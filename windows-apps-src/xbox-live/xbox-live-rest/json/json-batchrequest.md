---
title: BatchRequest (JSON)
assetID: 2ca34506-8801-efc5-7c83-3c9ec5572276
permalink: en-us/docs/xboxlive/rest/json-batchrequest.html
author: KevinAsgari
description: " BatchRequest (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 29effaaa7fe70a2b3ae19e9e30d8a852d954c9a9
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5750992"
---
# <a name="batchrequest-json"></a><span data-ttu-id="c52d9-104">BatchRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="c52d9-104">BatchRequest (JSON)</span></span>
<span data-ttu-id="c52d9-105">ユーザー、デバイス、およびタイトルなどのプレゼンス情報をフィルター処理するためのプロパティの配列です。</span><span class="sxs-lookup"><span data-stu-id="c52d9-105">An array of properties with which to filter presence information, such as users, devices, and titles.</span></span>
<a id="ID4EN"></a>


## <a name="batchrequest"></a><span data-ttu-id="c52d9-106">BatchRequest</span><span class="sxs-lookup"><span data-stu-id="c52d9-106">BatchRequest</span></span>

<span data-ttu-id="c52d9-107">BatchRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="c52d9-107">The BatchRequest object has the following specification.</span></span>

| <span data-ttu-id="c52d9-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="c52d9-108">Member</span></span>| <span data-ttu-id="c52d9-109">種類</span><span class="sxs-lookup"><span data-stu-id="c52d9-109">Type</span></span>| <span data-ttu-id="c52d9-110">説明</span><span class="sxs-lookup"><span data-stu-id="c52d9-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="c52d9-111">ユーザー</span><span class="sxs-lookup"><span data-stu-id="c52d9-111">users</span></span>| <span data-ttu-id="c52d9-112">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="c52d9-112">array of string</span></span>| <span data-ttu-id="c52d9-113">については、一度に 1100 Xuid、最大プレゼンスがユーザーの Xuid をリストします。</span><span class="sxs-lookup"><span data-stu-id="c52d9-113">List XUIDs of users whose presence you want to learn, with a maximum of 1100 XUIDs at a time.</span></span>|
| <span data-ttu-id="c52d9-114">deviceTypes</span><span class="sxs-lookup"><span data-stu-id="c52d9-114">deviceTypes</span></span>| <span data-ttu-id="c52d9-115">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="c52d9-115">array of string</span></span>| <span data-ttu-id="c52d9-116">について知りたいユーザーに使用されるデバイスの種類の一覧です。</span><span class="sxs-lookup"><span data-stu-id="c52d9-116">List of device types used by the users you want to know about.</span></span> <span data-ttu-id="c52d9-117">空の配列の場合、既定値はすべての可能なデバイスの種類 (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="c52d9-117">If the array is left empty, it defaults to all possible device types (that is, none are filtered out).</span></span>|
| <span data-ttu-id="c52d9-118">タイトル</span><span class="sxs-lookup"><span data-stu-id="c52d9-118">titles</span></span>| <span data-ttu-id="c52d9-119">32 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="c52d9-119">array of 32-bit unsigned integer</span></span>| <span data-ttu-id="c52d9-120">デバイスの一覧について理解していることをユーザーを種類します。</span><span class="sxs-lookup"><span data-stu-id="c52d9-120">List of device types whose users you want to know about.</span></span> <span data-ttu-id="c52d9-121">空の配列の場合、既定値はすべての可能なタイトル (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="c52d9-121">If the array is left empty, it defaults to all possible titles (that is, none are filtered out).</span></span>|
| <span data-ttu-id="c52d9-122">level</span><span class="sxs-lookup"><span data-stu-id="c52d9-122">level</span></span>| <span data-ttu-id="c52d9-123">string</span><span class="sxs-lookup"><span data-stu-id="c52d9-123">string</span></span>| <span data-ttu-id="c52d9-124">設定可能な値:</span><span class="sxs-lookup"><span data-stu-id="c52d9-124">Possible values:</span></span> <ul><li><span data-ttu-id="c52d9-125">ユーザーのユーザーのノードを入手します。</span><span class="sxs-lookup"><span data-stu-id="c52d9-125">user - get user nodes</span></span></li><li><span data-ttu-id="c52d9-126">デバイスの get ユーザーとデバイス ノード</span><span class="sxs-lookup"><span data-stu-id="c52d9-126">device - get user and device nodes</span></span></li><li><span data-ttu-id="c52d9-127">タイトルのタイトルの基本的なレベルの情報の取得</span><span class="sxs-lookup"><span data-stu-id="c52d9-127">title - get basic title level information</span></span></li><li><span data-ttu-id="c52d9-128">すべてのリッチ プレゼンス情報、メディア情報、またはその両方を取得します。</span><span class="sxs-lookup"><span data-stu-id="c52d9-128">all - get rich presence information, media information, or both</span></span></li></ul><span data-ttu-id="c52d9-129">既定値は、「タイトル」です。</span><span class="sxs-lookup"><span data-stu-id="c52d9-129">The default is "title".</span></span>| 
| <span data-ttu-id="c52d9-130">ガジェットの onlineOnly</span><span class="sxs-lookup"><span data-stu-id="c52d9-130">onlineOnly</span></span>| <span data-ttu-id="c52d9-131">ブール値</span><span class="sxs-lookup"><span data-stu-id="c52d9-131">Boolean value</span></span>| <span data-ttu-id="c52d9-132">このプロパティが true の場合、バッチ操作はフィルターで除外オフライン ユーザーが (回答が決まるものを含む) のレコード。</span><span class="sxs-lookup"><span data-stu-id="c52d9-132">If this property is true, the batch operation will filter out records for offline users (including cloaked ones).</span></span> <span data-ttu-id="c52d9-133">指定されていない場合は、オンラインとオフライン両方のユーザーが返されます。</span><span class="sxs-lookup"><span data-stu-id="c52d9-133">If it is not supplied, both online and offline users will be returned.</span></span>|

<a id="ID4EAD"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="c52d9-134">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="c52d9-134">Sample JSON syntax</span></span>


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


## <a name="see-also"></a><span data-ttu-id="c52d9-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="c52d9-135">See also</span></span>

<a id="ID4ELD"></a>


##### <a name="parent"></a><span data-ttu-id="c52d9-136">Parent</span><span class="sxs-lookup"><span data-stu-id="c52d9-136">Parent</span></span>

[<span data-ttu-id="c52d9-137">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="c52d9-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a><span data-ttu-id="c52d9-138">リファレンス</span><span class="sxs-lookup"><span data-stu-id="c52d9-138">Reference</span></span>   
