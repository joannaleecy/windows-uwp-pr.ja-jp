---
title: 取得する (パブリック///} クリップ/)
assetID: 15b3e873-1f96-b1da-2f79-6dac1369a4c0
permalink: en-us/docs/xboxlive/rest/uri-publicscidclipsget.html
author: KevinAsgari
description: " 取得する (パブリック///} クリップ/)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b945427118122e3b6d52210efc5e1de84a8c8d68
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882106"
---
# <a name="get-publicscidsscidclips"></a><span data-ttu-id="96e04-104">取得する (パブリック///} クリップ/)</span><span class="sxs-lookup"><span data-stu-id="96e04-104">GET (/public/scids/{scid}/clips)</span></span>
<span data-ttu-id="96e04-105">パブリック クリップを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="96e04-105">List public clips.</span></span> <span data-ttu-id="96e04-106">この URI のドメインが`gameclipsmetadata.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="96e04-106">The domain for this URI is `gameclipsmetadata.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="96e04-107">注釈</span><span class="sxs-lookup"><span data-stu-id="96e04-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="96e04-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="96e04-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="96e04-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="96e04-109">Query string parameters</span></span>](#ID4ENB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="96e04-110">注釈</span><span class="sxs-lookup"><span data-stu-id="96e04-110">Remarks</span></span>
 
<span data-ttu-id="96e04-111">この API は、さまざまな方法は、パブリック一覧クリップにできます。</span><span class="sxs-lookup"><span data-stu-id="96e04-111">This API allows for various ways to list clips that are public.</span></span> <span data-ttu-id="96e04-112">クリップの一覧に基づいて返されたプライバシー チェックと要求元の XUID に対してコンテンツの分離チェックします。</span><span class="sxs-lookup"><span data-stu-id="96e04-112">The list of clips is returned based on privacy checks and content isolation checks against the requesting XUID.</span></span>
 
<span data-ttu-id="96e04-113">クエリは、サービス構成 id (SCID) ごとに最適化されます。</span><span class="sxs-lookup"><span data-stu-id="96e04-113">Queries are optimized per service configuration identifier (SCID).</span></span> <span data-ttu-id="96e04-114">さらにフィルターを使ってまたは並べ替え順序を以下に示す既定値以外を指定するいくつかの状況で長い時間がかかるに戻ります。</span><span class="sxs-lookup"><span data-stu-id="96e04-114">Specifying further filters or sort orders other than the defaults listed below can in some circumstances take longer to return.</span></span> <span data-ttu-id="96e04-115">これは、ビデオのセットが大規模なより明確です。</span><span class="sxs-lookup"><span data-stu-id="96e04-115">This is more evident for larger sets of videos.</span></span> <span data-ttu-id="96e04-116">クエリでは、順の並べ替え順序を指定できません。</span><span class="sxs-lookup"><span data-stu-id="96e04-116">Queries cannot specify an ascending sort order.</span></span>
 
<span data-ttu-id="96e04-117">公開のクリップを特定のコレクションを取得するのには、修飾子が必要です。</span><span class="sxs-lookup"><span data-stu-id="96e04-117">The qualifier is required to get to the specific collection ofpublic clips.</span></span> <span data-ttu-id="96e04-118">要求元のユーザーに要求された SCID にアクセスする必要があります、そうしないと http/403 が返されます。</span><span class="sxs-lookup"><span data-stu-id="96e04-118">The requesting user must have access to the requested SCID, otherwise HTTP 403 will be returned.</span></span>
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="96e04-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="96e04-119">URI parameters</span></span>
 
| <span data-ttu-id="96e04-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="96e04-120">Parameter</span></span>| <span data-ttu-id="96e04-121">型</span><span class="sxs-lookup"><span data-stu-id="96e04-121">Type</span></span>| <span data-ttu-id="96e04-122">説明</span><span class="sxs-lookup"><span data-stu-id="96e04-122">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="96e04-123">scid</span><span class="sxs-lookup"><span data-stu-id="96e04-123">scid</span></span>| <span data-ttu-id="96e04-124">string</span><span class="sxs-lookup"><span data-stu-id="96e04-124">string</span></span>| <span data-ttu-id="96e04-125">パブリック クリップのプライマリ サービス構成 id。</span><span class="sxs-lookup"><span data-stu-id="96e04-125">The primary service configuration identifier of the public clips.</span></span>| 
| <span data-ttu-id="96e04-126">タイトル id</span><span class="sxs-lookup"><span data-stu-id="96e04-126">titleid</span></span>| <span data-ttu-id="96e04-127">string</span><span class="sxs-lookup"><span data-stu-id="96e04-127">string</span></span>| <span data-ttu-id="96e04-128">パブリック クリップのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="96e04-128">The titleId of the public clips.</span></span> <span data-ttu-id="96e04-129">SCID と同じ URI で指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="96e04-129">Cannot be specified in the same URI as the SCID.</span></span> <span data-ttu-id="96e04-130">指定した場合はプライマリー SCID を検索するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="96e04-130">If specified, will be used to look up the primary SCID.</span></span>| 
  
<a id="ID4ENB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="96e04-131">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="96e04-131">Query string parameters</span></span>
 
| <span data-ttu-id="96e04-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="96e04-132">Parameter</span></span>| <span data-ttu-id="96e04-133">型</span><span class="sxs-lookup"><span data-stu-id="96e04-133">Type</span></span>| <span data-ttu-id="96e04-134">説明</span><span class="sxs-lookup"><span data-stu-id="96e04-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="96e04-135">かどうか achievementId = {achievementId}。</span><span class="sxs-lookup"><span data-stu-id="96e04-135">?achievementId={achievementId}</span></span></b>| <span data-ttu-id="96e04-136">最新のクリップが指定された<b>achievementId</b>に一致します。</span><span class="sxs-lookup"><span data-stu-id="96e04-136">Most recent clips matching the specified <b>achievementId</b>.</span></span>| <span data-ttu-id="96e04-137">追加の並べ替えとフィルター処理することはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="96e04-137">Additional sorting/filtering is not supported.</span></span>| 
| <b><span data-ttu-id="96e04-138">かどうか greatestMomentId = {greatestMomentId}。</span><span class="sxs-lookup"><span data-stu-id="96e04-138">?greatestMomentId={greatestMomentId}</span></span></b>| <span data-ttu-id="96e04-139">最新のクリップが指定された<b>greatestMomentId</b>に一致します。</span><span class="sxs-lookup"><span data-stu-id="96e04-139">Most recent clips matching the specified <b>greatestMomentId</b>.</span></span>| <span data-ttu-id="96e04-140">追加の並べ替えとフィルター処理することはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="96e04-140">Additional sorting/filtering is not supported.</span></span>| 
| <b><span data-ttu-id="96e04-141">かどうか修飾子 = 作成。</span><span class="sxs-lookup"><span data-stu-id="96e04-141">?qualifier=created</span></span> </b>| <span data-ttu-id="96e04-142">Most Recent</span><span class="sxs-lookup"><span data-stu-id="96e04-142">Most Recent</span></span>| <span data-ttu-id="96e04-143">必須。</span><span class="sxs-lookup"><span data-stu-id="96e04-143">Required.</span></span>| 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a><span data-ttu-id="96e04-144">関連項目</span><span class="sxs-lookup"><span data-stu-id="96e04-144">See also</span></span>
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a><span data-ttu-id="96e04-145">Parent</span><span class="sxs-lookup"><span data-stu-id="96e04-145">Parent</span></span> 

[<span data-ttu-id="96e04-146">パブリック///} クリップ/</span><span class="sxs-lookup"><span data-stu-id="96e04-146">/public/scids/{scid}/clips</span></span>](uri-publicscidclips.md)

   