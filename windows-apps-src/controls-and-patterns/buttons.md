---
author: Jwmsft
Description: "ボタンは、特定の操作を直ちに実行する手段をユーザーに提供します。"
title: "ボタン"
label: Buttons
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: f04d1a3c-7dcd-4bc8-9586-3396923b312e
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.openlocfilehash: 2cb15d21496c080002411849682278df7f927e41
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="buttons"></a><span data-ttu-id="3f6ac-104">ボタン</span><span class="sxs-lookup"><span data-stu-id="3f6ac-104">Buttons</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="3f6ac-105">ボタンは、特定の操作を直ちに実行する手段をユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-105">A button gives the user a way to trigger an immediate action.</span></span>

> <span data-ttu-id="3f6ac-106">**重要な API**: [Button クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)、[RepeatButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx)、[Click イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx)</span><span class="sxs-lookup"><span data-stu-id="3f6ac-106">**Important APIs**: [Button class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx), [RepeatButton class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx), [Click event](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx)</span></span>

![ボタンの例](images/controls/button.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="3f6ac-108">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="3f6ac-108">Is this the right control?</span></span>

<span data-ttu-id="3f6ac-109">ボタンを使うと、ユーザーは直ちに操作を開始できます (フォームの送信など)。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-109">A button lets the user initiate an immediate action, such as submitting a form.</span></span>

<span data-ttu-id="3f6ac-110">他のページに移動する操作では、ボタンは使わず、リンクを使います。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-110">Don't use a button when the action is to navigate to another page; use a link instead.</span></span> <span data-ttu-id="3f6ac-111">詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-111">See [Hyperlinks](hyperlinks.md) for more info.</span></span>

> <span data-ttu-id="3f6ac-112">例外: ウィザードでのページの移動には、[戻る] と [次へ] というラベルのボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-112">Exception: For wizard navigation, use buttons labeled "Back" and "Next".</span></span> <span data-ttu-id="3f6ac-113">他の種類の前に戻る移動や上位レベルへの移動では、[戻る] ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-113">For other types of backwards navigation or navigation to an upper level, use a back button.</span></span>

## <a name="example"></a><span data-ttu-id="3f6ac-114">例</span><span class="sxs-lookup"><span data-stu-id="3f6ac-114">Example</span></span>

<span data-ttu-id="3f6ac-115">この例では、一情報へのアクセスを求めるダイアログ ボックスで、2 つのボタン ([Allow] (許可) と [Block] (禁止)) を使っています。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-115">This example uses two buttons, Allow and Block, in a dialog requesting location access.</span></span>

![ダイアログで使われるボタンの例](images/dialogs/dialog_RS2_two_button.png)

## <a name="create-a-button"></a><span data-ttu-id="3f6ac-117">ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="3f6ac-117">Create a button</span></span>

<span data-ttu-id="3f6ac-118">クリックに応答するボタンの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-118">This example shows a button that responds to a click.</span></span>

<span data-ttu-id="3f6ac-119">XAML でボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-119">Create the button in XAML.</span></span>

```xaml
<Button Content="Subscribe" Click="SubscribeButton_Click"/>
```

<span data-ttu-id="3f6ac-120">または、コードでボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-120">Or create the button in code.</span></span>

```csharp
Button subscribeButton = new Button();
subscribeButton.Content = "Subscribe";
subscribeButton.Click += SubscribeButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(subscribeButton);
```

<span data-ttu-id="3f6ac-121">Click イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-121">Handle the Click event.</span></span>

```csharp
private async void SubscribeButton_Click(object sender, RoutedEventArgs e)
{
    // Call app specific code to subscribe to the service. For example:
    ContentDialog subscribeDialog = new ContentDialog
    {
        Title = "Subscribe to App Service?",
        Content = "Listen, watch, and play in high definition for only $9.99/month. Free to try, cancel anytime.",
        CloseButtonText = "Not Now",
        PrimaryButtonText = "Subscribe",
        SecondaryButtonText = "Try it"
    };

    ContentDialogResult result = await subscribeDialog.ShowAsync();
}
```

### <a name="button-interaction"></a><span data-ttu-id="3f6ac-122">ボタンの対話式操作</span><span class="sxs-lookup"><span data-stu-id="3f6ac-122">Button interaction</span></span>

<span data-ttu-id="3f6ac-123">ポインターがボタンの上にあるときに、指やスタイラスでそのボタンをタップするか、マウスの左ボタンを押すと、ボタンでは [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-123">When you tap a Button with a finger or stylus, or press a left mouse button while the pointer is over it, the button raises the [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) event.</span></span> <span data-ttu-id="3f6ac-124">ボタンにキーボード フォーカスがある場合は、Enter キーまたは Space キーを押しても、Click イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-124">If a button has keyboard focus, pressing the Enter key or the Spacebar key also raises the Click event.</span></span>

<span data-ttu-id="3f6ac-125">通常、ボタンでは低レベルな [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントを処理できません。これに代わる Click 動作があるためです。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-125">You generally can't handle low-level [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) events on a Button because it has the Click behavior instead.</span></span> <span data-ttu-id="3f6ac-126">詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-126">For more info, see [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx).</span></span>

<span data-ttu-id="3f6ac-127">ボタンで Click イベントが発生する方法を変えるには、[ClickMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.clickmode.aspx) プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-127">You can change how a button raises the Click event by changing the [ClickMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.clickmode.aspx) property.</span></span> <span data-ttu-id="3f6ac-128">ClickMode の既定値は **Release** です。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-128">The default ClickMode value is **Release**.</span></span> <span data-ttu-id="3f6ac-129">ClickMode が **Hover** の場合、キーボード操作やタッチ操作によって Click イベントを発生させることはできません。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-129">If ClickMode is **Hover**, the Click event can't be raised with the keyboard or touch.</span></span>


### <a name="button-content"></a><span data-ttu-id="3f6ac-130">ボタンのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="3f6ac-130">Button content</span></span>

<span data-ttu-id="3f6ac-131">ボタンは [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx) です。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-131">Button is a [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx).</span></span> <span data-ttu-id="3f6ac-132">その XAML コンテンツ プロパティは [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) であり、`<Button>A button's content</Button>` のような XAML 構文を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-132">Its XAML content property is [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx), which enables a syntax like this for XAML: `<Button>A button's content</Button>`.</span></span> <span data-ttu-id="3f6ac-133">任意のオブジェクトをボタンのコンテンツとして設定できます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-133">You can set any object as the button's content.</span></span> <span data-ttu-id="3f6ac-134">コンテンツが [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) の場合、ボタンにレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-134">If the content is a [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx), it is rendered in the button.</span></span> <span data-ttu-id="3f6ac-135">コンテンツが別のタイプのオブジェクトの場合、その文字列表現がボタンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-135">If the content is another type of object, its string representation is shown in the button.</span></span>

<span data-ttu-id="3f6ac-136">ここでは、オレンジの画像とテキストを含む **StackPanel** がボタンのコンテンツとして設定されます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-136">Here, a **StackPanel** that contains an image of an orange and text is set as the content of a button.</span></span>

```xaml
<Button Click="Button_Click"
        Background="LightGray"
        Height="100" Width="80">
    <StackPanel>
        <Image Source="Assets/Photo.png" Height="62"/>
        <TextBlock Text="Photos" Foreground="Black"
                   HorizontalAlignment="Center"/>
    </StackPanel>
</Button>
```

<span data-ttu-id="3f6ac-137">ボタンは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-137">The button looks like this.</span></span>

![画像とテキスト コンテンツがあるボタン](images/button-orange.png)

## <a name="create-a-repeat-button"></a><span data-ttu-id="3f6ac-139">繰り返しボタンの作成</span><span class="sxs-lookup"><span data-stu-id="3f6ac-139">Create a repeat button</span></span>

<span data-ttu-id="3f6ac-140">[RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) は、ボタンが押されてから離されるまで、繰り返し [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントを発生させるボタンです。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-140">A [RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) is a button that raises [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) events repeatedly from the time it's pressed until it's released.</span></span> <span data-ttu-id="3f6ac-141">ボタンが押されてからクリック操作の繰り返しを始めるまでの RepeatButton の待ち時間を指定するには、[Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-141">Set the [Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) property to specify the time that the RepeatButton waits after it is pressed before it starts repeating the click action.</span></span> <span data-ttu-id="3f6ac-142">クリック操作の繰り返し間隔を指定するには、[Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-142">Set the [Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) property to specify the time between repetitions of the click action.</span></span> <span data-ttu-id="3f6ac-143">これらのプロパティの時間はどちらもミリ秒単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-143">Times for both properties are specified in milliseconds.</span></span>

<span data-ttu-id="3f6ac-144">次の例は 2 つの RepeatButton コントロールを示しています。それぞれの Click イベントを使って、テキスト ブロックに表示される値を増減します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-144">The following example shows two RepeatButton controls whose respective Click events are used to increase and decrease the value shown in a text block.</span></span>

```xaml
<StackPanel>
    <RepeatButton Width="100" Delay="500" Interval="100" Click="Increase_Click">Increase</RepeatButton>
    <RepeatButton Width="100" Delay="500" Interval="100" Click="Decrease_Click">Decrease</RepeatButton>
    <TextBlock x:Name="clickTextBlock" Text="Number of Clicks:" />
</StackPanel>
```

```csharp
private static int _clicks = 0;
private void Increase_Click(object sender, RoutedEventArgs e)
{
    _clicks += 1;
    clickTextBlock.Text = "Number of Clicks: " + _clicks;
}

private void Decrease_Click(object sender, RoutedEventArgs e)
{
    if(_clicks > 0)
    {
        _clicks -= 1;
        clickTextBlock.Text = "Number of Clicks: " + _clicks;
    }
}
```

## <a name="recommendations"></a><span data-ttu-id="3f6ac-145">推奨事項</span><span class="sxs-lookup"><span data-stu-id="3f6ac-145">Recommendations</span></span>

-   <span data-ttu-id="3f6ac-146">ボタンの用途と状態をユーザーがはっきりと理解できるようにします。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-146">Make sure the purpose and state of a button are clear to the user.</span></span>
-   <span data-ttu-id="3f6ac-147">ボタンによって行われる操作を明確に説明する、簡潔で具体的でわかりやすいテキストを使います。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-147">Use a concise, specific, self-explanatory text that clearly describes the action that the button performs.</span></span> <span data-ttu-id="3f6ac-148">通常、ボタンのテキスト コンテンツは、1 語の動詞です。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-148">Usually button text content is a single word, a verb.</span></span>
-   <span data-ttu-id="3f6ac-149">同じ意思決定に対して複数のボタンが存在する場合 (確認のダイアログなど)、コミット ボタンは次の順番で提示します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-149">When there are multiple buttons for the same decision (such as in a confirmation dialog), present the commit buttons in this order:</span></span>
    -   <span data-ttu-id="3f6ac-150">[OK]/[実行する]/[はい]</span><span class="sxs-lookup"><span data-stu-id="3f6ac-150">OK/[Do it]/Yes</span></span>
    -   <span data-ttu-id="3f6ac-151">[実行しない]/[いいえ]</span><span class="sxs-lookup"><span data-stu-id="3f6ac-151">[Don't do it]/No</span></span>
    -   <span data-ttu-id="3f6ac-152">[キャンセル]</span><span class="sxs-lookup"><span data-stu-id="3f6ac-152">Cancel</span></span>

    <span data-ttu-id="3f6ac-153">(この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。)</span><span class="sxs-lookup"><span data-stu-id="3f6ac-153">(where [Do it] and [Don't do it] are specific responses to the main instruction.)</span></span>

-   <span data-ttu-id="3f6ac-154">ボタンのテキスト コンテンツが動的な場合 (ローカライズされる場合など) は、ボタンのサイズがどのように変化し、その周囲のコントロールに何が起こるかを考えます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-154">If the button's text content is dynamic, for example, it is localized, consider how the button will resize and what will happen to controls around it.</span></span>
-   <span data-ttu-id="3f6ac-155">テキスト コンテンツの付いたコマンド ボタンの場合は、最小のボタン幅を使います。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-155">For command buttons with text content, use a minimum button width.</span></span>
-   <span data-ttu-id="3f6ac-156">テキスト コンテンツの付いた幅が狭い横長または縦長のコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-156">Avoid narrow, short, or tall command buttons with text content.</span></span>
-   <span data-ttu-id="3f6ac-157">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-157">Use the default font unless your brand guidelines tell you to use something different.</span></span>
-   <span data-ttu-id="3f6ac-158">ある操作をアプリの複数のページで実行できるようにするには、各ページでボタンを使うのではなく、[下部のアプリ バー](app-bars.md) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-158">For an action that needs to be available across multiple pages within your app, instead of duplicating a button on multiple pages, consider using a [bottom app bar](app-bars.md).</span></span>
-   <span data-ttu-id="3f6ac-159">ユーザーに対して表示するボタンは、1 つまたは 2 つにします (例: [承諾] と [キャンセル])。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-159">Expose only one or two buttons to the user at a time, for example, Accept and Cancel.</span></span> <span data-ttu-id="3f6ac-160">3 つ以上の操作をユーザーに示す必要がある場合は、ユーザーが操作を選択できる [チェック ボックス](checkbox.md) または [オプション ボタン](radio-button.md) を、それらの操作を開始するための 1 つのコマンド ボタンと共に使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-160">If you need to expose more actions to the user, consider using [checkboxes](checkbox.md) or [radio buttons](radio-button.md) from which the user can select actions, with a single command button to trigger those actions.</span></span>
-   <span data-ttu-id="3f6ac-161">最も一般的な操作や推奨される操作を示す既定のコマンド ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-161">Use the default command button to indicate the most common or recommended action.</span></span>
-   <span data-ttu-id="3f6ac-162">ボタンをカスタマイズすることを検討します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-162">Consider customizing your buttons.</span></span> <span data-ttu-id="3f6ac-163">ボタンの形は既定では四角形ですが、ボタンの外観を構成する視覚効果をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-163">A button's shape is rectangular by default, but you can customize the visuals that make up the button's appearance.</span></span> <span data-ttu-id="3f6ac-164">ボタンのコンテンツは、通常はテキスト (例: [承諾] や [キャンセル]) ですが、アイコンに置き換えるか、アイコンとテキストを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-164">A button's content is usually text—for example, Accept or Cancel—but you could replace the text with an icon, or use an icon plus text.</span></span>
-   <span data-ttu-id="3f6ac-165">ユーザーがボタンを操作したとき、ボタンの状態と外観を変更して、ユーザーにフィードバックを返します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-165">Make sure that as the user interacts with a button, the button changes state and appearance to provide feedback to the user.</span></span> <span data-ttu-id="3f6ac-166">ボタンの状態には、Normal、Pressed、Disabled などがあります。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-166">Normal, pressed, and disabled are examples of button states.</span></span>
-   <span data-ttu-id="3f6ac-167">ユーザーがボタンをタップまたはクリックしたときに、ボタンのアクションを開始します。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-167">Trigger the button's action when the user taps or presses the button.</span></span> <span data-ttu-id="3f6ac-168">通常、アクションは、ユーザーがボタンを離したときに開始されますが、指がボタンを押したときにボタンのアクションを開始するように設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-168">Usually the action is triggered when the user releases the button, but you also can set a button's action to trigger when a finger first presses it.</span></span>
-   <span data-ttu-id="3f6ac-169">送信、リセット、標準ボタンの既定のスタイルを取り替えないでください。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-169">Don't swap the default submit, reset, and button styles.</span></span>
-   <span data-ttu-id="3f6ac-170">ボタン内に多すぎるコンテンツを配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-170">Don't put too much content inside a button.</span></span> <span data-ttu-id="3f6ac-171">コンテンツは、簡潔でわかりやすくします。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-171">Make the content concise and easy to understand.</span></span>

### <a name="recommended-single-button-layout"></a><span data-ttu-id="3f6ac-172">単一のボタンの推奨レイアウト</span><span class="sxs-lookup"><span data-stu-id="3f6ac-172">Recommended single button layout</span></span>

<span data-ttu-id="3f6ac-173">ボタンを 1 つしか必要としないレイアウトでは、コンテナーのコンテキストに応じて、左揃えまたは右揃えにします。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-173">If your layout requires only one button, it should be either left- or right-aligned based on its container context.</span></span>

-   <span data-ttu-id="3f6ac-174">ボタンが 1 つだけのダイアログでは、ボタンを**右揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-174">Dialogs with only one button should **right-align** the button.</span></span> <span data-ttu-id="3f6ac-175">ダイアログにボタンが 1 つしかない場合は、ボタンによって安全で非破壊的な操作が実行されるようにします。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-175">If your dialog contains only one button, ensure that the button performs the safe, nondestructive action.</span></span> <span data-ttu-id="3f6ac-176">[ContentDialog](dialogs.md) を使い、単一のボタンを指定する場合は、自動的に右揃えになります。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-176">If you use [ContentDialog](dialogs.md) and specify a single button, it will automatically right-align.</span></span>

![ダイアログ内のボタン](images/pushbutton_doc_dialog.png)

-   <span data-ttu-id="3f6ac-178">ボタンがコンテナー UI 内 (トースト通知、ポップアップ、またはリスト ビュー項目内など) に表示される場合は、コンテナー内でボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-178">If your button appears within a container UI (for example, within a toast notification, a flyout, or a list view item), you should **right-align** the button within the container.</span></span>

![コンテナー内のボタン](images/pushbutton_doc_container.png)

-   <span data-ttu-id="3f6ac-180">ページに含まれるボタンが 1 つだけの場合は (設定ページの下部にある [適用] ボタンなど)、ボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-180">In pages that contain a single button (for example, an "Apply" button at the bottom of a settings page), you should **left-align** the button.</span></span> <span data-ttu-id="3f6ac-181">これで、ページのその他のコンテンツとボタンを揃えて配置できます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-181">This ensures that the button aligns with the rest of the page content.</span></span>

![ページのボタン](images/pushbutton_doc_page.png)

## <a name="back-buttons"></a><span data-ttu-id="3f6ac-183">戻るボタン</span><span class="sxs-lookup"><span data-stu-id="3f6ac-183">Back buttons</span></span>

<span data-ttu-id="3f6ac-184">戻るボタンは、バック スタックまたはユーザーのナビゲーション履歴を使って "戻る" ナビゲーションを実現する、システムの UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-184">The back button is a system-provided UI element that enables backward navigation through either the back stack or navigation history of the user.</span></span> <span data-ttu-id="3f6ac-185">独自の"戻る"ボタンを作成する必要はありませんが、前に戻る移動で適切なエクスペリエンスを提供するために作業が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-185">You don't have to create your own back button, but you might have to do some work to enable a good backwards navigation experience.</span></span> <span data-ttu-id="3f6ac-186">詳しくは、「[履歴と前に戻る移動](../layout/navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-186">For more info, see [History and backwards navigation](../layout/navigation-history-and-backwards-navigation.md)</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="3f6ac-187">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="3f6ac-187">Get the sample code</span></span>
*   [<span data-ttu-id="3f6ac-188">XAML UI の基本のサンプル</span><span class="sxs-lookup"><span data-stu-id="3f6ac-188">XAML UI basics sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)<br/>
    <span data-ttu-id="3f6ac-189">インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="3f6ac-189">See all of the XAML controls in an interactive format.</span></span>


## <a name="related-articles"></a><span data-ttu-id="3f6ac-190">関連記事</span><span class="sxs-lookup"><span data-stu-id="3f6ac-190">Related articles</span></span>

- [<span data-ttu-id="3f6ac-191">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="3f6ac-191">Radio buttons</span></span>](radio-button.md)
- [<span data-ttu-id="3f6ac-192">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="3f6ac-192">Toggle switches</span></span>](toggles.md)
- [<span data-ttu-id="3f6ac-193">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="3f6ac-193">Check boxes</span></span>](checkbox.md)
- [<span data-ttu-id="3f6ac-194">Button クラス</span><span class="sxs-lookup"><span data-stu-id="3f6ac-194">Button class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)
