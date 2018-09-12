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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882496"
---
# <a name="usersowneridpeopleavoid"></a><span data-ttu-id="410ba-104">ユーザーが/users/{ownerId}/回避します。</span><span class="sxs-lookup"><span data-stu-id="410ba-104">/users/{ownerId}/people/avoid</span></span>
<span data-ttu-id="410ba-105">ユーザーの回避一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="410ba-105">Accesses the Avoid list for a user</span></span>

  * [<span data-ttu-id="410ba-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="410ba-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="410ba-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="410ba-107">URI parameters</span></span>

| <span data-ttu-id="410ba-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="410ba-108">Parameter</span></span>| <span data-ttu-id="410ba-109">型</span><span class="sxs-lookup"><span data-stu-id="410ba-109">Type</span></span>| <span data-ttu-id="410ba-110">説明</span><span class="sxs-lookup"><span data-stu-id="410ba-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="410ba-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="410ba-111">ownerId</span></span>| <span data-ttu-id="410ba-112">string</span><span class="sxs-lookup"><span data-stu-id="410ba-112">string</span></span>| <span data-ttu-id="410ba-113">必須。</span><span class="sxs-lookup"><span data-stu-id="410ba-113">Required.</span></span> <span data-ttu-id="410ba-114">そのリソースにアクセスしているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="410ba-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="410ba-115">指定できる値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="410ba-115">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="410ba-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="410ba-116">Must be the authenticated user.</span></span> <span data-ttu-id="410ba-117">値の例:<code>xuid(2603643534573581)</code>します。</span><span class="sxs-lookup"><span data-stu-id="410ba-117">Example value: <code>xuid(2603643534573581)</code>.</span></span> <span data-ttu-id="410ba-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="410ba-118">Maximum size: none.</span></span> |

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="410ba-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="410ba-119">Valid methods</span></span>

[<span data-ttu-id="410ba-120">取得する (/users/{ownerId}/ユーザー/回避)</span><span class="sxs-lookup"><span data-stu-id="410ba-120">GET (/users/{ownerId}/people/avoid)</span></span>](uri-privacyusersxuidpeopleavoidget.md)

<span data-ttu-id="410ba-121">&nbsp;&nbsp;ユーザーの回避一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="410ba-121">&nbsp;&nbsp;Gets the Avoid list for a user.</span></span>

<a id="ID4E2B"></a>


## <a name="see-also"></a><span data-ttu-id="410ba-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="410ba-122">See also</span></span>

<a id="ID4E4B"></a>


##### <a name="parent"></a><span data-ttu-id="410ba-123">Parent</span><span class="sxs-lookup"><span data-stu-id="410ba-123">Parent</span></span>

[<span data-ttu-id="410ba-124">プライバシー Uri</span><span class="sxs-lookup"><span data-stu-id="410ba-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
