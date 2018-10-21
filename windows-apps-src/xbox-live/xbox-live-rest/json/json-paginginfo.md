---
title: PagingInfo (JSON)
assetID: 645e575d-3e8e-d954-90e6-e51dd83da93b
permalink: en-us/docs/xboxlive/rest/json-paginginfo.html
author: KevinAsgari
description: " PagingInfo (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 933169945c865fc6bc6f7b8b7ba7872fff98d1b8
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5159785"
---
# <a name="paginginfo-json"></a><span data-ttu-id="fd320-104">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="fd320-104">PagingInfo (JSON)</span></span>
<span data-ttu-id="fd320-105">データのページで返される結果のページング情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="fd320-105">Contains paging information for results that are returned in pages of data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="paginginfo"></a><span data-ttu-id="fd320-106">PagingInfo</span><span class="sxs-lookup"><span data-stu-id="fd320-106">PagingInfo</span></span>
 
| <span data-ttu-id="fd320-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="fd320-107">Member</span></span>| <span data-ttu-id="fd320-108">種類</span><span class="sxs-lookup"><span data-stu-id="fd320-108">Type</span></span>| <span data-ttu-id="fd320-109">説明</span><span class="sxs-lookup"><span data-stu-id="fd320-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="fd320-110">continuationToken</span><span class="sxs-lookup"><span data-stu-id="fd320-110">continuationToken</span></span>| <span data-ttu-id="fd320-111">string</span><span class="sxs-lookup"><span data-stu-id="fd320-111">string</span></span>| <span data-ttu-id="fd320-112">不透明な継続トークン結果の次のページにアクセスするために使用します。</span><span class="sxs-lookup"><span data-stu-id="fd320-112">An opaque continuation token used to access the next page of results.</span></span> <span data-ttu-id="fd320-113">最大 32 文字以下です。呼び出し元では、次のコレクション内の項目のセットを取得するために、 <b>continuationToken</b>クエリ パラメーターでは、この値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="fd320-113">Maximum 32 characters.Callers can supply this value in the <b>continuationToken</b> query parameter in order to retrieve the next set of items in the collection.</span></span> <span data-ttu-id="fd320-114">このプロパティが<b>null</b>の場合、項目がない追加コレクションでします。</span><span class="sxs-lookup"><span data-stu-id="fd320-114">If this property is <b>null</b>, then there are no additional items in the collection.</span></span> <span data-ttu-id="fd320-115">このプロパティは、必要な場合でも、 <b>skipItems</b>でページングされるコレクションが提供されます。</span><span class="sxs-lookup"><span data-stu-id="fd320-115">This property is required and is provided even if the collection is being paged with <b>skipItems</b>.</span></span>| 
| <span data-ttu-id="fd320-116">totalItems</span><span class="sxs-lookup"><span data-stu-id="fd320-116">totalItems</span></span>| <span data-ttu-id="fd320-117">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="fd320-117">32-bit signed integer</span></span>| <span data-ttu-id="fd320-118">コレクション内の項目の合計数。</span><span class="sxs-lookup"><span data-stu-id="fd320-118">The total number of items in the collection.</span></span> <span data-ttu-id="fd320-119">これが指定されていない場合は、サービスは、コレクションのサイズにリアルタイムで表示を提供することはできません。</span><span class="sxs-lookup"><span data-stu-id="fd320-119">This is not provided if the service is unable to provide a real-time view into the size of the collection.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="fd320-120">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="fd320-120">Sample JSON syntax</span></span>
 

```json
{
   "continuationToken":"16354135464161213-0708c1ba-147f-48cc-9ad9-546gaadg648"
   "totalItems":5,
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="fd320-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="fd320-121">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="fd320-122">Parent</span><span class="sxs-lookup"><span data-stu-id="fd320-122">Parent</span></span> 

[<span data-ttu-id="fd320-123">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="fd320-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   