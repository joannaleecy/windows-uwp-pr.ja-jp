---
title: /titles/{titleId}/sessionhosts
assetID: 92d9bdd2-5c8f-761b-3f9a-50f8db7b843c
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts.html
description: " /titles/{titleId}/sessionhosts"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c0a97d0c87f9204371daeaa825d6636ef6b8409c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658327"
---
# <a name="titlestitleidsessionhosts"></a><span data-ttu-id="9641f-104">/titles/{titleId}/sessionhosts</span><span class="sxs-lookup"><span data-stu-id="9641f-104">/titles/{titleId}/sessionhosts</span></span>
<span data-ttu-id="9641f-105">指定したタイトルの id に割り当てられる Xbox Live コンピューティング sessionhost を要求します。これらの Uri のドメインが`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="9641f-105">Requests a Xbox Live Compute sessionhost to be allocated for a given title id. The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="9641f-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9641f-106">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="9641f-107">ホスト名</span><span class="sxs-lookup"><span data-stu-id="9641f-107">Host Name</span></span>](#ID4EIB)
  * [<span data-ttu-id="9641f-108">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9641f-108">Valid Methods</span></span>](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="9641f-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="9641f-109">URI Parameters</span></span>
 
| <span data-ttu-id="9641f-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9641f-110">Parameter</span></span>| <span data-ttu-id="9641f-111">説明</span><span class="sxs-lookup"><span data-stu-id="9641f-111">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="9641f-112">titleId</span><span class="sxs-lookup"><span data-stu-id="9641f-112">titleId</span></span>| <span data-ttu-id="9641f-113">要求の操作対象のタイトルの ID。</span><span class="sxs-lookup"><span data-stu-id="9641f-113">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a><span data-ttu-id="9641f-114">ホスト名</span><span class="sxs-lookup"><span data-stu-id="9641f-114">Host Name</span></span>
 
<span data-ttu-id="9641f-115">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="9641f-115">gameserverms.xboxlive.com</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="9641f-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="9641f-116">Valid Methods</span></span>
  
[<span data-ttu-id="9641f-117">投稿</span><span class="sxs-lookup"><span data-stu-id="9641f-117">POST</span></span>](uri-titlestitleidsessionhosts-post.md)
 
<span data-ttu-id="9641f-118">&nbsp;&nbsp;クラスターの新しい要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="9641f-118">&nbsp;&nbsp;Create new cluster request.</span></span>
   