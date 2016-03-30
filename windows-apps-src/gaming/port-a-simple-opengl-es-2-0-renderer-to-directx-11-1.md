---
xxxxx: Xxx xx-- xxxx x xxxxxx XxxxXX XX Y.Y xxxxxxxx xx XxxxxxYX YY
xxxxxxxxxxx: Xxx xxx xxxxx xxxxxxx xxxxxxxx, xx'xx xxxxx xxxx xxx xxxxxx-- xxxxxxxx x xxxxxx xxxxxxxx xxx x xxxxxxxx, xxxxxx-xxxxxx xxxx xxxx XxxxXX XX Y.Y xxxx XxxxxxYX, xxxx xxxx xx xxxxxxx xxx XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx) xxxxxxxx xxxx Xxxxxx Xxxxxx YYYY.
xx.xxxxxxx: xYxYxxYY-xxYY-YxYx-xYYY-YYYYYYxYYxYx
---

# Xxx xx: xxxx x xxxxxx XxxxXX XX Y.Y xxxxxxxx xx XxxxxxYX YY


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx xxx xxxxx xxxxxxx xxxxxxxx, xx'xx xxxxx xxxx xxx xxxxxx: xxxxxxxx x xxxxxx xxxxxxxx xxx x xxxxxxxx, xxxxxx-xxxxxx xxxx xxxx XxxxXX XX Y.Y xxxx XxxxxxYX, xxxx xxxx xx xxxxxxx xxx XxxxxxX YY Xxx (Xxxxxxxxx Xxxxxxx) xxxxxxxx xxxx Xxxxxx Xxxxxx YYYY. Xx xx xxxx xxxxxxx xxxx xxxx xxxxxxx, xxx xxxx xxxxx xxx xxxxxxxxx:

-   Xxx xx xxxx x xxxxxx xxx xx xxxxxx xxxxxxx xx XxxxxxYX xxxxx xxxxxxx
-   Xxx xx xxxx xxxxxxxx xxx xxxxxxxxxx xx xxxxxxxx xxxxxxx
-   Xxx xx xxxxxxxxx XxxxxxYX xxxxxx xxxxxxx
-   Xxx xxxxx XXXX xxxxxxxxx xxx xxxx xx XxxxxxYX xxxxxx xxxxxxxxxxx
-   Xxx xx xxxx xxxx xxxxxx XXXX xx XXXX

Xxxx xxxxx xxxxxx xxxxx xxx xxxx xxxxxxx x xxx XxxxxxX YY xxxxxxx. Xx xxxxx xxx xx xxxxxx x xxx XxxxxxX YY xxxxxxx, xxxx [Xxxxxx x xxx XxxxxxX YY xxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX)](user-interface.md).

Xxx xxxxxxx xxxxxxx xxxx xxxxxx xx xxxxx xxxxx xxx xxx xxx xxxx xxx xxx [XxxxxxYX](https://msdn.microsoft.com/library/windows/desktop/ff476345) xxxxxxxxxxxxxx xxxxxxxx, xxx xxx xxx xxxxxxxxxxx xxxxx xxxx xxx xxxxxxx xx xxxxxxx xxxx xxxxxxxx xxxx Xxxx XX XX Y.Y xx XxxxxxYX YY.

Xxxx xxxxx xxxxx xxx xxxx xxxxx xxxx xxxxxxx xxx xxxx xxxxx xxxxxxxx xxxx: xxxxxxx x xxxxxxxx xxxxxx-xxxxxx xxxx xx x xxxxxx. Xx xxxx xxxxx, xxx xxxx xxxxxx xxx xxxxxxxxx xxxxxxx:

1.  Xxxxxxxx x xxxx xxxx xxxx xxxxxxxxx xxxx. Xxxx xxxx xx xxxxxxxxxxx xx x xxxx xx xxxxxxxx, xxxx xxxx xxxxxx xxxxxxxxxx x xxxxxxxx, x xxxxxx xxxxxx, xxx x xxxxx xxxxxx. Xxxx xxxx xx xxx xxxx x xxxxxx xxxxxx xxx xxx xxxxxxx xxxxxxxx xx xxxxxxx.
2.  Xxxxxxxx xxxxxx xxxxxxx xx xxxxxxx xxx xxxx xxxx. Xxxxx xxx xxx xxxxxxx: x xxxxxx xxxxxx xxxx xxxxxxxxx xxx xxxxxxxx xxx xxxxxxxxxxxxx, xxx x xxxxxxxx (xxxxx) xxxxxx xxxx xxxxxx xxx xxxxxxxxxx xxxxxx xx xxx xxxx xxxxx xxxxxxxxxxxxx. Xxxxx xxxxxx xxx xxxxxxx xxxx x xxxxxx xxxxxx xxx xxxxxxx.
3.  Xxxxxxx xxx xxxxxxx xxxxxxxx xxxx xx xxxx xxx xxxxxx xxx xxxxx xxxxxxxxxx xx xxx xxxxxx xxx xxxxxxxx xxxxxxx, xxxxxxxxxxxx.
4.  Xxxxxxxxxx xxx xxxxxxxx xxxx xx xxx xxxxxx.

![xxxxxx xxxxxx xxxx](images/simple-opengl-cube.png)

Xxxx xxxxxxxxxx xxxx xxxxxxxxxxx, xxx xxxxxx xx xxxxxxxx xxxx xxx xxxxxxxxx xxxxx xxxxxxxxxxx xxxxxxx Xxxx XX XX Y.Y xxx XxxxxxYX YY:

-   Xxx xxxxxxxxxxxxxx xx xxxxxx xxxxxxx xxx xxxxxx xxxx.
-   Xxx xxxxxxx xx xxxxxxxx xxx xxxxxxxxxxx xxxxxxx.
-   Xxxxxxx xxxxxxxxx, xxx xxx xxxxxx xxx xxxxxxx xx xxxxxx xxxxxxx.
-   Xxxxxx xxxxxxx xxxxxxxxx.

Xx xxxx xxxxxxxxxxx, xx xxxxx xx xx xxxxxx xxx xxxxxxx XxxxXX xxxxxxxx xxxxxxxxx, xxxxx xx xxxxxxx xxxx xxxx:

``` syntax
typedef struct 
{
    GLfloat pos[3];        
    GLfloat rgba[4];
} Vertex;

typedef struct
{
  // Integer handle to the shader program object.
  GLuint programObject;

  // The vertex and index buffers
  GLuint vertexBuffer;
  GLuint indexBuffer;

  // Handle to the location of model-view-projection matrix uniform
  GLint  mvpLoc; 
   
  // Vertex and index data
  Vertex  *vertices;
  GLuint   *vertexIndices;
  int       numIndices;

  // Rotation angle used for animation
  GLfloat   angle;

  GLfloat  mvpMatrix[4][4]; // the model-view-projection matrix itself
} Renderer;
```

Xxxx xxxxxxxxx xxx xxx xxxxxxxx xxx xxxxxxxx xxx xxx xxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx x xxxx xxxxxx xxxxxx-xxxxxx xxxx.

> **Xxxx**  Xxx XxxxXX XX Y.Y xxxx xx xxxx xxxxx xx xxxxx xx xxx Xxxxxxx XXX xxxxxxxxxxxxxx xxxxxxxx xx xxx Xxxxxxx Xxxxx, xxx xxxx Xxxxxxx X xxxxxxxxxxx xxxxxx.

 

## Xxxx xxx xxxx xx xxxx


### Xxxxxxxxxxxx

-   [Xxxxxxxxx Xxxxxx X++](http://msdn.microsoft.com/library/vstudio/60k1461a.aspx)
-   XxxxXX XX Y.Y

### Xxxxxxxxxxxxx

-   Xxxxxxxx. Xxxxxx [Xxxx XXX xxxx xx XXXX xxx XxxxxxYX](moving-from-egl-to-dxgi.md). Xxxx xxxx xxxxx xx xxxxxx xxxxxxxxxx xxx xxxxxxxx xxxxxxxxx xxxxxxxx xx XxxxxxX.

## <span id="keylinks_steps_heading">
            </span>Xxxxx


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Xxxxx</th>
<th align="left">Xxxxxxxxxxx</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[Port the shader objects](port-the-shader-config.md)</p></td>
<td align="left"><p>Xxxx xxxxxxx xxx xxxxxx xxxxxxxx xxxx XxxxXX XX Y.Y, xxx xxxxx xxxx xx xx xxx xx xxx xxxxxxxxxx xxxxxx xxx xxxxxxxx xxxxxx xxxxxxx xx XxxxxxYX YY, xxx xx xxxx xxxx xxxx xxx xxxx xxxxxxx xxx xxxxxxxxxxx xxxx xxx xxxxxx xxxxxxx xxxxx xxxx xxx xxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Port the vertex buffers and data](port-the-vertex-buffers-and-data-config.md)</p></td>
<td align="left"><p>Xx xxxx xxxx, xxx'xx xxxxxx xxx xxxxxx xxxxxxx xxxx xxxx xxxxxxx xxxx xxxxxx xxx xxx xxxxx xxxxxxx xxxx xxxxx xxx xxxxxxx xx xxxxxxxx xxx xxxxxxxx xx x xxxxxxxxx xxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[Port the GLSL](port-the-glsl.md)</p></td>
<td align="left"><p>Xxxx xxx'xx xxxxx xxxx xxx xxxx xxxx xxxxxxx xxx xxxxxxxxxx xxxx xxxxxxx xxx xxxxxx xxxxxxx, xx'x xxxx xx xxxx xxx xxxx xxxxxx xxxxx xxxxxxx xxxx XxxxXX XX Y.Y'x XX Xxxxxx Xxxxxxxx (XXXX) xx XxxxxxYX YY'x Xxxx-xxxxx Xxxxxx Xxxxxxxx (XXXX).</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Draw to the screen](draw-to-the-screen.md)</p></td>
<td align="left"><p>Xxxxxxx, xx xxxx xxx xxxx xxxx xxxxx xxx xxxxxxxx xxxx xx xxx xxxxxx.</p></td>
</tr>
</tbody>
</table>

 

## <span id="additional_resources">
            </span>Xxxxxxxxxx xxxxxxxxx


-   [Xxxxxxx xxxx xxx xxxxxxxxxxx xxx XXX XxxxxxX xxxx xxxxxxxxxxx](prepare-your-dev-environment-for-windows-store-directx-game-development.md)
-   [Xxxxxx x xxx XxxxxxX YY xxxxxxx xxx XXX](user-interface.md)
-   [Xxx XxxxXX XX Y.Y xxxxxxxx xxx xxxxxxxxxxxxxx xx XxxxxxYX YY](map-concepts-and-infrastructure.md)

 

 




<!--HONumber=Mar16_HO1-->
