---
author: WilliamsJason
title: デバイス ポータル ネットワーク API の資格情報の参照
description: 追加、削除、またはプログラムからネットワークの資格情報を更新する方法について説明します。
ms.localizationpriority: medium
ms.openlocfilehash: 7e00169f92ee6f0aa48df64ec4a1186f9682b358
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608861"
---
# <a name="network-credentials-api-reference"></a><span data-ttu-id="45e82-103">ネットワークの資格情報の API リファレンス</span><span class="sxs-lookup"><span data-stu-id="45e82-103">Network Credentials API reference</span></span>
<span data-ttu-id="45e82-104">追加、削除、またはこの REST API を使用して、キットに保存されているネットワークの資格情報を更新することができます。</span><span class="sxs-lookup"><span data-stu-id="45e82-104">You can add, remove, or update stored network credentials on your devkit using this REST API.</span></span>

## <a name="get-existing-credentials"></a><span data-ttu-id="45e82-105">既存の資格情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="45e82-105">Get existing credentials</span></span>

**<span data-ttu-id="45e82-106">要求</span><span class="sxs-lookup"><span data-stu-id="45e82-106">Request</span></span>**

<span data-ttu-id="45e82-107">ネットワークを共有するための資格情報を持っているユーザーのユーザー名と保存されている共有フォルダーの一覧を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="45e82-107">You can get a list of the stored shares along with the username of the user who has credentials for that network share.</span></span>

<span data-ttu-id="45e82-108">メソッド</span><span class="sxs-lookup"><span data-stu-id="45e82-108">Method</span></span>      | <span data-ttu-id="45e82-109">要求 URI</span><span class="sxs-lookup"><span data-stu-id="45e82-109">Request URI</span></span>
:------     | :-----
<span data-ttu-id="45e82-110">GET</span><span class="sxs-lookup"><span data-stu-id="45e82-110">GET</span></span> | <span data-ttu-id="45e82-111">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="45e82-111">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="45e82-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="45e82-112">URI parameters</span></span>**

- <span data-ttu-id="45e82-113">なし</span><span class="sxs-lookup"><span data-stu-id="45e82-113">None</span></span>

**<span data-ttu-id="45e82-114">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="45e82-114">Request headers</span></span>**

- <span data-ttu-id="45e82-115">なし</span><span class="sxs-lookup"><span data-stu-id="45e82-115">None</span></span>

**<span data-ttu-id="45e82-116">要求本文</span><span class="sxs-lookup"><span data-stu-id="45e82-116">Request body</span></span>**   

- <span data-ttu-id="45e82-117">なし</span><span class="sxs-lookup"><span data-stu-id="45e82-117">None</span></span>

**<span data-ttu-id="45e82-118">応答</span><span class="sxs-lookup"><span data-stu-id="45e82-118">Response</span></span>**   

- <span data-ttu-id="45e82-119">次の形式で JSON 配列します。</span><span class="sxs-lookup"><span data-stu-id="45e82-119">JSON array in the following format:</span></span>
* <span data-ttu-id="45e82-120">資格情報</span><span class="sxs-lookup"><span data-stu-id="45e82-120">Credentials</span></span>
  * <span data-ttu-id="45e82-121">ネットワーク パスのネットワーク共有へのパス。</span><span class="sxs-lookup"><span data-stu-id="45e82-121">NetworkPath - The path to the network share.</span></span>
  * <span data-ttu-id="45e82-122">ユーザー名の資格情報を保存しているユーザー名です。</span><span class="sxs-lookup"><span data-stu-id="45e82-122">Username - The username which has stored credentials.</span></span>

**<span data-ttu-id="45e82-123">状態コード</span><span class="sxs-lookup"><span data-stu-id="45e82-123">Status code</span></span>**

<span data-ttu-id="45e82-124">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="45e82-124">This API has the following expected status codes.</span></span>

<span data-ttu-id="45e82-125">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="45e82-125">HTTP status code</span></span>      | <span data-ttu-id="45e82-126">説明</span><span class="sxs-lookup"><span data-stu-id="45e82-126">Description</span></span>
:------     | :-----
<span data-ttu-id="45e82-127">200</span><span class="sxs-lookup"><span data-stu-id="45e82-127">200</span></span> | <span data-ttu-id="45e82-128">成功</span><span class="sxs-lookup"><span data-stu-id="45e82-128">Success</span></span>
<span data-ttu-id="45e82-129">4XX</span><span class="sxs-lookup"><span data-stu-id="45e82-129">4XX</span></span> | <span data-ttu-id="45e82-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="45e82-130">Error codes</span></span>
<span data-ttu-id="45e82-131">5XX</span><span class="sxs-lookup"><span data-stu-id="45e82-131">5XX</span></span> | <span data-ttu-id="45e82-132">エラー コード</span><span class="sxs-lookup"><span data-stu-id="45e82-132">Error codes</span></span>

## <a name="add-or-update-stored-credentials-for-a-user"></a><span data-ttu-id="45e82-133">追加またはユーザーの資格情報を更新します。</span><span class="sxs-lookup"><span data-stu-id="45e82-133">Add or update stored credentials for a user</span></span>

**<span data-ttu-id="45e82-134">要求</span><span class="sxs-lookup"><span data-stu-id="45e82-134">Request</span></span>**

<span data-ttu-id="45e82-135">メソッド</span><span class="sxs-lookup"><span data-stu-id="45e82-135">Method</span></span>      | <span data-ttu-id="45e82-136">要求 URI</span><span class="sxs-lookup"><span data-stu-id="45e82-136">Request URI</span></span>
:------     | :-----
<span data-ttu-id="45e82-137">POST</span><span class="sxs-lookup"><span data-stu-id="45e82-137">POST</span></span> | <span data-ttu-id="45e82-138">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="45e82-138">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="45e82-139">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="45e82-139">URI parameters</span></span>**

<span data-ttu-id="45e82-140">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="45e82-140">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="45e82-141">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="45e82-141">URI parameter</span></span>      | <span data-ttu-id="45e82-142">説明</span><span class="sxs-lookup"><span data-stu-id="45e82-142">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="45e82-143">ネットワーク パス</span><span class="sxs-lookup"><span data-stu-id="45e82-143">NetworkPath</span></span>        | <span data-ttu-id="45e82-144">共有へのパスをネットワークにアクセスするための資格情報を追加します。</span><span class="sxs-lookup"><span data-stu-id="45e82-144">The network path to the share you are adding credentials to access.</span></span> |
<br>

**<span data-ttu-id="45e82-145">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="45e82-145">Request headers</span></span>**

- <span data-ttu-id="45e82-146">なし</span><span class="sxs-lookup"><span data-stu-id="45e82-146">None</span></span>

**<span data-ttu-id="45e82-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="45e82-147">Request body</span></span>**

- <span data-ttu-id="45e82-148">JSON は次の要素:</span><span class="sxs-lookup"><span data-stu-id="45e82-148">The following JSON elements:</span></span>
* <span data-ttu-id="45e82-149">ネットワーク パスのネットワーク共有へのパス。</span><span class="sxs-lookup"><span data-stu-id="45e82-149">NetworkPath - The path to the network share.</span></span>
* <span data-ttu-id="45e82-150">ユーザー名のユーザー名の下の資格情報を保存します。</span><span class="sxs-lookup"><span data-stu-id="45e82-150">Username - The username to store the credentials under.</span></span>
* <span data-ttu-id="45e82-151">パスワードの新規または更新されたこのユーザーのパスワードです。</span><span class="sxs-lookup"><span data-stu-id="45e82-151">Password - The new or updated password for this user.</span></span>

**<span data-ttu-id="45e82-152">応答</span><span class="sxs-lookup"><span data-stu-id="45e82-152">Response</span></span>**   

- <span data-ttu-id="45e82-153">なし</span><span class="sxs-lookup"><span data-stu-id="45e82-153">None</span></span>  

**<span data-ttu-id="45e82-154">状態コード</span><span class="sxs-lookup"><span data-stu-id="45e82-154">Status code</span></span>**

<span data-ttu-id="45e82-155">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="45e82-155">This API has the following expected status codes.</span></span>

<span data-ttu-id="45e82-156">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="45e82-156">HTTP status code</span></span>      | <span data-ttu-id="45e82-157">説明</span><span class="sxs-lookup"><span data-stu-id="45e82-157">Description</span></span>
:------     | :-----
<span data-ttu-id="45e82-158">204</span><span class="sxs-lookup"><span data-stu-id="45e82-158">204</span></span> | <span data-ttu-id="45e82-159">成功</span><span class="sxs-lookup"><span data-stu-id="45e82-159">Success</span></span>
<span data-ttu-id="45e82-160">4XX</span><span class="sxs-lookup"><span data-stu-id="45e82-160">4XX</span></span> | <span data-ttu-id="45e82-161">エラー コード</span><span class="sxs-lookup"><span data-stu-id="45e82-161">Error codes</span></span>
<span data-ttu-id="45e82-162">5XX</span><span class="sxs-lookup"><span data-stu-id="45e82-162">5XX</span></span> | <span data-ttu-id="45e82-163">エラー コード</span><span class="sxs-lookup"><span data-stu-id="45e82-163">Error codes</span></span>

## <a name="remove-stored-credentials-for-a-share"></a><span data-ttu-id="45e82-164">共有の資格情報を削除します。</span><span class="sxs-lookup"><span data-stu-id="45e82-164">Remove stored credentials for a share.</span></span>

**<span data-ttu-id="45e82-165">要求</span><span class="sxs-lookup"><span data-stu-id="45e82-165">Request</span></span>**

<span data-ttu-id="45e82-166">メソッド</span><span class="sxs-lookup"><span data-stu-id="45e82-166">Method</span></span>      | <span data-ttu-id="45e82-167">要求 URI</span><span class="sxs-lookup"><span data-stu-id="45e82-167">Request URI</span></span>
:------     | :-----
<span data-ttu-id="45e82-168">DELETE</span><span class="sxs-lookup"><span data-stu-id="45e82-168">DELETE</span></span> | <span data-ttu-id="45e82-169">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="45e82-169">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="45e82-170">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="45e82-170">URI parameters</span></span>**

<span data-ttu-id="45e82-171">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="45e82-171">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="45e82-172">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="45e82-172">URI parameter</span></span>      | <span data-ttu-id="45e82-173">説明</span><span class="sxs-lookup"><span data-stu-id="45e82-173">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="45e82-174">ネットワーク パス</span><span class="sxs-lookup"><span data-stu-id="45e82-174">NetworkPath</span></span>        | <span data-ttu-id="45e82-175">格納された資格情報を削除する共有へのネットワーク パス。</span><span class="sxs-lookup"><span data-stu-id="45e82-175">The network path to the share from which you are removing stored credentials.</span></span> |
<br>

**<span data-ttu-id="45e82-176">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="45e82-176">Request headers</span></span>**

- <span data-ttu-id="45e82-177">なし</span><span class="sxs-lookup"><span data-stu-id="45e82-177">None</span></span>

**<span data-ttu-id="45e82-178">要求本文</span><span class="sxs-lookup"><span data-stu-id="45e82-178">Request body</span></span>**   

- <span data-ttu-id="45e82-179">なし</span><span class="sxs-lookup"><span data-stu-id="45e82-179">None</span></span>

**<span data-ttu-id="45e82-180">応答</span><span class="sxs-lookup"><span data-stu-id="45e82-180">Response</span></span>**   

- <span data-ttu-id="45e82-181">なし</span><span class="sxs-lookup"><span data-stu-id="45e82-181">None</span></span> 

**<span data-ttu-id="45e82-182">状態コード</span><span class="sxs-lookup"><span data-stu-id="45e82-182">Status code</span></span>**

<span data-ttu-id="45e82-183">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="45e82-183">This API has the following expected status codes.</span></span>

<span data-ttu-id="45e82-184">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="45e82-184">HTTP status code</span></span>      | <span data-ttu-id="45e82-185">説明</span><span class="sxs-lookup"><span data-stu-id="45e82-185">Description</span></span>
:------     | :-----
<span data-ttu-id="45e82-186">204</span><span class="sxs-lookup"><span data-stu-id="45e82-186">204</span></span> | <span data-ttu-id="45e82-187">資格情報への出席依頼が正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="45e82-187">The request to the credentials was successful.</span></span>
<span data-ttu-id="45e82-188">4XX</span><span class="sxs-lookup"><span data-stu-id="45e82-188">4XX</span></span> | <span data-ttu-id="45e82-189">エラー コード</span><span class="sxs-lookup"><span data-stu-id="45e82-189">Error codes</span></span>
<span data-ttu-id="45e82-190">5XX</span><span class="sxs-lookup"><span data-stu-id="45e82-190">5XX</span></span> | <span data-ttu-id="45e82-191">エラー コード</span><span class="sxs-lookup"><span data-stu-id="45e82-191">Error codes</span></span>

<br />
**<span data-ttu-id="45e82-192">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="45e82-192">Available device families</span></span>**

* <span data-ttu-id="45e82-193">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="45e82-193">Windows Xbox</span></span>


