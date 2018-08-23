---
author: mcleanbyron
Description: To run an experiment in your Universal Windows Platform (UWP) app with A/B testing, you must code the experiment in your app.
title: アプリの実験用のコードを記述する
ms.assetid: 6A5063E1-28CD-4087-A4FA-FBB511E9CED5
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP、Microsoft Store Services SDK、A/B テスト、実験
ms.localizationpriority: medium
ms.openlocfilehash: b0931d712ca99b429e2aaa7dec4b855f41ce55ef
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2819596"
---
# <a name="code-your-app-for-experimentation"></a>アプリの実験用のコードを記述する

[プロジェクトを作成してデベロッパー センターのダッシュ ボードのリモートの変数を定義](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)後をどこからでも Windows プラットフォーム (UWP) のアプリのコードを更新する準備ができたら。
* Windows デベロッパー センターからリモートの変数値が表示されます。
* ユーザー用のアプリのエクスペリエンスを構成するのにはリモート変数を使用します。
* イベントをユーザーが、実験の表示し、(*変換*とも呼ばれる)、目的の操作を実行することを示すデベロッパー センターにログインします。

アプリには、この動作を追加するには、Microsoft ストア サービス SDK によって提供される Api を使用します。

次のセクションでは、おのバリエーションを取得して、デベロッパー センターへのイベント ログの記録の一般的な手順について説明します。 アプリを使って、コードを記述した後、[デベロッパー センター ダッシュ ボードのテストを定義](define-your-experiment-in-the-dev-center-dashboard.md)できます。 実験の作成および実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

> [!NOTE]
> Microsoft ストア サービス SDK Api 実験の一部は、デベロッパー センターからデータを取得するのに[非同期パターン](../threading-async/asynchronous-programming-universal-windows-platform-apps.md)を使用します。 つまり、これらのメソッドの実行の一部可能性があります場所方法が行われた後、操作が完了するまで、アプリの UI が応答いらようにします。 非同期パターンでは、アプリでは、この記事のコードの例のように、Api、通話する際に**非同期**キーワードと**待機**演算子を使用する必要があります。 規則により、**非同期**の非同期メソッドを終了します。

## <a name="configure-your-project"></a>プロジェクトを構成する

初めに、Microsoft ストア サービス SDK 開発コンピューターにインストールし、[プロジェクトに必要な参照を追加します。

1. [Microsoft Store Services SDK](microsoft-store-services-sdk.md#install-the-sdk) をインストールします。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクト ノードを展開し、**[参照設定]** を右クリックして **[参照の追加]** をクリックします。
3. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
4. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

> [!NOTE]
> この記事のコードの例では、コード ファイルが**System.Threading.Tasks**と**Microsoft.Services.Store.Engagement**名前空間のステートメントを**使用する**と仮定します。

## <a name="get-variation-data-and-log-the-view-event-for-your-experiment"></a>バリエーションのデータを取得して、実験のビューのイベント ログに記録

プロジェクトで、実験を変更する機能のコードを探します。 バリエーションのデータを取得するコードを追加、このデータを使用してテストすると、機能の動作を変更して、a、実験のイベントの表示をログイン/B デベロッパー センターでサービスをテストします。

必要がある特定のコードは、アプリによって異なりますが、次の例では、基本的なプロセス。 完全なコードの例では、次を参照してください。[を作成および実行、最初に試す A B テスト/](create-and-run-your-first-experiment-with-a-b-testing.md)します。

[!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#ExperimentCodeSample)]

次の手順では、このプロセスの詳細の重要な部分について説明します。

1. 現在のバリエーションの割り当てを表す[StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)オブジェクトとデベロッパー センターに表示]、[変換のイベントを記録するのに使用する[StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger)オブジェクトを宣言します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet1)]

2. [プロジェクトの ID](run-app-experiments-with-a-b-testing.md#terms)を取得する実験に割り当てられている文字列変数を宣言します。
    > [!NOTE]
    > プロジェクトを取得する場合に [ID][デベロッパー センターのダッシュ ボードでプロジェクトを作成](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)します。 次に示すプロジェクト ID はのみを目的とたとえばです。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet2)]

3. 静的な[GetCachedVariationAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getcachedvariationasync)メソッドを使用して、実験の現在のキャッシュのバリエーションの割り当てを取得して、メソッド、実験のプロジェクト ID に渡します。 この方法では、 [ExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariationresult.experimentvariation)プロパティを通じてバリエーション割り当てへのアクセスを提供する[StoreServicesExperimentVariationResult](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariationresult)オブジェクトを返します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet3)]

4. キャッシュのバリエーションの割り当てをサーバーからリモート バリエーション割り当てに更新する必要があるかどうか決定する[IsStale](htthttps://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.isstale)プロパティを確認してください。 で、更新する必要がある場合、は、サーバーから更新されたバリエーション割り当てを確認し、ローカル キャッシュ バリエーションを更新する静的[GetRefreshedVariationAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getrefreshedvariationasync)メソッドを呼び出します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet4)]

5. バリエーションの割り当ての値を取得するのにには、 [StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)オブジェクトの[GetBoolean](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getboolean)、 [GetDouble](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getdouble)、 [GetInt32](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getint32)、または[GetString](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring)メソッドを使用します。 どちらの方法で最初のパラメーターが目的のバリエーションを取得するの名前 (デベロッパー センター ダッシュ ボードに入力したバリエーションの同じ名前です)。 2 番目のパラメーターがない場合は (たとえば、ネットワーク接続がない場合)、デベロッパー センターから指定した値を取得する方法を返す必要があるが、既定値は、バリエーションのキャッシュされたバージョン使用します。

    次の例では、 [GetString](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring)を使用して、*アドイン*をという名前の変数を取得し、**灰色] ボタン**の変数の既定値を指定します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet5)]

6. コードでは、テストしている機能の動作を変更するのに変数の値を使用します。 たとえば、次のコードは、アプリのボタンのコンテンツに*アドイン*値を割り当てます。 この例では、定義済みこのボタン別の場所で、プロジェクトにします。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet6)]

7. A、実験の[イベントの表示](run-app-experiments-with-a-b-testing.md#terms)を最後に、ログイン/B デベロッパー センターでサービスをテストします。 初期化、 ```logger``` [StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger)オブジェクトへのフィールドし、 [LogForVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation)メソッドを呼び出します。 現在のバリエーションの割り当て (このオブジェクトは、イベントに関するコンテキスト デベロッパー センター) を表す[StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)オブジェクトを渡すと、実験のイベントの表示の名前。 これは、デベロッパー センターのダッシュ ボードで、実験に入力したビューのイベント名と一致する必要があります。 コード、実験の一部であるバリエーションを表示するユーザーの起動時にイベントの表示をログに記録する必要があります。

    次の例では、イベント**userViewedButton**という名前の表示をログに記録する方法を示します。 この例では、実験の目的でイベントを表示しますが、アプリが、バリエーション データ (この場合は、ボタンのテキスト) を取得し、ボタンのコンテンツへの割り当てがログインしているために、アプリでは、ボタンをクリックするユーザーを取得します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet7)]

## <a name="log-conversion-events-to-dev-center"></a>デベロッパー センターへの変換のイベントを記録します。

次に、[A に[変換のイベント](run-app-experiments-with-a-b-testing.md#terms)を記録するコードを追加/B デベロッパー センターでサービスをテストします。 コードでは、ユーザーが、実験目標に達したときは、変換イベントを記録する必要があります。 必要な特定のコードは、アプリでは、異なりますが、一般的な手順を紹介します。 完全なコードの例では、次を参照してください。[を作成および実行、最初に試す A B テスト/](create-and-run-your-first-experiment-with-a-b-testing.md)します。

1. コードでは、ユーザーが実験の目標の 1 つの目標に達したときに実行される、 [LogForVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation)メソッドをもう一度呼び出すし、 [StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)オブジェクトと、実験の変換のイベントの名前。 これは、デベロッパー センターのダッシュ ボードで、実験に入力した変換イベント名のいずれかに一致する必要があります。

    次の例では、ボタンを**クリックして**イベント ハンドラーから**userClickedButton**という名前の変換のイベントを記録します。 この例では、実験の目的でボタンをクリックするユーザーを取得します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet8)]

## <a name="next-steps"></a>次のステップ

アプリでは、実験をコードが完了したら、次の手順です。
1. [デベロッパー センター ダッシュボードで実験を定義します](define-your-experiment-in-the-dev-center-dashboard.md)。 イベントを表示する、変換イベント、および、1 つの一意のバリエーションを定義する実験を作成する/B をテストします。
2. [デベロッパー センター ダッシュボードで実験を実行および管理します](manage-your-experiment.md)。


## <a name="related-topics"></a>関連トピック

* [プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を管理する](manage-your-experiment.md)
* [A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)
