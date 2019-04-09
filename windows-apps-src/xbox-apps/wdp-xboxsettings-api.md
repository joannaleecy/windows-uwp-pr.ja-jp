---
title: Device Portal の Xbox 開発者向け設定 API のリファレンス
description: Xbox 開発者向け設定にアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 6ab12b99-2944-49c9-92d9-f995efc4f6ce
ms.localizationpriority: medium
ms.openlocfilehash: 54a15be26adf0da97105f15f3a44f26ee7bfc96d
ms.sourcegitcommit: 681c1e3836d2a51cd3b31d824ece344281932bcd
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59240040"
---
# <a name="developer-settings-api-reference"></a><span data-ttu-id="a5a9c-104">開発者向け設定 API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="a5a9c-104">Developer settings API reference</span></span>

<span data-ttu-id="a5a9c-105">この API を使用して、開発に役立つ Xbox One 設定にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-105">You can access Xbox One settings that are useful for development using this API.</span></span>

## <a name="get-all-developer-settings-at-once"></a><span data-ttu-id="a5a9c-106">すべての開発者向け設定を一度に取得する</span><span class="sxs-lookup"><span data-stu-id="a5a9c-106">Get all developer settings at once</span></span>

**<span data-ttu-id="a5a9c-107">要求</span><span class="sxs-lookup"><span data-stu-id="a5a9c-107">Request</span></span>**

<span data-ttu-id="a5a9c-108">次の要求を使用して、すべての開発者向け設定を 1 つの要求で取得できます。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-108">You can use the following request to get all developer settings in a single request.</span></span>

<span data-ttu-id="a5a9c-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="a5a9c-109">Method</span></span>      | <span data-ttu-id="a5a9c-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a5a9c-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="a5a9c-111">GET</span><span class="sxs-lookup"><span data-stu-id="a5a9c-111">GET</span></span> | <span data-ttu-id="a5a9c-112">/ext/settings</span><span class="sxs-lookup"><span data-stu-id="a5a9c-112">/ext/settings</span></span>

**<span data-ttu-id="a5a9c-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a5a9c-113">URI parameters</span></span>**

- <span data-ttu-id="a5a9c-114">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-114">None</span></span>

**<span data-ttu-id="a5a9c-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a5a9c-115">Request headers</span></span>**

- <span data-ttu-id="a5a9c-116">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-116">None</span></span>

**<span data-ttu-id="a5a9c-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="a5a9c-117">Request body</span></span>**

- <span data-ttu-id="a5a9c-118">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-118">None</span></span>

**<span data-ttu-id="a5a9c-119">応答</span><span class="sxs-lookup"><span data-stu-id="a5a9c-119">Response</span></span>**   
<span data-ttu-id="a5a9c-120">応答は、すべての設定を含む設定の JSON 配列です。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-120">The response is a Settings JSON array containing all the settings.</span></span> <span data-ttu-id="a5a9c-121">設定オブジェクトには、それぞれ次のフィールドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-121">Each settings object contains the following fields:</span></span>

* <span data-ttu-id="a5a9c-122">Name: (文字列) 設定の名前。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-122">Name - (String) The name of the setting.</span></span>
* <span data-ttu-id="a5a9c-123">Value: (文字列) 設定の値。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-123">Value - (String) The value of the setting.</span></span>
* <span data-ttu-id="a5a9c-124">RequiresReboot: ("Yes" | "No") このフィールドは、設定を有効にするために再起動する必要があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-124">RequiresReboot - ("Yes" | "No") This field indicates whether the setting requires a reboot to take effect.</span></span>
* <span data-ttu-id="a5a9c-125">Disabled - ("Yes" | "No") このフィールドは、設定が無効であるかどうかと編集不可であるかを示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-125">Disabled - ("Yes" | "No") This field indicates whether the setting is disabled and cannot be edited.</span></span>
* <span data-ttu-id="a5a9c-126">Category: (文字列) 設定のカテゴリ。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-126">Category - (String) The category of the setting.</span></span>
* <span data-ttu-id="a5a9c-127">Type - ("Text" | "Number" | "Bool" | "Select") このフィールドは、設定の型を示します。テキスト入力、ブール値 ("true" または "false")、最小値と最大値を持つ数値、値の特定のリストを持つ選択のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-127">Type - ("Text" | "Number" | "Bool" | "Select") This field indicates what type a setting is: text input, a boolean value ("true" or "false"), a number with a min and max or select with a specific list of values.</span></span>

<span data-ttu-id="a5a9c-128">設定が数値の場合。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-128">If the setting is a number:</span></span>

* <span data-ttu-id="a5a9c-129">Min (Number) このフィールドでは、設定の最小の数値を示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-129">Min - (Number) This field indicates the minimal numerical value of the setting.</span></span>
* <span data-ttu-id="a5a9c-130">最大の (数) このフィールドが設定の最大の数値を示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-130">Max - (Number) This field indicates the maximum numerical value of the setting.</span></span>

<span data-ttu-id="a5a9c-131">場合は、設定を選択します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-131">If the setting is select:</span></span>

* <span data-ttu-id="a5a9c-132">OptionsVariable - ([はい] |"No") このフィールドが再起動せず、有効なオプションを変更できる場合、変数は、設定オプションをかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-132">OptionsVariable - ("Yes" | "No") This field indicates whether the setting options are variable, if the valid options can change without a reboot.</span></span>
* <span data-ttu-id="a5a9c-133">Options - 有効な選択オプションを文字列として含む JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-133">Options - JSON array containing the valid select options as strings.</span></span>

**<span data-ttu-id="a5a9c-134">状態コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-134">Status code</span></span>**

<span data-ttu-id="a5a9c-135">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-135">This API has the following expected status codes.</span></span>

<span data-ttu-id="a5a9c-136">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-136">HTTP status code</span></span>      | <span data-ttu-id="a5a9c-137">説明</span><span class="sxs-lookup"><span data-stu-id="a5a9c-137">Description</span></span>
:------     | :-----
<span data-ttu-id="a5a9c-138">200</span><span class="sxs-lookup"><span data-stu-id="a5a9c-138">200</span></span> | <span data-ttu-id="a5a9c-139">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="a5a9c-139">Request was successful</span></span>
<span data-ttu-id="a5a9c-140">4XX</span><span class="sxs-lookup"><span data-stu-id="a5a9c-140">4XX</span></span> | <span data-ttu-id="a5a9c-141">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-141">Error codes</span></span>
<span data-ttu-id="a5a9c-142">5XX</span><span class="sxs-lookup"><span data-stu-id="a5a9c-142">5XX</span></span> | <span data-ttu-id="a5a9c-143">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-143">Error codes</span></span>

## <a name="get-settings-one-at-a-time"></a><span data-ttu-id="a5a9c-144">設定を一度に 1 つ取得する</span><span class="sxs-lookup"><span data-stu-id="a5a9c-144">Get settings one at a time</span></span>

<span data-ttu-id="a5a9c-145">設定は個別に取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-145">Settings can also be retrieved individually.</span></span>

**<span data-ttu-id="a5a9c-146">要求</span><span class="sxs-lookup"><span data-stu-id="a5a9c-146">Request</span></span>**

<span data-ttu-id="a5a9c-147">次の要求を使って、個別の設定に関する情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-147">You can use the following request to get information about an individual setting.</span></span>

<span data-ttu-id="a5a9c-148">メソッド</span><span class="sxs-lookup"><span data-stu-id="a5a9c-148">Method</span></span>      | <span data-ttu-id="a5a9c-149">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a5a9c-149">Request URI</span></span>
:------     | :-----
<span data-ttu-id="a5a9c-150">GET</span><span class="sxs-lookup"><span data-stu-id="a5a9c-150">GET</span></span> | <span data-ttu-id="a5a9c-151">/ext/settings/\<setting name\></span><span class="sxs-lookup"><span data-stu-id="a5a9c-151">/ext/settings/\<setting name\></span></span>

**<span data-ttu-id="a5a9c-152">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a5a9c-152">URI parameters</span></span>**

- <span data-ttu-id="a5a9c-153">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-153">None</span></span>

**<span data-ttu-id="a5a9c-154">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a5a9c-154">Request headers</span></span>**

- <span data-ttu-id="a5a9c-155">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-155">None</span></span>

**<span data-ttu-id="a5a9c-156">要求本文</span><span class="sxs-lookup"><span data-stu-id="a5a9c-156">Request body</span></span>**

- <span data-ttu-id="a5a9c-157">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-157">None</span></span>

**<span data-ttu-id="a5a9c-158">応答</span><span class="sxs-lookup"><span data-stu-id="a5a9c-158">Response</span></span>**   
<span data-ttu-id="a5a9c-159">応答は、次のフィールドを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-159">The response is a JSON object with following fields:</span></span>

* <span data-ttu-id="a5a9c-160">Name: (文字列) 設定の名前。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-160">Name - (String) The name of the setting.</span></span>
* <span data-ttu-id="a5a9c-161">Value: (文字列) 設定の値。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-161">Value - (String) The value of the setting.</span></span>
* <span data-ttu-id="a5a9c-162">RequiresReboot: ("Yes" | "No") このフィールドは、設定を有効にするために再起動する必要があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-162">RequiresReboot - ("Yes" | "No") This field indicates whether the setting requires a reboot to take effect.</span></span>
* <span data-ttu-id="a5a9c-163">Disabled - ("Yes" | "No") このフィールドは、設定が無効であるかどうかと編集不可であるかを示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-163">Disabled - ("Yes" | "No") This field indicates whether the setting is disabled and cannot be edited.</span></span>
* <span data-ttu-id="a5a9c-164">Category: (文字列) 設定のカテゴリ。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-164">Category - (String) The category of the setting.</span></span>
* <span data-ttu-id="a5a9c-165">Type - ("Text" | "Number" | "Bool" | "Select") このフィールドは、設定の型を示します。テキスト入力、ブール値 ("true" または "false")、最小値と最大値を持つ数値、値の特定のリストを持つ選択のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-165">Type - ("Text" | "Number" | "Bool" | "Select") This field indicates what type a setting is: text input, a boolean value ("true" or "false"), a number with a min and max or select with a specific list of values.</span></span>

<span data-ttu-id="a5a9c-166">設定が数値の場合。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-166">If the setting is a number:</span></span>

* <span data-ttu-id="a5a9c-167">Min (Number) このフィールドでは、設定の最小の数値を示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-167">Min - (Number) This field indicates the minimal numerical value of the setting.</span></span>
* <span data-ttu-id="a5a9c-168">最大の (数) このフィールドが設定の最大の数値を示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-168">Max - (Number) This field indicates the maximum numerical value of the setting.</span></span>

<span data-ttu-id="a5a9c-169">場合は、設定を選択します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-169">If the setting is select:</span></span>

* <span data-ttu-id="a5a9c-170">OptionsVariable - ([はい] |"No") このフィールドが再起動せず、有効なオプションを変更できる場合、変数は、設定オプションをかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-170">OptionsVariable - ("Yes" | "No") This field indicates whether the setting options are variable, if the valid options can change without a reboot.</span></span>
* <span data-ttu-id="a5a9c-171">Options - 有効な選択オプションを文字列として含む JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-171">Options - JSON array containing the valid select options as strings.</span></span>

**<span data-ttu-id="a5a9c-172">状態コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-172">Status code</span></span>**

<span data-ttu-id="a5a9c-173">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-173">This API has the following expected status codes.</span></span>

<span data-ttu-id="a5a9c-174">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-174">HTTP status code</span></span>      | <span data-ttu-id="a5a9c-175">説明</span><span class="sxs-lookup"><span data-stu-id="a5a9c-175">Description</span></span>
:------     | :-----
<span data-ttu-id="a5a9c-176">200</span><span class="sxs-lookup"><span data-stu-id="a5a9c-176">200</span></span> | <span data-ttu-id="a5a9c-177">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="a5a9c-177">Request was successful</span></span>
<span data-ttu-id="a5a9c-178">4XX</span><span class="sxs-lookup"><span data-stu-id="a5a9c-178">4XX</span></span> | <span data-ttu-id="a5a9c-179">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-179">Error codes</span></span>
<span data-ttu-id="a5a9c-180">5XX</span><span class="sxs-lookup"><span data-stu-id="a5a9c-180">5XX</span></span> | <span data-ttu-id="a5a9c-181">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-181">Error codes</span></span>

## <a name="set-the-value-of-a-setting"></a><span data-ttu-id="a5a9c-182">設定の値を設定する</span><span class="sxs-lookup"><span data-stu-id="a5a9c-182">Set the value of a setting</span></span>

<span data-ttu-id="a5a9c-183">設定の値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-183">You can set the value of a setting.</span></span>

**<span data-ttu-id="a5a9c-184">要求</span><span class="sxs-lookup"><span data-stu-id="a5a9c-184">Request</span></span>**

<span data-ttu-id="a5a9c-185">次の要求を使って、設定の値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-185">You can use the following request to set the value for a setting.</span></span>

<span data-ttu-id="a5a9c-186">メソッド</span><span class="sxs-lookup"><span data-stu-id="a5a9c-186">Method</span></span>      | <span data-ttu-id="a5a9c-187">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a5a9c-187">Request URI</span></span>
:------     | :-----
<span data-ttu-id="a5a9c-188">PUT</span><span class="sxs-lookup"><span data-stu-id="a5a9c-188">PUT</span></span> | <span data-ttu-id="a5a9c-189">/ext/settings/\<setting name\></span><span class="sxs-lookup"><span data-stu-id="a5a9c-189">/ext/settings/\<setting name\></span></span>

**<span data-ttu-id="a5a9c-190">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a5a9c-190">URI parameters</span></span>**

- <span data-ttu-id="a5a9c-191">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-191">None</span></span>

**<span data-ttu-id="a5a9c-192">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a5a9c-192">Request headers</span></span>**

- <span data-ttu-id="a5a9c-193">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-193">None</span></span>

**<span data-ttu-id="a5a9c-194">要求本文</span><span class="sxs-lookup"><span data-stu-id="a5a9c-194">Request body</span></span>**   
<span data-ttu-id="a5a9c-195">要求本文は、次のフィールドを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-195">The request body is JSON object containing the following field:</span></span>   
<span data-ttu-id="a5a9c-196">Value: (文字列) 設定の新しい値。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-196">Value - (String) The new value for the setting.</span></span>

**<span data-ttu-id="a5a9c-197">応答</span><span class="sxs-lookup"><span data-stu-id="a5a9c-197">Response</span></span>**   

- <span data-ttu-id="a5a9c-198">なし</span><span class="sxs-lookup"><span data-stu-id="a5a9c-198">None</span></span>

**<span data-ttu-id="a5a9c-199">状態コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-199">Status code</span></span>**

<span data-ttu-id="a5a9c-200">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a5a9c-200">This API has the following expected status codes.</span></span>

<span data-ttu-id="a5a9c-201">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-201">HTTP status code</span></span>      | <span data-ttu-id="a5a9c-202">説明</span><span class="sxs-lookup"><span data-stu-id="a5a9c-202">Description</span></span>
:------     | :-----
<span data-ttu-id="a5a9c-203">200</span><span class="sxs-lookup"><span data-stu-id="a5a9c-203">200</span></span> | <span data-ttu-id="a5a9c-204">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="a5a9c-204">Request was successful</span></span>
<span data-ttu-id="a5a9c-205">4XX</span><span class="sxs-lookup"><span data-stu-id="a5a9c-205">4XX</span></span> | <span data-ttu-id="a5a9c-206">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-206">Error codes</span></span>
<span data-ttu-id="a5a9c-207">5XX</span><span class="sxs-lookup"><span data-stu-id="a5a9c-207">5XX</span></span> | <span data-ttu-id="a5a9c-208">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a5a9c-208">Error codes</span></span>

**<span data-ttu-id="a5a9c-209">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="a5a9c-209">Available device families</span></span>**

* <span data-ttu-id="a5a9c-210">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="a5a9c-210">Windows Xbox</span></span>