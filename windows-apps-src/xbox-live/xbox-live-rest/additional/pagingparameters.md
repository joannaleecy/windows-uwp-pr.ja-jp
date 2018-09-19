---
title: ページング パラメーター
assetID: f8d059fd-30e7-be60-0a46-c9a833c400c6
permalink: en-us/docs/xboxlive/rest/pagingparameters.html
author: KevinAsgari
description: " ページング パラメーター"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e1ed654e4dc1c0f1233ecdedf5d4af66da868bff
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4051473"
---
# <a name="paging-parameters"></a><span data-ttu-id="0e416-104">ページング パラメーター</span><span class="sxs-lookup"><span data-stu-id="0e416-104">Paging Parameters</span></span>
 
<span data-ttu-id="0e416-105">一部の Xbox Live サービス Uri では、JavaScript Object Notation (JSON) オブジェクトのコレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="0e416-105">Some Xbox Live Services URIs return collections of JavaScript Object Notation (JSON) objects.</span></span> <span data-ttu-id="0e416-106">これらのコレクションは、URI に接続されているクエリ文字列の一部としてページングのパラメーターを指定することによって、を通じてページングことができます。</span><span class="sxs-lookup"><span data-stu-id="0e416-106">These collections can be paged through by specifying paging parameters as part of the query string attached to the URI.</span></span> <span data-ttu-id="0e416-107">ページング パラメーターの完全な一覧に従います。</span><span class="sxs-lookup"><span data-stu-id="0e416-107">A complete list of the paging parameters follows.</span></span> <span data-ttu-id="0e416-108">ページングのパラメーターを許可するすべての Uri は、このページの下部にリンクされます。</span><span class="sxs-lookup"><span data-stu-id="0e416-108">All URIs that allow paging parameters are linked to at the bottom of this page.</span></span>
 
<a id="ID4E2"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="0e416-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="0e416-109">Query string parameters</span></span> 
 
| <span data-ttu-id="0e416-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0e416-110">Parameter</span></span>| <span data-ttu-id="0e416-111">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="0e416-111">Required</span></span>| <span data-ttu-id="0e416-112">種類</span><span class="sxs-lookup"><span data-stu-id="0e416-112">Type</span></span>| <span data-ttu-id="0e416-113">説明</span><span class="sxs-lookup"><span data-stu-id="0e416-113">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="0e416-114">continuationToken</span><span class="sxs-lookup"><span data-stu-id="0e416-114">continuationToken</span></span>| <span data-ttu-id="0e416-115">いいえ</span><span class="sxs-lookup"><span data-stu-id="0e416-115">No</span></span>| <span data-ttu-id="0e416-116">string</span><span class="sxs-lookup"><span data-stu-id="0e416-116">string</span></span>| <span data-ttu-id="0e416-117">特定の継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="0e416-117">Return the items starting at the given continuation token.</span></span> | 
| <span data-ttu-id="0e416-118">maxItems</span><span class="sxs-lookup"><span data-stu-id="0e416-118">maxItems</span></span>| <span data-ttu-id="0e416-119">いいえ</span><span class="sxs-lookup"><span data-stu-id="0e416-119">No</span></span>| <span data-ttu-id="0e416-120">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0e416-120">32-bit signed integer</span></span>| <span data-ttu-id="0e416-121"><b>SkipItems</b>と項目の範囲を返す<b>continuationToken</b>と組み合わせることができるコレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="0e416-121">Maximum number of items to return from the collection, which can be combined with <b>skipItems</b> and <b>continuationToken</b> to return a range of items.</span></span> <span data-ttu-id="0e416-122">サービスに結果の最後のページが返されていない場合でもは<b>maxItems</b>が存在しないと、 <b>maxItems</b>より少ないを返す可能性がある場合、既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0e416-122">The service may provide a default value if <b>maxItems</b> is not present, and may return fewer than <b>maxItems</b>, even if the last page of results has not yet been returned.</span></span> | 
| <span data-ttu-id="0e416-123">skipItems</span><span class="sxs-lookup"><span data-stu-id="0e416-123">skipItems</span></span>| <span data-ttu-id="0e416-124">いいえ</span><span class="sxs-lookup"><span data-stu-id="0e416-124">No</span></span>| <span data-ttu-id="0e416-125">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0e416-125">32-bit signed integer</span></span>| <span data-ttu-id="0e416-126">特定の項目数後以降の項目を返します。</span><span class="sxs-lookup"><span data-stu-id="0e416-126">Return items beginning after the given number of items.</span></span> <span data-ttu-id="0e416-127">たとえば、 <b>skipItems =「3」</b>項目を取得以降では、4 番目の項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="0e416-127">For example, <b>skipItems="3"</b> will retrieve items beginning with the fourth item retrieved.</span></span> | 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a><span data-ttu-id="0e416-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="0e416-128">See also</span></span>
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a><span data-ttu-id="0e416-129">Parent</span><span class="sxs-lookup"><span data-stu-id="0e416-129">Parent</span></span>  

[<span data-ttu-id="0e416-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="0e416-130">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference--get-usersxuidxuidachievementsuriachievementsuri-achievementsusersxuidachievementsgetv2md"></a><span data-ttu-id="0e416-131">参照[を取得する (/users/xuid({xuid})/achievements)](../uri/achievements/uri-achievementsusersxuidachievementsgetv2.md)</span><span class="sxs-lookup"><span data-stu-id="0e416-131">Reference  [GET (/users/xuid({xuid})/achievements)](../uri/achievements/uri-achievementsusersxuidachievementsgetv2.md)</span></span>

   