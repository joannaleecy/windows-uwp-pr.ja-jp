---
title: /users/{ownerId}/people
assetID: 9745a93c-720e-606d-bff2-ad0ec610ed98
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeople.html
author: KevinAsgari
description: " /users/{ownerId}/people"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9778c5519a52291754d08fa8c1f4c4ed163967e1
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4753230"
---
# <a name="usersowneridpeople"></a><span data-ttu-id="dad6b-104">/users/{ownerId}/people</span><span class="sxs-lookup"><span data-stu-id="dad6b-104">/users/{ownerId}/people</span></span>
<span data-ttu-id="dad6b-105">呼び出し元のユーザーのコレクションにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="dad6b-105">Accesses caller's people collection.</span></span> <span data-ttu-id="dad6b-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="dad6b-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="dad6b-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="dad6b-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="dad6b-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="dad6b-108">URI parameters</span></span>
 
| <span data-ttu-id="dad6b-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="dad6b-109">Parameter</span></span>| <span data-ttu-id="dad6b-110">型</span><span class="sxs-lookup"><span data-stu-id="dad6b-110">Type</span></span>| <span data-ttu-id="dad6b-111">説明</span><span class="sxs-lookup"><span data-stu-id="dad6b-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="dad6b-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="dad6b-112">ownerId</span></span>| <span data-ttu-id="dad6b-113">string</span><span class="sxs-lookup"><span data-stu-id="dad6b-113">string</span></span>| <span data-ttu-id="dad6b-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="dad6b-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="dad6b-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dad6b-115">Must match the authenticated user.</span></span> <span data-ttu-id="dad6b-116">可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="dad6b-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="dad6b-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="dad6b-117">Valid methods</span></span>

[<span data-ttu-id="dad6b-118">GET</span><span class="sxs-lookup"><span data-stu-id="dad6b-118">GET</span></span>](uri-usersowneridpeopleget.md)

<span data-ttu-id="dad6b-119">&nbsp;&nbsp;呼び出し元のユーザーのコレクションを取得します。</span><span class="sxs-lookup"><span data-stu-id="dad6b-119">&nbsp;&nbsp;Gets caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="dad6b-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="dad6b-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="dad6b-121">Parent</span><span class="sxs-lookup"><span data-stu-id="dad6b-121">Parent</span></span> 

[<span data-ttu-id="dad6b-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="dad6b-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   