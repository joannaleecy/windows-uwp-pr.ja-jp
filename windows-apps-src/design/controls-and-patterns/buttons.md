---
author: serenaz
Description: A button gives the user a way to trigger an immediate action.
title: ボタン
label: Buttons
template: detail.hbs
ms.author: sezhen
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
ms.localizationpriority: medium
ms.openlocfilehash: f663ce9da6453922e35f850a8cd039f33770f434
ms.sourcegitcommit: 4b522af988273946414a04fbbd1d7fde40f8ba5e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/08/2018
ms.locfileid: "1494169"
---
# <a name="buttons"></a><span data-ttu-id="83934-103">ボタン</span><span class="sxs-lookup"><span data-stu-id="83934-103">Buttons</span></span>


<span data-ttu-id="83934-104">ボタンは、特定の操作を直ちに実行する手段をユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="83934-104">A button gives the user a way to trigger an immediate action.</span></span>

> <span data-ttu-id="83934-105">**重要な API**: [Button クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)、[RepeatButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx)、[Click イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx)</span><span class="sxs-lookup"><span data-stu-id="83934-105">**Important APIs**: [Button class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx), [RepeatButton class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx), [Click event](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx)</span></span>

![ボタンの例](images/controls/button.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="83934-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="83934-107">Is this the right control?</span></span>

<span data-ttu-id="83934-108">ボタンを使うと、ユーザーは直ちに操作を開始できます (フォームの送信など)。</span><span class="sxs-lookup"><span data-stu-id="83934-108">A button lets the user initiate an immediate action, such as submitting a form.</span></span>

<span data-ttu-id="83934-109">他のページに移動する操作では、ボタンは使わず、リンクを使います。</span><span class="sxs-lookup"><span data-stu-id="83934-109">Don't use a button when the action is to navigate to another page; use a link instead.</span></span> <span data-ttu-id="83934-110">詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="83934-110">See [Hyperlinks](hyperlinks.md) for more info.</span></span>
> <span data-ttu-id="83934-111">例外: ウィザードでのページの移動には、[戻る] と [次へ] というラベルのボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="83934-111">Exception: For wizard navigation, use buttons labeled "Back" and "Next".</span></span> <span data-ttu-id="83934-112">他の種類の前に戻る移動や上位レベルへの移動では、[戻る] ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="83934-112">For other types of backwards navigation or navigation to an upper level, use a back button.</span></span>

## <a name="examples"></a><span data-ttu-id="83934-113">例</span><span class="sxs-lookup"><span data-stu-id="83934-113">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="83934-114">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="83934-114">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="83934-115"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Button">アプリを開き、Button の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="83934-115">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Button">open the app and see the Button in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="83934-116">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="83934-116">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="83934-117">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="83934-117">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="83934-118">この例では、一情報へのアクセスを求めるダイアログ ボックスで、2 つのボタン ([Allow] (許可) と [Block] (禁止)) を使っています。</span><span class="sxs-lookup"><span data-stu-id="83934-118">This example uses two buttons, Allow and Block, in a dialog requesting location access.</span></span>

![ダイアログで使われるボタンの例](images/dialogs/dialog_RS2_two_button.png)

## <a name="create-a-button"></a><span data-ttu-id="83934-120">ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="83934-120">Create a button</span></span>

<span data-ttu-id="83934-121">クリックに応答するボタンの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="83934-121">This example shows a button that responds to a click.</span></span>

<span data-ttu-id="83934-122">XAML でボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="83934-122">Create the button in XAML.</span></span>

```xaml
<Button Content="Subscribe" Click="SubscribeButton_Click"/>
```

<span data-ttu-id="83934-123">または、コードでボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="83934-123">Or create the button in code.</span></span>

```csharp
Button subscribeButton = new Button();
subscribeButton.Content = "Subscribe";
subscribeButton.Click += SubscribeButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(subscribeButton);
```

<span data-ttu-id="83934-124">Click イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="83934-124">Handle the Click event.</span></span>

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

### <a name="button-interaction"></a><span data-ttu-id="83934-125">ボタンの対話式操作</span><span class="sxs-lookup"><span data-stu-id="83934-125">Button interaction</span></span>

<span data-ttu-id="83934-126">ポインターがボタンの上にあるときに、指やスタイラスでそのボタンをタップするか、マウスの左ボタンを押すと、ボタンでは [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="83934-126">When you tap a Button with a finger or stylus, or press a left mouse button while the pointer is over it, the button raises the [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) event.</span></span> <span data-ttu-id="83934-127">ボタンにキーボード フォーカスがある場合は、Enter キーまたは Space キーを押しても、Click イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="83934-127">If a button has keyboard focus, pressing the Enter key or the Spacebar key also raises the Click event.</span></span>

<span data-ttu-id="83934-128">通常、ボタンでは低レベルな [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントを処理できません。これに代わる Click 動作があるためです。</span><span class="sxs-lookup"><span data-stu-id="83934-128">You generally can't handle low-level [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) events on a Button because it has the Click behavior instead.</span></span> <span data-ttu-id="83934-129">詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="83934-129">For more info, see [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx).</span></span>

<span data-ttu-id="83934-130">ボタンで Click イベントが発生する方法を変えるには、[ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="83934-130">You can change how a button raises the Click event by changing the [ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) property.</span></span> <span data-ttu-id="83934-131">ClickMode の既定値は **Release** ですが、ボタンの ClickMode を **Hover** または **Press** に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="83934-131">The default ClickMode value is **Release**, but you also can set a button's ClickMode to **Hover** or **Press**.</span></span> <span data-ttu-id="83934-132">ClickMode が **Hover** の場合、キーボード操作やタッチ操作によって Click イベントを発生させることはできません。</span><span class="sxs-lookup"><span data-stu-id="83934-132">If ClickMode is **Hover**, the Click event can't be raised with the keyboard or touch.</span></span>


### <a name="button-content"></a><span data-ttu-id="83934-133">ボタンのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="83934-133">Button content</span></span>

<span data-ttu-id="83934-134">ボタンは [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx) です。</span><span class="sxs-lookup"><span data-stu-id="83934-134">Button is a [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx).</span></span> <span data-ttu-id="83934-135">その XAML コンテンツ プロパティは [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) であり、`<Button>A button's content</Button>` のような XAML 構文を使用できます。</span><span class="sxs-lookup"><span data-stu-id="83934-135">Its XAML content property is [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx), which enables a syntax like this for XAML: `<Button>A button's content</Button>`.</span></span> <span data-ttu-id="83934-136">任意のオブジェクトをボタンのコンテンツとして設定できます。</span><span class="sxs-lookup"><span data-stu-id="83934-136">You can set any object as the button's content.</span></span> <span data-ttu-id="83934-137">コンテンツが [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) の場合、ボタンにレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="83934-137">If the content is a [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx), it is rendered in the button.</span></span> <span data-ttu-id="83934-138">コンテンツが別のタイプのオブジェクトの場合、その文字列表現がボタンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="83934-138">If the content is another type of object, its string representation is shown in the button.</span></span>

<span data-ttu-id="83934-139">ボタンのコンテンツは、通常はテキストです。</span><span class="sxs-lookup"><span data-stu-id="83934-139">A button's content is usually text.</span></span> <span data-ttu-id="83934-140">テキスト コンテンツの付いたボタンの設計に関する推奨事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="83934-140">Here are design recommendations for buttons with text content:</span></span>
-   <span data-ttu-id="83934-141">ボタンによって行われる操作を明確に説明する、簡潔で具体的でわかりやすいテキストを使います。</span><span class="sxs-lookup"><span data-stu-id="83934-141">Use a concise, specific, self-explanatory text that clearly describes the action that the button performs.</span></span> <span data-ttu-id="83934-142">通常、ボタンのテキスト コンテンツは、1 語の動詞です。</span><span class="sxs-lookup"><span data-stu-id="83934-142">Usually button text content is a single word, a verb.</span></span>
-   <span data-ttu-id="83934-143">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="83934-143">Use the default font unless your brand guidelines tell you to use something different.</span></span>
-   <span data-ttu-id="83934-144">短いテキストでは、120px の最小ボタン幅を使用し、幅が狭いコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="83934-144">For shorter text, avoid narrow command buttons by using a minimum button width of 120px.</span></span>
- <span data-ttu-id="83934-145">長いテキストでは、テキストを最大文字数 26 文字に制限し、さまざまなコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="83934-145">For longer text, avoid wide command buttons by limiting text to a maximum length of 26 characters.</span></span>
-   <span data-ttu-id="83934-146">ボタンのテキスト コンテンツが動的な場合 ([ローカライズされる](../globalizing/globalizing-portal.md) 場合など) は、ボタンのサイズがどのように変化し、その周囲のコントロールに何が起こるかを考えます。</span><span class="sxs-lookup"><span data-stu-id="83934-146">If the button's text content is dynamic (i.e., it is [localized](../globalizing/globalizing-portal.md)), consider how the button will resize and what will happen to controls around it.</span></span>

<table>
<tr>
<td> <b><span data-ttu-id="83934-147">必要な修正:</span><span class="sxs-lookup"><span data-stu-id="83934-147">Need to fix:</span></span></b><br> <span data-ttu-id="83934-148">オーバーフロー テキストの付いたボタン。</span><span class="sxs-lookup"><span data-stu-id="83934-148">Buttons with overflowing text.</span></span> </td>
<td> <img src="images/button-wraptext.png"/> </td>
</tr>
<tr>
<td> <b><span data-ttu-id="83934-149">オプション 1:</span><span class="sxs-lookup"><span data-stu-id="83934-149">Option 1:</span></span></b><br> <span data-ttu-id="83934-150">テキストの長さが 26 文字より大きい場合は、ボタンの幅やスタック ボタンを増やし、テキストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="83934-150">Increase button width, stack buttons, and wrap if text length is greater than 26 characters.</span></span> </td>
<td> <img src="images/button-wraptext1.png"> </td>
</tr>
<tr>
<td> <b><span data-ttu-id="83934-151">オプション 2:</span><span class="sxs-lookup"><span data-stu-id="83934-151">Option 2:</span></span></b><br> <span data-ttu-id="83934-152">ボタンの高さを増やし、テキストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="83934-152">Increase button height, and wrap text.</span></span> </td>
<td> <img src="images/button-wraptext2.png"> </td>
</tr>
</table>

<span data-ttu-id="83934-153">ボタンの外観を構成する視覚効果をカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="83934-153">You can also customize visuals that make up the button's appearance.</span></span> <span data-ttu-id="83934-154">たとえば、テキストをアイコンに置き換えたり、アイコンとテキストを使用したりできます。</span><span class="sxs-lookup"><span data-stu-id="83934-154">For example, you could replace the text with an icon, or use an icon plus text.</span></span>

<span data-ttu-id="83934-155">ここでは、画像とテキストを含む **StackPanel** がボタンのコンテンツとして設定されます。</span><span class="sxs-lookup"><span data-stu-id="83934-155">Here, a **StackPanel** that contains an image and text is set as the content of a button.</span></span>

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

<span data-ttu-id="83934-156">ボタンは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="83934-156">The button looks like this.</span></span>

![画像とテキスト コンテンツがあるボタン](images/button-orange.png)

## <a name="create-a-repeat-button"></a><span data-ttu-id="83934-158">繰り返しボタンの作成</span><span class="sxs-lookup"><span data-stu-id="83934-158">Create a repeat button</span></span>

<span data-ttu-id="83934-159">[RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) は、ボタンが押されてから離されるまで、繰り返し [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントを発生させるボタンです。</span><span class="sxs-lookup"><span data-stu-id="83934-159">A [RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) is a button that raises [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) events repeatedly from the time it's pressed until it's released.</span></span> <span data-ttu-id="83934-160">ボタンが押されてからクリック操作の繰り返しを始めるまでの RepeatButton の待ち時間を指定するには、[Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="83934-160">Set the [Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) property to specify the time that the RepeatButton waits after it is pressed before it starts repeating the click action.</span></span> <span data-ttu-id="83934-161">クリック操作の繰り返し間隔を指定するには、[Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="83934-161">Set the [Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) property to specify the time between repetitions of the click action.</span></span> <span data-ttu-id="83934-162">これらのプロパティの時間はどちらもミリ秒単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="83934-162">Times for both properties are specified in milliseconds.</span></span>

<span data-ttu-id="83934-163">次の例は 2 つの RepeatButton コントロールを示しています。それぞれの Click イベントを使って、テキスト ブロックに表示される値を増減します。</span><span class="sxs-lookup"><span data-stu-id="83934-163">The following example shows two RepeatButton controls whose respective Click events are used to increase and decrease the value shown in a text block.</span></span>

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

## <a name="recommendations"></a><span data-ttu-id="83934-164">推奨事項</span><span class="sxs-lookup"><span data-stu-id="83934-164">Recommendations</span></span>
-   <span data-ttu-id="83934-165">ボタンの用途と状態をユーザーがはっきりと理解できるようにします。</span><span class="sxs-lookup"><span data-stu-id="83934-165">Make sure the purpose and state of a button are clear to the user.</span></span>
-   <span data-ttu-id="83934-166">同じ意思決定に対して複数のボタンが存在する場合 (確認のダイアログなど)、コミット ボタンは次の順番で提示します。この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。</span><span class="sxs-lookup"><span data-stu-id="83934-166">When there are multiple buttons for the same decision (such as in a confirmation dialog), present the commit buttons in this order, where [Do it] and [Don't do it] are specific responses to the main instruction:</span></span>
    -   <span data-ttu-id="83934-167">[OK]/[実行する]/[はい]</span><span class="sxs-lookup"><span data-stu-id="83934-167">OK/[Do it]/Yes</span></span>
    -   <span data-ttu-id="83934-168">[実行しない]/[いいえ]</span><span class="sxs-lookup"><span data-stu-id="83934-168">[Don't do it]/No</span></span>
    -   <span data-ttu-id="83934-169">[キャンセル]</span><span class="sxs-lookup"><span data-stu-id="83934-169">Cancel</span></span>
-   <span data-ttu-id="83934-170">ユーザーに対して表示するボタンは、1 つまたは 2 つにします (例: [承諾] と [キャンセル])。</span><span class="sxs-lookup"><span data-stu-id="83934-170">Expose only one or two buttons to the user at a time, for example, Accept and Cancel.</span></span> <span data-ttu-id="83934-171">3 つ以上の操作をユーザーに示す必要がある場合は、ユーザーが操作を選択できる [チェック ボックス](checkbox.md) または [オプション ボタン](radio-button.md) を、それらの操作を開始するための 1 つのコマンド ボタンと共に使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="83934-171">If you need to expose more actions to the user, consider using [checkboxes](checkbox.md) or [radio buttons](radio-button.md) from which the user can select actions, with a single command button to trigger those actions.</span></span>
-   <span data-ttu-id="83934-172">ある操作をアプリの複数のページで実行できるようにするには、各ページでボタンを使うのではなく、[下部のアプリ バー](app-bars.md) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="83934-172">For an action that needs to be available across multiple pages within your app, instead of duplicating a button on multiple pages, consider using a [bottom app bar](app-bars.md).</span></span>

### <a name="recommended-single-button-layout"></a><span data-ttu-id="83934-173">単一のボタンの推奨レイアウト</span><span class="sxs-lookup"><span data-stu-id="83934-173">Recommended single button layout</span></span>

<span data-ttu-id="83934-174">ボタンを 1 つしか必要としないレイアウトでは、コンテナーのコンテキストに応じて、左揃えまたは右揃えにします。</span><span class="sxs-lookup"><span data-stu-id="83934-174">If your layout requires only one button, it should be either left- or right-aligned based on its container context.</span></span>

-   <span data-ttu-id="83934-175">ボタンが 1 つだけのダイアログでは、ボタンを**右揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="83934-175">Dialogs with only one button should **right-align** the button.</span></span> <span data-ttu-id="83934-176">ダイアログにボタンが 1 つしかない場合は、ボタンによって安全で非破壊的な操作が実行されるようにします。</span><span class="sxs-lookup"><span data-stu-id="83934-176">If your dialog contains only one button, ensure that the button performs the safe, nondestructive action.</span></span> <span data-ttu-id="83934-177">[ContentDialog](dialogs.md) を使い、単一のボタンを指定する場合は、自動的に右揃えになります。</span><span class="sxs-lookup"><span data-stu-id="83934-177">If you use [ContentDialog](dialogs.md) and specify a single button, it will automatically right-align.</span></span>

![ダイアログ内のボタン](images/pushbutton_doc_dialog.png)

-   <span data-ttu-id="83934-179">ボタンがコンテナー UI 内 (トースト通知、ポップアップ、またはリスト ビュー項目内など) に表示される場合は、コンテナー内でボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="83934-179">If your button appears within a container UI (for example, within a toast notification, a flyout, or a list view item), you should **right-align** the button within the container.</span></span>

![コンテナー内のボタン](images/pushbutton_doc_container.png)

-   <span data-ttu-id="83934-181">ページに含まれるボタンが 1 つだけの場合は (設定ページの下部にある [適用] ボタンなど)、ボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="83934-181">In pages that contain a single button (for example, an "Apply" button at the bottom of a settings page), you should **left-align** the button.</span></span> <span data-ttu-id="83934-182">これで、ページのその他のコンテンツとボタンを揃えて配置できます。</span><span class="sxs-lookup"><span data-stu-id="83934-182">This ensures that the button aligns with the rest of the page content.</span></span>

![ページのボタン](images/pushbutton_doc_page.png)

## <a name="back-buttons"></a><span data-ttu-id="83934-184">戻るボタン</span><span class="sxs-lookup"><span data-stu-id="83934-184">Back buttons</span></span>

<span data-ttu-id="83934-185">戻るボタンは、バック スタックまたはユーザーのナビゲーション履歴を使って "戻る" ナビゲーションを実現する、システムの UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="83934-185">The back button is a system-provided UI element that enables backward navigation through either the back stack or navigation history of the user.</span></span> <span data-ttu-id="83934-186">独自の"戻る"ボタンを作成する必要はありませんが、前に戻る移動で適切なエクスペリエンスを提供するために作業が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="83934-186">You don't have to create your own back button, but you might have to do some work to enable a good backwards navigation experience.</span></span> <span data-ttu-id="83934-187">詳しくは、「[履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="83934-187">For more info, see [History and backwards navigation](../basics/navigation-history-and-backwards-navigation.md)</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="83934-188">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="83934-188">Get the sample code</span></span>

- <span data-ttu-id="83934-189">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="83934-189">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>


## <a name="related-articles"></a><span data-ttu-id="83934-190">関連記事</span><span class="sxs-lookup"><span data-stu-id="83934-190">Related articles</span></span>
- [<span data-ttu-id="83934-191">Button クラス</span><span class="sxs-lookup"><span data-stu-id="83934-191">Button class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)
- [<span data-ttu-id="83934-192">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="83934-192">Radio buttons</span></span>](radio-button.md)
- [<span data-ttu-id="83934-193">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="83934-193">Check boxes</span></span>](checkbox.md)
- [<span data-ttu-id="83934-194">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="83934-194">Toggle switches</span></span>](toggles.md)
