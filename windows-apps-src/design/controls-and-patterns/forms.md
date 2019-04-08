---
Description: UWP アプリでのフォームのレイアウト ガイドラインです。
title: フォーム
template: detail.hbs
ms.date: 11/07/2017
ms.topic: article
keywords: Windows 10, UWP, Fluent
ms.openlocfilehash: 8a57f13e168a248569bca1beeceed7b4f6c89f69
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658157"
---
# <a name="forms"></a><span data-ttu-id="80066-104">フォーム</span><span class="sxs-lookup"><span data-stu-id="80066-104">Forms</span></span>
<span data-ttu-id="80066-105">フォームは、収集し、ユーザーからのデータを送信するコントロールのグループです。</span><span class="sxs-lookup"><span data-stu-id="80066-105">A form is a group of controls that collect and submit data from users.</span></span> <span data-ttu-id="80066-106">フォームは、通常、設定ページの使用調査、アカウント、およびその他を作成します。</span><span class="sxs-lookup"><span data-stu-id="80066-106">Forms are typically used for settings pages, surveys, creating accounts, and much more.</span></span> 

<span data-ttu-id="80066-107">この記事では、フォームのレイアウトを XAML を作成するためのデザイン ガイドラインについて説明します。</span><span class="sxs-lookup"><span data-stu-id="80066-107">This article discusses design guidelines for creating XAML layouts for forms.</span></span>

![フォームの例](images/PivotHeader.png)

## <a name="when-should-you-use-a-form"></a><span data-ttu-id="80066-109">フォームを使用する場合</span><span class="sxs-lookup"><span data-stu-id="80066-109">When should you use a form?</span></span>
<span data-ttu-id="80066-110">フォームは、明確に関連する他のデータ入力を収集するための専用ページです。</span><span class="sxs-lookup"><span data-stu-id="80066-110">A form is a dedicated page for collecting data inputs that are clearly related to each other.</span></span> <span data-ttu-id="80066-111">ユーザーから明示的にデータを収集する必要がある場合は、フォームを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80066-111">You should use a form when you need to explicitly collect data from a user.</span></span> <span data-ttu-id="80066-112">ユーザーがフォームを作成する場合があります。</span><span class="sxs-lookup"><span data-stu-id="80066-112">You might create a form for a user to:</span></span>
- <span data-ttu-id="80066-113">アカウントにログインします。</span><span class="sxs-lookup"><span data-stu-id="80066-113">Log into an account</span></span>
- <span data-ttu-id="80066-114">アカウントをサインアップします。</span><span class="sxs-lookup"><span data-stu-id="80066-114">Sign up for an account</span></span>
- <span data-ttu-id="80066-115">プライバシーなどのアプリ設定を変更またはオプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="80066-115">Change app settings, such as privacy or display options</span></span>
- <span data-ttu-id="80066-116">調査を実施します。</span><span class="sxs-lookup"><span data-stu-id="80066-116">Take a survey</span></span>
- <span data-ttu-id="80066-117">アイテムを購入します。</span><span class="sxs-lookup"><span data-stu-id="80066-117">Purchase an item</span></span>
- <span data-ttu-id="80066-118">フィードバックの送信</span><span class="sxs-lookup"><span data-stu-id="80066-118">Give feedback</span></span>

## <a name="types-of-forms"></a><span data-ttu-id="80066-119">フォームの種類</span><span class="sxs-lookup"><span data-stu-id="80066-119">Types of forms</span></span>

<span data-ttu-id="80066-120">ユーザー入力が送信され、表示方法を検討する場合は、フォームの 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="80066-120">When thinking about how user input is submitted and displayed, there are two types of forms:</span></span>

### <a name="1-instantly-updating"></a><span data-ttu-id="80066-121">1. すぐに更新しています。</span><span class="sxs-lookup"><span data-stu-id="80066-121">1. Instantly updating</span></span>
![設定 ページ](images/control-examples/toggle-switch-news.png)

<span data-ttu-id="80066-123">ユーザーがフォーム内の値の変更の結果をすぐに確認する場合は、すぐに更新の形式を使用します。</span><span class="sxs-lookup"><span data-stu-id="80066-123">Use an instantly updating form when you want users to immediately see the results of changing the values in the form.</span></span> <span data-ttu-id="80066-124">たとえばの設定 ページで、現在の選択が表示され、選択内容に加えられた変更はすぐに適用されます。</span><span class="sxs-lookup"><span data-stu-id="80066-124">For example, in settings pages, the current selections are displayed, and any changes made to the selections are applied immediately.</span></span> <span data-ttu-id="80066-125">アプリでの変更を確認する必要があります[イベント ハンドラーを追加](controls-and-events-intro.md)を各入力コントロール。</span><span class="sxs-lookup"><span data-stu-id="80066-125">To acknowledge the changes in your app, you will need to [add an event handler](controls-and-events-intro.md) to each input control.</span></span> <span data-ttu-id="80066-126">ユーザーは、入力コントロールを変更すると、アプリが適宜ことができます。</span><span class="sxs-lookup"><span data-stu-id="80066-126">If a user changes an input control, then your app can respond appropriately.</span></span>

### <a name="2-submitting-with-button"></a><span data-ttu-id="80066-127">2. ボタンを送信します。</span><span class="sxs-lookup"><span data-stu-id="80066-127">2. Submitting with button</span></span>
<span data-ttu-id="80066-128">フォームの他の種類は、ボタンのクリックでデータを送信するタイミングを選択できます。</span><span class="sxs-lookup"><span data-stu-id="80066-128">The other type of form allows the user to choose when to submit data with a click of a button.</span></span>

![予定表は、新しいイベント ページを追加します。](images/calendar-form.png)

<span data-ttu-id="80066-130">この種類のフォームでは、応答でのユーザーを柔軟です。</span><span class="sxs-lookup"><span data-stu-id="80066-130">This type of form gives the user flexibility in responding.</span></span> <span data-ttu-id="80066-131">通常、この種類のフォームは、自由形式の複数の入力フィールドが含まれていて、したがってより多様な応答を受信します。</span><span class="sxs-lookup"><span data-stu-id="80066-131">Typically, this type of form contains more free form input fields, and thus receives a greater variety of responses.</span></span> <span data-ttu-id="80066-132">確実に有効なユーザー入力と正しく書式設定されたデータを送信すると、次の推奨事項を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="80066-132">To ensure valid user input and properly formatted data upon submission, consider the following recommendations:</span></span>

- <span data-ttu-id="80066-133">適切なコントロールを使用して無効な情報を送信することが不可能になります (つまりを使用して、テキスト ボックスではなく、CalendarDatePicker カレンダーの日付)。</span><span class="sxs-lookup"><span data-stu-id="80066-133">Make it impossible to submit invalid information by using the correct control (i.e., use a CalendarDatePicker rather than a TextBox for calendar dates).</span></span> <span data-ttu-id="80066-134">後で、入力コントロールのセクションで、フォームに適切な入力コントロールを選択する方法の詳細を参照してください。</span><span class="sxs-lookup"><span data-stu-id="80066-134">See more on selecting the appropriate input controls in your form in the Input Controls section later.</span></span>
- <span data-ttu-id="80066-135">テキスト ボックス コントロールを使用する場合により、ユーザーが必要な入力形式のヒントを提供、 [PlaceholderText](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBox.PlaceholderText)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="80066-135">When using TextBox controls, provide users a hint of the desired input format with the [PlaceholderText](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBox.PlaceholderText) property.</span></span>
- <span data-ttu-id="80066-136">適切なユーザーがスクリーン キーボードを使用して、コントロールの想定される入力の記述を提供する、 [InputScope](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.inputscope)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="80066-136">Provide users with the appropriate on-screen keyboard by stating the expected input of a control with the [InputScope](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.inputscope) property.</span></span>
- <span data-ttu-id="80066-137">マークにアスタリスクを使用して入力が必要な \* ラベル。</span><span class="sxs-lookup"><span data-stu-id="80066-137">Mark required input with an asterisk \* on the label.</span></span>
- <span data-ttu-id="80066-138">すべての必要な情報が入力されるまでは、[送信] ボタンを無効にします。</span><span class="sxs-lookup"><span data-stu-id="80066-138">Disable the submit button until all required information is filled in.</span></span>
- <span data-ttu-id="80066-139">送信時に無効なデータがある場合は、強調表示されたフィールドまたは [境界線] で無効な入力コントロールをマークして、ユーザー フォームを再送信するように要求します。</span><span class="sxs-lookup"><span data-stu-id="80066-139">If there is invalid data upon submission, mark the controls with invalid input with highlighted fields or borders, and require the user to resubmit the form.</span></span>
- <span data-ttu-id="80066-140">障害が発生したネットワーク接続などの他のエラーの確認をユーザーに適切なエラー メッセージを表示します。</span><span class="sxs-lookup"><span data-stu-id="80066-140">For other errors, such as failed network connection, make sure to display an appropriate error message to the user.</span></span> 


## <a name="layout"></a><span data-ttu-id="80066-141">レイアウト</span><span class="sxs-lookup"><span data-stu-id="80066-141">Layout</span></span>

<span data-ttu-id="80066-142">ユーザー エクスペリエンスを容易にし、ユーザーが入力した正しいにできることには、フォームのレイアウトをデザインするための次の推奨事項を検討してください。</span><span class="sxs-lookup"><span data-stu-id="80066-142">To facilitate the user experience and ensure that users are able to enter the correct input, consider the following recommendations for designing layouts for forms.</span></span> 

### <a name="labels"></a><span data-ttu-id="80066-143">ラベル</span><span class="sxs-lookup"><span data-stu-id="80066-143">Labels</span></span>
<span data-ttu-id="80066-144">[ラベル](labels.md)左揃え、入力コントロールの上に配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80066-144">[Labels](labels.md) should be left-aligned and placed above the input control.</span></span> <span data-ttu-id="80066-145">多くのコントロールでは、ラベルを表示する組み込みヘッダー プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="80066-145">Many controls have a built-in Header property to display the label.</span></span> <span data-ttu-id="80066-146">Header プロパティがないコントロールの場合、またはコントロールのグループにラベルを付ける場合は、代わりに [TextBlock](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.TextBlock) を使います。</span><span class="sxs-lookup"><span data-stu-id="80066-146">For controls that don't have a Header property, or to label groups of controls, you can use a [TextBlock](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.TextBlock) instead.</span></span>

<span data-ttu-id="80066-147">[ユーザー補助のための設計](../accessibility/accessibility.md)、すべての個人とグループの両方の人間にわかりやすくするため、スクリーン リーダーのコントロールのラベルを付けます。</span><span class="sxs-lookup"><span data-stu-id="80066-147">To [design for accessibility](../accessibility/accessibility.md), label all individual and groups of controls for clarity for both human and screen readers.</span></span> 

<span data-ttu-id="80066-148">フォント スタイルの既定値を使用して、 [UWP の種類ごとの傾斜増加](../style/typography.md)します。</span><span class="sxs-lookup"><span data-stu-id="80066-148">For font styles, use the default [UWP type ramp](../style/typography.md).</span></span> <span data-ttu-id="80066-149">使用`TitleTextBlockStyle`ページのタイトルの`SubtitleTextBlockStyle`グループの見出しと`BodyTextBlockStyle`のコントロールのラベル。</span><span class="sxs-lookup"><span data-stu-id="80066-149">Use `TitleTextBlockStyle` for page titles, `SubtitleTextBlockStyle` for group headings, and `BodyTextBlockStyle` for control labels.</span></span>

<div class="mx-responsive-img">
<table>
<tr><th><span data-ttu-id="80066-150">推奨される事項</span><span class="sxs-lookup"><span data-stu-id="80066-150">Do</span></span></th><th><span data-ttu-id="80066-151">非推奨</span><span class="sxs-lookup"><span data-stu-id="80066-151">Don't</span></span></th></tr>
<tr>
<td><img src="../controls-and-patterns/images/forms-shortform1col.png" alt="form with top labels"></td>
<td><img src="../controls-and-patterns/images/forms-leftlabel-donot1.png" alt="form with left labels don't"></td>
</tr>
</table>
</div>

### <a name="spacing"></a><span data-ttu-id="80066-152">間隔</span><span class="sxs-lookup"><span data-stu-id="80066-152">Spacing</span></span>
<span data-ttu-id="80066-153">使用を互いからコントロールのグループを視覚的に分離、[配置、余白、および埋め込み](../layout/alignment-margin-padding.md)。</span><span class="sxs-lookup"><span data-stu-id="80066-153">To visually separate groups of controls from each other, use [alignment, margins, and padding](../layout/alignment-margin-padding.md).</span></span> <span data-ttu-id="80066-154">個々 の入力コントロールの高さ 80px は、スペース区切り 24px 離れている必要があります。</span><span class="sxs-lookup"><span data-stu-id="80066-154">Individual input controls are 80px in height and should be spaced 24px apart.</span></span> <span data-ttu-id="80066-155">入力コントロールのグループには、スペース区切り 48px 離れている必要があります。</span><span class="sxs-lookup"><span data-stu-id="80066-155">Groups of input controls should be spaced 48px apart.</span></span>

![フォームのグループ](images/forms-groups.png)

### <a name="columns"></a><span data-ttu-id="80066-157">列</span><span class="sxs-lookup"><span data-stu-id="80066-157">Columns</span></span>
<span data-ttu-id="80066-158">列を作成すると、特に大きい画面サイズでのフォームで不要な空白を削減できます。</span><span class="sxs-lookup"><span data-stu-id="80066-158">Creating columns can reduce unnecessary white space in forms, especially with larger screen sizes.</span></span> <span data-ttu-id="80066-159">ただし、複数列のフォームを作成する場合は、列の数は、ページの入力コントロールの数と、アプリ ウィンドウの画面サイズに依存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80066-159">However, if you would like to create a multi-column form, the number of columns should depend on the number of input controls on the page and the screen size of the app window.</span></span> <span data-ttu-id="80066-160">多数の入力コントロールを含む画面を過負荷ではなく、フォームの複数のページの作成を検討してください。</span><span class="sxs-lookup"><span data-stu-id="80066-160">Rather than overwhelm the screen with numerous input controls, consider creating multiple pages for your form.</span></span>  

<div class="mx-responsive-img">
<table>
<tr><th><span data-ttu-id="80066-161">推奨される事項</span><span class="sxs-lookup"><span data-stu-id="80066-161">Do</span></span></th><th><span data-ttu-id="80066-162">非推奨</span><span class="sxs-lookup"><span data-stu-id="80066-162">Don't</span></span></th></tr>
<tr>
<td><img src="../controls-and-patterns/images/forms-2cols.png" alt="form with 2 columns"></td>
<td><img src="../controls-and-patterns/images/forms-2cols-bad.png" alt="form with 2 bad columns"></td>
</tr>
<tr><td><img src="../controls-and-patterns/images/forms-3cols.png" alt="form with 3 columns"></td></tr>
</table>

</div>

### <a name="responsive-layout"></a><span data-ttu-id="80066-163">レスポンシブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="80066-163">Responsive layout</span></span>
<span data-ttu-id="80066-164">ユーザーが任意の入力フィールドを見落とさないように画面やウィンドウ サイズの変更としてフォーム サイズを変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80066-164">Forms should resize as the screen or window size changes, so users don't overlook any input fields.</span></span> <span data-ttu-id="80066-165">詳細については、次を参照してください。[レスポンシブ デザイン手法](../layout/responsive-design.md)します。</span><span class="sxs-lookup"><span data-stu-id="80066-165">For more information, see [responsive design techniques](../layout/responsive-design.md).</span></span> <span data-ttu-id="80066-166">たとえば、画面サイズに関係なく、ビューで、フォームの特定のリージョンを常に保持する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="80066-166">For example, you might want to keep specific regions of the form always in view, no matter the screen size.</span></span>

![フォームのフォーカス](images/forms-focus2.png)

### <a name="tab-stops"></a><span data-ttu-id="80066-168">タブ位置</span><span class="sxs-lookup"><span data-stu-id="80066-168">Tab stops</span></span>
<span data-ttu-id="80066-169">ユーザーがキーボードを使用してコントロールを移動する[タブ ストップ](../input/keyboard-interactions.md#tab-stops)します。</span><span class="sxs-lookup"><span data-stu-id="80066-169">Users can use the keyboard to navigate controls with [tab stops](../input/keyboard-interactions.md#tab-stops).</span></span> <span data-ttu-id="80066-170">既定では、コントロールのタブ オーダーは、XAML で作成された順序を反映します。</span><span class="sxs-lookup"><span data-stu-id="80066-170">By default, the tab order of controls reflects the order in which they are created in XAML.</span></span> <span data-ttu-id="80066-171">既定の動作を上書きするには、変更、 **IsTabStop**または**TabIndex**コントロールのプロパティ。</span><span class="sxs-lookup"><span data-stu-id="80066-171">To override the default behavior, change the **IsTabStop** or **TabIndex** properties of the control.</span></span> 

![フォーム内のコントロールにフォーカスをタブ](images/forms-focus1.png)

## <a name="input-controls"></a><span data-ttu-id="80066-173">入力コントロール</span><span class="sxs-lookup"><span data-stu-id="80066-173">Input controls</span></span>
<span data-ttu-id="80066-174">入力コントロールは、ユーザーがフォームに情報を入力できる UI 要素です。</span><span class="sxs-lookup"><span data-stu-id="80066-174">Input controls are the UI elements that allow users to enter information into forms.</span></span> <span data-ttu-id="80066-175">フォームに追加できるいくつかの一般的なコントロールは、使用する状況に関する情報と、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="80066-175">Some common controls that can be added to forms are listed below, as well as information about when to use them.</span></span>

### <a name="text-input"></a><span data-ttu-id="80066-176">テキスト入力</span><span class="sxs-lookup"><span data-stu-id="80066-176">Text input</span></span>
<span data-ttu-id="80066-177">コントロール</span><span class="sxs-lookup"><span data-stu-id="80066-177">Control</span></span> | <span data-ttu-id="80066-178">使用</span><span class="sxs-lookup"><span data-stu-id="80066-178">Use</span></span> | <span data-ttu-id="80066-179">例</span><span class="sxs-lookup"><span data-stu-id="80066-179">Example</span></span>
 - | - | -
[<span data-ttu-id="80066-180">TextBox</span><span class="sxs-lookup"><span data-stu-id="80066-180">TextBox</span></span>](text-box.md) | <span data-ttu-id="80066-181">1 つまたは複数の行のテキストをキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="80066-181">Capture one or multiple lines of text</span></span> | <span data-ttu-id="80066-182">名前や自由形式の応答、フィードバック</span><span class="sxs-lookup"><span data-stu-id="80066-182">Names, free form responses or feedback</span></span>
[<span data-ttu-id="80066-183">PasswordBox</span><span class="sxs-lookup"><span data-stu-id="80066-183">PasswordBox</span></span>](password-box.md) | <span data-ttu-id="80066-184">文字を表示してプライベート データを収集します。</span><span class="sxs-lookup"><span data-stu-id="80066-184">Collect private data by concealing the characters</span></span> | <span data-ttu-id="80066-185">パスワード、社会保障番号 (SSN)、Pin、クレジット カード情報</span><span class="sxs-lookup"><span data-stu-id="80066-185">Passwords, Social Security Numbers (SSN), PINs, credit card information</span></span> 
[<span data-ttu-id="80066-186">AutoSuggestBox</span><span class="sxs-lookup"><span data-stu-id="80066-186">AutoSuggestBox</span></span>](auto-suggest-box.md) | <span data-ttu-id="80066-187">入力するときに、対応する一連のデータの修正候補の一覧をユーザーに表示します。</span><span class="sxs-lookup"><span data-stu-id="80066-187">Show users a list of suggestions from a corresponding set of data as they type</span></span> | <span data-ttu-id="80066-188">データベースの検索、メールを: 行を前のクエリ</span><span class="sxs-lookup"><span data-stu-id="80066-188">Database search, mail to: line, previous queries</span></span>
[<span data-ttu-id="80066-189">RichEditBox</span><span class="sxs-lookup"><span data-stu-id="80066-189">RichEditBox</span></span>](rich-edit-box.md) | <span data-ttu-id="80066-190">書式設定されたテキスト、ハイパーリンク、およびイメージを持つテキスト ファイルを編集します。</span><span class="sxs-lookup"><span data-stu-id="80066-190">Edit text files with formatted text, hyperlinks, and images</span></span> | <span data-ttu-id="80066-191">ファイルのアップロード、preview、およびアプリでの編集</span><span class="sxs-lookup"><span data-stu-id="80066-191">Upload file, preview, and edit in app</span></span>

### <a name="selection"></a><span data-ttu-id="80066-192">選択</span><span class="sxs-lookup"><span data-stu-id="80066-192">Selection</span></span>
<span data-ttu-id="80066-193">コントロール</span><span class="sxs-lookup"><span data-stu-id="80066-193">Control</span></span> | <span data-ttu-id="80066-194">使用</span><span class="sxs-lookup"><span data-stu-id="80066-194">Use</span></span> | <span data-ttu-id="80066-195">例</span><span class="sxs-lookup"><span data-stu-id="80066-195">Example</span></span>
- | - | - 
| [<span data-ttu-id="80066-196">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="80066-196">CheckBox</span></span>](checkbox.md) | <span data-ttu-id="80066-197">選択するか、1 つまたは複数のアクション アイテムの選択を解除</span><span class="sxs-lookup"><span data-stu-id="80066-197">Select or deselect one or more action items</span></span> | <span data-ttu-id="80066-198">使用条件に同意する、省略可能な項目の追加、該当するものすべてを選択します</span><span class="sxs-lookup"><span data-stu-id="80066-198">Agree to terms and conditions, add optional items, select all that apply</span></span>
[<span data-ttu-id="80066-199">オプション ボタン</span><span class="sxs-lookup"><span data-stu-id="80066-199">RadioButton</span></span>](radio-button.md) | <span data-ttu-id="80066-200">2 つまたは複数の選択肢から 1 つのオプションを選択します。</span><span class="sxs-lookup"><span data-stu-id="80066-200">Select one option from two or more choices</span></span> | <span data-ttu-id="80066-201">メソッドなどの配布の種類を選択します。</span><span class="sxs-lookup"><span data-stu-id="80066-201">Pick type, shipping method, etc.</span></span>
[<span data-ttu-id="80066-202">ToggleSwitch</span><span class="sxs-lookup"><span data-stu-id="80066-202">ToggleSwitch</span></span>](toggles.md) | <span data-ttu-id="80066-203">2 つの相互に排他的なオプションのいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="80066-203">Choose one of two mutually exclusive options</span></span> | <span data-ttu-id="80066-204">オン/オフ</span><span class="sxs-lookup"><span data-stu-id="80066-204">On/off</span></span>

> <span data-ttu-id="80066-205">**注意**:5 つ以上の選択項目がある場合は、リスト コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="80066-205">**Note**: If there are five or more selection items, use a list control.</span></span>

### <a name="lists"></a><span data-ttu-id="80066-206">リスト</span><span class="sxs-lookup"><span data-stu-id="80066-206">Lists</span></span>
<span data-ttu-id="80066-207">コントロール</span><span class="sxs-lookup"><span data-stu-id="80066-207">Control</span></span> | <span data-ttu-id="80066-208">使用</span><span class="sxs-lookup"><span data-stu-id="80066-208">Use</span></span> | <span data-ttu-id="80066-209">例</span><span class="sxs-lookup"><span data-stu-id="80066-209">Example</span></span>
- | - | -
[<span data-ttu-id="80066-210">ComboBox</span><span class="sxs-lookup"><span data-stu-id="80066-210">ComboBox</span></span>](https://docs.microsoft.com/windows/uwp/controls-and-patterns/lists.md#drop-down-lists) | <span data-ttu-id="80066-211">コンパクトな状態で起動して、選択可能な項目の一覧を表示する展開</span><span class="sxs-lookup"><span data-stu-id="80066-211">Start in compact state and expand to show list of selectable items</span></span> | <span data-ttu-id="80066-212">州または国などの項目の長い一覧から選択します</span><span class="sxs-lookup"><span data-stu-id="80066-212">Select from a long list of items, such as states or countries</span></span>
[<span data-ttu-id="80066-213">ListView</span><span class="sxs-lookup"><span data-stu-id="80066-213">ListView</span></span>](https://docs.microsoft.com/windows/uwp/controls-and-patterns/lists#list-views) | <span data-ttu-id="80066-214">項目を分類し、グループ ヘッダーを割り当て、ドラッグし項目を削除、キュレーション コンテンツ、および項目の順序を変更</span><span class="sxs-lookup"><span data-stu-id="80066-214">Categorize items and assign group headers, drag and drop items, curate content, and reorder items</span></span> | <span data-ttu-id="80066-215">順位付けのオプション</span><span class="sxs-lookup"><span data-stu-id="80066-215">Rank options</span></span>
[<span data-ttu-id="80066-216">GridView</span><span class="sxs-lookup"><span data-stu-id="80066-216">GridView</span></span>](https://docs.microsoft.com/windows/uwp/controls-and-patterns/lists#grid-views) | <span data-ttu-id="80066-217">配置し、イメージ ベースのコレクションの参照</span><span class="sxs-lookup"><span data-stu-id="80066-217">Arrange and browse image-based collections</span></span> | <span data-ttu-id="80066-218">画像、色の選択、テーマの表示</span><span class="sxs-lookup"><span data-stu-id="80066-218">Pick a photo, color, display theme</span></span>

### <a name="numeric-input"></a><span data-ttu-id="80066-219">数値入力</span><span class="sxs-lookup"><span data-stu-id="80066-219">Numeric input</span></span>
<span data-ttu-id="80066-220">コントロール</span><span class="sxs-lookup"><span data-stu-id="80066-220">Control</span></span> | <span data-ttu-id="80066-221">使用</span><span class="sxs-lookup"><span data-stu-id="80066-221">Use</span></span> | <span data-ttu-id="80066-222">例</span><span class="sxs-lookup"><span data-stu-id="80066-222">Example</span></span>
- | - | -
[<span data-ttu-id="80066-223">スライダー</span><span class="sxs-lookup"><span data-stu-id="80066-223">Slider</span></span>](slider.md) | <span data-ttu-id="80066-224">連続する数値の範囲から数値を選択します。</span><span class="sxs-lookup"><span data-stu-id="80066-224">Select a number from a range of contiguous numerical values</span></span> | <span data-ttu-id="80066-225">パーセンテージ、ボリューム、再生速度</span><span class="sxs-lookup"><span data-stu-id="80066-225">Percentages, volume, playback speed</span></span>
[<span data-ttu-id="80066-226">評価</span><span class="sxs-lookup"><span data-stu-id="80066-226">Rating</span></span>](rating.md) | <span data-ttu-id="80066-227">星を評価します。</span><span class="sxs-lookup"><span data-stu-id="80066-227">Rate with stars</span></span> | <span data-ttu-id="80066-228">カスタマー フィードバック</span><span class="sxs-lookup"><span data-stu-id="80066-228">Customer feedback</span></span>

### <a name="date-and-time"></a><span data-ttu-id="80066-229">日時</span><span class="sxs-lookup"><span data-stu-id="80066-229">Date and Time</span></span>

<span data-ttu-id="80066-230">コントロール</span><span class="sxs-lookup"><span data-stu-id="80066-230">Control</span></span> | <span data-ttu-id="80066-231">使用</span><span class="sxs-lookup"><span data-stu-id="80066-231">Use</span></span> 
- | - 
[<span data-ttu-id="80066-232">予定表ビュー</span><span class="sxs-lookup"><span data-stu-id="80066-232">CalendarView</span></span>](calendar-view.md) | <span data-ttu-id="80066-233">1 つの日付または、常に表示されるカレンダーから日付の範囲を選択します。</span><span class="sxs-lookup"><span data-stu-id="80066-233">Pick a single date or a range of dates from an always visible calendar</span></span> 
[<span data-ttu-id="80066-234">CalendarDatePicker</span><span class="sxs-lookup"><span data-stu-id="80066-234">CalendarDatePicker</span></span>](calendar-date-picker.md) | <span data-ttu-id="80066-235">コンテキストの予定表から 1 つの日付を選択します。</span><span class="sxs-lookup"><span data-stu-id="80066-235">Pick a single date from a contextual calendar</span></span> 
[<span data-ttu-id="80066-236">DatePicker</span><span class="sxs-lookup"><span data-stu-id="80066-236">DatePicker</span></span>](date-picker.md) | <span data-ttu-id="80066-237">コンテキスト情報が重要でない 1 つのローカライズされた日付を選択します。</span><span class="sxs-lookup"><span data-stu-id="80066-237">Pick a single localized date when contextual info isn't important</span></span>
[<span data-ttu-id="80066-238">TimePicker</span><span class="sxs-lookup"><span data-stu-id="80066-238">TimePicker</span></span>](time-picker.md) | <span data-ttu-id="80066-239">1 つの時間の値を選択します。</span><span class="sxs-lookup"><span data-stu-id="80066-239">Pick a single time value</span></span>

### <a name="additional-controls"></a><span data-ttu-id="80066-240">その他のコントロール</span><span class="sxs-lookup"><span data-stu-id="80066-240">Additional Controls</span></span> 
<span data-ttu-id="80066-241">UWP コントロールの完全な一覧を参照してください。[関数によってコントロールのインデックス](controls-by-function.md)します。</span><span class="sxs-lookup"><span data-stu-id="80066-241">For a complete list of UWP controls, see [index of controls by function](controls-by-function.md).</span></span>

<span data-ttu-id="80066-242">複雑で、カスタムの UI コントロールを参照してください企業から使用可能な UWP リソースなど[Telerik](https://www.telerik.com/)、 [SyncFusion](https://www.syncfusion.com/products/uwp)、 [DevExpress](https://www.devexpress.com/Products/NET/Controls/Win10Apps/)、 [Infragistics](https://www.infragistics.com/products/universal-windows-platform)、 [ComponentOne](https://www.componentone.com/Studio/Platform/UWP)、および[ActiPro](https://www.actiprosoftware.com/products/controls/universal)します。</span><span class="sxs-lookup"><span data-stu-id="80066-242">For more complex and custom UI controls, look at UWP resources available from companies such as [Telerik](https://www.telerik.com/), [SyncFusion](https://www.syncfusion.com/products/uwp), [DevExpress](https://www.devexpress.com/Products/NET/Controls/Win10Apps/), [Infragistics](https://www.infragistics.com/products/universal-windows-platform), [ComponentOne](https://www.componentone.com/Studio/Platform/UWP), and [ActiPro](https://www.actiprosoftware.com/products/controls/universal).</span></span>

## <a name="one-column-form-example"></a><span data-ttu-id="80066-243">フォームの例を 1 つの列</span><span class="sxs-lookup"><span data-stu-id="80066-243">One column form example</span></span>
<span data-ttu-id="80066-244">この例で使用するアクリル[マスター/詳細](master-details.md)[リスト ビュー](lists.md)と[NavigationView](navigationview.md)コントロール。</span><span class="sxs-lookup"><span data-stu-id="80066-244">This example uses an Acrylic [master/detail](master-details.md) [list view](lists.md) and [NavigationView](navigationview.md) control.</span></span>
<span data-ttu-id="80066-245">![別の形式の例のスクリーン ショット](images/FormExample2.png)</span><span class="sxs-lookup"><span data-stu-id="80066-245">![Screenshot of another form example](images/FormExample2.png)</span></span>
```xaml
<StackPanel>
    <TextBlock Text="New Customer" Style="{StaticResource TitleTextBlockStyle}"/>
    <Button Height="100" Width="100" Background="LightGray" Content="Add photo" Margin="0,24" Click="AddPhotoButton_Click"/>
    <TextBox x:Name="Name" Header= "Name" Margin="0,24,0,0" MaxLength="32" Width="400" HorizontalAlignment="Left" InputScope="PersonalFullName"/>
    <TextBox x:Name="PhoneNumber" Header="Phone Number" Margin="0,24,0,0" MaxLength="15" Width="400" HorizontalAlignment="Left" InputScope="TelephoneNumber" />
    <TextBox x:Name="Email" Header="Email" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="EmailNameOrAddress" />
    <TextBox x:Name="Address" Header="Address" PlaceholderText="Address" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="EmailNameOrAddress" />
    <TextBox x:Name="Address2" Margin="0,24,0,0" PlaceholderText="Address 2" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="EmailNameOrAddress" />
    <RelativePanel>
        <TextBox x:Name="City" PlaceholderText="City" Margin="0,24,0,0" MaxLength="50" Width="200" HorizontalAlignment="Left" InputScope="EmailNameOrAddress" />
        <ComboBox x:Name="State" PlaceholderText="State" Margin="24,24,0,0"  Width="100" RelativePanel.RightOf="City">
             <x:String>WA</x:String>
        </ComboBox>
    </RelativePanel>
    <TextBox x:Name="ZipCode" PlaceholderText="Zip Code" Margin="0,24,0,0" MaxLength="6" Width="100" HorizontalAlignment="Left" InputScope="Number" />
    <StackPanel Orientation="Horizontal">
        <Button Content="Save" Margin="0,24" Click="SaveButton_Click"/>
        <Button Content="Cancel" Margin="24" Click="CancelButton_Click"/>
    </StackPanel>  
</StackPanel>
```

## <a name="two-column-form-example"></a><span data-ttu-id="80066-246">フォームの例を 2 つの列</span><span class="sxs-lookup"><span data-stu-id="80066-246">Two column form example</span></span>
<span data-ttu-id="80066-247">この例では、[ピボット](pivot.md)コントロール、[アクリル](../style/acrylic.md)の背景と[CommandBar](app-bars.md)入力コントロールだけでなく。</span><span class="sxs-lookup"><span data-stu-id="80066-247">This example uses the [Pivot](pivot.md) control, [Acrylic](../style/acrylic.md) background, and [CommandBar](app-bars.md) in addition to input controls.</span></span>
<span data-ttu-id="80066-248">![フォームの例のスクリーン ショット](images/FormExample.png)</span><span class="sxs-lookup"><span data-stu-id="80066-248">![Screenshot of form example](images/FormExample.png)</span></span>
```xaml
<Grid>
    <Pivot Background="{ThemeResource SystemControlAccentAcrylicWindowAccentMediumHighBrush}" >
        <Pivot.TitleTemplate>
            <DataTemplate>
                <Grid>
                    <TextBlock Text="Company Name" Style="{ThemeResource HeaderTextBlockStyle}"/>
                </Grid>
            </DataTemplate>
        </Pivot.TitleTemplate>
        <PivotItem Header="Orders" Margin="0"/>    
        <PivotItem Header="Customers" Margin="0">
            <!--Form Example-->
            <Grid Background="White">
                <RelativePanel>
                    <StackPanel x:Name="Customer" Margin="20">
                        <TextBox x:Name="CustomerName" Header= "Customer Name" Margin="0,24,0,0" MaxLength="320" Width="400" HorizontalAlignment="Left" InputScope="PersonalFullName"/>
                        <TextBox x:Name="CustomerPhoneNumber" Header="Phone Number" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="TelephoneNumber" />
                        <TextBox x:Name="Address" Header="Address" PlaceholderText="Address" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="AlphanumericFullWidth" />
                        <TextBox x:Name="Address2" Margin="0,24,0,0" PlaceholderText="Address 2" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="AlphanumericFullWidth" />
                        <RelativePanel>
                            <TextBox x:Name="City" PlaceholderText="City" Margin="0,24,0,0" MaxLength="50" Width="200" HorizontalAlignment="Left" InputScope="Text" />
                            <ComboBox x:Name="State" PlaceholderText="State" Margin="24,24,0,0"  Width="100" RelativePanel.RightOf="City">
                                <x:String>WA</x:String>
                            </ComboBox>
                        </RelativePanel>
                        <TextBox x:Name="ZipCode" PlaceholderText="Zip Code" Margin="0,24,0,0" MaxLength="6" Width="100" HorizontalAlignment="Left" InputScope="Number" />
                    </StackPanel>
                    <StackPanel x:Name="Associate" Margin="20" RelativePanel.RightOf="Customer">
                        <TextBox x:Name="AssociateName" Header= "Associate" Margin="0,24,0,0" MaxLength="320" Width="400" HorizontalAlignment="Left" InputScope="PersonalFullName"/>
                        <TextBox x:Name="AssociatePhoneNumber" Header="Phone Number" Margin="0,24,0,0" MaxLength="50" Width="400" HorizontalAlignment="Left" InputScope="TelephoneNumber" />
                        <DatePicker x:Name="TargetInstallDate" Header="Target install Date" HorizontalAlignment="Left" Margin="0,24,0,0"></DatePicker>
                        <TimePicker x:Name="InstallTime" Header="Install Time" HorizontalAlignment="Left" Margin="0,24,0,0"></TimePicker>
                    </StackPanel>
                </RelativePanel>
            </Grid>
        </PivotItem>
        <PivotItem Header="Invoices"/>
        <PivotItem Header="Stock"/>
        <Pivot.RightHeader>
            <CommandBar OverflowButtonVisibility="Collapsed" Background="Transparent">
                <AppBarButton Icon="Add"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Edit" />
                <AppBarButton Icon="Delete"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Save"/>
            </CommandBar>
        </Pivot.RightHeader>
    </Pivot>
</Grid>
```

## <a name="customer-orders-database-sample"></a><span data-ttu-id="80066-249">顧客注文データベース サンプル</span><span class="sxs-lookup"><span data-stu-id="80066-249">Customer Orders Database Sample</span></span>
<span data-ttu-id="80066-250">![顧客注文データベースのスクリーン ショット](images/customerorderform.png)フォームの入力に接続する方法について、 **Azure**を参照してください、完全に実装されたフォームを参照してください。 データベースにあり、[顧客注文データベース](https://github.com/Microsoft/Windows-appsample-customers-orders-database)アプリのサンプル。</span><span class="sxs-lookup"><span data-stu-id="80066-250">![customer orders database screenshot](images/customerorderform.png) To learn how to connect form input to an **Azure** database and see a fully implemented form, see the [Customers Orders Database](https://github.com/Microsoft/Windows-appsample-customers-orders-database) app sample.</span></span>

## <a name="related-topics"></a><span data-ttu-id="80066-251">関連トピック</span><span class="sxs-lookup"><span data-stu-id="80066-251">Related topics</span></span>
- [<span data-ttu-id="80066-252">入力コントロール</span><span class="sxs-lookup"><span data-stu-id="80066-252">Input controls</span></span>](controls-and-events-intro.md)
- [<span data-ttu-id="80066-253">文字体裁</span><span class="sxs-lookup"><span data-stu-id="80066-253">Typography</span></span>](../style/typography.md)
