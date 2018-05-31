---
author: mcleanbyron
description: Xbox Live の分析データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live の分析データの取得
ms.author: mcleans
ms.date: 04/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析
ms.localizationpriority: medium
ms.openlocfilehash: 82c24ee285070d733f3310b4ccec210adeafc27f
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1817270"
---
# <a name="get-xbox-live-analytics-data"></a><span data-ttu-id="19850-104">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-104">Get Xbox Live analytics data</span></span>

<span data-ttu-id="19850-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)をプレイしているユーザーに関する過去 30 日間の一般的な分析データを取得するには、Microsoft Store 分析 API の次のメソッドを使います。取得できるデータには、デバイス アクセサリの使用状況、インターネット接続の種類、ゲーマースコアの分布、ゲームの統計情報、フレンドとフォロワーのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-105">Use this method in the Microsoft Store analytics API to get the last 30 days of general analytics data for customers playing your [Xbox Live-enabled game](../xbox-live/index.md), including device accessory usage, internet connection type, gamerscore distribution, game statistics, and friends and followers data.</span></span> <span data-ttu-id="19850-106">この情報は、Windows デベロッパー センター ダッシュボードの [Xbox 分析レポート](../publish/xbox-analytics-report.md)でも確認できます。</span><span class="sxs-lookup"><span data-stu-id="19850-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in the Windows Dev Center dashboard.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="19850-107">現在このメソッドがサポートしているのは、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)によって公開された Xbox Live 対応ゲーム、または [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)経由で提出された Xbox Live 対応ゲームだけです。</span><span class="sxs-lookup"><span data-stu-id="19850-107">This method currently only supports Xbox Live-enabled games that are published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) or that are submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="19850-108">[Xbox Live クリエーターズ プログラム](../xbox-live/developer-program-overview.md#xbox-live-creators-program)経由で提出されたゲームのデータは返されません。</span><span class="sxs-lookup"><span data-stu-id="19850-108">It does not return data for games that were submitted via the [Xbox Live Creators Program](../xbox-live/developer-program-overview.md#xbox-live-creators-program).</span></span>

<span data-ttu-id="19850-109">Xbox Live 対応ゲームに関するその他の分析データは、次のメソッドを通じて取得できます。</span><span class="sxs-lookup"><span data-stu-id="19850-109">Additional analytics data for Xbox Live-enabled games is available via the following methods:</span></span>
* [<span data-ttu-id="19850-110">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-110">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="19850-111">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-111">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="19850-112">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="19850-112">Get Xbox Live Game Hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="19850-113">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="19850-113">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="19850-114">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-114">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
* [<span data-ttu-id="19850-115">Xbox Live の同時使用状況データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-115">Get Xbox Live concurrent usage data</span></span>](get-xbox-live-concurrent-usage-data.md)

## <a name="prerequisites"></a><span data-ttu-id="19850-116">前提条件</span><span class="sxs-lookup"><span data-stu-id="19850-116">Prerequisites</span></span>

<span data-ttu-id="19850-117">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="19850-117">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="19850-118">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="19850-118">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="19850-119">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="19850-119">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="19850-120">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="19850-120">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="19850-121">トークンの有効期限が切れたら新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="19850-121">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="19850-122">要求</span><span class="sxs-lookup"><span data-stu-id="19850-122">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="19850-123">要求の構文</span><span class="sxs-lookup"><span data-stu-id="19850-123">Request syntax</span></span>

| <span data-ttu-id="19850-124">メソッド</span><span class="sxs-lookup"><span data-stu-id="19850-124">Method</span></span> | <span data-ttu-id="19850-125">要求 URI</span><span class="sxs-lookup"><span data-stu-id="19850-125">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="19850-126">GET</span><span class="sxs-lookup"><span data-stu-id="19850-126">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="19850-127">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="19850-127">Request header</span></span>

| <span data-ttu-id="19850-128">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="19850-128">Header</span></span>        | <span data-ttu-id="19850-129">型</span><span class="sxs-lookup"><span data-stu-id="19850-129">Type</span></span>   | <span data-ttu-id="19850-130">説明</span><span class="sxs-lookup"><span data-stu-id="19850-130">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="19850-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="19850-131">Authorization</span></span> | <span data-ttu-id="19850-132">文字列</span><span class="sxs-lookup"><span data-stu-id="19850-132">string</span></span> | <span data-ttu-id="19850-133">必須。</span><span class="sxs-lookup"><span data-stu-id="19850-133">Required.</span></span> <span data-ttu-id="19850-134">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="19850-134">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="19850-135">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="19850-135">Request parameters</span></span>

| <span data-ttu-id="19850-136">パラメーター</span><span class="sxs-lookup"><span data-stu-id="19850-136">Parameter</span></span>        | <span data-ttu-id="19850-137">型</span><span class="sxs-lookup"><span data-stu-id="19850-137">Type</span></span>   |  <span data-ttu-id="19850-138">説明</span><span class="sxs-lookup"><span data-stu-id="19850-138">Description</span></span>      |  <span data-ttu-id="19850-139">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="19850-139">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="19850-140">applicationId</span><span class="sxs-lookup"><span data-stu-id="19850-140">applicationId</span></span> | <span data-ttu-id="19850-141">string</span><span class="sxs-lookup"><span data-stu-id="19850-141">string</span></span> | <span data-ttu-id="19850-142">Xbox Live の分析データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="19850-142">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve general Xbox Live analytics data.</span></span>  |  <span data-ttu-id="19850-143">必須</span><span class="sxs-lookup"><span data-stu-id="19850-143">Yes</span></span>  |
| <span data-ttu-id="19850-144">metricType</span><span class="sxs-lookup"><span data-stu-id="19850-144">metricType</span></span> | <span data-ttu-id="19850-145">string</span><span class="sxs-lookup"><span data-stu-id="19850-145">string</span></span> | <span data-ttu-id="19850-146">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="19850-146">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="19850-147">このメソッドでは、値 **productvalues** を指定します。</span><span class="sxs-lookup"><span data-stu-id="19850-147">For this method, specify the value **productvalues**.</span></span>  |  <span data-ttu-id="19850-148">必須</span><span class="sxs-lookup"><span data-stu-id="19850-148">Yes</span></span>  |


### <a name="request-example"></a><span data-ttu-id="19850-149">要求の例</span><span class="sxs-lookup"><span data-stu-id="19850-149">Request example</span></span>

<span data-ttu-id="19850-150">次の例では、Xbox Live 対応ゲームをプレイしているユーザーに関する一般的な分析データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-150">The following example demonstrates a request for getting general analytics data for customers playing your Xbox Live-enabled game.</span></span> <span data-ttu-id="19850-151">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="19850-151">Replace the *applicationId* value with the Store ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=productvalues HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="19850-152">応答</span><span class="sxs-lookup"><span data-stu-id="19850-152">Response</span></span>

<span data-ttu-id="19850-153">このメソッドは、次のオブジェクトを含む *Value* 配列を返します。</span><span class="sxs-lookup"><span data-stu-id="19850-153">This method returns a *Value* array that contains the following objects.</span></span>

| <span data-ttu-id="19850-154">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="19850-154">Object</span></span>      | <span data-ttu-id="19850-155">説明</span><span class="sxs-lookup"><span data-stu-id="19850-155">Description</span></span>                  |
|-------------|---------------------------------------------------|
| <span data-ttu-id="19850-156">ProductData</span><span class="sxs-lookup"><span data-stu-id="19850-156">ProductData</span></span>   |   <span data-ttu-id="19850-157">1 つの [DeviceProperties](#deviceproperties) オブジェクトと 1 つの [UserProperties](#userproperties) オブジェクトが含まれます。それぞれには、対象ゲームに関する過去 30 日間のデバイス分析データとユーザー分析データが格納されます。</span><span class="sxs-lookup"><span data-stu-id="19850-157">Contains one [DeviceProperties](#deviceproperties) object and one [UserProperties](#userproperties) object that contain the last 30 days of device and user analytics data for your game.</span></span>    |  
| <span data-ttu-id="19850-158">XboxwideData</span><span class="sxs-lookup"><span data-stu-id="19850-158">XboxwideData</span></span>   |  <span data-ttu-id="19850-159">1 つの [DeviceProperties](#deviceproperties) オブジェクトと 1 つの [UserProperties](#userproperties) オブジェクトが含まれます。それぞれには、すべての Xbox Live ユーザーを対象とした過去 30 日間の平均的なデバイス分析データとユーザー分析データが、パーセンテージとして格納されます。</span><span class="sxs-lookup"><span data-stu-id="19850-159">Contains one [DeviceProperties](#deviceproperties) object and one [UserProperties](#userproperties) object that contain the last 30 days of average device and user analytics data for all Xbox Live customers, as percentages.</span></span> <span data-ttu-id="19850-160">このデータは、対象ゲームのデータとの比較のために用意されています。</span><span class="sxs-lookup"><span data-stu-id="19850-160">This data is included for comparison purposes with the data for your game.</span></span>   |                                           


### <a name="deviceproperties"></a><span data-ttu-id="19850-161">DeviceProperties</span><span class="sxs-lookup"><span data-stu-id="19850-161">DeviceProperties</span></span>

<span data-ttu-id="19850-162">このリソースには、過去 30 日間について、対象ゲームに関するデバイス使用状況データ、またはすべての Xbox Live ユーザーを対象とした平均的なデバイス使用状況データが格納されます。</span><span class="sxs-lookup"><span data-stu-id="19850-162">This resource contains device usage data for your game or average device usage data for all Xbox Live customers during the last 30 days.</span></span>

| <span data-ttu-id="19850-163">値</span><span class="sxs-lookup"><span data-stu-id="19850-163">Value</span></span>           | <span data-ttu-id="19850-164">型</span><span class="sxs-lookup"><span data-stu-id="19850-164">Type</span></span>    | <span data-ttu-id="19850-165">説明</span><span class="sxs-lookup"><span data-stu-id="19850-165">Description</span></span>        |
|-----------------|---------|------|
|  <span data-ttu-id="19850-166">applicationId</span><span class="sxs-lookup"><span data-stu-id="19850-166">applicationId</span></span>               |    <span data-ttu-id="19850-167">string</span><span class="sxs-lookup"><span data-stu-id="19850-167">string</span></span>     |  <span data-ttu-id="19850-168">分析データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="19850-168">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you retrieved analytics data.</span></span>   |
|  <span data-ttu-id="19850-169">connectionTypeDistribution</span><span class="sxs-lookup"><span data-stu-id="19850-169">connectionTypeDistribution</span></span>               |    <span data-ttu-id="19850-170">array</span><span class="sxs-lookup"><span data-stu-id="19850-170">array</span></span>     |   <span data-ttu-id="19850-171">Xbox でワイヤード (有線) インターネット接続とワイヤレス インターネット接続を使っているユーザーの数を示すオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-171">Contains objects that indicate how many customers use a wired internet connection versus a wireless internet connection on Xbox.</span></span> <span data-ttu-id="19850-172">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="19850-172">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="19850-173">**conType**: 接続の種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="19850-173">**conType**: Specifies the connection type.</span></span></li><li><span data-ttu-id="19850-174">**deviceCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定の接続の種類を使っているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-174">**deviceCount**: In the **ProductData** object, this field specifies the number of your game's customers that use the connection type.</span></span> <span data-ttu-id="19850-175">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定の接続の種類を使っているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-175">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that use the connection type.</span></span></li></ul>   |     
|  <span data-ttu-id="19850-176">deviceCount</span><span class="sxs-lookup"><span data-stu-id="19850-176">deviceCount</span></span>               |   <span data-ttu-id="19850-177">string</span><span class="sxs-lookup"><span data-stu-id="19850-177">string</span></span>      |  <span data-ttu-id="19850-178">**ProductData** オブジェクトの場合、このフィールドは、過去 30 日間に対象ゲームがプレイされたユーザー デバイスの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-178">In the **ProductData** object, this field specifies the number of customer devices on which your game has been played during the last 30 days.</span></span> <span data-ttu-id="19850-179">**XboxwideData** オブジェクトの場合、このフィールドは常に 1 になり、すべての Xbox Live ユーザーを対象としたデータの開始パーセンテージである 100% を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-179">In the **XboxwideData** object, this field is always 1, indicating a starting percentage of 100% for data for all Xbox Live customers.</span></span>   |     
|  <span data-ttu-id="19850-180">eliteControllerPresentDeviceCount</span><span class="sxs-lookup"><span data-stu-id="19850-180">eliteControllerPresentDeviceCount</span></span>               |   <span data-ttu-id="19850-181">string</span><span class="sxs-lookup"><span data-stu-id="19850-181">string</span></span>      |  <span data-ttu-id="19850-182">**ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、Xbox Elite ワイヤレス コントローラーを使っているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-182">In the **ProductData** object, this field specifies the number of your game's customers that use the Xbox Elite Wireless Controller.</span></span> <span data-ttu-id="19850-183">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、Xbox Elite ワイヤレス コントローラーを使っているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-183">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that use the Xbox Elite Wireless Controller.</span></span>  |     
|  <span data-ttu-id="19850-184">externalDrivePresentDeviceCount</span><span class="sxs-lookup"><span data-stu-id="19850-184">externalDrivePresentDeviceCount</span></span>               |   <span data-ttu-id="19850-185">string</span><span class="sxs-lookup"><span data-stu-id="19850-185">string</span></span>      |  <span data-ttu-id="19850-186">**ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、Xbox で外部ハード ドライブを使っているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-186">In the **ProductData** object, this field specifies the number of your game's customers that use an external hard drive on Xbox.</span></span> <span data-ttu-id="19850-187">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、Xbox で外部ハード ドライブを使っているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-187">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that use an external hard drive on Xbox.</span></span>  |


### <a name="userproperties"></a><span data-ttu-id="19850-188">UserProperties</span><span class="sxs-lookup"><span data-stu-id="19850-188">UserProperties</span></span>

<span data-ttu-id="19850-189">このリソースには、過去 30 日間について、対象ゲームに関するユーザー データ、またはすべての Xbox Live ユーザーを対象とした平均的なユーザー データが格納されます。</span><span class="sxs-lookup"><span data-stu-id="19850-189">This resource contains user data for your game or average user data for all Xbox Live customers during the last 30 days.</span></span>

| <span data-ttu-id="19850-190">値</span><span class="sxs-lookup"><span data-stu-id="19850-190">Value</span></span>           | <span data-ttu-id="19850-191">型</span><span class="sxs-lookup"><span data-stu-id="19850-191">Type</span></span>    | <span data-ttu-id="19850-192">説明</span><span class="sxs-lookup"><span data-stu-id="19850-192">Description</span></span>        |
|-----------------|---------|------|
|  <span data-ttu-id="19850-193">applicationId</span><span class="sxs-lookup"><span data-stu-id="19850-193">applicationId</span></span>               |    <span data-ttu-id="19850-194">string</span><span class="sxs-lookup"><span data-stu-id="19850-194">string</span></span>     |   <span data-ttu-id="19850-195">分析データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="19850-195">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you retrieved analytics data.</span></span>  |
|  <span data-ttu-id="19850-196">userCount</span><span class="sxs-lookup"><span data-stu-id="19850-196">userCount</span></span>               |    <span data-ttu-id="19850-197">string</span><span class="sxs-lookup"><span data-stu-id="19850-197">string</span></span>     |   <span data-ttu-id="19850-198">**ProductData** オブジェクトの場合、このフィールドは、過去 30 日間に対象ゲームをプレイしたユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-198">In the **ProductData** object, this field specifies the number of customers that have played your game during the last 30 days.</span></span> <span data-ttu-id="19850-199">**XboxwideData** オブジェクトの場合、このフィールドは常に 1 になり、すべての Xbox Live ユーザーを対象としたデータの開始パーセンテージである 100% を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-199">In the **XboxwideData** object, this field is always 1, indicating a starting percentage of 100% for data for all Xbox Live customers.</span></span>   |     
|  <span data-ttu-id="19850-200">dvrUsageCounts</span><span class="sxs-lookup"><span data-stu-id="19850-200">dvrUsageCounts</span></span>               |   <span data-ttu-id="19850-201">array</span><span class="sxs-lookup"><span data-stu-id="19850-201">array</span></span>      |  <span data-ttu-id="19850-202">ゲーム録画を使ってゲームプレイを録画および表示したユーザーの数を示すオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-202">Contains objects that indicate how many customers have used game DVR to record and view gameplay.</span></span> <span data-ttu-id="19850-203">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="19850-203">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="19850-204">**dvrName**: 使用されたゲーム録画機能を指定します。</span><span class="sxs-lookup"><span data-stu-id="19850-204">**dvrName**: Specifies the game DVR feature used.</span></span> <span data-ttu-id="19850-205">取り得る値は、**gameClipUploads**、**gameClipViews**、**screenshotUploads**、**screenshotViews** です。</span><span class="sxs-lookup"><span data-stu-id="19850-205">Possible values are **gameClipUploads**, **gameClipViews**, **screenshotUploads**, and **screenshotViews**.</span></span></li><li><span data-ttu-id="19850-206">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定のゲーム録画機能を使用したユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-206">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that used the specified game DVR feature.</span></span> <span data-ttu-id="19850-207">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定のゲーム録画機能を使用したユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-207">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that used the specified game DVR feature.</span></span></li></ul>   |     
|  <span data-ttu-id="19850-208">followerCountPercentiles</span><span class="sxs-lookup"><span data-stu-id="19850-208">followerCountPercentiles</span></span>               |   <span data-ttu-id="19850-209">array</span><span class="sxs-lookup"><span data-stu-id="19850-209">array</span></span>      |  <span data-ttu-id="19850-210">ユーザーのフォロワー数に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-210">Contains objects that provide details about the number of followers for customers.</span></span> <span data-ttu-id="19850-211">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="19850-211">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="19850-212">**percentage**: 現在、この値は常に 50 になり、フォロワー データが中央値として提供されることを示します。</span><span class="sxs-lookup"><span data-stu-id="19850-212">**percentage**: Currently, this value is always 50, indicating that the follower data is provided as a median value.</span></span></li><li><span data-ttu-id="19850-213">**value**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのフォロワー数の中央値を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-213">**value**: In the **ProductData** object, this field specifies the median number of followers for your game's customers.</span></span> <span data-ttu-id="19850-214">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのフォロワー数の中央値を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-214">In the **XboxwideData** object, this field specifies the median number of followers for all Xbox Live customers.</span></span></li></ul>  |   
|  <span data-ttu-id="19850-215">friendCountPercentiles</span><span class="sxs-lookup"><span data-stu-id="19850-215">friendCountPercentiles</span></span>               |   <span data-ttu-id="19850-216">array</span><span class="sxs-lookup"><span data-stu-id="19850-216">array</span></span>      |  <span data-ttu-id="19850-217">ユーザーのフレンド数に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-217">Contains objects that provide details about the number of friends for customers.</span></span> <span data-ttu-id="19850-218">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="19850-218">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="19850-219">**percentage**: 現在、この値は常に 50 になり、フレンド データが中央値として提供されることを示します。</span><span class="sxs-lookup"><span data-stu-id="19850-219">**percentage**: Currently, this value is always 50, indicating that the friends data is provided as a median value.</span></span></li><li><span data-ttu-id="19850-220">**value**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのフレンド数の中央値を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-220">**value**: In the **ProductData** object, this field specifies the median number of friends for your game's customers.</span></span> <span data-ttu-id="19850-221">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのフレンド数の中央値を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-221">In the **XboxwideData** object, this field specifies the median number of friends for all Xbox Live customers.</span></span></li></ul>  |     
|  <span data-ttu-id="19850-222">gamerScoreRangeDistribution</span><span class="sxs-lookup"><span data-stu-id="19850-222">gamerScoreRangeDistribution</span></span>               |   <span data-ttu-id="19850-223">array</span><span class="sxs-lookup"><span data-stu-id="19850-223">array</span></span>      |  <span data-ttu-id="19850-224">ユーザーのゲーマースコアの分布に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-224">Contains objects that provide details about the gamerscore distribution for customers.</span></span> <span data-ttu-id="19850-225">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="19850-225">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="19850-226">**scoreRange**: 次のフィールドで使用状況データが提供されるゲーマースコアの範囲です。</span><span class="sxs-lookup"><span data-stu-id="19850-226">**scoreRange**: The gamerscore range for which the following field provides usage data.</span></span> <span data-ttu-id="19850-227">たとえば、**10K-25K** のように指定されます。</span><span class="sxs-lookup"><span data-stu-id="19850-227">For example, **10K-25K**.</span></span></li><li><span data-ttu-id="19850-228">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、プレイしたすべてのゲームに対するゲーマースコアが指定範囲に含まれているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-228">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that have a  gamerscore in the specified range for all games they have played.</span></span> <span data-ttu-id="19850-229">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、プレイしたすべてのゲームに対するゲーマースコアが指定範囲に含まれているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-229">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that have a gamerscore in the specified range for all games they have played.</span></span></li></ul>  |
|  <span data-ttu-id="19850-230">titleGamerScoreRangeDistribution</span><span class="sxs-lookup"><span data-stu-id="19850-230">titleGamerScoreRangeDistribution</span></span>               |   <span data-ttu-id="19850-231">array</span><span class="sxs-lookup"><span data-stu-id="19850-231">array</span></span>      |  <span data-ttu-id="19850-232">対象ゲームのゲーマースコアの分布に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-232">Contains objects that provide details about the gamerscore distribution for your game.</span></span> <span data-ttu-id="19850-233">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="19850-233">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="19850-234">**scoreRange**: 次のフィールドで使用状況データが提供されるゲーマースコアの範囲です。</span><span class="sxs-lookup"><span data-stu-id="19850-234">**scoreRange**: The gamerscore range for which the following field provides usage data.</span></span> <span data-ttu-id="19850-235">たとえば、**100-200** のように指定されます。</span><span class="sxs-lookup"><span data-stu-id="19850-235">For example, **100-200**.</span></span></li><li><span data-ttu-id="19850-236">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、対象ゲームのゲーマースコアが指定範囲に含まれているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-236">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that have a  gamerscore in the specified range for your game.</span></span> <span data-ttu-id="19850-237">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、対象ゲームのゲーマースコアが指定範囲に含まれているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-237">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that have a gamerscore in the specified range for your game.</span></span></li></ul>   |
|  <span data-ttu-id="19850-238">socialUsageCounts</span><span class="sxs-lookup"><span data-stu-id="19850-238">socialUsageCounts</span></span>               |   <span data-ttu-id="19850-239">array</span><span class="sxs-lookup"><span data-stu-id="19850-239">array</span></span>      |  <span data-ttu-id="19850-240">ユーザーのソーシャル利用状況に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-240">Contains objects that provide details about the social usage for customers.</span></span> <span data-ttu-id="19850-241">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="19850-241">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="19850-242">**scName**: ソーシャル利用状況の種類です。</span><span class="sxs-lookup"><span data-stu-id="19850-242">**scName**: The type of social usage.</span></span> <span data-ttu-id="19850-243">たとえば、**gameInvites** や **textMessages** のように指定されます。</span><span class="sxs-lookup"><span data-stu-id="19850-243">For example, **gameInvites** and **textMessages**.</span></span></li><li><span data-ttu-id="19850-244">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定の種類のソーシャル利用状況に含まれるユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-244">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that have participated in the specified social usage type.</span></span> <span data-ttu-id="19850-245">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定の種類のソーシャル利用状況に含まれるユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-245">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that have participated in the specified social usage type.</span></span></li></ul>   |
|  <span data-ttu-id="19850-246">streamingUsageCounts</span><span class="sxs-lookup"><span data-stu-id="19850-246">streamingUsageCounts</span></span>               |   <span data-ttu-id="19850-247">array</span><span class="sxs-lookup"><span data-stu-id="19850-247">array</span></span>      |  <span data-ttu-id="19850-248">ユーザーのストリーミング利用状況に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="19850-248">Contains objects that provide details about the streaming usage for customers.</span></span> <span data-ttu-id="19850-249">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="19850-249">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="19850-250">**stName**: ストリーミング プラットフォームの種類です。</span><span class="sxs-lookup"><span data-stu-id="19850-250">**stName**: The type of streaming platform.</span></span> <span data-ttu-id="19850-251">たとえば、**youtubeUsage**、**twitchUsage**、**mixerUsage** のように指定されます。</span><span class="sxs-lookup"><span data-stu-id="19850-251">For example, **youtubeUsage**, **twitchUsage**, and **mixerUsage**.</span></span></li><li><span data-ttu-id="19850-252">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定のストリーミング プラットフォームを使用したユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-252">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that have used the specified streaming platform.</span></span> <span data-ttu-id="19850-253">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定のストリーミング プラットフォームを使用したユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="19850-253">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that have used the specified streaming platform.</span></span></li></ul>  |


### <a name="response-example"></a><span data-ttu-id="19850-254">応答の例</span><span class="sxs-lookup"><span data-stu-id="19850-254">Response example</span></span>

<span data-ttu-id="19850-255">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="19850-255">The following example demonstrates an example JSON response body for this request.</span></span>

```json
{
  "Value": [
    {
      "ProductData": {
        "DeviceProperties": [
          {
            "applicationId": "9NBLGGGZ5QDR",
            "connectionTypeDistribution": [
              {
                "conType": "WIRED",
                "deviceCount": "43806"
              },
              {
                "conType": "WIRELESS",
                "deviceCount": "104035"
              }
            ],
            "deviceCount": "148063",
            "eliteControllerPresentDeviceCount": "10615",
            "externalDrivePresentDeviceCount": "46388"
          }
        ],
        "UserProperties": [
          {
            "applicationId": "9NBLGGGZ5QDR",
            "userCount": "142345",
            "dvrUsageCounts": [
              {
                "dvrName": "gameClipUploads",
                "userCount": "31264"
              },
              {
                "dvrName": "gameClipViews",
                "userCount": "52236"
              },
              {
                "dvrName": "screenshotUploads",
                "userCount": "27051"
              },
              {
                "dvrName": "screenshotViews",
                "userCount": "45640"
              }
            ],
            "followerCountPercentiles": [
              {
                "percentage": "50",
                "value": "11"
              }
            ],
            "friendCountPercentiles": [
              {
                "percentage": "50",
                "value": "11"
              }
            ],
            "gamerScoreRangeDistribution": [
              {
                "scoreRange": "10K-25K",
                "userCount": "30015"
              },
              {
                "scoreRange": "25K-50K",
                "userCount": "20495"
              },
              {
                "scoreRange": "3K-10K",
                "userCount": "32438"
              },
              {
                "scoreRange": "50K-100K",
                "userCount": "10608"
              },
              {
                "scoreRange": "<3K",
                "userCount": "45726"
              },
              {
                "scoreRange": ">100K",
                "userCount": "3063"
              }
            ],
            "titleGamerScoreRangeDistribution": [
              {
                "scoreRange": "400-600",
                "userCount": "133875"
              },
              {
                "scoreRange": "800-1000",
                "userCount": "45960"
              },
              {
                "scoreRange": "<100",
                "userCount": "269137"
              },
              {
                "scoreRange": "≥1K",
                "userCount": "11634"
              },
              {
                "scoreRange": "100-200",
                "userCount": "334471"
              },
              {
                "scoreRange": "600-800",
                "userCount": "123044"
              },
              {
                "scoreRange": "200-400",
                "userCount": "396725"
              }
            ],
            "socialUsageCounts": [
              {
                "scName": "gameInvites",
                "userCount": "82390"
              },
              {
                "scName": "textMessages",
                "userCount": "91880"
              },
              {
                "scName": "partySessionCount",
                "userCount": "68129"
              }
            ],
            "streamingUsageCounts": [
              {
                "stName": "youtubeUsage",
                "userCount": "74092"
              },
              {
                "stName": "twitchUsage",
                "userCount": "13401"
              }
              {
                "stName": "mixerUsage",
                "userCount": "22907"
              }
            ]
          }
        ]
      },
      "XboxwideData": {
        "DeviceProperties": [
          {
            "applicationId": "XBOXWIDE",
            "connectionTypeDistribution": [
              {
                "conType": "WIRED",
                "deviceCount": "0.213677732584786"
              },
              {
                "conType": "WIRELESS",
                "deviceCount": "0.786322267415214"
              }
            ],
            "deviceCount": "1",
            "eliteControllerPresentDeviceCount": "0.0476609278128012",
            "externalDrivePresentDeviceCount": "0.173747147416134"
          }
        ],
        "UserProperties": [
          {
            "applicationId": "XBOXWIDE",
            "userCount": "1",
            "dvrUsageCounts": [
              {
                "dvrName": "gameClipUploads",
                "userCount": "0.173210623993245"
              },
              {
                "dvrName": "gameClipViews",
                "userCount": "0.202104713778096"
              },
              {
                "dvrName": "screenshotUploads",
                "userCount": "0.136682414274251"
              },
              {
                "dvrName": "screenshotViews",
                "userCount": "0.158057895120314"
              }
            ],
            "followerCountPercentiles": [
              {
                "percentage": "50",
                "value": "5"
              }
            ],
            "friendCountPercentiles": [
              {
                "percentage": "50",
                "value": "5"
              }
            ],
            "gamerScoreRangeDistribution": [
              {
                "scoreRange": "10K-25K",
                "userCount": "0.134709282586519"
              },
              {
                "scoreRange": "25K-50K",
                "userCount": "0.0549468789343825"
              },
              {
                "scoreRange": "50K-100K",
                "userCount": "0.017301313342277"
              },
              {
                "scoreRange": "3K-10K",
                "userCount": "0.216512780268453"
              },
              {
                "scoreRange": "<3K",
                "userCount": "0.573515440094644"
              },
              {
                "scoreRange": ">100K",
                "userCount": "0.00301430477372488"
              }
            ],
            "titleGamerScoreRangeDistribution": [
              {
                "scoreRange": "100-200",
                "userCount": "0.178055695637076"
              },
              {
                "scoreRange": "200-400",
                "userCount": "0.173283639825241"
              },
              {
                "scoreRange": "400-600",
                "userCount": "0.0986865193958259"
              },
              {
                "scoreRange": "600-800",
                "userCount": "0.0506375775462092"
              },
              {
                "scoreRange": "800-1000",
                "userCount": "0.0232398822856435"
              },
              {
                "scoreRange": "<100",
                "userCount": "0.456443551582991"
              },
              {
                "scoreRange": "≥1K",
                "userCount": "0.0196531337270126"
              }
            ],
            "socialUsageCounts": [
              {
                "scName": "gameInvites",
                "userCount": "0.460375855738335"
              },
              {
                "scName": "textMessages",
                "userCount": "0.429256324070832"
              },
              {
                "scName": "partySessionCount",
                "userCount": "0.378446577751268"
              },
              {
                "scName": "gamehubViews",
                "userCount": "0.000197115778147329"
              }
            ],
            "streamingUsageCounts": [
              {
                "stName": "youtubeUsage",
                "userCount": "0.330320919178683"
              },
              {
                "stName": "twitchUsage",
                "userCount": "0.040666241835399"
              }
              {
                "stName": "mixerUsage",
                "userCount": "0.140193816053558"
              }
            ]
          }
        ]
      }
    }
  ],
  "@nextLink": null,
  "TotalCount": 4
}
```

## <a name="related-topics"></a><span data-ttu-id="19850-256">関連トピック</span><span class="sxs-lookup"><span data-stu-id="19850-256">Related topics</span></span>

* [<span data-ttu-id="19850-257">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="19850-257">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="19850-258">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-258">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="19850-259">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-259">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="19850-260">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="19850-260">Get Xbox Live game hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="19850-261">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="19850-261">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="19850-262">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-262">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
* [<span data-ttu-id="19850-263">Xbox Live の同時使用状況データの取得</span><span class="sxs-lookup"><span data-stu-id="19850-263">Get Xbox Live concurrent usage data</span></span>](get-xbox-live-concurrent-usage-data.md)
