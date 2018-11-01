---
author: M-Stahl
title: デバイス Xbox のポータル情報 API リファレンス
description: Xbox デバイスの情報にアクセスする方法をについて説明します。
ms.author: mstahl
ms.date: 11/7/2017
ms.topic: article
keywords: windows 10、uwp、xbox、デバイスのポータル
ms.localizationpriority: medium
ms.openlocfilehash: 4b0e2bab0ce7d5525e8032809954ff656a74a61c
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919895"
---
# <a name="xbox-info-api-reference"></a>Xbox 情報 API リファレンス   
この API を使用して Xbox を 1 つのデバイス情報にアクセスすることができます。

## <a name="get-xbox-one-device-information"></a>Xbox が 1 つのデバイス情報を取得します。

**要求**

Xbox 1 つのデバイス情報を取得できます。

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

* OsVersion - (文字列)、OS のバージョンです。
* OsEdition - (文字列)、OS のエディション」2017 年 3 月"など、または"2017年 3 月 QFE 1"。
* ConsoleId - (文字列)、コンソールの id。
* DeviceId を (文字列)、コンソールの Xbox Live デバイス id。
* シリアル番号 - (文字列)、コンソールのシリアル番号。
* DevMode の [なし] などの (文字列)、コンソールの現在の開発者モードまたは"Retail"です。
* ConsoleType -「Xbox」か「Xbox 1 S」など、(文字列)、コンソールのタイプです。
* DevkitCertificateExpirationTime - (番号)、UTC 時間 (秒)、コンソールの開発者キットの証明書の期限が切れる。

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