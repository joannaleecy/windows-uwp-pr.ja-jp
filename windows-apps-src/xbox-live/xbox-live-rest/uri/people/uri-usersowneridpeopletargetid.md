---
title: /users/{ownerId}/people/{targetid}
assetID: 9dd19e75-3b48-d7e0-fc65-6760c15ddf62
permalink: en-us/docs/xboxlive/rest/uri-usersowneridpeopletargetid.html
description: " /users/{ownerId}/people/{targetid}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6238996abdeaca9b7a9a7a20d3f1ae9702e95a73
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8927533"
---
# <a name="usersowneridpeopletargetid"></a><span data-ttu-id="d98da-104">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="d98da-104">/users/{ownerId}/people/{targetid}</span></span>
<span data-ttu-id="d98da-105">呼び出し元のユーザーのコレクションからターゲット ID でユーザーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d98da-105">Accesses a person by target ID from caller's people collection.</span></span> <span data-ttu-id="d98da-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d98da-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d98da-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d98da-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d98da-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d98da-108">URI parameters</span></span>
 
| <span data-ttu-id="d98da-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d98da-109">Parameter</span></span>| <span data-ttu-id="d98da-110">型</span><span class="sxs-lookup"><span data-stu-id="d98da-110">Type</span></span>| <span data-ttu-id="d98da-111">説明</span><span class="sxs-lookup"><span data-stu-id="d98da-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d98da-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="d98da-112">ownerId</span></span>| <span data-ttu-id="d98da-113">string</span><span class="sxs-lookup"><span data-stu-id="d98da-113">string</span></span>| <span data-ttu-id="d98da-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="d98da-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="d98da-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d98da-115">Must match the authenticated user.</span></span> <span data-ttu-id="d98da-116">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="d98da-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="d98da-117">targetid</span><span class="sxs-lookup"><span data-stu-id="d98da-117">targetid</span></span>| <span data-ttu-id="d98da-118">string</span><span class="sxs-lookup"><span data-stu-id="d98da-118">string</span></span>| <span data-ttu-id="d98da-119">所有者のユーザーのリストが Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからのデータを取得するユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="d98da-119">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="d98da-120">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="d98da-120">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="d98da-121">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="d98da-121">Valid methods</span></span>

[<span data-ttu-id="d98da-122">GET</span><span class="sxs-lookup"><span data-stu-id="d98da-122">GET</span></span>](uri-usersowneridpeopletargetidget.md)

<span data-ttu-id="d98da-123">&nbsp;&nbsp;呼び出し元のユーザーのコレクションからターゲット ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="d98da-123">&nbsp;&nbsp;Gets a person by target ID from caller's people collection.</span></span>
 
<a id="ID4E1B"></a>

 
## <a name="see-also"></a><span data-ttu-id="d98da-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="d98da-124">See also</span></span>
 
<a id="ID4E3B"></a>

 
##### <a name="parent"></a><span data-ttu-id="d98da-125">Parent</span><span class="sxs-lookup"><span data-stu-id="d98da-125">Parent</span></span> 

[<span data-ttu-id="d98da-126">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="d98da-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   