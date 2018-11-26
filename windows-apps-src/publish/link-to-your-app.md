---
Description: You can help customers discover your app by linking to your app's listing in the Microsoft Store.
title: アプリへのリンク
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, リンク, windows store プロトコル, アプリにリンクする, アプリへのリンク
ms.localizationpriority: medium
ms.openlocfilehash: 59df207adf44cea04505e41a3323da1743170c46
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7712327"
---
# <a name="link-to-your-app"></a><span data-ttu-id="2c8b5-103">アプリへのリンク</span><span class="sxs-lookup"><span data-stu-id="2c8b5-103">Link to your app</span></span>


<span data-ttu-id="2c8b5-104">顧客の Microsoft Store でアプリの登録情報にリンクして、アプリを見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-104">You can help customers discover your app by linking to your app's listing in the Microsoft Store.</span></span>

## <a name="getting-the-link-to-your-apps-store-listing"></a><span data-ttu-id="2c8b5-105">ストアのアプリの内容へのリンク</span><span class="sxs-lookup"><span data-stu-id="2c8b5-105">Getting the link to your app's Store listing</span></span>

<span data-ttu-id="2c8b5-106">アプリのストア登録情報の URL を取得するには、アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-106">To get the URL for your app's Store listing, navigate to the app's [App identity](view-app-identity-details.md) page in the **App management** section.</span></span> <span data-ttu-id="2c8b5-107">URL の形式は **`https://www.microsoft.com/store/apps/<your app's Store ID>`** です。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-107">The URL is in the format **`https://www.microsoft.com/store/apps/<your app's Store ID>`**.</span></span>

<span data-ttu-id="2c8b5-108">ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-108">When a customer clicks this link, it opens the web-based listing page for your app.</span></span> <span data-ttu-id="2c8b5-109">Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-109">On Windows devices, the Store app will also launch and display your app's listing.</span></span>


## <a name="linking-to-your-apps-store-listing-with-the-microsoft-store-badge"></a><span data-ttu-id="2c8b5-110">Microsoft ストア バッジを使ったアプリのストア登録情報へのリンク</span><span class="sxs-lookup"><span data-stu-id="2c8b5-110">Linking to your app's Store listing with the Microsoft Store badge</span></span>

<span data-ttu-id="2c8b5-111">カスタム バッジを知らせる、Microsoft ストアにアプリを使って、アプリの登録情報に直接リンクすることができます。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-111">You can link directly to your app's listing with a custom badge to let customers know your app is in the Microsoft Store.</span></span>

<span data-ttu-id="2c8b5-112">バッジを作成するには、 [Microsoft Store バッジ](http://go.microsoft.com/fwlink/p/?LinkID=534236)のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-112">To create your badge, visit the [Microsoft Store badges](http://go.microsoft.com/fwlink/p/?LinkID=534236) page.</span></span> <span data-ttu-id="2c8b5-113">バッジとリンクを生成するには、アプリの 12 文字の**ストア ID** が必要です。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-113">You'll need to have your app's 12-character **Store ID** in order to generate the badge and link.</span></span> <span data-ttu-id="2c8b5-114">アプリの**ストア ID** は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-114">You can find your app's **Store ID** on the [App identity](view-app-identity-details.md) page in the **App management** section.</span></span>

> [!NOTE]
> <span data-ttu-id="2c8b5-115">詳細と Microsoft Store バッジの使用に関連する要件については、[アプリのマーケティング ガイドライン](app-marketing-guidelines.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-115">See [App marketing guidelines](app-marketing-guidelines.md) for info and requirements related to your use of the Microsoft Store badge.</span></span>


## <a name="linking-directly-to-your-app-in-the-microsoft-store"></a><span data-ttu-id="2c8b5-116">Microsoft Store のアプリへの直接リンク</span><span class="sxs-lookup"><span data-stu-id="2c8b5-116">Linking directly to your app in the Microsoft Store</span></span>

<span data-ttu-id="2c8b5-117">Microsoft ストアを起動し、直接アプリの登録情報ページを使用して、ブラウザーを開かずにリンクを作成する、 **ms windows ストア:** URI スキーム。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-117">You can create a link that launches the Microsoft Store and goes directly to your app's listing page without opening a browser by using the **ms-windows-store:** URI scheme.</span></span>

<span data-ttu-id="2c8b5-118">ユーザーが Windows デバイスを使っていることがわかっていて、ストアの登録情報ページにユーザーが直接アクセスできるようにする場合は、このリンクが便利です。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-118">These links are useful if you know your users are on a Windows device and you want them to arrive directly at the listing page in the Store.</span></span> <span data-ttu-id="2c8b5-119">たとえば、ブラウザーのユーザー エージェント文字列を調べてユーザーのオペレーティング システムがストアをサポートしていることを確認した後や、既に UWP アプリを使って通信している場合に、このリンクを利用できます。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-119">For example, you might want to use this link after checking user agent strings in a browser to confirm that the user's operating system supports the Store, or when you are already communicating via a UWP app.</span></span>

<span data-ttu-id="2c8b5-120">アプリのストア登録情報に直接リンクをこの URI スキームを使用するには、このリンクをアプリのストア ID を追加します。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-120">To use this URI scheme to link directly to your app's Store listing, append your app's Store ID to this link:</span></span>

`ms-windows-store://pdp/?ProductId=`

<span data-ttu-id="2c8b5-121">Microsoft ストア プロトコルの使用について詳しくは、 [Microsoft アプリの起動](../launch-resume/launch-store-app.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2c8b5-121">For more about using the Microsoft Store protocol, see [Launch the Microsoft app](../launch-resume/launch-store-app.md).</span></span>

 

 




