---
author: jnHs
Description: You can help customers discover your app by linking to your app's listing in the Microsoft Store.
title: アプリへのリンク
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.author: wdg-dev-content
ms.date: 10/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, リンク, windows store プロトコル, アプリにリンクする, アプリへのリンク
ms.localizationpriority: medium
ms.openlocfilehash: 0025321aa73a66cc0a976bd347e613de3c3c4765
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2836506"
---
# <a name="link-to-your-app"></a><span data-ttu-id="afaf1-103">アプリへのリンク</span><span class="sxs-lookup"><span data-stu-id="afaf1-103">Link to your app</span></span>


<span data-ttu-id="afaf1-104">お客様の Microsoft ストアのアプリの一覧にリンクすることで、アプリを見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="afaf1-104">You can help customers discover your app by linking to your app's listing in the Microsoft Store.</span></span>

## <a name="getting-the-link-to-your-apps-store-listing"></a><span data-ttu-id="afaf1-105">ストアのアプリの内容へのリンク</span><span class="sxs-lookup"><span data-stu-id="afaf1-105">Getting the link to your app's Store listing</span></span>

<span data-ttu-id="afaf1-106">アプリのストア登録情報の URL を取得するには、アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="afaf1-106">To get the URL for your app's Store listing, navigate to the app's [App identity](view-app-identity-details.md) page in the **App management** section.</span></span> <span data-ttu-id="afaf1-107">URL の形式は **`https://www.microsoft.com/store/apps/<your app's Store ID>`** です。</span><span class="sxs-lookup"><span data-stu-id="afaf1-107">The URL is in the format **`https://www.microsoft.com/store/apps/<your app's Store ID>`**.</span></span>

<span data-ttu-id="afaf1-108">ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="afaf1-108">When a customer clicks this link, it opens the web-based listing page for your app.</span></span> <span data-ttu-id="afaf1-109">Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="afaf1-109">On Windows devices, the Store app will also launch and display your app's listing.</span></span>


## <a name="linking-to-your-apps-store-listing-with-the-microsoft-store-badge"></a><span data-ttu-id="afaf1-110">Microsoft ストア バッジ アプリのストア一覧へのリンク</span><span class="sxs-lookup"><span data-stu-id="afaf1-110">Linking to your app's Store listing with the Microsoft Store badge</span></span>

<span data-ttu-id="afaf1-111">直接、Microsoft ストアにアプリを顧客に伝えますにユーザー設定のバッジのアプリの一覧にリンクすることができます。</span><span class="sxs-lookup"><span data-stu-id="afaf1-111">You can link directly to your app's listing with a custom badge to let customers know your app is in the Microsoft Store.</span></span>

<span data-ttu-id="afaf1-112">自分のバッジを作成するには、 [Microsoft ストア バッジ](http://go.microsoft.com/fwlink/p/?LinkID=534236)のページを参照してください。</span><span class="sxs-lookup"><span data-stu-id="afaf1-112">To create your badge, visit the [Microsoft Store badges](http://go.microsoft.com/fwlink/p/?LinkID=534236) page.</span></span> <span data-ttu-id="afaf1-113">バッジとリンクを生成するには、アプリの 12 文字の**ストア ID** が必要です。</span><span class="sxs-lookup"><span data-stu-id="afaf1-113">You'll need to have your app's 12-character **Store ID** in order to generate the badge and link.</span></span> <span data-ttu-id="afaf1-114">アプリの**ストア ID** は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。</span><span class="sxs-lookup"><span data-stu-id="afaf1-114">You can find your app's **Store ID** on the [App identity](view-app-identity-details.md) page in the **App management** section.</span></span>

> [!NOTE]
> <span data-ttu-id="afaf1-115">情報を Microsoft ストア バッジの使用に関連する要件[アプリ マーケティング ガイドライン](app-marketing-guidelines.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="afaf1-115">See [App marketing guidelines](app-marketing-guidelines.md) for info and requirements related to your use of the Microsoft Store badge.</span></span>


## <a name="linking-directly-to-your-app-in-the-microsoft-store"></a><span data-ttu-id="afaf1-116">Microsoft ストアにアプリへの直接のリンク</span><span class="sxs-lookup"><span data-stu-id="afaf1-116">Linking directly to your app in the Microsoft Store</span></span>

<span data-ttu-id="afaf1-117">Microsoft ストアを起動しを開かずに、ブラウザーを使用して、アプリの一覧のページに直接移動するリンクを作成する、 **ms windows-ストア:** uri します。</span><span class="sxs-lookup"><span data-stu-id="afaf1-117">You can create a link that launches the Microsoft Store and goes directly to your app's listing page without opening a browser by using the **ms-windows-store:** URI scheme.</span></span>

<span data-ttu-id="afaf1-118">ユーザーが Windows デバイスを使っていることがわかっていて、ストアの登録情報ページにユーザーが直接アクセスできるようにする場合は、このリンクが便利です。</span><span class="sxs-lookup"><span data-stu-id="afaf1-118">These links are useful if you know your users are on a Windows device and you want them to arrive directly at the listing page in the Store.</span></span> <span data-ttu-id="afaf1-119">たとえば、ブラウザーのユーザー エージェント文字列を調べてユーザーのオペレーティング システムがストアをサポートしていることを確認した後や、既に UWP アプリを使って通信している場合に、このリンクを利用できます。</span><span class="sxs-lookup"><span data-stu-id="afaf1-119">For example, you might want to use this link after checking user agent strings in a browser to confirm that the user's operating system supports the Store, or when you are already communicating via a UWP app.</span></span>

<span data-ttu-id="afaf1-120">この uri を一覧表示するアプリのストアに直接リンクを使用するのには、このリンクをアプリのストア ID を追加します。</span><span class="sxs-lookup"><span data-stu-id="afaf1-120">To use this URI scheme to link directly to your app's Store listing, append your app's Store ID to this link:</span></span>

`ms-windows-store://pdp/?ProductId=`

<span data-ttu-id="afaf1-121">詳細については、Microsoft ストア プロトコルを使用して、 [Microsoft のアプリの起動](../launch-resume/launch-store-app.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="afaf1-121">For more about using the Microsoft Store protocol, see [Launch the Microsoft app](../launch-resume/launch-store-app.md).</span></span>

 

 




