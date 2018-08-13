---
author: M-Stahl
title: デバイス ポータル Xbox 情報 API リファレンス
description: Xbox デバイスの情報にアクセスする方法をについて説明します。
ms.author: mstahl
ms.date: 11/7/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、xbox、デバイスのポータル
ms.localizationpriority: medium
ms.openlocfilehash: db1df2418a2bb60de4a72f51ad01a0bfd547ec20
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608856"
---
# <a name="xbox-info-api-reference"></a>Xbox 情報 API リファレンス   
この API を使用して Xbox 1 つのデバイスの情報にアクセスできます。

## <a name="get-xbox-one-device-information"></a>デバイスの Xbox を 1 つの情報を取得します。

**要求**

1、Xbox については、デバイスの情報を入手できます。

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

* OsVersion - (文字列) OS のバージョンを使用します。
* OsEdition - (文字列) OS のエディションなど"2017年 3 月"または"2017年 3 月 QFE 1" します。
* ConsoleId - (文字列) コンソールの ID
* DeviceId - (文字列) コンソールの Xbox Live デバイス id。
* SerialNumber - (文字列) コンソールのシリアル値を使用します。
* DevMode -「なし」などの (文字列) コンソールの現在の開発者モードまたは「製品」します。
* ConsoleType - (文字列) コンソールの種類] の「一 Xbox」または"Xbox 1 S"などです。
* DevkitCertificateExpirationTime - (数値)、時刻、コンソールの開発キットの証明書の有効期限が切れる秒数。

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