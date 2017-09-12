---
author: jnHs
Description: "Windows ストアによってアプリに割り当てられた一意の ID に関連する詳細情報を表示したり、アプリのストア登録情報へのリンクを取得したりできます。"
title: "アプリ ID の詳細の表示"
ms.assetid: 86F05A79-EFBC-4705-9A71-3A056323AC65
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: d509189ae6392be3d4335732965b70fbc9c77436
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="view-app-identity-details"></a><span data-ttu-id="9d482-104">アプリ ID の詳細の表示</span><span class="sxs-lookup"><span data-stu-id="9d482-104">View app identity details</span></span>


<span data-ttu-id="9d482-105">Windows デベロッパー センター ダッシュボードを使ったアプリの作業では、Windows ストアによってアプリに割り当てられた一意の ID の詳細を表示できます。</span><span class="sxs-lookup"><span data-stu-id="9d482-105">When working with an app in the Windows Dev Center dashboard, you can view details related to the unique identity assigned to it by the Windows Store.</span></span> <span data-ttu-id="9d482-106">アプリのストア登録情報へのリンクを取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="9d482-106">You can also get a link to your app's Store listing.</span></span>

<span data-ttu-id="9d482-107">アプリ ID の情報を探すには、アプリのいずれかに移動し、左側のナビゲーション メニューで **[アプリ管理]** を展開します。</span><span class="sxs-lookup"><span data-stu-id="9d482-107">To find this info, navigate to one of your apps, then expand **App management** in the left navigation menu.</span></span> <span data-ttu-id="9d482-108">**[アプリ ID]** を選ぶと、アプリ ID の詳細が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9d482-108">Select **App identity** to view these details.</span></span>


## <a name="values-to-include-in-your-app-package-manifest"></a><span data-ttu-id="9d482-109">アプリのパッケージ マニフェストに追加する値</span><span class="sxs-lookup"><span data-stu-id="9d482-109">Values to include in your app package manifest</span></span>

<span data-ttu-id="9d482-110">次の値を .appx パッケージ マニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d482-110">The following values must be included in your .appx package manifest.</span></span> <span data-ttu-id="9d482-111">[パッケージのビルドに Microsoft Visual Studio を使っていて](../packaging/packaging-uwp-apps.md)、開発者アカウントに関連付けられている同じ Microsoft アカウントでサインインしている場合は、これらの値は自動的に追加されています。</span><span class="sxs-lookup"><span data-stu-id="9d482-111">If you [use Microsoft Visual Studio to build your packages](../packaging/packaging-uwp-apps.md), and are signed in with the same Microsoft account that you have associated with your developer account, these details are included automatically.</span></span> <span data-ttu-id="9d482-112">パッケージを手動でビルドしている場合は、以下の項目を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d482-112">If you're building your package manually, you'll need to add these items:</span></span>

-   **<span data-ttu-id="9d482-113">Package/Identity/Name</span><span class="sxs-lookup"><span data-stu-id="9d482-113">Package/Identity/Name</span></span>**
-   **<span data-ttu-id="9d482-114">Package/Identity/Publisher</span><span class="sxs-lookup"><span data-stu-id="9d482-114">Package/Identity/Publisher</span></span>**
-   **<span data-ttu-id="9d482-115">Package/Properties/PublisherDisplayName</span><span class="sxs-lookup"><span data-stu-id="9d482-115">Package/Properties/PublisherDisplayName</span></span>**

<span data-ttu-id="9d482-116">詳しくは、[パッケージ マニフェスト スキーマのリファレンス](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/schema-root)の「[**Identity**](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-identity)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9d482-116">For more info, see [**Identity**](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-identity) in the [package manifest schema reference](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/schema-root).</span></span>

<span data-ttu-id="9d482-117">また、アプリ ID を宣言するこれらの値により、パッケージが属している "パッケージ ファミリ" が確定されます。</span><span class="sxs-lookup"><span data-stu-id="9d482-117">Together, these elements declare the identity of your app, establishing the "package family" to which all of its packages belong.</span></span> <span data-ttu-id="9d482-118">個々のパッケージには、アーキテクチャやバージョンなど、その他の詳細が含まれています。</span><span class="sxs-lookup"><span data-stu-id="9d482-118">Individual packages will have additional details, such as architecture and version.</span></span>


## <a name="additional-values-for-package-family"></a><span data-ttu-id="9d482-119">パッケージファミリのその他の値</span><span class="sxs-lookup"><span data-stu-id="9d482-119">Additional values for package family</span></span>

<span data-ttu-id="9d482-120">次の値は、アプリのパッケージ ファミリを参照するが、マニフェストには含まれていないその他の値です。</span><span class="sxs-lookup"><span data-stu-id="9d482-120">The following values are additional values that refer to your app's package family, but are not included in your manifest.</span></span>

-   <span data-ttu-id="9d482-121">**パッケージ ファミリ名 (PFN)**: この値は特定の Windows API で使われます。</span><span class="sxs-lookup"><span data-stu-id="9d482-121">**Package Family Name (PFN)**: This value is used with certain Windows APIs.</span></span>
-   <span data-ttu-id="9d482-122">**パッケージ SID**: アプリに WNS の通知を渡すには、この値が必要になります。</span><span class="sxs-lookup"><span data-stu-id="9d482-122">**Package SID**: You'll need this value to send WNS notifications to your app.</span></span> <span data-ttu-id="9d482-123">詳しくは、「[Windows プッシュ通知サービスの概要](../controls-and-patterns/tiles-and-notifications-windows-push-notification-services--wns--overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9d482-123">For more info, see [Windows Push Notification Services (WNS) overview](../controls-and-patterns/tiles-and-notifications-windows-push-notification-services--wns--overview.md).</span></span>


## <a name="link-to-your-apps-listing"></a><span data-ttu-id="9d482-124">アプリの登録情報へのリンク</span><span class="sxs-lookup"><span data-stu-id="9d482-124">Link to your app's listing</span></span>

<span data-ttu-id="9d482-125">アプリのページへの直接リンクを共有することで、ユーザーはストアでアプリを見つけやすくなります。</span><span class="sxs-lookup"><span data-stu-id="9d482-125">The direct link to your app's page can be shared to help your customers find the app in the Store.</span></span> <span data-ttu-id="9d482-126">このリンクは、**`https://www.microsoft.com/store/apps/<your app's Store ID>`** の形式で示されます。</span><span class="sxs-lookup"><span data-stu-id="9d482-126">This link is in the format **`https://www.microsoft.com/store/apps/<your app's Store ID>`**.</span></span> <span data-ttu-id="9d482-127">ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="9d482-127">When a customer clicks this link, it opens the web-based listing page for your app.</span></span> <span data-ttu-id="9d482-128">Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="9d482-128">On Windows devices, the Store app will also launch and display your app's listing.</span></span>

<span data-ttu-id="9d482-129">アプリの**ストア ID** も、このセクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9d482-129">Your app's **Store ID** is also shown in this section.</span></span> <span data-ttu-id="9d482-130">このストア ID を使って、[ストア バッジを生成](http://go.microsoft.com/fwlink/p/?LinkId=534236)したり、その他の方法でアプリを識別したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="9d482-130">This Store ID can be used to [generate Store badges](http://go.microsoft.com/fwlink/p/?LinkId=534236) or otherwise identify your app.</span></span>

<span data-ttu-id="9d482-131">**ストア プロトコルのリンク**を使うと、アプリ内からリンクする場合などに、ブラウザーを開かずにストア内のアプリに直接リンクできます。</span><span class="sxs-lookup"><span data-stu-id="9d482-131">The **Store protocol link** can be used to link directly to your app in the Store without opening a browser, such as when you are linking from within an app.</span></span> <span data-ttu-id="9d482-132">詳しくは、「[アプリへのリンク](link-to-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9d482-132">For more info, see [Link to your app](link-to-your-app.md).</span></span>



 

 




