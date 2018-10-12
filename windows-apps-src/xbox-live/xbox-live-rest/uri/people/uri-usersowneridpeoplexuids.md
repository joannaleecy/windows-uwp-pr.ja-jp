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
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4567420"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="24899-104">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="24899-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="24899-105">XUID によって people を呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="24899-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="24899-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="24899-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="24899-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="24899-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="24899-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="24899-108">URI parameters</span></span>
 
| <span data-ttu-id="24899-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="24899-109">Parameter</span></span>| <span data-ttu-id="24899-110">型</span><span class="sxs-lookup"><span data-stu-id="24899-110">Type</span></span>| <span data-ttu-id="24899-111">説明</span><span class="sxs-lookup"><span data-stu-id="24899-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="24899-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="24899-112">ownerId</span></span>| <span data-ttu-id="24899-113">string</span><span class="sxs-lookup"><span data-stu-id="24899-113">string</span></span>| <span data-ttu-id="24899-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="24899-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="24899-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24899-115">Must match the authenticated user.</span></span> <span data-ttu-id="24899-116">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="24899-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="24899-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="24899-117">Valid methods</span></span>

[<span data-ttu-id="24899-118">POST</span><span class="sxs-lookup"><span data-stu-id="24899-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="24899-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="24899-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="24899-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="24899-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="24899-121">Parent</span><span class="sxs-lookup"><span data-stu-id="24899-121">Parent</span></span> 

[<span data-ttu-id="24899-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="24899-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   