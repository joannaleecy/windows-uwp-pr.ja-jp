---
title: Device Portal の Fiddler API のリファレンス
description: プログラムによって Fiddler のトレースを有効または無効にする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: e7d4225e-ac2c-41dc-aca7-9b1a95ec590b
ms.localizationpriority: medium
ms.openlocfilehash: f60f3fc8678208f694a9ffabde06fa60de759a45
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8826730"
---
# <a name="fiddler-settings-api-reference"></a><span data-ttu-id="adf8b-104">Fiddler 設定 API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="adf8b-104">Fiddler settings API reference</span></span>   
<span data-ttu-id="adf8b-105">この REST API を使って、開発機での Fiddler のネットワーク トレースを有効または無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="adf8b-105">You can enable and disable Fiddler network tracing on your devkit using this REST API.</span></span>

## <a name="determine-if-fiddler-tracing-is-enabled"></a><span data-ttu-id="adf8b-106">Fiddler のトレースが有効になっているかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="adf8b-106">Determine if Fiddler tracing is enabled</span></span>

**<span data-ttu-id="adf8b-107">要求</span><span class="sxs-lookup"><span data-stu-id="adf8b-107">Request</span></span>**

<span data-ttu-id="adf8b-108">Fiddler のトレースが次の要求を使用して、デバイスで有効になっているかどうかを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="adf8b-108">You can check to see if Fiddler tracing is enabled on the device using the following request.</span></span>

<span data-ttu-id="adf8b-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="adf8b-109">Method</span></span>      | <span data-ttu-id="adf8b-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="adf8b-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="adf8b-111">GET</span><span class="sxs-lookup"><span data-stu-id="adf8b-111">GET</span></span> | <span data-ttu-id="adf8b-112">/ext/fiddler</span><span class="sxs-lookup"><span data-stu-id="adf8b-112">/ext/fiddler</span></span>
<br />
**<span data-ttu-id="adf8b-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="adf8b-113">URI parameters</span></span>**

- <span data-ttu-id="adf8b-114">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-114">None</span></span>

**<span data-ttu-id="adf8b-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="adf8b-115">Request headers</span></span>**

- <span data-ttu-id="adf8b-116">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-116">None</span></span>

**<span data-ttu-id="adf8b-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="adf8b-117">Request body</span></span>**   

- <span data-ttu-id="adf8b-118">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-118">None</span></span>

**<span data-ttu-id="adf8b-119">応答</span><span class="sxs-lookup"><span data-stu-id="adf8b-119">Response</span></span>**   

- <span data-ttu-id="adf8b-120">JSON bool プロパティ IsProxyEnabled どの指定子かどうかどうか、プロキシを有効にします。</span><span class="sxs-lookup"><span data-stu-id="adf8b-120">JSON bool property IsProxyEnabled which specifiers whether the proxy is enabled or not.</span></span>

**<span data-ttu-id="adf8b-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-121">Status code</span></span>**

<span data-ttu-id="adf8b-122">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="adf8b-122">This API has the following expected status codes.</span></span>

<span data-ttu-id="adf8b-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-123">HTTP status code</span></span>      | <span data-ttu-id="adf8b-124">説明</span><span class="sxs-lookup"><span data-stu-id="adf8b-124">Description</span></span>
:------     | :-----
<span data-ttu-id="adf8b-125">200</span><span class="sxs-lookup"><span data-stu-id="adf8b-125">200</span></span> | <span data-ttu-id="adf8b-126">成功</span><span class="sxs-lookup"><span data-stu-id="adf8b-126">Success</span></span>
<span data-ttu-id="adf8b-127">4XX</span><span class="sxs-lookup"><span data-stu-id="adf8b-127">4XX</span></span> | <span data-ttu-id="adf8b-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-128">Error codes</span></span>
<span data-ttu-id="adf8b-129">5XX</span><span class="sxs-lookup"><span data-stu-id="adf8b-129">5XX</span></span> | <span data-ttu-id="adf8b-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-130">Error codes</span></span>

## <a name="enable-fiddler-tracing"></a><span data-ttu-id="adf8b-131">Fiddler のトレースを有効にする</span><span class="sxs-lookup"><span data-stu-id="adf8b-131">Enable Fiddler tracing</span></span>

**<span data-ttu-id="adf8b-132">要求</span><span class="sxs-lookup"><span data-stu-id="adf8b-132">Request</span></span>**

<span data-ttu-id="adf8b-133">次の要求を使って、開発機の Fiddler のトレースを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="adf8b-133">You can enable Fiddler tracing for the devkit using the following request.</span></span>  <span data-ttu-id="adf8b-134">この設定を有効にするには、デバイスを再起動する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="adf8b-134">Note that the device must be restarted before this takes effect.</span></span>

<span data-ttu-id="adf8b-135">メソッド</span><span class="sxs-lookup"><span data-stu-id="adf8b-135">Method</span></span>      | <span data-ttu-id="adf8b-136">要求 URI</span><span class="sxs-lookup"><span data-stu-id="adf8b-136">Request URI</span></span>
:------     | :-----
<span data-ttu-id="adf8b-137">POST</span><span class="sxs-lookup"><span data-stu-id="adf8b-137">POST</span></span> | <span data-ttu-id="adf8b-138">/ext/fiddler</span><span class="sxs-lookup"><span data-stu-id="adf8b-138">/ext/fiddler</span></span>
<br />
**<span data-ttu-id="adf8b-139">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="adf8b-139">URI parameters</span></span>**

<span data-ttu-id="adf8b-140">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="adf8b-140">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="adf8b-141">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="adf8b-141">URI parameter</span></span>      | <span data-ttu-id="adf8b-142">説明</span><span class="sxs-lookup"><span data-stu-id="adf8b-142">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="adf8b-143">proxyAddress</span><span class="sxs-lookup"><span data-stu-id="adf8b-143">proxyAddress</span></span>       | <span data-ttu-id="adf8b-144">Fiddler を実行しているデバイスの IP アドレスまたはホスト名</span><span class="sxs-lookup"><span data-stu-id="adf8b-144">The IP address or hostname of the device running Fiddler</span></span> |
| <span data-ttu-id="adf8b-145">proxyPort</span><span class="sxs-lookup"><span data-stu-id="adf8b-145">proxyPort</span></span>          | <span data-ttu-id="adf8b-146">トラフィックを監視するために Fiddler が使用しているポート。</span><span class="sxs-lookup"><span data-stu-id="adf8b-146">The port which Fiddler is using for monitoring traffic.</span></span> <span data-ttu-id="adf8b-147">既定では 8888</span><span class="sxs-lookup"><span data-stu-id="adf8b-147">Defaults to 8888</span></span> |
| <span data-ttu-id="adf8b-148">updateCert (省略可能)</span><span class="sxs-lookup"><span data-stu-id="adf8b-148">updateCert (optional)</span></span>| <span data-ttu-id="adf8b-149">Fiddler のルート証明書が提供されているかどうかを示すブール値。</span><span class="sxs-lookup"><span data-stu-id="adf8b-149">A boolean value indicating if the root Fiddler cert is provided.</span></span> <span data-ttu-id="adf8b-150">Fiddler がこの開発機で構成されたことがない場合や、別のホストで構成されていた場合は、true を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="adf8b-150">This must be true if Fiddler has never been configured on this devkit or was configured for a different host.</span></span>  |
<br>

**<span data-ttu-id="adf8b-151">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="adf8b-151">Request headers</span></span>**

- <span data-ttu-id="adf8b-152">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-152">None</span></span>

**<span data-ttu-id="adf8b-153">要求本文</span><span class="sxs-lookup"><span data-stu-id="adf8b-153">Request body</span></span>**

- <span data-ttu-id="adf8b-154">updateCert が false である場合や指定されていない場合は、なし。</span><span class="sxs-lookup"><span data-stu-id="adf8b-154">None if updateCert is false or not provided.</span></span> <span data-ttu-id="adf8b-155">それ以外の場合は、FiddlerRoot.cer ファイルを格納する、原則に従ったマルチパートの http 本文。</span><span class="sxs-lookup"><span data-stu-id="adf8b-155">Multi-part conforming http body containing the FiddlerRoot.cer file otherwise.</span></span>

**<span data-ttu-id="adf8b-156">応答</span><span class="sxs-lookup"><span data-stu-id="adf8b-156">Response</span></span>**   

- <span data-ttu-id="adf8b-157">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-157">None</span></span>  

**<span data-ttu-id="adf8b-158">状態コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-158">Status code</span></span>**

<span data-ttu-id="adf8b-159">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="adf8b-159">This API has the following expected status codes.</span></span>

<span data-ttu-id="adf8b-160">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-160">HTTP status code</span></span>      | <span data-ttu-id="adf8b-161">説明</span><span class="sxs-lookup"><span data-stu-id="adf8b-161">Description</span></span>
:------     | :-----
<span data-ttu-id="adf8b-162">204</span><span class="sxs-lookup"><span data-stu-id="adf8b-162">204</span></span> | <span data-ttu-id="adf8b-163">Fiddler を有効にする要求が受け付けられました。</span><span class="sxs-lookup"><span data-stu-id="adf8b-163">The request to enable Fiddler was accepted.</span></span> <span data-ttu-id="adf8b-164">Fiddler は、次回デバイスを再起動したときに有効になります。</span><span class="sxs-lookup"><span data-stu-id="adf8b-164">Fiddler will be enabled the next time the device reboots.</span></span>
<span data-ttu-id="adf8b-165">4XX</span><span class="sxs-lookup"><span data-stu-id="adf8b-165">4XX</span></span> | <span data-ttu-id="adf8b-166">エラー コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-166">Error codes</span></span>
<span data-ttu-id="adf8b-167">5XX</span><span class="sxs-lookup"><span data-stu-id="adf8b-167">5XX</span></span> | <span data-ttu-id="adf8b-168">エラー コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-168">Error codes</span></span>

## <a name="disable-fiddler-tracing-on-the-devkit"></a><span data-ttu-id="adf8b-169">開発機で Fiddler のトレースを無効にする</span><span class="sxs-lookup"><span data-stu-id="adf8b-169">Disable Fiddler tracing on the devkit</span></span>

**<span data-ttu-id="adf8b-170">要求</span><span class="sxs-lookup"><span data-stu-id="adf8b-170">Request</span></span>**

<span data-ttu-id="adf8b-171">次の要求を使って、デバイスでの Fiddler のトレースを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="adf8b-171">You can disable Fiddler tracing on the device using the following request.</span></span> <span data-ttu-id="adf8b-172">この設定を有効にするには、デバイスを再起動する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="adf8b-172">Note that the device must be restarted before this takes effect.</span></span>

<span data-ttu-id="adf8b-173">メソッド</span><span class="sxs-lookup"><span data-stu-id="adf8b-173">Method</span></span>      | <span data-ttu-id="adf8b-174">要求 URI</span><span class="sxs-lookup"><span data-stu-id="adf8b-174">Request URI</span></span>
:------     | :-----
<span data-ttu-id="adf8b-175">DELETE</span><span class="sxs-lookup"><span data-stu-id="adf8b-175">DELETE</span></span> | <span data-ttu-id="adf8b-176">/ext/fiddler</span><span class="sxs-lookup"><span data-stu-id="adf8b-176">/ext/fiddler</span></span>
<br />
**<span data-ttu-id="adf8b-177">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="adf8b-177">URI parameters</span></span>**

- <span data-ttu-id="adf8b-178">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-178">None</span></span>

**<span data-ttu-id="adf8b-179">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="adf8b-179">Request headers</span></span>**

- <span data-ttu-id="adf8b-180">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-180">None</span></span>

**<span data-ttu-id="adf8b-181">要求本文</span><span class="sxs-lookup"><span data-stu-id="adf8b-181">Request body</span></span>**   

- <span data-ttu-id="adf8b-182">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-182">None</span></span>

**<span data-ttu-id="adf8b-183">応答</span><span class="sxs-lookup"><span data-stu-id="adf8b-183">Response</span></span>**   

- <span data-ttu-id="adf8b-184">なし</span><span class="sxs-lookup"><span data-stu-id="adf8b-184">None</span></span> 

**<span data-ttu-id="adf8b-185">状態コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-185">Status code</span></span>**

<span data-ttu-id="adf8b-186">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="adf8b-186">This API has the following expected status codes.</span></span>

<span data-ttu-id="adf8b-187">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-187">HTTP status code</span></span>      | <span data-ttu-id="adf8b-188">説明</span><span class="sxs-lookup"><span data-stu-id="adf8b-188">Description</span></span>
:------     | :-----
<span data-ttu-id="adf8b-189">204</span><span class="sxs-lookup"><span data-stu-id="adf8b-189">204</span></span> | <span data-ttu-id="adf8b-190">Fiddler のトレースを無効にする要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="adf8b-190">The request to disable Fiddler tracing was successful.</span></span> <span data-ttu-id="adf8b-191">トレースは、次回デバイスを再起動したときに無効になります。</span><span class="sxs-lookup"><span data-stu-id="adf8b-191">Tracing will be disabled on the next reboot of the device.</span></span>
<span data-ttu-id="adf8b-192">4XX</span><span class="sxs-lookup"><span data-stu-id="adf8b-192">4XX</span></span> | <span data-ttu-id="adf8b-193">エラー コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-193">Error codes</span></span>
<span data-ttu-id="adf8b-194">5XX</span><span class="sxs-lookup"><span data-stu-id="adf8b-194">5XX</span></span> | <span data-ttu-id="adf8b-195">エラー コード</span><span class="sxs-lookup"><span data-stu-id="adf8b-195">Error codes</span></span>

<br />
**<span data-ttu-id="adf8b-196">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="adf8b-196">Available device families</span></span>**

* <span data-ttu-id="adf8b-197">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="adf8b-197">Windows Xbox</span></span>

## <a name="see-also"></a><span data-ttu-id="adf8b-198">参照</span><span class="sxs-lookup"><span data-stu-id="adf8b-198">See also</span></span>
- [<span data-ttu-id="adf8b-199">Xbox の UWP での Fiddler の構成</span><span class="sxs-lookup"><span data-stu-id="adf8b-199">Configuring Fiddler for UWP on Xbox</span></span>](uwp-fiddler.md)

