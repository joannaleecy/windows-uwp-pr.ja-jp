---
Description: Windows Ink のストロークをテキストおよび図形として認識するのには、手書き認識とインクの分析を使います。
title: Windows Ink のストロークをテキストおよび図形として認識する
ms.assetid: C2F3F3CE-737F-4652-98B7-5278A462F9D3
label: Recognize Windows Ink strokes as text
template: detail.hbs
keywords: Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, 手書き認識, ユーザー操作, 入力
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9bdd122f438cc9584b5e1eff2236c625adea9c2b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633747"
---
# <a name="recognize-windows-ink-strokes-as-text-and-shapes"></a>Windows Ink のストロークをテキストおよび図形として認識する

Windows Ink に組み込まれている認識機能により、インク ストロークをテキストと図形に変換します。

> **重要な API**:[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、 [ **Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)


## <a name="free-form-recognition-with-ink-analysis"></a>インクの分析による自由形式の認識

ここでは、Windows Ink の分析エンジン ([Windows.UI.Input.Inking.Analysis](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連の自由形式のストロークを分類、分析し、テキストまたは図形として認識する方法を示します。 (テキストおよび図形の認識に加えて、ドキュメント構造、箇条書き、および汎用的な描画の認識にもインクの分析を使うことができます。)

> [!NOTE]
> フォーム入力など、基本的な単一行のプレーン テキスト シナリオの場合、後述の「[制約付き手書き認識](#constrained-handwriting-recognition)」をご覧ください。

この例では、認識はユーザーが描画の終了を示すボタンをクリックしたときに開始されます。

**このサンプルをからダウンロード[インク分析のサンプル (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)**

1.  まず、UI を設定します (MainPage.xaml)。 

    UI には、[Recognize] ボタン、[**InkCanvas**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.InkCanvas)、標準的な [**Canvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas) があります。 [Recognize] ボタンが押されると、インク キャンバスにおけるすべてのインク ストロークが分析され、(認識された場合は) 対応する図形とテキストが標準のキャンバスに描画されます。 次に、元のインク ストロークがインク キャンバスから削除されます。
```xaml
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" 
                    Orientation="Horizontal" 
                    Grid.Row="0">
            <TextBlock x:Name="Header" 
                        Text="Basic ink analysis sample" 
                        Style="{ThemeResource HeaderTextBlockStyle}" 
                        Margin="10,0,0,0" />
            <Button x:Name="recognize" 
                    Content="Recognize" 
                    Margin="50,0,10,0"/>
        </StackPanel>
        <Grid x:Name="drawingCanvas" Grid.Row="1">

            <!-- The canvas where we render the replacement text and shapes. -->
            <Canvas x:Name="recognitionCanvas" />
            <!-- The canvas for ink input. -->
            <InkCanvas x:Name="inkCanvas" />

        </Grid>
    </Grid>
```
2. UI コード ビハインド ファイル (MainPage.xaml.cs) で、インクとインク分析機能に必要な名前空間の型参照を追加します。
    - [Windows.UI.Input.Inking](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)
    - [Windows.UI.Input.Inking.Analysis](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)
    - [Windows.UI.Xaml.Shapes](https://docs.microsoft.com/uwp/api/windows.ui.xaml.shapes)

3. その後、グローバル変数を指定します。
```csharp
    InkAnalyzer inkAnalyzer = new InkAnalyzer();
    IReadOnlyList<InkStroke> inkStrokes = null;
    InkAnalysisResult inkAnalysisResults = null;
```
4.  次に、基本的なインク入力の動作をいくつか設定します。
    - [  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペン、マウス、タッチからの入力データをインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。 
    - インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。 
    - [Recognize] ボタンのクリック イベントのリスナーも宣言します。
```csharp
/// <summary>
/// Initialize the UI page.
/// </summary>
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen | 
            Windows.UI.Core.CoreInputDeviceTypes.Touch;

        // Set initial ink stroke attributes.
        InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
        drawingAttributes.Color = Windows.UI.Colors.Black;
        drawingAttributes.IgnorePressure = false;
        drawingAttributes.FitToCurve = true;
        inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

        // Listen for button click to initiate recognition.
        recognize.Click += RecognizeStrokes_Click;
    }
```
5.  この例では、[Recognize] ボタンのクリック イベント ハンドラーでインクの分析を実行します。
    - まず、[**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas.InkPresenter) の [**StrokeContainer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter.StrokeContainer) で [**GetStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkstrokecontainer.GetStrokes) を呼び出して、現在のインク ストロークすべてのコレクションを取得します。
    - インク ストロークが存在する場合、InkAnalyzer の [**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__) への呼び出しでそれを渡します。
    - ここでは描画とテキストの両方を認識しようとしていますが、[**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) メソッドを使って、テキストのみを認識する (ドキュメント構造と箇条書きを含む) か、または描画のみを認識する (図形の認識を含む) かを指定できます。
    - [  **AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) を呼び出してインクの分析を初期化し、[**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult) を取得します。
    - [  **Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) が **Updated** の状態を返す場合、[**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) と [**InkAnalysisNodeKind.InkDrawing**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) の両方の [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) を呼び出します。
    - ノードの種類の両方のセットを反復処理し、(インク キャンバスの下にある) 認識キャンバスで対応するテキストや図形を描画します。
    - 最後に、認識されたノードを InkAnalyzer から削除し、対応するインク ストロークをインク キャンバスから削除します。
```csharp
/// <summary>
/// The "Analyze" button click handler.
/// Ink recognition is performed here.
/// </summary>
/// <param name="sender">Source of the click event</param>
/// <param name="e">Event args for the button click routed event</param>
private async void RecognizeStrokes_Click(object sender, RoutedEventArgs e)
    {
        inkStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
        // Ensure an ink stroke is present.
        if (inkStrokes.Count > 0)
        {
            inkAnalyzer.AddDataForStrokes(inkStrokes);

            // In this example, we try to recognizing both 
            // writing and drawing, so the platform default 
            // of "InkAnalysisStrokeKind.Auto" is used.
            // If you're only interested in a specific type of recognition,
            // such as writing or drawing, you can constrain recognition 
            // using the SetStrokDataKind method as follows:
            // foreach (var stroke in strokesText)
            // {
            //     analyzerText.SetStrokeDataKind(
            //      stroke.Id, InkAnalysisStrokeKind.Writing);
            // }
            // This can improve both efficiency and recognition results.
            inkAnalysisResults = await inkAnalyzer.AnalyzeAsync();

            // Have ink strokes on the canvas changed?
            if (inkAnalysisResults.Status == InkAnalysisStatus.Updated)
            {
                // Find all strokes that are recognized as handwriting and 
                // create a corresponding ink analysis InkWord node.
                var inkwordNodes = 
                    inkAnalyzer.AnalysisRoot.FindNodes(
                        InkAnalysisNodeKind.InkWord);

                // Iterate through each InkWord node.
                // Draw primary recognized text on recognitionCanvas 
                // (for this example, we ignore alternatives), and delete 
                // ink analysis data and recognized strokes.
                foreach (InkAnalysisInkWord node in inkwordNodes)
                {
                    // Draw a TextBlock object on the recognitionCanvas.
                    DrawText(node.RecognizedText, node.BoundingRect);

                    foreach (var strokeId in node.GetStrokeIds())
                    {
                        var stroke = 
                            inkCanvas.InkPresenter.StrokeContainer.GetStrokeById(strokeId);
                        stroke.Selected = true;
                    }
                    inkAnalyzer.RemoveDataForStrokes(node.GetStrokeIds());
                }
                inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();

                // Find all strokes that are recognized as a drawing and 
                // create a corresponding ink analysis InkDrawing node.
                var inkdrawingNodes =
                    inkAnalyzer.AnalysisRoot.FindNodes(
                        InkAnalysisNodeKind.InkDrawing);
                // Iterate through each InkDrawing node.
                // Draw recognized shapes on recognitionCanvas and
                // delete ink analysis data and recognized strokes.
                foreach (InkAnalysisInkDrawing node in inkdrawingNodes)
                {
                    if (node.DrawingKind == InkAnalysisDrawingKind.Drawing)
                    {
                        // Catch and process unsupported shapes (lines and so on) here.
                    }
                    // Process generalized shapes here (ellipses and polygons).
                    else
                    {
                        // Draw an Ellipse object on the recognitionCanvas (circle is a specialized ellipse).
                        if (node.DrawingKind == InkAnalysisDrawingKind.Circle || node.DrawingKind == InkAnalysisDrawingKind.Ellipse)
                        {
                            DrawEllipse(node);
                        }
                        // Draw a Polygon object on the recognitionCanvas.
                        else
                        {
                            DrawPolygon(node);
                        }
                        foreach (var strokeId in node.GetStrokeIds())
                        {
                            var stroke = inkCanvas.InkPresenter.StrokeContainer.GetStrokeById(strokeId);
                            stroke.Selected = true;
                        }
                    }
                    inkAnalyzer.RemoveDataForStrokes(node.GetStrokeIds());
                }
                inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
            }
        }
    }
```
6. 認識キャンバスに TextBlock を描画するための関数を以下に示します。 使用して関連付けられているインク ストロークの外接する四角形、手描き入力キャンバスで、TextBlock のフォント サイズと位置を設定します。
```csharp
/// <summary>
/// Draw ink recognition text string on the recognitionCanvas.
/// </summary>
/// <param name="recognizedText">The string returned by text recognition.</param>
/// <param name="boundingRect">The bounding rect of the original ink writing.</param>
private void DrawText(string recognizedText, Rect boundingRect)
{
    TextBlock text = new TextBlock();
    Canvas.SetTop(text, boundingRect.Top);
    Canvas.SetLeft(text, boundingRect.Left);

    text.Text = recognizedText;
    text.FontSize = boundingRect.Height;

    recognitionCanvas.Children.Add(text);
}
```
7. 認識キャンバスに楕円と多角形を描画するための関数を以下に示します。 使用して関連付けられているインク ストロークの外接する四角形手描き入力キャンバスで、図形のフォント サイズと位置を設定します。
```csharp
    // Draw an ellipse on the recognitionCanvas.
    private void DrawEllipse(InkAnalysisInkDrawing shape)
    {
        var points = shape.Points;
        Ellipse ellipse = new Ellipse();

        ellipse.Width = shape.BoundingRect.Width;
        ellipse.Height = shape.BoundingRect.Height;

        Canvas.SetTop(ellipse, shape.BoundingRect.Top);
        Canvas.SetLeft(ellipse, shape.BoundingRect.Left);

        var brush = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 0, 0, 255));
        ellipse.Stroke = brush;
        ellipse.StrokeThickness = 2;
        recognitionCanvas.Children.Add(ellipse);
    }

    // Draw a polygon on the recognitionCanvas.
    private void DrawPolygon(InkAnalysisInkDrawing shape)
    {
        List<Point> points = new List<Point>(shape.Points);
        Polygon polygon = new Polygon();

        foreach (Point point in points)
        {
            polygon.Points.Add(point);
        }

        var brush = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 0, 0, 255));
        polygon.Stroke = brush;
        polygon.StrokeThickness = 2;
        recognitionCanvas.Children.Add(polygon);
    }
```

このサンプルの動作を以下に示します。

| 分析前 | 分析後 |
| --- | --- |
| ![分析前](images/ink/ink-analysis-raw2-small.png) | ![分析後](images/ink/ink-analysis-analyzed2-small.png) |

---
## <a name="constrained-handwriting-recognition"></a>制約付き手書き認識

前のセクション ([インクの分析による自由形式の認識](#free-form-recognition-with-ink-analysis)) では、[インクの分析 API](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis) を使用して分析を行い、InkCanvas 領域内の任意のインク ストロークを認識する方法を説明しました。

このセクションでは、(インクの分析ではなく) Windows Ink 手書き認識エンジンを使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) 上の一連のストロークを、(インストールされた既定の言語パックに基づいて) テキストに変換する方法を説明します。

> [!NOTE]
> このセクションに示す基本的な手書き認識は、フォームの入力など、単一行のテキスト入力シナリオに最適です。 分析とドキュメントの構造、リスト項目、図形、および描画 (テキスト認識) だけでなくの解釈を含む豊富な認識シナリオでは、前のセクションを参照してください。[自由形式の認識とインク分析](#free-form-recognition-with-ink-analysis)します。

この例では、認識はユーザーが書き込みの終了を示すボタンをクリックしたときに開始されます。

**このサンプルをからダウンロード[インク手書き認識のサンプル](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)**

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

2. この例では、まずインク入力機能に必要な名前空間の型参照を追加する必要があります。
    - [Windows.UI.Input](https://docs.microsoft.com/uwp/api/windows.ui.input)
    - [Windows.UI.Input.Inking](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)


3.  次に、基本的なインク入力の動作をいくつか設定します。

    [  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。 インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。 [Recognize] ボタンのクリック イベントのリスナーも宣言します。

    ```csharp
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

4.  最後に、基本的な手書き認識を実行します。 この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。

    [  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。 インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。

    ```csharp
    // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
    ```

    手書き認識プロセスの管理用に、[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を作成します。

    ```csharp
    // Create a manager for the InkRecognizer object
        // used in handwriting recognition.
        InkRecognizerContainer inkRecognizerContainer =
            new InkRecognizerContainer();
    ```

    [**RecognizeAsync** ](https://msdn.microsoft.com/library/windows/apps/br208446)のセットを取得するために呼び出される[ **InkRecognitionResult** ](https://msdn.microsoft.com/library/windows/apps/br208464)オブジェクト。

    によって検出される各単語の認識の結果を生成、 [ **InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478)します。

    ```csharp
    // Recognize all ink strokes on the ink canvas.
        IReadOnlyList<InkRecognitionResult> recognitionResults =
            await inkRecognizerContainer.RecognizeAsync(
                inkCanvas.InkPresenter.StrokeContainer,
                InkRecognitionTarget.All);
    ```

    各[ **InkRecognitionResult** ](https://msdn.microsoft.com/library/windows/apps/br208464)オブジェクトには、一連テキストの候補にはが含まれています。 この一覧の最上位の項目は、残りの候補の信頼度の高い順に続く、最もよく一致する認識エンジンによってと見なされます。

    反復処理して各[ **InkRecognitionResult** ](https://msdn.microsoft.com/library/windows/apps/br208464)候補の一覧をコンパイルします。 候補が表示されます、 [ **InkStrokeContainer** ](https://msdn.microsoft.com/library/windows/apps/br208492)がクリアされます (も消去されます、 [ **InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535))。

    ```csharp
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

    完全なクリック ハンドラーの例を示します。

    ```csharp
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

## <a name="international-recognition"></a>地域と言語の認識

Windows のインク プラットフォームに組み込まれている手書き認識には、Windows がサポートするロケールと言語の詳細なサブセットが含まれています。

[  **InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478) によってサポートされている言語の一覧については、[**InkRecognizer.Name**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkrecognizer.name.aspx) プロパティに関するトピックをご覧ください。

アプリでは、インストール済みの一連の手書き認識エンジンを照会し、それらのいずれかを使うか、ユーザーが好きな言語を選べるようにできます。

**注**  ユーザーがインストールされている言語の一覧を表示して**設定 -&gt;時刻と言語**します。 インストール済みの言語の一覧は **[言語]** に表示されます。

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

    [  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。 インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。

    `InitializeRecognizerList` 関数を呼び出して、インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。

    また、[Recognize] ボタンのクリック イベントと認識エンジン コンボ ボックスの選択変更イベント用に、リスナーを宣言します。
```csharp
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
```csharp
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

    [  **InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を使って、認識エンジン コンボ ボックスから選ばれた認識エンジンに基づいて、[**SetDefaultRecognizer**](https://msdn.microsoft.com/library/windows/apps/hh920328) を呼び出します。
```csharp
// Handle recognizer change.
    private void comboInstalledRecognizers_SelectionChanged(
        object sender, SelectionChangedEventArgs e)
    {
        inkRecognizerContainer.SetDefaultRecognizer(
            (InkRecognizer)comboInstalledRecognizers.SelectedItem);
    }
```

5.  最後に、選ばれた手書き認識エンジンに基づいて、手書き認識を実行します。 この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。

    [  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。 インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。
```csharp
// Get all strokes on the InkCanvas.
    IReadOnlyList<InkStroke> currentStrokes =
        inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
```

    [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/br208446) is called to retrieve a set of [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) objects.

    Recognition results are produced for each word that is detected by an [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478).

```csharp
// Recognize all ink strokes on the ink canvas.
    IReadOnlyList<InkRecognitionResult> recognitionResults =
        await inkRecognizerContainer.RecognizeAsync(
            inkCanvas.InkPresenter.StrokeContainer,
            InkRecognitionTarget.All);
```

    Each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) object contains a set of text candidates. The topmost item in this list is considered by the recognition engine to be the best match, followed by the remaining candidates in order of decreasing confidence.

    We iterate through each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) and compile the list of candidates. The candidates are then displayed and the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) is cleared (which also clears the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)).

```csharp
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
    
```csharp
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

## <a name="dynamic-recognition"></a>動的な認識

前の 2 つの例では、認識を開始するためのボタンをユーザーが押す必要がありましたが、ストローク入力と基本的なタイミング関数を組み合わせて使用して、動的な認識を実行することもできます。

この例では、先ほど示した地域と言語の認識の例と同じ UI とインク ストローク入力の設定を使います。

1. これらのグローバル オブジェクト ([InkAnalyzer](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalyzer)、[InkStroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkstroke)、[InkAnalysisResult](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult)、[DispatcherTimer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dispatchertimer)) は、アプリ全体で使用します。    
```csharp
    // Stroke recognition globals.
    InkAnalyzer inkAnalyzer;
    DispatcherTimer recoTimer;
```

2.  音声認識を開始するボタンを用意する代わりに、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) の 2 つのストローク イベント ([**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024) と [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)) のリスナーを追加し、基本的なタイマー ([**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250)) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) 間隔を 1 秒に設定します。    
```csharp
    public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Listen for stroke events on the InkPresenter to 
        // enable dynamic recognition.
        // StrokesCollected is fired when the user stops inking by 
        // lifting their pen or finger, or releasing the mouse button.
        inkCanvas.InkPresenter.StrokesCollected += inkCanvas_StrokesCollected;
        // StrokeStarted is fired when ink input is first detected.
        inkCanvas.InkPresenter.StrokeInput.StrokeStarted +=
            inkCanvas_StrokeStarted;

        inkAnalyzer = new InkAnalyzer();

        // Timer to manage dynamic recognition.
        recoTimer = new DispatcherTimer();
        recoTimer.Interval = TimeSpan.FromSeconds(1);
        recoTimer.Tick += recoTimer_TickAsync;
    }
```

3.  次に、最初のステップで定義した InkPresenter イベントのハンドラーを定義することができます (さらに [**OnNavigatingFrom**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.page.onnavigatingfrom) ページ イベントを上書きしてタイマーを管理します)。

    - [**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024)  
    InkAnalyzer にインク ストロークを追加 ([**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.adddataforstrokes)) し、(ユーザーがペンを持ち上げるか、マウス ボタンから指を離すことで) インク入力を止めると、認識タイマーを開始します。 インク入力がなくなってから 1 秒後に、認識を開始します。  

        [  **SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) メソッドを使って、テキストのみを認識する (ドキュメント構造と箇条書きを含む) か、または描画のみを認識する (図形の認識を含む) かを指定できます。

    - [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)  
    新しいインク ストロークが次のタイマー ティック イベントの前に始まった場合、新しいインク ストロークが同じ手書き入力の続きである可能性が高いため、タイマーを停止します。
```csharp
    // Handler for the InkPresenter StrokeStarted event.
    // Don't perform analysis while a stroke is in progress.
    // If a new stroke starts before the next timer tick event,
    // stop the timer as the new stroke is likely the continuation
    // of a single handwriting entry.
    private void inkCanvas_StrokeStarted(InkStrokeInput sender, PointerEventArgs args)
    {
        recoTimer.Stop();
    }    
    // Handler for the InkPresenter StrokesCollected event.
    // Stop the timer and add the collected strokes to the InkAnalyzer.
    // Start the recognition timer when the user stops inking (by 
    // lifting their pen or finger, or releasing the mouse button).
    // If ink input is not detected after one second, initiate recognition.
    private void inkCanvas_StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
    {
        recoTimer.Stop();
        // If you're only interested in a specific type of recognition,
        // such as writing or drawing, you can constrain recognition 
        // using the SetStrokDataKind method, which can improve both 
        // efficiency and recognition results.
        // In this example, "InkAnalysisStrokeKind.Writing" is used.
        foreach (var stroke in args.Strokes)
        {
            inkAnalyzer.AddDataForStroke(stroke);
            inkAnalyzer.SetStrokeDataKind(stroke.Id, InkAnalysisStrokeKind.Writing);
        }
        recoTimer.Start();
    }    
    // Override the Page OnNavigatingFrom event handler to 
    // stop our timer if user leaves page.
    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        recoTimer.Stop();
    } 
```

4.  最後に、手書き認識を実行します。 この例では、[**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) イベント ハンドラーを使って、手書き認識を開始します。
    - [  **AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) を呼び出してインクの分析を初期化し、[**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult) を取得します。
    - [  **Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) が **Updated** の状態を返す場合、[**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) のノードの種類の [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) を呼び出します。
    - ノードを反復処理して、認識されたテキストを表示します。
    - 最後に、認識されたノードを InkAnalyzer から削除し、対応するインク ストロークをインク キャンバスから削除します。
```csharp
    private async void recoTimer_TickAsync(object sender, object e)
    {
        recoTimer.Stop();
        if (!inkAnalyzer.IsAnalyzing)
        {
            InkAnalysisResult result = await inkAnalyzer.AnalyzeAsync();

            // Have ink strokes on the canvas changed?
            if (result.Status == InkAnalysisStatus.Updated)
            {
                // Find all strokes that are recognized as handwriting and 
                // create a corresponding ink analysis InkWord node.
                var inkwordNodes =
                    inkAnalyzer.AnalysisRoot.FindNodes(
                        InkAnalysisNodeKind.InkWord);

                // Iterate through each InkWord node.
                // Display the primary recognized text (for this example, 
                // we ignore alternatives), and then delete the 
                // ink analysis data and recognized strokes.
                foreach (InkAnalysisInkWord node in inkwordNodes)
                {
                    string recognizedText = node.RecognizedText;
                    // Display the recognition candidates.
                    recognitionResult.Text = recognizedText;

                    foreach (var strokeId in node.GetStrokeIds())
                    {
                        var stroke =
                            inkCanvas.InkPresenter.StrokeContainer.GetStrokeById(strokeId);
                        stroke.Selected = true;
                    }
                    inkAnalyzer.RemoveDataForStrokes(node.GetStrokeIds());
                }
                inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
            }
        }
        else
        {
            // Ink analyzer is busy. Wait a while and try again.
            recoTimer.Start();
        }
    }
```

## <a name="related-articles"></a>関連記事

* [ペン操作とスタイラス操作](pen-and-stylus-interactions.md)

**トピックのサンプル**
* [インク分析のサンプル (basic) (C#)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)
* [インクの手書き認識のサンプル (C#)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)

**その他のサンプル**
* [単純なインクのサンプル (C#/C++)](https://go.microsoft.com/fwlink/p/?LinkID=620312)
* [複雑なインクのサンプル (C++)](https://go.microsoft.com/fwlink/p/?LinkID=620314)
* [インクのサンプル (JavaScript)](https://go.microsoft.com/fwlink/p/?LinkID=620308)
* [チュートリアルを開始します。UWP アプリでのインクをサポートします。](https://aka.ms/appsample-ink)
* [書籍のサンプルを色分け表示](https://aka.ms/cpubsample-coloringbook)
* [ファミリのノートのサンプル](https://aka.ms/cpubsample-familynotessample)


 
