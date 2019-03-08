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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661747"
---
# <a name="usersowneridpeopletargetid"></a><span data-ttu-id="f72d2-104">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="f72d2-104">/users/{ownerId}/people/{targetid}</span></span>
<span data-ttu-id="f72d2-105">呼び出し元のユーザーのコレクションからターゲットの ID でユーザーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="f72d2-105">Accesses a person by target ID from caller's people collection.</span></span> <span data-ttu-id="f72d2-106">これらの Uri のドメインが`social.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f72d2-106">The domain for these URIs is `social.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f72d2-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f72d2-107">URI parameters</span></span>](#ID4EV)
 
<a id="ID4EV"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f72d2-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f72d2-108">URI parameters</span></span>
 
| <span data-ttu-id="f72d2-109">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f72d2-109">Parameter</span></span>| <span data-ttu-id="f72d2-110">種類</span><span class="sxs-lookup"><span data-stu-id="f72d2-110">Type</span></span>| <span data-ttu-id="f72d2-111">説明</span><span class="sxs-lookup"><span data-stu-id="f72d2-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f72d2-112">ownerId</span><span class="sxs-lookup"><span data-stu-id="f72d2-112">ownerId</span></span>| <span data-ttu-id="f72d2-113">string</span><span class="sxs-lookup"><span data-stu-id="f72d2-113">string</span></span>| <span data-ttu-id="f72d2-114">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="f72d2-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="f72d2-115">認証されたユーザーに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f72d2-115">Must match the authenticated user.</span></span> <span data-ttu-id="f72d2-116">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="f72d2-116">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span>| 
| <span data-ttu-id="f72d2-117">targetid</span><span class="sxs-lookup"><span data-stu-id="f72d2-117">targetid</span></span>| <span data-ttu-id="f72d2-118">string</span><span class="sxs-lookup"><span data-stu-id="f72d2-118">string</span></span>| <span data-ttu-id="f72d2-119">所有者の連絡先リスト、Xbox ユーザー ID (XUID) またはゲーマータグのいずれかからデータを取得するユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="f72d2-119">Identifier of the user whose data is being retrieved from the owner's People list, either an Xbox User ID (XUID) or a gamertag.</span></span> <span data-ttu-id="f72d2-120">値の例: xuid(2603643534573581)、gt(SomeGamertag) します。</span><span class="sxs-lookup"><span data-stu-id="f72d2-120">Example values: xuid(2603643534573581), gt(SomeGamertag).</span></span>| 
  
<a id="ID4EQB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="f72d2-121">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f72d2-121">Valid methods</span></span>

[<span data-ttu-id="f72d2-122">取得</span><span class="sxs-lookup"><span data-stu-id="f72d2-122">GET</span></span>](uri-usersowneridpeopletargetidget.md)

<span data-ttu-id="f72d2-123">&nbsp;&nbsp;呼び出し元のユーザーのコレクションからターゲットの ID でユーザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="f72d2-123">&nbsp;&nbsp;Gets a person by target ID from caller's people collection.</span></span>
 
<a id="ID4E1B"></a>

 
## <a name="see-also"></a><span data-ttu-id="f72d2-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="f72d2-124">See also</span></span>
 
<a id="ID4E3B"></a>

 
##### <a name="parent"></a><span data-ttu-id="f72d2-125">Parent</span><span class="sxs-lookup"><span data-stu-id="f72d2-125">Parent</span></span> 

[<span data-ttu-id="f72d2-126">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="f72d2-126">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   