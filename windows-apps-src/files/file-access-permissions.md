---
xx.xxxxxxx: YXYYYXXY-XYYY-YYXY-XYXY-YYYYYYYYYYYX
xxxxx: Xxxx xxxxxx xxxxxxxxxxx
xxxxxxxxxxx: Xxxx xxx xxxxxx xxxxxxx xxxx xxxxxx xxxxxxxxx xx xxxxxxx. Xxxx xxx xxxx xxxxxx xxxxxxxxxx xxxxxxxxx xxxxxxx xxx xxxx xxxxxx, xx xx xxxxxxxxx xxxxxxxxxxxx.
---
# Xxxx xxxxxx xxxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxx xxxxxx xxxxxxx xxxx xxxxxx xxxxxxxxx xx xxxxxxx. Xxxx xxx xxxx xxxxxx xxxxxxxxxx xxxxxxxxx xxxxxxx xxx xxxx xxxxxx, xx xx xxxxxxxxx xxxxxxxxxxxx.

## Xxx xxxxxxxxx xxxx xxx xxxx xxx xxxxxx

Xxxx xxx xxxxxx x xxx xxx, xxx xxx xxxxxx xxx xxxxxxxxx xxxx xxxxxx xxxxxxxxx xx xxxxxxx:

-   **Xxxxxxxxxxx xxxxxxx xxxxxxxxx**. Xxx xxxxxx xxxxx xxxx xxx xx xxxxxxxxx xx xxx xxxx’x xxxxxx.

    Xxxxx xxx xxx xxxxxxx xxxx xx xxxxxx xxxxx xxx xxxxxxx xx xxxx xxx’x xxxxxxx xxxxxxxxx:

    1.  Xxx xxx xxxxxxxx x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxx xxxxxxxxxx xxxx xxx'x xxxxxxx xxxxxxxxx, xxxx xxxx:
        > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
        ```csharp
        Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
        ```
        ```javascript
        var installDirectory = Windows.ApplicationModel.Package.current.installedLocation;
        ```

       Xxx xxx xxxx xxxxxx xxxxx xxx xxxxxxx xx xxx xxxxxxxxx xxxxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxxxxx. Xx xxx xxxxxxx, xxxx **XxxxxxxXxxxxx** xx xxxxxx xx xxx `installDirectory` xxxxxxxx. Xxx xxx xxxxx xxxx xxxxx xxxxxxx xxxx xxxx xxx xxxxxxx xxx xxxxxxx xxxxxxxxx xx xxxxxxxxxxx xxx [Xxx xxxxxxx xxxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231526) xxx Xxxxxxx Y.Y xxx xx-xxxxx xxx xxxxxx xxxx xx xxxx Xxxxxxx YY xxx.

    2.  Xxx xxx xxxxxxxx x xxxx xxxxxxxx xxxx xxxx xxx'x xxxxxxx xxxxxxxxx xx xxxxx xx xxx XXX, xxxx xxxx:
        > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
        ```csharp
        using Windows.Storage;            
        StorageFile file = await StorageFile.GetFileFromApplicationUriAsync("ms-appx:///file.txt");
        ```
        ```javascript
        Windows.Storage.StorageFile.getFileFromApplicationUriAsync("ms-appx:///file.txt").done(
            function(file) {
                // Process file
            }
        );
        ```
        
        Xxxx [**XxxXxxxXxxxXxxxxxxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701741) xxxxxxxxx, xx xxxxxxx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxx xxxxxxxxxx xxx *xxxx.xxx* xxxx xx xxx xxx'x xxxxxxx xxxxxxxxx (`file` xx xxx xxxxxxx).

        Xxx "xx-xxxx:///" xxxxxx xx xxx XXX xxxxxx xx xxx xxx'x xxxxxxx xxxxxxxxx. Xxx xxx xxxxx xxxx xxxxx xxxxx xxx XXXx xx [Xxx xx xxx XXXx xx xxxxxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh781215).

    Xx xxxxxxxx, xxx xxxxxx xxxxx xxxxxxxxx, xxx xxx xxxx xxxxxx xxxxx xx xxxx xxx xxxxxxx xxxxxxxxx xx xxxxx xxxx [XxxYY xxx XXX xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx](https://msdn.microsoft.com/library/windows/apps/br205757) xxx xxxx [X/X++ Xxxxxxxx Xxxxxxx xxxxxxxxx xxxx Xxxxxxxxx Xxxxxx Xxxxxx](http://msdn.microsoft.com/library/hh875057.aspx).

    Xxx xxx'x xxxxxxx xxxxxxxxx xx x xxxx-xxxx xxxxxxxx. Xxx xxx’x xxxx xxxxxx xx xxx xxxxxxx xxxxxxxxx xxxxxxx xxx xxxx xxxxxx.

-   **Xxxxxxxxxxx xxxx xxxxxxxxx.** Xxx xxxxxxx xxxxx xxxx xxx xxx xxxxx xxxx. Xxxxx xxxxxxx (xxxxx, xxxxxxx xxx xxxxxxxxx) xxx xxxxxxx xxxx xxxx xxx xx xxxxxxxxx.

    Xxxxx xxx xxx xxxxxxx xxxx xx xxxxxx xxxxx xxx xxxxxxx xxxx xxxx xxx’x xxxx xxxxxxxxx:

    1.  Xxx [**XxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br241587) xxxxxxxxxx xx xxxxxxxx xx xxx xxxx xxxxxx.

        Xxx xxxxxxx, xxx xxx xxx [**XxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br241587).[**XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241621) xx xxxxxxxx x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxx xxxxxxxxxx xxxx xxx'x xxxxx xxxxxx xxxx xxxx:
        > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
        ```csharp
        using Windows.Storage;
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        ```
        ```javascript
        var localFolder = Windows.Storage.ApplicationData.current.localFolder;
        ```
 
        Xx xxx xxxx xx xxxxxx xxxx xxx'x xxxxxxx xx xxxxxxxxx xxxxxx, xxx xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241623) xx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241629) xxxxxxxx xxxxxxx.

        Xxxxx xxx xxxxxxxx x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxx xxxxxxxxxx xx xxx xxxx xxxxxxxx, xxx xxx xxxxxx xxxxx xxx xxxxxxx xx xxxx xxxxxxxx xx xxxxx **XxxxxxxXxxxxx** xxxxxxx. Xx xxx xxxxxxx, xxxxx **XxxxxxxXxxxxx** xxxxxxx xxx xxxxxx xx xxx `localFolder` xxxxxxxx. Xxx xxx xxxxx xxxx xxxxx xxxxx xxx xxxx xxxxxxxxx xx [Xxxxxxxx xxxxxxxxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/hh465109), xxx xx xxxxxxxxxxx xxx [Xxxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231478) xxx Xxxxxxx Y.Y xxx xx-xxxxx xxx xxxxxx xxxx xx xxxx Xxxxxxx YY xxx.

    2.  Xxx xxxxxxx, xxx xxx xxxxxxxx x xxxx xxxxxxxx xxxx xxxx xxx'x xxxxx xxxxxx xx xxxxx xx xxx XXX, xxxx xxxx:
        > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
        ```csharp
        using Windows.Storage;
        StorageFile file = await StorageFile.GetFileFromApplicationUriAsync("ms-appdata:///local/file.txt");
        ```
        ```javascript
        Windows.Storage.StorageFile.getFileFromApplicationUriAsync("ms-appdata:///local/file.txt").done(
            function(file) {
                // Process file
            }
        );
        ```

        Xxxx [**XxxXxxxXxxxXxxxxxxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701741) xxxxxxxxx, xx xxxxxxx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxx xxxxxxxxxx xxx *xxxx.xxx* xxxx xx xxx xxx'x xxxxx xxxxxx (`file` xx xxx xxxxxxx).

        Xxx "xx-xxxxxxx:///xxxxx/" xxxxxx xx xxx XXX xxxxxx xx xxx xxx'x xxxxx xxxxxx. Xx xxxxxx xxxxx xx xxx xxx'x xxxxxxx xx xxxxxxxxx xxxxxxx xxx "xx-xxxxxxx:///xxxxxxx/" xx "xx-xxxxxxx:///xxxxxxxxx/" xxxxxxx. Xxx xxx xxxxx xxxx xxxxx xxxxx xxx XXXx xx [Xxx xx xxxx xxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh781229).

    Xx xxxxxxxx, xxx xxxxxx xxxxx xxxxxxxxx, xxx xxx xxxx xxxxxx xxxxx xx xxxx xxx xxxx xxxxxxxxx xx xxxxx xxxx [XxxYY xxx XXX xxx XXX xxxx](https://msdn.microsoft.com/library/windows/apps/br205757) xxx xxxx X/X++ Xxxxxxxx Xxxxxxx xxxxxxxxx xxxx Xxxxxx Xxxxxx.

    Xxx xxx’x xxxxxx xxx xxxxx, xxxxxxx, xx xxxxxxxxx xxxxxxx xxxxxxx xxx xxxx xxxxxx.

-   **Xxxxxxxxx xxxxxxx.** Xxxxxxxxxxxx, xxxx xxx xxx xxxxxx xxxx xx xxx xxxxx xx xxxxxxxxx xxxxxxx xx xxxxxxx. Xxxx xx xx xxxxxx xx xxxx xxx xxxx xxx [XxxxXxxx xxxxxxxxx](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh464906.aspx#autoplay) xx xxxxxx xxxxxxxxxxxxx xxxx xxxxx xxxxxxx x xxxxxx, xxxx x xxxxxx xx XXX xxxxx xxxxx, xx xxxxx xxxxxx. Xxx xxxxx xxxx xxx xxx xxxxxx xxx xxxxxxx xx xxxxxxxx xxxx xxxxx xxxx xxx xxxxxxxxx xxx Xxxx Xxxx Xxxxxxxxxxx xxxxxxxxxxxx xx xxxx xxx xxxxxxxx.

    Xx xxxxxx, xxx xxx xxxx xxxx xxxxxx xx xxxxx xxx xxxxxxx xx x xxxxxxxxx xxxxxx xx xxxxxxx xxx xxxx xxxxxx (xxxxx [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207847) xxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207881)) xxx xxxxxxx xxx xxxx xxxx xxxxx xxx xxxxxxx xxx xxxx xxx xx xxxxxx. Xxxxx xxx xx xxx xxx xxxx xxxxxx xx [Xxxx xxxxx xxx xxxxxxx xxxx x xxxxxx](quickstart-using-file-and-folder-pickers.md).

    **Xxxx**  Xxx xxxx xxxx xxxxx xxxxxxxxx xx XX xxxx xxxx x xxxxxx xxx, xxx [Xxxxxx xxx XX xxxx](access-the-sd-card.md).

     

## Xxxxxxxxx Xxxxxxx Xxxxx xxxx xxx xxxxxx

-   **Xxxx’x Xxxxxxxxx xxxxxx.** Xxx xxxxxx xxxxx xxxxxxxxxx xxxxx xxx xxxxx xx xxxxxxx.

    Xx xxxxxxx, xxxx xxx xxx xxxx xxxxxx xxxxx xxx xxxxxxx xx xxx xxxx'x Xxxxxxxxx xxxxxx xxxx xxxx xxx xxxxxxx. Xxxxxxx, xxx xxx xxxx xxxxxx xx xxxxx xxx xxxxxxx xx xxx xxxx'x Xxxxxxxxx xxxxxx xx xxxxxxx x xxxx xxxxxx ([**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207847) xx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207881)) xx xxxx xxxxx xxx xxxxxxxx xxx xxxx xxxxx xx xxxxxxx xxx xxxx xxx xx xxxxxx.

    -   Xxx xxx xxxxxx x xxxx xx xxx xxxx'x Xxxxxxxxx xxxxxx xxxx xxxx:
        > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
        ```csharp
        using Windows.Storage;
        StorageFile newFile = await DownloadsFolder.CreateFileAsync("file.txt");
        ```
        ```javascript
        Windows.Storage.DownloadsFolder.createFileAsync("file.txt").done(
            function(newFile) {
                // Process file
            }
        );
        ```
 
        [
            **XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241632).[**XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh996761) xx xxxxxxxxxx xx xxxx xxx xxx xxxxxxx xxxx xxx xxxxxx xxxxxx xx xx xxxxx xx xxxxxxx xx xxxxxxxx xxxx xx xxx Xxxxxxxxx xxxxxx xxxx xxx xxx xxxx xxxx. Xxxx xxxxx xxxxxxx xxxxxxxx, xxxx xxxxxx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxx xxxxxxxxxx xxx xxxx xxxx xxx xxxxxxx. Xxxx xxxx xx xxxxxx `newFile` xx xxx xxxxxxx.

    -   Xxx xxx xxxxxx x xxxxxxxxx xx xxx xxxx'x Xxxxxxxxx xxxxxx xxxx xxxx:
        > [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
        ```csharp
        using Windows.Storage;
        StorageFolder newFolder = await DownloadsFolder.CreateFolderAsync("New Folder");
        ```
        ```javascript
        Windows.Storage.DownloadsFolder.createFolderAsync("New Folder").done(
            function(newFolder) {
                // Process folder
            }
        );
        ```
 
        [
            **XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241632).[**XxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh996763) xx xxxxxxxxxx xx xxxx xxx xxx xxxxxxx xxxx xxx xxxxxx xxxxxx xx xx xxxxx xx xxxxxxx xx xxxxxxxx xxxxxxxxx xx xxx Xxxxxxxxx xxxxxx xxxx xxx xxx xxxx xxxx. Xxxx xxxxx xxxxxxx xxxxxxxx, xxxx xxxxxx x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxx xxxxxxxxxx xxx xxxxxxxxx xxxx xxx xxxxxxx. Xxxx xxxx xx xxxxxx `newFolder` xx xxx xxxxxxx.

    Xx xxx xxxxxx x xxxx xx xxxxxx xx xxx Xxxxxxxxx xxxxxx, xx xxxxxxxxx xxxx xxx xxx xxxx xxxx xx xxxx xxx'x [**XxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207457) xx xxxx xxxx xxx xxx xxxxxxx xxxxxx xxxx xxxx xx xxx xxxxxx.

## Xxxxxxxxx xxxxxxxxxx xxxxxxxxx

Xx xxxxxxxx xx xxx xxxxxxx xxxxxxxxx, xx xxx xxx xxxxxx xxxxxxxxxx xxxxx xxx xxxxxxx xx xxxxxxxxx xxxxxxxxxxxx xx xxx xxx xxxxxxxx (xxx [Xxx xxxxxxxxxx xxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt270968)), xx xx xxxxxxx x xxxx xxxxxx xx xxx xxx xxxx xxxx xxxxx xxx xxxxxxx xxx xxx xxx xx xxxxxx (xxx [Xxxx xxxxx xxx xxxxxxx xxxx x xxxxxx](quickstart-using-file-and-folder-pickers.md)).

Xxx xxxxxxxxx xxxxx xxxxx xxxxxxxxxx xxxxxxxxx xxxx xxx xxx xxxxxx xx xxxxxxxxx x xxxxxxxxxx (xx xxxxxxxxxxxx) xxx xxxxx xxx xxxxxxxxxx [**Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227346) XXX:

| Xxxxxxxx | Xxxxxxxxxx | Xxxxxxx.Xxxxxxx XXX |
|----------|------------|---------------------|
| Xxxxxxxxx | XxxxxxxxxXxxxxxx <br><br>Xxxx: Xxx xxxx xxx Xxxx Xxxx Xxxxxxxxxxxx xx xxxx xxx xxxxxxxx xxxx xxxxxxx xxxxxxxx xxxx xxxxx xxxx xxxx xxx xxx xxxxxx xx xxxx xxxxxxxx. <br><br>Xxx xxxx xxxxxxxxxx xx xxxx xxx:<br>- Xxxxxxxxxxx xxxxx-xxxxxxxx xxxxxxx xxxxxx xx xxxxxxxx XxxXxxxx xxxxxxx xxxxx xxxxx XxxXxxxx XXXx xx Xxxxxxxx XXx<br>- Xxxxx xxxx xxxxx xx xxx xxxx’x XxxXxxxx xxxxxxxxxxxxx xxxxx xxxxxxx | [XxxxxXxxxxxx.XxxxxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br227152) |
| Xxxxx     | XxxxxXxxxxxx <br>Xxxx xxx [Xxxxx xxx xxxxxxx xx xxx Xxxxx, Xxxxxxxx, xxx Xxxxxx xxxxxxxxx](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md). | [XxxxxXxxxxxx.XxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br227155) |    
| Xxxxxxxx  | XxxxxxxxXxxxxxx<br> Xxxx xxx [Xxxxx xxx xxxxxxx xx xxx Xxxxx, Xxxxxxxx, xxx Xxxxxx xxxxxxxxx](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md). | [XxxxxXxxxxxx.XxxxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br227156) |  
| Xxxxxx    | XxxxxxXxxxxxx<br>Xxxx xxx [Xxxxx xxx xxxxxxx xx xxx Xxxxx, Xxxxxxxx, xxx Xxxxxx xxxxxxxxx](quickstart-managing-folders-in-the-music-pictures-and-videos-libraries.md). | [XxxxxXxxxxxx.XxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br227159) |   
| Xxxxxxxxx xxxxxxx  | XxxxxxxxxXxxxxxx <br><br>Xxxx  Xxx xxxx xxx Xxxx Xxxx Xxxxxxxxxxxx xx xxxx xxx xxxxxxxx xxxx xxxxxxx xxxxxxxx xxxx xxxxx xxxx xxxx xxx xxx xxxxxx xx xxxx xxxxxxxx. <br><br>Xxxx xxx [Xxxxxx xxx XX xxxx](access-the-sd-card.md). | [XxxxxXxxxxxx.XxxxxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br227158) |  
| Xxxxxxxxx xxxxxxxxx  | Xx xxxxx xxx xx xxx xxxxxxxxx xxxxxxxxxxxx xx xxxxxx. <br>- XxxxxXxxxxxx <br>- XxxxxxxxXxxxxxx <br>- XxxxxxXxxxxxx | [XxxxxXxxxxxx.XxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/br227153) |      
| Xxxxx xxxxxx xxxxxxx (XXXX) | Xx xxxxx xxx xx xxx xxxxxxxxx xxxxxxxxxxxx xx xxxxxx. <br>- XxxxxXxxxxxx <br>- XxxxxxxxXxxxxxx <br>- XxxxxxXxxxxxx | [XxxxxXxxxxxx.XxxxxXxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br227154) | 
| Xxxxxxxxx Xxxxxx Xxxxxxxxxx (XXX) xxxxxxx | X xxxxxxxxxxx xx xxx xxxxxxxxx xxxxxxxxxxxx xx xxxxxx. <br><br>Xxx xxxx xxx xxxx xxxxxxxx xxxxxxxxxx: <br>- XxxxxxxXxxxxxxXxxxxxXxxxxx <br><br>Xxx xx xxxxx xxx xxxxxxxx xxx xxxxxx xxxxxxxx xxxxxxxxxx: <br>- XxxxxxxxXxxxxx <br>- XxxxxxxxXxxxxxXxxxxx <br><br>Xxx, xx xxxxxxxxxx, xxx xxxxxx xxxxxxxxxxx xxxxxxxxxx:<br>- XxxxxxxxxxXxxxxxxxxxxxxx <br><br>Xxxx: Xxx xxxx xxx Xxxx Xxxx Xxxxxxxxxxxx xx xxxx xxx xxxxxxxx xxxx xxxxxxx xxxxxxxx xxxx xxxxx xxxx xxxx xxx xxx xxxxxx xx xxxx xxxxxxxx. | Xxxxxxxx x xxxxxx xxxxx: <br>[XxxxxxxXxxxxx.XxxXxxxxxXxxxXxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/br227278) <br><br>Xxxxxxxx x xxxx xxxxx: <br>[XxxxxxxXxxx.XxxXxxxXxxxXxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/br227206) |

<!--HONumber=Mar16_HO1-->
