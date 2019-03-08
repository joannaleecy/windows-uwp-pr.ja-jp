---
title: Xbox Live SDK の新規事項 - March 2017
description: Xbox Live SDK の新規事項 - March 2017
ms.assetid: 03180585-6f87-4929-acfc-750bd78988a0
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: be8127e01d8eaae96a1d71f71967a653c00b0280
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595347"
---
# <a name="whats-new-for-the-xbox-live-sdk---march-2017"></a>Xbox Live SDK の新規事項 - March 2017

December 2016 リリースで追加された内容については、「[新規事項 - December 2016](1612-whats-new.md)」を参照してください。

## <a name="xbox-services-api"></a>Xbox サービス API

### <a name="data-platform-2017"></a>データ プラットフォーム 2017

簡略化された統計 API が導入されました。  従来 XDP またはパートナー センターで定義されている統計の規則に対応するイベントを送信する必要がありましたし、これらは、クラウド内の統計値の更新プログラムします。  このモデルを統計 2013 といいます。

統計 2017 では、タイトルが統計値を制御します。  最新の統計値のある API を呼び出すだけで、統計値がイベントを必要とせずに直接サービスに送信されます。  これは、新しい `StatsManager` API を使用するもので、詳細は「[プレイヤー統計](../leaderboards-and-stats-2017/player-stats.md)」に記載されています。

### <a name="github"></a>GitHub

Xbox Live API (XSAPI) は、GitHub ([https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api)) に公開されています。  XDK に付属のバイナリまたは NuGet パッケージとしての使用も推奨していますが、ソースを使用したり、ソース コードに貢献していただくことも歓迎します。  

## <a name="xbox-live-creators-program"></a>Xbox Live クリエーターズ プログラム

Xbox Live クリエーターズ プログラムは、幅広い対象デベロッパーに Xbox Live 機能のサブセットを提供するデベロッパー プログラムです。  既に ID@Xbox プログラムを使用している場合には、これによる影響はありません。

プログラムの詳細については、「[開発者プログラムの概要](../developer-program-overview.md)」を参照してください。

## <a name="documentation"></a>ドキュメント

以下の新しい記事があります

| 記事 | 説明 |
|---------|-------------|
|[Xbox Live サービスの構成](../xbox-live-service-configuration.md) | Xbox Live タイトル用のサービス構成の実行に関する最新情報
| [構成の Xbox Live Unity で](../get-started-with-creators/configure-xbox-live-in-unity.md) | Xbox Live クリエーターズ プログラムのデベロッパー向けの Unity セットアップに関する新しい情報 |
| [Xbox Live のサンド ボックス](../xbox-live-sandboxes.md) | Xbox Live サンド ボックスとコンテンツの分離の簡易ガイド |
| [Xbox Live のテスト アカウント](../xbox-live-test-accounts.md) | パートナー センターを作成する方法とアカウントの作業をテストする方法については |
