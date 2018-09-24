---
author: mijacobs
Description: How to create app icons/logos that represent your app in the Start menu, app tiles, the taskbar, the Microsoft Store, and more.
title: アプリのアイコンとロゴ
template: detail.hbs
ms.author: mijacobs
ms.date: 04/17/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
design-contact: Judysa
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: e947b00c3a070a8d95a21e38c56bda07cd45d3c4
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4156351"
---
# <a name="app-icons-and-logos"></a><span data-ttu-id="ab6f1-103">アプリのアイコンとロゴ</span><span class="sxs-lookup"><span data-stu-id="ab6f1-103">App icons and logos</span></span> 

<span data-ttu-id="ab6f1-104">すべてのアプリが、それを表す、アイコン/ロゴと Windows シェルの複数の場所にそのアイコンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-104">Every app has an icon/logo that represents it, and that icon appears in multiple locations in the Windows shell:</span></span> 

:::row:::
    :::column:::
        <span data-ttu-id="ab6f1-105">\*、アプリ ウィンドウのタイトル バー \* [スタート] メニューで、アプリの一覧 \* タスク バーとタスク マネージャー \* アプリのタイル \* アプリのスプラッシュ画面 \* Microsoft ストア内</span><span class="sxs-lookup"><span data-stu-id="ab6f1-105">\* The title bar of your app window \* The app list in the start menu \* The taskbar and task manager \* Your app's tiles \* Your app's splash screen \* In the Microsoft Store</span></span> :::column-end:::
    :::column:::
        ![Windows 10 のスタート画面とタイル](images/assetguidance01.jpg)
    :::column-end:::
:::row-end:::

<span data-ttu-id="ab6f1-107">この記事では、アプリのアイコンの作成の基本を説明する必要がありますが、それらを管理し、それらを手動で管理する方法を Visual Studio を使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-107">This article covers the basics of creating app icons, how to use Visual Studio to manage them, and how manage them manually, should you need to.</span></span>
 
<span data-ttu-id="ab6f1-108">(この記事は、具体的にはアイコンをアプリ自体を表すアイコンの一般的なガイダンスについては、[アイコン](icons.md)に関する記事を参照してください。)</span><span class="sxs-lookup"><span data-stu-id="ab6f1-108">(This article is specifically for icons that represent the app itself; for general icon guidance, see the [Icons](icons.md) article.)</span></span>

## <a name="icon-types-locations-and-scale-factors"></a><span data-ttu-id="ab6f1-109">アイコンの種類、場所、およびスケール ファクター</span><span class="sxs-lookup"><span data-stu-id="ab6f1-109">Icon types, locations, and scale factors</span></span>

<span data-ttu-id="ab6f1-110">既定では、Visual Studio は、アセット サブディレクトリに、アイコン アセットを格納します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-110">By default, Visual Studio stores your icon assets in an assets subdirectory.</span></span> <span data-ttu-id="ab6f1-111">呼び出されたいるアイコン、表示される場所のさまざまな種類の一覧を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-111">Here's a list of the different types of icons, where they appear, and what they're called.</span></span> 

| <span data-ttu-id="ab6f1-112">アイコン名</span><span class="sxs-lookup"><span data-stu-id="ab6f1-112">Icon name</span></span> | <span data-ttu-id="ab6f1-113">表示されます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-113">Appears in</span></span> | <span data-ttu-id="ab6f1-114">アセット ファイル名</span><span class="sxs-lookup"><span data-stu-id="ab6f1-114">Asset file name</span></span> |
| ---      | ---        | --- |
| <span data-ttu-id="ab6f1-115">小さいタイル</span><span class="sxs-lookup"><span data-stu-id="ab6f1-115">Small tile</span></span> | <span data-ttu-id="ab6f1-116">スタート メニュー</span><span class="sxs-lookup"><span data-stu-id="ab6f1-116">Start menu</span></span> |  <span data-ttu-id="ab6f1-117">SmallTile.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-117">SmallTile.png</span></span>  |
| <span data-ttu-id="ab6f1-118">普通サイズのタイル</span><span class="sxs-lookup"><span data-stu-id="ab6f1-118">Medium tile</span></span> |<span data-ttu-id="ab6f1-119">スタート メニューで、Microsoft Store listing\ \*</span><span class="sxs-lookup"><span data-stu-id="ab6f1-119">Start menu,  Microsoft Store listing\*</span></span>  |  <span data-ttu-id="ab6f1-120">Square150x150Logo.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-120">Square150x150Logo.png</span></span> |
| <span data-ttu-id="ab6f1-121">ワイド タイル</span><span class="sxs-lookup"><span data-stu-id="ab6f1-121">Wide tile</span></span>  | <span data-ttu-id="ab6f1-122">スタート メニュー</span><span class="sxs-lookup"><span data-stu-id="ab6f1-122">Start menu</span></span>   | <span data-ttu-id="ab6f1-123">Wide310x150Logo.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-123">Wide310x150Logo.png</span></span> |
| <span data-ttu-id="ab6f1-124">大きいタイル</span><span class="sxs-lookup"><span data-stu-id="ab6f1-124">Large tile</span></span>   | <span data-ttu-id="ab6f1-125">スタート メニューで、Microsoft Store listing\ \*</span><span class="sxs-lookup"><span data-stu-id="ab6f1-125">Start menu,  Microsoft Store listing\*</span></span> |  <span data-ttu-id="ab6f1-126">LargeTile.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-126">LargeTile.png</span></span>  |
| <span data-ttu-id="ab6f1-127">アプリのアイコン</span><span class="sxs-lookup"><span data-stu-id="ab6f1-127">App icon</span></span> | <span data-ttu-id="ab6f1-128">[スタート] メニューのタスク バー、タスク マネージャーでアプリの一覧</span><span class="sxs-lookup"><span data-stu-id="ab6f1-128">App list in start menu, task bar, task manager</span></span> | <span data-ttu-id="ab6f1-129">Square44x44Logo.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-129">Square44x44Logo.png</span></span> |
| <span data-ttu-id="ab6f1-130">スプラッシュ画面</span><span class="sxs-lookup"><span data-stu-id="ab6f1-130">Splash screen</span></span> | <span data-ttu-id="ab6f1-131">アプリのスプラッシュ画面</span><span class="sxs-lookup"><span data-stu-id="ab6f1-131">The app's splash screen</span></span> | <span data-ttu-id="ab6f1-132">SplashScreen.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-132">SplashScreen.png</span></span>  |
| <span data-ttu-id="ab6f1-133">バッジ ロゴ</span><span class="sxs-lookup"><span data-stu-id="ab6f1-133">Badge logo</span></span> | <span data-ttu-id="ab6f1-134">アプリのタイル</span><span class="sxs-lookup"><span data-stu-id="ab6f1-134">Your app's tiles</span></span> | <span data-ttu-id="ab6f1-135">BadgeLogo.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-135">BadgeLogo.png</span></span>  |
| <span data-ttu-id="ab6f1-136">パッケージのロゴ/ストア ロゴ</span><span class="sxs-lookup"><span data-stu-id="ab6f1-136">Package logo/Store logo</span></span> | <span data-ttu-id="ab6f1-137">アプリ インストーラー, デベロッパー センターで、ストアでは、ストアで「レビューの書き込み」オプション「アプリを報告」オプション</span><span class="sxs-lookup"><span data-stu-id="ab6f1-137">App installer, Dev Center, the "Report an app" option in the Store, the "Write a review" option in the Store</span></span> | <span data-ttu-id="ab6f1-138">StoreLogo.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-138">StoreLogo.png</span></span>  |

<span data-ttu-id="ab6f1-139">\ \* しない場合[のみアップロードしたストア内の画像を表示](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store)するために使用します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-139">\* Used unless you choose to [display only uploaded images in the Store](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store).</span></span> 

<span data-ttu-id="ab6f1-140">これらのアイコンが鮮明にすべての画面で表示して、別のディスプレイのスケール ファクターの同じアイコンの複数のバージョンを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-140">To ensure these icons look sharp on every screen, you can create multiple versions of the same icon for different display scale factors.</span></span> 

<span data-ttu-id="ab6f1-141">スケール ファクターは、テキストなどの UI 要素のサイズを決定します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-141">The  scale factor determines the size of UI elements, such as text.</span></span> <span data-ttu-id="ab6f1-142">400% から 100% の要因の範囲が拡大縮小します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-142">Scale factors range from 100% to 400%.</span></span> <span data-ttu-id="ab6f1-143">値を大きくやすく高 DPI ディスプレイに表示するためより大きな UI 要素を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-143">Larger values create larger UI elements, making them easier to see on high-DPI displays.</span></span> 

:::row:::
    :::column:::
        <span data-ttu-id="ab6f1-144">Windows では、ディスプレイの DPI (ドット/インチ) と、デバイスの視聴距離に基づいて各ディスプレイの倍率が自動的に設定します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-144">Windows automatically sets the scale factor for each display based on its DPI (dots-per-inch) and the viewing distance of the device.</span></span> 

        (Users can override the default value by going to the **Settings &gt; Display &gt; Scale and layout** page.)
    :::column-end:::
    :::column:::
        ![](images/icons/display-settings-screen.png)
    :::column-end:::
:::row-end:::  


<span data-ttu-id="ab6f1-145">アプリ アイコン アセットはビットマップのビットマップが適切に拡大縮小されないため、お勧めしますバージョン各アイコン アセットの各スケール ファクター: 100%、125%、150%、200%、400% です。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-145">Because app icon assets are bitmaps and bitmaps don't scale well, we recommend providing a version each icon asset for each scale factor: 100%, 125%, 150%, 200%, and 400%.</span></span> <span data-ttu-id="ab6f1-146">多くのアイコンは正常です。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-146">That's a lot of icons!</span></span> <span data-ttu-id="ab6f1-147">な Visual Studio では、簡単に生成し、これらのアイコンを更新するツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-147">Fortunatly, Visual Studio provides a tool that makes it easy to generate and update these icons.</span></span> 

## <a name="microsoft-store-listing-image"></a><span data-ttu-id="ab6f1-148">Microsoft Store 登録情報の画像</span><span class="sxs-lookup"><span data-stu-id="ab6f1-148">Microsoft Store listing image</span></span>

<span data-ttu-id="ab6f1-149">「をどのように指定自分のアプリの登録情報の画像、Microsoft Store でか?」</span><span class="sxs-lookup"><span data-stu-id="ab6f1-149">"How do I specify images for my app's listing in the Microsoft Store?"</span></span>

<span data-ttu-id="ab6f1-150">既定では、パッケージの画像の一部で使います、ストア (その他の[申請プロセス中に提供するイメージ](https://docs.microsoft.com/en-us/windows/uwp/publish/app-screenshots-and-images)) と共にこのページの上部にある表で説明。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-150">By default, we use some of the images from your packages in the Store, as described in the table at the top of this page (along with other [images that you provide during the submission process](https://docs.microsoft.com/en-us/windows/uwp/publish/app-screenshots-and-images)).</span></span> <span data-ttu-id="ab6f1-151">ただし、Windows 10 (Xbox を含む) のユーザーに、登録情報を表示するときに、アプリのパッケージのロゴ画像を使用してから、ストアを防ぐため、代わりにアップロードした画像のみを使用してストア オプションがあります。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-151">However, you have the option to prevent the Store from using the logo images in your app's packages when displaying your listing to customers on Windows 10 (including Xbox), and instead have the Store use only images that you upload.</span></span> <span data-ttu-id="ab6f1-152">これにより、アプリの外観を詳しく制御では、ストアのさまざまな表示。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-152">This gives you more control over your app’s appearance in various displays throughout the Store.</span></span> <span data-ttu-id="ab6f1-153">(メモことのある製品は、以前の OS バージョンをサポートする場合それらのユーザーもについて、パッケージからの画像は、このオプションを使用する場合でも)申請プロセスの**Store 登録情報**のステップの**ストア ロゴ**のセクションで、これを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-153">(Note that if your product supports earlier OS versions, those customers may still see images from your packages, even if you use this option.) You can do this in the **Store logos** section of the **Store listing** step of the submission process.</span></span>

![アプリの申請プロセス中にストア ロゴを指定します。](images/app-icons/storelogodisplay.png)

<span data-ttu-id="ab6f1-155">このボックスをオンにする場合は、**ストアで表示する画像**と呼ばれる新しいセクションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-155">When you check this box, a new section called **Store display images** appears.</span></span> <span data-ttu-id="ab6f1-156">ここでは、アプリのパッケージからのロゴ画像の代わりに、ストアを使用する 3 つの画像サイズをアップロードできます: 300 x 300 ピクセル、150 x 150、71 x 71 ピクセル ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-156">Here, you can upload 3 image sizes that the Store will use in place of logo images from your app’s packages: 300 x 300, 150 x 150, and 71 x 71 pixels.</span></span> <span data-ttu-id="ab6f1-157">300 x 300 のサイズだけが必要な場合は、3 つすべてのサイズを提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-157">Only the 300 x 300 size is required, although we recommend providing all 3 sizes.</span></span>

<span data-ttu-id="ab6f1-158">詳しくは、[ディスプレイがストアでのロゴ画像をアップロードのみ](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-158">For more info, see [Display only uploaded logo images in the Store](/windows/uwp/publish/app-screenshots-and-images#display-only-uploaded-logo-images-in-the-store).</span></span>

<!-- ### Fallback images for the Store

The simplest way to control the Store listing image is to specify it during the app submission process. If you don't provide these images during the app submission process, the Store will use a tile image:

1. Large tile
2. Medium tile

If these images aren't provided, the Store will search all matching images of the same image type with a square aspect ratio, preferable with a height greated than the scaled requested height (scaled height is the machine's resolution scale factor * display height). If none of the images meet this criteria, the Store will ignore the scale factor and select an image based on height.  -->

<!-- You can provide screenshots, logos, and other art assets (such as trailers and promotional images to include in your app's Microsoft Store listing. Some of these are required, and some are optional (although some of the optional images are important to include for the best Store display).

The Store may also use your app's tile and other images that you include in your app's package. 

For more information, see [App screenshots, images, and trailers in the Microsoft Store](/windows/uwp/publish/app-screenshots-and-images). -->


## <a name="managing-app-icons-with-the-visual-studio-manifest-designer"></a><span data-ttu-id="ab6f1-159">Visual Studio マニフェスト デザイナーでのアプリ アイコンを管理します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-159">Managing app icons with the Visual Studio Manifest Designer</span></span>

<span data-ttu-id="ab6f1-160">Visual Studio では、**マニフェスト デザイナー**と呼ばれる、アプリのアイコンを管理するために非常に便利なツールを提供します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-160">Visual Studio provides a very useful tool for managing your app icons called the **Manifest Designer**.</span></span> 

> <span data-ttu-id="ab6f1-161">Visual Studio 2017 がまだしていない場合 (Visual Studio 2017 Community Edition)、無料のバージョンを含む、利用可能ないくつかのバージョンと、無料試用版を提供するその他のバージョン。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-161">If you don't already have Visual Studio 2017, there are several versions available, including a free version, (Visual Studio 2017 Community Edition), and the other versions offer free trials.</span></span> <span data-ttu-id="ab6f1-162">ここでダウンロードすることができます。[https://developer.microsoft.com/windows/downloads](https://developer.microsoft.com/windows/downloads)</span><span class="sxs-lookup"><span data-stu-id="ab6f1-162">You can download them here: [https://developer.microsoft.com/windows/downloads](https://developer.microsoft.com/windows/downloads)</span></span>


<span data-ttu-id="ab6f1-163">マニフェスト デザイナーを起動します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-163">To launch the Manifest Designer:</span></span>
<!-- 1. Use Visual Studio to open a UWP project.
2. In the **Solution Explorer**, double-click the package.appmanifest file. 

    ![The Visual Studio 2017 Solution Explorer](images/icons/vs-solution-explorer.png)

    Visual Studio displays the manifest designer.

    ![The Visual Studio 2017 manifest designer](images/icons/vs-manfiest-designer.png)
3. Click the **Visual Assets** tab.

    ![The Visual Assets tab](images/icons/vs-manfiest-designer-visual-assets.png) -->


:::row:::
    :::column:::
        <span data-ttu-id="ab6f1-164">1. Visual Studio を使用して UWP プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-164">1. Use Visual Studio to open a UWP project.</span></span>
    :::column-end:::
    :::column:::
        
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        <span data-ttu-id="ab6f1-165">2. [**ソリューション エクスプ ローラー**で、Package.appmxanifest ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-165">2. In the **Solution Explorer**, double-click the Package.appmxanifest file.</span></span>
    :::column-end:::
    :::column:::
        ![Visual Studio 2017 のマニフェスト デザイナー](images/icons/vs-solution-explorer.png)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
            <span data-ttu-id="ab6f1-167">Visual Studio では、マニフェスト デザイナーを表示します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-167">Visual Studio displays the Manifest Designer.</span></span>
    :::column-end:::
    :::column:::
            ![[ビジュアル資産] タブ](images/icons/vs-manfiest-designer.png)
    :::column-end:::
:::row-end:::    
:::row:::
    :::column:::
        <span data-ttu-id="ab6f1-169">3. [**ビジュアル資産**] タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-169">3. Click the **Visual Assets** tab.</span></span> :::column-end:::
    :::column:::
        ![[ビジュアル資産] タブ](images/icons/vs-manfiest-designer-visual-assets.png)
    :::column-end:::
:::row-end:::        

## <a name="generating-all-assets-at-once"></a><span data-ttu-id="ab6f1-171">一度にすべてのアセットの生成</span><span class="sxs-lookup"><span data-stu-id="ab6f1-171">Generating all assets at once</span></span>

<span data-ttu-id="ab6f1-172">**ビジュアル資産**] タブで、**すべてのビジュアル資産**の最初のメニュー項目はその名前が示す内容正確: ボタンを押すと、アプリが必要なすべてのビジュアル アセットを生成します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-172">The first menu item in the **Visual Assets** tab, **All Visual Assets**, does exactly what its name suggests: generates every visual asset your app needs with the press of a button.</span></span>

![Visaul Studio のすべてのビジュアル資産を生成します。](images/app-icons/all-visual-assets.png)

<span data-ttu-id="ab6f1-174">実行する必要があるすべてサプライ 1 つの画像は、Visaul Studio は小さいタイル、普通サイズのタイル、大きいタイル、ワイド タイル、大きいタイル、アプリのアイコン、スプラッシュ画面を生成してすべての倍率のアセットをロゴをパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-174">All you need to do is supply a single image, and Visaul Studio will generate the small tile, medium tile, large tile, wide tile, large tile, app icon, splash screen, and package logo assets for every scale factor.</span></span>

<span data-ttu-id="ab6f1-175">すべてのアセットを一度に生成するには。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-175">To generate all assets at once:</span></span>
1. <span data-ttu-id="ab6f1-176">**ソース**フィールドの横にある **...** ] をクリックし、使用するイメージを選択します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-176">Click the **...** next to the **Source** field and select the image you want to use.</span></span> <span data-ttu-id="ab6f1-177">ビットマップ画像を使用している場合は、鋭い結果を取得できるように、400 ピクセル以上 400 を確認します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-177">If you're using a bitmap image, make sure it's at least 400 by 400 pixels so that you get sharp results.</span></span> <span data-ttu-id="ab6f1-178">ベクター ベースのイメージが最適です。Visual Studio では、AI (Adobe Illustrator) と PDF ファイルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-178">Vector-based images work best; Visual Studio lets you use AI (Adobe Illustrator) and PDF files.</span></span> 
2. <span data-ttu-id="ab6f1-179">(省略可能)**ディスプレイの設定**] セクションでは、これらのオプションを構成します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-179">(Optional.) In the **Display Settings** section, configure these options:</span></span>

    <span data-ttu-id="ab6f1-180">a. </span><span class="sxs-lookup"><span data-stu-id="ab6f1-180">a.</span></span>  <span data-ttu-id="ab6f1-181">**短い名前**: アプリの短い名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-181">**Short name**:  Specify a short name for your app.</span></span>

    <span data-ttu-id="ab6f1-182">b. </span><span class="sxs-lookup"><span data-stu-id="ab6f1-182">b.</span></span>  <span data-ttu-id="ab6f1-183">**表示名**: 普通、ワイド、または大きいタイルの短い名前を表示するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-183">**Show name**: Indicate whether you want to display the short name on medium, wide, or large tiles.</span></span> 

    <span data-ttu-id="ab6f1-184">c.</span><span class="sxs-lookup"><span data-stu-id="ab6f1-184">c.</span></span> <span data-ttu-id="ab6f1-185">**バック グラウンドのタイル**: 16 進値またはタイルの背景色の色の名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-185">**Tile background**: Specify the hex value or a color name for the tile background color.</span></span> <span data-ttu-id="ab6f1-186">たとえば、`#464646` と記述します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-186">For example, `#464646`.</span></span> <span data-ttu-id="ab6f1-187">既定値は、`transparent` です。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-187">The default value is `transparent`.</span></span>

    <span data-ttu-id="ab6f1-188">d.</span><span class="sxs-lookup"><span data-stu-id="ab6f1-188">d.</span></span> <span data-ttu-id="ab6f1-189">**画面の背景を Spash**: spash 画面の背景の 16 進値または色の名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-189">**Spash screen background**: Specify the hex value or color name for the spash screen background.</span></span> 

3. <span data-ttu-id="ab6f1-190">[**生成**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-190">Click **Generate**.</span></span> 

<span data-ttu-id="ab6f1-191">Visual Studio は、イメージ ファイルを生成し、プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-191">Visual Studio generates your image files and adds them to project.</span></span> <span data-ttu-id="ab6f1-192">アセットを変更する場合は、単にプロセスを繰り返します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-192">If you want to change your assets, simply repeat the process.</span></span> 

<span data-ttu-id="ab6f1-193">拡大/縮小されたアイコン アセットは、このファイルの名前付け規則に従います。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-193">Scaled icon assets follow this file naming convention:</span></span>

<span data-ttu-id="ab6f1-194">*filename*規模の*拡大縮小率*.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-194">*filename*-scale-*scale factor*.png</span></span>

<span data-ttu-id="ab6f1-195">例:</span><span class="sxs-lookup"><span data-stu-id="ab6f1-195">For example,</span></span>

<span data-ttu-id="ab6f1-196">Square150x150Logo-スケール-100.png、Square150x150Logo-スケール-200.png、Square150x150Logo-スケール-400.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-196">Square150x150Logo-scale-100.png, Square150x150Logo-scale-200.png, Square150x150Logo-scale-400.png</span></span>

<span data-ttu-id="ab6f1-197">Visual Studio が既定ではバッジ ロゴを生成しないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-197">Notice that Visual Studio doesn't generate a badge logo by default.</span></span> <span data-ttu-id="ab6f1-198">バッジ ロゴは一意であり、その他のアプリ アイコンと一致しないようにおそらくためにです。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-198">That's because your badge logo is unique and probably shouldn't match your other app icons.</span></span> <span data-ttu-id="ab6f1-199">詳しくは、 [UWP アプリの資料のバッジ通知](/windows/uwp/design/shell/tiles-and-notifications/badges)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-199">For more info, see the  [Badge notifications for UWP apps article](/windows/uwp/design/shell/tiles-and-notifications/badges).</span></span> 


## <a name="more-about-app-icon-assets"></a><span data-ttu-id="ab6f1-200">アプリ アイコン アセットの詳細</span><span class="sxs-lookup"><span data-stu-id="ab6f1-200">More about app icon assets</span></span>
<span data-ttu-id="ab6f1-201">Visual Studio プロジェクトに必要なすべてのアプリ アイコン アセットが生成されますが、いるその他のアプリのアセットを異なる方法を理解する、それらをカスタマイズする場合は、できます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-201">Visual Studio will generate all the app icon assets required by your project, but if you'd like to customize them, it helps to understand how they're different from other app assets.</span></span> 

<span data-ttu-id="ab6f1-202">アプリ アイコン アセットは、多くの場所に表示されます。 Windows タスク バー、タスク ビュー、ALT + TAB およびスタート画面のタイルの右下隅します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-202">The app icon asset appears in a lot of places: the Windows taskbar, the task view, ALT+TAB, and the lower-right corner of Start tiles.</span></span> <span data-ttu-id="ab6f1-203">いくつか追加のサイズ変更とその他のアセットを持たないオプションを plating があるため、非常に多くの場所でアプリ アイコン アセットが表示されたら、:「ターゲット サイズ」アセットと「プレートなし」のアセットです。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-203">Because the app icon asset appears in so many places, it has some additional sizing and plating options the other assets don't have: "target-size" assets and "unplated" assets.</span></span> 

### <a name="target-size-app-icon-assets"></a><span data-ttu-id="ab6f1-204">ターゲット サイズのアプリ アイコン アセット</span><span class="sxs-lookup"><span data-stu-id="ab6f1-204">Target-size app icon assets</span></span>
<span data-ttu-id="ab6f1-205">だけでなく、標準的なスケール ファクター サイズ ("Square44x44Logo.scale 400.png") もお勧めします「ターゲット サイズ」アセットを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-205">In addition to the standard scale factor sizes ("Square44x44Logo.scale-400.png"), we also recommend creating "target-size" assets.</span></span> <span data-ttu-id="ab6f1-206">これらのアセットのターゲットのサイズと呼びます 400 などの特定のスケール ファクターではなく、16 ピクセルなどの特定のサイズをターゲットにするためです。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-206">We call these assets target-size because they target specific sizes, such as 16 pixels, rather than specific scale factors, such as 400.</span></span> <span data-ttu-id="ab6f1-207">ターゲット サイズのアセットは、スケール プラトー システムを使用していないサーフェスしています。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-207">Target-size assets are for surfaces that don't use the scaling plateau system:</span></span>

* <span data-ttu-id="ab6f1-208">スタート画面のジャンプ リスト (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="ab6f1-208">Start jump list (desktop)</span></span>
* <span data-ttu-id="ab6f1-209">スタート画面のタイルの下隅 (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="ab6f1-209">Start lower corner of tile (desktop)</span></span>
* <span data-ttu-id="ab6f1-210">ショートカット (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="ab6f1-210">Shortcuts (desktop)</span></span>
* <span data-ttu-id="ab6f1-211">コントロール パネル (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="ab6f1-211">Control Panel (desktop)</span></span>

<span data-ttu-id="ab6f1-212">ターゲット サイズのアセットの一覧を次に示します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-212">Here's the list of target-size assets:</span></span>


| <span data-ttu-id="ab6f1-213">アセットのサイズ</span><span class="sxs-lookup"><span data-stu-id="ab6f1-213">Asset size</span></span> | <span data-ttu-id="ab6f1-214">ファイル名の例</span><span class="sxs-lookup"><span data-stu-id="ab6f1-214">File name example</span></span>                  |
|------------|------------------------------------|
| <span data-ttu-id="ab6f1-215">16 x 16\*</span><span class="sxs-lookup"><span data-stu-id="ab6f1-215">16x16\*</span></span>    | <span data-ttu-id="ab6f1-216">Square44x44Logo.targetsize-16.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-216">Square44x44Logo.targetsize-16.png</span></span>  |
| <span data-ttu-id="ab6f1-217">24 x 24\*</span><span class="sxs-lookup"><span data-stu-id="ab6f1-217">24x24\*</span></span>    | <span data-ttu-id="ab6f1-218">Square44x44Logo.targetsize-24.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-218">Square44x44Logo.targetsize-24.png</span></span>  |
| <span data-ttu-id="ab6f1-219">32 x 32\*</span><span class="sxs-lookup"><span data-stu-id="ab6f1-219">32x32\*</span></span>    | <span data-ttu-id="ab6f1-220">Square44x44Logo.targetsize-32.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-220">Square44x44Logo.targetsize-32.png</span></span>  |
| <span data-ttu-id="ab6f1-221">48 x 48\*</span><span class="sxs-lookup"><span data-stu-id="ab6f1-221">48x48\*</span></span>    | <span data-ttu-id="ab6f1-222">Square44x44Logo.targetsize-48.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-222">Square44x44Logo.targetsize-48.png</span></span>  |
| <span data-ttu-id="ab6f1-223">256 x 256\*</span><span class="sxs-lookup"><span data-stu-id="ab6f1-223">256x256\*</span></span>  | <span data-ttu-id="ab6f1-224">Square44x44Logo.targetsize-256.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-224">Square44x44Logo.targetsize-256.png</span></span> |
| <span data-ttu-id="ab6f1-225">20 x 20</span><span class="sxs-lookup"><span data-stu-id="ab6f1-225">20x20</span></span>      | <span data-ttu-id="ab6f1-226">Square44x44Logo.targetsize-20.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-226">Square44x44Logo.targetsize-20.png</span></span>  |
| <span data-ttu-id="ab6f1-227">30 x 30</span><span class="sxs-lookup"><span data-stu-id="ab6f1-227">30x30</span></span>      | <span data-ttu-id="ab6f1-228">Square44x44Logo.targetsize-30.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-228">Square44x44Logo.targetsize-30.png</span></span>  |
| <span data-ttu-id="ab6f1-229">36 x 36</span><span class="sxs-lookup"><span data-stu-id="ab6f1-229">36x36</span></span>      | <span data-ttu-id="ab6f1-230">Square44x44Logo.targetsize-36.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-230">Square44x44Logo.targetsize-36.png</span></span>  |
| <span data-ttu-id="ab6f1-231">40 x 40</span><span class="sxs-lookup"><span data-stu-id="ab6f1-231">40x40</span></span>      | <span data-ttu-id="ab6f1-232">Square44x44Logo.targetsize-40.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-232">Square44x44Logo.targetsize-40.png</span></span>  |
| <span data-ttu-id="ab6f1-233">60 x 60</span><span class="sxs-lookup"><span data-stu-id="ab6f1-233">60x60</span></span>      | <span data-ttu-id="ab6f1-234">Square44x44Logo.targetsize-60.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-234">Square44x44Logo.targetsize-60.png</span></span>  |
| <span data-ttu-id="ab6f1-235">64 x 64</span><span class="sxs-lookup"><span data-stu-id="ab6f1-235">64x64</span></span>      | <span data-ttu-id="ab6f1-236">Square44x44Logo.targetsize-64.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-236">Square44x44Logo.targetsize-64.png</span></span>  |
| <span data-ttu-id="ab6f1-237">72 x 72</span><span class="sxs-lookup"><span data-stu-id="ab6f1-237">72x72</span></span>      | <span data-ttu-id="ab6f1-238">Square44x44Logo.targetsize-72.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-238">Square44x44Logo.targetsize-72.png</span></span>  |
| <span data-ttu-id="ab6f1-239">80 x 80</span><span class="sxs-lookup"><span data-stu-id="ab6f1-239">80x80</span></span>      | <span data-ttu-id="ab6f1-240">Square44x44Logo.targetsize-80.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-240">Square44x44Logo.targetsize-80.png</span></span>  |
| <span data-ttu-id="ab6f1-241">96 x 96</span><span class="sxs-lookup"><span data-stu-id="ab6f1-241">96x96</span></span>      | <span data-ttu-id="ab6f1-242">Square44x44Logo.targetsize-96.png</span><span class="sxs-lookup"><span data-stu-id="ab6f1-242">Square44x44Logo.targetsize-96.png</span></span>  |

<span data-ttu-id="ab6f1-243">\ \* 少なくとも、お勧めしますこれらのサイズを提供します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-243">\* At a minimum, we recommend providing these sizes.</span></span> 

<span data-ttu-id="ab6f1-244">これらのアセットにパディングを追加する必要はありません。パディングは、必要に応じて Windows によって追加されます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-244">You don't have to add padding to these assets; Windows adds padding if needed.</span></span> <span data-ttu-id="ab6f1-245">これらのアセットは、16 ピクセルの最小面積を占めている必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-245">These assets should account for a minimum footprint of 16 pixels.</span></span> 

<span data-ttu-id="ab6f1-246">Windows タスク バーのアイコンに表示される、このようなアセットの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-246">Here's an example of these assets as they appear in icons on the Windows taskbar:</span></span>

![Windows タスク バーのアセット](images/assetguidance21.png)

### <a name="unplated-assets"></a><span data-ttu-id="ab6f1-248">プレートなしのアセット</span><span class="sxs-lookup"><span data-stu-id="ab6f1-248">Unplated assets</span></span>
<span data-ttu-id="ab6f1-249">既定では、Windows は既定で色付きバック プレート上のターゲット ベースのアセットを使用します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-249">By default, Windows uses a target-based asset on top of a colored backplate by default.</span></span> <span data-ttu-id="ab6f1-250">する場合は、ターゲット ベースのプレートなしのアセットを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-250">If you want, you can provide a target-based unplated asset.</span></span> <span data-ttu-id="ab6f1-251">アセットは透明な背景に表示される「プレートなし」を意味します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-251">"Unplated" means the asset will be displayed on a transparent background.</span></span> <span data-ttu-id="ab6f1-252">これらのアセットは、さまざまな背景色で表示されることに留意してください。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-252">Keep in mind that these assets will appear over a variety of background colors.</span></span> 

![プレートなしのアセットとプレート付きのアセット](images/assetguidance22.png)

<span data-ttu-id="ab6f1-254">プレートなしのアプリ アイコン アセットを使用するサーフェスを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-254">Here are the surfaces that use unplated app icon assets:</span></span>
* <span data-ttu-id="ab6f1-255">タスク バーとタスク バー サムネイル (デスクトップ)</span><span class="sxs-lookup"><span data-stu-id="ab6f1-255">Taskbar and taskbar thumbnail (desktop)</span></span>
* <span data-ttu-id="ab6f1-256">タスク バーのジャンプ リスト</span><span class="sxs-lookup"><span data-stu-id="ab6f1-256">Taskbar jumplist</span></span>
* <span data-ttu-id="ab6f1-257">タスク ビュー</span><span class="sxs-lookup"><span data-stu-id="ab6f1-257">Task view</span></span>
* <span data-ttu-id="ab6f1-258">Alt + Tab キー</span><span class="sxs-lookup"><span data-stu-id="ab6f1-258">ALT+TAB</span></span>


### <a name="target-and-unplated-sizing"></a><span data-ttu-id="ab6f1-259">ターゲットとプレートなしのサイズ調整</span><span class="sxs-lookup"><span data-stu-id="ab6f1-259">Target and unplated sizing</span></span>

<span data-ttu-id="ab6f1-260">100% の倍率でのターゲット ベースのアセットのサイズの推奨事項を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-260">Here are the size recommendations for target-based assets, at 100% scale:</span></span>

![100% の倍率でのターゲット ベースのアセットのサイズ調整](images/assetguidance23.png)


## <a name="more-about-splash-screen-assets"></a><span data-ttu-id="ab6f1-262">スプラッシュ画面のアセットの詳細</span><span class="sxs-lookup"><span data-stu-id="ab6f1-262">More about splash screen assets</span></span>
<span data-ttu-id="ab6f1-263">スプラッシュ画面について詳しくは、 [UWP スプラッシュ画面の記事](/windows/uwp/launch-resume/splash-screens)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-263">For more info about splash screens, see the [UWP splash screens article](/windows/uwp/launch-resume/splash-screens).</span></span>

## <a name="more-about-badge-logo-assets"></a><span data-ttu-id="ab6f1-264">バッジ ロゴの資産の詳細</span><span class="sxs-lookup"><span data-stu-id="ab6f1-264">More about badge logo assets</span></span>

<span data-ttu-id="ab6f1-265">必要となるすべてのアセットを生成するアセット ジェネレーターを使用する場合は、既定ではバッジ ロゴを理由生成しない理由があります: している他のアプリのアセットとは大きく異なります。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-265">When you use the asset generator to generate all the assets you need, there's a reason why it doesn't generate badge logos by default: they're very different from other app assets.</span></span> <span data-ttu-id="ab6f1-266">バッジ ロゴは、通知であり、アプリのタイルに表示されるステータス イメージです。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-266">The badge logo is a status image that appears in notifications and on the app's tiles.</span></span> 

<span data-ttu-id="ab6f1-267">詳細については、 [UWP アプリの資料のバッジ通知](/windows/uwp/design/shell/tiles-and-notifications/badges)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-267">For more information, see the [Badge notifications for UWP apps article](/windows/uwp/design/shell/tiles-and-notifications/badges).</span></span>


## <a name="customizing-asset-padding"></a><span data-ttu-id="ab6f1-268">アセットのパディングをカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-268">Customizing asset padding</span></span>

<span data-ttu-id="ab6f1-269">既定では、Visual Studio アセット ジェネレーターには、何らかのイメージに推奨されるパディングが適用されます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-269">By default, Visual Studio asset generator applies recommended padding to whatever image.</span></span> <span data-ttu-id="ab6f1-270">場合は、イメージにパディングが既に含まれている、またはタイルの終わりに拡張フルブリード イメージ、**適用パディングを推奨**] チェック ボックスをオフにしてこの機能を無効にできます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-270">If your images already contain padding or you want full bleed images that extend to the end of the tile, you can turn this feature off by unchecking the **Apply recommended padding** check box.</span></span> 

### <a name="tile-padding-recommendations"></a><span data-ttu-id="ab6f1-271">タイルの余白の推奨事項</span><span class="sxs-lookup"><span data-stu-id="ab6f1-271">Tile padding recommendations</span></span>
<span data-ttu-id="ab6f1-272">独自のパディングを提供する場合は、タイルの推奨事項を示します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-272">If you want to provide your own padding, here are our recommendations for tiles.</span></span> 

<span data-ttu-id="ab6f1-273">ある 4 つのタイル サイズ: 小 (71 x 71)、medium (150 x 150)、全体 (150 x 310)、大規模な (310 x 310)。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-273">There are 4 tile sizes: small (71 x 71), medium (150 x 150), wide (310 x 150), and large (310 x 310).</span></span> 

<span data-ttu-id="ab6f1-274">各タイル アセットは、配置されるタイルと同じサイズです。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-274">Each tile asset is the same size as the tile on which it is placed.</span></span>

![タイル表示フルブリード](images/app-icons/tile-assets1.png)

<span data-ttu-id="ab6f1-276">アイコン タイルの端まで拡張しない場合は、パディングを作成する、アセットで透明のピクセルを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-276">If you don't want your icon to extend to the edge of the tile, you can use transparent pixels in your asset to create padding.</span></span> 

![タイルとバック プレート](images/assetguidance05.png)

<span data-ttu-id="ab6f1-278">小さいタイルでは、アイコンの幅と高さをタイル サイズの 66% に制限します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-278">For small tiles, limit the icon width and height to 66% of the tile size:</span></span>

![小さいタイルのサイズの比率](images/assetguidance09.png)

<span data-ttu-id="ab6f1-280">普通サイズのタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-280">For medium tiles, limit the icon width to 66% and height to 50% of tile size.</span></span> <span data-ttu-id="ab6f1-281">これによって、ブランド バー内の要素と重ならないようにします。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-281">This prevents overlapping of elements in the branding bar:</span></span>

![普通サイズのタイルのサイズの比率](images/assetguidance10.png)

<span data-ttu-id="ab6f1-283">ワイド タイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-283">For wide tiles, limit the icon width to 66% and height to 50% of tile size.</span></span> <span data-ttu-id="ab6f1-284">これによって、ブランド バー内の要素と重ならないようにします。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-284">This prevents overlapping of elements in the branding bar:</span></span>

![ワイド タイルのサイズの比率](images/assetguidance11.png)

<span data-ttu-id="ab6f1-286">大きいタイルでは、アイコンの幅をタイル サイズの 66% に、高さをタイル サイズの 50% に制限します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-286">For large tiles, limit the icon width to 66% and height to 50% of tile size:</span></span>

![大きいタイルのサイズの比率](images/assetguidance12.png)

<span data-ttu-id="ab6f1-288">水平方向または垂直方向にデザインされたアイコンがある一方で、ターゲット サイズの正方形に収まらない、より複雑な形状のアイコンもあります。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-288">Some icons are designed to be horizontally or vertically oriented, while others have more complex shapes that prevent them from fitting squarely within the target dimensions.</span></span> <span data-ttu-id="ab6f1-289">中央に配置されるアイコンの一方の辺に重みを付けることができます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-289">Icons that appear to be centered can be weighted to one side.</span></span> <span data-ttu-id="ab6f1-290">この場合、アイコンの視覚的な重みが正方形に収まるアイコンと同じであれば、アイコンの一部が推奨される面積の外側にはみ出していてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-290">In this case, parts of an icon may hang outside the recommended footprint, provided it occupies the same visual weight as a squarely fitted icon:</span></span>

![中央に配置された 3 つのアイコン](images/assetguidance13.png)

<span data-ttu-id="ab6f1-292">フルブリード アセットでは、要素が余白およびタイルの端の内側に接するように考慮します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-292">With full-bleed assets, take into account elements that interact within the margins and edges of the tiles.</span></span> <span data-ttu-id="ab6f1-293">タイルの高さまたは幅の 16% 以上の余白を維持します。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-293">Maintain margins of at least 16% of the height or width of the tile.</span></span> <span data-ttu-id="ab6f1-294">この割合は、最小タイル サイズでの余白の幅の 2 倍を表しています。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-294">This percentage represents double the width of the margins at the smallest tile sizes:</span></span>

![余白のあるフルブリード タイル](images/assetguidance14.png)

<span data-ttu-id="ab6f1-296">次の例では、余白が狭すぎます。</span><span class="sxs-lookup"><span data-stu-id="ab6f1-296">In this example, margins are too tight:</span></span>

![余白が小さすぎるフルブリード タイル](images/assetguidance15.png)









