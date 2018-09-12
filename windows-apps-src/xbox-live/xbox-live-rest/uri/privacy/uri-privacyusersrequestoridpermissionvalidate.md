---
title: /users/{requestorId}/アクセス許可/検証します。
assetID: 400a9721-bf43-76df-4cd1-9f2ae6ca5035
permalink: en-us/docs/xboxlive/rest/uri-privacyusersrequestoridpermissionvalidate.html
author: KevinAsgari
description: " /users/{requestorId}/アクセス許可/検証します。"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: faa0325a8540e1e3df9674a4acab2ab33e93dceb
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881618"
---
# <a name="usersrequestoridpermissionvalidate"></a><span data-ttu-id="a7ec1-104">/users/{requestorId}/アクセス許可/検証します。</span><span class="sxs-lookup"><span data-stu-id="a7ec1-104">/users/{requestorId}/permission/validate</span></span>
 
  * [<span data-ttu-id="a7ec1-105">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7ec1-105">URI parameters</span></span>](#ID4EQ)
 
<a id="ID4EQ"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a7ec1-106">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7ec1-106">URI parameters</span></span>
 
| <span data-ttu-id="a7ec1-107">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7ec1-107">Parameter</span></span>| <span data-ttu-id="a7ec1-108">型</span><span class="sxs-lookup"><span data-stu-id="a7ec1-108">Type</span></span>| <span data-ttu-id="a7ec1-109">説明</span><span class="sxs-lookup"><span data-stu-id="a7ec1-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a7ec1-110">requestorId</span><span class="sxs-lookup"><span data-stu-id="a7ec1-110">requestorId</span></span>| <span data-ttu-id="a7ec1-111">string</span><span class="sxs-lookup"><span data-stu-id="a7ec1-111">string</span></span>| <span data-ttu-id="a7ec1-112">必須。</span><span class="sxs-lookup"><span data-stu-id="a7ec1-112">Required.</span></span> <span data-ttu-id="a7ec1-113">アクションを実行するユーザーの識別子。</span><span class="sxs-lookup"><span data-stu-id="a7ec1-113">Identifier of the user performing the action.</span></span> <span data-ttu-id="a7ec1-114">指定できる値は<code>xuid({xuid})</code>と<code>me</code>します。</span><span class="sxs-lookup"><span data-stu-id="a7ec1-114">The possible values are <code>xuid({xuid})</code> and <code>me</code>.</span></span> <span data-ttu-id="a7ec1-115">これには、ログインしているユーザーがあります。</span><span class="sxs-lookup"><span data-stu-id="a7ec1-115">This must be a logged-in user.</span></span> <span data-ttu-id="a7ec1-116">値の例:<code>xuid(0987654321)</code>します。</span><span class="sxs-lookup"><span data-stu-id="a7ec1-116">Example value: <code>xuid(0987654321)</code>.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="valid-methods"></a><span data-ttu-id="a7ec1-117">有効なメソッド</span><span class="sxs-lookup"><span data-stu-id="a7ec1-117">Valid methods</span></span>

[<span data-ttu-id="a7ec1-118">取得する (/users/{requestorId}/アクセス許可/検証)</span><span class="sxs-lookup"><span data-stu-id="a7ec1-118">GET (/users/{requestorId}/permission/validate)</span></span>](uri-privacyusersrequestoridpermissionvalidateget.md)

<span data-ttu-id="a7ec1-119">&nbsp;&nbsp;ユーザーをターゲット ユーザーで指定された操作を実行できるかどうかに関するはいまたは no 応答を取得します。</span><span class="sxs-lookup"><span data-stu-id="a7ec1-119">&nbsp;&nbsp;Gets a yes-or-no answer about whether the user is allowed to perform the specified action with a target user.</span></span>

[<span data-ttu-id="a7ec1-120">POST (/users/{requestorId}/アクセス許可/検証)</span><span class="sxs-lookup"><span data-stu-id="a7ec1-120">POST (/users/{requestorId}/permission/validate)</span></span>](uri-privacyusersrequestoridpermissionvalidatepost.md)

<span data-ttu-id="a7ec1-121">&nbsp;&nbsp;一連のユーザーをターゲット ユーザーのセットを指定した操作を実行できるかどうかに関するはいまたは no 回答を取得します。</span><span class="sxs-lookup"><span data-stu-id="a7ec1-121">&nbsp;&nbsp;Gets a set of yes-or-no answers about whether the user is allowed to perform specified actions with a set of target users.</span></span>
 
<a id="ID4EAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="a7ec1-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="a7ec1-122">See also</span></span>
 
<a id="ID4ECC"></a>

   [<span data-ttu-id="a7ec1-123">プライバシー Uri</span><span class="sxs-lookup"><span data-stu-id="a7ec1-123">Privacy URIs</span></span>](atoc-reference-privacyv2.md)

 [<span data-ttu-id="a7ec1-124">PermissionId 列挙</span><span class="sxs-lookup"><span data-stu-id="a7ec1-124">PermissionId Enumeration</span></span>](../../enums/privacy-enum-permissionid.md)

   