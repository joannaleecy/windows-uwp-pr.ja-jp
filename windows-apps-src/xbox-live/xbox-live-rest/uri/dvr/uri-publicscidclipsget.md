---
title: GET (/public/scids/{scid}/clips)
assetID: 15b3e873-1f96-b1da-2f79-6dac1369a4c0
permalink: en-us/docs/xboxlive/rest/uri-publicscidclipsget.html
description: " GET (/public/scids/{scid}/clips)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5bce1dd261e0ad1172068a0287519cd0480da85f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589807"
---
# <a name="get-publicscidsscidclips"></a><span data-ttu-id="b2a15-104">GET (/public/scids/{scid}/clips)</span><span class="sxs-lookup"><span data-stu-id="b2a15-104">GET (/public/scids/{scid}/clips)</span></span>
<span data-ttu-id="b2a15-105">パブリックのクリップを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="b2a15-105">List public clips.</span></span> <span data-ttu-id="b2a15-106">この URI のドメインが`gameclipsmetadata.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b2a15-106">The domain for this URI is `gameclipsmetadata.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b2a15-107">注釈</span><span class="sxs-lookup"><span data-stu-id="b2a15-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="b2a15-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2a15-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="b2a15-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2a15-109">Query string parameters</span></span>](#ID4ENB)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="b2a15-110">注釈</span><span class="sxs-lookup"><span data-stu-id="b2a15-110">Remarks</span></span>
 
<span data-ttu-id="b2a15-111">この API は、パブリックであるリスト クリップするさまざまな方法を使用できます。</span><span class="sxs-lookup"><span data-stu-id="b2a15-111">This API allows for various ways to list clips that are public.</span></span> <span data-ttu-id="b2a15-112">クリップの一覧がプライバシーに関する確認と要求元 XUID に対してコンテンツの分離のチェックをベースに返されます。</span><span class="sxs-lookup"><span data-stu-id="b2a15-112">The list of clips is returned based on privacy checks and content isolation checks against the requesting XUID.</span></span>
 
<span data-ttu-id="b2a15-113">クエリは、サービス構成の識別子 (SCID) ごとに最適化されます。</span><span class="sxs-lookup"><span data-stu-id="b2a15-113">Queries are optimized per service configuration identifier (SCID).</span></span> <span data-ttu-id="b2a15-114">さらにフィルターまたは以下に示す既定値以外の並べ替え順序を指定するいくつかの状況で長い時間がかかるを返します。</span><span class="sxs-lookup"><span data-stu-id="b2a15-114">Specifying further filters or sort orders other than the defaults listed below can in some circumstances take longer to return.</span></span> <span data-ttu-id="b2a15-115">ビデオのより大きなセットをより明らかになります。</span><span class="sxs-lookup"><span data-stu-id="b2a15-115">This is more evident for larger sets of videos.</span></span> <span data-ttu-id="b2a15-116">クエリでは、昇順の並べ替え順序を指定できません。</span><span class="sxs-lookup"><span data-stu-id="b2a15-116">Queries cannot specify an ascending sort order.</span></span>
 
<span data-ttu-id="b2a15-117">公開のクリップを特定のコレクションを取得するには、修飾子が必要です。</span><span class="sxs-lookup"><span data-stu-id="b2a15-117">The qualifier is required to get to the specific collection ofpublic clips.</span></span> <span data-ttu-id="b2a15-118">要求元のユーザーは、要求された SCID にアクセスする必要があります、それ以外の場合 HTTP 403 が返されます。</span><span class="sxs-lookup"><span data-stu-id="b2a15-118">The requesting user must have access to the requested SCID, otherwise HTTP 403 will be returned.</span></span>
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b2a15-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2a15-119">URI parameters</span></span>
 
| <span data-ttu-id="b2a15-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2a15-120">Parameter</span></span>| <span data-ttu-id="b2a15-121">種類</span><span class="sxs-lookup"><span data-stu-id="b2a15-121">Type</span></span>| <span data-ttu-id="b2a15-122">説明</span><span class="sxs-lookup"><span data-stu-id="b2a15-122">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b2a15-123">scid</span><span class="sxs-lookup"><span data-stu-id="b2a15-123">scid</span></span>| <span data-ttu-id="b2a15-124">string</span><span class="sxs-lookup"><span data-stu-id="b2a15-124">string</span></span>| <span data-ttu-id="b2a15-125">パブリックのクリップをプライマリ サービスの構成の識別子です。</span><span class="sxs-lookup"><span data-stu-id="b2a15-125">The primary service configuration identifier of the public clips.</span></span>| 
| <span data-ttu-id="b2a15-126">タイトル id</span><span class="sxs-lookup"><span data-stu-id="b2a15-126">titleid</span></span>| <span data-ttu-id="b2a15-127">string</span><span class="sxs-lookup"><span data-stu-id="b2a15-127">string</span></span>| <span data-ttu-id="b2a15-128">パブリックのクリップのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="b2a15-128">The titleId of the public clips.</span></span> <span data-ttu-id="b2a15-129">同じ URI、SCID としてでは指定できません。</span><span class="sxs-lookup"><span data-stu-id="b2a15-129">Cannot be specified in the same URI as the SCID.</span></span> <span data-ttu-id="b2a15-130">指定した場合は、プライマリ SCID 検索に使用されます。</span><span class="sxs-lookup"><span data-stu-id="b2a15-130">If specified, will be used to look up the primary SCID.</span></span>| 
  
<a id="ID4ENB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="b2a15-131">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2a15-131">Query string parameters</span></span>
 
| <span data-ttu-id="b2a15-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b2a15-132">Parameter</span></span>| <span data-ttu-id="b2a15-133">種類</span><span class="sxs-lookup"><span data-stu-id="b2a15-133">Type</span></span>| <span data-ttu-id="b2a15-134">説明</span><span class="sxs-lookup"><span data-stu-id="b2a15-134">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="b2a15-135"><b>?achievementId={achievementId}</b></span><span class="sxs-lookup"><span data-stu-id="b2a15-135"><b>?achievementId={achievementId}</b></span></span>| <span data-ttu-id="b2a15-136">指定された一致する最新のクリップ<b>achievementId</b>します。</span><span class="sxs-lookup"><span data-stu-id="b2a15-136">Most recent clips matching the specified <b>achievementId</b>.</span></span>| <span data-ttu-id="b2a15-137">追加の並べ替え/フィルターはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="b2a15-137">Additional sorting/filtering is not supported.</span></span>| 
| <span data-ttu-id="b2a15-138"><b>?greatestMomentId={greatestMomentId}</b></span><span class="sxs-lookup"><span data-stu-id="b2a15-138"><b>?greatestMomentId={greatestMomentId}</b></span></span>| <span data-ttu-id="b2a15-139">指定された一致する最新のクリップ<b>greatestMomentId</b>します。</span><span class="sxs-lookup"><span data-stu-id="b2a15-139">Most recent clips matching the specified <b>greatestMomentId</b>.</span></span>| <span data-ttu-id="b2a15-140">追加の並べ替え/フィルターはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="b2a15-140">Additional sorting/filtering is not supported.</span></span>| 
| <span data-ttu-id="b2a15-141"><b>?qualifier=created </b></span><span class="sxs-lookup"><span data-stu-id="b2a15-141"><b>?qualifier=created </b></span></span>| <span data-ttu-id="b2a15-142">最新</span><span class="sxs-lookup"><span data-stu-id="b2a15-142">Most Recent</span></span>| <span data-ttu-id="b2a15-143">必須。</span><span class="sxs-lookup"><span data-stu-id="b2a15-143">Required.</span></span>| 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a><span data-ttu-id="b2a15-144">関連項目</span><span class="sxs-lookup"><span data-stu-id="b2a15-144">See also</span></span>
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a><span data-ttu-id="b2a15-145">Parent</span><span class="sxs-lookup"><span data-stu-id="b2a15-145">Parent</span></span> 

[<span data-ttu-id="b2a15-146">/public/scids/{scid}/clips</span><span class="sxs-lookup"><span data-stu-id="b2a15-146">/public/scids/{scid}/clips</span></span>](uri-publicscidclips.md)

   