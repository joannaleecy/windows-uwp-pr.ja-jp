---
title: BatchRequest (JSON)
assetID: 2ca34506-8801-efc5-7c83-3c9ec5572276
permalink: en-us/docs/xboxlive/rest/json-batchrequest.html
description: " BatchRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 51073c71700613edcd7c22e18cc0c00a9222d7e5
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8920493"
---
# <a name="batchrequest-json"></a>BatchRequest (JSON)
ユーザー、デバイス、およびタイトルなどのプレゼンス情報をフィルター処理するためのプロパティの配列です。
<a id="ID4EN"></a>


## <a name="batchrequest"></a>BatchRequest

BatchRequest オブジェクトには、次仕様があります。

| メンバー| 種類| 説明|
| --- | --- | --- |
| ユーザー| 文字列の配列| については、1100 Xuid、一度に最大プレゼンスがユーザーの Xuid をリストします。|
| deviceTypes| 文字列の配列| について知りたいユーザーに使用されるデバイスの種類の一覧です。 空の配列の場合、既定値はすべての可能なデバイスの種類 (つまり、none が除外されます)。|
| タイトル| 32 ビットの符号なし整数の配列| デバイスの一覧について理解していることをユーザーを種類します。 空の配列の場合、既定値はすべての可能なタイトル (つまり、none が除外されます)。|
| level| string| 設定可能な値: <ul><li>ユーザーのユーザーのノードを入手します。</li><li>デバイスの取得ユーザーとデバイス ノード</li><li>タイトルのタイトルの基本的なレベルの情報の取得</li><li>リッチ プレゼンス情報やメディアについては、すべてを取得します。</li></ul>既定値は、「タイトル」です。| 
| ガジェットの onlineOnly| ブール値| このプロパティが true の場合は、バッチ操作はオフラインのユーザーが (回答が決まるものを含む) のレコードをフィルター処理します。 指定されていない場合は、オンラインとオフライン両方のユーザーが返されます。|

<a id="ID4EAD"></a>


## <a name="sample-json-syntax"></a>JSON 構文の例


```json
{
  users:
  [
    "1234567890",
    "4567890123",
    "7890123456"
  ]
}


```


<a id="ID4EJD"></a>


## <a name="see-also"></a>関連項目

<a id="ID4ELD"></a>


##### <a name="parent"></a>Parent

[JavaScript Object Notation (JSON) オブジェクト リファレンス](atoc-xboxlivews-reference-json.md)


<a id="ID4EXD"></a>


##### <a name="reference"></a>リファレンス   
