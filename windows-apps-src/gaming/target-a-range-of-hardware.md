---
xxxxx: Xxxxxxx xxxxxx xxxx xx x xxxxx xx xxxxxxxx
xxxxxxxxxxx: Xxxxxx xxxxxx-xxxxxxxx xxxxxxx xx xxxxxx xxxxxxx xxx xxxxxx xxxxxxx xx xxxx xxxxxxxx xxxxxxx.
xx.xxxxxxx: xYYxYYYY-YYxY-YxYY-YxYY-YYxYYxYxxxYx
---

# Xxxxxxx xxxxxx xxxx xx x xxxxx xx xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxx xxxxxx-xxxxxxxx xxxxxxx xx xxxxxx xxxxxxx xxx xxxxxx xxxxxxx xx xxxx xxxxxxxx xxxxxxx. Xxxx Y xx [Xxxxxxxxxxx: Xxxxxxxxx xxxxxx xxxxxxx xxxxx xxxxx xxxxxxx xx XxxxxxYX YY](implementing-depth-buffers-for-shadow-mapping.md).

## Xxxxxxxxxx xxxxxx xxxxx


Xxxx xxx xxxxxx xxxxxxxxx xx xxx xxxxxx xxx xxxxxx xxx xxxxxxxxxxx xxxxxxx. Xxxxxxxxx, XxxxxxYX xxxxxxx xxxxx Y\_Y xxxxxxx xxx'x xxxx xxxxxx xxxxx xx xxxxx xxx xxxxxx xxxxxxxxx xx xxxxxxx. Xxx xxxxx xxxxxxxxx xxxxxxx xx xxxxx xxxxxxx. Xxxx xxx xxx xxxxxx xxxxxxxxx, xxxxxx xxx xxxxx xxxxxx xx xxxx xx xxxxxx xxx xxxxxx xxxxx.

Xxxxxx xxx xxxxxxxxxx xxxxxxx xxx xxxxx xxxxxxxxx:

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

Xxxx xxxxxx x xxxxxxx xxx xxxxxx xxxxxxxxx:

```cpp
comparisonSamplerDesc.Filter = D3D11_FILTER_COMPARISON_MIN_MAG_MIP_LINEAR;
DX::ThrowIfFailed(
    pD3DDevice->CreateSamplerState(
        &comparisonSamplerDesc,
        &m_comparisonSampler_linear
        )
    );
```

Xxxxxx x xxxxxxx:

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

Xxxxx xxxxxx xxxxx xxxx xxxxxx xxxxxxxxx:

```cpp
// Blends the shadow area into the lit area.
float3 light = lighting * (ambient + DplusS(N, L, NdotL, input.view));
float3 shadow = (1.0f - lighting) * ambient;
return float4(input.color * (light + shadow), 1.f);
```

## Xxxxxx xxxxxx xxxx


Xxxxxx xxxxxx xxxx xxx'x xxxx xx xxxxxx xxx xxxx xxxx xx xxxx xxxxx xx xxxxxxxx xxxxxx. Xxxxxxxxxx xxxx xxxxxxxxx xxxxxx xxx xxxxx xx xxxx xxxx xxx xxxxxxx xxx xxxxxxx xx xxxxxxxxx xxxxx xx xxxxxxx xxx xxxxxxxxx xxxxxxx xxxxx. Xxxxxxxx xx xxxxxxxxxxxx xxxx xxxxxxxx xxxxxx xxxx xx xxx xxxxxx xxxxxxx xxxx xxxx xxxxxxxx xxxxxx. Xxx [Xxxxxx Xxxxxxxxxx xx Xxxxxxx Xxxxxx Xxxxx Xxxx](https://msdn.microsoft.com/library/windows/desktop/ee416324).

## Xxxxxx xxxxxx xxxxx


Xxxxxxx xxxxxxxxx xx xxx xxxxxx xxxxxx xxxx xxxx xxxx xxxxxxxx xxxxx xxxx xxxxxxx, xxxxx xxxxx xxxxx xxxxxx xxxx x-xxxxxx xxxxxxxx. Xxx xxxx xxxxxx xxxxxx xxxx, xxxxxxx xxxxxxxxx xxxxx xx xxxx xxxxxx. Xxxxxxxxxx xxxx xxxxxxxxx xxxxx xxxxxxxxx xxxxx xx xxxx xxxx - XXXX\_XXXXXX\_XYYXY\_XXXXXXXX xxxxxx XXXX\_XXXXXX\_XYY\_XXXXXXXX - xxx xxxxxxx xxx xxxxx xxx xxxxxxx xx xxxxxxxxx xxxxxxx xxxxxx.

## Xxxxxxxxxx xxxxxxxxxxx xxxxxxx


Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx xxx xxxxxxx xxxxxx xxxxxxxxxxx, xxx xx'x xxxxxx xx xxx xxxxxxx xxxxxx xxxxxxx. Xxx xxx xxxx xxx xxxxxxxx xxxxxxxxxx xxx `#ifdef` xxxxxx xx xxxxxx xxxxxxxxx xxxxxxxx xx xxxxxxx. Xxxx xx xxxx xx xxxxxxx xxx Xxxxxx Xxxxxx xxxxxxx xxxx xx x xxxx xxxxxx xxx xxxxxx xxxxxxxx `<FxcCompiler>` xxxxxxx xxx xxx XXXX (xxxx xxxx xxx xxxxxxxxxxx xxxxxxxxxxxx xxxxxxxxxxx). Xxxx xxxx xxxx xxxxxxxxxxxx xxxxxxxxx xxxxxxxxx; xx xxxx xxxx, Xxxxxx Xxxxxx xxxxxxx \_xxxxx xxx \_xxxxxx xx xxx xxxxxxxxx xxxxxxxx xx xxx xxxxxx.

Xxx xxxxxxx xxxx xxxxx xxx xxx xxxxxx xxxxxxxx xxxxxxx xx xxx xxxxxx xxxxxxx XXXXXX:

```
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

Xxx xxxxxxx xxxx xxxxx xxx xxx xxxxxx xxxxxxxx xxxxxxx xx xxx xxxxxx xxxx xxx xxxxxxx xxxxxxxxxxxx xxxxxxxxxxx:

```
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

 

 




<!--HONumber=Mar16_HO1-->
