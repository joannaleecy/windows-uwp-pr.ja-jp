---
author: jnHs
Description: The Store listings section of the app submission process is where you provide the text and images that customers will see when viewing your app's listing in the Microsoft Store.
title: アプリの Microsoft Store 登録情報の作成
ms.assetid: 50D67219-B6C6-4EF0-B76A-926A5F24997D
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, 登録情報, 説明, Microsoft Store ページ, リリース ノート, タイトル
ms.localizationpriority: medium
ms.openlocfilehash: ec1867e747f3458e3a9cffabe9a45535d4c27489
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7570122"
---
# <a name="create-app-store-listings"></a><span data-ttu-id="a7698-103">アプリの Microsoft Store 登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="a7698-103">Create app Store listings</span></span>


<span data-ttu-id="a7698-104">[アプリの申請プロセス](app-submissions.md)の **[Store 登録情報]** セクションでは、ユーザーが Microsoft Store でアプリの登録情報を表示したときに表示されるテキストと[画像](app-screenshots-and-images.md)を指定できます。</span><span class="sxs-lookup"><span data-stu-id="a7698-104">The **Store listings** section of the [app submission process](app-submissions.md) is where you provide the text and [images](app-screenshots-and-images.md) that customers will see when viewing your app's listing in the Microsoft Store.</span></span>

<span data-ttu-id="a7698-105">**[Store 登録情報]** のフィールドの多くは省略可能ですが、登録情報が目立つように複数の画像とできるだけ多くの情報を指定することをお勧めします。**[Store 登録情報]** の手順が完成したと見なされるには、説明のテキストと少なくとも 1 つの[スクリーンショット](app-screenshots-and-images.md#screenshots)が必要です。</span><span class="sxs-lookup"><span data-stu-id="a7698-105">Many of the fields in a **Store listing** are optional, but we suggest providing multiple images and as much info as possible to make your listing stand out. The minimum required for the **Store listings** step to be considered complete is a text description and at least one [screenshot](app-screenshots-and-images.md#screenshots).</span></span>

> [!TIP]
> <span data-ttu-id="a7698-106">できます必要に応じて[をインポートおよびエクスポートのストア登録情報](import-and-export-store-listings.md)で情報を提供してパートナー センターで直接ファイルのアップロードではなく、.csv ファイルをオフライン登録情報を入力する場合。</span><span class="sxs-lookup"><span data-stu-id="a7698-106">You can optionally [import and export Store listings](import-and-export-store-listings.md) if you'd prefer to enter your listing info offline in a .csv file, rather than providing info and uploading files directly in Partner Center.</span></span> <span data-ttu-id="a7698-107">インポートおよびエクスポート オプションでは、一度に複数の更新を行うことができるため、多くの言語の登録情報がある場合に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="a7698-107">Using the import and export option can be especially convenient if you have listings in many languages, since it lets you make multiple updates at once.</span></span> 

<span data-ttu-id="a7698-108">以前に公開されたアプリには、Windows がサポートされている場合 8.x や Windows Phone 8.x または以前では、[プラットフォーム固有のストア登録情報の作成](create-platform-specific-store-listings.md)をそれらのユーザーに表示できます。</span><span class="sxs-lookup"><span data-stu-id="a7698-108">If your previously-published app supports Windows 8.x and/or Windows Phone 8.x or earlier, you can [create platform-specific Store listings](create-platform-specific-store-listings.md) to show to those customers.</span></span> 

## <a name="store-listing-languages"></a><span data-ttu-id="a7698-109">ストア登録情報の言語</span><span class="sxs-lookup"><span data-stu-id="a7698-109">Store listing languages</span></span>

<span data-ttu-id="a7698-110">少なくとも 1 つの言語の **[ストア登録情報]** ページを完成させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-110">You must complete the **Store listing** page for at least one language.</span></span> <span data-ttu-id="a7698-111">ストア登録情報は、パッケージでサポートしているすべての言語で提供することをお勧めしますが、ストア登録情報を提供しない言語を削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="a7698-111">We recommend providing a Store listing in each language that your packages support, but you have flexibility to remove languages for which you don’t wish to provide a Store listing.</span></span> <span data-ttu-id="a7698-112">パッケージでサポートしていない言語のストア登録情報を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="a7698-112">You can also create Store listings in additional languages which aren’t supported by your packages.</span></span>

> [!NOTE]
> <span data-ttu-id="a7698-113">申請にパッケージが既に含まれている場合は、パッケージでサポートされている[言語](supported-languages.md)が [申請の概要] ページに表示されます (言語を削除していない場合)。</span><span class="sxs-lookup"><span data-stu-id="a7698-113">If your submission includes packages already, we’ll show the [languages](supported-languages.md) supported in your packages on the submission overview page (unless you remove any of them).</span></span>

<span data-ttu-id="a7698-114">ストア登録情報の言語を追加または削除するには、申請の概要ページで **[言語の追加/削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a7698-114">To add or remove languages for your Store listings, click **Add/remove languages** from the submission overview page.</span></span> <span data-ttu-id="a7698-115">既にパッケージをアップロードしている場合は、**[Languages supported by your packages]** (パッケージでサポートしている言語) セクションに言語が表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-115">If you‘ve already uploaded packages, you’ll see their languages listed in the **Languages supported by your packages** section.</span></span> <span data-ttu-id="a7698-116">これらの言語の 1 つまたは複数を削除するには、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a7698-116">To remove one or more of these languages, click **Remove**.</span></span> <span data-ttu-id="a7698-117">以前にこのセクションから削除した言語を後で含める場合は、**[加算]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a7698-117">If you later decide to include a language that you previously removed from this section, you can click **Add**.</span></span>

<span data-ttu-id="a7698-118">**[ストア登録情報の追加言語]** セクションで、**[追加言語の管理]** をクリックして、パッケージに含まれて*いない*言語を追加するか、パッケージに含めない言語を削除します。</span><span class="sxs-lookup"><span data-stu-id="a7698-118">In the **Additional Store listing languages** section, you can click **Manage additional languages** to add or remove languages that are *not* included in your packages.</span></span> <span data-ttu-id="a7698-119">追加する言語のチェック ボックスをクリックし、**[更新]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a7698-119">Check the boxes for the languages that you’d like to add, then click **Update**.</span></span> <span data-ttu-id="a7698-120">選択した言語が **[ストア登録情報の追加言語]** セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-120">The languages you’ve selected will be displayed in the **Additional Store listing languages** section.</span></span> <span data-ttu-id="a7698-121">1 つまたは複数の言語を削除するには、**[削除]** をクリックします (または、**[追加言語の管理]** をクリックし、削除する言語のチェック ボックスをオフにします)。</span><span class="sxs-lookup"><span data-stu-id="a7698-121">To remove one or more of these languages, click **Remove** (or click **Manage additional languages** and uncheck the box for languages you’d like to remove).</span></span>

<span data-ttu-id="a7698-122">選択が終了したら **[保存]** をクリックして、申請の概要ページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="a7698-122">When you have finished making your selections, click **Save** to return to the submission overview page.</span></span> 

## <a name="add-and-edit-store-listing-info"></a><span data-ttu-id="a7698-123">追加して、ストア登録情報の編集</span><span class="sxs-lookup"><span data-stu-id="a7698-123">Add and edit Store listing info</span></span>

<span data-ttu-id="a7698-124">ストア登録情報を編集するには、申請の概要ページから言語名を選択します。</span><span class="sxs-lookup"><span data-stu-id="a7698-124">To edit a Store listing, select the language name from the submission overview page.</span></span> <span data-ttu-id="a7698-125">ストア登録情報をエクスポートしてオフラインで動作し、すべての登録情報データを一度にインポートを選んだ場合を除く別に、各言語を編集する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-125">You must edit each language separately, unless you choose to export your Store listings and work offline, then import all of the listing data at once.</span></span> <span data-ttu-id="a7698-126">しくみについて詳しくは、次を参照してください。[インポートおよびエクスポートのストア登録情報](import-and-export-store-listings.md)します。</span><span class="sxs-lookup"><span data-stu-id="a7698-126">For more about how that works, see [Import and export Store listings](import-and-export-store-listings.md).</span></span>

<span data-ttu-id="a7698-127">利用可能なフィールドは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a7698-127">The available fields are described below.</span></span>

## <a name="product-name"></a><span data-ttu-id="a7698-128">Product name (製品名)</span><span class="sxs-lookup"><span data-stu-id="a7698-128">Product name</span></span>

<span data-ttu-id="a7698-129">このドロップダウン ボックスでは、(この場合、アプリの 1 つ以上の名前を予約して) ストア登録情報で使用する名前を指定できます。</span><span class="sxs-lookup"><span data-stu-id="a7698-129">This drop-down box lets you specify which name should be used in the Store listing (if you have reserved more than one name for the app).</span></span>

<span data-ttu-id="a7698-130">アップロードしている場合は、ストア登録情報と同じ言語のパッケージの中である、それらのパッケージで使用する名前が選択されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-130">If you have uploaded packages in the same language as the Store listing you're working on, the name used in those packages will be selected.</span></span> <span data-ttu-id="a7698-131">既に公開された後[、アプリの名前を変更](manage-app-names.md#rename-an-app-that-has-already-been-published)する必要がある場合は、新しい名前を使用するパッケージをアップロードした後、新しい申請を作成するときにさまざまな予約名は、ここを選択できます。</span><span class="sxs-lookup"><span data-stu-id="a7698-131">If you need to [rename the app](manage-app-names.md#rename-an-app-that-has-already-been-published) after it's already been published, you can select a different reserved name here when you create a new submission, after you've uploaded packages that use the new name.</span></span>

<span data-ttu-id="a7698-132">言語のパッケージをアップロードしていない場合は、作業中と複数の名前を予約した名前をプルするには、その言語パッケージが関連付けられてがないため、予約済みのアプリ名のいずれかを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-132">If you haven't uploaded packages for the language you're working on, and you've reserved more than one name, you'll need to select one of your reserved app names, since there isn't an associated package in that language from which to pull the name.</span></span>

> [!NOTE]
> <span data-ttu-id="a7698-133">作業している登録情報の言語でストアにのみ選択した**製品名**が適用されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-133">The **Product name** you select only applies to the Store listing in the language you're working in.</span></span> <span data-ttu-id="a7698-134">これは、ユーザーは、アプリをインストールするときに表示される名前には影響しませんその名前は、インストールされるパッケージのマニフェストから取得されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-134">It does not impact the name displayed when a customer installs the app; that name comes from the manifest of the package that gets installed.</span></span> <span data-ttu-id="a7698-135">混乱を避けるためには、各言語のパッケージとストア登録情報が、同じ名前を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a7698-135">To avoid confusion, we recommend that each language's package(s) and Store listing use the same name.</span></span>

## <a name="description"></a><span data-ttu-id="a7698-136">説明</span><span class="sxs-lookup"><span data-stu-id="a7698-136">Description</span></span>

<span data-ttu-id="a7698-137">説明フィールドでは、アプリの内容をユーザーに伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="a7698-137">The description field is where you can tell customers what your app does.</span></span> <span data-ttu-id="a7698-138">このフィールドは必須であり、最大 10,000 文字のプレーンテキストを入力できます。</span><span class="sxs-lookup"><span data-stu-id="a7698-138">This field is required, and will accept up to 10,000 characters of plain text.</span></span>

<span data-ttu-id="a7698-139">説明を目立たせるためのヒントについては、「[人の心をつかむアプリの説明を書く](write-a-great-app-description.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a7698-139">For some tips on making your description stand out, see [Write a great app description](write-a-great-app-description.md).</span></span>

<span id="release-notes" />

## <a name="whats-new-in-this-version"></a><span data-ttu-id="a7698-140">今回のバージョンでの新機能</span><span class="sxs-lookup"><span data-stu-id="a7698-140">What's new in this version</span></span>

<span data-ttu-id="a7698-141">初めてアプリを申請する場合、このフィールドは空白のままにしてください。</span><span class="sxs-lookup"><span data-stu-id="a7698-141">If this is the first time you're submitting your app, leave this field blank.</span></span> <span data-ttu-id="a7698-142">既存のアプリの更新プログラムは、これは、ユーザーが最新のリリースで変更された内容を理解できるようにできます。</span><span class="sxs-lookup"><span data-stu-id="a7698-142">For an update to an existing app, this is where you can let customers know what's changed in the latest release.</span></span> <span data-ttu-id="a7698-143">このフィールドには 1500 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-143">This field has a 1500 character limit.</span></span> <span data-ttu-id="a7698-144">(以前は、このフィールドは **[リリース ノート]** と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="a7698-144">(Previously, this field was called **Release notes**).</span></span>

## <a name="product-features"></a><span data-ttu-id="a7698-145">製品の機能</span><span class="sxs-lookup"><span data-stu-id="a7698-145">Product features</span></span>

<span data-ttu-id="a7698-146">アプリの主な機能の短い概要です。</span><span class="sxs-lookup"><span data-stu-id="a7698-146">These are short summaries of your app's key features.</span></span> <span data-ttu-id="a7698-147">これらは、アプリの Store 登録情報の **[機能]** セクションに、**[説明]** と共に箇条書きの形式で表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-147">They are displayed to the customer as a bulleted list in the **Features** section of your app's Store listing, in addition to the **Description**.</span></span> <span data-ttu-id="a7698-148">機能ごとに、簡潔な 1 文 (200 文字未満) になるようにまとめます。</span><span class="sxs-lookup"><span data-stu-id="a7698-148">Keep these brief, with just a few words (and no more than 200 characters) per feature.</span></span> <span data-ttu-id="a7698-149">最大 20 の機能を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="a7698-149">You may include up to 20 features.</span></span>

> [!NOTE]
> <span data-ttu-id="a7698-150">これらの機能は、独自に行頭文字を追加しないように、Store 登録情報に箇条書きで表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-150">These features will appear bulleted in your Store listing, so don't add your own bullets.</span></span>

## <a name="screenshots"></a><span data-ttu-id="a7698-151">スクリーンショット</span><span class="sxs-lookup"><span data-stu-id="a7698-151">Screenshots</span></span>

<span data-ttu-id="a7698-152">アプリを提出するには、少なくとも 1 つのスクリーンショットが必要です。</span><span class="sxs-lookup"><span data-stu-id="a7698-152">One screenshot is required in order to submit your app.</span></span> <span data-ttu-id="a7698-153">ユーザーが自分が使っている種類のデバイスでアプリがどのように表示されるかをイメージできるように、アプリがサポートするデバイスの種類ごとに少なくとも 4 つのスクリーンショットを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a7698-153">We recommend providing at least four screenshots for each device type that your app supports so that people can see how the app will look on their device type.</span></span>

<span data-ttu-id="a7698-154">詳しくは、「[アプリのスクリーンショットと画像](app-screenshots-and-images.md#screenshots)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a7698-154">For more info, see [App screenshots and images](app-screenshots-and-images.md#screenshots).</span></span>


## <a name="store-logos"></a><span data-ttu-id="a7698-155">ストア ロゴ</span><span class="sxs-lookup"><span data-stu-id="a7698-155">Store logos</span></span> 

<span data-ttu-id="a7698-156">ストア ロゴは、アプリの情報をより適切にユーザーに表示するためにアップロードできるオプションの画像です。</span><span class="sxs-lookup"><span data-stu-id="a7698-156">Store logos are optional images that you can upload to enhance the way your app is displayed to customers.</span></span> <span data-ttu-id="a7698-157">必要に応じて、ここでアップロードした画像を Windows 10 (Xbox を含む) ユーザー向けのアプリの Store 登録情報に使うように指定して、アプリのパッケージからのロゴ画像が Microsoft Store で使われないようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="a7698-157">You can also optionally specify that only images you upload here should be used in your app’s Store listing for customers on Windows 10 (including Xbox), rather than allowing the Store to use logo images from your app’s packages.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a7698-158">アプリが Xbox をサポートしている場合、または Windows Phone 8.1 以前をサポートしている場合、ストアで登録情報が適切に表示されるようにするには、ここで特定の画像を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-158">If your app supports Xbox, or if it supports Windows Phone 8.1 or earlier, you must provide certain images here in order for the listing to appear properly in the Store.</span></span> 

<span data-ttu-id="a7698-159">詳しくは、「[ストア ロゴ](app-screenshots-and-images.md#store-logos)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a7698-159">For more info, see [Store logos](app-screenshots-and-images.md#store-logos).</span></span>


## <a name="trailers-and-additional-assets"></a><span data-ttu-id="a7698-160">トレーラーやその他のアセット</span><span class="sxs-lookup"><span data-stu-id="a7698-160">Trailers and additional assets</span></span>

<span data-ttu-id="a7698-161">ビデオ トレーラーやプロモーション用の画像など、製品の追加の資産を提出することができます。</span><span class="sxs-lookup"><span data-stu-id="a7698-161">You can submit additional assets for your product, including video trailers and promotional images.</span></span> <span data-ttu-id="a7698-162">これらはいずれも省略可能ですが、できるだけ多くの資産のアップロードを検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a7698-162">These are all optional, but we recommend that you consider uploading as many of them as possible.</span></span> <span data-ttu-id="a7698-163">これらの画像は、より魅力的な登録情報を作成し、製品がどのようなものかをユーザーに知ってもらうために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a7698-163">These images can help give customers a better idea of what your product is and make a more enticing listing.</span></span>

<span data-ttu-id="a7698-164">詳しくは、[トレーラーやその他のアセット](app-screenshots-and-images.md#trailers-and-additional-assets)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a7698-164">For more info, see [Trailers and additional assets](app-screenshots-and-images.md#trailers-and-additional-assets).</span></span>

<a id="supplemental-information" />

## <a name="supplemental-fields"></a><span data-ttu-id="a7698-165">補足的なフィールド</span><span class="sxs-lookup"><span data-stu-id="a7698-165">Supplemental fields</span></span>

<span data-ttu-id="a7698-166">このセクションのフィールドはすべてオプションです。</span><span class="sxs-lookup"><span data-stu-id="a7698-166">The fields in this section are all optional.</span></span> <span data-ttu-id="a7698-167">以下の情報を確認し、申請でこの情報を提供する意味があるかどうかを判断してください。</span><span class="sxs-lookup"><span data-stu-id="a7698-167">Review the info below to determine if providing this info makes sense for your submission.</span></span> <span data-ttu-id="a7698-168">特に、ほとんどの申請では**簡単な説明**をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a7698-168">In particular, the **Short description** is recommended for most submissions.</span></span> <span data-ttu-id="a7698-169">他のフィールドは、さまざまなシナリオで製品の最適なエクスペリエンスを実現するのに役立つ場合があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-169">The other fields may help provide an optimal experience for your product in different scenarios.</span></span>

### <a name="short-title"></a><span data-ttu-id="a7698-170">短いタイトル</span><span class="sxs-lookup"><span data-stu-id="a7698-170">Short title</span></span>

<span data-ttu-id="a7698-171">製品の名前の短いバージョン。</span><span class="sxs-lookup"><span data-stu-id="a7698-171">A shorter version of your product’s name.</span></span> <span data-ttu-id="a7698-172">指定した場合、Xbox One のさまざまな場所 (インストール時や [実績] など) で製品のフル タイトルの代わりにこの短い名前が表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="a7698-172">If provided, this shorter name may appear in various places on Xbox One (during installation, in Achievements, etc.) in place of the full title of your product.</span></span>

<span data-ttu-id="a7698-173">このフィールドには 50 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-173">This field has a 50 character limit.</span></span>


### <a name="sort-title"></a><span data-ttu-id="a7698-174">ソート タイトル</span><span class="sxs-lookup"><span data-stu-id="a7698-174">Sort title</span></span>

<span data-ttu-id="a7698-175">製品のアルファベット表記やスペルが複数ある場合、ここに別のバージョンを入力できます。</span><span class="sxs-lookup"><span data-stu-id="a7698-175">If your product could be alphabetized or spelled in different ways, you can enter another version here.</span></span> <span data-ttu-id="a7698-176">これにより、ユーザーが検索時にそのバージョンを入力した場合に製品をすばやく見つけることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="a7698-176">This allows customers to find your product more quickly if they type that version in while searching.</span></span> 

<span data-ttu-id="a7698-177">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-177">This field has a 255 character limit.</span></span>


### <a name="voice-title"></a><span data-ttu-id="a7698-178">音声タイトル</span><span class="sxs-lookup"><span data-stu-id="a7698-178">Voice title</span></span>

<span data-ttu-id="a7698-179">Kinect やヘッドセットを使うときに Xbox One のオーディオ エクスペリエンスで使われる、製品の代替名 (ある場合)。</span><span class="sxs-lookup"><span data-stu-id="a7698-179">An alternate name for your product that, if provided, may be used in the audio experience on Xbox One when using Kinect or a headset.</span></span>

<span data-ttu-id="a7698-180">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-180">This field has a 255 character limit.</span></span>


### <a name="short-description"></a><span data-ttu-id="a7698-181">簡単な説明</span><span class="sxs-lookup"><span data-stu-id="a7698-181">Short description</span></span>

<span data-ttu-id="a7698-182">製品の Store 登録情報の先頭に使うことができる短くてわかりやすい説明です。</span><span class="sxs-lookup"><span data-stu-id="a7698-182">A shorter, catchy description that may be used in the top of your product’s Store listing.</span></span> <span data-ttu-id="a7698-183">指定しない場合、長い[説明](#description)の最初の段落 (最大 500 の文字) が代わりに説明されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-183">If not provided, the first paragraph (up to 500 characters) of your longer [description](#description) will be used instead.</span></span> <span data-ttu-id="a7698-184">説明はこのテキストの下にも表示されるため、Store 登録情報が繰り返されないように内容が異なる簡単な説明を指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a7698-184">Because your description also appears below this text, we recommend providing a short description with different text so that your Store listing isn’t repetitive.</span></span>

<span data-ttu-id="a7698-185">ゲームの場合、簡単な説明は Xbox One のゲーム ハブの [情報] セクションにも表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="a7698-185">For games, the short description may also appear in the Information section of the Game Hub on Xbox One.</span></span>

<span data-ttu-id="a7698-186">最適な結果を得るには、短い説明下 270 文字してください。</span><span class="sxs-lookup"><span data-stu-id="a7698-186">For best results, keep your short description under 270 characters.</span></span> <span data-ttu-id="a7698-187">フィールドには 500 文字の制限が、一部のビューで最初に 270 文字のみを (短い説明の残りの部分は表示可能なリンク) と共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-187">The field has a 500 character limit, but in some views, only the first 270 characters will be shown (with a link available to view the rest of the short description).</span></span>


### <a name="additional-system-requirements"></a><span data-ttu-id="a7698-188">追加のシステム要件</span><span class="sxs-lookup"><span data-stu-id="a7698-188">Additional system requirements</span></span>

<span data-ttu-id="a7698-189">必要に応じて、アプリが正常に動作するうえで必要となるハードウェア構成を記述できます ([アプリのプロパティ](enter-app-properties.md#system-requirements)の **[システム必要条件]** セクションに指定した情報以外)。</span><span class="sxs-lookup"><span data-stu-id="a7698-189">If needed, you can describe the hardware configurations that your app requires to work properly (beyond the info you provided in the **System requirements** section in [App properties](enter-app-properties.md#system-requirements).</span></span> <span data-ttu-id="a7698-190">この情報は、一部のコンピューターでしか使うことができないハードウェアが必要なアプリの場合、特に重要です。</span><span class="sxs-lookup"><span data-stu-id="a7698-190">This is especially important if your app requires hardware that might not be available on every computer.</span></span> <span data-ttu-id="a7698-191">たとえば、3D プリンターやマイクロコントローラーなどの外部 USB ハードウェアがある場合にのみ、アプリケーションが正常に動作する場合は、ここにその情報を入力することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a7698-191">For instance, if your app will only work properly with external USB hardware such as a 3D printer or microcontroller, we suggest entering those here.</span></span> <span data-ttu-id="a7698-192">入力した情報は、製品のプロパティ ページで指定した要件と共に、Windows 10 バージョン 1607 以降 (Xbox を含む) でアプリの Store 登録情報を表示するユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-192">The info you enter will be shown to customers viewing your app's Store listing on Windows 10, version 1607 or later (including Xbox), along with the requirements you indicated on the product's properties page.</span></span> 

<span data-ttu-id="a7698-193">**[最小ハードウェア要件]** と **[推奨されるハードウェア]** の両方に最大 11 個の項目を入力できます。</span><span class="sxs-lookup"><span data-stu-id="a7698-193">You can enter up to 11 items for both **Minimum hardware** and **Recommended hardware**.</span></span> <span data-ttu-id="a7698-194">これらは、Store 登録情報に箇条書きの形式で表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-194">These are displayed to the customer as a bulleted list in your Store listing.</span></span> <span data-ttu-id="a7698-195">各項目につき短い 1 文 (かつ、200 文字未満) になるようにまとめます。</span><span class="sxs-lookup"><span data-stu-id="a7698-195">Keep these brief, with just a few words (and no more than 200 characters) per item.</span></span>

> [!NOTE]
> <span data-ttu-id="a7698-196">追加のシステム要件は、Store 登録情報に箇条書きの項目として表示されるため、独自に行頭文字を追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="a7698-196">Your additional system requirements will appear bulleted in your Store listing, so don't add your own bullets.</span></span>


<span id="shared-fields" />

## <a name="additional-information"></a><span data-ttu-id="a7698-197">追加情報</span><span class="sxs-lookup"><span data-stu-id="a7698-197">Additional information</span></span>

<span data-ttu-id="a7698-198">以下に説明する項目は、ユーザーにとって製品を見つけやすくしたり、製品の理解を助けたりするために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a7698-198">The items described below help customers discover and understand your product.</span></span> <span data-ttu-id="a7698-199">(このセクションは以前、**共有フィールド**と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="a7698-199">(This section was formerly called **Shared fields**).</span></span>

### <a name="search-terms"></a><span data-ttu-id="a7698-200">検索語句</span><span class="sxs-lookup"><span data-stu-id="a7698-200">Search terms</span></span>

<span data-ttu-id="a7698-201">検索語句は (以前はキーワードと呼ばれていました)、ユーザーには表示されない単語または短いフレーズで、ユーザーがそれらの語句を使って検索したときに Microsoft Store でアプリを見つけやすくすることができます。</span><span class="sxs-lookup"><span data-stu-id="a7698-201">Search terms (formerly called keywords) are single words or short phrases that are not displayed to customers, but can help your make your app discoverable in the Store when customers search using those terms.</span></span> <span data-ttu-id="a7698-202">最大 7 個の検索語句を含めることができ、それぞれの語句の最大長は 30 文字です。すべての検索語句を合わせて使用できる個々の単語の数は 21 個までです。</span><span class="sxs-lookup"><span data-stu-id="a7698-202">You can include up to 7 search terms with a maximum of 30 characters each, and can use no more than 21 separate words across all search terms.</span></span>

<span data-ttu-id="a7698-203">検索語句を追加するとき、特にアプリ名の一部ではない語句を追加する場合は、同様のアプリを検索する際にユーザーが使いそうな単語を考えてください。</span><span class="sxs-lookup"><span data-stu-id="a7698-203">When adding search terms, think about the words that customers might use when searching for apps like yours, especially if they're not part of your app's name.</span></span> <span data-ttu-id="a7698-204">アプリに実際に関連しない検索語句は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="a7698-204">Be sure not to use any search terms that are not actually relevant to your app.</span></span>

### <a name="copyright-and-trademark-info"></a><span data-ttu-id="a7698-205">著作権と商標の情報</span><span class="sxs-lookup"><span data-stu-id="a7698-205">Copyright and trademark info</span></span>

<span data-ttu-id="a7698-206">その他の著作権や商標の情報を指定する場合は、ここに入力します。</span><span class="sxs-lookup"><span data-stu-id="a7698-206">If you'd like to provide additional copyright and/or trademark info, enter it here.</span></span> <span data-ttu-id="a7698-207">このフィールドには 200 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-207">This field has a 200 character limit.</span></span>


### <a name="additional-license-terms"></a><span data-ttu-id="a7698-208">追加のライセンス条項</span><span class="sxs-lookup"><span data-stu-id="a7698-208">Additional license terms</span></span>

<span data-ttu-id="a7698-209">「**標準アプリケーション ライセンス条項**」(「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」からリンクされています) の条項に基づいて、アプリのライセンスをユーザーに付与する場合は、このフィールドを空白にします。</span><span class="sxs-lookup"><span data-stu-id="a7698-209">Leave this field blank if you want your app to be licensed to customers under the terms of the **Standard Application License Terms** (which are linked to from the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)).</span></span>

<span data-ttu-id="a7698-210">アプリのライセンス条項が「**標準アプリケーション ライセンス条項**」と異なる場合は、ここに入力します。</span><span class="sxs-lookup"><span data-stu-id="a7698-210">If your license terms are different from the **Standard Application License Terms**, enter them here.</span></span>

<span data-ttu-id="a7698-211">このフィールドに 1 つの URL を入力すると、ユーザーがクリックして追加のライセンス条項を読むことができるリンクとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-211">If you enter a single URL into this field, it will be displayed to customers as a link that they can click to read your additional license terms.</span></span> <span data-ttu-id="a7698-212">これは、追加のライセンス条項が非常に長い場合や、追加のライセンス条項にクリック可能なリンクや書式設定を含める場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="a7698-212">This is useful if your additional license terms are very long, or if you want to include clickable links or formatting in your additional license terms.</span></span>

<span data-ttu-id="a7698-213">このフィールドには、最大 10,000 文字のテキストを入力することもできます。</span><span class="sxs-lookup"><span data-stu-id="a7698-213">You can also enter up to 10,000 characters of text in this field.</span></span> <span data-ttu-id="a7698-214">この場合、これらの追加のライセンス条項は、ユーザーに対してプレーンテキストとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7698-214">If you do that, customers will see these additional license terms displayed as plain text.</span></span>


### <a name="developed-by"></a><span data-ttu-id="a7698-215">Developed by (開発元)</span><span class="sxs-lookup"><span data-stu-id="a7698-215">Developed by</span></span>

<span data-ttu-id="a7698-216">アプリのストア登録情報に **[Developed by] (開発元)** フィールドを含める場合は、ここにテキストを入力します </span><span class="sxs-lookup"><span data-stu-id="a7698-216">Enter text here if you want to include a **Developed by** field in your app's Store listing.</span></span> <span data-ttu-id="a7698-217">(**[Developed by] (開発元)** フィールドに値を入力していかどうかには関係なく、**[公開元]** フィールドにはアカウントに関連付けられた発行者の表示名が示されます)。</span><span class="sxs-lookup"><span data-stu-id="a7698-217">(The **Published by** field will list the publisher display name associated with your account, whether or not you provide a value for the **Developed by** field.)</span></span>

<span data-ttu-id="a7698-218">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a7698-218">This field has a 255 character limit.</span></span>
 

<span id="privacy-policy" />

> [!NOTE]
> <span data-ttu-id="a7698-219">**[プライバシー ポリシー]**、**[Web サイト]**、**[サポートの問い合わせ先情報]** の各フィールドは、[[プロパティ]](enter-app-properties.md) ページに移動しました。</span><span class="sxs-lookup"><span data-stu-id="a7698-219">The **Privacy policy**, **Website**, and **Support contact info** fields are now located on the [Properties](enter-app-properties.md) page.</span></span>

