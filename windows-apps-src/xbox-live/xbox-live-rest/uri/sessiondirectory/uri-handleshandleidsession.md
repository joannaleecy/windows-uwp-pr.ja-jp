---
title: /handles/{ハンドル id を使用}/セッション
assetID: 4ed2dcf5-5d1f-91ce-4a3f-eb3ba68727bf
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsession.html
author: KevinAsgari
description: " /handles/{ハンドル id を使用}/セッション"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: eb7ca17500f571ed72cf0bcd6ececbcde17ce717
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881835"
---
# <a name="handleshandleidsession"></a><span data-ttu-id="e0df9-104">/handles/{ハンドル id を使用}/セッション</span><span class="sxs-lookup"><span data-stu-id="e0df9-104">/handles/{handleId}/session</span></span>
<span data-ttu-id="e0df9-105">PUT を取得する操作セッションでは、ハンドルを逆参照を使用してをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e0df9-105">Supports PUT and GET operations for a session, using handle dereferencing.</span></span> 

> [!NOTE] 
> <span data-ttu-id="e0df9-106">この URI は、2015年マルチプレイヤーでは使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="e0df9-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="e0df9-107">テンプレート コントラクト 104/105 以降で使用して設計されています。</span><span class="sxs-lookup"><span data-stu-id="e0df9-107">It is intended for use with template contract 104/105 or later.</span></span>  

 

> [!NOTE] 
> <span data-ttu-id="e0df9-108">この URI は、現在 Xbox One 本体とサーバーのサービスの識別子を使用してアクセスできる外部のみです。</span><span class="sxs-lookup"><span data-stu-id="e0df9-108">This URI is currently only externally accessible by Xbox One consoles and servers using a service identifier.</span></span>  

 
<a id="ID4ES"></a>

 
## <a name="domain"></a><span data-ttu-id="e0df9-109">ドメイン</span><span class="sxs-lookup"><span data-stu-id="e0df9-109">Domain</span></span>
<span data-ttu-id="e0df9-110">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="e0df9-110">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e0df9-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e0df9-111">URI parameters</span></span>
 
| <span data-ttu-id="e0df9-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e0df9-112">Parameter</span></span>| <span data-ttu-id="e0df9-113">型</span><span class="sxs-lookup"><span data-stu-id="e0df9-113">Type</span></span>| <span data-ttu-id="e0df9-114">説明</span><span class="sxs-lookup"><span data-stu-id="e0df9-114">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="e0df9-115">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="e0df9-115">handleId</span></span>| <span data-ttu-id="e0df9-116">GUID</span><span class="sxs-lookup"><span data-stu-id="e0df9-116">GUID</span></span>| <span data-ttu-id="e0df9-117">セッションのハンドルを一意の ID。</span><span class="sxs-lookup"><span data-stu-id="e0df9-117">The unique ID of the handle for the session.</span></span>| 
  
<a id="ID4ESB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e0df9-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e0df9-118">Valid methods</span></span>

[<span data-ttu-id="e0df9-119">取得する (/handles/{ハンドル id を使用}/セッション)</span><span class="sxs-lookup"><span data-stu-id="e0df9-119">GET (/handles/{handleId}/session)</span></span>](uri-handleshandleidsessionget.md)

<span data-ttu-id="e0df9-120">&nbsp;&nbsp;指定したハンドル識別子セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="e0df9-120">&nbsp;&nbsp;Gets a session object for the specified handle identifier.</span></span> 

[<span data-ttu-id="e0df9-121">配置 (/handles/{ハンドル id}/セッション)</span><span class="sxs-lookup"><span data-stu-id="e0df9-121">PUT (/handles/{handle-id}/session)</span></span>](uri-handleshandleidsessionput.md)

<span data-ttu-id="e0df9-122">&nbsp;&nbsp;作成またはハンドルを逆参照によって、セッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="e0df9-122">&nbsp;&nbsp;Creates or updates a session by dereferencing a handle.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="e0df9-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="e0df9-123">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e0df9-124">Parent</span><span class="sxs-lookup"><span data-stu-id="e0df9-124">Parent</span></span> 

[<span data-ttu-id="e0df9-125">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="e0df9-125">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   