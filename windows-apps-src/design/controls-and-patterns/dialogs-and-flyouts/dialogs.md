---
Description: Dialogs and flyouts display transient UI elements that appear when the user requests them or when something happens that requires notification or approval.
title: ダイアログ コントロール
label: Dialogs
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: ad6affd9-a3c0-481f-a237-9a1ecd561be8
pm-contact: yulikl
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 3f3fd2173296c433015fa30b81c0d90e32d2d4b0
ms.sourcegitcommit: a60ab85e9f2f9690e0141050ec3aa51f18ec61ec
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/30/2019
ms.locfileid: "9036944"
---
## <a name="dialog-controls"></a><span data-ttu-id="9429f-103">ダイアログ コントロール</span><span class="sxs-lookup"><span data-stu-id="9429f-103">Dialog controls</span></span>

<span data-ttu-id="9429f-104">ダイアログ コントロールは、アプリのコンテキスト情報を提供するモーダル UI オーバーレイです。</span><span class="sxs-lookup"><span data-stu-id="9429f-104">Dialog controls are modal UI overlays that provide contextual app information.</span></span> <span data-ttu-id="9429f-105">明示的に閉じられるまでアプリ ウィンドウとのやり取りがブロックされています。</span><span class="sxs-lookup"><span data-stu-id="9429f-105">They block interactions with the app window until being explicitly dismissed.</span></span> <span data-ttu-id="9429f-106">多くの場合、ユーザーに何らかの操作を要求します。</span><span class="sxs-lookup"><span data-stu-id="9429f-106">They often request some kind of action from the user.</span></span>

![ダイアログの例](../images/dialogs/dialog_RS2_delete_file.png)


> <span data-ttu-id="9429f-108">**重要な Api**: [ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)</span><span class="sxs-lookup"><span data-stu-id="9429f-108">**Important APIs**: [ContentDialog class](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="9429f-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="9429f-109">Is this the right control?</span></span>

<span data-ttu-id="9429f-110">重要な情報をユーザーに通知したり、アクションが完了する前に確認や追加情報を要求したりするには、ダイアログを使用します。</span><span class="sxs-lookup"><span data-stu-id="9429f-110">Use dialogs to notify users of important information or to request confirmation or additional info before an action can be completed.</span></span>

<span data-ttu-id="9429f-111">使用する場合の推奨事項については、ダイアログとポップアップ (のようなコントロール) を使用する場合に、[ダイアログとポップアップ](index.md)が参照してください。</span><span class="sxs-lookup"><span data-stu-id="9429f-111">For recommendations on when to use a dialog vs. when to use a flyout (a similar control), see [Dialogs and flyouts](index.md).</span></span> 

## <a name="examples"></a><span data-ttu-id="9429f-112">例</span><span class="sxs-lookup"><span data-stu-id="9429f-112">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="9429f-113">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="9429f-113">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="../images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="9429f-114"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> または <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="9429f-114">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> or <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> in action.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="9429f-115">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="9429f-115">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery"><span data-ttu-id="9429f-116">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="9429f-116">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="general-guidelines"></a><span data-ttu-id="9429f-117">一般的なガイドライン</span><span class="sxs-lookup"><span data-stu-id="9429f-117">General guidelines</span></span>

-   <span data-ttu-id="9429f-118">ダイアログ内のテキストの 1 行目で、問題やユーザーの目的 (実行する内容) を明確に示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-118">Clearly identify the issue or the user's objective in the first line of the dialog's text.</span></span>
-   <span data-ttu-id="9429f-119">ダイアログのタイトルは主な説明で、省略可能です。</span><span class="sxs-lookup"><span data-stu-id="9429f-119">The dialog title is the main instruction and is optional.</span></span>
    -   <span data-ttu-id="9429f-120">簡潔なタイトルを使って、ユーザーがそのダイアログで行う必要がある操作を説明します。</span><span class="sxs-lookup"><span data-stu-id="9429f-120">Use a short title to explain what people need to do with the dialog.</span></span>
    -   <span data-ttu-id="9429f-121">ダイアログを使って、簡単なメッセージ、エラー、または質問を表示する場合は、タイトルを省略することもできます。</span><span class="sxs-lookup"><span data-stu-id="9429f-121">If you're using the dialog to deliver a simple message, error or question, you can optionally omit the title.</span></span> <span data-ttu-id="9429f-122">主な情報はコンテンツのテキストを使って伝えます。</span><span class="sxs-lookup"><span data-stu-id="9429f-122">Rely on the content text to deliver that core information.</span></span>
    -   <span data-ttu-id="9429f-123">タイトルは、ボタンの選択に直接関連するものにします。</span><span class="sxs-lookup"><span data-stu-id="9429f-123">Make sure that the title relates directly to the button choices.</span></span>
-   <span data-ttu-id="9429f-124">ダイアログ コンテンツには説明のテキストを含め、これは必須です。</span><span class="sxs-lookup"><span data-stu-id="9429f-124">The dialog content contains the descriptive text and is required.</span></span>
    -   <span data-ttu-id="9429f-125">メッセージ、エラー、または操作をブロック質問をできる限り簡潔に示します。</span><span class="sxs-lookup"><span data-stu-id="9429f-125">Present the message, error, or blocking question as simply as possible.</span></span>
    -   <span data-ttu-id="9429f-126">ダイアログ タイトルを使う場合は、コンテンツ領域を詳しい情報の提示や用語の定義に使います。</span><span class="sxs-lookup"><span data-stu-id="9429f-126">If a dialog title is used, use the content area to provide more detail or define terminology.</span></span> <span data-ttu-id="9429f-127">タイトルの言葉づかいを変えただけの文を繰り返さないようにします。</span><span class="sxs-lookup"><span data-stu-id="9429f-127">Don't repeat the title with slightly different wording.</span></span>
-   <span data-ttu-id="9429f-128">少なくとも 1 つのダイアログ ボタンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-128">At least one dialog button must appear.</span></span>
    -   <span data-ttu-id="9429f-129">ダイアログに、安全で非破壊的なアクションに対応する "OK"、"閉じる"、"キャンセル" などのボタンが少なくとも 1 つのあるようにします。</span><span class="sxs-lookup"><span data-stu-id="9429f-129">Ensure that your dialog has at least one button corresponding to a safe, nondestructive action like "Got it!", "Close", or "Cancel".</span></span> <span data-ttu-id="9429f-130">このボタンを追加するには、CloseButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="9429f-130">Use the CloseButton API to add this button.</span></span>
    -   <span data-ttu-id="9429f-131">ボタンのテキストには、主な説明またはコンテンツに対する具体的な応答を使用します。</span><span class="sxs-lookup"><span data-stu-id="9429f-131">Use specific responses to the main instruction or content as button text.</span></span> <span data-ttu-id="9429f-132">たとえば、主な説明が "使っているコンピューターへの AppName からのアクセスを許可しますか?" の場合、"許可" ボタンと "ブロック" ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="9429f-132">An example is, "Do you want to allow AppName to access your location?", followed by "Allow" and "Block" buttons.</span></span> <span data-ttu-id="9429f-133">具体的な応答の言葉はすばやく理解できるので、効率的に判断できます。</span><span class="sxs-lookup"><span data-stu-id="9429f-133">Specific responses can be understood more quickly, resulting in efficient decision making.</span></span>
    - <span data-ttu-id="9429f-134">アクション ボタンのテキストは簡潔にします。</span><span class="sxs-lookup"><span data-stu-id="9429f-134">Ensure that the text of the action buttons is concise.</span></span> <span data-ttu-id="9429f-135">短い文字列にすると、ユーザーがすばやく確実に選択できるようになります。</span><span class="sxs-lookup"><span data-stu-id="9429f-135">Short strings enable the user to make a choice quickly and confidently.</span></span>
    - <span data-ttu-id="9429f-136">安全で非破壊的なアクションに加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。</span><span class="sxs-lookup"><span data-stu-id="9429f-136">In addition to the safe, nondestructive action, you may optionally present the user with one or two action buttons related to the main instruction.</span></span> <span data-ttu-id="9429f-137">このような "処理実行" アクション ボタンでは、ダイアログの重要な点を確認します。</span><span class="sxs-lookup"><span data-stu-id="9429f-137">These "do it" action buttons confirm the main point of the dialog.</span></span> <span data-ttu-id="9429f-138">このような "処理実行" アクションを追加するには、PrimaryButton API と SecondaryButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="9429f-138">Use the PrimaryButton and SecondaryButton APIs to add these "do it" actions.</span></span>
    - <span data-ttu-id="9429f-139">"処理実行" アクション ボタンは一番左のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="9429f-139">The "do it" action button(s) should appears as the leftmost buttons.</span></span> <span data-ttu-id="9429f-140">安全で非破壊的なアクションは一番右のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="9429f-140">The safe, nondestructive action should appear as the rightmost button.</span></span>
    - <span data-ttu-id="9429f-141">必要に応じて、ダイアログの 3 つのボタンのうちの 1 つを既定のボタンとして区別できます。</span><span class="sxs-lookup"><span data-stu-id="9429f-141">You may optionally choose to differentiate one of the three buttons as the dialog's default button.</span></span> <span data-ttu-id="9429f-142">ボタンの 1 つを区別するには DefaultButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="9429f-142">Use the DefaultButton API to differentiate one of the buttons.</span></span>  
-   <span data-ttu-id="9429f-143">パスワード フィールドの検証エラーなど、ページの特定の場所に関連するエラーでは、ダイアログを使わずに、アプリのキャンバス自体を使ってインライン エラーを表示します。</span><span class="sxs-lookup"><span data-stu-id="9429f-143">Don't use dialogs for errors that are contextual to a specific place on the page, such as validation errors (in password fields, for example), use the app's canvas itself to show inline errors.</span></span>
- <span data-ttu-id="9429f-144">ダイアログ エクスペリエンスを構築するには、[ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)を使います。</span><span class="sxs-lookup"><span data-stu-id="9429f-144">Use the [ContentDialog class](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog) to build your dialog experience.</span></span> <span data-ttu-id="9429f-145">非推奨の MessageDialog API は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="9429f-145">Don't use the deprecated MessageDialog API.</span></span>

## <a name="how-to-create-a-dialog"></a><span data-ttu-id="9429f-146">ダイアログを作成する方法</span><span class="sxs-lookup"><span data-stu-id="9429f-146">How to create a dialog</span></span>
<span data-ttu-id="9429f-147">ダイアログ ボックスを作成するには、[ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)を使用します。</span><span class="sxs-lookup"><span data-stu-id="9429f-147">To create a dialog, you use the [ContentDialog class](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog).</span></span> <span data-ttu-id="9429f-148">ダイアログはコードまたはマークアップで作成できます。</span><span class="sxs-lookup"><span data-stu-id="9429f-148">You can create a dialog in code or markup.</span></span> <span data-ttu-id="9429f-149">通常は UI 要素を XAML で定義する方が容易ですが、単純なダイアログの場合には、コードを記述する方が実際には容易です。</span><span class="sxs-lookup"><span data-stu-id="9429f-149">Although its usually easier to define UI elements in XAML, in the case of a simple dialog, it's actually easier to just use code.</span></span> <span data-ttu-id="9429f-150">この例では、ダイアログを作成して、ユーザーに WiFi 接続がないことの通知を行い、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync)メソッドを使ってそれを表示しています。</span><span class="sxs-lookup"><span data-stu-id="9429f-150">This example creates a dialog to notify the user that there's no WiFi connection, and then uses the [ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method to display it.</span></span>

```csharp
private async void DisplayNoWifiDialog()
{
    ContentDialog noWifiDialog = new ContentDialog
    {
        Title = "No wifi connection",
        Content = "Check your connection and try again.",
        CloseButtonText = "Ok"
    };

    ContentDialogResult result = await noWifiDialog.ShowAsync();
}
```

<span data-ttu-id="9429f-151">ユーザーがダイアログのボタンをクリックすると、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync)メソッドは [ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) を返して、ユーザーがクリックしたボタンを伝えます。</span><span class="sxs-lookup"><span data-stu-id="9429f-151">When the user clicks a dialog button, the [ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method returns a [ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) to let you know which button the user clicks.</span></span>

<span data-ttu-id="9429f-152">この例でのダイアログは、質問を行い、[ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) の戻り値を使用してユーザーの応答を確認します。</span><span class="sxs-lookup"><span data-stu-id="9429f-152">The dialog in this example asks a question and uses the returned [ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) to determine the user's response.</span></span>

```csharp
private async void DisplayDeleteFileDialog()
{
    ContentDialog deleteFileDialog = new ContentDialog
    {
        Title = "Delete file permanently?",
        Content = "If you delete this file, you won't be able to recover it. Do you want to delete it?",
        PrimaryButtonText = "Delete",
        CloseButtonText = "Cancel"
    };

    ContentDialogResult result = await deleteFileDialog.ShowAsync();

    // Delete the file if the user clicked the primary button.
    /// Otherwise, do nothing.
    if (result == ContentDialogResult.Primary)
    {
        // Delete the file.
    }
    else
    {
        // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
        // Do nothing.
    }
}
```

## <a name="provide-a-safe-action"></a><span data-ttu-id="9429f-153">安全なアクションを提供します。</span><span class="sxs-lookup"><span data-stu-id="9429f-153">Provide a safe action</span></span>
<span data-ttu-id="9429f-154">ダイアログでユーザー操作がブロックされたとき、ユーザーがダイアログを閉じる主な方法はボタンであるため、ダイアログに "閉じる" や "OK" などの安全で非破壊的なボタンが少なくとも 1 つは含まれるようにします。</span><span class="sxs-lookup"><span data-stu-id="9429f-154">Because dialogs block user interaction, and because buttons are the primary mechanism for users to dismiss the dialog, ensure that your dialog contains at least one "safe" and nondestructive button such as "Close" or "Got it!".</span></span> **<span data-ttu-id="9429f-155">すべてのダイアログには、ダイアログを閉じるための少なくとも 1 つの安全なアクション ボタンを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-155">All dialogs should contain at least one safe action button to close the dialog.</span></span>** <span data-ttu-id="9429f-156">これにより、ユーザーはアクションを実行することなく安心してダイアログを閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="9429f-156">This ensures that the user can confidently close the dialog without performing an action.</span></span><br>![ボタンを 1 つ備えたダイアログ](../images/dialogs/dialog_RS2_one_button.png)

```csharp
private async void DisplayNoWifiDialog()
{
    ContentDialog noWifiDialog = new ContentDialog
    {
        Title = "No wifi connection",
        Content = "Check your connection and try again.",
        CloseButtonText = "Ok"
    };

    ContentDialogResult result = await noWifiDialog.ShowAsync();
}
```

<span data-ttu-id="9429f-158">ダイアログにブロック質問を表示する場合、ダイアログには質問に関連するアクション ボタンを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-158">When dialogs are used to display a blocking question, your dialog should present the user with action buttons related to the question.</span></span> <span data-ttu-id="9429f-159">安全で非破壊的なボタンは、1 つまたは 2 つの "処理実行" アクション ボタンを伴っている場合があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-159">The "safe" and nondestructive button may be accompanied by one or two "do it" action buttons.</span></span> <span data-ttu-id="9429f-160">複数のオプションを表示するときは、提示されている質問に関して "処理実行" アクションと安全な "処理非実行" アクションをボタンが明確に示すようにします。</span><span class="sxs-lookup"><span data-stu-id="9429f-160">When presenting the user with multiple options, ensure that the buttons clearly explain the "do it" and safe/"don’t do it" actions related to the question proposed.</span></span>

![ボタンを 2 つ備えたダイアログ](../images/dialogs/dialog_RS2_two_button.png)

```csharp
private async void DisplayLocationPromptDialog()
{
    ContentDialog locationPromptDialog = new ContentDialog
    {
        Title = "Allow AppName to access your location?",
        Content = "AppName uses this information to help you find places, connect with friends, and more.",
        CloseButtonText = "Block",
        PrimaryButtonText = "Allow"
    };

    ContentDialogResult result = await locationPromptDialog.ShowAsync();
}
```

<span data-ttu-id="9429f-162">ボタンを 3 つ備えたダイアログは、2 つの "処理実行" アクションと 1 つの "処理非実行" アクションを表示するときに使用します。</span><span class="sxs-lookup"><span data-stu-id="9429f-162">Three button dialogs are used when you present the user with two "do it" actions and a "don’t do it" action.</span></span> <span data-ttu-id="9429f-163">ボタンを 3 つ備えたダイアログは、セカンダリ アクションと安全な "閉じる" アクションを明確に区別して慎重に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-163">Three button dialogs should be used sparingly with clear distinctions between the secondary action and the safe/close action.</span></span>

![ボタンを 3 つ備えたダイアログ](../images/dialogs/dialog_RS2_three_button.png)

```csharp
private async void DisplaySubscribeDialog()
{
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

## <a name="the-three-dialog-buttons"></a><span data-ttu-id="9429f-165">ダイアログの 3 つのボタン</span><span class="sxs-lookup"><span data-stu-id="9429f-165">The three dialog buttons</span></span>
<span data-ttu-id="9429f-166">ContentDialog には、ダイアログ エクスペリエンスを構築するために使用できる、3 種類のボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="9429f-166">ContentDialog has three different types of buttons that you can use to build a dialog experience.</span></span>

- <span data-ttu-id="9429f-167">**CloseButton** - 必須 - ユーザーがダイアログを終了できる安全で非破壊的なアクションを表します。</span><span class="sxs-lookup"><span data-stu-id="9429f-167">**CloseButton** - Required - Represents the safe, nondestructive action that enables the user to exit the dialog.</span></span> <span data-ttu-id="9429f-168">一番右のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="9429f-168">Appears as the rightmost button.</span></span>
- <span data-ttu-id="9429f-169">**PrimaryButton** - 省略可能 - 1 つ目の "処理実行" アクションを表します。</span><span class="sxs-lookup"><span data-stu-id="9429f-169">**PrimaryButton** - Optional - Represents the first "do it" action.</span></span> <span data-ttu-id="9429f-170">一番左のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="9429f-170">Appears as the leftmost button.</span></span>
- <span data-ttu-id="9429f-171">**SecondaryButton** - 省略可能 - 2 つ目の "処理実行" アクションを表します。</span><span class="sxs-lookup"><span data-stu-id="9429f-171">**SecondaryButton** - Optional - Represents the second "do it" action.</span></span> <span data-ttu-id="9429f-172">中央のボタンとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="9429f-172">Appears as the middle button.</span></span>

<span data-ttu-id="9429f-173">組み込みのボタンを使用すると、ボタンが適切な位置に表示され、キーボード イベントに正しく反応し、コマンド領域がスクリーン キーボード使用時にも表示されたままになり、ダイアログの外観が他のダイアログと一貫性のあるものになります。</span><span class="sxs-lookup"><span data-stu-id="9429f-173">Using the built-in buttons will position the buttons appropriately, ensure that they correctly respond to keyboard events, ensure that the command area remains visible even when the on-screen keyboard is up, and will make the dialog look consistent with other dialogs.</span></span>

### <a name="closebutton"></a><span data-ttu-id="9429f-174">CloseButton</span><span class="sxs-lookup"><span data-stu-id="9429f-174">CloseButton</span></span>
<span data-ttu-id="9429f-175">すべてのダイアログには、ユーザーが安心してダイアログを終了できる、安全で非破壊的なアクション ボタンが含まれる必要があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-175">Every dialog should contain a safe, nondestructive action button that enables the user to confidently exit the dialog.</span></span>

<span data-ttu-id="9429f-176">このボタンを作成するには、ContentDialog.CloseButton API を使用します。</span><span class="sxs-lookup"><span data-stu-id="9429f-176">Use the ContentDialog.CloseButton API to create this button.</span></span> <span data-ttu-id="9429f-177">これにより、マウス、キーボード、タッチ、およびゲームパッドを含むすべての入力に対して、適切なユーザー エクスペリエンスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="9429f-177">This allows you to create the right user experience for all inputs including mouse, keyboard, touch, and gamepad.</span></span> <span data-ttu-id="9429f-178">このエクスペリエンスは以下の場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="9429f-178">This experience will happen when:</span></span>
<ol>
    <li><span data-ttu-id="9429f-179">ユーザーが CloseButton をクリックまたはタップする</span><span class="sxs-lookup"><span data-stu-id="9429f-179">The user clicks or taps on the CloseButton</span></span> </li>
    <li><span data-ttu-id="9429f-180">ユーザーがシステムの戻るボタンを押す</span><span class="sxs-lookup"><span data-stu-id="9429f-180">The user presses the system back button</span></span> </li>
    <li><span data-ttu-id="9429f-181">ユーザーがキーボードの Esc キーを押す</span><span class="sxs-lookup"><span data-stu-id="9429f-181">The user presses the ESC button on the keyboard</span></span> </li>
    <li><span data-ttu-id="9429f-182">ユーザーがゲームパッドの B を押す</span><span class="sxs-lookup"><span data-stu-id="9429f-182">The user presses Gamepad B</span></span> </li>
</ol>

<span data-ttu-id="9429f-183">ユーザーがダイアログのボタンをクリックすると、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは [ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) を返して、ユーザーがクリックしたボタンを伝えます。</span><span class="sxs-lookup"><span data-stu-id="9429f-183">When the user clicks a dialog button, the [ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method returns a [ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) to let you know which button the user clicks.</span></span> <span data-ttu-id="9429f-184">CloseButton を押すと ContentDialogResult.None が返されます。</span><span class="sxs-lookup"><span data-stu-id="9429f-184">Pressing on the CloseButton returns ContentDialogResult.None.</span></span>

### <a name="primarybutton-and-secondarybutton"></a><span data-ttu-id="9429f-185">PrimaryButton と SecondaryButton</span><span class="sxs-lookup"><span data-stu-id="9429f-185">PrimaryButton and SecondaryButton</span></span>
<span data-ttu-id="9429f-186">CloseButton に加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。</span><span class="sxs-lookup"><span data-stu-id="9429f-186">In addition to the CloseButton, you may optionally present the user with one or two action buttons related to the main instruction.</span></span>
<span data-ttu-id="9429f-187">1 つ目の "処理実行" アクションには PrimaryButton、2 つ目の "処理実行" アクションには SecondaryButton を使います。</span><span class="sxs-lookup"><span data-stu-id="9429f-187">Leverage PrimaryButton for the first "do it" action, and SecondaryButton for the second "do it" action.</span></span> <span data-ttu-id="9429f-188">ボタンを 3 つ備えたダイアログでは、通常、PrimaryButton は肯定的な "処理実行" アクションを示し、SecondaryButton は中立的または二次的な "処理実行" アクションを示します。</span><span class="sxs-lookup"><span data-stu-id="9429f-188">In three-button dialogs, the PrimaryButton generally represents the affirmative "do it" action, while the SecondaryButton generally represents a neutral or secondary "do it" action.</span></span>
<span data-ttu-id="9429f-189">たとえば、ユーザーがアプリからサービスに登録するように求められる場合があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-189">For example, an app may prompt the user to subscribe to a service.</span></span> <span data-ttu-id="9429f-190">肯定的な "処理実行" アクションとして PrimaryButton は "サブスクライブする" というテキストを表示し、中立的な "処理実行" アクションとして SecondaryButton は "試してみる" というテキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="9429f-190">The PrimaryButton as the affirmative "do it" action would host the Subscribe text, while the SecondaryButton as the neutral "do it" action would host the Try it text.</span></span> <span data-ttu-id="9429f-191">CloseButton は、ユーザーがいずれのアクションも実行せずにキャンセルできるようにします。</span><span class="sxs-lookup"><span data-stu-id="9429f-191">The CloseButton would allow the user to cancel without performing either action.</span></span>

<span data-ttu-id="9429f-192">ユーザーが PrimaryButton をクリックすると、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは ContentDialogResult.Primary を返します。</span><span class="sxs-lookup"><span data-stu-id="9429f-192">When the user clicks on the PrimaryButton, the [ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method returns ContentDialogResult.Primary.</span></span>
<span data-ttu-id="9429f-193">ユーザーが SecondaryButton をクリックすると、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは ContentDialogResult.Secondary を返します。</span><span class="sxs-lookup"><span data-stu-id="9429f-193">When the user clicks on the SecondaryButton, the [ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) method returns ContentDialogResult.Secondary.</span></span>

![ボタンを 3 つ備えたダイアログ](../images/dialogs/dialog_RS2_three_button.png)

### <a name="defaultbutton"></a><span data-ttu-id="9429f-195">DefaultButton</span><span class="sxs-lookup"><span data-stu-id="9429f-195">DefaultButton</span></span>
<span data-ttu-id="9429f-196">必要に応じて、3 つのボタンのうちの 1 つを既定のボタンとして区別できます。</span><span class="sxs-lookup"><span data-stu-id="9429f-196">You may optionally choose to differentiate one of the three buttons as the default button.</span></span> <span data-ttu-id="9429f-197">既定のボタンを指定すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="9429f-197">Specifying the default button causes the following to happen:</span></span>
- <span data-ttu-id="9429f-198">ボタンにアクセント ボタンとして視覚的な効果が適用される</span><span class="sxs-lookup"><span data-stu-id="9429f-198">The button receives the Accent Button visual treatment</span></span>
- <span data-ttu-id="9429f-199">ボタンが Enter キーに自動的に応答する</span><span class="sxs-lookup"><span data-stu-id="9429f-199">The button will respond to the ENTER key automatically</span></span>
    - <span data-ttu-id="9429f-200">ユーザーがキーボードの Enter キーを押すと、既定のボタンに関連付けられているクリック ハンドラーが起動し、ContentDialogResult は既定のボタンに関連付けられている値を返す</span><span class="sxs-lookup"><span data-stu-id="9429f-200">When the user presses the ENTER key on the keyboard, the click handler associated with the Default Button will fire and the ContentDialogResult will return the value associated with the Default Button</span></span>
    - <span data-ttu-id="9429f-201">ユーザーが Enter を処理するコントロールにキーボード フォーカスを置いている場合、既定のボタンは Enter が押されても反応しない</span><span class="sxs-lookup"><span data-stu-id="9429f-201">If the user has placed Keyboard Focus on a control that handles ENTER, the Default Button will not respond to ENTER presses</span></span>
- <span data-ttu-id="9429f-202">ダイアログのコンテンツにフォーカス可能な UI が含まれていない限り、ダイアログが開くとボタンが自動的にフォーカスされる</span><span class="sxs-lookup"><span data-stu-id="9429f-202">The button will receive focus automatically when the Dialog is opened unless the dialog’s content contains focusable UI</span></span>

<span data-ttu-id="9429f-203">既定のボタンを指定するには、ContentDialog.DefaultButton プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="9429f-203">Use the ContentDialog.DefaultButton property to indicate the default button.</span></span> <span data-ttu-id="9429f-204">既定では、既定のボタンは設定されていません。</span><span class="sxs-lookup"><span data-stu-id="9429f-204">By default, no default button is set.</span></span>

![既定のボタンを含むボタンを 3 つ備えたダイアログ](../images/dialogs/dialog_RS2_three_button_default.png)

```csharp
private async void DisplaySubscribeDialog()
{
    ContentDialog subscribeDialog = new ContentDialog
    {
        Title = "Subscribe to App Service?",
        Content = "Listen, watch, and play in high definition for only $9.99/month. Free to try, cancel anytime.",
        CloseButtonText = "Not Now",
        PrimaryButtonText = "Subscribe",
        SecondaryButtonText = "Try it",
        DefaultButton = ContentDialogButton.Primary
    };

    ContentDialogResult result = await subscribeDialog.ShowAsync();
}
```

## <a name="confirmation-dialogs-okcancel"></a><span data-ttu-id="9429f-206">確認ダイアログ ([OK]/[キャンセル])</span><span class="sxs-lookup"><span data-stu-id="9429f-206">Confirmation dialogs (OK/Cancel)</span></span>
<span data-ttu-id="9429f-207">確認ダイアログ ボックスにより、ユーザーはアクションを実行するかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="9429f-207">A confirmation dialog gives users the chance to confirm that they want to perform an action.</span></span> <span data-ttu-id="9429f-208">アクションを確認するか、キャンセルを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="9429f-208">They can affirm the action, or choose to cancel.</span></span>  
<span data-ttu-id="9429f-209">一般的な確認ダイアログ ボックスには、確認 ([OK]) ボタンと [キャンセル] ボタンの 2 つのボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="9429f-209">A typical confirmation dialog has two buttons: an affirmation ("OK") button and a cancel button.</span></span>  

<ul>
    <li>
        <p><span data-ttu-id="9429f-210">一般的に、確認ボタンは左側 (プライマリ ボタン) にあり、[キャンセル] ボタン (セカンダリ ボタン) は右側にあります。</span><span class="sxs-lookup"><span data-stu-id="9429f-210">In general, the affirmation button should be on the left (the primary button) and the cancel button (the secondary button) should be on the right.</span></span></p>
        <img alt="An OK/cancel dialog" src="../images/dialogs/dialog_RS2_delete_file.png" />
    </li>
    <li><span data-ttu-id="9429f-211">一般的な推奨事項のセクションで説明したように、テキストを指定したボタンを使って、主な説明またはコンテンツに対する具体的な応答を示します。</span><span class="sxs-lookup"><span data-stu-id="9429f-211">As noted in the general recommendations section, use buttons with text that identifies specific responses to the main instruction or content.</span></span>
    </li>
</ul>

> <span data-ttu-id="9429f-212">一部のプラットフォームでは、左側ではなく、右側に確認ボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="9429f-212">Some platforms put the affirmation button on the right instead of the left.</span></span> <span data-ttu-id="9429f-213">それでは、左側に確認ボタンを配置するのはなぜでしょうか。</span><span class="sxs-lookup"><span data-stu-id="9429f-213">So why do we recommend putting it on the left?</span></span>  <span data-ttu-id="9429f-214">ユーザーの大部分が右利きであり、右手でスマートフォンを保持すると想定した場合、実際に確認ボタンが左側にある方がボタンを押しやすくなります。これは、ボタンがユーザーの親指が描く円弧上にある可能性が高くなるためです。画面の右側にボタンがある場合、ユーザーは親指を内側に引いて操作しにくい位置に移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9429f-214">If you assume that the majority of users are right-handed and they hold their phone with that hand, it's actually more comfortable to press the affirmation button when it's on the left, because the button is more likely to be within the user's thumb-arc. Buttons on the right-side of the screen require the user to pull their thumb inward into a less-comfortable position.</span></span>





## <a name="get-the-sample-code"></a><span data-ttu-id="9429f-215">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="9429f-215">Get the sample code</span></span>

- <span data-ttu-id="9429f-216">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="9429f-216">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="9429f-217">関連記事</span><span class="sxs-lookup"><span data-stu-id="9429f-217">Related articles</span></span>
- [<span data-ttu-id="9429f-218">ヒント</span><span class="sxs-lookup"><span data-stu-id="9429f-218">Tooltips</span></span>](../tooltips.md)
- [<span data-ttu-id="9429f-219">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="9429f-219">Menus and context menu</span></span>](../menus.md)
- [<span data-ttu-id="9429f-220">Flyout クラス</span><span class="sxs-lookup"><span data-stu-id="9429f-220">Flyout class</span></span>](/uwp/api/Windows.UI.Xaml.Controls.Flyout)
- [<span data-ttu-id="9429f-221">ContentDialog クラス</span><span class="sxs-lookup"><span data-stu-id="9429f-221">ContentDialog class</span></span>](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)
