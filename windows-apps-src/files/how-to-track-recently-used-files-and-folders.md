---
xx.xxxxxxx: XXYYYXYY-YXYY-YYYY-XXYY-XYYXYXYYYYYY
xxxxx: Xxxxx xxxxxxxx xxxx xxxxx xxx xxxxxxx
xxxxxxxxxxx: Xxxxx xxxxx xxxx xxxx xxxx xxxxxxxx xxxxxxxxxx xx xxxxxx xxxx xx xxxx xxx'x xxxx xxxxxxxx xxxx xxxx (XXX).
---
# Xxxxx xxxxxxxx xxxx xxxxx xxx xxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


** Xxxxxxxxx XXXx **

- [**XxxxXxxxxxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207458)
- [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh738369)

Xxxxx xxxxx xxxx xxxx xxxx xxxxxxxx xxxxxxxxxx xx xxxxxx xxxx xx xxxx xxx'x xxxx xxxxxxxx xxxx xxxx (XXX). Xxx xxxxxxxx xxxxxxx xxx XXX xxx xxx xx xxxxxxx xxxxx xxxxx xx xxxx xxxx xxxx xxxx xxxxxxxx, xxx xx xxxxxxxx xxx xxxxxx xxxx xxxx xxx xxxx'x YY-xxxx xxxxx xx xxxxxxx. Xxx xxxx xxxx xxxxx xxx XXX.

Xxxx xxx'x XXX xx xxxxxxxxxxx xx xxx [**XxxxxxxXxxxXxxxXxxxxxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207475) xxxxx, xxxxx xxx xxxxxx xxxx xxx xxxxxx [**XxxxxxxXxxxxxxxxxxXxxxxxxxxxx.XxxxXxxxxxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207458) xxxxxxxx. XXX xxxxx xxx xxxxxx xx [**XXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227129) xxxxxxx, xx xxxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxxx (xxxxx xxxxxxxxx xxxxx) xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxxxxx (xxxxx xxxxxxxxx xxxxxxx) xxx xx xxxxx xx xxx XXX.

**Xxxx**  Xxxx xxx xxx [Xxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619994) xxx xxx [Xxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619995).

 

## Xxxxxxxxxxxxx

-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

-   **Xxxxxx xxxxxxxxxxx xx xxx xxxxxxxx**

    Xxx [Xxxx xxxxxx xxxxxxxxxxx](file-access-permissions.md).

-   [Xxxx xxxxx xxx xxxxxxx xxxx x xxxxxx](quickstart-using-file-and-folder-pickers.md)

    Xxxxxx xxxxx xxx xxxxx xxx xxxx xxxxx xxxx xxxxx xxxxxx xx xxxxx xxx xxxxx.

 ## Xxx x xxxxxx xxxx xx xxx XXX

-   Xxx xxxxx xxxx xxxx xxxx xxxxx xxx xxxxx xxxxx xxxx xxxx xxxxxx xx xxxxxxxxxx. Xx xxxxxxxx xxxxxx xxxxxx xxxxx xx xxxx xxx'x XXX xx xxxx xx xxxx xxx xxxxxx. Xxxx'x xxx.

    ```CSharp
    ...
    
    Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();

    var mru = Windows.Storage.AccessCache.StorageApplicationPermissions.MostRecentlyUsedList;
    string mruToken = mru.Add(file, "profile pic");
    ```
    
    [
            **XxxxxxxXxxxXxxxXxxxxxxxXxxxXxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/br207476) xx xxxxxxxxxx. Xx xxx xxxxxxx, xx xxx [**Xxx(XXxxxxxxXxxx, Xxxxxx)**](https://msdn.microsoft.com/library/windows/apps/br207481) xx xxxx xx xxx xxxxxxxxx xxxxxxxx xxxx xxx xxxx. Xxxxxxx xxxxxxxx xxxx xxx xxxxxx xxx xxxx'x xxxxxxx, xxx xxxxxxx "xxxxxxx xxx". Xxx xxx xxxx xxx xxx xxxx xx xxx XXX xxxxxxx xxxxxxxx xx xxxxxxx [**Xxx(XXxxxxxxXxxx)**](https://msdn.microsoft.com/library/windows/apps/br207480). Xxxx xxx xxx xx xxxx xx xxx XXX, xxx xxxxxx xxxxxxx x xxxxxxxx xxxxxxxxxxx xxxxxx, xxxxxx x xxxxx, xxxxx xx xxxx xx xxxxxxxx xxx xxxx.

    **Xxx**   Xxx'xx xxxx xxx xxxxx xx xxxxxxxx xx xxxx xxxx xxx XXX, xx xxxxxxx xx xxxxxxxxx. Xxx xxxx xxxx xxxxx xxx xxxx, xxx [Xxxxxxxx xxxxxxxxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/hh465109).

     

## Xxx x xxxxx xx xxxxxxxx xx xxxx xxxx xxx XXX

Xxx xxx xxxxxxxxx xxxxxx xxxx xxxxxxxxxxx xxx xxx xxxx xxx xxxx xx xxxxxxxx.

-   Xxxxxxxx x xxxx xx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xx xxxxx [**XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br207486).
-   Xxxxxxxx x xxxxxx xx x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xx xxxxx [**XxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br207489).
-   Xxxxxxxx x xxxxxxx [**XXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227129), xxxxx xxx xxxxxxxxx xxxxxx x xxxx xx xxxxxx, xx xxxxx [**XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br207492).

Xxxx'x xxx xx xxx xxxx xxx xxxx xx xxxx xxxxx.

```csharp
StorageFile retrievedFile = await mru.GetFileAsync(mruToken);
```

Xxxx'x xxx xx xxxxxxx xxx xxx xxxxxxx xx xxx xxxxxx xxx xxxx xxxxx.

```csharp
foreach (Windows.Storage.AccessCache.AccessListEntry entry in mru.Entries)
{
    string mruToken = entry.Token;
    string mruMetadata = entry.Metadata;
    Windows.Storage.IStorageItem item = await mru.GetItemAsync(mruToken);
    // The type of item will tell you whether it's a file or a folder.
}
```

Xxx [**XxxxxxXxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227349) xxxx xxx xxxxxxx xxxxxxx xx xxx XXX. Xxxxx xxxxxxx xxx [**XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227348) xxxxxxxxxx xxxx xxxxxxx xxx xxxxx xxx xxxxxxxx xxx xx xxxx.

## Xxxxxxxx xxxxx xxxx xxx XXX xxxx xx'x xxxx

Xxxx xxx XXX'x YY-xxxx xxxxx xx xxxxxxx xxx xxx xxx xx xxx x xxx xxxx, xxx xxxx xxxx xxx xxxxxxxx xxx xxxxxxx xxxx xxx xx xxxxxxxxxxxxx xxxxxxx. Xx, xxx xxxxx xxxx xx xxxxxx xx xxxx xxxxxx xxx xxx x xxx xxx.

## Xxxxxx-xxxxxx xxxx

Xx xxxx xx xx XXX, xxxx xxx xxxx xxx x xxxxxx-xxxxxx xxxx. Xx xxxxxxx xxxxx xxx xxxxxxx, xxxx xxxx xxxxxx xxxx xxx xxxxxxxxxx xx xxxxxx xxxxx xxxx xxxxx xxx xx xxxxxxxxxx xxxxxxxxx. Xx xxx xxx xxxxx xxxxx xx xxxx xxxxxx-xxxxxx xxxx xxxx xxx'xx xxxxxx xxxx xxxxxxxxxx xxxx xxxx xxx xxxxx xx xxxxxx xxxxx xxxxx xxxxx xxxxx. Xxxx xxx'x xxxxxx-xxxxxx xxxx xx xxxxxxxxxxx xx xxx [**XxxxxxxXxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207459) xxxxx, xxxxx xxx xxxxxx xxxx xxx xxxxxx [**XxxxxxxXxxxxxxxxxxXxxxxxxxxxx.XxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207457) xxxxxxxx.

Xxxx x xxxx xxxxx xx xxxx, xxxxxxxx xxxxxx xx xx xxxx xxxxxx-xxxxxx xxxx xx xxxx xx xxxx XXX.

-   Xxx [**XxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207457) xxx xxxx xx xx YYYY xxxxx. Xxxxxxxx: xx xxx xxxx xxxxxxx xx xxxx xx xxxxx, xx xxxx'x x xxx xx xxxxxxx.
-   Xxx xxxxxxxx xxxxx xxxxxxx xxxxx xxxx xxx [**XxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207457) xxx xxx. Xxxx xxx xxxxx xxx YYYY-xxxx xxxxx, xxx xxx'x xxx xxxxxxx xxxxx xxx xxxx xxxx xxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207497) xxxxxx.

 

 




<!--HONumber=Mar16_HO1-->
