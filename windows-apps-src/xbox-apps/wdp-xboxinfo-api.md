---
title: デバイス ポータル Xbox 情報 API リファレンス
description: Xbox デバイス情報にアクセスする方法について説明します。
ms.date: 11/072017
ms.topic: article
keywords: windows 10、uwp、xbox、デバイス ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 7aa8b11bc439266d36fbb27a7eaa7b07e924a17c
ms.sourcegitcommit: bad7ed6def79acbb4569de5a92c0717364e771d9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59244038"
---
# <a name="xbox-info-api-reference"></a>Xbox 情報 API リファレンス   
この API を使うと、Xbox One デバイス情報にアクセスすることができます。

## <a name="get-xbox-one-device-information"></a>Xbox One デバイス情報を取得する

## <a name="request"></a>要求

Xbox One に関するデバイス情報を取得できます。

メソッド      | 要求 URI
:------     | :-----
GET | /ext/xbox/info

**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

## <a name="response"></a>応答
次のフィールドを含む JSON オブジェクト。

* OsVersion - (文字列) OS のバージョン。
* OsEdition - (文字列) OS のエディション ("March 2017" や "March 2017 QFE 1" など)。
* ConsoleId - (文字列) コンソールの ID。
* DeviceId - (文字列) コンソールの Xbox Live デバイス ID。
* SerialNumber - (文字列) コンソールのシリアル番号。
* DevMode - (文字列) コンソールの現在の開発者モード ("None" や "Retail" など)。
* ConsoleType - (文字列) コンソールの種類 ("Xbox One" や "Xbox One S" など)。
* DevkitCertificateExpirationTime - (数値) コンソールの開発者キット証明書の有効期限が切れる UTC 時刻 (秒単位)。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 要求は成功しました
4XX | エラー コード
5XX | エラー コード

**利用可能なデバイス ファミリ**

* Windows Xbox