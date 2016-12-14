---
author: mcleanbyron
Description: "ユニバーサル Windows プラットフォーム (UWP) アプリで A/B テストを実行するには、アプリで実験用のコードを記述する必要があります。"
title: "アプリの実験用のコードを記述する"
ms.assetid: 6A5063E1-28CD-4087-A4FA-FBB511E9CED5
translationtype: Human Translation
ms.sourcegitcommit: ffda100344b1264c18b93f096d8061570dd8edee
ms.openlocfilehash: cc32e2688bce636e1f4bda02aade4ed1d94f3e28

---

# <a name="code-your-app-for-experimentation"></a>アプリの実験用のコードを記述する

[デベロッパー センター ダッシュボードでプロジェクトを作成し、リモート変数を定義](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)した後、ユニバーサル Windows プラットフォーム (UWP) アプリでコードを更新して、次の操作を行うことができます。
* Windows デベロッパー センターでリモート変数値を受け取る。
* リモート変数を使用して、ユーザーのアプリ エクスペリエンスを構成する。
* ユーザーが実験を表示し、必要なアクションを実行 ("*コンバージョン*" とも呼ばれます) したタイミングを示すイベントのログを、デベロッパー センターに記録する。

この動作をアプリに追加するには、Microsoft Store Services SDK によって提供される API を使用します。

以降のセクションでは、実験のバリエーションを取得し、デベロッパー センターでイベントをログに記録するための一般的なプロセスについて説明します。 アプリの実験用のコードを記述すると、[デベロッパー センター ダッシュボードで実験を定義](define-your-experiment-in-the-dev-center-dashboard.md)できます。 実験の作成および実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

>**注:**&nbsp;&nbsp;Windows Store Services SDK に含まれる一部の実験 API は、[非同期パターン](../threading-async/asynchronous-programming-universal-windows-platform-apps.md)を使用してデベロッパー センターからデータを取得します。 これは、これらのメソッドの一部が、メソッドが呼び出された後に実行されることを意味し、アプリの UI は、操作が完了するまでの間、高い応答性を維持できます。 この記事のコード例に示すように、非同期パターンでは、アプリで API を呼び出すときに、**async** キーワードと **await** 演算子を使用する必要があります。 慣例により、非同期メソッドの末尾には **Async** が付きます。

## <a name="configure-your-project"></a>プロジェクトを構成する

最初に、Microsoft Store Services SDK を開発用コンピューターにインストールして、プロジェクトに必要な参照を追加します。

1. [Microsoft Store Services SDK](microsoft-store-services-sdk.md#install-the-sdk) をインストールします。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクト ノードを展開し、**[参照設定]** を右クリックして **[参照の追加]** をクリックします。
3. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
4. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

>**注:**&nbsp;&nbsp;この記事のコード例では、コード ファイルに **System.Threading.Tasks** 名前空間と **Microsoft.Services.Store.Engagement** 名前空間の **using** ステートメントがあることを前提としています。

## <a name="get-variation-data-and-log-the-view-event-for-your-experiment"></a>バリエーション データを取得し、実験のビュー イベントをログに記録する

プロジェクト内で、実験で変更する機能のコードを探します。 バリエーションのデータを取得するコードを追加し、このデータを使用して、テストしている機能の動作を変更します。次に、実験のビュー イベントのログを、デベロッパー センターの A/B テスト サービスに記録します。

必要な特定のコードは、アプリによって異なりますが、次の例は基本的なプロセスを示しています。 完全なコード例については、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

> [!div class="tabbedCodeSnippets"]
[!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#ExperimentCodeSample)]

次の手順では、このプロセスの重要な部分について詳しく説明します。

1. 現在のバリエーションの割り当てを表す [StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) オブジェクトと、ビュー イベントとコンバージョン イベントのログをデベロッパー センターに記録するときに使用する [StoreServicesCustomEventLogger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.aspx) オブジェクトを宣言します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet1)]

1. 取得する実験の[プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms) に割り当てられる文字列変数を宣言します。
  >**注:**&nbsp;&nbsp;[デベロッパー センター ダッシュボードでプロジェクトを作成](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)するときに、プロジェクト ID を取得します。 次に示すプロジェクト ID は例示のためのものです。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet2)]

2. 静的な [GetCachedVariationAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getcachedvariationasync.aspx) メソッドを呼び出して、実験に対するキャッシュされた現在のバリエーションの割り当てを取得し、実験のプロジェクト ID をそのメソッドに渡します。 このメソッドは、[ExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariationresult.experimentvariation.aspx) プロパティを使用してバリエーションの割り当てへのアクセスを提供する [StoreServicesExperimentVariationResult](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariationresult.aspx) オブジェクトを返します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet3)]

4. [IsStale](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.isstale.aspx) プロパティを確認して、キャッシュされたバリエーションの割り当てを、サーバーからリモートのバリエーションの割り当てによって更新する必要があるかどうかを判断します。 更新する必要がある場合は、静的な [GetRefreshedVariationAsync](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getrefreshedvariationasync.aspx) メソッドを呼び出して、サーバーから更新されたバリエーションの割り当てを確認し、ローカルでキャッシュされたバリエーションを更新します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet4)]

5. [StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) オブジェクトの [GetBoolean](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getboolean.aspx)、[GetDouble](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getdouble.aspx)、[GetInt32](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getint32.aspx)、または [GetString](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring.aspx) の各メソッドを使用して、バリエーションの割り当ての値を取得します。 各メソッドの最初のパラメーターは、取得する設定のバリエーションの名前 (デベロッパー センター ダッシュボードで入力するバリエーションと同じ名前) です。 2 番目のパラメーターは、デベロッパー センターから指定された値を取得できない場合 (たとえば、ネットワークから切断されている場合) やキャッシュされたバージョンのバリエーションを利用できない場合にメソッドが返す必要のある既定値です。

  次の例では、[GetString](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring.aspx) を使用して、*buttonText* という名前の変数を取得し、**Grey Button** の既定の変数値を指定します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet5)]

4. コードで、変数値を使用して、テストする機能の動作を変更します。 たとえば、次のコードでは *buttonText* 値を、アプリ内のボタンのコンテンツに割り当てます。 この例では、プロジェクト内の別の場所で既にこのボタンを定義していることを前提としています。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet6)]

5. 最後に、実験の[ビュー イベント](run-app-experiments-with-a-b-testing.md#terms)のログをデベロッパー センターの A/B テスト サービスに記録します。 ```logger``` フィールドを [StoreServicesCustomEventLogger](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.aspx) オブジェクトに初期化し、[LogForVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation.aspx) メソッドを呼び出します。 現在のバリエーションの割り当てを表す [StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) オブジェクト (このオブジェクトはイベントに関するコンテキストをデベロッパー センターに提供します) と、実験のビュー イベントの名前を渡します。 これは、デベロッパー センター ダッシュ ボードで実験について入力したビュー イベント名と一致している必要があります。 コードでは、実験の一部であるバリエーションをユーザーが最初に表示するタイミングを示すビュー イベントをログに記録する必要があります。

  次の例では、**userViewedButton** という名前のビュー イベントをログに記録する方法を示します。 この例では、実験の目的は、ユーザーにアプリ内のボタンをクリックさせることであるため、ビュー イベントは、アプリがバリエーション データ (この場合、ボタンのテキスト) を取得し、それをボタンのコンテンツに割り当てた後にログに記録されます。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet7)]

## <a name="log-conversion-events-to-dev-center"></a>コンバージョン イベントのログをデベロッパー センターに記録する

次に、[コンバージョン イベント](run-app-experiments-with-a-b-testing.md#terms)のログをデベロッパー センターの A/B テスト サービスに記録するコードを追加します。 コードでは、ユーザーが実験の目標に達したときに、コンバージョン イベントのログを記録する必要があります。 必要なコードはアプリによって異なりますが、ここでは一般的な手順を示します。 完全なコード例については、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

1. 試験的機能のいずれかのゴールの目的をユーザーが達成した場合に実行するコードで、[LogForVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation.aspx) メソッドをもう一度呼び出して、[StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) オブジェクトと実験のコンバージョン イベントの名前を渡します。 これは、デベロッパー センター ダッシュ ボードで実験について入力したコンバージョン イベント名のいずれかと一致している必要があります。

  次の例では、ボタンの **Click** イベント ハンドラーから **userClickedButton** という名前のコンバージョン イベントをログに記録します。 この例では、実験の目的は、ユーザーにボタンをクリックさせることです。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet8)]

## <a name="next-steps"></a>次の手順

アプリの実験用のコードを記述したら、次の手順に進むことができます。
1. [デベロッパー センター ダッシュボードで実験を定義します](define-your-experiment-in-the-dev-center-dashboard.md)。 ビュー イベント、コンバージョン イベント、A/B テストの一意のバリエーションを定義する実験を作成します。
2. [デベロッパー センター ダッシュボードで実験を実行および管理します](manage-your-experiment.md)。


## <a name="related-topics"></a>関連トピック

* [プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を管理する](manage-your-experiment.md)
* [A/B テストを使用して最初の試験的機能を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)



<!--HONumber=Dec16_HO1-->


