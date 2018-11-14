---
title: パートナーとして Xbox Live を使用する際の概要
author: KevinAsgari
description: 対象パートナーや ID@Xbox メンバーが Xbox Live の開発を始める際に役立つリンクを紹介します。
ms.assetid: 69ab75d1-c0e7-4bad-bf8f-5df5cfce13d5
ms.author: kevinasg
ms.date: 06/07/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, パートナー, ID@Xbox
ms.localizationpriority: medium
ms.openlocfilehash: 74b343ce248201b997f5bcd357095154e221092f
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6260670"
---
# <a name="get-started-with-xbox-live-as-a-managed-partner-or-an-idxbox-developer"></a>対象パートナーまたは ID@Xbox 開発者として Xbox Live の利用を開始する

このセクションでは、パートナーまたは ID@Xbox 開発者として Xbox Live の利用を開始する方法について説明します。 パートナーや ID 開発者は、実績やマルチプレイヤーなど、Xbox Live の機能をすべて利用できます。

対象パートナーおよび ID@Xbox 開発者は、ユニバーサル Windows プラットフォーム (UWP) や Xbox 開発キット (XDK) プラットフォームに対応した Xbox Live タイトルを開発できます。

利用可能なコンテンツだけでなくここも含まれますが、承認されたパートナー センター アカウントを持つパートナーが利用できるその他のドキュメント。 そのようなコンテンツには、[Xbox Live パートナー コンテンツ](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/partner-content)でアクセスできます。

## <a name="why-should-you-use-xbox-live"></a>Xbox Live を使用する理由

Xbox Live には、ゲームの販売を促進し、ゲーマーの関心を引き付けておくために設計された一連の機能が用意されています。

- Xbox Live ソーシャル プラットフォームを使用すると、ゲーマーはフレンドと接続してゲームについて会話することができます。
- Xbox Live の実績を利用すると、ゲーマーが実績のロックを解除したときに、Xbox Live のソーシャル グラフにゲームの無料プロモーションが提供され、ゲームの人気を高める際に役立ちます。
- Xbox Live のランキングを利用すると、ゲーマーがフレンドに勝ってランクを上げることが可能になり、ゲームに対するユーザーの関心を高めることができます。
- Xbox Live のマルチプレイヤーを利用すると、ゲーマーがフレンドと一緒にプレイしたり、他のプレイヤーとのマッチメイキングによってゲーム内で戦ったり協力したりすることができます。
- Xbox Live の接続ストレージでは、デバイス間でゲームのセーブ データを無料でローミングでき、ゲーマーは Xbox One と Windows PC の間で簡単にゲームの進行を継続することができます。

## <a name="1-choose-a-platform"></a>1. プラットフォームを選択する
Xbox 開発キット (XDK)、ユニバーサル Windows プラットフォーム (UWP)、またはクロスプレイ ゲームのどれを作成するかを決定します。

- XDK ベースのゲームは Xbox One 本体でのみ動作します。
- UWP ゲームは、Windows PC、Windows Phone、Xbox One など、すべての Windows プラットフォームを対象にすることができます。
  - Xbox One については、「[Xbox One の UWP](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index)」をご覧ください。また、「[Xbox One 上の UWP アプリとゲームのシステム リソース](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)」をご覧になることもお勧めします。
- クロスプレイ ゲームは、通常、XDK と UWP の両方のパスを使用する Xbox One と Windows PC を対象とするゲームです。

## <a name="2-ensure-that-you-have-a-title-created-in-partner-center-or-xdp"></a>2。 パートナー センターまたは XDP で作成されたタイトルがあることを確認します
すべての Xbox Live タイトルは、サインインし、Xbox Live サービスを呼び出すことができます前に、パートナー センターまたは Xbox デベロッパー ポータル (XDP) で定義する必要があります。  これを行う方法は、「[新しいタイトルの作成](create-a-new-title.md)」で説明します。

## <a name="3-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a>3. 適切なガイドに従って IDE やゲーム エンジンをセットアップする
プラットフォームやエンジンに関する適切なファースト ステップ ガイドに従い、それに沿って学習することで、Xbox Live の基本を習得することができます。

* [UWP ゲーム用 Visual Studio を使って概要](get-started-with-visual-studio-and-uwp.md)は方法を説明にパートナー センターで Xbox Live 構成を Visual Studio プロジェクトをリンクします。
* 「[UWP ゲーム用 Unity の使用に関する概要](partner-add-xbox-live-to-unity-uwp.md)」では、Xbox Live 対応の新しい Unity タイトルを作成する方法、ランキングなどの機能をタイトルに追加する方法、およびネイティブの Visual Studio プロジェクトを生成する方法について説明します。
* 「[XDK ベースのゲームで Visual Studio を使用する際の概要](xdk-developers.md)」では、XDK を使用して Xbox One タイトルを作成する場合に Visual Studio プロジェクトをセットアップする方法について説明します。
* 「[クロスプレイ ゲームの作成に関する概要](get-started-with-cross-play-games.md)」では、Xbox One 向けの XDK ベースのゲームと Windows 10 PC 向けの UWP ベースのゲームを作成する方法について説明します。

## <a name="4-xbox-live-concepts"></a>4. Xbox Live の概念
タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。

- [Xbox Live のサンドボックス](../xbox-live-sandboxes.md)
- [Xbox Live テスト アカウント](../xbox-live-test-accounts.md)
- [Xbox Live API の概要](../introduction-to-xbox-live-apis.md)

## <a name="5-add-xbox-live-features"></a>5. Xbox Live の機能を追加する

Xbox Live の機能をゲームに追加します。

- [Xbox Live ソーシャル プラットフォーム - プロフィール、フレンド、プレゼンス](../social-platform/social-platform.md)
- [Xbox Live データ プラットフォーム - 統計、ランキング、実績](../data-platform/data-platform.md)
- [Xbox Live マルチプレイヤー プラットフォーム - 招待、マッチメイキング、トーナメント](../multiplayer/multiplayer-intro.md)
- [Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ](../storage-platform/storage-platform.md)
- [コンテキスト検索](../contextual-search/introduction-to-contextual-search.md)

## <a name="6-release-your-title"></a>6. タイトルをリリースする

ID@Xbox および対象パートナーは、タイトルをリリースする前に認定プロセスに合格する必要があります。  この理由は、タイトルがオンライン マルチプレイヤー、実績、リッチ プレゼンスなどの追加機能にアクセスする場合があるためです。  タイトルをリリースする準備ができたら、Microsoft の担当者に申請とリリースのプロセスに関する詳細をお問い合わせください。
