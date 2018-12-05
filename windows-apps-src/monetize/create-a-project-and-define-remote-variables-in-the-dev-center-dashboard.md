---
Description: Before you can run an experiment in your Universal Windows Platform (UWP) app with A/B testing, you must create a project and define your remote variables in Partner Center.
title: パートナー センターで実験プロジェクトを作成する
ms.assetid: C3809FF1-0A6A-4715-B989-BE9D0E8C9013
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、Microsoft Store Services SDK、A/B テスト、実験
ms.localizationpriority: medium
ms.openlocfilehash: acfd654f02cb7fb727d35271175e59966e2abdc4
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8693625"
---
# <a name="create-an-experiment-project-in-partner-center"></a>パートナー センターで実験プロジェクトを作成する

実験を最初に、パートナー センターで、アプリの実験[プロジェクト](run-app-experiments-with-a-b-testing.md#terms)を作成し、アプリがアクセスできるリモート変数を定義します。

次の手順では、プロジェクトを作成するための主な手順について説明します。 プロジェクトの作成と実験の実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

## <a name="instructions"></a>手順

1. [パートナー センター](https://partner.microsoft.com/dashboard)にサインインします。
2. **[アプリ]** で、実験を作成するアプリを選択します。
3. ナビゲーション ウィンドウで、**[Services]** を選択し、**[Experimentation]** を選択します。
4. **[Experimentation]** ページで、**[プロジェクト]** セクション **[新しいプロジェクト]** ボタンをクリックします。 1 つ以上のプロジェクトを既に作成している場合、それらのプロジェクトが **[プロジェクト]** セクションに表示されます。
5. **[新しいプロジェクト]** ページで、新しいプロジェクトの名前を入力します。
6. **[リモート変数]** セクションで、このプロジェクトのすべての実験で利用できるようにする[変数](run-app-experiments-with-a-b-testing.md#terms)を追加し、各変数の既定値を定義します。 ここで指定した既定値は、実験のコントロール グループと、実験に参加していないすべてのユーザーに使われます。
  1. **[リモート変数]** セクションが折りたたまれている場合、セクション見出しの **[表示]** をクリックします。
  2. **[変数の追加]** をクリックして、このプロジェクトのあらゆる実験で利用できるようにする新しい変数をそれぞれ作成し、変数の変数名と既定値を入力します。
  3. 追加の変数が終わったら、**[保存]** をクリックします。
3. **[SDK 統合]** セクションで、[プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms) 値を書き留めます。 [実験用のアプリのコード](code-your-experiment-in-your-app.md)をする必要がありますで参照するときこのプロジェクト ID コード バリエーション データを受信し、パートナー センターにビュー イベントとコンバージョン イベントを報告できます。

> [!NOTE]
> プロジェクトの実験がアクティブなときに、リモート変数を編集、追加、削除することはできません。 この制限により、アクティブな実験のコントロール グループのデータの整合性を保護できます。


## <a name="next-steps"></a>次の手順

プロジェクトを作成すると、[アプリの実験用のコードを記述](code-your-experiment-in-your-app.md)して、アプリでリモートの変数値を取得し始めることができ、[プロジェクトで実験を作成](define-your-experiment-in-the-dev-center-dashboard.md)することができます。

## <a name="related-topics"></a>関連トピック

* [アプリの実験用のコードを記述する](code-your-experiment-in-your-app.md)
* [パートナー センターで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [パートナー センターで実験を管理する](manage-your-experiment.md)
* [A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)
