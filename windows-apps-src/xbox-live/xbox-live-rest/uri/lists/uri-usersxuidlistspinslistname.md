---
title: /users/xuid(xuid)/lists/PINS/{listname}
assetID: b6421b11-fcd1-cfdb-c1fa-6cab3dab89d9
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistname.html
author: KevinAsgari
description: " /users/xuid(xuid)/lists/PINS/{listname}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 052a83f47dc2d5b692c811850e41381c4745815c
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4386226"
---
# <a name="usersxuidxuidlistspinslistname"></a><span data-ttu-id="92e48-104">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="92e48-104">/users/xuid(xuid)/lists/PINS/{listname}</span></span>
<span data-ttu-id="92e48-105">リストの項目にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="92e48-105">Accesses items in a list.</span></span> <span data-ttu-id="92e48-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="92e48-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="92e48-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92e48-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="92e48-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92e48-108">URI parameters</span></span>
 
| <span data-ttu-id="92e48-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="92e48-109">Parameter</span></span>| <span data-ttu-id="92e48-110">型</span><span class="sxs-lookup"><span data-stu-id="92e48-110">Type</span></span>| <span data-ttu-id="92e48-111">説明</span><span class="sxs-lookup"><span data-stu-id="92e48-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="92e48-112">xuid</span><span class="sxs-lookup"><span data-stu-id="92e48-112">xuid</span></span>| <span data-ttu-id="92e48-113">string</span><span class="sxs-lookup"><span data-stu-id="92e48-113">string</span></span>| <span data-ttu-id="92e48-114">Xbox ユーザー ID (XUID) です。</span><span class="sxs-lookup"><span data-stu-id="92e48-114">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="92e48-115">listtype</span><span class="sxs-lookup"><span data-stu-id="92e48-115">listtype</span></span>| <span data-ttu-id="92e48-116">string</span><span class="sxs-lookup"><span data-stu-id="92e48-116">string</span></span>| <span data-ttu-id="92e48-117">(使用方法と動作) の一覧の種類です。</span><span class="sxs-lookup"><span data-stu-id="92e48-117">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="92e48-118">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="92e48-118">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="92e48-119">リスト</span><span class="sxs-lookup"><span data-stu-id="92e48-119">listname</span></span>| <span data-ttu-id="92e48-120">string</span><span class="sxs-lookup"><span data-stu-id="92e48-120">string</span></span>| <span data-ttu-id="92e48-121">リストの名前 (際に指定された listtype の一覧がどの)。</span><span class="sxs-lookup"><span data-stu-id="92e48-121">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="92e48-122">常に"XBLPins"の項目のピン留めします。</span><span class="sxs-lookup"><span data-stu-id="92e48-122">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4EGC"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="92e48-123">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="92e48-123">Valid methods</span></span>

[<span data-ttu-id="92e48-124">DELETE</span><span class="sxs-lookup"><span data-stu-id="92e48-124">DELETE</span></span>](uri-usersxuidlistspinslistnamedelete.md)

<span data-ttu-id="92e48-125">&nbsp;&nbsp;一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="92e48-125">&nbsp;&nbsp;Removes items from a list.</span></span>

[<span data-ttu-id="92e48-126">GET</span><span class="sxs-lookup"><span data-stu-id="92e48-126">GET</span></span>](uri-usersxuidlistspinslistnameget.md)

<span data-ttu-id="92e48-127">&nbsp;&nbsp;リストの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="92e48-127">&nbsp;&nbsp;Returns the contents of a list.</span></span>

[<span data-ttu-id="92e48-128">POST</span><span class="sxs-lookup"><span data-stu-id="92e48-128">POST</span></span>](uri-usersxuidlistspinslistnamepost.md)

<span data-ttu-id="92e48-129">&nbsp;&nbsp;クエリ文字列パラメーター **insertIndex**に基づいてインデックスの一覧に項目を挿入します。</span><span class="sxs-lookup"><span data-stu-id="92e48-129">&nbsp;&nbsp;Inserts items into the list at the index based on the query string parameter **insertIndex**.</span></span>

[<span data-ttu-id="92e48-130">PUT</span><span class="sxs-lookup"><span data-stu-id="92e48-130">PUT</span></span>](uri-usersxuidlistspinslistnameput.md)

<span data-ttu-id="92e48-131">&nbsp;&nbsp;要求の本文内の各項目に指定されたインデックスに従ってリスト内の項目を更新します。</span><span class="sxs-lookup"><span data-stu-id="92e48-131">&nbsp;&nbsp;Updates the items in a list according to the indexes specified for each item in the request body.</span></span>
 
<a id="ID4EZC"></a>

 
## <a name="see-also"></a><span data-ttu-id="92e48-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="92e48-132">See also</span></span>
 
<a id="ID4E2C"></a>

 
##### <a name="parent"></a><span data-ttu-id="92e48-133">Parent</span><span class="sxs-lookup"><span data-stu-id="92e48-133">Parent</span></span> 

[<span data-ttu-id="92e48-134">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="92e48-134">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   