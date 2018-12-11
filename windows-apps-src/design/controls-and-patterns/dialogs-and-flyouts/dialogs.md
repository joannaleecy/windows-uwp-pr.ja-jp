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
ms.openlocfilehash: 520f4bdd72c51cd1508c9e655107ae909f6e4243
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8825787"
---
## <a name="dialog-controls"></a>ダイアログ コントロール

ダイアログ コントロールは、アプリのコンテキスト情報を提供するモーダル UI オーバーレイです。 明示的に閉じられるまでアプリ ウィンドウとのやり取りがブロックされています。 多くの場合、ユーザーに何らかの操作を要求します。

![ダイアログの例](../images/dialogs/dialog_RS2_delete_file.png)


> **重要な Api**: [ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

重要な情報をユーザーに通知したり、アクションが完了する前に確認や追加情報を要求したりするには、ダイアログを使用します。

使用する場合の推奨事項については、ダイアログとポップアップ (のようなコントロール) を使用する場合に、[ダイアログとポップアップ](index.md)が参照してください。 

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="../images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> または <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> の動作を確認してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="general-guidelines"></a>一般的なガイドライン

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
- ダイアログ エクスペリエンスを構築するには、[ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)を使います。 非推奨の MessageDialog API は使わないでください。

## <a name="how-to-create-a-dialog"></a>ダイアログを作成する方法
ダイアログ ボックスを作成するには、[ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)を使用します。 ダイアログはコードまたはマークアップで作成できます。 通常は UI 要素を XAML で定義する方が容易ですが、単純なダイアログの場合には、コードを記述する方が実際には容易です。 この例では、ダイアログを作成して、ユーザーに WiFi 接続がないことの通知を行い、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync)メソッドを使ってそれを表示しています。

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

ユーザーがダイアログのボタンをクリックすると、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync)メソッドは [ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) を返して、ユーザーがクリックしたボタンを伝えます。

この例でのダイアログは、質問を行い、[ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) の戻り値を使用してユーザーの応答を確認します。

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

## <a name="provide-a-safe-action"></a>安全なアクションを提供します。
ダイアログでユーザー操作がブロックされたとき、ユーザーがダイアログを閉じる主な方法はボタンであるため、ダイアログに "閉じる" や "OK" などの安全で非破壊的なボタンが少なくとも 1 つは含まれるようにします。 **すべてのダイアログには、ダイアログを閉じるための少なくとも 1 つの安全なアクション ボタンを含める必要があります。** これにより、ユーザーはアクションを実行することなく安心してダイアログを閉じることができます。<br>![ボタンを 1 つ備えたダイアログ](../images/dialogs/dialog_RS2_one_button.png)

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

ボタンを 3 つ備えたダイアログは、2 つの "処理実行" アクションと 1 つの "処理非実行" アクションを表示するときに使用します。 ボタンを 3 つ備えたダイアログは、セカンダリ アクションと安全な "閉じる" アクションを明確に区別して慎重に使用する必要があります。

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

## <a name="the-three-dialog-buttons"></a>ダイアログの 3 つのボタン
ContentDialog には、ダイアログ エクスペリエンスを構築するために使用できる、3 種類のボタンがあります。

- **CloseButton** - 必須 - ユーザーがダイアログを終了できる安全で非破壊的なアクションを表します。 一番右のボタンとして表示されます。
- **PrimaryButton** - 省略可能 - 1 つ目の "処理実行" アクションを表します。 一番左のボタンとして表示されます。
- **SecondaryButton** - 省略可能 - 2 つ目の "処理実行" アクションを表します。 中央のボタンとして表示されます。

組み込みのボタンを使用すると、ボタンが適切な位置に表示され、キーボード イベントに正しく反応し、コマンド領域がスクリーン キーボード使用時にも表示されたままになり、ダイアログの外観が他のダイアログと一貫性のあるものになります。

### <a name="closebutton"></a>CloseButton
すべてのダイアログには、ユーザーが安心してダイアログを終了できる、安全で非破壊的なアクション ボタンが含まれる必要があります。

このボタンを作成するには、ContentDialog.CloseButton API を使用します。 これにより、マウス、キーボード、タッチ、およびゲームパッドを含むすべての入力に対して、適切なユーザー エクスペリエンスを作成することができます。 このエクスペリエンスは以下の場合に発生します。
<ol>
    <li>ユーザーが CloseButton をクリックまたはタップする </li>
    <li>ユーザーがシステムの戻るボタンを押す </li>
    <li>ユーザーがキーボードの Esc キーを押す </li>
    <li>ユーザーがゲームパッドの B を押す </li>
</ol>

ユーザーがダイアログのボタンをクリックすると、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは [ContentDialogResult](/uwp/api/Windows.UI.Xaml.Controls.ContentDialogResult) を返して、ユーザーがクリックしたボタンを伝えます。 CloseButton を押すと ContentDialogResult.None が返されます。

### <a name="primarybutton-and-secondarybutton"></a>PrimaryButton と SecondaryButton
CloseButton に加え、必要に応じて、主な説明に関連する 1 つまたは 2 つのアクション ボタンをユーザーに対して表示できます。
1 つ目の "処理実行" アクションには PrimaryButton、2 つ目の "処理実行" アクションには SecondaryButton を使います。 ボタンを 3 つ備えたダイアログでは、通常、PrimaryButton は肯定的な "処理実行" アクションを示し、SecondaryButton は中立的または二次的な "処理実行" アクションを示します。
たとえば、ユーザーがアプリからサービスに登録するように求められる場合があります。 肯定的な "処理実行" アクションとして PrimaryButton は "サブスクライブする" というテキストを表示し、中立的な "処理実行" アクションとして SecondaryButton は "試してみる" というテキストを表示します。 CloseButton は、ユーザーがいずれのアクションも実行せずにキャンセルできるようにします。

ユーザーが PrimaryButton をクリックすると、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは ContentDialogResult.Primary を返します。
ユーザーが SecondaryButton をクリックすると、[ShowAsync](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog.ShowAsync) メソッドは ContentDialogResult.Secondary を返します。

![ボタンを 3 つ備えたダイアログ](../images/dialogs/dialog_RS2_three_button.png)

### <a name="defaultbutton"></a>DefaultButton
必要に応じて、3 つのボタンのうちの 1 つを既定のボタンとして区別できます。 既定のボタンを指定すると、次のようになります。
- ボタンにアクセント ボタンとして視覚的な効果が適用される
- ボタンが Enter キーに自動的に応答する
    - ユーザーがキーボードの Enter キーを押すと、既定のボタンに関連付けられているクリック ハンドラーが起動し、ContentDialogResult は既定のボタンに関連付けられている値を返す
    - ユーザーが Enter を処理するコントロールにキーボード フォーカスを置いている場合、既定のボタンは Enter が押されても反応しない
- ダイアログのコンテンツにフォーカス可能な UI が含まれていない限り、ダイアログが開くとボタンが自動的にフォーカスされる

既定のボタンを指定するには、ContentDialog.DefaultButton プロパティを使います。 既定では、既定のボタンは設定されていません。

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

## <a name="confirmation-dialogs-okcancel"></a>確認ダイアログ ([OK]/[キャンセル])
確認ダイアログ ボックスにより、ユーザーはアクションを実行するかどうかを確認できます。 アクションを確認するか、キャンセルを選択することができます。  
一般的な確認ダイアログ ボックスには、確認 ([OK]) ボタンと [キャンセル] ボタンの 2 つのボタンがあります。  

<ul>
    <li>
        <p>一般的に、確認ボタンは左側 (プライマリ ボタン) にあり、[キャンセル] ボタン (セカンダリ ボタン) は右側にあります。</p>
        <img alt="An OK/cancel dialog" src="../images/dialogs/dialog_RS2_delete_file.png" />
    </li>
    <li>一般的な推奨事項のセクションで説明したように、テキストを指定したボタンを使って、主な説明またはコンテンツに対する具体的な応答を示します。
    </li>
</ul>

> 一部のプラットフォームでは、左側ではなく、右側に確認ボタンが配置されます。 それでは、左側に確認ボタンを配置するのはなぜでしょうか。  ユーザーの大部分が右利きであり、右手でスマートフォンを保持すると想定した場合、実際に確認ボタンが左側にある方がボタンを押しやすくなります。これは、ボタンがユーザーの親指が描く円弧上にある可能性が高くなるためです。画面の右側にボタンがある場合、ユーザーは親指を内側に引いて操作しにくい位置に移動する必要があります。





## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事
- [ヒント](../tooltips.md)
- [メニューとコンテキスト メニュー](../menus.md)
- [Flyout クラス](/uwp/api/Windows.UI.Xaml.Controls.Flyout)
- [ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)
