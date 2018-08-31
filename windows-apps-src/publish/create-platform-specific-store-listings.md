---
author: jnHs
Description: If you've provided packages targeting different operating systems, you have the option to customize parts of your Store listing for different targeted operating systems.
title: プラットフォーム固有の Store 登録情報の作成
ms.assetid: 5BE66BE2-669C-49E0-8915-60F1027EF94A
ms.author: wdg-dev-content
ms.date: 3/13/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, カスタマイズ, 登録情報, 説明, 以前
ms.localizationpriority: medium
ms.openlocfilehash: 6f30a825cc7aec1b6f7dbf5cff0ea1c17c43ffd7
ms.sourcegitcommit: 1e5590dd10d606a910da6deb67b6a98f33235959
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/31/2018
ms.locfileid: "3228677"
---
# <a name="create-platform-specific-store-listings"></a><span data-ttu-id="96e84-103">プラットフォーム固有の Store 登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="96e84-103">Create platform-specific Store listings</span></span>


<span data-ttu-id="96e84-104">アプリに別のオペレーティング システムを対象とするパッケージがある場合は、以前のバージョンの OS (Windows 8.x 以前または Windows Phone 8.x 以前) のユーザー向けに Store 登録情報の一部をカスタマイズするオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="96e84-104">If your app has packages that target different operating systems, you have the option to customize parts of your Store listing for customers on earlier OS versions (Windows 8.x or earlier and/or Windows Phone 8.x or earlier).</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="96e84-105">Windows 10 のユーザーには、既定の [Store 登録情報](create-app-store-listings.md)が常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="96e84-105">Customers on Windows 10 will always see the default [Store listing](create-app-store-listings.md).</span></span> <span data-ttu-id="96e84-106">既に 1 つまたは複数の以前のバージョンの OS をサポートするパッケージをアップロードしている場合を除き、プラットフォーム固有の Store 登録情報を作成するオプションは表示されません。</span><span class="sxs-lookup"><span data-stu-id="96e84-106">You will not see the option to create platform-specific Store listings unless you have already uploaded packages that support one or more earlier OS versions.</span></span> 

<span data-ttu-id="96e84-107">プラットフォーム固有のストア登録情報は、すべてのユーザーに同じストア登録情報を表示するのではなく、ある OS バージョンでのみ表示される機能について説明したり、(デバイスの種類とは無関係に) 特定の OS に固有のスクリーンショットを指定したりする場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="96e84-107">Platform-specific Store listings can be useful if you want to mention features that appear only in one OS version, or want to provide screenshots that are specific to a particular OS (independent of device type), rather than having all customers see the same Store listing.</span></span>

> [!NOTE]
> <span data-ttu-id="96e84-108">ある言語でプラットフォーム固有の Store 登録情報を作成しても、アプリがサポートする他の言語でプラットフォーム固有の Store 登録情報が作成されることはありません。</span><span class="sxs-lookup"><span data-stu-id="96e84-108">Creating a platform-specific Store listing in one language does not create a platform-specific Store listing in other languages that your app supports.</span></span> <span data-ttu-id="96e84-109">プラットフォーム固有の Store 登録情報は、言語ごとに別個に作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="96e84-109">You'll need to create the platform-specific Store listing separately for each language.</span></span> <span data-ttu-id="96e84-110">また、プラットフォーム固有の登録情報用に、Store 登録情報のデータをインポートおよびエクスポートできないことにも注意してください。</span><span class="sxs-lookup"><span data-stu-id="96e84-110">Also note that you cannot import and export Store listing data for platform-specific listings.</span></span>


## <a name="creating-a-platform-specific-store-listing"></a><span data-ttu-id="96e84-111">プラットフォーム固有の Store 登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="96e84-111">Creating a platform-specific Store listing</span></span>

<span data-ttu-id="96e84-112">アプリが以前の OS バージョン (Windows 8.x 以前または Windows Phone 8.x 以前) をサポートする場合、**[Store 登録情報]** ページの上部で、**プラットフォーム固有のアプリの Store 登録情報を作成**するためのリンクを選択できます。</span><span class="sxs-lookup"><span data-stu-id="96e84-112">Near the top of your **Store listing** page, if your app supports earlier OS versions ((Windows 8.x or earlier and/or Windows Phone 8.x or earlier), you can select **create a platform-specific app Store listing**.</span></span> 

> [!TIP]
> <span data-ttu-id="96e84-113">プラットフォーム固有の Store 登録情報を作成するオプションは、パッケージをアップロードするまで表示されません。</span><span class="sxs-lookup"><span data-stu-id="96e84-113">You won't see the option to create platform-specific Store listings until after you've uploaded packages.</span></span>

<span data-ttu-id="96e84-114">このオプションを選択すると、申請でサポートされているターゲット OS のバージョンを選択するよう求められます。</span><span class="sxs-lookup"><span data-stu-id="96e84-114">After selecting this option, you'll be prompted to choose from the targeted OS versions that your submission supports.</span></span> <span data-ttu-id="96e84-115">アプリがターゲットとするすべての OS バージョンに対して既にプラットフォーム固有の Store 登録情報が作成されている場合は、それ以上選択することはできません。</span><span class="sxs-lookup"><span data-stu-id="96e84-115">Once you've already created platform-specific Store listings for all of the OS versions your app targets, you won't be able to make another selection.</span></span> <span data-ttu-id="96e84-116">Windows 10 のユーザーにはアプリの既定の Store 登録情報が常に表示されるため、Windows 10 は選択肢の一覧に含まれません。</span><span class="sxs-lookup"><span data-stu-id="96e84-116">(Windows 10 is not included in the list of choices, because customers on Windows 10 will always see the app's default Store listing.)</span></span>

<span data-ttu-id="96e84-117">作業の開始点として、既定の Store 登録情報を使うことができます。この場合、既定の Store 登録情報に入力されている適用可能なテキストと画像が取り込まれ、保存前に自由に変更できます。</span><span class="sxs-lookup"><span data-stu-id="96e84-117">You can use your default Store listing as a starting point, which will bring over the applicable text and images you've entered for your default Store listing; you'll then be able to make any changes you'd like before saving.</span></span> <span data-ttu-id="96e84-118">必要に応じて、完全に空のストア登録情報から始めることもできます。</span><span class="sxs-lookup"><span data-stu-id="96e84-118">You can also start from a completely blank Store listing if you prefer.</span></span>

<span data-ttu-id="96e84-119">**[続行]** をクリックすると、作成したプラットフォーム固有の Store 登録情報を表示するセクションが **[Store 登録情報]** ページに追加されます。</span><span class="sxs-lookup"><span data-stu-id="96e84-119">After you click **Continue**, your **Store listing** page will now include a section for the platform-specific Store listing you've just created.</span></span> <span data-ttu-id="96e84-120">このセクションには、**[説明]** (必須)、**[今回のバージョンでの新機能]**、**[スクリーンショット]**、**[アプリ タイル アイコン]**、**[アプリの機能]**、**[追加のシステム要件]** を指定する独自のフィールド セットが表示されます。</span><span class="sxs-lookup"><span data-stu-id="96e84-120">This section will include its own set of fields for **Description** (required), **What's new in this version**, **Screenshots**, **App tile icon**, **App features**, and **Additional system requirements**.</span></span> <span data-ttu-id="96e84-121">既定のストア登録情報と同じ情報であっても、カスタムのストア登録情報で情報を表示するすべてのフィールドに情報を入力してください。</span><span class="sxs-lookup"><span data-stu-id="96e84-121">Make sure to enter info into each field where you want to display info in the custom Store listing, even if it's the same info as in your default Store listing.</span></span> <span data-ttu-id="96e84-122">これらのフィールドのいずれかを空白のままにした場合、カスタムの Store 登録情報の該当するフィールドには情報が表示されません。</span><span class="sxs-lookup"><span data-stu-id="96e84-122">If you leave any of these fields blank, no info will appear for that field in the custom Store listing.</span></span>


> [!IMPORTANT]
> <span data-ttu-id="96e84-123">Store 登録情報の [[追加情報]](create-app-store-listings.md#additional-information) セクションのフィールドを別の OS バージョン用にカスタマイズすることはできません。</span><span class="sxs-lookup"><span data-stu-id="96e84-123">The fields in the [Additional information](create-app-store-listings.md#additional-information) section of the Store listing can't be customized for different OS versions.</span></span>
> 
> <span data-ttu-id="96e84-124">さらに、既定の [[Store 登録情報]](create-app-store-listings.md) ページのフィールドの一部は Windows 10 のユーザーにしか適用されないため、プラットフォーム固有の Store 登録情報の作成時には、同じオプションがすべて表示されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="96e84-124">Additionally, because some of the fields in the default [Store listing](create-app-store-listings.md) page only apply to customers on Windows 10, you won't see all of the same options when creating a platform-specific Store listing.</span></span> <span data-ttu-id="96e84-125">たとえば、トレーラーは Windows 10 バージョン 1607 以降のユーザーにしか表示されないため、プラットフォーム固有の Store 登録情報にトレーラーを追加することはできません。</span><span class="sxs-lookup"><span data-stu-id="96e84-125">For example, you can't add trailers to a platform-specific Store listing, because trailers are only shown to customers on Windows 10, version 1607 or later.</span></span> 


## <a name="removing-a-platform-specific-store-listing"></a><span data-ttu-id="96e84-126">プラットフォーム固有の Store 登録情報の削除</span><span class="sxs-lookup"><span data-stu-id="96e84-126">Removing a platform-specific Store listing</span></span>

<span data-ttu-id="96e84-127">プラットフォーム固有の Store 登録情報を作成した後、そのオペレーティング システムではユーザーに既定の Store 登録情報を表示することにした場合は、その登録情報の横にある **[削除]** リンクを選択します。</span><span class="sxs-lookup"><span data-stu-id="96e84-127">If you create a platform-specific Store listing and later decide you'd rather show your default Store listing to customers on that operating system, select the **Delete** link next to that listing.</span></span>

<span data-ttu-id="96e84-128">それらのユーザーに既定の Store 登録情報を表示することを確認したら、**[OK]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="96e84-128">After confirming that you'd like to show those customers your default Store listing, select **OK**.</span></span> <span data-ttu-id="96e84-129">プラットフォーム固有の Store 登録情報 (登録されていたすべての言語について) 削除すると、その OS バージョンのユーザーには既定の Store 登録情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="96e84-129">The platform-specific Store listing will be removed (for all languages in which it existed) and customers on that OS version will now see your default Store listing.</span></span> <span data-ttu-id="96e84-130">考えが変わった場合は、上記の手順に従ってそのオペレーティング システム用の別のプラットフォーム固有の Store 登録情報を作成できます。</span><span class="sxs-lookup"><span data-stu-id="96e84-130">If you change your mind, you can create another platform-specific Store listing for that operating system by following the steps listed above.</span></span>

 

 




