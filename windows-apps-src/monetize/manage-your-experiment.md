---
author: Xansky
Description: After you define your experiment in the Dev Center dashboard and code your experiment in your app, you are ready to active your experiment and use the Dev Center dashboard to review the results of your experiment.
title: ダッシュボードで実験を管理する
ms.assetid: D48EE0B4-47F2-455C-8FB9-630769AC5ACE
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP、Microsoft Store Services SDK、A/B テスト、実験
ms.localizationpriority: medium
ms.openlocfilehash: 0a5f48c1b5aeed1cd5e02a60c6ed1b55c4b02a92
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4740896"
---
# <a name="manage-your-experiment-in-the-dashboard"></a>ダッシュボードで実験を管理する

[デベロッパー センター ダッシュ ボードで実験を定義](define-your-experiment-in-the-dev-center-dashboard.md)し、[アプリでその実験のコードを記述](code-your-experiment-in-your-app.md)したら、実験をアクティブ化し、デベロッパー センター ダッシュ ボードを使用して、実験の結果を確認できます。 必要なすべてのデータを取得したら、実験を終了し、すべてのアプリでコントロールのバリエーションの変数値を使用し続けるか、他のバリエーションの変数値を使用することに切り替えるかを選択できます。

> [!NOTE]
> 実験をアクティブ化すると、デベロッパー センターでは、実験のデータをログに記録するようにインストルメント化されたアプリからのデータ収集が直ちに開始されます。 ただし、実験のデータがダッシュボードに表示されるまでに数時間かかることがあります。

実験の作成および実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

## <a name="activate-your-experiment"></a>実験をアクティブ化する

ダッシュボードの実験のパラメーターに問題がなく、アプリのコードを更新したら、実験をアクティブ化し、アプリから実験のデータを収集できるようになります。 実験がアクティブになっていると、アプリはバリエーション値を取得し、デベロッパー センターにビュー イベントとコンバージョン イベントをレポートできます。

1. [デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインします。
2. **[アプリ]** の下で、アクティブ化する実験を備えたアプリを選択します。
3. ナビゲーション ウィンドウで、**[サービス]** を選択し、**[実験]** を選択します。
4. **[プロジェクト]** セクションのプロジェクトの表で、目的の実験が含まれるプロジェクトを展開し、次のいずれかを実行します。
  * 実験の **[アクティブ化]** リンクをクリックします。 実験が、ページの上部にある **[アクティブな実験]** セクションに追加されます。
  * 実験の名前をクリックし、実験のページの下部までスクロールして、**[アクティブ化]** をクリックします。

> [!IMPORTANT]
> 実験の作成時に **[編集可能な実験]** チェック ボックスをオンにしていないと、実験をアクティブ化した後で実験のパラメーターを変更できなくなります。 アプリで実験のコードを記述してから実験をアクティブ化することをお勧めします。

## <a name="review-the-results-of-your-experiment"></a>実験の結果を確認する

1. デベロッパー センターで、アプリの **[実験]** ページに戻ります。
2. **[アクティブな実験]** セクションで、目的のアクティブな実験の名前をクリックし、実験のページに移動します。
3. アクティブな実験または完了した実験の場合、このページの最初の 2 つのセクションに実験の結果が表示されます。
  * **[結果の概要]** セクションには、実験の目標と各バリエーションのコンバージョン率の一覧が表示されます。
  * **[結果の詳細]** セクションには、ビュー、コンバージョン、固有ユーザー数、コンバージョン率、デルタ %、信頼性、重要性など、実験のすべての目標に対する各検証結果の詳細が表示されます。 *信頼性*は、推定値の信頼性の統計的な計測であり、許容誤差を計算したものです。 *重要性*は、サンプル サイズに基づいた統計的な計測であり、結果が偶然に発生したのではなく、特定の原因によって発生した可能性があることを示すものです。

> [!NOTE]
> デベロッパー センターで報告されるのは、24 時間以内に発生した、各ユーザーの最初のコンバージョン イベントのみです。 ユーザーが 24 時間以内にアプリで複数のコンバージョン イベントをトリガーした場合は、最初のコンバージョン イベントのみ報告されます。 これは、多数のコンバージョン イベントを使用する単一のユーザーによって、サンプルのユーザー グループの実験の結果が歪曲されないようにすることを目的としています。


## <a name="complete-your-experiment"></a>実験を完了する

1. ダッシュボードで、実験のページに戻ります。 手順については、前のセクションをご覧ください。
2. **[結果の概要]** セクションで、次のいずれかの操作を行います。
  * 実験を終了し、アプリでコントロールのバリエーションの変数値を使用し続ける場合は、**[保存]** をクリックします。
  * 実験を終了するが、アプリでは別のバリエーションの変数値を使用する場合は、新たに使用するバリエーションの下にある **[切り替え]** をクリックします。
3. **[OK]** をクリックして、実験を終了することを確認します。


## <a name="related-topics"></a>関連トピック

* [プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [アプリの実験用のコードを記述する](code-your-experiment-in-your-app.md)
* [デベロッパー センター ダッシュボードで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)
