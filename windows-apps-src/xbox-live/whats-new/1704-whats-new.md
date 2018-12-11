---
title: Xbox Live API の新規事項 - April 2017
description: Xbox Live API の新規事項 - April 2017
ms.assetid: ''
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live、Xbox、ゲーム、UWP、Windows 10、Xbox One、アリーナ、トーナメント
ms.localizationpriority: medium
ms.openlocfilehash: a9256bfce05c14a0bfa63c7ec656dd899648d844
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8947639"
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
