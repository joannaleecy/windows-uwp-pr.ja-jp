---
Description: If you've provided packages targeting different operating systems, you have the option to customize parts of your Store listing for different targeted operating systems.
title: プラットフォーム固有の Store 登録情報の作成
ms.assetid: 5BE66BE2-669C-49E0-8915-60F1027EF94A
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, カスタマイズ, 登録情報, 説明, 以前
ms.localizationpriority: medium
ms.openlocfilehash: bfb21d56df357640734e9e5026783cc398468f0a
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7978863"
---
# <a name="create-platform-specific-store-listings"></a><span data-ttu-id="4ad88-103">プラットフォーム固有の Store 登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="4ad88-103">Create platform-specific Store listings</span></span>


<span data-ttu-id="4ad88-104">以前の OS バージョンのユーザーのストア登録情報の一部をカスタマイズするオプションがある場合は、さまざまなオペレーティング システムをターゲットとするパッケージが以前に公開されたアプリに、(Windows 8.x またはそれ以前や Windows Phone 8.x またはそれ以前)。</span><span class="sxs-lookup"><span data-stu-id="4ad88-104">If your previously-published app has packages that target different operating systems, you have the option to customize parts of your Store listing for customers on earlier OS versions (Windows 8.x or earlier and/or Windows Phone 8.x or earlier).</span></span> 

<span data-ttu-id="4ad88-105">Windows 10 (Xbox を含む) のユーザーでは、既定の[Store 登録情報](create-app-store-listings.md)が常に表示します。</span><span class="sxs-lookup"><span data-stu-id="4ad88-105">Customers on Windows10 (including Xbox) will always see the default [Store listing](create-app-store-listings.md).</span></span> <span data-ttu-id="4ad88-106">1 つまたは複数の以前の OS バージョンをサポートするパッケージを使用したアプリを既に公開している場合を除き、プラットフォーム固有のストア登録情報を作成するオプションは表示されません。</span><span class="sxs-lookup"><span data-stu-id="4ad88-106">You won't see the option to create platform-specific Store listings unless you have already published your app with packages that support one or more earlier OS versions.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="4ad88-107">2018 年 10 月 31 日の時点で、新しく作成した製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。</span><span class="sxs-lookup"><span data-stu-id="4ad88-107">As of October 31, 2018, newly-created products cannot include packages targeting Windows 8.x/Windows Phone 8.x or earlier.</span></span> <span data-ttu-id="4ad88-108">詳しくは、この[ブログ記事](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/#SzKghBbqDMlmAO4c.97)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="4ad88-108">For more info, see this [blog post](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/#SzKghBbqDMlmAO4c.97).</span></span>

<span data-ttu-id="4ad88-109">1 つの OS バージョンでのみ表示される機能について説明したりするか、特定の OS (デバイスの種類の独立した) に固有のスクリーン ショットを提供する場合、プラットフォーム固有のストア登録情報が役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-109">Platform-specific Store listings can be useful if you want to mention features that appear only in one OS version, or want to provide screenshots that are specific to a particular OS (independent of device type).</span></span>

> [!NOTE]
> <span data-ttu-id="4ad88-110">ある言語でプラットフォーム固有の Store 登録情報を作成しても、アプリがサポートする他の言語でプラットフォーム固有の Store 登録情報が作成されることはありません。</span><span class="sxs-lookup"><span data-stu-id="4ad88-110">Creating a platform-specific Store listing in one language does not create a platform-specific Store listing in other languages that your app supports.</span></span> <span data-ttu-id="4ad88-111">プラットフォーム固有のストア登録情報は、言語ごとに別個に作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ad88-111">You'll need to create the platform-specific Store listing separately for each language.</span></span> <span data-ttu-id="4ad88-112">[インポートおよびエクスポートのストア登録情報データ](import-and-export-store-listings.md)プラットフォーム固有の登録情報にアクセスできないことにも注意してください。</span><span class="sxs-lookup"><span data-stu-id="4ad88-112">Also note that you cannot [import and export Store listing data](import-and-export-store-listings.md) for platform-specific listings.</span></span>


## <a name="creating-a-platform-specific-store-listing"></a><span data-ttu-id="4ad88-113">プラットフォーム固有のストア登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="4ad88-113">Creating a platform-specific Store listing</span></span>

<span data-ttu-id="4ad88-114">以前に公開されたアプリには、以前の OS バージョンをサポートするパッケージが含まれている場合、**ストア登録情報**ページの上部付近には ((Windows 8.x またはそれ以前や Windows Phone 8.x 以前)、する選択**でプラットフォーム固有のアプリのストア登録情報を作成できます**.</span><span class="sxs-lookup"><span data-stu-id="4ad88-114">Near the top of your **Store listing** page, if your previously-published app includes packages that support earlier OS versions ((Windows 8.x or earlier and/or Windows Phone 8.x or earlier), you can select **create a platform-specific app Store listing**.</span></span> <span data-ttu-id="4ad88-115">このオプションを選択すると、申請でサポートされているターゲット OS のバージョンを選択するよう求められます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-115">After selecting this option, you'll be prompted to choose from the targeted OS versions that your submission supports.</span></span> <span data-ttu-id="4ad88-116">すべての以前の OS バージョンに対してプラットフォーム固有のストア登録情報は、アプリが対象と既に作成したら、もう 1 つの項目を選択することはできません。</span><span class="sxs-lookup"><span data-stu-id="4ad88-116">Once you've already created platform-specific Store listings for all of the earlier OS versions your app targets, you won't be able to make another selection.</span></span>

<span data-ttu-id="4ad88-117">登録情報が、適用可能なテキストと画像の既定のストアに入力した経由で表示されますが、開始点として (Windows 10) の既定のストア登録情報を使用することができます。その後ことができますか保存する前に変更を加えます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-117">You can use your default (Windows 10) Store listing as a starting point, which will bring over the applicable text and images you've entered for your default Store listing; you'll then be able to make any changes you'd like before saving.</span></span> <span data-ttu-id="4ad88-118">必要に応じて、完全に空のストア登録情報から始めることもできます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-118">You can also start from a completely blank Store listing if you prefer.</span></span>

<span data-ttu-id="4ad88-119">**[続行]** をクリックすると、作成したプラットフォーム固有の Store 登録情報を表示するセクションが **[Store 登録情報]** ページに追加されます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-119">After you click **Continue**, your **Store listing** page will now include a section for the platform-specific Store listing you've just created.</span></span> <span data-ttu-id="4ad88-120">このセクションには、**[説明]** (必須)、**[今回のバージョンでの新機能]**、**[スクリーンショット]**、**[アプリ タイル アイコン]**、**[アプリの機能]**、**[追加のシステム要件]** を指定する独自のフィールド セットが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-120">This section will include its own set of fields for **Description** (required), **What's new in this version**, **Screenshots**, **App tile icon**, **App features**, and **Additional system requirements**.</span></span> <span data-ttu-id="4ad88-121">既定のストア登録情報と同じ情報であっても、カスタムのストア登録情報で情報を表示するすべてのフィールドに情報を入力してください。</span><span class="sxs-lookup"><span data-stu-id="4ad88-121">Make sure to enter info into each field where you want to display info in the custom Store listing, even if it's the same info as in your default Store listing.</span></span> <span data-ttu-id="4ad88-122">これらのフィールドのいずれかを空白のままにした場合、カスタムの Store 登録情報の該当するフィールドには情報が表示されません。</span><span class="sxs-lookup"><span data-stu-id="4ad88-122">If you leave any of these fields blank, no info will appear for that field in the custom Store listing.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="4ad88-123">Store 登録情報の [[追加情報]](create-app-store-listings.md#additional-information) セクションのフィールドを別の OS バージョン用にカスタマイズすることはできません。</span><span class="sxs-lookup"><span data-stu-id="4ad88-123">The fields in the [Additional information](create-app-store-listings.md#additional-information) section of the Store listing can't be customized for different OS versions.</span></span>
> 
> <span data-ttu-id="4ad88-124">さらに、既定の [[Store 登録情報]](create-app-store-listings.md) ページのフィールドの一部は Windows 10 のユーザーにしか適用されないため、プラットフォーム固有の Store 登録情報の作成時には、同じオプションがすべて表示されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="4ad88-124">Additionally, because some of the fields in the default [Store listing](create-app-store-listings.md) page only apply to customers on Windows 10, you won't see all of the same options when creating a platform-specific Store listing.</span></span> <span data-ttu-id="4ad88-125">たとえば、トレーラーは Windows 10 バージョン 1607 以降のユーザーにしか表示されないため、プラットフォーム固有の Store 登録情報にトレーラーを追加することはできません。</span><span class="sxs-lookup"><span data-stu-id="4ad88-125">For example, you can't add trailers to a platform-specific Store listing, because trailers are only shown to customers on Windows 10, version 1607 or later.</span></span> 

<span data-ttu-id="4ad88-126">特定の OS バージョンのユーザーに対して変更を加える必要に応じて、プラットフォーム固有の登録情報を編集する続行することができます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-126">You can continue to edit platform-specific listings as needed to make changes for customers on a certain OS version.</span></span>


## <a name="removing-a-platform-specific-store-listing"></a><span data-ttu-id="4ad88-127">プラットフォーム固有のストア登録情報の削除</span><span class="sxs-lookup"><span data-stu-id="4ad88-127">Removing a platform-specific Store listing</span></span>

<span data-ttu-id="4ad88-128">プラットフォーム固有の Store 登録情報を作成した後、そのオペレーティング システムではユーザーに既定の Store 登録情報を表示することにした場合は、その登録情報の横にある **[削除]** リンクを選択します。</span><span class="sxs-lookup"><span data-stu-id="4ad88-128">If you create a platform-specific Store listing and later decide you'd rather show your default Store listing to customers on that operating system, select the **Delete** link next to that listing.</span></span>

<span data-ttu-id="4ad88-129">それらのユーザーに既定の Store 登録情報を表示することを確認したら、**[OK]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="4ad88-129">After confirming that you'd like to show those customers your default Store listing, select **OK**.</span></span> <span data-ttu-id="4ad88-130">プラットフォーム固有の Store 登録情報 (登録されていたすべての言語について) 削除すると、その OS バージョンのユーザーには既定の Store 登録情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-130">The platform-specific Store listing will be removed (for all languages in which it existed) and customers on that OS version will now see your default Store listing.</span></span> <span data-ttu-id="4ad88-131">考えが変わった場合は、上記の手順に従ってそのオペレーティング システム用の別のプラットフォーム固有の Store 登録情報を作成できます。</span><span class="sxs-lookup"><span data-stu-id="4ad88-131">If you change your mind, you can create another platform-specific Store listing for that operating system by following the steps listed above.</span></span>
 

 




