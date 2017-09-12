---
author: Karl-Bridge-Microsoft
Description: "既定の InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手描き入力アプリに追加し、カスタム ペン ボタンを InkToolbar に追加して、カスタム ペン ボタンをカスタム ペン定義にバインドします。"
title: "InkToolbar をユニバーサル Windows プラットフォーム (UWP) アプリに追加する"
label: Add an InkToolbar to a Universal Windows Platform (UWP) app
template: detail.hbs
keywords: "Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, InkToolbar, ユニバーサル Windows プラットフォーム, UWP, ユーザー操作, 入力"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: d888f75f-c2a0-4134-81db-907b5e24fcc5
ms.openlocfilehash: a4bff46c2ab0f0f1f9a689f2744c9a77ac90630d
ms.sourcegitcommit: c519e3d34bef37f87bb44f02b295187849bb5eea
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/25/2017
---
# <a name="add-an-inktoolbar-to-a-universal-windows-platform-uwp-app"></a><span data-ttu-id="b7907-104">InkToolbar をユニバーサル Windows プラットフォーム (UWP) アプリに追加する</span><span class="sxs-lookup"><span data-stu-id="b7907-104">Add an InkToolbar to a Universal Windows Platform (UWP) app</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">


<span data-ttu-id="b7907-105">ユニバーサル Windows プラットフォーム (UWP) アプリでの手書き入力を容易にする、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) と [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) という 2 つのコントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="b7907-105">There are two different controls that facilitate inking in Universal Windows Platform (UWP) apps: [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) and [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx).</span></span>

<span data-ttu-id="b7907-106">[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) コントロールには、基本的な Windows Ink 機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="b7907-106">The [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx) control provides basic Windows Ink functionality.</span></span> <span data-ttu-id="b7907-107">このコントロールを使用して、ペン入力をインク ストローク (色と太さの既定の設定を使う) か消去ストロークとしてレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="b7907-107">Use it to render pen input as either an ink stroke (using default settings for color and thickness) or an erase stroke.</span></span>

> <span data-ttu-id="b7907-108">InkCanvas の実装について詳しくは、「[UWP アプリのペン操作とスタイラス操作](pen-and-stylus-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7907-108">For InkCanvas implementation details, see [Pen and stylus interactions in UWP apps](pen-and-stylus-interactions.md).</span></span>

<span data-ttu-id="b7907-109">InkCanvas は、完全に透明なオーバーレイであるため、インク ストロークのプロパティを設定するための UI は組み込まれていません。</span><span class="sxs-lookup"><span data-stu-id="b7907-109">As a completely transparent overlay, the InkCanvas does not provide any built-in UI for setting ink stroke properties.</span></span> <span data-ttu-id="b7907-110">既定の手書き入力エクスペリエンスを変更する場合、ユーザーがインク ストロークのプロパティを設定し、その他のカスタムの手書き入力機能を使用できるようにします。これには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="b7907-110">If you want to change the default inking experience, let users set ink stroke properties, and support other custom inking features, you have two options:</span></span>

- <span data-ttu-id="b7907-111">コード ビハインドで、InkCanvas にバインドされている、基になる [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx) オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="b7907-111">In code-behind, use the underlying [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx) object bound to the InkCanvas.</span></span>

  <span data-ttu-id="b7907-112">InkPresenter API では、手書き入力エクスペリエンスのさまざまなカスタマイズをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b7907-112">The InkPresenter APIs support extensive customization of the inking experience.</span></span> <span data-ttu-id="b7907-113">詳しくは、「[UWP アプリのペン操作とスタイラス操作](pen-and-stylus-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7907-113">For more detail, see [Pen and stylus interactions in UWP apps](pen-and-stylus-interactions.md).</span></span>

- <span data-ttu-id="b7907-114">[**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) を InkCanvas にバインドします。</span><span class="sxs-lookup"><span data-stu-id="b7907-114">Bind an [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) to the InkCanvas.</span></span> <span data-ttu-id="b7907-115">既定では、InkToolbar には、インク機能をアクティブ化し、ストロークのサイズ、インクの色、ペン先の形状などのインク関連のプロパティを設定できる、カスタマイズ可能で拡張可能なボタンのコレクションが用意されています。</span><span class="sxs-lookup"><span data-stu-id="b7907-115">By default, the InkToolbar provides a customizable and extensible collection of buttons for activating ink-related features such as stroke size, ink color, and pen tip.</span></span>

  <span data-ttu-id="b7907-116">ここでは、InkToolbar について説明します。</span><span class="sxs-lookup"><span data-stu-id="b7907-116">We discuss the InkToolbar in this topic.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="b7907-117">重要な API</span><span class="sxs-lookup"><span data-stu-id="b7907-117">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="b7907-118">InkCanvas クラス</span><span class="sxs-lookup"><span data-stu-id="b7907-118">InkCanvas class</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inkcanvas.aspx)</li>
<li>[**<span data-ttu-id="b7907-119">InkToolbar クラス</span><span class="sxs-lookup"><span data-stu-id="b7907-119">InkToolbar class</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)</li>
<li>[**<span data-ttu-id="b7907-120">InkPresenter クラス</span><span class="sxs-lookup"><span data-stu-id="b7907-120">InkPresenter class</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkpresenter.aspx)</li>
<li>[**<span data-ttu-id="b7907-121">Windows.UI.Input.Inking</span><span class="sxs-lookup"><span data-stu-id="b7907-121">Windows.UI.Input.Inking</span></span>**](https://msdn.microsoft.com/library/windows/apps/br208524)</li>
</ul>
</div>

## <a name="default-inktoolbar"></a><span data-ttu-id="b7907-122">既定の InkToolbar</span><span class="sxs-lookup"><span data-stu-id="b7907-122">Default InkToolbar</span></span>

<span data-ttu-id="b7907-123">既定では、[**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) には、描画、消去、強調表示、ステンシルの表示 (ルーラーまたは分度器) のボタンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b7907-123">By default, the [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) includes buttons for drawing, erasing, highlighting, and displaying a stencil (ruler or protractor).</span></span> <span data-ttu-id="b7907-124">機能に応じて、インクの色、ストロークの太さ、すべてのインクの消去など、他の設定やコマンドがポップアップに表示されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-124">Depending on the feature, other settings and commands, such as ink color, stroke thickness, erase all ink, are provided in a flyout.</span></span>

![InkToolbar](.\images\ink\ink-tools-invoked-toolbar-small.png)  
*<span data-ttu-id="b7907-126">既定の Windows Ink ツール バー</span><span class="sxs-lookup"><span data-stu-id="b7907-126">Default Windows Ink toolbar</span></span>*

<span data-ttu-id="b7907-127">既定の [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) を手描き入力のアプリに追加するには、[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) と同じページに配置して、2 つのコントロールを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="b7907-127">To add a default [**InkToolbar**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inktoolbar) to an inking app, just place it on the same page as your [**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) and associate the two controls.</span></span>

1. <span data-ttu-id="b7907-128">MainPage.xaml で、手書き入力面のコンテナー オブジェクト (ここでは Grid コントロールを使用します) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="b7907-128">In MainPage.xaml, declare a container object (for this example, we use a Grid control) for the inking surface.</span></span>
2. <span data-ttu-id="b7907-129">コンテナーの子として InkCanvas オブジェクトを宣言します </span><span class="sxs-lookup"><span data-stu-id="b7907-129">Declare an InkCanvas object as a child of the container.</span></span> <span data-ttu-id="b7907-130">(InkCanvas サイズはコンテナーから継承されます)。</span><span class="sxs-lookup"><span data-stu-id="b7907-130">(The InkCanvas size is inherited from the container.)</span></span>
3. <span data-ttu-id="b7907-131">InkToolbar を宣言し、TargetInkCanvas 属性を使用して InkCanvas にバインドします。</span><span class="sxs-lookup"><span data-stu-id="b7907-131">Declare an InkToolbar and use the TargetInkCanvas attribute to bind it to the InkCanvas.</span></span>
    > [!NOTE]  
    > <span data-ttu-id="b7907-132">InkToolbar が InkCanvas の後で宣言されるようにします。</span><span class="sxs-lookup"><span data-stu-id="b7907-132">Ensure the InkToolbar is declared after the InkCanvas.</span></span> <span data-ttu-id="b7907-133">そうでなければ、InkCanvas オーバーレイで InkToolbar にアクセスできなくなります。</span><span class="sxs-lookup"><span data-stu-id="b7907-133">If not, the InkCanvas overlay renders the InkToolbar inaccessible.</span></span>

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header"
                   Text="Basic ink sample"
                   Style="{ThemeResource HeaderTextBlockStyle}"
                   Margin="10,0,0,0" />
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <InkCanvas x:Name="inkCanvas" />
        <InkToolbar x:Name="inkToolbar"
          VerticalAlignment="Top"
          TargetInkCanvas="{x:Bind inkCanvas}" />
    </Grid>
</Grid>
```

## <a name="basic-customization"></a><span data-ttu-id="b7907-134">基本的なカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="b7907-134">Basic customization</span></span>

<span data-ttu-id="b7907-135">このセクションでは、Windows Ink ツール バーの基本的なカスタマイズに関するシナリオについて説明します。</span><span class="sxs-lookup"><span data-stu-id="b7907-135">In this section, we cover some basic Windows Ink toolbar customization scenarios.</span></span>

### <a name="specify-the-selected-button"></a><span data-ttu-id="b7907-136">選択されるボタンを指定する</span><span class="sxs-lookup"><span data-stu-id="b7907-136">Specify the selected button</span></span>  
![初期化時に鉛筆ボタンが選択される](.\images\ink\ink-tools-default-toolbar.png)  
*<span data-ttu-id="b7907-138">Windows Ink ツール バーで初期化時に鉛筆ボタンが選択される</span><span class="sxs-lookup"><span data-stu-id="b7907-138">Windows Ink toolbar with pencil button selected at initialization</span></span>*

<span data-ttu-id="b7907-139">既定では、アプリが起動し、ツール バーが初期化されると、最初 (または左端) のボタンが選択されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-139">By default, the first (or leftmost) button is selected when your app is launched and the toolbar is initialized.</span></span> <span data-ttu-id="b7907-140">既定の Windows Ink ツール バーでは、ボールペン ボタンが選択されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-140">In the default Windows Ink toolbar, this is the ballpoint pen button.</span></span>

<span data-ttu-id="b7907-141">フレームワークで組み込みのボタンの順序が定義されるため、最初のボタンが既定でアクティブ化したいペンやツールでない場合があります。</span><span class="sxs-lookup"><span data-stu-id="b7907-141">Because the framework defines the order of the built-in buttons, the first button might not be the pen or tool you want to activate by default.</span></span>

<span data-ttu-id="b7907-142">この既定の動作を上書きし、ツール バーで選択されるボタンを指定できます。</span><span class="sxs-lookup"><span data-stu-id="b7907-142">You can override this default behavior and specify the selected button on the toolbar.</span></span>

<span data-ttu-id="b7907-143">ここでは、(ボールペンではなく) 鉛筆ボタンが選択され、鉛筆がアクティブになるように、既定のツール バーを初期化します。</span><span class="sxs-lookup"><span data-stu-id="b7907-143">For this example, we initialize the default toolbar with the pencil button selected and the pencil activated (instead of the ballpoint pen).</span></span>

1. <span data-ttu-id="b7907-144">前の例から、InkCanvas と InkToolbar の XAML 宣言を使用します。</span><span class="sxs-lookup"><span data-stu-id="b7907-144">Use the XAML declaration for the InkCanvas and InkToolbar from the previous example.</span></span>
2. <span data-ttu-id="b7907-145">コード ビハインドで、[InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) オブジェクトの [Loaded](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loaded.aspx) イベントのハンドラーを設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-145">In code-behind, set up a handler for the [Loaded](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loaded.aspx) event of the [InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) object.</span></span>

  ```csharp
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// Here, we set up InkToolbar event listeners.
  /// </summary>
  public MainPage_CodeBehind()
  {
      this.InitializeComponent();
      // Add handlers for InkToolbar events.
      inkToolbar.Loaded += inkToolbar_Loaded;
  }
  ```

3. <span data-ttu-id="b7907-146">[Loaded](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loaded.aspx) イベントのハンドラーで次の処理を行います。</span><span class="sxs-lookup"><span data-stu-id="b7907-146">In the handler for the [Loaded](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loaded.aspx) event:</span></span>
  1. <span data-ttu-id="b7907-147">組み込みの [InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx) への参照を取得します。</span><span class="sxs-lookup"><span data-stu-id="b7907-147">Get a reference to the built-in [InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx).</span></span>

    <span data-ttu-id="b7907-148">[GetToolButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.gettoolbutton.aspx) メソッドで [InkToolbarTool.Pencil](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbartool.aspx) オブジェクトを渡すことで、[InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx) の [InkToolbarToolButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbartoolbutton.aspx) オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-148">Passing an [InkToolbarTool.Pencil](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbartool.aspx) object in the [GetToolButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.gettoolbutton.aspx) method returns an [InkToolbarToolButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbartoolbutton.aspx) object for the [InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx).</span></span>

  2. <span data-ttu-id="b7907-149">前の手順で返されたオブジェクトに [ActiveTool](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.activetool.aspx) を設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-149">Set [ActiveTool](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.activetool.aspx) to the object returned in the previous step.</span></span>

```CSharp
/// <summary>
/// Handle the Loaded event of the InkToolbar.
/// By default, the active tool is set to the first tool on the toolbar.
/// Here, we set the active tool to the pencil button.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void inkToolbar_Loaded(object sender, RoutedEventArgs e)
{
    InkToolbarToolButton pencilButton = inkToolbar.GetToolButton(InkToolbarTool.Pencil);
    inkToolbar.ActiveTool = pencilButton;
}
```

### <a name="specify-the-built-in-buttons"></a><span data-ttu-id="b7907-150">組み込みのボタンを指定する</span><span class="sxs-lookup"><span data-stu-id="b7907-150">Specify the built-in buttons</span></span>

![初期化時に特定のボタンが含まれる](.\images\ink\ink-tools-specific.png)  
*<span data-ttu-id="b7907-152">初期化時に特定のボタンが含まれる</span><span class="sxs-lookup"><span data-stu-id="b7907-152">Specific buttons included at initialization</span></span>*

<span data-ttu-id="b7907-153">既に説明したように、Windows Ink ツール バーには既定の組み込みボタンのコレクションが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b7907-153">As mentioned, the Windows Ink toolbar includes a collection of default, built-in buttons.</span></span> <span data-ttu-id="b7907-154">これらのボタンは次の順序で (左から右に) 表示されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-154">These buttons are displayed in the following order (from left to right):</span></span>

- [<span data-ttu-id="b7907-155">InkToolbarBallpointPenButton</span><span class="sxs-lookup"><span data-stu-id="b7907-155">InkToolbarBallpointPenButton</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx)
- [<span data-ttu-id="b7907-156">InkToolbarPencilButton</span><span class="sxs-lookup"><span data-stu-id="b7907-156">InkToolbarPencilButton</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx)
- [<span data-ttu-id="b7907-157">InkToolbarHighlighterButton</span><span class="sxs-lookup"><span data-stu-id="b7907-157">InkToolbarHighlighterButton</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarhighlighterbutton.aspx)
- [<span data-ttu-id="b7907-158">InkToolbarEraserButton</span><span class="sxs-lookup"><span data-stu-id="b7907-158">InkToolbarEraserButton</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx)
- [<span data-ttu-id="b7907-159">InkToolbarRulerButton</span><span class="sxs-lookup"><span data-stu-id="b7907-159">InkToolbarRulerButton</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarrulerbutton.aspx)

<span data-ttu-id="b7907-160">ここでは、組み込みのボールペン、鉛筆、および消しゴムのボタンのみ表示されるようにツール バーを初期化します。</span><span class="sxs-lookup"><span data-stu-id="b7907-160">For this example, we initialize the toolbar with only the built-in ballpoint pen, pencil, and eraser buttons.</span></span>

<span data-ttu-id="b7907-161">これは、XAML またはコード ビハインドを使用して実行できます。</span><span class="sxs-lookup"><span data-stu-id="b7907-161">You can do this using either XAML or code-behind.</span></span>

**<span data-ttu-id="b7907-162">XAML</span><span class="sxs-lookup"><span data-stu-id="b7907-162">XAML</span></span>**

<span data-ttu-id="b7907-163">最初の例から、InkCanvas と InkToolbar の XAML 宣言を変更します。</span><span class="sxs-lookup"><span data-stu-id="b7907-163">Modify the XAML declaration for the InkCanvas and InkToolbar from the first example.</span></span>
- <span data-ttu-id="b7907-164">[InitialControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.initialcontrols.aspx) 属性を追加し、値を "[None](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarinitialcontrols.aspx)" に設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-164">Add an [InitialControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.initialcontrols.aspx) attribute and set its value to "[None](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarinitialcontrols.aspx)".</span></span> <span data-ttu-id="b7907-165">これで組み込みボタンの既定のコレクションがクリアされます。</span><span class="sxs-lookup"><span data-stu-id="b7907-165">This clears the default collection of built-in buttons.</span></span>
- <span data-ttu-id="b7907-166">アプリで必要な特定の InkToolbar ボタンを追加します。</span><span class="sxs-lookup"><span data-stu-id="b7907-166">Add the specific InkToolbar buttons required by your app.</span></span> <span data-ttu-id="b7907-167">ここでは、[InkToolbarBallpointPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx)、[InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx)、および [InkToolbarEraserButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx) のみ追加します。</span><span class="sxs-lookup"><span data-stu-id="b7907-167">Here, we add [InkToolbarBallpointPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx), [InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx), and [InkToolbarEraserButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx) only.</span></span>
> [!NOTE]
> <span data-ttu-id="b7907-168">ボタンは、ここで指定した順序ではなく、フレームワークで定義されている順序でツール バーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-168">Buttons are added to the toolbar in the order defined by the framework, not the order specified here.</span></span>

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header"
                   Text="Basic ink sample"
                   Style="{ThemeResource HeaderTextBlockStyle}"
                   Margin="10,0,0,0" />
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <!-- Clear the default InkToolbar buttons by setting InitialControls to None. -->
        <!-- Set the active tool to the pencil button. -->
        <InkCanvas x:Name="inkCanvas" />
        <InkToolbar x:Name="inkToolbar"
                    VerticalAlignment="Top"
                    TargetInkCanvas="{x:Bind inkCanvas}"
                    InitialControls="None">
            <!--
             Add only the ballpoint pen, pencil, and eraser.
             Note that the buttons are added to the toolbar in the order
             defined by the framework, not the order we specify here.
            -->
            <InkToolbarEraserButton />
            <InkToolbarBallpointPenButton />
            <InkToolbarPencilButton/>
        </InkToolbar>
    </Grid>
</Grid>
```

**<span data-ttu-id="b7907-169">コード ビハインド</span><span class="sxs-lookup"><span data-stu-id="b7907-169">Code-behind</span></span>**
1. <span data-ttu-id="b7907-170">最初の例から、InkCanvas と InkToolbar の XAML 宣言を使用します。</span><span class="sxs-lookup"><span data-stu-id="b7907-170">Use the XAML declaration for the InkCanvas and InkToolbar from the first example.</span></span>

  ```xaml
  <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
      <Grid.RowDefinitions>
          <RowDefinition Height="Auto"/>
          <RowDefinition Height="*"/>
      </Grid.RowDefinitions>
      <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
          <TextBlock x:Name="Header"
                     Text="Basic ink sample"
                     Style="{ThemeResource HeaderTextBlockStyle}"
                     Margin="10,0,0,0" />
      </StackPanel>
      <Grid Grid.Row="1">
          <Image Source="Assets\StoreLogo.png" />
          <InkCanvas x:Name="inkCanvas" />
          <InkToolbar x:Name="inkToolbar"
          VerticalAlignment="Top"
          TargetInkCanvas="{x:Bind inkCanvas}" />
      </Grid>
  </Grid>
  ```

2. <span data-ttu-id="b7907-171">コード ビハインドで、[InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) オブジェクトの [Loading](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loading.aspx) イベントのハンドラーを設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-171">In code-behind, set up a handler for the [Loading](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.loading.aspx) event of the [InkToolbar](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) object.</span></span>

  ```csharp
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// Here, we set up InkToolbar event listeners.
  /// </summary>
  public MainPage_CodeBehind()
  {
      this.InitializeComponent();
      // Add handlers for InkToolbar events.
      inkToolbar.Loading += inkToolbar_Loading;
  }
  ```

3. <span data-ttu-id="b7907-172">[InitialControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.initialcontrols.aspx) を "[None](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarinitialcontrols.aspx)" に設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-172">Set [InitialControls](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.initialcontrols.aspx) to "[None](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarinitialcontrols.aspx)".</span></span>
4. <span data-ttu-id="b7907-173">アプリで必要なボタンのオブジェクト参照を作成します。</span><span class="sxs-lookup"><span data-stu-id="b7907-173">Create object references for the buttons required by your app.</span></span> <span data-ttu-id="b7907-174">ここでは、[InkToolbarBallpointPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx)、[InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx)、および [InkToolbarEraserButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx) のみ追加します。</span><span class="sxs-lookup"><span data-stu-id="b7907-174">Here, we add [InkToolbarBallpointPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarballpointpenbutton.aspx), [InkToolbarPencilButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpencilbutton.aspx), and [InkToolbarEraserButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbareraserbutton.aspx) only.</span></span>
  > [!NOTE]
  > <span data-ttu-id="b7907-175">ボタンは、ここで指定した順序ではなく、フレームワークで定義されている順序でツール バーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-175">Buttons are added to the toolbar in the order defined by the framework, not the order specified here.</span></span>

5. <span data-ttu-id="b7907-176">[Add](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobjectcollection.add.aspx) メソッドを使用して、ボタンを InkToolbar に追加します。</span><span class="sxs-lookup"><span data-stu-id="b7907-176">[Add](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobjectcollection.add.aspx) the buttons to the InkToolbar.</span></span>

  ```csharp
  /// <summary>
  /// Handles the Loading event of the InkToolbar.
  /// Here, we identify the buttons to include on the InkToolbar.
  /// </summary>
  /// <param name="sender">The InkToolbar</param>
  /// <param name="args">The InkToolbar event data.
  /// If there is no event data, this parameter is null</param>
  private void inkToolbar_Loading(FrameworkElement sender, object args)
  {
      // Clear all built-in buttons from the InkToolbar.
      inkToolbar.InitialControls = InkToolbarInitialControls.None;

      // Add only the ballpoint pen, pencil, and eraser.
      // Note that the buttons are added to the toolbar in the order
      // defined by the framework, not the order we specify here.
      InkToolbarBallpointPenButton ballpoint = new InkToolbarBallpointPenButton();
      InkToolbarPencilButton pencil = new InkToolbarPencilButton();
      InkToolbarEraserButton eraser = new InkToolbarEraserButton();
      inkToolbar.Children.Add(eraser);
      inkToolbar.Children.Add(ballpoint);
      inkToolbar.Children.Add(pencil);
  }
  ```

<!--
### Support touch input
By default, the InkToolbar supports both pen and mouse input, you have to enable support for touch input.
-->

## <a name="custom-buttons-and-inking-features"></a><span data-ttu-id="b7907-177">カスタム ボタンおよび手書き入力機能</span><span class="sxs-lookup"><span data-stu-id="b7907-177">Custom buttons and inking features</span></span>

<span data-ttu-id="b7907-178">InkToolbar を通じて提供されるボタン (および関連する手書き入力機能) のコレクションをカスタマイズして拡張できます。</span><span class="sxs-lookup"><span data-stu-id="b7907-178">You can customize and extend the collection of buttons (and associated inking features) that are provided through the InkToolbar.</span></span>

<span data-ttu-id="b7907-179">InkToolbar は、次のような 2 つの異なるボタンの種類のグループで構成されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-179">The InkToolbar consists of two distinct groups of button types:</span></span>

1. <span data-ttu-id="b7907-180">"ツール" ボタンのグループ。組み込みの描画ボタン、消去ボタン、強調表示ボタンが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b7907-180">A group of "tool" buttons containing the built-in drawing, erasing, and highlighting buttons.</span></span> <span data-ttu-id="b7907-181">カスタム ペンとカスタム ツールはここに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-181">Custom pens and tools are added here.</span></span>
> <span data-ttu-id="b7907-182">**注**&nbsp;&nbsp;機能の選択は相互に排他的です。</span><span class="sxs-lookup"><span data-stu-id="b7907-182">**Note**&nbsp;&nbsp;Feature selection is mutually exclusive.</span></span>

2. <span data-ttu-id="b7907-183">"トグル" ボタンのグループ。組み込みのルーラー ボタンが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b7907-183">A group of "toggle" buttons containing the built-in ruler button.</span></span> <span data-ttu-id="b7907-184">カスタム トグルはここに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-184">Custom toggles are added here.</span></span>
> <span data-ttu-id="b7907-185">**注**&nbsp;&nbsp;機能は相互に排他的ではないので、他のアクティブなツールと同時に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b7907-185">**Note**&nbsp;&nbsp;Features are not mutually exclusive and can be used concurrently with other active tools.</span></span>

<span data-ttu-id="b7907-186">お使いのアプリケーションと必要なインク機能によって異なりますが、InkToolbar には次のボタン (カスタムの手書き入力機能にバインドされます) を追加できます。</span><span class="sxs-lookup"><span data-stu-id="b7907-186">Depending on your application and the inking functionality required, you can add any of the following buttons (bound to your custom ink features) to the InkToolbar:</span></span>

- <span data-ttu-id="b7907-187">カスタム ペン – インクのカラー パレットやペン先のプロパティ (形状、回転、サイズなど) がホスト アプリで定義されるペン。</span><span class="sxs-lookup"><span data-stu-id="b7907-187">Custom pen – a pen for which the ink color palette and pen tip properties, such as shape, rotation, and size, are defined by the host app.</span></span>
- <span data-ttu-id="b7907-188">カスタム ツール – ホスト アプリで定義されるペン不使用ツール。</span><span class="sxs-lookup"><span data-stu-id="b7907-188">Custom tool – a non-pen tool, defined by the host app.</span></span>
- <span data-ttu-id="b7907-189">カスタム トグル – アプリで定義された機能の状態をオンまたはオフに設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-189">Custom toggle – Sets the state of an app-defined feature to on or off.</span></span> <span data-ttu-id="b7907-190">オンにすると、機能はアクティブなツールと連携して動作します。</span><span class="sxs-lookup"><span data-stu-id="b7907-190">When turned on, the feature works in conjunction with the active tool.</span></span>

> <span data-ttu-id="b7907-191">**注**&nbsp;&nbsp;組み込みのボタンの表示順序を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="b7907-191">**Note**&nbsp;&nbsp;You cannot change the display order of the built-in buttons.</span></span> <span data-ttu-id="b7907-192">既定の表示順序は、ボールペン、鉛筆、蛍光ペン、消しゴム、ルーラーです。</span><span class="sxs-lookup"><span data-stu-id="b7907-192">The default display order is: Ballpoint pen, pencil, highlighter, eraser, and ruler.</span></span> <span data-ttu-id="b7907-193">カスタム ペンは最後の既定のペンに追加され、カスタム ツール ボタンは最後のペン ボタンと消しゴム ボタンの間に追加され、カスタム トグル ボタンはルーラー ボタンの後に追加されます </span><span class="sxs-lookup"><span data-stu-id="b7907-193">Custom pens are appended to the last default pen, custom tool buttons are added between the last pen button and the eraser button and custom toggle buttons are added after the ruler button.</span></span> <span data-ttu-id="b7907-194">(カスタム ボタンは、指定されている順序で追加されます)。</span><span class="sxs-lookup"><span data-stu-id="b7907-194">(Custom buttons are added in the order they are specified.)</span></span>

### <a name="custom-pen"></a><span data-ttu-id="b7907-195">カスタム ペン</span><span class="sxs-lookup"><span data-stu-id="b7907-195">Custom pen</span></span>

<span data-ttu-id="b7907-196">形状、回転、サイズなどのインク カラー パレットと、ペン先のプロパティを定義するカスタムペン (カスタム ペン ボタンを使用してアクティブ化されます) を作成できます。</span><span class="sxs-lookup"><span data-stu-id="b7907-196">You can create a custom pen (activated through a custom pen button) where you define the ink color palette and pen tip properties, such as shape, rotation, and size.</span></span>

![筆記体のカスタム ペン ボタン](.\images\ink\ink-tools-custompen.png)  
*<span data-ttu-id="b7907-198">筆記体のカスタム ペン ボタン</span><span class="sxs-lookup"><span data-stu-id="b7907-198">Custom calligraphic pen button</span></span>*

<span data-ttu-id="b7907-199">ここでは、幅広のペン先で、基本的な筆記体のインク ストロークを可能にするカスタム ペンを定義します。</span><span class="sxs-lookup"><span data-stu-id="b7907-199">For this example, we define a custom pen with a broad tip that enables basic calligraphic ink strokes.</span></span> <span data-ttu-id="b7907-200">また、ボタン ポップアップに表示されるパレットのブラシのコレクションもカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="b7907-200">We also customize the collection of brushes in the palette displayed on the button flyout.</span></span>

**<span data-ttu-id="b7907-201">コード ビハインド</span><span class="sxs-lookup"><span data-stu-id="b7907-201">Code-behind</span></span>**

<span data-ttu-id="b7907-202">まず、コード ビハインドでカスタム ペンを定義し、描画の属性を指定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-202">First, we define our custom pen and specify the drawing attributes in code-behind.</span></span> <span data-ttu-id="b7907-203">このカスタム ペンを後で XAML から参照します。</span><span class="sxs-lookup"><span data-stu-id="b7907-203">We reference this custom pen from XAML later.</span></span>

1. <span data-ttu-id="b7907-204">ソリューション エクスプローラーでプロジェクトを右クリックし、[追加]、[新しい項目] の順に選びます。</span><span class="sxs-lookup"><span data-stu-id="b7907-204">Right click the project in Solution Explorer and select Add -> New item.</span></span>
2. <span data-ttu-id="b7907-205">[Visual C#] の [コード] で、新しいクラス ファイルを追加し、CalligraphicPen.cs という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b7907-205">Under Visual C# -> Code, add a new Class file and call it CalligraphicPen.cs.</span></span>
3. <span data-ttu-id="b7907-206">Calligraphic.cs で、既定の using ブロックを次のように置き換えます。</span><span class="sxs-lookup"><span data-stu-id="b7907-206">In Calligraphic.cs, replace the default using block with the following:</span></span>
```csharp
using System.Numerics;
using Windows.UI;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
```

4. <span data-ttu-id="b7907-207">CalligraphicPen クラスが [InkToolbarCustomPen](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompen.aspx) から派生するように指定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-207">Specify that the CalligraphicPen class is derived from [InkToolbarCustomPen](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompen.aspx).</span></span>
```csharp
class CalligraphicPen : InkToolbarCustomPen
{
}
```

5. <span data-ttu-id="b7907-208">[CreateInkDrawingAttributesCore](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompen.createinkdrawingattributescore.aspx) をオーバーライドし、ブラシとストロークのサイズを独自に指定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-208">Override  [CreateInkDrawingAttributesCore](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompen.createinkdrawingattributescore.aspx)  to specify your own brush and stroke size.</span></span>
```csharp
class CalligraphicPen : InkToolbarCustomPen
{
    protected override InkDrawingAttributes
      CreateInkDrawingAttributesCore(Brush brush, double strokeWidth)
    {
    }
}
```

6. <span data-ttu-id="b7907-209">[InkDrawingAttributes](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.aspx) オブジェクトを作成し、[ペン先の形状](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.pentip.aspx)、[ペン先の回転](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.pentiptransform.aspx)、[ストロークのサイズ](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.size.aspx)、および[インクの色](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.color.aspx)を設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-209">Create an [InkDrawingAttributes](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.aspx) object and set the [pen tip shape](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.pentip.aspx), [tip rotation](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.pentiptransform.aspx), [stroke size](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.size.aspx), and [ink color](https://msdn.microsoft.com/library/windows/apps/windows.ui.input.inking.inkdrawingattributes.color.aspx).</span></span>
```csharp
class CalligraphicPen : InkToolbarCustomPen
{
    protected override InkDrawingAttributes
      CreateInkDrawingAttributesCore(Brush brush, double strokeWidth)
    {
        InkDrawingAttributes inkDrawingAttributes =
          new InkDrawingAttributes();
        inkDrawingAttributes.PenTip = PenTipShape.Circle;
        inkDrawingAttributes.Size =
          new Windows.Foundation.Size(strokeWidth, strokeWidth * 20);
        SolidColorBrush solidColorBrush = brush as SolidColorBrush;
        if (solidColorBrush != null)
        {
            inkDrawingAttributes.Color = solidColorBrush.Color;
        }
        else
        {
            inkDrawingAttributes.Color = Colors.Black;
        }

        Matrix3x2 matrix = Matrix3x2.CreateRotation(45);
        inkDrawingAttributes.PenTipTransform = matrix;

        return inkDrawingAttributes;
    }
}
```

**<span data-ttu-id="b7907-210">XAML</span><span class="sxs-lookup"><span data-stu-id="b7907-210">XAML</span></span>**

<span data-ttu-id="b7907-211">次に、MainPage.xaml で、カスタム ペンへの必要な参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="b7907-211">Next, we add the necessary references to the custom pen in MainPage.xaml.</span></span>

1. <span data-ttu-id="b7907-212">CalligraphicPen.cs で定義したカスタム ペン (`CalligraphicPen`) と、カスタム ペンでサポートされる[ブラシ コレクション](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Media.BrushCollection.aspx) (`CalligraphicPenPalette`) への参照を作成するローカル ページのリソース ディクショナリを宣言します。</span><span class="sxs-lookup"><span data-stu-id="b7907-212">We declare a local page resource dictionary that creates a reference to the custom pen (`CalligraphicPen`) defined in CalligraphicPen.cs, and a [brush collection](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Media.BrushCollection.aspx) supported by the custom pen (`CalligraphicPenPalette`).</span></span>
```xaml
<Page.Resources>
    <!-- Add the custom CalligraphicPen to the page resources. -->
    <local:CalligraphicPen x:Key="CalligraphicPen" />
    <!-- Specify the colors for the palette of the custom pen. -->
    <BrushCollection x:Key="CalligraphicPenPalette">
        <SolidColorBrush Color="Blue" />
        <SolidColorBrush Color="Red" />
    </BrushCollection>
</Page.Resources>
```

2. <span data-ttu-id="b7907-213">次に、InkToolbar と子要素の [InkToolbarCustomPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompenbutton.aspx) を追加します。</span><span class="sxs-lookup"><span data-stu-id="b7907-213">We then add an InkToolbar with a child [InkToolbarCustomPenButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarcustompenbutton.aspx) element.</span></span>

  <span data-ttu-id="b7907-214">カスタム ペン ボタンには、ページ リソースで宣言された `CalligraphicPen` と `CalligraphicPenPalette` の 2 つの静的なリソース参照が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b7907-214">The custom pen button includes the two static resource references declared in the page resources: `CalligraphicPen` and `CalligraphicPenPalette`.</span></span>

  <span data-ttu-id="b7907-215">また、ストローク サイズのスライダーの範囲 ([MinStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.minstrokewidth.aspx)、[MaxStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.maxstrokewidth.aspx)、および [SelectedStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.selectedstrokewidthproperty.aspx))、選択されたブラシ ([SelectedBrushIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.selectedbrushindex.aspx))、カスタム ペン ボタンのアイコン ([SymbolIcon](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.symbolicon.aspx)) も指定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-215">We also specify the range for the stroke size slider ([MinStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.minstrokewidth.aspx), [MaxStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.maxstrokewidth.aspx), and [SelectedStrokeWidth](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.selectedstrokewidthproperty.aspx)), the selected brush ([SelectedBrushIndex](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbarpenbutton.selectedbrushindex.aspx)), and the icon for the custom pen button ([SymbolIcon](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.symbolicon.aspx)).</span></span>
```xaml
<Grid Grid.Row="1">
    <InkCanvas x:Name="inkCanvas" />
    <InkToolbar x:Name="inkToolbar"
                VerticalAlignment="Top"
                TargetInkCanvas="{x:Bind inkCanvas}">
        <InkToolbarCustomPenButton
            CustomPen="{StaticResource CalligraphicPen}"
            Palette="{StaticResource CalligraphicPenPalette}"
            MinStrokeWidth="1" MaxStrokeWidth="3" SelectedStrokeWidth="2"
            SelectedBrushIndex ="1">
            <SymbolIcon Symbol="Favorite" />
            <InkToolbarCustomPenButton.ConfigurationContent>
                <InkToolbarPenConfigurationControl />
            </InkToolbarCustomPenButton.ConfigurationContent>
        </InkToolbarCustomPenButton>
    </InkToolbar>
</Grid>
```

### <a name="custom-toggle"></a><span data-ttu-id="b7907-216">カスタム トグル</span><span class="sxs-lookup"><span data-stu-id="b7907-216">Custom toggle</span></span>

<span data-ttu-id="b7907-217">カスタム トグル (カスタム トグル ボタンを使用してアクティブ化されます) を作成して、アプリ定義の機能の状態をオンまたはオフに設定できます。</span><span class="sxs-lookup"><span data-stu-id="b7907-217">You can create a custom toggle (activated through a custom toggle button) to set the state of an app-defined feature to on or off.</span></span> <span data-ttu-id="b7907-218">オンにすると、機能はアクティブなツールと連携して動作します。</span><span class="sxs-lookup"><span data-stu-id="b7907-218">When turned on, the feature works in conjunction with the active tool.</span></span>

<span data-ttu-id="b7907-219">この例では、タッチ入力による手書き入力を可能にするカスタム トグル ボタンを定義しています (既定では、タッチの手書き入力は有効化されていません)。</span><span class="sxs-lookup"><span data-stu-id="b7907-219">In this example, we define a custom toggle button that enables inking with touch input (by default, touch inking is not enabled).</span></span>

> [!NOTE]  
> <span data-ttu-id="b7907-220">タッチを使った手書き入力をサポートする必要がある場合は、この例で指定されたアイコンとツールチップを使い、CustomToggleButton を使用して手書き入力を有効化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b7907-220">If you need to support inking with touch, we recommended that you enable it using a CustomToggleButton, with the icon and tooltip specified in this example.</span></span>

<span data-ttu-id="b7907-221">通常タッチ入力は、オブジェクトまたはアプリの UI を直接操作するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-221">Typically, touch input is used for direct manipulation of an object or the app UI.</span></span> <span data-ttu-id="b7907-222">タッチによる手書き入力を有効化したときの動作の違いを示すために、InkCanvas を ScrollViewer コンテナ内に配置し、ScrollViewer のサイズを InkCanvas よりも小さく設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-222">To demonstrate the differences in behavior when touch inking is enabled, we place the InkCanvas within a ScrollViewer container and set the dimensions of the ScrollViewer to be smaller than the InkCanvas.</span></span> 

<span data-ttu-id="b7907-223">アプリが起動すると、ペンによる手書き入力のみがサポートされ、タッチは手書き入力の入力面をパンまたはズームするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-223">When the app starts, only pen inking is supported and touch is used to pan or zoom the inking surface.</span></span> <span data-ttu-id="b7907-224">タッチによる手書き入力が有効化されていると、手書き入力の入力面をタッチ入力でパンまたはズームすることはできません。</span><span class="sxs-lookup"><span data-stu-id="b7907-224">When touch inking is enabled, the inking surface cannot be panned or zoomed through touch input.</span></span>

> [!NOTE]
> <span data-ttu-id="b7907-225">[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) および [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar) の UX ガイドラインは、「[インク コントロール](..\controls-and-patterns\inking-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7907-225">See [Inking controls](..\controls-and-patterns\inking-controls.md) for both [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) and [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar) UX guidelines.</span></span> <span data-ttu-id="b7907-226">次の推奨事項は、この例に関連したものです。</span><span class="sxs-lookup"><span data-stu-id="b7907-226">The following recommendations are relevant to this example:</span></span>
> - <span data-ttu-id="b7907-227">[**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar) と手書き入力全般は、アクティブなペンを通じて最適なエクスペリエンスを実現します。</span><span class="sxs-lookup"><span data-stu-id="b7907-227">The [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbar), and inking in general, is best experienced through an active pen.</span></span> <span data-ttu-id="b7907-228">ただし、アプリで必要な場合は、マウスやタッチによる手書き入力をサポートできます。</span><span class="sxs-lookup"><span data-stu-id="b7907-228">However, inking with mouse and touch can be supported if required by your app.</span></span> 
> - <span data-ttu-id="b7907-229">タッチ入力による手書き入力をサポートする場合、トグル ボタンに "Segoe MLD2 アセット" フォントの "ED5F" アイコンを使うと共に、"タッチによる手書き" というヒントを表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b7907-229">If supporting inking with touch input, we recommend using the "ED5F" icon from the "Segoe MLD2 Assets" font for the toggle button, with a "Touch writing" tooltip.</span></span> 

**<span data-ttu-id="b7907-230">XAML</span><span class="sxs-lookup"><span data-stu-id="b7907-230">XAML</span></span>**

1. <span data-ttu-id="b7907-231">まず、イベント ハンドラー (Toggle_Custom) を指定する Click イベント リスナーを持つ [**InkToolbarCustomToggleButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToggleButton) 要素 (toggleButton) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="b7907-231">First, we declare an [**InkToolbarCustomToggleButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToggleButton) element (toggleButton) with a Click event listener that specifies the event handler (Toggle_Custom).</span></span>

```xaml 
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>

    <StackPanel Grid.Row="0" 
                x:Name="HeaderPanel" 
                Orientation="Horizontal">
        <TextBlock x:Name="Header" 
                   Text="Basic ink sample" 
                   Style="{ThemeResource HeaderTextBlockStyle}" 
                   Margin="10" />
    </StackPanel>

    <ScrollViewer Grid.Row="1" 
                  HorizontalScrollBarVisibility="Auto" 
                  VerticalScrollBarVisibility="Auto">
        
        <Grid HorizontalAlignment="Left" VerticalAlignment="Top">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            
            <InkToolbar Grid.Row="0" 
                        Margin="10"
                        x:Name="inkToolbar" 
                        VerticalAlignment="Top"
                        TargetInkCanvas="{x:Bind inkCanvas}">
                <InkToolbarCustomToggleButton 
                x:Name="toggleButton" 
                Click="CustomToggle_Click" 
                ToolTipService.ToolTip="Touch Writing">
                    <SymbolIcon Symbol="{x:Bind TouchWritingIcon}"/>
                </InkToolbarCustomToggleButton>
            </InkToolbar>
            
            <ScrollViewer Grid.Row="1" 
                          Height="500"
                          Width="500"
                          x:Name="scrollViewer" 
                          ZoomMode="Enabled" 
                          MinZoomFactor=".1" 
                          VerticalScrollMode="Enabled" 
                          VerticalScrollBarVisibility="Auto" 
                          HorizontalScrollMode="Enabled" 
                          HorizontalScrollBarVisibility="Auto">
                
                <Grid x:Name="outputGrid" 
                      Height="1000"
                      Width="1000"
                      Background="{ThemeResource SystemControlBackgroundChromeWhiteBrush}">
                    <InkCanvas x:Name="inkCanvas"/>
                </Grid>
                
            </ScrollViewer>
        </Grid>
    </ScrollViewer>
</Grid>
```

**<span data-ttu-id="b7907-232">コード ビハインド</span><span class="sxs-lookup"><span data-stu-id="b7907-232">Code-behind</span></span>**

2. <span data-ttu-id="b7907-233">前のスニペットでは、タッチによる手書き入力 (toggleButton) のカスタム トグル ボタンの Click イベント リスナーとハンドラー (Toggle_Custom) を宣言しました。</span><span class="sxs-lookup"><span data-stu-id="b7907-233">In the previous snippet, we declared a Click event listener and handler (Toggle_Custom) on the custom toggle button for touch inking (toggleButton).</span></span> <span data-ttu-id="b7907-234">このハンドラーは、InkPresenter の InputDeviceTypes プロパティを使って、CoreInputDeviceTypes.Touch のサポートを単にトグルします。</span><span class="sxs-lookup"><span data-stu-id="b7907-234">This handler simply toggles support for CoreInputDeviceTypes.Touch through the InputDeviceTypes property of the InkPresenter.</span></span>

   <span data-ttu-id="b7907-235">また、SymbolIcon 要素と、コードビハインド ファイル (TouchWritingIcon) で定義されたフィールドにバインドする {x：Bind} マークアップ拡張を使用して、ボタンのアイコンを指定しました。</span><span class="sxs-lookup"><span data-stu-id="b7907-235">We also specified an icon for the button using the SymbolIcon element and the {x:Bind} markup extension that binds it to a field defined in the code-behind file (TouchWritingIcon).</span></span>

   <span data-ttu-id="b7907-236">次のスニペットには、Click イベント ハンドラーと TouchWritingIcon の定義の両方が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b7907-236">The following snippet includes both the Click event handler and the definition of TouchWritingIcon.</span></span>

```csharp 
namespace Ink_Basic_InkToolbar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage_AddCustomToggle : Page
    {
        Symbol TouchWritingIcon = (Symbol)0xED5F;

        public MainPage_AddCustomToggle()
        {
            this.InitializeComponent();
        }

        // Handler for the custom toggle button that enables touch inking.
        private void CustomToggle_Click(object sender, RoutedEventArgs e)
        {
            if (toggleButton.IsChecked == true)
            {
                inkCanvas.InkPresenter.InputDeviceTypes |= CoreInputDeviceTypes.Touch;
            }
            else
            {
                inkCanvas.InkPresenter.InputDeviceTypes &= ~CoreInputDeviceTypes.Touch;
            }
        }
    }
}
```

### <a name="custom-tool"></a><span data-ttu-id="b7907-237">カスタム ツール</span><span class="sxs-lookup"><span data-stu-id="b7907-237">Custom tool</span></span>

<span data-ttu-id="b7907-238">カスタム ツール ボタンを作成して、アプリで定義されたペン以外のツールを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="b7907-238">You can create a custom tool button to invoke a non-pen tool that is defined by your app.</span></span>

<span data-ttu-id="b7907-239">既定では、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) はすべての入力をインク ストロークか消去ストロークとして処理します。</span><span class="sxs-lookup"><span data-stu-id="b7907-239">By default, an [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) processes all input as either an ink stroke or an erase stroke.</span></span> <span data-ttu-id="b7907-240">これには、セカンダリ ハードウェア アフォーダンス (ペン バレル ボタン、マウスの右ボタンなど) によって変更された入力も含まれます。</span><span class="sxs-lookup"><span data-stu-id="b7907-240">This includes input modified by a secondary hardware affordance such as a pen barrel button, a right mouse button, or similar.</span></span> <span data-ttu-id="b7907-241">ただし、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) は、特定の入力を未処理のままにするように設定でき、それをカスタム処理のためにアプリに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="b7907-241">However, [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) can be configured to leave specific input unprocessed, which can then be passed through to your app for custom processing.</span></span>

<span data-ttu-id="b7907-242">この例では、カスタム ツール ボタンを定義しており、これを選択すると、後続のストロークはインクではなく、なげなわ選択 (破線) として処理されてレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="b7907-242">In this example, we define a custom tool button that, when selected, causes subsequent strokes to be processed and rendered as a selection lasso (dashed line) instead of ink.</span></span> <span data-ttu-id="b7907-243">選択領域の範囲内のすべてのインク ストロークが [**Selected**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkStroke.Selected) に設定されます。</span><span class="sxs-lookup"><span data-stu-id="b7907-243">All ink strokes within the bounds of the selection area are set to [**Selected**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkStroke.Selected).</span></span>

> [!NOTE]
> <span data-ttu-id="b7907-244">InkCanvas および InkToolbar の UX ガイドラインは、「インク コントロール」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7907-244">See Inking controls for both InkCanvas and InkToolbar UX guidelines.</span></span> <span data-ttu-id="b7907-245">次の推奨事項は、この例に関連したものです。</span><span class="sxs-lookup"><span data-stu-id="b7907-245">The following recommendation is relevant to this example:</span></span>
> - <span data-ttu-id="b7907-246">ストローク選択を提供する場合は、「選択ツール」ツールチップを使用して、ツール ボタンの "Segoe MLD2 アセット" フォントの "EF20" アイコンを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b7907-246">If providing stroke selection, we recommend using the "EF20" icon from the "Segoe MLD2 Assets" font for the tool button, with a "Selection tool" tooltip.</span></span> 
 
**<span data-ttu-id="b7907-247">XAML</span><span class="sxs-lookup"><span data-stu-id="b7907-247">XAML</span></span>**

1. <span data-ttu-id="b7907-248">まず、ストローク選択が構成されているイベント ハンドラー (customToolButton_Click) を指定する Click イベント リスナーを持つ [**InkToolbarCustomToolButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToolButton) 要素 (customToolButton) を宣言します。</span><span class="sxs-lookup"><span data-stu-id="b7907-248">First, we declare an [**InkToolbarCustomToolButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToolButton) element (customToolButton) with a Click event listener that specifies the event handler (customToolButton_Click) where stroke selection is configured.</span></span> <span data-ttu-id="b7907-249">(ストローク選択のコピー、切り取り、貼り付けのための一連のボタンも追加しました。)</span><span class="sxs-lookup"><span data-stu-id="b7907-249">(We've also added a set of buttons for copying, cutting, and pasting the stroke selection.)</span></span>

2. <span data-ttu-id="b7907-250">選択ストロークを描画するための Canvas 要素も追加します。</span><span class="sxs-lookup"><span data-stu-id="b7907-250">We also add a Canvas element for drawing our selection stroke.</span></span> <span data-ttu-id="b7907-251">別のレイヤーを使って選択ストロークを描画すると、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) とそのコンテンツは影響を受けることがありません。</span><span class="sxs-lookup"><span data-stu-id="b7907-251">Using a separate layer to draw the selection stroke ensures the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkCanvas) and its content remain untouched.</span></span> 

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header" 
                   Text="Basic ink sample" 
                   Style="{ThemeResource HeaderTextBlockStyle}" 
                   Margin="10,0,0,0" />
    </StackPanel>
    <StackPanel x:Name="ToolPanel" Orientation="Horizontal" Grid.Row="1">
        <InkToolbar x:Name="inkToolbar" 
                    VerticalAlignment="Top" 
                    TargetInkCanvas="{x:Bind inkCanvas}">
            <InkToolbarCustomToolButton 
                x:Name="customToolButton" 
                Click="customToolButton_Click" 
                ToolTipService.ToolTip="Selection tool">
                <SymbolIcon Symbol="{x:Bind SelectIcon}"/>
            </InkToolbarCustomToolButton>
        </InkToolbar>
        <Button x:Name="cutButton" 
                Content="Cut" 
                Click="cutButton_Click"
                Width="100"
                Margin="5,0,0,0"/>
        <Button x:Name="copyButton" 
                Content="Copy"  
                Click="copyButton_Click"
                Width="100"
                Margin="5,0,0,0"/>
        <Button x:Name="pasteButton" 
                Content="Paste"  
                Click="pasteButton_Click"
                Width="100"
                Margin="5,0,0,0"/>
    </StackPanel>
    <Grid Grid.Row="2" x:Name="outputGrid" 
              Background="{ThemeResource SystemControlBackgroundChromeWhiteBrush}" 
              Height="Auto">
        <!-- Canvas for displaying selection UI. -->
        <Canvas x:Name="selectionCanvas"/>
        <!-- Canvas for displaying ink. -->
        <InkCanvas x:Name="inkCanvas" />
    </Grid>
</Grid>
```

**<span data-ttu-id="b7907-252">コード ビハインド</span><span class="sxs-lookup"><span data-stu-id="b7907-252">Code-behind</span></span>**

2. <span data-ttu-id="b7907-253">次に、MainPage.xaml.cs コードビハインド ファイルの [**InkToolbarCustomToolButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToolButton) の Click イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="b7907-253">We then handle the Click event for the [**InkToolbarCustomToolButton**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Controls.InkToolbarCustomToolButton) in the MainPage.xaml.cs code-behind file.</span></span>

   <span data-ttu-id="b7907-254">このハンドラは、未処理の入力をアプリに渡すように [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) を設定します。</span><span class="sxs-lookup"><span data-stu-id="b7907-254">This handler configures the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Input.Inking.InkPresenter) to pass unprocessed input through to the app.</span></span> 

   <span data-ttu-id="b7907-255">このコードの詳細な手順については、「[UWP アプリでのペン操作と Windows Ink](pen-and-stylus-interactions.md)」の「高度な処理のための入力のパススルー」のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7907-255">For a more detailed step through of this code:  See the Pass-through input for advanced processing section of [Pen interactions and Windows Ink in UWP apps](pen-and-stylus-interactions.md).</span></span>

   <span data-ttu-id="b7907-256">また、SymbolIcon 要素と、コードビハインド ファイル (SelectIcon) で定義されたフィールドにバインドする {x：Bind} マークアップ拡張を使用して、ボタンのアイコンを指定しました。</span><span class="sxs-lookup"><span data-stu-id="b7907-256">We also specified an icon for the button using the SymbolIcon element and the {x:Bind} markup extension that binds it to a field defined in the code-behind file (SelectIcon).</span></span>

   <span data-ttu-id="b7907-257">次のスニペットには、Click イベント ハンドラーと SelectIcon の定義の両方が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b7907-257">The following snippet includes both the Click event handler and the definition of SelectIcon.</span></span>

```csharp
namespace Ink_Basic_InkToolbar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage_AddCustomTool : Page
    {
        // Icon for custom selection tool button.
        Symbol SelectIcon = (Symbol)0xEF20;

        // Stroke selection tool.
        private Polyline lasso;
        // Stroke selection area.
        private Rect boundingRect;

        public MainPage_AddCustomTool()
        {
            this.InitializeComponent();

            // Listen for new ink or erase strokes to clean up selection UI.
            inkCanvas.InkPresenter.StrokeInput.StrokeStarted +=
                StrokeInput_StrokeStarted;
            inkCanvas.InkPresenter.StrokesErased +=
                InkPresenter_StrokesErased;
        }

        private void customToolButton_Click(object sender, RoutedEventArgs e)
        {
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
        }

        // Handle new ink or erase strokes to clean up selection UI.
        private void StrokeInput_StrokeStarted(
            InkStrokeInput sender, Windows.UI.Core.PointerEventArgs args)
        {
            ClearSelection();
        }

        private void InkPresenter_StrokesErased(
            InkPresenter sender, InkStrokesErasedEventArgs args)
        {
            ClearSelection();
        }

        private void cutButton_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
            inkCanvas.InkPresenter.StrokeContainer.DeleteSelected();
            ClearSelection();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
        }

        private void pasteButton_Click(object sender, RoutedEventArgs e)
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

        // Clean up selection UI.
        private void ClearSelection()
        {
            var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
            foreach (var stroke in strokes)
            {
                stroke.Selected = false;
            }
            ClearBoundingRect();
        }

        private void ClearBoundingRect()
        {
            if (selectionCanvas.Children.Any())
            {
                selectionCanvas.Children.Clear();
                boundingRect = Rect.Empty;
            }
        }

        // Handle unprocessed pointer events from modifed input.
        // The input is used to provide selection functionality.
        // Selection UI is drawn on a canvas under the InkCanvas.
        private void UnprocessedInput_PointerPressed(
            InkUnprocessedInput sender, PointerEventArgs args)
        {
            // Initialize a selection lasso.
            lasso = new Polyline()
            {
                Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                StrokeThickness = 1,
                StrokeDashArray = new DoubleCollection() { 5, 2 },
            };

            lasso.Points.Add(args.CurrentPoint.RawPosition);

            selectionCanvas.Children.Add(lasso);
        }

        private void UnprocessedInput_PointerMoved(
            InkUnprocessedInput sender, PointerEventArgs args)
        {
            // Add a point to the lasso Polyline object.
            lasso.Points.Add(args.CurrentPoint.RawPosition);
        }

        private void UnprocessedInput_PointerReleased(
            InkUnprocessedInput sender, PointerEventArgs args)
        {
            // Add the final point to the Polyline object and 
            // select strokes within the lasso area.
            // Draw a bounding box on the selection canvas 
            // around the selected ink strokes.
            lasso.Points.Add(args.CurrentPoint.RawPosition);

            boundingRect =
                inkCanvas.InkPresenter.StrokeContainer.SelectWithPolyLine(
                    lasso.Points);

            DrawBoundingRect();
        }

        // Draw a bounding rectangle, on the selection canvas, encompassing 
        // all ink strokes within the lasso area.
        private void DrawBoundingRect()
        {
            // Clear all existing content from the selection canvas.
            selectionCanvas.Children.Clear();

            // Draw a bounding rectangle only if there are ink strokes 
            // within the lasso area.
            if (!((boundingRect.Width == 0) ||
                (boundingRect.Height == 0) ||
                boundingRect.IsEmpty))
            {
                var rectangle = new Rectangle()
                {
                    Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                    StrokeThickness = 1,
                    StrokeDashArray = new DoubleCollection() { 5, 2 },
                    Width = boundingRect.Width,
                    Height = boundingRect.Height
                };

                Canvas.SetLeft(rectangle, boundingRect.X);
                Canvas.SetTop(rectangle, boundingRect.Y);

                selectionCanvas.Children.Add(rectangle);
            }
        }
    }
}
```



### <a name="custom-ink-rendering"></a><span data-ttu-id="b7907-258">カスタム インク レンダリング</span><span class="sxs-lookup"><span data-stu-id="b7907-258">Custom ink rendering</span></span>

<span data-ttu-id="b7907-259">既定では、手書き入力は低待機時間のバックグラウンド スレッドで処理され、描画と同時に "ウェット" レンダリングが行われます。</span><span class="sxs-lookup"><span data-stu-id="b7907-259">By default, ink input is processed on a low-latency background thread and rendered "wet" as it is drawn.</span></span> <span data-ttu-id="b7907-260">ストロークが完了すると (ペンまたは指が画面を離れるか、マウスのボタンが離されると)、UI スレッドでストロークが処理されて、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) レイヤーへの "ドライ" レンダリングが行われます (アプリケーション コンテンツの上にレンダリングされてウェット インクが置き換えられます)。</span><span class="sxs-lookup"><span data-stu-id="b7907-260">When the stroke is completed (pen or finger lifted, or mouse button released), the stroke is processed on the UI thread and rendered "dry" to the [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) layer (above the application content and replacing the wet ink).</span></span>

<span data-ttu-id="b7907-261">インク プラットフォームでは、この動作を上書きして、手書き入力のカスタム ドライ レンダリングによって手書き入力エクスペリエンスを全面的にカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="b7907-261">The ink platform enables you to override this behavior and completely customize the inking experience by custom drying the ink input.</span></span>

<span data-ttu-id="b7907-262">カスタム ドライ レンダリングについて詳しくは、「[UWP アプリでのペン操作と Windows Ink](https://msdn.microsoft.com/windows/uwp/input-and-devices/pen-and-stylus-interactions#custom-ink-rendering)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7907-262">For more info on custom drying, see [Pen interactions and Windows Ink in UWP apps](https://msdn.microsoft.com/windows/uwp/input-and-devices/pen-and-stylus-interactions#custom-ink-rendering).</span></span>

> [!NOTE]
> <span data-ttu-id="b7907-263">カスタム ドライ レンダリングと [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)</span><span class="sxs-lookup"><span data-stu-id="b7907-263">Custom drying and the [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)</span></span>  
> <span data-ttu-id="b7907-264">カスタム ドライの実装によって、アプリが [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の既定のインク レンダリング動作を上書きすると、レンダリングされたインク ストロークが InkToolbar で利用できなくなり、InkToolbar の組み込みの消去コマンドが正常に機能しなくなります。</span><span class="sxs-lookup"><span data-stu-id="b7907-264">If your app overrides the default ink rendering behavior of the [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) with a custom drying implementation, the rendered ink strokes are no longer available to the InkToolbar and the built-in erase commands of the InkToolbar do not work as expected.</span></span> <span data-ttu-id="b7907-265">消去機能を提供するには、すべてのポインター イベントを処理し、ストロークごとにヒット テストを実行すると共に、組み込みの [すべてのインクのデータを消去] コマンドをオーバーライドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7907-265">To provide erase functionality, you must handle all pointer events, perform hit-testing on each stroke, and override the built-in "Erase all ink" command.</span></span>

## <a name="related-articles"></a><span data-ttu-id="b7907-266">関連記事</span><span class="sxs-lookup"><span data-stu-id="b7907-266">Related articles</span></span>

* [<span data-ttu-id="b7907-267">ペン操作とスタイラス操作</span><span class="sxs-lookup"><span data-stu-id="b7907-267">Pen and stylus interactions</span></span>](pen-and-stylus-interactions.md)

**<span data-ttu-id="b7907-268">サンプル</span><span class="sxs-lookup"><span data-stu-id="b7907-268">Samples</span></span>**
* [<span data-ttu-id="b7907-269">単純なインクのサンプル (C#/C++)</span><span class="sxs-lookup"><span data-stu-id="b7907-269">Simple ink sample (C#/C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [<span data-ttu-id="b7907-270">複雑なインクのサンプル (C++)</span><span class="sxs-lookup"><span data-stu-id="b7907-270">Complex ink sample (C++)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [<span data-ttu-id="b7907-271">インクのサンプル (JavaScript)</span><span class="sxs-lookup"><span data-stu-id="b7907-271">Ink sample (JavaScript)</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [<span data-ttu-id="b7907-272">入門チュートリアル: UWP アプリでのインクのサポート</span><span class="sxs-lookup"><span data-stu-id="b7907-272">Get Started Tutorial: Support ink in your UWP app</span></span>](https://aka.ms/appsample-ink)
* [<span data-ttu-id="b7907-273">塗り絵帳のサンプル</span><span class="sxs-lookup"><span data-stu-id="b7907-273">Coloring book sample</span></span>](https://aka.ms/cpubsample-coloringbook)
* [<span data-ttu-id="b7907-274">Family Notes のサンプル</span><span class="sxs-lookup"><span data-stu-id="b7907-274">Family notes sample</span></span>](https://aka.ms/cpubsample-familynotessample)

