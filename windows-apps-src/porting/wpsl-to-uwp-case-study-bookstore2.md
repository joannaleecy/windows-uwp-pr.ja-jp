---
author: stevewhims
ms.assetid: 333f67f5-f012-4981-917f-c6fd271267c6
description: このケース スタディ、Bookstore で情報に基づいて、グループ化された、LongListSelector 内のデータを表示する、WindowsPhone Silverlight アプリから始まります。
title: WindowsPhone Silverlight から UWP ケース スタディ-Bookstore2
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8e518439ddd4e131c2d045f4467670b42a392fca
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5760881"
---
# <a name="windowsphone-silverlight-to-uwp-case-study-bookstore2"></a><span data-ttu-id="14186-104">WindowsPhone Silverlight から UWP へのケース スタディ: Bookstore2</span><span class="sxs-lookup"><span data-stu-id="14186-104">WindowsPhone Silverlight to UWP case study: Bookstore2</span></span>


<span data-ttu-id="14186-105">このケース スタディ- [bookstore1](wpsl-to-uwp-case-study-bookstore1.md)情報に基づいて、グループ化された**LongListSelector**内のデータを表示する、WindowsPhone Silverlight アプリから始まります。</span><span class="sxs-lookup"><span data-stu-id="14186-105">This case study—which builds on the info given in [Bookstore1](wpsl-to-uwp-case-study-bookstore1.md)—begins with a WindowsPhone Silverlight app that displays grouped data in a **LongListSelector**.</span></span> <span data-ttu-id="14186-106">ビュー モデルでは、**Author** クラスの各インスタンスは、該当する著者によって書かれた書籍のグループを表します。**LongListSelector** では、著者ごとにグループ化された書籍の一覧を表示したり、縮小して著者のジャンプ リストを表示したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="14186-106">In the view model, each instance of the class **Author** represents the group of the books written by that author, and in the **LongListSelector**, we can either view the list of books grouped by author or we can zoom out to see a jump list of authors.</span></span> <span data-ttu-id="14186-107">ジャンプ リストを使うと、書籍の一覧をスクロールするよりもすばやく移動することができます。</span><span class="sxs-lookup"><span data-stu-id="14186-107">The jump list affords much quicker navigation than scrolling through the list of books.</span></span> <span data-ttu-id="14186-108">アプリを Windows10Universal Windows プラットフォーム (UWP) アプリを移植する手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="14186-108">We walk through the steps of porting the app to a Windows10Universal Windows Platform (UWP) app.</span></span>

<span data-ttu-id="14186-109">**注:** と Visual Studio で bookstore2universal \_10 を開く「Visual Studio 更新プログラムが必要」、メッセージを表示し、手順[TargetPlatformVersion](w8x-to-uwp-troubleshooting.md)でターゲット プラットフォームのバージョンを設定するためです。</span><span class="sxs-lookup"><span data-stu-id="14186-109">**Note** When opening Bookstore2Universal\_10 in Visual Studio, if you see the message "Visual Studio update required", then follow the steps for setting Target Platform Version in [TargetPlatformVersion](w8x-to-uwp-troubleshooting.md).</span></span>

## <a name="downloads"></a><span data-ttu-id="14186-110">ダウンロード</span><span class="sxs-lookup"><span data-stu-id="14186-110">Downloads</span></span>

<span data-ttu-id="14186-111">[ダウンロード、Bookstore2WPSL8 WindowsPhone Silverlight アプリ](http://go.microsoft.com/fwlink/p/?linkid=522601)です。</span><span class="sxs-lookup"><span data-stu-id="14186-111">[Download the Bookstore2WPSL8 WindowsPhone Silverlight app](http://go.microsoft.com/fwlink/p/?linkid=522601).</span></span>

<span data-ttu-id="14186-112">[Windows 10 アプリをダウンロード、bookstore2universal \_10](http://go.microsoft.com/fwlink/?linkid=532952)します。</span><span class="sxs-lookup"><span data-stu-id="14186-112">[Download the Bookstore2Universal\_10 Windows10 app](http://go.microsoft.com/fwlink/?linkid=532952).</span></span>

##  <a name="the-windowsphone-silverlight-app"></a><span data-ttu-id="14186-113">WindowsPhone Silverlight アプリ</span><span class="sxs-lookup"><span data-stu-id="14186-113">The WindowsPhone Silverlight app</span></span>

<span data-ttu-id="14186-114">下の図は、ここで移植するアプリ Bookstore2WPSL8 の外観を示しています。</span><span class="sxs-lookup"><span data-stu-id="14186-114">The illustration below shows what Bookstore2WPSL8—the app that we're going to port—looks like.</span></span> <span data-ttu-id="14186-115">このアプリでは、著者ごとにグループ化された書籍の **LongListSelector** を縦方向にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="14186-115">It's a vertically-scrolling **LongListSelector** of books grouped by author.</span></span> <span data-ttu-id="14186-116">このリストを縮小してジャンプ リストを表示し、そこから任意のグループに移動できます。</span><span class="sxs-lookup"><span data-stu-id="14186-116">You can zoom out to the jump list, and from there, you can navigate back into any group.</span></span> <span data-ttu-id="14186-117">このアプリには 2 つの重要な機能があります。それらは、グループ化されたデータ ソースを提供するビュー モデルと、そのビュー モデルにバインドされるユーザー インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="14186-117">There are two main pieces to this app: the view model that provides the grouped data source, and the user interface that binds to that view model.</span></span> <span data-ttu-id="14186-118">思いますが、これらの要素を WindowsPhone Silverlight テクノロジから簡単に移植できますユニバーサル Windows プラットフォーム (UWP)。</span><span class="sxs-lookup"><span data-stu-id="14186-118">As we'll see, both of these pieces port easily from WindowsPhone Silverlight technology to the Universal Windows Platform (UWP).</span></span>

![Bookstore2WPSL8 の外観](images/wpsl-to-uwp-case-studies/c02-01-wpsl-how-the-app-looks.png)

##  <a name="porting-to-a-windows10-project"></a><span data-ttu-id="14186-120">Windows 10 プロジェクトへの移植</span><span class="sxs-lookup"><span data-stu-id="14186-120">Porting to a Windows10 project</span></span>

<span data-ttu-id="14186-121">Visual Studio で新しいプロジェクトを作成し、そこへ Bookstore2WPSL8 からファイルをコピーし、コピーしたファイルを新しいプロジェクトに含めるというタスクは、短時間で実行できます。</span><span class="sxs-lookup"><span data-stu-id="14186-121">It's a quick task to create a new project in Visual Studio, copy files over to it from Bookstore2WPSL8, and include the copied files in the new project.</span></span> <span data-ttu-id="14186-122">最初に、"新しいアプリケーション (Windows ユニバーサル)" プロジェクトを新規作成します。</span><span class="sxs-lookup"><span data-stu-id="14186-122">Start by creating a new Blank Application (Windows Universal) project.</span></span> <span data-ttu-id="14186-123">そして、"Bookstore2Universal\_10" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="14186-123">Name it Bookstore2Universal\_10.</span></span> <span data-ttu-id="14186-124">Bookstore2WPSL8 から Bookstore2Universal\_10 にコピーするファイルを、以下に示します。</span><span class="sxs-lookup"><span data-stu-id="14186-124">These are the files to copy over from Bookstore2WPSL8 to Bookstore2Universal\_10.</span></span>

-   <span data-ttu-id="14186-125">ブック カバーの画像の PNG ファイルを含むフォルダー (フォルダーは \\Assets\\CoverImages) をコピーします。</span><span class="sxs-lookup"><span data-stu-id="14186-125">Copy the folder containing the book cover image PNG files (the folder is \\Assets\\CoverImages).</span></span> <span data-ttu-id="14186-126">フォルダーをコピーしたら、**ソリューション エクスプローラー**で **[すべてのファイルを表示]** がオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="14186-126">After copying the folder, in **Solution Explorer**, make sure **Show All Files** is toggled on.</span></span> <span data-ttu-id="14186-127">コピーしたフォルダーを右クリックし、**[プロジェクトに含める]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="14186-127">Right-click the folder that you copied and click **Include In Project**.</span></span> <span data-ttu-id="14186-128">このコマンドは、ファイルまたはフォルダーをプロジェクトに "含める" ことを意味します。</span><span class="sxs-lookup"><span data-stu-id="14186-128">That command is what we mean by "including" files or folders in a project.</span></span> <span data-ttu-id="14186-129">ファイルやフォルダーをコピーするたびに、**ソリューション エクスプローラー**で **[更新]** をクリックしてから、ファイルまたはフォルダーをプロジェクトに含めます。</span><span class="sxs-lookup"><span data-stu-id="14186-129">Each time you copy a file or folder, click **Refresh** in **Solution Explorer** and then include the file or folder in the project.</span></span> <span data-ttu-id="14186-130">コピー先で置き換えるファイルについては、この手順を実行する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="14186-130">There's no need to do this for files that you're replacing in the destination.</span></span>
-   <span data-ttu-id="14186-131">ビュー モデル ソース ファイルを含むフォルダー (フォルダーは \\ViewModel) をコピーします。</span><span class="sxs-lookup"><span data-stu-id="14186-131">Copy the folder containing the view model source file (the folder is \\ViewModel).</span></span>
-   <span data-ttu-id="14186-132">MainPage.xaml をコピーして、コピー先のファイルを置き換えます。</span><span class="sxs-lookup"><span data-stu-id="14186-132">Copy MainPage.xaml and replace the file in the destination.</span></span>

<span data-ttu-id="14186-133">App.xaml と App.xaml.cs Visual Studio によって生成された windows 10 プロジェクトを保持できます。</span><span class="sxs-lookup"><span data-stu-id="14186-133">We can keep the App.xaml, and App.xaml.cs that Visual Studio generated for us in the Windows10 project.</span></span>

<span data-ttu-id="14186-134">コピーしたソース コードとマークアップ ファイルを編集し、Bookstore2WPSL8 名前空間への参照をすべて、Bookstore2Universal\_10 に変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-134">Edit the source code and markup files that you just copied and change any references to the Bookstore2WPSL8 namespace to Bookstore2Universal\_10.</span></span> <span data-ttu-id="14186-135">これをすばやく行うには、**[フォルダーを指定して置換]** 機能を使います。</span><span class="sxs-lookup"><span data-stu-id="14186-135">A quick way to do that is to use the **Replace In Files** feature.</span></span> <span data-ttu-id="14186-136">ビュー モデルのソース ファイルに含まれている命令型コードでは、移植作業のために次の変更を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="14186-136">In the imperative code in the view model source file, these porting changes are needed.</span></span>

-   <span data-ttu-id="14186-137">`System.ComponentModel.DesignerProperties` を `DesignMode` に変更した後、これに対して **[解決]** コマンドを使います。</span><span class="sxs-lookup"><span data-stu-id="14186-137">Change `System.ComponentModel.DesignerProperties` to `DesignMode` and then use the **Resolve** command on it.</span></span> <span data-ttu-id="14186-138">`IsInDesignTool` プロパティを削除し、IntelliSense を使って適切なプロパティ名 (`DesignModeEnabled`) を追加します。</span><span class="sxs-lookup"><span data-stu-id="14186-138">Delete the `IsInDesignTool` property and use IntelliSense to add the correct property name: `DesignModeEnabled`.</span></span>
-   <span data-ttu-id="14186-139">`ImageSource` に対して **[解決]** コマンドを使います。</span><span class="sxs-lookup"><span data-stu-id="14186-139">Use the **Resolve** command on `ImageSource`.</span></span>
-   <span data-ttu-id="14186-140">`BitmapImage` に対して **[解決]** コマンドを使います。</span><span class="sxs-lookup"><span data-stu-id="14186-140">Use the **Resolve** command on `BitmapImage`.</span></span>
-   <span data-ttu-id="14186-141">`using System.Windows.Media;` と `using System.Windows.Media.Imaging;` を削除します。</span><span class="sxs-lookup"><span data-stu-id="14186-141">Delete `using System.Windows.Media;` and `using System.Windows.Media.Imaging;`.</span></span>
-   <span data-ttu-id="14186-142">**Bookstore2Universal\_10.BookstoreViewModel.AppName** プロパティによって返された値を "BOOKSTORE2WPSL8" から "BOOKSTORE2UNIVERSAL" に変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-142">Change the value returned by the **Bookstore2Universal\_10.BookstoreViewModel.AppName** property from "BOOKSTORE2WPSL8" to "BOOKSTORE2UNIVERSAL".</span></span>
-   <span data-ttu-id="14186-143">「[Bookstore1](wpsl-to-uwp-case-study-bookstore1.md)」の場合と同じように、**BookSku.CoverImage** プロパティの実装を更新します (「[ビュー モデルへの画像のバインド](wpsl-to-uwp-case-study-bookstore1.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="14186-143">Just as we did for [Bookstore1](wpsl-to-uwp-case-study-bookstore1.md), update the implementation of the **BookSku.CoverImage** property (see [Binding an Image to a view model](wpsl-to-uwp-case-study-bookstore1.md)).</span></span>

<span data-ttu-id="14186-144">MainPage.xaml では、初期の移植作業のために次の変更を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="14186-144">In MainPage.xaml, these initial porting changes are needed.</span></span>

-   <span data-ttu-id="14186-145">`phone:PhoneApplicationPage` を `Page` に変更します (プロパティ要素構文での出現箇所を含みます)。</span><span class="sxs-lookup"><span data-stu-id="14186-145">Change `phone:PhoneApplicationPage` to `Page` (including the occurrences in property element syntax).</span></span>
-   <span data-ttu-id="14186-146">`phone` と `shell` の名前空間のプレフィックス宣言を削除します。</span><span class="sxs-lookup"><span data-stu-id="14186-146">Delete the `phone` and `shell` namespace prefix declarations.</span></span>
-   <span data-ttu-id="14186-147">その他の名前空間のプレフィックス宣言で、"clr-namespace" を "using" に変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-147">Change "clr-namespace" to "using" in the remaining namespace prefix declaration.</span></span>
-   <span data-ttu-id="14186-148">`SupportedOrientations="Portrait"` と `Orientation="Portrait"` を削除し、新しいプロジェクトのアプリ パッケージ マニフェストで**縦方向**を構成します。</span><span class="sxs-lookup"><span data-stu-id="14186-148">Delete `SupportedOrientations="Portrait"`, and `Orientation="Portrait"`, and configure **Portrait** in the app package manifest in the new project.</span></span>
-   <span data-ttu-id="14186-149">`shell:SystemTray.IsVisible="True"` を削除します。</span><span class="sxs-lookup"><span data-stu-id="14186-149">Delete `shell:SystemTray.IsVisible="True"`.</span></span>
-   <span data-ttu-id="14186-150">ジャンプ リスト項目コンバーター (マークアップ内にリソースとして含まれています) の種類は、[**Windows.UI.Xaml.Controls.Primitives**](https://msdn.microsoft.com/library/windows/apps/br209818) 名前空間に移動しています。</span><span class="sxs-lookup"><span data-stu-id="14186-150">The types of the jump list item converters (which are present in the markup as resources) have moved to the [**Windows.UI.Xaml.Controls.Primitives**](https://msdn.microsoft.com/library/windows/apps/br209818) namespace.</span></span> <span data-ttu-id="14186-151">そのため、名前空間のプレフィックス宣言 Windows\_UI\_Xaml\_Controls\_Primitives を追加し、これを **Windows.UI.Xaml.Controls.Primitives** にマップします。</span><span class="sxs-lookup"><span data-stu-id="14186-151">So, add the namespace prefix declaration Windows\_UI\_Xaml\_Controls\_Primitives and map it to **Windows.UI.Xaml.Controls.Primitives**.</span></span> <span data-ttu-id="14186-152">ジャンプ リスト項目コンバーターのリソースで、プレフィックスを `phone:` から `Windows_UI_Xaml_Controls_Primitives:` に変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-152">On the jump list item converter resources, change the prefix from `phone:` to `Windows_UI_Xaml_Controls_Primitives:`.</span></span>
-   <span data-ttu-id="14186-153">「[Bookstore1](wpsl-to-uwp-case-study-bookstore1.md)」の場合と同じように、`PhoneTextExtraLargeStyle` **TextBlock** スタイルに対するすべての参照を `SubtitleTextBlockStyle` に対する参照に置き換えます。また、`PhoneTextSubtleStyle` を `SubtitleTextBlockStyle` に、`PhoneTextNormalStyle` を `CaptionTextBlockStyle` に、`PhoneTextTitle1Style` を `HeaderTextBlockStyle` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="14186-153">Just as we did for [Bookstore1](wpsl-to-uwp-case-study-bookstore1.md), replace all references to the `PhoneTextExtraLargeStyle` **TextBlock** style with a reference to `SubtitleTextBlockStyle`, replace `PhoneTextSubtleStyle` with `SubtitleTextBlockStyle`, replace `PhoneTextNormalStyle` with `CaptionTextBlockStyle`, and replace `PhoneTextTitle1Style` with `HeaderTextBlockStyle`.</span></span>
-   <span data-ttu-id="14186-154">`BookTemplate` には例外が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="14186-154">There is one exception in `BookTemplate`.</span></span> <span data-ttu-id="14186-155">2 番目の **TextBlock** のスタイルは、`CaptionTextBlockStyle` を参照している必要があります。</span><span class="sxs-lookup"><span data-stu-id="14186-155">The style of the second **TextBlock** should reference `CaptionTextBlockStyle`.</span></span>
-   <span data-ttu-id="14186-156">`AuthorGroupHeaderTemplate` の内部の **TextBlock** から FontFamily 属性を削除し、**Border** の Background が `PhoneAccentBrush` の代わりに `SystemControlBackgroundAccentBrush` を参照するように設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-156">Remove the FontFamily attribute from the **TextBlock** inside `AuthorGroupHeaderTemplate` and set the Background of the **Border** to reference `SystemControlBackgroundAccentBrush` instead of `PhoneAccentBrush`.</span></span>
-   <span data-ttu-id="14186-157">[表示ピクセルに関連する変更](wpsl-to-uwp-porting-xaml-and-ui.md)のため、マークアップ全体を調べて、すべての固定サイズの寸法 (余白、幅、高さなど) を 0.8 倍にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="14186-157">Because of [changes related to view pixels](wpsl-to-uwp-porting-xaml-and-ui.md), go through the markup and multiply any fixed size dimension (margins, width, height, etc) by 0.8.</span></span>

## <a name="replacing-the-longlistselector"></a><span data-ttu-id="14186-158">LongListSelector の置き換え</span><span class="sxs-lookup"><span data-stu-id="14186-158">Replacing the LongListSelector</span></span>


<span data-ttu-id="14186-159">**LongListSelector** を [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/hh702601) コントロールに置き換えるには、いくつかの手順があります。この手順を始めましょう。</span><span class="sxs-lookup"><span data-stu-id="14186-159">Replacing the **LongListSelector** with a [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/hh702601) control will take several steps, so let's make a start on that.</span></span> <span data-ttu-id="14186-160">**LongListSelector** はグループ化されたデータ ソースに直接バインドされますが、**SemanticZoom** には [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) コントロールや [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705) コントロールが含まれており、これらのコントロールは [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/br209833) アダプターを経由してデータに間接的にバインドされます。</span><span class="sxs-lookup"><span data-stu-id="14186-160">A **LongListSelector** binds directly to the grouped data source, but a **SemanticZoom** contains [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) or [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705) controls, which bind indirectly to the data via a [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/br209833) adapter.</span></span> <span data-ttu-id="14186-161">**CollectionViewSource** はマークアップ内にリソースとして含まれている必要があります。そのため、最初にこの項目を MainPage.xaml の `<Page.Resources>` 内にあるマークアップに追加します。</span><span class="sxs-lookup"><span data-stu-id="14186-161">The **CollectionViewSource** needs to be present in the markup as a resource, so let's begin by adding that to the markup in MainPage.xaml inside `<Page.Resources>`.</span></span>

```xml
    <CollectionViewSource
        x:Name="AuthorHasACollectionOfBookSku"
        Source="{Binding Authors}"
        IsSourceGrouped="true"/>
```

<span data-ttu-id="14186-162">**LongListSelector.ItemsSource** のバインディングは **CollectionViewSource.Source** の値になり、**LongListSelector.IsGroupingEnabled** は **CollectionViewSource.IsSourceGrouped** になることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="14186-162">Note that the binding on **LongListSelector.ItemsSource** becomes the value of **CollectionViewSource.Source**, and **LongListSelector.IsGroupingEnabled** becomes **CollectionViewSource.IsSourceGrouped**.</span></span> <span data-ttu-id="14186-163">**CollectionViewSource** には名前 (キーではないので注意してください) があるので、この名前に対してバインドすることができます。</span><span class="sxs-lookup"><span data-stu-id="14186-163">The **CollectionViewSource** has a name (note: not a key, as you might expect) so that we can bind to it.</span></span>

<span data-ttu-id="14186-164">次に、`phone:LongListSelector` をこのマークアップに置き換えます。これにより、暫定的な **SemanticZoom** が機能します。</span><span class="sxs-lookup"><span data-stu-id="14186-164">Next, replace the `phone:LongListSelector` with this markup, which will give us a preliminary **SemanticZoom** to work with.</span></span>

```xml
    <SemanticZoom>
        <SemanticZoom.ZoomedInView>
            <ListView
                ItemsSource="{Binding Source={StaticResource AuthorHasACollectionOfBookSku}}"
                ItemTemplate="{StaticResource BookTemplate}">
                <ListView.GroupStyle>
                    <GroupStyle
                        HeaderTemplate="{StaticResource AuthorGroupHeaderTemplate}"
                        HidesIfEmpty="True"/>
                </ListView.GroupStyle>
            </ListView>
        </SemanticZoom.ZoomedInView>
        <SemanticZoom.ZoomedOutView>
            <ListView
                ItemsSource="{Binding CollectionGroups, Source={StaticResource AuthorHasACollectionOfBookSku}}"
                ItemTemplate="{StaticResource ZoomedOutAuthorTemplate}"/>
        </SemanticZoom.ZoomedOutView>
    </SemanticZoom>
```

<span data-ttu-id="14186-165">**LongListSelector** でのフラット リスト モードとジャンプ リスト モードに関する概念は、**SemanticZoom** での拡大表示と縮小表示に関する概念にそれぞれ対応しています。</span><span class="sxs-lookup"><span data-stu-id="14186-165">The **LongListSelector** notion of flat list and jump list modes is answered in the **SemanticZoom** notion of a zoomed-in and a zoomed-out view, respectively.</span></span> <span data-ttu-id="14186-166">拡大表示はプロパティであり、そのプロパティを **ListView** のインスタンスに設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-166">The zoomed-in view is a property, and you set that property to an instance of a **ListView**.</span></span> <span data-ttu-id="14186-167">この場合、縮小表示も **ListView** に設定され、両方の **ListView** コントロールが **CollectionViewSource** にバインドされます。</span><span class="sxs-lookup"><span data-stu-id="14186-167">In this case, the zoomed-out view is also set to a **ListView**, and both **ListView** controls are bound to our **CollectionViewSource**.</span></span> <span data-ttu-id="14186-168">拡大表示では、**LongListSelector** のフラット リストで使われているものと同じ項目テンプレート、グループ ヘッダー テンプレート、および **HideEmptyGroups** 設定 (現在は **HidesIfEmpty** という名前) が使われます。</span><span class="sxs-lookup"><span data-stu-id="14186-168">The zoomed-in view uses the same item template, group header template, and **HideEmptyGroups** setting (now named **HidesIfEmpty**) as the **LongListSelector**'s flat list does.</span></span> <span data-ttu-id="14186-169">縮小表示では、**LongListSelector** のジャンプ リストのスタイル (`AuthorNameJumpListStyle`) に含まれているものと類似した項目テンプレートが使われます。</span><span class="sxs-lookup"><span data-stu-id="14186-169">And the zoomed-out view uses an item template very much like the one inside the **LongListSelector**'s jump list style (`AuthorNameJumpListStyle`).</span></span> <span data-ttu-id="14186-170">また、縮小表示は **CollectionViewSource** の特殊なプロパティ (**CollectionGroups**) にバインドされていることにも注意してください。このプロパティは、項目ではなくグループを含んでいるコレクションを表しています。</span><span class="sxs-lookup"><span data-stu-id="14186-170">Also, note that the zoomed-out view binds to a special property of the **CollectionViewSource** named **CollectionGroups**, which is a collection containing the groups rather than the items.</span></span>

<span data-ttu-id="14186-171">`AuthorNameJumpListStyle` は不要になりました (ただしすべてが不要になったわけではありません)。</span><span class="sxs-lookup"><span data-stu-id="14186-171">We no longer need `AuthorNameJumpListStyle`, at least not all of it.</span></span> <span data-ttu-id="14186-172">縮小表示ビューで必要となるのは、グループ (このアプリでは著者) のデータ テンプレートだけです。</span><span class="sxs-lookup"><span data-stu-id="14186-172">We only need the data template for the groups (which are authors in this app) in the zoomed-out view.</span></span> <span data-ttu-id="14186-173">ここでは、`AuthorNameJumpListStyle` スタイルを削除し、このスタイルを次のデータ テンプレートに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="14186-173">So, we delete the `AuthorNameJumpListStyle` style and replace it with this data template.</span></span>

```xml
   <DataTemplate x:Key="ZoomedOutAuthorTemplate">
        <Border Margin="9.6,0.8" Background="{Binding Converter={StaticResource JumpListItemBackgroundConverter}}">
            <TextBlock Margin="9.6,0,9.6,4.8" Text="{Binding Group.Name}" Style="{StaticResource SubtitleTextBlockStyle}"
            Foreground="{Binding Converter={StaticResource JumpListItemForegroundConverter}}" VerticalAlignment="Bottom"/>
        </Border>
    </DataTemplate>
```

<span data-ttu-id="14186-174">このデータ テンプレートのデータ コンテキストは、項目ではなくグループであるため、**Group** という名前の特殊なプロパティにバインドすることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="14186-174">Note that, since the data context of this data template is a group rather than an item, we bind to a special property named **Group**.</span></span>

<span data-ttu-id="14186-175">これで、アプリをビルドして実行できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="14186-175">You can build and run the app now.</span></span> <span data-ttu-id="14186-176">モバイル エミュレーターでは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="14186-176">Here's how it looks on the mobile emulator.</span></span>

![最初のソース コードの変更を加えたモバイルの UWP アプリ](images/wpsl-to-uwp-case-studies/c02-02-mob10-initial-source-code-changes.png)

<span data-ttu-id="14186-178">ビュー モデル、拡大表示、縮小表示は適切に連携しますが、スタイル設定やテンプレート化の作業を必要とする問題があります。</span><span class="sxs-lookup"><span data-stu-id="14186-178">The view model and the zoomed-in and zoomed-out views are working together correctly, although one issue is that we need to do a little more styling and templating work.</span></span> <span data-ttu-id="14186-179">たとえば、適切なスタイルとブラシがまだ使われていない、テキストが縮小表示のためにクリックできるグループ ヘッダーに表示されないようにします。デスクトップ デバイスでアプリを実行すると、アプリがまだ対応していないこと、最適なエクスペリエンスと、windows できる可能性のあるモバイル デバイスの画面よりもずっとサイズが大きい大型デバイス上の領域を使用するためのユーザー インターフェイスは、2 つ目の問題が表示されます。</span><span class="sxs-lookup"><span data-stu-id="14186-179">For example, the correct styles and brushes are not yet being used, so the text is invisible on the group headers that you can click to zoom out. If you run the app on a desktop device, then you'll see a second issue, which is that the app doesn't yet adapt its user-interface to give the best experience and use of space on larger devices where windows can be potentially much larger than the screen of a mobile device.</span></span> <span data-ttu-id="14186-180">次のセクション (「[最初のスタイル設定とテンプレート化](#initial-styling-and-templating)」、「[アダプティブ UI](#adaptive-ui)」、「[最終的なスタイル設定](#final-styling)」) では、これらの問題に対処します。</span><span class="sxs-lookup"><span data-stu-id="14186-180">So, in the next few sections ([Initial styling and templating](#initial-styling-and-templating), [Adaptive UI](#adaptive-ui), and [Final styling](#final-styling)), we'll remedy those issues.</span></span>

## <a name="initial-styling-and-templating"></a><span data-ttu-id="14186-181">最初のスタイル設定とテンプレート化</span><span class="sxs-lookup"><span data-stu-id="14186-181">Initial styling and templating</span></span>

<span data-ttu-id="14186-182">適切な間隔でグループ ヘッダーを配置するには、`AuthorGroupHeaderTemplate` を編集し、**Border** で **Margin** を `"0,0,0,9.6"` に設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-182">To space out the group headers nicely, edit `AuthorGroupHeaderTemplate` and set a **Margin** of `"0,0,0,9.6"` on the **Border**.</span></span>

<span data-ttu-id="14186-183">適切な間隔で書籍項目を配置するには、`BookTemplate` を編集し、両方の **TextBlock** で **Margin** を `"9.6,0"` に設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-183">To space out the book items nicely, Edit `BookTemplate` and set the **Margin** to `"9.6,0"` on both **TextBlock**s.</span></span>

<span data-ttu-id="14186-184">アプリ名とページ タイトルのレイアウトを向上させるには、`TitlePanel` 内で、2 番目の **TextBlock** の上余白を削除します。そのためには、**Margin** の値を `"7.2,0,0,0"` に設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-184">To lay out the app name and the page title a little better, inside `TitlePanel`, remove the top **Margin** on the second **TextBlock** by setting the value to `"7.2,0,0,0"`.</span></span> <span data-ttu-id="14186-185">また、`TitlePanel` 自体で、余白を `0` (または適切な外観になる任意の値) に設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-185">And on `TitlePanel` itself, set the margin to `0` (or whatever value looks good to you)</span></span>

<span data-ttu-id="14186-186">`LayoutRoot` の Background を `"{ThemeResource ApplicationPageBackgroundThemeBrush}"` に変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-186">Change `LayoutRoot`'s Background to `"{ThemeResource ApplicationPageBackgroundThemeBrush}"`.</span></span>

## <a name="adaptive-ui"></a><span data-ttu-id="14186-187">アダプティブ UI</span><span class="sxs-lookup"><span data-stu-id="14186-187">Adaptive UI</span></span>

<span data-ttu-id="14186-188">Phone アプリを基にして作業を開始したため、この段階のプロセスでは、移植したアプリの UI レイアウトが小型のデバイスや狭いウィンドウにのみ適したレイアウトになっているのは当然です。</span><span class="sxs-lookup"><span data-stu-id="14186-188">Because we started out with a phone app, it's no surprise that our ported app's UI layout really only makes sense for small devices and narrow windows at this stage in the process.</span></span> <span data-ttu-id="14186-189">実現しようとしている UI レイアウトは、アプリを幅の広いウィンドウで実行しているとき (大型画面を備えたデバイスの場合) には自動的に調整して広い領域を活用し、アプリのウィンドウが狭い場合 (小型のデバイスが該当しますが、大型のデバイスの場合もあります) は現在の UI のみを使うレイアウトです。</span><span class="sxs-lookup"><span data-stu-id="14186-189">But, we'd really like the UI layout to adapt itself and make better use of space when the app is running in a wide window (which is only possible on a device with a large screen), and for it only to use the UI that we have currently when the app's window is narrow (which happens on a small device, and can also happen on a large device).</span></span>

<span data-ttu-id="14186-190">これを実現するために、アダプティブな Visual State Manager 機能を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="14186-190">We can use the adaptive Visual State Manager feature to achieve this.</span></span> <span data-ttu-id="14186-191">現在使っているテンプレートを利用して、既定で UI が幅の狭い状態でレイアウトされるように、視覚要素のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-191">We'll set properties on visual elements so that, by default, the UI is laid out in the narrow state using the templates that we're using right now.</span></span> <span data-ttu-id="14186-192">その後で、アプリのウィンドウ幅が特定のサイズ以上になる状況を確認します (このサイズは[有効ピクセル](wpsl-to-uwp-porting-xaml-and-ui.md)の単位で測定します)。また、より大きなレイアウトやより幅の広いレイアウトを実現できるように、視覚要素のプロパティを変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-192">Then, we'll detect when the app's window is wider-than-or-equal-to a specific size (measured in units of [effective pixels](wpsl-to-uwp-porting-xaml-and-ui.md)), and in response, we'll change the properties of visual elements so that we get a larger, and wider, layout.</span></span> <span data-ttu-id="14186-193">これらのプロパティの変更を表示状態として設定し、アダプティブなトリガーを使って、有効ピクセル単位のウィンドウ幅に応じて、その表示状態を適用するかどうかを継続的に監視し判断します。</span><span class="sxs-lookup"><span data-stu-id="14186-193">We'll put those property changes in a visual state, and we'll use an adaptive trigger to continuously monitor and determine whether to apply that visual state, or not, depending on the width of the window in effective pixels.</span></span> <span data-ttu-id="14186-194">この場合はウィンドウの幅でトリガーしていますが、ウィンドウの高さでトリガーすることもできます。</span><span class="sxs-lookup"><span data-stu-id="14186-194">We're triggering on window width in this case, but it's possible to trigger on window height, too.</span></span>

<span data-ttu-id="14186-195">この使用事例では、ウィンドウの最小幅は 548 epx が適しています。これは、最も小型のデバイスで幅の広いレイアウトを表示する際に適したサイズであるためです。</span><span class="sxs-lookup"><span data-stu-id="14186-195">A minimum window width of 548 epx is appropriate for this use case because that's the size of the smallest device we would want to show the wide layout on.</span></span> <span data-ttu-id="14186-196">通常、電話は 548 epx よりも小さいため、電話のような小型のデバイスでは既定の幅の狭いレイアウトをそのまま使います。</span><span class="sxs-lookup"><span data-stu-id="14186-196">Phones are typically smaller than 548 epx, so on a small device like that, we'd remain in the default narrow layout.</span></span> <span data-ttu-id="14186-197">PC の既定では、ワイド状態への切り替えをトリガーできる十分な幅でウィンドウが開き、250 x 250 サイズの項目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="14186-197">On a PC, the window will launch by default wide enough to trigger the switch to the wide state, which will display 250x250-sized items.</span></span> <span data-ttu-id="14186-198">この状態でウィンドウをドラッグして、250 x 250 サイズの項目を最低 2 列分は表示できる幅の狭いウィンドウにすることができます。</span><span class="sxs-lookup"><span data-stu-id="14186-198">From there, you'll be able to drag the window narrow enough to display a minimum of two columns of the 250x250 items.</span></span> <span data-ttu-id="14186-199">これよりも幅を狭くすると、トリガーが非アクティブ化されます。これにより、幅の広い表示状態が削除され、既定の幅の狭いレイアウトが有効になります。</span><span class="sxs-lookup"><span data-stu-id="14186-199">Any narrower than that and the trigger will deactivate, the wide visual state will be removed, and the default narrow layout will be in effect.</span></span>

<span data-ttu-id="14186-200">アダプティブな Visual State Manager で作業する前に、まずワイド状態を設計する必要があります。つまり、マークアップに新しい視覚要素とテンプレートを追加することを意味します。</span><span class="sxs-lookup"><span data-stu-id="14186-200">Before tackling the adaptive Visual State Manager piece, we first need to design the wide state and that means adding some new visual elements and templates to our markup.</span></span> <span data-ttu-id="14186-201">次の手順でその方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="14186-201">These steps describe how to do that.</span></span> <span data-ttu-id="14186-202">視覚要素およびテンプレートの命名規則として、ワイド状態用のすべての要素やテンプレートには、"wide" という単語を含めます。</span><span class="sxs-lookup"><span data-stu-id="14186-202">By way of naming conventions for visual elements and templates, we'll include the word "wide" in the name of any element or template that is for the wide state.</span></span> <span data-ttu-id="14186-203">要素またはテンプレートの名前に "wide" という単語が含まれていない場合、狭い状態の要素やテンプレートであると見なすことができます。これは、既定の状態であり、そのプロパティ値はページ内の視覚要素のローカル値として設定されます。</span><span class="sxs-lookup"><span data-stu-id="14186-203">If an element or template does not contain the word "wide", then you can assume that it is for the narrow state, which is the default state and whose property values are set as local values on visual elements in the page.</span></span> <span data-ttu-id="14186-204">ワイド状態のプロパティ値のみが、マークアップ内の実際の表示状態によって設定されます。</span><span class="sxs-lookup"><span data-stu-id="14186-204">Only the property values for the wide state are set via an actual Visual State in the markup.</span></span>

-   <span data-ttu-id="14186-205">マークアップ内の [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/hh702601) コントロールのコピーを作成し、そのコピーで `x:Name="narrowSeZo"` を設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-205">Make a copy of the [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/hh702601) control in the markup and set `x:Name="narrowSeZo"` on the copy.</span></span> <span data-ttu-id="14186-206">元のコントロールでは、`x:Name="wideSeZo"` を設定し、既定ではワイド状態が表示されないように `Visibility="Collapsed"` も設定します。</span><span class="sxs-lookup"><span data-stu-id="14186-206">On the original, set `x:Name="wideSeZo"` and also set `Visibility="Collapsed"` so that the wide one is not visible by default.</span></span>
-   <span data-ttu-id="14186-207">`wideSeZo` で、拡大表示と縮小表示の両方の **ListView** を **GridView** に変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-207">In `wideSeZo`, change the **ListView**s to **GridView**s in both the zoomed-in view and the zoomed-out view.</span></span>
-   <span data-ttu-id="14186-208">3 つのリソース `AuthorGroupHeaderTemplate`、`ZoomedOutAuthorTemplate`、`BookTemplate` のコピーを作成し、コピーのキーに `Wide` という単語を追加します。</span><span class="sxs-lookup"><span data-stu-id="14186-208">Make a copy of these three resources `AuthorGroupHeaderTemplate`, `ZoomedOutAuthorTemplate`, and `BookTemplate` and append the word `Wide` to the keys of the copies.</span></span> <span data-ttu-id="14186-209">また、これらの新しいリソースのキーを参照するように、`wideSeZo` を更新します。</span><span class="sxs-lookup"><span data-stu-id="14186-209">Also, update `wideSeZo` so that it references the keys of these new resources.</span></span>
-   <span data-ttu-id="14186-210">`AuthorGroupHeaderTemplateWide` の内容を `<TextBlock Style="{StaticResource SubheaderTextBlockStyle}" Text="{Binding Name}"/>` に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="14186-210">Replace the contents of `AuthorGroupHeaderTemplateWide` with `<TextBlock Style="{StaticResource SubheaderTextBlockStyle}" Text="{Binding Name}"/>`.</span></span>
-   <span data-ttu-id="14186-211">`ZoomedOutAuthorTemplateWide` の内容を次のように置き換えます。</span><span class="sxs-lookup"><span data-stu-id="14186-211">Replace the contents of `ZoomedOutAuthorTemplateWide` with:</span></span>

```xml
    <Grid HorizontalAlignment="Left" Width="250" Height="250" >
        <Border Background="{StaticResource ListViewItemPlaceholderBackgroundThemeBrush}"/>
        <StackPanel VerticalAlignment="Bottom" Background="{StaticResource ListViewItemOverlayBackgroundThemeBrush}">
          <TextBlock Foreground="{StaticResource ListViewItemOverlayForegroundThemeBrush}"
              Style="{StaticResource SubtitleTextBlockStyle}"
            Height="80" Margin="15,0" Text="{Binding Group.Name}"/>
        </StackPanel>
    </Grid>
```

-   <span data-ttu-id="14186-212">`BookTemplateWide` の内容を次のように置き換えます。</span><span class="sxs-lookup"><span data-stu-id="14186-212">Replace the contents of `BookTemplateWide` with:</span></span>

```xml
    <Grid HorizontalAlignment="Left" Width="250" Height="250">
        <Border Background="{StaticResource ListViewItemPlaceholderBackgroundThemeBrush}"/>
        <Image Source="{Binding CoverImage}" Stretch="UniformToFill"/>
        <StackPanel VerticalAlignment="Bottom" Background="{StaticResource ListViewItemOverlayBackgroundThemeBrush}">
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}"
                Foreground="{StaticResource ListViewItemOverlaySecondaryForegroundThemeBrush}"
                TextWrapping="NoWrap" TextTrimming="CharacterEllipsis"
                Margin="12,0,24,0" Text="{Binding Title}"/>
            <TextBlock Style="{StaticResource CaptionTextBlockStyle}" Text="{Binding Author.Name}"
                Foreground="{StaticResource ListViewItemOverlaySecondaryForegroundThemeBrush}" TextWrapping="NoWrap"
                TextTrimming="CharacterEllipsis" Margin="12,0,12,12"/>
        </StackPanel>
    </Grid>
```

-   <span data-ttu-id="14186-213">ワイド状態では、拡大表示のグループ間の垂直方向の間隔を大きくする必要があります。</span><span class="sxs-lookup"><span data-stu-id="14186-213">For the wide state, the groups in the zoomed-in view will need more vertical breathing space around them.</span></span> <span data-ttu-id="14186-214">項目パネル テンプレートを作成し参照することで、必要な結果を得ることができます。</span><span class="sxs-lookup"><span data-stu-id="14186-214">Creating and referencing an items panel template will give us the results we want.</span></span> <span data-ttu-id="14186-215">マークアップは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="14186-215">Here's how the markup looks.</span></span>

```xml
   <ItemsPanelTemplate x:Key="ZoomedInItemsPanelTemplate">
        <ItemsWrapGrid Orientation="Horizontal" GroupPadding="0,0,0,20"/>
    </ItemsPanelTemplate>
    ...

    <SemanticZoom x:Name="wideSeZo" ... >
        <SemanticZoom.ZoomedInView>
            <GridView
            ...
            ItemsPanel="{StaticResource ZoomedInItemsPanelTemplate}">
            ...
```

-   <span data-ttu-id="14186-216">最後に、適切な Visual State Manager のマークアップを `LayoutRoot` の最初の子として追加します。</span><span class="sxs-lookup"><span data-stu-id="14186-216">Finally, add the appropriate Visual State Manager markup as the first child of `LayoutRoot`.</span></span>

```xml
    <Grid x:Name="LayoutRoot" ... >
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState x:Name="WideState">
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="548"/>
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="wideSeZo.Visibility" Value="Visible"/>
                        <Setter Target="narrowSeZo.Visibility" Value="Collapsed"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

    ...
```

## <a name="final-styling"></a><span data-ttu-id="14186-217">最終的なスタイル設定</span><span class="sxs-lookup"><span data-stu-id="14186-217">Final styling</span></span>

<span data-ttu-id="14186-218">残りの作業は、スタイルの最終的な調整です。</span><span class="sxs-lookup"><span data-stu-id="14186-218">All that remains are some final styling tweaks.</span></span>

-   <span data-ttu-id="14186-219">`AuthorGroupHeaderTemplate` で、**TextBlock** に対して `Foreground="White"` を設定します。これにより、モバイル デバイス ファミリで実行したときに適切に表示されます。</span><span class="sxs-lookup"><span data-stu-id="14186-219">In `AuthorGroupHeaderTemplate`, set `Foreground="White"` on the **TextBlock** so that it looks correct when running on the mobile device family.</span></span>
-   <span data-ttu-id="14186-220">`AuthorGroupHeaderTemplate` と `ZoomedOutAuthorTemplate` の両方で、**TextBlock** に `FontWeight="SemiBold"` を追加します。</span><span class="sxs-lookup"><span data-stu-id="14186-220">Add `FontWeight="SemiBold"` to the **TextBlock** in both `AuthorGroupHeaderTemplate` and `ZoomedOutAuthorTemplate`.</span></span>
-   <span data-ttu-id="14186-221">`narrowSeZo`で、縮小表示ビューでのグループ ヘッダーと著者は、伸縮表示ではなく左揃えで表示されます。ここではその設定を行います。</span><span class="sxs-lookup"><span data-stu-id="14186-221">In `narrowSeZo`, the group headers and the authors in the zoomed-out view are left-aligned instead of stretched, so let's work on that.</span></span> <span data-ttu-id="14186-222">[**HorizontalContentAlignment**](https://msdn.microsoft.com/library/windows/apps/br209417) を `Stretch` に設定して、拡大表示ビュー用の [**HeaderContainerStyle**](https://msdn.microsoft.com/library/windows/apps/dn251841) を作成します。</span><span class="sxs-lookup"><span data-stu-id="14186-222">We'll create a [**HeaderContainerStyle**](https://msdn.microsoft.com/library/windows/apps/dn251841) for the zoomed-in view with [**HorizontalContentAlignment**](https://msdn.microsoft.com/library/windows/apps/br209417) set to `Stretch`.</span></span> <span data-ttu-id="14186-223">次に、同じ [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) を含む、縮小表示ビュー用の [**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/br242817) を作成します。</span><span class="sxs-lookup"><span data-stu-id="14186-223">And we'll create an [**ItemContainerStyle**](https://msdn.microsoft.com/library/windows/apps/br242817) for the zoomed-out view containing that same [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817).</span></span> <span data-ttu-id="14186-224">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="14186-224">Here's what that looks like.</span></span>

```xml
   <Style x:Key="AuthorGroupHeaderContainerStyle" TargetType="ListViewHeaderItem">
        <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
    </Style>

    <Style x:Key="ZoomedOutAuthorItemContainerStyle" TargetType="ListViewItem">
        <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
    </Style>

    ...

    <SemanticZoom x:Name="narrowSeZo" ... >
        <SemanticZoom.ZoomedInView>
            <ListView
            ...
                <ListView.GroupStyle>
                    <GroupStyle
                    ...
                    HeaderContainerStyle="{StaticResource AuthorGroupHeaderContainerStyle}"
                    ...
        <SemanticZoom.ZoomedOutView>
            <ListView
                ...
                ItemContainerStyle="{StaticResource ZoomedOutAuthorItemContainerStyle}"
                ...
```

<span data-ttu-id="14186-225">スタイル設定操作の最後のシーケンスで、アプリの外観は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="14186-225">That last sequence of styling operations leaves the app looking like this.</span></span>

![デスクトップ デバイスで動作中の、移植された Windows 10 アプリ (2 つのサイズのウィンドウによる拡大表示)](images/w8x-to-uwp-case-studies/c02-07-desk10-zi-ported.png)

<span data-ttu-id="14186-227">デスクトップ デバイス、拡大表示ビュー、2 つのサイズのウィンドウで実行されている、移植された windows 10 アプリ 
![デスクトップ デバイス、縮小表示ビュー、2 つのサイズのウィンドウで実行されている、移植された windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="14186-227">The ported Windows10 app running on a Desktop device, zoomed-in view, two sizes of window  
![the ported windows 10 app running on a desktop device, zoomed-out view, two sizes of window</span></span>](images/w8x-to-uwp-case-studies/c02-08-desk10-zo-ported.png)

<span data-ttu-id="14186-228">デスクトップ デバイス、縮小表示ビュー、2 つのサイズのウィンドウで実行されている、移植された windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="14186-228">The ported Windows10 app running on a Desktop device, zoomed-out view, two sizes of window</span></span>

![モバイル デバイスで動作中の、移植された Windows 10 アプリ (拡大表示)](images/w8x-to-uwp-case-studies/c02-09-mob10-zi-ported.png)

<span data-ttu-id="14186-230">拡大表示ビューのモバイル デバイスで実行されている、移植された windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="14186-230">The ported Windows10 app running on a Mobile device, zoomed-in view</span></span>

![モバイル デバイスで動作中の、移植された Windows 10 アプリ (縮小表示)](images/w8x-to-uwp-case-studies/c02-10-mob10-zo-ported.png)

<span data-ttu-id="14186-232">モバイル デバイス、縮小表示で実行されている、移植された windows 10 アプリ</span><span class="sxs-lookup"><span data-stu-id="14186-232">The ported Windows10 app running on a Mobile device, zoomed-out view</span></span>

## <a name="making-the-view-model-more-flexible"></a><span data-ttu-id="14186-233">ビュー モデルの柔軟性の向上</span><span class="sxs-lookup"><span data-stu-id="14186-233">Making the view model more flexible</span></span>

<span data-ttu-id="14186-234">このセクションでは、UWP を使うようにアプリを移行することによって利用可能になる機能の例を紹介します。</span><span class="sxs-lookup"><span data-stu-id="14186-234">This section contains an example of facilities that open up to us by virtue of having moved our app to use the UWP.</span></span> <span data-ttu-id="14186-235">ここでは、**CollectionViewSource** を使ってアクセスするときにビュー モデルの柔軟性を向上させるために実行できるオプションの手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="14186-235">Here, we explain optional steps that you can follow to make your view model more flexible when accessed via a **CollectionViewSource**.</span></span> <span data-ttu-id="14186-236">ビュー モデル (ソース ファイルは ViewModel\\BookstoreViewModel.cs) WindowsPhone Silverlight アプリ Bookstore2WPSL8 から移植することから派生した、Author という名前のクラスが含まれています**一覧&lt;T&gt;**、 **T**は BookSku します。</span><span class="sxs-lookup"><span data-stu-id="14186-236">The view model (the source file is in ViewModel\\BookstoreViewModel.cs) that we ported from the WindowsPhone Silverlight app Bookstore2WPSL8 contains a class named Author, which derives from **List&lt;T&gt;**, where **T** is BookSku.</span></span> <span data-ttu-id="14186-237">これは、Author クラスが BookSku の*グループである*ことを意味します。</span><span class="sxs-lookup"><span data-stu-id="14186-237">That means that the Author class *is a* group of BookSku.</span></span>

<span data-ttu-id="14186-238">**CollectionViewSource.Source** を Authors にバインドするとき、Authors 内の各 Author が*何か*のグループであるということを伝える必要があります。</span><span class="sxs-lookup"><span data-stu-id="14186-238">When we bind **CollectionViewSource.Source** to Authors, the only thing we're communicating is that each Author in Authors is a group of *something*.</span></span> <span data-ttu-id="14186-239">このケース スタディでは、**CollectionViewSource** に依存して、Author が BookSku のグループであることを特定しています。</span><span class="sxs-lookup"><span data-stu-id="14186-239">We leave it to the **CollectionViewSource** to determine that Author is, in this case, a group of BookSku.</span></span> <span data-ttu-id="14186-240">この設定でも機能しますが、柔軟性はありません。</span><span class="sxs-lookup"><span data-stu-id="14186-240">That works: but it's not flexible.</span></span> <span data-ttu-id="14186-241">Author が BookSku のグループ*および*著者の住所のグループの*両方*を表す必要がある場合は、どうしたらよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="14186-241">What if we want Author to be *both* a group of BookSku *and* a group of the addresses where the author has lived?</span></span> <span data-ttu-id="14186-242">Author を、これらの両方のグループにすることは*できません*。</span><span class="sxs-lookup"><span data-stu-id="14186-242">Author can't *be* both of those groups.</span></span> <span data-ttu-id="14186-243">ただし、Author に任意の数のグループを*保持させる*ことはできます。</span><span class="sxs-lookup"><span data-stu-id="14186-243">But, Author can *have* any number of groups.</span></span> <span data-ttu-id="14186-244">これが解決策となります。つまり、現在使っている "*グループである*" というパターンの代わりに、またはこのパターンに加えて、"*グループを保持する*" というパターンを使います。</span><span class="sxs-lookup"><span data-stu-id="14186-244">And that's the solution: use the *has-a-group* pattern instead of, or in addition to, the *is-a-group* pattern that we're using currently.</span></span> <span data-ttu-id="14186-245">以下にその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="14186-245">Here's how:</span></span>

-   <span data-ttu-id="14186-246">Author が **List&lt;T&gt;** から派生しないように変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-246">Change Author so that it no longer derives from **List&lt;T&gt;**.</span></span>
-   <span data-ttu-id="14186-247">次のフィールドを Author に追加します: `private ObservableCollection<BookSku> bookSkus = new ObservableCollection<BookSku>();`。</span><span class="sxs-lookup"><span data-stu-id="14186-247">Add this field to Author: `private ObservableCollection<BookSku> bookSkus = new ObservableCollection<BookSku>();`.</span></span>
-   <span data-ttu-id="14186-248">次のプロパティを Author に追加します: `public ObservableCollection<BookSku> BookSkus { get { return this.bookSkus; } }`。</span><span class="sxs-lookup"><span data-stu-id="14186-248">Add this property to Author: `public ObservableCollection<BookSku> BookSkus { get { return this.bookSkus; } }`.</span></span>
-   <span data-ttu-id="14186-249">当然ですが、上の 2 つの手順を繰り返して、必要な数のグループを Author に追加できます。</span><span class="sxs-lookup"><span data-stu-id="14186-249">And of course we can repeat the above two steps to add as many groups to Author as we need.</span></span>
-   <span data-ttu-id="14186-250">AddBookSku メソッドの実装を `this.BookSkus.Add(bookSku);` に変更します。</span><span class="sxs-lookup"><span data-stu-id="14186-250">Change the implementation of the AddBookSku method to `this.BookSkus.Add(bookSku);`.</span></span>
-   <span data-ttu-id="14186-251">これで、Author は少なくとも 1 つのグループを*保持する*ようになりました。また、**CollectionViewSource** に対して、どのグループを使うかを伝える必要があります。</span><span class="sxs-lookup"><span data-stu-id="14186-251">Now that Author *has* at least one group, we need to communicate to the **CollectionViewSource** which of those groups it should use.</span></span> <span data-ttu-id="14186-252">そのためには、**CollectionViewSource** に次のプロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="14186-252">To do that, add this property to the **CollectionViewSource**:</span></span> `ItemsPath="BookSkus"`

<span data-ttu-id="14186-253">これらの変更を行っても、このアプリの機能は変更されません。ここでは、必要に応じて Author と **CollectionViewSource** を拡張する方法を理解してください。</span><span class="sxs-lookup"><span data-stu-id="14186-253">Those changes leave this app functionally unchanged, but you now know how you could extend Author, and the **CollectionViewSource**, should you need to.</span></span> <span data-ttu-id="14186-254">Author に対して最後の変更を加えましょう。この変更により、**CollectionViewSource.ItemsPath** を指定*しないで* Author を使う場合に、選んだ既定のグループが使われるようになります。</span><span class="sxs-lookup"><span data-stu-id="14186-254">Let's make one last change to Author so that, if we use it *without* specifying **CollectionViewSource.ItemsPath**, a default group of our choosing will be used:</span></span>

```csharp
    public class Author : IEnumerable<BookSku>
    {
        ...

        public IEnumerator<BookSku> GetEnumerator()
        {
            return this.BookSkus.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.BookSkus.GetEnumerator();
        }
    }
```

<span data-ttu-id="14186-255">これで、アプリが同じように動作を続ける場合は、必要に応じて `ItemsPath="BookSkus"` を削除できます。</span><span class="sxs-lookup"><span data-stu-id="14186-255">And now we can choose to remove `ItemsPath="BookSkus"` if we like and the app will still behave the same way.</span></span>

## <a name="conclusion"></a><span data-ttu-id="14186-256">まとめ</span><span class="sxs-lookup"><span data-stu-id="14186-256">Conclusion</span></span>

<span data-ttu-id="14186-257">このケース スタディには、前のケース スタディよりも複雑なユーザー インターフェイスが関連しています。</span><span class="sxs-lookup"><span data-stu-id="14186-257">This case study involved a more ambitious user interface than the previous one.</span></span> <span data-ttu-id="14186-258">すべての機能と WindowsPhone Silverlight の **LongListSelector**の概念- 度を高める- **SemanticZoom**、 **ListView**、 **GridView**、および**CollectionViewSource**の形式での UWP アプリを利用できることが検出されました。</span><span class="sxs-lookup"><span data-stu-id="14186-258">All of the facilities and concepts of the WindowsPhone Silverlight **LongListSelector**—and more—were found to be available to a UWP app in the form of **SemanticZoom**, **ListView**, **GridView**, and **CollectionViewSource**.</span></span> <span data-ttu-id="14186-259">UWP アプリで命令型コードやマークアップの両方を再利用 (コピーと編集) して、最小および最大の Windows デバイスのフォーム ファクターや、その中間のあらゆるサイズに合わせて調整された機能、UI、および操作を実現する方法について説明しました。</span><span class="sxs-lookup"><span data-stu-id="14186-259">We showed how to re-use, or copy-and-edit, both imperative code and markup in a UWP app to achieve functionality, UI, and interactions tailored to suit the narrowest and widest Windows device form factors and all sizes in-between.</span></span>
