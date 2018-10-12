---
title: DeviceEndpoint (JSON)
assetID: bd6c4af8-e491-8885-970e-e53d1d60642b
permalink: en-us/docs/xboxlive/rest/json-deviceendpoint.html
author: KevinAsgari
description: " DeviceEndpoint (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bfae4eac9ecf0177026183cc25bac5526bbba62f
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4568477"
---
# <a name="deviceendpoint-json"></a><span data-ttu-id="d2e2f-104">DeviceEndpoint (JSON)</span><span class="sxs-lookup"><span data-stu-id="d2e2f-104">DeviceEndpoint (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="deviceendpoint"></a><span data-ttu-id="d2e2f-105">DeviceEndpoint</span><span class="sxs-lookup"><span data-stu-id="d2e2f-105">DeviceEndpoint</span></span>
 
<span data-ttu-id="d2e2f-106">DeviceEndpoint オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-106">The DeviceEndpoint object has the following specification.</span></span>
 
| <span data-ttu-id="d2e2f-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="d2e2f-107">Member</span></span>| <span data-ttu-id="d2e2f-108">種類</span><span class="sxs-lookup"><span data-stu-id="d2e2f-108">Type</span></span>| <span data-ttu-id="d2e2f-109">説明</span><span class="sxs-lookup"><span data-stu-id="d2e2f-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d2e2f-110">deviceName</span><span class="sxs-lookup"><span data-stu-id="d2e2f-110">deviceName</span></span>| <span data-ttu-id="d2e2f-111">string</span><span class="sxs-lookup"><span data-stu-id="d2e2f-111">string</span></span>| <span data-ttu-id="d2e2f-112">省略可能。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-112">Optional.</span></span> <span data-ttu-id="d2e2f-113">該当する場合、このデバイスのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-113">A friendly name for the device, if applicable.</span></span> <span data-ttu-id="d2e2f-114">現在、この値は使用しません。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-114">Currently this value is not used.</span></span>| 
| <span data-ttu-id="d2e2f-115">endpointUri</span><span class="sxs-lookup"><span data-stu-id="d2e2f-115">endpointUri</span></span>| <span data-ttu-id="d2e2f-116">string</span><span class="sxs-lookup"><span data-stu-id="d2e2f-116">string</span></span>| <span data-ttu-id="d2e2f-117">必須。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-117">Required.</span></span> <span data-ttu-id="d2e2f-118">クライアント プラットフォーム (Windows または Windows Phone) が、プッシュ通知サービス (WNS または MPNS) から入手した URL です。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-118">The URL that the client platform (Windows or Windows Phone) has obtained from its push notification service (WNS or MPNS).</span></span>| 
| <span data-ttu-id="d2e2f-119">locale</span><span class="sxs-lookup"><span data-stu-id="d2e2f-119">locale</span></span>| <span data-ttu-id="d2e2f-120">string</span><span class="sxs-lookup"><span data-stu-id="d2e2f-120">string</span></span>| <span data-ttu-id="d2e2f-121">必須。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-121">Required.</span></span> <span data-ttu-id="d2e2f-122">このエンドポイントに送信される通知の目的の言語です。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-122">The desired language of notifications sent to this endpoint.</span></span> <span data-ttu-id="d2e2f-123">優先順位の値をコンマ区切りのリストであることができます。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-123">Can be a list of comma-separated values in preference order.</span></span> <span data-ttu-id="d2e2f-124">例:「DE-DE, EN-US, en」。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-124">Example: "de-DE, en-US, en".</span></span>| 
| <span data-ttu-id="d2e2f-125">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="d2e2f-125">platform</span></span>| <span data-ttu-id="d2e2f-126">string</span><span class="sxs-lookup"><span data-stu-id="d2e2f-126">string</span></span>| <span data-ttu-id="d2e2f-127">省略可能。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-127">Optional.</span></span> <span data-ttu-id="d2e2f-128">現在サポートされている値は、"WindowsPhone"および"Windows"です。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-128">Currently supported values are "WindowsPhone" and "Windows".</span></span> <span data-ttu-id="d2e2f-129">指定しない場合、デバイス トークンから導出されます。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-129">If not specified, it is derived from the Device token.</span></span>| 
| <span data-ttu-id="d2e2f-130">platformVersion</span><span class="sxs-lookup"><span data-stu-id="d2e2f-130">platformVersion</span></span>| <span data-ttu-id="d2e2f-131">string</span><span class="sxs-lookup"><span data-stu-id="d2e2f-131">string</span></span>| <span data-ttu-id="d2e2f-132">省略可能。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-132">Optional.</span></span> <span data-ttu-id="d2e2f-133">この文字列の形式は、各プラットフォームを特定します。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-133">The format of this string is particular to each platform.</span></span> <span data-ttu-id="d2e2f-134">現在、この値は使用しません。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-134">Currently this value is not used.</span></span>| 
| <span data-ttu-id="d2e2f-135">systemId</span><span class="sxs-lookup"><span data-stu-id="d2e2f-135">systemId</span></span>| <span data-ttu-id="d2e2f-136">GUID</span><span class="sxs-lookup"><span data-stu-id="d2e2f-136">GUID</span></span>| <span data-ttu-id="d2e2f-137">必須。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-137">Required.</span></span> <span data-ttu-id="d2e2f-138">「アプリ インスタンス」の一意の識別子 (デバイス/ユーザーの組み合わせ)。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-138">Unique identifier for the "app instance" (device/user combination).</span></span> <span data-ttu-id="d2e2f-139">ベスト プラクティスの導入がインストール/最初の実行時にランダムな GUID を生成するアプリの引き続き、アプリの後続の実行でその値を使用します。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-139">Best practice implementation is for an app to generate a random GUID upon install/first-run, and continue to use that value on subsequent runs of the app.</span></span>| 
| <span data-ttu-id="d2e2f-140">titleId</span><span class="sxs-lookup"><span data-stu-id="d2e2f-140">titleId</span></span>| <span data-ttu-id="d2e2f-141">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d2e2f-141">32-bit unsigned integer</span></span>| <span data-ttu-id="d2e2f-142">必須。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-142">Required.</span></span> <span data-ttu-id="d2e2f-143">サービスに呼び出しを発行するゲームのタイトル ID です。</span><span class="sxs-lookup"><span data-stu-id="d2e2f-143">The Title ID of the game issuing the call to the service.</span></span>| 
  
<a id="ID4EGD"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="d2e2f-144">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="d2e2f-144">Sample JSON syntax</span></span>
 

```json
{
  "systemId": "e9af05b4-70de-4920-880f-026c6fb67d1b",
  "userId" : 1234567890
  "endpointUri": "http://cloud.notify.windows.com/.../",
  "platform": "Windows",
  "platformVersion": "1.0",
  "deviceName": "Test Endpoint",
  "locale": "en-US",
  "titleId": 1297290219
}
    
```

  
<a id="ID4EPD"></a>

 
## <a name="see-also"></a><span data-ttu-id="d2e2f-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="d2e2f-145">See also</span></span>
 
<a id="ID4ERD"></a>

 
##### <a name="parent"></a><span data-ttu-id="d2e2f-146">Parent</span><span class="sxs-lookup"><span data-stu-id="d2e2f-146">Parent</span></span> 

[<span data-ttu-id="d2e2f-147">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="d2e2f-147">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a><span data-ttu-id="d2e2f-148">リファレンス</span><span class="sxs-lookup"><span data-stu-id="d2e2f-148">Reference</span></span>   