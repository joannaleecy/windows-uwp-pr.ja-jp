---
xx.xxxxxxx: XXYYXYYY-YXXX-YYYY-YYXY-YXXXXYXYXYYX
xxxxx: Xxx xxxx xxxxxxxxxx
xxxxxxxxxxx: Xxx xxxxxxxxxx&\#YYYY;xxx-xxxxx, xxxxx, xxx xxxxxxxx&\#YYYY;xxx x xxxx xxxxxxxxxxx xx x XxxxxxxXxxx xxxxxx.
---
# Xxx xxxx xxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


** Xxxxxxxxx XXXx **

-   [**XxxxxxxXxxx.XxxXxxxxXxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701737)
-   [**XxxxxxxXxxx.Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227225)
-   [**XxxxxxxXxxxXxxxxxxXxxxxxxxxx.XxxxxxxxXxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh770652)

Xxx xxxxxxxxxx—xxx-xxxxx, xxxxx, xxx xxxxxxxx—xxx x xxxx xxxxxxxxxxx xx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxx.

**Xxxx**  Xxxx xxx xxx [Xxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619995).

 


## Xxxxxxxxxxxxx

-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

-   **Xxxxxx xxxxxxxxxxx xx xxx xxxxxxxx**

    Xxx xxxxxxx, xxx xxxx xx xxxxx xxxxxxxx xxxxxxx xxx **xxxxxxxxXxxxxxx** xxxxxxxxxx, xxx xxxx xxxxxxxx xxx xxxxxxx x xxxxxxxxx xxxxxxxxxx xx xx xxxxxxxxxx xx xxx. Xx xxxxx xxxx, xxx [Xxxx xxxxxx xxxxxxxxxxx](file-access-permissions.md).

## Xxxxxxx x xxxx'x xxx-xxxxx xxxxxxxxxx

Xxxx xxx-xxxxx xxxx xxxxxxxxxx xxx xxxxxxxxxx xx xxxxxxx xx xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxx. Xxxxx xxxxxxxxxx xxxxxxx xxx xxxxx xxxxxxxxxx, xxxxxxx xxxx, xxxxxxxx xxxx, xxxxxxx xxxx, xxxx xxxx, xxx xx xx.

**Xxxx**  Xxxxxxxx xx xxxxxxx xxx **xxxxxxxxXxxxxxx** xxxxxxxxxx.

 

Xxxx xxxxxxx xxxxxxxxxx xxx xx xxx xxxxx xx xxx Xxxxxxxx xxxxxxx, xxxxxxxxx x xxx xx xxxx xxxx'x xxx-xxxxx xxxxxxxxxx.

```csharp
// Enumerate all files in the Pictures library.
var folder = Windows.Storage.KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Get top-level file properties.
    fileProperties.AppendLine("File name: " + file.Name);
    fileProperties.AppendLine("File type: " + file.FileType);
}
```

## Xxxxxxx x xxxx'x xxxxx xxxxxxxxxx

Xxxx xxxxx xxxx xxxxxxxxxx xxx xxxxxxxx xx xxxxx xxxxxxx xxx [**XxxxxxxXxxx.XxxXxxxxXxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701737) xxxxxx. Xxxx xxxxxx xxxxxxx x [**XxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br212113) xxxxxx, xxxxx xxxxxxx xxxxxxxxxx xxx xxx xxxx xx xxx xxxx (xxxx xx xxxxxx) xx xxxx xx xxxx xxx xxxx xxx xxxx xxxxxxxx.

Xxxx xxxxxxx xxxxxxxxxx xxx xx xxx xxxxx xx xxx Xxxxxxxx xxxxxxx, xxxxxxxxx x xxx xx xxxx xxxx'x xxxxx xxxxxxxxxx.

```csharp
// Enumerate all files in the Pictures library.
var folder = Windows.Storage.KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Get file's basic properties.
    Windows.Storage.FileProperties.BasicProperties basicProperties = 
        await file.GetBasicPropertiesAsync();
    string fileSize = string.Format("{0:n0}", basicProperties.Size);
    fileProperties.AppendLine("File size: " + fileSize + " bytes");
    fileProperties.AppendLine("Date modified: " + basicProperties.DateModified);
}
 ```
 
## Xxxxxxx x xxxx'x xxxxxxxx xxxxxxxxxx

Xxxxx xxxx xxx xxx-xxxxx xxx xxxxx xxxx xxxxxxxxxx, xxxxx xxx xxxx xxxxxxxxxx xxxxxxxxxx xxxx xxx xxxx'x xxxxxxxx. Xxxxx xxxxxxxx xxxxxxxxxx xxx xxxxxxxx xx xxxxxxx xxx [**XxxxxXxxxxxxxxx.XxxxxxxxXxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br212124) xxxxxx. (X [**XxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br212113) xxxxxx xx xxxxxxxx xx xxxxxxx xxx [**XxxxxxxXxxx.Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227225) xxxxxxxx.) Xxxxx xxx-xxxxx xxx xxxxx xxxx xxxxxxxxxx xxx xxxxxxxxxx xx xxxxxxxxxx xx x xxxxx—[**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxx **XxxxxXxxxxxxxxx**, xxxxxxxxxxxx—xxxxxxxx xxxxxxxxxx xxx xxxxxxxx xx xxxxxxx xx [XXxxxxxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=313091) xxxxxxxxxx xx [Xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=325032) xxxxxxx xxxxxxxxxxxx xxx xxxxx xx xxx xxxxxxxxxx xxxx xxx xx xx xxxxxxxxx xx xxx **XxxxxXxxxxxxxxx.XxxxxxxxXxxxxxxxxxXxxxx** xxxxxx. Xxxx xxxxxx xxxx xxxxxxx xx [XXxxxxxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=325238) xxxxxxxxxx. Xxxx xxxxxxxx xxxxxxxx xx xxxx xxxxxxxxx xxxx xxx xxxxxxxxxx xx xxxx xx xx xxxxx.

Xxxx xxxxxxx xxxxxxxxxx xxx xx xxx xxxxx xx xxx Xxxxxxxx xxxxxxx, xxxxxxxxx xxx xxxxx xx xxxxxxx xxxxxxxxxx (**XxxxXxxxxxxx** xxx **XxxxXxxxx**) xx x [Xxxx](http://go.microsoft.com/fwlink/p/?LinkID=325246) xxxxxx, xxxxxx xxxx [Xxxx](http://go.microsoft.com/fwlink/p/?LinkID=325246) xxxxxx xx [**XxxxxXxxxxxxxxx.XxxxxxxxXxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br212124) xx xxxxxxxx xxxxx xxxxxxxxxx, xxx xxxx xxxxxxxxx xxxxx xxxxxxxxxx xx xxxx xxxx xxx xxxxxxxx [XXxxxxxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=325238) xxxxxx.

```csharp
const string dateAccessedProperty = "System.DateAccessed";
const string fileOwnerProperty = "System.FileOwner";

// Enumerate all files in the Pictures library.
var folder = KnownFolders.PicturesLibrary;
var query = folder.CreateFileQuery();
var files = await query.GetFilesAsync();

foreach (Windows.Storage.StorageFile file in files)
{
    StringBuilder fileProperties = new StringBuilder();

    // Define property names to be retrieved.
    var propertyNames = new List<string>();
    propertyNames.Add(dateAccessedProperty);
    propertyNames.Add(fileOwnerProperty);

    // Get extended properties.
    IDictionary<string, object> extraProperties = 
        await file.Properties.RetrievePropertiesAsync(propertyNames);

    // Get date-accessed property.
    var propValue = extraProperties[dateAccessedProperty];
    if (propValue != null)
    {
        fileProperties.AppendLine("Date accessed: " + propValue);
    }

    // Get file-owner property.
    propValue = extraProperties[fileOwnerProperty];
    if (propValue != null)
    {
        fileProperties.AppendLine("File owner: " + propValue);
    }
}
```

 

 




<!--HONumber=Mar16_HO1-->
