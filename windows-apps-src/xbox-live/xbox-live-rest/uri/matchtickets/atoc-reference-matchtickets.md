---
title: マッチメイ キング Uri
assetID: 667b02a9-6f34-8165-001b-ee8782575202
permalink: en-us/docs/xboxlive/rest/atoc-reference-matchtickets.html
author: KevinAsgari
description: " マッチメイ キング Uri"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7bfeb225c67567c392615686743828941c02f6d2
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3963033"
---
# <a name="matchmaking-uris"></a>マッチメイ キング Uri
 
このセクションでは、マッチメイ キング サービス用の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法についての詳細を提供します。 
 
<a id="ID4E6"></a>

 
## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EEB"></a>

 
## <a name="service-version"></a>サービスのバージョン
 
これらの HTTP/REST Uri の呼び出し元する必要があります値を渡す 103 以降 X-Xbl-コントラクトのバージョン、サービスのバージョンのエンターテインメント探索サービス (EDS) を指定する HTTP ヘッダー。 
  
<a id="ID4ELB"></a>

 
## <a name="system-objects-and-properties"></a>システム オブジェクトとプロパティ
 
現時点では、マッチメイ キング サービスのすべての構成が発生した手動で、 [Xbox デベロッパー ポータル (XDP)](https://xdp.xboxlive.com)または[Windows デベロッパー センター](https://partner.microsoft.com/dashboard/windows/overview)のサービス構成部分を使用します。 マッチメイ キングのいくつかの情報は、MPSD に定義されたオブジェクトにも反映されます。 
 
マッチメイ キングを構成するために使われるメインの JSON オブジェクトは、 [MatchTicket (JSON)](../../json/json-matchticket.md)と[HopperStatsResults (JSON)](../../json/json-hopperstatsresults.md)で定義されます。 すべてのマッチ チケットが他のユーザーと一致する必要があるプレイヤーが含まれているマルチプレイヤー セッションへの参照を提供する**ticketSessionRef**オブジェクトを定義する必要があることに注意してください。 
  
<a id="ID4EBC"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/serviceconfigs/{scid}/hoppers/{hoppername}](uri-serviceconfigsscidhoppershoppername.md)

&nbsp;&nbsp;マッチ チケットを作成する POST 操作をサポートしています。 

[/serviceconfigs/{scid}/hoppers/{name}/統計](uri-serviceconfigsscidhoppershoppernamestats.md)

&nbsp;&nbsp;ホッパーの統計情報を取得するための取得操作をサポートしています。

[/serviceconfigs/{scid} {hoppername}/hoppers//tickets/{ticketid}](uri-scidhoppernameticketid.md)

&nbsp;&nbsp;マッチ チケットの削除操作をサポートしています。
 
<a id="ID4ENC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EPC"></a>

   [MatchTicket (JSON)](../../json/json-matchticket.md)

 [HopperStatsResults (JSON)](../../json/json-hopperstatsresults.md)

 [セッション ディレクトリ Uri](../sessiondirectory/atoc-reference-sessiondirectory.md)

  
<a id="ID4E2C"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   