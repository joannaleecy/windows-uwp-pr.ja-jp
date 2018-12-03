---
title: DeviceEndpoint (JSON)
assetID: bd6c4af8-e491-8885-970e-e53d1d60642b
permalink: en-us/docs/xboxlive/rest/json-deviceendpoint.html
description: " DeviceEndpoint (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 48631f545846c53a50090b1bb369e92f3f65ed80
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8350851"
---
# <a name="deviceendpoint-json"></a><span data-ttu-id="60a84-104">DeviceEndpoint (JSON)</span><span class="sxs-lookup"><span data-stu-id="60a84-104">DeviceEndpoint (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="deviceendpoint"></a><span data-ttu-id="60a84-105">DeviceEndpoint</span><span class="sxs-lookup"><span data-stu-id="60a84-105">DeviceEndpoint</span></span>
 
<span data-ttu-id="60a84-106">DeviceEndpoint オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="60a84-106">The DeviceEndpoint object has the following specification.</span></span>
 
| <span data-ttu-id="60a84-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="60a84-107">Member</span></span>| <span data-ttu-id="60a84-108">種類</span><span class="sxs-lookup"><span data-stu-id="60a84-108">Type</span></span>| <span data-ttu-id="60a84-109">説明</span><span class="sxs-lookup"><span data-stu-id="60a84-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="60a84-110">deviceName</span><span class="sxs-lookup"><span data-stu-id="60a84-110">deviceName</span></span>| <span data-ttu-id="60a84-111">string</span><span class="sxs-lookup"><span data-stu-id="60a84-111">string</span></span>| <span data-ttu-id="60a84-112">省略可能。</span><span class="sxs-lookup"><span data-stu-id="60a84-112">Optional.</span></span> <span data-ttu-id="60a84-113">該当する場合は、デバイスのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="60a84-113">A friendly name for the device, if applicable.</span></span> <span data-ttu-id="60a84-114">現在、この値は使用しません。</span><span class="sxs-lookup"><span data-stu-id="60a84-114">Currently this value is not used.</span></span>| 
| <span data-ttu-id="60a84-115">endpointUri</span><span class="sxs-lookup"><span data-stu-id="60a84-115">endpointUri</span></span>| <span data-ttu-id="60a84-116">string</span><span class="sxs-lookup"><span data-stu-id="60a84-116">string</span></span>| <span data-ttu-id="60a84-117">必須。</span><span class="sxs-lookup"><span data-stu-id="60a84-117">Required.</span></span> <span data-ttu-id="60a84-118">クライアント プラットフォーム (Windows または Windows Phone) が、プッシュ通知サービス (WNS または MPNS) から入手した URL です。</span><span class="sxs-lookup"><span data-stu-id="60a84-118">The URL that the client platform (Windows or Windows Phone) has obtained from its push notification service (WNS or MPNS).</span></span>| 
| <span data-ttu-id="60a84-119">locale</span><span class="sxs-lookup"><span data-stu-id="60a84-119">locale</span></span>| <span data-ttu-id="60a84-120">string</span><span class="sxs-lookup"><span data-stu-id="60a84-120">string</span></span>| <span data-ttu-id="60a84-121">必須。</span><span class="sxs-lookup"><span data-stu-id="60a84-121">Required.</span></span> <span data-ttu-id="60a84-122">このエンドポイントに送信される通知の目的の言語です。</span><span class="sxs-lookup"><span data-stu-id="60a84-122">The desired language of notifications sent to this endpoint.</span></span> <span data-ttu-id="60a84-123">優先順位の値をコンマ区切りのリストであることができます。</span><span class="sxs-lookup"><span data-stu-id="60a84-123">Can be a list of comma-separated values in preference order.</span></span> <span data-ttu-id="60a84-124">例:「DE-DE, EN-US, en」します。</span><span class="sxs-lookup"><span data-stu-id="60a84-124">Example: "de-DE, en-US, en".</span></span>| 
| <span data-ttu-id="60a84-125">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="60a84-125">platform</span></span>| <span data-ttu-id="60a84-126">string</span><span class="sxs-lookup"><span data-stu-id="60a84-126">string</span></span>| <span data-ttu-id="60a84-127">省略可能。</span><span class="sxs-lookup"><span data-stu-id="60a84-127">Optional.</span></span> <span data-ttu-id="60a84-128">現在サポートされている値は、"WindowsPhone"および"Windows"です。</span><span class="sxs-lookup"><span data-stu-id="60a84-128">Currently supported values are "WindowsPhone" and "Windows".</span></span> <span data-ttu-id="60a84-129">指定しない場合、デバイス トークンから導出されます。</span><span class="sxs-lookup"><span data-stu-id="60a84-129">If not specified, it is derived from the Device token.</span></span>| 
| <span data-ttu-id="60a84-130">platformVersion</span><span class="sxs-lookup"><span data-stu-id="60a84-130">platformVersion</span></span>| <span data-ttu-id="60a84-131">string</span><span class="sxs-lookup"><span data-stu-id="60a84-131">string</span></span>| <span data-ttu-id="60a84-132">省略可能。</span><span class="sxs-lookup"><span data-stu-id="60a84-132">Optional.</span></span> <span data-ttu-id="60a84-133">この文字列の形式は、各プラットフォームを特定します。</span><span class="sxs-lookup"><span data-stu-id="60a84-133">The format of this string is particular to each platform.</span></span> <span data-ttu-id="60a84-134">現在、この値は使用しません。</span><span class="sxs-lookup"><span data-stu-id="60a84-134">Currently this value is not used.</span></span>| 
| <span data-ttu-id="60a84-135">systemId</span><span class="sxs-lookup"><span data-stu-id="60a84-135">systemId</span></span>| <span data-ttu-id="60a84-136">GUID</span><span class="sxs-lookup"><span data-stu-id="60a84-136">GUID</span></span>| <span data-ttu-id="60a84-137">必須。</span><span class="sxs-lookup"><span data-stu-id="60a84-137">Required.</span></span> <span data-ttu-id="60a84-138">「アプリ インスタンス」の一意の識別子 (デバイス/ユーザーの組み合わせ)。</span><span class="sxs-lookup"><span data-stu-id="60a84-138">Unique identifier for the "app instance" (device/user combination).</span></span> <span data-ttu-id="60a84-139">ベスト プラクティスの導入がインストール/最初の実行時にランダムな GUID を生成するアプリの引き続き、アプリの後続の実行でその値を使用します。</span><span class="sxs-lookup"><span data-stu-id="60a84-139">Best practice implementation is for an app to generate a random GUID upon install/first-run, and continue to use that value on subsequent runs of the app.</span></span>| 
| <span data-ttu-id="60a84-140">titleId</span><span class="sxs-lookup"><span data-stu-id="60a84-140">titleId</span></span>| <span data-ttu-id="60a84-141">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="60a84-141">32-bit unsigned integer</span></span>| <span data-ttu-id="60a84-142">必須。</span><span class="sxs-lookup"><span data-stu-id="60a84-142">Required.</span></span> <span data-ttu-id="60a84-143">サービスに呼び出しを発行するゲームのタイトル ID です。</span><span class="sxs-lookup"><span data-stu-id="60a84-143">The Title ID of the game issuing the call to the service.</span></span>| 
  
<a id="ID4EGD"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="60a84-144">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="60a84-144">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="60a84-145">関連項目</span><span class="sxs-lookup"><span data-stu-id="60a84-145">See also</span></span>
 
<a id="ID4ERD"></a>

 
##### <a name="parent"></a><span data-ttu-id="60a84-146">Parent</span><span class="sxs-lookup"><span data-stu-id="60a84-146">Parent</span></span> 

[<span data-ttu-id="60a84-147">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="60a84-147">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a><span data-ttu-id="60a84-148">リファレンス</span><span class="sxs-lookup"><span data-stu-id="60a84-148">Reference</span></span>   