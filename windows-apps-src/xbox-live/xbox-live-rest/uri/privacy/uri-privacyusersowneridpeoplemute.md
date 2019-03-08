---
title: /users/{ownerId}/people/mute
assetID: efb929d8-79a7-83f0-c348-c92ced42bc05
permalink: en-us/docs/xboxlive/rest/uri-privacyusersowneridpeoplemute.html
description: " /users/{ownerId}/people/mute"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 86010d11ff0a7ebe188766f51bc3160a4f2befa4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641547"
---
# <a name="usersowneridpeoplemute"></a><span data-ttu-id="51b1d-104">/users/{ownerId}/people/mute</span><span class="sxs-lookup"><span data-stu-id="51b1d-104">/users/{ownerId}/people/mute</span></span>
<span data-ttu-id="51b1d-105">ユーザーのミュートの一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="51b1d-105">Accesses the mute list for a user.</span></span>

  * [<span data-ttu-id="51b1d-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="51b1d-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="51b1d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="51b1d-107">URI parameters</span></span>

| <span data-ttu-id="51b1d-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="51b1d-108">Parameter</span></span>| <span data-ttu-id="51b1d-109">種類</span><span class="sxs-lookup"><span data-stu-id="51b1d-109">Type</span></span>| <span data-ttu-id="51b1d-110">説明</span><span class="sxs-lookup"><span data-stu-id="51b1d-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="51b1d-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="51b1d-111">ownerId</span></span>| <span data-ttu-id="51b1d-112">string</span><span class="sxs-lookup"><span data-stu-id="51b1d-112">string</span></span>| <span data-ttu-id="51b1d-113">必須。</span><span class="sxs-lookup"><span data-stu-id="51b1d-113">Required.</span></span> <span data-ttu-id="51b1d-114">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="51b1d-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="51b1d-115">使用可能な値は"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。</span><span class="sxs-lookup"><span data-stu-id="51b1d-115">The possible values are "me", <code>xuid({xuid})</code>, or gt({gamertag}).</span></span> <span data-ttu-id="51b1d-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b1d-116">Must be the authenticated user.</span></span> <span data-ttu-id="51b1d-117">値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。</span><span class="sxs-lookup"><span data-stu-id="51b1d-117">Example values: <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code>.</span></span> <span data-ttu-id="51b1d-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="51b1d-118">Maximum size: none.</span></span> |

<a id="ID4ETB"></a>


## <a name="valid-methods"></a><span data-ttu-id="51b1d-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="51b1d-119">Valid methods</span></span>

[<span data-ttu-id="51b1d-120">GET (/users/{ownerId}/people/mute)</span><span class="sxs-lookup"><span data-stu-id="51b1d-120">GET (/users/{ownerId}/people/mute)</span></span>](uri-privacyusersowneridpeoplemuteget.md)

<span data-ttu-id="51b1d-121">&nbsp;&nbsp;ユーザーのミュートの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="51b1d-121">&nbsp;&nbsp;Gets the mute list for a user.</span></span>

<a id="ID4E4B"></a>


## <a name="see-also"></a><span data-ttu-id="51b1d-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="51b1d-122">See also</span></span>

<a id="ID4E6B"></a>


##### <a name="parent"></a><span data-ttu-id="51b1d-123">Parent</span><span class="sxs-lookup"><span data-stu-id="51b1d-123">Parent</span></span>

[<span data-ttu-id="51b1d-124">プライバシーの Uri</span><span class="sxs-lookup"><span data-stu-id="51b1d-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
