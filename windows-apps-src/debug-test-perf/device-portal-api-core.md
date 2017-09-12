---
author: mukin
ms.assetid: bfabd3d5-dd56-4917-9572-f3ba0de4f8c0
title: "デバイス ポータル コア API リファレンス"
description: "Windows Device Portal コア REST API について説明します。これによって、データにアクセスし、プログラムを使ってデバイスを制御することが可能になります。"
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b6df8f361df82ef65098877027cf1857fa575b0b
ms.sourcegitcommit: d2ec178103f49b198da2ee486f1681e38dcc8e7b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/28/2017
---
# <a name="device-portal-core-api-reference"></a><span data-ttu-id="da3fe-104">デバイス ポータル コア API リファレンス</span><span class="sxs-lookup"><span data-stu-id="da3fe-104">Device Portal core API reference</span></span>

<span data-ttu-id="da3fe-105">Windows Device Portal の機能はすべて、REST API の上に構築されています。REST API は、プログラムからデータにアクセスしてデバイスを制御するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-105">Everything in the Windows Device Portal is built on top of REST APIs that you can use to access the data and control your device programmatically.</span></span>

## <a name="app-deployment"></a><span data-ttu-id="da3fe-106">アプリの展開</span><span class="sxs-lookup"><span data-stu-id="da3fe-106">App deployment</span></span>

---
### <a name="install-an-app"></a><span data-ttu-id="da3fe-107">アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="da3fe-107">Install an app</span></span>

**<span data-ttu-id="da3fe-108">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-108">Request</span></span>**

<span data-ttu-id="da3fe-109">次の要求形式を使用して、アプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-109">You can install an app by using the following request format.</span></span>

<span data-ttu-id="da3fe-110">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-110">Method</span></span>      | <span data-ttu-id="da3fe-111">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-111">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-112">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-112">POST</span></span> | <span data-ttu-id="da3fe-113">/api/app/packagemanager/package</span><span class="sxs-lookup"><span data-stu-id="da3fe-113">/api/app/packagemanager/package</span></span>
<br />
**<span data-ttu-id="da3fe-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-114">URI parameters</span></span>**

<span data-ttu-id="da3fe-115">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-115">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-116">URI parameter</span></span> | <span data-ttu-id="da3fe-117">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-117">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-118">package</span><span class="sxs-lookup"><span data-stu-id="da3fe-118">package</span></span>   | <span data-ttu-id="da3fe-119">(**必須**) インストールするパッケージのファイル名。</span><span class="sxs-lookup"><span data-stu-id="da3fe-119">(**required**) The file name of the package to be installed.</span></span>
<br />
**<span data-ttu-id="da3fe-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-120">Request headers</span></span>**

- <span data-ttu-id="da3fe-121">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-121">None</span></span>

**<span data-ttu-id="da3fe-122">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-122">Request body</span></span>**

- <span data-ttu-id="da3fe-123">.appx または .appxbundle ファイル、およびアプリが必要とする依存関係。</span><span class="sxs-lookup"><span data-stu-id="da3fe-123">The .appx or .appxbundle file, as well as any dependencies the app requires.</span></span> 
- <span data-ttu-id="da3fe-124">デバイスが IoT または Windows デスクトップの場合、アプリの署名に使う証明書。</span><span class="sxs-lookup"><span data-stu-id="da3fe-124">The certificate used to sign the app, if the device is IoT or Windows Desktop.</span></span> <span data-ttu-id="da3fe-125">その他のプラットフォームでは、証明書は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="da3fe-125">Other platforms do not require the certificate.</span></span> 

**<span data-ttu-id="da3fe-126">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-126">Response</span></span>**

**<span data-ttu-id="da3fe-127">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-127">Status code</span></span>**

<span data-ttu-id="da3fe-128">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-128">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-129">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-129">HTTP status code</span></span>      | <span data-ttu-id="da3fe-130">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-130">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-131">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-131">200</span></span> | <span data-ttu-id="da3fe-132">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="da3fe-132">Deploy request accepted and being processed</span></span>
<span data-ttu-id="da3fe-133">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-133">4XX</span></span> | <span data-ttu-id="da3fe-134">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-134">Error codes</span></span>
<span data-ttu-id="da3fe-135">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-135">5XX</span></span> | <span data-ttu-id="da3fe-136">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-136">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-137">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-137">Available device families</span></span>**

* <span data-ttu-id="da3fe-138">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-138">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-139">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-139">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-140">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-140">Xbox</span></span>
* <span data-ttu-id="da3fe-141">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-141">HoloLens</span></span>
* <span data-ttu-id="da3fe-142">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-142">IoT</span></span>

---
### <a name="get-app-installation-status"></a><span data-ttu-id="da3fe-143">アプリのインストール状態を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-143">Get app installation status</span></span>

**<span data-ttu-id="da3fe-144">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-144">Request</span></span>**

<span data-ttu-id="da3fe-145">次の要求形式を使用して、現在進行中のアプリのインストールの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-145">You can get the status of an app installation that is currently in progress by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-146">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-146">Method</span></span>      | <span data-ttu-id="da3fe-147">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-147">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-148">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-148">GET</span></span> | <span data-ttu-id="da3fe-149">/api/app/packagemanager/state</span><span class="sxs-lookup"><span data-stu-id="da3fe-149">/api/app/packagemanager/state</span></span>
<br />
**<span data-ttu-id="da3fe-150">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-150">URI parameters</span></span>**

- <span data-ttu-id="da3fe-151">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-151">None</span></span>

**<span data-ttu-id="da3fe-152">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-152">Request headers</span></span>**

- <span data-ttu-id="da3fe-153">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-153">None</span></span>

**<span data-ttu-id="da3fe-154">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-154">Request body</span></span>**

- <span data-ttu-id="da3fe-155">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-155">None</span></span>

**<span data-ttu-id="da3fe-156">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-156">Response</span></span>**

**<span data-ttu-id="da3fe-157">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-157">Status code</span></span>**

<span data-ttu-id="da3fe-158">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-158">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-159">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-159">HTTP status code</span></span>      | <span data-ttu-id="da3fe-160">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-160">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-161">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-161">200</span></span> | <span data-ttu-id="da3fe-162">最後の展開の結果</span><span class="sxs-lookup"><span data-stu-id="da3fe-162">The result of the last deployment</span></span>
<span data-ttu-id="da3fe-163">204</span><span class="sxs-lookup"><span data-stu-id="da3fe-163">204</span></span> | <span data-ttu-id="da3fe-164">インストールは実行中です</span><span class="sxs-lookup"><span data-stu-id="da3fe-164">The installation is running</span></span>
<span data-ttu-id="da3fe-165">404</span><span class="sxs-lookup"><span data-stu-id="da3fe-165">404</span></span> | <span data-ttu-id="da3fe-166">インストール操作は見つかりませんでした</span><span class="sxs-lookup"><span data-stu-id="da3fe-166">No installation action was found</span></span>
<br />
**<span data-ttu-id="da3fe-167">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-167">Available device families</span></span>**

* <span data-ttu-id="da3fe-168">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-168">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-169">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-169">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-170">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-170">Xbox</span></span>
* <span data-ttu-id="da3fe-171">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-171">HoloLens</span></span>
* <span data-ttu-id="da3fe-172">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-172">IoT</span></span>

---
### <a name="uninstall-an-app"></a><span data-ttu-id="da3fe-173">アプリをアンインストールする</span><span class="sxs-lookup"><span data-stu-id="da3fe-173">Uninstall an app</span></span>

**<span data-ttu-id="da3fe-174">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-174">Request</span></span>**

<span data-ttu-id="da3fe-175">次の要求形式を使用して、アプリをアンインストールできます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-175">You can uninstall an app by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-176">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-176">Method</span></span>      | <span data-ttu-id="da3fe-177">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-177">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-178">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-178">DELETE</span></span> | <span data-ttu-id="da3fe-179">/api/app/packagemanager/package</span><span class="sxs-lookup"><span data-stu-id="da3fe-179">/api/app/packagemanager/package</span></span>
<br />

**<span data-ttu-id="da3fe-180">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-180">URI parameters</span></span>**

<span data-ttu-id="da3fe-181">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-181">URI parameter</span></span> | <span data-ttu-id="da3fe-182">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-182">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-183">package</span><span class="sxs-lookup"><span data-stu-id="da3fe-183">package</span></span>   | <span data-ttu-id="da3fe-184">(**必須**) ターゲット アプリの PackageFullName (GET /api/app/packagemanager/packages から)</span><span class="sxs-lookup"><span data-stu-id="da3fe-184">(**required**) The PackageFullName (from GET /api/app/packagemanager/packages) of the target app</span></span>

**<span data-ttu-id="da3fe-185">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-185">Request headers</span></span>**

- <span data-ttu-id="da3fe-186">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-186">None</span></span>

**<span data-ttu-id="da3fe-187">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-187">Request body</span></span>**

- <span data-ttu-id="da3fe-188">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-188">None</span></span>

**<span data-ttu-id="da3fe-189">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-189">Response</span></span>**

**<span data-ttu-id="da3fe-190">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-190">Status code</span></span>**

<span data-ttu-id="da3fe-191">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-191">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-192">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-192">HTTP status code</span></span>      | <span data-ttu-id="da3fe-193">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-193">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-194">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-194">200</span></span> | <span data-ttu-id="da3fe-195">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-195">OK</span></span>
<span data-ttu-id="da3fe-196">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-196">4XX</span></span> | <span data-ttu-id="da3fe-197">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-197">Error codes</span></span>
<span data-ttu-id="da3fe-198">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-198">5XX</span></span> | <span data-ttu-id="da3fe-199">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-199">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-200">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-200">Available device families</span></span>**

* <span data-ttu-id="da3fe-201">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-201">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-202">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-202">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-203">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-203">Xbox</span></span>
* <span data-ttu-id="da3fe-204">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-204">HoloLens</span></span>
* <span data-ttu-id="da3fe-205">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-205">IoT</span></span>

---
### <a name="get-installed-apps"></a><span data-ttu-id="da3fe-206">インストールされたアプリを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-206">Get installed apps</span></span>

**<span data-ttu-id="da3fe-207">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-207">Request</span></span>**

<span data-ttu-id="da3fe-208">次の要求形式を使用して、システムにインストールされているアプリの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-208">You can get a list of apps installed on the system by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-209">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-209">Method</span></span>      | <span data-ttu-id="da3fe-210">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-210">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-211">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-211">GET</span></span> | <span data-ttu-id="da3fe-212">/api/app/packagemanager/packages</span><span class="sxs-lookup"><span data-stu-id="da3fe-212">/api/app/packagemanager/packages</span></span>
<br />

**<span data-ttu-id="da3fe-213">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-213">URI parameters</span></span>**

- <span data-ttu-id="da3fe-214">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-214">None</span></span>

**<span data-ttu-id="da3fe-215">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-215">Request headers</span></span>**

- <span data-ttu-id="da3fe-216">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-216">None</span></span>

**<span data-ttu-id="da3fe-217">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-217">Request body</span></span>**

- <span data-ttu-id="da3fe-218">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-218">None</span></span>

**<span data-ttu-id="da3fe-219">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-219">Response</span></span>**

<span data-ttu-id="da3fe-220">応答には、インストールされているパッケージの一覧と関連する詳細情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-220">The response includes a list of installed packages with associated details.</span></span> <span data-ttu-id="da3fe-221">この応答のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-221">The template for this response is as follows.</span></span>
```
{"InstalledPackages": [
    {
        "Name": string,
        "PackageFamilyName": string,
        "PackageFullName": string,
        "PackageOrigin": int, (https://msdn.microsoft.com/en-us/library/windows/desktop/dn313167(v=vs.85).aspx)
        "PackageRelativeId": string,
        "Publisher": string,
        "Version": {
            "Build": int,
            "Major": int,
            "Minor": int,
            "Revision": int
     },
     "RegisteredUsers": [
     {
        "UserDisplayName": string,
        "UserSID": string
     },...
     ]
    },...
]}
```
**<span data-ttu-id="da3fe-222">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-222">Status code</span></span>**

<span data-ttu-id="da3fe-223">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-223">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-224">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-224">HTTP status code</span></span>      | <span data-ttu-id="da3fe-225">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-225">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-226">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-226">200</span></span> | <span data-ttu-id="da3fe-227">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-227">OK</span></span>
<span data-ttu-id="da3fe-228">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-228">4XX</span></span> | <span data-ttu-id="da3fe-229">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-229">Error codes</span></span>
<span data-ttu-id="da3fe-230">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-230">5XX</span></span> | <span data-ttu-id="da3fe-231">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-231">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-232">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-232">Available device families</span></span>**

* <span data-ttu-id="da3fe-233">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-233">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-234">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-234">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-235">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-235">Xbox</span></span>
* <span data-ttu-id="da3fe-236">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-236">HoloLens</span></span>
* <span data-ttu-id="da3fe-237">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-237">IoT</span></span>

---
## Device manager
---
### <a name="get-the-installed-devices-on-the-machine"></a><span data-ttu-id="da3fe-238">コンピューターにインストールされているデバイスを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-238">Get the installed devices on the machine</span></span>

**<span data-ttu-id="da3fe-239">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-239">Request</span></span>**

<span data-ttu-id="da3fe-240">次の要求形式を使用して、コンピューターにインストールされているデバイスの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-240">You can get a list of devices that are installed on the machine by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-241">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-241">Method</span></span>      | <span data-ttu-id="da3fe-242">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-242">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-243">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-243">GET</span></span> | <span data-ttu-id="da3fe-244">/api/devicemanager/devices</span><span class="sxs-lookup"><span data-stu-id="da3fe-244">/api/devicemanager/devices</span></span>
<br />

**<span data-ttu-id="da3fe-245">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-245">URI parameters</span></span>**

- <span data-ttu-id="da3fe-246">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-246">None</span></span>

**<span data-ttu-id="da3fe-247">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-247">Request headers</span></span>**

- <span data-ttu-id="da3fe-248">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-248">None</span></span>

**<span data-ttu-id="da3fe-249">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-249">Request body</span></span>**

- <span data-ttu-id="da3fe-250">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-250">None</span></span>

**<span data-ttu-id="da3fe-251">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-251">Response</span></span>**

<span data-ttu-id="da3fe-252">応答には、デバイスにアタッチされているデバイスの JSON 配列が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-252">The response includes a JSON array of devices attached to the device.</span></span>
``` 
{"DeviceList": [
    {
        "Class": string,
        "Description": string,
        "ID": string,
        "Manufacturer": string,
        "ParentID": string,
        "ProblemCode": int,
        "StatusCode": int
    },...
]}
```

**<span data-ttu-id="da3fe-253">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-253">Status code</span></span>**

<span data-ttu-id="da3fe-254">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-254">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-255">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-255">HTTP status code</span></span>      | <span data-ttu-id="da3fe-256">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-256">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-257">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-257">200</span></span> | <span data-ttu-id="da3fe-258">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-258">OK</span></span>
<span data-ttu-id="da3fe-259">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-259">4XX</span></span> | <span data-ttu-id="da3fe-260">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-260">Error codes</span></span>
<span data-ttu-id="da3fe-261">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-261">5XX</span></span> | <span data-ttu-id="da3fe-262">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-262">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-263">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-263">Available device families</span></span>**

* <span data-ttu-id="da3fe-264">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-264">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-265">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-265">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-266">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-266">IoT</span></span>

---
## Dump collection
---
### <a name="get-the-list-of-all-crash-dumps-for-apps"></a><span data-ttu-id="da3fe-267">アプリのすべてのクラッシュ ダンプの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-267">Get the list of all crash dumps for apps</span></span>

**<span data-ttu-id="da3fe-268">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-268">Request</span></span>**

<span data-ttu-id="da3fe-269">次の要求形式を使用して、サイドローディングされたすべてのアプリについて、利用可能なすべてのクラッシュ ダンプの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-269">You can get the list of all the available crash dumps for all sideloaded apps by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-270">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-270">Method</span></span>      | <span data-ttu-id="da3fe-271">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-271">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-272">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-272">GET</span></span> | <span data-ttu-id="da3fe-273">/api/debug/dump/usermode/dumps</span><span class="sxs-lookup"><span data-stu-id="da3fe-273">/api/debug/dump/usermode/dumps</span></span>
<br />

**<span data-ttu-id="da3fe-274">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-274">URI parameters</span></span>**

- <span data-ttu-id="da3fe-275">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-275">None</span></span>

**<span data-ttu-id="da3fe-276">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-276">Request headers</span></span>**

- <span data-ttu-id="da3fe-277">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-277">None</span></span>

**<span data-ttu-id="da3fe-278">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-278">Request body</span></span>**

- <span data-ttu-id="da3fe-279">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-279">None</span></span>

**<span data-ttu-id="da3fe-280">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-280">Response</span></span>**

<span data-ttu-id="da3fe-281">応答には、サイドローディングされたアプリケーションごとにクラッシュ ダンプの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-281">The response includes a list of crash dumps for each sideloaded application.</span></span>

**<span data-ttu-id="da3fe-282">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-282">Status code</span></span>**

<span data-ttu-id="da3fe-283">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-283">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-284">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-284">HTTP status code</span></span>      | <span data-ttu-id="da3fe-285">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-285">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-286">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-286">200</span></span> | <span data-ttu-id="da3fe-287">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-287">OK</span></span>
<span data-ttu-id="da3fe-288">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-288">4XX</span></span> | <span data-ttu-id="da3fe-289">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-289">Error codes</span></span>
<span data-ttu-id="da3fe-290">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-290">5XX</span></span> | <span data-ttu-id="da3fe-291">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-291">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-292">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-292">Available device families</span></span>**

* <span data-ttu-id="da3fe-293">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="da3fe-293">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="da3fe-294">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-294">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-295">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-295">HoloLens</span></span>
* <span data-ttu-id="da3fe-296">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-296">IoT</span></span>

---
### <a name="get-the-crash-dump-collection-settings-for-an-app"></a><span data-ttu-id="da3fe-297">アプリのクラッシュ ダンプ収集設定を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-297">Get the crash dump collection settings for an app</span></span>

**<span data-ttu-id="da3fe-298">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-298">Request</span></span>**

<span data-ttu-id="da3fe-299">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプ収集設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-299">You can get the crash dump collection settings for a sideloaded app by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-300">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-300">Method</span></span>      | <span data-ttu-id="da3fe-301">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-301">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-302">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-302">GET</span></span> | <span data-ttu-id="da3fe-303">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="da3fe-303">/api/debug/dump/usermode/crashcontrol</span></span>
<br />

**<span data-ttu-id="da3fe-304">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-304">URI parameters</span></span>**

<span data-ttu-id="da3fe-305">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-305">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-306">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-306">URI parameter</span></span> | <span data-ttu-id="da3fe-307">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-307">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-308">packageFullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-308">packageFullname</span></span>   | <span data-ttu-id="da3fe-309">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-309">(**required**) The full name of the package for the sideloaded app.</span></span>
<br />
**<span data-ttu-id="da3fe-310">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-310">Request headers</span></span>**

- <span data-ttu-id="da3fe-311">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-311">None</span></span>

**<span data-ttu-id="da3fe-312">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-312">Request body</span></span>**

- <span data-ttu-id="da3fe-313">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-313">None</span></span>

**<span data-ttu-id="da3fe-314">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-314">Response</span></span>**

<span data-ttu-id="da3fe-315">応答は、次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-315">The response has the following format.</span></span>
```
{"CrashDumpEnabled": bool}
```

**<span data-ttu-id="da3fe-316">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-316">Status code</span></span>**

<span data-ttu-id="da3fe-317">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-317">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-318">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-318">HTTP status code</span></span>      | <span data-ttu-id="da3fe-319">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-319">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-320">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-320">200</span></span> | <span data-ttu-id="da3fe-321">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-321">OK</span></span>
<span data-ttu-id="da3fe-322">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-322">4XX</span></span> | <span data-ttu-id="da3fe-323">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-323">Error codes</span></span>
<span data-ttu-id="da3fe-324">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-324">5XX</span></span> | <span data-ttu-id="da3fe-325">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-325">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-326">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-326">Available device families</span></span>**

* <span data-ttu-id="da3fe-327">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="da3fe-327">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="da3fe-328">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-328">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-329">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-329">HoloLens</span></span>
* <span data-ttu-id="da3fe-330">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-330">IoT</span></span>

---
### <a name="delete-a-crash-dump-for-a-sideloaded-app"></a><span data-ttu-id="da3fe-331">サイドローディングされたアプリのクラッシュ ダンプを削除する</span><span class="sxs-lookup"><span data-stu-id="da3fe-331">Delete a crash dump for a sideloaded app</span></span>

**<span data-ttu-id="da3fe-332">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-332">Request</span></span>**

<span data-ttu-id="da3fe-333">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを削除できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-333">You can delete a sideloaded app's crash dump by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-334">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-334">Method</span></span>      | <span data-ttu-id="da3fe-335">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-335">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-336">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-336">DELETE</span></span> | <span data-ttu-id="da3fe-337">/api/debug/dump/usermode/crashdump</span><span class="sxs-lookup"><span data-stu-id="da3fe-337">/api/debug/dump/usermode/crashdump</span></span>
<br />

**<span data-ttu-id="da3fe-338">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-338">URI parameters</span></span>**

<span data-ttu-id="da3fe-339">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-339">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-340">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-340">URI parameter</span></span> | <span data-ttu-id="da3fe-341">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-341">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-342">packageFullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-342">packageFullname</span></span>   | <span data-ttu-id="da3fe-343">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-343">(**required**) The full name of the package for the sideloaded app.</span></span>
<span data-ttu-id="da3fe-344">fileName</span><span class="sxs-lookup"><span data-stu-id="da3fe-344">fileName</span></span>   | <span data-ttu-id="da3fe-345">(**必須**) 削除する必要があるダンプ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-345">(**required**) The name of the dump file that should be deleted.</span></span>
<br />
**<span data-ttu-id="da3fe-346">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-346">Request headers</span></span>**

- <span data-ttu-id="da3fe-347">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-347">None</span></span>

**<span data-ttu-id="da3fe-348">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-348">Request body</span></span>**

- <span data-ttu-id="da3fe-349">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-349">None</span></span>

**<span data-ttu-id="da3fe-350">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-350">Response</span></span>**

**<span data-ttu-id="da3fe-351">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-351">Status code</span></span>**

<span data-ttu-id="da3fe-352">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-352">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-353">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-353">HTTP status code</span></span>      | <span data-ttu-id="da3fe-354">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-354">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-355">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-355">200</span></span> | <span data-ttu-id="da3fe-356">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-356">OK</span></span>
<span data-ttu-id="da3fe-357">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-357">4XX</span></span> | <span data-ttu-id="da3fe-358">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-358">Error codes</span></span>
<span data-ttu-id="da3fe-359">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-359">5XX</span></span> | <span data-ttu-id="da3fe-360">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-360">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-361">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-361">Available device families</span></span>**

* <span data-ttu-id="da3fe-362">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="da3fe-362">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="da3fe-363">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-363">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-364">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-364">HoloLens</span></span>
* <span data-ttu-id="da3fe-365">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-365">IoT</span></span>

---
### <a name="disable-crash-dumps-for-a-sideloaded-app"></a><span data-ttu-id="da3fe-366">サイドローディングされたアプリのクラッシュ ダンプを無効にする</span><span class="sxs-lookup"><span data-stu-id="da3fe-366">Disable crash dumps for a sideloaded app</span></span>

**<span data-ttu-id="da3fe-367">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-367">Request</span></span>**

<span data-ttu-id="da3fe-368">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-368">You can disable crash dumps for a sideloaded app by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-369">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-369">Method</span></span>      | <span data-ttu-id="da3fe-370">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-370">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-371">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-371">DELETE</span></span> | <span data-ttu-id="da3fe-372">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="da3fe-372">/api/debug/dump/usermode/crashcontrol</span></span>

<br />
**<span data-ttu-id="da3fe-373">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-373">URI parameters</span></span>**

<span data-ttu-id="da3fe-374">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-374">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-375">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-375">URI parameter</span></span> | <span data-ttu-id="da3fe-376">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-376">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-377">packageFullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-377">packageFullname</span></span>   | <span data-ttu-id="da3fe-378">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-378">(**required**) The full name of the package for the sideloaded app.</span></span>
<br />
**<span data-ttu-id="da3fe-379">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-379">Request headers</span></span>**

- <span data-ttu-id="da3fe-380">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-380">None</span></span>

**<span data-ttu-id="da3fe-381">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-381">Request body</span></span>**

- <span data-ttu-id="da3fe-382">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-382">None</span></span>

**<span data-ttu-id="da3fe-383">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-383">Response</span></span>**

**<span data-ttu-id="da3fe-384">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-384">Status code</span></span>**

<span data-ttu-id="da3fe-385">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-385">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-386">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-386">HTTP status code</span></span>      | <span data-ttu-id="da3fe-387">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-387">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-388">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-388">200</span></span> | <span data-ttu-id="da3fe-389">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-389">OK</span></span>
<span data-ttu-id="da3fe-390">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-390">4XX</span></span> | <span data-ttu-id="da3fe-391">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-391">Error codes</span></span>
<span data-ttu-id="da3fe-392">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-392">5XX</span></span> | <span data-ttu-id="da3fe-393">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-393">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-394">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-394">Available device families</span></span>**

* <span data-ttu-id="da3fe-395">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="da3fe-395">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="da3fe-396">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-396">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-397">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-397">HoloLens</span></span>
* <span data-ttu-id="da3fe-398">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-398">IoT</span></span>

---
### <a name="download-the-crash-dump-for-a-sideloaded-app"></a><span data-ttu-id="da3fe-399">サイドローディングされたアプリのクラッシュ ダンプをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="da3fe-399">Download the crash dump for a sideloaded app</span></span>

**<span data-ttu-id="da3fe-400">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-400">Request</span></span>**

<span data-ttu-id="da3fe-401">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-401">You can download a sideloaded app's crash dump by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-402">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-402">Method</span></span>      | <span data-ttu-id="da3fe-403">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-403">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-404">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-404">GET</span></span> | <span data-ttu-id="da3fe-405">/api/debug/dump/usermode/crashdump</span><span class="sxs-lookup"><span data-stu-id="da3fe-405">/api/debug/dump/usermode/crashdump</span></span>
<br />

**<span data-ttu-id="da3fe-406">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-406">URI parameters</span></span>**

<span data-ttu-id="da3fe-407">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-407">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-408">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-408">URI parameter</span></span> | <span data-ttu-id="da3fe-409">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-409">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-410">packageFullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-410">packageFullname</span></span>   | <span data-ttu-id="da3fe-411">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-411">(**required**) The full name of the package for the sideloaded app.</span></span>
<span data-ttu-id="da3fe-412">fileName</span><span class="sxs-lookup"><span data-stu-id="da3fe-412">fileName</span></span>   | <span data-ttu-id="da3fe-413">(**必須**) ダウンロードするダンプ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-413">(**required**) The name of the dump file that you want to download.</span></span>
<br />
**<span data-ttu-id="da3fe-414">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-414">Request headers</span></span>**

- <span data-ttu-id="da3fe-415">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-415">None</span></span>

**<span data-ttu-id="da3fe-416">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-416">Request body</span></span>**

- <span data-ttu-id="da3fe-417">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-417">None</span></span>

**<span data-ttu-id="da3fe-418">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-418">Response</span></span>**

<span data-ttu-id="da3fe-419">応答には、ダンプ ファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-419">The response includes a dump file.</span></span> <span data-ttu-id="da3fe-420">WinDbg または Visual Studio を使用して、ダンプ ファイルを検証できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-420">You can use WinDbg or Visual Studio to examine the dump file.</span></span>

**<span data-ttu-id="da3fe-421">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-421">Status code</span></span>**

<span data-ttu-id="da3fe-422">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-422">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-423">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-423">HTTP status code</span></span>      | <span data-ttu-id="da3fe-424">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-424">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-425">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-425">200</span></span> | <span data-ttu-id="da3fe-426">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-426">OK</span></span>
<span data-ttu-id="da3fe-427">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-427">4XX</span></span> | <span data-ttu-id="da3fe-428">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-428">Error codes</span></span>
<span data-ttu-id="da3fe-429">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-429">5XX</span></span> | <span data-ttu-id="da3fe-430">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-430">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-431">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-431">Available device families</span></span>**

* <span data-ttu-id="da3fe-432">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="da3fe-432">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="da3fe-433">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-433">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-434">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-434">HoloLens</span></span>
* <span data-ttu-id="da3fe-435">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-435">IoT</span></span>

---
### <a name="enable-crash-dumps-for-a-sideloaded-app"></a><span data-ttu-id="da3fe-436">サイドローディングされたアプリのクラッシュ ダンプを有効にする</span><span class="sxs-lookup"><span data-stu-id="da3fe-436">Enable crash dumps for a sideloaded app</span></span>

**<span data-ttu-id="da3fe-437">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-437">Request</span></span>**

<span data-ttu-id="da3fe-438">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-438">You can enable crash dumps for a sideloaded app by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-439">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-439">Method</span></span>      | <span data-ttu-id="da3fe-440">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-440">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-441">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-441">POST</span></span> | <span data-ttu-id="da3fe-442">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="da3fe-442">/api/debug/dump/usermode/crashcontrol</span></span>
<br />

**<span data-ttu-id="da3fe-443">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-443">URI parameters</span></span>**

<span data-ttu-id="da3fe-444">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-444">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-445">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-445">URI parameter</span></span> | <span data-ttu-id="da3fe-446">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-446">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-447">packageFullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-447">packageFullname</span></span>   | <span data-ttu-id="da3fe-448">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-448">(**required**) The full name of the package for the sideloaded app.</span></span>
<br />
**<span data-ttu-id="da3fe-449">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-449">Request headers</span></span>**

- <span data-ttu-id="da3fe-450">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-450">None</span></span>

**<span data-ttu-id="da3fe-451">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-451">Request body</span></span>**

- <span data-ttu-id="da3fe-452">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-452">None</span></span>

**<span data-ttu-id="da3fe-453">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-453">Response</span></span>**

**<span data-ttu-id="da3fe-454">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-454">Status code</span></span>**

<span data-ttu-id="da3fe-455">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-455">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-456">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-456">HTTP status code</span></span>      | <span data-ttu-id="da3fe-457">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-457">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-458">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-458">200</span></span> | <span data-ttu-id="da3fe-459">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-459">OK</span></span>
<br />
**<span data-ttu-id="da3fe-460">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-460">Available device families</span></span>**

* <span data-ttu-id="da3fe-461">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="da3fe-461">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="da3fe-462">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-462">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-463">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-463">HoloLens</span></span>
* <span data-ttu-id="da3fe-464">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-464">IoT</span></span>

---
### <a name="get-the-list-of-bugcheck-files"></a><span data-ttu-id="da3fe-465">バグチェック ファイルの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-465">Get the list of bugcheck files</span></span>

**<span data-ttu-id="da3fe-466">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-466">Request</span></span>**

<span data-ttu-id="da3fe-467">次の要求形式を使用して、バグチェックのミニダンプ ファイルの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-467">You can get the list of bugcheck minidump files by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-468">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-468">Method</span></span>      | <span data-ttu-id="da3fe-469">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-469">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-470">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-470">GET</span></span> | <span data-ttu-id="da3fe-471">/api/debug/dump/kernel/dumplist</span><span class="sxs-lookup"><span data-stu-id="da3fe-471">/api/debug/dump/kernel/dumplist</span></span>
<br />

**<span data-ttu-id="da3fe-472">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-472">URI parameters</span></span>**

- <span data-ttu-id="da3fe-473">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-473">None</span></span>

**<span data-ttu-id="da3fe-474">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-474">Request headers</span></span>**

- <span data-ttu-id="da3fe-475">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-475">None</span></span>

**<span data-ttu-id="da3fe-476">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-476">Request body</span></span>**

- <span data-ttu-id="da3fe-477">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-477">None</span></span>

**<span data-ttu-id="da3fe-478">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-478">Response</span></span>**

<span data-ttu-id="da3fe-479">応答には、ダンプ ファイル名とこれらのファイルのサイズの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-479">The response includes a list of dump file names and the sizes of these files.</span></span> <span data-ttu-id="da3fe-480">一覧は、次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-480">This list will be in the following format.</span></span> 
```
{"DumpFiles": [
    {
        "FileName": string,
        "FileSize": int
    },...
]}
```

**<span data-ttu-id="da3fe-481">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-481">Status code</span></span>**

<span data-ttu-id="da3fe-482">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-482">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-483">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-483">HTTP status code</span></span>      | <span data-ttu-id="da3fe-484">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-484">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-485">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-485">200</span></span> | <span data-ttu-id="da3fe-486">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-486">OK</span></span>
<br />
**<span data-ttu-id="da3fe-487">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-487">Available device families</span></span>**

* <span data-ttu-id="da3fe-488">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-488">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-489">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-489">IoT</span></span>

---
### <a name="download-a-bugcheck-dump-file"></a><span data-ttu-id="da3fe-490">バグチェックのダンプ ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="da3fe-490">Download a bugcheck dump file</span></span>

**<span data-ttu-id="da3fe-491">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-491">Request</span></span>**

<span data-ttu-id="da3fe-492">次の要求形式を使用して、バグチェックのダンプ ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-492">You can download a bugcheck dump file by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-493">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-493">Method</span></span>      | <span data-ttu-id="da3fe-494">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-494">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-495">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-495">GET</span></span> | <span data-ttu-id="da3fe-496">/api/debug/dump/kernel/dump</span><span class="sxs-lookup"><span data-stu-id="da3fe-496">/api/debug/dump/kernel/dump</span></span>
<br />

**<span data-ttu-id="da3fe-497">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-497">URI parameters</span></span>**

<span data-ttu-id="da3fe-498">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-498">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-499">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-499">URI parameter</span></span> | <span data-ttu-id="da3fe-500">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-500">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-501">filename</span><span class="sxs-lookup"><span data-stu-id="da3fe-501">filename</span></span>   | <span data-ttu-id="da3fe-502">(**必須**) ダンプ ファイルのファイル名。</span><span class="sxs-lookup"><span data-stu-id="da3fe-502">(**required**) The file name of the dump file.</span></span> <span data-ttu-id="da3fe-503">API を使ってダンプの一覧を取得することによって確認できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-503">You can find this by using the API to get the dump list.</span></span>
<br />
**<span data-ttu-id="da3fe-504">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-504">Request headers</span></span>**

- <span data-ttu-id="da3fe-505">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-505">None</span></span>

**<span data-ttu-id="da3fe-506">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-506">Request body</span></span>**

- <span data-ttu-id="da3fe-507">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-507">None</span></span>

**<span data-ttu-id="da3fe-508">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-508">Response</span></span>**

<span data-ttu-id="da3fe-509">応答には、ダンプ ファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-509">The response includes the dump file.</span></span> <span data-ttu-id="da3fe-510">WinDbg を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-510">You can inspect this file using WinDbg.</span></span>

**<span data-ttu-id="da3fe-511">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-511">Status code</span></span>**

<span data-ttu-id="da3fe-512">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-512">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-513">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-513">HTTP status code</span></span>      | <span data-ttu-id="da3fe-514">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-514">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-515">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-515">200</span></span> | <span data-ttu-id="da3fe-516">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-516">OK</span></span>
<span data-ttu-id="da3fe-517">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-517">4XX</span></span> | <span data-ttu-id="da3fe-518">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-518">Error codes</span></span>
<span data-ttu-id="da3fe-519">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-519">5XX</span></span> | <span data-ttu-id="da3fe-520">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-520">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-521">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-521">Available device families</span></span>**

* <span data-ttu-id="da3fe-522">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-522">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-523">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-523">IoT</span></span>

---
### <a name="get-the-bugcheck-crash-control-settings"></a><span data-ttu-id="da3fe-524">バグチェックのクラッシュ制御の設定を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-524">Get the bugcheck crash control settings</span></span>

**<span data-ttu-id="da3fe-525">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-525">Request</span></span>**

<span data-ttu-id="da3fe-526">次の要求形式を使用して、バグチェックのクラッシュ制御の設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-526">You can get the bugcheck crash control settings by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-527">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-527">Method</span></span>      | <span data-ttu-id="da3fe-528">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-528">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-529">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-529">GET</span></span> | <span data-ttu-id="da3fe-530">/api/debug/dump/kernel/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="da3fe-530">/api/debug/dump/kernel/crashcontrol</span></span>

<br />
**<span data-ttu-id="da3fe-531">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-531">URI parameters</span></span>**

- <span data-ttu-id="da3fe-532">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-532">None</span></span>

**<span data-ttu-id="da3fe-533">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-533">Request headers</span></span>**

- <span data-ttu-id="da3fe-534">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-534">None</span></span>

**<span data-ttu-id="da3fe-535">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-535">Request body</span></span>**

- <span data-ttu-id="da3fe-536">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-536">None</span></span>

**<span data-ttu-id="da3fe-537">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-537">Response</span></span>**

<span data-ttu-id="da3fe-538">応答には、クラッシュの制御の設定が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-538">The response includes the crash control settings.</span></span> <span data-ttu-id="da3fe-539">CrashControl について詳しくは、「[CrashControl](https://technet.microsoft.com/library/cc951703.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da3fe-539">For more information about CrashControl, see the [CrashControl](https://technet.microsoft.com/library/cc951703.aspx) article.</span></span> <span data-ttu-id="da3fe-540">応答のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-540">The template for the response is as follows.</span></span>
```
{
    "autoreboot": bool (0 or 1),
    "dumptype": int (0 to 4),
    "maxdumpcount": int,
    "overwrite": bool (0 or 1)
}
```

**<span data-ttu-id="da3fe-541">ダンプの種類</span><span class="sxs-lookup"><span data-stu-id="da3fe-541">Dump types</span></span>**

<span data-ttu-id="da3fe-542">0: 無効</span><span class="sxs-lookup"><span data-stu-id="da3fe-542">0: Disabled</span></span>

<span data-ttu-id="da3fe-543">1: 完全メモリ ダンプ (使用中のすべてのメモリを収集)</span><span class="sxs-lookup"><span data-stu-id="da3fe-543">1: Complete memory dump (collects all in-use memory)</span></span>

<span data-ttu-id="da3fe-544">2: カーネル メモリ ダンプ (ユーザー モード メモリを無視)</span><span class="sxs-lookup"><span data-stu-id="da3fe-544">2: Kernel memory dump (ignores user mode memory)</span></span>

<span data-ttu-id="da3fe-545">3: 限られたカーネル ミニダンプ</span><span class="sxs-lookup"><span data-stu-id="da3fe-545">3: Limited kernel minidump</span></span>

**<span data-ttu-id="da3fe-546">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-546">Status code</span></span>**

<span data-ttu-id="da3fe-547">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-547">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-548">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-548">HTTP status code</span></span>      | <span data-ttu-id="da3fe-549">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-549">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-550">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-550">200</span></span> | <span data-ttu-id="da3fe-551">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-551">OK</span></span>
<span data-ttu-id="da3fe-552">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-552">4XX</span></span> | <span data-ttu-id="da3fe-553">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-553">Error codes</span></span>
<span data-ttu-id="da3fe-554">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-554">5XX</span></span> | <span data-ttu-id="da3fe-555">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-555">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-556">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-556">Available device families</span></span>**

* <span data-ttu-id="da3fe-557">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-557">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-558">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-558">IoT</span></span>

---
### <a name="get-a-live-kernel-dump"></a><span data-ttu-id="da3fe-559">ライブ カーネル ダンプを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-559">Get a live kernel dump</span></span>

**<span data-ttu-id="da3fe-560">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-560">Request</span></span>**

<span data-ttu-id="da3fe-561">次の要求形式を使用して、ライブ カーネル ダンプを取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-561">You can get a live kernel dump by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-562">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-562">Method</span></span>      | <span data-ttu-id="da3fe-563">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-563">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-564">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-564">GET</span></span> | <span data-ttu-id="da3fe-565">/api/debug/dump/livekernel</span><span class="sxs-lookup"><span data-stu-id="da3fe-565">/api/debug/dump/livekernel</span></span>
<br />

**<span data-ttu-id="da3fe-566">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-566">URI parameters</span></span>**

- <span data-ttu-id="da3fe-567">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-567">None</span></span>

**<span data-ttu-id="da3fe-568">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-568">Request headers</span></span>**

- <span data-ttu-id="da3fe-569">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-569">None</span></span>

**<span data-ttu-id="da3fe-570">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-570">Request body</span></span>**

- <span data-ttu-id="da3fe-571">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-571">None</span></span>

**<span data-ttu-id="da3fe-572">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-572">Response</span></span>**

<span data-ttu-id="da3fe-573">応答には、カーネル モードの完全なダンプが含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-573">The response includes the full kernel mode dump.</span></span> <span data-ttu-id="da3fe-574">WinDbg を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-574">You can inspect this file using WinDbg.</span></span>

**<span data-ttu-id="da3fe-575">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-575">Status code</span></span>**

<span data-ttu-id="da3fe-576">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-576">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-577">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-577">HTTP status code</span></span>      | <span data-ttu-id="da3fe-578">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-578">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-579">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-579">200</span></span> | <span data-ttu-id="da3fe-580">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-580">OK</span></span>
<span data-ttu-id="da3fe-581">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-581">4XX</span></span> | <span data-ttu-id="da3fe-582">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-582">Error codes</span></span>
<span data-ttu-id="da3fe-583">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-583">5XX</span></span> | <span data-ttu-id="da3fe-584">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-584">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-585">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-585">Available device families</span></span>**

* <span data-ttu-id="da3fe-586">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-586">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-587">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-587">IoT</span></span>

---
### <a name="get-a-dump-from-a-live-user-process"></a><span data-ttu-id="da3fe-588">ライブ ユーザー プロセスからダンプを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-588">Get a dump from a live user process</span></span>

**<span data-ttu-id="da3fe-589">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-589">Request</span></span>**

<span data-ttu-id="da3fe-590">次の要求形式を使用して、ライブ ユーザー プロセスのダンプを取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-590">You can get the dump for live user process by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-591">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-591">Method</span></span>      | <span data-ttu-id="da3fe-592">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-592">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-593">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-593">GET</span></span> | <span data-ttu-id="da3fe-594">/api/debug/dump/usermode/live</span><span class="sxs-lookup"><span data-stu-id="da3fe-594">/api/debug/dump/usermode/live</span></span>
<br />

**<span data-ttu-id="da3fe-595">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-595">URI parameters</span></span>**

<span data-ttu-id="da3fe-596">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-596">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-597">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-597">URI parameter</span></span> | <span data-ttu-id="da3fe-598">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-598">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-599">pid</span><span class="sxs-lookup"><span data-stu-id="da3fe-599">pid</span></span>   | <span data-ttu-id="da3fe-600">(**必須**) 目的のプロセスの一意のプロセス ID。</span><span class="sxs-lookup"><span data-stu-id="da3fe-600">(**required**) The unique process id for the process you are interested in.</span></span>
<br />
**<span data-ttu-id="da3fe-601">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-601">Request headers</span></span>**

- <span data-ttu-id="da3fe-602">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-602">None</span></span>

**<span data-ttu-id="da3fe-603">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-603">Request body</span></span>**

- <span data-ttu-id="da3fe-604">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-604">None</span></span>

**<span data-ttu-id="da3fe-605">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-605">Response</span></span>**

<span data-ttu-id="da3fe-606">応答には、プロセス ダンプが含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-606">The response includes the process dump.</span></span> <span data-ttu-id="da3fe-607">WinDbg または Visual Studio を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-607">You can inspect this file using WinDbg or Visual Studio.</span></span>

**<span data-ttu-id="da3fe-608">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-608">Status code</span></span>**

<span data-ttu-id="da3fe-609">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-609">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-610">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-610">HTTP status code</span></span>      | <span data-ttu-id="da3fe-611">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-611">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-612">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-612">200</span></span> | <span data-ttu-id="da3fe-613">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-613">OK</span></span>
<span data-ttu-id="da3fe-614">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-614">4XX</span></span> | <span data-ttu-id="da3fe-615">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-615">Error codes</span></span>
<span data-ttu-id="da3fe-616">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-616">5XX</span></span> | <span data-ttu-id="da3fe-617">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-617">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-618">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-618">Available device families</span></span>**

* <span data-ttu-id="da3fe-619">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-619">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-620">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-620">IoT</span></span>

---
### <a name="set-the-bugcheck-crash-control-settings"></a><span data-ttu-id="da3fe-621">バグチェックのクラッシュ制御の設定を行う</span><span class="sxs-lookup"><span data-stu-id="da3fe-621">Set the bugcheck crash control settings</span></span>

**<span data-ttu-id="da3fe-622">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-622">Request</span></span>**

<span data-ttu-id="da3fe-623">次の要求形式を使用して、バグチェック データの収集に関する設定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-623">You can set the settings for collecting bugcheck data by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-624">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-624">Method</span></span>      | <span data-ttu-id="da3fe-625">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-625">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-626">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-626">POST</span></span> | <span data-ttu-id="da3fe-627">/api/debug/dump/kernel/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="da3fe-627">/api/debug/dump/kernel/crashcontrol</span></span>
<br />

**<span data-ttu-id="da3fe-628">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-628">URI parameters</span></span>**

<span data-ttu-id="da3fe-629">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-629">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-630">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-630">URI parameter</span></span> | <span data-ttu-id="da3fe-631">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-631">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-632">autoreboot</span><span class="sxs-lookup"><span data-stu-id="da3fe-632">autoreboot</span></span>   | <span data-ttu-id="da3fe-633">(**オプション**) true または false。</span><span class="sxs-lookup"><span data-stu-id="da3fe-633">(**optional**) True or false.</span></span> <span data-ttu-id="da3fe-634">これは、エラーやロックの発生後に、システムが自動的に再起動するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-634">This indicates whether the system restarts automatically after it fails or locks.</span></span>
<span data-ttu-id="da3fe-635">dumptype</span><span class="sxs-lookup"><span data-stu-id="da3fe-635">dumptype</span></span>   | <span data-ttu-id="da3fe-636">(**オプション**) dump タイプ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-636">(**optional**) The dump type.</span></span> <span data-ttu-id="da3fe-637">サポートされる値については、「[CrashDumpType 列挙体](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da3fe-637">For the supported values, see the [CrashDumpType Enumeration](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx).</span></span>
<span data-ttu-id="da3fe-638">maxdumpcount</span><span class="sxs-lookup"><span data-stu-id="da3fe-638">maxdumpcount</span></span>   | <span data-ttu-id="da3fe-639">(**オプション**) 保存するダンプの最大数。</span><span class="sxs-lookup"><span data-stu-id="da3fe-639">(**optional**) The maximum number of dumps to save.</span></span>
<span data-ttu-id="da3fe-640">overwrite</span><span class="sxs-lookup"><span data-stu-id="da3fe-640">overwrite</span></span>   | <span data-ttu-id="da3fe-641">(**オプション**) true または false。</span><span class="sxs-lookup"><span data-stu-id="da3fe-641">(**optional**) True of false.</span></span> <span data-ttu-id="da3fe-642">これは、*maxdumpcount* で指定されているダンプ カウンターの制限に達した場合に古いダンプを上書きするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-642">This indicates whether or not to overwrite old dumps when the dump counter limit specified by *maxdumpcount* has been reached.</span></span>
<br />
**<span data-ttu-id="da3fe-643">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-643">Request headers</span></span>**

- <span data-ttu-id="da3fe-644">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-644">None</span></span>

**<span data-ttu-id="da3fe-645">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-645">Request body</span></span>**

- <span data-ttu-id="da3fe-646">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-646">None</span></span>

**<span data-ttu-id="da3fe-647">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-647">Response</span></span>**

**<span data-ttu-id="da3fe-648">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-648">Status code</span></span>**

<span data-ttu-id="da3fe-649">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-649">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-650">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-650">HTTP status code</span></span>      | <span data-ttu-id="da3fe-651">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-651">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-652">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-652">200</span></span> | <span data-ttu-id="da3fe-653">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-653">OK</span></span>
<span data-ttu-id="da3fe-654">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-654">4XX</span></span> | <span data-ttu-id="da3fe-655">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-655">Error codes</span></span>
<span data-ttu-id="da3fe-656">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-656">5XX</span></span> | <span data-ttu-id="da3fe-657">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-657">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-658">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-658">Available device families</span></span>**

* <span data-ttu-id="da3fe-659">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-659">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-660">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-660">IoT</span></span>

---
## ETW
---
### <a name="create-a-realtime-etw-session-over-a-websocket"></a><span data-ttu-id="da3fe-661">websocket 経由でリアルタイムの ETW セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="da3fe-661">Create a realtime ETW session over a websocket</span></span>

**<span data-ttu-id="da3fe-662">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-662">Request</span></span>**

<span data-ttu-id="da3fe-663">次の要求形式を使用して、リアルタイムの ETW セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-663">You can create a realtime ETW session by using the following request format.</span></span> <span data-ttu-id="da3fe-664">これは、websocket 経由で管理されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-664">This will be managed over a websocket.</span></span>  <span data-ttu-id="da3fe-665">ETW イベントは、サーバーで一括処理され、1 秒に 1 回クライアントに送信されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-665">ETW events are batched on the server and sent to the client once per second.</span></span> 
 
<span data-ttu-id="da3fe-666">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-666">Method</span></span>      | <span data-ttu-id="da3fe-667">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-667">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-668">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="da3fe-668">GET/WebSocket</span></span> | <span data-ttu-id="da3fe-669">/api/etw/session/realtime</span><span class="sxs-lookup"><span data-stu-id="da3fe-669">/api/etw/session/realtime</span></span>
<br />

**<span data-ttu-id="da3fe-670">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-670">URI parameters</span></span>**

- <span data-ttu-id="da3fe-671">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-671">None</span></span>

**<span data-ttu-id="da3fe-672">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-672">Request headers</span></span>**

- <span data-ttu-id="da3fe-673">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-673">None</span></span>

**<span data-ttu-id="da3fe-674">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-674">Request body</span></span>**

- <span data-ttu-id="da3fe-675">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-675">None</span></span>

**<span data-ttu-id="da3fe-676">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-676">Response</span></span>**

<span data-ttu-id="da3fe-677">応答には、有効なプロバイダーの ETW イベントが含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-677">The response includes the ETW events from the enabled providers.</span></span>  <span data-ttu-id="da3fe-678">以下の「ETW WebSocket コマンド」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="da3fe-678">See ETW WebSocket commands below.</span></span> 

**<span data-ttu-id="da3fe-679">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-679">Status code</span></span>**

<span data-ttu-id="da3fe-680">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-680">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-681">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-681">HTTP status code</span></span>      | <span data-ttu-id="da3fe-682">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-682">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-683">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-683">200</span></span> | <span data-ttu-id="da3fe-684">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-684">OK</span></span>
<span data-ttu-id="da3fe-685">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-685">4XX</span></span> | <span data-ttu-id="da3fe-686">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-686">Error codes</span></span>
<span data-ttu-id="da3fe-687">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-687">5XX</span></span> | <span data-ttu-id="da3fe-688">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-688">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-689">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-689">Available device families</span></span>**

* <span data-ttu-id="da3fe-690">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-690">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-691">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-691">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-692">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-692">HoloLens</span></span>
* <span data-ttu-id="da3fe-693">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-693">IoT</span></span>

### <a name="etw-websocket-commands"></a><span data-ttu-id="da3fe-694">ETW WebSocket コマンド</span><span class="sxs-lookup"><span data-stu-id="da3fe-694">ETW WebSocket commands</span></span>
<span data-ttu-id="da3fe-695">次のコマンドは、クライアントからサーバーに送信されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-695">These commands are sent from the client to the server.</span></span>

<span data-ttu-id="da3fe-696">コマンド</span><span class="sxs-lookup"><span data-stu-id="da3fe-696">Command</span></span> | <span data-ttu-id="da3fe-697">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-697">Description</span></span>
:----- | :-----
<span data-ttu-id="da3fe-698">provider *{guid}* enable *{level}*</span><span class="sxs-lookup"><span data-stu-id="da3fe-698">provider *{guid}* enable *{level}*</span></span> | <span data-ttu-id="da3fe-699">*{guid}* で指定されたプロバイダー (括弧は不要) を指定されたレベルで有効にします。</span><span class="sxs-lookup"><span data-stu-id="da3fe-699">Enable the provider marked by *{guid}* (without brackets) at the specified level.</span></span> <span data-ttu-id="da3fe-700">*{level}* は、1 (最小限の詳細) ～ 5 (詳細) の **int** です。</span><span class="sxs-lookup"><span data-stu-id="da3fe-700">*{level}* is an **int** from 1 (least detail) to 5 (verbose).</span></span>
<span data-ttu-id="da3fe-701">provider *{guid}* disable</span><span class="sxs-lookup"><span data-stu-id="da3fe-701">provider *{guid}* disable</span></span> | <span data-ttu-id="da3fe-702">*{guid}* で指定されたプロバイダー (括弧は不要) を無効にします。</span><span class="sxs-lookup"><span data-stu-id="da3fe-702">Disable the provider marked by *{guid}* (without brackets).</span></span>

<span data-ttu-id="da3fe-703">この応答は、サーバーからクライアントに送信されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-703">This responses is sent from the server to the client.</span></span> <span data-ttu-id="da3fe-704">これは、テキストとして送信され、JSON で解析すると次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-704">This is sent as text and you get the following format by parsing the JSON.</span></span>
```
{
    "Events":[
        {
            "Timestamp": int,
            "ProviderName": string,
            "ID": int, 
            "TaskName": string,
            "Keyword": int,
            "Level": int,
            payload objects...
        },...
    ],
    "Frequency": int
}
```

<span data-ttu-id="da3fe-705">payload objects は、追加のキーと値のペア (文字列: 文字列) で、元の ETW イベントから提供されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-705">Payload objects are extra key-value pairs (string:string) that are provided in the original ETW event.</span></span>

<span data-ttu-id="da3fe-706">例:</span><span class="sxs-lookup"><span data-stu-id="da3fe-706">Example:</span></span>
```
{
    "ID" : 42, 
    "Keyword" : 9223372036854775824, 
    "Level" : 4, 
    "Message" : "UDPv4: 412 bytes transmitted from 10.81.128.148:510 to 132.215.243.34:510. ",
    "PID" : "1218", 
    "ProviderName" : "Microsoft-Windows-Kernel-Network", 
    "TaskName" : "KERNEL_NETWORK_TASK_UDPIP", 
    "Timestamp" : 131039401761757686, 
    "connid" : "0", 
    "daddr" : "132.245.243.34", 
    "dport" : "500", 
    "saddr" : "10.82.128.118", 
    "seqnum" : "0", 
    "size" : "412", 
    "sport" : "500"
}
```

---
### <a name="enumerate-the-registered-etw-providers"></a><span data-ttu-id="da3fe-707">登録済みの ETW プロバイダーを列挙する</span><span class="sxs-lookup"><span data-stu-id="da3fe-707">Enumerate the registered ETW providers</span></span>

**<span data-ttu-id="da3fe-708">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-708">Request</span></span>**

<span data-ttu-id="da3fe-709">次の要求形式を使用して、登録済みプロバイダーを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-709">You can enumerate through the registered providers by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-710">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-710">Method</span></span>      | <span data-ttu-id="da3fe-711">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-711">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-712">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-712">GET</span></span> | <span data-ttu-id="da3fe-713">/api/etw/providers</span><span class="sxs-lookup"><span data-stu-id="da3fe-713">/api/etw/providers</span></span>
<br />

**<span data-ttu-id="da3fe-714">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-714">URI parameters</span></span>**

- <span data-ttu-id="da3fe-715">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-715">None</span></span>

**<span data-ttu-id="da3fe-716">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-716">Request headers</span></span>**

- <span data-ttu-id="da3fe-717">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-717">None</span></span>

**<span data-ttu-id="da3fe-718">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-718">Request body</span></span>**

- <span data-ttu-id="da3fe-719">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-719">None</span></span>

**<span data-ttu-id="da3fe-720">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-720">Response</span></span>**

<span data-ttu-id="da3fe-721">応答には、ETW プロバイダーの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-721">The response includes the list of ETW providers.</span></span> <span data-ttu-id="da3fe-722">一覧には、各プロバイダーのフレンドリ名と GUID が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-722">The list will include the friendly name and GUID for each provider in the following format.</span></span>
```
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

**<span data-ttu-id="da3fe-723">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-723">Status code</span></span>**

<span data-ttu-id="da3fe-724">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-724">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-725">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-725">HTTP status code</span></span>      | <span data-ttu-id="da3fe-726">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-726">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-727">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-727">200</span></span> | <span data-ttu-id="da3fe-728">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-728">OK</span></span>
<br />
**<span data-ttu-id="da3fe-729">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-729">Available device families</span></span>**

* <span data-ttu-id="da3fe-730">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-730">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-731">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-731">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-732">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-732">HoloLens</span></span>
* <span data-ttu-id="da3fe-733">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-733">IoT</span></span>

---
### <a name="enumerate-the-custom-etw-providers-exposed-by-the-platform"></a><span data-ttu-id="da3fe-734">プラットフォームによって公開されているカスタム ETW プロバイダーを列挙します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-734">Enumerate the custom ETW providers exposed by the platform.</span></span>

**<span data-ttu-id="da3fe-735">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-735">Request</span></span>**

<span data-ttu-id="da3fe-736">次の要求形式を使用して、登録済みプロバイダーを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-736">You can enumerate through the registered providers by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-737">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-737">Method</span></span>      | <span data-ttu-id="da3fe-738">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-738">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-739">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-739">GET</span></span> | <span data-ttu-id="da3fe-740">/api/etw/customproviders</span><span class="sxs-lookup"><span data-stu-id="da3fe-740">/api/etw/customproviders</span></span>
<br />

**<span data-ttu-id="da3fe-741">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-741">URI parameters</span></span>**

- <span data-ttu-id="da3fe-742">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-742">None</span></span>

**<span data-ttu-id="da3fe-743">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-743">Request headers</span></span>**

- <span data-ttu-id="da3fe-744">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-744">None</span></span>

**<span data-ttu-id="da3fe-745">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-745">Request body</span></span>**

- <span data-ttu-id="da3fe-746">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-746">None</span></span>

**<span data-ttu-id="da3fe-747">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-747">Response</span></span>**

<span data-ttu-id="da3fe-748">200 OK。</span><span class="sxs-lookup"><span data-stu-id="da3fe-748">200 OK.</span></span> <span data-ttu-id="da3fe-749">応答には、ETW プロバイダーの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-749">The response includes the list of ETW providers.</span></span> <span data-ttu-id="da3fe-750">一覧には、各プロバイダーのフレンドリ名と GUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-750">The list will include the friendly name and GUID for each provider.</span></span>

```
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

**<span data-ttu-id="da3fe-751">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-751">Status code</span></span>**

- <span data-ttu-id="da3fe-752">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="da3fe-752">Standard status codes.</span></span>
<br />
**<span data-ttu-id="da3fe-753">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-753">Available device families</span></span>**

* <span data-ttu-id="da3fe-754">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-754">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-755">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-755">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-756">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-756">HoloLens</span></span>
* <span data-ttu-id="da3fe-757">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-757">IoT</span></span>

---
## OS information
---
### <a name="get-the-machine-name"></a><span data-ttu-id="da3fe-758">コンピューター名を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-758">Get the machine name</span></span>

**<span data-ttu-id="da3fe-759">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-759">Request</span></span>**

<span data-ttu-id="da3fe-760">次の要求形式を使用して、コンピューターの名前を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-760">You can get the name of a machine by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-761">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-761">Method</span></span>      | <span data-ttu-id="da3fe-762">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-762">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-763">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-763">GET</span></span> | <span data-ttu-id="da3fe-764">/api/os/machinename</span><span class="sxs-lookup"><span data-stu-id="da3fe-764">/api/os/machinename</span></span>
<br />

**<span data-ttu-id="da3fe-765">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-765">URI parameters</span></span>**

- <span data-ttu-id="da3fe-766">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-766">None</span></span>

**<span data-ttu-id="da3fe-767">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-767">Request headers</span></span>**

- <span data-ttu-id="da3fe-768">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-768">None</span></span>

**<span data-ttu-id="da3fe-769">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-769">Request body</span></span>**

- <span data-ttu-id="da3fe-770">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-770">None</span></span>

**<span data-ttu-id="da3fe-771">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-771">Response</span></span>**

<span data-ttu-id="da3fe-772">応答には、コンピューター名が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-772">The response includes the computer name in the following format.</span></span> 

```
{"ComputerName": string}
```

**<span data-ttu-id="da3fe-773">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-773">Status code</span></span>**

<span data-ttu-id="da3fe-774">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-774">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-775">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-775">HTTP status code</span></span>      | <span data-ttu-id="da3fe-776">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-776">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-777">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-777">200</span></span> | <span data-ttu-id="da3fe-778">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-778">OK</span></span>
<span data-ttu-id="da3fe-779">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-779">4XX</span></span> | <span data-ttu-id="da3fe-780">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-780">Error codes</span></span>
<span data-ttu-id="da3fe-781">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-781">5XX</span></span> | <span data-ttu-id="da3fe-782">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-782">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-783">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-783">Available device families</span></span>**

* <span data-ttu-id="da3fe-784">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-784">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-785">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-785">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-786">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-786">Xbox</span></span>
* <span data-ttu-id="da3fe-787">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-787">HoloLens</span></span>
* <span data-ttu-id="da3fe-788">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-788">IoT</span></span>

---
### <a name="get-the-operating-system-information"></a><span data-ttu-id="da3fe-789">オペレーティング システムの情報を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-789">Get the operating system information</span></span>

**<span data-ttu-id="da3fe-790">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-790">Request</span></span>**

<span data-ttu-id="da3fe-791">次の要求形式を使用して、コンピューターの OS 情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-791">You can get the OS information for a machine by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-792">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-792">Method</span></span>      | <span data-ttu-id="da3fe-793">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-793">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-794">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-794">GET</span></span> | <span data-ttu-id="da3fe-795">/api/os/info</span><span class="sxs-lookup"><span data-stu-id="da3fe-795">/api/os/info</span></span>
<br />

**<span data-ttu-id="da3fe-796">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-796">URI parameters</span></span>**

- <span data-ttu-id="da3fe-797">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-797">None</span></span>

**<span data-ttu-id="da3fe-798">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-798">Request headers</span></span>**

- <span data-ttu-id="da3fe-799">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-799">None</span></span>

**<span data-ttu-id="da3fe-800">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-800">Request body</span></span>**

- <span data-ttu-id="da3fe-801">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-801">None</span></span>

**<span data-ttu-id="da3fe-802">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-802">Response</span></span>**

<span data-ttu-id="da3fe-803">応答には、OS 情報が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-803">The response includes the OS information in the following format.</span></span>

```
{
    "ComputerName": string,
    "OsEdition": string,
    "OsEditionId": int,
    "OsVersion": string,
    "Platform": string
}
```

**<span data-ttu-id="da3fe-804">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-804">Status code</span></span>**

<span data-ttu-id="da3fe-805">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-805">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-806">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-806">HTTP status code</span></span>      | <span data-ttu-id="da3fe-807">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-807">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-808">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-808">200</span></span> | <span data-ttu-id="da3fe-809">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-809">OK</span></span>
<span data-ttu-id="da3fe-810">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-810">4XX</span></span> | <span data-ttu-id="da3fe-811">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-811">Error codes</span></span>
<span data-ttu-id="da3fe-812">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-812">5XX</span></span> | <span data-ttu-id="da3fe-813">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-813">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-814">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-814">Available device families</span></span>**

* <span data-ttu-id="da3fe-815">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-815">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-816">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-816">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-817">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-817">Xbox</span></span>
* <span data-ttu-id="da3fe-818">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-818">HoloLens</span></span>
* <span data-ttu-id="da3fe-819">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-819">IoT</span></span>

---
### <a name="get-the-device-family"></a><span data-ttu-id="da3fe-820">デバイス ファミリを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-820">Get the device family</span></span> 

**<span data-ttu-id="da3fe-821">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-821">Request</span></span>**

<span data-ttu-id="da3fe-822">次の要求形式を使用して、デバイス ファミリ (Xbox、携帯電話、デスクトップなど) を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-822">You can get the device family (Xbox, phone, desktop, etc) using the following request format.</span></span>
 
<span data-ttu-id="da3fe-823">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-823">Method</span></span>      | <span data-ttu-id="da3fe-824">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-824">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-825">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-825">GET</span></span> | <span data-ttu-id="da3fe-826">/api/os/devicefamily</span><span class="sxs-lookup"><span data-stu-id="da3fe-826">/api/os/devicefamily</span></span>
<br />

**<span data-ttu-id="da3fe-827">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-827">URI parameters</span></span>**

- <span data-ttu-id="da3fe-828">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-828">None</span></span>

**<span data-ttu-id="da3fe-829">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-829">Request headers</span></span>**

- <span data-ttu-id="da3fe-830">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-830">None</span></span>

**<span data-ttu-id="da3fe-831">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-831">Request body</span></span>**

- <span data-ttu-id="da3fe-832">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-832">None</span></span>

**<span data-ttu-id="da3fe-833">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-833">Response</span></span>**

<span data-ttu-id="da3fe-834">応答には、デバイス ファミリ (SKU - デスクトップ、Xbox など) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-834">The response includes the device family (SKU - Desktop, Xbox, etc).</span></span>

```
{
   "DeviceType" : string
}
```

<span data-ttu-id="da3fe-835">DeviceType は、"Windows.Xbox"、"Windows.Desktop" などのようになります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-835">DeviceType will look like "Windows.Xbox", "Windows.Desktop", etc.</span></span> 

**<span data-ttu-id="da3fe-836">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-836">Status code</span></span>**

<span data-ttu-id="da3fe-837">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-837">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-838">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-838">HTTP status code</span></span>      | <span data-ttu-id="da3fe-839">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-839">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-840">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-840">200</span></span> | <span data-ttu-id="da3fe-841">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-841">OK</span></span>
<span data-ttu-id="da3fe-842">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-842">4XX</span></span> | <span data-ttu-id="da3fe-843">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-843">Error codes</span></span>
<span data-ttu-id="da3fe-844">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-844">5XX</span></span> | <span data-ttu-id="da3fe-845">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-845">Error codes</span></span>

**<span data-ttu-id="da3fe-846">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-846">Available device families</span></span>**

* <span data-ttu-id="da3fe-847">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-847">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-848">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-848">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-849">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-849">Xbox</span></span>
* <span data-ttu-id="da3fe-850">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-850">HoloLens</span></span>
* <span data-ttu-id="da3fe-851">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-851">IoT</span></span>

---
### <a name="set-the-machine-name"></a><span data-ttu-id="da3fe-852">コンピューター名を設定する</span><span class="sxs-lookup"><span data-stu-id="da3fe-852">Set the machine name</span></span>

**<span data-ttu-id="da3fe-853">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-853">Request</span></span>**

<span data-ttu-id="da3fe-854">次の要求形式を使用して、コンピューターの名前を設定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-854">You can set the name of a machine by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-855">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-855">Method</span></span>      | <span data-ttu-id="da3fe-856">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-856">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-857">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-857">POST</span></span> | <span data-ttu-id="da3fe-858">/api/os/machinename</span><span class="sxs-lookup"><span data-stu-id="da3fe-858">/api/os/machinename</span></span>
<br />

**<span data-ttu-id="da3fe-859">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-859">URI parameters</span></span>**

<span data-ttu-id="da3fe-860">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-860">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-861">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-861">URI parameter</span></span> | <span data-ttu-id="da3fe-862">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-862">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-863">name</span><span class="sxs-lookup"><span data-stu-id="da3fe-863">name</span></span> | <span data-ttu-id="da3fe-864">(**必須**) コンピューターの新しい名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-864">(**required**) The new name for the machine.</span></span>
<br />
**<span data-ttu-id="da3fe-865">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-865">Request headers</span></span>**

- <span data-ttu-id="da3fe-866">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-866">None</span></span>

**<span data-ttu-id="da3fe-867">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-867">Request body</span></span>**

- <span data-ttu-id="da3fe-868">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-868">None</span></span>

**<span data-ttu-id="da3fe-869">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-869">Response</span></span>**

**<span data-ttu-id="da3fe-870">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-870">Status code</span></span>**

<span data-ttu-id="da3fe-871">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-871">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-872">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-872">HTTP status code</span></span>      | <span data-ttu-id="da3fe-873">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-873">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-874">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-874">200</span></span> | <span data-ttu-id="da3fe-875">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-875">OK</span></span>
<br />
**<span data-ttu-id="da3fe-876">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-876">Available device families</span></span>**

* <span data-ttu-id="da3fe-877">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-877">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-878">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-878">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-879">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-879">Xbox</span></span>
* <span data-ttu-id="da3fe-880">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-880">HoloLens</span></span>
* <span data-ttu-id="da3fe-881">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-881">IoT</span></span>

---
## User information
---
### <a name="get-the-active-user"></a><span data-ttu-id="da3fe-882">アクティブ ユーザーを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-882">Get the active user</span></span>

**<span data-ttu-id="da3fe-883">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-883">Request</span></span>**

<span data-ttu-id="da3fe-884">次の要求形式を使用して、デバイスのアクティブ ユーザーの名前を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-884">You can get the name of the active user on the device by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-885">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-885">Method</span></span>      | <span data-ttu-id="da3fe-886">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-886">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-887">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-887">GET</span></span> | <span data-ttu-id="da3fe-888">/api/users/activeuser</span><span class="sxs-lookup"><span data-stu-id="da3fe-888">/api/users/activeuser</span></span>
<br />

**<span data-ttu-id="da3fe-889">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-889">URI parameters</span></span>**

- <span data-ttu-id="da3fe-890">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-890">None</span></span>

**<span data-ttu-id="da3fe-891">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-891">Request headers</span></span>**

- <span data-ttu-id="da3fe-892">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-892">None</span></span>

**<span data-ttu-id="da3fe-893">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-893">Request body</span></span>**

- <span data-ttu-id="da3fe-894">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-894">None</span></span>

**<span data-ttu-id="da3fe-895">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-895">Response</span></span>**

<span data-ttu-id="da3fe-896">応答には、ユーザー情報が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-896">The response includes user information in the following format.</span></span> 

<span data-ttu-id="da3fe-897">成功した場合:</span><span class="sxs-lookup"><span data-stu-id="da3fe-897">On success:</span></span> 
```
{
    "UserDisplayName" : string, 
    "UserSID" : string
}
```
<span data-ttu-id="da3fe-898">失敗した場合:</span><span class="sxs-lookup"><span data-stu-id="da3fe-898">On failure:</span></span>
```
{
    "Code" : int, 
    "CodeText" : string, 
    "Reason" : string, 
    "Success" : bool
}
```

**<span data-ttu-id="da3fe-899">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-899">Status code</span></span>**

<span data-ttu-id="da3fe-900">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-900">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-901">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-901">HTTP status code</span></span>      | <span data-ttu-id="da3fe-902">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-902">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-903">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-903">200</span></span> | <span data-ttu-id="da3fe-904">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-904">OK</span></span>
<span data-ttu-id="da3fe-905">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-905">4XX</span></span> | <span data-ttu-id="da3fe-906">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-906">Error codes</span></span>
<span data-ttu-id="da3fe-907">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-907">5XX</span></span> | <span data-ttu-id="da3fe-908">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-908">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-909">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-909">Available device families</span></span>**

* <span data-ttu-id="da3fe-910">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-910">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-911">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-911">HoloLens</span></span>
* <span data-ttu-id="da3fe-912">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-912">IoT</span></span>

---
## Performance data
---
### <a name="get-the-list-of-running-processes"></a><span data-ttu-id="da3fe-913">実行中のプロセスの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-913">Get the list of running processes</span></span>

**<span data-ttu-id="da3fe-914">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-914">Request</span></span>**

<span data-ttu-id="da3fe-915">次の要求形式を使用して、現在実行中のプロセスの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-915">You can get the list of currently running processes by using the following request format.</span></span>  <span data-ttu-id="da3fe-916">これは、WebSocket 接続にアップグレードすることもでき、1 秒に 1 度クライアントにプッシュされる同じ JSON データを取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-916">this can be upgraded to a WebSocket connection as well, with the same JSON data being pushed to the client once per second.</span></span> 
 
<span data-ttu-id="da3fe-917">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-917">Method</span></span>      | <span data-ttu-id="da3fe-918">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-918">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-919">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-919">GET</span></span> | <span data-ttu-id="da3fe-920">/api/resourcemanager/processes</span><span class="sxs-lookup"><span data-stu-id="da3fe-920">/api/resourcemanager/processes</span></span>
<span data-ttu-id="da3fe-921">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="da3fe-921">GET/WebSocket</span></span> | <span data-ttu-id="da3fe-922">/api/resourcemanager/processes</span><span class="sxs-lookup"><span data-stu-id="da3fe-922">/api/resourcemanager/processes</span></span>
<br />

**<span data-ttu-id="da3fe-923">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-923">URI parameters</span></span>**

- <span data-ttu-id="da3fe-924">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-924">None</span></span>

**<span data-ttu-id="da3fe-925">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-925">Request headers</span></span>**

- <span data-ttu-id="da3fe-926">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-926">None</span></span>

**<span data-ttu-id="da3fe-927">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-927">Request body</span></span>**

- <span data-ttu-id="da3fe-928">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-928">None</span></span>

**<span data-ttu-id="da3fe-929">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-929">Response</span></span>**

<span data-ttu-id="da3fe-930">応答には、プロセスの一覧と各プロセスの詳細情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-930">The response includes a list of processes with details for each process.</span></span> <span data-ttu-id="da3fe-931">情報は JSON 形式で、テンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-931">The information is in JSON format and has the following template.</span></span>
```
{"Processes": [
    {
        "CPUUsage": int,
        "ImageName": string,
        "PageFileUsage": int,
        "PrivateWorkingSet": int,
        "ProcessId": int,
        "SessionId": int,
        "UserName": string,
        "VirtualSize": int,
        "WorkingSetSize": int
    },...
]}
```

**<span data-ttu-id="da3fe-932">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-932">Status code</span></span>**

<span data-ttu-id="da3fe-933">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-933">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-934">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-934">HTTP status code</span></span>      | <span data-ttu-id="da3fe-935">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-935">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-936">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-936">200</span></span> | <span data-ttu-id="da3fe-937">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-937">OK</span></span>
<span data-ttu-id="da3fe-938">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-938">4XX</span></span> | <span data-ttu-id="da3fe-939">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-939">Error codes</span></span>
<span data-ttu-id="da3fe-940">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-940">5XX</span></span> | <span data-ttu-id="da3fe-941">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-941">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-942">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-942">Available device families</span></span>**

* <span data-ttu-id="da3fe-943">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-943">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-944">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-944">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-945">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-945">HoloLens</span></span>
* <span data-ttu-id="da3fe-946">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-946">IoT</span></span>

---
### <a name="get-the-system-performance-statistics"></a><span data-ttu-id="da3fe-947">システム パフォーマンスの統計情報を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-947">Get the system performance statistics</span></span>

**<span data-ttu-id="da3fe-948">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-948">Request</span></span>**

<span data-ttu-id="da3fe-949">次の要求形式を使用して、システム パフォーマンスの統計情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-949">You can get the system performance statistics by using the following request format.</span></span> <span data-ttu-id="da3fe-950">これには、読み取りと書き込みのサイクルや、使用されているメモリの量などの情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-950">This includes information such as read and write cycles and how much memory has been used.</span></span>
 
<span data-ttu-id="da3fe-951">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-951">Method</span></span>      | <span data-ttu-id="da3fe-952">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-952">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-953">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-953">GET</span></span> | <span data-ttu-id="da3fe-954">/api/resourcemanager/systemperf</span><span class="sxs-lookup"><span data-stu-id="da3fe-954">/api/resourcemanager/systemperf</span></span>
<span data-ttu-id="da3fe-955">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="da3fe-955">GET/WebSocket</span></span> | <span data-ttu-id="da3fe-956">/api/resourcemanager/systemperf</span><span class="sxs-lookup"><span data-stu-id="da3fe-956">/api/resourcemanager/systemperf</span></span>
<br />
<span data-ttu-id="da3fe-957">これは、WebSocket 接続にアップグレードできます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-957">This can also be upgraded to a WebSocket connection.</span></span>  <span data-ttu-id="da3fe-958">1 秒に 1 度以下と同じ JSON データが提供されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-958">It provides the same JSON data below once every second.</span></span> 

**<span data-ttu-id="da3fe-959">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-959">URI parameters</span></span>**

- <span data-ttu-id="da3fe-960">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-960">None</span></span>

**<span data-ttu-id="da3fe-961">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-961">Request headers</span></span>**

- <span data-ttu-id="da3fe-962">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-962">None</span></span>

**<span data-ttu-id="da3fe-963">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-963">Request body</span></span>**

- <span data-ttu-id="da3fe-964">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-964">None</span></span>

**<span data-ttu-id="da3fe-965">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-965">Response</span></span>**

<span data-ttu-id="da3fe-966">応答には、CPU と GPU の使用量、メモリ アクセス、ネットワーク アクセスなど、システムのパフォーマンス統計情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-966">The response includes the performance statistics for the system such as CPU and GPU usage, memory access, and network access.</span></span> <span data-ttu-id="da3fe-967">この情報は JSON 形式で、テンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-967">This information is in JSON format and has the following template.</span></span>
```
{
    "AvailablePages": int,
    "CommitLimit": int,
    "CommittedPages": int,
    "CpuLoad": int,
    "IOOtherSpeed": int,
    "IOReadSpeed": int,
    "IOWriteSpeed": int,
    "NonPagedPoolPages": int,
    "PageSize": int,
    "PagedPoolPages": int,
    "TotalInstalledInKb": int,
    "TotalPages": int,
    "GPUData": 
    {
        "AvailableAdapters": [{ (One per detected adapter)
            "DedicatedMemory": int,
            "DedicatedMemoryUsed": int,
            "Description": string,
            "SystemMemory": int,
            "SystemMemoryUsed": int,
            "EnginesUtilization": [ float,... (One per detected engine)]
        },...
    ]},
    "NetworkingData": {
        "NetworkInBytes": int,
        "NetworkOutBytes": int
    }
}
```

**<span data-ttu-id="da3fe-968">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-968">Status code</span></span>**

<span data-ttu-id="da3fe-969">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-969">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-970">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-970">HTTP status code</span></span>      | <span data-ttu-id="da3fe-971">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-971">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-972">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-972">200</span></span> | <span data-ttu-id="da3fe-973">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-973">OK</span></span>
<span data-ttu-id="da3fe-974">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-974">4XX</span></span> | <span data-ttu-id="da3fe-975">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-975">Error codes</span></span>
<span data-ttu-id="da3fe-976">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-976">5XX</span></span> | <span data-ttu-id="da3fe-977">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-977">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-978">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-978">Available device families</span></span>**

* <span data-ttu-id="da3fe-979">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-979">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-980">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-980">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-981">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-981">Xbox</span></span>
* <span data-ttu-id="da3fe-982">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-982">HoloLens</span></span>
* <span data-ttu-id="da3fe-983">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-983">IoT</span></span>

---
## Power
---
### <a name="get-the-current-battery-state"></a><span data-ttu-id="da3fe-984">現在のバッテリ状態を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-984">Get the current battery state</span></span>

**<span data-ttu-id="da3fe-985">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-985">Request</span></span>**

<span data-ttu-id="da3fe-986">次の要求形式を使用して、バッテリの現在の状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-986">You can get the current state of the battery by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-987">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-987">Method</span></span>      | <span data-ttu-id="da3fe-988">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-988">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-989">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-989">GET</span></span> | <span data-ttu-id="da3fe-990">/api/power/battery</span><span class="sxs-lookup"><span data-stu-id="da3fe-990">/api/power/battery</span></span>
<br />

**<span data-ttu-id="da3fe-991">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-991">URI parameters</span></span>**

- <span data-ttu-id="da3fe-992">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-992">None</span></span>

**<span data-ttu-id="da3fe-993">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-993">Request headers</span></span>**

- <span data-ttu-id="da3fe-994">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-994">None</span></span>

**<span data-ttu-id="da3fe-995">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-995">Request body</span></span>**

- <span data-ttu-id="da3fe-996">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-996">None</span></span>

**<span data-ttu-id="da3fe-997">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-997">Response</span></span>**

<span data-ttu-id="da3fe-998">現在のバッテリ状態に関する情報が次の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-998">The current battery state information is returned using the following format.</span></span>
```
{
    "AcOnline": int (0 | 1),
    "BatteryPresent": int (0 | 1),
    "Charging": int (0 | 1),
    "DefaultAlert1": int,
    "DefaultAlert2": int,
    "EstimatedTime": int,
    "MaximumCapacity": int,
    "RemainingCapacity": int
}
```

**<span data-ttu-id="da3fe-999">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-999">Status code</span></span>**

<span data-ttu-id="da3fe-1000">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1000">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1001">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1001">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1002">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1002">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1003">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1003">200</span></span> | <span data-ttu-id="da3fe-1004">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1004">OK</span></span>
<span data-ttu-id="da3fe-1005">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1005">4XX</span></span> | <span data-ttu-id="da3fe-1006">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1006">Error codes</span></span>
<span data-ttu-id="da3fe-1007">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1007">5XX</span></span> | <span data-ttu-id="da3fe-1008">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1008">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1009">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1009">Available device families</span></span>**

* <span data-ttu-id="da3fe-1010">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1010">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1011">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1011">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1012">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1012">HoloLens</span></span>
* <span data-ttu-id="da3fe-1013">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1013">IoT</span></span>

---
### <a name="get-the-active-power-scheme"></a><span data-ttu-id="da3fe-1014">アクティブな電源設定を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1014">Get the active power scheme</span></span>

**<span data-ttu-id="da3fe-1015">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1015">Request</span></span>**

<span data-ttu-id="da3fe-1016">次の要求形式を使用して、アクティブな電源設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1016">You can get the active power scheme by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1017">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1017">Method</span></span>      | <span data-ttu-id="da3fe-1018">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1018">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1019">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1019">GET</span></span> | <span data-ttu-id="da3fe-1020">/api/power/activecfg</span><span class="sxs-lookup"><span data-stu-id="da3fe-1020">/api/power/activecfg</span></span>
<br />

**<span data-ttu-id="da3fe-1021">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1021">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1022">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1022">None</span></span>

**<span data-ttu-id="da3fe-1023">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1023">Request headers</span></span>**

- <span data-ttu-id="da3fe-1024">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1024">None</span></span>

**<span data-ttu-id="da3fe-1025">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1025">Request body</span></span>**

- <span data-ttu-id="da3fe-1026">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1026">None</span></span>

**<span data-ttu-id="da3fe-1027">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1027">Response</span></span>**

<span data-ttu-id="da3fe-1028">アクティブな電源設定の形式は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1028">The active power scheme has the following format.</span></span>
```
{"ActivePowerScheme": string (guid of scheme)}
```

**<span data-ttu-id="da3fe-1029">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1029">Status code</span></span>**

<span data-ttu-id="da3fe-1030">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1030">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1031">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1031">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1032">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1032">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1033">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1033">200</span></span> | <span data-ttu-id="da3fe-1034">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1034">OK</span></span>
<span data-ttu-id="da3fe-1035">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1035">4XX</span></span> | <span data-ttu-id="da3fe-1036">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1036">Error codes</span></span>
<span data-ttu-id="da3fe-1037">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1037">5XX</span></span> | <span data-ttu-id="da3fe-1038">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1038">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1039">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1039">Available device families</span></span>**

* <span data-ttu-id="da3fe-1040">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1040">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1041">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1041">IoT</span></span>

---
### <a name="get-the-sub-value-for-a-power-scheme"></a><span data-ttu-id="da3fe-1042">電源設定のサブ値を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1042">Get the sub-value for a power scheme</span></span>

**<span data-ttu-id="da3fe-1043">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1043">Request</span></span>**

<span data-ttu-id="da3fe-1044">次の要求形式を使用して、電源設定のサブ値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1044">You can get the sub-value for a power scheme by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1045">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1045">Method</span></span>      | <span data-ttu-id="da3fe-1046">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1046">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1047">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1047">GET</span></span> | <span data-ttu-id="da3fe-1048">/api/power/cfg/*<power scheme path>*</span><span class="sxs-lookup"><span data-stu-id="da3fe-1048">/api/power/cfg/*<power scheme path>*</span></span>
<br />
<span data-ttu-id="da3fe-1049">オプション:</span><span class="sxs-lookup"><span data-stu-id="da3fe-1049">Options:</span></span>
- <span data-ttu-id="da3fe-1050">SCHEME_CURRENT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1050">SCHEME_CURRENT</span></span>

**<span data-ttu-id="da3fe-1051">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1051">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1052">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1052">None</span></span>

**<span data-ttu-id="da3fe-1053">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1053">Request headers</span></span>**

- <span data-ttu-id="da3fe-1054">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1054">None</span></span>

**<span data-ttu-id="da3fe-1055">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1055">Request body</span></span>**

<span data-ttu-id="da3fe-1056">利用可能な電源状態の完全な一覧は、アプリケーションごとが基本で、バッテリ低下、重要なバッテリといったさまざまな電源状態がフラグ設定されています。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1056">A full listing of power states available is on a per-application basis and the settings for flagging various power states like low and critical batterty.</span></span> 

**<span data-ttu-id="da3fe-1057">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1057">Response</span></span>**

**<span data-ttu-id="da3fe-1058">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1058">Status code</span></span>**

<span data-ttu-id="da3fe-1059">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1059">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1060">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1060">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1061">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1061">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1062">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1062">200</span></span> | <span data-ttu-id="da3fe-1063">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1063">OK</span></span>
<span data-ttu-id="da3fe-1064">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1064">4XX</span></span> | <span data-ttu-id="da3fe-1065">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1065">Error codes</span></span>
<span data-ttu-id="da3fe-1066">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1066">5XX</span></span> | <span data-ttu-id="da3fe-1067">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1067">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1068">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1068">Available device families</span></span>**

* <span data-ttu-id="da3fe-1069">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1069">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1070">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1070">IoT</span></span>

---
### <a name="get-the-power-state-of-the-system"></a><span data-ttu-id="da3fe-1071">システムの電源状態を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1071">Get the power state of the system</span></span>

**<span data-ttu-id="da3fe-1072">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1072">Request</span></span>**

<span data-ttu-id="da3fe-1073">次の要求形式を使用して、システムの電源状態を確認できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1073">You can check the power state of the system by using the following request format.</span></span> <span data-ttu-id="da3fe-1074">これによって、低電力状態になっているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1074">This will let you check to see if it is in a low power state.</span></span>
 
<span data-ttu-id="da3fe-1075">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1075">Method</span></span>      | <span data-ttu-id="da3fe-1076">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1076">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1077">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1077">GET</span></span> | <span data-ttu-id="da3fe-1078">/api/power/state</span><span class="sxs-lookup"><span data-stu-id="da3fe-1078">/api/power/state</span></span>
<br />

**<span data-ttu-id="da3fe-1079">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1079">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1080">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1080">None</span></span>

**<span data-ttu-id="da3fe-1081">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1081">Request headers</span></span>**

- <span data-ttu-id="da3fe-1082">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1082">None</span></span>

**<span data-ttu-id="da3fe-1083">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1083">Request body</span></span>**

- <span data-ttu-id="da3fe-1084">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1084">None</span></span>

**<span data-ttu-id="da3fe-1085">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1085">Response</span></span>**

<span data-ttu-id="da3fe-1086">電源状態の情報のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1086">The power state information has the following template.</span></span>
```
{"LowPowerStateAvailable": bool}
```

**<span data-ttu-id="da3fe-1087">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1087">Status code</span></span>**

<span data-ttu-id="da3fe-1088">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1088">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1089">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1089">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1090">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1090">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1091">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1091">200</span></span> | <span data-ttu-id="da3fe-1092">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1092">OK</span></span>
<span data-ttu-id="da3fe-1093">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1093">4XX</span></span> | <span data-ttu-id="da3fe-1094">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1094">Error codes</span></span>
<span data-ttu-id="da3fe-1095">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1095">5XX</span></span> | <span data-ttu-id="da3fe-1096">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1096">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1097">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1097">Available device families</span></span>**

* <span data-ttu-id="da3fe-1098">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1098">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1099">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1099">HoloLens</span></span>
* <span data-ttu-id="da3fe-1100">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1100">IoT</span></span>

---
### <a name="set-the-active-power-scheme"></a><span data-ttu-id="da3fe-1101">アクティブな電源設定を行う</span><span class="sxs-lookup"><span data-stu-id="da3fe-1101">Set the active power scheme</span></span>

**<span data-ttu-id="da3fe-1102">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1102">Request</span></span>**

<span data-ttu-id="da3fe-1103">次の要求形式を使用して、アクティブな電源設定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1103">You can set the active power scheme by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1104">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1104">Method</span></span>      | <span data-ttu-id="da3fe-1105">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1105">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1106">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1106">POST</span></span> | <span data-ttu-id="da3fe-1107">/api/power/activecfg</span><span class="sxs-lookup"><span data-stu-id="da3fe-1107">/api/power/activecfg</span></span>
<br />

**<span data-ttu-id="da3fe-1108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1108">URI parameters</span></span>**

<span data-ttu-id="da3fe-1109">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1109">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1110">URI parameter</span></span> | <span data-ttu-id="da3fe-1111">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1111">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1112">scheme</span><span class="sxs-lookup"><span data-stu-id="da3fe-1112">scheme</span></span> | <span data-ttu-id="da3fe-1113">(**必須**) システムのアクティブな電源設定として設定するスキームの GUID。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1113">(**required**) The GUID of the scheme you want to set as the active power scheme for the system.</span></span>
<br />
**<span data-ttu-id="da3fe-1114">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1114">Request headers</span></span>**

- <span data-ttu-id="da3fe-1115">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1115">None</span></span>

**<span data-ttu-id="da3fe-1116">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1116">Request body</span></span>**

- <span data-ttu-id="da3fe-1117">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1117">None</span></span>

**<span data-ttu-id="da3fe-1118">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1118">Response</span></span>**

**<span data-ttu-id="da3fe-1119">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1119">Status code</span></span>**

<span data-ttu-id="da3fe-1120">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1120">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1121">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1121">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1122">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1122">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1123">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1123">200</span></span> | <span data-ttu-id="da3fe-1124">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1124">OK</span></span>
<span data-ttu-id="da3fe-1125">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1125">4XX</span></span> | <span data-ttu-id="da3fe-1126">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1126">Error codes</span></span>
<span data-ttu-id="da3fe-1127">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1127">5XX</span></span> | <span data-ttu-id="da3fe-1128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1128">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1129">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1129">Available device families</span></span>**

* <span data-ttu-id="da3fe-1130">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1130">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1131">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1131">IoT</span></span>

---
### <a name="set-the-sub-value-for-a-power-scheme"></a><span data-ttu-id="da3fe-1132">電源設定のサブ値を設定する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1132">Set the sub-value for a power scheme</span></span>

**<span data-ttu-id="da3fe-1133">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1133">Request</span></span>**

<span data-ttu-id="da3fe-1134">次の要求形式を使用して、電源設定のサブ値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1134">You can set the sub-value for a power scheme by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1135">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1135">Method</span></span>      | <span data-ttu-id="da3fe-1136">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1136">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1137">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1137">POST</span></span> | <span data-ttu-id="da3fe-1138">/api/power/cfg/*<power scheme path>*</span><span class="sxs-lookup"><span data-stu-id="da3fe-1138">/api/power/cfg/*<power scheme path>*</span></span>
<br />

**<span data-ttu-id="da3fe-1139">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1139">URI parameters</span></span>**

<span data-ttu-id="da3fe-1140">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1140">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1141">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1141">URI parameter</span></span> | <span data-ttu-id="da3fe-1142">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1142">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1143">valueAC</span><span class="sxs-lookup"><span data-stu-id="da3fe-1143">valueAC</span></span> | <span data-ttu-id="da3fe-1144">(**必須**) AC 電源に使用する値。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1144">(**required**) The value to use for A/C power.</span></span>
<span data-ttu-id="da3fe-1145">valueDC</span><span class="sxs-lookup"><span data-stu-id="da3fe-1145">valueDC</span></span> | <span data-ttu-id="da3fe-1146">(**必須**) バッテリ電源に使用する値。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1146">(**required**) The value to use for battery power.</span></span>
<br />
**<span data-ttu-id="da3fe-1147">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1147">Request headers</span></span>**

- <span data-ttu-id="da3fe-1148">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1148">None</span></span>

**<span data-ttu-id="da3fe-1149">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1149">Request body</span></span>**

- <span data-ttu-id="da3fe-1150">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1150">None</span></span>

**<span data-ttu-id="da3fe-1151">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1151">Response</span></span>**

**<span data-ttu-id="da3fe-1152">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1152">Status code</span></span>**

<span data-ttu-id="da3fe-1153">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1153">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1154">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1154">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1155">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1155">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1156">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1156">200</span></span> | <span data-ttu-id="da3fe-1157">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1157">OK</span></span>
<br />
**<span data-ttu-id="da3fe-1158">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1158">Available device families</span></span>**

* <span data-ttu-id="da3fe-1159">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1159">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1160">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1160">IoT</span></span>

---
### <a name="get-a-sleep-study-report"></a><span data-ttu-id="da3fe-1161">SleepStudy レポートを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1161">Get a sleep study report</span></span>

**<span data-ttu-id="da3fe-1162">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1162">Request</span></span>**

<span data-ttu-id="da3fe-1163">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1163">Method</span></span>      | <span data-ttu-id="da3fe-1164">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1164">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1165">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1165">GET</span></span> | <span data-ttu-id="da3fe-1166">/api/power/sleepstudy/report</span><span class="sxs-lookup"><span data-stu-id="da3fe-1166">/api/power/sleepstudy/report</span></span>
<br />
<span data-ttu-id="da3fe-1167">次の要求形式を使用して、SleepStudy レポートを取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1167">You can get a sleep study report by using the following request format.</span></span>

**<span data-ttu-id="da3fe-1168">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1168">URI parameters</span></span>**
<span data-ttu-id="da3fe-1169">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1169">URI parameter</span></span> | <span data-ttu-id="da3fe-1170">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1170">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1171">FileName</span><span class="sxs-lookup"><span data-stu-id="da3fe-1171">FileName</span></span> | <span data-ttu-id="da3fe-1172">(**必須**) ダウンロードするファイルの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1172">(**required**) The full name for the file you want to download.</span></span> <span data-ttu-id="da3fe-1173">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1173">This value should be hex64 encoded.</span></span>
<br />
**<span data-ttu-id="da3fe-1174">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1174">Request headers</span></span>**

- <span data-ttu-id="da3fe-1175">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1175">None</span></span>

**<span data-ttu-id="da3fe-1176">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1176">Request body</span></span>**

- <span data-ttu-id="da3fe-1177">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1177">None</span></span>

**<span data-ttu-id="da3fe-1178">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1178">Response</span></span>**

<span data-ttu-id="da3fe-1179">応答は、スリープ検査の結果が含まれているファイルです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1179">The response is a file containing the sleep study.</span></span> 

**<span data-ttu-id="da3fe-1180">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1180">Status code</span></span>**

<span data-ttu-id="da3fe-1181">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1181">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1182">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1182">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1183">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1183">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1184">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1184">200</span></span> | <span data-ttu-id="da3fe-1185">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1185">OK</span></span>
<span data-ttu-id="da3fe-1186">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1186">4XX</span></span> | <span data-ttu-id="da3fe-1187">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1187">Error codes</span></span>
<span data-ttu-id="da3fe-1188">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1188">5XX</span></span> | <span data-ttu-id="da3fe-1189">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1189">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1190">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1190">Available device families</span></span>**

* <span data-ttu-id="da3fe-1191">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1191">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1192">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1192">IoT</span></span>

---
### <a name="enumerate-the-available-sleep-study-reports"></a><span data-ttu-id="da3fe-1193">利用可能な SleepStudy レポートを列挙する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1193">Enumerate the available sleep study reports</span></span>

**<span data-ttu-id="da3fe-1194">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1194">Request</span></span>**

<span data-ttu-id="da3fe-1195">次の要求形式を使用して、利用可能な SleepStudy レポートを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1195">You can enumerate the available sleep study reports by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1196">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1196">Method</span></span>      | <span data-ttu-id="da3fe-1197">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1197">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1198">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1198">GET</span></span> | <span data-ttu-id="da3fe-1199">/api/power/sleepstudy/reports</span><span class="sxs-lookup"><span data-stu-id="da3fe-1199">/api/power/sleepstudy/reports</span></span>
<br />

**<span data-ttu-id="da3fe-1200">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1200">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1201">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1201">None</span></span>

**<span data-ttu-id="da3fe-1202">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1202">Request headers</span></span>**

- <span data-ttu-id="da3fe-1203">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1203">None</span></span>

**<span data-ttu-id="da3fe-1204">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1204">Request body</span></span>**

- <span data-ttu-id="da3fe-1205">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1205">None</span></span>

**<span data-ttu-id="da3fe-1206">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1206">Response</span></span>**

<span data-ttu-id="da3fe-1207">利用可能なレポートの一覧のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1207">The list of available reports has the following template.</span></span>

```
{"Reports": [
    {
        "FileName": string
    },...
]}
```

**<span data-ttu-id="da3fe-1208">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1208">Status code</span></span>**

<span data-ttu-id="da3fe-1209">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1209">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1210">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1210">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1211">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1211">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1212">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1212">200</span></span> | <span data-ttu-id="da3fe-1213">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1213">OK</span></span>
<span data-ttu-id="da3fe-1214">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1214">4XX</span></span> | <span data-ttu-id="da3fe-1215">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1215">Error codes</span></span>
<span data-ttu-id="da3fe-1216">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1216">5XX</span></span> | <span data-ttu-id="da3fe-1217">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1217">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1218">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1218">Available device families</span></span>**

* <span data-ttu-id="da3fe-1219">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1219">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1220">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1220">IoT</span></span>

---
### <a name="get-the-sleep-study-transform"></a><span data-ttu-id="da3fe-1221">スリープ スタディ変換を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1221">Get the sleep study transform</span></span>

**<span data-ttu-id="da3fe-1222">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1222">Request</span></span>**

<span data-ttu-id="da3fe-1223">次の要求形式を使用して、スリープ スタディ変換を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1223">You can get the sleep study transform by using the following request format.</span></span> <span data-ttu-id="da3fe-1224">この変換は、SleepStudy レポートを、ユーザーが読み取ることができる XML 形式に変換する XSLT です。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1224">This transform is an XSLT that converts the sleep study report into an XML format that can be read by a person.</span></span>
 
<span data-ttu-id="da3fe-1225">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1225">Method</span></span>      | <span data-ttu-id="da3fe-1226">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1226">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1227">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1227">GET</span></span> | <span data-ttu-id="da3fe-1228">/api/power/sleepstudy/transform</span><span class="sxs-lookup"><span data-stu-id="da3fe-1228">/api/power/sleepstudy/transform</span></span>
<br />

**<span data-ttu-id="da3fe-1229">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1229">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1230">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1230">None</span></span>

**<span data-ttu-id="da3fe-1231">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1231">Request headers</span></span>**

- <span data-ttu-id="da3fe-1232">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1232">None</span></span>

**<span data-ttu-id="da3fe-1233">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1233">Request body</span></span>**

- <span data-ttu-id="da3fe-1234">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1234">None</span></span>

**<span data-ttu-id="da3fe-1235">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1235">Response</span></span>**

<span data-ttu-id="da3fe-1236">応答には、スリープ スタディ変換が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1236">The response contains the sleep study transform.</span></span>

**<span data-ttu-id="da3fe-1237">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1237">Status code</span></span>**

<span data-ttu-id="da3fe-1238">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1238">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1239">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1239">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1240">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1240">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1241">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1241">200</span></span> | <span data-ttu-id="da3fe-1242">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1242">OK</span></span>
<span data-ttu-id="da3fe-1243">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1243">4XX</span></span> | <span data-ttu-id="da3fe-1244">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1244">Error codes</span></span>
<span data-ttu-id="da3fe-1245">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1245">5XX</span></span> | <span data-ttu-id="da3fe-1246">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1246">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1247">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1247">Available device families</span></span>**

* <span data-ttu-id="da3fe-1248">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1248">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1249">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1249">IoT</span></span>

---
## Remote control
---
### <a name="restart-the-target-computer"></a><span data-ttu-id="da3fe-1250">ターゲット コンピューターを再起動する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1250">Restart the target computer</span></span>

**<span data-ttu-id="da3fe-1251">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1251">Request</span></span>**

<span data-ttu-id="da3fe-1252">次の要求形式を使用して、ターゲット コンピューターを再起動できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1252">You can restart the target computer by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1253">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1253">Method</span></span>      | <span data-ttu-id="da3fe-1254">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1254">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1255">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1255">POST</span></span> | <span data-ttu-id="da3fe-1256">/api/control/restart</span><span class="sxs-lookup"><span data-stu-id="da3fe-1256">/api/control/restart</span></span>
<br />

**<span data-ttu-id="da3fe-1257">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1257">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1258">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1258">None</span></span>

**<span data-ttu-id="da3fe-1259">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1259">Request headers</span></span>**

- <span data-ttu-id="da3fe-1260">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1260">None</span></span>

**<span data-ttu-id="da3fe-1261">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1261">Request body</span></span>**

- <span data-ttu-id="da3fe-1262">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1262">None</span></span>

**<span data-ttu-id="da3fe-1263">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1263">Response</span></span>**

**<span data-ttu-id="da3fe-1264">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1264">Status code</span></span>**

<span data-ttu-id="da3fe-1265">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1265">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1266">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1266">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1267">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1267">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1268">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1268">200</span></span> | <span data-ttu-id="da3fe-1269">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1269">OK</span></span>
<br />
**<span data-ttu-id="da3fe-1270">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1270">Available device families</span></span>**

* <span data-ttu-id="da3fe-1271">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1271">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1272">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1272">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1273">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1273">Xbox</span></span>
* <span data-ttu-id="da3fe-1274">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1274">HoloLens</span></span>
* <span data-ttu-id="da3fe-1275">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1275">IoT</span></span>

---
### <a name="shut-down-the-target-computer"></a><span data-ttu-id="da3fe-1276">ターゲット コンピューターをシャットダウンする</span><span class="sxs-lookup"><span data-stu-id="da3fe-1276">Shut down the target computer</span></span>

**<span data-ttu-id="da3fe-1277">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1277">Request</span></span>**

<span data-ttu-id="da3fe-1278">次の要求形式を使用して、ターゲット コンピューターをシャット ダウンできます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1278">You can shut down the target computer by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1279">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1279">Method</span></span>      | <span data-ttu-id="da3fe-1280">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1280">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1281">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1281">POST</span></span> | <span data-ttu-id="da3fe-1282">/api/control/shutdown</span><span class="sxs-lookup"><span data-stu-id="da3fe-1282">/api/control/shutdown</span></span>
<br />

**<span data-ttu-id="da3fe-1283">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1283">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1284">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1284">None</span></span>

**<span data-ttu-id="da3fe-1285">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1285">Request headers</span></span>**

- <span data-ttu-id="da3fe-1286">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1286">None</span></span>

**<span data-ttu-id="da3fe-1287">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1287">Request body</span></span>**

- <span data-ttu-id="da3fe-1288">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1288">None</span></span>

**<span data-ttu-id="da3fe-1289">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1289">Response</span></span>**

**<span data-ttu-id="da3fe-1290">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1290">Status code</span></span>**

<span data-ttu-id="da3fe-1291">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1291">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1292">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1292">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1293">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1293">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1294">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1294">200</span></span> | <span data-ttu-id="da3fe-1295">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1295">OK</span></span>
<span data-ttu-id="da3fe-1296">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1296">4XX</span></span> | <span data-ttu-id="da3fe-1297">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1297">Error codes</span></span>
<span data-ttu-id="da3fe-1298">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1298">5XX</span></span> | <span data-ttu-id="da3fe-1299">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1299">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1300">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1300">Available device families</span></span>**

* <span data-ttu-id="da3fe-1301">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1301">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1302">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1302">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1303">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1303">Xbox</span></span>
* <span data-ttu-id="da3fe-1304">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1304">HoloLens</span></span>
* <span data-ttu-id="da3fe-1305">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1305">IoT</span></span>

---
## Task manager
---
### <a name="start-a-modern-app"></a><span data-ttu-id="da3fe-1306">最新のアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1306">Start a modern app</span></span>

**<span data-ttu-id="da3fe-1307">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1307">Request</span></span>**

<span data-ttu-id="da3fe-1308">次の要求形式を使用して、最新のアプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1308">You can start a modern app by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1309">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1309">Method</span></span>      | <span data-ttu-id="da3fe-1310">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1310">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1311">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1311">POST</span></span> | <span data-ttu-id="da3fe-1312">/api/taskmanager/app</span><span class="sxs-lookup"><span data-stu-id="da3fe-1312">/api/taskmanager/app</span></span>
<br />

**<span data-ttu-id="da3fe-1313">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1313">URI parameters</span></span>**

<span data-ttu-id="da3fe-1314">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1314">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1315">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1315">URI parameter</span></span> | <span data-ttu-id="da3fe-1316">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1316">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1317">appid</span><span class="sxs-lookup"><span data-stu-id="da3fe-1317">appid</span></span>   | <span data-ttu-id="da3fe-1318">(**必須**) 起動するアプリの PRAID。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1318">(**required**) The PRAID for the app you want to start.</span></span> <span data-ttu-id="da3fe-1319">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1319">This value should be hex64 encoded.</span></span>
<span data-ttu-id="da3fe-1320">package</span><span class="sxs-lookup"><span data-stu-id="da3fe-1320">package</span></span>   | <span data-ttu-id="da3fe-1321">(**必須**) 起動するアプリ パッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1321">(**required**) The full name for the app package you want to start.</span></span> <span data-ttu-id="da3fe-1322">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1322">This value should be hex64 encoded.</span></span>
<br />
**<span data-ttu-id="da3fe-1323">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1323">Request headers</span></span>**

- <span data-ttu-id="da3fe-1324">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1324">None</span></span>

**<span data-ttu-id="da3fe-1325">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1325">Request body</span></span>**

- <span data-ttu-id="da3fe-1326">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1326">None</span></span>

**<span data-ttu-id="da3fe-1327">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1327">Response</span></span>**

**<span data-ttu-id="da3fe-1328">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1328">Status code</span></span>**

<span data-ttu-id="da3fe-1329">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1329">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1330">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1330">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1331">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1331">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1332">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1332">200</span></span> | <span data-ttu-id="da3fe-1333">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1333">OK</span></span>
<span data-ttu-id="da3fe-1334">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1334">4XX</span></span> | <span data-ttu-id="da3fe-1335">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1335">Error codes</span></span>
<span data-ttu-id="da3fe-1336">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1336">5XX</span></span> | <span data-ttu-id="da3fe-1337">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1337">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1338">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1338">Available device families</span></span>**

* <span data-ttu-id="da3fe-1339">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1339">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1340">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1340">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1341">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1341">Xbox</span></span>
* <span data-ttu-id="da3fe-1342">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1342">HoloLens</span></span>
* <span data-ttu-id="da3fe-1343">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1343">IoT</span></span>

---
### <a name="stop-a-modern-app"></a><span data-ttu-id="da3fe-1344">最新のアプリを停止する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1344">Stop a modern app</span></span>

**<span data-ttu-id="da3fe-1345">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1345">Request</span></span>**

<span data-ttu-id="da3fe-1346">次の要求形式を使用して、最新のアプリを停止できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1346">You can stop a modern app by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1347">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1347">Method</span></span>      | <span data-ttu-id="da3fe-1348">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1348">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1349">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-1349">DELETE</span></span> | <span data-ttu-id="da3fe-1350">/api/taskmanager/app</span><span class="sxs-lookup"><span data-stu-id="da3fe-1350">/api/taskmanager/app</span></span>
<br />

**<span data-ttu-id="da3fe-1351">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1351">URI parameters</span></span>**

<span data-ttu-id="da3fe-1352">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1352">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1353">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1353">URI parameter</span></span> | <span data-ttu-id="da3fe-1354">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1354">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1355">package</span><span class="sxs-lookup"><span data-stu-id="da3fe-1355">package</span></span>   | <span data-ttu-id="da3fe-1356">(**必須**) 停止するアプリ パッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1356">(**required**) The full name of the app packages that you want to stop.</span></span> <span data-ttu-id="da3fe-1357">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1357">This value should be hex64 encoded.</span></span>
<span data-ttu-id="da3fe-1358">forcestop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1358">forcestop</span></span>   | <span data-ttu-id="da3fe-1359">(**オプション**) 値が **yes** の場合は、システムがすべてのプロセスを強制的に停止することを示します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1359">(**optional**) A value of **yes** indicates that the system should force all processes to stop.</span></span>
<br />
**<span data-ttu-id="da3fe-1360">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1360">Request headers</span></span>**

- <span data-ttu-id="da3fe-1361">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1361">None</span></span>

**<span data-ttu-id="da3fe-1362">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1362">Request body</span></span>**

- <span data-ttu-id="da3fe-1363">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1363">None</span></span>

**<span data-ttu-id="da3fe-1364">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1364">Response</span></span>**

**<span data-ttu-id="da3fe-1365">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1365">Status code</span></span>**

<span data-ttu-id="da3fe-1366">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1366">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1367">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1367">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1368">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1368">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1369">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1369">200</span></span> | <span data-ttu-id="da3fe-1370">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1370">OK</span></span>
<span data-ttu-id="da3fe-1371">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1371">4XX</span></span> | <span data-ttu-id="da3fe-1372">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1372">Error codes</span></span>
<span data-ttu-id="da3fe-1373">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1373">5XX</span></span> | <span data-ttu-id="da3fe-1374">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1374">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1375">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1375">Available device families</span></span>**

* <span data-ttu-id="da3fe-1376">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1376">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1377">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1377">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1378">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1378">Xbox</span></span>
* <span data-ttu-id="da3fe-1379">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1379">HoloLens</span></span>
* <span data-ttu-id="da3fe-1380">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1380">IoT</span></span>

---
### <a name="kill-process-by-pid"></a><span data-ttu-id="da3fe-1381">PID でプロセスを強制終了する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1381">Kill process by PID</span></span>

**<span data-ttu-id="da3fe-1382">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1382">Request</span></span>**

<span data-ttu-id="da3fe-1383">次の要求形式を使用して、プロセスを強制終了できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1383">You can kill a process by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1384">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1384">Method</span></span>      | <span data-ttu-id="da3fe-1385">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1385">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1386">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-1386">DELETE</span></span> | <span data-ttu-id="da3fe-1387">/api/taskmanager/process</span><span class="sxs-lookup"><span data-stu-id="da3fe-1387">/api/taskmanager/process</span></span>
<br />

**<span data-ttu-id="da3fe-1388">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1388">URI parameters</span></span>**

<span data-ttu-id="da3fe-1389">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1389">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1390">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1390">URI parameter</span></span> | <span data-ttu-id="da3fe-1391">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1391">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1392">pid</span><span class="sxs-lookup"><span data-stu-id="da3fe-1392">pid</span></span>   | <span data-ttu-id="da3fe-1393">(**必須**) 終了するプロセスの一意のプロセス ID。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1393">(**required**) The unique process id for the process to stop.</span></span>
<br />
**<span data-ttu-id="da3fe-1394">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1394">Request headers</span></span>**

- <span data-ttu-id="da3fe-1395">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1395">None</span></span>

**<span data-ttu-id="da3fe-1396">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1396">Request body</span></span>**

- <span data-ttu-id="da3fe-1397">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1397">None</span></span>

**<span data-ttu-id="da3fe-1398">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1398">Response</span></span>**

**<span data-ttu-id="da3fe-1399">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1399">Status code</span></span>**

<span data-ttu-id="da3fe-1400">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1400">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1401">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1401">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1402">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1402">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1403">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1403">200</span></span> | <span data-ttu-id="da3fe-1404">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1404">OK</span></span>
<span data-ttu-id="da3fe-1405">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1405">4XX</span></span> | <span data-ttu-id="da3fe-1406">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1406">Error codes</span></span>
<span data-ttu-id="da3fe-1407">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1407">5XX</span></span> | <span data-ttu-id="da3fe-1408">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1408">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1409">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1409">Available device families</span></span>**

* <span data-ttu-id="da3fe-1410">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1410">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1411">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1411">HoloLens</span></span>
* <span data-ttu-id="da3fe-1412">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1412">IoT</span></span>

---
## Networking
---
### <a name="get-the-current-ip-configuration"></a><span data-ttu-id="da3fe-1413">現在の IP 構成を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1413">Get the current IP configuration</span></span>

**<span data-ttu-id="da3fe-1414">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1414">Request</span></span>**

<span data-ttu-id="da3fe-1415">次の要求形式を使用して、現在の IP 構成を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1415">You can get the current IP configuration by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1416">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1416">Method</span></span>      | <span data-ttu-id="da3fe-1417">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1417">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1418">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1418">GET</span></span> | <span data-ttu-id="da3fe-1419">/api/networking/ipconfig</span><span class="sxs-lookup"><span data-stu-id="da3fe-1419">/api/networking/ipconfig</span></span>
<br />

**<span data-ttu-id="da3fe-1420">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1420">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1421">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1421">None</span></span>

**<span data-ttu-id="da3fe-1422">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1422">Request headers</span></span>**

- <span data-ttu-id="da3fe-1423">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1423">None</span></span>

**<span data-ttu-id="da3fe-1424">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1424">Request body</span></span>**

- <span data-ttu-id="da3fe-1425">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1425">None</span></span>

**<span data-ttu-id="da3fe-1426">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1426">Response</span></span>**

<span data-ttu-id="da3fe-1427">応答には、次のテンプレートの IP 構成が含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1427">The response includes the IP configuration in the following template.</span></span>

```
{"Adapters": [
    {
        "Description": string,
        "HardwareAddress": string,
        "Index": int,
        "Name": string,
        "Type": string,
        "DHCP": {
            "LeaseExpires": int, (timestamp)
            "LeaseObtained": int, (timestamp)
            "Address": {
                "IpAddress": string,
                "Mask": string
            }
        },
        "WINS": {(WINS is optional)
            "Primary": {
                "IpAddress": string,
                "Mask": string
            },
            "Secondary": {
                "IpAddress": string,
                "Mask": string
            }
        },
        "Gateways": [{ (always 1+)
            "IpAddress": "10.82.128.1",
            "Mask": "255.255.255.255"
            },...
        ],
        "IpAddresses": [{ (always 1+)
            "IpAddress": "10.82.128.148",
            "Mask": "255.255.255.0"
            },...
        ]
    },...
]}
```

**<span data-ttu-id="da3fe-1428">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1428">Status code</span></span>**

<span data-ttu-id="da3fe-1429">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1429">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1430">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1430">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1431">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1431">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1432">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1432">200</span></span> | <span data-ttu-id="da3fe-1433">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1433">OK</span></span>
<span data-ttu-id="da3fe-1434">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1434">4XX</span></span> | <span data-ttu-id="da3fe-1435">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1435">Error codes</span></span>
<span data-ttu-id="da3fe-1436">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1436">5XX</span></span> | <span data-ttu-id="da3fe-1437">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1437">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1438">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1438">Available device families</span></span>**

* <span data-ttu-id="da3fe-1439">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1439">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1440">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1440">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1441">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1441">Xbox</span></span>
* <span data-ttu-id="da3fe-1442">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1442">HoloLens</span></span>
* <span data-ttu-id="da3fe-1443">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1443">IoT</span></span>

--
### <a name="enumerate-wireless-network-interfaces"></a><span data-ttu-id="da3fe-1444">ワイヤレス ネットワーク インターフェイスを列挙する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1444">Enumerate wireless network interfaces</span></span>

**<span data-ttu-id="da3fe-1445">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1445">Request</span></span>**

<span data-ttu-id="da3fe-1446">次の要求形式を使用して、利用可能なワイヤレス ネットワーク インターフェイスを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1446">You can enumerate the available wireless network interfaces by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1447">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1447">Method</span></span>      | <span data-ttu-id="da3fe-1448">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1448">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1449">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1449">GET</span></span> | <span data-ttu-id="da3fe-1450">/api/wifi/interfaces</span><span class="sxs-lookup"><span data-stu-id="da3fe-1450">/api/wifi/interfaces</span></span>
<br />

**<span data-ttu-id="da3fe-1451">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1451">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1452">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1452">None</span></span>

**<span data-ttu-id="da3fe-1453">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1453">Request headers</span></span>**

- <span data-ttu-id="da3fe-1454">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1454">None</span></span>

**<span data-ttu-id="da3fe-1455">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1455">Request body</span></span>**

- <span data-ttu-id="da3fe-1456">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1456">None</span></span>

**<span data-ttu-id="da3fe-1457">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1457">Response</span></span>**

<span data-ttu-id="da3fe-1458">次の形式の利用可能なワイヤレス インターフェイスと詳細の一覧。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1458">A list of the available wireless interfaces with details in the following format.</span></span>

``` 
{"Interfaces": [{
    "Description": string,
    "GUID": string (guid with curly brackets),
    "Index": int,
    "ProfilesList": [
        {
            "GroupPolicyProfile": bool,
            "Name": string, (Network currently connected to)
            "PerUserProfile": bool
        },...
    ]
    }
]}
```

**<span data-ttu-id="da3fe-1459">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1459">Status code</span></span>**

<span data-ttu-id="da3fe-1460">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1460">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1461">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1461">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1462">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1462">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1463">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1463">200</span></span> | <span data-ttu-id="da3fe-1464">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1464">OK</span></span>
<span data-ttu-id="da3fe-1465">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1465">4XX</span></span> | <span data-ttu-id="da3fe-1466">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1466">Error codes</span></span>
<span data-ttu-id="da3fe-1467">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1467">5XX</span></span> | <span data-ttu-id="da3fe-1468">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1468">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1469">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1469">Available device families</span></span>**

* <span data-ttu-id="da3fe-1470">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1470">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1471">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1471">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1472">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1472">Xbox</span></span>
* <span data-ttu-id="da3fe-1473">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1473">HoloLens</span></span>
* <span data-ttu-id="da3fe-1474">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1474">IoT</span></span>

---
### <a name="enumerate-wireless-networks"></a><span data-ttu-id="da3fe-1475">ワイヤレス ネットワークを列挙する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1475">Enumerate wireless networks</span></span>

**<span data-ttu-id="da3fe-1476">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1476">Request</span></span>**

<span data-ttu-id="da3fe-1477">次の要求形式を使用して、指定されたインターフェイスのワイヤレス ネットワークの一覧を列挙できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1477">You can enumerate the list of wireless networks on the specified interface by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1478">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1478">Method</span></span>      | <span data-ttu-id="da3fe-1479">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1479">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1480">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1480">GET</span></span> | <span data-ttu-id="da3fe-1481">/api/wifi/networks</span><span class="sxs-lookup"><span data-stu-id="da3fe-1481">/api/wifi/networks</span></span>
<br />

**<span data-ttu-id="da3fe-1482">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1482">URI parameters</span></span>**

<span data-ttu-id="da3fe-1483">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1483">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1484">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1484">URI parameter</span></span> | <span data-ttu-id="da3fe-1485">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1485">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1486">interface</span><span class="sxs-lookup"><span data-stu-id="da3fe-1486">interface</span></span>   | <span data-ttu-id="da3fe-1487">(**必須**) ワイヤレス ネットワークの検索に使用するネットワーク インターフェイスの GUID (括弧は不要)。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1487">(**required**) The GUID for the network interface to use to search for wireless networks, without brackets.</span></span> 
<br />
**<span data-ttu-id="da3fe-1488">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1488">Request headers</span></span>**

- <span data-ttu-id="da3fe-1489">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1489">None</span></span>

**<span data-ttu-id="da3fe-1490">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1490">Request body</span></span>**

- <span data-ttu-id="da3fe-1491">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1491">None</span></span>

**<span data-ttu-id="da3fe-1492">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1492">Response</span></span>**

<span data-ttu-id="da3fe-1493">指定された*インターフェイス*で見つかったワイヤレス ネットワークの一覧。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1493">The list of wireless networks found on the provided *interface*.</span></span> <span data-ttu-id="da3fe-1494">これには、ネットワークの詳細が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1494">This includes details for the networks in the following format.</span></span>

```
{"AvailableNetworks": [
    {
        "AlreadyConnected": bool,
        "AuthenticationAlgorithm": string, (WPA2, etc)
        "Channel": int,
        "CipherAlgorithm": string, (e.g. AES)
        "Connectable": int, (0 | 1)
        "InfrastructureType": string,
        "ProfileAvailable": bool,
        "ProfileName": string,
        "SSID": string,
        "SecurityEnabled": int, (0 | 1)
        "SignalQuality": int,
        "BSSID": [int,...],
        "PhysicalTypes": [string,...]
    },...
]}
```

**<span data-ttu-id="da3fe-1495">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1495">Status code</span></span>**

<span data-ttu-id="da3fe-1496">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1496">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1497">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1497">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1498">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1498">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1499">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1499">200</span></span> | <span data-ttu-id="da3fe-1500">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1500">OK</span></span>
<span data-ttu-id="da3fe-1501">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1501">4XX</span></span> | <span data-ttu-id="da3fe-1502">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1502">Error codes</span></span>
<span data-ttu-id="da3fe-1503">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1503">5XX</span></span> | <span data-ttu-id="da3fe-1504">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1504">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1505">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1505">Available device families</span></span>**

* <span data-ttu-id="da3fe-1506">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1506">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1507">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1507">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1508">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1508">Xbox</span></span>
* <span data-ttu-id="da3fe-1509">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1509">HoloLens</span></span>
* <span data-ttu-id="da3fe-1510">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1510">IoT</span></span>

---
### <a name="connect-and-disconnect-to-a-wi-fi-network"></a><span data-ttu-id="da3fe-1511">Wi-Fi ネットワークを接続および切断する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1511">Connect and disconnect to a Wi-Fi network.</span></span>

**<span data-ttu-id="da3fe-1512">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1512">Request</span></span>**

<span data-ttu-id="da3fe-1513">次の要求形式を使用して、Wi-Fi ネットワークを接続および切断できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1513">You can connect or disconnect to a Wi-Fi network by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1514">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1514">Method</span></span>      | <span data-ttu-id="da3fe-1515">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1515">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1516">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1516">POST</span></span> | <span data-ttu-id="da3fe-1517">/api/wifi/network</span><span class="sxs-lookup"><span data-stu-id="da3fe-1517">/api/wifi/network</span></span>
<br />

**<span data-ttu-id="da3fe-1518">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1518">URI parameters</span></span>**

<span data-ttu-id="da3fe-1519">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1519">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1520">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1520">URI parameter</span></span> | <span data-ttu-id="da3fe-1521">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1521">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1522">interface</span><span class="sxs-lookup"><span data-stu-id="da3fe-1522">interface</span></span>   | <span data-ttu-id="da3fe-1523">(**必須**) ネットワークへの接続に使用するネットワーク インターフェイスの GUID。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1523">(**required**) The GUID for the network interface you use to connect to the network.</span></span>
<span data-ttu-id="da3fe-1524">op</span><span class="sxs-lookup"><span data-stu-id="da3fe-1524">op</span></span>   | <span data-ttu-id="da3fe-1525">(**必須**) 実行するアクションを示します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1525">(**required**) Indicates the action to take.</span></span> <span data-ttu-id="da3fe-1526">設定可能な値は、connect または disconnect です。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1526">Possible values are connect or disconnect.</span></span>
<span data-ttu-id="da3fe-1527">ssid</span><span class="sxs-lookup"><span data-stu-id="da3fe-1527">ssid</span></span>   | <span data-ttu-id="da3fe-1528">(***op* == connect の場合は必須**) 接続先 SSID。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1528">(**required if *op* == connect**) The SSID to connect to.</span></span>
<span data-ttu-id="da3fe-1529">key</span><span class="sxs-lookup"><span data-stu-id="da3fe-1529">key</span></span>   | <span data-ttu-id="da3fe-1530">(***op* == connect で、ネットワークで認証が必要な場合は必須**) 共有キー。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1530">(**required if *op* == connect and network requires authentication**) The shared key.</span></span>
<span data-ttu-id="da3fe-1531">createprofile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1531">createprofile</span></span> | <span data-ttu-id="da3fe-1532">(**必要**) デバイスでネットワークのプロファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1532">(**required**) Create a profile for the network on the device.</span></span>  <span data-ttu-id="da3fe-1533">これにより、今後、デバイスはネットワークに自動接続されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1533">This will cause the device to auto-connect to the network in the future.</span></span> <span data-ttu-id="da3fe-1534">**yes** または **no** を指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1534">This can be **yes** or **no**.</span></span> 

**<span data-ttu-id="da3fe-1535">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1535">Request headers</span></span>**

- <span data-ttu-id="da3fe-1536">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1536">None</span></span>

**<span data-ttu-id="da3fe-1537">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1537">Request body</span></span>**

- <span data-ttu-id="da3fe-1538">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1538">None</span></span>

**<span data-ttu-id="da3fe-1539">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1539">Response</span></span>**

**<span data-ttu-id="da3fe-1540">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1540">Status code</span></span>**

<span data-ttu-id="da3fe-1541">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1541">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1542">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1542">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1543">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1543">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1544">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1544">200</span></span> | <span data-ttu-id="da3fe-1545">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1545">OK</span></span>
<br />
**<span data-ttu-id="da3fe-1546">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1546">Available device families</span></span>**

* <span data-ttu-id="da3fe-1547">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1547">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1548">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1548">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1549">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1549">Xbox</span></span>
* <span data-ttu-id="da3fe-1550">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1550">HoloLens</span></span>
* <span data-ttu-id="da3fe-1551">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1551">IoT</span></span>

---
### <a name="delete-a-wi-fi-profile"></a><span data-ttu-id="da3fe-1552">Wi-Fi のプロファイルを削除する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1552">Delete a Wi-Fi profile</span></span>

**<span data-ttu-id="da3fe-1553">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1553">Request</span></span>**

<span data-ttu-id="da3fe-1554">次の要求形式を使用して、特定のインターフェイス上のネットワークに関連付けられたプロファイルを削除できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1554">You can delete a profile associated with a network on a specific interface by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1555">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1555">Method</span></span>      | <span data-ttu-id="da3fe-1556">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1556">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1557">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-1557">DELETE</span></span> | <span data-ttu-id="da3fe-1558">/api/wifi/network</span><span class="sxs-lookup"><span data-stu-id="da3fe-1558">/api/wifi/network</span></span>
<br />

**<span data-ttu-id="da3fe-1559">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1559">URI parameters</span></span>**

<span data-ttu-id="da3fe-1560">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1560">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1561">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1561">URI parameter</span></span> | <span data-ttu-id="da3fe-1562">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1562">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1563">interface</span><span class="sxs-lookup"><span data-stu-id="da3fe-1563">interface</span></span>   | <span data-ttu-id="da3fe-1564">(**必須**) 削除するプロファイルに関連付けられたネットワーク インターフェイスの GUID。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1564">(**required**) The GUID for the network interface associated with the profile to delete.</span></span>
<span data-ttu-id="da3fe-1565">profile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1565">profile</span></span>   | <span data-ttu-id="da3fe-1566">(**必須**) 削除するプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1566">(**required**) The name of the profile to delete.</span></span>
<br />
**<span data-ttu-id="da3fe-1567">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1567">Request headers</span></span>**

- <span data-ttu-id="da3fe-1568">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1568">None</span></span>

**<span data-ttu-id="da3fe-1569">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1569">Request body</span></span>**

- <span data-ttu-id="da3fe-1570">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1570">None</span></span>

**<span data-ttu-id="da3fe-1571">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1571">Response</span></span>**

**<span data-ttu-id="da3fe-1572">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1572">Status code</span></span>**

<span data-ttu-id="da3fe-1573">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1573">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1574">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1574">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1575">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1575">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1576">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1576">200</span></span> | <span data-ttu-id="da3fe-1577">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1577">OK</span></span>
<br />
**<span data-ttu-id="da3fe-1578">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1578">Available device families</span></span>**

* <span data-ttu-id="da3fe-1579">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1579">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1580">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1580">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1581">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-1581">Xbox</span></span>
* <span data-ttu-id="da3fe-1582">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1582">HoloLens</span></span>
* <span data-ttu-id="da3fe-1583">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1583">IoT</span></span>

---
## Windows Error Reporting (WER)
---
### <a name="download-a-windows-error-reporting-wer-file"></a><span data-ttu-id="da3fe-1584">Windows エラー報告 (WER) ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="da3fe-1584">Download a Windows error reporting (WER) file</span></span>

**<span data-ttu-id="da3fe-1585">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1585">Request</span></span>**

<span data-ttu-id="da3fe-1586">次の要求形式を使用して、WER 関連のファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1586">You can download a WER-related file by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1587">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1587">Method</span></span>      | <span data-ttu-id="da3fe-1588">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1588">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1589">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1589">GET</span></span> | <span data-ttu-id="da3fe-1590">/api/wer/report/file</span><span class="sxs-lookup"><span data-stu-id="da3fe-1590">/api/wer/report/file</span></span>
<br />

**<span data-ttu-id="da3fe-1591">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1591">URI parameters</span></span>**

<span data-ttu-id="da3fe-1592">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1592">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1593">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1593">URI parameter</span></span> | <span data-ttu-id="da3fe-1594">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1594">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1595">user</span><span class="sxs-lookup"><span data-stu-id="da3fe-1595">user</span></span>   | <span data-ttu-id="da3fe-1596">(**必須**) レポートに関連付けられたユーザー名。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1596">(**required**) The user name associated with the report.</span></span>
<span data-ttu-id="da3fe-1597">type</span><span class="sxs-lookup"><span data-stu-id="da3fe-1597">type</span></span>   | <span data-ttu-id="da3fe-1598">(**必須**) レポートの種類。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1598">(**required**) The type of report.</span></span> <span data-ttu-id="da3fe-1599">これは **queried** または **archived** のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1599">This can be either **queried** or **archived**.</span></span>
<span data-ttu-id="da3fe-1600">name</span><span class="sxs-lookup"><span data-stu-id="da3fe-1600">name</span></span>   | <span data-ttu-id="da3fe-1601">(**必須**) レポートの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1601">(**required**) The name of the report.</span></span> <span data-ttu-id="da3fe-1602">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1602">This should be base64 encoded.</span></span> 
<span data-ttu-id="da3fe-1603">file</span><span class="sxs-lookup"><span data-stu-id="da3fe-1603">file</span></span>   | <span data-ttu-id="da3fe-1604">(**必須**) レポートからダウンロードするファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1604">(**required**) The name of the file to download from the report.</span></span> <span data-ttu-id="da3fe-1605">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1605">This should be base64 encoded.</span></span> 
<br />
**<span data-ttu-id="da3fe-1606">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1606">Request headers</span></span>**

- <span data-ttu-id="da3fe-1607">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1607">None</span></span>

**<span data-ttu-id="da3fe-1608">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1608">Request body</span></span>**

- <span data-ttu-id="da3fe-1609">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1609">None</span></span>

**<span data-ttu-id="da3fe-1610">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1610">Response</span></span>**

- <span data-ttu-id="da3fe-1611">応答には、要求したファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1611">Response contains the requested file.</span></span> 

**<span data-ttu-id="da3fe-1612">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1612">Status code</span></span>**

<span data-ttu-id="da3fe-1613">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1613">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1614">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1614">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1615">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1615">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1616">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1616">200</span></span> | <span data-ttu-id="da3fe-1617">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1617">OK</span></span>
<span data-ttu-id="da3fe-1618">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1618">4XX</span></span> | <span data-ttu-id="da3fe-1619">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1619">Error codes</span></span>
<span data-ttu-id="da3fe-1620">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1620">5XX</span></span> | <span data-ttu-id="da3fe-1621">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1621">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1622">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1622">Available device families</span></span>**

* <span data-ttu-id="da3fe-1623">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1623">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1624">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1624">HoloLens</span></span>
* <span data-ttu-id="da3fe-1625">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1625">IoT</span></span>

---
### <a name="enumerate-files-in-a-windows-error-reporting-wer-report"></a><span data-ttu-id="da3fe-1626">Windows エラー報告 (WER) レポート内のファイルを列挙する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1626">Enumerate files in a Windows error reporting (WER) report</span></span>

**<span data-ttu-id="da3fe-1627">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1627">Request</span></span>**

<span data-ttu-id="da3fe-1628">次の要求形式を使用して、WER レポート内のファイルを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1628">You can enumerate the files in a WER report by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1629">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1629">Method</span></span>      | <span data-ttu-id="da3fe-1630">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1630">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1631">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1631">GET</span></span> | <span data-ttu-id="da3fe-1632">/api/wer/report/files</span><span class="sxs-lookup"><span data-stu-id="da3fe-1632">/api/wer/report/files</span></span>
<br />

**<span data-ttu-id="da3fe-1633">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1633">URI parameters</span></span>**

<span data-ttu-id="da3fe-1634">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1634">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1635">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1635">URI parameter</span></span> | <span data-ttu-id="da3fe-1636">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1636">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1637">user</span><span class="sxs-lookup"><span data-stu-id="da3fe-1637">user</span></span>   | <span data-ttu-id="da3fe-1638">(**必須**) レポートに関連付けられたユーザー。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1638">(**required**) The user associated with the report.</span></span>
<span data-ttu-id="da3fe-1639">type</span><span class="sxs-lookup"><span data-stu-id="da3fe-1639">type</span></span>   | <span data-ttu-id="da3fe-1640">(**必須**) レポートの種類。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1640">(**required**) The type of report.</span></span> <span data-ttu-id="da3fe-1641">これは **queried** または **archived** のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1641">This can be either **queried** or **archived**.</span></span>
<span data-ttu-id="da3fe-1642">name</span><span class="sxs-lookup"><span data-stu-id="da3fe-1642">name</span></span>   | <span data-ttu-id="da3fe-1643">(**必須**) レポートの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1643">(**required**) The name of the report.</span></span> <span data-ttu-id="da3fe-1644">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1644">This should be base64 encoded.</span></span> 
<br />
**<span data-ttu-id="da3fe-1645">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1645">Request headers</span></span>**

- <span data-ttu-id="da3fe-1646">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1646">None</span></span>

**<span data-ttu-id="da3fe-1647">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1647">Request body</span></span>**

```
{"Files": [
    {
        "Name": string, (Filename, not base64 encoded)
        "Size": int (bytes)
    },...
]}
```

**<span data-ttu-id="da3fe-1648">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1648">Response</span></span>**

**<span data-ttu-id="da3fe-1649">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1649">Status code</span></span>**

<span data-ttu-id="da3fe-1650">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1650">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1651">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1651">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1652">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1652">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1653">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1653">200</span></span> | <span data-ttu-id="da3fe-1654">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1654">OK</span></span>
<span data-ttu-id="da3fe-1655">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1655">4XX</span></span> | <span data-ttu-id="da3fe-1656">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1656">Error codes</span></span>
<span data-ttu-id="da3fe-1657">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1657">5XX</span></span> | <span data-ttu-id="da3fe-1658">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1658">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1659">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1659">Available device families</span></span>**

* <span data-ttu-id="da3fe-1660">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1660">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1661">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1661">HoloLens</span></span>
* <span data-ttu-id="da3fe-1662">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1662">IoT</span></span>

---
### <a name="list-the-windows-error-reporting-wer-reports"></a><span data-ttu-id="da3fe-1663">Windows エラー報告 (WER) レポートを一覧表示する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1663">List the Windows error reporting (WER) reports</span></span>

**<span data-ttu-id="da3fe-1664">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1664">Request</span></span>**

<span data-ttu-id="da3fe-1665">次の要求形式を使用して、WER レポートを取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1665">You can get the WER reports by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1666">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1666">Method</span></span>      | <span data-ttu-id="da3fe-1667">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1667">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1668">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1668">GET</span></span> | <span data-ttu-id="da3fe-1669">/api/wer/reports</span><span class="sxs-lookup"><span data-stu-id="da3fe-1669">/api/wer/reports</span></span>
<br />

**<span data-ttu-id="da3fe-1670">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1670">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1671">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1671">None</span></span>

**<span data-ttu-id="da3fe-1672">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1672">Request headers</span></span>**

- <span data-ttu-id="da3fe-1673">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1673">None</span></span>

**<span data-ttu-id="da3fe-1674">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1674">Request body</span></span>**

- <span data-ttu-id="da3fe-1675">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1675">None</span></span>

**<span data-ttu-id="da3fe-1676">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1676">Response</span></span>**

<span data-ttu-id="da3fe-1677">WER 報告の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1677">The WER reports in the following format.</span></span>

```
{"WerReports": [
    {
        "User": string,
        "Reports": [
            {
                "CreationTime": int,
                "Name": string, (not base64 encoded)
                "Type": string ("Queue" or "Archive")
            },
    },...
]}
```

**<span data-ttu-id="da3fe-1678">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1678">Status code</span></span>**

<span data-ttu-id="da3fe-1679">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1679">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1680">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1680">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1681">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1681">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1682">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1682">200</span></span> | <span data-ttu-id="da3fe-1683">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1683">OK</span></span>
<span data-ttu-id="da3fe-1684">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1684">4XX</span></span> | <span data-ttu-id="da3fe-1685">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1685">Error codes</span></span>
<span data-ttu-id="da3fe-1686">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1686">5XX</span></span> | <span data-ttu-id="da3fe-1687">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1687">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1688">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1688">Available device families</span></span>**

* <span data-ttu-id="da3fe-1689">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1689">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1690">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1690">HoloLens</span></span>
* <span data-ttu-id="da3fe-1691">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1691">IoT</span></span>

---
## Windows Performance Recorder (WPR) 
---
### <a name="start-tracing-with-a-custom-profile"></a><span data-ttu-id="da3fe-1692">カスタム プロファイルを使用してトレースを開始する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1692">Start tracing with a custom profile</span></span>

**<span data-ttu-id="da3fe-1693">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1693">Request</span></span>**

<span data-ttu-id="da3fe-1694">次の要求形式を使用して、WPR プロファイルをアップロードし、そのプロファイルを使用してトレースを開始できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1694">You can upload a WPR profile and start tracing using that profile by using the following request format.</span></span>  <span data-ttu-id="da3fe-1695">一度に実行できるトレースは 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1695">Only one trace can run at a time.</span></span> <span data-ttu-id="da3fe-1696">プロファイルはデバイス上に残りません。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1696">The profile will not remain on the device.</span></span> 
 
<span data-ttu-id="da3fe-1697">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1697">Method</span></span>      | <span data-ttu-id="da3fe-1698">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1698">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1699">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1699">POST</span></span> | <span data-ttu-id="da3fe-1700">/api/wpr/customtrace</span><span class="sxs-lookup"><span data-stu-id="da3fe-1700">/api/wpr/customtrace</span></span>
<br />

**<span data-ttu-id="da3fe-1701">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1701">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1702">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1702">None</span></span>

**<span data-ttu-id="da3fe-1703">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1703">Request headers</span></span>**

- <span data-ttu-id="da3fe-1704">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1704">None</span></span>

**<span data-ttu-id="da3fe-1705">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1705">Request body</span></span>**

- <span data-ttu-id="da3fe-1706">カスタム WPR プロファイルが含まれる、原則に従ったマルチパートの http 本文。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1706">A multi-part conforming http body that contains the custom WPR profile.</span></span>

**<span data-ttu-id="da3fe-1707">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1707">Response</span></span>**

<span data-ttu-id="da3fe-1708">WPR セッション状態の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1708">The WPR session status in the following format.</span></span>

```
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

**<span data-ttu-id="da3fe-1709">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1709">Status code</span></span>**

<span data-ttu-id="da3fe-1710">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1710">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1711">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1711">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1712">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1712">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1713">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1713">200</span></span> | <span data-ttu-id="da3fe-1714">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1714">OK</span></span>
<span data-ttu-id="da3fe-1715">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1715">4XX</span></span> | <span data-ttu-id="da3fe-1716">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1716">Error codes</span></span>
<span data-ttu-id="da3fe-1717">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1717">5XX</span></span> | <span data-ttu-id="da3fe-1718">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1718">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1719">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1719">Available device families</span></span>**

* <span data-ttu-id="da3fe-1720">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1720">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1721">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1721">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1722">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1722">HoloLens</span></span>
* <span data-ttu-id="da3fe-1723">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1723">IoT</span></span>

---
### <a name="start-a-boot-performance-tracing-session"></a><span data-ttu-id="da3fe-1724">起動パフォーマンス トレース セッションを開始する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1724">Start a boot performance tracing session</span></span>

**<span data-ttu-id="da3fe-1725">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1725">Request</span></span>**

<span data-ttu-id="da3fe-1726">次の要求形式を使用して、WPR の起動トレース セッションを開始できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1726">You can start a boot WPR tracing session by using the following request format.</span></span> <span data-ttu-id="da3fe-1727">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1727">This is also known as a performance tracing session.</span></span>
 
<span data-ttu-id="da3fe-1728">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1728">Method</span></span>      | <span data-ttu-id="da3fe-1729">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1729">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1730">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1730">POST</span></span> | <span data-ttu-id="da3fe-1731">/api/wpr/boottrace</span><span class="sxs-lookup"><span data-stu-id="da3fe-1731">/api/wpr/boottrace</span></span>
<br />

**<span data-ttu-id="da3fe-1732">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1732">URI parameters</span></span>**

<span data-ttu-id="da3fe-1733">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1733">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1734">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1734">URI parameter</span></span> | <span data-ttu-id="da3fe-1735">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1735">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1736">profile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1736">profile</span></span>   | <span data-ttu-id="da3fe-1737">(**必須**) このパラメーターは起動時に必要です。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1737">(**required**) This parameter is required on start.</span></span> <span data-ttu-id="da3fe-1738">パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1738">The name of the profile that should start a performance tracing session.</span></span> <span data-ttu-id="da3fe-1739">指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1739">The possible profiles are stored in perfprofiles/profiles.json.</span></span>
<br />
**<span data-ttu-id="da3fe-1740">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1740">Request headers</span></span>**

- <span data-ttu-id="da3fe-1741">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1741">None</span></span>

**<span data-ttu-id="da3fe-1742">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1742">Request body</span></span>**

- <span data-ttu-id="da3fe-1743">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1743">None</span></span>

**<span data-ttu-id="da3fe-1744">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1744">Response</span></span>**

<span data-ttu-id="da3fe-1745">この API は、開始時に次の形式で WPR セッション状態を返します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1745">On start, this API returns the WPR session status in the following format.</span></span>

```
{
    "SessionType": string, (Running or Idle) 
    "State": string (boot)
}
```

**<span data-ttu-id="da3fe-1746">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1746">Status code</span></span>**

<span data-ttu-id="da3fe-1747">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1747">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1748">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1748">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1749">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1749">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1750">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1750">200</span></span> | <span data-ttu-id="da3fe-1751">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1751">OK</span></span>
<span data-ttu-id="da3fe-1752">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1752">4XX</span></span> | <span data-ttu-id="da3fe-1753">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1753">Error codes</span></span>
<span data-ttu-id="da3fe-1754">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1754">5XX</span></span> | <span data-ttu-id="da3fe-1755">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1755">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1756">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1756">Available device families</span></span>**

* <span data-ttu-id="da3fe-1757">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1757">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1758">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1758">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1759">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1759">HoloLens</span></span>
* <span data-ttu-id="da3fe-1760">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1760">IoT</span></span>

---
### <a name="stop-a-boot-performance-tracing-session"></a><span data-ttu-id="da3fe-1761">起動パフォーマンス トレース セッションを停止する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1761">Stop a boot performance tracing session</span></span>

**<span data-ttu-id="da3fe-1762">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1762">Request</span></span>**

<span data-ttu-id="da3fe-1763">次の要求形式を使用して、WPR の起動トレース セッションを停止できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1763">You can stop a boot WPR tracing session by using the following request format.</span></span> <span data-ttu-id="da3fe-1764">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1764">This is also known as a performance tracing session.</span></span>
 
<span data-ttu-id="da3fe-1765">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1765">Method</span></span>      | <span data-ttu-id="da3fe-1766">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1766">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1767">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1767">GET</span></span> | <span data-ttu-id="da3fe-1768">/api/wpr/boottrace</span><span class="sxs-lookup"><span data-stu-id="da3fe-1768">/api/wpr/boottrace</span></span>
<br />

**<span data-ttu-id="da3fe-1769">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1769">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1770">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1770">None</span></span>

**<span data-ttu-id="da3fe-1771">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1771">Request headers</span></span>**

- <span data-ttu-id="da3fe-1772">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1772">None</span></span>

**<span data-ttu-id="da3fe-1773">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1773">Request body</span></span>**

- <span data-ttu-id="da3fe-1774">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1774">None</span></span>

**<span data-ttu-id="da3fe-1775">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1775">Response</span></span>**

-  <span data-ttu-id="da3fe-1776">なし。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1776">None.</span></span>  <span data-ttu-id="da3fe-1777">**注:** これは時間のかかる処理です。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1777">**Note:** This is a long running operation.</span></span>  <span data-ttu-id="da3fe-1778">ETL のディスクへの書き込みが終了すると、制御が戻ります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1778">It will return when the ETL is finished writing to disk.</span></span>

**<span data-ttu-id="da3fe-1779">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1779">Status code</span></span>**

<span data-ttu-id="da3fe-1780">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1780">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1781">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1781">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1782">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1782">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1783">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1783">200</span></span> | <span data-ttu-id="da3fe-1784">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1784">OK</span></span>
<span data-ttu-id="da3fe-1785">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1785">4XX</span></span> | <span data-ttu-id="da3fe-1786">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1786">Error codes</span></span>
<span data-ttu-id="da3fe-1787">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1787">5XX</span></span> | <span data-ttu-id="da3fe-1788">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1788">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1789">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1789">Available device families</span></span>**

* <span data-ttu-id="da3fe-1790">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1790">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1791">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1791">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1792">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1792">HoloLens</span></span>
* <span data-ttu-id="da3fe-1793">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1793">IoT</span></span>

---
### <a name="start-a-performance-tracing-session"></a><span data-ttu-id="da3fe-1794">パフォーマンス トレース セッションを開始する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1794">Start a performance tracing session</span></span>

**<span data-ttu-id="da3fe-1795">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1795">Request</span></span>**

<span data-ttu-id="da3fe-1796">次の要求形式を使用して、WPR のトレース セッションを開始できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1796">You can start a WPR tracing session by using the following request format.</span></span> <span data-ttu-id="da3fe-1797">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1797">This is also known as a performance tracing session.</span></span>  <span data-ttu-id="da3fe-1798">一度に実行できるトレースは 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1798">Only one trace can run at a time.</span></span> 
 
<span data-ttu-id="da3fe-1799">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1799">Method</span></span>      | <span data-ttu-id="da3fe-1800">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1800">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1801">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-1801">POST</span></span> | <span data-ttu-id="da3fe-1802">/api/wpr/trace</span><span class="sxs-lookup"><span data-stu-id="da3fe-1802">/api/wpr/trace</span></span>
<br />

**<span data-ttu-id="da3fe-1803">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1803">URI parameters</span></span>**

<span data-ttu-id="da3fe-1804">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1804">You can specify the following additional parameters on the request URI:</span></span>

<span data-ttu-id="da3fe-1805">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1805">URI parameter</span></span> | <span data-ttu-id="da3fe-1806">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1806">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1807">profile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1807">profile</span></span>   | <span data-ttu-id="da3fe-1808">(**必須**) パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1808">(**required**) The name of the profile that should start a performance tracing session.</span></span> <span data-ttu-id="da3fe-1809">指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1809">The possible profiles are stored in perfprofiles/profiles.json.</span></span>
<br />
**<span data-ttu-id="da3fe-1810">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1810">Request headers</span></span>**

- <span data-ttu-id="da3fe-1811">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1811">None</span></span>

**<span data-ttu-id="da3fe-1812">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1812">Request body</span></span>**

- <span data-ttu-id="da3fe-1813">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1813">None</span></span>

**<span data-ttu-id="da3fe-1814">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1814">Response</span></span>**

<span data-ttu-id="da3fe-1815">この API は、開始時に次の形式で WPR セッション状態を返します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1815">On start, this API returns the WPR session status in the following format.</span></span>

```
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal)
}
```

**<span data-ttu-id="da3fe-1816">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1816">Status code</span></span>**

<span data-ttu-id="da3fe-1817">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1817">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1818">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1818">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1819">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1819">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1820">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1820">200</span></span> | <span data-ttu-id="da3fe-1821">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1821">OK</span></span>
<span data-ttu-id="da3fe-1822">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1822">4XX</span></span> | <span data-ttu-id="da3fe-1823">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1823">Error codes</span></span>
<span data-ttu-id="da3fe-1824">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1824">5XX</span></span> | <span data-ttu-id="da3fe-1825">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1825">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1826">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1826">Available device families</span></span>**

* <span data-ttu-id="da3fe-1827">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1827">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1828">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1828">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1829">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1829">HoloLens</span></span>
* <span data-ttu-id="da3fe-1830">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1830">IoT</span></span>

---
### <a name="stop-a-performance-tracing-session"></a><span data-ttu-id="da3fe-1831">パフォーマンスのトレース セッションを停止する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1831">Stop a performance tracing session</span></span>

**<span data-ttu-id="da3fe-1832">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1832">Request</span></span>**

<span data-ttu-id="da3fe-1833">次の要求形式を使用して、WPR のトレース セッションを停止できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1833">You can stop a WPR tracing session by using the following request format.</span></span> <span data-ttu-id="da3fe-1834">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1834">This is also known as a performance tracing session.</span></span>
 
<span data-ttu-id="da3fe-1835">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1835">Method</span></span>      | <span data-ttu-id="da3fe-1836">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1836">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1837">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1837">GET</span></span> | <span data-ttu-id="da3fe-1838">/api/wpr/trace</span><span class="sxs-lookup"><span data-stu-id="da3fe-1838">/api/wpr/trace</span></span>
<br />

**<span data-ttu-id="da3fe-1839">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1839">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1840">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1840">None</span></span>

**<span data-ttu-id="da3fe-1841">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1841">Request headers</span></span>**

- <span data-ttu-id="da3fe-1842">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1842">None</span></span>

**<span data-ttu-id="da3fe-1843">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1843">Request body</span></span>**

- <span data-ttu-id="da3fe-1844">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1844">None</span></span>

**<span data-ttu-id="da3fe-1845">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1845">Response</span></span>**

- <span data-ttu-id="da3fe-1846">なし。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1846">None.</span></span>  <span data-ttu-id="da3fe-1847">**注:** これは時間のかかる処理です。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1847">**Note:** This is a long running operation.</span></span>  <span data-ttu-id="da3fe-1848">ETL のディスクへの書き込みが終了すると、制御が戻ります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1848">It will return when the ETL is finished writing to disk.</span></span>  

**<span data-ttu-id="da3fe-1849">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1849">Status code</span></span>**

<span data-ttu-id="da3fe-1850">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1850">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1851">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1851">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1852">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1852">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1853">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1853">200</span></span> | <span data-ttu-id="da3fe-1854">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1854">OK</span></span>
<span data-ttu-id="da3fe-1855">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1855">4XX</span></span> | <span data-ttu-id="da3fe-1856">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1856">Error codes</span></span>
<span data-ttu-id="da3fe-1857">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1857">5XX</span></span> | <span data-ttu-id="da3fe-1858">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1858">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1859">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1859">Available device families</span></span>**

* <span data-ttu-id="da3fe-1860">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1860">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1861">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1861">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1862">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1862">HoloLens</span></span>
* <span data-ttu-id="da3fe-1863">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1863">IoT</span></span>

---
### <a name="retrieve-the-status-of-a-tracing-session"></a><span data-ttu-id="da3fe-1864">トレース セッションの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1864">Retrieve the status of a tracing session</span></span>

**<span data-ttu-id="da3fe-1865">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1865">Request</span></span>**

<span data-ttu-id="da3fe-1866">次の要求形式を使用して、現在の WPR セッションの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1866">You can retrieve the status of the current WPR session by using the following request format.</span></span>
 
<span data-ttu-id="da3fe-1867">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1867">Method</span></span>      | <span data-ttu-id="da3fe-1868">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1868">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1869">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1869">GET</span></span> | <span data-ttu-id="da3fe-1870">/api/wpr/status</span><span class="sxs-lookup"><span data-stu-id="da3fe-1870">/api/wpr/status</span></span>
<br />

**<span data-ttu-id="da3fe-1871">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1871">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1872">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1872">None</span></span>

**<span data-ttu-id="da3fe-1873">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1873">Request headers</span></span>**

- <span data-ttu-id="da3fe-1874">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1874">None</span></span>

**<span data-ttu-id="da3fe-1875">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1875">Request body</span></span>**

- <span data-ttu-id="da3fe-1876">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1876">None</span></span>

**<span data-ttu-id="da3fe-1877">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1877">Response</span></span>**

<span data-ttu-id="da3fe-1878">WPR トレース セッションの状態の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1878">The status of the WPR tracing session in the following format.</span></span>

```
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

**<span data-ttu-id="da3fe-1879">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1879">Status code</span></span>**

<span data-ttu-id="da3fe-1880">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1880">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1881">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1881">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1882">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1882">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1883">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1883">200</span></span> | <span data-ttu-id="da3fe-1884">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1884">OK</span></span>
<span data-ttu-id="da3fe-1885">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1885">4XX</span></span> | <span data-ttu-id="da3fe-1886">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1886">Error codes</span></span>
<span data-ttu-id="da3fe-1887">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1887">5XX</span></span> | <span data-ttu-id="da3fe-1888">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1888">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1889">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1889">Available device families</span></span>**

* <span data-ttu-id="da3fe-1890">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1890">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1891">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1891">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1892">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1892">HoloLens</span></span>
* <span data-ttu-id="da3fe-1893">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1893">IoT</span></span>

---
### <a name="list-completed-tracing-sessions-etls"></a><span data-ttu-id="da3fe-1894">完了したトレース セッション (ETL) を一覧表示する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1894">List completed tracing sessions (ETLs)</span></span>

**<span data-ttu-id="da3fe-1895">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1895">Request</span></span>**

<span data-ttu-id="da3fe-1896">次の要求形式を使用して、デバイス上の ETL トレースの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1896">You can get a listing of ETL traces on the device using the following request format.</span></span> 

<span data-ttu-id="da3fe-1897">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1897">Method</span></span>      | <span data-ttu-id="da3fe-1898">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1898">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1899">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1899">GET</span></span> | <span data-ttu-id="da3fe-1900">/api/wpr/tracefiles</span><span class="sxs-lookup"><span data-stu-id="da3fe-1900">/api/wpr/tracefiles</span></span>
<br />

**<span data-ttu-id="da3fe-1901">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1901">URI parameters</span></span>**

- <span data-ttu-id="da3fe-1902">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1902">None</span></span>

**<span data-ttu-id="da3fe-1903">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1903">Request headers</span></span>**

- <span data-ttu-id="da3fe-1904">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1904">None</span></span>

**<span data-ttu-id="da3fe-1905">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1905">Request body</span></span>**

- <span data-ttu-id="da3fe-1906">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1906">None</span></span>

**<span data-ttu-id="da3fe-1907">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1907">Response</span></span>**

<span data-ttu-id="da3fe-1908">完了したトレース セッションの一覧は次の形式で提供されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1908">The listing of completed tracing sessions is provided in the following format.</span></span>

```
{"Items": [{
    "CurrentDir": string (filepath),
    "DateCreated": int (File CreationTime),
    "FileSize": int (bytes),
    "Id": string (filename),
    "Name": string (filename),
    "SubPath": string (filepath),
    "Type": int
}]}
```

**<span data-ttu-id="da3fe-1909">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1909">Status code</span></span>**

<span data-ttu-id="da3fe-1910">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1910">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1911">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1911">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1912">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1912">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1913">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1913">200</span></span> | <span data-ttu-id="da3fe-1914">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1914">OK</span></span>
<span data-ttu-id="da3fe-1915">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1915">4XX</span></span> | <span data-ttu-id="da3fe-1916">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1916">Error codes</span></span>
<span data-ttu-id="da3fe-1917">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1917">5XX</span></span> | <span data-ttu-id="da3fe-1918">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1918">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1919">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1919">Available device families</span></span>**

* <span data-ttu-id="da3fe-1920">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1920">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1921">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1921">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1922">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1922">HoloLens</span></span>
* <span data-ttu-id="da3fe-1923">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1923">IoT</span></span>

---
### <a name="download-a-tracing-session-etl"></a><span data-ttu-id="da3fe-1924">トレース セッション (ETL) をダウンロードする</span><span class="sxs-lookup"><span data-stu-id="da3fe-1924">Download a tracing session (ETL)</span></span>

**<span data-ttu-id="da3fe-1925">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1925">Request</span></span>**

<span data-ttu-id="da3fe-1926">次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) をダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1926">You can download a tracefile (boot trace or user-mode trace) using the following request format.</span></span> 

<span data-ttu-id="da3fe-1927">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1927">Method</span></span>      | <span data-ttu-id="da3fe-1928">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1928">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1929">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-1929">GET</span></span> | <span data-ttu-id="da3fe-1930">/api/wpr/tracefile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1930">/api/wpr/tracefile</span></span>
<br />

**<span data-ttu-id="da3fe-1931">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1931">URI parameters</span></span>**

<span data-ttu-id="da3fe-1932">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1932">You can specify the following additional parameter on the request URI:</span></span>

<span data-ttu-id="da3fe-1933">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1933">URI parameter</span></span> | <span data-ttu-id="da3fe-1934">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1934">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1935">filename</span><span class="sxs-lookup"><span data-stu-id="da3fe-1935">filename</span></span>   | <span data-ttu-id="da3fe-1936">(**必須**) ダウンロードする ETL トレースの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1936">(**required**) The name of the ETL trace to download.</span></span>  <span data-ttu-id="da3fe-1937">これらは /api/wpr/tracefiles にあります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1937">These can be found in /api/wpr/tracefiles</span></span>

**<span data-ttu-id="da3fe-1938">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1938">Request headers</span></span>**

- <span data-ttu-id="da3fe-1939">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1939">None</span></span>

**<span data-ttu-id="da3fe-1940">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1940">Request body</span></span>**

- <span data-ttu-id="da3fe-1941">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1941">None</span></span>

**<span data-ttu-id="da3fe-1942">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1942">Response</span></span>**

- <span data-ttu-id="da3fe-1943">トレース ETL ファイルを返します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1943">Returns the trace ETL file.</span></span>

**<span data-ttu-id="da3fe-1944">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1944">Status code</span></span>**

<span data-ttu-id="da3fe-1945">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1945">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1946">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1946">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1947">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1947">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1948">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1948">200</span></span> | <span data-ttu-id="da3fe-1949">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1949">OK</span></span>
<span data-ttu-id="da3fe-1950">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1950">4XX</span></span> | <span data-ttu-id="da3fe-1951">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1951">Error codes</span></span>
<span data-ttu-id="da3fe-1952">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1952">5XX</span></span> | <span data-ttu-id="da3fe-1953">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1953">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1954">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1954">Available device families</span></span>**

* <span data-ttu-id="da3fe-1955">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1955">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1956">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-1956">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1957">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1957">HoloLens</span></span>
* <span data-ttu-id="da3fe-1958">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1958">IoT</span></span>

---
### <a name="delete-a-tracing-session-etl"></a><span data-ttu-id="da3fe-1959">トレース セッション (ETL) を削除する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1959">Delete a tracing session (ETL)</span></span>

**<span data-ttu-id="da3fe-1960">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1960">Request</span></span>**

<span data-ttu-id="da3fe-1961">次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) を削除できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1961">You can delete a tracefile (boot trace or user-mode trace) using the following request format.</span></span> 

<span data-ttu-id="da3fe-1962">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1962">Method</span></span>      | <span data-ttu-id="da3fe-1963">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1963">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1964">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-1964">DELETE</span></span> | <span data-ttu-id="da3fe-1965">/api/wpr/tracefile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1965">/api/wpr/tracefile</span></span>
<br />

**<span data-ttu-id="da3fe-1966">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1966">URI parameters</span></span>**

<span data-ttu-id="da3fe-1967">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1967">You can specify the following additional parameter on the request URI:</span></span>

<span data-ttu-id="da3fe-1968">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-1968">URI parameter</span></span> | <span data-ttu-id="da3fe-1969">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1969">Description</span></span>
:---          | :---
<span data-ttu-id="da3fe-1970">filename</span><span class="sxs-lookup"><span data-stu-id="da3fe-1970">filename</span></span>   | <span data-ttu-id="da3fe-1971">(**必須**) 削除する ETL トレースの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1971">(**required**) The name of the ETL trace to delete.</span></span>  <span data-ttu-id="da3fe-1972">これらは /api/wpr/tracefiles にあります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1972">These can be found in /api/wpr/tracefiles</span></span>

**<span data-ttu-id="da3fe-1973">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-1973">Request headers</span></span>**

- <span data-ttu-id="da3fe-1974">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1974">None</span></span>

**<span data-ttu-id="da3fe-1975">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-1975">Request body</span></span>**

- <span data-ttu-id="da3fe-1976">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-1976">None</span></span>

**<span data-ttu-id="da3fe-1977">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-1977">Response</span></span>**

- <span data-ttu-id="da3fe-1978">トレース ETL ファイルを返します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1978">Returns the trace ETL file.</span></span>

**<span data-ttu-id="da3fe-1979">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1979">Status code</span></span>**

<span data-ttu-id="da3fe-1980">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1980">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-1981">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1981">HTTP status code</span></span>      | <span data-ttu-id="da3fe-1982">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-1982">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-1983">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-1983">200</span></span> | <span data-ttu-id="da3fe-1984">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-1984">OK</span></span>
<span data-ttu-id="da3fe-1985">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1985">4XX</span></span> | <span data-ttu-id="da3fe-1986">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1986">Error codes</span></span>
<span data-ttu-id="da3fe-1987">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-1987">5XX</span></span> | <span data-ttu-id="da3fe-1988">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-1988">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-1989">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1989">Available device families</span></span>**

* <span data-ttu-id="da3fe-1990">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-1990">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-1991">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-1991">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-1992">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-1992">HoloLens</span></span>
* <span data-ttu-id="da3fe-1993">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-1993">IoT</span></span>

---
## DNS-SD Tags 
---
### <a name="view-tags"></a><span data-ttu-id="da3fe-1994">タグを表示する</span><span class="sxs-lookup"><span data-stu-id="da3fe-1994">View Tags</span></span>

**<span data-ttu-id="da3fe-1995">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-1995">Request</span></span>**

<span data-ttu-id="da3fe-1996">デバイスに現在適用されているタグを表示します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1996">View the currently applied tags for the device.</span></span>  <span data-ttu-id="da3fe-1997">これらのタグは、T キー内の DNS-SD TXT レコードを使用してアドバタイズされます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-1997">These are advertised via DNS-SD TXT records in the T key.</span></span>  
 
<span data-ttu-id="da3fe-1998">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-1998">Method</span></span>      | <span data-ttu-id="da3fe-1999">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-1999">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2000">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-2000">GET</span></span> | <span data-ttu-id="da3fe-2001">/api/dns-sd/tags</span><span class="sxs-lookup"><span data-stu-id="da3fe-2001">/api/dns-sd/tags</span></span>
<br />

**<span data-ttu-id="da3fe-2002">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2002">URI parameters</span></span>**

- <span data-ttu-id="da3fe-2003">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2003">None</span></span>

**<span data-ttu-id="da3fe-2004">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2004">Request headers</span></span>**

- <span data-ttu-id="da3fe-2005">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2005">None</span></span>

**<span data-ttu-id="da3fe-2006">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2006">Request body</span></span>**

- <span data-ttu-id="da3fe-2007">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2007">None</span></span>

<span data-ttu-id="da3fe-2008">**応答** 現在適用されているタグの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2008">**Response** The currently applied tags in the following format.</span></span> 
```
 {
    "tags": [
        "tag1", 
        "tag2", 
        ...
     ]
}
```

**<span data-ttu-id="da3fe-2009">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2009">Status code</span></span>**

<span data-ttu-id="da3fe-2010">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2010">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2011">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2011">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2012">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2012">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2013">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2013">200</span></span> | <span data-ttu-id="da3fe-2014">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-2014">OK</span></span>
<span data-ttu-id="da3fe-2015">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2015">5XX</span></span> | <span data-ttu-id="da3fe-2016">サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2016">Server Error</span></span> 

<br />
**<span data-ttu-id="da3fe-2017">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2017">Available device families</span></span>**

* <span data-ttu-id="da3fe-2018">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2018">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2019">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2019">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2020">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2020">Xbox</span></span>
* <span data-ttu-id="da3fe-2021">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2021">HoloLens</span></span>
* <span data-ttu-id="da3fe-2022">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2022">IoT</span></span>

---
### <a name="delete-tags"></a><span data-ttu-id="da3fe-2023">タグを削除する</span><span class="sxs-lookup"><span data-stu-id="da3fe-2023">Delete Tags</span></span>

**<span data-ttu-id="da3fe-2024">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2024">Request</span></span>**

<span data-ttu-id="da3fe-2025">DNS-SD によって現在アドバタイズされているすべてのタグを削除します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2025">Delete all tags currently advertised by DNS-SD.</span></span>   
 
<span data-ttu-id="da3fe-2026">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2026">Method</span></span>      | <span data-ttu-id="da3fe-2027">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2027">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2028">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-2028">DELETE</span></span> | <span data-ttu-id="da3fe-2029">/api/dns-sd/tags</span><span class="sxs-lookup"><span data-stu-id="da3fe-2029">/api/dns-sd/tags</span></span>
<br />

**<span data-ttu-id="da3fe-2030">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2030">URI parameters</span></span>**

- <span data-ttu-id="da3fe-2031">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2031">None</span></span>

**<span data-ttu-id="da3fe-2032">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2032">Request headers</span></span>**

- <span data-ttu-id="da3fe-2033">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2033">None</span></span>

**<span data-ttu-id="da3fe-2034">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2034">Request body</span></span>**

- <span data-ttu-id="da3fe-2035">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2035">None</span></span>

**<span data-ttu-id="da3fe-2036">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-2036">Response</span></span>**
 - <span data-ttu-id="da3fe-2037">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2037">None</span></span>

**<span data-ttu-id="da3fe-2038">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2038">Status code</span></span>**

<span data-ttu-id="da3fe-2039">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2039">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2040">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2040">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2041">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2041">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2042">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2042">200</span></span> | <span data-ttu-id="da3fe-2043">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-2043">OK</span></span>
<span data-ttu-id="da3fe-2044">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2044">5XX</span></span> | <span data-ttu-id="da3fe-2045">サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2045">Server Error</span></span> 

<br />
**<span data-ttu-id="da3fe-2046">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2046">Available device families</span></span>**

* <span data-ttu-id="da3fe-2047">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2047">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2048">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2048">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2049">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2049">Xbox</span></span>
* <span data-ttu-id="da3fe-2050">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2050">HoloLens</span></span>
* <span data-ttu-id="da3fe-2051">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2051">IoT</span></span>

---
### <a name="delete-tag"></a><span data-ttu-id="da3fe-2052">タグを削除する</span><span class="sxs-lookup"><span data-stu-id="da3fe-2052">Delete Tag</span></span>

**<span data-ttu-id="da3fe-2053">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2053">Request</span></span>**

<span data-ttu-id="da3fe-2054">DNS-SD によって現在アドバタイズされている 1 つのタグを削除します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2054">Delete a tag currently advertised by DNS-SD.</span></span>   
 
<span data-ttu-id="da3fe-2055">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2055">Method</span></span>      | <span data-ttu-id="da3fe-2056">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2056">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2057">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-2057">DELETE</span></span> | <span data-ttu-id="da3fe-2058">/api/dns-sd/tag</span><span class="sxs-lookup"><span data-stu-id="da3fe-2058">/api/dns-sd/tag</span></span>
<br />

**<span data-ttu-id="da3fe-2059">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2059">URI parameters</span></span>**

<span data-ttu-id="da3fe-2060">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2060">URI parameter</span></span> | <span data-ttu-id="da3fe-2061">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2061">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2062">tagValue</span><span class="sxs-lookup"><span data-stu-id="da3fe-2062">tagValue</span></span> | <span data-ttu-id="da3fe-2063">(**必須**) 削除するタグ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2063">(**required**) The tag to be removed.</span></span>

**<span data-ttu-id="da3fe-2064">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2064">Request headers</span></span>**

- <span data-ttu-id="da3fe-2065">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2065">None</span></span>

**<span data-ttu-id="da3fe-2066">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2066">Request body</span></span>**

- <span data-ttu-id="da3fe-2067">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2067">None</span></span>

**<span data-ttu-id="da3fe-2068">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-2068">Response</span></span>**
 - <span data-ttu-id="da3fe-2069">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2069">None</span></span>

**<span data-ttu-id="da3fe-2070">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2070">Status code</span></span>**

<span data-ttu-id="da3fe-2071">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2071">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2072">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2072">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2073">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2073">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2074">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2074">200</span></span> | <span data-ttu-id="da3fe-2075">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-2075">OK</span></span>

<br />
**<span data-ttu-id="da3fe-2076">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2076">Available device families</span></span>**

* <span data-ttu-id="da3fe-2077">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2077">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2078">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2078">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2079">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2079">Xbox</span></span>
* <span data-ttu-id="da3fe-2080">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2080">HoloLens</span></span>
* <span data-ttu-id="da3fe-2081">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2081">IoT</span></span>
 
---
### <a name="add-a-tag"></a><span data-ttu-id="da3fe-2082">タグを追加する</span><span class="sxs-lookup"><span data-stu-id="da3fe-2082">Add a Tag</span></span>

**<span data-ttu-id="da3fe-2083">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2083">Request</span></span>**

<span data-ttu-id="da3fe-2084">DNS-SD アドバタイズにタグを追加します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2084">Add a tag to the DNS-SD advertisement.</span></span>   
 
<span data-ttu-id="da3fe-2085">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2085">Method</span></span>      | <span data-ttu-id="da3fe-2086">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2086">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2087">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-2087">POST</span></span> | <span data-ttu-id="da3fe-2088">/api/dns-sd/tag</span><span class="sxs-lookup"><span data-stu-id="da3fe-2088">/api/dns-sd/tag</span></span>
<br />

**<span data-ttu-id="da3fe-2089">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2089">URI parameters</span></span>**

<span data-ttu-id="da3fe-2090">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2090">URI parameter</span></span> | <span data-ttu-id="da3fe-2091">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2091">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2092">tagValue</span><span class="sxs-lookup"><span data-stu-id="da3fe-2092">tagValue</span></span> | <span data-ttu-id="da3fe-2093">(**必要**) 追加するタグ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2093">(**required**) The tag to be added.</span></span>

**<span data-ttu-id="da3fe-2094">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2094">Request headers</span></span>**

- <span data-ttu-id="da3fe-2095">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2095">None</span></span>

**<span data-ttu-id="da3fe-2096">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2096">Request body</span></span>**

- <span data-ttu-id="da3fe-2097">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2097">None</span></span>

**<span data-ttu-id="da3fe-2098">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-2098">Response</span></span>**
 - <span data-ttu-id="da3fe-2099">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2099">None</span></span>

**<span data-ttu-id="da3fe-2100">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2100">Status code</span></span>**

<span data-ttu-id="da3fe-2101">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2101">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2102">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2102">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2103">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2103">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2104">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2104">200</span></span> | <span data-ttu-id="da3fe-2105">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-2105">OK</span></span>
<span data-ttu-id="da3fe-2106">401</span><span class="sxs-lookup"><span data-stu-id="da3fe-2106">401</span></span> | <span data-ttu-id="da3fe-2107">タグ領域のオーバーフロー。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2107">Tag space Overflow.</span></span>  <span data-ttu-id="da3fe-2108">提供されたタグが、結果として生成される DNS-SD サービス レコードに対して長すぎます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2108">Results when the proposed tag is too long for the resulting DNS-SD service record.</span></span>  

<br />
**<span data-ttu-id="da3fe-2109">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2109">Available device families</span></span>**

* <span data-ttu-id="da3fe-2110">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2110">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2111">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2111">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2112">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2112">Xbox</span></span>
* <span data-ttu-id="da3fe-2113">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2113">HoloLens</span></span>
* <span data-ttu-id="da3fe-2114">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2114">IoT</span></span>

## <a name="app-file-explorer"></a><span data-ttu-id="da3fe-2115">アプリのエクスプローラー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2115">App File Explorer</span></span>

---
### <a name="get-known-folders"></a><span data-ttu-id="da3fe-2116">既知のフォルダーを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-2116">Get known folders</span></span>

**<span data-ttu-id="da3fe-2117">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2117">Request</span></span>**

<span data-ttu-id="da3fe-2118">アクセス可能なトップ レベル フォルダーの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2118">Obtain a list of accessible top-level folders.</span></span>

<span data-ttu-id="da3fe-2119">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2119">Method</span></span>      | <span data-ttu-id="da3fe-2120">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2120">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2121">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-2121">GET</span></span> | <span data-ttu-id="da3fe-2122">/api/filesystem/apps/knownfolders</span><span class="sxs-lookup"><span data-stu-id="da3fe-2122">/api/filesystem/apps/knownfolders</span></span>
<br />

**<span data-ttu-id="da3fe-2123">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2123">URI parameters</span></span>**

- <span data-ttu-id="da3fe-2124">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2124">None</span></span>

**<span data-ttu-id="da3fe-2125">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2125">Request headers</span></span>**

- <span data-ttu-id="da3fe-2126">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2126">None</span></span>

**<span data-ttu-id="da3fe-2127">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2127">Request body</span></span>**

- <span data-ttu-id="da3fe-2128">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2128">None</span></span>

<span data-ttu-id="da3fe-2129">**応答** 利用可能なフォルダーの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2129">**Response** The available folders in the following format.</span></span> 
```
 {"KnownFolders": [
    "folder0",
    "folder1",...
]}
```
**<span data-ttu-id="da3fe-2130">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2130">Status code</span></span>**

<span data-ttu-id="da3fe-2131">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2131">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2132">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2132">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2133">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2133">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2134">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2134">200</span></span> | <span data-ttu-id="da3fe-2135">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2135">Deploy request accepted and being processed</span></span>
<span data-ttu-id="da3fe-2136">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2136">4XX</span></span> | <span data-ttu-id="da3fe-2137">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2137">Error codes</span></span>
<span data-ttu-id="da3fe-2138">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2138">5XX</span></span> | <span data-ttu-id="da3fe-2139">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2139">Error codes</span></span>
<br />

**<span data-ttu-id="da3fe-2140">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2140">Available device families</span></span>**

* <span data-ttu-id="da3fe-2141">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2141">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2142">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2142">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2143">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2143">HoloLens</span></span>
* <span data-ttu-id="da3fe-2144">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2144">Xbox</span></span>
* <span data-ttu-id="da3fe-2145">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2145">IoT</span></span>

---
### <a name="get-files"></a><span data-ttu-id="da3fe-2146">ファイルを取得する</span><span class="sxs-lookup"><span data-stu-id="da3fe-2146">Get files</span></span>

**<span data-ttu-id="da3fe-2147">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2147">Request</span></span>**

<span data-ttu-id="da3fe-2148">フォルダー内のファイルの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2148">Obtain a list of files in a folder.</span></span>

<span data-ttu-id="da3fe-2149">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2149">Method</span></span>      | <span data-ttu-id="da3fe-2150">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2150">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2151">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-2151">GET</span></span> | <span data-ttu-id="da3fe-2152">/api/filesystem/apps/files</span><span class="sxs-lookup"><span data-stu-id="da3fe-2152">/api/filesystem/apps/files</span></span>
<br />

**<span data-ttu-id="da3fe-2153">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2153">URI parameters</span></span>**

<span data-ttu-id="da3fe-2154">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2154">URI parameter</span></span> | <span data-ttu-id="da3fe-2155">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2155">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2156">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="da3fe-2156">knownfolderid</span></span> | <span data-ttu-id="da3fe-2157">(**必須**) 必要なファイルの一覧の対象となるトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2157">(**required**) The top-level directory where you want the list of files.</span></span> <span data-ttu-id="da3fe-2158">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2158">Use **LocalAppData** for access to sideloaded apps.</span></span> 
<span data-ttu-id="da3fe-2159">packagefullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-2159">packagefullname</span></span> | <span data-ttu-id="da3fe-2160">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2160">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> 
<span data-ttu-id="da3fe-2161">path</span><span class="sxs-lookup"><span data-stu-id="da3fe-2161">path</span></span> | <span data-ttu-id="da3fe-2162">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2162">(**optional**) The sub-directory within the folder or package specified above.</span></span> 

**<span data-ttu-id="da3fe-2163">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2163">Request headers</span></span>**

- <span data-ttu-id="da3fe-2164">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2164">None</span></span>

**<span data-ttu-id="da3fe-2165">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2165">Request body</span></span>**

- <span data-ttu-id="da3fe-2166">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2166">None</span></span>

<span data-ttu-id="da3fe-2167">**応答** 利用可能なフォルダーの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2167">**Response** The available folders in the following format.</span></span> 
```
{"Items": [
    {
        "CurrentDir": string (folder under the requested known folder),
        "DateCreated": int,
        "FileSize": int (bytes),
        "Id": string,
        "Name": string,
        "SubPath": string (present if this item is a folder, this is the name of the folder),
        "Type": int
    },...
]}
```
**<span data-ttu-id="da3fe-2168">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2168">Status code</span></span>**

<span data-ttu-id="da3fe-2169">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2169">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2170">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2170">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2171">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2171">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2172">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2172">200</span></span> | <span data-ttu-id="da3fe-2173">OK</span><span class="sxs-lookup"><span data-stu-id="da3fe-2173">OK</span></span>
<span data-ttu-id="da3fe-2174">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2174">4XX</span></span> | <span data-ttu-id="da3fe-2175">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2175">Error codes</span></span>
<span data-ttu-id="da3fe-2176">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2176">5XX</span></span> | <span data-ttu-id="da3fe-2177">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2177">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-2178">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2178">Available device families</span></span>**

* <span data-ttu-id="da3fe-2179">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2179">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2180">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2180">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2181">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2181">HoloLens</span></span>
* <span data-ttu-id="da3fe-2182">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2182">Xbox</span></span>
* <span data-ttu-id="da3fe-2183">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2183">IoT</span></span>

---
### <a name="download-a-file"></a><span data-ttu-id="da3fe-2184">ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="da3fe-2184">Download a file</span></span>

**<span data-ttu-id="da3fe-2185">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2185">Request</span></span>**

<span data-ttu-id="da3fe-2186">既知のフォルダーまたは appLocalData からファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2186">Obtain a file from a known folder or appLocalData.</span></span>

<span data-ttu-id="da3fe-2187">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2187">Method</span></span>      | <span data-ttu-id="da3fe-2188">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2188">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2189">GET</span><span class="sxs-lookup"><span data-stu-id="da3fe-2189">GET</span></span> | <span data-ttu-id="da3fe-2190">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="da3fe-2190">/api/filesystem/apps/file</span></span>

**<span data-ttu-id="da3fe-2191">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2191">URI parameters</span></span>**

<span data-ttu-id="da3fe-2192">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2192">URI parameter</span></span> | <span data-ttu-id="da3fe-2193">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2193">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2194">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="da3fe-2194">knownfolderid</span></span> | <span data-ttu-id="da3fe-2195">(**必須**) ファイルをダウンロードするトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2195">(**required**) The top-level directory where you want to download files.</span></span> <span data-ttu-id="da3fe-2196">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2196">Use **LocalAppData** for access to sideloaded apps.</span></span> 
<span data-ttu-id="da3fe-2197">filename</span><span class="sxs-lookup"><span data-stu-id="da3fe-2197">filename</span></span> | <span data-ttu-id="da3fe-2198">(**必須**) ダウンロードするファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2198">(**required**) The name of the file being downloaded.</span></span> 
<span data-ttu-id="da3fe-2199">packagefullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-2199">packagefullname</span></span> | <span data-ttu-id="da3fe-2200">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2200">(**required if *knownfolderid* == LocalAppData**) The package full name you are interested in.</span></span> 
<span data-ttu-id="da3fe-2201">path</span><span class="sxs-lookup"><span data-stu-id="da3fe-2201">path</span></span> | <span data-ttu-id="da3fe-2202">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2202">(**optional**) The sub-directory within the folder or package specified above.</span></span>

**<span data-ttu-id="da3fe-2203">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2203">Request headers</span></span>**

- <span data-ttu-id="da3fe-2204">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2204">None</span></span>

**<span data-ttu-id="da3fe-2205">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2205">Request body</span></span>**

- <span data-ttu-id="da3fe-2206">要求するファイル (存在する場合)</span><span class="sxs-lookup"><span data-stu-id="da3fe-2206">The file requested, if present</span></span>

**<span data-ttu-id="da3fe-2207">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-2207">Response</span></span>**

**<span data-ttu-id="da3fe-2208">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2208">Status code</span></span>**

<span data-ttu-id="da3fe-2209">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2209">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2210">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2210">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2211">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2211">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2212">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2212">200</span></span> | <span data-ttu-id="da3fe-2213">要求したファイル</span><span class="sxs-lookup"><span data-stu-id="da3fe-2213">The requested file</span></span>
<span data-ttu-id="da3fe-2214">404</span><span class="sxs-lookup"><span data-stu-id="da3fe-2214">404</span></span> | <span data-ttu-id="da3fe-2215">ファイルが見つかりません</span><span class="sxs-lookup"><span data-stu-id="da3fe-2215">File not found</span></span>
<span data-ttu-id="da3fe-2216">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2216">5XX</span></span> | <span data-ttu-id="da3fe-2217">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2217">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-2218">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2218">Available device families</span></span>**

* <span data-ttu-id="da3fe-2219">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2219">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2220">Windows デスクトップ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2220">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2221">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2221">HoloLens</span></span>
* <span data-ttu-id="da3fe-2222">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2222">Xbox</span></span>
* <span data-ttu-id="da3fe-2223">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2223">IoT</span></span>

---
### <a name="rename-a-file"></a><span data-ttu-id="da3fe-2224">ファイルの名前の変更</span><span class="sxs-lookup"><span data-stu-id="da3fe-2224">Rename a file</span></span>

**<span data-ttu-id="da3fe-2225">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2225">Request</span></span>**

<span data-ttu-id="da3fe-2226">フォルダー内のファイルの名前を変更します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2226">Rename a file in a folder.</span></span>

<span data-ttu-id="da3fe-2227">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2227">Method</span></span>      | <span data-ttu-id="da3fe-2228">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2228">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2229">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-2229">POST</span></span> | <span data-ttu-id="da3fe-2230">/api/filesystem/apps/rename</span><span class="sxs-lookup"><span data-stu-id="da3fe-2230">/api/filesystem/apps/rename</span></span>

<br />
**<span data-ttu-id="da3fe-2231">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2231">URI parameters</span></span>**

<span data-ttu-id="da3fe-2232">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2232">URI parameter</span></span> | <span data-ttu-id="da3fe-2233">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2233">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2234">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="da3fe-2234">knownfolderid</span></span> | <span data-ttu-id="da3fe-2235">(**必須**) ファイルが存在するトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2235">(**required**) The top-level directory where the file is located.</span></span> <span data-ttu-id="da3fe-2236">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2236">Use **LocalAppData** for access to sideloaded apps.</span></span> 
<span data-ttu-id="da3fe-2237">filename</span><span class="sxs-lookup"><span data-stu-id="da3fe-2237">filename</span></span> | <span data-ttu-id="da3fe-2238">(**必須**) 名前を変更するファイルの元の名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2238">(**required**) The original name of the file being renamed.</span></span> 
<span data-ttu-id="da3fe-2239">newfilename</span><span class="sxs-lookup"><span data-stu-id="da3fe-2239">newfilename</span></span> | <span data-ttu-id="da3fe-2240">(**必須**) ファイルの新しい名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2240">(**required**) The new name of the file.</span></span>
<span data-ttu-id="da3fe-2241">packagefullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-2241">packagefullname</span></span> | <span data-ttu-id="da3fe-2242">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2242">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> 
<span data-ttu-id="da3fe-2243">path</span><span class="sxs-lookup"><span data-stu-id="da3fe-2243">path</span></span> | <span data-ttu-id="da3fe-2244">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2244">(**optional**) The sub-directory within the folder or package specified above.</span></span> 

**<span data-ttu-id="da3fe-2245">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2245">Request headers</span></span>**

- <span data-ttu-id="da3fe-2246">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2246">None</span></span>

**<span data-ttu-id="da3fe-2247">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2247">Request body</span></span>**

- <span data-ttu-id="da3fe-2248">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2248">None</span></span>

**<span data-ttu-id="da3fe-2249">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-2249">Response</span></span>**

- <span data-ttu-id="da3fe-2250">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2250">None</span></span>

**<span data-ttu-id="da3fe-2251">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2251">Status code</span></span>**

<span data-ttu-id="da3fe-2252">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2252">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2253">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2253">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2254">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2254">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2255">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2255">200</span></span> | <span data-ttu-id="da3fe-2256">OK。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2256">OK.</span></span> <span data-ttu-id="da3fe-2257">ファイルの名前が変更されました</span><span class="sxs-lookup"><span data-stu-id="da3fe-2257">The file is renamed</span></span>
<span data-ttu-id="da3fe-2258">404</span><span class="sxs-lookup"><span data-stu-id="da3fe-2258">404</span></span> | <span data-ttu-id="da3fe-2259">ファイルが見つかりません</span><span class="sxs-lookup"><span data-stu-id="da3fe-2259">File not found</span></span>
<span data-ttu-id="da3fe-2260">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2260">5XX</span></span> | <span data-ttu-id="da3fe-2261">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2261">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-2262">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2262">Available device families</span></span>**

* <span data-ttu-id="da3fe-2263">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2263">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2264">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2264">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2265">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2265">HoloLens</span></span>
* <span data-ttu-id="da3fe-2266">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2266">Xbox</span></span>
* <span data-ttu-id="da3fe-2267">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2267">IoT</span></span>

---
### <a name="delete-a-file"></a><span data-ttu-id="da3fe-2268">ファイルを削除する</span><span class="sxs-lookup"><span data-stu-id="da3fe-2268">Delete a file</span></span>

**<span data-ttu-id="da3fe-2269">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2269">Request</span></span>**

<span data-ttu-id="da3fe-2270">フォルダー内のファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2270">Delete a file in a folder.</span></span>

<span data-ttu-id="da3fe-2271">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2271">Method</span></span>      | <span data-ttu-id="da3fe-2272">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2272">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2273">DELETE</span><span class="sxs-lookup"><span data-stu-id="da3fe-2273">DELETE</span></span> | <span data-ttu-id="da3fe-2274">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="da3fe-2274">/api/filesystem/apps/file</span></span>
<br />
**<span data-ttu-id="da3fe-2275">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2275">URI parameters</span></span>**

<span data-ttu-id="da3fe-2276">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2276">URI parameter</span></span> | <span data-ttu-id="da3fe-2277">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2277">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2278">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="da3fe-2278">knownfolderid</span></span> | <span data-ttu-id="da3fe-2279">(**必須**) ファイルを削除するトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2279">(**required**) The top-level directory where you want to delete files.</span></span> <span data-ttu-id="da3fe-2280">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2280">Use **LocalAppData** for access to sideloaded apps.</span></span> 
<span data-ttu-id="da3fe-2281">filename</span><span class="sxs-lookup"><span data-stu-id="da3fe-2281">filename</span></span> | <span data-ttu-id="da3fe-2282">(**必須**) 削除するファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2282">(**required**) The name of the file being deleted.</span></span> 
<span data-ttu-id="da3fe-2283">packagefullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-2283">packagefullname</span></span> | <span data-ttu-id="da3fe-2284">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2284">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> 
<span data-ttu-id="da3fe-2285">path</span><span class="sxs-lookup"><span data-stu-id="da3fe-2285">path</span></span> | <span data-ttu-id="da3fe-2286">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2286">(**optional**) The sub-directory within the folder or package specified above.</span></span>

**<span data-ttu-id="da3fe-2287">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2287">Request headers</span></span>**

- <span data-ttu-id="da3fe-2288">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2288">None</span></span>

**<span data-ttu-id="da3fe-2289">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2289">Request body</span></span>**

- <span data-ttu-id="da3fe-2290">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2290">None</span></span>

**<span data-ttu-id="da3fe-2291">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-2291">Response</span></span>**

- <span data-ttu-id="da3fe-2292">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2292">None</span></span> 

**<span data-ttu-id="da3fe-2293">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2293">Status code</span></span>**

<span data-ttu-id="da3fe-2294">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2294">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2295">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2295">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2296">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2296">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2297">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2297">200</span></span> | <span data-ttu-id="da3fe-2298">OK。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2298">OK.</span></span> <span data-ttu-id="da3fe-2299">ファイルが削除されます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2299">The file is deleted</span></span>
<span data-ttu-id="da3fe-2300">404</span><span class="sxs-lookup"><span data-stu-id="da3fe-2300">404</span></span> | <span data-ttu-id="da3fe-2301">ファイルが見つかりません</span><span class="sxs-lookup"><span data-stu-id="da3fe-2301">File not found</span></span>
<span data-ttu-id="da3fe-2302">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2302">5XX</span></span> | <span data-ttu-id="da3fe-2303">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2303">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-2304">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2304">Available device families</span></span>**

* <span data-ttu-id="da3fe-2305">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2305">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2306">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2306">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2307">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2307">HoloLens</span></span>
* <span data-ttu-id="da3fe-2308">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2308">Xbox</span></span>
* <span data-ttu-id="da3fe-2309">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2309">IoT</span></span>

---
### <a name="upload-a-file"></a><span data-ttu-id="da3fe-2310">ファイルをアップロードする</span><span class="sxs-lookup"><span data-stu-id="da3fe-2310">Upload a file</span></span>

**<span data-ttu-id="da3fe-2311">要求</span><span class="sxs-lookup"><span data-stu-id="da3fe-2311">Request</span></span>**

<span data-ttu-id="da3fe-2312">フォルダーにファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2312">Upload a file to a folder.</span></span>  <span data-ttu-id="da3fe-2313">この場合、同じ名前を持つ既存のファイルは上書きされますが、新しいフォルダーは作成されません。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2313">This will overwrite an existing file with the same name, but will not create new folders.</span></span> 

<span data-ttu-id="da3fe-2314">メソッド</span><span class="sxs-lookup"><span data-stu-id="da3fe-2314">Method</span></span>      | <span data-ttu-id="da3fe-2315">要求 URI</span><span class="sxs-lookup"><span data-stu-id="da3fe-2315">Request URI</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2316">POST</span><span class="sxs-lookup"><span data-stu-id="da3fe-2316">POST</span></span> | <span data-ttu-id="da3fe-2317">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="da3fe-2317">/api/filesystem/apps/file</span></span>
<br />
**<span data-ttu-id="da3fe-2318">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2318">URI parameters</span></span>**

<span data-ttu-id="da3fe-2319">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="da3fe-2319">URI parameter</span></span> | <span data-ttu-id="da3fe-2320">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2320">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2321">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="da3fe-2321">knownfolderid</span></span> | <span data-ttu-id="da3fe-2322">(**必須**) ファイルをアップロードするトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2322">(**required**) The top-level directory where you want to upload files.</span></span> <span data-ttu-id="da3fe-2323">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2323">Use **LocalAppData** for access to sideloaded apps.</span></span>
<span data-ttu-id="da3fe-2324">packagefullname</span><span class="sxs-lookup"><span data-stu-id="da3fe-2324">packagefullname</span></span> | <span data-ttu-id="da3fe-2325">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2325">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> 
<span data-ttu-id="da3fe-2326">path</span><span class="sxs-lookup"><span data-stu-id="da3fe-2326">path</span></span> | <span data-ttu-id="da3fe-2327">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2327">(**optional**) The sub-directory within the folder or package specified above.</span></span>

**<span data-ttu-id="da3fe-2328">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="da3fe-2328">Request headers</span></span>**

- <span data-ttu-id="da3fe-2329">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2329">None</span></span>

**<span data-ttu-id="da3fe-2330">要求本文</span><span class="sxs-lookup"><span data-stu-id="da3fe-2330">Request body</span></span>**

- <span data-ttu-id="da3fe-2331">なし</span><span class="sxs-lookup"><span data-stu-id="da3fe-2331">None</span></span>

**<span data-ttu-id="da3fe-2332">応答</span><span class="sxs-lookup"><span data-stu-id="da3fe-2332">Response</span></span>**

**<span data-ttu-id="da3fe-2333">状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2333">Status code</span></span>**

<span data-ttu-id="da3fe-2334">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2334">This API has the following expected status codes.</span></span>

<span data-ttu-id="da3fe-2335">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2335">HTTP status code</span></span>      | <span data-ttu-id="da3fe-2336">説明</span><span class="sxs-lookup"><span data-stu-id="da3fe-2336">Description</span></span>
:------     | :-----
<span data-ttu-id="da3fe-2337">200</span><span class="sxs-lookup"><span data-stu-id="da3fe-2337">200</span></span> | <span data-ttu-id="da3fe-2338">OK。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2338">OK.</span></span> <span data-ttu-id="da3fe-2339">ファイルがアップロードされます。</span><span class="sxs-lookup"><span data-stu-id="da3fe-2339">The file is uploaded</span></span>
<span data-ttu-id="da3fe-2340">4XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2340">4XX</span></span> | <span data-ttu-id="da3fe-2341">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2341">Error codes</span></span>
<span data-ttu-id="da3fe-2342">5XX</span><span class="sxs-lookup"><span data-stu-id="da3fe-2342">5XX</span></span> | <span data-ttu-id="da3fe-2343">エラー コード</span><span class="sxs-lookup"><span data-stu-id="da3fe-2343">Error codes</span></span>
<br />
**<span data-ttu-id="da3fe-2344">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="da3fe-2344">Available device families</span></span>**

* <span data-ttu-id="da3fe-2345">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="da3fe-2345">Windows Mobile</span></span>
* <span data-ttu-id="da3fe-2346">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="da3fe-2346">Windows Desktop</span></span>
* <span data-ttu-id="da3fe-2347">HoloLens</span><span class="sxs-lookup"><span data-stu-id="da3fe-2347">HoloLens</span></span>
* <span data-ttu-id="da3fe-2348">Xbox</span><span class="sxs-lookup"><span data-stu-id="da3fe-2348">Xbox</span></span>
* <span data-ttu-id="da3fe-2349">IoT</span><span class="sxs-lookup"><span data-stu-id="da3fe-2349">IoT</span></span>