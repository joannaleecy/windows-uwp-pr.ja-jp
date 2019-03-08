---
Description: セマンティック ズーム コントロールを使うと、ユーザーは同じデータ セットの 2 つの異なるセマンティック表示間でズームを実行できるようになります。
title: セマンティック ズーム
ms.assetid: B5C21FE7-BA83-4940-9CC1-96F6A2DC28C7
label: Semantic zoom
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: predavid
design-contact: kimsea
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 210cca8a4b17b77e8c1f9cb490a79bcd1a53b6c7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627617"
---
# <a name="semantic-zoom"></a><span data-ttu-id="6df44-104">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="6df44-104">Semantic zoom</span></span>

 

<span data-ttu-id="6df44-105">セマンティック ズームを使用すると、ユーザーは同じコンテンツを 2 種類のビューで表示できるようになるので、グループ化された大きなデータ セット内を迅速に移動できるようになります。</span><span class="sxs-lookup"><span data-stu-id="6df44-105">Semantic zoom lets the user switch between two different views of the same content so that they can quickly navigate through a large set of grouped data.</span></span>
 
- <span data-ttu-id="6df44-106">拡大表示は、コンテンツのメイン表示です。</span><span class="sxs-lookup"><span data-stu-id="6df44-106">The zoomed-in view is the main view of the content.</span></span> <span data-ttu-id="6df44-107">これは、個別のデータ項目を表示するためのメイン ビューです。</span><span class="sxs-lookup"><span data-stu-id="6df44-107">This is the main view where you show individual data items.</span></span> 
- <span data-ttu-id="6df44-108">縮小表示は、同じコンテンツの上位レベルの表示です。</span><span class="sxs-lookup"><span data-stu-id="6df44-108">The zoomed-out view is a higher-level view of the same content.</span></span> <span data-ttu-id="6df44-109">通常、グループ化されたデータ セットのグループ ヘッダーは、このビューで表示します。</span><span class="sxs-lookup"><span data-stu-id="6df44-109">You typically show the group headers for a grouped data set in this view.</span></span> 

<span data-ttu-id="6df44-110">たとえば、アドレス帳を表示しているときに、表示を縮小して "W" の文字にすばやく移動したり、文字を拡大表示して、その文字に関連付けられた名前を調べたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="6df44-110">For example, when viewing an address book, the user could zoom out to quickly jump to the letter "W", and zoom in on that letter to see the names associated with it.</span></span> 

> <span data-ttu-id="6df44-111">**重要な Api**:[SemanticZoom クラス](https://msdn.microsoft.com/library/windows/apps/hh702601)、 [ListView クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx)、 [GridView クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span><span class="sxs-lookup"><span data-stu-id="6df44-111">**Important APIs**: [SemanticZoom class](https://msdn.microsoft.com/library/windows/apps/hh702601), [ListView class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx), [GridView class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx)</span></span>

<span data-ttu-id="6df44-112">**機能**:</span><span class="sxs-lookup"><span data-stu-id="6df44-112">**Features**:</span></span>

-   <span data-ttu-id="6df44-113">縮小表示ビューのサイズは、セマンティック ズーム コントロールの境界によって制限されます。</span><span class="sxs-lookup"><span data-stu-id="6df44-113">The size of the zoomed-out view is constrained by the bounds of the semantic zoom control.</span></span>
-   <span data-ttu-id="6df44-114">グループ ヘッダーをタップするとビューが切り替わります。</span><span class="sxs-lookup"><span data-stu-id="6df44-114">Tapping on a group header toggles views.</span></span> <span data-ttu-id="6df44-115">ピンチしてビューを切り替える方法を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="6df44-115">Pinching as a way to toggle between views can be enabled.</span></span>
-   <span data-ttu-id="6df44-116">アクティブなヘッダーによりビューが切り替わります。</span><span class="sxs-lookup"><span data-stu-id="6df44-116">Active headers switch between views.</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="6df44-117">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="6df44-117">Is this the right control?</span></span>

<span data-ttu-id="6df44-118">**SemanticZoom** コントロールは、グループ化されたデータ セットを表示する際、データが大きすぎて 1 ページや 2 ページでは表示しきれない場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="6df44-118">Use a **SemanticZoom** control when you need to show a grouped data set that's large enough that it can’t all be shown on one or two pages.</span></span>

<span data-ttu-id="6df44-119">セマンティック ズームと光学式ズームを混同しないように気を付けてください。</span><span class="sxs-lookup"><span data-stu-id="6df44-119">Don't confuse semantic zooming with optical zooming.</span></span> <span data-ttu-id="6df44-120">操作方法と基本的な動作 (ズーム係数に基づいて詳しく表示したり簡単に表示したりする動作) は同じですが、光学式ズームでは、コンテンツ領域またはオブジェクトの倍率調整を写真のように行います。</span><span class="sxs-lookup"><span data-stu-id="6df44-120">While they share both the same interaction and basic behavior (displaying more or less detail based on a zoom factor), optical zoom refers to the adjustment of magnification for a content area or object such as a photograph.</span></span> <span data-ttu-id="6df44-121">光学式ズームを行うコントロールについて詳しくは、[ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) コントロールの説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6df44-121">For info about a control that performs optical zooming, see the [ScrollViewer](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.scrollviewer.aspx) control.</span></span>

## <a name="examples"></a><span data-ttu-id="6df44-122">例</span><span class="sxs-lookup"><span data-stu-id="6df44-122">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="6df44-123">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="6df44-123">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="6df44-124"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/SemanticZoom">アプリを開き、SemanticZoom の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="6df44-124">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/SemanticZoom">open the app and see the SemanticZoom in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="6df44-125"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></span><span class="sxs-lookup"><span data-stu-id="6df44-125"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="6df44-126"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="6df44-126"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="6df44-127">**写真アプリ**</span><span class="sxs-lookup"><span data-stu-id="6df44-127">**Photos app**</span></span>

<span data-ttu-id="6df44-128">フォト アプリで使われるセマンティック ズームの例です。</span><span class="sxs-lookup"><span data-stu-id="6df44-128">Here's a semantic zoom used in the Photos app.</span></span> <span data-ttu-id="6df44-129">写真は月ごとにグループ化されています。</span><span class="sxs-lookup"><span data-stu-id="6df44-129">Photos are grouped by month.</span></span> <span data-ttu-id="6df44-130">既定のグリッド ビューで月ヘッダーを選択すると、月の一覧ビューにズームアウトして、すばやく移動できます。</span><span class="sxs-lookup"><span data-stu-id="6df44-130">Selecting a month header in the default grid view zooms out to the month list view for quicker navigation.</span></span>

![フォト アプリで使われるセマンティック ズーム](images/control-examples/semantic-zoom-photos.png)

<span data-ttu-id="6df44-132">**アドレス帳**</span><span class="sxs-lookup"><span data-stu-id="6df44-132">**Address book**</span></span>

<span data-ttu-id="6df44-133">セマンティック ズームを使って簡単にナビゲートできるデータ セットの例として、アドレス帳があります。</span><span class="sxs-lookup"><span data-stu-id="6df44-133">An address book is another example of a data set that can be much easier to navigate using semantic zoom.</span></span> <span data-ttu-id="6df44-134">縮小表示ビューを使用すると、必要な文字にすばやく移動できます (左の画像)。拡大表示ビューには、個別のデータ項目が表示されます (右の画像)。</span><span class="sxs-lookup"><span data-stu-id="6df44-134">You can use the zoomed-out view to quickly jump to the letter you need (left image), while the zoomed-in view displays the individual data items (right image).</span></span>

![連絡先の一覧で使用されているセマンティック ズームの例](images/semanticzoom-win10.png)

## <a name="create-a-semantic-zoom"></a><span data-ttu-id="6df44-136">セマンティック ズームの作成</span><span class="sxs-lookup"><span data-stu-id="6df44-136">Create a semantic zoom</span></span>

<span data-ttu-id="6df44-137">**SemanticZoom**コントロールには、独自の視覚的表現はありません。</span><span class="sxs-lookup"><span data-stu-id="6df44-137">The **SemanticZoom** control doesn’t have any visual representation of its own.</span></span> <span data-ttu-id="6df44-138">SemanticZoom は、コンテンツを表示する 2 つのコントロール (通常は **ListView** コントロールと **GridView** コントロール) 間の切り替えを管理する、ホスト コントロールです。</span><span class="sxs-lookup"><span data-stu-id="6df44-138">It’s a host control that manages the transition between 2 other controls that provide the views of your content, typically **ListView** or **GridView** controls.</span></span>  <span data-ttu-id="6df44-139">開発者は、これらのビュー コントロールを SemanticZoom の [ZoomedInView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.zoomedinview.aspx) プロパティと [ZoomedOutView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.zoomedoutview.aspx) プロパティに設定します。</span><span class="sxs-lookup"><span data-stu-id="6df44-139">You set the view controls to the [ZoomedInView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.zoomedinview.aspx) and [ZoomedOutView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.zoomedoutview.aspx) properties of the SemanticZoom.</span></span>

<span data-ttu-id="6df44-140">セマンティック ズームに必要な 3 つの要素は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="6df44-140">The 3 elements you need for a semantic zoom are:</span></span>
- <span data-ttu-id="6df44-141">グループ化されたデータ ソース</span><span class="sxs-lookup"><span data-stu-id="6df44-141">A grouped data source</span></span>
- <span data-ttu-id="6df44-142">項目レベルのデータを表示する拡大表示ビュー。</span><span class="sxs-lookup"><span data-stu-id="6df44-142">A zoomed-in view that shows the item-level data.</span></span>
- <span data-ttu-id="6df44-143">グループ レベルのデータを表示する縮小表示ビュー。</span><span class="sxs-lookup"><span data-stu-id="6df44-143">A zoomed-out view that shows the group-level data.</span></span>

<span data-ttu-id="6df44-144">セマンティック ズームを使用する前に、グループ化されたデータに対してリスト ビューを使用する方法を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6df44-144">Before you use a semantic zoom, you should understand how to use a list view with grouped data.</span></span> <span data-ttu-id="6df44-145">詳細については、次を参照してください。[ビューとグリッド ビューを一覧表示](listview-and-gridview.md)します。</span><span class="sxs-lookup"><span data-stu-id="6df44-145">For more info, see [List view and grid view](listview-and-gridview.md).</span></span> 

> <span data-ttu-id="6df44-146">**注**&nbsp;&nbsp; SemanticZoom コントロールの拡大表示ビューと縮小表示ビューを定義するには、[ISemanticZoomInformation](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.isemanticzoominformation.aspx) インターフェイスを実装する任意のコントロールを 2 つ使用できます。</span><span class="sxs-lookup"><span data-stu-id="6df44-146">**Note**&nbsp;&nbsp;To define the zoomed-in view and the zoomed-out view of the SemanticZoom control, you can use any two controls that implement the [ISemanticZoomInformation](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.isemanticzoominformation.aspx) interface.</span></span> <span data-ttu-id="6df44-147">XAML フレームワークでは、このインターフェイスを実装する 3 つのコントロールを提供します。ListView、GridView、およびハブ。</span><span class="sxs-lookup"><span data-stu-id="6df44-147">The XAML framework provides 3 controls that implement this interface: ListView, GridView, and Hub.</span></span>
 
 <span data-ttu-id="6df44-148">この XAML は、SemanticZoom コントロールの構造を示したものです。</span><span class="sxs-lookup"><span data-stu-id="6df44-148">This XAML shows the structure of the SemanticZoom control.</span></span> <span data-ttu-id="6df44-149">ZoomedInView プロパティと ZoomedOutView プロパティに、他のコントロールを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="6df44-149">You assign other controls to the ZoomedInView and ZoomedOutView properties.</span></span>
 
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
 
<span data-ttu-id="6df44-150">この例は、「[XAML UI の基本サンプル](https://go.microsoft.com/fwlink/p/?LinkId=619992)」の SemanticZoom ページから引用したものです。</span><span class="sxs-lookup"><span data-stu-id="6df44-150">The examples here are taken from the SemanticZoom page of the [XAML UI Basics sample](https://go.microsoft.com/fwlink/p/?LinkId=619992).</span></span> <span data-ttu-id="6df44-151">データ ソースを含む完全なコードは、このサンプルをダウンロードして確認できます。</span><span class="sxs-lookup"><span data-stu-id="6df44-151">You can download the sample to see the complete code including the data source.</span></span> <span data-ttu-id="6df44-152">このセマンティック ズームでは、拡大表示ビューに GridView を使用し、縮小表示ビューに ListView を使用しています。</span><span class="sxs-lookup"><span data-stu-id="6df44-152">This semantic zoom uses a GridView to supply the zoomed-in view and a ListView for the zoomed-out view.</span></span>
  
<span data-ttu-id="6df44-153">**拡大ビューを定義します。**</span><span class="sxs-lookup"><span data-stu-id="6df44-153">**Define the zoomed-in view**</span></span>

<span data-ttu-id="6df44-154">ここでは、拡大表示ビューに GridView コントロールを使用する例を示します。</span><span class="sxs-lookup"><span data-stu-id="6df44-154">Here's the GridView control for the zoomed-in view.</span></span> <span data-ttu-id="6df44-155">拡大表示ビューには、グループ内の個別のデータ項目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="6df44-155">The zoomed-in view should display the individual data items in groups.</span></span> <span data-ttu-id="6df44-156">この例は、グリッド内の項目を画像とテキストで表示する方法を示したものです。</span><span class="sxs-lookup"><span data-stu-id="6df44-156">This example shows how to display the items in a grid with an image and text.</span></span> 

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
 
<span data-ttu-id="6df44-157">グループ ヘッダーの外観は、`ZoomedInGroupHeaderTemplate` リソース内で定義されています。</span><span class="sxs-lookup"><span data-stu-id="6df44-157">The look of the group headers is defined in the `ZoomedInGroupHeaderTemplate` resource.</span></span> <span data-ttu-id="6df44-158">項目の外観は、`ZoomedInTemplate` リソース内で定義されています。</span><span class="sxs-lookup"><span data-stu-id="6df44-158">The look of the items is defined in the `ZoomedInTemplate` resource.</span></span> 

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

<span data-ttu-id="6df44-159">**縮小ビューを定義します。**</span><span class="sxs-lookup"><span data-stu-id="6df44-159">**Define the zoomed-out view**</span></span>

<span data-ttu-id="6df44-160">この XAML は、縮小表示用の ListView コントロールを定義したものです。</span><span class="sxs-lookup"><span data-stu-id="6df44-160">This XAML defines a ListView control for the zoomed-out view.</span></span> <span data-ttu-id="6df44-161">この例では、グループ ヘッダーをリスト内のテキストとして表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6df44-161">This example shows how to display the group headers as text in a list.</span></span>

```xaml
<SemanticZoom.ZoomedOutView>
    <ListView ItemsSource="{x:Bind cvsGroups.View.CollectionGroups}" 
              SelectionMode="None" 
              ItemTemplate="{StaticResource ZoomedOutTemplate}" />
</SemanticZoom.ZoomedOutView>
```

 <span data-ttu-id="6df44-162">外観は、`ZoomedOutTemplate` リソース内で定義されています。</span><span class="sxs-lookup"><span data-stu-id="6df44-162">The look is defined in the `ZoomedOutTemplate` resource.</span></span>
 
```xaml    
<DataTemplate x:Key="ZoomedOutTemplate" x:DataType="wuxdata:ICollectionViewGroup">
    <TextBlock Text="{x:Bind Group.(data:ControlInfoDataGroup.Title)}" 
               Style="{StaticResource SubtitleTextBlockStyle}" TextWrapping="Wrap"/>
</DataTemplate>
```

<span data-ttu-id="6df44-163">**ビューを同期します。**</span><span class="sxs-lookup"><span data-stu-id="6df44-163">**Synchronize the views**</span></span>

<span data-ttu-id="6df44-164">拡大表示と縮小表示は同期する必要があります。したがって、ユーザーが縮小表示のグループを選択した場合、同じグループの詳細が拡大表示されることになります。</span><span class="sxs-lookup"><span data-stu-id="6df44-164">The zoomed-in view and zoomed-out view should be synchronized, so if a user selects a group in the zoomed-out view, the details of that same group are shown in the zoomed-in view.</span></span> <span data-ttu-id="6df44-165">[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) を使うか、または表示を同期するためのコードを追加できます。</span><span class="sxs-lookup"><span data-stu-id="6df44-165">You can use a [CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) or add code to synchronize the views.</span></span>

<span data-ttu-id="6df44-166">同じ CollectionViewSource にバインドするコントロールには、常に同じ現在の項目が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6df44-166">Any controls that you bind to the same CollectionViewSource always have the same current item.</span></span> <span data-ttu-id="6df44-167">両表示でデータ ソースとして同じ CollectionViewSource を使っている場合、CollectionViewSource により表示が自動的に同期されます。</span><span class="sxs-lookup"><span data-stu-id="6df44-167">If both views use the same CollectionViewSource as their data source, the CollectionViewSource synchronizes the views automatically.</span></span> <span data-ttu-id="6df44-168">詳しくは、[CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6df44-168">For more info, see [CollectionViewSource](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx).</span></span>

<span data-ttu-id="6df44-169">表示の同期のために CollectionViewSource を使わない場合は、[ViewChangeStarted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.viewchangestarted.aspx) のイベントを処理し、次のようなイベント ハンドラーで項目を同期化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6df44-169">If you don't use a CollectionViewSource to synchronize the views, you should handle the [ViewChangeStarted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.viewchangestarted.aspx) event and synchronize the items in the event handler, as shown here.</span></span>

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

## <a name="recommendations"></a><span data-ttu-id="6df44-170">推奨事項</span><span class="sxs-lookup"><span data-stu-id="6df44-170">Recommendations</span></span>

-   <span data-ttu-id="6df44-171">アプリでセマンティック ズームを使うときは、ズーム レベルごとに項目のレイアウトとパン方向が変わらないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6df44-171">When using semantic zoom in your app, be sure that the item layout and panning direction don't change based on the zoom level.</span></span> <span data-ttu-id="6df44-172">レイアウトとパン操作は、ズーム レベルに関係なく一貫して予測できるものにしてください。</span><span class="sxs-lookup"><span data-stu-id="6df44-172">Layouts and panning interactions should be consistent and predictable across zoom levels.</span></span>
-   <span data-ttu-id="6df44-173">セマンティック ズームを使ってすばやくコンテンツにジャンプできるようにするため、縮小モードでのページや画面の数は 3 つまでに制限します。</span><span class="sxs-lookup"><span data-stu-id="6df44-173">Semantic zoom enables the user to jump quickly to content, so limit the number of pages/screens to three in the zoomed-out mode.</span></span> <span data-ttu-id="6df44-174">パンが多すぎると、セマンティック ズームの実用性が損なわれます。</span><span class="sxs-lookup"><span data-stu-id="6df44-174">Too much panning diminishes the practicality of semantic zoom.</span></span>
-   <span data-ttu-id="6df44-175">セマンティック ズームを使ってコンテンツの範囲を変更しないでください。</span><span class="sxs-lookup"><span data-stu-id="6df44-175">Avoid using semantic zoom to change the scope of the content.</span></span> <span data-ttu-id="6df44-176">たとえば、フォト アルバムをファイル エクスプローラーのフォルダー表示に切り替えないでください。</span><span class="sxs-lookup"><span data-stu-id="6df44-176">For example, a photo album shouldn't switch to a folder view in File Explorer.</span></span>
-   <span data-ttu-id="6df44-177">各ビューに不可欠な構造とセマンティクスを使います。</span><span class="sxs-lookup"><span data-stu-id="6df44-177">Use a structure and semantics that are essential to the view.</span></span>
-   <span data-ttu-id="6df44-178">グループ化したコレクションの項目にはグループ名を使います。</span><span class="sxs-lookup"><span data-stu-id="6df44-178">Use group names for items in a grouped collection.</span></span>
-   <span data-ttu-id="6df44-179">グループ化せずに並べ替えたコレクションには並べ替え順序を使います (日付の場合は時系列順、名前の一覧の場合はアルファベット順など)。</span><span class="sxs-lookup"><span data-stu-id="6df44-179">Use sort ordering for a collection that is ungrouped but sorted, such as chronological for dates or alphabetical for a list of names.</span></span>


## <a name="get-the-sample-code"></a><span data-ttu-id="6df44-180">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="6df44-180">Get the sample code</span></span>

- <span data-ttu-id="6df44-181">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="6df44-181">[XAML Controls Gallery sample](https://github.com/Microsoft/Xaml-Controls-Gallery) - See all the XAML controls in an interactive format.</span></span>


## <a name="related-articles"></a><span data-ttu-id="6df44-182">関連記事</span><span class="sxs-lookup"><span data-stu-id="6df44-182">Related articles</span></span>

- [<span data-ttu-id="6df44-183">ナビゲーションのデザインの基礎</span><span class="sxs-lookup"><span data-stu-id="6df44-183">Navigation design basics</span></span>](../basics/navigation-basics.md)
- [<span data-ttu-id="6df44-184">リスト ビューおよびグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="6df44-184">List view and grid view</span></span>](listview-and-gridview.md)
- [<span data-ttu-id="6df44-185">項目コンテナーとテンプレート</span><span class="sxs-lookup"><span data-stu-id="6df44-185">Item containers and templates</span></span>](item-containers-templates.md)





