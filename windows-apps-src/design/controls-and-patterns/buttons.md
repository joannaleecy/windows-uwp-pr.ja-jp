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
ms.openlocfilehash: f0bf7731a8480fb4f6d81368227ad6259780381b
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2860484"
---
# <a name="buttons"></a><span data-ttu-id="3ada5-103">ボタン</span><span class="sxs-lookup"><span data-stu-id="3ada5-103">Buttons</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3ada5-104">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-104">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="3ada5-105">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="3ada5-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span> <span data-ttu-id="3ada5-106">プレビュー機能[最新の Windows 10 の内部のプレビュー ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-106">Preview features require the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="3ada5-107">ボタンは、特定の操作を直ちに実行する方法をユーザーに与えます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-107">A button gives the user a way to trigger an immediate action.</span></span> <span data-ttu-id="3ada5-108">いくつかのボタンは、ナビゲーション、繰り返しのアクション] メニューを表示するなど、特定のタスクの特殊なされます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-108">Some buttons are specialized for particular tasks, such as navigation, repeated actions, or presenting menus.</span></span>

![ボタンの例](images/controls/button.png)

<span data-ttu-id="3ada5-110">XAML フレームワークには、いくつかの特殊なボタン コントロールと同様に、標準のボタン コントロールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="3ada5-110">The XAML framework provides a standard button control as well as several specialized button controls.</span></span>

<span data-ttu-id="3ada5-111">コントロール</span><span class="sxs-lookup"><span data-stu-id="3ada5-111">Control</span></span> | <span data-ttu-id="3ada5-112">説明</span><span class="sxs-lookup"><span data-stu-id="3ada5-112">Description</span></span>
------- | -----------
[<span data-ttu-id="3ada5-113">ボタン</span><span class="sxs-lookup"><span data-stu-id="3ada5-113">Button</span></span>](/uwp/api/windows.ui.xaml.controls.button) | <span data-ttu-id="3ada5-114">すぐにアクションを開始します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-114">Initiates an immediate action.</span></span> <span data-ttu-id="3ada5-115">イベントやコマンドのバインドで使用できます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-115">Can be used with a Click event or Command binding.</span></span>
[<span data-ttu-id="3ada5-116">RepeatButton</span><span class="sxs-lookup"><span data-stu-id="3ada5-116">RepeatButton</span></span>](/uwp/api/windows.ui.xaml.controls.primitives.repeatbutton) | <span data-ttu-id="3ada5-117">押したときに、継続的をクリックしてイベントを発生させる] ボタン。</span><span class="sxs-lookup"><span data-stu-id="3ada5-117">A button that raises a Click event continuously while pressed.</span></span>
[<span data-ttu-id="3ada5-118">HyperlinkButton</span><span class="sxs-lookup"><span data-stu-id="3ada5-118">HyperlinkButton</span></span>](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton) | <span data-ttu-id="3ada5-119">A ボタン ナビゲーションで使用し、ハイパーリンクのようなスタイルが適用されます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-119">A button that's styled like a hyperlink, used for navigation.</span></span> <span data-ttu-id="3ada5-120">詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3ada5-120">See [Hyperlinks](hyperlinks.md) for more info.</span></span>
[<span data-ttu-id="3ada5-121">DropDownButton</span><span class="sxs-lookup"><span data-stu-id="3ada5-121">DropDownButton</span></span>](/uwp/api/windows.ui.xaml.controls.dropdownbutton) | <span data-ttu-id="3ada5-122">(プレビュー版)ボタン、プロセス、接続されているサブメニューを開きます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-122">(Preview) A button with a chevron to open an attached flyout.</span></span>
[<span data-ttu-id="3ada5-123">SplitButton</span><span class="sxs-lookup"><span data-stu-id="3ada5-123">SplitButton</span></span>](/uwp/api/windows.ui.xaml.controls.splitbutton) | <span data-ttu-id="3ada5-124">(プレビュー版)2 つの辺] ボタン。</span><span class="sxs-lookup"><span data-stu-id="3ada5-124">(Preview) A button with two sides.</span></span> <span data-ttu-id="3ada5-125">1 つの辺が、アクションを開始し、[その他の面に、メニューが表示します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-125">One side initiates an action, and the other side opens a menu.</span></span>
[<span data-ttu-id="3ada5-126">ToggleSplitButton</span><span class="sxs-lookup"><span data-stu-id="3ada5-126">ToggleSplitButton</span></span>](/uwp/api/windows.ui.xaml.controls.togglesplitbutton) | <span data-ttu-id="3ada5-127">(プレビュー版)2 つの辺の表示/非表示] ボタン。</span><span class="sxs-lookup"><span data-stu-id="3ada5-127">(Preview) A toggle button with two sides.</span></span> <span data-ttu-id="3ada5-128">1 つの辺をオン/オフを切り替えます、その他の面に、メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-128">One side toggles on/off, and the other side opens a menu.</span></span>

| **<span data-ttu-id="3ada5-129">Windows の UI ライブラリを取得します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-129">Get the Windows UI Library</span></span>** |
| - |
| <span data-ttu-id="3ada5-130">DropDownButton、分割ボタンと ToggleSplitButton NuGet パッケージに新しいコントロールや UWP アプリの UI の機能が含まれている、Windows UI ライブラリの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="3ada5-130">DropDownButton, SplitButton, and ToggleSplitButton are included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="3ada5-131">インストール方法など、さらに詳しい情報は、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3ada5-131">For more info, including installation instructions, see the [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> |

| **<span data-ttu-id="3ada5-132">Platform Api</span><span class="sxs-lookup"><span data-stu-id="3ada5-132">Platform APIs</span></span>** | **<span data-ttu-id="3ada5-133">Windows UI ライブラリ Api</span><span class="sxs-lookup"><span data-stu-id="3ada5-133">Windows UI Library APIs</span></span>** |
| - | - |
| <span data-ttu-id="3ada5-134">して[[イベント] をクリックして](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click)[コマンドのプロパティ](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.command)</span><span class="sxs-lookup"><span data-stu-id="3ada5-134">[Click event](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.click), [Command property](/uwp/api/windows.ui.xaml.controls.primitives.buttonbase.command)</span></span> | <span data-ttu-id="3ada5-135">[DropDownButton クラス](/uwp/api/microsoft.ui.xaml.controls.dropdownbutton)、 [SplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.splitbutton) [ToggleSplitButton クラス](/uwp/api/microsoft.ui.xaml.controls.togglesplitbutton)</span><span class="sxs-lookup"><span data-stu-id="3ada5-135">[DropDownButton class](/uwp/api/microsoft.ui.xaml.controls.dropdownbutton), [SplitButton class](/uwp/api/microsoft.ui.xaml.controls.splitbutton), [ToggleSplitButton class](/uwp/api/microsoft.ui.xaml.controls.togglesplitbutton)</span></span> |

## <a name="is-this-the-right-control"></a><span data-ttu-id="3ada5-136">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="3ada5-136">Is this the right control?</span></span>

<span data-ttu-id="3ada5-137">ユーザー フォームを送信するなど、すぐにアクションを開始するように**ボタン**を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-137">Use a **Button** to let the user initiate an immediate action, such as submitting a form.</span></span>

<span data-ttu-id="3ada5-138">別のページに移動するには、アクション ボタンを使用しません。代わりに、 [HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton)を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-138">Don't use a button when the action is to navigate to another page; use a [HyperlinkButton](/uwp/api/windows.ui.xaml.controls.hyperlinkbutton) instead.</span></span> <span data-ttu-id="3ada5-139">詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3ada5-139">See [Hyperlinks](hyperlinks.md) for more info.</span></span>
> <span data-ttu-id="3ada5-140">例外: ウィザードでのページの移動には、[戻る] と [次へ] というラベルのボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="3ada5-140">Exception: For wizard navigation, use buttons labeled "Back" and "Next".</span></span> <span data-ttu-id="3ada5-141">他の種類の下位またはナビゲーションを上位レベルの場合は、使用して[[戻る] ボタン](../basics/navigation-history-and-backwards-navigation.md)。</span><span class="sxs-lookup"><span data-stu-id="3ada5-141">For other types of backwards navigation or navigation to an upper level, use a [back button](../basics/navigation-history-and-backwards-navigation.md).</span></span>

<span data-ttu-id="3ada5-142">ユーザーは、操作を繰り返し発生する場合はの**RepeatButton**を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-142">Use a **RepeatButton** when the user might want to trigger an action repeatedly.</span></span> <span data-ttu-id="3ada5-143">たとえば、反対の値を増減する、RepeatButton を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-143">For example, use a RepeatButton to increment or decrement a value in a counter.</span></span>

<span data-ttu-id="3ada5-144">ボタンにその他のオプションを含むフライアウトときの**DropDownButton**を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-144">Use a **DropDownButton** when the button has a flyout that contains more options.</span></span> <span data-ttu-id="3ada5-145">既定のプロセスでは、視覚ボタンにフライアウトが含まれていることを提供します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-145">The default chevron provides a visual indication that the button includes a flyout.</span></span>

<span data-ttu-id="3ada5-146">ユーザーは、すぐにアクションを開始またはいないその他のオプションからを個別に選択できるようにする場合はの**SplitButton**を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-146">Use a **SplitButton** when you want the user to be able to initiate an immediate action or choose from additional options independently.</span></span>

## <a name="examples"></a><span data-ttu-id="3ada5-147">例</span><span class="sxs-lookup"><span data-stu-id="3ada5-147">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="3ada5-148">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="3ada5-148">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="3ada5-149"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Button">アプリを開き、Button の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="3ada5-149">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Button">open the app and see the Button in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="3ada5-150">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="3ada5-150">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="3ada5-151">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="3ada5-151">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="3ada5-152">この例では、一情報へのアクセスを求めるダイアログ ボックスで、2 つのボタン ([Allow] (許可) と [Block] (禁止)) を使っています。</span><span class="sxs-lookup"><span data-stu-id="3ada5-152">This example uses two buttons, Allow and Block, in a dialog requesting location access.</span></span>

![ダイアログで使われるボタンの例](images/dialogs/dialog_RS2_two_button.png)

## <a name="create-a-button"></a><span data-ttu-id="3ada5-154">ボタンの作成</span><span class="sxs-lookup"><span data-stu-id="3ada5-154">Create a button</span></span>

<span data-ttu-id="3ada5-155">クリックに応答するボタンの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-155">This example shows a button that responds to a click.</span></span>

<span data-ttu-id="3ada5-156">XAML でボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-156">Create the button in XAML.</span></span>

```xaml
<Button Content="Subscribe" Click="SubscribeButton_Click"/>
```

<span data-ttu-id="3ada5-157">または、コードでボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-157">Or create the button in code.</span></span>

```csharp
Button subscribeButton = new Button();
subscribeButton.Content = "Subscribe";
subscribeButton.Click += SubscribeButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(subscribeButton);
```

<span data-ttu-id="3ada5-158">Click イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-158">Handle the Click event.</span></span>

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

### <a name="button-interaction"></a><span data-ttu-id="3ada5-159">ボタンの対話式操作</span><span class="sxs-lookup"><span data-stu-id="3ada5-159">Button interaction</span></span>

<span data-ttu-id="3ada5-160">ポインターがボタンの上にあるときに、指やスタイラスでそのボタンをタップするか、マウスの左ボタンを押すと、ボタンでは [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-160">When you tap a Button with a finger or stylus, or press a left mouse button while the pointer is over it, the button raises the [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) event.</span></span> <span data-ttu-id="3ada5-161">ボタンにキーボード フォーカスがある場合は、Enter キーまたは Space キーを押しても、Click イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-161">If a button has keyboard focus, pressing the Enter key or the Spacebar key also raises the Click event.</span></span>

<span data-ttu-id="3ada5-162">通常、ボタンでは低レベルな [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントを処理できません。これに代わる Click 動作があるためです。</span><span class="sxs-lookup"><span data-stu-id="3ada5-162">You generally can't handle low-level [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) events on a Button because it has the Click behavior instead.</span></span> <span data-ttu-id="3ada5-163">詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3ada5-163">For more info, see [Events and routed events overview](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx).</span></span>

<span data-ttu-id="3ada5-164">ボタンで Click イベントが発生する方法を変えるには、[ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) プロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-164">You can change how a button raises the Click event by changing the [ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) property.</span></span> <span data-ttu-id="3ada5-165">ClickMode の既定値は **Release** ですが、ボタンの ClickMode を **Hover** または **Press** に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-165">The default ClickMode value is **Release**, but you also can set a button's ClickMode to **Hover** or **Press**.</span></span> <span data-ttu-id="3ada5-166">ClickMode が **Hover** の場合、キーボード操作やタッチ操作によって Click イベントを発生させることはできません。</span><span class="sxs-lookup"><span data-stu-id="3ada5-166">If ClickMode is **Hover**, the Click event can't be raised with the keyboard or touch.</span></span>


### <a name="button-content"></a><span data-ttu-id="3ada5-167">ボタンのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="3ada5-167">Button content</span></span>

<span data-ttu-id="3ada5-168">ボタンは [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx) です。</span><span class="sxs-lookup"><span data-stu-id="3ada5-168">Button is a [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx).</span></span> <span data-ttu-id="3ada5-169">その XAML コンテンツ プロパティは [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) であり、`<Button>A button's content</Button>` のような XAML 構文を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-169">Its XAML content property is [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx), which enables a syntax like this for XAML: `<Button>A button's content</Button>`.</span></span> <span data-ttu-id="3ada5-170">任意のオブジェクトをボタンのコンテンツとして設定できます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-170">You can set any object as the button's content.</span></span> <span data-ttu-id="3ada5-171">コンテンツが [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) の場合、ボタンにレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-171">If the content is a [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx), it is rendered in the button.</span></span> <span data-ttu-id="3ada5-172">コンテンツが別のタイプのオブジェクトの場合、その文字列表現がボタンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-172">If the content is another type of object, its string representation is shown in the button.</span></span>

<span data-ttu-id="3ada5-173">ボタンのコンテンツは、通常はテキストです。</span><span class="sxs-lookup"><span data-stu-id="3ada5-173">A button's content is usually text.</span></span> <span data-ttu-id="3ada5-174">テキスト コンテンツの付いたボタンの設計に関する推奨事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-174">Here are design recommendations for buttons with text content:</span></span>
-   <span data-ttu-id="3ada5-175">ボタンによって行われる操作を明確に説明する、簡潔で具体的でわかりやすいテキストを使います。</span><span class="sxs-lookup"><span data-stu-id="3ada5-175">Use a concise, specific, self-explanatory text that clearly describes the action that the button performs.</span></span> <span data-ttu-id="3ada5-176">通常、ボタンのテキスト コンテンツは、1 語の動詞です。</span><span class="sxs-lookup"><span data-stu-id="3ada5-176">Usually button text content is a single word, a verb.</span></span>
-   <span data-ttu-id="3ada5-177">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="3ada5-177">Use the default font unless your brand guidelines tell you to use something different.</span></span>
-   <span data-ttu-id="3ada5-178">短いテキストでは、120px の最小ボタン幅を使用し、幅が狭いコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-178">For shorter text, avoid narrow command buttons by using a minimum button width of 120px.</span></span>
- <span data-ttu-id="3ada5-179">長いテキストでは、テキストを最大文字数 26 文字に制限し、さまざまなコマンド ボタンは使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-179">For longer text, avoid wide command buttons by limiting text to a maximum length of 26 characters.</span></span>
-   <span data-ttu-id="3ada5-180">ボタンのテキスト コンテンツが動的な場合 ([ローカライズされる](../globalizing/globalizing-portal.md) 場合など) は、ボタンのサイズがどのように変化し、その周囲のコントロールに何が起こるかを考えます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-180">If the button's text content is dynamic (i.e., it is [localized](../globalizing/globalizing-portal.md)), consider how the button will resize and what will happen to controls around it.</span></span>

<table>
<tr>
<td> <b><span data-ttu-id="3ada5-181">必要な修正:</span><span class="sxs-lookup"><span data-stu-id="3ada5-181">Need to fix:</span></span></b><br> <span data-ttu-id="3ada5-182">オーバーフロー テキストの付いたボタン。</span><span class="sxs-lookup"><span data-stu-id="3ada5-182">Buttons with overflowing text.</span></span> </td>
<td> <img src="images/button-wraptext.png"/> </td>
</tr>
<tr>
<td> <b><span data-ttu-id="3ada5-183">オプション 1:</span><span class="sxs-lookup"><span data-stu-id="3ada5-183">Option 1:</span></span></b><br> <span data-ttu-id="3ada5-184">テキストの長さが 26 文字より大きい場合は、ボタンの幅やスタック ボタンを増やし、テキストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-184">Increase button width, stack buttons, and wrap if text length is greater than 26 characters.</span></span> </td>
<td> <img src="images/button-wraptext1.png"> </td>
</tr>
<tr>
<td> <b><span data-ttu-id="3ada5-185">オプション 2:</span><span class="sxs-lookup"><span data-stu-id="3ada5-185">Option 2:</span></span></b><br> <span data-ttu-id="3ada5-186">ボタンの高さを増やし、テキストを折り返します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-186">Increase button height, and wrap text.</span></span> </td>
<td> <img src="images/button-wraptext2.png"> </td>
</tr>
</table>

<span data-ttu-id="3ada5-187">ボタンの外観を構成する視覚効果をカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-187">You can also customize visuals that make up the button's appearance.</span></span> <span data-ttu-id="3ada5-188">たとえば、テキストをアイコンに置き換えたり、アイコンとテキストを使用したりできます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-188">For example, you could replace the text with an icon, or use an icon plus text.</span></span>

<span data-ttu-id="3ada5-189">ここでは、画像とテキストを含む **StackPanel** がボタンのコンテンツとして設定されます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-189">Here, a **StackPanel** that contains an image and text is set as the content of a button.</span></span>

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

<span data-ttu-id="3ada5-190">ボタンは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-190">The button looks like this.</span></span>

![画像とテキスト コンテンツがあるボタン](images/button-orange.png)

## <a name="create-a-repeat-button"></a><span data-ttu-id="3ada5-192">繰り返しボタンの作成</span><span class="sxs-lookup"><span data-stu-id="3ada5-192">Create a repeat button</span></span>

<span data-ttu-id="3ada5-193">[RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) は、ボタンが押されてから離されるまで、繰り返し [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントを発生させるボタンです。</span><span class="sxs-lookup"><span data-stu-id="3ada5-193">A [RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) is a button that raises [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) events repeatedly from the time it's pressed until it's released.</span></span> <span data-ttu-id="3ada5-194">ボタンが押されてからクリック操作の繰り返しを始めるまでの RepeatButton の待ち時間を指定するには、[Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-194">Set the [Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) property to specify the time that the RepeatButton waits after it is pressed before it starts repeating the click action.</span></span> <span data-ttu-id="3ada5-195">クリック操作の繰り返し間隔を指定するには、[Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-195">Set the [Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) property to specify the time between repetitions of the click action.</span></span> <span data-ttu-id="3ada5-196">これらのプロパティの時間はどちらもミリ秒単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-196">Times for both properties are specified in milliseconds.</span></span>

<span data-ttu-id="3ada5-197">次の例は 2 つの RepeatButton コントロールを示しています。それぞれの Click イベントを使って、テキスト ブロックに表示される値を増減します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-197">The following example shows two RepeatButton controls whose respective Click events are used to increase and decrease the value shown in a text block.</span></span>

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

## <a name="create-a-drop-down-button"></a><span data-ttu-id="3ada5-198">ドロップ ダウン ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-198">Create a drop down button</span></span>

> <span data-ttu-id="3ada5-199">**プレビュー**: DropDownButton[最新の Windows 10 の内部のプレビュー ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)必要です。</span><span class="sxs-lookup"><span data-stu-id="3ada5-199">**Preview**: DropDownButton requires the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="3ada5-200">の[DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton)は、その他のオプションを含む添付のフライアウトがある視覚的なインジケーターとして、プロセスが表示されているボタンです。</span><span class="sxs-lookup"><span data-stu-id="3ada5-200">A [DropDownButton](/uwp/api/windows.ui.xaml.controls.dropdownbutton) is a button that shows a chevron as a visual indicator that it has an attached flyout that contains more options.</span></span> <span data-ttu-id="3ada5-201">フライアウト; と標準のボタンと同じ動作があります。表示のみとは異なります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-201">It has the same behavior as a standard Button with a flyout; only the appearance is different.</span></span>

<span data-ttu-id="3ada5-202">ドロップ ダウン ボタンをクリックしてイベントを継承するが、通常はこれを使用しません。</span><span class="sxs-lookup"><span data-stu-id="3ada5-202">The drop down button inherits the Click event, but you typically don't use it.</span></span> <span data-ttu-id="3ada5-203">代わりに、フライアウト プロパティを使用するフライアウトを添付し、フライアウトでメニュー オプションを使用してアクションを起動します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-203">Instead, you use the Flyout property to attach a flyout and invoke actions using menu options in the flyout.</span></span> <span data-ttu-id="3ada5-204">フライアウトは、ボタンをクリックしたときに自動的に開きます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-204">The flyout opens automatically when the button is clicked.</span></span>

> [!TIP]
> <span data-ttu-id="3ada5-205">フライアウトの詳細については、[メニューおよびコンテキスト メニュー](menus.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3ada5-205">For more info about flyouts, see [Menus and context menus](menus.md).</span></span>

### <a name="example---drop-down-button"></a><span data-ttu-id="3ada5-206">ドロップ ダウン ボタンの使用例</span><span class="sxs-lookup"><span data-stu-id="3ada5-206">Example - Drop down button</span></span>

<span data-ttu-id="3ada5-207">この例では、段落の配置を RichEditBox のためのコマンドを含むフライアウトを使って、ドロップ ダウン ボタンを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-207">This example shows how to create a drop down button with a flyout that contains commands for paragraph alignment in a RichEditBox.</span></span> <span data-ttu-id="3ada5-208">(情報とコードの詳細を参照してください[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="3ada5-208">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>

![ドロップ ダウン配置コマンド ボタン](images/drop-down-button-align.png)

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

## <a name="create-a-split-button"></a><span data-ttu-id="3ada5-210">分割ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-210">Create a split button</span></span>

> <span data-ttu-id="3ada5-211">**プレビュー**: SplitButton[最新の Windows 10 の内部のプレビュー ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)必要です。</span><span class="sxs-lookup"><span data-stu-id="3ada5-211">**Preview**: SplitButton requires the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="3ada5-212">[SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton)を個別に呼び出すことができる 2 つの部分があります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-212">A [SplitButton](/uwp/api/windows.ui.xaml.controls.splitbutton) has two parts that can be invoked separately.</span></span> <span data-ttu-id="3ada5-213">1 つの部分では、標準のボタンに似ています、すぐにアクションを起動します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-213">One part behaves like a standard button and invokes an immediate action.</span></span> <span data-ttu-id="3ada5-214">他の部分では、ユーザーが選択できるその他のオプションを含むフライアウトを起動します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-214">The other part invokes a flyout that contains additional options that the user can choose from.</span></span>

> [!NOTE]
> <span data-ttu-id="3ada5-215">タッチで呼び出されると、[分割] ボタンのドロップダウン ボタンとして動作します。ボタンの両方の部分では、フライアウトを起動します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-215">When invoked with touch, the split button behaves as a drop down button; both halves of the button invoke the flyout.</span></span> <span data-ttu-id="3ada5-216">入力には、他の方法でユーザーは個別にボタンのいずれかの半分を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-216">With other methods of input, a user can invoke either half of the button separately.</span></span>

<span data-ttu-id="3ada5-217">分割ボタンの一般的な動作は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="3ada5-217">The typical behavior for a split button is:</span></span>

- <span data-ttu-id="3ada5-218">ユーザーは、ボタンのパーツをクリックすると、イベントを処理] をクリックして] ボックスで現在選択されている] オプションを起動します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-218">When the user clicks the button part, handle the Click event to invoke the option that's currently selected in the drop down.</span></span>
- <span data-ttu-id="3ada5-219">開いているドロップダウンとハンドルの呼び出しのオプションを両方の変更にドロップダウン リスト内のアイテムが選択されている起動し、します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-219">When the drop down is open, handle invocation of the items in the drop down to both change which option is selected, and then invoke it.</span></span> <span data-ttu-id="3ada5-220">に、フライアウト アイテムを起動することが重要] ボタンのタッチを使用してイベントが発生しない] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-220">It's important to invoke the flyout item because the button Click event doesn't occur when using touch.</span></span>

> [!TIP]
> <span data-ttu-id="3ada5-221">のドロップ内のアイテムを設定することや、呼び出しを処理するには、さまざまな方法があります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-221">There are many ways to put items in the drop down and handle their invocation.</span></span> <span data-ttu-id="3ada5-222">リスト ビューまたは GridView を使用する方法の 1 つが SelectionChanged イベントを処理するには</span><span class="sxs-lookup"><span data-stu-id="3ada5-222">If you use a ListView or GridView, one way is to handle the SelectionChanged event.</span></span> <span data-ttu-id="3ada5-223">この場合[SingleSelectionFollowsFocus](/uwp/api/windows.ui.xaml.controls.listviewbase.singleselectionfollowsfocus)を**false**に設定します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-223">If you do this, set [SingleSelectionFollowsFocus](/uwp/api/windows.ui.xaml.controls.listviewbase.singleselectionfollowsfocus) to **false**.</span></span> <span data-ttu-id="3ada5-224">これにより、ユーザーがそれぞれの変更のアイテムが起動せず、キーボードを使うと、オプションを移動します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-224">This lets users navigate the options using a keyboard without invoking the item on each change.</span></span>

### <a name="example---split-button"></a><span data-ttu-id="3ada5-225">例の分割] ボタン</span><span class="sxs-lookup"><span data-stu-id="3ada5-225">Example - Split button</span></span>

<span data-ttu-id="3ada5-226">この例を RichEditBox で選択したテキストの背景色を変更するための分割] ボタンを作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-226">This example shows how to create a split button that is used to change the foreground color of selected text in a RichEditBox.</span></span> <span data-ttu-id="3ada5-227">(情報とコードの詳細を参照してください[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="3ada5-227">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>

![背景色を選ぶための分割] ボタン](images/split-button-rtb.png)

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

## <a name="create-a-toggle-split-button"></a><span data-ttu-id="3ada5-229">表示/非表示の分割] ボタンを作成します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-229">Create a toggle split button</span></span>

> <span data-ttu-id="3ada5-230">**プレビュー**: ToggleSplitButton[最新の Windows 10 の内部のプレビュー ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)必要です。</span><span class="sxs-lookup"><span data-stu-id="3ada5-230">**Preview**: ToggleSplitButton requires the [latest Windows 10 Insider Preview build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="3ada5-231">[ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton)を個別に呼び出すことができる 2 つの部分があります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-231">A [ToggleSplitButton](/uwp/api/windows.ui.xaml.controls.togglesplitbutton) has two parts that can be invoked separately.</span></span> <span data-ttu-id="3ada5-232">1 つの部分に似てトグル ボタンをオンまたはオフにすることができます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-232">One part behaves like a toggle button that can be on or off.</span></span> <span data-ttu-id="3ada5-233">他の部分では、ユーザーが選択できるその他のオプションを含むフライアウトを起動します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-233">The other part invokes a flyout that contains additional options that the user can choose from.</span></span>

<span data-ttu-id="3ada5-234">表示/非表示の分割] ボタンは通常、機能を無効にする機能は、ユーザーが選択される複数のオプションを有効またはに使用されます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-234">A toggle split button is typically used to enable or disable a feature when the feature has multiple options that the user can choose from.</span></span> <span data-ttu-id="3ada5-235">たとえば、ドキュメントの編集者] で、される可能性がありますドロップダウンを使用して、リストのスタイルを選択する] リストを有効にします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-235">For example, in a document editor, it could be used to turn lists on or off, while the drop down is used to choose the style of the list.</span></span>

> [!NOTE]
> <span data-ttu-id="3ada5-236">タッチで呼び出されると、[分割] ボタンのドロップ ダウン ボタンとして動作します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-236">When invoked with touch, the split button behaves as a drop down button.</span></span> <span data-ttu-id="3ada5-237">入力には、他の方法でユーザーは個別にボタンのいずれかの半分を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-237">With other methods of input, a user can invoke either half of the button separately.</span></span> <span data-ttu-id="3ada5-238">タッチ] ボタンの両方の部分フライアウトを起動します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-238">With touch, both halves of the button invoke the flyout.</span></span> <span data-ttu-id="3ada5-239">このため、] をオンまたはオフに切り替え] フライアウト コンテンツのオプションを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-239">Therefore, you must include an option in your flyout content to toggle the button on or off.</span></span>

### <a name="differences-with-togglebutton"></a><span data-ttu-id="3ada5-240">トグル ボタンとの相違点</span><span class="sxs-lookup"><span data-stu-id="3ada5-240">Differences with ToggleButton</span></span>

<span data-ttu-id="3ada5-241">[トグル ボタン](/uwp/api/windows.ui.xaml.controls.primitives.togglebutton)] とは異なり ToggleSplitButton に中間状態はありません。</span><span class="sxs-lookup"><span data-stu-id="3ada5-241">Unlike [ToggleButton](/uwp/api/windows.ui.xaml.controls.primitives.togglebutton), ToggleSplitButton does not have an indeterminate state.</span></span> <span data-ttu-id="3ada5-242">その結果、これらの違いを点に注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-242">As a result, you should keep in mind these differences:</span></span>

- <span data-ttu-id="3ada5-243">**IsThreeState**プロパティまたは**中間状態**のイベントを ToggleSplitButton はありません。</span><span class="sxs-lookup"><span data-stu-id="3ada5-243">ToggleSplitButton does not have an **IsThreeState** property or **Indeterminate** event.</span></span>
- <span data-ttu-id="3ada5-244">[ToggleSplitButton.IsChecked](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischecked)プロパティは、だけ**ブール値**、**ブール値が null 許容**されません。</span><span class="sxs-lookup"><span data-stu-id="3ada5-244">The [ToggleSplitButton.IsChecked](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischecked) property is just a **bool**, not a **nullable bool**.</span></span>
- <span data-ttu-id="3ada5-245">ToggleSplitButton が[IsCheckedChanged](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischeckedchanged)イベントのみ別の**オン**と**オフ**のイベントはありません。</span><span class="sxs-lookup"><span data-stu-id="3ada5-245">ToggleSplitButton has only the [IsCheckedChanged](/uwp/api/windows.ui.xaml.controls.togglesplitbutton.ischeckedchanged) event; it does not have separate **Checked** and **Unchecked** events.</span></span>

### <a name="example---toggle-split-button"></a><span data-ttu-id="3ada5-246">例: 表示/非表示の分割] ボタン</span><span class="sxs-lookup"><span data-stu-id="3ada5-246">Example - Toggle split button</span></span>

<span data-ttu-id="3ada5-247">方法の分割] ボタン、トグルを使用してリストのオンとオフを書式設定を有効にして、RichEditBox で、リストのスタイルを変更する次の例を示しています。</span><span class="sxs-lookup"><span data-stu-id="3ada5-247">The following example shows how a toggle split button could be used to turn list formatting on or off, and change the style of the list, in a RichEditBox.</span></span> <span data-ttu-id="3ada5-248">(情報とコードの詳細を参照してください[リッチ エディット ボックス](rich-edit-box.md))。</span><span class="sxs-lookup"><span data-stu-id="3ada5-248">(For more info and code, see [Rich edit box](rich-edit-box.md)).</span></span>

![リストのスタイルを選ぶためのトグル分割] ボタン](images/toggle-split-button-open.png)

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

## <a name="recommendations"></a><span data-ttu-id="3ada5-250">推奨事項</span><span class="sxs-lookup"><span data-stu-id="3ada5-250">Recommendations</span></span>

- <span data-ttu-id="3ada5-251">ボタンの用途と状態をユーザーがはっきりと理解できるようにします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-251">Make sure the purpose and state of a button are clear to the user.</span></span>
- <span data-ttu-id="3ada5-252">同じ意思決定に対して複数のボタンが存在する場合 (確認のダイアログなど)、コミット ボタンは次の順番で提示します。この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-252">When there are multiple buttons for the same decision (such as in a confirmation dialog), present the commit buttons in this order, where [Do it] and [Don't do it] are specific responses to the main instruction:</span></span>
    - <span data-ttu-id="3ada5-253">[OK]/[実行する]/[はい]</span><span class="sxs-lookup"><span data-stu-id="3ada5-253">OK/[Do it]/Yes</span></span>
    - <span data-ttu-id="3ada5-254">[実行しない]/[いいえ]</span><span class="sxs-lookup"><span data-stu-id="3ada5-254">[Don't do it]/No</span></span>
    - <span data-ttu-id="3ada5-255">[キャンセル]</span><span class="sxs-lookup"><span data-stu-id="3ada5-255">Cancel</span></span>
- <span data-ttu-id="3ada5-256">ユーザーに対して表示するボタンは、1 つまたは 2 つにします (例: [承諾] と [キャンセル])。</span><span class="sxs-lookup"><span data-stu-id="3ada5-256">Expose only one or two buttons to the user at a time, for example, Accept and Cancel.</span></span> <span data-ttu-id="3ada5-257">3 つ以上の操作をユーザーに示す必要がある場合は、ユーザーが操作を選択できる [チェック ボックス](checkbox.md) または [オプション ボタン](radio-button.md) を、それらの操作を開始するための 1 つのコマンド ボタンと共に使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-257">If you need to expose more actions to the user, consider using [checkboxes](checkbox.md) or [radio buttons](radio-button.md) from which the user can select actions, with a single command button to trigger those actions.</span></span>
- <span data-ttu-id="3ada5-258">ある操作をアプリの複数のページで実行できるようにするには、各ページでボタンを使うのではなく、[下部のアプリ バー](app-bars.md) を使うことを検討します。</span><span class="sxs-lookup"><span data-stu-id="3ada5-258">For an action that needs to be available across multiple pages within your app, instead of duplicating a button on multiple pages, consider using a [bottom app bar](app-bars.md).</span></span>

### <a name="recommended-single-button-layout"></a><span data-ttu-id="3ada5-259">単一のボタンの推奨レイアウト</span><span class="sxs-lookup"><span data-stu-id="3ada5-259">Recommended single button layout</span></span>

<span data-ttu-id="3ada5-260">ボタンを 1 つしか必要としないレイアウトでは、コンテナーのコンテキストに応じて、左揃えまたは右揃えにします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-260">If your layout requires only one button, it should be either left- or right-aligned based on its container context.</span></span>

- <span data-ttu-id="3ada5-261">ボタンが 1 つだけのダイアログでは、ボタンを**右揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-261">Dialogs with only one button should **right-align** the button.</span></span> <span data-ttu-id="3ada5-262">ダイアログにボタンが 1 つしかない場合は、ボタンによって安全で非破壊的な操作が実行されるようにします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-262">If your dialog contains only one button, ensure that the button performs the safe, nondestructive action.</span></span> <span data-ttu-id="3ada5-263">[ContentDialog](dialogs.md) を使い、単一のボタンを指定する場合は、自動的に右揃えになります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-263">If you use [ContentDialog](dialogs.md) and specify a single button, it will automatically right-align.</span></span>

![ダイアログ内のボタン](images/pushbutton_doc_dialog.png)

- <span data-ttu-id="3ada5-265">ボタンがコンテナー UI 内 (トースト通知、ポップアップ、またはリスト ビュー項目内など) に表示される場合は、コンテナー内でボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-265">If your button appears within a container UI (for example, within a toast notification, a flyout, or a list view item), you should **right-align** the button within the container.</span></span>

![コンテナー内のボタン](images/pushbutton_doc_container.png)

- <span data-ttu-id="3ada5-267">ページに含まれるボタンが 1 つだけの場合は (設定ページの下部にある [適用] ボタンなど)、ボタンを**左揃え**にします。</span><span class="sxs-lookup"><span data-stu-id="3ada5-267">In pages that contain a single button (for example, an "Apply" button at the bottom of a settings page), you should **left-align** the button.</span></span> <span data-ttu-id="3ada5-268">これで、ページのその他のコンテンツとボタンを揃えて配置できます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-268">This ensures that the button aligns with the rest of the page content.</span></span>

![ページのボタン](images/pushbutton_doc_page.png)

## <a name="back-buttons"></a><span data-ttu-id="3ada5-270">戻るボタン</span><span class="sxs-lookup"><span data-stu-id="3ada5-270">Back buttons</span></span>

<span data-ttu-id="3ada5-271">戻るボタンは、バック スタックまたはユーザーのナビゲーション履歴を使って "戻る" ナビゲーションを実現する、システムの UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="3ada5-271">The back button is a system-provided UI element that enables backward navigation through either the back stack or navigation history of the user.</span></span> <span data-ttu-id="3ada5-272">独自の"戻る"ボタンを作成する必要はありませんが、前に戻る移動で適切なエクスペリエンスを提供するために作業が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="3ada5-272">You don't have to create your own back button, but you might have to do some work to enable a good backwards navigation experience.</span></span> <span data-ttu-id="3ada5-273">詳しくは、「[履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3ada5-273">For more info, see [History and backwards navigation](../basics/navigation-history-and-backwards-navigation.md)</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="3ada5-274">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="3ada5-274">Get the sample code</span></span>

- <span data-ttu-id="3ada5-275">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="3ada5-275">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="3ada5-276">関連記事</span><span class="sxs-lookup"><span data-stu-id="3ada5-276">Related articles</span></span>

- [<span data-ttu-id="3ada5-277">Button クラス</span><span class="sxs-lookup"><span data-stu-id="3ada5-277">Button class</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)
- [<span data-ttu-id="3ada5-278">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="3ada5-278">Radio buttons</span></span>](radio-button.md)
- [<span data-ttu-id="3ada5-279">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="3ada5-279">Check boxes</span></span>](checkbox.md)
- [<span data-ttu-id="3ada5-280">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="3ada5-280">Toggle switches</span></span>](toggles.md)
