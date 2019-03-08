---
title: ハードウェアの範囲でのシャドウ マップのサポート
description: より高速なデバイスでは高品質なシャドウを、性能が低いデバイスではよりすばやいシャドウをレンダリングします。
ms.assetid: d97c0544-44f2-4e29-5e02-54c45e0dff4e
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP, ゲーム, シャドウ マップ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: d0e661065f86ac173a6ce323281c80fc964d0a4c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646367"
---
# <a name="support-shadow-maps-on-a-range-of-hardware"></a>ハードウェアの範囲でのシャドウ マップのサポート




より高速なデバイスでは高品質なシャドウを、性能が低いデバイスではよりすばやいシャドウをレンダリングします。 パート 4 の[チュートリアル。Direct3d11 の深度バッファーを使用してボリュームをシャドウ実装](implementing-depth-buffers-for-shadow-mapping.md)します。

## <a name="comparison-filter-types"></a>フィルターの種類の比較


パフォーマンス ペナルティに対する余裕がデバイスにある場合にのみ、リニア フィルタリングを使います。 一般に、Direct3D 機能レベル 9\_1 のデバイスの影のリニア フィルタ リングに十分な能力はありません。 そうしたデバイスでは、代わりにポイント フィルタリングを使います。 リニア フィルタリングを使う場合は、シャドウのエッジをブレンドするようにピクセル シェーダーを調整します。

ポイント フィルタリングの比較サンプラーを作成します。

```cpp
D3D11_SAMPLER_DESC comparisonSamplerDesc;
ZeroMemory(&comparisonSamplerDesc, sizeof(D3D11_SAMPLER_DESC));
comparisonSamplerDesc.AddressU = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.AddressV = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.AddressW = D3D11_TEXTURE_ADDRESS_BORDER;
comparisonSamplerDesc.BorderColor[0] = 1.0f;
comparisonSamplerDesc.BorderColor[1] = 1.0f;
comparisonSamplerDesc.BorderColor[2] = 1.0f;
comparisonSamplerDesc.BorderColor[3] = 1.0f;
comparisonSamplerDesc.MinLOD = 0.f;
comparisonSamplerDesc.MaxLOD = D3D11_FLOAT32_MAX;
comparisonSamplerDesc.MipLODBias = 0.f;
comparisonSamplerDesc.MaxAnisotropy = 0;
comparisonSamplerDesc.ComparisonFunc = D3D11_COMPARISON_LESS_EQUAL;
comparisonSamplerDesc.Filter = D3D11_FILTER_COMPARISON_MIN_MAG_MIP_POINT;

// Point filtered shadows can be faster, and may be a good choice when
// rendering on hardware with lower feature levels. This sample has a
// UI option to enable/disable filtering so you can see the difference
// in quality and speed.

DX::ThrowIfFailed(
    pD3DDevice->CreateSamplerState(
        &comparisonSamplerDesc,
        &m_comparisonSampler_point
        )
    );
```

次に、リニア フィルタリングのサンプラーを作成します。

```cpp
comparisonSamplerDesc.Filter = D3D11_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR;
DX::ThrowIfFailed(
    pD3DDevice->CreateSamplerState(
        &comparisonSamplerDesc,
        &m_comparisonSampler_linear
        )
    );
```

サンプラーを選びます。

```cpp
ID3D11PixelShader* pixelShader;
ID3D11SamplerState** comparisonSampler;
if (m_useLinear)
{
    pixelShader = m_shadowPixelShader_linear.Get();
    comparisonSampler = m_comparisonSampler_linear.GetAddressOf();
}
else
{
    pixelShader = m_shadowPixelShader_point.Get();
    comparisonSampler = m_comparisonSampler_point.GetAddressOf();
}

// Attach our pixel shader.
context->PSSetShader(
    pixelShader,
    nullptr,
    0
    );

context->PSSetSamplers(0, 1, comparisonSampler);
context->PSSetShaderResources(0, 1, m_shadowResourceView.GetAddressOf());
```

リニア フィルタリングでシャドウのエッジをブレンドします。

```cpp
// Blends the shadow area into the lit area.
float3 light = lighting * (ambient + DplusS(N, L, NdotL, input.view));
float3 shadow = (1.0f - lighting) * ambient;
return float4(input.color * (light + shadow), 1.f);
```

## <a name="shadow-buffer-size"></a>シャドウ バッファーのサイズ


シャドウ マップを大きくするとブロックノイズが発生しなくなりますが、グラフィックス メモリ内の領域を多く消費します。 ゲームでさまざまなシャドウ マップのサイズを試し、さまざまなデバイスとディスプレイ サイズで結果を確認してください。 少ないグラフィックス メモリで良い結果が得られるように、カスケードされたシャドウ マップなどの最適化を検討してください。 「[シャドウ深度マップを向上させるための一般的な方法](https://msdn.microsoft.com/library/windows/desktop/ee416324)」をご覧ください。

## <a name="shadow-buffer-depth"></a>シャドウ バッファーの深度


シャドウ バッファーの精度を上げると、深度のテスト結果がより正確になり、z バッファー ファイティングなどの問題を避けるのに役立ちます。 ただし、シャドウ マップを大きくした場合と同じように、精度を上げると、消費するメモリの量が多くなります。 ゲーム - DXGI の深さが異なる有効桁数の型を実験\_形式\_R24G8\_DXGI と TYPELESS\_形式\_R16\_TYPELESS - で、速度と品質を確認別の機能レベル。

## <a name="optimizing-precompiled-shaders"></a>プリコンパイル済みシェーダーの最適化


ユニバーサル Windows プラットフォーム (UWP) アプリでは動的シェーダー コンパイルを使うことができますが、動的シェーダー リンクを使う方が高速に処理できます。 また、コンパイラ ディレクティブと `#ifdef` ブロックを使って、異なるバージョンのシェーダーを作成することができます。 この処理を実行するには、テキスト エディターで Visual Studio プロジェクト ファイルを開き、HLSL の `<FxcCompiler>` エントリを (それぞれ適切なプリプロセッサの定義を含めて) 複数追加します。 別のファイル名; が必要になりますこのことに注意してください。この場合は、Visual Studio に追加\_ポイントと\_シェーダーの異なるバージョンを線形。

リニア フィルター処理を行ったバージョンのシェーダーのプロジェクト ファイル エントリでは、次のように、LINEAR を定義します。

```xml
<FxCompile Include="Content\ShadowPixelShader.hlsl">
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Release|ARM'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Debug|Win32'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Release|Win32'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Debug|x64'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Release|x64'">Pixel</ShaderType>
  <DisableOptimizations Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">false</DisableOptimizations>
  <EnableDebuggingInformation Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">true</EnableDebuggingInformation>
  <DisableOptimizations Condition="'$(Configuration)|$(Platform)'=='Debug|Win32'">false</DisableOptimizations>
  <DisableOptimizations Condition="'$(Configuration)|$(Platform)'=='Debug|x64'">false</DisableOptimizations>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">$(OutDir)%(Filename)_linear.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Release|ARM'">$(OutDir)%(Filename)_linear.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Debug|Win32'">$(OutDir)%(Filename)_linear.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Release|Win32'">$(OutDir)%(Filename)_linear.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Debug|x64'">$(OutDir)%(Filename)_linear.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Release|x64'">$(OutDir)%(Filename)_linear.cso</ObjectFileOutput>
  <PreprocessorDefinitions Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">LINEAR</PreprocessorDefinitions>
  <PreprocessorDefinitions Condition="'$(Configuration)|$(Platform)'=='Release|ARM'">LINEAR</PreprocessorDefinitions>
  <PreprocessorDefinitions Condition="'$(Configuration)|$(Platform)'=='Debug|Win32'">LINEAR</PreprocessorDefinitions>
  <PreprocessorDefinitions Condition="'$(Configuration)|$(Platform)'=='Release|Win32'">LINEAR</PreprocessorDefinitions>
  <PreprocessorDefinitions Condition="'$(Configuration)|$(Platform)'=='Debug|x64'">LINEAR</PreprocessorDefinitions>
  <PreprocessorDefinitions Condition="'$(Configuration)|$(Platform)'=='Release|x64'">LINEAR</PreprocessorDefinitions>
</FxCompile>
```

リニア フィルター処理を行ったバージョンのシェーダーのプロジェクト ファイル エントリには、次のように、プリプロセッサの定義を含めません。

```xml
<FxCompile Include="Content\ShadowPixelShader.hlsl">
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Release|ARM'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Debug|Win32'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Release|Win32'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Debug|x64'">Pixel</ShaderType>
  <ShaderType Condition="'$(Configuration)|$(Platform)'=='Release|x64'">Pixel</ShaderType>
  <DisableOptimizations Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">false</DisableOptimizations>
  <EnableDebuggingInformation Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">true</EnableDebuggingInformation>
  <DisableOptimizations Condition="'$(Configuration)|$(Platform)'=='Debug|Win32'">false</DisableOptimizations>
  <DisableOptimizations Condition="'$(Configuration)|$(Platform)'=='Debug|x64'">false</DisableOptimizations>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Debug|ARM'">$(OutDir)%(Filename)_point.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Release|ARM'">$(OutDir)%(Filename)_point.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Debug|Win32'">$(OutDir)%(Filename)_point.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Release|Win32'">$(OutDir)%(Filename)_point.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Debug|x64'">$(OutDir)%(Filename)_point.cso</ObjectFileOutput>
  <ObjectFileOutput Condition="'$(Configuration)|$(Platform)'=='Release|x64'">$(OutDir)%(Filename)_point.cso</ObjectFileOutput>
</FxCompile>
```

 

 




