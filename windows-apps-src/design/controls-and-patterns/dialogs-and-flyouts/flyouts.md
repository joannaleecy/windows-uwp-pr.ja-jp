---
author: mijacobs
Description: Dialogs and flyouts display transient UI elements that appear when the user requests them or when something happens that requires notification or approval.
title: ポップアップ コントロール
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: ad6affd9-a3c0-481f-a237-9a1ecd561be8
pm-contact: yulikl
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: e68f8f48ca9ba67a29c8a52a5d59767a080f642b
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7119432"
---
# <a name="flyouts"></a><span data-ttu-id="41885-103">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="41885-103">Flyouts</span></span>

<span data-ttu-id="41885-104">ポップアップは、コンテンツとして任意の UI を表示できる簡易非表示コンテナーです。</span><span class="sxs-lookup"><span data-stu-id="41885-104">A flyout is a light dismiss container that can show arbitrary UI as its content.</span></span> <span data-ttu-id="41885-105">ポップアップには、他のポップアップやコンテキスト メニューを含めて、入れ子になったエクスペリエンスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="41885-105">Flyouts can contain other flyouts or context menus to create a nested experience.</span></span>

![ポップアップ内で入れ子になったコンテキスト メニュー](../images/flyout-nested.png)

> <span data-ttu-id="41885-107">**重要な Api**: [Flyout クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout)</span><span class="sxs-lookup"><span data-stu-id="41885-107">**Important APIs**: [Flyout class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="41885-108">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="41885-108">Is this the right control?</span></span>

* <span data-ttu-id="41885-109">[ヒント](../tooltips.md)や[コンテキスト メニュー](../menus.md)の変わりにポップアップを使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="41885-109">Don't use a flyout instead of [tooltip](../tooltips.md) or [context menu](../menus.md).</span></span> <span data-ttu-id="41885-110">指定した時間が経過すると非表示になる短い説明を表示するには、ヒントを使います。</span><span class="sxs-lookup"><span data-stu-id="41885-110">Use a tooltip to show a short description that hides after a specified time.</span></span> <span data-ttu-id="41885-111">UI 要素に関連した状況依存の操作 (コピーや貼り付けなど) には、コンテキスト メニューを使います。</span><span class="sxs-lookup"><span data-stu-id="41885-111">Use a context menu for contextual actions related to a UI element, such as copy and paste.</span></span>

<span data-ttu-id="41885-112">使用する場合の推奨事項については、ポップアップとダイアログ (のようなコントロール) を使用する場合に、[ダイアログとポップアップ](index.md)が参照してください。</span><span class="sxs-lookup"><span data-stu-id="41885-112">For recommendations on when to use a flyout vs. when to use a dialog (a similar control), see [Dialogs and flyouts](index.md).</span></span> 

## <a name="examples"></a><span data-ttu-id="41885-113">例</span><span class="sxs-lookup"><span data-stu-id="41885-113">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="41885-114">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="41885-114">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="../images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="41885-115"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> または <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="41885-115">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> or <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> in action.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="41885-116">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="41885-116">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="41885-117">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="41885-117">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

##  <a name="how-to-create-a-flyout"></a><span data-ttu-id="41885-118">ポップアップを作成する方法</span><span class="sxs-lookup"><span data-stu-id="41885-118">How to create a flyout</span></span>


<span data-ttu-id="41885-119">ポップアップは、特定のコントロールにアタッチされます。</span><span class="sxs-lookup"><span data-stu-id="41885-119">Flyouts are attached to specific controls.</span></span> <span data-ttu-id="41885-120">[Placement](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.Placement) プロパティを使って、ポップアップが表示される場所 (上、左、下、右、またはフル) を指定します。</span><span class="sxs-lookup"><span data-stu-id="41885-120">You can use the [Placement](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.Placement) property to specify where a flyout appears: Top, Left, Bottom, Right, or Full.</span></span> <span data-ttu-id="41885-121">[完全配置モード](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode)を選択した場合、アプリはポップアップを拡大し、アプリ ウィンドウ内の中央に配置します。</span><span class="sxs-lookup"><span data-stu-id="41885-121">If you select the [Full placement mode](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode), the app stretches the flyout and centers it inside the app window.</span></span> <span data-ttu-id="41885-122">[Button](/uwp/api/Windows.UI.Xaml.Controls.Button)などの一部のコントロールは、ポップアップや[コンテキスト メニュー](../menus.md)を関連付けるために使用できる [Flyout](/uwp/api/Windows.UI.Xaml.Controls.Button.Flyout) プロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="41885-122">Some controls, such as [Button](/uwp/api/Windows.UI.Xaml.Controls.Button), provide a [Flyout](/uwp/api/Windows.UI.Xaml.Controls.Button.Flyout) property that you can use to associate a flyout or [context menu](../menus.md).</span></span>

<span data-ttu-id="41885-123">この例では、ボタンが押されたときに、いくつかのテキストを表示するシンプルなポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="41885-123">This example creates a simple flyout that displays some text when the button is pressed.</span></span>
````xaml
<Button Content="Click me">
  <Button.Flyout>
     <Flyout>
        <TextBlock Text="This is a flyout!"/>
     </Flyout>
  </Button.Flyout>
</Button>
````

<span data-ttu-id="41885-124">コントロールに Flyout プロパティがない場合には、代わりに [FlyoutBase.AttachedFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.AttachedFlyoutProperty) 添付プロパティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="41885-124">If the control doesn't have a flyout property, you can use the [FlyoutBase.AttachedFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase.AttachedFlyoutProperty) attached property instead.</span></span> <span data-ttu-id="41885-125">これを行う場合には、さらに [FlyoutBase.ShowAttachedFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase#Windows_UI_Xaml_Controls_Primitives_FlyoutBase_ShowAttachedFlyout_Windows_UI_Xaml_FrameworkElement_)メソッドを呼び出して、ポップアップを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="41885-125">When you do this, you also need to call the [FlyoutBase.ShowAttachedFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase#Windows_UI_Xaml_Controls_Primitives_FlyoutBase_ShowAttachedFlyout_Windows_UI_Xaml_FrameworkElement_) method to show the flyout.</span></span>

<span data-ttu-id="41885-126">この例では、画像に簡単なポップアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="41885-126">This example adds a simple flyout to an image.</span></span> <span data-ttu-id="41885-127">ユーザーが画像をタップしたときに、アプリはポップアップを表示します。</span><span class="sxs-lookup"><span data-stu-id="41885-127">When the user taps the image, the app shows the flyout.</span></span>

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

<span data-ttu-id="41885-128">前に示した例では、ポップアップはインラインで定義されています。</span><span class="sxs-lookup"><span data-stu-id="41885-128">The previous examples defined their flyouts inline.</span></span> <span data-ttu-id="41885-129">ポップアップを静的なリソースとして定義して、複数の要素で使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="41885-129">You can also define a flyout as a static resource and then use it with multiple elements.</span></span> <span data-ttu-id="41885-130">この例では、サムネイルがタップされたときに大きな画像を表示する、より複雑なポップアップを作成します。</span><span class="sxs-lookup"><span data-stu-id="41885-130">This example creates a more complicated flyout that displays a larger version of an image when its thumbnail is tapped.</span></span>

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

## <a name="style-a-flyout"></a><span data-ttu-id="41885-131">ポップアップのスタイルを設定する</span><span class="sxs-lookup"><span data-stu-id="41885-131">Style a flyout</span></span>
<span data-ttu-id="41885-132">ポップアップのスタイルを設定するには、[FlyoutPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout.FlyoutPresenterStyle) を変更します。</span><span class="sxs-lookup"><span data-stu-id="41885-132">To style a Flyout, modify its [FlyoutPresenterStyle](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Flyout.FlyoutPresenterStyle).</span></span> <span data-ttu-id="41885-133">次の例では、テキストの折り返しの段落を示し、スクリーン リーダーがテキスト ブロックにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="41885-133">This example shows a paragraph of wrapping text and makes the text block accessible to a screen reader.</span></span>

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

## <a name="styling-flyouts-for-10-foot-experiences"></a><span data-ttu-id="41885-135">10 フィート エクスペリエンス向けのポップアップのスタイル設定</span><span class="sxs-lookup"><span data-stu-id="41885-135">Styling flyouts for 10-foot experiences</span></span>

<span data-ttu-id="41885-136">ポップアップなどの簡易非表示コントロールは、閉じるまでの間、一時的な UI にキーボードのフォーカスやゲームパッドのフォーカスを捕捉します。</span><span class="sxs-lookup"><span data-stu-id="41885-136">Light dismiss controls like flyout trap keyboard and gamepad focus inside their transient UI until dismissed.</span></span> <span data-ttu-id="41885-137">この動作に視覚的な合図を提供するために、Xbox の簡易非表示コントロールは、スコープ外の UI を暗く表示するオーバーレイを描画します。</span><span class="sxs-lookup"><span data-stu-id="41885-137">To provide a visual cue for this behavior, light dismiss controls on Xbox draw an overlay that dims the contrast and visibility of out of scope UI.</span></span> <span data-ttu-id="41885-138">この動作は、[`LightDismissOverlayMode`](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.LightDismissOverlayMode) プロパティを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="41885-138">This behavior can be modified with the [`LightDismissOverlayMode`](/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutBase.LightDismissOverlayMode) property.</span></span> <span data-ttu-id="41885-139">既定では、ポップアウトは Xbox で簡易非表示オーバーレイを描画し、他のデバイス ファミリでは描画しませんが、アプリで強制的にオーバーレイを常に**オン**にするか、常に**オフ**にするかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="41885-139">By default, flyouts will draw the light dismiss overlay on Xbox but not other device families, but apps can choose to force the overlay to be always **On** or always **Off**.</span></span>

![ポップアップと暗転オーバーレイ](../images/flyout-smoke.png)

```xaml
<MenuFlyout LightDismissOverlayMode="On">
```

## <a name="light-dismiss-behavior"></a><span data-ttu-id="41885-141">簡易非表示の動作</span><span class="sxs-lookup"><span data-stu-id="41885-141">Light dismiss behavior</span></span>
<span data-ttu-id="41885-142">ポップアウトは、次のクイック簡易非表示アクションで閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="41885-142">Flyouts can be closed with a quick light dismiss action, including</span></span>
-   <span data-ttu-id="41885-143">ポップアップの外側をタップする</span><span class="sxs-lookup"><span data-stu-id="41885-143">Tap outside the flyout</span></span>
-   <span data-ttu-id="41885-144">Esc キーを押す</span><span class="sxs-lookup"><span data-stu-id="41885-144">Press the Escape keyboard key</span></span>
-   <span data-ttu-id="41885-145">ハードウェアまたはソフトウェアのシステムの戻るボタンを押す</span><span class="sxs-lookup"><span data-stu-id="41885-145">Press the hardware or software system Back button</span></span>
-   <span data-ttu-id="41885-146">ゲームパッドの B ボタンを押す</span><span class="sxs-lookup"><span data-stu-id="41885-146">Press the gamepad B button</span></span>

<span data-ttu-id="41885-147">タップで非表示にする場合、通常ではこのジェスチャは吸収されて下の UI に渡されません。</span><span class="sxs-lookup"><span data-stu-id="41885-147">When dismissing with a tap, this gesture is typically absorbed and not passed on to the UI underneath.</span></span> <span data-ttu-id="41885-148">たとえば、開いているポップアウトの背後にボタンが見えている場合、ユーザーが 1 回目のタップでポップアップを閉じても、このボタンはアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="41885-148">For example, if there’s a button visible behind an open flyout, the user’s first tap dismisses the flyout but does not activate this button.</span></span> <span data-ttu-id="41885-149">ボタンを押すには、もう 1 回タップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="41885-149">Pressing the button requires a second tap.</span></span>

<span data-ttu-id="41885-150">この動作は、ボタンをポップアウトの入力パススルー要素として指定することで変更できます。</span><span class="sxs-lookup"><span data-stu-id="41885-150">You can change this behavior by designating the button as an input pass-through element for the flyout.</span></span> <span data-ttu-id="41885-151">上記の簡易非表示アクションの結果、ポップアウトが閉じます。また、タップ イベントがその指定された `OverlayInputPassThroughElement` に渡されます。</span><span class="sxs-lookup"><span data-stu-id="41885-151">The flyout will close as a result of the light dismiss actions described above and will also pass the tap event to its designated `OverlayInputPassThroughElement`.</span></span> <span data-ttu-id="41885-152">機能的に似た項目でユーザー操作を高速化するには、この動作の採用を検討します。</span><span class="sxs-lookup"><span data-stu-id="41885-152">Consider adopting this behavior to speed up user interactions on functionally similar items.</span></span> <span data-ttu-id="41885-153">アプリにお気に入りのコレクションがあり、コレクションの各項目にアタッチされたポップアウトがある場合は、ユーザーがすばやく連続して複数のポップアウトを操作したい可能性があると考えるのが妥当です。</span><span class="sxs-lookup"><span data-stu-id="41885-153">If your app has a favorites collection and each item in the collection includes an attached flyout, it's reasonable to expect that users may want to interact with multiple flyouts in rapid succession.</span></span>

[!NOTE] <span data-ttu-id="41885-154">破壊的なアクションを実行するオーバーレイの入力パススルー要素を指定しないように注意します。</span><span class="sxs-lookup"><span data-stu-id="41885-154">Be careful not to designate an overlay input pass-through element which results in a destructive action.</span></span> <span data-ttu-id="41885-155">ユーザーは、プライマリ UI をアクティブ化しない、控えめな簡易非表示アクションに慣れています。</span><span class="sxs-lookup"><span data-stu-id="41885-155">Users have become habituated to discreet light dismiss actions which do not activate primary UI.</span></span> <span data-ttu-id="41885-156">予期しない動作や中断動作を避けるために、閉じる、削除、または同様の破壊的なボタンは簡易非表示でアクティブ化しないでください。</span><span class="sxs-lookup"><span data-stu-id="41885-156">Close, Delete or similarly destructive buttons should not activate on light dismiss to avoid unexpected and disruptive behavior.</span></span>

<span data-ttu-id="41885-157">次の例では、FavoritesBar にある 3 つすべてのボタンが 1 回目のタップでアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="41885-157">In the following example, all three buttons inside FavoritesBar will be activated on the first tap.</span></span>

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

## <a name="get-the-sample-code"></a><span data-ttu-id="41885-158">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="41885-158">Get the sample code</span></span>

- <span data-ttu-id="41885-159">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="41885-159">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="41885-160">関連記事</span><span class="sxs-lookup"><span data-stu-id="41885-160">Related articles</span></span>
- [<span data-ttu-id="41885-161">ヒント</span><span class="sxs-lookup"><span data-stu-id="41885-161">Tooltips</span></span>](../tooltips.md)
- [<span data-ttu-id="41885-162">メニューとコンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="41885-162">Menus and context menu</span></span>](../menus.md)
- [<span data-ttu-id="41885-163">Flyout クラス</span><span class="sxs-lookup"><span data-stu-id="41885-163">Flyout class</span></span>](/uwp/api/Windows.UI.Xaml.Controls.Flyout)
- [<span data-ttu-id="41885-164">ContentDialog クラス</span><span class="sxs-lookup"><span data-stu-id="41885-164">ContentDialog class</span></span>](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)