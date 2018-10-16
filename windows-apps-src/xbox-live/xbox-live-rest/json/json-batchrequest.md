---
title: BatchRequest (JSON)
assetID: 2ca34506-8801-efc5-7c83-3c9ec5572276
permalink: en-us/docs/xboxlive/rest/json-batchrequest.html
author: KevinAsgari
description: " BatchRequest (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6271cdf3d94f194adee5087136c1d87ad9f214b5
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4684844"
---
# <a name="batchrequest-json"></a><span data-ttu-id="b0eb0-104">BatchRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="b0eb0-104">BatchRequest (JSON)</span></span>
<span data-ttu-id="b0eb0-105">ユーザー、デバイス、およびタイトルなどのプレゼンス情報をフィルター処理するためのプロパティの配列です。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-105">An array of properties with which to filter presence information, such as users, devices, and titles.</span></span>
<a id="ID4EN"></a>


## <a name="batchrequest"></a><span data-ttu-id="b0eb0-106">BatchRequest</span><span class="sxs-lookup"><span data-stu-id="b0eb0-106">BatchRequest</span></span>

<span data-ttu-id="b0eb0-107">BatchRequest オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-107">The BatchRequest object has the following specification.</span></span>

| <span data-ttu-id="b0eb0-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="b0eb0-108">Member</span></span>| <span data-ttu-id="b0eb0-109">種類</span><span class="sxs-lookup"><span data-stu-id="b0eb0-109">Type</span></span>| <span data-ttu-id="b0eb0-110">説明</span><span class="sxs-lookup"><span data-stu-id="b0eb0-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="b0eb0-111">ユーザー</span><span class="sxs-lookup"><span data-stu-id="b0eb0-111">users</span></span>| <span data-ttu-id="b0eb0-112">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="b0eb0-112">array of string</span></span>| <span data-ttu-id="b0eb0-113">については、一度に 1100 Xuid の最大プレゼンスがユーザーの Xuid をリストします。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-113">List XUIDs of users whose presence you want to learn, with a maximum of 1100 XUIDs at a time.</span></span>|
| <span data-ttu-id="b0eb0-114">deviceTypes</span><span class="sxs-lookup"><span data-stu-id="b0eb0-114">deviceTypes</span></span>| <span data-ttu-id="b0eb0-115">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="b0eb0-115">array of string</span></span>| <span data-ttu-id="b0eb0-116">について知りたいユーザーに使用されるデバイスの種類の一覧です。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-116">List of device types used by the users you want to know about.</span></span> <span data-ttu-id="b0eb0-117">空の配列の場合、既定値はすべての可能なデバイスの種類 (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-117">If the array is left empty, it defaults to all possible device types (that is, none are filtered out).</span></span>|
| <span data-ttu-id="b0eb0-118">タイトル</span><span class="sxs-lookup"><span data-stu-id="b0eb0-118">titles</span></span>| <span data-ttu-id="b0eb0-119">32 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="b0eb0-119">array of 32-bit unsigned integer</span></span>| <span data-ttu-id="b0eb0-120">デバイスの一覧について理解していることをユーザーを種類します。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-120">List of device types whose users you want to know about.</span></span> <span data-ttu-id="b0eb0-121">空の配列の場合、既定値はすべての可能なタイトル (つまり、none が除外されます)。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-121">If the array is left empty, it defaults to all possible titles (that is, none are filtered out).</span></span>|
| <span data-ttu-id="b0eb0-122">level</span><span class="sxs-lookup"><span data-stu-id="b0eb0-122">level</span></span>| <span data-ttu-id="b0eb0-123">string</span><span class="sxs-lookup"><span data-stu-id="b0eb0-123">string</span></span>| <span data-ttu-id="b0eb0-124">設定可能な値:</span><span class="sxs-lookup"><span data-stu-id="b0eb0-124">Possible values:</span></span> <ul><li><span data-ttu-id="b0eb0-125">ユーザーの取得ユーザー ノード</span><span class="sxs-lookup"><span data-stu-id="b0eb0-125">user - get user nodes</span></span></li><li><span data-ttu-id="b0eb0-126">デバイスの get ユーザーとデバイス ノード</span><span class="sxs-lookup"><span data-stu-id="b0eb0-126">device - get user and device nodes</span></span></li><li><span data-ttu-id="b0eb0-127">タイトルのタイトルの基本的なレベルの情報の取得</span><span class="sxs-lookup"><span data-stu-id="b0eb0-127">title - get basic title level information</span></span></li><li><span data-ttu-id="b0eb0-128">リッチ プレゼンス情報やメディアについては、すべてを取得します。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-128">all - get rich presence information, media information, or both</span></span></li></ul><span data-ttu-id="b0eb0-129">既定値は、「タイトル」です。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-129">The default is "title".</span></span>| 
| <span data-ttu-id="b0eb0-130">ガジェットの onlineOnly</span><span class="sxs-lookup"><span data-stu-id="b0eb0-130">onlineOnly</span></span>| <span data-ttu-id="b0eb0-131">ブール値</span><span class="sxs-lookup"><span data-stu-id="b0eb0-131">Boolean value</span></span>| <span data-ttu-id="b0eb0-132">このプロパティが true の場合、バッチ操作はオフラインのユーザーが (回答が決まるものを含む) のレコードをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-132">If this property is true, the batch operation will filter out records for offline users (including cloaked ones).</span></span> <span data-ttu-id="b0eb0-133">指定されていない場合は、オンラインとオフライン両方のユーザーが返されます。</span><span class="sxs-lookup"><span data-stu-id="b0eb0-133">If it is not supplied, both online and offline users will be returned.</span></span>|

<a id="ID4EAD"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="b0eb0-134">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="b0eb0-134">Sample JSON syntax</span></span>


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


## <a name="see-also"></a><span data-ttu-id="b0eb0-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="b0eb0-135">See also</span></span>

<a id="ID4ELD"></a>


##### <a name="parent"></a><span data-ttu-id="b0eb0-136">Parent</span><span class="sxs-lookup"><span data-stu-id="b0eb0-136">Parent</span></span>

[<span data-ttu-id="b0eb0-137">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="b0eb0-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a><span data-ttu-id="b0eb0-138">リファレンス</span><span class="sxs-lookup"><span data-stu-id="b0eb0-138">Reference</span></span>   
