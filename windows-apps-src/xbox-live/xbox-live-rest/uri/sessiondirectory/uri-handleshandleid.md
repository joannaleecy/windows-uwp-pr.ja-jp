---
title: /handles/{ハンドル id を使用}
assetID: 5b722d3e-fe80-fec5-a26b-8b3db6422004
permalink: en-us/docs/xboxlive/rest/uri-handleshandleid.html
author: KevinAsgari
description: " /handles/{ハンドル id を使用}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 47dda291a9a86ccbee69e1e51ca71be373f5dc1d
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3962565"
---
# <a name="handleshandleid"></a><span data-ttu-id="aabed-104">/handles/{ハンドル id を使用}</span><span class="sxs-lookup"><span data-stu-id="aabed-104">/handles/{handleId}</span></span>
<span data-ttu-id="aabed-105">識別子により指定されたセッション ハンドルを削除または取得の操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="aabed-105">Supports DELETE and GET operations for session handles specified by identifier.</span></span> 

> [!NOTE] 
> <span data-ttu-id="aabed-106">この URI は、2015年マルチプレイヤーで使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="aabed-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="aabed-107">テンプレート コントラクト 104/105 以降で使用する概念があることです。</span><span class="sxs-lookup"><span data-stu-id="aabed-107">It is intended for use with template contract 104/105 or later.</span></span>  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a><span data-ttu-id="aabed-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="aabed-108">Domain</span></span>
<span data-ttu-id="aabed-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="aabed-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="aabed-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="aabed-110">URI parameters</span></span>
 
| <span data-ttu-id="aabed-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="aabed-111">Parameter</span></span>| <span data-ttu-id="aabed-112">型</span><span class="sxs-lookup"><span data-stu-id="aabed-112">Type</span></span>| <span data-ttu-id="aabed-113">説明</span><span class="sxs-lookup"><span data-stu-id="aabed-113">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="aabed-114">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="aabed-114">handleId</span></span>| <span data-ttu-id="aabed-115">GUID</span><span class="sxs-lookup"><span data-stu-id="aabed-115">GUID</span></span>| <span data-ttu-id="aabed-116">セッション ハンドルの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="aabed-116">The unique ID of the handle for the session.</span></span>| 
  
<a id="ID4ERB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="aabed-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="aabed-117">Valid methods</span></span>

[<span data-ttu-id="aabed-118">削除 (/handles/{ハンドル id を使用しました)</span><span class="sxs-lookup"><span data-stu-id="aabed-118">DELETE (/handles/{handleId})</span></span>](uri-handleshandleiddelete.md)

<span data-ttu-id="aabed-119">&nbsp;&nbsp;ハンドル ID で指定されたハンドルを削除します。</span><span class="sxs-lookup"><span data-stu-id="aabed-119">&nbsp;&nbsp;Deletes handles specified by handle ID.</span></span>

[<span data-ttu-id="aabed-120">(/Handles/{ハンドル id}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="aabed-120">GET (/handles/{handle-id})</span></span>](uri-handleshandleidget.md)

<span data-ttu-id="aabed-121">&nbsp;&nbsp;ハンドル ID で指定されたハンドルを取得します。</span><span class="sxs-lookup"><span data-stu-id="aabed-121">&nbsp;&nbsp;Retrieves handles specified by handle ID.</span></span>
 
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="aabed-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="aabed-122">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="aabed-123">Parent</span><span class="sxs-lookup"><span data-stu-id="aabed-123">Parent</span></span> 

[<span data-ttu-id="aabed-124">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="aabed-124">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   