---
title: /users/{ownerId}/people/{targetid}
assetID: 9dd19e75-3b48-d7e0-fc65-6760c15ddf62
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetid.html
author: KevinAsgari
description: " /users/{ownerId}/people/{targetid}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7693d9e60a9fdf58eba8aecdd8618c0a78ecef44
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4308457"
---
# <a name="usersowneridpeopletargetid"></a><span data-ttu-id="b413f-104">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="b413f-104">/users/{ownerId}/people/{targetid}</span></span>
<span data-ttu-id="b413f-105">呼び出し元のユーザーのコレクションからターゲット ID によってユーザーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b413f-105">Accesses a person by target ID from caller's people collection.</span></span> <span data-ttu-id="b413f-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b413f-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="b413f-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b413f-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="b413f-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b413f-108">URI parameters</span></span>
 
| <span data-ttu-id="b413f-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b413f-109">Parameter</span></span>| <span data-ttu-id="b413f-110">型</span><span class="sxs-lookup"><span data-stu-id="b413f-110">Type</span></span>| <span data-ttu-id="b413f-111">説明</span><span class="sxs-lookup"><span data-stu-id="b413f-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b413f-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="b413f-112">ownerId</span></span>| <span data-ttu-id="b413f-113">string</span><span class="sxs-lookup"><span data-stu-id="b413f-113">string</span></span>| <span data-ttu-id="b413f-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="b413f-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="b413f-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b413f-115">Must match the authenticated user.</span></span> <span data-ttu-id="b413f-116">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="b413f-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="b413f-117">targetid</span><span class="sxs-lookup"><span data-stu-id="b413f-117">targetid</span></span>| <span data-ttu-id="b413f-118">string</span><span class="sxs-lookup"><span data-stu-id="b413f-118">string</span></span>| <span data-ttu-id="b413f-119">所有者の People リストで、Xbox ユーザー ID (XUID) か、ゲーマータグがデータを取得するユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="b413f-119">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="b413f-120">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="b413f-120">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="b413f-121">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="b413f-121">Valid methods</span></span>

[<span data-ttu-id="b413f-122">GET</span><span class="sxs-lookup"><span data-stu-id="b413f-122">GET</span></span>](uri-usersowneridpeopletargetidget.md)

<span data-ttu-id="b413f-123">&nbsp;&nbsp;呼び出し元のユーザーのコレクションからターゲット ID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="b413f-123">&nbsp;&nbsp;Gets a person by target ID from caller's people collection.</span></span>
 
<a id="ID4E1B"></a>

 
## <a name="see-also"></a><span data-ttu-id="b413f-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="b413f-124">See also</span></span>
 
<a id="ID4E3B"></a>

 
##### <a name="parent"></a><span data-ttu-id="b413f-125">Parent</span><span class="sxs-lookup"><span data-stu-id="b413f-125">Parent</span></span> 

[<span data-ttu-id="b413f-126">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="b413f-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   