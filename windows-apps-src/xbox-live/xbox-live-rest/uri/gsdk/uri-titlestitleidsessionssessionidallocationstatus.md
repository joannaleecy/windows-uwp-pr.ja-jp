---
title: /titles/{titleId}/sessions/{sessionId}/allocationStatus
assetID: 55611f4b-4ba4-fa9a-ce44-fcc4a6df1b35
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionssessionidallocationstatus.html
author: KevinAsgari
description: " /titles/{titleId}/sessions/{sessionId}/allocationStatus"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f8137980bddbf494c989f4f8a39c2f6edaf3d30a
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3928919"
---
# <a name="titlestitleidsessionssessionidallocationstatus"></a><span data-ttu-id="5ee33-104">/titles/{titleId}/sessions/{sessionId}/allocationStatus</span><span class="sxs-lookup"><span data-stu-id="5ee33-104">/titles/{titleId}/sessions/{sessionId}/allocationStatus</span></span>
<span data-ttu-id="5ee33-105">特定のタイトル id とセッション id、チケットの要求の状態を取得します。</span><span class="sxs-lookup"><span data-stu-id="5ee33-105">For the given title id and session id, get status of the ticket request.</span></span> <span data-ttu-id="5ee33-106">これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="5ee33-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="5ee33-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5ee33-107">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="5ee33-108">ホスト名</span><span class="sxs-lookup"><span data-stu-id="5ee33-108">Host Name</span></span>](#ID4EPB)
  * [<span data-ttu-id="5ee33-109">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5ee33-109">Valid Methods</span></span>](#ID4EWB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="5ee33-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5ee33-110">URI Parameters</span></span>
 
| <span data-ttu-id="5ee33-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="5ee33-111">Parameter</span></span>| <span data-ttu-id="5ee33-112">説明</span><span class="sxs-lookup"><span data-stu-id="5ee33-112">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="5ee33-113">titleId</span><span class="sxs-lookup"><span data-stu-id="5ee33-113">titleId</span></span>| <span data-ttu-id="5ee33-114">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="5ee33-114">ID of the title that the request should operate on.</span></span>| 
| <span data-ttu-id="5ee33-115">sessionId</span><span class="sxs-lookup"><span data-stu-id="5ee33-115">sessionId</span></span>| <span data-ttu-id="5ee33-116">検索するセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="5ee33-116">the ID of the session to look up.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="host-name"></a><span data-ttu-id="5ee33-117">ホスト名</span><span class="sxs-lookup"><span data-stu-id="5ee33-117">Host Name</span></span>
 
<span data-ttu-id="5ee33-118">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="5ee33-118">gameserverms.xboxlive.com</span></span>
  
<a id="ID4EWB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="5ee33-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="5ee33-119">Valid Methods</span></span>
  
[<span data-ttu-id="5ee33-120">GET</span><span class="sxs-lookup"><span data-stu-id="5ee33-120">GET</span></span>](uri-titlestitleidsessionssessionidallocationstatus-get.md)
 
<span data-ttu-id="5ee33-121">&nbsp;&nbsp;その sessionId で識別される sessionhost の割り当ての状態を返します。</span><span class="sxs-lookup"><span data-stu-id="5ee33-121">&nbsp;&nbsp;Returns the allocation status of the sessionhost identified by its sessionId.</span></span>
   