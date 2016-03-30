---
Xxxxxxxxxxx: Xxxxx xxx xxxxxx xxxx xx x Xxxxxxxx Xxxxxxxxxxx Xxxxxx (XXX) xxxx xxxxx xxxxxxxx Xxx Xxxxxxxxxx Xxxxxx (XXX) xxxxxxxx.
xxxxx: Xxxxx xxx xxxxxxxx xxx xxxxxxx
xx.xxxxxxx: XYYXYXYX-XXYY-YYYY-YYYY-YXYXXYXXXYYY
xxxxx: Xxxxx xxx xxxxxxxx xxx xxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxx xxx xxxxxxxx xxx xxxxxxx
\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxx xxxxxxx xxx xxxxx xxx xxxxxxxxx xxx xxxxxxxxxxx xxx xxx xxxxxxxx xxxx xxxx xxxxxxxx, xxxxxxxxxxx xxx xxxxxxxxxx xxx xxxxxxxxx. Xxxx xxxx xxx xxx xxx-xxxxxxx, xxx xxxx xxx xxxxxx XXX xxxxx, xxxxxxxxx xxxxx-xxxxxxx xxxxxxxxxx xxxxxxxxxxxx.


**Xxxxxxxxx XXXx**

-   [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535)
-   [**Xxxxxxx.XX.Xxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208524)



**Xxxx**  
XXX xx xxx xxxx xxxxxxx xxxxxxxxxx xxxxxxxxxxxxxx xx xxx. Xx xxx xx xxxxxxxx xxxxxx x xxxxxx xxxxxxxx xxxxxx, xxxx xx x XXX xxxx, xx xxxxxx xxxxxxxx xx xxx Xxxxxxxxx.

 

## <span id="Save_ink_strokes_to_a_file">
            </span>
            <span id="save_ink_strokes_to_a_file">
            </span>
            <span id="SAVE_INK_STROKES_TO_A_FILE">
            </span>Xxxx xxx xxxxxxx xx x xxxx


Xxxx, xx xxxxxxxxxxx xxx xx xxxx xxx xxxxxxx xxxxx xx xx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx.

1.  Xxxxx, xx xxx xx xxx XX.

    Xxx XX xxxxxxxx "Xxxx", "Xxxx", xxx "Xxxxx" xxxxxxx, xxx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535).

```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="Header" 
                       Text="Basic ink store sample" 
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
            <Button x:Name="btnSave" 
                    Content="Save" 
                    Margin="50,0,10,0"/>
            <Button x:Name="btnLoad" 
                    Content="Load" 
                    Margin="50,0,10,0"/>
            <Button x:Name="btnClear" 
                    Content="Clear" 
                    Margin="50,0,10,0"/>
        </StackPanel>
        <Grid Grid.Row="1">
            <InkCanvas x:Name="inkCanvas" />
        </Grid>
    </Grid>
```

2.  Xx xxxx xxx xxxx xxxxx xxx xxxxx xxxxxxxxx.

    Xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxxx xx xxxxxxxxx xxxxx xxxx xxxx xxxx xxx xxx xxxxx xx xxx xxxxxxx ([**XxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922019)), xxx xxxxxxxxx xxx xxx xxxxx xxxxxx xx xxx xxxxxxx xxx xxxxxxxx.

```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Listen for button click to initiate save.
        btnSave.Click += btnSave_Click;
        // Listen for button click to initiate load.
        btnLoad.Click += btnLoad_Click;
        // Listen for button click to clear ink canvas.
        btnClear.Click += btnClear_Click;
    }
```

3.  Xxxxxxx, xx xxxx xxx xxx xx xxx xxxxx xxxxx xxxxxxx xx xxx **Xxxx** xxxxxx.

    X [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207871) xxxx xxx xxxx xxxxxx xxxx xxx xxxx xxx xxx xxxxxxxx xxxxx xxx xxx xxxx xx xxxxx.

    Xxxx x xxxx xx xxxxxxxx, xx xxxx xx [**XXxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241731) xxxxxx xxx xx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br241635).

    Xx xxxx xxxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br242114) xx xxxxxxxxx xxx xxx xxxxxxx xxxxxxx xx xxx [**XxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208492) xx xxx xxxxxx.

```    CSharp
// Save ink data to a file.
    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();

        // Strokes present on ink canvas.
        if (currentStrokes.Count > 0)
        {
            // Let users choose their ink file using a file picker.
            // Initialize the picker.
            Windows.Storage.Pickers.FileSavePicker savePicker = 
                new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = 
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add(
                "GIF with embedded ISF", 
                new List<string>() { ".gif" });
            savePicker.DefaultFileExtension = ".gif";
            savePicker.SuggestedFileName = "InkSample";

            // Show the file picker.
            Windows.Storage.StorageFile file = 
                await savePicker.PickSaveFileAsync();
            // When chosen, picker returns a reference to the selected file.
            if (file != null)
            {
                // Prevent updates to the file until updates are 
                // finalized with call to CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // Open a file stream for writing.
                IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                // Write the ink strokes to the output stream.
                using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
                {
                    await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
                    await outputStream.FlushAsync();
                }
                stream.Dispose();

                // Finalize write so other apps can update file.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    // File saved.
                }
                else
                {
                    // File couldn&#39;t be saved.
                }
            }
            // User selects Cancel and picker returns null.
            else
            {
                // Operation cancelled.
            }
        }
    }
```

**Xxxx**  
XXX xx xxx xxxx xxxxxxxxx xxxxxx xxx xxxxxx xxx xxxx. Xxxxxxx, xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701607) xxxxxx (xxxxxxxxxxxx xx xxx xxxx xxxxxxx) xxxx xxxxxxx xxxxxxxxxx xxxxxxx xxx xxxxxxxx xxxxxxxxxxxxx.

 

## <span id="Load_ink_strokes_from_a_file">
            </span>
            <span id="load_ink_strokes_from_a_file">
            </span>
            <span id="LOAD_INK_STROKES_FROM_A_FILE">
            </span>Xxxx xxx xxxxxxx xxxx x xxxx


Xxxx, xx xxxxxxxxxxx xxx xx xxxx xxx xxxxxxx xxxx x xxxx xxx xxxxxx xxxx xx xx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx.

1.  Xxxxx, xx xxx xx xxx XX.

    Xxx XX xxxxxxxx "Xxxx", "Xxxx", xxx "Xxxxx" xxxxxxx, xxx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535).

```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="Header" 
                       Text="Basic ink store sample" 
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
            <Button x:Name="btnSave" 
                    Content="Save" 
                    Margin="50,0,10,0"/>
            <Button x:Name="btnLoad" 
                    Content="Load" 
                    Margin="50,0,10,0"/>
            <Button x:Name="btnClear" 
                    Content="Clear" 
                    Margin="50,0,10,0"/>
        </StackPanel>
        <Grid Grid.Row="1">
            <InkCanvas x:Name="inkCanvas" />
        </Grid>
    </Grid>
```

2.  Xx xxxx xxx xxxx xxxxx xxx xxxxx xxxxxxxxx.

    Xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxxx xx xxxxxxxxx xxxxx xxxx xxxx xxxx xxx xxx xxxxx xx xxx xxxxxxx ([**XxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922019)), xxx xxxxxxxxx xxx xxx xxxxx xxxxxx xx xxx xxxxxxx xxx xxxxxxxx.

```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Listen for button click to initiate save.
        btnSave.Click += btnSave_Click;
        // Listen for button click to initiate load.
        btnLoad.Click += btnLoad_Click;
        // Listen for button click to clear ink canvas.
        btnClear.Click += btnClear_Click;
    }
```

3.  Xxxxxxx, xx xxxx xxx xxx xx xxx xxxxx xxxxx xxxxxxx xx xxx **Xxxx** xxxxxx.

    X [**XxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br207847) xxxx xxx xxxx xxxxxx xxxx xxx xxxx xxx xxx xxxxxxxx xxxx xxxxx xx xxxxxxxx xxx xxxxx xxx xxxx.

    Xxxx x xxxx xx xxxxxxxx, xx xxxx xx [**XXxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241731) xxxxxx xxx xx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br241635).

    Xx xxxx xxxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701607) xx xxxx, xx-xxxxxxxxx, xxx xxxx xxx xxxxx xxx xxxxxxx xxxx xxx [**XxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208492). Xxxxxxx xxx xxxxxxx xxxx xxx **XxxXxxxxxXxxxxxxxx** xxxxxx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxxxx xxxxxx xxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535).

```    CSharp
// Save ink data to a file.
    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
        // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();

        // Strokes present on ink canvas.
        if (currentStrokes.Count > 0)
        {
            // Let users choose their ink file using a file picker.
            // Initialize the picker.
            Windows.Storage.Pickers.FileSavePicker savePicker = 
                new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = 
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add(
                "GIF with embedded ISF", 
                new List<string>() { ".gif" });
            savePicker.DefaultFileExtension = ".gif";
            savePicker.SuggestedFileName = "InkSample";

            // Show the file picker.
            Windows.Storage.StorageFile file = 
                await savePicker.PickSaveFileAsync();
            // When chosen, picker returns a reference to the selected file.
            if (file != null)
            {
                // Prevent updates to the file until updates are 
                // finalized with call to CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);
                // Open a file stream for writing.
                IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                // Write the ink strokes to the output stream.
                using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
                {
                    await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
                    await outputStream.FlushAsync();
                }
                stream.Dispose();

                // Finalize write so other apps can update file.
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    // File saved.
                }
                else
                {
                    // File couldn&#39;t be saved.
                }
            }
            // User selects Cancel and picker returns null.
            else
            {
                // Operation cancelled.
            }
        }
    }
```

**Xxxx**  
XXX xx xxx xxxx xxxxxxxxx xxxxxx xxx xxxxxx xxx xxxx. Xxxxxxx, xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701607) xxxxxx xxxx xxxxxxx xxx xxxxxxxxx xxxxxxx xxx xxxxxxxx xxxxxxxxxxxxx.

| Xxxxxx                    | Xxxxxxxxxxx                                                                                                                                                                                                                                                                                                                                                                                           |
|---------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| XxxXxxxxxxxxxXxxxxx       | Xxxxxxxxx xxx xxxx xx xxxxxxxxx xxxxx XXX. Xxxx xx xxx xxxx xxxxxxx xxxxxxxxxx xxxxxxxxxxxxxx xx xxx. Xx xxx xx xxxxxxxx xxxxxx x xxxxxx xxxxxxxx xxxxxx xx xxxxxx xxxxxxxx xx xxx Xxxxxxxxx.                                                                                                                                                                                                         |
| XxxxYYXxxXxxxxxxxxxXxxxxx | Xxxxxxxxx xxx xxxx xx xxxxxxxxx xx xxxxxxxx xxx XXX xx x xxxxYY xxxxxx. Xxxx xxxxxx xx xxxxxxxx xx xxx xxx xx xxxxxxx xxxxxxxx xx xx XXX xx XXXX xxxx.                                                                                                                                                                                                                                                |
| Xxx                       | Xxxxxxxxx xxx xxxx xx xxxxxxxxx xx xxxxx x XXX xxxx xxxx xxxxxxxx XXX xx xxxxxxxx xxxxxxxx xxxxxx xxx xxxx. Xxxx xxxxxxx xxx xx xx xxxxxx xx xxxxxxxxxxxx xxxx xxx xxx xxx-xxxxxxx xxx xxxxxxxx xxx xxxx xxx xxxxxxxx xxxx xx xxxxxxx xx xx xxx-xxxxxxx xxxxxxxxxxx. Xxxx xxxxxx xx xxxxx xxxx xxxxxxxxxxxx xxx xxxxxxx xxxxxx xx XXXX xxxx xxx xxx xxxxxx xx xxxxxx xx xxx xxx xxx-xxx xxxxxxxxxxxx. |
| XxxxYYXxx                 | Xxxxxxxxx xxx xxxx xx xxxxxxxxx xx xxxxx x xxxxYY-xxxxxxx xxxxxxxxx XXX. Xxxx xxxxxx xx xxxxxxxx xxxx xxx xx xx xx xxxxxxx xxxxxxxx xx xx XXX xx XXXX xxxx xxx xxxxx xxxxxxxxxx xxxx xx xxxxx. X xxxxxxxx xxx xx xxxx xx xx xx XXX xxxxxx xxxxxxxxx xx xxxxxxx xxx xxx xxxxxxxxxxx xxx xxxx xx xxxxxxxx XXXX xxxxxxx Xxxxxxxxxx Xxxxxxxxxx Xxxxxxxx Xxxxxxxxxxxxxxx (XXXX).                           |

 

 

## <span id="Copy_and_paste_ink_strokes_with_the_clipboard">
            </span>
            <span id="copy_and_paste_ink_strokes_with_the_clipboard">
            </span>
            <span id="COPY_AND_PASTE_INK_STROKES_WITH_THE_CLIPBOARD">
            </span>Xxxx xxx xxxxx xxx xxxxxxx xxxx xxx xxxxxxxxx


Xxxx, xx xxxxxxxxxxx xxx xx xxx xxx xxxxxxxxx xx xxxxxxxx xxx xxxxxxx xxxxxxx xxxx.

Xx xxxxxxx xxxxxxxxx xxxxxxxxxxxxx, xxx xxxxx-xx [**XxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208492) xxx xxx xxxx xxxxxxxx xxxxxxx xxx xx xxxx xxx xxxxxxx xx xxxxxxxx.

Xxx xxxx xxxxxxx, xx xxxxxx xxxxxx xxxxxxxxx xxxx xxxxx xx xxxxxxxx xxxx x xxx xxxxxx xxxxxx (xx xxxxx xxxxx xxxxxx). Xxx x xxxxxxxx xxxxxxx xx xxx xx xxxxxxxxx xxxxxx xxxxxxxxx, xxx [Xxxx-xxxxxxx xxxxx xxx xxxxxxxx xxxxxxxxxx](pen-and-stylus-interactions.md#passthrough) xx [Xxx xxx xxxxxx xxxxxxxxxxxx](pen-and-stylus-interactions.md).

1.  Xxxxx, xx xxx xx xxx XX.

    Xxx XX xxxxxxxx "Xxx", "Xxxx", "Xxxxx", xxx "Xxxxx" xxxxxxx, xxxxx xxxx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxx x xxxxxxxxx xxxxxx.

```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="tbHeader" 
                       Text="Basic ink store sample" 
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
            <Button x:Name="btnCut" 
                    Content="Cut" 
                    Margin="20,0,10,0"/>
            <Button x:Name="btnCopy" 
                    Content="Copy" 
                    Margin="20,0,10,0"/>
            <Button x:Name="btnPaste" 
                    Content="Paste" 
                    Margin="20,0,10,0"/>
            <Button x:Name="btnClear" 
                    Content="Clear" 
                    Margin="20,0,10,0"/>
        </StackPanel>
        <Grid x:Name="gridCanvas" Grid.Row="1">
            <!-- Canvas for displaying selection UI. -->
            <Canvas x:Name="selectionCanvas"/>
            <!-- Inking area -->
            <InkCanvas x:Name="inkCanvas"/>
        </Grid>
    </Grid>
```

2.  Xx xxxx xxx xxxx xxxxx xxx xxxxx xxxxxxxxx.

    Xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxxx xx xxxxxxxxx xxxxx xxxx xxxx xxxx xxx xxx xxxxx xx xxx xxxxxxx ([**XxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922019)). Xxxxxxxxx xxx xxx xxxxx xxxxxx xx xxx xxxxxxx xx xxxx xx xxxxxxx xxx xxxxxx xxxxxx xxx xxxxxxxxx xxxxxxxxxxxxx xxx xxxx xxxxxxxx xxxx.

    Xxx x xxxxxxxx xxxxxxx xx xxx xx xxxxxxxxx xxxxxx xxxxxxxxx, xxx [Xxxx-xxxxxxx xxxxx xxx xxxxxxxx xxxxxxxxxx](pen-and-stylus-interactions.md#passthrough) xx [Xxx xxx xxxxxx xxxxxxxxxxxx](pen-and-stylus-interactions.md) .

```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Listen for button click to cut ink strokes.
        btnCut.Click += btnCut_Click;
        // Listen for button click to copy ink strokes.
        btnCopy.Click += btnCopy_Click;
        // Listen for button click to paste ink strokes.
        btnPaste.Click += btnPaste_Click;
        // Listen for button click to clear ink canvas.
        btnClear.Click += btnClear_Click;

        // By default, the InkPresenter processes input modified by 
        // a secondary affordance (pen barrel button, right mouse 
        // button, or similar) as ink.
        // To pass through modified input to the app for custom processing 
        // on the app UI thread instead of the background ink thread, set 
        // InputProcessingConfiguration.RightDragAction to LeaveUnprocessed.
        inkCanvas.InkPresenter.InputProcessingConfiguration.RightDragAction =
            InkInputRightDragAction.LeaveUnprocessed;

        // Listen for unprocessed pointer events from modified input.
        // The input is used to provide selection functionality.
        inkCanvas.InkPresenter.UnprocessedInput.PointerPressed +=
            UnprocessedInput_PointerPressed;
        inkCanvas.InkPresenter.UnprocessedInput.PointerMoved +=
            UnprocessedInput_PointerMoved;
        inkCanvas.InkPresenter.UnprocessedInput.PointerReleased +=
            UnprocessedInput_PointerReleased;

        // Listen for new ink or erase strokes to clean up selection UI.
        inkCanvas.InkPresenter.StrokeInput.StrokeStarted +=
            StrokeInput_StrokeStarted;
        inkCanvas.InkPresenter.StrokesErased +=
            InkPresenter_StrokesErased;
    }
```

3.  Xxxxxxx, xxxxx xxxxxx xxxxxx xxxxxxxxx xxxxxxx, xx xxxxxxxxx xxxxxxxxx xxxxxxxxxxxxx xx xxx xxxxx xxxxx xxxxxxxx xx xxx **Xxx**, **Xxxx**, xxx **Xxxxx** xxxxxxx.

    Xxx xxx, xx xxxxx xxxx [**XxxxXxxxxxxxXxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br244232) xx xxx [**XxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208492) xx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922011).

    Xx xxxx xxxx [**XxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br244233) xx xxxxxx xxx xxxxxxx xxxx xxx xxx xxxxxx.

    Xxxxxxx, xx xxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxxxxx xxxxxx.

```    CSharp
private void btnCut_Click(object sender, RoutedEventArgs e)
    {
        inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
        inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
        ClearSelection();
    }
```

```    CSharp
// Clean up selection UI.
    private void ClearSelection()
    {
        var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
        foreach (var stroke in strokes)
        {
            stroke.Selected = false;
        }
        ClearDrawnBoundingRect();
    }

    private void ClearDrawnBoundingRect()
    {
        if (selectionCanvas.Children.Any())
        {
            selectionCanvas.Children.Clear();
            boundingRect = Rect.Empty;
        }
    }
```

    For copy, we simply call [**CopySelectedToClipboard**](https://msdn.microsoft.com/library/windows/apps/br244232) on the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011).

```    CSharp
private void btnCopy_Click(object sender, RoutedEventArgs e)
    {
        inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
    }
```

    For paste, we call [**CanPasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208495) to ensure that the content on the clipboard can be pasted to the ink canvas.

    If so, we call [**PasteFromClipboard**](https://msdn.microsoft.com/library/windows/apps/br208503) to insert the clipboard ink strokes into the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011), which then renders the strokes to the ink canvas.

```    CSharp
private void btnPaste_Click(object sender, RoutedEventArgs e)
    {
        if (inkCanvas.InkPresenter.StrokeContainer.CanPasteFromClipboard())
        {
            inkCanvas.InkPresenter.StrokeContainer.PasteFromClipboard(
                new Point(0, 0));
        }
        else
        {
            // Cannot paste from clipboard.
        }
    }
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


* [Xxx xxx xxxxxx xxxxxxxxxxxx](pen-and-stylus-interactions.md)
**Xxxxxxx**
* [Xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [Xxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [Xxxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620314)
 

 




<!--HONumber=Mar16_HO1-->
