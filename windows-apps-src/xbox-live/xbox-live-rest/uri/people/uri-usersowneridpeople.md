---
title: /users/{ownerId}/people
assetID: 9745a93c-720e-606d-bff2-ad0ec610ed98
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeople.html
description: " /users/{ownerId}/people"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c3980ca2d755d9fceb4b9059f8c5f529a7c16218
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8782410"
---
# <a name="usersowneridpeople"></a><span data-ttu-id="778ed-104">/users/{ownerId}/people</span><span class="sxs-lookup"><span data-stu-id="778ed-104">/users/{ownerId}/people</span></span>
<span data-ttu-id="778ed-105">呼び出し元のユーザーのコレクションにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="778ed-105">Accesses caller's people collection.</span></span> <span data-ttu-id="778ed-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="778ed-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="778ed-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="778ed-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="778ed-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="778ed-108">URI parameters</span></span>
 
| <span data-ttu-id="778ed-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="778ed-109">Parameter</span></span>| <span data-ttu-id="778ed-110">型</span><span class="sxs-lookup"><span data-stu-id="778ed-110">Type</span></span>| <span data-ttu-id="778ed-111">説明</span><span class="sxs-lookup"><span data-stu-id="778ed-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="778ed-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="778ed-112">ownerId</span></span>| <span data-ttu-id="778ed-113">string</span><span class="sxs-lookup"><span data-stu-id="778ed-113">string</span></span>| <span data-ttu-id="778ed-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="778ed-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="778ed-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="778ed-115">Must match the authenticated user.</span></span> <span data-ttu-id="778ed-116">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="778ed-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="778ed-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="778ed-117">Valid methods</span></span>

[<span data-ttu-id="778ed-118">GET</span><span class="sxs-lookup"><span data-stu-id="778ed-118">GET</span></span>](uri-usersowneridpeopleget.md)

<span data-ttu-id="778ed-119">&nbsp;&nbsp;呼び出し元のユーザーのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="778ed-119">&nbsp;&nbsp;Gets caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="778ed-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="778ed-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="778ed-121">Parent</span><span class="sxs-lookup"><span data-stu-id="778ed-121">Parent</span></span> 

[<span data-ttu-id="778ed-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="778ed-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   