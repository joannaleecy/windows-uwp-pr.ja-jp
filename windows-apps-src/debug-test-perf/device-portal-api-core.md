---
ms.assetid: bfabd3d5-dd56-4917-9572-f3ba0de4f8c0
title: デバイス ポータル コア API リファレンス
description: Windows Device Portal コア REST API について説明します。これによって、データにアクセスし、プログラムを使ってデバイスを制御することが可能になります。
ms.date: 03/22/2017
ms.topic: article
keywords: windows 10、uwp、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 5f541a27a96b88b37d3f32b98246ba0ccbe2c8cf
ms.sourcegitcommit: 681c1e3836d2a51cd3b31d824ece344281932bcd
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59067857"
---
# <a name="device-portal-core-api-reference"></a><span data-ttu-id="01424-104">デバイス ポータル コア API リファレンス</span><span class="sxs-lookup"><span data-stu-id="01424-104">Device Portal core API reference</span></span>

<span data-ttu-id="01424-105">デバイス ポータルのすべての機能は、REST API の上に構築されています。開発者は REST API を直接呼び出して、プログラムからリソースにアクセスし、デバイスを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="01424-105">All Device Portal functionality is built on REST APIs that developers can call directly to access resources and control their devices programmatically.</span></span>

## <a name="app-deployment"></a><span data-ttu-id="01424-106">アプリの展開</span><span class="sxs-lookup"><span data-stu-id="01424-106">App deployment</span></span>

### <a name="install-an-app"></a><span data-ttu-id="01424-107">アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="01424-107">Install an app</span></span>

**<span data-ttu-id="01424-108">要求</span><span class="sxs-lookup"><span data-stu-id="01424-108">Request</span></span>**

<span data-ttu-id="01424-109">次の要求形式を使用して、アプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="01424-109">You can install an app by using the following request format.</span></span>

| <span data-ttu-id="01424-110">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-110">Method</span></span>      | <span data-ttu-id="01424-111">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-111">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-112">POST</span><span class="sxs-lookup"><span data-stu-id="01424-112">POST</span></span> | <span data-ttu-id="01424-113">/api/app/packagemanager/package</span><span class="sxs-lookup"><span data-stu-id="01424-113">/api/app/packagemanager/package</span></span> |

**<span data-ttu-id="01424-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-114">URI parameters</span></span>**

<span data-ttu-id="01424-115">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-115">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-116">URI parameter</span></span> | <span data-ttu-id="01424-117">説明</span><span class="sxs-lookup"><span data-stu-id="01424-117">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-118">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="01424-118">package</span></span>   | <span data-ttu-id="01424-119">(**必須**) インストールするパッケージのファイル名。</span><span class="sxs-lookup"><span data-stu-id="01424-119">(**required**) The file name of the package to be installed.</span></span> |

**<span data-ttu-id="01424-120">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-120">Request headers</span></span>**

- <span data-ttu-id="01424-121">なし</span><span class="sxs-lookup"><span data-stu-id="01424-121">None</span></span>

**<span data-ttu-id="01424-122">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-122">Request body</span></span>**

- <span data-ttu-id="01424-123">.appx または .appxbundle ファイル、およびアプリが必要とする依存関係。</span><span class="sxs-lookup"><span data-stu-id="01424-123">The .appx or .appxbundle file, as well as any dependencies the app requires.</span></span> 
- <span data-ttu-id="01424-124">デバイスが IoT または Windows デスクトップの場合、アプリの署名に使う証明書。</span><span class="sxs-lookup"><span data-stu-id="01424-124">The certificate used to sign the app, if the device is IoT or Windows Desktop.</span></span> <span data-ttu-id="01424-125">その他のプラットフォームでは、証明書は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="01424-125">Other platforms do not require the certificate.</span></span> 

**<span data-ttu-id="01424-126">応答</span><span class="sxs-lookup"><span data-stu-id="01424-126">Response</span></span>**

**<span data-ttu-id="01424-127">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-127">Status code</span></span>**

<span data-ttu-id="01424-128">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-128">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-129">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-129">HTTP status code</span></span>      | <span data-ttu-id="01424-130">説明</span><span class="sxs-lookup"><span data-stu-id="01424-130">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="01424-131">200</span><span class="sxs-lookup"><span data-stu-id="01424-131">200</span></span> | <span data-ttu-id="01424-132">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="01424-132">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="01424-133">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-133">4XX</span></span> | <span data-ttu-id="01424-134">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-134">Error codes</span></span> |
| <span data-ttu-id="01424-135">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-135">5XX</span></span> | <span data-ttu-id="01424-136">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-136">Error codes</span></span> |

**<span data-ttu-id="01424-137">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-137">Available device families</span></span>**

* <span data-ttu-id="01424-138">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-138">Windows Mobile</span></span>
* <span data-ttu-id="01424-139">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-139">Windows Desktop</span></span>
* <span data-ttu-id="01424-140">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-140">Xbox</span></span>
* <span data-ttu-id="01424-141">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-141">HoloLens</span></span>
* <span data-ttu-id="01424-142">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-142">IoT</span></span>

<hr>
### <span data-ttu-id="01424-143">関連セットをインストールする</span><span class="sxs-lookup"><span data-stu-id="01424-143">Install a related set</span></span>

**<span data-ttu-id="01424-144">要求</span><span class="sxs-lookup"><span data-stu-id="01424-144">Request</span></span>**

<span data-ttu-id="01424-145">次の要求形式を使用して、[関連セット](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/)をインストールできます。</span><span class="sxs-lookup"><span data-stu-id="01424-145">You can install a [related set](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/) by using the following request format.</span></span>

| <span data-ttu-id="01424-146">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-146">Method</span></span>      | <span data-ttu-id="01424-147">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-147">Request URI</span></span> |
| :------     | :------ |
| <span data-ttu-id="01424-148">POST</span><span class="sxs-lookup"><span data-stu-id="01424-148">POST</span></span> | <span data-ttu-id="01424-149">/api/app/packagemanager/package</span><span class="sxs-lookup"><span data-stu-id="01424-149">/api/app/packagemanager/package</span></span> |

**<span data-ttu-id="01424-150">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-150">URI parameters</span></span>**

<span data-ttu-id="01424-151">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-151">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-152">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-152">URI parameter</span></span> | <span data-ttu-id="01424-153">説明</span><span class="sxs-lookup"><span data-stu-id="01424-153">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-154">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="01424-154">package</span></span>   | <span data-ttu-id="01424-155">(**必須**) インストールするパッケージのファイル名。</span><span class="sxs-lookup"><span data-stu-id="01424-155">(**required**) The file names of the packages to be installed.</span></span> |

**<span data-ttu-id="01424-156">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-156">Request headers</span></span>**

- <span data-ttu-id="01424-157">なし</span><span class="sxs-lookup"><span data-stu-id="01424-157">None</span></span>

**<span data-ttu-id="01424-158">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-158">Request body</span></span>** 
- <span data-ttu-id="01424-159">オプション パッケージをパラメーターとして指定するときは、"foo.appx.opt"、"bar.appxbundle.opt" などのようにパッケージのファイル名に ".opt" を追加します。</span><span class="sxs-lookup"><span data-stu-id="01424-159">Add ".opt" to the optional package file names when specifying them as a parameter, like so: "foo.appx.opt" or "bar.appxbundle.opt".</span></span> 
- <span data-ttu-id="01424-160">.appx または .appxbundle ファイル、およびアプリが必要とする依存関係。</span><span class="sxs-lookup"><span data-stu-id="01424-160">The .appx or .appxbundle file, as well as any dependencies the app requires.</span></span> 
- <span data-ttu-id="01424-161">デバイスが IoT または Windows デスクトップの場合、アプリの署名に使う証明書。</span><span class="sxs-lookup"><span data-stu-id="01424-161">The certificate used to sign the app, if the device is IoT or Windows Desktop.</span></span> <span data-ttu-id="01424-162">その他のプラットフォームでは、証明書は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="01424-162">Other platforms do not require the certificate.</span></span> 

**<span data-ttu-id="01424-163">応答</span><span class="sxs-lookup"><span data-stu-id="01424-163">Response</span></span>**

**<span data-ttu-id="01424-164">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-164">Status code</span></span>**

<span data-ttu-id="01424-165">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-165">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-166">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-166">HTTP status code</span></span>      | <span data-ttu-id="01424-167">説明</span><span class="sxs-lookup"><span data-stu-id="01424-167">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="01424-168">200</span><span class="sxs-lookup"><span data-stu-id="01424-168">200</span></span> | <span data-ttu-id="01424-169">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="01424-169">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="01424-170">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-170">4XX</span></span> | <span data-ttu-id="01424-171">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-171">Error codes</span></span> |
| <span data-ttu-id="01424-172">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-172">5XX</span></span> | <span data-ttu-id="01424-173">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-173">Error codes</span></span> |

**<span data-ttu-id="01424-174">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-174">Available device families</span></span>**

* <span data-ttu-id="01424-175">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-175">Windows Mobile</span></span>
* <span data-ttu-id="01424-176">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-176">Windows Desktop</span></span>
* <span data-ttu-id="01424-177">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-177">Xbox</span></span>
* <span data-ttu-id="01424-178">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-178">HoloLens</span></span>
* <span data-ttu-id="01424-179">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-179">IoT</span></span>

<hr>
### <span data-ttu-id="01424-180">アプリをルース フォルダーに登録する</span><span class="sxs-lookup"><span data-stu-id="01424-180">Register an app in a loose folder</span></span>

**<span data-ttu-id="01424-181">要求</span><span class="sxs-lookup"><span data-stu-id="01424-181">Request</span></span>**

<span data-ttu-id="01424-182">次の要求形式を使用して、アプリをルース フォルダーに登録できます。</span><span class="sxs-lookup"><span data-stu-id="01424-182">You can register an app in a loose folder by using the following request format.</span></span>

| <span data-ttu-id="01424-183">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-183">Method</span></span>      | <span data-ttu-id="01424-184">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-184">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-185">POST</span><span class="sxs-lookup"><span data-stu-id="01424-185">POST</span></span> | <span data-ttu-id="01424-186">/api/app/packagemanager/networkapp</span><span class="sxs-lookup"><span data-stu-id="01424-186">/api/app/packagemanager/networkapp</span></span> |

**<span data-ttu-id="01424-187">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-187">URI parameters</span></span>**

- <span data-ttu-id="01424-188">なし</span><span class="sxs-lookup"><span data-stu-id="01424-188">None</span></span>

**<span data-ttu-id="01424-189">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-189">Request headers</span></span>**

- <span data-ttu-id="01424-190">なし</span><span class="sxs-lookup"><span data-stu-id="01424-190">None</span></span>

**<span data-ttu-id="01424-191">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-191">Request body</span></span>**

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

**<span data-ttu-id="01424-192">応答</span><span class="sxs-lookup"><span data-stu-id="01424-192">Response</span></span>**

**<span data-ttu-id="01424-193">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-193">Status code</span></span>**

<span data-ttu-id="01424-194">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-194">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-195">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-195">HTTP status code</span></span>      | <span data-ttu-id="01424-196">説明</span><span class="sxs-lookup"><span data-stu-id="01424-196">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="01424-197">200</span><span class="sxs-lookup"><span data-stu-id="01424-197">200</span></span> | <span data-ttu-id="01424-198">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="01424-198">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="01424-199">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-199">4XX</span></span> | <span data-ttu-id="01424-200">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-200">Error codes</span></span> |
| <span data-ttu-id="01424-201">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-201">5XX</span></span> | <span data-ttu-id="01424-202">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-202">Error codes</span></span> |

**<span data-ttu-id="01424-203">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-203">Available device families</span></span>**

* <span data-ttu-id="01424-204">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-204">Windows Desktop</span></span>
* <span data-ttu-id="01424-205">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-205">Xbox</span></span>
* <span data-ttu-id="01424-206">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-206">HoloLens</span></span>
* <span data-ttu-id="01424-207">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-207">IoT</span></span>

<hr>
### <span data-ttu-id="01424-208">関連セットをルース ファイル フォルダーに登録する</span><span class="sxs-lookup"><span data-stu-id="01424-208">Register a related set in loose file folders</span></span>

**<span data-ttu-id="01424-209">要求</span><span class="sxs-lookup"><span data-stu-id="01424-209">Request</span></span>**

<span data-ttu-id="01424-210">次の要求形式を使用して、[関連セット](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/)をルース フォルダーに登録できます。</span><span class="sxs-lookup"><span data-stu-id="01424-210">You can register a [related set](https://blogs.msdn.microsoft.com/appinstaller/2017/05/12/tooling-to-create-a-related-set/) in loose folders by using the following request format.</span></span>

| <span data-ttu-id="01424-211">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-211">Method</span></span>      | <span data-ttu-id="01424-212">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-212">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-213">POST</span><span class="sxs-lookup"><span data-stu-id="01424-213">POST</span></span> | <span data-ttu-id="01424-214">/api/app/packagemanager/networkapp</span><span class="sxs-lookup"><span data-stu-id="01424-214">/api/app/packagemanager/networkapp</span></span> |

**<span data-ttu-id="01424-215">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-215">URI parameters</span></span>**

- <span data-ttu-id="01424-216">なし</span><span class="sxs-lookup"><span data-stu-id="01424-216">None</span></span>

**<span data-ttu-id="01424-217">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-217">Request headers</span></span>**

- <span data-ttu-id="01424-218">なし</span><span class="sxs-lookup"><span data-stu-id="01424-218">None</span></span>

**<span data-ttu-id="01424-219">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-219">Request body</span></span>**

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

**<span data-ttu-id="01424-220">応答</span><span class="sxs-lookup"><span data-stu-id="01424-220">Response</span></span>**

**<span data-ttu-id="01424-221">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-221">Status code</span></span>**

<span data-ttu-id="01424-222">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-222">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-223">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-223">HTTP status code</span></span>      | <span data-ttu-id="01424-224">説明</span><span class="sxs-lookup"><span data-stu-id="01424-224">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="01424-225">200</span><span class="sxs-lookup"><span data-stu-id="01424-225">200</span></span> | <span data-ttu-id="01424-226">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="01424-226">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="01424-227">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-227">4XX</span></span> | <span data-ttu-id="01424-228">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-228">Error codes</span></span> |
| <span data-ttu-id="01424-229">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-229">5XX</span></span> | <span data-ttu-id="01424-230">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-230">Error codes</span></span> |

**<span data-ttu-id="01424-231">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-231">Available device families</span></span>**

* <span data-ttu-id="01424-232">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-232">Windows Desktop</span></span>
* <span data-ttu-id="01424-233">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-233">Xbox</span></span>
* <span data-ttu-id="01424-234">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-234">HoloLens</span></span>
* <span data-ttu-id="01424-235">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-235">IoT</span></span>

<hr>
### <span data-ttu-id="01424-236">アプリのインストール状態を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-236">Get app installation status</span></span>

**<span data-ttu-id="01424-237">要求</span><span class="sxs-lookup"><span data-stu-id="01424-237">Request</span></span>**

<span data-ttu-id="01424-238">次の要求形式を使用して、現在進行中のアプリのインストールの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-238">You can get the status of an app installation that is currently in progress by using the following request format.</span></span>
 
| <span data-ttu-id="01424-239">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-239">Method</span></span>      | <span data-ttu-id="01424-240">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-240">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-241">GET</span><span class="sxs-lookup"><span data-stu-id="01424-241">GET</span></span> | <span data-ttu-id="01424-242">/api/app/packagemanager/state</span><span class="sxs-lookup"><span data-stu-id="01424-242">/api/app/packagemanager/state</span></span> |

**<span data-ttu-id="01424-243">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-243">URI parameters</span></span>**

- <span data-ttu-id="01424-244">なし</span><span class="sxs-lookup"><span data-stu-id="01424-244">None</span></span>

**<span data-ttu-id="01424-245">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-245">Request headers</span></span>**

- <span data-ttu-id="01424-246">なし</span><span class="sxs-lookup"><span data-stu-id="01424-246">None</span></span>

**<span data-ttu-id="01424-247">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-247">Request body</span></span>**

- <span data-ttu-id="01424-248">なし</span><span class="sxs-lookup"><span data-stu-id="01424-248">None</span></span>

**<span data-ttu-id="01424-249">応答</span><span class="sxs-lookup"><span data-stu-id="01424-249">Response</span></span>**

**<span data-ttu-id="01424-250">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-250">Status code</span></span>**

<span data-ttu-id="01424-251">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-251">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-252">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-252">HTTP status code</span></span>      | <span data-ttu-id="01424-253">説明</span><span class="sxs-lookup"><span data-stu-id="01424-253">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="01424-254">200</span><span class="sxs-lookup"><span data-stu-id="01424-254">200</span></span> | <span data-ttu-id="01424-255">最後の展開の結果</span><span class="sxs-lookup"><span data-stu-id="01424-255">The result of the last deployment</span></span> |
| <span data-ttu-id="01424-256">204</span><span class="sxs-lookup"><span data-stu-id="01424-256">204</span></span> | <span data-ttu-id="01424-257">インストールは実行中です</span><span class="sxs-lookup"><span data-stu-id="01424-257">The installation is running</span></span> |
| <span data-ttu-id="01424-258">404</span><span class="sxs-lookup"><span data-stu-id="01424-258">404</span></span> | <span data-ttu-id="01424-259">インストール操作は見つかりませんでした</span><span class="sxs-lookup"><span data-stu-id="01424-259">No installation action was found</span></span> |

**<span data-ttu-id="01424-260">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-260">Available device families</span></span>**

* <span data-ttu-id="01424-261">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-261">Windows Mobile</span></span>
* <span data-ttu-id="01424-262">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-262">Windows Desktop</span></span>
* <span data-ttu-id="01424-263">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-263">Xbox</span></span>
* <span data-ttu-id="01424-264">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-264">HoloLens</span></span>
* <span data-ttu-id="01424-265">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-265">IoT</span></span>

<hr>
### <span data-ttu-id="01424-266">アプリをアンインストールする</span><span class="sxs-lookup"><span data-stu-id="01424-266">Uninstall an app</span></span>

**<span data-ttu-id="01424-267">要求</span><span class="sxs-lookup"><span data-stu-id="01424-267">Request</span></span>**

<span data-ttu-id="01424-268">次の要求形式を使用して、アプリをアンインストールできます。</span><span class="sxs-lookup"><span data-stu-id="01424-268">You can uninstall an app by using the following request format.</span></span>
 
| <span data-ttu-id="01424-269">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-269">Method</span></span>      | <span data-ttu-id="01424-270">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-270">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-271">Del</span><span class="sxs-lookup"><span data-stu-id="01424-271">DELETE</span></span> | <span data-ttu-id="01424-272">/api/app/packagemanager/package</span><span class="sxs-lookup"><span data-stu-id="01424-272">/api/app/packagemanager/package</span></span> |

**<span data-ttu-id="01424-273">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-273">URI parameters</span></span>**

| <span data-ttu-id="01424-274">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-274">URI parameter</span></span> | <span data-ttu-id="01424-275">説明</span><span class="sxs-lookup"><span data-stu-id="01424-275">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-276">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="01424-276">package</span></span>   | <span data-ttu-id="01424-277">(**必須**) ターゲット アプリの PackageFullName (GET /api/app/packagemanager/packages から)</span><span class="sxs-lookup"><span data-stu-id="01424-277">(**required**) The PackageFullName (from GET /api/app/packagemanager/packages) of the target app</span></span> |

**<span data-ttu-id="01424-278">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-278">Request headers</span></span>**

- <span data-ttu-id="01424-279">なし</span><span class="sxs-lookup"><span data-stu-id="01424-279">None</span></span>

**<span data-ttu-id="01424-280">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-280">Request body</span></span>**

- <span data-ttu-id="01424-281">なし</span><span class="sxs-lookup"><span data-stu-id="01424-281">None</span></span>

**<span data-ttu-id="01424-282">応答</span><span class="sxs-lookup"><span data-stu-id="01424-282">Response</span></span>**

**<span data-ttu-id="01424-283">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-283">Status code</span></span>**

<span data-ttu-id="01424-284">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-284">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-285">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-285">HTTP status code</span></span>      | <span data-ttu-id="01424-286">説明</span><span class="sxs-lookup"><span data-stu-id="01424-286">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-287">200</span><span class="sxs-lookup"><span data-stu-id="01424-287">200</span></span> | <span data-ttu-id="01424-288">OK</span><span class="sxs-lookup"><span data-stu-id="01424-288">OK</span></span> | 
| <span data-ttu-id="01424-289">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-289">4XX</span></span> | <span data-ttu-id="01424-290">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-290">Error codes</span></span> |
| <span data-ttu-id="01424-291">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-291">5XX</span></span> | <span data-ttu-id="01424-292">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-292">Error codes</span></span> |

**<span data-ttu-id="01424-293">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-293">Available device families</span></span>**

* <span data-ttu-id="01424-294">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-294">Windows Mobile</span></span>
* <span data-ttu-id="01424-295">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-295">Windows Desktop</span></span>
* <span data-ttu-id="01424-296">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-296">Xbox</span></span>
* <span data-ttu-id="01424-297">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-297">HoloLens</span></span>
* <span data-ttu-id="01424-298">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-298">IoT</span></span>

<hr>
### <span data-ttu-id="01424-299">インストールされたアプリを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-299">Get installed apps</span></span>

**<span data-ttu-id="01424-300">要求</span><span class="sxs-lookup"><span data-stu-id="01424-300">Request</span></span>**

<span data-ttu-id="01424-301">次の要求形式を使用して、システムにインストールされているアプリの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-301">You can get a list of apps installed on the system by using the following request format.</span></span>
 
| <span data-ttu-id="01424-302">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-302">Method</span></span>      | <span data-ttu-id="01424-303">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-303">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-304">GET</span><span class="sxs-lookup"><span data-stu-id="01424-304">GET</span></span> | <span data-ttu-id="01424-305">/api/app/packagemanager/packages</span><span class="sxs-lookup"><span data-stu-id="01424-305">/api/app/packagemanager/packages</span></span> |


**<span data-ttu-id="01424-306">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-306">URI parameters</span></span>**

- <span data-ttu-id="01424-307">なし</span><span class="sxs-lookup"><span data-stu-id="01424-307">None</span></span>

**<span data-ttu-id="01424-308">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-308">Request headers</span></span>**

- <span data-ttu-id="01424-309">なし</span><span class="sxs-lookup"><span data-stu-id="01424-309">None</span></span>

**<span data-ttu-id="01424-310">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-310">Request body</span></span>**

- <span data-ttu-id="01424-311">なし</span><span class="sxs-lookup"><span data-stu-id="01424-311">None</span></span>

**<span data-ttu-id="01424-312">応答</span><span class="sxs-lookup"><span data-stu-id="01424-312">Response</span></span>**

<span data-ttu-id="01424-313">応答には、インストールされているパッケージの一覧と関連する詳細情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-313">The response includes a list of installed packages with associated details.</span></span> <span data-ttu-id="01424-314">この応答のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-314">The template for this response is as follows.</span></span>
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
**<span data-ttu-id="01424-315">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-315">Status code</span></span>**

<span data-ttu-id="01424-316">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-316">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-317">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-317">HTTP status code</span></span>      | <span data-ttu-id="01424-318">説明</span><span class="sxs-lookup"><span data-stu-id="01424-318">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-319">200</span><span class="sxs-lookup"><span data-stu-id="01424-319">200</span></span> | <span data-ttu-id="01424-320">OK</span><span class="sxs-lookup"><span data-stu-id="01424-320">OK</span></span> | 
| <span data-ttu-id="01424-321">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-321">4XX</span></span> | <span data-ttu-id="01424-322">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-322">Error codes</span></span> |
| <span data-ttu-id="01424-323">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-323">5XX</span></span> | <span data-ttu-id="01424-324">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-324">Error codes</span></span> |

**<span data-ttu-id="01424-325">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-325">Available device families</span></span>**

* <span data-ttu-id="01424-326">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-326">Windows Mobile</span></span>
* <span data-ttu-id="01424-327">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-327">Windows Desktop</span></span>
* <span data-ttu-id="01424-328">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-328">Xbox</span></span>
* <span data-ttu-id="01424-329">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-329">HoloLens</span></span>
* <span data-ttu-id="01424-330">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-330">IoT</span></span>

<hr>
## <span data-ttu-id="01424-331">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="01424-331">Bluetooth</span></span>
<hr>

### <a name="get-the-bluetooth-radios-on-the-machine"></a><span data-ttu-id="01424-332">コンピューターの Bluetooth 無線を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-332">Get the Bluetooth radios on the machine</span></span>

**<span data-ttu-id="01424-333">要求</span><span class="sxs-lookup"><span data-stu-id="01424-333">Request</span></span>**

<span data-ttu-id="01424-334">次の要求形式を使用して、コンピューターにインストールされている Bluetooth 無線の一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-334">You can get a list of the Bluetooth radios that are installed on the machine by using the following request format.</span></span> <span data-ttu-id="01424-335">これは、同じ JSON データを同様に、WebSocket 接続にアップグレードできます。</span><span class="sxs-lookup"><span data-stu-id="01424-335">This can be upgraded to a WebSocket connection as well, with the same JSON data.</span></span>
 
| <span data-ttu-id="01424-336">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-336">Method</span></span>        | <span data-ttu-id="01424-337">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-337">Request URI</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-338">GET</span><span class="sxs-lookup"><span data-stu-id="01424-338">GET</span></span>           | <span data-ttu-id="01424-339">/api/bt/getradios</span><span class="sxs-lookup"><span data-stu-id="01424-339">/api/bt/getradios</span></span> |
| <span data-ttu-id="01424-340">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="01424-340">GET/WebSocket</span></span> | <span data-ttu-id="01424-341">/api/bt/getradios</span><span class="sxs-lookup"><span data-stu-id="01424-341">/api/bt/getradios</span></span> |


**<span data-ttu-id="01424-342">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-342">URI parameters</span></span>**

- <span data-ttu-id="01424-343">なし</span><span class="sxs-lookup"><span data-stu-id="01424-343">None</span></span>

**<span data-ttu-id="01424-344">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-344">Request headers</span></span>**

- <span data-ttu-id="01424-345">なし</span><span class="sxs-lookup"><span data-stu-id="01424-345">None</span></span>

**<span data-ttu-id="01424-346">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-346">Request body</span></span>**

- <span data-ttu-id="01424-347">なし</span><span class="sxs-lookup"><span data-stu-id="01424-347">None</span></span>

**<span data-ttu-id="01424-348">応答</span><span class="sxs-lookup"><span data-stu-id="01424-348">Response</span></span>**

<span data-ttu-id="01424-349">応答には、デバイスにアタッチされている Bluetooth 無線の JSON 配列が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-349">The response includes a JSON array of Bluetooth radios attached to the device.</span></span>
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
**<span data-ttu-id="01424-350">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-350">Status code</span></span>**

<span data-ttu-id="01424-351">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-351">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-352">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-352">HTTP status code</span></span> | <span data-ttu-id="01424-353">説明</span><span class="sxs-lookup"><span data-stu-id="01424-353">Description</span></span> |
| :------             | :------ |
| <span data-ttu-id="01424-354">200</span><span class="sxs-lookup"><span data-stu-id="01424-354">200</span></span>              | <span data-ttu-id="01424-355">OK</span><span class="sxs-lookup"><span data-stu-id="01424-355">OK</span></span> |
| <span data-ttu-id="01424-356">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-356">4XX</span></span>              | <span data-ttu-id="01424-357">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-357">Error codes</span></span> |
| <span data-ttu-id="01424-358">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-358">5XX</span></span>              | <span data-ttu-id="01424-359">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-359">Error codes</span></span> |

**<span data-ttu-id="01424-360">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-360">Available device families</span></span>**

* <span data-ttu-id="01424-361">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-361">Windows Desktop</span></span>
* <span data-ttu-id="01424-362">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-362">HoloLens</span></span>
* <span data-ttu-id="01424-363">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-363">IoT</span></span>

<hr>
### <span data-ttu-id="01424-364">Bluetooth 無線をオンまたはオフにします。</span><span class="sxs-lookup"><span data-stu-id="01424-364">Turn the Bluetooth radio on or off</span></span>

**<span data-ttu-id="01424-365">要求</span><span class="sxs-lookup"><span data-stu-id="01424-365">Request</span></span>**

<span data-ttu-id="01424-366">特定の Bluetooth 無線をオンまたはオフに設定します。</span><span class="sxs-lookup"><span data-stu-id="01424-366">Sets a specific Bluetooth radio to On or Off.</span></span>
 
| <span data-ttu-id="01424-367">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-367">Method</span></span> | <span data-ttu-id="01424-368">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-368">Request URI</span></span> |
| :------   | :------ |
| <span data-ttu-id="01424-369">POST</span><span class="sxs-lookup"><span data-stu-id="01424-369">POST</span></span>   | <span data-ttu-id="01424-370">/api/bt/setradio</span><span class="sxs-lookup"><span data-stu-id="01424-370">/api/bt/setradio</span></span> |

**<span data-ttu-id="01424-371">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-371">URI parameters</span></span>**

<span data-ttu-id="01424-372">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-372">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-373">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-373">URI parameter</span></span> | <span data-ttu-id="01424-374">説明</span><span class="sxs-lookup"><span data-stu-id="01424-374">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-375">ID</span><span class="sxs-lookup"><span data-stu-id="01424-375">ID</span></span>            | <span data-ttu-id="01424-376">(**必須**) Bluetooth 無線のデバイス ID であり、base 64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-376">(**required**) The device ID for the Bluetooth radio and must be base 64 encoded.</span></span> |
| <span data-ttu-id="01424-377">状態</span><span class="sxs-lookup"><span data-stu-id="01424-377">State</span></span>         | <span data-ttu-id="01424-378">(**必要**) これは、`"On"`または`"Off"`します。</span><span class="sxs-lookup"><span data-stu-id="01424-378">(**required**) This can be `"On"` or `"Off"`.</span></span> |

**<span data-ttu-id="01424-379">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-379">Request headers</span></span>**

- <span data-ttu-id="01424-380">なし</span><span class="sxs-lookup"><span data-stu-id="01424-380">None</span></span>

**<span data-ttu-id="01424-381">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-381">Request body</span></span>**

- <span data-ttu-id="01424-382">なし</span><span class="sxs-lookup"><span data-stu-id="01424-382">None</span></span>

**<span data-ttu-id="01424-383">応答</span><span class="sxs-lookup"><span data-stu-id="01424-383">Response</span></span>**

**<span data-ttu-id="01424-384">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-384">Status code</span></span>**

<span data-ttu-id="01424-385">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-385">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-386">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-386">HTTP status code</span></span> | <span data-ttu-id="01424-387">説明</span><span class="sxs-lookup"><span data-stu-id="01424-387">Description</span></span> |
| :------             | :------ |
| <span data-ttu-id="01424-388">200</span><span class="sxs-lookup"><span data-stu-id="01424-388">200</span></span>              | <span data-ttu-id="01424-389">OK</span><span class="sxs-lookup"><span data-stu-id="01424-389">OK</span></span> |
| <span data-ttu-id="01424-390">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-390">4XX</span></span>              | <span data-ttu-id="01424-391">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-391">Error codes</span></span> |
| <span data-ttu-id="01424-392">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-392">5XX</span></span>              | <span data-ttu-id="01424-393">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-393">Error codes</span></span> |

**<span data-ttu-id="01424-394">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-394">Available device families</span></span>**

* <span data-ttu-id="01424-395">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-395">Windows Desktop</span></span>
* <span data-ttu-id="01424-396">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-396">HoloLens</span></span>
* <span data-ttu-id="01424-397">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-397">IoT</span></span>

<hr>
## <span data-ttu-id="01424-398">デバイス マネージャー</span><span class="sxs-lookup"><span data-stu-id="01424-398">Device manager</span></span>
<hr>
### <span data-ttu-id="01424-399">コンピューターにインストールされているデバイスを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-399">Get the installed devices on the machine</span></span>

**<span data-ttu-id="01424-400">要求</span><span class="sxs-lookup"><span data-stu-id="01424-400">Request</span></span>**

<span data-ttu-id="01424-401">次の要求形式を使用して、コンピューターにインストールされているデバイスの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-401">You can get a list of devices that are installed on the machine by using the following request format.</span></span>

| <span data-ttu-id="01424-402">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-402">Method</span></span>      | <span data-ttu-id="01424-403">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-403">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-404">GET</span><span class="sxs-lookup"><span data-stu-id="01424-404">GET</span></span> | <span data-ttu-id="01424-405">/api/devicemanager/devices</span><span class="sxs-lookup"><span data-stu-id="01424-405">/api/devicemanager/devices</span></span> |

**<span data-ttu-id="01424-406">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-406">URI parameters</span></span>**

- <span data-ttu-id="01424-407">なし</span><span class="sxs-lookup"><span data-stu-id="01424-407">None</span></span>

**<span data-ttu-id="01424-408">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-408">Request headers</span></span>**

- <span data-ttu-id="01424-409">なし</span><span class="sxs-lookup"><span data-stu-id="01424-409">None</span></span>

**<span data-ttu-id="01424-410">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-410">Request body</span></span>**

- <span data-ttu-id="01424-411">なし</span><span class="sxs-lookup"><span data-stu-id="01424-411">None</span></span>

**<span data-ttu-id="01424-412">応答</span><span class="sxs-lookup"><span data-stu-id="01424-412">Response</span></span>**

<span data-ttu-id="01424-413">応答には、デバイスにアタッチされているデバイスの JSON 配列が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-413">The response includes a JSON array of devices attached to the device.</span></span>
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

**<span data-ttu-id="01424-414">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-414">Status code</span></span>**

<span data-ttu-id="01424-415">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-415">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-416">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-416">HTTP status code</span></span>      | <span data-ttu-id="01424-417">説明</span><span class="sxs-lookup"><span data-stu-id="01424-417">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-418">200</span><span class="sxs-lookup"><span data-stu-id="01424-418">200</span></span> | <span data-ttu-id="01424-419">OK</span><span class="sxs-lookup"><span data-stu-id="01424-419">OK</span></span> | 
| <span data-ttu-id="01424-420">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-420">4XX</span></span> | <span data-ttu-id="01424-421">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-421">Error codes</span></span> |
| <span data-ttu-id="01424-422">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-422">5XX</span></span> | <span data-ttu-id="01424-423">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-423">Error codes</span></span> |

**<span data-ttu-id="01424-424">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-424">Available device families</span></span>**

* <span data-ttu-id="01424-425">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-425">Windows Mobile</span></span>
* <span data-ttu-id="01424-426">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-426">Windows Desktop</span></span>
* <span data-ttu-id="01424-427">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-427">IoT</span></span>

<hr>
### <span data-ttu-id="01424-428">接続された USB デバイス/ハブのデータを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-428">Get data on connected USB Devices/Hubs</span></span>

**<span data-ttu-id="01424-429">要求</span><span class="sxs-lookup"><span data-stu-id="01424-429">Request</span></span>**

<span data-ttu-id="01424-430">次の要求形式を使用して、接続された USB デバイスおよびハブの USB 記述子の一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-430">You can get a list of USB descriptors for connected USB devices and Hubs by using the following request format.</span></span>

| <span data-ttu-id="01424-431">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-431">Method</span></span>      | <span data-ttu-id="01424-432">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-432">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-433">GET</span><span class="sxs-lookup"><span data-stu-id="01424-433">GET</span></span> | <span data-ttu-id="01424-434">/ext/devices/usbdevices</span><span class="sxs-lookup"><span data-stu-id="01424-434">/ext/devices/usbdevices</span></span> |


**<span data-ttu-id="01424-435">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-435">URI parameters</span></span>**

- <span data-ttu-id="01424-436">なし</span><span class="sxs-lookup"><span data-stu-id="01424-436">None</span></span>

**<span data-ttu-id="01424-437">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-437">Request headers</span></span>**

- <span data-ttu-id="01424-438">なし</span><span class="sxs-lookup"><span data-stu-id="01424-438">None</span></span>

**<span data-ttu-id="01424-439">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-439">Request body</span></span>**

- <span data-ttu-id="01424-440">なし</span><span class="sxs-lookup"><span data-stu-id="01424-440">None</span></span>

**<span data-ttu-id="01424-441">応答</span><span class="sxs-lookup"><span data-stu-id="01424-441">Response</span></span>**

<span data-ttu-id="01424-442">応答は、ハブの USB 記述子およびポート情報と共に、USB デバイスのデバイス ID が含まれる JSON です。</span><span class="sxs-lookup"><span data-stu-id="01424-442">The response is JSON that includes DeviceID for the USB Device along with the USB Descriptors and port information for hubs.</span></span>
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

**<span data-ttu-id="01424-443">返されるデータのサンプル</span><span class="sxs-lookup"><span data-stu-id="01424-443">Sample return data</span></span>**
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

**<span data-ttu-id="01424-444">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-444">Status code</span></span>**

<span data-ttu-id="01424-445">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-445">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-446">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-446">HTTP status code</span></span>      | <span data-ttu-id="01424-447">説明</span><span class="sxs-lookup"><span data-stu-id="01424-447">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-448">200</span><span class="sxs-lookup"><span data-stu-id="01424-448">200</span></span> | <span data-ttu-id="01424-449">OK</span><span class="sxs-lookup"><span data-stu-id="01424-449">OK</span></span> | 
| <span data-ttu-id="01424-450">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-450">5XX</span></span> | <span data-ttu-id="01424-451">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-451">Error codes</span></span> |

**<span data-ttu-id="01424-452">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-452">Available device families</span></span>**

* <span data-ttu-id="01424-453">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-453">Windows Desktop</span></span>
* <span data-ttu-id="01424-454">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-454">IoT</span></span>

<hr>
## <span data-ttu-id="01424-455">ダンプの収集</span><span class="sxs-lookup"><span data-stu-id="01424-455">Dump collection</span></span>
<hr>
### <span data-ttu-id="01424-456">アプリのすべてのクラッシュ ダンプの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-456">Get the list of all crash dumps for apps</span></span>

**<span data-ttu-id="01424-457">要求</span><span class="sxs-lookup"><span data-stu-id="01424-457">Request</span></span>**

<span data-ttu-id="01424-458">次の要求形式を使用して、サイドローディングされたすべてのアプリについて、利用可能なすべてのクラッシュ ダンプの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-458">You can get the list of all the available crash dumps for all sideloaded apps by using the following request format.</span></span>
 
| <span data-ttu-id="01424-459">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-459">Method</span></span>      | <span data-ttu-id="01424-460">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-460">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-461">GET</span><span class="sxs-lookup"><span data-stu-id="01424-461">GET</span></span> | <span data-ttu-id="01424-462">/api/debug/dump/usermode/dumps</span><span class="sxs-lookup"><span data-stu-id="01424-462">/api/debug/dump/usermode/dumps</span></span> |


**<span data-ttu-id="01424-463">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-463">URI parameters</span></span>**

- <span data-ttu-id="01424-464">なし</span><span class="sxs-lookup"><span data-stu-id="01424-464">None</span></span>

**<span data-ttu-id="01424-465">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-465">Request headers</span></span>**

- <span data-ttu-id="01424-466">なし</span><span class="sxs-lookup"><span data-stu-id="01424-466">None</span></span>

**<span data-ttu-id="01424-467">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-467">Request body</span></span>**

- <span data-ttu-id="01424-468">なし</span><span class="sxs-lookup"><span data-stu-id="01424-468">None</span></span>

**<span data-ttu-id="01424-469">応答</span><span class="sxs-lookup"><span data-stu-id="01424-469">Response</span></span>**

<span data-ttu-id="01424-470">応答には、サイドローディングされたアプリケーションごとにクラッシュ ダンプの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-470">The response includes a list of crash dumps for each sideloaded application.</span></span>

**<span data-ttu-id="01424-471">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-471">Status code</span></span>**

<span data-ttu-id="01424-472">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-472">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-473">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-473">HTTP status code</span></span>      | <span data-ttu-id="01424-474">説明</span><span class="sxs-lookup"><span data-stu-id="01424-474">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-475">200</span><span class="sxs-lookup"><span data-stu-id="01424-475">200</span></span> | <span data-ttu-id="01424-476">OK</span><span class="sxs-lookup"><span data-stu-id="01424-476">OK</span></span> | 
| <span data-ttu-id="01424-477">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-477">4XX</span></span> | <span data-ttu-id="01424-478">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-478">Error codes</span></span> |
| <span data-ttu-id="01424-479">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-479">5XX</span></span> | <span data-ttu-id="01424-480">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-480">Error codes</span></span> |

**<span data-ttu-id="01424-481">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-481">Available device families</span></span>**

* <span data-ttu-id="01424-482">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="01424-482">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="01424-483">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-483">Windows Desktop</span></span>
* <span data-ttu-id="01424-484">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-484">HoloLens</span></span>
* <span data-ttu-id="01424-485">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-485">IoT</span></span>

<hr>
### <span data-ttu-id="01424-486">アプリのクラッシュ ダンプ収集設定を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-486">Get the crash dump collection settings for an app</span></span>

**<span data-ttu-id="01424-487">要求</span><span class="sxs-lookup"><span data-stu-id="01424-487">Request</span></span>**

<span data-ttu-id="01424-488">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプ収集設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-488">You can get the crash dump collection settings for a sideloaded app by using the following request format.</span></span>
 
| <span data-ttu-id="01424-489">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-489">Method</span></span>      | <span data-ttu-id="01424-490">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-490">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-491">GET</span><span class="sxs-lookup"><span data-stu-id="01424-491">GET</span></span> | <span data-ttu-id="01424-492">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="01424-492">/api/debug/dump/usermode/crashcontrol</span></span> |


**<span data-ttu-id="01424-493">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-493">URI parameters</span></span>**

<span data-ttu-id="01424-494">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-494">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-495">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-495">URI parameter</span></span> | <span data-ttu-id="01424-496">説明</span><span class="sxs-lookup"><span data-stu-id="01424-496">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-497">packageFullname</span><span class="sxs-lookup"><span data-stu-id="01424-497">packageFullname</span></span>   | <span data-ttu-id="01424-498">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="01424-498">(**required**) The full name of the package for the sideloaded app.</span></span> |

**<span data-ttu-id="01424-499">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-499">Request headers</span></span>**

- <span data-ttu-id="01424-500">なし</span><span class="sxs-lookup"><span data-stu-id="01424-500">None</span></span>

**<span data-ttu-id="01424-501">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-501">Request body</span></span>**

- <span data-ttu-id="01424-502">なし</span><span class="sxs-lookup"><span data-stu-id="01424-502">None</span></span>

**<span data-ttu-id="01424-503">応答</span><span class="sxs-lookup"><span data-stu-id="01424-503">Response</span></span>**

<span data-ttu-id="01424-504">応答は、次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="01424-504">The response has the following format.</span></span>
```json
{"CrashDumpEnabled": bool}
```

**<span data-ttu-id="01424-505">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-505">Status code</span></span>**

<span data-ttu-id="01424-506">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-506">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-507">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-507">HTTP status code</span></span>      | <span data-ttu-id="01424-508">説明</span><span class="sxs-lookup"><span data-stu-id="01424-508">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-509">200</span><span class="sxs-lookup"><span data-stu-id="01424-509">200</span></span> | <span data-ttu-id="01424-510">OK</span><span class="sxs-lookup"><span data-stu-id="01424-510">OK</span></span> | 
| <span data-ttu-id="01424-511">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-511">4XX</span></span> | <span data-ttu-id="01424-512">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-512">Error codes</span></span> |
| <span data-ttu-id="01424-513">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-513">5XX</span></span> | <span data-ttu-id="01424-514">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-514">Error codes</span></span> |

**<span data-ttu-id="01424-515">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-515">Available device families</span></span>**

* <span data-ttu-id="01424-516">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="01424-516">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="01424-517">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-517">Windows Desktop</span></span>
* <span data-ttu-id="01424-518">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-518">HoloLens</span></span>
* <span data-ttu-id="01424-519">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-519">IoT</span></span>

<hr>
### <span data-ttu-id="01424-520">サイドローディングされたアプリのクラッシュ ダンプを削除する</span><span class="sxs-lookup"><span data-stu-id="01424-520">Delete a crash dump for a sideloaded app</span></span>

**<span data-ttu-id="01424-521">要求</span><span class="sxs-lookup"><span data-stu-id="01424-521">Request</span></span>**

<span data-ttu-id="01424-522">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを削除できます。</span><span class="sxs-lookup"><span data-stu-id="01424-522">You can delete a sideloaded app's crash dump by using the following request format.</span></span>
 
| <span data-ttu-id="01424-523">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-523">Method</span></span>      | <span data-ttu-id="01424-524">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-524">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-525">Del</span><span class="sxs-lookup"><span data-stu-id="01424-525">DELETE</span></span> | <span data-ttu-id="01424-526">/api/debug/dump/usermode/crashdump</span><span class="sxs-lookup"><span data-stu-id="01424-526">/api/debug/dump/usermode/crashdump</span></span> |


**<span data-ttu-id="01424-527">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-527">URI parameters</span></span>**

<span data-ttu-id="01424-528">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-528">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-529">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-529">URI parameter</span></span> | <span data-ttu-id="01424-530">説明</span><span class="sxs-lookup"><span data-stu-id="01424-530">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="01424-531">packageFullname</span><span class="sxs-lookup"><span data-stu-id="01424-531">packageFullname</span></span>   | <span data-ttu-id="01424-532">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="01424-532">(**required**) The full name of the package for the sideloaded app.</span></span> |
| <span data-ttu-id="01424-533">fileName</span><span class="sxs-lookup"><span data-stu-id="01424-533">fileName</span></span>   | <span data-ttu-id="01424-534">(**必須**) 削除する必要があるダンプ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-534">(**required**) The name of the dump file that should be deleted.</span></span> |

**<span data-ttu-id="01424-535">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-535">Request headers</span></span>**

- <span data-ttu-id="01424-536">なし</span><span class="sxs-lookup"><span data-stu-id="01424-536">None</span></span>

**<span data-ttu-id="01424-537">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-537">Request body</span></span>**

- <span data-ttu-id="01424-538">なし</span><span class="sxs-lookup"><span data-stu-id="01424-538">None</span></span>

**<span data-ttu-id="01424-539">応答</span><span class="sxs-lookup"><span data-stu-id="01424-539">Response</span></span>**

**<span data-ttu-id="01424-540">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-540">Status code</span></span>**

<span data-ttu-id="01424-541">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-541">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-542">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-542">HTTP status code</span></span>      | <span data-ttu-id="01424-543">説明</span><span class="sxs-lookup"><span data-stu-id="01424-543">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-544">200</span><span class="sxs-lookup"><span data-stu-id="01424-544">200</span></span> | <span data-ttu-id="01424-545">OK</span><span class="sxs-lookup"><span data-stu-id="01424-545">OK</span></span> | 
| <span data-ttu-id="01424-546">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-546">4XX</span></span> | <span data-ttu-id="01424-547">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-547">Error codes</span></span> |
| <span data-ttu-id="01424-548">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-548">5XX</span></span> | <span data-ttu-id="01424-549">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-549">Error codes</span></span> |

**<span data-ttu-id="01424-550">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-550">Available device families</span></span>**

* <span data-ttu-id="01424-551">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="01424-551">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="01424-552">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-552">Windows Desktop</span></span>
* <span data-ttu-id="01424-553">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-553">HoloLens</span></span>
* <span data-ttu-id="01424-554">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-554">IoT</span></span>

<hr>
### <span data-ttu-id="01424-555">サイドローディングされたアプリのクラッシュ ダンプを無効にする</span><span class="sxs-lookup"><span data-stu-id="01424-555">Disable crash dumps for a sideloaded app</span></span>

**<span data-ttu-id="01424-556">要求</span><span class="sxs-lookup"><span data-stu-id="01424-556">Request</span></span>**

<span data-ttu-id="01424-557">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="01424-557">You can disable crash dumps for a sideloaded app by using the following request format.</span></span>
 
| <span data-ttu-id="01424-558">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-558">Method</span></span>      | <span data-ttu-id="01424-559">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-559">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-560">Del</span><span class="sxs-lookup"><span data-stu-id="01424-560">DELETE</span></span> | <span data-ttu-id="01424-561">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="01424-561">/api/debug/dump/usermode/crashcontrol</span></span> |


**<span data-ttu-id="01424-562">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-562">URI parameters</span></span>**

<span data-ttu-id="01424-563">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-563">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-564">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-564">URI parameter</span></span> | <span data-ttu-id="01424-565">説明</span><span class="sxs-lookup"><span data-stu-id="01424-565">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="01424-566">packageFullname</span><span class="sxs-lookup"><span data-stu-id="01424-566">packageFullname</span></span>   | <span data-ttu-id="01424-567">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="01424-567">(**required**) The full name of the package for the sideloaded app.</span></span> |

**<span data-ttu-id="01424-568">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-568">Request headers</span></span>**

- <span data-ttu-id="01424-569">なし</span><span class="sxs-lookup"><span data-stu-id="01424-569">None</span></span>

**<span data-ttu-id="01424-570">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-570">Request body</span></span>**

- <span data-ttu-id="01424-571">なし</span><span class="sxs-lookup"><span data-stu-id="01424-571">None</span></span>

**<span data-ttu-id="01424-572">応答</span><span class="sxs-lookup"><span data-stu-id="01424-572">Response</span></span>**

**<span data-ttu-id="01424-573">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-573">Status code</span></span>**

<span data-ttu-id="01424-574">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-574">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-575">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-575">HTTP status code</span></span>      | <span data-ttu-id="01424-576">説明</span><span class="sxs-lookup"><span data-stu-id="01424-576">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-577">200</span><span class="sxs-lookup"><span data-stu-id="01424-577">200</span></span> | <span data-ttu-id="01424-578">OK</span><span class="sxs-lookup"><span data-stu-id="01424-578">OK</span></span> | 
| <span data-ttu-id="01424-579">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-579">4XX</span></span> | <span data-ttu-id="01424-580">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-580">Error codes</span></span> |
| <span data-ttu-id="01424-581">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-581">5XX</span></span> | <span data-ttu-id="01424-582">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-582">Error codes</span></span> |

**<span data-ttu-id="01424-583">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-583">Available device families</span></span>**

* <span data-ttu-id="01424-584">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="01424-584">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="01424-585">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-585">Windows Desktop</span></span>
* <span data-ttu-id="01424-586">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-586">HoloLens</span></span>
* <span data-ttu-id="01424-587">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-587">IoT</span></span>

<hr>
### <span data-ttu-id="01424-588">サイドローディングされたアプリのクラッシュ ダンプをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="01424-588">Download the crash dump for a sideloaded app</span></span>

**<span data-ttu-id="01424-589">要求</span><span class="sxs-lookup"><span data-stu-id="01424-589">Request</span></span>**

<span data-ttu-id="01424-590">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="01424-590">You can download a sideloaded app's crash dump by using the following request format.</span></span>
 
| <span data-ttu-id="01424-591">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-591">Method</span></span>      | <span data-ttu-id="01424-592">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-592">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-593">GET</span><span class="sxs-lookup"><span data-stu-id="01424-593">GET</span></span> | <span data-ttu-id="01424-594">/api/debug/dump/usermode/crashdump</span><span class="sxs-lookup"><span data-stu-id="01424-594">/api/debug/dump/usermode/crashdump</span></span> |


**<span data-ttu-id="01424-595">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-595">URI parameters</span></span>**

<span data-ttu-id="01424-596">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-596">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-597">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-597">URI parameter</span></span> | <span data-ttu-id="01424-598">説明</span><span class="sxs-lookup"><span data-stu-id="01424-598">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-599">packageFullname</span><span class="sxs-lookup"><span data-stu-id="01424-599">packageFullname</span></span>   | <span data-ttu-id="01424-600">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="01424-600">(**required**) The full name of the package for the sideloaded app.</span></span> |
| <span data-ttu-id="01424-601">fileName</span><span class="sxs-lookup"><span data-stu-id="01424-601">fileName</span></span>   | <span data-ttu-id="01424-602">(**必須**) ダウンロードするダンプ ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-602">(**required**) The name of the dump file that you want to download.</span></span> |

**<span data-ttu-id="01424-603">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-603">Request headers</span></span>**

- <span data-ttu-id="01424-604">なし</span><span class="sxs-lookup"><span data-stu-id="01424-604">None</span></span>

**<span data-ttu-id="01424-605">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-605">Request body</span></span>**

- <span data-ttu-id="01424-606">なし</span><span class="sxs-lookup"><span data-stu-id="01424-606">None</span></span>

**<span data-ttu-id="01424-607">応答</span><span class="sxs-lookup"><span data-stu-id="01424-607">Response</span></span>**

<span data-ttu-id="01424-608">応答には、ダンプ ファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-608">The response includes a dump file.</span></span> <span data-ttu-id="01424-609">WinDbg または Visual Studio を使用して、ダンプ ファイルを検証できます。</span><span class="sxs-lookup"><span data-stu-id="01424-609">You can use WinDbg or Visual Studio to examine the dump file.</span></span>

**<span data-ttu-id="01424-610">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-610">Status code</span></span>**

<span data-ttu-id="01424-611">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-611">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-612">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-612">HTTP status code</span></span>      | <span data-ttu-id="01424-613">説明</span><span class="sxs-lookup"><span data-stu-id="01424-613">Description</span></span> |
| :------     | :----- |
|  <span data-ttu-id="01424-614">200</span><span class="sxs-lookup"><span data-stu-id="01424-614">200</span></span> | <span data-ttu-id="01424-615">OK</span><span class="sxs-lookup"><span data-stu-id="01424-615">OK</span></span> | 
| <span data-ttu-id="01424-616">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-616">4XX</span></span> | <span data-ttu-id="01424-617">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-617">Error codes</span></span> |
| <span data-ttu-id="01424-618">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-618">5XX</span></span> | <span data-ttu-id="01424-619">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-619">Error codes</span></span> |

**<span data-ttu-id="01424-620">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-620">Available device families</span></span>**

* <span data-ttu-id="01424-621">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="01424-621">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="01424-622">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-622">Windows Desktop</span></span>
* <span data-ttu-id="01424-623">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-623">HoloLens</span></span>
* <span data-ttu-id="01424-624">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-624">IoT</span></span>

<hr>
### <span data-ttu-id="01424-625">サイドローディングされたアプリのクラッシュ ダンプを有効にする</span><span class="sxs-lookup"><span data-stu-id="01424-625">Enable crash dumps for a sideloaded app</span></span>

**<span data-ttu-id="01424-626">要求</span><span class="sxs-lookup"><span data-stu-id="01424-626">Request</span></span>**

<span data-ttu-id="01424-627">次の要求形式を使用して、サイドローディングされたアプリのクラッシュ ダンプを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="01424-627">You can enable crash dumps for a sideloaded app by using the following request format.</span></span>
 
| <span data-ttu-id="01424-628">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-628">Method</span></span>      | <span data-ttu-id="01424-629">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-629">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-630">POST</span><span class="sxs-lookup"><span data-stu-id="01424-630">POST</span></span> | <span data-ttu-id="01424-631">/api/debug/dump/usermode/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="01424-631">/api/debug/dump/usermode/crashcontrol</span></span> |


**<span data-ttu-id="01424-632">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-632">URI parameters</span></span>**

<span data-ttu-id="01424-633">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-633">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-634">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-634">URI parameter</span></span> | <span data-ttu-id="01424-635">説明</span><span class="sxs-lookup"><span data-stu-id="01424-635">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="01424-636">packageFullname</span><span class="sxs-lookup"><span data-stu-id="01424-636">packageFullname</span></span>   | <span data-ttu-id="01424-637">(**必須**) サイドローディングされたアプリのパッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="01424-637">(**required**) The full name of the package for the sideloaded app.</span></span> |

**<span data-ttu-id="01424-638">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-638">Request headers</span></span>**

- <span data-ttu-id="01424-639">なし</span><span class="sxs-lookup"><span data-stu-id="01424-639">None</span></span>

**<span data-ttu-id="01424-640">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-640">Request body</span></span>**

- <span data-ttu-id="01424-641">なし</span><span class="sxs-lookup"><span data-stu-id="01424-641">None</span></span>

**<span data-ttu-id="01424-642">応答</span><span class="sxs-lookup"><span data-stu-id="01424-642">Response</span></span>**

**<span data-ttu-id="01424-643">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-643">Status code</span></span>**

<span data-ttu-id="01424-644">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-644">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-645">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-645">HTTP status code</span></span>      | <span data-ttu-id="01424-646">説明</span><span class="sxs-lookup"><span data-stu-id="01424-646">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-647">200</span><span class="sxs-lookup"><span data-stu-id="01424-647">200</span></span> | <span data-ttu-id="01424-648">OK</span><span class="sxs-lookup"><span data-stu-id="01424-648">OK</span></span> | 

**<span data-ttu-id="01424-649">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-649">Available device families</span></span>**

* <span data-ttu-id="01424-650">Window Mobile (Windows Insider Program のみ)</span><span class="sxs-lookup"><span data-stu-id="01424-650">Window Mobile (in Windows Insider Program)</span></span>
* <span data-ttu-id="01424-651">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-651">Windows Desktop</span></span>
* <span data-ttu-id="01424-652">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-652">HoloLens</span></span>
* <span data-ttu-id="01424-653">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-653">IoT</span></span>

<hr>
### <span data-ttu-id="01424-654">バグチェック ファイルの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-654">Get the list of bugcheck files</span></span>

**<span data-ttu-id="01424-655">要求</span><span class="sxs-lookup"><span data-stu-id="01424-655">Request</span></span>**

<span data-ttu-id="01424-656">次の要求形式を使用して、バグチェックのミニダンプ ファイルの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-656">You can get the list of bugcheck minidump files by using the following request format.</span></span>
 
| <span data-ttu-id="01424-657">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-657">Method</span></span>      | <span data-ttu-id="01424-658">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-658">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-659">GET</span><span class="sxs-lookup"><span data-stu-id="01424-659">GET</span></span> | <span data-ttu-id="01424-660">/api/debug/dump/kernel/dumplist</span><span class="sxs-lookup"><span data-stu-id="01424-660">/api/debug/dump/kernel/dumplist</span></span> |


**<span data-ttu-id="01424-661">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-661">URI parameters</span></span>**

- <span data-ttu-id="01424-662">なし</span><span class="sxs-lookup"><span data-stu-id="01424-662">None</span></span>

**<span data-ttu-id="01424-663">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-663">Request headers</span></span>**

- <span data-ttu-id="01424-664">なし</span><span class="sxs-lookup"><span data-stu-id="01424-664">None</span></span>

**<span data-ttu-id="01424-665">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-665">Request body</span></span>**

- <span data-ttu-id="01424-666">なし</span><span class="sxs-lookup"><span data-stu-id="01424-666">None</span></span>

**<span data-ttu-id="01424-667">応答</span><span class="sxs-lookup"><span data-stu-id="01424-667">Response</span></span>**

<span data-ttu-id="01424-668">応答には、ダンプ ファイル名とこれらのファイルのサイズの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-668">The response includes a list of dump file names and the sizes of these files.</span></span> <span data-ttu-id="01424-669">一覧は、次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="01424-669">This list will be in the following format.</span></span> 
```json
{"DumpFiles": [
    {
        "FileName": string,
        "FileSize": int
    },...
]}
```

**<span data-ttu-id="01424-670">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-670">Status code</span></span>**

<span data-ttu-id="01424-671">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-671">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-672">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-672">HTTP status code</span></span>      | <span data-ttu-id="01424-673">説明</span><span class="sxs-lookup"><span data-stu-id="01424-673">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-674">200</span><span class="sxs-lookup"><span data-stu-id="01424-674">200</span></span> | <span data-ttu-id="01424-675">OK</span><span class="sxs-lookup"><span data-stu-id="01424-675">OK</span></span> | 

**<span data-ttu-id="01424-676">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-676">Available device families</span></span>**

* <span data-ttu-id="01424-677">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-677">Windows Desktop</span></span>
* <span data-ttu-id="01424-678">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-678">IoT</span></span>

<hr>
### <span data-ttu-id="01424-679">バグチェックのダンプ ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="01424-679">Download a bugcheck dump file</span></span>

**<span data-ttu-id="01424-680">要求</span><span class="sxs-lookup"><span data-stu-id="01424-680">Request</span></span>**

<span data-ttu-id="01424-681">次の要求形式を使用して、バグチェックのダンプ ファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="01424-681">You can download a bugcheck dump file by using the following request format.</span></span>
 
| <span data-ttu-id="01424-682">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-682">Method</span></span>      | <span data-ttu-id="01424-683">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-683">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-684">GET</span><span class="sxs-lookup"><span data-stu-id="01424-684">GET</span></span> | <span data-ttu-id="01424-685">/api/debug/dump/kernel/dump</span><span class="sxs-lookup"><span data-stu-id="01424-685">/api/debug/dump/kernel/dump</span></span> |


**<span data-ttu-id="01424-686">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-686">URI parameters</span></span>**

<span data-ttu-id="01424-687">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-687">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-688">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-688">URI parameter</span></span> | <span data-ttu-id="01424-689">説明</span><span class="sxs-lookup"><span data-stu-id="01424-689">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-690">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="01424-690">filename</span></span>   | <span data-ttu-id="01424-691">(**必須**) ダンプ ファイルのファイル名。</span><span class="sxs-lookup"><span data-stu-id="01424-691">(**required**) The file name of the dump file.</span></span> <span data-ttu-id="01424-692">API を使ってダンプの一覧を取得することによって確認できます。</span><span class="sxs-lookup"><span data-stu-id="01424-692">You can find this by using the API to get the dump list.</span></span> |


**<span data-ttu-id="01424-693">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-693">Request headers</span></span>**

- <span data-ttu-id="01424-694">なし</span><span class="sxs-lookup"><span data-stu-id="01424-694">None</span></span>

**<span data-ttu-id="01424-695">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-695">Request body</span></span>**

- <span data-ttu-id="01424-696">なし</span><span class="sxs-lookup"><span data-stu-id="01424-696">None</span></span>

**<span data-ttu-id="01424-697">応答</span><span class="sxs-lookup"><span data-stu-id="01424-697">Response</span></span>**

<span data-ttu-id="01424-698">応答には、ダンプ ファイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-698">The response includes the dump file.</span></span> <span data-ttu-id="01424-699">WinDbg を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="01424-699">You can inspect this file using WinDbg.</span></span>

**<span data-ttu-id="01424-700">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-700">Status code</span></span>**

<span data-ttu-id="01424-701">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-701">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-702">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-702">HTTP status code</span></span>      | <span data-ttu-id="01424-703">説明</span><span class="sxs-lookup"><span data-stu-id="01424-703">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-704">200</span><span class="sxs-lookup"><span data-stu-id="01424-704">200</span></span> | <span data-ttu-id="01424-705">OK</span><span class="sxs-lookup"><span data-stu-id="01424-705">OK</span></span> | 
| <span data-ttu-id="01424-706">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-706">4XX</span></span> | <span data-ttu-id="01424-707">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-707">Error codes</span></span> |
| <span data-ttu-id="01424-708">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-708">5XX</span></span> | <span data-ttu-id="01424-709">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-709">Error codes</span></span> |

**<span data-ttu-id="01424-710">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-710">Available device families</span></span>**

* <span data-ttu-id="01424-711">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-711">Windows Desktop</span></span>
* <span data-ttu-id="01424-712">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-712">IoT</span></span>

<hr>
### <span data-ttu-id="01424-713">バグチェックのクラッシュ制御の設定を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-713">Get the bugcheck crash control settings</span></span>

**<span data-ttu-id="01424-714">要求</span><span class="sxs-lookup"><span data-stu-id="01424-714">Request</span></span>**

<span data-ttu-id="01424-715">次の要求形式を使用して、バグチェックのクラッシュ制御の設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-715">You can get the bugcheck crash control settings by using the following request format.</span></span>
 
| <span data-ttu-id="01424-716">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-716">Method</span></span>      | <span data-ttu-id="01424-717">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-717">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-718">GET</span><span class="sxs-lookup"><span data-stu-id="01424-718">GET</span></span> | <span data-ttu-id="01424-719">/api/debug/dump/kernel/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="01424-719">/api/debug/dump/kernel/crashcontrol</span></span> |


**<span data-ttu-id="01424-720">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-720">URI parameters</span></span>**

- <span data-ttu-id="01424-721">なし</span><span class="sxs-lookup"><span data-stu-id="01424-721">None</span></span>

**<span data-ttu-id="01424-722">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-722">Request headers</span></span>**

- <span data-ttu-id="01424-723">なし</span><span class="sxs-lookup"><span data-stu-id="01424-723">None</span></span>

**<span data-ttu-id="01424-724">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-724">Request body</span></span>**

- <span data-ttu-id="01424-725">なし</span><span class="sxs-lookup"><span data-stu-id="01424-725">None</span></span>

**<span data-ttu-id="01424-726">応答</span><span class="sxs-lookup"><span data-stu-id="01424-726">Response</span></span>**

<span data-ttu-id="01424-727">応答には、クラッシュの制御の設定が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-727">The response includes the crash control settings.</span></span> <span data-ttu-id="01424-728">CrashControl について詳しくは、「[CrashControl](https://technet.microsoft.com/library/cc951703.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="01424-728">For more information about CrashControl, see the [CrashControl](https://technet.microsoft.com/library/cc951703.aspx) article.</span></span> <span data-ttu-id="01424-729">応答のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-729">The template for the response is as follows.</span></span>
```json
{
    "autoreboot": bool (0 or 1),
    "dumptype": int (0 to 4),
    "maxdumpcount": int,
    "overwrite": bool (0 or 1)
}
```

**<span data-ttu-id="01424-730">ダンプの種類</span><span class="sxs-lookup"><span data-stu-id="01424-730">Dump types</span></span>**

<span data-ttu-id="01424-731">0:Disabled</span><span class="sxs-lookup"><span data-stu-id="01424-731">0: Disabled</span></span>

<span data-ttu-id="01424-732">1:完全メモリ ダンプを (すべての使用中のメモリを収集します)</span><span class="sxs-lookup"><span data-stu-id="01424-732">1: Complete memory dump (collects all in-use memory)</span></span>

<span data-ttu-id="01424-733">2:カーネル メモリ ダンプが (ユーザー モードのメモリは無視されます)</span><span class="sxs-lookup"><span data-stu-id="01424-733">2: Kernel memory dump (ignores user mode memory)</span></span>

<span data-ttu-id="01424-734">3:制限付きのカーネルのミニダンプ</span><span class="sxs-lookup"><span data-stu-id="01424-734">3: Limited kernel minidump</span></span>

**<span data-ttu-id="01424-735">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-735">Status code</span></span>**

<span data-ttu-id="01424-736">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-736">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-737">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-737">HTTP status code</span></span>      | <span data-ttu-id="01424-738">説明</span><span class="sxs-lookup"><span data-stu-id="01424-738">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-739">200</span><span class="sxs-lookup"><span data-stu-id="01424-739">200</span></span> | <span data-ttu-id="01424-740">OK</span><span class="sxs-lookup"><span data-stu-id="01424-740">OK</span></span> | 
| <span data-ttu-id="01424-741">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-741">4XX</span></span> | <span data-ttu-id="01424-742">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-742">Error codes</span></span> |
| <span data-ttu-id="01424-743">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-743">5XX</span></span> | <span data-ttu-id="01424-744">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-744">Error codes</span></span> |

**<span data-ttu-id="01424-745">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-745">Available device families</span></span>**

* <span data-ttu-id="01424-746">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-746">Windows Desktop</span></span>
* <span data-ttu-id="01424-747">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-747">IoT</span></span>

<hr>
### <span data-ttu-id="01424-748">ライブ カーネル ダンプを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-748">Get a live kernel dump</span></span>

**<span data-ttu-id="01424-749">要求</span><span class="sxs-lookup"><span data-stu-id="01424-749">Request</span></span>**

<span data-ttu-id="01424-750">次の要求形式を使用して、ライブ カーネル ダンプを取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-750">You can get a live kernel dump by using the following request format.</span></span>
 
| <span data-ttu-id="01424-751">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-751">Method</span></span>      | <span data-ttu-id="01424-752">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-752">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-753">GET</span><span class="sxs-lookup"><span data-stu-id="01424-753">GET</span></span> | <span data-ttu-id="01424-754">/api/debug/dump/livekernel</span><span class="sxs-lookup"><span data-stu-id="01424-754">/api/debug/dump/livekernel</span></span> |


**<span data-ttu-id="01424-755">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-755">URI parameters</span></span>**

- <span data-ttu-id="01424-756">なし</span><span class="sxs-lookup"><span data-stu-id="01424-756">None</span></span>

**<span data-ttu-id="01424-757">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-757">Request headers</span></span>**

- <span data-ttu-id="01424-758">なし</span><span class="sxs-lookup"><span data-stu-id="01424-758">None</span></span>

**<span data-ttu-id="01424-759">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-759">Request body</span></span>**

- <span data-ttu-id="01424-760">なし</span><span class="sxs-lookup"><span data-stu-id="01424-760">None</span></span>

**<span data-ttu-id="01424-761">応答</span><span class="sxs-lookup"><span data-stu-id="01424-761">Response</span></span>**

<span data-ttu-id="01424-762">応答には、カーネル モードの完全なダンプが含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-762">The response includes the full kernel mode dump.</span></span> <span data-ttu-id="01424-763">WinDbg を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="01424-763">You can inspect this file using WinDbg.</span></span>

**<span data-ttu-id="01424-764">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-764">Status code</span></span>**

<span data-ttu-id="01424-765">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-765">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-766">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-766">HTTP status code</span></span>      | <span data-ttu-id="01424-767">説明</span><span class="sxs-lookup"><span data-stu-id="01424-767">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-768">200</span><span class="sxs-lookup"><span data-stu-id="01424-768">200</span></span> | <span data-ttu-id="01424-769">OK</span><span class="sxs-lookup"><span data-stu-id="01424-769">OK</span></span> | 
| <span data-ttu-id="01424-770">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-770">4XX</span></span> | <span data-ttu-id="01424-771">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-771">Error codes</span></span> |
| <span data-ttu-id="01424-772">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-772">5XX</span></span> | <span data-ttu-id="01424-773">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-773">Error codes</span></span> |

**<span data-ttu-id="01424-774">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-774">Available device families</span></span>**

* <span data-ttu-id="01424-775">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-775">Windows Desktop</span></span>
* <span data-ttu-id="01424-776">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-776">IoT</span></span>

<hr>
### <span data-ttu-id="01424-777">ライブ ユーザー プロセスからダンプを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-777">Get a dump from a live user process</span></span>

**<span data-ttu-id="01424-778">要求</span><span class="sxs-lookup"><span data-stu-id="01424-778">Request</span></span>**

<span data-ttu-id="01424-779">次の要求形式を使用して、ライブ ユーザー プロセスのダンプを取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-779">You can get the dump for live user process by using the following request format.</span></span>
 
| <span data-ttu-id="01424-780">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-780">Method</span></span>      | <span data-ttu-id="01424-781">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-781">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-782">GET</span><span class="sxs-lookup"><span data-stu-id="01424-782">GET</span></span> | <span data-ttu-id="01424-783">/api/debug/dump/usermode/live</span><span class="sxs-lookup"><span data-stu-id="01424-783">/api/debug/dump/usermode/live</span></span> |


**<span data-ttu-id="01424-784">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-784">URI parameters</span></span>**

<span data-ttu-id="01424-785">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-785">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-786">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-786">URI parameter</span></span> | <span data-ttu-id="01424-787">説明</span><span class="sxs-lookup"><span data-stu-id="01424-787">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-788">pid</span><span class="sxs-lookup"><span data-stu-id="01424-788">pid</span></span>   | <span data-ttu-id="01424-789">(**必須**) 目的のプロセスの一意のプロセス ID。</span><span class="sxs-lookup"><span data-stu-id="01424-789">(**required**) The unique process id for the process you are interested in.</span></span> |

**<span data-ttu-id="01424-790">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-790">Request headers</span></span>**

- <span data-ttu-id="01424-791">なし</span><span class="sxs-lookup"><span data-stu-id="01424-791">None</span></span>

**<span data-ttu-id="01424-792">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-792">Request body</span></span>**

- <span data-ttu-id="01424-793">なし</span><span class="sxs-lookup"><span data-stu-id="01424-793">None</span></span>

**<span data-ttu-id="01424-794">応答</span><span class="sxs-lookup"><span data-stu-id="01424-794">Response</span></span>**

<span data-ttu-id="01424-795">応答には、プロセス ダンプが含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-795">The response includes the process dump.</span></span> <span data-ttu-id="01424-796">WinDbg または Visual Studio を使用してこのファイルを調べることができます。</span><span class="sxs-lookup"><span data-stu-id="01424-796">You can inspect this file using WinDbg or Visual Studio.</span></span>

**<span data-ttu-id="01424-797">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-797">Status code</span></span>**

<span data-ttu-id="01424-798">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-798">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-799">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-799">HTTP status code</span></span>      | <span data-ttu-id="01424-800">説明</span><span class="sxs-lookup"><span data-stu-id="01424-800">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-801">200</span><span class="sxs-lookup"><span data-stu-id="01424-801">200</span></span> | <span data-ttu-id="01424-802">OK</span><span class="sxs-lookup"><span data-stu-id="01424-802">OK</span></span> | 
| <span data-ttu-id="01424-803">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-803">4XX</span></span> | <span data-ttu-id="01424-804">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-804">Error codes</span></span> |
| <span data-ttu-id="01424-805">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-805">5XX</span></span> | <span data-ttu-id="01424-806">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-806">Error codes</span></span> |

**<span data-ttu-id="01424-807">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-807">Available device families</span></span>**

* <span data-ttu-id="01424-808">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-808">Windows Desktop</span></span>
* <span data-ttu-id="01424-809">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-809">IoT</span></span>

<hr>
### <span data-ttu-id="01424-810">バグチェックのクラッシュ制御の設定を行う</span><span class="sxs-lookup"><span data-stu-id="01424-810">Set the bugcheck crash control settings</span></span>

**<span data-ttu-id="01424-811">要求</span><span class="sxs-lookup"><span data-stu-id="01424-811">Request</span></span>**

<span data-ttu-id="01424-812">次の要求形式を使用して、バグチェック データの収集に関する設定を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="01424-812">You can set the settings for collecting bugcheck data by using the following request format.</span></span>
 
| <span data-ttu-id="01424-813">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-813">Method</span></span>      | <span data-ttu-id="01424-814">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-814">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-815">POST</span><span class="sxs-lookup"><span data-stu-id="01424-815">POST</span></span> | <span data-ttu-id="01424-816">/api/debug/dump/kernel/crashcontrol</span><span class="sxs-lookup"><span data-stu-id="01424-816">/api/debug/dump/kernel/crashcontrol</span></span> |


**<span data-ttu-id="01424-817">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-817">URI parameters</span></span>**

<span data-ttu-id="01424-818">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-818">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-819">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-819">URI parameter</span></span> | <span data-ttu-id="01424-820">説明</span><span class="sxs-lookup"><span data-stu-id="01424-820">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="01424-821">autoreboot</span><span class="sxs-lookup"><span data-stu-id="01424-821">autoreboot</span></span>   | <span data-ttu-id="01424-822">(**オプション**) true または false。</span><span class="sxs-lookup"><span data-stu-id="01424-822">(**optional**) True or false.</span></span> <span data-ttu-id="01424-823">これは、エラーやロックの発生後に、システムが自動的に再起動するかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="01424-823">This indicates whether the system restarts automatically after it fails or locks.</span></span> |
| <span data-ttu-id="01424-824">dumptype</span><span class="sxs-lookup"><span data-stu-id="01424-824">dumptype</span></span>   | <span data-ttu-id="01424-825">(**オプション**) dump タイプ。</span><span class="sxs-lookup"><span data-stu-id="01424-825">(**optional**) The dump type.</span></span> <span data-ttu-id="01424-826">サポートされる値については、「[CrashDumpType 列挙体](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="01424-826">For the supported values, see the [CrashDumpType Enumeration](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx).</span></span>|
| <span data-ttu-id="01424-827">maxdumpcount</span><span class="sxs-lookup"><span data-stu-id="01424-827">maxdumpcount</span></span>   | <span data-ttu-id="01424-828">(**オプション**) 保存するダンプの最大数。</span><span class="sxs-lookup"><span data-stu-id="01424-828">(**optional**) The maximum number of dumps to save.</span></span> |
| <span data-ttu-id="01424-829">overwrite</span><span class="sxs-lookup"><span data-stu-id="01424-829">overwrite</span></span>   | <span data-ttu-id="01424-830">(**オプション**) true または false。</span><span class="sxs-lookup"><span data-stu-id="01424-830">(**optional**) True of false.</span></span> <span data-ttu-id="01424-831">これは、*maxdumpcount*で指定されているダンプ カウンターの制限に達した場合に古いダンプを上書きするかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="01424-831">This indicates whether or not to overwrite old dumps when the dump counter limit specified by *maxdumpcount* has been reached.</span></span> |

**<span data-ttu-id="01424-832">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-832">Request headers</span></span>**

- <span data-ttu-id="01424-833">なし</span><span class="sxs-lookup"><span data-stu-id="01424-833">None</span></span>

**<span data-ttu-id="01424-834">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-834">Request body</span></span>**

- <span data-ttu-id="01424-835">なし</span><span class="sxs-lookup"><span data-stu-id="01424-835">None</span></span>

**<span data-ttu-id="01424-836">応答</span><span class="sxs-lookup"><span data-stu-id="01424-836">Response</span></span>**

**<span data-ttu-id="01424-837">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-837">Status code</span></span>**

<span data-ttu-id="01424-838">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-838">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-839">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-839">HTTP status code</span></span>      | <span data-ttu-id="01424-840">説明</span><span class="sxs-lookup"><span data-stu-id="01424-840">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-841">200</span><span class="sxs-lookup"><span data-stu-id="01424-841">200</span></span> | <span data-ttu-id="01424-842">OK</span><span class="sxs-lookup"><span data-stu-id="01424-842">OK</span></span> | 
| <span data-ttu-id="01424-843">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-843">4XX</span></span> | <span data-ttu-id="01424-844">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-844">Error codes</span></span> |
| <span data-ttu-id="01424-845">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-845">5XX</span></span> | <span data-ttu-id="01424-846">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-846">Error codes</span></span> |

**<span data-ttu-id="01424-847">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-847">Available device families</span></span>**

* <span data-ttu-id="01424-848">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-848">Windows Desktop</span></span>
* <span data-ttu-id="01424-849">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-849">IoT</span></span>

<hr>
## <span data-ttu-id="01424-850">ETW</span><span class="sxs-lookup"><span data-stu-id="01424-850">ETW</span></span>
<hr>
### <span data-ttu-id="01424-851">websocket 経由でリアルタイムの ETW セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="01424-851">Create a realtime ETW session over a websocket</span></span>

**<span data-ttu-id="01424-852">要求</span><span class="sxs-lookup"><span data-stu-id="01424-852">Request</span></span>**

<span data-ttu-id="01424-853">次の要求形式を使用して、リアルタイムの ETW セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="01424-853">You can create a realtime ETW session by using the following request format.</span></span> <span data-ttu-id="01424-854">これは、websocket 経由で管理されます。</span><span class="sxs-lookup"><span data-stu-id="01424-854">This will be managed over a websocket.</span></span>  <span data-ttu-id="01424-855">ETW イベントは、サーバーで一括処理され、1 秒に 1 回クライアントに送信されます。</span><span class="sxs-lookup"><span data-stu-id="01424-855">ETW events are batched on the server and sent to the client once per second.</span></span> 
 
| <span data-ttu-id="01424-856">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-856">Method</span></span>      | <span data-ttu-id="01424-857">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-857">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-858">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="01424-858">GET/WebSocket</span></span> | <span data-ttu-id="01424-859">/api/etw/session/realtime</span><span class="sxs-lookup"><span data-stu-id="01424-859">/api/etw/session/realtime</span></span> |


**<span data-ttu-id="01424-860">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-860">URI parameters</span></span>**

- <span data-ttu-id="01424-861">なし</span><span class="sxs-lookup"><span data-stu-id="01424-861">None</span></span>

**<span data-ttu-id="01424-862">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-862">Request headers</span></span>**

- <span data-ttu-id="01424-863">なし</span><span class="sxs-lookup"><span data-stu-id="01424-863">None</span></span>

**<span data-ttu-id="01424-864">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-864">Request body</span></span>**

- <span data-ttu-id="01424-865">なし</span><span class="sxs-lookup"><span data-stu-id="01424-865">None</span></span>

**<span data-ttu-id="01424-866">応答</span><span class="sxs-lookup"><span data-stu-id="01424-866">Response</span></span>**

<span data-ttu-id="01424-867">応答には、有効なプロバイダーの ETW イベントが含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-867">The response includes the ETW events from the enabled providers.</span></span>  <span data-ttu-id="01424-868">以下の「ETW WebSocket コマンド」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="01424-868">See ETW WebSocket commands below.</span></span> 

**<span data-ttu-id="01424-869">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-869">Status code</span></span>**

<span data-ttu-id="01424-870">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-870">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-871">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-871">HTTP status code</span></span>      | <span data-ttu-id="01424-872">説明</span><span class="sxs-lookup"><span data-stu-id="01424-872">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-873">200</span><span class="sxs-lookup"><span data-stu-id="01424-873">200</span></span> | <span data-ttu-id="01424-874">OK</span><span class="sxs-lookup"><span data-stu-id="01424-874">OK</span></span> | 
| <span data-ttu-id="01424-875">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-875">4XX</span></span> | <span data-ttu-id="01424-876">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-876">Error codes</span></span> |
| <span data-ttu-id="01424-877">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-877">5XX</span></span> | <span data-ttu-id="01424-878">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-878">Error codes</span></span> |

**<span data-ttu-id="01424-879">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-879">Available device families</span></span>**

* <span data-ttu-id="01424-880">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-880">Windows Mobile</span></span>
* <span data-ttu-id="01424-881">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-881">Windows Desktop</span></span>
* <span data-ttu-id="01424-882">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-882">HoloLens</span></span>
* <span data-ttu-id="01424-883">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-883">IoT</span></span>

### <a name="etw-websocket-commands"></a><span data-ttu-id="01424-884">ETW WebSocket コマンド</span><span class="sxs-lookup"><span data-stu-id="01424-884">ETW WebSocket commands</span></span>
<span data-ttu-id="01424-885">次のコマンドは、クライアントからサーバーに送信されます。</span><span class="sxs-lookup"><span data-stu-id="01424-885">These commands are sent from the client to the server.</span></span>

| <span data-ttu-id="01424-886">コマンド</span><span class="sxs-lookup"><span data-stu-id="01424-886">Command</span></span> | <span data-ttu-id="01424-887">説明</span><span class="sxs-lookup"><span data-stu-id="01424-887">Description</span></span> |
| :----- | :----- |
| <span data-ttu-id="01424-888">provider *{guid}* enable *{level}*</span><span class="sxs-lookup"><span data-stu-id="01424-888">provider *{guid}* enable *{level}*</span></span> | <span data-ttu-id="01424-889">*{guid}* で指定されたプロバイダー (括弧は不要) を指定されたレベルで有効にします。</span><span class="sxs-lookup"><span data-stu-id="01424-889">Enable the provider marked by *{guid}* (without brackets) at the specified level.</span></span> <span data-ttu-id="01424-890">*{level}* は、1 (最小限の詳細) ～ 5 (詳細) の **int** です。</span><span class="sxs-lookup"><span data-stu-id="01424-890">*{level}* is an **int** from 1 (least detail) to 5 (verbose).</span></span> |
| <span data-ttu-id="01424-891">provider *{guid}* disable</span><span class="sxs-lookup"><span data-stu-id="01424-891">provider *{guid}* disable</span></span> | <span data-ttu-id="01424-892">*{guid}* で指定されたプロバイダー (括弧は不要) を無効にします。</span><span class="sxs-lookup"><span data-stu-id="01424-892">Disable the provider marked by *{guid}* (without brackets).</span></span> |

<span data-ttu-id="01424-893">この応答は、サーバーからクライアントに送信されます。</span><span class="sxs-lookup"><span data-stu-id="01424-893">This responses is sent from the server to the client.</span></span> <span data-ttu-id="01424-894">これは、テキストとして送信され、JSON で解析すると次の形式になります。</span><span class="sxs-lookup"><span data-stu-id="01424-894">This is sent as text and you get the following format by parsing the JSON.</span></span>
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

<span data-ttu-id="01424-895">payload objects は、追加のキーと値のペア (文字列: 文字列) で、元の ETW イベントから提供されます。</span><span class="sxs-lookup"><span data-stu-id="01424-895">Payload objects are extra key-value pairs (string:string) that are provided in the original ETW event.</span></span>

<span data-ttu-id="01424-896">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="01424-896">Example:</span></span>
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
### <span data-ttu-id="01424-897">登録済みの ETW プロバイダーを列挙する</span><span class="sxs-lookup"><span data-stu-id="01424-897">Enumerate the registered ETW providers</span></span>

**<span data-ttu-id="01424-898">要求</span><span class="sxs-lookup"><span data-stu-id="01424-898">Request</span></span>**

<span data-ttu-id="01424-899">次の要求形式を使用して、登録済みプロバイダーを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="01424-899">You can enumerate through the registered providers by using the following request format.</span></span>
 
| <span data-ttu-id="01424-900">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-900">Method</span></span>      | <span data-ttu-id="01424-901">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-901">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-902">GET</span><span class="sxs-lookup"><span data-stu-id="01424-902">GET</span></span> | <span data-ttu-id="01424-903">/api/etw/providers</span><span class="sxs-lookup"><span data-stu-id="01424-903">/api/etw/providers</span></span> |


**<span data-ttu-id="01424-904">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-904">URI parameters</span></span>**

- <span data-ttu-id="01424-905">なし</span><span class="sxs-lookup"><span data-stu-id="01424-905">None</span></span>

**<span data-ttu-id="01424-906">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-906">Request headers</span></span>**

- <span data-ttu-id="01424-907">なし</span><span class="sxs-lookup"><span data-stu-id="01424-907">None</span></span>

**<span data-ttu-id="01424-908">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-908">Request body</span></span>**

- <span data-ttu-id="01424-909">なし</span><span class="sxs-lookup"><span data-stu-id="01424-909">None</span></span>

**<span data-ttu-id="01424-910">応答</span><span class="sxs-lookup"><span data-stu-id="01424-910">Response</span></span>**

<span data-ttu-id="01424-911">応答には、ETW プロバイダーの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-911">The response includes the list of ETW providers.</span></span> <span data-ttu-id="01424-912">一覧には、各プロバイダーのフレンドリ名と GUID が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-912">The list will include the friendly name and GUID for each provider in the following format.</span></span>
```json
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

**<span data-ttu-id="01424-913">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-913">Status code</span></span>**

<span data-ttu-id="01424-914">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-914">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-915">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-915">HTTP status code</span></span>      | <span data-ttu-id="01424-916">説明</span><span class="sxs-lookup"><span data-stu-id="01424-916">Description</span></span> | 
| :------     | :----- |
|  <span data-ttu-id="01424-917">200</span><span class="sxs-lookup"><span data-stu-id="01424-917">200</span></span> | <span data-ttu-id="01424-918">OK</span><span class="sxs-lookup"><span data-stu-id="01424-918">OK</span></span> | 

**<span data-ttu-id="01424-919">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-919">Available device families</span></span>**

* <span data-ttu-id="01424-920">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-920">Windows Mobile</span></span>
* <span data-ttu-id="01424-921">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-921">Windows Desktop</span></span>
* <span data-ttu-id="01424-922">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-922">HoloLens</span></span>
* <span data-ttu-id="01424-923">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-923">IoT</span></span>

<hr>
### <span data-ttu-id="01424-924">プラットフォームによって公開されているカスタム ETW プロバイダーを列挙します。</span><span class="sxs-lookup"><span data-stu-id="01424-924">Enumerate the custom ETW providers exposed by the platform.</span></span>

**<span data-ttu-id="01424-925">要求</span><span class="sxs-lookup"><span data-stu-id="01424-925">Request</span></span>**

<span data-ttu-id="01424-926">次の要求形式を使用して、登録済みプロバイダーを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="01424-926">You can enumerate through the registered providers by using the following request format.</span></span>
 
| <span data-ttu-id="01424-927">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-927">Method</span></span>      | <span data-ttu-id="01424-928">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-928">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-929">GET</span><span class="sxs-lookup"><span data-stu-id="01424-929">GET</span></span> | <span data-ttu-id="01424-930">/api/etw/customproviders</span><span class="sxs-lookup"><span data-stu-id="01424-930">/api/etw/customproviders</span></span> |


**<span data-ttu-id="01424-931">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-931">URI parameters</span></span>**

- <span data-ttu-id="01424-932">なし</span><span class="sxs-lookup"><span data-stu-id="01424-932">None</span></span>

**<span data-ttu-id="01424-933">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-933">Request headers</span></span>**

- <span data-ttu-id="01424-934">なし</span><span class="sxs-lookup"><span data-stu-id="01424-934">None</span></span>

**<span data-ttu-id="01424-935">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-935">Request body</span></span>**

- <span data-ttu-id="01424-936">なし</span><span class="sxs-lookup"><span data-stu-id="01424-936">None</span></span>

**<span data-ttu-id="01424-937">応答</span><span class="sxs-lookup"><span data-stu-id="01424-937">Response</span></span>**

<span data-ttu-id="01424-938">200 OK。</span><span class="sxs-lookup"><span data-stu-id="01424-938">200 OK.</span></span> <span data-ttu-id="01424-939">応答には、ETW プロバイダーの一覧が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-939">The response includes the list of ETW providers.</span></span> <span data-ttu-id="01424-940">一覧には、各プロバイダーのフレンドリ名と GUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-940">The list will include the friendly name and GUID for each provider.</span></span>

```json
{"Providers": [
    {
        "GUID": string, (GUID)
        "Name": string
    },...
]}
```

**<span data-ttu-id="01424-941">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-941">Status code</span></span>**

- <span data-ttu-id="01424-942">標準の状態コード。</span><span class="sxs-lookup"><span data-stu-id="01424-942">Standard status codes.</span></span>

**<span data-ttu-id="01424-943">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-943">Available device families</span></span>**

* <span data-ttu-id="01424-944">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-944">Windows Mobile</span></span>
* <span data-ttu-id="01424-945">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-945">Windows Desktop</span></span>
* <span data-ttu-id="01424-946">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-946">HoloLens</span></span>
* <span data-ttu-id="01424-947">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-947">IoT</span></span>

<hr>
## <span data-ttu-id="01424-948">Location</span><span class="sxs-lookup"><span data-stu-id="01424-948">Location</span></span>
<hr>

### <a name="get-location-override-mode"></a><span data-ttu-id="01424-949">場所の上書きモードを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-949">Get location override mode</span></span>

**<span data-ttu-id="01424-950">要求</span><span class="sxs-lookup"><span data-stu-id="01424-950">Request</span></span>**

<span data-ttu-id="01424-951">次の要求型式を使用して、デバイスの場所スタック上書き状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-951">You can get the device's location stack override status by using the following request format.</span></span> <span data-ttu-id="01424-952">この呼び出しを成功させるには、開発者モードを有効にしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-952">Developer mode must be on for this call to succeed.</span></span>
 
| <span data-ttu-id="01424-953">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-953">Method</span></span>      | <span data-ttu-id="01424-954">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-954">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-955">GET</span><span class="sxs-lookup"><span data-stu-id="01424-955">GET</span></span> | <span data-ttu-id="01424-956">/ext/location/override</span><span class="sxs-lookup"><span data-stu-id="01424-956">/ext/location/override</span></span> |


**<span data-ttu-id="01424-957">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-957">URI parameters</span></span>**

- <span data-ttu-id="01424-958">なし</span><span class="sxs-lookup"><span data-stu-id="01424-958">None</span></span>

**<span data-ttu-id="01424-959">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-959">Request headers</span></span>**

- <span data-ttu-id="01424-960">なし</span><span class="sxs-lookup"><span data-stu-id="01424-960">None</span></span>

**<span data-ttu-id="01424-961">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-961">Request body</span></span>**

- <span data-ttu-id="01424-962">なし</span><span class="sxs-lookup"><span data-stu-id="01424-962">None</span></span>

**<span data-ttu-id="01424-963">応答</span><span class="sxs-lookup"><span data-stu-id="01424-963">Response</span></span>**

<span data-ttu-id="01424-964">応答には、デバイスの上書き状態が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-964">The response includes the override state of the device in the following format.</span></span> 

```json
{"Override" : bool}
```

**<span data-ttu-id="01424-965">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-965">Status code</span></span>**

<span data-ttu-id="01424-966">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-966">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-967">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-967">HTTP status code</span></span>      | <span data-ttu-id="01424-968">説明</span><span class="sxs-lookup"><span data-stu-id="01424-968">Description</span></span> |
| :------     | :----- |
|  <span data-ttu-id="01424-969">200</span><span class="sxs-lookup"><span data-stu-id="01424-969">200</span></span> | <span data-ttu-id="01424-970">OK</span><span class="sxs-lookup"><span data-stu-id="01424-970">OK</span></span> | 
| <span data-ttu-id="01424-971">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-971">4XX</span></span> | <span data-ttu-id="01424-972">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-972">Error codes</span></span> |
| <span data-ttu-id="01424-973">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-973">5XX</span></span> | <span data-ttu-id="01424-974">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-974">Error codes</span></span> |

**<span data-ttu-id="01424-975">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-975">Available device families</span></span>**

* <span data-ttu-id="01424-976">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-976">Windows Mobile</span></span>
* <span data-ttu-id="01424-977">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-977">Windows Desktop</span></span>
* <span data-ttu-id="01424-978">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-978">Xbox</span></span>
* <span data-ttu-id="01424-979">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-979">HoloLens</span></span>
* <span data-ttu-id="01424-980">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-980">IoT</span></span>

### <a name="set-location-override-mode"></a><span data-ttu-id="01424-981">場所の上書きモードを設定する</span><span class="sxs-lookup"><span data-stu-id="01424-981">Set location override mode</span></span>

**<span data-ttu-id="01424-982">要求</span><span class="sxs-lookup"><span data-stu-id="01424-982">Request</span></span>**

<span data-ttu-id="01424-983">次の要求型式を使用して、デバイスの場所スタック上書き状態を設定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-983">You can set the device's location stack override status by using the following request format.</span></span> <span data-ttu-id="01424-984">有効になっている場合は、場所スタックによって位置挿入が許可されます。</span><span class="sxs-lookup"><span data-stu-id="01424-984">When enabled, the location stack allows position injection.</span></span> <span data-ttu-id="01424-985">この呼び出しを成功させるには、開発者モードを有効にしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-985">Developer mode must be on for this call to succeed.</span></span>

| <span data-ttu-id="01424-986">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-986">Method</span></span>      | <span data-ttu-id="01424-987">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-987">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-988">PUT</span><span class="sxs-lookup"><span data-stu-id="01424-988">PUT</span></span> | <span data-ttu-id="01424-989">/ext/location/override</span><span class="sxs-lookup"><span data-stu-id="01424-989">/ext/location/override</span></span> |


**<span data-ttu-id="01424-990">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-990">URI parameters</span></span>**

- <span data-ttu-id="01424-991">なし</span><span class="sxs-lookup"><span data-stu-id="01424-991">None</span></span>

**<span data-ttu-id="01424-992">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-992">Request headers</span></span>**

- <span data-ttu-id="01424-993">なし</span><span class="sxs-lookup"><span data-stu-id="01424-993">None</span></span>

**<span data-ttu-id="01424-994">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-994">Request body</span></span>**

```json
{"Override" : bool}
```

**<span data-ttu-id="01424-995">応答</span><span class="sxs-lookup"><span data-stu-id="01424-995">Response</span></span>**

<span data-ttu-id="01424-996">応答には、デバイスに設定されている上書き状態が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-996">The response includes the override state that the device has been set to in the following format.</span></span> 

```json
{"Override" : bool}
```

**<span data-ttu-id="01424-997">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-997">Status code</span></span>**

<span data-ttu-id="01424-998">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-998">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-999">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-999">HTTP status code</span></span>      | <span data-ttu-id="01424-1000">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1000">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1001">200</span><span class="sxs-lookup"><span data-stu-id="01424-1001">200</span></span> | <span data-ttu-id="01424-1002">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1002">OK</span></span> |
| <span data-ttu-id="01424-1003">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1003">4XX</span></span> | <span data-ttu-id="01424-1004">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1004">Error codes</span></span> |
| <span data-ttu-id="01424-1005">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1005">5XX</span></span> | <span data-ttu-id="01424-1006">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1006">Error codes</span></span> |

**<span data-ttu-id="01424-1007">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1007">Available device families</span></span>**

* <span data-ttu-id="01424-1008">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1008">Windows Mobile</span></span>
* <span data-ttu-id="01424-1009">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1009">Windows Desktop</span></span>
* <span data-ttu-id="01424-1010">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1010">Xbox</span></span>
* <span data-ttu-id="01424-1011">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1011">HoloLens</span></span>
* <span data-ttu-id="01424-1012">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1012">IoT</span></span>

### <a name="get-the-injected-position"></a><span data-ttu-id="01424-1013">挿入された位置を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1013">Get the injected position</span></span>

**<span data-ttu-id="01424-1014">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1014">Request</span></span>**

<span data-ttu-id="01424-1015">次の要求型式を使用して、デバイスの挿入 (スプーフィング) された場所を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1015">You can get the device's injected (spoofed) location by using the following request format.</span></span> <span data-ttu-id="01424-1016">挿入された場所を設定する必要があります。設定されなかった場合は、エラーがスローされます。</span><span class="sxs-lookup"><span data-stu-id="01424-1016">An injected location must be set, or an error will be thrown.</span></span>
 
| <span data-ttu-id="01424-1017">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1017">Method</span></span>      | <span data-ttu-id="01424-1018">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1018">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1019">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1019">GET</span></span> | <span data-ttu-id="01424-1020">/ext/location/position</span><span class="sxs-lookup"><span data-stu-id="01424-1020">/ext/location/position</span></span> |


**<span data-ttu-id="01424-1021">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1021">URI parameters</span></span>**

- <span data-ttu-id="01424-1022">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1022">None</span></span>

**<span data-ttu-id="01424-1023">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1023">Request headers</span></span>**

- <span data-ttu-id="01424-1024">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1024">None</span></span>

**<span data-ttu-id="01424-1025">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1025">Request body</span></span>**

- <span data-ttu-id="01424-1026">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1026">None</span></span>

**<span data-ttu-id="01424-1027">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1027">Response</span></span>**

<span data-ttu-id="01424-1028">応答には、現在の挿入された緯度と経度の値が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1028">The response includes the current injected latitude and longitude values in the following format.</span></span> 

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

**<span data-ttu-id="01424-1029">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1029">Status code</span></span>**

<span data-ttu-id="01424-1030">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1030">This API has the following expected status codes.</span></span>

|  <span data-ttu-id="01424-1031">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1031">HTTP status code</span></span>      | <span data-ttu-id="01424-1032">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1032">Description</span></span> | 
| :------     | :----- |
| <span data-ttu-id="01424-1033">200</span><span class="sxs-lookup"><span data-stu-id="01424-1033">200</span></span> | <span data-ttu-id="01424-1034">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1034">OK</span></span> |
| <span data-ttu-id="01424-1035">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1035">4XX</span></span> | <span data-ttu-id="01424-1036">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1036">Error codes</span></span> |
| <span data-ttu-id="01424-1037">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1037">5XX</span></span> | <span data-ttu-id="01424-1038">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1038">Error codes</span></span> |

**<span data-ttu-id="01424-1039">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1039">Available device families</span></span>**

* <span data-ttu-id="01424-1040">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1040">Windows Mobile</span></span>
* <span data-ttu-id="01424-1041">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1041">Windows Desktop</span></span>
* <span data-ttu-id="01424-1042">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1042">Xbox</span></span>
* <span data-ttu-id="01424-1043">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1043">HoloLens</span></span>
* <span data-ttu-id="01424-1044">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1044">IoT</span></span>

### <a name="set-the-injected-position"></a><span data-ttu-id="01424-1045">挿入された位置を設定する</span><span class="sxs-lookup"><span data-stu-id="01424-1045">Set the injected position</span></span>

**<span data-ttu-id="01424-1046">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1046">Request</span></span>**

<span data-ttu-id="01424-1047">次の要求型式を使用して、デバイスの挿入 (スプーフィング) された場所を設定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1047">You can set the device's injected (spoofed) location by using the following request format.</span></span> <span data-ttu-id="01424-1048">あらかじめデバイス上で場所の上書きモードが有効になっており、設定される場所も有効である必要があります。それ以外の場合はエラーがスローされます。</span><span class="sxs-lookup"><span data-stu-id="01424-1048">Location override mode must first be enabled on the device, and the set location must be a valid location or an error will be thrown.</span></span>

| <span data-ttu-id="01424-1049">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1049">Method</span></span>      | <span data-ttu-id="01424-1050">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1050">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1051">PUT</span><span class="sxs-lookup"><span data-stu-id="01424-1051">PUT</span></span> | <span data-ttu-id="01424-1052">/ext/location/override</span><span class="sxs-lookup"><span data-stu-id="01424-1052">/ext/location/override</span></span> |


**<span data-ttu-id="01424-1053">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1053">URI parameters</span></span>**

- <span data-ttu-id="01424-1054">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1054">None</span></span>

**<span data-ttu-id="01424-1055">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1055">Request headers</span></span>**

- <span data-ttu-id="01424-1056">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1056">None</span></span>

**<span data-ttu-id="01424-1057">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1057">Request body</span></span>**

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

**<span data-ttu-id="01424-1058">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1058">Response</span></span>**

<span data-ttu-id="01424-1059">応答には、設定された場所の情報が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1059">The response includes the location that has been set in the following format.</span></span> 

```json
{
    "Latitude" : double,
    "Longitude" : double
}
```

**<span data-ttu-id="01424-1060">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1060">Status code</span></span>**

<span data-ttu-id="01424-1061">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1061">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1062">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1062">HTTP status code</span></span>      | <span data-ttu-id="01424-1063">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1063">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1064">200</span><span class="sxs-lookup"><span data-stu-id="01424-1064">200</span></span> | <span data-ttu-id="01424-1065">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1065">OK</span></span> |
| <span data-ttu-id="01424-1066">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1066">4XX</span></span> | <span data-ttu-id="01424-1067">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1067">Error codes</span></span> |
| <span data-ttu-id="01424-1068">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1068">5XX</span></span> | <span data-ttu-id="01424-1069">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1069">Error codes</span></span> |

**<span data-ttu-id="01424-1070">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1070">Available device families</span></span>**

* <span data-ttu-id="01424-1071">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1071">Windows Mobile</span></span>
* <span data-ttu-id="01424-1072">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1072">Windows Desktop</span></span>
* <span data-ttu-id="01424-1073">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1073">Xbox</span></span>
* <span data-ttu-id="01424-1074">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1074">HoloLens</span></span>
* <span data-ttu-id="01424-1075">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1075">IoT</span></span>

<hr>
## <span data-ttu-id="01424-1076">OS 情報</span><span class="sxs-lookup"><span data-stu-id="01424-1076">OS information</span></span>
<hr>
### <span data-ttu-id="01424-1077">コンピューター名を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1077">Get the machine name</span></span>

**<span data-ttu-id="01424-1078">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1078">Request</span></span>**

<span data-ttu-id="01424-1079">次の要求形式を使用して、コンピューターの名前を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1079">You can get the name of a machine by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1080">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1080">Method</span></span>      | <span data-ttu-id="01424-1081">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1081">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1082">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1082">GET</span></span> | <span data-ttu-id="01424-1083">/api/os/machinename</span><span class="sxs-lookup"><span data-stu-id="01424-1083">/api/os/machinename</span></span> |


**<span data-ttu-id="01424-1084">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1084">URI parameters</span></span>**

- <span data-ttu-id="01424-1085">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1085">None</span></span>

**<span data-ttu-id="01424-1086">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1086">Request headers</span></span>**

- <span data-ttu-id="01424-1087">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1087">None</span></span>

**<span data-ttu-id="01424-1088">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1088">Request body</span></span>**

- <span data-ttu-id="01424-1089">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1089">None</span></span>

**<span data-ttu-id="01424-1090">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1090">Response</span></span>**

<span data-ttu-id="01424-1091">応答には、コンピューター名が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1091">The response includes the computer name in the following format.</span></span> 

```json
{"ComputerName": string}
```

**<span data-ttu-id="01424-1092">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1092">Status code</span></span>**

<span data-ttu-id="01424-1093">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1093">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1094">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1094">HTTP status code</span></span>      | <span data-ttu-id="01424-1095">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1095">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1096">200</span><span class="sxs-lookup"><span data-stu-id="01424-1096">200</span></span> | <span data-ttu-id="01424-1097">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1097">OK</span></span> |
| <span data-ttu-id="01424-1098">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1098">4XX</span></span> | <span data-ttu-id="01424-1099">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1099">Error codes</span></span> |
| <span data-ttu-id="01424-1100">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1100">5XX</span></span> | <span data-ttu-id="01424-1101">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1101">Error codes</span></span> |

**<span data-ttu-id="01424-1102">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1102">Available device families</span></span>**

* <span data-ttu-id="01424-1103">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1103">Windows Mobile</span></span>
* <span data-ttu-id="01424-1104">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1104">Windows Desktop</span></span>
* <span data-ttu-id="01424-1105">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1105">Xbox</span></span>
* <span data-ttu-id="01424-1106">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1106">HoloLens</span></span>
* <span data-ttu-id="01424-1107">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1107">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1108">オペレーティング システムの情報を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1108">Get the operating system information</span></span>

**<span data-ttu-id="01424-1109">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1109">Request</span></span>**

<span data-ttu-id="01424-1110">次の要求形式を使用して、コンピューターの OS 情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1110">You can get the OS information for a machine by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1111">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1111">Method</span></span>      | <span data-ttu-id="01424-1112">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1112">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1113">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1113">GET</span></span> | <span data-ttu-id="01424-1114">/api/os/info</span><span class="sxs-lookup"><span data-stu-id="01424-1114">/api/os/info</span></span> |


**<span data-ttu-id="01424-1115">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1115">URI parameters</span></span>**

- <span data-ttu-id="01424-1116">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1116">None</span></span>

**<span data-ttu-id="01424-1117">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1117">Request headers</span></span>**

- <span data-ttu-id="01424-1118">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1118">None</span></span>

**<span data-ttu-id="01424-1119">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1119">Request body</span></span>**

- <span data-ttu-id="01424-1120">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1120">None</span></span>

**<span data-ttu-id="01424-1121">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1121">Response</span></span>**

<span data-ttu-id="01424-1122">応答には、OS 情報が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1122">The response includes the OS information in the following format.</span></span>

```json
{
    "ComputerName": string,
    "OsEdition": string,
    "OsEditionId": int,
    "OsVersion": string,
    "Platform": string
}
```

**<span data-ttu-id="01424-1123">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1123">Status code</span></span>**

<span data-ttu-id="01424-1124">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1124">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1125">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1125">HTTP status code</span></span>      | <span data-ttu-id="01424-1126">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1126">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1127">200</span><span class="sxs-lookup"><span data-stu-id="01424-1127">200</span></span> | <span data-ttu-id="01424-1128">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1128">OK</span></span> |
| <span data-ttu-id="01424-1129">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1129">4XX</span></span> | <span data-ttu-id="01424-1130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1130">Error codes</span></span> |
| <span data-ttu-id="01424-1131">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1131">5XX</span></span> | <span data-ttu-id="01424-1132">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1132">Error codes</span></span> |

**<span data-ttu-id="01424-1133">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1133">Available device families</span></span>**

* <span data-ttu-id="01424-1134">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1134">Windows Mobile</span></span>
* <span data-ttu-id="01424-1135">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1135">Windows Desktop</span></span>
* <span data-ttu-id="01424-1136">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1136">Xbox</span></span>
* <span data-ttu-id="01424-1137">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1137">HoloLens</span></span>
* <span data-ttu-id="01424-1138">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1138">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1139">デバイス ファミリを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1139">Get the device family</span></span> 

**<span data-ttu-id="01424-1140">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1140">Request</span></span>**

<span data-ttu-id="01424-1141">次の要求形式を使用して、デバイス ファミリ (Xbox、携帯電話、デスクトップなど) を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1141">You can get the device family (Xbox, phone, desktop, etc) using the following request format.</span></span>
 
| <span data-ttu-id="01424-1142">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1142">Method</span></span>      | <span data-ttu-id="01424-1143">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1143">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1144">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1144">GET</span></span> | <span data-ttu-id="01424-1145">/api/os/devicefamily</span><span class="sxs-lookup"><span data-stu-id="01424-1145">/api/os/devicefamily</span></span> |


**<span data-ttu-id="01424-1146">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1146">URI parameters</span></span>**

- <span data-ttu-id="01424-1147">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1147">None</span></span>

**<span data-ttu-id="01424-1148">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1148">Request headers</span></span>**

- <span data-ttu-id="01424-1149">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1149">None</span></span>

**<span data-ttu-id="01424-1150">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1150">Request body</span></span>**

- <span data-ttu-id="01424-1151">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1151">None</span></span>

**<span data-ttu-id="01424-1152">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1152">Response</span></span>**

<span data-ttu-id="01424-1153">応答には、デバイス ファミリ (SKU - デスクトップ、Xbox など) が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1153">The response includes the device family (SKU - Desktop, Xbox, etc).</span></span>

```json
{
   "DeviceType" : string
}
```

<span data-ttu-id="01424-1154">DeviceType は、"Windows.Xbox"、"Windows.Desktop" などのようになります。</span><span class="sxs-lookup"><span data-stu-id="01424-1154">DeviceType will look like "Windows.Xbox", "Windows.Desktop", etc.</span></span> 

**<span data-ttu-id="01424-1155">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1155">Status code</span></span>**

<span data-ttu-id="01424-1156">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1156">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1157">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1157">HTTP status code</span></span>      | <span data-ttu-id="01424-1158">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1158">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1159">200</span><span class="sxs-lookup"><span data-stu-id="01424-1159">200</span></span> | <span data-ttu-id="01424-1160">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1160">OK</span></span> |
| <span data-ttu-id="01424-1161">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1161">4XX</span></span> | <span data-ttu-id="01424-1162">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1162">Error codes</span></span> |
| <span data-ttu-id="01424-1163">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1163">5XX</span></span> | <span data-ttu-id="01424-1164">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1164">Error codes</span></span> |

**<span data-ttu-id="01424-1165">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1165">Available device families</span></span>**

* <span data-ttu-id="01424-1166">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1166">Windows Mobile</span></span>
* <span data-ttu-id="01424-1167">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1167">Windows Desktop</span></span>
* <span data-ttu-id="01424-1168">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1168">Xbox</span></span>
* <span data-ttu-id="01424-1169">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1169">HoloLens</span></span>
* <span data-ttu-id="01424-1170">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1170">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1171">コンピューター名を設定する</span><span class="sxs-lookup"><span data-stu-id="01424-1171">Set the machine name</span></span>

**<span data-ttu-id="01424-1172">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1172">Request</span></span>**

<span data-ttu-id="01424-1173">次の要求形式を使用して、コンピューターの名前を設定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1173">You can set the name of a machine by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1174">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1174">Method</span></span>      | <span data-ttu-id="01424-1175">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1175">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1176">POST</span><span class="sxs-lookup"><span data-stu-id="01424-1176">POST</span></span> | <span data-ttu-id="01424-1177">/api/os/machinename</span><span class="sxs-lookup"><span data-stu-id="01424-1177">/api/os/machinename</span></span> |


**<span data-ttu-id="01424-1178">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1178">URI parameters</span></span>**

<span data-ttu-id="01424-1179">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1179">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1180">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1180">URI parameter</span></span> | <span data-ttu-id="01424-1181">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1181">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-1182">name</span><span class="sxs-lookup"><span data-stu-id="01424-1182">name</span></span> | <span data-ttu-id="01424-1183">(**必須**) コンピューターの新しい名前。</span><span class="sxs-lookup"><span data-stu-id="01424-1183">(**required**) The new name for the machine.</span></span> |

**<span data-ttu-id="01424-1184">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1184">Request headers</span></span>**

- <span data-ttu-id="01424-1185">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1185">None</span></span>

**<span data-ttu-id="01424-1186">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1186">Request body</span></span>**

- <span data-ttu-id="01424-1187">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1187">None</span></span>

**<span data-ttu-id="01424-1188">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1188">Response</span></span>**

**<span data-ttu-id="01424-1189">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1189">Status code</span></span>**

<span data-ttu-id="01424-1190">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1190">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1191">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1191">HTTP status code</span></span>      | <span data-ttu-id="01424-1192">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1192">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1193">200</span><span class="sxs-lookup"><span data-stu-id="01424-1193">200</span></span> | <span data-ttu-id="01424-1194">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1194">OK</span></span> |

**<span data-ttu-id="01424-1195">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1195">Available device families</span></span>**

* <span data-ttu-id="01424-1196">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1196">Windows Mobile</span></span>
* <span data-ttu-id="01424-1197">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1197">Windows Desktop</span></span>
* <span data-ttu-id="01424-1198">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1198">Xbox</span></span>
* <span data-ttu-id="01424-1199">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1199">HoloLens</span></span>
* <span data-ttu-id="01424-1200">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1200">IoT</span></span>

<hr>
## <span data-ttu-id="01424-1201">ユーザー情報</span><span class="sxs-lookup"><span data-stu-id="01424-1201">User information</span></span>
<hr>
### <span data-ttu-id="01424-1202">アクティブ ユーザーを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1202">Get the active user</span></span>

**<span data-ttu-id="01424-1203">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1203">Request</span></span>**

<span data-ttu-id="01424-1204">次の要求形式を使用して、デバイスのアクティブ ユーザーの名前を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1204">You can get the name of the active user on the device by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1205">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1205">Method</span></span>      | <span data-ttu-id="01424-1206">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1206">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1207">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1207">GET</span></span> | <span data-ttu-id="01424-1208">/api/users/activeuser</span><span class="sxs-lookup"><span data-stu-id="01424-1208">/api/users/activeuser</span></span> |


**<span data-ttu-id="01424-1209">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1209">URI parameters</span></span>**

- <span data-ttu-id="01424-1210">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1210">None</span></span>

**<span data-ttu-id="01424-1211">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1211">Request headers</span></span>**

- <span data-ttu-id="01424-1212">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1212">None</span></span>

**<span data-ttu-id="01424-1213">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1213">Request body</span></span>**

- <span data-ttu-id="01424-1214">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1214">None</span></span>

**<span data-ttu-id="01424-1215">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1215">Response</span></span>**

<span data-ttu-id="01424-1216">応答には、ユーザー情報が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1216">The response includes user information in the following format.</span></span> 

<span data-ttu-id="01424-1217">成功した場合:</span><span class="sxs-lookup"><span data-stu-id="01424-1217">On success:</span></span> 
```json
{
    "UserDisplayName" : string, 
    "UserSID" : string
}
```
<span data-ttu-id="01424-1218">失敗した場合:</span><span class="sxs-lookup"><span data-stu-id="01424-1218">On failure:</span></span>
```json
{
    "Code" : int, 
    "CodeText" : string, 
    "Reason" : string, 
    "Success" : bool
}
```

**<span data-ttu-id="01424-1219">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1219">Status code</span></span>**

<span data-ttu-id="01424-1220">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1220">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1221">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1221">HTTP status code</span></span>      | <span data-ttu-id="01424-1222">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1222">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1223">200</span><span class="sxs-lookup"><span data-stu-id="01424-1223">200</span></span> | <span data-ttu-id="01424-1224">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1224">OK</span></span> |
| <span data-ttu-id="01424-1225">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1225">4XX</span></span> | <span data-ttu-id="01424-1226">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1226">Error codes</span></span> |
| <span data-ttu-id="01424-1227">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1227">5XX</span></span> | <span data-ttu-id="01424-1228">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1228">Error codes</span></span> |

**<span data-ttu-id="01424-1229">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1229">Available device families</span></span>**

* <span data-ttu-id="01424-1230">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1230">Windows Desktop</span></span>
* <span data-ttu-id="01424-1231">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1231">HoloLens</span></span>
* <span data-ttu-id="01424-1232">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1232">IoT</span></span>

<hr>
## <span data-ttu-id="01424-1233">パフォーマンス データ</span><span class="sxs-lookup"><span data-stu-id="01424-1233">Performance data</span></span>
<hr>
### <span data-ttu-id="01424-1234">実行中のプロセスの一覧を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1234">Get the list of running processes</span></span>

**<span data-ttu-id="01424-1235">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1235">Request</span></span>**

<span data-ttu-id="01424-1236">次の要求形式を使用して、現在実行中のプロセスの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1236">You can get the list of currently running processes by using the following request format.</span></span>  <span data-ttu-id="01424-1237">これは、WebSocket 接続にアップグレードすることもでき、1 秒に 1 度クライアントにプッシュされる同じ JSON データを取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1237">this can be upgraded to a WebSocket connection as well, with the same JSON data being pushed to the client once per second.</span></span> 
 
| <span data-ttu-id="01424-1238">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1238">Method</span></span>      | <span data-ttu-id="01424-1239">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1239">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1240">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1240">GET</span></span> | <span data-ttu-id="01424-1241">/api/resourcemanager/processes</span><span class="sxs-lookup"><span data-stu-id="01424-1241">/api/resourcemanager/processes</span></span> |
| <span data-ttu-id="01424-1242">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="01424-1242">GET/WebSocket</span></span> | <span data-ttu-id="01424-1243">/api/resourcemanager/processes</span><span class="sxs-lookup"><span data-stu-id="01424-1243">/api/resourcemanager/processes</span></span> |


**<span data-ttu-id="01424-1244">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1244">URI parameters</span></span>**

- <span data-ttu-id="01424-1245">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1245">None</span></span>

**<span data-ttu-id="01424-1246">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1246">Request headers</span></span>**

- <span data-ttu-id="01424-1247">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1247">None</span></span>

**<span data-ttu-id="01424-1248">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1248">Request body</span></span>**

- <span data-ttu-id="01424-1249">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1249">None</span></span>

**<span data-ttu-id="01424-1250">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1250">Response</span></span>**

<span data-ttu-id="01424-1251">応答には、プロセスの一覧と各プロセスの詳細情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1251">The response includes a list of processes with details for each process.</span></span> <span data-ttu-id="01424-1252">情報は JSON 形式で、テンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-1252">The information is in JSON format and has the following template.</span></span>
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

**<span data-ttu-id="01424-1253">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1253">Status code</span></span>**

<span data-ttu-id="01424-1254">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1254">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1255">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1255">HTTP status code</span></span>      | <span data-ttu-id="01424-1256">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1256">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1257">200</span><span class="sxs-lookup"><span data-stu-id="01424-1257">200</span></span> | <span data-ttu-id="01424-1258">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1258">OK</span></span> |
| <span data-ttu-id="01424-1259">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1259">4XX</span></span> | <span data-ttu-id="01424-1260">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1260">Error codes</span></span> |
| <span data-ttu-id="01424-1261">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1261">5XX</span></span> | <span data-ttu-id="01424-1262">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1262">Error codes</span></span> |

**<span data-ttu-id="01424-1263">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1263">Available device families</span></span>**

* <span data-ttu-id="01424-1264">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1264">Windows Mobile</span></span>
* <span data-ttu-id="01424-1265">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1265">Windows Desktop</span></span>
* <span data-ttu-id="01424-1266">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1266">HoloLens</span></span>
* <span data-ttu-id="01424-1267">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1267">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1268">システム パフォーマンスの統計情報を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1268">Get the system performance statistics</span></span>

**<span data-ttu-id="01424-1269">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1269">Request</span></span>**

<span data-ttu-id="01424-1270">次の要求形式を使用して、システム パフォーマンスの統計情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1270">You can get the system performance statistics by using the following request format.</span></span> <span data-ttu-id="01424-1271">これには、読み取りと書き込みのサイクルや、使用されているメモリの量などの情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1271">This includes information such as read and write cycles and how much memory has been used.</span></span>
 
| <span data-ttu-id="01424-1272">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1272">Method</span></span>      | <span data-ttu-id="01424-1273">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1273">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1274">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1274">GET</span></span> | <span data-ttu-id="01424-1275">/api/resourcemanager/systemperf</span><span class="sxs-lookup"><span data-stu-id="01424-1275">/api/resourcemanager/systemperf</span></span> |
| <span data-ttu-id="01424-1276">GET/WebSocket</span><span class="sxs-lookup"><span data-stu-id="01424-1276">GET/WebSocket</span></span> | <span data-ttu-id="01424-1277">/api/resourcemanager/systemperf</span><span class="sxs-lookup"><span data-stu-id="01424-1277">/api/resourcemanager/systemperf</span></span> |

<span data-ttu-id="01424-1278">これは、WebSocket 接続にアップグレードできます。</span><span class="sxs-lookup"><span data-stu-id="01424-1278">This can also be upgraded to a WebSocket connection.</span></span>  <span data-ttu-id="01424-1279">1 秒に 1 度以下と同じ JSON データが提供されます。</span><span class="sxs-lookup"><span data-stu-id="01424-1279">It provides the same JSON data below once every second.</span></span> 

**<span data-ttu-id="01424-1280">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1280">URI parameters</span></span>**

- <span data-ttu-id="01424-1281">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1281">None</span></span>

**<span data-ttu-id="01424-1282">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1282">Request headers</span></span>**

- <span data-ttu-id="01424-1283">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1283">None</span></span>

**<span data-ttu-id="01424-1284">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1284">Request body</span></span>**

- <span data-ttu-id="01424-1285">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1285">None</span></span>

**<span data-ttu-id="01424-1286">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1286">Response</span></span>**

<span data-ttu-id="01424-1287">応答には、CPU と GPU の使用量、メモリ アクセス、ネットワーク アクセスなど、パフォーマンスの統計情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1287">The response includes the performance statistics for the system such as CPU and GPU usage, memory access, and network access.</span></span> <span data-ttu-id="01424-1288">この情報は JSON 形式で、テンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-1288">This information is in JSON format and has the following template.</span></span>
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

**<span data-ttu-id="01424-1289">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1289">Status code</span></span>**

<span data-ttu-id="01424-1290">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1290">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1291">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1291">HTTP status code</span></span>      | <span data-ttu-id="01424-1292">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1292">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1293">200</span><span class="sxs-lookup"><span data-stu-id="01424-1293">200</span></span> | <span data-ttu-id="01424-1294">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1294">OK</span></span> |
| <span data-ttu-id="01424-1295">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1295">4XX</span></span> | <span data-ttu-id="01424-1296">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1296">Error codes</span></span> |
| <span data-ttu-id="01424-1297">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1297">5XX</span></span> | <span data-ttu-id="01424-1298">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1298">Error codes</span></span> |

**<span data-ttu-id="01424-1299">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1299">Available device families</span></span>**

* <span data-ttu-id="01424-1300">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1300">Windows Mobile</span></span>
* <span data-ttu-id="01424-1301">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1301">Windows Desktop</span></span>
* <span data-ttu-id="01424-1302">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1302">Xbox</span></span>
* <span data-ttu-id="01424-1303">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1303">HoloLens</span></span>
* <span data-ttu-id="01424-1304">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1304">IoT</span></span>

<hr>
## <span data-ttu-id="01424-1305">Power</span><span class="sxs-lookup"><span data-stu-id="01424-1305">Power</span></span>
<hr>
### <span data-ttu-id="01424-1306">現在のバッテリ状態を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1306">Get the current battery state</span></span>

**<span data-ttu-id="01424-1307">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1307">Request</span></span>**

<span data-ttu-id="01424-1308">次の要求形式を使用して、バッテリの現在の状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1308">You can get the current state of the battery by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1309">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1309">Method</span></span>      | <span data-ttu-id="01424-1310">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1310">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1311">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1311">GET</span></span> | <span data-ttu-id="01424-1312">/api/power/battery</span><span class="sxs-lookup"><span data-stu-id="01424-1312">/api/power/battery</span></span> |


**<span data-ttu-id="01424-1313">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1313">URI parameters</span></span>**

- <span data-ttu-id="01424-1314">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1314">None</span></span>

**<span data-ttu-id="01424-1315">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1315">Request headers</span></span>**

- <span data-ttu-id="01424-1316">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1316">None</span></span>

**<span data-ttu-id="01424-1317">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1317">Request body</span></span>**

- <span data-ttu-id="01424-1318">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1318">None</span></span>

**<span data-ttu-id="01424-1319">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1319">Response</span></span>**

<span data-ttu-id="01424-1320">現在のバッテリ状態に関する情報が次の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="01424-1320">The current battery state information is returned using the following format.</span></span>
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

**<span data-ttu-id="01424-1321">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1321">Status code</span></span>**

<span data-ttu-id="01424-1322">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1322">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1323">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1323">HTTP status code</span></span>      | <span data-ttu-id="01424-1324">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1324">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1325">200</span><span class="sxs-lookup"><span data-stu-id="01424-1325">200</span></span> | <span data-ttu-id="01424-1326">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1326">OK</span></span> |
| <span data-ttu-id="01424-1327">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1327">4XX</span></span> | <span data-ttu-id="01424-1328">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1328">Error codes</span></span> |
| <span data-ttu-id="01424-1329">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1329">5XX</span></span> | <span data-ttu-id="01424-1330">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1330">Error codes</span></span> |

**<span data-ttu-id="01424-1331">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1331">Available device families</span></span>**

* <span data-ttu-id="01424-1332">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1332">Windows Mobile</span></span>
* <span data-ttu-id="01424-1333">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1333">Windows Desktop</span></span>
* <span data-ttu-id="01424-1334">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1334">HoloLens</span></span>
* <span data-ttu-id="01424-1335">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1335">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1336">アクティブな電源設定を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1336">Get the active power scheme</span></span>

**<span data-ttu-id="01424-1337">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1337">Request</span></span>**

<span data-ttu-id="01424-1338">次の要求形式を使用して、アクティブな電源設定を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1338">You can get the active power scheme by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1339">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1339">Method</span></span>      | <span data-ttu-id="01424-1340">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1340">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1341">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1341">GET</span></span> | <span data-ttu-id="01424-1342">/api/power/activecfg</span><span class="sxs-lookup"><span data-stu-id="01424-1342">/api/power/activecfg</span></span> |


**<span data-ttu-id="01424-1343">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1343">URI parameters</span></span>**

- <span data-ttu-id="01424-1344">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1344">None</span></span>

**<span data-ttu-id="01424-1345">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1345">Request headers</span></span>**

- <span data-ttu-id="01424-1346">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1346">None</span></span>

**<span data-ttu-id="01424-1347">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1347">Request body</span></span>**

- <span data-ttu-id="01424-1348">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1348">None</span></span>

**<span data-ttu-id="01424-1349">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1349">Response</span></span>**

<span data-ttu-id="01424-1350">アクティブな電源設定の形式は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-1350">The active power scheme has the following format.</span></span>
```json
{"ActivePowerScheme": string (guid of scheme)}
```

**<span data-ttu-id="01424-1351">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1351">Status code</span></span>**

<span data-ttu-id="01424-1352">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1352">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1353">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1353">HTTP status code</span></span>      | <span data-ttu-id="01424-1354">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1354">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1355">200</span><span class="sxs-lookup"><span data-stu-id="01424-1355">200</span></span> | <span data-ttu-id="01424-1356">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1356">OK</span></span> |
| <span data-ttu-id="01424-1357">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1357">4XX</span></span> | <span data-ttu-id="01424-1358">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1358">Error codes</span></span> |
| <span data-ttu-id="01424-1359">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1359">5XX</span></span> | <span data-ttu-id="01424-1360">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1360">Error codes</span></span> |

**<span data-ttu-id="01424-1361">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1361">Available device families</span></span>**

* <span data-ttu-id="01424-1362">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1362">Windows Desktop</span></span>
* <span data-ttu-id="01424-1363">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1363">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1364">電源設定のサブ値を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1364">Get the sub-value for a power scheme</span></span>

**<span data-ttu-id="01424-1365">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1365">Request</span></span>**

<span data-ttu-id="01424-1366">次の要求形式を使用して、電源設定のサブ値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1366">You can get the sub-value for a power scheme by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1367">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1367">Method</span></span>      | <span data-ttu-id="01424-1368">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1368">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1369">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1369">GET</span></span> | <span data-ttu-id="01424-1370">/api/power/cfg/*<power scheme path>*</span><span class="sxs-lookup"><span data-stu-id="01424-1370">/api/power/cfg/*<power scheme path>*</span></span> |

<span data-ttu-id="01424-1371">オプション:</span><span class="sxs-lookup"><span data-stu-id="01424-1371">Options:</span></span>
- <span data-ttu-id="01424-1372">SCHEME_CURRENT</span><span class="sxs-lookup"><span data-stu-id="01424-1372">SCHEME_CURRENT</span></span>

**<span data-ttu-id="01424-1373">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1373">URI parameters</span></span>**

- <span data-ttu-id="01424-1374">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1374">None</span></span>

**<span data-ttu-id="01424-1375">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1375">Request headers</span></span>**

- <span data-ttu-id="01424-1376">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1376">None</span></span>

**<span data-ttu-id="01424-1377">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1377">Request body</span></span>**

<span data-ttu-id="01424-1378">利用可能な電源状態の完全な一覧は、アプリケーションごとが基本で、バッテリ低下、重要なバッテリといったさまざまな電源状態がフラグ設定されています。</span><span class="sxs-lookup"><span data-stu-id="01424-1378">A full listing of power states available is on a per-application basis and the settings for flagging various power states like low and critical batterty.</span></span> 

**<span data-ttu-id="01424-1379">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1379">Response</span></span>**

**<span data-ttu-id="01424-1380">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1380">Status code</span></span>**

<span data-ttu-id="01424-1381">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1381">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1382">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1382">HTTP status code</span></span>      | <span data-ttu-id="01424-1383">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1383">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1384">200</span><span class="sxs-lookup"><span data-stu-id="01424-1384">200</span></span> | <span data-ttu-id="01424-1385">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1385">OK</span></span> |
| <span data-ttu-id="01424-1386">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1386">4XX</span></span> | <span data-ttu-id="01424-1387">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1387">Error codes</span></span> |
| <span data-ttu-id="01424-1388">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1388">5XX</span></span> | <span data-ttu-id="01424-1389">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1389">Error codes</span></span> |

**<span data-ttu-id="01424-1390">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1390">Available device families</span></span>**

* <span data-ttu-id="01424-1391">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1391">Windows Desktop</span></span>
* <span data-ttu-id="01424-1392">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1392">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1393">システムの電源状態を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1393">Get the power state of the system</span></span>

**<span data-ttu-id="01424-1394">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1394">Request</span></span>**

<span data-ttu-id="01424-1395">次の要求形式を使用して、システムの電源状態を確認できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1395">You can check the power state of the system by using the following request format.</span></span> <span data-ttu-id="01424-1396">これによって、低電力状態になっているかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1396">This will let you check to see if it is in a low power state.</span></span>
 
| <span data-ttu-id="01424-1397">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1397">Method</span></span>      | <span data-ttu-id="01424-1398">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1398">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1399">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1399">GET</span></span> | <span data-ttu-id="01424-1400">/api/power/state</span><span class="sxs-lookup"><span data-stu-id="01424-1400">/api/power/state</span></span> |


**<span data-ttu-id="01424-1401">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1401">URI parameters</span></span>**

- <span data-ttu-id="01424-1402">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1402">None</span></span>

**<span data-ttu-id="01424-1403">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1403">Request headers</span></span>**

- <span data-ttu-id="01424-1404">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1404">None</span></span>

**<span data-ttu-id="01424-1405">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1405">Request body</span></span>**

- <span data-ttu-id="01424-1406">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1406">None</span></span>

**<span data-ttu-id="01424-1407">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1407">Response</span></span>**

<span data-ttu-id="01424-1408">電源状態の情報のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-1408">The power state information has the following template.</span></span>
```json
{"LowPowerState" : false, "LowPowerStateAvailable" : true }
```

**<span data-ttu-id="01424-1409">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1409">Status code</span></span>**

<span data-ttu-id="01424-1410">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1410">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1411">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1411">HTTP status code</span></span>      | <span data-ttu-id="01424-1412">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1412">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1413">200</span><span class="sxs-lookup"><span data-stu-id="01424-1413">200</span></span> | <span data-ttu-id="01424-1414">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1414">OK</span></span> |
| <span data-ttu-id="01424-1415">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1415">4XX</span></span> | <span data-ttu-id="01424-1416">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1416">Error codes</span></span> |
| <span data-ttu-id="01424-1417">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1417">5XX</span></span> | <span data-ttu-id="01424-1418">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1418">Error codes</span></span> |

**<span data-ttu-id="01424-1419">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1419">Available device families</span></span>**

* <span data-ttu-id="01424-1420">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1420">Windows Desktop</span></span>
* <span data-ttu-id="01424-1421">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1421">HoloLens</span></span>
* <span data-ttu-id="01424-1422">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1422">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1423">アクティブな電源設定を行う</span><span class="sxs-lookup"><span data-stu-id="01424-1423">Set the active power scheme</span></span>

**<span data-ttu-id="01424-1424">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1424">Request</span></span>**

<span data-ttu-id="01424-1425">次の要求形式を使用して、アクティブな電源設定を設定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1425">You can set the active power scheme by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1426">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1426">Method</span></span>      | <span data-ttu-id="01424-1427">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1427">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1428">POST</span><span class="sxs-lookup"><span data-stu-id="01424-1428">POST</span></span> | <span data-ttu-id="01424-1429">/api/power/activecfg</span><span class="sxs-lookup"><span data-stu-id="01424-1429">/api/power/activecfg</span></span> |


**<span data-ttu-id="01424-1430">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1430">URI parameters</span></span>**

<span data-ttu-id="01424-1431">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1431">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1432">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1432">URI parameter</span></span> | <span data-ttu-id="01424-1433">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1433">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="01424-1434">scheme</span><span class="sxs-lookup"><span data-stu-id="01424-1434">scheme</span></span> | <span data-ttu-id="01424-1435">(**必須**) システムのアクティブな電源設定として設定するスキームの GUID。</span><span class="sxs-lookup"><span data-stu-id="01424-1435">(**required**) The GUID of the scheme you want to set as the active power scheme for the system.</span></span> |

**<span data-ttu-id="01424-1436">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1436">Request headers</span></span>**

- <span data-ttu-id="01424-1437">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1437">None</span></span>

**<span data-ttu-id="01424-1438">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1438">Request body</span></span>**

- <span data-ttu-id="01424-1439">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1439">None</span></span>

**<span data-ttu-id="01424-1440">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1440">Response</span></span>**

**<span data-ttu-id="01424-1441">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1441">Status code</span></span>**

<span data-ttu-id="01424-1442">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1442">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1443">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1443">HTTP status code</span></span>      | <span data-ttu-id="01424-1444">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1444">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1445">200</span><span class="sxs-lookup"><span data-stu-id="01424-1445">200</span></span> | <span data-ttu-id="01424-1446">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1446">OK</span></span> |
| <span data-ttu-id="01424-1447">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1447">4XX</span></span> | <span data-ttu-id="01424-1448">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1448">Error codes</span></span> |
| <span data-ttu-id="01424-1449">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1449">5XX</span></span> | <span data-ttu-id="01424-1450">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1450">Error codes</span></span> |

**<span data-ttu-id="01424-1451">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1451">Available device families</span></span>**

* <span data-ttu-id="01424-1452">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1452">Windows Desktop</span></span>
* <span data-ttu-id="01424-1453">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1453">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1454">電源設定のサブ値を設定する</span><span class="sxs-lookup"><span data-stu-id="01424-1454">Set the sub-value for a power scheme</span></span>

**<span data-ttu-id="01424-1455">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1455">Request</span></span>**

<span data-ttu-id="01424-1456">次の要求形式を使用して、電源設定のサブ値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1456">You can set the sub-value for a power scheme by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1457">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1457">Method</span></span>      | <span data-ttu-id="01424-1458">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1458">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1459">POST</span><span class="sxs-lookup"><span data-stu-id="01424-1459">POST</span></span> | <span data-ttu-id="01424-1460">/api/power/cfg/*<power scheme path>*</span><span class="sxs-lookup"><span data-stu-id="01424-1460">/api/power/cfg/*<power scheme path>*</span></span> |


**<span data-ttu-id="01424-1461">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1461">URI parameters</span></span>**

<span data-ttu-id="01424-1462">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1462">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1463">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1463">URI parameter</span></span> | <span data-ttu-id="01424-1464">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1464">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-1465">valueAC</span><span class="sxs-lookup"><span data-stu-id="01424-1465">valueAC</span></span> | <span data-ttu-id="01424-1466">(**必須**) AC 電源に使用する値。</span><span class="sxs-lookup"><span data-stu-id="01424-1466">(**required**) The value to use for A/C power.</span></span> |
| <span data-ttu-id="01424-1467">valueDC</span><span class="sxs-lookup"><span data-stu-id="01424-1467">valueDC</span></span> | <span data-ttu-id="01424-1468">(**必須**) バッテリ電源に使用する値。</span><span class="sxs-lookup"><span data-stu-id="01424-1468">(**required**) The value to use for battery power.</span></span> |

**<span data-ttu-id="01424-1469">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1469">Request headers</span></span>**

- <span data-ttu-id="01424-1470">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1470">None</span></span>

**<span data-ttu-id="01424-1471">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1471">Request body</span></span>**

- <span data-ttu-id="01424-1472">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1472">None</span></span>

**<span data-ttu-id="01424-1473">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1473">Response</span></span>**

**<span data-ttu-id="01424-1474">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1474">Status code</span></span>**

<span data-ttu-id="01424-1475">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1475">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1476">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1476">HTTP status code</span></span>      | <span data-ttu-id="01424-1477">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1477">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1478">200</span><span class="sxs-lookup"><span data-stu-id="01424-1478">200</span></span> | <span data-ttu-id="01424-1479">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1479">OK</span></span> |

**<span data-ttu-id="01424-1480">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1480">Available device families</span></span>**

* <span data-ttu-id="01424-1481">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1481">Windows Desktop</span></span>
* <span data-ttu-id="01424-1482">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1482">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1483">SleepStudy レポートを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1483">Get a sleep study report</span></span>

**<span data-ttu-id="01424-1484">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1484">Request</span></span>**

| <span data-ttu-id="01424-1485">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1485">Method</span></span>      | <span data-ttu-id="01424-1486">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1486">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1487">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1487">GET</span></span> | <span data-ttu-id="01424-1488">/api/power/sleepstudy/report</span><span class="sxs-lookup"><span data-stu-id="01424-1488">/api/power/sleepstudy/report</span></span> |

<span data-ttu-id="01424-1489">次の要求形式を使用して、SleepStudy レポートを取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1489">You can get a sleep study report by using the following request format.</span></span>

**<span data-ttu-id="01424-1490">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1490">URI parameters</span></span>**
| <span data-ttu-id="01424-1491">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1491">URI parameter</span></span> | <span data-ttu-id="01424-1492">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1492">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-1493">FileName</span><span class="sxs-lookup"><span data-stu-id="01424-1493">FileName</span></span> | <span data-ttu-id="01424-1494">(**必須**) ダウンロードするファイルの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="01424-1494">(**required**) The full name for the file you want to download.</span></span> <span data-ttu-id="01424-1495">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1495">This value should be hex64 encoded.</span></span> |

**<span data-ttu-id="01424-1496">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1496">Request headers</span></span>**

- <span data-ttu-id="01424-1497">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1497">None</span></span>

**<span data-ttu-id="01424-1498">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1498">Request body</span></span>**

- <span data-ttu-id="01424-1499">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1499">None</span></span>

**<span data-ttu-id="01424-1500">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1500">Response</span></span>**

<span data-ttu-id="01424-1501">応答は、スリープ検査の結果が含まれているファイルです。</span><span class="sxs-lookup"><span data-stu-id="01424-1501">The response is a file containing the sleep study.</span></span> 

**<span data-ttu-id="01424-1502">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1502">Status code</span></span>**

<span data-ttu-id="01424-1503">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1503">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1504">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1504">HTTP status code</span></span>      | <span data-ttu-id="01424-1505">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1505">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1506">200</span><span class="sxs-lookup"><span data-stu-id="01424-1506">200</span></span> | <span data-ttu-id="01424-1507">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1507">OK</span></span> |
| <span data-ttu-id="01424-1508">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1508">4XX</span></span> | <span data-ttu-id="01424-1509">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1509">Error codes</span></span> |
| <span data-ttu-id="01424-1510">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1510">5XX</span></span> | <span data-ttu-id="01424-1511">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1511">Error codes</span></span> |

**<span data-ttu-id="01424-1512">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1512">Available device families</span></span>**

* <span data-ttu-id="01424-1513">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1513">Windows Desktop</span></span>
* <span data-ttu-id="01424-1514">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1514">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1515">利用可能な SleepStudy レポートを列挙する</span><span class="sxs-lookup"><span data-stu-id="01424-1515">Enumerate the available sleep study reports</span></span>

**<span data-ttu-id="01424-1516">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1516">Request</span></span>**

<span data-ttu-id="01424-1517">次の要求形式を使用して、利用可能な SleepStudy レポートを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1517">You can enumerate the available sleep study reports by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1518">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1518">Method</span></span>      | <span data-ttu-id="01424-1519">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1519">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1520">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1520">GET</span></span> | <span data-ttu-id="01424-1521">/api/power/sleepstudy/reports</span><span class="sxs-lookup"><span data-stu-id="01424-1521">/api/power/sleepstudy/reports</span></span> |


**<span data-ttu-id="01424-1522">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1522">URI parameters</span></span>**

- <span data-ttu-id="01424-1523">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1523">None</span></span>

**<span data-ttu-id="01424-1524">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1524">Request headers</span></span>**

- <span data-ttu-id="01424-1525">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1525">None</span></span>

**<span data-ttu-id="01424-1526">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1526">Request body</span></span>**

- <span data-ttu-id="01424-1527">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1527">None</span></span>

**<span data-ttu-id="01424-1528">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1528">Response</span></span>**

<span data-ttu-id="01424-1529">利用可能なレポートの一覧のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-1529">The list of available reports has the following template.</span></span>

```json
{"Reports": [
    {
        "FileName": string
    },...
]}
```

**<span data-ttu-id="01424-1530">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1530">Status code</span></span>**

<span data-ttu-id="01424-1531">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1531">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1532">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1532">HTTP status code</span></span>      | <span data-ttu-id="01424-1533">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1533">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1534">200</span><span class="sxs-lookup"><span data-stu-id="01424-1534">200</span></span> | <span data-ttu-id="01424-1535">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1535">OK</span></span> |
| <span data-ttu-id="01424-1536">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1536">4XX</span></span> | <span data-ttu-id="01424-1537">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1537">Error codes</span></span> |
| <span data-ttu-id="01424-1538">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1538">5XX</span></span> | <span data-ttu-id="01424-1539">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1539">Error codes</span></span> |

**<span data-ttu-id="01424-1540">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1540">Available device families</span></span>**

* <span data-ttu-id="01424-1541">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1541">Windows Desktop</span></span>
* <span data-ttu-id="01424-1542">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1542">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1543">スリープ スタディ変換を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1543">Get the sleep study transform</span></span>

**<span data-ttu-id="01424-1544">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1544">Request</span></span>**

<span data-ttu-id="01424-1545">次の要求形式を使用して、スリープ スタディ変換を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1545">You can get the sleep study transform by using the following request format.</span></span> <span data-ttu-id="01424-1546">この変換は、SleepStudy レポートを、ユーザーが読み取ることができる XML 形式に変換する XSLT です。</span><span class="sxs-lookup"><span data-stu-id="01424-1546">This transform is an XSLT that converts the sleep study report into an XML format that can be read by a person.</span></span>
 
| <span data-ttu-id="01424-1547">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1547">Method</span></span>      | <span data-ttu-id="01424-1548">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1548">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1549">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1549">GET</span></span> | <span data-ttu-id="01424-1550">/api/power/sleepstudy/transform</span><span class="sxs-lookup"><span data-stu-id="01424-1550">/api/power/sleepstudy/transform</span></span> |


**<span data-ttu-id="01424-1551">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1551">URI parameters</span></span>**

- <span data-ttu-id="01424-1552">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1552">None</span></span>

**<span data-ttu-id="01424-1553">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1553">Request headers</span></span>**

- <span data-ttu-id="01424-1554">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1554">None</span></span>

**<span data-ttu-id="01424-1555">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1555">Request body</span></span>**

- <span data-ttu-id="01424-1556">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1556">None</span></span>

**<span data-ttu-id="01424-1557">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1557">Response</span></span>**

<span data-ttu-id="01424-1558">応答には、スリープ スタディ変換が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1558">The response contains the sleep study transform.</span></span>

**<span data-ttu-id="01424-1559">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1559">Status code</span></span>**

<span data-ttu-id="01424-1560">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1560">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1561">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1561">HTTP status code</span></span>      | <span data-ttu-id="01424-1562">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1562">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1563">200</span><span class="sxs-lookup"><span data-stu-id="01424-1563">200</span></span> | <span data-ttu-id="01424-1564">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1564">OK</span></span> |
| <span data-ttu-id="01424-1565">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1565">4XX</span></span> | <span data-ttu-id="01424-1566">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1566">Error codes</span></span> |
| <span data-ttu-id="01424-1567">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1567">5XX</span></span> | <span data-ttu-id="01424-1568">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1568">Error codes</span></span> |

**<span data-ttu-id="01424-1569">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1569">Available device families</span></span>**

* <span data-ttu-id="01424-1570">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1570">Windows Desktop</span></span>
* <span data-ttu-id="01424-1571">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1571">IoT</span></span>

<hr>
## <span data-ttu-id="01424-1572">リモコン</span><span class="sxs-lookup"><span data-stu-id="01424-1572">Remote control</span></span>
<hr>
### <span data-ttu-id="01424-1573">ターゲット コンピューターを再起動する</span><span class="sxs-lookup"><span data-stu-id="01424-1573">Restart the target computer</span></span>

**<span data-ttu-id="01424-1574">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1574">Request</span></span>**

<span data-ttu-id="01424-1575">次の要求形式を使用して、ターゲット コンピューターを再起動できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1575">You can restart the target computer by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1576">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1576">Method</span></span>      | <span data-ttu-id="01424-1577">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1577">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1578">POST</span><span class="sxs-lookup"><span data-stu-id="01424-1578">POST</span></span> | <span data-ttu-id="01424-1579">/api/control/restart</span><span class="sxs-lookup"><span data-stu-id="01424-1579">/api/control/restart</span></span> |


**<span data-ttu-id="01424-1580">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1580">URI parameters</span></span>**

- <span data-ttu-id="01424-1581">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1581">None</span></span>

**<span data-ttu-id="01424-1582">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1582">Request headers</span></span>**

- <span data-ttu-id="01424-1583">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1583">None</span></span>

**<span data-ttu-id="01424-1584">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1584">Request body</span></span>**

- <span data-ttu-id="01424-1585">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1585">None</span></span>

**<span data-ttu-id="01424-1586">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1586">Response</span></span>**

**<span data-ttu-id="01424-1587">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1587">Status code</span></span>**

<span data-ttu-id="01424-1588">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1588">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1589">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1589">HTTP status code</span></span>      | <span data-ttu-id="01424-1590">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1590">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1591">200</span><span class="sxs-lookup"><span data-stu-id="01424-1591">200</span></span> | <span data-ttu-id="01424-1592">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1592">OK</span></span> |

**<span data-ttu-id="01424-1593">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1593">Available device families</span></span>**

* <span data-ttu-id="01424-1594">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1594">Windows Mobile</span></span>
* <span data-ttu-id="01424-1595">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1595">Windows Desktop</span></span>
* <span data-ttu-id="01424-1596">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1596">Xbox</span></span>
* <span data-ttu-id="01424-1597">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1597">HoloLens</span></span>
* <span data-ttu-id="01424-1598">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1598">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1599">ターゲット コンピューターをシャットダウンする</span><span class="sxs-lookup"><span data-stu-id="01424-1599">Shut down the target computer</span></span>

**<span data-ttu-id="01424-1600">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1600">Request</span></span>**

<span data-ttu-id="01424-1601">次の要求形式を使用して、ターゲット コンピューターをシャット ダウンできます。</span><span class="sxs-lookup"><span data-stu-id="01424-1601">You can shut down the target computer by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1602">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1602">Method</span></span>      | <span data-ttu-id="01424-1603">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1603">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1604">POST</span><span class="sxs-lookup"><span data-stu-id="01424-1604">POST</span></span> | <span data-ttu-id="01424-1605">/api/control/shutdown</span><span class="sxs-lookup"><span data-stu-id="01424-1605">/api/control/shutdown</span></span> |


**<span data-ttu-id="01424-1606">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1606">URI parameters</span></span>**

- <span data-ttu-id="01424-1607">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1607">None</span></span>

**<span data-ttu-id="01424-1608">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1608">Request headers</span></span>**

- <span data-ttu-id="01424-1609">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1609">None</span></span>

**<span data-ttu-id="01424-1610">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1610">Request body</span></span>**

- <span data-ttu-id="01424-1611">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1611">None</span></span>

**<span data-ttu-id="01424-1612">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1612">Response</span></span>**

**<span data-ttu-id="01424-1613">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1613">Status code</span></span>**

<span data-ttu-id="01424-1614">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1614">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1615">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1615">HTTP status code</span></span>      | <span data-ttu-id="01424-1616">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1616">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1617">200</span><span class="sxs-lookup"><span data-stu-id="01424-1617">200</span></span> | <span data-ttu-id="01424-1618">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1618">OK</span></span> |
| <span data-ttu-id="01424-1619">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1619">4XX</span></span> | <span data-ttu-id="01424-1620">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1620">Error codes</span></span> |
| <span data-ttu-id="01424-1621">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1621">5XX</span></span> | <span data-ttu-id="01424-1622">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1622">Error codes</span></span> |

**<span data-ttu-id="01424-1623">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1623">Available device families</span></span>**

* <span data-ttu-id="01424-1624">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1624">Windows Mobile</span></span>
* <span data-ttu-id="01424-1625">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1625">Windows Desktop</span></span>
* <span data-ttu-id="01424-1626">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1626">Xbox</span></span>
* <span data-ttu-id="01424-1627">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1627">HoloLens</span></span>
* <span data-ttu-id="01424-1628">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1628">IoT</span></span>

<hr>
## <span data-ttu-id="01424-1629">タスク マネージャー</span><span class="sxs-lookup"><span data-stu-id="01424-1629">Task manager</span></span>
<hr>
### <span data-ttu-id="01424-1630">最新のアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="01424-1630">Start a modern app</span></span>

**<span data-ttu-id="01424-1631">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1631">Request</span></span>**

<span data-ttu-id="01424-1632">次の要求形式を使用して、最新のアプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1632">You can start a modern app by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1633">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1633">Method</span></span>      | <span data-ttu-id="01424-1634">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1634">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1635">POST</span><span class="sxs-lookup"><span data-stu-id="01424-1635">POST</span></span> | <span data-ttu-id="01424-1636">/api/taskmanager/app</span><span class="sxs-lookup"><span data-stu-id="01424-1636">/api/taskmanager/app</span></span> |


**<span data-ttu-id="01424-1637">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1637">URI parameters</span></span>**

<span data-ttu-id="01424-1638">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1638">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1639">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1639">URI parameter</span></span> | <span data-ttu-id="01424-1640">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1640">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="01424-1641">appid</span><span class="sxs-lookup"><span data-stu-id="01424-1641">appid</span></span>   | <span data-ttu-id="01424-1642">(**必須**) 起動するアプリの PRAID。</span><span class="sxs-lookup"><span data-stu-id="01424-1642">(**required**) The PRAID for the app you want to start.</span></span> <span data-ttu-id="01424-1643">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1643">This value should be hex64 encoded.</span></span> |
| <span data-ttu-id="01424-1644">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="01424-1644">package</span></span>   | <span data-ttu-id="01424-1645">(**必須**) 起動するアプリ パッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="01424-1645">(**required**) The full name for the app package you want to start.</span></span> <span data-ttu-id="01424-1646">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1646">This value should be hex64 encoded.</span></span> |

**<span data-ttu-id="01424-1647">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1647">Request headers</span></span>**

- <span data-ttu-id="01424-1648">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1648">None</span></span>

**<span data-ttu-id="01424-1649">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1649">Request body</span></span>**

- <span data-ttu-id="01424-1650">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1650">None</span></span>

**<span data-ttu-id="01424-1651">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1651">Response</span></span>**

**<span data-ttu-id="01424-1652">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1652">Status code</span></span>**

<span data-ttu-id="01424-1653">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1653">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1654">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1654">HTTP status code</span></span>      | <span data-ttu-id="01424-1655">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1655">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1656">200</span><span class="sxs-lookup"><span data-stu-id="01424-1656">200</span></span> | <span data-ttu-id="01424-1657">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1657">OK</span></span> |
| <span data-ttu-id="01424-1658">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1658">4XX</span></span> | <span data-ttu-id="01424-1659">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1659">Error codes</span></span> |
| <span data-ttu-id="01424-1660">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1660">5XX</span></span> | <span data-ttu-id="01424-1661">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1661">Error codes</span></span> |

**<span data-ttu-id="01424-1662">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1662">Available device families</span></span>**

* <span data-ttu-id="01424-1663">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1663">Windows Mobile</span></span>
* <span data-ttu-id="01424-1664">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1664">Windows Desktop</span></span>
* <span data-ttu-id="01424-1665">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1665">Xbox</span></span>
* <span data-ttu-id="01424-1666">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1666">HoloLens</span></span>
* <span data-ttu-id="01424-1667">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1667">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1668">最新のアプリを停止する</span><span class="sxs-lookup"><span data-stu-id="01424-1668">Stop a modern app</span></span>

**<span data-ttu-id="01424-1669">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1669">Request</span></span>**

<span data-ttu-id="01424-1670">次の要求形式を使用して、最新のアプリを停止できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1670">You can stop a modern app by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1671">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1671">Method</span></span>      | <span data-ttu-id="01424-1672">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1672">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1673">Del</span><span class="sxs-lookup"><span data-stu-id="01424-1673">DELETE</span></span> | <span data-ttu-id="01424-1674">/api/taskmanager/app</span><span class="sxs-lookup"><span data-stu-id="01424-1674">/api/taskmanager/app</span></span> |


**<span data-ttu-id="01424-1675">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1675">URI parameters</span></span>**

<span data-ttu-id="01424-1676">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1676">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1677">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1677">URI parameter</span></span> | <span data-ttu-id="01424-1678">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1678">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="01424-1679">パッケージ (package)</span><span class="sxs-lookup"><span data-stu-id="01424-1679">package</span></span>   | <span data-ttu-id="01424-1680">(**必須**) 停止するアプリ パッケージの完全な名前。</span><span class="sxs-lookup"><span data-stu-id="01424-1680">(**required**) The full name of the app packages that you want to stop.</span></span> <span data-ttu-id="01424-1681">この値は、hex64 エンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1681">This value should be hex64 encoded.</span></span> |
| <span data-ttu-id="01424-1682">forcestop</span><span class="sxs-lookup"><span data-stu-id="01424-1682">forcestop</span></span>   | <span data-ttu-id="01424-1683">(**オプション**) 値が **yes** の場合は、システムがすべてのプロセスを強制的に停止することを示します。</span><span class="sxs-lookup"><span data-stu-id="01424-1683">(**optional**) A value of **yes** indicates that the system should force all processes to stop.</span></span> |

**<span data-ttu-id="01424-1684">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1684">Request headers</span></span>**

- <span data-ttu-id="01424-1685">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1685">None</span></span>

**<span data-ttu-id="01424-1686">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1686">Request body</span></span>**

- <span data-ttu-id="01424-1687">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1687">None</span></span>

**<span data-ttu-id="01424-1688">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1688">Response</span></span>**

**<span data-ttu-id="01424-1689">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1689">Status code</span></span>**

<span data-ttu-id="01424-1690">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1690">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1691">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1691">HTTP status code</span></span>      | <span data-ttu-id="01424-1692">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1692">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1693">200</span><span class="sxs-lookup"><span data-stu-id="01424-1693">200</span></span> | <span data-ttu-id="01424-1694">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1694">OK</span></span> |
| <span data-ttu-id="01424-1695">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1695">4XX</span></span> | <span data-ttu-id="01424-1696">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1696">Error codes</span></span> |
| <span data-ttu-id="01424-1697">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1697">5XX</span></span> | <span data-ttu-id="01424-1698">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1698">Error codes</span></span> |

**<span data-ttu-id="01424-1699">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1699">Available device families</span></span>**

* <span data-ttu-id="01424-1700">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1700">Windows Mobile</span></span>
* <span data-ttu-id="01424-1701">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1701">Windows Desktop</span></span>
* <span data-ttu-id="01424-1702">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1702">Xbox</span></span>
* <span data-ttu-id="01424-1703">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1703">HoloLens</span></span>
* <span data-ttu-id="01424-1704">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1704">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1705">PID でプロセスを強制終了する</span><span class="sxs-lookup"><span data-stu-id="01424-1705">Kill process by PID</span></span>

**<span data-ttu-id="01424-1706">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1706">Request</span></span>**

<span data-ttu-id="01424-1707">次の要求形式を使用して、プロセスを強制終了できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1707">You can kill a process by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1708">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1708">Method</span></span>      | <span data-ttu-id="01424-1709">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1709">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1710">Del</span><span class="sxs-lookup"><span data-stu-id="01424-1710">DELETE</span></span> | <span data-ttu-id="01424-1711">/api/taskmanager/process</span><span class="sxs-lookup"><span data-stu-id="01424-1711">/api/taskmanager/process</span></span> |


**<span data-ttu-id="01424-1712">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1712">URI parameters</span></span>**

<span data-ttu-id="01424-1713">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1713">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1714">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1714">URI parameter</span></span> | <span data-ttu-id="01424-1715">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1715">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-1716">pid</span><span class="sxs-lookup"><span data-stu-id="01424-1716">pid</span></span>   | <span data-ttu-id="01424-1717">(**必須**) 終了するプロセスの一意のプロセス ID。</span><span class="sxs-lookup"><span data-stu-id="01424-1717">(**required**) The unique process id for the process to stop.</span></span> |

**<span data-ttu-id="01424-1718">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1718">Request headers</span></span>**

- <span data-ttu-id="01424-1719">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1719">None</span></span>

**<span data-ttu-id="01424-1720">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1720">Request body</span></span>**

- <span data-ttu-id="01424-1721">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1721">None</span></span>

**<span data-ttu-id="01424-1722">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1722">Response</span></span>**

**<span data-ttu-id="01424-1723">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1723">Status code</span></span>**

<span data-ttu-id="01424-1724">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1724">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1725">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1725">HTTP status code</span></span>      | <span data-ttu-id="01424-1726">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1726">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1727">200</span><span class="sxs-lookup"><span data-stu-id="01424-1727">200</span></span> | <span data-ttu-id="01424-1728">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1728">OK</span></span> |
| <span data-ttu-id="01424-1729">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1729">4XX</span></span> | <span data-ttu-id="01424-1730">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1730">Error codes</span></span> |
| <span data-ttu-id="01424-1731">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1731">5XX</span></span> | <span data-ttu-id="01424-1732">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1732">Error codes</span></span> |

**<span data-ttu-id="01424-1733">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1733">Available device families</span></span>**

* <span data-ttu-id="01424-1734">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1734">Windows Desktop</span></span>
* <span data-ttu-id="01424-1735">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1735">HoloLens</span></span>
* <span data-ttu-id="01424-1736">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1736">IoT</span></span>

<hr>
## <span data-ttu-id="01424-1737">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="01424-1737">Networking</span></span>
<hr>
### <span data-ttu-id="01424-1738">現在の IP 構成を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-1738">Get the current IP configuration</span></span>

**<span data-ttu-id="01424-1739">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1739">Request</span></span>**

<span data-ttu-id="01424-1740">次の要求形式を使用して、現在の IP 構成を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1740">You can get the current IP configuration by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1741">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1741">Method</span></span>      | <span data-ttu-id="01424-1742">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1742">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1743">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1743">GET</span></span> | <span data-ttu-id="01424-1744">/api/networking/ipconfig</span><span class="sxs-lookup"><span data-stu-id="01424-1744">/api/networking/ipconfig</span></span> |


**<span data-ttu-id="01424-1745">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1745">URI parameters</span></span>**

- <span data-ttu-id="01424-1746">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1746">None</span></span>

**<span data-ttu-id="01424-1747">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1747">Request headers</span></span>**

- <span data-ttu-id="01424-1748">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1748">None</span></span>

**<span data-ttu-id="01424-1749">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1749">Request body</span></span>**

- <span data-ttu-id="01424-1750">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1750">None</span></span>

**<span data-ttu-id="01424-1751">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1751">Response</span></span>**

<span data-ttu-id="01424-1752">応答には、次のテンプレートの IP 構成が含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1752">The response includes the IP configuration in the following template.</span></span>

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

**<span data-ttu-id="01424-1753">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1753">Status code</span></span>**

<span data-ttu-id="01424-1754">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1754">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1755">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1755">HTTP status code</span></span>      | <span data-ttu-id="01424-1756">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1756">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1757">200</span><span class="sxs-lookup"><span data-stu-id="01424-1757">200</span></span> | <span data-ttu-id="01424-1758">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1758">OK</span></span> |
| <span data-ttu-id="01424-1759">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1759">4XX</span></span> | <span data-ttu-id="01424-1760">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1760">Error codes</span></span> |
| <span data-ttu-id="01424-1761">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1761">5XX</span></span> | <span data-ttu-id="01424-1762">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1762">Error codes</span></span> |

**<span data-ttu-id="01424-1763">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1763">Available device families</span></span>**

* <span data-ttu-id="01424-1764">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1764">Windows Mobile</span></span>
* <span data-ttu-id="01424-1765">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1765">Windows Desktop</span></span>
* <span data-ttu-id="01424-1766">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1766">Xbox</span></span>
* <span data-ttu-id="01424-1767">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1767">HoloLens</span></span>
* <span data-ttu-id="01424-1768">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1768">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1769">静的 IP アドレス (IPV4 構成) の設定します。</span><span class="sxs-lookup"><span data-stu-id="01424-1769">Set a static IP address (IPV4 configuration)</span></span>

**<span data-ttu-id="01424-1770">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1770">Request</span></span>**

<span data-ttu-id="01424-1771">静的 IP と DNS で IPV4 構成を設定します。</span><span class="sxs-lookup"><span data-stu-id="01424-1771">Sets the IPV4 configuration with static IP and DNS.</span></span> <span data-ttu-id="01424-1772">静的 IP が指定されていない場合は、DHCP が使用できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1772">If a static IP is not specified, then it enables DHCP.</span></span> <span data-ttu-id="01424-1773">静的 IP が指定されている場合は、DNS も指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1773">If a static IP is specified, then DNS must be specified also.</span></span>
 
| <span data-ttu-id="01424-1774">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1774">Method</span></span>      | <span data-ttu-id="01424-1775">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1775">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1776">PUT</span><span class="sxs-lookup"><span data-stu-id="01424-1776">PUT</span></span> | <span data-ttu-id="01424-1777">/api/networking/ipv4config</span><span class="sxs-lookup"><span data-stu-id="01424-1777">/api/networking/ipv4config</span></span> |


**<span data-ttu-id="01424-1778">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1778">URI parameters</span></span>**

| <span data-ttu-id="01424-1779">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1779">URI parameter</span></span> | <span data-ttu-id="01424-1780">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1780">Description</span></span> |
| :---          | :--- |
| <span data-ttu-id="01424-1781">AdapterName</span><span class="sxs-lookup"><span data-stu-id="01424-1781">AdapterName</span></span> | <span data-ttu-id="01424-1782">(**必要**) ネットワーク インターフェイスの GUID。</span><span class="sxs-lookup"><span data-stu-id="01424-1782">(**required**) The network interface GUID.</span></span> |
| <span data-ttu-id="01424-1783">IPAddress</span><span class="sxs-lookup"><span data-stu-id="01424-1783">IPAddress</span></span> | <span data-ttu-id="01424-1784">設定する静的 IP アドレス。</span><span class="sxs-lookup"><span data-stu-id="01424-1784">The static IP address to set.</span></span> |
| <span data-ttu-id="01424-1785">サブネット マスク</span><span class="sxs-lookup"><span data-stu-id="01424-1785">SubnetMask</span></span> | <span data-ttu-id="01424-1786">(**必要**場合*IPAddress*が null でない)、静的なサブネット マスク。</span><span class="sxs-lookup"><span data-stu-id="01424-1786">(**required** if *IPAddress* is not null) The static subnet mask.</span></span> |
| <span data-ttu-id="01424-1787">DefaultGateway</span><span class="sxs-lookup"><span data-stu-id="01424-1787">DefaultGateway</span></span> | <span data-ttu-id="01424-1788">(**必要**場合*IPAddress*が null でない)、静的な既定ゲートウェイ。</span><span class="sxs-lookup"><span data-stu-id="01424-1788">(**required** if *IPAddress* is not null) The static default gateway.</span></span> |
| <span data-ttu-id="01424-1789">PrimaryDNS</span><span class="sxs-lookup"><span data-stu-id="01424-1789">PrimaryDNS</span></span> | <span data-ttu-id="01424-1790">(**必要**場合*IPAddress*が null でない) を設定する静的なプライマリ DNS。</span><span class="sxs-lookup"><span data-stu-id="01424-1790">(**required** if *IPAddress* is not null) The static primary DNS to set.</span></span> |
| <span data-ttu-id="01424-1791">SecondayDNS</span><span class="sxs-lookup"><span data-stu-id="01424-1791">SecondayDNS</span></span> | <span data-ttu-id="01424-1792">(**必要**場合*PrimaryDNS*が null でない) を設定する静的セカンダリ DNS。</span><span class="sxs-lookup"><span data-stu-id="01424-1792">(**required** if *PrimaryDNS* is not null) The static secondary DNS to set.</span></span> |

<span data-ttu-id="01424-1793">わかりやすくするため、DHCP にインターフェイスを設定するシリアル化、`AdapterName`ネットワーク上で。</span><span class="sxs-lookup"><span data-stu-id="01424-1793">For clarity, to set an interface to DHCP, serialize just the `AdapterName` on the wire:</span></span>
```
{
    "AdapterName":"{82F86C1B-2BAE-41E3-B08D-786CA44FEED7}"
}
```

**<span data-ttu-id="01424-1794">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1794">Request headers</span></span>**

- <span data-ttu-id="01424-1795">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1795">None</span></span>

**<span data-ttu-id="01424-1796">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1796">Request body</span></span>**

- <span data-ttu-id="01424-1797">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1797">None</span></span>

**<span data-ttu-id="01424-1798">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1798">Response</span></span>**

**<span data-ttu-id="01424-1799">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1799">Status code</span></span>**

<span data-ttu-id="01424-1800">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1800">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1801">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1801">HTTP status code</span></span>      | <span data-ttu-id="01424-1802">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1802">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1803">200</span><span class="sxs-lookup"><span data-stu-id="01424-1803">200</span></span> | <span data-ttu-id="01424-1804">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1804">OK</span></span> |
| <span data-ttu-id="01424-1805">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1805">4XX</span></span> | <span data-ttu-id="01424-1806">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1806">Error codes</span></span> |
| <span data-ttu-id="01424-1807">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1807">5XX</span></span> | <span data-ttu-id="01424-1808">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1808">Error codes</span></span> |

**<span data-ttu-id="01424-1809">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1809">Available device families</span></span>**

* <span data-ttu-id="01424-1810">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1810">Windows Mobile</span></span>
* <span data-ttu-id="01424-1811">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1811">Windows Desktop</span></span>
* <span data-ttu-id="01424-1812">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1812">Xbox</span></span>
* <span data-ttu-id="01424-1813">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1813">HoloLens</span></span>
* <span data-ttu-id="01424-1814">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1814">IoT</span></span>
<hr>
### <span data-ttu-id="01424-1815">ワイヤレス ネットワーク インターフェイスを列挙する</span><span class="sxs-lookup"><span data-stu-id="01424-1815">Enumerate wireless network interfaces</span></span>

**<span data-ttu-id="01424-1816">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1816">Request</span></span>**

<span data-ttu-id="01424-1817">次の要求形式を使用して、利用可能なワイヤレス ネットワーク インターフェイスを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1817">You can enumerate the available wireless network interfaces by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1818">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1818">Method</span></span>      | <span data-ttu-id="01424-1819">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1819">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1820">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1820">GET</span></span> | <span data-ttu-id="01424-1821">/api/wifi/interfaces</span><span class="sxs-lookup"><span data-stu-id="01424-1821">/api/wifi/interfaces</span></span> |


**<span data-ttu-id="01424-1822">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1822">URI parameters</span></span>**

- <span data-ttu-id="01424-1823">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1823">None</span></span>

**<span data-ttu-id="01424-1824">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1824">Request headers</span></span>**

- <span data-ttu-id="01424-1825">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1825">None</span></span>

**<span data-ttu-id="01424-1826">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1826">Request body</span></span>**

- <span data-ttu-id="01424-1827">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1827">None</span></span>

**<span data-ttu-id="01424-1828">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1828">Response</span></span>**

<span data-ttu-id="01424-1829">次の形式の利用可能なワイヤレス インターフェイスと詳細の一覧。</span><span class="sxs-lookup"><span data-stu-id="01424-1829">A list of the available wireless interfaces with details in the following format.</span></span>

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

**<span data-ttu-id="01424-1830">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1830">Status code</span></span>**

<span data-ttu-id="01424-1831">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1831">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1832">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1832">HTTP status code</span></span>      | <span data-ttu-id="01424-1833">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1833">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1834">200</span><span class="sxs-lookup"><span data-stu-id="01424-1834">200</span></span> | <span data-ttu-id="01424-1835">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1835">OK</span></span> |
| <span data-ttu-id="01424-1836">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1836">4XX</span></span> | <span data-ttu-id="01424-1837">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1837">Error codes</span></span> |
| <span data-ttu-id="01424-1838">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1838">5XX</span></span> | <span data-ttu-id="01424-1839">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1839">Error codes</span></span> |

**<span data-ttu-id="01424-1840">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1840">Available device families</span></span>**

* <span data-ttu-id="01424-1841">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1841">Windows Mobile</span></span>
* <span data-ttu-id="01424-1842">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1842">Windows Desktop</span></span>
* <span data-ttu-id="01424-1843">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1843">Xbox</span></span>
* <span data-ttu-id="01424-1844">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1844">HoloLens</span></span>
* <span data-ttu-id="01424-1845">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1845">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1846">ワイヤレス ネットワークを列挙する</span><span class="sxs-lookup"><span data-stu-id="01424-1846">Enumerate wireless networks</span></span>

**<span data-ttu-id="01424-1847">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1847">Request</span></span>**

<span data-ttu-id="01424-1848">次の要求形式を使用して、指定されたインターフェイスのワイヤレス ネットワークの一覧を列挙できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1848">You can enumerate the list of wireless networks on the specified interface by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1849">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1849">Method</span></span>      | <span data-ttu-id="01424-1850">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1850">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1851">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1851">GET</span></span> | <span data-ttu-id="01424-1852">/api/wifi/networks</span><span class="sxs-lookup"><span data-stu-id="01424-1852">/api/wifi/networks</span></span> |


**<span data-ttu-id="01424-1853">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1853">URI parameters</span></span>**

<span data-ttu-id="01424-1854">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1854">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1855">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1855">URI parameter</span></span> | <span data-ttu-id="01424-1856">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1856">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-1857">インターフェイス</span><span class="sxs-lookup"><span data-stu-id="01424-1857">interface</span></span>   | <span data-ttu-id="01424-1858">(**必須**) ワイヤレス ネットワークの検索に使用するネットワーク インターフェイスの GUID (括弧は不要)。</span><span class="sxs-lookup"><span data-stu-id="01424-1858">(**required**) The GUID for the network interface to use to search for wireless networks, without brackets.</span></span> |

**<span data-ttu-id="01424-1859">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1859">Request headers</span></span>**

- <span data-ttu-id="01424-1860">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1860">None</span></span>

**<span data-ttu-id="01424-1861">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1861">Request body</span></span>**

- <span data-ttu-id="01424-1862">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1862">None</span></span>

**<span data-ttu-id="01424-1863">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1863">Response</span></span>**

<span data-ttu-id="01424-1864">指定された*インターフェイス*で見つかったワイヤレス ネットワークの一覧。</span><span class="sxs-lookup"><span data-stu-id="01424-1864">The list of wireless networks found on the provided *interface*.</span></span> <span data-ttu-id="01424-1865">これには、ネットワークの詳細が次の形式で含まれます。</span><span class="sxs-lookup"><span data-stu-id="01424-1865">This includes details for the networks in the following format.</span></span>

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

**<span data-ttu-id="01424-1866">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1866">Status code</span></span>**

<span data-ttu-id="01424-1867">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1867">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1868">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1868">HTTP status code</span></span>      | <span data-ttu-id="01424-1869">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1869">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1870">200</span><span class="sxs-lookup"><span data-stu-id="01424-1870">200</span></span> | <span data-ttu-id="01424-1871">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1871">OK</span></span> |
| <span data-ttu-id="01424-1872">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1872">4XX</span></span> | <span data-ttu-id="01424-1873">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1873">Error codes</span></span> |
| <span data-ttu-id="01424-1874">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1874">5XX</span></span> | <span data-ttu-id="01424-1875">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1875">Error codes</span></span> |

**<span data-ttu-id="01424-1876">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1876">Available device families</span></span>**

* <span data-ttu-id="01424-1877">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1877">Windows Mobile</span></span>
* <span data-ttu-id="01424-1878">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1878">Windows Desktop</span></span>
* <span data-ttu-id="01424-1879">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1879">Xbox</span></span>
* <span data-ttu-id="01424-1880">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1880">HoloLens</span></span>
* <span data-ttu-id="01424-1881">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1881">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1882">Wi-Fi ネットワークを接続および切断する</span><span class="sxs-lookup"><span data-stu-id="01424-1882">Connect and disconnect to a Wi-Fi network.</span></span>

**<span data-ttu-id="01424-1883">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1883">Request</span></span>**

<span data-ttu-id="01424-1884">次の要求形式を使用して、Wi-Fi ネットワークを接続および切断できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1884">You can connect or disconnect to a Wi-Fi network by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1885">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1885">Method</span></span>      | <span data-ttu-id="01424-1886">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1886">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1887">POST</span><span class="sxs-lookup"><span data-stu-id="01424-1887">POST</span></span> | <span data-ttu-id="01424-1888">/api/wifi/network</span><span class="sxs-lookup"><span data-stu-id="01424-1888">/api/wifi/network</span></span> |


**<span data-ttu-id="01424-1889">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1889">URI parameters</span></span>**

<span data-ttu-id="01424-1890">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1890">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1891">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1891">URI parameter</span></span> | <span data-ttu-id="01424-1892">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1892">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-1893">インターフェイス</span><span class="sxs-lookup"><span data-stu-id="01424-1893">interface</span></span>   | <span data-ttu-id="01424-1894">(**必須**) ネットワークへの接続に使用するネットワーク インターフェイスの GUID。</span><span class="sxs-lookup"><span data-stu-id="01424-1894">(**required**) The GUID for the network interface you use to connect to the network.</span></span> |
| <span data-ttu-id="01424-1895">op</span><span class="sxs-lookup"><span data-stu-id="01424-1895">op</span></span>   | <span data-ttu-id="01424-1896">(**必須**) 実行するアクションを示します。</span><span class="sxs-lookup"><span data-stu-id="01424-1896">(**required**) Indicates the action to take.</span></span> <span data-ttu-id="01424-1897">設定可能な値は、connect または disconnect です。</span><span class="sxs-lookup"><span data-stu-id="01424-1897">Possible values are connect or disconnect.</span></span>|
| <span data-ttu-id="01424-1898">ssid</span><span class="sxs-lookup"><span data-stu-id="01424-1898">ssid</span></span>   | <span data-ttu-id="01424-1899">(***op* == connect の場合は必須**) 接続先 SSID。</span><span class="sxs-lookup"><span data-stu-id="01424-1899">(**required if *op* == connect**) The SSID to connect to.</span></span> |
| <span data-ttu-id="01424-1900">key</span><span class="sxs-lookup"><span data-stu-id="01424-1900">key</span></span>   | <span data-ttu-id="01424-1901">(***op* == connect で、ネットワークで認証が必要な場合は必須**) 共有キー。</span><span class="sxs-lookup"><span data-stu-id="01424-1901">(**required if *op* == connect and network requires authentication**) The shared key.</span></span> |
| <span data-ttu-id="01424-1902">createprofile</span><span class="sxs-lookup"><span data-stu-id="01424-1902">createprofile</span></span> | <span data-ttu-id="01424-1903">(**必要**) デバイスでネットワークのプロファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="01424-1903">(**required**) Create a profile for the network on the device.</span></span>  <span data-ttu-id="01424-1904">これにより、今後、デバイスはネットワークに自動接続されます。</span><span class="sxs-lookup"><span data-stu-id="01424-1904">This will cause the device to auto-connect to the network in the future.</span></span> <span data-ttu-id="01424-1905">**yes** または **no** を指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1905">This can be **yes** or **no**.</span></span> |

**<span data-ttu-id="01424-1906">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1906">Request headers</span></span>**

- <span data-ttu-id="01424-1907">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1907">None</span></span>

**<span data-ttu-id="01424-1908">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1908">Request body</span></span>**

- <span data-ttu-id="01424-1909">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1909">None</span></span>

**<span data-ttu-id="01424-1910">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1910">Response</span></span>**

**<span data-ttu-id="01424-1911">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1911">Status code</span></span>**

<span data-ttu-id="01424-1912">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1912">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1913">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1913">HTTP status code</span></span>      | <span data-ttu-id="01424-1914">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1914">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1915">200</span><span class="sxs-lookup"><span data-stu-id="01424-1915">200</span></span> | <span data-ttu-id="01424-1916">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1916">OK</span></span> |

**<span data-ttu-id="01424-1917">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1917">Available device families</span></span>**

* <span data-ttu-id="01424-1918">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1918">Windows Mobile</span></span>
* <span data-ttu-id="01424-1919">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1919">Windows Desktop</span></span>
* <span data-ttu-id="01424-1920">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1920">Xbox</span></span>
* <span data-ttu-id="01424-1921">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1921">HoloLens</span></span>
* <span data-ttu-id="01424-1922">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1922">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1923">Wi-Fi のプロファイルを削除する</span><span class="sxs-lookup"><span data-stu-id="01424-1923">Delete a Wi-Fi profile</span></span>

**<span data-ttu-id="01424-1924">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1924">Request</span></span>**

<span data-ttu-id="01424-1925">次の要求形式を使用して、特定のインターフェイス上のネットワークに関連付けられたプロファイルを削除できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1925">You can delete a profile associated with a network on a specific interface by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1926">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1926">Method</span></span>      | <span data-ttu-id="01424-1927">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1927">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1928">Del</span><span class="sxs-lookup"><span data-stu-id="01424-1928">DELETE</span></span> | <span data-ttu-id="01424-1929">/api/wifi/profile</span><span class="sxs-lookup"><span data-stu-id="01424-1929">/api/wifi/profile</span></span> |


**<span data-ttu-id="01424-1930">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1930">URI parameters</span></span>**

<span data-ttu-id="01424-1931">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1931">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1932">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1932">URI parameter</span></span> | <span data-ttu-id="01424-1933">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1933">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-1934">インターフェイス</span><span class="sxs-lookup"><span data-stu-id="01424-1934">interface</span></span>   | <span data-ttu-id="01424-1935">(**必須**) 削除するプロファイルに関連付けられたネットワーク インターフェイスの GUID。</span><span class="sxs-lookup"><span data-stu-id="01424-1935">(**required**) The GUID for the network interface associated with the profile to delete.</span></span> |
| <span data-ttu-id="01424-1936">プロファイル</span><span class="sxs-lookup"><span data-stu-id="01424-1936">profile</span></span>   | <span data-ttu-id="01424-1937">(**必須**) 削除するプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-1937">(**required**) The name of the profile to delete.</span></span> |

**<span data-ttu-id="01424-1938">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1938">Request headers</span></span>**

- <span data-ttu-id="01424-1939">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1939">None</span></span>

**<span data-ttu-id="01424-1940">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1940">Request body</span></span>**

- <span data-ttu-id="01424-1941">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1941">None</span></span>

**<span data-ttu-id="01424-1942">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1942">Response</span></span>**

**<span data-ttu-id="01424-1943">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1943">Status code</span></span>**

<span data-ttu-id="01424-1944">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1944">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1945">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1945">HTTP status code</span></span>      | <span data-ttu-id="01424-1946">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1946">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1947">200</span><span class="sxs-lookup"><span data-stu-id="01424-1947">200</span></span> | <span data-ttu-id="01424-1948">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1948">OK</span></span> |

**<span data-ttu-id="01424-1949">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1949">Available device families</span></span>**

* <span data-ttu-id="01424-1950">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-1950">Windows Mobile</span></span>
* <span data-ttu-id="01424-1951">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1951">Windows Desktop</span></span>
* <span data-ttu-id="01424-1952">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-1952">Xbox</span></span>
* <span data-ttu-id="01424-1953">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1953">HoloLens</span></span>
* <span data-ttu-id="01424-1954">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1954">IoT</span></span>

<hr>
## <span data-ttu-id="01424-1955">Windows エラー報告 (WER)</span><span class="sxs-lookup"><span data-stu-id="01424-1955">Windows Error Reporting (WER)</span></span>
<hr>
### <span data-ttu-id="01424-1956">Windows エラー報告 (WER) ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="01424-1956">Download a Windows error reporting (WER) file</span></span>

**<span data-ttu-id="01424-1957">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1957">Request</span></span>**

<span data-ttu-id="01424-1958">次の要求形式を使用して、WER 関連のファイルをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="01424-1958">You can download a WER-related file by using the following request format.</span></span>
 
| <span data-ttu-id="01424-1959">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-1959">Method</span></span>      | <span data-ttu-id="01424-1960">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-1960">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1961">GET</span><span class="sxs-lookup"><span data-stu-id="01424-1961">GET</span></span> | <span data-ttu-id="01424-1962">/api/wer/report/file</span><span class="sxs-lookup"><span data-stu-id="01424-1962">/api/wer/report/file</span></span> |


**<span data-ttu-id="01424-1963">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1963">URI parameters</span></span>**

<span data-ttu-id="01424-1964">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-1964">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-1965">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-1965">URI parameter</span></span> | <span data-ttu-id="01424-1966">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1966">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-1967">ユーザー</span><span class="sxs-lookup"><span data-stu-id="01424-1967">user</span></span>   | <span data-ttu-id="01424-1968">(**必須**) レポートに関連付けられたユーザー名。</span><span class="sxs-lookup"><span data-stu-id="01424-1968">(**required**) The user name associated with the report.</span></span> |
| <span data-ttu-id="01424-1969">type</span><span class="sxs-lookup"><span data-stu-id="01424-1969">type</span></span>   | <span data-ttu-id="01424-1970">(**必須**) レポートの種類。</span><span class="sxs-lookup"><span data-stu-id="01424-1970">(**required**) The type of report.</span></span> <span data-ttu-id="01424-1971">これは **queried** または **archived** のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="01424-1971">This can be either **queried** or **archived**.</span></span> |
| <span data-ttu-id="01424-1972">name</span><span class="sxs-lookup"><span data-stu-id="01424-1972">name</span></span>   | <span data-ttu-id="01424-1973">(**必須**) レポートの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-1973">(**required**) The name of the report.</span></span> <span data-ttu-id="01424-1974">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1974">This should be base64 encoded.</span></span> |
| <span data-ttu-id="01424-1975">ファイル</span><span class="sxs-lookup"><span data-stu-id="01424-1975">file</span></span>   | <span data-ttu-id="01424-1976">(**必須**) レポートからダウンロードするファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-1976">(**required**) The name of the file to download from the report.</span></span> <span data-ttu-id="01424-1977">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1977">This should be base64 encoded.</span></span> |

**<span data-ttu-id="01424-1978">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-1978">Request headers</span></span>**

- <span data-ttu-id="01424-1979">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1979">None</span></span>

**<span data-ttu-id="01424-1980">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-1980">Request body</span></span>**

- <span data-ttu-id="01424-1981">なし</span><span class="sxs-lookup"><span data-stu-id="01424-1981">None</span></span>

**<span data-ttu-id="01424-1982">応答</span><span class="sxs-lookup"><span data-stu-id="01424-1982">Response</span></span>**

- <span data-ttu-id="01424-1983">応答には、要求したファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="01424-1983">Response contains the requested file.</span></span> 

**<span data-ttu-id="01424-1984">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1984">Status code</span></span>**

<span data-ttu-id="01424-1985">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-1985">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-1986">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-1986">HTTP status code</span></span>      | <span data-ttu-id="01424-1987">説明</span><span class="sxs-lookup"><span data-stu-id="01424-1987">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-1988">200</span><span class="sxs-lookup"><span data-stu-id="01424-1988">200</span></span> | <span data-ttu-id="01424-1989">OK</span><span class="sxs-lookup"><span data-stu-id="01424-1989">OK</span></span> |
| <span data-ttu-id="01424-1990">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-1990">4XX</span></span> | <span data-ttu-id="01424-1991">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1991">Error codes</span></span> |
| <span data-ttu-id="01424-1992">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-1992">5XX</span></span> | <span data-ttu-id="01424-1993">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-1993">Error codes</span></span> |

**<span data-ttu-id="01424-1994">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-1994">Available device families</span></span>**

* <span data-ttu-id="01424-1995">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-1995">Windows Desktop</span></span>
* <span data-ttu-id="01424-1996">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-1996">HoloLens</span></span>
* <span data-ttu-id="01424-1997">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-1997">IoT</span></span>

<hr>
### <span data-ttu-id="01424-1998">Windows エラー報告 (WER) レポート内のファイルを列挙する</span><span class="sxs-lookup"><span data-stu-id="01424-1998">Enumerate files in a Windows error reporting (WER) report</span></span>

**<span data-ttu-id="01424-1999">要求</span><span class="sxs-lookup"><span data-stu-id="01424-1999">Request</span></span>**

<span data-ttu-id="01424-2000">次の要求形式を使用して、WER レポート内のファイルを列挙できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2000">You can enumerate the files in a WER report by using the following request format.</span></span>
 
| <span data-ttu-id="01424-2001">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2001">Method</span></span>      | <span data-ttu-id="01424-2002">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2002">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2003">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2003">GET</span></span> | <span data-ttu-id="01424-2004">/api/wer/report/files</span><span class="sxs-lookup"><span data-stu-id="01424-2004">/api/wer/report/files</span></span> |


**<span data-ttu-id="01424-2005">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2005">URI parameters</span></span>**

<span data-ttu-id="01424-2006">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2006">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-2007">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2007">URI parameter</span></span> | <span data-ttu-id="01424-2008">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2008">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-2009">ユーザー</span><span class="sxs-lookup"><span data-stu-id="01424-2009">user</span></span>   | <span data-ttu-id="01424-2010">(**必須**) レポートに関連付けられたユーザー。</span><span class="sxs-lookup"><span data-stu-id="01424-2010">(**required**) The user associated with the report.</span></span> |
| <span data-ttu-id="01424-2011">type</span><span class="sxs-lookup"><span data-stu-id="01424-2011">type</span></span>   | <span data-ttu-id="01424-2012">(**必須**) レポートの種類。</span><span class="sxs-lookup"><span data-stu-id="01424-2012">(**required**) The type of report.</span></span> <span data-ttu-id="01424-2013">これは **queried** または **archived** のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="01424-2013">This can be either **queried** or **archived**.</span></span> |
| <span data-ttu-id="01424-2014">name</span><span class="sxs-lookup"><span data-stu-id="01424-2014">name</span></span>   | <span data-ttu-id="01424-2015">(**必須**) レポートの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2015">(**required**) The name of the report.</span></span> <span data-ttu-id="01424-2016">base64 でエンコードされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2016">This should be base64 encoded.</span></span> |

**<span data-ttu-id="01424-2017">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2017">Request headers</span></span>**

- <span data-ttu-id="01424-2018">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2018">None</span></span>

**<span data-ttu-id="01424-2019">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2019">Request body</span></span>**

```json
{"Files": [
    {
        "Name": string, (Filename, not base64 encoded)
        "Size": int (bytes)
    },...
]}
```

**<span data-ttu-id="01424-2020">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2020">Response</span></span>**

**<span data-ttu-id="01424-2021">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2021">Status code</span></span>**

<span data-ttu-id="01424-2022">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2022">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2023">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2023">HTTP status code</span></span>      | <span data-ttu-id="01424-2024">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2024">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2025">200</span><span class="sxs-lookup"><span data-stu-id="01424-2025">200</span></span> | <span data-ttu-id="01424-2026">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2026">OK</span></span> |
| <span data-ttu-id="01424-2027">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2027">4XX</span></span> | <span data-ttu-id="01424-2028">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2028">Error codes</span></span> |
| <span data-ttu-id="01424-2029">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2029">5XX</span></span> | <span data-ttu-id="01424-2030">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2030">Error codes</span></span> |

**<span data-ttu-id="01424-2031">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2031">Available device families</span></span>**

* <span data-ttu-id="01424-2032">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2032">Windows Desktop</span></span>
* <span data-ttu-id="01424-2033">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2033">HoloLens</span></span>
* <span data-ttu-id="01424-2034">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2034">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2035">Windows エラー報告 (WER) レポートを一覧表示する</span><span class="sxs-lookup"><span data-stu-id="01424-2035">List the Windows error reporting (WER) reports</span></span>

**<span data-ttu-id="01424-2036">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2036">Request</span></span>**

<span data-ttu-id="01424-2037">次の要求形式を使用して、WER レポートを取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2037">You can get the WER reports by using the following request format.</span></span>
 
| <span data-ttu-id="01424-2038">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2038">Method</span></span>      | <span data-ttu-id="01424-2039">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2039">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2040">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2040">GET</span></span> | <span data-ttu-id="01424-2041">/api/wer/reports</span><span class="sxs-lookup"><span data-stu-id="01424-2041">/api/wer/reports</span></span> |


**<span data-ttu-id="01424-2042">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2042">URI parameters</span></span>**

- <span data-ttu-id="01424-2043">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2043">None</span></span>

**<span data-ttu-id="01424-2044">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2044">Request headers</span></span>**

- <span data-ttu-id="01424-2045">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2045">None</span></span>

**<span data-ttu-id="01424-2046">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2046">Request body</span></span>**

- <span data-ttu-id="01424-2047">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2047">None</span></span>

**<span data-ttu-id="01424-2048">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2048">Response</span></span>**

<span data-ttu-id="01424-2049">WER 報告の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-2049">The WER reports in the following format.</span></span>

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

**<span data-ttu-id="01424-2050">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2050">Status code</span></span>**

<span data-ttu-id="01424-2051">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2051">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2052">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2052">HTTP status code</span></span>      | <span data-ttu-id="01424-2053">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2053">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2054">200</span><span class="sxs-lookup"><span data-stu-id="01424-2054">200</span></span> | <span data-ttu-id="01424-2055">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2055">OK</span></span> |
| <span data-ttu-id="01424-2056">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2056">4XX</span></span> | <span data-ttu-id="01424-2057">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2057">Error codes</span></span> |
| <span data-ttu-id="01424-2058">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2058">5XX</span></span> | <span data-ttu-id="01424-2059">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2059">Error codes</span></span> |

**<span data-ttu-id="01424-2060">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2060">Available device families</span></span>**

* <span data-ttu-id="01424-2061">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2061">Windows Desktop</span></span>
* <span data-ttu-id="01424-2062">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2062">HoloLens</span></span>
* <span data-ttu-id="01424-2063">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2063">IoT</span></span>

<hr>
## <span data-ttu-id="01424-2064">Windows Performance Recorder (WPR)</span><span class="sxs-lookup"><span data-stu-id="01424-2064">Windows Performance Recorder (WPR)</span></span> 
<hr>
### <span data-ttu-id="01424-2065">カスタム プロファイルを使用してトレースを開始する</span><span class="sxs-lookup"><span data-stu-id="01424-2065">Start tracing with a custom profile</span></span>

**<span data-ttu-id="01424-2066">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2066">Request</span></span>**

<span data-ttu-id="01424-2067">次の要求形式を使用して、WPR プロファイルをアップロードし、そのプロファイルを使用してトレースを開始できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2067">You can upload a WPR profile and start tracing using that profile by using the following request format.</span></span>  <span data-ttu-id="01424-2068">一度に実行できるトレースは 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="01424-2068">Only one trace can run at a time.</span></span> <span data-ttu-id="01424-2069">プロファイルはデバイス上に残りません。</span><span class="sxs-lookup"><span data-stu-id="01424-2069">The profile will not remain on the device.</span></span> 
 
| <span data-ttu-id="01424-2070">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2070">Method</span></span>      | <span data-ttu-id="01424-2071">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2071">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2072">POST</span><span class="sxs-lookup"><span data-stu-id="01424-2072">POST</span></span> | <span data-ttu-id="01424-2073">/api/wpr/customtrace</span><span class="sxs-lookup"><span data-stu-id="01424-2073">/api/wpr/customtrace</span></span> |


**<span data-ttu-id="01424-2074">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2074">URI parameters</span></span>**

- <span data-ttu-id="01424-2075">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2075">None</span></span>

**<span data-ttu-id="01424-2076">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2076">Request headers</span></span>**

- <span data-ttu-id="01424-2077">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2077">None</span></span>

**<span data-ttu-id="01424-2078">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2078">Request body</span></span>**

- <span data-ttu-id="01424-2079">カスタム WPR プロファイルが含まれる、原則に従ったマルチパートの http 本文。</span><span class="sxs-lookup"><span data-stu-id="01424-2079">A multi-part conforming http body that contains the custom WPR profile.</span></span>

**<span data-ttu-id="01424-2080">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2080">Response</span></span>**

<span data-ttu-id="01424-2081">WPR セッション状態の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-2081">The WPR session status in the following format.</span></span>

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

**<span data-ttu-id="01424-2082">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2082">Status code</span></span>**

<span data-ttu-id="01424-2083">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2083">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2084">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2084">HTTP status code</span></span>      | <span data-ttu-id="01424-2085">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2085">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2086">200</span><span class="sxs-lookup"><span data-stu-id="01424-2086">200</span></span> | <span data-ttu-id="01424-2087">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2087">OK</span></span> |
| <span data-ttu-id="01424-2088">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2088">4XX</span></span> | <span data-ttu-id="01424-2089">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2089">Error codes</span></span> |
| <span data-ttu-id="01424-2090">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2090">5XX</span></span> | <span data-ttu-id="01424-2091">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2091">Error codes</span></span> |

**<span data-ttu-id="01424-2092">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2092">Available device families</span></span>**

* <span data-ttu-id="01424-2093">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2093">Windows Mobile</span></span>
* <span data-ttu-id="01424-2094">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2094">Windows Desktop</span></span>
* <span data-ttu-id="01424-2095">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2095">HoloLens</span></span>
* <span data-ttu-id="01424-2096">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2096">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2097">起動パフォーマンス トレース セッションを開始する</span><span class="sxs-lookup"><span data-stu-id="01424-2097">Start a boot performance tracing session</span></span>

**<span data-ttu-id="01424-2098">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2098">Request</span></span>**

<span data-ttu-id="01424-2099">次の要求形式を使用して、WPR の起動トレース セッションを開始できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2099">You can start a boot WPR tracing session by using the following request format.</span></span> <span data-ttu-id="01424-2100">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="01424-2100">This is also known as a performance tracing session.</span></span>
 
| <span data-ttu-id="01424-2101">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2101">Method</span></span>      | <span data-ttu-id="01424-2102">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2102">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2103">POST</span><span class="sxs-lookup"><span data-stu-id="01424-2103">POST</span></span> | <span data-ttu-id="01424-2104">/api/wpr/boottrace</span><span class="sxs-lookup"><span data-stu-id="01424-2104">/api/wpr/boottrace</span></span> |


**<span data-ttu-id="01424-2105">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2105">URI parameters</span></span>**

<span data-ttu-id="01424-2106">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2106">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-2107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2107">URI parameter</span></span> | <span data-ttu-id="01424-2108">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2108">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-2109">プロファイル</span><span class="sxs-lookup"><span data-stu-id="01424-2109">profile</span></span>   | <span data-ttu-id="01424-2110">(**必須**) このパラメーターは起動時に必要です。</span><span class="sxs-lookup"><span data-stu-id="01424-2110">(**required**) This parameter is required on start.</span></span> <span data-ttu-id="01424-2111">パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2111">The name of the profile that should start a performance tracing session.</span></span> <span data-ttu-id="01424-2112">指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。</span><span class="sxs-lookup"><span data-stu-id="01424-2112">The possible profiles are stored in perfprofiles/profiles.json.</span></span> |

**<span data-ttu-id="01424-2113">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2113">Request headers</span></span>**

- <span data-ttu-id="01424-2114">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2114">None</span></span>

**<span data-ttu-id="01424-2115">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2115">Request body</span></span>**

- <span data-ttu-id="01424-2116">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2116">None</span></span>

**<span data-ttu-id="01424-2117">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2117">Response</span></span>**

<span data-ttu-id="01424-2118">この API は、開始時に次の形式で WPR セッション状態を返します。</span><span class="sxs-lookup"><span data-stu-id="01424-2118">On start, this API returns the WPR session status in the following format.</span></span>

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (boot)
}
```

**<span data-ttu-id="01424-2119">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2119">Status code</span></span>**

<span data-ttu-id="01424-2120">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2120">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2121">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2121">HTTP status code</span></span>      | <span data-ttu-id="01424-2122">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2122">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2123">200</span><span class="sxs-lookup"><span data-stu-id="01424-2123">200</span></span> | <span data-ttu-id="01424-2124">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2124">OK</span></span> |
| <span data-ttu-id="01424-2125">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2125">4XX</span></span> | <span data-ttu-id="01424-2126">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2126">Error codes</span></span> |
| <span data-ttu-id="01424-2127">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2127">5XX</span></span> | <span data-ttu-id="01424-2128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2128">Error codes</span></span> |

**<span data-ttu-id="01424-2129">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2129">Available device families</span></span>**

* <span data-ttu-id="01424-2130">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2130">Windows Mobile</span></span>
* <span data-ttu-id="01424-2131">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2131">Windows Desktop</span></span>
* <span data-ttu-id="01424-2132">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2132">HoloLens</span></span>
* <span data-ttu-id="01424-2133">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2133">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2134">起動パフォーマンス トレース セッションを停止する</span><span class="sxs-lookup"><span data-stu-id="01424-2134">Stop a boot performance tracing session</span></span>

**<span data-ttu-id="01424-2135">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2135">Request</span></span>**

<span data-ttu-id="01424-2136">次の要求形式を使用して、WPR の起動トレース セッションを停止できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2136">You can stop a boot WPR tracing session by using the following request format.</span></span> <span data-ttu-id="01424-2137">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="01424-2137">This is also known as a performance tracing session.</span></span>
 
| <span data-ttu-id="01424-2138">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2138">Method</span></span>      | <span data-ttu-id="01424-2139">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2139">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2140">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2140">GET</span></span> | <span data-ttu-id="01424-2141">/api/wpr/boottrace</span><span class="sxs-lookup"><span data-stu-id="01424-2141">/api/wpr/boottrace</span></span> |


**<span data-ttu-id="01424-2142">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2142">URI parameters</span></span>**

- <span data-ttu-id="01424-2143">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2143">None</span></span>

**<span data-ttu-id="01424-2144">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2144">Request headers</span></span>**

- <span data-ttu-id="01424-2145">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2145">None</span></span>

**<span data-ttu-id="01424-2146">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2146">Request body</span></span>**

- <span data-ttu-id="01424-2147">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2147">None</span></span>

**<span data-ttu-id="01424-2148">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2148">Response</span></span>**

-  <span data-ttu-id="01424-2149">なし。</span><span class="sxs-lookup"><span data-stu-id="01424-2149">None.</span></span>  <span data-ttu-id="01424-2150">**注:** これは、実行時間の長い操作です。</span><span class="sxs-lookup"><span data-stu-id="01424-2150">**Note:** This is a long running operation.</span></span>  <span data-ttu-id="01424-2151">ETL のディスクへの書き込みが終了すると、制御が戻ります。</span><span class="sxs-lookup"><span data-stu-id="01424-2151">It will return when the ETL is finished writing to disk.</span></span>

**<span data-ttu-id="01424-2152">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2152">Status code</span></span>**

<span data-ttu-id="01424-2153">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2153">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2154">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2154">HTTP status code</span></span>      | <span data-ttu-id="01424-2155">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2155">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2156">200</span><span class="sxs-lookup"><span data-stu-id="01424-2156">200</span></span> | <span data-ttu-id="01424-2157">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2157">OK</span></span> |
| <span data-ttu-id="01424-2158">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2158">4XX</span></span> | <span data-ttu-id="01424-2159">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2159">Error codes</span></span> |
| <span data-ttu-id="01424-2160">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2160">5XX</span></span> | <span data-ttu-id="01424-2161">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2161">Error codes</span></span> |

**<span data-ttu-id="01424-2162">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2162">Available device families</span></span>**

* <span data-ttu-id="01424-2163">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2163">Windows Mobile</span></span>
* <span data-ttu-id="01424-2164">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2164">Windows Desktop</span></span>
* <span data-ttu-id="01424-2165">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2165">HoloLens</span></span>
* <span data-ttu-id="01424-2166">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2166">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2167">パフォーマンス トレース セッションを開始する</span><span class="sxs-lookup"><span data-stu-id="01424-2167">Start a performance tracing session</span></span>

**<span data-ttu-id="01424-2168">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2168">Request</span></span>**

<span data-ttu-id="01424-2169">次の要求形式を使用して、WPR のトレース セッションを開始できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2169">You can start a WPR tracing session by using the following request format.</span></span> <span data-ttu-id="01424-2170">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="01424-2170">This is also known as a performance tracing session.</span></span>  <span data-ttu-id="01424-2171">一度に実行できるトレースは 1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="01424-2171">Only one trace can run at a time.</span></span> 
 
| <span data-ttu-id="01424-2172">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2172">Method</span></span>      | <span data-ttu-id="01424-2173">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2173">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2174">POST</span><span class="sxs-lookup"><span data-stu-id="01424-2174">POST</span></span> | <span data-ttu-id="01424-2175">/api/wpr/trace</span><span class="sxs-lookup"><span data-stu-id="01424-2175">/api/wpr/trace</span></span> |


**<span data-ttu-id="01424-2176">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2176">URI parameters</span></span>**

<span data-ttu-id="01424-2177">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2177">You can specify the following additional parameters on the request URI:</span></span>

| <span data-ttu-id="01424-2178">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2178">URI parameter</span></span> | <span data-ttu-id="01424-2179">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2179">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-2180">プロファイル</span><span class="sxs-lookup"><span data-stu-id="01424-2180">profile</span></span>   | <span data-ttu-id="01424-2181">(**必須**) パフォーマンス トレース セッションを開始する必要があるプロファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2181">(**required**) The name of the profile that should start a performance tracing session.</span></span> <span data-ttu-id="01424-2182">指定可能なプロファイルは、perfprofiles/profiles.json に格納されています。</span><span class="sxs-lookup"><span data-stu-id="01424-2182">The possible profiles are stored in perfprofiles/profiles.json.</span></span> |

**<span data-ttu-id="01424-2183">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2183">Request headers</span></span>**

- <span data-ttu-id="01424-2184">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2184">None</span></span>

**<span data-ttu-id="01424-2185">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2185">Request body</span></span>**

- <span data-ttu-id="01424-2186">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2186">None</span></span>

**<span data-ttu-id="01424-2187">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2187">Response</span></span>**

<span data-ttu-id="01424-2188">この API は、開始時に次の形式で WPR セッション状態を返します。</span><span class="sxs-lookup"><span data-stu-id="01424-2188">On start, this API returns the WPR session status in the following format.</span></span>

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal)
}
```

**<span data-ttu-id="01424-2189">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2189">Status code</span></span>**

<span data-ttu-id="01424-2190">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2190">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2191">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2191">HTTP status code</span></span>      | <span data-ttu-id="01424-2192">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2192">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2193">200</span><span class="sxs-lookup"><span data-stu-id="01424-2193">200</span></span> | <span data-ttu-id="01424-2194">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2194">OK</span></span> |
| <span data-ttu-id="01424-2195">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2195">4XX</span></span> | <span data-ttu-id="01424-2196">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2196">Error codes</span></span> |
| <span data-ttu-id="01424-2197">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2197">5XX</span></span> | <span data-ttu-id="01424-2198">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2198">Error codes</span></span> |

**<span data-ttu-id="01424-2199">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2199">Available device families</span></span>**

* <span data-ttu-id="01424-2200">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2200">Windows Mobile</span></span>
* <span data-ttu-id="01424-2201">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2201">Windows Desktop</span></span>
* <span data-ttu-id="01424-2202">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2202">HoloLens</span></span>
* <span data-ttu-id="01424-2203">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2203">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2204">パフォーマンスのトレース セッションを停止する</span><span class="sxs-lookup"><span data-stu-id="01424-2204">Stop a performance tracing session</span></span>

**<span data-ttu-id="01424-2205">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2205">Request</span></span>**

<span data-ttu-id="01424-2206">次の要求形式を使用して、WPR のトレース セッションを停止できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2206">You can stop a WPR tracing session by using the following request format.</span></span> <span data-ttu-id="01424-2207">これは、パフォーマンス トレース セッションとも呼びます。</span><span class="sxs-lookup"><span data-stu-id="01424-2207">This is also known as a performance tracing session.</span></span>
 
| <span data-ttu-id="01424-2208">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2208">Method</span></span>      | <span data-ttu-id="01424-2209">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2209">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2210">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2210">GET</span></span> | <span data-ttu-id="01424-2211">/api/wpr/trace</span><span class="sxs-lookup"><span data-stu-id="01424-2211">/api/wpr/trace</span></span> |


**<span data-ttu-id="01424-2212">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2212">URI parameters</span></span>**

- <span data-ttu-id="01424-2213">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2213">None</span></span>

**<span data-ttu-id="01424-2214">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2214">Request headers</span></span>**

- <span data-ttu-id="01424-2215">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2215">None</span></span>

**<span data-ttu-id="01424-2216">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2216">Request body</span></span>**

- <span data-ttu-id="01424-2217">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2217">None</span></span>

**<span data-ttu-id="01424-2218">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2218">Response</span></span>**

- <span data-ttu-id="01424-2219">なし。</span><span class="sxs-lookup"><span data-stu-id="01424-2219">None.</span></span>  <span data-ttu-id="01424-2220">**注:** これは、実行時間の長い操作です。</span><span class="sxs-lookup"><span data-stu-id="01424-2220">**Note:** This is a long running operation.</span></span>  <span data-ttu-id="01424-2221">ETL のディスクへの書き込みが終了すると、制御が戻ります。</span><span class="sxs-lookup"><span data-stu-id="01424-2221">It will return when the ETL is finished writing to disk.</span></span>  

**<span data-ttu-id="01424-2222">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2222">Status code</span></span>**

<span data-ttu-id="01424-2223">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2223">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2224">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2224">HTTP status code</span></span>      | <span data-ttu-id="01424-2225">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2225">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2226">200</span><span class="sxs-lookup"><span data-stu-id="01424-2226">200</span></span> | <span data-ttu-id="01424-2227">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2227">OK</span></span> |
| <span data-ttu-id="01424-2228">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2228">4XX</span></span> | <span data-ttu-id="01424-2229">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2229">Error codes</span></span> |
| <span data-ttu-id="01424-2230">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2230">5XX</span></span> | <span data-ttu-id="01424-2231">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2231">Error codes</span></span> |

**<span data-ttu-id="01424-2232">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2232">Available device families</span></span>**

* <span data-ttu-id="01424-2233">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2233">Windows Mobile</span></span>
* <span data-ttu-id="01424-2234">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2234">Windows Desktop</span></span>
* <span data-ttu-id="01424-2235">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2235">HoloLens</span></span>
* <span data-ttu-id="01424-2236">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2236">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2237">トレース セッションの状態を取得する</span><span class="sxs-lookup"><span data-stu-id="01424-2237">Retrieve the status of a tracing session</span></span>

**<span data-ttu-id="01424-2238">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2238">Request</span></span>**

<span data-ttu-id="01424-2239">次の要求形式を使用して、現在の WPR セッションの状態を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2239">You can retrieve the status of the current WPR session by using the following request format.</span></span>
 
| <span data-ttu-id="01424-2240">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2240">Method</span></span>      | <span data-ttu-id="01424-2241">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2241">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2242">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2242">GET</span></span> | <span data-ttu-id="01424-2243">/api/wpr/status</span><span class="sxs-lookup"><span data-stu-id="01424-2243">/api/wpr/status</span></span> |


**<span data-ttu-id="01424-2244">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2244">URI parameters</span></span>**

- <span data-ttu-id="01424-2245">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2245">None</span></span>

**<span data-ttu-id="01424-2246">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2246">Request headers</span></span>**

- <span data-ttu-id="01424-2247">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2247">None</span></span>

**<span data-ttu-id="01424-2248">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2248">Request body</span></span>**

- <span data-ttu-id="01424-2249">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2249">None</span></span>

**<span data-ttu-id="01424-2250">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2250">Response</span></span>**

<span data-ttu-id="01424-2251">WPR トレース セッションの状態の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-2251">The status of the WPR tracing session in the following format.</span></span>

```json
{
    "SessionType": string, (Running or Idle) 
    "State": string (normal or boot)
}
```

**<span data-ttu-id="01424-2252">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2252">Status code</span></span>**

<span data-ttu-id="01424-2253">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2253">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2254">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2254">HTTP status code</span></span>      | <span data-ttu-id="01424-2255">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2255">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2256">200</span><span class="sxs-lookup"><span data-stu-id="01424-2256">200</span></span> | <span data-ttu-id="01424-2257">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2257">OK</span></span> |
| <span data-ttu-id="01424-2258">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2258">4XX</span></span> | <span data-ttu-id="01424-2259">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2259">Error codes</span></span> |
| <span data-ttu-id="01424-2260">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2260">5XX</span></span> | <span data-ttu-id="01424-2261">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2261">Error codes</span></span> |

**<span data-ttu-id="01424-2262">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2262">Available device families</span></span>**

* <span data-ttu-id="01424-2263">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2263">Windows Mobile</span></span>
* <span data-ttu-id="01424-2264">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2264">Windows Desktop</span></span>
* <span data-ttu-id="01424-2265">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2265">HoloLens</span></span>
* <span data-ttu-id="01424-2266">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2266">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2267">完了したトレース セッション (ETL) を一覧表示する</span><span class="sxs-lookup"><span data-stu-id="01424-2267">List completed tracing sessions (ETLs)</span></span>

**<span data-ttu-id="01424-2268">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2268">Request</span></span>**

<span data-ttu-id="01424-2269">次の要求形式を使用して、デバイス上の ETL トレースの一覧を取得できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2269">You can get a listing of ETL traces on the device using the following request format.</span></span> 

| <span data-ttu-id="01424-2270">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2270">Method</span></span>      | <span data-ttu-id="01424-2271">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2271">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2272">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2272">GET</span></span> | <span data-ttu-id="01424-2273">/api/wpr/tracefiles</span><span class="sxs-lookup"><span data-stu-id="01424-2273">/api/wpr/tracefiles</span></span> |


**<span data-ttu-id="01424-2274">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2274">URI parameters</span></span>**

- <span data-ttu-id="01424-2275">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2275">None</span></span>

**<span data-ttu-id="01424-2276">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2276">Request headers</span></span>**

- <span data-ttu-id="01424-2277">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2277">None</span></span>

**<span data-ttu-id="01424-2278">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2278">Request body</span></span>**

- <span data-ttu-id="01424-2279">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2279">None</span></span>

**<span data-ttu-id="01424-2280">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2280">Response</span></span>**

<span data-ttu-id="01424-2281">完了したトレース セッションの一覧は次の形式で提供されます。</span><span class="sxs-lookup"><span data-stu-id="01424-2281">The listing of completed tracing sessions is provided in the following format.</span></span>

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

**<span data-ttu-id="01424-2282">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2282">Status code</span></span>**

<span data-ttu-id="01424-2283">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2283">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2284">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2284">HTTP status code</span></span>      | <span data-ttu-id="01424-2285">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2285">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2286">200</span><span class="sxs-lookup"><span data-stu-id="01424-2286">200</span></span> | <span data-ttu-id="01424-2287">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2287">OK</span></span> |
| <span data-ttu-id="01424-2288">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2288">4XX</span></span> | <span data-ttu-id="01424-2289">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2289">Error codes</span></span> |
| <span data-ttu-id="01424-2290">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2290">5XX</span></span> | <span data-ttu-id="01424-2291">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2291">Error codes</span></span> |

**<span data-ttu-id="01424-2292">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2292">Available device families</span></span>**

* <span data-ttu-id="01424-2293">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2293">Windows Mobile</span></span>
* <span data-ttu-id="01424-2294">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2294">Windows Desktop</span></span>
* <span data-ttu-id="01424-2295">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2295">HoloLens</span></span>
* <span data-ttu-id="01424-2296">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2296">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2297">トレース セッション (ETL) をダウンロードする</span><span class="sxs-lookup"><span data-stu-id="01424-2297">Download a tracing session (ETL)</span></span>

**<span data-ttu-id="01424-2298">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2298">Request</span></span>**

<span data-ttu-id="01424-2299">次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) をダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="01424-2299">You can download a tracefile (boot trace or user-mode trace) using the following request format.</span></span> 

| <span data-ttu-id="01424-2300">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2300">Method</span></span>      | <span data-ttu-id="01424-2301">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2301">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2302">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2302">GET</span></span> | <span data-ttu-id="01424-2303">/api/wpr/tracefile</span><span class="sxs-lookup"><span data-stu-id="01424-2303">/api/wpr/tracefile</span></span> |


**<span data-ttu-id="01424-2304">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2304">URI parameters</span></span>**

<span data-ttu-id="01424-2305">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2305">You can specify the following additional parameter on the request URI:</span></span>

| <span data-ttu-id="01424-2306">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2306">URI parameter</span></span> | <span data-ttu-id="01424-2307">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2307">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-2308">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="01424-2308">filename</span></span>   | <span data-ttu-id="01424-2309">(**必須**) ダウンロードする ETL トレースの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2309">(**required**) The name of the ETL trace to download.</span></span>  <span data-ttu-id="01424-2310">これらは /api/wpr/tracefiles にあります。</span><span class="sxs-lookup"><span data-stu-id="01424-2310">These can be found in /api/wpr/tracefiles</span></span> |

**<span data-ttu-id="01424-2311">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2311">Request headers</span></span>**

- <span data-ttu-id="01424-2312">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2312">None</span></span>

**<span data-ttu-id="01424-2313">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2313">Request body</span></span>**

- <span data-ttu-id="01424-2314">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2314">None</span></span>

**<span data-ttu-id="01424-2315">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2315">Response</span></span>**

- <span data-ttu-id="01424-2316">トレース ETL ファイルを返します。</span><span class="sxs-lookup"><span data-stu-id="01424-2316">Returns the trace ETL file.</span></span>

**<span data-ttu-id="01424-2317">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2317">Status code</span></span>**

<span data-ttu-id="01424-2318">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2318">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2319">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2319">HTTP status code</span></span>      | <span data-ttu-id="01424-2320">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2320">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2321">200</span><span class="sxs-lookup"><span data-stu-id="01424-2321">200</span></span> | <span data-ttu-id="01424-2322">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2322">OK</span></span> |
| <span data-ttu-id="01424-2323">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2323">4XX</span></span> | <span data-ttu-id="01424-2324">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2324">Error codes</span></span> |
| <span data-ttu-id="01424-2325">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2325">5XX</span></span> | <span data-ttu-id="01424-2326">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2326">Error codes</span></span> |

**<span data-ttu-id="01424-2327">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2327">Available device families</span></span>**

* <span data-ttu-id="01424-2328">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2328">Windows Mobile</span></span>
* <span data-ttu-id="01424-2329">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2329">Windows Desktop</span></span>
* <span data-ttu-id="01424-2330">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2330">HoloLens</span></span>
* <span data-ttu-id="01424-2331">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2331">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2332">トレース セッション (ETL) を削除する</span><span class="sxs-lookup"><span data-stu-id="01424-2332">Delete a tracing session (ETL)</span></span>

**<span data-ttu-id="01424-2333">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2333">Request</span></span>**

<span data-ttu-id="01424-2334">次の要求形式を使用して、トレースファイル (ブート トレースまたはユーザー モード トレース) を削除できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2334">You can delete a tracefile (boot trace or user-mode trace) using the following request format.</span></span> 

| <span data-ttu-id="01424-2335">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2335">Method</span></span>      | <span data-ttu-id="01424-2336">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2336">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2337">Del</span><span class="sxs-lookup"><span data-stu-id="01424-2337">DELETE</span></span> | <span data-ttu-id="01424-2338">/api/wpr/tracefile</span><span class="sxs-lookup"><span data-stu-id="01424-2338">/api/wpr/tracefile</span></span> |


**<span data-ttu-id="01424-2339">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2339">URI parameters</span></span>**

<span data-ttu-id="01424-2340">次の追加パラメーターを要求 URI に指定できます。</span><span class="sxs-lookup"><span data-stu-id="01424-2340">You can specify the following additional parameter on the request URI:</span></span>

| <span data-ttu-id="01424-2341">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2341">URI parameter</span></span> | <span data-ttu-id="01424-2342">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2342">Description</span></span> |
| :------          | :------ |
| <span data-ttu-id="01424-2343">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="01424-2343">filename</span></span>   | <span data-ttu-id="01424-2344">(**必須**) 削除する ETL トレースの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2344">(**required**) The name of the ETL trace to delete.</span></span>  <span data-ttu-id="01424-2345">これらは /api/wpr/tracefiles にあります。</span><span class="sxs-lookup"><span data-stu-id="01424-2345">These can be found in /api/wpr/tracefiles</span></span> |

**<span data-ttu-id="01424-2346">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2346">Request headers</span></span>**

- <span data-ttu-id="01424-2347">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2347">None</span></span>

**<span data-ttu-id="01424-2348">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2348">Request body</span></span>**

- <span data-ttu-id="01424-2349">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2349">None</span></span>

**<span data-ttu-id="01424-2350">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2350">Response</span></span>**

- <span data-ttu-id="01424-2351">トレース ETL ファイルを返します。</span><span class="sxs-lookup"><span data-stu-id="01424-2351">Returns the trace ETL file.</span></span>

**<span data-ttu-id="01424-2352">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2352">Status code</span></span>**

<span data-ttu-id="01424-2353">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2353">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2354">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2354">HTTP status code</span></span>      | <span data-ttu-id="01424-2355">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2355">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2356">200</span><span class="sxs-lookup"><span data-stu-id="01424-2356">200</span></span> | <span data-ttu-id="01424-2357">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2357">OK</span></span> |
| <span data-ttu-id="01424-2358">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2358">4XX</span></span> | <span data-ttu-id="01424-2359">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2359">Error codes</span></span> |
| <span data-ttu-id="01424-2360">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2360">5XX</span></span> | <span data-ttu-id="01424-2361">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2361">Error codes</span></span> |

**<span data-ttu-id="01424-2362">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2362">Available device families</span></span>**

* <span data-ttu-id="01424-2363">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2363">Windows Mobile</span></span>
* <span data-ttu-id="01424-2364">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2364">Windows Desktop</span></span>
* <span data-ttu-id="01424-2365">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2365">HoloLens</span></span>
* <span data-ttu-id="01424-2366">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2366">IoT</span></span>

<hr>
## <span data-ttu-id="01424-2367">DNS SD タグ</span><span class="sxs-lookup"><span data-stu-id="01424-2367">DNS-SD Tags</span></span> 
<hr>
### <span data-ttu-id="01424-2368">タグを表示する</span><span class="sxs-lookup"><span data-stu-id="01424-2368">View Tags</span></span>

**<span data-ttu-id="01424-2369">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2369">Request</span></span>**

<span data-ttu-id="01424-2370">デバイスに現在適用されているタグを表示します。</span><span class="sxs-lookup"><span data-stu-id="01424-2370">View the currently applied tags for the device.</span></span>  <span data-ttu-id="01424-2371">これらのタグは、T キー内の DNS-SD TXT レコードを使用してアドバタイズされます。</span><span class="sxs-lookup"><span data-stu-id="01424-2371">These are advertised via DNS-SD TXT records in the T key.</span></span>  
 
| <span data-ttu-id="01424-2372">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2372">Method</span></span>      | <span data-ttu-id="01424-2373">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2373">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2374">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2374">GET</span></span> | <span data-ttu-id="01424-2375">/api/dns-sd/tags</span><span class="sxs-lookup"><span data-stu-id="01424-2375">/api/dns-sd/tags</span></span> |


**<span data-ttu-id="01424-2376">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2376">URI parameters</span></span>**

- <span data-ttu-id="01424-2377">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2377">None</span></span>

**<span data-ttu-id="01424-2378">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2378">Request headers</span></span>**

- <span data-ttu-id="01424-2379">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2379">None</span></span>

**<span data-ttu-id="01424-2380">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2380">Request body</span></span>**

- <span data-ttu-id="01424-2381">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2381">None</span></span>

<span data-ttu-id="01424-2382">**応答** 現在適用されているタグの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-2382">**Response** The currently applied tags in the following format.</span></span> 
```json
 {
    "tags": [
        "tag1", 
        "tag2", 
        ...
     ]
}
```

**<span data-ttu-id="01424-2383">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2383">Status code</span></span>**

<span data-ttu-id="01424-2384">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2384">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2385">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2385">HTTP status code</span></span>      | <span data-ttu-id="01424-2386">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2386">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2387">200</span><span class="sxs-lookup"><span data-stu-id="01424-2387">200</span></span> | <span data-ttu-id="01424-2388">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2388">OK</span></span> |
| <span data-ttu-id="01424-2389">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2389">5XX</span></span> | <span data-ttu-id="01424-2390">サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="01424-2390">Server Error</span></span> |


**<span data-ttu-id="01424-2391">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2391">Available device families</span></span>**

* <span data-ttu-id="01424-2392">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2392">Windows Mobile</span></span>
* <span data-ttu-id="01424-2393">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2393">Windows Desktop</span></span>
* <span data-ttu-id="01424-2394">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2394">Xbox</span></span>
* <span data-ttu-id="01424-2395">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2395">HoloLens</span></span>
* <span data-ttu-id="01424-2396">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2396">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2397">タグを削除する</span><span class="sxs-lookup"><span data-stu-id="01424-2397">Delete Tags</span></span>

**<span data-ttu-id="01424-2398">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2398">Request</span></span>**

<span data-ttu-id="01424-2399">DNS-SD によって現在アドバタイズされているすべてのタグを削除します。</span><span class="sxs-lookup"><span data-stu-id="01424-2399">Delete all tags currently advertised by DNS-SD.</span></span>   
 
| <span data-ttu-id="01424-2400">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2400">Method</span></span>      | <span data-ttu-id="01424-2401">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2401">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2402">Del</span><span class="sxs-lookup"><span data-stu-id="01424-2402">DELETE</span></span> | <span data-ttu-id="01424-2403">/api/dns-sd/tags</span><span class="sxs-lookup"><span data-stu-id="01424-2403">/api/dns-sd/tags</span></span> |


**<span data-ttu-id="01424-2404">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2404">URI parameters</span></span>**

- <span data-ttu-id="01424-2405">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2405">None</span></span>

**<span data-ttu-id="01424-2406">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2406">Request headers</span></span>**

- <span data-ttu-id="01424-2407">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2407">None</span></span>

**<span data-ttu-id="01424-2408">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2408">Request body</span></span>**

- <span data-ttu-id="01424-2409">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2409">None</span></span>

**<span data-ttu-id="01424-2410">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2410">Response</span></span>**
 - <span data-ttu-id="01424-2411">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2411">None</span></span>

**<span data-ttu-id="01424-2412">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2412">Status code</span></span>**

<span data-ttu-id="01424-2413">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2413">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2414">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2414">HTTP status code</span></span>      | <span data-ttu-id="01424-2415">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2415">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2416">200</span><span class="sxs-lookup"><span data-stu-id="01424-2416">200</span></span> | <span data-ttu-id="01424-2417">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2417">OK</span></span> |
| <span data-ttu-id="01424-2418">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2418">5XX</span></span> | <span data-ttu-id="01424-2419">サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="01424-2419">Server Error</span></span> |


**<span data-ttu-id="01424-2420">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2420">Available device families</span></span>**

* <span data-ttu-id="01424-2421">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2421">Windows Mobile</span></span>
* <span data-ttu-id="01424-2422">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2422">Windows Desktop</span></span>
* <span data-ttu-id="01424-2423">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2423">Xbox</span></span>
* <span data-ttu-id="01424-2424">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2424">HoloLens</span></span>
* <span data-ttu-id="01424-2425">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2425">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2426">タグを削除する</span><span class="sxs-lookup"><span data-stu-id="01424-2426">Delete Tag</span></span>

**<span data-ttu-id="01424-2427">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2427">Request</span></span>**

<span data-ttu-id="01424-2428">DNS-SD によって現在アドバタイズされている 1 つのタグを削除します。</span><span class="sxs-lookup"><span data-stu-id="01424-2428">Delete a tag currently advertised by DNS-SD.</span></span>   
 
| <span data-ttu-id="01424-2429">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2429">Method</span></span>      | <span data-ttu-id="01424-2430">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2430">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2431">Del</span><span class="sxs-lookup"><span data-stu-id="01424-2431">DELETE</span></span> | <span data-ttu-id="01424-2432">/api/dns-sd/tag</span><span class="sxs-lookup"><span data-stu-id="01424-2432">/api/dns-sd/tag</span></span> |


**<span data-ttu-id="01424-2433">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2433">URI parameters</span></span>**

| <span data-ttu-id="01424-2434">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2434">URI parameter</span></span> | <span data-ttu-id="01424-2435">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2435">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2436">tagValue</span><span class="sxs-lookup"><span data-stu-id="01424-2436">tagValue</span></span> | <span data-ttu-id="01424-2437">(**必須**) 削除するタグ。</span><span class="sxs-lookup"><span data-stu-id="01424-2437">(**required**) The tag to be removed.</span></span> |

**<span data-ttu-id="01424-2438">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2438">Request headers</span></span>**

- <span data-ttu-id="01424-2439">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2439">None</span></span>

**<span data-ttu-id="01424-2440">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2440">Request body</span></span>**

- <span data-ttu-id="01424-2441">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2441">None</span></span>

**<span data-ttu-id="01424-2442">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2442">Response</span></span>**
 - <span data-ttu-id="01424-2443">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2443">None</span></span>

**<span data-ttu-id="01424-2444">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2444">Status code</span></span>**

<span data-ttu-id="01424-2445">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2445">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2446">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2446">HTTP status code</span></span>      | <span data-ttu-id="01424-2447">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2447">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2448">200</span><span class="sxs-lookup"><span data-stu-id="01424-2448">200</span></span> | <span data-ttu-id="01424-2449">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2449">OK</span></span> |


**<span data-ttu-id="01424-2450">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2450">Available device families</span></span>**

* <span data-ttu-id="01424-2451">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2451">Windows Mobile</span></span>
* <span data-ttu-id="01424-2452">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2452">Windows Desktop</span></span>
* <span data-ttu-id="01424-2453">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2453">Xbox</span></span>
* <span data-ttu-id="01424-2454">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2454">HoloLens</span></span>
* <span data-ttu-id="01424-2455">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2455">IoT</span></span>
 
<hr>
### <span data-ttu-id="01424-2456">タグを追加する</span><span class="sxs-lookup"><span data-stu-id="01424-2456">Add a Tag</span></span>

**<span data-ttu-id="01424-2457">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2457">Request</span></span>**

<span data-ttu-id="01424-2458">DNS-SD アドバタイズにタグを追加します。</span><span class="sxs-lookup"><span data-stu-id="01424-2458">Add a tag to the DNS-SD advertisement.</span></span>   
 
| <span data-ttu-id="01424-2459">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2459">Method</span></span>      | <span data-ttu-id="01424-2460">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2460">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2461">POST</span><span class="sxs-lookup"><span data-stu-id="01424-2461">POST</span></span> | <span data-ttu-id="01424-2462">/api/dns-sd/tag</span><span class="sxs-lookup"><span data-stu-id="01424-2462">/api/dns-sd/tag</span></span> |


**<span data-ttu-id="01424-2463">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2463">URI parameters</span></span>**

| <span data-ttu-id="01424-2464">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2464">URI parameter</span></span> | <span data-ttu-id="01424-2465">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2465">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2466">tagValue</span><span class="sxs-lookup"><span data-stu-id="01424-2466">tagValue</span></span> | <span data-ttu-id="01424-2467">(**必要**) 追加するタグ。</span><span class="sxs-lookup"><span data-stu-id="01424-2467">(**required**) The tag to be added.</span></span> |

**<span data-ttu-id="01424-2468">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2468">Request headers</span></span>**

- <span data-ttu-id="01424-2469">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2469">None</span></span>

**<span data-ttu-id="01424-2470">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2470">Request body</span></span>**

- <span data-ttu-id="01424-2471">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2471">None</span></span>

**<span data-ttu-id="01424-2472">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2472">Response</span></span>**
 - <span data-ttu-id="01424-2473">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2473">None</span></span>

**<span data-ttu-id="01424-2474">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2474">Status code</span></span>**

<span data-ttu-id="01424-2475">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2475">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2476">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2476">HTTP status code</span></span>      | <span data-ttu-id="01424-2477">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2477">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2478">200</span><span class="sxs-lookup"><span data-stu-id="01424-2478">200</span></span> | <span data-ttu-id="01424-2479">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2479">OK</span></span> |
| <span data-ttu-id="01424-2480">401</span><span class="sxs-lookup"><span data-stu-id="01424-2480">401</span></span> | <span data-ttu-id="01424-2481">タグ領域のオーバーフロー。</span><span class="sxs-lookup"><span data-stu-id="01424-2481">Tag space Overflow.</span></span>  <span data-ttu-id="01424-2482">提供されたタグが、結果として生成される DNS-SD サービス レコードに対して長すぎます。</span><span class="sxs-lookup"><span data-stu-id="01424-2482">Results when the proposed tag is too long for the resulting DNS-SD service record.</span></span> |


**<span data-ttu-id="01424-2483">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2483">Available device families</span></span>**

* <span data-ttu-id="01424-2484">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2484">Windows Mobile</span></span>
* <span data-ttu-id="01424-2485">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2485">Windows Desktop</span></span>
* <span data-ttu-id="01424-2486">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2486">Xbox</span></span>
* <span data-ttu-id="01424-2487">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2487">HoloLens</span></span>
* <span data-ttu-id="01424-2488">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2488">IoT</span></span>

## <a name="app-file-explorer"></a><span data-ttu-id="01424-2489">アプリのエクスプローラー</span><span class="sxs-lookup"><span data-stu-id="01424-2489">App File Explorer</span></span>

<hr>
### <span data-ttu-id="01424-2490">既知のフォルダーを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-2490">Get known folders</span></span>

**<span data-ttu-id="01424-2491">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2491">Request</span></span>**

<span data-ttu-id="01424-2492">アクセス可能なトップ レベル フォルダーの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="01424-2492">Obtain a list of accessible top-level folders.</span></span>

| <span data-ttu-id="01424-2493">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2493">Method</span></span>      | <span data-ttu-id="01424-2494">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2494">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2495">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2495">GET</span></span> | <span data-ttu-id="01424-2496">/api/filesystem/apps/knownfolders</span><span class="sxs-lookup"><span data-stu-id="01424-2496">/api/filesystem/apps/knownfolders</span></span> |


**<span data-ttu-id="01424-2497">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2497">URI parameters</span></span>**

- <span data-ttu-id="01424-2498">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2498">None</span></span>

**<span data-ttu-id="01424-2499">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2499">Request headers</span></span>**

- <span data-ttu-id="01424-2500">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2500">None</span></span>

**<span data-ttu-id="01424-2501">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2501">Request body</span></span>**

- <span data-ttu-id="01424-2502">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2502">None</span></span>

<span data-ttu-id="01424-2503">**応答** 利用可能なフォルダーの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-2503">**Response** The available folders in the following format.</span></span> 
```json
 {"KnownFolders": [
    "folder0",
    "folder1",...
]}
```
**<span data-ttu-id="01424-2504">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2504">Status code</span></span>**

<span data-ttu-id="01424-2505">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2505">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2506">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2506">HTTP status code</span></span>      | <span data-ttu-id="01424-2507">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2507">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2508">200</span><span class="sxs-lookup"><span data-stu-id="01424-2508">200</span></span> | <span data-ttu-id="01424-2509">展開要求は受け入れられ、処理されています。</span><span class="sxs-lookup"><span data-stu-id="01424-2509">Deploy request accepted and being processed</span></span> |
| <span data-ttu-id="01424-2510">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2510">4XX</span></span> | <span data-ttu-id="01424-2511">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2511">Error codes</span></span> |
| <span data-ttu-id="01424-2512">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2512">5XX</span></span> | <span data-ttu-id="01424-2513">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2513">Error codes</span></span> |


**<span data-ttu-id="01424-2514">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2514">Available device families</span></span>**

* <span data-ttu-id="01424-2515">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2515">Windows Mobile</span></span>
* <span data-ttu-id="01424-2516">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2516">Windows Desktop</span></span>
* <span data-ttu-id="01424-2517">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2517">HoloLens</span></span>
* <span data-ttu-id="01424-2518">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2518">Xbox</span></span>
* <span data-ttu-id="01424-2519">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2519">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2520">ファイルを取得する</span><span class="sxs-lookup"><span data-stu-id="01424-2520">Get files</span></span>

**<span data-ttu-id="01424-2521">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2521">Request</span></span>**

<span data-ttu-id="01424-2522">フォルダー内のファイルの一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="01424-2522">Obtain a list of files in a folder.</span></span>

| <span data-ttu-id="01424-2523">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2523">Method</span></span>      | <span data-ttu-id="01424-2524">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2524">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2525">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2525">GET</span></span> | <span data-ttu-id="01424-2526">/api/filesystem/apps/files</span><span class="sxs-lookup"><span data-stu-id="01424-2526">/api/filesystem/apps/files</span></span> |


**<span data-ttu-id="01424-2527">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2527">URI parameters</span></span>**

| <span data-ttu-id="01424-2528">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2528">URI parameter</span></span> | <span data-ttu-id="01424-2529">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2529">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2530">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="01424-2530">knownfolderid</span></span> | <span data-ttu-id="01424-2531">(**必須**) 必要なファイルの一覧の対象となるトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2531">(**required**) The top-level directory where you want the list of files.</span></span> <span data-ttu-id="01424-2532">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="01424-2532">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="01424-2533">packagefullname</span><span class="sxs-lookup"><span data-stu-id="01424-2533">packagefullname</span></span> | <span data-ttu-id="01424-2534">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="01424-2534">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> |
| <span data-ttu-id="01424-2535">path</span><span class="sxs-lookup"><span data-stu-id="01424-2535">path</span></span> | <span data-ttu-id="01424-2536">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2536">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

**<span data-ttu-id="01424-2537">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2537">Request headers</span></span>**

- <span data-ttu-id="01424-2538">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2538">None</span></span>

**<span data-ttu-id="01424-2539">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2539">Request body</span></span>**

- <span data-ttu-id="01424-2540">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2540">None</span></span>

<span data-ttu-id="01424-2541">**応答** 利用可能なフォルダーの形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="01424-2541">**Response** The available folders in the following format.</span></span> 
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
**<span data-ttu-id="01424-2542">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2542">Status code</span></span>**

<span data-ttu-id="01424-2543">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2543">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2544">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2544">HTTP status code</span></span>      | <span data-ttu-id="01424-2545">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2545">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2546">200</span><span class="sxs-lookup"><span data-stu-id="01424-2546">200</span></span> | <span data-ttu-id="01424-2547">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2547">OK</span></span> |
| <span data-ttu-id="01424-2548">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2548">4XX</span></span> | <span data-ttu-id="01424-2549">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2549">Error codes</span></span> |
| <span data-ttu-id="01424-2550">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2550">5XX</span></span> | <span data-ttu-id="01424-2551">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2551">Error codes</span></span> |

**<span data-ttu-id="01424-2552">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2552">Available device families</span></span>**

* <span data-ttu-id="01424-2553">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2553">Windows Mobile</span></span>
* <span data-ttu-id="01424-2554">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2554">Windows Desktop</span></span>
* <span data-ttu-id="01424-2555">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2555">HoloLens</span></span>
* <span data-ttu-id="01424-2556">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2556">Xbox</span></span>
* <span data-ttu-id="01424-2557">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2557">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2558">ファイルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="01424-2558">Download a file</span></span>

**<span data-ttu-id="01424-2559">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2559">Request</span></span>**

<span data-ttu-id="01424-2560">既知のフォルダーまたは appLocalData からファイルを取得します。</span><span class="sxs-lookup"><span data-stu-id="01424-2560">Obtain a file from a known folder or appLocalData.</span></span>

| <span data-ttu-id="01424-2561">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2561">Method</span></span>      | <span data-ttu-id="01424-2562">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2562">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2563">GET</span><span class="sxs-lookup"><span data-stu-id="01424-2563">GET</span></span> | <span data-ttu-id="01424-2564">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="01424-2564">/api/filesystem/apps/file</span></span> |

**<span data-ttu-id="01424-2565">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2565">URI parameters</span></span>**

| <span data-ttu-id="01424-2566">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2566">URI parameter</span></span> | <span data-ttu-id="01424-2567">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2567">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2568">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="01424-2568">knownfolderid</span></span> | <span data-ttu-id="01424-2569">(**必須**) ファイルをダウンロードするトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2569">(**required**) The top-level directory where you want to download files.</span></span> <span data-ttu-id="01424-2570">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="01424-2570">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="01424-2571">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="01424-2571">filename</span></span> | <span data-ttu-id="01424-2572">(**必須**) ダウンロードするファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2572">(**required**) The name of the file being downloaded.</span></span> |
| <span data-ttu-id="01424-2573">packagefullname</span><span class="sxs-lookup"><span data-stu-id="01424-2573">packagefullname</span></span> | <span data-ttu-id="01424-2574">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="01424-2574">(**required if *knownfolderid* == LocalAppData**) The package full name you are interested in.</span></span> |
| <span data-ttu-id="01424-2575">path</span><span class="sxs-lookup"><span data-stu-id="01424-2575">path</span></span> | <span data-ttu-id="01424-2576">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2576">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

**<span data-ttu-id="01424-2577">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2577">Request headers</span></span>**

- <span data-ttu-id="01424-2578">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2578">None</span></span>

**<span data-ttu-id="01424-2579">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2579">Request body</span></span>**

- <span data-ttu-id="01424-2580">要求するファイル (存在する場合)</span><span class="sxs-lookup"><span data-stu-id="01424-2580">The file requested, if present</span></span>

**<span data-ttu-id="01424-2581">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2581">Response</span></span>**

**<span data-ttu-id="01424-2582">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2582">Status code</span></span>**

<span data-ttu-id="01424-2583">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2583">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2584">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2584">HTTP status code</span></span>      | <span data-ttu-id="01424-2585">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2585">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2586">200</span><span class="sxs-lookup"><span data-stu-id="01424-2586">200</span></span> | <span data-ttu-id="01424-2587">要求したファイル</span><span class="sxs-lookup"><span data-stu-id="01424-2587">The requested file</span></span> |
| <span data-ttu-id="01424-2588">404</span><span class="sxs-lookup"><span data-stu-id="01424-2588">404</span></span> | <span data-ttu-id="01424-2589">ファイルが見つからない</span><span class="sxs-lookup"><span data-stu-id="01424-2589">File not found</span></span> |
| <span data-ttu-id="01424-2590">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2590">5XX</span></span> | <span data-ttu-id="01424-2591">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2591">Error codes</span></span> |

**<span data-ttu-id="01424-2592">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2592">Available device families</span></span>**

* <span data-ttu-id="01424-2593">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2593">Windows Mobile</span></span>
* <span data-ttu-id="01424-2594">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2594">Windows Desktop</span></span>
* <span data-ttu-id="01424-2595">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2595">HoloLens</span></span>
* <span data-ttu-id="01424-2596">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2596">Xbox</span></span>
* <span data-ttu-id="01424-2597">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2597">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2598">ファイルの名前の変更</span><span class="sxs-lookup"><span data-stu-id="01424-2598">Rename a file</span></span>

**<span data-ttu-id="01424-2599">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2599">Request</span></span>**

<span data-ttu-id="01424-2600">フォルダー内のファイルの名前を変更します。</span><span class="sxs-lookup"><span data-stu-id="01424-2600">Rename a file in a folder.</span></span>

| <span data-ttu-id="01424-2601">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2601">Method</span></span>      | <span data-ttu-id="01424-2602">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2602">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2603">POST</span><span class="sxs-lookup"><span data-stu-id="01424-2603">POST</span></span> | <span data-ttu-id="01424-2604">/api/filesystem/apps/rename</span><span class="sxs-lookup"><span data-stu-id="01424-2604">/api/filesystem/apps/rename</span></span> |


**<span data-ttu-id="01424-2605">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2605">URI parameters</span></span>**

| <span data-ttu-id="01424-2606">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2606">URI parameter</span></span> | <span data-ttu-id="01424-2607">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2607">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2608">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="01424-2608">knownfolderid</span></span> | <span data-ttu-id="01424-2609">(**必須**) ファイルが存在するトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2609">(**required**) The top-level directory where the file is located.</span></span> <span data-ttu-id="01424-2610">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="01424-2610">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="01424-2611">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="01424-2611">filename</span></span> | <span data-ttu-id="01424-2612">(**必須**) 名前を変更するファイルの元の名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2612">(**required**) The original name of the file being renamed.</span></span> |
| <span data-ttu-id="01424-2613">newfilename</span><span class="sxs-lookup"><span data-stu-id="01424-2613">newfilename</span></span> | <span data-ttu-id="01424-2614">(**必須**) ファイルの新しい名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2614">(**required**) The new name of the file.</span></span>|
| <span data-ttu-id="01424-2615">packagefullname</span><span class="sxs-lookup"><span data-stu-id="01424-2615">packagefullname</span></span> | <span data-ttu-id="01424-2616">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="01424-2616">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> |
| <span data-ttu-id="01424-2617">path</span><span class="sxs-lookup"><span data-stu-id="01424-2617">path</span></span> | <span data-ttu-id="01424-2618">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2618">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

**<span data-ttu-id="01424-2619">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2619">Request headers</span></span>**

- <span data-ttu-id="01424-2620">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2620">None</span></span>

**<span data-ttu-id="01424-2621">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2621">Request body</span></span>**

- <span data-ttu-id="01424-2622">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2622">None</span></span>

**<span data-ttu-id="01424-2623">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2623">Response</span></span>**

- <span data-ttu-id="01424-2624">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2624">None</span></span>

**<span data-ttu-id="01424-2625">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2625">Status code</span></span>**

<span data-ttu-id="01424-2626">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2626">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2627">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2627">HTTP status code</span></span>      | <span data-ttu-id="01424-2628">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2628">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2629">200</span><span class="sxs-lookup"><span data-stu-id="01424-2629">200</span></span> | <span data-ttu-id="01424-2630">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2630">OK</span></span> |<span data-ttu-id="01424-2631">.</span><span class="sxs-lookup"><span data-stu-id="01424-2631">.</span></span> <span data-ttu-id="01424-2632">ファイルの名前が変更されました</span><span class="sxs-lookup"><span data-stu-id="01424-2632">The file is renamed</span></span>
| <span data-ttu-id="01424-2633">404</span><span class="sxs-lookup"><span data-stu-id="01424-2633">404</span></span> | <span data-ttu-id="01424-2634">ファイルが見つからない</span><span class="sxs-lookup"><span data-stu-id="01424-2634">File not found</span></span> |
| <span data-ttu-id="01424-2635">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2635">5XX</span></span> | <span data-ttu-id="01424-2636">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2636">Error codes</span></span> |

**<span data-ttu-id="01424-2637">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2637">Available device families</span></span>**

* <span data-ttu-id="01424-2638">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2638">Windows Mobile</span></span>
* <span data-ttu-id="01424-2639">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2639">Windows Desktop</span></span>
* <span data-ttu-id="01424-2640">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2640">HoloLens</span></span>
* <span data-ttu-id="01424-2641">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2641">Xbox</span></span>
* <span data-ttu-id="01424-2642">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2642">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2643">ファイルを削除する</span><span class="sxs-lookup"><span data-stu-id="01424-2643">Delete a file</span></span>

**<span data-ttu-id="01424-2644">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2644">Request</span></span>**

<span data-ttu-id="01424-2645">フォルダー内のファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="01424-2645">Delete a file in a folder.</span></span>

| <span data-ttu-id="01424-2646">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2646">Method</span></span>      | <span data-ttu-id="01424-2647">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2647">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2648">Del</span><span class="sxs-lookup"><span data-stu-id="01424-2648">DELETE</span></span> | <span data-ttu-id="01424-2649">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="01424-2649">/api/filesystem/apps/file</span></span> |

**<span data-ttu-id="01424-2650">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2650">URI parameters</span></span>**

| <span data-ttu-id="01424-2651">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2651">URI parameter</span></span> | <span data-ttu-id="01424-2652">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2652">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2653">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="01424-2653">knownfolderid</span></span> | <span data-ttu-id="01424-2654">(**必須**) ファイルを削除するトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2654">(**required**) The top-level directory where you want to delete files.</span></span> <span data-ttu-id="01424-2655">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="01424-2655">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="01424-2656">&lt;ファイル名&gt;</span><span class="sxs-lookup"><span data-stu-id="01424-2656">filename</span></span> | <span data-ttu-id="01424-2657">(**必須**) 削除するファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="01424-2657">(**required**) The name of the file being deleted.</span></span> |
| <span data-ttu-id="01424-2658">packagefullname</span><span class="sxs-lookup"><span data-stu-id="01424-2658">packagefullname</span></span> | <span data-ttu-id="01424-2659">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="01424-2659">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> |
| <span data-ttu-id="01424-2660">path</span><span class="sxs-lookup"><span data-stu-id="01424-2660">path</span></span> | <span data-ttu-id="01424-2661">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2661">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

**<span data-ttu-id="01424-2662">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2662">Request headers</span></span>**

- <span data-ttu-id="01424-2663">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2663">None</span></span>

**<span data-ttu-id="01424-2664">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2664">Request body</span></span>**

- <span data-ttu-id="01424-2665">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2665">None</span></span>

**<span data-ttu-id="01424-2666">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2666">Response</span></span>**

- <span data-ttu-id="01424-2667">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2667">None</span></span> 

**<span data-ttu-id="01424-2668">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2668">Status code</span></span>**

<span data-ttu-id="01424-2669">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2669">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2670">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2670">HTTP status code</span></span>      | <span data-ttu-id="01424-2671">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2671">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2672">200</span><span class="sxs-lookup"><span data-stu-id="01424-2672">200</span></span> | <span data-ttu-id="01424-2673">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2673">OK</span></span> |<span data-ttu-id="01424-2674">.</span><span class="sxs-lookup"><span data-stu-id="01424-2674">.</span></span> <span data-ttu-id="01424-2675">ファイルが削除されます。</span><span class="sxs-lookup"><span data-stu-id="01424-2675">The file is deleted</span></span> |
| <span data-ttu-id="01424-2676">404</span><span class="sxs-lookup"><span data-stu-id="01424-2676">404</span></span> | <span data-ttu-id="01424-2677">ファイルが見つからない</span><span class="sxs-lookup"><span data-stu-id="01424-2677">File not found</span></span> |
| <span data-ttu-id="01424-2678">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2678">5XX</span></span> | <span data-ttu-id="01424-2679">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2679">Error codes</span></span> |

**<span data-ttu-id="01424-2680">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2680">Available device families</span></span>**

* <span data-ttu-id="01424-2681">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2681">Windows Mobile</span></span>
* <span data-ttu-id="01424-2682">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2682">Windows Desktop</span></span>
* <span data-ttu-id="01424-2683">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2683">HoloLens</span></span>
* <span data-ttu-id="01424-2684">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2684">Xbox</span></span>
* <span data-ttu-id="01424-2685">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2685">IoT</span></span>

<hr>
### <span data-ttu-id="01424-2686">ファイルをアップロードする</span><span class="sxs-lookup"><span data-stu-id="01424-2686">Upload a file</span></span>

**<span data-ttu-id="01424-2687">要求</span><span class="sxs-lookup"><span data-stu-id="01424-2687">Request</span></span>**

<span data-ttu-id="01424-2688">フォルダーにファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="01424-2688">Upload a file to a folder.</span></span>  <span data-ttu-id="01424-2689">この場合、同じ名前を持つ既存のファイルは上書きされますが、新しいフォルダーは作成されません。</span><span class="sxs-lookup"><span data-stu-id="01424-2689">This will overwrite an existing file with the same name, but will not create new folders.</span></span> 

| <span data-ttu-id="01424-2690">メソッド</span><span class="sxs-lookup"><span data-stu-id="01424-2690">Method</span></span>      | <span data-ttu-id="01424-2691">要求 URI</span><span class="sxs-lookup"><span data-stu-id="01424-2691">Request URI</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2692">POST</span><span class="sxs-lookup"><span data-stu-id="01424-2692">POST</span></span> | <span data-ttu-id="01424-2693">/api/filesystem/apps/file</span><span class="sxs-lookup"><span data-stu-id="01424-2693">/api/filesystem/apps/file</span></span> |

**<span data-ttu-id="01424-2694">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2694">URI parameters</span></span>**

| <span data-ttu-id="01424-2695">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="01424-2695">URI parameter</span></span> | <span data-ttu-id="01424-2696">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2696">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2697">knownfolderid</span><span class="sxs-lookup"><span data-stu-id="01424-2697">knownfolderid</span></span> | <span data-ttu-id="01424-2698">(**必須**) ファイルをアップロードするトップレベル ディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2698">(**required**) The top-level directory where you want to upload files.</span></span> <span data-ttu-id="01424-2699">サイドロードされたアプリにアクセスするには、**LocalAppData** を使用します。</span><span class="sxs-lookup"><span data-stu-id="01424-2699">Use **LocalAppData** for access to sideloaded apps.</span></span> |
| <span data-ttu-id="01424-2700">packagefullname</span><span class="sxs-lookup"><span data-stu-id="01424-2700">packagefullname</span></span> | <span data-ttu-id="01424-2701">(***knownfolderid* == LocalAppData の場合は必須**) 対象となるアプリのパッケージのフルネーム。</span><span class="sxs-lookup"><span data-stu-id="01424-2701">(**required if *knownfolderid* == LocalAppData**) The package full name of the app you are interested in.</span></span> |
| <span data-ttu-id="01424-2702">path</span><span class="sxs-lookup"><span data-stu-id="01424-2702">path</span></span> | <span data-ttu-id="01424-2703">(**オプション**) 上で指定したフォルダーまたはパッケージ内のサブディレクトリ。</span><span class="sxs-lookup"><span data-stu-id="01424-2703">(**optional**) The sub-directory within the folder or package specified above.</span></span> |

**<span data-ttu-id="01424-2704">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="01424-2704">Request headers</span></span>**

- <span data-ttu-id="01424-2705">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2705">None</span></span>

**<span data-ttu-id="01424-2706">要求本文</span><span class="sxs-lookup"><span data-stu-id="01424-2706">Request body</span></span>**

- <span data-ttu-id="01424-2707">なし</span><span class="sxs-lookup"><span data-stu-id="01424-2707">None</span></span>

**<span data-ttu-id="01424-2708">応答</span><span class="sxs-lookup"><span data-stu-id="01424-2708">Response</span></span>**

**<span data-ttu-id="01424-2709">状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2709">Status code</span></span>**

<span data-ttu-id="01424-2710">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="01424-2710">This API has the following expected status codes.</span></span>

| <span data-ttu-id="01424-2711">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="01424-2711">HTTP status code</span></span>      | <span data-ttu-id="01424-2712">説明</span><span class="sxs-lookup"><span data-stu-id="01424-2712">Description</span></span> |
| :------     | :----- |
| <span data-ttu-id="01424-2713">200</span><span class="sxs-lookup"><span data-stu-id="01424-2713">200</span></span> | <span data-ttu-id="01424-2714">OK</span><span class="sxs-lookup"><span data-stu-id="01424-2714">OK</span></span> |<span data-ttu-id="01424-2715">.</span><span class="sxs-lookup"><span data-stu-id="01424-2715">.</span></span> <span data-ttu-id="01424-2716">ファイルがアップロードされます。</span><span class="sxs-lookup"><span data-stu-id="01424-2716">The file is uploaded</span></span> |
| <span data-ttu-id="01424-2717">4XX</span><span class="sxs-lookup"><span data-stu-id="01424-2717">4XX</span></span> | <span data-ttu-id="01424-2718">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2718">Error codes</span></span> |
| <span data-ttu-id="01424-2719">5XX</span><span class="sxs-lookup"><span data-stu-id="01424-2719">5XX</span></span> | <span data-ttu-id="01424-2720">エラー コード</span><span class="sxs-lookup"><span data-stu-id="01424-2720">Error codes</span></span> |

**<span data-ttu-id="01424-2721">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="01424-2721">Available device families</span></span>**

* <span data-ttu-id="01424-2722">Windows Mobile</span><span class="sxs-lookup"><span data-stu-id="01424-2722">Windows Mobile</span></span>
* <span data-ttu-id="01424-2723">Windows Desktop</span><span class="sxs-lookup"><span data-stu-id="01424-2723">Windows Desktop</span></span>
* <span data-ttu-id="01424-2724">HoloLens</span><span class="sxs-lookup"><span data-stu-id="01424-2724">HoloLens</span></span>
* <span data-ttu-id="01424-2725">Xbox</span><span class="sxs-lookup"><span data-stu-id="01424-2725">Xbox</span></span>
* <span data-ttu-id="01424-2726">IoT</span><span class="sxs-lookup"><span data-stu-id="01424-2726">IoT</span></span>
