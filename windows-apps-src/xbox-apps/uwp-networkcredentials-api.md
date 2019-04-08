---
title: デバイス ポータル ネットワーク資格情報 API リファレンス
description: ネットワーク資格情報をプログラムにより追加、削除、更新する方法について説明します。
ms.localizationpriority: medium
ms.topic: article
ms.date: 02/08/2017
ms.openlocfilehash: ac30d8db830c51ee40653feb49b443ed44502617
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659217"
---
# <a name="network-credentials-api-reference"></a><span data-ttu-id="08265-103">ネットワーク資格情報 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="08265-103">Network Credentials API reference</span></span>
<span data-ttu-id="08265-104">この REST API を使って、開発キットで保存されているネットワーク資格情報を追加、削除、更新することができます。</span><span class="sxs-lookup"><span data-stu-id="08265-104">You can add, remove, or update stored network credentials on your devkit using this REST API.</span></span>

## <a name="get-existing-credentials"></a><span data-ttu-id="08265-105">既存の資格情報を取得する</span><span class="sxs-lookup"><span data-stu-id="08265-105">Get existing credentials</span></span>

<span data-ttu-id="08265-106">**要求**</span><span class="sxs-lookup"><span data-stu-id="08265-106">**Request**</span></span>

<span data-ttu-id="08265-107">そのネットワーク共有の資格情報を持っているユーザーのユーザー名と共に、保存されている共有フォルダーの一覧を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="08265-107">You can get a list of the stored shares along with the username of the user who has credentials for that network share.</span></span>

<span data-ttu-id="08265-108">メソッド</span><span class="sxs-lookup"><span data-stu-id="08265-108">Method</span></span>      | <span data-ttu-id="08265-109">要求 URI</span><span class="sxs-lookup"><span data-stu-id="08265-109">Request URI</span></span>
:------     | :-----
<span data-ttu-id="08265-110">GET</span><span class="sxs-lookup"><span data-stu-id="08265-110">GET</span></span> | <span data-ttu-id="08265-111">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="08265-111">/ext/networkcredential</span></span>
<br />
<span data-ttu-id="08265-112">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="08265-112">**URI parameters**</span></span>

- <span data-ttu-id="08265-113">なし</span><span class="sxs-lookup"><span data-stu-id="08265-113">None</span></span>

<span data-ttu-id="08265-114">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="08265-114">**Request headers**</span></span>

- <span data-ttu-id="08265-115">なし</span><span class="sxs-lookup"><span data-stu-id="08265-115">None</span></span>

<span data-ttu-id="08265-116">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="08265-116">**Request body**</span></span>   

- <span data-ttu-id="08265-117">なし</span><span class="sxs-lookup"><span data-stu-id="08265-117">None</span></span>

<span data-ttu-id="08265-118">**応答**</span><span class="sxs-lookup"><span data-stu-id="08265-118">**Response**</span></span>   

- <span data-ttu-id="08265-119">次の形式の JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="08265-119">JSON array in the following format:</span></span>
* <span data-ttu-id="08265-120">資格情報</span><span class="sxs-lookup"><span data-stu-id="08265-120">Credentials</span></span>
  * <span data-ttu-id="08265-121">ネットワーク パス - ネットワーク共有へのパス。</span><span class="sxs-lookup"><span data-stu-id="08265-121">NetworkPath - The path to the network share.</span></span>
  * <span data-ttu-id="08265-122">ユーザー名 - 資格情報を保存しているユーザー名。</span><span class="sxs-lookup"><span data-stu-id="08265-122">Username - The username which has stored credentials.</span></span>

<span data-ttu-id="08265-123">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="08265-123">**Status code**</span></span>

<span data-ttu-id="08265-124">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="08265-124">This API has the following expected status codes.</span></span>

<span data-ttu-id="08265-125">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="08265-125">HTTP status code</span></span>      | <span data-ttu-id="08265-126">説明</span><span class="sxs-lookup"><span data-stu-id="08265-126">Description</span></span>
:------     | :-----
<span data-ttu-id="08265-127">200</span><span class="sxs-lookup"><span data-stu-id="08265-127">200</span></span> | <span data-ttu-id="08265-128">成功</span><span class="sxs-lookup"><span data-stu-id="08265-128">Success</span></span>
<span data-ttu-id="08265-129">4XX</span><span class="sxs-lookup"><span data-stu-id="08265-129">4XX</span></span> | <span data-ttu-id="08265-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="08265-130">Error codes</span></span>
<span data-ttu-id="08265-131">5XX</span><span class="sxs-lookup"><span data-stu-id="08265-131">5XX</span></span> | <span data-ttu-id="08265-132">エラー コード</span><span class="sxs-lookup"><span data-stu-id="08265-132">Error codes</span></span>

## <a name="add-or-update-stored-credentials-for-a-user"></a><span data-ttu-id="08265-133">保存されたユーザーの資格情報を追加または更新する</span><span class="sxs-lookup"><span data-stu-id="08265-133">Add or update stored credentials for a user</span></span>

<span data-ttu-id="08265-134">**要求**</span><span class="sxs-lookup"><span data-stu-id="08265-134">**Request**</span></span>

<span data-ttu-id="08265-135">メソッド</span><span class="sxs-lookup"><span data-stu-id="08265-135">Method</span></span>      | <span data-ttu-id="08265-136">要求 URI</span><span class="sxs-lookup"><span data-stu-id="08265-136">Request URI</span></span>
:------     | :-----
<span data-ttu-id="08265-137">POST</span><span class="sxs-lookup"><span data-stu-id="08265-137">POST</span></span> | <span data-ttu-id="08265-138">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="08265-138">/ext/networkcredential</span></span>
<br />
<span data-ttu-id="08265-139">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="08265-139">**URI parameters**</span></span>

<span data-ttu-id="08265-140">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="08265-140">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="08265-141">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="08265-141">URI parameter</span></span>      | <span data-ttu-id="08265-142">説明</span><span class="sxs-lookup"><span data-stu-id="08265-142">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="08265-143">ネットワーク パス</span><span class="sxs-lookup"><span data-stu-id="08265-143">NetworkPath</span></span>        | <span data-ttu-id="08265-144">アクセスするために資格情報を追加する共有へのネットワーク パス。</span><span class="sxs-lookup"><span data-stu-id="08265-144">The network path to the share you are adding credentials to access.</span></span> |
<br>

<span data-ttu-id="08265-145">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="08265-145">**Request headers**</span></span>

- <span data-ttu-id="08265-146">なし</span><span class="sxs-lookup"><span data-stu-id="08265-146">None</span></span>

<span data-ttu-id="08265-147">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="08265-147">**Request body**</span></span>

- <span data-ttu-id="08265-148">次の JSON 要素</span><span class="sxs-lookup"><span data-stu-id="08265-148">The following JSON elements:</span></span>
* <span data-ttu-id="08265-149">ネットワーク パス - ネットワーク共有へのパス。</span><span class="sxs-lookup"><span data-stu-id="08265-149">NetworkPath - The path to the network share.</span></span>
* <span data-ttu-id="08265-150">ユーザー名 - 資格情報を保存するユーザー名。</span><span class="sxs-lookup"><span data-stu-id="08265-150">Username - The username to store the credentials under.</span></span>
* <span data-ttu-id="08265-151">パスワード - このユーザーの新規または更新されたパスワード。</span><span class="sxs-lookup"><span data-stu-id="08265-151">Password - The new or updated password for this user.</span></span>

<span data-ttu-id="08265-152">**応答**</span><span class="sxs-lookup"><span data-stu-id="08265-152">**Response**</span></span>   

- <span data-ttu-id="08265-153">なし</span><span class="sxs-lookup"><span data-stu-id="08265-153">None</span></span>  

<span data-ttu-id="08265-154">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="08265-154">**Status code**</span></span>

<span data-ttu-id="08265-155">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="08265-155">This API has the following expected status codes.</span></span>

<span data-ttu-id="08265-156">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="08265-156">HTTP status code</span></span>      | <span data-ttu-id="08265-157">説明</span><span class="sxs-lookup"><span data-stu-id="08265-157">Description</span></span>
:------     | :-----
<span data-ttu-id="08265-158">204</span><span class="sxs-lookup"><span data-stu-id="08265-158">204</span></span> | <span data-ttu-id="08265-159">成功</span><span class="sxs-lookup"><span data-stu-id="08265-159">Success</span></span>
<span data-ttu-id="08265-160">4XX</span><span class="sxs-lookup"><span data-stu-id="08265-160">4XX</span></span> | <span data-ttu-id="08265-161">エラー コード</span><span class="sxs-lookup"><span data-stu-id="08265-161">Error codes</span></span>
<span data-ttu-id="08265-162">5XX</span><span class="sxs-lookup"><span data-stu-id="08265-162">5XX</span></span> | <span data-ttu-id="08265-163">エラー コード</span><span class="sxs-lookup"><span data-stu-id="08265-163">Error codes</span></span>

## <a name="remove-stored-credentials-for-a-share"></a><span data-ttu-id="08265-164">共有の保存された資格情報を削除します。</span><span class="sxs-lookup"><span data-stu-id="08265-164">Remove stored credentials for a share.</span></span>

<span data-ttu-id="08265-165">**要求**</span><span class="sxs-lookup"><span data-stu-id="08265-165">**Request**</span></span>

<span data-ttu-id="08265-166">メソッド</span><span class="sxs-lookup"><span data-stu-id="08265-166">Method</span></span>      | <span data-ttu-id="08265-167">要求 URI</span><span class="sxs-lookup"><span data-stu-id="08265-167">Request URI</span></span>
:------     | :-----
<span data-ttu-id="08265-168">Del</span><span class="sxs-lookup"><span data-stu-id="08265-168">DELETE</span></span> | <span data-ttu-id="08265-169">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="08265-169">/ext/networkcredential</span></span>
<br />
<span data-ttu-id="08265-170">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="08265-170">**URI parameters**</span></span>

<span data-ttu-id="08265-171">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="08265-171">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="08265-172">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="08265-172">URI parameter</span></span>      | <span data-ttu-id="08265-173">説明</span><span class="sxs-lookup"><span data-stu-id="08265-173">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="08265-174">ネットワーク パス</span><span class="sxs-lookup"><span data-stu-id="08265-174">NetworkPath</span></span>        | <span data-ttu-id="08265-175">保存された資格情報の削除元の共有へのネットワーク パス。</span><span class="sxs-lookup"><span data-stu-id="08265-175">The network path to the share from which you are removing stored credentials.</span></span> |
<br>

<span data-ttu-id="08265-176">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="08265-176">**Request headers**</span></span>

- <span data-ttu-id="08265-177">なし</span><span class="sxs-lookup"><span data-stu-id="08265-177">None</span></span>

<span data-ttu-id="08265-178">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="08265-178">**Request body**</span></span>   

- <span data-ttu-id="08265-179">なし</span><span class="sxs-lookup"><span data-stu-id="08265-179">None</span></span>

<span data-ttu-id="08265-180">**応答**</span><span class="sxs-lookup"><span data-stu-id="08265-180">**Response**</span></span>   

- <span data-ttu-id="08265-181">なし</span><span class="sxs-lookup"><span data-stu-id="08265-181">None</span></span> 

<span data-ttu-id="08265-182">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="08265-182">**Status code**</span></span>

<span data-ttu-id="08265-183">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="08265-183">This API has the following expected status codes.</span></span>

<span data-ttu-id="08265-184">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="08265-184">HTTP status code</span></span>      | <span data-ttu-id="08265-185">説明</span><span class="sxs-lookup"><span data-stu-id="08265-185">Description</span></span>
:------     | :-----
<span data-ttu-id="08265-186">204</span><span class="sxs-lookup"><span data-stu-id="08265-186">204</span></span> | <span data-ttu-id="08265-187">資格情報への要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="08265-187">The request to the credentials was successful.</span></span>
<span data-ttu-id="08265-188">4XX</span><span class="sxs-lookup"><span data-stu-id="08265-188">4XX</span></span> | <span data-ttu-id="08265-189">エラー コード</span><span class="sxs-lookup"><span data-stu-id="08265-189">Error codes</span></span>
<span data-ttu-id="08265-190">5XX</span><span class="sxs-lookup"><span data-stu-id="08265-190">5XX</span></span> | <span data-ttu-id="08265-191">エラー コード</span><span class="sxs-lookup"><span data-stu-id="08265-191">Error codes</span></span>

<br />
<span data-ttu-id="08265-192">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="08265-192">**Available device families**</span></span>

* <span data-ttu-id="08265-193">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="08265-193">Windows Xbox</span></span>


