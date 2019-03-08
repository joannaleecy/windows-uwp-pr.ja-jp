---
title: 評判 URI
assetID: d1cb76c0-86a4-8c51-19f6-5f223b517d46
permalink: en-us/docs/xboxlive/rest/atoc-reference-reputation.html
description: " 評判 URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 93d6d6e6acfd8fa39bd9d26c87ed99362d2c88d6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57614007"
---
# <a name="reputation-uris"></a>評判 URI
 
このセクションでは、Universal Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト転送プロトコル (HTTP) のメソッドに関する詳細情報を提供の Xbox Live サービスから、 **Microsoft.Xbox.Services.Social.ReputationService**. Uri の評判のドメインとは、reputation.xboxlive.com です。 一般的な URI 形式があります https://reputation.xboxlive.com/users/xuid(2533274790412952)/feedbackします。 
 
」の説明に従って、reputation service は、フィードバックを使用して[フィードバック (JSON)](../../json/json-feedback.md)、評価スコアを計算します。 このスコアは、ReputationOverall キー下のユーザーの統計情報の領域に保存されます。 ユーザーの統計情報を取得する方法についての詳細については、次を参照してください。[取得 (/users/xuid({xuid})/scids/{scid}/stats)](../userstats/uri-usersxuidscidsscidstatsget.md)します。 
 
すべてのプラットフォームでのゲームでは、評価サービスを使用できます。
 
<a id="ID4EMB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/xuid({xuid})/feedback](uri-reputationusersxuidfeedback.md)

&nbsp;&nbsp;シェルを使用するのではなく、ゲームのフィードバックのオプションを追加したい場合、タイトルから使用されます。

[/users/batchfeedback](uri-reputationusersbatchfeedback.md)

&nbsp;&nbsp;タイトルのインターフェイスの外部でのバッチの形式でフィードバックを送信するタイトルのサービスで使用します。

[/users/me/resetreputation](uri-usersmeresetreputation.md)

&nbsp;&nbsp;現在のユーザーの評価スコアにアクセスする強制チームを有効にします。

[/users/xuid({xuid})/deleteuserdata](uri-usersxuiddeleteuserdata.md)

&nbsp;&nbsp;テスト ユーザーの評価データを完全にリセットします。 テスト目的専用です。

[/users/xuid({xuid})/resetreputation](uri-usersxuidresetreputation.md)

&nbsp;&nbsp;指定したユーザーの評価スコアにアクセスする強制チームを有効にします。
 
<a id="ID4E5B"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   