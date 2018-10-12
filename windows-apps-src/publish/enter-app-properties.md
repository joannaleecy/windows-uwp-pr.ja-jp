---
author: jnHs
Description: The App properties page of the app submission process lets you define your app's category and indicate hardware preferences or other declarations.
title: アプリのプロパティの入力
ms.assetid: CDE4AF96-95A0-4635-9D07-A27B810CAE26
ms.author: wdg-dev-content
ms.date: 08/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, ゲーム設定, 表示モード, システム要件, ハードウェア要件, 最小ハードウェア, 推奨されるハードウェア, プライバシー ポリシー, サポートの問い合わせ先情報, アプリ Web サイト, サポート情報
ms.localizationpriority: medium
ms.openlocfilehash: d23fb0cb3fb4668682df1957cbf0c88bcf8649c1
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4568798"
---
# <a name="enter-app-properties"></a><span data-ttu-id="d4684-103">アプリのプロパティの入力</span><span class="sxs-lookup"><span data-stu-id="d4684-103">Enter app properties</span></span>

<span data-ttu-id="d4684-104">[アプリの申請プロセス](app-submissions.md)の **[プロパティ]** ページでは、アプリのカテゴリを定義し、他の情報や宣言を入力します。</span><span class="sxs-lookup"><span data-stu-id="d4684-104">The **Properties** page of the [app submission process](app-submissions.md) is where you define your app's category and enter other info and declarations.</span></span> <span data-ttu-id="d4684-105">このページでは、アプリに関する完全な詳細情報を正確に指定してください。</span><span class="sxs-lookup"><span data-stu-id="d4684-105">Be sure to provide complete and accurate details about your app on this page.</span></span>


## <a name="category-and-subcategory"></a><span data-ttu-id="d4684-106">カテゴリとサブカテゴリ</span><span class="sxs-lookup"><span data-stu-id="d4684-106">Category and subcategory</span></span>

<span data-ttu-id="d4684-107">Microsoft Store でアプリの分類に使うカテゴリを (該当する場合はサブカテゴリ/ジャンルも) 示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d4684-107">You must indicate the category (and subcategory/genre, if applicable) which the Store should use to categorize your app.</span></span> <span data-ttu-id="d4684-108">アプリを提出するには、カテゴリを指定することが必要です。</span><span class="sxs-lookup"><span data-stu-id="d4684-108">Specifying a category is required in order to submit your app.</span></span>

<span data-ttu-id="d4684-109">詳しくは、「[カテゴリとサブカテゴリの一覧](category-and-subcategory-table.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d4684-109">For more info, see [Category and subcategory table](category-and-subcategory-table.md).</span></span>


## <a name="support-info"></a><span data-ttu-id="d4684-110">サポート情報</span><span class="sxs-lookup"><span data-stu-id="d4684-110">Support info</span></span>

<span data-ttu-id="d4684-111">このセクションでは、ユーザーがアプリの詳細とサポートを受ける方法について理解するのに役立つ情報を入力できます。</span><span class="sxs-lookup"><span data-stu-id="d4684-111">This section lets you provide info to help customers understand more about your app and how to get support.</span></span>

### <a name="privacy-policy-url"></a><span data-ttu-id="d4684-112">プライバシー ポリシーの URL</span><span class="sxs-lookup"><span data-stu-id="d4684-112">Privacy policy URL</span></span>

<span data-ttu-id="d4684-113">開発者は、アプリをプライバシーに関する法令と規制に準拠させ、必要に応じてプライバシー ポリシーの有効な URL をここで提供する責任があります。</span><span class="sxs-lookup"><span data-stu-id="d4684-113">You are responsible for ensuring your app complies with privacy laws and regulations, and for providing a valid privacy policy URL here if required.</span></span>

<span data-ttu-id="d4684-114">このセクションでは、アプリが[個人情報](https://docs.microsoft.com/legal/windows/agreements/store-policies#105-personal-information)へのアクセス、収集、送信を行うかどうかを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d4684-114">In this section, you must indicate whether or not your app accesses, collects, or transmits any [personal information](https://docs.microsoft.com/legal/windows/agreements/store-policies#105-personal-information).</span></span> <span data-ttu-id="d4684-115">**[はい]** と回答した場合、プライバシー ポリシーの URL が必要です。</span><span class="sxs-lookup"><span data-stu-id="d4684-115">If you answer **Yes**, a privacy policy URL is required.</span></span> <span data-ttu-id="d4684-116">それ以外の場合、これは任意です (ただし、アプリにプライバシー ポリシーが必要と判断されたが、用意されていない場合、申請が認定に合格しない可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="d4684-116">Otherwise, it is optional (though if we determine that your app requires a privacy policy, and you have not provided one, your submission may fail certification).</span></span>

> [!NOTE]
> <span data-ttu-id="d4684-117">個人情報へのアクセス、送信、収集を許可する可能性がある[機能](../packaging/app-capability-declarations.md)をパッケージが宣言していることが検出された場合、この質問が **[はい]** とマークされ、プライバシー ポリシーの URL の入力が必須になります。</span><span class="sxs-lookup"><span data-stu-id="d4684-117">If we detect that your packages declare [capabilities](../packaging/app-capability-declarations.md) that could allow personal information to be accessed, transmitted, or collected, we will mark this question as **Yes**, and you will be required to enter a privacy policy URL.</span></span>

<span data-ttu-id="d4684-118">アプリにプライバシー ポリシーが必要かどうかを確認するには、「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」と「[Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies#105-personal-information)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d4684-118">To help you determine if your app requires a privacy policy, review the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement) and the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies#105-personal-information).</span></span> 

> [!NOTE]
> <span data-ttu-id="d4684-119">Microsoft では、アプリ用の既定のプライバシー ポリシーは用意していません。</span><span class="sxs-lookup"><span data-stu-id="d4684-119">Microsoft doesn't provide a default privacy policy for your app.</span></span> <span data-ttu-id="d4684-120">同様に、アプリは Microsoft のプライバシー ポリシーの対象にはなりません。</span><span class="sxs-lookup"><span data-stu-id="d4684-120">Likewise, your app is not covered by any Microsoft privacy policy.</span></span> 


### <a name="website"></a><span data-ttu-id="d4684-121">Web サイト</span><span class="sxs-lookup"><span data-stu-id="d4684-121">Website</span></span>

<span data-ttu-id="d4684-122">アプリの Web ページの URL を入力します。</span><span class="sxs-lookup"><span data-stu-id="d4684-122">Enter the URL of the web page for your app.</span></span> <span data-ttu-id="d4684-123">この URL は、Microsoft Store のアプリの登録情報 Web ページではなく、独自の Web サイトのページを指すものにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d4684-123">This URL must point to a page on your own website, not your app's web listing in the Store.</span></span> <span data-ttu-id="d4684-124">このフィールドは任意ですが、使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d4684-124">This field is optional, but recommended.</span></span>

### <a name="support-contact-info"></a><span data-ttu-id="d4684-125">サポートの問い合わせ先情報</span><span class="sxs-lookup"><span data-stu-id="d4684-125">Support contact info</span></span>

<span data-ttu-id="d4684-126">アプリのサポートをユーザーに提供する Web ページの URL、またはユーザーがサポートに連絡するためのメール アドレスを入力します。</span><span class="sxs-lookup"><span data-stu-id="d4684-126">Enter the URL of the web page where your customers can go for support with your app, or an email address that customers can contact for support.</span></span> <span data-ttu-id="d4684-127">ユーザーが必要な場合にサポートを受ける方法を知ることができるように、すべての申請にこの情報を含めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d4684-127">We recommend including this info for all submissions, so that your customers know how to get support if they need it.</span></span> <span data-ttu-id="d4684-128">Microsoft がアプリのサポートをユーザーに提供することはない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="d4684-128">Note that Microsoft does not provide your customers with support for your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d4684-129">**[サポートの問い合わせ先情報]** フィールドは、アプリやゲームが Xbox で使用可能な場合に必須です。</span><span class="sxs-lookup"><span data-stu-id="d4684-129">The **Support contact info** field is required if your app or game is available on Xbox.</span></span> <span data-ttu-id="d4684-130">それ以外の場合、これは任意です (ただし、推奨されます)。</span><span class="sxs-lookup"><span data-stu-id="d4684-130">Otherwise, it is optional (but recommended).</span></span>


## <a name="game-settings"></a><span data-ttu-id="d4684-131">ゲーム設定</span><span class="sxs-lookup"><span data-stu-id="d4684-131">Game settings</span></span>

<span data-ttu-id="d4684-132">このセクションは、製品のカテゴリとして **[ゲーム]** を選択した場合にのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="d4684-132">This section will only appear if you selected **Games** as your product’s category.</span></span> <span data-ttu-id="d4684-133">ここでは、ゲームがサポートしている機能を指定できます。</span><span class="sxs-lookup"><span data-stu-id="d4684-133">Here you can specify which features your game supports.</span></span> <span data-ttu-id="d4684-134">このセクションで指定した情報はすべて、製品のストア登録情報に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d4684-134">All of the information that you provide in this section will be displayed on the product’s Store listing.</span></span>

<span data-ttu-id="d4684-135">ゲームでマルチプレイヤー オプションのいずれかをサポートしている場合は、セッションあたりの最小プレイヤー数と最大プレイヤー数を指定してください。</span><span class="sxs-lookup"><span data-stu-id="d4684-135">If your game supports any of the multiplayer options, be sure to indicate the minimum and maximum number of players for a session.</span></span> <span data-ttu-id="d4684-136">最小または最大のプレイヤー数として 1,000 人より大きい値を入力することはできません。</span><span class="sxs-lookup"><span data-stu-id="d4684-136">You can't enter more than 1,000 minimum or maximum players.</span></span>

<span data-ttu-id="d4684-137">**[クロスプラットフォーム マルチプレイヤー]** は、ゲームが Windows 10 PC と Xbox のプレイヤー間のマルチプレイヤー セッションをサポートしていることを示します。</span><span class="sxs-lookup"><span data-stu-id="d4684-137">**Cross-platform multiplayer** means that the game supports multiplayer sessions between players on Windows 10 PCs and Xbox.</span></span>


## <a name="display-mode"></a><span data-ttu-id="d4684-138">表示モード</span><span class="sxs-lookup"><span data-stu-id="d4684-138">Display mode</span></span>

<span data-ttu-id="d4684-139">このセクションでは、PC または HoloLens デバイス、あるいはその両方で、[Windows Mixed Reality](https://developer.microsoft.com/windows/mixed-reality) の (2D 表示でなく) イマーシブ ビューでの実行用に製品が設計されているかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="d4684-139">This section lets you indicate whether your product is designed to run in an immersive (not a 2D) view for [Windows Mixed Reality](https://developer.microsoft.com/windows/mixed-reality) on PC and/or HoloLens devices.</span></span> <span data-ttu-id="d4684-140">該当する場合は、次の操作も必要になります。</span><span class="sxs-lookup"><span data-stu-id="d4684-140">If you indicate that it is, you'll also need to:</span></span>
- <span data-ttu-id="d4684-141">**[プロパティ]** ページの後半に表示される [[システム要件]](#system-requirements) セクションで、**[Windows Mixed Reality イマーシブ ヘッドセット]** について **[最小ハードウェア要件]** または **[推奨されるハードウェア]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="d4684-141">Select either **Minimum hardware** or **Recommended hardware** for **Windows Mixed Reality immersive headset** in the [System requirements](#system-requirements) section that appears lower on the **Properties** page.</span></span>
- <span data-ttu-id="d4684-142">PC を選択した場合は、アプリを座った状態のみまたは立った状態のみで使用するのか、使用中にさまざまな場所に移動できる (または移動する必要がある) のかをユーザーが判断できるように、**[境界線のセットアップ]** も指定します。</span><span class="sxs-lookup"><span data-stu-id="d4684-142">Specify the **Boundary setup** (if PC is selected) so that users know whether it's meant to be used in a seated or standing position only, or whether it allows (or requires) the user to move around while using it.</span></span> 

<span data-ttu-id="d4684-143">製品のカテゴリとして **[ゲーム]** を選択した場合は、**[表示モード]** に追加のオプションが表示されます。ここでは、4K 解像度のビデオ出力、ハイ ダイナミック レンジ (HDR) のビデオ出力、可変リフレッシュ レートの表示を製品がサポートしているかどうかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="d4684-143">If you have selected **Games** as your product's category, you'll see additional options in the **Display mode** selection that let you indicate whether your product supports 4K resolution video output, High Dynamic Range (HDR) video output, or variable refresh rate displays.</span></span>

<span data-ttu-id="d4684-144">製品がこれらの表示モード オプションをサポートしていない場合は、すべてのチェック ボックスをオフにしておきます。</span><span class="sxs-lookup"><span data-stu-id="d4684-144">If your product does not support any of these display mode options, leave all of the boxes unchecked.</span></span>


## <a name="product-declarations"></a><span data-ttu-id="d4684-145">製品の宣言</span><span class="sxs-lookup"><span data-stu-id="d4684-145">Product declarations</span></span>

<span data-ttu-id="d4684-146">アプリにいずれかの宣言を適用するかどうかを指定するには、このセクションのチェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="d4684-146">You can check boxes in this section to indicate if any of the declarations apply to your app.</span></span> <span data-ttu-id="d4684-147">これは、アプリがどのように表示されるか、特定のユーザーに提供されるかどうか、またはユーザーがアプリをどのように使うことができるかに影響を与える可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d4684-147">This may affect the way your app is displayed, whether it is offered to certain customers, or how customers can use it.</span></span>

<span data-ttu-id="d4684-148">詳しくは、「[製品の宣言](app-declarations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d4684-148">For more info, see [Product declarations](app-declarations.md).</span></span>

## <a name="system-requirements"></a><span data-ttu-id="d4684-149">システム要件</span><span class="sxs-lookup"><span data-stu-id="d4684-149">System requirements</span></span>

<span data-ttu-id="d4684-150">このセクションには、アプリを正常に実行して操作するために特定のハードウェア機能が必要かどうか、または推奨されているかどうかを指定するオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="d4684-150">In this section, you have the option to indicate if certain hardware features are required or recommended to run and interact with your app properly.</span></span> <span data-ttu-id="d4684-151">各ハードウェア項目を **[最小ハードウェア]** か **[推奨されるハードウェア]** (またはその両方) として指定するチェック ボックスをオンにできます (または該当するオプションを指定できます)。</span><span class="sxs-lookup"><span data-stu-id="d4684-151">You can check the box (or indicate the appropriate option) for each hardware item where you would like to specify **Minimum hardware** and/or **Recommended hardware**.</span></span>

<span data-ttu-id="d4684-152">**[推奨されるハードウェア]** を選択すると、製品のストア登録情報で、Windows 10 バージョン 1607 以降のユーザーに対し、それらの項目は推奨されるハードウェアとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="d4684-152">If you make selections for **Recommended hardware**, those items will be displayed in your product's Store listing as recommended hardware for customers on Windows 10, version 1607 or later.</span></span> <span data-ttu-id="d4684-153">それより前の OS バージョンのユーザーには、この情報は表示されません。</span><span class="sxs-lookup"><span data-stu-id="d4684-153">Customers on earlier OS versions will not see this info.</span></span>

<span data-ttu-id="d4684-154">**[最小ハードウェア]** を選択すると、製品のストア登録情報で、Windows 10 バージョン 1607 以降のユーザーに対し、それらの項目は必須ハードウェアとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="d4684-154">If you make selections for **Minimum hardware**, those items will be displayed in your product's Store listing as required hardware for customers on Windows 10, version 1607 or later.</span></span> <span data-ttu-id="d4684-155">それより前の OS バージョンのユーザーには、この情報は表示されません。</span><span class="sxs-lookup"><span data-stu-id="d4684-155">Customers on earlier OS versions will not see this info.</span></span> <span data-ttu-id="d4684-156">また、ストアでは、必須ハードウェアのないデバイスでアプリの登録情報を表示しているユーザーに対して警告を表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d4684-156">The Store may also display a warning to customers who are viewing your app's listing on a device that doesn’t have the required hardware.</span></span> <span data-ttu-id="d4684-157">これによって該当するハードウェアを持っていないデバイスへのアプリのダウンロードができなくなることはありませんが、それらのデバイスではアプリの評価をしたりレビューを書いたりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="d4684-157">This won't prevent people from downloading your app on devices that don't have the appropriate hardware, but they won't be able to rate or review your app on those devices.</span></span> 

<span data-ttu-id="d4684-158">ユーザーの動作は、特定の要件とユーザーの Windows のバージョンによって次のように異なります。</span><span class="sxs-lookup"><span data-stu-id="d4684-158">The behavior for customers will vary depending on the specific requirements and the customer's version of Windows:</span></span>

- **<span data-ttu-id="d4684-159">Windows 10 バージョン 1607 以降のユーザー:</span><span class="sxs-lookup"><span data-stu-id="d4684-159">For customers on Windows 10, version 1607 or later:</span></span>**
     - <span data-ttu-id="d4684-160">ストア登録情報に、最小要件と推奨要件のすべてが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d4684-160">All minimum and recommended requirements will be displayed in the Store listing.</span></span>
     - <span data-ttu-id="d4684-161">ストアによってすべての最小要件がチェックされ、要件を満たさないデバイスでは警告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d4684-161">The Store will check for all minimum requirements and will display a warning to customers on a device that doesn't meet the requirements.</span></span>
- **<span data-ttu-id="d4684-162">それより前のバージョンの Windows 10 のユーザー:</span><span class="sxs-lookup"><span data-stu-id="d4684-162">For customers on earlier versions of Windows 10:</span></span>**
     - <span data-ttu-id="d4684-163">ほとんどのユーザーに関しては、すべての最小ハードウェア要件と推奨されるハードウェア要件がストア登録情報に表示されます (前のバージョンのストア クライアントを表示しているユーザーの場合には、最小ハードウェア要件しか表示されません)。</span><span class="sxs-lookup"><span data-stu-id="d4684-163">For most customers, all minimum and recommended hardware requirements will be displayed in the Store listing (though customers viewing an older versions of the Store client will only see the minimum hardware requirements).</span></span>
     - <span data-ttu-id="d4684-164">**[最小ハードウェア]** として指定した項目の検証がストアによって試みられます。ただし、**メモリ**、**DirectX**、**ビデオ メモリ**、**グラフィックス**、**プロセッサ**は例外で、これらについては検証が行われず、要件を満たしていないデバイスに関する警告は表示されません。</span><span class="sxs-lookup"><span data-stu-id="d4684-164">The Store will attempt to verify items that you designate as **Minimum hardware**, with the exception of **Memory**, **DirectX**, **Video memory**, **Graphics**, and **Processor**; none of those will be verified, and customers won't see any warning on devices which don't meet those requirements.</span></span> 
- **<span data-ttu-id="d4684-165">Windows 8.x 以前および Windows Phone 8.x 以前のユーザー:</span><span class="sxs-lookup"><span data-stu-id="d4684-165">For customers on Windows 8.x and earlier or Windows Phone 8.x and earlier:</span></span>**
     - <span data-ttu-id="d4684-166">**[タッチ スクリーン]** の **[最小ハードウェア]** チェック ボックスをオンにすると、この要件がアプリのストア登録情報に表示されます。また、タッチ スクリーンのないデバイスのユーザーがアプリをダウンロードしようとすると、警告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d4684-166">If you check the **Minimum hardware** box for **Touch screen**, this requirement will be displayed in your app's Store listing, and customers on devices without a touch screen will see a warning if they try to download the app.</span></span> <span data-ttu-id="d4684-167">その他の要件については、検証も行われませんし、ストア登録情報に表示もされません。</span><span class="sxs-lookup"><span data-stu-id="d4684-167">No other requirements will be verified or displayed in your Store listing.</span></span>

<span data-ttu-id="d4684-168">また指定したハードウェアについての実行時のチェックをアプリにも追加することをお勧めします。これは、選択した機能がユーザーのデバイスにないことをストアが常に検出できるとは限らず、また、警告が表示されていてもユーザーはアプリをダウンロードできるためです。</span><span class="sxs-lookup"><span data-stu-id="d4684-168">We also recommend adding runtime checks for the specified hardware into your app, since the Store may not always be able to detect that a customer's device is missing the selected feature(s) and they could still be able to download your app even if a warning is displayed.</span></span> <span data-ttu-id="d4684-169">メモリや DirectX レベルの最小要件を満たしていないデバイスに UWP アプリをまったくダウンロードできないようにするには、[StoreManifest XML ファイル](https://docs.microsoft.com/uwp/schemas/storemanifest/storemanifestschema2015/schema-root)で最小要件を指定します。</span><span class="sxs-lookup"><span data-stu-id="d4684-169">If you want to completely prevent your UWP app from being downloaded on a device which doesn't meet minimum requirements for memory or DirectX level, you can designate the minimum requirements in a [StoreManifest XML file](https://docs.microsoft.com/uwp/schemas/storemanifest/storemanifestschema2015/schema-root).</span></span>

> [!TIP]
> <span data-ttu-id="d4684-170">3D プリンターや USB デバイスなど、製品が正常に動作するためにこのセクションに示されていない追加の項目を必要とする場合、Store 登録情報を作成するときに、[追加のシステム要件](create-app-store-listings.md#additional-system-requirements)を入力することもできます。</span><span class="sxs-lookup"><span data-stu-id="d4684-170">If your product requires additional items that aren't listed in this section in order to run properly, such as 3D printers or USB devices, you can also enter [additional system requirements](create-app-store-listings.md#additional-system-requirements) when you create your Store listing.</span></span>





