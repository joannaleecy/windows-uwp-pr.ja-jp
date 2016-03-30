---
xx.xxxxxxx: YYYYYYYX-YYYX-YYYX-XYXX-YYYYXXYXXYYY
xxxxx: Xxxxxxxxxxx xxxxxxxxxxxx xx Xxxxxxxxx XxxXxxxx xxxxx
xxxxxxxxxxx: Xxxxxxxxx xx x Xxxxxxxxx XxxXxxxx xxxx xx xxxxxxxxx xxxxx xxx XxxxxxxXxxx.XxXxxxxxxxx xxxxxxxx.
---
# Xxxxxxxxxxx xxxxxxxxxxxx xx Xxxxxxxxx XxxXxxxx xxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


** Xxxxxxxxx XXXx **

-   [**XxxxXX xxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh701440)
-   [**XxxxxxxXxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/BR227171)
-   [**XxxxxxxXxxx.XxXxxxxxxxx xxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx)

Xxxxxxxxx xx x Xxxxxxxxx XxxXxxxx xxxx xx xxxxxxxxx xxxxx xxx [**XxxxxxxXxxx.XxXxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx) xxxxxxxx.

## Xxxxxxxxxxxxx

-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/Mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/Mt187334).

-   **Xxx xxxxxxxxx xxxxxxxxxxxx**

    Xxx [Xxxx xxxxxx xxxxxxxxxxx](file-access-permissions.md).

## Xxxxx xxx XxxxxxxXxxx.XxXxxxxxxxx xxxxxxxx

Xxxxx xxx xxxx xx xxxx XxxXxxxx xxxxx xx xxxxxx xxxxxxxxx-xxxxxxx (xxxxxxx) xx xxxxxx-xxxx. Xxxx xxxxxxxxxx xxxxxxx xxxxx xx xxxx xxxxx xxxxx (xxxx xx xxxxxxxx xxx xxxxxx) xx xxxxx XxxXxxxx, xxxx xxxx xx xxxxxx-xxxx, xxx xxxx xxxx xxxxx (xxx xxxx xxxxx xxxx xxxxxxx xx x xxxxxxxx xxxx).

[
            **XxxxxxxXxxx.XxXxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx), xx xxxx xx xxxxxxxxx xx x xxxx xx xxxxxxxxx xxxxxxxxx. Xxx xxxxxxxxx xxxxx xxxxx xxx xxxxx xx xxx **XxxxxxxXxxx.XxXxxxxxxxx** xxxxxxxx xx xxxxxxx xxxxxxxxx.

| Xxxx xx xxxx                              | Xxxxxx | Xxxxxxx xxxxxxx        | Xxxxxxx |
|-------------------------------------------|--------|------------------------|---------|
| Xxxxx xxxx                                | Xxxx   | Xxxx                   | Xxxx    |
| XxxXxxxx xxxx xxxxxx xx xxxxxxxxx-xxxxxxx | Xxxx   | Xxxx                   | Xxxx    |
| XxxXxxxx xxxx xxxxxx xx xxxxxx-xxxx       | Xxxx   | Xxxxx xx xxxx xxxxxxxx | Xxxxx   |
| Xxxxxxx xxxx                              | Xxxx   | Xxxxx xx xxxx xxxxxxxx | Xxxxx   |

 

Xxx xxxxxxxxx xxxxx xxxxxxxxxx xxx xx xxxxxxxxx xx x xxxx xx xxxxxxxxx xxxxxxxxx.

1.  Xxxxxxx x xxxxxxxxxx xxxxxxxxxxx xxx xxx xxxxxxx xxx xxxx xx xxxxxx.
2.  Xxxxxxx xxx [**Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR227346) xxxxxxxxx. Xxxx xxxxxxxxx xxxxxxxx xxx xxxxx xxx xxxxxxxx xxxxx, xxxxxxx, xxx xxxxxxxxxxx xxxxxxxx. Xx xxxx xxxxxxxx xxx xxxxxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR227171) xxxx.
3.  Xxxxxxx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR227171) xxxxxx xxx xxx xxxxxxx xxxx(x). Xx xxx xxx xxxxxxxxxxx x xxxxxxx, xxxx xxxx xx xxxxxxx xxxxxxxxxxxx xx xxxxxxx xxx [**XxxxxxxXxxxxx.XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR227252) xxxxxx xxx xxxx xxxxxxx xxx xxxxxxxxx [**XxxxxxxXxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208046) xxxxxx'x [**XxxXxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/br227276.aspx) xxxxxx. Xxx **XxxXxxxxXxxxx** xxxxxx xxxxxxx xx [XXxxxXxxxXxxx](http://go.microsoft.com/fwlink/p/?LinkId=324970) xxxxxxxxxx xx **XxxxxxxXxxx** xxxxxxx.
4.  Xxxx xxx xxxx xxx xxxxxx xx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR227171) xxxxxx xxxxxxxxxxxx xxx xxxxxxx xxxx(x), xxx xxxxx xx xxx [**XxxxxxxXxxx.XxXxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx) xxxxxxxx xxxxxxxx xxxxxxx xx xxx xxx xxxx xx xxxxxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxx xxxxxxxxxxx xxx xx xxxxxxxxx xxx xxxxxx xxx xxxxxx xxx xxxxxxxxxx xx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR227171) xxxxxxx xxx xxxx xxxxxx. Xxx xxxxxxx xxxxxx xxxx xxxxxxxx xxxx xxx xxxxxxxx xxxxxxxxxx xxxxxxxxxxx xxx [**XxxxxxxXxxx.XxXxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.storage.storagefile.isavailable.aspx) xxxxxxxx xxx xxxx xxxx.

```CSharp
/// <summary>
/// Generic function that retrieves all files from the specified folder.
/// </summary>
/// <param name="folder">The folder to be searched.</param>
/// <returns>An IReadOnlyList collection containing the file objects.</returns>
async Task<System.Collections.Generic.IReadOnlyList<StorageFile>> GetLibraryFilesAsync(StorageFolder folder)
{
    var query = folder.CreateFileQuery();
    return await query.GetFilesAsync();
}

...

private async void CheckAvailabilityOfFilesInPicturesLibrary()
{
    // Determine availability of all files within Pictures library.
    var files = await GetLibraryFilesAsync(KnownFolders.PicturesLibrary);
    for (int i = 0; i < files.Count; i++)
    {
        StorageFile file = files[i];

        StringBuilder fileInfo = new StringBuilder();
        fileInfo.AppendFormat("{0} (on {1}) is {2}", 
                    file.Name, 
                    file.Provider.DisplayName, 
                    file.IsAvailable ? "available" : "not available");
    }
}
```

 

 




<!--HONumber=Mar16_HO1-->
