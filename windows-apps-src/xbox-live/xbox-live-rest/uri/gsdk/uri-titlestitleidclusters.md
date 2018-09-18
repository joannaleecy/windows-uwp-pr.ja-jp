---
title: /titles/{titleId}/clusters
assetID: 5b1e242c-fd99-180b-e133-87946febd51c
permalink: en-us/docs/xboxlive/rest/uri-titlestitleidclusters.html
author: KevinAsgari
description: " /titles/{titleId}/clusters"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fa44c721c4dffc318270a563e0686318ce80d437
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4022351"
---
# <a name="titlestitleidclusters"></a><span data-ttu-id="59cd7-104">/titles/{titleId}/clusters</span><span class="sxs-lookup"><span data-stu-id="59cd7-104">/titles/{titleId}/clusters</span></span>
<span data-ttu-id="59cd7-105">により、クライアントは、タイトルの Xbox Live Compute サーバー インスタンスを作成する URI。</span><span class="sxs-lookup"><span data-stu-id="59cd7-105">URI that allows a client to create an Xbox Live Compute server instance for a title.</span></span> <span data-ttu-id="59cd7-106">これらの Uri のドメインは、`gameserverds.xboxlive.com`と`gameserverms.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="59cd7-106">The domains for these URIs are `gameserverds.xboxlive.com` and `gameserverms.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="59cd7-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="59cd7-107">URI Parameters</span></span>](#ID4EU)
  * [<span data-ttu-id="59cd7-108">ホスト名</span><span class="sxs-lookup"><span data-stu-id="59cd7-108">Host Name</span></span>](#ID4EIB)
  * [<span data-ttu-id="59cd7-109">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="59cd7-109">Valid Methods</span></span>](#ID4EPB)
 
<a id="ID4EU"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="59cd7-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="59cd7-110">URI Parameters</span></span>
 
| <span data-ttu-id="59cd7-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="59cd7-111">Parameter</span></span>| <span data-ttu-id="59cd7-112">説明</span><span class="sxs-lookup"><span data-stu-id="59cd7-112">Description</span></span>| 
| --- | --- | 
| <span data-ttu-id="59cd7-113">titleId</span><span class="sxs-lookup"><span data-stu-id="59cd7-113">titleId</span></span>| <span data-ttu-id="59cd7-114">要求の操作のタイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="59cd7-114">ID of the title that the request should operate on.</span></span>| 
  
<a id="ID4EIB"></a>

 
## <a name="host-name"></a><span data-ttu-id="59cd7-115">ホスト名</span><span class="sxs-lookup"><span data-stu-id="59cd7-115">Host Name</span></span>
 
<span data-ttu-id="59cd7-116">gameserverms.xboxlive.com</span><span class="sxs-lookup"><span data-stu-id="59cd7-116">gameserverms.xboxlive.com</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="59cd7-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="59cd7-117">Valid Methods</span></span>
  
[<span data-ttu-id="59cd7-118">POST</span><span class="sxs-lookup"><span data-stu-id="59cd7-118">POST</span></span>](uri-titlestitleidclusters-post.md)
 
<span data-ttu-id="59cd7-119">&nbsp;&nbsp;Xbox Live Compute サーバー インスタンスを作成するクライアントをできる URI。</span><span class="sxs-lookup"><span data-stu-id="59cd7-119">&nbsp;&nbsp;URI that allows a client to create an Xbox Live Compute server instance.</span></span>
   