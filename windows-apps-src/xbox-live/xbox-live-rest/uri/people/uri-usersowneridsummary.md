---
title: /users/{ownerId}/summary
assetID: 63f8ed09-532d-381e-59e6-2849893df5bf
permalink: en-us/docs/xboxlive/rest/uri-usersowneridsummary.html
description: " /users/{ownerId}/summary"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f8ad32fb2033c97a408ccb0f6cc6871b01caf5c5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617807"
---
# <a name="usersowneridsummary"></a><span data-ttu-id="fea91-104">/users/{ownerId}/summary</span><span class="sxs-lookup"><span data-stu-id="fea91-104">/users/{ownerId}/summary</span></span>
<span data-ttu-id="fea91-105">呼び出し元の観点から、所有者に関するデータの概要にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="fea91-105">Accesses summary data about the owner from the caller's perspective.</span></span>

  * [<span data-ttu-id="fea91-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fea91-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="fea91-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fea91-107">URI parameters</span></span>

| <span data-ttu-id="fea91-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fea91-108">Parameter</span></span>| <span data-ttu-id="fea91-109">種類</span><span class="sxs-lookup"><span data-stu-id="fea91-109">Type</span></span>| <span data-ttu-id="fea91-110">説明</span><span class="sxs-lookup"><span data-stu-id="fea91-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="fea91-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="fea91-111">ownerId</span></span>| <span data-ttu-id="fea91-112">string</span><span class="sxs-lookup"><span data-stu-id="fea91-112">string</span></span>| <span data-ttu-id="fea91-113">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="fea91-113">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="fea91-114">使用可能な値は、"me"、xuid({xuid})、または gt({gamertag}) です。</span><span class="sxs-lookup"><span data-stu-id="fea91-114">The possible values are "me", xuid({xuid}), or gt({gamertag}).</span></span> <span data-ttu-id="fea91-115">値の例: <code>me</code>、 <code>xuid(2603643534573581)</code>、 <code>gt(SomeGamertag)</code></span><span class="sxs-lookup"><span data-stu-id="fea91-115">Example values: <code>me</code>, <code>xuid(2603643534573581)</code>, <code>gt(SomeGamertag)</code></span></span>|

<a id="ID4ESB"></a>


## <a name="valid-methods"></a><span data-ttu-id="fea91-116">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="fea91-116">Valid methods</span></span>

[<span data-ttu-id="fea91-117">GET (/users/{ownerId}/summary)</span><span class="sxs-lookup"><span data-stu-id="fea91-117">GET (/users/{ownerId}/summary)</span></span>](uri-usersowneridsummaryget.md)

<span data-ttu-id="fea91-118">&nbsp;&nbsp;呼び出し元の観点から、所有者に関する概要データを取得します。</span><span class="sxs-lookup"><span data-stu-id="fea91-118">&nbsp;&nbsp;Gets summary data about the owner from the caller's perspective.</span></span>

<a id="ID4E3B"></a>


## <a name="see-also"></a><span data-ttu-id="fea91-119">関連項目</span><span class="sxs-lookup"><span data-stu-id="fea91-119">See also</span></span>

<a id="ID4E5B"></a>


##### <a name="parent"></a><span data-ttu-id="fea91-120">Parent</span><span class="sxs-lookup"><span data-stu-id="fea91-120">Parent</span></span>

[<span data-ttu-id="fea91-121">/users/{ownerId}/summary</span><span class="sxs-lookup"><span data-stu-id="fea91-121">/users/{ownerId}/summary</span></span>](uri-usersowneridsummaryget.md)
