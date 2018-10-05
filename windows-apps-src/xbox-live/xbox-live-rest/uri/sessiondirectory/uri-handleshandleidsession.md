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
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4384051"
---
# <a name="handleshandleidsession"></a><span data-ttu-id="56e34-104">/handles/{handleId}/session</span><span class="sxs-lookup"><span data-stu-id="56e34-104">/handles/{handleId}/session</span></span>
<span data-ttu-id="56e34-105">PUT および GET 操作セッションでは、ハンドルを逆参照を使用してをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="56e34-105">Supports PUT and GET operations for a session, using handle dereferencing.</span></span> 

> [!NOTE] 
> <span data-ttu-id="56e34-106">この URI は、2015年マルチプレイヤーで使用し、そのマルチプレイヤーのバージョンにのみ以降を適用します。</span><span class="sxs-lookup"><span data-stu-id="56e34-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="56e34-107">テンプレート コントラクト 104/105 以降で使用する概念があることです。</span><span class="sxs-lookup"><span data-stu-id="56e34-107">It is intended for use with template contract 104/105 or later.</span></span>  

 

> [!NOTE] 
> <span data-ttu-id="56e34-108">この URI は、現在 Xbox One 本体とサーバーのサービスの識別子を使用してアクセスできる外部のみです。</span><span class="sxs-lookup"><span data-stu-id="56e34-108">This URI is currently only externally accessible by Xbox One consoles and servers using a service identifier.</span></span>  

 
<a id="ID4ES"></a>

 
## <a name="domain"></a><span data-ttu-id="56e34-109">ドメイン</span><span class="sxs-lookup"><span data-stu-id="56e34-109">Domain</span></span>
<span data-ttu-id="56e34-110">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="56e34-110">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="56e34-111">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="56e34-111">URI parameters</span></span>
 
| <span data-ttu-id="56e34-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="56e34-112">Parameter</span></span>| <span data-ttu-id="56e34-113">型</span><span class="sxs-lookup"><span data-stu-id="56e34-113">Type</span></span>| <span data-ttu-id="56e34-114">説明</span><span class="sxs-lookup"><span data-stu-id="56e34-114">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="56e34-115">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="56e34-115">handleId</span></span>| <span data-ttu-id="56e34-116">GUID</span><span class="sxs-lookup"><span data-stu-id="56e34-116">GUID</span></span>| <span data-ttu-id="56e34-117">セッション ハンドルの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="56e34-117">The unique ID of the handle for the session.</span></span>| 
  
<a id="ID4ESB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="56e34-118">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="56e34-118">Valid methods</span></span>

[<span data-ttu-id="56e34-119">GET (/handles/{handleId}/session)</span><span class="sxs-lookup"><span data-stu-id="56e34-119">GET (/handles/{handleId}/session)</span></span>](uri-handleshandleidsessionget.md)

<span data-ttu-id="56e34-120">&nbsp;&nbsp;指定したハンドル識別子のセッション オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="56e34-120">&nbsp;&nbsp;Gets a session object for the specified handle identifier.</span></span> 

[<span data-ttu-id="56e34-121">PUT (/handles/{handle-id}/session)</span><span class="sxs-lookup"><span data-stu-id="56e34-121">PUT (/handles/{handle-id}/session)</span></span>](uri-handleshandleidsessionput.md)

<span data-ttu-id="56e34-122">&nbsp;&nbsp;作成またはハンドルを逆参照により、セッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="56e34-122">&nbsp;&nbsp;Creates or updates a session by dereferencing a handle.</span></span>
 
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="56e34-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="56e34-123">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="56e34-124">Parent</span><span class="sxs-lookup"><span data-stu-id="56e34-124">Parent</span></span> 

[<span data-ttu-id="56e34-125">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="56e34-125">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   