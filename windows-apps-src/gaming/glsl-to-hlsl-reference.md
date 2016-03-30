---
xxxxx: XXXX-xx-XXXX xxxxxxxxx
xxxxxxxxxxx: Xxx xxxx xxxx XxxxXX Xxxxxx Xxxxxxxx (XXXX) xxxx xx Xxxxxxxxx Xxxx Xxxxx Xxxxxx Xxxxxxxx (XXXX) xxxx xxxx xxx xxxx xxxx xxxxxxxx xxxxxxxxxxxx xxxx XxxxXX XX Y.Y xx XxxxxxYX YY xx xxxxxx x xxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX).
xx.xxxxxxx: YYYxYYxY-xxYx-YYxY-YYxY-xYYxYxYxYYYY
---

# XXXX-xx-XXXX xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx xxxx xxxx XxxxXX Xxxxxx Xxxxxxxx (XXXX) xxxx xx Xxxxxxxxx Xxxx Xxxxx Xxxxxx Xxxxxxxx (XXXX) xxxx xxxx xxx [xxxx xxxx xxxxxxxx xxxxxxxxxxxx xxxx XxxxXX XX Y.Y xx XxxxxxYX YY](port-from-opengl-es-2-0-to-directx-11-1.md) xx xxxxxx x xxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX). Xxx XXXX xxxx xx xxxxxxxx xx xxxxxx xx xxxxxxxxxx xxxx XxxxXX XX Y.Y; xxx XXXX xx xxxxxxxxxx xxxx XxxxxxYX YY. Xxx xxxx xxxxx xxx xxxxxxxxxxx xxxxxxx XxxxxxYX YY xxx xxxxxxxx xxxxxxxx xx XxxxxxYX, xxx [Xxxxxxx xxxxxxx](feature-mapping.md).

-   [Xxxxxxxxx XxxxXX XX Y.Y xxxx XxxxxxYX YY](#compare)
-   [Xxxxxxx XXXX xxxxxxxxx xx XXXX](#variables)
-   [Xxxxxxx XXXX xxxxx xx XXXX](#types)
-   [Xxxxxxx XXXX xxx-xxxxxxx xxxxxx xxxxxxxxx xx XXXX](#porting_glsl_pre-defined_global_variables_to_hlsl)
-   [Xxxxxxxx xx xxxxxxx XXXX xxxxxxxxx xx XXXX](#example1)
    -   [Xxxxxxx, xxxxxxxxx, xxx xxxxxxx xx XXXX](#uniform___attribute__and_varying_in_glsl)
    -   [Xxxxxxxx xxxxxxx xxx xxxx xxxxxxxxx xx XXXX](#constant_buffers_and_data_transfers_in_hlsl)
-   [Xxxxxxxx xx xxxxxxx XxxxXX xxxxxxxxx xxxx xx XxxxxxYX](#example2)
-   [Xxxxxxx xxxxxx](#related_topics)

## Xxxxxxxxx XxxxXX XX Y.Y xxxx XxxxxxYX YY


XxxxXX XX Y.Y xxx XxxxxxYX YY xxxx xxxx xxxxxxxxxxxx. Xxxx xxxx xxxx xxxxxxx xxxxxxxxx xxxxxxxxx xxx xxxxxxxx xxxxxxxx. Xxx XxxxxxYX YY xx x xxxxxxxxx xxxxxxxxxxxxxx xxx XXX, xxx x xxxxxxxxxxxxx; XxxxXX XX Y.Y xx x xxxxxxxxx xxxxxxxxxxxxx xxx XXX, xxx xx xxxxxxxxxxxxxx. XxxxxxYX YY xxx XxxxXX XX Y.Y xxxxxxxxx xxxxxx xx xxxxx xxxx:

| XxxxXX XX Y.Y                                                                                         | XxxxxxYX YY                                                                                                            |
|-------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| Xxxxxxxx xxx xxxxxxxxx xxxxxx xxxxxxxx xxxxxxxxxxxxx xxxx xxxxxx xxxxxxxx xxxxxxxxxxxxxxx             | Xxxxxxxxx xxxxxxxxxxxxxx xx xxxxxxxx xxxxxxxxxxx xxx xxxxxxxxxxxxx xx Xxxxxxx xxxxxxxxx                                |
| Xxxxxxxxxx xxx xxxxxxxx xxxxxxxxx, xxxxxxx xxxxxxx xxxx xxxxxxxxx                                     | Xxxxxx xxxxxx xx xxxxxxxx xxxxxx; xxx xxx xxxxxx xxxxxxxxx xxx xxxxxxxxxx                                              |
| Xxxxxxxx xxxxxx-xxxxx xxxxxxx xxx xxxxx-xxxxx xxxxxxxxx (xxx xxxxxxx, Xxxxxx XxxxxxXxxxx Xxxxx (XXX)) | Xxxxxx-xxxxx xxxxxxx, xxxx XxxxxxYX, xxx xxxxx xxxx xxxxx xxxxxxx xx xxxxxxxx xxxxxxxxxxx xxx Xxxxxxx xxxx             |
| Xxxxxxxx xxxxxxx xxxxxxxxxxxxx xxx xxxxxxxxxx                                                         | Xxxxxxxxx xxxx xxxxxxxx xxxxxxxx xx xxx XXX xx x xxxxxxx xxx xx xxxx xxxx'x xxxxxxxx xx xxx xxxxxxxxxx xxxxxxxx xxxxxx |

 

XXXX xxx XXXX xxxxxxxxx xxxxxx xx xxxxx xxxx:

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XXXX</th>
<th align="left">XXXX</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">Xxxxxxxxxx, xxxx-xxxxxxx (X xxxx)</td>
<td align="left">Xxxxxx xxxxxxxx, xxxx-xxxxxxx (X++ xxxx)</td>
</tr>
<tr class="even">
<td align="left">Xxxxxx xxxxxxxxxxx xxxxxxxxxx xxxx xxx xxxxxxxx XXX</td>
<td align="left">Xxx XXXX xxxxxxxx [compiles the shader](https://msdn.microsoft.com/library/windows/desktop/bb509633) xx xx xxxxxxxxxxxx xxxxxx xxxxxxxxxxxxxx xxxxxx XxxxxxYX xxxxxx xx xx xxx xxxxxx.
<div class="alert">
<strong>Xxxx</strong>  Xxxx xxxxxx xxxxxxxxxxxxxx xx xxxxxxxx xxxxxxxxxxx. Xx'x xxxxxxxxx xxxxxxxx xx xxx xxxxx xxxx, xxxxxx xxxx xx xxx xxx xxxx.
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left">[
            Variable](#variables) xxxxxxx xxxxxxxxx</td>
<td align="left">Xxxxxxxx xxxxxxx xxx xxxx xxxxxxxxx xxx xxxxx xxxxxx xxxxxxxxxxxx</td>
</tr>
<tr class="even">
<td align="left"><p>[Types](#types)</p>
<p>Xxxxxxx xxxxxx xxxx: xxxY/Y/Y</p>
<p>xxxx, xxxxxxx, xxxxx</p></td>
<td align="left"><p>Xxxxxxx xxxxxx xxxx: xxxxxY/Y/Y</p>
<p>xxxYYxxxxx, xxxYYxxxxx</p></td>
</tr>
<tr class="odd">
<td align="left">xxxxxxxYX [Xxxxxxxx]</td>
<td align="left">[
            texture.Sample](https://msdn.microsoft.com/library/windows/desktop/bb509695) [xxxxxxxx.Xxxxxxxx]</td>
</tr>
<tr class="even">
<td align="left">xxxxxxxYX [xxxxxxxx]</td>
<td align="left">[
            Texture2D](https://msdn.microsoft.com/library/windows/desktop/ff471525) [xxxxxxxx]</td>
</tr>
<tr class="odd">
<td align="left">Xxx-xxxxx xxxxxxxx (xxxxxxx)</td>
<td align="left">Xxxxxx-xxxxx xxxxxxxx (xxxxxxx)
<div class="alert">
<strong>Xxxx</strong>   Xxx xxx <strong>xxx_xxxxx</strong> xxxx-xxxxxxxx xx xxxxxx xxx xxxxxx xxx xxx xxxxxxxx. Xxx xxxx xxxx, xxx [Variable Syntax](https://msdn.microsoft.com/library/windows/desktop/bb509706). Xxx xxx xxxx xxxxxxx x xxxxxxxx xxxx xx x xxxxxx xx xxxxxx xxx xxxxxx xxxxxxx.
</div>
<div>
 
</div></td>
</tr>
<tr class="even">
<td align="left">Xxxxxxxx xxxxxx</td>
<td align="left">Xxxxx xxxxxx</td>
</tr>
</tbody>
</table>

 

> **Xxxx**  XXXX xxx xxxxxxxx xxx xxxxxxxx xx xxx xxxxxxxx xxxxxxx. Xx XXXX, xxxx XxxxxxYX Y, xxx xxxxxxx xxxxxxx xx xxxx xx xxx xxxxxxx xxxxx.

 

Xx XXXX, xxx xxxxxxx xxxx xx xxx XxxxXX xxxxx xx xxx-xxxxxxx xxxxxx xxxxxxxxx. Xxx xxxxxxx, xxxx XXXX, xxx xxx xxx **xx\_Xxxxxxxx** xxxxxxxx xx xxxxxxx xxxxxx xxxxxxxx xxx xxx **xx\_XxxxXxxxx** xxxxxxxx xx xxxxxxx xxxxxxxx xxxxx. Xx XXXX, xxx xxxx XxxxxxYX xxxxx xxxxxxxxxx xxxx xxx xxx xxxx xx xxx xxxxxx. Xxx xxxxxxx, xxxx XxxxxxYX xxx XXXX, xxx xxxxx xx xxx xxxxxx xxxxxx xxxx xxxxx xxx xxxx xxxxxx xx xxx xxxxxx xxxxxx, xxx xxx xxxxxxxxx xx x xxxxxxxx xxxxxx xx xxx xxx xxxx xxxx xxxxx xxx xxxxxxxxx xx x xxxxxxxx xxxxxx ([xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb509581)) xx xxxxxx xxxx.

## Xxxxxxx XXXX xxxxxxxxx xx XXXX


Xx XXXX, xxx xxxxx xxxxxxxxx (xxxxxxxxxx) xx x xxxxxx xxxxxx xxxxxxxx xxxxxxxxxxx xx xxxx xxxx xxxxxxxx x xxxxxxxx xxxxxxxx xx xxxx xxxxxxx. Xx XXXX, xxx xxx’x xxxx xxxxx xxxxxxxxx xxxxxxx xxx xxxxxx xxx xxxx xx xxx xxxxxx xxxx xxx xxxxxxxxx xxxx xxx xxxx xx xxxx xxxxxx xxx xxxx xxx xxxxxx xxxx xxxx xxxxxx.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XXXX xxxxxxxx xxxxxxxx</th>
<th align="left">XXXX xxxxxxxxxx</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><strong>xxxxxxx</strong></p>
<p>Xxx xxxx x xxxxxxx xxxxxxxx xxxx xxx xxx xxxx xxxx xxxxxx xx xxxx xxxxxx xxx xxxxxxxx xxxxxxx. Xxx xxxx xxx xxx xxxxxx xx xxx xxxxxxxx xxxxxx xxx xxxx xxx xxxxxxxxx xxxx xxxxx xxxxxxx xx xxxxx xxxxxx xxxx xxx xxxx xxxxxxxxxx xxx xxxxxxx xx x xxxxxxxx xxxx. Xxxxx xxxxxx xxx xxxxxxx. Xxxx xxxxxxxx xxx xxx xxx xxx xxxxxx xxxxx xxx xxxxxx xxxxxxxx xx xxx xxxxxxxxxx xxxxxx-xxxxx xxxxxx xxxx.</p>
<p>Xxxxxxx xxxxxxxxx xxx xxx-xxxxxxx xxxxxxxxx.</p></td>
<td align="left"><p>Xxx xxxxxxxx xxxxxx.</p>
<p>Xxx [How to: Create a Constant Buffer](https://msdn.microsoft.com/library/windows/desktop/ff476896) xxx [Shader Constants](https://msdn.microsoft.com/library/windows/desktop/bb509581).</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>xxxxxxx</strong></p>
<p>Xxx xxxxxxxxxx x xxxxxxx xxxxxxxx xxxxxx xxx xxxxxx xxxxxx xxx xxxx xx xxxxxxx xx xx xxxxxxxxxxx xxxxx xxxxxxx xxxxxxxx xx xxx xxxxxxxx xxxxxx. Xxxxxxx xxx xxxxxx xxxxxx xxxx xxxx xxx xxxxx xx xxx xxxxxxx xxxxxxxxx xx xxxx xxxxxx, xxx xxxxxxxxxx xxxxxxxxxxxx xxxxx xxxxxx (xx x xxxxxxxxxxx-xxxxxxx xxxxxx) xx xxxxxxxx xxx xxxxxxxx xxxxxx xx xxxx xxxx xxx xxxxxxxx xxxxxx. Xxxxx xxxxxxxxx xxxx xxxxxx xxxx xxxxxxxx.</p></td>
<td align="left">Xxx xxx xxxxxxxxx xxxx xxx xxxxxx xxxx xxxx xxxxxx xxxxxx xx xxx xxxxx xx xxxx xxxxx xxxxxx. Xxxx xxxx xxx xxxxxxxx xxxxxx xxxxx.</td>
</tr>
<tr class="odd">
<td align="left"><p><strong>xxxxxxxxx</strong></p>
<p>Xx xxxxxxxxx xx x xxxx xx xxx xxxxxxxxxxx xx x xxxxxx xxxx xxx xxxx xxxx xxx xxx xxxx xx xxx xxxxxx xxxxxx xxxxx. Xxxxxx x xxxxxxx, xxx xxx xxxx xxxxxxxxx’x xxxxx xxx xxxx xxxxxx, xxxxx, xx xxxx, xxxxxx xxxx xxxxxx xx xxxx x xxxxxxxxx xxxxx. Xxxxxxxxx xxxxxxxxx xxx xxx-xxxxxx xxxxxxxxx.</p></td>
<td align="left"><p>Xxxxxx x xxxxxx xxxxxx xx xxxx XxxxxxYX xxx xxxx xxx xxxxx xx xx xxx xxxxxx xxxxx xxxxxxx xx xxx xxxxxx xxxxxx. Xxxxxxxxxx, xxxxxx xx xxxxx xxxxxx. Xxx [How to: Create a Vertex Buffer](https://msdn.microsoft.com/library/windows/desktop/ff476899) xxx [How to: Create an Index Buffer](https://msdn.microsoft.com/library/windows/desktop/ff476897).</p>
<p>Xxxxxx xx xxxxx xxxxxx xx xxxx XxxxxxYX xxx xxxx xxx xxxxx xxxxxxxx xxxxxx xxxx xxxxx xx xxx xxxxxx xxxxx. Xxx [Create the input layout](https://msdn.microsoft.com/library/windows/desktop/bb205117#Create_the_Input_Layout).</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>xxxxx</strong></p>
<p>Xxxxxxxxx xxxx xxx xxxxxxxx xxxx xxx xxxxxx xxx xxxxx xxxxxx.</p></td>
<td align="left">Xxx x <strong>xxxxxx xxxxx</strong>. <strong>xxxxxx</strong> xxxxx xxx xxxxx xxx'x xxxxxxx xx xxxxxxxx xxxxxxx, <strong>xxxxx</strong> xxxxx xxx xxxxxx xxx'x xxxxxx xxx xxxxx. Xx, xxx xxxxx xx xxxxx xx xxxxxxx xxxx xxxxx xx xxx xxxxxxxxxxx.</td>
</tr>
</tbody>
</table>

 

Xx XXXX, xxxxxxxxx xxxxxxx xxxxxxxxx xxx xxxx xxxxxxxx xxxxxx xxxxxxxxx xxxx xxx xxxxxxx xx xxxx xxxxxx.

Xxxx xxx xxxx xxxx xx xxxxxxxx ([XxxxxxxYX](https://msdn.microsoft.com/library/windows/desktop/ff471525) xx XXXX) xxx xxxxx xxxxxxxxxx xxxxxxxx ([XxxxxxxXxxxx](https://msdn.microsoft.com/library/windows/desktop/bb509644) xx XXXX), xxx xxxxxxxxx xxxxxxx xxxx xx xxxxxx xxxxxxxxx xx xxx xxxxx xxxxxx.

## Xxxxxxx XXXX xxxxx xx XXXX


Xxx xxxx xxxxx xx xxxx xxxx XXXX xxxxx xx XXXX.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XXXX xxxx</th>
<th align="left">XXXX xxxx</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">xxxxxx xxxxx: xxxxx, xxx, xxxx</td>
<td align="left"><p>xxxxxx xxxxx: xxxxx, xxx, xxxx</p>
<p>xxxx, xxxx, xxxxxx</p>
<p>Xxx xxxx xxxx, xxx [Scalar Types](https://msdn.microsoft.com/library/windows/desktop/bb509646).</p></td>
</tr>
<tr class="even">
<td align="left"><p>xxxxxx xxxx</p>
<ul>
<li>xxxxxxxx-xxxxx xxxxxx: xxxY, xxxY, xxxY</li>
<li>Xxxxxxx xxxxxx: xxxxY, xxxxY, xxxxY</li>
<li>xxxxxx xxxxxxx xxxxxx: xxxxY, xxxxY, xxxxY</li>
</ul></td>
<td align="left"><p>xxxxxx xxxx</p>
<ul>
<li>xxxxxY, xxxxxY, xxxxxY, xxx xxxxxY</li>
<li>xxxxY, xxxxY, xxxxY, xxx xxxxY</li>
<li>xxxY, xxxY, xxxY, xxx xxxY</li>
<li><p>Xxxxx xxxxx xxxx xxxx xxxxxx xxxxxxxxxx xxxxxxx xx xxxxx, xxxx, xxx xxx:</p>
<ul>
<li>xxxx</li>
<li>xxxYYxxxxx, xxxYYxxxxx</li>
<li>xxxYYxxx, xxxYYxxx</li>
<li>xxxYYxxxx</li>
</ul></li>
</ul>
<p>Xxx xxxx xxxx, xxx [Vector Type](https://msdn.microsoft.com/library/windows/desktop/bb509707) xxx [Keywords](https://msdn.microsoft.com/library/windows/desktop/bb509568).</p>
<p>xxxxxx xx xxxx xxxx xxxxxxx xx xxxxxY (xxxxxxx xxxxxx &xx;xxxxx, Y&xx; xxxxxx;). Xxx xxxx xxxx, xxx [User-Defined Type](https://msdn.microsoft.com/library/windows/desktop/bb509702).</p></td>
</tr>
<tr class="odd">
<td align="left"><p>xxxxxx xxxx</p>
<ul>
<li>xxxY: YxY xxxxx xxxxxx</li>
<li>xxxY: YxY xxxxx xxxxxx</li>
<li>xxxY: YxY xxxxx xxxxxx</li>
</ul></td>
<td align="left"><p>xxxxxx xxxx</p>
<ul>
<li>xxxxxYxY</li>
<li>xxxxxYxY</li>
<li>xxxxxYxY</li>
<li>xxxx, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY, xxxxxYxY</li>
<li><p>Xxxxx xxxxx xxxx xxxx xxxxxx xxxxxxxxxx xxxxxxx xx xxxxx:</p>
<ul>
<li>xxx, xxxx, xxxx</li>
<li>xxxYYxxxxx, xxxYYxxxxx</li>
<li>xxxYYxxx, xxxYYxxx</li>
<li>xxxYYxxxx</li>
</ul></li>
</ul>
<p>Xxx xxx xxxx xxx xxx [matrix type](https://msdn.microsoft.com/library/windows/desktop/bb509623) xx xxxxxx x xxxxxx.</p>
<p>Xxx xxxxxxx: xxxxxx &xx;xxxxx, Y, Y&xx; xXxxxxx = {Y.Yx, Y.Y, Y.Yx, Y.Yx};</p>
<p>xxxxxx xx xxxx xxxx xxxxxxx xx xxxxxYxY (xxxxxxx xxxxxx &xx;xxxxx, Y, Y&xx; xxxxxx;). Xxx xxxx xxxx, xxx [User-Defined Type](https://msdn.microsoft.com/library/windows/desktop/bb509702).</p></td>
</tr>
<tr class="even">
<td align="left"><p>xxxxxxxxx xxxxxxxxxx xxx xxxxx, xxx, xxxxxxx</p>
<ul>
<li><p>xxxxx</p>
<p>Xxxx xxxxxxxxx xxxxxxxx xxxxxxx xxxxxxxxx xxxxxxxxxxxx xxxx xxx xxxxxxx xxxx xxxx xxxxxxxx xx xxxYYxxxxx xxx xxxx xxxx x xxxx YY-xxx xxxxx. Xxxxxxxxxx xx XXXX xx:</p>
<p>xxxxx xxxxx -&xx; xxxxx</p>
<p>xxxxx xxx -&xx; xxx</p></li>
<li><p>xxxxxxx</p>
<p>Xxxx xxxxxxxxx xxxxxxx xx xxxxx xxx xxx xx xxxxxxxxxx xx xxxYYxxxxx xxx xxxYYxxx xx XXXX. Xxxxxxx YY xxxx xx xxxxxxxx, xxx xxxx xxxYYxxxxx.</p></li>
<li><p>xxxx</p>
<p>Xxxx xxxxxxxxx xxxxxxx xx xxxxx xxxxxxxx x xxxxxxxx xxxxx xxxxx xx -Y xx Y. Xxxxxxxxxx xx xxxYYxxxxx xx XXXX.</p></li>
</ul></td>
<td align="left"><p>xxxxxxxxx xxxxx</p>
<ul>
<li>xxxYYxxxxx: xxxxxxx YY-xxx xxxxxxxx xxxxx xxxxx</li>
<li><p>xxxYYxxxxx</p>
<p>Xxxxxxx xxxxx-xxxxx xxxxxx Y.Y xxx xxxxx (Y xxxx xx xxxxx xxxxxx xxx Y xxxx xxxxxxxxxx xxxxxxxxx). Xxx Y-xxx xxxxxxxxxx xxxxxxxxx xxx xx xxxxxxxxx xx Y xxxxxxx xx xxxxxxxxx xx xxxx xx xxx xxxx xxxxxxxxx xxxxx xx -Y xx Y.</p></li>
<li>xxxYYxxx: xxxxxxx YY-xxx xxxxxx xxxxxxx</li>
<li><p>xxxYYxxx: xxxxxxx YY-xxx xxxxxx xxxxxxx</p>
<p>Xxxx xxxx xx xxx YYXxxxxY ([9_x feature levels](https://msdn.microsoft.com/library/windows/desktop/ff476876)) xx xxxxx xxxxxxxx xxx xxxxxxxxxxx xx xxxxxxxx xxxxx xxxxxxx. Xxxx xx xxx xxxxxxxxx xxx xxx xxx xxxx xxx xxxxxxx xx xxxxxxx xxxx x YY-xxx xxxxxxxx xxxxx xxxxxx.</p></li>
<li>xxxYYxxxx: xxxxxxx YY-xxx xxxxxxxx xxxxxxx</li>
</ul>
<p>Xxx xxxx xxxx, xxx [Scalar Types](https://msdn.microsoft.com/library/windows/desktop/bb509646) xxx [Using HLSL minimum precision](https://msdn.microsoft.com/library/windows/desktop/hh968108).</p></td>
</tr>
<tr class="odd">
<td align="left">xxxxxxxYX</td>
<td align="left">[Texture2D](https://msdn.microsoft.com/library/windows/desktop/ff471525)</td>
</tr>
<tr class="even">
<td align="left">xxxxxxxXxxx</td>
<td align="left">[TextureCube](https://msdn.microsoft.com/library/windows/desktop/bb509700)</td>
</tr>
</tbody>
</table>

 

## Xxxxxxx XXXX xxx-xxxxxxx xxxxxx xxxxxxxxx xx XXXX


Xxx xxxx xxxxx xx xxxx XXXX xxx-xxxxxxx xxxxxx xxxxxxxxx xx XXXX.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XXXX xxx-xxxxxxx xxxxxx xxxxxxxx</th>
<th align="left">XXXX xxxxxxxxx</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><strong>xx_Xxxxxxxx</strong></p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxY</strong>.</p>
<p>Xxxxxx xxxxxxxx</p>
<p>xxx xxxxxxx - xx_Xxxxxxxx = xxxxxxxx;</p></td>
<td align="left"><p>XX_Xxxxxxxx</p>
<p>XXXXXXXX xx XxxxxxYX Y</p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxxxY</strong>.</p>
<p>Xxxxxx xxxxxx xxxxxx</p>
<p>Xxxxxx xxxxxxxx</p>
<p>xxx xxxxxxx - xxxxxY xXxxxxxxx : XX_Xxxxxxxx;</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>xx_XxxxxXxxx</strong></p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxxx</strong>.</p>
<p>Xxxxx xxxx</p></td>
<td align="left"><p>XXXXX</p>
<p>Xx xxxxxxx xxxxxx xxx xxxxxx XxxxxxYX Y</p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxxx</strong>.</p>
<p>Xxxxxx xxxxxx xxxxxx</p>
<p>Xxxxx xxxx</p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong>xx_XxxxXxxxx</strong></p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxY</strong>.</p>
<p>Xxxxxxxx xxxxx</p>
<p>xxx xxxxxxx - xx_XxxxXxxxx = xxxY(xxxxxXxxxxxx, Y.Y);</p></td>
<td align="left"><p>XX_Xxxxxx</p>
<p>XXXXX xx XxxxxxYX Y</p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxxxY</strong>.</p>
<p>Xxxxx xxxxxx xxxxxx</p>
<p>Xxxxx xxxxx</p>
<p>xxx xxxxxxx - xxxxxY Xxxxx[Y] : XX_Xxxxxx;</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>xx_XxxxXxxx[x]</strong></p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxY</strong>.</p>
<p>Xxxxxxxx xxxxx xxx xxxxx xxxxxxxxxx x</p></td>
<td align="left"><p>XX_Xxxxxx[x]</p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxxxY</strong>.</p>
<p>Xxxxx xxxxxx xxxxxx xxxxx xxxx xx xxxxxx xx x xxxxxx xxxxxx, xxxxx Y &xx;= x &xx;= Y.</p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong>xx_XxxxXxxxx</strong></p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxY</strong>.</p>
<p>Xxxxxxxx xxxxxxxx xxxxxx xxxxx xxxxxx</p></td>
<td align="left"><p>XX_Xxxxxxxx</p>
<p>Xxx xxxxxxxxx xx XxxxxxYX Y</p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxxxY</strong>.</p>
<p>Xxxxx xxxxxx xxxxx</p>
<p>Xxxxxx xxxxx xxxxxxxxxxx</p>
<p>xxx xxxxxxx - xxxxxY xxxxxxXxxxx : XX_Xxxxxxxx</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>xx_XxxxxXxxxxx</strong></p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxx</strong>.</p>
<p>Xxxxxxxxxx xxxxxxx xxxxxxxx xxxxxxx xx x xxxxx-xxxxxx xxxxxxxxx.</p></td>
<td align="left"><p>XX_XxXxxxxXxxx</p>
<p>XXXXX xx XxxxxxYX Y</p>
<p>XX_XxXxxxxXxxx xx xxxx <strong>xxxx</strong>.</p>
<p>XXXXX xx xxxx <strong>xxxxx</strong>.</p>
<p>Xxxxx xxxxxx xxxxx</p>
<p>Xxxxxxxxx xxxxxx</p></td>
</tr>
<tr class="odd">
<td align="left"><p><strong>xx_XxxxxXxxxx</strong></p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxY</strong>.</p>
<p>Xxxxxxxx xxxxxxxx xxxxxx x xxxxx (xxxxx xxxxxxxxxxxxx xxxx)</p></td>
<td align="left"><p>XX_Xxxxxxxx</p>
<p>XXXX xx XxxxxxYX Y</p>
<p>XX_Xxxxxxxx xx xxxx <strong>xxxxxY</strong>.</p>
<p>XXXX xx xxxx <strong>xxxxxY</strong>.</p>
<p>Xxxxx xxxxxx xxxxx</p>
<p>Xxx xxxxx xx xxxxxx xxxxxxxx xx xxxxxx xxxxx</p>
<p>xxx xxxxxxx - xxxxxY xxx : XX_Xxxxxxxx</p></td>
</tr>
<tr class="even">
<td align="left"><p><strong>xx_XxxxXxxxx</strong></p>
<p>Xxxx xxxxxxxx xx xxxx <strong>xxxxx</strong>.</p>
<p>Xxxxx xxxxxx xxxx</p></td>
<td align="left"><p>XX_Xxxxx</p>
<p>XXXXX xx XxxxxxYX Y</p>
<p>XX_Xxxxx xx xxxx <strong>xxxxx</strong>.</p>
<p>Xxxxx xxxxxx xxxxxx</p>
<p>Xxxxx xxxxxx xxxx</p></td>
</tr>
</tbody>
</table>

 

Xxx xxx xxxxxxxxx xx xxxxxxx xxxxxxxx, xxxxx, xxx xx xx xxx xxxxxx xxxxxx xxxxx xxx xxxxx xxxxxx xxxxx. Xxx xxxx xxxxx xxx xxxxxxxxx xxxxxx xx xxx xxxxx xxxxxx xxxx xxx xxxxxx xxxxxx xxxxx. Xxx xxxxxxxx, xxx [Xxxxxxxx xx xxxxxxx XXXX xxxxxxxxx xx XXXX](#example1). Xxx xxxx xxxx xxxxx xxx XXXX xxxxxxxxx, xxx [Xxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb509647).

## Xxxxxxxx xx xxxxxxx XXXX xxxxxxxxx xx XXXX


Xxxx xx xxxx xxxxxxxx xx xxxxx XXXX xxxxxxxxx xx XxxxXX/XXXX xxxx xxx xxxx xxx xxxxxxxxxx xxxxxxx xx XxxxxxYX/XXXX xxxx.

### Xxxxxxx, xxxxxxxxx, xxx xxxxxxx xx XXXX

XxxxXX xxx xxxx

``` syntax
// Uniform values can be set in app code and then processed in the shader code.
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

// Incoming position of vertex
attribute vec4 position;
 
// Incoming color for the vertex
attribute vec3 color;
 
// The varying variable tells the shader pipeline to pass it  
// on to the fragment shader.
varying vec3 colorVarying;
```

XXXX xxxxxx xxxxxx xxxx

``` syntax
//The shader entry point is the main method.
void main()
{
colorVarying = color; //Use the varying variable to pass the color to the fragment shader
gl_Position = position; //Copy the position to the gl_Position pre-defined global variable
}
```

XXXX xxxxxxxx xxxxxx xxxx

``` syntax
void main()
{
//Pad the colorVarying vec3 with a 1.0 for alpha to create a vec4 color
//and assign that color to the gl_FragColor pre-defined global variable
//This color then becomes the fragment's color.
gl_FragColor = vec4(colorVarying, 1.0);
}
```

### Xxxxxxxx xxxxxxx xxx xxxx xxxxxxxxx xx XXXX

Xxxx xx xx xxxxxxx xx xxx xxx xxxx xxxx xx xxx XXXX xxxxxx xxxxxx xxxx xxxx xxxxx xxxxxxx xx xxx xxxxx xxxxxx. Xx xxxx xxx xxxx, xxxxxx x xxxxxx xxx x xxxxxxxx xxxxxx. Xxxx, xx xxxx xxxxxx xxxxxx xxxx, xxxxxx xxx xxxxxxxx xxxxxx xx x [xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb509581) xxx xxxxx xxx xxx-xxxxxx xxxx xxx xxx xxxxx xxxxxx xxxxx xxxx. Xxxx xx xxx xxxxxxxxxx xxxxxx **XxxxxxXxxxxxXxxxx** xxx **XxxxxXxxxxxXxxxx**.

XxxxxxYX xxx xxxx

```cpp
struct ConstantBuffer
{
    XMFLOAT4X4 model;
    XMFLOAT4X4 view;
    XMFLOAT4X4 projection;
};
struct SimpleCubeVertex
{
    XMFLOAT3 pos;   // position
    XMFLOAT3 color; // color
};

 // Create an input layout that matches the layout defined in the vertex shader code.
 const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
 {
     { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0,  0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
     { "COLOR",    0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
 };

// Create vertex and index buffers that define a geometry.
```

XXXX xxxxxx xxxxxx xxxx

``` syntax
cbuffer ModelViewProjectionCB : register( b0 )
{
    matrix model; 
    matrix view;
    matrix projection;
};
// The POSITION and COLOR semantics must match the semantics in the input layout Direct3D app code.
struct VertexShaderInput
{
    float3 pos : POSITION; // Incoming position of vertex 
    float3 color : COLOR; // Incoming color for the vertex
};

struct PixelShaderInput
{
    float4 pos : SV_Position; // Copy the vertex position.
    float4 color : COLOR; // Pass the color to the pixel shader.
};

PixelShaderInput main(VertexShaderInput input)
{
    PixelShaderInput vertexShaderOutput;

    // shader source code

    return vertexShaderOutput;
}
```

XXXX xxxxx xxxxxx xxxx

``` syntax
// Collect input from the vertex shader. 
// The COLOR semantic must match the semantic in the vertex shader code.
struct PixelShaderInput
{
    float4 pos : SV_Position;
    float4 color : COLOR; // Color for the pixel
};

// Set the pixel color value for the renter target. 
float4 main(PixelShaderInput input) : SV_Target
{
    return input.color;
}
```

## Xxxxxxxx xx xxxxxxx XxxxXX xxxxxxxxx xxxx xx XxxxxxYX


Xxxx xx xxxx xx xxxxxxx xx xxxxxxxxx xx XxxxXX XX Y.Y xxxx xxx xxxx xxx xxxxxxxxxx xxxxxxx xx XxxxxxYX YY xxxx.

XxxxXX xxxxxxxxx xxxx

``` syntax
// Bind shaders to the pipeline. 
// Both vertex shader and fragment shader are in a program.
glUseProgram(m_shader->getProgram());
 
// Input asssembly 
// Get the position and color attributes of the vertex.

m_positionLocation = glGetAttribLocation(m_shader->getProgram(), "position");
glEnableVertexAttribArray(m_positionLocation);

m_colorLocation = glGetAttribColor(m_shader->getProgram(), "color");
glEnableVertexAttribArray(m_colorLocation);
 
// Bind the vertex buffer object to the input assembler.
glBindBuffer(GL_ARRAY_BUFFER, m_geometryBuffer);
glVertexAttribPointer(m_positionLocation, 4, GL_FLOAT, GL_FALSE, 0, NULL);
glBindBuffer(GL_ARRAY_BUFFER, m_colorBuffer);
glVertexAttribPointer(m_colorLocation, 3, GL_FLOAT, GL_FALSE, 0, NULL);
 
// Draw a triangle with 3 vertices.
glDrawArray(GL_TRIANGLES, 0, 3);
```

XxxxxxYX xxxxxxxxx xxxx

```cpp
// Bind the vertex shader and pixel shader to the pipeline.
m_d3dDeviceContext->VSSetShader(vertexShader.Get(),nullptr,0);
m_d3dDeviceContext->PSSetShader(pixelShader.Get(),nullptr,0);
 
// Declare the inputs that the shaders expect.
m_d3dDeviceContext->IASetInputLayout(inputLayout.Get());
m_d3dDeviceContext->IASetVertexBuffers(0, 1, vertexBuffer.GetAddressOf(), &stride, &offset);

// Set the primitive’s topology.
m_d3dDeviceContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);

// Draw a triangle with 3 vertices. triangleVertices is an array of 3 vertices.
m_d3dDeviceContext->Draw(ARRAYSIZE(triangleVertices),0);
```

## Xxxxxxx xxxxxx


* [Xxxx xxxx XxxxXX XX Y.Y xx XxxxxxYX YY](port-from-opengl-es-2-0-to-directx-11-1.md)

 

 




<!--HONumber=Mar16_HO1-->
