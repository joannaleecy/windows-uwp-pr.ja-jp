---
title: 標準の HTTP 状態コード
assetID: 7a19de56-7acd-ad2b-e8e6-53126991093b
permalink: en-us/docs/xboxlive/rest/httpstatuscodes.html
author: KevinAsgari
description: " 標準の HTTP 状態コード"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5540339d61c81b08b9843f7352ac816d93fcf12e
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5986283"
---
# <a name="standard-http-status-codes"></a>標準の HTTP 状態コード
 
標準的なハイパー テキスト トランスポート プロトコル (HTTP) では、さまざまなクライアント要求に対する応答としてサーバーによって返されるステータス コードについて説明します。 Xbox Live サービスのメソッドは、要求の状態を記述する HTTP プロトコルに準拠した状態コードを返します。
 
Xbox Live サービスとその一般的な意味によって返されるステータス コードの一覧を次に示します。
 
<a id="ID4EAB"></a>

 
## <a name="xbox-live-services-status-codes"></a>Xbox Live サービスの状態コード
 
| コード| 理由フレーズ| 説明| 
| --- | --- | --- | 
| 200| OK| 要求が成功しました。| 
| 201| Created| エンティティが作成されました。| 
| 202| Accepted| 要求は受け入れられましたが、まだ完了していません。| 
| 204| No Content| 要求が完了したらが、返されるコンテンツはありません。| 
| 301| 完全に移動| サービスは、さまざまな URI に移動しました。| 
| 302| 見つかった| 要求されたリソースが別の URI 一時的に存在します。| 
| 307| 一時的なリダイレクト| このリソースの URI が一時的に変更されました。| 
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。| 
| 401| 権限がありません| 要求には、ユーザー認証が必要です。| 
| 403| Forbidden| ユーザーまたはサービスの要求は許可されていません。| 
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。| 
| 406| 許容できません。| リソースのバージョンがサポートされていません。| 
| 408| 要求のタイムアウト| 要求にかかった時間が長すぎます。| 
| 409| Conflict| リソースの現在の状態と競合するため、要求を完了しませんでした。| 
| 410| なった| 要求されたリソースが利用可能ではなくなりました。| 
| 412| Precondition Failed| サーバーで、要求者は、要求に前提条件のいずれかが満たしていません。| 
| 416| 範囲が満たされていませんが要求| 要求された範囲は利用できません。| 
| 500| 内部サーバー エラー| サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。| 
| 501| 実装されていません。| サーバーは、要求を満たすために必要な機能をサポートしません。| 
| 503| Service Unavailable| 要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度要求を行ってください。| 
 

> [!NOTE] 
> 一部のリソースとメソッドは、そのリソースやメソッドのコンテキスト内で特定の状態コードの意味の特定の情報を提供します。 詳細については、リソースや使用しているメソッドのドキュメントを参照してください。 

  
<a id="ID4E3BAC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4E5BAC"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EKCAC"></a>

 
##### <a name="reference--universal-resource-identifier-uri-referenceuriatoc-xboxlivews-reference-urismd"></a>参照[ユニバーサル リソース識別子 (URI) リファレンス](../uri/atoc-xboxlivews-reference-uris.md)

 [その他の参照情報](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4EZCAC"></a>

 
##### <a name="external-links--w3org-http11-status-code-definitionshttpwwww3orgprotocolsrfc2616rfc2616-sec10htmlsec10"></a>外部リンク[W3.org: http/1.1 ステータス コード定義](http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html#sec10)

   