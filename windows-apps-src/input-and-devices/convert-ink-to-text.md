---
Description: インク ストロークを手書き認識によりテキストに変換したり、カスタム認識により図形に変換したりします。
title: インク ストロークの認識
ms.assetid: C2F3F3CE-737F-4652-98B7-5278A462F9D3
label: インク ストロークの認識
template: detail.hbs
---

# インク ストロークの認識


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


**重要な API**

-   [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)
-   [**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)

インク ストロークを手書き認識によりテキストに変換したり、カスタム認識により図形に変換したりします。

手書き認識は、Windows のインク プラットフォームに組み込まれており、ロケールと言語の拡張セットがサポートされています。

ここで示しているすべての例では、インク入力機能に必要な名前空間の参照を追加しています。 "Windows.UI.Input.Inking" などです。

## <span id="Basic_handwriting_recognition"></span><span id="basic_handwriting_recognition"></span><span id="BASIC_HANDWRITING_RECOGNITION"></span>基本的な手書き認識


ここでは、既定のインストール言語パックに関連付けられた手書き認識エンジンを使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連のインク ストロークを解釈する方法を示します。

認識は、ユーザーが手書きの終了時にボタンをクリックすると開始されます。

1.  まず、UI を設定します。

    UI には、[Recognize] ボタン、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、認識結果を表示する領域を用意します。

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

2.  次に、基本的なインク入力の動作をいくつか設定します。

    [
            **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。 インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。 [Recognize] ボタンのクリック イベントのリスナーも宣言します。

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

3.  最後に、基本的な手書き認識を実行します。 この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。

    [
            **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。 インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。

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

## <span id="International_recognition"></span><span id="international_recognition"></span><span id="INTERNATIONAL_RECOGNITION"></span>地域と言語の認識


Windows でサポートされている包括的な言語のサブセットを手書き認識に使えます。

次の表に示しているのは、[**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478) でサポートされている言語です。 最初の列に示しているのは、[**Name**](https://msdn.microsoft.com/library/windows/apps/br208484) に使える値です。

| 名前                                                            | IETF 言語タグ | 対象範囲                                                                      |
|-----------------------------------------------------------------|-------------------|-------------------------------------------------------------------------------|
| Microsoft English (US) Handwriting Recognizer                   | en-US             | 英語 (米国 とフィリピン)                                       |
| Microsoft English (UK) Handwriting Recognizer                   | en-GB             | 英語 (英国、およびこの表で指定されていないその他のすべての地域) |
| Microsoft English (Canada) Handwriting Recognizer               | en-CA             | 英語 (カナダ)                                                             |
| Microsoft English (Australia) Handwriting Recognizer            | en-AU             | 英語 (オーストラリア)                                                          |
| Microsoft-Handschrifterkennung - Deutsch                        | de-DE             | ドイツ語 (ドイツ、オーストリア、ルクセンブルク、ナミビア)                           |
| Microsoft-Handschrifterkennung - Deutsch (Schweiz)              | de-CH             | ドイツ語 (スイス、リヒテンシュタイン)                                       |
| Reconocimiento de escritura a mano en español de Microsoft      | es-ES             | スペイン語 (スペイン、およびこの表で指定されていないその他のすべての地域)         |
| Reconocedor de escritura en Español (México) de Microsoft       | es-MX             | スペイン語 (メキシコ、米国)                                       |
| Reconocedor de escritura en Español (Argentina) de Microsoft    | es-AR             | スペイン語 (アルゼンチン、パラグアイ、ウルグアイ)                                   |
| Reconnaissance d'écriture Microsoft - Français                  | fr                | フランス語 (フランス、カナダ、ベルギー、スイス、およびその他のすべての地域)       |
| Microsoft 日本語手書き認識エンジン                              | ja                | 日本語 (すべての地域)                                                     |
| Riconoscimento grafia italiana Microsoft                        | it                | イタリア語 (イタリア、スイス、およびその他のすべての地域)                        |
| Microsoft Nederlandstalige handschriftherkenning                | nl-NL             | オランダ語 (オランダ、スリナム、アンティル諸島)                           |
| Microsoft Nederlandstalige (België) handschriftherkenning       | nl-BE             | オランダ語 (フラマン) (ベルギー)                                                    |
| Microsoft 中文(简体)手写识别器                                  | zh                | 簡体字中国語                                                  |
| Microsoft 中文(繁體)手寫辨識器                                  | zh-Hant           | 繁体字中国語                                                 |
| Microsoft система распознавания русского рукописного ввода      | ru                | ロシア語 (すべての地域)                                                      |
| Reconhecedor de Manuscrito da Microsoft para Português (Brasil) | pt-BR             | ポルトガル語 (ブラジル)                                                          |
| Reconhecedor de escrita manual da Microsoft para português      | pt-PT             | ポルトガル語 (ポルトガル、およびその他のすべての地域)                               |
| Microsoft 한글 필기 인식기                                      | ko                | 韓国語 (すべての地域)                                                       |
| System rozpoznawania polskiego pisma odręcznego firmy Microsoft | pl                | ポーランド語 (すべての地域)                                                       |
| Microsoft Handskriftstolk för svenska                           | sv                | スウェーデン語 (すべての地域)                                                      |
| Microsoft rozpoznávač rukopisu pro český jazyk                  | cs                | チェコ語 (すべての地域)                                                        |
| Microsoft Genkendelse af dansk håndskrift                       | da                | デンマーク語 (すべての地域)                                                       |
| Microsoft Håndskriftsgjenkjenner for norsk                      | nb                | ノルウェー語 (ブークモール) (すべての地域)                                           |
| Microsoft Håndskriftsgjenkjenner for nynorsk                    | nn                | ノルウェー語 (ニーノシュク) (すべての地域)                                          |
| Microsoftin suomenkielinen käsinkirjoituksen tunnistus          | fi                | フィンランド語 (すべての地域)                                                      |
| Microsoft recunoaştere grafie - Română                          | ro                | ルーマニア語 (すべての地域)                                                     |
| Microsoftov hrvatski rukopisni prepoznavač                      | hr                | クロアチア語 (すべての地域)                                                     |
| Microsoft prepoznavač rukopisa za srpski (latinica)             | sr-Latn           | セルビア語 (ラテン) (すべての地域)                                           |
| Microsoft препознавач рукописа за српски (ћирилица)             | sr                | セルビア語 (キリル) (すべての地域)                                        |
| Reconeixedor d'escriptura manual en català de Microsoft         | ca                | カタロニア語 (すべての地域)                                                      |

 

アプリでは、インストール済みの一連の手書き認識エンジンを照会し、それらのいずれかを使うか、ユーザーが好きな言語を選べるようにできます。

**注**  
ユーザーは [設定]、[時刻と言語] の順に移動することで、インストール済みの言語の一覧を表示できます。 インストール済みの言語の一覧は [言語] に表示されます。

新しい言語パックをインストールし、その言語の手書き認識を有効にするには、次の手順に従ってください。

1.  **[設定]、[時刻と言語]、[地域と言語]** の順に移動します。
2.  **[言語の追加]** を選びます。
3.  一覧で言語を選んでから、地域のバージョンを選びます。 これで、選んだ言語が **[地域と言語]** ページに表示されます。
4.  言語をクリックし、**[オプション]** を選びます。
5.  **[言語のオプション]** ページで、**手書き認識エンジン**をダウンロードします (完全言語パック、音声認識エンジン、キーボード レイアウトもダウンロードできます)。

 

ここでは、選ばれた手書き認識エンジンを使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連のインク ストロークを解釈する方法を示します。

認識は、ユーザーが手書きの終了時にボタンをクリックすると開始されます。

1.  まず、UI を設定します。

    UI には、[Recognize] ボタン、インストール済みの手書き認識エンジンの一覧を表示するコンボ ボックス、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、認識結果を表示する領域を用意します。

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

2.  次に、基本的なインク入力の動作をいくつか設定します。

    [
            **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。 インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。

    `InitializeRecognizerList` 関数を呼び出して、インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。

    また、[Recognize] ボタンのクリック イベントと認識エンジン コンボ ボックスの選択変更イベント用に、リスナーを宣言します。

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

3.  インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。

    手書き認識プロセスの管理用に、[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を作成します。 このオブジェクトを使って、[**GetRecognizers**](https://msdn.microsoft.com/library/windows/apps/br208480) を呼び出し、インストール済みの手書き認識エンジンの一覧を取得して、認識エンジン コンボ ボックスに入れます。

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

4.  認識エンジン コンボ ボックスの選択が変更されていれば、手書き認識エンジンを更新します。

    [
            **InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を使って、認識エンジン コンボ ボックスから選ばれた認識エンジンに基づいて、[**SetDefaultRecognizer**](https://msdn.microsoft.com/library/windows/apps/hh920328) を呼び出します。

```    CSharp
// Handle recognizer change.
    private void comboInstalledRecognizers_SelectionChanged(
        object sender, SelectionChangedEventArgs e)
    {
        inkRecognizerContainer.SetDefaultRecognizer(
            (InkRecognizer)comboInstalledRecognizers.SelectedItem);
    }
```

5.  最後に、選ばれた手書き認識エンジンに基づいて、手書き認識を実行します。 この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。

    [
            **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。 インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。

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

## <span id="Dynamic_handwriting_recognition"></span><span id="dynamic_handwriting_recognition"></span><span id="DYNAMIC_HANDWRITING_RECOGNITION"></span>動的な手書き認識


前の 2 つの例では、認識を開始するには、ユーザーがボタンを押す必要があります。 アプリでは、インク ストローク入力と基本的なタイミング機能を組み合わせて使うことで、動的な認識を実行することもできます。

この例では、先ほど示した地域と言語の認識の例と同じ UI とインク ストローク入力の設定を使います。

1.  先ほどの例と同様、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) を構成します。インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。

    音声認識を開始するボタンを用意する代わりに、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) の 2 つのストローク イベント ([**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024) と [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)) のリスナーを追加し、基本的なタイマー ([**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250)) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) 間隔を 1 秒に設定します。

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

2.  ここで示しているのは、最初の手順で追加した 3 つのイベントのハンドラーです。

    <span id="StrokesCollected"></span><span id="strokescollected"></span><span id="STROKESCOLLECTED"></span>[**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024)  
    ユーザーがペンを持ち上げるか、マウス ボタンから指を離すことで、インク入力を止めると、認識タイマーを開始します。 インク入力がなくなってから 1 秒後に、認識を開始します。

    <span id="StrokeStarted"></span><span id="strokestarted"></span><span id="STROKESTARTED"></span>[**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)  
    新しいインク ストロークが次のタイマー ティック イベントの前に始まった場合、新しいインク ストロークが同じ手書き入力の続きである可能性が高いため、タイマーを停止します。

    <span id="Tick"></span><span id="tick"></span><span id="TICK"></span>[**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256)  
    インク入力がなくなってから 1 秒後に、認識関数を呼び出します。

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

3.  最後に、選ばれた手書き認識エンジンに基づいて、手書き認識を実行します。 この例では、[**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) イベント ハンドラーを使って、手書き認識を開始します。

    [
            **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。 インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。

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

## <span id="related_topics"></span>関連記事


* [ペン操作とスタイラス操作](pen-and-stylus-interactions.md)
**サンプル**
* [インクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [単純なインクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [複雑なインクのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620314)
 

 






<!--HONumber=Mar16_HO1-->


