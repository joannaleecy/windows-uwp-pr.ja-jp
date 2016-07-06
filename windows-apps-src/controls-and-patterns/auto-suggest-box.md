---
author: Jwmsft
Description: "ユーザーが入力するときに、検索候補を表示するテキスト入力ボックスです。"
title: "自動提案ボックスのガイドライン"
ms.assetid: 1F608477-F795-4F33-92FA-F200CC243B6B
dev.assetid: 54F8DB8A-120A-4D79-8B5A-9315A3764C2F
label: Auto-suggest box
template: detail.hbs
ms.sourcegitcommit: 7d438080e2e8533f1148c07e27143d4d1fcacf5d
ms.openlocfilehash: bc3337101f0f2e8449d052743f7b3ce8d2dac516

---
# 自動提案ボックス
入力に応じてユーザーが選択できる候補の一覧を表示するには、AutoSuggestBox を使います。

![自動提案ボックス](images/controls/auto-suggest-box-open.png)



-   [**AutoSuggestBox クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)
-   [**TextChanged イベント**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx)
-   [**SuggestionChose イベント**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx)
-   [**QuerySubmitted イベント**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx)

## 適切なコントロールの選択

候補の一覧を使ってテキストを検索できる、シンプルでカスタマイズ可能なコントロールが必要な場合は、自動提案ボックスを使います。

適切なテキスト コントロールの選択について詳しくは、「[テキスト コントロール](text-controls.md)」をご覧ください。

## 例

Groove ミュージック アプリの自動提案ボックス。

![Groove ミュージック アプリの自動提案ボックス](images/control-examples/auto-suggest-box-groove.png)

## 構造
自動提案ボックスのエントリ ポイントは、オプションのヘッダーとオプションのヒント テキスト付きのテキスト ボックスで構成されます。

![自動提案コントロールのエントリ ポイントの例](images/controls_autosuggest_entrypoint.png)

自動提案結果の一覧には、ユーザーがテキストの入力を開始すると自動的に内容が入力されます。 結果の一覧は、テキスト入力ボックスの上または下に表示されます。 [すべてクリア] ボタンも表示されます。

![展開された自動提案コントロールの例](images/controls_autosuggest_expanded01.png)

## 自動提案ボックスの作成

AutoSuggestBox を使うには、3 つのユーザー操作に応答する必要があります。

- テキストの変更 - ユーザーがテキストを入力したときに、候補リストを更新します。
- 候補の選択 - ユーザーが候補リストで候補を選んだときに、テキスト ボックスを更新します。
- クエリの送信 - ユーザーがクエリを送信したときに、クエリの結果を表示します。

### テキストの変更

テキスト ボックスの内容が更新されるたびに、[**TextChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textchanged.aspx) イベントが発生します。 イベント引数 [Reason](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxtextchangedeventargs.reason.aspx) プロパティを使って、変更がユーザー入力によって生じたものかどうかを調べます。 変更の理由が **UserInput** の場合、入力に基づいてデータをフィルター処理します。 次に、フィルター処理されたデータを AutoSuggestBox の [ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) に設定し、候補リストを更新します。

候補リストでの項目の表示方法を制御するには、[DisplayMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.displaymemberpath.aspx) または [ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) を使うことができます。

- データ項目の単一のプロパティのテキストを表示するには、DisplayMemberPath プロパティを設定し、候補リストに表示するオブジェクトのプロパティを選択します。
- リストの各項目に対してカスタマイズした外観を定義するには、ItemTemplate プロパティを使います。

### 候補の選択

ユーザーがキーボードを使って候補リスト内を移動したときは、テキスト ボックス内のテキストを更新して合わせる必要があります。

[TextMemberPath](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.textmemberpath.aspx) プロパティを設定し、テキスト ボックスに表示するデータ オブジェクトのプロパティを選択します。 TextMemberPath を指定した場合、テキスト ボックスは自動的に更新されます。 通常は、DisplayMemberPath と TextMemberPath に同じ値を指定する必要があるため、候補リストとテキスト ボックスのテキストは同じです。

単純ではないプロパティを表示する必要がある場合、[SuggestionChosen](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.suggestionchosen.aspx) イベントを処理し、選択した項目に基づいてカスタム テキストをテキスト ボックスに入力します。

### クエリの送信

[QuerySubmitted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.querysubmitted.aspx) イベントを処理し、アプリに適したクエリ操作を実行して、ユーザーに結果を表示します。

ユーザーがクエリ文字列をコミットすると、QuerySubmitted イベントが発生します。 ユーザーは次のいずれかの方法でクエリをコミットできます。
- テキスト ボックスにフォーカスがあるときに、Enter キーを押すか、クエリ アイコンをクリックします。 イベント引数の [ChosenSuggestion](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.chosensuggestion.aspx) プロパティは **null** です。
- 候補リストにフォーカスがあるときに、Enter キーを押すか、項目をクリックまたはタップします。 イベント引数の ChosenSuggestion プロパティには、一覧から選択された項目が含まれています。

いずれの場合も、イベント引数の [QueryText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestboxquerysubmittedeventargs.querytext.aspx) プロパティにはテキスト ボックスのテキストが含まれています。

## 検索に AutoSuggestBox を使う

AutoSuggestBox を使って、ユーザーが入力と同時に選べる候補リストを表示します。

既定では、テキスト入力ボックスにはクエリ ボタンが表示されません。 [QueryIcon](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.queryicon.aspx) プロパティを設定し、テキスト ボックスの右側に指定したアイコンが表示されるボタンを追加することができます。 たとえば、AutoSuggestBox を一般的な検索ボックスと同様の外観にするには、次のような "検索" アイコンを追加します。

```xaml
<AutoSuggestBox QueryIcon="Find"/>
```

ここでは、AutoSuggestBox に "検索" アイコンが付いています。

![自動提案コントロールのエントリ ポイントの例](images/controls_autosuggest_entrypoint.png)

## サンプル

AutoSuggestBox の動作の詳細な例については、[AutoSuggestBox の移行のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619996) と [XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992) をご覧ください。

必須のイベント ハンドラーを使った簡単な AutoSuggestBox を次に示します。

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

## 推奨と非推奨

-   自動提案ボックスを使って検索を実行したときに、入力したテキストに対応する検索結果が存在しなかった場合は、"検索結果が見つかりませんでした" という 1 行を表示します。これにより、検索要求が実行されたことがユーザーに伝わります。

    ![検索結果のない自動提案ボックスの例](images/controls_autosuggest_noresults.png)

{{> aside-internal content = "
## グローバリゼーションとローカライズのチェックリスト

<table>
<tr>
<th>垂直方向の間隔</th><td>非ラテン文字を使って垂直方法の間隔を調整し、非ラテン文字が数字を含めて適切に表示されるようにします。</td>
</tr>
<tr>
<th>スクロール</th><td>自動提案テキストが選択されたときに、文字列の末尾までスクロールできるようにする必要があります。</td>
</tr>
</table>
"}}

## 関連記事

- [テキスト コントロール](text-controls.md)
- [スペル チェック](spell-checking-and-prediction.md)
- [検索](search.md)
- [**TextBox クラス**](https://msdn.microsoft.com/library/windows/apps/br209683)
- [**Windows.UI.Xaml.Controls PasswordBox クラス**](https://msdn.microsoft.com/library/windows/apps/br227519)
- [String.Length プロパティ](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)



<!--HONumber=Jun16_HO4-->


