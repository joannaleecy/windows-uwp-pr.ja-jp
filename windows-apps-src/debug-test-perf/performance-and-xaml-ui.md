---
author: jwmsft
ms.assetid: 64F7FC51-E8AC-4098-9C5F-0172E4724B5C
title: パフォーマンス
description: ユーザーは、高い応答性と自然な使用感、そしてバッテリーが消耗しないことをアプリに期待しています。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3dfc4e5d3d2741cf36a1a9aae8c0c22feed5305e
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7290721"
---
# <a name="performance"></a>パフォーマンス


ユーザーは、高い応答性と自然な使用感、そしてバッテリーが消耗しないことをアプリに期待しています。 技術的には、パフォーマンスは機能要件ではありませんが、パフォーマンスを機能として扱うことで、ユーザーの期待に沿うことができます。 鍵となる要因は、目標の明確化と測定の実施です。 パフォーマンスが重要なシナリオを決定し、優れたパフォーマンスとは何を意味するかを定義します。 次に、プロジェクトの初期とライフサイクル全体で十分な回数の測定を行って、目標を達成できることを確認します。 このセクションでは、パフォーマンスのワークフローの整理、アニメーション エラーやフレーム レートの問題の解決、および起動時間、ページ ナビゲーションの時間、メモリ使用量の調整を行う方法を示します。

いない場合、されている手順をパフォーマンスに大幅な改善が windows 10 をターゲットにアプリを移植するだけきました。 いくつかの XAML の最適化 (たとえば、 [{X:bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783)) では、windows 10 アプリで利用可能なのみです。 [Windows 10 に移植アプリ](https://msdn.microsoft.com/library/windows/apps/Mt238321)と[ユニバーサル Windows プラットフォームに移行する](http://channel9.msdn.com/Events/Build/2015/3-741)//build/ セッションを参照してください。

| トピック | 説明 |
|-------|-------------|
| [パフォーマンスの計画](planning-and-measuring-performance.md) | ユーザーは、高い応答性と自然な使用感、そしてバッテリーが消耗しないことをアプリに期待しています。 技術的には、パフォーマンスは機能要件ではありませんが、パフォーマンスを機能として扱うことで、ユーザーの期待に沿うことができます。 鍵となる要因は、目標の明確化と測定の実施です。 パフォーマンスが重要なシナリオを決定し、優れたパフォーマンスとは何を意味するかを定義します。 次に、プロジェクトの初期とライフサイクル全体で十分な回数の測定を行って、目標を達成できることを確認します。 |
| [バックグラウンド アクティビティの最適化](optimize-background-activity.md) | システムと連携して、バッテリー効率の高い方法でバックグラウンド タスクを使用する UWP アプリを作成します。 |
| [ListView と GridView の UI の最適化](optimize-gridview-and-listview.md) | [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/BR242705) のパフォーマンスと起動時間を、UI の仮想化や要素の削減、項目の段階的な更新を通して向上させます。 |
| [ListView と GridView のデータ仮想化](listview-and-gridview-data-optimization.md) | データ仮想化によって [<strong>GridView</strong>](https://msdn.microsoft.com/library/windows/apps/BR242705) のパフォーマンスと起動時間を向上させます。 |
| [ガベージ コレクションのパフォーマンスの向上](improve-garbage-collection-performance.md) | C# と Visual Basic で記述されたユニバーサル Windows プラットフォーム (UWP) アプリは、.NET ガベージ コレクターによって、自動的にメモリ管理が行われます。 このセクションでは、UWP アプリでの .NET ガーベジ コレクターの動作とパフォーマンスに関するベスト プラクティスについて説明します。 |
| [UI スレッドの応答性の確保](keep-the-ui-thread-responsive.md) | ユーザーは、コンピューターの種類に関係なく、アプリが計算を実行しているときも引き続き応答性を保つことを期待します。 これは、アプリケーションの種類によって異なる意味を持ちます。 一部のアプリケーションにとっては、これは、よりリアルな物理的効果の再現、ディスクや Web からのデータの読み込み速度の向上、複雑なシーンのすばやい表示とページ間の移動、スナップでの方向検出、高速のデータ処理などを意味します。 計算の種類に関係なく、ユーザーはアプリが入力に対して反応することを求め、計算中にアプリが応答停止しているように見える状況は望ましくありません。 |
| [XAML マークアップの最適化](optimize-xaml-loading.md) | UI が複雑な場合は、XAML マークアップを解析し、メモリ内にオブジェクトを構築するのに時間がかかります。 以下に、アプリでの XAML マークアップの解析および読み込み時間や、メモリ効率の向上に役立つヒントを紹介します。 | 
| [XAML レイアウトの最適化](optimize-your-xaml-layout.md) | レイアウトは、CPU 使用率とメモリ オーバーヘッドの両方で、XAML アプリの負荷の高い部分です。 ここでは、XAML アプリのレイアウトのパフォーマンスを向上させるための簡単な手順を示します。 | 
| [MVVM と言語のパフォーマンスに関するヒント](mvvm-performance-tips.md) | このトピックでは、ソフトウェアの設計パターンとプログラミング言語の選択に関連するいくつかのパフォーマンスの考慮事項について説明します。 |
| [アプリ起動時のパフォーマンスのベスト プラクティス](best-practices-for-your-app-s-startup-performance.md) | 起動とアクティブ化を処理する方法を向上させることによって、最適な起動時間の UWP アプリを作成します。 |
| [アニメーション、メディア、画像の最適化](optimize-animations-and-media.md) | スムーズなアニメーション、高いフレーム レート、およびパフォーマンスの高いメディア キャプチャと再生を備えたユニバーサル Windows プラットフォーム (UWP) アプリを作成します。 |
| [中断/再開の最適化](optimize-suspend-resume.md) | プロセス継続時間システムの使用を合理化することで、中断または終了の後効率的に再開される UWP アプリを作成します。 |
| [ファイル アクセスの最適化](optimize-file-access.md) | ファイル システムに効率的にアクセスすることで、ディスクの待ち時間とメモリ/CPU サイクルによるパフォーマンスの問題を回避する UWP アプリを作成します。 |
| [Windows ランタイム コンポーネントと相互運用性の最適化](windows-runtime-components-and-optimizing-interop.md) | 相互運用性のパフォーマンスの問題を回避しながら、ネイティブ型とマネージ型の間で UWP コンポーネントと相互運用機能を使う UWP アプリを作成します。 |
| [プロファイリングとパフォーマンスに関するツール](tools-for-profiling-and-performance.md) | Microsoft には、UWP アプリのパフォーマンスを改善する際に役立つツールがいくつか用意されています。|

