---
author: mcleblanc
ms.assetid: 83b4be37-6613-4d00-a48a-0451a24a30fb
title: データ バインディング
description: データ バインディングは、アプリの UI でデータを表示し、必要に応じてそのデータとの同期を保つ方法です。
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: edc3dc53a7cf536bbabce108647cf54693c3ab05
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4312594"
---
# <a name="data-binding"></a>データ バインディング

データ バインディングは、アプリの UI でデータを表示し、必要に応じてそのデータとの同期を保つ方法です。 データ バインディングによって、UI の問題からデータの問題を切り離すことができるため、概念的なモデルが簡素化されると共に、アプリの読みやすさ、テストの容易性、保守容易性が向上します。 マークアップでは、 [{X:bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)または[{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)の使用を選択できます。 また、同じアプリや同じ UI 要素で、この 2 つを組み合わせて使うこともできます。 {x:Bind} は Windows 10 の新機能で、パフォーマンスが向上しています。

| トピック | 説明 |
|-------|-------------|
| [データ バインディングの概要](data-binding-quickstart.md) | このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリで、コントロール (または他の UI 要素) を単一の項目にバインドする方法や、項目コントロールを項目のコレクションにバインドする方法を説明します。 また、項目のレンダリングを制御する方法、選択内容に基づいて詳細ビューを実装する方法、表示するデータを変換する方法も紹介します。 詳しくは、「[データ バインディングの詳細](data-binding-in-depth.md)」をご覧ください。 | 
| [データ バインディングの詳細](data-binding-in-depth.md) | このトピックでは、データ バインディングの機能について詳しく説明します。 |
| [デザイン サーフェイス上のサンプル データとプロトタイプを作るためのサンプル データ](displaying-data-in-the-designer.md) | コントロールが (アプリのレイアウト、テンプレート、およびその他のビジュアルのプロパティで使用できます) するために Visual Studio デザイナーでデータを格納するために、さまざまな方法で設計時のサンプル データを使用することができます。 サンプル データは、スケッチ (プロトタイプ) アプリを開発する場合にも便利で、時間の節約になります。 スケッチやプロトタイプで実行時にサンプル データを使うと、実際のライブ データに接続しなくてもアイデアを実証できます。 |
| [階層データをバインドしてマスター/詳細ビューを作る方法](how-to-bind-to-hierarchical-data-and-create-a-master-details-view.md) | チェーン内でバインドされた [<strong>CollectionViewSource</strong>](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスに項目コントロールをバインドすることによって、階層データの複数レベルのマスター/詳細 (リスト/詳細とも呼ばれる) ビューを作成することができます。 |
| [データ バインディングと MVVM](data-binding-and-mvvm.md) | このトピックでは、モデル-ビュー-ビューモデル (MVVM) UI のアーキテクチャの設計パターンについて説明します。 データ バインディング、MVVM の中心では、でき、UI と UI 以外のコード間で疎結合します。 |
