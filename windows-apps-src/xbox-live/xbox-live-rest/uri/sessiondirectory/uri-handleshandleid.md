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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882533"
---
# <a name="handleshandleid"></a><span data-ttu-id="5705f-104">/handles/{ハンドル id を使用}</span><span class="sxs-lookup"><span data-stu-id="5705f-104">/handles/{handleId}</span></span>
<span data-ttu-id="5705f-105">識別子により指定されたセッション ハンドルの削除を取得する操作をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="5705f-105">Supports DELETE and GET operations for session handles specified by identifier.</span></span> 

> [!NOTE] 
> <span data-ttu-id="5705f-106">この URI は、2015年マルチプレイヤーでは使用され、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="5705f-106">This URI is used by 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="5705f-107">テンプレート コントラクト 104/105 以降で使用して設計されています。</span><span class="sxs-lookup"><span data-stu-id="5705f-107">It is intended for use with template contract 104/105 or later.</span></span>  

 
<a id="ID4EQ"></a>

 
## <a name="domain"></a><span data-ttu-id="5705f-108">ドメイン</span><span class="sxs-lookup"><span data-stu-id="5705f-108">Domain</span></span>
<span data-ttu-id="5705f-109">sessiondirectory.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="5705f-109">sessiondirectory.xboxlive.com</span></span>  
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5705f-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5705f-110">URI parameters</span></span>
 
| <span data-ttu-id="5705f-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5705f-111">Parameter</span></span>| <span data-ttu-id="5705f-112">型</span><span class="sxs-lookup"><span data-stu-id="5705f-112">Type</span></span>| <span data-ttu-id="5705f-113">説明</span><span class="sxs-lookup"><span data-stu-id="5705f-113">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="5705f-114">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="5705f-114">handleId</span></span>| <span data-ttu-id="5705f-115">GUID</span><span class="sxs-lookup"><span data-stu-id="5705f-115">GUID</span></span>| <span data-ttu-id="5705f-116">セッションのハンドルを一意の ID。</span><span class="sxs-lookup"><span data-stu-id="5705f-116">The unique ID of the handle for the session.</span></span>| 
  
<a id="ID4ERB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="5705f-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5705f-117">Valid methods</span></span>

[<span data-ttu-id="5705f-118">(/Handles/{ハンドル id を使用}) を削除します。</span><span class="sxs-lookup"><span data-stu-id="5705f-118">DELETE (/handles/{handleId})</span></span>](uri-handleshandleiddelete.md)

<span data-ttu-id="5705f-119">&nbsp;&nbsp;ハンドル ID で指定されたハンドルを削除します。</span><span class="sxs-lookup"><span data-stu-id="5705f-119">&nbsp;&nbsp;Deletes handles specified by handle ID.</span></span>

[<span data-ttu-id="5705f-120">(/Handles/{ハンドル id}) を取得します。</span><span class="sxs-lookup"><span data-stu-id="5705f-120">GET (/handles/{handle-id})</span></span>](uri-handleshandleidget.md)

<span data-ttu-id="5705f-121">&nbsp;&nbsp;ハンドル ID で指定されたハンドルを取得します。</span><span class="sxs-lookup"><span data-stu-id="5705f-121">&nbsp;&nbsp;Retrieves handles specified by handle ID.</span></span>
 
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="5705f-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="5705f-122">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="5705f-123">Parent</span><span class="sxs-lookup"><span data-stu-id="5705f-123">Parent</span></span> 

[<span data-ttu-id="5705f-124">セッション ディレクトリ Uri</span><span class="sxs-lookup"><span data-stu-id="5705f-124">Session Directory URIs</span></span>](atoc-reference-sessiondirectory.md)

   