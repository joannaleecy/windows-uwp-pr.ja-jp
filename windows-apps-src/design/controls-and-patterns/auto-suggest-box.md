---
Description: ユーザーが入力するときに、検索候補を表示するテキスト入力ボックスです。
title: 自動提案ボックスのガイドライン
ms.assetid: 1F608477-F795-4F33-92FA-F200CC243B6B
dev.assetid: 54F8DB8A-120A-4D79-8B5A-9315A3764C2F
label: Auto-suggest box
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 86b0063175b5e040cd7d92357bfa4b8abac4e13c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592407"
---
# <a name="auto-suggest-box"></a><span data-ttu-id="64a3f-104">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="64a3f-104">Auto-suggest box</span></span>

<span data-ttu-id="64a3f-105">AutoSuggestBox を使って、ユーザーが入力と同時に選べる候補リストを表示します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-105">Use an AutoSuggestBox to provide a list of suggestions for a user to select from as they type.</span></span>

> <span data-ttu-id="64a3f-106">**重要な Api**:[AutoSuggestBox クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)、 [TextChanged イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx)、 [SuggestionChose イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx)、 [QuerySubmitted イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx)</span><span class="sxs-lookup"><span data-stu-id="64a3f-106">**Important APIs**: [AutoSuggestBox class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx), [TextChanged event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx), [SuggestionChose event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx), [QuerySubmitted event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx)</span></span>

![自動提案ボックス](images/controls/auto-suggest-box-open.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="64a3f-108">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="64a3f-108">Is this the right control?</span></span>

<span data-ttu-id="64a3f-109">候補の一覧を使ってテキストを検索できる、シンプルでカスタマイズ可能なコントロールが必要な場合は、自動提案ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="64a3f-109">If you'd like a simple, customizable control that allows text search with a list of suggestions, then choose an auto-suggest box.</span></span>

<span data-ttu-id="64a3f-110">適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64a3f-110">For more info about choosing the right text control, see the [Text controls](text-controls.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="64a3f-111">例</span><span class="sxs-lookup"><span data-stu-id="64a3f-111">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="64a3f-112">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="64a3f-112">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="64a3f-113"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/AutoSuggestBox">アプリを開き、AutoSuggestBox の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="64a3f-113">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/AutoSuggestBox">open the app and see the AutoSuggestBox in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="64a3f-114"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></span><span class="sxs-lookup"><span data-stu-id="64a3f-114"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="64a3f-115"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="64a3f-115"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="64a3f-116">Groove ミュージック アプリの自動提案ボックス。</span><span class="sxs-lookup"><span data-stu-id="64a3f-116">An auto suggest box in the Groove Music app.</span></span>

![Groove ミュージック アプリの自動提案ボックス](images/control-examples/auto-suggest-box-groove.png)

## <a name="anatomy"></a><span data-ttu-id="64a3f-118">構造</span><span class="sxs-lookup"><span data-stu-id="64a3f-118">Anatomy</span></span>
<span data-ttu-id="64a3f-119">自動提案ボックスのエントリ ポイントは、オプションのヘッダーとオプションのヒント テキスト付きのテキスト ボックスで構成されます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-119">The entry point for the auto-suggest box consists of an optional header and a text box with optional hint text:</span></span>

![自動提案コントロールのエントリ ポイントの例](images/controls_autosuggest_entrypoint.png)

<span data-ttu-id="64a3f-121">自動提案結果の一覧には、ユーザーがテキストの入力を開始すると自動的に内容が入力されます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-121">The auto-suggest results list populates automatically once the user starts to enter text.</span></span> <span data-ttu-id="64a3f-122">結果の一覧は、テキスト入力ボックスの上または下に表示されます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-122">The results list can appear above or below the text entry box.</span></span> <span data-ttu-id="64a3f-123">[すべてクリア] ボタンも表示されます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-123">A "clear all" button appears:</span></span>

![展開された自動提案コントロールの例](images/controls_autosuggest_expanded01.png)

## <a name="create-an-auto-suggest-box"></a><span data-ttu-id="64a3f-125">自動提案ボックスの作成</span><span class="sxs-lookup"><span data-stu-id="64a3f-125">Create an auto-suggest box</span></span>

<span data-ttu-id="64a3f-126">AutoSuggestBox を使うには、3 つのユーザー操作に応答する必要があります。</span><span class="sxs-lookup"><span data-stu-id="64a3f-126">To use an AutoSuggestBox, you need to respond to 3 user actions.</span></span>

- <span data-ttu-id="64a3f-127">テキストの変更 - ユーザーがテキストを入力したときに、候補リストを更新します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-127">Text changed - When the user enters text, update the suggestion list.</span></span>
- <span data-ttu-id="64a3f-128">候補の選択 - ユーザーが候補リストで候補を選んだときに、テキスト ボックスを更新します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-128">Suggestion chosen - When the user chooses a suggestion in the suggestion list, update the text box.</span></span>
- <span data-ttu-id="64a3f-129">クエリの送信 - ユーザーがクエリを送信したときに、クエリの結果を表示します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-129">Query submitted - When the user submits a query, show the query results.</span></span>

### <a name="text-changed"></a><span data-ttu-id="64a3f-130">テキストの変更</span><span class="sxs-lookup"><span data-stu-id="64a3f-130">Text changed</span></span>

<span data-ttu-id="64a3f-131">テキスト ボックスの内容が更新されるたびに、[TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-131">The [TextChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx) event occurs whenever the content of the text box is updated.</span></span> <span data-ttu-id="64a3f-132">イベント引数 [Reason](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxtextchangedeventargs.reason.aspx) プロパティを使って、変更がユーザー入力によって生じたものかどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-132">Use the event args [Reason](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxtextchangedeventargs.reason.aspx) property to determine whether the change was due to user input.</span></span> <span data-ttu-id="64a3f-133">変更の理由が **UserInput** の場合、入力に基づいてデータをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-133">If the change reason is **UserInput**, filter your data based on the input.</span></span> <span data-ttu-id="64a3f-134">次に、フィルター処理されたデータを AutoSuggestBox の [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) に設定し、候補リストを更新します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-134">Then, set the filtered data as the [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) of the AutoSuggestBox to update the suggestion list.</span></span>

<span data-ttu-id="64a3f-135">候補リストでの項目の表示方法を制御するには、[DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) または [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-135">To control how items are displayed in the suggestion list, you can use [DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) or [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx).</span></span>

- <span data-ttu-id="64a3f-136">データ項目の単一のプロパティのテキストを表示するには、DisplayMemberPath プロパティを設定し、候補リストに表示するオブジェクトのプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-136">To display the text of a single property of your data item, set the DisplayMemberPath property to choose which property from your object to display in the suggestion list.</span></span>
- <span data-ttu-id="64a3f-137">リストの各項目に対してカスタマイズした外観を定義するには、ItemTemplate プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="64a3f-137">To define a custom look for each item in the list, use the ItemTemplate property.</span></span>

### <a name="suggestion-chosen"></a><span data-ttu-id="64a3f-138">候補の選択</span><span class="sxs-lookup"><span data-stu-id="64a3f-138">Suggestion chosen</span></span>

<span data-ttu-id="64a3f-139">ユーザーがキーボードを使って候補リスト内を移動したときは、テキスト ボックス内のテキストを更新して合わせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="64a3f-139">When a user navigates through the suggestion list using the keyboard, you need to update the text in the text box to match.</span></span>

<span data-ttu-id="64a3f-140">[TextMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textmemberpath.aspx) プロパティを設定し、テキスト ボックスに表示するデータ オブジェクトのプロパティを選択します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-140">You can set the [TextMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textmemberpath.aspx) property to choose which property from your data object to display in the text box.</span></span> <span data-ttu-id="64a3f-141">TextMemberPath を指定した場合、テキスト ボックスは自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-141">If you specify a TextMemberPath, the text box is updated automatically.</span></span> <span data-ttu-id="64a3f-142">通常は、DisplayMemberPath と TextMemberPath に同じ値を指定する必要があるため、候補リストとテキスト ボックスのテキストは同じです。</span><span class="sxs-lookup"><span data-stu-id="64a3f-142">You should typically specify the same value for DisplayMemberPath and TextMemberPath so the text is the same in the suggestion list and the text box.</span></span>

<span data-ttu-id="64a3f-143">単純ではないプロパティを表示する必要がある場合、[SuggestionChosen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx) イベントを処理し、選択した項目に基づいてカスタム テキストをテキスト ボックスに入力します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-143">If you need to show more than a simple property, handle the [SuggestionChosen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx) event to populate the text box with custom text based on the selected item.</span></span>

### <a name="query-submitted"></a><span data-ttu-id="64a3f-144">クエリの送信</span><span class="sxs-lookup"><span data-stu-id="64a3f-144">Query submitted</span></span>

<span data-ttu-id="64a3f-145">[QuerySubmitted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx) イベントを処理し、アプリに適したクエリ操作を実行して、ユーザーに結果を表示します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-145">Handle the [QuerySubmitted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx) event to perform a query action appropriate to your app and show the result to the user.</span></span>

<span data-ttu-id="64a3f-146">ユーザーがクエリ文字列をコミットすると、QuerySubmitted イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-146">The QuerySubmitted event occurs when a user commits a query string.</span></span> <span data-ttu-id="64a3f-147">ユーザーは次のいずれかの方法でクエリをコミットできます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-147">The user can commit a query in one of these ways:</span></span>
- <span data-ttu-id="64a3f-148">テキスト ボックスにフォーカスがあるときに、Enter キーを押すか、クエリ アイコンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="64a3f-148">While the focus is in the text box, press Enter or click the query icon.</span></span> <span data-ttu-id="64a3f-149">イベント引数の [ChosenSuggestion](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.chosensuggestion.aspx) プロパティは **null** です。</span><span class="sxs-lookup"><span data-stu-id="64a3f-149">The event args [ChosenSuggestion](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.chosensuggestion.aspx) property is **null**.</span></span>
- <span data-ttu-id="64a3f-150">候補リストにフォーカスがあるときに、Enter キーを押すか、項目をクリックまたはタップします。</span><span class="sxs-lookup"><span data-stu-id="64a3f-150">While the focus is in the suggestion list, press Enter, click, or tap an item.</span></span> <span data-ttu-id="64a3f-151">イベント引数の ChosenSuggestion プロパティには、一覧から選択された項目が含まれています。</span><span class="sxs-lookup"><span data-stu-id="64a3f-151">The event args ChosenSuggestion property contains the item that was selected from the list.</span></span>

<span data-ttu-id="64a3f-152">いずれの場合も、イベント引数の [QueryText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.querytext.aspx) プロパティにはテキスト ボックスのテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="64a3f-152">In all cases, the event args [QueryText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.querytext.aspx) property contains the text from the text box.</span></span>

<span data-ttu-id="64a3f-153">必須のイベント ハンドラーを使った簡単な AutoSuggestBox を次に示します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-153">Here is a simple AutoSuggestBox with the required event handlers.</span></span>

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

## <a name="use-autosuggestbox-for-search"></a><span data-ttu-id="64a3f-154">検索に AutoSuggestBox を使う</span><span class="sxs-lookup"><span data-stu-id="64a3f-154">Use AutoSuggestBox for search</span></span>

<span data-ttu-id="64a3f-155">AutoSuggestBox を使って、ユーザーが入力と同時に選べる候補リストを表示します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-155">Use an AutoSuggestBox to provide a list of suggestions for a user to select from as they type.</span></span>

<span data-ttu-id="64a3f-156">既定では、テキスト入力ボックスにはクエリ ボタンが表示されません。</span><span class="sxs-lookup"><span data-stu-id="64a3f-156">By default, the text entry box doesn’t have a query button shown.</span></span> <span data-ttu-id="64a3f-157">[QueryIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.queryicon.aspx) プロパティを設定し、テキスト ボックスの右側に指定したアイコンが表示されるボタンを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-157">You can set the [QueryIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.queryicon.aspx) property to add a button with the specified icon on the right side of the text box.</span></span> <span data-ttu-id="64a3f-158">たとえば、AutoSuggestBox を一般的な検索ボックスと同様の外観にするには、次のような "検索" アイコンを追加します。</span><span class="sxs-lookup"><span data-stu-id="64a3f-158">For example, to make the AutoSuggestBox look like a typical search box, add a ‘find’ icon, like this.</span></span>

```xaml
<AutoSuggestBox QueryIcon="Find"/>
```

<span data-ttu-id="64a3f-159">ここでは、AutoSuggestBox に "検索" アイコンが付いています。</span><span class="sxs-lookup"><span data-stu-id="64a3f-159">Here's an AutoSuggestBox with a 'find' icon.</span></span>

![自動提案コントロールのエントリ ポイントの例](images/controls_autosuggest_entrypoint.png)

## <a name="dos-and-donts"></a><span data-ttu-id="64a3f-161">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="64a3f-161">Do's and don'ts</span></span>

-   <span data-ttu-id="64a3f-162">自動提案ボックスを使って検索を実行したときに、入力したテキストに対応する検索結果が存在しなかった場合は、"検索結果が見つかりませんでした" という 1 行を表示します。これにより、ユーザーは検索要求が実行されたことがわかります。</span><span class="sxs-lookup"><span data-stu-id="64a3f-162">When using the auto-suggest box to perform searches and no search results exist for the entered text, display a single-line "No results" message as the result so that users know their search request executed:</span></span>

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

## <a name="get-the-sample-code"></a><span data-ttu-id="64a3f-164">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="64a3f-164">Get the sample code</span></span>

- <span data-ttu-id="64a3f-165">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="64a3f-165">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>
- [<span data-ttu-id="64a3f-166">AutoSuggestBox サンプル</span><span class="sxs-lookup"><span data-stu-id="64a3f-166">AutoSuggestBox sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlAutoSuggestBox)

## <a name="related-articles"></a><span data-ttu-id="64a3f-167">関連記事</span><span class="sxs-lookup"><span data-stu-id="64a3f-167">Related articles</span></span>

- [<span data-ttu-id="64a3f-168">テキスト コントロール</span><span class="sxs-lookup"><span data-stu-id="64a3f-168">Text controls</span></span>](text-controls.md)
- [<span data-ttu-id="64a3f-169">スペル チェック</span><span class="sxs-lookup"><span data-stu-id="64a3f-169">Spell checking</span></span>](text-controls.md)
- [<span data-ttu-id="64a3f-170">検索</span><span class="sxs-lookup"><span data-stu-id="64a3f-170">Search</span></span>](search.md)
- [<span data-ttu-id="64a3f-171">TextBox クラス</span><span class="sxs-lookup"><span data-stu-id="64a3f-171">TextBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209683)
- [<span data-ttu-id="64a3f-172">Windows.UI.Xaml.Controls PasswordBox クラス</span><span class="sxs-lookup"><span data-stu-id="64a3f-172">Windows.UI.Xaml.Controls PasswordBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br227519)
- [<span data-ttu-id="64a3f-173">String.Length プロパティ</span><span class="sxs-lookup"><span data-stu-id="64a3f-173">String.Length property</span></span>](https://msdn.microsoft.com/library/system.string.length.aspx)
