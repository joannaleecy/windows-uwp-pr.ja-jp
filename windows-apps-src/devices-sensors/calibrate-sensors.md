---
ms.assetid: ECE848C2-33DE-46B0-BAE7-647DB62779BB
title: センサーの調整
description: デバイスの磁力計 (コンパス、傾斜計、方位センサー) に基づくセンサーは、環境の要因に応じて調整が必要になることがあります。
ms.date: 03/22/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 7a93d59a00630c240e74049a9fd98d50f285b0dd
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57634677"
---
# <a name="calibrate-sensors"></a><span data-ttu-id="0bdc3-104">センサーの調整</span><span class="sxs-lookup"><span data-stu-id="0bdc3-104">Calibrate sensors</span></span>


<span data-ttu-id="0bdc3-105">**重要な API**</span><span class="sxs-lookup"><span data-stu-id="0bdc3-105">**Important APIs**</span></span>

-   [<span data-ttu-id="0bdc3-106">**Windows.Devices.Sensors**</span><span class="sxs-lookup"><span data-stu-id="0bdc3-106">**Windows.Devices.Sensors**</span></span>](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [<span data-ttu-id="0bdc3-107">**Windows.Devices.Sensors.Custom**</span><span class="sxs-lookup"><span data-stu-id="0bdc3-107">**Windows.Devices.Sensors.Custom**</span></span>](https://msdn.microsoft.com/library/windows/apps/Dn895032)

<span data-ttu-id="0bdc3-108">デバイスの磁力計 (コンパス、傾斜計、方位センサー) に基づくセンサーは、環境の要因に応じて調整が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-108">Sensors in a device based on the magnetometer – the compass, inclinometer and orientation sensor - can become in need of calibration due to environmental factors.</span></span> <span data-ttu-id="0bdc3-109">[  **MagnetometerAccuracy**](https://msdn.microsoft.com/library/windows/apps/Dn297552) 列挙値は、デバイスの調整が必要になる場合の対応策を決めるのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-109">The [**MagnetometerAccuracy**](https://msdn.microsoft.com/library/windows/apps/Dn297552) enumeration can help determine a course of action when your device is in need of calibration.</span></span>

## <a name="when-to-calibrate-the-magnetometer"></a><span data-ttu-id="0bdc3-110">磁力計を調整するタイミング</span><span class="sxs-lookup"><span data-stu-id="0bdc3-110">When to calibrate the magnetometer</span></span>

<span data-ttu-id="0bdc3-111">[  **MagnetometerAccuracy**](https://msdn.microsoft.com/library/windows/apps/Dn297552) 列挙値には、アプリが実行されているデバイスを調整する必要があるかどうかを判断するのに役立つ 4 つの値があります。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-111">The [**MagnetometerAccuracy**](https://msdn.microsoft.com/library/windows/apps/Dn297552) enumeration has four values that help you determine if the device your app is running on needs to be calibrated.</span></span> <span data-ttu-id="0bdc3-112">デバイスを調整する必要がある場合は、その旨をユーザーに知らせる必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-112">If a device needs to be calibrated, you should let the user know that calibration is needed.</span></span> <span data-ttu-id="0bdc3-113">ただし、あまりに頻繁に調整を行うようユーザーに促さないでください。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-113">However, you should not prompt the user to calibrate too frequently.</span></span> <span data-ttu-id="0bdc3-114">10 分に 1 回を超えないようにします。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-114">We recommend no more than once every 10 minutes.</span></span>

| <span data-ttu-id="0bdc3-115">値</span><span class="sxs-lookup"><span data-stu-id="0bdc3-115">Value</span></span>           | <span data-ttu-id="0bdc3-116">説明</span><span class="sxs-lookup"><span data-stu-id="0bdc3-116">Description</span></span>    |
| ----------------- | ------------------- |
| <span data-ttu-id="0bdc3-117">**Unknown**</span><span class="sxs-lookup"><span data-stu-id="0bdc3-117">**Unknown**</span></span>     | <span data-ttu-id="0bdc3-118">センサー ドライバーは現在の正確さを報告できませんでした。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-118">The sensor driver could not report the current accuracy.</span></span> <span data-ttu-id="0bdc3-119">これは、必ずしもデバイスが調整されていないことを意味するわけではありません。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-119">This does not necessarily mean the device is out of calibration.</span></span> <span data-ttu-id="0bdc3-120">**Unknown** が返された場合の最適な対応策は、開発しているアプリによって決まります。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-120">It is up to your app to decide the best course of action if **Unknown** is returned.</span></span> <span data-ttu-id="0bdc3-121">アプリがセンサーの正確な読み取り値を利用しているのであれば、ユーザーにデバイスの調整を促します。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-121">If your app is dependant on an accurate sensor reading, you may want to prompt the user to calibrate the device.</span></span> |
| <span data-ttu-id="0bdc3-122">**信頼性の低い**</span><span class="sxs-lookup"><span data-stu-id="0bdc3-122">**Unreliable**</span></span>  | <span data-ttu-id="0bdc3-123">現在、磁力計の正確さが大きく劣っています。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-123">There is currently a high degree of inaccuracy in the magnetometer.</span></span> <span data-ttu-id="0bdc3-124">この値が最初に返された時点で、アプリからユーザーに必ず調整を求めます。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-124">Apps should always ask for a calibration from the user when this value is first returned.</span></span> |
| <span data-ttu-id="0bdc3-125">**おおよそ**</span><span class="sxs-lookup"><span data-stu-id="0bdc3-125">**Approximate**</span></span> | <span data-ttu-id="0bdc3-126">特定のアプリに対してデータは十分に正確です。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-126">The data is accurate enough for some applications.</span></span> <span data-ttu-id="0bdc3-127">ユーザーがデバイスを上下または左右に動かしたかどうかがわかればよいだけの仮想現実アプリでは、調整なしで続行できます。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-127">A virtual reality app, that only needs to know if the user has moved the device up/down or left/right, can continue without calibration.</span></span> <span data-ttu-id="0bdc3-128">指示を出すためにどの方向に進んでいるか知る必要があるナビゲーション アプリのように、絶対的な進路を必要とするアプリでは、調整を促す必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-128">Apps that need an absolute heading, like a navigation app that needs to know what direction you are driving in order to give you directions, need to ask for calibration.</span></span> |
| <span data-ttu-id="0bdc3-129">**高**</span><span class="sxs-lookup"><span data-stu-id="0bdc3-129">**High**</span></span>        | <span data-ttu-id="0bdc3-130">データは正確です。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-130">The data is precise.</span></span> <span data-ttu-id="0bdc3-131">拡張現実アプリ、ナビゲーション アプリなどの絶対的な進路を知る必要があるアプリでも、調整は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="0bdc3-131">No calibration is needed, even for apps that need to know an absolute heading such as augmented reality or navigation apps.</span></span> |