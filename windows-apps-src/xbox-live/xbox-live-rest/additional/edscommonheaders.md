---
title: EDS 共通ヘッダー
assetID: 91297c9e-709d-7886-1da0-8a896c4953f4
permalink: en-us/docs/xboxlive/rest/edscommonheaders.html
description: " EDS 共通ヘッダー"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 51a85383ee75fa51cb8376451ac955dcc4fa2edf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630707"
---
# <a name="eds-common-headers"></a>EDS 共通ヘッダー

<a id="ID4EO"></a>



## <a name="entertainment-discovery-services-eds-common-request-headers"></a>エンターテイメント検出サービス (EDS) 一般的な要求ヘッダー

| ヘッダー名| 説明| 必須?| 説明|
| --- | --- | --- | --- |
| <b>x-xbl-contract-version</b>| EDS サービスのバージョン| ○| 3.2|
| <b>x-xbl-client-type</b>| クライアントの種類のヘッダー| ○| 独自のクライアントの種類を取得するチームに読み上げます。|
| <b>x-xbl-client-version</b>| クライアントのバージョン| ○| 任意の空でない文字列。|
| <b>x-xbl-parent-ig</b>| 印象の guid| ○| ログ内やその他のサービス呼び出し間に要求を追跡するために使用します。|
| <b>x-xbl-device-type</b>| デバイスの種類| ○| クライアントを表すデバイスです。|
| <b>OK</b>| 型をそのまま使用します。| ○| XML または JSON です。|
| <b>承認</b>| Auth ヘッダー| ○|  |
| <b>x-xbl-autoSuggest-seed-text</b>| 自動は、シードのテキストをお勧めします| no| BI の使用と関連性|
| <b>x-xbl-search-term</b>| 検索語句| no|  |
| <b>x xbl 入力メソッド</b>| ユーザーによって使用される入力メソッド| no| コント ローラーで、音声、Kinect します。|
| <b>x-xbl-kinect-enabled</b>| 有効になっている Kinect| no| はい/いいえ。|
| <b>x-xbl-speech-session-id</b>| 音声セッションの ID| no| かどうかのセッションでは、音声認識を使用して開始されました。|
| <b>x-xbl-client-id</b>| 匿名クライアント Id| no| BI レポートと関連性のために使用します。|
| <b>x xbl デバイス id</b>| デバイス ID| no| BI レポートと関連性のために使用します。|
| <b>x-xbl-user-agent</b>| クライアント ユーザー エージェント| no| BI を使用します。 "&lt;名 >/&lt;バージョン > (&lt;OS のバージョン >;&lt;プラットフォーム >;&lt;機能 >;&lt;製造 >;&lt;モデル >)"。|
| <b>x-xbl-parent-ig</b>| 「連結された」の呼び出しの前の印象 Guid| いいえ (ただし強くお勧めします)| BI の関連性にとって重要です。 たとえば、参照呼び出しの IG を次の詳細を IG の親であります。|
| <b>delid</b>| Id を委任します。| no| 内部サービスによって使用される、ユーザーの代理として動作します。|

## <a name="common-response-headers"></a>一般的な応答ヘッダー

| ヘッダー名| 説明| 必須?| 説明|
| --- | --- | --- | --- | --- | --- | --- | --- |
| <b>キャッシュ</b>| キャッシュ ヘッダー| ○| 参照してください<a href="https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9"> http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9</a>します。|
| <b>x-xbl-errors</b>| エラー| no| さまざまなデータ プロバイダーからのエラーの一覧です。|
| <b>x-xbl-traceid</b>| ログからのトレース Id| ○| 要求固有のログを追跡するために使用します。|
| <b>x-server-name</b>| 要求を処理するサーバーの名前を難読化します。| ○| 内部デバッグに使用します。|

<a id="ID4EECAC"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EGCAC"></a>


##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)


<a id="ID4ESCAC"></a>


##### <a name="further-information"></a>詳細情報

[Marketplace の Uri](../uri/marketplace/atoc-reference-marketplace.md)
