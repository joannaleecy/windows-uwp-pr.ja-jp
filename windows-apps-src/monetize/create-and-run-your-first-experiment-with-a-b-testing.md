---
author: mcleanbyron
Description: "このチュートリアルでは、A/B テストを使用して最初の実験を作成、実行、管理します。"
title: "A/B テストを使用して最初の実験を作成および実行する"
ms.assetid: 16A2B129-14E1-4C68-86E8-52F1BE58F256
translationtype: Human Translation
ms.sourcegitcommit: bfe4862c441ca095a40df4f594fdf9b3e213d142
ms.openlocfilehash: ab15741531b829c496811cdfca35059cd113f91d

---

# A/B テストを使用して最初の実験を作成および実行する

このチュートリアルでは、次の作業を行います。
* デベロッパー センター ダッシュボードで、アプリのボタンのテキストと色を表すいくつかのリモート変数を定義する実験[プロジェクト](run-app-experiments-with-a-b-testing.md#terms)を作成します。
* リモート変数の値を取得し、そのデータを使用してボタンの背景色を変更し、デベロッパー センターでビュー イベントとコンバージョン イベントのデータをログに記録するアプリを作成します。
* アプリのボタンの背景色を変更するとボタンのクリック回数が正常に増えるかどうかをテストする実験をプロジェクトに作成します。
* アプリを実行して、実験データを収集します。
* デベロッパー センター ダッシュボードで実験結果を確認し、アプリのすべてのユーザーに有効なバリエーションを選択して、実験を完了します。

デベロッパー センターでの A/B テストの概要については、「[A/B テストを使用してアプリの試験的機能を実行する](run-app-experiments-with-a-b-testing.md)」をご覧ください。

## 前提条件

このチュートリアルを実行するには、Windows デベロッパー センターのアカウントが必要です。また、「[A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)」の説明に従って開発用コンピューターを構成する必要があります。

## Windows デベロッパー センターでリモート変数を含むプロジェクトを作成する

1. [デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインします。
2. 実験の作成に使用するアプリが既にデベロッパー センターにある場合は、ダッシュボードでそのアプリを選択します。 ダッシュボードにまだアプリがない場合は、[名前を予約して新しいアプリを作成](../publish/create-your-app-by-reserving-a-name.md)し、ダッシュボードでそのアプリを選択します。
3. ナビゲーション ウィンドウで、**[サービス]** をクリックし、**[実験]** をクリックします。
4. 次のページの **[プロジェクト]** セクションで、**[新しいプロジェクト]** ボタンをクリックします。
5. **[新しいプロジェクト]** ページで、新しいプロジェクトの名前として「**Button Click Experiments**」と入力します。
6. **[リモート変数]** セクションを展開し、**[変数の追加]** を 4 回クリックします。 これで、空の変数行が 4 行追加されます。
  * 最初の行で、変数名として「**buttonText**」と入力し、**[既定値]** 列に「**Grey Button**」と入力します。
  * 2 番目の行で、変数名として「**r**」と入力し、**[既定値]** 列に「**128**」と入力します。
  * 3 番目の行で、変数名として「**g**」と入力し、**[既定値]** 列に「**128**」と入力します。
  * 4 番目の行で、変数名として「**b**」と入力し、**[既定値]** 列に「**128**」と入力します。
7. **[保存]** をクリックし、**[SDK 統合]** セクションに表示される[プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms) 値を書き留めます。 次のセクションでは、アプリのコードを更新し、コードでこの値を参照します。

## アプリで実験のコードを記述する

1. Visual Studio 2015 で、Visual C# を使用して新しいユニバーサル Windows プラットフォーム プロジェクトを作成します。 プロジェクトに「**SampleExperiment**」という名前を付けます。
2. ソリューション エクスプローラーで、プロジェクト ノードを展開し、**[参照設定]** を右クリックして **[参照の追加]** をクリックします。
3. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
4. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。
5. **ソリューション エクスプローラー**で、MainPage.xaml をダブルクリックして、アプリでメイン ページのデザイナーを開きます。
6. **[ツールボックス]** からページに**ボタン**をドラッグします。
7. デザイナーでボタンをダブルクリックしてコード ファイルを開き、**Click** イベントのイベント ハンドラーを追加します。  
8. コード ファイルのすべての内容を次のコードで置き換えます。 ```projectId``` 変数を、前のセクションでデベロッパー センター ダッシュボードから取得した[プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms) 値に割り当てます。

  ```CSharp
  using System;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Controls;
  using Windows.UI.Xaml.Media;
  using System.Threading.Tasks;
  using Windows.UI;
  using Windows.UI.Core;

  // Namespace for A/B testing.
  using Microsoft.Services.Store.Engagement;

  namespace SampleExperiment
  {  
     public sealed partial class MainPage : Page
     {
        private StoreServicesExperimentVariation variation;
        private StoreServicesCustomEventLogger logger;

        // Assign this variable to the project ID for your experiment from Dev Center.
        private string projectId = "";

        public MainPage()
        {
            this.InitializeComponent();

            // Because this call is not awaited, execution of the current method
            // continues before the call is completed.
#pragma warning disable CS4014
            InitializeExperiment();
#pragma warning restore CS4014
        }

        private async Task InitializeExperiment()
        {
            // Get the current cached variation assignment for the experiment.
            var result = await StoreServicesExperimentVariation.GetCachedVariationAsync(projectId);
            variation = result.ExperimentVariation;

            // Check whether the cached variation assignment needs to be refreshed.
            // If so, then refresh it.
            if (result.ErrorCode != StoreServicesEngagementErrorCode.None || result.ExperimentVariation.IsStale)
            {
                result = await StoreServicesExperimentVariation.GetRefreshedVariationAsync(projectId);

                // If the call succeeds, use the new result. Otherwise, use the cached value.
                if (result.ErrorCode == StoreServicesEngagementErrorCode.None)
                {
                    variation = result.ExperimentVariation;
                }
            }

            // Get remote variables named "buttonText", "r", "g", and "b" from the variation
            // assignment. If no variation assignment is available, the variables default
            // to "Grey button" for the button text and grey RGB value for the button color.
            var buttonText = variation.GetString("buttonText", "Grey Button");
            var r = (byte)variation.GetInt32("r", 128);
            var g = (byte)variation.GetInt32("g", 128);
            var b = (byte)variation.GetInt32("b", 128);

            // Assign button text and color.
            await button.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    button.Background = new SolidColorBrush(Color.FromArgb(255, r, g, b));
                    button.Content = buttonText;
                    button.Visibility = Visibility.Visible;
                });

            // Log the view event named "userViewedButton" to Dev Center.
            if (logger == null)
            {
                logger = StoreServicesCustomEventLogger.GetDefault();
            }

            logger.LogForVariation(variation, "userViewedButton");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Log the conversion event named "userClickedButton" to Dev Center.
            if (logger == null)
            {
                logger = StoreServicesCustomEventLogger.GetDefault();
            }

            logger.LogForVariation(variation, "userClickedButton");
        }
     }
  }
  ```
10. コード ファイルを保存して、プロジェクトをビルドします。

## Windows デベロッパー センターで実験を作成する

1. Windows デベロッパー センター ダッシュボードの **Button Click Experiments** プロジェクト ページに戻ります。
2. **[Experiments]** セクションで、**[新しい実験]** ボタンをクリックします。
5. **[実験の詳細]** セクションで、**[実験名]** フィールドに「**Optimize Button Clicks**」と入力します。
6. **[ビュー イベント]** セクションで、**[ビュー イベント名]** フィールドに「**userViewedButton**」と入力します。 この名前が、前のセクションで追加したコードで記録したビュー イベント文字列と一致することに注意してください。
7. **[ゴールとコンバージョン イベント]** セクションで、次の値を入力します。
  * **[Goal name]** (目標名) フィールドに「**Increase Button Clicks**」と入力します。
  * **[コンバージョン イベント名]** フィールドに「**userClickedButton**」という名前を入力します。 この名前が、前のセクションで追加したコードで記録したコンバージョン イベント文字列と一致することに注意してください。
  * **[目標]** フィールドで、**[最大化]** を選択します。
8. **[リモート変数とバリエーション]** セクションで、バリエーションがアプリに均等に配分されるように **[均等に配布する]** チェック ボックスがオンになっていることを確認します。
9. 変数を実験に追加します。
  9. ドロップダウン コントロールをクリックし、**[buttonText]** を選択して、**[変数の追加]** をクリックします。 文字列 **Grey Button** が **[バリエーション A]** 列に自動的に表示されます (この値はプロジェクトの設定から派生します)。 **[バリエーション B]** 列で、「**Blue Button**」と入力します。
  9. もう一度ドロップダウン コントロールをクリックし、**[r]** を選択して、**[変数の追加]** をクリックします。 文字列 **128** が **[バリエーション A]** 列に自動的に表示されます。 **[バリエーション B]** 列で、「**1**」と入力します。
  9. もう一度ドロップダウン コントロールをクリックし、**[g]** を選択して、**[変数の追加]** をクリックします。 文字列 **128** が **[バリエーション A]** 列に自動的に表示されます。 **[バリエーション B]** 列で、「**1**」と入力します。  
  9. もう一度ドロップダウン コントロールをクリックし、**[b]** を選択して、**[変数の追加]** をクリックします。 文字列 **128** が **[バリエーション A]** 列に自動的に表示されます。 **[バリエーション B]** 列で、「**255**」と入力します。  
10. **[保存]** をクリックし、**[アクティブ化]** をクリックします。

> **重要**&nbsp;&nbsp;実験をアクティブ化した後は、実験の作成時に **[編集可能な実験]** チェック ボックスをオンにしなかった限り、実験のパラメーターを変更できなくなります。 通常は、アプリで実験のコードを記述してから実験をアクティブ化することをお勧めします。

## アプリを実行して実験データを収集する

1. 前の手順で作成した **SampleExperiment** アプリを実行します。
2. 灰色または青色のボタンが表示されることを確認します。 ボタンをクリックしてアプリを閉じます。
3. 同じコンピューターで上記の手順を複数回繰り返して、同じボタンの色がアプリに表示されることを確認します。

## 結果を確認して試験的機能の実行を完了する

前のセクションの手順を完了して少なくとも数時間経ってから、次の手順に従って試験的機能の実行結果を確認し、試験的機能の実行を完了します。

> **注:**&nbsp;&nbsp;実験をアクティブ化するとすぐに、デベロッパー センターでは、実験のデータをログに記録するようにインストルメント化されたアプリからデータの収集を開始します。 ただし、試験的機能のデータがダッシュボードに表示されるまでに数時間かかることがあります。

1. デベロッパー センターで、アプリの **[実験]** ページに戻ります。
2. **[アクティブな実験]** セクションで、**[Optimize Button Clicks]** (ボタンのクリックを最適化) をクリックしてこの実験のページに移動します。
3. **[Results summary]** (結果の要約) セクションと **[Results details]** (結果の詳細) セクションに表示される結果が想定した結果と一致していることを確認します。 これらのセクションについて詳しくは、「[デベロッパー センター ダッシュボードで試験的機能を管理する](manage-your-experiment.md#review-the-results-of-your-experiment)」をご覧ください。

  >**注:**&nbsp;&nbsp;デベロッパー センターで報告されるのは、24 時間以内に発生した、各ユーザーの最初のコンバージョン イベントのみです。 ユーザーが 24 時間以内にアプリで複数のコンバージョン イベントをトリガーした場合は、最初のコンバージョン イベントのみ報告されます。 これは、多数のコンバージョン イベントを使用する単一のユーザーによって、サンプルのユーザー グループの試験的機能の実行結果が歪曲されないようにすることを目的としています。
4. これで、試験的機能の実行を終了できるようになりました。 **[Results summary]** (結果の要約) セクションの **[Variation B]** (バリエーション B) 列で、**[切り替え]** をクリックします。 これで、アプリのすべてのユーザーが青色のボタンに切り替えられます。
5. **[OK]** をクリックして、試験的機能の実行を終了することを確認します。
6. 前のセクションで作成した **SampleExperiment** アプリを実行します。
7. 青色のボタンが表示されることを確認します。 更新されたバリエーションの割り当てをアプリが受信するまでに、最大で 2 分かかる場合があります。

## 関連トピック

* [プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [アプリの実験用のコードを記述する](code-your-experiment-in-your-app.md)
* [デベロッパー センター ダッシュボードで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を管理する](manage-your-experiment.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)



<!--HONumber=Sep16_HO1-->


