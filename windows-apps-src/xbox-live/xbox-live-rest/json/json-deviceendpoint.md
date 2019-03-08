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
# <a name="deviceendpoint-json"></a>DeviceEndpoint (JSON)
 
<a id="ID4EO"></a>

 
## <a name="deviceendpoint"></a>DeviceEndpoint
 
DeviceEndpoint オブジェクトには、次の仕様があります。
 
| メンバー| 種類| 説明| 
| --- | --- | --- | 
| deviceName| string| (省略可能)。 該当する場合は、デバイスのフレンドリ名。 現在、この値は使用されません。| 
| endpointUri| string| 必須。 クライアントのプラットフォーム (Windows または Windows Phone) は、プッシュ通知サービス (WNS または MPNS) から取得する URL です。| 
| locale| string| 必須。 このエンドポイントに送信される通知の目的の言語。 優先順位の値をコンマ区切りのリストであることができます。 例:「DE-DE、EN-US, en」です。| 
| プラットフォーム| string| (省略可能)。 現在サポートされている値は"WindowsPhone"および"Windows です"。 指定しない場合、デバイス トークンから派生します。| 
| platformVersion| string| (省略可能)。 この文字列の形式は、各プラットフォームに固有です。 現在、この値は使用されません。| 
| systemId| GUID| 必須。 「アプリのインスタンス」の一意識別子 (デバイス/ユーザーの組み合わせ)。 ベスト プラクティスの実装はインストール/最初の実行時にランダムな GUID を生成するアプリをその値を使用して、アプリの後続実行を続行します。| 
| titleId| 32 ビット符号なし整数| 必須。 サービスへの呼び出しを発行するゲームのタイトルの ID。| 
  
<a id="ID4EGD"></a>

 
## <a name="sample-json-syntax"></a>サンプルの JSON の構文
 

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

 
## <a name="see-also"></a>関連項目
 
<a id="ID4ERD"></a>

 
##### <a name="parent"></a>Parent 

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a>リファレンス   