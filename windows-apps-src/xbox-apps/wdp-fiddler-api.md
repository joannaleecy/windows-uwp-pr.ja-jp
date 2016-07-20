---
author: WilliamsJason
title: "Device Portal の Fiddler API のリファレンス"
description: "プログラムによって Fiddler のトレースを有効または無効にする方法について説明します。"
area: Xbox
translationtype: Human Translation
ms.sourcegitcommit: eeb3bc5c4843fe86c54930315d4e112166664e45
ms.openlocfilehash: 435a00eaf9c1f0d8e0c0043229c2adc80638ace3

---

# Fiddler 設定 API のリファレンス   
この REST API を使って、開発機での Fiddler のネットワーク トレースを有効または無効にすることができます。

## Fiddler のトレースを有効にする

**要求**

次の要求を使って、開発機の Fiddler のトレースを有効にすることができます。  この設定を有効にするには、デバイスを再起動する必要があることに注意してください。

メソッド      | 要求 URI
:------     | :-----
POST | /ext/fiddler
<br />
**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

| URI パラメーター      | 説明     | 
| ------------------ |-----------------|
| proxyAddress       | Fiddler を実行しているデバイスの IP アドレスまたはホスト名 |
| proxyPort          | トラフィックを監視するために Fiddler が使用しているポート。 既定では 8888 |
| updateCert (省略可能)| Fiddler のルート証明書が提供されているかどうかを示すブール値。 Fiddler がこの開発機で構成されたことがない場合や、別のホストで構成されていた場合は、true を指定する必要があります。  |
<br>

**要求ヘッダー**

- なし

**要求本文**

- updateCert が false である場合や指定されていない場合は、なし。 それ以外の場合は、FiddlerRoot.cer ファイルを格納する、原則に従ったマルチパートの http 本文。

**応答**   

- なし  

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
204 | Fiddler を有効にする要求が受け付けられました。 Fiddler は、次回デバイスを再起動したときに有効になります。
4XX | エラー コード
5XX | エラー コード

## 開発機で Fiddler のトレースを無効にする

**要求**

次の要求を使って、デバイスでの Fiddler のトレースを無効にすることができます。 この設定を有効にするには、デバイスを再起動する必要があることに注意してください。

メソッド      | 要求 URI
:------     | :-----
DELETE | /ext/fiddler
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**   

- なし

**応答**   

- なし 

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
204 | Fiddler のトレースを無効にする要求が成功しました。 トレースは、次回デバイスを再起動したときに無効になります。
4XX | エラー コード
5XX | エラー コード

<br />
**利用可能なデバイス ファミリ**

* Windows Xbox

## 参照
- [Xbox の UWP での Fiddler の構成](uwp-fiddler.md)




<!--HONumber=Jul16_HO1-->


