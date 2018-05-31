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
ms.openlocfilehash: f663ce9da6453922e35f850a8cd039f33770f434
ms.sourcegitcommit: 4b522af988273946414a04fbbd1d7fde40f8ba5e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/08/2018
ms.locfileid: "1494169"
---
# <a name="buttons"></a>ボタン


ボタンは、特定の操作を直ちに実行する手段をユーザーに提供します。

> **重要な API**: [Button クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)、[RepeatButton クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx)、[Click イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx)

![ボタンの例](images/controls/button.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ボタンを使うと、ユーザーは直ちに操作を開始できます (フォームの送信など)。

他のページに移動する操作では、ボタンは使わず、リンクを使います。 詳しくは、「[ハイパーリンク](hyperlinks.md)」をご覧ください。
> 例外: ウィザードでのページの移動には、[戻る] と [次へ] というラベルのボタンを使います。 他の種類の前に戻る移動や上位レベルへの移動では、[戻る] ボタンを使います。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Button">アプリを開き、Button の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

この例では、一情報へのアクセスを求めるダイアログ ボックスで、2 つのボタン ([Allow] (許可) と [Block] (禁止)) を使っています。

![ダイアログで使われるボタンの例](images/dialogs/dialog_RS2_two_button.png)

## <a name="create-a-button"></a>ボタンの作成

クリックに応答するボタンの例を次に示します。

XAML でボタンを作成します。

```xaml
<Button Content="Subscribe" Click="SubscribeButton_Click"/>
```

または、コードでボタンを作成します。

```csharp
Button subscribeButton = new Button();
subscribeButton.Content = "Subscribe";
subscribeButton.Click += SubscribeButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(subscribeButton);
```

Click イベントを処理します。

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

### <a name="button-interaction"></a>ボタンの対話式操作

ポインターがボタンの上にあるときに、指やスタイラスでそのボタンをタップするか、マウスの左ボタンを押すと、ボタンでは [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントが発生します。 ボタンにキーボード フォーカスがある場合は、Enter キーまたは Space キーを押しても、Click イベントが発生します。

通常、ボタンでは低レベルな [PointerPressed](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) イベントを処理できません。これに代わる Click 動作があるためです。 詳しくは、「[イベントとルーティング イベントの概要](https://msdn.microsoft.com/library/windows/apps/mt185584.aspx)」をご覧ください。

ボタンで Click イベントが発生する方法を変えるには、[ClickMode](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.clickmode) プロパティを変更します。 ClickMode の既定値は **Release** ですが、ボタンの ClickMode を **Hover** または **Press** に設定することもできます。 ClickMode が **Hover** の場合、キーボード操作やタッチ操作によって Click イベントを発生させることはできません。


### <a name="button-content"></a>ボタンのコンテンツ

ボタンは [ContentControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx) です。 その XAML コンテンツ プロパティは [Content](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx) であり、`<Button>A button's content</Button>` のような XAML 構文を使用できます。 任意のオブジェクトをボタンのコンテンツとして設定できます。 コンテンツが [UIElement](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx) の場合、ボタンにレンダリングされます。 コンテンツが別のタイプのオブジェクトの場合、その文字列表現がボタンに表示されます。

ボタンのコンテンツは、通常はテキストです。 テキスト コンテンツの付いたボタンの設計に関する推奨事項を次に示します。
-   ボタンによって行われる操作を明確に説明する、簡潔で具体的でわかりやすいテキストを使います。 通常、ボタンのテキスト コンテンツは、1 語の動詞です。
-   ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。
-   短いテキストでは、120px の最小ボタン幅を使用し、幅が狭いコマンド ボタンは使わないようにします。
- 長いテキストでは、テキストを最大文字数 26 文字に制限し、さまざまなコマンド ボタンは使わないようにします。
-   ボタンのテキスト コンテンツが動的な場合 ([ローカライズされる](../globalizing/globalizing-portal.md) 場合など) は、ボタンのサイズがどのように変化し、その周囲のコントロールに何が起こるかを考えます。

<table>
<tr>
<td> <b>必要な修正:</b><br> オーバーフロー テキストの付いたボタン。 </td>
<td> <img src="images/button-wraptext.png"/> </td>
</tr>
<tr>
<td> <b>オプション 1:</b><br> テキストの長さが 26 文字より大きい場合は、ボタンの幅やスタック ボタンを増やし、テキストを折り返します。 </td>
<td> <img src="images/button-wraptext1.png"> </td>
</tr>
<tr>
<td> <b>オプション 2:</b><br> ボタンの高さを増やし、テキストを折り返します。 </td>
<td> <img src="images/button-wraptext2.png"> </td>
</tr>
</table>

ボタンの外観を構成する視覚効果をカスタマイズすることもできます。 たとえば、テキストをアイコンに置き換えたり、アイコンとテキストを使用したりできます。

ここでは、画像とテキストを含む **StackPanel** がボタンのコンテンツとして設定されます。

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

ボタンは次のように表示されます。

![画像とテキスト コンテンツがあるボタン](images/button-orange.png)

## <a name="create-a-repeat-button"></a>繰り返しボタンの作成

[RepeatButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) は、ボタンが押されてから離されるまで、繰り返し [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントを発生させるボタンです。 ボタンが押されてからクリック操作の繰り返しを始めるまでの RepeatButton の待ち時間を指定するには、[Delay](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) プロパティを設定します。 クリック操作の繰り返し間隔を指定するには、[Interval](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) プロパティを設定します。 これらのプロパティの時間はどちらもミリ秒単位で指定します。

次の例は 2 つの RepeatButton コントロールを示しています。それぞれの Click イベントを使って、テキスト ブロックに表示される値を増減します。

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

## <a name="recommendations"></a>推奨事項
-   ボタンの用途と状態をユーザーがはっきりと理解できるようにします。
-   同じ意思決定に対して複数のボタンが存在する場合 (確認のダイアログなど)、コミット ボタンは次の順番で提示します。この "[実行する]" と "[実行しない]" は、メインの指示に対応する具体的な文になります。
    -   [OK]/[実行する]/[はい]
    -   [実行しない]/[いいえ]
    -   [キャンセル]
-   ユーザーに対して表示するボタンは、1 つまたは 2 つにします (例: [承諾] と [キャンセル])。 3 つ以上の操作をユーザーに示す必要がある場合は、ユーザーが操作を選択できる [チェック ボックス](checkbox.md) または [オプション ボタン](radio-button.md) を、それらの操作を開始するための 1 つのコマンド ボタンと共に使うことを検討します。
-   ある操作をアプリの複数のページで実行できるようにするには、各ページでボタンを使うのではなく、[下部のアプリ バー](app-bars.md) を使うことを検討します。

### <a name="recommended-single-button-layout"></a>単一のボタンの推奨レイアウト

ボタンを 1 つしか必要としないレイアウトでは、コンテナーのコンテキストに応じて、左揃えまたは右揃えにします。

-   ボタンが 1 つだけのダイアログでは、ボタンを**右揃え**にします。 ダイアログにボタンが 1 つしかない場合は、ボタンによって安全で非破壊的な操作が実行されるようにします。 [ContentDialog](dialogs.md) を使い、単一のボタンを指定する場合は、自動的に右揃えになります。

![ダイアログ内のボタン](images/pushbutton_doc_dialog.png)

-   ボタンがコンテナー UI 内 (トースト通知、ポップアップ、またはリスト ビュー項目内など) に表示される場合は、コンテナー内でボタンを**左揃え**にします。

![コンテナー内のボタン](images/pushbutton_doc_container.png)

-   ページに含まれるボタンが 1 つだけの場合は (設定ページの下部にある [適用] ボタンなど)、ボタンを**左揃え**にします。 これで、ページのその他のコンテンツとボタンを揃えて配置できます。

![ページのボタン](images/pushbutton_doc_page.png)

## <a name="back-buttons"></a>戻るボタン

戻るボタンは、バック スタックまたはユーザーのナビゲーション履歴を使って "戻る" ナビゲーションを実現する、システムの UI 要素です。 独自の"戻る"ボタンを作成する必要はありませんが、前に戻る移動で適切なエクスペリエンスを提供するために作業が必要になることがあります。 詳しくは、「[履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。


## <a name="related-articles"></a>関連記事
- [Button クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)
- [ラジオ ボタン](radio-button.md)
- [チェック ボックス](checkbox.md)
- [トグル スイッチ](toggles.md)
