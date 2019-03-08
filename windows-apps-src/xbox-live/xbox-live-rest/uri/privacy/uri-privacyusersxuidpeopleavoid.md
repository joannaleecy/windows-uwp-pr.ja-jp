---
title: /users/{ownerId}/people/avoid
assetID: 13dc3a10-ed04-4600-3afb-aa95a4139a06
permalink: en-us/docs/xboxlive/rest/uri-privacyusersxuidpeopleavoid.html
description: " /users/{ownerId}/people/avoid"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d0ae745f825d6afda87167859b12bcc52b899f18
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607487"
---
# <a name="usersowneridpeopleavoid"></a><span data-ttu-id="96171-104">/users/{ownerId}/people/avoid</span><span class="sxs-lookup"><span data-stu-id="96171-104">/users/{ownerId}/people/avoid</span></span>
<span data-ttu-id="96171-105">ユーザーの避け一覧にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="96171-105">Accesses the Avoid list for a user</span></span>

  * [<span data-ttu-id="96171-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="96171-106">URI parameters</span></span>](#ID4EQ)

<a id="ID4EQ"></a>


## <a name="uri-parameters"></a><span data-ttu-id="96171-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="96171-107">URI parameters</span></span>

| <span data-ttu-id="96171-108">パラメーター</span><span class="sxs-lookup"><span data-stu-id="96171-108">Parameter</span></span>| <span data-ttu-id="96171-109">種類</span><span class="sxs-lookup"><span data-stu-id="96171-109">Type</span></span>| <span data-ttu-id="96171-110">説明</span><span class="sxs-lookup"><span data-stu-id="96171-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="96171-111">ownerId</span><span class="sxs-lookup"><span data-stu-id="96171-111">ownerId</span></span>| <span data-ttu-id="96171-112">string</span><span class="sxs-lookup"><span data-stu-id="96171-112">string</span></span>| <span data-ttu-id="96171-113">必須。</span><span class="sxs-lookup"><span data-stu-id="96171-113">Required.</span></span> <span data-ttu-id="96171-114">リソースがアクセスされているユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="96171-114">Identifier of the user whose resource is being accessed.</span></span> <span data-ttu-id="96171-115">指定できる値は<code>xuid({xuid})</code>します。</span><span class="sxs-lookup"><span data-stu-id="96171-115">The possible values are <code>xuid({xuid})</code>.</span></span> <span data-ttu-id="96171-116">認証されたユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="96171-116">Must be the authenticated user.</span></span> <span data-ttu-id="96171-117">値の例:<code>xuid(2603643534573581)</code>します。</span><span class="sxs-lookup"><span data-stu-id="96171-117">Example value: <code>xuid(2603643534573581)</code>.</span></span> <span data-ttu-id="96171-118">最大サイズ: なし。</span><span class="sxs-lookup"><span data-stu-id="96171-118">Maximum size: none.</span></span> |

<a id="ID4ERB"></a>


## <a name="valid-methods"></a><span data-ttu-id="96171-119">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="96171-119">Valid methods</span></span>

[<span data-ttu-id="96171-120">GET (/users/{ownerId}/people/avoid)</span><span class="sxs-lookup"><span data-stu-id="96171-120">GET (/users/{ownerId}/people/avoid)</span></span>](uri-privacyusersxuidpeopleavoidget.md)

<span data-ttu-id="96171-121">&nbsp;&nbsp;ユーザーの避け一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="96171-121">&nbsp;&nbsp;Gets the Avoid list for a user.</span></span>

<a id="ID4E2B"></a>


## <a name="see-also"></a><span data-ttu-id="96171-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="96171-122">See also</span></span>

<a id="ID4E4B"></a>


##### <a name="parent"></a><span data-ttu-id="96171-123">Parent</span><span class="sxs-lookup"><span data-stu-id="96171-123">Parent</span></span>

[<span data-ttu-id="96171-124">プライバシーの Uri</span><span class="sxs-lookup"><span data-stu-id="96171-124">Privacy URIs</span></span>](atoc-reference-privacyv2.md)
