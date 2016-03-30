---
Xxxxxxxxxxx: Xxx xxx xxx x XxxxXxxxXxx xxxxxxx xx xxxxx xxx xxxx xxxx xxxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxx xxxx, xxxxxxxxxx, xxx xxxxxx. Xxx xxx xxxx x XxxxXxxxXxx xxxx-xxxx xx xxxxxxx xxx XxXxxxXxxx xxxxxxxx xx xxxx.
xxxxx: XxxxXxxxXxx
xx.xxxxxxx: YXXXYXXX-YXYY-YYYX-YXYY-YYYYXXXXYYYY
xxxxx: Xxxx xxxx xxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxx xxxx xxx
Xxx xxx xxx x XxxxXxxxXxx xxxxxxx xx xxxxx xxx xxxx xxxx xxxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxx xxxx, xxxxxxxxxx, xxx xxxxxx. Xxx xxx xxxx x XxxxXxxxXxx xxxx-xxxx xx xxxxxxx xxx XxXxxxXxxx xxxxxxxx xx **xxxx**.

<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**XxxxXxxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx)
-   [**Xxxxxxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.document.aspx)
-   [**XxXxxxXxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isreadonly.aspx)
-   [**XxXxxxxXxxxxXxxxxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isspellcheckenabled.aspx)

## Xx xxxx xxx xxxxx xxxxxxx?

Xxx x **XxxxXxxxXxx** xx xxxxxxx xxx xxxx xxxx xxxxx. Xxx xxx'x xxx x XxxxXxxxXxx xx xxx xxxx xxxxx xxxx xxx xxx xxx xxx xxx xxx xxxxx xxxxxxxx xxxx xxxxx xxxxx. Xxxxxx, xxx xxx xx xx xxxx xxxx xxxx xxxxx xxxx xxx xxxxxxxx xxxx xxxx xxx. Xxx xxxxxxxxx xxxx xxxx xxxxxxx xxxx x XxxxXxxxXxx xx x .xxx xxxx.
-   Xx xxx xxxxxxx xxxxxxx xx xxx xxxxx-xxxx xxxx xxx xx xxx xxxxxxxx xxxxxxxxx (xxxx xx xxxx xxxxxxx xx xxx xxxxxxxx xx xx xxxxx xxxxxxx), xxx xxxxx xxxxxxxxx xxxxxxx xxxx xxxx, xxx x xxxx xxxx xxx.
-   Xx xxx xxxx xxxxx xx xx xxxx xx xxxxxx xxxxx xxxx, xxx x xxxx xxxx xxx.
-   Xxxx xxxxxxxxx xxxx xxxx xxxx xxxx xx xxxxxxxx xxx xxx xxxxxxxxxxx xx xxxxx, xxx x xxxxx xxxx xxxxx xxxxxxx.
-   Xxx xxx xxxxx xxxxxxxxx, xxx x xxxxx xxxx xxxxx xxxxxxx.

Xxx xxxx xxxx xxxxx xxxxxxxx xxx xxxxx xxxx xxxxxxx, xxx xxx [Xxxx xxxxxxxx](text-controls.md) xxxxxxx.

## Xxxxxxxx

Xxxx xxxx xxxx xxx xxx x xxxx xxxx xxxxxxxx xxxx xx xx. Xxx xxxxxxxxxx xxx xxxx xxxxxxx xxxx'x xxxx xx xxx xxxx xxxx xxx, xxx xxx xxxxxx xxxxxxx xx xxxxx x xxxxxxx xxx xx xxxxxxx xxxxxxx xxx xxxxxxxxx xxxxx xxxxxxx.

![X xxxx xxxx xxx xxxx xx xxxx xxxxxxxx](images/rich-edit-box.png)

## Xxxxxx x xxxx xxxx xxx

Xx xxxxxxx, xxx XxxxXxxxXxx xxxxxxxx xxxxx xxxxxxxx. Xx xxxxxxx xxx xxxxx xxxxxxx, xxx xxx [XxXxxxxXxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.isspellcheckenabled.aspx) xxxxxxxx xx **xxxxx**. Xxx xxxx xxxx, xxx Xxxxxxxxxx xxx xxxxxxxxx xxx xxxxx xxxxxxxx.

Xxx xxx xxx [Xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.document.aspx) xxxxxxxx xx xxx XxxxXxxxXxx xx xxx xxx xxxxxxx. Xxx xxxxxxx xx x XxxxXxxxXxx xx x [Xxxxxxx.XX.Xxxx.XXxxxXxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/bb774052.aspx) xxxxxx, xxxxxx xxx XxxxXxxxXxxxx xxxxxxx, xxxxx xxxx [Xxxxxxx.XX.Xxxx.Xxxxxxxxx.Xxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.block.aspx) xxxxxxx xx xxx xxxxxxx. Xxx XXxxxXxxxxxxx xxxxxxxxx xxxxxxxx x xxx xx xxxx xxx xxxx xxx xxxxxxxx xx x xxxxxx, xxxxxxxx xxxx xxxxxx, xxx xxx xxxxxx xxxxxxxxx, xxxx xxx xxxx xxxxxxx, xxx xxxxxxx xxxxxxxxxx xxxxxxxxxx, xxx xx xx.

Xxxx xxxxxxx xxxxx xxx xx xxxx, xxxx, xxx xxxx x Xxxx Xxxx Xxxxxx (.xxx) xxxx xx x XxxxXxxxXxx.

```xaml
<RelativePanel Margin="20" HorizontalAlignment="Stretch">
    <RelativePanel.Resources>
        <Style TargetType="AppBarButton">
            <Setter Property="IsCompact" Value="True"/>
        </Style>
    </RelativePanel.Resources>
    <AppBarButton x:Name="openFileButton" Icon="OpenFile" 
                  Click="OpenButton_Click" ToolTipService.ToolTip="Open file"/>
    <AppBarButton Icon="Save" Click="SaveButton_Click" 
                  ToolTipService.ToolTip="Save file" 
                  RelativePanel.RightOf="openFileButton" Margin="8,0,0,0"/>

    <AppBarButton Icon="Bold" Click="BoldButton_Click" ToolTipService.ToolTip="Bold" 
                  RelativePanel.LeftOf="italicButton" Margin="0,0,8,0"/>
    <AppBarButton x:Name="italicButton" Icon="Italic" Click="ItalicButton_Click" 
                  ToolTipService.ToolTip="Italic" RelativePanel.LeftOf="underlineButton" Margin="0,0,8,0"/>
    <AppBarButton x:Name="underlineButton" Icon="Underline" Click="UnderlineButton_Click" 
                  ToolTipService.ToolTip="Underline" RelativePanel.AlignRightWithPanel="True"/>

    <RichEditBox x:Name="editor" Height="200" RelativePanel.Below="openFileButton" 
                 RelativePanel.AlignLeftWithPanel="True" RelativePanel.AlignRightWithPanel="True"/>
</RelativePanel>
```


```csharp
private async void OpenButton_Click(object sender, RoutedEventArgs e)
{
    // Open a text file.
    Windows.Storage.Pickers.FileOpenPicker open =
        new Windows.Storage.Pickers.FileOpenPicker();
    open.SuggestedStartLocation =
        Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
    open.FileTypeFilter.Add(".rtf");

    Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

    if (file != null)
    {
        try
        {
            Windows.Storage.Streams.IRandomAccessStream randAccStream =
        await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

            // Load the file into the Document property of the RichEditBox.
            editor.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
        }
        catch (Exception)
        {
            ContentDialog errorDialog = new ContentDialog()
            {
                Title = "File open error",
                Content = "Sorry, I couldn't open the file.",
                PrimaryButtonText = "Ok"
            };

            await errorDialog.ShowAsync();
        }
    }
}

private async void SaveButton_Click(object sender, RoutedEventArgs e)
{
    Windows.Storage.Pickers.FileSavePicker savePicker = new Windows.Storage.Pickers.FileSavePicker();
    savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

    // Dropdown of file types the user can save the file as
    savePicker.FileTypeChoices.Add("Rich Text", new List<string>() { ".rtf" });

    // Default file name if the user does not type one in or select a file to replace
    savePicker.SuggestedFileName = "New Document";

    Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
    if (file != null)
    {
        // Prevent updates to the remote version of the file until we 
        // finish making changes and call CompleteUpdatesAsync.
        Windows.Storage.CachedFileManager.DeferUpdates(file);
        // write to file
        Windows.Storage.Streams.IRandomAccessStream randAccStream =
            await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

        editor.Document.SaveToStream(Windows.UI.Text.TextGetOptions.FormatRtf, randAccStream);

        // Let Windows know that we're finished changing the file so the 
        // other app can update the remote version of the file.
        Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
        if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
        {
            Windows.UI.Popups.MessageDialog errorBox =
                new Windows.UI.Popups.MessageDialog("File " + file.Name + " couldn't be saved.");
            await errorBox.ShowAsync();
        }
    }
}

private void BoldButton_Click(object sender, RoutedEventArgs e)
{
    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
        charFormatting.Bold = Windows.UI.Text.FormatEffect.Toggle;
        selectedText.CharacterFormat = charFormatting;
    }
}

private void ItalicButton_Click(object sender, RoutedEventArgs e)
{
    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
        charFormatting.Italic = Windows.UI.Text.FormatEffect.Toggle;
        selectedText.CharacterFormat = charFormatting;
    }
}

private void UnderlineButton_Click(object sender, RoutedEventArgs e)
{
    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
        if (charFormatting.Underline == Windows.UI.Text.UnderlineType.None)
        {
            charFormatting.Underline = Windows.UI.Text.UnderlineType.Single;
        }
        else {
            charFormatting.Underline = Windows.UI.Text.UnderlineType.None;
        }
        selectedText.CharacterFormat = charFormatting;
    }
}
```

## Xxxxxx xxx xxxxx xxxxxxxx xxx xxxx xxxx xxxxxxx

Xx xxxx xxxxx xx xxxxx xxxx xxxxx xxx xxxxx xxxxxxxx, xx Xxxx Xxxxx Xxxxx (XXX), xxx xxx xxx xxx xxxxx xxxxx xx xxx xxxx xxxxxxx xx xxxxx xxx xxxx xx xxxx xxx xxxx xx xxxxxxxx xx xxxxx. Xxx xxxxxxx xxxxxxxx xxxxxx xx xxxxxxx xxxxxxxxxxx xxx xxxxxxx xxxx xxxx xxxx xxxxxxxxx.

Xxx xxxx xxxx xxxxx xxx xx xxx xxxxx xxxxxx, xxx [Xxx xxxxx xxxxx xx xxxxxx xxx xxxxx xxxxxxxx]().

## Xxxxxxxxxxxxxxx

-   Xxxx xxx xxxxxx x xxxx xxxx xxx, xxxxxxx xxxxxxx xxxxxxx xxx xxxxxxxxx xxxxx xxxxxxx.
-   Xxx x xxxx xxxx'x xxxxxxxxxx xxxx xxx xxxxx xx xxxx xxx.
-   Xxxx xxx xxxxxx xx xxx xxxx xxxxxxx xxxx xxxxxx xx xxxxxxxxxxx xxxxxxx xxxxxxx.
-   Xxx'x xxx xxxx xxxx xxxxx xxxxxxxx xxxx xx xxxxxx xxxxx xxxxx xxxx.
-   Xxx'x xxx x xxxxx-xxxx xxxx xxx xxxx xxxxx xxxx xxxx x xxxxxx xxxx.
-   Xxx'x xxx x xxxx xxxx xxxxxxx xx x xxxxx xxxx xxxxxxx xx xxxxxxxx.



\[Xxxx xxxxxxx xxxxxxxx xxxxxxxxxxx xxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx Xxxxxxx YY. Xxx Xxxxxxx Y.Y xxxxxxxx, xxxxxx xxxxxxxx xxx [Xxxxxxx Y.Y xxxxxxxxxx XXX](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Xxxxxxx xxxxxxxx

[Xxxx xxxxxxxx](text-controls.md)

**Xxx xxxxxxxxx**
- [Xxxxxxxxxx xxx xxxxx xxxxxxxx](spell-checking-and-prediction.md)
- [Xxxxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [Xxxxxxxxxx xxx xxxx xxxxx](text-controls.md)

**Xxx xxxxxxxxxx (XXXX)**
- [**XxxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br209683)
- [**Xxxxxxx.XX.Xxxx.Xxxxxxxx XxxxxxxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227519)


**Xxx xxxxxxxxxx (xxxxx)**
- [Xxxxxx.Xxxxxx xxxxxxxx](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
<!--HONumber=Mar16_HO1-->
