---
title: Device Portal の Xbox Live サンド ボックス API のリファレンス
description: Xbox Live サンド ボックスにプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 72c7459c-420a-4da9-8afa-191a846185a5
ms.localizationpriority: medium
ms.openlocfilehash: d05528ecf4408a7e7483b909b75722037c6528b7
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8482942"
---
# <a name="xbox-live-sandbox-api-reference"></a><span data-ttu-id="25278-104">Xbox Live サンド ボックス API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="25278-104">Xbox Live Sandbox API reference</span></span>   
<span data-ttu-id="25278-105">この REST API を使用して、Xbox Live サンド ボックスを取得および設定できます。</span><span class="sxs-lookup"><span data-stu-id="25278-105">You can get and set your Xbox Live sandbox using this REST API.</span></span>

## <a name="get-the-xbox-live-sandbox"></a><span data-ttu-id="25278-106">Xbox Live サンド ボックスを取得する</span><span class="sxs-lookup"><span data-stu-id="25278-106">Get the Xbox Live sandbox</span></span>

**<span data-ttu-id="25278-107">要求</span><span class="sxs-lookup"><span data-stu-id="25278-107">Request</span></span>**

<span data-ttu-id="25278-108">次の要求を使用して、デバイスの Xbox Live サンド ボックスの現在の値を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="25278-108">You can read the current value for the device's Xbox Live sandbox using the following request:</span></span>

<span data-ttu-id="25278-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="25278-109">Method</span></span>      | <span data-ttu-id="25278-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="25278-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="25278-111">GET</span><span class="sxs-lookup"><span data-stu-id="25278-111">GET</span></span> | <span data-ttu-id="25278-112">/ext/xboxlive/sandbox</span><span class="sxs-lookup"><span data-stu-id="25278-112">/ext/xboxlive/sandbox</span></span>
<br />
**<span data-ttu-id="25278-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="25278-113">URI parameters</span></span>**

- <span data-ttu-id="25278-114">なし</span><span class="sxs-lookup"><span data-stu-id="25278-114">None</span></span>

**<span data-ttu-id="25278-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25278-115">Request headers</span></span>**

- <span data-ttu-id="25278-116">なし</span><span class="sxs-lookup"><span data-stu-id="25278-116">None</span></span>

**<span data-ttu-id="25278-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="25278-117">Request body</span></span>**

- <span data-ttu-id="25278-118">なし</span><span class="sxs-lookup"><span data-stu-id="25278-118">None</span></span>

**<span data-ttu-id="25278-119">応答</span><span class="sxs-lookup"><span data-stu-id="25278-119">Response</span></span>**   
<span data-ttu-id="25278-120">Sandbox: (文字列) デバイスに適用されている現在のサンド ボックス。</span><span class="sxs-lookup"><span data-stu-id="25278-120">Sandbox - (String) The current Sandbox the device is in.</span></span>   

**<span data-ttu-id="25278-121">状態コード</span><span class="sxs-lookup"><span data-stu-id="25278-121">Status code</span></span>**

<span data-ttu-id="25278-122">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="25278-122">This API has the following expected status codes.</span></span>

<span data-ttu-id="25278-123">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="25278-123">HTTP status code</span></span>      | <span data-ttu-id="25278-124">説明</span><span class="sxs-lookup"><span data-stu-id="25278-124">Description</span></span>
:------     | :-----
<span data-ttu-id="25278-125">200</span><span class="sxs-lookup"><span data-stu-id="25278-125">200</span></span> | <span data-ttu-id="25278-126">ファイル共有の資格情報にアクセスする要求が許可されました。</span><span class="sxs-lookup"><span data-stu-id="25278-126">The request to access the credentials for the file share was granted.</span></span>
<span data-ttu-id="25278-127">4XX</span><span class="sxs-lookup"><span data-stu-id="25278-127">4XX</span></span> | <span data-ttu-id="25278-128">エラー コード</span><span class="sxs-lookup"><span data-stu-id="25278-128">Error codes</span></span>
<span data-ttu-id="25278-129">5XX</span><span class="sxs-lookup"><span data-stu-id="25278-129">5XX</span></span> | <span data-ttu-id="25278-130">エラー コード</span><span class="sxs-lookup"><span data-stu-id="25278-130">Error codes</span></span>

## <a name="set-the-xbox-live-sandbox"></a><span data-ttu-id="25278-131">Xbox Live サンド ボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="25278-131">Set the Xbox Live sandbox</span></span>
<span data-ttu-id="25278-132">次の要求を使用して、デバイスの Xbox Live サンド ボックスを変更できます。</span><span class="sxs-lookup"><span data-stu-id="25278-132">You can change the Xbox Live sandbox for the device using the following request.</span></span> <span data-ttu-id="25278-133">Xbox One では、設定を有効にするためにデバイスを再起動する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="25278-133">Note that on Xbox One, the device needs to be restarted before the setting takes effect.</span></span>

**<span data-ttu-id="25278-134">要求</span><span class="sxs-lookup"><span data-stu-id="25278-134">Request</span></span>**

<span data-ttu-id="25278-135">次の要求を使用して、デバイスの Xbox Live サンド ボックスの現在の値を設定できます。</span><span class="sxs-lookup"><span data-stu-id="25278-135">You can set the current value for the device's Xbox Live sandbox using the following request:</span></span>

<span data-ttu-id="25278-136">メソッド</span><span class="sxs-lookup"><span data-stu-id="25278-136">Method</span></span>      | <span data-ttu-id="25278-137">要求 URI</span><span class="sxs-lookup"><span data-stu-id="25278-137">Request URI</span></span>
:------     | :-----
<span data-ttu-id="25278-138">PUT</span><span class="sxs-lookup"><span data-stu-id="25278-138">PUT</span></span> | <span data-ttu-id="25278-139">/ext/xboxlive/sandbox</span><span class="sxs-lookup"><span data-stu-id="25278-139">/ext/xboxlive/sandbox</span></span>
<br />
**<span data-ttu-id="25278-140">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="25278-140">URI parameters</span></span>**

- <span data-ttu-id="25278-141">なし</span><span class="sxs-lookup"><span data-stu-id="25278-141">None</span></span>

**<span data-ttu-id="25278-142">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="25278-142">Request headers</span></span>**

- <span data-ttu-id="25278-143">なし</span><span class="sxs-lookup"><span data-stu-id="25278-143">None</span></span>

**<span data-ttu-id="25278-144">要求本文</span><span class="sxs-lookup"><span data-stu-id="25278-144">Request body</span></span>**   
<span data-ttu-id="25278-145">要求本文は、次のフィールドを含む JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="25278-145">The request body is a JSON object containing the following field:</span></span>   
<span data-ttu-id="25278-146">Sandbox: (文字列) デバイスのサンド ボックスに設定する新しい値。</span><span class="sxs-lookup"><span data-stu-id="25278-146">Sandbox - (String) The new value to set the device's sandbox to.</span></span>

**<span data-ttu-id="25278-147">応答</span><span class="sxs-lookup"><span data-stu-id="25278-147">Response</span></span>**   
<span data-ttu-id="25278-148">Sandbox: (文字列) デバイスに適用されている現在のサンド ボックス。</span><span class="sxs-lookup"><span data-stu-id="25278-148">Sandbox - (String) The current Sandbox the device is in.</span></span>   

**<span data-ttu-id="25278-149">状態コード</span><span class="sxs-lookup"><span data-stu-id="25278-149">Status code</span></span>**

<span data-ttu-id="25278-150">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="25278-150">This API has the following expected status codes.</span></span>

<span data-ttu-id="25278-151">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="25278-151">HTTP status code</span></span>      | <span data-ttu-id="25278-152">説明</span><span class="sxs-lookup"><span data-stu-id="25278-152">Description</span></span>
:------     | :-----
<span data-ttu-id="25278-153">200</span><span class="sxs-lookup"><span data-stu-id="25278-153">200</span></span> | <span data-ttu-id="25278-154">ファイル共有の資格情報にアクセスする要求が許可されました。</span><span class="sxs-lookup"><span data-stu-id="25278-154">The request to access the credentials for the file share was granted.</span></span>
<span data-ttu-id="25278-155">4XX</span><span class="sxs-lookup"><span data-stu-id="25278-155">4XX</span></span> | <span data-ttu-id="25278-156">エラー コード</span><span class="sxs-lookup"><span data-stu-id="25278-156">Error codes</span></span>
<span data-ttu-id="25278-157">5XX</span><span class="sxs-lookup"><span data-stu-id="25278-157">5XX</span></span> | <span data-ttu-id="25278-158">エラー コード</span><span class="sxs-lookup"><span data-stu-id="25278-158">Error codes</span></span>

<br />
**<span data-ttu-id="25278-159">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="25278-159">Available device families</span></span>**

* <span data-ttu-id="25278-160">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="25278-160">Windows Xbox</span></span>

