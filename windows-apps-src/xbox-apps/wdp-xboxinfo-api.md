---
author: M-Stahl
title: Device Portal の Xbox 情報 API リファレンス
description: Xbox デバイス情報にアクセスする方法をについて説明します。
ms.author: mstahl
ms.date: 11/7/2017
ms.topic: article
keywords: windows 10, uwp, xbox, デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 4b0e2bab0ce7d5525e8032809954ff656a74a61c
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6839926"
---
# <a name="xbox-info-api-reference"></a>Xbox 情報 API リファレンス   
この API を使用して Xbox One のデバイス情報にアクセスすることができます。

## <a name="get-xbox-one-device-information"></a>Xbox One デバイス情報を取得します。

**要求**

Xbox One については、デバイス情報を取得できます。

メソッド      | 要求 URI
:------     | :-----
GET | /ext/xbox/info
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**   
次のフィールドを含む JSON オブジェクト。

* OsVersion - (文字列)、OS のバージョン。
* OsEdition - (文字列)、OS のエディションなど「2017 年 3 月」または"2017 年 3 月 1 日"QFE します。
* ConsoleId - (String) 本体の id。
* DeviceId - (String) 本体の Xbox Live デバイス id。
* SerialNumber - (String) 本体のシリアル番号。
* DevMode - (String) 本体の現在の開発者モード、"None"など、または「市販」。
* ConsoleType - (String) 本体の種類、"Xbox One"または"Xbox One S"など。
* DevkitCertificateExpirationTime - (数値)、UTC 時間 (秒)、本体の開発者キットの証明書の有効期限が切れます。

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