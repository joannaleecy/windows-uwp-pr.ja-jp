---
author: jnHs
Description: The Store listings section of the app submission process is where you provide the text and images that customers will see when viewing your app's listing in the Microsoft Store.
title: アプリの Microsoft Store 登録情報の作成
ms.assetid: 50D67219-B6C6-4EF0-B76A-926A5F24997D
ms.author: wdg-dev-content
ms.date: 04/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 登録情報, 説明, Microsoft Store ページ, リリース ノート, タイトル
ms.localizationpriority: high
ms.openlocfilehash: 91242f7bd5f43b9d8af605b3b814e80006c90ce4
ms.sourcegitcommit: cceaf2206ec53a3e9155f97f44e4795a7b6a1d78
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/03/2018
---
# <a name="create-app-store-listings"></a><span data-ttu-id="79673-103">アプリの Microsoft Store 登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="79673-103">Create app Store listings</span></span>


<span data-ttu-id="79673-104">[アプリの申請プロセス](app-submissions.md)の **[Store 登録情報]** セクションでは、ユーザーが Microsoft Store でアプリの登録情報を表示したときに表示されるテキストと[画像](app-screenshots-and-images.md)を指定できます。</span><span class="sxs-lookup"><span data-stu-id="79673-104">The **Store listings** section of the [app submission process](app-submissions.md) is where you provide the text and [images](app-screenshots-and-images.md) that customers will see when viewing your app's listing in the Microsoft Store.</span></span>

<span data-ttu-id="79673-105">**[Store 登録情報]** のフィールドの多くは省略可能ですが、登録情報が目立つように複数の画像とできるだけ多くの情報を指定することをお勧めします。**[Store 登録情報]** の手順が完成したと見なされるには、説明のテキストと少なくとも 1 つの[スクリーンショット](app-screenshots-and-images.md#screenshots)が必要です。</span><span class="sxs-lookup"><span data-stu-id="79673-105">Many of the fields in a **Store listing** are optional, but we suggest providing multiple images and as much info as possible to make your listing stand out. The minimum required for the **Store listings** step to be considered complete is a text description and at least one [screenshot](app-screenshots-and-images.md#screenshots).</span></span> <span data-ttu-id="79673-106">申請によっては、[[プライバシー ポリシー]](#privacy-policy) フィールドと [[サポートの問い合わせ先情報]](#support-contact-info) フィールドも必須です。</span><span class="sxs-lookup"><span data-stu-id="79673-106">For some submissions, the [Privacy policy](#privacy-policy) and [Support contact info](#support-contact-info) fields are also required.</span></span> 

> [!TIP]
> <span data-ttu-id="79673-107">ダッシュボードで直接 Store 登録情報を入力してファイルをアップロードするのではなく、.csv ファイルを使ってオフラインで登録情報を入力する場合は、必要に応じて [Store 登録情報をインポートおよびエクスポート](import-and-export-store-listings.md)することもできます。</span><span class="sxs-lookup"><span data-stu-id="79673-107">You can optionally [import and export Store listings](import-and-export-store-listings.md) if you'd prefer to enter your listing info offline in a .csv file, rather than providing info and uploading files directly in the dashboard.</span></span> <span data-ttu-id="79673-108">インポートおよびエクスポート オプションでは、一度に複数の更新を行うことができるため、多くの言語の登録情報がある場合に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="79673-108">Using the import and export option can be especially convenient if you have listings in many languages, since it lets you make multiple updates at once.</span></span> 

<span data-ttu-id="79673-109">既定では、対象となるすべてのオペレーティング システムに同じ Store 登録情報 (言語ごと) が使われます。</span><span class="sxs-lookup"><span data-stu-id="79673-109">By default, we'll use the same Store listing (per language) for all of your targeted operating systems.</span></span> <span data-ttu-id="79673-110">申請でサポートされる特定のオペレーティング システム用にカスタマイズされた Store 登録情報を使う場合は、[プラットフォーム固有の Store 登録情報を作成](create-platform-specific-store-listings.md)できます。</span><span class="sxs-lookup"><span data-stu-id="79673-110">If you'd like to use a customized Store listing for a specific operating system that your submission supports, you can [create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span> <span data-ttu-id="79673-111">既定の登録情報は、Windows 10 のユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-111">Your default listing will always be shown to customers on Windows 10.</span></span>

## <a name="store-listing-languages"></a><span data-ttu-id="79673-112">ストア登録情報の言語</span><span class="sxs-lookup"><span data-stu-id="79673-112">Store listing languages</span></span>

<span data-ttu-id="79673-113">少なくとも 1 つの言語の **[ストア登録情報]** ページを完成させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="79673-113">You must complete the **Store listing** page for at least one language.</span></span> <span data-ttu-id="79673-114">ストア登録情報は、パッケージでサポートしているすべての言語で提供することをお勧めしますが、ストア登録情報を提供しない言語を削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="79673-114">We recommend providing a Store listing in each language that your packages support, but you have flexibility to remove languages for which you don’t wish to provide a Store listing.</span></span> <span data-ttu-id="79673-115">パッケージでサポートしていない言語のストア登録情報を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="79673-115">You can also create Store listings in additional languages which aren’t supported by your packages.</span></span>

> [!NOTE]
> <span data-ttu-id="79673-116">申請にパッケージが既に含まれている場合は、パッケージでサポートされている[言語](supported-languages.md)が [申請の概要] ページに表示されます (言語を削除していない場合)。</span><span class="sxs-lookup"><span data-stu-id="79673-116">If your submission includes packages already, we’ll show the [languages](supported-languages.md) supported in your packages on the submission overview page (unless you remove any of them).</span></span>

<span data-ttu-id="79673-117">ストア登録情報の言語を追加または削除するには、申請の概要ページで **[言語の追加/削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="79673-117">To add or remove languages for your Store listings, click **Add/remove languages** from the submission overview page.</span></span> <span data-ttu-id="79673-118">既にパッケージをアップロードしている場合は、**[Languages supported by your packages]** (パッケージでサポートしている言語) セクションに言語が表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-118">If you‘ve already uploaded packages, you’ll see their languages listed in the **Languages supported by your packages** section.</span></span> <span data-ttu-id="79673-119">これらの言語の 1 つまたは複数を削除するには、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="79673-119">To remove one or more of these languages, click **Remove**.</span></span> <span data-ttu-id="79673-120">以前にこのセクションから削除した言語を後で含める場合は、**[加算]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="79673-120">If you later decide to include a language that you previously removed from this section, you can click **Add**.</span></span>

<span data-ttu-id="79673-121">**[ストア登録情報の追加言語]** セクションで、**[追加言語の管理]** をクリックして、パッケージに含まれて*いない*言語を追加するか、パッケージに含めない言語を削除します。</span><span class="sxs-lookup"><span data-stu-id="79673-121">In the **Additional Store listing languages** section, you can click **Manage additional languages** to add or remove languages that are *not* included in your packages.</span></span> <span data-ttu-id="79673-122">追加する言語のチェック ボックスをクリックし、**[更新]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="79673-122">Check the boxes for the languages that you’d like to add, then click **Update**.</span></span> <span data-ttu-id="79673-123">選択した言語が **[ストア登録情報の追加言語]** セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-123">The languages you’ve selected will be displayed in the **Additional Store listing languages** section.</span></span> <span data-ttu-id="79673-124">1 つまたは複数の言語を削除するには、**[削除]** をクリックします (または、**[追加言語の管理]** をクリックし、削除する言語のチェック ボックスをオフにします)。</span><span class="sxs-lookup"><span data-stu-id="79673-124">To remove one or more of these languages, click **Remove** (or click **Manage additional languages** and uncheck the box for languages you’d like to remove).</span></span>

<span data-ttu-id="79673-125">選択が終了したら **[保存]** をクリックして、申請の概要ページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="79673-125">When you have finished making your selections, click **Save** to return to the submission overview page.</span></span>

> [!NOTE]
> <span data-ttu-id="79673-126">パッケージでサポートしていない言語のストア登録情報を作成するときは、そのストア登録情報に表示する予約済みのアプリ名を指定する必要があります。その言語のパッケージが関連付けられておらず、名前を取得できないためです。</span><span class="sxs-lookup"><span data-stu-id="79673-126">When creating a Store listing in a language that isn't supported by your packages, you'll need to indicate which of your reserved app names should be displayed in that Store listing, since there isn't an associated package in that language from which to pull the name.</span></span> <span data-ttu-id="79673-127">ここで選んだ名前は、この言語のストア登録情報にのみ適用され、ユーザーがアプリをインストールするときに表示される名前には影響しません。</span><span class="sxs-lookup"><span data-stu-id="79673-127">The name you choose here only applies to the Store listing for this language and does not impact the name displayed when a customer installs the app.</span></span>

<span data-ttu-id="79673-128">ストア登録情報を編集するには、申請の概要ページで言語名をクリックします。</span><span class="sxs-lookup"><span data-stu-id="79673-128">To edit a Store listing, click the language name from the submission overview page.</span></span>

<span data-ttu-id="79673-129">**[ストア登録情報]** ページの上部には、選択した言語の既定のストア登録情報に関連付けられたフィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="79673-129">At the top of the **Store listing** page are the fields associated with your default Store listing for the selected language.</span></span> <span data-ttu-id="79673-130">以前の OS バージョン (Windows 8.x 以前、Windows Phone 8.x 以前) を対象とするパッケージがあり、指定された OS バージョンのユーザーに表示する別のスクリーン ショットまたは情報を含むプラットフォームに固有のストア登録情報を作成している場合を除き、これらのフィールドはすべてのユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-130">These fields will be shown to all of your customers, unless you have packages targeting earlier OS versions (Windows 8.x or earlier; Windows Phone 8.x or earlier) and create platform-specific Store listings to include different screenshots or info to display to customers on specified OS versions.</span></span> <span data-ttu-id="79673-131">詳しくは、「[プラットフォーム固有のストア登録情報の作成](create-platform-specific-store-listings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="79673-131">For more info, see [Create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span>

## <a name="description"></a><span data-ttu-id="79673-132">説明</span><span class="sxs-lookup"><span data-stu-id="79673-132">Description</span></span>

<span data-ttu-id="79673-133">説明フィールドでは、アプリの内容をユーザーに伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="79673-133">The description field is where you can tell customers what your app does.</span></span> <span data-ttu-id="79673-134">このフィールドは必須であり、最大 10,000 文字のプレーンテキストを入力できます。</span><span class="sxs-lookup"><span data-stu-id="79673-134">This field is required, and will accept up to 10,000 characters of plain text.</span></span>

<span data-ttu-id="79673-135">説明を目立たせるためのヒントについては、「[人の心をつかむアプリの説明を書く](write-a-great-app-description.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="79673-135">For some tips on making your description stand out, see [Write a great app description](write-a-great-app-description.md).</span></span>

<span id="release-notes" />

## <a name="whats-new-in-this-version"></a><span data-ttu-id="79673-136">今回のバージョンでの新機能</span><span class="sxs-lookup"><span data-stu-id="79673-136">What's new in this version</span></span>

<span data-ttu-id="79673-137">初めてアプリを申請する場合、このフィールドは空白のままにしてください。</span><span class="sxs-lookup"><span data-stu-id="79673-137">If this is the first time you're submitting your app, leave this field blank.</span></span> <span data-ttu-id="79673-138">既存のアプリの更新の場合、ここには最新のリリースでの変更点をユーザーに知らせることができます。</span><span class="sxs-lookup"><span data-stu-id="79673-138">For an update to an existing app, this is where you can let customer know what's changed in the latest release.</span></span> <span data-ttu-id="79673-139">このフィールドには 1,500 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="79673-139">This field has a 1500 character limit.</span></span> <span data-ttu-id="79673-140">(以前は、このフィールドは **[リリース ノート]** と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="79673-140">(Previously, this field was called **Release notes**).</span></span>

## <a name="app-features"></a><span data-ttu-id="79673-141">アプリの機能</span><span class="sxs-lookup"><span data-stu-id="79673-141">App features</span></span>

<span data-ttu-id="79673-142">アプリの主な機能の短い概要です。</span><span class="sxs-lookup"><span data-stu-id="79673-142">These are short summaries of your app's key features.</span></span> <span data-ttu-id="79673-143">これらは、アプリの Store 登録情報の **[機能]** セクションに、**[説明]** と共に箇条書きの形式で表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-143">They are displayed to the customer as a bulleted list in the **Features** section of your app's Store listing, in addition to the **Description**.</span></span> <span data-ttu-id="79673-144">機能ごとに、簡潔な 1 文 (200 文字未満) になるようにまとめます。</span><span class="sxs-lookup"><span data-stu-id="79673-144">Keep these brief, with just a few words (and no more than 200 characters) per feature.</span></span> <span data-ttu-id="79673-145">最大 20 の機能を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="79673-145">You may include up to 20 features.</span></span>

> [!NOTE]
> <span data-ttu-id="79673-146">アプリの機能は、Store 登録情報に箇条書きの項目として表示されるため、独自に行頭文字を追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="79673-146">Your app features will appear bulleted in your Store listing, so don't add your own bullets.</span></span>

## <a name="screenshots"></a><span data-ttu-id="79673-147">スクリーンショット</span><span class="sxs-lookup"><span data-stu-id="79673-147">Screenshots</span></span>

<span data-ttu-id="79673-148">アプリを提出するには、少なくとも 1 つのスクリーンショットが必要です。</span><span class="sxs-lookup"><span data-stu-id="79673-148">One screenshot is required in order to submit your app.</span></span> <span data-ttu-id="79673-149">ユーザーが自分が使っている種類のデバイスでアプリがどのように表示されるかをイメージできるように、アプリがサポートするデバイスの種類ごとに少なくとも 4 つのスクリーンショットを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="79673-149">We recommend providing at least four screenshots for each device type that your app supports so that people can see how the app will look on their device type.</span></span>

<span data-ttu-id="79673-150">詳しくは、「[アプリのスクリーンショットと画像](app-screenshots-and-images.md#screenshots)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="79673-150">For more info, see [App screenshots and images](app-screenshots-and-images.md#screenshots).</span></span>


## <a name="store-logos"></a><span data-ttu-id="79673-151">ストア ロゴ</span><span class="sxs-lookup"><span data-stu-id="79673-151">Store logos</span></span> 

<span data-ttu-id="79673-152">ストア ロゴは、アプリの情報をより適切にユーザーに表示するためにアップロードできるオプションの画像です。</span><span class="sxs-lookup"><span data-stu-id="79673-152">Store logos are optional images that you can upload to enhance the way your app is displayed to customers.</span></span> <span data-ttu-id="79673-153">必要に応じて、ここでアップロードした画像を Windows 10 (Xbox を含む) ユーザー向けのアプリの Store 登録情報に使うように指定して、アプリのパッケージからのロゴ画像が Microsoft Store で使われないようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="79673-153">You can also optionally specify that only images you upload here should be used in your app’s Store listing for customers on Windows 10 (including Xbox), rather than allowing the Store to use logo images from your app’s packages.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="79673-154">アプリが Xbox をサポートしている場合、または Windows Phone 8.1 以前をサポートしている場合、ストアで登録情報が適切に表示されるようにするには、ここで特定の画像を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="79673-154">If your app supports Xbox, or if it supports Windows Phone 8.1 or earlier, you must provide certain images here in order for the listing to appear properly in the Store.</span></span> 

<span data-ttu-id="79673-155">詳しくは、「[ストア ロゴ](app-screenshots-and-images.md#store-logos)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="79673-155">For more info, see [Store logos](app-screenshots-and-images.md#store-logos).</span></span>


## <a name="additional-art-assets"></a><span data-ttu-id="79673-156">追加のアート資産</span><span class="sxs-lookup"><span data-stu-id="79673-156">Additional art assets</span></span>

<span data-ttu-id="79673-157">トレーラーやプロモーション用の画像など、製品用の追加の資産を提出することができます。</span><span class="sxs-lookup"><span data-stu-id="79673-157">You can submit additional assets for your product, including trailers and promotional images.</span></span> <span data-ttu-id="79673-158">これらはいずれも省略可能ですが、できるだけ多くの資産のアップロードを検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="79673-158">These are all optional, but we recommend that you consider uploading as many of them as possible.</span></span> <span data-ttu-id="79673-159">これらの画像は、より魅力的な登録情報を作成し、製品がどのようなものかをユーザーに知ってもらうために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="79673-159">These images can help give customers a better idea of what your product is and make a more enticing listing.</span></span>

<span data-ttu-id="79673-160">詳しくは、「[追加のアート資産](app-screenshots-and-images.md#additional-art-assets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="79673-160">For more info, see [Additional art assets](app-screenshots-and-images.md#additional-art-assets).</span></span>


## <a name="supplemental-information"></a><span data-ttu-id="79673-161">補足情報</span><span class="sxs-lookup"><span data-stu-id="79673-161">Supplemental information</span></span>

<span data-ttu-id="79673-162">このセクションのフィールドはすべてオプションです。</span><span class="sxs-lookup"><span data-stu-id="79673-162">The fields in this section are all optional.</span></span> <span data-ttu-id="79673-163">アプリの機能やシステム要件は、アプリの機能や最適なエクスペリエンスのための要件をユーザーに理解してもらうのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="79673-163">App features and system requirements can help customers understand more about what your app does and what is required for the best experience.</span></span> <span data-ttu-id="79673-164">他のオプションは、さまざまなシナリオで製品の最適なエクスペリエンスを実現するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="79673-164">Other options help provide an optimal experience for your product in different scenarios.</span></span> <span data-ttu-id="79673-165">以下の情報を確認し、申請でこの情報を提供する意味があるかどうかを判断してください。</span><span class="sxs-lookup"><span data-stu-id="79673-165">Review the info below to determine if providing this info makes sense for your submission.</span></span>

### <a name="short-title"></a><span data-ttu-id="79673-166">短いタイトル</span><span class="sxs-lookup"><span data-stu-id="79673-166">Short title</span></span>

<span data-ttu-id="79673-167">製品の名前の短いバージョン。</span><span class="sxs-lookup"><span data-stu-id="79673-167">A shorter version of your product’s name.</span></span> <span data-ttu-id="79673-168">指定した場合、Xbox One のさまざまな場所 (インストール時や [実績] など) で製品のフル タイトルの代わりにこの短い名前が表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="79673-168">If provided, this shorter name may appear in various places on Xbox One (during installation, in Achievements, etc.) in place of the full title of your product.</span></span>

<span data-ttu-id="79673-169">**短いタイトル**には 50 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="79673-169">The **Short title** has a 50 character limit.</span></span>


### <a name="sort-title"></a><span data-ttu-id="79673-170">ソート タイトル</span><span class="sxs-lookup"><span data-stu-id="79673-170">Sort title</span></span>

<span data-ttu-id="79673-171">製品のアルファベット表記やスペルが複数ある場合、ここに別のバージョンを入力できます。</span><span class="sxs-lookup"><span data-stu-id="79673-171">If your product could be alphabetized or spelled in different ways, you can enter another version here.</span></span> <span data-ttu-id="79673-172">これにより、ユーザーが検索時にそのバージョンを入力した場合に製品をすばやく見つけることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="79673-172">This allows customers to find your product more quickly if they type that version in while searching.</span></span> 

<span data-ttu-id="79673-173">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="79673-173">This field has a 255 character limit.</span></span>


### <a name="voice-title"></a><span data-ttu-id="79673-174">音声タイトル</span><span class="sxs-lookup"><span data-stu-id="79673-174">Voice title</span></span>

<span data-ttu-id="79673-175">Kinect やヘッドセットを使うときに Xbox One のオーディオ エクスペリエンスで使われる、製品の代替名 (ある場合)。</span><span class="sxs-lookup"><span data-stu-id="79673-175">An alternate name for your product that, if provided, may be used in the audio experience on Xbox One when using Kinect or a headset.</span></span>

<span data-ttu-id="79673-176">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="79673-176">This field has a 255 character limit.</span></span>


### <a name="short-description"></a><span data-ttu-id="79673-177">簡単な説明</span><span class="sxs-lookup"><span data-stu-id="79673-177">Short description</span></span>

<span data-ttu-id="79673-178">ゲームにのみ使用されます。</span><span class="sxs-lookup"><span data-stu-id="79673-178">Only used for games.</span></span> <span data-ttu-id="79673-179">この説明は、Xbox One のゲーム ハブにある [情報] セクションに表示され、ユーザーがどのようなゲームかを理解するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="79673-179">This description appears in the Information section of the Game Hub on Xbox One, and helps customers understand more about your game.</span></span>

<span data-ttu-id="79673-180">このフィールドには 500 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="79673-180">This field has a 500 character limit.</span></span>


### <a name="additional-system-requirements"></a><span data-ttu-id="79673-181">追加のシステム要件</span><span class="sxs-lookup"><span data-stu-id="79673-181">Additional system requirements</span></span>

<span data-ttu-id="79673-182">必要に応じて、アプリが正常に動作するうえで必要となるハードウェア構成を記述できます ([アプリのプロパティ](enter-app-properties.md#system-requirements)の **[システム必要条件]** セクションに指定した情報以外)。</span><span class="sxs-lookup"><span data-stu-id="79673-182">If needed, you can describe the hardware configurations that your app requires to work properly (beyond the info you provided in the **System requirements** section in [App properties](enter-app-properties.md#system-requirements).</span></span> <span data-ttu-id="79673-183">この情報は、一部のコンピューターでしか使うことができないハードウェアが必要なアプリの場合、特に重要です。</span><span class="sxs-lookup"><span data-stu-id="79673-183">This is especially important if your app requires hardware that might not be available on every computer.</span></span> <span data-ttu-id="79673-184">たとえば、3D プリンターやマイクロコントローラーなどの外部 USB ハードウェアがある場合にのみ、アプリケーションが正常に動作する場合は、ここにその情報を入力することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="79673-184">For instance, if your app will only work properly with external USB hardware such as a 3D printer or microcontroller, we suggest entering those here.</span></span> <span data-ttu-id="79673-185">入力した情報は、製品のプロパティ ページで指定した要件と共に、Windows 10 バージョン 1607 以降 (Xbox を含む) でアプリの Store 登録情報を表示するユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-185">The info you enter will be shown to customers viewing your app's Store listing on Windows 10, version 1607 or later (including Xbox), along with the requirements you indicated on the product's properties page.</span></span> 

<span data-ttu-id="79673-186">**[最小ハードウェア要件]** と **[推奨されるハードウェア]** の両方に最大 11 個の項目を入力できます。</span><span class="sxs-lookup"><span data-stu-id="79673-186">You can enter up to 11 items for both **Minimum hardware** and **Recommended hardware**.</span></span> <span data-ttu-id="79673-187">これらは、Store 登録情報に箇条書きの形式で表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-187">These are displayed to the customer as a bulleted list in your Store listing.</span></span> <span data-ttu-id="79673-188">各項目につき短い 1 文 (かつ、200 文字未満) になるようにまとめます。</span><span class="sxs-lookup"><span data-stu-id="79673-188">Keep these brief, with just a few words (and no more than 200 characters) per item.</span></span>

> [!NOTE]
> <span data-ttu-id="79673-189">追加のシステム要件は、Store 登録情報に箇条書きの項目として表示されるため、独自に行頭文字を追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="79673-189">Your additional system requirements will appear bulleted in your Store listing, so don't add your own bullets.</span></span>


<span id="shared-fields" />

## <a name="additional-information"></a><span data-ttu-id="79673-190">追加情報</span><span class="sxs-lookup"><span data-stu-id="79673-190">Additional information</span></span>

<span data-ttu-id="79673-191">以下に説明する項目は、ユーザーにとって製品を見つけやすくしたり、製品の理解を助けたりするために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="79673-191">The items described below help customers discover and understand your product.</span></span> <span data-ttu-id="79673-192">ここで入力した情報は、[プラットフォーム固有のストア登録情報を作成](create-platform-specific-store-listings.md)した場合でも、オペレーティング システムに関係なく、指定の言語のすべてのストア登録情報に適用されます。</span><span class="sxs-lookup"><span data-stu-id="79673-192">The info you enter here will apply to all of your Store listings in a given language, regardless of operating system, even if you [create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span> <span data-ttu-id="79673-193">(このセクションは以前、**共有フィールド**と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="79673-193">(This section was formerly called **Shared fields**).</span></span>

### <a name="search-terms"></a><span data-ttu-id="79673-194">検索語句</span><span class="sxs-lookup"><span data-stu-id="79673-194">Search terms</span></span>

<span data-ttu-id="79673-195">検索語句は (以前はキーワードと呼ばれていました)、ユーザーには表示されない単語または短いフレーズで、ユーザーがそれらの語句を使って検索したときに Microsoft Store でアプリを見つけやすくすることができます。</span><span class="sxs-lookup"><span data-stu-id="79673-195">Search terms (formerly called keywords) are single words or short phrases that are not displayed to customers, but can help your make your app discoverable in the Store when customers search using those terms.</span></span> <span data-ttu-id="79673-196">最大 7 個の検索語句を含めることができ、それぞれの語句の最大長は 30 文字です。すべての検索語句を合わせて使用できる個々の単語の数は 21 個までです。</span><span class="sxs-lookup"><span data-stu-id="79673-196">You can include up to 7 search terms with a maximum of 30 characters each, and can use no more than 21 separate words across all search terms.</span></span>

<span data-ttu-id="79673-197">検索語句を追加するとき、特にアプリ名の一部ではない語句を追加する場合は、同様のアプリを検索する際にユーザーが使いそうな単語を考えてください。</span><span class="sxs-lookup"><span data-stu-id="79673-197">When adding search terms, think about the words that customers might use when searching for apps like yours, especially if they're not part of your app's name.</span></span> <span data-ttu-id="79673-198">アプリに実際に関連しない検索語句は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="79673-198">Be sure not to use any search terms that are not actually relevant to your app.</span></span>

### <a name="copyright-and-trademark-info"></a><span data-ttu-id="79673-199">著作権と商標の情報</span><span class="sxs-lookup"><span data-stu-id="79673-199">Copyright and trademark info</span></span>

<span data-ttu-id="79673-200">その他の著作権や商標の情報を指定する場合は、ここに入力します。</span><span class="sxs-lookup"><span data-stu-id="79673-200">If you'd like to provide additional copyright and/or trademark info, enter it here.</span></span> <span data-ttu-id="79673-201">このフィールドには 200 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="79673-201">This field has a 200 character limit.</span></span>


### <a name="additional-license-terms"></a><span data-ttu-id="79673-202">追加のライセンス条項</span><span class="sxs-lookup"><span data-stu-id="79673-202">Additional license terms</span></span>

<span data-ttu-id="79673-203">「**標準アプリケーション ライセンス条項**」(「[アプリ開発者契約](https://msdn.microsoft.com/library/windows/apps/hh694058)」からリンクされています) の条項に基づいて、アプリのライセンスをユーザーに付与する場合は、このフィールドを空白にします。</span><span class="sxs-lookup"><span data-stu-id="79673-203">Leave this field blank if you want your app to be licensed to customers under the terms of the **Standard Application License Terms** (which are linked to from the [App Developer Agreement](https://msdn.microsoft.com/library/windows/apps/hh694058)).</span></span>

<span data-ttu-id="79673-204">アプリのライセンス条項が「**標準アプリケーション ライセンス条項**」と異なる場合は、ここに入力します。</span><span class="sxs-lookup"><span data-stu-id="79673-204">If your license terms are different from the **Standard Application License Terms**, enter them here.</span></span>

<span data-ttu-id="79673-205">このフィールドに 1 つの URL を入力すると、ユーザーがクリックして追加のライセンス条項を読むことができるリンクとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-205">If you enter a single URL into this field, it will be displayed to customers as a link that they can click to read your additional license terms.</span></span> <span data-ttu-id="79673-206">これは、追加のライセンス条項が非常に長い場合や、追加のライセンス条項にクリック可能なリンクや書式設定を含める場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="79673-206">This is useful if your additional license terms are very long, or if you want to include clickable links or formatting in your additional license terms.</span></span>

<span data-ttu-id="79673-207">このフィールドには、最大 10,000 文字のテキストを入力することもできます。</span><span class="sxs-lookup"><span data-stu-id="79673-207">You can also enter up to 10,000 characters of text in this field.</span></span> <span data-ttu-id="79673-208">この場合、これらの追加のライセンス条項は、ユーザーに対してプレーンテキストとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="79673-208">If you do that, customers will see these additional license terms displayed as plain text.</span></span>


### <a name="developed-by"></a><span data-ttu-id="79673-209">Developed by (開発元)</span><span class="sxs-lookup"><span data-stu-id="79673-209">Developed by</span></span>

<span data-ttu-id="79673-210">アプリのストア登録情報に **[Developed by] (開発元)** フィールドを含める場合は、ここにテキストを入力します </span><span class="sxs-lookup"><span data-stu-id="79673-210">Enter text here if you want to include a **Developed by** field in your app's Store listing.</span></span> <span data-ttu-id="79673-211">(**[Developed by] (開発元)** フィールドに値を入力していかどうかには関係なく、**[公開元]** フィールドにはアカウントに関連付けられた発行者の表示名が示されます)。</span><span class="sxs-lookup"><span data-stu-id="79673-211">(The **Published by** field will list the publisher display name associated with your account, whether or not you provide a value for the **Developed by** field.)</span></span>

<span data-ttu-id="79673-212">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="79673-212">This field has a 255 character limit.</span></span>
 

<span id="privacy-policy" />

> [!NOTE]
> <span data-ttu-id="79673-213">**[プライバシー ポリシー]**、**[Web サイト]**、**[サポートの問い合わせ先情報]** の各フィールドは、[[プロパティ]](enter-app-properties.md) ページに移動しました。</span><span class="sxs-lookup"><span data-stu-id="79673-213">The **Privacy policy**, **Website**, and **Support contact info** fields are now located on the [Properties](enter-app-properties.md) page.</span></span>

