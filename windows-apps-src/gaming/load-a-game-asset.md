---
xxxxx: Xxxx xxxxxxxxx xx xxxx XxxxxxX xxxx
xxxxxxxxxxx: Xxxx xxxxx, xx xxxx xxxxx, xxxx xxxxxxxxx xxx xxxxxx (xxxx xx xxxxxxx, xxxxxxxx, xxxxxxxxxx xxxxxx xx xxxxx xxxxxxxx xxxx) xxxx xxxxx xxxxxxx xx xxxx xxxxx xxxx xxxxxx.
xx.xxxxxxx: xYYYYYxx-YYxY-xxYY-YxYY-YYYxxxYxYxYY
---

# Xxxx xxxxxxxxx xx xxxx XxxxxxX xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxx, xx xxxx xxxxx, xxxx xxxxxxxxx xxx xxxxxx (xxxx xx xxxxxxx, xxxxxxxx, xxxxxxxxxx xxxxxx xx xxxxx xxxxxxxx xxxx) xxxx xxxxx xxxxxxx xx xxxx xxxxx xxxx xxxxxx. Xxxx, xx xxxx xxx xxxxxxx x xxxx-xxxxx xxxx xx xxxx xxx xxxx xxxxxxxx xxxx xxxxxxx xxxxx xxxxx xx xxx xx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx.

Xxx xxxxxxx, xxx xxxxxx xxx xxxxxxxxx xxxxxxx xx xxxx xxxx xxxxx xxxx xxxx xxxxxxx xxxx xxxxxxx xxxx, xxx xxxxxxxx xx x xxxxxxxx xxxxxx. Xxx xxxx xx xxxx xxx xxxxxxxx, xxx xxxx xx: xxxxx x xxxx, xxxxxxxxxxxx xxxxxx xxx xx xxxxxxxx xxxxxxx xx xxxx xxxxx xxx xxxxxxxxxx xx xxxx xxxxxxxx XXXx, xx xxx xx xxxxxxxxx xxxxxxxxxxx xxx xxx xx xxxx xxxx. Xxxx, xx xxxxx xxx xxxxxxx xxx xxxxx xxxxx xxx xxxxxxx xxxxx xxxxxxxxx xxxxx xx xxxxxxx xxxxxxxxx xxx xxx xxxx XxxxxxYX: xxxxxx (xxxxxx), xxxxxxxx (xxxxxxx), xxx xxxxxxxx xxxxxx xxxxxxx.

## Xxxx xxx xxxx xx xxxx


### Xxxxxxxxxxxx

-   Xxxxxxxx Xxxxxxxx Xxxxxxx (xxxxxxxx.x)

### Xxxxxxxxxxxxx

-   Xxxxxxxxxx xxx xxxxx Xxxxxxx Xxxxxxx
-   Xxxxxxxxxx xxxxxxxxxxxx xxxxx
-   Xxxxxxxxxx xxx xxxxx xxxxxxxx xx Y-X xxxxxxxx xxxxxxxxxxx.

Xxxx xxxxxx xxxx xxxxxxxx xxxxx xxxx xxxxx xxx xxxxxxxx xxxxxxx xxx xxxxxxxxxx. Xxx'xx xxxxxxxxx xxx xxxx xxxxxxx xxxxxxx xx xxxxx xxxxx xxxxxxxxxx xxxx xxxxx.

-   XxxxxXxxxxx.x/.xxx
-   XxxxxXxxxxxXxxxxx.x/.xxx
-   XXXXxxxxxxXxxxxx.x/.xxx

Xxx xxxxxxxx xxxx xxx xxxxx xxxxxxx xxx xx xxxxx xx xxx xxxxxxxxx xxxxx.

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
<td align="left"><p>[Complete code for BasicLoader](complete-code-for-basicloader.md)</p></td>
<td align="left"><p>Xxxxxxxx xxxx xxx x xxxxx xxx xxxxxxx xxxx xxxxxxx xxx xxxx xxxxxxxx xxxx xxxxxxx xxxx xxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Complete code for BasicReaderWriter](complete-code-for-basicreaderwriter.md)</p></td>
<td align="left"><p>Xxxxxxxx xxxx xxx x xxxxx xxx xxxxxxx xxx xxxxxxx xxx xxxxxxx xxxxxx xxxx xxxxx xx xxxxxxx. Xxxx xx xxx [BasicLoader](complete-code-for-basicloader.md) xxxxx.</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[Complete code for DDSTextureLoader](complete-code-for-ddstextureloader.md)</p></td>
<td align="left"><p>Xxxxxxxx xxxx xxx x xxxxx xxx xxxxxx xxxx xxxxx x XXX xxxxxxx xxxx xxxxxx.</p></td>
</tr>
</tbody>
</table>

 

## Xxxxxxxxxxxx

### Xxxxxxxxxxxx xxxxxxx

Xxxxxxxxxxxx xxxxxxx xx xxxxxxx xxxxx xxx **xxxx** xxxxxxxx xxxx xxx Xxxxxxxx Xxxxxxxx Xxxxxxx (XXX). X **xxxx** xxxxxxxx x xxxxxx xxxx xxxxxxxx xx x xxxxxx xxxx xxxxxxxxx xxx xxxxxxx xx xxx xxxxx xxxx xxxxx xx xxxxxxxxx, xxx xxxxxxx xxxxxxx xxx xxxxxx xx:

`task<generic return type>(async code to execute).then((parameters for lambda){ lambda code contents });`.

Xxxxx xxx xx xxxxxxx xxxxxxxx xxxxx xxx **.xxxx()** xxxxxx, xx xxxx xxxx xxx xxxxxxxxx xxxxxxxxx, xxxxxxx xxxxx xxxxxxxxx xxxx xxxxxxx xx xxx xxxxxxx xx xxx xxxxx xxxxxxxxx xxx xx xxx. Xx xxxx xxx, xxx xxx xxxx, xxxxxxx, xxx xxxxxx xxxxxxx xxxxxx xx xxxxxxxx xxxxxxx xx x xxx xxxx xxxxxxx xxxxxx xxxxxxxxx xx xxx xxxxxx.

Xxx xxxx xxxxxxx, xxxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

Xxx, xxx'x xxxx xx xxx xxxxx xxxxxxxxx xxx xxxxxxxxx xxx xxxxxxxx xx xxxxx xxxx xxxxxxx xxxxxx, **XxxxXxxxXxxxx**.

```cpp
#include <ppltasks.h>

// ...
concurrency::task<Platform::Array<byte>^> ReadDataAsync(
        _In_ Platform::String^ filename);

// ...

using concurrency;

task<Platform::Array<byte>^> BasicReaderWriter::ReadDataAsync(
    _In_ Platform::String^ filename
    )
{
    return task<StorageFile^>(m_location->GetFileAsync(filename)).then([=](StorageFile^ file)
    {
        return FileIO::ReadBufferAsync(file);
    }).then([=](IBuffer^ buffer)
    {
        auto fileData = ref new Platform::Array<byte>(buffer->Length);
        DataReader::FromBuffer(buffer)->ReadBytes(fileData);
        return fileData;
    });
}
```

Xx xxxx xxxx, xxxx xxxx xxxx xxxxx xxx **XxxxXxxxXxxxx** xxxxxx xxxxxxx xxxxx, x xxxx xx xxxxxxx xx xxxx x xxxxxx xxxx xxx xxxx xxxxxx. Xxxx xx xxxxxxxxx, x xxxxxxx xxxx xxxxx xxx xxxxxx xxx xxxxxxx xxx xxxxx xxxx xxxx xxxxxx xxxx xx xxxxx xxxxx xxx xxxxxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208119) xxxx.

```cpp
m_basicReaderWriter = ref new BasicReaderWriter();

// ...
return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ bytecode)
    {
      // Perform some operation with the data when the async load completes.          
    });
```

Xxxx'x xxx xxxx xxx xxxx xx **XxxxXxxxXxxxx**. Xxxx xx xxxxxxxxx, xxxx xxxx xxxxxxxx xx xxxxx xx xxxxx xxxx xxxx xxx xxxxxxxx xxxx. Xxxxx **XxxxXxxxXxxxx** xxxxxx xx xxxxxxx xx x xxxx, xxx xxx xxx x xxxxxx xx xxxxxxx x xxxxxxxx xxxxxxxxx xxxx xxx xxxx xxxxx xx xxxxxxxx, xxxx xx xxxxxxx xxxx xxxx xxxx xx x XxxxxxX xxxxxxxx xxxx xxx xxx xx.

Xx xxxx xxxx xx xxxxxxxxxxxx xxxxxx, xxxx xxxx xxxxxxxxx xxxx x xxxxxx xxxx xxxx xxxx xxx xxxx xxxxxx xxx xxxx. Xxx xxx xx xxxx xxxxxx xxx xxxxx xxx xxxx xxxx xxxx xxxx xxxx xxxxx xx xxx xxxx xxxxxxxx xx xxxx [**XXxxxxxxxxXxxx::Xxx**](https://msdn.microsoft.com/library/windows/apps/hh700505) xxxxxxxxxxxxxx. Xxxxx, xxx xxxx xxxx xxxxxxxx xxxxxxx xxxxxxx xxxxxxxxxxxxxx xx xxx xxxx xxx xxxxx xxxxxxx xxx xx xxx xxxxxx xxxxx'x xxxx xx xxxx xxxxx xxx xxxxxxx xxxxxxxxx xxxxxx xxxxxxxx xx xxxxx xxxxxxxxxxxx.

Xxxxxxx, xxx xxx'x xxxx xx xxxxx xxx xxxx xxxxxx xxxxx xxx xx xxx xxxxx xxxxxxx xxx xxxxxxxxx! Xxxxxx xxxx xxxxxx xxx xxxxxxxxx xxxx xxxxxxx xx xxxxxxxx, xxxx xx x xxxxxxxx xxxxx, xxx xxx xxx xxxxxxx xx xxxx xxxxxxx xxxxxx(x) xx xxx xxxx xxxxxx xxxx xxxxxxxx. Xxxxx xxx xxxxxxxx xxxxxx xxxxxxxx xxx xxxxxxxxxx xxxx xxx xxxxx xxxxxx xxxxxxxxx.

Xxxx'x xx xxxxxxx xxxxx xxx xxxxx xxxxxxx xxxxxxx xx XxxxxXxxxxx.xxx xx xxxx xxxxxxx, x xxxx, xxx x xxxxxxx xxxx xxx xxxx xxxxxx xx. Xxxxxx xxxx xx xxxx x xxxxxxxx xxxxx xx xxx xxxx xxxxxx, **x\_xxxxxxxXxxxxxxx**, xxxx xxx xx xxx xxxxxxx xxxxxxx xxxxxx.

```cpp
void ResourceLoading::CreateDeviceResources()
{
    // DirectXBase is a common sample class that implements a basic view provider. 
    
    DirectXBase::CreateDeviceResources(); 

    // ...

    // This flag will keep track of whether or not all application
    // resources have been loaded.  Until all resources are loaded,
    // only the sample overlay will be drawn on the screen.
    m_loadingComplete = false;

    // Create a BasicLoader, and use it to asynchronously load all
    // application resources.  When an output value becomes non-null,
    // this indicates that the asynchronous operation has completed.
    BasicLoader^ loader = ref new BasicLoader(m_d3dDevice.Get());

    auto loadVertexShaderTask = loader->LoadShaderAsync(
        "SimpleVertexShader.cso",
        nullptr,
        0,
        &m_vertexShader,
        &m_inputLayout
        );

    auto loadPixelShaderTask = loader->LoadShaderAsync(
        "SimplePixelShader.cso",
        &m_pixelShader
        );

    auto loadTextureTask = loader->LoadTextureAsync(
        "reftexture.dds",
        nullptr,
        &m_textureSRV
        );

    auto loadMeshTask = loader->LoadMeshAsync(
        "refmesh.vbo",
        &m_vertexBuffer,
        &m_indexBuffer,
        nullptr,
        &m_indexCount
        );

    // The && operator can be used to create a single task that represents
    // a group of multiple tasks. The new task's completed handler will only
    // be called once all associated tasks have completed. In this case, the
    // new task represents a task to load various assets from the package.
    (loadVertexShaderTask && loadPixelShaderTask && loadTextureTask && loadMeshTask).then([=]()
    {
        m_loadingComplete = true;
    });

    // Create constant buffers and other graphics device-specific resources here.
}
```

Xxxx xxxx xxx xxxxx xxxx xxxx xxxxxxxxxx xxxxx xxx && xxxxxxxx xxxx xxxx xxx xxxxxx xxxx xxxx xxx xxxxxxx xxxxxxxx xxxx xx xxxxxxxxx xxxx xxxx xxx xx xxx xxxxx xxxxxxxx. Xxxx xxxx xx xxx xxxx xxxxxxxx xxxxx, xxx xxxx xxx xxxxxxxxxxx xx xxxx xxxxxxxxxx. Xxx xxxxxxx, xx xxx xxxxxx xxxx xxx xxxxx xxxxxxxxxxxx xx xxx xxxx xxxxx, xxxxxxx xxxxxx xxx xxxx xxx xxx xxxxx xxxx xxx xx xx xxxxxxxx xxxx xxxxxx xxx xxxxxx xxxx xx xxx.

Xxx'xx xxxx xxx xx xxxx xxxxxxxx xxxxx xxxxxxxxxxxxxx. Xxxxxxxxxxx xxxx xxxxx xxx xxxx xxxxxxx, xxx xxx xxx xxxx xxxxxxxx xx xxxx xx [Xxxxxxxx xxxx xxx XxxxxXxxxxxXxxxxx](complete-code-for-basicreaderwriter.md) xxx [Xxxxxxxx xxxx xxx XxxxxXxxxxx](complete-code-for-basicloader.md).

Xx xxxxxx, xxxxxxxxx xxxxxxxx xxx xxxxx xxxxx xxxxx xxxxxxx xxxxxxxxxx xxxxxxxxxx xx xxxxxxxxxx xxxxxx xxxx xxx xxxxx xx xx xxxx xx xxxx xxxxxxxx xxxxxxxx. Xxx'x xxxx x xxxx xx xxxxx xxxxxxxx xxxxx xx xxxxxxxxx: xxxxxx, xxxxxxxx, xxx xxxxxxx.

### Xxxxxxx xxxxxx

Xxxxxx xxx xxxxxx xxxx, xxxxxx xxxxxxxxx xxxxxxxxxxxx xx xxxx xxxxxx xxxx xxxx xx xxxxxxxx xx x xxxx xxxx xxxxxxx xxx (xxxx YXXxxxxx XXX xx Xxxxx XxxxXxxxx) xx xxxx. Xxxxx xxxxxx xxxxxxxxx xxx xxxxxx xx xxxx xxxx, xxxx xxxxxx xxxxxxxxxx xxxx xxxxx xxx xxxxxxx xx xxxx xxx xxxxxx xxx xxxxxxxxxx. Xxxx xxxxx xxxxxxx xxxxx xxx xxxxxxxxx xxxx, xx xxxx, xxxxxxxxx xx xxxxx xxxxxx. Xx'xx xxxxx xx xxxxxx xxxx xxxxxxx xxxx xxxxxx xxxx.

Xx xxxx x xxxx xxxxxxxxx, xxx xxxx xxxx xxx xxxxxx xx xxx xxxx xx xxx xxxx xxx xxx xxxx. Xxx xxxxxx **XxxxxXxxxxxXxxxxx** xxxx xxxxx xxxxxx xxxxx xxx xxxx xx xx x xxxx xxxxxx; xx xxxxx'x xxxx xxxx xxx xxxx xxxx xxxxxxxxxx x xxxx, xxxx xxxx x xxxxxxxx xxxx xxxxxx xx xxxxxxxx xx xxxxxxx xxxxxxxxxxx! Xxx xxxx xxxxxxx xxx xxxxxxxxxx xx xxx xxxxx xxx xxxx xxxx xxxx xxxxxx.

(Xxx xxxxxx xxxxxx xxx xx xxxxxxx xxxxx xxxx xx x xxxxxx xxxx'x xx xxxxx xx xxx xxxxxxxx xxxxxxxxxxxxxx xx xxxxxxxx. Xxxxx xx xxxx xxxxxx xxxxxxxx xxxxxxxxxxx xxx xxxx xxxx.)

Xxx'x xxx xxx xxxx xxxx xxxx xxx xxxx'x xxxx. Xxx xxxxxx xx xxx xxxxxxx xxxxxxx xxxx xxx xxxx xx x xxxxxx-xxxxxxxx xxxxxx xxxxxxxx xxxx .xxx. (Xxxxx, xxxx xxxxxx xx xxx xxx xxxx xx XxxxXX'x XXX xxxxxx.) Xxxx xxxxxx xxxxxx xxxx xx xxx **XxxxxXxxxxx** xxxx, xxxxx xx x xxxxxx xxxxxxx xx xxx xxxx xxx xxx xxxYxxx xxxxxxxxx xxxx. Xxx xxxxxx xx xxx xxxxxx xxxx xx xxx .xxx xxxx xxxxx xxxx xxxx:

-   Xxx xxxxx YY xxxx (Y xxxxx) xx xxx xxxx xxxxxx xxxxxxx xxx xxxxxx xx xxxxxxxx (xxxXxxxxxxx) xx xxx xxxx, xxxxxxxxxxx xx x xxxxYY xxxxx.
-   Xxx xxxx YY xxxx (Y xxxxx) xx xxx xxxx xxxxxx xxxxxxx xxx xxxxxx xx xxxxxxx xx xxx xxxx (xxxXxxxxxx), xxxxxxxxxxx xx x xxxxYY xxxxx.
-   Xxxxx xxxx, xxx xxxxxxxxxx (xxxXxxxxxxx \* xxxxxx(**XxxxxXxxxxx**)) xxxx xxxxxxx xxx xxxxxx xxxx.
-   Xxx xxxx (xxxXxxxxxx \* YY) xxxx xx xxxx xxxxxxx xxx xxxxx xxxx, xxxxxxxxxxx xx x xxxxxxxx xx xxxxYY xxxxxx.

Xxx xxxxx xx xxxx: xxxx xxx xxx-xxxxx xxxxxx xx xxx xxxx xxxx xxx xxxx xxxxxx. Xxxx, xx xxxx xxx xxx xxxxxxxxxx xxxx xxxxxx-xxxx. Xxx Xxxxxxx Y xxxxxxxxx xxx xxxxxx-xxxxxx.

Xx xxx xxxxxxx, xxx xxxx x xxxxxx, XxxxxxXxxx, xxxx xxx **XxxxXxxxXxxxx** xxxxxx xx xxxxxxx xxxx xxx-xxxxx xxxxxxxxxxxxxx.

```cpp
task<void> BasicLoader::LoadMeshAsync(
    _In_ Platform::String^ filename,
    _Out_ ID3D11Buffer** vertexBuffer,
    _Out_ ID3D11Buffer** indexBuffer,
    _Out_opt_ uint32* vertexCount,
    _Out_opt_ uint32* indexCount
    )
{
    return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ meshData)
    {
        CreateMesh(
            meshData->Data,
            vertexBuffer,
            indexBuffer,
            vertexCount,
            indexCount,
            filename
            );
    });
}
```

**XxxxxxXxxx** xxxxxxxxxx xxx xxxx xxxx xxxxxx xxxx xxx xxxx, xxx xxxxxxx x xxxxxx xxxxxx xxx xx xxxxx xxxxxx xxx xxx xxxx xx xxxxxxx xxx xxxxxx xxx xxxxx xxxxx, xxxxxxxxxxxx, xx [**XXYXYYXxxxxx::XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476501) xxx xxxxxxxxxx xxxxxx XYXYY\_XXXX\_XXXXXX\_XXXXXX xx XYXYY\_XXXX\_XXXXX\_XXXXXX. Xxxx'x xxx xxxx xxxx xx **XxxxxXxxxxx**:

```cpp
void BasicLoader::CreateMesh(
    _In_ byte* meshData,
    _Out_ ID3D11Buffer** vertexBuffer,
    _Out_ ID3D11Buffer** indexBuffer,
    _Out_opt_ uint32* vertexCount,
    _Out_opt_ uint32* indexCount,
    _In_opt_ Platform::String^ debugName
    )
{
    // The first 4 bytes of the BasicMesh format define the number of vertices in the mesh.
    uint32 numVertices = *reinterpret_cast<uint32*>(meshData);

    // The following 4 bytes define the number of indices in the mesh.
    uint32 numIndices = *reinterpret_cast<uint32*>(meshData + sizeof(uint32));

    // The next segment of the BasicMesh format contains the vertices of the mesh.
    BasicVertex* vertices = reinterpret_cast<BasicVertex*>(meshData + sizeof(uint32) * 2);

    // The last segment of the BasicMesh format contains the indices of the mesh.
    uint16* indices = reinterpret_cast<uint16*>(meshData + sizeof(uint32) * 2 + sizeof(BasicVertex) * numVertices);

    // Create the vertex and index buffers with the mesh data.

    D3D11_SUBRESOURCE_DATA vertexBufferData = {0};
    vertexBufferData.pSysMem = vertices;
    vertexBufferData.SysMemPitch = 0;
    vertexBufferData.SysMemSlicePitch = 0;
    CD3D11_BUFFER_DESC vertexBufferDesc(numVertices * sizeof(BasicVertex), D3D11_BIND_VERTEX_BUFFER);

    m_d3dDevice->CreateBuffer(
            &vertexBufferDesc,
            &vertexBufferData,
            vertexBuffer
            );
    
    D3D11_SUBRESOURCE_DATA indexBufferData = {0};
    indexBufferData.pSysMem = indices;
    indexBufferData.SysMemPitch = 0;
    indexBufferData.SysMemSlicePitch = 0;
    CD3D11_BUFFER_DESC indexBufferDesc(numIndices * sizeof(uint16), D3D11_BIND_INDEX_BUFFER);
    
    m_d3dDevice->CreateBuffer(
            &indexBufferDesc,
            &indexBufferData,
            indexBuffer
            );
  
    if (vertexCount != nullptr)
    {
        *vertexCount = numVertices;
    }
    if (indexCount != nullptr)
    {
        *indexCount = numIndices;
    }
}
```

Xxx xxxxxxxxx xxxxxx x xxxxxx/xxxxx xxxxxx xxxx xxx xxxxx xxxx xxx xxx xx xxxx xxxx. Xxxxx xxx xxxx xxx xxxx xxx xxxxxx xx xx xx xxx. Xx xxx xxxx x xxx xx xxxxxx, xxx xxx xxxx xxxx xx xxxx xxxx xxxx xxx xxxx xx xxxxxxxx xxxxxx xx xxx xxxx, xxxx xx xxxxxx xxxxxxxx, xxx-xxxxxxx xxxxxxx xxxxxx. Xxx xxxxx xxxxxx, xxxx xxxxxxx xxxx, xxx xxx xxxxxx xxx xxxxxxxx xxxx x xxxxx, xxx xxxx xx x xxxx xxxxxxx xxxxxxxxx xxx xxx xx xxx xxxxx xx xxxx xxxxx.

Xxxxx, xxxx xxxx xxxxxx xxxx xxxxxx! Xxxxx xxx xxxx, xxxx xxxx xx xxxxxxxxx xxxxxx xxxx xxxxxx xxx xxxxx xxxx xx xxxxxx xxxxxx. Xxxxx xxx xxxx xxxx xxxxxxxxx xxxx xx xxxxxxxxx xxx xxxxx xxxxxx xx xxx xxxxxx xxxx xx XxxxxxYX, xxxx xx xxxxxxxx xxxxx xxx xxxxxx. Xxx xxxx xxxxxxxxxxx xxxxx xxxxxx xxxx, xxxx [Xxxxxxxxxxxx xx Xxxxxxx xx XxxxxxYX YY](https://msdn.microsoft.com/library/windows/desktop/ff476898) xxx [Xxxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb147291).

Xxxx, xxx'x xxxx xx xxxxxxx xxxxxxxx.

### Xxxxxxx xxxxxxxx

Xxx xxxx xxxxxx xxxxx xx x xxxx—xxx xxx xxx xxxx xxxxxxxxx xxxx xx xxx xxxxx xx xxxx xxx xx xxxxxx—xxx xxxxxxxx. Xxxx xxxxxx, xxxxxxxx xxx xxxx xx x xxxxxxx xx xxxxxxx, xxx xxx xxxxxxx xxxx xx x xxxxxx xxxx XxxxxxYX xxx xxx xxxx xxx xxxx xxxx. Xxxxxxxx xxxx xxxx xx x xxxx xxxxxxx xx xxxxx xxx xxx xxxx xx xxxxxx xxxxxxxxx xxxxxxx. XXX xxxxxx xxx xxxxxxxx xxx xx xxxx xx xxxxxxx xxx xxxx xxx xxxxxxxxxxx xx xxxxxxxx xxxxxxx; xxxx xxx xxxxx xxxx xxx xxxx xx xxxxx xxxxxxx xxx xxxxxx xxxx x xxxx xxxxxxx; xxx xxxxxx xxxx xxx xxxx xx xxx-xxxxx xxxxxxxx xxxxxxxxxxxx. Xx x xxxxxx xxxx, x xxxxxxx xxxxx xxx xxxxxxxxxxx xxxx xxxxxxxxx xx xxxxxxxxxx xxxxxxxx, xxx xxxx xxxx xxxx xxxxxxxxxxx xxxxxx xxxx xxx!

Xxxx xxxx xxxxxx, xxxxx xxx x xxxxxx xx xxxxxxxx xxxxxxx xxxx xxx xxxx xx xxxx xxxxxx xxxxx xxx xxxxxxxxx. Xxxxx xxxxxxxx xxx xxxxxx xxxxxxx x xxxxx xxxxxxx xx xxx XXX (xxx xxxxxx) xxxxxx, xxxx xxx xxxxx xxxxxxxxxx xx xxxx xxxxxxx. Xxx xxxx'x xxxxxxxx xx xxx xxxxxxxxxxx xx xxxx xxxx'x xxxxxxxx, xxx xxx xxx xxx xxx xxxxxxxxxxx/xxxxxxxxxxxxx xxxxxxxxx(x) xxx xxxx xx xxxx xx xxx xxxxxxx xxx XxxxxxYX xxxxxxx xxxx xxxx xx x xxxxxx xx xxx xxxxxxxxxx (xxxx x [**XxxxxxxYX**](https://msdn.microsoft.com/library/windows/desktop/ff476635) xxxxxx).

XxxxxxYX xxxxxxxx xxxxxxx xxx xxx XXX xxxxxxx xxxxxxxxxxx xxxxxxxxxx, xxxxxxxx xxxxx XXX xxxxxx xxx xxx xx xxxxxxxxx xx xxx xxxxxx'x xxxxxxxx xxxxxxxx. XXX xxxxx xxxxxxx XXX xxxxxxxx (xxx xxxxx xxxxxxx xxxxxxxxxxx xxxxxxx xx xxxx), xxx xxx xxxxxxxx xxxx .xxx.

X XXX xxxx xx x xxxxxx xxxx xxxx xxxxxxxx xxx xxxxxxxxx xxxxxxxxxxx:

-   X XXXXX (xxxxx xxxxxx) xxxxxxxxxx xxx xxxx xxxxxxxxx xxxx xxxxx 'XXX ' (YxYYYYYYYY).

-   X xxxxxxxxxxx xx xxx xxxx xx xxx xxxx.

    Xxx xxxx xx xxxxxxxxx xxxx x xxxxxx xxxxxxxxxxx xxxxx [**XXX\_XXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb943982); xxx xxxxx xxxxxx xx xxxxxxx xxxxx [**XXX\_XXXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb943984). Xxxx xxxx xxx **XXX\_XXXXXX** xxx **XXX\_XXXXXXXXXXX** xxxxxxxxxx xxxxxxx xxx xxxxxxxxxx XXXXXXXXXXXXXY, XXXXXXXY xxx XXXXXXXXXXXXX XxxxxxXxxx Y xxxxxxxxxx. **XXX\_XXXXXX** xx xxx xxxxxx xxxxxxxxxx xx XXXXXXXXXXXXXY xxx XXXXXXXY. **XXX\_XXXXXXXXXXX** xx xxx xxxxxx xxxxxxxxxx xx XXXXXXXXXXXXX.

    ```cpp
    DWORD               dwMagic;
    DDS_HEADER          header;
    ```

    Xx xxx xxxxx xx **xxXxxxx** xx [**XXX\_XXXXXXXXXXX**](https://msdn.microsoft.com/library/windows/desktop/bb943984) xx xxx xx XXXX\_XXXXXX xxx **xxXxxxXX** xx xxx xx "XXYY" xx xxxxxxxxxx [**XXX\_XXXXXX\_XXXYY**](https://msdn.microsoft.com/library/windows/desktop/bb943983) xxxxxxxxx xxxx xx xxxxxxx xx xxxxxxxxxxx xxxxxxx xxxxxx xx XXXX xxxxxxx xxxx xxxxxx xx xxxxxxxxx xx xx XXX xxxxx xxxxxx xxxx xx xxxxxxxx xxxxx xxxxxxx, xXXX xxxxxxx xxx. Xxxx xxx **XXX\_XXXXXX\_XXXYY** xxxxxxxxx xx xxxxxxx, xxx xxxxxx xxxx xxxxxxxxxxx xxxx xxxxx xxxx xxxx.

    ```cpp
    DWORD               dwMagic;
    DDS_HEADER          header;
    DDS_HEADER_DXT10    header10;
    ```

-   X xxxxxxx xx xx xxxxx xx xxxxx xxxx xxxxxxxx xxx xxxx xxxxxxx xxxx.
    ```cpp
    BYTE bdata[]
    ```

-   X xxxxxxx xx xx xxxxx xx xxxxx xxxx xxxxxxxx xxx xxxxxxxxx xxxxxxxx xxxx xx; xxxxxx xxxxxx, xxxxx xx x xxxx xxx, xxxxxx xx x xxxxxx xxxxxxx. Xxxxxx xxxxx xxxxx xxx xxxx xxxxxxxxxxx xxxxx xxx XXX xxxx xxxxxx xxx x: [xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb205578), x [xxxx xxx](https://msdn.microsoft.com/library/windows/desktop/bb205577), xx x [xxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb205579).

    ```cpp
    BYTE bdata2[]
    ```

Xxxx xxxxx xxxxxx xx xxx XXX xxxxxx. Xx xxx xxx'x xxxx x xxxx xx xxxxxx xxxx xxxxxxx xx xxxx xxxxxx, xxxxxxxx xxxxxxxx xxx. Xxx xxxx xxxxxx xx xxx XXX xxxxxx xxx xxx xx xxxx xxxx xx xx xxxx xxxx, xxxx [Xxxxxxxxxxx Xxxxx xxx XXX](https://msdn.microsoft.com/library/windows/desktop/bb943991). Xx xxx xxxxxxx, xx'xx xxx XXX.

Xx xxxx xxxxx xxxxxxxx xxxxx, xxx xxxx xxx xxxx xxxx x xxxx xx x xxxxxx xx xxxxx. Xxxx xxxx xxxxxxx xxxx xxxxxxxxx, xxx xxxxxx xxxx xxxx xxxx (xxx **XxxxxxXxxxxxx** xxxxxx) xx xxxxxxx xxx xxxxxx xx xxxxx xxxx x xxxxxx xxxx XxxxxxYX xxx xxx.

```cpp
task<void> BasicLoader::LoadTextureAsync(
    _In_ Platform::String^ filename,
    _Out_opt_ ID3D11Texture2D** texture,
    _Out_opt_ ID3D11ShaderResourceView** textureView
    )
{
    return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ textureData)
    {
        CreateTexture(
            GetExtension(filename) == "dds",
            textureData->Data,
            textureData->Length,
            texture,
            textureView,
            filename
            );
    });
}
```

Xx xxx xxxxxxxx xxxxxxx, xxx xxxxxx xxxxxx xx xxx xx xxx xxxxxxxx xxx xx xxxxxxxxx xx "xxx". Xx xx xxxx, xxx xxxxxx xxxx xx xx x XXX xxxxxxx. Xx xxx, xxxx, xxx xxx Xxxxxxx Xxxxxxx Xxxxxxxxx (XXX) XXXx xx xxxxxxxx xxx xxxxxx xxx xxxxxx xxx xxxx xx x xxxxxx. Xxxxxx xxx, xxx xxxxxx xx x [**XxxxxxxYX**](https://msdn.microsoft.com/library/windows/desktop/ff476635) xxxxxx (xx xx xxxxx).

```cpp
void BasicLoader::CreateTexture(
    _In_ bool decodeAsDDS,
    _In_reads_bytes_(dataSize) byte* data,
    _In_ uint32 dataSize,
    _Out_opt_ ID3D11Texture2D** texture,
    _Out_opt_ ID3D11ShaderResourceView** textureView,
    _In_opt_ Platform::String^ debugName
    )
{
    ComPtr<ID3D11ShaderResourceView> shaderResourceView;
    ComPtr<ID3D11Texture2D> texture2D;

    if (decodeAsDDS)
    {
        ComPtr<ID3D11Resource> resource;

        if (textureView == nullptr)
        {
            CreateDDSTextureFromMemory(
                m_d3dDevice.Get(),
                data,
                dataSize,
                &resource,
                nullptr
                );
        }
        else
        {
            CreateDDSTextureFromMemory(
                m_d3dDevice.Get(),
                data,
                dataSize,
                &resource,
                &shaderResourceView
                );
        }

        resource.As(&texture2D);
    }
    else
    {
        if (m_wicFactory.Get() == nullptr)
        {
            // A WIC factory object is required in order to load texture
            // assets stored in non-DDS formats.  If BasicLoader was not
            // initialized with one, create one as needed.
            CoCreateInstance(
                    CLSID_WICImagingFactory,
                    nullptr,
                    CLSCTX_INPROC_SERVER,
                    IID_PPV_ARGS(&m_wicFactory));
        }

        ComPtr<IWICStream> stream;
        m_wicFactory->CreateStream(&stream);

        stream->InitializeFromMemory(
                data,
                dataSize);

        ComPtr<IWICBitmapDecoder> bitmapDecoder;
        m_wicFactory->CreateDecoderFromStream(
                stream.Get(),
                nullptr,
                WICDecodeMetadataCacheOnDemand,
                &bitmapDecoder);

        ComPtr<IWICBitmapFrameDecode> bitmapFrame;
        bitmapDecoder->GetFrame(0, &bitmapFrame);

        ComPtr<IWICFormatConverter> formatConverter;
        m_wicFactory->CreateFormatConverter(&formatConverter);

        formatConverter->Initialize(
                bitmapFrame.Get(),
                GUID_WICPixelFormat32bppPBGRA,
                WICBitmapDitherTypeNone,
                nullptr,
                0.0,
                WICBitmapPaletteTypeCustom);

        uint32 width;
        uint32 height;
        bitmapFrame->GetSize(&width, &height);

        std::unique_ptr<byte[]> bitmapPixels(new byte[width * height * 4]);
        formatConverter->CopyPixels(
                nullptr,
                width * 4,
                width * height * 4,
                bitmapPixels.get());

        D3D11_SUBRESOURCE_DATA initialData;
        ZeroMemory(&initialData, sizeof(initialData));
        initialData.pSysMem = bitmapPixels.get();
        initialData.SysMemPitch = width * 4;
        initialData.SysMemSlicePitch = 0;

        CD3D11_TEXTURE2D_DESC textureDesc(
            DXGI_FORMAT_B8G8R8A8_UNORM,
            width,
            height,
            1,
            1
            );

        m_d3dDevice->CreateTexture2D(
                &textureDesc,
                &initialData,
                &texture2D);

        if (textureView != nullptr)
        {
            CD3D11_SHADER_RESOURCE_VIEW_DESC shaderResourceViewDesc(
                texture2D.Get(),
                D3D11_SRV_DIMENSION_TEXTURE2D
                );

            m_d3dDevice->CreateShaderResourceView(
                    texture2D.Get(),
                    &shaderResourceViewDesc,
                    &shaderResourceView);
        }
    }


    if (texture != nullptr)
    {
        *texture = texture2D.Detach();
    }
    if (textureView != nullptr)
    {
        *textureView = shaderResourceView.Detach();
    }
}
```

Xxxx xxxx xxxx xxxxxxxxx, xxx xxxx x [**XxxxxxxYX**](https://msdn.microsoft.com/library/windows/desktop/ff476635) xx xxxxxx, xxxxxx xxxx xx xxxxx xxxx. Xx xxxx xxxxxx, xxx xxxxxxxx xxxx x xxx xx xxxx xx xxxx xxxx xxx xx xxx xxxxx xxxxx. Xxxxxxxx xxxxxxxx xxxxxx xxx xxxxxxxxx xxxxxxxx xxxxxxxx xxx-xxxxx xx xxx-xxxxx, xxxxxx xxxx xxxxxxx xxxx xxx xxxx xxx xxxx xx xxxxx xxxxxx.

(Xxx **XxxxxxXXXXxxxxxxXxxxXxxxxx** xxxxxx xxxxxx xx xxx xxxxx xxxxxx xxx xx xxxxxxxx xx xxxx xx [Xxxxxxxx xxxx xxx XXXXxxxxxxXxxxxx](complete-code-for-ddstextureloader.md).)

Xxxx, xxxxxxxxxx xxxxxxxx xx xxxxxxx "xxxxx" xxx xxx xx xxxxxxxx xxxx xxxxxxxx xx xxxxxxxx. Xxxx xxxxxxx xxxx xx xxxxxxx xxxxxxxx xx xxx xxxx xx xxxxxx xx xxxxxxxx xxxx xx xxxxxx xxx xxxxx xxx xxx xxxxxxxx. Xxxx xxxx xxxx xxx xxxxxxx xxxx xxxxxxxxxxx xx xxxx xxxx xxx xxxx xxx xxxxxxxx xxxx, xx xxx xxxx xxx xx xxx xxx xxxxxxx xxxxxxxx xx xxx xxxxxxxxxxxxx xxxxxxxx xxxx xxx xxxxxxx xxxxxxxx xxxxxxx.

### Xxxxxxx xxxxxxx

Xxxxxxx xxx xxxxxxxx Xxxx Xxxxx Xxxxxx Xxxxxxxx (XXXX) xxxxx xxxx xxx xxxxxx xxxx xxxxxx xxx xxxxxxx xx xxxxxxxx xxxxxx xx xxx xxxxxxxx xxxxxxxx. Xxx xxxx xxxxxx xxx xxxxxxxxx xxxxxxx xxx xxx xxxxxx xxx xxxxx xxxxxxx, xxxxx xxxxxxx xxx xxxxxxxxxx xxxxxxxx xx xxxx xxxx xxx xxx xxxxxx xx xxx xxxxx'x xxxxxxxx(x), xxxxxxxxxxxx. Xxx XXXX xxxx xx xxxxxxxx xx xxxxxxxxx xxx xxxxxxxx, xxxxx xxxxxxxx xxxxxxx xxx xxxxxxxx, xxx xxxxxxx xxxx-xxxxxxxxxx xx xxx xxxxxxxx xxxxx.

X XxxxxxYX xxxx xxx xxxx x xxxxxx xx xxxxxxxxx xxxxxxx, xxxx xxx xxxxxxxx xxxx x xxxxxxxx XXX (Xxxxxxxx Xxxxxx Xxxxxx, .xxx) xxxx. Xxxxxxxx, xxx xxx'x xxxx xx xxxx xxxx xxx xxxx xx xxxx xxxx xxxxxxxxxxx, xxx xx xxxx xxxxx, xxx xxx xxxxxx xxxx xxxx xxxx xxx xxxx xx xxxxxxxx, xx xx x xxx-xxxxx xxxxx (xxxx xx x xxxxxx xxx xxxx xxxxxxx).

Xxx xxxx xx xxx **XxxxxXxxxxx** xxxxx xxxxxxxx x xxxxxx xx xxxxxxxxx xxx xxxxxxxxx xxxxxxx, xxxxxxxxx xxxxxx, xxxxxxxx, xxxxx, xxx xxxx xxxxxxx. Xxx xxxx xxxxx xxxxxx xxxxx xxxxxxx xx xx xxxxxxx. (Xxx xxx xxxxxx xxx xxxxxxxx xxxx xx [Xxxxxxxx xxxx xxx XxxxxXxxxxx](complete-code-for-basicloader.md).)

```cpp
concurrency::task<void> LoadShaderAsync(
    _In_ Platform::String^ filename,
    _Out_ ID3D11PixelShader** shader
    );

// ...

task<void> BasicLoader::LoadShaderAsync(
    _In_ Platform::String^ filename,
    _Out_ ID3D11PixelShader** shader
    )
{
    return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ bytecode)
    {
        
       m_d3dDevice->CreatePixelShader(
                bytecode->Data,
                bytecode->Length,
                nullptr,
                shader);
    });
}

```

Xx xxxx xxxxxxx, xxx xxx xxx **XxxxxXxxxxxXxxxxx** xxxxxxxx (**x\_xxxxxXxxxxxXxxxxx**) xx xxxx xx xxx xxxxxxxx xxxxxxxx xxxxxx xxxxxx (.xxx) xxxx xx x xxxx xxxxxx. Xxxx xxxx xxxx xxxxxxxxx, xxx xxxxxx xxxxx [**XXYXYYXxxxxx::XxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476513) xxxx xxx xxxx xxxx xxxxxx xxxx xxx xxxx. Xxxx xxxxxxxx xxxx xxx xxxx xxxx xxxxxxxxxx xxxx xxx xxxx xxx xxxxxxxxxx, xxx xxxx xxxx xxxx xxxxx xxxx xxxx xxxxxx xxxxxxx xxx xxxxxx.

Xxxxxx xxxxxxx xxx xxx xxxx xxxxxxx. Xxx x xxxxxx xxxxxx, xxx xxxx xxxx x xxxxxxxx xxxxx xxxxxx xxxx xxxxxxx xxx xxxxxx xxxx. Xxx xxxxxxxxx xxxx xxx xx xxxx xx xxxxxxxxxxxxxx xxxx x xxxxxx xxxxxx xxxxx xxxx x xxxxxx xxxxxx xxxxx xxxxxx. Xx xxxx xxxx xxx xxxxxx xxxxxxxxxxx xxxx xxx xxxx xxxx xxxx xxxxxx xxx xx xxxxxxxxx xxxxxxxxxxx xx xxxx xxxxx xxxxxx!

Xxx'x xxxxxx xxx xxxxx xxxxxx xxxxxx xxx xxxx xxx xxxxxx xxxxxx.

```cpp
void BasicLoader::CreateInputLayout(
    _In_reads_bytes_(bytecodeSize) byte* bytecode,
    _In_ uint32 bytecodeSize,
    _In_reads_opt_(layoutDescNumElements) D3D11_INPUT_ELEMENT_DESC* layoutDesc,
    _In_ uint32 layoutDescNumElements,
    _Out_ ID3D11InputLayout** layout
    )
{
    if (layoutDesc == nullptr)
    {
        // If no input layout is specified, use the BasicVertex layout.
        const D3D11_INPUT_ELEMENT_DESC basicVertexLayoutDesc[] =
        {
            { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,  D3D11_INPUT_PER_VERTEX_DATA, 0 },
            { "NORMAL",   0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
            { "TEXCOORD", 0, DXGI_FORMAT_R32G32_FLOAT,    0, 24, D3D11_INPUT_PER_VERTEX_DATA, 0 },
        };

        m_d3dDevice->CreateInputLayout(
                basicVertexLayoutDesc,
                ARRAYSIZE(basicVertexLayoutDesc),
                bytecode,
                bytecodeSize,
                layout);
    }
    else
    {
        m_d3dDevice->CreateInputLayout(
                layoutDesc,
                layoutDescNumElements,
                bytecode,
                bytecodeSize,
                layout);
    }
}
```

Xx xxxx xxxxxxxxxx xxxxxx, xxxx xxxxxx xxx xxx xxxxxxxxx xxxx xxxxxxxxx xx xxx xxxxxx xxxxxx:

-   X YX xxxxxxxxxx xxxxxxxx (x, x, x) xx xxx xxxxx'x xxxxxxxxxx xxxxx, xxxxxxxxxxx xx x xxxx xx YY-xxx xxxxxxxx xxxxx xxxxxx.
-   X xxxxxx xxxxxx xxx xxx xxxxxx, xxxx xxxxxxxxxxx xx xxxxx YY-xxx xxxxxxxx xxxxx xxxxxx.
-   X xxxxxxxxxxx YX xxxxxxx xxxxxxxxxx xxxxx (x, x) , xxxxxxxxxxx xx x xxxx xx YY-xxx xxxxxxxx xxxxxx.

Xxxxx xxx-xxxxxx xxxxx xxxxxxxx xxx xxxxxx [XXXX xxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/bb509647), xxx xxxx xxx x xxx xx xxxxxxx xxxxxxxxx xxxx xx xxxx xxxx xx xxx xxxx xxxx xxxxxxxx xxxxxx xxxxxx. Xxxx xxxxxxxx xxxx xxx xxxxxx xxxxxx xxxx xxx xxxxx xxxxxx xx xxx xxxx xxxx xxx'xx xxxxxx. Xxx xxxxxxxxx xxxxxx xxx xxxxx xx (xxx xxxxxx xxxx) xxx xxxxxx xxxxxx xx xx xxxx, xxx xxxxxxx xxxx xxxx xxx xxxx xxx-xxxxxx xxxxxxxxxxxx xx xxxx xxxxxx'x XXXX xxxx.

Xxx, xxxx xxx xxxxxx xxxxxx xxxxxx.

```cpp
concurrency::task<void> LoadShaderAsync(
        _In_ Platform::String^ filename,
        _In_reads_opt_(layoutDescNumElements) D3D11_INPUT_ELEMENT_DESC layoutDesc[],
        _In_ uint32 layoutDescNumElements,
        _Out_ ID3D11VertexShader** shader,
        _Out_opt_ ID3D11InputLayout** layout
        );

// ...

task<void> BasicLoader::LoadShaderAsync(
    _In_ Platform::String^ filename,
    _In_reads_opt_(layoutDescNumElements) D3D11_INPUT_ELEMENT_DESC layoutDesc[],
    _In_ uint32 layoutDescNumElements,
    _Out_ ID3D11VertexShader** shader,
    _Out_opt_ ID3D11InputLayout** layout
    )
{
    // This method assumes that the lifetime of input arguments may be shorter
    // than the duration of this task.  In order to ensure accurate results, a
    // copy of all arguments passed by pointer must be made.  The method then
    // ensures that the lifetime of the copied data exceeds that of the task.

    // Create copies of the layoutDesc array as well as the SemanticName strings,
    // both of which are pointers to data whose lifetimes may be shorter than that
    // of this method's task.
    shared_ptr<vector<D3D11_INPUT_ELEMENT_DESC>> layoutDescCopy;
    shared_ptr<vector<string>> layoutDescSemanticNamesCopy;
    if (layoutDesc != nullptr)
    {
        layoutDescCopy.reset(
            new vector<D3D11_INPUT_ELEMENT_DESC>(
                layoutDesc,
                layoutDesc + layoutDescNumElements
                )
            );

        layoutDescSemanticNamesCopy.reset(
            new vector<string>(layoutDescNumElements)
            );

        for (uint32 i = 0; i < layoutDescNumElements; i++)
        {
            layoutDescSemanticNamesCopy->at(i).assign(layoutDesc[i].SemanticName);
        }
    }

    return m_basicReaderWriter->ReadDataAsync(filename).then([=](const Platform::Array<byte>^ bytecode)
    {
       m_d3dDevice->CreateVertexShader(
                bytecode->Data,
                bytecode->Length,
                nullptr,
                shader);

        if (layout != nullptr)
        {
            if (layoutDesc != nullptr)
            {
                // Reassign the SemanticName elements of the layoutDesc array copy to point
                // to the corresponding copied strings. Performing the assignment inside the
                // lambda body ensures that the lambda will take a reference to the shared_ptr
                // that holds the data.  This will guarantee that the data is still valid when
                // CreateInputLayout is called.
                for (uint32 i = 0; i < layoutDescNumElements; i++)
                {
                    layoutDescCopy->at(i).SemanticName = layoutDescSemanticNamesCopy->at(i).c_str();
                }
            }

            CreateInputLayout(
                bytecode->Data,
                bytecode->Length,
                layoutDesc == nullptr ? nullptr : layoutDescCopy->data(),
                layoutDescNumElements,
                layout);   
        }
    });
}

```

Xx xxxx xxxx, xxxx xxx'xx xxxx xx xxx xxxx xxxx xxx xxx xxxxxx xxxxxx'x XXX xxxx, xxx xxxxxx xxx xxxxxx xxxxxx xx xxxxxxx [**XXYXYYXxxxxx::XxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ff476524). Xxxxx xxxx, xxx xxxxxx xxxx xxxxx xxxxxx xxx xxx xxxxxx xx xxx xxxx xxxxxx.

Xxxxx xxxxxx xxxxx, xxxx xx xxxx xxx xxxxxxxx xxxxxxx, xxx xxxx xxxxxxx xxxxxxxx xxxxxxxxxxxxx. Xxxxxxxx xxxx xxx x xxxxxxx xx xxxxxx xxxxxxx xxxxxxx xx xxxxxxxx xx [Xxxxxxxx xxxx xxx XxxxxXxxxxx](complete-code-for-basicloader.md) xxx xx xxx [XxxxxxYX xxxxxxxx xxxxxxx xxxxxx]( http://go.microsoft.com/fwlink/p/?LinkID=265132).

## Xxxxxxx

Xx xxxx xxxxx, xxx xxxxxx xxxxxxxxxx xxx xx xxxx xx xxxxxx xx xxxxxx xxxxxxx xxx xxxxxxxxxxxxxx xxxxxxx xxxxxx xxxx xxxxxxxxx xxx xxxxxx, xxxx xx xxxxxx, xxxxxxxx, xxx xxxxxxxx xxxxxxx.

## Xxxxxxx xxxxxx

* [XxxxxxYX xxxxxxxx xxxxxxx xxxxxx]( http://go.microsoft.com/fwlink/p/?LinkID=265132)
* [Xxxxxxxx xxxx xxx XxxxxXxxxxx](complete-code-for-basicloader.md)
* [Xxxxxxxx xxxx xxx XxxxxXxxxxxXxxxxx](complete-code-for-basicreaderwriter.md)
* [Xxxxxxxx xxxx xxx XXXXxxxxxxXxxxxx](complete-code-for-ddstextureloader.md)

 

 




<!--HONumber=Mar16_HO1-->
