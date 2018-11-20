---
author: Xansky
Description: After you define your experiment in Partner Center and code your experiment in your app, you are ready to active your experiment and use Partner Center to review the results of your experiment.
title: パートナー センターで実験を管理する
ms.assetid: D48EE0B4-47F2-455C-8FB9-630769AC5ACE
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、Microsoft Store Services SDK、A/B テスト、実験
ms.localizationpriority: medium
ms.openlocfilehash: 9d1cdb80a2278850f18cecc631fef0b5dff0fefc
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7419952"
---
# <a name="manage-your-experiment-in-partner-center"></a>パートナー センターで実験を管理する

[パートナー センターで実験を定義](define-your-experiment-in-the-dev-center-dashboard.md)すると、[実験用のアプリのコード](code-your-experiment-in-your-app.md)実験をアクティブ化し、パートナー センターを使用して、実験の結果を確認する準備ができたらします。 必要なすべてのデータを取得したら、実験を終了し、すべてのアプリでコントロールのバリエーションの変数値を使用し続けるか、他のバリエーションの変数値を使用することに切り替えるかを選択できます。

> [!NOTE]
> 実験をアクティブ化するとすぐにパートナー センターが実験のデータをログにインストルメント化されたアプリからデータの収集を開始します。 ただし、実験のデータがパートナー センターで表示される数時間がかかることができます。

実験の作成および実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

## <a name="activate-your-experiment"></a>実験をアクティブ化する

パートナー センターで実験のパラメーターに問題がなければ、アプリのコードを更新するは、アプリから実験データの収集を開始するために、実験をアクティブ化する準備ができたらします。 実験がアクティブである場合、アプリはバリエーション値を取得し、パートナー センターにビュー イベントとコンバージョン イベントを報告できます。

1. [パートナー センター](https://partner.microsoft.com/dashboard)にサインインします。
2. **[アプリ]** の下で、アクティブ化する実験を備えたアプリを選択します。
3. ナビゲーション ウィンドウで、**[サービス]** を選択し、**[実験]** を選択します。
4. **[プロジェクト]** セクションのプロジェクトの表で、目的の実験が含まれるプロジェクトを展開し、次のいずれかを実行します。
  * 実験の **[アクティブ化]** リンクをクリックします。 実験が、ページの上部にある **[アクティブな実験]** セクションに追加されます。
  * 実験の名前をクリックし、実験のページの下部までスクロールして、**[アクティブ化]** をクリックします。

> [!IMPORTANT]
> 実験の作成時に **[編集可能な実験]** チェック ボックスをオンにしていないと、実験をアクティブ化した後で実験のパラメーターを変更できなくなります。 アプリで実験のコードを記述してから実験をアクティブ化することをお勧めします。

## <a name="review-the-results-of-your-experiment"></a>実験の結果を確認する

1. パートナー センターでは、アプリの**実験**のページに戻ります。
2. **[アクティブな実験]** セクションで、目的のアクティブな実験の名前をクリックし、実験のページに移動します。
3. アクティブな実験または完了した実験の場合、このページの最初の 2 つのセクションに実験の結果が表示されます。
  * **[結果の概要]** セクションには、実験の目標と各バリエーションのコンバージョン率の一覧が表示されます。
  * **[結果の詳細]** セクションには、ビュー、コンバージョン、固有ユーザー数、コンバージョン率、デルタ %、信頼性、重要性など、実験のすべての目標に対する各検証結果の詳細が表示されます。 *信頼性*は、推定値の信頼性の統計的な計測であり、許容誤差を計算したものです。 *重要性*は、サンプル サイズに基づいた統計的な計測であり、結果が偶然に発生したのではなく、特定の原因によって発生した可能性があることを示すものです。

> [!NOTE]
> パートナー センターでは、24 時間の期間内の各ユーザーの最初のコンバージョン イベントのみを報告します。 ユーザーが 24 時間以内にアプリで複数のコンバージョン イベントをトリガーした場合は、最初のコンバージョン イベントのみ報告されます。 これは、多数のコンバージョン イベントを使用する単一のユーザーによって、サンプルのユーザー グループの実験の結果が歪曲されないようにすることを目的としています。


## <a name="complete-your-experiment"></a>実験を完了する

1. パートナー センターで、実験のページに戻ります。 手順については、前のセクションをご覧ください。
2. **[結果の概要]** セクションで、次のいずれかの操作を行います。
  * 実験を終了し、アプリでコントロールのバリエーションの変数値を使用し続ける場合は、**[保存]** をクリックします。
  * 実験を終了するが、アプリでは別のバリエーションの変数値を使用する場合は、新たに使用するバリエーションの下にある **[切り替え]** をクリックします。
3. **[OK]** をクリックして、実験を終了することを確認します。


## <a name="related-topics"></a>関連トピック

* [プロジェクトを作成し、パートナー センターでリモート変数を定義します。](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [アプリの実験用のコードを記述する](code-your-experiment-in-your-app.md)
* [パートナー センターで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)
