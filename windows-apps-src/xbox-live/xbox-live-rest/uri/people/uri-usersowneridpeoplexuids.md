---
title: /users/{ownerId}/people/xuids
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
author: KevinAsgari
description: " /users/{ownerId}/people/xuids"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 715659b8bb001697fc9386be6ec587b3682793c5
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4153986"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="52870-104">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="52870-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="52870-105">XUID によって people を呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="52870-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="52870-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="52870-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="52870-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="52870-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="52870-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="52870-108">URI parameters</span></span>
 
| <span data-ttu-id="52870-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="52870-109">Parameter</span></span>| <span data-ttu-id="52870-110">型</span><span class="sxs-lookup"><span data-stu-id="52870-110">Type</span></span>| <span data-ttu-id="52870-111">説明</span><span class="sxs-lookup"><span data-stu-id="52870-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="52870-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="52870-112">ownerId</span></span>| <span data-ttu-id="52870-113">string</span><span class="sxs-lookup"><span data-stu-id="52870-113">string</span></span>| <span data-ttu-id="52870-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="52870-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="52870-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="52870-115">Must match the authenticated user.</span></span> <span data-ttu-id="52870-116">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="52870-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="52870-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="52870-117">Valid methods</span></span>

[<span data-ttu-id="52870-118">POST</span><span class="sxs-lookup"><span data-stu-id="52870-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="52870-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="52870-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="52870-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="52870-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="52870-121">Parent</span><span class="sxs-lookup"><span data-stu-id="52870-121">Parent</span></span> 

[<span data-ttu-id="52870-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="52870-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   