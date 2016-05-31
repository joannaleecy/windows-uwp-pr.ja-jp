---
author: mcleanbyron
Description: デベロッパー センター ダッシュボードで試験的機能を定義したら、アプリでその試験的機能のコードを記述できます。
title: アプリで試験的機能のコードを記述する
ms.assetid: 6A5063E1-28CD-4087-A4FA-FBB511E9CED5
---

# アプリで試験的機能のコードを記述する

[デベロッパー センター ダッシュボードで試験的機能を定義](define-your-experiment-in-the-dev-center-dashboard.md)したら、ユニバーサル Windows プラットフォーム (UWP) アプリでコードを更新して試験的機能のバリエーション データを取得し、そのデータを使って、テストする機能の動作を変更し、デベロッパー センターでビュー イベントとコンバージョン イベントをログに記録できます。

以降のセクションでは、試験的機能のバリエーションを取得し、デベロッパー センターでイベントをログに記録するための一般的なプロセスについて説明します。 試験的機能の作成および実行のプロセスを詳しく示すチュートリアルについては、「[A/B テストを使用して最初の試験的機能を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

## プロジェクトを構成する

最初に、Microsoft Store Engagement and Monetization SDK を開発用コンピューターにインストールして、プロジェクトに必要な参照を追加します。

1. [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) をインストールします。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクト ノードを展開し、**[参照設定]** を右クリックして **[参照の追加]** をクリックします。
3. **[参照マネージャー]**で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
4. SDK の一覧で、**[Microsoft Store Engagement SDK]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

## バリエーション設定を取得するコードを追加する

プロジェクトで、試験的機能の実行において変更する機能のコードを探します。 バリエーションの設定を取得するコードを追加し、そのデータを使って、テストする機能の動作を変更します。 必要なコードはアプリによって異なりますが、ここでは一般的な手順を示します。 完全なコード例については、「[A/B テストを使用して最初の試験的機能を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

1. 試験的機能のバリエーションを取得するために使用する [ExperimentClient](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.aspx) オブジェクトと現在のバリエーションの割り当てを表す [ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.aspx) オブジェクトを宣言します。
```CSharp
private readonly ExperimentClient experiment;
private ExperimentVariation variation;
```

2. [ExperimentClient](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.aspx) オブジェクトを初期化し、ダッシュボードの **[Experiments]** (試験的機能) ページから取得した API キーをコンストラクターに渡します。 API キーについて詳しくは、「[デベロッパー センター ダッシュボードで試験的機能を定義する](define-your-experiment-in-the-dev-center-dashboard.md#generate-an-api-key)」をご覧ください。 次に示す API キーは例示のためのものです。
```CSharp
experiment = new ExperimentClient("F48AC670-4472-4387-AB7D-D65B095153FB");
```

3. [GetVariationAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.getvariationasync.aspx) メソッドを呼び出して、試験的機能の現在のキャッシュされたバリエーションの割り当てを取得します。 このメソッドは、[Variation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariationresult.variation.aspx) プロパティを使用してバリエーションの割り当てへのアクセスを提供する [ExperimentVariationResult](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariationresult.aspx) オブジェクトを返します。
```CSharp
ExperimentVariationResult result = await experiment.GetVariationAsync();
variation = result.Variation;
```

4. [NeedsRefresh](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.needsrefresh.aspx) プロパティを確認して、キャッシュされたバリエーションの割り当てを更新する必要があるかどうかを判断します。 更新する必要がある場合は、[RefreshVariationAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentclient.refreshvariationasync.aspx) メソッドを呼び出して、サーバーから更新されたバリエーションの割り当てを確認し、ローカルでキャッシュされたバリエーションを更新します。
```CSharp
// Check whether the cached variation assignment needs to be refreshed.
// If so, then refresh it.
if (result.ErrorCode != EngagementErrorCode.Success || result.Variation.NeedsRefresh)
{
      result = await experiment.RefreshVariationAsync();

      // If the call succeeds, use the new result. Otherwise, use the
      // cached value we retrieved earlier.
      if (result.ErrorCode == EngagementErrorCode.Success)
      {
          variation = result.Variation;
      }
}
```

5. [ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.aspx) オブジェクトの [GetBoolean](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getboolean.aspx)、[GetDouble](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getdouble.aspx)、[GetInteger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getinteger.aspx)、または [GetString](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getstring.aspx) の各メソッドを使用して、バリエーションの割り当ての設定を取得します。 各メソッドの最初のパラメーターは、(デベロッパー センター ダッシュボードで入力した) 取得する設定の名前です。 2 番目のパラメーターは、デベロッパー センターから指定された値を取得できない場合 (たとえば、ネットワークから切断されている場合) やキャッシュされたバージョンのバリエーションを利用できない場合にメソッドが返す必要のある既定値です。

  次の例では、[GetString](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.getstring.aspx) を使用して、*buttonText* という名前の設定を取得し、**Grey Button** の既定の設定値を指定します。
```CSharp
var buttonText = currentVariation.GetString("buttonText", "Grey Button");
```
4. コードで、設定値を使用して、テストする機能の動作を変更します。 たとえば、次のコードでは *buttonText* 値をボタンのコンテンツに割り当てます。
```CSharp
button.Content = buttonText;
```

## ビュー イベントとコンバージョン イベントをログに記録するコードをデベロッパー センターに追加する

次に、ビュー イベントとコンバージョン イベントをログに記録するコードをデベロッパー センターの A/B テスト サービスに追加します。 試験的機能に含まれるバリエーションの表示をユーザーが開始した場合はビュー イベントをログに記録し、試験的機能の目的をユーザーが達成した場合はコンバージョン イベントをログに記録する必要があります。

必要なコードはアプリによって異なりますが、ここでは一般的な手順を示します。 完全なコード例については、「[A/B テストを使用して最初の試験的機能を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

1. バリエーションの表示をユーザーが開始した場合に実行するコードで、[StoreServicesCustomEvents](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomevents.aspx) オブジェクトの静的な [Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomevents.log.aspx) メソッドを呼び出します。 デベロッパー センター ダッシュボードで試験的機能に定義したビュー イベントの名前と、現在のバリエーションの割り当てを表す [ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.aspx) オブジェクト (このオブジェクトはイベントに関するコンテキストをデベロッパー センターに提供します) を渡します。 次の例では、**userViewedButton** という名前のビュー イベントをログに記録します。
```CSharp
StoreServicesCustomEvents.Log("userViewedButton", variation);
```
2. 試験的機能のいずれかのゴールの目的をユーザーが達成した場合に実行するコードで、[Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomevents.log.aspx) メソッドをもう一度呼び出して、試験的機能に定義したコンバージョン イベントの名前と [ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.experimentvariation.aspx) オブジェクトを渡します。 次の例では、**userClickedButton** という名前のコンバージョン イベントをログに記録します。
```CSharp
StoreServicesCustomEvents.Log("userClickedButton", variation);
```

## 次の手順

デベロッパー センター ダッシュボードで試験的機能を定義し、アプリでその試験的機能のコードを記述したら、[デベロッパー センター ダッシュボードで試験的機能を実行および管理](manage-your-experiment.md)できます。

## 関連トピック

  * [デベロッパー センター ダッシュボードで試験的機能を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
  * [デベロッパー センター ダッシュボードで試験的機能を管理する](manage-your-experiment.md)
  * [A/B テストを使用して最初の試験的機能を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
  * [A/B テストを使用してアプリの試験的機能を実行する](run-app-experiments-with-a-b-testing.md)


<!--HONumber=May16_HO2-->


