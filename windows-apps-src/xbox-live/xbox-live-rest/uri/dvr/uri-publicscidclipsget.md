---
title: GET (/public/scids/{scid}/clips)
assetID: 15b3e873-1f96-b1da-2f79-6dac1369a4c0
permalink: en-us/docs/xboxlive/rest/uri-publicscidclipsget.html
author: KevinAsgari
description: " GET (/public/scids/{scid}/clips)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b945427118122e3b6d52210efc5e1de84a8c8d68
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4383737"
---
# <a name="get-publicscidsscidclips"></a><span data-ttu-id="c4076-104">GET (/public/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="c4076-104">GET (/public/scids/{scid}/clips)</span></span>
<span data-ttu-id="c4076-105">パブリック クリップを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="c4076-105">List public clips.</span></span> <span data-ttu-id="c4076-106">この URI のドメインが`gameclipsmetadata.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c4076-106">The domain for this URI is `gameclipsmetadata.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c4076-107">注釈</span><span class="sxs-lookup"><span data-stu-id="c4076-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="c4076-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4076-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="c4076-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4076-109">Query string parameters</span></span>](#ID4ENB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="c4076-110">注釈</span><span class="sxs-lookup"><span data-stu-id="c4076-110">Remarks</span></span>
 
<span data-ttu-id="c4076-111">この API は、さまざまな方法は、パブリック一覧クリップにできます。</span><span class="sxs-lookup"><span data-stu-id="c4076-111">This API allows for various ways to list clips that are public.</span></span> <span data-ttu-id="c4076-112">クリップの一覧に基づいて返されたプライバシー チェックと要求元の XUID に対してコンテンツの分離チェックします。</span><span class="sxs-lookup"><span data-stu-id="c4076-112">The list of clips is returned based on privacy checks and content isolation checks against the requesting XUID.</span></span>
 
<span data-ttu-id="c4076-113">クエリは、サービス構成 id (SCID) ごとに最適化されます。</span><span class="sxs-lookup"><span data-stu-id="c4076-113">Queries are optimized per service configuration identifier (SCID).</span></span> <span data-ttu-id="c4076-114">さらにフィルターを使ってまたは以下に示す既定値以外の並べ替え順序を指定するいくつかの状況で長い時間がかかるに戻ります。</span><span class="sxs-lookup"><span data-stu-id="c4076-114">Specifying further filters or sort orders other than the defaults listed below can in some circumstances take longer to return.</span></span> <span data-ttu-id="c4076-115">これは、ビデオの大きなセットのより顕著です。</span><span class="sxs-lookup"><span data-stu-id="c4076-115">This is more evident for larger sets of videos.</span></span> <span data-ttu-id="c4076-116">クエリでは、昇順の並べ替え順序を指定できません。</span><span class="sxs-lookup"><span data-stu-id="c4076-116">Queries cannot specify an ascending sort order.</span></span>
 
<span data-ttu-id="c4076-117">修飾子は、公開のクリップを特定のコレクションを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c4076-117">The qualifier is required to get to the specific collection ofpublic clips.</span></span> <span data-ttu-id="c4076-118">要求元のユーザーに要求された SCID にアクセスする必要があります、そうしないと http/403 が返されます。</span><span class="sxs-lookup"><span data-stu-id="c4076-118">The requesting user must have access to the requested SCID, otherwise HTTP 403 will be returned.</span></span>
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c4076-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4076-119">URI parameters</span></span>
 
| <span data-ttu-id="c4076-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4076-120">Parameter</span></span>| <span data-ttu-id="c4076-121">型</span><span class="sxs-lookup"><span data-stu-id="c4076-121">Type</span></span>| <span data-ttu-id="c4076-122">説明</span><span class="sxs-lookup"><span data-stu-id="c4076-122">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c4076-123">scid</span><span class="sxs-lookup"><span data-stu-id="c4076-123">scid</span></span>| <span data-ttu-id="c4076-124">string</span><span class="sxs-lookup"><span data-stu-id="c4076-124">string</span></span>| <span data-ttu-id="c4076-125">パブリック クリップの主要なサービス構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="c4076-125">The primary service configuration identifier of the public clips.</span></span>| 
| <span data-ttu-id="c4076-126">タイトル id</span><span class="sxs-lookup"><span data-stu-id="c4076-126">titleid</span></span>| <span data-ttu-id="c4076-127">string</span><span class="sxs-lookup"><span data-stu-id="c4076-127">string</span></span>| <span data-ttu-id="c4076-128">パブリック クリップのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="c4076-128">The titleId of the public clips.</span></span> <span data-ttu-id="c4076-129">SCID と同じ URI で指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="c4076-129">Cannot be specified in the same URI as the SCID.</span></span> <span data-ttu-id="c4076-130">指定した場合はプライマリー SCID を検索するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="c4076-130">If specified, will be used to look up the primary SCID.</span></span>| 
  
<a id="ID4ENB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="c4076-131">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4076-131">Query string parameters</span></span>
 
| <span data-ttu-id="c4076-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c4076-132">Parameter</span></span>| <span data-ttu-id="c4076-133">型</span><span class="sxs-lookup"><span data-stu-id="c4076-133">Type</span></span>| <span data-ttu-id="c4076-134">説明</span><span class="sxs-lookup"><span data-stu-id="c4076-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="c4076-135">? achievementId = {achievementId}</span><span class="sxs-lookup"><span data-stu-id="c4076-135">?achievementId={achievementId}</span></span></b>| <span data-ttu-id="c4076-136">最新のクリップが指定した<b>achievementId</b>に一致します。</span><span class="sxs-lookup"><span data-stu-id="c4076-136">Most recent clips matching the specified <b>achievementId</b>.</span></span>| <span data-ttu-id="c4076-137">追加の並べ替え/フィルタ リングはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c4076-137">Additional sorting/filtering is not supported.</span></span>| 
| <b><span data-ttu-id="c4076-138">? greatestMomentId = {greatestMomentId}</span><span class="sxs-lookup"><span data-stu-id="c4076-138">?greatestMomentId={greatestMomentId}</span></span></b>| <span data-ttu-id="c4076-139">最新のクリップが指定した<b>greatestMomentId</b>に一致します。</span><span class="sxs-lookup"><span data-stu-id="c4076-139">Most recent clips matching the specified <b>greatestMomentId</b>.</span></span>| <span data-ttu-id="c4076-140">追加の並べ替え/フィルタ リングはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c4076-140">Additional sorting/filtering is not supported.</span></span>| 
| <b><span data-ttu-id="c4076-141">? 修飾子 = 作成</span><span class="sxs-lookup"><span data-stu-id="c4076-141">?qualifier=created</span></span> </b>| <span data-ttu-id="c4076-142">Most Recent</span><span class="sxs-lookup"><span data-stu-id="c4076-142">Most Recent</span></span>| <span data-ttu-id="c4076-143">必須。</span><span class="sxs-lookup"><span data-stu-id="c4076-143">Required.</span></span>| 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a><span data-ttu-id="c4076-144">関連項目</span><span class="sxs-lookup"><span data-stu-id="c4076-144">See also</span></span>
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a><span data-ttu-id="c4076-145">Parent</span><span class="sxs-lookup"><span data-stu-id="c4076-145">Parent</span></span> 

[<span data-ttu-id="c4076-146">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="c4076-146">/public/scids/{scid}/clips</span></span>](uri-publicscidclips.md)

   