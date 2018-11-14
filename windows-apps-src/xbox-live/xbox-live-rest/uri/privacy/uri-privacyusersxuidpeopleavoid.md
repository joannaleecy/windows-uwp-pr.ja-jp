---
title: /users/{ownerId}/people/avoid
assetID: 13dc3a10-ed04-4600-3afb-aa95a4139a06
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoid.html
author: KevinAsgari
description: " /users/{ownerId}/people/avoid"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3f4e7523790f527cc8c5816a01dd10ae92112af8
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6254222"
---
# <a name="usersowneridpeopleavoid"></a><span data-ttu-id="68005-104">/users/{ownerId}/people/avoid</span><span class="sxs-lookup"><span data-stu-id="68005-104">/users/{ownerId}/people/avoid</span></span>
<span data-ttu-id="68005-105">ユーザーの回避一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="68005-105">Accesses the Avoid list for a user</span></span>

  * [<span data-ttu-id="68005-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="68005-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="68005-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="68005-107">URI parameters</span></span>

| <span data-ttu-id="68005-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="68005-108">Parameter</span></span>| <span data-ttu-id="68005-109">型</span><span class="sxs-lookup"><span data-stu-id="68005-109">Type</span></span>| <span data-ttu-id="68005-110">説明</span><span class="sxs-lookup"><span data-stu-id="68005-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="68005-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="68005-111">ownerId</span></span>| <span data-ttu-id="68005-112">string</span><span class="sxs-lookup"><span data-stu-id="68005-112">string</span></span>| <span data-ttu-id="68005-113">必須。</span><span class="sxs-lookup"><span data-stu-id="68005-113">Required.</span></span> <span data-ttu-id="68005-114">そのリソースにアクセスしているユーザーの id。</span><span class="sxs-lookup"><span data-stu-id="68005-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="68005-115">可能な値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="68005-115">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="68005-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="68005-116">Must be the authenticated user.</span></span> <span data-ttu-id="68005-117">値の例:<code>xuid(2603643534573581)</code>します。</span><span class="sxs-lookup"><span data-stu-id="68005-117">Example value: <code>xuid(2603643534573581)</code>.</span></span> <span data-ttu-id="68005-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="68005-118">Maximum size: none.</span></span> |

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="68005-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="68005-119">Valid methods</span></span>

[<span data-ttu-id="68005-120">GET (/users/{ownerId}/people/avoid)</span><span class="sxs-lookup"><span data-stu-id="68005-120">GET (/users/{ownerId}/people/avoid)</span></span>](uri-privacyusersxuidpeopleavoidget.md)

<span data-ttu-id="68005-121">&nbsp;&nbsp;ユーザーの回避一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="68005-121">&nbsp;&nbsp;Gets the Avoid list for a user.</span></span>

<a id="ID4E2B"></a>


## <a name="see-also"></a><span data-ttu-id="68005-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="68005-122">See also</span></span>

<a id="ID4E4B"></a>


##### <a name="parent"></a><span data-ttu-id="68005-123">Parent</span><span class="sxs-lookup"><span data-stu-id="68005-123">Parent</span></span>

[<span data-ttu-id="68005-124">プライバシー URI</span><span class="sxs-lookup"><span data-stu-id="68005-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
