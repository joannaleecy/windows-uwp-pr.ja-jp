---
title: /users/xuid(xuid)/lists/PINS/{listname}
assetID: b6421b11-fcd1-cfdb-c1fa-6cab3dab89d9
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistname.html
description: " /users/xuid(xuid)/lists/PINS/{listname}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0f9610b400e9530f86e264cea30bfdfdd1b09c8d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627997"
---
# <a name="usersxuidxuidlistspinslistname"></a><span data-ttu-id="d6180-104">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="d6180-104">/users/xuid(xuid)/lists/PINS/{listname}</span></span>
<span data-ttu-id="d6180-105">リスト内の項目にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d6180-105">Accesses items in a list.</span></span> <span data-ttu-id="d6180-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d6180-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d6180-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d6180-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d6180-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d6180-108">URI parameters</span></span>
 
| <span data-ttu-id="d6180-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d6180-109">Parameter</span></span>| <span data-ttu-id="d6180-110">種類</span><span class="sxs-lookup"><span data-stu-id="d6180-110">Type</span></span>| <span data-ttu-id="d6180-111">説明</span><span class="sxs-lookup"><span data-stu-id="d6180-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d6180-112">xuid</span><span class="sxs-lookup"><span data-stu-id="d6180-112">xuid</span></span>| <span data-ttu-id="d6180-113">string</span><span class="sxs-lookup"><span data-stu-id="d6180-113">string</span></span>| <span data-ttu-id="d6180-114">Xbox のユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="d6180-114">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="d6180-115">listtype</span><span class="sxs-lookup"><span data-stu-id="d6180-115">listtype</span></span>| <span data-ttu-id="d6180-116">string</span><span class="sxs-lookup"><span data-stu-id="d6180-116">string</span></span>| <span data-ttu-id="d6180-117">(その使用方法およびどのように機能します) のリストの種類。</span><span class="sxs-lookup"><span data-stu-id="d6180-117">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="d6180-118">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="d6180-118">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="d6180-119">listname</span><span class="sxs-lookup"><span data-stu-id="d6180-119">listname</span></span>| <span data-ttu-id="d6180-120">string</span><span class="sxs-lookup"><span data-stu-id="d6180-120">string</span></span>| <span data-ttu-id="d6180-121">リストの名前 (を操作する特定の listtype のどのリスト)。</span><span class="sxs-lookup"><span data-stu-id="d6180-121">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="d6180-122">常に"XBLPins"の項目のピンです。</span><span class="sxs-lookup"><span data-stu-id="d6180-122">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4EGC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="d6180-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="d6180-123">Valid methods</span></span>

[<span data-ttu-id="d6180-124">DELETE</span><span class="sxs-lookup"><span data-stu-id="d6180-124">DELETE</span></span>](uri-usersxuidlistspinslistnamedelete.md)

<span data-ttu-id="d6180-125">&nbsp;&nbsp;一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="d6180-125">&nbsp;&nbsp;Removes items from a list.</span></span>

[<span data-ttu-id="d6180-126">取得</span><span class="sxs-lookup"><span data-stu-id="d6180-126">GET</span></span>](uri-usersxuidlistspinslistnameget.md)

<span data-ttu-id="d6180-127">&nbsp;&nbsp;一覧の内容を返します。</span><span class="sxs-lookup"><span data-stu-id="d6180-127">&nbsp;&nbsp;Returns the contents of a list.</span></span>

[<span data-ttu-id="d6180-128">投稿</span><span class="sxs-lookup"><span data-stu-id="d6180-128">POST</span></span>](uri-usersxuidlistspinslistnamepost.md)

<span data-ttu-id="d6180-129">&nbsp;&nbsp;クエリ文字列パラメーターに基づいてインデックス位置にある一覧に項目を挿入**insertIndex**します。</span><span class="sxs-lookup"><span data-stu-id="d6180-129">&nbsp;&nbsp;Inserts items into the list at the index based on the query string parameter **insertIndex**.</span></span>

[<span data-ttu-id="d6180-130">PUT</span><span class="sxs-lookup"><span data-stu-id="d6180-130">PUT</span></span>](uri-usersxuidlistspinslistnameput.md)

<span data-ttu-id="d6180-131">&nbsp;&nbsp;要求本文内の各項目に指定されたインデックスによってリスト内の項目を更新します。</span><span class="sxs-lookup"><span data-stu-id="d6180-131">&nbsp;&nbsp;Updates the items in a list according to the indexes specified for each item in the request body.</span></span>
 
<a id="ID4EZC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d6180-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="d6180-132">See also</span></span>
 
<a id="ID4E2C"></a>

 
##### <a name="parent"></a><span data-ttu-id="d6180-133">Parent</span><span class="sxs-lookup"><span data-stu-id="d6180-133">Parent</span></span> 

[<span data-ttu-id="d6180-134">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="d6180-134">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   