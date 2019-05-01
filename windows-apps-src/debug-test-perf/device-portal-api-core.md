---
ms.assetid: bfabd3d5-dd56-4917-9572-f3ba0de4f8c0
title: デバイス ポータル コア API リファレンス
description: Windows Device Portal コア REST API について説明します。これによって、データにアクセスし、プログラムを使ってデバイスを制御することが可能になります。
ms.custom: 19H1
ms.date: 04/19/2019
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 910e3108009704d444fb81b195f9dd9eae3daa9d
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63798183"
---
# <a name="device-portal-core-api-reference"></a><span data-ttu-id="c78d6-104">デバイス ポータル コア API リファレンス</span><span class="sxs-lookup"><span data-stu-id="c78d6-104">Device Portal core API reference</span></span>

<span data-ttu-id="c78d6-105">デバイス ポータルのすべての機能は、REST API の上に構築されています。開発者は REST API を直接呼び出して、プログラムからリソースにアクセスし、デバイスを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-105">All Device Portal functionality is built on REST APIs that developers can call directly to access resources and control their devices programmatically.</span></span>

## <a name="app-deployment"></a><span data-ttu-id="c78d6-106">アプリの展開</span><span class="sxs-lookup"><span data-stu-id="c78d6-106">App deployment</span></span>

### <a name="install-an-app"></a><span data-ttu-id="c78d6-107">アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="c78d6-107">Install an app</span></span>

<span data-ttu-id="c78d6-108">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-108">**Request**</span></span>

<span data-ttu-id="c78d6-109">次の要求形式を使用して、アプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-109">You can install an app by using the following request format.</span></span>

| <span data-ttu-id="c78d6-110">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-110">Method</span></span>      | <span data-ttu-id="c78d6-111">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-111">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-112">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-112">POST</span></span> | <span data-ttu-id="c78d6-113">/api/app/packagemanager/package</span><span class="sxs-lookup"><span data-stu-id="c78d6-113">/api/app/packagemanager/package</span></span> |

<span data-ttu-id="c78d6-114">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-114">**URI parameters**</span></span>

<span data-ttu-id="c78d6-115">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-115">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-116">URI parameter</span></span> | <span data-ttu-id="c78d6-117">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-117">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-118">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="c78d6-118">package</span></span>   | <span data-ttu-id="c78d6-119">(**必須**) インストールするパッケージのファイル名。</span><span class="sxs-lookup"><span data-stu-id="c78d6-119">(**required**) The file name of the package to be installed.</span></span> |

<span data-ttu-id="c78d6-120">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-120">**Request headers**</span></span>

- <span data-ttu-id="c78d6-121">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-121">None</span></span>

<span data-ttu-id="c78d6-122">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-122">**Request body**</span></span>

- <span data-ttu-id="c78d6-123">.appx または .appxbundle ファイル、およびアプリが必要とする依存関係。</span><span class="sxs-lookup"><span data-stu-id="c78d6-123">The .appx or .appxbundle file, as well as any dependencies the app requires.</span></span> 
- <span data-ttu-id="c78d6-124">デバイスが IoT または Windows デスクトップの場合、アプリの署名に使う証明書。</span><span class="sxs-lookup"><span data-stu-id="c78d6-124">The certificate used to sign the app, if the device is IoT or Windows Desktop.</span></span> <span data-ttu-id="c78d6-125">その他のプラットフォームでは、証明書は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="c78d6-125">Other platforms do not require the certificate.</span></span> 

<span data-ttu-id="c78d6-126">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-126">**Response**</span></span>

<span data-ttu-id="c78d6-127">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-127">**Status code**</span></span>

<span data-ttu-id="c78d6-128">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-128">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-129">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-129">HTTP status code</span></span>      | <span data-ttu-id="c78d6-130">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-130">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="c78d6-131">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-131">200</span></span> | <span data-ttu-id="c78d6-132">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-132">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="c78d6-133">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-133">4XX</span></span> | <span data-ttu-id="c78d6-134">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-134">Error codes</span></span> |
| <span data-ttu-id="c78d6-135">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-135">5XX</span></span> | <span data-ttu-id="c78d6-136">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-136">Error codes</span></span> |

<span data-ttu-id="c78d6-137">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-137">**Available device families**</span></span>

* <span data-ttu-id="c78d6-138">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-138">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-139">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-139">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-140">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-140">Xbox</span></span>
* <span data-ttu-id="c78d6-141">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-141">HoloLens</span></span>
* <span data-ttu-id="c78d6-142">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-142">IoT</span></span>

<hr>

### <a name="install-a-related-set"></a><span data-ttu-id="c78d6-143">関連セットをインストールする</span><span class="sxs-lookup"><span data-stu-id="c78d6-143">Install a related set</span></span>

<span data-ttu-id="c78d6-144">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-144">**Request**</span></span>

<span data-ttu-id="c78d6-145">次の要求形式を使用して、[関連セット](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/)をインストールできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-145">You can install a [related set](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/) by using the following request format.</span></span>

| <span data-ttu-id="c78d6-146">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-146">Method</span></span>      | <span data-ttu-id="c78d6-147">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-147">Request URI</span></span> |
| :------     | :------ |
| <span data-ttu-id="c78d6-148">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-148">POST</span></span> | <span data-ttu-id="c78d6-149">/api/app/packagemanager/package</span><span class="sxs-lookup"><span data-stu-id="c78d6-149">/api/app/packagemanager/package</span></span> |

<span data-ttu-id="c78d6-150">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-150">**URI parameters**</span></span>

<span data-ttu-id="c78d6-151">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-151">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-152">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-152">URI parameter</span></span> | <span data-ttu-id="c78d6-153">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-153">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-154">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="c78d6-154">package</span></span>   | <span data-ttu-id="c78d6-155">(**必須**) インストールするパッケージのファイル名。</span><span class="sxs-lookup"><span data-stu-id="c78d6-155">(**required**) The file names of the packages to be installed.</span></span> |

<span data-ttu-id="c78d6-156">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-156">**Request headers**</span></span>

- <span data-ttu-id="c78d6-157">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-157">None</span></span>

<span data-ttu-id="c78d6-158">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-158">**Request body**</span></span> 
- <span data-ttu-id="c78d6-159">オプション パッケージをパラメーターとして指定するときは、"foo.appx.opt"、"bar.appxbundle.opt" などのようにパッケージのファイル名に ".opt" を追加します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-159">Add ".opt" to the optional package file names when specifying them as a parameter, like so: "foo.appx.opt" or "bar.appxbundle.opt".</span></span> 
- <span data-ttu-id="c78d6-160">.appx または .appxbundle ファイル、およびアプリが必要とする依存関係。</span><span class="sxs-lookup"><span data-stu-id="c78d6-160">The .appx or .appxbundle file, as well as any dependencies the app requires.</span></span> 
- <span data-ttu-id="c78d6-161">デバイスが IoT または Windows デスクトップの場合、アプリの署名に使う証明書。</span><span class="sxs-lookup"><span data-stu-id="c78d6-161">The certificate used to sign the app, if the device is IoT or Windows Desktop.</span></span> <span data-ttu-id="c78d6-162">その他のプラットフォームでは、証明書は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="c78d6-162">Other platforms do not require the certificate.</span></span> 

<span data-ttu-id="c78d6-163">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-163">**Response**</span></span>

<span data-ttu-id="c78d6-164">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-164">**Status code**</span></span>

<span data-ttu-id="c78d6-165">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-165">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-166">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-166">HTTP status code</span></span>      | <span data-ttu-id="c78d6-167">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-167">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="c78d6-168">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-168">200</span></span> | <span data-ttu-id="c78d6-169">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-169">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="c78d6-170">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-170">4XX</span></span> | <span data-ttu-id="c78d6-171">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-171">Error codes</span></span> |
| <span data-ttu-id="c78d6-172">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-172">5XX</span></span> | <span data-ttu-id="c78d6-173">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-173">Error codes</span></span> |

<span data-ttu-id="c78d6-174">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-174">**Available device families**</span></span>

* <span data-ttu-id="c78d6-175">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-175">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-176">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-176">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-177">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-177">Xbox</span></span>
* <span data-ttu-id="c78d6-178">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-178">HoloLens</span></span>
* <span data-ttu-id="c78d6-179">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-179">IoT</span></span>

<hr>

### <a name="register-an-app-in-a-loose-folder"></a><span data-ttu-id="c78d6-180">アプリをルース フォルダーに登録する</span><span class="sxs-lookup"><span data-stu-id="c78d6-180">Register an app in a loose folder</span></span>

<span data-ttu-id="c78d6-181">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-181">**Request**</span></span>

<span data-ttu-id="c78d6-182">次の要求形式を使用して、アプリをルース フォルダーに登録できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-182">You can register an app in a loose folder by using the following request format.</span></span>

| <span data-ttu-id="c78d6-183">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-183">Method</span></span>      | <span data-ttu-id="c78d6-184">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-184">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-185">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-185">POST</span></span> | <span data-ttu-id="c78d6-186">/api/app/packagemanager/networkapp</span><span class="sxs-lookup"><span data-stu-id="c78d6-186">/api/app/packagemanager/networkapp</span></span> |

<span data-ttu-id="c78d6-187">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-187">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-188">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-188">None</span></span>

<span data-ttu-id="c78d6-189">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-189">**Request headers**</span></span>

- <span data-ttu-id="c78d6-190">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-190">None</span></span>

<span data-ttu-id="c78d6-191">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-191">**Request body**</span></span>

```json
{
    "mainpackage" :
    {
        "networkshare" : "\\some\share\path",
        "username" : "optional_username",
        "password" : "optional_password"
    }
}
```

<span data-ttu-id="c78d6-192">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-192">**Response**</span></span>

<span data-ttu-id="c78d6-193">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-193">**Status code**</span></span>

<span data-ttu-id="c78d6-194">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-194">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-195">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-195">HTTP status code</span></span>      | <span data-ttu-id="c78d6-196">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-196">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="c78d6-197">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-197">200</span></span> | <span data-ttu-id="c78d6-198">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-198">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="c78d6-199">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-199">4XX</span></span> | <span data-ttu-id="c78d6-200">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-200">Error codes</span></span> |
| <span data-ttu-id="c78d6-201">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-201">5XX</span></span> | <span data-ttu-id="c78d6-202">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-202">Error codes</span></span> |

<span data-ttu-id="c78d6-203">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-203">**Available device families**</span></span>

* <span data-ttu-id="c78d6-204">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-204">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-205">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-205">Xbox</span></span>
* <span data-ttu-id="c78d6-206">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-206">HoloLens</span></span>
* <span data-ttu-id="c78d6-207">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-207">IoT</span></span>

<hr>

### <a name="register-a-related-set-in-loose-file-folders"></a><span data-ttu-id="c78d6-208">関連セットをルース ファイル フォルダーに登録する</span><span class="sxs-lookup"><span data-stu-id="c78d6-208">Register a related set in loose file folders</span></span>

<span data-ttu-id="c78d6-209">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-209">**Request**</span></span>

<span data-ttu-id="c78d6-210">次の要求形式を使用して、[関連セット](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/)をルース フォルダーに登録できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-210">You can register a [related set](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/) in loose folders by using the following request format.</span></span>

| <span data-ttu-id="c78d6-211">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-211">Method</span></span>      | <span data-ttu-id="c78d6-212">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-212">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-213">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-213">POST</span></span> | <span data-ttu-id="c78d6-214">/api/app/packagemanager/networkapp</span><span class="sxs-lookup"><span data-stu-id="c78d6-214">/api/app/packagemanager/networkapp</span></span> |

<span data-ttu-id="c78d6-215">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-215">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-216">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-216">None</span></span>

<span data-ttu-id="c78d6-217">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-217">**Request headers**</span></span>

- <span data-ttu-id="c78d6-218">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-218">None</span></span>

<span data-ttu-id="c78d6-219">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-219">**Request body**</span></span>

```json
{
    "mainpackage" :
    {
        "networkshare" : "\\some\share\path",
        "username" : "optional_username",
        "password" : "optional_password"
    },
    "optionalpackages" :
    [
        {
            "networkshare" : "\\some\share\path2",
            "username" : "optional_username2",
            "password" : "optional_password2"
        },
        ...
    ]
}
```

<span data-ttu-id="c78d6-220">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-220">**Response**</span></span>

<span data-ttu-id="c78d6-221">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-221">**Status code**</span></span>

<span data-ttu-id="c78d6-222">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-222">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-223">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-223">HTTP status code</span></span>      | <span data-ttu-id="c78d6-224">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-224">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="c78d6-225">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-225">200</span></span> | <span data-ttu-id="c78d6-226">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-226">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="c78d6-227">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-227">4XX</span></span> | <span data-ttu-id="c78d6-228">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-228">Error codes</span></span> |
| <span data-ttu-id="c78d6-229">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-229">5XX</span></span> | <span data-ttu-id="c78d6-230">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-230">Error codes</span></span> |

<span data-ttu-id="c78d6-231">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-231">**Available device families**</span></span>

* <span data-ttu-id="c78d6-232">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-232">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-233">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-233">Xbox</span></span>
* <span data-ttu-id="c78d6-234">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-234">HoloLens</span></span>
* <span data-ttu-id="c78d6-235">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-235">IoT</span></span>

<hr>

### <a name="get-app-installation-status"></a><span data-ttu-id="c78d6-236">アプリのインストール状態を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-236">Get app installation status</span></span>

<span data-ttu-id="c78d6-237">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-237">**Request**</span></span>

<span data-ttu-id="c78d6-238">次の要求形式を使用して、現在進行中のアプリのインストールの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-238">You can get the status of an app installation that is currently in progress by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-239">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-239">Method</span></span>      | <span data-ttu-id="c78d6-240">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-240">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-241">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-241">GET</span></span> | <span data-ttu-id="c78d6-242">/api/app/packagemanager/state</span><span class="sxs-lookup"><span data-stu-id="c78d6-242">/api/app/packagemanager/state</span></span> |

<span data-ttu-id="c78d6-243">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-243">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-244">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-244">None</span></span>

<span data-ttu-id="c78d6-245">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-245">**Request headers**</span></span>

- <span data-ttu-id="c78d6-246">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-246">None</span></span>

<span data-ttu-id="c78d6-247">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-247">**Request body**</span></span>

- <span data-ttu-id="c78d6-248">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-248">None</span></span>

<span data-ttu-id="c78d6-249">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-249">**Response**</span></span>

<span data-ttu-id="c78d6-250">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-250">**Status code**</span></span>

<span data-ttu-id="c78d6-251">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-251">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-252">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-252">HTTP status code</span></span>      | <span data-ttu-id="c78d6-253">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-253">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="c78d6-254">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-254">200</span></span> | <span data-ttu-id="c78d6-255">最後の展開の結果</span><span class="sxs-lookup"><span data-stu-id="c78d6-255">The result of the last deployment</span></span> |
| <span data-ttu-id="c78d6-256">204</span><span class="sxs-lookup"><span data-stu-id="c78d6-256">204</span></span> | <span data-ttu-id="c78d6-257">インストールは実行中です</span><span class="sxs-lookup"><span data-stu-id="c78d6-257">The installation is running</span></span> |
| <span data-ttu-id="c78d6-258">404</span><span class="sxs-lookup"><span data-stu-id="c78d6-258">404</span></span> | <span data-ttu-id="c78d6-259">インストール操作は見つかりませんでした</span><span class="sxs-lookup"><span data-stu-id="c78d6-259">No installation action was found</span></span> |

<span data-ttu-id="c78d6-260">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-260">**Available device families**</span></span>

* <span data-ttu-id="c78d6-261">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-261">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-262">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-262">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-263">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-263">Xbox</span></span>
* <span data-ttu-id="c78d6-264">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-264">HoloLens</span></span>
* <span data-ttu-id="c78d6-265">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-265">IoT</span></span>

<hr>

### <a name="uninstall-an-app"></a><span data-ttu-id="c78d6-266">アプリをアンインストールする</span><span class="sxs-lookup"><span data-stu-id="c78d6-266">Uninstall an app</span></span>

<span data-ttu-id="c78d6-267">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-267">**Request**</span></span>

<span data-ttu-id="c78d6-268">次の要求形式を使用して、アプリをアンインストールできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-268">You can uninstall an app by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-269">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-269">Method</span></span>      | <span data-ttu-id="c78d6-270">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-270">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-271">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-271">DELETE</span></span> | <span data-ttu-id="c78d6-272">/api/app/packagemanager/package</span><span class="sxs-lookup"><span data-stu-id="c78d6-272">/api/app/packagemanager/package</span></span> |

<span data-ttu-id="c78d6-273">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-273">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-274">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-274">URI parameter</span></span> | <span data-ttu-id="c78d6-275">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-275">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-276">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="c78d6-276">package</span></span>   | <span data-ttu-id="c78d6-277">(**必須**) ターゲット アプリの PackageFullName (GET /api/app/packagemanager/packages から)</span><span class="sxs-lookup"><span data-stu-id="c78d6-277">(**required**) The PackageFullName (from GET /api/app/packagemanager/packages) of the target app</span></span> |

<span data-ttu-id="c78d6-278">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-278">**Request headers**</span></span>

- <span data-ttu-id="c78d6-279">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-279">None</span></span>

<span data-ttu-id="c78d6-280">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-280">**Request body**</span></span>

- <span data-ttu-id="c78d6-281">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-281">None</span></span>

<span data-ttu-id="c78d6-282">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-282">**Response**</span></span>

<span data-ttu-id="c78d6-283">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-283">**Status code**</span></span>

<span data-ttu-id="c78d6-284">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-284">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-285">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-285">HTTP status code</span></span>      | <span data-ttu-id="c78d6-286">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-286">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-287">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-287">200</span></span> | <span data-ttu-id="c78d6-288">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-288">OK</span></span> | 
| <span data-ttu-id="c78d6-289">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-289">4XX</span></span> | <span data-ttu-id="c78d6-290">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-290">Error codes</span></span> |
| <span data-ttu-id="c78d6-291">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-291">5XX</span></span> | <span data-ttu-id="c78d6-292">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-292">Error codes</span></span> |

<span data-ttu-id="c78d6-293">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-293">**Available device families**</span></span>

* <span data-ttu-id="c78d6-294">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-294">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-295">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-295">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-296">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-296">Xbox</span></span>
* <span data-ttu-id="c78d6-297">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-297">HoloLens</span></span>
* <span data-ttu-id="c78d6-298">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-298">IoT</span></span>

<hr>

### <a name="get-installed-apps"></a><span data-ttu-id="c78d6-299">インストールされたアプリを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-299">Get installed apps</span></span>

<span data-ttu-id="c78d6-300">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-300">**Request**</span></span>

<span data-ttu-id="c78d6-301">次の要求形式を使用して、システムにインストールされているアプリの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-301">You can get a list of apps installed on the system by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-302">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-302">Method</span></span>      | <span data-ttu-id="c78d6-303">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-303">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-304">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-304">GET</span></span> | <span data-ttu-id="c78d6-305">/api/app/packagemanager/packages</span><span class="sxs-lookup"><span data-stu-id="c78d6-305">/api/app/packagemanager/packages</span></span> |


<span data-ttu-id="c78d6-306">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-306">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-307">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-307">None</span></span>

<span data-ttu-id="c78d6-308">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-308">**Request headers**</span></span>

- <span data-ttu-id="c78d6-309">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-309">None</span></span>

<span data-ttu-id="c78d6-310">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-310">**Request body**</span></span>

- <span data-ttu-id="c78d6-311">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-311">None</span></span>

<span data-ttu-id="c78d6-312">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-312">**Response**</span></span>

<span data-ttu-id="c78d6-313">応答には、インストールされているパッケージの一覧と関連する詳細情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-313">The response includes a list of installed packages with associated details.</span></span> <span data-ttu-id="c78d6-314">この応答のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-314">The template for this response is as follows.</span></span>
```json
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
<span data-ttu-id="c78d6-315">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-315">**Status code**</span></span>

<span data-ttu-id="c78d6-316">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-316">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-317">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-317">HTTP status code</span></span>      | <span data-ttu-id="c78d6-318">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-318">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-319">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-319">200</span></span> | <span data-ttu-id="c78d6-320">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-320">OK</span></span> | 
| <span data-ttu-id="c78d6-321">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-321">4XX</span></span> | <span data-ttu-id="c78d6-322">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-322">Error codes</span></span> |
| <span data-ttu-id="c78d6-323">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-323">5XX</span></span> | <span data-ttu-id="c78d6-324">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-324">Error codes</span></span> |

<span data-ttu-id="c78d6-325">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-325">**Available device families**</span></span>

* <span data-ttu-id="c78d6-326">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-326">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-327">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-327">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-328">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-328">Xbox</span></span>
* <span data-ttu-id="c78d6-329">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-329">HoloLens</span></span>
* <span data-ttu-id="c78d6-330">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-330">IoT</span></span>

<hr>

## <a name="bluetooth"></a><span data-ttu-id="c78d6-331">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="c78d6-331">Bluetooth</span></span>

<hr>

### <a name="get-the-bluetooth-radios-on-the-machine"></a><span data-ttu-id="c78d6-332">コンピューターの Bluetooth 無線を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-332">Get the Bluetooth radios on the machine</span></span>

<span data-ttu-id="c78d6-333">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-333">**Request**</span></span>

<span data-ttu-id="c78d6-334">次の要求形式を使用して、コンピューターにインストールされている Bluetooth 無線の一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-334">You can get a list of the Bluetooth radios that are installed on the machine by using the following request format.</span></span> <span data-ttu-id="c78d6-335">これは、同じ JSON データを同様に、WebSocket 接続にアップグレードできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-335">This can be upgraded to a WebSocket connection as well, with the same JSON data.</span></span>
 
| <span data-ttu-id="c78d6-336">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-336">Method</span></span>        | <span data-ttu-id="c78d6-337">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-337">Request URI</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-338">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-338">GET</span></span>           | <span data-ttu-id="c78d6-339">/api/bt/getradios</span><span class="sxs-lookup"><span data-stu-id="c78d6-339">/api/bt/getradios</span></span> |
| <span data-ttu-id="c78d6-340">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="c78d6-340">GET/WebSocket</span></span> | <span data-ttu-id="c78d6-341">/api/bt/getradios</span><span class="sxs-lookup"><span data-stu-id="c78d6-341">/api/bt/getradios</span></span> |


<span data-ttu-id="c78d6-342">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-342">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-343">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-343">None</span></span>

<span data-ttu-id="c78d6-344">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-344">**Request headers**</span></span>

- <span data-ttu-id="c78d6-345">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-345">None</span></span>

<span data-ttu-id="c78d6-346">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-346">**Request body**</span></span>

- <span data-ttu-id="c78d6-347">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-347">None</span></span>

<span data-ttu-id="c78d6-348">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-348">**Response**</span></span>

<span data-ttu-id="c78d6-349">応答には、デバイスにアタッチされている Bluetooth 無線の JSON 配列が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-349">The response includes a JSON array of Bluetooth radios attached to the device.</span></span>
```json
{"BluetoothRadios" : [
    {
        "BluetoothAddress" : int64,
        "DisplayName" : string,
        "HasUnknownUsbDevice" : boolean,
        "HasProblem" : boolean,
        "ID" : string,
        "ProblemCode" : int,
        "State" : string
    },...
]}
```
<span data-ttu-id="c78d6-350">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-350">**Status code**</span></span>

<span data-ttu-id="c78d6-351">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-351">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-352">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-352">HTTP status code</span></span> | <span data-ttu-id="c78d6-353">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-353">Description</span></span> |
| :------             | :------ |
| <span data-ttu-id="c78d6-354">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-354">200</span></span>              | <span data-ttu-id="c78d6-355">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-355">OK</span></span> |
| <span data-ttu-id="c78d6-356">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-356">4XX</span></span>              | <span data-ttu-id="c78d6-357">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-357">Error codes</span></span> |
| <span data-ttu-id="c78d6-358">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-358">5XX</span></span>              | <span data-ttu-id="c78d6-359">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-359">Error codes</span></span> |

<span data-ttu-id="c78d6-360">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-360">**Available device families**</span></span>

* <span data-ttu-id="c78d6-361">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-361">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-362">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-362">HoloLens</span></span>
* <span data-ttu-id="c78d6-363">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-363">IoT</span></span>

<hr>

### <a name="turn-the-bluetooth-radio-on-or-off"></a><span data-ttu-id="c78d6-364">Bluetooth 無線をオンまたはオフにします。</span><span class="sxs-lookup"><span data-stu-id="c78d6-364">Turn the Bluetooth radio on or off</span></span>

<span data-ttu-id="c78d6-365">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-365">**Request**</span></span>

<span data-ttu-id="c78d6-366">特定の Bluetooth 無線をオンまたはオフに設定します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-366">Sets a specific Bluetooth radio to On or Off.</span></span>
 
| <span data-ttu-id="c78d6-367">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-367">Method</span></span> | <span data-ttu-id="c78d6-368">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-368">Request URI</span></span> |
| :------   | :------ |
| <span data-ttu-id="c78d6-369">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-369">POST</span></span>   | <span data-ttu-id="c78d6-370">/api/bt/setradio</span><span class="sxs-lookup"><span data-stu-id="c78d6-370">/api/bt/setradio</span></span> |

<span data-ttu-id="c78d6-371">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-371">**URI parameters**</span></span>

<span data-ttu-id="c78d6-372">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-372">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-373">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-373">URI parameter</span></span> | <span data-ttu-id="c78d6-374">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-374">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-375">ID</span><span class="sxs-lookup"><span data-stu-id="c78d6-375">ID</span></span>            | <span data-ttu-id="c78d6-376">(**必須**) Bluetooth 無線のデバイス ID であり、base 64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-376">(**required**) The device ID for the Bluetooth radio and must be base 64 encoded.</span></span> |
| <span data-ttu-id="c78d6-377">状態</span><span class="sxs-lookup"><span data-stu-id="c78d6-377">State</span></span>         | <span data-ttu-id="c78d6-378">(**必要**) これは、`"On"`または`"Off"`します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-378">(**required**) This can be `"On"` or `"Off"`.</span></span> |

<span data-ttu-id="c78d6-379">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-379">**Request headers**</span></span>

- <span data-ttu-id="c78d6-380">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-380">None</span></span>

<span data-ttu-id="c78d6-381">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-381">**Request body**</span></span>

- <span data-ttu-id="c78d6-382">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-382">None</span></span>

<span data-ttu-id="c78d6-383">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-383">**Response**</span></span>

<span data-ttu-id="c78d6-384">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-384">**Status code**</span></span>

<span data-ttu-id="c78d6-385">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-385">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-386">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-386">HTTP status code</span></span> | <span data-ttu-id="c78d6-387">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-387">Description</span></span> |
| :------             | :------ |
| <span data-ttu-id="c78d6-388">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-388">200</span></span>              | <span data-ttu-id="c78d6-389">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-389">OK</span></span> |
| <span data-ttu-id="c78d6-390">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-390">4XX</span></span>              | <span data-ttu-id="c78d6-391">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-391">Error codes</span></span> |
| <span data-ttu-id="c78d6-392">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-392">5XX</span></span>              | <span data-ttu-id="c78d6-393">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-393">Error codes</span></span> |

<span data-ttu-id="c78d6-394">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-394">**Available device families**</span></span>

* <span data-ttu-id="c78d6-395">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-395">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-396">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-396">HoloLens</span></span>
* <span data-ttu-id="c78d6-397">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-397">IoT</span></span>

---
### <a name="get-a-list-of-paired-bluetooth-devices"></a><span data-ttu-id="c78d6-398">ペアリングされた Bluetooth デバイスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-398">Get a list of paired Bluetooth devices</span></span>

<span data-ttu-id="c78d6-399">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-399">**Request**</span></span>

<span data-ttu-id="c78d6-400">次の要求形式を使用して、ペアになっている現在の Bluetooth デバイスの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-400">You can get a list of the currently paired Bluetooth devices by using the following request format.</span></span> <span data-ttu-id="c78d6-401">これは、同じ JSON データで WebSocket 接続にアップグレードできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-401">This can be upgraded to a WebSocket connection with the same JSON data.</span></span> <span data-ttu-id="c78d6-402">WebSocket 接続の有効期間中、デバイスの一覧を変更できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-402">During the lifetime of the WebSocket connection, the device list can change.</span></span> <span data-ttu-id="c78d6-403">デバイスの完全な一覧は、更新プログラムがあるたびに WebSocket 接続経由で送信されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-403">A complete list of devices will be sent over the WebSocket connection each time there is an update.</span></span>

| <span data-ttu-id="c78d6-404">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-404">Method</span></span>        | <span data-ttu-id="c78d6-405">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-405">Request URI</span></span>       |
| :---          | :---              |
| <span data-ttu-id="c78d6-406">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-406">GET</span></span>           | <span data-ttu-id="c78d6-407">/api/bt/getpaired</span><span class="sxs-lookup"><span data-stu-id="c78d6-407">/api/bt/getpaired</span></span> |
| <span data-ttu-id="c78d6-408">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="c78d6-408">GET/WebSocket</span></span> | <span data-ttu-id="c78d6-409">/api/bt/getpaired</span><span class="sxs-lookup"><span data-stu-id="c78d6-409">/api/bt/getpaired</span></span> |

<span data-ttu-id="c78d6-410">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-410">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-411">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-411">None</span></span>

<span data-ttu-id="c78d6-412">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-412">**Request headers**</span></span>

- <span data-ttu-id="c78d6-413">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-413">None</span></span>

<span data-ttu-id="c78d6-414">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-414">**Request body**</span></span>

- <span data-ttu-id="c78d6-415">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-415">None</span></span>

<span data-ttu-id="c78d6-416">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-416">**Response**</span></span>

<span data-ttu-id="c78d6-417">応答には、現在はペアになっている Bluetooth デバイスの JSON 配列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-417">The response includes a JSON array of Bluetooth devices that are currently paired.</span></span>
```json
{"PairedDevices": [
    {
        "Name" : string,
        "ID" : string,
        "AudioConnectionStatus" : string
    },...
]}
```
<span data-ttu-id="c78d6-418">*AudioConnectionStatus*フィールドが存在するは、このシステムでのオーディオ デバイスを使用できる場合になります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-418">The *AudioConnectionStatus* field will be present if the device can be used for audio on this system.</span></span> <span data-ttu-id="c78d6-419">(ポリシーと省略可能なコンポーネントが影響。)*AudioConnectionStatus* 「接続済み」または「切断」のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-419">(Policies and optional components may affect this.) *AudioConnectionStatus* will be either "Connected" or "Disconnected".</span></span>

---
### <a name="get-a-list-of-available-bluetooth-devices"></a><span data-ttu-id="c78d6-420">使用可能な Bluetooth デバイスの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-420">Get a list of available Bluetooth devices</span></span>

<span data-ttu-id="c78d6-421">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-421">**Request**</span></span>

<span data-ttu-id="c78d6-422">次の要求形式を使用してペアリングの Bluetooth デバイスの一覧を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-422">You can get a list of the Bluetooth devices available for pairing by using the following request format.</span></span> <span data-ttu-id="c78d6-423">これは、同じ JSON データで WebSocket 接続にアップグレードできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-423">This can be upgraded to a WebSocket connection with the same JSON data.</span></span> <span data-ttu-id="c78d6-424">WebSocket 接続の有効期間中、デバイスの一覧を変更できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-424">During the lifetime of the WebSocket connection, the device list can change.</span></span> <span data-ttu-id="c78d6-425">デバイスの完全な一覧は、更新プログラムがあるたびに WebSocket 接続経由で送信されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-425">A complete list of devices will be sent over the WebSocket connection each time there is an update.</span></span>

| <span data-ttu-id="c78d6-426">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-426">Method</span></span>        | <span data-ttu-id="c78d6-427">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-427">Request URI</span></span>          |
| :---          | :---                 |
| <span data-ttu-id="c78d6-428">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-428">GET</span></span>           | <span data-ttu-id="c78d6-429">/api/bt/getavailable</span><span class="sxs-lookup"><span data-stu-id="c78d6-429">/api/bt/getavailable</span></span> |
| <span data-ttu-id="c78d6-430">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="c78d6-430">GET/WebSocket</span></span> | <span data-ttu-id="c78d6-431">/api/bt/getavailable</span><span class="sxs-lookup"><span data-stu-id="c78d6-431">/api/bt/getavailable</span></span> |

<span data-ttu-id="c78d6-432">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-432">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-433">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-433">None</span></span>

<span data-ttu-id="c78d6-434">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-434">**Request headers**</span></span>

- <span data-ttu-id="c78d6-435">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-435">None</span></span>

<span data-ttu-id="c78d6-436">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-436">**Request body**</span></span>

- <span data-ttu-id="c78d6-437">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-437">None</span></span>

<span data-ttu-id="c78d6-438">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-438">**Response**</span></span>

<span data-ttu-id="c78d6-439">応答には、ペアリングには現在使用できる Bluetooth デバイスの JSON 配列が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-439">The response includes a JSON array of Bluetooth devices that are currently available for pairing.</span></span>
```json
{"AvailableDevices": [
    {
        "Name" : string,
        "ID" : string
    },...
]}
```

---
### <a name="connect-a-bluetooth-device"></a><span data-ttu-id="c78d6-440">Bluetooth デバイスを接続します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-440">Connect a Bluetooth device</span></span>

<span data-ttu-id="c78d6-441">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-441">**Request**</span></span>

<span data-ttu-id="c78d6-442">このシステムでのオーディオ デバイスを使用できる場合、デバイスに接続されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-442">Will connect to the device if the device can be used for audio on this system.</span></span> <span data-ttu-id="c78d6-443">(ポリシーと省略可能なコンポーネントが影響。)</span><span class="sxs-lookup"><span data-stu-id="c78d6-443">(Policies and optional components may affect this.)</span></span>

| <span data-ttu-id="c78d6-444">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-444">Method</span></span>       | <span data-ttu-id="c78d6-445">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-445">Request URI</span></span>           |
| :---         | :---                  |
| <span data-ttu-id="c78d6-446">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-446">POST</span></span>         | <span data-ttu-id="c78d6-447">/api/bt/connectdevice</span><span class="sxs-lookup"><span data-stu-id="c78d6-447">/api/bt/connectdevice</span></span> |

<span data-ttu-id="c78d6-448">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-448">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-449">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-449">URI parameter</span></span> | <span data-ttu-id="c78d6-450">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-450">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-451">ID</span><span class="sxs-lookup"><span data-stu-id="c78d6-451">ID</span></span>            | <span data-ttu-id="c78d6-452">(**必要**)、Bluetooth デバイスの関連付けのエンドポイント ID と Base64 でエンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-452">(**required**) The Association Endpoint ID for the Bluetooth device and must be Base64-encoded.</span></span> |

<span data-ttu-id="c78d6-453">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-453">**Request headers**</span></span>

- <span data-ttu-id="c78d6-454">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-454">None</span></span>

<span data-ttu-id="c78d6-455">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-455">**Request body**</span></span>

- <span data-ttu-id="c78d6-456">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-456">None</span></span>

<span data-ttu-id="c78d6-457">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-457">**Response**</span></span>

<span data-ttu-id="c78d6-458">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-458">**Status code**</span></span>

<span data-ttu-id="c78d6-459">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-459">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-460">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-460">HTTP status code</span></span> | <span data-ttu-id="c78d6-461">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-461">Description</span></span> |
| :---             | :--- |
| <span data-ttu-id="c78d6-462">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-462">200</span></span>              | <span data-ttu-id="c78d6-463">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-463">OK</span></span> |
| <span data-ttu-id="c78d6-464">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-464">4XX</span></span>              | <span data-ttu-id="c78d6-465">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-465">Error codes</span></span> |
| <span data-ttu-id="c78d6-466">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-466">5XX</span></span>              | <span data-ttu-id="c78d6-467">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-467">Error codes</span></span> |

<span data-ttu-id="c78d6-468">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-468">**Available device families**</span></span>

* <span data-ttu-id="c78d6-469">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-469">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-470">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-470">HoloLens</span></span>
* <span data-ttu-id="c78d6-471">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-471">IoT</span></span>


---
### <a name="disconnect-a-bluetooth-device"></a><span data-ttu-id="c78d6-472">Bluetooth デバイスを切断します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-472">Disconnect a Bluetooth device</span></span>

<span data-ttu-id="c78d6-473">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-473">**Request**</span></span>

<span data-ttu-id="c78d6-474">このシステムでのオーディオ デバイスを使用できる場合、デバイスが切断されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-474">Will disconnect the device if the device can be used for audio on this system.</span></span> <span data-ttu-id="c78d6-475">(ポリシーと省略可能なコンポーネントが影響。)</span><span class="sxs-lookup"><span data-stu-id="c78d6-475">(Policies and optional components may affect this.)</span></span>

| <span data-ttu-id="c78d6-476">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-476">Method</span></span>       | <span data-ttu-id="c78d6-477">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-477">Request URI</span></span>              |
| :---         | :---                     |
| <span data-ttu-id="c78d6-478">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-478">POST</span></span>         | <span data-ttu-id="c78d6-479">/api/bt/disconnectdevice</span><span class="sxs-lookup"><span data-stu-id="c78d6-479">/api/bt/disconnectdevice</span></span> |

<span data-ttu-id="c78d6-480">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-480">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-481">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-481">URI parameter</span></span> | <span data-ttu-id="c78d6-482">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-482">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-483">ID</span><span class="sxs-lookup"><span data-stu-id="c78d6-483">ID</span></span>            | <span data-ttu-id="c78d6-484">(**必要**)、Bluetooth デバイスの関連付けのエンドポイント ID と Base64 でエンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-484">(**required**) The Association Endpoint ID for the Bluetooth device and must be Base64-encoded.</span></span> |

<span data-ttu-id="c78d6-485">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-485">**Request headers**</span></span>

- <span data-ttu-id="c78d6-486">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-486">None</span></span>

<span data-ttu-id="c78d6-487">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-487">**Request body**</span></span>

- <span data-ttu-id="c78d6-488">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-488">None</span></span>

<span data-ttu-id="c78d6-489">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-489">**Response**</span></span>

<span data-ttu-id="c78d6-490">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-490">**Status code**</span></span>

<span data-ttu-id="c78d6-491">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-491">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-492">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-492">HTTP status code</span></span> | <span data-ttu-id="c78d6-493">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-493">Description</span></span> |
| :---             | :--- |
| <span data-ttu-id="c78d6-494">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-494">200</span></span>              | <span data-ttu-id="c78d6-495">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-495">OK</span></span> |
| <span data-ttu-id="c78d6-496">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-496">4XX</span></span>              | <span data-ttu-id="c78d6-497">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-497">Error codes</span></span> |
| <span data-ttu-id="c78d6-498">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-498">5XX</span></span>              | <span data-ttu-id="c78d6-499">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-499">Error codes</span></span> |

<span data-ttu-id="c78d6-500">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-500">**Available device families**</span></span>

* <span data-ttu-id="c78d6-501">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-501">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-502">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-502">HoloLens</span></span>
* <span data-ttu-id="c78d6-503">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-503">IoT</span></span>

---
## <a name="device-manager"></a><span data-ttu-id="c78d6-504">デバイス マネージャー</span><span class="sxs-lookup"><span data-stu-id="c78d6-504">Device manager</span></span>
<hr>

### <a name="get-the-installed-devices-on-the-machine"></a><span data-ttu-id="c78d6-505">コンピューターにインストールされているデバイスを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-505">Get the installed devices on the machine</span></span>

<span data-ttu-id="c78d6-506">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-506">**Request**</span></span>

<span data-ttu-id="c78d6-507">次の要求形式を使用して、コンピューターにインストールされているデバイスの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-507">You can get a list of devices that are installed on the machine by using the following request format.</span></span>

| <span data-ttu-id="c78d6-508">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-508">Method</span></span>      | <span data-ttu-id="c78d6-509">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-509">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-510">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-510">GET</span></span> | <span data-ttu-id="c78d6-511">/api/devicemanager/devices</span><span class="sxs-lookup"><span data-stu-id="c78d6-511">/api/devicemanager/devices</span></span> |

<span data-ttu-id="c78d6-512">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-512">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-513">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-513">None</span></span>

<span data-ttu-id="c78d6-514">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-514">**Request headers**</span></span>

- <span data-ttu-id="c78d6-515">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-515">None</span></span>

<span data-ttu-id="c78d6-516">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-516">**Request body**</span></span>

- <span data-ttu-id="c78d6-517">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-517">None</span></span>

<span data-ttu-id="c78d6-518">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-518">**Response**</span></span>

<span data-ttu-id="c78d6-519">応答には、デバイスにアタッチされているデバイスの JSON 配列が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-519">The response includes a JSON array of devices attached to the device.</span></span>
```json
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

<span data-ttu-id="c78d6-520">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-520">**Status code**</span></span>

<span data-ttu-id="c78d6-521">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-521">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-522">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-522">HTTP status code</span></span>      | <span data-ttu-id="c78d6-523">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-523">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-524">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-524">200</span></span> | <span data-ttu-id="c78d6-525">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-525">OK</span></span> | 
| <span data-ttu-id="c78d6-526">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-526">4XX</span></span> | <span data-ttu-id="c78d6-527">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-527">Error codes</span></span> |
| <span data-ttu-id="c78d6-528">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-528">5XX</span></span> | <span data-ttu-id="c78d6-529">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-529">Error codes</span></span> |

<span data-ttu-id="c78d6-530">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-530">**Available device families**</span></span>

* <span data-ttu-id="c78d6-531">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-531">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-532">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-532">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-533">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-533">IoT</span></span>

<hr>

### <a name="get-data-on-connected-usb-deviceshubs"></a><span data-ttu-id="c78d6-534">接続された USB デバイス/ハブのデータを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-534">Get data on connected USB Devices/Hubs</span></span>

<span data-ttu-id="c78d6-535">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-535">**Request**</span></span>

<span data-ttu-id="c78d6-536">次の要求形式を使用して、接続された USB デバイスおよびハブの USB 記述子の一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-536">You can get a list of USB descriptors for connected USB devices and Hubs by using the following request format.</span></span>

| <span data-ttu-id="c78d6-537">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-537">Method</span></span>      | <span data-ttu-id="c78d6-538">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-538">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-539">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-539">GET</span></span> | <span data-ttu-id="c78d6-540">/ext/devices/usbdevices</span><span class="sxs-lookup"><span data-stu-id="c78d6-540">/ext/devices/usbdevices</span></span> |


<span data-ttu-id="c78d6-541">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-541">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-542">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-542">None</span></span>

<span data-ttu-id="c78d6-543">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-543">**Request headers**</span></span>

- <span data-ttu-id="c78d6-544">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-544">None</span></span>

<span data-ttu-id="c78d6-545">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-545">**Request body**</span></span>

- <span data-ttu-id="c78d6-546">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-546">None</span></span>

<span data-ttu-id="c78d6-547">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-547">**Response**</span></span>

<span data-ttu-id="c78d6-548">応答は、ハブの USB 記述子およびポート情報と共に、USB デバイスのデバイス ID が含まれる JSON です。</span><span class="sxs-lookup"><span data-stu-id="c78d6-548">The response is JSON that includes DeviceID for the USB Device along with the USB Descriptors and port information for hubs.</span></span>
```json
{
    "DeviceList": [
        {
        "ID": string,
        "ParentID": string, // Will equal an "ID" within the list, or be blank
        "Description": string, // optional
        "Manufacturer": string, // optional
        "ProblemCode": int, // optional
        "StatusCode": int // optional
        },
        ...
    ]
}
```

<span data-ttu-id="c78d6-549">**サンプル データを返す**</span><span class="sxs-lookup"><span data-stu-id="c78d6-549">**Sample return data**</span></span>
```json
{
    "DeviceList": [{
        "ID": "System",
        "ParentID": ""
    }, {
        "Class": "USB",
        "Description": "Texas Instruments USB 3.0 xHCI Host Controller",
        "ID": "PCI\\VEN_104C&DEV_8241&SUBSYS_1589103C&REV_02\\4&37085792&0&00E7",
        "Manufacturer": "Texas Instruments",
        "ParentID": "System",
        "ProblemCode": 0,
        "StatusCode": 25174026
    }, {
        "Class": "USB",
        "Description": "USB Composite Device",
        "DeviceDriverKey": "{36fc9e60-c465-11cf-8056-444553540000}\\0016",
        "ID": "USB\\VID_045E&PID_00DB\\8&2994096B&0&1",
        "Manufacturer": "(Standard USB Host Controller)",
        "ParentID": "USB\\VID_0557&PID_8021\\7&2E9A8711&0&4",
        "ProblemCode": 0,
        "StatusCode": 25182218
    }]
}
```

<span data-ttu-id="c78d6-550">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-550">**Status code**</span></span>

<span data-ttu-id="c78d6-551">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-551">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-552">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-552">HTTP status code</span></span>      | <span data-ttu-id="c78d6-553">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-553">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-554">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-554">200</span></span> | <span data-ttu-id="c78d6-555">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-555">OK</span></span> | 
| <span data-ttu-id="c78d6-556">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-556">5XX</span></span> | <span data-ttu-id="c78d6-557">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-557">Error codes</span></span> |

<span data-ttu-id="c78d6-558">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-558">**Available device families**</span></span>

* <span data-ttu-id="c78d6-559">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-559">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-560">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-560">IoT</span></span>

<hr>

## <a name="dump-collection"></a><span data-ttu-id="c78d6-561">ダンプの収集</span><span class="sxs-lookup"><span data-stu-id="c78d6-561">Dump collection</span></span>

<hr>

### <a name="get-the-list-of-all-crash-dumps-for-apps"></a><span data-ttu-id="c78d6-562">アプリのすべてのクラッシュ ダンプの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-562">Get the list of all crash dumps for apps</span></span>

<span data-ttu-id="c78d6-563">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-563">**Request**</span></span>

<span data-ttu-id="c78d6-564">次の要求形式を使用して、サイドローディングされたすべてのアプリについて、利用可能なすべてのクラッシュ ダンプの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-564">You can get the list of all the available crash dumps for all sideloaded apps by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-565">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-565">Method</span></span>      | <span data-ttu-id="c78d6-566">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-566">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-567">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-567">GET</span></span> | <span data-ttu-id="c78d6-568">/api/debug/dump/usermode/dumps</span><span class="sxs-lookup"><span data-stu-id="c78d6-568">/api/debug/dump/usermode/dumps</span></span> |


<span data-ttu-id="c78d6-569">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-569">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-570">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-570">None</span></span>

<span data-ttu-id="c78d6-571">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-571">**Request headers**</span></span>

- <span data-ttu-id="c78d6-572">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-572">None</span></span>

<span data-ttu-id="c78d6-573">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-573">**Request body**</span></span>

- <span data-ttu-id="c78d6-574">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-574">None</span></span>

<span data-ttu-id="c78d6-575">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-575">**Response**</span></span>

<span data-ttu-id="c78d6-576">応答には、サイドローディングされたアプリケーションごとにクラッシュ ダンプの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-576">The response includes a list of crash dumps for each sideloaded application.</span></span>

<span data-ttu-id="c78d6-577">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-577">**Status code**</span></span>

<span data-ttu-id="c78d6-578">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-578">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-579">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-579">HTTP status code</span></span>      | <span data-ttu-id="c78d6-580">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-580">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-581">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-581">200</span></span> | <span data-ttu-id="c78d6-582">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-582">OK</span></span> | 
| <span data-ttu-id="c78d6-583">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-583">4XX</span></span> | <span data-ttu-id="c78d6-584">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-584">Error codes</span></span> |
| <span data-ttu-id="c78d6-585">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-585">5XX</span></span> | <span data-ttu-id="c78d6-586">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-586">Error codes</span></span> |

<span data-ttu-id="c78d6-587">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-587">**Available device families**</span></span>

* <span data-ttu-id="c78d6-588">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="c78d6-588">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="c78d6-589">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-589">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-590">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-590">HoloLens</span></span>
* <span data-ttu-id="c78d6-591">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-591">IoT</span></span>

<hr>

### <a name="get-the-crash-dump-collection-settings-for-an-app"></a><span data-ttu-id="c78d6-592">アプリのクラッシュ ダンプ収集設定を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-592">Get the crash dump collection settings for an app</span></span>

<span data-ttu-id="c78d6-593">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-593">**Request**</span></span>

<span data-ttu-id="c78d6-594">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプ収集設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-594">You can get the crash dump collection settings for a sideloaded app by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-595">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-595">Method</span></span>      | <span data-ttu-id="c78d6-596">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-596">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-597">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-597">GET</span></span> | <span data-ttu-id="c78d6-598">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="c78d6-598">/api/debug/dump/usermode/crashcontrol</span></span> |


<span data-ttu-id="c78d6-599">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-599">**URI parameters**</span></span>

<span data-ttu-id="c78d6-600">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-600">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-601">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-601">URI parameter</span></span> | <span data-ttu-id="c78d6-602">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-602">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-603">packageFullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-603">packageFullname</span></span>   | <span data-ttu-id="c78d6-604">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-604">(**required**) The full name of the package for the sideloaded app.</span></span> |

<span data-ttu-id="c78d6-605">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-605">**Request headers**</span></span>

- <span data-ttu-id="c78d6-606">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-606">None</span></span>

<span data-ttu-id="c78d6-607">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-607">**Request body**</span></span>

- <span data-ttu-id="c78d6-608">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-608">None</span></span>

<span data-ttu-id="c78d6-609">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-609">**Response**</span></span>

<span data-ttu-id="c78d6-610">応答は、次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-610">The response has the following format.</span></span>
```json
{"CrashDumpEnabled": bool}
```

<span data-ttu-id="c78d6-611">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-611">**Status code**</span></span>

<span data-ttu-id="c78d6-612">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-612">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-613">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-613">HTTP status code</span></span>      | <span data-ttu-id="c78d6-614">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-614">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-615">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-615">200</span></span> | <span data-ttu-id="c78d6-616">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-616">OK</span></span> | 
| <span data-ttu-id="c78d6-617">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-617">4XX</span></span> | <span data-ttu-id="c78d6-618">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-618">Error codes</span></span> |
| <span data-ttu-id="c78d6-619">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-619">5XX</span></span> | <span data-ttu-id="c78d6-620">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-620">Error codes</span></span> |

<span data-ttu-id="c78d6-621">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-621">**Available device families**</span></span>

* <span data-ttu-id="c78d6-622">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="c78d6-622">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="c78d6-623">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-623">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-624">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-624">HoloLens</span></span>
* <span data-ttu-id="c78d6-625">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-625">IoT</span></span>

<hr>

### <a name="delete-a-crash-dump-for-a-sideloaded-app"></a><span data-ttu-id="c78d6-626">サイドローディングされたアプリのクラッシュ ダンプを削除する</span><span class="sxs-lookup"><span data-stu-id="c78d6-626">Delete a crash dump for a sideloaded app</span></span>

<span data-ttu-id="c78d6-627">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-627">**Request**</span></span>

<span data-ttu-id="c78d6-628">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを削除できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-628">You can delete a sideloaded app's crash dump by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-629">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-629">Method</span></span>      | <span data-ttu-id="c78d6-630">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-630">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-631">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-631">DELETE</span></span> | <span data-ttu-id="c78d6-632">/api/debug/dump/usermode/crashdump</span><span class="sxs-lookup"><span data-stu-id="c78d6-632">/api/debug/dump/usermode/crashdump</span></span> |


<span data-ttu-id="c78d6-633">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-633">**URI parameters**</span></span>

<span data-ttu-id="c78d6-634">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-634">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-635">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-635">URI parameter</span></span> | <span data-ttu-id="c78d6-636">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-636">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-637">packageFullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-637">packageFullname</span></span>   | <span data-ttu-id="c78d6-638">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-638">(**required**) The full name of the package for the sideloaded app.</span></span> |
| <span data-ttu-id="c78d6-639">fileName</span><span class="sxs-lookup"><span data-stu-id="c78d6-639">fileName</span></span>   | <span data-ttu-id="c78d6-640">(**必須**) 削除する必要があるダンプ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-640">(**required**) The name of the dump file that should be deleted.</span></span> |

<span data-ttu-id="c78d6-641">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-641">**Request headers**</span></span>

- <span data-ttu-id="c78d6-642">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-642">None</span></span>

<span data-ttu-id="c78d6-643">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-643">**Request body**</span></span>

- <span data-ttu-id="c78d6-644">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-644">None</span></span>

<span data-ttu-id="c78d6-645">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-645">**Response**</span></span>

<span data-ttu-id="c78d6-646">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-646">**Status code**</span></span>

<span data-ttu-id="c78d6-647">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-647">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-648">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-648">HTTP status code</span></span>      | <span data-ttu-id="c78d6-649">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-649">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-650">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-650">200</span></span> | <span data-ttu-id="c78d6-651">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-651">OK</span></span> | 
| <span data-ttu-id="c78d6-652">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-652">4XX</span></span> | <span data-ttu-id="c78d6-653">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-653">Error codes</span></span> |
| <span data-ttu-id="c78d6-654">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-654">5XX</span></span> | <span data-ttu-id="c78d6-655">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-655">Error codes</span></span> |

<span data-ttu-id="c78d6-656">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-656">**Available device families**</span></span>

* <span data-ttu-id="c78d6-657">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="c78d6-657">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="c78d6-658">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-658">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-659">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-659">HoloLens</span></span>
* <span data-ttu-id="c78d6-660">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-660">IoT</span></span>

<hr>

### <a name="disable-crash-dumps-for-a-sideloaded-app"></a><span data-ttu-id="c78d6-661">サイドローディングされたアプリのクラッシュ ダンプを無効にする</span><span class="sxs-lookup"><span data-stu-id="c78d6-661">Disable crash dumps for a sideloaded app</span></span>

<span data-ttu-id="c78d6-662">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-662">**Request**</span></span>

<span data-ttu-id="c78d6-663">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-663">You can disable crash dumps for a sideloaded app by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-664">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-664">Method</span></span>      | <span data-ttu-id="c78d6-665">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-665">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-666">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-666">DELETE</span></span> | <span data-ttu-id="c78d6-667">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="c78d6-667">/api/debug/dump/usermode/crashcontrol</span></span> |


<span data-ttu-id="c78d6-668">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-668">**URI parameters**</span></span>

<span data-ttu-id="c78d6-669">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-669">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-670">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-670">URI parameter</span></span> | <span data-ttu-id="c78d6-671">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-671">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-672">packageFullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-672">packageFullname</span></span>   | <span data-ttu-id="c78d6-673">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-673">(**required**) The full name of the package for the sideloaded app.</span></span> |

<span data-ttu-id="c78d6-674">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-674">**Request headers**</span></span>

- <span data-ttu-id="c78d6-675">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-675">None</span></span>

<span data-ttu-id="c78d6-676">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-676">**Request body**</span></span>

- <span data-ttu-id="c78d6-677">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-677">None</span></span>

<span data-ttu-id="c78d6-678">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-678">**Response**</span></span>

<span data-ttu-id="c78d6-679">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-679">**Status code**</span></span>

<span data-ttu-id="c78d6-680">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-680">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-681">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-681">HTTP status code</span></span>      | <span data-ttu-id="c78d6-682">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-682">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-683">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-683">200</span></span> | <span data-ttu-id="c78d6-684">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-684">OK</span></span> | 
| <span data-ttu-id="c78d6-685">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-685">4XX</span></span> | <span data-ttu-id="c78d6-686">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-686">Error codes</span></span> |
| <span data-ttu-id="c78d6-687">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-687">5XX</span></span> | <span data-ttu-id="c78d6-688">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-688">Error codes</span></span> |

<span data-ttu-id="c78d6-689">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-689">**Available device families**</span></span>

* <span data-ttu-id="c78d6-690">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="c78d6-690">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="c78d6-691">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-691">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-692">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-692">HoloLens</span></span>
* <span data-ttu-id="c78d6-693">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-693">IoT</span></span>

<hr>

### <a name="download-the-crash-dump-for-a-sideloaded-app"></a><span data-ttu-id="c78d6-694">サイドローディングされたアプリのクラッシュ ダンプをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="c78d6-694">Download the crash dump for a sideloaded app</span></span>

<span data-ttu-id="c78d6-695">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-695">**Request**</span></span>

<span data-ttu-id="c78d6-696">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-696">You can download a sideloaded app's crash dump by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-697">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-697">Method</span></span>      | <span data-ttu-id="c78d6-698">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-698">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-699">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-699">GET</span></span> | <span data-ttu-id="c78d6-700">/api/debug/dump/usermode/crashdump</span><span class="sxs-lookup"><span data-stu-id="c78d6-700">/api/debug/dump/usermode/crashdump</span></span> |


<span data-ttu-id="c78d6-701">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-701">**URI parameters**</span></span>

<span data-ttu-id="c78d6-702">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-702">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-703">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-703">URI parameter</span></span> | <span data-ttu-id="c78d6-704">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-704">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-705">packageFullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-705">packageFullname</span></span>   | <span data-ttu-id="c78d6-706">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-706">(**required**) The full name of the package for the sideloaded app.</span></span> |
| <span data-ttu-id="c78d6-707">fileName</span><span class="sxs-lookup"><span data-stu-id="c78d6-707">fileName</span></span>   | <span data-ttu-id="c78d6-708">(**必須**) ダウンロードするダンプ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-708">(**required**) The name of the dump file that you want to download.</span></span> |

<span data-ttu-id="c78d6-709">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-709">**Request headers**</span></span>

- <span data-ttu-id="c78d6-710">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-710">None</span></span>

<span data-ttu-id="c78d6-711">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-711">**Request body**</span></span>

- <span data-ttu-id="c78d6-712">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-712">None</span></span>

<span data-ttu-id="c78d6-713">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-713">**Response**</span></span>

<span data-ttu-id="c78d6-714">応答には、ダンプ ファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-714">The response includes a dump file.</span></span> <span data-ttu-id="c78d6-715">WinDbg または Visual Studio を使用して、ダンプ ファイルを検証できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-715">You can use WinDbg or Visual Studio to examine the dump file.</span></span>

<span data-ttu-id="c78d6-716">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-716">**Status code**</span></span>

<span data-ttu-id="c78d6-717">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-717">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-718">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-718">HTTP status code</span></span>      | <span data-ttu-id="c78d6-719">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-719">Description</span></span> |
| :------     | :----- |
|  <span data-ttu-id="c78d6-720">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-720">200</span></span> | <span data-ttu-id="c78d6-721">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-721">OK</span></span> | 
| <span data-ttu-id="c78d6-722">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-722">4XX</span></span> | <span data-ttu-id="c78d6-723">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-723">Error codes</span></span> |
| <span data-ttu-id="c78d6-724">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-724">5XX</span></span> | <span data-ttu-id="c78d6-725">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-725">Error codes</span></span> |

<span data-ttu-id="c78d6-726">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-726">**Available device families**</span></span>

* <span data-ttu-id="c78d6-727">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="c78d6-727">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="c78d6-728">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-728">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-729">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-729">HoloLens</span></span>
* <span data-ttu-id="c78d6-730">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-730">IoT</span></span>

<hr>

### <a name="enable-crash-dumps-for-a-sideloaded-app"></a><span data-ttu-id="c78d6-731">サイドローディングされたアプリのクラッシュ ダンプを有効にする</span><span class="sxs-lookup"><span data-stu-id="c78d6-731">Enable crash dumps for a sideloaded app</span></span>

<span data-ttu-id="c78d6-732">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-732">**Request**</span></span>

<span data-ttu-id="c78d6-733">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-733">You can enable crash dumps for a sideloaded app by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-734">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-734">Method</span></span>      | <span data-ttu-id="c78d6-735">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-735">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-736">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-736">POST</span></span> | <span data-ttu-id="c78d6-737">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="c78d6-737">/api/debug/dump/usermode/crashcontrol</span></span> |


<span data-ttu-id="c78d6-738">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-738">**URI parameters**</span></span>

<span data-ttu-id="c78d6-739">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-739">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-740">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-740">URI parameter</span></span> | <span data-ttu-id="c78d6-741">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-741">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-742">packageFullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-742">packageFullname</span></span>   | <span data-ttu-id="c78d6-743">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-743">(**required**) The full name of the package for the sideloaded app.</span></span> |

<span data-ttu-id="c78d6-744">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-744">**Request headers**</span></span>

- <span data-ttu-id="c78d6-745">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-745">None</span></span>

<span data-ttu-id="c78d6-746">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-746">**Request body**</span></span>

- <span data-ttu-id="c78d6-747">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-747">None</span></span>

<span data-ttu-id="c78d6-748">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-748">**Response**</span></span>

<span data-ttu-id="c78d6-749">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-749">**Status code**</span></span>

<span data-ttu-id="c78d6-750">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-750">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-751">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-751">HTTP status code</span></span>      | <span data-ttu-id="c78d6-752">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-752">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-753">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-753">200</span></span> | <span data-ttu-id="c78d6-754">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-754">OK</span></span> | 

<span data-ttu-id="c78d6-755">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-755">**Available device families**</span></span>

* <span data-ttu-id="c78d6-756">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="c78d6-756">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="c78d6-757">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-757">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-758">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-758">HoloLens</span></span>
* <span data-ttu-id="c78d6-759">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-759">IoT</span></span>

<hr>

### <a name="get-the-list-of-bugcheck-files"></a><span data-ttu-id="c78d6-760">バグチェック ファイルの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-760">Get the list of bugcheck files</span></span>

<span data-ttu-id="c78d6-761">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-761">**Request**</span></span>

<span data-ttu-id="c78d6-762">次の要求形式を使用して、バグチェックのミニダンプ ファイルの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-762">You can get the list of bugcheck minidump files by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-763">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-763">Method</span></span>      | <span data-ttu-id="c78d6-764">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-764">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-765">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-765">GET</span></span> | <span data-ttu-id="c78d6-766">/api/debug/dump/kernel/dumplist</span><span class="sxs-lookup"><span data-stu-id="c78d6-766">/api/debug/dump/kernel/dumplist</span></span> |


<span data-ttu-id="c78d6-767">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-767">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-768">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-768">None</span></span>

<span data-ttu-id="c78d6-769">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-769">**Request headers**</span></span>

- <span data-ttu-id="c78d6-770">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-770">None</span></span>

<span data-ttu-id="c78d6-771">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-771">**Request body**</span></span>

- <span data-ttu-id="c78d6-772">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-772">None</span></span>

<span data-ttu-id="c78d6-773">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-773">**Response**</span></span>

<span data-ttu-id="c78d6-774">応答には、ダンプ ファイル名とこれらのファイルのサイズの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-774">The response includes a list of dump file names and the sizes of these files.</span></span> <span data-ttu-id="c78d6-775">一覧は、次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-775">This list will be in the following format.</span></span> 
```json
{"DumpFiles": [
    {
        "FileName": string,
        "FileSize": int
    },...
]}
```

<span data-ttu-id="c78d6-776">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-776">**Status code**</span></span>

<span data-ttu-id="c78d6-777">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-777">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-778">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-778">HTTP status code</span></span>      | <span data-ttu-id="c78d6-779">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-779">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-780">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-780">200</span></span> | <span data-ttu-id="c78d6-781">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-781">OK</span></span> | 

<span data-ttu-id="c78d6-782">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-782">**Available device families**</span></span>

* <span data-ttu-id="c78d6-783">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-783">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-784">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-784">IoT</span></span>

<hr>

### <a name="download-a-bugcheck-dump-file"></a><span data-ttu-id="c78d6-785">バグチェックのダンプ ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="c78d6-785">Download a bugcheck dump file</span></span>

<span data-ttu-id="c78d6-786">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-786">**Request**</span></span>

<span data-ttu-id="c78d6-787">次の要求形式を使用して、バグチェックのダンプ ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-787">You can download a bugcheck dump file by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-788">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-788">Method</span></span>      | <span data-ttu-id="c78d6-789">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-789">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-790">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-790">GET</span></span> | <span data-ttu-id="c78d6-791">/api/debug/dump/kernel/dump</span><span class="sxs-lookup"><span data-stu-id="c78d6-791">/api/debug/dump/kernel/dump</span></span> |


<span data-ttu-id="c78d6-792">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-792">**URI parameters**</span></span>

<span data-ttu-id="c78d6-793">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-793">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-794">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-794">URI parameter</span></span> | <span data-ttu-id="c78d6-795">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-795">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-796">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="c78d6-796">filename</span></span>   | <span data-ttu-id="c78d6-797">(**必須**) ダンプ ファイルのファイル名。</span><span class="sxs-lookup"><span data-stu-id="c78d6-797">(**required**) The file name of the dump file.</span></span> <span data-ttu-id="c78d6-798">API を使ってダンプの一覧を取得することによって確認できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-798">You can find this by using the API to get the dump list.</span></span> |


<span data-ttu-id="c78d6-799">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-799">**Request headers**</span></span>

- <span data-ttu-id="c78d6-800">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-800">None</span></span>

<span data-ttu-id="c78d6-801">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-801">**Request body**</span></span>

- <span data-ttu-id="c78d6-802">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-802">None</span></span>

<span data-ttu-id="c78d6-803">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-803">**Response**</span></span>

<span data-ttu-id="c78d6-804">応答には、ダンプ ファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-804">The response includes the dump file.</span></span> <span data-ttu-id="c78d6-805">WinDbg を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-805">You can inspect this file using WinDbg.</span></span>

<span data-ttu-id="c78d6-806">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-806">**Status code**</span></span>

<span data-ttu-id="c78d6-807">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-807">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-808">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-808">HTTP status code</span></span>      | <span data-ttu-id="c78d6-809">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-809">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-810">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-810">200</span></span> | <span data-ttu-id="c78d6-811">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-811">OK</span></span> | 
| <span data-ttu-id="c78d6-812">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-812">4XX</span></span> | <span data-ttu-id="c78d6-813">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-813">Error codes</span></span> |
| <span data-ttu-id="c78d6-814">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-814">5XX</span></span> | <span data-ttu-id="c78d6-815">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-815">Error codes</span></span> |

<span data-ttu-id="c78d6-816">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-816">**Available device families**</span></span>

* <span data-ttu-id="c78d6-817">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-817">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-818">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-818">IoT</span></span>

<hr>

### <a name="get-the-bugcheck-crash-control-settings"></a><span data-ttu-id="c78d6-819">バグチェックのクラッシュ制御の設定を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-819">Get the bugcheck crash control settings</span></span>

<span data-ttu-id="c78d6-820">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-820">**Request**</span></span>

<span data-ttu-id="c78d6-821">次の要求形式を使用して、バグチェックのクラッシュ制御の設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-821">You can get the bugcheck crash control settings by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-822">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-822">Method</span></span>      | <span data-ttu-id="c78d6-823">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-823">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-824">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-824">GET</span></span> | <span data-ttu-id="c78d6-825">/api/debug/dump/kernel/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="c78d6-825">/api/debug/dump/kernel/crashcontrol</span></span> |


<span data-ttu-id="c78d6-826">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-826">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-827">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-827">None</span></span>

<span data-ttu-id="c78d6-828">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-828">**Request headers**</span></span>

- <span data-ttu-id="c78d6-829">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-829">None</span></span>

<span data-ttu-id="c78d6-830">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-830">**Request body**</span></span>

- <span data-ttu-id="c78d6-831">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-831">None</span></span>

<span data-ttu-id="c78d6-832">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-832">**Response**</span></span>

<span data-ttu-id="c78d6-833">応答には、クラッシュの制御の設定が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-833">The response includes the crash control settings.</span></span> <span data-ttu-id="c78d6-834">CrashControl について詳しくは、「[CrashControl](https://technet.microsoft.com/library/cc951703.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c78d6-834">For more information about CrashControl, see the [CrashControl](https://technet.microsoft.com/library/cc951703.aspx) article.</span></span> <span data-ttu-id="c78d6-835">応答のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-835">The template for the response is as follows.</span></span>
```json
{
    "autoreboot": bool (0 or 1),
    "dumptype": int (0 to 4),
    "maxdumpcount": int,
    "overwrite": bool (0 or 1)
}
```

<span data-ttu-id="c78d6-836">**ダンプの種類**</span><span class="sxs-lookup"><span data-stu-id="c78d6-836">**Dump types**</span></span>

<span data-ttu-id="c78d6-837">0:Disabled</span><span class="sxs-lookup"><span data-stu-id="c78d6-837">0: Disabled</span></span>

<span data-ttu-id="c78d6-838">1:完全メモリ ダンプを (すべての使用中のメモリを収集します)</span><span class="sxs-lookup"><span data-stu-id="c78d6-838">1: Complete memory dump (collects all in-use memory)</span></span>

<span data-ttu-id="c78d6-839">2:カーネル メモリ ダンプが (ユーザー モードのメモリは無視されます)</span><span class="sxs-lookup"><span data-stu-id="c78d6-839">2: Kernel memory dump (ignores user mode memory)</span></span>

<span data-ttu-id="c78d6-840">3:制限付きのカーネルのミニダンプ</span><span class="sxs-lookup"><span data-stu-id="c78d6-840">3: Limited kernel minidump</span></span>

<span data-ttu-id="c78d6-841">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-841">**Status code**</span></span>

<span data-ttu-id="c78d6-842">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-842">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-843">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-843">HTTP status code</span></span>      | <span data-ttu-id="c78d6-844">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-844">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-845">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-845">200</span></span> | <span data-ttu-id="c78d6-846">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-846">OK</span></span> | 
| <span data-ttu-id="c78d6-847">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-847">4XX</span></span> | <span data-ttu-id="c78d6-848">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-848">Error codes</span></span> |
| <span data-ttu-id="c78d6-849">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-849">5XX</span></span> | <span data-ttu-id="c78d6-850">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-850">Error codes</span></span> |

<span data-ttu-id="c78d6-851">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-851">**Available device families**</span></span>

* <span data-ttu-id="c78d6-852">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-852">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-853">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-853">IoT</span></span>

<hr>

### <a name="get-a-live-kernel-dump"></a><span data-ttu-id="c78d6-854">ライブ カーネル ダンプを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-854">Get a live kernel dump</span></span>

<span data-ttu-id="c78d6-855">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-855">**Request**</span></span>

<span data-ttu-id="c78d6-856">次の要求形式を使用して、ライブ カーネル ダンプを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-856">You can get a live kernel dump by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-857">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-857">Method</span></span>      | <span data-ttu-id="c78d6-858">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-858">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-859">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-859">GET</span></span> | <span data-ttu-id="c78d6-860">/api/debug/dump/livekernel</span><span class="sxs-lookup"><span data-stu-id="c78d6-860">/api/debug/dump/livekernel</span></span> |


<span data-ttu-id="c78d6-861">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-861">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-862">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-862">None</span></span>

<span data-ttu-id="c78d6-863">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-863">**Request headers**</span></span>

- <span data-ttu-id="c78d6-864">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-864">None</span></span>

<span data-ttu-id="c78d6-865">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-865">**Request body**</span></span>

- <span data-ttu-id="c78d6-866">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-866">None</span></span>

<span data-ttu-id="c78d6-867">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-867">**Response**</span></span>

<span data-ttu-id="c78d6-868">応答には、カーネル モードの完全なダンプが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-868">The response includes the full kernel mode dump.</span></span> <span data-ttu-id="c78d6-869">WinDbg を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-869">You can inspect this file using WinDbg.</span></span>

<span data-ttu-id="c78d6-870">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-870">**Status code**</span></span>

<span data-ttu-id="c78d6-871">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-871">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-872">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-872">HTTP status code</span></span>      | <span data-ttu-id="c78d6-873">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-873">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-874">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-874">200</span></span> | <span data-ttu-id="c78d6-875">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-875">OK</span></span> | 
| <span data-ttu-id="c78d6-876">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-876">4XX</span></span> | <span data-ttu-id="c78d6-877">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-877">Error codes</span></span> |
| <span data-ttu-id="c78d6-878">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-878">5XX</span></span> | <span data-ttu-id="c78d6-879">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-879">Error codes</span></span> |

<span data-ttu-id="c78d6-880">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-880">**Available device families**</span></span>

* <span data-ttu-id="c78d6-881">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-881">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-882">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-882">IoT</span></span>

<hr>

### <a name="get-a-dump-from-a-live-user-process"></a><span data-ttu-id="c78d6-883">ライブ ユーザー プロセスからダンプを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-883">Get a dump from a live user process</span></span>

<span data-ttu-id="c78d6-884">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-884">**Request**</span></span>

<span data-ttu-id="c78d6-885">次の要求形式を使用して、ライブ ユーザー プロセスのダンプを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-885">You can get the dump for live user process by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-886">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-886">Method</span></span>      | <span data-ttu-id="c78d6-887">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-887">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-888">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-888">GET</span></span> | <span data-ttu-id="c78d6-889">/api/debug/dump/usermode/live</span><span class="sxs-lookup"><span data-stu-id="c78d6-889">/api/debug/dump/usermode/live</span></span> |


<span data-ttu-id="c78d6-890">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-890">**URI parameters**</span></span>

<span data-ttu-id="c78d6-891">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-891">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-892">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-892">URI parameter</span></span> | <span data-ttu-id="c78d6-893">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-893">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-894">pid</span><span class="sxs-lookup"><span data-stu-id="c78d6-894">pid</span></span>   | <span data-ttu-id="c78d6-895">(**必須**) 目的のプロセスの一意のプロセス ID。</span><span class="sxs-lookup"><span data-stu-id="c78d6-895">(**required**) The unique process id for the process you are interested in.</span></span> |

<span data-ttu-id="c78d6-896">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-896">**Request headers**</span></span>

- <span data-ttu-id="c78d6-897">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-897">None</span></span>

<span data-ttu-id="c78d6-898">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-898">**Request body**</span></span>

- <span data-ttu-id="c78d6-899">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-899">None</span></span>

<span data-ttu-id="c78d6-900">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-900">**Response**</span></span>

<span data-ttu-id="c78d6-901">応答には、プロセス ダンプが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-901">The response includes the process dump.</span></span> <span data-ttu-id="c78d6-902">WinDbg または Visual Studio を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-902">You can inspect this file using WinDbg or Visual Studio.</span></span>

<span data-ttu-id="c78d6-903">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-903">**Status code**</span></span>

<span data-ttu-id="c78d6-904">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-904">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-905">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-905">HTTP status code</span></span>      | <span data-ttu-id="c78d6-906">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-906">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-907">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-907">200</span></span> | <span data-ttu-id="c78d6-908">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-908">OK</span></span> | 
| <span data-ttu-id="c78d6-909">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-909">4XX</span></span> | <span data-ttu-id="c78d6-910">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-910">Error codes</span></span> |
| <span data-ttu-id="c78d6-911">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-911">5XX</span></span> | <span data-ttu-id="c78d6-912">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-912">Error codes</span></span> |

<span data-ttu-id="c78d6-913">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-913">**Available device families**</span></span>

* <span data-ttu-id="c78d6-914">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-914">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-915">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-915">IoT</span></span>

<hr>

### <a name="set-the-bugcheck-crash-control-settings"></a><span data-ttu-id="c78d6-916">バグチェックのクラッシュ制御の設定を行う</span><span class="sxs-lookup"><span data-stu-id="c78d6-916">Set the bugcheck crash control settings</span></span>

<span data-ttu-id="c78d6-917">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-917">**Request**</span></span>

<span data-ttu-id="c78d6-918">次の要求形式を使用して、バグチェック データの収集に関する設定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-918">You can set the settings for collecting bugcheck data by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-919">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-919">Method</span></span>      | <span data-ttu-id="c78d6-920">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-920">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-921">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-921">POST</span></span> | <span data-ttu-id="c78d6-922">/api/debug/dump/kernel/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="c78d6-922">/api/debug/dump/kernel/crashcontrol</span></span> |


<span data-ttu-id="c78d6-923">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-923">**URI parameters**</span></span>

<span data-ttu-id="c78d6-924">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-924">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-925">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-925">URI parameter</span></span> | <span data-ttu-id="c78d6-926">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-926">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-927">autoreboot</span><span class="sxs-lookup"><span data-stu-id="c78d6-927">autoreboot</span></span>   | <span data-ttu-id="c78d6-928">(**オプション**) true または false。</span><span class="sxs-lookup"><span data-stu-id="c78d6-928">(**optional**) True or false.</span></span> <span data-ttu-id="c78d6-929">これは、エラーやロックの発生後に、システムが自動的に再起動するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-929">This indicates whether the system restarts automatically after it fails or locks.</span></span> |
| <span data-ttu-id="c78d6-930">dumptype</span><span class="sxs-lookup"><span data-stu-id="c78d6-930">dumptype</span></span>   | <span data-ttu-id="c78d6-931">(**オプション**) dump タイプ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-931">(**optional**) The dump type.</span></span> <span data-ttu-id="c78d6-932">サポートされる値については、「[CrashDumpType 列挙体](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c78d6-932">For the supported values, see the [CrashDumpType Enumeration](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx).</span></span>|
| <span data-ttu-id="c78d6-933">maxdumpcount</span><span class="sxs-lookup"><span data-stu-id="c78d6-933">maxdumpcount</span></span>   | <span data-ttu-id="c78d6-934">(**オプション**) 保存するダンプの最大数。</span><span class="sxs-lookup"><span data-stu-id="c78d6-934">(**optional**) The maximum number of dumps to save.</span></span> |
| <span data-ttu-id="c78d6-935">overwrite</span><span class="sxs-lookup"><span data-stu-id="c78d6-935">overwrite</span></span>   | <span data-ttu-id="c78d6-936">(**オプション**) true または false。</span><span class="sxs-lookup"><span data-stu-id="c78d6-936">(**optional**) True of false.</span></span> <span data-ttu-id="c78d6-937">これは、*maxdumpcount*で指定されているダンプ カウンターの制限に達した場合に古いダンプを上書きするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-937">This indicates whether or not to overwrite old dumps when the dump counter limit specified by *maxdumpcount* has been reached.</span></span> |

<span data-ttu-id="c78d6-938">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-938">**Request headers**</span></span>

- <span data-ttu-id="c78d6-939">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-939">None</span></span>

<span data-ttu-id="c78d6-940">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-940">**Request body**</span></span>

- <span data-ttu-id="c78d6-941">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-941">None</span></span>

<span data-ttu-id="c78d6-942">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-942">**Response**</span></span>

<span data-ttu-id="c78d6-943">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-943">**Status code**</span></span>

<span data-ttu-id="c78d6-944">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-944">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-945">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-945">HTTP status code</span></span>      | <span data-ttu-id="c78d6-946">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-946">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-947">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-947">200</span></span> | <span data-ttu-id="c78d6-948">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-948">OK</span></span> | 
| <span data-ttu-id="c78d6-949">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-949">4XX</span></span> | <span data-ttu-id="c78d6-950">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-950">Error codes</span></span> |
| <span data-ttu-id="c78d6-951">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-951">5XX</span></span> | <span data-ttu-id="c78d6-952">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-952">Error codes</span></span> |

<span data-ttu-id="c78d6-953">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-953">**Available device families**</span></span>

* <span data-ttu-id="c78d6-954">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-954">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-955">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-955">IoT</span></span>

<hr>

## <a name="etw"></a><span data-ttu-id="c78d6-956">ETW</span><span class="sxs-lookup"><span data-stu-id="c78d6-956">ETW</span></span>

<hr>

### <a name="create-a-realtime-etw-session-over-a-websocket"></a><span data-ttu-id="c78d6-957">websocket 経由でリアルタイムの ETW セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="c78d6-957">Create a realtime ETW session over a websocket</span></span>

<span data-ttu-id="c78d6-958">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-958">**Request**</span></span>

<span data-ttu-id="c78d6-959">次の要求形式を使用して、リアルタイムの ETW セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-959">You can create a realtime ETW session by using the following request format.</span></span> <span data-ttu-id="c78d6-960">これは、websocket 経由で管理されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-960">This will be managed over a websocket.</span></span>  <span data-ttu-id="c78d6-961">ETW イベントは、サーバーで一括処理され、1 秒に 1 回クライアントに送信されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-961">ETW events are batched on the server and sent to the client once per second.</span></span> 
 
| <span data-ttu-id="c78d6-962">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-962">Method</span></span>      | <span data-ttu-id="c78d6-963">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-963">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-964">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="c78d6-964">GET/WebSocket</span></span> | <span data-ttu-id="c78d6-965">/api/etw/session/realtime</span><span class="sxs-lookup"><span data-stu-id="c78d6-965">/api/etw/session/realtime</span></span> |


<span data-ttu-id="c78d6-966">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-966">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-967">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-967">None</span></span>

<span data-ttu-id="c78d6-968">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-968">**Request headers**</span></span>

- <span data-ttu-id="c78d6-969">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-969">None</span></span>

<span data-ttu-id="c78d6-970">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-970">**Request body**</span></span>

- <span data-ttu-id="c78d6-971">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-971">None</span></span>

<span data-ttu-id="c78d6-972">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-972">**Response**</span></span>

<span data-ttu-id="c78d6-973">応答には、有効なプロバイダーの ETW イベントが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-973">The response includes the ETW events from the enabled providers.</span></span>  <span data-ttu-id="c78d6-974">以下の「ETW WebSocket コマンド」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c78d6-974">See ETW WebSocket commands below.</span></span> 

<span data-ttu-id="c78d6-975">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-975">**Status code**</span></span>

<span data-ttu-id="c78d6-976">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-976">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-977">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-977">HTTP status code</span></span>      | <span data-ttu-id="c78d6-978">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-978">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-979">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-979">200</span></span> | <span data-ttu-id="c78d6-980">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-980">OK</span></span> | 
| <span data-ttu-id="c78d6-981">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-981">4XX</span></span> | <span data-ttu-id="c78d6-982">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-982">Error codes</span></span> |
| <span data-ttu-id="c78d6-983">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-983">5XX</span></span> | <span data-ttu-id="c78d6-984">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-984">Error codes</span></span> |

<span data-ttu-id="c78d6-985">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-985">**Available device families**</span></span>

* <span data-ttu-id="c78d6-986">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-986">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-987">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-987">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-988">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-988">HoloLens</span></span>
* <span data-ttu-id="c78d6-989">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-989">IoT</span></span>

### <a name="etw-websocket-commands"></a><span data-ttu-id="c78d6-990">ETW WebSocket コマンド</span><span class="sxs-lookup"><span data-stu-id="c78d6-990">ETW WebSocket commands</span></span>
<span data-ttu-id="c78d6-991">次のコマンドは、クライアントからサーバーに送信されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-991">These commands are sent from the client to the server.</span></span>

| <span data-ttu-id="c78d6-992">コマンド</span><span class="sxs-lookup"><span data-stu-id="c78d6-992">Command</span></span> | <span data-ttu-id="c78d6-993">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-993">Description</span></span> |
| :----- | :----- |
| <span data-ttu-id="c78d6-994">provider *{guid}* enable *{level}*</span><span class="sxs-lookup"><span data-stu-id="c78d6-994">provider *{guid}* enable *{level}*</span></span> | <span data-ttu-id="c78d6-995">*{guid}* で指定されたプロバイダー (括弧は不要) を指定されたレベルで有効にします。</span><span class="sxs-lookup"><span data-stu-id="c78d6-995">Enable the provider marked by *{guid}* (without brackets) at the specified level.</span></span> <span data-ttu-id="c78d6-996">*{level}* は、1 (最小限の詳細) ～ 5 (詳細) の **int** です。</span><span class="sxs-lookup"><span data-stu-id="c78d6-996">*{level}* is an **int** from 1 (least detail) to 5 (verbose).</span></span> |
| <span data-ttu-id="c78d6-997">provider *{guid}* disable</span><span class="sxs-lookup"><span data-stu-id="c78d6-997">provider *{guid}* disable</span></span> | <span data-ttu-id="c78d6-998">*{guid}* で指定されたプロバイダー (括弧は不要) を無効にします。</span><span class="sxs-lookup"><span data-stu-id="c78d6-998">Disable the provider marked by *{guid}* (without brackets).</span></span> |

<span data-ttu-id="c78d6-999">この応答は、サーバーからクライアントに送信されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-999">This responses is sent from the server to the client.</span></span> <span data-ttu-id="c78d6-1000">これは、テキストとして送信され、JSON で解析すると次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1000">This is sent as text and you get the following format by parsing the JSON.</span></span>
```json
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

<span data-ttu-id="c78d6-1001">payload objects は、追加のキーと値のペア (文字列: 文字列) で、元の ETW イベントから提供されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1001">Payload objects are extra key-value pairs (string:string) that are provided in the original ETW event.</span></span>

<span data-ttu-id="c78d6-1002">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1002">Example:</span></span>
```json
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

<hr>

### <a name="enumerate-the-registered-etw-providers"></a><span data-ttu-id="c78d6-1003">登録済みの ETW プロバイダーを列挙する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1003">Enumerate the registered ETW providers</span></span>

<span data-ttu-id="c78d6-1004">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1004">**Request**</span></span>

<span data-ttu-id="c78d6-1005">次の要求形式を使用して、登録済みプロバイダーを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1005">You can enumerate through the registered providers by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1006">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1006">Method</span></span>      | <span data-ttu-id="c78d6-1007">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1007">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1008">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1008">GET</span></span> | <span data-ttu-id="c78d6-1009">/api/etw/providers</span><span class="sxs-lookup"><span data-stu-id="c78d6-1009">/api/etw/providers</span></span> |


<span data-ttu-id="c78d6-1010">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1010">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1011">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1011">None</span></span>

<span data-ttu-id="c78d6-1012">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1012">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1013">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1013">None</span></span>

<span data-ttu-id="c78d6-1014">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1014">**Request body**</span></span>

- <span data-ttu-id="c78d6-1015">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1015">None</span></span>

<span data-ttu-id="c78d6-1016">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1016">**Response**</span></span>

<span data-ttu-id="c78d6-1017">応答には、ETW プロバイダーの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1017">The response includes the list of ETW providers.</span></span> <span data-ttu-id="c78d6-1018">一覧には、各プロバイダーのフレンドリ名と GUID が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1018">The list will include the friendly name and GUID for each provider in the following format.</span></span>
```json
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

<span data-ttu-id="c78d6-1019">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1019">**Status code**</span></span>

<span data-ttu-id="c78d6-1020">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1020">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-1021">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1021">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1022">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1022">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="c78d6-1023">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1023">200</span></span> | <span data-ttu-id="c78d6-1024">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1024">OK</span></span> | 

<span data-ttu-id="c78d6-1025">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1025">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1026">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1026">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1027">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1027">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1028">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1028">HoloLens</span></span>
* <span data-ttu-id="c78d6-1029">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1029">IoT</span></span>

<hr>

### <a name="enumerate-the-custom-etw-providers-exposed-by-the-platform"></a><span data-ttu-id="c78d6-1030">プラットフォームによって公開されているカスタム ETW プロバイダーを列挙します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1030">Enumerate the custom ETW providers exposed by the platform.</span></span>

<span data-ttu-id="c78d6-1031">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1031">**Request**</span></span>

<span data-ttu-id="c78d6-1032">次の要求形式を使用して、登録済みプロバイダーを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1032">You can enumerate through the registered providers by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1033">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1033">Method</span></span>      | <span data-ttu-id="c78d6-1034">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1034">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1035">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1035">GET</span></span> | <span data-ttu-id="c78d6-1036">/api/etw/customproviders</span><span class="sxs-lookup"><span data-stu-id="c78d6-1036">/api/etw/customproviders</span></span> |


<span data-ttu-id="c78d6-1037">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1037">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1038">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1038">None</span></span>

<span data-ttu-id="c78d6-1039">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1039">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1040">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1040">None</span></span>

<span data-ttu-id="c78d6-1041">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1041">**Request body**</span></span>

- <span data-ttu-id="c78d6-1042">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1042">None</span></span>

<span data-ttu-id="c78d6-1043">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1043">**Response**</span></span>

<span data-ttu-id="c78d6-1044">200 OK。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1044">200 OK.</span></span> <span data-ttu-id="c78d6-1045">応答には、ETW プロバイダーの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1045">The response includes the list of ETW providers.</span></span> <span data-ttu-id="c78d6-1046">一覧には、各プロバイダーのフレンドリ名と GUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1046">The list will include the friendly name and GUID for each provider.</span></span>

```json
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

<span data-ttu-id="c78d6-1047">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1047">**Status code**</span></span>

- <span data-ttu-id="c78d6-1048">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1048">Standard status codes.</span></span>

<span data-ttu-id="c78d6-1049">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1049">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1050">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1050">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1051">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1051">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1052">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1052">HoloLens</span></span>
* <span data-ttu-id="c78d6-1053">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1053">IoT</span></span>

<hr>

## <a name="location"></a><span data-ttu-id="c78d6-1054">Location</span><span class="sxs-lookup"><span data-stu-id="c78d6-1054">Location</span></span>

<hr>

### <a name="get-location-override-mode"></a><span data-ttu-id="c78d6-1055">場所の上書きモードを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1055">Get location override mode</span></span>

<span data-ttu-id="c78d6-1056">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1056">**Request**</span></span>

<span data-ttu-id="c78d6-1057">次の要求型式を使用して、デバイスの場所スタック上書き状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1057">You can get the device's location stack override status by using the following request format.</span></span> <span data-ttu-id="c78d6-1058">この呼び出しを成功させるには、開発者モードを有効にしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1058">Developer mode must be on for this call to succeed.</span></span>
 
| <span data-ttu-id="c78d6-1059">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1059">Method</span></span>      | <span data-ttu-id="c78d6-1060">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1060">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1061">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1061">GET</span></span> | <span data-ttu-id="c78d6-1062">/ext/location/override</span><span class="sxs-lookup"><span data-stu-id="c78d6-1062">/ext/location/override</span></span> |


<span data-ttu-id="c78d6-1063">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1063">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1064">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1064">None</span></span>

<span data-ttu-id="c78d6-1065">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1065">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1066">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1066">None</span></span>

<span data-ttu-id="c78d6-1067">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1067">**Request body**</span></span>

- <span data-ttu-id="c78d6-1068">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1068">None</span></span>

<span data-ttu-id="c78d6-1069">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1069">**Response**</span></span>

<span data-ttu-id="c78d6-1070">応答には、デバイスの上書き状態が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1070">The response includes the override state of the device in the following format.</span></span> 

```json
{"Override" : bool}
```

<span data-ttu-id="c78d6-1071">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1071">**Status code**</span></span>

<span data-ttu-id="c78d6-1072">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1072">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1073">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1073">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1074">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1074">Description</span></span> |
| :------     | :----- |
|  <span data-ttu-id="c78d6-1075">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1075">200</span></span> | <span data-ttu-id="c78d6-1076">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1076">OK</span></span> | 
| <span data-ttu-id="c78d6-1077">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1077">4XX</span></span> | <span data-ttu-id="c78d6-1078">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1078">Error codes</span></span> |
| <span data-ttu-id="c78d6-1079">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1079">5XX</span></span> | <span data-ttu-id="c78d6-1080">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1080">Error codes</span></span> |

<span data-ttu-id="c78d6-1081">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1081">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1082">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1082">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1083">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1083">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1084">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1084">Xbox</span></span>
* <span data-ttu-id="c78d6-1085">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1085">HoloLens</span></span>
* <span data-ttu-id="c78d6-1086">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1086">IoT</span></span>

### <a name="set-location-override-mode"></a><span data-ttu-id="c78d6-1087">場所の上書きモードを設定する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1087">Set location override mode</span></span>

<span data-ttu-id="c78d6-1088">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1088">**Request**</span></span>

<span data-ttu-id="c78d6-1089">次の要求型式を使用して、デバイスの場所スタック上書き状態を設定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1089">You can set the device's location stack override status by using the following request format.</span></span> <span data-ttu-id="c78d6-1090">有効になっている場合は、場所スタックによって位置挿入が許可されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1090">When enabled, the location stack allows position injection.</span></span> <span data-ttu-id="c78d6-1091">この呼び出しを成功させるには、開発者モードを有効にしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1091">Developer mode must be on for this call to succeed.</span></span>

| <span data-ttu-id="c78d6-1092">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1092">Method</span></span>      | <span data-ttu-id="c78d6-1093">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1093">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1094">PUT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1094">PUT</span></span> | <span data-ttu-id="c78d6-1095">/ext/location/override</span><span class="sxs-lookup"><span data-stu-id="c78d6-1095">/ext/location/override</span></span> |


<span data-ttu-id="c78d6-1096">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1096">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1097">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1097">None</span></span>

<span data-ttu-id="c78d6-1098">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1098">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1099">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1099">None</span></span>

<span data-ttu-id="c78d6-1100">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1100">**Request body**</span></span>

```json
{"Override" : bool}
```

<span data-ttu-id="c78d6-1101">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1101">**Response**</span></span>

<span data-ttu-id="c78d6-1102">応答には、デバイスに設定されている上書き状態が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1102">The response includes the override state that the device has been set to in the following format.</span></span> 

```json
{"Override" : bool}
```

<span data-ttu-id="c78d6-1103">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1103">**Status code**</span></span>

<span data-ttu-id="c78d6-1104">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1104">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1105">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1105">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1106">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1106">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1107">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1107">200</span></span> | <span data-ttu-id="c78d6-1108">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1108">OK</span></span> |
| <span data-ttu-id="c78d6-1109">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1109">4XX</span></span> | <span data-ttu-id="c78d6-1110">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1110">Error codes</span></span> |
| <span data-ttu-id="c78d6-1111">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1111">5XX</span></span> | <span data-ttu-id="c78d6-1112">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1112">Error codes</span></span> |

<span data-ttu-id="c78d6-1113">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1113">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1114">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1114">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1115">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1115">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1116">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1116">Xbox</span></span>
* <span data-ttu-id="c78d6-1117">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1117">HoloLens</span></span>
* <span data-ttu-id="c78d6-1118">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1118">IoT</span></span>

### <a name="get-the-injected-position"></a><span data-ttu-id="c78d6-1119">挿入された位置を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1119">Get the injected position</span></span>

<span data-ttu-id="c78d6-1120">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1120">**Request**</span></span>

<span data-ttu-id="c78d6-1121">次の要求型式を使用して、デバイスの挿入 (スプーフィング) された場所を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1121">You can get the device's injected (spoofed) location by using the following request format.</span></span> <span data-ttu-id="c78d6-1122">挿入された場所を設定する必要があります。設定されなかった場合は、エラーがスローされます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1122">An injected location must be set, or an error will be thrown.</span></span>
 
| <span data-ttu-id="c78d6-1123">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1123">Method</span></span>      | <span data-ttu-id="c78d6-1124">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1124">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1125">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1125">GET</span></span> | <span data-ttu-id="c78d6-1126">/ext/location/position</span><span class="sxs-lookup"><span data-stu-id="c78d6-1126">/ext/location/position</span></span> |


<span data-ttu-id="c78d6-1127">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1127">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1128">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1128">None</span></span>

<span data-ttu-id="c78d6-1129">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1129">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1130">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1130">None</span></span>

<span data-ttu-id="c78d6-1131">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1131">**Request body**</span></span>

- <span data-ttu-id="c78d6-1132">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1132">None</span></span>

<span data-ttu-id="c78d6-1133">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1133">**Response**</span></span>

<span data-ttu-id="c78d6-1134">応答には、現在の挿入された緯度と経度の値が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1134">The response includes the current injected latitude and longitude values in the following format.</span></span> 

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

<span data-ttu-id="c78d6-1135">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1135">**Status code**</span></span>

<span data-ttu-id="c78d6-1136">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1136">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="c78d6-1137">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1137">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1138">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1138">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="c78d6-1139">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1139">200</span></span> | <span data-ttu-id="c78d6-1140">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1140">OK</span></span> |
| <span data-ttu-id="c78d6-1141">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1141">4XX</span></span> | <span data-ttu-id="c78d6-1142">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1142">Error codes</span></span> |
| <span data-ttu-id="c78d6-1143">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1143">5XX</span></span> | <span data-ttu-id="c78d6-1144">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1144">Error codes</span></span> |

<span data-ttu-id="c78d6-1145">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1145">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1146">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1146">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1147">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1147">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1148">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1148">Xbox</span></span>
* <span data-ttu-id="c78d6-1149">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1149">HoloLens</span></span>
* <span data-ttu-id="c78d6-1150">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1150">IoT</span></span>

### <a name="set-the-injected-position"></a><span data-ttu-id="c78d6-1151">挿入された位置を設定する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1151">Set the injected position</span></span>

<span data-ttu-id="c78d6-1152">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1152">**Request**</span></span>

<span data-ttu-id="c78d6-1153">次の要求型式を使用して、デバイスの挿入 (スプーフィング) された場所を設定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1153">You can set the device's injected (spoofed) location by using the following request format.</span></span> <span data-ttu-id="c78d6-1154">あらかじめデバイス上で場所の上書きモードが有効になっており、設定される場所も有効である必要があります。それ以外の場合はエラーがスローされます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1154">Location override mode must first be enabled on the device, and the set location must be a valid location or an error will be thrown.</span></span>

| <span data-ttu-id="c78d6-1155">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1155">Method</span></span>      | <span data-ttu-id="c78d6-1156">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1156">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1157">PUT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1157">PUT</span></span> | <span data-ttu-id="c78d6-1158">/ext/location/override</span><span class="sxs-lookup"><span data-stu-id="c78d6-1158">/ext/location/override</span></span> |


<span data-ttu-id="c78d6-1159">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1159">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1160">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1160">None</span></span>

<span data-ttu-id="c78d6-1161">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1161">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1162">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1162">None</span></span>

<span data-ttu-id="c78d6-1163">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1163">**Request body**</span></span>

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

<span data-ttu-id="c78d6-1164">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1164">**Response**</span></span>

<span data-ttu-id="c78d6-1165">応答には、設定された場所の情報が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1165">The response includes the location that has been set in the following format.</span></span> 

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

<span data-ttu-id="c78d6-1166">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1166">**Status code**</span></span>

<span data-ttu-id="c78d6-1167">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1167">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1168">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1168">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1169">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1169">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1170">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1170">200</span></span> | <span data-ttu-id="c78d6-1171">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1171">OK</span></span> |
| <span data-ttu-id="c78d6-1172">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1172">4XX</span></span> | <span data-ttu-id="c78d6-1173">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1173">Error codes</span></span> |
| <span data-ttu-id="c78d6-1174">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1174">5XX</span></span> | <span data-ttu-id="c78d6-1175">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1175">Error codes</span></span> |

<span data-ttu-id="c78d6-1176">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1176">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1177">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1177">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1178">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1178">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1179">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1179">Xbox</span></span>
* <span data-ttu-id="c78d6-1180">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1180">HoloLens</span></span>
* <span data-ttu-id="c78d6-1181">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1181">IoT</span></span>

<hr>

## <a name="os-information"></a><span data-ttu-id="c78d6-1182">OS 情報</span><span class="sxs-lookup"><span data-stu-id="c78d6-1182">OS information</span></span>

<hr>

### <a name="get-the-machine-name"></a><span data-ttu-id="c78d6-1183">コンピューター名を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1183">Get the machine name</span></span>

<span data-ttu-id="c78d6-1184">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1184">**Request**</span></span>

<span data-ttu-id="c78d6-1185">次の要求形式を使用して、コンピューターの名前を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1185">You can get the name of a machine by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1186">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1186">Method</span></span>      | <span data-ttu-id="c78d6-1187">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1187">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1188">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1188">GET</span></span> | <span data-ttu-id="c78d6-1189">/api/os/machinename</span><span class="sxs-lookup"><span data-stu-id="c78d6-1189">/api/os/machinename</span></span> |


<span data-ttu-id="c78d6-1190">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1190">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1191">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1191">None</span></span>

<span data-ttu-id="c78d6-1192">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1192">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1193">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1193">None</span></span>

<span data-ttu-id="c78d6-1194">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1194">**Request body**</span></span>

- <span data-ttu-id="c78d6-1195">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1195">None</span></span>

<span data-ttu-id="c78d6-1196">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1196">**Response**</span></span>

<span data-ttu-id="c78d6-1197">応答には、コンピューター名が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1197">The response includes the computer name in the following format.</span></span> 

```json
{"ComputerName": string}
```

<span data-ttu-id="c78d6-1198">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1198">**Status code**</span></span>

<span data-ttu-id="c78d6-1199">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1199">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1200">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1200">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1201">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1201">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1202">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1202">200</span></span> | <span data-ttu-id="c78d6-1203">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1203">OK</span></span> |
| <span data-ttu-id="c78d6-1204">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1204">4XX</span></span> | <span data-ttu-id="c78d6-1205">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1205">Error codes</span></span> |
| <span data-ttu-id="c78d6-1206">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1206">5XX</span></span> | <span data-ttu-id="c78d6-1207">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1207">Error codes</span></span> |

<span data-ttu-id="c78d6-1208">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1208">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1209">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1209">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1210">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1210">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1211">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1211">Xbox</span></span>
* <span data-ttu-id="c78d6-1212">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1212">HoloLens</span></span>
* <span data-ttu-id="c78d6-1213">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1213">IoT</span></span>

<hr>

### <a name="get-the-operating-system-information"></a><span data-ttu-id="c78d6-1214">オペレーティング システムの情報を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1214">Get the operating system information</span></span>

<span data-ttu-id="c78d6-1215">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1215">**Request**</span></span>

<span data-ttu-id="c78d6-1216">次の要求形式を使用して、コンピューターの OS 情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1216">You can get the OS information for a machine by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1217">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1217">Method</span></span>      | <span data-ttu-id="c78d6-1218">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1218">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1219">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1219">GET</span></span> | <span data-ttu-id="c78d6-1220">/api/os/info</span><span class="sxs-lookup"><span data-stu-id="c78d6-1220">/api/os/info</span></span> |


<span data-ttu-id="c78d6-1221">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1221">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1222">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1222">None</span></span>

<span data-ttu-id="c78d6-1223">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1223">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1224">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1224">None</span></span>

<span data-ttu-id="c78d6-1225">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1225">**Request body**</span></span>

- <span data-ttu-id="c78d6-1226">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1226">None</span></span>

<span data-ttu-id="c78d6-1227">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1227">**Response**</span></span>

<span data-ttu-id="c78d6-1228">応答には、OS 情報が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1228">The response includes the OS information in the following format.</span></span>

```json
{
    "ComputerName": string,
    "OsEdition": string,
    "OsEditionId": int,
    "OsVersion": string,
    "Platform": string
}
```

<span data-ttu-id="c78d6-1229">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1229">**Status code**</span></span>

<span data-ttu-id="c78d6-1230">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1230">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1231">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1231">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1232">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1232">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1233">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1233">200</span></span> | <span data-ttu-id="c78d6-1234">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1234">OK</span></span> |
| <span data-ttu-id="c78d6-1235">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1235">4XX</span></span> | <span data-ttu-id="c78d6-1236">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1236">Error codes</span></span> |
| <span data-ttu-id="c78d6-1237">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1237">5XX</span></span> | <span data-ttu-id="c78d6-1238">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1238">Error codes</span></span> |

<span data-ttu-id="c78d6-1239">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1239">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1240">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1240">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1241">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1241">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1242">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1242">Xbox</span></span>
* <span data-ttu-id="c78d6-1243">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1243">HoloLens</span></span>
* <span data-ttu-id="c78d6-1244">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1244">IoT</span></span>

<hr>

### <a name="get-the-device-family"></a><span data-ttu-id="c78d6-1245">デバイス ファミリを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1245">Get the device family</span></span> 

<span data-ttu-id="c78d6-1246">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1246">**Request**</span></span>

<span data-ttu-id="c78d6-1247">次の要求形式を使用して、デバイス ファミリ (Xbox、携帯電話、デスクトップなど) を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1247">You can get the device family (Xbox, phone, desktop, etc) using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1248">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1248">Method</span></span>      | <span data-ttu-id="c78d6-1249">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1249">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1250">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1250">GET</span></span> | <span data-ttu-id="c78d6-1251">/api/os/devicefamily</span><span class="sxs-lookup"><span data-stu-id="c78d6-1251">/api/os/devicefamily</span></span> |


<span data-ttu-id="c78d6-1252">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1252">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1253">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1253">None</span></span>

<span data-ttu-id="c78d6-1254">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1254">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1255">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1255">None</span></span>

<span data-ttu-id="c78d6-1256">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1256">**Request body**</span></span>

- <span data-ttu-id="c78d6-1257">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1257">None</span></span>

<span data-ttu-id="c78d6-1258">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1258">**Response**</span></span>

<span data-ttu-id="c78d6-1259">応答には、デバイス ファミリ (SKU - デスクトップ、Xbox など) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1259">The response includes the device family (SKU - Desktop, Xbox, etc).</span></span>

```json
{
   "DeviceType" : string
}
```

<span data-ttu-id="c78d6-1260">DeviceType は、"Windows.Xbox"、"Windows.Desktop" などのようになります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1260">DeviceType will look like "Windows.Xbox", "Windows.Desktop", etc.</span></span> 

<span data-ttu-id="c78d6-1261">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1261">**Status code**</span></span>

<span data-ttu-id="c78d6-1262">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1262">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1263">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1263">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1264">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1264">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1265">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1265">200</span></span> | <span data-ttu-id="c78d6-1266">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1266">OK</span></span> |
| <span data-ttu-id="c78d6-1267">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1267">4XX</span></span> | <span data-ttu-id="c78d6-1268">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1268">Error codes</span></span> |
| <span data-ttu-id="c78d6-1269">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1269">5XX</span></span> | <span data-ttu-id="c78d6-1270">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1270">Error codes</span></span> |

<span data-ttu-id="c78d6-1271">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1271">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1272">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1272">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1273">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1273">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1274">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1274">Xbox</span></span>
* <span data-ttu-id="c78d6-1275">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1275">HoloLens</span></span>
* <span data-ttu-id="c78d6-1276">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1276">IoT</span></span>

<hr>

### <a name="set-the-machine-name"></a><span data-ttu-id="c78d6-1277">コンピューター名を設定する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1277">Set the machine name</span></span>

<span data-ttu-id="c78d6-1278">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1278">**Request**</span></span>

<span data-ttu-id="c78d6-1279">次の要求形式を使用して、コンピューターの名前を設定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1279">You can set the name of a machine by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1280">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1280">Method</span></span>      | <span data-ttu-id="c78d6-1281">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1281">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1282">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-1282">POST</span></span> | <span data-ttu-id="c78d6-1283">/api/os/machinename</span><span class="sxs-lookup"><span data-stu-id="c78d6-1283">/api/os/machinename</span></span> |


<span data-ttu-id="c78d6-1284">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1284">**URI parameters**</span></span>

<span data-ttu-id="c78d6-1285">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1285">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-1286">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1286">URI parameter</span></span> | <span data-ttu-id="c78d6-1287">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1287">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-1288">name</span><span class="sxs-lookup"><span data-stu-id="c78d6-1288">name</span></span> | <span data-ttu-id="c78d6-1289">(**必須**) コンピューターの新しい名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1289">(**required**) The new name for the machine.</span></span> |

<span data-ttu-id="c78d6-1290">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1290">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1291">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1291">None</span></span>

<span data-ttu-id="c78d6-1292">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1292">**Request body**</span></span>

- <span data-ttu-id="c78d6-1293">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1293">None</span></span>

<span data-ttu-id="c78d6-1294">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1294">**Response**</span></span>

<span data-ttu-id="c78d6-1295">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1295">**Status code**</span></span>

<span data-ttu-id="c78d6-1296">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1296">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1297">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1297">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1298">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1298">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1299">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1299">200</span></span> | <span data-ttu-id="c78d6-1300">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1300">OK</span></span> |

<span data-ttu-id="c78d6-1301">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1301">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1302">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1302">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1303">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1303">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1304">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1304">Xbox</span></span>
* <span data-ttu-id="c78d6-1305">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1305">HoloLens</span></span>
* <span data-ttu-id="c78d6-1306">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1306">IoT</span></span>

<hr>

## <a name="user-information"></a><span data-ttu-id="c78d6-1307">ユーザー情報</span><span class="sxs-lookup"><span data-stu-id="c78d6-1307">User information</span></span>

<hr>

### <a name="get-the-active-user"></a><span data-ttu-id="c78d6-1308">アクティブ ユーザーを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1308">Get the active user</span></span>

<span data-ttu-id="c78d6-1309">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1309">**Request**</span></span>

<span data-ttu-id="c78d6-1310">次の要求形式を使用して、デバイスのアクティブ ユーザーの名前を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1310">You can get the name of the active user on the device by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1311">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1311">Method</span></span>      | <span data-ttu-id="c78d6-1312">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1312">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1313">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1313">GET</span></span> | <span data-ttu-id="c78d6-1314">/api/users/activeuser</span><span class="sxs-lookup"><span data-stu-id="c78d6-1314">/api/users/activeuser</span></span> |


<span data-ttu-id="c78d6-1315">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1315">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1316">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1316">None</span></span>

<span data-ttu-id="c78d6-1317">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1317">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1318">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1318">None</span></span>

<span data-ttu-id="c78d6-1319">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1319">**Request body**</span></span>

- <span data-ttu-id="c78d6-1320">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1320">None</span></span>

<span data-ttu-id="c78d6-1321">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1321">**Response**</span></span>

<span data-ttu-id="c78d6-1322">応答には、ユーザー情報が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1322">The response includes user information in the following format.</span></span> 

<span data-ttu-id="c78d6-1323">成功した場合:</span><span class="sxs-lookup"><span data-stu-id="c78d6-1323">On success:</span></span> 
```json
{
    "UserDisplayName" : string, 
    "UserSID" : string
}
```
<span data-ttu-id="c78d6-1324">失敗した場合:</span><span class="sxs-lookup"><span data-stu-id="c78d6-1324">On failure:</span></span>
```json
{
    "Code" : int, 
    "CodeText" : string, 
    "Reason" : string, 
    "Success" : bool
}
```

<span data-ttu-id="c78d6-1325">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1325">**Status code**</span></span>

<span data-ttu-id="c78d6-1326">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1326">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1327">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1327">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1328">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1328">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1329">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1329">200</span></span> | <span data-ttu-id="c78d6-1330">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1330">OK</span></span> |
| <span data-ttu-id="c78d6-1331">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1331">4XX</span></span> | <span data-ttu-id="c78d6-1332">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1332">Error codes</span></span> |
| <span data-ttu-id="c78d6-1333">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1333">5XX</span></span> | <span data-ttu-id="c78d6-1334">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1334">Error codes</span></span> |

<span data-ttu-id="c78d6-1335">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1335">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1336">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1336">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1337">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1337">HoloLens</span></span>
* <span data-ttu-id="c78d6-1338">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1338">IoT</span></span>

<hr>

## <a name="performance-data"></a><span data-ttu-id="c78d6-1339">パフォーマンス データ</span><span class="sxs-lookup"><span data-stu-id="c78d6-1339">Performance data</span></span>

<hr>

### <a name="get-the-list-of-running-processes"></a><span data-ttu-id="c78d6-1340">実行中のプロセスの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1340">Get the list of running processes</span></span>

<span data-ttu-id="c78d6-1341">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1341">**Request**</span></span>

<span data-ttu-id="c78d6-1342">次の要求形式を使用して、現在実行中のプロセスの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1342">You can get the list of currently running processes by using the following request format.</span></span>  <span data-ttu-id="c78d6-1343">これは、WebSocket 接続にアップグレードすることもでき、1 秒に 1 度クライアントにプッシュされる同じ JSON データを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1343">this can be upgraded to a WebSocket connection as well, with the same JSON data being pushed to the client once per second.</span></span> 
 
| <span data-ttu-id="c78d6-1344">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1344">Method</span></span>      | <span data-ttu-id="c78d6-1345">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1345">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1346">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1346">GET</span></span> | <span data-ttu-id="c78d6-1347">/api/resourcemanager/processes</span><span class="sxs-lookup"><span data-stu-id="c78d6-1347">/api/resourcemanager/processes</span></span> |
| <span data-ttu-id="c78d6-1348">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="c78d6-1348">GET/WebSocket</span></span> | <span data-ttu-id="c78d6-1349">/api/resourcemanager/processes</span><span class="sxs-lookup"><span data-stu-id="c78d6-1349">/api/resourcemanager/processes</span></span> |


<span data-ttu-id="c78d6-1350">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1350">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1351">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1351">None</span></span>

<span data-ttu-id="c78d6-1352">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1352">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1353">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1353">None</span></span>

<span data-ttu-id="c78d6-1354">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1354">**Request body**</span></span>

- <span data-ttu-id="c78d6-1355">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1355">None</span></span>

<span data-ttu-id="c78d6-1356">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1356">**Response**</span></span>

<span data-ttu-id="c78d6-1357">応答には、プロセスの一覧と各プロセスの詳細情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1357">The response includes a list of processes with details for each process.</span></span> <span data-ttu-id="c78d6-1358">情報は JSON 形式で、テンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1358">The information is in JSON format and has the following template.</span></span>
```json
{"Processes": [
    {
        "CPUUsage": float,
        "ImageName": string,
        "PageFileUsage": long,
        "PrivateWorkingSet": long,
        "ProcessId": int,
        "SessionId": int,
        "UserName": string,
        "VirtualSize": long,
        "WorkingSetSize": long
    },...
]}
```

<span data-ttu-id="c78d6-1359">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1359">**Status code**</span></span>

<span data-ttu-id="c78d6-1360">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1360">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1361">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1361">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1362">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1362">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1363">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1363">200</span></span> | <span data-ttu-id="c78d6-1364">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1364">OK</span></span> |
| <span data-ttu-id="c78d6-1365">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1365">4XX</span></span> | <span data-ttu-id="c78d6-1366">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1366">Error codes</span></span> |
| <span data-ttu-id="c78d6-1367">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1367">5XX</span></span> | <span data-ttu-id="c78d6-1368">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1368">Error codes</span></span> |

<span data-ttu-id="c78d6-1369">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1369">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1370">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1370">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1371">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1371">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1372">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1372">HoloLens</span></span>
* <span data-ttu-id="c78d6-1373">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1373">IoT</span></span>

<hr>

### <a name="get-the-system-performance-statistics"></a><span data-ttu-id="c78d6-1374">システム パフォーマンスの統計情報を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1374">Get the system performance statistics</span></span>

<span data-ttu-id="c78d6-1375">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1375">**Request**</span></span>

<span data-ttu-id="c78d6-1376">次の要求形式を使用して、システム パフォーマンスの統計情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1376">You can get the system performance statistics by using the following request format.</span></span> <span data-ttu-id="c78d6-1377">これには、読み取りと書き込みのサイクルや、使用されているメモリの量などの情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1377">This includes information such as read and write cycles and how much memory has been used.</span></span>
 
| <span data-ttu-id="c78d6-1378">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1378">Method</span></span>      | <span data-ttu-id="c78d6-1379">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1379">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1380">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1380">GET</span></span> | <span data-ttu-id="c78d6-1381">/api/resourcemanager/systemperf</span><span class="sxs-lookup"><span data-stu-id="c78d6-1381">/api/resourcemanager/systemperf</span></span> |
| <span data-ttu-id="c78d6-1382">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="c78d6-1382">GET/WebSocket</span></span> | <span data-ttu-id="c78d6-1383">/api/resourcemanager/systemperf</span><span class="sxs-lookup"><span data-stu-id="c78d6-1383">/api/resourcemanager/systemperf</span></span> |

<span data-ttu-id="c78d6-1384">これは、WebSocket 接続にアップグレードできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1384">This can also be upgraded to a WebSocket connection.</span></span>  <span data-ttu-id="c78d6-1385">1 秒に 1 度以下と同じ JSON データが提供されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1385">It provides the same JSON data below once every second.</span></span> 

<span data-ttu-id="c78d6-1386">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1386">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1387">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1387">None</span></span>

<span data-ttu-id="c78d6-1388">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1388">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1389">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1389">None</span></span>

<span data-ttu-id="c78d6-1390">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1390">**Request body**</span></span>

- <span data-ttu-id="c78d6-1391">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1391">None</span></span>

<span data-ttu-id="c78d6-1392">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1392">**Response**</span></span>

<span data-ttu-id="c78d6-1393">応答には、CPU と GPU の使用量、メモリ アクセス、ネットワーク アクセスなど、パフォーマンスの統計情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1393">The response includes the performance statistics for the system such as CPU and GPU usage, memory access, and network access.</span></span> <span data-ttu-id="c78d6-1394">この情報は JSON 形式で、テンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1394">This information is in JSON format and has the following template.</span></span>
```json
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

<span data-ttu-id="c78d6-1395">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1395">**Status code**</span></span>

<span data-ttu-id="c78d6-1396">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1396">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1397">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1397">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1398">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1398">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1399">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1399">200</span></span> | <span data-ttu-id="c78d6-1400">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1400">OK</span></span> |
| <span data-ttu-id="c78d6-1401">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1401">4XX</span></span> | <span data-ttu-id="c78d6-1402">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1402">Error codes</span></span> |
| <span data-ttu-id="c78d6-1403">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1403">5XX</span></span> | <span data-ttu-id="c78d6-1404">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1404">Error codes</span></span> |

<span data-ttu-id="c78d6-1405">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1405">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1406">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1406">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1407">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1407">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1408">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1408">Xbox</span></span>
* <span data-ttu-id="c78d6-1409">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1409">HoloLens</span></span>
* <span data-ttu-id="c78d6-1410">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1410">IoT</span></span>

<hr>

## <a name="power"></a><span data-ttu-id="c78d6-1411">Power</span><span class="sxs-lookup"><span data-stu-id="c78d6-1411">Power</span></span>

<hr>

### <a name="get-the-current-battery-state"></a><span data-ttu-id="c78d6-1412">現在のバッテリ状態を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1412">Get the current battery state</span></span>

<span data-ttu-id="c78d6-1413">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1413">**Request**</span></span>

<span data-ttu-id="c78d6-1414">次の要求形式を使用して、バッテリの現在の状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1414">You can get the current state of the battery by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1415">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1415">Method</span></span>      | <span data-ttu-id="c78d6-1416">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1416">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1417">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1417">GET</span></span> | <span data-ttu-id="c78d6-1418">/api/power/battery</span><span class="sxs-lookup"><span data-stu-id="c78d6-1418">/api/power/battery</span></span> |


<span data-ttu-id="c78d6-1419">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1419">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1420">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1420">None</span></span>

<span data-ttu-id="c78d6-1421">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1421">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1422">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1422">None</span></span>

<span data-ttu-id="c78d6-1423">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1423">**Request body**</span></span>

- <span data-ttu-id="c78d6-1424">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1424">None</span></span>

<span data-ttu-id="c78d6-1425">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1425">**Response**</span></span>

<span data-ttu-id="c78d6-1426">現在のバッテリ状態に関する情報が次の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1426">The current battery state information is returned using the following format.</span></span>
```json
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

<span data-ttu-id="c78d6-1427">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1427">**Status code**</span></span>

<span data-ttu-id="c78d6-1428">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1428">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1429">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1429">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1430">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1430">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1431">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1431">200</span></span> | <span data-ttu-id="c78d6-1432">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1432">OK</span></span> |
| <span data-ttu-id="c78d6-1433">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1433">4XX</span></span> | <span data-ttu-id="c78d6-1434">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1434">Error codes</span></span> |
| <span data-ttu-id="c78d6-1435">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1435">5XX</span></span> | <span data-ttu-id="c78d6-1436">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1436">Error codes</span></span> |

<span data-ttu-id="c78d6-1437">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1437">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1438">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1438">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1439">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1439">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1440">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1440">HoloLens</span></span>
* <span data-ttu-id="c78d6-1441">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1441">IoT</span></span>

<hr>

### <a name="get-the-active-power-scheme"></a><span data-ttu-id="c78d6-1442">アクティブな電源設定を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1442">Get the active power scheme</span></span>

<span data-ttu-id="c78d6-1443">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1443">**Request**</span></span>

<span data-ttu-id="c78d6-1444">次の要求形式を使用して、アクティブな電源設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1444">You can get the active power scheme by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1445">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1445">Method</span></span>      | <span data-ttu-id="c78d6-1446">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1446">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1447">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1447">GET</span></span> | <span data-ttu-id="c78d6-1448">/api/power/activecfg</span><span class="sxs-lookup"><span data-stu-id="c78d6-1448">/api/power/activecfg</span></span> |


<span data-ttu-id="c78d6-1449">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1449">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1450">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1450">None</span></span>

<span data-ttu-id="c78d6-1451">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1451">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1452">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1452">None</span></span>

<span data-ttu-id="c78d6-1453">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1453">**Request body**</span></span>

- <span data-ttu-id="c78d6-1454">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1454">None</span></span>

<span data-ttu-id="c78d6-1455">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1455">**Response**</span></span>

<span data-ttu-id="c78d6-1456">アクティブな電源設定の形式は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1456">The active power scheme has the following format.</span></span>
```json
{"ActivePowerScheme": string (guid of scheme)}
```

<span data-ttu-id="c78d6-1457">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1457">**Status code**</span></span>

<span data-ttu-id="c78d6-1458">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1458">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1459">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1459">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1460">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1460">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1461">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1461">200</span></span> | <span data-ttu-id="c78d6-1462">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1462">OK</span></span> |
| <span data-ttu-id="c78d6-1463">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1463">4XX</span></span> | <span data-ttu-id="c78d6-1464">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1464">Error codes</span></span> |
| <span data-ttu-id="c78d6-1465">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1465">5XX</span></span> | <span data-ttu-id="c78d6-1466">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1466">Error codes</span></span> |

<span data-ttu-id="c78d6-1467">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1467">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1468">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1468">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1469">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1469">IoT</span></span>

<hr>

### <a name="get-the-sub-value-for-a-power-scheme"></a><span data-ttu-id="c78d6-1470">電源設定のサブ値を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1470">Get the sub-value for a power scheme</span></span>

<span data-ttu-id="c78d6-1471">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1471">**Request**</span></span>

<span data-ttu-id="c78d6-1472">次の要求形式を使用して、電源設定のサブ値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1472">You can get the sub-value for a power scheme by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1473">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1473">Method</span></span>      | <span data-ttu-id="c78d6-1474">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1474">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1475">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1475">GET</span></span> | <span data-ttu-id="c78d6-1476">/api/power/cfg/*<power scheme path>*</span><span class="sxs-lookup"><span data-stu-id="c78d6-1476">/api/power/cfg/*<power scheme path>*</span></span> |

<span data-ttu-id="c78d6-1477">オプション:</span><span class="sxs-lookup"><span data-stu-id="c78d6-1477">Options:</span></span>
- <span data-ttu-id="c78d6-1478">SCHEME_CURRENT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1478">SCHEME_CURRENT</span></span>

<span data-ttu-id="c78d6-1479">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1479">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1480">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1480">None</span></span>

<span data-ttu-id="c78d6-1481">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1481">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1482">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1482">None</span></span>

<span data-ttu-id="c78d6-1483">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1483">**Request body**</span></span>

<span data-ttu-id="c78d6-1484">利用可能な電源状態の完全な一覧は、アプリケーションごとが基本で、バッテリ低下、重要なバッテリといったさまざまな電源状態がフラグ設定されています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1484">A full listing of power states available is on a per-application basis and the settings for flagging various power states like low and critical batterty.</span></span> 

<span data-ttu-id="c78d6-1485">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1485">**Response**</span></span>

<span data-ttu-id="c78d6-1486">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1486">**Status code**</span></span>

<span data-ttu-id="c78d6-1487">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1487">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1488">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1488">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1489">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1489">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1490">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1490">200</span></span> | <span data-ttu-id="c78d6-1491">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1491">OK</span></span> |
| <span data-ttu-id="c78d6-1492">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1492">4XX</span></span> | <span data-ttu-id="c78d6-1493">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1493">Error codes</span></span> |
| <span data-ttu-id="c78d6-1494">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1494">5XX</span></span> | <span data-ttu-id="c78d6-1495">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1495">Error codes</span></span> |

<span data-ttu-id="c78d6-1496">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1496">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1497">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1497">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1498">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1498">IoT</span></span>

<hr>

### <a name="get-the-power-state-of-the-system"></a><span data-ttu-id="c78d6-1499">システムの電源状態を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1499">Get the power state of the system</span></span>

<span data-ttu-id="c78d6-1500">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1500">**Request**</span></span>

<span data-ttu-id="c78d6-1501">次の要求形式を使用して、システムの電源状態を確認できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1501">You can check the power state of the system by using the following request format.</span></span> <span data-ttu-id="c78d6-1502">これによって、低電力状態になっているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1502">This will let you check to see if it is in a low power state.</span></span>
 
| <span data-ttu-id="c78d6-1503">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1503">Method</span></span>      | <span data-ttu-id="c78d6-1504">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1504">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1505">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1505">GET</span></span> | <span data-ttu-id="c78d6-1506">/api/power/state</span><span class="sxs-lookup"><span data-stu-id="c78d6-1506">/api/power/state</span></span> |


<span data-ttu-id="c78d6-1507">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1507">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1508">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1508">None</span></span>

<span data-ttu-id="c78d6-1509">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1509">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1510">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1510">None</span></span>

<span data-ttu-id="c78d6-1511">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1511">**Request body**</span></span>

- <span data-ttu-id="c78d6-1512">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1512">None</span></span>

<span data-ttu-id="c78d6-1513">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1513">**Response**</span></span>

<span data-ttu-id="c78d6-1514">電源状態の情報のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1514">The power state information has the following template.</span></span>
```json
{"LowPowerState" : false, "LowPowerStateAvailable" : true }
```

<span data-ttu-id="c78d6-1515">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1515">**Status code**</span></span>

<span data-ttu-id="c78d6-1516">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1516">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1517">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1517">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1518">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1518">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1519">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1519">200</span></span> | <span data-ttu-id="c78d6-1520">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1520">OK</span></span> |
| <span data-ttu-id="c78d6-1521">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1521">4XX</span></span> | <span data-ttu-id="c78d6-1522">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1522">Error codes</span></span> |
| <span data-ttu-id="c78d6-1523">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1523">5XX</span></span> | <span data-ttu-id="c78d6-1524">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1524">Error codes</span></span> |

<span data-ttu-id="c78d6-1525">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1525">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1526">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1526">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1527">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1527">HoloLens</span></span>
* <span data-ttu-id="c78d6-1528">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1528">IoT</span></span>

<hr>

### <a name="set-the-active-power-scheme"></a><span data-ttu-id="c78d6-1529">アクティブな電源設定を行う</span><span class="sxs-lookup"><span data-stu-id="c78d6-1529">Set the active power scheme</span></span>

<span data-ttu-id="c78d6-1530">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1530">**Request**</span></span>

<span data-ttu-id="c78d6-1531">次の要求形式を使用して、アクティブな電源設定を設定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1531">You can set the active power scheme by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1532">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1532">Method</span></span>      | <span data-ttu-id="c78d6-1533">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1533">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1534">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-1534">POST</span></span> | <span data-ttu-id="c78d6-1535">/api/power/activecfg</span><span class="sxs-lookup"><span data-stu-id="c78d6-1535">/api/power/activecfg</span></span> |


<span data-ttu-id="c78d6-1536">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1536">**URI parameters**</span></span>

<span data-ttu-id="c78d6-1537">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1537">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-1538">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1538">URI parameter</span></span> | <span data-ttu-id="c78d6-1539">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1539">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-1540">scheme</span><span class="sxs-lookup"><span data-stu-id="c78d6-1540">scheme</span></span> | <span data-ttu-id="c78d6-1541">(**必須**) システムのアクティブな電源設定として設定するスキームの GUID。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1541">(**required**) The GUID of the scheme you want to set as the active power scheme for the system.</span></span> |

<span data-ttu-id="c78d6-1542">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1542">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1543">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1543">None</span></span>

<span data-ttu-id="c78d6-1544">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1544">**Request body**</span></span>

- <span data-ttu-id="c78d6-1545">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1545">None</span></span>

<span data-ttu-id="c78d6-1546">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1546">**Response**</span></span>

<span data-ttu-id="c78d6-1547">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1547">**Status code**</span></span>

<span data-ttu-id="c78d6-1548">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1548">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1549">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1549">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1550">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1550">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1551">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1551">200</span></span> | <span data-ttu-id="c78d6-1552">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1552">OK</span></span> |
| <span data-ttu-id="c78d6-1553">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1553">4XX</span></span> | <span data-ttu-id="c78d6-1554">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1554">Error codes</span></span> |
| <span data-ttu-id="c78d6-1555">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1555">5XX</span></span> | <span data-ttu-id="c78d6-1556">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1556">Error codes</span></span> |

<span data-ttu-id="c78d6-1557">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1557">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1558">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1558">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1559">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1559">IoT</span></span>

<hr>

### <a name="set-the-sub-value-for-a-power-scheme"></a><span data-ttu-id="c78d6-1560">電源設定のサブ値を設定する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1560">Set the sub-value for a power scheme</span></span>

<span data-ttu-id="c78d6-1561">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1561">**Request**</span></span>

<span data-ttu-id="c78d6-1562">次の要求形式を使用して、電源設定のサブ値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1562">You can set the sub-value for a power scheme by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1563">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1563">Method</span></span>      | <span data-ttu-id="c78d6-1564">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1564">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1565">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-1565">POST</span></span> | <span data-ttu-id="c78d6-1566">/api/power/cfg/*<power scheme path>*</span><span class="sxs-lookup"><span data-stu-id="c78d6-1566">/api/power/cfg/*<power scheme path>*</span></span> |


<span data-ttu-id="c78d6-1567">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1567">**URI parameters**</span></span>

<span data-ttu-id="c78d6-1568">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1568">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-1569">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1569">URI parameter</span></span> | <span data-ttu-id="c78d6-1570">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1570">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-1571">valueAC</span><span class="sxs-lookup"><span data-stu-id="c78d6-1571">valueAC</span></span> | <span data-ttu-id="c78d6-1572">(**必須**) AC 電源に使用する値。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1572">(**required**) The value to use for A/C power.</span></span> |
| <span data-ttu-id="c78d6-1573">valueDC</span><span class="sxs-lookup"><span data-stu-id="c78d6-1573">valueDC</span></span> | <span data-ttu-id="c78d6-1574">(**必須**) バッテリ電源に使用する値。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1574">(**required**) The value to use for battery power.</span></span> |

<span data-ttu-id="c78d6-1575">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1575">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1576">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1576">None</span></span>

<span data-ttu-id="c78d6-1577">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1577">**Request body**</span></span>

- <span data-ttu-id="c78d6-1578">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1578">None</span></span>

<span data-ttu-id="c78d6-1579">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1579">**Response**</span></span>

<span data-ttu-id="c78d6-1580">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1580">**Status code**</span></span>

<span data-ttu-id="c78d6-1581">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1581">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1582">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1582">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1583">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1583">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1584">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1584">200</span></span> | <span data-ttu-id="c78d6-1585">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1585">OK</span></span> |

<span data-ttu-id="c78d6-1586">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1586">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1587">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1587">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1588">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1588">IoT</span></span>

<hr>

### <a name="get-a-sleep-study-report"></a><span data-ttu-id="c78d6-1589">SleepStudy レポートを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1589">Get a sleep study report</span></span>

<span data-ttu-id="c78d6-1590">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1590">**Request**</span></span>

| <span data-ttu-id="c78d6-1591">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1591">Method</span></span>      | <span data-ttu-id="c78d6-1592">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1592">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1593">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1593">GET</span></span> | <span data-ttu-id="c78d6-1594">/api/power/sleepstudy/report</span><span class="sxs-lookup"><span data-stu-id="c78d6-1594">/api/power/sleepstudy/report</span></span> |

<span data-ttu-id="c78d6-1595">次の要求形式を使用して、SleepStudy レポートを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1595">You can get a sleep study report by using the following request format.</span></span>

<span data-ttu-id="c78d6-1596">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1596">**URI parameters**</span></span>
| <span data-ttu-id="c78d6-1597">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1597">URI parameter</span></span> | <span data-ttu-id="c78d6-1598">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1598">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-1599">FileName</span><span class="sxs-lookup"><span data-stu-id="c78d6-1599">FileName</span></span> | <span data-ttu-id="c78d6-1600">(**必須**) ダウンロードするファイルの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1600">(**required**) The full name for the file you want to download.</span></span> <span data-ttu-id="c78d6-1601">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1601">This value should be hex64 encoded.</span></span> |

<span data-ttu-id="c78d6-1602">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1602">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1603">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1603">None</span></span>

<span data-ttu-id="c78d6-1604">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1604">**Request body**</span></span>

- <span data-ttu-id="c78d6-1605">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1605">None</span></span>

<span data-ttu-id="c78d6-1606">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1606">**Response**</span></span>

<span data-ttu-id="c78d6-1607">応答は、スリープ検査の結果が含まれているファイルです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1607">The response is a file containing the sleep study.</span></span> 

<span data-ttu-id="c78d6-1608">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1608">**Status code**</span></span>

<span data-ttu-id="c78d6-1609">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1609">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1610">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1610">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1611">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1611">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1612">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1612">200</span></span> | <span data-ttu-id="c78d6-1613">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1613">OK</span></span> |
| <span data-ttu-id="c78d6-1614">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1614">4XX</span></span> | <span data-ttu-id="c78d6-1615">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1615">Error codes</span></span> |
| <span data-ttu-id="c78d6-1616">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1616">5XX</span></span> | <span data-ttu-id="c78d6-1617">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1617">Error codes</span></span> |

<span data-ttu-id="c78d6-1618">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1618">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1619">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1619">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1620">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1620">IoT</span></span>

<hr>

### <a name="enumerate-the-available-sleep-study-reports"></a><span data-ttu-id="c78d6-1621">利用可能な SleepStudy レポートを列挙する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1621">Enumerate the available sleep study reports</span></span>

<span data-ttu-id="c78d6-1622">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1622">**Request**</span></span>

<span data-ttu-id="c78d6-1623">次の要求形式を使用して、利用可能な SleepStudy レポートを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1623">You can enumerate the available sleep study reports by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1624">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1624">Method</span></span>      | <span data-ttu-id="c78d6-1625">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1625">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1626">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1626">GET</span></span> | <span data-ttu-id="c78d6-1627">/api/power/sleepstudy/reports</span><span class="sxs-lookup"><span data-stu-id="c78d6-1627">/api/power/sleepstudy/reports</span></span> |


<span data-ttu-id="c78d6-1628">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1628">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1629">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1629">None</span></span>

<span data-ttu-id="c78d6-1630">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1630">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1631">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1631">None</span></span>

<span data-ttu-id="c78d6-1632">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1632">**Request body**</span></span>

- <span data-ttu-id="c78d6-1633">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1633">None</span></span>

<span data-ttu-id="c78d6-1634">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1634">**Response**</span></span>

<span data-ttu-id="c78d6-1635">利用可能なレポートの一覧のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1635">The list of available reports has the following template.</span></span>

```json
{"Reports": [
    {
        "FileName": string
    },...
]}
```

<span data-ttu-id="c78d6-1636">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1636">**Status code**</span></span>

<span data-ttu-id="c78d6-1637">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1637">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1638">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1638">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1639">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1639">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1640">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1640">200</span></span> | <span data-ttu-id="c78d6-1641">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1641">OK</span></span> |
| <span data-ttu-id="c78d6-1642">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1642">4XX</span></span> | <span data-ttu-id="c78d6-1643">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1643">Error codes</span></span> |
| <span data-ttu-id="c78d6-1644">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1644">5XX</span></span> | <span data-ttu-id="c78d6-1645">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1645">Error codes</span></span> |

<span data-ttu-id="c78d6-1646">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1646">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1647">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1647">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1648">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1648">IoT</span></span>

<hr>

### <a name="get-the-sleep-study-transform"></a><span data-ttu-id="c78d6-1649">スリープ スタディ変換を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1649">Get the sleep study transform</span></span>

<span data-ttu-id="c78d6-1650">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1650">**Request**</span></span>

<span data-ttu-id="c78d6-1651">次の要求形式を使用して、スリープ スタディ変換を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1651">You can get the sleep study transform by using the following request format.</span></span> <span data-ttu-id="c78d6-1652">この変換は、SleepStudy レポートを、ユーザーが読み取ることができる XML 形式に変換する XSLT です。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1652">This transform is an XSLT that converts the sleep study report into an XML format that can be read by a person.</span></span>
 
| <span data-ttu-id="c78d6-1653">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1653">Method</span></span>      | <span data-ttu-id="c78d6-1654">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1654">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1655">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1655">GET</span></span> | <span data-ttu-id="c78d6-1656">/api/power/sleepstudy/transform</span><span class="sxs-lookup"><span data-stu-id="c78d6-1656">/api/power/sleepstudy/transform</span></span> |


<span data-ttu-id="c78d6-1657">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1657">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1658">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1658">None</span></span>

<span data-ttu-id="c78d6-1659">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1659">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1660">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1660">None</span></span>

<span data-ttu-id="c78d6-1661">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1661">**Request body**</span></span>

- <span data-ttu-id="c78d6-1662">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1662">None</span></span>

<span data-ttu-id="c78d6-1663">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1663">**Response**</span></span>

<span data-ttu-id="c78d6-1664">応答には、スリープ スタディ変換が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1664">The response contains the sleep study transform.</span></span>

<span data-ttu-id="c78d6-1665">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1665">**Status code**</span></span>

<span data-ttu-id="c78d6-1666">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1666">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1667">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1667">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1668">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1668">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1669">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1669">200</span></span> | <span data-ttu-id="c78d6-1670">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1670">OK</span></span> |
| <span data-ttu-id="c78d6-1671">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1671">4XX</span></span> | <span data-ttu-id="c78d6-1672">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1672">Error codes</span></span> |
| <span data-ttu-id="c78d6-1673">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1673">5XX</span></span> | <span data-ttu-id="c78d6-1674">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1674">Error codes</span></span> |

<span data-ttu-id="c78d6-1675">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1675">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1676">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1676">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1677">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1677">IoT</span></span>

<hr>

## <a name="remote-control"></a><span data-ttu-id="c78d6-1678">リモコン</span><span class="sxs-lookup"><span data-stu-id="c78d6-1678">Remote control</span></span>

<hr>

### <a name="restart-the-target-computer"></a><span data-ttu-id="c78d6-1679">ターゲット コンピューターを再起動する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1679">Restart the target computer</span></span>

<span data-ttu-id="c78d6-1680">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1680">**Request**</span></span>

<span data-ttu-id="c78d6-1681">次の要求形式を使用して、ターゲット コンピューターを再起動できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1681">You can restart the target computer by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1682">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1682">Method</span></span>      | <span data-ttu-id="c78d6-1683">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1683">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1684">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-1684">POST</span></span> | <span data-ttu-id="c78d6-1685">/api/control/restart</span><span class="sxs-lookup"><span data-stu-id="c78d6-1685">/api/control/restart</span></span> |


<span data-ttu-id="c78d6-1686">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1686">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1687">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1687">None</span></span>

<span data-ttu-id="c78d6-1688">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1688">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1689">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1689">None</span></span>

<span data-ttu-id="c78d6-1690">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1690">**Request body**</span></span>

- <span data-ttu-id="c78d6-1691">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1691">None</span></span>

<span data-ttu-id="c78d6-1692">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1692">**Response**</span></span>

<span data-ttu-id="c78d6-1693">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1693">**Status code**</span></span>

<span data-ttu-id="c78d6-1694">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1694">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1695">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1695">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1696">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1696">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1697">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1697">200</span></span> | <span data-ttu-id="c78d6-1698">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1698">OK</span></span> |

<span data-ttu-id="c78d6-1699">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1699">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1700">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1700">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1701">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1701">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1702">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1702">Xbox</span></span>
* <span data-ttu-id="c78d6-1703">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1703">HoloLens</span></span>
* <span data-ttu-id="c78d6-1704">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1704">IoT</span></span>

<hr>

### <a name="shut-down-the-target-computer"></a><span data-ttu-id="c78d6-1705">ターゲット コンピューターをシャットダウンする</span><span class="sxs-lookup"><span data-stu-id="c78d6-1705">Shut down the target computer</span></span>

<span data-ttu-id="c78d6-1706">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1706">**Request**</span></span>

<span data-ttu-id="c78d6-1707">次の要求形式を使用して、ターゲット コンピューターをシャット ダウンできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1707">You can shut down the target computer by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1708">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1708">Method</span></span>      | <span data-ttu-id="c78d6-1709">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1709">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1710">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-1710">POST</span></span> | <span data-ttu-id="c78d6-1711">/api/control/shutdown</span><span class="sxs-lookup"><span data-stu-id="c78d6-1711">/api/control/shutdown</span></span> |


<span data-ttu-id="c78d6-1712">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1712">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1713">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1713">None</span></span>

<span data-ttu-id="c78d6-1714">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1714">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1715">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1715">None</span></span>

<span data-ttu-id="c78d6-1716">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1716">**Request body**</span></span>

- <span data-ttu-id="c78d6-1717">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1717">None</span></span>

<span data-ttu-id="c78d6-1718">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1718">**Response**</span></span>

<span data-ttu-id="c78d6-1719">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1719">**Status code**</span></span>

<span data-ttu-id="c78d6-1720">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1720">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1721">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1721">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1722">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1722">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1723">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1723">200</span></span> | <span data-ttu-id="c78d6-1724">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1724">OK</span></span> |
| <span data-ttu-id="c78d6-1725">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1725">4XX</span></span> | <span data-ttu-id="c78d6-1726">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1726">Error codes</span></span> |
| <span data-ttu-id="c78d6-1727">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1727">5XX</span></span> | <span data-ttu-id="c78d6-1728">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1728">Error codes</span></span> |

<span data-ttu-id="c78d6-1729">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1729">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1730">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1730">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1731">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1731">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1732">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1732">Xbox</span></span>
* <span data-ttu-id="c78d6-1733">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1733">HoloLens</span></span>
* <span data-ttu-id="c78d6-1734">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1734">IoT</span></span>

<hr>

## <a name="task-manager"></a><span data-ttu-id="c78d6-1735">タスク マネージャー</span><span class="sxs-lookup"><span data-stu-id="c78d6-1735">Task manager</span></span>

<hr>

### <a name="start-a-modern-app"></a><span data-ttu-id="c78d6-1736">最新のアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1736">Start a modern app</span></span>

<span data-ttu-id="c78d6-1737">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1737">**Request**</span></span>

<span data-ttu-id="c78d6-1738">次の要求形式を使用して、最新のアプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1738">You can start a modern app by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1739">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1739">Method</span></span>      | <span data-ttu-id="c78d6-1740">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1740">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1741">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-1741">POST</span></span> | <span data-ttu-id="c78d6-1742">/api/taskmanager/app</span><span class="sxs-lookup"><span data-stu-id="c78d6-1742">/api/taskmanager/app</span></span> |


<span data-ttu-id="c78d6-1743">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1743">**URI parameters**</span></span>

<span data-ttu-id="c78d6-1744">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1744">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-1745">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1745">URI parameter</span></span> | <span data-ttu-id="c78d6-1746">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1746">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-1747">appid</span><span class="sxs-lookup"><span data-stu-id="c78d6-1747">appid</span></span>   | <span data-ttu-id="c78d6-1748">(**必須**) 起動するアプリの PRAID。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1748">(**required**) The PRAID for the app you want to start.</span></span> <span data-ttu-id="c78d6-1749">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1749">This value should be hex64 encoded.</span></span> |
| <span data-ttu-id="c78d6-1750">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="c78d6-1750">package</span></span>   | <span data-ttu-id="c78d6-1751">(**必須**) 起動するアプリ パッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1751">(**required**) The full name for the app package you want to start.</span></span> <span data-ttu-id="c78d6-1752">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1752">This value should be hex64 encoded.</span></span> |

<span data-ttu-id="c78d6-1753">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1753">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1754">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1754">None</span></span>

<span data-ttu-id="c78d6-1755">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1755">**Request body**</span></span>

- <span data-ttu-id="c78d6-1756">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1756">None</span></span>

<span data-ttu-id="c78d6-1757">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1757">**Response**</span></span>

<span data-ttu-id="c78d6-1758">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1758">**Status code**</span></span>

<span data-ttu-id="c78d6-1759">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1759">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1760">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1760">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1761">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1761">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1762">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1762">200</span></span> | <span data-ttu-id="c78d6-1763">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1763">OK</span></span> |
| <span data-ttu-id="c78d6-1764">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1764">4XX</span></span> | <span data-ttu-id="c78d6-1765">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1765">Error codes</span></span> |
| <span data-ttu-id="c78d6-1766">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1766">5XX</span></span> | <span data-ttu-id="c78d6-1767">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1767">Error codes</span></span> |

<span data-ttu-id="c78d6-1768">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1768">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1769">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1769">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1770">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1770">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1771">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1771">Xbox</span></span>
* <span data-ttu-id="c78d6-1772">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1772">HoloLens</span></span>
* <span data-ttu-id="c78d6-1773">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1773">IoT</span></span>

<hr>

### <a name="stop-a-modern-app"></a><span data-ttu-id="c78d6-1774">最新のアプリを停止する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1774">Stop a modern app</span></span>

<span data-ttu-id="c78d6-1775">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1775">**Request**</span></span>

<span data-ttu-id="c78d6-1776">次の要求形式を使用して、最新のアプリを停止できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1776">You can stop a modern app by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1777">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1777">Method</span></span>      | <span data-ttu-id="c78d6-1778">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1778">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1779">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-1779">DELETE</span></span> | <span data-ttu-id="c78d6-1780">/api/taskmanager/app</span><span class="sxs-lookup"><span data-stu-id="c78d6-1780">/api/taskmanager/app</span></span> |


<span data-ttu-id="c78d6-1781">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1781">**URI parameters**</span></span>

<span data-ttu-id="c78d6-1782">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1782">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-1783">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1783">URI parameter</span></span> | <span data-ttu-id="c78d6-1784">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1784">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-1785">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="c78d6-1785">package</span></span>   | <span data-ttu-id="c78d6-1786">(**必須**) 停止するアプリ パッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1786">(**required**) The full name of the app packages that you want to stop.</span></span> <span data-ttu-id="c78d6-1787">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1787">This value should be hex64 encoded.</span></span> |
| <span data-ttu-id="c78d6-1788">forcestop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1788">forcestop</span></span>   | <span data-ttu-id="c78d6-1789">(**オプション**) 値が **yes** の場合は、システムがすべてのプロセスを強制的に停止することを示します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1789">(**optional**) A value of **yes** indicates that the system should force all processes to stop.</span></span> |

<span data-ttu-id="c78d6-1790">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1790">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1791">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1791">None</span></span>

<span data-ttu-id="c78d6-1792">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1792">**Request body**</span></span>

- <span data-ttu-id="c78d6-1793">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1793">None</span></span>

<span data-ttu-id="c78d6-1794">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1794">**Response**</span></span>

<span data-ttu-id="c78d6-1795">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1795">**Status code**</span></span>

<span data-ttu-id="c78d6-1796">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1796">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1797">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1797">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1798">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1798">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1799">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1799">200</span></span> | <span data-ttu-id="c78d6-1800">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1800">OK</span></span> |
| <span data-ttu-id="c78d6-1801">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1801">4XX</span></span> | <span data-ttu-id="c78d6-1802">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1802">Error codes</span></span> |
| <span data-ttu-id="c78d6-1803">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1803">5XX</span></span> | <span data-ttu-id="c78d6-1804">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1804">Error codes</span></span> |

<span data-ttu-id="c78d6-1805">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1805">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1806">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1806">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1807">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1807">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1808">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1808">Xbox</span></span>
* <span data-ttu-id="c78d6-1809">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1809">HoloLens</span></span>
* <span data-ttu-id="c78d6-1810">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1810">IoT</span></span>

<hr>

### <a name="kill-process-by-pid"></a><span data-ttu-id="c78d6-1811">PID でプロセスを強制終了する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1811">Kill process by PID</span></span>

<span data-ttu-id="c78d6-1812">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1812">**Request**</span></span>

<span data-ttu-id="c78d6-1813">次の要求形式を使用して、プロセスを強制終了できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1813">You can kill a process by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1814">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1814">Method</span></span>      | <span data-ttu-id="c78d6-1815">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1815">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1816">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-1816">DELETE</span></span> | <span data-ttu-id="c78d6-1817">/api/taskmanager/process</span><span class="sxs-lookup"><span data-stu-id="c78d6-1817">/api/taskmanager/process</span></span> |


<span data-ttu-id="c78d6-1818">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1818">**URI parameters**</span></span>

<span data-ttu-id="c78d6-1819">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1819">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-1820">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1820">URI parameter</span></span> | <span data-ttu-id="c78d6-1821">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1821">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-1822">pid</span><span class="sxs-lookup"><span data-stu-id="c78d6-1822">pid</span></span>   | <span data-ttu-id="c78d6-1823">(**必須**) 終了するプロセスの一意のプロセス ID。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1823">(**required**) The unique process id for the process to stop.</span></span> |

<span data-ttu-id="c78d6-1824">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1824">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1825">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1825">None</span></span>

<span data-ttu-id="c78d6-1826">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1826">**Request body**</span></span>

- <span data-ttu-id="c78d6-1827">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1827">None</span></span>

<span data-ttu-id="c78d6-1828">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1828">**Response**</span></span>

<span data-ttu-id="c78d6-1829">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1829">**Status code**</span></span>

<span data-ttu-id="c78d6-1830">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1830">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1831">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1831">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1832">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1832">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1833">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1833">200</span></span> | <span data-ttu-id="c78d6-1834">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1834">OK</span></span> |
| <span data-ttu-id="c78d6-1835">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1835">4XX</span></span> | <span data-ttu-id="c78d6-1836">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1836">Error codes</span></span> |
| <span data-ttu-id="c78d6-1837">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1837">5XX</span></span> | <span data-ttu-id="c78d6-1838">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1838">Error codes</span></span> |

<span data-ttu-id="c78d6-1839">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1839">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1840">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1840">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1841">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1841">HoloLens</span></span>
* <span data-ttu-id="c78d6-1842">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1842">IoT</span></span>

<hr>

## <a name="networking"></a><span data-ttu-id="c78d6-1843">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="c78d6-1843">Networking</span></span>

<hr>

### <a name="get-the-current-ip-configuration"></a><span data-ttu-id="c78d6-1844">現在の IP 構成を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1844">Get the current IP configuration</span></span>

<span data-ttu-id="c78d6-1845">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1845">**Request**</span></span>

<span data-ttu-id="c78d6-1846">次の要求形式を使用して、現在の IP 構成を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1846">You can get the current IP configuration by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1847">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1847">Method</span></span>      | <span data-ttu-id="c78d6-1848">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1848">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1849">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1849">GET</span></span> | <span data-ttu-id="c78d6-1850">/api/networking/ipconfig</span><span class="sxs-lookup"><span data-stu-id="c78d6-1850">/api/networking/ipconfig</span></span> |


<span data-ttu-id="c78d6-1851">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1851">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1852">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1852">None</span></span>

<span data-ttu-id="c78d6-1853">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1853">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1854">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1854">None</span></span>

<span data-ttu-id="c78d6-1855">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1855">**Request body**</span></span>

- <span data-ttu-id="c78d6-1856">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1856">None</span></span>

<span data-ttu-id="c78d6-1857">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1857">**Response**</span></span>

<span data-ttu-id="c78d6-1858">応答には、次のテンプレートの IP 構成が含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1858">The response includes the IP configuration in the following template.</span></span>

```json
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

<span data-ttu-id="c78d6-1859">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1859">**Status code**</span></span>

<span data-ttu-id="c78d6-1860">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1860">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1861">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1861">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1862">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1862">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1863">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1863">200</span></span> | <span data-ttu-id="c78d6-1864">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1864">OK</span></span> |
| <span data-ttu-id="c78d6-1865">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1865">4XX</span></span> | <span data-ttu-id="c78d6-1866">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1866">Error codes</span></span> |
| <span data-ttu-id="c78d6-1867">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1867">5XX</span></span> | <span data-ttu-id="c78d6-1868">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1868">Error codes</span></span> |

<span data-ttu-id="c78d6-1869">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1869">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1870">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1870">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1871">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1871">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1872">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1872">Xbox</span></span>
* <span data-ttu-id="c78d6-1873">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1873">HoloLens</span></span>
* <span data-ttu-id="c78d6-1874">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1874">IoT</span></span>

<hr>

### <a name="set-a-static-ip-address-ipv4-configuration"></a><span data-ttu-id="c78d6-1875">静的 IP アドレス (IPV4 構成) の設定します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1875">Set a static IP address (IPV4 configuration)</span></span>

<span data-ttu-id="c78d6-1876">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1876">**Request**</span></span>

<span data-ttu-id="c78d6-1877">静的 IP と DNS で IPV4 構成を設定します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1877">Sets the IPV4 configuration with static IP and DNS.</span></span> <span data-ttu-id="c78d6-1878">静的 IP が指定されていない場合は、DHCP が使用できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1878">If a static IP is not specified, then it enables DHCP.</span></span> <span data-ttu-id="c78d6-1879">静的 IP が指定されている場合は、DNS も指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1879">If a static IP is specified, then DNS must be specified also.</span></span>
 
| <span data-ttu-id="c78d6-1880">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1880">Method</span></span>      | <span data-ttu-id="c78d6-1881">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1881">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1882">PUT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1882">PUT</span></span> | <span data-ttu-id="c78d6-1883">/api/networking/ipv4config</span><span class="sxs-lookup"><span data-stu-id="c78d6-1883">/api/networking/ipv4config</span></span> |


<span data-ttu-id="c78d6-1884">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1884">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-1885">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1885">URI parameter</span></span> | <span data-ttu-id="c78d6-1886">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1886">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="c78d6-1887">AdapterName</span><span class="sxs-lookup"><span data-stu-id="c78d6-1887">AdapterName</span></span> | <span data-ttu-id="c78d6-1888">(**必要**) ネットワーク インターフェイスの GUID。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1888">(**required**) The network interface GUID.</span></span> |
| <span data-ttu-id="c78d6-1889">IPAddress</span><span class="sxs-lookup"><span data-stu-id="c78d6-1889">IPAddress</span></span> | <span data-ttu-id="c78d6-1890">設定する静的 IP アドレス。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1890">The static IP address to set.</span></span> |
| <span data-ttu-id="c78d6-1891">サブネット マスク</span><span class="sxs-lookup"><span data-stu-id="c78d6-1891">SubnetMask</span></span> | <span data-ttu-id="c78d6-1892">(**必要**場合*IPAddress*が null でない)、静的なサブネット マスク。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1892">(**required** if *IPAddress* is not null) The static subnet mask.</span></span> |
| <span data-ttu-id="c78d6-1893">DefaultGateway</span><span class="sxs-lookup"><span data-stu-id="c78d6-1893">DefaultGateway</span></span> | <span data-ttu-id="c78d6-1894">(**必要**場合*IPAddress*が null でない)、静的な既定ゲートウェイ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1894">(**required** if *IPAddress* is not null) The static default gateway.</span></span> |
| <span data-ttu-id="c78d6-1895">PrimaryDNS</span><span class="sxs-lookup"><span data-stu-id="c78d6-1895">PrimaryDNS</span></span> | <span data-ttu-id="c78d6-1896">(**必要**場合*IPAddress*が null でない) を設定する静的なプライマリ DNS。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1896">(**required** if *IPAddress* is not null) The static primary DNS to set.</span></span> |
| <span data-ttu-id="c78d6-1897">SecondayDNS</span><span class="sxs-lookup"><span data-stu-id="c78d6-1897">SecondayDNS</span></span> | <span data-ttu-id="c78d6-1898">(**必要**場合*PrimaryDNS*が null でない) を設定する静的セカンダリ DNS。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1898">(**required** if *PrimaryDNS* is not null) The static secondary DNS to set.</span></span> |

<span data-ttu-id="c78d6-1899">わかりやすくするため、DHCP にインターフェイスを設定するシリアル化、`AdapterName`ネットワーク上で。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1899">For clarity, to set an interface to DHCP, serialize just the `AdapterName` on the wire:</span></span>

```json
{
    "AdapterName":"{82F86C1B-2BAE-41E3-B08D-786CA44FEED7}"
}
```

<span data-ttu-id="c78d6-1900">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1900">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1901">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1901">None</span></span>

<span data-ttu-id="c78d6-1902">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1902">**Request body**</span></span>

- <span data-ttu-id="c78d6-1903">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1903">None</span></span>

<span data-ttu-id="c78d6-1904">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1904">**Response**</span></span>

<span data-ttu-id="c78d6-1905">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1905">**Status code**</span></span>

<span data-ttu-id="c78d6-1906">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1906">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1907">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1907">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1908">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1908">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1909">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1909">200</span></span> | <span data-ttu-id="c78d6-1910">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1910">OK</span></span> |
| <span data-ttu-id="c78d6-1911">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1911">4XX</span></span> | <span data-ttu-id="c78d6-1912">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1912">Error codes</span></span> |
| <span data-ttu-id="c78d6-1913">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1913">5XX</span></span> | <span data-ttu-id="c78d6-1914">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1914">Error codes</span></span> |

<span data-ttu-id="c78d6-1915">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1915">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1916">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1916">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1917">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1917">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1918">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1918">Xbox</span></span>
* <span data-ttu-id="c78d6-1919">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1919">HoloLens</span></span>
* <span data-ttu-id="c78d6-1920">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1920">IoT</span></span>

<hr>

### <a name="enumerate-wireless-network-interfaces"></a><span data-ttu-id="c78d6-1921">ワイヤレス ネットワーク インターフェイスを列挙する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1921">Enumerate wireless network interfaces</span></span>

<span data-ttu-id="c78d6-1922">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1922">**Request**</span></span>

<span data-ttu-id="c78d6-1923">次の要求形式を使用して、利用可能なワイヤレス ネットワーク インターフェイスを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1923">You can enumerate the available wireless network interfaces by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1924">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1924">Method</span></span>      | <span data-ttu-id="c78d6-1925">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1925">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1926">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1926">GET</span></span> | <span data-ttu-id="c78d6-1927">/api/wifi/interfaces</span><span class="sxs-lookup"><span data-stu-id="c78d6-1927">/api/wifi/interfaces</span></span> |


<span data-ttu-id="c78d6-1928">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1928">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-1929">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1929">None</span></span>

<span data-ttu-id="c78d6-1930">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1930">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1931">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1931">None</span></span>

<span data-ttu-id="c78d6-1932">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1932">**Request body**</span></span>

- <span data-ttu-id="c78d6-1933">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1933">None</span></span>

<span data-ttu-id="c78d6-1934">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1934">**Response**</span></span>

<span data-ttu-id="c78d6-1935">次の形式の利用可能なワイヤレス インターフェイスと詳細の一覧。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1935">A list of the available wireless interfaces with details in the following format.</span></span>

```json 
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

<span data-ttu-id="c78d6-1936">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1936">**Status code**</span></span>

<span data-ttu-id="c78d6-1937">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1937">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1938">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1938">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1939">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1939">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1940">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1940">200</span></span> | <span data-ttu-id="c78d6-1941">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1941">OK</span></span> |
| <span data-ttu-id="c78d6-1942">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1942">4XX</span></span> | <span data-ttu-id="c78d6-1943">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1943">Error codes</span></span> |
| <span data-ttu-id="c78d6-1944">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1944">5XX</span></span> | <span data-ttu-id="c78d6-1945">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1945">Error codes</span></span> |

<span data-ttu-id="c78d6-1946">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1946">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1947">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1947">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1948">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1948">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1949">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1949">Xbox</span></span>
* <span data-ttu-id="c78d6-1950">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1950">HoloLens</span></span>
* <span data-ttu-id="c78d6-1951">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1951">IoT</span></span>

<hr>

### <a name="enumerate-wireless-networks"></a><span data-ttu-id="c78d6-1952">ワイヤレス ネットワークを列挙する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1952">Enumerate wireless networks</span></span>

<span data-ttu-id="c78d6-1953">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1953">**Request**</span></span>

<span data-ttu-id="c78d6-1954">次の要求形式を使用して、指定されたインターフェイスのワイヤレス ネットワークの一覧を列挙できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1954">You can enumerate the list of wireless networks on the specified interface by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1955">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1955">Method</span></span>      | <span data-ttu-id="c78d6-1956">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1956">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1957">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-1957">GET</span></span> | <span data-ttu-id="c78d6-1958">/api/wifi/networks</span><span class="sxs-lookup"><span data-stu-id="c78d6-1958">/api/wifi/networks</span></span> |


<span data-ttu-id="c78d6-1959">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1959">**URI parameters**</span></span>

<span data-ttu-id="c78d6-1960">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1960">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-1961">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1961">URI parameter</span></span> | <span data-ttu-id="c78d6-1962">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1962">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-1963">インターフェイス</span><span class="sxs-lookup"><span data-stu-id="c78d6-1963">interface</span></span>   | <span data-ttu-id="c78d6-1964">(**必須**) ワイヤレス ネットワークの検索に使用するネットワーク インターフェイスの GUID (括弧は不要)。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1964">(**required**) The GUID for the network interface to use to search for wireless networks, without brackets.</span></span> |

<span data-ttu-id="c78d6-1965">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1965">**Request headers**</span></span>

- <span data-ttu-id="c78d6-1966">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1966">None</span></span>

<span data-ttu-id="c78d6-1967">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1967">**Request body**</span></span>

- <span data-ttu-id="c78d6-1968">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-1968">None</span></span>

<span data-ttu-id="c78d6-1969">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1969">**Response**</span></span>

<span data-ttu-id="c78d6-1970">指定された*インターフェイス*で見つかったワイヤレス ネットワークの一覧。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1970">The list of wireless networks found on the provided *interface*.</span></span> <span data-ttu-id="c78d6-1971">これには、ネットワークの詳細が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1971">This includes details for the networks in the following format.</span></span>

```json
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

<span data-ttu-id="c78d6-1972">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1972">**Status code**</span></span>

<span data-ttu-id="c78d6-1973">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1973">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-1974">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1974">HTTP status code</span></span>      | <span data-ttu-id="c78d6-1975">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1975">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1976">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-1976">200</span></span> | <span data-ttu-id="c78d6-1977">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-1977">OK</span></span> |
| <span data-ttu-id="c78d6-1978">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1978">4XX</span></span> | <span data-ttu-id="c78d6-1979">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1979">Error codes</span></span> |
| <span data-ttu-id="c78d6-1980">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-1980">5XX</span></span> | <span data-ttu-id="c78d6-1981">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-1981">Error codes</span></span> |

<span data-ttu-id="c78d6-1982">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1982">**Available device families**</span></span>

* <span data-ttu-id="c78d6-1983">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-1983">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-1984">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-1984">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-1985">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-1985">Xbox</span></span>
* <span data-ttu-id="c78d6-1986">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-1986">HoloLens</span></span>
* <span data-ttu-id="c78d6-1987">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-1987">IoT</span></span>

<hr>

### <a name="connect-and-disconnect-to-a-wi-fi-network"></a><span data-ttu-id="c78d6-1988">Wi-Fi ネットワークを接続および切断する</span><span class="sxs-lookup"><span data-stu-id="c78d6-1988">Connect and disconnect to a Wi-Fi network.</span></span>

<span data-ttu-id="c78d6-1989">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1989">**Request**</span></span>

<span data-ttu-id="c78d6-1990">次の要求形式を使用して、Wi-Fi ネットワークを接続および切断できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1990">You can connect or disconnect to a Wi-Fi network by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-1991">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-1991">Method</span></span>      | <span data-ttu-id="c78d6-1992">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-1992">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-1993">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-1993">POST</span></span> | <span data-ttu-id="c78d6-1994">/api/wifi/network</span><span class="sxs-lookup"><span data-stu-id="c78d6-1994">/api/wifi/network</span></span> |


<span data-ttu-id="c78d6-1995">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-1995">**URI parameters**</span></span>

<span data-ttu-id="c78d6-1996">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-1996">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-1997">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-1997">URI parameter</span></span> | <span data-ttu-id="c78d6-1998">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-1998">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-1999">インターフェイス</span><span class="sxs-lookup"><span data-stu-id="c78d6-1999">interface</span></span>   | <span data-ttu-id="c78d6-2000">(**必須**) ネットワークへの接続に使用するネットワーク インターフェイスの GUID。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2000">(**required**) The GUID for the network interface you use to connect to the network.</span></span> |
| <span data-ttu-id="c78d6-2001">op</span><span class="sxs-lookup"><span data-stu-id="c78d6-2001">op</span></span>   | <span data-ttu-id="c78d6-2002">(**必須**) 実行するアクションを示します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2002">(**required**) Indicates the action to take.</span></span> <span data-ttu-id="c78d6-2003">設定可能な値は、connect または disconnect です。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2003">Possible values are connect or disconnect.</span></span>|
| <span data-ttu-id="c78d6-2004">ssid</span><span class="sxs-lookup"><span data-stu-id="c78d6-2004">ssid</span></span>   | <span data-ttu-id="c78d6-2005">(***op* == connect の場合は必須**) 接続先 SSID。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2005">(**required if *op* == connect**) The SSID to connect to.</span></span> |
| <span data-ttu-id="c78d6-2006">key</span><span class="sxs-lookup"><span data-stu-id="c78d6-2006">key</span></span>   | <span data-ttu-id="c78d6-2007">(***op* == connect で、ネットワークで認証が必要な場合は必須**) 共有キー。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2007">(**required if *op* == connect and network requires authentication**) The shared key.</span></span> |
| <span data-ttu-id="c78d6-2008">createprofile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2008">createprofile</span></span> | <span data-ttu-id="c78d6-2009">(**必要**) デバイスでネットワークのプロファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2009">(**required**) Create a profile for the network on the device.</span></span>  <span data-ttu-id="c78d6-2010">これにより、今後、デバイスはネットワークに自動接続されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2010">This will cause the device to auto-connect to the network in the future.</span></span> <span data-ttu-id="c78d6-2011">**yes** または **no** を指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2011">This can be **yes** or **no**.</span></span> |

<span data-ttu-id="c78d6-2012">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2012">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2013">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2013">None</span></span>

<span data-ttu-id="c78d6-2014">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2014">**Request body**</span></span>

- <span data-ttu-id="c78d6-2015">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2015">None</span></span>

<span data-ttu-id="c78d6-2016">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2016">**Response**</span></span>

<span data-ttu-id="c78d6-2017">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2017">**Status code**</span></span>

<span data-ttu-id="c78d6-2018">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2018">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2019">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2019">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2020">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2020">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2021">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2021">200</span></span> | <span data-ttu-id="c78d6-2022">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2022">OK</span></span> |

<span data-ttu-id="c78d6-2023">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2023">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2024">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2024">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2025">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2025">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2026">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2026">Xbox</span></span>
* <span data-ttu-id="c78d6-2027">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2027">HoloLens</span></span>
* <span data-ttu-id="c78d6-2028">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2028">IoT</span></span>

<hr>

### <a name="delete-a-wi-fi-profile"></a><span data-ttu-id="c78d6-2029">Wi-Fi のプロファイルを削除する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2029">Delete a Wi-Fi profile</span></span>

<span data-ttu-id="c78d6-2030">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2030">**Request**</span></span>

<span data-ttu-id="c78d6-2031">次の要求形式を使用して、特定のインターフェイス上のネットワークに関連付けられたプロファイルを削除できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2031">You can delete a profile associated with a network on a specific interface by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-2032">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2032">Method</span></span>      | <span data-ttu-id="c78d6-2033">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2033">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2034">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-2034">DELETE</span></span> | <span data-ttu-id="c78d6-2035">/api/wifi/profile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2035">/api/wifi/profile</span></span> |


<span data-ttu-id="c78d6-2036">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2036">**URI parameters**</span></span>

<span data-ttu-id="c78d6-2037">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2037">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-2038">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2038">URI parameter</span></span> | <span data-ttu-id="c78d6-2039">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2039">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-2040">インターフェイス</span><span class="sxs-lookup"><span data-stu-id="c78d6-2040">interface</span></span>   | <span data-ttu-id="c78d6-2041">(**必須**) 削除するプロファイルに関連付けられたネットワーク インターフェイスの GUID。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2041">(**required**) The GUID for the network interface associated with the profile to delete.</span></span> |
| <span data-ttu-id="c78d6-2042">プロファイル</span><span class="sxs-lookup"><span data-stu-id="c78d6-2042">profile</span></span>   | <span data-ttu-id="c78d6-2043">(**必須**) 削除するプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2043">(**required**) The name of the profile to delete.</span></span> |

<span data-ttu-id="c78d6-2044">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2044">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2045">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2045">None</span></span>

<span data-ttu-id="c78d6-2046">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2046">**Request body**</span></span>

- <span data-ttu-id="c78d6-2047">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2047">None</span></span>

<span data-ttu-id="c78d6-2048">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2048">**Response**</span></span>

<span data-ttu-id="c78d6-2049">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2049">**Status code**</span></span>

<span data-ttu-id="c78d6-2050">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2050">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2051">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2051">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2052">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2052">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2053">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2053">200</span></span> | <span data-ttu-id="c78d6-2054">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2054">OK</span></span> |

<span data-ttu-id="c78d6-2055">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2055">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2056">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2056">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2057">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2057">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2058">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2058">Xbox</span></span>
* <span data-ttu-id="c78d6-2059">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2059">HoloLens</span></span>
* <span data-ttu-id="c78d6-2060">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2060">IoT</span></span>

<hr>

## <a name="windows-error-reporting-wer"></a><span data-ttu-id="c78d6-2061">Windows エラー報告 (WER)</span><span class="sxs-lookup"><span data-stu-id="c78d6-2061">Windows Error Reporting (WER)</span></span>

<hr>

### <a name="download-a-windows-error-reporting-wer-file"></a><span data-ttu-id="c78d6-2062">Windows エラー報告 (WER) ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="c78d6-2062">Download a Windows error reporting (WER) file</span></span>

<span data-ttu-id="c78d6-2063">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2063">**Request**</span></span>

<span data-ttu-id="c78d6-2064">次の要求形式を使用して、WER 関連のファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2064">You can download a WER-related file by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-2065">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2065">Method</span></span>      | <span data-ttu-id="c78d6-2066">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2066">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2067">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2067">GET</span></span> | <span data-ttu-id="c78d6-2068">/api/wer/report/file</span><span class="sxs-lookup"><span data-stu-id="c78d6-2068">/api/wer/report/file</span></span> |


<span data-ttu-id="c78d6-2069">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2069">**URI parameters**</span></span>

<span data-ttu-id="c78d6-2070">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2070">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-2071">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2071">URI parameter</span></span> | <span data-ttu-id="c78d6-2072">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2072">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-2073">ユーザー</span><span class="sxs-lookup"><span data-stu-id="c78d6-2073">user</span></span>   | <span data-ttu-id="c78d6-2074">(**必須**) レポートに関連付けられたユーザー名。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2074">(**required**) The user name associated with the report.</span></span> |
| <span data-ttu-id="c78d6-2075">type</span><span class="sxs-lookup"><span data-stu-id="c78d6-2075">type</span></span>   | <span data-ttu-id="c78d6-2076">(**必須**) レポートの種類。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2076">(**required**) The type of report.</span></span> <span data-ttu-id="c78d6-2077">これは **queried** または **archived** のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2077">This can be either **queried** or **archived**.</span></span> |
| <span data-ttu-id="c78d6-2078">name</span><span class="sxs-lookup"><span data-stu-id="c78d6-2078">name</span></span>   | <span data-ttu-id="c78d6-2079">(**必須**) レポートの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2079">(**required**) The name of the report.</span></span> <span data-ttu-id="c78d6-2080">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2080">This should be base64 encoded.</span></span> |
| <span data-ttu-id="c78d6-2081">ファイル</span><span class="sxs-lookup"><span data-stu-id="c78d6-2081">file</span></span>   | <span data-ttu-id="c78d6-2082">(**必須**) レポートからダウンロードするファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2082">(**required**) The name of the file to download from the report.</span></span> <span data-ttu-id="c78d6-2083">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2083">This should be base64 encoded.</span></span> |

<span data-ttu-id="c78d6-2084">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2084">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2085">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2085">None</span></span>

<span data-ttu-id="c78d6-2086">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2086">**Request body**</span></span>

- <span data-ttu-id="c78d6-2087">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2087">None</span></span>

<span data-ttu-id="c78d6-2088">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2088">**Response**</span></span>

- <span data-ttu-id="c78d6-2089">応答には、要求したファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2089">Response contains the requested file.</span></span> 

<span data-ttu-id="c78d6-2090">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2090">**Status code**</span></span>

<span data-ttu-id="c78d6-2091">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2091">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2092">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2092">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2093">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2093">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2094">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2094">200</span></span> | <span data-ttu-id="c78d6-2095">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2095">OK</span></span> |
| <span data-ttu-id="c78d6-2096">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2096">4XX</span></span> | <span data-ttu-id="c78d6-2097">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2097">Error codes</span></span> |
| <span data-ttu-id="c78d6-2098">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2098">5XX</span></span> | <span data-ttu-id="c78d6-2099">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2099">Error codes</span></span> |

<span data-ttu-id="c78d6-2100">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2100">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2101">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2101">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2102">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2102">HoloLens</span></span>
* <span data-ttu-id="c78d6-2103">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2103">IoT</span></span>

<hr>

### <a name="enumerate-files-in-a-windows-error-reporting-wer-report"></a><span data-ttu-id="c78d6-2104">Windows エラー報告 (WER) レポート内のファイルを列挙する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2104">Enumerate files in a Windows error reporting (WER) report</span></span>

<span data-ttu-id="c78d6-2105">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2105">**Request**</span></span>

<span data-ttu-id="c78d6-2106">次の要求形式を使用して、WER レポート内のファイルを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2106">You can enumerate the files in a WER report by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-2107">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2107">Method</span></span>      | <span data-ttu-id="c78d6-2108">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2108">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2109">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2109">GET</span></span> | <span data-ttu-id="c78d6-2110">/api/wer/report/files</span><span class="sxs-lookup"><span data-stu-id="c78d6-2110">/api/wer/report/files</span></span> |


<span data-ttu-id="c78d6-2111">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2111">**URI parameters**</span></span>

<span data-ttu-id="c78d6-2112">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2112">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-2113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2113">URI parameter</span></span> | <span data-ttu-id="c78d6-2114">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2114">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-2115">ユーザー</span><span class="sxs-lookup"><span data-stu-id="c78d6-2115">user</span></span>   | <span data-ttu-id="c78d6-2116">(**必須**) レポートに関連付けられたユーザー。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2116">(**required**) The user associated with the report.</span></span> |
| <span data-ttu-id="c78d6-2117">type</span><span class="sxs-lookup"><span data-stu-id="c78d6-2117">type</span></span>   | <span data-ttu-id="c78d6-2118">(**必須**) レポートの種類。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2118">(**required**) The type of report.</span></span> <span data-ttu-id="c78d6-2119">これは **queried** または **archived** のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2119">This can be either **queried** or **archived**.</span></span> |
| <span data-ttu-id="c78d6-2120">name</span><span class="sxs-lookup"><span data-stu-id="c78d6-2120">name</span></span>   | <span data-ttu-id="c78d6-2121">(**必須**) レポートの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2121">(**required**) The name of the report.</span></span> <span data-ttu-id="c78d6-2122">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2122">This should be base64 encoded.</span></span> |

<span data-ttu-id="c78d6-2123">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2123">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2124">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2124">None</span></span>

<span data-ttu-id="c78d6-2125">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2125">**Request body**</span></span>

```json
{"Files": [
    {
        "Name": string, (Filename, not base64 encoded)
        "Size": int (bytes)
    },...
]}
```

<span data-ttu-id="c78d6-2126">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2126">**Response**</span></span>

<span data-ttu-id="c78d6-2127">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2127">**Status code**</span></span>

<span data-ttu-id="c78d6-2128">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2128">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2129">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2129">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2130">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2130">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2131">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2131">200</span></span> | <span data-ttu-id="c78d6-2132">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2132">OK</span></span> |
| <span data-ttu-id="c78d6-2133">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2133">4XX</span></span> | <span data-ttu-id="c78d6-2134">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2134">Error codes</span></span> |
| <span data-ttu-id="c78d6-2135">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2135">5XX</span></span> | <span data-ttu-id="c78d6-2136">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2136">Error codes</span></span> |

<span data-ttu-id="c78d6-2137">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2137">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2138">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2138">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2139">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2139">HoloLens</span></span>
* <span data-ttu-id="c78d6-2140">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2140">IoT</span></span>

<hr>

### <a name="list-the-windows-error-reporting-wer-reports"></a><span data-ttu-id="c78d6-2141">Windows エラー報告 (WER) レポートを一覧表示する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2141">List the Windows error reporting (WER) reports</span></span>

<span data-ttu-id="c78d6-2142">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2142">**Request**</span></span>

<span data-ttu-id="c78d6-2143">次の要求形式を使用して、WER レポートを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2143">You can get the WER reports by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-2144">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2144">Method</span></span>      | <span data-ttu-id="c78d6-2145">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2145">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2146">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2146">GET</span></span> | <span data-ttu-id="c78d6-2147">/api/wer/reports</span><span class="sxs-lookup"><span data-stu-id="c78d6-2147">/api/wer/reports</span></span> |


<span data-ttu-id="c78d6-2148">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2148">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2149">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2149">None</span></span>

<span data-ttu-id="c78d6-2150">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2150">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2151">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2151">None</span></span>

<span data-ttu-id="c78d6-2152">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2152">**Request body**</span></span>

- <span data-ttu-id="c78d6-2153">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2153">None</span></span>

<span data-ttu-id="c78d6-2154">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2154">**Response**</span></span>

<span data-ttu-id="c78d6-2155">WER 報告の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2155">The WER reports in the following format.</span></span>

```json
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

<span data-ttu-id="c78d6-2156">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2156">**Status code**</span></span>

<span data-ttu-id="c78d6-2157">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2157">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2158">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2158">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2159">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2159">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2160">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2160">200</span></span> | <span data-ttu-id="c78d6-2161">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2161">OK</span></span> |
| <span data-ttu-id="c78d6-2162">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2162">4XX</span></span> | <span data-ttu-id="c78d6-2163">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2163">Error codes</span></span> |
| <span data-ttu-id="c78d6-2164">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2164">5XX</span></span> | <span data-ttu-id="c78d6-2165">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2165">Error codes</span></span> |

<span data-ttu-id="c78d6-2166">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2166">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2167">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2167">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2168">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2168">HoloLens</span></span>
* <span data-ttu-id="c78d6-2169">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2169">IoT</span></span>

<hr>

## <a name="windows-performance-recorder-wpr"></a><span data-ttu-id="c78d6-2170">Windows Performance Recorder (WPR)</span><span class="sxs-lookup"><span data-stu-id="c78d6-2170">Windows Performance Recorder (WPR)</span></span> 

<hr>

### <a name="start-tracing-with-a-custom-profile"></a><span data-ttu-id="c78d6-2171">カスタム プロファイルを使用してトレースを開始する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2171">Start tracing with a custom profile</span></span>

<span data-ttu-id="c78d6-2172">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2172">**Request**</span></span>

<span data-ttu-id="c78d6-2173">次の要求形式を使用して、WPR プロファイルをアップロードし、そのプロファイルを使用してトレースを開始できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2173">You can upload a WPR profile and start tracing using that profile by using the following request format.</span></span>  <span data-ttu-id="c78d6-2174">一度に実行できるトレースは 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2174">Only one trace can run at a time.</span></span> <span data-ttu-id="c78d6-2175">プロファイルはデバイス上に残りません。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2175">The profile will not remain on the device.</span></span> 
 
| <span data-ttu-id="c78d6-2176">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2176">Method</span></span>      | <span data-ttu-id="c78d6-2177">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2177">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2178">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-2178">POST</span></span> | <span data-ttu-id="c78d6-2179">/api/wpr/customtrace</span><span class="sxs-lookup"><span data-stu-id="c78d6-2179">/api/wpr/customtrace</span></span> |


<span data-ttu-id="c78d6-2180">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2180">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2181">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2181">None</span></span>

<span data-ttu-id="c78d6-2182">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2182">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2183">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2183">None</span></span>

<span data-ttu-id="c78d6-2184">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2184">**Request body**</span></span>

- <span data-ttu-id="c78d6-2185">カスタム WPR プロファイルが含まれる、原則に従ったマルチパートの http 本文。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2185">A multi-part conforming http body that contains the custom WPR profile.</span></span>

<span data-ttu-id="c78d6-2186">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2186">**Response**</span></span>

<span data-ttu-id="c78d6-2187">WPR セッション状態の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2187">The WPR session status in the following format.</span></span>

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

<span data-ttu-id="c78d6-2188">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2188">**Status code**</span></span>

<span data-ttu-id="c78d6-2189">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2189">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2190">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2190">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2191">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2191">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2192">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2192">200</span></span> | <span data-ttu-id="c78d6-2193">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2193">OK</span></span> |
| <span data-ttu-id="c78d6-2194">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2194">4XX</span></span> | <span data-ttu-id="c78d6-2195">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2195">Error codes</span></span> |
| <span data-ttu-id="c78d6-2196">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2196">5XX</span></span> | <span data-ttu-id="c78d6-2197">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2197">Error codes</span></span> |

<span data-ttu-id="c78d6-2198">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2198">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2199">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2199">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2200">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2200">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2201">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2201">HoloLens</span></span>
* <span data-ttu-id="c78d6-2202">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2202">IoT</span></span>

<hr>

### <a name="start-a-boot-performance-tracing-session"></a><span data-ttu-id="c78d6-2203">起動パフォーマンス トレース セッションを開始する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2203">Start a boot performance tracing session</span></span>

<span data-ttu-id="c78d6-2204">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2204">**Request**</span></span>

<span data-ttu-id="c78d6-2205">次の要求形式を使用して、WPR の起動トレース セッションを開始できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2205">You can start a boot WPR tracing session by using the following request format.</span></span> <span data-ttu-id="c78d6-2206">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2206">This is also known as a performance tracing session.</span></span>
 
| <span data-ttu-id="c78d6-2207">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2207">Method</span></span>      | <span data-ttu-id="c78d6-2208">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2208">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2209">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-2209">POST</span></span> | <span data-ttu-id="c78d6-2210">/api/wpr/boottrace</span><span class="sxs-lookup"><span data-stu-id="c78d6-2210">/api/wpr/boottrace</span></span> |


<span data-ttu-id="c78d6-2211">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2211">**URI parameters**</span></span>

<span data-ttu-id="c78d6-2212">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2212">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-2213">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2213">URI parameter</span></span> | <span data-ttu-id="c78d6-2214">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2214">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-2215">プロファイル</span><span class="sxs-lookup"><span data-stu-id="c78d6-2215">profile</span></span>   | <span data-ttu-id="c78d6-2216">(**必須**) このパラメーターは起動時に必要です。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2216">(**required**) This parameter is required on start.</span></span> <span data-ttu-id="c78d6-2217">パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2217">The name of the profile that should start a performance tracing session.</span></span> <span data-ttu-id="c78d6-2218">指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2218">The possible profiles are stored in perfprofiles/profiles.json.</span></span> |

<span data-ttu-id="c78d6-2219">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2219">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2220">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2220">None</span></span>

<span data-ttu-id="c78d6-2221">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2221">**Request body**</span></span>

- <span data-ttu-id="c78d6-2222">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2222">None</span></span>

<span data-ttu-id="c78d6-2223">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2223">**Response**</span></span>

<span data-ttu-id="c78d6-2224">この API は、開始時に次の形式で WPR セッション状態を返します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2224">On start, this API returns the WPR session status in the following format.</span></span>

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (boot)
}
```

<span data-ttu-id="c78d6-2225">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2225">**Status code**</span></span>

<span data-ttu-id="c78d6-2226">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2226">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2227">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2227">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2228">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2228">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2229">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2229">200</span></span> | <span data-ttu-id="c78d6-2230">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2230">OK</span></span> |
| <span data-ttu-id="c78d6-2231">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2231">4XX</span></span> | <span data-ttu-id="c78d6-2232">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2232">Error codes</span></span> |
| <span data-ttu-id="c78d6-2233">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2233">5XX</span></span> | <span data-ttu-id="c78d6-2234">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2234">Error codes</span></span> |

<span data-ttu-id="c78d6-2235">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2235">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2236">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2236">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2237">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2237">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2238">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2238">HoloLens</span></span>
* <span data-ttu-id="c78d6-2239">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2239">IoT</span></span>

<hr>

### <a name="stop-a-boot-performance-tracing-session"></a><span data-ttu-id="c78d6-2240">起動パフォーマンス トレース セッションを停止する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2240">Stop a boot performance tracing session</span></span>

<span data-ttu-id="c78d6-2241">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2241">**Request**</span></span>

<span data-ttu-id="c78d6-2242">次の要求形式を使用して、WPR の起動トレース セッションを停止できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2242">You can stop a boot WPR tracing session by using the following request format.</span></span> <span data-ttu-id="c78d6-2243">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2243">This is also known as a performance tracing session.</span></span>
 
| <span data-ttu-id="c78d6-2244">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2244">Method</span></span>      | <span data-ttu-id="c78d6-2245">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2245">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2246">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2246">GET</span></span> | <span data-ttu-id="c78d6-2247">/api/wpr/boottrace</span><span class="sxs-lookup"><span data-stu-id="c78d6-2247">/api/wpr/boottrace</span></span> |


<span data-ttu-id="c78d6-2248">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2248">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2249">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2249">None</span></span>

<span data-ttu-id="c78d6-2250">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2250">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2251">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2251">None</span></span>

<span data-ttu-id="c78d6-2252">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2252">**Request body**</span></span>

- <span data-ttu-id="c78d6-2253">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2253">None</span></span>

<span data-ttu-id="c78d6-2254">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2254">**Response**</span></span>

-  <span data-ttu-id="c78d6-2255">なし。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2255">None.</span></span>  <span data-ttu-id="c78d6-2256">**注:** これは、実行時間の長い操作です。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2256">**Note:** This is a long running operation.</span></span>  <span data-ttu-id="c78d6-2257">ETL のディスクへの書き込みが終了すると、制御が戻ります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2257">It will return when the ETL is finished writing to disk.</span></span>

<span data-ttu-id="c78d6-2258">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2258">**Status code**</span></span>

<span data-ttu-id="c78d6-2259">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2259">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2260">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2260">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2261">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2261">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2262">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2262">200</span></span> | <span data-ttu-id="c78d6-2263">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2263">OK</span></span> |
| <span data-ttu-id="c78d6-2264">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2264">4XX</span></span> | <span data-ttu-id="c78d6-2265">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2265">Error codes</span></span> |
| <span data-ttu-id="c78d6-2266">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2266">5XX</span></span> | <span data-ttu-id="c78d6-2267">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2267">Error codes</span></span> |

<span data-ttu-id="c78d6-2268">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2268">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2269">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2269">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2270">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2270">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2271">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2271">HoloLens</span></span>
* <span data-ttu-id="c78d6-2272">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2272">IoT</span></span>

<hr>

### <a name="start-a-performance-tracing-session"></a><span data-ttu-id="c78d6-2273">パフォーマンス トレース セッションを開始する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2273">Start a performance tracing session</span></span>

<span data-ttu-id="c78d6-2274">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2274">**Request**</span></span>

<span data-ttu-id="c78d6-2275">次の要求形式を使用して、WPR のトレース セッションを開始できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2275">You can start a WPR tracing session by using the following request format.</span></span> <span data-ttu-id="c78d6-2276">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2276">This is also known as a performance tracing session.</span></span>  <span data-ttu-id="c78d6-2277">一度に実行できるトレースは 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2277">Only one trace can run at a time.</span></span> 
 
| <span data-ttu-id="c78d6-2278">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2278">Method</span></span>      | <span data-ttu-id="c78d6-2279">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2279">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2280">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-2280">POST</span></span> | <span data-ttu-id="c78d6-2281">/api/wpr/trace</span><span class="sxs-lookup"><span data-stu-id="c78d6-2281">/api/wpr/trace</span></span> |


<span data-ttu-id="c78d6-2282">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2282">**URI parameters**</span></span>

<span data-ttu-id="c78d6-2283">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2283">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="c78d6-2284">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2284">URI parameter</span></span> | <span data-ttu-id="c78d6-2285">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2285">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-2286">プロファイル</span><span class="sxs-lookup"><span data-stu-id="c78d6-2286">profile</span></span>   | <span data-ttu-id="c78d6-2287">(**必須**) パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2287">(**required**) The name of the profile that should start a performance tracing session.</span></span> <span data-ttu-id="c78d6-2288">指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2288">The possible profiles are stored in perfprofiles/profiles.json.</span></span> |

<span data-ttu-id="c78d6-2289">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2289">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2290">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2290">None</span></span>

<span data-ttu-id="c78d6-2291">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2291">**Request body**</span></span>

- <span data-ttu-id="c78d6-2292">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2292">None</span></span>

<span data-ttu-id="c78d6-2293">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2293">**Response**</span></span>

<span data-ttu-id="c78d6-2294">この API は、開始時に次の形式で WPR セッション状態を返します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2294">On start, this API returns the WPR session status in the following format.</span></span>

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal)
}
```

<span data-ttu-id="c78d6-2295">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2295">**Status code**</span></span>

<span data-ttu-id="c78d6-2296">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2296">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2297">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2297">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2298">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2298">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2299">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2299">200</span></span> | <span data-ttu-id="c78d6-2300">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2300">OK</span></span> |
| <span data-ttu-id="c78d6-2301">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2301">4XX</span></span> | <span data-ttu-id="c78d6-2302">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2302">Error codes</span></span> |
| <span data-ttu-id="c78d6-2303">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2303">5XX</span></span> | <span data-ttu-id="c78d6-2304">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2304">Error codes</span></span> |

<span data-ttu-id="c78d6-2305">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2305">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2306">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2306">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2307">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2307">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2308">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2308">HoloLens</span></span>
* <span data-ttu-id="c78d6-2309">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2309">IoT</span></span>

<hr>

### <a name="stop-a-performance-tracing-session"></a><span data-ttu-id="c78d6-2310">パフォーマンスのトレース セッションを停止する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2310">Stop a performance tracing session</span></span>

<span data-ttu-id="c78d6-2311">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2311">**Request**</span></span>

<span data-ttu-id="c78d6-2312">次の要求形式を使用して、WPR のトレース セッションを停止できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2312">You can stop a WPR tracing session by using the following request format.</span></span> <span data-ttu-id="c78d6-2313">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2313">This is also known as a performance tracing session.</span></span>
 
| <span data-ttu-id="c78d6-2314">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2314">Method</span></span>      | <span data-ttu-id="c78d6-2315">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2315">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2316">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2316">GET</span></span> | <span data-ttu-id="c78d6-2317">/api/wpr/trace</span><span class="sxs-lookup"><span data-stu-id="c78d6-2317">/api/wpr/trace</span></span> |


<span data-ttu-id="c78d6-2318">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2318">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2319">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2319">None</span></span>

<span data-ttu-id="c78d6-2320">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2320">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2321">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2321">None</span></span>

<span data-ttu-id="c78d6-2322">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2322">**Request body**</span></span>

- <span data-ttu-id="c78d6-2323">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2323">None</span></span>

<span data-ttu-id="c78d6-2324">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2324">**Response**</span></span>

- <span data-ttu-id="c78d6-2325">なし。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2325">None.</span></span>  <span data-ttu-id="c78d6-2326">**注:** これは、実行時間の長い操作です。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2326">**Note:** This is a long running operation.</span></span>  <span data-ttu-id="c78d6-2327">ETL のディスクへの書き込みが終了すると、制御が戻ります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2327">It will return when the ETL is finished writing to disk.</span></span>  

<span data-ttu-id="c78d6-2328">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2328">**Status code**</span></span>

<span data-ttu-id="c78d6-2329">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2329">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2330">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2330">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2331">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2331">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2332">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2332">200</span></span> | <span data-ttu-id="c78d6-2333">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2333">OK</span></span> |
| <span data-ttu-id="c78d6-2334">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2334">4XX</span></span> | <span data-ttu-id="c78d6-2335">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2335">Error codes</span></span> |
| <span data-ttu-id="c78d6-2336">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2336">5XX</span></span> | <span data-ttu-id="c78d6-2337">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2337">Error codes</span></span> |

<span data-ttu-id="c78d6-2338">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2338">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2339">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2339">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2340">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2340">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2341">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2341">HoloLens</span></span>
* <span data-ttu-id="c78d6-2342">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2342">IoT</span></span>

<hr>

### <a name="retrieve-the-status-of-a-tracing-session"></a><span data-ttu-id="c78d6-2343">トレース セッションの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2343">Retrieve the status of a tracing session</span></span>

<span data-ttu-id="c78d6-2344">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2344">**Request**</span></span>

<span data-ttu-id="c78d6-2345">次の要求形式を使用して、現在の WPR セッションの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2345">You can retrieve the status of the current WPR session by using the following request format.</span></span>
 
| <span data-ttu-id="c78d6-2346">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2346">Method</span></span>      | <span data-ttu-id="c78d6-2347">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2347">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2348">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2348">GET</span></span> | <span data-ttu-id="c78d6-2349">/api/wpr/status</span><span class="sxs-lookup"><span data-stu-id="c78d6-2349">/api/wpr/status</span></span> |


<span data-ttu-id="c78d6-2350">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2350">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2351">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2351">None</span></span>

<span data-ttu-id="c78d6-2352">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2352">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2353">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2353">None</span></span>

<span data-ttu-id="c78d6-2354">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2354">**Request body**</span></span>

- <span data-ttu-id="c78d6-2355">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2355">None</span></span>

<span data-ttu-id="c78d6-2356">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2356">**Response**</span></span>

<span data-ttu-id="c78d6-2357">WPR トレース セッションの状態の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2357">The status of the WPR tracing session in the following format.</span></span>

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

<span data-ttu-id="c78d6-2358">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2358">**Status code**</span></span>

<span data-ttu-id="c78d6-2359">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2359">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2360">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2360">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2361">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2361">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2362">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2362">200</span></span> | <span data-ttu-id="c78d6-2363">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2363">OK</span></span> |
| <span data-ttu-id="c78d6-2364">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2364">4XX</span></span> | <span data-ttu-id="c78d6-2365">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2365">Error codes</span></span> |
| <span data-ttu-id="c78d6-2366">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2366">5XX</span></span> | <span data-ttu-id="c78d6-2367">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2367">Error codes</span></span> |

<span data-ttu-id="c78d6-2368">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2368">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2369">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2369">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2370">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2370">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2371">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2371">HoloLens</span></span>
* <span data-ttu-id="c78d6-2372">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2372">IoT</span></span>

<hr>

### <a name="list-completed-tracing-sessions-etls"></a><span data-ttu-id="c78d6-2373">完了したトレース セッション (ETL) を一覧表示する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2373">List completed tracing sessions (ETLs)</span></span>

<span data-ttu-id="c78d6-2374">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2374">**Request**</span></span>

<span data-ttu-id="c78d6-2375">次の要求形式を使用して、デバイス上の ETL トレースの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2375">You can get a listing of ETL traces on the device using the following request format.</span></span> 

| <span data-ttu-id="c78d6-2376">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2376">Method</span></span>      | <span data-ttu-id="c78d6-2377">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2377">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2378">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2378">GET</span></span> | <span data-ttu-id="c78d6-2379">/api/wpr/tracefiles</span><span class="sxs-lookup"><span data-stu-id="c78d6-2379">/api/wpr/tracefiles</span></span> |


<span data-ttu-id="c78d6-2380">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2380">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2381">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2381">None</span></span>

<span data-ttu-id="c78d6-2382">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2382">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2383">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2383">None</span></span>

<span data-ttu-id="c78d6-2384">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2384">**Request body**</span></span>

- <span data-ttu-id="c78d6-2385">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2385">None</span></span>

<span data-ttu-id="c78d6-2386">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2386">**Response**</span></span>

<span data-ttu-id="c78d6-2387">完了したトレース セッションの一覧は次の形式で提供されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2387">The listing of completed tracing sessions is provided in the following format.</span></span>

```json
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

<span data-ttu-id="c78d6-2388">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2388">**Status code**</span></span>

<span data-ttu-id="c78d6-2389">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2389">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2390">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2390">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2391">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2391">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2392">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2392">200</span></span> | <span data-ttu-id="c78d6-2393">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2393">OK</span></span> |
| <span data-ttu-id="c78d6-2394">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2394">4XX</span></span> | <span data-ttu-id="c78d6-2395">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2395">Error codes</span></span> |
| <span data-ttu-id="c78d6-2396">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2396">5XX</span></span> | <span data-ttu-id="c78d6-2397">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2397">Error codes</span></span> |

<span data-ttu-id="c78d6-2398">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2398">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2399">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2399">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2400">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2400">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2401">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2401">HoloLens</span></span>
* <span data-ttu-id="c78d6-2402">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2402">IoT</span></span>

<hr>

### <a name="download-a-tracing-session-etl"></a><span data-ttu-id="c78d6-2403">トレース セッション (ETL) をダウンロードする</span><span class="sxs-lookup"><span data-stu-id="c78d6-2403">Download a tracing session (ETL)</span></span>

<span data-ttu-id="c78d6-2404">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2404">**Request**</span></span>

<span data-ttu-id="c78d6-2405">次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) をダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2405">You can download a tracefile (boot trace or user-mode trace) using the following request format.</span></span> 

| <span data-ttu-id="c78d6-2406">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2406">Method</span></span>      | <span data-ttu-id="c78d6-2407">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2407">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2408">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2408">GET</span></span> | <span data-ttu-id="c78d6-2409">/api/wpr/tracefile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2409">/api/wpr/tracefile</span></span> |


<span data-ttu-id="c78d6-2410">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2410">**URI parameters**</span></span>

<span data-ttu-id="c78d6-2411">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2411">You can specify the following additional parameter on the request URI:</span></span>

| <span data-ttu-id="c78d6-2412">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2412">URI parameter</span></span> | <span data-ttu-id="c78d6-2413">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2413">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-2414">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="c78d6-2414">filename</span></span>   | <span data-ttu-id="c78d6-2415">(**必須**) ダウンロードする ETL トレースの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2415">(**required**) The name of the ETL trace to download.</span></span>  <span data-ttu-id="c78d6-2416">これらは /api/wpr/tracefiles にあります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2416">These can be found in /api/wpr/tracefiles</span></span> |

<span data-ttu-id="c78d6-2417">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2417">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2418">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2418">None</span></span>

<span data-ttu-id="c78d6-2419">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2419">**Request body**</span></span>

- <span data-ttu-id="c78d6-2420">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2420">None</span></span>

<span data-ttu-id="c78d6-2421">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2421">**Response**</span></span>

- <span data-ttu-id="c78d6-2422">トレース ETL ファイルを返します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2422">Returns the trace ETL file.</span></span>

<span data-ttu-id="c78d6-2423">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2423">**Status code**</span></span>

<span data-ttu-id="c78d6-2424">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2424">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2425">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2425">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2426">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2426">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2427">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2427">200</span></span> | <span data-ttu-id="c78d6-2428">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2428">OK</span></span> |
| <span data-ttu-id="c78d6-2429">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2429">4XX</span></span> | <span data-ttu-id="c78d6-2430">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2430">Error codes</span></span> |
| <span data-ttu-id="c78d6-2431">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2431">5XX</span></span> | <span data-ttu-id="c78d6-2432">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2432">Error codes</span></span> |

<span data-ttu-id="c78d6-2433">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2433">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2434">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2434">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2435">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2435">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2436">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2436">HoloLens</span></span>
* <span data-ttu-id="c78d6-2437">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2437">IoT</span></span>

<hr>

### <a name="delete-a-tracing-session-etl"></a><span data-ttu-id="c78d6-2438">トレース セッション (ETL) を削除する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2438">Delete a tracing session (ETL)</span></span>

<span data-ttu-id="c78d6-2439">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2439">**Request**</span></span>

<span data-ttu-id="c78d6-2440">次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) を削除できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2440">You can delete a tracefile (boot trace or user-mode trace) using the following request format.</span></span> 

| <span data-ttu-id="c78d6-2441">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2441">Method</span></span>      | <span data-ttu-id="c78d6-2442">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2442">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2443">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-2443">DELETE</span></span> | <span data-ttu-id="c78d6-2444">/api/wpr/tracefile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2444">/api/wpr/tracefile</span></span> |


<span data-ttu-id="c78d6-2445">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2445">**URI parameters**</span></span>

<span data-ttu-id="c78d6-2446">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2446">You can specify the following additional parameter on the request URI:</span></span>

| <span data-ttu-id="c78d6-2447">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2447">URI parameter</span></span> | <span data-ttu-id="c78d6-2448">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2448">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="c78d6-2449">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="c78d6-2449">filename</span></span>   | <span data-ttu-id="c78d6-2450">(**必須**) 削除する ETL トレースの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2450">(**required**) The name of the ETL trace to delete.</span></span>  <span data-ttu-id="c78d6-2451">これらは /api/wpr/tracefiles にあります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2451">These can be found in /api/wpr/tracefiles</span></span> |

<span data-ttu-id="c78d6-2452">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2452">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2453">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2453">None</span></span>

<span data-ttu-id="c78d6-2454">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2454">**Request body**</span></span>

- <span data-ttu-id="c78d6-2455">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2455">None</span></span>

<span data-ttu-id="c78d6-2456">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2456">**Response**</span></span>

- <span data-ttu-id="c78d6-2457">トレース ETL ファイルを返します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2457">Returns the trace ETL file.</span></span>

<span data-ttu-id="c78d6-2458">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2458">**Status code**</span></span>

<span data-ttu-id="c78d6-2459">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2459">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2460">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2460">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2461">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2461">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2462">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2462">200</span></span> | <span data-ttu-id="c78d6-2463">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2463">OK</span></span> |
| <span data-ttu-id="c78d6-2464">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2464">4XX</span></span> | <span data-ttu-id="c78d6-2465">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2465">Error codes</span></span> |
| <span data-ttu-id="c78d6-2466">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2466">5XX</span></span> | <span data-ttu-id="c78d6-2467">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2467">Error codes</span></span> |

<span data-ttu-id="c78d6-2468">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2468">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2469">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2469">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2470">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2470">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2471">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2471">HoloLens</span></span>
* <span data-ttu-id="c78d6-2472">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2472">IoT</span></span>

<hr>

## <a name="dns-sd-tags"></a><span data-ttu-id="c78d6-2473">DNS SD タグ</span><span class="sxs-lookup"><span data-stu-id="c78d6-2473">DNS-SD Tags</span></span> 

<hr>

### <a name="view-tags"></a><span data-ttu-id="c78d6-2474">タグを表示する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2474">View Tags</span></span>

<span data-ttu-id="c78d6-2475">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2475">**Request**</span></span>

<span data-ttu-id="c78d6-2476">デバイスに現在適用されているタグを表示します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2476">View the currently applied tags for the device.</span></span>  <span data-ttu-id="c78d6-2477">これらのタグは、T キー内の DNS-SD TXT レコードを使用してアドバタイズされます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2477">These are advertised via DNS-SD TXT records in the T key.</span></span>  
 
| <span data-ttu-id="c78d6-2478">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2478">Method</span></span>      | <span data-ttu-id="c78d6-2479">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2479">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2480">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2480">GET</span></span> | <span data-ttu-id="c78d6-2481">/api/dns-sd/tags</span><span class="sxs-lookup"><span data-stu-id="c78d6-2481">/api/dns-sd/tags</span></span> |


<span data-ttu-id="c78d6-2482">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2482">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2483">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2483">None</span></span>

<span data-ttu-id="c78d6-2484">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2484">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2485">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2485">None</span></span>

<span data-ttu-id="c78d6-2486">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2486">**Request body**</span></span>

- <span data-ttu-id="c78d6-2487">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2487">None</span></span>

<span data-ttu-id="c78d6-2488">**応答** 現在適用されているタグの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2488">**Response** The currently applied tags in the following format.</span></span> 
```json
 {
    "tags": [
        "tag1", 
        "tag2", 
        ...
     ]
}
```

<span data-ttu-id="c78d6-2489">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2489">**Status code**</span></span>

<span data-ttu-id="c78d6-2490">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2490">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2491">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2491">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2492">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2492">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2493">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2493">200</span></span> | <span data-ttu-id="c78d6-2494">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2494">OK</span></span> |
| <span data-ttu-id="c78d6-2495">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2495">5XX</span></span> | <span data-ttu-id="c78d6-2496">サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="c78d6-2496">Server Error</span></span> |


<span data-ttu-id="c78d6-2497">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2497">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2498">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2498">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2499">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2499">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2500">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2500">Xbox</span></span>
* <span data-ttu-id="c78d6-2501">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2501">HoloLens</span></span>
* <span data-ttu-id="c78d6-2502">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2502">IoT</span></span>

<hr>

### <a name="delete-tags"></a><span data-ttu-id="c78d6-2503">タグを削除する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2503">Delete Tags</span></span>

<span data-ttu-id="c78d6-2504">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2504">**Request**</span></span>

<span data-ttu-id="c78d6-2505">DNS-SD によって現在アドバタイズされているすべてのタグを削除します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2505">Delete all tags currently advertised by DNS-SD.</span></span>   
 
| <span data-ttu-id="c78d6-2506">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2506">Method</span></span>      | <span data-ttu-id="c78d6-2507">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2507">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2508">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-2508">DELETE</span></span> | <span data-ttu-id="c78d6-2509">/api/dns-sd/tags</span><span class="sxs-lookup"><span data-stu-id="c78d6-2509">/api/dns-sd/tags</span></span> |


<span data-ttu-id="c78d6-2510">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2510">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2511">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2511">None</span></span>

<span data-ttu-id="c78d6-2512">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2512">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2513">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2513">None</span></span>

<span data-ttu-id="c78d6-2514">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2514">**Request body**</span></span>

- <span data-ttu-id="c78d6-2515">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2515">None</span></span>

<span data-ttu-id="c78d6-2516">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2516">**Response**</span></span>
 - <span data-ttu-id="c78d6-2517">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2517">None</span></span>

<span data-ttu-id="c78d6-2518">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2518">**Status code**</span></span>

<span data-ttu-id="c78d6-2519">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2519">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2520">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2520">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2521">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2521">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2522">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2522">200</span></span> | <span data-ttu-id="c78d6-2523">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2523">OK</span></span> |
| <span data-ttu-id="c78d6-2524">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2524">5XX</span></span> | <span data-ttu-id="c78d6-2525">サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="c78d6-2525">Server Error</span></span> |


<span data-ttu-id="c78d6-2526">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2526">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2527">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2527">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2528">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2528">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2529">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2529">Xbox</span></span>
* <span data-ttu-id="c78d6-2530">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2530">HoloLens</span></span>
* <span data-ttu-id="c78d6-2531">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2531">IoT</span></span>

<hr>

### <a name="delete-tag"></a><span data-ttu-id="c78d6-2532">タグを削除する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2532">Delete Tag</span></span>

<span data-ttu-id="c78d6-2533">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2533">**Request**</span></span>

<span data-ttu-id="c78d6-2534">DNS-SD によって現在アドバタイズされている 1 つのタグを削除します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2534">Delete a tag currently advertised by DNS-SD.</span></span>   
 
| <span data-ttu-id="c78d6-2535">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2535">Method</span></span>      | <span data-ttu-id="c78d6-2536">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2536">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2537">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-2537">DELETE</span></span> | <span data-ttu-id="c78d6-2538">/api/dns-sd/tag</span><span class="sxs-lookup"><span data-stu-id="c78d6-2538">/api/dns-sd/tag</span></span> |


<span data-ttu-id="c78d6-2539">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2539">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-2540">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2540">URI parameter</span></span> | <span data-ttu-id="c78d6-2541">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2541">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2542">tagValue</span><span class="sxs-lookup"><span data-stu-id="c78d6-2542">tagValue</span></span> | <span data-ttu-id="c78d6-2543">(**必須**) 削除するタグ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2543">(**required**) The tag to be removed.</span></span> |

<span data-ttu-id="c78d6-2544">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2544">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2545">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2545">None</span></span>

<span data-ttu-id="c78d6-2546">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2546">**Request body**</span></span>

- <span data-ttu-id="c78d6-2547">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2547">None</span></span>

<span data-ttu-id="c78d6-2548">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2548">**Response**</span></span>
 - <span data-ttu-id="c78d6-2549">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2549">None</span></span>

<span data-ttu-id="c78d6-2550">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2550">**Status code**</span></span>

<span data-ttu-id="c78d6-2551">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2551">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2552">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2552">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2553">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2553">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2554">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2554">200</span></span> | <span data-ttu-id="c78d6-2555">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2555">OK</span></span> |


<span data-ttu-id="c78d6-2556">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2556">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2557">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2557">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2558">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2558">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2559">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2559">Xbox</span></span>
* <span data-ttu-id="c78d6-2560">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2560">HoloLens</span></span>
* <span data-ttu-id="c78d6-2561">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2561">IoT</span></span>
 
<hr>

### <a name="add-a-tag"></a><span data-ttu-id="c78d6-2562">タグを追加する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2562">Add a Tag</span></span>

<span data-ttu-id="c78d6-2563">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2563">**Request**</span></span>

<span data-ttu-id="c78d6-2564">DNS-SD アドバタイズにタグを追加します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2564">Add a tag to the DNS-SD advertisement.</span></span>   
 
| <span data-ttu-id="c78d6-2565">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2565">Method</span></span>      | <span data-ttu-id="c78d6-2566">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2566">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2567">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-2567">POST</span></span> | <span data-ttu-id="c78d6-2568">/api/dns-sd/tag</span><span class="sxs-lookup"><span data-stu-id="c78d6-2568">/api/dns-sd/tag</span></span> |


<span data-ttu-id="c78d6-2569">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2569">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-2570">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2570">URI parameter</span></span> | <span data-ttu-id="c78d6-2571">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2571">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2572">tagValue</span><span class="sxs-lookup"><span data-stu-id="c78d6-2572">tagValue</span></span> | <span data-ttu-id="c78d6-2573">(**必要**) 追加するタグ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2573">(**required**) The tag to be added.</span></span> |

<span data-ttu-id="c78d6-2574">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2574">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2575">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2575">None</span></span>

<span data-ttu-id="c78d6-2576">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2576">**Request body**</span></span>

- <span data-ttu-id="c78d6-2577">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2577">None</span></span>

<span data-ttu-id="c78d6-2578">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2578">**Response**</span></span>
 - <span data-ttu-id="c78d6-2579">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2579">None</span></span>

<span data-ttu-id="c78d6-2580">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2580">**Status code**</span></span>

<span data-ttu-id="c78d6-2581">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2581">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2582">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2582">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2583">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2583">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2584">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2584">200</span></span> | <span data-ttu-id="c78d6-2585">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2585">OK</span></span> |
| <span data-ttu-id="c78d6-2586">401</span><span class="sxs-lookup"><span data-stu-id="c78d6-2586">401</span></span> | <span data-ttu-id="c78d6-2587">タグ領域のオーバーフロー。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2587">Tag space Overflow.</span></span>  <span data-ttu-id="c78d6-2588">提供されたタグが、結果として生成される DNS-SD サービス レコードに対して長すぎます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2588">Results when the proposed tag is too long for the resulting DNS-SD service record.</span></span> |


<span data-ttu-id="c78d6-2589">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2589">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2590">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2590">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2591">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2591">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2592">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2592">Xbox</span></span>
* <span data-ttu-id="c78d6-2593">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2593">HoloLens</span></span>
* <span data-ttu-id="c78d6-2594">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2594">IoT</span></span>

## <a name="app-file-explorer"></a><span data-ttu-id="c78d6-2595">アプリのエクスプローラー</span><span class="sxs-lookup"><span data-stu-id="c78d6-2595">App File Explorer</span></span>

<hr>

### <a name="get-known-folders"></a><span data-ttu-id="c78d6-2596">既知のフォルダーを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2596">Get known folders</span></span>

<span data-ttu-id="c78d6-2597">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2597">**Request**</span></span>

<span data-ttu-id="c78d6-2598">アクセス可能なトップ レベル フォルダーの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2598">Obtain a list of accessible top-level folders.</span></span>

| <span data-ttu-id="c78d6-2599">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2599">Method</span></span>      | <span data-ttu-id="c78d6-2600">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2600">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2601">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2601">GET</span></span> | <span data-ttu-id="c78d6-2602">/api/filesystem/apps/knownfolders</span><span class="sxs-lookup"><span data-stu-id="c78d6-2602">/api/filesystem/apps/knownfolders</span></span> |


<span data-ttu-id="c78d6-2603">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2603">**URI parameters**</span></span>

- <span data-ttu-id="c78d6-2604">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2604">None</span></span>

<span data-ttu-id="c78d6-2605">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2605">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2606">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2606">None</span></span>

<span data-ttu-id="c78d6-2607">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2607">**Request body**</span></span>

- <span data-ttu-id="c78d6-2608">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2608">None</span></span>

<span data-ttu-id="c78d6-2609">**応答** 利用可能なフォルダーの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2609">**Response** The available folders in the following format.</span></span> 
```json
 {"KnownFolders": [
    "folder0",
    "folder1",...
]}
```
<span data-ttu-id="c78d6-2610">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2610">**Status code**</span></span>

<span data-ttu-id="c78d6-2611">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2611">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2612">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2612">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2613">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2613">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2614">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2614">200</span></span> | <span data-ttu-id="c78d6-2615">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2615">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="c78d6-2616">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2616">4XX</span></span> | <span data-ttu-id="c78d6-2617">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2617">Error codes</span></span> |
| <span data-ttu-id="c78d6-2618">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2618">5XX</span></span> | <span data-ttu-id="c78d6-2619">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2619">Error codes</span></span> |


<span data-ttu-id="c78d6-2620">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2620">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2621">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2621">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2622">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2622">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2623">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2623">HoloLens</span></span>
* <span data-ttu-id="c78d6-2624">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2624">Xbox</span></span>
* <span data-ttu-id="c78d6-2625">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2625">IoT</span></span>

<hr>

### <a name="get-files"></a><span data-ttu-id="c78d6-2626">ファイルを取得する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2626">Get files</span></span>

<span data-ttu-id="c78d6-2627">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2627">**Request**</span></span>

<span data-ttu-id="c78d6-2628">フォルダー内のファイルの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2628">Obtain a list of files in a folder.</span></span>

| <span data-ttu-id="c78d6-2629">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2629">Method</span></span>      | <span data-ttu-id="c78d6-2630">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2630">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2631">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2631">GET</span></span> | <span data-ttu-id="c78d6-2632">/api/filesystem/apps/files</span><span class="sxs-lookup"><span data-stu-id="c78d6-2632">/api/filesystem/apps/files</span></span> |


<span data-ttu-id="c78d6-2633">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2633">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-2634">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2634">URI parameter</span></span> | <span data-ttu-id="c78d6-2635">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2635">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2636">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="c78d6-2636">knownfolderid</span></span> | <span data-ttu-id="c78d6-2637">(**必須**) 必要なファイルの一覧の対象となるトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2637">(**required**) The top-level directory where you want the list of files.</span></span> <span data-ttu-id="c78d6-2638">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2638">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="c78d6-2639">packagefullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-2639">packagefullname</span></span> | <span data-ttu-id="c78d6-2640">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2640">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> |
| <span data-ttu-id="c78d6-2641">path</span><span class="sxs-lookup"><span data-stu-id="c78d6-2641">path</span></span> | <span data-ttu-id="c78d6-2642">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2642">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

<span data-ttu-id="c78d6-2643">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2643">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2644">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2644">None</span></span>

<span data-ttu-id="c78d6-2645">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2645">**Request body**</span></span>

- <span data-ttu-id="c78d6-2646">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2646">None</span></span>

<span data-ttu-id="c78d6-2647">**応答** 利用可能なフォルダーの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2647">**Response** The available folders in the following format.</span></span> 
```json
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
<span data-ttu-id="c78d6-2648">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2648">**Status code**</span></span>

<span data-ttu-id="c78d6-2649">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2649">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2650">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2650">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2651">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2651">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2652">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2652">200</span></span> | <span data-ttu-id="c78d6-2653">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2653">OK</span></span> |
| <span data-ttu-id="c78d6-2654">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2654">4XX</span></span> | <span data-ttu-id="c78d6-2655">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2655">Error codes</span></span> |
| <span data-ttu-id="c78d6-2656">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2656">5XX</span></span> | <span data-ttu-id="c78d6-2657">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2657">Error codes</span></span> |

<span data-ttu-id="c78d6-2658">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2658">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2659">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2659">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2660">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2660">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2661">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2661">HoloLens</span></span>
* <span data-ttu-id="c78d6-2662">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2662">Xbox</span></span>
* <span data-ttu-id="c78d6-2663">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2663">IoT</span></span>

<hr>

### <a name="download-a-file"></a><span data-ttu-id="c78d6-2664">ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="c78d6-2664">Download a file</span></span>

<span data-ttu-id="c78d6-2665">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2665">**Request**</span></span>

<span data-ttu-id="c78d6-2666">既知のフォルダーまたは appLocalData からファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2666">Obtain a file from a known folder or appLocalData.</span></span>

| <span data-ttu-id="c78d6-2667">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2667">Method</span></span>      | <span data-ttu-id="c78d6-2668">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2668">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2669">GET</span><span class="sxs-lookup"><span data-stu-id="c78d6-2669">GET</span></span> | <span data-ttu-id="c78d6-2670">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="c78d6-2670">/api/filesystem/apps/file</span></span> |

<span data-ttu-id="c78d6-2671">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2671">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-2672">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2672">URI parameter</span></span> | <span data-ttu-id="c78d6-2673">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2673">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2674">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="c78d6-2674">knownfolderid</span></span> | <span data-ttu-id="c78d6-2675">(**必須**) ファイルをダウンロードするトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2675">(**required**) The top-level directory where you want to download files.</span></span> <span data-ttu-id="c78d6-2676">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2676">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="c78d6-2677">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="c78d6-2677">filename</span></span> | <span data-ttu-id="c78d6-2678">(**必須**) ダウンロードするファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2678">(**required**) The name of the file being downloaded.</span></span> |
| <span data-ttu-id="c78d6-2679">packagefullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-2679">packagefullname</span></span> | <span data-ttu-id="c78d6-2680">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2680">(**required if *knownfolderid* == LocalAppData**) The package full name you are interested in.</span></span> |
| <span data-ttu-id="c78d6-2681">path</span><span class="sxs-lookup"><span data-stu-id="c78d6-2681">path</span></span> | <span data-ttu-id="c78d6-2682">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2682">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

<span data-ttu-id="c78d6-2683">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2683">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2684">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2684">None</span></span>

<span data-ttu-id="c78d6-2685">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2685">**Request body**</span></span>

- <span data-ttu-id="c78d6-2686">要求するファイル (存在する場合)</span><span class="sxs-lookup"><span data-stu-id="c78d6-2686">The file requested, if present</span></span>

<span data-ttu-id="c78d6-2687">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2687">**Response**</span></span>

<span data-ttu-id="c78d6-2688">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2688">**Status code**</span></span>

<span data-ttu-id="c78d6-2689">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2689">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2690">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2690">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2691">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2691">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2692">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2692">200</span></span> | <span data-ttu-id="c78d6-2693">要求したファイル</span><span class="sxs-lookup"><span data-stu-id="c78d6-2693">The requested file</span></span> |
| <span data-ttu-id="c78d6-2694">404</span><span class="sxs-lookup"><span data-stu-id="c78d6-2694">404</span></span> | <span data-ttu-id="c78d6-2695">ファイルが見つからない</span><span class="sxs-lookup"><span data-stu-id="c78d6-2695">File not found</span></span> |
| <span data-ttu-id="c78d6-2696">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2696">5XX</span></span> | <span data-ttu-id="c78d6-2697">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2697">Error codes</span></span> |

<span data-ttu-id="c78d6-2698">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2698">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2699">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2699">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2700">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2700">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2701">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2701">HoloLens</span></span>
* <span data-ttu-id="c78d6-2702">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2702">Xbox</span></span>
* <span data-ttu-id="c78d6-2703">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2703">IoT</span></span>

<hr>

### <a name="rename-a-file"></a><span data-ttu-id="c78d6-2704">ファイルの名前の変更</span><span class="sxs-lookup"><span data-stu-id="c78d6-2704">Rename a file</span></span>

<span data-ttu-id="c78d6-2705">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2705">**Request**</span></span>

<span data-ttu-id="c78d6-2706">フォルダー内のファイルの名前を変更します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2706">Rename a file in a folder.</span></span>

| <span data-ttu-id="c78d6-2707">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2707">Method</span></span>      | <span data-ttu-id="c78d6-2708">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2708">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2709">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-2709">POST</span></span> | <span data-ttu-id="c78d6-2710">/api/filesystem/apps/rename</span><span class="sxs-lookup"><span data-stu-id="c78d6-2710">/api/filesystem/apps/rename</span></span> |


<span data-ttu-id="c78d6-2711">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2711">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-2712">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2712">URI parameter</span></span> | <span data-ttu-id="c78d6-2713">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2713">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2714">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="c78d6-2714">knownfolderid</span></span> | <span data-ttu-id="c78d6-2715">(**必須**) ファイルが存在するトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2715">(**required**) The top-level directory where the file is located.</span></span> <span data-ttu-id="c78d6-2716">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2716">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="c78d6-2717">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="c78d6-2717">filename</span></span> | <span data-ttu-id="c78d6-2718">(**必須**) 名前を変更するファイルの元の名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2718">(**required**) The original name of the file being renamed.</span></span> |
| <span data-ttu-id="c78d6-2719">newfilename</span><span class="sxs-lookup"><span data-stu-id="c78d6-2719">newfilename</span></span> | <span data-ttu-id="c78d6-2720">(**必須**) ファイルの新しい名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2720">(**required**) The new name of the file.</span></span>|
| <span data-ttu-id="c78d6-2721">packagefullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-2721">packagefullname</span></span> | <span data-ttu-id="c78d6-2722">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2722">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> |
| <span data-ttu-id="c78d6-2723">path</span><span class="sxs-lookup"><span data-stu-id="c78d6-2723">path</span></span> | <span data-ttu-id="c78d6-2724">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2724">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

<span data-ttu-id="c78d6-2725">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2725">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2726">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2726">None</span></span>

<span data-ttu-id="c78d6-2727">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2727">**Request body**</span></span>

- <span data-ttu-id="c78d6-2728">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2728">None</span></span>

<span data-ttu-id="c78d6-2729">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2729">**Response**</span></span>

- <span data-ttu-id="c78d6-2730">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2730">None</span></span>

<span data-ttu-id="c78d6-2731">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2731">**Status code**</span></span>

<span data-ttu-id="c78d6-2732">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2732">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2733">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2733">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2734">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2734">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2735">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2735">200</span></span> | <span data-ttu-id="c78d6-2736">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2736">OK</span></span> |<span data-ttu-id="c78d6-2737">.</span><span class="sxs-lookup"><span data-stu-id="c78d6-2737">.</span></span> <span data-ttu-id="c78d6-2738">ファイルの名前が変更されました</span><span class="sxs-lookup"><span data-stu-id="c78d6-2738">The file is renamed</span></span>
| <span data-ttu-id="c78d6-2739">404</span><span class="sxs-lookup"><span data-stu-id="c78d6-2739">404</span></span> | <span data-ttu-id="c78d6-2740">ファイルが見つからない</span><span class="sxs-lookup"><span data-stu-id="c78d6-2740">File not found</span></span> |
| <span data-ttu-id="c78d6-2741">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2741">5XX</span></span> | <span data-ttu-id="c78d6-2742">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2742">Error codes</span></span> |

<span data-ttu-id="c78d6-2743">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2743">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2744">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2744">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2745">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2745">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2746">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2746">HoloLens</span></span>
* <span data-ttu-id="c78d6-2747">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2747">Xbox</span></span>
* <span data-ttu-id="c78d6-2748">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2748">IoT</span></span>

<hr>

### <a name="delete-a-file"></a><span data-ttu-id="c78d6-2749">ファイルを削除する</span><span class="sxs-lookup"><span data-stu-id="c78d6-2749">Delete a file</span></span>

<span data-ttu-id="c78d6-2750">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2750">**Request**</span></span>

<span data-ttu-id="c78d6-2751">フォルダー内のファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2751">Delete a file in a folder.</span></span>

| <span data-ttu-id="c78d6-2752">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2752">Method</span></span>      | <span data-ttu-id="c78d6-2753">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2753">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2754">Del</span><span class="sxs-lookup"><span data-stu-id="c78d6-2754">DELETE</span></span> | <span data-ttu-id="c78d6-2755">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="c78d6-2755">/api/filesystem/apps/file</span></span> |

<span data-ttu-id="c78d6-2756">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2756">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-2757">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2757">URI parameter</span></span> | <span data-ttu-id="c78d6-2758">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2758">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2759">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="c78d6-2759">knownfolderid</span></span> | <span data-ttu-id="c78d6-2760">(**必須**) ファイルを削除するトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2760">(**required**) The top-level directory where you want to delete files.</span></span> <span data-ttu-id="c78d6-2761">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2761">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="c78d6-2762">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="c78d6-2762">filename</span></span> | <span data-ttu-id="c78d6-2763">(**必須**) 削除するファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2763">(**required**) The name of the file being deleted.</span></span> |
| <span data-ttu-id="c78d6-2764">packagefullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-2764">packagefullname</span></span> | <span data-ttu-id="c78d6-2765">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2765">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> |
| <span data-ttu-id="c78d6-2766">path</span><span class="sxs-lookup"><span data-stu-id="c78d6-2766">path</span></span> | <span data-ttu-id="c78d6-2767">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2767">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

<span data-ttu-id="c78d6-2768">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2768">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2769">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2769">None</span></span>

<span data-ttu-id="c78d6-2770">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2770">**Request body**</span></span>

- <span data-ttu-id="c78d6-2771">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2771">None</span></span>

<span data-ttu-id="c78d6-2772">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2772">**Response**</span></span>

- <span data-ttu-id="c78d6-2773">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2773">None</span></span> 

<span data-ttu-id="c78d6-2774">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2774">**Status code**</span></span>

<span data-ttu-id="c78d6-2775">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2775">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2776">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2776">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2777">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2777">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2778">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2778">200</span></span> | <span data-ttu-id="c78d6-2779">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2779">OK</span></span> |<span data-ttu-id="c78d6-2780">.</span><span class="sxs-lookup"><span data-stu-id="c78d6-2780">.</span></span> <span data-ttu-id="c78d6-2781">ファイルが削除されます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2781">The file is deleted</span></span> |
| <span data-ttu-id="c78d6-2782">404</span><span class="sxs-lookup"><span data-stu-id="c78d6-2782">404</span></span> | <span data-ttu-id="c78d6-2783">ファイルが見つからない</span><span class="sxs-lookup"><span data-stu-id="c78d6-2783">File not found</span></span> |
| <span data-ttu-id="c78d6-2784">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2784">5XX</span></span> | <span data-ttu-id="c78d6-2785">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2785">Error codes</span></span> |

<span data-ttu-id="c78d6-2786">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2786">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2787">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2787">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2788">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2788">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2789">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2789">HoloLens</span></span>
* <span data-ttu-id="c78d6-2790">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2790">Xbox</span></span>
* <span data-ttu-id="c78d6-2791">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2791">IoT</span></span>

<hr>

### <a name="upload-a-file"></a><span data-ttu-id="c78d6-2792">ファイルをアップロードする</span><span class="sxs-lookup"><span data-stu-id="c78d6-2792">Upload a file</span></span>

<span data-ttu-id="c78d6-2793">**要求**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2793">**Request**</span></span>

<span data-ttu-id="c78d6-2794">フォルダーにファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2794">Upload a file to a folder.</span></span>  <span data-ttu-id="c78d6-2795">この場合、同じ名前を持つ既存のファイルは上書きされますが、新しいフォルダーは作成されません。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2795">This will overwrite an existing file with the same name, but will not create new folders.</span></span> 

| <span data-ttu-id="c78d6-2796">メソッド</span><span class="sxs-lookup"><span data-stu-id="c78d6-2796">Method</span></span>      | <span data-ttu-id="c78d6-2797">要求 URI</span><span class="sxs-lookup"><span data-stu-id="c78d6-2797">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2798">POST</span><span class="sxs-lookup"><span data-stu-id="c78d6-2798">POST</span></span> | <span data-ttu-id="c78d6-2799">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="c78d6-2799">/api/filesystem/apps/file</span></span> |

<span data-ttu-id="c78d6-2800">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2800">**URI parameters**</span></span>

| <span data-ttu-id="c78d6-2801">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c78d6-2801">URI parameter</span></span> | <span data-ttu-id="c78d6-2802">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2802">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2803">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="c78d6-2803">knownfolderid</span></span> | <span data-ttu-id="c78d6-2804">(**必須**) ファイルをアップロードするトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2804">(**required**) The top-level directory where you want to upload files.</span></span> <span data-ttu-id="c78d6-2805">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2805">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="c78d6-2806">packagefullname</span><span class="sxs-lookup"><span data-stu-id="c78d6-2806">packagefullname</span></span> | <span data-ttu-id="c78d6-2807">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2807">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> |
| <span data-ttu-id="c78d6-2808">path</span><span class="sxs-lookup"><span data-stu-id="c78d6-2808">path</span></span> | <span data-ttu-id="c78d6-2809">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2809">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

<span data-ttu-id="c78d6-2810">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2810">**Request headers**</span></span>

- <span data-ttu-id="c78d6-2811">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2811">None</span></span>

<span data-ttu-id="c78d6-2812">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2812">**Request body**</span></span>

- <span data-ttu-id="c78d6-2813">なし</span><span class="sxs-lookup"><span data-stu-id="c78d6-2813">None</span></span>

<span data-ttu-id="c78d6-2814">**応答**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2814">**Response**</span></span>

<span data-ttu-id="c78d6-2815">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2815">**Status code**</span></span>

<span data-ttu-id="c78d6-2816">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2816">This API has the following expected status codes.</span></span>

| <span data-ttu-id="c78d6-2817">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2817">HTTP status code</span></span>      | <span data-ttu-id="c78d6-2818">説明</span><span class="sxs-lookup"><span data-stu-id="c78d6-2818">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="c78d6-2819">200</span><span class="sxs-lookup"><span data-stu-id="c78d6-2819">200</span></span> | <span data-ttu-id="c78d6-2820">OK</span><span class="sxs-lookup"><span data-stu-id="c78d6-2820">OK</span></span> |<span data-ttu-id="c78d6-2821">.</span><span class="sxs-lookup"><span data-stu-id="c78d6-2821">.</span></span> <span data-ttu-id="c78d6-2822">ファイルがアップロードされます。</span><span class="sxs-lookup"><span data-stu-id="c78d6-2822">The file is uploaded</span></span> |
| <span data-ttu-id="c78d6-2823">4XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2823">4XX</span></span> | <span data-ttu-id="c78d6-2824">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2824">Error codes</span></span> |
| <span data-ttu-id="c78d6-2825">5XX</span><span class="sxs-lookup"><span data-stu-id="c78d6-2825">5XX</span></span> | <span data-ttu-id="c78d6-2826">エラー コード</span><span class="sxs-lookup"><span data-stu-id="c78d6-2826">Error codes</span></span> |

<span data-ttu-id="c78d6-2827">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="c78d6-2827">**Available device families**</span></span>

* <span data-ttu-id="c78d6-2828">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="c78d6-2828">Windows Mobile</span></span>
* <span data-ttu-id="c78d6-2829">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="c78d6-2829">Windows Desktop</span></span>
* <span data-ttu-id="c78d6-2830">HoloLens</span><span class="sxs-lookup"><span data-stu-id="c78d6-2830">HoloLens</span></span>
* <span data-ttu-id="c78d6-2831">Xbox</span><span class="sxs-lookup"><span data-stu-id="c78d6-2831">Xbox</span></span>
* <span data-ttu-id="c78d6-2832">IoT</span><span class="sxs-lookup"><span data-stu-id="c78d6-2832">IoT</span></span>
