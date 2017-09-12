---
author: jnHs
Description: "アプリのストア登録情報には、スクリーンショット、ロゴ、追加のアート資産 (トレーラーやプロモーション用の画像など) を選択して含めることができます。"
title: "アプリのスクリーンショット、画像、トレーラー"
ms.assetid: D216DD2B-F43D-4D26-82EE-0CD34DB929D8
ms.author: wdg-dev-content
ms.date: 08/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 7d5da868a93f958a9432e7f8360129a8be8ca486
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="app-screenshots-images-and-trailers"></a><span data-ttu-id="73555-104">アプリのスクリーンショット、画像、トレーラー</span><span class="sxs-lookup"><span data-stu-id="73555-104">App screenshots, images, and trailers</span></span>

<span data-ttu-id="73555-105">デザインが優れた画像は、ストアで潜在顧客にアプリをアピールする効果的な方法の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="73555-105">Well-designed images are one of the main ways for you to represent your app to potential customers in the Store.</span></span>

<span data-ttu-id="73555-106">アプリのストア登録情報には、[スクリーンショット](#screenshots)、[ロゴ](#store-logos)、追加のアート資産 ([トレーラー](#trailers)や[プロモーション用の画像](##additional-art-assets)など) を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="73555-106">You can provide [screenshots](#screenshots), [logos](#store-logos), and other art assets (such as [trailers](#trailers) and [promotional images](##additional-art-assets) to include in your app's Store listing.</span></span> <span data-ttu-id="73555-107">これらの中には必須の画像も、省略可能な画像もあります (ただし、省略可能な画像の中には、ストア登録情報をできるだけ魅力的なものにするため、含めた方がよい画像があります)。</span><span class="sxs-lookup"><span data-stu-id="73555-107">Some of these are required, and some are optional (although some of the optional images are important to include for the best Store display).</span></span> 

<span data-ttu-id="73555-108">[アプリの申請プロセス](app-submissions.md)では、[ストア登録情報](create-app-store-listings.md)を設定する手順でこのようなアート資産を指定します。</span><span class="sxs-lookup"><span data-stu-id="73555-108">During the [app submission process](app-submissions.md), you provide these art assets in the [Store listings](create-app-store-listings.md) step.</span></span> <span data-ttu-id="73555-109">ストアで使用される画像やその表示状態は、ユーザーのオペレーティング システムやその他の要因によって異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="73555-109">Note that the images which are used in the Store, and the way that they appear, may vary depending on the customer's operating system and other factors.</span></span>

<span data-ttu-id="73555-110">ストアでは、アプリのタイルと、アプリのパッケージに含まれている他の画像も使われる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="73555-110">The Store may also use your app's tile and other images that you include in your app's package.</span></span> <span data-ttu-id="73555-111">アプリを申請する前に、[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)を実行して、必須の画像が不足していないかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="73555-111">Run the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) to determine if you're missing any required images before you submit your app.</span></span> <span data-ttu-id="73555-112">これらの画像に関するガイダンスと推奨事項については、「[タイルとアイコン アセット](../controls-and-patterns/tiles-and-notifications-app-assets.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73555-112">For guidance and recommendations about these images, see [Tile and icon assets](../controls-and-patterns/tiles-and-notifications-app-assets.md).</span></span>

## <a name="screenshots"></a><span data-ttu-id="73555-113">スクリーンショット</span><span class="sxs-lookup"><span data-stu-id="73555-113">Screenshots</span></span>

<span data-ttu-id="73555-114">スクリーンショットは、アプリのストア登録情報でユーザーに表示されるアプリの画像です。</span><span class="sxs-lookup"><span data-stu-id="73555-114">Screenshots are images of your app that are displayed to your customers in your app's Store listing.</span></span>

<span data-ttu-id="73555-115">ユーザーが特定の種類のデバイスでアプリのストア登録情報を表示したときに適切なスクリーンショットが表示されるように、さまざまなデバイス ファミリ用のスクリーンショットを提供できます。</span><span class="sxs-lookup"><span data-stu-id="73555-115">You have the option to provide screenshots for different device families, so that the appropriate screenshots will appear when a customer views your app's Store listing on that type of device.</span></span> 

<span data-ttu-id="73555-116">(どのデバイス ファミリであっても) 申請時に必要なスクリーンショットは 1 つだけですが、デスクトップ用のスクリーンショットは最大 9 個、その他のデバイス ファミリ用のスクリーンショットは最大 8 個まで指定できます。</span><span class="sxs-lookup"><span data-stu-id="73555-116">Only one screenshot (for any device family) is required for your submission, though you can provide several; up to 9 desktop screenshots and up to 8 screenshots for the other device families.</span></span> <span data-ttu-id="73555-117">ユーザーが自分が使っている種類のデバイスでアプリがどのように表示されるかをイメージできるように、アプリがサポートするデバイス ファミリごとに少なくとも 4 つのスクリーンショットを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73555-117">We suggest providing at least four screenshots for each device family that your app supports so that people can see how the app will look on their device type.</span></span>

> [!NOTE]
> <span data-ttu-id="73555-118">Microsoft Visual Studio には、[スクリーンショットをキャプチャするツール](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator#BKMK_Capture_a_screenshot_of_your_app_for_submission_to_the_Microsoft_Store)が用意されています。</span><span class="sxs-lookup"><span data-stu-id="73555-118">Microsoft Visual Studio provides a [tool to help you capture screenshots](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator#BKMK_Capture_a_screenshot_of_your_app_for_submission_to_the_Microsoft_Store).</span></span>

<span data-ttu-id="73555-119">各スクリーンショットは .png ファイルでなければならず、横方向でも縦方向でもかまいません。ファイル サイズは 5 MB 以下にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-119">Each screenshot must be a .png file in either landscape or portrait orientation, and the file size can't be larger than 5 MB.</span></span>

<span data-ttu-id="73555-120">サイズの要件は、デバイス ファミリによって異なります。</span><span class="sxs-lookup"><span data-stu-id="73555-120">The size requirements vary depending on the device family:</span></span>
- <span data-ttu-id="73555-121">モバイル: 768 x 1280、720 x 1280、480 x 800 ピクセル</span><span class="sxs-lookup"><span data-stu-id="73555-121">Mobile: either 768 x 1280, 720 x 1280, or 480 x 800 pixels</span></span>
- <span data-ttu-id="73555-122">デスクトップ: 1366 x 768 ピクセル以上</span><span class="sxs-lookup"><span data-stu-id="73555-122">Desktop: 1366 x 768 pixels or larger</span></span>
- <span data-ttu-id="73555-123">ホログラフィック: 1268 x 720 ピクセル以上</span><span class="sxs-lookup"><span data-stu-id="73555-123">Holographic: 1268 x 720 pixels or larger</span></span>
- <span data-ttu-id="73555-124">Xbox: 3480 x 2160 ピクセル以下</span><span class="sxs-lookup"><span data-stu-id="73555-124">Xbox: 3480 x 2160 pixels or smaller</span></span>

<span data-ttu-id="73555-125">最適な表示のために、スクリーンショットの作成時には次のガイドラインに留意してください。</span><span class="sxs-lookup"><span data-stu-id="73555-125">For the best display, keep the following guidelines in mind when creating your screenshots:</span></span>
- <span data-ttu-id="73555-126">重要なビジュアルとテキストは画像の上部 3/4 に収めてください。</span><span class="sxs-lookup"><span data-stu-id="73555-126">Keep critical visuals and text in the top 3/4 of the image.</span></span> <span data-ttu-id="73555-127">下部 1/4 にはテキスト オーバーレイが表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="73555-127">Text overlays may appear on the bottom 1/4.</span></span> 
- <span data-ttu-id="73555-128">スクリーンショットにはロゴ、アイコン、マーケティング メッセージを追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="73555-128">Don’t add additional logos, icons, or marketing messages to your screenshots.</span></span>
- <span data-ttu-id="73555-129">過度に明るい色や暗い色、またはコントラストの高い縞模様は使わないでください。テキスト オーバーレイの読みやすさが損なわれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="73555-129">Don’t use extremely light or dark colors or highly-contrasting stripes that may interfere with readability of text overlays.</span></span>

<span data-ttu-id="73555-130">各スクリーンショットを説明する短いキャプションを 200 文字以内で指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="73555-130">You can also provide a short caption that describes each screenshot in 200 characters or less.</span></span>

> [!TIP]
> <span data-ttu-id="73555-131">スクリーンショットは、指定した順番に登録情報に表示されます。</span><span class="sxs-lookup"><span data-stu-id="73555-131">Screenshots are displayed in your listing in order.</span></span> <span data-ttu-id="73555-132">スクリーンショットをアップロードした後で、ドラッグ アンド ドロップで並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="73555-132">After you upload your screenshots, you can drag and drop them to reorder them.</span></span> 

<span data-ttu-id="73555-133">ストア登録情報を[複数の言語](supported-languages.md)で用意する場合は、言語ごとに **[ストア登録情報]** ページがあります。</span><span class="sxs-lookup"><span data-stu-id="73555-133">Note that if you create Store listings for [multiple languages](supported-languages.md), you'll have a **Store listing** page for each one.</span></span> <span data-ttu-id="73555-134">画像は言語ごとに個別にアップロードし (同じ画像を使う場合でも)、使用するキャプションも言語ごとに指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-134">You'll need to upload images for each language separately (even if you are using the same images), and provide captions to use for each language.</span></span>


## <a name="store-logos"></a><span data-ttu-id="73555-135">ストア ロゴ</span><span class="sxs-lookup"><span data-stu-id="73555-135">Store logos</span></span>

<span data-ttu-id="73555-136">ストア ロゴは、ストアの表示をさらにカスタマイズするためにアップロードできるオプションの画像です。</span><span class="sxs-lookup"><span data-stu-id="73555-136">Store logos are optional images that you can upload for a more customized display in the Store.</span></span> <span data-ttu-id="73555-137">アプリがサポートするすべての デバイスと OS バージョンで、できるだけ魅力的なストア登録情報を演出できるように、これらの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73555-137">We recommend that you provide these images for the best Store listing display on all of the devices and OS versions that your app supports.</span></span>

<span data-ttu-id="73555-138">これらの画像は .png ファイル形式とし、次のガイドラインに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-138">You can provide these images as .png files, which should follow the guidelines below:</span></span>

- <span data-ttu-id="73555-139">**9:16 (720 x 1080 または 1440 x 2160 ピクセル)**: Windows 10 ユーザーと Xbox デバイス向けのストア登録情報のメイン画像として使われます。この画像があると、登録情報の見ばえがよくなります。</span><span class="sxs-lookup"><span data-stu-id="73555-139">**9:16 (720 x 1080 or 1440 x 2160 pixels)**: This is used as the main image on Store listings for customers on Windows 10 and Xbox devices, so we strongly recommend providing this image; your listing may not look good without it.</span></span> <span data-ttu-id="73555-140">この画像にはアプリ名を含める必要があり、画像内のテキストは、読みやすさに関するアクセシビリティ要件 (4.5:1 のコントラスト比) を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-140">The image should include your app’s name, and any text on the image should meet accessible readability requirements (4.51 contrast ratio).</span></span>  
- <span data-ttu-id="73555-141">**1:1 (1080 x 1080 または 2160 x 2160 ピクセル)**: この画像はいくつかのレイアウトで表示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="73555-141">**1:1 (1080 x 1080 or 2160 x 2160 pixels)**: This image may appear in some layouts.</span></span> <span data-ttu-id="73555-142">この画像を提供する場合は、アプリ名を必ず含めてください。</span><span class="sxs-lookup"><span data-stu-id="73555-142">If you provide it, be sure to include your app’s name.</span></span>
- <span data-ttu-id="73555-143">**1:1 (300 x 300 ピクセル)**: この画像は**アプリのタイル アイコン**とも呼ばれ、Windows Phone 8.1 以前のユーザーにアプリのストア登録情報を表示するときに使われます。</span><span class="sxs-lookup"><span data-stu-id="73555-143">**1:1 (300 x 300 pixels)**: This image, sometimes referred to as the **App tile icon**, is used when displaying your app's Store listing to customers on Windows Phone 8.1 and earlier.</span></span> <span data-ttu-id="73555-144">この画像が提供されない場合、Windows Phone 8.1 以前のユーザーがアプリの登録情報ページを表示すると、空白のアイコンが表示されます </span><span class="sxs-lookup"><span data-stu-id="73555-144">If you don't provide this image, customers on Windows Phone 8.1 or earlier will see a blank icon with your app's listing.</span></span> <span data-ttu-id="73555-145">(アプリに Windows Phone 8.1 以前をターゲットとするパッケージしかない場合、これは Windows 10 のユーザーにも適用されます)。申請に UWP パッケージ*しか*含まれない場合は、この画像を提供する必要はありません </span><span class="sxs-lookup"><span data-stu-id="73555-145">(This also applies to customers on Windows 10, if your app only has packages targeting Windows Phone 8.1 or earlier.) If your submission *only* includes UWP packages, you don’t need to provide this image.</span></span> <span data-ttu-id="73555-146">(申請に Windows Phone 8.x パッケージと UWP パッケージの両方が含まれている場合、この画像を提供すると、Windows 10 の一部のストア レイアウトで使われることがあります。</span><span class="sxs-lookup"><span data-stu-id="73555-146">(Note that if your submission includes both Windows Phone 8.x packages and UWP packages, and you provide this image, it may be used on Windows 10 in certain Store layouts.</span></span> <span data-ttu-id="73555-147">これを避けるには、Windows Phone OS のバージョン用に[プラットフォーム固有の登録情報](create-platform-specific-store-listings.md)を作成し、その登録情報にのみアプリのタイル アイコンを含めるようにします)。</span><span class="sxs-lookup"><span data-stu-id="73555-147">To prevent this, you can create a [platform-specific listing](create-platform-specific-store-listings.md) for the Windows Phone OS versions, and only include the app tile icon there.)</span></span>

<span data-ttu-id="73555-148">また、Windows 10 ユーザーにストア登録情報が表示されるときに、アプリのパッケージのロゴ画像ではなく、アップロードした画像のみが使用されるようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="73555-148">You also have the option to prevent the Store from using logo images in your app's packages when displaying your listing to customers on Windows 10, and instead have the Store use only images that you upload.</span></span> <span data-ttu-id="73555-149">これにより、Windows 10 については、ストアのさまざまな画面でのアプリの魅せ方をさらに細かく制御できます。</span><span class="sxs-lookup"><span data-stu-id="73555-149">This gives you more control over your app’s appearance in various displays throughout the Store on Windows 10.</span></span>

<span data-ttu-id="73555-150">Windows 10 のストアではアップロードした画像のみを使用するには、**[Windows 10 のユーザーに対しては、パッケージの画像ではなく、アップロードしたロゴ画像を表示します]** というチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="73555-150">To use only uploaded images for display in the Store on Windows 10, check the box that says **For Windows 10 customers, display uploaded logo images instead of the images from my packages**.</span></span>

<span data-ttu-id="73555-151">このチェック ボックスをオンにすると、**[Uploaded Store logos] (アップロードされたストア ロゴ)** という新しいセクションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="73555-151">When you check this box, a new section called **Uploaded Store logos** appears.</span></span> <span data-ttu-id="73555-152">ここで 3 つの画像をアップロードできます。これには 300 x 300 の "アプリ タイル アイコン" サイズも含まれます (このチェック ボックスをオンにすると、画像を指定するフィールドがこのセクションに移動します)。</span><span class="sxs-lookup"><span data-stu-id="73555-152">Here, you can upload 3 images, including the 300 x 300 “app tile icon” size (if you check the box, the field to provide that image will move into this section).</span></span> <span data-ttu-id="73555-153">このオプションを使う場合は、300 x 300 ピクセル、150 x 150 ピクセル、71 x 71 ピクセルの 3 つの画像をすべて指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73555-153">We recommend providing all three image sizes if you use this option: 300 x 300, 150 x 150, and 71 x 71 pixels.</span></span> <span data-ttu-id="73555-154">ただし、必須のサイズは 300 x 300 だけです。</span><span class="sxs-lookup"><span data-stu-id="73555-154">However, only the 300 x 300 size is required.</span></span>


## <a name="additional-art-assets"></a><span data-ttu-id="73555-155">追加のアート資産</span><span class="sxs-lookup"><span data-stu-id="73555-155">Additional art assets</span></span>

<span data-ttu-id="73555-156">このセクションでは、ストアで製品をより効果的に表示するために役立つアートワークを指定できます。アートワークには、プロモーション用の画像、Xbox 画像、オプションのプロモーション用の画像、トレーラーがあります。</span><span class="sxs-lookup"><span data-stu-id="73555-156">This section lets you provide artwork to help display your product more effectively in the Store: promotional images, Xbox images, optional promotional images, and trailers.</span></span> <span data-ttu-id="73555-157">より魅力的なストア登録情報を制作するため、これらの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73555-157">We recommend providing these images to create a more inviting Store listing.</span></span> <span data-ttu-id="73555-158">**16:9 "ヒーロー" (1920 x 1080 または 3840 x 2160 ピクセル)** は、ストア登録情報に[ビデオ トレーラー](#trailers) を含める場合は特に推奨されます。これを含めないと、トレーラーは登録情報の最上部に表示されません。</span><span class="sxs-lookup"><span data-stu-id="73555-158">The **16:9 "hero" (1920 x 1080 or 3840 x 2160 pixels)** is especially recommended if you plan to include [video trailers](#trailers) in your Store listing; if you don't include it, your trailers won't appear at the top of your listing.</span></span>

<span data-ttu-id="73555-159">これらの画像を追加するには、**[追加のアート資産]** セクションで **[詳細の表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="73555-159">To add these images, select **Show details** in the **Additional art assets** section.</span></span>


## <a name="promotional-images"></a><span data-ttu-id="73555-160">プロモーション用の画像</span><span class="sxs-lookup"><span data-stu-id="73555-160">Promotional images</span></span>

<span data-ttu-id="73555-161">このセクションの画像はアプリの登録情報の見ばえをよくし、Microsoft がアプリをおすすめのアプリとしてプロモーションに起用させていただくかどうかを検討する参考にもなります。</span><span class="sxs-lookup"><span data-stu-id="73555-161">The images in this section can help your app listing look better, and also allow us to consider your app for featured promotional opportunities.</span></span> <span data-ttu-id="73555-162">これらの画像を提供したとしても、アプリが必ずプロモーションに起用されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="73555-162">Note that providing these images doesn't guarantee that your app will be featured.</span></span> <span data-ttu-id="73555-163">詳しくは、「[アプリの販売促進を容易にする方法](make-your-app-easier-to-promote.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73555-163">See [Making your app easy to promote](make-your-app-easier-to-promote.md) for more information.</span></span>

<span data-ttu-id="73555-164">プロモーション用のアートワークをデザインするときに念頭に置く必要のあるヒントを次に示します。</span><span class="sxs-lookup"><span data-stu-id="73555-164">Here are some tips to keep in mind when designing your promotional artwork:</span></span>

- <span data-ttu-id="73555-165">画像は .png 形式にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-165">Images must be in .png format.</span></span>
- <span data-ttu-id="73555-166">アプリに関連があり、アプリの認識と差別化を促す動的な画像を選びます。</span><span class="sxs-lookup"><span data-stu-id="73555-166">Select dynamic images that relate to the app and drive recognition and differentiation.</span></span> <span data-ttu-id="73555-167">ありきたりの写真や一般的な視覚効果は使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="73555-167">Avoid stock photography or generic visuals.</span></span>
- <span data-ttu-id="73555-168">テキスト (ブランドを除く) を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="73555-168">Don't include text (aside from your branding).</span></span>
- <span data-ttu-id="73555-169">画像内の空白領域を最小限に抑えます。</span><span class="sxs-lookup"><span data-stu-id="73555-169">Minimize empty space in the image.</span></span>
- <span data-ttu-id="73555-170">アプリの UI の表示やデバイスに固有の画像の使用は避けます。</span><span class="sxs-lookup"><span data-stu-id="73555-170">Avoid showing your app's UI, and do not use any device-specific imagery.</span></span>
- <span data-ttu-id="73555-171">政治的および国家的なテーマ、旗、または宗教的なシンボルを避けます。</span><span class="sxs-lookup"><span data-stu-id="73555-171">Avoid political and national themes, flags, or religious symbols.</span></span>
- <span data-ttu-id="73555-172">無神経なジェスチャ、ヌード、ギャンブル、通貨、麻薬、タバコ、またはアルコールの画像を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="73555-172">Don't include images of insensitive gestures, nudity, gambling, currency, drugs, tobacco, or alcohol.</span></span>
- <span data-ttu-id="73555-173">閲覧者に向けた武器や過剰な暴力や流血の画像を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="73555-173">Don't use weapons pointing at the viewer or excessive violence and gore.</span></span>

<span data-ttu-id="73555-174">**16:9 の "ヒーロー" 画像 (1920 x 1080 または 3840 x 2160 ピクセル)** は、あらゆる種類の Windows 10 デバイス向けのストアで、さまざまなプロモーション用のレイアウトに使われます。</span><span class="sxs-lookup"><span data-stu-id="73555-174">The **16:9 "hero" (1920 x 1080 or 3840 x 2160 pixels)** is used in various layouts in the Store on all Windows 10 device types.</span></span> <span data-ttu-id="73555-175">アプリがターゲットとしている OS バージョンやデバイスの種類が何であっても、この画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73555-175">We recommend providing this image, regardless of which OS versions or device types your app targets.</span></span> <span data-ttu-id="73555-176">この画像は、登録情報に[ビデオ トレーラー](#trailers)が含まれる場合、適切に表示するためには*必須*です。</span><span class="sxs-lookup"><span data-stu-id="73555-176">This image is *required* for proper display if your listing includes [video trailers](#trailers).</span></span> <span data-ttu-id="73555-177">この画像は、Windows 10 Version 1607 以降のユーザーに対しては、ストア登録情報の最上部のメイン画像として使われます (またはトレーラーの再生後に表示されます)。</span><span class="sxs-lookup"><span data-stu-id="73555-177">For customers on Windows 10, version 1607 or later, it is used as the main image on the top of your Store listing (or appears after any trailers finish playing).</span></span> 

<span data-ttu-id="73555-178">**2:1 (2400 x 1200)** の画像サイズは、アプリが Holographic デバイス ファミリをサポートする場合にのみ、使われます。</span><span class="sxs-lookup"><span data-stu-id="73555-178">The **2:1 (2400 x 1200)** image size is only used if your app supports the Holographic device family.</span></span>

<span data-ttu-id="73555-179">画像をデザインするときは、一部のレイアウトで下部の 3 分の 1 にグラデーションが適用されることに留意してください。これは、画像に重ねてマーケティング用のテキストを読みやすく表示できるようにするためです。</span><span class="sxs-lookup"><span data-stu-id="73555-179">When designing your image, keep in mind that in some layouts, we'll apply a gradient over the bottom third so that we can legibly display marketing text over the image.</span></span> <span data-ttu-id="73555-180">このため、下部の 3 分の 1 には、テキストや主要な視覚要素を配置しないでください。</span><span class="sxs-lookup"><span data-stu-id="73555-180">Because of this, make sure you avoid placing text and key visual elements in the bottom third.</span></span> <span data-ttu-id="73555-181">さらに、画像はトリミングされる可能性があるため、アプリのブランドや最も重要な詳細は中央に配置してください。</span><span class="sxs-lookup"><span data-stu-id="73555-181">Additionally, we may crop your image, so place your app's branding and the most important details in the center.</span></span>  

<!-- update? ![guidelines for spotlight image](images/spotlight1.jpg) 
![well-designed spotlight image](images/spotlight2.jpg)

The image below shows the key proportions to keep in mind. The "safe zone" in the center will be prominent even if we crop the image. The "dynamic text area" is where text and a gradient may appear.  -->

## <a name="xbox-images"></a><span data-ttu-id="73555-182">Xbox 画像</span><span class="sxs-lookup"><span data-stu-id="73555-182">Xbox images</span></span>

<span data-ttu-id="73555-183">これらの画像は、アプリを Xbox に公開する場合に、適切な表示のために推奨されます。</span><span class="sxs-lookup"><span data-stu-id="73555-183">These images are recommended for proper display if you publish your app to Xbox.</span></span> 

<span data-ttu-id="73555-184">アップロードできるサイズには次の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="73555-184">There are 3 different sizes that you can upload:</span></span>
- <span data-ttu-id="73555-185">**ブランド付きのキー アート、584 x 800 ピクセル**: Xbox.com ストアで使われます。</span><span class="sxs-lookup"><span data-stu-id="73555-185">**Branded key art, 584 x 800 pixels**: Used in the Xbox.com Store.</span></span> <span data-ttu-id="73555-186">製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-186">Must include the product’s title.</span></span> 
- <span data-ttu-id="73555-187">**タイトル付きのヒーロー、1920 x 1080 ピクセル**: 製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-187">**Titled hero, 1920 x 1080 pixels**: Must include the product’s title.</span></span>
- <span data-ttu-id="73555-188">**おすすめのプロモーション、1080 x 1080 ピクセル**: Xbox ストアで使われます。</span><span class="sxs-lookup"><span data-stu-id="73555-188">**Featured promo, 1080 x 1080 pixels**: Used in the Xbox Store.</span></span> <span data-ttu-id="73555-189">製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-189">Must include the product’s title.</span></span>

> [!NOTE]
> <span data-ttu-id="73555-190">Xbox でできるだけ魅力的な表示にするには、[ストア ロゴ](#store-logos)のセクションで **9:16 (720 x 1080 または 1440 x 2160 ピクセル)** の画像も提供してください。</span><span class="sxs-lookup"><span data-stu-id="73555-190">For the best display on Xbox, you must also provide a **9:16 (720 x 1080 or 1440 x 2160 pixels)** image in the [Store logos](#store-logos) section.</span></span>


## <a name="optional-promotional-images"></a><span data-ttu-id="73555-191">オプションのプロモーション用の画像</span><span class="sxs-lookup"><span data-stu-id="73555-191">Optional promotional images</span></span>

<span data-ttu-id="73555-192">アプリが以前のバージョンの OS (Windows 8.x や Windows Phone 8.x) をサポートしている場合、プロモーション用のレイアウトで取り上げられるアプリの検討対象となるようにするには、これらの画像を提供する必要があります (ただし、画像を提供してもアプリが取り上げられる保証はありません)。</span><span class="sxs-lookup"><span data-stu-id="73555-192">If your app supports earlier OS versions (Windows 8.x and/or Windows Phone 8.x), these images must be provided in order for us to consider featuring your app in promotional layouts (though they don't guarantee that your app will be featured).</span></span> <span data-ttu-id="73555-193">アプリがこれらの以前の OS バージョンをサポートしていない場合は、このセクションは省略できます。</span><span class="sxs-lookup"><span data-stu-id="73555-193">If your app does not support these earlier OS versions, you can skip this section.</span></span>

<span data-ttu-id="73555-194">**Windows Phone 8.1 以前**では、**1000 x 800 ピクセル (5:4)** と **358 x 358 ピクセル (1:1)** の 2 つの画像サイズをプロモーション用のレイアウトで使用できます。</span><span class="sxs-lookup"><span data-stu-id="73555-194">**For Windows Phone 8.1 and earlier**, two image sizes can be used in promotional layouts: **1000 x 800 pixels (5:4)** and **358 x 358 pixels (1:1)**.</span></span> <span data-ttu-id="73555-195">アプリが Windows Phone 8.1 以前で実行される場合は、プロモーションの対象として検討されるように、これらの両方のサイズの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73555-195">If your app runs on Windows Phone 8.1 or earlier, we recommend providing images in both of these sizes for promotional consideration.</span></span>  

> [!TIP]
> <span data-ttu-id="73555-196">Windows Phone 8.1 以前をサポートする申請では、忘れずに [[ストア ロゴ]](#store-logos) セクションで 300 x 300 のアプリ タイル アイコン画像を提供してください。</span><span class="sxs-lookup"><span data-stu-id="73555-196">Be sure to provide a 300 x 300 app tile icon image in the [Store logos](#store-logos) section for any submission that supports Windows Phone 8.1 or earlier.</span></span> <span data-ttu-id="73555-197">これにより、ストアでアプリが空白のアイコンで表示されるのを防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="73555-197">This will ensure that your app does not appear in the Store with a blank icon.</span></span>  

<span data-ttu-id="73555-198">**Windows 8.1 以前**では、いくつかのプロモーション用のレイアウトで **414 x 180** ピクセルのサイズが使われることがあります。</span><span class="sxs-lookup"><span data-stu-id="73555-198">**For Windows 8.1 and earlier**, some promotional layouts may use an image in the **414 x 180** pixel size.</span></span> <span data-ttu-id="73555-199">アプリが Windows 8.1 以前で実行される場合は、プロモーションの対象として検討されるように、このサイズの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73555-199">If your app runs on Windows 8.1 or earlier, we recommend providing an image in this size for promotional consideration.</span></span>


## <a name="trailers"></a><span data-ttu-id="73555-200">トレーラー</span><span class="sxs-lookup"><span data-stu-id="73555-200">Trailers</span></span>

<span data-ttu-id="73555-201">トレーラーは、製品がどのようなものかを知ってもらうために、製品の動作をユーザーに紹介する短いビデオです。</span><span class="sxs-lookup"><span data-stu-id="73555-201">Trailers are short videos that give customers a way to see your product in action, so they can get a better understanding of what it’s like.</span></span> <span data-ttu-id="73555-202">アプリのストア登録情報の最上部に表示されます ([プロモーション用の画像](#promotional-images)のセクションで  **1920 x 1080 ピクセルの画像 (16:9)** を含めている場合)。</span><span class="sxs-lookup"><span data-stu-id="73555-202">They are shown at the top of your app's Store listing (as long as you include a **1920 x 1080 pixel image (16:9)** in the [Promotional images](#promotional-images) section).</span></span> 

<span data-ttu-id="73555-203">トレーラーは[スムーズ ストリーミング](http://www.iis.net/downloads/microsoft/smooth-streaming)でエンコードされ、クライアントに配信されるビデオ ストリームの品質は、利用可能な帯域幅と CPU リソースに基づいて調整されます。</span><span class="sxs-lookup"><span data-stu-id="73555-203">Trailers are encoded with [Smooth Streaming](http://www.iis.net/downloads/microsoft/smooth-streaming), which adapts the quality of a video stream delivered to clients in real time based on their available bandwidth and CPU resources.</span></span>

> [!NOTE]
> <span data-ttu-id="73555-204">トレーラーは、Windows 10 バージョン 1607 以降のユーザーにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="73555-204">Trailers are only shown to customers on Windows 10, version 1607 or later.</span></span>

### <a name="upload-trailers"></a><span data-ttu-id="73555-205">トレーラーのアップロード</span><span class="sxs-lookup"><span data-stu-id="73555-205">Upload trailers</span></span>

<span data-ttu-id="73555-206">ストア登録情報には、最大 15 個のトレーラーを追加できます。</span><span class="sxs-lookup"><span data-stu-id="73555-206">You can add up to 15 trailers to your Store listing.</span></span> <span data-ttu-id="73555-207">各トレーラーが以下に示す要件を満たしていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="73555-207">Be sure they meet the requirements listed below for each trailer.</span></span>

<span data-ttu-id="73555-208">トレーラーごとに、ビデオ ファイル (.mp4 または .mov)、サムネイル画像、タイトルを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-208">You must provide a video file (.mp4 or .mov), a thumbnail image, and a title for each trailer.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="73555-209">トレーラーを使う場合は、トレーラーがアプリのストア登録情報の最上部に表示されるように、[プロモーション用の画像](#promotional-images)のセクションで **1920 x 1080 ピクセルの画像 (16:9)** を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-209">When using trailers, you must also provide a **1920 x 1080 pixel image (16:9)** in the [Promotional images](#promotional-images) section in order for your trailers to appear at the top of your Store listing.</span></span> <span data-ttu-id="73555-210">この画像は、トレーラーの再生後に表示されます。</span><span class="sxs-lookup"><span data-stu-id="73555-210">This image will appear after your trailers have finished playing.</span></span>

<span data-ttu-id="73555-211">効果的なトレーラーを作成するには、次の推奨事項に従ってください。</span><span class="sxs-lookup"><span data-stu-id="73555-211">Follow these recommendations to make your trailers effective:</span></span>
- <span data-ttu-id="73555-212">トレーラーは、高品質で最小限の長さ (2 分以内を推奨) にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-212">Trailers should be of good quality and minimal length (2 minutes or less recommended).</span></span> 
- <span data-ttu-id="73555-213">フレーム レートと解像度は、ソース マテリアルと一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-213">Frame rate and resolution should match the source material.</span></span> <span data-ttu-id="73555-214">たとえば、720p60 で撮影されたコンテンツは、720p60 でエンコードしてアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-214">For example, content shot at 720p60 should be encoded and uploaded at 720p60.</span></span> 
- <span data-ttu-id="73555-215">各トレーラーが別々の内容であることがユーザーにわかるように、トレーラーごとに異なるサムネイルを使ってください。</span><span class="sxs-lookup"><span data-stu-id="73555-215">Use a different thumbnail for each trailer so that customers know they are unique.</span></span>
- <span data-ttu-id="73555-216">一部のレイアウトではトレーラーの上下がわずかにトリミングされる可能性があるため、重要な情報は画面の中央に表示されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="73555-216">Because some layouts may slightly crop the top and bottom of your trailer, make sure key info appears in the center of the screen.</span></span>

<span data-ttu-id="73555-217">次に示す要件にも従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-217">You must also follow the requirements stated below.</span></span>

**<span data-ttu-id="73555-218">登録情報にトレーラーを追加するには:</span><span class="sxs-lookup"><span data-stu-id="73555-218">To add trailers to your listing:</span></span>**
1. <span data-ttu-id="73555-219">指定されたボックスにトレーラーの**ビデオ ファイル**をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="73555-219">Upload your trailer **video file** in the indicated box.</span></span> <span data-ttu-id="73555-220">既にアップロードしたトレーラーを再利用する場合のために (別の言語のストア登録情報を作成する場合など)、ドロップダウン ボックスも表示されます。</span><span class="sxs-lookup"><span data-stu-id="73555-220">A drop-down box is also shown in case you want to reuse a trailer you have alread uploaded (perhaps for a Store listing in a different language).</span></span>
2. <span data-ttu-id="73555-221">トレーラーをアップロードしたら、対応する**サムネイル画像**をアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-221">After you have uploaded the trailer, you'll need to upload a **thumbnail image** to go along with it.</span></span> <span data-ttu-id="73555-222">これは 1920 x 1080 ピクセルの .png ファイルにする必要があり、通常はトレーラーから取得した静止画像を使います。</span><span class="sxs-lookup"><span data-stu-id="73555-222">This must be a .png file that is 1920 x 1080 pixels, and is typically a still image taken from the trailer.</span></span>
3. <span data-ttu-id="73555-223">鉛筆アイコンをクリックして**タイトル**を追加します (255 文字以内)。</span><span class="sxs-lookup"><span data-stu-id="73555-223">Click the pencil icon to add a **title** for your trailer (255 characters or fewer).</span></span>
4. <span data-ttu-id="73555-224">登録情報にさらにトレーラーを追加する場合は、**[トレーラーの追加]** をクリックし、上の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="73555-224">If you want to add more trailers to the listing, click **Add trailer** and repeat the steps listed above.</span></span>

<span data-ttu-id="73555-225">トレーラーを削除するには、ファイル名の横にある **[X]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="73555-225">To remove a trailer, click the **X** next to its file name.</span></span> <span data-ttu-id="73555-226">現在のストア登録情報からのみ削除するか、製品のすべてのストア登録情報から削除するか (つまり、この言語だけを対象とするか、すべての言語を対象とするか) を選択できます。</span><span class="sxs-lookup"><span data-stu-id="73555-226">You can choose whether to remove it from only the current Store listings, or from all Store listings for your product (that is, for only this language or for all languages).</span></span>

### <a name="trailer-requirements"></a><span data-ttu-id="73555-227">トレーラーの要件</span><span class="sxs-lookup"><span data-stu-id="73555-227">Trailer requirements</span></span>

<span data-ttu-id="73555-228">トレーラーを提供する場合は、次の要件に従ってください。</span><span class="sxs-lookup"><span data-stu-id="73555-228">When providing your trailers, be sure to follow these requirements:</span></span>

- <span data-ttu-id="73555-229">ビデオ形式は MOV または MP4 にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-229">The video format must be MOV or MP4.</span></span> 
- <span data-ttu-id="73555-230">ビデオの再生時間は 30 分未満にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-230">The video duration must be less than 30 minutes.</span></span> 
- <span data-ttu-id="73555-231">トレーラーのサイズを 10 GB より大きくすることはできません。</span><span class="sxs-lookup"><span data-stu-id="73555-231">The file size of the trailer can’t exceed 10 GB.</span></span> 
- <span data-ttu-id="73555-232">サムネイルは、1920 x 1080 ピクセルの解像度の PNG ファイルにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-232">The thumbnail must be a PNG file with a resolution of 1920 x 1080 pixels.</span></span> 
- <span data-ttu-id="73555-233">タイトルを 255 文字より長くすることはできません。</span><span class="sxs-lookup"><span data-stu-id="73555-233">The title can’t exceed 255 characters.</span></span> 

<span data-ttu-id="73555-234">ストア登録情報ページの他のフィールドと同様に、トレーラーをストアに公開するには、その前に認定に合格する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73555-234">Like the other fields on the Store listing page, trailers must pass certification before you can publish them to the Store.</span></span> <span data-ttu-id="73555-235">トレーラーが [Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx)に準拠していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="73555-235">Be sure your trailers comply with the [Windows Store Policies](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx).</span></span>

<span data-ttu-id="73555-236">ファイルの種類に応じて追加の要件があります。</span><span class="sxs-lookup"><span data-stu-id="73555-236">There are additional requirements depending on the type of file.</span></span>

#### <a name="mov"></a><span data-ttu-id="73555-237">MOV</span><span class="sxs-lookup"><span data-stu-id="73555-237">MOV</span></span>

<table>
<tr>
<td>
**<span data-ttu-id="73555-238">ビデオ:</span><span class="sxs-lookup"><span data-stu-id="73555-238">Video:</span></span>**
<ul>
<li><span data-ttu-id="73555-239">1080p ProRes (適切な場合は HQ)</span><span class="sxs-lookup"><span data-stu-id="73555-239">1080p ProRes (HQ where appropriate)</span></span></li>
<li><span data-ttu-id="73555-240">ネイティブ フレーム レート (29.97 FPS を推奨)</span><span class="sxs-lookup"><span data-stu-id="73555-240">Native framerate; 29.97 FPS preferred</span></span></li>
</ul>
</td>
<td>
**<span data-ttu-id="73555-241">オーディオ:</span><span class="sxs-lookup"><span data-stu-id="73555-241">Audio:</span></span>**
<ul>
<li><span data-ttu-id="73555-242">ステレオが必須</span><span class="sxs-lookup"><span data-stu-id="73555-242">Stereo required</span></span></li>
<li><span data-ttu-id="73555-243">推奨オーディオ レベル: -16 LKFS/LUFS</span><span class="sxs-lookup"><span data-stu-id="73555-243">Recommended Audio Level: -16 LKFS/LUFS</span></span></li>
</ul> 
</td>
</tr>
</table>

#### <a name="mp4"></a><span data-ttu-id="73555-244">MP4</span><span class="sxs-lookup"><span data-stu-id="73555-244">MP4</span></span>

<table>
<tr>
<td>
**<span data-ttu-id="73555-245">ビデオ:</span><span class="sxs-lookup"><span data-stu-id="73555-245">Video:</span></span>**
<ul>
<li><span data-ttu-id="73555-246">コーデック: H.264</span><span class="sxs-lookup"><span data-stu-id="73555-246">Codec: H.264</span></span></li>
<li><span data-ttu-id="73555-247">プログレッシブ スキャン (インターレースなし)</span><span class="sxs-lookup"><span data-stu-id="73555-247">Progressive scan (no interlacing)</span></span></li>
<li><span data-ttu-id="73555-248">ハイ プロファイル</span><span class="sxs-lookup"><span data-stu-id="73555-248">High Profile</span></span></li>
<li><span data-ttu-id="73555-249">2 連続 B フレーム</span><span class="sxs-lookup"><span data-stu-id="73555-249">2 consecutive B frames</span></span></li>
<li><span data-ttu-id="73555-250">クローズド GOP </span><span class="sxs-lookup"><span data-stu-id="73555-250">Closed GOP.</span></span> <span data-ttu-id="73555-251">(フレーム レートの半分の GOP)</span><span class="sxs-lookup"><span data-stu-id="73555-251">GOP of half the frame rate</span></span></li>
<li><span data-ttu-id="73555-252">CABAC</span><span class="sxs-lookup"><span data-stu-id="73555-252">CABAC</span></span></li>
<li><span data-ttu-id="73555-253">50 MB/秒</span><span class="sxs-lookup"><span data-stu-id="73555-253">50 MB/s</span></span> </li>
<li><span data-ttu-id="73555-254">色空間: 4.2.0</span><span class="sxs-lookup"><span data-stu-id="73555-254">Color Space: 4.2.0</span></span></li>
</ul>
</td>
<td>
**<span data-ttu-id="73555-255">オーディオ:</span><span class="sxs-lookup"><span data-stu-id="73555-255">Audio:</span></span>**
<ul>
<li><span data-ttu-id="73555-256">コーデック: AAC-LC</span><span class="sxs-lookup"><span data-stu-id="73555-256">Codec: AAC-LC</span></span></li>
<li><span data-ttu-id="73555-257">チャンネル: ステレオまたはサラウンド サウンド</span><span class="sxs-lookup"><span data-stu-id="73555-257">Channels: Stereo or surround sound</span></span></li>
<li><span data-ttu-id="73555-258">サンプル レート: 48 KHz</span><span class="sxs-lookup"><span data-stu-id="73555-258">Sample rate: 48 KHz</span></span></li>
<li><span data-ttu-id="73555-259">オーディオ ビットレート: ステレオでは 384 KB/秒、サラウンド サウンドでは 512 KB/秒</span><span class="sxs-lookup"><span data-stu-id="73555-259">Audio Bitrate: 384 KB/s for Stereo, 512 KB/s for surround sound</span></span></li>
</ul>
</td>
</tr>
</table>

<span data-ttu-id="73555-260">H.264 メザニン ファイルでは、次の形式が推奨されます。</span><span class="sxs-lookup"><span data-stu-id="73555-260">For H.264 Mezzanine files, we recommend the following:</span></span>
- <span data-ttu-id="73555-261">コンテナー: MP4</span><span class="sxs-lookup"><span data-stu-id="73555-261">Container: MP4</span></span>
- <span data-ttu-id="73555-262">編集リストなし (そうでない場合、AV の同期が失われることがあります)</span><span class="sxs-lookup"><span data-stu-id="73555-262">No Edit Lists (or you might lose AV sync)</span></span>
- <span data-ttu-id="73555-263">ファイルの先頭に moov アトムを配置 (ファスト スタート)</span><span class="sxs-lookup"><span data-stu-id="73555-263">moov atom at the front of the file (Fast Start)</span></span>

