---
Description: ボタンは、特定の操作を直ちに実行する手段をユーザーに提供します。
title: ボタン
label: Buttons
template: detail.hbs
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
ms.assetid: f04d1a3c-7dcd-4bc8-9586-3396923b312e
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 286b278d0c41edfbc5c008f31e5a8e28fa30f93a
ms.sourcegitcommit: aeebfe35330aa471d22121957d9b510f6ebacbcf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/03/2019
ms.locfileid: "58901640"
---
# <a name="buttons"></a><span data-ttu-id="04b50-104">ボタン</span><span class="sxs-lookup"><span data-stu-id="04b50-104">Buttons</span></span>

<span data-ttu-id="04b50-105">ボタンは、特定の操作を直ちに実行する手段をユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="04b50-105">A button gives the user a way to trigger an immediate action.</span></span> <span data-ttu-id="04b50-106">いくつかのボタンはナビゲーション、繰り返しの操作メニューを表示するなど、特定のタスクに特化されています。</span><span class="sxs-lookup"><span data-stu-id="04b50-106">Some buttons are specialized for particular tasks, such as navigation, repeated actions, or presenting menus.</span></span>

![ボタンの例](images/controls/button.png)

<span data-ttu-id="04b50-108">XAML フレームワークでは、いくつかの特殊なボタン コントロールと同様に、標準のボタン コントロールを提供します。</span><span class="sxs-lookup"><span data-stu-id="04b50-108">The XAML framework provides a standard button control as well as several specialized button controls.</span></span>

<span data-ttu-id="04b50-109">コントロール</span><span class="sxs-lookup"><span data-stu-id="04b50-109">Control</span></span> | <span data-ttu-id="04b50-110">説明</span><span class="sxs-lookup"><span data-stu-id="04b50-110">Description</span></span>
------- | -----------
[<span data-ttu-id="04b50-111">Button</span><span class="sxs-lookup"><span data-stu-id="04b50-111">Button</span></span>](/uwp/api/windows.ui.xaml.controls.button) | <span data-ttu-id="04b50-112">即時のアクションを開始します。</span><span class="sxs-lookup"><span data-stu-id="04b50-112">Initiates an immediate action.</span></span> <span data-ttu-id="04b50-113">コマンド バインディングまたは Click イベントと共に使用することができます。</span><span class="sxs-lookup"><span data-stu-id="04b50-113">Can be used with a Click event or Command binding.</span></span>
[<span data-ttu-id="04b50-114">RepeatButton</span><span class="sxs-lookup"><span data-stu-id="04b50-114">RepeatButton</span></span>](/uwp/api/windows.ui.xaml.controls.primitives.repeatbutton) | <span data-ttu-id="04b50-115">押されたときに継続的には、クリック イベントを発生させるボタン。</span><span class="sxs-lookup"><span data-stu-id="04b50-115">A button that raises a Click event continuously while pressed.</span></span>
[<span data-ttu-id="04b50-116">HyperlinkButton</span><span class="sxs-lookup"><span data-stu-id="04b50-116">HyperlinkButton</span></span>](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton) | <span data-ttu-id="04b50-117">A ボタンをハイパーリンクのナビゲーションのために使用されるようにスタイルが適用されます。</span><span class="sxs-lookup"><span data-stu-id="04b50-117">A button that's styled like a hyperlink, used for navigation.</span></span> <span data-ttu-id="04b50-118">詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04b50-118">See [Hyperlinks](hyperlinks.md) for more info.</span></span>
[<span data-ttu-id="04b50-119">DropDownButton</span><span class="sxs-lookup"><span data-stu-id="04b50-119">DropDownButton</span></span>](/uwp/api/windows.ui.xaml.controls.dropdownbutton) | <span data-ttu-id="04b50-120">開く、アタッチされたフライアウトのシェブロン ボタン。</span><span class="sxs-lookup"><span data-stu-id="04b50-120">A button with a chevron to open an attached flyout.</span></span>
[<span data-ttu-id="04b50-121">分割ボタン</span><span class="sxs-lookup"><span data-stu-id="04b50-121">SplitButton</span></span>](/uwp/api/windows.ui.xaml.controls.splitbutton) | <span data-ttu-id="04b50-122">2 つの辺のボタンです。</span><span class="sxs-lookup"><span data-stu-id="04b50-122">A button with two sides.</span></span> <span data-ttu-id="04b50-123">一方の側の操作を開始して、もう一方の側には、メニューが開かれます。</span><span class="sxs-lookup"><span data-stu-id="04b50-123">One side initiates an action, and the other side opens a menu.</span></span>
[<span data-ttu-id="04b50-124">ToggleSplitButton</span><span class="sxs-lookup"><span data-stu-id="04b50-124">ToggleSplitButton</span></span>](/uwp/api/windows.ui.xaml.controls.togglesplitbutton) | <span data-ttu-id="04b50-125">2 つの辺をトグル ボタン。</span><span class="sxs-lookup"><span data-stu-id="04b50-125">A toggle button with two sides.</span></span> <span data-ttu-id="04b50-126">一方の側をオン/オフを切り替えるし、もう一方の側には、メニューが開かれます。</span><span class="sxs-lookup"><span data-stu-id="04b50-126">One side toggles on/off, and the other side opens a menu.</span></span>

| **<span data-ttu-id="04b50-127">Windows UI ライブラリを入手する</span><span class="sxs-lookup"><span data-stu-id="04b50-127">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="04b50-128">DropDownButton、分割ボタン、および ToggleSplitButton は Windows の UI ライブラリ、新しいコントロール、および UWP アプリの UI 機能を含む NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="04b50-128">DropDownButton, SplitButton, and ToggleSplitButton are included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="04b50-129">インストール手順を含む詳細については、次を参照してください。、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="04b50-129">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

| **<span data-ttu-id="04b50-130">プラットフォームの Api</span><span class="sxs-lookup"><span data-stu-id="04b50-130">Platform APIs</span></span>** | **<span data-ttu-id="04b50-131">Windows UI ライブラリの Api</span><span class="sxs-lookup"><span data-stu-id="04b50-131">Windows UI Library APIs</span></span>** |
| - | - |
| <span data-ttu-id="04b50-132">[クリックしてイベント](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)、 [Command プロパティ](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.command)</span><span class="sxs-lookup"><span data-stu-id="04b50-132">[Click event](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click), [Command property](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.command)</span></span> | <span data-ttu-id="04b50-133">[DropDownButton クラス](/uwp/api/microsoft.ui.xaml.controls.dropdownbutton)、 [SplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.splitbutton)、 [ToggleSplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.togglesplitbutton)</span><span class="sxs-lookup"><span data-stu-id="04b50-133">[DropDownButton class](/uwp/api/microsoft.ui.xaml.controls.dropdownbutton), [SplitButton class](/uwp/api/microsoft.ui.xaml.controls.splitbutton), [ToggleSplitButton class](/uwp/api/microsoft.ui.xaml.controls.togglesplitbutton)</span></span> |

## <a name="is-this-the-right-control"></a><span data-ttu-id="04b50-134">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="04b50-134">Is this the right control?</span></span>

<span data-ttu-id="04b50-135">使用して、**ボタン**ユーザー フォームを送信するなどの即時アクションを開始するようにします。</span><span class="sxs-lookup"><span data-stu-id="04b50-135">Use a **Button** to let the user initiate an immediate action, such as submitting a form.</span></span>

<span data-ttu-id="04b50-136">アクションが別のページに移動する場合、ボタンを使用しないでください。使用して、 [HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton)代わりにします。</span><span class="sxs-lookup"><span data-stu-id="04b50-136">Don't use a button when the action is to navigate to another page; use a [HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton) instead.</span></span> <span data-ttu-id="04b50-137">詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04b50-137">See [Hyperlinks](hyperlinks.md) for more info.</span></span>
> <span data-ttu-id="04b50-138">例外:ウィザードのナビゲーションのためには、「バックアップ」というラベルのボタンと [次へ] を使用します。</span><span class="sxs-lookup"><span data-stu-id="04b50-138">Exception: For wizard navigation, use buttons labeled "Back" and "Next".</span></span> <span data-ttu-id="04b50-139">他の種類の下位または上位レベル、使用するナビゲーション、 [[戻る] ボタン](../basics/navigation-history-and-backwards-navigation.md)。</span><span class="sxs-lookup"><span data-stu-id="04b50-139">For other types of backwards navigation or navigation to an upper level, use a [back button](../basics/navigation-history-and-backwards-navigation.md).</span></span>

<span data-ttu-id="04b50-140">使用して、 **RepeatButton**ユーザーが繰り返しアクションをトリガーする可能性があります。</span><span class="sxs-lookup"><span data-stu-id="04b50-140">Use a **RepeatButton** when the user might want to trigger an action repeatedly.</span></span> <span data-ttu-id="04b50-141">たとえば、カウンターの値を増減させる、RepeatButton を使用します。</span><span class="sxs-lookup"><span data-stu-id="04b50-141">For example, use a RepeatButton to increment or decrement a value in a counter.</span></span>

<span data-ttu-id="04b50-142">使用して、 **DropDownButton**ボタンがより多くのオプションを含むフライアウトを持っている場合。</span><span class="sxs-lookup"><span data-stu-id="04b50-142">Use a **DropDownButton** when the button has a flyout that contains more options.</span></span> <span data-ttu-id="04b50-143">既定のシェブロン ボタンには、フライアウトが含まれているかが表示を提供します。</span><span class="sxs-lookup"><span data-stu-id="04b50-143">The default chevron provides a visual indication that the button includes a flyout.</span></span>

<span data-ttu-id="04b50-144">使用して、 **SplitButton**する操作が直ちに開始またはいません追加のオプションからを個別に選択できるように、ユーザーの場合します。</span><span class="sxs-lookup"><span data-stu-id="04b50-144">Use a **SplitButton** when you want the user to be able to initiate an immediate action or choose from additional options independently.</span></span>

## <a name="examples"></a><span data-ttu-id="04b50-145">例</span><span class="sxs-lookup"><span data-stu-id="04b50-145">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="04b50-146">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="04b50-146">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="04b50-147"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Button">アプリを開き、Button の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="04b50-147">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Button">open the app and see the Button in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="04b50-148">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="04b50-148">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery"><span data-ttu-id="04b50-149">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="04b50-149">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="04b50-150">この例では、一情報へのアクセスを求めるダイアログ ボックスで、2 つのボタン ([Allow] (許可) と [Block] (禁止)) を使っています。</span><span class="sxs-lookup"><span data-stu-id="04b50-150">This example uses two buttons, Allow and Block, in a dialog requesting location access.</span></span>

![ダイアログで使われるボタンの例](images/dialogs/dialog_RS2_two_button.png)

## <a name="create-a-button"></a><span data-ttu-id="04b50-152">ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="04b50-152">Create a button</span></span>

<span data-ttu-id="04b50-153">クリックに応答するボタンの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="04b50-153">This example shows a button that responds to a click.</span></span>

<span data-ttu-id="04b50-154">XAML でボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="04b50-154">Create the button in XAML.</span></span>

```xaml
<Button Content="Subscribe" Click="SubscribeButton_Click"/>
```

<span data-ttu-id="04b50-155">または、コードでボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="04b50-155">Or create the button in code.</span></span>

```csharp
Button subscribeButton = new Button();
subscribeButton.Content = "Subscribe";
subscribeButton.Click += SubscribeButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(subscribeButton);
```

<span data-ttu-id="04b50-156">Click イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="04b50-156">Handle the Click event.</span></span>

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

### <a name="button-interaction"></a><span data-ttu-id="04b50-157">ボタンの対話式操作</span><span class="sxs-lookup"><span data-stu-id="04b50-157">Button interaction</span></span>

<span data-ttu-id="04b50-158">ポインターがボタンの上にあるときに、指やスタイラスでそのボタンをタップするか、マウスの左ボタンを押すと、ボタンでは [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="04b50-158">When you tap a Button with a finger or stylus, or press a left mouse button while the pointer is over it, the button raises the [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) event.</span></span> <span data-ttu-id="04b50-159">ボタンにキーボード フォーカスがある場合は、Enter キーまたは Space キーを押しても、Click イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="04b50-159">If a button has keyboard focus, pressing the Enter key or the Spacebar key also raises the Click event.</span></span>

<span data-ttu-id="04b50-160">通常、ボタンでは低レベルな [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントを処理できません。これに代わる Click 動作があるためです。</span><span class="sxs-lookup"><span data-stu-id="04b50-160">You generally can't handle low-level [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) events on a Button because it has the Click behavior instead.</span></span> <span data-ttu-id="04b50-161">詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04b50-161">For more info, see [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx).</span></span>

<span data-ttu-id="04b50-162">ボタンで Click イベントが発生する方法を変えるには、[ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="04b50-162">You can change how a button raises the Click event by changing the [ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) property.</span></span> <span data-ttu-id="04b50-163">ClickMode の既定値は **Release** ですが、ボタンの ClickMode を **Hover** または **Press** に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="04b50-163">The default ClickMode value is **Release**, but you also can set a button's ClickMode to **Hover** or **Press**.</span></span> <span data-ttu-id="04b50-164">ClickMode が **Hover** の場合、キーボード操作やタッチ操作によって Click イベントを発生させることはできません。</span><span class="sxs-lookup"><span data-stu-id="04b50-164">If ClickMode is **Hover**, the Click event can't be raised with the keyboard or touch.</span></span>


### <a name="button-content"></a><span data-ttu-id="04b50-165">ボタンのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="04b50-165">Button content</span></span>

<span data-ttu-id="04b50-166">ボタンは [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx) です。</span><span class="sxs-lookup"><span data-stu-id="04b50-166">Button is a [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx).</span></span> <span data-ttu-id="04b50-167">その XAML コンテンツ プロパティは [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) であり、`<Button>A button's content</Button>` のような XAML 構文を使用できます。</span><span class="sxs-lookup"><span data-stu-id="04b50-167">Its XAML content property is [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx), which enables a syntax like this for XAML: `<Button>A button's content</Button>`.</span></span> <span data-ttu-id="04b50-168">任意のオブジェクトをボタンのコンテンツとして設定できます。</span><span class="sxs-lookup"><span data-stu-id="04b50-168">You can set any object as the button's content.</span></span> <span data-ttu-id="04b50-169">コンテンツが [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) の場合、ボタンにレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="04b50-169">If the content is a [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx), it is rendered in the button.</span></span> <span data-ttu-id="04b50-170">コンテンツが別のタイプのオブジェクトの場合、その文字列表現がボタンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="04b50-170">If the content is another type of object, its string representation is shown in the button.</span></span>

<span data-ttu-id="04b50-171">ボタンのコンテンツは、通常はテキストです。</span><span class="sxs-lookup"><span data-stu-id="04b50-171">A button's content is usually text.</span></span> <span data-ttu-id="04b50-172">テキスト コンテンツの付いたボタンの設計に関する推奨事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="04b50-172">Here are design recommendations for buttons with text content:</span></span>
-   <span data-ttu-id="04b50-173">ボタンによって行われる操作を明確に説明する、簡潔で具体的でわかりやすいテキストを使います。</span><span class="sxs-lookup"><span data-stu-id="04b50-173">Use a concise, specific, self-explanatory text that clearly describes the action that the button performs.</span></span> <span data-ttu-id="04b50-174">通常、ボタンのテキスト コンテンツは、1 語の動詞です。</span><span class="sxs-lookup"><span data-stu-id="04b50-174">Usually button text content is a single word, a verb.</span></span>
-   <span data-ttu-id="04b50-175">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="04b50-175">Use the default font unless your brand guidelines tell you to use something different.</span></span>
-   <span data-ttu-id="04b50-176">短いテキストでは、120px の最小ボタン幅を使用し、幅が狭いコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="04b50-176">For shorter text, avoid narrow command buttons by using a minimum button width of 120px.</span></span>
- <span data-ttu-id="04b50-177">長いテキストでは、テキストを最大文字数 26 文字に制限し、さまざまなコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="04b50-177">For longer text, avoid wide command buttons by limiting text to a maximum length of 26 characters.</span></span>
-   <span data-ttu-id="04b50-178">ボタンのテキスト コンテンツが動的な場合 ([ローカライズされる](../globalizing/globalizing-portal.md) 場合など) は、ボタンのサイズがどのように変化し、その周囲のコントロールに何が起こるかを考えます。</span><span class="sxs-lookup"><span data-stu-id="04b50-178">If the button's text content is dynamic (i.e., it is [localized](../globalizing/globalizing-portal.md)), consider how the button will resize and what will happen to controls around it.</span></span>

<table>
<tr>
<td> <b><span data-ttu-id="04b50-179">必要な修正:</span><span class="sxs-lookup"><span data-stu-id="04b50-179">Need to fix:</span></span></b><br> <span data-ttu-id="04b50-180">オーバーフロー テキストの付いたボタン。</span><span class="sxs-lookup"><span data-stu-id="04b50-180">Buttons with overflowing text.</span></span> </td>
<td> <img src="images/button-wraptext.png"/> </td>
</tr>
<tr>
<td> <b><span data-ttu-id="04b50-181">オプション 1:</span><span class="sxs-lookup"><span data-stu-id="04b50-181">Option 1:</span></span></b><br> <span data-ttu-id="04b50-182">テキストの長さが 26 文字より大きい場合は、ボタンの幅やスタック ボタンを増やし、テキストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="04b50-182">Increase button width, stack buttons, and wrap if text length is greater than 26 characters.</span></span> </td>
<td> <img src="images/button-wraptext1.png"> </td>
</tr>
<tr>
<td> <b><span data-ttu-id="04b50-183">オプション 2:</span><span class="sxs-lookup"><span data-stu-id="04b50-183">Option 2:</span></span></b><br> <span data-ttu-id="04b50-184">ボタンの高さを増やし、テキストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="04b50-184">Increase button height, and wrap text.</span></span> </td>
<td> <img src="images/button-wraptext2.png"> </td>
</tr>
</table>

<span data-ttu-id="04b50-185">ボタンの外観を構成する視覚効果をカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="04b50-185">You can also customize visuals that make up the button's appearance.</span></span> <span data-ttu-id="04b50-186">たとえば、テキストをアイコンに置き換えたり、アイコンとテキストを使用したりできます。</span><span class="sxs-lookup"><span data-stu-id="04b50-186">For example, you could replace the text with an icon, or use an icon plus text.</span></span>

<span data-ttu-id="04b50-187">ここでは、画像とテキストを含む **StackPanel** がボタンのコンテンツとして設定されます。</span><span class="sxs-lookup"><span data-stu-id="04b50-187">Here, a **StackPanel** that contains an image and text is set as the content of a button.</span></span>

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

<span data-ttu-id="04b50-188">ボタンは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="04b50-188">The button looks like this.</span></span>

![画像とテキスト コンテンツがあるボタン](images/button-orange.png)

## <a name="create-a-repeat-button"></a><span data-ttu-id="04b50-190">繰り返しボタンの作成</span><span class="sxs-lookup"><span data-stu-id="04b50-190">Create a repeat button</span></span>

<span data-ttu-id="04b50-191">[RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) は、ボタンが押されてから離されるまで、繰り返し [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントを発生させるボタンです。</span><span class="sxs-lookup"><span data-stu-id="04b50-191">A [RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) is a button that raises [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) events repeatedly from the time it's pressed until it's released.</span></span> <span data-ttu-id="04b50-192">ボタンが押されてからクリック操作の繰り返しを始めるまでの RepeatButton の待ち時間を指定するには、[Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="04b50-192">Set the [Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) property to specify the time that the RepeatButton waits after it is pressed before it starts repeating the click action.</span></span> <span data-ttu-id="04b50-193">クリック操作の繰り返し間隔を指定するには、[Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="04b50-193">Set the [Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) property to specify the time between repetitions of the click action.</span></span> <span data-ttu-id="04b50-194">これらのプロパティの時間はどちらもミリ秒単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="04b50-194">Times for both properties are specified in milliseconds.</span></span>

<span data-ttu-id="04b50-195">次の例は 2 つの RepeatButton コントロールを示しています。それぞれの Click イベントを使って、テキスト ブロックに表示される値を増減します。</span><span class="sxs-lookup"><span data-stu-id="04b50-195">The following example shows two RepeatButton controls whose respective Click events are used to increase and decrease the value shown in a text block.</span></span>

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

## <a name="create-a-drop-down-button"></a><span data-ttu-id="04b50-196">ドロップダウン ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="04b50-196">Create a drop down button</span></span>

> <span data-ttu-id="04b50-197">DropDownButton には、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="04b50-197">DropDownButton requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="04b50-198">A [DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton)はより多くのオプションを含む、アタッチされたフライアウトがある視覚的なインジケーターとしてのシェブロンを表示するボタン。</span><span class="sxs-lookup"><span data-stu-id="04b50-198">A [DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton) is a button that shows a chevron as a visual indicator that it has an attached flyout that contains more options.</span></span> <span data-ttu-id="04b50-199">フライアウト; での標準ボタンと同じ動作があります。外観だけが異なります。</span><span class="sxs-lookup"><span data-stu-id="04b50-199">It has the same behavior as a standard Button with a flyout; only the appearance is different.</span></span>

<span data-ttu-id="04b50-200">ドロップダウン ボタンは、Click イベントを継承しますが、通常、これを使用しません。</span><span class="sxs-lookup"><span data-stu-id="04b50-200">The drop down button inherits the Click event, but you typically don't use it.</span></span> <span data-ttu-id="04b50-201">代わりに、フライアウト プロパティを使用して、フライアウトをアタッチし、フライアウトでメニュー オプションを使用してアクションを起動します。</span><span class="sxs-lookup"><span data-stu-id="04b50-201">Instead, you use the Flyout property to attach a flyout and invoke actions using menu options in the flyout.</span></span> <span data-ttu-id="04b50-202">フライアウトは、ボタンがクリックされたときに自動的に開きます。</span><span class="sxs-lookup"><span data-stu-id="04b50-202">The flyout opens automatically when the button is clicked.</span></span> <span data-ttu-id="04b50-203">必ず指定して、[配置](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.placement)フライアウト ボタンに対する目的の配置のプロパティ。</span><span class="sxs-lookup"><span data-stu-id="04b50-203">Be sure to specify the [Placement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.placement) property of your flyout to ensure the desired placement in relation to the button.</span></span> <span data-ttu-id="04b50-204">既定の配置アルゴリズムは、すべての状況で目的の配置を生成しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="04b50-204">The default placement algorithm might not produce the intended placement in all situations.</span></span>

> [!TIP]
> <span data-ttu-id="04b50-205">フライアウトの詳細については、次を参照してください。[メニューおよびコンテキスト メニュー](menus.md)します。</span><span class="sxs-lookup"><span data-stu-id="04b50-205">For more info about flyouts, see [Menus and context menus](menus.md).</span></span>

### <a name="example---drop-down-button"></a><span data-ttu-id="04b50-206">例 - ドロップダウン ボタン</span><span class="sxs-lookup"><span data-stu-id="04b50-206">Example - Drop down button</span></span>

<span data-ttu-id="04b50-207">この例では、コマンド、RichEditBox で段落の配置を含むポップアップ付きのドロップダウン ボタンを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="04b50-207">This example shows how to create a drop down button with a flyout that contains commands for paragraph alignment in a RichEditBox.</span></span> <span data-ttu-id="04b50-208">(詳細な情報とコードについては、次を参照してください。[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="04b50-208">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>

![ドロップダウン ボタンの配置コマンドを使用](images/drop-down-button-align.png)

```xaml
<DropDownButton ToolTipService.ToolTip="Alignment">
    <TextBlock FontFamily="Segoe MDL2 Assets" FontSize="14" Text="&#xE8E4;"/>
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

## <a name="create-a-split-button"></a><span data-ttu-id="04b50-210">分割ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="04b50-210">Create a split button</span></span>

> <span data-ttu-id="04b50-211">分割ボタンには、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="04b50-211">SplitButton requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="04b50-212">A [SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton)は個別に呼び出すことができる 2 つの部分があります。</span><span class="sxs-lookup"><span data-stu-id="04b50-212">A [SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton) has two parts that can be invoked separately.</span></span> <span data-ttu-id="04b50-213">1 つの部分では、標準のボタンのように動作し、即時のアクションを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="04b50-213">One part behaves like a standard button and invokes an immediate action.</span></span> <span data-ttu-id="04b50-214">他の部分では、ユーザーが選択できる追加のオプションを含むフライアウトを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="04b50-214">The other part invokes a flyout that contains additional options that the user can choose from.</span></span>

> [!NOTE]
> <span data-ttu-id="04b50-215">タッチで呼び出されると、分割ボタンのドロップダウン ボタンとして動作します。ボタンの両方の部分では、フライアウトを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="04b50-215">When invoked with touch, the split button behaves as a drop down button; both halves of the button invoke the flyout.</span></span> <span data-ttu-id="04b50-216">入力の他の方法で、ユーザーは個別にボタンのいずれかの半分を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="04b50-216">With other methods of input, a user can invoke either half of the button separately.</span></span>

<span data-ttu-id="04b50-217">分割ボタンの一般的な動作は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="04b50-217">The typical behavior for a split button is:</span></span>

- <span data-ttu-id="04b50-218">ユーザーには、ボタンの一部がクリックするは、ドロップダウンで現在選択されているオプションを呼び出すための Click イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="04b50-218">When the user clicks the button part, handle the Click event to invoke the option that's currently selected in the drop down.</span></span>
- <span data-ttu-id="04b50-219">ドロップダウンが開いているとき、オプションが両方の変更ドロップダウン内の項目のハンドルの呼び出しが選択されているし、それを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="04b50-219">When the drop down is open, handle invocation of the items in the drop down to both change which option is selected, and then invoke it.</span></span> <span data-ttu-id="04b50-220">ために、フライアウトの項目を呼び出すことが重要ボタンの Click イベントがタッチを使用する場合に発生しません。</span><span class="sxs-lookup"><span data-stu-id="04b50-220">It's important to invoke the flyout item because the button Click event doesn't occur when using touch.</span></span>

> [!TIP]
> <span data-ttu-id="04b50-221">ドロップダウンの項目を配置して、その呼び出しを処理する多くの方法はあります。</span><span class="sxs-lookup"><span data-stu-id="04b50-221">There are many ways to put items in the drop down and handle their invocation.</span></span> <span data-ttu-id="04b50-222">ListView、GridView を使用する場合、1 つの方法は、SelectionChanged イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="04b50-222">If you use a ListView or GridView, one way is to handle the SelectionChanged event.</span></span> <span data-ttu-id="04b50-223">これを行う場合は、設定[SingleSelectionFollowsFocus](/uwp/api/windows.ui.xaml.controls.listviewbase.singleselectionfollowsfocus)に**false**します。</span><span class="sxs-lookup"><span data-stu-id="04b50-223">If you do this, set [SingleSelectionFollowsFocus](/uwp/api/windows.ui.xaml.controls.listviewbase.singleselectionfollowsfocus) to **false**.</span></span> <span data-ttu-id="04b50-224">これにより、ユーザーがキーボードを使用して、各変更上のアイテムを呼び出すことがなくオプション間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="04b50-224">This lets users navigate the options using a keyboard without invoking the item on each change.</span></span>

### <a name="example---split-button"></a><span data-ttu-id="04b50-225">例 - の分割ボタン</span><span class="sxs-lookup"><span data-stu-id="04b50-225">Example - Split button</span></span>

<span data-ttu-id="04b50-226">この例を RichEditBox で選択したテキストの前景色を変更するために使用する分割ボタンを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="04b50-226">This example shows how to create a split button that is used to change the foreground color of selected text in a RichEditBox.</span></span> <span data-ttu-id="04b50-227">(詳細な情報とコードについては、次を参照してください。[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="04b50-227">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>
<span data-ttu-id="04b50-228">分割ボタンのフライアウトは[BottomEdgeAlignedLeft](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutplacementmode)の既定値としてその[配置](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.placement)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="04b50-228">Split button's flyout uses [BottomEdgeAlignedLeft](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutplacementmode) as the default value for its [Placement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.placement) property.</span></span> <span data-ttu-id="04b50-229">この値を上書きすることはできません。</span><span class="sxs-lookup"><span data-stu-id="04b50-229">You can't override this value.</span></span>

![前景色を選択するための分割ボタン](images/split-button-rtb.png)

```xaml
<SplitButton ToolTipService.ToolTip="Foreground color"
             Click="BrushButtonClick">
    <Border x:Name="SelectedColorBorder" Width="20" Height="20"/>
    <SplitButton.Flyout>
        <Flyout x:Name="BrushFlyout">
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

## <a name="create-a-toggle-split-button"></a><span data-ttu-id="04b50-231">切り替えの分割ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="04b50-231">Create a toggle split button</span></span>

> <span data-ttu-id="04b50-232">ToggleSplitButton には、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="04b50-232">ToggleSplitButton requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="04b50-233">A [ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton)は個別に呼び出すことができる 2 つの部分があります。</span><span class="sxs-lookup"><span data-stu-id="04b50-233">A [ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton) has two parts that can be invoked separately.</span></span> <span data-ttu-id="04b50-234">1 つの部分は、トグル ボタンをオンまたはオフにできるように動作します。</span><span class="sxs-lookup"><span data-stu-id="04b50-234">One part behaves like a toggle button that can be on or off.</span></span> <span data-ttu-id="04b50-235">他の部分では、ユーザーが選択できる追加のオプションを含むフライアウトを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="04b50-235">The other part invokes a flyout that contains additional options that the user can choose from.</span></span>

<span data-ttu-id="04b50-236">切り替えの分割ボタンを有効または機能を無効にする機能、ユーザーが選択できる複数のオプションがあるときに通常使用されます。</span><span class="sxs-lookup"><span data-stu-id="04b50-236">A toggle split button is typically used to enable or disable a feature when the feature has multiple options that the user can choose from.</span></span> <span data-ttu-id="04b50-237">たとえば、ドキュメント エディターでそのされる可能性がありますリスト オン/オフ、ドロップダウンを使用して、リストのスタイルを選択します。</span><span class="sxs-lookup"><span data-stu-id="04b50-237">For example, in a document editor, it could be used to turn lists on or off, while the drop down is used to choose the style of the list.</span></span>

> [!NOTE]
> <span data-ttu-id="04b50-238">タッチで呼び出されると、切り替えの分割ボタンは、ドロップダウン ボタンとして動作します。</span><span class="sxs-lookup"><span data-stu-id="04b50-238">When invoked with touch, the toggle split button behaves as a drop down button.</span></span> <span data-ttu-id="04b50-239">入力の他の方法では、ユーザーは切り替えるし、ボタンの 2 つの要素を個別に呼び出します。</span><span class="sxs-lookup"><span data-stu-id="04b50-239">With other methods of input, a user can toggle and invoke the two halves of the button separately.</span></span> <span data-ttu-id="04b50-240">タッチ操作では、ボタンの両方の部分は、フライアウトを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="04b50-240">With touch, both halves of the button invoke the flyout.</span></span> <span data-ttu-id="04b50-241">そのため、 をオン/オフ切り替え、フライアウトのコンテンツ オプションを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="04b50-241">Therefore, you must include an option in your flyout content to toggle the button on or off.</span></span>

### <a name="differences-with-togglebutton"></a><span data-ttu-id="04b50-242">トグル ボタンとの違い</span><span class="sxs-lookup"><span data-stu-id="04b50-242">Differences with ToggleButton</span></span>

<span data-ttu-id="04b50-243">異なり[ToggleButton](/uwp/api/windows.ui.xaml.controls.primitives.togglebutton)ToggleSplitButton には、中間の状態はありません。</span><span class="sxs-lookup"><span data-stu-id="04b50-243">Unlike [ToggleButton](/uwp/api/windows.ui.xaml.controls.primitives.togglebutton), ToggleSplitButton does not have an indeterminate state.</span></span> <span data-ttu-id="04b50-244">その結果、おく必要がありますに注意してくださいでこれらの違い。</span><span class="sxs-lookup"><span data-stu-id="04b50-244">As a result, you should keep in mind these differences:</span></span>

- <span data-ttu-id="04b50-245">ToggleSplitButton はありません、 **IsThreeState**プロパティまたは**不定**イベント。</span><span class="sxs-lookup"><span data-stu-id="04b50-245">ToggleSplitButton does not have an **IsThreeState** property or **Indeterminate** event.</span></span>
- <span data-ttu-id="04b50-246">[ToggleSplitButton.IsChecked](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischecked)プロパティは、 **bool**ではなく、 **null 許容のブール値**します。</span><span class="sxs-lookup"><span data-stu-id="04b50-246">The [ToggleSplitButton.IsChecked](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischecked) property is just a **bool**, not a **nullable bool**.</span></span>
- <span data-ttu-id="04b50-247">ToggleSplitButton のみを持つ、 [IsCheckedChanged](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischeckedchanged)イベントです。 独立したことはありません**Checked**と**未チェック**イベント。</span><span class="sxs-lookup"><span data-stu-id="04b50-247">ToggleSplitButton has only the [IsCheckedChanged](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischeckedchanged) event; it does not have separate **Checked** and **Unchecked** events.</span></span>

### <a name="example---toggle-split-button"></a><span data-ttu-id="04b50-248">例 - 切り替えの分割ボタン</span><span class="sxs-lookup"><span data-stu-id="04b50-248">Example - Toggle split button</span></span>

<span data-ttu-id="04b50-249">次の例では、分割ボタン、トグルのリストをオンまたはオフ、書式設定を有効にされる可能性があり、リスト、RichEditBox のスタイルの変更を示します。</span><span class="sxs-lookup"><span data-stu-id="04b50-249">The following example shows how a toggle split button could be used to turn list formatting on or off, and change the style of the list, in a RichEditBox.</span></span> <span data-ttu-id="04b50-250">(詳細な情報とコードについては、次を参照してください。[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="04b50-250">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>
<span data-ttu-id="04b50-251">切り替えの分割ボタンのフライアウトは[BottomEdgeAlignedLeft](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutplacementmode)の既定値としてその[配置](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.placement)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="04b50-251">Toggle split button's flyout uses [BottomEdgeAlignedLeft](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutplacementmode) as the default value for its [Placement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.placement) property.</span></span> <span data-ttu-id="04b50-252">この値を上書きすることはできません。</span><span class="sxs-lookup"><span data-stu-id="04b50-252">You can't override this value.</span></span>

![リストのスタイルを選択するための切り替えの分割ボタン](images/toggle-split-button-open.png)

```xaml
<ToggleSplitButton x:Name="ListButton"
                   ToolTipService.ToolTip="List style"
                   Click="ListButton_Click"
                   IsCheckedChanged="ListStyleButton_IsCheckedChanged">
    <TextBlock FontFamily="Segoe MDL2 Assets" FontSize="14" Text="&#xE8FD;"/>
    <ToggleSplitButton.Flyout>
        <Flyout>
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

## <a name="recommendations"></a><span data-ttu-id="04b50-254">推奨事項</span><span class="sxs-lookup"><span data-stu-id="04b50-254">Recommendations</span></span>

- <span data-ttu-id="04b50-255">ボタンの用途と状態をユーザーがはっきりと理解できるようにします。</span><span class="sxs-lookup"><span data-stu-id="04b50-255">Make sure the purpose and state of a button are clear to the user.</span></span>
- <span data-ttu-id="04b50-256">同じ意思決定に対して複数のボタンが存在する場合 (確認のダイアログなど)、コミット ボタンは次の順番で提示します。この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。</span><span class="sxs-lookup"><span data-stu-id="04b50-256">When there are multiple buttons for the same decision (such as in a confirmation dialog), present the commit buttons in this order, where [Do it] and [Don't do it] are specific responses to the main instruction:</span></span>
    - <span data-ttu-id="04b50-257">[OK]/[実行する]/[はい]</span><span class="sxs-lookup"><span data-stu-id="04b50-257">OK/[Do it]/Yes</span></span>
    - <span data-ttu-id="04b50-258">[実行しない]/[いいえ]</span><span class="sxs-lookup"><span data-stu-id="04b50-258">[Don't do it]/No</span></span>
    - <span data-ttu-id="04b50-259">Cancel</span><span class="sxs-lookup"><span data-stu-id="04b50-259">Cancel</span></span>
- <span data-ttu-id="04b50-260">ユーザーに対して表示するボタンは、1 つまたは 2 つにします (例: [承諾] と [キャンセル])。</span><span class="sxs-lookup"><span data-stu-id="04b50-260">Expose only one or two buttons to the user at a time, for example, Accept and Cancel.</span></span> <span data-ttu-id="04b50-261">3 つ以上の操作をユーザーに示す必要がある場合は、ユーザーが操作を選択できる [チェック ボックス](checkbox.md) または [オプション ボタン](radio-button.md) を、それらの操作を開始するための 1 つのコマンド ボタンと共に使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="04b50-261">If you need to expose more actions to the user, consider using [checkboxes](checkbox.md) or [radio buttons](radio-button.md) from which the user can select actions, with a single command button to trigger those actions.</span></span>
- <span data-ttu-id="04b50-262">ある操作をアプリの複数のページで実行できるようにするには、各ページでボタンを使うのではなく、[下部のアプリ バー](app-bars.md) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="04b50-262">For an action that needs to be available across multiple pages within your app, instead of duplicating a button on multiple pages, consider using a [bottom app bar](app-bars.md).</span></span>

### <a name="recommended-single-button-layout"></a><span data-ttu-id="04b50-263">単一のボタンの推奨レイアウト</span><span class="sxs-lookup"><span data-stu-id="04b50-263">Recommended single button layout</span></span>

<span data-ttu-id="04b50-264">ボタンを 1 つしか必要としないレイアウトでは、コンテナーのコンテキストに応じて、左揃えまたは右揃えにします。</span><span class="sxs-lookup"><span data-stu-id="04b50-264">If your layout requires only one button, it should be either left- or right-aligned based on its container context.</span></span>

- <span data-ttu-id="04b50-265">ボタンが 1 つだけのダイアログでは、ボタンを**右揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="04b50-265">Dialogs with only one button should **right-align** the button.</span></span> <span data-ttu-id="04b50-266">ダイアログにボタンが 1 つしかない場合は、ボタンによって安全で非破壊的な操作が実行されるようにします。</span><span class="sxs-lookup"><span data-stu-id="04b50-266">If your dialog contains only one button, ensure that the button performs the safe, nondestructive action.</span></span> <span data-ttu-id="04b50-267">[ContentDialog](dialogs.md) を使い、単一のボタンを指定する場合は、自動的に右揃えになります。</span><span class="sxs-lookup"><span data-stu-id="04b50-267">If you use [ContentDialog](dialogs.md) and specify a single button, it will automatically right-align.</span></span>

![ダイアログ内のボタン](images/pushbutton_doc_dialog.png)

- <span data-ttu-id="04b50-269">ボタンがコンテナー UI 内 (トースト通知、ポップアップ、またはリスト ビュー項目内など) に表示される場合は、コンテナー内でボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="04b50-269">If your button appears within a container UI (for example, within a toast notification, a flyout, or a list view item), you should **right-align** the button within the container.</span></span>

![コンテナー内のボタン](images/pushbutton_doc_container.png)

- <span data-ttu-id="04b50-271">ページに含まれるボタンが 1 つだけの場合は (設定ページの下部にある [適用] ボタンなど)、ボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="04b50-271">In pages that contain a single button (for example, an "Apply" button at the bottom of a settings page), you should **left-align** the button.</span></span> <span data-ttu-id="04b50-272">これで、ページのその他のコンテンツとボタンを揃えて配置できます。</span><span class="sxs-lookup"><span data-stu-id="04b50-272">This ensures that the button aligns with the rest of the page content.</span></span>

![ページのボタン](images/pushbutton_doc_page.png)

## <a name="back-buttons"></a><span data-ttu-id="04b50-274">戻るボタン</span><span class="sxs-lookup"><span data-stu-id="04b50-274">Back buttons</span></span>

<span data-ttu-id="04b50-275">戻るボタンは、バック スタックまたはユーザーのナビゲーション履歴を使って "戻る" ナビゲーションを実現する、システムの UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="04b50-275">The back button is a system-provided UI element that enables backward navigation through either the back stack or navigation history of the user.</span></span> <span data-ttu-id="04b50-276">独自の"戻る"ボタンを作成する必要はありませんが、前に戻る移動で適切なエクスペリエンスを提供するために作業が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="04b50-276">You don't have to create your own back button, but you might have to do some work to enable a good backwards navigation experience.</span></span> <span data-ttu-id="04b50-277">詳しくは、「[履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04b50-277">For more info, see [History and backwards navigation](../basics/navigation-history-and-backwards-navigation.md)</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="04b50-278">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="04b50-278">Get the sample code</span></span>

- <span data-ttu-id="04b50-279">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="04b50-279">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="04b50-280">関連記事</span><span class="sxs-lookup"><span data-stu-id="04b50-280">Related articles</span></span>

- [<span data-ttu-id="04b50-281">Button クラス</span><span class="sxs-lookup"><span data-stu-id="04b50-281">Button class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)
- [<span data-ttu-id="04b50-282">オプション ボタン</span><span class="sxs-lookup"><span data-stu-id="04b50-282">Radio buttons</span></span>](radio-button.md)
- [<span data-ttu-id="04b50-283">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="04b50-283">Check boxes</span></span>](checkbox.md)
- [<span data-ttu-id="04b50-284">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="04b50-284">Toggle switches</span></span>](toggles.md)
