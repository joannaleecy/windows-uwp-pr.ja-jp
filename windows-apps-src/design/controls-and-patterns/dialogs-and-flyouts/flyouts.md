---
Description: ダイアログとポップアップは、ユーザーが要求したとき、または通知や許可を必要とする状況が発生したときに表示される一時的な UI 要素です。
title: Flyout コントロール
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: ad6affd9-a3c0-481f-a237-9a1ecd561be8
pm-contact: yulikl
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 52de0933bf51adaae6b0923868e12eb92ced4a1a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57625017"
---
# <a name="flyouts"></a>ポップアップ

ポップアップは、コンテンツとして任意の UI を表示できる簡易非表示コンテナーです。 ポップアップには、他のポップアップやコンテキスト メニューを含めて、入れ子になったエクスペリエンスを作成することができます。

![ポップアップ内で入れ子になったコンテキスト メニュー](../images/flyout-nested.png)

> **重要な Api**:[フライアウト クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

* [ヒント](../tooltips.md)や[コンテキスト メニュー](../menus.md)の変わりにポップアップを使用しないようにします。 指定した時間が経過すると非表示になる短い説明を表示するには、ヒントを使います。 UI 要素に関連した状況依存の操作 (コピーや貼り付けなど) には、コンテキスト メニューを使います。

(のようなコントロール) ダイアログ ボックスを使用する場合とポップアップを使用する場合の推奨事項を参照してください[ダイアログとフライアウト](index.md)します。 

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="../images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> または <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> の動作を確認してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></li>
    </ul>
</td>
</tr>
</table>

##  <a name="how-to-create-a-flyout"></a>フライアウトを作成する方法


ポップアップは、特定のコントロールにアタッチされます。 使用することができます、[配置](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.Placement)フライアウトが表示される場所を指定するプロパティ。上、左、下、右、または完全な。 [完全配置モード](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode)を選択した場合、アプリはポップアップを拡大し、アプリ ウィンドウ内の中央に配置します。 [Button](/uwp/api/Windows.UI.Xaml.Controls.Button)などの一部のコントロールは、ポップアップや[コンテキスト メニュー](../menus.md)を関連付けるために使用できる [Flyout](/uwp/api/Windows.UI.Xaml.Controls.Button.Flyout) プロパティを提供します。

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

## <a name="style-a-flyout"></a>ポップアップのスタイルを設定する
ポップアップのスタイルを設定するには、[FlyoutPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout.FlyoutPresenterStyle) を変更します。 次の例では、テキストの折り返しの段落を示し、スクリーン リーダーがテキスト ブロックにアクセスできるようにします。

![折り返しのあるテキストを使ったアクセシビリティ対応のポップアップ](../images/flyout-wrapping-text.png)

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

## <a name="styling-flyouts-for-10-foot-experiences"></a>ある 10 フィート エクスペリエンスのフライアウトをスタイル設定

ポップアップなどの簡易非表示コントロールは、閉じるまでの間、一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。 この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。 この動作は、[`LightDismissOverlayMode`](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.LightDismissOverlayMode) プロパティを使用して変更できます。 既定では、ポップアウトは Xbox で簡易非表示オーバーレイを描画し、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常に**オン**にするか、常に**オフ**にするかを選択できます。

![ポップアップと暗転オーバーレイ](../images/flyout-smoke.png)

```xaml
<MenuFlyout LightDismissOverlayMode="On">
```

## <a name="light-dismiss-behavior"></a>簡易非表示の動作
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

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事
- [ヒント](../tooltips.md)
- [メニューとコンテキスト メニュー](../menus.md)
- [フライアウト クラス](/uwp/api/Windows.UI.Xaml.Controls.Flyout)
- [ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)