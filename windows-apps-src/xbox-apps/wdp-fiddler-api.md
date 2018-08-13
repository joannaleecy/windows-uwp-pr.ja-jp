---
author: WilliamsJason
title: Device Portal の Fiddler API のリファレンス
description: プログラムによって Fiddler のトレースを有効または無効にする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: e7d4225e-ac2c-41dc-aca7-9b1a95ec590b
ms.localizationpriority: medium
ms.openlocfilehash: 819f039f04d1e0a7fd035b10e3cbe408645e8f4d
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "409942"
---
# <a name="fiddler-settings-api-reference"></a><span data-ttu-id="33dc0-104">Fiddler 設定 API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="33dc0-104">Fiddler settings API reference</span></span>   
<span data-ttu-id="33dc0-105">この REST API を使って、開発機での Fiddler のネットワーク トレースを有効または無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="33dc0-105">You can enable and disable Fiddler network tracing on your devkit using this REST API.</span></span>

## <a name="determine-if-fiddler-tracing-is-enabled"></a><span data-ttu-id="33dc0-106">Fiddler トレースが有効になっているかどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="33dc0-106">Determine if Fiddler tracing is enabled</span></span>

**<span data-ttu-id="33dc0-107">要求</span><span class="sxs-lookup"><span data-stu-id="33dc0-107">Request</span></span>**

<span data-ttu-id="33dc0-108">次のような要求を使用して、デバイス上 Fiddler トレースが有効になっているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="33dc0-108">You can check to see if Fiddler tracing is enabled on the device using the following request.</span></span>

<span data-ttu-id="33dc0-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="33dc0-109">Method</span></span>      | <span data-ttu-id="33dc0-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="33dc0-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="33dc0-111">GET</span><span class="sxs-lookup"><span data-stu-id="33dc0-111">GET</span></span> | <span data-ttu-id="33dc0-112">/ext/fiddler</span><span class="sxs-lookup"><span data-stu-id="33dc0-112">/ext/fiddler</span></span>
<br />
**<span data-ttu-id="33dc0-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="33dc0-113">URI parameters</span></span>**

- <span data-ttu-id="33dc0-114">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-114">None</span></span>

**<span data-ttu-id="33dc0-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33dc0-115">Request headers</span></span>**

- <span data-ttu-id="33dc0-116">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-116">None</span></span>

**<span data-ttu-id="33dc0-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="33dc0-117">Request body</span></span>**   

- <span data-ttu-id="33dc0-118">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-118">None</span></span>

**<span data-ttu-id="33dc0-119">応答</span><span class="sxs-lookup"><span data-stu-id="33dc0-119">Response</span></span>**   

- <span data-ttu-id="33dc0-120">JSON ブール プロパティ IsProxyEnabled どの指定子かどうかどうか、プロキシを有効にします。</span><span class="sxs-lookup"><span data-stu-id="33dc0-120">JSON bool property IsProxyEnabled which specifiers whether the proxy is enabled or not.</span></span>

**<span data-ttu-id="33dc0-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-121">Status code</span></span>**

<span data-ttu-id="33dc0-122">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33dc0-122">This API has the following expected status codes.</span></span>

<span data-ttu-id="33dc0-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-123">HTTP status code</span></span>      | <span data-ttu-id="33dc0-124">説明</span><span class="sxs-lookup"><span data-stu-id="33dc0-124">Description</span></span>
:------     | :-----
<span data-ttu-id="33dc0-125">200</span><span class="sxs-lookup"><span data-stu-id="33dc0-125">200</span></span> | <span data-ttu-id="33dc0-126">成功</span><span class="sxs-lookup"><span data-stu-id="33dc0-126">Success</span></span>
<span data-ttu-id="33dc0-127">4XX</span><span class="sxs-lookup"><span data-stu-id="33dc0-127">4XX</span></span> | <span data-ttu-id="33dc0-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-128">Error codes</span></span>
<span data-ttu-id="33dc0-129">5XX</span><span class="sxs-lookup"><span data-stu-id="33dc0-129">5XX</span></span> | <span data-ttu-id="33dc0-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-130">Error codes</span></span>

## <a name="enable-fiddler-tracing"></a><span data-ttu-id="33dc0-131">Fiddler のトレースを有効にする</span><span class="sxs-lookup"><span data-stu-id="33dc0-131">Enable Fiddler tracing</span></span>

**<span data-ttu-id="33dc0-132">要求</span><span class="sxs-lookup"><span data-stu-id="33dc0-132">Request</span></span>**

<span data-ttu-id="33dc0-133">次の要求を使って、開発機の Fiddler のトレースを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="33dc0-133">You can enable Fiddler tracing for the devkit using the following request.</span></span>  <span data-ttu-id="33dc0-134">この設定を有効にするには、デバイスを再起動する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="33dc0-134">Note that the device must be restarted before this takes effect.</span></span>

<span data-ttu-id="33dc0-135">メソッド</span><span class="sxs-lookup"><span data-stu-id="33dc0-135">Method</span></span>      | <span data-ttu-id="33dc0-136">要求 URI</span><span class="sxs-lookup"><span data-stu-id="33dc0-136">Request URI</span></span>
:------     | :-----
<span data-ttu-id="33dc0-137">POST</span><span class="sxs-lookup"><span data-stu-id="33dc0-137">POST</span></span> | <span data-ttu-id="33dc0-138">/ext/fiddler</span><span class="sxs-lookup"><span data-stu-id="33dc0-138">/ext/fiddler</span></span>
<br />
**<span data-ttu-id="33dc0-139">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="33dc0-139">URI parameters</span></span>**

<span data-ttu-id="33dc0-140">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="33dc0-140">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="33dc0-141">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="33dc0-141">URI parameter</span></span>      | <span data-ttu-id="33dc0-142">説明</span><span class="sxs-lookup"><span data-stu-id="33dc0-142">Description</span></span>     | 
| ------------------ |-----------------|
| <span data-ttu-id="33dc0-143">proxyAddress</span><span class="sxs-lookup"><span data-stu-id="33dc0-143">proxyAddress</span></span>       | <span data-ttu-id="33dc0-144">Fiddler を実行しているデバイスの IP アドレスまたはホスト名</span><span class="sxs-lookup"><span data-stu-id="33dc0-144">The IP address or hostname of the device running Fiddler</span></span> |
| <span data-ttu-id="33dc0-145">proxyPort</span><span class="sxs-lookup"><span data-stu-id="33dc0-145">proxyPort</span></span>          | <span data-ttu-id="33dc0-146">トラフィックを監視するために Fiddler が使用しているポート。</span><span class="sxs-lookup"><span data-stu-id="33dc0-146">The port which Fiddler is using for monitoring traffic.</span></span> <span data-ttu-id="33dc0-147">既定では 8888</span><span class="sxs-lookup"><span data-stu-id="33dc0-147">Defaults to 8888</span></span> |
| <span data-ttu-id="33dc0-148">updateCert (省略可能)</span><span class="sxs-lookup"><span data-stu-id="33dc0-148">updateCert (optional)</span></span>| <span data-ttu-id="33dc0-149">Fiddler のルート証明書が提供されているかどうかを示すブール値。</span><span class="sxs-lookup"><span data-stu-id="33dc0-149">A boolean value indicating if the root Fiddler cert is provided.</span></span> <span data-ttu-id="33dc0-150">Fiddler がこの開発機で構成されたことがない場合や、別のホストで構成されていた場合は、true を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="33dc0-150">This must be true if Fiddler has never been configured on this devkit or was configured for a different host.</span></span>  |
<br>

**<span data-ttu-id="33dc0-151">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33dc0-151">Request headers</span></span>**

- <span data-ttu-id="33dc0-152">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-152">None</span></span>

**<span data-ttu-id="33dc0-153">要求本文</span><span class="sxs-lookup"><span data-stu-id="33dc0-153">Request body</span></span>**

- <span data-ttu-id="33dc0-154">updateCert が false である場合や指定されていない場合は、なし。</span><span class="sxs-lookup"><span data-stu-id="33dc0-154">None if updateCert is false or not provided.</span></span> <span data-ttu-id="33dc0-155">それ以外の場合は、FiddlerRoot.cer ファイルを格納する、原則に従ったマルチパートの http 本文。</span><span class="sxs-lookup"><span data-stu-id="33dc0-155">Multi-part conforming http body containing the FiddlerRoot.cer file otherwise.</span></span>

**<span data-ttu-id="33dc0-156">応答</span><span class="sxs-lookup"><span data-stu-id="33dc0-156">Response</span></span>**   

- <span data-ttu-id="33dc0-157">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-157">None</span></span>  

**<span data-ttu-id="33dc0-158">状態コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-158">Status code</span></span>**

<span data-ttu-id="33dc0-159">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33dc0-159">This API has the following expected status codes.</span></span>

<span data-ttu-id="33dc0-160">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-160">HTTP status code</span></span>      | <span data-ttu-id="33dc0-161">説明</span><span class="sxs-lookup"><span data-stu-id="33dc0-161">Description</span></span>
:------     | :-----
<span data-ttu-id="33dc0-162">204</span><span class="sxs-lookup"><span data-stu-id="33dc0-162">204</span></span> | <span data-ttu-id="33dc0-163">Fiddler を有効にする要求が受け付けられました。</span><span class="sxs-lookup"><span data-stu-id="33dc0-163">The request to enable Fiddler was accepted.</span></span> <span data-ttu-id="33dc0-164">Fiddler は、次回デバイスを再起動したときに有効になります。</span><span class="sxs-lookup"><span data-stu-id="33dc0-164">Fiddler will be enabled the next time the device reboots.</span></span>
<span data-ttu-id="33dc0-165">4XX</span><span class="sxs-lookup"><span data-stu-id="33dc0-165">4XX</span></span> | <span data-ttu-id="33dc0-166">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-166">Error codes</span></span>
<span data-ttu-id="33dc0-167">5XX</span><span class="sxs-lookup"><span data-stu-id="33dc0-167">5XX</span></span> | <span data-ttu-id="33dc0-168">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-168">Error codes</span></span>

## <a name="disable-fiddler-tracing-on-the-devkit"></a><span data-ttu-id="33dc0-169">開発機で Fiddler のトレースを無効にする</span><span class="sxs-lookup"><span data-stu-id="33dc0-169">Disable Fiddler tracing on the devkit</span></span>

**<span data-ttu-id="33dc0-170">要求</span><span class="sxs-lookup"><span data-stu-id="33dc0-170">Request</span></span>**

<span data-ttu-id="33dc0-171">次の要求を使って、デバイスでの Fiddler のトレースを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="33dc0-171">You can disable Fiddler tracing on the device using the following request.</span></span> <span data-ttu-id="33dc0-172">この設定を有効にするには、デバイスを再起動する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="33dc0-172">Note that the device must be restarted before this takes effect.</span></span>

<span data-ttu-id="33dc0-173">メソッド</span><span class="sxs-lookup"><span data-stu-id="33dc0-173">Method</span></span>      | <span data-ttu-id="33dc0-174">要求 URI</span><span class="sxs-lookup"><span data-stu-id="33dc0-174">Request URI</span></span>
:------     | :-----
<span data-ttu-id="33dc0-175">DELETE</span><span class="sxs-lookup"><span data-stu-id="33dc0-175">DELETE</span></span> | <span data-ttu-id="33dc0-176">/ext/fiddler</span><span class="sxs-lookup"><span data-stu-id="33dc0-176">/ext/fiddler</span></span>
<br />
**<span data-ttu-id="33dc0-177">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="33dc0-177">URI parameters</span></span>**

- <span data-ttu-id="33dc0-178">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-178">None</span></span>

**<span data-ttu-id="33dc0-179">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="33dc0-179">Request headers</span></span>**

- <span data-ttu-id="33dc0-180">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-180">None</span></span>

**<span data-ttu-id="33dc0-181">要求本文</span><span class="sxs-lookup"><span data-stu-id="33dc0-181">Request body</span></span>**   

- <span data-ttu-id="33dc0-182">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-182">None</span></span>

**<span data-ttu-id="33dc0-183">応答</span><span class="sxs-lookup"><span data-stu-id="33dc0-183">Response</span></span>**   

- <span data-ttu-id="33dc0-184">なし</span><span class="sxs-lookup"><span data-stu-id="33dc0-184">None</span></span> 

**<span data-ttu-id="33dc0-185">状態コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-185">Status code</span></span>**

<span data-ttu-id="33dc0-186">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="33dc0-186">This API has the following expected status codes.</span></span>

<span data-ttu-id="33dc0-187">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-187">HTTP status code</span></span>      | <span data-ttu-id="33dc0-188">説明</span><span class="sxs-lookup"><span data-stu-id="33dc0-188">Description</span></span>
:------     | :-----
<span data-ttu-id="33dc0-189">204</span><span class="sxs-lookup"><span data-stu-id="33dc0-189">204</span></span> | <span data-ttu-id="33dc0-190">Fiddler のトレースを無効にする要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="33dc0-190">The request to disable Fiddler tracing was successful.</span></span> <span data-ttu-id="33dc0-191">トレースは、次回デバイスを再起動したときに無効になります。</span><span class="sxs-lookup"><span data-stu-id="33dc0-191">Tracing will be disabled on the next reboot of the device.</span></span>
<span data-ttu-id="33dc0-192">4XX</span><span class="sxs-lookup"><span data-stu-id="33dc0-192">4XX</span></span> | <span data-ttu-id="33dc0-193">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-193">Error codes</span></span>
<span data-ttu-id="33dc0-194">5XX</span><span class="sxs-lookup"><span data-stu-id="33dc0-194">5XX</span></span> | <span data-ttu-id="33dc0-195">エラー コード</span><span class="sxs-lookup"><span data-stu-id="33dc0-195">Error codes</span></span>

<br />
**<span data-ttu-id="33dc0-196">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="33dc0-196">Available device families</span></span>**

* <span data-ttu-id="33dc0-197">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="33dc0-197">Windows Xbox</span></span>

## <a name="see-also"></a><span data-ttu-id="33dc0-198">参照</span><span class="sxs-lookup"><span data-stu-id="33dc0-198">See also</span></span>
- [<span data-ttu-id="33dc0-199">Xbox の UWP での Fiddler の構成</span><span class="sxs-lookup"><span data-stu-id="33dc0-199">Configuring Fiddler for UWP on Xbox</span></span>](uwp-fiddler.md)

