---
title: /titles/{titleId}/sessionhosts
assetID: 92d9bdd2-5c8f-761b-3f9a-50f8db7b843c
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts.html
author: KevinAsgari
description: " /titles/{titleId}/sessionhosts"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a93e134dba9ce66b8b6b547308f926112f6a577f
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4267920"
---
# <a name="titlestitleidsessionhosts"></a><span data-ttu-id="cce30-104">/titles/{titleId}/sessionhosts</span><span class="sxs-lookup"><span data-stu-id="cce30-104">/titles/{titleId}/sessionhosts</span></span>
<span data-ttu-id="cce30-105">特定のタイトル id に割り当てられる Xbox Live Compute sessionhost を要求します。これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cce30-105">Requests a Xbox Live Compute sessionhost to be allocated for a given title id. The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="cce30-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cce30-106">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="cce30-107">ホスト名</span><span class="sxs-lookup"><span data-stu-id="cce30-107">Host Name</span></span>](#ID4EIB)
  * [<span data-ttu-id="cce30-108">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="cce30-108">Valid Methods</span></span>](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cce30-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cce30-109">URI Parameters</span></span>
 
| <span data-ttu-id="cce30-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cce30-110">Parameter</span></span>| <span data-ttu-id="cce30-111">説明</span><span class="sxs-lookup"><span data-stu-id="cce30-111">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="cce30-112">titleId</span><span class="sxs-lookup"><span data-stu-id="cce30-112">titleId</span></span>| <span data-ttu-id="cce30-113">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="cce30-113">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a><span data-ttu-id="cce30-114">ホスト名</span><span class="sxs-lookup"><span data-stu-id="cce30-114">Host Name</span></span>
 
<span data-ttu-id="cce30-115">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="cce30-115">gameserverms.xboxlive.com</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="cce30-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="cce30-116">Valid Methods</span></span>
  
[<span data-ttu-id="cce30-117">POST</span><span class="sxs-lookup"><span data-stu-id="cce30-117">POST</span></span>](uri-titlestitleidsessionhosts-post.md)
 
<span data-ttu-id="cce30-118">&nbsp;&nbsp;新しいクラスターの要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="cce30-118">&nbsp;&nbsp;Create new cluster request.</span></span>
   