---
title: "Xbox Live API の新規事項 - April 2017"
author: KevinAsgari
description: "Xbox Live API の新規事項 - April 2017"
ms.assetid: 
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live、Xbox、ゲーム、UWP、Windows 10、Xbox One、アリーナ、トーナメント"
ms.openlocfilehash: 1f4f5be09858ca93f51813d8d926973dd51a17e0
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="whats-new-for-the-xbox-live-apis---april-2017"></a>Xbox Live API の新規事項 - April 2017

March 2017 リリースで追加された内容については、「[新規事項 - March 2017](1703-whats-new.md)」を参照してください。

## <a name="xbox-services-apis"></a>Xbox サービス API

### <a name="visual-studio-2017"></a>Visual Studio 2017

Xbox Live API は、ユニバーサル Windows プラットフォーム (UWP) および Xbox One タイトルのために Visual Studio 2017 をサポートするように更新されました。

### <a name="tournaments"></a>トーナメント

トーナメントをサポートするための新しい API が追加されました。 `xbox::services::tournaments::tournament_service` クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。

これらの新しいトーナメント API では、以下のシナリオが可能になります。

* サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。
* サービスからトーナメントに関する詳細を取得する。
* サービスをクエリしてトーナメントのチームの一覧を取得する。
* サービスからトーナメントのチームに関する詳細を取得する。
* リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。
