---
title: /handles/{handleId}/session
assetID: 4ed2dcf5-5d1f-91ce-4a3f-eb3ba68727bf
permalink: en-us/docs/xboxlive/rest/uri-handleshandleidsession.html
description: " /handles/{handleId}/session"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e7b6990917437c22dd4d9282492e2a0eab37893b
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8778816"
---
# <a name="handleshandleidsession"></a><span data-ttu-id="82ed1-104">/handles/{handleId}/session</span><span class="sxs-lookup"><span data-stu-id="82ed1-104">/handles/{handleId}/session</span></span>
<span data-ttu-id="82ed1-105">PUT および GET 操作セッションでは、ハンドルを逆参照を使用してをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="82ed1-105">Supports PUT and GET operations for a session, using handle dereferencing.</span></span> 

> [!NOTE] 
> <span data-ttu-id="82ed1-106">この URI は、2015年マルチプレイヤーで使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="82ed1-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="82ed1-107">テンプレート コントラクト 104/105 以降で使用されます。</span><span class="sxs-lookup"><span data-stu-id="82ed1-107">It is intended for use with template contract 104/105 or later.</span></span>  

 

> [!NOTE] 
> <span data-ttu-id="82ed1-108">この URI は、現在 Xbox One 本体とサーバーのサービスの識別子を使用してアクセスできる外部のみです。</span><span class="sxs-lookup"><span data-stu-id="82ed1-108">This URI is currently only externally accessible by Xbox One consoles and servers using a service identifier.</span></span>  

 
<a id="ID4ES"></a>

 
## <a name="domain"></a><span data-ttu-id="82ed1-109">ドメイン</span><span class="sxs-lookup"><span data-stu-id="82ed1-109">Domain</span></span>
<span data-ttu-id="82ed1-110">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="82ed1-110">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="82ed1-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="82ed1-111">URI parameters</span></span>
 
| <span data-ttu-id="82ed1-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="82ed1-112">Parameter</span></span>| <span data-ttu-id="82ed1-113">型</span><span class="sxs-lookup"><span data-stu-id="82ed1-113">Type</span></span>| <span data-ttu-id="82ed1-114">説明</span><span class="sxs-lookup"><span data-stu-id="82ed1-114">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="82ed1-115">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="82ed1-115">handleId</span></span>| <span data-ttu-id="82ed1-116">GUID</span><span class="sxs-lookup"><span data-stu-id="82ed1-116">GUID</span></span>| <span data-ttu-id="82ed1-117">セッション ハンドルの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="82ed1-117">The unique ID of the handle for the session.</span></span>| 
  
<a id="ID4ESB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="82ed1-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="82ed1-118">Valid methods</span></span>

[<span data-ttu-id="82ed1-119">GET (/handles/{handleId}/session)</span><span class="sxs-lookup"><span data-stu-id="82ed1-119">GET (/handles/{handleId}/session)</span></span>](uri-handleshandleidsessionget.md)

<span data-ttu-id="82ed1-120">&nbsp;&nbsp;指定したハンドル識別子セッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="82ed1-120">&nbsp;&nbsp;Gets a session object for the specified handle identifier.</span></span> 

[<span data-ttu-id="82ed1-121">PUT (/handles/{handle-id}/session)</span><span class="sxs-lookup"><span data-stu-id="82ed1-121">PUT (/handles/{handle-id}/session)</span></span>](uri-handleshandleidsessionput.md)

<span data-ttu-id="82ed1-122">&nbsp;&nbsp;作成またはハンドルを逆参照によって、セッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="82ed1-122">&nbsp;&nbsp;Creates or updates a session by dereferencing a handle.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="82ed1-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="82ed1-123">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="82ed1-124">Parent</span><span class="sxs-lookup"><span data-stu-id="82ed1-124">Parent</span></span> 

[<span data-ttu-id="82ed1-125">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="82ed1-125">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   