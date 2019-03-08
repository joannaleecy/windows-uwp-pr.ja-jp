---
title: BatchRequest (JSON)
assetID: 2ca34506-8801-efc5-7c83-3c9ec5572276
permalink: en-us/docs/xboxlive/rest/json-batchrequest.html
description: " BatchRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 51073c71700613edcd7c22e18cc0c00a9222d7e5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654157"
---
# <a name="batchrequest-json"></a><span data-ttu-id="9c0ae-104">BatchRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="9c0ae-104">BatchRequest (JSON)</span></span>
<span data-ttu-id="9c0ae-105">ユーザー、デバイス、およびタイトルなどのプレゼンス情報をフィルター処理に使用するプロパティの配列。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-105">An array of properties with which to filter presence information, such as users, devices, and titles.</span></span>
<a id="ID4EN"></a>


## <a name="batchrequest"></a><span data-ttu-id="9c0ae-106">BatchRequest</span><span class="sxs-lookup"><span data-stu-id="9c0ae-106">BatchRequest</span></span>

<span data-ttu-id="9c0ae-107">BatchRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-107">The BatchRequest object has the following specification.</span></span>

| <span data-ttu-id="9c0ae-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="9c0ae-108">Member</span></span>| <span data-ttu-id="9c0ae-109">種類</span><span class="sxs-lookup"><span data-stu-id="9c0ae-109">Type</span></span>| <span data-ttu-id="9c0ae-110">説明</span><span class="sxs-lookup"><span data-stu-id="9c0ae-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="9c0ae-111">ユーザー</span><span class="sxs-lookup"><span data-stu-id="9c0ae-111">users</span></span>| <span data-ttu-id="9c0ae-112">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="9c0ae-112">array of string</span></span>| <span data-ttu-id="9c0ae-113">ユーザーについては、1100 Xuid、一度に最大でプレゼンスが Xuid をリストします。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-113">List XUIDs of users whose presence you want to learn, with a maximum of 1100 XUIDs at a time.</span></span>|
| <span data-ttu-id="9c0ae-114">deviceTypes</span><span class="sxs-lookup"><span data-stu-id="9c0ae-114">deviceTypes</span></span>| <span data-ttu-id="9c0ae-115">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="9c0ae-115">array of string</span></span>| <span data-ttu-id="9c0ae-116">について知りたいユーザーによって使用されるデバイスの種類の一覧です。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-116">List of device types used by the users you want to know about.</span></span> <span data-ttu-id="9c0ae-117">配列が空のまま場合、すべての可能なデバイスの種類に既定値 (つまり、none、フィルターで除外)。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-117">If the array is left empty, it defaults to all possible device types (that is, none are filtered out).</span></span>|
| <span data-ttu-id="9c0ae-118">タイトル</span><span class="sxs-lookup"><span data-stu-id="9c0ae-118">titles</span></span>| <span data-ttu-id="9c0ae-119">32 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="9c0ae-119">array of 32-bit unsigned integer</span></span>| <span data-ttu-id="9c0ae-120">デバイスの一覧について知りたいユーザーを種類します。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-120">List of device types whose users you want to know about.</span></span> <span data-ttu-id="9c0ae-121">配列が空のまま場合、すべての可能なタイトルを既定値 (つまり、none、フィルターで除外)。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-121">If the array is left empty, it defaults to all possible titles (that is, none are filtered out).</span></span>|
| <span data-ttu-id="9c0ae-122">level</span><span class="sxs-lookup"><span data-stu-id="9c0ae-122">level</span></span>| <span data-ttu-id="9c0ae-123">string</span><span class="sxs-lookup"><span data-stu-id="9c0ae-123">string</span></span>| <span data-ttu-id="9c0ae-124">設定可能な値:</span><span class="sxs-lookup"><span data-stu-id="9c0ae-124">Possible values:</span></span> <ul><li><span data-ttu-id="9c0ae-125">ユーザー - ユーザー ノードの取得</span><span class="sxs-lookup"><span data-stu-id="9c0ae-125">user - get user nodes</span></span></li><li><span data-ttu-id="9c0ae-126">デバイスのユーザーを取得し、デバイス ノード</span><span class="sxs-lookup"><span data-stu-id="9c0ae-126">device - get user and device nodes</span></span></li><li><span data-ttu-id="9c0ae-127">タイトル-タイトルの基本的なレベルの情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-127">title - get basic title level information</span></span></li><li><span data-ttu-id="9c0ae-128">豊富なプレゼンス情報、メディア情報、またはその両方の取得 - すべて</span><span class="sxs-lookup"><span data-stu-id="9c0ae-128">all - get rich presence information, media information, or both</span></span></li></ul><span data-ttu-id="9c0ae-129">既定では"title です"。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-129">The default is "title".</span></span>| 
| <span data-ttu-id="9c0ae-130">ガジェットの onlineOnly</span><span class="sxs-lookup"><span data-stu-id="9c0ae-130">onlineOnly</span></span>| <span data-ttu-id="9c0ae-131">ブール値</span><span class="sxs-lookup"><span data-stu-id="9c0ae-131">Boolean value</span></span>| <span data-ttu-id="9c0ae-132">このプロパティが true の場合、バッチ操作はユーザーがオフライン (クロークされているものを含む) でレコードが除外されます。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-132">If this property is true, the batch operation will filter out records for offline users (including cloaked ones).</span></span> <span data-ttu-id="9c0ae-133">指定されていない場合は、オンラインとオフラインの両方のユーザーが返されます。</span><span class="sxs-lookup"><span data-stu-id="9c0ae-133">If it is not supplied, both online and offline users will be returned.</span></span>|

<a id="ID4EAD"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="9c0ae-134">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="9c0ae-134">Sample JSON syntax</span></span>


```json
{
  users:
  [
    "1234567890",
    "4567890123",
    "7890123456"
  ]
}


```


<a id="ID4EJD"></a>


## <a name="see-also"></a><span data-ttu-id="9c0ae-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="9c0ae-135">See also</span></span>

<a id="ID4ELD"></a>


##### <a name="parent"></a><span data-ttu-id="9c0ae-136">Parent</span><span class="sxs-lookup"><span data-stu-id="9c0ae-136">Parent</span></span>

[<span data-ttu-id="9c0ae-137">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="9c0ae-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a><span data-ttu-id="9c0ae-138">リファレンス</span><span class="sxs-lookup"><span data-stu-id="9c0ae-138">Reference</span></span>   
