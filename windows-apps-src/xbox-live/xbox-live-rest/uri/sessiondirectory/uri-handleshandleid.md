---
title: /handles/{handleId}
assetID: 5b722d3e-fe80-fec5-a26b-8b3db6422004
permalink: en-us/docs/xboxlive/rest/uri-handleshandleid.html
description: " /handles/{handleId}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3a312d3744e96755a899d73307a47c01e3dc79fd
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8732740"
---
# <a name="handleshandleid"></a><span data-ttu-id="c02c0-104">/handles/{handleId}</span><span class="sxs-lookup"><span data-stu-id="c02c0-104">/handles/{handleId}</span></span>
<span data-ttu-id="c02c0-105">識別子により指定されたセッション ハンドルの削除と取得の操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="c02c0-105">Supports DELETE and GET operations for session handles specified by identifier.</span></span> 

> [!NOTE] 
> <span data-ttu-id="c02c0-106">この URI は、2015年マルチプレイヤーで使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="c02c0-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="c02c0-107">テンプレート コントラクト 104/105 以降で使用されます。</span><span class="sxs-lookup"><span data-stu-id="c02c0-107">It is intended for use with template contract 104/105 or later.</span></span>  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a><span data-ttu-id="c02c0-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="c02c0-108">Domain</span></span>
<span data-ttu-id="c02c0-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="c02c0-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c02c0-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c02c0-110">URI parameters</span></span>
 
| <span data-ttu-id="c02c0-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c02c0-111">Parameter</span></span>| <span data-ttu-id="c02c0-112">型</span><span class="sxs-lookup"><span data-stu-id="c02c0-112">Type</span></span>| <span data-ttu-id="c02c0-113">説明</span><span class="sxs-lookup"><span data-stu-id="c02c0-113">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="c02c0-114">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="c02c0-114">handleId</span></span>| <span data-ttu-id="c02c0-115">GUID</span><span class="sxs-lookup"><span data-stu-id="c02c0-115">GUID</span></span>| <span data-ttu-id="c02c0-116">セッション ハンドルの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="c02c0-116">The unique ID of the handle for the session.</span></span>| 
  
<a id="ID4ERB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="c02c0-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="c02c0-117">Valid methods</span></span>

[<span data-ttu-id="c02c0-118">DELETE (/handles/{handleId})</span><span class="sxs-lookup"><span data-stu-id="c02c0-118">DELETE (/handles/{handleId})</span></span>](uri-handleshandleiddelete.md)

<span data-ttu-id="c02c0-119">&nbsp;&nbsp;ハンドル ID で指定されたハンドルを削除します。</span><span class="sxs-lookup"><span data-stu-id="c02c0-119">&nbsp;&nbsp;Deletes handles specified by handle ID.</span></span>

[<span data-ttu-id="c02c0-120">GET (/handles/{handle-id})</span><span class="sxs-lookup"><span data-stu-id="c02c0-120">GET (/handles/{handle-id})</span></span>](uri-handleshandleidget.md)

<span data-ttu-id="c02c0-121">&nbsp;&nbsp;ハンドル ID で指定されたハンドルを取得します。</span><span class="sxs-lookup"><span data-stu-id="c02c0-121">&nbsp;&nbsp;Retrieves handles specified by handle ID.</span></span>
 
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="c02c0-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="c02c0-122">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="c02c0-123">Parent</span><span class="sxs-lookup"><span data-stu-id="c02c0-123">Parent</span></span> 

[<span data-ttu-id="c02c0-124">セッション ディレクトリ URI</span><span class="sxs-lookup"><span data-stu-id="c02c0-124">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   