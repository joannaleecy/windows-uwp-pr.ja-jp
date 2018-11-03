---
author: eliotcowley
title: Marble Maze、C++ と DirectX での UWP ゲームの開発
description: ドキュメントのこのセクションでは、DirectX と Visual C++ を使って 3D のユニバーサル Windows プラットフォーム (UWP) ゲームを作成する方法について説明します。
ms.assetid: 43f1977a-7e1d-614c-696e-7669dd8a9cc7
ms.author: elcowle
ms.date: 08/10/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, サンプル, DirectX, 3D
ms.localizationpriority: medium
ms.openlocfilehash: 7a808c36ab319d76f16c653c5812ebe4b269ec59
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5981904"
---
# <a name="developing-marble-maze-a-uwp-game-in-c-and-directx"></a>Marble Maze、C++ と DirectX での UWP ゲームの開発




このトピックでは、DirectX と Visual C++ を使って 3D のユニバーサル Windows プラットフォーム (UWP) ゲームを作成する方法について説明します。 Marble Maze と呼ばれるこのゲームでは、タブレット、従来のデスクトップ、ノート PC などの、複数のフォーム ファクターを活用しています。

> [!NOTE]
> Marble Maze のソース コードをダウンロードするには、[GitHub のサンプル](http://go.microsoft.com/fwlink/?LinkId=624011)をご覧ください。

> [!IMPORTANT]
> Marble Maze は、UWP ゲームを作成するためのベスト プラクティスと考えられる設計パターンを示しています。 各自のプラクティスと開発するゲームの固有の要件に適合するように、このゲームの実装の詳細を利用できます。 各自のニーズに適合する別のテクニックやライブラリがある場合はそれを自由にお使いください  (ただし、コードが [Windows アプリ認定キット](https://docs.microsoft.com/windows/uwp/debug-test-perf/windows-app-certification-kit)によるテストに合格することを常に確かめてください。) ゲームの開発を成功させるために Marble Maze の実装が不可欠であると見なされる場合は、このドキュメントでその点を強調しています。

 

## <a name="introducing-marble-maze"></a>Marble Maze について


Marble Maze を選んだのは、それが比較的基本的なゲームであるにもかかわらず、大半のゲームで使われる多様な機能を備えているためです。 Marble Maze は、グラフィックス、入力処理、オーディオの使用方法を示しています。 さらに、規則やゴールなどのゲームのメカニズムも示します。

Marble Maze は、通常は穴がある箱と金属またはガラス製の大理石で構成される卓上版の迷路ゲームに似ています。 Marble Maze のゴールは、卓上版と同じです。迷路を傾けて、大理石を迷路の入り口から出口まで、穴に落とさずにできるだけ短い時間で誘導することです。 Marble Maze には、チェックポイントという概念が追加されています。 大理石が穴に落ちた場合、ゲームは、大理石が通過した最後のチェックポイントの場所から再開されます。

Marble Maze では、ユーザーは複数の方法でゲーム ボードを操作できます。 タッチ対応または加速度計対応デバイスの場合は、これらのデバイスを使ってゲーム ボードを動かすことができます。 Xbox One コントローラーまたはマウスを使って、ゲームのプレイを制御することもできます。

![Marble Maze ゲームのスクリーン ショット。](images/marblemaze-2.png)

## <a name="prerequisites"></a>前提条件


-   Windows 10 Creators Update
-   [Microsoft Visual Studio2017](https://www.visualstudio.com/downloads/)
-   C++ プログラミングの知識
-   DirectX と DirectX の用語に関する知識
-   COM に関する基本的な知識

## <a name="who-should-read-this"></a>このドキュメントの対象読者


3D ゲームやその他のグラフィックス重視のアプリケーションを windows 10 の作成に関心がある場合はこのします。 このドキュメントで説明する基本原則とプラクティスを活用して、各自の UWP ゲームを作成してください。 C++ と DirectX のプログラミングの知識または強い興味があれば、このドキュメントを活用するのに役に立ちます。 DirectX の経験がない場合でも、類似の 3D グラフィックスのプログラミング環境の経験があれば役に立ちます。

ドキュメント「[チュートリアル: DirectX によるシンプルな UWP ゲームの作成](tutorial--create-your-first-uwp-directx-game.md)」に、DirectX と C++ を使った基本的な 3D シューティング ゲームを実装するサンプルの説明があります。

## <a name="what-this-documentation-covers"></a>このドキュメントの内容


このドキュメントでは、以下の方法について説明します。

-   Windows ランタイム API と DirectX を使って UWP ゲームを作成する。
-   [Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff476080) と [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990) を使って、モデル、テクスチャ、頂点シェーダー、ピクセル シェーダー、2D オーバーレイ等の視覚的なコンテンツを操作する。
-   タッチ、加速度計、Xbox One コントローラーなどの入力メカニズムを統合する。
-   [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) を使って、音楽とサウンド エフェクトを組み込む。

## <a name="what-this-documentation-does-not-cover"></a>このドキュメントで扱われていない内容


このドキュメントでは、ゲーム開発の次の側面は扱いません。 これらの側面は、追加リソースで扱われます。

-   3D ゲームの設計原則。
-   C++ または DirectX プログラミングの基本。
-   テクスチャ、モデル、オーディオなどのリソースを設計する方法。
-   ゲームの動作またはパフォーマンスに関する問題をトラブルシューティングする方法。
-   海外で使用できるようにゲームを準備する方法。
-   ゲームを検証して Microsoft Store に公開する方法。

Marble Maze では、[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) ライブラリを使って、3D ジオメトリの操作と衝突などの物理計算を実行します。 DirectXMath については、このセクションでは詳しく説明しません。 Marble Maze での DirectXMath の使用方法については、ソース コードをご覧ください。

Marble Maze には再利用可能なコンポーネントがたくさん用意されていますが、それは完全なゲーム開発フレームワークではありません。 Marble Maze のコンポーネントをゲームで再利用できると見なされる場合は、このドキュメントでその点を強調しています。

## <a name="next-steps"></a>次の手順


「[Marble Maze サンプルの基礎](marble-maze-sample-fundamentals.md)」で、Marble Maze の構造と、Marble Maze のソース コードが従っているコーディング ガイドラインとスタイル ガイドラインを確認することから始めることをお勧めします。 次の表に、簡単に参照できるように、このセクションに含まれるドキュメントの概要を示します。

## <a name="in-this-section"></a>このセクションの内容


| タイトル                                                                                                                    | 説明                                                                                                                                                                                                                                        |
|--------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Marble Maze サンプルの基礎](marble-maze-sample-fundamentals.md)                                                   | ゲームの構造の概要と、ソース コードが従っているコーディング ガイドラインとスタイル ガイドラインの一部を示します。                                                                                                                                 |
| [Marble Maze のアプリケーション構造](marble-maze-application-structure.md)                                               | Marble Maze アプリケーション コードの構造と、DirectX UWP アプリの構造と従来のデスクトップ アプリケーションの構造の違いについて説明します。                                                                                    |
| [Marble Maze サンプルへの視覚的なコンテンツの追加](adding-visual-content-to-the-marble-maze-sample.md)                   | Direct3D と Direct2D を使うときに留意する主なプラクティスについて説明します。 これらのプラクティスが Marble Maze の視覚的なコンテンツにどのように適用されるかについても説明します。                                                                           |
| [Marble Maze サンプルへの入力と対話機能の追加](adding-input-and-interactivity-to-the-marble-maze-sample.md) | ユーザーがメニュー間を移動し、ゲーム ボードを操作できるように、Marble Maze が加速度計入力、タッチ入力、Xbox One コントローラー入力を処理する方法について説明します。 入力を操作するときに留意するベスト プラクティスについても説明します。 |
| [Marble Maze のサンプルへのオーディオの追加](adding-audio-to-the-marble-maze-sample.md)                                     | Marble Maze でオーディオを操作して音楽とサウンド エフェクトをゲームのエクスペリエンスに追加する方法について説明します。                                                                                                                                                  |

 

 

 




