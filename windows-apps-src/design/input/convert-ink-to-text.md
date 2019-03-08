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
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633747"
---
# <a name="recognize-windows-ink-strokes-as-text-and-shapes"></a><span data-ttu-id="0ce98-104">Windows Ink のストロークをテキストおよび図形として認識する</span><span class="sxs-lookup"><span data-stu-id="0ce98-104">Recognize Windows Ink strokes as text and shapes</span></span>

<span data-ttu-id="0ce98-105">Windows Ink に組み込まれている認識機能により、インク ストロークをテキストと図形に変換します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-105">Convert ink strokes to text and shapes using the recognition capabilities built into Windows Ink.</span></span>

> <span data-ttu-id="0ce98-106">**重要な Api**:[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、 [ **Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</span><span class="sxs-lookup"><span data-stu-id="0ce98-106">**Important APIs**: [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), [**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</span></span>


## <a name="free-form-recognition-with-ink-analysis"></a><span data-ttu-id="0ce98-107">インクの分析による自由形式の認識</span><span class="sxs-lookup"><span data-stu-id="0ce98-107">Free-form recognition with ink analysis</span></span>

<span data-ttu-id="0ce98-108">ここでは、Windows Ink の分析エンジン ([Windows.UI.Input.Inking.Analysis](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連の自由形式のストロークを分類、分析し、テキストまたは図形として認識する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-108">Here, we demonstrate how to use the Windows Ink analysis engine ([Windows.UI.Input.Inking.Analysis](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)) to classify, analyze, and recognize a set of free-form strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) as either text or shapes.</span></span> <span data-ttu-id="0ce98-109">(テキストおよび図形の認識に加えて、ドキュメント構造、箇条書き、および汎用的な描画の認識にもインクの分析を使うことができます。)</span><span class="sxs-lookup"><span data-stu-id="0ce98-109">(In addition to text and shape recognition, ink analysis can also be used to recognize document structure, bullet lists, and generic drawings.)</span></span>

> [!NOTE]
> <span data-ttu-id="0ce98-110">フォーム入力など、基本的な単一行のプレーン テキスト シナリオの場合、後述の「[制約付き手書き認識](#constrained-handwriting-recognition)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ce98-110">For basic, single-line, plain text scenarios such as form input, see [Constrained handwriting recognition](#constrained-handwriting-recognition) later in this topic.</span></span>

<span data-ttu-id="0ce98-111">この例では、認識はユーザーが描画の終了を示すボタンをクリックしたときに開始されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-111">In this example, recognition is initiated when the user clicks a button to indicate they are finished drawing.</span></span>

<span data-ttu-id="0ce98-112">**このサンプルをからダウンロード[インク分析のサンプル (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)**</span><span class="sxs-lookup"><span data-stu-id="0ce98-112">**Download this sample from [Ink analysis sample (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)**</span></span>

1.  <span data-ttu-id="0ce98-113">まず、UI を設定します (MainPage.xaml)。</span><span class="sxs-lookup"><span data-stu-id="0ce98-113">First, we set up the UI (MainPage.xaml).</span></span> 

    <span data-ttu-id="0ce98-114">UI には、[Recognize] ボタン、[**InkCanvas**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.InkCanvas)、標準的な [**Canvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas) があります。</span><span class="sxs-lookup"><span data-stu-id="0ce98-114">The UI includes a "Recognize" button, an [**InkCanvas**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.InkCanvas), and a standard [**Canvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas).</span></span> <span data-ttu-id="0ce98-115">[Recognize] ボタンが押されると、インク キャンバスにおけるすべてのインク ストロークが分析され、(認識された場合は) 対応する図形とテキストが標準のキャンバスに描画されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-115">When the "Recognize" button is pressed, all ink strokes on the ink canvas are analyzed and (if recognized) corresponding shapes and text are drawn on the standard canvas.</span></span> <span data-ttu-id="0ce98-116">次に、元のインク ストロークがインク キャンバスから削除されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-116">The original ink strokes are then deleted from the ink canvas.</span></span>
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
2. <span data-ttu-id="0ce98-117">UI コード ビハインド ファイル (MainPage.xaml.cs) で、インクとインク分析機能に必要な名前空間の型参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-117">In the UI code-behind file (MainPage.xaml.cs), add the namespace type references required for our ink and ink analysis functionality:</span></span>
    - [<span data-ttu-id="0ce98-118">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="0ce98-118">Windows.UI.Input.Inking</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)
    - [<span data-ttu-id="0ce98-119">Windows.UI.Input.Inking.Analysis</span><span class="sxs-lookup"><span data-stu-id="0ce98-119">Windows.UI.Input.Inking.Analysis</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)
    - [<span data-ttu-id="0ce98-120">Windows.UI.Xaml.Shapes</span><span class="sxs-lookup"><span data-stu-id="0ce98-120">Windows.UI.Xaml.Shapes</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.shapes)

3. <span data-ttu-id="0ce98-121">その後、グローバル変数を指定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-121">We then specify our global variables:</span></span>
```csharp
    InkAnalyzer inkAnalyzer = new InkAnalyzer();
    IReadOnlyList<InkStroke> inkStrokes = null;
    InkAnalysisResult inkAnalysisResults = null;
```
4.  <span data-ttu-id="0ce98-122">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-122">Next, we set some basic ink input behaviors:</span></span>
    - <span data-ttu-id="0ce98-123">[  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペン、マウス、タッチからの入力データをインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-123">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from pen, mouse, and touch as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> 
    - <span data-ttu-id="0ce98-124">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-124">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span> 
    - <span data-ttu-id="0ce98-125">[Recognize] ボタンのクリック イベントのリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-125">A listener for the click event on the "Recognize" button is also declared.</span></span>
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
5.  <span data-ttu-id="0ce98-126">この例では、[Recognize] ボタンのクリック イベント ハンドラーでインクの分析を実行します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-126">For this example, we perform the ink analysis in the click event handler of the "Recognize" button.</span></span>
    - <span data-ttu-id="0ce98-127">まず、[**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas.InkPresenter) の [**StrokeContainer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter.StrokeContainer) で [**GetStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkstrokecontainer.GetStrokes) を呼び出して、現在のインク ストロークすべてのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-127">First, call [**GetStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkstrokecontainer.GetStrokes) on the [**StrokeContainer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter.StrokeContainer) of the [**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas.InkPresenter) to get the collection of all current ink strokes.</span></span>
    - <span data-ttu-id="0ce98-128">インク ストロークが存在する場合、InkAnalyzer の [**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__) への呼び出しでそれを渡します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-128">If ink strokes are present, pass them in a call to [**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__) of the InkAnalyzer.</span></span>
    - <span data-ttu-id="0ce98-129">ここでは描画とテキストの両方を認識しようとしていますが、[**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) メソッドを使って、テキストのみを認識する (ドキュメント構造と箇条書きを含む) か、または描画のみを認識する (図形の認識を含む) かを指定できます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-129">We're trying to recognize both drawings and text, but you can use the [**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) method to specify whether you're interested only in text (including document structure and bullet lists) or only in drawings (including shape recognition).</span></span>
    - <span data-ttu-id="0ce98-130">[  **AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) を呼び出してインクの分析を初期化し、[**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult) を取得します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-130">Call [**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) to initiate ink analysis and get the [**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult).</span></span>
    - <span data-ttu-id="0ce98-131">[  **Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) が **Updated** の状態を返す場合、[**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) と [**InkAnalysisNodeKind.InkDrawing**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) の両方の [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-131">If [**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) returns a state of **Updated**, call [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) for both [**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) and [**InkAnalysisNodeKind.InkDrawing**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind).</span></span>
    - <span data-ttu-id="0ce98-132">ノードの種類の両方のセットを反復処理し、(インク キャンバスの下にある) 認識キャンバスで対応するテキストや図形を描画します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-132">Iterate through both sets of node types and draw the respective text or shape on the recognition canvas (below the ink canvas).</span></span>
    - <span data-ttu-id="0ce98-133">最後に、認識されたノードを InkAnalyzer から削除し、対応するインク ストロークをインク キャンバスから削除します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-133">Finally, delete the recognized nodes from the InkAnalyzer and the corresponding ink strokes from the ink canvas.</span></span>
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
6. <span data-ttu-id="0ce98-134">認識キャンバスに TextBlock を描画するための関数を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-134">Here's the function for drawing a TextBlock on our recognition canvas.</span></span> <span data-ttu-id="0ce98-135">使用して関連付けられているインク ストロークの外接する四角形、手描き入力キャンバスで、TextBlock のフォント サイズと位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-135">We use the bounding rectangle of the associated ink stroke on the ink canvas to set the position and font size of the TextBlock.</span></span>
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
7. <span data-ttu-id="0ce98-136">認識キャンバスに楕円と多角形を描画するための関数を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-136">Here are the functions for drawing ellipses and polygons on our recognition canvas.</span></span> <span data-ttu-id="0ce98-137">使用して関連付けられているインク ストロークの外接する四角形手描き入力キャンバスで、図形のフォント サイズと位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-137">We use the bounding rectangle of the associated ink stroke on the ink canvas to set the position and font size of the shapes.</span></span>
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

<span data-ttu-id="0ce98-138">このサンプルの動作を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-138">Here's this sample in action:</span></span>

| <span data-ttu-id="0ce98-139">分析前</span><span class="sxs-lookup"><span data-stu-id="0ce98-139">Before analysis</span></span> | <span data-ttu-id="0ce98-140">分析後</span><span class="sxs-lookup"><span data-stu-id="0ce98-140">After analysis</span></span> |
| --- | --- |
| ![分析前](images/ink/ink-analysis-raw2-small.png) | ![分析後](images/ink/ink-analysis-analyzed2-small.png) |

---
## <a name="constrained-handwriting-recognition"></a><span data-ttu-id="0ce98-143">制約付き手書き認識</span><span class="sxs-lookup"><span data-stu-id="0ce98-143">Constrained handwriting recognition</span></span>

<span data-ttu-id="0ce98-144">前のセクション ([インクの分析による自由形式の認識](#free-form-recognition-with-ink-analysis)) では、[インクの分析 API](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis) を使用して分析を行い、InkCanvas 領域内の任意のインク ストロークを認識する方法を説明しました。</span><span class="sxs-lookup"><span data-stu-id="0ce98-144">In the preceding section ([Free-form recognition with ink analysis](#free-form-recognition-with-ink-analysis)), we demonstrated how to use the [ink analysis APIs](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis) to analyze and recognize arbitrary ink strokes within an InkCanvas area.</span></span>

<span data-ttu-id="0ce98-145">このセクションでは、(インクの分析ではなく) Windows Ink 手書き認識エンジンを使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) 上の一連のストロークを、(インストールされた既定の言語パックに基づいて) テキストに変換する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-145">In this section, we demonstrate how to use the Windows Ink handwriting recognition engine (not ink analysis) to convert a set of strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) to text (based on the installed default language pack).</span></span>

> [!NOTE]
> <span data-ttu-id="0ce98-146">このセクションに示す基本的な手書き認識は、フォームの入力など、単一行のテキスト入力シナリオに最適です。</span><span class="sxs-lookup"><span data-stu-id="0ce98-146">The basic handwriting recognition shown in this section is best suited for single-line, text input scenarios such as form input.</span></span> <span data-ttu-id="0ce98-147">分析とドキュメントの構造、リスト項目、図形、および描画 (テキスト認識) だけでなくの解釈を含む豊富な認識シナリオでは、前のセクションを参照してください。[自由形式の認識とインク分析](#free-form-recognition-with-ink-analysis)します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-147">For richer recognition scenarios that include analysis and interpretation of document structure, list items, shapes, and drawings (in addition to text recognition), see the previous section: [Free-form recognition with ink analysis](#free-form-recognition-with-ink-analysis).</span></span>

<span data-ttu-id="0ce98-148">この例では、認識はユーザーが書き込みの終了を示すボタンをクリックしたときに開始されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-148">In this example, recognition is initiated when the user clicks a button to indicate they are finished writing.</span></span>

<span data-ttu-id="0ce98-149">**このサンプルをからダウンロード[インク手書き認識のサンプル](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)**</span><span class="sxs-lookup"><span data-stu-id="0ce98-149">**Download this sample from [Ink handwriting recognition sample](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)**</span></span>

1.  <span data-ttu-id="0ce98-150">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-150">First, we set up the UI.</span></span>

    <span data-ttu-id="0ce98-151">UI には、[Recognize] ボタン、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、認識結果を表示する領域を用意します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-151">The UI includes a "Recognize" button, the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), and an area to display recognition results.</span></span>    

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

2. <span data-ttu-id="0ce98-152">この例では、まずインク入力機能に必要な名前空間の型参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0ce98-152">For this example, you need to first add the namespace type references required for our ink functionality:</span></span>
    - [<span data-ttu-id="0ce98-153">Windows.UI.Input</span><span class="sxs-lookup"><span data-stu-id="0ce98-153">Windows.UI.Input</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input)
    - [<span data-ttu-id="0ce98-154">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="0ce98-154">Windows.UI.Input.Inking</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)


3.  <span data-ttu-id="0ce98-155">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-155">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="0ce98-156">[  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-156">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="0ce98-157">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-157">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span> <span data-ttu-id="0ce98-158">[Recognize] ボタンのクリック イベントのリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-158">A listener for the click event on the "Recognize" button is also declared.</span></span>

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

4.  <span data-ttu-id="0ce98-159">最後に、基本的な手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-159">Finally, we perform the basic handwriting recognition.</span></span> <span data-ttu-id="0ce98-160">この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-160">For this example, we use the click event handler of the "Recognize" button to perform the handwriting recognition.</span></span>

    <span data-ttu-id="0ce98-161">[  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-161">An [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stores all ink strokes in an [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) object.</span></span> <span data-ttu-id="0ce98-162">インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-162">The strokes are exposed through the [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) property of the **InkPresenter** and retrieved using the [**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) method.</span></span>

    ```csharp
    // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
    ```

    <span data-ttu-id="0ce98-163">手書き認識プロセスの管理用に、[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を作成します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-163">An [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) is created to manage the handwriting recognition process.</span></span>

    ```csharp
    // Create a manager for the InkRecognizer object
        // used in handwriting recognition.
        InkRecognizerContainer inkRecognizerContainer =
            new InkRecognizerContainer();
    ```

    <span data-ttu-id="0ce98-164">[**RecognizeAsync** ](https://msdn.microsoft.com/library/windows/apps/br208446)のセットを取得するために呼び出される[ **InkRecognitionResult** ](https://msdn.microsoft.com/library/windows/apps/br208464)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="0ce98-164">[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/br208446) is called to retrieve a set of [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) objects.</span></span>

    <span data-ttu-id="0ce98-165">によって検出される各単語の認識の結果を生成、 [ **InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478)します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-165">Recognition results are produced for each word that is detected by an [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478).</span></span>

    ```csharp
    // Recognize all ink strokes on the ink canvas.
        IReadOnlyList<InkRecognitionResult> recognitionResults =
            await inkRecognizerContainer.RecognizeAsync(
                inkCanvas.InkPresenter.StrokeContainer,
                InkRecognitionTarget.All);
    ```

    <span data-ttu-id="0ce98-166">各[ **InkRecognitionResult** ](https://msdn.microsoft.com/library/windows/apps/br208464)オブジェクトには、一連テキストの候補にはが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0ce98-166">Each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) object contains a set of text candidates.</span></span> <span data-ttu-id="0ce98-167">この一覧の最上位の項目は、残りの候補の信頼度の高い順に続く、最もよく一致する認識エンジンによってと見なされます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-167">The topmost item in this list is considered by the recognition engine to be the best match, followed by the remaining candidates in order of decreasing confidence.</span></span>

    <span data-ttu-id="0ce98-168">反復処理して各[ **InkRecognitionResult** ](https://msdn.microsoft.com/library/windows/apps/br208464)候補の一覧をコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="0ce98-168">We iterate through each [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) and compile the list of candidates.</span></span> <span data-ttu-id="0ce98-169">候補が表示されます、 [ **InkStrokeContainer** ](https://msdn.microsoft.com/library/windows/apps/br208492)がクリアされます (も消去されます、 [ **InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535))。</span><span class="sxs-lookup"><span data-stu-id="0ce98-169">The candidates are then displayed and the [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) is cleared (which also clears the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)).</span></span>

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

    <span data-ttu-id="0ce98-170">完全なクリック ハンドラーの例を示します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-170">Here's the click handler example, in full.</span></span>

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

## <a name="international-recognition"></a><span data-ttu-id="0ce98-171">地域と言語の認識</span><span class="sxs-lookup"><span data-stu-id="0ce98-171">International recognition</span></span>

<span data-ttu-id="0ce98-172">Windows のインク プラットフォームに組み込まれている手書き認識には、Windows がサポートするロケールと言語の詳細なサブセットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0ce98-172">The handwriting recognition built into the Windows ink platform includes an extensive subset of locales and languages supported by Windows.</span></span>

<span data-ttu-id="0ce98-173">[  **InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478) によってサポートされている言語の一覧については、[**InkRecognizer.Name**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkrecognizer.name.aspx) プロパティに関するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0ce98-173">See the [**InkRecognizer.Name**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkrecognizer.name.aspx) property topic for a list of languages supported by the [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478) .</span></span>

<span data-ttu-id="0ce98-174">アプリでは、インストール済みの一連の手書き認識エンジンを照会し、それらのいずれかを使うか、ユーザーが好きな言語を選べるようにできます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-174">Your app can query the set of installed handwriting recognition engines and use one of those, or let a user select their preferred language.</span></span>

<span data-ttu-id="0ce98-175">**注**  ユーザーがインストールされている言語の一覧を表示して**設定 -&gt;時刻と言語**します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-175">**Note**   Users can see a list of installed languages by going to **Settings -&gt; Time & Language**.</span></span> <span data-ttu-id="0ce98-176">インストール済みの言語の一覧は **[言語]** に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-176">Installed languages are listed under **Languages**.</span></span>

<span data-ttu-id="0ce98-177">新しい言語パックをインストールし、その言語の手書き認識を有効にするには、次の手順に従ってください。</span><span class="sxs-lookup"><span data-stu-id="0ce98-177">To install new language packs and enable handwriting recognition for that language:</span></span>

1.  <span data-ttu-id="0ce98-178">**[設定]、[時刻と言語]、[地域と言語]** の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-178">Go to **Settings &gt; Time & language &gt; Region & language**.</span></span>
2.  <span data-ttu-id="0ce98-179">**[言語の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-179">Select **Add a language**.</span></span>
3.  <span data-ttu-id="0ce98-180">一覧で言語を選んでから、地域のバージョンを選びます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-180">Select a language from the list, then choose the region version.</span></span> <span data-ttu-id="0ce98-181">これで、選んだ言語が **[地域と言語]** ページに表示されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-181">The language is now listed on the **Region & language** page.</span></span>
4.  <span data-ttu-id="0ce98-182">言語をクリックし、**[オプション]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-182">Click the language and select **Options**.</span></span>
5.  <span data-ttu-id="0ce98-183">**[言語のオプション]** ページで、**手書き認識エンジン**をダウンロードします (完全言語パック、音声認識エンジン、キーボード レイアウトもダウンロードできます)。</span><span class="sxs-lookup"><span data-stu-id="0ce98-183">On the **Language options** page, download the **Handwriting recognition engine** (they can also download the full language pack, speech recognition engine, and keyboard layout here).</span></span>

 

<span data-ttu-id="0ce98-184">ここでは、選ばれた手書き認識エンジンを使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連のインク ストロークを解釈する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-184">Here, we demonstrate how to use the handwriting recognition engine to interpret a set of strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) based on the selected recognizer.</span></span>

<span data-ttu-id="0ce98-185">認識は、ユーザーが手書きの終了時にボタンをクリックすると開始されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-185">The recognition is initiated by the user clicking a button when they are finished writing.</span></span>

1.  <span data-ttu-id="0ce98-186">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-186">First, we set up the UI.</span></span>

    <span data-ttu-id="0ce98-187">UI には、[Recognize] ボタン、インストール済みの手書き認識エンジンの一覧を表示するコンボ ボックス、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、認識結果を表示する領域を用意します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-187">The UI includes a "Recognize" button, a combo box that lists all installed handwriting recognizers, the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), and an area to display recognition results.</span></span>
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

2.  <span data-ttu-id="0ce98-188">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-188">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="0ce98-189">[  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-189">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="0ce98-190">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-190">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span>

    <span data-ttu-id="0ce98-191">`InitializeRecognizerList` 関数を呼び出して、インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-191">We call an `InitializeRecognizerList` function to populate the recognizer combo box with a list of installed handwriting recognizers.</span></span>

    <span data-ttu-id="0ce98-192">また、[Recognize] ボタンのクリック イベントと認識エンジン コンボ ボックスの選択変更イベント用に、リスナーを宣言します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-192">We also declare listeners for the click event on the "Recognize" button and the selection changed event on the recognizer combo box.</span></span>
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

3.  <span data-ttu-id="0ce98-193">インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-193">We populate the recognizer combo box with a list of installed handwriting recognizers.</span></span>

    <span data-ttu-id="0ce98-194">手書き認識プロセスの管理用に、[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を作成します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-194">An [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) is created to manage the handwriting recognition process.</span></span> <span data-ttu-id="0ce98-195">このオブジェクトを使って、[**GetRecognizers**](https://msdn.microsoft.com/library/windows/apps/br208480) を呼び出し、インストール済みの手書き認識エンジンの一覧を取得して、認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-195">Use this object to call [**GetRecognizers**](https://msdn.microsoft.com/library/windows/apps/br208480) and retrieve the list of installed recognizers to populate the recognizer combo box.</span></span>
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

4.  <span data-ttu-id="0ce98-196">認識エンジン コンボ ボックスの選択が変更されていれば、手書き認識エンジンを更新します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-196">Update the handwriting recognizer if the recognizer combo box selection changes.</span></span>

    <span data-ttu-id="0ce98-197">[  **InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を使って、認識エンジン コンボ ボックスから選ばれた認識エンジンに基づいて、[**SetDefaultRecognizer**](https://msdn.microsoft.com/library/windows/apps/hh920328) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-197">Use the [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) to call [**SetDefaultRecognizer**](https://msdn.microsoft.com/library/windows/apps/hh920328) based on the selected recognizer from the recognizer combo box.</span></span>
```csharp
// Handle recognizer change.
    private void comboInstalledRecognizers_SelectionChanged(
        object sender, SelectionChangedEventArgs e)
    {
        inkRecognizerContainer.SetDefaultRecognizer(
            (InkRecognizer)comboInstalledRecognizers.SelectedItem);
    }
```

5.  <span data-ttu-id="0ce98-198">最後に、選ばれた手書き認識エンジンに基づいて、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-198">Finally, we perform the handwriting recognition based on the selected handwriting recognizer.</span></span> <span data-ttu-id="0ce98-199">この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-199">For this example, we use the click event handler of the "Recognize" button to perform the handwriting recognition.</span></span>

    <span data-ttu-id="0ce98-200">[  **InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-200">An [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stores all ink strokes in an [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) object.</span></span> <span data-ttu-id="0ce98-201">インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-201">The strokes are exposed through the [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) property of the **InkPresenter** and retrieved using the [**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) method.</span></span>
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

## <a name="dynamic-recognition"></a><span data-ttu-id="0ce98-202">動的な認識</span><span class="sxs-lookup"><span data-stu-id="0ce98-202">Dynamic recognition</span></span>

<span data-ttu-id="0ce98-203">前の 2 つの例では、認識を開始するためのボタンをユーザーが押す必要がありましたが、ストローク入力と基本的なタイミング関数を組み合わせて使用して、動的な認識を実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-203">While, the previous two examples require the user to press a button to start recognition, you can also perform dynamic recognition using stroke input paired with a basic timing function.</span></span>

<span data-ttu-id="0ce98-204">この例では、先ほど示した地域と言語の認識の例と同じ UI とインク ストローク入力の設定を使います。</span><span class="sxs-lookup"><span data-stu-id="0ce98-204">For this example, we'll use the same UI and stroke settings as the previous international recognition example.</span></span>

1. <span data-ttu-id="0ce98-205">これらのグローバル オブジェクト ([InkAnalyzer](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalyzer)、[InkStroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkstroke)、[InkAnalysisResult](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult)、[DispatcherTimer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dispatchertimer)) は、アプリ全体で使用します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-205">These global objects ([InkAnalyzer](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalyzer), [InkStroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkstroke), [InkAnalysisResult](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult), [DispatcherTimer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dispatchertimer)) are used throughout our app.</span></span>    
```csharp
    // Stroke recognition globals.
    InkAnalyzer inkAnalyzer;
    DispatcherTimer recoTimer;
```

2.  <span data-ttu-id="0ce98-206">音声認識を開始するボタンを用意する代わりに、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) の 2 つのストローク イベント ([**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024) と [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)) のリスナーを追加し、基本的なタイマー ([**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250)) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) 間隔を 1 秒に設定します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-206">Instead of a button to initiate recognition, we add listeners for two [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stroke events ([**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024) and [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)), and set up a basic timer ([**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250)) with a one second [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) interval.</span></span>    
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

3.  <span data-ttu-id="0ce98-207">次に、最初のステップで定義した InkPresenter イベントのハンドラーを定義することができます (さらに [**OnNavigatingFrom**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.page.onnavigatingfrom) ページ イベントを上書きしてタイマーを管理します)。</span><span class="sxs-lookup"><span data-stu-id="0ce98-207">We then define the handlers for the InkPresenter events we declared in the first step (we also override the [**OnNavigatingFrom**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.page.onnavigatingfrom) page event to manage our timer).</span></span>

    - [<span data-ttu-id="0ce98-208">**StrokesCollected**</span><span class="sxs-lookup"><span data-stu-id="0ce98-208">**StrokesCollected**</span></span>](https://msdn.microsoft.com/library/windows/apps/dn922024)  
    <span data-ttu-id="0ce98-209">InkAnalyzer にインク ストロークを追加 ([**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.adddataforstrokes)) し、(ユーザーがペンを持ち上げるか、マウス ボタンから指を離すことで) インク入力を止めると、認識タイマーを開始します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-209">Add ink strokes ([**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.adddataforstrokes)) to the InkAnalyzer and start the recognition timer when the user stops inking (by lifting their pen or finger, or releasing the mouse button).</span></span> <span data-ttu-id="0ce98-210">インク入力がなくなってから 1 秒後に、認識を開始します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-210">After one second of no ink input, recognition is initiated.</span></span>  

        <span data-ttu-id="0ce98-211">[  **SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) メソッドを使って、テキストのみを認識する (ドキュメント構造と箇条書きを含む) か、または描画のみを認識する (図形の認識を含む) かを指定できます。</span><span class="sxs-lookup"><span data-stu-id="0ce98-211">Use the [**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) method to specify whether you're interested only in text (including document structure amd bullet lists) or only in drawings (inlcuding shape recognition).</span></span>

    - [<span data-ttu-id="0ce98-212">**StrokeStarted**</span><span class="sxs-lookup"><span data-stu-id="0ce98-212">**StrokeStarted**</span></span>](https://msdn.microsoft.com/library/windows/apps/dn914702)  
    <span data-ttu-id="0ce98-213">新しいインク ストロークが次のタイマー ティック イベントの前に始まった場合、新しいインク ストロークが同じ手書き入力の続きである可能性が高いため、タイマーを停止します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-213">If a new stroke starts before the next timer tick event, stop the timer as the new stroke is likely the continuation of a single handwriting entry.</span></span>
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

4.  <span data-ttu-id="0ce98-214">最後に、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-214">Finally, we perform the handwriting recognition.</span></span> <span data-ttu-id="0ce98-215">この例では、[**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) イベント ハンドラーを使って、手書き認識を開始します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-215">For this example, we use the [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) event handler of a [**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) to initiate the handwriting recognition.</span></span>
    - <span data-ttu-id="0ce98-216">[  **AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) を呼び出してインクの分析を初期化し、[**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult) を取得します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-216">Call [**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) to initiate ink analysis and get the [**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult).</span></span>
    - <span data-ttu-id="0ce98-217">[  **Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) が **Updated** の状態を返す場合、[**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) のノードの種類の [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-217">If [**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) returns a state of **Updated**, call [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) for node types of  [**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind).</span></span>
    - <span data-ttu-id="0ce98-218">ノードを反復処理して、認識されたテキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-218">Iterate through the nodes and display the recognized text.</span></span>
    - <span data-ttu-id="0ce98-219">最後に、認識されたノードを InkAnalyzer から削除し、対応するインク ストロークをインク キャンバスから削除します。</span><span class="sxs-lookup"><span data-stu-id="0ce98-219">Finally, delete the recognized nodes from the InkAnalyzer and the corresponding ink strokes from the ink canvas.</span></span>
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

## <a name="related-articles"></a><span data-ttu-id="0ce98-220">関連記事</span><span class="sxs-lookup"><span data-stu-id="0ce98-220">Related articles</span></span>

* [<span data-ttu-id="0ce98-221">ペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="0ce98-221">Pen and stylus interactions</span></span>](pen-and-stylus-interactions.md)

<span data-ttu-id="0ce98-222">**トピックのサンプル**</span><span class="sxs-lookup"><span data-stu-id="0ce98-222">**Topic samples**</span></span>
* [<span data-ttu-id="0ce98-223">インク分析のサンプル (basic) (C#)</span><span class="sxs-lookup"><span data-stu-id="0ce98-223">Ink analysis sample (basic) (C#)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)
* [<span data-ttu-id="0ce98-224">インクの手書き認識のサンプル (C#)</span><span class="sxs-lookup"><span data-stu-id="0ce98-224">Ink handwriting recognition sample (C#)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)

<span data-ttu-id="0ce98-225">**その他のサンプル**</span><span class="sxs-lookup"><span data-stu-id="0ce98-225">**Other samples**</span></span>
* [<span data-ttu-id="0ce98-226">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="0ce98-226">Simple ink sample (C#/C++)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="0ce98-227">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="0ce98-227">Complex ink sample (C++)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="0ce98-228">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="0ce98-228">Ink sample (JavaScript)</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="0ce98-229">チュートリアルを開始します。UWP アプリでのインクをサポートします。</span><span class="sxs-lookup"><span data-stu-id="0ce98-229">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="0ce98-230">書籍のサンプルを色分け表示</span><span class="sxs-lookup"><span data-stu-id="0ce98-230">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="0ce98-231">ファミリのノートのサンプル</span><span class="sxs-lookup"><span data-stu-id="0ce98-231">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)


 
