---
author: mtoepke
title: "ゲームと DirectX"
description: "ユニバーサル Windows プラットフォーム (UWP) は、ゲームを作り、配布し、収益を得るための新たな機会を提供します。 新しいゲームの開始または既存のゲームの移植について説明します。"
ms.assetid: 4073b835-c900-4ff2-9fc5-da52f9432a1f
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: b690fa9a97898da49646e39c982465a4a41adb7a

---

# ゲームと DirectX


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

ユニバーサル Windows プラットフォーム (UWP) は、ゲームを作り、配布し、収益を得るための新たな機会を提供します。 新しいゲームの開始または既存のゲームの移植について説明します。

| トピック | 説明 |
|---------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Windows 10 ゲーム開発ガイド](e2e.md) | UWP ゲーム開発のためのリソースや情報を網羅したガイドです。 |
| [ユニバーサル Windows プラットフォーム アプリのゲーム テクノロジ](game-development-platform-guide.md) | このガイドでは、UWP ゲームの開発に利用できるテクノロジについて説明します。 |
| [ゲームのプロジェクト テンプレートとツール](prepare-your-dev-environment-for-windows-store-directx-game-development.md) | UWP 用の DirectX ゲームのプログラミングを開始するために必要なものについて説明します。 |
| [アプリ オブジェクトと DirectX](about-the-metro-style-user-interface-and-directx.md) | DirectX を使った UWP ゲームでは、Windows UI ユーザー インターフェイスの要素とオブジェクトの多くが使われません。 逆に、それらのアプリは Windows ランタイム スタックの下位レベルで実行されることから、アプリ オブジェクトに直接アクセスして相互運用するという基本的な方法でユーザー インターフェイス フレームワークと相互運用する必要があります。 ここでは、この相互運用をいつどのように行うかと、DirectX 開発者が UWP アプリの開発でこのモデルを効果的に使う方法を説明します。 |
| [アプリの起動と再開](launching-and-resuming-apps-directx-and-cpp.md) | UWP DirectX アプリを起動、一時停止、再開する方法について説明します。 |
| [DirectX ゲームの 2D グラフィックス](working-with-2d-graphics-in-your-directx-game.md) | ここでは 2D ビットマップ グラフィックスおよび効果の用途と、これらを実際のゲームで使用する方法について説明します。 |
| [DirectX ゲームの基本的な 3D グラフィックス](an-introduction-to-3d-graphics-with-directx.md) | DirectX プログラミングを使って、3D グラフィックスの基本的な概念を実装する方法について説明します。 |
| [DirectX ゲームでのリソースの読み込み](load-a-game-asset.md) | ほとんどのゲームは、ある時点で、ローカル ストレージまたは他のデータ ストリームからリソースとアセット (シェーダー、テクスチャ、定義済みメッシュ、その他のグラフィックス データなど) を読み込みます。 ここでは、このようなファイルを読み込んで UWP ゲームで使う際に考慮すべきことについて、その概要を説明します。 |
| [DirectX によるシンプルな UWP ゲームの作成](tutorial--create-your-first-metro-style-directx-game.md) | この一連のチュートリアルでは、DirectX と C++ を使って基本的な UWP ゲームを作成する方法を説明します。 アートやメッシュなどのアセットの読み込み、主要なゲーム ループの作成、簡易なレンダリング パイプラインの実装、サウンドやコントロールの追加を行うプロセスなど、ゲームの主要な要素すべてについて説明します。 |
| [Marble Maze、C++ と DirectX でのユニバーサル Windows プラットフォーム ゲームの開発](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md) | ドキュメントのこのセクションでは、DirectX と Visual C++ を使って 3-D の UWP ゲームを作成する方法について説明します。 このドキュメントでは、タブレットなどの新しいフォーム ファクターに対応し、従来のデスクトップやノート PC でも動作する、Marble Maze という名前の 3-D ゲームを作成する方法を示します。 |
| [画面の向きのサポート](supporting-screen-rotation-directx-and-cpp.md) | ここでは、UWP DirectX アプリで、Windows 10 デバイスのグラフィックス ハードウェアを効率的、効果的に使って画面の回転を処理するためのベスト プラクティスについて説明します。 |
| [ゲームのオーディオ](working-with-audio-in-your-directx-game.md) | ミュージックやサウンドを開発し、DirectX ゲームに統合する方法、およびオーディオ信号を処理して、ダイナミック サウンドやポジショナル サウンドを作成する方法について説明します。 |
| [ゲームのタッチ コントロール](tutorial--adding-touch-controls-to-your-directx-game.md) | ここでは、DirectX を使って基本的なタッチ コントロールを UWP C++ ゲームに追加する方法について説明します。 具体的には、平面に固定されたカメラを動かすタッチ ベースのコントロールを Direct3D 環境に追加し、指またはスタイラスでドラッグするとカメラの視点がシフトするようにする方法を紹介します。 |
| [ゲームのムーブ/ルック コントロール](tutorial--adding-move-look-controls-to-your-directx-game.md) | ここでは、マウスとキーボードの従来のムーブ/ルック コントロール (マウスルック コントロールとも呼ばれます) を DirectX ゲームに追加する方法について説明します。 |
| [入力とレンダリング ループの最適化](optimize-performance-for-windows-store-direct3d-11-apps-with-coredispatcher.md) | 入力待ち時間は、ゲーム エクスペリエンスに大きな影響を与えるため、最適化するとゲームがより洗練されたものに感じられます。 また、適切な入力イベントの最適化によってバッテリー残量を節約できます。 適切な [CoreDispatcher](optimize-performance-for-windows-store-direct3d-11-apps-with-coredispatcher.md) 入力イベント処理オプションを選択して、ゲームで入力ができる限り滑らかに処理されるようにする方法を説明します。 |
| [スワップ チェーンのスケーリングとオーバーレイ](multisampling--scaling--and-overlay-swap-chains.md) | モバイル デバイスでのレンダリングを高速化するためにスケーリングされたスワップ チェーンを作成し、オーバーレイ スワップ チェーン (使用できる場合) を使って画質を高める方法について説明します。 |
| [DXGI 1.3 スワップ チェーンによる遅延の減少](reduce-latency-with-dxgi-1-3-swap-chains.md) | DXGI 1.3 を使って、スワップ チェーンが新しいフレームのレンダリング開始の適切な時間を通知するまで待機することで、実質的なフレーム待機時間を削減します。 |
| [UWP アプリでのマルチサンプリング](multisampling--multi-sample-anti-aliasing--in-windows-store-apps.md) | Direct3D を使って構築された UWP アプリでマルチサンプリングを使う方法について説明します。 |
| [Direct3D 11 でのデバイス削除シナリオの処理](handling-device-lost-scenarios.md) | このトピックでは、グラフィックス アダプターが削除または再初期化されたときに Direct3D と DXGI デバイス インターフェイス チェーンを再作成する方法について説明します。 |
| [ゲームの非同期プログラミング](asynchronous-programming-directx-and-cpp.md) | このトピックでは、DirectX で非同期プログラミングやスレッディングを使う際のさまざまな考慮事項について取り上げます。 |
| [ゲームのネットワーク](work-with-networking-in-your-directx-game.md) | ネットワーク機能を開発し、DirectX ゲームに組み込む方法について説明します。 |
| [DirectX と XAML の相互運用機能](directx-and-xaml-interop.md) | UWP ゲームで Extensible Application Markup Language (XAML) と Microsoft DirectX を組み合わせて使うことができます。 |
| [ゲームのパッケージ化](package-your-windows-store-directx-game.md) | 規模の大きい UWP ゲーム (特に、地域固有のアセットや機能オプションによる高解像度アセットを伴って複数言語をサポートするゲーム) は、サイズが容易に膨張する可能性があります。 このトピックでは、ユーザーが実際に必要なリソースのみを受け取ることができるように、アプリ パッケージとアプリ バンドルを使ってアプリをカスタマイズする方法について説明します。 |
| [ゲーム移植ガイド](porting-guides.md) | 既存のゲームを Direct3D 11、UWP、および Windows 10 に移植するためのガイドを示します。 |
| [ゲーム プログラミング リソース](additional-directx-game-programming-resources.md) | Windows でのゲーム プログラミングについて詳しくは、次のリソースをご覧ください。 |

 

> **注**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

ゲーム開発の概要とチュートリアルを最大限に活用するには、次のテーマについて理解している必要があります。

-   Microsoft C++ コンポーネント拡張 (C++/CX) これは自動参照カウントが組み込まれた Microsoft C++ の更新であり、DirectX 11.1 以降のバージョンを使って UWP ゲームを開発するための言語です。
-   基本的なグラフィックス プログラミング用語。
-   Windows プログラミングの基本的な概念。
-   Direct3D 9 または 11 API に関する基本的な知識。

 

 







<!--HONumber=Jun16_HO3-->


