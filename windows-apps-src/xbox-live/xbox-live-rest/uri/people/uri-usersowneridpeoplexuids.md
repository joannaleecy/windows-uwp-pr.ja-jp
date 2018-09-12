---
title: ユーザー/xuid/users/{ownerId}
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
author: KevinAsgari
description: " ユーザー/xuid/users/{ownerId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 715659b8bb001697fc9386be6ec587b3682793c5
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931433"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="c9964-104">ユーザー/xuid/users/{ownerId}</span><span class="sxs-lookup"><span data-stu-id="c9964-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="c9964-105">XUID によって people を呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="c9964-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="c9964-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c9964-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c9964-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9964-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c9964-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9964-108">URI parameters</span></span>
 
| <span data-ttu-id="c9964-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c9964-109">Parameter</span></span>| <span data-ttu-id="c9964-110">型</span><span class="sxs-lookup"><span data-stu-id="c9964-110">Type</span></span>| <span data-ttu-id="c9964-111">説明</span><span class="sxs-lookup"><span data-stu-id="c9964-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c9964-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="c9964-112">ownerId</span></span>| <span data-ttu-id="c9964-113">string</span><span class="sxs-lookup"><span data-stu-id="c9964-113">string</span></span>| <span data-ttu-id="c9964-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="c9964-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="c9964-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c9964-115">Must match the authenticated user.</span></span> <span data-ttu-id="c9964-116">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="c9964-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="c9964-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="c9964-117">Valid methods</span></span>

[<span data-ttu-id="c9964-118">POST</span><span class="sxs-lookup"><span data-stu-id="c9964-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="c9964-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="c9964-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="c9964-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="c9964-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="c9964-121">Parent</span><span class="sxs-lookup"><span data-stu-id="c9964-121">Parent</span></span> 

[<span data-ttu-id="c9964-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="c9964-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   