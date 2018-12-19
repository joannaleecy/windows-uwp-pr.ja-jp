---
Description: Use handwriting recognition and ink analysis to recognize Windows Ink strokes as text and shapes.
title: Windows Ink のストロークをテキストおよび図形として認識する
ms.assetid: C2F3F3CE-737F-4652-98B7-5278A462F9D3
label: Recognize Windows Ink strokes as text
template: detail.hbs
keywords: Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, 手書き認識, ユーザー操作, 入力
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 581f91099a09cff9307a2b4119f9db938f1b83f9
ms.sourcegitcommit: 8ac3818db796a144b44f848b6211bc46a62ab544
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/19/2018
ms.locfileid: "8976919"
---
# <a name="recognize-windows-ink-strokes-as-text-and-shapes"></a><span data-ttu-id="e68b1-103">Windows Ink のストロークをテキストおよび図形として認識する</span><span class="sxs-lookup"><span data-stu-id="e68b1-103">Recognize Windows Ink strokes as text and shapes</span></span>

<span data-ttu-id="e68b1-104">Windows Ink に組み込まれている認識機能により、インク ストロークをテキストと図形に変換します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-104">Convert ink strokes to text and shapes using the recognition capabilities built into Windows Ink.</span></span>

> <span data-ttu-id="e68b1-105">**重要な API**: [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、[**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</span><span class="sxs-lookup"><span data-stu-id="e68b1-105">**Important APIs**: [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), [**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)</span></span>


## <a name="free-form-recognition-with-ink-analysis"></a><span data-ttu-id="e68b1-106">インクの分析による自由形式の認識</span><span class="sxs-lookup"><span data-stu-id="e68b1-106">Free-form recognition with ink analysis</span></span>

<span data-ttu-id="e68b1-107">ここでは、Windows Ink の分析エンジン ([Windows.UI.Input.Inking.Analysis](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連の自由形式のストロークを分類、分析し、テキストまたは図形として認識する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-107">Here, we demonstrate how to use the Windows Ink analysis engine ([Windows.UI.Input.Inking.Analysis](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)) to classify, analyze, and recognize a set of free-form strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) as either text or shapes.</span></span> <span data-ttu-id="e68b1-108">(テキストおよび図形の認識に加えて、ドキュメント構造、箇条書き、および汎用的な描画の認識にもインクの分析を使うことができます。)</span><span class="sxs-lookup"><span data-stu-id="e68b1-108">(In addition to text and shape recognition, ink analysis can also be used to recognize document structure, bullet lists, and generic drawings.)</span></span>

> [!NOTE]
> <span data-ttu-id="e68b1-109">フォーム入力など、基本的な単一行のプレーン テキスト シナリオの場合、後述の「[制約付き手書き認識](#constrained-handwriting-recognition)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e68b1-109">For basic, single-line, plain text scenarios such as form input, see [Constrained handwriting recognition](#constrained-handwriting-recognition) later in this topic.</span></span>

<span data-ttu-id="e68b1-110">この例では、認識はユーザーが描画の終了を示すボタンをクリックしたときに開始されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-110">In this example, recognition is initiated when the user clicks a button to indicate they are finished drawing.</span></span>

**<span data-ttu-id="e68b1-111">このサンプルは、「[Ink analysis sample (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)」(インクの分析のサンプル (基本)) でダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="e68b1-111">Download this sample from [Ink analysis sample (basic)](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)</span></span>**

1.  <span data-ttu-id="e68b1-112">まず、UI を設定します (MainPage.xaml)。</span><span class="sxs-lookup"><span data-stu-id="e68b1-112">First, we set up the UI (MainPage.xaml).</span></span> 

    <span data-ttu-id="e68b1-113">UI には、[Recognize] ボタン、[**InkCanvas**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.InkCanvas)、標準的な [**Canvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas) があります。</span><span class="sxs-lookup"><span data-stu-id="e68b1-113">The UI includes a "Recognize" button, an [**InkCanvas**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.InkCanvas), and a standard [**Canvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas).</span></span> <span data-ttu-id="e68b1-114">[Recognize] ボタンが押されると、インク キャンバスにおけるすべてのインク ストロークが分析され、(認識された場合は) 対応する図形とテキストが標準のキャンバスに描画されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-114">When the "Recognize" button is pressed, all ink strokes on the ink canvas are analyzed and (if recognized) corresponding shapes and text are drawn on the standard canvas.</span></span> <span data-ttu-id="e68b1-115">次に、元のインク ストロークがインク キャンバスから削除されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-115">The original ink strokes are then deleted from the ink canvas.</span></span>
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
2. <span data-ttu-id="e68b1-116">UI コード ビハインド ファイル (MainPage.xaml.cs) で、インクとインク分析機能に必要な名前空間の型参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-116">In the UI code-behind file (MainPage.xaml.cs), add the namespace type references required for our ink and ink analysis functionality:</span></span>
    - [<span data-ttu-id="e68b1-117">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="e68b1-117">Windows.UI.Input.Inking</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)
    - [<span data-ttu-id="e68b1-118">Windows.UI.Input.Inking.Analysis</span><span class="sxs-lookup"><span data-stu-id="e68b1-118">Windows.UI.Input.Inking.Analysis</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)
    - [<span data-ttu-id="e68b1-119">Windows.UI.Xaml.Shapes</span><span class="sxs-lookup"><span data-stu-id="e68b1-119">Windows.UI.Xaml.Shapes</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.shapes)

3. <span data-ttu-id="e68b1-120">その後、グローバル変数を指定します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-120">We then specify our global variables:</span></span>
```csharp
    InkAnalyzer inkAnalyzer = new InkAnalyzer();
    IReadOnlyList<InkStroke> inkStrokes = null;
    InkAnalysisResult inkAnalysisResults = null;
```
4.  <span data-ttu-id="e68b1-121">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-121">Next, we set some basic ink input behaviors:</span></span>
    - <span data-ttu-id="e68b1-122">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペン、マウス、タッチからの入力データをインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-122">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from pen, mouse, and touch as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> 
    - <span data-ttu-id="e68b1-123">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-123">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span> 
    - <span data-ttu-id="e68b1-124">[Recognize] ボタンのクリック イベントのリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-124">A listener for the click event on the "Recognize" button is also declared.</span></span>
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
5.  <span data-ttu-id="e68b1-125">この例では、[Recognize] ボタンのクリック イベント ハンドラーでインクの分析を実行します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-125">For this example, we perform the ink analysis in the click event handler of the "Recognize" button.</span></span>
    - <span data-ttu-id="e68b1-126">まず、[**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas.InkPresenter) の [**StrokeContainer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter.StrokeContainer) で [**GetStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkstrokecontainer.GetStrokes) を呼び出して、現在のインク ストロークすべてのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-126">First, call [**GetStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkstrokecontainer.GetStrokes) on the [**StrokeContainer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter.StrokeContainer) of the [**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas.InkPresenter) to get the collection of all current ink strokes.</span></span>
    - <span data-ttu-id="e68b1-127">インク ストロークが存在する場合、InkAnalyzer の [**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__) への呼び出しでそれを渡します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-127">If ink strokes are present, pass them in a call to [**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__) of the InkAnalyzer.</span></span>
    - <span data-ttu-id="e68b1-128">ここでは描画とテキストの両方を認識しようとしていますが、[**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) メソッドを使って、テキストのみを認識する (ドキュメント構造と箇条書きを含む) か、または描画のみを認識する (図形の認識を含む) かを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-128">We're trying to recognize both drawings and text, but you can use the [**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) method to specify whether you're interested only in text (including document structure and bullet lists) or only in drawings (including shape recognition).</span></span>
    - <span data-ttu-id="e68b1-129">[**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) を呼び出してインクの分析を初期化し、[**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult) を取得します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-129">Call [**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) to initiate ink analysis and get the [**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult).</span></span>
    - <span data-ttu-id="e68b1-130">[**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) が **Updated** の状態を返す場合、[**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) と [**InkAnalysisNodeKind.InkDrawing**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) の両方の [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-130">If [**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) returns a state of **Updated**, call [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) for both [**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) and [**InkAnalysisNodeKind.InkDrawing**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind).</span></span>
    - <span data-ttu-id="e68b1-131">ノードの種類の両方のセットを反復処理し、(インク キャンバスの下にある) 認識キャンバスで対応するテキストや図形を描画します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-131">Iterate through both sets of node types and draw the respective text or shape on the recognition canvas (below the ink canvas).</span></span>
    - <span data-ttu-id="e68b1-132">最後に、認識されたノードを InkAnalyzer から削除し、対応するインク ストロークをインク キャンバスから削除します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-132">Finally, delete the recognized nodes from the InkAnalyzer and the corresponding ink strokes from the ink canvas.</span></span>
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
6. <span data-ttu-id="e68b1-133">認識キャンバスに TextBlock を描画するための関数を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-133">Here's the function for drawing a TextBlock on our recognition canvas.</span></span> <span data-ttu-id="e68b1-134">位置と、TextBlock のフォント サイズを設定するのにには、インク キャンバスで関連付けられたインク ストロークの境界の四角形を使用します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-134">We use the bounding rectangle of the associated ink stroke on the ink canvas to set the position and font size of the TextBlock.</span></span>
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
7. <span data-ttu-id="e68b1-135">認識キャンバスに楕円と多角形を描画するための関数を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-135">Here are the functions for drawing ellipses and polygons on our recognition canvas.</span></span> <span data-ttu-id="e68b1-136">図形のフォント サイズと位置を設定するのにには、インク キャンバスで関連付けられたインク ストロークの境界の四角形を使用します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-136">We use the bounding rectangle of the associated ink stroke on the ink canvas to set the position and font size of the shapes.</span></span>
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

<span data-ttu-id="e68b1-137">このサンプルの動作を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-137">Here's this sample in action:</span></span>

| <span data-ttu-id="e68b1-138">分析前</span><span class="sxs-lookup"><span data-stu-id="e68b1-138">Before analysis</span></span> | <span data-ttu-id="e68b1-139">分析後</span><span class="sxs-lookup"><span data-stu-id="e68b1-139">After analysis</span></span> |
| --- | --- |
| ![分析前](images/ink/ink-analysis-raw2-small.png) | ![分析後](images/ink/ink-analysis-analyzed2-small.png) |

---
## <a name="constrained-handwriting-recognition"></a><span data-ttu-id="e68b1-142">制約付き手書き認識</span><span class="sxs-lookup"><span data-stu-id="e68b1-142">Constrained handwriting recognition</span></span>

<span data-ttu-id="e68b1-143">前のセクション ([インクの分析による自由形式の認識](#free-form-recognition-with-ink-analysis)) では、[インクの分析 API](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis) を使用して分析を行い、InkCanvas 領域内の任意のインク ストロークを認識する方法を説明しました。</span><span class="sxs-lookup"><span data-stu-id="e68b1-143">In the preceding section ([Free-form recognition with ink analysis](#free-form-recognition-with-ink-analysis)), we demonstrated how to use the [ink analysis APIs](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis) to analyze and recognize arbitrary ink strokes within an InkCanvas area.</span></span>

<span data-ttu-id="e68b1-144">このセクションでは、(インクの分析ではなく) Windows Ink 手書き認識エンジンを使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) 上の一連のストロークを、(インストールされた既定の言語パックに基づいて) テキストに変換する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-144">In this section, we demonstrate how to use the Windows Ink handwriting recognition engine (not ink analysis) to convert a set of strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) to text (based on the installed default language pack).</span></span>

> [!NOTE]
> <span data-ttu-id="e68b1-145">このセクションに示す基本的な手書き認識は、フォームの入力など、単一行のテキスト入力シナリオに最適です。</span><span class="sxs-lookup"><span data-stu-id="e68b1-145">The basic handwriting recognition shown in this section is best suited for single-line, text input scenarios such as form input.</span></span> <span data-ttu-id="e68b1-146">ドキュメント構造、リスト項目、図形、描画 (テキスト認識に加えて) の分析と解釈を含むより高度な認識シナリオの場合は、前のセクションの「[インクの分析による自由形式の認識](#free-form-recognition-with-ink-analysis)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e68b1-146">For richer recognition scenarios that include analysis and interpretation of document structure, list items, shapes, and drawings (in addition to text recognition), see the previous section: [Free-form recognition with ink analysis](#free-form-recognition-with-ink-analysis).</span></span>

<span data-ttu-id="e68b1-147">この例では、認識はユーザーが書き込みの終了を示すボタンをクリックしたときに開始されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-147">In this example, recognition is initiated when the user clicks a button to indicate they are finished writing.</span></span>

**<span data-ttu-id="e68b1-148">このサンプルは、「[Ink handwriting recognition sample](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)」(インクの手書き認識のサンプル) でダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="e68b1-148">Download this sample from [Ink handwriting recognition sample](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)</span></span>**

1.  <span data-ttu-id="e68b1-149">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-149">First, we set up the UI.</span></span>

    <span data-ttu-id="e68b1-150">UI には、[Recognize] ボタン、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、認識結果を表示する領域を用意します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-150">The UI includes a "Recognize" button, the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), and an area to display recognition results.</span></span>    

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

2. <span data-ttu-id="e68b1-151">この例では、まずインク入力機能に必要な名前空間の型参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e68b1-151">For this example, you need to first add the namespace type references required for our ink functionality:</span></span>
    - [<span data-ttu-id="e68b1-152">Windows.UI.Input</span><span class="sxs-lookup"><span data-stu-id="e68b1-152">Windows.UI.Input</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input)
    - [<span data-ttu-id="e68b1-153">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="e68b1-153">Windows.UI.Input.Inking</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)


3.  <span data-ttu-id="e68b1-154">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-154">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="e68b1-155">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-155">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="e68b1-156">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-156">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span> <span data-ttu-id="e68b1-157">[Recognize] ボタンのクリック イベントのリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-157">A listener for the click event on the "Recognize" button is also declared.</span></span>

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

4.  <span data-ttu-id="e68b1-158">最後に、基本的な手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-158">Finally, we perform the basic handwriting recognition.</span></span> <span data-ttu-id="e68b1-159">この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-159">For this example, we use the click event handler of the "Recognize" button to perform the handwriting recognition.</span></span>

    <span data-ttu-id="e68b1-160">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-160">An [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stores all ink strokes in an [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) object.</span></span> <span data-ttu-id="e68b1-161">インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-161">The strokes are exposed through the [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) property of the **InkPresenter** and retrieved using the [**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) method.</span></span>

    ```csharp
    // Get all strokes on the InkCanvas.
        IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
    ```

    <span data-ttu-id="e68b1-162">手書き認識プロセスの管理用に、[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を作成します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-162">An [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) is created to manage the handwriting recognition process.</span></span>

    ```csharp
    // Create a manager for the InkRecognizer object
        // used in handwriting recognition.
        InkRecognizerContainer inkRecognizerContainer =
            new InkRecognizerContainer();
    ```

    <span data-ttu-id="e68b1-163">[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/br208446)は[**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464)オブジェクトのセットを取得すると呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-163">[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/br208446) is called to retrieve a set of [**InkRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/br208464) objects.</span></span>

    <span data-ttu-id="e68b1-164">[**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478)によって検出された各単語の認識結果が生成されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-164">Recognition results are produced for each word that is detected by an [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478).</span></span>

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

## <a name="international-recognition"></a><span data-ttu-id="e68b1-165">地域と言語の認識</span><span class="sxs-lookup"><span data-stu-id="e68b1-165">International recognition</span></span>

<span data-ttu-id="e68b1-166">Windows のインク プラットフォームに組み込まれている手書き認識には、Windows がサポートするロケールと言語の詳細なサブセットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e68b1-166">The handwriting recognition built into the Windows ink platform includes an extensive subset of locales and languages supported by Windows.</span></span>

<span data-ttu-id="e68b1-167">[**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478) によってサポートされている言語の一覧については、[**InkRecognizer.Name**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkrecognizer.name.aspx) プロパティに関するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e68b1-167">See the [**InkRecognizer.Name**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkrecognizer.name.aspx) property topic for a list of languages supported by the [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478) .</span></span>

<span data-ttu-id="e68b1-168">アプリでは、インストール済みの一連の手書き認識エンジンを照会し、それらのいずれかを使うか、ユーザーが好きな言語を選べるようにできます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-168">Your app can query the set of installed handwriting recognition engines and use one of those, or let a user select their preferred language.</span></span>

<span data-ttu-id="e68b1-169">**注:** に移動してユーザーがインストールされている言語の一覧を表示できます**設定] -&gt;時刻と言語**します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-169">**Note** Users can see a list of installed languages by going to **Settings -&gt; Time & Language**.</span></span> <span data-ttu-id="e68b1-170">インストール済みの言語の一覧は **[言語]** に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-170">Installed languages are listed under **Languages**.</span></span>

<span data-ttu-id="e68b1-171">新しい言語パックをインストールし、その言語の手書き認識を有効にするには、次の手順に従ってください。</span><span class="sxs-lookup"><span data-stu-id="e68b1-171">To install new language packs and enable handwriting recognition for that language:</span></span>

1.  <span data-ttu-id="e68b1-172">**[設定]、[時刻と言語]、[地域と言語]** の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-172">Go to **Settings &gt; Time & language &gt; Region & language**.</span></span>
2.  <span data-ttu-id="e68b1-173">**[言語の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-173">Select **Add a language**.</span></span>
3.  <span data-ttu-id="e68b1-174">一覧で言語を選んでから、地域のバージョンを選びます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-174">Select a language from the list, then choose the region version.</span></span> <span data-ttu-id="e68b1-175">これで、選んだ言語が **[地域と言語]** ページに表示されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-175">The language is now listed on the **Region & language** page.</span></span>
4.  <span data-ttu-id="e68b1-176">言語をクリックし、**[オプション]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-176">Click the language and select **Options**.</span></span>
5.  <span data-ttu-id="e68b1-177">**[言語のオプション]** ページで、**手書き認識エンジン**をダウンロードします (完全言語パック、音声認識エンジン、キーボード レイアウトもダウンロードできます)。</span><span class="sxs-lookup"><span data-stu-id="e68b1-177">On the **Language options** page, download the **Handwriting recognition engine** (they can also download the full language pack, speech recognition engine, and keyboard layout here).</span></span>

 

<span data-ttu-id="e68b1-178">ここでは、選ばれた手書き認識エンジンを使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連のインク ストロークを解釈する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-178">Here, we demonstrate how to use the handwriting recognition engine to interpret a set of strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) based on the selected recognizer.</span></span>

<span data-ttu-id="e68b1-179">認識は、ユーザーが手書きの終了時にボタンをクリックすると開始されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-179">The recognition is initiated by the user clicking a button when they are finished writing.</span></span>

1.  <span data-ttu-id="e68b1-180">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-180">First, we set up the UI.</span></span>

    <span data-ttu-id="e68b1-181">UI には、[Recognize] ボタン、インストール済みの手書き認識エンジンの一覧を表示するコンボ ボックス、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、認識結果を表示する領域を用意します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-181">The UI includes a "Recognize" button, a combo box that lists all installed handwriting recognizers, the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), and an area to display recognition results.</span></span>
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

2.  <span data-ttu-id="e68b1-182">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-182">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="e68b1-183">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-183">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="e68b1-184">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-184">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span>

    <span data-ttu-id="e68b1-185">`InitializeRecognizerList` 関数を呼び出して、インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-185">We call an `InitializeRecognizerList` function to populate the recognizer combo box with a list of installed handwriting recognizers.</span></span>

    <span data-ttu-id="e68b1-186">また、[Recognize] ボタンのクリック イベントと認識エンジン コンボ ボックスの選択変更イベント用に、リスナーを宣言します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-186">We also declare listeners for the click event on the "Recognize" button and the selection changed event on the recognizer combo box.</span></span>
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

3.  <span data-ttu-id="e68b1-187">インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-187">We populate the recognizer combo box with a list of installed handwriting recognizers.</span></span>

    <span data-ttu-id="e68b1-188">手書き認識プロセスの管理用に、[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を作成します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-188">An [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) is created to manage the handwriting recognition process.</span></span> <span data-ttu-id="e68b1-189">このオブジェクトを使って、[**GetRecognizers**](https://msdn.microsoft.com/library/windows/apps/br208480) を呼び出し、インストール済みの手書き認識エンジンの一覧を取得して、認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-189">Use this object to call [**GetRecognizers**](https://msdn.microsoft.com/library/windows/apps/br208480) and retrieve the list of installed recognizers to populate the recognizer combo box.</span></span>
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

4.  <span data-ttu-id="e68b1-190">認識エンジン コンボ ボックスの選択が変更されていれば、手書き認識エンジンを更新します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-190">Update the handwriting recognizer if the recognizer combo box selection changes.</span></span>

    <span data-ttu-id="e68b1-191">[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を使って、認識エンジン コンボ ボックスから選ばれた認識エンジンに基づいて、[**SetDefaultRecognizer**](https://msdn.microsoft.com/library/windows/apps/hh920328) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-191">Use the [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) to call [**SetDefaultRecognizer**](https://msdn.microsoft.com/library/windows/apps/hh920328) based on the selected recognizer from the recognizer combo box.</span></span>
```csharp
// Handle recognizer change.
    private void comboInstalledRecognizers_SelectionChanged(
        object sender, SelectionChangedEventArgs e)
    {
        inkRecognizerContainer.SetDefaultRecognizer(
            (InkRecognizer)comboInstalledRecognizers.SelectedItem);
    }
```

5.  <span data-ttu-id="e68b1-192">最後に、選ばれた手書き認識エンジンに基づいて、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-192">Finally, we perform the handwriting recognition based on the selected handwriting recognizer.</span></span> <span data-ttu-id="e68b1-193">この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-193">For this example, we use the click event handler of the "Recognize" button to perform the handwriting recognition.</span></span>

    <span data-ttu-id="e68b1-194">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-194">An [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stores all ink strokes in an [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) object.</span></span> <span data-ttu-id="e68b1-195">インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-195">The strokes are exposed through the [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) property of the **InkPresenter** and retrieved using the [**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) method.</span></span>
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

## <a name="dynamic-recognition"></a><span data-ttu-id="e68b1-196">動的な認識</span><span class="sxs-lookup"><span data-stu-id="e68b1-196">Dynamic recognition</span></span>

<span data-ttu-id="e68b1-197">前の 2 つの例では、認識を開始するためのボタンをユーザーが押す必要がありましたが、ストローク入力と基本的なタイミング関数を組み合わせて使用して、動的な認識を実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-197">While, the previous two examples require the user to press a button to start recognition, you can also perform dynamic recognition using stroke input paired with a basic timing function.</span></span>

<span data-ttu-id="e68b1-198">この例では、先ほど示した地域と言語の認識の例と同じ UI とインク ストローク入力の設定を使います。</span><span class="sxs-lookup"><span data-stu-id="e68b1-198">For this example, we'll use the same UI and stroke settings as the previous international recognition example.</span></span>

1. <span data-ttu-id="e68b1-199">これらのグローバル オブジェクト ([InkAnalyzer](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalyzer)、[InkStroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkstroke)、[InkAnalysisResult](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult)、[DispatcherTimer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dispatchertimer)) は、アプリ全体で使用します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-199">These global objects ([InkAnalyzer](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalyzer), [InkStroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkstroke), [InkAnalysisResult](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult), [DispatcherTimer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dispatchertimer)) are used throughout our app.</span></span>    
```csharp
    // Stroke recognition globals.
    InkAnalyzer inkAnalyzer;
    DispatcherTimer recoTimer;
```

2.  <span data-ttu-id="e68b1-200">音声認識を開始するボタンを用意する代わりに、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) の 2 つのストローク イベント ([**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024) と [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)) のリスナーを追加し、基本的なタイマー ([**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250)) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) 間隔を 1 秒に設定します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-200">Instead of a button to initiate recognition, we add listeners for two [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stroke events ([**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024) and [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)), and set up a basic timer ([**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250)) with a one second [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) interval.</span></span>    
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

3.  <span data-ttu-id="e68b1-201">次に、最初のステップで定義した InkPresenter イベントのハンドラーを定義することができます (さらに [**OnNavigatingFrom**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.page.onnavigatingfrom) ページ イベントを上書きしてタイマーを管理します)。</span><span class="sxs-lookup"><span data-stu-id="e68b1-201">We then define the handlers for the InkPresenter events we declared in the first step (we also override the [**OnNavigatingFrom**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.page.onnavigatingfrom) page event to manage our timer).</span></span>

    - [**<span data-ttu-id="e68b1-202">StrokesCollected</span><span class="sxs-lookup"><span data-stu-id="e68b1-202">StrokesCollected</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn922024)  
    <span data-ttu-id="e68b1-203">InkAnalyzer にインク ストロークを追加 ([**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.adddataforstrokes)) し、(ユーザーがペンを持ち上げるか、マウス ボタンから指を離すことで) インク入力を止めると、認識タイマーを開始します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-203">Add ink strokes ([**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.adddataforstrokes)) to the InkAnalyzer and start the recognition timer when the user stops inking (by lifting their pen or finger, or releasing the mouse button).</span></span> <span data-ttu-id="e68b1-204">インク入力がなくなってから 1 秒後に、認識を開始します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-204">After one second of no ink input, recognition is initiated.</span></span>  

        <span data-ttu-id="e68b1-205">[**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) メソッドを使って、テキストのみを認識する (ドキュメント構造と箇条書きを含む) か、または描画のみを認識する (図形の認識を含む) かを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e68b1-205">Use the [**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.setstrokedatakind) method to specify whether you're interested only in text (including document structure amd bullet lists) or only in drawings (inlcuding shape recognition).</span></span>

    - [**<span data-ttu-id="e68b1-206">StrokeStarted</span><span class="sxs-lookup"><span data-stu-id="e68b1-206">StrokeStarted</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn914702)  
    <span data-ttu-id="e68b1-207">新しいインク ストロークが次のタイマー ティック イベントの前に始まった場合、新しいインク ストロークが同じ手書き入力の続きである可能性が高いため、タイマーを停止します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-207">If a new stroke starts before the next timer tick event, stop the timer as the new stroke is likely the continuation of a single handwriting entry.</span></span>
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

4.  <span data-ttu-id="e68b1-208">最後に、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-208">Finally, we perform the handwriting recognition.</span></span> <span data-ttu-id="e68b1-209">この例では、[**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) イベント ハンドラーを使って、手書き認識を開始します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-209">For this example, we use the [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) event handler of a [**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) to initiate the handwriting recognition.</span></span>
    - <span data-ttu-id="e68b1-210">[**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) を呼び出してインクの分析を初期化し、[**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult) を取得します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-210">Call [**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer.AnalyzeAsync) to initiate ink analysis and get the [**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult).</span></span>
    - <span data-ttu-id="e68b1-211">[**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) が **Updated** の状態を返す場合、[**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) のノードの種類の [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-211">If [**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult.Status) returns a state of **Updated**, call [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot.findnodes) for node types of  [**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind).</span></span>
    - <span data-ttu-id="e68b1-212">ノードを反復処理して、認識されたテキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-212">Iterate through the nodes and display the recognized text.</span></span>
    - <span data-ttu-id="e68b1-213">最後に、認識されたノードを InkAnalyzer から削除し、対応するインク ストロークをインク キャンバスから削除します。</span><span class="sxs-lookup"><span data-stu-id="e68b1-213">Finally, delete the recognized nodes from the InkAnalyzer and the corresponding ink strokes from the ink canvas.</span></span>
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

## <a name="related-articles"></a><span data-ttu-id="e68b1-214">関連記事</span><span class="sxs-lookup"><span data-stu-id="e68b1-214">Related articles</span></span>

* [<span data-ttu-id="e68b1-215">ペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="e68b1-215">Pen and stylus interactions</span></span>](pen-and-stylus-interactions.md)

**<span data-ttu-id="e68b1-216">トピックのサンプル</span><span class="sxs-lookup"><span data-stu-id="e68b1-216">Topic samples</span></span>**
* [<span data-ttu-id="e68b1-217">インクの分析のサンプル (基本) (C#)</span><span class="sxs-lookup"><span data-stu-id="e68b1-217">Ink analysis sample (basic) (C#)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-analysis-basic.zip)
* [<span data-ttu-id="e68b1-218">インクの手書き認識のサンプル (C#)</span><span class="sxs-lookup"><span data-stu-id="e68b1-218">Ink handwriting recognition sample (C#)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-ink-handwriting-reco.zip)

**<span data-ttu-id="e68b1-219">その他のサンプル</span><span class="sxs-lookup"><span data-stu-id="e68b1-219">Other samples</span></span>**
* [<span data-ttu-id="e68b1-220">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="e68b1-220">Simple ink sample (C#/C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="e68b1-221">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="e68b1-221">Complex ink sample (C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="e68b1-222">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="e68b1-222">Ink sample (JavaScript)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="e68b1-223">入門チュートリアル: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="e68b1-223">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="e68b1-224">塗り絵帳のサンプル</span><span class="sxs-lookup"><span data-stu-id="e68b1-224">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="e68b1-225">Family Notes のサンプル</span><span class="sxs-lookup"><span data-stu-id="e68b1-225">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)


 
