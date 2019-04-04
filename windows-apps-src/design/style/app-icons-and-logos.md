---
Description: '[スタート] メニューのアプリ タイル、タスク バー、Microsoft Store、および複数のアプリを表すアプリ アイコン/ロゴを作成する方法。'
title: アプリのアイコンとロゴ
template: detail.hbs
ms.date: 04/17/2018
ms.topic: article
keywords: windows 10, uwp
design-contact: Judysa
doc-status: Published
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: b755e8d165d58ce4303d9fefe6d051abce6c9765
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622457"
---
# <a name="app-icons-and-logos"></a><span data-ttu-id="82de7-104">アプリのアイコンとロゴ</span><span class="sxs-lookup"><span data-stu-id="82de7-104">App icons and logos</span></span> 

<span data-ttu-id="82de7-105">すべてのアプリは、それを表す、アイコンやロゴを備え、Windows シェルで複数の場所にそのアイコンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="82de7-105">Every app has an icon/logo that represents it, and that icon appears in multiple locations in the Windows shell:</span></span> 

:::row:::
    :::column:::
        * <span data-ttu-id="82de7-106">アプリのウィンドウのタイトル バー</span><span class="sxs-lookup"><span data-stu-id="82de7-106">The title bar of your app window</span></span>
        * <span data-ttu-id="82de7-107">[スタート] メニューで、アプリの一覧</span><span class="sxs-lookup"><span data-stu-id="82de7-107">The app list in the start menu</span></span>
        * <span data-ttu-id="82de7-108">タスク バーと タスク マネージャー</span><span class="sxs-lookup"><span data-stu-id="82de7-108">The taskbar and task manager</span></span>
        * <span data-ttu-id="82de7-109">アプリのタイル</span><span class="sxs-lookup"><span data-stu-id="82de7-109">Your app's tiles</span></span>
        * <span data-ttu-id="82de7-110">アプリのスプラッシュ スクリーン</span><span class="sxs-lookup"><span data-stu-id="82de7-110">Your app's splash screen</span></span>
        * <span data-ttu-id="82de7-111">Microsoft Store で</span><span class="sxs-lookup"><span data-stu-id="82de7-111">In the Microsoft Store</span></span>
    :::column-end:::
    :::column:::
        ![windows 10 start and tiles](images/assetguidance01.jpg)
    :::column-end:::
:::row-end:::

<span data-ttu-id="82de7-112">この記事には、アプリのアイコンの作成の基礎に必要となる Visual Studio をそれらを管理し、それらを手動で管理する方法を使用する方法。</span><span class="sxs-lookup"><span data-stu-id="82de7-112">This article covers the basics of creating app icons, how to use Visual Studio to manage them, and how manage them manually, should you need to.</span></span>
 
<span data-ttu-id="82de7-113">(この記事はアイコンが、アプリ自体を表す一般的なアイコンのガイダンスについては、具体的には、[アイコン](icons.md)記事を参照してください。)。</span><span class="sxs-lookup"><span data-stu-id="82de7-113">(This article is specifically for icons that represent the app itself; for general icon guidance, see the [Icons](icons.md) article.)</span></span>

## <a name="icon-types-locations-and-scale-factors"></a><span data-ttu-id="82de7-114">アイコンの種類、場所、およびスケール ファクター</span><span class="sxs-lookup"><span data-stu-id="82de7-114">Icon types, locations, and scale factors</span></span>

<span data-ttu-id="82de7-115">既定では、Visual Studio は、資産のサブディレクトリに、アイコンのアセットを格納します。</span><span class="sxs-lookup"><span data-stu-id="82de7-115">By default, Visual Studio stores your icon assets in an assets subdirectory.</span></span> <span data-ttu-id="82de7-116">アイコン、表示される場所などと呼ばれるさまざまな種類の一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="82de7-116">Here's a list of the different types of icons, where they appear, and what they're called.</span></span> 

| <span data-ttu-id="82de7-117">アイコン名</span><span class="sxs-lookup"><span data-stu-id="82de7-117">Icon name</span></span> | <span data-ttu-id="82de7-118">表示されます。</span><span class="sxs-lookup"><span data-stu-id="82de7-118">Appears in</span></span> | <span data-ttu-id="82de7-119">資産ファイルの名前</span><span class="sxs-lookup"><span data-stu-id="82de7-119">Asset file name</span></span> |
| ---      | ---        | --- |
| <span data-ttu-id="82de7-120">小さなタイル</span><span class="sxs-lookup"><span data-stu-id="82de7-120">Small tile</span></span> | <span data-ttu-id="82de7-121">スタート メニュー</span><span class="sxs-lookup"><span data-stu-id="82de7-121">Start menu</span></span> |  <span data-ttu-id="82de7-122">SmallTile.png</span><span class="sxs-lookup"><span data-stu-id="82de7-122">SmallTile.png</span></span>  |
| <span data-ttu-id="82de7-123">中規模のタイル</span><span class="sxs-lookup"><span data-stu-id="82de7-123">Medium tile</span></span> |<span data-ttu-id="82de7-124">[スタート] メニューには、Microsoft Store の一覧\*</span><span class="sxs-lookup"><span data-stu-id="82de7-124">Start menu,  Microsoft Store listing\*</span></span>  |  <span data-ttu-id="82de7-125">Square150x150Logo.png</span><span class="sxs-lookup"><span data-stu-id="82de7-125">Square150x150Logo.png</span></span> |
| <span data-ttu-id="82de7-126">ワイド タイル</span><span class="sxs-lookup"><span data-stu-id="82de7-126">Wide tile</span></span>  | <span data-ttu-id="82de7-127">スタート メニュー</span><span class="sxs-lookup"><span data-stu-id="82de7-127">Start menu</span></span>   | <span data-ttu-id="82de7-128">Wide310x150Logo.png</span><span class="sxs-lookup"><span data-stu-id="82de7-128">Wide310x150Logo.png</span></span> |
| <span data-ttu-id="82de7-129">大きいタイル</span><span class="sxs-lookup"><span data-stu-id="82de7-129">Large tile</span></span>   | <span data-ttu-id="82de7-130">[スタート] メニューには、Microsoft Store の一覧\*</span><span class="sxs-lookup"><span data-stu-id="82de7-130">Start menu,  Microsoft Store listing\*</span></span> |  <span data-ttu-id="82de7-131">LargeTile.png</span><span class="sxs-lookup"><span data-stu-id="82de7-131">LargeTile.png</span></span>  |
| <span data-ttu-id="82de7-132">アプリ アイコン</span><span class="sxs-lookup"><span data-stu-id="82de7-132">App icon</span></span> | <span data-ttu-id="82de7-133">[スタート] メニューのタスク バー、タスク マネージャーでのアプリの一覧</span><span class="sxs-lookup"><span data-stu-id="82de7-133">App list in start menu, task bar, task manager</span></span> | <span data-ttu-id="82de7-134">Square44x44Logo.png</span><span class="sxs-lookup"><span data-stu-id="82de7-134">Square44x44Logo.png</span></span> |
| <span data-ttu-id="82de7-135">スプラッシュ画面</span><span class="sxs-lookup"><span data-stu-id="82de7-135">Splash screen</span></span> | <span data-ttu-id="82de7-136">アプリのスプラッシュ スクリーン</span><span class="sxs-lookup"><span data-stu-id="82de7-136">The app's splash screen</span></span> | <span data-ttu-id="82de7-137">SplashScreen.png</span><span class="sxs-lookup"><span data-stu-id="82de7-137">SplashScreen.png</span></span>  |
| <span data-ttu-id="82de7-138">バッジ ロゴ</span><span class="sxs-lookup"><span data-stu-id="82de7-138">Badge logo</span></span> | <span data-ttu-id="82de7-139">アプリのタイル</span><span class="sxs-lookup"><span data-stu-id="82de7-139">Your app's tiles</span></span> | <span data-ttu-id="82de7-140">BadgeLogo.png</span><span class="sxs-lookup"><span data-stu-id="82de7-140">BadgeLogo.png</span></span>  |
| <span data-ttu-id="82de7-141">パッケージ ロゴ/ストア ロゴ</span><span class="sxs-lookup"><span data-stu-id="82de7-141">Package logo/Store logo</span></span> | <span data-ttu-id="82de7-142">アプリのインストーラー、パートナー センターで、ストアでは、ストア内の「レビューを書く」オプションで「レポート、アプリ」のオプション</span><span class="sxs-lookup"><span data-stu-id="82de7-142">App installer, Partner Center, the "Report an app" option in the Store, the "Write a review" option in the Store</span></span> | <span data-ttu-id="82de7-143">StoreLogo.png</span><span class="sxs-lookup"><span data-stu-id="82de7-143">StoreLogo.png</span></span>  |

<span data-ttu-id="82de7-144">\* 使用を選択しない限り[表示は、ストア内のイメージのみアップロード](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store)します。</span><span class="sxs-lookup"><span data-stu-id="82de7-144">\* Used unless you choose to [display only uploaded images in the Store](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store).</span></span> 

<span data-ttu-id="82de7-145">これらのアイコンがすべての画面に鮮明させるには、別のディスプレイのスケール ファクターの同じアイコンの複数のバージョンを作成できます。</span><span class="sxs-lookup"><span data-stu-id="82de7-145">To ensure these icons look sharp on every screen, you can create multiple versions of the same icon for different display scale factors.</span></span> 

<span data-ttu-id="82de7-146">スケール ファクターは、テキストなどの UI 要素のサイズを決定します。</span><span class="sxs-lookup"><span data-stu-id="82de7-146">The  scale factor determines the size of UI elements, such as text.</span></span> <span data-ttu-id="82de7-147">スケールは、100% ~ 400% の範囲を考慮します。</span><span class="sxs-lookup"><span data-stu-id="82de7-147">Scale factors range from 100% to 400%.</span></span> <span data-ttu-id="82de7-148">大きな値は、高解像度ディスプレイに表示しやすくより大きなの UI 要素を作成します。</span><span class="sxs-lookup"><span data-stu-id="82de7-148">Larger values create larger UI elements, making them easier to see on high-DPI displays.</span></span> 

:::row:::
    :::column:::
        Windows automatically sets the scale factor for each display based on its DPI (dots-per-inch) and the viewing distance of the device. 

        (Users can override the default value by going to the **Settings &gt; Display &gt; Scale and layout** page.)
    :::column-end:::
    :::column:::
        ![](images/icons/display-settings-screen.png)
    :::column-end:::
:::row-end:::  


<span data-ttu-id="82de7-149">アプリ アイコンのアセットはビットマップ ビットマップは適切にスケーリングしないため、各スケール ファクターのバージョンを各アイコンの資産を提供するをお勧めします。100%、125%、150%、200%、400% です。</span><span class="sxs-lookup"><span data-stu-id="82de7-149">Because app icon assets are bitmaps and bitmaps don't scale well, we recommend providing a version each icon asset for each scale factor: 100%, 125%, 150%, 200%, and 400%.</span></span> <span data-ttu-id="82de7-150">多くのアイコンです。</span><span class="sxs-lookup"><span data-stu-id="82de7-150">That's a lot of icons!</span></span> <span data-ttu-id="82de7-151">さいわい、Visual Studio は、簡単に生成し、これらのアイコンの更新ツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="82de7-151">Fortunately, Visual Studio provides a tool that makes it easy to generate and update these icons.</span></span> 

## <a name="microsoft-store-listing-image"></a><span data-ttu-id="82de7-152">Microsoft Store の一覧の画像</span><span class="sxs-lookup"><span data-stu-id="82de7-152">Microsoft Store listing image</span></span>

<span data-ttu-id="82de7-153">「の指定方法を自分のアプリの一覧については、イメージ、Microsoft Store ででしょうか。」</span><span class="sxs-lookup"><span data-stu-id="82de7-153">"How do I specify images for my app's listing in the Microsoft Store?"</span></span>

<span data-ttu-id="82de7-154">既定では、使用して、パッケージからのイメージの一部、ストア内のこのページの上部にある表に示す (とその他の[送信処理中に指定したイメージ](https://docs.microsoft.com/en-us/windows/uwp/publish/app-screenshots-and-images))。</span><span class="sxs-lookup"><span data-stu-id="82de7-154">By default, we use some of the images from your packages in the Store, as described in the table at the top of this page (along with other [images that you provide during the submission process](https://docs.microsoft.com/en-us/windows/uwp/publish/app-screenshots-and-images)).</span></span> <span data-ttu-id="82de7-155">ただし、ストアが (Xbox を含む)、Windows 10 でのお客様に、一覧を表示するときに、アプリのパッケージでロゴのイメージを使用するを防ぐを代わりに、ストアにアップロードするイメージのみを使用して、オプションがあります。</span><span class="sxs-lookup"><span data-stu-id="82de7-155">However, you have the option to prevent the Store from using the logo images in your app's packages when displaying your listing to customers on Windows 10 (including Xbox), and instead have the Store use only images that you upload.</span></span> <span data-ttu-id="82de7-156">これにより、ストアのさまざまな画面でアプリがどのように表示されるかをさらに細かく制御できます。</span><span class="sxs-lookup"><span data-stu-id="82de7-156">This gives you more control over your app’s appearance in various displays throughout the Store.</span></span> <span data-ttu-id="82de7-157">(注ことのある製品は、以前の OS バージョンをサポートする場合顧客もについて、パッケージからのイメージ場合でも、このオプションを使用する)これを行う、**ロゴを格納**のセクション、**ストア一覧**送信処理の手順。</span><span class="sxs-lookup"><span data-stu-id="82de7-157">(Note that if your product supports earlier OS versions, those customers may still see images from your packages, even if you use this option.) You can do this in the **Store logos** section of the **Store listing** step of the submission process.</span></span>

![アプリの提出プロセス中にストア ロゴを指定します。](images/app-icons/storelogodisplay.png)

<span data-ttu-id="82de7-159">このボックスをオンにすると、新しいセクションと呼ばれる**ストア イメージを表示**が表示されます。</span><span class="sxs-lookup"><span data-stu-id="82de7-159">When you check this box, a new section called **Store display images** appears.</span></span> <span data-ttu-id="82de7-160">ここでは、アプリのパッケージからロゴのイメージの代わりに、ストアが使用する 3 つのイメージ サイズをアップロードできます。300 x 300、150 x 150、および 71 x 71 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="82de7-160">Here, you can upload 3 image sizes that the Store will use in place of logo images from your app’s packages: 300 x 300, 150 x 150, and 71 x 71 pixels.</span></span> <span data-ttu-id="82de7-161">すべての 3 つのサイズを提供することをお勧めします。 300 x 300 サイズのみが必要です。</span><span class="sxs-lookup"><span data-stu-id="82de7-161">Only the 300 x 300 size is required, although we recommend providing all 3 sizes.</span></span>

<span data-ttu-id="82de7-162">詳細については、[表示は、ストア ロゴのイメージのみアップロード](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="82de7-162">For more info, see [Display only uploaded logo images in the Store](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store).</span></span>

<!-- ### Fallback images for the Store

The simplest way to control the Store listing image is to specify it during the app submission process. If you don't provide these images during the app submission process, the Store will use a tile image:

1. Large tile
2. Medium tile

If these images aren't provided, the Store will search all matching images of the same image type with a square aspect ratio, preferable with a height greated than the scaled requested height (scaled height is the machine's resolution scale factor * display height). If none of the images meet this criteria, the Store will ignore the scale factor and select an image based on height.  -->

<!-- You can provide screenshots, logos, and other art assets (such as trailers and promotional images to include in your app's Microsoft Store listing. Some of these are required, and some are optional (although some of the optional images are important to include for the best Store display).

The Store may also use your app's tile and other images that you include in your app's package. 

For more information, see [App screenshots, images, and trailers in the Microsoft Store](/windows/uwp/publish/app-screenshots-and-images). -->


## <a name="managing-app-icons-with-the-visual-studio-manifest-designer"></a><span data-ttu-id="82de7-163">Visual Studio のマニフェスト デザイナーでのアプリ アイコンの管理</span><span class="sxs-lookup"><span data-stu-id="82de7-163">Managing app icons with the Visual Studio Manifest Designer</span></span>

<span data-ttu-id="82de7-164">Visual Studio と呼ばれる、アプリ アイコンの管理に非常に便利なツールを提供します、**マニフェスト デザイナー**します。</span><span class="sxs-lookup"><span data-stu-id="82de7-164">Visual Studio provides a very useful tool for managing your app icons called the **Manifest Designer**.</span></span> 

> <span data-ttu-id="82de7-165">まだ Visual Studio 2017 を持っていない場合、いくつかのバージョンがあるなどの無料バージョンである (Visual Studio 2017 Community Edition) と他のバージョンは、無料試用版を提供します。</span><span class="sxs-lookup"><span data-stu-id="82de7-165">If you don't already have Visual Studio 2017, there are several versions available, including a free version, (Visual Studio 2017 Community Edition), and the other versions offer free trials.</span></span> <span data-ttu-id="82de7-166">ここでダウンロードすることができます。 [https://developer.microsoft.com/windows/downloads](https://developer.microsoft.com/windows/downloads)</span><span class="sxs-lookup"><span data-stu-id="82de7-166">You can download them here: [https://developer.microsoft.com/windows/downloads](https://developer.microsoft.com/windows/downloads)</span></span>


<span data-ttu-id="82de7-167">マニフェスト デザイナーを起動するには。</span><span class="sxs-lookup"><span data-stu-id="82de7-167">To launch the Manifest Designer:</span></span>
<!-- 1. Use Visual Studio to open a UWP project.
2. In the **Solution Explorer**, double-click the package.appmanifest file. 

    ![The Visual Studio 2017 Solution Explorer](images/icons/vs-solution-explorer.png)

    Visual Studio displays the manifest designer.

    ![The Visual Studio 2017 manifest designer](images/icons/vs-manfiest-designer.png)
3. Click the **Visual Assets** tab.

    ![The Visual Assets tab](images/icons/vs-manfiest-designer-visual-assets.png) -->


:::row:::
    :::column:::
        1. <span data-ttu-id="82de7-168">Visual Studio を使用して、UWP プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="82de7-168">Use Visual Studio to open a UWP project.</span></span>
    :::column-end:::
    :::column:::
        
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        2. <span data-ttu-id="82de7-169">**ソリューション エクスプ ローラー**、Package.appmxanifest ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="82de7-169">In the **Solution Explorer**, double-click the Package.appmxanifest file.</span></span>
    :::column-end:::
    :::column:::
        ![The Visual Studio 2017 Manifest Designer](images/icons/vs-solution-explorer.png)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
            Visual Studio displays the Manifest Designer.
    :::column-end:::
    :::column:::
            ![The Visual Assets tab](images/icons/vs-manfiest-designer.png)
    :::column-end:::
:::row-end:::    
:::row:::
    :::column:::
        3. <span data-ttu-id="82de7-170">をクリックして、**のビジュアル アセット**タブ。</span><span class="sxs-lookup"><span data-stu-id="82de7-170">Click the **Visual Assets** tab.</span></span>
    :::column-end:::
    :::column:::
        ![The Visual Assets tab](images/icons/vs-manfiest-designer-visual-assets.png)
    :::column-end:::
:::row-end:::        

## <a name="generating-all-assets-at-once"></a><span data-ttu-id="82de7-171">すべての資産を一度に作成します。</span><span class="sxs-lookup"><span data-stu-id="82de7-171">Generating all assets at once</span></span>

<span data-ttu-id="82de7-172">内の最初のメニュー項目、**のビジュアル アセット** タブで、**すべてのビジュアル資産**は正確にその名前のとおり: ボタンを押すと、アプリが必要なすべてのビジュアル資産が生成されます。</span><span class="sxs-lookup"><span data-stu-id="82de7-172">The first menu item in the **Visual Assets** tab, **All Visual Assets**, does exactly what its name suggests: generates every visual asset your app needs with the press of a button.</span></span>

![Visual Studio ですべてのビジュアル資産を生成します。](images/app-icons/all-visual-assets.png)

<span data-ttu-id="82de7-174">1 つのイメージを指定が行う必要があるすべてと、Visual Studio は小さなタイル、中」のタイル、大、ワイド タイル、大規模なタイル、アプリ アイコン、スプラッシュ スクリーンを生成し、すべてのスケール ファクターのロゴの資産をパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="82de7-174">All you need to do is supply a single image, and Visual Studio will generate the small tile, medium tile, large tile, wide tile, large tile, app icon, splash screen, and package logo assets for every scale factor.</span></span>

<span data-ttu-id="82de7-175">すべての資産を一度に生成。</span><span class="sxs-lookup"><span data-stu-id="82de7-175">To generate all assets at once:</span></span>
1. <span data-ttu-id="82de7-176">をクリックして、 **.** 横に、**ソース**フィールドし、使用するイメージを選択します。</span><span class="sxs-lookup"><span data-stu-id="82de7-176">Click the **...** next to the **Source** field and select the image you want to use.</span></span> <span data-ttu-id="82de7-177">ビットマップ イメージを使用している場合は、シャープな結果を取得することが 400 ピクセルの 400 以上を確認します。</span><span class="sxs-lookup"><span data-stu-id="82de7-177">If you're using a bitmap image, make sure it's at least 400 by 400 pixels so that you get sharp results.</span></span> <span data-ttu-id="82de7-178">ベクター ベースのイメージが最適です。Visual Studio を使用して、AI (Adobe Illustrator) や PDF ファイルを使用できます。</span><span class="sxs-lookup"><span data-stu-id="82de7-178">Vector-based images work best; Visual Studio lets you use AI (Adobe Illustrator) and PDF files.</span></span> 
2. <span data-ttu-id="82de7-179">(省略可能)**表示設定**セクションで、これらのオプションを構成します。</span><span class="sxs-lookup"><span data-stu-id="82de7-179">(Optional.) In the **Display Settings** section, configure these options:</span></span>

    <span data-ttu-id="82de7-180">a. </span><span class="sxs-lookup"><span data-stu-id="82de7-180">a.</span></span>  <span data-ttu-id="82de7-181">**短い名前**:アプリの短い名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="82de7-181">**Short name**:  Specify a short name for your app.</span></span>

    <span data-ttu-id="82de7-182">b. </span><span class="sxs-lookup"><span data-stu-id="82de7-182">b.</span></span>  <span data-ttu-id="82de7-183">**名前を表示する**:短い名前を中、または大規模なタイルに表示するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="82de7-183">**Show name**: Indicate whether you want to display the short name on medium, wide, or large tiles.</span></span> 

    <span data-ttu-id="82de7-184">c.</span><span class="sxs-lookup"><span data-stu-id="82de7-184">c.</span></span> <span data-ttu-id="82de7-185">**タイルのバック グラウンド**:16 進数の値またはタイルの背景色を色の名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="82de7-185">**Tile background**: Specify the hex value or a color name for the tile background color.</span></span> <span data-ttu-id="82de7-186">たとえば、`#464646` と記述します。</span><span class="sxs-lookup"><span data-stu-id="82de7-186">For example, `#464646`.</span></span> <span data-ttu-id="82de7-187">既定値は、`transparent` です。</span><span class="sxs-lookup"><span data-stu-id="82de7-187">The default value is `transparent`.</span></span>

    <span data-ttu-id="82de7-188">d.</span><span class="sxs-lookup"><span data-stu-id="82de7-188">d.</span></span> <span data-ttu-id="82de7-189">**スプラッシュ画面の背景**:スプラッシュ画面の背景色の 16 進値または色の名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="82de7-189">**Spash screen background**: Specify the hex value or color name for the spash screen background.</span></span> 

3. <span data-ttu-id="82de7-190">クリックして**生成**します。</span><span class="sxs-lookup"><span data-stu-id="82de7-190">Click **Generate**.</span></span> 

<span data-ttu-id="82de7-191">Visual Studio は、イメージ ファイルを生成し、プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="82de7-191">Visual Studio generates your image files and adds them to project.</span></span> <span data-ttu-id="82de7-192">資産を変更する場合は、プロセスを繰り返します。</span><span class="sxs-lookup"><span data-stu-id="82de7-192">If you want to change your assets, simply repeat the process.</span></span> 

<span data-ttu-id="82de7-193">アイコンがスケーリングされた資産は、このファイルの名前付け規則に従います。</span><span class="sxs-lookup"><span data-stu-id="82de7-193">Scaled icon assets follow this file naming convention:</span></span>

<span data-ttu-id="82de7-194">*filename*-scale-*scale factor*.png</span><span class="sxs-lookup"><span data-stu-id="82de7-194">*filename*-scale-*scale factor*.png</span></span>

<span data-ttu-id="82de7-195">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="82de7-195">For example,</span></span>

<span data-ttu-id="82de7-196">Square150x150Logo-scale-100.png, Square150x150Logo-scale-200.png, Square150x150Logo-scale-400.png</span><span class="sxs-lookup"><span data-stu-id="82de7-196">Square150x150Logo-scale-100.png, Square150x150Logo-scale-200.png, Square150x150Logo-scale-400.png</span></span>

<span data-ttu-id="82de7-197">Visual Studio が既定でバッジ ロゴを生成しないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="82de7-197">Notice that Visual Studio doesn't generate a badge logo by default.</span></span> <span data-ttu-id="82de7-198">バッジ ロゴは一意であり、その他のアプリ アイコンが一致しないためにです。</span><span class="sxs-lookup"><span data-stu-id="82de7-198">That's because your badge logo is unique and probably shouldn't match your other app icons.</span></span> <span data-ttu-id="82de7-199">詳細については、、 [UWP アプリのアーティクルの通知のバッジ](/windows/uwp/design/shell/tiles-and-notifications/badges)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="82de7-199">For more info, see the  [Badge notifications for UWP apps article](/windows/uwp/design/shell/tiles-and-notifications/badges).</span></span> 


## <a name="more-about-app-icon-assets"></a><span data-ttu-id="82de7-200">アプリ アイコンの資産の詳細情報</span><span class="sxs-lookup"><span data-stu-id="82de7-200">More about app icon assets</span></span>
<span data-ttu-id="82de7-201">Visual Studio プロジェクトで必要なすべてのアプリ アイコンのアセットが生成されますが、その他のアプリの資産から相違を理解することによってそれらをカスタマイズしたい場合。</span><span class="sxs-lookup"><span data-stu-id="82de7-201">Visual Studio will generate all the app icon assets required by your project, but if you'd like to customize them, it helps to understand how they're different from other app assets.</span></span> 

<span data-ttu-id="82de7-202">アプリ アイコンの資産がさまざまな場所に表示されます。 Windows タスク バー、タスクの表示、ALT + TAB キー、およびスタート タイルの右上隅にあります。</span><span class="sxs-lookup"><span data-stu-id="82de7-202">The app icon asset appears in a lot of places: the Windows taskbar, the task view, ALT+TAB, and the lower-right corner of Start tiles.</span></span> <span data-ttu-id="82de7-203">いくつか追加のサイズとオプションがないその他の資産を plating がアプリ アイコンの資産は、非常に多くの場所に表示される、ため: 資産の「ターゲット サイズ」と「プレートなし」の資産。</span><span class="sxs-lookup"><span data-stu-id="82de7-203">Because the app icon asset appears in so many places, it has some additional sizing and plating options the other assets don't have: "target-size" assets and "unplated" assets.</span></span> 

### <a name="target-size-app-icon-assets"></a><span data-ttu-id="82de7-204">ターゲット サイズのアプリ アイコンの資産</span><span class="sxs-lookup"><span data-stu-id="82de7-204">Target-size app icon assets</span></span>
<span data-ttu-id="82de7-205">標準的なスケール要素サイズ ("Square44x44Logo.scale 400.png") だけでなくもをお勧め「ターゲット サイズ」の資産を作成します。</span><span class="sxs-lookup"><span data-stu-id="82de7-205">In addition to the standard scale factor sizes ("Square44x44Logo.scale-400.png"), we also recommend creating "target-size" assets.</span></span> <span data-ttu-id="82de7-206">400 などの特定のスケール ファクターではなく、16 ピクセルなどの特定のサイズを対象にできるので、これらの資産ターゲットのサイズを呼んでいます。</span><span class="sxs-lookup"><span data-stu-id="82de7-206">We call these assets target-size because they target specific sizes, such as 16 pixels, rather than specific scale factors, such as 400.</span></span> <span data-ttu-id="82de7-207">ターゲット サイズの資産は、スケーリングの頭打ちシステムを使用していないサーフェスのことです。</span><span class="sxs-lookup"><span data-stu-id="82de7-207">Target-size assets are for surfaces that don't use the scaling plateau system:</span></span>

* <span data-ttu-id="82de7-208">スタート画面のジャンプ リスト (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="82de7-208">Start jump list (desktop)</span></span>
* <span data-ttu-id="82de7-209">スタート画面のタイルの下隅 (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="82de7-209">Start lower corner of tile (desktop)</span></span>
* <span data-ttu-id="82de7-210">ショートカット (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="82de7-210">Shortcuts (desktop)</span></span>
* <span data-ttu-id="82de7-211">コントロール パネル (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="82de7-211">Control Panel (desktop)</span></span>

<span data-ttu-id="82de7-212">ターゲット サイズの資産の一覧を次に示します。</span><span class="sxs-lookup"><span data-stu-id="82de7-212">Here's the list of target-size assets:</span></span>


| <span data-ttu-id="82de7-213">アセットのサイズ</span><span class="sxs-lookup"><span data-stu-id="82de7-213">Asset size</span></span> | <span data-ttu-id="82de7-214">ファイル名の例</span><span class="sxs-lookup"><span data-stu-id="82de7-214">File name example</span></span>                  |
|------------|------------------------------------|
| <span data-ttu-id="82de7-215">16 x 16\*</span><span class="sxs-lookup"><span data-stu-id="82de7-215">16x16\*</span></span>    | <span data-ttu-id="82de7-216">Square44x44Logo.targetsize-16.png</span><span class="sxs-lookup"><span data-stu-id="82de7-216">Square44x44Logo.targetsize-16.png</span></span>  |
| <span data-ttu-id="82de7-217">24 x 24\*</span><span class="sxs-lookup"><span data-stu-id="82de7-217">24x24\*</span></span>    | <span data-ttu-id="82de7-218">Square44x44Logo.targetsize-24.png</span><span class="sxs-lookup"><span data-stu-id="82de7-218">Square44x44Logo.targetsize-24.png</span></span>  |
| <span data-ttu-id="82de7-219">32x32\*</span><span class="sxs-lookup"><span data-stu-id="82de7-219">32x32\*</span></span>    | <span data-ttu-id="82de7-220">Square44x44Logo.targetsize-32.png</span><span class="sxs-lookup"><span data-stu-id="82de7-220">Square44x44Logo.targetsize-32.png</span></span>  |
| <span data-ttu-id="82de7-221">48 x 48\*</span><span class="sxs-lookup"><span data-stu-id="82de7-221">48x48\*</span></span>    | <span data-ttu-id="82de7-222">Square44x44Logo.targetsize-48.png</span><span class="sxs-lookup"><span data-stu-id="82de7-222">Square44x44Logo.targetsize-48.png</span></span>  |
| <span data-ttu-id="82de7-223">256x256\*</span><span class="sxs-lookup"><span data-stu-id="82de7-223">256x256\*</span></span>  | <span data-ttu-id="82de7-224">Square44x44Logo.targetsize-256.png</span><span class="sxs-lookup"><span data-stu-id="82de7-224">Square44x44Logo.targetsize-256.png</span></span> |
| <span data-ttu-id="82de7-225">20 x 20</span><span class="sxs-lookup"><span data-stu-id="82de7-225">20x20</span></span>      | <span data-ttu-id="82de7-226">Square44x44Logo.targetsize-20.png</span><span class="sxs-lookup"><span data-stu-id="82de7-226">Square44x44Logo.targetsize-20.png</span></span>  |
| <span data-ttu-id="82de7-227">30 x 30</span><span class="sxs-lookup"><span data-stu-id="82de7-227">30x30</span></span>      | <span data-ttu-id="82de7-228">Square44x44Logo.targetsize-30.png</span><span class="sxs-lookup"><span data-stu-id="82de7-228">Square44x44Logo.targetsize-30.png</span></span>  |
| <span data-ttu-id="82de7-229">36 x 36</span><span class="sxs-lookup"><span data-stu-id="82de7-229">36x36</span></span>      | <span data-ttu-id="82de7-230">Square44x44Logo.targetsize-36.png</span><span class="sxs-lookup"><span data-stu-id="82de7-230">Square44x44Logo.targetsize-36.png</span></span>  |
| <span data-ttu-id="82de7-231">40 x 40</span><span class="sxs-lookup"><span data-stu-id="82de7-231">40x40</span></span>      | <span data-ttu-id="82de7-232">Square44x44Logo.targetsize-40.png</span><span class="sxs-lookup"><span data-stu-id="82de7-232">Square44x44Logo.targetsize-40.png</span></span>  |
| <span data-ttu-id="82de7-233">60 x 60</span><span class="sxs-lookup"><span data-stu-id="82de7-233">60x60</span></span>      | <span data-ttu-id="82de7-234">Square44x44Logo.targetsize-60.png</span><span class="sxs-lookup"><span data-stu-id="82de7-234">Square44x44Logo.targetsize-60.png</span></span>  |
| <span data-ttu-id="82de7-235">64 x 64</span><span class="sxs-lookup"><span data-stu-id="82de7-235">64x64</span></span>      | <span data-ttu-id="82de7-236">Square44x44Logo.targetsize-64.png</span><span class="sxs-lookup"><span data-stu-id="82de7-236">Square44x44Logo.targetsize-64.png</span></span>  |
| <span data-ttu-id="82de7-237">72 x 72</span><span class="sxs-lookup"><span data-stu-id="82de7-237">72x72</span></span>      | <span data-ttu-id="82de7-238">Square44x44Logo.targetsize-72.png</span><span class="sxs-lookup"><span data-stu-id="82de7-238">Square44x44Logo.targetsize-72.png</span></span>  |
| <span data-ttu-id="82de7-239">80 x 80</span><span class="sxs-lookup"><span data-stu-id="82de7-239">80x80</span></span>      | <span data-ttu-id="82de7-240">Square44x44Logo.targetsize-80.png</span><span class="sxs-lookup"><span data-stu-id="82de7-240">Square44x44Logo.targetsize-80.png</span></span>  |
| <span data-ttu-id="82de7-241">96 x 96</span><span class="sxs-lookup"><span data-stu-id="82de7-241">96x96</span></span>      | <span data-ttu-id="82de7-242">Square44x44Logo.targetsize-96.png</span><span class="sxs-lookup"><span data-stu-id="82de7-242">Square44x44Logo.targetsize-96.png</span></span>  |

<span data-ttu-id="82de7-243">\* 少なくとも、これらのサイズを提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="82de7-243">\* At a minimum, we recommend providing these sizes.</span></span> 

<span data-ttu-id="82de7-244">これらのアセットにパディングを追加する必要はありません。パディングは、必要に応じて Windows によって追加されます。</span><span class="sxs-lookup"><span data-stu-id="82de7-244">You don't have to add padding to these assets; Windows adds padding if needed.</span></span> <span data-ttu-id="82de7-245">これらのアセットは、16 ピクセルの最小面積を占めている必要があります。</span><span class="sxs-lookup"><span data-stu-id="82de7-245">These assets should account for a minimum footprint of 16 pixels.</span></span> 

<span data-ttu-id="82de7-246">Windows タスク バーのアイコンに表示される、このようなアセットの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="82de7-246">Here's an example of these assets as they appear in icons on the Windows taskbar:</span></span>

![Windows タスク バーのアセット](images/assetguidance21.png)

### <a name="unplated-assets"></a><span data-ttu-id="82de7-248">プレートなしの資産</span><span class="sxs-lookup"><span data-stu-id="82de7-248">Unplated assets</span></span>
<span data-ttu-id="82de7-249">既定では、Windows は、既定で色付き backplate 上にターゲット ベースの資産を使用します。</span><span class="sxs-lookup"><span data-stu-id="82de7-249">By default, Windows uses a target-based asset on top of a colored backplate by default.</span></span> <span data-ttu-id="82de7-250">する場合は、ターゲットのプレートなし資産を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="82de7-250">If you want, you can provide a target-based unplated asset.</span></span> <span data-ttu-id="82de7-251">資産が透明な背景に表示されます「プレートなし」を意味します。</span><span class="sxs-lookup"><span data-stu-id="82de7-251">"Unplated" means the asset will be displayed on a transparent background.</span></span> <span data-ttu-id="82de7-252">これらの資産は、さまざまな背景の色で表示されることに留意してください。</span><span class="sxs-lookup"><span data-stu-id="82de7-252">Keep in mind that these assets will appear over a variety of background colors.</span></span> 

![プレートなしのアセットとプレート付きのアセット](images/assetguidance22.png)

<span data-ttu-id="82de7-254">プレートなしのアプリ アイコンのアセットを使用する画面を次に示します。</span><span class="sxs-lookup"><span data-stu-id="82de7-254">Here are the surfaces that use unplated app icon assets:</span></span>
* <span data-ttu-id="82de7-255">タスク バーとタスク バー サムネイル (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="82de7-255">Taskbar and taskbar thumbnail (desktop)</span></span>
* <span data-ttu-id="82de7-256">タスク バーのジャンプ リスト</span><span class="sxs-lookup"><span data-stu-id="82de7-256">Taskbar jumplist</span></span>
* <span data-ttu-id="82de7-257">タスク ビュー</span><span class="sxs-lookup"><span data-stu-id="82de7-257">Task view</span></span>
* <span data-ttu-id="82de7-258">Alt + Tab キー</span><span class="sxs-lookup"><span data-stu-id="82de7-258">ALT+TAB</span></span>


### <a name="target-and-unplated-sizing"></a><span data-ttu-id="82de7-259">ターゲットおよびプレートなしのサイズ変更</span><span class="sxs-lookup"><span data-stu-id="82de7-259">Target and unplated sizing</span></span>

<span data-ttu-id="82de7-260">100% スケールで、ターゲット ベースの資産のサイズの推奨事項を次に示します。</span><span class="sxs-lookup"><span data-stu-id="82de7-260">Here are the size recommendations for target-based assets, at 100% scale:</span></span>

![100% の倍率でのターゲット ベースのアセットのサイズ調整](images/assetguidance23.png)


## <a name="more-about-splash-screen-assets"></a><span data-ttu-id="82de7-262">スプラッシュ画面の資産の詳細情報</span><span class="sxs-lookup"><span data-stu-id="82de7-262">More about splash screen assets</span></span>
<span data-ttu-id="82de7-263">スプラッシュ スクリーンの詳細については、、 [UWP スプラッシュ画面記事](/windows/uwp/launch-resume/splash-screens)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="82de7-263">For more info about splash screens, see the [UWP splash screens article](/windows/uwp/launch-resume/splash-screens).</span></span>

## <a name="more-about-badge-logo-assets"></a><span data-ttu-id="82de7-264">バッジ ロゴの資産の詳細情報</span><span class="sxs-lookup"><span data-stu-id="82de7-264">More about badge logo assets</span></span>

<span data-ttu-id="82de7-265">なぜバッジ ロゴが既定で生成されない理由がある必要があるすべての資産を生成する資産ジェネレーターを使用する場合: その他のアプリの資産から非常に異なる場合します。</span><span class="sxs-lookup"><span data-stu-id="82de7-265">When you use the asset generator to generate all the assets you need, there's a reason why it doesn't generate badge logos by default: they're very different from other app assets.</span></span> <span data-ttu-id="82de7-266">バッジ ロゴは、通知とアプリのタイルに表示される状態のイメージです。</span><span class="sxs-lookup"><span data-stu-id="82de7-266">The badge logo is a status image that appears in notifications and on the app's tiles.</span></span> 

<span data-ttu-id="82de7-267">詳細については、、 [UWP アプリのアーティクルの通知のバッジ](/windows/uwp/design/shell/tiles-and-notifications/badges)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="82de7-267">For more information, see the [Badge notifications for UWP apps article](/windows/uwp/design/shell/tiles-and-notifications/badges).</span></span>


## <a name="customizing-asset-padding"></a><span data-ttu-id="82de7-268">資産の余白をカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="82de7-268">Customizing asset padding</span></span>

<span data-ttu-id="82de7-269">既定では、Visual Studio 資産ジェネレーターには、どのようなイメージに推奨される埋め込みが適用されます。</span><span class="sxs-lookup"><span data-stu-id="82de7-269">By default, Visual Studio asset generator applies recommended padding to whatever image.</span></span> <span data-ttu-id="82de7-270">イメージの余白では、既にまたは、フルブリード イメージ タイルの末尾に拡張する場合場合、オフにできますこの機能をオフにして、**パディングをお勧めします。 適用**チェック ボックスをオンします。</span><span class="sxs-lookup"><span data-stu-id="82de7-270">If your images already contain padding or you want full bleed images that extend to the end of the tile, you can turn this feature off by unchecking the **Apply recommended padding** check box.</span></span> 

### <a name="tile-padding-recommendations"></a><span data-ttu-id="82de7-271">タイルの埋め込みに関する推奨事項</span><span class="sxs-lookup"><span data-stu-id="82de7-271">Tile padding recommendations</span></span>
<span data-ttu-id="82de7-272">独自の埋め込みを指定する場合は、タイルの推奨事項を示します。</span><span class="sxs-lookup"><span data-stu-id="82de7-272">If you want to provide your own padding, here are our recommendations for tiles.</span></span> 

<span data-ttu-id="82de7-273">4 つのタイル サイズがある: small (71 x 71)、medium (150 x 150)、ワイド (150 x 310)、大規模な (310 x 310)。</span><span class="sxs-lookup"><span data-stu-id="82de7-273">There are 4 tile sizes: small (71 x 71), medium (150 x 150), wide (310 x 150), and large (310 x 310).</span></span> 

<span data-ttu-id="82de7-274">各タイル アセットは、配置されるタイルと同じサイズです。</span><span class="sxs-lookup"><span data-stu-id="82de7-274">Each tile asset is the same size as the tile on which it is placed.</span></span>

![タイルが表示されたフルブリード](images/app-icons/tile-assets1.png)

<span data-ttu-id="82de7-276">タイルのエッジに拡張する、アイコンをしたくない場合は、パディングの作成に、資産の透明なピクセルを使用できます。</span><span class="sxs-lookup"><span data-stu-id="82de7-276">If you don't want your icon to extend to the edge of the tile, you can use transparent pixels in your asset to create padding.</span></span> 

![タイルとバック プレート](images/assetguidance05.png)

<span data-ttu-id="82de7-278">小さいタイルでは、アイコンの幅と高さをタイル サイズの 66% に制限します。</span><span class="sxs-lookup"><span data-stu-id="82de7-278">For small tiles, limit the icon width and height to 66% of the tile size:</span></span>

![小さいタイルのサイズの比率](images/assetguidance09.png)

<span data-ttu-id="82de7-280">普通サイズのタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="82de7-280">For medium tiles, limit the icon width to 66% and height to 50% of tile size.</span></span> <span data-ttu-id="82de7-281">これによって、ブランド バー内の要素と重ならないようにします。</span><span class="sxs-lookup"><span data-stu-id="82de7-281">This prevents overlapping of elements in the branding bar:</span></span>

![普通サイズのタイルのサイズの比率](images/assetguidance10.png)

<span data-ttu-id="82de7-283">ワイド タイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="82de7-283">For wide tiles, limit the icon width to 66% and height to 50% of tile size.</span></span> <span data-ttu-id="82de7-284">これによって、ブランド バー内の要素と重ならないようにします。</span><span class="sxs-lookup"><span data-stu-id="82de7-284">This prevents overlapping of elements in the branding bar:</span></span>

![ワイド タイルのサイズの比率](images/assetguidance11.png)

<span data-ttu-id="82de7-286">大きいタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="82de7-286">For large tiles, limit the icon width to 66% and height to 50% of tile size:</span></span>

![大きいタイルのサイズの比率](images/assetguidance12.png)

<span data-ttu-id="82de7-288">水平方向または垂直方向にデザインされたアイコンがある一方で、ターゲット サイズの正方形に収まらない、より複雑な形状のアイコンもあります。</span><span class="sxs-lookup"><span data-stu-id="82de7-288">Some icons are designed to be horizontally or vertically oriented, while others have more complex shapes that prevent them from fitting squarely within the target dimensions.</span></span> <span data-ttu-id="82de7-289">中央に配置されるアイコンの一方の辺に重みを付けることができます。</span><span class="sxs-lookup"><span data-stu-id="82de7-289">Icons that appear to be centered can be weighted to one side.</span></span> <span data-ttu-id="82de7-290">この場合、アイコンの視覚的な重みが正方形に収まるアイコンと同じであれば、アイコンの一部が推奨される面積の外側にはみ出していてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="82de7-290">In this case, parts of an icon may hang outside the recommended footprint, provided it occupies the same visual weight as a squarely fitted icon:</span></span>

![中央に配置された 3 つのアイコン](images/assetguidance13.png)

<span data-ttu-id="82de7-292">フルブリード アセットでは、要素が余白およびタイルの端の内側に接するように考慮します。</span><span class="sxs-lookup"><span data-stu-id="82de7-292">With full-bleed assets, take into account elements that interact within the margins and edges of the tiles.</span></span> <span data-ttu-id="82de7-293">タイルの高さまたは幅の 16% 以上の余白を維持します。</span><span class="sxs-lookup"><span data-stu-id="82de7-293">Maintain margins of at least 16% of the height or width of the tile.</span></span> <span data-ttu-id="82de7-294">この割合は、最小タイル サイズでの余白の幅の 2 倍を表しています。</span><span class="sxs-lookup"><span data-stu-id="82de7-294">This percentage represents double the width of the margins at the smallest tile sizes:</span></span>

![余白のあるフルブリード タイル](images/assetguidance14.png)

<span data-ttu-id="82de7-296">次の例では、余白が狭すぎます。</span><span class="sxs-lookup"><span data-stu-id="82de7-296">In this example, margins are too tight:</span></span>

![余白が小さすぎるフルブリード タイル](images/assetguidance15.png)









