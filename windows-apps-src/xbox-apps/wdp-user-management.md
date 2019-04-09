---
title: Xbox Live テスト ユーザー管理 API のリファレンス
description: ユーザー管理 API にプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 70876ab6-8222-4940-b4fb-65b581a77d6a
ms.openlocfilehash: 71c47767cf026b962f682fb30ca93758dbd5e227
ms.sourcegitcommit: bad7ed6def79acbb4569de5a92c0717364e771d9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59244078"
---
#<a name="xbox-live-user-management"></a><span data-ttu-id="37030-104">Xbox Live ユーザー管理 #</span><span class="sxs-lookup"><span data-stu-id="37030-104">Xbox Live User Management#</span></span>

## <a name="request"></a><span data-ttu-id="37030-105">要求</span><span class="sxs-lookup"><span data-stu-id="37030-105">Request</span></span>

<span data-ttu-id="37030-106">本体のユーザーの一覧を取得したり、一覧を更新したりできます。更新では、既存のユーザーの追加、削除、サインイン、サインアウト、または変更を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="37030-106">You can get the list of users on the console, or update the list--adding, removing, signing in, signing out, or modifying existing users.</span></span>

| <span data-ttu-id="37030-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="37030-107">Method</span></span>        | <span data-ttu-id="37030-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="37030-108">Request URI</span></span>     | 
| ------------- |-----------------|
| <span data-ttu-id="37030-109">GET</span><span class="sxs-lookup"><span data-stu-id="37030-109">GET</span></span>           | <span data-ttu-id="37030-110">/ext/user</span><span class="sxs-lookup"><span data-stu-id="37030-110">/ext/user</span></span> |
| <span data-ttu-id="37030-111">PUT</span><span class="sxs-lookup"><span data-stu-id="37030-111">PUT</span></span>           | <span data-ttu-id="37030-112">/ext/user</span><span class="sxs-lookup"><span data-stu-id="37030-112">/ext/user</span></span> |


**<span data-ttu-id="37030-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="37030-113">URI parameters</span></span>**

* <span data-ttu-id="37030-114">なし</span><span class="sxs-lookup"><span data-stu-id="37030-114">None</span></span>

**<span data-ttu-id="37030-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="37030-115">Request headers</span></span>**

* <span data-ttu-id="37030-116">なし</span><span class="sxs-lookup"><span data-stu-id="37030-116">None</span></span>

**<span data-ttu-id="37030-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="37030-117">Request body</span></span>**

<span data-ttu-id="37030-118">PUT メソッドの呼び出しには、次の構造の JSON 配列を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="37030-118">Calls to PUT should include a JSON array with the following structure:</span></span>

* <span data-ttu-id="37030-119">Users</span><span class="sxs-lookup"><span data-stu-id="37030-119">Users</span></span>
  * <span data-ttu-id="37030-120">AutoSignIn (省略可能): EmailAddress や UserId で指定されたアカウントの自動サインインを無効または有効にするブール値。</span><span class="sxs-lookup"><span data-stu-id="37030-120">AutoSignIn (optional) : bool disabling or enabling automatic signin for the account specified by EmailAddress or UserId.</span></span>
  * <span data-ttu-id="37030-121">EmailAddress (省略可能 - スポンサーが付いたユーザーをサインインしない限り、ユーザー Id は指定しないかどうかを指定する必要があります)。電子メール アドレスを変更/追加/削除するユーザーを指定します。</span><span class="sxs-lookup"><span data-stu-id="37030-121">EmailAddress (optional - must be provided if UserId is not provided unless signing in a sponsored user) : Email address specifying the user to modify/add/delete.</span></span>
  * <span data-ttu-id="37030-122">パスワード (省略可能 - ユーザーがコンソールに現在がないかどうかを指定する必要があります)。コンソールに新しいユーザーを追加するために使用するパスワード。</span><span class="sxs-lookup"><span data-stu-id="37030-122">Password (optional - must be provided if the user isn't currently on the console) : Password used for adding a new user to the console.</span></span>
  * <span data-ttu-id="37030-123">SignedIn (省略可能): 指定されたアカウントでサインインまたはサインアウトする必要があるかどうかを指定するブール値。</span><span class="sxs-lookup"><span data-stu-id="37030-123">SignedIn (optional) : bool specifying whether the provided account should be signed in or out.</span></span>
  * <span data-ttu-id="37030-124">ユーザー Id (省略可能 - EmailAddress が付属しており、ユーザーをサインインしない限り、指定しないかどうかを指定する必要があります)。ユーザー Id の変更/追加/削除するユーザーを指定します。</span><span class="sxs-lookup"><span data-stu-id="37030-124">UserId (optional - must be provided if EmailAddress is not provided unless signing in a sponsored user) : UserId specifying the user to modify/add/delete.</span></span>
  * <span data-ttu-id="37030-125">SponsoredUser (省略可能): スポンサー ユーザーを追加するかどうかを指定するブール値。</span><span class="sxs-lookup"><span data-stu-id="37030-125">SponsoredUser (optional) : bool specifying whether to add a sponsored user.</span></span>
  * <span data-ttu-id="37030-126">(省略可能) の削除: コンソールからこのユーザーの削除を指定するブール値</span><span class="sxs-lookup"><span data-stu-id="37030-126">Delete (optional) : bool specifying to delete this user from the console</span></span>

## <a name="response"></a><span data-ttu-id="37030-127">応答</span><span class="sxs-lookup"><span data-stu-id="37030-127">Response</span></span>

**<span data-ttu-id="37030-128">応答本文</span><span class="sxs-lookup"><span data-stu-id="37030-128">Response body</span></span>**

<span data-ttu-id="37030-129">GET メソッドの呼び出しでは、次のプロパティが指定された JSON 配列を返します。</span><span class="sxs-lookup"><span data-stu-id="37030-129">Calls to GET will return a JSON array with the following properties:</span></span>

* <span data-ttu-id="37030-130">Users</span><span class="sxs-lookup"><span data-stu-id="37030-130">Users</span></span>
  * <span data-ttu-id="37030-131">AutoSignIn (省略可能)</span><span class="sxs-lookup"><span data-stu-id="37030-131">AutoSignIn (optional)</span></span>
  * <span data-ttu-id="37030-132">EmailAddress (省略可能)</span><span class="sxs-lookup"><span data-stu-id="37030-132">EmailAddress (optional)</span></span>
  * <span data-ttu-id="37030-133">Gamertag</span><span class="sxs-lookup"><span data-stu-id="37030-133">Gamertag</span></span>
  * <span data-ttu-id="37030-134">SignedIn</span><span class="sxs-lookup"><span data-stu-id="37030-134">SignedIn</span></span>
  * <span data-ttu-id="37030-135">UserId</span><span class="sxs-lookup"><span data-stu-id="37030-135">UserId</span></span>
  * <span data-ttu-id="37030-136">XboxUserId</span><span class="sxs-lookup"><span data-stu-id="37030-136">XboxUserId</span></span>
  * <span data-ttu-id="37030-137">SponsoredUser (省略可能)</span><span class="sxs-lookup"><span data-stu-id="37030-137">SponsoredUser (optional)</span></span>
  
**<span data-ttu-id="37030-138">状態コード</span><span class="sxs-lookup"><span data-stu-id="37030-138">Status code</span></span>**

<span data-ttu-id="37030-139">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="37030-139">This API has the following expected status codes.</span></span>

| <span data-ttu-id="37030-140">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="37030-140">HTTP status code</span></span>   | <span data-ttu-id="37030-141">説明</span><span class="sxs-lookup"><span data-stu-id="37030-141">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="37030-142">200</span><span class="sxs-lookup"><span data-stu-id="37030-142">200</span></span>                | <span data-ttu-id="37030-143">GET メソッドの呼び出しが成功し、ユーザーの JSON 配列が応答本文で返されました</span><span class="sxs-lookup"><span data-stu-id="37030-143">Call to GET was successful and JSON array of users returned in the response body</span></span> |
| <span data-ttu-id="37030-144">204</span><span class="sxs-lookup"><span data-stu-id="37030-144">204</span></span>                | <span data-ttu-id="37030-145">PUT メソッドの呼び出しが成功し、本体のユーザーが更新されました</span><span class="sxs-lookup"><span data-stu-id="37030-145">Call to PUT was successful and the users on the console have been updated</span></span> |
| <span data-ttu-id="37030-146">4XX</span><span class="sxs-lookup"><span data-stu-id="37030-146">4XX</span></span>                | <span data-ttu-id="37030-147">無効な要求データまたは形式を示すさまざまなエラー</span><span class="sxs-lookup"><span data-stu-id="37030-147">Various errors for invalid request data or format</span></span> |
| <span data-ttu-id="37030-148">5XX</span><span class="sxs-lookup"><span data-stu-id="37030-148">5XX</span></span>                | <span data-ttu-id="37030-149">予期しないエラーのエラー コード</span><span class="sxs-lookup"><span data-stu-id="37030-149">Error codes for unexpected failures</span></span> |
