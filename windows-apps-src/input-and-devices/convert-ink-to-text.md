---
Xxxxxxxxxxx: Xxxxxxx xxx xxxxxxx xx xxxx xxxxx xxxxxxxxxxx xxxxxxxxxxx, xx xx xxxxxx xxxxx xxxxxx xxxxxxxxxxx.
xxxxx: Xxxxxxxxx xxx xxxxxxx
xx.xxxxxxx: XYXYXYXX-YYYX-YYYY-YYXY-YYYYXYYYXYXY
xxxxx: Xxxxxxxxx xxx xxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxxx xxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535)
-   [**Xxxxxxx.XX.Xxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208524)

Xxxxxxx xxx xxxxxxx xx xxxx xxxxx xxxxxxxxxxx xxxxxxxxxxx, xx xx xxxxxx xxxxx xxxxxx xxxxxxxxxxx.

Xxxxxxxxxxx xxxxxxxxxxx xx xxxxx xx xx xxx Xxxxxxx xxx xxxxxxxx, xxx xxxxxxxx xx xxxxxxxxx xxx xx xxxxxxx xxx xxxxxxxxx.

Xxx xxx xxxxxxxx xxxx, xxx xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xxx xxx xxxxxxxxxxxxx. Xxxx xxxxxxxx "Xxxxxxx.XX.Xxxxx.Xxxxxx".

## <span id="Basic_handwriting_recognition">
            </span>
            <span id="basic_handwriting_recognition">
            </span>
            <span id="BASIC_HANDWRITING_RECOGNITION">
            </span>Xxxxx xxxxxxxxxxx xxxxxxxxxxx


Xxxx, xx xxxxxxxxxxx xxx xx xxx xxx xxxxxxxxxxx xxxxxxxxxxx xxxxxx, xxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxx xxxxxxxx xxxx, xx xxxxxxxxx x xxx xx xxxxxxx xx xx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535).

Xxx xxxxxxxxxxx xx xxxxxxxxx xx xxx xxxx xxxxxxxx x xxxxxx xxxx xxxx xxx xxxxxxxx xxxxxxx.

1.  Xxxxx, xx xxx xx xxx XX.

    Xxx XX xxxxxxxx x "Xxxxxxxxx" xxxxxx, xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535), xxx xx xxxx xx xxxxxxx xxxxxxxxxxx xxxxxxx.

```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" 
                    Orientation="Horizontal" 
                    Grid.Row="0">
            <TextBlock x:Name="Header" 
                       Text="Basic ink recognition sample" 
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
            <Button x:Name="recognize" 
                    Content="Recognize" 
                    Margin="50,0,10,0"/>
        </StackPanel>
        <Grid Grid.Row="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="Auto"/>
            </Grid.RowDefinitions>
            <InkCanvas x:Name="inkCanvas" 
                       Grid.Row="0"/>
            <TextBlock x:Name="recognitionResult" 
                       Grid.Row="1" 
                       Margin="50,0,10,0"/>
        </Grid>
    </Grid>
```

2.  Xx xxxx xxx xxxx xxxxx xxx xxxxx xxxxxxxxx.

    Xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxxx xx xxxxxxxxx xxxxx xxxx xxxx xxxx xxx xxx xxxxx xx xxx xxxxxxx ([**XxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922019)). Xxx xxxxxxx xxx xxxxxxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxx xxx xxxxxxxxx [**XxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ms695050). X xxxxxxxx xxx xxx xxxxx xxxxx xx xxx "Xxxxxxxxx" xxxxxx xx xxxx xxxxxxxx.

```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Set initial ink stroke attributes.
        InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
        drawingAttributes.Color = Windows.UI.Colors.Black;
        drawingAttributes.IgnorePressure = false;
        drawingAttributes.FitToCurve = true;
        inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

        // Listen for button click to initiate recognition.
        recognize.Click += Recognize_Click;
    }
```

3.  Xxxxxxx, xx xxxxxxx xxx xxxxx xxxxxxxxxxx xxxxxxxxxxx. Xxx xxxx xxxxxxx, xx xxx xxx xxxxx xxxxx xxxxxxx xx xxx "Xxxxxxxxx" xxxxxx xx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxx.

    Xx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xxxxxx xxx xxx xxxxxxx xx xx [**XxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208492) xxxxxx. Xxx xxxxxxx xxx xxxxxxx xxxxxxx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn948766) xxxxxxxx xx xxx **XxxXxxxxxxxx** xxx xxxxxxxxx xxxxx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208499) xxxxxx.

```    CSharp
// Get all strokes on the InkCanvas.
    IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
```

    An [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) is created to manage the handwriting recognition process.

```    CSharp
// Create a manager for the InkRecognizer object 
    // used in handwriting recognition.
    InkRecognizerContainer inkRecognizerContainer = 
        new InkRecognizerContainer();
```

    [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/br208446) is called to retrieve a set of [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) objects.

    Recognition results are produced for each word that is detected by an [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478).

```    CSharp
// Recognize all ink strokes on the ink canvas.
    IReadOnlyList<InkRecognitionResult> recognitionResults = 
        await inkRecognizerContainer.RecognizeAsync(
            inkCanvas.InkPresenter.StrokeContainer, 
            InkRecognitionTarget.All);
```

    Each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) object contains a set of text candidates. The topmost item in this list is considered by the recognition engine to be the best match, followed by the remaining candidates in order of decreasing confidence.

    We iterate through each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) and compile the list of candidates. The candidates are then displayed and the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) is cleared (which also clears the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)).

```    CSharp
string str = "Recognition result\n";
    // Iterate through the recognition results.
    foreach (var result in recognitionResults)
    {
        // Get all recognition candidates from each recognition result.
        IReadOnlyList<string> candidates = result.GetTextCandidates();
        str += "Candidates: " + candidates.Count.ToString() + "\n";
        foreach (string candidate in candidates)
        {
            str += candidate + " ";
        }
    }
    // Display the recognition candidates.
    recognitionResult.Text = str;
    // Clear the ink canvas once recognition is complete.
    inkCanvas.InkPresenter.StrokeContainer.Clear();
```

    Here's the click handler example, in full.

```    CSharp
// Handle button click to initiate recognition.
    private async void Recognize_Click(object sender, RoutedEventArgs e)
    {
        // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();

        // Ensure an ink stroke is present.
        if (currentStrokes.Count > 0)
        {
            // Create a manager for the InkRecognizer object 
            // used in handwriting recognition.
            InkRecognizerContainer inkRecognizerContainer = 
                new InkRecognizerContainer();

            // inkRecognizerContainer is null if a recognition engine is not available.
            if (!(inkRecognizerContainer == null))
            {
                // Recognize all ink strokes on the ink canvas.
                IReadOnlyList<InkRecognitionResult> recognitionResults = 
                    await inkRecognizerContainer.RecognizeAsync(
                        inkCanvas.InkPresenter.StrokeContainer, 
                        InkRecognitionTarget.All);
                // Process and display the recognition results.
                if (recognitionResults.Count > 0)
                {
                    string str = "Recognition result\n";
                    // Iterate through the recognition results.
                    foreach (var result in recognitionResults)
                    {
                        // Get all recognition candidates from each recognition result.
                        IReadOnlyList<string> candidates = result.GetTextCandidates();
                        str += "Candidates: " + candidates.Count.ToString() + "\n";
                        foreach (string candidate in candidates)
                        {
                            str += candidate + " ";
                        }
                    }
                    // Display the recognition candidates.
                    recognitionResult.Text = str;
                    // Clear the ink canvas once recognition is complete.
                    inkCanvas.InkPresenter.StrokeContainer.Clear();
                }
                else
                {
                    recognitionResult.Text = "No recognition results.";
                }
            }
            else
            {
                Windows.UI.Popups.MessageDialog messageDialog = new Windows.UI.Popups.MessageDialog("You must install handwriting recognition engine.");
                await messageDialog.ShowAsync();
            }
        }
        else
        {
            recognitionResult.Text = "No ink strokes to recognize.";
        }
    }
```

## <span id="International_recognition">
            </span>
            <span id="international_recognition">
            </span>
            <span id="INTERNATIONAL_RECOGNITION">
            </span>Xxxxxxxxxxxxx xxxxxxxxxxx


X xxxxxxxxxxxxx xxxxxx xx xxxxxxxxx xxxxxxxxx xx Xxxxxxx xxx xx xxxx xxx xxxxxxxxxxx xxxxxxxxxxx.

Xxx xxxxxxxxx xxxxx xxxxx xxx xxxxxxxxx xxxxxxxxx xx xxx [**XxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208478). Xxx xxxxx xxxxxx xxxxxxxx xxx xxxxxxxx xxxxxx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br208484).

| Xxxx                                                            | XXXX xxxxxxxx xxx | Xxxxxxxx                                                                      |
|-----------------------------------------------------------------|-------------------|-------------------------------------------------------------------------------|
| Xxxxxxxxx Xxxxxxx (XX) Xxxxxxxxxxx Xxxxxxxxxx                   | xx-XX             | Xxxxxxx xx xxx X.X. xxx xxx Xxxxxxxxxxx                                       |
| Xxxxxxxxx Xxxxxxx (XX) Xxxxxxxxxxx Xxxxxxxxxx                   | xx-XX             | Xxxxxxx xx Xxxxx Xxxxxxx, xxx xxx xxxxx xxxxxxxxx xxx xxxxxxxxx xx xxxx xxxxx |
| Xxxxxxxxx Xxxxxxx (Xxxxxx) Xxxxxxxxxxx Xxxxxxxxxx               | xx-XX             | Xxxxxxx xx Xxxxxx                                                             |
| Xxxxxxxxx Xxxxxxx (Xxxxxxxxx) Xxxxxxxxxxx Xxxxxxxxxx            | xx-XX             | Xxxxxxx xx Xxxxxxxxx                                                          |
| Xxxxxxxxx-Xxxxxxxxxxxxxxxxxxxx - Xxxxxxx                        | xx-XX             | Xxxxxx xx Xxxxxxx, Xxxxxxx, Xxxxxxxxxx, xxx Xxxxxxx                           |
| Xxxxxxxxx-Xxxxxxxxxxxxxxxxxxxx - Xxxxxxx (Xxxxxxx)              | xx-XX             | Xxxxxx xx Xxxxxxxxxxx xxx Xxxxxxxxxxxxx                                       |
| Xxxxxxxxxxxxxx xx xxxxxxxxx x xxxx xx xxxxñxx xx Xxxxxxxxx      | xx-XX             | Xxxxxxx xx Xxxxx, xxx xxx xxxxx xxxxxxxxx xxx xxxxxxxxx xx xxxx xxxxx         |
| Xxxxxxxxxxx xx xxxxxxxxx xx Xxxxñxx (Xéxxxx) xx Xxxxxxxxx       | xx-XX             | Xxxxxxx xx Xxxxxx xxx xxx Xxxxxx Xxxxxx                                       |
| Xxxxxxxxxxx xx xxxxxxxxx xx Xxxxñxx (Xxxxxxxxx) xx Xxxxxxxxx    | xx-XX             | Xxxxxxx xx Xxxxxxxxx, Xxxxxxxx, xxx Xxxxxxx                                   |
| Xxxxxxxxxxxxxx x'éxxxxxxx Xxxxxxxxx - Xxxxçxxx                  | xx                | Xxxxxx xx Xxxxxx, Xxxxxx, Xxxxxxx, Xxxxxxxxxxx, xxx xxx xxxxx xxxxxxxxx       |
| Xxxxxxxxx 日本語手書き認識エンジン                              | xx                | Xxxxxxxx xx xxx xxxxxxxxx                                                     |
| Xxxxxxxxxxxxxx xxxxxx xxxxxxxx Xxxxxxxxx                        | xx                | Xxxxxxx xx Xxxxx, Xxxxxxxxxxx, xxx xxx xxxxx xxxxxxxxx                        |
| Xxxxxxxxx Xxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxxxx                | xx-XX             | Xxxxx xx xxx Xxxxxxxxxxx, Xxxxxxx, xxx xxx Xxxxxxxx                           |
| Xxxxxxxxx Xxxxxxxxxxxxxxxx (Xxxxxë) xxxxxxxxxxxxxxxxxxxxx       | xx-XX             | Xxxxx xx Xxxxxxx (Xxxxxxx)                                                    |
| Xxxxxxxxx 中文(简体)手写识别器                                  | xx                | Xxxxxxx xx xxxxxxxxxx xxxxxx                                                  |
| Xxxxxxxxx 中文(繁體)手寫辨識器                                  | xx-Xxxx           | Xxxxxxx xx xxxxxxxxxxx xxxxxx                                                 |
| Xxxxxxxxx система распознавания русского рукописного ввода      | xx                | Xxxxxxx xx xxx xxxxxxxxx                                                      |
| Xxxxxxxxxxxx xx Xxxxxxxxxx xx Xxxxxxxxx xxxx Xxxxxxxêx (Xxxxxx) | xx-XX             | Xxxxxxxxxx xx Xxxxxx                                                          |
| Xxxxxxxxxxxx xx xxxxxxx xxxxxx xx Xxxxxxxxx xxxx xxxxxxxêx      | xx-XX             | Xxxxxxxxxx xx Xxxxxxxx, xxx xxx xxxxx xxxxxxxxx                               |
| Xxxxxxxxx 한글 필기 인식기                                      | xx                | Xxxxxx xx xxx xxxxxxxxx                                                       |
| Xxxxxx xxxxxxxxxxxxx xxxxxxxxx xxxxx xxxęxxxxxx xxxxx Xxxxxxxxx | xx                | Xxxxxx xx xxx xxxxxxxxx                                                       |
| Xxxxxxxxx Xxxxxxxxxxxxxxx xöx xxxxxxx                           | xx                | Xxxxxxx xx xxx xxxxxxxxx                                                      |
| Xxxxxxxxx xxxxxxxáxxč xxxxxxxx xxx čxxxý xxxxx                  | xx                | Xxxxx xx xxx xxxxxxxxx                                                        |
| Xxxxxxxxx Xxxxxxxxxxx xx xxxxx xåxxxxxxxx                       | xx                | Xxxxxx xx xxx xxxxxxxxx                                                       |
| Xxxxxxxxx Xåxxxxxxxxxxxxxxxxxxxx xxx xxxxx                      | xx                | Xxxxxxxxx (Xxxxxx) xx xxx xxxxxxxxx                                           |
| Xxxxxxxxx Xåxxxxxxxxxxxxxxxxxxxx xxx xxxxxxx                    | xx                | Xxxxxxxxx (Xxxxxxx) xx xxx xxxxxxxxx                                          |
| Xxxxxxxxxxx xxxxxxxxxxxxxx xäxxxxxxxxxxxxxxx xxxxxxxxx          | xx                | Xxxxxxx xx xxx xxxxxxxxx                                                      |
| Xxxxxxxxx xxxxxxxşxxxx xxxxxx - Xxxâxă                          | xx                | Xxxxxxxx xx xxx xxxxxxxxx                                                     |
| Xxxxxxxxxxx xxxxxxxx xxxxxxxxx xxxxxxxxxxč                      | xx                | Xxxxxxxx xx xxx xxxxxxxxx                                                     |
| Xxxxxxxxx xxxxxxxxxxč xxxxxxxx xx xxxxxx (xxxxxxxx)             | xx-Xxxx           | Xxxxxxx, xx Xxxxx, xx xxx xxxxxxxxx                                           |
| Xxxxxxxxx препознавач рукописа за српски (ћирилица)             | xx                | Xxxxxxx, xx Xxxxxxxx, xx xxx xxxxxxxxx                                        |
| Xxxxxxxxxxxx x'xxxxxxxxxx xxxxxx xx xxxxxà xx Xxxxxxxxx         | xx                | Xxxxxxx xx xxx xxxxxxxxx                                                      |

 

Xxxx xxx xxx xxxxx xxx xxx xx xxxxxxxxx xxxxxxxxxxx xxxxxxxxxxx xxxxxxx xxx xxx xxx xx xxxxx xx xxx x xxxx xxxxxx xxxxx xxxxxxxxx xxxxxxxx.

**Xxxx**  
Xxxxx xxx xxx x xxxx xx xxxxxxxxx xxxxxxxxx xx xxxxx xx Xxxxxxxx -&xx; Xxxx & Xxxxxxxx. Xxxxxxxxx xxxxxxxxx xxx xxxxxx xxxxx Xxxxxxxxx.

Xx xxxxxxx xxx xxxxxxxx xxxxx xxx xxxxxx xxxxxxxxxxx xxxxxxxxxxx xxx xxxx xxxxxxxx:

1.  Xx xx **Xxxxxxxx &xx; Xxxx & xxxxxxxx &xx; Xxxxxx & xxxxxxxx**.
2.  Xxxxxx **Xxx x xxxxxxxx**.
3.  Xxxxxx x xxxxxxxx xxxx xxx xxxx, xxxx xxxxxx xxx xxxxxx xxxxxxx. Xxx xxxxxxxx xx xxx xxxxxx xx xxx **Xxxxxx & xxxxxxxx** xxxx.
4.  Xxxxx xxx xxxxxxxx xxx xxxxxx **Xxxxxxx**.
5.  Xx xxx **Xxxxxxxx xxxxxxx** xxxx, xxxxxxxx xxx **Xxxxxxxxxxx xxxxxxxxxxx xxxxxx** (xxxx xxx xxxx xxxxxxxx xxx xxxx xxxxxxxx xxxx, xxxxxx xxxxxxxxxxx xxxxxx, xxx xxxxxxxx xxxxxx xxxx).

 

Xxxx, xx xxxxxxxxxxx xxx xx xxx xxx xxxxxxxxxxx xxxxxxxxxxx xxxxxx xx xxxxxxxxx x xxx xx xxxxxxx xx xx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxx xx xxx xxxxxxxx xxxxxxxxxx.

Xxx xxxxxxxxxxx xx xxxxxxxxx xx xxx xxxx xxxxxxxx x xxxxxx xxxx xxxx xxx xxxxxxxx xxxxxxx.

1.  Xxxxx, xx xxx xx xxx XX.

    Xxx XX xxxxxxxx x "Xxxxxxxxx" xxxxxx, x xxxxx xxx xxxx xxxxx xxx xxxxxxxxx xxxxxxxxxxx xxxxxxxxxxx, xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535), xxx xx xxxx xx xxxxxxx xxxxxxxxxxx xxxxxxx.

```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" 
                    Orientation="Horizontal" 
                    Grid.Row="0">
            <TextBlock x:Name="Header" 
                       Text="Advanced international ink recognition sample" 
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
            <ComboBox x:Name="comboInstalledRecognizers" 
                     Margin="50,0,10,0">
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
            <Button x:Name="buttonRecognize" 
                    Content="Recognize" 
                    IsEnabled="False"
                    Margin="50,0,10,0"/>
        </StackPanel>
        <Grid Grid.Row="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="Auto"/>
            </Grid.RowDefinitions>
            <InkCanvas x:Name="inkCanvas" 
                       Grid.Row="0"/>
            <TextBlock x:Name="recognitionResult" 
                       Grid.Row="1" 
                       Margin="50,0,10,0"/>
        </Grid>
    </Grid>
```

2.  Xx xxxx xxx xxxx xxxxx xxx xxxxx xxxxxxxxx.

    Xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxxx xx xxxxxxxxx xxxxx xxxx xxxx xxxx xxx xxx xxxxx xx xxx xxxxxxx ([**XxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922019)). Xxx xxxxxxx xxx xxxxxxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxx xxx xxxxxxxxx [**XxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ms695050).

    Xx xxxx xx `InitializeRecognizerList` xxxxxxxx xx xxxxxxxx xxx xxxxxxxxxx xxxxx xxx xxxx x xxxx xx xxxxxxxxx xxxxxxxxxxx xxxxxxxxxxx.

    Xx xxxx xxxxxxx xxxxxxxxx xxx xxx xxxxx xxxxx xx xxx "Xxxxxxxxx" xxxxxx xxx xxx xxxxxxxxx xxxxxxx xxxxx xx xxx xxxxxxxxxx xxxxx xxx.

```    CSharp
 public MainPage()
     {
         this.InitializeComponent();

         // Set supported inking device types.
         inkCanvas.InkPresenter.InputDeviceTypes =
             Windows.UI.Core.CoreInputDeviceTypes.Mouse |
             Windows.UI.Core.CoreInputDeviceTypes.Pen;

         // Set initial ink stroke attributes.
         InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
         drawingAttributes.Color = Windows.UI.Colors.Black;
         drawingAttributes.IgnorePressure = false;
         drawingAttributes.FitToCurve = true;
         inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

         // Populate the recognizer combo box with installed recognizers.
         InitializeRecognizerList();

         // Listen for combo box selection.
         comboInstalledRecognizers.SelectionChanged += 
             comboInstalledRecognizers_SelectionChanged;

         // Listen for button click to initiate recognition.
         buttonRecognize.Click += Recognize_Click;
     }
```

3.  Xx xxxxxxxx xxx xxxxxxxxxx xxxxx xxx xxxx x xxxx xx xxxxxxxxx xxxxxxxxxxx xxxxxxxxxxx.

    Xx [**XxxXxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208479) xx xxxxxxx xx xxxxxx xxx xxxxxxxxxxx xxxxxxxxxxx xxxxxxx. Xxx xxxx xxxxxx xx xxxx [**XxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208480) xxx xxxxxxxx xxx xxxx xx xxxxxxxxx xxxxxxxxxxx xx xxxxxxxx xxx xxxxxxxxxx xxxxx xxx.

```    CSharp
// Populate the recognizer combo box with installed recognizers.
    private void InitializeRecognizerList()
    {
        // Create a manager for the handwriting recognition process.
        inkRecognizerContainer = new InkRecognizerContainer();
        // Retrieve the collection of installed handwriting recognizers.
        IReadOnlyList<InkRecognizer> installedRecognizers = 
            inkRecognizerContainer.GetRecognizers();
        // inkRecognizerContainer is null if a recognition engine is not available.
        if (!(inkRecognizerContainer == null))
        {
            comboInstalledRecognizers.ItemsSource = installedRecognizers;
            buttonRecognize.IsEnabled = true;
        }
    }
```

4.  Xxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xx xxx xxxxxxxxxx xxxxx xxx xxxxxxxxx xxxxxxx.

    Xxx xxx [**XxxXxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208479) xx xxxx [**XxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh920328) xxxxx xx xxx xxxxxxxx xxxxxxxxxx xxxx xxx xxxxxxxxxx xxxxx xxx.

```    CSharp
// Handle recognizer change.
    private void comboInstalledRecognizers_SelectionChanged(
        object sender, SelectionChangedEventArgs e)
    {
        inkRecognizerContainer.SetDefaultRecognizer(
            (InkRecognizer)comboInstalledRecognizers.SelectedItem);
    }
```

5.  Xxxxxxx, xx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxx xxxxx xx xxx xxxxxxxx xxxxxxxxxxx xxxxxxxxxx. Xxx xxxx xxxxxxx, xx xxx xxx xxxxx xxxxx xxxxxxx xx xxx "Xxxxxxxxx" xxxxxx xx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxx.

    Xx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xxxxxx xxx xxx xxxxxxx xx xx [**XxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208492) xxxxxx. Xxx xxxxxxx xxx xxxxxxx xxxxxxx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn948766) xxxxxxxx xx xxx **XxxXxxxxxxxx** xxx xxxxxxxxx xxxxx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208499) xxxxxx.

```    CSharp
// Get all strokes on the InkCanvas.
    IReadOnlyList<InkStroke> currentStrokes = 
        inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
```

    [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/br208446) is called to retrieve a set of [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) objects.

    Recognition results are produced for each word that is detected by an [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478).

```    CSharp
// Recognize all ink strokes on the ink canvas.
    IReadOnlyList<InkRecognitionResult> recognitionResults =
        await inkRecognizerContainer.RecognizeAsync(
            inkCanvas.InkPresenter.StrokeContainer,
            InkRecognitionTarget.All);
```

    Each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) object contains a set of text candidates. The topmost item in this list is considered by the recognition engine to be the best match, followed by the remaining candidates in order of decreasing confidence.

    We iterate through each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) and compile the list of candidates. The candidates are then displayed and the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) is cleared (which also clears the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)).

```    CSharp
string str = "Recognition result\n";
    // Iterate through the recognition results.
    foreach (InkRecognitionResult result in recognitionResults)
    {
        // Get all recognition candidates from each recognition result.
        IReadOnlyList<string> candidates = 
            result.GetTextCandidates();
        str += "Candidates: " + candidates.Count.ToString() + "\n";
        foreach (string candidate in candidates)
        {
            str += candidate + " ";
        }
    }
    // Display the recognition candidates.
    recognitionResult.Text = str;
    // Clear the ink canvas once recognition is complete.
    inkCanvas.InkPresenter.StrokeContainer.Clear();
```

    Here's the click handler example, in full.

```    CSharp
// Handle button click to initiate recognition.
    private async void Recognize_Click(object sender, RoutedEventArgs e)
    {
        // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = 
            inkCanvas.InkPresenter.StrokeContainer.GetStrokes();

        // Ensure an ink stroke is present.
        if (currentStrokes.Count > 0)
        {
            // inkRecognizerContainer is null if a recognition engine is not available.
            if (!(inkRecognizerContainer == null))
            {
                // Recognize all ink strokes on the ink canvas.
                IReadOnlyList<InkRecognitionResult> recognitionResults =
                    await inkRecognizerContainer.RecognizeAsync(
                        inkCanvas.InkPresenter.StrokeContainer,
                        InkRecognitionTarget.All);
                // Process and display the recognition results.
                if (recognitionResults.Count > 0)
                {
                    string str = "Recognition result\n";
                    // Iterate through the recognition results.
                    foreach (InkRecognitionResult result in recognitionResults)
                    {
                        // Get all recognition candidates from each recognition result.
                        IReadOnlyList<string> candidates = 
                            result.GetTextCandidates();
                        str += "Candidates: " + candidates.Count.ToString() + "\n";
                        foreach (string candidate in candidates)
                        {
                            str += candidate + " ";
                        }
                    }
                    // Display the recognition candidates.
                    recognitionResult.Text = str;
                    // Clear the ink canvas once recognition is complete.
                    inkCanvas.InkPresenter.StrokeContainer.Clear();
                }
                else
                {
                    recognitionResult.Text = "No recognition results.";
                }
            }
            else
            {
                Windows.UI.Popups.MessageDialog messageDialog = 
                    new Windows.UI.Popups.MessageDialog(
                        "You must install handwriting recognition engine.");
                await messageDialog.ShowAsync();
            }
        }
        else
        {
            recognitionResult.Text = "No ink strokes to recognize.";
        }
    }
```

## <span id="Dynamic_handwriting_recognition">
            </span>
            <span id="dynamic_handwriting_recognition">
            </span>
            <span id="DYNAMIC_HANDWRITING_RECOGNITION">
            </span>Xxxxxxx xxxxxxxxxxx xxxxxxxxxxx


Xxx xxxxxxxx xxx xxxxxxxx xxxxxxx xxx xxxx xx xxxxx x xxxxxx xx xxxxx xxxxxxxxxxx. Xxxx xxx xxx xxxx xxxxxxx xxxxxxx xxxxxxxxxxx xxxxx xxxxxx xxxxx xxxxxx xxxx x xxxxx xxxxxx xxxxxxxx.

Xxx xxxx xxxxxxx, xx'xx xxx xxx xxxx XX xxx xxxxxx xxxxxxxx xx xxx xxxxxxxx xxxxxxxxxxxxx xxxxxxxxxxx xxxxxxx.

1.  Xxxx xxx xxxxxxxx xxxxxxxx, xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxxx xx xxxxxxxxx xxxxx xxxx xxxx xxxx xxx xxx xxxxx xx xxx xxxxxxx ([**XxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922019)), xxx xxx xxxxxxx xxx xxxxxxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxx xxx xxxxxxxxx [**XxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ms695050).

    Xxxxxxx xx x xxxxxx xx xxxxxxxx xxxxxxxxxxx, xx xxx xxxxxxxxx xxx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xxxxxx xxxxxx ([**XxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922024) xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914702)), xxx xxx xx x xxxxx xxxxx ([**XxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br244250)) xxxx x xxx xxxxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br244256) xxxxxxxx.

```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Set initial ink stroke attributes.
        InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
        drawingAttributes.Color = Windows.UI.Colors.Black;
        drawingAttributes.IgnorePressure = false;
        drawingAttributes.FitToCurve = true;
        inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

        // Populate the recognizer combo box with installed recognizers.
        InitializeRecognizerList();

        // Listen for combo box selection.
        comboInstalledRecognizers.SelectionChanged += 
            comboInstalledRecognizers_SelectionChanged;

        // Listen for stroke events on the InkPresenter to 
        // enable dynamic recognition.
        // StrokesCollected is fired when the user stops inking by 
        // lifting their pen or finger, or releasing the mouse button.
        inkCanvas.InkPresenter.StrokesCollected += 
            inkCanvas_StrokesCollected;
        // StrokeStarted is fired when ink input is first detected.
        inkCanvas.InkPresenter.StrokeInput.StrokeStarted += 
            inkCanvas_StrokeStarted;

        // Timer to manage dynamic recognition.
        recoTimer = new DispatcherTimer();
        recoTimer.Interval = new TimeSpan(0, 0, 1);
        recoTimer.Tick += recoTimer_Tick;
    }

    // Handler for the timer tick event calls the recognition function.
    private void recoTimer_Tick(object sender, object e)
    {
        Recognize_Tick();
    }

    // Handler for the InkPresenter StrokeStarted event.
    // If a new stroke starts before the next timer tick event,
    // stop the timer as the new stroke is likely the continuation
    // of a single handwriting entry.
    private void inkCanvas_StrokeStarted(InkStrokeInput sender, PointerEventArgs args)
    {
        recoTimer.Stop();
    }

    // Handler for the InkPresenter StrokesCollected event.
    // Start the recognition timer when the user stops inking by 
    // lifting their pen or finger, or releasing the mouse button.
    // After one second of no ink input, recognition is initiated.
    private void inkCanvas_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
    {
        recoTimer.Start();
    }
    
```

2.  Xxxx xxx xxx xxxxxxxx xxx xxx xxxxx xxxxxx xx xxxxx xx xxx xxxxx xxxx.

    <span id="StrokesCollected">
                </span>
            <span id="strokescollected">
            </span>
            <span id="STROKESCOLLECTED">
            </span>
            [
            **XxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922024)  
Xxxxx xxx xxxxxxxxxxx xxxxx xxxx xxx xxxx xxxxx xxxxxx xx xxxxxxx xxxxx xxx xx xxxxxx, xx xxxxxxxxx xxx xxxxx xxxxxx. Xxxxx xxx xxxxxx xx xx xxx xxxxx, xxxxxxxxxxx xx xxxxxxxxx.

    <span id="StrokeStarted">
                </span>
            <span id="strokestarted">
            </span>
            <span id="STROKESTARTED">
            </span>
            [
            **XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914702)  
Xx x xxx xxxxxx xxxxxx xxxxxx xxx xxxx xxxxx xxxx xxxxx, xxxx xxx xxxxx xx xxx xxx xxxxxx xx xxxxxx xxx xxxxxxxxxxxx xx x xxxxxx xxxxxxxxxxx xxxxx.

    <span id="Tick">
                </span>
            <span id="tick">
            </span>
            <span id="TICK">
            </span>
            [
            **Xxxx**](https://msdn.microsoft.com/library/windows/apps/br244256)  
Xxxx xxx xxxxxxxxxxx xxxxxxxx xxxxx xxx xxxxxx xx xx xxx xxxxx.

```    CSharp
// Handler for the timer tick event calls the recognition function.
    private void recoTimer_Tick(object sender, object e)
    {
        Recognize_Tick();
    }

    // Handler for the InkPresenter StrokeStarted event.
    // If a new stroke starts before the next timer tick event,
    // stop the timer as the new stroke is likely the continuation
    // of a single handwriting entry.
    private void inkCanvas_StrokeStarted(InkStrokeInput sender, PointerEventArgs args)
    {
        recoTimer.Stop();
    }

    // Handler for the InkPresenter StrokesCollected event.
    // Start the recognition timer when the user stops inking by 
    // lifting their pen or finger, or releasing the mouse button.
    // After one second of no ink input, recognition is initiated.
    private void inkCanvas_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
    {
        recoTimer.Start();
    }
```

3.  Xxxxxxx, xx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxx xxxxx xx xxx xxxxxxxx xxxxxxxxxxx xxxxxxxxxx. Xxx xxxx xxxxxxx, xx xxx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br244256) xxxxx xxxxxxx xx x [**XxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br244250) xx xxxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxx.

    Xx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xxxxxx xxx xxx xxxxxxx xx xx [**XxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208492) xxxxxx. Xxx xxxxxxx xxx xxxxxxx xxxxxxx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn948766) xxxxxxxx xx xxx **XxxXxxxxxxxx** xxx xxxxxxxxx xxxxx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208499) xxxxxx.

```    CSharp
// Get all strokes on the InkCanvas.
    IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
```

    [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/br208446) is called to retrieve a set of [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) objects.

    Recognition results are produced for each word that is detected by an [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478).

```    CSharp
// Recognize all ink strokes on the ink canvas.
    IReadOnlyList<InkRecognitionResult> recognitionResults =
        await inkRecognizerContainer.RecognizeAsync(
            inkCanvas.InkPresenter.StrokeContainer,
            InkRecognitionTarget.All);
```

    Each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) object contains a set of text candidates. The topmost item in this list is considered by the recognition engine to be the best match, followed by the remaining candidates in order of decreasing confidence.

    We iterate through each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) and compile the list of candidates. The candidates are then displayed and the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) is cleared (which also clears the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)).

```    CSharp
string str = "Recognition result\n";
    // Iterate through the recognition results.
    foreach (InkRecognitionResult result in recognitionResults)
    {
        // Get all recognition candidates from each recognition result.
        IReadOnlyList<string> candidates = result.GetTextCandidates();
        str += "Candidates: " + candidates.Count.ToString() + "\n";
        foreach (string candidate in candidates)
        {
            str += candidate + " ";
        }
    }
    // Display the recognition candidates.
    recognitionResult.Text = str;
    // Clear the ink canvas once recognition is complete.
    inkCanvas.InkPresenter.StrokeContainer.Clear();
```

    Here's the recognition function, in full.

```    CSharp
// Respond to timer Tick and initiate recognition.
    private async void Recognize_Tick()
    {
        // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();

        // Ensure an ink stroke is present.
        if (currentStrokes.Count > 0)
        {
            // inkRecognizerContainer is null if a recognition engine is not available.
            if (!(inkRecognizerContainer == null))
            {
                // Recognize all ink strokes on the ink canvas.
                IReadOnlyList<InkRecognitionResult> recognitionResults =
                    await inkRecognizerContainer.RecognizeAsync(
                        inkCanvas.InkPresenter.StrokeContainer,
                        InkRecognitionTarget.All);
                // Process and display the recognition results.
                if (recognitionResults.Count > 0)
                {
                    string str = "Recognition result\n";
                    // Iterate through the recognition results.
                    foreach (InkRecognitionResult result in recognitionResults)
                    {
                        // Get all recognition candidates from each recognition result.
                        IReadOnlyList<string> candidates = result.GetTextCandidates();
                        str += "Candidates: " + candidates.Count.ToString() + "\n";
                        foreach (string candidate in candidates)
                        {
                            str += candidate + " ";
                        }
                    }
                    // Display the recognition candidates.
                    recognitionResult.Text = str;
                    // Clear the ink canvas once recognition is complete.
                    inkCanvas.InkPresenter.StrokeContainer.Clear();
                }
                else
                {
                    recognitionResult.Text = "No recognition results.";
                }
            }
            else
            {
                Windows.UI.Popups.MessageDialog messageDialog = new Windows.UI.Popups.MessageDialog("You must install handwriting recognition engine.");
                await messageDialog.ShowAsync();
            }
        }
        else
        {
            recognitionResult.Text = "No ink strokes to recognize.";
        }

        // Stop the dynamic recognition timer.
        recoTimer.Stop();
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
