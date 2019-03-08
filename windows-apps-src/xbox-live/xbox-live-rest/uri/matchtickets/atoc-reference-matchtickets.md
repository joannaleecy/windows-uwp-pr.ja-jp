---
title: マッチメイキング URI
assetID: 667b02a9-6f34-8165-001b-ee8782575202
permalink: en-us/docs/xboxlive/rest/atoc-reference-matchtickets.html
description: " マッチメイキング URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c52abca7ed49d4a5e14520095ae944938b86f093
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590467"
---
# <a name="matchmaking-uris"></a>マッチメイキング URI
 
このセクションでは、マッチメイ キング サービスの Xbox Live サービスから Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供します。 
 
<a id="ID4E6"></a>

 
## <a name="domain"></a>ドメイン
momatch.xboxlive.com  
<a id="ID4EEB"></a>

 
## <a name="service-version"></a>サービスのバージョン
 
これらの HTTP/REST Uri の呼び出し元する必要があります値を渡す 103 以降 X Xbl-コントラクトのバージョン、エンターテイメント検出サービス (EDS) のサービスのバージョンを指定する HTTP ヘッダー。 
  
<a id="ID4ELB"></a>

 
## <a name="system-objects-and-properties"></a>システム オブジェクトとプロパティ
 
現時点では、サービス設定の部分を使用してマッチメイ キング サービスのすべての構成が手動で発生した、 [Xbox 開発者ポータル (XDP)](https://xdp.xboxlive.com)または[パートナー センター](https://partner.microsoft.com/dashboard)します。 いくつかのマッチメイ キング情報は、MPSD に対して定義されているオブジェクトにも反映されます。 
 
マッチメイ キングを構成するために使用される主な JSON オブジェクトが定義されている[MatchTicket (JSON)](../../json/json-matchticket.md)と[HopperStatsResults (JSON)](../../json/json-hopperstatsresults.md)します。 チケットが一致するすべてのメモを定義する必要があります、 **ticketSessionRef**プレーヤーまたは他のユーザーと一致することを希望するプレーヤーを含むマルチ プレーヤーのセッションへの参照を提供するオブジェクト。 
  
<a id="ID4EBC"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/serviceconfigs/{scid}/hoppers/{hoppername}](uri-serviceconfigsscidhoppershoppername.md)

&nbsp;&nbsp;一致のチケットを作成する POST 操作をサポートしています。 

[/serviceconfigs/{scid}/hoppers/{name}/stats](uri-serviceconfigsscidhoppershoppernamestats.md)

&nbsp;&nbsp;Hopper の統計情報を取得するための GET 操作をサポートしています。

[/serviceconfigs/{scid}/hoppers/{hoppername}/tickets/{ticketid}](uri-scidhoppernameticketid.md)

&nbsp;&nbsp;一致するチケットの削除操作をサポートしています。
 
<a id="ID4ENC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EPC"></a>

   [MatchTicket (JSON)](../../json/json-matchticket.md)

 [HopperStatsResults (JSON)](../../json/json-hopperstatsresults.md)

 [セッション ディレクトリの Uri](../sessiondirectory/atoc-reference-sessiondirectory.md)

  
<a id="ID4E2C"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   