---
author: Karl-Bridge-Microsoft
Description: "インク ツールの説明"
title: "インク コントロール"
label: Inking Controls
template: detail.hbs
ms.author: kbridge
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 97eae5f3-c16b-4aa5-b4a1-dd892cf32ead
ms.openlocfilehash: 3efbda64a872a59cd1e3e5da03cd9ab896642766
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="inking-controls"></a><span data-ttu-id="6436b-104">インク コントロール</span><span class="sxs-lookup"><span data-stu-id="6436b-104">Inking controls</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="6436b-105">ユニバーサル Windows プラットフォーム (UWP) アプリでの手書き入力を容易にする、[InkCanvas](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) と [InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) という 2 つのコントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="6436b-105">There are two different controls that facilitate inking in Universal Windows Platform (UWP) apps: [InkCanvas](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) and [InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx).</span></span>

<span data-ttu-id="6436b-106">InkCanvas コントロールは、インク ストローク (色と太さの既定の設定を使用) か消去ストロークのいずれかとしてペン入力をレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="6436b-106">The InkCanvas control renders pen input as either an ink stroke (using default settings for color and thickness) or an erase stroke.</span></span> <span data-ttu-id="6436b-107">このコントロールは透明なオーバーレイで、インク ストロークの既定のプロパティを変更するための組み込みの UI は含まれていません。</span><span class="sxs-lookup"><span data-stu-id="6436b-107">This control is a transparent overlay that doesn't include any built-in UI for changing the default ink stroke properties.</span></span>

> [!NOTE]
> <span data-ttu-id="6436b-108">InkCanvas は、マウス入力とタッチ入力の両方に似たような機能をサポートするように構成できます。</span><span class="sxs-lookup"><span data-stu-id="6436b-108">InkCanvas can be configured to support similar functionality for both mouse and touch input.</span></span>

<span data-ttu-id="6436b-109">InkCanvas コントロールにはインク ストロークの既定の設定を変更するためのサポートは含まれていないため、InkToolbar コントロールと組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="6436b-109">As the InkCanvas control does not include support for changing the default ink stroke settings, it can be paired with an InkToolbar control.</span></span> <span data-ttu-id="6436b-110">InkToolbar には、関連付けられた InkCanvas のインク関連機能をアクティブ化する、カスタマイズと拡張が可能なボタンのコレクションが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6436b-110">The InkToolbar contains a customizable and extensible collection of buttons that activate ink-related features in an associated InkCanvas.</span></span>

<span data-ttu-id="6436b-111">既定では、InkToolbar には、描画、消去、強調表示、ルーラー表示のボタンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6436b-111">By default, the InkToolbar includes buttons for drawing, erasing, highlighting, and displaying a ruler.</span></span> <span data-ttu-id="6436b-112">機能に応じて、インクの色、ストロークの太さ、すべてのインクの消去など、他の設定やコマンドがポップアップに表示されます。</span><span class="sxs-lookup"><span data-stu-id="6436b-112">Depending on the feature, other settings and commands, such as ink color, stroke thickness, erase all ink, are provided in a flyout.</span></span>

> [!NOTE]
> <span data-ttu-id="6436b-113">InkToolbar は、ペン入力とマウス入力をサポートしていますが、タッチ入力を認識するように構成することもできます。</span><span class="sxs-lookup"><span data-stu-id="6436b-113">InkToolbar supports pen and mouse input and can be configured to recognize touch input.</span></span>

<img src="images/ink-tools-invoked-toolbar.png" width="300" alt="InkToolbar palette flyout">

> <span data-ttu-id="6436b-114">**重要な API**: [InkCanvas クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx)、[InkToolbar クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)、[InkPresenter クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx)、[Windows.UI.Input.Inking](https://msdn.microsoft.com/library/windows/apps/br208524)</span><span class="sxs-lookup"><span data-stu-id="6436b-114">**Important APIs**: [InkCanvas class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx), [InkToolbar class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx), [InkPresenter class](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx), [Windows.UI.Input.Inking](https://msdn.microsoft.com/library/windows/apps/br208524)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="6436b-115">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="6436b-115">Is this the right control?</span></span>

<span data-ttu-id="6436b-116">ユーザーにインク設定を提供せずに、アプリで基本的な手書き入力機能を有効にする必要がある場合、InkCanvas を使います。</span><span class="sxs-lookup"><span data-stu-id="6436b-116">Use the InkCanvas when you need to enable basic inking features in your app without providing any ink settings to the user.</span></span>

<span data-ttu-id="6436b-117">既定では、ストロークはペン先 (太さ 2 ピクセルの黒のボールペン) を使うときはインクとしてレンダリングされ、消しゴム ボタンを使うときは消しゴムとしてレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="6436b-117">By default, strokes are rendered as ink when using the pen tip (a black ballpoint pen with a thickness of 2 pixels) and as an eraser when using the eraser tip.</span></span> <span data-ttu-id="6436b-118">消しゴム ボタンがない場合は、ペン先からの入力を消去ストロークとして処理するように InkCanvas を構成できます。</span><span class="sxs-lookup"><span data-stu-id="6436b-118">If an eraser tip is not present, the InkCanvas can be configured to process input from the pen tip as an erase stroke.</span></span>

<span data-ttu-id="6436b-119">インク機能をアクティブ化し、ストロークのサイズ、色、ペン先の形状などの基本的なインクのプロパティを設定するための UI を提供するには、InkCanvas と InkToolbar を組み合わせます。</span><span class="sxs-lookup"><span data-stu-id="6436b-119">Pair the InkCanvas with an InkToolbar to provide a UI for activating ink features and setting basic ink properties such as stroke size, color, and shape of the pen tip.</span></span>

> [!NOTE] 
> <span data-ttu-id="6436b-120">InkCanvas でのインク ストロークのレンダリングに対する幅広いカスタマイズについては、基になる [InkPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx) オブジェクトを使ってください。</span><span class="sxs-lookup"><span data-stu-id="6436b-120">For more extensive customization of ink stroke rendering on an InkCanvas, use the underlying [InkPresenter](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx) object.</span></span>

## <a name="examples"></a><span data-ttu-id="6436b-121">例</span><span class="sxs-lookup"><span data-stu-id="6436b-121">Examples</span></span>

**<span data-ttu-id="6436b-122">Microsoft Edge</span><span class="sxs-lookup"><span data-stu-id="6436b-122">Microsoft Edge</span></span>**

<span data-ttu-id="6436b-123">Edge ブラウザーでは、**Web ノート**に InkCanvas と InkToolbar を使います。</span><span class="sxs-lookup"><span data-stu-id="6436b-123">The Edge browser uses the InkCanvas and InkToolbar for **Web Notes**.</span></span>  
![InkCanvas は Microsoft Edge で手書き入力するために使います。](images/ink-tools-edge.png)

**<span data-ttu-id="6436b-125">Windows Ink ワークスペース</span><span class="sxs-lookup"><span data-stu-id="6436b-125">Windows Ink Workspace</span></span>**

<span data-ttu-id="6436b-126">InkCanvas と InkToolbar は、**Windows Ink ワークスペース**の**スケッチパッド**と**画面スケッチ**の両方にも使われます。</span><span class="sxs-lookup"><span data-stu-id="6436b-126">The InkCanvas and InkToolbar are also used for both **Sketchpad** and **Screen sketch** in the **Windows Ink Workspace**.</span></span>  
![Windows Ink ワークスペースの InkToolbar](images/ink-tools-ink-workspace.png)

## <a name="create-an-inkcanvas-and-inktoolbar"></a><span data-ttu-id="6436b-128">InkCanvas と InkToolbar を作成する</span><span class="sxs-lookup"><span data-stu-id="6436b-128">Create an InkCanvas and InkToolbar</span></span>

<span data-ttu-id="6436b-129">アプリに InkCanvas を追加するには、次に示す 1 行のマークアップが必要です。</span><span class="sxs-lookup"><span data-stu-id="6436b-129">Adding an InkCanvas to your app requires just one line of markup:</span></span>

```xaml
<InkCanvas x:Name=“myInkCanvas”/>
```

> [!NOTE]
> <span data-ttu-id="6436b-130">InkPresenter 使った InkCanvas のカスタマイズについて詳しくは、「["UWP アプリのペン操作とスタイラス操作"](http://windowsstyleguide/input-and-devices/pen-and-stylus-interactions/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6436b-130">For detailed InkCanvas customization using InkPresenter, see the ["Pen and stylus interactions in UWP apps"](http://windowsstyleguide/input-and-devices/pen-and-stylus-interactions/) article.</span></span>

<span data-ttu-id="6436b-131">InkToolbar コントロールは、InkCanvas と組み合わせて使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6436b-131">The InkToolbar control must be used in conjunction with an InkCanvas.</span></span> <span data-ttu-id="6436b-132">InkToolbar (組み込みのすべてのツールが含まれています) をアプリに組み込むには、さらに次の 1 行のマークアップを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6436b-132">Incorporating an InkToolbar (with all built-in tools) into your app requires one additional line of markup:</span></span>

 ```xaml
<InkToolbar TargetInkCanvas=“{x:Bind myInkCanvas}”/>
 ```

<span data-ttu-id="6436b-133">これにより、次のような InkToolbar が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6436b-133">This displays the following InkToolbar:</span></span>
<img src="images/ink-tools-uninvoked-toolbar.png" width="250" alt="Basic InkToolbar">

### <a name="built-in-buttons"></a><span data-ttu-id="6436b-134">組み込みのボタン</span><span class="sxs-lookup"><span data-stu-id="6436b-134">Built-in buttons</span></span>

<span data-ttu-id="6436b-135">InkToolbar には、次に示す組み込みのボタンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6436b-135">The InkToolbar includes the following built-in buttons:</span></span>

**<span data-ttu-id="6436b-136">ペン</span><span class="sxs-lookup"><span data-stu-id="6436b-136">Pens</span></span>**

- <span data-ttu-id="6436b-137">ボールペン - 丸いペン先で単色の不透明なストロークを描画します。</span><span class="sxs-lookup"><span data-stu-id="6436b-137">Ballpoint pen - draws a solid, opaque stroke with a circle pen tip.</span></span> <span data-ttu-id="6436b-138">ストロークのサイズは、感知された筆圧に依存します。</span><span class="sxs-lookup"><span data-stu-id="6436b-138">The stroke size is dependent on the pen pressure detected.</span></span>
- <span data-ttu-id="6436b-139">鉛筆 - 丸いペン先で、輪郭がぼやけている、テクスチャが適用された、半透明のストローク (階層化された網かけ効果に役立ちます) を描画します。</span><span class="sxs-lookup"><span data-stu-id="6436b-139">Pencil - draws a soft-edged, textured, and semi-transparent stroke (useful for layered shading effects) with a circle pen tip.</span></span> <span data-ttu-id="6436b-140">ストロークの色 (濃さ) は、感知された筆圧に依存します。</span><span class="sxs-lookup"><span data-stu-id="6436b-140">The stroke color (darkness) is dependent on the pen pressure detected.</span></span>
- <span data-ttu-id="6436b-141">蛍光ペン – 四角形のペン先で半透明のストロークを描画します。</span><span class="sxs-lookup"><span data-stu-id="6436b-141">Highlighter – draws a semi-transparent stroke with a rectangle pen tip.</span></span>

<span data-ttu-id="6436b-142">各ペンのポップアップで、カラー パレットとサイズの属性 (最小、最大、既定) の両方をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="6436b-142">You can customize both the color palette and size attributes (min, max, default) in the flyout for each pen.</span></span>

**<span data-ttu-id="6436b-143">ツール</span><span class="sxs-lookup"><span data-stu-id="6436b-143">Tool</span></span>**

- <span data-ttu-id="6436b-144">消しゴム – タッチされたインク ストロークを削除します。</span><span class="sxs-lookup"><span data-stu-id="6436b-144">Eraser – deletes any ink stroke touched.</span></span> <span data-ttu-id="6436b-145">消しゴムのストロークの下にある部分だけではなく、インク ストローク全体が削除されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6436b-145">Note that the entire ink stroke is deleted, not just the portion under the eraser stroke.</span></span>

**<span data-ttu-id="6436b-146">トグル</span><span class="sxs-lookup"><span data-stu-id="6436b-146">Toggle</span></span>**

- <span data-ttu-id="6436b-147">ルーラー – ルーラーの表示/非表示を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="6436b-147">Ruler – shows or hides the ruler.</span></span> <span data-ttu-id="6436b-148">ルーラーの端付近で描画すると、インク ストロークがルーラーにスナップされます。</span><span class="sxs-lookup"><span data-stu-id="6436b-148">Drawing near the ruler edge causes the ink stroke to snap to the ruler.</span></span>  
 ![InkToolbar に関連付けられたルーラーの外観](images/inking-tools-ruler.png)

<span data-ttu-id="6436b-150">これは既定の構成ですが、お使いのアプリの InkToolbar にどの組み込みのボタンが含めるかを完全に制御できます。</span><span class="sxs-lookup"><span data-stu-id="6436b-150">Although this is the default configuration, you have complete control over which built-in buttons are included in the InkToolbar for your app.</span></span>

### <a name="custom-buttons"></a><span data-ttu-id="6436b-151">カスタム ボタン</span><span class="sxs-lookup"><span data-stu-id="6436b-151">Custom buttons</span></span>

<span data-ttu-id="6436b-152">InkToolbar は、次のような 2 つの異なるボタンの種類のグループで構成されます。</span><span class="sxs-lookup"><span data-stu-id="6436b-152">The InkToolbar consists of two distinct groups of button types:</span></span>

1. <span data-ttu-id="6436b-153">"ツール" ボタンのグループ。組み込みの描画ボタン、消去ボタン、強調表示ボタンが含まれます。</span><span class="sxs-lookup"><span data-stu-id="6436b-153">A group of "tool" buttons containing the built-in drawing, erasing, and highlighting buttons.</span></span> <span data-ttu-id="6436b-154">カスタム ペンとカスタム ツールはここに追加されます。</span><span class="sxs-lookup"><span data-stu-id="6436b-154">Custom pens and tools are added here.</span></span>
> [!NOTE]
> <span data-ttu-id="6436b-155">機能の選択は相互に排他的です。</span><span class="sxs-lookup"><span data-stu-id="6436b-155">Feature selection is mutually exclusive.</span></span>

2. <span data-ttu-id="6436b-156">"トグル" ボタンのグループ。組み込みのルーラー ボタンが含まれます。</span><span class="sxs-lookup"><span data-stu-id="6436b-156">A group of "toggle" buttons containing the built-in ruler button.</span></span> <span data-ttu-id="6436b-157">カスタム トグルはここに追加されます。</span><span class="sxs-lookup"><span data-stu-id="6436b-157">Custom toggles are added here.</span></span>
> [!NOTE]
> <span data-ttu-id="6436b-158">機能は相互に排他的ではないので、他のアクティブなツールと同時に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="6436b-158">Features are not mutually exclusive and can be used concurrently with other active tools.</span></span>

<span data-ttu-id="6436b-159">お使いのアプリケーションと必要なインク機能によって異なりますが、InkToolbar には次のボタン (カスタムの手書き入力機能にバインドされます) を追加できます。</span><span class="sxs-lookup"><span data-stu-id="6436b-159">Depending on your application and the inking functionality required, you can add any of the following buttons (bound to your custom ink features) to the InkToolbar:</span></span>

- <span data-ttu-id="6436b-160">カスタム ペン – インクのカラー パレットやペン先のプロパティ (形状、回転、サイズなど) がホスト アプリで定義されるペン。</span><span class="sxs-lookup"><span data-stu-id="6436b-160">Custom pen – a pen for which the ink color palette and pen tip properties, such as shape, rotation, and size, are defined by the host app.</span></span>
- <span data-ttu-id="6436b-161">カスタム ツール – ホスト アプリで定義されるペン不使用ツール。</span><span class="sxs-lookup"><span data-stu-id="6436b-161">Custom tool – a non-pen tool, defined by the host app.</span></span>
- <span data-ttu-id="6436b-162">カスタム トグル – アプリで定義された機能の状態をオンまたはオフに設定します。</span><span class="sxs-lookup"><span data-stu-id="6436b-162">Custom toggle – Sets the state of an app-defined feature to on or off.</span></span> <span data-ttu-id="6436b-163">オンにすると、機能はアクティブなツールと連携して動作します。</span><span class="sxs-lookup"><span data-stu-id="6436b-163">When turned on, the feature works in conjunction with the active tool.</span></span>

> [!NOTE]
> <span data-ttu-id="6436b-164">組み込みのボタンの表示順序を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="6436b-164">You cannot change the display order of the built-in buttons.</span></span> <span data-ttu-id="6436b-165">既定の表示順序は、ボールペン、鉛筆、蛍光ペン、消しゴム、ルーラーです。</span><span class="sxs-lookup"><span data-stu-id="6436b-165">The default display order is: Ballpoint pen, pencil, highlighter, eraser, and ruler.</span></span> <span data-ttu-id="6436b-166">カスタム ペンは最後の既定のペンに追加され、カスタム ツール ボタンは最後のペン ボタンと消しゴム ボタンの間に追加され、カスタム トグル ボタンはルーラー ボタンの後に追加されます </span><span class="sxs-lookup"><span data-stu-id="6436b-166">Custom pens are appended to the last default pen, custom tool buttons are added between the last pen button and the eraser button and custom toggle buttons are added after the ruler button.</span></span> <span data-ttu-id="6436b-167">(カスタム ボタンは、指定されている順序で追加されます)。</span><span class="sxs-lookup"><span data-stu-id="6436b-167">(Custom buttons are added in the order they are specified.)</span></span>

<span data-ttu-id="6436b-168">InkToolbar はトップ レベルの項目にすることもできますが、通常は "手書き入力" ボタンまたはコマンドを使って公開されます。</span><span class="sxs-lookup"><span data-stu-id="6436b-168">Although the InkToolbar can be a top level item, it is typically exposed through an “Inking” button or command.</span></span> <span data-ttu-id="6436b-169">Segoe MLD2 アセット フォントの EE56 グリフをトップ レベルのアイコンとして使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6436b-169">We recommend using EE56 glyph from the Segoe MLD2 Assets font as a top level icon.</span></span>

## <a name="inktoolbar-interaction"></a><span data-ttu-id="6436b-170">InkToolbar の操作</span><span class="sxs-lookup"><span data-stu-id="6436b-170">InkToolbar Interaction</span></span>

<span data-ttu-id="6436b-171">組み込みのすべてのペン ボタンとツール ボタンには、インクのプロパティと、ペン先の形状とサイズを設定できるポップアップ メニューが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6436b-171">All built-in pen and tool buttons include a flyout menu where ink properties and pen tip shape and size can be set.</span></span> <span data-ttu-id="6436b-172">ポップアップがあることを示すために、ボタンには "拡張グリフ" </span><span class="sxs-lookup"><span data-stu-id="6436b-172">An "extension glyph"</span></span> ![InkToolbar グリフ](images/ink-tools-glyph.png) <span data-ttu-id="6436b-174"> が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6436b-174">is displayed on the button to indicate the existence of the flyout.</span></span>

<span data-ttu-id="6436b-175">ポップアップは、アクティブなツールのボタンが再選択されたときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="6436b-175">The flyout is shown when the button of an active tool is selected again.</span></span> <span data-ttu-id="6436b-176">色やサイズが変更されると、ポップアップは自動的に閉じられ、手書き入力を再開できます。</span><span class="sxs-lookup"><span data-stu-id="6436b-176">When the color or size is changed, the flyout is automatically dismissed and inking can be resumed.</span></span> <span data-ttu-id="6436b-177">カスタム ペンやカスタム ツールでは、既定のポップアップを使うことも、カスタム ポップアップを指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="6436b-177">Custom pens and tools can use the default flyout or specify a custom flyout.</span></span>

<span data-ttu-id="6436b-178">また、消しゴムには **[すべてのインクのデータを消去]** コマンドを提供するポップアップがあります。</span><span class="sxs-lookup"><span data-stu-id="6436b-178">The eraser also has a flyout that provides the **Erase All Ink** command.</span></span>  
![消しゴムのポップアップが呼び出された InkToolbar](images/ink-tools-erase-all-ink.png)

 <span data-ttu-id="6436b-180">カスタマイズと拡張について詳しくは、[SimpleInk のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6436b-180">For information on customization and extensibility, check out [SimpleInk sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk).</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="6436b-181">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="6436b-181">Do's and don'ts</span></span>

- <span data-ttu-id="6436b-182">InkCanvas と手書き入力全般は、アクティブなペンを通じて最適なエクスペリエンスを実現します。</span><span class="sxs-lookup"><span data-stu-id="6436b-182">The InkCanvas, and inking in general, is best experienced through an active pen.</span></span> <span data-ttu-id="6436b-183">ただし、アプリで必要な場合は、マウスとタッチ (パッシブ ペンを含む) の入力による手書き入力をサポートすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6436b-183">However, we recommend supporting inking with mouse and touch (including passive pen) input if required by your app.</span></span>
- <span data-ttu-id="6436b-184">手書き入力の基本的な機能と設定を提供するには、InkToolbar コントロールと InkCanvas を使います。</span><span class="sxs-lookup"><span data-stu-id="6436b-184">Use an InkToolbar control with the InkCanvas to provide basic inking features and settings.</span></span> <span data-ttu-id="6436b-185">InkCanvas と InkToolbar は共に、プログラムでカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="6436b-185">Both the InkCanvas and InkToolbar can be programmatically customized.</span></span>
- <span data-ttu-id="6436b-186">InkToolbar と手書き入力全般は、アクティブなペンを通じて最適なエクスペリエンスを実現します。</span><span class="sxs-lookup"><span data-stu-id="6436b-186">The InkToolbar, and inking in general, is best experienced through an active pen.</span></span> <span data-ttu-id="6436b-187">ただし、アプリで必要な場合は、マウスやタッチによる手書き入力をサポートできます。</span><span class="sxs-lookup"><span data-stu-id="6436b-187">However, inking with mouse and touch can be supported if required by your app.</span></span>
- <span data-ttu-id="6436b-188">タッチ入力による手書き入力をサポートする場合、トグル ボタンに Segoe MLD2 アセット フォントの ED5F アイコンを使うと共に、"タッチによる手書き" というヒントを表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6436b-188">If supporting inking with touch input, we recommend using the ED5F icon from the Segoe MLD2 Assets font for the toggle button, with a “Touch writing” tooltip.</span></span>
- <span data-ttu-id="6436b-189">ストローク選択を提供する場合は、「選択ツール」ツールチップを使用して、ツール ボタンの Segoe MLD2 アセット フォントの EF20 アイコンを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6436b-189">If providing stroke selection, we recommend using the EF20 icon from the Segoe MLD2 Assets font for the tool button, with a “Selection tool” tooltip.</span></span>
- <span data-ttu-id="6436b-190">複数の InkCanvas を使う場合、1 つの InkToolbar を使ってキャンバス間の手書き入力を制御することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6436b-190">If using more than one InkCanvas, we recommend using a single InkToolbar to control inking across canvases.</span></span>
- <span data-ttu-id="6436b-191">最高のパフォーマンスを得るには、既定のツールとカスタム ツールの両方にカスタム ポップアップを作成するのではなく、既定のポップアップを変更することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6436b-191">For best performance, we recommend altering the default flyout rather than creating a custom one for both default and custom tools.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="6436b-192">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="6436b-192">Get the sample code</span></span>

<span data-ttu-id="6436b-193">[SimpleInk のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk)では、InkCanvas コントロールと InkToolbar コントロールのカスタマイズ機能と拡張機能に関する 8 個のシナリオを示しています。</span><span class="sxs-lookup"><span data-stu-id="6436b-193">[SimpleInk sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk) demonstrates 8 scenarios around the customization and extensibility capabilities of the InkCanvas and InkToolbar controls.</span></span> <span data-ttu-id="6436b-194">各シナリオでは、一般的な手書き入力の状況とコントロールの実装に関する基本的なガイダンスが提供されています。</span><span class="sxs-lookup"><span data-stu-id="6436b-194">Each scenario provides basic guidance on common inking situations and control implementations.</span></span>

<span data-ttu-id="6436b-195">高度な手書き入力のサンプルについては、[ComplexInk のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ComplexInk)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6436b-195">For a more advanced inking sample, see [ComplexInk sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ComplexInk).</span></span>

## <a name="related-articles"></a><span data-ttu-id="6436b-196">関連記事</span><span class="sxs-lookup"><span data-stu-id="6436b-196">Related articles</span></span>

- [<span data-ttu-id="6436b-197">UWP アプリのペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="6436b-197">Pen and stylus interactions in UWP apps</span></span>](http://windowsstyleguide/input-and-devices/pen-and-stylus-interactions/)
- [<span data-ttu-id="6436b-198">インク ストロークの認識</span><span class="sxs-lookup"><span data-stu-id="6436b-198">Recognize ink strokes</span></span>](http://windowsstyleguide/input-and-devices/convert-ink-to-text/)
- [<span data-ttu-id="6436b-199">インク ストロークの保存と取得</span><span class="sxs-lookup"><span data-stu-id="6436b-199">Store and retrieve ink strokes</span></span>](http://windowsstyleguide/input-and-devices/save-and-load-ink/)
