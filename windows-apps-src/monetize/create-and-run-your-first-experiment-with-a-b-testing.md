---
author: mcleanbyron
Description: このチュートリアルでは、A/B テストを使用して最初の試験的機能を作成および実行します。
title: A/B テストを使用して最初の試験的機能を作成および実行する
ms.assetid: 16A2B129-14E1-4C68-86E8-52F1BE58F256
---

# A/B テストを使用して最初の試験的機能を作成および実行する

このチュートリアルでは、次の作業を行います。
* アプリのボタンの背景色を変更するとボタンのクリック回数が正常に増えるかどうかをテストする試験的機能を Windows デベロッパー センター ダッシュボードで作成します。
* デベロッパー センターからバリエーション設定を取得し、そのデータを使用してボタンの背景色を変更し、デベロッパー センターでビュー イベントとコンバージョン イベントのデータをログに記録するアプリを作成します。
* アプリを実行して、試験的機能のデータを収集します。
* デベロッパー センター ダッシュボードで試験的機能の実行結果を確認し、アプリのすべてのユーザーに有効なバリエーションを選択して、試験的機能の実行を完了します。

デベロッパー センターでの A/B テストの概要については、「[A/B テストを使用してアプリの試験的機能を実行する](run-app-experiments-with-a-b-testing.md)」をご覧ください。

## 前提条件

このチュートリアルを実行するには、Windows デベロッパー センターのアカウントが必要です。また、「[A/B テストを使用してアプリの試験的機能を実行する](run-app-experiments-with-a-b-testing.md)」の説明に従って開発用コンピューターを構成する必要があります。

## Windows デベロッパー センターで試験的機能を作成する

1. [デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインします。
2. 試験的機能の作成に使用するアプリが既にデベロッパー センターにある場合は、**[Your apps]** (自分のアプリ) でアプリを選択します。 ダッシュボードにまだアプリがない場合は、[名前を予約して新しいアプリを作成](../publish/create-your-app-by-reserving-a-name.md)し、ダッシュボードでそのアプリを選択します。
3. ナビゲーション ウィンドウで、**[サービス]** をクリックし、**[Experimentation]** (試験的機能) をクリックします。
4. **[API keys]** (API キー) セクションで、**[New API key]** (新しい API キー) を選択して新しい API キーを生成し、API キーの名前として「**My First Experiment**」と入力します。 この API キーは、このチュートリアルの次のセクションで使用します。
5. **[Experiments]** (試験的機能) セクションで、**[New experiment]** (新しい試験的機能) をクリックします。 **[Experiment name]** (試験的機能の名前) フィールドに「**Optimize Button Clicks**」という名前を入力します。
6. **[ビュー イベント名]** フィールドに「**userViewedButton**」という名前を入力します。 このチュートリアルの後半では、アプリのメイン ページが初期化され、ボタンがユーザーに表示されるときにこのビュー イベントをログに記録するコードを追加します。
7. **[Goals and conversion events]** (目標とコンバージョン イベント) セクションで、次の値を入力します。
  * **[Goal name]** (目標名) フィールドに「**Increase Button Clicks**」と入力します。
  * **[コンバージョン イベント名]** フィールドに「**userClickedButton**」という名前を入力します。 このチュートリアルの後半では、ボタンのクリック イベント ハンドラーでこのコンバージョン イベントをログに記録するコードを追加します。
  * **[目標]** フィールドで、**[最大化]** を選択します。
8. **[Variations and settings]** (バリエーションと設定) セクションで、**[設定の追加]** を 3 回クリックします。 これで、空の設定が 4 行追加されます。
  * 最初の行に、設定名として「**buttonText**」と入力し、**[Variation A]** (バリエーション A) 列に「**Grey Button**」と入力し、**[Variation B]** (バリエーション B) 列に「**Blue Button**」と入力します。
  * 2 番目の行に、設定名として「**r**」と入力し、**[Variation A]** (バリエーション A) 列に「**128**」と入力し、**[Variation B]** (バリエーション B) 列に「**1**」と入力します。
  * 3 番目の行に、設定名として「**g**」と入力し、**[Variation A]** (バリエーション A) 列に「**128**」と入力し、**[Variation B]** (バリエーション B) 列に「**1**」と入力します。
  * 4 番目の行に、設定名として「**b**」と入力し、**[Variation A]** 列に「**128**」と入力し、**[Variation B]** 列に「**255**」と入力します。  
9. **[均等な配分]** チェック ボックスがオンになっていることを確認します。これで、バリエーションがアプリに均等に配分されます。
10. **[保存]** をクリックし、**[アクティブ化]** をクリックします。

> **重要:** 試験的機能をアクティブ化した後は、試験的機能がテスト用でない限り (試験的機能の作成時に **[Test experiment]** (試験的機能をテストする) チェック ボックスをオンにした場合を除き)、試験的機能のパラメーターを変更できなくなります。 通常は、アプリで試験的機能のコードを記述してから試験的機能をアクティブ化することをお勧めします。 わかりやすくするために、このチュートリアルでは試験的機能をすぐにアクティブ化できるようにしています。

## アプリで試験的機能のコードを記述する

1. Visual Studio 2015 で、Visual C# を使用して新しいユニバーサル Windows プラットフォーム プロジェクトを作成します。 プロジェクトに「**SampleExperiment**」という名前を付けます。
2. ソリューション エクスプローラーで、プロジェクト ノードを展開し、**[参照設定]** を右クリックして **[参照の追加]** をクリックします。
3. **[参照マネージャー]**で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
4. SDK の一覧で、**[Microsoft Store Engagement SDK]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。
5. **ソリューション エクスプローラー**で、MainPage.xaml をダブルクリックして、アプリでメイン ページのデザイナーを開きます。
6. **[ツールボックス]** からページに**ボタン**をドラッグします。
7. デザイナーでボタンをダブルクリックしてコード ファイルを開き、**Click** イベントのイベント ハンドラーを追加します。  
8. コード ファイルのすべての内容を次のコードで置き換えます。

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
        private readonly ExperimentClient experiment;
        private ExperimentVariation variation;

        // Assign this variable to your API key from Dev Center. The API key
        // shown below is for example purposes only.
        private string apiKey = "F48AC670-4472-4387-AB7D-D65B095153FB";    

        public MainPage()
        {
            this.InitializeComponent();

            // Initialize the ExperimentClient for A/B testing.
            experiment = new ExperimentClient(apiKey);

            // Because this call is not awaited, execution of the current method
            // continues before the call is completed.
            #pragma warning disable CS4014
            Initialize();
            #pragma warning restore CS4014
        }

        private async Task Initialize()
        {
            // Get the current cached variation assignment for the experiment.
            ExperimentVariationResult result = await experiment.GetVariationAsync();
            variation = result.Variation;

            // Check whether the cached variation assignment needs to be refreshed.
            // If so, then refresh it.
            if (result.ErrorCode != EngagementErrorCode.Success || result.Variation.NeedsRefresh)
            {
                result = await experiment.RefreshVariationAsync();

                // If the call succeeds, use the new result. Otherwise, use the cached value.
                if (result.ErrorCode == EngagementErrorCode.Success)
                {
                    variation = result.Variation;
                }
            }

            // Get settings named "buttonText", "r", "g", and "b" from the variation
            // assignment. If no variation assignment is available, the settings default
            // to "Grey button" for the button text and grey RGB value for the button color.
            var buttonText = variation.GetString("buttonText", "Grey Button");
            var r = (byte)variation.GetInteger("r", 128);
            var g = (byte)variation.GetInteger("g", 128);
            var b = (byte)variation.GetInteger("b", 128);

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
            StoreServicesCustomEvents.Log("userViewedButton", variation);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Log the conversion event named "userClickedButton" to Dev Center.
            StoreServicesCustomEvents.Log("userClickedButton", variation);
        }
     }
  }
  ```
9. 次のコード行で、前のセクションでデベロッパー センター ダッシュボードから取得した API キーに *apiKey* 変数を割り当てます。 次に示す API キーは例示のためのものです。
```CSharp
private string apiKey = "F48AC670-4472-4387-AB7D-D65B095153FB";
```
10. コード ファイルを保存して、プロジェクトをビルドします。

## アプリを実行して試験的機能のデータを収集する

1. 前のセクションで作成した **SampleExperiment** アプリを実行します。
2. 灰色または青色のボタンが表示されることを確認します。 ボタンをクリックしてアプリを閉じます。
3. 同じコンピューターで上記の手順を複数回繰り返して、同じボタンの色がアプリに表示されることを確認します。

## 結果を確認して試験的機能の実行を完了する

前のセクションの手順を完了して少なくとも数時間経ってから、次の手順に従って試験的機能の実行結果を確認し、試験的機能の実行を完了します。

> **注:** 試験的機能をアクティブ化するとすぐに、デベロッパー センターでは、試験的機能のデータをログに記録するようにインストルメント化されたアプリからデータの収集を開始します。 ただし、試験的機能のデータがダッシュボードに表示されるまでに数時間かかることがあります。

1. デベロッパー センターで、アプリの **[Experimentation]** (試験的機能) ページに戻ります。
2. **[Experiments]** (試験的機能) セクションで、**[アクティブ]** フィルターをクリックし、**[Optimize Button Clicks]** (ボタンのクリックを最適化) をクリックしてこの試験的機能のページに移動します。
3. **[Results summary]** (結果の要約) セクションと **[Results details]** (結果の詳細) セクションに表示される結果が想定した結果と一致していることを確認します。 これらのセクションについて詳しくは、「[デベロッパー センター ダッシュボードで試験的機能を管理する](manage-your-experiment.md#review-the-results-of-your-experiment)」をご覧ください。

  >**注:** デベロッパー センターで報告されるのは、24 時間以内に発生した、各ユーザーの最初のコンバージョン イベントのみです。 ユーザーが 24 時間以内にアプリで複数のコンバージョン イベントをトリガーした場合は、最初のコンバージョン イベントのみ報告されます。 これは、多数のコンバージョン イベントを使用する単一のユーザーによって、サンプルのユーザー グループの試験的機能の実行結果が歪曲されないようにすることを目的としています。

4. これで、試験的機能の実行を終了できるようになりました。 **[Results summary]** (結果の要約) セクションの **[Variation B]** (バリエーション B) 列で、**[切り替え]** をクリックします。 これで、アプリのすべてのユーザーが青色のボタンに切り替えられます。
5. **[OK]** をクリックして、試験的機能の実行を終了することを確認します。
6. 前のセクションで作成した **SampleExperiment** アプリを実行します。
7. 青色のボタンが表示されることを確認します。 更新されたバリエーションの割り当てをアプリが受信するまでに、最大で 2 分かかる場合があります。

## 関連トピック

  * [デベロッパー センター ダッシュボードで試験的機能を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
  * [アプリで試験的機能のコードを記述する](code-your-experiment-in-your-app.md)
  * [デベロッパー センター ダッシュボードで試験的機能を管理する](manage-your-experiment.md)
  * [A/B テストを使用してアプリの試験的機能を実行する](run-app-experiments-with-a-b-testing.md)


<!--HONumber=May16_HO2-->


