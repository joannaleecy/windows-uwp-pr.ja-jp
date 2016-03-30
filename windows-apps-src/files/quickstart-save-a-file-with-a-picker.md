---
xx.xxxxxxx: YXXXXYYX-YYXY-YXYX-XYXY-XYXYYYXXXYYY
xxxxx: Xxxx x xxxx xxxx x xxxxxx
xxxxxxxxxxx: Xxx XxxxXxxxXxxxxx xx xxx xxxxx xxxxxxx xxx xxxx xxx xxxxxxxx xxxxx xxxx xxxx xxxx xxx xx xxxx x xxxx.
---

# Xxxx x xxxx xxxx x xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207871)
-   [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171)

Xxx [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207871) xx xxx xxxxx xxxxxxx xxx xxxx xxx xxxxxxxx xxxxx xxxx xxxx xxxx xxx xx xxxx x xxxx.

> **Xxxx**  Xxxx xxx xxx [Xxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619994).

 

## Xxxxxxxxxxxxx


-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

-   **Xxxxxx xxxxxxxxxxx xx xxx xxxxxxxx**

    Xxx [Xxxx xxxxxx xxxxxxxxxxx](file-access-permissions.md).

## XxxxXxxxXxxxxx: xxxx-xx-xxxx


Xxx x [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207871) xx xxxx xxxx xxxxx xxx xxxxxxx xxx xxxx, xxxx, xxx xxxxxxxx xx x xxxx xx xxxx. Xxxxxx, xxxxxxxxx, xxx xxxx x xxxx xxxxxx xxxxxx, xxx xxxx xxxx xxxx xxx xxx xxxxxxxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxx xxxx xxxxxxxxxx xxx xxxx xxxxxx.

1.  **Xxxxxx xxx xxxxxxxxx xxx XxxxXxxxXxxxxx**

```cs
var savePicker = new Windows.Storage.Pickers.FileSavePicker();
savePicker.SuggestedStartLocation = 
    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
// Dropdown of file types the user can save the file as
savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
// Default file name if the user does not type one in or select a file to replace
savePicker.SuggestedFileName = "New Document";
```

Xxx xxxxxxxxxx xx xxx xxxx xxxxxx xxxxxx xxxx xxx xxxxxxxx xx xxxx xxxxx xxx xxxx xxx. Xxx xxxxxxxxxx xx xxxx xxx xxxxxx xxx xx xxxxxxxxx xxx xxxx xxxxxx, xxx [Xxxxxxxxxx xxx xxxxxxxxx xxx xxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465182).

Xxxx xxxxxxx xxxx xxxxx xxxxxxxxxx: [**XxxxxxxxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207880), [**XxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207875) xxx [**XxxxxxxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207878).

> **Xxxx**[**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207871) xxxxxxx xxxxxxx xxx xxxx xxxxxx xxxxx xxx [**XxxxxxXxxxXxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/br207891).

     
- Xxxxxxx xxx xxxx xx xxxxxx x xxxxxxxx xx xxxx xxxx, xxx xxxxxx xxxx [**XxxxxxxxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207880) xx xxx xxx'x xxxxx xxxxxx xx xxxxx [**XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241621). Xxx [**XxxxxxxxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207854) xx x xxxxxxxx xxxxxxxxxxx xxx xxx xxxx xx xxxx xxxxx xxxxx, xxx xxxxxxx Xxxxx, Xxxxxxxx, Xxxxxx, xx Xxxxxxxxx. Xxxx xxx xxxxx xxxxxxxx, xxx xxxx xxx xxxxxxxx xx xxxxx xxxxxxxxx.
 
- Xxxxxxx xx xxxx xx xxxx xxxx xxx xxx xxx xxxx xxx xxxx xxxxx xx xx xxxxx, xx xxx [**XxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207875) xx xxxxxxx xxxx xxxxx xxxx xxx xxxxxx xxxxxxxx (Xxxxxxxxx Xxxx xxxxxxxxx xxx xxxx xxxxx). Xxxx xxxx xxx xxx xxxx xxxxx xxxx xxx xxxxxxx xxx xxxxxxxxx xx xxxx xxx. Xxxxx xxxx xx xxxx xx xxxx xxxxx xxxx xx xxx xx xxx xxxx xxxxx xxx xxxxxxx. Xxxx xxx xxxx xxxxxx xxx xxxx xxxx xx xxxxxxxxx xxxxxxx xx xxx xxxx xxxxx xxxx xxx xxxxxxxxx. Xxx xxxxx xxxx xxxx xxxxxx xx xxx xxxx xxxx xx xxxxxxxx xx xxxxxxx: xx xxxxxxx xxxx, xxx xxx [**XxxxxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207873) xxxxxxxx.

> **Xxxx**  Xxx xxxx xxxxxx xxxx xxxx xxx xxxxxxxxx xxxxxxxx xxxx xxxx xx xxxxxx xxxxx xxxxx xx xxxxxxxx, xx xxxx xxxx xxxx xxxxx xxxx xxxxx xxx xxxxxxxx xxxxx xxxxx xxx xxxxxxxxx xx xxx xxxx.

- Xx xxxx xxx xxxx xxxx xxxxxx, xxx xxxxxxx xxxx x [**XxxxxxxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207878). Xxxx xxxx xxxxxxxxx xxxx xxxx xxxxxxxx xx xxx xxxx xxxxx xxxxx. Xxx xxxxxxx, xxxx Xxxx, xxx xxx xxxxxxx xxx xxxxxxxx xxxx xxxx xx xxxxx xx xxx, xx xxx xxxxx xxxx xx x xxxxxxxx xx xxx xxxx xx xxxxxx x xxxx xxxx xxxx xxx xxx xxxx x xxxx.

2.  **Xxxx xxx XxxxXxxxXxxxxx xxx xxxx xx xxx xxxxxx xxxx**

    Xxxxxxx xxx xxxx xxxxxx xx xxxxxxx [**XxxxXxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br207876). Xxxxx xxx xxxx xxxxxxxxx xxx xxxx, xxxx xxxx, xxx xxxxxxxx, xxx xxxxxxxx xx xxxx xxx xxxx, **XxxxXxxxXxxxXxxxx** xxxxxxx x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxx xxxx xxxxxxxxxx xxx xxxxx xxxx. Xxx xxx xxxxxxx xxx xxxxxxx xxxx xxxx xxx xxxx xxx xxxx xxxx xxx xxxxx xxxxxx xx xx.

```cs
Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
    if (file != null)
    {
        // Prevent updates to the remote version of the file until
        // we finish making changes and call CompleteUpdatesAsync.
        Windows.Storage.CachedFileManager.DeferUpdates(file);
        // write to file
        await Windows.Storage.FileIO.WriteTextAsync(file, file.Name);
        // Let Windows know that we're finished changing the file so
        // the other app can update the remote version of the file.
        // Completing updates may require Windows to ask for user input.
        Windows.Storage.Provider.FileUpdateStatus status = 
            await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
        if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
        {
            this.textBlock.Text = "File " + file.Name + " was saved.";
        }
        else
        {
            this.textBlock.Text = "File " + file.Name + " couldn't be saved.";
        }
    }
    else
    {
        this.textBlock.Text = "Operation cancelled.";
    }
```

Xxx xxxxxxx xxxxxx xxxx xxx xxxx xx xxxxx xxx xxxxxx xxx xxx xxxx xxxx xxxx xx. Xxxx xxx [Xxxxxxxx, xxxxxxx, xxx xxxxxxx x xxxx](quickstart-reading-and-writing-files.md).

**Xxx**  Xxx xxxxxx xxxxxx xxxxx xxx xxxxx xxxx xx xxxx xxxx xx xx xxxxx xxxxxx xxx xxxxxxx xxx xxxxx xxxxxxxxxx. Xxxx, xxx xxx xxxx xxxxxxx xx xxx xxxx xx xxxxxxxxxxx xxx xxxx xxx, xxx xxxxxxx xxxxxxxxxxx xxxxxxxx xx xxx xxxxxx xxxx xx xxx xxxxx.

     

 

 




<!--HONumber=Mar16_HO1-->
