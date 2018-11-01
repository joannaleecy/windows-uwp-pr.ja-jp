---
author: M-Stahl
title: デバイス Xbox のポータル情報 API リファレンス
description: Xbox デバイスの情報にアクセスする方法をについて説明します。
ms.author: mstahl
ms.date: 11/7/2017
ms.topic: article
keywords: windows 10、uwp、xbox、デバイスのポータル
ms.localizationpriority: medium
ms.openlocfilehash: 4b0e2bab0ce7d5525e8032809954ff656a74a61c
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919895"
---
# <a name="xbox-info-api-reference"></a><span data-ttu-id="7b32f-104">Xbox 情報 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="7b32f-104">Xbox Info API reference</span></span>   
<span data-ttu-id="7b32f-105">この API を使用して Xbox を 1 つのデバイス情報にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="7b32f-105">You can access Xbox One device information using this API.</span></span>

## <a name="get-xbox-one-device-information"></a><span data-ttu-id="7b32f-106">Xbox が 1 つのデバイス情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="7b32f-106">Get Xbox One device information</span></span>

**<span data-ttu-id="7b32f-107">要求</span><span class="sxs-lookup"><span data-stu-id="7b32f-107">Request</span></span>**

<span data-ttu-id="7b32f-108">Xbox 1 つのデバイス情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="7b32f-108">You can get device information about your Xbox One.</span></span>

<span data-ttu-id="7b32f-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="7b32f-109">Method</span></span>      | <span data-ttu-id="7b32f-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="7b32f-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="7b32f-111">GET</span><span class="sxs-lookup"><span data-stu-id="7b32f-111">GET</span></span> | <span data-ttu-id="7b32f-112">/ext/xbox/info</span><span class="sxs-lookup"><span data-stu-id="7b32f-112">/ext/xbox/info</span></span>
<br />
**<span data-ttu-id="7b32f-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7b32f-113">URI parameters</span></span>**

- <span data-ttu-id="7b32f-114">なし</span><span class="sxs-lookup"><span data-stu-id="7b32f-114">None</span></span>

**<span data-ttu-id="7b32f-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7b32f-115">Request headers</span></span>**

- <span data-ttu-id="7b32f-116">なし</span><span class="sxs-lookup"><span data-stu-id="7b32f-116">None</span></span>

**<span data-ttu-id="7b32f-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="7b32f-117">Request body</span></span>**

- <span data-ttu-id="7b32f-118">なし</span><span class="sxs-lookup"><span data-stu-id="7b32f-118">None</span></span>

**<span data-ttu-id="7b32f-119">応答</span><span class="sxs-lookup"><span data-stu-id="7b32f-119">Response</span></span>**   
<span data-ttu-id="7b32f-120">次のフィールドを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="7b32f-120">A JSON object with the following fields:</span></span>

* <span data-ttu-id="7b32f-121">OsVersion - (文字列)、OS のバージョンです。</span><span class="sxs-lookup"><span data-stu-id="7b32f-121">OsVersion - (String) The version of the OS.</span></span>
* <span data-ttu-id="7b32f-122">OsEdition - (文字列)、OS のエディション」2017 年 3 月"など、または"2017年 3 月 QFE 1"。</span><span class="sxs-lookup"><span data-stu-id="7b32f-122">OsEdition - (String) The edition of the OS, such as "March 2017" or "March 2017 QFE 1".</span></span>
* <span data-ttu-id="7b32f-123">ConsoleId - (文字列)、コンソールの id。</span><span class="sxs-lookup"><span data-stu-id="7b32f-123">ConsoleId - (String) The console's ID.</span></span>
* <span data-ttu-id="7b32f-124">DeviceId を (文字列)、コンソールの Xbox Live デバイス id。</span><span class="sxs-lookup"><span data-stu-id="7b32f-124">DeviceId - (String) The console's Xbox Live Device Id.</span></span>
* <span data-ttu-id="7b32f-125">シリアル番号 - (文字列)、コンソールのシリアル番号。</span><span class="sxs-lookup"><span data-stu-id="7b32f-125">SerialNumber - (String) The console's serial number.</span></span>
* <span data-ttu-id="7b32f-126">DevMode の [なし] などの (文字列)、コンソールの現在の開発者モードまたは"Retail"です。</span><span class="sxs-lookup"><span data-stu-id="7b32f-126">DevMode - (String) The console's current developer mode, such as "None" or "Retail".</span></span>
* <span data-ttu-id="7b32f-127">ConsoleType -「Xbox」か「Xbox 1 S」など、(文字列)、コンソールのタイプです。</span><span class="sxs-lookup"><span data-stu-id="7b32f-127">ConsoleType - (String) The console's type, such as "Xbox One" or "Xbox One S".</span></span>
* <span data-ttu-id="7b32f-128">DevkitCertificateExpirationTime - (番号)、UTC 時間 (秒)、コンソールの開発者キットの証明書の期限が切れる。</span><span class="sxs-lookup"><span data-stu-id="7b32f-128">DevkitCertificateExpirationTime - (Number) The UTC Time in seconds when the console's developer kit certificate will expire.</span></span>

**<span data-ttu-id="7b32f-129">状態コード</span><span class="sxs-lookup"><span data-stu-id="7b32f-129">Status code</span></span>**

<span data-ttu-id="7b32f-130">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7b32f-130">This API has the following expected status codes.</span></span>

<span data-ttu-id="7b32f-131">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="7b32f-131">HTTP status code</span></span>      | <span data-ttu-id="7b32f-132">説明</span><span class="sxs-lookup"><span data-stu-id="7b32f-132">Description</span></span>
:------     | :-----
<span data-ttu-id="7b32f-133">200</span><span class="sxs-lookup"><span data-stu-id="7b32f-133">200</span></span> | <span data-ttu-id="7b32f-134">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="7b32f-134">Request was successful</span></span>
<span data-ttu-id="7b32f-135">4XX</span><span class="sxs-lookup"><span data-stu-id="7b32f-135">4XX</span></span> | <span data-ttu-id="7b32f-136">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7b32f-136">Error codes</span></span>
<span data-ttu-id="7b32f-137">5XX</span><span class="sxs-lookup"><span data-stu-id="7b32f-137">5XX</span></span> | <span data-ttu-id="7b32f-138">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7b32f-138">Error codes</span></span>

<br />
**<span data-ttu-id="7b32f-139">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="7b32f-139">Available device families</span></span>**

* <span data-ttu-id="7b32f-140">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="7b32f-140">Windows Xbox</span></span>