---
title: EDS 共通ヘッダー
assetID: 91297c9e-709d-7886-1da0-8a896c4953f4
permalink: en-us/docs/xboxlive/rest/edscommonheaders.html
author: KevinAsgari
description: " EDS 共通ヘッダー"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 80a38dfa2dad97b4383f86328ddbf61d6e4a299f
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7575592"
---
# <a name="eds-common-headers"></a>EDS 共通ヘッダー

<a id="ID4EO"></a>



## <a name="entertainment-discovery-services-eds-common-request-headers"></a>エンターテイメント探索サービスの要求ヘッダーの一般的な (EDS)

| ヘッダー名| 説明| 必須?| 説明|
| --- | --- | --- | --- |
| <b>x xbl コントラクト バージョン</b>| EDS サービス バージョン| 必須| 3.2|
| <b>x xbl クライアント型</b>| クライアントの種類のヘッダー| 必須| 独自のクライアントの種類を取得するチームに問い合わせます。|
| <b>x xbl クライアント バージョン</b>| クライアントのバージョン| 必須| 任意の空でない文字列。|
| <b>x xbl 親 ig</b>| 印象 guid| 必須| ログに記録し、その他のサービス呼び出しの間での要求を追跡するために使用します。|
| <b>x xbl デバイス型</b>| デバイスの種類| 必須| クライアントを表すデバイス。|
| <b>Accept</b>| 型を受け入れる| 必須| XML または JSON します。|
| <b>Authorization</b>| 認証ヘッダー| 必須|  |
| <b>x xbl-自動提案の-シード-テキスト</b>| 自動提案シード テキスト| ×| BI の使用と関連性|
| <b>x xbl 検索語句</b>| 検索語句| ×|  |
| <b>x xbl 入力方法</b>| ユーザーによって使用される入力方式| ×| コント ローラー、音声認識、Kinect します。|
| <b>x xbl-kinect の対応</b>| Kinect を有効になっています。| ×| はい/いいえ。|
| <b>x xbl-音声-セッションの id</b>| 音声認識セッションの ID| ×| かどうかのセッションでは、音声認識を使用して開始されました。|
| <b>x xbl クライアント id</b>| 匿名のクライアント Id| ×| BI レポートと関連性のために使用します。|
| <b>x xbl デバイス id</b>| デバイス ID| ×| BI レポートと関連性のために使用します。|
| <b>x xbl ユーザー エージェント</b>| クライアントのユーザー エージェント| ×| BI に使用されます。 "&lt;名 >/&lt;バージョン > (&lt;OS バージョン > です。&lt;プラットフォーム > です。&lt;機能 > です。&lt;製造 > です。&lt;モデル >)"。|
| <b>x xbl 親 ig</b>| 「連結された」呼び出しの前の印象 Guid| いいえ (ただし、強く推奨)| BI 関連に重要です。 たとえば、参照の呼び出しの IG は、呼び出しの詳細は次の親 IG です。|
| <b>delid</b>| ユーザーを委任します。| ×| 内部サービスで使用すると、ユーザーの代わりに動作します。|

## <a name="common-response-headers"></a>一般的な応答ヘッダー

| ヘッダー名| 説明| 必須?| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <b>キャッシュ</b>| キャッシュのヘッダー| 必須| 表示<a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9">http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9</a>します。|
| <b>x-xbl エラー</b>| エラー| ×| さまざまなデータ プロバイダーからのエラーの一覧です。|
| <b>x-xbl-traceid</b>| トレース ログから Id| 必須| 要求の特定のログを追跡するために使用します。|
| <b>x サーバー名</b>| 要求を処理するサーバーの暗号化されている名前。| 必須| 内部デバッグ用に使用します。|

<a id="ID4EECAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EGCAC"></a>


##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)


<a id="ID4ESCAC"></a>


##### <a name="further-information"></a>詳細情報

[マーケットプレース URI](../uri/marketplace/atoc-reference-marketplace.md)
