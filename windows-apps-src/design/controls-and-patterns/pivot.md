---
author: QuinnRadich
Description: The Pivot control enables touch-swiping between a small set of content sections.
title: ピボット
template: detail.hbs
ms.author: quradic
ms.date: 06/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: llongley
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 5bb6ed36c772e5ae80a3cb801b4b6b36bb1ab18c
ms.sourcegitcommit: 7efffcc715a4be26f0cf7f7e249653d8c356319b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/30/2018
ms.locfileid: "3116117"
---
# <a name="pivot"></a>ピボット

[ピボット](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)コントロールでは、コンテンツのセクションの少数の間でのタッチ スワイプを使用できます。

> **重要な Api**: [Pivot クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)、 [NavigationView クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.NavigationView)

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Pivot">、アプリを開き Pivot コントロールの動作をご覧ください</a>。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

[NavigationView](navigationview.md)と同様、Pivot コントロールでは、選択した項目に下線します。

![既定のフォーカスでは選択されたヘッダーが下線付きで表示される](images/pivot_focus_selectedHeader.png)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

をタブ パターンの一般的な上部のナビゲーションを実現するのには、 [NavigationView](navigationview.md)、自動的にさまざまな画面サイズに合わせて変化してを自由にカスタマイズでは、これを使用してお勧めします。

ただし、ナビゲーションは、タッチ スワイプを必要とする場合は、ピボットを使って勧めします。

NavigationView とピボット コントロールの他の主な違いは、既定のオーバーフローの動作とナビゲーション API には。

- ユーザーはすべての項目を表示できるように NavigationView メニューのドロップダウンを使用しますが、項目がオーバーフロー カルーセル オーバーフローのピボットします。
- ピボットで NavigationView ではナビゲーションの動作をより細かく制御できますが、コンテンツのセクション間のナビゲーションを処理します。

## <a name="use-navigationview-instead-of-pivot"></a>ピボットではなく NavigationView を使用します。

アプリの UI は、Pivot コントロールを使用している場合は、次のコードでピボットを NavigationView を変換できます。

この XAML では、3 つのセクションの例では、 [pivot コントロールを作成する](#create-a-pivot-control)ピボットなどのコンテンツを NavigationView を作成します。

```xaml
<NavigationView x:Name="rootNavigationView" Header="Category Title"
 ItemInvoked="NavView_ItemInvoked">
    <NavigationView.MenuItems>
        <NavigationViewItem Content="Section 1" x:Name="Section1Content" />
        <NavigationViewItem Content="Section 2" x:Name="Section2Content" />
        <NavigationViewItem Content="Section 3" x:Name="Section3Content" />
    </NavigationView.MenuItems>
</NavigationView>

<Page x:Class="AppName.Section1Page">
    <TextBlock Text="Content of section 1."/>
</Page>

<Page x:Class="AppName.Section2Page">
    <TextBlock Text="Content of section 2."/>
</Page>

<Page x:Class="AppName.Section3Page">
    <TextBlock Text="Content of section 3."/>
</Page>
```

NavigationView は、ナビゲーションのカスタマイズをより細かく制御し、コード ビハインドで対応する必要があります。 上記の XAML を加え、次のコード ビハインドを使用します。

```csharp
private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{
    FrameNavigationOptions navOptions = new FrameNavigationOptions();
    navOptions.TransitionInfoOverride = new SlideNavigationTransitionInfo() {
         SlideNavigationTransitionDirection=args.RecommendedNavigationTransitionInfo
    };

    navOptions.IsNavigationStackEnabled = False;

    switch (item.Name)
    {
        case "Section1Content":
            ContentFrame.NavigateToType(typeof(Section1Page), null, navOptions);
            break;

        case "Section2Content":
            ContentFrame.NavigateToType(typeof(Section2Page), null, navOptions);
            break;

        case "Section3Content":
            ContentFrame.NavigateToType(typeof(Section3Page), null, navOptions);
            break;
    }  
}
```

このコードは、コンテンツのセクション間タッチ スワイプ エクスペリエンス マイナスの Pivot コントロールの組み込みのナビゲーション エクスペリエンスを模倣します。 ただし、わかるように、切り替えのアニメーション化された、ナビゲーション パラメーター、およびスタック機能を含む、いくつかのポイントもカスタマイズする可能性があります。

## <a name="create-a-pivot-control"></a>ピボット コントロールの作成

このコードは、コンテンツの 3 つのセクションの基本的なピボット コントロールを作成します。

```xaml
<Pivot x:Name="rootPivot" Title="Category Title">
    <PivotItem Header="Section 1">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of section 1."/>
    </PivotItem>
    <PivotItem Header="Section 2">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of section 2."/>
    </PivotItem>
    <PivotItem Header="Section 3">
        <!--Pivot content goes here-->
        <TextBlock Text="Content of section 3."/>
    </PivotItem>
</Pivot>
```

### <a name="pivot-items"></a>ピボット項目

Pivot は [ItemsControl](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) であるため、あらゆる種類の項目のコレクションを含めることができます。 ピボットに追加する項目が明示的に [PivotItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivotitem.aspx) ではない場合、PivotItem で暗黙的にラップされます。 ピボットは通常コンテンツのページ間を移動するために使用されるため、XAML UI 要素を使用して直接 [Items](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.items.aspx) コレクションを設定するのが一般的です。 または、[ItemsSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) プロパティをデータ ソースに設定することもできます。 ItemsSource にバインドされている項目は、任意の型にすることができますが、明示的に PivotItem ではない場合は、[ItemTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)と [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.headertemplate.aspx) を定義して、項目を表示する方法を指定する必要があります。

[SelectedItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selecteditem.aspx) プロパティを使って、ピボットのアクティブな項目を取得または設定できます。 アクティブな項目のインデックスを取得または設定するには、[SelectedIndex](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.selectedindex.aspx) プロパティを使います。

### <a name="pivot-headers"></a>ピボット ヘッダー

[LeftHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.leftheader.aspx) プロパティと [RightHeader](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.rightheader.aspx) プロパティを使って、ピボット ヘッダーに他のコントロールを追加できます。

たとえば、[CommandBar](https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/app-bars) をピボットの RightHeader に追加できます。

```xaml
<Pivot>
    <Pivot.RightHeader>
        <CommandBar>
                <AppBarButton Icon="Add"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Edit"/>
                <AppBarButton Icon="Delete"/>
                <AppBarSeparator/>
                <AppBarButton Icon="Save"/>
        </CommandBar>
    </Pivot.RightHeader>
</Pivot>
```

### <a name="pivot-interaction"></a>ピボットの操作

ピボット コントロールを使うと、次のタッチ ジェスチャ操作が可能になります。

- ピボット項目のヘッダーをタップすると、そのヘッダーのセクション コンテンツに移動します。
- ピボット項目のヘッダー上で左または右へスワイプすると、隣接するセクションに移動します。
- セクション コンテンツ上で左または右へスワイプすると、隣接するセクションに移動します。

コントロールには次の 2 つのモードがあります。

**固定**

- 許可されている領域内にすべてのピボット ヘッダーが収まる場合、ピボットは固定されます。
- ピボット ラベルをタップすると、ピボット自体は移動しませんが、対応するページに移動します。 アクティブなピボットは強調表示されます。

**カルーセル**

- 許可されている領域内にすべてのピボット ヘッダーが収まらない場合、ピボットがカルーセル表示されます。
- ピボット ラベルをタップすると対応するページに移動し、アクティブなピボット ラベルは最初の位置までカルーセル表示されます。
- カルーセル内のピボット項目は、最後のピボット セクションから最初のピボット セクションにループします。

> **注** ピボット ヘッダーを [10 フィート環境](../devices/designing-for-tv.md)でカルーセル表示しないでください。 Xbox 上でアプリを実行する場合は、[IsHeaderItemsCarouselEnabled](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot.IsHeaderItemsCarouselEnabled) プロパティを **false** に設定します。

## <a name="recommendations"></a>推奨事項

- カルーセル (ラウンドト リップ) モードを使う場合、5 個より多いヘッダーを使わないでください。5 個より多いヘッダーをループすると、混乱を招く可能性があります。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。

## <a name="related-topics"></a>関連トピック

- [Pivot クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Pivot)
- [ナビゲーション デザインの基本](../basics/navigation-basics.md)