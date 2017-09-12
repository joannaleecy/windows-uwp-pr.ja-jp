---
author: jnHs
Description: "アプリの申請プロセスの [ストア登録情報] セクションでは、アプリのストア登録情報に表示されるテキストと画像を指定できます。"
title: "アプリのストア登録情報の作成"
ms.assetid: 50D67219-B6C6-4EF0-B76A-926A5F24997D
ms.author: wdg-dev-content
ms.date: 08/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 004169178c906ac892865569fd2ed483bd2471fa
ms.sourcegitcommit: 6c6f3c265498d7651fcc4081c04c41fafcbaa5e7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="create-app-store-listings"></a><span data-ttu-id="40e6b-104">アプリのストア登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="40e6b-104">Create app Store listings</span></span>


<span data-ttu-id="40e6b-105">[アプリの申請プロセス](app-submissions.md)の **[ストア登録情報]** セクションでは、アプリのストア登録情報に表示されるテキストと[画像](app-screenshots-and-images.md)を指定できます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-105">The **Store listings** section of the [app submission process](app-submissions.md) is where you provide the text and [images](app-screenshots-and-images.md) that customers will see in your app's Store listing.</span></span>

> [!NOTE]
> <span data-ttu-id="40e6b-106">このページのオプションが最近更新されています。</span><span class="sxs-lookup"><span data-stu-id="40e6b-106">We have recently updated the options on this page.</span></span> <span data-ttu-id="40e6b-107">新しいオプションが提供される前に提出された処理中の申請がある場合、その申請には引き続き以前のオプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-107">If you had an in-progress submission from before the newer options were available, that submission will still show the older options.</span></span> <span data-ttu-id="40e6b-108">このようなアプリで新しいオプションを使う場合は、その申請を削除して新しい申請を作成できます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-108">You can delete that submission and then create a new one if you want to use the new options for that app.</span></span> <span data-ttu-id="40e6b-109">または、処理中の申請が公開された後、次回の更新時に新しいオプションを使用できます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-109">Otherwise, the newer options will become available with the next update after you publish your in-progress submission.</span></span>

<span data-ttu-id="40e6b-110">**[ストア登録情報]** のフィールドの多くは省略可能ですが、登録情報が目立つように複数の画像とできるだけ多くの情報を指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-110">Many of the fields in a **Store listing** are optional, but we suggest providing multiple images and as much info as possible to make your listing stand out.</span></span> <span data-ttu-id="40e6b-111">**[ストア登録情報]** 手順が完成したと見なされるには、説明のテキストと少なくとも 1 つの[スクリーンショット](app-screenshots-and-images.md#screenshots)が必要です。</span><span class="sxs-lookup"><span data-stu-id="40e6b-111">The minimum required for the **Store listings** step to be considered complete is a text description and at least one [screenshot](app-screenshots-and-images.md#screenshots).</span></span>

> [!TIP]
> <span data-ttu-id="40e6b-112">ダッシュボードで直接ストア登録情報を入力するのではなく、.csv ファイルを使ってオフラインで登録情報を入力する場合は、[ストア登録情報をインポートおよびエクスポート](import-and-export-store-listings.md)することもできます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-112">You can also [import and export Store listings](import-and-export-store-listings.md) if you'd like to enter your listing info offline in a .csv file, rather than providing this info directly in the dashboard.</span></span> <span data-ttu-id="40e6b-113">これは、多数の言語での登録情報があるときに、特に便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-113">This may be especially convenient if you have listings in many languages.</span></span>

<span data-ttu-id="40e6b-114">既定では、対象となるすべてのオペレーティング システムに同じストア登録情報 (言語ごと) が使われます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-114">By default, we'll use the same Store listing (per language) for all of your targeted operating systems.</span></span> <span data-ttu-id="40e6b-115">特定のオペレーティング システム用にカスタマイズされたストア登録情報を使う場合は、[プラットフォーム固有のストア登録情報を作成](create-platform-specific-store-listings.md)できます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-115">If you'd like to use a customized Store listing for a specific operating system, you can [create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span> <span data-ttu-id="40e6b-116">既定の登録情報は、Windows 10 のユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-116">Your default listing will always be shown to customers on Windows 10.</span></span>

## <a name="store-listing-languages"></a><span data-ttu-id="40e6b-117">ストア登録情報の言語</span><span class="sxs-lookup"><span data-stu-id="40e6b-117">Store listing languages</span></span>

<span data-ttu-id="40e6b-118">少なくとも 1 つの言語の **[ストア登録情報]** ページを完成させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-118">You must complete the **Store listing** page for at least one language.</span></span> <span data-ttu-id="40e6b-119">ストア登録情報は、パッケージでサポートしているすべての言語で提供することをお勧めしますが、ストア登録情報を提供しない言語を削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-119">We recommend providing a Store listing in each language that your packages support, but you have flexibility to remove languages for which you don’t wish to provide a Store listing.</span></span> <span data-ttu-id="40e6b-120">パッケージでサポートしていない言語のストア登録情報を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-120">You can also create Store listings in additional languages which aren’t supported by your packages.</span></span>

> [!NOTE]
> <span data-ttu-id="40e6b-121">申請にパッケージが既に含まれている場合は、パッケージでサポートされている[言語](supported-languages.md)が [申請の概要] ページに表示されます (言語を削除していない場合)。</span><span class="sxs-lookup"><span data-stu-id="40e6b-121">If your submission includes packages already, we’ll show the [languages](supported-languages.md) supported in your packages on the submission overview page (unless you remove any of them).</span></span>

<span data-ttu-id="40e6b-122">ストア登録情報の言語を追加または削除するには、申請の概要ページで **[言語の追加/削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-122">To add or remove languages for your Store listings, click **Add/remove languages** from the submission overview page.</span></span> <span data-ttu-id="40e6b-123">既にパッケージをアップロードしている場合は、**[Languages supported by your packages]** (パッケージでサポートしている言語) セクションに言語が表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-123">If you‘ve already uploaded packages, you’ll see their languages listed in the **Languages supported by your packages** section.</span></span> <span data-ttu-id="40e6b-124">これらの言語の 1 つまたは複数を削除するには、**[削除]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-124">To remove one or more of these languages, click **Remove**.</span></span> <span data-ttu-id="40e6b-125">以前にこのセクションから削除した言語を後で含める場合は、**[加算]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-125">If you later decide to include a language that you previously removed from this section, you can click **Add**.</span></span>

<span data-ttu-id="40e6b-126">**[ストア登録情報の追加言語]** セクションで、**[追加言語の管理]** をクリックして、パッケージに含まれて*いない*言語を追加するか、パッケージに含めない言語を削除します。</span><span class="sxs-lookup"><span data-stu-id="40e6b-126">In the **Additional Store listing languages** section, you can click **Manage additional languages** to add or remove languages that are *not* included in your packages.</span></span> <span data-ttu-id="40e6b-127">追加する言語のチェック ボックスをクリックし、**[更新]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-127">Check the boxes for the languages that you’d like to add, then click **Update**.</span></span> <span data-ttu-id="40e6b-128">選択した言語が **[ストア登録情報の追加言語]** セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-128">The languages you’ve selected will be displayed in the **Additional Store listing languages** section.</span></span> <span data-ttu-id="40e6b-129">1 つまたは複数の言語を削除するには、**[削除]** をクリックします (または、**[追加言語の管理]** をクリックし、削除する言語のチェック ボックスをオフにします)。</span><span class="sxs-lookup"><span data-stu-id="40e6b-129">To remove one or more of these languages, click **Remove** (or click **Manage additional languages** and uncheck the box for languages you’d like to remove).</span></span>

<span data-ttu-id="40e6b-130">選択が終了したら **[保存]** をクリックして、申請の概要ページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-130">When you have finished making your selections, click **Save** to return to the submission overview page.</span></span>

> [!NOTE]
> <span data-ttu-id="40e6b-131">パッケージでサポートしていない言語のストア登録情報を作成するときは、そのストア登録情報に表示する予約済みのアプリ名を指定する必要があります。その言語のパッケージが関連付けられておらず、名前を取得できないためです。</span><span class="sxs-lookup"><span data-stu-id="40e6b-131">When creating a Store listing in a language that isn't supported by your packages, you'll need to indicate which of your reserved app names should be displayed in that Store listing, since there isn't an associated package in that language from which to pull the name.</span></span> <span data-ttu-id="40e6b-132">ここで選んだ名前は、この言語のストア登録情報にのみ適用され、ユーザーがアプリをインストールするときに表示される名前には影響しません。</span><span class="sxs-lookup"><span data-stu-id="40e6b-132">The name you choose here only applies to the Store listing for this language and does not impact the name displayed when a customer installs the app.</span></span>

<span data-ttu-id="40e6b-133">ストア登録情報を編集するには、申請の概要ページで言語名をクリックします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-133">To edit a Store listing, click the language name from the submission overview page.</span></span>

<span data-ttu-id="40e6b-134">**[ストア登録情報]** ページの上部には、選択した言語の既定のストア登録情報に関連付けられたフィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-134">At the top of the **Store listing** page are the fields associated with your default Store listing for the selected language.</span></span> <span data-ttu-id="40e6b-135">以前の OS バージョン (Windows 8.x 以前、Windows Phone 8.x 以前) を対象とするパッケージがあり、指定された OS バージョンのユーザーに表示する別のスクリーン ショットまたは情報を含むプラットフォームに固有のストア登録情報を作成している場合を除き、これらのフィールドはすべてのユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-135">These fields will be shown to all of your customers, unless you have packages targeting earlier OS versions (Windows 8.x or earlier; Windows Phone 8.x or earlier) and create platform-specific Store listings to include different screenshots or info to display to customers on specified OS versions.</span></span> <span data-ttu-id="40e6b-136">詳しくは、「[プラットフォーム固有のストア登録情報の作成](create-platform-specific-store-listings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-136">For more info, see [Create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span>

## <a name="description"></a><span data-ttu-id="40e6b-137">説明</span><span class="sxs-lookup"><span data-stu-id="40e6b-137">Description</span></span>

<span data-ttu-id="40e6b-138">説明フィールドでは、アプリの内容をユーザーに伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-138">The description field is where you can tell customers what your app does.</span></span> <span data-ttu-id="40e6b-139">このフィールドは必須であり、最大 10,000 文字のプレーンテキストを入力できます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-139">This field is required, and will accept up to 10,000 characters of plain text.</span></span>

<span data-ttu-id="40e6b-140">説明を目立たせるためのヒントについては、「[人の心をつかむアプリの説明を書く](write-a-great-app-description.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-140">For some tips on making your description stand out, see [Write a great app description](write-a-great-app-description.md).</span></span>

## <a name="release-notes"></a><span data-ttu-id="40e6b-141">リリース ノート</span><span class="sxs-lookup"><span data-stu-id="40e6b-141">Release notes</span></span>

<span data-ttu-id="40e6b-142">初めてアプリを申請する場合、通常このフィールドは空白のままにします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-142">If this is the first time you're submitting your app, you'll probably want to leave this field blank.</span></span> <span data-ttu-id="40e6b-143">既存のアプリの更新の場合、ここには最新のリリースでの変更点をユーザーに知らせることができます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-143">For an update to an existing app, this is where you can let customer know what's changed in the latest release.</span></span> <span data-ttu-id="40e6b-144">このフィールドには 1,500 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-144">This field has a 1500 character limit.</span></span>

## <a name="screenshots"></a><span data-ttu-id="40e6b-145">スクリーンショット</span><span class="sxs-lookup"><span data-stu-id="40e6b-145">Screenshots</span></span>

<span data-ttu-id="40e6b-146">アプリを提出するには、少なくとも 1 つのスクリーンショットが必要です。</span><span class="sxs-lookup"><span data-stu-id="40e6b-146">One screenshot is required in order to submit your app.</span></span> <span data-ttu-id="40e6b-147">アプリがサポートするデバイスの種類ごとに、1 つ以上のスクリーンショットを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-147">We recommend providing at least one screenshot for each device type that your app supports.</span></span>

<span data-ttu-id="40e6b-148">詳しくは、「[アプリのスクリーンショットと画像](app-screenshots-and-images.md#screenshots)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-148">For more info, see [App screenshots and images](app-screenshots-and-images.md#screenshots).</span></span>

## <a name="store-logos"></a><span data-ttu-id="40e6b-149">ストア ロゴ</span><span class="sxs-lookup"><span data-stu-id="40e6b-149">Store logos</span></span> 

<span data-ttu-id="40e6b-150">ストア ロゴは、アプリの情報をより適切にユーザーに表示するためにアップロードできるオプションの画像です。</span><span class="sxs-lookup"><span data-stu-id="40e6b-150">Store logos are optional images that you can upload to enhance the way your app is displayed to customers.</span></span> <span data-ttu-id="40e6b-151">必要に応じて、ここでアップロードした画像を Windows 10 ユーザー向けのアプリのストア登録情報に使うように指定して、アプリのパッケージからのロゴ画像がストアで使われないようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-151">You can also optionally specify that only images you upload here should be used in your app’s Store listing for Windows 10 customers, rather than allowing the Store to use logo images from your app’s packages.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="40e6b-152">アプリが Xbox をサポートしている場合、または Windows Phone 8.1 以前をサポートしている場合、ストアで登録情報が適切に表示されるようにするには、ここで特定の画像を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-152">If your app supports Xbox, or if it supports Windows Phone 8.1 or earlier, you must provide certain images here in order for the listing to appear properly in the Store.</span></span> 

<span data-ttu-id="40e6b-153">詳しくは、「[ストア ロゴ](app-screenshots-and-images.md#store-logos)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-153">For more info, see [Store logos](app-screenshots-and-images.md#store-logos).</span></span>

## <a name="additional-art-assets"></a><span data-ttu-id="40e6b-154">追加のアート資産</span><span class="sxs-lookup"><span data-stu-id="40e6b-154">Additional art assets</span></span>

<span data-ttu-id="40e6b-155">トレーラーやプロモーション用の画像など、製品用の追加の資産を提出することができます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-155">You can submit additional assets for your product, including trailers and promotional images.</span></span> <span data-ttu-id="40e6b-156">これらはいずれも省略可能ですが、できるだけ多くの資産のアップロードを検討することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-156">These are all optional, but we recommend that you consider uploading as many of them as possible.</span></span> <span data-ttu-id="40e6b-157">これらの画像は、より魅力的な登録情報を作成し、製品がどのようなものかをユーザーに知ってもらうために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-157">These images can help give customers a better idea of what your product is and make a more enticing listing.</span></span>

<span data-ttu-id="40e6b-158">詳しくは、「[追加のアート資産](app-screenshots-and-images.md#additional-art-assets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-158">For more info, see [Additional art assets](app-screenshots-and-images.md#additional-art-assets).</span></span>

## <a name="additional-information"></a><span data-ttu-id="40e6b-159">追加情報</span><span class="sxs-lookup"><span data-stu-id="40e6b-159">Additional information</span></span>

<span data-ttu-id="40e6b-160">このセクションのフィールドはいずれも省略可能ですが、アプリの機能や最適なエクスペリエンスのための要件をユーザーに理解してもらうために使用できます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-160">The fields in this section are all optional, but can be used to help customers understand more about what your app does and what is required for the best experience.</span></span> <span data-ttu-id="40e6b-161">以下に説明するオプションをよく確認し、アプリについてユーザーが知っておく必要のある情報や、アプリをダウンロードしたくなるような情報を入力することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-161">We suggest reviewing the options described below and providing any information that customers might need to know about your app, or that could help entice them to download it.</span></span>

### <a name="app-features"></a><span data-ttu-id="40e6b-162">アプリの機能</span><span class="sxs-lookup"><span data-stu-id="40e6b-162">App features</span></span>

<span data-ttu-id="40e6b-163">アプリの主な機能の短い概要です。</span><span class="sxs-lookup"><span data-stu-id="40e6b-163">These are short summaries of your app's key features.</span></span> <span data-ttu-id="40e6b-164">これらは、アプリのストア登録情報に、説明と共に箇条書きの形式で表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-164">They are displayed to the customer as a bulleted list in your app's Store listing, in addition to the Description.</span></span> <span data-ttu-id="40e6b-165">機能ごとに、簡潔な 1 文 (200 文字未満) になるようにまとめます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-165">Keep these brief, with just a few words (and no more than 200 characters) per feature.</span></span> <span data-ttu-id="40e6b-166">最大 20 の機能を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-166">You may include up to 20 features.</span></span>

> [!NOTE]
> <span data-ttu-id="40e6b-167">アプリの機能は、ストア登録情報に箇条書きの項目として表示されるため、独自に行頭文字を追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-167">Your app features will appear bulleted in your Store listing, so don't add your own bullets.</span></span>

### <a name="additional-system-requirements"></a><span data-ttu-id="40e6b-168">追加のシステム要件</span><span class="sxs-lookup"><span data-stu-id="40e6b-168">Additional system requirements</span></span>

<span data-ttu-id="40e6b-169">必要に応じて、アプリが正常に動作するうえで必要となるハードウェア構成を記述できます ([アプリのプロパティ](enter-app-properties.md#system-requirements)の **[システム必要条件]** セクションに指定した情報以外)。</span><span class="sxs-lookup"><span data-stu-id="40e6b-169">If needed, you can describe the hardware configurations that your app requires to work properly (beyond the info you provided in the **System requirements** section in [App properties](enter-app-properties.md#system-requirements).</span></span> <span data-ttu-id="40e6b-170">この情報は、一部のコンピューターでしか使うことができないハードウェアが必要なアプリの場合、特に重要です。</span><span class="sxs-lookup"><span data-stu-id="40e6b-170">This is especially important if your app requires hardware that might not be available on every computer.</span></span>

<span data-ttu-id="40e6b-171">**[最小ハードウェア要件]** と **[推奨されるハードウェア]** の両方に最大 11 個の項目を入力できます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-171">You can enter up to 11 items for both **Minimum hardware** and **Recommended hardware**.</span></span>  <span data-ttu-id="40e6b-172">これらは、アプリの登録情報に箇条書きの形式で表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-172">They are displayed to the customer as a bulleted list in your app's listing.</span></span> <span data-ttu-id="40e6b-173">各項目につき短い 1 文 (かつ、200 文字未満) になるようにまとめます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-173">Keep these brief, with just a few words (and no more than 200 characters) per item.</span></span>

<span data-ttu-id="40e6b-174">ここに入力した情報は、製品のプロパティ ページで指定した要件と共に、Windows 10 バージョン 1607 以降でアプリのストア登録情報を表示するユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-174">The info you enter here will be shown to customers viewing your app's Store listing on Windows 10, version 1607 or later, along with the requirements you indicated on the product's properties page.</span></span>

> [!NOTE]
> <span data-ttu-id="40e6b-175">追加のシステム要件は、ストア登録情報に箇条書きの項目として表示されるため、独自に行頭文字を追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-175">Your additional system requirements will appear bulleted in your Store listing, so don't add your own bullets.</span></span>

### <a name="developed-by"></a><span data-ttu-id="40e6b-176">Developed by (開発元)</span><span class="sxs-lookup"><span data-stu-id="40e6b-176">Developed by</span></span>

<span data-ttu-id="40e6b-177">アプリのストア登録情報に **[Developed by] (開発元)** フィールドを含める場合は、ここにテキストを入力します </span><span class="sxs-lookup"><span data-stu-id="40e6b-177">Enter text here if you want to include a **Developed by** field in your app's Store listing.</span></span> <span data-ttu-id="40e6b-178">(**[Developed by] (開発元)** フィールドに値を入力していかどうかには関係なく、**[公開元]** フィールドにはアカウントに関連付けられた発行者の表示名が示されます)。</span><span class="sxs-lookup"><span data-stu-id="40e6b-178">(The **Published by** field will list the publisher display name associated with your account, whether or not you provide a value for the **Developed by** field.)</span></span>

<span data-ttu-id="40e6b-179">このフィールドには 255 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-179">This field has a 255 character limit.</span></span>


## <a name="shared-fields"></a><span data-ttu-id="40e6b-180">共有フィールド</span><span class="sxs-lookup"><span data-stu-id="40e6b-180">Shared fields</span></span>

<span data-ttu-id="40e6b-181">以下に説明する項目は、ユーザーにとって製品を見つけやすくしたり、製品の理解を助けたりするために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-181">The items described below help customers discover and understand your product.</span></span> <span data-ttu-id="40e6b-182">ここで入力した情報は、[プラットフォーム固有のストア登録情報を作成](create-platform-specific-store-listings.md)した場合でも、オペレーティング システムに関係なく、指定の言語のすべてのストア登録情報に適用されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-182">The info you enter here will apply to all of your Store listings in a given language, regardless of operating system, even if you [create platform-specific Store listings](create-platform-specific-store-listings.md).</span></span>

### <a name="search-terms"></a><span data-ttu-id="40e6b-183">検索語句</span><span class="sxs-lookup"><span data-stu-id="40e6b-183">Search terms</span></span>

<span data-ttu-id="40e6b-184">検索語句は (以前はキーワードと呼ばれていました)、ユーザーには表示されない単語または短いフレーズで、語句に関連する検索結果にアプリが表示されるようにするものです。</span><span class="sxs-lookup"><span data-stu-id="40e6b-184">Search terms (formerly called keywords) are single words or short phrases that are not displayed to customers, but can help your app appear in search results related to the term.</span></span> <span data-ttu-id="40e6b-185">最大 7 個の検索語句を含めることができ、それぞれの語句の最大長は 30 文字です。すべての検索語句を合わせて使用できる個々の単語の数は 21 個までです。</span><span class="sxs-lookup"><span data-stu-id="40e6b-185">You can include up to 7 search terms with a maximum of 30 characters each, and can use no more than 21 separate words across all search terms.</span></span>

<span data-ttu-id="40e6b-186">検索語句を追加するとき、特にアプリ名の一部ではない語句を追加する場合は、同様のアプリを検索する際にユーザーが使いそうな単語を考えてください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-186">When adding search terms, think about the words that customers might use when searching for apps like yours, especially if they're not part of your app's name.</span></span> <span data-ttu-id="40e6b-187">アプリに実際に関連しない検索語句は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-187">Be sure not to use any search terms that are not actually relevant to your app.</span></span>


### <a name="privacy-policy"></a><span data-ttu-id="40e6b-188">プライバシー ポリシー</span><span class="sxs-lookup"><span data-stu-id="40e6b-188">Privacy policy</span></span>

<span data-ttu-id="40e6b-189">アプリのプライバシー ポリシーがある場合は、ここに URL を入力します。</span><span class="sxs-lookup"><span data-stu-id="40e6b-189">If you have a privacy policy for your app, enter its URL here.</span></span> <span data-ttu-id="40e6b-190">開発者は、アプリをプライバシーに関する法令と規制に準拠させ、必要に応じてプライバシー ポリシーを提供する責任があります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-190">You are responsible for ensuring your app complies with privacy laws and regulations, and for providing a privacy policy, if required.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="40e6b-191">Microsoft では、アプリ用の既定のプライバシー ポリシーは用意していません。</span><span class="sxs-lookup"><span data-stu-id="40e6b-191">Microsoft doesn't provide a default privacy policy for your app.</span></span> <span data-ttu-id="40e6b-192">同様に、アプリは Microsoft のプライバシー ポリシーの対象にはなりません。</span><span class="sxs-lookup"><span data-stu-id="40e6b-192">Likewise, your app is not covered by any Microsoft privacy policy.</span></span> <span data-ttu-id="40e6b-193">アプリにプライバシー ポリシーが必要かどうかを確認するには、「[アプリ開発者契約](https://msdn.microsoft.com/library/windows/apps/hh694058)」と「[Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#pol_10_5_1)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40e6b-193">To determine if your app requires a privacy policy, review the [App Developer Agreement](https://msdn.microsoft.com/library/windows/apps/hh694058) and the [Windows Store Policies](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#pol_10_5_1).</span></span>

### <a name="copyright-and-trademark-info"></a><span data-ttu-id="40e6b-194">著作権と商標の情報</span><span class="sxs-lookup"><span data-stu-id="40e6b-194">Copyright and trademark info</span></span>

<span data-ttu-id="40e6b-195">その他の著作権や商標の情報を指定する場合は、ここに入力します。</span><span class="sxs-lookup"><span data-stu-id="40e6b-195">If you'd like to provide additional copyright and/or trademark info, enter it here.</span></span> <span data-ttu-id="40e6b-196">このフィールドには 200 文字の制限があります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-196">This field has a 200 character limit.</span></span>

### <a name="additional-license-terms"></a><span data-ttu-id="40e6b-197">追加のライセンス条項</span><span class="sxs-lookup"><span data-stu-id="40e6b-197">Additional license terms</span></span>

<span data-ttu-id="40e6b-198">「**標準アプリケーション ライセンス条項**」(「[アプリ開発者契約](https://msdn.microsoft.com/library/windows/apps/hh694058)」からリンクされています) の条項に基づいて、アプリのライセンスをユーザーに付与する場合は、このフィールドを空白にします。</span><span class="sxs-lookup"><span data-stu-id="40e6b-198">Leave this field blank if you want your app to be licensed to customers under the terms of the **Standard Application License Terms** (which are linked to from the [App Developer Agreement](https://msdn.microsoft.com/library/windows/apps/hh694058)).</span></span>

<span data-ttu-id="40e6b-199">アプリのライセンス条項が「**標準アプリケーション ライセンス条項**」と異なる場合は、ここに入力します。</span><span class="sxs-lookup"><span data-stu-id="40e6b-199">If your license terms are different from the **Standard Application License Terms**, enter them here.</span></span>

<span data-ttu-id="40e6b-200">このフィールドに 1 つの URL を入力すると、ユーザーがクリックして追加のライセンス条項を読むことができるリンクとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-200">If you enter a single URL into this field, it will be displayed to customers as a link that they can click to read your additional license terms.</span></span> <span data-ttu-id="40e6b-201">これは、追加のライセンス条項が非常に長い場合や、追加のライセンス条項にクリック可能なリンクや書式設定を含める場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="40e6b-201">This is useful if your additional license terms are very long, or if you want to include clickable links or formatting in your additional license terms.</span></span>

<span data-ttu-id="40e6b-202">このフィールドには、最大 10,000 文字のテキストを入力することもできます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-202">You can also enter up to 10,000 characters of text in this field.</span></span> <span data-ttu-id="40e6b-203">この場合、これらの追加のライセンス条項は、ユーザーに対してプレーンテキストとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="40e6b-203">If you do that, customers will see these additional license terms displayed as plain text.</span></span>

### <a name="website"></a><span data-ttu-id="40e6b-204">Web サイト</span><span class="sxs-lookup"><span data-stu-id="40e6b-204">Website</span></span>

<span data-ttu-id="40e6b-205">アプリの Web ページの URL を入力します。</span><span class="sxs-lookup"><span data-stu-id="40e6b-205">Enter the URL of the web page for your app.</span></span> <span data-ttu-id="40e6b-206">この URL は、ストアのアプリの登録情報 Web ページではなく、独自の Web サイトのページを指すものにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="40e6b-206">This URL must point to a page on your own website, not your app's web listing in the Store.</span></span>

### <a name="support-contact-info"></a><span data-ttu-id="40e6b-207">サポートの問い合わせ先情報</span><span class="sxs-lookup"><span data-stu-id="40e6b-207">Support contact info</span></span>

<span data-ttu-id="40e6b-208">アプリのサポートをユーザーに提供する Web ページの URL、またはユーザーがサポートに連絡するためのメール アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="40e6b-208">Enter the URL of the web page where your customers can go for support on your app, or an email address that customers can contact for support.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="40e6b-209">Microsoft は、アプリのサポートをユーザーに提供することはありません。</span><span class="sxs-lookup"><span data-stu-id="40e6b-209">Microsoft doesn't provide your customers with support for your app.</span></span>

