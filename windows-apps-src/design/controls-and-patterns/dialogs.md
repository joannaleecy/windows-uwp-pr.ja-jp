---
author: mijacobs
Description: Dialogs and flyouts display transient UI elements that appear when the user requests them or when something happens that requires notification or approval.
title: ダイアログとポップアップ
label: Dialogs
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
ms.assetid: ad6affd9-a3c0-481f-a237-9a1ecd561be8
pm-contact: yulikl
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 7b263fda1de798473f581e2191d3fa01385060e6
ms.sourcegitcommit: e4627686138ec8c885696c4c511f2f05195cf8ff
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/17/2018
ms.locfileid: "1893847"
---
# <a name="dialogs-and-flyouts"></a>ダイアログとポップアップ



ダイアログ ボックスとポップアップは、通知、許可、またはユーザーからの追加の情報を必要とする状況が発生したときに表示される一時的な UI 要素です。

> **重要な API**: [ContentDialog クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)、[Flyout クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout)


:::row::: :::column::: **ダイアログ**
        
        ![Example of a dialog](images/dialogs/dialog_RS2_delete_file.png)

        Dialogs are modal UI overlays that provide contextual app information. Dialogs block interactions with the app window until being explicitly dismissed. They often request some kind of action from the user.
    :::column-end:::
    :::column::: 
        **Flyouts**

        ![Example of a flyout](images/flyout-example2.png)

        A flyout is a lightweight contextual popup that displays UI related to what the user is doing. It includes placement and sizing logic, and can be used to reveal a secondary control or show more detail about an item.

        Unlike a dialog, a flyout can be quickly dismissed by tapping or clicking somewhere outside the flyout, pressing the Escape key or Back button, resizing the app window, or changing the device's orientation.
    :::column-end:::
:::row-end:::


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

* 重要な情報をユーザーに通知したり、アクションが完了する前に確認や追加情報を要求したりするには、ダイアログを使用します。
* [ヒント](tooltips.md)や[コンテキスト メニュー](menus.md)の変わりにポップアップを使用しないようにします。 指定した時間が経過すると非表示になる短い説明を表示するには、ヒントを使います。 UI 要素に関連した状況依存の操作 (コピーや貼り付けなど) には、コンテキスト メニューを使います。  


ダイアログとポップアップにより、ユーザーが重要な情報を認識していることを確認できますが、ユーザー エクスペリエンスは中断されます。 ダイアログはモーダル (ブロック) であるため、ユーザーは中断され、ダイアログの操作を行うまで他の操作を行うことはできません。 ポップアップの煩わしさはダイアログより低くなりますが、多用すると、煩わしくなります。

伝える情報の重要度が、ユーザーを中断させる必要があるものかどうかを、よく検討する必要があります。 また、情報の表示頻度を検討し、数分ごとにダイアログや通知を表示している場合には、代わりにプライマリ UI でこの情報用の領域を割り当てることを検討します。 たとえばチャット クライアントで、友人がログインするたびにポップアップを表示させるよりも、その時点でオンラインである友人の一覧を表示し、ログインが行われたときには強調表示させるなどの方法を検討します。

ダイアログは、アクション (ファイルの削除など) を実行する前に確認するために、よく使用されます。 ユーザーが特定の操作を頻繁に実行することが想定される場合には、ユーザーがアクションを毎回確認する必要があるようにするよりも、誤って操作した場合に、ユーザーが元に戻せる方法を提供することを検討します。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> または <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> の動作を確認してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="dialogs-vs-flyouts"></a>ダイアログとポップアップの比較

ダイアログかポップアップを使用すると決めた場合には、どちらを選択する必要があります。

ダイアログは操作をブロックし、ポップアップはブロックしないため、ダイアログの使用は、ユーザーが他のすべてを中断して情報や回答の提供に集中する必要がある状況に限定する必要があります。 一方ポップアップは、ユーザーに情報を知らせるが、ユーザーがそれを無視してもよい場合に使用します。

:::row::: :::column:::
   <p><b>ダイアログの用途:</b> <br/>
<ul>
<li>続行前にユーザーが読んだり確認したりする<b>必要のある重要な</b>情報を表示する場合。 次のようなシナリオが考えられます。
<ul>
  <li>ユーザーのセキュリティが侵害される可能性がある場合</li>
  <li>ユーザーが重要な資産に永続的な変更を加えようとしている場合</li>
  <li>ユーザーが重要な資産を削除しようとしている場合</li>
  <li>アプリ内購入を確認する場合</li>
</ul>

</li>
<li>接続エラーなど、アプリ全体の状況に適用されるエラー メッセージ</li>
<li>アプリからユーザーにブロック質問を表示する必要がある場合 (アプリで自動的に選ぶことができない場合など) ブロック質問とは、無視したり先送りにしたりできない質問です。この質問では、ユーザーに明確な選択肢を提示する必要があります。</li>
</ul>
</p>
:::column-end::: :::column::: <p><b>ポップアップの用途:</b> <br/>
<ul>
<li>操作を完了する前に、必要な追加情報を収集する場合。</li>
<li>一部の場合のみに意味がある情報を表示する場合。 たとえばフォト ギャラリー アプリで、ユーザーが画像のサムネイルをクリックした場合に、大きな画像を表示するためにポップアップを使用できます。</li>
<li>詳細やページ上の項目の長い説明などの詳しい情報の表示。</li>
</ul></p>
:::column-end::: :::row-end:::



## <a name="dialogs"></a>ダイアログ
### <a name="general-guidelines"></a>一般的なガイドライン

-   ダイアログ内のテキストの 1 行目で、問題やユーザーの目的 (実行する内容) を明確に示す必要があります。
-   ダイアログのタイトルは主な説明で、省略可能です。
    -   簡潔なタイトルを使って、ユーザーがそのダイアログで行う必要がある操作を説明します。
    -   ダイアログを使って、簡単なメッセージ、エラー、または質問を表示する場合は、タイトルを省略することもできます。 主な情報はコンテンツのテキストを使って伝えます。
    -   タイトルは、ボタンの選択に直接関連するものにします。
-   ダイアログ コンテンツには説明のテキストを含め、これは必須です。
    -   メッセージ、エラー、または操作をブロック質問をできる限り簡潔に示します。
    -   ダイアログ タイトルを使う場合は、コンテンツ領域を詳しい情報の提示や用語の定義に使います。 タイトルの言葉づかいを変えただけの文を繰り返さないようにします。
-   少なくとも 1 つのダイアログ ボタンを表示する必要があります。
    -   ダイアログに、安全で非破壊的なアクションに対応する "OK"、"閉じる"、"キャンセル" などのボタンが少なくとも 1 つのあるようにします。 このボタンを追加するには、CloseButton API を使用します。
    -   ボタンのテキストには、主な説明またはコンテンツに対する具体的な応答を使用します。 たとえば、主な説明が "使っているコンピューターへの AppName からのアクセスを許可しますか?" の場合、"許可" ボタンと "ブロック" ボタンを使います。 具体的な応答の言葉はすばやく理解できるので、効率的に判断できます。
    - アクション ボタンのテキストは簡潔にします。 短い文字列にすると、ユーザーがすばやく確実に選択できるようになります。
    - 安全で非破壊的なアクションに加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。 このような "処理実行" アクション ボタンでは、ダイアログの重要な点を確認します。 このような "処理実行" アクションを追加するには、PrimaryButton API と SecondaryButton API を使用します。
    - "処理実行" アクション ボタンは一番左のボタンとして表示されます。 安全で非破壊的なアクションは一番右のボタンとして表示されます。
    - 必要に応じて、ダイアログの 3 つのボタンのうちの 1 つを既定のボタンとして区別できます。 ボタンの 1 つを区別するには DefaultButton API を使用します。  
-   パスワード フィールドの検証エラーなど、ページの特定の場所に関連するエラーでは、ダイアログを使わずに、アプリのキャンバス自体を使ってインライン エラーを表示します。
- ダイアログ エクスペリエンスを構築するには、[ContentDialog クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)を使います。 非推奨の MessageDialog API は使わないでください。

### <a name="dialog-scenarios"></a>ダイアログのシナリオ
ダイアログでユーザー操作がブロックされたとき、ユーザーがダイアログを閉じる主な方法はボタンであるため、ダイアログに "閉じる" や "OK" などの安全で非破壊的なボタンが少なくとも 1 つは含まれるようにします。 **すべてのダイアログには、ダイアログを閉じるための少なくとも 1 つの安全なアクション ボタンを含める必要があります。** これにより、ユーザーはアクションを実行することなく安心してダイアログを閉じることができます。<br>![ボタンを 1 つ備えたダイアログ](images/dialogs/dialog_RS2_one_button.png)

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

ダイアログにブロック質問を表示する場合、ダイアログには質問に関連するアクション ボタンを表示する必要があります。 安全で非破壊的なボタンは、1 つまたは 2 つの "処理実行" アクション ボタンを伴っている場合があります。 複数のオプションを表示するときは、提示されている質問に関して "処理実行" アクションと安全な "処理非実行" アクションをボタンが明確に示すようにします。

![ボタンを 2 つ備えたダイアログ](images/dialogs/dialog_RS2_two_button.png)

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

ボタンを 3 つ備えたダイアログは、2 つの "処理実行" アクションと 1 つの "処理非実行" アクションを表示するときに使用します。 ボタンを 3 つ備えたダイアログは、セカンダリ アクションと安全な "閉じる" アクションを明確に区別して慎重に使用する必要があります。

![ボタンを 3 つ備えたダイアログ](images/dialogs/dialog_RS2_three_button.png)

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

### <a name="the-three-dialog-buttons"></a>ダイアログの 3 つのボタン
ContentDialog には、ダイアログ エクスペリエンスを構築するために使用できる、3 種類のボタンがあります。

- **CloseButton** - 必須 - ユーザーがダイアログを終了できる安全で非破壊的なアクションを表します。 一番右のボタンとして表示されます。
- **PrimaryButton** - 省略可能 - 1 つ目の "処理実行" アクションを表します。 一番左のボタンとして表示されます。
- **SecondaryButton** - 省略可能 - 2 つ目の "処理実行" アクションを表します。 中央のボタンとして表示されます。

組み込みのボタンを使用すると、ボタンが適切な位置に表示され、キーボード イベントに正しく反応し、コマンド領域がスクリーン キーボード使用時にも表示されたままになり、ダイアログの外観が他のダイアログと一貫性のあるものになります。

#### <a name="closebutton"></a>CloseButton
すべてのダイアログには、ユーザーが安心してダイアログを終了できる、安全で非破壊的なアクション ボタンが含まれる必要があります。

このボタンを作成するには、ContentDialog.CloseButton API を使用します。 これにより、マウス、キーボード、タッチ、およびゲームパッドを含むすべての入力に対して、適切なユーザー エクスペリエンスを作成することができます。 このエクスペリエンスは以下の場合に発生します。
<ol>
    <li>ユーザーが CloseButton をクリックまたはタップする </li>
    <li>ユーザーがシステムの戻るボタンを押す </li>
    <li>ユーザーがキーボードの Esc キーを押す </li>
    <li>ユーザーがゲームパッドの B を押す </li>
</ol>

ユーザーがダイアログのボタンをクリックすると、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは [ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) を返して、ユーザーがクリックしたボタンを伝えます。 CloseButton を押すと ContentDialogResult.None が返されます。

#### <a name="primarybutton-and-secondarybutton"></a>PrimaryButton と SecondaryButton
CloseButton に加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。
1 つ目の "処理実行" アクションには PrimaryButton、2 つ目の "処理実行" アクションには SecondaryButton を使います。 ボタンを 3 つ備えたダイアログでは、通常、PrimaryButton は肯定的な "処理実行" アクションを示し、SecondaryButton は中立的または二次的な "処理実行" アクションを示します。
たとえば、ユーザーがアプリからサービスに登録するように求められる場合があります。 肯定的な "処理実行" アクションとして PrimaryButton は "サブスクライブする" というテキストを表示し、中立的な "処理実行" アクションとして SecondaryButton は "試してみる" というテキストを表示します。 CloseButton は、ユーザーがいずれのアクションも実行せずにキャンセルできるようにします。

ユーザーが PrimaryButton をクリックすると、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは ContentDialogResult.Primary を返します。
ユーザーが SecondaryButton をクリックすると、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは ContentDialogResult.Secondary を返します。

![ボタンを 3 つ備えたダイアログ](images/dialogs/dialog_RS2_three_button.png)

#### <a name="defaultbutton"></a>DefaultButton
必要に応じて、3 つのボタンのうちの 1 つを既定のボタンとして区別できます。 既定のボタンを指定すると、次のようになります。
- ボタンにアクセント ボタンとして視覚的な効果が適用される
- ボタンが Enter キーに自動的に応答する
    - ユーザーがキーボードの Enter キーを押すと、既定のボタンに関連付けられているクリック ハンドラーが起動し、ContentDialogResult は既定のボタンに関連付けられている値を返す
    - ユーザーが Enter を処理するコントロールにキーボード フォーカスを置いている場合、既定のボタンは Enter が押されても反応しない
- ダイアログのコンテンツにフォーカス可能な UI が含まれていない限り、ダイアログが開くとボタンが自動的にフォーカスされる

既定のボタンを指定するには、ContentDialog.DefaultButton プロパティを使います。 既定では、既定のボタンは設定されていません。

![既定のボタンを含むボタンを 3 つ備えたダイアログ](images/dialogs/dialog_RS2_three_button_default.png)

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

### <a name="confirmation-dialogs-okcancel"></a>確認ダイアログ ([OK]/[キャンセル])
確認ダイアログにより、ユーザーはアクションを実行するかどうかを確認できます。 アクションを確認するか、キャンセルを選択することができます。  
一般的な確認ダイアログ ボックスには、確認 ([OK]) ボタンと [キャンセル] ボタンの 2 つのボタンがあります。  

<ul>
    <li>
        <p>一般的に、確認ボタンは左側 (プライマリ ボタン) にあり、[キャンセル] ボタン (セカンダリ ボタン) は右側にあります。</p>
        <img alt="An OK/cancel dialog" src="images/dialogs/dialog_RS2_delete_file.png" />
    </li>
    <li>一般的な推奨事項のセクションで説明したように、テキストを指定したボタンを使って、主な説明またはコンテンツに対する具体的な応答を示します。
    </li>
</ul>

> 一部のプラットフォームでは、左側ではなく、右側に確認ボタンが配置されます。 それでは、左側に確認ボタンを配置するのはなぜでしょうか。  ユーザーの大部分が右利きであり、右手でスマートフォンを保持すると想定した場合、実際に確認ボタンが左側にある方がボタンを押しやすくなります。これは、ボタンがユーザーの親指が描く円弧上にある可能性が高くなるためです。画面の右側にボタンがある場合、ユーザーは親指を内側に引いて操作しにくい位置に移動する必要があります。

### <a name="create-a-dialog"></a>ダイアログの作成
ダイアログを作成するには、[ContentDialog クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)を使用します。 ダイアログはコードまたはマークアップで作成できます。 通常は UI 要素を XAML で定義する方が容易ですが、単純なダイアログの場合には、コードを記述する方が実際には容易です。 この例では、ダイアログを作成して、ユーザーに WiFi 接続がないことの通知を行い、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync)メソッドを使ってそれを表示しています。

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

ユーザーがダイアログのボタンをクリックすると、[ShowAsync](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync)メソッドは [ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) を返して、ユーザーがクリックしたボタンを伝えます。

この例でのダイアログは、質問を行い、[ContentDialogResult](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) の戻り値を使用してユーザーの応答を確認します。

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

## <a name="flyouts"></a>ポップアップ
###  <a name="create-a-flyout"></a>ポップアップの作成

ポップアップは、コンテンツとして任意の UI を表示できる簡易非表示コンテナーです。 ポップアップには、他のポップアップやコンテキスト メニューを含めて、入れ子になったエクスペリエンスを作成することができます。

![ポップアップ内で入れ子になったコンテキスト メニュー](images/flyout-nested.png)

ポップアップは、特定のコントロールにアタッチされます。 [Placement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.Placement) プロパティを使って、ポップアップが表示される場所 (上、左、下、右、またはフル) を指定します。 [完全配置モード](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode)を選択した場合、アプリはポップアップを拡大し、アプリ ウィンドウ内の中央に配置します。 [Button](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Button)などの一部のコントロールは、ポップアップや[コンテキスト メニュー](menus.md)を関連付けるために使用できる [Flyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Button.Flyout) プロパティを提供します。

この例では、ボタンが押されたときに、いくつかのテキストを表示するシンプルなポップアップを作成します。
````xaml
<Button Content="Click me">
  <Button.Flyout>
     <Flyout>
        <TextBlock Text="This is a flyout!"/>
     </Flyout>
  </Button.Flyout>
</Button>
````

コントロールに Flyout プロパティがない場合には、代わりに [FlyoutBase.AttachedFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.AttachedFlyoutProperty) 添付プロパティを使用できます。 これを行う場合には、さらに [FlyoutBase.ShowAttachedFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase#Windows_UI_Xaml_Controls_Primitives_FlyoutBase_ShowAttachedFlyout_Windows_UI_Xaml_FrameworkElement_)メソッドを呼び出して、ポップアップを表示する必要があります。

この例では、画像に簡単なポップアップを追加します。 ユーザーが画像をタップしたときに、アプリはポップアップを表示します。

````xaml
<Image Source="Assets/cliff.jpg" Width="50" Height="50"
  Margin="10" Tapped="Image_Tapped">
  <FlyoutBase.AttachedFlyout>
    <Flyout>
      <TextBlock Text="This is some text in a flyout."  />
    </Flyout>        
  </FlyoutBase.AttachedFlyout>
</Image>
````

````csharp
private void Image_Tapped(object sender, TappedRoutedEventArgs e)
{
    FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
}
````

前に示した例では、ポップアップはインラインで定義されています。 ポップアップを静的なリソースとして定義して、複数の要素で使用することもできます。 この例では、サムネイルがタップされたときに大きな画像を表示する、より複雑なポップアップを作成します。

````xaml
<!-- Declare the shared flyout as a resource. -->
<Page.Resources>
    <Flyout x:Key="ImagePreviewFlyout" Placement="Right">
        <!-- The flyout's DataContext must be the Image Source
             of the image the flyout is attached to. -->
        <Image Source="{Binding Path=Source}"
            MaxHeight="400" MaxWidth="400" Stretch="Uniform"/>
    </Flyout>
</Page.Resources>
````

````xaml
<!-- Assign the flyout to each element that shares it. -->
<StackPanel>
    <Image Source="Assets/cliff.jpg" Width="50" Height="50"
           Margin="10" Tapped="Image_Tapped"
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
    <Image Source="Assets/grapes.jpg" Width="50" Height="50"
           Margin="10" Tapped="Image_Tapped"
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
    <Image Source="Assets/rainier.jpg" Width="50" Height="50"
           Margin="10" Tapped="Image_Tapped"
           FlyoutBase.AttachedFlyout="{StaticResource ImagePreviewFlyout}"
           DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}"/>
</StackPanel>
````

````csharp
private void Image_Tapped(object sender, TappedRoutedEventArgs e)
{
    FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);  
}
````

### <a name="style-a-flyout"></a>ポップアップのスタイルを設定する
ポップアップのスタイルを設定するには、[FlyoutPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout.FlyoutPresenterStyle) を変更します。 次の例では、テキストの折り返しの段落を示し、スクリーン リーダーがテキスト ブロックにアクセスできるようにします。

![折り返しのあるテキストを使ったアクセシビリティ対応のポップアップ](images/flyout-wrapping-text.png)

````xaml
<Flyout>
  <Flyout.FlyoutPresenterStyle>
    <Style TargetType="FlyoutPresenter">
      <Setter Property="ScrollViewer.HorizontalScrollMode"
          Value="Disabled"/>
      <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"/>
      <Setter Property="IsTabStop" Value="True"/>
      <Setter Property="TabNavigation" Value="Cycle"/>
    </Style>
  </Flyout.FlyoutPresenterStyle>
  <TextBlock Style="{StaticResource BodyTextBlockStyle}" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."/>
</Flyout>
````

#### <a name="styling-flyouts-for-10-foot-experience"></a>10 フィート エクスペリエンス向けのポップアップのスタイル指定

ポップアップなどの簡易非表示コントロールは、閉じるまでの間、一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。 この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。 この動作は、[`LightDismissOverlayMode`](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.LightDismissOverlayMode) プロパティを使用して変更できます。 既定では、ポップアウトは Xbox で簡易非表示オーバーレイを描画し、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常に**オン**にするか、常に**オフ**にするかを選択できます。

![ポップアップと暗転オーバーレイ](images/flyout-smoke.png)

```xaml
<MenuFlyout LightDismissOverlayMode="On">
```

### <a name="light-dismiss-behavior"></a>簡易非表示の動作
ポップアウトは、次のクイック簡易非表示アクションで閉じることができます。
-   ポップアップの外側をタップする
-   Esc キーを押す
-   ハードウェアまたはソフトウェアのシステムの戻るボタンを押す
-   ゲームパッドの B ボタンを押す

タップで非表示にする場合、通常ではこのジェスチャは吸収されて下の UI に渡されません。 たとえば、開いているポップアウトの背後にボタンが見えている場合、ユーザーが 1 回目のタップでポップアップを閉じても、このボタンはアクティブ化されません。 ボタンを押すには、もう 1 回タップする必要があります。

この動作は、ボタンをポップアウトの入力パススルー要素として指定することで変更できます。 上記の簡易非表示アクションの結果、ポップアウトが閉じます。また、タップ イベントがその指定された `OverlayInputPassThroughElement` に渡されます。 機能的に似た項目でユーザー操作を高速化するには、この動作の採用を検討します。 アプリにお気に入りのコレクションがあり、コレクションの各項目にアタッチされたポップアウトがある場合は、ユーザーがすばやく連続して複数のポップアウトを操作したい可能性があると考えるのが妥当です。

[!NOTE] 破壊的なアクションを実行するオーバーレイの入力パススルー要素を指定しないように注意します。 ユーザーは、プライマリ UI をアクティブ化しない、控えめな簡易非表示アクションに慣れています。 予期しない動作や中断動作を避けるために、閉じる、削除、または同様の破壊的なボタンは簡易非表示でアクティブ化しないでください。

次の例では、FavoritesBar にある 3 つすべてのボタンが 1 回目のタップでアクティブ化されます。

````xaml
<Page>
    <Page.Resources>
        <Flyout x:Name="TravelFlyout" x:Key="TravelFlyout"
                OverlayInputPassThroughElement="{x:Bind FavoritesBar}">
            <StackPanel>
                <HyperlinkButton Content="Washington Trails Association"/>
                <HyperlinkButton Content="Washington Cascades - Go Northwest! A Travel Guide"/>  
            </StackPanel>
        </Flyout>
    </Page.Resources>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="FavoritesBar" Orientation="Horizontal">
            <HyperlinkButton x:Name="PageLinkBtn">Bing</HyperlinkButton>  
            <Button x:Name="Folder1" Content="Travel" Flyout="{StaticResource TravelFlyout}"/>
            <Button x:Name="Folder2" Content="Entertainment" Click="Folder2_Click"/>
        </StackPanel>
        <ScrollViewer Grid.Row="1">
            <WebView x:Name="WebContent"/>
        </ScrollViewer>
    </Grid>
</Page>
````
````csharp
private void Folder2_Click(object sender, RoutedEventArgs e)
{
     Flyout flyout = new Flyout();
     flyout.OverlayInputPassThroughElement = FavoritesBar;
     ...
     flyout.ShowAt(sender as FrameworkElement);
{
````

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事
- [ヒント](tooltips.md)
- [メニューとコンテキスト メニュー](menus.md)
- [Flyout クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout)
- [ContentDialog クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)
