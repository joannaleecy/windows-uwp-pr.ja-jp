---
Description: ユニバーサル Windows プラットフォーム (UWP) アプリで A/B テストを実行するには、アプリで実験用のコードを記述する必要があります。
title: アプリの実験用のコードを記述する
ms.assetid: 6A5063E1-28CD-4087-A4FA-FBB511E9CED5
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store Services SDK, A/B テスト, 実験
ms.localizationpriority: medium
ms.openlocfilehash: 2e00c3f8d7f1f41d6b44743ebb663b09575fb21a
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58334950"
---
# <a name="code-your-app-for-experimentation"></a>アプリの実験用のコードを記述する

したら[プロジェクトを作成し、パートナー センターでリモート変数定義](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)をユニバーサル Windows プラットフォーム (UWP) アプリにコードを更新する準備が整いました。
* パートナー センターからリモート変数の値を受信します。
* リモート変数を使用して、ユーザーのアプリ エクスペリエンスを構成する。
* パートナー センターのユーザーが、実験の表示や、必要な操作を実行を示すイベントを記録 (とも呼ばれる、*変換*)。

この動作をアプリに追加するには、Microsoft Store Services SDK によって提供される API を使用します。

次のセクションでは、実験のバリエーションを取得して、パートナー センターにイベントをログ記録の一般的なプロセスについて説明します。 後に実験用のアプリをコーディングする[パートナー センターで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)します。 実験の作成と実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

> [!NOTE]
> 実験では、Microsoft Store Services SDK の Api の一部を使用して、[の非同期パターン](../threading-async/asynchronous-programming-universal-windows-platform-apps.md)パートナー センターからデータを取得します。 これは、これらのメソッドの一部が、メソッドが呼び出された後に実行されることを意味し、アプリの UI は、操作が完了するまでの間、高い応答性を維持できます。 この記事のコード例に示すように、非同期パターンでは、アプリで API を呼び出すときに、**async** キーワードと **await** 演算子を使用する必要があります。 慣例により、非同期メソッドの末尾には **Async** が付きます。

## <a name="configure-your-project"></a>プロジェクトを構成する

最初に、Microsoft Store Services SDK を開発用コンピューターにインストールして、プロジェクトに必要な参照を追加します。

1. [Microsoft Store Services SDK](microsoft-store-services-sdk.md#install-the-sdk) をインストールします。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクト ノードを展開し、**[参照設定]** を右クリックして **[参照の追加]** をクリックします。
3. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
4. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

> [!NOTE]
> この記事のコード例では、コード ファイルに **System.Threading.Tasks** 名前空間と **Microsoft.Services.Store.Engagement** 名前空間の **using** ステートメントがあることを前提としています。

## <a name="get-variation-data-and-log-the-view-event-for-your-experiment"></a>バリエーション データを取得し、実験のビュー イベントをログに記録する

プロジェクトで、試験的機能の実行において変更する機能のコードを探します。 バリエーションの 1 つのデータを取得するコードを追加、このデータを使用してテストすると、機能の動作を変更して、A に、実験用のビュー イベントをログ B は、パートナー センターでサービスをテストします。

必要な特定のコードは、アプリによって異なりますが、次の例は基本的なプロセスを示しています。 完全なコード例については、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

[!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#ExperimentCodeSample)]

次の手順では、このプロセスの重要な部分について詳しく説明します。

1. 宣言を[StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation) 、現在のバリエーションの 1 つの割り当てを表すオブジェクトを[StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger)ログの表示と変換に使用するオブジェクトパートナー センターのイベント。

    [!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet1)]

2. 取得する実験の[プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms) に割り当てられる文字列変数を宣言します。
    > [!NOTE]
    > プロジェクトを取得するときに ID を[パートナー センターでプロジェクトを作成](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)です。 次に示すプロジェクト ID は例示のためのものです。

    [!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet2)]

3. 静的な [GetCachedVariationAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getcachedvariationasync) メソッドを呼び出して、実験に対するキャッシュされた現在のバリエーションの割り当てを取得し、実験のプロジェクト ID をそのメソッドに渡します。 このメソッドは、[ExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariationresult.experimentvariation) プロパティを使用してバリエーションの割り当てへのアクセスを提供する [StoreServicesExperimentVariationResult](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariationresult) オブジェクトを返します。

    [!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet3)]

4. [IsStale](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.isstale) プロパティを確認して、キャッシュされたバリエーションの割り当てを、サーバーからリモートのバリエーションの割り当てによって更新する必要があるかどうかを判断します。 更新する必要がある場合は、静的な [GetRefreshedVariationAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getrefreshedvariationasync) メソッドを呼び出して、サーバーから更新されたバリエーションの割り当てを確認し、ローカルでキャッシュされたバリエーションを更新します。

    [!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet4)]

5. [StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation) オブジェクトの [GetBoolean](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getboolean)、[GetDouble](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getdouble)、[GetInt32](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getint32)、または [GetString](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring) の各メソッドを使用して、バリエーションの割り当ての値を取得します。 各メソッドで最初のパラメーターは、バリエーションを取得するの名前 (これはバリエーションの 1 つで、パートナー センターで入力したのと同じ名前です)。 2 番目のパラメーターがない (たとえば、ネットワーク接続がない場合)、パートナー センターから、指定した値を取得できない場合にメソッドが返す既定値と、バリエーションの 1 つのキャッシュされたバージョンをご利用いただけません。

    次の例では、[GetString](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring) を使用して、*buttonText* という名前の変数を取得し、**Grey Button** の既定の変数値を指定します。

    [!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet5)]

6. コードで、変数値を使用して、テストする機能の動作を変更します。 たとえば、次のコードでは *buttonText* 値を、アプリ内のボタンのコンテンツに割り当てます。 この例では、プロジェクト内の別の場所で既にこのボタンを定義していることを前提としています。

    [!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet6)]

7. 最後に、ログ、[ビュー イベント](run-app-experiments-with-a-b-testing.md#terms)実験、A に B は、パートナー センターでサービスをテストします。 ```logger``` フィールドを [StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger) オブジェクトに初期化し、[LogForVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation) メソッドを呼び出します。 渡す、 [StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation) (このオブジェクトは、イベントに関するコンテキストをパートナー センターに提供します)、現在のバリエーションの 1 つの割り当てと、実験のビュー イベントの名前を表すオブジェクトします。 これは、パートナー センターでの実験用に入力したビューのイベント名と一致する必要があります。 コードでは、実験の一部であるバリエーションをユーザーが最初に表示するタイミングを示すビュー イベントをログに記録する必要があります。

    次の例では、**userViewedButton** という名前のビュー イベントをログに記録する方法を示します。 この例では、実験の目的は、ユーザーにアプリ内のボタンをクリックさせることであるため、ビュー イベントは、アプリがバリエーション データ (この場合、ボタンのテキスト) を取得し、それをボタンのコンテンツに割り当てた後にログに記録されます。

    [!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet7)]

## <a name="log-conversion-events-to-partner-center"></a>変換イベントをパートナー センターにログインします。

次に、ログに記録するコードを追加[変換イベント](run-app-experiments-with-a-b-testing.md#terms)A を B は、パートナー センターでサービスをテストします。 コードでは、ユーザーが実験の目標に達したときに、コンバージョン イベントのログを記録する必要があります。 必要なコードはアプリによって異なりますが、ここでは一般的な手順を示します。 完全なコード例については、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

1. 実験のいずれかのゴールの目的をユーザーが達成した場合に実行するコードで、[LogForVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation) メソッドをもう一度呼び出して、[StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation) オブジェクトと実験のコンバージョン イベントの名前を渡します。 これは、パートナー センターでの実験用に入力した変換イベント名のいずれかに一致しなければなりません。

    次の例では、ボタンの **Click** イベント ハンドラーから **userClickedButton** という名前のコンバージョン イベントをログに記録します。 この例では、実験の目的は、ユーザーにボタンをクリックさせることです。

    [!code-csharp[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet8)]

## <a name="next-steps"></a>次のステップ

アプリの実験用のコードを記述したら、次の手順に進むことができます。
1. [パートナー センターで、実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)します。 ビュー イベント、コンバージョン イベント、A/B テストの一意のバリエーションを定義する実験を作成します。
2. [実行し、パートナー センターで実験を管理](manage-your-experiment.md)します。


## <a name="related-topics"></a>関連トピック

* [プロジェクトを作成し、パートナー センターでのリモート変数の定義](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [パートナー センターでの実験を定義します。](define-your-experiment-in-the-dev-center-dashboard.md)
* [パートナー センターで、実験を管理します。](manage-your-experiment.md)
* [作成し、A で初めての実験を実行する B のテスト](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A とアプリの実験を実行する B のテスト](run-app-experiments-with-a-b-testing.md)
