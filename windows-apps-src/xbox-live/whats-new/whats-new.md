---
title: Xbox Live の新機能
description: Xbox Live SDK の新機能
ms.date: 10/23/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 33e5b6afbf0d60679bfce1789be2d965fd881f1c
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8755609"
---
# <a name="whats-new-for-xbox-live"></a>Xbox Live の新機能
[Xbox Live API GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。

## <a name="in-this-article"></a>この記事の内容

* [6 月 2018](#june-2018)
* [2017 年 8 月](#august-2017)
* [2017 年 7 月](#july-2017)
* [2017 年 6 月](#june-2017)
* [2017 年 5 月](#may-2017)
* [2017 年 4 月](#april-2017)
* [2017 年 3 月](#march-2017)
* [アーカイブされた記事](#archived)

## <a name="june-2018"></a>6 月 2018

### <a name="xbox-live-features"></a>Xbox Live の機能

#### <a name="c-api-layer-for-xsapi"></a>Xsapi C API レイヤー

一部の Xbox Live 機能の C++ Api が利用できるようになりました。 新しい API レイヤーでは、カスタムのメモリ管理、手動のスレッド管理の非同期タスクは、新しい HTTP ライブラリなど、サポートされている機能の多くのメリットを提供します。

詳細については、 [Xbox Live C Api](../xsapi-flat-c.md)を参照してください。

## <a name="august-2017"></a>2017 年 8 月

### <a name="xbox-live-features"></a>Xbox Live の機能

#### <a name="in-game-clubs"></a>ゲーム内クラブ

開発者は、"ゲーム内クラブ" を作成できるようになりました。 ゲーム内クラブは、開発者が完全にカスタマイズ可能であり、ゲームの内部と外部の両方で使うことができる点で標準の Xbox クラブとは異なります、 ゲーム開発者は、これらを使って、チーム、仲間、スクワッドなど、独自の要件を満たすあらゆる種類の永続グループ シナリオをゲーム内にすばやく構築することができます。

Xbox Live メンバーは、Xbox コンソール、PC、または iOS/Android デバイスで自由にチャット、フィード、LFG、Mixer などのクラブ機能を使って、どの Xbox エクスペリエンスにおいてもゲームの外部でゲーム内クラブにアクセスして相互につながり、ゲームとの接続を維持できます。

API を使うと、ゲーム内から直接ゲーム内クラブを作成および管理できます。 これらの API は、xbox::services::clubs 名前空間に存在します。

## <a name="july-2017"></a>2017 年 7 月

### <a name="xbox-live-features"></a>Xbox Live の機能

#### <a name="tournaments"></a>トーナメント

トーナメントをサポートするための新しい API が追加されました。 xbox::services::tournaments::tournament_service クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。
これらの新しいトーナメント API では、以下のシナリオが可能になります。

* サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。
* サービスからトーナメントに関する詳細を取得する。
* サービスをクエリしてトーナメントのチームの一覧を取得する。
* サービスからトーナメントのチームに関する詳細を取得する。
* リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。

## <a name="june-2017"></a>2017 年 6 月

### <a name="xbox-live-features"></a>Xbox Live の機能

#### <a name="game-chat-2"></a>ゲーム チャット 2

ゲーム チャットの更新および強化されたバージョンを利用できるようになりました。 詳細については、「[ゲーム チャット 2 の概要](../multiplayer/chat/game-chat-2-overview.md)」を参照してください。

### <a name="xbox-live-tools"></a>Xbox Live ツール

#### <a name="xbox-live-powershell-module"></a>Xbox Live PowerShell モジュール

* 開発用コンピューターでサンドボックスを簡単に切り替えることができるように、PowerShell モジュールが追加されました。 詳細については、「[ツール](../tools/tools.md)」を参照してください。

#### <a name="bug-fixes"></a>バグ修正

* さまざまなバグを修正しました。 詳しい一覧については、[GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページをご覧ください。

## <a name="may-2017"></a>2017 年 5 月

### <a name="xbox-services-apis"></a>Xbox サービス API

#### <a name="multiplayer"></a>マルチプレイヤー

* 検索ハンドルの照会を今すぐには、応答にカスタム セッション プロパティが含まれています。

#### <a name="bug-fixes"></a>バグ修正

* 有効な HTTP エラー コードではなく "bad json" が返されるバグを修正しました。

## <a name="april-2017"></a>2017 年 4 月

### <a name="xbox-services-apis"></a>Xbox サービス API

#### <a name="visual-studio-2017"></a>Visual Studio 2017

Xbox Live API は、ユニバーサル Windows プラットフォーム (UWP) および Xbox One タイトルのために Visual Studio 2017 をサポートするように更新されました。

#### <a name="tournaments"></a>トーナメント

トーナメントをサポートするための新しい API が追加されました。 `xbox::services::tournaments::tournament_service` クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。

これらの新しいトーナメント API では、以下のシナリオが可能になります。

* サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。
* サービスからトーナメントに関する詳細を取得する。
* サービスをクエリしてトーナメントのチームの一覧を取得する。
* サービスからトーナメントのチームに関する詳細を取得する。
* リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。

## <a name="march-2017"></a>2017 年 3 月

### <a name="xbox-services-api"></a>Xbox サービス API

#### <a name="data-platform-2017"></a>データ プラットフォーム 2017

簡略化された統計 API が導入されました。  従来 XDP またはパートナー センターで定義された統計の規則に対応するイベントを送信する必要があるし、これらによってクラウドの統計の値を更新します。  このモデルを統計 2013 といいます。

統計 2017 では、タイトルが統計値を制御します。  最新の統計値のある API を呼び出すだけで、統計値がイベントを必要とせずに直接サービスに送信されます。  これは、新しい `StatsManager` API を使用するもので、詳細は「[プレイヤー統計](../leaderboards-and-stats-2017/player-stats.md)」に記載されています。

#### <a name="github"></a>GitHub

Xbox Live API (XSAPI) は、GitHub ([https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api)) に公開されています。  XDK に付属のバイナリまたは NuGet パッケージとしての使用も推奨していますが、ソースを使用したり、ソース コードに貢献していただくことも歓迎します。  

### <a name="xbox-live-creators-program"></a>Xbox Live クリエーターズ プログラム

Xbox Live クリエーターズ プログラムは、幅広い対象デベロッパーに Xbox Live 機能のサブセットを提供するデベロッパー プログラムです。  既に ID@Xbox プログラムを使用している場合には、これによる影響はありません。

プログラムの詳細については、「[開発者プログラムの概要](../developer-program-overview.md)」を参照してください。

### <a name="documentation"></a>ドキュメント

以下の新しい記事があります。

| 記事 | 説明 |
|---------|-------------|
|[Xbox Live サービス構成](../xbox-live-service-configuration.md) | Xbox Live タイトル用のサービス構成の実行に関する最新情報
| [Unity で Xbox Live を構成する](../get-started-with-creators/configure-xbox-live-in-unity.md) | Xbox Live クリエーターズ プログラムのデベロッパー向けの Unity セットアップに関する新しい情報 |
| [Xbox Live のサンドボックス](../xbox-live-sandboxes.md) | Xbox Live サンド ボックスとコンテンツの分離の簡易ガイド |
| [Xbox Live テスト アカウント](../xbox-live-test-accounts.md) | アカウントの機能とパートナー センターでそれらを作成する方法をテストする方法に関する情報 |

## <a name="archived"></a>アーカイブされた記事

* [2016 年 12 月](1612-whats-new.md)
* [2016 年 11 月](1611-whats-new.md)
* [2016 年 8 月](1608-whats-new.md)
* [2016 年 6 月](1606-whats-new.md)
* [2016 年 4 月](1603-whats-new.md)
* [2016 年 3 月](1603-whats-new.md)
* [2016 年 2 月](1602-whats-new.md)
* [2015 年 10 月](1510-whats-new.md)
* [2015 年 9 月](1509-whats-new.md)
* [2015 年 8 月](1508-whats-new.md)
* [2015 年 6 月](1506-whats-new.md)
