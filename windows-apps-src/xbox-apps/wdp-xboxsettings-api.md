---
author: m-stahl
title: Device Portal の Xbox 開発者向け設定 API のリファレンス
description: Xbox 開発者向け設定にアクセスする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 6ab12b99-2944-49c9-92d9-f995efc4f6ce
ms.openlocfilehash: dfde4c45a4aa5a520e0aa98cd7f31f7d84854e08
ms.sourcegitcommit: 0e44f197e7e649d542ec3f67cd790a61dbe1226f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/07/2017
ms.locfileid: "662502"
---
# <a name="developer-settings-api-reference"></a><span data-ttu-id="8a56f-104">開発者向け設定 API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="8a56f-104">Developer settings API reference</span></span>   
<span data-ttu-id="8a56f-105">この API を使用して、開発に役立つ Xbox One 設定にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="8a56f-105">You can access Xbox One settings that are useful for development using this API.</span></span>

## <a name="get-all-developer-settings-at-once"></a><span data-ttu-id="8a56f-106">すべての開発者向け設定を一度に取得する</span><span class="sxs-lookup"><span data-stu-id="8a56f-106">Get all developer settings at once</span></span>

**<span data-ttu-id="8a56f-107">要求</span><span class="sxs-lookup"><span data-stu-id="8a56f-107">Request</span></span>**

<span data-ttu-id="8a56f-108">次の要求を使用して、すべての開発者向け設定を 1 つの要求で取得できます。</span><span class="sxs-lookup"><span data-stu-id="8a56f-108">You can use the following request to get all developer settings in a single request.</span></span>

<span data-ttu-id="8a56f-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="8a56f-109">Method</span></span>      | <span data-ttu-id="8a56f-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="8a56f-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="8a56f-111">GET</span><span class="sxs-lookup"><span data-stu-id="8a56f-111">GET</span></span> | <span data-ttu-id="8a56f-112">/ext/settings</span><span class="sxs-lookup"><span data-stu-id="8a56f-112">/ext/settings</span></span>
<br />
**<span data-ttu-id="8a56f-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8a56f-113">URI parameters</span></span>**

- <span data-ttu-id="8a56f-114">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-114">None</span></span>

**<span data-ttu-id="8a56f-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8a56f-115">Request headers</span></span>**

- <span data-ttu-id="8a56f-116">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-116">None</span></span>

**<span data-ttu-id="8a56f-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="8a56f-117">Request body</span></span>**

- <span data-ttu-id="8a56f-118">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-118">None</span></span>

**<span data-ttu-id="8a56f-119">応答</span><span class="sxs-lookup"><span data-stu-id="8a56f-119">Response</span></span>**   
<span data-ttu-id="8a56f-120">応答は、すべての設定を含む設定の JSON 配列です。</span><span class="sxs-lookup"><span data-stu-id="8a56f-120">The response is a Settings JSON array containing all the settings.</span></span> <span data-ttu-id="8a56f-121">設定オブジェクトには、それぞれ次のフィールドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="8a56f-121">Each settings object contains the following fields:</span></span>

<span data-ttu-id="8a56f-122">Name: (文字列) 設定の名前。</span><span class="sxs-lookup"><span data-stu-id="8a56f-122">Name - (String) The name of the setting.</span></span>
<span data-ttu-id="8a56f-123">Value: (文字列) 設定の値。</span><span class="sxs-lookup"><span data-stu-id="8a56f-123">Value - (String) The value of the setting.</span></span>
<span data-ttu-id="8a56f-124">RequiresReboot: ("Yes" | "No") このフィールドは、設定を有効にするために再起動する必要があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-124">RequiresReboot - ("Yes" | "No") This field indicates whether the setting requires a reboot to take effect.</span></span>
<span data-ttu-id="8a56f-125">Disabled - ("Yes" | "No") このフィールドは、設定が無効であるかどうかと編集不可であるかを示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-125">Disabled - ("Yes" | "No") This field indicates whether the setting is disabled and cannot be edited.</span></span>
<span data-ttu-id="8a56f-126">Category: (文字列) 設定のカテゴリ。</span><span class="sxs-lookup"><span data-stu-id="8a56f-126">Category - (String) The category of the setting.</span></span>
<span data-ttu-id="8a56f-127">Type - ("Text" | "Number" | "Bool" | "Select") このフィールドは、設定の型を示します。テキスト入力、ブール値 ("true" または "false")、最小値と最大値を持つ数値、値の特定のリストを持つ選択のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="8a56f-127">Type - ("Text" | "Number" | "Bool" | "Select") This field indicates what type a setting is: text input, a boolean value ("true" or "false"), a number with a min and max or select with a specific list of values.</span></span>

<span data-ttu-id="8a56f-128">設定が数値の場合: Min - (数値) このフィールドは、設定の最小数値を示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-128">If the setting is a number: Min - (Number) This field indicates the minimal numverical value of the setting.</span></span>
<span data-ttu-id="8a56f-129">Max - (数値) このフィールドは、設定の最大数値を示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-129">Max - (Number) This field indicates the maximum numverical value of the setting.</span></span>

<span data-ttu-id="8a56f-130">設定が選択の場合: OptionsVariable - ("Yes" | "No") このフィールドは、設定オプションが可変であるかどうか、再起動しなくても有効なオプションが変化する可能性があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-130">If the setting is select: OptionsVariable - ("Yes" | "No") This field indicates whether the setitng options are variable, if the valid options can change without a reboot.</span></span>
<span data-ttu-id="8a56f-131">Options - 有効な選択オプションを文字列として含む JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="8a56f-131">Options - JSON array containing the valid select options as strings.</span></span>

**<span data-ttu-id="8a56f-132">状態コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-132">Status code</span></span>**

<span data-ttu-id="8a56f-133">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8a56f-133">This API has the following expected status codes.</span></span>

<span data-ttu-id="8a56f-134">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-134">HTTP status code</span></span>      | <span data-ttu-id="8a56f-135">説明</span><span class="sxs-lookup"><span data-stu-id="8a56f-135">Description</span></span>
:------     | :-----
<span data-ttu-id="8a56f-136">200</span><span class="sxs-lookup"><span data-stu-id="8a56f-136">200</span></span> | <span data-ttu-id="8a56f-137">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="8a56f-137">Request was successful</span></span>
<span data-ttu-id="8a56f-138">4XX</span><span class="sxs-lookup"><span data-stu-id="8a56f-138">4XX</span></span> | <span data-ttu-id="8a56f-139">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-139">Error codes</span></span>
<span data-ttu-id="8a56f-140">5XX</span><span class="sxs-lookup"><span data-stu-id="8a56f-140">5XX</span></span> | <span data-ttu-id="8a56f-141">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-141">Error codes</span></span>

## <a name="get-settings-one-at-a-time"></a><span data-ttu-id="8a56f-142">設定を一度に 1 つ取得する</span><span class="sxs-lookup"><span data-stu-id="8a56f-142">Get settings one at a time</span></span>
<span data-ttu-id="8a56f-143">設定は個別に取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="8a56f-143">Settings can also be retrieved individually.</span></span>

**<span data-ttu-id="8a56f-144">要求</span><span class="sxs-lookup"><span data-stu-id="8a56f-144">Request</span></span>**

<span data-ttu-id="8a56f-145">次の要求を使って、個別の設定に関する情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="8a56f-145">You can use the following request to get information about an individual setting.</span></span>

<span data-ttu-id="8a56f-146">メソッド</span><span class="sxs-lookup"><span data-stu-id="8a56f-146">Method</span></span>      | <span data-ttu-id="8a56f-147">要求 URI</span><span class="sxs-lookup"><span data-stu-id="8a56f-147">Request URI</span></span>
:------     | :-----
<span data-ttu-id="8a56f-148">GET</span><span class="sxs-lookup"><span data-stu-id="8a56f-148">GET</span></span> | <span data-ttu-id="8a56f-149">/ext/settings/\<設定名\></span><span class="sxs-lookup"><span data-stu-id="8a56f-149">/ext/settings/\<setting name\></span></span>
<br />
**<span data-ttu-id="8a56f-150">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8a56f-150">URI parameters</span></span>**

- <span data-ttu-id="8a56f-151">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-151">None</span></span>

**<span data-ttu-id="8a56f-152">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8a56f-152">Request headers</span></span>**

- <span data-ttu-id="8a56f-153">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-153">None</span></span>

**<span data-ttu-id="8a56f-154">要求本文</span><span class="sxs-lookup"><span data-stu-id="8a56f-154">Request body</span></span>**

- <span data-ttu-id="8a56f-155">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-155">None</span></span>

**<span data-ttu-id="8a56f-156">応答</span><span class="sxs-lookup"><span data-stu-id="8a56f-156">Response</span></span>**   
<span data-ttu-id="8a56f-157">応答は、次のフィールドを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="8a56f-157">The response is a JSON object with following fields:</span></span>

<span data-ttu-id="8a56f-158">Name: (文字列) 設定の名前。</span><span class="sxs-lookup"><span data-stu-id="8a56f-158">Name - (String) The name of the setting.</span></span>
<span data-ttu-id="8a56f-159">Value: (文字列) 設定の値。</span><span class="sxs-lookup"><span data-stu-id="8a56f-159">Value - (String) The value of the setting.</span></span>
<span data-ttu-id="8a56f-160">RequiresReboot: ("Yes" | "No") このフィールドは、設定を有効にするために再起動する必要があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-160">RequiresReboot - ("Yes" | "No") This field indicates whether the setting requires a reboot to take effect.</span></span>
<span data-ttu-id="8a56f-161">Disabled - ("Yes" | "No") このフィールドは、設定が無効であるかどうかと編集不可であるかを示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-161">Disabled - ("Yes" | "No") This field indicates whether the setting is disabled and cannot be edited.</span></span>
<span data-ttu-id="8a56f-162">Category: (文字列) 設定のカテゴリ。</span><span class="sxs-lookup"><span data-stu-id="8a56f-162">Category - (String) The category of the setting.</span></span>
<span data-ttu-id="8a56f-163">Type - ("Text" | "Number" | "Bool" | "Select") このフィールドは、設定の型を示します。テキスト入力、ブール値 ("true" または "false")、最小値と最大値を持つ数値、値の特定のリストを持つ選択のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="8a56f-163">Type - ("Text" | "Number" | "Bool" | "Select") This field indicates what type a setting is: text input, a boolean value ("true" or "false"), a number with a min and max or select with a specific list of values.</span></span>

<span data-ttu-id="8a56f-164">設定が数値の場合: Min - (数値) このフィールドは、設定の最小数値を示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-164">If the setting is a number: Min - (Number) This field indicates the minimal numverical value of the setting.</span></span>
<span data-ttu-id="8a56f-165">Max - (数値) このフィールドは、設定の最大数値を示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-165">Max - (Number) This field indicates the maximum numverical value of the setting.</span></span>

<span data-ttu-id="8a56f-166">設定が選択の場合: OptionsVariable - ("Yes" | "No") このフィールドは、設定オプションが可変であるかどうか、再起動しなくても有効なオプションが変化する可能性があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="8a56f-166">If the setting is select: OptionsVariable - ("Yes" | "No") This field indicates whether the setitng options are variable, if the valid options can change without a reboot.</span></span>
<span data-ttu-id="8a56f-167">Options - 有効な選択オプションを文字列として含む JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="8a56f-167">Options - JSON array containing the valid select options as strings.</span></span>

**<span data-ttu-id="8a56f-168">状態コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-168">Status code</span></span>**

<span data-ttu-id="8a56f-169">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8a56f-169">This API has the following expected status codes.</span></span>

<span data-ttu-id="8a56f-170">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-170">HTTP status code</span></span>      | <span data-ttu-id="8a56f-171">説明</span><span class="sxs-lookup"><span data-stu-id="8a56f-171">Description</span></span>
:------     | :-----
<span data-ttu-id="8a56f-172">200</span><span class="sxs-lookup"><span data-stu-id="8a56f-172">200</span></span> | <span data-ttu-id="8a56f-173">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="8a56f-173">Request was successful</span></span>
<span data-ttu-id="8a56f-174">4XX</span><span class="sxs-lookup"><span data-stu-id="8a56f-174">4XX</span></span> | <span data-ttu-id="8a56f-175">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-175">Error codes</span></span>
<span data-ttu-id="8a56f-176">5XX</span><span class="sxs-lookup"><span data-stu-id="8a56f-176">5XX</span></span> | <span data-ttu-id="8a56f-177">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-177">Error codes</span></span>

## <a name="set-the-value-of-a-setting"></a><span data-ttu-id="8a56f-178">設定の値を設定する</span><span class="sxs-lookup"><span data-stu-id="8a56f-178">Set the value of a setting</span></span>
<span data-ttu-id="8a56f-179">設定の値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="8a56f-179">You can set the value of a setting.</span></span>

**<span data-ttu-id="8a56f-180">要求</span><span class="sxs-lookup"><span data-stu-id="8a56f-180">Request</span></span>**

<span data-ttu-id="8a56f-181">次の要求を使って、設定の値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="8a56f-181">You can use the following request to set the value for a setting.</span></span>

<span data-ttu-id="8a56f-182">メソッド</span><span class="sxs-lookup"><span data-stu-id="8a56f-182">Method</span></span>      | <span data-ttu-id="8a56f-183">要求 URI</span><span class="sxs-lookup"><span data-stu-id="8a56f-183">Request URI</span></span>
:------     | :-----
<span data-ttu-id="8a56f-184">PUT</span><span class="sxs-lookup"><span data-stu-id="8a56f-184">PUT</span></span> | <span data-ttu-id="8a56f-185">/ext/settings/\<設定名\></span><span class="sxs-lookup"><span data-stu-id="8a56f-185">/ext/settings/\<setting name\></span></span>
<br />
**<span data-ttu-id="8a56f-186">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8a56f-186">URI parameters</span></span>**

- <span data-ttu-id="8a56f-187">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-187">None</span></span>

**<span data-ttu-id="8a56f-188">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="8a56f-188">Request headers</span></span>**

- <span data-ttu-id="8a56f-189">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-189">None</span></span>

**<span data-ttu-id="8a56f-190">要求本文</span><span class="sxs-lookup"><span data-stu-id="8a56f-190">Request body</span></span>**   
<span data-ttu-id="8a56f-191">要求本文は、次のフィールドを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="8a56f-191">The request body is JSON object containing the following field:</span></span>   
<span data-ttu-id="8a56f-192">Value: (文字列) 設定の新しい値。</span><span class="sxs-lookup"><span data-stu-id="8a56f-192">Value - (String) The new value for the setting.</span></span>

**<span data-ttu-id="8a56f-193">応答</span><span class="sxs-lookup"><span data-stu-id="8a56f-193">Response</span></span>**   

- <span data-ttu-id="8a56f-194">なし</span><span class="sxs-lookup"><span data-stu-id="8a56f-194">None</span></span>

**<span data-ttu-id="8a56f-195">状態コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-195">Status code</span></span>**

<span data-ttu-id="8a56f-196">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8a56f-196">This API has the following expected status codes.</span></span>

<span data-ttu-id="8a56f-197">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-197">HTTP status code</span></span>      | <span data-ttu-id="8a56f-198">説明</span><span class="sxs-lookup"><span data-stu-id="8a56f-198">Description</span></span>
:------     | :-----
<span data-ttu-id="8a56f-199">200</span><span class="sxs-lookup"><span data-stu-id="8a56f-199">200</span></span> | <span data-ttu-id="8a56f-200">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="8a56f-200">Request was successful</span></span>
<span data-ttu-id="8a56f-201">4XX</span><span class="sxs-lookup"><span data-stu-id="8a56f-201">4XX</span></span> | <span data-ttu-id="8a56f-202">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-202">Error codes</span></span>
<span data-ttu-id="8a56f-203">5XX</span><span class="sxs-lookup"><span data-stu-id="8a56f-203">5XX</span></span> | <span data-ttu-id="8a56f-204">エラー コード</span><span class="sxs-lookup"><span data-stu-id="8a56f-204">Error codes</span></span>

<br />
**<span data-ttu-id="8a56f-205">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="8a56f-205">Available device families</span></span>**

* <span data-ttu-id="8a56f-206">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="8a56f-206">Windows Xbox</span></span>