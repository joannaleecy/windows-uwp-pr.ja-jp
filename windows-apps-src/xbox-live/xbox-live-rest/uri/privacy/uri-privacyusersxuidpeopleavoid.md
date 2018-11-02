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
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5920580"
---
# <a name="usersowneridpeopleavoid"></a><span data-ttu-id="846f8-104">/users/{ownerId}/people/avoid</span><span class="sxs-lookup"><span data-stu-id="846f8-104">/users/{ownerId}/people/avoid</span></span>
<span data-ttu-id="846f8-105">ユーザーの回避一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="846f8-105">Accesses the Avoid list for a user</span></span>

  * [<span data-ttu-id="846f8-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="846f8-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="846f8-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="846f8-107">URI parameters</span></span>

| <span data-ttu-id="846f8-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="846f8-108">Parameter</span></span>| <span data-ttu-id="846f8-109">型</span><span class="sxs-lookup"><span data-stu-id="846f8-109">Type</span></span>| <span data-ttu-id="846f8-110">説明</span><span class="sxs-lookup"><span data-stu-id="846f8-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="846f8-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="846f8-111">ownerId</span></span>| <span data-ttu-id="846f8-112">string</span><span class="sxs-lookup"><span data-stu-id="846f8-112">string</span></span>| <span data-ttu-id="846f8-113">必須。</span><span class="sxs-lookup"><span data-stu-id="846f8-113">Required.</span></span> <span data-ttu-id="846f8-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="846f8-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="846f8-115">設定可能な値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="846f8-115">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="846f8-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="846f8-116">Must be the authenticated user.</span></span> <span data-ttu-id="846f8-117">値の例:<code>xuid(2603643534573581)</code>します。</span><span class="sxs-lookup"><span data-stu-id="846f8-117">Example value: <code>xuid(2603643534573581)</code>.</span></span> <span data-ttu-id="846f8-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="846f8-118">Maximum size: none.</span></span> |

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="846f8-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="846f8-119">Valid methods</span></span>

[<span data-ttu-id="846f8-120">GET (/users/{ownerId}/people/avoid)</span><span class="sxs-lookup"><span data-stu-id="846f8-120">GET (/users/{ownerId}/people/avoid)</span></span>](uri-privacyusersxuidpeopleavoidget.md)

<span data-ttu-id="846f8-121">&nbsp;&nbsp;ユーザーの回避一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="846f8-121">&nbsp;&nbsp;Gets the Avoid list for a user.</span></span>

<a id="ID4E2B"></a>


## <a name="see-also"></a><span data-ttu-id="846f8-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="846f8-122">See also</span></span>

<a id="ID4E4B"></a>


##### <a name="parent"></a><span data-ttu-id="846f8-123">Parent</span><span class="sxs-lookup"><span data-stu-id="846f8-123">Parent</span></span>

[<span data-ttu-id="846f8-124">プライバシー URI</span><span class="sxs-lookup"><span data-stu-id="846f8-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
