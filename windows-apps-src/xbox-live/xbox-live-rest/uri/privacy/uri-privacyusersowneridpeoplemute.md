---
title: /users/{ownerId}/people/mute
assetID: efb929d8-79a7-83f0-c348-c92ced42bc05
permalink: en-us/docs/xboxlive/rest/uri-privacyusersowneridpeoplemute.html
author: KevinAsgari
description: " /users/{ownerId}/people/mute"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a5de74be5e82fde007d6680eaf4c9e5a543afc64
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5161039"
---
# <a name="usersowneridpeoplemute"></a><span data-ttu-id="f8e13-104">/users/{ownerId}/people/mute</span><span class="sxs-lookup"><span data-stu-id="f8e13-104">/users/{ownerId}/people/mute</span></span>
<span data-ttu-id="f8e13-105">ユーザーのミュート一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="f8e13-105">Accesses the mute list for a user.</span></span>

  * [<span data-ttu-id="f8e13-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8e13-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="f8e13-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8e13-107">URI parameters</span></span>

| <span data-ttu-id="f8e13-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f8e13-108">Parameter</span></span>| <span data-ttu-id="f8e13-109">型</span><span class="sxs-lookup"><span data-stu-id="f8e13-109">Type</span></span>| <span data-ttu-id="f8e13-110">説明</span><span class="sxs-lookup"><span data-stu-id="f8e13-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="f8e13-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="f8e13-111">ownerId</span></span>| <span data-ttu-id="f8e13-112">string</span><span class="sxs-lookup"><span data-stu-id="f8e13-112">string</span></span>| <span data-ttu-id="f8e13-113">必須。</span><span class="sxs-lookup"><span data-stu-id="f8e13-113">Required.</span></span> <span data-ttu-id="f8e13-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="f8e13-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="f8e13-115">可能な値は、"me" <code>xuid({xuid})</code>、または gt({gamertag}) します。</span><span class="sxs-lookup"><span data-stu-id="f8e13-115">The possible values are "me", <code>xuid({xuid})</code>, or gt({gamertag}).</span></span> <span data-ttu-id="f8e13-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8e13-116">Must be the authenticated user.</span></span> <span data-ttu-id="f8e13-117">値の例: <code>xuid(2603643534573581)</code>、<code>gt(SomeGamertag)</code>します。</span><span class="sxs-lookup"><span data-stu-id="f8e13-117">Example values: <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code>.</span></span> <span data-ttu-id="f8e13-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="f8e13-118">Maximum size: none.</span></span> |

<a id="ID4ETB"></a>


## <a name="valid-methods"></a><span data-ttu-id="f8e13-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="f8e13-119">Valid methods</span></span>

[<span data-ttu-id="f8e13-120">GET (/users/{ownerId}/people/mute)</span><span class="sxs-lookup"><span data-stu-id="f8e13-120">GET (/users/{ownerId}/people/mute)</span></span>](uri-privacyusersowneridpeoplemuteget.md)

<span data-ttu-id="f8e13-121">&nbsp;&nbsp;ユーザーのミュートの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="f8e13-121">&nbsp;&nbsp;Gets the mute list for a user.</span></span>

<a id="ID4E4B"></a>


## <a name="see-also"></a><span data-ttu-id="f8e13-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="f8e13-122">See also</span></span>

<a id="ID4E6B"></a>


##### <a name="parent"></a><span data-ttu-id="f8e13-123">Parent</span><span class="sxs-lookup"><span data-stu-id="f8e13-123">Parent</span></span>

[<span data-ttu-id="f8e13-124">プライバシー URI</span><span class="sxs-lookup"><span data-stu-id="f8e13-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
