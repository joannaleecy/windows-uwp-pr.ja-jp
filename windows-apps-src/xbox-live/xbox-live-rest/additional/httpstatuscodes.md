---
title: 標準の HTTP 状態コード
assetID: 7a19de56-7acd-ad2b-e8e6-53126991093b
permalink: en-us/docs/xboxlive/rest/httpstatuscodes.html
description: " 標準の HTTP 状態コード"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c77972e88dbf4950f716594ee61220d1734a7fef
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635557"
---
# <a name="standard-http-status-codes"></a>標準の HTTP 状態コード
 
標準的なハイパー テキスト転送プロトコル (HTTP) には、さまざまなサーバーはクライアント要求への応答で返されるステータス コードがについて説明します。 Xbox Live サービス メソッドでは、要求の状態を記述する HTTP プロトコル準拠ステータス コードを返します。
 
Xbox Live サービス、およびその一般的な意味で返されるステータス コードの一覧を示します。
 
<a id="ID4EAB"></a>

 
## <a name="xbox-live-services-status-codes"></a>Xbox Live サービスの状態コード
 
| コード| 理由語句| 説明| 
| --- | --- | --- | 
| 200| OK| 要求が成功します。| 
| 201| 作成日| エンティティが作成されました。| 
| 202| Accepted| 要求は受け入れられましたが、まだ完了していません。| 
| 204| コンテンツはありません| 要求が完了したらが、コンテンツを返すことはありません。| 
| 301| 完全に移動| サービスが別の URI に移動します。| 
| 302| 見つかりません| 別の uri、要求されたリソースが一時的に存在します。| 
| 307| 一時的なリダイレクト| このリソースの URI が一時的に変更されました。| 
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスは、要求することはできません。| 
| 404| 検出不可| 指定されたリソースが見つかりませんでした。| 
| 406| Not Acceptable| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| 要求がかかり過ぎて、完了します。| 
| 409| Conflict| リソースの現在の状態と競合するため、要求が完了しませんでした。| 
| 410| なった| 要求されたリソースは使用できなくします。| 
| 412| Precondition Failed| サーバーには、要求元は、要求に前提条件が満たしていません。| 
| 416| 要求の範囲が満たされていません| 要求された範囲は、ご利用いただけません。| 
| 500| 内部サーバー エラー| サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。| 
| 501| 実装されていません| サーバーは、要求を満たすために必要な機能をサポートしていません。| 
| 503| サービス利用不可| 要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。| 
 

> [!NOTE] 
> 一部のリソースとメソッドは、そのリソースまたはメソッドのコンテキスト内で特定のステータス コードの意味について特定の情報を提供します。 詳細については、リソースまたは使用しているメソッドは、ドキュメントを参照してください。 

  
<a id="ID4E3BAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E5BAC"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EKCAC"></a>

 
##### <a name="reference--universal-resource-identifier-uri-referenceuriatoc-xboxlivews-reference-urismd"></a>参照[Universal Resource Identifier (URI) のリファレンス](../uri/atoc-xboxlivews-reference-uris.md)

 [その他の参照](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EZCAC"></a>

 
##### <a name="external-links--w3org-http11-status-code-definitionshttpswwww3orgprotocolsrfc2616rfc2616-sec10htmlsec10"></a>外部リンク[W3.org:Http/1.1 ステータス コードの定義](https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10)

   