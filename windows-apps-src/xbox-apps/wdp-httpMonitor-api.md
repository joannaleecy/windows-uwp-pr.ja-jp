---
title: Device Portal の HTTP モニター API のリファレンス
description: Xbox でフォーカスのあるアプリから HTTP トラフィックにアクセスする方法について説明します。
ms.localizationpriority: medium
ms.topic: article
ms.date: 02/08/2017
ms.openlocfilehash: 8b8828b060e0401e7938517e497bae20e1234baf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645677"
---
# <a name="http-monitor-api-reference"></a>HTTP モニター API のリファレンス   
Dev Home のチェック ボックスをオンにすることにより Xbox 本体で HTTP モニターが有効になっている場合、この API を使用してフォーカスのあるアプリのリアルタイム HTTP トラフィックにアクセスできます。

## <a name="get-if-the-http-monitor-is-enabled"></a>HTTP モニターが有効かどうかを取得

**要求**

Dev Home で HTTP モニターが有効になっているかどうかを取得できます。

メソッド      | 要求 URI
:------     | :-----
GET | /ext/httpmonitor/sessions
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**   
次のフィールドを含む JSON オブジェクト。

* Enabled - (ブール値) Dev Home でチェック ボックスをオンにすることにより Xbox 本体で HTTP モニターが有効になっているかどうか。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 要求は成功しました
4XX | エラー コード
5XX | エラー コード

## <a name="get-http-traffic-from-the-focused-app"></a>フォーカスのあるアプリから HTTP トラフィックを取得します。
**要求**

Dev Home で HTTP モニターが有効になっている場合は、Xbox のフォーカスのあるアプリ (システム アプリでない限り) からリアルタイムで HTTP トラフィックを取得します。

メソッド      | 要求 URI
:------     | :-----
WebSocket | /ext/httpmonitor/sessions
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**   
次のフィールドを含む JSON オブジェクト。

* セッション
    * RequestHeaders - (JSON オブジェクト) HTTP 要求からの要求ヘッダー。
    * RequestContentHeaders - (JSON オブジェクト) HTTP 要求からの要求コンテンツ ヘッダー。
    * RequestURL - (文字列) 要求 URL。
    * RequestMethod - (文字列) 要求メソッド。
    * RequestMessage - (文字列) 要求メッセージは、現在のところ JSON およびテキスト コンテンツのみをサポートしています。
    * ResponseHeaders - (JSON オブジェクト) HTTP 応答からの応答ヘッダー。
    * ResponseContentHeaders - (JSON オブジェクト) HTTP 応答からの応答コンテンツ ヘッダー。
    * StatusCode - (数値) 応答状態コード。
    * ReasponsePhrase - (文字列) 応答理由フレーズ。
    * ResponseMessage - (文字列) 応答メッセージは、現在のところ JSON およびテキスト コンテンツのみをサポートしています。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 要求は成功しました
4XX | エラー コード
403 | HTTP モニターが無効になっています。Dev Home で有効にする必要があります。
5XX | エラー コード

<br />
**使用可能なデバイス ファミリ**

* Windows Xbox