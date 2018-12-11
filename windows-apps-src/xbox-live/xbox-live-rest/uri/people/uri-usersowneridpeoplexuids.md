---
title: /users/{ownerId}/people/xuids
assetID: db2faec7-9f6c-f240-586a-45d6ed596e88
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeoplexuids.html
description: " /users/{ownerId}/people/xuids"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 27b7695ba163bf0ca832a96df030868e646e0abc
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8870970"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="3cd76-104">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="3cd76-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="3cd76-105">XUID によってユーザーを呼び出し元のユーザーのコレクションからアクセスします。</span><span class="sxs-lookup"><span data-stu-id="3cd76-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="3cd76-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3cd76-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3cd76-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3cd76-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3cd76-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3cd76-108">URI parameters</span></span>
 
| <span data-ttu-id="3cd76-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3cd76-109">Parameter</span></span>| <span data-ttu-id="3cd76-110">型</span><span class="sxs-lookup"><span data-stu-id="3cd76-110">Type</span></span>| <span data-ttu-id="3cd76-111">説明</span><span class="sxs-lookup"><span data-stu-id="3cd76-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3cd76-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="3cd76-112">ownerId</span></span>| <span data-ttu-id="3cd76-113">string</span><span class="sxs-lookup"><span data-stu-id="3cd76-113">string</span></span>| <span data-ttu-id="3cd76-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="3cd76-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="3cd76-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3cd76-115">Must match the authenticated user.</span></span> <span data-ttu-id="3cd76-116">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="3cd76-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="3cd76-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="3cd76-117">Valid methods</span></span>

[<span data-ttu-id="3cd76-118">POST</span><span class="sxs-lookup"><span data-stu-id="3cd76-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="3cd76-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションに対応する XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="3cd76-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="3cd76-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="3cd76-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="3cd76-121">Parent</span><span class="sxs-lookup"><span data-stu-id="3cd76-121">Parent</span></span> 

[<span data-ttu-id="3cd76-122">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="3cd76-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   