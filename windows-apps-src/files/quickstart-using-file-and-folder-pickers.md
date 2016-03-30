---
xx.xxxxxxx: XYYXXXYX-YYXX-YYYY-YYYY-YYXYYXXXXXYY
xxxxx: Xxxx xxxxx xxx xxxxxxx xxxx x xxxxxx
xxxxxxxxxxx: Xxxxxx xxxxx xxx xxxxxxx xx xxxxxxx xxx xxxx xxxxxxxx xxxx x xxxxxx. Xxx xxx xxx xxx XxxxXxxxXxxxxx xxx XxxxXxxxXxxxxx xxxxxxx xx xxxx xxxxxx xx xxxxx, xxx xxx XxxxxxXxxxxx xx xxxx xxxxxx xx x xxxxxx.
---

# Xxxx xxxxx xxx xxxxxxx xxxx x xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207847)
-   [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207881)
-   [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171)

Xxxxxx xxxxx xxx xxxxxxx xx xxxxxxx xxx xxxx xxxxxxxx xxxx x xxxxxx. Xxx xxx xxx xxx [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207847) xxx [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207871) xxxxxxx xx xxxx xxxxxx xx xxxxx, xxx xxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207881) xx xxxx xxxxxx xx x xxxxxx.

**Xxxx**  Xxxx xxx xxx [Xxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619994).

 

## Xxxxxxxxxxxxx


-   **Xxxxxxxxxx xxxxx xxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx**

    Xxx xxx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X# xx Xxxxxx Xxxxx, xxx [Xxxx xxxxxxxxxxxx XXXx xx X# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt187337). Xx xxxxx xxx xx xxxxx xxxxxxxxxxxx xxxx xx X++, xxx [Xxxxxxxxxxxx xxxxxxxxxxx xx X++](https://msdn.microsoft.com/library/windows/apps/mt187334).

-   **Xxxxxx xxxxxxxxxxx xx xxx xxxxxxxx**

    Xxx [Xxxx xxxxxx xxxxxxxxxxx](file-access-permissions.md).

## Xxxx xxxxxx XX


X xxxx xxxxxx xxxxxxxx xxxxxxxxxxx xx xxxxxx xxxxx xxx xx xxxxxxx x xxxxxxxxxx xxxxxxxxxx xxxx xxxxx xxxx xx xxxx xxxxx.

Xxxx xxxxxxxxxxx xxxxxxxx:

-   Xxx xxxxxxx xxxxxxxx
-   Xxx xxxx xx xxxxx xxxx xxx xxxx xxxxxx
-   X xxxx xx xxxxxxxxx xxxx xxx xxxx xxx xxxxxx xx. Xxxxx xxxxxxxxx xxxxxxx xxxx xxxxxx xxxxxxxxx—xxxx xx xxx Xxxxx xx Xxxxxxxxx xxxxxx—xx xxxx xx xxxx xxxx xxxxxxxxx xxx xxxx xxxxxx xxxxxxxx (xxxx xx Xxxxxx, Xxxxxx, xxx Xxxxxxxxx XxxXxxxx).

Xx xxxxx xxx xxxxx xxxxxxx x xxxx xxxxxx xx xxxx xxx xxxx xxx xxxx xxxxxxxxxxx.

![x xxxx xxxxxx xxxx xxx xxxxx xxxxxx xx xx xxxxxx.](images/picker-multifile-600px.png)

## Xxx xxxxxxx xxxx


Xxxxxxx x xxxxxx, xxxx xxx xxx xxxx xxxxxx xx xxxxx xxx xxxxxxx xx xxx xxxx'x xxxxxx. Xxxxxxx xxx xxxxxx, xxx xxxx xxxxxxx xxxxx xxxxxx xx xxxx xxxxx (xx xxxxxxx) xx xxxx xx xxxx xx. Xxxx xxx xxxxxxxx xxxxx xxxxx xx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxxxxx, xxxxx xxx xxx xxxx xxxxxxx xx.

Xxx xxxxxx xxxx x xxxxxx, xxxxxxx xxxxxxxxx xx xxx xxx xxxx xxxx xxxxx xxx xxxxxxx xxxx xxx xxxxx xxxxxx xx xxxx xxxxx xxxx. Xxxxx xxxxxx xxxx xxxxx xxxx xxx xxxx xxxxx xxxx xxx xxxx xxxxxx: xxxx xxx xxxxxxxx xx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxxx. Xx xxxxxxx, xxxx xxx xxx xxxxxxx xx xxxx xx xxx xxxx xxxx xx xxxxx xxxx xxxxxxx. Xxxxx xxxx xxxx xxxxx xxxxxxxxx xx xxxxxxxxxxxxx xx xxxx xxxxxx xxxxxxxxx. Xx xxx xxxx xxxx xxx xx xxxxxxx xxxxx, x xxxx xxxxxxxx, xx xxxx xxxxxxx xx xxxxx xxxx, xxx [Xxxxxxxxxxx xxxx xxxx xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465192).

Xxx xxxxxxx, xxx xxxxx xxxx xxx xxxx xxxxxx xx xxxx xxx xx xxxx xxxx xxxx xxx xxxx x xxxx. Xxxx xxxxx xxxx xxx xxx xxxxxxx xxx. Xxx xxxx xxxxxx xxxxxxxxx xxxx xxx xxxxxx xxx/xx xxxxx xxxx xx xxx xxx xxxx xxxxxxxx xxx xxxx xxx xxxx. Xxxx xxxx xxxx xxxxxxx x xxxx, xxx xxxx xxxxxx xxxxxxx xxxx xxxx xx xxxx xxx. Xxxx'x xxx xxxxxxx xxx xxx xxxx xxxxx xxx xxxx xxxxxxx x xxxx xxxx xxxxxxx xxx, xxxx xx XxxXxxxx. Xx xxxx xxxx XxxXxxxx xx xxx xxxxxxxxx xxx.

![x xxxxxxx xxxx xxxxx xxx xxxxxxx xx xxx xxx xxxxxxx x xxxx xx xxxx xxxx xxxxxxx xxx xxxxx xxx xxxx xxxxxx xx xx xxxxxxxxx xxxxxxx xxx xxx xxxx.](images/app-to-app-diagram-600px.png)

## Xxxx x xxxxxx xxxx xx xxxx xx: xxxxxxxx xxxx xxxxxxx


```CSharp
var picker = new Windows.Storage.Pickers.FileOpenPicker();
picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
picker.SuggestedStartLocation = 
    Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
picker.FileTypeFilter.Add(".jpg");
picker.FileTypeFilter.Add(".jpeg");
picker.FileTypeFilter.Add(".png");

Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
if (file != null)
{
    // Application now has read/write access to the picked file
    this.textBlock.Text = "Picked photo: " + file.Name;
}
else
{
    this.textBlock.Text = "Operation cancelled.";
}
```

Xxx xxxx xx xxxx xxxxxxxx xxxxx, xxx xxx [Xxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619994).

## Xxxx x xxxxxx xxxx xx xxxx xx: xxxx-xx-xxxx


Xxxxx x xxxx xxxxxx xxxxxxxx xxxxxxxx xxx xxxxxxxxxxx x xxxx xxxxxx xxxxxx, xxx xxxx xxxxxxx xxx xxxx xxxxxx xx xxx xxxx xxx xxxx xxx xx xxxx xxxxx.

1.  **Xxxxxx xxx xxxxxxxxx x XxxxXxxxXxxxxx**

```CSharp
var picker = new Windows.Storage.Pickers.FileOpenPicker();
    picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
    picker.SuggestedStartLocation = 
        Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
    picker.FileTypeFilter.Add(".jpg");
    picker.FileTypeFilter.Add(".jpeg");
    picker.FileTypeFilter.Add(".png");
```

Xxx xxxxxxxxxx xx xxx xxxx xxxxxx xxxxxx xxxx xxx xxxxxxxx xx xxxx xxxxx xxx xxxx xxx. Xxx xxxxxxxxxx xx xxxx xxx xxxxxx xxx xx xxxxxxxxx xxx xxxx xxxxxx, xxx [Xxxxxxxxxx xxx xxxxxxxxx xxx xxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465182).

Xxxx xxxxxxx xxxxxxx x xxxx, xxxxxx xxxxxxx xx xxxxxxxx xx x xxxxxxxxxx xxxxxxxx xxxx xxx xxxx xxx xxxx xxxx xx xxxxxxx xxxxx xxxxxxxxxx: [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207855), [**XxxxxxxxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207854), xxx [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207850).

-   Xxxxxxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207855) xx xxx **Xxxxxxxxx**[**XxxxxxXxxxXxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.storage.pickers.pickerviewmode.aspx#thumbnail) xxxx xxxxx xxxxxxx x xxxx, xxxxxx xxxxxxx xx xxxxx xxxxxxx xxxxxxxxxx xx xxxxxxxxx xxxxx xx xxx xxxx xxxxxx. Xx xxxx xxx xxxxxxx xxxxxx xxxxx xxxx xx xxxxxxxx xx xxxxxx. Xxxxxxxxx, xxx [**XxxxxxXxxxXxxx.Xxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.storage.pickers.pickerviewmode.aspx#list). X xxxxxxxxxxxx xxxxx xxx xxxx **Xxxxxx Xxxxxxx xx Xxxxx** xxx **Xxxxxx Xxxxxxxx** xxxxxxxx xxxxx xxx xxx **XxxxXxxx** xxxxxxxxxxx xx xxx xxxxxxx xxxxxx xxxxxxx xxx xxxx xxxxxx.

-   Xxxxxxx [**XxxxxxxxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207854) xx Xxxxxxxx xxxxx [**XxxxxxXxxxxxxxXx.XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207890) xxxxxx xxx xxxx xx x xxxxxxxx xxxxx xxxx'xx xxxxxx xx xxxx xxxxxxxx. Xxx **XxxxxxxxxXxxxxXxxxxxxx** xx x xxxxxxxx xxxxxxxxxxx xxx xxx xxxx xx xxxx xxxxx xxxxxx, xxx xxxxxxx Xxxxx, Xxxxxxxx, Xxxxxx, xx Xxxxxxxxx. Xxxx xxx xxxxx xxxxxxxx, xxx xxxx xxx xxxxxxxx xx xxxxx xxxxxxxxx.

-   Xxxxx [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207850) xx xxxxxxx xxxx xxxxx xxxxx xxx xxxx xxxxxxx xx xxxxxxx xxxxx xxxx xxx xxxxxxxx. Xx xxxxxxx xxxxxxxx xxxx xxxxx xx xxx **XxxxXxxxXxxxxx** xxxx xxx xxxxxxx, xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br207844) xxxxxxx xx [**Xxx**](https://msdn.microsoft.com/library/windows/apps/br207834).

2.  **Xxxx xxx XxxxXxxxXxxxxx**

    -   **Xx xxxx x xxxxxx xxxx**

```CSharp
Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
        if (file != null)
        {
            // Application now has read/write access to the picked file
            this.textBlock.Text = "Picked photo: " + file.Name;
        }
        else
        {
            this.textBlock.Text = "Operation cancelled.";
        }
```

    -   **To pick multiple files**

```CSharp
var files = await picker.PickMultipleFilesAsync();
        if (files.Count > 0)
        {
            StringBuilder output = new StringBuilder("Picked files:\n");

            // Application now has read/write access to the picked file(s)
            foreach (Windows.Storage.StorageFile file in files)
            {
                output.Append(file.Name + "\n");
            }
            this.textBlock.Text = output.ToString();
        }
        else
        {
            this.textBlock.Text = "Operation cancelled.";
        }
```

## Xxxx x xxxxxx: xxxxxxxx xxxx xxxxxxx


```CSharp
var folderPicker = new Windows.Storage.Pickers.FolderPicker();
folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;

Windows.Storage.StorageFolder folder = await folderPicker.PickSingleFolderAsync();
if (folder != null)
{
    // Application now has read/write access to all contents in the picked folder
    // (including other sub-folder contents)
    Windows.Storage.AccessCache.StorageApplicationPermissions.
    FutureAccessList.AddOrReplace("PickedFolderToken", folder);
    this.textBlock.Text = "Picked folder: " + folder.Name;
}
else
{
    this.textBlock.Text = "Operation cancelled.";
}
```

**Xxx**  Xxxxxxxx xxxx xxx xxxxxxxx x xxxx xx xxxxxx xxxxxxx x xxxxxx, xxx xx xx xxxx xxx'x [**XxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207457) xx [**XxxxXxxxxxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br207458) xx xxxx xxxxx xx xx. Xxx xxx xxxxx xxxx xxxxx xxxxx xxxxx xxxxx xx [Xxx xx xxxxx xxxxxxxx-xxxx xxxxx xxx xxxxxxx](how-to-track-recently-used-files-and-folders.md).

 

 

 




<!--HONumber=Mar16_HO1-->
