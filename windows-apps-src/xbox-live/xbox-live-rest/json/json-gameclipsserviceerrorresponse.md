---
title: GameClipsServiceErrorResponse (JSON)
assetID: dd606f0f-d52d-f88f-0fff-41c15837f9ed
permalink: en-us/docs/xboxlive/rest/json-gameclipsserviceerrorresponse.html
author: KevinAsgari
description: " GameClipsServiceErrorResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6356000e1a554c948748abf725804a0d9024e40e
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3933640"
---
# <a name="gameclipsserviceerrorresponse-json"></a><span data-ttu-id="cb561-104">GameClipsServiceErrorResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="cb561-104">GameClipsServiceErrorResponse (JSON)</span></span>
<span data-ttu-id="cb561-105">/Users/{ownerId} {scid}/scids//clips/{gameClipId} への応答の省略可能な部分/uri 形式/{gameClipUriType} API です。</span><span class="sxs-lookup"><span data-stu-id="cb561-105">An optional part of the response to the /users/{ownerId}/scids/{scid}/clips/{gameClipId}/uris/format/{gameClipUriType} API.</span></span> 
<a id="ID4EN"></a>

 
## <a name="gameclipsserviceerrorresponse"></a><span data-ttu-id="cb561-106">GameClipsServiceErrorResponse</span><span class="sxs-lookup"><span data-stu-id="cb561-106">GameClipsServiceErrorResponse</span></span>
 
<span data-ttu-id="cb561-107">GameClipsServiceErrorResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="cb561-107">The GameClipsServiceErrorResponse object has the following specification.</span></span>
 
| <span data-ttu-id="cb561-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="cb561-108">Member</span></span>| <span data-ttu-id="cb561-109">種類</span><span class="sxs-lookup"><span data-stu-id="cb561-109">Type</span></span>| <span data-ttu-id="cb561-110">説明</span><span class="sxs-lookup"><span data-stu-id="cb561-110">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="cb561-111">errorSource</span><span class="sxs-lookup"><span data-stu-id="cb561-111">errorSource</span></span></b>| <span data-ttu-id="cb561-112">string</span><span class="sxs-lookup"><span data-stu-id="cb561-112">string</span></span>| <span data-ttu-id="cb561-113">エラーの発生元です。</span><span class="sxs-lookup"><span data-stu-id="cb561-113">Source of the error.</span></span>| 
| <b><span data-ttu-id="cb561-114">errorResponseCode</span><span class="sxs-lookup"><span data-stu-id="cb561-114">errorResponseCode</span></span></b>| <span data-ttu-id="cb561-115">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="cb561-115">32-bit signed integer</span></span>| <span data-ttu-id="cb561-116">(Null にすることができます) エラーに関連付けられたコードです。</span><span class="sxs-lookup"><span data-stu-id="cb561-116">Code associated with the error (can be null).</span></span>| 
| <b><span data-ttu-id="cb561-117">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="cb561-117">errorMessage</span></span></b>| <span data-ttu-id="cb561-118">string</span><span class="sxs-lookup"><span data-stu-id="cb561-118">string</span></span>| <span data-ttu-id="cb561-119">エラーの詳細を追加します。</span><span class="sxs-lookup"><span data-stu-id="cb561-119">Additional details about the error.</span></span>| 
  
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cb561-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="cb561-120">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cb561-121">Parent</span><span class="sxs-lookup"><span data-stu-id="cb561-121">Parent</span></span> 

[<span data-ttu-id="cb561-122">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="cb561-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   