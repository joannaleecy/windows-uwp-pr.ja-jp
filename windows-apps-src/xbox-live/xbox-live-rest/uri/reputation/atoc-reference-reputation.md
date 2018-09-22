---
title: 評判 URI
assetID: d1cb76c0-86a4-8c51-19f6-5f223b517d46
permalink: en-us/docs/xboxlive/rest/atoc-reference-reputation.html
author: KevinAsgari
description: " 評判 URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b869f87760498dc6a2224809a42380f1b8f5930b
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4128994"
---
# <a name="reputation-uris"></a>評判 URI
 
このセクションでは、 **Microsoft.Xbox.Services.Social.ReputationService**用の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) メソッドに関する詳細を提供します。 評判 Uri ドメインは、reputation.xboxlive.com です。 一般的な URI 形式がありますhttps://reputation.xboxlive.com/users/xuid(2533274790412952)/feedbackします。 
 
評判サービスで使用してフィードバックを[フィードバック (JSON)](../../json/json-feedback.md)、評判スコアを計算します。 このスコアは、ReputationOverall キーの下で、ユーザーの統計情報の領域に保存されます。 ユーザーの統計情報の取得について詳しくは、以下を参照してください。[を取得する (/users/xuid({xuid})/scids/{scid}/stats)](../userstats/uri-usersxuidscidsscidstatsget.md)します。 
 
すべてのプラットフォームでのゲームでは、評判サービスを使用できます。
 
<a id="ID4EMB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/xuid({xuid})/feedback](uri-reputationusersxuidfeedback.md)

&nbsp;&nbsp;シェルを使用するのではなく、ゲームでフィードバック オプションを追加したい場合に、タイトルから使われます。

[/users/batchfeedback](uri-reputationusersbatchfeedback.md)

&nbsp;&nbsp;タイトルのインターフェイスの外部のバッチ形式でフィードバックを送信するタイトルのサービスによって使用されます。

[/users/me/resetreputation](uri-usersmeresetreputation.md)

&nbsp;&nbsp;現在のユーザーの評判スコアにアクセスする執行チームを使用できます。

[/users/xuid({xuid})/deleteuserdata](uri-usersxuiddeleteuserdata.md)

&nbsp;&nbsp;テスト ユーザーの評判のデータを完全にリセットします。 テストのみです。

[/users/xuid({xuid})/resetreputation](uri-usersxuidresetreputation.md)

&nbsp;&nbsp;指定したユーザーの評判スコアにアクセスするために執行チームを使用できます。
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   