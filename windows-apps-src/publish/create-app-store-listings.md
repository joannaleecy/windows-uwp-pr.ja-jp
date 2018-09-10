---
author: jnHs
Description: The Store listings section of the app submission process is where you provide the text and images that customers will see when viewing your app's listing in the Microsoft Store.
title: アプリの Microsoft Store 登録情報の作成
ms.assetid: 50D67219-B6C6-4EF0-B76A-926A5F24997D
ms.author: wdg-dev-content
ms.date: 06/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 登録情報, 説明, Microsoft Store ページ, リリース ノート, タイトル
ms.localizationpriority: medium
ms.openlocfilehash: bd3585b1a2fee2a00c99990b32902b524f3318da
ms.sourcegitcommit: f5cf806a595969ecbb018c3f7eea86c7a34940f6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/10/2018
ms.locfileid: "3824306"
---
# <a name="create-app-store-listings"></a><span data-ttu-id="a66c1-103">アプリの Microsoft Store 登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="a66c1-103">Create app Store listings</span></span>


<span data-ttu-id="a66c1-104">[アプリの申請プロセス](app-submissions.md)の **[Store 登録情報]** セクションでは、ユーザーが Microsoft Store でアプリの登録情報を表示したときに表示されるテキストと[画像](app-screenshots-and-images.md)を指定できます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-104">The **Store listings** section of the [app submission process](app-submissions.md) is where you provide the text and [images](app-screenshots-and-images.md) that customers will see when viewing your app's listing in the Microsoft Store.</span></span>

<span data-ttu-id="a66c1-105">**[Store 登録情報]** のフィールドの多くは省略可能ですが、登録情報が目立つように複数の画像とできるだけ多くの情報を指定することをお勧めします。**[Store 登録情報]** の手順が完成したと見なされるには、説明のテキストと少なくとも 1 つの[スクリーンショット](app-screenshots-and-images.md#screenshots)が必要です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-105">Many of the fields in a **Store listing** are optional, but we suggest providing multiple images and as much info as possible to make your listing stand out. The minimum required for the **Store listings** step to be considered complete is a text description and at least one [screenshot](app-screenshots-and-images.md#screenshots).</span></span> <span data-ttu-id="a66c1-106">申請によっては、[[プライバシー ポリシー]](#privacy-policy) フィールドと [[サポートの問い合わせ先情報]](#support-contact-info) フィールドも必須です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-106">For some submissions, the [Privacy policy](#privacy-policy) and [Support contact info](#support-contact-info) fields are also required.</span></span> 

> [!TIP]
> <span data-ttu-id="a66c1-107">ダッシュボードで直接 Store 登録情報を入力してファイルをアップロードするのではなく、.csv ファイルを使ってオフラインで登録情報を入力する場合は、必要に応じて [Store 登録情報をインポートおよびエクスポート](import-and-export-store-listings.md)することもできます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-107">You can optionally [import and export Store listings](import-and-export-store-listings.md) if you'd prefer to enter your listing info offline in a .csv file, rather than providing info and uploading files directly in the dashboard.</span></span> <span data-ttu-id="a66c1-108">インポートおよびエクスポート オプションでは、一度に複数の更新を行うことができるため、多くの言語の登録情報がある場合に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-108">Using the import and export option can be especially convenient if you have listings in many languages, since it lets you make multiple updates at once.</span></span> 

<span data-ttu-id="a66c1-109">既定では、対象となるすべてのオペレーティング システムに同じ Store 登録情報 (言語ごと) が使われます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-109">By default, we'll use the same Store listing (per language) for all of your targeted operating systems.</span></span> <span data-ttu-id="a66c1-110">申請でサポートされる特定のオペレーティング システム用にカスタマイズされた Store 登録情報を使う場合は、[プラットフォーム固有の Store 登録情報を作成](create-platform-specific-store-listings.md)できます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-110">If you'd like to use a customized Store listing for a specific operating system that your submission supports, you can [create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span> <span data-ttu-id="a66c1-111">既定の登録情報は、Windows 10 のユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-111">Your default listing will always be shown to customers on Windows 10.</span></span>

## <a name="store-listing-languages"></a><span data-ttu-id="a66c1-112">ストア登録情報の言語</span><span class="sxs-lookup"><span data-stu-id="a66c1-112">Store listing languages</span></span>

<span data-ttu-id="a66c1-113">少なくとも 1 つの言語の **[ストア登録情報]** ページを完成させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-113">You must complete the **Store listing** page for at least one language.</span></span> <span data-ttu-id="a66c1-114">ストア登録情報は、パッケージでサポートしているすべての言語で提供することをお勧めしますが、ストア登録情報を提供しない言語を削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-114">We recommend providing a Store listing in each language that your packages support, but you have flexibility to remove languages for which you don’t wish to provide a Store listing.</span></span> <span data-ttu-id="a66c1-115">パッケージでサポートしていない言語のストア登録情報を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-115">You can also create Store listings in additional languages which aren’t supported by your packages.</span></span>

> [!NOTE]
> <span data-ttu-id="a66c1-116">申請にパッケージが既に含まれている場合は、パッケージでサポートされている[言語](supported-languages.md)が [申請の概要] ページに表示されます (言語を削除していない場合)。</span><span class="sxs-lookup"><span data-stu-id="a66c1-116">If your submission includes packages already, we’ll show the [languages](supported-languages.md) supported in your packages on the submission overview page (unless you remove any of them).</span></span>

<span data-ttu-id="a66c1-117">ストア登録情報の言語を追加または削除するには、申請の概要ページで **[言語の追加/削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-117">To add or remove languages for your Store listings, click **Add/remove languages** from the submission overview page.</span></span> <span data-ttu-id="a66c1-118">既にパッケージをアップロードしている場合は、**[Languages supported by your packages]** (パッケージでサポートしている言語) セクションに言語が表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-118">If you‘ve already uploaded packages, you’ll see their languages listed in the **Languages supported by your packages** section.</span></span> <span data-ttu-id="a66c1-119">これらの言語の 1 つまたは複数を削除するには、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-119">To remove one or more of these languages, click **Remove**.</span></span> <span data-ttu-id="a66c1-120">以前にこのセクションから削除した言語を後で含める場合は、**[加算]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-120">If you later decide to include a language that you previously removed from this section, you can click **Add**.</span></span>

<span data-ttu-id="a66c1-121">**[ストア登録情報の追加言語]** セクションで、**[追加言語の管理]** をクリックして、パッケージに含まれて*いない*言語を追加するか、パッケージに含めない言語を削除します。</span><span class="sxs-lookup"><span data-stu-id="a66c1-121">In the **Additional Store listing languages** section, you can click **Manage additional languages** to add or remove languages that are *not* included in your packages.</span></span> <span data-ttu-id="a66c1-122">追加する言語のチェック ボックスをクリックし、**[更新]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-122">Check the boxes for the languages that you’d like to add, then click **Update**.</span></span> <span data-ttu-id="a66c1-123">選択した言語が **[ストア登録情報の追加言語]** セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-123">The languages you’ve selected will be displayed in the **Additional Store listing languages** section.</span></span> <span data-ttu-id="a66c1-124">1 つまたは複数の言語を削除するには、**[削除]** をクリックします (または、**[追加言語の管理]** をクリックし、削除する言語のチェック ボックスをオフにします)。</span><span class="sxs-lookup"><span data-stu-id="a66c1-124">To remove one or more of these languages, click **Remove** (or click **Manage additional languages** and uncheck the box for languages you’d like to remove).</span></span>

<span data-ttu-id="a66c1-125">選択が終了したら **[保存]** をクリックして、申請の概要ページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-125">When you have finished making your selections, click **Save** to return to the submission overview page.</span></span>

## <a name="add-and-edit-store-listing-info"></a><span data-ttu-id="a66c1-126">追加し、ストア登録情報の編集</span><span class="sxs-lookup"><span data-stu-id="a66c1-126">Add and edit Store listing info</span></span>

<span data-ttu-id="a66c1-127">ストア登録情報を編集するには、申請の概要ページから言語名を選択します。</span><span class="sxs-lookup"><span data-stu-id="a66c1-127">To edit a Store listing, select the language name from the submission overview page.</span></span>

<span data-ttu-id="a66c1-128">**[ストア登録情報]** ページの上部には、選択した言語の既定のストア登録情報に関連付けられたフィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-128">At the top of the **Store listing** page are the fields associated with your default Store listing for the selected language.</span></span> <span data-ttu-id="a66c1-129">以前の OS バージョン (Windows 8.x 以前、Windows Phone 8.x 以前) を対象とするパッケージがあり、指定された OS バージョンのユーザーに表示する別のスクリーン ショットまたは情報を含むプラットフォームに固有のストア登録情報を作成している場合を除き、これらのフィールドはすべてのユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-129">These fields will be shown to all of your customers, unless you have packages targeting earlier OS versions (Windows 8.x or earlier; Windows Phone 8.x or earlier) and create platform-specific Store listings to include different screenshots or info to display to customers on specified OS versions.</span></span> <span data-ttu-id="a66c1-130">詳しくは、「[プラットフォーム固有のストア登録情報の作成](create-platform-specific-store-listings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-130">For more info, see [Create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span>

## <a name="product-name"></a><span data-ttu-id="a66c1-131">Product name (製品名)</span><span class="sxs-lookup"><span data-stu-id="a66c1-131">Product name</span></span>

<span data-ttu-id="a66c1-132">このドロップダウン ボックスでは、(アプリの 1 つ以上の名前を予約している) 場合、Store 登録情報で使用する名前を指定できます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-132">This drop-down box lets you specify which name should be used in the Store listing (if you have reserved more than one name for the app).</span></span>

<span data-ttu-id="a66c1-133">作業中のストア登録情報と同じ言語でパッケージをアップロードしている、それらのパッケージで使用する名前が選ばれます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-133">If you have uploaded package(s) in the same language as the Store listing you're working on, the name used in those packages will be selected.</span></span> <span data-ttu-id="a66c1-134">既に公開された後[、アプリの名前を変更](manage-app-names.md#rename-an-app-that-has-already-been-published)する必要がある場合は、新しい名前を使用するパッケージで、新しい申請を作成するときにさまざまな予約名は、ここを選択できます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-134">If you need to [rename the app](manage-app-names.md#rename-an-app-that-has-already-been-published) after it's already been published, you can select a different reserved name here when you create a new submission with packages that use the new name.</span></span>

<span data-ttu-id="a66c1-135">言語のパッケージをアップロードしていない場合は、作業中と 1 つ以上の名前を予約した名前をプルするには、その言語パッケージが関連付けられてがないため、予約済みのアプリ名のいずれかを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-135">If you haven't uploaded packages for the language you're working on, and you've reserved more than one name, you'll need to select one of your reserved app names, since there isn't an associated package in that language from which to pull the name.</span></span>

> [!NOTE]
> <span data-ttu-id="a66c1-136">作業している登録情報の言語でストアにのみ選択した**製品名**が適用されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-136">The **Product name** you select only applies to the Store listing in the language you're working in.</span></span> <span data-ttu-id="a66c1-137">これは、ユーザーは、アプリをインストールするときに表示される名前には影響しませんその名前は、インストールされるパッケージのマニフェストから取得されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-137">It does not impact the name displayed when a customer installs the app; that name comes from the manifest of the package that gets installed.</span></span> <span data-ttu-id="a66c1-138">混乱を避けるためには、各言語のパッケージとストア登録情報が、同じ名前を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-138">To avoid confusion, we recommend that each language's package(s) and Store listing use the same name.</span></span>

## <a name="description"></a><span data-ttu-id="a66c1-139">説明</span><span class="sxs-lookup"><span data-stu-id="a66c1-139">Description</span></span>

<span data-ttu-id="a66c1-140">説明フィールドでは、アプリの内容をユーザーに伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-140">The description field is where you can tell customers what your app does.</span></span> <span data-ttu-id="a66c1-141">このフィールドは必須であり、最大 10,000 文字のプレーンテキストを入力できます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-141">This field is required, and will accept up to 10,000 characters of plain text.</span></span>

<span data-ttu-id="a66c1-142">説明を目立たせるためのヒントについては、「[人の心をつかむアプリの説明を書く](write-a-great-app-description.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-142">For some tips on making your description stand out, see [Write a great app description](write-a-great-app-description.md).</span></span>

<span id="release-notes" />

## <a name="whats-new-in-this-version"></a><span data-ttu-id="a66c1-143">今回のバージョンでの新機能</span><span class="sxs-lookup"><span data-stu-id="a66c1-143">What's new in this version</span></span>

<span data-ttu-id="a66c1-144">初めてアプリを申請する場合、このフィールドは空白のままにしてください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-144">If this is the first time you're submitting your app, leave this field blank.</span></span> <span data-ttu-id="a66c1-145">既存のアプリの更新の場合、ここには最新のリリースでの変更点をユーザーに知らせることができます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-145">For an update to an existing app, this is where you can let customer know what's changed in the latest release.</span></span> <span data-ttu-id="a66c1-146">このフィールドには 1,500 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-146">This field has a 1500 character limit.</span></span> <span data-ttu-id="a66c1-147">(以前は、このフィールドは **[リリース ノート]** と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="a66c1-147">(Previously, this field was called **Release notes**).</span></span>

## <a name="app-features"></a><span data-ttu-id="a66c1-148">アプリの機能</span><span class="sxs-lookup"><span data-stu-id="a66c1-148">App features</span></span>

<span data-ttu-id="a66c1-149">アプリの主な機能の短い概要です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-149">These are short summaries of your app's key features.</span></span> <span data-ttu-id="a66c1-150">これらは、アプリの Store 登録情報の **[機能]** セクションに、**[説明]** と共に箇条書きの形式で表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-150">They are displayed to the customer as a bulleted list in the **Features** section of your app's Store listing, in addition to the **Description**.</span></span> <span data-ttu-id="a66c1-151">機能ごとに、簡潔な 1 文 (200 文字未満) になるようにまとめます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-151">Keep these brief, with just a few words (and no more than 200 characters) per feature.</span></span> <span data-ttu-id="a66c1-152">最大 20 の機能を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-152">You may include up to 20 features.</span></span>

> [!NOTE]
> <span data-ttu-id="a66c1-153">アプリの機能は、Store 登録情報に箇条書きの項目として表示されるため、独自に行頭文字を追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-153">Your app features will appear bulleted in your Store listing, so don't add your own bullets.</span></span>

## <a name="screenshots"></a><span data-ttu-id="a66c1-154">スクリーンショット</span><span class="sxs-lookup"><span data-stu-id="a66c1-154">Screenshots</span></span>

<span data-ttu-id="a66c1-155">アプリを提出するには、少なくとも 1 つのスクリーンショットが必要です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-155">One screenshot is required in order to submit your app.</span></span> <span data-ttu-id="a66c1-156">ユーザーが自分が使っている種類のデバイスでアプリがどのように表示されるかをイメージできるように、アプリがサポートするデバイスの種類ごとに少なくとも 4 つのスクリーンショットを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-156">We recommend providing at least four screenshots for each device type that your app supports so that people can see how the app will look on their device type.</span></span>

<span data-ttu-id="a66c1-157">詳しくは、「[アプリのスクリーンショットと画像](app-screenshots-and-images.md#screenshots)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-157">For more info, see [App screenshots and images](app-screenshots-and-images.md#screenshots).</span></span>


## <a name="store-logos"></a><span data-ttu-id="a66c1-158">ストア ロゴ</span><span class="sxs-lookup"><span data-stu-id="a66c1-158">Store logos</span></span> 

<span data-ttu-id="a66c1-159">ストア ロゴは、アプリの情報をより適切にユーザーに表示するためにアップロードできるオプションの画像です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-159">Store logos are optional images that you can upload to enhance the way your app is displayed to customers.</span></span> <span data-ttu-id="a66c1-160">必要に応じて、ここでアップロードした画像を Windows 10 (Xbox を含む) ユーザー向けのアプリの Store 登録情報に使うように指定して、アプリのパッケージからのロゴ画像が Microsoft Store で使われないようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-160">You can also optionally specify that only images you upload here should be used in your app’s Store listing for customers on Windows 10 (including Xbox), rather than allowing the Store to use logo images from your app’s packages.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="a66c1-161">アプリが Xbox をサポートしている場合、または Windows Phone 8.1 以前をサポートしている場合、ストアで登録情報が適切に表示されるようにするには、ここで特定の画像を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-161">If your app supports Xbox, or if it supports Windows Phone 8.1 or earlier, you must provide certain images here in order for the listing to appear properly in the Store.</span></span> 

<span data-ttu-id="a66c1-162">詳しくは、「[ストア ロゴ](app-screenshots-and-images.md#store-logos)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-162">For more info, see [Store logos](app-screenshots-and-images.md#store-logos).</span></span>


## <a name="additional-art-assets"></a><span data-ttu-id="a66c1-163">追加のアート資産</span><span class="sxs-lookup"><span data-stu-id="a66c1-163">Additional art assets</span></span>

<span data-ttu-id="a66c1-164">トレーラーやプロモーション用の画像など、製品用の追加の資産を提出することができます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-164">You can submit additional assets for your product, including trailers and promotional images.</span></span> <span data-ttu-id="a66c1-165">これらはいずれも省略可能ですが、できるだけ多くの資産のアップロードを検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-165">These are all optional, but we recommend that you consider uploading as many of them as possible.</span></span> <span data-ttu-id="a66c1-166">これらの画像は、より魅力的な登録情報を作成し、製品がどのようなものかをユーザーに知ってもらうために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-166">These images can help give customers a better idea of what your product is and make a more enticing listing.</span></span>

<span data-ttu-id="a66c1-167">詳しくは、「[追加のアート資産](app-screenshots-and-images.md#additional-art-assets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-167">For more info, see [Additional art assets](app-screenshots-and-images.md#additional-art-assets).</span></span>

<a id="supplemental-information" />

## <a name="supplemental-fields"></a><span data-ttu-id="a66c1-168">補足的なフィールド</span><span class="sxs-lookup"><span data-stu-id="a66c1-168">Supplemental fields</span></span>

<span data-ttu-id="a66c1-169">このセクションのフィールドはすべてオプションです。</span><span class="sxs-lookup"><span data-stu-id="a66c1-169">The fields in this section are all optional.</span></span> <span data-ttu-id="a66c1-170">以下の情報を確認し、申請でこの情報を提供する意味があるかどうかを判断してください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-170">Review the info below to determine if providing this info makes sense for your submission.</span></span> <span data-ttu-id="a66c1-171">特に、ほとんどの申請では**簡単な説明**をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-171">In particular, the **Short description** is recommended for most submissions.</span></span> <span data-ttu-id="a66c1-172">他のフィールドは、さまざまなシナリオで製品の最適なエクスペリエンスを実現するのに役立つ場合があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-172">The other fields may help provide an optimal experience for your product in different scenarios.</span></span>

### <a name="short-title"></a><span data-ttu-id="a66c1-173">短いタイトル</span><span class="sxs-lookup"><span data-stu-id="a66c1-173">Short title</span></span>

<span data-ttu-id="a66c1-174">製品の名前の短いバージョン。</span><span class="sxs-lookup"><span data-stu-id="a66c1-174">A shorter version of your product’s name.</span></span> <span data-ttu-id="a66c1-175">指定した場合、Xbox One のさまざまな場所 (インストール時や [実績] など) で製品のフル タイトルの代わりにこの短い名前が表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-175">If provided, this shorter name may appear in various places on Xbox One (during installation, in Achievements, etc.) in place of the full title of your product.</span></span>

<span data-ttu-id="a66c1-176">このフィールドには 50 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-176">This field has a 50 character limit.</span></span>


### <a name="sort-title"></a><span data-ttu-id="a66c1-177">ソート タイトル</span><span class="sxs-lookup"><span data-stu-id="a66c1-177">Sort title</span></span>

<span data-ttu-id="a66c1-178">製品のアルファベット表記やスペルが複数ある場合、ここに別のバージョンを入力できます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-178">If your product could be alphabetized or spelled in different ways, you can enter another version here.</span></span> <span data-ttu-id="a66c1-179">これにより、ユーザーが検索時にそのバージョンを入力した場合に製品をすばやく見つけることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-179">This allows customers to find your product more quickly if they type that version in while searching.</span></span> 

<span data-ttu-id="a66c1-180">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-180">This field has a 255 character limit.</span></span>


### <a name="voice-title"></a><span data-ttu-id="a66c1-181">音声タイトル</span><span class="sxs-lookup"><span data-stu-id="a66c1-181">Voice title</span></span>

<span data-ttu-id="a66c1-182">Kinect やヘッドセットを使うときに Xbox One のオーディオ エクスペリエンスで使われる、製品の代替名 (ある場合)。</span><span class="sxs-lookup"><span data-stu-id="a66c1-182">An alternate name for your product that, if provided, may be used in the audio experience on Xbox One when using Kinect or a headset.</span></span>

<span data-ttu-id="a66c1-183">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-183">This field has a 255 character limit.</span></span>


### <a name="short-description"></a><span data-ttu-id="a66c1-184">簡単な説明</span><span class="sxs-lookup"><span data-stu-id="a66c1-184">Short description</span></span>

<span data-ttu-id="a66c1-185">製品の Store 登録情報の先頭に使うことができる短くてわかりやすい説明です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-185">A shorter, catchy description that may be used in the top of your product’s Store listing.</span></span> <span data-ttu-id="a66c1-186">指定しない場合、長い[説明](#description)の最初の段落 (最大 500 の文字) が代わりに説明されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-186">If not provided, the first paragraph (up to 500 characters) of your longer [description](#description) will be used instead.</span></span> <span data-ttu-id="a66c1-187">説明はこのテキストの下にも表示されるため、Store 登録情報が繰り返されないように内容が異なる簡単な説明を指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-187">Because your description also appears below this text, we recommend providing a short description with different text so that your Store listing isn’t repetitive.</span></span>

<span data-ttu-id="a66c1-188">ゲームの場合、簡単な説明は Xbox One のゲーム ハブの [情報] セクションにも表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-188">For games, the short description may also appear in the Information section of the Game Hub on Xbox One.</span></span>

<span data-ttu-id="a66c1-189">最良の結果は、270 未満の文字、簡単な説明をしておいてください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-189">For best results, keep your short description under 270 characters.</span></span> <span data-ttu-id="a66c1-190">フィールドには 500 文字の制限がありますが、一部のビューで最初に 270 文字のみを (短い説明の残りの部分は表示可能なリンク) と共に表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-190">The field has a 500 character limit, but in some views, only the first 270 characters will be shown (with a link available to view the rest of the short description).</span></span>


### <a name="additional-system-requirements"></a><span data-ttu-id="a66c1-191">追加のシステム要件</span><span class="sxs-lookup"><span data-stu-id="a66c1-191">Additional system requirements</span></span>

<span data-ttu-id="a66c1-192">必要に応じて、アプリが正常に動作するうえで必要となるハードウェア構成を記述できます ([アプリのプロパティ](enter-app-properties.md#system-requirements)の **[システム必要条件]** セクションに指定した情報以外)。</span><span class="sxs-lookup"><span data-stu-id="a66c1-192">If needed, you can describe the hardware configurations that your app requires to work properly (beyond the info you provided in the **System requirements** section in [App properties](enter-app-properties.md#system-requirements).</span></span> <span data-ttu-id="a66c1-193">この情報は、一部のコンピューターでしか使うことができないハードウェアが必要なアプリの場合、特に重要です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-193">This is especially important if your app requires hardware that might not be available on every computer.</span></span> <span data-ttu-id="a66c1-194">たとえば、3D プリンターやマイクロコントローラーなどの外部 USB ハードウェアがある場合にのみ、アプリケーションが正常に動作する場合は、ここにその情報を入力することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-194">For instance, if your app will only work properly with external USB hardware such as a 3D printer or microcontroller, we suggest entering those here.</span></span> <span data-ttu-id="a66c1-195">入力した情報は、製品のプロパティ ページで指定した要件と共に、Windows 10 バージョン 1607 以降 (Xbox を含む) でアプリの Store 登録情報を表示するユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-195">The info you enter will be shown to customers viewing your app's Store listing on Windows 10, version 1607 or later (including Xbox), along with the requirements you indicated on the product's properties page.</span></span> 

<span data-ttu-id="a66c1-196">**[最小ハードウェア要件]** と **[推奨されるハードウェア]** の両方に最大 11 個の項目を入力できます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-196">You can enter up to 11 items for both **Minimum hardware** and **Recommended hardware**.</span></span> <span data-ttu-id="a66c1-197">これらは、Store 登録情報に箇条書きの形式で表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-197">These are displayed to the customer as a bulleted list in your Store listing.</span></span> <span data-ttu-id="a66c1-198">各項目につき短い 1 文 (かつ、200 文字未満) になるようにまとめます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-198">Keep these brief, with just a few words (and no more than 200 characters) per item.</span></span>

> [!NOTE]
> <span data-ttu-id="a66c1-199">追加のシステム要件は、Store 登録情報に箇条書きの項目として表示されるため、独自に行頭文字を追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-199">Your additional system requirements will appear bulleted in your Store listing, so don't add your own bullets.</span></span>


<span id="shared-fields" />

## <a name="additional-information"></a><span data-ttu-id="a66c1-200">追加情報</span><span class="sxs-lookup"><span data-stu-id="a66c1-200">Additional information</span></span>

<span data-ttu-id="a66c1-201">以下に説明する項目は、ユーザーにとって製品を見つけやすくしたり、製品の理解を助けたりするために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-201">The items described below help customers discover and understand your product.</span></span> <span data-ttu-id="a66c1-202">ここで入力した情報は、[プラットフォーム固有のストア登録情報を作成](create-platform-specific-store-listings.md)した場合でも、オペレーティング システムに関係なく、指定の言語のすべてのストア登録情報に適用されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-202">The info you enter here will apply to all of your Store listings in a given language, regardless of operating system, even if you [create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span> <span data-ttu-id="a66c1-203">(このセクションは以前、**共有フィールド**と呼ばれていました)。</span><span class="sxs-lookup"><span data-stu-id="a66c1-203">(This section was formerly called **Shared fields**).</span></span>

### <a name="search-terms"></a><span data-ttu-id="a66c1-204">検索語句</span><span class="sxs-lookup"><span data-stu-id="a66c1-204">Search terms</span></span>

<span data-ttu-id="a66c1-205">検索語句は (以前はキーワードと呼ばれていました)、ユーザーには表示されない単語または短いフレーズで、ユーザーがそれらの語句を使って検索したときに Microsoft Store でアプリを見つけやすくすることができます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-205">Search terms (formerly called keywords) are single words or short phrases that are not displayed to customers, but can help your make your app discoverable in the Store when customers search using those terms.</span></span> <span data-ttu-id="a66c1-206">最大 7 個の検索語句を含めることができ、それぞれの語句の最大長は 30 文字です。すべての検索語句を合わせて使用できる個々の単語の数は 21 個までです。</span><span class="sxs-lookup"><span data-stu-id="a66c1-206">You can include up to 7 search terms with a maximum of 30 characters each, and can use no more than 21 separate words across all search terms.</span></span>

<span data-ttu-id="a66c1-207">検索語句を追加するとき、特にアプリ名の一部ではない語句を追加する場合は、同様のアプリを検索する際にユーザーが使いそうな単語を考えてください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-207">When adding search terms, think about the words that customers might use when searching for apps like yours, especially if they're not part of your app's name.</span></span> <span data-ttu-id="a66c1-208">アプリに実際に関連しない検索語句は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="a66c1-208">Be sure not to use any search terms that are not actually relevant to your app.</span></span>

### <a name="copyright-and-trademark-info"></a><span data-ttu-id="a66c1-209">著作権と商標の情報</span><span class="sxs-lookup"><span data-stu-id="a66c1-209">Copyright and trademark info</span></span>

<span data-ttu-id="a66c1-210">その他の著作権や商標の情報を指定する場合は、ここに入力します。</span><span class="sxs-lookup"><span data-stu-id="a66c1-210">If you'd like to provide additional copyright and/or trademark info, enter it here.</span></span> <span data-ttu-id="a66c1-211">このフィールドには 200 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-211">This field has a 200 character limit.</span></span>


### <a name="additional-license-terms"></a><span data-ttu-id="a66c1-212">追加のライセンス条項</span><span class="sxs-lookup"><span data-stu-id="a66c1-212">Additional license terms</span></span>

<span data-ttu-id="a66c1-213">「**標準アプリケーション ライセンス条項**」(「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」からリンクされています) の条項に基づいて、アプリのライセンスをユーザーに付与する場合は、このフィールドを空白にします。</span><span class="sxs-lookup"><span data-stu-id="a66c1-213">Leave this field blank if you want your app to be licensed to customers under the terms of the **Standard Application License Terms** (which are linked to from the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)).</span></span>

<span data-ttu-id="a66c1-214">アプリのライセンス条項が「**標準アプリケーション ライセンス条項**」と異なる場合は、ここに入力します。</span><span class="sxs-lookup"><span data-stu-id="a66c1-214">If your license terms are different from the **Standard Application License Terms**, enter them here.</span></span>

<span data-ttu-id="a66c1-215">このフィールドに 1 つの URL を入力すると、ユーザーがクリックして追加のライセンス条項を読むことができるリンクとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-215">If you enter a single URL into this field, it will be displayed to customers as a link that they can click to read your additional license terms.</span></span> <span data-ttu-id="a66c1-216">これは、追加のライセンス条項が非常に長い場合や、追加のライセンス条項にクリック可能なリンクや書式設定を含める場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="a66c1-216">This is useful if your additional license terms are very long, or if you want to include clickable links or formatting in your additional license terms.</span></span>

<span data-ttu-id="a66c1-217">このフィールドには、最大 10,000 文字のテキストを入力することもできます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-217">You can also enter up to 10,000 characters of text in this field.</span></span> <span data-ttu-id="a66c1-218">この場合、これらの追加のライセンス条項は、ユーザーに対してプレーンテキストとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="a66c1-218">If you do that, customers will see these additional license terms displayed as plain text.</span></span>


### <a name="developed-by"></a><span data-ttu-id="a66c1-219">Developed by (開発元)</span><span class="sxs-lookup"><span data-stu-id="a66c1-219">Developed by</span></span>

<span data-ttu-id="a66c1-220">アプリのストア登録情報に **[Developed by] (開発元)** フィールドを含める場合は、ここにテキストを入力します </span><span class="sxs-lookup"><span data-stu-id="a66c1-220">Enter text here if you want to include a **Developed by** field in your app's Store listing.</span></span> <span data-ttu-id="a66c1-221">(**[Developed by] (開発元)** フィールドに値を入力していかどうかには関係なく、**[公開元]** フィールドにはアカウントに関連付けられた発行者の表示名が示されます)。</span><span class="sxs-lookup"><span data-stu-id="a66c1-221">(The **Published by** field will list the publisher display name associated with your account, whether or not you provide a value for the **Developed by** field.)</span></span>

<span data-ttu-id="a66c1-222">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="a66c1-222">This field has a 255 character limit.</span></span>
 

<span id="privacy-policy" />

> [!NOTE]
> <span data-ttu-id="a66c1-223">**[プライバシー ポリシー]**、**[Web サイト]**、**[サポートの問い合わせ先情報]** の各フィールドは、[[プロパティ]](enter-app-properties.md) ページに移動しました。</span><span class="sxs-lookup"><span data-stu-id="a66c1-223">The **Privacy policy**, **Website**, and **Support contact info** fields are now located on the [Properties](enter-app-properties.md) page.</span></span>

