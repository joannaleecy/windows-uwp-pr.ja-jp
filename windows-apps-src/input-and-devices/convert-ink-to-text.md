---
author: Karl-Bridge-Microsoft
Description: "Windows Ink のストロークをテキストおよび図形として認識するのには、手書き認識とインクの分析を使います。"
title: "Windows Ink のストロークをテキストおよび図形として認識する"
ms.assetid: C2F3F3CE-737F-4652-98B7-5278A462F9D3
label: Recognize Windows Ink strokes as text
template: detail.hbs
keywords: "Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, 手書き認識, ユーザー操作, 入力"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 973d8a49df92a0514263459d3b974a7d39166d4e
ms.sourcegitcommit: 14db5eecd035a42bf3b25ea80ba479532c328b32
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/16/2017
---
# <a name="recognize-windows-ink-strokes-as-text-and-shapes"></a><span data-ttu-id="7bcc9-104">Windows Ink のストロークをテキストおよび図形として認識する</span><span class="sxs-lookup"><span data-stu-id="7bcc9-104">Recognize Windows Ink strokes as text and shapes</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="7bcc9-105">Windows Ink に組み込まれている認識機能により、インク ストロークをテキストと図形に変換します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-105">Convert ink strokes to text and shapes using the recognition capabilities built into Windows Ink.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="7bcc9-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="7bcc9-106">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="7bcc9-107">InkCanvas</span><span class="sxs-lookup"><span data-stu-id="7bcc9-107">InkCanvas</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn858535)</li>
<li>[**<span data-ttu-id="7bcc9-108">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="7bcc9-108">Windows.UI.Input.Inking</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208524)</li>
</ul>
</div> 

## <a name="free-form-recognition-with-ink-analysis"></a><span data-ttu-id="7bcc9-109">インクの分析による自由形式の認識</span><span class="sxs-lookup"><span data-stu-id="7bcc9-109">Free-form recognition with ink analysis</span></span>

<span data-ttu-id="7bcc9-110">ここでは、Windows Ink の分析エンジン ([Windows.UI.Input.Inking.Analysis](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連の自由形式のストロークを分類、分析し、テキストまたは図形として認識する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-110">Here, we demonstrate how to use the Windows Ink analysis engine ([Windows.UI.Input.Inking.Analysis](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)) to classify, analyze, and recognize a set of free-form strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) as either text or shapes.</span></span> <span data-ttu-id="7bcc9-111">(テキストおよび図形の認識に加えて、ドキュメント構造、箇条書き、および汎用的な描画の認識にもインクの分析を使うことができます。)</span><span class="sxs-lookup"><span data-stu-id="7bcc9-111">(In addition to text and shape recognition, ink analysis can also be used to recognize document structure, bullet lists, and generic drawings.)</span></span>

> [!NOTE]
> <span data-ttu-id="7bcc9-112">フォーム入力など、基本的な単一行のプレーン テキスト シナリオの場合、後述の「[制約付き手書き認識](#constrained-handwriting-recognition)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-112">For basic, single-line, plain text scenarios such as form input, see [Constrained handwriting recognition](#constrained-handwriting-recognition) later in this topic.</span></span>

<span data-ttu-id="7bcc9-113">この例では、認識はユーザーが描画の終了を示すボタンをクリックしたときに開始されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-113">In this example, recognition is initiated when the user clicks a button to indicate they are finished drawing.</span></span>

1.  <span data-ttu-id="7bcc9-114">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-114">First, we set up the UI.</span></span>

    <span data-ttu-id="7bcc9-115">UI には、[Recognize] ボタン、[**InkCanvas**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.InkCanvas)、標準的な [**Canvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas) があります。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-115">The UI includes a "Recognize" button, an [**InkCanvas**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.InkCanvas), and a standard [**Canvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.canvas).</span></span> <span data-ttu-id="7bcc9-116">[Recognize] ボタンが押されると、インク キャンバスにおけるすべてのインク ストロークが分析され、(認識された場合は) 対応する図形とテキストが標準のキャンバスに描画されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-116">When the "Recognize" button is pressed, all ink strokes on the ink canvas are analyzed and (if recognized) corresponding shapes and text are drawn on the standard canvas.</span></span> <span data-ttu-id="7bcc9-117">次に、元のインク ストロークがインク キャンバスから削除されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-117">The original ink strokes are then deleted from the ink canvas.</span></span>
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
2. <span data-ttu-id="7bcc9-118">この例では、まずインクとインク分析機能に必要な名前空間の型参照を UI 分離コード ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-118">For this example, we first add the namespace type references required for our ink and ink analysis functionality to the UI code-behind file:</span></span>
    - [<span data-ttu-id="7bcc9-119">Windows.UI.Input</span><span class="sxs-lookup"><span data-stu-id="7bcc9-119">Windows.UI.Input</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input)
    - [<span data-ttu-id="7bcc9-120">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="7bcc9-120">Windows.UI.Input.Inking</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)
    - [<span data-ttu-id="7bcc9-121">Windows.UI.Input.Inking.Analysis</span><span class="sxs-lookup"><span data-stu-id="7bcc9-121">Windows.UI.Input.Inking.Analysis</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis)
    - [<span data-ttu-id="7bcc9-122">Windows.Storage.Streams</span><span class="sxs-lookup"><span data-stu-id="7bcc9-122">Windows.Storage.Streams</span></span>](https://docs.microsoft.com/uwp/api/windows.storage.streams)

3. <span data-ttu-id="7bcc9-123">その後、グローバル変数を指定します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-123">We then specify our global variables:</span></span>
``` csharp
    InkAnalyzer inkAnalyzer = new InkAnalyzer();
    IReadOnlyList<InkStroke> inkStrokes = null;
    InkAnalysisResult inkAnalysisResults = null;
```
4.  <span data-ttu-id="7bcc9-124">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-124">Next, we set some basic ink input behaviors:</span></span>
    - <span data-ttu-id="7bcc9-125">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペン、マウス、タッチからの入力データをインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-125">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from pen, mouse, and touch as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> 
    - <span data-ttu-id="7bcc9-126">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-126">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span> 
    - <span data-ttu-id="7bcc9-127">[Recognize] ボタンのクリック イベントのリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-127">A listener for the click event on the "Recognize" button is also declared.</span></span>
``` csharp
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
5.  <span data-ttu-id="7bcc9-128">この例では、[Recognize] ボタンのクリック イベント ハンドラーでインクの分析を実行します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-128">For this example, we perform the ink analysis in the click event handler of the "Recognize" button.</span></span>
    - <span data-ttu-id="7bcc9-129">まず、[**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas#Windows_UI_Xaml_Controls_InkCanvas_InkPresenter) の [**StrokeContainer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter#Windows_UI_Input_Inking_InkPresenter_StrokeContainer) で [**GetStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkstrokecontainer#Windows_UI_Input_Inking_InkStrokeContainer_GetStrokes) を呼び出して、現在のインク ストロークすべてのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-129">First, call [**GetStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkstrokecontainer#Windows_UI_Input_Inking_InkStrokeContainer_GetStrokes) on the [**StrokeContainer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter#Windows_UI_Input_Inking_InkPresenter_StrokeContainer) of the [**InkCanvas.InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.inkcanvas#Windows_UI_Xaml_Controls_InkCanvas_InkPresenter) to get the collection of all current ink strokes.</span></span>
    - <span data-ttu-id="7bcc9-130">インク ストロークが存在する場合、InkAnalyzer の [**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__) への呼び出しでそれを渡します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-130">If ink strokes are present, pass them in a call to [**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__) of the InkAnalyzer.</span></span>
    - <span data-ttu-id="7bcc9-131">ここでは描画とテキストの両方を認識しようとしていますが、[**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_SetStrokeDataKind_System_UInt32_Windows_UI_Input_Inking_Analysis_InkAnalysisStrokeKind_) プロパティを使って、テキストのみを認識する (ドキュメント構造と箇条書きを含む) か、または描画のみを認識する (図形の認識を含む) かを指定することができます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-131">We're trying to recognize both drawings and text, but you can use the [**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_SetStrokeDataKind_System_UInt32_Windows_UI_Input_Inking_Analysis_InkAnalysisStrokeKind_) property to specify whether you're interested only in text (including document structure amd bullet lists) or only in drawings (inlcuding shape recognition).</span></span>
    - <span data-ttu-id="7bcc9-132">[**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AnalyzeAsync) を呼び出してインクの分析を初期化し、[**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult) を取得します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-132">Call [**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AnalyzeAsync) to initiate ink analysis and get the [**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult).</span></span>
    - <span data-ttu-id="7bcc9-133">[**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult#Windows_UI_Input_Inking_Analysis_InkAnalysisResult_Status) が **Updated** の状態を返す場合、[**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) と [**InkAnalysisNodeKind.InkDrawing**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) の両方の [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot#Windows_UI_Input_Inking_Analysis_InkAnalysisRoot_FindNodes_Windows_UI_Input_Inking_Analysis_InkAnalysisNodeKind_) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-133">If [**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult#Windows_UI_Input_Inking_Analysis_InkAnalysisResult_Status) returns a state of **Updated**, call [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot#Windows_UI_Input_Inking_Analysis_InkAnalysisRoot_FindNodes_Windows_UI_Input_Inking_Analysis_InkAnalysisNodeKind_) for both [**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) and [**InkAnalysisNodeKind.InkDrawing**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind).</span></span>
    - <span data-ttu-id="7bcc9-134">ノードの種類の両方のセットを反復処理し、(インク キャンバスの下にある) 認識キャンバスで対応するテキストや図形を描画します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-134">Iterate through both sets of node types and draw the respective text or shape on the recognition canvas (below the ink canvas).</span></span>
    - <span data-ttu-id="7bcc9-135">最後に、認識されたノードを InkAnalyzer から削除し、対応するインク ストロークをインク キャンバスから削除します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-135">Finally, delete the recognized nodes from the InkAnalyzer and the corresponding ink strokes from the ink canvas.</span></span>
``` csharp
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
6. <span data-ttu-id="7bcc9-136">認識キャンバスに TextBlock を描画するための関数を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-136">Here's the function for drawing a TextBlock on our recognition canvas.</span></span> <span data-ttu-id="7bcc9-137">TextBlock の位置とフォント サイズを設定するには、インク キャンバスで関連付けられたインク ストロークの境界の四角形を使います。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-137">We use the the bounding rectangle of the associated ink stroke on the ink canvas to set the position and font size of the TextBlock.</span></span>
``` csharp
    // Draw text on the recognitionCanvas.
    private void DrawText(string recognizedText, Rect boundingRect)
    {
        TextBlock text = new TextBlock();
        TranslateTransform translateTransform = new TranslateTransform();
        TransformGroup transformGroup = new TransformGroup();

        translateTransform.X = boundingRect.Left;
        translateTransform.Y = boundingRect.Top;
        transformGroup.Children.Add(translateTransform);
        text.RenderTransform = transformGroup;

        text.Text = recognizedText;
        text.FontSize = boundingRect.Height;

        recognitionCanvas.Children.Add(text);
    }
```
7. <span data-ttu-id="7bcc9-138">認識キャンバスに楕円と多角形を描画するための関数を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-138">Here are the functions for drawing ellipses and polygons on our recognition canvas.</span></span> <span data-ttu-id="7bcc9-139">図形の位置とフォント サイズを設定するには、インク キャンバスで関連付けられたインク ストロークの境界の四角形を使います。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-139">We use the the bounding rectangle of the associated ink stroke on the ink canvas to set the position and font size of the shapes.</span></span>
``` csharp
    // Draw an ellipse on the recognitionCanvas.
    private void DrawEllipse(InkAnalysisInkDrawing shape)
    {
        var points = shape.Points;
        Ellipse ellipse = new Ellipse();
        ellipse.Width = Math.Sqrt((points[0].X - points[2].X) * (points[0].X - points[2].X) +
                (points[0].Y - points[2].Y) * (points[0].Y - points[2].Y));
        ellipse.Height = Math.Sqrt((points[1].X - points[3].X) * (points[1].X - points[3].X) +
                (points[1].Y - points[3].Y) * (points[1].Y - points[3].Y));

        var rotAngle = Math.Atan2(points[2].Y - points[0].Y, points[2].X - points[0].X);
        RotateTransform rotateTransform = new RotateTransform();
        rotateTransform.Angle = rotAngle * 180 / Math.PI;
        rotateTransform.CenterX = ellipse.Width / 2.0;
        rotateTransform.CenterY = ellipse.Height / 2.0;

        TranslateTransform translateTransform = new TranslateTransform();
        translateTransform.X = shape.Center.X - ellipse.Width / 2.0;
        translateTransform.Y = shape.Center.Y - ellipse.Height / 2.0;

        TransformGroup transformGroup = new TransformGroup();
        transformGroup.Children.Add(rotateTransform);
        transformGroup.Children.Add(translateTransform);
        ellipse.RenderTransform = transformGroup;

        var brush = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 0, 0, 255));
        ellipse.Stroke = brush;
        ellipse.StrokeThickness = 2;
        recognitionCanvas.Children.Add(ellipse);
    }

    // Draw a polygon on the recognitionCanvas.
    private void DrawPolygon(InkAnalysisInkDrawing shape)
    {
        var points = shape.Points;
        Polygon polygon = new Polygon();

        foreach (var point in points)
        {
            polygon.Points.Add(point);
        }

        var brush = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 0, 0, 255));
        polygon.Stroke = brush;
        polygon.StrokeThickness = 2;
        recognitionCanvas.Children.Add(polygon);
    }
```

<span data-ttu-id="7bcc9-140">このサンプルの動作を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-140">Here's this sample in action:</span></span>

| <span data-ttu-id="7bcc9-141">分析前</span><span class="sxs-lookup"><span data-stu-id="7bcc9-141">Before analysis</span></span> | <span data-ttu-id="7bcc9-142">分析後</span><span class="sxs-lookup"><span data-stu-id="7bcc9-142">After analysis</span></span> |
| --- | --- |
| ![分析前](images\ink\ink-analysis-raw2-small.png) | ![分析後](images\ink\ink-analysis-analyzed2-small.png) |

## <a name="constrained-handwriting-recognition"></a><span data-ttu-id="7bcc9-145">制約付き手書き認識</span><span class="sxs-lookup"><span data-stu-id="7bcc9-145">Constrained handwriting recognition</span></span>

<span data-ttu-id="7bcc9-146">前のセクション ([インクの分析による自由形式の認識](#free-form-recognition-with-ink-analysis)) では、[インクの分析 API](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis) を使用して分析を行い、InkCanvas 領域内の任意のインク ストロークを認識する方法を説明しました。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-146">In the preceding section ([Free-form recognition with ink analysis](#free-form-recognition-with-ink-analysis)), we demonstrated how to use the [ink analysis APIs](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis) to analyze and recognize arbitrary ink strokes within an InkCanvas area.</span></span>

<span data-ttu-id="7bcc9-147">このセクションでは、(インクの分析ではなく) Windows Ink 手書き認識エンジンを使って [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) 上の一連のストロークを (インストールされた既定の言語パックに基づいて) テキストに変換する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-147">In this section, we demonstrate how to use the Windows Ink handwriting recognition engine (not ink analysis) to try to convert a set of strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) to text (based on the installed default language pack).</span></span>

> [!NOTE]
> <span data-ttu-id="7bcc9-148">このセクションに示す基本的な手書き認識は、フォームの入力など、簡単な単一行のプレーン テキスト シナリオに最適です。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-148">The basic handwriting recognition shown in this section is best suited for straightforward, single-line, plain text scenarios such as form input.</span></span> <span data-ttu-id="7bcc9-149">ドキュメント構造、リスト項目、図形、描画 (テキスト認識に加えて) の分析と解釈を含むより高度な認識シナリオの場合は、前のセクションの「[インクの分析による自由形式の認識](#free-form-recognition-with-ink-analysis)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-149">For richer recognition scenarios that include analysis and interpretation of document structure, list items, shapes, and drawings (in addition to text recognition), see the previous section: [Free-form recognition with ink analysis](#free-form-recognition-with-ink-analysis).</span></span>

<span data-ttu-id="7bcc9-150">この例では、認識はユーザーが書き込みの終了を示すボタンをクリックしたときに開始されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-150">In this example, recognition is initiated when the user clicks a button to indicate they are finished writing.</span></span>

1.  <span data-ttu-id="7bcc9-151">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-151">First, we set up the UI.</span></span>

    <span data-ttu-id="7bcc9-152">UI には、[Recognize] ボタン、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、認識結果を表示する領域を用意します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-152">The UI includes a "Recognize" button, the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), and an area to display recognition results.</span></span>    
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

2. <span data-ttu-id="7bcc9-153">この例では、まずインク入力機能に必要な名前空間の型参照を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-153">For this example, you need to first add the namespace type references required for our ink functionality:</span></span>
    - [<span data-ttu-id="7bcc9-154">Windows.UI.Input</span><span class="sxs-lookup"><span data-stu-id="7bcc9-154">Windows.UI.Input</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input)
    - [<span data-ttu-id="7bcc9-155">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="7bcc9-155">Windows.UI.Input.Inking</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)


3.  <span data-ttu-id="7bcc9-156">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-156">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="7bcc9-157">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-157">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="7bcc9-158">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-158">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span> <span data-ttu-id="7bcc9-159">[Recognize] ボタンのクリック イベントのリスナーも宣言します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-159">A listener for the click event on the "Recognize" button is also declared.</span></span>
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

4.  <span data-ttu-id="7bcc9-160">最後に、基本的な手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-160">Finally, we perform the basic handwriting recognition.</span></span> <span data-ttu-id="7bcc9-161">この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-161">For this example, we use the click event handler of the "Recognize" button to perform the handwriting recognition.</span></span>

    <span data-ttu-id="7bcc9-162">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-162">An [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stores all ink strokes in an [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) object.</span></span> <span data-ttu-id="7bcc9-163">インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-163">The strokes are exposed through the [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) property of the **InkPresenter** and retrieved using the [**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) method.</span></span>
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

## <a name="international-recognition"></a><span data-ttu-id="7bcc9-164">地域と言語の認識</span><span class="sxs-lookup"><span data-stu-id="7bcc9-164">International recognition</span></span>

<span data-ttu-id="7bcc9-165">Windows のインク プラットフォームに組み込まれている手書き認識には、Windows がサポートするロケールと言語の詳細なサブセットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-165">The handwriting recognition built into the Windows ink platform includes an extensive subset of locales and languages supported by Windows.</span></span>

<span data-ttu-id="7bcc9-166">[**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478) によってサポートされている言語の一覧については、[**InkRecognizer.Name**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkrecognizer.name.aspx) プロパティに関するトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-166">See the [**InkRecognizer.Name**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkrecognizer.name.aspx) property topic for a list of languages supported by the [**InkRecognizer**](https://msdn.microsoft.com/library/windows/apps/br208478) .</span></span>

<span data-ttu-id="7bcc9-167">アプリでは、インストール済みの一連の手書き認識エンジンを照会し、それらのいずれかを使うか、ユーザーが好きな言語を選べるようにできます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-167">Your app can query the set of installed handwriting recognition engines and use one of those, or let a user select their preferred language.</span></span>

**<span data-ttu-id="7bcc9-168">注意</span><span class="sxs-lookup"><span data-stu-id="7bcc9-168">Note</span></span>**  
<span data-ttu-id="7bcc9-169">ユーザーは **[設定]、[時刻と言語]** の順に移動することで、インストール済みの言語の一覧を表示できます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-169">Users can see a list of installed languages by going to **Settings -&gt; Time & Language**.</span></span> <span data-ttu-id="7bcc9-170">インストール済みの言語の一覧は **[言語]** に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-170">Installed languages are listed under **Languages**.</span></span>

<span data-ttu-id="7bcc9-171">新しい言語パックをインストールし、その言語の手書き認識を有効にするには、次の手順に従ってください。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-171">To install new language packs and enable handwriting recognition for that language:</span></span>

1.  <span data-ttu-id="7bcc9-172">**[設定]、[時刻と言語]、[地域と言語]** の順に移動します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-172">Go to **Settings &gt; Time & language &gt; Region & language**.</span></span>
2.  <span data-ttu-id="7bcc9-173">**[言語の追加]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-173">Select **Add a language**.</span></span>
3.  <span data-ttu-id="7bcc9-174">一覧で言語を選んでから、地域のバージョンを選びます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-174">Select a language from the list, then choose the region version.</span></span> <span data-ttu-id="7bcc9-175">これで、選んだ言語が **[地域と言語]** ページに表示されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-175">The language is now listed on the **Region & language** page.</span></span>
4.  <span data-ttu-id="7bcc9-176">言語をクリックし、**[オプション]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-176">Click the language and select **Options**.</span></span>
5.  <span data-ttu-id="7bcc9-177">**[言語のオプション]** ページで、**手書き認識エンジン**をダウンロードします (完全言語パック、音声認識エンジン、キーボード レイアウトもダウンロードできます)。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-177">On the **Language options** page, download the **Handwriting recognition engine** (they can also download the full language pack, speech recognition engine, and keyboard layout here).</span></span>

 

<span data-ttu-id="7bcc9-178">ここでは、選ばれた手書き認識エンジンを使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) での一連のインク ストロークを解釈する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-178">Here, we demonstrate how to use the handwriting recognition engine to interpret a set of strokes on an [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) based on the selected recognizer.</span></span>

<span data-ttu-id="7bcc9-179">認識は、ユーザーが手書きの終了時にボタンをクリックすると開始されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-179">The recognition is initiated by the user clicking a button when they are finished writing.</span></span>

1.  <span data-ttu-id="7bcc9-180">まず、UI を設定します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-180">First, we set up the UI.</span></span>

    <span data-ttu-id="7bcc9-181">UI には、[Recognize] ボタン、インストール済みの手書き認識エンジンの一覧を表示するコンボ ボックス、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)、認識結果を表示する領域を用意します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-181">The UI includes a "Recognize" button, a combo box that lists all installed handwriting recognizers, the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535), and an area to display recognition results.</span></span>
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

2.  <span data-ttu-id="7bcc9-182">次に、基本的なインク入力の動作をいくつか設定します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-182">We then set some basic ink input behaviors.</span></span>

    <span data-ttu-id="7bcc9-183">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、ペンとマウスのいずれからの入力データもインク ストローク ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)) として解釈するように構成します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-183">The [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) is configured to interpret input data from both pen and mouse as ink strokes ([**InputDeviceTypes**](https://msdn.microsoft.com/library/windows/apps/dn922019)).</span></span> <span data-ttu-id="7bcc9-184">インク ストロークは、指定した [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050) を使って、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-184">Ink strokes are rendered on the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) using the specified [**InkDrawingAttributes**](https://msdn.microsoft.com/library/windows/desktop/ms695050).</span></span>

    <span data-ttu-id="7bcc9-185">`InitializeRecognizerList` 関数を呼び出して、インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-185">We call an `InitializeRecognizerList` function to populate the recognizer combo box with a list of installed handwriting recognizers.</span></span>

    <span data-ttu-id="7bcc9-186">また、[Recognize] ボタンのクリック イベントと認識エンジン コンボ ボックスの選択変更イベント用に、リスナーを宣言します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-186">We also declare listeners for the click event on the "Recognize" button and the selection changed event on the recognizer combo box.</span></span>
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

3.  <span data-ttu-id="7bcc9-187">インストール済みの手書き認識エンジンの一覧を認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-187">We populate the recognizer combo box with a list of installed handwriting recognizers.</span></span>

    <span data-ttu-id="7bcc9-188">手書き認識プロセスの管理用に、[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を作成します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-188">An [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) is created to manage the handwriting recognition process.</span></span> <span data-ttu-id="7bcc9-189">このオブジェクトを使って、[**GetRecognizers**](https://msdn.microsoft.com/library/windows/apps/br208480) を呼び出し、インストール済みの手書き認識エンジンの一覧を取得して、認識エンジン コンボ ボックスに入れます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-189">Use this object to call [**GetRecognizers**](https://msdn.microsoft.com/library/windows/apps/br208480) and retrieve the list of installed recognizers to populate the recognizer combo box.</span></span>
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

4.  <span data-ttu-id="7bcc9-190">認識エンジン コンボ ボックスの選択が変更されていれば、手書き認識エンジンを更新します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-190">Update the handwriting recognizer if the recognizer combo box selection changes.</span></span>

    <span data-ttu-id="7bcc9-191">[**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) を使って、認識エンジン コンボ ボックスから選ばれた認識エンジンに基づいて、[**SetDefaultRecognizer**](https://msdn.microsoft.com/library/windows/apps/hh920328) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-191">Use the [**InkRecognizerContainer**](https://msdn.microsoft.com/library/windows/apps/br208479) to call [**SetDefaultRecognizer**](https://msdn.microsoft.com/library/windows/apps/hh920328) based on the selected recognizer from the recognizer combo box.</span></span>
```    CSharp
// Handle recognizer change.
    private void comboInstalledRecognizers_SelectionChanged(
        object sender, SelectionChangedEventArgs e)
    {
        inkRecognizerContainer.SetDefaultRecognizer(
            (InkRecognizer)comboInstalledRecognizers.SelectedItem);
    }
```

5.  <span data-ttu-id="7bcc9-192">最後に、選ばれた手書き認識エンジンに基づいて、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-192">Finally, we perform the handwriting recognition based on the selected handwriting recognizer.</span></span> <span data-ttu-id="7bcc9-193">この例では、[Recognize] ボタンのクリック イベント ハンドラーを使って、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-193">For this example, we use the click event handler of the "Recognize" button to perform the handwriting recognition.</span></span>

    <span data-ttu-id="7bcc9-194">[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってすべてのインク ストロークが [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) オブジェクトに格納されます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-194">An [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stores all ink strokes in an [**InkStrokeContainer**](https://msdn.microsoft.com/library/windows/apps/br208492) object.</span></span> <span data-ttu-id="7bcc9-195">インク ストロークを **InkPresenter** の [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) プロパティを介して公開し、[**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) メソッドを使って取得します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-195">The strokes are exposed through the [**StrokeContainer**](https://msdn.microsoft.com/library/windows/apps/dn948766) property of the **InkPresenter** and retrieved using the [**GetStrokes**](https://msdn.microsoft.com/library/windows/apps/br208499) method.</span></span>
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

## <a name="dynamic-recognition"></a><span data-ttu-id="7bcc9-196">動的な認識</span><span class="sxs-lookup"><span data-stu-id="7bcc9-196">Dynamic recognition</span></span>

<span data-ttu-id="7bcc9-197">前の 2 つの例では、認識を開始するためのボタンをユーザーが押す必要がありましたが、ストローク入力と基本的なタイミング関数を組み合わせて使用して、動的な認識を実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-197">While, the previous two examples require the user to press a button to start recognition, you can also perform dynamic recognition using stroke input paired with a basic timing function.</span></span>

<span data-ttu-id="7bcc9-198">この例では、先ほど示した地域と言語の認識の例と同じ UI とインク ストローク入力の設定を使います。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-198">For this example, we'll use the same UI and stroke settings as the previous international recognition example.</span></span>

1. <span data-ttu-id="7bcc9-199">これらのグローバル オブジェクト ([InkAnalyzer](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalyzer)、[InkStroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkstroke)、[InkAnalysisResult](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult)、[DispatcherTimer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dispatchertimer)) は、アプリ全体で使用します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-199">These global objects ([InkAnalyzer](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalyzer), [InkStroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkstroke), [InkAnalysisResult](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult), [DispatcherTimer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.dispatchertimer)) are used throughout our app.</span></span>    
```csharp
    // Stroke recognition globals.
    InkAnalyzer inkAnalyzer;
    DispatcherTimer recoTimer;
```

2.  <span data-ttu-id="7bcc9-200">音声認識を開始するボタンを用意する代わりに、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) の 2 つのストローク イベント ([**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024) と [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)) のリスナーを追加し、基本的なタイマー ([**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250)) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) 間隔を 1 秒に設定します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-200">Instead of a button to initiate recognition, we add listeners for two [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) stroke events ([**StrokesCollected**](https://msdn.microsoft.com/library/windows/apps/dn922024) and [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702)), and set up a basic timer ([**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250)) with a one second [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) interval.</span></span>    
``` csharp
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

3.  <span data-ttu-id="7bcc9-201">次に、最初のステップで定義した InkPresenter イベントのハンドラーを定義することができます (さらに [**OnNavigatingFrom**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page#Windows_UI_Xaml_Controls_Page_OnNavigatingFrom_Windows_UI_Xaml_Navigation_NavigatingCancelEventArgs_) ページ イベントを上書きしてタイマーを管理します)。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-201">We then define the handlers for the InkPresenter events we declared in the first step (we also override the [**OnNavigatingFrom**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.page#Windows_UI_Xaml_Controls_Page_OnNavigatingFrom_Windows_UI_Xaml_Navigation_NavigatingCancelEventArgs_) page event to manage our timer).</span></span>

    - [**<span data-ttu-id="7bcc9-202">StrokesCollected</span><span class="sxs-lookup"><span data-stu-id="7bcc9-202">StrokesCollected</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn922024)  
    <span data-ttu-id="7bcc9-203">InkAnalyzer にインク ストロークを追加 ([**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__)) し、(ユーザーがペンを持ち上げるか、マウス ボタンから指を離すことで) インク入力を止めると、認識タイマーを開始します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-203">Add ink strokes ([**AddDataForStrokes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AddDataForStrokes_Windows_Foundation_Collections_IIterable_Windows_UI_Input_Inking_InkStroke__)) to the InkAnalyzer and start the recognition timer when the user stops inking (by lifting their pen or finger, or releasing the mouse button).</span></span> <span data-ttu-id="7bcc9-204">インク入力がなくなってから 1 秒後に、認識を開始します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-204">After one second of no ink input, recognition is initiated.</span></span>  

        <span data-ttu-id="7bcc9-205">[**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_SetStrokeDataKind_System_UInt32_Windows_UI_Input_Inking_Analysis_InkAnalysisStrokeKind_) プロパティを使って、テキストのみを認識する (ドキュメント構造と箇条書きを含む) か、または描画のみを認識する (図形の認識を含む) かを指定することができます。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-205">Use the [**SetStrokeDataKind**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_SetStrokeDataKind_System_UInt32_Windows_UI_Input_Inking_Analysis_InkAnalysisStrokeKind_) property to specify whether you're interested only in text (including document structure amd bullet lists) or only in drawings (inlcuding shape recognition).</span></span>

    - [**<span data-ttu-id="7bcc9-206">StrokeStarted</span><span class="sxs-lookup"><span data-stu-id="7bcc9-206">StrokeStarted</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn914702)  
    <span data-ttu-id="7bcc9-207">新しいインク ストロークが次のタイマー ティック イベントの前に始まった場合、新しいインク ストロークが同じ手書き入力の続きである可能性が高いため、タイマーを停止します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-207">If a new stroke starts before the next timer tick event, stop the timer as the new stroke is likely the continuation of a single handwriting entry.</span></span>
``` csharp
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

4.  <span data-ttu-id="7bcc9-208">最後に、手書き認識を実行します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-208">Finally, we perform the handwriting recognition.</span></span> <span data-ttu-id="7bcc9-209">この例では、[**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) の [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) イベント ハンドラーを使って、手書き認識を開始します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-209">For this example, we use the [**Tick**](https://msdn.microsoft.com/library/windows/apps/br244256) event handler of a [**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) to initiate the handwriting recognition.</span></span>
    - <span data-ttu-id="7bcc9-210">[**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AnalyzeAsync) を呼び出してインクの分析を初期化し、[**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult) を取得します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-210">Call [**AnalyzeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalyzer#Windows_UI_Input_Inking_Analysis_InkAnalyzer_AnalyzeAsync) to initiate ink analysis and get the [**InkAnalysisResult**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult).</span></span>
    - <span data-ttu-id="7bcc9-211">[**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult#Windows_UI_Input_Inking_Analysis_InkAnalysisResult_Status) が **Updated** の状態を返す場合、[**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind) のノードの種類の [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot#Windows_UI_Input_Inking_Analysis_InkAnalysisRoot_FindNodes_Windows_UI_Input_Inking_Analysis_InkAnalysisNodeKind_) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-211">If [**Status**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisresult#Windows_UI_Input_Inking_Analysis_InkAnalysisResult_Status) returns a state of **Updated**, call [**FindNodes**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisroot#Windows_UI_Input_Inking_Analysis_InkAnalysisRoot_FindNodes_Windows_UI_Input_Inking_Analysis_InkAnalysisNodeKind_) for node types of  [**InkAnalysisNodeKind.InkWord**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis.inkanalysisnodekind).</span></span>
    - <span data-ttu-id="7bcc9-212">ノードを反復処理して、認識されたテキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-212">Iterate through the nodes and display the recognized text.</span></span>
    - <span data-ttu-id="7bcc9-213">最後に、認識されたノードを InkAnalyzer から削除し、対応するインク ストロークをインク キャンバスから削除します。</span><span class="sxs-lookup"><span data-stu-id="7bcc9-213">Finally, delete the recognized nodes from the InkAnalyzer and the corresponding ink strokes from the ink canvas.</span></span>
``` csharp
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

## <a name="related-articles"></a><span data-ttu-id="7bcc9-214">関連記事</span><span class="sxs-lookup"><span data-stu-id="7bcc9-214">Related articles</span></span>

* [<span data-ttu-id="7bcc9-215">ペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="7bcc9-215">Pen and stylus interactions</span></span>](pen-and-stylus-interactions.md)

**<span data-ttu-id="7bcc9-216">サンプル</span><span class="sxs-lookup"><span data-stu-id="7bcc9-216">Samples</span></span>**
* [<span data-ttu-id="7bcc9-217">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="7bcc9-217">Simple ink sample (C#/C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="7bcc9-218">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="7bcc9-218">Complex ink sample (C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="7bcc9-219">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="7bcc9-219">Ink sample (JavaScript)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="7bcc9-220">入門チュートリアル: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="7bcc9-220">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="7bcc9-221">塗り絵帳のサンプル</span><span class="sxs-lookup"><span data-stu-id="7bcc9-221">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="7bcc9-222">Family Notes のサンプル</span><span class="sxs-lookup"><span data-stu-id="7bcc9-222">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)


 
