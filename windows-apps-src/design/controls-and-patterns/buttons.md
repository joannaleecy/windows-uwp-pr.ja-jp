---
Description: A button gives the user a way to trigger an immediate action.
title: ボタン
label: Buttons
template: detail.hbs
ms.date: 10/2/2018
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: f04d1a3c-7dcd-4bc8-9586-3396923b312e
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 5b755533cd4f0720477988781e6cc955b532f1a9
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8331563"
---
# <a name="buttons"></a><span data-ttu-id="025b0-103">ボタン</span><span class="sxs-lookup"><span data-stu-id="025b0-103">Buttons</span></span>

<span data-ttu-id="025b0-104">ボタンは、特定の操作を直ちに実行する方法をユーザーに与えます。</span><span class="sxs-lookup"><span data-stu-id="025b0-104">A button gives the user a way to trigger an immediate action.</span></span> <span data-ttu-id="025b0-105">いくつかのボタンはナビゲーション、繰り返される操作は、メニューを表示するなど、特定のタスクの特殊な。</span><span class="sxs-lookup"><span data-stu-id="025b0-105">Some buttons are specialized for particular tasks, such as navigation, repeated actions, or presenting menus.</span></span>

![ボタンの例](images/controls/button.png)

<span data-ttu-id="025b0-107">XAML フレームワークでは、いくつかの特殊なボタン コントロールと同様に、標準的なボタン コントロールを提供します。</span><span class="sxs-lookup"><span data-stu-id="025b0-107">The XAML framework provides a standard button control as well as several specialized button controls.</span></span>

<span data-ttu-id="025b0-108">コントロール</span><span class="sxs-lookup"><span data-stu-id="025b0-108">Control</span></span> | <span data-ttu-id="025b0-109">説明</span><span class="sxs-lookup"><span data-stu-id="025b0-109">Description</span></span>
------- | -----------
[<span data-ttu-id="025b0-110">ボタン</span><span class="sxs-lookup"><span data-stu-id="025b0-110">Button</span></span>](/uwp/api/windows.ui.xaml.controls.button) | <span data-ttu-id="025b0-111">即座にアクションを開始します。</span><span class="sxs-lookup"><span data-stu-id="025b0-111">Initiates an immediate action.</span></span> <span data-ttu-id="025b0-112">Click イベントまたはコマンドのバインディングを使用できます。</span><span class="sxs-lookup"><span data-stu-id="025b0-112">Can be used with a Click event or Command binding.</span></span>
[<span data-ttu-id="025b0-113">RepeatButton</span><span class="sxs-lookup"><span data-stu-id="025b0-113">RepeatButton</span></span>](/uwp/api/windows.ui.xaml.controls.primitives.repeatbutton) | <span data-ttu-id="025b0-114">押されている間に継続的には、Click イベントを発生させるボタンです。</span><span class="sxs-lookup"><span data-stu-id="025b0-114">A button that raises a Click event continuously while pressed.</span></span>
[<span data-ttu-id="025b0-115">HyperlinkButton</span><span class="sxs-lookup"><span data-stu-id="025b0-115">HyperlinkButton</span></span>](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton) | <span data-ttu-id="025b0-116">A ボタンをナビゲーションの使用、ハイパーリンクのようにスタイルが適用されます。</span><span class="sxs-lookup"><span data-stu-id="025b0-116">A button that's styled like a hyperlink, used for navigation.</span></span> <span data-ttu-id="025b0-117">詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="025b0-117">See [Hyperlinks](hyperlinks.md) for more info.</span></span>
[<span data-ttu-id="025b0-118">DropDownButton</span><span class="sxs-lookup"><span data-stu-id="025b0-118">DropDownButton</span></span>](/uwp/api/windows.ui.xaml.controls.dropdownbutton) | <span data-ttu-id="025b0-119">添付のポップアップを開く山形記号のボタンです。</span><span class="sxs-lookup"><span data-stu-id="025b0-119">A button with a chevron to open an attached flyout.</span></span>
[<span data-ttu-id="025b0-120">SplitButton</span><span class="sxs-lookup"><span data-stu-id="025b0-120">SplitButton</span></span>](/uwp/api/windows.ui.xaml.controls.splitbutton) | <span data-ttu-id="025b0-121">2 つの辺ボタンです。</span><span class="sxs-lookup"><span data-stu-id="025b0-121">A button with two sides.</span></span> <span data-ttu-id="025b0-122">一方の辺の操作を開始して、その他の側にメニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="025b0-122">One side initiates an action, and the other side opens a menu.</span></span>
[<span data-ttu-id="025b0-123">ToggleSplitButton</span><span class="sxs-lookup"><span data-stu-id="025b0-123">ToggleSplitButton</span></span>](/uwp/api/windows.ui.xaml.controls.togglesplitbutton) | <span data-ttu-id="025b0-124">2 つの辺とトグル ボタン。</span><span class="sxs-lookup"><span data-stu-id="025b0-124">A toggle button with two sides.</span></span> <span data-ttu-id="025b0-125">一方の辺をオン/オフを切り替えます、反対側メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="025b0-125">One side toggles on/off, and the other side opens a menu.</span></span>

| **<span data-ttu-id="025b0-126">Windows UI のライブラリを入手します。</span><span class="sxs-lookup"><span data-stu-id="025b0-126">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="025b0-127">DropDownButton、分割ボタンと ToggleSplitButton は、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="025b0-127">DropDownButton, SplitButton, and ToggleSplitButton are included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="025b0-128">詳しくは、インストール手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="025b0-128">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

| **<span data-ttu-id="025b0-129">プラットフォーム Api</span><span class="sxs-lookup"><span data-stu-id="025b0-129">Platform APIs</span></span>** | **<span data-ttu-id="025b0-130">Windows UI ライブラリ Api</span><span class="sxs-lookup"><span data-stu-id="025b0-130">Windows UI Library APIs</span></span>** |
| - | - |
| <span data-ttu-id="025b0-131">して[click イベント](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)、[コマンドのプロパティ](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.command)</span><span class="sxs-lookup"><span data-stu-id="025b0-131">[Click event](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click), [Command property](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.command)</span></span> | <span data-ttu-id="025b0-132">[DropDownButton クラス](/uwp/api/microsoft.ui.xaml.controls.dropdownbutton)、 [SplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.splitbutton)、 [ToggleSplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.togglesplitbutton)</span><span class="sxs-lookup"><span data-stu-id="025b0-132">[DropDownButton class](/uwp/api/microsoft.ui.xaml.controls.dropdownbutton), [SplitButton class](/uwp/api/microsoft.ui.xaml.controls.splitbutton), [ToggleSplitButton class](/uwp/api/microsoft.ui.xaml.controls.togglesplitbutton)</span></span> |

## <a name="is-this-the-right-control"></a><span data-ttu-id="025b0-133">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="025b0-133">Is this the right control?</span></span>

<span data-ttu-id="025b0-134">ユーザーがフォームの送信など、即座にアクションを開始できるようにするには、**ボタン**を使います。</span><span class="sxs-lookup"><span data-stu-id="025b0-134">Use a **Button** to let the user initiate an immediate action, such as submitting a form.</span></span>

<span data-ttu-id="025b0-135">別のページに移動する操作では、ボタンを使用しないでください。[HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton)を使用してください。</span><span class="sxs-lookup"><span data-stu-id="025b0-135">Don't use a button when the action is to navigate to another page; use a [HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton) instead.</span></span> <span data-ttu-id="025b0-136">詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="025b0-136">See [Hyperlinks](hyperlinks.md) for more info.</span></span>
> <span data-ttu-id="025b0-137">例外: ウィザードでのページの移動には、[戻る] と [次へ] というラベルのボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="025b0-137">Exception: For wizard navigation, use buttons labeled "Back" and "Next".</span></span> <span data-ttu-id="025b0-138">他の種類の前に戻るまたは、上位レベルへのナビゲーションを使用して、 [[戻る] ボタン](../basics/navigation-history-and-backwards-navigation.md)。</span><span class="sxs-lookup"><span data-stu-id="025b0-138">For other types of backwards navigation or navigation to an upper level, use a [back button](../basics/navigation-history-and-backwards-navigation.md).</span></span>

<span data-ttu-id="025b0-139">ユーザーは、繰り返しアクションをトリガーする場合は、 **RepeatButton**を使用します。</span><span class="sxs-lookup"><span data-stu-id="025b0-139">Use a **RepeatButton** when the user might want to trigger an action repeatedly.</span></span> <span data-ttu-id="025b0-140">たとえば、カウンターの値を増減する、RepeatButton を使用します。</span><span class="sxs-lookup"><span data-stu-id="025b0-140">For example, use a RepeatButton to increment or decrement a value in a counter.</span></span>

<span data-ttu-id="025b0-141">ボタンには、ポップアップの他のオプションが含まれている場合は、 **DropDownButton**を使用します。</span><span class="sxs-lookup"><span data-stu-id="025b0-141">Use a **DropDownButton** when the button has a flyout that contains more options.</span></span> <span data-ttu-id="025b0-142">既定の山形記号のボタンがポップアップに含まれることを視覚を提供します。</span><span class="sxs-lookup"><span data-stu-id="025b0-142">The default chevron provides a visual indication that the button includes a flyout.</span></span>

<span data-ttu-id="025b0-143">ユーザーを即座にアクションを開始またはいない追加のオプションからを個別に選択できるようにする場合は、 **SplitButton**を使用します。</span><span class="sxs-lookup"><span data-stu-id="025b0-143">Use a **SplitButton** when you want the user to be able to initiate an immediate action or choose from additional options independently.</span></span>

## <a name="examples"></a><span data-ttu-id="025b0-144">例</span><span class="sxs-lookup"><span data-stu-id="025b0-144">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="025b0-145">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="025b0-145">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="025b0-146"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Button">アプリを開き、Button の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="025b0-146">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Button">open the app and see the Button in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="025b0-147">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="025b0-147">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="025b0-148">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="025b0-148">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="025b0-149">この例では、一情報へのアクセスを求めるダイアログ ボックスで、2 つのボタン ([Allow] (許可) と [Block] (禁止)) を使っています。</span><span class="sxs-lookup"><span data-stu-id="025b0-149">This example uses two buttons, Allow and Block, in a dialog requesting location access.</span></span>

![ダイアログで使われるボタンの例](images/dialogs/dialog_RS2_two_button.png)

## <a name="create-a-button"></a><span data-ttu-id="025b0-151">ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="025b0-151">Create a button</span></span>

<span data-ttu-id="025b0-152">クリックに応答するボタンの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="025b0-152">This example shows a button that responds to a click.</span></span>

<span data-ttu-id="025b0-153">XAML でボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="025b0-153">Create the button in XAML.</span></span>

```xaml
<Button Content="Subscribe" Click="SubscribeButton_Click"/>
```

<span data-ttu-id="025b0-154">または、コードでボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="025b0-154">Or create the button in code.</span></span>

```csharp
Button subscribeButton = new Button();
subscribeButton.Content = "Subscribe";
subscribeButton.Click += SubscribeButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(subscribeButton);
```

<span data-ttu-id="025b0-155">Click イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="025b0-155">Handle the Click event.</span></span>

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

### <a name="button-interaction"></a><span data-ttu-id="025b0-156">ボタンの対話式操作</span><span class="sxs-lookup"><span data-stu-id="025b0-156">Button interaction</span></span>

<span data-ttu-id="025b0-157">ポインターがボタンの上にあるときに、指やスタイラスでそのボタンをタップするか、マウスの左ボタンを押すと、ボタンでは [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="025b0-157">When you tap a Button with a finger or stylus, or press a left mouse button while the pointer is over it, the button raises the [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) event.</span></span> <span data-ttu-id="025b0-158">ボタンにキーボード フォーカスがある場合は、Enter キーまたは Space キーを押しても、Click イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="025b0-158">If a button has keyboard focus, pressing the Enter key or the Spacebar key also raises the Click event.</span></span>

<span data-ttu-id="025b0-159">通常、ボタンでは低レベルな [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントを処理できません。これに代わる Click 動作があるためです。</span><span class="sxs-lookup"><span data-stu-id="025b0-159">You generally can't handle low-level [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) events on a Button because it has the Click behavior instead.</span></span> <span data-ttu-id="025b0-160">詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="025b0-160">For more info, see [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx).</span></span>

<span data-ttu-id="025b0-161">ボタンで Click イベントが発生する方法を変えるには、[ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="025b0-161">You can change how a button raises the Click event by changing the [ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) property.</span></span> <span data-ttu-id="025b0-162">ClickMode の既定値は **Release** ですが、ボタンの ClickMode を **Hover** または **Press** に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="025b0-162">The default ClickMode value is **Release**, but you also can set a button's ClickMode to **Hover** or **Press**.</span></span> <span data-ttu-id="025b0-163">ClickMode が **Hover** の場合、キーボード操作やタッチ操作によって Click イベントを発生させることはできません。</span><span class="sxs-lookup"><span data-stu-id="025b0-163">If ClickMode is **Hover**, the Click event can't be raised with the keyboard or touch.</span></span>


### <a name="button-content"></a><span data-ttu-id="025b0-164">ボタンのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="025b0-164">Button content</span></span>

<span data-ttu-id="025b0-165">ボタンは [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx) です。</span><span class="sxs-lookup"><span data-stu-id="025b0-165">Button is a [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx).</span></span> <span data-ttu-id="025b0-166">その XAML コンテンツ プロパティは [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) であり、`<Button>A button's content</Button>` のような XAML 構文を使用できます。</span><span class="sxs-lookup"><span data-stu-id="025b0-166">Its XAML content property is [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx), which enables a syntax like this for XAML: `<Button>A button's content</Button>`.</span></span> <span data-ttu-id="025b0-167">任意のオブジェクトをボタンのコンテンツとして設定できます。</span><span class="sxs-lookup"><span data-stu-id="025b0-167">You can set any object as the button's content.</span></span> <span data-ttu-id="025b0-168">コンテンツが [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) の場合、ボタンにレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="025b0-168">If the content is a [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx), it is rendered in the button.</span></span> <span data-ttu-id="025b0-169">コンテンツが別のタイプのオブジェクトの場合、その文字列表現がボタンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="025b0-169">If the content is another type of object, its string representation is shown in the button.</span></span>

<span data-ttu-id="025b0-170">ボタンのコンテンツは、通常はテキストです。</span><span class="sxs-lookup"><span data-stu-id="025b0-170">A button's content is usually text.</span></span> <span data-ttu-id="025b0-171">テキスト コンテンツの付いたボタンの設計に関する推奨事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="025b0-171">Here are design recommendations for buttons with text content:</span></span>
-   <span data-ttu-id="025b0-172">ボタンによって行われる操作を明確に説明する、簡潔で具体的でわかりやすいテキストを使います。</span><span class="sxs-lookup"><span data-stu-id="025b0-172">Use a concise, specific, self-explanatory text that clearly describes the action that the button performs.</span></span> <span data-ttu-id="025b0-173">通常、ボタンのテキスト コンテンツは、1 語の動詞です。</span><span class="sxs-lookup"><span data-stu-id="025b0-173">Usually button text content is a single word, a verb.</span></span>
-   <span data-ttu-id="025b0-174">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="025b0-174">Use the default font unless your brand guidelines tell you to use something different.</span></span>
-   <span data-ttu-id="025b0-175">短いテキストでは、120px の最小ボタン幅を使用し、幅が狭いコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="025b0-175">For shorter text, avoid narrow command buttons by using a minimum button width of 120px.</span></span>
- <span data-ttu-id="025b0-176">長いテキストでは、テキストを最大文字数 26 文字に制限し、さまざまなコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="025b0-176">For longer text, avoid wide command buttons by limiting text to a maximum length of 26 characters.</span></span>
-   <span data-ttu-id="025b0-177">ボタンのテキスト コンテンツが動的な場合 ([ローカライズされる](../globalizing/globalizing-portal.md) 場合など) は、ボタンのサイズがどのように変化し、その周囲のコントロールに何が起こるかを考えます。</span><span class="sxs-lookup"><span data-stu-id="025b0-177">If the button's text content is dynamic (i.e., it is [localized](../globalizing/globalizing-portal.md)), consider how the button will resize and what will happen to controls around it.</span></span>

<table>
<tr>
<td> <b><span data-ttu-id="025b0-178">必要な修正:</span><span class="sxs-lookup"><span data-stu-id="025b0-178">Need to fix:</span></span></b><br> <span data-ttu-id="025b0-179">オーバーフロー テキストの付いたボタン。</span><span class="sxs-lookup"><span data-stu-id="025b0-179">Buttons with overflowing text.</span></span> </td>
<td> <img src="images/button-wraptext.png"/> </td>
</tr>
<tr>
<td> <b><span data-ttu-id="025b0-180">オプション 1:</span><span class="sxs-lookup"><span data-stu-id="025b0-180">Option 1:</span></span></b><br> <span data-ttu-id="025b0-181">テキストの長さが 26 文字より大きい場合は、ボタンの幅やスタック ボタンを増やし、テキストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="025b0-181">Increase button width, stack buttons, and wrap if text length is greater than 26 characters.</span></span> </td>
<td> <img src="images/button-wraptext1.png"> </td>
</tr>
<tr>
<td> <b><span data-ttu-id="025b0-182">オプション 2:</span><span class="sxs-lookup"><span data-stu-id="025b0-182">Option 2:</span></span></b><br> <span data-ttu-id="025b0-183">ボタンの高さを増やし、テキストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="025b0-183">Increase button height, and wrap text.</span></span> </td>
<td> <img src="images/button-wraptext2.png"> </td>
</tr>
</table>

<span data-ttu-id="025b0-184">ボタンの外観を構成する視覚効果をカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="025b0-184">You can also customize visuals that make up the button's appearance.</span></span> <span data-ttu-id="025b0-185">たとえば、テキストをアイコンに置き換えたり、アイコンとテキストを使用したりできます。</span><span class="sxs-lookup"><span data-stu-id="025b0-185">For example, you could replace the text with an icon, or use an icon plus text.</span></span>

<span data-ttu-id="025b0-186">ここでは、画像とテキストを含む **StackPanel** がボタンのコンテンツとして設定されます。</span><span class="sxs-lookup"><span data-stu-id="025b0-186">Here, a **StackPanel** that contains an image and text is set as the content of a button.</span></span>

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

<span data-ttu-id="025b0-187">ボタンは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="025b0-187">The button looks like this.</span></span>

![画像とテキスト コンテンツがあるボタン](images/button-orange.png)

## <a name="create-a-repeat-button"></a><span data-ttu-id="025b0-189">繰り返しボタンの作成</span><span class="sxs-lookup"><span data-stu-id="025b0-189">Create a repeat button</span></span>

<span data-ttu-id="025b0-190">[RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) は、ボタンが押されてから離されるまで、繰り返し [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントを発生させるボタンです。</span><span class="sxs-lookup"><span data-stu-id="025b0-190">A [RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) is a button that raises [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) events repeatedly from the time it's pressed until it's released.</span></span> <span data-ttu-id="025b0-191">ボタンが押されてからクリック操作の繰り返しを始めるまでの RepeatButton の待ち時間を指定するには、[Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="025b0-191">Set the [Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) property to specify the time that the RepeatButton waits after it is pressed before it starts repeating the click action.</span></span> <span data-ttu-id="025b0-192">クリック操作の繰り返し間隔を指定するには、[Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="025b0-192">Set the [Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) property to specify the time between repetitions of the click action.</span></span> <span data-ttu-id="025b0-193">これらのプロパティの時間はどちらもミリ秒単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="025b0-193">Times for both properties are specified in milliseconds.</span></span>

<span data-ttu-id="025b0-194">次の例は 2 つの RepeatButton コントロールを示しています。それぞれの Click イベントを使って、テキスト ブロックに表示される値を増減します。</span><span class="sxs-lookup"><span data-stu-id="025b0-194">The following example shows two RepeatButton controls whose respective Click events are used to increase and decrease the value shown in a text block.</span></span>

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

## <a name="create-a-drop-down-button"></a><span data-ttu-id="025b0-195">ドロップダウン ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="025b0-195">Create a drop down button</span></span>

> <span data-ttu-id="025b0-196">DropDownButton には、Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) が必要ですか、後で、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。</span><span class="sxs-lookup"><span data-stu-id="025b0-196">DropDownButton requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="025b0-197">[DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton)は、その他のオプションが含まれている添付のポップアップが設定されている視覚的なインジケーターとして、山形記号を表示するボタンです。</span><span class="sxs-lookup"><span data-stu-id="025b0-197">A [DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton) is a button that shows a chevron as a visual indicator that it has an attached flyout that contains more options.</span></span> <span data-ttu-id="025b0-198">ポップアップ; の標準的なボタンと同じ動作があります。外観だけが異なります。</span><span class="sxs-lookup"><span data-stu-id="025b0-198">It has the same behavior as a standard Button with a flyout; only the appearance is different.</span></span>

<span data-ttu-id="025b0-199">ドロップダウン ボタンには、Click イベントが継承されますが、通常は使用しません。</span><span class="sxs-lookup"><span data-stu-id="025b0-199">The drop down button inherits the Click event, but you typically don't use it.</span></span> <span data-ttu-id="025b0-200">代わりに、ポップアップ プロパティを使用して、ポップアップをアタッチし、ポップアップ メニュー オプションを使用して、アクションを起動します。</span><span class="sxs-lookup"><span data-stu-id="025b0-200">Instead, you use the Flyout property to attach a flyout and invoke actions using menu options in the flyout.</span></span> <span data-ttu-id="025b0-201">ポップアップは、ボタンがクリックされたときに自動的に開きます。</span><span class="sxs-lookup"><span data-stu-id="025b0-201">The flyout opens automatically when the button is clicked.</span></span>

> [!TIP]
> <span data-ttu-id="025b0-202">ポップアップについて詳しくは、[メニューとコンテキスト メニュー](menus.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="025b0-202">For more info about flyouts, see [Menus and context menus](menus.md).</span></span>

### <a name="example---drop-down-button"></a><span data-ttu-id="025b0-203">例 - ドロップダウン ボタン</span><span class="sxs-lookup"><span data-stu-id="025b0-203">Example - Drop down button</span></span>

<span data-ttu-id="025b0-204">この例では、RichEditBox で段落の配置のコマンドを含むポップアップをドロップダウン ボタンを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="025b0-204">This example shows how to create a drop down button with a flyout that contains commands for paragraph alignment in a RichEditBox.</span></span> <span data-ttu-id="025b0-205">(詳細とコードは、参照[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="025b0-205">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>

![ドロップダウン ボタンを配置コマンド](images/drop-down-button-align.png)

```xaml
<DropDownButton ToolTipService.ToolTip="Alignment">
    <TextBlock FontFamily="Segoe MDL2 Assets" FontSize="16" Text="&#xE8E4;"/>
    <DropDownButton.Flyout>
        <MenuFlyout Placement="BottomEdgeAlignedLeft">
            <MenuFlyoutItem Text="Left" Icon="AlignLeft" Tag="left"
                            Click="AlignmentMenuFlyoutItem_Click"/>
            <MenuFlyoutItem Text="Center" Icon="AlignCenter" Tag="center"
                            Click="AlignmentMenuFlyoutItem_Click"/>
            <MenuFlyoutItem Text="Right" Icon="AlignRight" Tag="right"
                            Click="AlignmentMenuFlyoutItem_Click"/>
        </MenuFlyout>
    </DropDownButton.Flyout>
</DropDownButton>
```

```csharp
private void AlignmentMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
{
    var option = ((MenuFlyoutItem)sender).Tag.ToString();

    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        // Apply the alignment to the selected paragraphs.
        var paragraphFormatting = selectedText.ParagraphFormat;
        if (option == "left")
        {
            paragraphFormatting.Alignment = Windows.UI.Text.ParagraphAlignment.Left;
        }
        else if (option == "center")
        {
            paragraphFormatting.Alignment = Windows.UI.Text.ParagraphAlignment.Center;
        }
        else if (option == "right")
        {
            paragraphFormatting.Alignment = Windows.UI.Text.ParagraphAlignment.Right;
        }
    }
}
```

## <a name="create-a-split-button"></a><span data-ttu-id="025b0-207">分割ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="025b0-207">Create a split button</span></span>

> <span data-ttu-id="025b0-208">SplitButton には、Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) が必要ですか、後で、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。</span><span class="sxs-lookup"><span data-stu-id="025b0-208">SplitButton requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="025b0-209">[SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton)は、個別に呼び出すことができる 2 つの部分です。</span><span class="sxs-lookup"><span data-stu-id="025b0-209">A [SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton) has two parts that can be invoked separately.</span></span> <span data-ttu-id="025b0-210">1 つの部分では、標準的なボタンのように動作し、即座にアクションを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="025b0-210">One part behaves like a standard button and invokes an immediate action.</span></span> <span data-ttu-id="025b0-211">他の部分では、ユーザーが選択できる追加のオプションが含まれているポップアップを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="025b0-211">The other part invokes a flyout that contains additional options that the user can choose from.</span></span>

> [!NOTE]
> <span data-ttu-id="025b0-212">タッチで呼び出されると、分割ボタンと同様に動作ドロップダウン ボタンボタンの両方の部分では、ポップアップを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="025b0-212">When invoked with touch, the split button behaves as a drop down button; both halves of the button invoke the flyout.</span></span> <span data-ttu-id="025b0-213">入力の他の方法では、ユーザーが、ボタンのいずれかの半分を個別に呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="025b0-213">With other methods of input, a user can invoke either half of the button separately.</span></span>

<span data-ttu-id="025b0-214">分割ボタンの一般的な動作は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="025b0-214">The typical behavior for a split button is:</span></span>

- <span data-ttu-id="025b0-215">ユーザーは、ボタンの一部をクリックすると、ドロップダウンで、現在選択されているオプションを起動する Click イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="025b0-215">When the user clicks the button part, handle the Click event to invoke the option that's currently selected in the drop down.</span></span>
- <span data-ttu-id="025b0-216">ドロップダウンが開いているときは、オプションを両方の変更にドロップダウン リストで項目のハンドルの呼び出しが選択されると、それを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="025b0-216">When the drop down is open, handle invocation of the items in the drop down to both change which option is selected, and then invoke it.</span></span> <span data-ttu-id="025b0-217">ために、ポップアップの項目を呼び出すことが重要ボタンの Click イベントがタッチを使うときに発生しません。</span><span class="sxs-lookup"><span data-stu-id="025b0-217">It's important to invoke the flyout item because the button Click event doesn't occur when using touch.</span></span>

> [!TIP]
> <span data-ttu-id="025b0-218">ドロップ内の項目を配置し、その呼び出しを処理する方法はたくさんあります。</span><span class="sxs-lookup"><span data-stu-id="025b0-218">There are many ways to put items in the drop down and handle their invocation.</span></span> <span data-ttu-id="025b0-219">ListView または GridView を使用する場合、SelectionChanged イベントを処理する方法の 1 つことです。</span><span class="sxs-lookup"><span data-stu-id="025b0-219">If you use a ListView or GridView, one way is to handle the SelectionChanged event.</span></span> <span data-ttu-id="025b0-220">これを行う場合[SingleSelectionFollowsFocus](/uwp/api/windows.ui.xaml.controls.listviewbase.singleselectionfollowsfocus)を**false**に設定します。</span><span class="sxs-lookup"><span data-stu-id="025b0-220">If you do this, set [SingleSelectionFollowsFocus](/uwp/api/windows.ui.xaml.controls.listviewbase.singleselectionfollowsfocus) to **false**.</span></span> <span data-ttu-id="025b0-221">これにより、ユーザーが変更されるたびに、項目を呼び出さずにキーボードを使用してオプションを移動できます。</span><span class="sxs-lookup"><span data-stu-id="025b0-221">This lets users navigate the options using a keyboard without invoking the item on each change.</span></span>

### <a name="example---split-button"></a><span data-ttu-id="025b0-222">分割ボタンの使用例</span><span class="sxs-lookup"><span data-stu-id="025b0-222">Example - Split button</span></span>

<span data-ttu-id="025b0-223">この例では、RichEditBox で選択したテキストの前景色を変更するために使用する分割ボタンを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="025b0-223">This example shows how to create a split button that is used to change the foreground color of selected text in a RichEditBox.</span></span> <span data-ttu-id="025b0-224">(詳細とコードは、参照[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="025b0-224">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>

![前景色を選択するための分割ボタン](images/split-button-rtb.png)

```xaml
<SplitButton ToolTipService.ToolTip="Foreground color"
             Click="BrushButtonClick">
    <Border x:Name="SelectedColorBorder" Width="20" Height="20"/>
    <SplitButton.Flyout>
        <Flyout x:Name="BrushFlyout" Placement="BottomEdgeAlignedLeft">
            <!-- Set SingleSelectionFollowsFocus="False"
                 so that keyboard navigation works correctly. -->
            <GridView ItemsSource="{x:Bind ColorOptions}" 
                      SelectionChanged="BrushSelectionChanged"
                      SingleSelectionFollowsFocus="False"
                      SelectedIndex="0" Padding="0">
                <GridView.ItemTemplate>
                    <DataTemplate>
                        <Rectangle Fill="{Binding}" Width="20" Height="20"/>
                    </DataTemplate>
                </GridView.ItemTemplate>
                <GridView.ItemContainerStyle>
                    <Style TargetType="GridViewItem">
                        <Setter Property="Margin" Value="2"/>
                        <Setter Property="MinWidth" Value="0"/>
                        <Setter Property="MinHeight" Value="0"/>
                    </Style>
                </GridView.ItemContainerStyle>
            </GridView>
        </Flyout>
    </SplitButton.Flyout>
</SplitButton>
```

```csharp
public sealed partial class MainPage : Page
{
    // Color options that are bound to the grid in the split button flyout.
    private List<SolidColorBrush> ColorOptions = new List<SolidColorBrush>();
    private SolidColorBrush CurrentColorBrush = null;

    public MainPage()
    {
        this.InitializeComponent();

        // Add color brushes to the collection.
        ColorOptions.Add(new SolidColorBrush(Colors.Black));
        ColorOptions.Add(new SolidColorBrush(Colors.Red));
        ColorOptions.Add(new SolidColorBrush(Colors.Orange));
        ColorOptions.Add(new SolidColorBrush(Colors.Yellow));
        ColorOptions.Add(new SolidColorBrush(Colors.Green));
        ColorOptions.Add(new SolidColorBrush(Colors.Blue));
        ColorOptions.Add(new SolidColorBrush(Colors.Indigo));
        ColorOptions.Add(new SolidColorBrush(Colors.Violet));
        ColorOptions.Add(new SolidColorBrush(Colors.White));
    }

    private void BrushButtonClick(object sender, object e)
    {
        // When the button part of the split button is clicked,
        // apply the selected color.
        ChangeColor();
    }

    private void BrushSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // When the flyout part of the split button is opened and the user selects
        // an option, set their choice as the current color, apply it, then close the flyout.
        CurrentColorBrush = (SolidColorBrush)e.AddedItems[0];
        SelectedColorBorder.Background = CurrentColorBrush;
        ChangeColor();
        BrushFlyout.Hide();
    }

    private void ChangeColor()
    {
        // Apply the color to the selected text in a RichEditBox.
        Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
        if (selectedText != null)
        {
            Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
            charFormatting.ForegroundColor = CurrentColorBrush.Color;
            selectedText.CharacterFormat = charFormatting;
        }
    }
}
```

## <a name="create-a-toggle-split-button"></a><span data-ttu-id="025b0-226">分割トグル ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="025b0-226">Create a toggle split button</span></span>

> <span data-ttu-id="025b0-227">ToggleSplitButton には、Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) が必要ですか、後で、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。</span><span class="sxs-lookup"><span data-stu-id="025b0-227">ToggleSplitButton requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="025b0-228">[ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton)は、個別に呼び出すことができる 2 つの部分です。</span><span class="sxs-lookup"><span data-stu-id="025b0-228">A [ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton) has two parts that can be invoked separately.</span></span> <span data-ttu-id="025b0-229">1 つの部分は、オンまたはオフにできるトグル ボタンのように動作します。</span><span class="sxs-lookup"><span data-stu-id="025b0-229">One part behaves like a toggle button that can be on or off.</span></span> <span data-ttu-id="025b0-230">他の部分では、ユーザーが選択できる追加のオプションが含まれているポップアップを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="025b0-230">The other part invokes a flyout that contains additional options that the user can choose from.</span></span>

<span data-ttu-id="025b0-231">分割トグル ボタンは通常を有効にするまたは機能を無効にする機能、ユーザーが選択できる複数のオプションがあるときに使われます。</span><span class="sxs-lookup"><span data-stu-id="025b0-231">A toggle split button is typically used to enable or disable a feature when the feature has multiple options that the user can choose from.</span></span> <span data-ttu-id="025b0-232">たとえば、ドキュメントのエディターで、される可能性がありますを有効にしてリスト オンまたはオフ、ドロップダウン リストのスタイルの選択に使用します。</span><span class="sxs-lookup"><span data-stu-id="025b0-232">For example, in a document editor, it could be used to turn lists on or off, while the drop down is used to choose the style of the list.</span></span>

> [!NOTE]
> <span data-ttu-id="025b0-233">タッチで呼び出されると、分割ボタンはドロップダウン ボタンとして動作します。</span><span class="sxs-lookup"><span data-stu-id="025b0-233">When invoked with touch, the split button behaves as a drop down button.</span></span> <span data-ttu-id="025b0-234">入力の他の方法では、ユーザーが、ボタンのいずれかの半分を個別に呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="025b0-234">With other methods of input, a user can invoke either half of the button separately.</span></span> <span data-ttu-id="025b0-235">タッチでは、ボタンの両方の部分は、ポップアップを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="025b0-235">With touch, both halves of the button invoke the flyout.</span></span> <span data-ttu-id="025b0-236">そのため、ポップアップ コンテンツ] をオンまたはオフ切り替えのオプションを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="025b0-236">Therefore, you must include an option in your flyout content to toggle the button on or off.</span></span>

### <a name="differences-with-togglebutton"></a><span data-ttu-id="025b0-237">トグル ボタンとの違い</span><span class="sxs-lookup"><span data-stu-id="025b0-237">Differences with ToggleButton</span></span>

<span data-ttu-id="025b0-238">[トグル ボタン](/uwp/api/windows.ui.xaml.controls.primitives.togglebutton)とは異なり ToggleSplitButton は不確定の状態はありません。</span><span class="sxs-lookup"><span data-stu-id="025b0-238">Unlike [ToggleButton](/uwp/api/windows.ui.xaml.controls.primitives.togglebutton), ToggleSplitButton does not have an indeterminate state.</span></span> <span data-ttu-id="025b0-239">その結果、これらの違いを点に注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="025b0-239">As a result, you should keep in mind these differences:</span></span>

- <span data-ttu-id="025b0-240">ToggleSplitButton には、 **IsThreeState**プロパティまたは**中間状態**イベントはありません。</span><span class="sxs-lookup"><span data-stu-id="025b0-240">ToggleSplitButton does not have an **IsThreeState** property or **Indeterminate** event.</span></span>
- <span data-ttu-id="025b0-241">[ToggleSplitButton.IsChecked](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischecked)プロパティは、単**bool**、 **null 許容ブール値**ではありません。</span><span class="sxs-lookup"><span data-stu-id="025b0-241">The [ToggleSplitButton.IsChecked](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischecked) property is just a **bool**, not a **nullable bool**.</span></span>
- <span data-ttu-id="025b0-242">ToggleSplitButton が[IsCheckedChanged](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischeckedchanged)イベントのみです。独立した**Checked**イベントと**Unchecked**イベントはありません。</span><span class="sxs-lookup"><span data-stu-id="025b0-242">ToggleSplitButton has only the [IsCheckedChanged](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischeckedchanged) event; it does not have separate **Checked** and **Unchecked** events.</span></span>

### <a name="example---toggle-split-button"></a><span data-ttu-id="025b0-243">例 - トグル ボタンに分割</span><span class="sxs-lookup"><span data-stu-id="025b0-243">Example - Toggle split button</span></span>

<span data-ttu-id="025b0-244">次の例方法を示していますトグル ボタンを分割をオンまたはオフ、書式設定の一覧を有効にするために使用が RichEditBox で、リストのスタイルを変更します。</span><span class="sxs-lookup"><span data-stu-id="025b0-244">The following example shows how a toggle split button could be used to turn list formatting on or off, and change the style of the list, in a RichEditBox.</span></span> <span data-ttu-id="025b0-245">(詳細とコードは、参照[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="025b0-245">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>

![リストのスタイルを選択するためのトグル分割ボタン](images/toggle-split-button-open.png)

```xaml
<ToggleSplitButton x:Name="ListButton"
                   ToolTipService.ToolTip="List style"
                   Click="ListButton_Click"
                   IsCheckedChanged="ListStyleButton_IsCheckedChanged">
    <TextBlock FontFamily="Segoe MDL2 Assets" FontSize="16" Text="&#xE8FD;"/>
    <ToggleSplitButton.Flyout>
        <Flyout Placement="BottomEdgeAlignedLeft">
            <ListView x:Name="ListStylesListView"
                      SelectionChanged="ListStylesListView_SelectionChanged" 
                      SingleSelectionFollowsFocus="False">
                <StackPanel Tag="bullet" Orientation="Horizontal">
                    <FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xE7C8;"/>
                    <TextBlock Text="Bullet" Margin="8,0"/>
                </StackPanel>
                <StackPanel Tag="alpha" Orientation="Horizontal">
                    <TextBlock Text="A" FontSize="24" Margin="2,0"/>
                    <TextBlock Text="Alpha" Margin="8"/>
                </StackPanel>
                <StackPanel Tag="numeric" Orientation="Horizontal">
                    <FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xF146;"/>
                    <TextBlock Text="Numeric" Margin="8,0"/>
                </StackPanel>
                <TextBlock Tag="none" Text="None" Margin="28,0"/>
            </ListView>
        </Flyout>
    </ToggleSplitButton.Flyout>
</ToggleSplitButton>
```

```csharp
private void ListStyleButton_IsCheckedChanged(ToggleSplitButton sender, ToggleSplitButtonIsCheckedChangedEventArgs args)
{
    // Use the toggle button to turn the selected list style on or off.
    if (((ToggleSplitButton)sender).IsChecked == true)
    {
        // On. Apply the list style selected in the drop down to the selected text.
        var listStyle = ((FrameworkElement)(ListStylesListView.SelectedItem)).Tag.ToString();
        ApplyListStyle(listStyle);
    }
    else
    {
        // Off. Make the selected text not a list,
        // but don't change the list style selected in the drop down.
        ApplyListStyle("none");
    }
}

private void ListStylesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    var listStyle = ((FrameworkElement)(e.AddedItems[0])).Tag.ToString();

    if (ListButton.IsChecked == true)
    {
        // Toggle button is on. Turn it off...
        if (listStyle == "none")
        {
            ListButton.IsChecked = false;
        }
        else
        {
            // or apply the new selection.
            ApplyListStyle(listStyle);
        }
    }
    else
    {
        // Toggle button is off. Turn it on, which will apply the selection
        // in the IsCheckedChanged event handler.
        ListButton.IsChecked = true;
    }
}

private void ApplyListStyle(string listStyle)
{
    Windows.UI.Text.ITextSelection selectedText = editor.Document.Selection;
    if (selectedText != null)
    {
        // Apply the list style to the selected text.
        var paragraphFormatting = selectedText.ParagraphFormat;
        if (listStyle == "none")
        {  
            paragraphFormatting.ListType = Windows.UI.Text.MarkerType.None;
        }
        else if (listStyle == "bullet")
        {
            paragraphFormatting.ListType = Windows.UI.Text.MarkerType.Bullet;
        }
        else if (listStyle == "numeric")
        {
            paragraphFormatting.ListType = Windows.UI.Text.MarkerType.Arabic;
        }
        else if (listStyle == "alpha")
        {
            paragraphFormatting.ListType = Windows.UI.Text.MarkerType.UppercaseEnglishLetter;
        }
        selectedText.ParagraphFormat = paragraphFormatting;
    }
}
```

## <a name="recommendations"></a><span data-ttu-id="025b0-247">推奨事項</span><span class="sxs-lookup"><span data-stu-id="025b0-247">Recommendations</span></span>

- <span data-ttu-id="025b0-248">ボタンの用途と状態をユーザーがはっきりと理解できるようにします。</span><span class="sxs-lookup"><span data-stu-id="025b0-248">Make sure the purpose and state of a button are clear to the user.</span></span>
- <span data-ttu-id="025b0-249">同じ意思決定に対して複数のボタンが存在する場合 (確認のダイアログなど)、コミット ボタンは次の順番で提示します。この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。</span><span class="sxs-lookup"><span data-stu-id="025b0-249">When there are multiple buttons for the same decision (such as in a confirmation dialog), present the commit buttons in this order, where [Do it] and [Don't do it] are specific responses to the main instruction:</span></span>
    - <span data-ttu-id="025b0-250">[OK]/[実行する]/[はい]</span><span class="sxs-lookup"><span data-stu-id="025b0-250">OK/[Do it]/Yes</span></span>
    - <span data-ttu-id="025b0-251">[実行しない]/[いいえ]</span><span class="sxs-lookup"><span data-stu-id="025b0-251">[Don't do it]/No</span></span>
    - <span data-ttu-id="025b0-252">[キャンセル]</span><span class="sxs-lookup"><span data-stu-id="025b0-252">Cancel</span></span>
- <span data-ttu-id="025b0-253">ユーザーに対して表示するボタンは、1 つまたは 2 つにします (例: [承諾] と [キャンセル])。</span><span class="sxs-lookup"><span data-stu-id="025b0-253">Expose only one or two buttons to the user at a time, for example, Accept and Cancel.</span></span> <span data-ttu-id="025b0-254">3 つ以上の操作をユーザーに示す必要がある場合は、ユーザーが操作を選択できる [チェック ボックス](checkbox.md) または [オプション ボタン](radio-button.md) を、それらの操作を開始するための 1 つのコマンド ボタンと共に使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="025b0-254">If you need to expose more actions to the user, consider using [checkboxes](checkbox.md) or [radio buttons](radio-button.md) from which the user can select actions, with a single command button to trigger those actions.</span></span>
- <span data-ttu-id="025b0-255">ある操作をアプリの複数のページで実行できるようにするには、各ページでボタンを使うのではなく、[下部のアプリ バー](app-bars.md) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="025b0-255">For an action that needs to be available across multiple pages within your app, instead of duplicating a button on multiple pages, consider using a [bottom app bar](app-bars.md).</span></span>

### <a name="recommended-single-button-layout"></a><span data-ttu-id="025b0-256">単一のボタンの推奨レイアウト</span><span class="sxs-lookup"><span data-stu-id="025b0-256">Recommended single button layout</span></span>

<span data-ttu-id="025b0-257">ボタンを 1 つしか必要としないレイアウトでは、コンテナーのコンテキストに応じて、左揃えまたは右揃えにします。</span><span class="sxs-lookup"><span data-stu-id="025b0-257">If your layout requires only one button, it should be either left- or right-aligned based on its container context.</span></span>

- <span data-ttu-id="025b0-258">ボタンが 1 つだけのダイアログでは、ボタンを**右揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="025b0-258">Dialogs with only one button should **right-align** the button.</span></span> <span data-ttu-id="025b0-259">ダイアログにボタンが 1 つしかない場合は、ボタンによって安全で非破壊的な操作が実行されるようにします。</span><span class="sxs-lookup"><span data-stu-id="025b0-259">If your dialog contains only one button, ensure that the button performs the safe, nondestructive action.</span></span> <span data-ttu-id="025b0-260">[ContentDialog](dialogs.md) を使い、単一のボタンを指定する場合は、自動的に右揃えになります。</span><span class="sxs-lookup"><span data-stu-id="025b0-260">If you use [ContentDialog](dialogs.md) and specify a single button, it will automatically right-align.</span></span>

![ダイアログ内のボタン](images/pushbutton_doc_dialog.png)

- <span data-ttu-id="025b0-262">ボタンがコンテナー UI 内 (トースト通知、ポップアップ、またはリスト ビュー項目内など) に表示される場合は、コンテナー内でボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="025b0-262">If your button appears within a container UI (for example, within a toast notification, a flyout, or a list view item), you should **right-align** the button within the container.</span></span>

![コンテナー内のボタン](images/pushbutton_doc_container.png)

- <span data-ttu-id="025b0-264">ページに含まれるボタンが 1 つだけの場合は (設定ページの下部にある [適用] ボタンなど)、ボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="025b0-264">In pages that contain a single button (for example, an "Apply" button at the bottom of a settings page), you should **left-align** the button.</span></span> <span data-ttu-id="025b0-265">これで、ページのその他のコンテンツとボタンを揃えて配置できます。</span><span class="sxs-lookup"><span data-stu-id="025b0-265">This ensures that the button aligns with the rest of the page content.</span></span>

![ページのボタン](images/pushbutton_doc_page.png)

## <a name="back-buttons"></a><span data-ttu-id="025b0-267">戻るボタン</span><span class="sxs-lookup"><span data-stu-id="025b0-267">Back buttons</span></span>

<span data-ttu-id="025b0-268">戻るボタンは、バック スタックまたはユーザーのナビゲーション履歴を使って "戻る" ナビゲーションを実現する、システムの UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="025b0-268">The back button is a system-provided UI element that enables backward navigation through either the back stack or navigation history of the user.</span></span> <span data-ttu-id="025b0-269">独自の"戻る"ボタンを作成する必要はありませんが、前に戻る移動で適切なエクスペリエンスを提供するために作業が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="025b0-269">You don't have to create your own back button, but you might have to do some work to enable a good backwards navigation experience.</span></span> <span data-ttu-id="025b0-270">詳しくは、「[履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="025b0-270">For more info, see [History and backwards navigation](../basics/navigation-history-and-backwards-navigation.md)</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="025b0-271">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="025b0-271">Get the sample code</span></span>

- <span data-ttu-id="025b0-272">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="025b0-272">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="025b0-273">関連記事</span><span class="sxs-lookup"><span data-stu-id="025b0-273">Related articles</span></span>

- [<span data-ttu-id="025b0-274">Button クラス</span><span class="sxs-lookup"><span data-stu-id="025b0-274">Button class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)
- [<span data-ttu-id="025b0-275">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="025b0-275">Radio buttons</span></span>](radio-button.md)
- [<span data-ttu-id="025b0-276">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="025b0-276">Check boxes</span></span>](checkbox.md)
- [<span data-ttu-id="025b0-277">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="025b0-277">Toggle switches</span></span>](toggles.md)
