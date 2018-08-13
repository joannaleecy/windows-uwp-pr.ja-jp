---
author: M-Stahl
title: デバイス ポータル Xbox 情報 API リファレンス
description: Xbox デバイスの情報にアクセスする方法をについて説明します。
ms.author: mstahl
ms.date: 11/7/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、xbox、デバイスのポータル
ms.localizationpriority: medium
ms.openlocfilehash: db1df2418a2bb60de4a72f51ad01a0bfd547ec20
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608856"
---
# <a name="xbox-info-api-reference"></a><span data-ttu-id="e2b5c-104">Xbox 情報 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="e2b5c-104">Xbox Info API reference</span></span>   
<span data-ttu-id="e2b5c-105">この API を使用して Xbox 1 つのデバイスの情報にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-105">You can access Xbox One device information using this API.</span></span>

## <a name="get-xbox-one-device-information"></a><span data-ttu-id="e2b5c-106">デバイスの Xbox を 1 つの情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-106">Get Xbox One device information</span></span>

**<span data-ttu-id="e2b5c-107">要求</span><span class="sxs-lookup"><span data-stu-id="e2b5c-107">Request</span></span>**

<span data-ttu-id="e2b5c-108">1、Xbox については、デバイスの情報を入手できます。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-108">You can get device information about your Xbox One.</span></span>

<span data-ttu-id="e2b5c-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="e2b5c-109">Method</span></span>      | <span data-ttu-id="e2b5c-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="e2b5c-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="e2b5c-111">GET</span><span class="sxs-lookup"><span data-stu-id="e2b5c-111">GET</span></span> | <span data-ttu-id="e2b5c-112">/ext/xbox/info</span><span class="sxs-lookup"><span data-stu-id="e2b5c-112">/ext/xbox/info</span></span>
<br />
**<span data-ttu-id="e2b5c-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e2b5c-113">URI parameters</span></span>**

- <span data-ttu-id="e2b5c-114">なし</span><span class="sxs-lookup"><span data-stu-id="e2b5c-114">None</span></span>

**<span data-ttu-id="e2b5c-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e2b5c-115">Request headers</span></span>**

- <span data-ttu-id="e2b5c-116">なし</span><span class="sxs-lookup"><span data-stu-id="e2b5c-116">None</span></span>

**<span data-ttu-id="e2b5c-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="e2b5c-117">Request body</span></span>**

- <span data-ttu-id="e2b5c-118">なし</span><span class="sxs-lookup"><span data-stu-id="e2b5c-118">None</span></span>

**<span data-ttu-id="e2b5c-119">応答</span><span class="sxs-lookup"><span data-stu-id="e2b5c-119">Response</span></span>**   
<span data-ttu-id="e2b5c-120">次のフィールドを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-120">A JSON object with the following fields:</span></span>

* <span data-ttu-id="e2b5c-121">OsVersion - (文字列) OS のバージョンを使用します。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-121">OsVersion - (String) The version of the OS.</span></span>
* <span data-ttu-id="e2b5c-122">OsEdition - (文字列) OS のエディションなど"2017年 3 月"または"2017年 3 月 QFE 1" します。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-122">OsEdition - (String) The edition of the OS, such as "March 2017" or "March 2017 QFE 1".</span></span>
* <span data-ttu-id="e2b5c-123">ConsoleId - (文字列) コンソールの ID</span><span class="sxs-lookup"><span data-stu-id="e2b5c-123">ConsoleId - (String) The console's ID.</span></span>
* <span data-ttu-id="e2b5c-124">DeviceId - (文字列) コンソールの Xbox Live デバイス id。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-124">DeviceId - (String) The console's Xbox Live Device Id.</span></span>
* <span data-ttu-id="e2b5c-125">SerialNumber - (文字列) コンソールのシリアル値を使用します。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-125">SerialNumber - (String) The console's serial number.</span></span>
* <span data-ttu-id="e2b5c-126">DevMode -「なし」などの (文字列) コンソールの現在の開発者モードまたは「製品」します。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-126">DevMode - (String) The console's current developer mode, such as "None" or "Retail".</span></span>
* <span data-ttu-id="e2b5c-127">ConsoleType - (文字列) コンソールの種類] の「一 Xbox」または"Xbox 1 S"などです。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-127">ConsoleType - (String) The console's type, such as "Xbox One" or "Xbox One S".</span></span>
* <span data-ttu-id="e2b5c-128">DevkitCertificateExpirationTime - (数値)、時刻、コンソールの開発キットの証明書の有効期限が切れる秒数。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-128">DevkitCertificateExpirationTime - (Number) The UTC Time in seconds when the console's developer kit certificate will expire.</span></span>

**<span data-ttu-id="e2b5c-129">状態コード</span><span class="sxs-lookup"><span data-stu-id="e2b5c-129">Status code</span></span>**

<span data-ttu-id="e2b5c-130">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e2b5c-130">This API has the following expected status codes.</span></span>

<span data-ttu-id="e2b5c-131">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e2b5c-131">HTTP status code</span></span>      | <span data-ttu-id="e2b5c-132">説明</span><span class="sxs-lookup"><span data-stu-id="e2b5c-132">Description</span></span>
:------     | :-----
<span data-ttu-id="e2b5c-133">200</span><span class="sxs-lookup"><span data-stu-id="e2b5c-133">200</span></span> | <span data-ttu-id="e2b5c-134">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="e2b5c-134">Request was successful</span></span>
<span data-ttu-id="e2b5c-135">4XX</span><span class="sxs-lookup"><span data-stu-id="e2b5c-135">4XX</span></span> | <span data-ttu-id="e2b5c-136">エラー コード</span><span class="sxs-lookup"><span data-stu-id="e2b5c-136">Error codes</span></span>
<span data-ttu-id="e2b5c-137">5XX</span><span class="sxs-lookup"><span data-stu-id="e2b5c-137">5XX</span></span> | <span data-ttu-id="e2b5c-138">エラー コード</span><span class="sxs-lookup"><span data-stu-id="e2b5c-138">Error codes</span></span>

<br />
**<span data-ttu-id="e2b5c-139">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="e2b5c-139">Available device families</span></span>**

* <span data-ttu-id="e2b5c-140">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="e2b5c-140">Windows Xbox</span></span>