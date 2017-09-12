---
author: jnHs
Description: "Windows Phone 8.1 以前を対象としたアプリでマップ サービスを使うには、アプリのコードに含めるマップ サービス アプリケーション ID とトークンが必要です。 このトークンは Windows デベロッパー センター ダッシュボードから入手できます。"
title: "マップ サービスの使用"
ms.assetid: E5EE6B56-B86F-4D62-B16A-F023FE98EFAB
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 875d3efd6e9b27d7fced140f3d53a473fad1ae3c
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="use-map-services"></a><span data-ttu-id="838ad-105">マップ サービスの使用</span><span class="sxs-lookup"><span data-stu-id="838ad-105">Use map services</span></span>


<span data-ttu-id="838ad-106">Windows Phone 8.1 以前を対象としたアプリでマップ サービスを使うには、アプリのコードに含めるマップ サービス アプリケーション ID とトークンが必要です。</span><span class="sxs-lookup"><span data-stu-id="838ad-106">To use map services in apps for Windows Phone 8.1 and earlier, you need a map service application ID and a token to include in your app's code.</span></span> <span data-ttu-id="838ad-107">このトークンは、デベロッパー センター ダッシュボードで **[マップ]** ページに移動し、目的のアプリの **[サービス]** セクションから取得できます。</span><span class="sxs-lookup"><span data-stu-id="838ad-107">You can get this token in the Dev Center dashboard by navigating to the **Maps** page in your app's **Services** section.</span></span>

> <span data-ttu-id="838ad-108">**注**  他のオペレーティング システムを対象としたアプリでマップ サービスを使うには、[Bing Maps デベロッパー センター](http://go.microsoft.com/fwlink/p/?LinkId=614880)にアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="838ad-108">**Note**  To use map services in apps targeting other operating systems, visit the [Bing Maps Dev Center](http://go.microsoft.com/fwlink/p/?LinkId=614880).</span></span> <span data-ttu-id="838ad-109">詳しくは、「[マップ認証キーの要求](https://msdn.microsoft.com/library/windows/apps/mt219694)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="838ad-109">See [Request a maps authentication key](https://msdn.microsoft.com/library/windows/apps/mt219694) for more info.</span></span>

<span data-ttu-id="838ad-110">[アプリの名前を予約](create-your-app-by-reserving-a-name.md)したら、左側のナビゲーション メニューの **[サービス]** セクションを探し、そのセクションを展開して、**[マップ]** ページを表示します。</span><span class="sxs-lookup"><span data-stu-id="838ad-110">Once you've [reserved your app's name](create-your-app-by-reserving-a-name.md), look for the **Services** section in the left navigation menu and expand it to show the **Maps** page.</span></span> <span data-ttu-id="838ad-111">**[トークンの取得]** をクリックすると、**ApplicationID** と **AuthenticationToken** が生成され、このページに表示されます。</span><span class="sxs-lookup"><span data-stu-id="838ad-111">When you click **Get token**, the **ApplicationID** and **AuthenticationToken** will be generated and will appear on this page.</span></span>

> <span data-ttu-id="838ad-112">**注**  この時点でアプリの申請を完了する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="838ad-112">**Note**  You don’t have to finish submitting your app at this time.</span></span> <span data-ttu-id="838ad-113">トークンと ID を要求した後も、情報はこのページに保存されます。</span><span class="sxs-lookup"><span data-stu-id="838ad-113">After you request a token and ID, the info will be saved on this page.</span></span> <span data-ttu-id="838ad-114">いつでもこのページに戻って、この情報を参照できます。</span><span class="sxs-lookup"><span data-stu-id="838ad-114">You can return to this page at any time to view this info.</span></span>

<span data-ttu-id="838ad-115">また、アプリをパッケージ化して申請する前に、必ずアプリのコードに **ApplicationID** と **AuthenticationToken** を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="838ad-115">You'll also need to make sure to add the **ApplicationID** and **AuthenticationToken** to your code before you package and submit your app.</span></span> <span data-ttu-id="838ad-116">詳細については、「[Windows Phone 8 でマップ コントロールをページに追加する方法](http://go.microsoft.com/fwlink/p/?LinkId=614882)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="838ad-116">For more info, see [How to add a Map control to a page (Windows Phone 8.1)](http://go.microsoft.com/fwlink/p/?LinkId=614882).</span></span>

 

 




