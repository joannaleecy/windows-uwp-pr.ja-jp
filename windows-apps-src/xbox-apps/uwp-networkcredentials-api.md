---
title: Device Portal ネットワーク資格情報 API リファレンス
description: 追加、削除、またはネットワーク資格情報をプログラムで更新する方法について説明します。
ms.localizationpriority: medium
ms.openlocfilehash: 2da8dae554a0dcbb84d3d3fc3873e2fb035175dc
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8346535"
---
# <a name="network-credentials-api-reference"></a><span data-ttu-id="5c9b6-103">ネットワーク資格情報 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="5c9b6-103">Network Credentials API reference</span></span>
<span data-ttu-id="5c9b6-104">追加、削除、またはこの REST API を使用して、開発機で保存されているネットワーク資格情報を更新することができます。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-104">You can add, remove, or update stored network credentials on your devkit using this REST API.</span></span>

## <a name="get-existing-credentials"></a><span data-ttu-id="5c9b6-105">既存の資格情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-105">Get existing credentials</span></span>

**<span data-ttu-id="5c9b6-106">要求</span><span class="sxs-lookup"><span data-stu-id="5c9b6-106">Request</span></span>**

<span data-ttu-id="5c9b6-107">そのネットワーク共有の資格情報を持っているユーザーのユーザー名と共に保存されている共有の一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-107">You can get a list of the stored shares along with the username of the user who has credentials for that network share.</span></span>

<span data-ttu-id="5c9b6-108">メソッド</span><span class="sxs-lookup"><span data-stu-id="5c9b6-108">Method</span></span>      | <span data-ttu-id="5c9b6-109">要求 URI</span><span class="sxs-lookup"><span data-stu-id="5c9b6-109">Request URI</span></span>
:------     | :-----
<span data-ttu-id="5c9b6-110">GET</span><span class="sxs-lookup"><span data-stu-id="5c9b6-110">GET</span></span> | <span data-ttu-id="5c9b6-111">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="5c9b6-111">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="5c9b6-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5c9b6-112">URI parameters</span></span>**

- <span data-ttu-id="5c9b6-113">なし</span><span class="sxs-lookup"><span data-stu-id="5c9b6-113">None</span></span>

**<span data-ttu-id="5c9b6-114">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5c9b6-114">Request headers</span></span>**

- <span data-ttu-id="5c9b6-115">なし</span><span class="sxs-lookup"><span data-stu-id="5c9b6-115">None</span></span>

**<span data-ttu-id="5c9b6-116">要求本文</span><span class="sxs-lookup"><span data-stu-id="5c9b6-116">Request body</span></span>**   

- <span data-ttu-id="5c9b6-117">なし</span><span class="sxs-lookup"><span data-stu-id="5c9b6-117">None</span></span>

**<span data-ttu-id="5c9b6-118">応答</span><span class="sxs-lookup"><span data-stu-id="5c9b6-118">Response</span></span>**   

- <span data-ttu-id="5c9b6-119">次の形式の JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-119">JSON array in the following format:</span></span>
* <span data-ttu-id="5c9b6-120">資格情報</span><span class="sxs-lookup"><span data-stu-id="5c9b6-120">Credentials</span></span>
  * <span data-ttu-id="5c9b6-121">ネットワーク パスのネットワーク共有へのパス。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-121">NetworkPath - The path to the network share.</span></span>
  * <span data-ttu-id="5c9b6-122">ユーザー名の資格情報を保存しているユーザー名。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-122">Username - The username which has stored credentials.</span></span>

**<span data-ttu-id="5c9b6-123">状態コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-123">Status code</span></span>**

<span data-ttu-id="5c9b6-124">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-124">This API has the following expected status codes.</span></span>

<span data-ttu-id="5c9b6-125">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-125">HTTP status code</span></span>      | <span data-ttu-id="5c9b6-126">説明</span><span class="sxs-lookup"><span data-stu-id="5c9b6-126">Description</span></span>
:------     | :-----
<span data-ttu-id="5c9b6-127">200</span><span class="sxs-lookup"><span data-stu-id="5c9b6-127">200</span></span> | <span data-ttu-id="5c9b6-128">成功</span><span class="sxs-lookup"><span data-stu-id="5c9b6-128">Success</span></span>
<span data-ttu-id="5c9b6-129">4XX</span><span class="sxs-lookup"><span data-stu-id="5c9b6-129">4XX</span></span> | <span data-ttu-id="5c9b6-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-130">Error codes</span></span>
<span data-ttu-id="5c9b6-131">5XX</span><span class="sxs-lookup"><span data-stu-id="5c9b6-131">5XX</span></span> | <span data-ttu-id="5c9b6-132">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-132">Error codes</span></span>

## <a name="add-or-update-stored-credentials-for-a-user"></a><span data-ttu-id="5c9b6-133">追加またはユーザーの資格情報を更新します。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-133">Add or update stored credentials for a user</span></span>

**<span data-ttu-id="5c9b6-134">要求</span><span class="sxs-lookup"><span data-stu-id="5c9b6-134">Request</span></span>**

<span data-ttu-id="5c9b6-135">メソッド</span><span class="sxs-lookup"><span data-stu-id="5c9b6-135">Method</span></span>      | <span data-ttu-id="5c9b6-136">要求 URI</span><span class="sxs-lookup"><span data-stu-id="5c9b6-136">Request URI</span></span>
:------     | :-----
<span data-ttu-id="5c9b6-137">POST</span><span class="sxs-lookup"><span data-stu-id="5c9b6-137">POST</span></span> | <span data-ttu-id="5c9b6-138">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="5c9b6-138">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="5c9b6-139">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5c9b6-139">URI parameters</span></span>**

<span data-ttu-id="5c9b6-140">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-140">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="5c9b6-141">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5c9b6-141">URI parameter</span></span>      | <span data-ttu-id="5c9b6-142">説明</span><span class="sxs-lookup"><span data-stu-id="5c9b6-142">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="5c9b6-143">ネットワーク パス</span><span class="sxs-lookup"><span data-stu-id="5c9b6-143">NetworkPath</span></span>        | <span data-ttu-id="5c9b6-144">共有へのネットワーク パスにアクセスする資格情報が追加されます。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-144">The network path to the share you are adding credentials to access.</span></span> |
<br>

**<span data-ttu-id="5c9b6-145">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5c9b6-145">Request headers</span></span>**

- <span data-ttu-id="5c9b6-146">なし</span><span class="sxs-lookup"><span data-stu-id="5c9b6-146">None</span></span>

**<span data-ttu-id="5c9b6-147">要求本文</span><span class="sxs-lookup"><span data-stu-id="5c9b6-147">Request body</span></span>**

- <span data-ttu-id="5c9b6-148">次の JSON 要素:</span><span class="sxs-lookup"><span data-stu-id="5c9b6-148">The following JSON elements:</span></span>
* <span data-ttu-id="5c9b6-149">ネットワーク パスのネットワーク共有へのパス。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-149">NetworkPath - The path to the network share.</span></span>
* <span data-ttu-id="5c9b6-150">Username: 下の資格情報を格納するユーザー名。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-150">Username - The username to store the credentials under.</span></span>
* <span data-ttu-id="5c9b6-151">このユーザーの新規または更新されたパスワードのパスワード。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-151">Password - The new or updated password for this user.</span></span>

**<span data-ttu-id="5c9b6-152">応答</span><span class="sxs-lookup"><span data-stu-id="5c9b6-152">Response</span></span>**   

- <span data-ttu-id="5c9b6-153">なし</span><span class="sxs-lookup"><span data-stu-id="5c9b6-153">None</span></span>  

**<span data-ttu-id="5c9b6-154">状態コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-154">Status code</span></span>**

<span data-ttu-id="5c9b6-155">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-155">This API has the following expected status codes.</span></span>

<span data-ttu-id="5c9b6-156">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-156">HTTP status code</span></span>      | <span data-ttu-id="5c9b6-157">説明</span><span class="sxs-lookup"><span data-stu-id="5c9b6-157">Description</span></span>
:------     | :-----
<span data-ttu-id="5c9b6-158">204</span><span class="sxs-lookup"><span data-stu-id="5c9b6-158">204</span></span> | <span data-ttu-id="5c9b6-159">成功</span><span class="sxs-lookup"><span data-stu-id="5c9b6-159">Success</span></span>
<span data-ttu-id="5c9b6-160">4XX</span><span class="sxs-lookup"><span data-stu-id="5c9b6-160">4XX</span></span> | <span data-ttu-id="5c9b6-161">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-161">Error codes</span></span>
<span data-ttu-id="5c9b6-162">5XX</span><span class="sxs-lookup"><span data-stu-id="5c9b6-162">5XX</span></span> | <span data-ttu-id="5c9b6-163">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-163">Error codes</span></span>

## <a name="remove-stored-credentials-for-a-share"></a><span data-ttu-id="5c9b6-164">共有の資格情報を削除します。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-164">Remove stored credentials for a share.</span></span>

**<span data-ttu-id="5c9b6-165">要求</span><span class="sxs-lookup"><span data-stu-id="5c9b6-165">Request</span></span>**

<span data-ttu-id="5c9b6-166">メソッド</span><span class="sxs-lookup"><span data-stu-id="5c9b6-166">Method</span></span>      | <span data-ttu-id="5c9b6-167">要求 URI</span><span class="sxs-lookup"><span data-stu-id="5c9b6-167">Request URI</span></span>
:------     | :-----
<span data-ttu-id="5c9b6-168">DELETE</span><span class="sxs-lookup"><span data-stu-id="5c9b6-168">DELETE</span></span> | <span data-ttu-id="5c9b6-169">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="5c9b6-169">/ext/networkcredential</span></span>
<br />
**<span data-ttu-id="5c9b6-170">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5c9b6-170">URI parameters</span></span>**

<span data-ttu-id="5c9b6-171">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-171">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="5c9b6-172">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="5c9b6-172">URI parameter</span></span>      | <span data-ttu-id="5c9b6-173">説明</span><span class="sxs-lookup"><span data-stu-id="5c9b6-173">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="5c9b6-174">ネットワーク パス</span><span class="sxs-lookup"><span data-stu-id="5c9b6-174">NetworkPath</span></span>        | <span data-ttu-id="5c9b6-175">保存された資格情報を削除する共有へのネットワーク パス。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-175">The network path to the share from which you are removing stored credentials.</span></span> |
<br>

**<span data-ttu-id="5c9b6-176">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="5c9b6-176">Request headers</span></span>**

- <span data-ttu-id="5c9b6-177">なし</span><span class="sxs-lookup"><span data-stu-id="5c9b6-177">None</span></span>

**<span data-ttu-id="5c9b6-178">要求本文</span><span class="sxs-lookup"><span data-stu-id="5c9b6-178">Request body</span></span>**   

- <span data-ttu-id="5c9b6-179">なし</span><span class="sxs-lookup"><span data-stu-id="5c9b6-179">None</span></span>

**<span data-ttu-id="5c9b6-180">応答</span><span class="sxs-lookup"><span data-stu-id="5c9b6-180">Response</span></span>**   

- <span data-ttu-id="5c9b6-181">なし</span><span class="sxs-lookup"><span data-stu-id="5c9b6-181">None</span></span> 

**<span data-ttu-id="5c9b6-182">状態コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-182">Status code</span></span>**

<span data-ttu-id="5c9b6-183">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-183">This API has the following expected status codes.</span></span>

<span data-ttu-id="5c9b6-184">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-184">HTTP status code</span></span>      | <span data-ttu-id="5c9b6-185">説明</span><span class="sxs-lookup"><span data-stu-id="5c9b6-185">Description</span></span>
:------     | :-----
<span data-ttu-id="5c9b6-186">204</span><span class="sxs-lookup"><span data-stu-id="5c9b6-186">204</span></span> | <span data-ttu-id="5c9b6-187">資格情報を要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="5c9b6-187">The request to the credentials was successful.</span></span>
<span data-ttu-id="5c9b6-188">4XX</span><span class="sxs-lookup"><span data-stu-id="5c9b6-188">4XX</span></span> | <span data-ttu-id="5c9b6-189">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-189">Error codes</span></span>
<span data-ttu-id="5c9b6-190">5XX</span><span class="sxs-lookup"><span data-stu-id="5c9b6-190">5XX</span></span> | <span data-ttu-id="5c9b6-191">エラー コード</span><span class="sxs-lookup"><span data-stu-id="5c9b6-191">Error codes</span></span>

<br />
**<span data-ttu-id="5c9b6-192">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="5c9b6-192">Available device families</span></span>**

* <span data-ttu-id="5c9b6-193">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="5c9b6-193">Windows Xbox</span></span>


