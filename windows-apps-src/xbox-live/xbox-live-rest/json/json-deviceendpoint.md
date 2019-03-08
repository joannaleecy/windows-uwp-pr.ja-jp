---
title: DeviceEndpoint (JSON)
assetID: bd6c4af8-e491-8885-970e-e53d1d60642b
permalink: en-us/docs/xboxlive/rest/json-deviceendpoint.html
description: " DeviceEndpoint (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0eaa21072ebf14b6f6d959ff40af34724a45522f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618877"
---
# <a name="deviceendpoint-json"></a><span data-ttu-id="6bbc4-104">DeviceEndpoint (JSON)</span><span class="sxs-lookup"><span data-stu-id="6bbc4-104">DeviceEndpoint (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="deviceendpoint"></a><span data-ttu-id="6bbc4-105">DeviceEndpoint</span><span class="sxs-lookup"><span data-stu-id="6bbc4-105">DeviceEndpoint</span></span>
 
<span data-ttu-id="6bbc4-106">DeviceEndpoint オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-106">The DeviceEndpoint object has the following specification.</span></span>
 
| <span data-ttu-id="6bbc4-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="6bbc4-107">Member</span></span>| <span data-ttu-id="6bbc4-108">種類</span><span class="sxs-lookup"><span data-stu-id="6bbc4-108">Type</span></span>| <span data-ttu-id="6bbc4-109">説明</span><span class="sxs-lookup"><span data-stu-id="6bbc4-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6bbc4-110">deviceName</span><span class="sxs-lookup"><span data-stu-id="6bbc4-110">deviceName</span></span>| <span data-ttu-id="6bbc4-111">string</span><span class="sxs-lookup"><span data-stu-id="6bbc4-111">string</span></span>| <span data-ttu-id="6bbc4-112">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-112">Optional.</span></span> <span data-ttu-id="6bbc4-113">該当する場合は、デバイスのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-113">A friendly name for the device, if applicable.</span></span> <span data-ttu-id="6bbc4-114">現在、この値は使用されません。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-114">Currently this value is not used.</span></span>| 
| <span data-ttu-id="6bbc4-115">endpointUri</span><span class="sxs-lookup"><span data-stu-id="6bbc4-115">endpointUri</span></span>| <span data-ttu-id="6bbc4-116">string</span><span class="sxs-lookup"><span data-stu-id="6bbc4-116">string</span></span>| <span data-ttu-id="6bbc4-117">必須。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-117">Required.</span></span> <span data-ttu-id="6bbc4-118">クライアントのプラットフォーム (Windows または Windows Phone) は、プッシュ通知サービス (WNS または MPNS) から取得する URL です。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-118">The URL that the client platform (Windows or Windows Phone) has obtained from its push notification service (WNS or MPNS).</span></span>| 
| <span data-ttu-id="6bbc4-119">locale</span><span class="sxs-lookup"><span data-stu-id="6bbc4-119">locale</span></span>| <span data-ttu-id="6bbc4-120">string</span><span class="sxs-lookup"><span data-stu-id="6bbc4-120">string</span></span>| <span data-ttu-id="6bbc4-121">必須。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-121">Required.</span></span> <span data-ttu-id="6bbc4-122">このエンドポイントに送信される通知の目的の言語。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-122">The desired language of notifications sent to this endpoint.</span></span> <span data-ttu-id="6bbc4-123">優先順位の値をコンマ区切りのリストであることができます。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-123">Can be a list of comma-separated values in preference order.</span></span> <span data-ttu-id="6bbc4-124">例:「DE-DE、EN-US, en」です。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-124">Example: "de-DE, en-US, en".</span></span>| 
| <span data-ttu-id="6bbc4-125">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="6bbc4-125">platform</span></span>| <span data-ttu-id="6bbc4-126">string</span><span class="sxs-lookup"><span data-stu-id="6bbc4-126">string</span></span>| <span data-ttu-id="6bbc4-127">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-127">Optional.</span></span> <span data-ttu-id="6bbc4-128">現在サポートされている値は"WindowsPhone"および"Windows です"。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-128">Currently supported values are "WindowsPhone" and "Windows".</span></span> <span data-ttu-id="6bbc4-129">指定しない場合、デバイス トークンから派生します。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-129">If not specified, it is derived from the Device token.</span></span>| 
| <span data-ttu-id="6bbc4-130">platformVersion</span><span class="sxs-lookup"><span data-stu-id="6bbc4-130">platformVersion</span></span>| <span data-ttu-id="6bbc4-131">string</span><span class="sxs-lookup"><span data-stu-id="6bbc4-131">string</span></span>| <span data-ttu-id="6bbc4-132">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-132">Optional.</span></span> <span data-ttu-id="6bbc4-133">この文字列の形式は、各プラットフォームに固有です。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-133">The format of this string is particular to each platform.</span></span> <span data-ttu-id="6bbc4-134">現在、この値は使用されません。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-134">Currently this value is not used.</span></span>| 
| <span data-ttu-id="6bbc4-135">systemId</span><span class="sxs-lookup"><span data-stu-id="6bbc4-135">systemId</span></span>| <span data-ttu-id="6bbc4-136">GUID</span><span class="sxs-lookup"><span data-stu-id="6bbc4-136">GUID</span></span>| <span data-ttu-id="6bbc4-137">必須。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-137">Required.</span></span> <span data-ttu-id="6bbc4-138">「アプリのインスタンス」の一意識別子 (デバイス/ユーザーの組み合わせ)。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-138">Unique identifier for the "app instance" (device/user combination).</span></span> <span data-ttu-id="6bbc4-139">ベスト プラクティスの実装はインストール/最初の実行時にランダムな GUID を生成するアプリをその値を使用して、アプリの後続実行を続行します。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-139">Best practice implementation is for an app to generate a random GUID upon install/first-run, and continue to use that value on subsequent runs of the app.</span></span>| 
| <span data-ttu-id="6bbc4-140">titleId</span><span class="sxs-lookup"><span data-stu-id="6bbc4-140">titleId</span></span>| <span data-ttu-id="6bbc4-141">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6bbc4-141">32-bit unsigned integer</span></span>| <span data-ttu-id="6bbc4-142">必須。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-142">Required.</span></span> <span data-ttu-id="6bbc4-143">サービスへの呼び出しを発行するゲームのタイトルの ID。</span><span class="sxs-lookup"><span data-stu-id="6bbc4-143">The Title ID of the game issuing the call to the service.</span></span>| 
  
<a id="ID4EGD"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="6bbc4-144">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="6bbc4-144">Sample JSON syntax</span></span>
 

```json
{
  "systemId": "e9af05b4-70de-4920-880f-026c6fb67d1b",
  "userId" : 1234567890
  "endpointUri": "https://cloud.notify.windows.com/.../",
  "platform": "Windows",
  "platformVersion": "1.0",
  "deviceName": "Test Endpoint",
  "locale": "en-US",
  "titleId": 1297290219
}
    
```

  
<a id="ID4EPD"></a>

 
## <a name="see-also"></a><span data-ttu-id="6bbc4-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="6bbc4-145">See also</span></span>
 
<a id="ID4ERD"></a>

 
##### <a name="parent"></a><span data-ttu-id="6bbc4-146">Parent</span><span class="sxs-lookup"><span data-stu-id="6bbc4-146">Parent</span></span> 

[<span data-ttu-id="6bbc4-147">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="6bbc4-147">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a><span data-ttu-id="6bbc4-148">リファレンス</span><span class="sxs-lookup"><span data-stu-id="6bbc4-148">Reference</span></span>   