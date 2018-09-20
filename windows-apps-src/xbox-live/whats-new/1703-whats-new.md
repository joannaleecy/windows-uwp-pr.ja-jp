---
title: Xbox Live SDK の新規事項 - March 2017
author: KevinAsgari
description: Xbox Live SDK の新規事項 - March 2017
ms.assetid: 03180585-6f87-4929-acfc-750bd78988a0
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: cd57ea928db2a04dd4117af439c42666a5d3734e
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4086916"
---
# <a name="whats-new-for-the-xbox-live-sdk---march-2017"></a>Xbox Live SDK の新規事項 - March 2017

December 2016 リリースで追加された内容については、「[新規事項 - December 2016](1612-whats-new.md)」を参照してください。

## <a name="xbox-services-api"></a>Xbox サービス API

### <a name="data-platform-2017"></a>データ プラットフォーム 2017

簡略化された統計 API が導入されました。  これまでは XDP またはデベロッパー センターで定義された統計の規則に対応したイベントを送信する必要があり、これらによってクラウドの統計値を更新していました。  このモデルを統計 2013 といいます。

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
|[Xbox Live サービス構成](../xbox-live-service-configuration.md) | Xbox Live タイトル用のサービス構成の実行に関する最新情報
| [Unity で Xbox Live を構成する](../get-started-with-creators/configure-xbox-live-in-unity.md) | Xbox Live クリエーターズ プログラムのデベロッパー向けの Unity セットアップに関する新しい情報 |
| [Xbox Live のサンドボックス](../xbox-live-sandboxes.md) | Xbox Live サンド ボックスとコンテンツの分離の簡易ガイド |
| [Xbox Live テスト アカウント](../xbox-live-test-accounts.md) | テスト アカウントの機能と Windows デベロッパー センターでのそれらの作成方法に関する情報 |
