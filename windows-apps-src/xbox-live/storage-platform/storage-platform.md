---
title: Xbox Live ストレージ プラットフォーム
author: KevinAsgari
description: 接続ストレージとタイトル ストレージを含む、Xbox Live ストレージ プラットフォームについて説明します。
ms.assetid: 3c92549c-65fd-4d26-a693-3aded8bae498
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ef948a581c52f4b8ef781457b8e30851abf77723
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6277993"
---
# <a name="xbox-live-storage-platform---connected-storage-title-storage"></a>Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ

Xbox Live では、発行元がグローバル タイトル データとプレイヤー固有のデータをクラウドに保存できます。

## <a name="in-this-section"></a>このセクションの内容

[接続ストレージ](connected-storage/connected-storage-overview.md)ユーザーごとの接続ストレージ API を使用して格納されたデータは、ユーザー用に PC と複数の Xbox One 本体に自動的にローミングされ、オフラインでも使用できます。 このサービスを使用すると、デバイスを切り替えた後、タイトルを再起動するときにゲームプレイをスムーズに続行できます。 接続ストレージ サービスを使用して、インベントリ、ゲームの状態、ゲーム内の現在位置などの進行状況のデータを頻繁に保存してください。 接続ストレージ サービスは、よりフォールト トレラントなクラウド ストレージ サービスであり、ネットワークや電源障害の影響を受けにくくなっています。

[Xbox Live タイトル ストレージ](xbox-live-title-storage/xbox-live-title-storage.md) Xbox Live タイトル ストレージ サービスでは、ゲーム データやタイトル アセットをクラウドに格納して共有できます。 どのプラットフォームで実行されるゲームでも、これをオンラインで使用できます。 このサービスによって、コンシューマー用のデータの可視性をより細かく制御できるようになるだけでなく、ユーザーごとのデータに加えてタイトルごとのグローバル データの可視性も向上します。 タイトル ストレージは、プレイヤーの統計、プレイヤーのランキング、ロックできないアートワークなどのタイトル アセットを格納するのに便利です。