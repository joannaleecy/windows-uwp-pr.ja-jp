---
title: Device Portal の HTTP モニター API のリファレンス
description: Xbox でフォーカスのあるアプリから HTTP トラフィックにアクセスする方法について説明します。
ms.localizationpriority: medium
ms.topic: article
ms.date: 02/08/2017
ms.openlocfilehash: 8b8828b060e0401e7938517e497bae20e1234baf
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8797894"
---
# <a name="http-monitor-api-reference"></a><span data-ttu-id="809d6-103">HTTP モニター API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="809d6-103">HTTP Monitor API reference</span></span>   
<span data-ttu-id="809d6-104">Dev Home のチェック ボックスをオンにすることにより Xbox 本体で HTTP モニターが有効になっている場合、この API を使用してフォーカスのあるアプリのリアルタイム HTTP トラフィックにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="809d6-104">You can access real-time HTTP traffic for the focused app using this API if the HTTP monitor has been enabled on the Xbox console by checking the box in Dev Home.</span></span>

## <a name="get-if-the-http-monitor-is-enabled"></a><span data-ttu-id="809d6-105">HTTP モニターが有効かどうかを取得</span><span class="sxs-lookup"><span data-stu-id="809d6-105">Get if the HTTP Monitor is enabled</span></span>

**<span data-ttu-id="809d6-106">要求</span><span class="sxs-lookup"><span data-stu-id="809d6-106">Request</span></span>**

<span data-ttu-id="809d6-107">Dev Home で HTTP モニターが有効になっているかどうかを取得できます。</span><span class="sxs-lookup"><span data-stu-id="809d6-107">You can get whether the HTTP monitor has been enabled in Dev Home.</span></span>

<span data-ttu-id="809d6-108">メソッド</span><span class="sxs-lookup"><span data-stu-id="809d6-108">Method</span></span>      | <span data-ttu-id="809d6-109">要求 URI</span><span class="sxs-lookup"><span data-stu-id="809d6-109">Request URI</span></span>
:------     | :-----
<span data-ttu-id="809d6-110">GET</span><span class="sxs-lookup"><span data-stu-id="809d6-110">GET</span></span> | <span data-ttu-id="809d6-111">/ext/httpmonitor/sessions</span><span class="sxs-lookup"><span data-stu-id="809d6-111">/ext/httpmonitor/sessions</span></span>
<br />
**<span data-ttu-id="809d6-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="809d6-112">URI parameters</span></span>**

- <span data-ttu-id="809d6-113">なし</span><span class="sxs-lookup"><span data-stu-id="809d6-113">None</span></span>

**<span data-ttu-id="809d6-114">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="809d6-114">Request headers</span></span>**

- <span data-ttu-id="809d6-115">なし</span><span class="sxs-lookup"><span data-stu-id="809d6-115">None</span></span>

**<span data-ttu-id="809d6-116">要求本文</span><span class="sxs-lookup"><span data-stu-id="809d6-116">Request body</span></span>**

- <span data-ttu-id="809d6-117">なし</span><span class="sxs-lookup"><span data-stu-id="809d6-117">None</span></span>

**<span data-ttu-id="809d6-118">応答</span><span class="sxs-lookup"><span data-stu-id="809d6-118">Response</span></span>**   
<span data-ttu-id="809d6-119">次のフィールドを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="809d6-119">A JSON object with the following fields:</span></span>

* <span data-ttu-id="809d6-120">Enabled - (ブール値) Dev Home でチェック ボックスをオンにすることにより Xbox 本体で HTTP モニターが有効になっているかどうか。</span><span class="sxs-lookup"><span data-stu-id="809d6-120">Enabled - (Bool) Whether the HTTP monitor has been enabled on the Xbox console by checking the box in Dev Home.</span></span>

**<span data-ttu-id="809d6-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="809d6-121">Status code</span></span>**

<span data-ttu-id="809d6-122">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="809d6-122">This API has the following expected status codes.</span></span>

<span data-ttu-id="809d6-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="809d6-123">HTTP status code</span></span>      | <span data-ttu-id="809d6-124">説明</span><span class="sxs-lookup"><span data-stu-id="809d6-124">Description</span></span>
:------     | :-----
<span data-ttu-id="809d6-125">200</span><span class="sxs-lookup"><span data-stu-id="809d6-125">200</span></span> | <span data-ttu-id="809d6-126">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="809d6-126">Request was successful</span></span>
<span data-ttu-id="809d6-127">4XX</span><span class="sxs-lookup"><span data-stu-id="809d6-127">4XX</span></span> | <span data-ttu-id="809d6-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="809d6-128">Error codes</span></span>
<span data-ttu-id="809d6-129">5XX</span><span class="sxs-lookup"><span data-stu-id="809d6-129">5XX</span></span> | <span data-ttu-id="809d6-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="809d6-130">Error codes</span></span>

## <a name="get-http-traffic-from-the-focused-app"></a><span data-ttu-id="809d6-131">フォーカスのあるアプリから HTTP トラフィックを取得します。</span><span class="sxs-lookup"><span data-stu-id="809d6-131">Get HTTP traffic from the focused app</span></span>
**<span data-ttu-id="809d6-132">要求</span><span class="sxs-lookup"><span data-stu-id="809d6-132">Request</span></span>**

<span data-ttu-id="809d6-133">Dev Home で HTTP モニターが有効になっている場合は、Xbox のフォーカスのあるアプリ (システム アプリでない限り) からリアルタイムで HTTP トラフィックを取得します。</span><span class="sxs-lookup"><span data-stu-id="809d6-133">Get HTTP traffic from the focused app on the Xbox, as long as it is not a system app, in real-time, if the HTTP monitor has been enabled from Dev Home.</span></span>

<span data-ttu-id="809d6-134">メソッド</span><span class="sxs-lookup"><span data-stu-id="809d6-134">Method</span></span>      | <span data-ttu-id="809d6-135">要求 URI</span><span class="sxs-lookup"><span data-stu-id="809d6-135">Request URI</span></span>
:------     | :-----
<span data-ttu-id="809d6-136">WebSocket</span><span class="sxs-lookup"><span data-stu-id="809d6-136">Websocket</span></span> | <span data-ttu-id="809d6-137">/ext/httpmonitor/sessions</span><span class="sxs-lookup"><span data-stu-id="809d6-137">/ext/httpmonitor/sessions</span></span>
<br />
**<span data-ttu-id="809d6-138">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="809d6-138">URI parameters</span></span>**

- <span data-ttu-id="809d6-139">なし</span><span class="sxs-lookup"><span data-stu-id="809d6-139">None</span></span>

**<span data-ttu-id="809d6-140">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="809d6-140">Request headers</span></span>**

- <span data-ttu-id="809d6-141">なし</span><span class="sxs-lookup"><span data-stu-id="809d6-141">None</span></span>

**<span data-ttu-id="809d6-142">要求本文</span><span class="sxs-lookup"><span data-stu-id="809d6-142">Request body</span></span>**

- <span data-ttu-id="809d6-143">なし</span><span class="sxs-lookup"><span data-stu-id="809d6-143">None</span></span>

**<span data-ttu-id="809d6-144">応答</span><span class="sxs-lookup"><span data-stu-id="809d6-144">Response</span></span>**   
<span data-ttu-id="809d6-145">次のフィールドを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="809d6-145">A JSON object with the following fields:</span></span>

* <span data-ttu-id="809d6-146">セッション</span><span class="sxs-lookup"><span data-stu-id="809d6-146">Sessions</span></span>
    * <span data-ttu-id="809d6-147">RequestHeaders - (JSON オブジェクト) HTTP 要求からの要求ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="809d6-147">RequestHeaders - (JSON Object) The request headers from the HTTP Request.</span></span>
    * <span data-ttu-id="809d6-148">RequestContentHeaders - (JSON オブジェクト) HTTP 要求からの要求コンテンツ ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="809d6-148">RequestContentHeaders - (JSON Object) The request content headers from the HTTP Request.</span></span>
    * <span data-ttu-id="809d6-149">RequestURL - (文字列) 要求 URL。</span><span class="sxs-lookup"><span data-stu-id="809d6-149">RequestURL - (String) The request URL.</span></span>
    * <span data-ttu-id="809d6-150">RequestMethod - (文字列) 要求メソッド。</span><span class="sxs-lookup"><span data-stu-id="809d6-150">RequestMethod - (String) The request method.</span></span>
    * <span data-ttu-id="809d6-151">RequestMessage - (文字列) 要求メッセージは、現在のところ JSON およびテキスト コンテンツのみをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="809d6-151">RequestMessage - (String) The request message, currently only supporting JSON and text content.</span></span>
    * <span data-ttu-id="809d6-152">ResponseHeaders - (JSON オブジェクト) HTTP 応答からの応答ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="809d6-152">ResponseHeaders - (JSON Object) The response headers from the HTTP Response.</span></span>
    * <span data-ttu-id="809d6-153">ResponseContentHeaders - (JSON オブジェクト) HTTP 応答からの応答コンテンツ ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="809d6-153">ResponseContentHeaders - (JSON Object) The response content headers from the HTTP Response.</span></span>
    * <span data-ttu-id="809d6-154">StatusCode - (数値) 応答状態コード。</span><span class="sxs-lookup"><span data-stu-id="809d6-154">StatusCode - (Number) The response status code.</span></span>
    * <span data-ttu-id="809d6-155">ReasponsePhrase - (文字列) 応答理由フレーズ。</span><span class="sxs-lookup"><span data-stu-id="809d6-155">ReasponsePhrase - (String) The response reason phrase.</span></span>
    * <span data-ttu-id="809d6-156">ResponseMessage - (文字列) 応答メッセージは、現在のところ JSON およびテキスト コンテンツのみをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="809d6-156">ResponseMessage - (String) The response message, currently only supporting JSON and text content.</span></span>

**<span data-ttu-id="809d6-157">状態コード</span><span class="sxs-lookup"><span data-stu-id="809d6-157">Status code</span></span>**

<span data-ttu-id="809d6-158">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="809d6-158">This API has the following expected status codes.</span></span>

<span data-ttu-id="809d6-159">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="809d6-159">HTTP status code</span></span>      | <span data-ttu-id="809d6-160">説明</span><span class="sxs-lookup"><span data-stu-id="809d6-160">Description</span></span>
:------     | :-----
<span data-ttu-id="809d6-161">200</span><span class="sxs-lookup"><span data-stu-id="809d6-161">200</span></span> | <span data-ttu-id="809d6-162">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="809d6-162">Request was successful</span></span>
<span data-ttu-id="809d6-163">4XX</span><span class="sxs-lookup"><span data-stu-id="809d6-163">4XX</span></span> | <span data-ttu-id="809d6-164">エラー コード</span><span class="sxs-lookup"><span data-stu-id="809d6-164">Error codes</span></span>
<span data-ttu-id="809d6-165">403</span><span class="sxs-lookup"><span data-stu-id="809d6-165">403</span></span> | <span data-ttu-id="809d6-166">HTTP モニターが無効になっています。Dev Home で有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="809d6-166">HTTP Monitor disabled, must be enabled in Dev Home</span></span>
<span data-ttu-id="809d6-167">5XX</span><span class="sxs-lookup"><span data-stu-id="809d6-167">5XX</span></span> | <span data-ttu-id="809d6-168">エラー コード</span><span class="sxs-lookup"><span data-stu-id="809d6-168">Error codes</span></span>

<br />
**<span data-ttu-id="809d6-169">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="809d6-169">Available device families</span></span>**

* <span data-ttu-id="809d6-170">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="809d6-170">Windows Xbox</span></span>