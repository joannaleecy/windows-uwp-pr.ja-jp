---
ms.assetid: beac6333-655a-4bcf-9caf-bba15f715ea5
title: スレッド化と非同期プログラミング
description: スレッド化と非同期プログラミングによって、アプリは並列スレッドで作業を非同期的に実行できます。
ms.date: 05/14/2018
ms.topic: article
keywords: windows 10, uwp, 非同期, スレッド, スレッド化
ms.localizationpriority: medium
ms.openlocfilehash: 22c151b90be30b39da7decd9a0ce3109e29b7fb7
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7707010"
---
# <a name="threading-and-async-programming"></a>スレッド化と非同期プログラミング
スレッド化と非同期プログラミングによって、アプリは並列スレッドで作業を非同期的に実行できます。

アプリでは、スレッド プールを使って、並列スレッドで作業を非同期的に実行できます。 スレッド プールでは、一連のスレッドを管理し、スレッドが使用可能になるとキューを使って作業項目をそのスレッドに割り当てます。 スレッド プールを使うと UI をブロックすることなく広範な作業を実行できるため、スレッド プールは Windows ランタイムで利用できる非同期プログラミング パターンと似ています。ただし、スレッド プールは非同期プログラミング パターンよりも細かく制御でき、これを使って複数の作業項目を並列的に実行できます。 スレッド プールを使うと、次のことが可能になります。

-   作業項目の送信、作業項目の優先度の管理、作業項目の取り消し。

-   タイマーおよび定期タイマーを使った作業項目のスケジュール設定。

-   重要な作業項目のためのリソースの確保。

-   指定されたイベントとセマフォに応答した作業項目の実行。

スレッド プールにより、スレッドの作成と破棄のオーバーヘッドが少なくなるため、効率的にスレッドを管理できます。 つまり、複数の CPU コアを使ってスレッドを最適化でき、バックグラウンド タスクが実行されているときにアプリ間でスレッド リソースを分配することができます。 スレッド管理のしくみよりも、タスクを実行するコードを作成することが主な目的であるので、組み込みスレッド プールを使うと便利です。

| トピック                                                                                                          | 説明                         |
|----------------------------------------------------------------------------------------------------------------|-------------------------------------|
| [非同期プログラミング (UWP アプリ)](asynchronous-programming-universal-windows-platform-apps.md)              | このトピックでは、ユニバーサル Windows プラットフォーム (UWP) での非同期プログラミングとは、c#、Microsoft Visual Basic.NET、VisualC ではコンポーネント拡張機能では、その表現について説明します (、C++/cli CX)、および JavaScript します。 |
| [C++/CX での非同期プログラミング (UWP アプリ)](asynchronous-programming-in-cpp-universal-windows-platform-apps.md)| ここでは、ppltasks.h の <code>task</code> 名前空間で定義された <code>concurrency</code> クラスを使って C++/CX の非同期メソッドを実装する際に推奨される方法について説明します。 |
| [スレッド プールを使うためのベスト プラクティス](best-practices-for-using-the-thread-pool.md)                         | このトピックでは、スレッド プールを使った操作のベスト プラクティスについて説明します。 |
| [C# または Visual Basic での非同期 API の呼び出し](call-asynchronous-apis-in-csharp-or-visual-basic.md)             | ユニバーサル Windows プラットフォーム (UWP) には、時間がかかる可能性がある操作を実行しているときでも、アプリの応答性を保つために、さまざまな非同期 API が用意されています。 このトピックでは、C# または Microsoft Visual Basic で UWP の非同期メソッドを使う方法について説明します。 |
| [定期的な作業項目の作成](create-a-periodic-work-item.md)                                                   | 定期的に実行される作業項目の作成方法を説明します。 |
| [スレッド プールへの作業項目の送信](submit-a-work-item-to-the-thread-pool.md)                               | スレッド プールに作業項目を送信することで独立したスレッドで作業を実行する方法について説明します。 |
| [タイマーを使った作業項目の送信](use-a-timer-to-submit-a-work-item.md)                                       | タイマーが終了した後に実行される作業項目の作成方法を説明します。 |
