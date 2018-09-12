---
title: /users/{ownerId} そして {targetid}
assetID: 9dd19e75-3b48-d7e0-fc65-6760c15ddf62
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetid.html
author: KevinAsgari
description: " /users/{ownerId} そして {targetid}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7693d9e60a9fdf58eba8aecdd8618c0a78ecef44
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3930845"
---
# <a name="usersowneridpeopletargetid"></a><span data-ttu-id="a59d5-104">/users/{ownerId} そして {targetid}</span><span class="sxs-lookup"><span data-stu-id="a59d5-104">/users/{ownerId}/people/{targetid}</span></span>
<span data-ttu-id="a59d5-105">呼び出し元のユーザーのコレクションからターゲット ID でユーザーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="a59d5-105">Accesses a person by target ID from caller's people collection.</span></span> <span data-ttu-id="a59d5-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a59d5-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a59d5-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a59d5-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a59d5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a59d5-108">URI parameters</span></span>
 
| <span data-ttu-id="a59d5-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a59d5-109">Parameter</span></span>| <span data-ttu-id="a59d5-110">型</span><span class="sxs-lookup"><span data-stu-id="a59d5-110">Type</span></span>| <span data-ttu-id="a59d5-111">説明</span><span class="sxs-lookup"><span data-stu-id="a59d5-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a59d5-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="a59d5-112">ownerId</span></span>| <span data-ttu-id="a59d5-113">string</span><span class="sxs-lookup"><span data-stu-id="a59d5-113">string</span></span>| <span data-ttu-id="a59d5-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="a59d5-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="a59d5-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a59d5-115">Must match the authenticated user.</span></span> <span data-ttu-id="a59d5-116">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="a59d5-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="a59d5-117">targetid</span><span class="sxs-lookup"><span data-stu-id="a59d5-117">targetid</span></span>| <span data-ttu-id="a59d5-118">string</span><span class="sxs-lookup"><span data-stu-id="a59d5-118">string</span></span>| <span data-ttu-id="a59d5-119">所有者のユーザー リスト、Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからのデータを取得するユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="a59d5-119">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="a59d5-120">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="a59d5-120">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="a59d5-121">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a59d5-121">Valid methods</span></span>

[<span data-ttu-id="a59d5-122">GET</span><span class="sxs-lookup"><span data-stu-id="a59d5-122">GET</span></span>](uri-usersowneridpeopletargetidget.md)

<span data-ttu-id="a59d5-123">&nbsp;&nbsp;呼び出し元のユーザーのコレクションからターゲット ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="a59d5-123">&nbsp;&nbsp;Gets a person by target ID from caller's people collection.</span></span>
 
<a id="ID4E1B"></a>

 
## <a name="see-also"></a><span data-ttu-id="a59d5-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="a59d5-124">See also</span></span>
 
<a id="ID4E3B"></a>

 
##### <a name="parent"></a><span data-ttu-id="a59d5-125">Parent</span><span class="sxs-lookup"><span data-stu-id="a59d5-125">Parent</span></span> 

[<span data-ttu-id="a59d5-126">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="a59d5-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   