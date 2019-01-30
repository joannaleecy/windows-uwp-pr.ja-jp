---
Description: A semantic zoom control allows the user to zoom between two different semantic views of the same data set.
title: セマンティック ズーム
ms.assetid: B5C21FE7-BA83-4940-9CC1-96F6A2DC28C7
label: Semantic zoom
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: predavid
design-contact: kimsea
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 027ad255feaffa25450b1c490d1697410e91f431
ms.sourcegitcommit: a60ab85e9f2f9690e0141050ec3aa51f18ec61ec
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/30/2019
ms.locfileid: "9037184"
---
# <a name="semantic-zoom"></a><span data-ttu-id="880f8-103">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="880f8-103">Semantic zoom</span></span>

 

<span data-ttu-id="880f8-104">セマンティック ズームを使用すると、ユーザーは同じコンテンツを 2 種類のビューで表示できるようになるので、グループ化された大きなデータ セット内を迅速に移動できるようになります。</span><span class="sxs-lookup"><span data-stu-id="880f8-104">Semantic zoom lets the user switch between two different views of the same content so that they can quickly navigate through a large set of grouped data.</span></span>
 
- <span data-ttu-id="880f8-105">拡大表示は、コンテンツのメイン表示です。</span><span class="sxs-lookup"><span data-stu-id="880f8-105">The zoomed-in view is the main view of the content.</span></span> <span data-ttu-id="880f8-106">これは、個別のデータ項目を表示するためのメイン ビューです。</span><span class="sxs-lookup"><span data-stu-id="880f8-106">This is the main view where you show individual data items.</span></span> 
- <span data-ttu-id="880f8-107">縮小表示は、同じコンテンツの上位レベルの表示です。</span><span class="sxs-lookup"><span data-stu-id="880f8-107">The zoomed-out view is a higher-level view of the same content.</span></span> <span data-ttu-id="880f8-108">通常、グループ化されたデータ セットのグループ ヘッダーは、このビューで表示します。</span><span class="sxs-lookup"><span data-stu-id="880f8-108">You typically show the group headers for a grouped data set in this view.</span></span> 

<span data-ttu-id="880f8-109">たとえば、アドレス帳を表示しているときに、表示を縮小して "W" の文字にすばやく移動したり、文字を拡大表示して、その文字に関連付けられた名前を調べたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="880f8-109">For example, when viewing an address book, the user could zoom out to quickly jump to the letter "W", and zoom in on that letter to see the names associated with it.</span></span> 

> <span data-ttu-id="880f8-110">**重要な API**: [SemanticZoom クラス](https://msdn.microsoft.com/library/windows/apps/hh702601)、[ListView クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx)、[GridView クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span><span class="sxs-lookup"><span data-stu-id="880f8-110">**Important APIs**: [SemanticZoom class](https://msdn.microsoft.com/library/windows/apps/hh702601), [ListView class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx), [GridView class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span></span>

<span data-ttu-id="880f8-111">**機能**:</span><span class="sxs-lookup"><span data-stu-id="880f8-111">**Features**:</span></span>

-   <span data-ttu-id="880f8-112">縮小表示ビューのサイズは、セマンティック ズーム コントロールの境界によって制限されます。</span><span class="sxs-lookup"><span data-stu-id="880f8-112">The size of the zoomed-out view is constrained by the bounds of the semantic zoom control.</span></span>
-   <span data-ttu-id="880f8-113">グループ ヘッダーをタップするとビューが切り替わります。</span><span class="sxs-lookup"><span data-stu-id="880f8-113">Tapping on a group header toggles views.</span></span> <span data-ttu-id="880f8-114">ピンチしてビューを切り替える方法を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="880f8-114">Pinching as a way to toggle between views can be enabled.</span></span>
-   <span data-ttu-id="880f8-115">アクティブなヘッダーによりビューが切り替わります。</span><span class="sxs-lookup"><span data-stu-id="880f8-115">Active headers switch between views.</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="880f8-116">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="880f8-116">Is this the right control?</span></span>

<span data-ttu-id="880f8-117">**SemanticZoom** コントロールは、グループ化されたデータ セットを表示する際、データが大きすぎて 1 ページや 2 ページでは表示しきれない場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="880f8-117">Use a **SemanticZoom** control when you need to show a grouped data set that's large enough that it can’t all be shown on one or two pages.</span></span>

<span data-ttu-id="880f8-118">セマンティック ズームと光学式ズームを混同しないように気を付けてください。</span><span class="sxs-lookup"><span data-stu-id="880f8-118">Don't confuse semantic zooming with optical zooming.</span></span> <span data-ttu-id="880f8-119">操作方法と基本的な動作 (ズーム係数に基づいて詳しく表示したり簡単に表示したりする動作) は同じですが、光学式ズームでは、コンテンツ領域またはオブジェクトの倍率調整を写真のように行います。</span><span class="sxs-lookup"><span data-stu-id="880f8-119">While they share both the same interaction and basic behavior (displaying more or less detail based on a zoom factor), optical zoom refers to the adjustment of magnification for a content area or object such as a photograph.</span></span> <span data-ttu-id="880f8-120">光学式ズームを行うコントロールについて詳しくは、[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) コントロールの説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="880f8-120">For info about a control that performs optical zooming, see the [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) control.</span></span>

## <a name="examples"></a><span data-ttu-id="880f8-121">例</span><span class="sxs-lookup"><span data-stu-id="880f8-121">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="880f8-122">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="880f8-122">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="880f8-123"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/SemanticZoom">アプリを開き、SemanticZoom の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="880f8-123">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/SemanticZoom">open the app and see the SemanticZoom in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="880f8-124">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="880f8-124">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery"><span data-ttu-id="880f8-125">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="880f8-125">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

**<span data-ttu-id="880f8-126">フォト アプリ</span><span class="sxs-lookup"><span data-stu-id="880f8-126">Photos app</span></span>**

<span data-ttu-id="880f8-127">フォト アプリで使われるセマンティック ズームの例です。</span><span class="sxs-lookup"><span data-stu-id="880f8-127">Here's a semantic zoom used in the Photos app.</span></span> <span data-ttu-id="880f8-128">写真は月ごとにグループ化されています。</span><span class="sxs-lookup"><span data-stu-id="880f8-128">Photos are grouped by month.</span></span> <span data-ttu-id="880f8-129">既定のグリッド ビューで月ヘッダーを選択すると、月の一覧ビューにズームアウトして、すばやく移動できます。</span><span class="sxs-lookup"><span data-stu-id="880f8-129">Selecting a month header in the default grid view zooms out to the month list view for quicker navigation.</span></span>

![フォト アプリで使われるセマンティック ズーム](images/control-examples/semantic-zoom-photos.png)

**<span data-ttu-id="880f8-131">アドレス帳</span><span class="sxs-lookup"><span data-stu-id="880f8-131">Address book</span></span>**

<span data-ttu-id="880f8-132">セマンティック ズームを使って簡単にナビゲートできるデータ セットの例として、アドレス帳があります。</span><span class="sxs-lookup"><span data-stu-id="880f8-132">An address book is another example of a data set that can be much easier to navigate using semantic zoom.</span></span> <span data-ttu-id="880f8-133">縮小表示ビューを使用すると、必要な文字にすばやく移動できます (左の画像)。拡大表示ビューには、個別のデータ項目が表示されます (右の画像)。</span><span class="sxs-lookup"><span data-stu-id="880f8-133">You can use the zoomed-out view to quickly jump to the letter you need (left image), while the zoomed-in view displays the individual data items (right image).</span></span>

![連絡先の一覧で使用されているセマンティック ズームの例](images/semanticzoom-win10.png)

## <a name="create-a-semantic-zoom"></a><span data-ttu-id="880f8-135">セマンティック ズームの作成</span><span class="sxs-lookup"><span data-stu-id="880f8-135">Create a semantic zoom</span></span>

<span data-ttu-id="880f8-136">**SemanticZoom**コントロールには、独自の視覚的表現はありません。</span><span class="sxs-lookup"><span data-stu-id="880f8-136">The **SemanticZoom** control doesn’t have any visual representation of its own.</span></span> <span data-ttu-id="880f8-137">SemanticZoom は、コンテンツを表示する 2 つのコントロール (通常は **ListView** コントロールと **GridView** コントロール) 間の切り替えを管理する、ホスト コントロールです。</span><span class="sxs-lookup"><span data-stu-id="880f8-137">It’s a host control that manages the transition between 2 other controls that provide the views of your content, typically **ListView** or **GridView** controls.</span></span>  <span data-ttu-id="880f8-138">開発者は、これらのビュー コントロールを SemanticZoom の [ZoomedInView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.zoomedinview.aspx) プロパティと [ZoomedOutView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.zoomedoutview.aspx) プロパティに設定します。</span><span class="sxs-lookup"><span data-stu-id="880f8-138">You set the view controls to the [ZoomedInView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.zoomedinview.aspx) and [ZoomedOutView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.zoomedoutview.aspx) properties of the SemanticZoom.</span></span>

<span data-ttu-id="880f8-139">セマンティック ズームに必要な 3 つの要素は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="880f8-139">The 3 elements you need for a semantic zoom are:</span></span>
- <span data-ttu-id="880f8-140">グループ化されたデータ ソース</span><span class="sxs-lookup"><span data-stu-id="880f8-140">A grouped data source</span></span>
- <span data-ttu-id="880f8-141">項目レベルのデータを表示する拡大表示ビュー。</span><span class="sxs-lookup"><span data-stu-id="880f8-141">A zoomed-in view that shows the item-level data.</span></span>
- <span data-ttu-id="880f8-142">グループ レベルのデータを表示する縮小表示ビュー。</span><span class="sxs-lookup"><span data-stu-id="880f8-142">A zoomed-out view that shows the group-level data.</span></span>

<span data-ttu-id="880f8-143">セマンティック ズームを使用する前に、グループ化されたデータに対してリスト ビューを使用する方法を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="880f8-143">Before you use a semantic zoom, you should understand how to use a list view with grouped data.</span></span> <span data-ttu-id="880f8-144">詳しくは、「[リスト ビューとグリッド ビュー](listview-and-gridview.md)」と「[リスト内の項目のグループ化]()」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="880f8-144">For more info, see [List view and grid view](listview-and-gridview.md) and [Grouping items in a list]().</span></span> 

> <span data-ttu-id="880f8-145">**注**&nbsp;&nbsp; SemanticZoom コントロールの拡大表示ビューと縮小表示ビューを定義するには、[ISemanticZoomInformation](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.isemanticzoominformation.aspx) インターフェイスを実装する任意のコントロールを 2 つ使用できます。</span><span class="sxs-lookup"><span data-stu-id="880f8-145">**Note**&nbsp;&nbsp;To define the zoomed-in view and the zoomed-out view of the SemanticZoom control, you can use any two controls that implement the [ISemanticZoomInformation](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.isemanticzoominformation.aspx) interface.</span></span> <span data-ttu-id="880f8-146">XAML フレームワークには、このインターフェイスを実装するコントロールが 3 つ用意されています。ListView、GridView、および Hub です。</span><span class="sxs-lookup"><span data-stu-id="880f8-146">The XAML framework provides 3 controls that implement this interface: ListView, GridView, and Hub.</span></span>
 
 <span data-ttu-id="880f8-147">この XAML は、SemanticZoom コントロールの構造を示したものです。</span><span class="sxs-lookup"><span data-stu-id="880f8-147">This XAML shows the structure of the SemanticZoom control.</span></span> <span data-ttu-id="880f8-148">ZoomedInView プロパティと ZoomedOutView プロパティに、他のコントロールを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="880f8-148">You assign other controls to the ZoomedInView and ZoomedOutView properties.</span></span>
 
 ```xaml
<SemanticZoom>
    <SemanticZoom.ZoomedInView>
        <!-- Put the GridView for the zoomed in view here. -->   
    </SemanticZoom.ZoomedInView>

    <SemanticZoom.ZoomedOutView>
        <!-- Put the ListView for the zoomed out view here. -->       
    </SemanticZoom.ZoomedOutView>
</SemanticZoom>
 ```
 
<span data-ttu-id="880f8-149">この例は、「[XAML UI の基本サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619992)」の SemanticZoom ページから引用したものです。</span><span class="sxs-lookup"><span data-stu-id="880f8-149">The examples here are taken from the SemanticZoom page of the [XAML UI Basics sample](http://go.microsoft.com/fwlink/p/?LinkId=619992).</span></span> <span data-ttu-id="880f8-150">データ ソースを含む完全なコードは、このサンプルをダウンロードして確認できます。</span><span class="sxs-lookup"><span data-stu-id="880f8-150">You can download the sample to see the complete code including the data source.</span></span> <span data-ttu-id="880f8-151">このセマンティック ズームでは、拡大表示ビューに GridView を使用し、縮小表示ビューに ListView を使用しています。</span><span class="sxs-lookup"><span data-stu-id="880f8-151">This semantic zoom uses a GridView to supply the zoomed-in view and a ListView for the zoomed-out view.</span></span>
  
**<span data-ttu-id="880f8-152">拡大表示ビューの定義</span><span class="sxs-lookup"><span data-stu-id="880f8-152">Define the zoomed-in view</span></span>**

<span data-ttu-id="880f8-153">ここでは、拡大表示ビューに GridView コントロールを使用する例を示します。</span><span class="sxs-lookup"><span data-stu-id="880f8-153">Here's the GridView control for the zoomed-in view.</span></span> <span data-ttu-id="880f8-154">拡大表示ビューには、グループ内の個別のデータ項目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="880f8-154">The zoomed-in view should display the individual data items in groups.</span></span> <span data-ttu-id="880f8-155">この例は、グリッド内の項目を画像とテキストで表示する方法を示したものです。</span><span class="sxs-lookup"><span data-stu-id="880f8-155">This example shows how to display the items in a grid with an image and text.</span></span> 

```xaml
<SemanticZoom.ZoomedInView>
    <GridView ItemsSource="{x:Bind cvsGroups.View}" 
              ScrollViewer.IsHorizontalScrollChainingEnabled="False" 
              SelectionMode="None" 
              ItemTemplate="{StaticResource ZoomedInTemplate}">
        <GridView.GroupStyle>
            <GroupStyle HeaderTemplate="{StaticResource ZoomedInGroupHeaderTemplate}"/>
        </GridView.GroupStyle>
    </GridView>
</SemanticZoom.ZoomedInView>
```
 
<span data-ttu-id="880f8-156">グループ ヘッダーの外観は、`ZoomedInGroupHeaderTemplate` リソース内で定義されています。</span><span class="sxs-lookup"><span data-stu-id="880f8-156">The look of the group headers is defined in the `ZoomedInGroupHeaderTemplate` resource.</span></span> <span data-ttu-id="880f8-157">項目の外観は、`ZoomedInTemplate` リソース内で定義されています。</span><span class="sxs-lookup"><span data-stu-id="880f8-157">The look of the items is defined in the `ZoomedInTemplate` resource.</span></span> 

```xaml
<DataTemplate x:Key="ZoomedInGroupHeaderTemplate" x:DataType="data:ControlInfoDataGroup">
    <TextBlock Text="{x:Bind Title}" 
               Foreground="{ThemeResource ApplicationForegroundThemeBrush}" 
               Style="{StaticResource SubtitleTextBlockStyle}"/>
</DataTemplate>

<DataTemplate x:Key="ZoomedInTemplate" x:DataType="data:ControlInfoDataItem">
    <StackPanel Orientation="Horizontal" MinWidth="200" Margin="12,6,0,6">
        <Image Source="{x:Bind ImagePath}" Height="80" Width="80"/>
        <StackPanel Margin="20,0,0,0">
            <TextBlock Text="{x:Bind Title}" 
                       Style="{StaticResource BaseTextBlockStyle}"/>
            <TextBlock Text="{x:Bind Subtitle}" 
                       TextWrapping="Wrap" HorizontalAlignment="Left" 
                       Width="300" Style="{StaticResource BodyTextBlockStyle}"/>
        </StackPanel>
    </StackPanel>
</DataTemplate>
```

**<span data-ttu-id="880f8-158">縮小表示ビューの定義</span><span class="sxs-lookup"><span data-stu-id="880f8-158">Define the zoomed-out view</span></span>**

<span data-ttu-id="880f8-159">この XAML は、縮小表示用の ListView コントロールを定義したものです。</span><span class="sxs-lookup"><span data-stu-id="880f8-159">This XAML defines a ListView control for the zoomed-out view.</span></span> <span data-ttu-id="880f8-160">この例では、グループ ヘッダーをリスト内のテキストとして表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="880f8-160">This example shows how to display the group headers as text in a list.</span></span>

```xaml
<SemanticZoom.ZoomedOutView>
    <ListView ItemsSource="{x:Bind cvsGroups.View.CollectionGroups}" 
              SelectionMode="None" 
              ItemTemplate="{StaticResource ZoomedOutTemplate}" />
</SemanticZoom.ZoomedOutView>
```

 <span data-ttu-id="880f8-161">外観は、`ZoomedOutTemplate` リソース内で定義されています。</span><span class="sxs-lookup"><span data-stu-id="880f8-161">The look is defined in the `ZoomedOutTemplate` resource.</span></span>
 
```xaml    
<DataTemplate x:Key="ZoomedOutTemplate" x:DataType="wuxdata:ICollectionViewGroup">
    <TextBlock Text="{x:Bind Group.(data:ControlInfoDataGroup.Title)}" 
               Style="{StaticResource SubtitleTextBlockStyle}" TextWrapping="Wrap"/>
</DataTemplate>
```

**<span data-ttu-id="880f8-162">表示の同期</span><span class="sxs-lookup"><span data-stu-id="880f8-162">Synchronize the views</span></span>**

<span data-ttu-id="880f8-163">拡大表示と縮小表示は同期する必要があります。したがって、ユーザーが縮小表示のグループを選択した場合、同じグループの詳細が拡大表示されることになります。</span><span class="sxs-lookup"><span data-stu-id="880f8-163">The zoomed-in view and zoomed-out view should be synchronized, so if a user selects a group in the zoomed-out view, the details of that same group are shown in the zoomed-in view.</span></span> <span data-ttu-id="880f8-164">[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) を使うか、または表示を同期するためのコードを追加できます。</span><span class="sxs-lookup"><span data-stu-id="880f8-164">You can use a [CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) or add code to synchronize the views.</span></span>

<span data-ttu-id="880f8-165">同じ CollectionViewSource にバインドするコントロールには、常に同じ現在の項目が含まれます。</span><span class="sxs-lookup"><span data-stu-id="880f8-165">Any controls that you bind to the same CollectionViewSource always have the same current item.</span></span> <span data-ttu-id="880f8-166">両表示でデータ ソースとして同じ CollectionViewSource を使っている場合、CollectionViewSource により表示が自動的に同期されます。</span><span class="sxs-lookup"><span data-stu-id="880f8-166">If both views use the same CollectionViewSource as their data source, the CollectionViewSource synchronizes the views automatically.</span></span> <span data-ttu-id="880f8-167">詳しくは、[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="880f8-167">For more info, see [CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx).</span></span>

<span data-ttu-id="880f8-168">表示の同期のために CollectionViewSource を使わない場合は、[ViewChangeStarted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.viewchangestarted.aspx) のイベントを処理し、次のようなイベント ハンドラーで項目を同期化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="880f8-168">If you don't use a CollectionViewSource to synchronize the views, you should handle the [ViewChangeStarted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.viewchangestarted.aspx) event and synchronize the items in the event handler, as shown here.</span></span>

```xaml
<SemanticZoom x:Name="semanticZoom" ViewChangeStarted="SemanticZoom_ViewChangeStarted">
```

```csharp
private void SemanticZoom_ViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
{
    if (e.IsSourceZoomedInView == false)
    {
        e.DestinationItem.Item = e.SourceItem.Item;
    }
}
```

## <a name="recommendations"></a><span data-ttu-id="880f8-169">推奨事項</span><span class="sxs-lookup"><span data-stu-id="880f8-169">Recommendations</span></span>

-   <span data-ttu-id="880f8-170">アプリでセマンティック ズームを使うときは、ズーム レベルごとに項目のレイアウトとパン方向が変わらないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="880f8-170">When using semantic zoom in your app, be sure that the item layout and panning direction don't change based on the zoom level.</span></span> <span data-ttu-id="880f8-171">レイアウトとパン操作は、ズーム レベルに関係なく一貫して予測できるものにしてください。</span><span class="sxs-lookup"><span data-stu-id="880f8-171">Layouts and panning interactions should be consistent and predictable across zoom levels.</span></span>
-   <span data-ttu-id="880f8-172">セマンティック ズームを使ってすばやくコンテンツにジャンプできるようにするため、縮小モードでのページや画面の数は 3 つまでに制限します。</span><span class="sxs-lookup"><span data-stu-id="880f8-172">Semantic zoom enables the user to jump quickly to content, so limit the number of pages/screens to three in the zoomed-out mode.</span></span> <span data-ttu-id="880f8-173">パンが多すぎると、セマンティック ズームの実用性が損なわれます。</span><span class="sxs-lookup"><span data-stu-id="880f8-173">Too much panning diminishes the practicality of semantic zoom.</span></span>
-   <span data-ttu-id="880f8-174">セマンティック ズームを使ってコンテンツの範囲を変更しないでください。</span><span class="sxs-lookup"><span data-stu-id="880f8-174">Avoid using semantic zoom to change the scope of the content.</span></span> <span data-ttu-id="880f8-175">たとえば、フォト アルバムをファイル エクスプローラーのフォルダー表示に切り替えないでください。</span><span class="sxs-lookup"><span data-stu-id="880f8-175">For example, a photo album shouldn't switch to a folder view in File Explorer.</span></span>
-   <span data-ttu-id="880f8-176">各ビューに不可欠な構造とセマンティクスを使います。</span><span class="sxs-lookup"><span data-stu-id="880f8-176">Use a structure and semantics that are essential to the view.</span></span>
-   <span data-ttu-id="880f8-177">グループ化したコレクションの項目にはグループ名を使います。</span><span class="sxs-lookup"><span data-stu-id="880f8-177">Use group names for items in a grouped collection.</span></span>
-   <span data-ttu-id="880f8-178">グループ化せずに並べ替えたコレクションには並べ替え順序を使います (日付の場合は時系列順、名前の一覧の場合はアルファベット順など)。</span><span class="sxs-lookup"><span data-stu-id="880f8-178">Use sort ordering for a collection that is ungrouped but sorted, such as chronological for dates or alphabetical for a list of names.</span></span>


## <a name="get-the-sample-code"></a><span data-ttu-id="880f8-179">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="880f8-179">Get the sample code</span></span>

- <span data-ttu-id="880f8-180">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="880f8-180">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>


## <a name="related-articles"></a><span data-ttu-id="880f8-181">関連記事</span><span class="sxs-lookup"><span data-stu-id="880f8-181">Related articles</span></span>

- [<span data-ttu-id="880f8-182">ナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="880f8-182">Navigation design basics</span></span>](../basics/navigation-basics.md)
- [<span data-ttu-id="880f8-183">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="880f8-183">List view and grid view</span></span>](listview-and-gridview.md)
- [<span data-ttu-id="880f8-184">項目コンテナーやテンプレート</span><span class="sxs-lookup"><span data-stu-id="880f8-184">Item containers and templates</span></span>](item-containers-templates.md)





