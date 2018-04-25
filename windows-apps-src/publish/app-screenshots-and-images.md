---
author: jnHs
Description: You can select the screenshots, logos, and other art assets (such as trailers and promotional images) to include in your app's Store listing.
title: アプリのスクリーンショット、画像、トレーラー
ms.assetid: D216DD2B-F43D-4D26-82EE-0CD34DB929D8
ms.author: wdg-dev-content
ms.date: 3/13/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, uwp, 予告編, ビデオ, スクリーン ショット, 画像, アイコン, Store 登録情報, Store 登録情報の画像
ms.localizationpriority: high
ms.openlocfilehash: 56edae8c8af56f45a8901938908dc6064c93b1fd
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
---
# <a name="app-screenshots-images-and-trailers"></a><span data-ttu-id="e319e-103">アプリのスクリーンショット、画像、トレーラー</span><span class="sxs-lookup"><span data-stu-id="e319e-103">App screenshots, images, and trailers</span></span>

<span data-ttu-id="e319e-104">デザインが優れた画像は、ストアで潜在顧客にアプリをアピールする効果的な方法の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="e319e-104">Well-designed images are one of the main ways for you to represent your app to potential customers in the Store.</span></span>

<span data-ttu-id="e319e-105">アプリのストア登録情報には、[スクリーンショット](#screenshots)、[ロゴ](#store-logos)、追加のアート資産 ([トレーラー](#trailers)や[プロモーション用の画像](##additional-art-assets)など) を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="e319e-105">You can provide [screenshots](#screenshots), [logos](#store-logos), and other art assets (such as [trailers](#trailers) and [promotional images](##additional-art-assets) to include in your app's Store listing.</span></span> <span data-ttu-id="e319e-106">これらの中には必須の画像も、省略可能な画像もあります (ただし、省略可能な画像の中には、ストア登録情報をできるだけ魅力的なものにするため、含めた方がよい画像があります)。</span><span class="sxs-lookup"><span data-stu-id="e319e-106">Some of these are required, and some are optional (although some of the optional images are important to include for the best Store display).</span></span> 

<span data-ttu-id="e319e-107">[アプリの申請プロセス](app-submissions.md)では、[ストア登録情報](create-app-store-listings.md)を設定する手順でこのようなアート資産を指定します。</span><span class="sxs-lookup"><span data-stu-id="e319e-107">During the [app submission process](app-submissions.md), you provide these art assets in the [Store listings](create-app-store-listings.md) step.</span></span> <span data-ttu-id="e319e-108">ストアで使用される画像やその表示状態は、ユーザーのオペレーティング システムやその他の要因によって異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-108">Note that the images which are used in the Store, and the way that they appear, may vary depending on the customer's operating system and other factors.</span></span>

<span data-ttu-id="e319e-109">ストアでは、アプリのタイルと、アプリのパッケージに含まれている他の画像も使われる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-109">The Store may also use your app's tile and other images that you include in your app's package.</span></span> <span data-ttu-id="e319e-110">アプリを申請する前に、[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)を実行して、必須の画像が不足していないかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="e319e-110">Run the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) to determine if you're missing any required images before you submit your app.</span></span> <span data-ttu-id="e319e-111">これらの画像に関するガイダンスと推奨事項については、「[タイルとアイコン アセット](../design/shell/tiles-and-notifications/app-assets.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e319e-111">For guidance and recommendations about these images, see [Tile and icon assets](../design/shell/tiles-and-notifications/app-assets.md).</span></span>

## <a name="screenshots"></a><span data-ttu-id="e319e-112">スクリーンショット</span><span class="sxs-lookup"><span data-stu-id="e319e-112">Screenshots</span></span>

<span data-ttu-id="e319e-113">スクリーンショットは、アプリの Store 登録情報でユーザーに表示されるアプリの画像です。</span><span class="sxs-lookup"><span data-stu-id="e319e-113">Screenshots are images of your app that are displayed to your customers in your app's Store listing.</span></span>

<span data-ttu-id="e319e-114">ユーザーが特定の種類のデバイスでアプリの Store 登録情報を表示したときに適切なスクリーンショットが表示されるように、アプリでサポートされているさまざまなデバイス ファミリ用のスクリーンショットを提供できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-114">You have the option to provide screenshots for the different device families that your app supports so that the appropriate screenshots will appear when a customer views your app's Store listing on that type of device.</span></span> 

<span data-ttu-id="e319e-115">(どのデバイス ファミリであっても) 申請時に必要なスクリーンショットは 1 つだけですが、デスクトップ用のスクリーンショットは最大 9 個、その他のデバイス ファミリ用のスクリーンショットは最大 8 個まで指定できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-115">Only one screenshot (for any device family) is required for your submission, though you can provide several; up to 9 desktop screenshots and up to 8 screenshots for the other device families.</span></span> <span data-ttu-id="e319e-116">ユーザーが自分が使っている種類のデバイスでアプリがどのように表示されるかをイメージできるように、アプリがサポートするデバイス ファミリごとに少なくとも 4 つのスクリーンショットを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e319e-116">We suggest providing at least four screenshots for each device family that your app supports so that people can see how the app will look on their device type.</span></span> <span data-ttu-id="e319e-117">(アプリでサポートされていないデバイス ファミリのスクリーンショットは含めないでください)。**デスクトップ**のスクリーンショットは、Surface Hub デバイスのユーザーにも表示される点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="e319e-117">(Do not include screenshots for device families that your app does not support.) Note that **Desktop** screenshots will also be shown to customers on Surface Hub devices.</span></span>

> [!NOTE]
> <span data-ttu-id="e319e-118">Microsoft Visual Studio には、[スクリーンショットをキャプチャするツール](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator#BKMK_Capture_a_screenshot_of_your_app_for_submission_to_the_Microsoft_Store)が用意されています。</span><span class="sxs-lookup"><span data-stu-id="e319e-118">Microsoft Visual Studio provides a [tool to help you capture screenshots](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator#BKMK_Capture_a_screenshot_of_your_app_for_submission_to_the_Microsoft_Store).</span></span>

<span data-ttu-id="e319e-119">各スクリーンショットは .png ファイルでなければならず、横方向でも縦方向でもかまいません。ファイル サイズは 50 MB 以下にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-119">Each screenshot must be a .png file in either landscape or portrait orientation, and the file size can't be larger than 50 MB.</span></span>

<span data-ttu-id="e319e-120">サイズの要件は、デバイス ファミリによって異なります。</span><span class="sxs-lookup"><span data-stu-id="e319e-120">The size requirements vary depending on the device family:</span></span>
- <span data-ttu-id="e319e-121">デスクトップ: 1366 x 768 ピクセル以上。</span><span class="sxs-lookup"><span data-stu-id="e319e-121">Desktop: 1366 x 768 pixels or larger.</span></span> <span data-ttu-id="e319e-122">4K 画像 (3840 x 2160) がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="e319e-122">Supports 4K images (3840 x 2160).</span></span> <span data-ttu-id="e319e-123">(Surface Hub デバイスのユーザーにも表示されます)。</span><span class="sxs-lookup"><span data-stu-id="e319e-123">(Will also be shown to customers on Surface Hub devices.)</span></span>
- <span data-ttu-id="e319e-124">モバイル: 画像は、1080 x 1920、1920 x 1080、768 x 1280、1280 x 768、720 x 1280、1280 x 720、800 x 480、または 480 x 800 ピクセルのいずれかにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-124">Mobile: Images must be one of the following: 1080 x 1920, 1920 x 1080, 768 x 1280, 1280 x 768, 720 x 1280, 1280 x 720, 800 x 480, or 480 x 800 pixels.</span></span>
- <span data-ttu-id="e319e-125">Xbox: 3480 x 2160 ピクセル以下。</span><span class="sxs-lookup"><span data-stu-id="e319e-125">Xbox: 3480 x 2160 pixels or smaller.</span></span> <span data-ttu-id="e319e-126">4K 画像 (3840 x 2160) がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="e319e-126">Supports 4K images (3840 x 2160).</span></span>
- <span data-ttu-id="e319e-127">ホログラフィック: 1268 x 720 ピクセル以上。</span><span class="sxs-lookup"><span data-stu-id="e319e-127">Holographic: 1268 x 720 pixels or larger.</span></span> <span data-ttu-id="e319e-128">4K 画像 (3840 x 2160) がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="e319e-128">Supports 4K images (3840 x 2160).</span></span>

<span data-ttu-id="e319e-129">最適な表示のために、スクリーンショットの作成時には次のガイドラインに留意してください。</span><span class="sxs-lookup"><span data-stu-id="e319e-129">For the best display, keep the following guidelines in mind when creating your screenshots:</span></span>
- <span data-ttu-id="e319e-130">重要なビジュアルとテキストは画像の上部 3/4 に収めてください。</span><span class="sxs-lookup"><span data-stu-id="e319e-130">Keep critical visuals and text in the top 3/4 of the image.</span></span> <span data-ttu-id="e319e-131">下部 1/4 にはテキスト オーバーレイが表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="e319e-131">Text overlays may appear on the bottom 1/4.</span></span> 
- <span data-ttu-id="e319e-132">スクリーンショットにはロゴ、アイコン、マーケティング メッセージを追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="e319e-132">Don’t add additional logos, icons, or marketing messages to your screenshots.</span></span>
- <span data-ttu-id="e319e-133">過度に明るい色や暗い色、またはコントラストの高い縞模様は使わないでください。テキスト オーバーレイの読みやすさが損なわれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-133">Don’t use extremely light or dark colors or highly-contrasting stripes that may interfere with readability of text overlays.</span></span>

<span data-ttu-id="e319e-134">各スクリーンショットを説明する短いキャプションを 200 文字以内で指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="e319e-134">You can also provide a short caption that describes each screenshot in 200 characters or less.</span></span>

> [!TIP]
> <span data-ttu-id="e319e-135">スクリーンショットは、指定した順番に登録情報に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-135">Screenshots are displayed in your listing in order.</span></span> <span data-ttu-id="e319e-136">スクリーンショットをアップロードした後で、ドラッグ アンド ドロップで並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="e319e-136">After you upload your screenshots, you can drag and drop them to reorder them.</span></span> 

<span data-ttu-id="e319e-137">ストア登録情報を[複数の言語](supported-languages.md)で用意する場合は、言語ごとに **[ストア登録情報]** ページがあります。</span><span class="sxs-lookup"><span data-stu-id="e319e-137">Note that if you create Store listings for [multiple languages](supported-languages.md), you'll have a **Store listing** page for each one.</span></span> <span data-ttu-id="e319e-138">画像は言語ごとに個別にアップロードし (同じ画像を使う場合でも)、使用するキャプションも言語ごとに指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-138">You'll need to upload images for each language separately (even if you are using the same images), and provide captions to use for each language.</span></span>


## <a name="store-logos"></a><span data-ttu-id="e319e-139">Microsoft Store ロゴ</span><span class="sxs-lookup"><span data-stu-id="e319e-139">Store logos</span></span>

<span data-ttu-id="e319e-140">Microsoft Store ロゴをアップロードし、Microsoft Store の表示をさらにカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e319e-140">You can upload Store logos to create a more customized display in the Store.</span></span> <span data-ttu-id="e319e-141">アプリがサポートするすべての デバイスと OS バージョンで、Store 登録情報が最適に表示されるように、これらの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e319e-141">We recommend that you provide these images so that your Store listing appears optimally on all of the devices and OS versions that your app supports.</span></span> <span data-ttu-id="e319e-142">アプリを Xbox のユーザーにも提供している場合、これらの画像もいくつか必要である点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="e319e-142">Note that if your app is available to customers on Xbox, some of these images are required.</span></span>

<span data-ttu-id="e319e-143">これらの画像は .png ファイル (50 MB 以内) として用意できます。各画像は次のガイドラインに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-143">You can provide these images as .png files (no greater than 50 MB), each of which should follow the guidelines below.</span></span>

### <a name="916-poster-art-720-x-1080-or-1440-x-2160-pixels"></a><span data-ttu-id="e319e-144">9:16 ポスター アート (720 x 1080 または 1440 x 2160 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="e319e-144">9:16 Poster art (720 x 1080 or 1440 x 2160 pixels)</span></span>

<span data-ttu-id="e319e-145">Windows 10 デバイスと Xbox デバイスのユーザー向けのメイン ロゴ画像として使われます。適切に表示されるようにするため、この画像を用意することを**強くお勧め**します。</span><span class="sxs-lookup"><span data-stu-id="e319e-145">This is used as the main logo image for customers on Windows 10 and Xbox devices, so we **strongly recommend** providing this image to ensure proper display.</span></span> <span data-ttu-id="e319e-146">この画像を含めないと登録情報が適切に表示されない可能性があります。また、Microsoft Store を参照しているときにユーザーに表示される他の登録情報と一貫性がなくなります。</span><span class="sxs-lookup"><span data-stu-id="e319e-146">Your listing may not look good if you don't include it, and won't be consistent with other listings that customers see while browing the Store.</span></span> <span data-ttu-id="e319e-147">この画像は、検索結果や自動編集コレクションでも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e319e-147">This image may also be used in search results or in editorially-curated collections.</span></span>

<span data-ttu-id="e319e-148">この画像にはアプリ名を含める必要があり、画像内のテキストは、読みやすさに関するアクセシビリティ要件 (4.5:1 のコントラスト比) を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-148">This image should include your app’s name, and any text on the image should meet accessible readability requirements (4.51 contrast ratio).</span></span> <span data-ttu-id="e319e-149">この画像の下部 4 分の 1 にテキスト オーバーレイが表示されることがあるため、テキストやキーの画像を含めないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="e319e-149">Note that text overlays may appear on the bottom quarter of this image, so make sure you don't include text or key imagery there.</span></span>

> [!NOTE]
> <span data-ttu-id="e319e-150">Xbox のユーザーにアプリを提供している場合、この画像は**必須**であり、製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-150">If your app is available to customers on Xbox, this image is **required** and must include the product's title.</span></span> <span data-ttu-id="e319e-151">画像の下部 4 分の 1 にはテキスト オーバーレイが表示されることがあるため、タイトルは画像の上部 4 分の 3 に表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-151">The title must appear in the top three-quarters of the image, since text overlays may appear on the bottom quarter of the image.</span></span>

### <a name="11-box-art-1080-x-1080-or-2160-x-2160-pixels"></a><span data-ttu-id="e319e-152">1:1 ボックス アート (1080 x 1080 または 2160 x 2160 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="e319e-152">1:1 box art (1080 x 1080 or 2160 x 2160 pixels)</span></span>

<span data-ttu-id="e319e-153">この画像は、Windows 10 (Xbox を含む) のさまざまな Microsoft Store に表示される場合があります。**9:16 ポスター アート**画像を用意しない場合、この画像がメイン ロゴとして使用されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-153">This image may appear in various Store pages for Windows 10 (including Xbox), and if you don't provide the **9:16 Poster art** image it will be used as your main logo.</span></span> <span data-ttu-id="e319e-154">この画像にはアプリの名前も含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-154">This image should also include your app’s name.</span></span> <span data-ttu-id="e319e-155">この画像の下部 4 分の 1 にテキスト オーバーレイが表示されることがあるため、テキストやキーの画像を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="e319e-155">Text overlays may appear on the bottom quarter of this image, so don't include text or key imagery there.</span></span> <span data-ttu-id="e319e-156">必ず、この画像にはアプリの名前を含めてください。</span><span class="sxs-lookup"><span data-stu-id="e319e-156">Be sure to include your app’s name in this image.</span></span> 

> [!NOTE]
> <span data-ttu-id="e319e-157">Xbox のユーザーにアプリを提供している場合、この画像は**必須**であり、製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-157">If your app is available to customers on Xbox, this image is **required** and must include the product's title.</span></span> <span data-ttu-id="e319e-158">画像の下部 4 分の 1 にはテキスト オーバーレイが表示されることがあるため、タイトルは画像の上部 4 分の 3 に表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-158">The title must appear in the top three-quarters of the image, since text overlays may appear on the bottom quarter of the image.</span></span>

### <a name="11-app-tile-icon-300-x-300-pixels"></a><span data-ttu-id="e319e-159">1:1 アプリ タイル アイコン (300 x 300 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="e319e-159">1:1 App tile icon (300 x 300 pixels)</span></span>

<span data-ttu-id="e319e-160">この画像は、Windows Phone 8.1 以前で適切に表示されるために必要です。</span><span class="sxs-lookup"><span data-stu-id="e319e-160">This image is required for proper display on Windows Phone 8.1 and earlier.</span></span> <span data-ttu-id="e319e-161">アプリで Windows Phone 8.1 以前がサポートされているが、この画像を用意しない場合、アプリの登録情報ページに空白のアイコンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-161">If your app supports Windows Phone 8.1 or earlier and you don't provide this image, those customers will see a blank icon with your app's listing.</span></span> <span data-ttu-id="e319e-162">(アプリに Windows Phone 8.1 以前をターゲットとするパッケージしかない場合、これは Windows 10 のユーザーにも適用されます)。申請に UWP パッケージ*しか*含まれない場合は、この画像を提供する必要はありません </span><span class="sxs-lookup"><span data-stu-id="e319e-162">(This also applies to customers on Windows 10, if your app only has packages targeting Windows Phone 8.1 or earlier.) If your submission *only* includes UWP packages, you don’t need to provide this image.</span></span> <span data-ttu-id="e319e-163">(申請に Windows Phone 8.x パッケージと UWP パッケージの両方が含まれている場合、この画像を提供すると、Windows 10 の一部の Microsoft Store レイアウトで使われることがあります。</span><span class="sxs-lookup"><span data-stu-id="e319e-163">(Note that if your submission includes both Windows Phone 8.x packages and UWP packages, and you do provide this image, it may be used on Windows 10 in certain Store layouts.</span></span> <span data-ttu-id="e319e-164">これを避けるには、アプリでサポートされている Windows Phone のバージョン用に[プラットフォーム固有の登録情報](create-platform-specific-store-listings.md)を作成し、その登録情報にのみアプリのタイル アイコンを含めるようにします)。</span><span class="sxs-lookup"><span data-stu-id="e319e-164">If you want to prevent this, you can create [platform-specific listings](create-platform-specific-store-listings.md) for the Windows Phone versions that your app supports and only include the app tile icon there.)</span></span>

<span data-ttu-id="e319e-165">また、Windows 10 (Xbox を含む) ユーザーに Microsoft Store 登録情報が表示されるときに、アプリのパッケージのロゴ画像ではなく、アップロードした画像のみが使用されるようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e319e-165">You also have the option to prevent the Store from using logo images in your app's packages when displaying your listing to customers on Windows 10 (including Xbox), and instead have the Store use only images that you upload.</span></span> <span data-ttu-id="e319e-166">これにより、Windows 10 (Xbox を含む) ユーザーについては、Microsoft Store のさまざまな画面でのアプリの魅せ方をさらに細かく制御できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-166">This gives you more control over your app’s appearance in various displays throughout the Store for customers on Windows 10 (including Xbox).</span></span>

<span data-ttu-id="e319e-167">Windows 10 (Xbox を含む) の Microsoft Store ではアップロードした画像のみを使用するには、**[Windows 10 のユーザーに対しては、パッケージの画像ではなく、アップロードしたロゴ画像を表示します]** というチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="e319e-167">To use only uploaded images for display in the Store on Windows 10 (including Xbox), check the box that says **For Windows 10 customers, display uploaded logo images instead of the images from my packages**.</span></span> <span data-ttu-id="e319e-168">(このボックスをオンにしない場合、アプリのパッケージの画像が使用されます)。</span><span class="sxs-lookup"><span data-stu-id="e319e-168">(If you don't check this box, images from your app's packages will be used.)</span></span>

<span data-ttu-id="e319e-169">このチェック ボックスをオンにすると、**[Uploaded Store logos] (アップロードされた Microsoft Store ロゴ)** という新しいセクションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-169">When you check this box, a new section called **Uploaded Store logos** appears.</span></span> <span data-ttu-id="e319e-170">ここで 3 つの画像をアップロードできます。これには 300 x 300 の "アプリ タイル アイコン" サイズも含まれます (このチェック ボックスをオンにすると、画像を指定するフィールドがこのセクションに移動します)。</span><span class="sxs-lookup"><span data-stu-id="e319e-170">Here, you can upload 3 images, including the 300 x 300 “app tile icon” size (if you check the box, the field to provide that image will move into this section).</span></span> <span data-ttu-id="e319e-171">このオプションを使う場合は、300 x 300 ピクセル、150 x 150 ピクセル、71 x 71 ピクセルの 3 つの画像をすべて指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e319e-171">We recommend providing all three image sizes if you use this option: 300 x 300, 150 x 150, and 71 x 71 pixels.</span></span> <span data-ttu-id="e319e-172">ただし、必須のサイズは 300 x 300 だけです。</span><span class="sxs-lookup"><span data-stu-id="e319e-172">However, only the 300 x 300 size is required.</span></span>


<span id="promotional-images" />

## <a name="additional-art-assets"></a><span data-ttu-id="e319e-173">追加のアート資産</span><span class="sxs-lookup"><span data-stu-id="e319e-173">Additional art assets</span></span>

<span data-ttu-id="e319e-174">このセクションでは、Microsoft Store で製品をより効果的に表示するために役立つアートワークを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-174">This section lets you provide artwork to help display your product more effectively in the Store.</span></span> <span data-ttu-id="e319e-175">より魅力的な Store 登録情報を制作するため、これらの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e319e-175">We recommend providing these images to create a more inviting Store listing.</span></span>

> [!TIP]
> <span data-ttu-id="e319e-176">**16:9 スーパー ヒーロー アート**は、Store 登録情報に[ビデオ トレーラー](#trailers) を含める場合は特に推奨されます。これを含めないと、トレーラーは登録情報の最上部に表示されません。</span><span class="sxs-lookup"><span data-stu-id="e319e-176">The **16:9 Super hero art** is especially recommended if you plan to include [video trailers](#trailers) in your Store listing; if you don't include it, your trailers won't appear at the top of your listing.</span></span>

<span data-ttu-id="e319e-177">これらの画像を追加するには、**[追加のアート資産]** セクションで **[詳細の表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="e319e-177">To add these images, select **Show details** in the **Additional art assets** section.</span></span>



### <a name="windows-10-and-xbox-image-169-super-hero-art"></a><span data-ttu-id="e319e-178">Windows 10 と Xbox の画像 (16:9 スーパー ヒーロー アート)</span><span class="sxs-lookup"><span data-stu-id="e319e-178">Windows 10 and Xbox image (16:9 Super hero art)</span></span>

<span data-ttu-id="e319e-179">**16:9 スーパー ヒーロー アート (1920 x 1080 または 3840 x 2160 ピクセル)** 画像は、あらゆる種類の Windows 10 (Xbox を含む) デバイス向けの Microsoft Store で、さまざまなレイアウトに使われます。</span><span class="sxs-lookup"><span data-stu-id="e319e-179">The **16:9 Super hero art (1920 x 1080 or 3840 x 2160 pixels)** image is used in various layouts in the Microsoft Store on all Windows 10 device types (including Xbox).</span></span> <span data-ttu-id="e319e-180">アプリがターゲットとしている OS バージョンやデバイスの種類が何であっても、この画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e319e-180">We recommend providing this image, regardless of which OS versions or device types your app targets.</span></span>

<span data-ttu-id="e319e-181">この画像は、登録情報に[ビデオ トレーラー](#trailers)が含まれる場合、適切に表示するためには*必須*です。</span><span class="sxs-lookup"><span data-stu-id="e319e-181">This image is *required* for proper display if your listing includes [video trailers](#trailers).</span></span> <span data-ttu-id="e319e-182">この画像は、Windows 10 Version 1607 以降 (Xbox を含む) のユーザーに対しては、Store 登録情報の最上部のメイン画像として使われます (またはトレーラーの再生後に表示されます)。</span><span class="sxs-lookup"><span data-stu-id="e319e-182">For customers on Windows 10, version 1607 or later (which includes Xbox), it is used as the main image on the top of your Store listing (or appears after any trailers finish playing).</span></span> <span data-ttu-id="e319e-183">Microsoft Store 全体でプロモーション用のレイアウトによってアプリを紹介するために使われることもあります。</span><span class="sxs-lookup"><span data-stu-id="e319e-183">It may also be used to feature your app in promotional layouts throughout the Store.</span></span> <span data-ttu-id="e319e-184">この画像には、製品のタイトルやそ他のテキストを含めることはできない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="e319e-184">Note that this image must not include the product's title or other text.</span></span>

<span data-ttu-id="e319e-185">この画像をデザインするときに念頭に置く必要のあるヒントを次に示します。</span><span class="sxs-lookup"><span data-stu-id="e319e-185">Here are some tips to keep in mind when designing this image:</span></span>

- <span data-ttu-id="e319e-186">画像は、1920 × 1080 ピクセルまたは 3840 x 2160 ピクセルの .png である必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-186">The image must be a .png that is either 1920 x 1080 pixels or 3840 x 2160 pixels.</span></span>
- <span data-ttu-id="e319e-187">アプリに関連があり、アプリの認識と差別化を促す動的な画像を選びます。</span><span class="sxs-lookup"><span data-stu-id="e319e-187">Select a dynamic image that relates to the app to drive recognition and differentiation.</span></span> <span data-ttu-id="e319e-188">ありきたりの写真や一般的な視覚効果は使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="e319e-188">Avoid stock photography or generic visuals.</span></span>
- <span data-ttu-id="e319e-189">画像にはテキストを含めないでください。</span><span class="sxs-lookup"><span data-stu-id="e319e-189">Don't include text in the image.</span></span>
- <span data-ttu-id="e319e-190">下部の 3 分の 1 には主要な視覚要素を配置しないでください (レイアウトによってはその比率で徐々に適用される可能性があるため)。</span><span class="sxs-lookup"><span data-stu-id="e319e-190">Avoid placing key visual elements in the bottom third of the image (since in some layouts we may apply a gradient over that portion).</span></span>
- <span data-ttu-id="e319e-191">最も重要な詳細は画像の中央に配置してください (レイアウトによっては画像がトリミングされる可能性があるため)。</span><span class="sxs-lookup"><span data-stu-id="e319e-191">Place the most important details in the center of the image (since in some layouts we may crop the image).</span></span>
- <span data-ttu-id="e319e-192">空白領域は最小限に抑えてください。</span><span class="sxs-lookup"><span data-stu-id="e319e-192">Minimize empty space.</span></span>
- <span data-ttu-id="e319e-193">アプリの UI の表示やデバイスに固有の画像の使用は避けます。</span><span class="sxs-lookup"><span data-stu-id="e319e-193">Avoid showing your app's UI, and do not use any device-specific imagery.</span></span>
- <span data-ttu-id="e319e-194">政治的および国家的なテーマ、旗、または宗教的なシンボルを避けます。</span><span class="sxs-lookup"><span data-stu-id="e319e-194">Avoid political and national themes, flags, or religious symbols.</span></span>
- <span data-ttu-id="e319e-195">無神経なジェスチャ、ヌード、ギャンブル、通貨、麻薬、タバコ、またはアルコールの画像を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="e319e-195">Don't include images of insensitive gestures, nudity, gambling, currency, drugs, tobacco, or alcohol.</span></span>
- <span data-ttu-id="e319e-196">閲覧者に向けた武器や過剰な暴力や流血の画像を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="e319e-196">Don't use weapons pointing at the viewer or excessive violence and gore.</span></span>

<span data-ttu-id="e319e-197">この画像を提供すると、アプリのプロモーションの機会があった場合に検討対象となりますが、アプリが取り上げられると保証されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="e319e-197">While providing this image allows us to consider your app for featured promotional opportunities, it does not guarantee that your app will be featured.</span></span> <span data-ttu-id="e319e-198">詳しくは、「[アプリの販売促進を容易にする方法](make-your-app-easier-to-promote.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e319e-198">See [Making your app easy to promote](make-your-app-easier-to-promote.md) for more information.</span></span>


### <a name="xbox-images"></a><span data-ttu-id="e319e-199">Xbox 画像</span><span class="sxs-lookup"><span data-stu-id="e319e-199">Xbox images</span></span>

<span data-ttu-id="e319e-200">これらの画像は、アプリを Xbox に公開する場合に、適切な表示のために必要です。</span><span class="sxs-lookup"><span data-stu-id="e319e-200">These images are required for proper display if you publish your app to Xbox.</span></span> 

<span data-ttu-id="e319e-201">アップロードできるサイズには次の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="e319e-201">There are 3 different sizes that you can upload:</span></span>
- <span data-ttu-id="e319e-202">**ブランド付きのキー アート、584 x 800 ピクセル**: 製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-202">**Branded key art, 584 x 800 pixels**: Must include the product’s title.</span></span> <span data-ttu-id="e319e-203">この画像にはブランド バーが必要です。</span><span class="sxs-lookup"><span data-stu-id="e319e-203">A Branding Bar is required on this image.</span></span> <span data-ttu-id="e319e-204">画像の下部 4 分の 1 にはオーバーレイが表示されることがあるため、タイトルとすべてのキーの画像を上部 4 分の 3 にとどめてください。</span><span class="sxs-lookup"><span data-stu-id="e319e-204">Keep the title and all key imagery in the top three-quarters of the image, as an overlay may appear over the bottom quarter.</span></span>
- <span data-ttu-id="e319e-205">**タイトル付きのヒーロー アート、1920 x 1080 ピクセル**: 製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-205">**Titled hero art, 1920 x 1080 pixels**: Must include the product’s title.</span></span> <span data-ttu-id="e319e-206">画像の下部 4 分の 1 にはオーバーレイが表示されることがあるため、タイトルとすべてのキーの画像を上部 4 分の 3 にとどめてください。</span><span class="sxs-lookup"><span data-stu-id="e319e-206">Keep the title and all key imagery in the top three-quarters of the image, as an overlay may appear over the bottom quarter.</span></span>
- <span data-ttu-id="e319e-207">**おすすめプロモーション アート (正方形)、1080 x 1080 ピクセル**: 製品のタイトルは含めることは*できません*。</span><span class="sxs-lookup"><span data-stu-id="e319e-207">**Featured Promotional Square art, 1080 x 1080 pixels**: Must *not* include the product’s title.</span></span>

> [!NOTE]
> <span data-ttu-id="e319e-208">Xbox でできるだけ魅力的な表示にするには、[ストア ロゴ](#store-logos)のセクションで **9:16 (720 x 1080 または 1440 x 2160 ピクセル)** の画像も提供してください。</span><span class="sxs-lookup"><span data-stu-id="e319e-208">For the best display on Xbox, you must also provide a **9:16 (720 x 1080 or 1440 x 2160 pixels)** image in the [Store logos](#store-logos) section.</span></span>


### <a name="holographic-image"></a><span data-ttu-id="e319e-209">ホログラフィックの画像</span><span class="sxs-lookup"><span data-stu-id="e319e-209">Holographic image</span></span>

<span data-ttu-id="e319e-210">**2:1 (2400 x 1200)** の画像は、アプリが Holographic デバイス ファミリをサポートする場合にのみ、使われます。</span><span class="sxs-lookup"><span data-stu-id="e319e-210">The **2:1 (2400 x 1200)** image is only used if your app supports the Holographic device family.</span></span> <span data-ttu-id="e319e-211">その場合、この画像を用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e319e-211">If it does, we recommend providing this image.</span></span>


<span id="optional-promotional-images" />

### <a name="images-only-for-windows-8x-andor-windows-phone-8x"></a><span data-ttu-id="e319e-212">Windows 8.x や Windows Phone 8.x 専用の画像</span><span class="sxs-lookup"><span data-stu-id="e319e-212">Images only for Windows 8.x and/or Windows Phone 8.x</span></span> 

<span data-ttu-id="e319e-213">アプリが以前のバージョンの OS (Windows 8.x や Windows Phone 8.x) をサポートしている場合、プロモーション用のレイアウトで取り上げられるアプリの検討対象となるようにするには、これらの画像を提供する必要があります (ただし、画像を提供してもアプリが取り上げられる保証はありません)。</span><span class="sxs-lookup"><span data-stu-id="e319e-213">If your app supports earlier OS versions (Windows 8.x and/or Windows Phone 8.x), these images must be provided in order for us to consider featuring your app in promotional layouts (though they don't guarantee that your app will be featured).</span></span> <span data-ttu-id="e319e-214">アプリがこれらの以前の OS バージョンをサポートしていない場合は、このセクションは省略できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-214">If your app does not support these earlier OS versions, you can skip this section.</span></span> <span data-ttu-id="e319e-215">(このセクションは、以前は「**オプションのプロモーション用の画像**」と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="e319e-215">(This section was formerly called **Optional promotional images**.)</span></span>

<span data-ttu-id="e319e-216">**Windows Phone 8.1 以前**では、**1000 x 800 ピクセル (5:4)** と **358 x 358 ピクセル (1:1)** の 2 つの画像サイズをプロモーション用のレイアウトで使用できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-216">**For Windows Phone 8.1 and earlier**, two image sizes can be used in promotional layouts: **1000 x 800 pixels (5:4)** and **358 x 358 pixels (1:1)**.</span></span> <span data-ttu-id="e319e-217">アプリが Windows Phone 8.1 以前で実行される場合は、プロモーションの対象として検討されるように、これらの両方のサイズの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e319e-217">If your app runs on Windows Phone 8.1 or earlier, we recommend providing images in both of these sizes for promotional consideration.</span></span>  

> [!TIP]
> <span data-ttu-id="e319e-218">Windows Phone 8.1 以前をサポートする申請では、忘れずに [[ストア ロゴ]](#store-logos) セクションで 300 x 300 のアプリ タイル アイコン画像を提供してください。</span><span class="sxs-lookup"><span data-stu-id="e319e-218">Be sure to provide a 300 x 300 app tile icon image in the [Store logos](#store-logos) section for any submission that supports Windows Phone 8.1 or earlier.</span></span> <span data-ttu-id="e319e-219">これにより、ストアでアプリが空白のアイコンで表示されるのを防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="e319e-219">This will ensure that your app does not appear in the Store with a blank icon.</span></span>  

<span data-ttu-id="e319e-220">**Windows 8.1 以前**では、いくつかのプロモーション用のレイアウトで **414 x 180** ピクセルのサイズが使われることがあります。</span><span class="sxs-lookup"><span data-stu-id="e319e-220">**For Windows 8.1 and earlier**, some promotional layouts may use an image in the **414 x 180** pixel size.</span></span> <span data-ttu-id="e319e-221">アプリが Windows 8.1 以前で実行される場合は、プロモーションの対象として検討されるように、このサイズの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e319e-221">If your app runs on Windows 8.1 or earlier, we recommend providing an image in this size for promotional consideration.</span></span>


## <a name="trailers"></a><span data-ttu-id="e319e-222">トレーラー</span><span class="sxs-lookup"><span data-stu-id="e319e-222">Trailers</span></span>

<span data-ttu-id="e319e-223">トレーラーは、製品がどのようなものかを知ってもらうために、製品の動作をユーザーに紹介する短いビデオです。</span><span class="sxs-lookup"><span data-stu-id="e319e-223">Trailers are short videos that give customers a way to see your product in action, so they can get a better understanding of what it’s like.</span></span> <span data-ttu-id="e319e-224">アプリのストア登録情報の最上部に表示されます ([プロモーション用の画像](#promotional-images)のセクションで  **1920 x 1080 ピクセルの画像 (16:9)** を含めている場合)。</span><span class="sxs-lookup"><span data-stu-id="e319e-224">They are shown at the top of your app's Store listing (as long as you include a **1920 x 1080 pixel image (16:9)** in the [Promotional images](#promotional-images) section).</span></span> 

<span data-ttu-id="e319e-225">トレーラーは[スムーズ ストリーミング](http://www.iis.net/downloads/microsoft/smooth-streaming)でエンコードされ、クライアントに配信されるビデオ ストリームの品質は、利用可能な帯域幅と CPU リソースに基づいて調整されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-225">Trailers are encoded with [Smooth Streaming](http://www.iis.net/downloads/microsoft/smooth-streaming), which adapts the quality of a video stream delivered to clients in real time based on their available bandwidth and CPU resources.</span></span>

> [!NOTE]
> <span data-ttu-id="e319e-226">トレーラーは、Windows 10 バージョン 1607 以降 (Xbox を含む) のユーザーにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-226">Trailers are only shown to customers on Windows 10, version 1607 or later (which includes Xbox).</span></span>

### <a name="upload-trailers"></a><span data-ttu-id="e319e-227">トレーラーのアップロード</span><span class="sxs-lookup"><span data-stu-id="e319e-227">Upload trailers</span></span>

<span data-ttu-id="e319e-228">Store 登録情報には、最大 15 個のトレーラーを追加できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-228">You can add up to 15 trailers to your Store listing.</span></span> <span data-ttu-id="e319e-229">各トレーラーが以下に示す[要件](#trailer-requirements)のすべてを満たしていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="e319e-229">Be sure they meet all of the [requirements](#trailer-requirements) listed below.</span></span>

<span data-ttu-id="e319e-230">提供するトレーラーごとに、ビデオ ファイル (.mp4 または .mov)、サムネイル画像、タイトルをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-230">For each trailer you provide, you must upload a video file (.mp4 or .mov), a thumbnail image, and a title.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e319e-231">トレーラーを使う場合は、トレーラーがアプリのストア登録情報の最上部に表示されるように、[プロモーション用の画像](#promotional-images)のセクションで **1920 x 1080 ピクセルの画像 (16:9)** を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-231">When using trailers, you must also provide a **1920 x 1080 pixel image (16:9)** in the [Promotional images](#promotional-images) section in order for your trailers to appear at the top of your Store listing.</span></span> <span data-ttu-id="e319e-232">この画像は、トレーラーの再生後に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-232">This image will appear after your trailers have finished playing.</span></span>

<span data-ttu-id="e319e-233">効果的なトレーラーを作成するには、次の推奨事項に従ってください。</span><span class="sxs-lookup"><span data-stu-id="e319e-233">Follow these recommendations to make your trailers effective:</span></span>
- <span data-ttu-id="e319e-234">トレーラーは、高品質で最小限の長さ (60 秒以内および 2 GB 未満を推奨) にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-234">Trailers should be of good quality and minimal length (60 seconds or less and less than 2 GB recommended).</span></span> 
- <span data-ttu-id="e319e-235">各トレーラーが別々の内容であることがユーザーにわかるように、トレーラーごとに異なるサムネイルを使ってください。</span><span class="sxs-lookup"><span data-stu-id="e319e-235">Use a different thumbnail for each trailer so that customers know they are unique.</span></span>
- <span data-ttu-id="e319e-236">一部の Store レイアウトではトレーラーの上下がわずかにトリミングされる可能性があるため、重要な情報は画面の中央に表示されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="e319e-236">Because some Store layouts may slightly crop the top and bottom of your trailer, make sure key info appears in the center of the screen.</span></span>
- <span data-ttu-id="e319e-237">フレーム レートと解像度は、ソース マテリアルと一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-237">Frame rate and resolution should match the source material.</span></span> <span data-ttu-id="e319e-238">たとえば、720p60 で撮影されたコンテンツは、720p60 でエンコードしてアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-238">For example, content shot at 720p60 should be encoded and uploaded at 720p60.</span></span> 

<span data-ttu-id="e319e-239">次に示す要件にも従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-239">You must also follow the requirements listed below.</span></span>

**<span data-ttu-id="e319e-240">登録情報にトレーラーを追加するには:</span><span class="sxs-lookup"><span data-stu-id="e319e-240">To add trailers to your listing:</span></span>**
1. <span data-ttu-id="e319e-241">指定されたボックスにトレーラーの**ビデオ ファイル**をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="e319e-241">Upload your trailer **video file** in the indicated box.</span></span> <span data-ttu-id="e319e-242">既にアップロードしたトレーラーを再利用する場合のために (別の言語のストア登録情報を作成する場合など)、ドロップダウン ボックスも表示されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-242">A drop-down box is also shown in case you want to reuse a trailer you have alread uploaded (perhaps for a Store listing in a different language).</span></span>
2. <span data-ttu-id="e319e-243">トレーラーをアップロードしたら、対応する**サムネイル画像**をアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-243">After you have uploaded the trailer, you'll need to upload a **thumbnail image** to go along with it.</span></span> <span data-ttu-id="e319e-244">これは 1920 x 1080 ピクセルの .png ファイルにする必要があり、通常はトレーラーから取得した静止画像を使います。</span><span class="sxs-lookup"><span data-stu-id="e319e-244">This must be a .png file that is 1920 x 1080 pixels, and is typically a still image taken from the trailer.</span></span>
3. <span data-ttu-id="e319e-245">鉛筆アイコンをクリックして**タイトル**を追加します (255 文字以内)。</span><span class="sxs-lookup"><span data-stu-id="e319e-245">Click the pencil icon to add a **title** for your trailer (255 characters or fewer).</span></span>
4. <span data-ttu-id="e319e-246">登録情報にさらにトレーラーを追加する場合は、**[トレーラーの追加]** をクリックし、上の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="e319e-246">If you want to add more trailers to the listing, click **Add trailer** and repeat the steps listed above.</span></span>

> [!TIP]
> <span data-ttu-id="e319e-247">複数の言語で Store 登録情報を作成した場合は、**[既存のトレーラーから選択]** を選択して、既にアップロードしたトレーラーを再利用できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-247">If you have created Store listings in multiple languages, you can select **Choose from existing trailers** to reuse the trailers you've already uploaded.</span></span> <span data-ttu-id="e319e-248">言語ごとに個別にアップロードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="e319e-248">You don't have to upload them individually for each language.</span></span>

<span data-ttu-id="e319e-249">登録情報からトレーラーを削除するには、ファイル名の横にある **[X]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="e319e-249">To remove a trailer from a listing, click the **X** next to its file name.</span></span> <span data-ttu-id="e319e-250">現在作業している Store 登録情報からのみ削除するか、製品のすべての Store 登録情報 (すべての言語) から削除するかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="e319e-250">You can choose whether to remove it from only the current Store listing in which you are working, or to remove it from from all of your product's Store listings (in every language).</span></span>


### <a name="trailer-requirements"></a><span data-ttu-id="e319e-251">トレーラーの要件</span><span class="sxs-lookup"><span data-stu-id="e319e-251">Trailer requirements</span></span>

<span data-ttu-id="e319e-252">トレーラーを提供する場合は、次の要件に従ってください。</span><span class="sxs-lookup"><span data-stu-id="e319e-252">When providing your trailers, be sure to follow these requirements:</span></span>

- <span data-ttu-id="e319e-253">ビデオ形式は MOV または MP4 にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-253">The video format must be MOV or MP4.</span></span> 
- <span data-ttu-id="e319e-254">ビデオの再生時間は 60 秒以下にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-254">The video duration shouldn't exceed 60 seconds.</span></span>
- <span data-ttu-id="e319e-255">トレーラーのサイズは 2 GB 以下にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-255">The file size of the trailer shouldn't exceed 2 GB.</span></span> 
- <span data-ttu-id="e319e-256">ビデオの解像度は、1920 × 1080 ピクセルまたは 3840 x 2160 ピクセルのいずれかである必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-256">The video resolution must be either 1920 x 1080 pixels or 3840 x 2160 pixels.</span></span>
- <span data-ttu-id="e319e-257">サムネイルは、1920 x 1080 ピクセルまたは 3840 x 2160 ピクセルの解像度の PNG ファイルにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-257">The thumbnail must be a PNG file with a resolution of either 1920 x 1080 pixels or 3840 x 2160 pixels.</span></span>
- <span data-ttu-id="e319e-258">タイトルを 255 文字より長くすることはできません。</span><span class="sxs-lookup"><span data-stu-id="e319e-258">The title can’t exceed 255 characters.</span></span> 

<span data-ttu-id="e319e-259">Store 登録情報ページの他のフィールドと同様に、トレーラーを Microsoft Store に公開するには、その前に認定に合格する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-259">Like the other fields on the Store listing page, trailers must pass certification before you can publish them to the Microsoft Store.</span></span> <span data-ttu-id="e319e-260">トレーラーが [Microsoft Storeポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx)に準拠していることを確認してください。 </span><span class="sxs-lookup"><span data-stu-id="e319e-260">Be sure your trailers comply with the [Microsoft Store Policies](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx).</span></span>

<span data-ttu-id="e319e-261">ファイルの種類に応じて追加の要件があります。</span><span class="sxs-lookup"><span data-stu-id="e319e-261">There are additional requirements depending on the type of file.</span></span>

#### <a name="mov"></a><span data-ttu-id="e319e-262">MOV</span><span class="sxs-lookup"><span data-stu-id="e319e-262">MOV</span></span>

<table>
<tr>
<td>

**<span data-ttu-id="e319e-263">ビデオ:</span><span class="sxs-lookup"><span data-stu-id="e319e-263">Video:</span></span>**

<ul>
<li><span data-ttu-id="e319e-264">1080p ProRes (適切な場合は HQ)</span><span class="sxs-lookup"><span data-stu-id="e319e-264">1080p ProRes (HQ where appropriate)</span></span></li>
<li><span data-ttu-id="e319e-265">ネイティブ フレーム レート (29.97 FPS を推奨)</span><span class="sxs-lookup"><span data-stu-id="e319e-265">Native framerate; 29.97 FPS preferred</span></span></li>
</ul>
</td>
<td>

**<span data-ttu-id="e319e-266">オーディオ:</span><span class="sxs-lookup"><span data-stu-id="e319e-266">Audio:</span></span>**

<ul>
<li><span data-ttu-id="e319e-267">ステレオが必須</span><span class="sxs-lookup"><span data-stu-id="e319e-267">Stereo required</span></span></li>
<li><span data-ttu-id="e319e-268">推奨オーディオ レベル: -16 LKFS/LUFS</span><span class="sxs-lookup"><span data-stu-id="e319e-268">Recommended Audio Level: -16 LKFS/LUFS</span></span></li>
</ul> 
</td>
</tr>
</table>

#### <a name="mp4"></a><span data-ttu-id="e319e-269">MP4</span><span class="sxs-lookup"><span data-stu-id="e319e-269">MP4</span></span>

<table>
<tr>
<td>

**<span data-ttu-id="e319e-270">ビデオ:</span><span class="sxs-lookup"><span data-stu-id="e319e-270">Video:</span></span>**

<ul>
<li><span data-ttu-id="e319e-271">コーデック: H.264</span><span class="sxs-lookup"><span data-stu-id="e319e-271">Codec: H.264</span></span></li>
<li><span data-ttu-id="e319e-272">プログレッシブ スキャン (インターレースなし)</span><span class="sxs-lookup"><span data-stu-id="e319e-272">Progressive scan (no interlacing)</span></span></li>
<li><span data-ttu-id="e319e-273">ハイ プロファイル</span><span class="sxs-lookup"><span data-stu-id="e319e-273">High Profile</span></span></li>
<li><span data-ttu-id="e319e-274">2 連続 B フレーム</span><span class="sxs-lookup"><span data-stu-id="e319e-274">2 consecutive B frames</span></span></li>
<li><span data-ttu-id="e319e-275">クローズド GOP </span><span class="sxs-lookup"><span data-stu-id="e319e-275">Closed GOP.</span></span> <span data-ttu-id="e319e-276">(フレーム レートの半分の GOP)</span><span class="sxs-lookup"><span data-stu-id="e319e-276">GOP of half the frame rate</span></span></li>
<li><span data-ttu-id="e319e-277">CABAC</span><span class="sxs-lookup"><span data-stu-id="e319e-277">CABAC</span></span></li>
<li><span data-ttu-id="e319e-278">50 MB/秒</span><span class="sxs-lookup"><span data-stu-id="e319e-278">50 MB/s</span></span> </li>
<li><span data-ttu-id="e319e-279">色空間: 4.2.0</span><span class="sxs-lookup"><span data-stu-id="e319e-279">Color Space: 4.2.0</span></span></li>
</ul>
</td>
<td>

**<span data-ttu-id="e319e-280">オーディオ:</span><span class="sxs-lookup"><span data-stu-id="e319e-280">Audio:</span></span>**

<ul>
<li><span data-ttu-id="e319e-281">コーデック: AAC-LC</span><span class="sxs-lookup"><span data-stu-id="e319e-281">Codec: AAC-LC</span></span></li>
<li><span data-ttu-id="e319e-282">チャンネル: ステレオまたはサラウンド サウンド</span><span class="sxs-lookup"><span data-stu-id="e319e-282">Channels: Stereo or surround sound</span></span></li>
<li><span data-ttu-id="e319e-283">サンプル レート: 48 KHz</span><span class="sxs-lookup"><span data-stu-id="e319e-283">Sample rate: 48 KHz</span></span></li>
<li><span data-ttu-id="e319e-284">オーディオ ビットレート: ステレオでは 384 KB/秒、サラウンド サウンドでは 512 KB/秒</span><span class="sxs-lookup"><span data-stu-id="e319e-284">Audio Bitrate: 384 KB/s for Stereo, 512 KB/s for surround sound</span></span></li>
</ul>
</td>
</tr>
</table>

<span data-ttu-id="e319e-285">H.264 メザニン ファイルでは、次の形式が推奨されます。</span><span class="sxs-lookup"><span data-stu-id="e319e-285">For H.264 Mezzanine files, we recommend the following:</span></span>
- <span data-ttu-id="e319e-286">コンテナー: MP4</span><span class="sxs-lookup"><span data-stu-id="e319e-286">Container: MP4</span></span>
- <span data-ttu-id="e319e-287">編集リストなし (そうでない場合、AV の同期が失われることがあります)</span><span class="sxs-lookup"><span data-stu-id="e319e-287">No Edit Lists (or you might lose AV sync)</span></span>
- <span data-ttu-id="e319e-288">ファイルの先頭に moov アトムを配置 (ファスト スタート)</span><span class="sxs-lookup"><span data-stu-id="e319e-288">moov atom at the front of the file (Fast Start)</span></span>

