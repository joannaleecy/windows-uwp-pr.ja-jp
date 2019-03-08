---
title: Device Portal の Fiddler API のリファレンス
description: プログラムによって Fiddler のトレースを有効または無効にする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: e7d4225e-ac2c-41dc-aca7-9b1a95ec590b
ms.localizationpriority: medium
ms.openlocfilehash: f60f3fc8678208f694a9ffabde06fa60de759a45
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603337"
---
# <a name="fiddler-settings-api-reference"></a>Fiddler 設定 API のリファレンス   
この REST API を使って、開発機での Fiddler のネットワーク トレースを有効または無効にすることができます。

## <a name="determine-if-fiddler-tracing-is-enabled"></a>Fiddler トレースが有効になっているかどうかを判断します。

**要求**

次の要求を使って、デバイスで Fiddler トレースが有効になっているかどうかを確認することができます。

メソッド      | 要求 URI
:------     | :-----
GET | /ext/fiddler
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**   

- なし

**応答**   

- プロキシが有効かどうかを指定する JSON ブール プロパティ IsProxyEnabled。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 成功
4XX | エラー コード
5XX | エラー コード

## <a name="enable-fiddler-tracing"></a>Fiddler のトレースを有効にする

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

## <a name="disable-fiddler-tracing-on-the-devkit"></a>開発機で Fiddler のトレースを無効にする

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
**使用可能なデバイス ファミリ**

* Windows Xbox

## <a name="see-also"></a>関連項目
- [Xbox で UWP 用 Fiddler を構成します。](uwp-fiddler.md)

