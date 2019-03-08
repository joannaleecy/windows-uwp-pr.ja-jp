---
title: PagingInfo (JSON)
assetID: 645e575d-3e8e-d954-90e6-e51dd83da93b
permalink: en-us/docs/xboxlive/rest/json-paginginfo.html
description: " PagingInfo (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0e773d73499e79fe23f736a536027932ca1a07b4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651217"
---
# <a name="paginginfo-json"></a><span data-ttu-id="38a1e-104">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="38a1e-104">PagingInfo (JSON)</span></span>
<span data-ttu-id="38a1e-105">ページのデータで返される結果のページング情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="38a1e-105">Contains paging information for results that are returned in pages of data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="paginginfo"></a><span data-ttu-id="38a1e-106">PagingInfo</span><span class="sxs-lookup"><span data-stu-id="38a1e-106">PagingInfo</span></span>
 
| <span data-ttu-id="38a1e-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="38a1e-107">Member</span></span>| <span data-ttu-id="38a1e-108">種類</span><span class="sxs-lookup"><span data-stu-id="38a1e-108">Type</span></span>| <span data-ttu-id="38a1e-109">説明</span><span class="sxs-lookup"><span data-stu-id="38a1e-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="38a1e-110">continuationToken</span><span class="sxs-lookup"><span data-stu-id="38a1e-110">continuationToken</span></span>| <span data-ttu-id="38a1e-111">string</span><span class="sxs-lookup"><span data-stu-id="38a1e-111">string</span></span>| <span data-ttu-id="38a1e-112">結果の次のページにアクセスするために使用する非透過的継続トークンです。</span><span class="sxs-lookup"><span data-stu-id="38a1e-112">An opaque continuation token used to access the next page of results.</span></span> <span data-ttu-id="38a1e-113">最大 32 文字です。呼び出し元がこの値を指定できます、 <b>continuationToken</b>次の一連のコレクション内の項目を取得するためにクエリ パラメーター。</span><span class="sxs-lookup"><span data-stu-id="38a1e-113">Maximum 32 characters.Callers can supply this value in the <b>continuationToken</b> query parameter in order to retrieve the next set of items in the collection.</span></span> <span data-ttu-id="38a1e-114">このプロパティが場合<b>null</b>をコレクションに追加の項目はありません。</span><span class="sxs-lookup"><span data-stu-id="38a1e-114">If this property is <b>null</b>, then there are no additional items in the collection.</span></span> <span data-ttu-id="38a1e-115">このプロパティは必須でありが提供されると、コレクションはページングされている場合でも<b>skipItems</b>します。</span><span class="sxs-lookup"><span data-stu-id="38a1e-115">This property is required and is provided even if the collection is being paged with <b>skipItems</b>.</span></span>| 
| <span data-ttu-id="38a1e-116">totalItems</span><span class="sxs-lookup"><span data-stu-id="38a1e-116">totalItems</span></span>| <span data-ttu-id="38a1e-117">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="38a1e-117">32-bit signed integer</span></span>| <span data-ttu-id="38a1e-118">コレクション内の項目の合計数。</span><span class="sxs-lookup"><span data-stu-id="38a1e-118">The total number of items in the collection.</span></span> <span data-ttu-id="38a1e-119">これは、サービスは、コレクションのサイズにリアルタイム ビューを提供することがない場合、このレベルは提供されません。</span><span class="sxs-lookup"><span data-stu-id="38a1e-119">This is not provided if the service is unable to provide a real-time view into the size of the collection.</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="38a1e-120">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="38a1e-120">Sample JSON syntax</span></span>
 

```json
{
   "continuationToken":"16354135464161213-0708c1ba-147f-48cc-9ad9-546gaadg648"
   "totalItems":5,
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="38a1e-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="38a1e-121">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="38a1e-122">Parent</span><span class="sxs-lookup"><span data-stu-id="38a1e-122">Parent</span></span> 

[<span data-ttu-id="38a1e-123">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="38a1e-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   