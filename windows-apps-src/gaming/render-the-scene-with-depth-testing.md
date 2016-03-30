---
xxxxx: Xxxxxx xxx xxxxx xxxx xxxxx xxxxxxx
xxxxxxxxxxx: Xxxxxx x xxxxxx xxxxxx xx xxxxxx xxxxx xxxxxxx xx xxxx xxxxxx (xx xxxxxxxx) xxxxxx xxx xxxx xxxxx xxxxxx.
xx.xxxxxxx: xxYYYxxx-xYxY-xxYx-xYYY-YYYYYYYYYYYY
---

# Xxxxxx xxx xxxxx xxxx xxxxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxx x xxxxxx xxxxxx xx xxxxxx xxxxx xxxxxxx xx xxxx xxxxxx (xx xxxxxxxx) xxxxxx xxx xxxx xxxxx xxxxxx. Xxxx Y xx [Xxxxxxxxxxx: Xxxxxxxxx xxxxxx xxxxxxx xxxxx xxxxx xxxxxxx xx XxxxxxYX YY](implementing-depth-buffers-for-shadow-mapping.md).

## Xxxxxxx xxxxxxxxxxxxxx xxx xxxxx xxxxxxx


Xxxx xxxxxx xxxxxx xxxxx xx xxxxxxx xxx xxxxxxxxxxx xxxxx xxxxx xxxxxxxx xxx xxxx xxxxxx. Xxxxxxx xxx xxxxx xxxxx xxxxx, xxxx, xxx xxxxxxxxxx xxxxxxxx xxxxx x xxxxxxxx xxxxxx. Xxx xxx xxxx xxx xxxx xxxxxxxx xxxxxx xx xxxxxxx xxx xxxxx xxxxxxxx xxx xxxxxx xxx xxxxxxxx xxxxxxxxxxxx. Xxx xxxxxxxxxxx xxxxxxxx xx xxxxx xxxxx xxxx xx xxxx xxxxxx xxx xxxxx xxxx.

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

Xxxx, xxx xxxxx xxxxxx xxxx xxx xxx xxxxxxxxxxxx xxxxx xxxxx xxxxxxxx xxxxxxxx xx xxx xxxxxx xxxxxx xx xxxx xxxxxxx xxx xxxxx xx xx xxxxxx.

## Xxxx xxxxxxx xxx xxxxxxxx xx xx xxx xxxxx xxxxxxx


Xxxxx, xxxxx xxxx xxx xxxxx xx xx xxx xxxx xxxxxxx xx xxx xxxxx xx xxxxxxxxxxx xxx X xxx X xxxxxxxxxxx. Xx xxxx xxx xxxx xxxxxx xxx xxxxx \[Y, Y\] xxxx xx'x xxxxxxxx xxx xxx xxxxx xx xx xx xxxxxx. Xxxxxxxxx xxx xxx xxxx xxx xxxxx xxxx. X xxxxxx xxx xxxx xxx xxxx xxxxxxx xx xxxxxxx [Xxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/hh447231) xxx xxxxxxxxx xxx xxxxxx xxxxxxx xxx xxxxxxxx xxxxx.

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

## Xxxxx xxxx xxxxxxx xxx xxxxxx xxx


Xxx x xxxxxx xxxxxxxxxx xxxxxxxx (xxxxxx [XxxxxxXxx](https://msdn.microsoft.com/library/windows/desktop/bb509696) xx [XxxxxxXxxXxxxxXxxx](https://msdn.microsoft.com/library/windows/desktop/bb509697)) xx xxxx xxx xxxxx'x xxxxx xx xxxxx xxxxx xxxxxxx xxx xxxxx xxx. Xxxxxxx xxx xxxxxxxxxx xxxxx xxxxx xxxxx xxxxx, xxxxx xx `z / w`, xxx xxxx xxx xxxxx xx xxx xxxxxxxxxx xxxxxxxx. Xxxxx xx xxx x XxxxXxXxxxx xxxxxxxxxx xxxx xxx xxx xxxxxxx, xxx xxxxxxxxx xxxxxxxx xxxxxxx xxxx xxxx xxx xxxxxxxxxx xxxx xxxxxx; xxxx xxxxxxxxx xxxx xxx xxxxx xx xx xxxxxx.

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

## Xxxxxxx xxxxxxxx xx xx xxx xx xxxxxx


Xx xxx xxxxx xx xxx xx xxxxxx, xxx xxxxx xxxxxx xxxxxx xxxxxxx xxxxxx xxxxxxxx xxx xxx xx xx xxx xxxxx xxxxx.

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

Xxxxxxxxx, xxx xxxxx xxxxxx xxxxxx xxxxxxx xxx xxxxx xxxxx xxxxx xxxxxxx xxxxxxxx.

```cpp
return float4(input.color * ambient, 1.f);
```

Xx xxx xxxx xxxx xx xxxx xxxxxxxxxxx, xxxxx xxx xx [Xxxxxxx xxxxxx xxxx xx x xxxxx xx xxxxxxxx](target-a-range-of-hardware.md).

 

 




<!--HONumber=Mar16_HO1-->
