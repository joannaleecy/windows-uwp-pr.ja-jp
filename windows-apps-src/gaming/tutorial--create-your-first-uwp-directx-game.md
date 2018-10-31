---
author: joannaleecy
title: DirectX ユニバーサル Windows プラットフォーム (UWP) ゲームの作成
description: この一連のチュートリアルでは、DirectX と C++ を使って基本的なユニバーサル Windows プラットフォーム (UWP) ゲームを作成する方法を説明します。
ms.assetid: 9edc5868-38cf-58cc-1fb3-8fb85a7ab2c9
keywords: DirectX ゲームのサンプル, ゲームのサンプル, ユニバーサル Windows プラットフォーム (UWP), Direct3D 11 ゲーム
ms.author: joanlee
ms.date: 12/01/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1c589eeb71d93619b92254207ddc5eb1b1494a55
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5866485"
---
# <a name="create-a-simple-universal-windows-platform-uwp-game-with-directx"></a>DirectX を使った単純なユニバーサル Windows プラットフォーム (UWP) ゲームの作成

この一連のチュートリアルでは、DirectX と C++ を使って基本的なユニバーサル Windows プラットフォーム (UWP) ゲームを作成する方法を説明します。 アートやメッシュなどのアセットの読み込み、主要なゲーム ループの作成、簡易なレンダリング パイプラインの実装、サウンドやコントロールの追加を行うプロセスなど、ゲームの主要な要素すべてについて説明します。

UWP ゲーム開発の手法と考慮事項について説明します。 完全なエンド ツー エンドのゲームを示すのではなく、 むしろ、UWP DirectX ゲーム開発の主要な概念に焦点を当てて、これらの概念に関係する Windows ランタイム固有の考慮事項を示します。

## <a name="objective"></a>目標

UWP DirectX ゲームの基本的な概念とコンポーネントを使い、DirectX を使って UWP ゲームをより快適に設計できるようになること。

## <a name="what-you-need-to-know-before-starting"></a>始める前に理解しておく必要があること


説明を始める前に、次の事項について理解しておく必要があります。

-   Microsoft C++ Windows ランタイム言語拡張機能 (C++/CX)。 これは自動参照カウントが組み込まれた Microsoft C++ の更新であり、DirectX 11.1 以降のバージョンを使って UWP ゲームを開発するための言語です。
-   線形代数およびニュートン物理学の基本的な概念。
-   基本的なグラフィックス プログラミング用語。
-   Windows プログラミングの基本的な概念。
-   [Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx) および [Direct3D 11](https://msdn.microsoft.com/library/windows/desktop/hh404569) API に関する基本的な知識。

##  <a name="direct3d-uwp-shooting-game-sample"></a>Direct3D UWP シューティング ゲームのサンプル


このサンプルは、プレイヤーが動く標的に弾を撃つ、簡単なファーストパーソン シューティング ギャラリーを実装しています。 標的に命中するたびにポイントが与えられ、プレーヤーは難度が上がっていく 6 つのレベルを進むことができます。 レベルの最後に、ポイントが集計されて、プレーヤーに最終スコアが与えられます。

サンプルで示されているゲームの概念は、次のとおりです。

-   DirectX 11.1 と Windows ランタイムの間の相互運用
-   主観 3D 視点およびカメラ
-   ステレオスコピック 3D 効果
-   3D でのオブジェクト間の衝突検出
-   マウス、タッチ、Xbox コントローラーからのプレイヤーの入力の処理
-   オーディオ ミキシングおよび再生
-   基本的なゲームのステート マシン

![ゲーム サンプルの動作](images/simple-dx-game-overview.png)

| トピック | 説明 |
|-------|-------------|
|[ゲーム プロジェクトのセットアップ](tutorial--setting-up-the-games-infrastructure.md) | ゲームを作るための最初の手順は、必要なコード インフラストラクチャ作業の量を最小限に抑えるように Microsoft Visual Studio でプロジェクトを設定することです。 適切なテンプレートを使い、ゲーム開発用にプロジェクトを構成することで、時間や手間を大幅に節約できます。 シンプルなゲーム プロジェクトを設定および構成する手順を紹介します。 |
| [ゲームの UWP アプリ フレームワークの定義](tutorial--building-the-games-uwp-app-framework.md) | UWP DirectX ゲーム オブジェクトで Windows と対話するためのフレームワークを構築します。 これには、中断/再開イベントの処理、ウィンドウのフォーカス、スナップなどの Windows ランタイム プロパティが含まれます。  |
| [ゲームのフロー管理](tutorial-game-flow-management.md) | プレイヤーとシステムとの対話を有効にする高度なステート マシンを定義します。 UI で全体的なゲームのステート マシンを操作する方法および UWP ゲーム用のイベント ハンドラーを作成する方法について説明します。 |
| [メイン ゲーム オブジェクトの定義](tutorial--defining-the-main-game-loop.md) | ルールを作成することでゲームをプレイする方法を定義します。 |
| [レンダリング フレームワーク I: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md) | グラフィックスを表示するレンダリング フレームワークを作成します。 このトピックは 2 部構成となっています。 レンダリングの概要では、画面に表示するシーンのオブジェクトを表示する方法について説明します。 |
| [レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md) | レンダリング トピックの第 2 部では、レンダリングが発生する前に必要なデータを準備する方法について説明します。 |
| [ユーザー インターフェイスの追加](tutorial--adding-a-user-interface.md) | 単純なメニュー オプションとヘッドアップ ディスプレイ コンポーネントを追加し、プレイヤーにフィードバックを提供します。 |
| [コントロールの追加](tutorial--adding-controls.md) | ゲームにムーブ/ルック コントロール (基本的なタッチ、マウス、およびゲーム コントローラーのコントロール) を追加します。 |
| [サウンドの追加](tutorial--adding-sound.md) | [XAudio2](https://msdn.microsoft.com/library/windows/desktop/ee415813) API を使用して、ゲームのサウンドを作成する方法について説明します。 |
| [ゲーム サンプルの紹介](tutorial-resources.md) | XAML を使用したオーバーレイの作成など、DirectX ゲーム開発の知識をさらに深めるためのリソースです。 |