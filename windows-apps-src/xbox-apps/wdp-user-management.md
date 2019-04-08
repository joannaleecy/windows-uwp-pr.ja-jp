---
title: Xbox Live テスト ユーザー管理 API のリファレンス
description: ユーザー管理 API にプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 70876ab6-8222-4940-b4fb-65b581a77d6a
ms.openlocfilehash: c934a88dd1825fb0111083d71eb25e477956d79c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627367"
---
#<a name="xbox-live-user-management"></a><span data-ttu-id="3aefe-104">Xbox Live ユーザー管理 #</span><span class="sxs-lookup"><span data-stu-id="3aefe-104">Xbox Live User Management#</span></span>

<span data-ttu-id="3aefe-105">**要求**</span><span class="sxs-lookup"><span data-stu-id="3aefe-105">**Request**</span></span>

<span data-ttu-id="3aefe-106">本体のユーザーの一覧を取得したり、一覧を更新したりできます。更新では、既存のユーザーの追加、削除、サインイン、サインアウト、または変更を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="3aefe-106">You can get the list of users on the console, or update the list--adding, removing, signing in, signing out, or modifying existing users.</span></span>

| <span data-ttu-id="3aefe-107">メソッド</span><span class="sxs-lookup"><span data-stu-id="3aefe-107">Method</span></span>        | <span data-ttu-id="3aefe-108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="3aefe-108">Request URI</span></span>     | 
| ------------- |-----------------|
| <span data-ttu-id="3aefe-109">GET</span><span class="sxs-lookup"><span data-stu-id="3aefe-109">GET</span></span>           | <span data-ttu-id="3aefe-110">/ext/user</span><span class="sxs-lookup"><span data-stu-id="3aefe-110">/ext/user</span></span> |
| <span data-ttu-id="3aefe-111">PUT</span><span class="sxs-lookup"><span data-stu-id="3aefe-111">PUT</span></span>           | <span data-ttu-id="3aefe-112">/ext/user</span><span class="sxs-lookup"><span data-stu-id="3aefe-112">/ext/user</span></span> |
<br>

<span data-ttu-id="3aefe-113">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="3aefe-113">**URI parameters**</span></span>

* <span data-ttu-id="3aefe-114">なし</span><span class="sxs-lookup"><span data-stu-id="3aefe-114">None</span></span>

<span data-ttu-id="3aefe-115">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="3aefe-115">**Request headers**</span></span>

* <span data-ttu-id="3aefe-116">なし</span><span class="sxs-lookup"><span data-stu-id="3aefe-116">None</span></span>

<span data-ttu-id="3aefe-117">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="3aefe-117">**Request body**</span></span>

<span data-ttu-id="3aefe-118">PUT メソッドの呼び出しには、次の構造の JSON 配列を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3aefe-118">Calls to PUT should include a JSON array with the following structure:</span></span>

* <span data-ttu-id="3aefe-119">Users</span><span class="sxs-lookup"><span data-stu-id="3aefe-119">Users</span></span>
  * <span data-ttu-id="3aefe-120">AutoSignIn (省略可能): EmailAddress や UserId で指定されたアカウントの自動サインインを無効または有効にするブール値。</span><span class="sxs-lookup"><span data-stu-id="3aefe-120">AutoSignIn (optional) : bool disabling or enabling automatic signin for the account specified by EmailAddress or UserId.</span></span>
  * <span data-ttu-id="3aefe-121">EmailAddress (省略可能 - スポンサーが付いたユーザーをサインインしない限り、ユーザー Id は指定しないかどうかを指定する必要があります)。電子メール アドレスを変更/追加/削除するユーザーを指定します。</span><span class="sxs-lookup"><span data-stu-id="3aefe-121">EmailAddress (optional - must be provided if UserId is not provided unless signing in a sponsored user) : Email address specifying the user to modify/add/delete.</span></span>
  * <span data-ttu-id="3aefe-122">パスワード (省略可能 - ユーザーがコンソールに現在がないかどうかを指定する必要があります)。コンソールに新しいユーザーを追加するために使用するパスワード。</span><span class="sxs-lookup"><span data-stu-id="3aefe-122">Password (optional - must be provided if the user isn't currently on the console) : Password used for adding a new user to the console.</span></span>
  * <span data-ttu-id="3aefe-123">SignedIn (省略可能): 指定されたアカウントでサインインまたはサインアウトする必要があるかどうかを指定するブール値。</span><span class="sxs-lookup"><span data-stu-id="3aefe-123">SignedIn (optional) : bool specifying whether the provided account should be signed in or out.</span></span>
  * <span data-ttu-id="3aefe-124">ユーザー Id (省略可能 - EmailAddress が付属しており、ユーザーをサインインしない限り、指定しないかどうかを指定する必要があります)。ユーザー Id の変更/追加/削除するユーザーを指定します。</span><span class="sxs-lookup"><span data-stu-id="3aefe-124">UserId (optional - must be provided if EmailAddress is not provided unless signing in a sponsored user) : UserId specifying the user to modify/add/delete.</span></span>
  * <span data-ttu-id="3aefe-125">SponsoredUser (省略可能): スポンサー ユーザーを追加するかどうかを指定するブール値。</span><span class="sxs-lookup"><span data-stu-id="3aefe-125">SponsoredUser (optional) : bool specifying whether to add a sponsored user.</span></span>
  * <span data-ttu-id="3aefe-126">(省略可能) の削除: コンソールからこのユーザーの削除を指定するブール値</span><span class="sxs-lookup"><span data-stu-id="3aefe-126">Delete (optional) : bool specifying to delete this user from the console</span></span>

###<a name="response"></a><span data-ttu-id="3aefe-127">応答 ###</span><span class="sxs-lookup"><span data-stu-id="3aefe-127">Response###</span></span>

<span data-ttu-id="3aefe-128">**応答本文**</span><span class="sxs-lookup"><span data-stu-id="3aefe-128">**Response body**</span></span>

<span data-ttu-id="3aefe-129">GET メソッドの呼び出しでは、次のプロパティが指定された JSON 配列を返します。</span><span class="sxs-lookup"><span data-stu-id="3aefe-129">Calls to GET will return a JSON array with the following properties:</span></span>

* <span data-ttu-id="3aefe-130">Users</span><span class="sxs-lookup"><span data-stu-id="3aefe-130">Users</span></span>
  * <span data-ttu-id="3aefe-131">AutoSignIn (省略可能)</span><span class="sxs-lookup"><span data-stu-id="3aefe-131">AutoSignIn (optional)</span></span>
  * <span data-ttu-id="3aefe-132">EmailAddress (省略可能)</span><span class="sxs-lookup"><span data-stu-id="3aefe-132">EmailAddress (optional)</span></span>
  * <span data-ttu-id="3aefe-133">Gamertag</span><span class="sxs-lookup"><span data-stu-id="3aefe-133">Gamertag</span></span>
  * <span data-ttu-id="3aefe-134">SignedIn</span><span class="sxs-lookup"><span data-stu-id="3aefe-134">SignedIn</span></span>
  * <span data-ttu-id="3aefe-135">UserId</span><span class="sxs-lookup"><span data-stu-id="3aefe-135">UserId</span></span>
  * <span data-ttu-id="3aefe-136">XboxUserId</span><span class="sxs-lookup"><span data-stu-id="3aefe-136">XboxUserId</span></span>
  * <span data-ttu-id="3aefe-137">SponsoredUser (省略可能)</span><span class="sxs-lookup"><span data-stu-id="3aefe-137">SponsoredUser (optional)</span></span>
  
<span data-ttu-id="3aefe-138">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="3aefe-138">**Status code**</span></span>

<span data-ttu-id="3aefe-139">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3aefe-139">This API has the following expected status codes.</span></span>

| <span data-ttu-id="3aefe-140">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="3aefe-140">HTTP status code</span></span>   | <span data-ttu-id="3aefe-141">説明</span><span class="sxs-lookup"><span data-stu-id="3aefe-141">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="3aefe-142">200</span><span class="sxs-lookup"><span data-stu-id="3aefe-142">200</span></span>                | <span data-ttu-id="3aefe-143">GET メソッドの呼び出しが成功し、ユーザーの JSON 配列が応答本文で返されました</span><span class="sxs-lookup"><span data-stu-id="3aefe-143">Call to GET was successful and JSON array of users returned in the response body</span></span> |
| <span data-ttu-id="3aefe-144">204</span><span class="sxs-lookup"><span data-stu-id="3aefe-144">204</span></span>                | <span data-ttu-id="3aefe-145">PUT メソッドの呼び出しが成功し、本体のユーザーが更新されました</span><span class="sxs-lookup"><span data-stu-id="3aefe-145">Call to PUT was successful and the users on the console have been updated</span></span> |
| <span data-ttu-id="3aefe-146">4XX</span><span class="sxs-lookup"><span data-stu-id="3aefe-146">4XX</span></span>                | <span data-ttu-id="3aefe-147">無効な要求データまたは形式を示すさまざまなエラー</span><span class="sxs-lookup"><span data-stu-id="3aefe-147">Various errors for invalid request data or format</span></span> |
| <span data-ttu-id="3aefe-148">5XX</span><span class="sxs-lookup"><span data-stu-id="3aefe-148">5XX</span></span>                | <span data-ttu-id="3aefe-149">予期しないエラーのエラー コード</span><span class="sxs-lookup"><span data-stu-id="3aefe-149">Error codes for unexpected failures</span></span> |
<br>


