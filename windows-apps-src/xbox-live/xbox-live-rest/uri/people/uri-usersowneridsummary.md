---
title: /users/{ownerId}/summary
assetID: 63f8ed09-532d-381e-59e6-2849893df5bf
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummary.html
author: KevinAsgari
description: " /users/{ownerId}/summary"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1cf5fc70d2f4b149f7a5c6dd20c5aaf22cafe2a7
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4174206"
---
# <a name="usersowneridsummary"></a><span data-ttu-id="719bf-104">/users/{ownerId}/summary</span><span class="sxs-lookup"><span data-stu-id="719bf-104">/users/{ownerId}/summary</span></span>
<span data-ttu-id="719bf-105">呼び出し元の観点から所有者に関する集計データをアクセスします。</span><span class="sxs-lookup"><span data-stu-id="719bf-105">Accesses summary data about the owner from the caller's perspective.</span></span>

  * [<span data-ttu-id="719bf-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="719bf-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="719bf-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="719bf-107">URI parameters</span></span>

| <span data-ttu-id="719bf-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="719bf-108">Parameter</span></span>| <span data-ttu-id="719bf-109">型</span><span class="sxs-lookup"><span data-stu-id="719bf-109">Type</span></span>| <span data-ttu-id="719bf-110">説明</span><span class="sxs-lookup"><span data-stu-id="719bf-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="719bf-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="719bf-111">ownerId</span></span>| <span data-ttu-id="719bf-112">string</span><span class="sxs-lookup"><span data-stu-id="719bf-112">string</span></span>| <span data-ttu-id="719bf-113">そのリソースにアクセスしているユーザーの識別子です。</span><span class="sxs-lookup"><span data-stu-id="719bf-113">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="719bf-114">設定可能な値は、"me"xuid({xuid})、または gt({gamertag}) されます。</span><span class="sxs-lookup"><span data-stu-id="719bf-114">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span> <span data-ttu-id="719bf-115">値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、</span><span class="sxs-lookup"><span data-stu-id="719bf-115">Example values: <code>me</code>, <code>xuid(2603643534573581)</code>,</span></span> <code>gt(SomeGamertag)</code>|

<a id="ID4ESB"></a>


## <a name="valid-methods"></a><span data-ttu-id="719bf-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="719bf-116">Valid methods</span></span>

[<span data-ttu-id="719bf-117">GET (/users/{ownerId}/summary)</span><span class="sxs-lookup"><span data-stu-id="719bf-117">GET (/users/{ownerId}/summary)</span></span>](uri-usersowneridsummaryget.md)

<span data-ttu-id="719bf-118">&nbsp;&nbsp;呼び出し元の観点から所有者に関する集計データを取得します。</span><span class="sxs-lookup"><span data-stu-id="719bf-118">&nbsp;&nbsp;Gets summary data about the owner from the caller's perspective.</span></span>

<a id="ID4E3B"></a>


## <a name="see-also"></a><span data-ttu-id="719bf-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="719bf-119">See also</span></span>

<a id="ID4E5B"></a>


##### <a name="parent"></a><span data-ttu-id="719bf-120">Parent</span><span class="sxs-lookup"><span data-stu-id="719bf-120">Parent</span></span>

[<span data-ttu-id="719bf-121">/users/{ownerId}/summary</span><span class="sxs-lookup"><span data-stu-id="719bf-121">/users/{ownerId}/summary</span></span>]()
