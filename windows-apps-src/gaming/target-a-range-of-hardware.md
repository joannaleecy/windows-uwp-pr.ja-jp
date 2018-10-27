---
author: mtoepke
title: ハードウェアの範囲でのシャドウ マップのサポート
description: より高速なデバイスでは高品質なシャドウを、性能が低いデバイスではよりすばやいシャドウをレンダリングします。
ms.assetid: d97c0544-44f2-4e29-5e02-54c45e0dff4e
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, UWP, ゲーム, シャドウ マップ, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: a9c53578fc67c13aafa1c8e39ad1d2910981081d
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5691932"
---
# <a name="support-shadow-maps-on-a-range-of-hardware"></a><span data-ttu-id="9b37e-104">ハードウェアの範囲でのシャドウ マップのサポート</span><span class="sxs-lookup"><span data-stu-id="9b37e-104">Support shadow maps on a range of hardware</span></span>




<span data-ttu-id="9b37e-105">より高速なデバイスでは高品質なシャドウを、性能が低いデバイスではよりすばやいシャドウをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="9b37e-105">Render higher-fidelity shadows on faster devices and faster shadows on less powerful devices.</span></span> <span data-ttu-id="9b37e-106">「[チュートリアル: Direct3D 11 の深度バッファーを使ったシャドウ ボリュームの実装](implementing-depth-buffers-for-shadow-mapping.md)」のパート 4 です。</span><span class="sxs-lookup"><span data-stu-id="9b37e-106">Part 4 of [Walkthrough: Implement shadow volumes using depth buffers in Direct3D 11](implementing-depth-buffers-for-shadow-mapping.md).</span></span>

## <a name="comparison-filter-types"></a><span data-ttu-id="9b37e-107">フィルターの種類の比較</span><span class="sxs-lookup"><span data-stu-id="9b37e-107">Comparison filter types</span></span>


<span data-ttu-id="9b37e-108">パフォーマンス ペナルティに対する余裕がデバイスにある場合にのみ、リニア フィルタリングを使います。</span><span class="sxs-lookup"><span data-stu-id="9b37e-108">Only use linear filtering if the device can afford the performance penalty.</span></span> <span data-ttu-id="9b37e-109">通常、Direct3D 機能レベル 9\_1 のデバイスには、シャドウにリニア フィルタリングを使うだけの処理能力がありません。</span><span class="sxs-lookup"><span data-stu-id="9b37e-109">Generally, Direct3D feature level 9\_1 devices don't have enough power to spare for linear filtering on shadows.</span></span> <span data-ttu-id="9b37e-110">そうしたデバイスでは、代わりにポイント フィルタリングを使います。</span><span class="sxs-lookup"><span data-stu-id="9b37e-110">Use point filtering instead on these devices.</span></span> <span data-ttu-id="9b37e-111">リニア フィルタリングを使う場合は、シャドウのエッジをブレンドするようにピクセル シェーダーを調整します。</span><span class="sxs-lookup"><span data-stu-id="9b37e-111">When you use linear filtering, adjust the pixel shader so that it blends the shadow edges.</span></span>

<span data-ttu-id="9b37e-112">ポイント フィルタリングの比較サンプラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="9b37e-112">Create the comparison sampler for point filtering:</span></span>

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

<span data-ttu-id="9b37e-113">次に、リニア フィルタリングのサンプラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="9b37e-113">Then create a sampler for linear filtering:</span></span>

```cpp
comparisonSamplerDesc.Filter = D3D11_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR;
DX::ThrowIfFailed(
    pD3DDevice->CreateSamplerState(
        &comparisonSamplerDesc,
        &m_comparisonSampler_linear
        )
    );
```

<span data-ttu-id="9b37e-114">サンプラーを選びます。</span><span class="sxs-lookup"><span data-stu-id="9b37e-114">Choose a sampler:</span></span>

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

<span data-ttu-id="9b37e-115">リニア フィルタリングでシャドウのエッジをブレンドします。</span><span class="sxs-lookup"><span data-stu-id="9b37e-115">Blend shadow edges with linear filtering:</span></span>

```cpp
// Blends the shadow area into the lit area.
float3 light = lighting * (ambient + DplusS(N, L, NdotL, input.view));
float3 shadow = (1.0f - lighting) * ambient;
return float4(input.color * (light + shadow), 1.f);
```

## <a name="shadow-buffer-size"></a><span data-ttu-id="9b37e-116">シャドウ バッファーのサイズ</span><span class="sxs-lookup"><span data-stu-id="9b37e-116">Shadow buffer size</span></span>


<span data-ttu-id="9b37e-117">シャドウ マップを大きくするとブロックノイズが発生しなくなりますが、グラフィックス メモリ内の領域を多く消費します。</span><span class="sxs-lookup"><span data-stu-id="9b37e-117">Larger shadow maps won't look as blocky but they take up more space in graphics memory.</span></span> <span data-ttu-id="9b37e-118">ゲームでさまざまなシャドウ マップのサイズを試し、さまざまなデバイスとディスプレイ サイズで結果を確認してください。</span><span class="sxs-lookup"><span data-stu-id="9b37e-118">Experiment with different shadow map sizes in your game and observe the results in different types of devices and different display sizes.</span></span> <span data-ttu-id="9b37e-119">少ないグラフィックス メモリで良い結果が得られるように、カスケードされたシャドウ マップなどの最適化を検討してください。</span><span class="sxs-lookup"><span data-stu-id="9b37e-119">Consider an optimization like cascaded shadow maps to get better results with less graphics memory.</span></span> <span data-ttu-id="9b37e-120">「[シャドウ深度マップを向上させるための一般的な方法](https://msdn.microsoft.com/library/windows/desktop/ee416324)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9b37e-120">See [Common Techniques to Improve Shadow Depth Maps](https://msdn.microsoft.com/library/windows/desktop/ee416324).</span></span>

## <a name="shadow-buffer-depth"></a><span data-ttu-id="9b37e-121">シャドウ バッファーの深度</span><span class="sxs-lookup"><span data-stu-id="9b37e-121">Shadow buffer depth</span></span>


<span data-ttu-id="9b37e-122">シャドウ バッファーの精度を上げると、深度のテスト結果がより正確になり、z バッファー ファイティングなどの問題を避けるのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="9b37e-122">Greater precision in the shadow buffer will give more accurate depth test results, which helps avoid issues like z-buffer fighting.</span></span> <span data-ttu-id="9b37e-123">ただし、シャドウ マップを大きくした場合と同じように、精度を上げると、消費するメモリの量が多くなります。</span><span class="sxs-lookup"><span data-stu-id="9b37e-123">But like larger shadow maps, greater precision takes up more memory.</span></span> <span data-ttu-id="9b37e-124">ゲームで異なる深度の精度の種類 (DXGI\_FORMAT\_R24G8\_TYPELESS と DXGI\_FORMAT\_R16\_TYPELESS) を使って、さまざまな機能レベルで速度と品質を確認してください。</span><span class="sxs-lookup"><span data-stu-id="9b37e-124">Experiment with different depth precision types in your game - DXGI\_FORMAT\_R24G8\_TYPELESS versus DXGI\_FORMAT\_R16\_TYPELESS - and observe the speed and quality on different feature levels.</span></span>

## <a name="optimizing-precompiled-shaders"></a><span data-ttu-id="9b37e-125">プリコンパイル済みシェーダーの最適化</span><span class="sxs-lookup"><span data-stu-id="9b37e-125">Optimizing precompiled shaders</span></span>


<span data-ttu-id="9b37e-126">ユニバーサル Windows プラットフォーム (UWP) アプリでは動的シェーダー コンパイルを使うことができますが、動的シェーダー リンクを使う方が高速に処理できます。</span><span class="sxs-lookup"><span data-stu-id="9b37e-126">Universal Windows Platform (UWP) apps can use dynamic shader compilation, but it's faster to use dynamic shader linking.</span></span> <span data-ttu-id="9b37e-127">また、コンパイラ ディレクティブと `#ifdef` ブロックを使って、異なるバージョンのシェーダーを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="9b37e-127">You can also use compiler directives and `#ifdef` blocks to create different versions of shaders.</span></span> <span data-ttu-id="9b37e-128">この処理を実行するには、テキスト エディターで Visual Studio プロジェクト ファイルを開き、HLSL の `<FxcCompiler>` エントリを (それぞれ適切なプリプロセッサの定義を含めて) 複数追加します。</span><span class="sxs-lookup"><span data-stu-id="9b37e-128">This is done by opening the Visual Studio project file in a text editor and adding multiple `<FxcCompiler>` entries for the HLSL (each with the appropriate preprocessor definitions).</span></span> <span data-ttu-id="9b37e-129">このとき、ファイル名を別々にする必要があることに注意してください。この例では、バージョンが異なるシェーダーの名前に \_point と \_linear が追加されます。</span><span class="sxs-lookup"><span data-stu-id="9b37e-129">Note that this necessitates different filenames; in this case, Visual Studio appends \_point and \_linear to the different versions of the shader.</span></span>

<span data-ttu-id="9b37e-130">リニア フィルター処理を行ったバージョンのシェーダーのプロジェクト ファイル エントリでは、次のように、LINEAR を定義します。</span><span class="sxs-lookup"><span data-stu-id="9b37e-130">The project file entry for the linear filtered version of the shader defines LINEAR:</span></span>

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

<span data-ttu-id="9b37e-131">リニア フィルター処理を行ったバージョンのシェーダーのプロジェクト ファイル エントリには、次のように、プリプロセッサの定義を含めません。</span><span class="sxs-lookup"><span data-stu-id="9b37e-131">The project file entry for the linear filtered version of the shader does not include preprocessor definitions:</span></span>

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

 

 




