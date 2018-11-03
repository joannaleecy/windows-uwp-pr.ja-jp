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
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5971237"
---
# <a name="usersowneridpeopletargetid"></a><span data-ttu-id="b7c59-104">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="b7c59-104">/users/{ownerId}/people/{targetid}</span></span>
<span data-ttu-id="b7c59-105">呼び出し元のユーザーのコレクションからターゲット ID でユーザーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b7c59-105">Accesses a person by target ID from caller's people collection.</span></span> <span data-ttu-id="b7c59-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b7c59-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b7c59-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b7c59-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b7c59-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b7c59-108">URI parameters</span></span>
 
| <span data-ttu-id="b7c59-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b7c59-109">Parameter</span></span>| <span data-ttu-id="b7c59-110">型</span><span class="sxs-lookup"><span data-stu-id="b7c59-110">Type</span></span>| <span data-ttu-id="b7c59-111">説明</span><span class="sxs-lookup"><span data-stu-id="b7c59-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b7c59-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="b7c59-112">ownerId</span></span>| <span data-ttu-id="b7c59-113">string</span><span class="sxs-lookup"><span data-stu-id="b7c59-113">string</span></span>| <span data-ttu-id="b7c59-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="b7c59-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="b7c59-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7c59-115">Must match the authenticated user.</span></span> <span data-ttu-id="b7c59-116">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="b7c59-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="b7c59-117">targetid</span><span class="sxs-lookup"><span data-stu-id="b7c59-117">targetid</span></span>| <span data-ttu-id="b7c59-118">string</span><span class="sxs-lookup"><span data-stu-id="b7c59-118">string</span></span>| <span data-ttu-id="b7c59-119">Xbox ユーザー ID (XUID) か、ゲーマータグの所有者のユーザー一覧からのデータを取得するユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="b7c59-119">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="b7c59-120">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="b7c59-120">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b7c59-121">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b7c59-121">Valid methods</span></span>

[<span data-ttu-id="b7c59-122">GET</span><span class="sxs-lookup"><span data-stu-id="b7c59-122">GET</span></span>](uri-usersowneridpeopletargetidget.md)

<span data-ttu-id="b7c59-123">&nbsp;&nbsp;呼び出し元のユーザーのコレクションからターゲット ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="b7c59-123">&nbsp;&nbsp;Gets a person by target ID from caller's people collection.</span></span>
 
<a id="ID4E1B"></a>

 
## <a name="see-also"></a><span data-ttu-id="b7c59-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="b7c59-124">See also</span></span>
 
<a id="ID4E3B"></a>

 
##### <a name="parent"></a><span data-ttu-id="b7c59-125">Parent</span><span class="sxs-lookup"><span data-stu-id="b7c59-125">Parent</span></span> 

[<span data-ttu-id="b7c59-126">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="b7c59-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   