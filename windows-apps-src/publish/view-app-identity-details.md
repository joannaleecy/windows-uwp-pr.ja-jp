---
author: jnHs
Description: View details related to the unique identity assigned to your app by the Microsoft Store, and get a link to your app's Store listing.
title: アプリ ID の詳細の表示
ms.assetid: 86F05A79-EFBC-4705-9A71-3A056323AC65
ms.author: wdg-dev-content
ms.date: 12/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: cf2c10fd8fa581e29fe20c5bdcb2683c5246af1d
ms.sourcegitcommit: 53ba430930ecec8ea10c95b390fe6e654fe363e1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3421380"
---
# <a name="view-app-identity-details"></a><span data-ttu-id="c7967-103">アプリ ID の詳細の表示</span><span class="sxs-lookup"><span data-stu-id="c7967-103">View app identity details</span></span>


<span data-ttu-id="c7967-104">Windows デベロッパー センター ダッシュ ボードでアプリを使用する場合は、Microsoft Store で割り当てられた一意の id に関連する詳細を表示できます。</span><span class="sxs-lookup"><span data-stu-id="c7967-104">When working with an app in the Windows Dev Center dashboard, you can view details related to the unique identity assigned to it by the Microsoft Store.</span></span> <span data-ttu-id="c7967-105">アプリのストア登録情報へのリンクを取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="c7967-105">You can also get a link to your app's Store listing.</span></span>

<span data-ttu-id="c7967-106">アプリ ID の情報を探すには、アプリのいずれかに移動し、左側のナビゲーション メニューで **[アプリ管理]** を展開します。</span><span class="sxs-lookup"><span data-stu-id="c7967-106">To find this info, navigate to one of your apps, then expand **App management** in the left navigation menu.</span></span> <span data-ttu-id="c7967-107">**[アプリ ID]** を選ぶと、アプリ ID の詳細が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c7967-107">Select **App identity** to view these details.</span></span>


## <a name="values-to-include-in-your-app-package-manifest"></a><span data-ttu-id="c7967-108">アプリのパッケージ マニフェストに追加する値</span><span class="sxs-lookup"><span data-stu-id="c7967-108">Values to include in your app package manifest</span></span>

<span data-ttu-id="c7967-109">次の値を .appx パッケージ マニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7967-109">The following values must be included in your .appx package manifest.</span></span> <span data-ttu-id="c7967-110">[パッケージのビルドに Microsoft Visual Studio を使っていて](../packaging/packaging-uwp-apps.md)、開発者アカウントに関連付けられている同じ Microsoft アカウントでサインインしている場合は、これらの値は自動的に追加されています。</span><span class="sxs-lookup"><span data-stu-id="c7967-110">If you [use Microsoft Visual Studio to build your packages](../packaging/packaging-uwp-apps.md), and are signed in with the same Microsoft account that you have associated with your developer account, these details are included automatically.</span></span> <span data-ttu-id="c7967-111">パッケージを手動でビルドしている場合は、以下の項目を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7967-111">If you're building your package manually, you'll need to add these items:</span></span>

-   **<span data-ttu-id="c7967-112">Package/Identity/Name</span><span class="sxs-lookup"><span data-stu-id="c7967-112">Package/Identity/Name</span></span>**
-   **<span data-ttu-id="c7967-113">Package/Identity/Publisher</span><span class="sxs-lookup"><span data-stu-id="c7967-113">Package/Identity/Publisher</span></span>**
-   **<span data-ttu-id="c7967-114">Package/Properties/PublisherDisplayName</span><span class="sxs-lookup"><span data-stu-id="c7967-114">Package/Properties/PublisherDisplayName</span></span>**

<span data-ttu-id="c7967-115">詳しくは、[パッケージ マニフェスト スキーマのリファレンス](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/schema-root)の「[**Identity**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7967-115">For more info, see [**Identity**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) in the [package manifest schema reference](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/schema-root).</span></span>

<span data-ttu-id="c7967-116">また、アプリ ID を宣言するこれらの値により、パッケージが属している "パッケージ ファミリ" が確定されます。</span><span class="sxs-lookup"><span data-stu-id="c7967-116">Together, these elements declare the identity of your app, establishing the "package family" to which all of its packages belong.</span></span> <span data-ttu-id="c7967-117">個々のパッケージには、アーキテクチャやバージョンなど、その他の詳細が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c7967-117">Individual packages will have additional details, such as architecture and version.</span></span>


## <a name="additional-values-for-package-family"></a><span data-ttu-id="c7967-118">パッケージファミリのその他の値</span><span class="sxs-lookup"><span data-stu-id="c7967-118">Additional values for package family</span></span>

<span data-ttu-id="c7967-119">次の値は、アプリのパッケージ ファミリを参照するが、マニフェストには含まれていないその他の値です。</span><span class="sxs-lookup"><span data-stu-id="c7967-119">The following values are additional values that refer to your app's package family, but are not included in your manifest.</span></span>

-   <span data-ttu-id="c7967-120">**パッケージ ファミリ名 (PFN)**: この値は特定の Windows API で使われます。</span><span class="sxs-lookup"><span data-stu-id="c7967-120">**Package Family Name (PFN)**: This value is used with certain Windows APIs.</span></span>
-   <span data-ttu-id="c7967-121">**パッケージ SID**: アプリに WNS の通知を渡すには、この値が必要になります。</span><span class="sxs-lookup"><span data-stu-id="c7967-121">**Package SID**: You'll need this value to send WNS notifications to your app.</span></span> <span data-ttu-id="c7967-122">詳しくは、「[Windows プッシュ通知サービス (WNS) の概要](../design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7967-122">For more info, see [Windows Push Notification Services (WNS) overview](../design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview.md).</span></span>


## <a name="link-to-your-apps-listing"></a><span data-ttu-id="c7967-123">アプリの登録情報へのリンク</span><span class="sxs-lookup"><span data-stu-id="c7967-123">Link to your app's listing</span></span>

<span data-ttu-id="c7967-124">アプリのページへの直接リンクを共有することで、ユーザーはストアでアプリを見つけやすくなります。</span><span class="sxs-lookup"><span data-stu-id="c7967-124">The direct link to your app's page can be shared to help your customers find the app in the Store.</span></span> <span data-ttu-id="c7967-125">このリンクは、**`https://www.microsoft.com/store/apps/<your app's Store ID>`** の形式で示されます。</span><span class="sxs-lookup"><span data-stu-id="c7967-125">This link is in the format **`https://www.microsoft.com/store/apps/<your app's Store ID>`**.</span></span> <span data-ttu-id="c7967-126">ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="c7967-126">When a customer clicks this link, it opens the web-based listing page for your app.</span></span> <span data-ttu-id="c7967-127">Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="c7967-127">On Windows devices, the Store app will also launch and display your app's listing.</span></span>

<span data-ttu-id="c7967-128">アプリの**ストア ID** も、このセクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="c7967-128">Your app's **Store ID** is also shown in this section.</span></span> <span data-ttu-id="c7967-129">このストア ID を使って、[ストア バッジを生成](http://go.microsoft.com/fwlink/p/?LinkId=534236)したり、その他の方法でアプリを識別したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="c7967-129">This Store ID can be used to [generate Store badges](http://go.microsoft.com/fwlink/p/?LinkId=534236) or otherwise identify your app.</span></span>

<span data-ttu-id="c7967-130">**ストア プロトコルのリンク**を使うと、アプリ内からリンクする場合などに、ブラウザーを開かずにストア内のアプリに直接リンクできます。</span><span class="sxs-lookup"><span data-stu-id="c7967-130">The **Store protocol link** can be used to link directly to your app in the Store without opening a browser, such as when you are linking from within an app.</span></span> <span data-ttu-id="c7967-131">詳しくは、「[アプリへのリンク](link-to-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7967-131">For more info, see [Link to your app](link-to-your-app.md).</span></span>



 

 




