---
author: Xansky
description: Xbox Live の分析データを取得するには、Microsoft Store 分析 API の以下のメソッドを使います。
title: Xbox Live の分析データの取得
ms.author: mhopkins
ms.date: 06/04/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Store サービス, Microsoft Store 分析 API, Xbox Live 分析
ms.localizationpriority: medium
ms.openlocfilehash: 68bc3389276acc910272d57e9cc859a7e8ffd6c7
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4741377"
---
# <a name="get-xbox-live-analytics-data"></a><span data-ttu-id="c2a31-104">Xbox Live の分析データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-104">Get Xbox Live analytics data</span></span>

<span data-ttu-id="c2a31-105">[Xbox Live 対応ゲーム](../xbox-live/index.md)をプレイしているユーザーに関する過去 30 日間の一般的な分析データを取得するには、Microsoft Store 分析 API の次のメソッドを使います。取得できるデータには、デバイス アクセサリの使用状況、インターネット接続の種類、ゲーマースコアの分布、ゲームの統計情報、フレンドとフォロワーのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-105">Use this method in the Microsoft Store analytics API to get the last 30 days of general analytics data for customers playing your [Xbox Live-enabled game](../xbox-live/index.md), including device accessory usage, internet connection type, gamerscore distribution, game statistics, and friends and followers data.</span></span> <span data-ttu-id="c2a31-106">この情報は、Windows デベロッパー センター ダッシュボードの [Xbox 分析レポート](../publish/xbox-analytics-report.md)でも確認できます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-106">This information is also available in the [Xbox analytics report](../publish/xbox-analytics-report.md) in the Windows Dev Center dashboard.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c2a31-107">このメソッドは、Xbox のゲームまたは Xbox Live サービスを使用するゲームのみサポートします。</span><span class="sxs-lookup"><span data-stu-id="c2a31-107">This method only supports games for Xbox or games that use Xbox Live services.</span></span> <span data-ttu-id="c2a31-108">これらのゲームは、[概念の承認プロセス](../gaming/concept-approval.md)を完了する必要があります。これには、[Microsoft パートナー](../xbox-live/developer-program-overview.md#microsoft-partners)が発行したゲームと [ID@Xbox プログラム](../xbox-live/developer-program-overview.md#id)を介して申請されたゲームが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-108">These games must go through the [concept approval process](../gaming/concept-approval.md), which includes games published by [Microsoft partners](../xbox-live/developer-program-overview.md#microsoft-partners) and games submitted via the [ID@Xbox program](../xbox-live/developer-program-overview.md#id).</span></span> <span data-ttu-id="c2a31-109">このメソッドでは、[Xbox Live クリエーターズ プログラム](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md)を介して発行されたゲームは現在サポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c2a31-109">This method does not currently support games published via the [Xbox Live Creators Program](../xbox-live/get-started-with-creators/get-started-with-xbox-live-creators.md).</span></span>

<span data-ttu-id="c2a31-110">Xbox Live 対応ゲームに関するその他の分析データは、次のメソッドを通じて取得できます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-110">Additional analytics data for Xbox Live-enabled games is available via the following methods:</span></span>
* [<span data-ttu-id="c2a31-111">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-111">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="c2a31-112">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-112">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="c2a31-113">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-113">Get Xbox Live Game Hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="c2a31-114">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-114">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="c2a31-115">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-115">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
* [<span data-ttu-id="c2a31-116">Xbox Live の同時使用状況データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-116">Get Xbox Live concurrent usage data</span></span>](get-xbox-live-concurrent-usage-data.md)

## <a name="prerequisites"></a><span data-ttu-id="c2a31-117">前提条件</span><span class="sxs-lookup"><span data-stu-id="c2a31-117">Prerequisites</span></span>

<span data-ttu-id="c2a31-118">このメソッドを使うには、最初に次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-118">To use this method, you need to first do the following:</span></span>

* <span data-ttu-id="c2a31-119">Microsoft Store 分析 API に関するすべての[前提条件](access-analytics-data-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="c2a31-119">If you have not done so already, complete all the [prerequisites](access-analytics-data-using-windows-store-services.md#prerequisites) for the Microsoft Store analytics API.</span></span>
* <span data-ttu-id="c2a31-120">このメソッドの要求ヘッダーで使う [Azure AD アクセス トークンを取得](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-120">[Obtain an Azure AD access token](access-analytics-data-using-windows-store-services.md#obtain-an-azure-ad-access-token) to use in the request header for this method.</span></span> <span data-ttu-id="c2a31-121">アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-121">After you obtain an access token, you have 60 minutes to use it before it expires.</span></span> <span data-ttu-id="c2a31-122">トークンの有効期限が切れたら、新しいトークンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-122">After the token expires, you can obtain a new one.</span></span>

## <a name="request"></a><span data-ttu-id="c2a31-123">要求</span><span class="sxs-lookup"><span data-stu-id="c2a31-123">Request</span></span>


### <a name="request-syntax"></a><span data-ttu-id="c2a31-124">要求の構文</span><span class="sxs-lookup"><span data-stu-id="c2a31-124">Request syntax</span></span>

| <span data-ttu-id="c2a31-125">メソッド</span><span class="sxs-lookup"><span data-stu-id="c2a31-125">Method</span></span> | <span data-ttu-id="c2a31-126">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c2a31-126">Request URI</span></span>       |
|--------|----------------------|
| <span data-ttu-id="c2a31-127">GET</span><span class="sxs-lookup"><span data-stu-id="c2a31-127">GET</span></span>    | ```https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics``` |


### <a name="request-header"></a><span data-ttu-id="c2a31-128">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2a31-128">Request header</span></span>

| <span data-ttu-id="c2a31-129">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2a31-129">Header</span></span>        | <span data-ttu-id="c2a31-130">型</span><span class="sxs-lookup"><span data-stu-id="c2a31-130">Type</span></span>   | <span data-ttu-id="c2a31-131">説明</span><span class="sxs-lookup"><span data-stu-id="c2a31-131">Description</span></span>                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| <span data-ttu-id="c2a31-132">Authorization</span><span class="sxs-lookup"><span data-stu-id="c2a31-132">Authorization</span></span> | <span data-ttu-id="c2a31-133">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-133">string</span></span> | <span data-ttu-id="c2a31-134">必須。</span><span class="sxs-lookup"><span data-stu-id="c2a31-134">Required.</span></span> <span data-ttu-id="c2a31-135">**Bearer** &lt;*トークン*&gt; という形式の Azure AD アクセス トークン。</span><span class="sxs-lookup"><span data-stu-id="c2a31-135">The Azure AD access token in the form **Bearer** &lt;*token*&gt;.</span></span> |


### <a name="request-parameters"></a><span data-ttu-id="c2a31-136">要求パラメーター</span><span class="sxs-lookup"><span data-stu-id="c2a31-136">Request parameters</span></span>

| <span data-ttu-id="c2a31-137">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c2a31-137">Parameter</span></span>        | <span data-ttu-id="c2a31-138">型</span><span class="sxs-lookup"><span data-stu-id="c2a31-138">Type</span></span>   |  <span data-ttu-id="c2a31-139">説明</span><span class="sxs-lookup"><span data-stu-id="c2a31-139">Description</span></span>      |  <span data-ttu-id="c2a31-140">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="c2a31-140">Required</span></span>  
|---------------|--------|---------------|------|
| <span data-ttu-id="c2a31-141">applicationId</span><span class="sxs-lookup"><span data-stu-id="c2a31-141">applicationId</span></span> | <span data-ttu-id="c2a31-142">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-142">string</span></span> | <span data-ttu-id="c2a31-143">Xbox Live の分析データを取得するゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-143">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you want to retrieve general Xbox Live analytics data.</span></span>  |  <span data-ttu-id="c2a31-144">必須</span><span class="sxs-lookup"><span data-stu-id="c2a31-144">Yes</span></span>  |
| <span data-ttu-id="c2a31-145">metricType</span><span class="sxs-lookup"><span data-stu-id="c2a31-145">metricType</span></span> | <span data-ttu-id="c2a31-146">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-146">string</span></span> | <span data-ttu-id="c2a31-147">取得する Xbox Live 分析データの種類を指定する文字列です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-147">A string that specifies the type of Xbox Live analytics data to retrieve.</span></span> <span data-ttu-id="c2a31-148">このメソッドでは、値 **productvalues** を指定します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-148">For this method, specify the value **productvalues**.</span></span>  |  <span data-ttu-id="c2a31-149">必須</span><span class="sxs-lookup"><span data-stu-id="c2a31-149">Yes</span></span>  |


### <a name="request-example"></a><span data-ttu-id="c2a31-150">要求の例</span><span class="sxs-lookup"><span data-stu-id="c2a31-150">Request example</span></span>

<span data-ttu-id="c2a31-151">次の例では、Xbox Live 対応ゲームをプレイしているユーザーに関する一般的な分析データを取得する要求を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-151">The following example demonstrates a request for getting general analytics data for customers playing your Xbox Live-enabled game.</span></span> <span data-ttu-id="c2a31-152">*applicationId* の値は、ゲームの Store ID に置き換えてください。</span><span class="sxs-lookup"><span data-stu-id="c2a31-152">Replace the *applicationId* value with the Store ID for your game.</span></span>

```syntax
GET https://manage.devcenter.microsoft.com/v1.0/my/analytics/gameanalytics?applicationId=9NBLGGGZ5QDR&metrictype=productvalues HTTP/1.1
Authorization: Bearer <your access token>
```

## <a name="response"></a><span data-ttu-id="c2a31-153">応答</span><span class="sxs-lookup"><span data-stu-id="c2a31-153">Response</span></span>

<span data-ttu-id="c2a31-154">このメソッドは、次のオブジェクトを含む *Value* 配列を返します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-154">This method returns a *Value* array that contains the following objects.</span></span>

| <span data-ttu-id="c2a31-155">オブジェクト</span><span class="sxs-lookup"><span data-stu-id="c2a31-155">Object</span></span>      | <span data-ttu-id="c2a31-156">説明</span><span class="sxs-lookup"><span data-stu-id="c2a31-156">Description</span></span>                  |
|-------------|---------------------------------------------------|
| <span data-ttu-id="c2a31-157">ProductData</span><span class="sxs-lookup"><span data-stu-id="c2a31-157">ProductData</span></span>   |   <span data-ttu-id="c2a31-158">1 つの [DeviceProperties](#deviceproperties) オブジェクトと 1 つの [UserProperties](#userproperties) オブジェクトが含まれます。それぞれには、対象ゲームに関する過去 30 日間のデバイス分析データとユーザー分析データが格納されます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-158">Contains one [DeviceProperties](#deviceproperties) object and one [UserProperties](#userproperties) object that contain the last 30 days of device and user analytics data for your game.</span></span>    |  
| <span data-ttu-id="c2a31-159">XboxwideData</span><span class="sxs-lookup"><span data-stu-id="c2a31-159">XboxwideData</span></span>   |  <span data-ttu-id="c2a31-160">1 つの [DeviceProperties](#deviceproperties) オブジェクトと 1 つの [UserProperties](#userproperties) オブジェクトが含まれます。それぞれには、すべての Xbox Live ユーザーを対象とした過去 30 日間の平均的なデバイス分析データとユーザー分析データが、パーセンテージとして格納されます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-160">Contains one [DeviceProperties](#deviceproperties) object and one [UserProperties](#userproperties) object that contain the last 30 days of average device and user analytics data for all Xbox Live customers, as percentages.</span></span> <span data-ttu-id="c2a31-161">このデータは、対象ゲームのデータとの比較のために用意されています。</span><span class="sxs-lookup"><span data-stu-id="c2a31-161">This data is included for comparison purposes with the data for your game.</span></span>   |                                           


### <a name="deviceproperties"></a><span data-ttu-id="c2a31-162">DeviceProperties</span><span class="sxs-lookup"><span data-stu-id="c2a31-162">DeviceProperties</span></span>

<span data-ttu-id="c2a31-163">このリソースには、過去 30 日間について、対象ゲームに関するデバイス使用状況データ、またはすべての Xbox Live ユーザーを対象とした平均的なデバイス使用状況データが格納されます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-163">This resource contains device usage data for your game or average device usage data for all Xbox Live customers during the last 30 days.</span></span>

| <span data-ttu-id="c2a31-164">値</span><span class="sxs-lookup"><span data-stu-id="c2a31-164">Value</span></span>           | <span data-ttu-id="c2a31-165">型</span><span class="sxs-lookup"><span data-stu-id="c2a31-165">Type</span></span>    | <span data-ttu-id="c2a31-166">説明</span><span class="sxs-lookup"><span data-stu-id="c2a31-166">Description</span></span>        |
|-----------------|---------|------|
|  <span data-ttu-id="c2a31-167">applicationId</span><span class="sxs-lookup"><span data-stu-id="c2a31-167">applicationId</span></span>               |    <span data-ttu-id="c2a31-168">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-168">string</span></span>     |  <span data-ttu-id="c2a31-169">分析データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-169">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you retrieved analytics data.</span></span>   |
|  <span data-ttu-id="c2a31-170">connectionTypeDistribution</span><span class="sxs-lookup"><span data-stu-id="c2a31-170">connectionTypeDistribution</span></span>               |    <span data-ttu-id="c2a31-171">array</span><span class="sxs-lookup"><span data-stu-id="c2a31-171">array</span></span>     |   <span data-ttu-id="c2a31-172">Xbox でワイヤード (有線) インターネット接続とワイヤレス インターネット接続を使っているユーザーの数を示すオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-172">Contains objects that indicate how many customers use a wired internet connection versus a wireless internet connection on Xbox.</span></span> <span data-ttu-id="c2a31-173">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-173">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="c2a31-174">**conType**: 接続の種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-174">**conType**: Specifies the connection type.</span></span></li><li><span data-ttu-id="c2a31-175">**deviceCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定の接続の種類を使っているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-175">**deviceCount**: In the **ProductData** object, this field specifies the number of your game's customers that use the connection type.</span></span> <span data-ttu-id="c2a31-176">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定の接続の種類を使っているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-176">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that use the connection type.</span></span></li></ul>   |     
|  <span data-ttu-id="c2a31-177">deviceCount</span><span class="sxs-lookup"><span data-stu-id="c2a31-177">deviceCount</span></span>               |   <span data-ttu-id="c2a31-178">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-178">string</span></span>      |  <span data-ttu-id="c2a31-179">**ProductData** オブジェクトの場合、このフィールドは、過去 30 日間に対象ゲームがプレイされたユーザー デバイスの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-179">In the **ProductData** object, this field specifies the number of customer devices on which your game has been played during the last 30 days.</span></span> <span data-ttu-id="c2a31-180">**XboxwideData** オブジェクトの場合、このフィールドは常に 1 になり、すべての Xbox Live ユーザーを対象としたデータの開始パーセンテージである 100% を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-180">In the **XboxwideData** object, this field is always 1, indicating a starting percentage of 100% for data for all Xbox Live customers.</span></span>   |     
|  <span data-ttu-id="c2a31-181">eliteControllerPresentDeviceCount</span><span class="sxs-lookup"><span data-stu-id="c2a31-181">eliteControllerPresentDeviceCount</span></span>               |   <span data-ttu-id="c2a31-182">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-182">string</span></span>      |  <span data-ttu-id="c2a31-183">**ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、Xbox Elite ワイヤレス コントローラーを使っているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-183">In the **ProductData** object, this field specifies the number of your game's customers that use the Xbox Elite Wireless Controller.</span></span> <span data-ttu-id="c2a31-184">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、Xbox Elite ワイヤレス コントローラーを使っているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-184">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that use the Xbox Elite Wireless Controller.</span></span>  |     
|  <span data-ttu-id="c2a31-185">externalDrivePresentDeviceCount</span><span class="sxs-lookup"><span data-stu-id="c2a31-185">externalDrivePresentDeviceCount</span></span>               |   <span data-ttu-id="c2a31-186">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-186">string</span></span>      |  <span data-ttu-id="c2a31-187">**ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、Xbox で外部ハード ドライブを使っているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-187">In the **ProductData** object, this field specifies the number of your game's customers that use an external hard drive on Xbox.</span></span> <span data-ttu-id="c2a31-188">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、Xbox で外部ハード ドライブを使っているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-188">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that use an external hard drive on Xbox.</span></span>  |


### <a name="userproperties"></a><span data-ttu-id="c2a31-189">UserProperties</span><span class="sxs-lookup"><span data-stu-id="c2a31-189">UserProperties</span></span>

<span data-ttu-id="c2a31-190">このリソースには、過去 30 日間について、対象ゲームに関するユーザー データ、またはすべての Xbox Live ユーザーを対象とした平均的なユーザー データが格納されます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-190">This resource contains user data for your game or average user data for all Xbox Live customers during the last 30 days.</span></span>

| <span data-ttu-id="c2a31-191">値</span><span class="sxs-lookup"><span data-stu-id="c2a31-191">Value</span></span>           | <span data-ttu-id="c2a31-192">型</span><span class="sxs-lookup"><span data-stu-id="c2a31-192">Type</span></span>    | <span data-ttu-id="c2a31-193">説明</span><span class="sxs-lookup"><span data-stu-id="c2a31-193">Description</span></span>        |
|-----------------|---------|------|
|  <span data-ttu-id="c2a31-194">applicationId</span><span class="sxs-lookup"><span data-stu-id="c2a31-194">applicationId</span></span>               |    <span data-ttu-id="c2a31-195">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-195">string</span></span>     |   <span data-ttu-id="c2a31-196">分析データを取得したゲームの [Store ID](in-app-purchases-and-trials.md#store-ids) です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-196">The [Store ID](in-app-purchases-and-trials.md#store-ids) of the game for which you retrieved analytics data.</span></span>  |
|  <span data-ttu-id="c2a31-197">userCount</span><span class="sxs-lookup"><span data-stu-id="c2a31-197">userCount</span></span>               |    <span data-ttu-id="c2a31-198">string</span><span class="sxs-lookup"><span data-stu-id="c2a31-198">string</span></span>     |   <span data-ttu-id="c2a31-199">**ProductData** オブジェクトの場合、このフィールドは、過去 30 日間に対象ゲームをプレイしたユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-199">In the **ProductData** object, this field specifies the number of customers that have played your game during the last 30 days.</span></span> <span data-ttu-id="c2a31-200">**XboxwideData** オブジェクトの場合、このフィールドは常に 1 になり、すべての Xbox Live ユーザーを対象としたデータの開始パーセンテージである 100% を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-200">In the **XboxwideData** object, this field is always 1, indicating a starting percentage of 100% for data for all Xbox Live customers.</span></span>   |     
|  <span data-ttu-id="c2a31-201">dvrUsageCounts</span><span class="sxs-lookup"><span data-stu-id="c2a31-201">dvrUsageCounts</span></span>               |   <span data-ttu-id="c2a31-202">array</span><span class="sxs-lookup"><span data-stu-id="c2a31-202">array</span></span>      |  <span data-ttu-id="c2a31-203">ゲーム録画を使ってゲームプレイを録画および表示したユーザーの数を示すオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-203">Contains objects that indicate how many customers have used game DVR to record and view gameplay.</span></span> <span data-ttu-id="c2a31-204">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-204">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="c2a31-205">**dvrName**: 使用されたゲーム録画機能を指定します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-205">**dvrName**: Specifies the game DVR feature used.</span></span> <span data-ttu-id="c2a31-206">取り得る値は、**gameClipUploads**、**gameClipViews**、**screenshotUploads**、**screenshotViews** です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-206">Possible values are **gameClipUploads**, **gameClipViews**, **screenshotUploads**, and **screenshotViews**.</span></span></li><li><span data-ttu-id="c2a31-207">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定のゲーム録画機能を使用したユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-207">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that used the specified game DVR feature.</span></span> <span data-ttu-id="c2a31-208">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定のゲーム録画機能を使用したユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-208">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that used the specified game DVR feature.</span></span></li></ul>   |     
|  <span data-ttu-id="c2a31-209">followerCountPercentiles</span><span class="sxs-lookup"><span data-stu-id="c2a31-209">followerCountPercentiles</span></span>               |   <span data-ttu-id="c2a31-210">array</span><span class="sxs-lookup"><span data-stu-id="c2a31-210">array</span></span>      |  <span data-ttu-id="c2a31-211">ユーザーのフォロワー数に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-211">Contains objects that provide details about the number of followers for customers.</span></span> <span data-ttu-id="c2a31-212">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-212">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="c2a31-213">**percentage**: 現在、この値は常に 50 になり、フォロワー データが中央値として提供されることを示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-213">**percentage**: Currently, this value is always 50, indicating that the follower data is provided as a median value.</span></span></li><li><span data-ttu-id="c2a31-214">**value**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのフォロワー数の中央値を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-214">**value**: In the **ProductData** object, this field specifies the median number of followers for your game's customers.</span></span> <span data-ttu-id="c2a31-215">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのフォロワー数の中央値を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-215">In the **XboxwideData** object, this field specifies the median number of followers for all Xbox Live customers.</span></span></li></ul>  |   
|  <span data-ttu-id="c2a31-216">friendCountPercentiles</span><span class="sxs-lookup"><span data-stu-id="c2a31-216">friendCountPercentiles</span></span>               |   <span data-ttu-id="c2a31-217">array</span><span class="sxs-lookup"><span data-stu-id="c2a31-217">array</span></span>      |  <span data-ttu-id="c2a31-218">ユーザーのフレンド数に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-218">Contains objects that provide details about the number of friends for customers.</span></span> <span data-ttu-id="c2a31-219">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-219">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="c2a31-220">**percentage**: 現在、この値は常に 50 になり、フレンド データが中央値として提供されることを示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-220">**percentage**: Currently, this value is always 50, indicating that the friends data is provided as a median value.</span></span></li><li><span data-ttu-id="c2a31-221">**value**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのフレンド数の中央値を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-221">**value**: In the **ProductData** object, this field specifies the median number of friends for your game's customers.</span></span> <span data-ttu-id="c2a31-222">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのフレンド数の中央値を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-222">In the **XboxwideData** object, this field specifies the median number of friends for all Xbox Live customers.</span></span></li></ul>  |     
|  <span data-ttu-id="c2a31-223">gamerScoreRangeDistribution</span><span class="sxs-lookup"><span data-stu-id="c2a31-223">gamerScoreRangeDistribution</span></span>               |   <span data-ttu-id="c2a31-224">array</span><span class="sxs-lookup"><span data-stu-id="c2a31-224">array</span></span>      |  <span data-ttu-id="c2a31-225">ユーザーのゲーマースコアの分布に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-225">Contains objects that provide details about the gamerscore distribution for customers.</span></span> <span data-ttu-id="c2a31-226">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-226">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="c2a31-227">**scoreRange**: 次のフィールドで使用状況データが提供されるゲーマースコアの範囲です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-227">**scoreRange**: The gamerscore range for which the following field provides usage data.</span></span> <span data-ttu-id="c2a31-228">たとえば、**10K-25K** のように指定されます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-228">For example, **10K-25K**.</span></span></li><li><span data-ttu-id="c2a31-229">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、プレイしたすべてのゲームに対するゲーマースコアが指定範囲に含まれているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-229">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that have a  gamerscore in the specified range for all games they have played.</span></span> <span data-ttu-id="c2a31-230">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、プレイしたすべてのゲームに対するゲーマースコアが指定範囲に含まれているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-230">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that have a gamerscore in the specified range for all games they have played.</span></span></li></ul>  |
|  <span data-ttu-id="c2a31-231">titleGamerScoreRangeDistribution</span><span class="sxs-lookup"><span data-stu-id="c2a31-231">titleGamerScoreRangeDistribution</span></span>               |   <span data-ttu-id="c2a31-232">array</span><span class="sxs-lookup"><span data-stu-id="c2a31-232">array</span></span>      |  <span data-ttu-id="c2a31-233">対象ゲームのゲーマースコアの分布に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-233">Contains objects that provide details about the gamerscore distribution for your game.</span></span> <span data-ttu-id="c2a31-234">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-234">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="c2a31-235">**scoreRange**: 次のフィールドで使用状況データが提供されるゲーマースコアの範囲です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-235">**scoreRange**: The gamerscore range for which the following field provides usage data.</span></span> <span data-ttu-id="c2a31-236">たとえば、**100-200** のように指定されます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-236">For example, **100-200**.</span></span></li><li><span data-ttu-id="c2a31-237">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、対象ゲームのゲーマースコアが指定範囲に含まれているユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-237">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that have a  gamerscore in the specified range for your game.</span></span> <span data-ttu-id="c2a31-238">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、対象ゲームのゲーマースコアが指定範囲に含まれているユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-238">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that have a gamerscore in the specified range for your game.</span></span></li></ul>   |
|  <span data-ttu-id="c2a31-239">socialUsageCounts</span><span class="sxs-lookup"><span data-stu-id="c2a31-239">socialUsageCounts</span></span>               |   <span data-ttu-id="c2a31-240">array</span><span class="sxs-lookup"><span data-stu-id="c2a31-240">array</span></span>      |  <span data-ttu-id="c2a31-241">ユーザーのソーシャル利用状況に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-241">Contains objects that provide details about the social usage for customers.</span></span> <span data-ttu-id="c2a31-242">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-242">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="c2a31-243">**scName**: ソーシャル利用状況の種類です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-243">**scName**: The type of social usage.</span></span> <span data-ttu-id="c2a31-244">たとえば、**gameInvites** や **textMessages** のように指定されます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-244">For example, **gameInvites** and **textMessages**.</span></span></li><li><span data-ttu-id="c2a31-245">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定の種類のソーシャル利用状況に含まれるユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-245">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that have participated in the specified social usage type.</span></span> <span data-ttu-id="c2a31-246">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定の種類のソーシャル利用状況に含まれるユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-246">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that have participated in the specified social usage type.</span></span></li></ul>   |
|  <span data-ttu-id="c2a31-247">streamingUsageCounts</span><span class="sxs-lookup"><span data-stu-id="c2a31-247">streamingUsageCounts</span></span>               |   <span data-ttu-id="c2a31-248">array</span><span class="sxs-lookup"><span data-stu-id="c2a31-248">array</span></span>      |  <span data-ttu-id="c2a31-249">ユーザーのストリーミング利用状況に関する詳細を提供するオブジェクトが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-249">Contains objects that provide details about the streaming usage for customers.</span></span> <span data-ttu-id="c2a31-250">各オブジェクトには、次の 2 つの文字列フィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="c2a31-250">Each object has two string fields:</span></span> <ul><li><span data-ttu-id="c2a31-251">**stName**: ストリーミング プラットフォームの種類です。</span><span class="sxs-lookup"><span data-stu-id="c2a31-251">**stName**: The type of streaming platform.</span></span> <span data-ttu-id="c2a31-252">たとえば、**youtubeUsage**、**twitchUsage**、**mixerUsage** のように指定されます。</span><span class="sxs-lookup"><span data-stu-id="c2a31-252">For example, **youtubeUsage**, **twitchUsage**, and **mixerUsage**.</span></span></li><li><span data-ttu-id="c2a31-253">**userCount**: **ProductData** オブジェクトの場合、このフィールドは、対象ゲームのユーザーのうち、指定のストリーミング プラットフォームを使用したユーザーの数を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-253">**userCount**: In the **ProductData** object, this field specifies the number of your game's customers that have used the specified streaming platform.</span></span> <span data-ttu-id="c2a31-254">**XboxwideData** オブジェクトの場合、このフィールドは、すべての Xbox Live ユーザーのうち、指定のストリーミング プラットフォームを使用したユーザーの割合を示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-254">In the **XboxwideData** object, this field specifies the percentage of all Xbox Live customers that have used the specified streaming platform.</span></span></li></ul>  |


### <a name="response-example"></a><span data-ttu-id="c2a31-255">応答の例</span><span class="sxs-lookup"><span data-stu-id="c2a31-255">Response example</span></span>

<span data-ttu-id="c2a31-256">この要求の JSON 応答の本文の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c2a31-256">The following example demonstrates an example JSON response body for this request.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="c2a31-257">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c2a31-257">Related topics</span></span>

* [<span data-ttu-id="c2a31-258">Microsoft Store サービスを使った分析データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="c2a31-258">Access analytics data using Microsoft Store services</span></span>](access-analytics-data-using-windows-store-services.md)
* [<span data-ttu-id="c2a31-259">Xbox Live の実績データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-259">Get Xbox Live achievements data</span></span>](get-xbox-live-achievements-data.md)
* [<span data-ttu-id="c2a31-260">Xbox Live の正常性データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-260">Get Xbox Live health data</span></span>](get-xbox-live-health-data.md)
* [<span data-ttu-id="c2a31-261">Xbox Live ゲーム ハブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-261">Get Xbox Live game hub data</span></span>](get-xbox-live-game-hub-data.md)
* [<span data-ttu-id="c2a31-262">Xbox Live クラブのデータの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-262">Get Xbox Live club data</span></span>](get-xbox-live-club-data.md)
* [<span data-ttu-id="c2a31-263">Xbox Live のマルチプレイヤー データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-263">Get Xbox Live multiplayer data</span></span>](get-xbox-live-multiplayer-data.md)
* [<span data-ttu-id="c2a31-264">Xbox Live の同時使用状況データの取得</span><span class="sxs-lookup"><span data-stu-id="c2a31-264">Get Xbox Live concurrent usage data</span></span>](get-xbox-live-concurrent-usage-data.md)
