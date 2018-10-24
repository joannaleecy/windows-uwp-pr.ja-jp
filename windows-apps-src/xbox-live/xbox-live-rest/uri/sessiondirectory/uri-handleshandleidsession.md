---
title: /handles/{handleId}/session
assetID: 4ed2dcf5-5d1f-91ce-4a3f-eb3ba68727bf
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsession.html
author: KevinAsgari
description: " /handles/{handleId}/session"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: eb7ca17500f571ed72cf0bcd6ececbcde17ce717
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5436313"
---
# <a name="handleshandleidsession"></a><span data-ttu-id="e38e6-104">/handles/{handleId}/session</span><span class="sxs-lookup"><span data-stu-id="e38e6-104">/handles/{handleId}/session</span></span>
<span data-ttu-id="e38e6-105">PUT および GET 操作セッションでは、ハンドルを逆参照を使用してをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="e38e6-105">Supports PUT and GET operations for a session, using handle dereferencing.</span></span> 

> [!NOTE] 
> <span data-ttu-id="e38e6-106">この URI は、2015年マルチプレイヤーで使用され、および後でそのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="e38e6-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="e38e6-107">テンプレート コントラクト 104/105 以降で使用されます。</span><span class="sxs-lookup"><span data-stu-id="e38e6-107">It is intended for use with template contract 104/105 or later.</span></span>  

 

> [!NOTE] 
> <span data-ttu-id="e38e6-108">この URI は、現在 Xbox One 本体とサービスの識別子を使用してサーバーによって外部的にもアクセスのみです。</span><span class="sxs-lookup"><span data-stu-id="e38e6-108">This URI is currently only externally accessible by Xbox One consoles and servers using a service identifier.</span></span>  

 
<a id="ID4ES"></a>

 
## <a name="domain"></a><span data-ttu-id="e38e6-109">ドメイン</span><span class="sxs-lookup"><span data-stu-id="e38e6-109">Domain</span></span>
<span data-ttu-id="e38e6-110">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="e38e6-110">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e38e6-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e38e6-111">URI parameters</span></span>
 
| <span data-ttu-id="e38e6-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e38e6-112">Parameter</span></span>| <span data-ttu-id="e38e6-113">型</span><span class="sxs-lookup"><span data-stu-id="e38e6-113">Type</span></span>| <span data-ttu-id="e38e6-114">説明</span><span class="sxs-lookup"><span data-stu-id="e38e6-114">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="e38e6-115">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="e38e6-115">handleId</span></span>| <span data-ttu-id="e38e6-116">GUID</span><span class="sxs-lookup"><span data-stu-id="e38e6-116">GUID</span></span>| <span data-ttu-id="e38e6-117">セッションのハンドルを一意の ID。</span><span class="sxs-lookup"><span data-stu-id="e38e6-117">The unique ID of the handle for the session.</span></span>| 
  
<a id="ID4ESB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="e38e6-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="e38e6-118">Valid methods</span></span>

[<span data-ttu-id="e38e6-119">GET (/handles/{handleId}/session)</span><span class="sxs-lookup"><span data-stu-id="e38e6-119">GET (/handles/{handleId}/session)</span></span>](uri-handleshandleidsessionget.md)

<span data-ttu-id="e38e6-120">&nbsp;&nbsp;指定したハンドル識別子のセッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="e38e6-120">&nbsp;&nbsp;Gets a session object for the specified handle identifier.</span></span> 

[<span data-ttu-id="e38e6-121">PUT (/handles/{handle-id}/session)</span><span class="sxs-lookup"><span data-stu-id="e38e6-121">PUT (/handles/{handle-id}/session)</span></span>](uri-handleshandleidsessionput.md)

<span data-ttu-id="e38e6-122">&nbsp;&nbsp;作成またはハンドルを逆参照によってセッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="e38e6-122">&nbsp;&nbsp;Creates or updates a session by dereferencing a handle.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="e38e6-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="e38e6-123">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e38e6-124">Parent</span><span class="sxs-lookup"><span data-stu-id="e38e6-124">Parent</span></span> 

[<span data-ttu-id="e38e6-125">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="e38e6-125">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   