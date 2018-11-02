---
title: /titles/{titleId}/sessionhosts
assetID: 92d9bdd2-5c8f-761b-3f9a-50f8db7b843c
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidsessionhosts.html
author: KevinAsgari
description: " /titles/{titleId}/sessionhosts"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 77868d4bce61c80e9f8ebd0744822c9ade27327e
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5941037"
---
# <a name="titlestitleidsessionhosts"></a><span data-ttu-id="865e4-104">/titles/{titleId}/sessionhosts</span><span class="sxs-lookup"><span data-stu-id="865e4-104">/titles/{titleId}/sessionhosts</span></span>
<span data-ttu-id="865e4-105">特定のタイトル id が割り当ての Xbox Live Compute sessionhost を要求します。これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="865e4-105">Requests a Xbox Live Compute sessionhost to be allocated for a given title id. The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="865e4-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="865e4-106">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="865e4-107">ホスト名</span><span class="sxs-lookup"><span data-stu-id="865e4-107">Host Name</span></span>](#ID4EIB)
  * [<span data-ttu-id="865e4-108">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="865e4-108">Valid Methods</span></span>](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="865e4-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="865e4-109">URI Parameters</span></span>
 
| <span data-ttu-id="865e4-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="865e4-110">Parameter</span></span>| <span data-ttu-id="865e4-111">説明</span><span class="sxs-lookup"><span data-stu-id="865e4-111">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="865e4-112">titleId</span><span class="sxs-lookup"><span data-stu-id="865e4-112">titleId</span></span>| <span data-ttu-id="865e4-113">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="865e4-113">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a><span data-ttu-id="865e4-114">ホスト名</span><span class="sxs-lookup"><span data-stu-id="865e4-114">Host Name</span></span>
 
<span data-ttu-id="865e4-115">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="865e4-115">gameserverms.xboxlive.com</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="865e4-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="865e4-116">Valid Methods</span></span>
  
[<span data-ttu-id="865e4-117">POST</span><span class="sxs-lookup"><span data-stu-id="865e4-117">POST</span></span>](uri-titlestitleidsessionhosts-post.md)
 
<span data-ttu-id="865e4-118">&nbsp;&nbsp;新しいクラスターの要求を作成します。</span><span class="sxs-lookup"><span data-stu-id="865e4-118">&nbsp;&nbsp;Create new cluster request.</span></span>
   