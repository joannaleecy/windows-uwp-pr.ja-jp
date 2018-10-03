---
title: /users/{ownerId}/people/avoid
assetID: 13dc3a10-ed04-4600-3afb-aa95a4139a06
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoid.html
author: KevinAsgari
description: " /users/{ownerId}/people/avoid"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 635f11677997523fe952de04b8398410efc503d2
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4264256"
---
# <a name="usersowneridpeopleavoid"></a><span data-ttu-id="c8f3d-104">/users/{ownerId}/people/avoid</span><span class="sxs-lookup"><span data-stu-id="c8f3d-104">/users/{ownerId}/people/avoid</span></span>
<span data-ttu-id="c8f3d-105">ユーザーの避ける一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="c8f3d-105">Accesses the Avoid list for a user</span></span>

  * [<span data-ttu-id="c8f3d-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8f3d-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="c8f3d-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8f3d-107">URI parameters</span></span>

| <span data-ttu-id="c8f3d-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8f3d-108">Parameter</span></span>| <span data-ttu-id="c8f3d-109">型</span><span class="sxs-lookup"><span data-stu-id="c8f3d-109">Type</span></span>| <span data-ttu-id="c8f3d-110">説明</span><span class="sxs-lookup"><span data-stu-id="c8f3d-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="c8f3d-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="c8f3d-111">ownerId</span></span>| <span data-ttu-id="c8f3d-112">string</span><span class="sxs-lookup"><span data-stu-id="c8f3d-112">string</span></span>| <span data-ttu-id="c8f3d-113">必須。</span><span class="sxs-lookup"><span data-stu-id="c8f3d-113">Required.</span></span> <span data-ttu-id="c8f3d-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="c8f3d-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="c8f3d-115">設定可能な値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="c8f3d-115">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="c8f3d-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8f3d-116">Must be the authenticated user.</span></span> <span data-ttu-id="c8f3d-117">値の例:<code>xuid(2603643534573581)</code>します。</span><span class="sxs-lookup"><span data-stu-id="c8f3d-117">Example value: <code>xuid(2603643534573581)</code>.</span></span> <span data-ttu-id="c8f3d-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="c8f3d-118">Maximum size: none.</span></span> |

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="c8f3d-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="c8f3d-119">Valid methods</span></span>

[<span data-ttu-id="c8f3d-120">GET (/users/{ownerId}/people/avoid)</span><span class="sxs-lookup"><span data-stu-id="c8f3d-120">GET (/users/{ownerId}/people/avoid)</span></span>](uri-privacyusersxuidpeopleavoidget.md)

<span data-ttu-id="c8f3d-121">&nbsp;&nbsp;ユーザーの避ける一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="c8f3d-121">&nbsp;&nbsp;Gets the Avoid list for a user.</span></span>

<a id="ID4E2B"></a>


## <a name="see-also"></a><span data-ttu-id="c8f3d-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="c8f3d-122">See also</span></span>

<a id="ID4E4B"></a>


##### <a name="parent"></a><span data-ttu-id="c8f3d-123">Parent</span><span class="sxs-lookup"><span data-stu-id="c8f3d-123">Parent</span></span>

[<span data-ttu-id="c8f3d-124">プライバシー URI</span><span class="sxs-lookup"><span data-stu-id="c8f3d-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
