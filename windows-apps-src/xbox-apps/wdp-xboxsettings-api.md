---
author: m-stahl
title: Device Portal の Xbox 開発者向け設定 API のリファレンス
description: Xbox 開発者向け設定にアクセスする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 6ab12b99-2944-49c9-92d9-f995efc4f6ce
ms.localizationpriority: medium
ms.openlocfilehash: 8f3d0c09b242f8d60b06ee0dc510ad9a756466c5
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6991949"
---
# <a name="developer-settings-api-reference"></a><span data-ttu-id="63790-104">開発者向け設定 API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="63790-104">Developer settings API reference</span></span>   
<span data-ttu-id="63790-105">この API を使用して、開発に役立つ Xbox One 設定にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="63790-105">You can access Xbox One settings that are useful for development using this API.</span></span>

## <a name="get-all-developer-settings-at-once"></a><span data-ttu-id="63790-106">すべての開発者向け設定を一度に取得する</span><span class="sxs-lookup"><span data-stu-id="63790-106">Get all developer settings at once</span></span>

**<span data-ttu-id="63790-107">要求</span><span class="sxs-lookup"><span data-stu-id="63790-107">Request</span></span>**

<span data-ttu-id="63790-108">次の要求を使用して、すべての開発者向け設定を 1 つの要求で取得できます。</span><span class="sxs-lookup"><span data-stu-id="63790-108">You can use the following request to get all developer settings in a single request.</span></span>

<span data-ttu-id="63790-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="63790-109">Method</span></span>      | <span data-ttu-id="63790-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="63790-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="63790-111">GET</span><span class="sxs-lookup"><span data-stu-id="63790-111">GET</span></span> | <span data-ttu-id="63790-112">/ext/settings</span><span class="sxs-lookup"><span data-stu-id="63790-112">/ext/settings</span></span>
<br />
**<span data-ttu-id="63790-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="63790-113">URI parameters</span></span>**

- <span data-ttu-id="63790-114">なし</span><span class="sxs-lookup"><span data-stu-id="63790-114">None</span></span>

**<span data-ttu-id="63790-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="63790-115">Request headers</span></span>**

- <span data-ttu-id="63790-116">なし</span><span class="sxs-lookup"><span data-stu-id="63790-116">None</span></span>

**<span data-ttu-id="63790-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="63790-117">Request body</span></span>**

- <span data-ttu-id="63790-118">なし</span><span class="sxs-lookup"><span data-stu-id="63790-118">None</span></span>

**<span data-ttu-id="63790-119">応答</span><span class="sxs-lookup"><span data-stu-id="63790-119">Response</span></span>**   
<span data-ttu-id="63790-120">応答は、すべての設定を含む設定の JSON 配列です。</span><span class="sxs-lookup"><span data-stu-id="63790-120">The response is a Settings JSON array containing all the settings.</span></span> <span data-ttu-id="63790-121">設定オブジェクトには、それぞれ次のフィールドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="63790-121">Each settings object contains the following fields:</span></span>

* <span data-ttu-id="63790-122">Name: (文字列) 設定の名前。</span><span class="sxs-lookup"><span data-stu-id="63790-122">Name - (String) The name of the setting.</span></span>
* <span data-ttu-id="63790-123">Value: (文字列) 設定の値。</span><span class="sxs-lookup"><span data-stu-id="63790-123">Value - (String) The value of the setting.</span></span>
* <span data-ttu-id="63790-124">RequiresReboot: ("Yes" | "No") このフィールドは、設定を有効にするために再起動する必要があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="63790-124">RequiresReboot - ("Yes" | "No") This field indicates whether the setting requires a reboot to take effect.</span></span>
* <span data-ttu-id="63790-125">Disabled - ("Yes" | "No") このフィールドは、設定が無効であるかどうかと編集不可であるかを示します。</span><span class="sxs-lookup"><span data-stu-id="63790-125">Disabled - ("Yes" | "No") This field indicates whether the setting is disabled and cannot be edited.</span></span>
* <span data-ttu-id="63790-126">Category: (文字列) 設定のカテゴリ。</span><span class="sxs-lookup"><span data-stu-id="63790-126">Category - (String) The category of the setting.</span></span>
* <span data-ttu-id="63790-127">Type - ("Text" | "Number" | "Bool" | "Select") このフィールドは、設定の型を示します。テキスト入力、ブール値 ("true" または "false")、最小値と最大値を持つ数値、値の特定のリストを持つ選択のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="63790-127">Type - ("Text" | "Number" | "Bool" | "Select") This field indicates what type a setting is: text input, a boolean value ("true" or "false"), a number with a min and max or select with a specific list of values.</span></span>

<span data-ttu-id="63790-128">設定が、多くの場合。</span><span class="sxs-lookup"><span data-stu-id="63790-128">If the setting is a number:</span></span>
* <span data-ttu-id="63790-129">Min - (数値) このフィールドは、設定の最小限の数値を示します。</span><span class="sxs-lookup"><span data-stu-id="63790-129">Min - (Number) This field indicates the minimal numerical value of the setting.</span></span>
* <span data-ttu-id="63790-130">Max - (数値) このフィールドは、設定の最大の数値を示します。</span><span class="sxs-lookup"><span data-stu-id="63790-130">Max - (Number) This field indicates the maximum numerical value of the setting.</span></span>

<span data-ttu-id="63790-131">設定を選択します。</span><span class="sxs-lookup"><span data-stu-id="63790-131">If the setting is select:</span></span>
* <span data-ttu-id="63790-132">OptionsVariable - ("Yes"|"No") このフィールドを示すかどうか、オプションの設定、変数場合は、再起動しなくても有効なオプションを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="63790-132">OptionsVariable - ("Yes" | "No") This field indicates whether the setting options are variable, if the valid options can change without a reboot.</span></span>
* <span data-ttu-id="63790-133">Options - 有効な選択オプションを文字列として含む JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="63790-133">Options - JSON array containing the valid select options as strings.</span></span>

**<span data-ttu-id="63790-134">状態コード</span><span class="sxs-lookup"><span data-stu-id="63790-134">Status code</span></span>**

<span data-ttu-id="63790-135">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="63790-135">This API has the following expected status codes.</span></span>

<span data-ttu-id="63790-136">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="63790-136">HTTP status code</span></span>      | <span data-ttu-id="63790-137">説明</span><span class="sxs-lookup"><span data-stu-id="63790-137">Description</span></span>
:------     | :-----
<span data-ttu-id="63790-138">200</span><span class="sxs-lookup"><span data-stu-id="63790-138">200</span></span> | <span data-ttu-id="63790-139">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="63790-139">Request was successful</span></span>
<span data-ttu-id="63790-140">4XX</span><span class="sxs-lookup"><span data-stu-id="63790-140">4XX</span></span> | <span data-ttu-id="63790-141">エラー コード</span><span class="sxs-lookup"><span data-stu-id="63790-141">Error codes</span></span>
<span data-ttu-id="63790-142">5XX</span><span class="sxs-lookup"><span data-stu-id="63790-142">5XX</span></span> | <span data-ttu-id="63790-143">エラー コード</span><span class="sxs-lookup"><span data-stu-id="63790-143">Error codes</span></span>

## <a name="get-settings-one-at-a-time"></a><span data-ttu-id="63790-144">設定を一度に 1 つ取得する</span><span class="sxs-lookup"><span data-stu-id="63790-144">Get settings one at a time</span></span>
<span data-ttu-id="63790-145">設定は個別に取得することもできます。</span><span class="sxs-lookup"><span data-stu-id="63790-145">Settings can also be retrieved individually.</span></span>

**<span data-ttu-id="63790-146">要求</span><span class="sxs-lookup"><span data-stu-id="63790-146">Request</span></span>**

<span data-ttu-id="63790-147">次の要求を使って、個別の設定に関する情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="63790-147">You can use the following request to get information about an individual setting.</span></span>

<span data-ttu-id="63790-148">メソッド</span><span class="sxs-lookup"><span data-stu-id="63790-148">Method</span></span>      | <span data-ttu-id="63790-149">要求 URI</span><span class="sxs-lookup"><span data-stu-id="63790-149">Request URI</span></span>
:------     | :-----
<span data-ttu-id="63790-150">GET</span><span class="sxs-lookup"><span data-stu-id="63790-150">GET</span></span> | <span data-ttu-id="63790-151">/ext/settings/\<設定名\></span><span class="sxs-lookup"><span data-stu-id="63790-151">/ext/settings/\<setting name\></span></span>
<br />
**<span data-ttu-id="63790-152">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="63790-152">URI parameters</span></span>**

- <span data-ttu-id="63790-153">なし</span><span class="sxs-lookup"><span data-stu-id="63790-153">None</span></span>

**<span data-ttu-id="63790-154">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="63790-154">Request headers</span></span>**

- <span data-ttu-id="63790-155">なし</span><span class="sxs-lookup"><span data-stu-id="63790-155">None</span></span>

**<span data-ttu-id="63790-156">要求本文</span><span class="sxs-lookup"><span data-stu-id="63790-156">Request body</span></span>**

- <span data-ttu-id="63790-157">なし</span><span class="sxs-lookup"><span data-stu-id="63790-157">None</span></span>

**<span data-ttu-id="63790-158">応答</span><span class="sxs-lookup"><span data-stu-id="63790-158">Response</span></span>**   
<span data-ttu-id="63790-159">応答は、次のフィールドを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="63790-159">The response is a JSON object with following fields:</span></span>

* <span data-ttu-id="63790-160">Name: (文字列) 設定の名前。</span><span class="sxs-lookup"><span data-stu-id="63790-160">Name - (String) The name of the setting.</span></span>
* <span data-ttu-id="63790-161">Value: (文字列) 設定の値。</span><span class="sxs-lookup"><span data-stu-id="63790-161">Value - (String) The value of the setting.</span></span>
* <span data-ttu-id="63790-162">RequiresReboot: ("Yes" | "No") このフィールドは、設定を有効にするために再起動する必要があるかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="63790-162">RequiresReboot - ("Yes" | "No") This field indicates whether the setting requires a reboot to take effect.</span></span>
* <span data-ttu-id="63790-163">Disabled - ("Yes" | "No") このフィールドは、設定が無効であるかどうかと編集不可であるかを示します。</span><span class="sxs-lookup"><span data-stu-id="63790-163">Disabled - ("Yes" | "No") This field indicates whether the setting is disabled and cannot be edited.</span></span>
* <span data-ttu-id="63790-164">Category: (文字列) 設定のカテゴリ。</span><span class="sxs-lookup"><span data-stu-id="63790-164">Category - (String) The category of the setting.</span></span>
* <span data-ttu-id="63790-165">Type - ("Text" | "Number" | "Bool" | "Select") このフィールドは、設定の型を示します。テキスト入力、ブール値 ("true" または "false")、最小値と最大値を持つ数値、値の特定のリストを持つ選択のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="63790-165">Type - ("Text" | "Number" | "Bool" | "Select") This field indicates what type a setting is: text input, a boolean value ("true" or "false"), a number with a min and max or select with a specific list of values.</span></span>

<span data-ttu-id="63790-166">設定が、多くの場合。</span><span class="sxs-lookup"><span data-stu-id="63790-166">If the setting is a number:</span></span>
* <span data-ttu-id="63790-167">Min - (数値) このフィールドは、設定の最小限の数値を示します。</span><span class="sxs-lookup"><span data-stu-id="63790-167">Min - (Number) This field indicates the minimal numerical value of the setting.</span></span>
* <span data-ttu-id="63790-168">Max - (数値) このフィールドは、設定の最大の数値を示します。</span><span class="sxs-lookup"><span data-stu-id="63790-168">Max - (Number) This field indicates the maximum numerical value of the setting.</span></span>

<span data-ttu-id="63790-169">設定を選択します。</span><span class="sxs-lookup"><span data-stu-id="63790-169">If the setting is select:</span></span>
* <span data-ttu-id="63790-170">OptionsVariable - ("Yes"|"No") このフィールドを示すかどうか、オプションの設定、変数場合は、再起動しなくても有効なオプションを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="63790-170">OptionsVariable - ("Yes" | "No") This field indicates whether the setting options are variable, if the valid options can change without a reboot.</span></span>
* <span data-ttu-id="63790-171">Options - 有効な選択オプションを文字列として含む JSON 配列。</span><span class="sxs-lookup"><span data-stu-id="63790-171">Options - JSON array containing the valid select options as strings.</span></span>

**<span data-ttu-id="63790-172">状態コード</span><span class="sxs-lookup"><span data-stu-id="63790-172">Status code</span></span>**

<span data-ttu-id="63790-173">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="63790-173">This API has the following expected status codes.</span></span>

<span data-ttu-id="63790-174">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="63790-174">HTTP status code</span></span>      | <span data-ttu-id="63790-175">説明</span><span class="sxs-lookup"><span data-stu-id="63790-175">Description</span></span>
:------     | :-----
<span data-ttu-id="63790-176">200</span><span class="sxs-lookup"><span data-stu-id="63790-176">200</span></span> | <span data-ttu-id="63790-177">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="63790-177">Request was successful</span></span>
<span data-ttu-id="63790-178">4XX</span><span class="sxs-lookup"><span data-stu-id="63790-178">4XX</span></span> | <span data-ttu-id="63790-179">エラー コード</span><span class="sxs-lookup"><span data-stu-id="63790-179">Error codes</span></span>
<span data-ttu-id="63790-180">5XX</span><span class="sxs-lookup"><span data-stu-id="63790-180">5XX</span></span> | <span data-ttu-id="63790-181">エラー コード</span><span class="sxs-lookup"><span data-stu-id="63790-181">Error codes</span></span>

## <a name="set-the-value-of-a-setting"></a><span data-ttu-id="63790-182">設定の値を設定する</span><span class="sxs-lookup"><span data-stu-id="63790-182">Set the value of a setting</span></span>
<span data-ttu-id="63790-183">設定の値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="63790-183">You can set the value of a setting.</span></span>

**<span data-ttu-id="63790-184">要求</span><span class="sxs-lookup"><span data-stu-id="63790-184">Request</span></span>**

<span data-ttu-id="63790-185">次の要求を使って、設定の値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="63790-185">You can use the following request to set the value for a setting.</span></span>

<span data-ttu-id="63790-186">メソッド</span><span class="sxs-lookup"><span data-stu-id="63790-186">Method</span></span>      | <span data-ttu-id="63790-187">要求 URI</span><span class="sxs-lookup"><span data-stu-id="63790-187">Request URI</span></span>
:------     | :-----
<span data-ttu-id="63790-188">PUT</span><span class="sxs-lookup"><span data-stu-id="63790-188">PUT</span></span> | <span data-ttu-id="63790-189">/ext/settings/\<設定名\></span><span class="sxs-lookup"><span data-stu-id="63790-189">/ext/settings/\<setting name\></span></span>
<br />
**<span data-ttu-id="63790-190">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="63790-190">URI parameters</span></span>**

- <span data-ttu-id="63790-191">なし</span><span class="sxs-lookup"><span data-stu-id="63790-191">None</span></span>

**<span data-ttu-id="63790-192">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="63790-192">Request headers</span></span>**

- <span data-ttu-id="63790-193">なし</span><span class="sxs-lookup"><span data-stu-id="63790-193">None</span></span>

**<span data-ttu-id="63790-194">要求本文</span><span class="sxs-lookup"><span data-stu-id="63790-194">Request body</span></span>**   
<span data-ttu-id="63790-195">要求本文は、次のフィールドを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="63790-195">The request body is JSON object containing the following field:</span></span>   
<span data-ttu-id="63790-196">Value: (文字列) 設定の新しい値。</span><span class="sxs-lookup"><span data-stu-id="63790-196">Value - (String) The new value for the setting.</span></span>

**<span data-ttu-id="63790-197">応答</span><span class="sxs-lookup"><span data-stu-id="63790-197">Response</span></span>**   

- <span data-ttu-id="63790-198">なし</span><span class="sxs-lookup"><span data-stu-id="63790-198">None</span></span>

**<span data-ttu-id="63790-199">状態コード</span><span class="sxs-lookup"><span data-stu-id="63790-199">Status code</span></span>**

<span data-ttu-id="63790-200">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="63790-200">This API has the following expected status codes.</span></span>

<span data-ttu-id="63790-201">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="63790-201">HTTP status code</span></span>      | <span data-ttu-id="63790-202">説明</span><span class="sxs-lookup"><span data-stu-id="63790-202">Description</span></span>
:------     | :-----
<span data-ttu-id="63790-203">200</span><span class="sxs-lookup"><span data-stu-id="63790-203">200</span></span> | <span data-ttu-id="63790-204">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="63790-204">Request was successful</span></span>
<span data-ttu-id="63790-205">4XX</span><span class="sxs-lookup"><span data-stu-id="63790-205">4XX</span></span> | <span data-ttu-id="63790-206">エラー コード</span><span class="sxs-lookup"><span data-stu-id="63790-206">Error codes</span></span>
<span data-ttu-id="63790-207">5XX</span><span class="sxs-lookup"><span data-stu-id="63790-207">5XX</span></span> | <span data-ttu-id="63790-208">エラー コード</span><span class="sxs-lookup"><span data-stu-id="63790-208">Error codes</span></span>

<br />
**<span data-ttu-id="63790-209">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="63790-209">Available device families</span></span>**

* <span data-ttu-id="63790-210">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="63790-210">Windows Xbox</span></span>