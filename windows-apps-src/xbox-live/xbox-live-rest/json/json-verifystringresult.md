---
title: VerifyStringResult (JSON)
assetID: 272c688e-179e-c7e9-086b-e76d0d4bcb57
permalink: en-us/docs/xboxlive/rest/json-verifystringresult.html
author: KevinAsgari
description: " VerifyStringResult (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1ba5336ed0bf734eff60a4bbffca3397fd1ea3eb
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6147607"
---
# <a name="verifystringresult-json"></a>VerifyStringResult (JSON)
[/System/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)に送信された各文字列に対応する結果コード。
<a id="ID4ER"></a>


## <a name="verifystringresult"></a>VerifyStringResult

VerifyStringResult オブジェクトでは、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| resultCode| 32 ビットの符号なし整数| 必須。 HResult コードに対応する文字列を送信します。|
| offendingString| string| 必須。 拒否される文字列の原因となった文字列値。|

<a id="ID4EXB"></a>


## <a name="sample-json-syntax"></a>JSON 構文の例


```json
{
    "verifyStringResult":
    [
        {"resultCode": "1", "offendingString": "badword"},
        {"resultCode": "0", "offendingString": ""},
        {"resultCode": "0", "offendingString": ""},
        {"resultCode": "0", "offendingString": ""},
    ]
}

```


#### <a name="common-hresult-values"></a>一般的な HResult 値

| 値| エラーの名前|
| --- | --- | --- | --- | --- |
| 0| 成功|
| 1| 不快感を与える文字列|
| 2| 文字列が長すぎます|
| 3| 不明なエラー|

<a id="ID4ELD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4END"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a>リファレンス

[POST (/system/strings/validate)](../uri/stringserver/uri-systemstringsvalidatepost.md)
