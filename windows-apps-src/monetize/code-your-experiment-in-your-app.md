---
author: mcleanbyron
Description: "ユニバーサル Windows プラットフォーム (UWP) アプリで A/B テストを実行するには、アプリで実験用のコードを記述する必要があります。"
title: "アプリの実験用のコードを記述する"
ms.assetid: 6A5063E1-28CD-4087-A4FA-FBB511E9CED5
translationtype: Human Translation
ms.sourcegitcommit: 29a94fd14d11256ade28463c04abfec81287cf39
ms.openlocfilehash: e5de32dcc7b0694e72d9686b3b9a64de17a02277

---

# アプリの実験用のコードを記述する

[デベロッパー センター ダッシュボードでプロジェクトを作成し、リモート変数を定義](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)した後、ユニバーサル Windows プラットフォーム (UWP) アプリでコードを更新して、次の操作を行うことができます。
* Windows デベロッパー センターでリモート変数値を受け取る。
* リモート変数を使用して、ユーザーのアプリ エクスペリエンスを構成する。
* ユーザーが実験を表示し、必要なアクションを実行 ("*コンバージョン*" とも呼ばれます) したタイミングを示すイベントのログを、デベロッパー センターに記録する。

以降のセクションでは、実験のバリエーションを取得し、デベロッパー センターでイベントをログに記録するための一般的なプロセスについて説明します。 アプリの実験用のコードを記述すると、[デベロッパー センター ダッシュボードで実験を定義](define-your-experiment-in-the-dev-center-dashboard.md)できます。 実験の作成と実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

## プロジェクトを構成する

最初に、Microsoft Store Services SDK を開発用コンピューターにインストールして、プロジェクトに必要な参照を追加します。

1. [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストールします。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクト ノードを展開し、**[参照設定]** を右クリックして **[参照の追加]** をクリックします。
3. **[参照マネージャー]**で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
4. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

## バリエーション データを取得するコードを追加する

プロジェクトで、実験で変更する機能のコードを探します。 バリエーションのデータを取得するコードを追加し、そのデータを使って、テストする機能の動作を変更します。 必要なコードはアプリによって異なりますが、ここでは一般的な手順を示します。 完全なコード例については、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

1. 現在のバリエーションの割り当てを表す [StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) オブジェクトと、ビュー イベントとコンバージョン イベントのログをデベロッパー センターに記録するときに使用する [StoreServicesCustomEventLogger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.aspx) オブジェクトを宣言します。
```CSharp
private StoreServicesExperimentVariation variation;
private StoreServicesCustomEventLogger logger;
```

2. 静的な [GetCachedVariationAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getcachedvariationasync.aspx) メソッドを呼び出して、実験に対するキャッシュされた現在のバリエーションの割り当てを取得し、実験の[プロジェクトID](run-app-experiments-with-a-b-testing.md#terms) をそのメソッドに渡します。 このメソッドは、[ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariationresult.experimentvariation.aspx) プロパティを使用してバリエーションの割り当てへのアクセスを提供する [StoreServicesExperimentVariationResult](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariationresult.aspx) オブジェクトを返します。
  >**注:**&nbsp;&nbsp;[デベロッパー センター ダッシュボードでプロジェクトを作成](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)するときに、プロジェクト ID を取得します。 次に示すプロジェクト ID は例示のためのものです。

  ```CSharp
var result = await StoreServicesExperimentVariation.GetCachedVariationAsync(
      "F48AC670-4472-4387-AB7D-D65B095153FB");
variation = result.ExperimentVariation;
```

4. [IsStale](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.isstale.aspx) プロパティを確認して、キャッシュされたバリエーションの割り当てを、サーバーからリモートのバリエーションの割り当てによって更新する必要があるかどうかを判断します。 更新する必要がある場合は、静的な [GetRefreshedVariationAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getrefreshedvariationasync.aspx) メソッドを呼び出して、サーバーから更新されたバリエーションの割り当てを確認し、ローカルでキャッシュされたバリエーションを更新します。
```CSharp
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
```

5. [StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) オブジェクトの [GetBoolean](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getboolean.aspx)、[GetDouble](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getdouble.aspx)、[GetInt32](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getint32.aspx)、または [GetString](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring.aspx) の各メソッドを使用して、バリエーションの割り当ての値を取得します。 各メソッドの最初のパラメーターは、取得する設定のバリエーションの名前 (デベロッパー センター ダッシュボードで入力するバリエーションと同じ名前) です。 2 番目のパラメーターは、デベロッパー センターから指定された値を取得できない場合 (たとえば、ネットワークから切断されている場合) やキャッシュされたバージョンのバリエーションを利用できない場合にメソッドが返す必要のある既定値です。

  次の例では、[GetString](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring.aspx) を使用して、*buttonText* という名前の変数を取得し、**Grey Button** の既定の変数値を指定します。
```CSharp
var buttonText = variation.GetString("buttonText", "Grey Button");
```
4. コードで、変数値を使用して、テストする機能の動作を変更します。 たとえば、次のコードでは *buttonText* 値をボタンのコンテンツに割り当てます。
```CSharp
button.Content = buttonText;
```

## ビュー イベントとコンバージョン イベントをログに記録するコードをデベロッパー センターに追加する

次に、[ビュー イベント](run-app-experiments-with-a-b-testing.md#terms)と[コンバージョン イベント](run-app-experiments-with-a-b-testing.md#terms)をログに記録するコードを、デベロッパー センターの A/B テスト サービスに追加します。 試験的機能に含まれるバリエーションの表示をユーザーが開始した場合はビュー イベントをログに記録し、試験的機能の目的をユーザーが達成した場合はコンバージョン イベントをログに記録する必要があります。

必要なコードはアプリによって異なりますが、ここでは一般的な手順を示します。 完全なコード例については、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

1. バリエーションの表示をユーザーが開始した場合に実行するコードで、```logger``` フィールドを [StoreServicesCustomEventLogger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.aspx) オブジェクトに初期化し、[LogForVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation.aspx) メソッドを呼び出します。 現在のバリエーションの割り当てを表す [StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) オブジェクト (イベントに関するコンテキストをデベロッパー センターに提供します)、およびビュー イベントの名前 (デベロッパー センター ダッシュボードで入力するビュー イベントと同じ名前) を渡します。 次の例では、**userViewedButton** という名前のビュー イベントをログに記録します。

  ```CSharp
  if (logger == null)
  {
      logger = StoreServicesCustomEventLogger.GetDefault();
  }

  logger.LogForVariation(variation, "userViewedButton");
  ```

2. 実験のいずれかのゴールの目的をユーザーが達成した場合に実行するコードで、[LogForVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation.aspx) メソッドをもう一度呼び出して、[StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) オブジェクトと、コンバージョン イベントの名前 (デベロッパー センター ダッシュボードで入力するコンバージョン イベントと同じ名前) を渡します。 次の例では、**userClickedButton** という名前のコンバージョン イベントをログに記録します。
```CSharp
logger.LogForVariation(variation, "userClickedButton");
```

## 次のステップ

アプリの実験用のコードを記述したら、次の手順に進むことができます。
1. [デベロッパー センター ダッシュボードで実験を定義します](define-your-experiment-in-the-dev-center-dashboard.md)。 ビュー イベント、コンバージョン イベント、A/B テストの一意のバリエーションを定義する実験を作成します。
2. [デベロッパー センター ダッシュボードで実験を実行および管理します](manage-your-experiment.md)。


## 関連トピック

* [プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を管理する](manage-your-experiment.md)
* [A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)



<!--HONumber=Sep16_HO1-->


