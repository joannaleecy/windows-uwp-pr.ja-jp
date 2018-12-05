---
title: Device Portal リモコン入力 API リファレンス
description: Xbox でコントローラー、キーボード、およびマウス入力をリモートで送信する方法について説明します。
ms.localizationpriority: medium
ms.openlocfilehash: e0db86ad50bfb1cb27f516243542a554e710c3ea
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8730592"
---
# <a name="remote-input-api-reference"></a>リモート入力 API リファレンス   
この API を介してリモートからリアルタイムでコントローラー、キーボード、およびマウス入力を送信することができます。

**要求**

メソッド      | 要求 URI
:------     | :-----
WebSocket | /ext/remoteinput
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求**

一連のバイト配列メッセージの websocket です。 各メッセージについて、形式は次のとおりです。

最初のバイトは、入力タイプを示します。 次の入力タイプがサポートされています。

| 入力タイプ        | バイト値 |
|------------|-------------|
キーボード キーコード | 0x01
キーボード スキャンコード | 0x02
マウス | 0x03
すべてクリア | 0x04

KeyboardKeyCodes および KeyboardScanCodes では、2 番目のバイトはキーコードまたはスキャン コードの値で、3 番目のバイトは 押下の 0x01 とリリースの 0x00 です。

マウス メッセージでは、次の値はマウス イベントの種類を示す、ネットワーク順序の UINT16 (2 バイト) です。

| アクションの種類        | UINT16 値 |
|------------|-------------|
移動 | 0x0001
LeftDown | 0x0002
LeftUp | 0x0004
RightDown | 0x0008
RightUp | 0x0010
MiddleDown | 0x0020
MiddleUp | 0x0040
X1Down | 0x0080
X1Up | 0x0100
X2Down | 0x0200
X2Up | 0x0400
VerticalWheelMoved | 0x0800
HorizontalWheelMoved | 0x1000

このバイトの後に、ネットワーク順序の 2 つの UINT32 値とホイール アクションを示す 3 つ目のオプションの UINT32 が続きます。 最初の 2 つの値は X 座標と Y 座標で、3 つ目の値はホイールのデルタです。 X 座標と Y 座標は、水平面および垂直面でマウスの相対位置を示す 0 ～ 65535 の間の値になることが期待されます。

ClearAll は、現在押されているキーを離す必要があることを示します。 他のバイトは必要ありません。

ゲームパッド入力を送信するために、ゲームパッドのボタンの押下を表すキーコードの値を KeyboardKeyCodes で使用できます。 これらの値は次のとおりです。

| ゲームパッドの種類        | バイト値 |
|------------|-------------|
VK_GAMEPAD_A                       |  0xC3
VK_GAMEPAD_B                       |  0xC4
VK_GAMEPAD_X                       |  0xC5
VK_GAMEPAD_Y                       |  0xC6
VK_GAMEPAD_RIGHT_SHOULDER          |  0xC7
VK_GAMEPAD_LEFT_SHOULDER           |  0xC8
VK_GAMEPAD_LEFT_TRIGGER            |  0xC9
VK_GAMEPAD_RIGHT_TRIGGER           |  0xCA
VK_GAMEPAD_DPAD_UP                 |  0xCB
VK_GAMEPAD_DPAD_DOWN               |  0xCC
VK_GAMEPAD_DPAD_LEFT               |  0xCD
VK_GAMEPAD_DPAD_RIGHT              |  0xCE
VK_GAMEPAD_MENU                    |  0xCF
VK_GAMEPAD_VIEW                    |  0xD0
VK_GAMEPAD_LEFT_THUMBSTICK_BUTTON  |  0xD1
VK_GAMEPAD_RIGHT_THUMBSTICK_BUTTON |  0xD2
VK_GAMEPAD_LEFT_THUMBSTICK_UP      |  0xD3
VK_GAMEPAD_LEFT_THUMBSTICK_DOWN    |  0xD4
VK_GAMEPAD_LEFT_THUMBSTICK_RIGHT   |  0xD5
VK_GAMEPAD_LEFT_THUMBSTICK_LEFT    |  0xD6
VK_GAMEPAD_RIGHT_THUMBSTICK_UP     |  0xD7
VK_GAMEPAD_RIGHT_THUMBSTICK_DOWN   |  0xD8
VK_GAMEPAD_RIGHT_THUMBSTICK_RIGHT  |  0xD9
VK_GAMEPAD_RIGHT_THUMBSTICK_LEFT   |  0xDA


**応答**   

- なし

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 要求は成功しました
4XX | エラー コード
5XX | エラー コード

<br />
**利用可能なデバイス ファミリ**

* Windows Xbox