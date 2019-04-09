---
title: Device Portal の Xbox Live サンド ボックス API のリファレンス
description: Xbox Live サンド ボックスにプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 72c7459c-420a-4da9-8afa-191a846185a5
ms.localizationpriority: medium
ms.openlocfilehash: 8f04514962cf0684daa99ee75d4c4da73c785735
ms.sourcegitcommit: bad7ed6def79acbb4569de5a92c0717364e771d9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59244088"
---
# <a name="xbox-live-sandbox-api-reference"></a><span data-ttu-id="a7106-104">Xbox Live サンド ボックス API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="a7106-104">Xbox Live Sandbox API reference</span></span>   
<span data-ttu-id="a7106-105">この REST API を使用して、Xbox Live サンド ボックスを取得および設定できます。</span><span class="sxs-lookup"><span data-stu-id="a7106-105">You can get and set your Xbox Live sandbox using this REST API.</span></span>

## <a name="get-the-xbox-live-sandbox"></a><span data-ttu-id="a7106-106">Xbox Live サンド ボックスを取得する</span><span class="sxs-lookup"><span data-stu-id="a7106-106">Get the Xbox Live sandbox</span></span>

**<span data-ttu-id="a7106-107">要求</span><span class="sxs-lookup"><span data-stu-id="a7106-107">Request</span></span>**

<span data-ttu-id="a7106-108">次の要求を使用して、デバイスの Xbox Live サンド ボックスの現在の値を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="a7106-108">You can read the current value for the device's Xbox Live sandbox using the following request:</span></span>

<span data-ttu-id="a7106-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="a7106-109">Method</span></span>      | <span data-ttu-id="a7106-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a7106-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="a7106-111">GET</span><span class="sxs-lookup"><span data-stu-id="a7106-111">GET</span></span> | <span data-ttu-id="a7106-112">/ext/xboxlive/sandbox</span><span class="sxs-lookup"><span data-stu-id="a7106-112">/ext/xboxlive/sandbox</span></span>

**<span data-ttu-id="a7106-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7106-113">URI parameters</span></span>**

- <span data-ttu-id="a7106-114">なし</span><span class="sxs-lookup"><span data-stu-id="a7106-114">None</span></span>

**<span data-ttu-id="a7106-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a7106-115">Request headers</span></span>**

- <span data-ttu-id="a7106-116">なし</span><span class="sxs-lookup"><span data-stu-id="a7106-116">None</span></span>

**<span data-ttu-id="a7106-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="a7106-117">Request body</span></span>**

- <span data-ttu-id="a7106-118">なし</span><span class="sxs-lookup"><span data-stu-id="a7106-118">None</span></span>

**<span data-ttu-id="a7106-119">応答</span><span class="sxs-lookup"><span data-stu-id="a7106-119">Response</span></span>**   
<span data-ttu-id="a7106-120">Sandbox: (文字列) デバイスに適用されている現在のサンド ボックス。</span><span class="sxs-lookup"><span data-stu-id="a7106-120">Sandbox - (String) The current Sandbox the device is in.</span></span>   

**<span data-ttu-id="a7106-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="a7106-121">Status code</span></span>**

<span data-ttu-id="a7106-122">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a7106-122">This API has the following expected status codes.</span></span>

<span data-ttu-id="a7106-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a7106-123">HTTP status code</span></span>      | <span data-ttu-id="a7106-124">説明</span><span class="sxs-lookup"><span data-stu-id="a7106-124">Description</span></span>
:------     | :-----
<span data-ttu-id="a7106-125">200</span><span class="sxs-lookup"><span data-stu-id="a7106-125">200</span></span> | <span data-ttu-id="a7106-126">ファイル共有の資格情報にアクセスする要求が許可されました。</span><span class="sxs-lookup"><span data-stu-id="a7106-126">The request to access the credentials for the file share was granted.</span></span>
<span data-ttu-id="a7106-127">4XX</span><span class="sxs-lookup"><span data-stu-id="a7106-127">4XX</span></span> | <span data-ttu-id="a7106-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a7106-128">Error codes</span></span>
<span data-ttu-id="a7106-129">5XX</span><span class="sxs-lookup"><span data-stu-id="a7106-129">5XX</span></span> | <span data-ttu-id="a7106-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a7106-130">Error codes</span></span>

## <a name="set-the-xbox-live-sandbox"></a><span data-ttu-id="a7106-131">Xbox Live サンド ボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="a7106-131">Set the Xbox Live sandbox</span></span>
<span data-ttu-id="a7106-132">次の要求を使用して、デバイスの Xbox Live サンド ボックスを変更できます。</span><span class="sxs-lookup"><span data-stu-id="a7106-132">You can change the Xbox Live sandbox for the device using the following request.</span></span> <span data-ttu-id="a7106-133">Xbox One では、設定を有効にするためにデバイスを再起動する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="a7106-133">Note that on Xbox One, the device needs to be restarted before the setting takes effect.</span></span>

**<span data-ttu-id="a7106-134">要求</span><span class="sxs-lookup"><span data-stu-id="a7106-134">Request</span></span>**

<span data-ttu-id="a7106-135">次の要求を使用して、デバイスの Xbox Live サンド ボックスの現在の値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="a7106-135">You can set the current value for the device's Xbox Live sandbox using the following request:</span></span>

<span data-ttu-id="a7106-136">メソッド</span><span class="sxs-lookup"><span data-stu-id="a7106-136">Method</span></span>      | <span data-ttu-id="a7106-137">要求 URI</span><span class="sxs-lookup"><span data-stu-id="a7106-137">Request URI</span></span>
:------     | :-----
<span data-ttu-id="a7106-138">PUT</span><span class="sxs-lookup"><span data-stu-id="a7106-138">PUT</span></span> | <span data-ttu-id="a7106-139">/ext/xboxlive/sandbox</span><span class="sxs-lookup"><span data-stu-id="a7106-139">/ext/xboxlive/sandbox</span></span>

**<span data-ttu-id="a7106-140">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a7106-140">URI parameters</span></span>**

- <span data-ttu-id="a7106-141">なし</span><span class="sxs-lookup"><span data-stu-id="a7106-141">None</span></span>

**<span data-ttu-id="a7106-142">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a7106-142">Request headers</span></span>**

- <span data-ttu-id="a7106-143">なし</span><span class="sxs-lookup"><span data-stu-id="a7106-143">None</span></span>

**<span data-ttu-id="a7106-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="a7106-144">Request body</span></span>**   
<span data-ttu-id="a7106-145">要求本文は、次のフィールドを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="a7106-145">The request body is a JSON object containing the following field:</span></span>   
<span data-ttu-id="a7106-146">Sandbox: (文字列) デバイスのサンド ボックスに設定する新しい値。</span><span class="sxs-lookup"><span data-stu-id="a7106-146">Sandbox - (String) The new value to set the device's sandbox to.</span></span>

**<span data-ttu-id="a7106-147">応答</span><span class="sxs-lookup"><span data-stu-id="a7106-147">Response</span></span>**   
<span data-ttu-id="a7106-148">Sandbox: (文字列) デバイスに適用されている現在のサンド ボックス。</span><span class="sxs-lookup"><span data-stu-id="a7106-148">Sandbox - (String) The current Sandbox the device is in.</span></span>   

**<span data-ttu-id="a7106-149">状態コード</span><span class="sxs-lookup"><span data-stu-id="a7106-149">Status code</span></span>**

<span data-ttu-id="a7106-150">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a7106-150">This API has the following expected status codes.</span></span>

<span data-ttu-id="a7106-151">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="a7106-151">HTTP status code</span></span>      | <span data-ttu-id="a7106-152">説明</span><span class="sxs-lookup"><span data-stu-id="a7106-152">Description</span></span>
:------     | :-----
<span data-ttu-id="a7106-153">200</span><span class="sxs-lookup"><span data-stu-id="a7106-153">200</span></span> | <span data-ttu-id="a7106-154">ファイル共有の資格情報にアクセスする要求が許可されました。</span><span class="sxs-lookup"><span data-stu-id="a7106-154">The request to access the credentials for the file share was granted.</span></span>
<span data-ttu-id="a7106-155">4XX</span><span class="sxs-lookup"><span data-stu-id="a7106-155">4XX</span></span> | <span data-ttu-id="a7106-156">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a7106-156">Error codes</span></span>
<span data-ttu-id="a7106-157">5XX</span><span class="sxs-lookup"><span data-stu-id="a7106-157">5XX</span></span> | <span data-ttu-id="a7106-158">エラー コード</span><span class="sxs-lookup"><span data-stu-id="a7106-158">Error codes</span></span>

**<span data-ttu-id="a7106-159">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="a7106-159">Available device families</span></span>**

* <span data-ttu-id="a7106-160">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="a7106-160">Windows Xbox</span></span>

