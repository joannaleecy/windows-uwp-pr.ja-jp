---
title: ページング パラメーター
assetID: f8d059fd-30e7-be60-0a46-c9a833c400c6
permalink: en-us/docs/xboxlive/rest/pagingparameters.html
description: " ページング パラメーター"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fe80e1666f9eab8caf7e0bbdb2b537bd7661c9a9
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8893914"
---
# <a name="paging-parameters"></a><span data-ttu-id="9bee3-104">ページング パラメーター</span><span class="sxs-lookup"><span data-stu-id="9bee3-104">Paging Parameters</span></span>
 
<span data-ttu-id="9bee3-105">一部の Xbox Live サービス Uri では、JavaScript Object Notation (JSON) オブジェクトのコレクションを返します。</span><span class="sxs-lookup"><span data-stu-id="9bee3-105">Some Xbox Live Services URIs return collections of JavaScript Object Notation (JSON) objects.</span></span> <span data-ttu-id="9bee3-106">これらのコレクションは、URI に接続されているクエリ文字列の一部としてページング パラメーターを指定することによって、を通じてページことができます。</span><span class="sxs-lookup"><span data-stu-id="9bee3-106">These collections can be paged through by specifying paging parameters as part of the query string attached to the URI.</span></span> <span data-ttu-id="9bee3-107">ページング パラメーターの完全な一覧に依存します。</span><span class="sxs-lookup"><span data-stu-id="9bee3-107">A complete list of the paging parameters follows.</span></span> <span data-ttu-id="9bee3-108">ページング パラメーターを許可するすべての Uri は、このページの下部にリンクされます。</span><span class="sxs-lookup"><span data-stu-id="9bee3-108">All URIs that allow paging parameters are linked to at the bottom of this page.</span></span>
 
<a id="ID4E2"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="9bee3-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="9bee3-109">Query string parameters</span></span> 
 
| <span data-ttu-id="9bee3-110">パラメーター</span><span class="sxs-lookup"><span data-stu-id="9bee3-110">Parameter</span></span>| <span data-ttu-id="9bee3-111">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="9bee3-111">Required</span></span>| <span data-ttu-id="9bee3-112">種類</span><span class="sxs-lookup"><span data-stu-id="9bee3-112">Type</span></span>| <span data-ttu-id="9bee3-113">説明</span><span class="sxs-lookup"><span data-stu-id="9bee3-113">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="9bee3-114">continuationToken</span><span class="sxs-lookup"><span data-stu-id="9bee3-114">continuationToken</span></span>| <span data-ttu-id="9bee3-115">いいえ</span><span class="sxs-lookup"><span data-stu-id="9bee3-115">No</span></span>| <span data-ttu-id="9bee3-116">string</span><span class="sxs-lookup"><span data-stu-id="9bee3-116">string</span></span>| <span data-ttu-id="9bee3-117">特定の継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="9bee3-117">Return the items starting at the given continuation token.</span></span> | 
| <span data-ttu-id="9bee3-118">maxItems</span><span class="sxs-lookup"><span data-stu-id="9bee3-118">maxItems</span></span>| <span data-ttu-id="9bee3-119">いいえ</span><span class="sxs-lookup"><span data-stu-id="9bee3-119">No</span></span>| <span data-ttu-id="9bee3-120">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="9bee3-120">32-bit signed integer</span></span>| <span data-ttu-id="9bee3-121">組み合わせた<b>skipItems</b>と<b>continuationToken</b>項目の範囲を返すことができるコレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="9bee3-121">Maximum number of items to return from the collection, which can be combined with <b>skipItems</b> and <b>continuationToken</b> to return a range of items.</span></span> <span data-ttu-id="9bee3-122">サービスに結果の最後のページが返されていない場合でもは<b>maxItems</b>が存在しないと、 <b>maxItems</b>より少ないを返す可能性がある場合、既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9bee3-122">The service may provide a default value if <b>maxItems</b> is not present, and may return fewer than <b>maxItems</b>, even if the last page of results has not yet been returned.</span></span> | 
| <span data-ttu-id="9bee3-123">skipItems</span><span class="sxs-lookup"><span data-stu-id="9bee3-123">skipItems</span></span>| <span data-ttu-id="9bee3-124">いいえ</span><span class="sxs-lookup"><span data-stu-id="9bee3-124">No</span></span>| <span data-ttu-id="9bee3-125">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="9bee3-125">32-bit signed integer</span></span>| <span data-ttu-id="9bee3-126">特定の項目数後以降の項目を返します。</span><span class="sxs-lookup"><span data-stu-id="9bee3-126">Return items beginning after the given number of items.</span></span> <span data-ttu-id="9bee3-127">たとえば、 <b>skipItems =「3」</b>項目を取得以降では、4 番目の項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="9bee3-127">For example, <b>skipItems="3"</b> will retrieve items beginning with the fourth item retrieved.</span></span> | 
  
<a id="ID4EDD"></a>

 
## <a name="see-also"></a><span data-ttu-id="9bee3-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="9bee3-128">See also</span></span>
 
<a id="ID4EFD"></a>

 
##### <a name="parent"></a><span data-ttu-id="9bee3-129">Parent</span><span class="sxs-lookup"><span data-stu-id="9bee3-129">Parent</span></span>  

[<span data-ttu-id="9bee3-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="9bee3-130">Additional Reference</span></span>](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference--get-usersxuidxuidachievementsuriachievementsuri-achievementsusersxuidachievementsgetv2md"></a><span data-ttu-id="9bee3-131">参照[を取得する (/users/xuid({xuid})/achievements)](../uri/achievements/uri-achievementsusersxuidachievementsgetv2.md)</span><span class="sxs-lookup"><span data-stu-id="9bee3-131">Reference  [GET (/users/xuid({xuid})/achievements)](../uri/achievements/uri-achievementsusersxuidachievementsgetv2.md)</span></span>

   