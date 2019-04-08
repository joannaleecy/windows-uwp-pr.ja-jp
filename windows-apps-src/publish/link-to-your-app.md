---
Description: お客様の Microsoft Store でアプリの一覧にリンクすることで、アプリを検出することができます。
title: アプリへのリンク
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, リンク, windows store プロトコル, アプリにリンクする, アプリへのリンク
ms.localizationpriority: medium
ms.openlocfilehash: 56bc051c3c5a935f3b6b26e478731fcde9c06902
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661537"
---
# <a name="link-to-your-app"></a><span data-ttu-id="6b5c5-104">アプリへのリンク</span><span class="sxs-lookup"><span data-stu-id="6b5c5-104">Link to your app</span></span>


<span data-ttu-id="6b5c5-105">お客様の Microsoft Store でアプリの一覧にリンクすることで、アプリを検出することができます。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-105">You can help customers discover your app by linking to your app's listing in the Microsoft Store.</span></span>

## <a name="getting-the-link-to-your-apps-store-listing"></a><span data-ttu-id="6b5c5-106">アプリのストア登録情報へのリンク</span><span class="sxs-lookup"><span data-stu-id="6b5c5-106">Getting the link to your app's Store listing</span></span>

<span data-ttu-id="6b5c5-107">アプリのストア登録情報の URL を取得するには、アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-107">To get the URL for your app's Store listing, navigate to the app's [App identity](view-app-identity-details.md) page in the **App management** section.</span></span> <span data-ttu-id="6b5c5-108">URL の形式は **`https://www.microsoft.com/store/apps/<your app's Store ID>`** です。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-108">The URL is in the format **`https://www.microsoft.com/store/apps/<your app's Store ID>`**.</span></span>

<span data-ttu-id="6b5c5-109">ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-109">When a customer clicks this link, it opens the web-based listing page for your app.</span></span> <span data-ttu-id="6b5c5-110">Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-110">On Windows devices, the Store app will also launch and display your app's listing.</span></span>


## <a name="linking-to-your-apps-store-listing-with-the-microsoft-store-badge"></a><span data-ttu-id="6b5c5-111">Microsoft Store バッジが付いた、アプリのストアの一覧へのリンク</span><span class="sxs-lookup"><span data-stu-id="6b5c5-111">Linking to your app's Store listing with the Microsoft Store badge</span></span>

<span data-ttu-id="6b5c5-112">Microsoft Store アプリがユーザーに知らせるにカスタム バッジでのアプリの一覧に直接リンクすることができます。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-112">You can link directly to your app's listing with a custom badge to let customers know your app is in the Microsoft Store.</span></span>

<span data-ttu-id="6b5c5-113">バッジを作成するを参照してください。、 [Microsoft Store のバッジ](https://go.microsoft.com/fwlink/p/?LinkID=534236)ページ。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-113">To create your badge, visit the [Microsoft Store badges](https://go.microsoft.com/fwlink/p/?LinkID=534236) page.</span></span> <span data-ttu-id="6b5c5-114">バッジとリンクを生成するには、アプリの 12 文字の**ストア ID** が必要です。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-114">You'll need to have your app's 12-character **Store ID** in order to generate the badge and link.</span></span> <span data-ttu-id="6b5c5-115">アプリの**ストア ID** は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-115">You can find your app's **Store ID** on the [App identity](view-app-identity-details.md) page in the **App management** section.</span></span>

> [!NOTE]
> <span data-ttu-id="6b5c5-116">参照してください[App marketing ガイドライン](app-marketing-guidelines.md)情報と Microsoft Store バッジの使用に関連する要件。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-116">See [App marketing guidelines](app-marketing-guidelines.md) for info and requirements related to your use of the Microsoft Store badge.</span></span>


## <a name="linking-directly-to-your-app-in-the-microsoft-store"></a><span data-ttu-id="6b5c5-117">Microsoft Store でアプリに直接リンク</span><span class="sxs-lookup"><span data-stu-id="6b5c5-117">Linking directly to your app in the Microsoft Store</span></span>

<span data-ttu-id="6b5c5-118">Microsoft Store を起動しを使用して、ブラウザーを開くことがなく、アプリの一覧ページに直接移動するリンクを作成することができます、 **ms-windows ストア。** URI スキーム。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-118">You can create a link that launches the Microsoft Store and goes directly to your app's listing page without opening a browser by using the **ms-windows-store:** URI scheme.</span></span>

<span data-ttu-id="6b5c5-119">ユーザーが Windows デバイスを使っていることがわかっていて、ストアの登録情報ページにユーザーが直接アクセスできるようにする場合は、このリンクが便利です。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-119">These links are useful if you know your users are on a Windows device and you want them to arrive directly at the listing page in the Store.</span></span> <span data-ttu-id="6b5c5-120">たとえば、ブラウザーのユーザー エージェント文字列を調べてユーザーのオペレーティング システムがストアをサポートしていることを確認した後や、既に UWP アプリを使って通信している場合に、このリンクを利用できます。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-120">For example, you might want to use this link after checking user agent strings in a browser to confirm that the user's operating system supports the Store, or when you are already communicating via a UWP app.</span></span>

<span data-ttu-id="6b5c5-121">この URI スキームを使用して、一覧表示するアプリのストアに直接リンクする、次のリンクをアプリの Store ID を追加します。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-121">To use this URI scheme to link directly to your app's Store listing, append your app's Store ID to this link:</span></span>

`ms-windows-store://pdp/?ProductId=`

<span data-ttu-id="6b5c5-122">詳細については、Microsoft Store のプロトコルを使用して、次を参照してください。 [Microsoft アプリを起動](../launch-resume/launch-store-app.md)します。</span><span class="sxs-lookup"><span data-stu-id="6b5c5-122">For more about using the Microsoft Store protocol, see [Launch the Microsoft app](../launch-resume/launch-store-app.md).</span></span>

 

 




