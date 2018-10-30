---
title: /users/{ownerId}/people
assetID: 9745a93c-720e-606d-bff2-ad0ec610ed98
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeople.html
author: KevinAsgari
description: " /users/{ownerId}/people"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5191249e3ee0cdea9ca07f8f3bfbdd15992a3145
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5742820"
---
# <a name="usersowneridpeople"></a><span data-ttu-id="f8bb8-104">/users/{ownerId}/people</span><span class="sxs-lookup"><span data-stu-id="f8bb8-104">/users/{ownerId}/people</span></span>
<span data-ttu-id="f8bb8-105">呼び出し元のユーザーのコレクションにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="f8bb8-105">Accesses caller's people collection.</span></span> <span data-ttu-id="f8bb8-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f8bb8-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f8bb8-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8bb8-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f8bb8-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8bb8-108">URI parameters</span></span>
 
| <span data-ttu-id="f8bb8-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8bb8-109">Parameter</span></span>| <span data-ttu-id="f8bb8-110">型</span><span class="sxs-lookup"><span data-stu-id="f8bb8-110">Type</span></span>| <span data-ttu-id="f8bb8-111">説明</span><span class="sxs-lookup"><span data-stu-id="f8bb8-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f8bb8-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="f8bb8-112">ownerId</span></span>| <span data-ttu-id="f8bb8-113">string</span><span class="sxs-lookup"><span data-stu-id="f8bb8-113">string</span></span>| <span data-ttu-id="f8bb8-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="f8bb8-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="f8bb8-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8bb8-115">Must match the authenticated user.</span></span> <span data-ttu-id="f8bb8-116">可能な値は、"me"xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="f8bb8-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f8bb8-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f8bb8-117">Valid methods</span></span>

[<span data-ttu-id="f8bb8-118">GET</span><span class="sxs-lookup"><span data-stu-id="f8bb8-118">GET</span></span>](uri-usersowneridpeopleget.md)

<span data-ttu-id="f8bb8-119">&nbsp;&nbsp;呼び出し元のユーザーのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="f8bb8-119">&nbsp;&nbsp;Gets caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="f8bb8-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="f8bb8-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="f8bb8-121">Parent</span><span class="sxs-lookup"><span data-stu-id="f8bb8-121">Parent</span></span> 

[<span data-ttu-id="f8bb8-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="f8bb8-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   