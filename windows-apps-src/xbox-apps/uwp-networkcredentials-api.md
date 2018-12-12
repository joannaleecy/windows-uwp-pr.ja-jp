---
title: Device Portal ネットワーク資格情報 API リファレンス
description: 追加、削除、またはネットワーク資格情報をプログラムで更新する方法について説明します。
ms.localizationpriority: medium
ms.topic: article
ms.date: 02/08/2017
ms.openlocfilehash: ac30d8db830c51ee40653feb49b443ed44502617
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8934687"
---
# <a name="network-credentials-api-reference"></a><span data-ttu-id="b753a-103">ネットワーク資格情報 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="b753a-103">Network Credentials API reference</span></span>
<span data-ttu-id="b753a-104">追加、削除、またはこの REST API を使用して、開発機で保存されているネットワーク資格情報を更新することができます。</span><span class="sxs-lookup"><span data-stu-id="b753a-104">You can add, remove, or update stored network credentials on your devkit using this REST API.</span></span>

## <a name="get-existing-credentials"></a><span data-ttu-id="b753a-105">既存の資格情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="b753a-105">Get existing credentials</span></span>

**<span data-ttu-id="b753a-106">要求</span><span class="sxs-lookup"><span data-stu-id="b753a-106">Request</span></span>**

<span data-ttu-id="b753a-107">そのネットワーク共有の資格情報を持っているユーザーのユーザー名と共に保存されている共有の一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="b753a-107">You can get a list of the stored shares along with the username of the user who has credentials for that network share.</span></span>

<span data-ttu-id="b753a-108">メソッド</span><span class="sxs-lookup"><span data-stu-id="b753a-108">Method</span></span>      | <span data-ttu-id="b753a-109">要求 URI</span><span class="sxs-lookup"><span data-stu-id="b753a-109">Request URI</span></span>
:------     | :-----
<span data-ttu-id="b753a-110">GET</span><span class="sxs-lookup"><span data-stu-id="b753a-110">GET</span></span> | <span data-ttu-id="b753a-111">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="b753a-111">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="b753a-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b753a-112">URI parameters</span></span>**

- <span data-ttu-id="b753a-113">なし</span><span class="sxs-lookup"><span data-stu-id="b753a-113">None</span></span>

**<span data-ttu-id="b753a-114">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b753a-114">Request headers</span></span>**

- <span data-ttu-id="b753a-115">なし</span><span class="sxs-lookup"><span data-stu-id="b753a-115">None</span></span>

**<span data-ttu-id="b753a-116">要求本文</span><span class="sxs-lookup"><span data-stu-id="b753a-116">Request body</span></span>**   

- <span data-ttu-id="b753a-117">なし</span><span class="sxs-lookup"><span data-stu-id="b753a-117">None</span></span>

**<span data-ttu-id="b753a-118">応答</span><span class="sxs-lookup"><span data-stu-id="b753a-118">Response</span></span>**   

- <span data-ttu-id="b753a-119">次の形式の JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="b753a-119">JSON array in the following format:</span></span>
* <span data-ttu-id="b753a-120">資格情報</span><span class="sxs-lookup"><span data-stu-id="b753a-120">Credentials</span></span>
  * <span data-ttu-id="b753a-121">ネットワーク パスのネットワーク共有へのパス。</span><span class="sxs-lookup"><span data-stu-id="b753a-121">NetworkPath - The path to the network share.</span></span>
  * <span data-ttu-id="b753a-122">ユーザー名の資格情報を保存しているユーザー名。</span><span class="sxs-lookup"><span data-stu-id="b753a-122">Username - The username which has stored credentials.</span></span>

**<span data-ttu-id="b753a-123">状態コード</span><span class="sxs-lookup"><span data-stu-id="b753a-123">Status code</span></span>**

<span data-ttu-id="b753a-124">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b753a-124">This API has the following expected status codes.</span></span>

<span data-ttu-id="b753a-125">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="b753a-125">HTTP status code</span></span>      | <span data-ttu-id="b753a-126">説明</span><span class="sxs-lookup"><span data-stu-id="b753a-126">Description</span></span>
:------     | :-----
<span data-ttu-id="b753a-127">200</span><span class="sxs-lookup"><span data-stu-id="b753a-127">200</span></span> | <span data-ttu-id="b753a-128">成功</span><span class="sxs-lookup"><span data-stu-id="b753a-128">Success</span></span>
<span data-ttu-id="b753a-129">4XX</span><span class="sxs-lookup"><span data-stu-id="b753a-129">4XX</span></span> | <span data-ttu-id="b753a-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b753a-130">Error codes</span></span>
<span data-ttu-id="b753a-131">5XX</span><span class="sxs-lookup"><span data-stu-id="b753a-131">5XX</span></span> | <span data-ttu-id="b753a-132">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b753a-132">Error codes</span></span>

## <a name="add-or-update-stored-credentials-for-a-user"></a><span data-ttu-id="b753a-133">追加またはユーザーの資格情報を更新します。</span><span class="sxs-lookup"><span data-stu-id="b753a-133">Add or update stored credentials for a user</span></span>

**<span data-ttu-id="b753a-134">要求</span><span class="sxs-lookup"><span data-stu-id="b753a-134">Request</span></span>**

<span data-ttu-id="b753a-135">メソッド</span><span class="sxs-lookup"><span data-stu-id="b753a-135">Method</span></span>      | <span data-ttu-id="b753a-136">要求 URI</span><span class="sxs-lookup"><span data-stu-id="b753a-136">Request URI</span></span>
:------     | :-----
<span data-ttu-id="b753a-137">POST</span><span class="sxs-lookup"><span data-stu-id="b753a-137">POST</span></span> | <span data-ttu-id="b753a-138">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="b753a-138">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="b753a-139">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b753a-139">URI parameters</span></span>**

<span data-ttu-id="b753a-140">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="b753a-140">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="b753a-141">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b753a-141">URI parameter</span></span>      | <span data-ttu-id="b753a-142">説明</span><span class="sxs-lookup"><span data-stu-id="b753a-142">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="b753a-143">ネットワーク パス</span><span class="sxs-lookup"><span data-stu-id="b753a-143">NetworkPath</span></span>        | <span data-ttu-id="b753a-144">共有へのネットワーク パスにアクセスする資格情報が追加されます。</span><span class="sxs-lookup"><span data-stu-id="b753a-144">The network path to the share you are adding credentials to access.</span></span> |
<br>

**<span data-ttu-id="b753a-145">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b753a-145">Request headers</span></span>**

- <span data-ttu-id="b753a-146">なし</span><span class="sxs-lookup"><span data-stu-id="b753a-146">None</span></span>

**<span data-ttu-id="b753a-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="b753a-147">Request body</span></span>**

- <span data-ttu-id="b753a-148">次の JSON 要素:</span><span class="sxs-lookup"><span data-stu-id="b753a-148">The following JSON elements:</span></span>
* <span data-ttu-id="b753a-149">ネットワーク パスのネットワーク共有へのパス。</span><span class="sxs-lookup"><span data-stu-id="b753a-149">NetworkPath - The path to the network share.</span></span>
* <span data-ttu-id="b753a-150">Username: 下の資格情報を格納するユーザー名。</span><span class="sxs-lookup"><span data-stu-id="b753a-150">Username - The username to store the credentials under.</span></span>
* <span data-ttu-id="b753a-151">このユーザーの新規または更新されたパスワードのパスワード。</span><span class="sxs-lookup"><span data-stu-id="b753a-151">Password - The new or updated password for this user.</span></span>

**<span data-ttu-id="b753a-152">応答</span><span class="sxs-lookup"><span data-stu-id="b753a-152">Response</span></span>**   

- <span data-ttu-id="b753a-153">なし</span><span class="sxs-lookup"><span data-stu-id="b753a-153">None</span></span>  

**<span data-ttu-id="b753a-154">状態コード</span><span class="sxs-lookup"><span data-stu-id="b753a-154">Status code</span></span>**

<span data-ttu-id="b753a-155">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b753a-155">This API has the following expected status codes.</span></span>

<span data-ttu-id="b753a-156">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="b753a-156">HTTP status code</span></span>      | <span data-ttu-id="b753a-157">説明</span><span class="sxs-lookup"><span data-stu-id="b753a-157">Description</span></span>
:------     | :-----
<span data-ttu-id="b753a-158">204</span><span class="sxs-lookup"><span data-stu-id="b753a-158">204</span></span> | <span data-ttu-id="b753a-159">成功</span><span class="sxs-lookup"><span data-stu-id="b753a-159">Success</span></span>
<span data-ttu-id="b753a-160">4XX</span><span class="sxs-lookup"><span data-stu-id="b753a-160">4XX</span></span> | <span data-ttu-id="b753a-161">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b753a-161">Error codes</span></span>
<span data-ttu-id="b753a-162">5XX</span><span class="sxs-lookup"><span data-stu-id="b753a-162">5XX</span></span> | <span data-ttu-id="b753a-163">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b753a-163">Error codes</span></span>

## <a name="remove-stored-credentials-for-a-share"></a><span data-ttu-id="b753a-164">共有に保存された資格情報を削除します。</span><span class="sxs-lookup"><span data-stu-id="b753a-164">Remove stored credentials for a share.</span></span>

**<span data-ttu-id="b753a-165">要求</span><span class="sxs-lookup"><span data-stu-id="b753a-165">Request</span></span>**

<span data-ttu-id="b753a-166">メソッド</span><span class="sxs-lookup"><span data-stu-id="b753a-166">Method</span></span>      | <span data-ttu-id="b753a-167">要求 URI</span><span class="sxs-lookup"><span data-stu-id="b753a-167">Request URI</span></span>
:------     | :-----
<span data-ttu-id="b753a-168">DELETE</span><span class="sxs-lookup"><span data-stu-id="b753a-168">DELETE</span></span> | <span data-ttu-id="b753a-169">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="b753a-169">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="b753a-170">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b753a-170">URI parameters</span></span>**

<span data-ttu-id="b753a-171">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="b753a-171">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="b753a-172">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="b753a-172">URI parameter</span></span>      | <span data-ttu-id="b753a-173">説明</span><span class="sxs-lookup"><span data-stu-id="b753a-173">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="b753a-174">ネットワーク パス</span><span class="sxs-lookup"><span data-stu-id="b753a-174">NetworkPath</span></span>        | <span data-ttu-id="b753a-175">保存された資格情報を削除する共有へのネットワーク パス。</span><span class="sxs-lookup"><span data-stu-id="b753a-175">The network path to the share from which you are removing stored credentials.</span></span> |
<br>

**<span data-ttu-id="b753a-176">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b753a-176">Request headers</span></span>**

- <span data-ttu-id="b753a-177">なし</span><span class="sxs-lookup"><span data-stu-id="b753a-177">None</span></span>

**<span data-ttu-id="b753a-178">要求本文</span><span class="sxs-lookup"><span data-stu-id="b753a-178">Request body</span></span>**   

- <span data-ttu-id="b753a-179">なし</span><span class="sxs-lookup"><span data-stu-id="b753a-179">None</span></span>

**<span data-ttu-id="b753a-180">応答</span><span class="sxs-lookup"><span data-stu-id="b753a-180">Response</span></span>**   

- <span data-ttu-id="b753a-181">なし</span><span class="sxs-lookup"><span data-stu-id="b753a-181">None</span></span> 

**<span data-ttu-id="b753a-182">状態コード</span><span class="sxs-lookup"><span data-stu-id="b753a-182">Status code</span></span>**

<span data-ttu-id="b753a-183">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b753a-183">This API has the following expected status codes.</span></span>

<span data-ttu-id="b753a-184">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="b753a-184">HTTP status code</span></span>      | <span data-ttu-id="b753a-185">説明</span><span class="sxs-lookup"><span data-stu-id="b753a-185">Description</span></span>
:------     | :-----
<span data-ttu-id="b753a-186">204</span><span class="sxs-lookup"><span data-stu-id="b753a-186">204</span></span> | <span data-ttu-id="b753a-187">資格情報を要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="b753a-187">The request to the credentials was successful.</span></span>
<span data-ttu-id="b753a-188">4XX</span><span class="sxs-lookup"><span data-stu-id="b753a-188">4XX</span></span> | <span data-ttu-id="b753a-189">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b753a-189">Error codes</span></span>
<span data-ttu-id="b753a-190">5XX</span><span class="sxs-lookup"><span data-stu-id="b753a-190">5XX</span></span> | <span data-ttu-id="b753a-191">エラー コード</span><span class="sxs-lookup"><span data-stu-id="b753a-191">Error codes</span></span>

<br />
**<span data-ttu-id="b753a-192">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="b753a-192">Available device families</span></span>**

* <span data-ttu-id="b753a-193">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="b753a-193">Windows Xbox</span></span>


