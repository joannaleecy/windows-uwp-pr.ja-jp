---
title: /users/{ownerId}/people/xuids
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
author: KevinAsgari
description: " /users/{ownerId}/people/xuids"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d2b915e185462e65f68fefce009d6081e7cddf37
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5881306"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="7dcdb-104">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="7dcdb-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="7dcdb-105">XUID によって people を呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="7dcdb-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="7dcdb-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7dcdb-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="7dcdb-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7dcdb-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7dcdb-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7dcdb-108">URI parameters</span></span>
 
| <span data-ttu-id="7dcdb-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7dcdb-109">Parameter</span></span>| <span data-ttu-id="7dcdb-110">型</span><span class="sxs-lookup"><span data-stu-id="7dcdb-110">Type</span></span>| <span data-ttu-id="7dcdb-111">説明</span><span class="sxs-lookup"><span data-stu-id="7dcdb-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7dcdb-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="7dcdb-112">ownerId</span></span>| <span data-ttu-id="7dcdb-113">string</span><span class="sxs-lookup"><span data-stu-id="7dcdb-113">string</span></span>| <span data-ttu-id="7dcdb-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="7dcdb-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="7dcdb-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7dcdb-115">Must match the authenticated user.</span></span> <span data-ttu-id="7dcdb-116">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="7dcdb-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="7dcdb-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="7dcdb-117">Valid methods</span></span>

[<span data-ttu-id="7dcdb-118">POST</span><span class="sxs-lookup"><span data-stu-id="7dcdb-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="7dcdb-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションに対応する XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="7dcdb-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="7dcdb-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="7dcdb-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="7dcdb-121">Parent</span><span class="sxs-lookup"><span data-stu-id="7dcdb-121">Parent</span></span> 

[<span data-ttu-id="7dcdb-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="7dcdb-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   