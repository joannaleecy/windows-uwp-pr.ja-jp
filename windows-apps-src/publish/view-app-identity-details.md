---
Description: Microsoft Store、により、アプリに割り当てられた一意の id に関連する詳細を表示し、アプリのストアの一覧へのリンクを取得します。
title: アプリ ID の詳細の表示
ms.assetid: 86F05A79-EFBC-4705-9A71-3A056323AC65
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 7e108d603a623e3b9e41d7ced3c0fafc80f006b8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610817"
---
# <a name="view-app-identity-details"></a><span data-ttu-id="78c26-104">アプリ ID の詳細の表示</span><span class="sxs-lookup"><span data-stu-id="78c26-104">View app identity details</span></span>


<span data-ttu-id="78c26-105">は、Microsoft Store によって、アプリに割り当てられた一意の id に関連する詳細を表示するその**アプリ id**ページ。</span><span class="sxs-lookup"><span data-stu-id="78c26-105">You can view details related to the unique identity assigned to your app by the Microsoft Store on its **App identity** pages.</span></span> <span data-ttu-id="78c26-106">取得できます、アプリのストアのリンクをこのページに一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="78c26-106">You can also get a link to your app's Store listing on this page.</span></span>

<span data-ttu-id="78c26-107">アプリ ID の情報を探すには、アプリのいずれかに移動し、左側のナビゲーション メニューで **[アプリ管理]** を展開します。</span><span class="sxs-lookup"><span data-stu-id="78c26-107">To find this info, navigate to one of your apps, then expand **App management** in the left navigation menu.</span></span> <span data-ttu-id="78c26-108">**[アプリ ID]** を選ぶと、アプリ ID の詳細が表示されます。</span><span class="sxs-lookup"><span data-stu-id="78c26-108">Select **App identity** to view these details.</span></span>


## <a name="values-to-include-in-your-app-package-manifest"></a><span data-ttu-id="78c26-109">アプリのパッケージ マニフェストに追加する値</span><span class="sxs-lookup"><span data-stu-id="78c26-109">Values to include in your app package manifest</span></span>

<span data-ttu-id="78c26-110">パッケージ マニフェストでは、次の値を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="78c26-110">The following values must be included in your package manifest.</span></span> <span data-ttu-id="78c26-111">[パッケージのビルドに Microsoft Visual Studio を使っていて](../packaging/packaging-uwp-apps.md)、開発者アカウントに関連付けられている同じ Microsoft アカウントでサインインしている場合は、これらの値は自動的に追加されています。</span><span class="sxs-lookup"><span data-stu-id="78c26-111">If you [use Microsoft Visual Studio to build your packages](../packaging/packaging-uwp-apps.md), and are signed in with the same Microsoft account that you have associated with your developer account, these details are included automatically.</span></span> <span data-ttu-id="78c26-112">パッケージを手動でビルドしている場合は、以下の項目を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="78c26-112">If you're building your package manually, you'll need to add these items:</span></span>

-   <span data-ttu-id="78c26-113">**パッケージ/ユーザー/名前**</span><span class="sxs-lookup"><span data-stu-id="78c26-113">**Package/Identity/Name**</span></span>
-   <span data-ttu-id="78c26-114">**パッケージ/ユーザー/パブリッシャー**</span><span class="sxs-lookup"><span data-stu-id="78c26-114">**Package/Identity/Publisher**</span></span>
-   <span data-ttu-id="78c26-115">**パッケージ/プロパティ/PublisherDisplayName**</span><span class="sxs-lookup"><span data-stu-id="78c26-115">**Package/Properties/PublisherDisplayName**</span></span>

<span data-ttu-id="78c26-116">詳しくは、[パッケージ マニフェスト スキーマのリファレンス](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/schema-root)の「[**Identity**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78c26-116">For more info, see [**Identity**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity) in the [package manifest schema reference](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/schema-root).</span></span>

<span data-ttu-id="78c26-117">また、アプリ ID を宣言するこれらの値により、パッケージが属している "パッケージ ファミリ" が確定されます。</span><span class="sxs-lookup"><span data-stu-id="78c26-117">Together, these elements declare the identity of your app, establishing the "package family" to which all of its packages belong.</span></span> <span data-ttu-id="78c26-118">個々のパッケージには、アーキテクチャやバージョンなど、その他の詳細が含まれています。</span><span class="sxs-lookup"><span data-stu-id="78c26-118">Individual packages will have additional details, such as architecture and version.</span></span>


## <a name="additional-values-for-package-family"></a><span data-ttu-id="78c26-119">パッケージファミリのその他の値</span><span class="sxs-lookup"><span data-stu-id="78c26-119">Additional values for package family</span></span>

<span data-ttu-id="78c26-120">次の値は、アプリのパッケージ ファミリを参照するが、マニフェストには含まれていないその他の値です。</span><span class="sxs-lookup"><span data-stu-id="78c26-120">The following values are additional values that refer to your app's package family, but are not included in your manifest.</span></span>

-   <span data-ttu-id="78c26-121">**パッケージ ファミリ名 (PFN)**:この値は、特定の Windows Api で使用されます。</span><span class="sxs-lookup"><span data-stu-id="78c26-121">**Package Family Name (PFN)**: This value is used with certain Windows APIs.</span></span>
-   <span data-ttu-id="78c26-122">**パッケージ SID**:この値をアプリに WNS 通知を送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="78c26-122">**Package SID**: You'll need this value to send WNS notifications to your app.</span></span> <span data-ttu-id="78c26-123">詳しくは、「[Windows プッシュ通知サービスの概要](../design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78c26-123">For more info, see [Windows Push Notification Services (WNS) overview](../design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview.md).</span></span>


## <a name="link-to-your-apps-listing"></a><span data-ttu-id="78c26-124">アプリの登録情報へのリンク</span><span class="sxs-lookup"><span data-stu-id="78c26-124">Link to your app's listing</span></span>

<span data-ttu-id="78c26-125">アプリのページへの直接リンクを共有することで、ユーザーはストアでアプリを見つけやすくなります。</span><span class="sxs-lookup"><span data-stu-id="78c26-125">The direct link to your app's page can be shared to help your customers find the app in the Store.</span></span> <span data-ttu-id="78c26-126">このリンクは、**`https://www.microsoft.com/store/apps/<your app's Store ID>`** の形式で示されます。</span><span class="sxs-lookup"><span data-stu-id="78c26-126">This link is in the format **`https://www.microsoft.com/store/apps/<your app's Store ID>`**.</span></span> <span data-ttu-id="78c26-127">ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="78c26-127">When a customer clicks this link, it opens the web-based listing page for your app.</span></span> <span data-ttu-id="78c26-128">Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="78c26-128">On Windows devices, the Store app will also launch and display your app's listing.</span></span>

<span data-ttu-id="78c26-129">アプリの**ストア ID** も、このセクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="78c26-129">Your app's **Store ID** is also shown in this section.</span></span> <span data-ttu-id="78c26-130">このストア ID を使って、[ストア バッジを生成](https://go.microsoft.com/fwlink/p/?LinkId=534236)したり、その他の方法でアプリを識別したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="78c26-130">This Store ID can be used to [generate Store badges](https://go.microsoft.com/fwlink/p/?LinkId=534236) or otherwise identify your app.</span></span>

<span data-ttu-id="78c26-131">**ストア プロトコルのリンク**を使うと、アプリ内からリンクする場合などに、ブラウザーを開かずにストア内のアプリに直接リンクできます。</span><span class="sxs-lookup"><span data-stu-id="78c26-131">The **Store protocol link** can be used to link directly to your app in the Store without opening a browser, such as when you are linking from within an app.</span></span> <span data-ttu-id="78c26-132">詳しくは、「[アプリへのリンク](link-to-your-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="78c26-132">For more info, see [Link to your app](link-to-your-app.md).</span></span>



 

 




