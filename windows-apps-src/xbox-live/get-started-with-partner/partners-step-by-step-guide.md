---
title: Xbox Live パートナー向けステップ バイ ステップ ガイド
author: KevinAsgari
description: 対象パートナー向けに Xbox Live を統合するための手順のガイドラインを説明します。
ms.assetid: f0c9db8f-f492-4955-8622-e1736f0a4509
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6c1b1741beaf1ffa2b034726a41c56339136e6f1
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4257712"
---
# <a name="step-by-step-guide-to-integrate-xbox-live-for-managed-partners-and-idxbox-members"></a>対象パートナーおよび ID@Xbox メンバー向けに Xbox Live を統合するためのステップ バイ ステップ ガイド

このセクションは、Xbox Live を開始し実行する際に役立ちます。

## <a name="1-choose-a-platform"></a>1. プラットフォームを選択する
Xbox 開発キット (XDK)、ユニバーサル Windows プラットフォーム (UWP)、またはクロスプレイ ゲームのどれを作成するかを決定します。

- XDK ベースのゲームは Xbox One 本体のみで動作します。
- UWP ゲームは、Windows PC、Windows Phone、Xbox One など、すべての Windows プラットフォームを対象にすることができます。
  - Xbox One については、「[Xbox One の UWP](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index)」をご覧ください。また、「[Xbox One 上の UWP アプリとゲームのシステム リソース](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)」をご覧になることもお勧めします。
- クロスプレイ ゲームは、通常、XDK と UWP の両方のパスを使用する Xbox One と Windows PC を対象とするゲームです。

## <a name="2-ensure-you-have-a-title-created-on-dev-center-or-xdp"></a>2. デベロッパー センターまたは XDP で作成されたタイトルがあることを確認する
すべての Xbox Live タイトルは、サインインして Xbox Live サービスを呼び出すことができるようになるには、デベロッパー センターまたは Xbox デベロッパー ポータル (XDP) で定義されている必要があります。  これを行う方法は、「[新しいタイトルの作成](create-a-new-title.md)」で説明します。

## <a name="3-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a>3. 適切なガイドに従って、IDE やゲーム エンジンをセットアップする
プラットフォームやエンジンに関する適切なファースト ステップ ガイドに従い、それに沿って学習することで、Xbox Live の基本を習得することができます。

* 「[UWP ゲーム用 Visual Studio の使用に関する概要](get-started-with-visual-studio-and-uwp.md)」では、デベロッパー センターで Xbox Live 構成を使用して Visual Studio プロジェクトをリンクする方法について説明します。

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

ID@Xbox タイトルとゲーム パブリッシャーがリリースするタイトルの場合、リリースまでに Microsoft パートナーが認定プロセスに合格する必要があります。  その理由は、こうしたタイトルでは、マルチプレイヤー、実績、リッチ プレゼンスなどの追加機能へアクセスする場合があるためです。  タイトルをリリースする準備ができたら、Microsoft の担当者に申請とリリースのプロセスに関する詳細を問い合わせてください。
