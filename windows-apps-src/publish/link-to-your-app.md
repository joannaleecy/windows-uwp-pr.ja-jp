---
author: jnHs
Description: "アプリのストア登録情報ページにリンクすることで、ユーザーがアプリを見つけやすくすることができます。"
title: "アプリへのリンク"
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, リンク, windows store プロトコル, アプリにリンクする, アプリへのリンク"
ms.openlocfilehash: 2d0750493926937a6326c5f72f568d4294b137c5
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="link-to-your-app"></a><span data-ttu-id="636e1-104">アプリへのリンク</span><span class="sxs-lookup"><span data-stu-id="636e1-104">Link to your app</span></span>


<span data-ttu-id="636e1-105">アプリのストア登録情報ページにリンクすることで、ユーザーがアプリを見つけやすくすることができます。</span><span class="sxs-lookup"><span data-stu-id="636e1-105">You can help customers discover your app by linking to your app's Store listing.</span></span>

## <a name="getting-the-link-to-your-apps-store-listing"></a><span data-ttu-id="636e1-106">アプリのストア登録情報へのリンク</span><span class="sxs-lookup"><span data-stu-id="636e1-106">Getting the link to your app's Store listing</span></span>

<span data-ttu-id="636e1-107">アプリのストア登録情報の URL を取得するには、アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="636e1-107">To get the URL for your app's Store listing, navigate to the app's [App identity](view-app-identity-details.md) page in the **App management** section.</span></span> <span data-ttu-id="636e1-108">URL の形式は **`https://www.microsoft.com/store/apps/<your app's Store ID>`** です。</span><span class="sxs-lookup"><span data-stu-id="636e1-108">The URL is in the format **`https://www.microsoft.com/store/apps/<your app's Store ID>`**.</span></span>

<span data-ttu-id="636e1-109">ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="636e1-109">When a customer clicks this link, it opens the web-based listing page for your app.</span></span> <span data-ttu-id="636e1-110">Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="636e1-110">On Windows devices, the Store app will also launch and display your app's listing.</span></span>


## <a name="linking-to-your-apps-store-listing-with-the-windows-store-badge"></a><span data-ttu-id="636e1-111">Windows ストア バッジを使ったアプリのストア登録情報へのリンク</span><span class="sxs-lookup"><span data-stu-id="636e1-111">Linking to your app's Store listing with the Windows Store badge</span></span>

<span data-ttu-id="636e1-112">カスタム バッジを使ってアプリの登録情報に直接リンクし、ユーザーにアプリが Windows ストアにあることを知らせることができます。</span><span class="sxs-lookup"><span data-stu-id="636e1-112">You can link directly to your app's listing with a custom badge to let customers know your app is in the Windows Store.</span></span>

<span data-ttu-id="636e1-113">バッジを作成するには、[Windows ストア バッジ](http://go.microsoft.com/fwlink/p/?LinkID=534236)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="636e1-113">To create your badge, visit the [Windows Store badges](http://go.microsoft.com/fwlink/p/?LinkID=534236) page.</span></span> <span data-ttu-id="636e1-114">バッジとリンクを生成するには、アプリの 12 文字の**ストア ID** が必要です。</span><span class="sxs-lookup"><span data-stu-id="636e1-114">You'll need to have your app's 12-character **Store ID** in order to generate the badge and link.</span></span> <span data-ttu-id="636e1-115">アプリの**ストア ID** は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。</span><span class="sxs-lookup"><span data-stu-id="636e1-115">You can find your app's **Store ID** on the [App identity](view-app-identity-details.md) page in the **App management** section.</span></span>

> [!NOTE]
> <span data-ttu-id="636e1-116">Windows ストア バッジの使用に関する情報と要件については、[アプリのマーケティング ガイドライン](app-marketing-guidelines.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="636e1-116">See [App marketing guidelines](app-marketing-guidelines.md) for info and requirements related to your use of the Windows Store badge.</span></span>


## <a name="linking-directly-to-your-app-in-the-windows-store"></a><span data-ttu-id="636e1-117">Windows ストアのアプリへの直接リンク</span><span class="sxs-lookup"><span data-stu-id="636e1-117">Linking directly to your app in the Windows Store</span></span>

<span data-ttu-id="636e1-118">ブラウザーを開いて **ms-windows-store:** URI スキームを使わなくても、Windows ストアを起動して、直接アプリの登録情報ページに移動するリンクを作成できます。</span><span class="sxs-lookup"><span data-stu-id="636e1-118">You can create a link that launches the Windows Store and goes directly to your app's listing page without opening a browser by using the **ms-windows-store:** URI scheme.</span></span>

<span data-ttu-id="636e1-119">ユーザーが Windows デバイスを使っていることがわかっていて、ストアの登録情報ページにユーザーが直接アクセスできるようにする場合は、このリンクが便利です。</span><span class="sxs-lookup"><span data-stu-id="636e1-119">These links are useful if you know your users are on a Windows device and you want them to arrive directly at the listing page in the Store.</span></span> <span data-ttu-id="636e1-120">たとえば、ブラウザーのユーザー エージェント文字列を調べてユーザーのオペレーティング システムがストアをサポートしていることを確認した後や、既に UWP アプリを使って通信している場合に、このリンクを利用できます。</span><span class="sxs-lookup"><span data-stu-id="636e1-120">For example, you might want to use this link after checking user agent strings in a browser to confirm that the user's operating system supports the Store, or when you are already communicating via a UWP app.</span></span>

<span data-ttu-id="636e1-121">Windows ストア プロトコルを使って、アプリのストア登録情報に直接リンクするには、このリンクにアプリのストア ID を追加します。</span><span class="sxs-lookup"><span data-stu-id="636e1-121">To use the Windows Store protocol to link directly to your app's Store listing, append your app's Store ID to this link:</span></span>

`ms-windows-store://pdp/?ProductId=`

<span data-ttu-id="636e1-122">Windows ストア プロトコルの使用について詳しくは、「[Windows ストア アプリの起動](../launch-resume/launch-store-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="636e1-122">For more about using the Windows Store protocol, see [Launch the Windows Store app](../launch-resume/launch-store-app.md).</span></span>

 

 




