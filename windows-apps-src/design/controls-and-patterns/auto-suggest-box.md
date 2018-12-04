---
Description: A text entry box that provides suggestions as the user types.
title: 自動提案ボックスのガイドライン
ms.assetid: 1F608477-F795-4F33-92FA-F200CC243B6B
dev.assetid: 54F8DB8A-120A-4D79-8B5A-9315A3764C2F
label: Auto-suggest box
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: b68b3480ac81a445551a070eaf0a1454ff22a9e7
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8483967"
---
# <a name="auto-suggest-box"></a><span data-ttu-id="ed488-103">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="ed488-103">Auto-suggest box</span></span>

<span data-ttu-id="ed488-104">AutoSuggestBox を使って、ユーザーが入力と同時に選べる候補リストを表示します。</span><span class="sxs-lookup"><span data-stu-id="ed488-104">Use an AutoSuggestBox to provide a list of suggestions for a user to select from as they type.</span></span>

> <span data-ttu-id="ed488-105">**重要な API**: [AutoSuggestBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)、[TextChanged イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx)、[SuggestionChose イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx)、[QuerySubmitted イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx)</span><span class="sxs-lookup"><span data-stu-id="ed488-105">**Important APIs**: [AutoSuggestBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx), [TextChanged event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx), [SuggestionChose event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx), [QuerySubmitted event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx)</span></span>

![自動提案ボックス](images/controls/auto-suggest-box-open.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="ed488-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="ed488-107">Is this the right control?</span></span>

<span data-ttu-id="ed488-108">候補の一覧を使ってテキストを検索できる、シンプルでカスタマイズ可能なコントロールが必要な場合は、自動提案ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="ed488-108">If you'd like a simple, customizable control that allows text search with a list of suggestions, then choose an auto-suggest box.</span></span>

<span data-ttu-id="ed488-109">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed488-109">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="ed488-110">例</span><span class="sxs-lookup"><span data-stu-id="ed488-110">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="ed488-111">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="ed488-111">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="ed488-112"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/AutoSuggestBox">アプリを開き、AutoSuggestBox の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="ed488-112">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/AutoSuggestBox">open the app and see the AutoSuggestBox in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="ed488-113">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="ed488-113">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="ed488-114">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="ed488-114">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="ed488-115">Groove ミュージック アプリの自動提案ボックス。</span><span class="sxs-lookup"><span data-stu-id="ed488-115">An auto suggest box in the Groove Music app.</span></span>

![Groove ミュージック アプリの自動提案ボックス](images/control-examples/auto-suggest-box-groove.png)

## <a name="anatomy"></a><span data-ttu-id="ed488-117">構造</span><span class="sxs-lookup"><span data-stu-id="ed488-117">Anatomy</span></span>
<span data-ttu-id="ed488-118">自動提案ボックスのエントリ ポイントは、オプションのヘッダーとオプションのヒント テキスト付きのテキスト ボックスで構成されます。</span><span class="sxs-lookup"><span data-stu-id="ed488-118">The entry point for the auto-suggest box consists of an optional header and a text box with optional hint text:</span></span>

![自動提案コントロールのエントリ ポイントの例](images/controls_autosuggest_entrypoint.png)

<span data-ttu-id="ed488-120">自動提案結果の一覧には、ユーザーがテキストの入力を開始すると自動的に内容が入力されます。</span><span class="sxs-lookup"><span data-stu-id="ed488-120">The auto-suggest results list populates automatically once the user starts to enter text.</span></span> <span data-ttu-id="ed488-121">結果の一覧は、テキスト入力ボックスの上または下に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed488-121">The results list can appear above or below the text entry box.</span></span> <span data-ttu-id="ed488-122">[すべてクリア] ボタンも表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed488-122">A "clear all" button appears:</span></span>

![展開された自動提案コントロールの例](images/controls_autosuggest_expanded01.png)

## <a name="create-an-auto-suggest-box"></a><span data-ttu-id="ed488-124">自動提案ボックスの作成</span><span class="sxs-lookup"><span data-stu-id="ed488-124">Create an auto-suggest box</span></span>

<span data-ttu-id="ed488-125">AutoSuggestBox を使うには、3 つのユーザー操作に応答する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed488-125">To use an AutoSuggestBox, you need to respond to 3 user actions.</span></span>

- <span data-ttu-id="ed488-126">テキストの変更 - ユーザーがテキストを入力したときに、候補リストを更新します。</span><span class="sxs-lookup"><span data-stu-id="ed488-126">Text changed - When the user enters text, update the suggestion list.</span></span>
- <span data-ttu-id="ed488-127">候補の選択 - ユーザーが候補リストで候補を選んだときに、テキスト ボックスを更新します。</span><span class="sxs-lookup"><span data-stu-id="ed488-127">Suggestion chosen - When the user chooses a suggestion in the suggestion list, update the text box.</span></span>
- <span data-ttu-id="ed488-128">クエリの送信 - ユーザーがクエリを送信したときに、クエリの結果を表示します。</span><span class="sxs-lookup"><span data-stu-id="ed488-128">Query submitted - When the user submits a query, show the query results.</span></span>

### <a name="text-changed"></a><span data-ttu-id="ed488-129">テキストの変更</span><span class="sxs-lookup"><span data-stu-id="ed488-129">Text changed</span></span>

<span data-ttu-id="ed488-130">テキスト ボックスの内容が更新されるたびに、[TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="ed488-130">The [TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx) event occurs whenever the content of the text box is updated.</span></span> <span data-ttu-id="ed488-131">イベント引数 [Reason](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxtextchangedeventargs.reason.aspx) プロパティを使って、変更がユーザー入力によって生じたものかどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="ed488-131">Use the event args [Reason](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxtextchangedeventargs.reason.aspx) property to determine whether the change was due to user input.</span></span> <span data-ttu-id="ed488-132">変更の理由が **UserInput** の場合、入力に基づいてデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="ed488-132">If the change reason is **UserInput**, filter your data based on the input.</span></span> <span data-ttu-id="ed488-133">次に、フィルター処理されたデータを AutoSuggestBox の [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) に設定し、候補リストを更新します。</span><span class="sxs-lookup"><span data-stu-id="ed488-133">Then, set the filtered data as the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) of the AutoSuggestBox to update the suggestion list.</span></span>

<span data-ttu-id="ed488-134">候補リストでの項目の表示方法を制御するには、[DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) または [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="ed488-134">To control how items are displayed in the suggestion list, you can use [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) or [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx).</span></span>

- <span data-ttu-id="ed488-135">データ項目の単一のプロパティのテキストを表示するには、DisplayMemberPath プロパティを設定し、候補リストに表示するオブジェクトのプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="ed488-135">To display the text of a single property of your data item, set the DisplayMemberPath property to choose which property from your object to display in the suggestion list.</span></span>
- <span data-ttu-id="ed488-136">リストの各項目に対してカスタマイズした外観を定義するには、ItemTemplate プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="ed488-136">To define a custom look for each item in the list, use the ItemTemplate property.</span></span>

### <a name="suggestion-chosen"></a><span data-ttu-id="ed488-137">候補の選択</span><span class="sxs-lookup"><span data-stu-id="ed488-137">Suggestion chosen</span></span>

<span data-ttu-id="ed488-138">ユーザーがキーボードを使って候補リスト内を移動したときは、テキスト ボックス内のテキストを更新して合わせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed488-138">When a user navigates through the suggestion list using the keyboard, you need to update the text in the text box to match.</span></span>

<span data-ttu-id="ed488-139">[TextMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textmemberpath.aspx) プロパティを設定し、テキスト ボックスに表示するデータ オブジェクトのプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="ed488-139">You can set the [TextMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textmemberpath.aspx) property to choose which property from your data object to display in the text box.</span></span> <span data-ttu-id="ed488-140">TextMemberPath を指定した場合、テキスト ボックスは自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="ed488-140">If you specify a TextMemberPath, the text box is updated automatically.</span></span> <span data-ttu-id="ed488-141">通常は、DisplayMemberPath と TextMemberPath に同じ値を指定する必要があるため、候補リストとテキスト ボックスのテキストは同じです。</span><span class="sxs-lookup"><span data-stu-id="ed488-141">You should typically specify the same value for DisplayMemberPath and TextMemberPath so the text is the same in the suggestion list and the text box.</span></span>

<span data-ttu-id="ed488-142">単純ではないプロパティを表示する必要がある場合、[SuggestionChosen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx) イベントを処理し、選択した項目に基づいてカスタム テキストをテキスト ボックスに入力します。</span><span class="sxs-lookup"><span data-stu-id="ed488-142">If you need to show more than a simple property, handle the [SuggestionChosen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx) event to populate the text box with custom text based on the selected item.</span></span>

### <a name="query-submitted"></a><span data-ttu-id="ed488-143">クエリの送信</span><span class="sxs-lookup"><span data-stu-id="ed488-143">Query submitted</span></span>

<span data-ttu-id="ed488-144">[QuerySubmitted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx) イベントを処理し、アプリに適したクエリ操作を実行して、ユーザーに結果を表示します。</span><span class="sxs-lookup"><span data-stu-id="ed488-144">Handle the [QuerySubmitted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx) event to perform a query action appropriate to your app and show the result to the user.</span></span>

<span data-ttu-id="ed488-145">ユーザーがクエリ文字列をコミットすると、QuerySubmitted イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="ed488-145">The QuerySubmitted event occurs when a user commits a query string.</span></span> <span data-ttu-id="ed488-146">ユーザーは次のいずれかの方法でクエリをコミットできます。</span><span class="sxs-lookup"><span data-stu-id="ed488-146">The user can commit a query in one of these ways:</span></span>
- <span data-ttu-id="ed488-147">テキスト ボックスにフォーカスがあるときに、Enter キーを押すか、クエリ アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="ed488-147">While the focus is in the text box, press Enter or click the query icon.</span></span> <span data-ttu-id="ed488-148">イベント引数の [ChosenSuggestion](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.chosensuggestion.aspx) プロパティは **null** です。</span><span class="sxs-lookup"><span data-stu-id="ed488-148">The event args [ChosenSuggestion](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.chosensuggestion.aspx) property is **null**.</span></span>
- <span data-ttu-id="ed488-149">候補リストにフォーカスがあるときに、Enter キーを押すか、項目をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="ed488-149">While the focus is in the suggestion list, press Enter, click, or tap an item.</span></span> <span data-ttu-id="ed488-150">イベント引数の ChosenSuggestion プロパティには、一覧から選択された項目が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ed488-150">The event args ChosenSuggestion property contains the item that was selected from the list.</span></span>

<span data-ttu-id="ed488-151">いずれの場合も、イベント引数の [QueryText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.querytext.aspx) プロパティにはテキスト ボックスのテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ed488-151">In all cases, the event args [QueryText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.querytext.aspx) property contains the text from the text box.</span></span>

<span data-ttu-id="ed488-152">必須のイベント ハンドラーを使った簡単な AutoSuggestBox を次に示します。</span><span class="sxs-lookup"><span data-stu-id="ed488-152">Here is a simple AutoSuggestBox with the required event handlers.</span></span>

```xaml
<AutoSuggestBox PlaceholderText="Search" QueryIcon="Find" Width="200"
                TextChanged="AutoSuggestBox_TextChanged"
                QuerySubmitted="AutoSuggestBox_QuerySubmitted"
                SuggestionChosen="AutoSuggestBox_SuggestionChosen"/>
```

```csharp
private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
{
    // Only get results when it was a user typing,
    // otherwise assume the value got filled in by TextMemberPath
    // or the handler for SuggestionChosen.
    if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
    {
        //Set the ItemsSource to be your filtered dataset
        //sender.ItemsSource = dataset;
    }
}


private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
{
    // Set sender.Text. You can use args.SelectedItem to build your text string.
}


private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
{
    if (args.ChosenSuggestion != null)
    {
        // User selected an item from the suggestion list, take an action on it here.
    }
    else
    {
        // Use args.QueryText to determine what to do.
    }
}
```

## <a name="use-autosuggestbox-for-search"></a><span data-ttu-id="ed488-153">検索に AutoSuggestBox を使う</span><span class="sxs-lookup"><span data-stu-id="ed488-153">Use AutoSuggestBox for search</span></span>

<span data-ttu-id="ed488-154">AutoSuggestBox を使って、ユーザーが入力と同時に選べる候補リストを表示します。</span><span class="sxs-lookup"><span data-stu-id="ed488-154">Use an AutoSuggestBox to provide a list of suggestions for a user to select from as they type.</span></span>

<span data-ttu-id="ed488-155">既定では、テキスト入力ボックスにはクエリ ボタンが表示されません。</span><span class="sxs-lookup"><span data-stu-id="ed488-155">By default, the text entry box doesn’t have a query button shown.</span></span> <span data-ttu-id="ed488-156">[QueryIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.queryicon.aspx) プロパティを設定し、テキスト ボックスの右側に指定したアイコンが表示されるボタンを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="ed488-156">You can set the [QueryIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.queryicon.aspx) property to add a button with the specified icon on the right side of the text box.</span></span> <span data-ttu-id="ed488-157">たとえば、AutoSuggestBox を一般的な検索ボックスと同様の外観にするには、次のような "検索" アイコンを追加します。</span><span class="sxs-lookup"><span data-stu-id="ed488-157">For example, to make the AutoSuggestBox look like a typical search box, add a ‘find’ icon, like this.</span></span>

```xaml
<AutoSuggestBox QueryIcon="Find"/>
```

<span data-ttu-id="ed488-158">ここでは、AutoSuggestBox に "検索" アイコンが付いています。</span><span class="sxs-lookup"><span data-stu-id="ed488-158">Here's an AutoSuggestBox with a 'find' icon.</span></span>

![自動提案コントロールのエントリ ポイントの例](images/controls_autosuggest_entrypoint.png)

## <a name="dos-and-donts"></a><span data-ttu-id="ed488-160">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="ed488-160">Do's and don'ts</span></span>

-   <span data-ttu-id="ed488-161">自動提案ボックスを使って検索を実行したときに、入力したテキストに対応する検索結果が存在しなかった場合は、"検索結果が見つかりませんでした" という 1 行を表示します。これにより、検索要求が実行されたことがユーザーに伝わります。</span><span class="sxs-lookup"><span data-stu-id="ed488-161">When using the auto-suggest box to perform searches and no search results exist for the entered text, display a single-line "No results" message as the result so that users know their search request executed:</span></span>

    ![検索結果のない自動提案ボックスの例](images/controls_autosuggest_noresults.png)

<!--
<div class="microsoft-internal-note">
**Globalization and localization checklist**

<table>
<tr>
<th>Vertical spacing</th><td>Use non-Latin characters for vertical spacing to ensure non-Latin scripts will display properly, including numbers.</td>
</tr>
<tr>
<th>Scrolling</th><td>When auto suggest text is selected, user should be able to scroll to end of string.</td>
</tr>
</table>
</div>
-->

## <a name="get-the-sample-code"></a><span data-ttu-id="ed488-163">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="ed488-163">Get the sample code</span></span>

- <span data-ttu-id="ed488-164">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="ed488-164">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="ed488-165">AutoSuggestBox サンプル</span><span class="sxs-lookup"><span data-stu-id="ed488-165">AutoSuggestBox sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlAutoSuggestBox)

## <a name="related-articles"></a><span data-ttu-id="ed488-166">関連記事</span><span class="sxs-lookup"><span data-stu-id="ed488-166">Related articles</span></span>

- [<span data-ttu-id="ed488-167">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="ed488-167">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="ed488-168">スペル チェック</span><span class="sxs-lookup"><span data-stu-id="ed488-168">Spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="ed488-169">検索</span><span class="sxs-lookup"><span data-stu-id="ed488-169">Search</span></span>](search.md)
- [<span data-ttu-id="ed488-170">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="ed488-170">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="ed488-171">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="ed488-171">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="ed488-172">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="ed488-172">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length.aspx)
