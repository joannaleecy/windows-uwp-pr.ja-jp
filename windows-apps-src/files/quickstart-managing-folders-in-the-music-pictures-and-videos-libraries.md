---
xx.xxxxxxx: YXXYYYYY-YXYX-YYYY-XXXX-XYYYYYXXYXYY
xxxxx: Xxxxx xxx xxxxxxx xx xxx Xxxxx, Xxxxxxxx, xxx Xxxxxx xxxxxxxxx
xxxxxxxxxxx: Xxx xxxxxxxx xxxxxxx xx xxxxx, xxxxxxxx, xx xxxxxx xx xxx xxxxxxxxxxxxx xxxxxxxxx. Xxx xxx xxxx xxxxxx xxxxxxx xxxx xxxxxxxxx, xxx xxx xxxx xx xxxxxxx xx x xxxxxxx, xxx xxxxxxxx xxxxxx xxxxxx, xxxxx, xxx xxxxxx.
---

# Xxxxx xxx xxxxxxx xx xxx Xxxxx, Xxxxxxxx, xxx Xxxxxx xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxx xxxxxxxx xxxxxxx xx xxxxx, xxxxxxxx, xx xxxxxx xx xxx xxxxxxxxxxxxx xxxxxxxxx. Xxx xxx xxxx xxxxxx xxxxxxx xxxx xxxxxxxxx, xxx xxx xxxx xx xxxxxxx xx x xxxxxxx, xxx xxxxxxxx xxxxxx xxxxxx, xxxxx, xxx xxxxxx.

X xxxxxxx xx x xxxxxxx xxxxxxxxxx xx xxxxxxx, xxxxx xxxxxxxx x xxxxx xxxxxx xx xxxxxxx xxxx xxx xxxxx xxxxxxx xxx xxxx xxx xxxxx xx xxx xxxxxxx xx xxxxx xxxx xxx xx xxx xx xxx xxxxx-xx xxxx. Xxx xxxxxxx, xxx Xxxxxxxx xxxxxxx xxxxxxxx xxx Xxxxxxxx xxxxx xxxxxx xx xxxxxxx. Xxx xxxx xxx xxx xxxxxxx xx, xx xxxxxx xxxx xxxx, xxx Xxxxxxxx xxxxxxx xx xxxxx xxxx xxx xx xxx xxxxx-xx Xxxxxx xxx.

## Xxxxxxxxxxxxx


-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

-   **Xxxxxx xxxxxxxxxxx xx xxx xxxxxxxx**

    Xx Xxxxxx Xxxxxx, xxxx xxx xxx xxxxxxxx xxxx xx Xxxxxxxx Xxxxxxxx. Xx xxx **Xxxxxxxxxxxx** xxxx, xxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxxxxx.

    -   **Xxxxx Xxxxxxx**
    -   **Xxxxxxxx Xxxxxxx**
    -   **Xxxxxx Xxxxxxx**

    Xx xxxxx xxxx, xxx [Xxxx xxxxxx xxxxxxxxxxx](file-access-permissions.md).

## Xxx x xxxxxxxxx xx x xxxxxxx


**Xxxx**  Xxxxxxxx xx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxxx.
 

Xx xxx x xxxxxxxxx xx xxx xxxx'x Xxxxx, Xxxxxxxx, xx Xxxxx xxxxxxx, xxxx xxx [**XxxxxxxXxxxxxx.XxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251725) xxxxxx. Xxxxxxx xxx xxxxxxxxxxxxx xxxxx xxxx xxx [**XxxxxXxxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/dn298399) xxxxxxxxxxx.

-   [**XxxxxXxxxxxxXx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227155)
-   [**XxxxxXxxxxxxXx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227156)
-   [**XxxxxXxxxxxxXx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227159)

```CSharp
    var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync
        (Windows.Storage.KnownLibraryId.Pictures);
```

## Xxx xxx xxxx xx xxxxxxx xx x xxxxxxx


Xx xxx xxx xxxx xx xxxxxxx xx x xxxxxxx, xxx xxx xxxxx xx xxx [**XxxxxxxXxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251724) xxxxxxxx.

```CSharp
    using Windows.Foundation.Collections;

    // ...
            
    IObservableVector<Windows.Storage.StorageFolder> myPictureFolders = myPictures.Folders;
```

## Xxx xxx xxxxxx xx x xxxxxxx xxxxx xxx xxxxx xxx xxxxx xx xxxxxxx


Xx xxx xxx xxxxxx xx x xxxxxxx xxxxx xxx xxxxx xxx xxxxx xx xxxxxxx, xxx xxx xxxxx xx xxx [**XxxxxxxXxxxxxx.XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251728) xxxxxxxx.

```CSharp
    Windows.Storage.StorageFolder savePicturesFolder = myPictures.SaveFolder;
```

## Xxx xx xxxxxxxx xxxxxx xx x xxxxxxx


Xx xxx x xxxxxx xx x xxxxxxx, xxx xxxx xxx [**XxxxxxxXxxxxxx.XxxxxxxXxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251726). Xxxxxx xxx Xxxxxxxx Xxxxxxx xx xx xxxxxxx, xxxxxxx xxxx xxxxxx xxxxxx x xxxxxx xxxxxx xx xx xxxxx xx xxx xxxx xxxx xx **Xxx xxxx xxxxxx xx Xxxxxxxx** xxxxxx. Xx xxx xxxx xxxxx x xxxxxx xxxx xxx xxxxxx xxxxxxx xx xxx xxxxxxxx xxxxxxxx xx xxxx xxx xx xxxxxxx xx xxxx xx xxx [**XxxxxxxXxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251724) xxxxxxxx (xxx xx xxx xxxxx-xx Xxxxxx xxx), xxx xxx xxxxxx xxxx xxx xxxxxx xx x xxxxx xx xxx Xxxxxxxx xxxxxx xx Xxxx Xxxxxxxx.


```CSharp
    Windows.Storage.StorageFolder newFolder = await myPictures.RequestAddFolderAsync();
```

## Xxxxxx x xxxxxx xxxx x xxxxxxx


Xx xxxxxx x xxxxxx xxxx x xxxxxxx, xxxx xxx [**XxxxxxxXxxxxxx.XxxxxxxXxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251727) xxxxxx xxx xxxxxxx xxx xxxxxx xx xx xxxxxxx. Xxx xxxxx xxx [**XxxxxxxXxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251724) xxx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242878) xxxxxxx (xx xxxxxxx) xxx xxx xxxx xx xxxxxx x xxxxxx xx xxxxxx.

Xxxx xxx xxxx [**XxxxxxxXxxxxxx.XxxxxxxXxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251727), xxx xxxx xxxx x xxxxxxxxxxxx xxxxxx xxxxxx xxxx xxx xxxxxx "xxx'x xxxxxx xx Xxxxxxxx xxxxxxx, xxx xxx'x xx xxxxxxx." Xxxx xxxx xxxxx xx xxxx xxx xxxxxx xxxxxxx xx xxx xxxxxxxx xxxxxxxx xx xxxx, xx xxxxxxx xxxx xxx [**XxxxxxxXxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251724) xxxxxxxx, xxx xxxx xx xxxxxx xxxxxxxx xx xxx xxxxx-xx Xxxxxx xxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxx xxxx xxx xxxx xxx xxxxxxxx xxx xxxxxx xx xxxxxx xxxx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242878) xxxxxxx xxxxx **xxXxxxxxxXxxxxxx**.


```CSharp
    bool result = await myPictures.RequestRemoveFolderAsync(folder);
```

## Xxx xxxxxxxx xx xxxxxxx xx xxx xxxx xx xxxxxxx xx x xxxxxxx


Xx xxx xxxxxxxx xxxxx xxxxxxx xx xxx xxxx xx xxxxxxx xx x xxxxxxx, xxxxxxxx x xxxxxxx xxx xxx [**XxxxxxxXxxxxxx.XxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251723) xxxxx xx xxx xxxxxxx.


```CSharp
    myPictures.DefinitionChanged += MyPictures_DefinitionChanged;
    // ...

void HandleDefinitionChanged(Windows.Storage.StorageLibrary sender, object args)
{
    // ...
}
```

## Xxxxx xxxxxxx xxxxxxx


X xxxxxx xxxxxxxx xxxx xxxxxxxxxx xxxxxxxxx xxx xxxxx xxx xxxx xx xxxxx xxxxx xxxxx. Xxxxx-xx xxxx xxxxx xxxx xxxx-xxxxxxx xxxxx xxx xxxxxxxxxx xxxxx xx xxxxx xxxxxxxxx.

Xxx xxxxxxxxx xxx:

-   **Xxxxxxxx** xxxxxx. Xxxxxxxx xxxxxxxx.

    -   **Xxxxxx Xxxx** xxxxxx. Xxxxxxxx xxxxxx xxx xxxxx xxxx xxx xxxxx-xx xxxxxx.

    -   **Xxxxx Xxxxxxxx** xxxxxx. Xxxxxxxx xxxxxxxx xxxx xxx xxxx xxx xxxxx xxxx xxxxx xxxx.

-   **Xxxxx** xxxxxx. Xxxxxxxx xxxxx, xxxxxxxx, xxx xxxxx xxxxx.

-   **Xxxxx** xxxxxx. Xxxxxxxx xxxxxx.

Xxxxx xx xxxx xxx xxxx xxxxx xxxxx xxxxx xxxxxxx xxx xxxxx xxxxxxx xxxxxxx xx xxx XX xxxx. Xx xxxx x xxxxx xxxx xxxxxxxx xx xxx XX xxxx, xxxx xxx xxxxxxxx xx xxx XX xxxx, xx xxx xxx xxxx xx xxxxxx xxx xxxx xx xxxxx x xxxx xxxxxx. Xxx xxxx xxxx, xxx [Xxxxxx xxx XX xxxx](access-the-sd-card.md).

## Xxxxxxxx xxx xxxxx xxxxxxxxx


### Xxxxx xxxxxxx xxxxxxx xxxx xxxxxxxx xxx xxxxxxxxx xxxxxxx

Xxxxx xxx xxxxxx xx xxxxx xxxxx xx xxxxxxx xx xxx xxxxxxxx XX xxxx. Xxxx, xxxxxxx, xxx xxx xxx xx xxxxxxxx xxxxx xx xx xxxxxx xx xxx XX xxxx. Xx x xxxxxx, xxx xxxxx xxxxxxxxx xxx xx xxxxx xxxxxx xxx xxxxxx'x xxxxxxxx xxxxxxx xxx xxx XX xxxx.

Xxx xxx'x xxxx xx xxxxx xxxxxxxxxx xxxx xx xxxxxx xxxx xxxxxxxxxxx. Xxx xxxxxxx xx xxx [**Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227346) xxxxxxxxx xxxx xxxxx xxxxx xxxxxxx xxxxxxxxxxxxx xxxxxxx xxx xxxxx xxxxxxx xxxx xxxx xxxxxxxxx. Xxx xxx'x xxxx xx xxxxxxx xxx **xxxxxxxxxXxxxxxx** xxxxxxxxxx xx xxx xxx xxxxxxxx xxxx xx xxx xxxxx xxxxxxxx xxxxxxx, xxxxxx.

Xxxxxxxx xxx xxxxx xx xxx xxxxxx'x xxxxxxx xxxxx xx xxx xxxxxxxxx xxxxx:

![xxxxxx xx xxx xxxxx xxx xx xxxx](images/phone-media-locations.png)

Xx xxx xxxxx xxx xxxxxxxx xx xxx Xxxxxxxx Xxxxxxx xx xxxxxxx `await KnownFolders.PicturesLibrary.GetFilesAsync()`, xxx xxxxxxx xxxxxxx xxxx xxxxxxxxXxx.xxx xxx XXXxx.xxx.

### Xxxx xxxxxxx

Xxx xxx xxxx xxxxxxx xx xxxxxxxxx xxx xxxxxx xxxxxxxx xx x xxxxx xxxxxxx xxxxxxx.

Xxx xxxx xxxxxxx xxxxxx xxxx xxxxx xx xxx xxxxxxxxx xxxxx xxxx. Xxx xxxxxxx, xx xxx xxxxx xxx Xxxxx Xxxxxxx xxxx x xxxx xxxxx, xxx xxxxx xxxxxxx xx xxx xxxxxxx xxx xxxxxxx xxxxx xxxxx xx xxx Xxxxx xxxxxx.

Xx xxxxxxx xxxxx xxx xxxxxx xxxxx xxxx x xxx-xxxxxxxxxx xxxxx xxx x xxxx-xxxxxxxxxx xxxxx xx xxxxx xxxxxxx, xxx xxxx xxxxxxx xxxxxx xxxx xxx xxx-xxxxxxxxxx xxxxx.

Xxx Xxxxxx Xxxx xxx xxx Xxxxx Xxxxxxxx xxxxxx xx xxx xxxxxxx xxx xxxx xxxxxxx.

Xxx xxxxxxxxx xxxx xxxxxxx xxx xxxxxxxxx:

**Xxxxxxxx xxxxxxx**

-   `GetFilesAsync(CommonFileQuery.OrderByDate)`

**Xxxxx xxxxxxx**

-   `GetFilesAsync(CommonFileQuery.OrderByName)`
-   `GetFoldersAsync(CommonFolderQuery.GroupByArtist)`
-   `GetFoldersAysnc(CommonFolderQuery.GroupByAlbum)`
-   `GetFoldersAysnc(CommonFolderQuery.GroupByAlbumArtist)`
-   `GetFoldersAsync(CommonFolderQuery.GroupByGenre)`

**Xxxxx xxxxxxx**

-   `GetFilesAsync(CommonFileQuery.OrderByDate)`

### Xxxx xxxxxxx

Xx xxx x xxxxxxxx xxxxxxx xx xxx xxx xxxxx xxx xxxxxxx xx x xxxxxxx, xxxx `GetFilesAsync(CommonFileQuery.DefaultQuery)`. Xxxx xxxxxx xxxxxxx xxx xxxxx xx xxx xxxxxxx, xxxxxxxxxx xx xxxxx xxxx. Xxxx xx x xxxxxxx xxxxx, xx xxx xxxx xx xxxxxxxxx xxx xxxxxxxx xx xxxxxxxxxx xxxxxxxxxxx xx xxx xxxx xxx xxxxxxx xxxxxxxxxx xx xxx xxxxxxx.

Xxx xxxx xxxxxxx xx xxxxxx xxxxx xxxxx xx xxxxx xxxx xxx xxx xxxxxxxxxx xx xxx xxxxx-xx xxxxxxx, xx xx xxxxxx xxx xxx xxxxx xx x xxxxxxx, xxxxxxxxx xxxxx xxxx xxx xxx xx xxx xxxxxxxxx xxxx. Xxx xxxxxxx, xx xxx xxxxx xxx Xxxxx Xxxxxxx xxxx x xxxx xxxxx, xxx xxxxx xxxxxxx xxxxxxx xxx xxxxxxx xxxxx xxxxx xx xxx xxxxx xx xxx Xxxxx xxxxxx.

### Xxxxxx xxxxxxx

Xxxxxx xxxx xxx xxxxxx xxx xxx xxxxxxxx XX xxxx xxxxxxx xxx xxxxxxx xxx xxxxx xxxxx xx xxx xxxxxxxxx xxxxx:

![xxxxx xx ](images/phone-media-queries.png)

Xxxx xxx x xxx xxxxxxxx xx xxxxxxx xxx xxx xxxxxxx xxxx xxxx xxxxxx.

| Xxxxx | Xxxxxxx |
|--------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|
| XxxxxXxxxxxx.XxxxxxxxXxxxxxx.XxxXxxxxXxxxx();  | - Xxxxxx Xxxx xxxxxx xxxx xxxxxxxx xxxxxxx <br>- Xxxxxx Xxxx xxxxxx xxxx xxx XX xxxx <br>- Xxxxx Xxxxxxxx xxxxxx xxxx xxxxxxxx xxxxxxx <br>- Xxxxx Xxxxxxxx xxxxxx xxxx xxx XX xxxx <br><br>Xxxx xx x xxxx xxxxx, xx xxxx xxxxxxxxx xxxxxxxx xx xxx Xxxxxxxx xxxxxx   xxx xxxxxxxx. |
| XxxxxXxxxxxx.XxxxxxxxXxxxxxx.XxxXxxxxXxxxx();  | Xx xxxxxxx. <br><br>Xxxx xx xxxx xxxxx, xxx xxx Xxxxxxxx xxxxxx xxxx xxx xxxxxxx xxx xxxxx xx xxx xxxxxxxxx xxxxxxxx. |
| XxxxxXxxxxxx.XxxxxxxxXxxxxxx.XxxXxxxxXxxxx(XxxxxxXxxxXxxxx.XxxxxXxXxxx); | - Y-Y-YYYY.xxx xxxx xxxx xxx XX xxxx <br>- Y-Y-YYYY.xxx xxxx xxxx xxxxxxxx xxxxxxx <br>- Y-Y-YYYY.xxx xxxx xxxx xxxxxxxx xxxxxxx <br>- Y-Y-YYYY.xxx xxxx xxxx xxx XX xxxx <br><br>Xxxx xx x xxxx xxxxx, xx xxx xxxxxxxx xx xxx Xxxxxxxx xxxxxx xxx xx xxx   xxxxx xxxxxxx xxx xxxxxxxx. |
| XxxxxXxxxxxx.XxxxxxXxxx.XxxXxxxxXxxxx(); | - Y-Y-YYYY.xxx xxxx xxxx xxxxxxxx xxxxxxx <br>- Y-Y-YYYY.xxx xxxx xxxx xxx XX xxxx <br><br>Xxxx xx x xxxx xxxxx. Xxx xxxxxxxx xx xxx xxxxxxx xx xxx xxxxxxxxxx. |

 
## Xxxxx xxxxxxx xxxxxxxxxxxx xxx xxxx xxxxx


Xxxx xxx xxx xxxxxxxxxxxx xxxx xxx xxx xxxxxxx xx xxx xxx xxxxxxxx xxxx xx xxxxxx xxxxx xxxxx xx xxxx xxx.

-   **Xxxxx**. Xxxxxxx xxx **Xxxxx Xxxxxxx** xxxxxxxxxx xx xxx xxx xxxxxxxx xxxx xx xxx xxxx xxx xxx xxx xxxxxx xxxxx xx xxx xxxxxxxxx xxxx xxxxx:

    -   .xxx
    -   .xxx
    -   .xxY
    -   .xYx
    -   .xYx
    -   .xxx
    -   .xxx
    -   .xxx
    -   .YxY
    -   .Yxx
    -   .xxY
    -   .xx
    -   .xxx
    -   .Yxxx
    -   .YxxY
    -   .xxx
    -   .xxx
    -   .xxxx
    -   .xxx
-   **Xxxxxx**. Xxxxxxx xxx **Xxxxxxxx Xxxxxxx** xxxxxxxxxx xx xxx xxx xxxxxxxx xxxx xx xxx xxxx xxx xxx xxx xxxxxx xxxxx xx xxx xxxxxxxxx xxxx xxxxx:

    -   .xxxx
    -   .xxx
    -   .xxx
    -   .xxx
    -   .xxxx
    -   .xxx
    -   .xxx
    -   .xxx
    -   .xxx
    -   .xxx
    -   .xxx
-   **Xxxxxx**. Xxxxxxx xxx **Xxxxx Xxxxxxx** xxxxxxxxxx xx xxx xxx xxxxxxxx xxxx xx xxx xxxx xxx xxx xxx xxxxxx xxxxx xx xxx xxxxxxxxx xxxx xxxxx:

    -   .xx
    -   .xYx
    -   .xxx
    -   .xxx
    -   .xxx
    -   .xxY
    -   .YxY
    -   .Yxx
    -   .xxYx
    -   .xxx
    -   .xxx
    -   .Yxxx
    -   .YxxY

## Xxxxxxx xxxx xxxxxx


Xx xxxxxxx xxxxx xxx xxxxxx xxxxx xxxx x xxx-xxxxxxxxxx xxxxx xxx x xxxx-xxxxxxxxxx xxxxx xx xxxxx xxxxxxx, xxx xxxx xxxxxxx xxxxxx xxxx xxx xxx-xxxxxxxxxx xxxxx.

Xxx Xxxxxx Xxxx xxx xxx Xxxxx Xxxxxxxx xxxxxx xx xxx xxxxxxx xxx xxxx xxxxxxx.

**Xxxxxxx x xxxxx xx xxx xxx xxxx xxxxxxxx xx**

Xx xxx xxxx xx xxx xxx xxxx xxxx x xxxxx xxxxx xxxxx xx xxx xxx xxxx xxxxxxxx xx, xxx xxx xxxx xxx **XxxxxxxXxxXx** xxxx xxx xxxxx'x xxxxxxxx xx xxxxx xxxx xxxxxxx xx xxx xxxxxxxxx xxxxxxx. Xx xxxx xxxxxxx, **xxxxXxxxx** xx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171).

```CSharp
  IDictionary<string, object> propertiesToSave = new Dictionary<string, object>();

  propertiesToSave.Add("System.CreatorOpenWithUIOptions", 1);
  propertiesToSave.Add("System.CreatorAppId", appId);
 
  testPhoto.Properties.SavePropertiesAsync(propertiesToSave).AsyncWait();   
```

## Xxxxx xxxxxx xxxxxxx xx xxx x xxxx xx x xxxxx xxxxxxx


Xxxx xxx xxxxxx x xxxxx xxxxxxx xx xxxxx x xxxxx xxxxxx xxxx xx **XxxxxXxxxxxx.XxxxxxxXxxxxxx**, xxx xxx xxx xxxxxx xxxxxxx xx xxx x xxxx xx xxx xxxxx xxxxxxx, xxx xxxx xx xxxx xxxx xx xxxxx xxx xxx xxxxxxx xxxx xxxx xxxx xxxxx. Xxxxxxxxx xxxxx xxxxxxx xxxx xx xxx xxx xxxx xx xxx xxxxx xxxxxxx xx xxxxxxxx xxxxxxx xx xxxxx xxx xxxxxx xxxxx xxx x xxxxxx xx xxx xxxx.

Xxx xxxxxxx, xxxx xxx xxx xxx xxxxxxxxx xxxx, xxx xxxx xx xxx xxxxx xx xxx xxxxx xxxxxxx. Xx xxx xxxx xx xxxx, `using (var destinationStream = (await destinationFile.OpenAsync(FileAccessMode.ReadWrite)).GetOutputStreamAt(0))`, xxxx xxx **XxxxXxxxx** xxxxxx xxx xxx **XxxXxxxxxXxxxxxXx** xxxxxx xxxx x xxxxxx. Xxxxxxx xxxx xxx xxxxxx xxxxxx xx xxx **XxxXxxxxxXxxxxxXx** xxxxxx xx xxxxxxxx xx x xxxxxx xx xxx **xxxxx** xxxxxxxxx. Xxx xxxxx xxxxxx xxxxxxx xxxx xxx xxxxxxxx xxxxxx xxx xxxx.

```CSharp
StorageFolder testFolder = await StorageFolder.GetFolderFromPathAsync(@"C:\test");
StorageFile sourceFile = await testFolder.GetFileAsync("TestImage.jpg");
StorageFile destinationFile = await KnownFolders.CameraRoll.CreateFileAsync("MyTestImage.jpg");
using (var sourceStream = (await sourceFile.OpenReadAsync()).GetInputStreamAt(0))
{
    using (var destinationStream = (await destinationFile.OpenAsync(FileAccessMode.ReadWrite)).GetOutputStreamAt(0))
    {
        await RandomAccessStream.CopyAndCloseAsync(sourceStream, destinationStream);
    }
}

```

Xx xxx xxxxxx xxxxxxx xxxxxxxxxxxx xx xxx x xxxx xx xxx xxxxx xxxxxxx, xxxx xxxx xx xxxxx xxx xxx xxxxxxx xxxx xxxx xxxx xxxxx, xx xxxxx xx xxx xxxxxxxxx xxxxxxx.

```CSharp
StorageFolder testFolder = await StorageFolder.GetFolderFromPathAsync(@"C:\test");
StorageFile sourceFile = await testFolder.GetFileAsync("TestImage.jpg");
StorageFile destinationFile = await KnownFolders.CameraRoll.CreateFileAsync("MyTestImage.jpg");

using (var sourceStream = await sourceFile.OpenReadAsync())
{
    using (var sourceInputStream = sourceStream.GetInputStreamAt(0))
    {
        using (var destinationStream = await destinationFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            using (var destinationOutputStream = destinationStream.GetOutputStreamAt(0))
            {
                await RandomAccessStream.CopyAndCloseAsync(sourceInputStream, destinationStream);
            }
        }
    }
}
```

 

 




<!--HONumber=Mar16_HO1-->
