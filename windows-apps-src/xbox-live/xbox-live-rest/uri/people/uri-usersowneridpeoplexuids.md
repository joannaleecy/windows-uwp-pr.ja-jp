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
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5444399"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="482bc-104">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="482bc-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="482bc-105">XUID によって people を呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="482bc-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="482bc-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="482bc-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="482bc-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="482bc-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="482bc-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="482bc-108">URI parameters</span></span>
 
| <span data-ttu-id="482bc-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="482bc-109">Parameter</span></span>| <span data-ttu-id="482bc-110">型</span><span class="sxs-lookup"><span data-stu-id="482bc-110">Type</span></span>| <span data-ttu-id="482bc-111">説明</span><span class="sxs-lookup"><span data-stu-id="482bc-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="482bc-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="482bc-112">ownerId</span></span>| <span data-ttu-id="482bc-113">string</span><span class="sxs-lookup"><span data-stu-id="482bc-113">string</span></span>| <span data-ttu-id="482bc-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="482bc-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="482bc-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="482bc-115">Must match the authenticated user.</span></span> <span data-ttu-id="482bc-116">可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="482bc-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="482bc-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="482bc-117">Valid methods</span></span>

[<span data-ttu-id="482bc-118">POST</span><span class="sxs-lookup"><span data-stu-id="482bc-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="482bc-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションに対応する XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="482bc-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="482bc-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="482bc-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="482bc-121">Parent</span><span class="sxs-lookup"><span data-stu-id="482bc-121">Parent</span></span> 

[<span data-ttu-id="482bc-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="482bc-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   