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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57626337"
---
# <a name="usersowneridpeoplexuids"></a><span data-ttu-id="12e91-104">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="12e91-104">/users/{ownerId}/people/xuids</span></span>
<span data-ttu-id="12e91-105">XUID によってユーザーを呼び出し元のユーザーのコレクションからアクセスされます。</span><span class="sxs-lookup"><span data-stu-id="12e91-105">Accesses people by XUID from caller's people collection.</span></span> <span data-ttu-id="12e91-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="12e91-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="12e91-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="12e91-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="12e91-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="12e91-108">URI parameters</span></span>
 
| <span data-ttu-id="12e91-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="12e91-109">Parameter</span></span>| <span data-ttu-id="12e91-110">種類</span><span class="sxs-lookup"><span data-stu-id="12e91-110">Type</span></span>| <span data-ttu-id="12e91-111">説明</span><span class="sxs-lookup"><span data-stu-id="12e91-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="12e91-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="12e91-112">ownerId</span></span>| <span data-ttu-id="12e91-113">string</span><span class="sxs-lookup"><span data-stu-id="12e91-113">string</span></span>| <span data-ttu-id="12e91-114">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="12e91-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="12e91-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12e91-115">Must match the authenticated user.</span></span> <span data-ttu-id="12e91-116">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="12e91-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
  
<a id="ID4EOB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="12e91-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="12e91-117">Valid methods</span></span>

[<span data-ttu-id="12e91-118">投稿</span><span class="sxs-lookup"><span data-stu-id="12e91-118">POST</span></span>](uri-usersowneridpeoplexuidspost.md)

<span data-ttu-id="12e91-119">&nbsp;&nbsp;呼び出し元のユーザーからコレクションの XUID によってユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="12e91-119">&nbsp;&nbsp;Gets people by XUID from caller's people collection.</span></span>
 
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="12e91-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="12e91-120">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="12e91-121">Parent</span><span class="sxs-lookup"><span data-stu-id="12e91-121">Parent</span></span> 

[<span data-ttu-id="12e91-122">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="12e91-122">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   