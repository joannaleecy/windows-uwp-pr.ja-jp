---
author: Jwmsft
Description: "ユーザーが入力するときに、検索候補を表示するテキスト入力ボックスです。"
title: "自動提案ボックスのガイドライン"
ms.assetid: 1F608477-F795-4F33-92FA-F200CC243B6B
dev.assetid: 54F8DB8A-120A-4D79-8B5A-9315A3764C2F
label: Auto-suggest box
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.openlocfilehash: 61e0d0c1d368a515a7d0b6aba24c7de4b5898092
ms.sourcegitcommit: 45490bd85e6f8d247a041841d547ecac2ff48250
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/23/2017
---
# <a name="auto-suggest-box"></a><span data-ttu-id="6f42a-104">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="6f42a-104">Auto-suggest box</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="6f42a-105">AutoSuggestBox を使って、ユーザーが入力と同時に選べる候補リストを表示します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-105">Use an AutoSuggestBox to provide a list of suggestions for a user to select from as they type.</span></span>

> <span data-ttu-id="6f42a-106">**重要な API**: [AutoSuggestBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)、[TextChanged イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx)、[SuggestionChose イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx)、[QuerySubmitted イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx)</span><span class="sxs-lookup"><span data-stu-id="6f42a-106">**Important APIs**: [AutoSuggestBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx), [TextChanged event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx), [SuggestionChose event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx), [QuerySubmitted event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx)</span></span>

![自動提案ボックス](images/controls/auto-suggest-box-open.png)


## <a name="is-this-the-right-control"></a><span data-ttu-id="6f42a-108">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="6f42a-108">Is this the right control?</span></span>

<span data-ttu-id="6f42a-109">候補の一覧を使ってテキストを検索できる、シンプルでカスタマイズ可能なコントロールが必要な場合は、自動提案ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="6f42a-109">If you'd like a simple, customizable control that allows text search with a list of suggestions, then choose an auto-suggest box.</span></span>

<span data-ttu-id="6f42a-110">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f42a-110">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="6f42a-111">例</span><span class="sxs-lookup"><span data-stu-id="6f42a-111">Examples</span></span>

<span data-ttu-id="6f42a-112">Groove ミュージック アプリの自動提案ボックス。</span><span class="sxs-lookup"><span data-stu-id="6f42a-112">An auto suggest box in the Groove Music app.</span></span>

![Groove ミュージック アプリの自動提案ボックス](images/control-examples/auto-suggest-box-groove.png)

## <a name="anatomy"></a><span data-ttu-id="6f42a-114">構造</span><span class="sxs-lookup"><span data-stu-id="6f42a-114">Anatomy</span></span>
<span data-ttu-id="6f42a-115">自動提案ボックスのエントリ ポイントは、オプションのヘッダーとオプションのヒント テキスト付きのテキスト ボックスで構成されます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-115">The entry point for the auto-suggest box consists of an optional header and a text box with optional hint text:</span></span>

![自動提案コントロールのエントリ ポイントの例](images/controls_autosuggest_entrypoint.png)

<span data-ttu-id="6f42a-117">自動提案結果の一覧には、ユーザーがテキストの入力を開始すると自動的に内容が入力されます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-117">The auto-suggest results list populates automatically once the user starts to enter text.</span></span> <span data-ttu-id="6f42a-118">結果の一覧は、テキスト入力ボックスの上または下に表示されます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-118">The results list can appear above or below the text entry box.</span></span> <span data-ttu-id="6f42a-119">[すべてクリア] ボタンも表示されます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-119">A "clear all" button appears:</span></span>

![展開された自動提案コントロールの例](images/controls_autosuggest_expanded01.png)

## <a name="create-an-auto-suggest-box"></a><span data-ttu-id="6f42a-121">自動提案ボックスの作成</span><span class="sxs-lookup"><span data-stu-id="6f42a-121">Create an auto-suggest box</span></span>

<span data-ttu-id="6f42a-122">AutoSuggestBox を使うには、3 つのユーザー操作に応答する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f42a-122">To use an AutoSuggestBox, you need to respond to 3 user actions.</span></span>

- <span data-ttu-id="6f42a-123">テキストの変更 - ユーザーがテキストを入力したときに、候補リストを更新します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-123">Text changed - When the user enters text, update the suggestion list.</span></span>
- <span data-ttu-id="6f42a-124">候補の選択 - ユーザーが候補リストで候補を選んだときに、テキスト ボックスを更新します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-124">Suggestion chosen - When the user chooses a suggestion in the suggestion list, update the text box.</span></span>
- <span data-ttu-id="6f42a-125">クエリの送信 - ユーザーがクエリを送信したときに、クエリの結果を表示します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-125">Query submitted - When the user submits a query, show the query results.</span></span>

### <a name="text-changed"></a><span data-ttu-id="6f42a-126">テキストの変更</span><span class="sxs-lookup"><span data-stu-id="6f42a-126">Text changed</span></span>

<span data-ttu-id="6f42a-127">テキスト ボックスの内容が更新されるたびに、[TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-127">The [TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx) event occurs whenever the content of the text box is updated.</span></span> <span data-ttu-id="6f42a-128">イベント引数 [Reason](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxtextchangedeventargs.reason.aspx) プロパティを使って、変更がユーザー入力によって生じたものかどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-128">Use the event args [Reason](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxtextchangedeventargs.reason.aspx) property to determine whether the change was due to user input.</span></span> <span data-ttu-id="6f42a-129">変更の理由が **UserInput** の場合、入力に基づいてデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-129">If the change reason is **UserInput**, filter your data based on the input.</span></span> <span data-ttu-id="6f42a-130">次に、フィルター処理されたデータを AutoSuggestBox の [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) に設定し、候補リストを更新します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-130">Then, set the filtered data as the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) of the AutoSuggestBox to update the suggestion list.</span></span>

<span data-ttu-id="6f42a-131">候補リストでの項目の表示方法を制御するには、[DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) または [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-131">To control how items are displayed in the suggestion list, you can use [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) or [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx).</span></span>

- <span data-ttu-id="6f42a-132">データ項目の単一のプロパティのテキストを表示するには、DisplayMemberPath プロパティを設定し、候補リストに表示するオブジェクトのプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-132">To display the text of a single property of your data item, set the DisplayMemberPath property to choose which property from your object to display in the suggestion list.</span></span>
- <span data-ttu-id="6f42a-133">リストの各項目に対してカスタマイズした外観を定義するには、ItemTemplate プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="6f42a-133">To define a custom look for each item in the list, use the ItemTemplate property.</span></span>

### <a name="suggestion-chosen"></a><span data-ttu-id="6f42a-134">候補の選択</span><span class="sxs-lookup"><span data-stu-id="6f42a-134">Suggestion chosen</span></span>

<span data-ttu-id="6f42a-135">ユーザーがキーボードを使って候補リスト内を移動したときは、テキスト ボックス内のテキストを更新して合わせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="6f42a-135">When a user navigates through the suggestion list using the keyboard, you need to update the text in the text box to match.</span></span>

<span data-ttu-id="6f42a-136">[TextMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textmemberpath.aspx) プロパティを設定し、テキスト ボックスに表示するデータ オブジェクトのプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-136">You can set the [TextMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textmemberpath.aspx) property to choose which property from your data object to display in the text box.</span></span> <span data-ttu-id="6f42a-137">TextMemberPath を指定した場合、テキスト ボックスは自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-137">If you specify a TextMemberPath, the text box is updated automatically.</span></span> <span data-ttu-id="6f42a-138">通常は、DisplayMemberPath と TextMemberPath に同じ値を指定する必要があるため、候補リストとテキスト ボックスのテキストは同じです。</span><span class="sxs-lookup"><span data-stu-id="6f42a-138">You should typically specify the same value for DisplayMemberPath and TextMemberPath so the text is the same in the suggestion list and the text box.</span></span>

<span data-ttu-id="6f42a-139">単純ではないプロパティを表示する必要がある場合、[SuggestionChosen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx) イベントを処理し、選択した項目に基づいてカスタム テキストをテキスト ボックスに入力します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-139">If you need to show more than a simple property, handle the [SuggestionChosen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx) event to populate the text box with custom text based on the selected item.</span></span>

### <a name="query-submitted"></a><span data-ttu-id="6f42a-140">クエリの送信</span><span class="sxs-lookup"><span data-stu-id="6f42a-140">Query submitted</span></span>

<span data-ttu-id="6f42a-141">[QuerySubmitted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx) イベントを処理し、アプリに適したクエリ操作を実行して、ユーザーに結果を表示します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-141">Handle the [QuerySubmitted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx) event to perform a query action appropriate to your app and show the result to the user.</span></span>

<span data-ttu-id="6f42a-142">ユーザーがクエリ文字列をコミットすると、QuerySubmitted イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-142">The QuerySubmitted event occurs when a user commits a query string.</span></span> <span data-ttu-id="6f42a-143">ユーザーは次のいずれかの方法でクエリをコミットできます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-143">The user can commit a query in one of these ways:</span></span>
- <span data-ttu-id="6f42a-144">テキスト ボックスにフォーカスがあるときに、Enter キーを押すか、クエリ アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="6f42a-144">While the focus is in the text box, press Enter or click the query icon.</span></span> <span data-ttu-id="6f42a-145">イベント引数の [ChosenSuggestion](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.chosensuggestion.aspx) プロパティは **null** です。</span><span class="sxs-lookup"><span data-stu-id="6f42a-145">The event args [ChosenSuggestion](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.chosensuggestion.aspx) property is **null**.</span></span>
- <span data-ttu-id="6f42a-146">候補リストにフォーカスがあるときに、Enter キーを押すか、項目をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="6f42a-146">While the focus is in the suggestion list, press Enter, click, or tap an item.</span></span> <span data-ttu-id="6f42a-147">イベント引数の ChosenSuggestion プロパティには、一覧から選択された項目が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6f42a-147">The event args ChosenSuggestion property contains the item that was selected from the list.</span></span>

<span data-ttu-id="6f42a-148">いずれの場合も、イベント引数の [QueryText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.querytext.aspx) プロパティにはテキスト ボックスのテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6f42a-148">In all cases, the event args [QueryText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.querytext.aspx) property contains the text from the text box.</span></span>

## <a name="use-autosuggestbox-for-search"></a><span data-ttu-id="6f42a-149">検索に AutoSuggestBox を使う</span><span class="sxs-lookup"><span data-stu-id="6f42a-149">Use AutoSuggestBox for search</span></span>

<span data-ttu-id="6f42a-150">AutoSuggestBox を使って、ユーザーが入力と同時に選べる候補リストを表示します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-150">Use an AutoSuggestBox to provide a list of suggestions for a user to select from as they type.</span></span>

<span data-ttu-id="6f42a-151">既定では、テキスト入力ボックスにはクエリ ボタンが表示されません。</span><span class="sxs-lookup"><span data-stu-id="6f42a-151">By default, the text entry box doesn’t have a query button shown.</span></span> <span data-ttu-id="6f42a-152">[QueryIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.queryicon.aspx) プロパティを設定し、テキスト ボックスの右側に指定したアイコンが表示されるボタンを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="6f42a-152">You can set the [QueryIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.queryicon.aspx) property to add a button with the specified icon on the right side of the text box.</span></span> <span data-ttu-id="6f42a-153">たとえば、AutoSuggestBox を一般的な検索ボックスと同様の外観にするには、次のような "検索" アイコンを追加します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-153">For example, to make the AutoSuggestBox look like a typical search box, add a ‘find’ icon, like this.</span></span>

```xaml
<AutoSuggestBox QueryIcon="Find"/>
```

<span data-ttu-id="6f42a-154">ここでは、AutoSuggestBox に "検索" アイコンが付いています。</span><span class="sxs-lookup"><span data-stu-id="6f42a-154">Here's an AutoSuggestBox with a 'find' icon.</span></span>

![自動提案コントロールのエントリ ポイントの例](images/controls_autosuggest_entrypoint.png)

## <a name="get-the-sample-code"></a><span data-ttu-id="6f42a-156">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="6f42a-156">Get the sample code</span></span> 

<span data-ttu-id="6f42a-157">AutoSuggestBox の動作の詳細な例については、[AutoSuggestBox の移行のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlAutoSuggestBox) と [XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6f42a-157">To see complete working examples of AutoSuggestBox, see the [AutoSuggestBox sample](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlAutoSuggestBox) and [XAML UI Basics sample](http://go.microsoft.com/fwlink/p/?LinkId=619992).</span></span>

<span data-ttu-id="6f42a-158">必須のイベント ハンドラーを使った簡単な AutoSuggestBox を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6f42a-158">Here is a simple AutoSuggestBox with the required event handlers.</span></span>

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

## <a name="dos-and-donts"></a><span data-ttu-id="6f42a-159">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="6f42a-159">Do's and don'ts</span></span>

-   <span data-ttu-id="6f42a-160">自動提案ボックスを使って検索を実行したときに、入力したテキストに対応する検索結果が存在しなかった場合は、"検索結果が見つかりませんでした" という 1 行を表示します。これにより、ユーザーは検索要求が実行されたことがわかります。</span><span class="sxs-lookup"><span data-stu-id="6f42a-160">When using the auto-suggest box to perform searches and no search results exist for the entered text, display a single-line "No results" message as the result so that users know their search request executed:</span></span>

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


## <a name="related-articles"></a><span data-ttu-id="6f42a-162">関連記事</span><span class="sxs-lookup"><span data-stu-id="6f42a-162">Related articles</span></span>

- [<span data-ttu-id="6f42a-163">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="6f42a-163">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="6f42a-164">スペル チェック</span><span class="sxs-lookup"><span data-stu-id="6f42a-164">Spell checking</span></span>](spell-checking-and-prediction.md)
- [<span data-ttu-id="6f42a-165">検索</span><span class="sxs-lookup"><span data-stu-id="6f42a-165">Search</span></span>](search.md)
- [<span data-ttu-id="6f42a-166">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="6f42a-166">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="6f42a-167">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="6f42a-167">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="6f42a-168">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="6f42a-168">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length.aspx)
