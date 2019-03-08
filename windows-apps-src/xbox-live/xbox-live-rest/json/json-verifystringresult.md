---
title: VerifyStringResult (JSON)
assetID: 272c688e-179e-c7e9-086b-e76d0d4bcb57
permalink: en-us/docs/xboxlive/rest/json-verifystringresult.html
description: " VerifyStringResult (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b01793222be80efccdca1f24f5226a2e9ff78064
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57599487"
---
# <a name="verifystringresult-json"></a>VerifyStringResult (JSON)
送信された各文字列に対応するコードを結果[/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)します。
<a id="ID4ER"></a>


## <a name="verifystringresult"></a>VerifyStringResult

VerifyStringResult オブジェクトには、次の仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| 結果コード| 32 ビット符号なし整数| 必須。 対応する HResult コード文字列を送信します。|
| offendingString| string| 必須。 拒否される文字列の原因となった文字列値。|

<a id="ID4EXB"></a>


## <a name="sample-json-syntax"></a>サンプルの JSON の構文


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


#### <a name="common-hresult-values"></a>共通 HResult 値

| Value| エラー名|
| --- | --- | --- | --- | --- |
| 0| 成功|
| 1| 不快感を与える文字列|
| 2| 文字列が長すぎます|
| 3| 不明なエラー|

<a id="ID4ELD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4END"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクトの参照](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a>リファレンス

[POST (/system/strings/validate)](../uri/stringserver/uri-systemstringsvalidatepost.md)
