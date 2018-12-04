---
title: Device Portal の Xbox 情報 API リファレンス
description: Xbox デバイス情報にアクセスする方法をについて説明します。
ms.date: 11/7/2017
ms.topic: article
keywords: windows 10, uwp, xbox, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: d7901890e1cc8fab24742e8785562d13d2fe182a
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8462941"
---
# <a name="xbox-info-api-reference"></a><span data-ttu-id="93ecf-104">Xbox 情報 API リファレンス</span><span class="sxs-lookup"><span data-stu-id="93ecf-104">Xbox Info API reference</span></span>   
<span data-ttu-id="93ecf-105">この API を使用して Xbox One のデバイス情報にアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="93ecf-105">You can access Xbox One device information using this API.</span></span>

## <a name="get-xbox-one-device-information"></a><span data-ttu-id="93ecf-106">Xbox One デバイス情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="93ecf-106">Get Xbox One device information</span></span>

**<span data-ttu-id="93ecf-107">要求</span><span class="sxs-lookup"><span data-stu-id="93ecf-107">Request</span></span>**

<span data-ttu-id="93ecf-108">Xbox One については、デバイスの情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="93ecf-108">You can get device information about your Xbox One.</span></span>

<span data-ttu-id="93ecf-109">メソッド</span><span class="sxs-lookup"><span data-stu-id="93ecf-109">Method</span></span>      | <span data-ttu-id="93ecf-110">要求 URI</span><span class="sxs-lookup"><span data-stu-id="93ecf-110">Request URI</span></span>
:------     | :-----
<span data-ttu-id="93ecf-111">GET</span><span class="sxs-lookup"><span data-stu-id="93ecf-111">GET</span></span> | <span data-ttu-id="93ecf-112">/ext/xbox/info</span><span class="sxs-lookup"><span data-stu-id="93ecf-112">/ext/xbox/info</span></span>
<br />
**<span data-ttu-id="93ecf-113">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="93ecf-113">URI parameters</span></span>**

- <span data-ttu-id="93ecf-114">なし</span><span class="sxs-lookup"><span data-stu-id="93ecf-114">None</span></span>

**<span data-ttu-id="93ecf-115">要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="93ecf-115">Request headers</span></span>**

- <span data-ttu-id="93ecf-116">なし</span><span class="sxs-lookup"><span data-stu-id="93ecf-116">None</span></span>

**<span data-ttu-id="93ecf-117">要求本文</span><span class="sxs-lookup"><span data-stu-id="93ecf-117">Request body</span></span>**

- <span data-ttu-id="93ecf-118">なし</span><span class="sxs-lookup"><span data-stu-id="93ecf-118">None</span></span>

**<span data-ttu-id="93ecf-119">応答</span><span class="sxs-lookup"><span data-stu-id="93ecf-119">Response</span></span>**   
<span data-ttu-id="93ecf-120">次のフィールドを含む JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="93ecf-120">A JSON object with the following fields:</span></span>

* <span data-ttu-id="93ecf-121">OsVersion - (文字列)、OS のバージョン。</span><span class="sxs-lookup"><span data-stu-id="93ecf-121">OsVersion - (String) The version of the OS.</span></span>
* <span data-ttu-id="93ecf-122">OsEdition - (文字列)、OS のエディションなど「2017 年 3 月」または"2017 年 3 月 1 日"QFE します。</span><span class="sxs-lookup"><span data-stu-id="93ecf-122">OsEdition - (String) The edition of the OS, such as "March 2017" or "March 2017 QFE 1".</span></span>
* <span data-ttu-id="93ecf-123">ConsoleId - (String) 本体の id。</span><span class="sxs-lookup"><span data-stu-id="93ecf-123">ConsoleId - (String) The console's ID.</span></span>
* <span data-ttu-id="93ecf-124">DeviceId - (String) 本体の Xbox Live デバイス id。</span><span class="sxs-lookup"><span data-stu-id="93ecf-124">DeviceId - (String) The console's Xbox Live Device Id.</span></span>
* <span data-ttu-id="93ecf-125">SerialNumber - (String) 本体のシリアル番号。</span><span class="sxs-lookup"><span data-stu-id="93ecf-125">SerialNumber - (String) The console's serial number.</span></span>
* <span data-ttu-id="93ecf-126">DevMode - (String) 本体の現在の開発者モード、"None"など、または「市販」します。</span><span class="sxs-lookup"><span data-stu-id="93ecf-126">DevMode - (String) The console's current developer mode, such as "None" or "Retail".</span></span>
* <span data-ttu-id="93ecf-127">ConsoleType - (String) 本体の種類、"Xbox One"または"Xbox One S"などです。</span><span class="sxs-lookup"><span data-stu-id="93ecf-127">ConsoleType - (String) The console's type, such as "Xbox One" or "Xbox One S".</span></span>
* <span data-ttu-id="93ecf-128">DevkitCertificateExpirationTime - (数値)、UTC 時間 (秒)、本体の開発者キットの証明書の期限が切れるします。</span><span class="sxs-lookup"><span data-stu-id="93ecf-128">DevkitCertificateExpirationTime - (Number) The UTC Time in seconds when the console's developer kit certificate will expire.</span></span>

**<span data-ttu-id="93ecf-129">状態コード</span><span class="sxs-lookup"><span data-stu-id="93ecf-129">Status code</span></span>**

<span data-ttu-id="93ecf-130">この API では次の状態コードが返される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="93ecf-130">This API has the following expected status codes.</span></span>

<span data-ttu-id="93ecf-131">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="93ecf-131">HTTP status code</span></span>      | <span data-ttu-id="93ecf-132">説明</span><span class="sxs-lookup"><span data-stu-id="93ecf-132">Description</span></span>
:------     | :-----
<span data-ttu-id="93ecf-133">200</span><span class="sxs-lookup"><span data-stu-id="93ecf-133">200</span></span> | <span data-ttu-id="93ecf-134">要求は成功しました</span><span class="sxs-lookup"><span data-stu-id="93ecf-134">Request was successful</span></span>
<span data-ttu-id="93ecf-135">4XX</span><span class="sxs-lookup"><span data-stu-id="93ecf-135">4XX</span></span> | <span data-ttu-id="93ecf-136">エラー コード</span><span class="sxs-lookup"><span data-stu-id="93ecf-136">Error codes</span></span>
<span data-ttu-id="93ecf-137">5XX</span><span class="sxs-lookup"><span data-stu-id="93ecf-137">5XX</span></span> | <span data-ttu-id="93ecf-138">エラー コード</span><span class="sxs-lookup"><span data-stu-id="93ecf-138">Error codes</span></span>

<br />
**<span data-ttu-id="93ecf-139">利用可能なデバイス ファミリ</span><span class="sxs-lookup"><span data-stu-id="93ecf-139">Available device families</span></span>**

* <span data-ttu-id="93ecf-140">Windows Xbox</span><span class="sxs-lookup"><span data-stu-id="93ecf-140">Windows Xbox</span></span>