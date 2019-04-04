---
Description: アプリのストア登録情報には、スクリーンショット、ロゴ、追加のアート資産 (トレーラーやプロモーション用の画像など) を選択して含めることができます。
title: アプリのスクリーンショット、画像、トレーラー
ms.assetid: D216DD2B-F43D-4D26-82EE-0CD34DB929D8
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, uwp, 予告編, ビデオ, スクリーン ショット, 画像, アイコン, Store 登録情報, Store 登録情報の画像
ms.localizationpriority: medium
ms.openlocfilehash: 0ae5b68d73a3776adf6250dbb96de827a106a6c5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610187"
---
# <a name="app-screenshots-images-and-trailers"></a><span data-ttu-id="47209-104">アプリのスクリーンショット、画像、トレーラー</span><span class="sxs-lookup"><span data-stu-id="47209-104">App screenshots, images, and trailers</span></span>

<span data-ttu-id="47209-105">デザインが優れた画像は、ストアで潜在顧客にアプリをアピールする効果的な方法の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="47209-105">Well-designed images are one of the main ways for you to represent your app to potential customers in the Store.</span></span>

<span data-ttu-id="47209-106">行うことができます[スクリーン ショット](#screenshots)、[ロゴ](#store-logos)、[トレーラー](#trailers)、および他のアート資産をアプリのストアの一覧に含めます。</span><span class="sxs-lookup"><span data-stu-id="47209-106">You can provide [screenshots](#screenshots), [logos](#store-logos), [trailers](#trailers), and other art assets to include in your app's Store listing.</span></span> <span data-ttu-id="47209-107">これらの中には必須の画像も、省略可能な画像もあります (ただし、省略可能な画像の中には、ストア登録情報をできるだけ魅力的なものにするため、含めた方がよい画像があります)。</span><span class="sxs-lookup"><span data-stu-id="47209-107">Some of these are required, and some are optional (although some of the optional images are important to include for the best Store display).</span></span>

<span data-ttu-id="47209-108">[アプリの申請プロセス](app-submissions.md)では、[ストア登録情報](create-app-store-listings.md)を設定する手順でこのようなアート資産を指定します。</span><span class="sxs-lookup"><span data-stu-id="47209-108">During the [app submission process](app-submissions.md), you provide these art assets in the [Store listings](create-app-store-listings.md) step.</span></span> <span data-ttu-id="47209-109">ストアで使用される画像やその表示状態は、ユーザーのオペレーティング システムやその他の要因によって異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="47209-109">Note that the images which are used in the Store, and the way that they appear, may vary depending on the customer's operating system and other factors.</span></span>

<span data-ttu-id="47209-110">ストアには、アプリのアイコンと、アプリのパッケージに含めることが他のイメージも使用可能性があります。</span><span class="sxs-lookup"><span data-stu-id="47209-110">The Store may also use your app's icon and other images that you include in your app's package.</span></span> <span data-ttu-id="47209-111">アプリを申請する前に、[Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)を実行して、必須の画像が不足していないかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="47209-111">Run the [Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) to determine if you're missing any required images before you submit your app.</span></span> <span data-ttu-id="47209-112">ガイダンスと推奨事項については、これらのイメージでは、[アプリ アイコンとロゴ](../design/style/app-icons-and-logos.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="47209-112">For guidance and recommendations about these images, see [App icons and logos](../design/style/app-icons-and-logos.md).</span></span>

## <a name="screenshots"></a><span data-ttu-id="47209-113">スクリーンショット</span><span class="sxs-lookup"><span data-stu-id="47209-113">Screenshots</span></span>

<span data-ttu-id="47209-114">スクリーンショットは、アプリのストア登録情報でユーザーに表示されるアプリの画像です。</span><span class="sxs-lookup"><span data-stu-id="47209-114">Screenshots are images of your app that are displayed to your customers in your app's Store listing.</span></span>

<span data-ttu-id="47209-115">ユーザーが特定の種類のデバイスでアプリの Store 登録情報を表示したときに適切なスクリーンショットが表示されるように、アプリでサポートされているさまざまなデバイス ファミリ用のスクリーンショットを提供できます。</span><span class="sxs-lookup"><span data-stu-id="47209-115">You have the option to provide screenshots for the different device families that your app supports so that the appropriate screenshots will appear when a customer views your app's Store listing on that type of device.</span></span> 

<span data-ttu-id="47209-116">(どのデバイス ファミリであっても) 申請時に必要なスクリーンショットは 1 つだけですが、デスクトップ用のスクリーンショットは最大 9 個、その他のデバイス ファミリ用のスクリーンショットは最大 8 個まで指定できます。</span><span class="sxs-lookup"><span data-stu-id="47209-116">Only one screenshot (for any device family) is required for your submission, though you can provide several; up to 9 desktop screenshots and up to 8 screenshots for the other device families.</span></span> <span data-ttu-id="47209-117">ユーザーが自分が使っている種類のデバイスでアプリがどのように表示されるかをイメージできるように、アプリがサポートするデバイス ファミリごとに少なくとも 4 つのスクリーンショットを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47209-117">We suggest providing at least four screenshots for each device family that your app supports so that people can see how the app will look on their device type.</span></span> <span data-ttu-id="47209-118">(含めないでくださいスクリーン ショットのデバイス ファミリで、アプリがサポートされていません。)なお**デスクトップ**スクリーン ショットは、Surface Hub デバイスのユーザーにも表示されます。</span><span class="sxs-lookup"><span data-stu-id="47209-118">(Do not include screenshots for device families that your app does not support.) Note that **Desktop** screenshots will also be shown to customers on Surface Hub devices.</span></span>

> [!NOTE]
> <span data-ttu-id="47209-119">Microsoft Visual Studio には、[スクリーンショットをキャプチャするツール](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator#BKMK_Capture_a_screenshot_of_your_app_for_submission_to_the_Microsoft_Store)が用意されています。</span><span class="sxs-lookup"><span data-stu-id="47209-119">Microsoft Visual Studio provides a [tool to help you capture screenshots](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator#BKMK_Capture_a_screenshot_of_your_app_for_submission_to_the_Microsoft_Store).</span></span>

<span data-ttu-id="47209-120">各スクリーンショットは .png ファイルでなければならず、横方向でも縦方向でもかまいません。ファイル サイズは 50 MB 以下にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-120">Each screenshot must be a .png file in either landscape or portrait orientation, and the file size can't be larger than 50 MB.</span></span>

<span data-ttu-id="47209-121">サイズの要件は、デバイス ファミリによって異なります。</span><span class="sxs-lookup"><span data-stu-id="47209-121">The size requirements vary depending on the device family:</span></span>
- <span data-ttu-id="47209-122">デスクトップ:x 768 ピクセル以上に 1366 します。</span><span class="sxs-lookup"><span data-stu-id="47209-122">Desktop: 1366 x 768 pixels or larger.</span></span> <span data-ttu-id="47209-123">4K 画像 (3840 x 2160) がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="47209-123">Supports 4K images (3840 x 2160).</span></span> <span data-ttu-id="47209-124">(Surface Hub デバイスのユーザーにも表示されます)。</span><span class="sxs-lookup"><span data-stu-id="47209-124">(Will also be shown to customers on Surface Hub devices.)</span></span>
- <span data-ttu-id="47209-125">モバイル:イメージは、次のいずれかである必要があります。1080 x 1920、1920 x 1080、768 1280 x、x 768、720 x 1280、x 720、800 x 480 または 800 ピクセル x 480 1280 1280 します。</span><span class="sxs-lookup"><span data-stu-id="47209-125">Mobile: Images must be one of the following: 1080 x 1920, 1920 x 1080, 768 x 1280, 1280 x 768, 720 x 1280, 1280 x 720, 800 x 480, or 480 x 800 pixels.</span></span>
- <span data-ttu-id="47209-126">Xbox:3480 2160 ピクセル x または小さくします。</span><span class="sxs-lookup"><span data-stu-id="47209-126">Xbox: 3480 x 2160 pixels or smaller.</span></span> <span data-ttu-id="47209-127">4K 画像 (3840 x 2160) がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="47209-127">Supports 4K images (3840 x 2160).</span></span>
- <span data-ttu-id="47209-128">Holographic:1268 x 720 ピクセル以上。</span><span class="sxs-lookup"><span data-stu-id="47209-128">Holographic: 1268 x 720 pixels or larger.</span></span> <span data-ttu-id="47209-129">4K 画像 (3840 x 2160) がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="47209-129">Supports 4K images (3840 x 2160).</span></span>

<span data-ttu-id="47209-130">最適な表示のために、スクリーンショットの作成時には次のガイドラインに留意してください。</span><span class="sxs-lookup"><span data-stu-id="47209-130">For the best display, keep the following guidelines in mind when creating your screenshots:</span></span>
- <span data-ttu-id="47209-131">重要なビジュアルとテキストは画像の上部 3/4 に収めてください。</span><span class="sxs-lookup"><span data-stu-id="47209-131">Keep critical visuals and text in the top 3/4 of the image.</span></span> <span data-ttu-id="47209-132">下部 1/4 にはテキスト オーバーレイが表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="47209-132">Text overlays may appear on the bottom 1/4.</span></span> 
- <span data-ttu-id="47209-133">スクリーンショットにはロゴ、アイコン、マーケティング メッセージを追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="47209-133">Don’t add additional logos, icons, or marketing messages to your screenshots.</span></span>
- <span data-ttu-id="47209-134">過度に明るい色や暗い色、またはコントラストの高い縞模様は使わないでください。テキスト オーバーレイの読みやすさが損なわれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="47209-134">Don’t use extremely light or dark colors or highly-contrasting stripes that may interfere with readability of text overlays.</span></span>

<span data-ttu-id="47209-135">各スクリーンショットを説明する短いキャプションを 200 文字以内で指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="47209-135">You can also provide a short caption that describes each screenshot in 200 characters or less.</span></span>

> [!TIP]
> <span data-ttu-id="47209-136">スクリーンショットは、指定した順番に登録情報に表示されます。</span><span class="sxs-lookup"><span data-stu-id="47209-136">Screenshots are displayed in your listing in order.</span></span> <span data-ttu-id="47209-137">スクリーンショットをアップロードした後で、ドラッグ アンド ドロップで並べ替えることができます。</span><span class="sxs-lookup"><span data-stu-id="47209-137">After you upload your screenshots, you can drag and drop them to reorder them.</span></span> 

<span data-ttu-id="47209-138">ストア登録情報を[複数の言語](supported-languages.md)で用意する場合は、言語ごとに **[ストア登録情報]** ページがあります。</span><span class="sxs-lookup"><span data-stu-id="47209-138">Note that if you create Store listings for [multiple languages](supported-languages.md), you'll have a **Store listing** page for each one.</span></span> <span data-ttu-id="47209-139">言語ごとに別個に画像をアップロードして (同じ画像を使う場合でも)、使用する字幕を言語ごとに入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-139">You'll need to upload images for each language separately (even if you are using the same images), and provide captions to use for each language.</span></span> <span data-ttu-id="47209-140">(多くの言語でのストアの一覧があれば、する可能性があります方が簡単なこれらを更新する[一覧表示するデータとオフラインで作業してエクスポート](import-and-export-store-listings.md))。</span><span class="sxs-lookup"><span data-stu-id="47209-140">(If you have Store listings in a lot of languages, you may find it easier to update them by [exporting your listing data and working offline](import-and-export-store-listings.md).)</span></span>


## <a name="store-logos"></a><span data-ttu-id="47209-141">ストア ロゴ</span><span class="sxs-lookup"><span data-stu-id="47209-141">Store logos</span></span>

<span data-ttu-id="47209-142">Microsoft Store ロゴをアップロードし、Microsoft Store の表示をさらにカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="47209-142">You can upload Store logos to create a more customized display in the Store.</span></span> <span data-ttu-id="47209-143">アプリがサポートするすべての デバイスと OS バージョンで、Store 登録情報が最適に表示されるように、これらの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47209-143">We recommend that you provide these images so that your Store listing appears optimally on all of the devices and OS versions that your app supports.</span></span> <span data-ttu-id="47209-144">アプリを Xbox のユーザーにも提供している場合、これらの画像もいくつか必要である点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="47209-144">Note that if your app is available to customers on Xbox, some of these images are required.</span></span>

<span data-ttu-id="47209-145">これらの画像は .png ファイル (50 MB 以内) として用意できます。各画像は次のガイドラインに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-145">You can provide these images as .png files (no greater than 50 MB), each of which should follow the guidelines below.</span></span>

### <a name="916-poster-art-720-x-1080-or-1440-x-2160-pixels"></a><span data-ttu-id="47209-146">9:16 ポスター アート (720 x 1080 または 1440 x 2160 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="47209-146">9:16 Poster art (720 x 1080 or 1440 x 2160 pixels)</span></span>

<span data-ttu-id="47209-147">Windows 10 デバイスと Xbox デバイスのユーザー向けのメイン ロゴ画像として使われます。適切に表示されるようにするため、この画像を用意することを**強くお勧め**します。</span><span class="sxs-lookup"><span data-stu-id="47209-147">This is used as the main logo image for customers on Windows 10 and Xbox devices, so we **strongly recommend** providing this image to ensure proper display.</span></span> <span data-ttu-id="47209-148">掲載は、可能性があります見栄えがない場合は、含まれていませんし、その他のストアを閲覧中に顧客に表示される一覧で一貫性のあることはできません。</span><span class="sxs-lookup"><span data-stu-id="47209-148">Your listing may not look good if you don't include it, and won't be consistent with other listings that customers see while browsing the Store.</span></span> <span data-ttu-id="47209-149">この画像は、検索結果や自動編集コレクションでも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="47209-149">This image may also be used in search results or in editorially-curated collections.</span></span>

<span data-ttu-id="47209-150">この画像にはアプリ名を含める必要があり、画像内のテキストは、読みやすさに関するアクセシビリティ要件 (4.5:1 のコントラスト比) を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-150">This image should include your app’s name, and any text on the image should meet accessible readability requirements (4.51 contrast ratio).</span></span> <span data-ttu-id="47209-151">この画像の下部 4 分の 1 にテキスト オーバーレイが表示されることがあるため、テキストやキーの画像を含めないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="47209-151">Note that text overlays may appear on the bottom quarter of this image, so make sure you don't include text or key imagery there.</span></span>

> [!NOTE]
> <span data-ttu-id="47209-152">Xbox のユーザーにアプリを提供している場合、この画像は**必須**であり、製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-152">If your app is available to customers on Xbox, this image is **required** and must include the product's title.</span></span> <span data-ttu-id="47209-153">画像の下部 4 分の 1 にはテキスト オーバーレイが表示されることがあるため、タイトルは画像の上部 4 分の 3 に表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-153">The title must appear in the top three-quarters of the image, since text overlays may appear on the bottom quarter of the image.</span></span>

### <a name="11-box-art-1080-x-1080-or-2160-x-2160-pixels"></a><span data-ttu-id="47209-154">1:1 ボックス アート (1080 x 1080 または 2160 x 2160 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="47209-154">1:1 box art (1080 x 1080 or 2160 x 2160 pixels)</span></span>

<span data-ttu-id="47209-155">この画像は、Windows 10 (Xbox を含む) のさまざまな Microsoft Store に表示される場合があります。**9:16 ポスター アート**画像を用意しない場合、この画像がメイン ロゴとして使用されます。</span><span class="sxs-lookup"><span data-stu-id="47209-155">This image may appear in various Store pages for Windows 10 (including Xbox), and if you don't provide the **9:16 Poster art** image it will be used as your main logo.</span></span> <span data-ttu-id="47209-156">この画像にはアプリの名前も含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-156">This image should also include your app’s name.</span></span> <span data-ttu-id="47209-157">この画像の下部 4 分の 1 にテキスト オーバーレイが表示されることがあるため、テキストやキーの画像を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="47209-157">Text overlays may appear on the bottom quarter of this image, so don't include text or key imagery there.</span></span> <span data-ttu-id="47209-158">必ず、この画像にはアプリの名前を含めてください。</span><span class="sxs-lookup"><span data-stu-id="47209-158">Be sure to include your app’s name in this image.</span></span> 

> [!NOTE]
> <span data-ttu-id="47209-159">Xbox のユーザーにアプリを提供している場合、この画像は**必須**であり、製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-159">If your app is available to customers on Xbox, this image is **required** and must include the product's title.</span></span> <span data-ttu-id="47209-160">画像の下部 4 分の 1 にはテキスト オーバーレイが表示されることがあるため、タイトルは画像の上部 4 分の 3 に表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-160">The title must appear in the top three-quarters of the image, since text overlays may appear on the bottom quarter of the image.</span></span>

### <a name="11-app-tile-icon-300-x-300-pixels"></a><span data-ttu-id="47209-161">1:1 アプリ タイル アイコン (300 x 300 ピクセル)</span><span class="sxs-lookup"><span data-stu-id="47209-161">1:1 App tile icon (300 x 300 pixels)</span></span>

<span data-ttu-id="47209-162">この画像は、Windows Phone 8.1 以前で適切に表示されるために必要です。</span><span class="sxs-lookup"><span data-stu-id="47209-162">This image is required for proper display on Windows Phone 8.1 and earlier.</span></span> <span data-ttu-id="47209-163">以前発行されたアプリは、Windows Phone 8.1 以前をサポートしています。 このイメージを指定しない場合は、顧客には、アプリの一覧に、空白アイコンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="47209-163">If your previously-published app supports Windows Phone 8.1 or earlier, and you don't provide this image, those customers will see a blank icon with your app's listing.</span></span> <span data-ttu-id="47209-164">(これにも当てはまりますお客様は Windows 10 アプリでは、Windows Phone 8.1 またはそれ以前を対象とするパッケージのみがいる場合。)</span><span class="sxs-lookup"><span data-stu-id="47209-164">(This also applies to customers on Windows 10 if your app only has packages targeting Windows Phone 8.1 or earlier.)</span></span>

<span data-ttu-id="47209-165">場合、送信*のみ*UWP のパッケージが含まれていますこのイメージを提供する必要はありません (のボックスをオンにしない限り、 **Windows 10 および Xbox でお客様の場合、パッケージから画像の代わりにアップロードしたロゴのイメージを表示。**、次のセクションで説明)。</span><span class="sxs-lookup"><span data-stu-id="47209-165">If your submission *only* includes UWP packages, you don’t need to provide this image (unless you check the box for  **For customers on Windows 10 and Xbox, display uploaded logo images instead of the images from my packages**, as described in the next section).</span></span>

### <a name="display-only-uploaded-logo-images-in-the-store"></a><span data-ttu-id="47209-166">表示のみストア内のロゴ イメージをアップロード</span><span class="sxs-lookup"><span data-stu-id="47209-166">Display only uploaded logo images in the Store</span></span>

<span data-ttu-id="47209-167">ストアが (Xbox を含む)、Windows 10 でのお客様に、一覧を表示するときに、アプリのパッケージでロゴのイメージを使用するを防ぐを代わりにアップロードするイメージのみを使用して、ストアのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="47209-167">You have the option to prevent the Store from using the logo images in your app's packages when displaying your listing to customers on Windows 10 (including Xbox), and instead have the Store use only images that you upload.</span></span> <span data-ttu-id="47209-168">これにより、Windows 10 (Xbox を含む) ユーザーについては、Microsoft Store のさまざまな画面でのアプリの魅せ方をさらに細かく制御できます。</span><span class="sxs-lookup"><span data-stu-id="47209-168">This gives you more control over your app’s appearance in various displays throughout the Store for customers on Windows 10 (including Xbox).</span></span> <span data-ttu-id="47209-169">(以前に発行アプリでは、以前の OS バージョンをサポートする場合顧客可能性がありますも参照イメージ パッケージから)。</span><span class="sxs-lookup"><span data-stu-id="47209-169">(If your previously-published app supports earlier OS versions, those customers may still see images from your packages.)</span></span>

<span data-ttu-id="47209-170">(顧客の Windows 10 で Xbox を含む) をアップロードするイメージのみを使用し、使用、パッケージからのすべてのイメージ ストアには、チェック ボックスをオン**Windows 10 で Xbox 向けから画像の代わりにアップロードしたロゴのイメージを表示パッケージ**します。</span><span class="sxs-lookup"><span data-stu-id="47209-170">To have the Store use only the images you upload (for customers on Windows 10, including Xbox), and not use any images from your packages, check the box that says **For customers on Windows 10 and Xbox, display uploaded logo images instead of the images from my packages**.</span></span>

<span data-ttu-id="47209-171">このボックスをオンにすると、新しいセクションと呼ばれる**ストア イメージを表示**が表示されます。</span><span class="sxs-lookup"><span data-stu-id="47209-171">When you check this box, a new section called **Store display images** appears.</span></span> <span data-ttu-id="47209-172">ここを含む、3 つのイメージをアップロードすることができます、 **1 対 1 のアプリ タイル アイコン (300 x 300 ピクセル)** サイズ (、ボックスをオンにする場合は、そのイメージを提供するフィールドはこのをセクションに移動) します。</span><span class="sxs-lookup"><span data-stu-id="47209-172">Here, you can upload 3 images, including the **1:1 app tile icon (300 x 300 pixels)** size (if you check the box, the field to provide that image will move into this section).</span></span> <span data-ttu-id="47209-173">このオプションを使用する場合は、すべての 3 つのイメージ サイズを提供することをお勧めします。300 x 300、150 x 150、および 71 x 71 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="47209-173">We recommend providing all three image sizes if you use this option: 300 x 300, 150 x 150, and 71 x 71 pixels.</span></span> <span data-ttu-id="47209-174">ただし、必須のサイズは 300 x 300 だけです。</span><span class="sxs-lookup"><span data-stu-id="47209-174">However, only the 300 x 300 size is required.</span></span>


<span id="promotional-images" />

## <a name="trailers-and-additional-assets"></a><span data-ttu-id="47209-175">トレーラーと資産の追加</span><span class="sxs-lookup"><span data-stu-id="47209-175">Trailers and additional assets</span></span>

<span data-ttu-id="47209-176">このセクションでは、Microsoft Store で製品をより効果的に表示するために役立つアートワークを指定できます。</span><span class="sxs-lookup"><span data-stu-id="47209-176">This section lets you provide artwork to help display your product more effectively in the Store.</span></span> <span data-ttu-id="47209-177">より魅力的なストア登録情報を制作するため、これらの画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47209-177">We recommend providing these images to create a more inviting Store listing.</span></span>

> [!TIP]
> <span data-ttu-id="47209-178">[16:9 のスーパー ヒーロー アート](#windows-10-and-xbox-image-169-super-hero-art)イメージが追加する予定の場合に特にお勧めします[ビデオ トレーラー](#trailers)ストアをリストします。 追加しない場合、リストの上部にある、トレーラーは表示されません。</span><span class="sxs-lookup"><span data-stu-id="47209-178">The [16:9 Super hero art](#windows-10-and-xbox-image-169-super-hero-art) image is especially recommended if you plan to include [video trailers](#trailers) in your Store listing; if you don't include it, your trailers won't appear at the top of your listing.</span></span>


### <a name="trailers"></a><span data-ttu-id="47209-179">トレーラー</span><span class="sxs-lookup"><span data-stu-id="47209-179">Trailers</span></span>

<span data-ttu-id="47209-180">トレーラーは、製品がどのようなものかを知ってもらうために、製品の動作をユーザーに紹介する短いビデオです。</span><span class="sxs-lookup"><span data-stu-id="47209-180">Trailers are short videos that give customers a way to see your product in action, so they can get a better understanding of what it’s like.</span></span> <span data-ttu-id="47209-181">アプリのストアの一覧の上部に表示されます (含める限り、 [16:9 のスーパー ヒーロー アート](#windows-10-and-xbox-image-169-super-hero-art)イメージ)。</span><span class="sxs-lookup"><span data-stu-id="47209-181">They are shown at the top of your app's Store listing (as long as you include a [16:9 Super hero art](#windows-10-and-xbox-image-169-super-hero-art) image).</span></span> 

<span data-ttu-id="47209-182">トレーラーは[スムーズ ストリーミング](https://www.iis.net/downloads/microsoft/smooth-streaming)でエンコードされ、クライアントに配信されるビデオ ストリームの品質は、利用可能な帯域幅と CPU リソースに基づいて調整されます。</span><span class="sxs-lookup"><span data-stu-id="47209-182">Trailers are encoded with [Smooth Streaming](https://www.iis.net/downloads/microsoft/smooth-streaming), which adapts the quality of a video stream delivered to clients in real time based on their available bandwidth and CPU resources.</span></span>

> [!NOTE]
> <span data-ttu-id="47209-183">トレーラーは、Windows 10 バージョン 1607 以降 (Xbox を含む) のユーザーにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="47209-183">Trailers are only shown to customers on Windows 10, version 1607 or later (which includes Xbox).</span></span>

### <a name="upload-trailers"></a><span data-ttu-id="47209-184">トレーラーのアップロード</span><span class="sxs-lookup"><span data-stu-id="47209-184">Upload trailers</span></span>

<span data-ttu-id="47209-185">ストア登録情報には、最大 15 個のトレーラーを追加できます。</span><span class="sxs-lookup"><span data-stu-id="47209-185">You can add up to 15 trailers to your Store listing.</span></span> <span data-ttu-id="47209-186">各トレーラーが以下に示す[要件](#trailer-requirements)のすべてを満たしていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="47209-186">Be sure they meet all of the [requirements](#trailer-requirements) listed below.</span></span>

<span data-ttu-id="47209-187">提供するトレーラーごとに、ビデオ ファイル (.mp4 または .mov)、サムネイル画像、タイトルをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-187">For each trailer you provide, you must upload a video file (.mp4 or .mov), a thumbnail image, and a title.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="47209-188">指定する必要があるトレーラーを使用する場合、 [16:9 のスーパー ヒーロー アート](#windows-10-and-xbox-image-169-super-hero-art)トレーラー、ストアの上部にある一覧に表示するためにセクションの図します。</span><span class="sxs-lookup"><span data-stu-id="47209-188">When using trailers, you must also provide a [16:9 Super hero art](#windows-10-and-xbox-image-169-super-hero-art) image section in order for your trailers to appear at the top of your Store listing.</span></span> <span data-ttu-id="47209-189">この画像は、トレーラーの再生後に表示されます。</span><span class="sxs-lookup"><span data-stu-id="47209-189">This image will appear after your trailers have finished playing.</span></span>

<span data-ttu-id="47209-190">効果的なトレーラーを作成するには、次の推奨事項に従ってください。</span><span class="sxs-lookup"><span data-stu-id="47209-190">Follow these recommendations to make your trailers effective:</span></span>
- <span data-ttu-id="47209-191">トレーラーは、高品質で最小限の長さ (60 秒以内および 2 GB 未満を推奨) にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-191">Trailers should be of good quality and minimal length (60 seconds or less and less than 2 GB recommended).</span></span> 
- <span data-ttu-id="47209-192">各トレーラーが別々の内容であることがユーザーにわかるように、トレーラーごとに異なるサムネイルを使ってください。</span><span class="sxs-lookup"><span data-stu-id="47209-192">Use a different thumbnail for each trailer so that customers know they are unique.</span></span>
- <span data-ttu-id="47209-193">一部の Store レイアウトではトレーラーの上下がわずかにトリミングされる可能性があるため、重要な情報は画面の中央に表示されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="47209-193">Because some Store layouts may slightly crop the top and bottom of your trailer, make sure key info appears in the center of the screen.</span></span>
- <span data-ttu-id="47209-194">フレーム レートと解像度は、ソース マテリアルと一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-194">Frame rate and resolution should match the source material.</span></span> <span data-ttu-id="47209-195">たとえば、720p60 で撮影されたコンテンツは、720p60 でエンコードしてアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-195">For example, content shot at 720p60 should be encoded and uploaded at 720p60.</span></span> 

<span data-ttu-id="47209-196">次に示す要件にも従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-196">You must also follow the requirements listed below.</span></span>

<span data-ttu-id="47209-197">**トレーラーをリストに追加します。**</span><span class="sxs-lookup"><span data-stu-id="47209-197">**To add trailers to your listing:**</span></span>
1. <span data-ttu-id="47209-198">指定されたボックスにトレーラーの**ビデオ ファイル**をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="47209-198">Upload your trailer **video file** in the indicated box.</span></span> <span data-ttu-id="47209-199">既にアップロードしたトレーラーを再利用する場合のために (別の言語のストア登録情報を作成する場合など)、ドロップダウン ボックスも表示されます。</span><span class="sxs-lookup"><span data-stu-id="47209-199">A drop-down box is also shown in case you want to reuse a trailer you have alread uploaded (perhaps for a Store listing in a different language).</span></span>
2. <span data-ttu-id="47209-200">トレーラーをアップロードしたら、対応する**サムネイル画像**をアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-200">After you have uploaded the trailer, you'll need to upload a **thumbnail image** to go along with it.</span></span> <span data-ttu-id="47209-201">これは 1920 x 1080 ピクセルの .png ファイルにする必要があり、通常はトレーラーから取得した静止画像を使います。</span><span class="sxs-lookup"><span data-stu-id="47209-201">This must be a .png file that is 1920 x 1080 pixels, and is typically a still image taken from the trailer.</span></span>
3. <span data-ttu-id="47209-202">鉛筆アイコンをクリックして**タイトル**を追加します (255 文字以内)。</span><span class="sxs-lookup"><span data-stu-id="47209-202">Click the pencil icon to add a **title** for your trailer (255 characters or fewer).</span></span>
4. <span data-ttu-id="47209-203">登録情報にさらにトレーラーを追加する場合は、**[トレーラーの追加]** をクリックし、上の手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="47209-203">If you want to add more trailers to the listing, click **Add trailer** and repeat the steps listed above.</span></span>

> [!TIP]
> <span data-ttu-id="47209-204">複数の言語で Store 登録情報を作成した場合は、**[既存のトレーラーから選択]** を選択して、既にアップロードしたトレーラーを再利用できます。</span><span class="sxs-lookup"><span data-stu-id="47209-204">If you have created Store listings in multiple languages, you can select **Choose from existing trailers** to reuse the trailers you've already uploaded.</span></span> <span data-ttu-id="47209-205">言語ごとに個別にアップロードする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="47209-205">You don't have to upload them individually for each language.</span></span>

<span data-ttu-id="47209-206">登録情報からトレーラーを削除するには、ファイル名の横にある **[X]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="47209-206">To remove a trailer from a listing, click the **X** next to its file name.</span></span> <span data-ttu-id="47209-207">これには、次の操作は、現在ストア一覧のみから削除する、またはすべての (すべての言語) で、製品のストアの一覧から削除するかどうかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="47209-207">You can choose whether to remove it from only the current Store listing in which you are working, or to remove it from all of your product's Store listings (in every language).</span></span>


### <a name="trailer-requirements"></a><span data-ttu-id="47209-208">トレーラーの要件</span><span class="sxs-lookup"><span data-stu-id="47209-208">Trailer requirements</span></span>

<span data-ttu-id="47209-209">トレーラーを提供する場合は、次の要件に従ってください。</span><span class="sxs-lookup"><span data-stu-id="47209-209">When providing your trailers, be sure to follow these requirements:</span></span>

- <span data-ttu-id="47209-210">ビデオ形式は MOV または MP4 にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-210">The video format must be MOV or MP4.</span></span> 
- <span data-ttu-id="47209-211">ビデオの再生時間は 60 秒以下にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-211">The video duration shouldn't exceed 60 seconds.</span></span>
- <span data-ttu-id="47209-212">トレーラーのサイズは 2 GB 以下にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-212">The file size of the trailer shouldn't exceed 2 GB.</span></span> 
- <span data-ttu-id="47209-213">ビデオの解像度は、1920 × 1080 ピクセルまたは 3840 x 2160 ピクセルのいずれかである必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-213">The video resolution must be either 1920 x 1080 pixels or 3840 x 2160 pixels.</span></span>
- <span data-ttu-id="47209-214">サムネイルは、1920 x 1080 ピクセルまたは 3840 x 2160 ピクセルの解像度の PNG ファイルにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-214">The thumbnail must be a PNG file with a resolution of either 1920 x 1080 pixels or 3840 x 2160 pixels.</span></span>
- <span data-ttu-id="47209-215">タイトルを 255 文字より長くすることはできません。</span><span class="sxs-lookup"><span data-stu-id="47209-215">The title can’t exceed 255 characters.</span></span> 
- <span data-ttu-id="47209-216">トレーラーに年齢区分は含めないでください。</span><span class="sxs-lookup"><span data-stu-id="47209-216">Do not include age ratings in your trailers.</span></span>

<span data-ttu-id="47209-217">Store 登録情報ページの他のフィールドと同様に、トレーラーを Microsoft Store に公開するには、その前に認定に合格する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-217">Like the other fields on the Store listing page, trailers must pass certification before you can publish them to the Microsoft Store.</span></span> <span data-ttu-id="47209-218">トレーラーが [Microsoft Storeポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)に準拠していることを確認してください。 </span><span class="sxs-lookup"><span data-stu-id="47209-218">Be sure your trailers comply with the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span>

<span data-ttu-id="47209-219">ファイルの種類に応じて追加の要件があります。</span><span class="sxs-lookup"><span data-stu-id="47209-219">There are additional requirements depending on the type of file.</span></span>

#### <a name="mov"></a><span data-ttu-id="47209-220">MOV</span><span class="sxs-lookup"><span data-stu-id="47209-220">MOV</span></span>

<table>
<tr>
<td>

<span data-ttu-id="47209-221">**ビデオ:**</span><span class="sxs-lookup"><span data-stu-id="47209-221">**Video:**</span></span>

<ul>
<li><span data-ttu-id="47209-222">1080p ProRes (適切な場合は HQ)</span><span class="sxs-lookup"><span data-stu-id="47209-222">1080p ProRes (HQ where appropriate)</span></span></li>
<li><span data-ttu-id="47209-223">ネイティブ フレーム レート (29.97 FPS を推奨)</span><span class="sxs-lookup"><span data-stu-id="47209-223">Native framerate; 29.97 FPS preferred</span></span></li>
</ul>
</td>
<td>

<span data-ttu-id="47209-224">**オーディオ:**</span><span class="sxs-lookup"><span data-stu-id="47209-224">**Audio:**</span></span>

<ul>
<li><span data-ttu-id="47209-225">ステレオが必須</span><span class="sxs-lookup"><span data-stu-id="47209-225">Stereo required</span></span></li>
<li><span data-ttu-id="47209-226">推奨オーディオ レベル: -16 LKFS/LUFS</span><span class="sxs-lookup"><span data-stu-id="47209-226">Recommended Audio Level: -16 LKFS/LUFS</span></span></li>
</ul> 
</td>
</tr>
</table>

#### <a name="mp4"></a><span data-ttu-id="47209-227">MP4</span><span class="sxs-lookup"><span data-stu-id="47209-227">MP4</span></span>

<table>
<tr>
<td>

<span data-ttu-id="47209-228">**ビデオ:**</span><span class="sxs-lookup"><span data-stu-id="47209-228">**Video:**</span></span>

<ul>
<li><span data-ttu-id="47209-229">コーデック:H.264</span><span class="sxs-lookup"><span data-stu-id="47209-229">Codec: H.264</span></span></li>
<li><span data-ttu-id="47209-230">プログレッシブ スキャン (インターレースなし)</span><span class="sxs-lookup"><span data-stu-id="47209-230">Progressive scan (no interlacing)</span></span></li>
<li><span data-ttu-id="47209-231">ハイ プロファイル</span><span class="sxs-lookup"><span data-stu-id="47209-231">High Profile</span></span></li>
<li><span data-ttu-id="47209-232">2 連続 B フレーム</span><span class="sxs-lookup"><span data-stu-id="47209-232">2 consecutive B frames</span></span></li>
<li><span data-ttu-id="47209-233">クローズド GOP </span><span class="sxs-lookup"><span data-stu-id="47209-233">Closed GOP.</span></span> <span data-ttu-id="47209-234">(フレーム レートの半分の GOP)</span><span class="sxs-lookup"><span data-stu-id="47209-234">GOP of half the frame rate</span></span></li>
<li><span data-ttu-id="47209-235">CABAC</span><span class="sxs-lookup"><span data-stu-id="47209-235">CABAC</span></span></li>
<li><span data-ttu-id="47209-236">50 MB/秒</span><span class="sxs-lookup"><span data-stu-id="47209-236">50 MB/s</span></span> </li>
<li><span data-ttu-id="47209-237">色空間:4.2.0</span><span class="sxs-lookup"><span data-stu-id="47209-237">Color Space: 4.2.0</span></span></li>
</ul>
</td>
<td>

<span data-ttu-id="47209-238">**オーディオ:**</span><span class="sxs-lookup"><span data-stu-id="47209-238">**Audio:**</span></span>

<ul>
<li><span data-ttu-id="47209-239">コーデック:AAC-LC</span><span class="sxs-lookup"><span data-stu-id="47209-239">Codec: AAC-LC</span></span></li>
<li><span data-ttu-id="47209-240">チャネル:ステレオまたはサラウンド サウンド</span><span class="sxs-lookup"><span data-stu-id="47209-240">Channels: Stereo or surround sound</span></span></li>
<li><span data-ttu-id="47209-241">サンプル レート:48 KHz</span><span class="sxs-lookup"><span data-stu-id="47209-241">Sample rate: 48 KHz</span></span></li>
<li><span data-ttu-id="47209-242">オーディオ ビットレート。ステレオ用 384 KB/秒、サラウンド サウンドで 512 KB/秒</span><span class="sxs-lookup"><span data-stu-id="47209-242">Audio Bitrate: 384 KB/s for Stereo, 512 KB/s for surround sound</span></span></li>
</ul>
</td>
</tr>
</table>

<span data-ttu-id="47209-243">H.264 メザニン ファイルでは、次の形式が推奨されます。</span><span class="sxs-lookup"><span data-stu-id="47209-243">For H.264 Mezzanine files, we recommend the following:</span></span>
- <span data-ttu-id="47209-244">コンテナ:MP4</span><span class="sxs-lookup"><span data-stu-id="47209-244">Container: MP4</span></span>
- <span data-ttu-id="47209-245">編集リストなし (そうでない場合、AV の同期が失われることがあります)</span><span class="sxs-lookup"><span data-stu-id="47209-245">No Edit Lists (or you might lose AV sync)</span></span>
- <span data-ttu-id="47209-246">ファイルの先頭に moov アトムを配置 (ファスト スタート)</span><span class="sxs-lookup"><span data-stu-id="47209-246">moov atom at the front of the file (Fast Start)</span></span>

### <a name="windows-10-and-xbox-image-169-super-hero-art"></a><span data-ttu-id="47209-247">Windows 10 と Xbox の画像 (16:9 スーパー ヒーロー アート)</span><span class="sxs-lookup"><span data-stu-id="47209-247">Windows 10 and Xbox image (16:9 Super hero art)</span></span>

<span data-ttu-id="47209-248">**イメージを Windows 10 および Xbox**  セクションで、 **16:9 のスーパー ヒーロー アート (1920 x 1080 または 3840 x 2,160 ピクセル)** イメージ (Xbox を含む) すべての Windows 10 デバイスの種類の Microsoft Store でのさまざまなレイアウトで使用します。</span><span class="sxs-lookup"><span data-stu-id="47209-248">In the **Windows 10 and Xbox image** section, the **16:9 Super hero art (1920 x 1080 or 3840 x 2160 pixels)** image is used in various layouts in the Microsoft Store on all Windows 10 device types (including Xbox).</span></span> <span data-ttu-id="47209-249">アプリがターゲットとしている OS バージョンやデバイスの種類が何であっても、この画像を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47209-249">We recommend providing this image, regardless of which OS versions or device types your app targets.</span></span>

<span data-ttu-id="47209-250">この画像は、登録情報に[ビデオ トレーラー](#trailers)が含まれる場合、適切に表示するためには*必須*です。</span><span class="sxs-lookup"><span data-stu-id="47209-250">This image is *required* for proper display if your listing includes [video trailers](#trailers).</span></span> <span data-ttu-id="47209-251">この画像は、Windows 10 Version 1607 以降 (Xbox を含む) のユーザーに対しては、Store 登録情報の最上部のメイン画像として使われます (またはトレーラーの再生後に表示されます)。</span><span class="sxs-lookup"><span data-stu-id="47209-251">For customers on Windows 10, version 1607 or later (which includes Xbox), it is used as the main image on the top of your Store listing (or appears after any trailers finish playing).</span></span> <span data-ttu-id="47209-252">Microsoft Store 全体でプロモーション用のレイアウトによってアプリを紹介するために使われることもあります。</span><span class="sxs-lookup"><span data-stu-id="47209-252">It may also be used to feature your app in promotional layouts throughout the Store.</span></span> <span data-ttu-id="47209-253">この画像には、製品のタイトルやそ他のテキストを含めることはできない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="47209-253">Note that this image must not include the product's title or other text.</span></span>

<span data-ttu-id="47209-254">この画像をデザインするときに念頭に置く必要のあるヒントを次に示します。</span><span class="sxs-lookup"><span data-stu-id="47209-254">Here are some tips to keep in mind when designing this image:</span></span>

- <span data-ttu-id="47209-255">画像は、1920 × 1080 ピクセルまたは 3840 x 2160 ピクセルの .png である必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-255">The image must be a .png that is either 1920 x 1080 pixels or 3840 x 2160 pixels.</span></span>
- <span data-ttu-id="47209-256">アプリに関連があり、アプリの認識と差別化を促す動的な画像を選びます。</span><span class="sxs-lookup"><span data-stu-id="47209-256">Select a dynamic image that relates to the app to drive recognition and differentiation.</span></span> <span data-ttu-id="47209-257">ありきたりの写真や一般的な視覚効果は使わないようにします。</span><span class="sxs-lookup"><span data-stu-id="47209-257">Avoid stock photography or generic visuals.</span></span>
- <span data-ttu-id="47209-258">画像にはテキストを含めないでください。</span><span class="sxs-lookup"><span data-stu-id="47209-258">Don't include text in the image.</span></span>
- <span data-ttu-id="47209-259">下部の 3 分の 1 には主要な視覚要素を配置しないでください (レイアウトによってはその比率で徐々に適用される可能性があるため)。</span><span class="sxs-lookup"><span data-stu-id="47209-259">Avoid placing key visual elements in the bottom third of the image (since in some layouts we may apply a gradient over that portion).</span></span>
- <span data-ttu-id="47209-260">最も重要な詳細は画像の中央に配置してください (レイアウトによっては画像がトリミングされる可能性があるため)。</span><span class="sxs-lookup"><span data-stu-id="47209-260">Place the most important details in the center of the image (since in some layouts we may crop the image).</span></span>
- <span data-ttu-id="47209-261">空白領域は最小限に抑えてください。</span><span class="sxs-lookup"><span data-stu-id="47209-261">Minimize empty space.</span></span>
- <span data-ttu-id="47209-262">アプリの UI の表示やデバイスに固有の画像の使用は避けます。</span><span class="sxs-lookup"><span data-stu-id="47209-262">Avoid showing your app's UI, and do not use any device-specific imagery.</span></span>
- <span data-ttu-id="47209-263">政治的および国家的なテーマ、旗、または宗教的なシンボルを避けます。</span><span class="sxs-lookup"><span data-stu-id="47209-263">Avoid political and national themes, flags, or religious symbols.</span></span>
- <span data-ttu-id="47209-264">無神経なジェスチャ、ヌード、ギャンブル、通貨、麻薬、タバコ、またはアルコールの画像を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="47209-264">Don't include images of insensitive gestures, nudity, gambling, currency, drugs, tobacco, or alcohol.</span></span>
- <span data-ttu-id="47209-265">閲覧者に向けた武器や過剰な暴力や流血の画像を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="47209-265">Don't use weapons pointing at the viewer or excessive violence and gore.</span></span>

<span data-ttu-id="47209-266">この画像を提供すると、アプリのプロモーションの機会があった場合に検討対象となりますが、アプリが取り上げられると保証されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="47209-266">While providing this image allows us to consider your app for featured promotional opportunities, it does not guarantee that your app will be featured.</span></span> <span data-ttu-id="47209-267">詳しくは、「[アプリの販売促進を容易にする方法](make-your-app-easier-to-promote.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="47209-267">See [Making your app easy to promote](make-your-app-easier-to-promote.md) for more information.</span></span>


### <a name="xbox-images"></a><span data-ttu-id="47209-268">Xbox 画像</span><span class="sxs-lookup"><span data-stu-id="47209-268">Xbox images</span></span>

<span data-ttu-id="47209-269">これらの画像は、アプリを Xbox に公開する場合に、適切な表示のために必要です。</span><span class="sxs-lookup"><span data-stu-id="47209-269">These images are required for proper display if you publish your app to Xbox.</span></span> 

<span data-ttu-id="47209-270">アップロードできるサイズには次の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="47209-270">There are 3 different sizes that you can upload:</span></span>
- <span data-ttu-id="47209-271">**キーのアート、584 × 800 ピクセルのブランド**:製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-271">**Branded key art, 584 x 800 pixels**: Must include the product’s title.</span></span> <span data-ttu-id="47209-272">この画像にはブランド バーが必要です。</span><span class="sxs-lookup"><span data-stu-id="47209-272">A Branding Bar is required on this image.</span></span> <span data-ttu-id="47209-273">画像の下部 4 分の 1 にはオーバーレイが表示されることがあるため、タイトルとすべてのキーの画像を上部 4 分の 3 にとどめてください。</span><span class="sxs-lookup"><span data-stu-id="47209-273">Keep the title and all key imagery in the top three-quarters of the image, as an overlay may appear over the bottom quarter.</span></span>
- <span data-ttu-id="47209-274">**「Hero アート、1920 x 1080 ピクセル**:製品のタイトルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-274">**Titled hero art, 1920 x 1080 pixels**: Must include the product’s title.</span></span> <span data-ttu-id="47209-275">画像の下部 4 分の 1 にはオーバーレイが表示されることがあるため、タイトルとすべてのキーの画像を上部 4 分の 3 にとどめてください。</span><span class="sxs-lookup"><span data-stu-id="47209-275">Keep the title and all key imagery in the top three-quarters of the image, as an overlay may appear over the bottom quarter.</span></span>
- <span data-ttu-id="47209-276">**プロモーションの正方形のアート、1080 x 1080 ピクセルの機能を備えた**:必要があります*いない*製品のタイトルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="47209-276">**Featured Promotional Square art, 1080 x 1080 pixels**: Must *not* include the product’s title.</span></span>

> [!NOTE]
> <span data-ttu-id="47209-277">Xbox でできるだけ魅力的な表示にするには、[ストア ロゴ](#store-logos)のセクションで **9:16 (720 x 1080 または 1440 x 2160 ピクセル)** の画像も提供してください。</span><span class="sxs-lookup"><span data-stu-id="47209-277">For the best display on Xbox, you must also provide a **9:16 (720 x 1080 or 1440 x 2160 pixels)** image in the [Store logos](#store-logos) section.</span></span>


### <a name="holographic-image"></a><span data-ttu-id="47209-278">ホログラフィックの画像</span><span class="sxs-lookup"><span data-stu-id="47209-278">Holographic image</span></span>

<span data-ttu-id="47209-279">**2:1 (2400 x 1200)** の画像は、アプリが Holographic デバイス ファミリをサポートする場合にのみ、使われます。</span><span class="sxs-lookup"><span data-stu-id="47209-279">The **2:1 (2400 x 1200)** image is only used if your app supports the Holographic device family.</span></span> <span data-ttu-id="47209-280">その場合、この画像を用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47209-280">If it does, we recommend providing this image.</span></span>


<span id="optional-promotional-images" />

### <a name="images-only-for-windows-8x-andor-windows-phone-8x"></a><span data-ttu-id="47209-281">Windows 8.x や Windows Phone 8.x 専用の画像</span><span class="sxs-lookup"><span data-stu-id="47209-281">Images only for Windows 8.x and/or Windows Phone 8.x</span></span> 

<span data-ttu-id="47209-282">以前から送信されたアプリは、以前の OS バージョンをサポートしている場合 (Windows 8.x および Windows Phone 8.x)、キャンペーンのレイアウトでアプリを際立た (ただし、アプリの機能を備えたがあることを保証はありません) を考慮するためにはこれらのイメージを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47209-282">If your previously-submitted app supports earlier OS versions (Windows 8.x and/or Windows Phone 8.x), these images must be provided in order for us to consider featuring your app in promotional layouts (though they don't guarantee that your app will be featured).</span></span> <span data-ttu-id="47209-283">アプリが以前の OS バージョンをサポートしていない場合は、このセクションをスキップします。</span><span class="sxs-lookup"><span data-stu-id="47209-283">If your app does not support these earlier OS versions, skip this section.</span></span> <span data-ttu-id="47209-284">(このセクションは、以前は「**オプションのプロモーション用の画像**」と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="47209-284">(This section was formerly called **Optional promotional images**.)</span></span>

<span data-ttu-id="47209-285">**Windows Phone 8.1**、2 つのイメージ サイズは、キャンペーンのレイアウトで使用できます。**1000 × 800 ピクセル (5:4)** と**358 x 358 ピクセル (1:1)** します。</span><span class="sxs-lookup"><span data-stu-id="47209-285">**For Windows Phone 8.1 and earlier**, two image sizes can be used in promotional layouts: **1000 x 800 pixels (5:4)** and **358 x 358 pixels (1:1)**.</span></span> <span data-ttu-id="47209-286">アプリでは、Windows Phone 8.1 またはそれ以前を実行する場合は、これらのサイズの両方でイメージを提供するをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47209-286">If your app runs on Windows Phone 8.1 or earlier, we recommend providing images in both of these sizes.</span></span>  

> [!TIP]
> <span data-ttu-id="47209-287">Windows Phone 8.1 以前をサポートする申請では、忘れずに [[ストア ロゴ]](#store-logos) セクションで 300 x 300 のアプリ タイル アイコン画像を提供してください。</span><span class="sxs-lookup"><span data-stu-id="47209-287">Be sure to provide a 300 x 300 app tile icon image in the [Store logos](#store-logos) section for any submission that supports Windows Phone 8.1 or earlier.</span></span> <span data-ttu-id="47209-288">これにより、ストアでアプリが空白のアイコンで表示されるのを防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="47209-288">This will ensure that your app does not appear in the Store with a blank icon.</span></span>  

<span data-ttu-id="47209-289">**Windows 8.1 以前**では、いくつかのプロモーション用のレイアウトで **414 x 180** ピクセルのサイズが使われることがあります。</span><span class="sxs-lookup"><span data-stu-id="47209-289">**For Windows 8.1 and earlier**, some promotional layouts may use an image in the **414 x 180** pixel size.</span></span> <span data-ttu-id="47209-290">アプリでは、Windows 8.1 またはそれ以前を実行する場合は、この sizen 内のイメージを提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="47209-290">If your app runs on Windows 8.1 or earlier, we recommend providing an image in this sizen.</span></span>




