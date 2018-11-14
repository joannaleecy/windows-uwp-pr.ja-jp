---
title: /users/{ownerId}/people/{targetid}
assetID: 9dd19e75-3b48-d7e0-fc65-6760c15ddf62
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetid.html
author: KevinAsgari
description: " /users/{ownerId}/people/{targetid}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f745e416c573bdf4c6aa172c62a82204ba077dcd
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6270779"
---
# <a name="usersowneridpeopletargetid"></a><span data-ttu-id="fdc09-104">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="fdc09-104">/users/{ownerId}/people/{targetid}</span></span>
<span data-ttu-id="fdc09-105">呼び出し元のユーザーのコレクションからターゲット ID によってユーザーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="fdc09-105">Accesses a person by target ID from caller's people collection.</span></span> <span data-ttu-id="fdc09-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="fdc09-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="fdc09-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fdc09-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="fdc09-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fdc09-108">URI parameters</span></span>
 
| <span data-ttu-id="fdc09-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fdc09-109">Parameter</span></span>| <span data-ttu-id="fdc09-110">型</span><span class="sxs-lookup"><span data-stu-id="fdc09-110">Type</span></span>| <span data-ttu-id="fdc09-111">説明</span><span class="sxs-lookup"><span data-stu-id="fdc09-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="fdc09-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="fdc09-112">ownerId</span></span>| <span data-ttu-id="fdc09-113">string</span><span class="sxs-lookup"><span data-stu-id="fdc09-113">string</span></span>| <span data-ttu-id="fdc09-114">そのリソースにアクセスしているユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="fdc09-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="fdc09-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fdc09-115">Must match the authenticated user.</span></span> <span data-ttu-id="fdc09-116">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="fdc09-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="fdc09-117">targetid</span><span class="sxs-lookup"><span data-stu-id="fdc09-117">targetid</span></span>| <span data-ttu-id="fdc09-118">string</span><span class="sxs-lookup"><span data-stu-id="fdc09-118">string</span></span>| <span data-ttu-id="fdc09-119">所有者のユーザーのリストが Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからのデータを取得するユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="fdc09-119">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="fdc09-120">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="fdc09-120">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="fdc09-121">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="fdc09-121">Valid methods</span></span>

[<span data-ttu-id="fdc09-122">GET</span><span class="sxs-lookup"><span data-stu-id="fdc09-122">GET</span></span>](uri-usersowneridpeopletargetidget.md)

<span data-ttu-id="fdc09-123">&nbsp;&nbsp;呼び出し元のユーザーのコレクションからターゲット ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="fdc09-123">&nbsp;&nbsp;Gets a person by target ID from caller's people collection.</span></span>
 
<a id="ID4E1B"></a>

 
## <a name="see-also"></a><span data-ttu-id="fdc09-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="fdc09-124">See also</span></span>
 
<a id="ID4E3B"></a>

 
##### <a name="parent"></a><span data-ttu-id="fdc09-125">Parent</span><span class="sxs-lookup"><span data-stu-id="fdc09-125">Parent</span></span> 

[<span data-ttu-id="fdc09-126">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="fdc09-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   