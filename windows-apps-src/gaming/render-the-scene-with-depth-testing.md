---
author: mtoepke
title: 深度のテストを使ったシーンのレンダリング
description: シャドウ効果を作成するには、頂点 (またはジオメトリ) シェーダーとピクセル シェーダーに深度のテストを追加します。
ms.assetid: bf496dfb-d7f5-af6b-d588-501164608560
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、レンダリング、シーン、深度のテスト、Direct3D、シャドウ
ms.localizationpriority: medium
ms.openlocfilehash: dc776a60e771cc8d5961e8c7b9c67eb99fabea3a
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5694425"
---
# <a name="render-the-scene-with-depth-testing"></a>深度のテストを使ったシーンのレンダリング




シャドウ効果を作成するには、頂点 (またはジオメトリ) シェーダーとピクセル シェーダーに深度のテストを追加します。 「[チュートリアル: Direct3D 11 の深度バッファーを使ったシャドウ ボリュームの実装](implementing-depth-buffers-for-shadow-mapping.md)」のパート 3 です。

## <a name="include-transformation-for-light-frustum"></a>ライトの視錐台の変換の追加


頂点シェーダーで、各頂点の変換後のライト空間位置を計算する必要があります。 定数バッファーを使って、ライト空間のモデル、ビュー、プロジェクションの各マトリックスを提供します  また、この定数バッファーを使って、照明計算用にライトの位置と法線を提供することもできます。 ライト空間内の変換された位置は深度のテスト時に使います。

```cpp
PixelShaderInput main(VertexShaderInput input)
{
    PixelShaderInput output;
    float4 pos = float4(input.pos, 1.0f);

    // Transform the vertex position into projected space.
    float4 modelPos = mul(pos, model);
    pos = mul(modelPos, view);
    pos = mul(pos, projection);
    output.pos = pos;

    // Transform the vertex position into projected space from the POV of the light.
    float4 lightSpacePos = mul(modelPos, lView);
    lightSpacePos = mul(lightSpacePos, lProjection);
    output.lightSpacePos = lightSpacePos;

    // Light ray
    float3 lRay = lPos.xyz - modelPos.xyz;
    output.lRay = lRay;
    
    // Camera ray
    output.view = eyePos.xyz - modelPos.xyz;

    // Transform the vertex normal into world space.
    float4 norm = float4(input.norm, 1.0f);
    norm = mul(norm, model);
    output.norm = norm.xyz;
    
    // Pass through the color and texture coordinates without modification.
    output.color = input.color;
    output.tex = input.tex;

    return output;
}
```

次に、ピクセル シェーダーでは、頂点シェーダーから提供された補完済みのライト空間位置を使って、ピクセルがシャドウ内かどうかをテストします。

## <a name="test-whether-the-position-is-in-the-light-frustum"></a>位置がライトの視錐台内かどうかのテスト


最初に、X 座標と Y 座標を正規化して、ピクセルがライトの視錐台内かどうかをチェックします。 両方が範囲 \[0, 1\] 内の場合は、ピクセルがシャドウ内にある可能性があります。 それ以外の場合は、深度のテストをスキップできます。 シェーダーでは、[Saturate](https://msdn.microsoft.com/library/windows/desktop/hh447231) を呼び出し、結果を元の値と比較することで、これをすばやくテストできます。

```cpp
// Compute texture coordinates for the current point's location on the shadow map.
float2 shadowTexCoords;
shadowTexCoords.x = 0.5f + (input.lightSpacePos.x / input.lightSpacePos.w * 0.5f);
shadowTexCoords.y = 0.5f - (input.lightSpacePos.y / input.lightSpacePos.w * 0.5f);
float pixelDepth = input.lightSpacePos.z / input.lightSpacePos.w;

float lighting = 1;

// Check if the pixel texture coordinate is in the view frustum of the 
// light before doing any shadow work.
if ((saturate(shadowTexCoords.x) == shadowTexCoords.x) &&
    (saturate(shadowTexCoords.y) == shadowTexCoords.y) &&
    (pixelDepth > 0))
{
```

## <a name="depth-test-against-the-shadow-map"></a>シャドウ マップに対する深度のテスト


サンプル比較関数 ([SampleCmp](https://msdn.microsoft.com/library/windows/desktop/bb509696) または [SampleCmpLevelZero](https://msdn.microsoft.com/library/windows/desktop/bb509697)) を使って、深度マップに対するライト空間内のピクセルの深度をテストします。 正規化されたライト空間の深度値 (`z / w`) を計算し、その値を比較関数に渡します。 サンプラーでは LessOrEqual 比較テストを使うため、比較テストに合格すると組み込みメソッドの関数は 0 を返します。これは、そのピクセルがシャドウの内側にあることを示しています。

```cpp
// Use an offset value to mitigate shadow artifacts due to imprecise 
// floating-point values (shadow acne).
//
// This is an approximation of epsilon * tan(acos(saturate(NdotL))):
float margin = acos(saturate(NdotL));
#ifdef LINEAR
// The offset can be slightly smaller with smoother shadow edges.
float epsilon = 0.0005 / margin;
#else
float epsilon = 0.001 / margin;
#endif
// Clamp epsilon to a fixed range so it doesn't go overboard.
epsilon = clamp(epsilon, 0, 0.1);

// Use the SampleCmpLevelZero Texture2D method (or SampleCmp) to sample from 
// the shadow map, just as you would with Direct3D feature level 10_0 and
// higher.  Feature level 9_1 only supports LessOrEqual, which returns 0 if
// the pixel is in the shadow.
lighting = float(shadowMap.SampleCmpLevelZero(
    shadowSampler,
    shadowTexCoords,
    pixelDepth + epsilon
    )
    );
```

## <a name="compute-lighting-in-or-out-of-shadow"></a>シャドウの内側または外側の照明の計算


ピクセルがシャドウの内側にない場合は、ピクセル シェーダーは直接照明を計算し、それをピクセル値に追加します。

```cpp
return float4(input.color * (ambient + DplusS(N, L, NdotL, input.view)), 1.f);
```

```cpp
float3 DplusS(float3 N, float3 L, float NdotL, float3 view)
{
    const float3 Kdiffuse = float3(.5f, .5f, .4f);
    const float3 Kspecular = float3(.2f, .2f, .3f);
    const float exponent = 3.f;

    // Compute the diffuse coefficient.
    float diffuseConst = saturate(NdotL);

    // Compute the diffuse lighting value.
    float3 diffuse = Kdiffuse * diffuseConst;

    // Compute the specular highlight.
    float3 R = reflect(-L, N);
    float3 V = normalize(view);
    float3 RdotV = dot(R, V);
    float3 specular = Kspecular * pow(saturate(RdotV), exponent);

    return (diffuse + specular);
}
```

それ以外の場合は、アンビエント照明を使ってピクセル値を計算します。

```cpp
return float4(input.color * ambient, 1.f);
```

このチュートリアルの次のパートでは、[ハードウェアの範囲でシャドウ マップをサポートする](target-a-range-of-hardware.md)方法について説明します。

 

 




