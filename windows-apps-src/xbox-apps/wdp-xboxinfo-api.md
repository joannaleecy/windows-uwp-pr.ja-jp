---
title: デバイス ポータル Xbox 情報 API リファレンス
description: Xbox デバイス情報にアクセスする方法について説明します。
ms.date: 11/072017
ms.topic: article
keywords: windows 10、uwp、xbox、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 85c2c139aa8064e1f0769064b95eeb531086b8c1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617497"
---
# <a name="xbox-info-api-reference"></a><span data-ttu-id="80914-104">Xbox 情報 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="80914-104">Xbox Info API reference</span></span>   
<span data-ttu-id="80914-105">この API を使うと、Xbox One デバイス情報にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="80914-105">You can access Xbox One device information using this API.</span></span>

## <a name="get-xbox-one-device-information"></a><span data-ttu-id="80914-106">Xbox One デバイス情報を取得する</span><span class="sxs-lookup"><span data-stu-id="80914-106">Get Xbox One device information</span></span>

<span data-ttu-id="80914-107">**要求**</span><span class="sxs-lookup"><span data-stu-id="80914-107">**Request**</span></span>

<span data-ttu-id="80914-108">Xbox One に関するデバイス情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="80914-108">You can get device information about your Xbox One.</span></span>

<span data-ttu-id="80914-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="80914-109">Method</span></span>      | <span data-ttu-id="80914-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="80914-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="80914-111">GET</span><span class="sxs-lookup"><span data-stu-id="80914-111">GET</span></span> | <span data-ttu-id="80914-112">/ext/xbox/info</span><span class="sxs-lookup"><span data-stu-id="80914-112">/ext/xbox/info</span></span>
<br />
<span data-ttu-id="80914-113">**URI パラメーター**</span><span class="sxs-lookup"><span data-stu-id="80914-113">**URI parameters**</span></span>

- <span data-ttu-id="80914-114">なし</span><span class="sxs-lookup"><span data-stu-id="80914-114">None</span></span>

<span data-ttu-id="80914-115">**要求ヘッダー**</span><span class="sxs-lookup"><span data-stu-id="80914-115">**Request headers**</span></span>

- <span data-ttu-id="80914-116">なし</span><span class="sxs-lookup"><span data-stu-id="80914-116">None</span></span>

<span data-ttu-id="80914-117">**要求本文**</span><span class="sxs-lookup"><span data-stu-id="80914-117">**Request body**</span></span>

- <span data-ttu-id="80914-118">なし</span><span class="sxs-lookup"><span data-stu-id="80914-118">None</span></span>

<span data-ttu-id="80914-119">**応答** </span><span class="sxs-lookup"><span data-stu-id="80914-119">**Response** </span></span>  
<span data-ttu-id="80914-120">次のフィールドを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="80914-120">A JSON object with the following fields:</span></span>

* <span data-ttu-id="80914-121">OsVersion - (文字列) OS のバージョン。</span><span class="sxs-lookup"><span data-stu-id="80914-121">OsVersion - (String) The version of the OS.</span></span>
* <span data-ttu-id="80914-122">OsEdition - (文字列) OS のエディション ("March 2017" や "March 2017 QFE 1" など)。</span><span class="sxs-lookup"><span data-stu-id="80914-122">OsEdition - (String) The edition of the OS, such as "March 2017" or "March 2017 QFE 1".</span></span>
* <span data-ttu-id="80914-123">ConsoleId - (文字列) コンソールの ID。</span><span class="sxs-lookup"><span data-stu-id="80914-123">ConsoleId - (String) The console's ID.</span></span>
* <span data-ttu-id="80914-124">DeviceId - (文字列) コンソールの Xbox Live デバイス ID。</span><span class="sxs-lookup"><span data-stu-id="80914-124">DeviceId - (String) The console's Xbox Live Device Id.</span></span>
* <span data-ttu-id="80914-125">SerialNumber - (文字列) コンソールのシリアル番号。</span><span class="sxs-lookup"><span data-stu-id="80914-125">SerialNumber - (String) The console's serial number.</span></span>
* <span data-ttu-id="80914-126">DevMode - (文字列) コンソールの現在の開発者モード ("None" や "Retail" など)。</span><span class="sxs-lookup"><span data-stu-id="80914-126">DevMode - (String) The console's current developer mode, such as "None" or "Retail".</span></span>
* <span data-ttu-id="80914-127">ConsoleType - (文字列) コンソールの種類 ("Xbox One" や "Xbox One S" など)。</span><span class="sxs-lookup"><span data-stu-id="80914-127">ConsoleType - (String) The console's type, such as "Xbox One" or "Xbox One S".</span></span>
* <span data-ttu-id="80914-128">DevkitCertificateExpirationTime - (数値) コンソールの開発者キット証明書の有効期限が切れる UTC 時刻 (秒単位)。</span><span class="sxs-lookup"><span data-stu-id="80914-128">DevkitCertificateExpirationTime - (Number) The UTC Time in seconds when the console's developer kit certificate will expire.</span></span>

<span data-ttu-id="80914-129">**状態コード**</span><span class="sxs-lookup"><span data-stu-id="80914-129">**Status code**</span></span>

<span data-ttu-id="80914-130">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="80914-130">This API has the following expected status codes.</span></span>

<span data-ttu-id="80914-131">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="80914-131">HTTP status code</span></span>      | <span data-ttu-id="80914-132">説明</span><span class="sxs-lookup"><span data-stu-id="80914-132">Description</span></span>
:------     | :-----
<span data-ttu-id="80914-133">200</span><span class="sxs-lookup"><span data-stu-id="80914-133">200</span></span> | <span data-ttu-id="80914-134">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="80914-134">Request was successful</span></span>
<span data-ttu-id="80914-135">4XX</span><span class="sxs-lookup"><span data-stu-id="80914-135">4XX</span></span> | <span data-ttu-id="80914-136">エラー コード</span><span class="sxs-lookup"><span data-stu-id="80914-136">Error codes</span></span>
<span data-ttu-id="80914-137">5XX</span><span class="sxs-lookup"><span data-stu-id="80914-137">5XX</span></span> | <span data-ttu-id="80914-138">エラー コード</span><span class="sxs-lookup"><span data-stu-id="80914-138">Error codes</span></span>

<br />
<span data-ttu-id="80914-139">**使用可能なデバイス ファミリ**</span><span class="sxs-lookup"><span data-stu-id="80914-139">**Available device families**</span></span>

* <span data-ttu-id="80914-140">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="80914-140">Windows Xbox</span></span>