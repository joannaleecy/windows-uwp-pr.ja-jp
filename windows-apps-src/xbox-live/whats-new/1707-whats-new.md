---
title: "Xbox Live API の新規事項 - July 2017"
author: KevinAsgari
description: "Xbox Live API の新規事項 - July 2017"
ms.assetid: 
ms.author: kevinasg
ms.date: 07-16-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 新規事項, july 2017"
ms.openlocfilehash: cf05aea43c7f974fe9ca4bfd638718ac05b05ad5
ms.sourcegitcommit: 2b436dc5e5681b8884e0531ee303f851a3e3ccf2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/18/2017
---
# <a name="whats-new-for-the-xbox-live-apis---july-2017"></a>Xbox Live API の新規事項 - July 2017

June 2017 リリースで追加された内容については、「[新規事項 - June 2017](1706-whats-new.md)」を参照してください。

[Xbox Live API GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。

## <a name="xbox-live-features"></a>Xbox Live の機能

### <a name="multiplayer-updates"></a>マルチプレイヤーの更新

アクティビティ ハンドルと検索ハンドルの照会の応答にカスタム セッション プロパティが含まれるようになりました。

### <a name="tournaments"></a>トーナメント

トーナメントをサポートするための新しい API が追加されました。 xbox::services::tournaments::tournament_service クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。
これらの新しいトーナメント API では、以下のシナリオが可能になります。
* サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。
* サービスからトーナメントに関する詳細を取得する。
* サービスをクエリしてトーナメントのチームの一覧を取得する。
* サービスからトーナメントのチームに関する詳細を取得する。
* リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。
