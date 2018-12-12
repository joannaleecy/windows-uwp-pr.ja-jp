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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8935488"
---
# <a name="usersowneridpeoplemute"></a><span data-ttu-id="cf3fc-104">/users/{ownerId}/people/mute</span><span class="sxs-lookup"><span data-stu-id="cf3fc-104">/users/{ownerId}/people/mute</span></span>
<span data-ttu-id="cf3fc-105">ユーザーのミュート リストにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="cf3fc-105">Accesses the mute list for a user.</span></span>

  * [<span data-ttu-id="cf3fc-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf3fc-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="cf3fc-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf3fc-107">URI parameters</span></span>

| <span data-ttu-id="cf3fc-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf3fc-108">Parameter</span></span>| <span data-ttu-id="cf3fc-109">型</span><span class="sxs-lookup"><span data-stu-id="cf3fc-109">Type</span></span>| <span data-ttu-id="cf3fc-110">説明</span><span class="sxs-lookup"><span data-stu-id="cf3fc-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="cf3fc-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="cf3fc-111">ownerId</span></span>| <span data-ttu-id="cf3fc-112">string</span><span class="sxs-lookup"><span data-stu-id="cf3fc-112">string</span></span>| <span data-ttu-id="cf3fc-113">必須。</span><span class="sxs-lookup"><span data-stu-id="cf3fc-113">Required.</span></span> <span data-ttu-id="cf3fc-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="cf3fc-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="cf3fc-115">設定可能な値は"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。</span><span class="sxs-lookup"><span data-stu-id="cf3fc-115">The possible values are "me", <code>xuid({xuid})</code>, or gt({gamertag}).</span></span> <span data-ttu-id="cf3fc-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf3fc-116">Must be the authenticated user.</span></span> <span data-ttu-id="cf3fc-117">値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。</span><span class="sxs-lookup"><span data-stu-id="cf3fc-117">Example values: <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code>.</span></span> <span data-ttu-id="cf3fc-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="cf3fc-118">Maximum size: none.</span></span> |

<a id="ID4ETB"></a>


## <a name="valid-methods"></a><span data-ttu-id="cf3fc-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="cf3fc-119">Valid methods</span></span>

[<span data-ttu-id="cf3fc-120">GET (/users/{ownerId}/people/mute)</span><span class="sxs-lookup"><span data-stu-id="cf3fc-120">GET (/users/{ownerId}/people/mute)</span></span>](uri-privacyusersowneridpeoplemuteget.md)

<span data-ttu-id="cf3fc-121">&nbsp;&nbsp;ユーザーのミュートの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="cf3fc-121">&nbsp;&nbsp;Gets the mute list for a user.</span></span>

<a id="ID4E4B"></a>


## <a name="see-also"></a><span data-ttu-id="cf3fc-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="cf3fc-122">See also</span></span>

<a id="ID4E6B"></a>


##### <a name="parent"></a><span data-ttu-id="cf3fc-123">Parent</span><span class="sxs-lookup"><span data-stu-id="cf3fc-123">Parent</span></span>

[<span data-ttu-id="cf3fc-124">プライバシー URI</span><span class="sxs-lookup"><span data-stu-id="cf3fc-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
