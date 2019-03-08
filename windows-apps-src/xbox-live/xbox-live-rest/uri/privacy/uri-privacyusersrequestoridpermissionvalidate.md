---
title: /users/{requestorId}/permission/validate
assetID: 400a9721-bf43-76df-4cd1-9f2ae6ca5035
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidate.html
description: " /users/{requestorId}/permission/validate"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4a062fd417bae37fd66c944e0e534ef7a50de5fa
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599367"
---
# <a name="usersrequestoridpermissionvalidate"></a><span data-ttu-id="dc76d-104">/users/{requestorId}/permission/validate</span><span class="sxs-lookup"><span data-stu-id="dc76d-104">/users/{requestorId}/permission/validate</span></span>
 
  * [<span data-ttu-id="dc76d-105">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="dc76d-105">URI parameters</span></span>](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="dc76d-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="dc76d-106">URI parameters</span></span>
 
| <span data-ttu-id="dc76d-107">パラメーター</span><span class="sxs-lookup"><span data-stu-id="dc76d-107">Parameter</span></span>| <span data-ttu-id="dc76d-108">種類</span><span class="sxs-lookup"><span data-stu-id="dc76d-108">Type</span></span>| <span data-ttu-id="dc76d-109">説明</span><span class="sxs-lookup"><span data-stu-id="dc76d-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="dc76d-110">requestorId</span><span class="sxs-lookup"><span data-stu-id="dc76d-110">requestorId</span></span>| <span data-ttu-id="dc76d-111">string</span><span class="sxs-lookup"><span data-stu-id="dc76d-111">string</span></span>| <span data-ttu-id="dc76d-112">必須。</span><span class="sxs-lookup"><span data-stu-id="dc76d-112">Required.</span></span> <span data-ttu-id="dc76d-113">アクションを実行して、ユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="dc76d-113">Identifier of the user performing the action.</span></span> <span data-ttu-id="dc76d-114">指定できる値は<code>xuid({xuid})</code>と<code>me</code>します。</span><span class="sxs-lookup"><span data-stu-id="dc76d-114">The possible values are <code>xuid({xuid})</code> and <code>me</code>.</span></span> <span data-ttu-id="dc76d-115">これには、ログイン ユーザーがあります。</span><span class="sxs-lookup"><span data-stu-id="dc76d-115">This must be a logged-in user.</span></span> <span data-ttu-id="dc76d-116">値の例:<code>xuid(0987654321)</code>します。</span><span class="sxs-lookup"><span data-stu-id="dc76d-116">Example value: <code>xuid(0987654321)</code>.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="dc76d-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="dc76d-117">Valid methods</span></span>

[<span data-ttu-id="dc76d-118">GET (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="dc76d-118">GET (/users/{requestorId}/permission/validate)</span></span>](uri-privacyusersrequestoridpermissionvalidateget.md)

<span data-ttu-id="dc76d-119">&nbsp;&nbsp;対象ユーザーと指定したアクションを実行するユーザーを許可するかどうかについてはいまたは no 応答を取得します。</span><span class="sxs-lookup"><span data-stu-id="dc76d-119">&nbsp;&nbsp;Gets a yes-or-no answer about whether the user is allowed to perform the specified action with a target user.</span></span>

[<span data-ttu-id="dc76d-120">POST (/users/{requestorId}/permission/validate)</span><span class="sxs-lookup"><span data-stu-id="dc76d-120">POST (/users/{requestorId}/permission/validate)</span></span>](uri-privacyusersrequestoridpermissionvalidatepost.md)

<span data-ttu-id="dc76d-121">&nbsp;&nbsp;対象ユーザーのセットで指定されたアクションを実行するユーザーを許可するかどうかについての回答をはいまたは no のセットを取得します。</span><span class="sxs-lookup"><span data-stu-id="dc76d-121">&nbsp;&nbsp;Gets a set of yes-or-no answers about whether the user is allowed to perform specified actions with a set of target users.</span></span>
 
<a id="ID4EAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="dc76d-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="dc76d-122">See also</span></span>
 
<a id="ID4ECC"></a>

   [<span data-ttu-id="dc76d-123">プライバシーの Uri</span><span class="sxs-lookup"><span data-stu-id="dc76d-123">Privacy URIs</span></span>](atoc-reference-privacyv2.md)

 [<span data-ttu-id="dc76d-124">PermissionId 列挙型</span><span class="sxs-lookup"><span data-stu-id="dc76d-124">PermissionId Enumeration</span></span>](../../enums/privacy-enum-permissionid.md)

   