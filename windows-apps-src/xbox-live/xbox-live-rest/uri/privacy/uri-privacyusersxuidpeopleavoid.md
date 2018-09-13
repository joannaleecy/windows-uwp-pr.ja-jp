---
title: ユーザーが/users/{ownerId}/回避します。
assetID: 13dc3a10-ed04-4600-3afb-aa95a4139a06
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoid.html
author: KevinAsgari
description: " ユーザーが/users/{ownerId}/回避します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 635f11677997523fe952de04b8398410efc503d2
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3963141"
---
# <a name="usersowneridpeopleavoid"></a><span data-ttu-id="03d5a-104">ユーザーが/users/{ownerId}/回避します。</span><span class="sxs-lookup"><span data-stu-id="03d5a-104">/users/{ownerId}/people/avoid</span></span>
<span data-ttu-id="03d5a-105">ユーザーの回避一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="03d5a-105">Accesses the Avoid list for a user</span></span>

  * [<span data-ttu-id="03d5a-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="03d5a-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="03d5a-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="03d5a-107">URI parameters</span></span>

| <span data-ttu-id="03d5a-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="03d5a-108">Parameter</span></span>| <span data-ttu-id="03d5a-109">型</span><span class="sxs-lookup"><span data-stu-id="03d5a-109">Type</span></span>| <span data-ttu-id="03d5a-110">説明</span><span class="sxs-lookup"><span data-stu-id="03d5a-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="03d5a-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="03d5a-111">ownerId</span></span>| <span data-ttu-id="03d5a-112">string</span><span class="sxs-lookup"><span data-stu-id="03d5a-112">string</span></span>| <span data-ttu-id="03d5a-113">必須。</span><span class="sxs-lookup"><span data-stu-id="03d5a-113">Required.</span></span> <span data-ttu-id="03d5a-114">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="03d5a-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="03d5a-115">可能な値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="03d5a-115">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="03d5a-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="03d5a-116">Must be the authenticated user.</span></span> <span data-ttu-id="03d5a-117">値の例:<code>xuid(2603643534573581)</code>します。</span><span class="sxs-lookup"><span data-stu-id="03d5a-117">Example value: <code>xuid(2603643534573581)</code>.</span></span> <span data-ttu-id="03d5a-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="03d5a-118">Maximum size: none.</span></span> |

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="03d5a-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="03d5a-119">Valid methods</span></span>

[<span data-ttu-id="03d5a-120">取得する (ユーザーが/users/{ownerId}/回避)</span><span class="sxs-lookup"><span data-stu-id="03d5a-120">GET (/users/{ownerId}/people/avoid)</span></span>](uri-privacyusersxuidpeopleavoidget.md)

<span data-ttu-id="03d5a-121">&nbsp;&nbsp;ユーザーの回避一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="03d5a-121">&nbsp;&nbsp;Gets the Avoid list for a user.</span></span>

<a id="ID4E2B"></a>


## <a name="see-also"></a><span data-ttu-id="03d5a-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="03d5a-122">See also</span></span>

<a id="ID4E4B"></a>


##### <a name="parent"></a><span data-ttu-id="03d5a-123">Parent</span><span class="sxs-lookup"><span data-stu-id="03d5a-123">Parent</span></span>

[<span data-ttu-id="03d5a-124">プライバシー Uri</span><span class="sxs-lookup"><span data-stu-id="03d5a-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
