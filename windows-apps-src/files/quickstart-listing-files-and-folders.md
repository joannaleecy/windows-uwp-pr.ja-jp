---
xx.xxxxxxx: YXYYXYXX-YYXY-YYYY-XYYY-XYXYYYYYXYXX
xxxxx: Xxxxxxxxx xxx xxxxx xxxxx xxx xxxxxxx
xxxxxxxxxxx: Xxxxxx xxxxx xxx xxxxxxx xx xxxxxx x xxxxxx, xxxxxxx, xxxxxx, xx xxxxxxx xxxxxxxx. Xxx xxx xxxx xxxxx xxx xxxxx xxx xxxxxxx xx x xxxxxxxx xx xxxxxxxxxxxx xxxx xxx xxxxxx xxxxxxx.
---
# Xxxxxxxxx xxx xxxxx xxxxx xxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxx xxxxx xxx xxxxxxx xx xxxxxx x xxxxxx, xxxxxxx, xxxxxx, xx xxxxxxx xxxxxxxx. Xxx xxx xxxx xxxxx xxx xxxxx xxx xxxxxxx xx x xxxxxxxx xx xxxxxxxxxxxx xxxx xxx xxxxxx xxxxxxx.

**Xxxx**  Xxxx xxx xxx [Xxxxxx xxxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619993).

 
## Xxxxxxxxxxxxx

-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

-   **Xxxxxx xxxxxxxxxxx xx xxx xxxxxxxx**

    Xxx xxxxxxx, xxx xxxx xx xxxxx xxxxxxxx xxxxxxx xxx **xxxxxxxxXxxxxxx** xxxxxxxxxx, xxx xxxx xxxxxxxx xxx xxxxxxx x xxxxxxxxx xxxxxxxxxx xx xx xxxxxxxxxx xx xxx. Xx xxxxx xxxx, xxx [Xxxx xxxxxx xxxxxxxxxxx](file-access-permissions.md).

## Xxxxxxxxx xxxxx xxx xxxxxxx xx x xxxxxxxx

> **Xxxx**  Xxxxxxxx xx xxxxxxx xxx **xxxxxxxxXxxxxxx** xxxxxxxxxx.

Xx xxxx xxxxxxx xx xxxxx xxx xxx [**XxxxxxxXxxxxx.XxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227276) xxxxxx xx xxx xxx xxx xxxxx xx xxx xxxx xxxxxx xx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227156) (xxx xx xxxxxxxxxx) xxx xxxx xxx xxxx xx xxxx xxxx. Xxxx, xx xxx xxx [**XxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227280) xxxxxx xx xxx xxx xxx xxxxxxxxxx xx xxx **XxxxxxxxXxxxxxx** xxx xxxx xxx xxxx xx xxxx xxxxxxxxx.

<!--BUGBUG: IAsyncOperation<IVectorView<StorageFolder^>^>^  causes build to flake out-->
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"] 
> ```cpp
> //#include <ppltasks.h>
> //#xxxxxxx <string>
> //#xxxxxxx <memory>
> xxxxx xxxxxxxxx Xxxxxxx::Xxxxxxx;
> xxxxx xxxxxxxxx Xxxxxxxx::Xxxxxxxxxxs;
> xxxxx xxxxxxxxx xxxxxxxxnxx;
> xxxxx xxxxxxxxx xxx;
> 
> // Xx xxxx xx xxxxxxx xxx Xxxxxxxx Xxxxxx xxxxxxxxxx xx xxx xxxxxxxxxxxx xxxx.
> XxxxxxxXxxxxx^ xxxxxxxxXxxxxx = XxxxxXxxxxxx::XxxxxxxxXxxxxxx;
> 
> // Xxx x xxxxxx_xxx xx xxxx xxx xxxxxx xxxxx xx xxxxxx
> // xxxxx xxx xxxx xxxx xx xxxxxxxe.
> xxxx xxxxxxXxxxxx = xxxx_xxared<wstring>();
> *xxxxxxXxxxxx += X"Xxxxx:\x";
> 
> // Xxx x xxxx-xxxx xxxxxx xx xxx xxxx xxxxxxx
> // xxx xxxx xx xx xxx xxxxxxxxxxxn. 
> xxxxxx_xxxx(xxxxxxxxXxxxxx->XxxXxxxxXxxxc())        
>     // xxxxxxXxxxxx xx xxxxxxxx xx xxxxx, xxxxx xxxxxxx a copy 
>     // xx xxx xxxxxx_xxx xxx xxxxxxxxxx xxx xxxxxxxxe couxx.
>     .xxxx ([xxxxxxXxxxxx] (XXectorView\<StorageFile^>^ xxxxx)
> {        
>     xxx ( xxxxxxxx xxx x = Y ; x < xxxxx->Xxxx; x++)
>     {
>         *xxxxxxXxxxxx += xxxxx->XxxXx(x)->Xxxx->Xxxx();
>         *xxxxxxXxxxxx += X"\x";
>     }
> })
>     // Xx xxxx xx xxxxxxxxxx xxxxx xxx xxxxxx xxpe 
>     // xxxx: -> XXxxxxXxxxxtion<...>
>     .then([picturesFolder]() -> IAsyncOperation\<IVectorView\<StorageFolder^>^>^ 
> {
>     xxxxxx xxxxxxxxXxxxxx->XxxXxxxxxxXxxxx();
> })
>     // Xxxxxxx "xxxx" xx xxxxxx x_XxxxxxXxxxXxxxx xxxx xxxxxx xxx xambda.
>     .xxxx([xxxx, xxxxxxXxxxxx](XXxxtorView\<StorageFolder^>^ xxxxxxx)
> {        
>     *xxxxxxXxxxxx += X"Xxxxxxx:\x";
> 
>     xxx ( xxxxxxxx xxx x = Y; x < xxxxxxx->Xxxx; x++)
>     {
>         *xxxxxxXxxxxx += xxxxxxx->XxxXx(x)->Xxxx->Xxxx();
>         *xxxxxxXxxxxx += X"\x";
>     }
> 
>     // Xxxxxx x_XxxxxxXxxxXxxxx xx x XxxxXxxxx xxxxxxx xx xxx XXXX.
>     x_XxxxxxXxxxXxxxx->Xxxx = xxx xxx Xxxxxx((*xxxxxxXxxxxx).x_xxx());
> });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
> StringBuilder outputText = new StringBuilder();
> 
> IReadOnlyList<StorageFile> xxxxXxxx = 
>     xxxxx xxxxxxxxXxxxxx.XxxXxxxxXxxxx();
> 
> xxxxxxXxxx.XxxxxxXxxx("Xxxxx:");
> xxxxxxx (XxxxxxxXxxx xxxx xx xxxxXxxt)
> {
>     xxxxxxXxxx.Xxxxxx(xxxx.Xxxx + "\x");
> }
> 
> XXxxxXxxxXxxx<StorageFolder> xxxxxxXxxx = 
>     xxxxx xxxxxxxxXxxxxx.XxxXxxxxxxXxxxx();
>            
> xxxxxxXxxx.XxxxxxXxxx("Xxxxxxx:");
> xxxxxxx (XxxxxxxXxxxxx xxxxxx xx xxxxxxXxxt)
> {
>     xxxxxxXxxx.Xxxxxx(xxxxxx.XxxxxxxXxxx + "\n");
> }
> ```
> ```vb
> Dim picturesFolder As StorageFolder = KnownFolders.PicturesLibrary
> Dim outputText As New StringBuilder
> 
> Dim fileList As IReadOnlyList(Of StorageFile) =
>     Await picturesFolder.GetFilesAsync()
> 
> outputText.AppendLine("Files:")
> For Each file As StorageFile In fileList
> 
>     outputText.Append(file.Name & vbLf)
> 
> Next file
> 
> Dim folderList As IReadOnlyList(Of StorageFolder) =
>     Await picturesFolder.GetFoldersAsync()
> 
> outputText.AppendLine("Folders:")
> For Each folder As StorageFolder In folderList
> 
>     outputText.Append(folder.DisplayName & vbLf)
> 
> Next folder
> ```


> **Xxxx**  Xx X\# xx Xxxxxx Xxxxx, xxxxxxxx xx xxx xxx **xxxxx** xxxxxxx xx xxx xxxxxx xxxxxxxxxxx xx xxx xxxxxx xx xxxxx xxx xxx xxx **xxxxx** xxxxxxxx.
 

Xxxxxxxxxxxxx, xxx xxx xxx xxx [**XxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227286) xxxxxx xx xxx xxx xxxxx (xxxx xxxxx xxx xxxxxxxxxx) xx x xxxxxxxxxx xxxxxxxx. Xxx xxxxxxxxx xxxxxxx xxxx xxx **XxxXxxxxXxxxx** xxxxxx xx xxx xxx xxxxx xxx xxxxxxxxxx xx xxx xxxx xxxxxx xx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227156) (xxx xx xxxxxxxxxx). Xxxx xxx xxxxxxx xxxxx xxx xxxx xx xxxx xxxx xxx xxxxxxxxx. Xx xxx xxxx xx x xxxxxxxxx, xxx xxxxxxx xxxxxxx `"folder"` xx xxx xxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"] 
> ```cpp
> // See previous example for comments, namespace and #include info.
> StorageFolder^ picturesFolder = KnownFolders::PicturesLibrary;
> auto outputString = make_shared<wstring>();
> 
> xxxxxx_xxxx(xxxxxxxxXxxxxx->XxxXxxxxXxxxx())        
>     .xxxx ([xxxx, xxxxxxXxxxxx] (XXxxxxxXxew<IStorageItem^>^ xxxxx)
> {        
>     xxx ( xxxxxxxx xxx x = Y ; x < xxxxx->Xxxx; x++)
>     {
>         *xxxxxxXxxxxx += xxxxx->XxxXx(x)->Xxxx->Xxxx();
>         xx(xxxxx->XxxXx(x)->XxXxXxxx(XxxxxxxXxxxXxxxx::Xxxxxx))
>         {
>             *xxxxxxXxxxxx += X"  xxxxxx\x";
>         }
>         xxxx
>         {
>             *xxxxxxXxxxxx += X"\x";
>         }
>         x_XxxxxxXxxxXxxxx->Xxxx = xxx xxx Xxxxxx((*xxxxxxXxxxxx).x_xxx());
>     }
> });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
> StringBuilder outputText = new StringBuilder();
> 
> IReadOnlyList<IStorageItem> xxxxxXxxx = 
>     xxxxx xxxxxxxxXxxxxx.XxxXxxxxXxxxx();
> 
> xxxxxxx (xxx xxxx xx xxxxxXxxx)
> {
>     xx (xxxx xx XxxxxxxXxxder)
>     {
>         xxxxxxXxxx.Xxxxxx(xxxx.Xxxx + " xxxxxx\x");
> 
>     }
>     xxxx
>     {
>         xxxxxxXxxx.Xxxxxx(xxxx.Xxxx + "\x");
> 
>     }
> }
> ```
> ```xx
> Xxx xxxxxxxxXxxxxx Xx XxxxxxxXxxxxx = XxxxxXxxxxxx.XxxxxxxxXxxxxxx
> Xxx xxxxxxXxxx Xx Xxx XxxxxxXxxxxxx
> 
> Xxx xxxxxXxxx Xx XXxxxXxxxXxxx(Xx XXxxxxxxXxxx) =
>     Xxxxx xxxxxxxxXxxxxx.XxxXxxxxXxxxx()
> 
> Xxx Xxxx xxxx Xx xxxxxXxxx
> 
>     Xx XxxxXx xxxx Xx XxxxxxxXxxxxx Xxxx
> 
>         xxxxxxXxxx.Xxxxxx(xxxx.Xxxx & " xxxxxx" & xxXx)
> 
>     Xxxx
> 
>         xxxxxxXxxx.Xxxxxx(xxxx.Xxxx & xxXx)
> 
>     Xxx Xx
> 
> Xxxx xxxx
> ```

## Xxxxx xxxxx xx x xxxxxxxx xxx xxxxxxxxx xxxxxxxx xxxxx

Xx xxxx xxxxxxx xx xxxxx xxx xxx xxx xxxxx xx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227156) xxxxxxx xx xxx xxxxx, xxx xxxx xxxx xxx xxxxxxx xxxxxxxx xxxx xxxxxxxxxx. Xxxxx, xx xxxx [**XxxxxxxXxxxxx.XxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227262) xxx xxxx xxx [**XxxxxxXxxxxxXxxxx.XxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br207957) xxxxx xx xxx xxxxxx. Xxxx xxxxx xx x [**XxxxxxxXxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208066) xxxxxx.

Xxxx xx xxxx [**XxxxxxxXxxxxxXxxxxXxxxxx.XxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br208074) xxxxx xxxxxxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxxxxx xxxxxxxxxxxx xxxxxxx xxxxxxx. Xx xxxx xxxx xx'xx xxxxxxxx xx xxxxx, xx xxx xxxxxxx xxxxxxx xxxx xxxxxxxxx x xxxxx xx xxxxx xxxx xxx xxxx xxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"] 
> ```cpp
> //#include <ppltasks.h>
> //#xxxxxxx <string>
> //#xxxxxxx <memory>
> xxxxx xxxxxxxxx Xxxxxxx::Xxxxxxx;
> xxxxx xxxxxxxxx Xxxxxxx::Xxxxxxx::Xxxxxh;
> xxxxx xxxxxxxxx xxxxxxxxnxx;
> xxxxx xxxxxxxxx Xxxxxxxx::Xxxxxxtxxxx;
> xxxxx xxxxxxxxx Xxxxxxx::Xxxxxxxxxx::Xxxxexxxxxx;
> xxxxx xxxxxxxxx xxx;
> 
> XxxxxxxXxxxxx^ xxxxxxxxXxxxxx = XxxxxXxxxxxx::XxxxxxxxXxxxxxx;
> 
> XxxxxxxXxxxxxXxxxxXxxxxx^ xxxxxXxxxxx = 
>     xxxxxxxxXxxxxx->XxxxxxXxxxxxXxxxx(XxxxxxXxxxxxXxxxx::XxxxxXxXxxxx);
> 
> // Xxx xxxxxx_xxx xx xxxx xxxxxxXxxxxx xxxxxxx xx xxxxxx
> // xxxxx xxx xxxx xxxxxxxxx, xxxxx xx xxxxx xxx xxxxxxxx xxxx xxx xx xxxxe.
> xxxx xxxxxxXxxxxx = xxx::xxxx_xxared<wstring>();
> 
> xxxxxx_xxxx( xxxxxXxxxxx->XxxXxxxxxxXxxxx()).xxxx([xxxx, xxxxxxXxxxxx] (XXxxxxxXxxx<StorageFolder^>^ xxxx) 
> {        
>     xxx ( xxxxxxxx xxx x = Y; x < xxxx->Xxxx; x++)
>     {
>         create_task(view->GetAt(i)->GetFilesAsync()).then([this, i, view, outputString](IVectorView<StorageFile^>^ xxxxx)
>         {
>             *xxxxxxXxxxxx += xxxx->XxxXx(x)->Xxxx->Xxxx();
>             *xxxxxxXxxxxx += X"(";
>             *xxxxxxXxxxxx += xx_xxxxxxx(xxxxx->Xxxx);
>             *xxxxxxXxxxxx += X")\x\x";
>             xxx (xxxxxxxx xxx x = Y; x < xxxxx->Xxxx; x++)
>             {
>                 *xxxxxxXxxxxx += X"     ";
>                 *xxxxxxXxxxxx += xxxxx->XxxXx(x)->Xxxx->Xxxx();
>                 *xxxxxxXxxxxx += X"\x\x";
>             }
>         }).xxxx([xxxx, xxxxxxXxxxxx]()
>         {
>             x_XxxxxxXxxxXxxxx->Xxxx = xxx xxx Xxxxxx((*xxxxxxXxxxxx).x_xxx());
>         });
>     }    
> });
> ```
> ```cs
> StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
> 
> StorageFolderQueryResult queryResult = 
>     picturesFolder.CreateFolderQuery(CommonFolderQuery.GroupByMonth);
>         
> IReadOnlyList<StorageFolder> xxxxxxXxxx = 
>     xxxxx xxxxxXxxxxx.XxxXxxxxxxXxxxx();
> 
> XxxxxxXxxxxxx xxxxxxXxxx = xxx XxxxxxXxxxxxx();
> 
> xxxxxxx (XxxxxxxXxxxxx xxxxxx xx xxxxxxXxxx)
> {
>     XXxxxXxxxList<StorageFile> xxxxXxxx = xxxxx xxxxxx.XxxXxxxxXxxxx();
> 
>     // Xxxxx xxx xxxxx xxx xxxxxx xx xxxxx xx xxxx xxxxx.
>     xxxxxxXxxx.XxxxxxXxxx(xxxxxx.Xxxx + " (" + xxxxXxxx.Xxxxx + ")");
> 
>     xxxxxxx (XxxxxxxXxxx xxxx xx xxxxXxxx)
>     {
>         // Xxxxx xxx xxxx xx xxx xxxx.
>         xxxxxxXxxx.XxxxxxXxxx("   " + xxxx.Xxxx);
>     }
> }
> ```
> ```xx
> Xxx xxxxxxxxXxxxxx Xx XxxxxxxXxxxxx = XxxxxXxxxxxx.XxxxxxxxXxxxxxx
> Xxx xxxxxxXxxx Xx Xxx XxxxxxXxxxxxx
> 
> Xxx xxxxxXxxxxx Xx XxxxxxxXxxxxxXxxxxXxxxxx =
>     xxxxxxxxXxxxxx.XxxxxxXxxxxxXxxxx(XxxxxxXxxxxxXxxxx.XxxxxXxXxxxx)
> 
> Xxx xxxxxxXxxx Xx XXxxxXxxxXxxx(Xx XxxxxxxXxxxxx) =
>     Xxxxx xxxxxXxxxxx.XxxXxxxxxxXxxxx()
> 
> Xxx Xxxx xxxxxx Xx XxxxxxxXxxxxx Xx xxxxxxXxxx
> 
>     Xxx xxxxXxxx Xx XXxxxXxxxXxxx(Xx XxxxxxxXxxx) =
>         Xxxxx xxxxxx.XxxXxxxxXxxxx()
> 
>     ' Xxxxx xxx xxxxx xxx xxxxxx xx xxxxx xx xxxx xxxxx.
>     xxxxxxXxxx.XxxxxxXxxx(xxxxxx.Xxxx & " (" & xxxxXxxx.Xxxxx & ")")
> 
>     Xxx Xxxx xxxx Xx XxxxxxxXxxx Xx xxxxXxxx
> 
>         ' Xxxxx xxx xxxx xx xxx xxxx.
>         xxxxxxXxxx.XxxxxxXxxx("   " & xxxx.Xxxx)
> 
>     Xxxx xxxx
> 
> Xxxx xxxxxx
> ```

Xxx xxxxxx xx xxx xxxxxxx xxxxx xxxxxxx xx xxx xxxxxxxxx.

``` syntax
July ‎2015 (2)
   MyImage3.png
   MyImage4.png
‎December ‎2014 (2)
   MyImage1.png
   MyImage2.png
```

<!--HONumber=Mar16_HO1-->
