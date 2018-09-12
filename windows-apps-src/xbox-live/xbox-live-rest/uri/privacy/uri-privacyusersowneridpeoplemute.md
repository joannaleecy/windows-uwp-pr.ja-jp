---
title: ユーザー/ミュート/users/{ownerId}
assetID: efb929d8-79a7-83f0-c348-c92ced42bc05
permalink: en-us/docs/xboxlive/rest/uri-privacyusersowneridpeoplemute.html
author: KevinAsgari
description: " ユーザー/ミュート/users/{ownerId}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a5de74be5e82fde007d6680eaf4c9e5a543afc64
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931666"
---
# <a name="usersowneridpeoplemute"></a><span data-ttu-id="613b6-104">ユーザー/ミュート/users/{ownerId}</span><span class="sxs-lookup"><span data-stu-id="613b6-104">/users/{ownerId}/people/mute</span></span>
<span data-ttu-id="613b6-105">ユーザーのミュート リストにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="613b6-105">Accesses the mute list for a user.</span></span>

  * [<span data-ttu-id="613b6-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="613b6-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="613b6-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="613b6-107">URI parameters</span></span>

| <span data-ttu-id="613b6-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="613b6-108">Parameter</span></span>| <span data-ttu-id="613b6-109">型</span><span class="sxs-lookup"><span data-stu-id="613b6-109">Type</span></span>| <span data-ttu-id="613b6-110">説明</span><span class="sxs-lookup"><span data-stu-id="613b6-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="613b6-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="613b6-111">ownerId</span></span>| <span data-ttu-id="613b6-112">string</span><span class="sxs-lookup"><span data-stu-id="613b6-112">string</span></span>| <span data-ttu-id="613b6-113">必須。</span><span class="sxs-lookup"><span data-stu-id="613b6-113">Required.</span></span> <span data-ttu-id="613b6-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="613b6-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="613b6-115">設定可能な値は"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。</span><span class="sxs-lookup"><span data-stu-id="613b6-115">The possible values are "me", <code>xuid({xuid})</code>, or gt({gamertag}).</span></span> <span data-ttu-id="613b6-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="613b6-116">Must be the authenticated user.</span></span> <span data-ttu-id="613b6-117">値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。</span><span class="sxs-lookup"><span data-stu-id="613b6-117">Example values: <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code>.</span></span> <span data-ttu-id="613b6-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="613b6-118">Maximum size: none.</span></span> |

<a id="ID4ETB"></a>


## <a name="valid-methods"></a><span data-ttu-id="613b6-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="613b6-119">Valid methods</span></span>

[<span data-ttu-id="613b6-120">GET (/users/{ownerId}/ユーザー/ミュート)</span><span class="sxs-lookup"><span data-stu-id="613b6-120">GET (/users/{ownerId}/people/mute)</span></span>](uri-privacyusersowneridpeoplemuteget.md)

<span data-ttu-id="613b6-121">&nbsp;&nbsp;ユーザーのミュートの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="613b6-121">&nbsp;&nbsp;Gets the mute list for a user.</span></span>

<a id="ID4E4B"></a>


## <a name="see-also"></a><span data-ttu-id="613b6-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="613b6-122">See also</span></span>

<a id="ID4E6B"></a>


##### <a name="parent"></a><span data-ttu-id="613b6-123">Parent</span><span class="sxs-lookup"><span data-stu-id="613b6-123">Parent</span></span>

[<span data-ttu-id="613b6-124">プライバシー Uri</span><span class="sxs-lookup"><span data-stu-id="613b6-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
