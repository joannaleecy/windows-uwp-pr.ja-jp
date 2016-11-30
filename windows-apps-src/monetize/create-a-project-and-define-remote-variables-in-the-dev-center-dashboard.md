---
author: mcleanbyron
Description: "ユニバーサル Windows プラットフォーム (UWP) アプリで A/B テストを実施する前に、デベロッパー センター ダッシュボードでプロジェクトを作成し、リモート変数を定義する必要があります。"
title: "プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する"
ms.assetid: C3809FF1-0A6A-4715-B989-BE9D0E8C9013
translationtype: Human Translation
ms.sourcegitcommit: 32c1b379ee3913e267664e6d125fbc3daf480bb3
ms.openlocfilehash: 88a55c9ed64d5f52f959a1c68618dc5296dc24d6

---

# プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する

実験を始めるには、デベロッパー センター ダッシュボードでアプリの実験[プロジェクト](run-app-experiments-with-a-b-testing.md#terms)を作成し、アプリがアクセスできるリモート変数を定義します。

次の手順では、プロジェクトを作成するための主な手順について説明します。 プロジェクトの作成と実験の実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

## 手順

1. [デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインします。
2. **[アプリ]** で、実験を作成するアプリを選択します。
3. ナビゲーション ウィンドウで、**[Services]** を選択し、**[Experimentation]** を選択します。
4. **[Experimentation]** ページで、**[プロジェクト]** セクション **[新しいプロジェクト]** ボタンをクリックします。 1 つ以上のプロジェクトを既に作成している場合、それらのプロジェクトが **[プロジェクト]** セクションに表示されます。
5. **[新しいプロジェクト]** ページで、新しいプロジェクトの名前を入力します。
6. **[リモート変数]** セクションで、このプロジェクトのすべての実験で利用できるようにする[変数](run-app-experiments-with-a-b-testing.md#terms)を追加し、各変数の既定値を定義します。 ここで指定した既定値は、実験のコントロール グループと、実験に参加していないすべてのユーザーに使われます。
  1. **[リモート変数]** セクションが折りたたまれている場合、セクション見出しの **[表示]** をクリックします。
  2. **[変数の追加]** をクリックして、このプロジェクトのあらゆる実験で利用できるようにする新しい変数をそれぞれ作成し、変数の変数名と既定値を入力します。
  3. 追加の変数が終わったら、**[保存]** をクリックします。
3. **[SDK 統合]** セクションで、[プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms) 値を書き留めます。 [アプリの実験用のコードを記述](code-your-experiment-in-your-app.md)する場合、バリエーション データを受け取り、ビュー イベントとコンバージョン イベントをデベロッパー センターにレポートできるように、コードでこのプロジェクト ID を参照する必要があります。

>**注**&nbsp;&nbsp;プロジェクトの実験がアクティブなときに、リモート変数を編集、追加、削除することはできません。 この制限により、アクティブな実験のコントロール グループのデータの整合性を保護できます。


## 次の手順

プロジェクトを作成すると、[アプリの実験用のコードを記述](code-your-experiment-in-your-app.md)して、アプリでリモートの変数値を取得し始めることができ、[プロジェクトで実験を作成](define-your-experiment-in-the-dev-center-dashboard.md)することができます。

## 関連トピック

* [アプリの実験用のコードを記述する](code-your-experiment-in-your-app.md)
* [デベロッパー センター ダッシュボードで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで試験的機能を管理する](manage-your-experiment.md)
* [A/B テストを使用して最初の試験的機能を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)



<!--HONumber=Nov16_HO1-->


