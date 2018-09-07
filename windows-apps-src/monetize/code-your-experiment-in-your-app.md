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
ms.sourcegitcommit: 53ba430930ecec8ea10c95b390fe6e654fe363e1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3422373"
---
# <a name="code-your-app-for-experimentation"></a>アプリの実験用のコードを記述する

[プロジェクトを作成しデベロッパー センター ダッシュ ボードでリモート変数を定義する](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)の後にユニバーサル Windows プラットフォーム (UWP) アプリでコードを更新する準備ができたら。
* Windows デベロッパー センターからリモート変数値を受信します。
* リモート変数を使用して、ユーザー向けのアプリのエクスペリエンスを構成します。
* デベロッパー センターを示すユーザーの実験を表示および (*変換*とも呼ばれます) 目的のアクションを実行したときにイベント ログに記録します。

この動作をアプリに追加するには、Microsoft Store Services SDK によって提供される Api を使用します。

次のセクションでは、実験のバリエーションを取得し、デベロッパー センターにイベント ログに記録する一般的なプロセスについて説明します。 実験用のアプリのコード、したら[、デベロッパー センター ダッシュ ボードで実験を定義](define-your-experiment-in-the-dev-center-dashboard.md)できます。 実験の作成および実行のプロセスについて詳しく示すチュートリアルについては、「[A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

> [!NOTE]
> 実験で、Microsoft Store Services SDK Api の一部は、デベロッパー センターからデータを取得するのに、[非同期パターン](../threading-async/asynchronous-programming-universal-windows-platform-apps.md)を使用します。 これは、これらのメソッドの実行の一部が有効になること、メソッドが呼び出されると後、ので、アプリの UI は、操作が完了するまで、応答性の高いままを意味します。 非同期パターンでは、この記事のコード例で示されているように、Api を呼び出すと、**非同期**キーワードと**await**演算子を使用するアプリが必要です。 慣例により、非同期メソッドが**非同期**で終了します。

## <a name="configure-your-project"></a>プロジェクトを構成する

最初に、開発用コンピューターで、Microsoft Store Services SDK をインストールし、必要に応じて、プロジェクトに参照を追加します。

1. [Microsoft Store Services SDK](microsoft-store-services-sdk.md#install-the-sdk) をインストールします。
2. Visual Studio でプロジェクトを開きます。
3. ソリューション エクスプローラーで、プロジェクト ノードを展開し、**[参照設定]** を右クリックして **[参照の追加]** をクリックします。
3. **[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。
4. SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。

> [!NOTE]
> この記事のコード例では、 **System.Threading.Tasks** **Microsoft.Services.Store.Engagement**名前空間の**using**ステートメントをコード ファイルであることを前提としています。

## <a name="get-variation-data-and-log-the-view-event-for-your-experiment"></a>バリエーション データを取得して、実験のビュー イベントの記録

プロジェクトで実験で変更する機能のコードを見つけます。 バリエーション データを取得するコードを追加、このデータを使用して、テストしている機能の動作を変更し、し、実験のビュー イベントをログ B は、デベロッパー センターでサービスをテストします。

必要な特定のコードは、アプリによって異なりますが、次の例は、基本的なプロセスを示しています。 完全なコード例については[を作成および実行を使用して最初の実験 B テスト](create-and-run-your-first-experiment-with-a-b-testing.md)します。

[!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#ExperimentCodeSample)]

次の手順では、このプロセスの詳細の重要な部分について説明します。

1. 現在のバリエーションの割り当てを表す[StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)オブジェクトとデベロッパー センターにビューとコンバージョン イベントを記録するために使用する[StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger)オブジェクトを宣言します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet1)]

2. [プロジェクト ID](run-app-experiments-with-a-b-testing.md#terms)を取得する実験用に割り当てられている文字列変数を宣言します。
    > [!NOTE]
    > プロジェクトを取得するタイミングを ID [、デベロッパー センター ダッシュ ボードでプロジェクトを作成](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)します。 次に示すプロジェクト ID が目的でのみではたとえばです。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet2)]

3. 静的[GetCachedVariationAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getcachedvariationasync)メソッドを呼び出すことによって、実験の現在のキャッシュされたバリエーションの割り当てを取得し、実験のプロジェクト ID をメソッドに渡します。 このメソッドは、 [ExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariationresult.experimentvariation)プロパティを使ってバリエーションの割り当てへのアクセスを提供する[StoreServicesExperimentVariationResult](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariationresult)オブジェクトを返します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet3)]

4. キャッシュされたバリエーションの割り当てをサーバーからリモートのバリエーションの割り当てを更新する必要があるかどうかを判断する[IsStale](htthttps://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.isstale)プロパティを確認します。 更新する必要が場合、は、サーバーから更新されたバリエーションの割り当ての確認、ローカルにキャッシュされたバリエーションを更新する静的[GetRefreshedVariationAsync](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getrefreshedvariationasync)メソッドを呼び出します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet4)]

5. バリエーションの割り当ての値を取得するには、 [GetBoolean](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getboolean)、 [GetDouble](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getdouble)、 [GetInt32](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getint32)、または[GetString](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring) [StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)オブジェクトのメソッドを使います。 各メソッドの最初のパラメーターを取得するのバリエーションの名前 (これは、デベロッパー センター ダッシュ ボードで入力するバリエーションの同じ名前です)。 2 番目のパラメーターは、既定値 (たとえば、ネットワーク接続がない場合)、デベロッパー センターから指定された値を取得することはない場合、メソッドを返す必要がありますバリエーションのキャッシュされたバージョンが利用できません。

    次の例では、 [GetString](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation.getstring)を使用して、 *[buttonText*という名前の変数を取得し、 **Grey Button**の既定の変数値を指定します。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet5)]

6. コードで、変数の値を使用して、テストしている機能の動作を変更します。 たとえば、次のコードは、アプリ内のボタンのコンテンツに *[buttonText*値を割り当てます。 この例では、別の場所はプロジェクトで既にこのボタンを定義したが前提としています。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet6)]

7. 最後に、実験の[ビュー イベント](run-app-experiments-with-a-b-testing.md#terms)を A にログイン B は、デベロッパー センターでサービスをテストします。 初期化、 ```logger``` [StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger)オブジェクトにフィールドし、 [LogForVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation)メソッドを呼び出します。 現在のバリエーションの割り当て (このオブジェクトは、デベロッパー センターに、イベントに関するコンテキストを提供) を表す[StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)オブジェクトを渡すと、実験のビュー イベントの名前。 これは、は、デベロッパー センター ダッシュ ボードで実験用に入力するビュー イベント名と一致する必要があります。 コードには、バリエーション実験の一部である、ユーザーが開始するときにビュー イベントを記録する必要があります。

    次の例では、 **userViewedButton**という名前のビュー イベント ログに記録する方法を示します。 この例では、実験の目標は、ビュー イベントは、アプリが (この場合は、ボタンのテキスト) で、バリエーション データを取得し、ボタンのコンテンツへの割り当てが後に記録するために、アプリでボタンをクリックするユーザーを取得するのにです。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet7)]

## <a name="log-conversion-events-to-dev-center"></a>コンバージョン イベントをデベロッパー センターにログインします。

A[コンバージョン イベント](run-app-experiments-with-a-b-testing.md#terms)をログに記録するコードを次に、追加 B は、デベロッパー センターでサービスをテストします。 コードでは、ユーザーが実験の目標に達したときは、コンバージョン イベントを記録する必要があります。 必要な特定のコードは、アプリによって異なりますが、一般的な手順を以下に示します。 完全なコード例については[を作成および実行を使用して最初の実験 B テスト](create-and-run-your-first-experiment-with-a-b-testing.md)します。

1. ユーザーが、実験の目標の 1 つの目標に達したときに実行されるコードでは、もう一度[LogForVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation)メソッドを呼び出すし、 [StoreServicesExperimentVariation](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicesexperimentvariation)オブジェクトと、実験のコンバージョン イベントの名前を渡します。 これは、デベロッパー センター ダッシュ ボードで実験用に入力するコンバージョン イベント名のいずれかに一致する必要があります。

    次の例では、ボタンの**Click**イベント ハンドラーから**userclickedbutton」という入力**をという名前のコンバージョン イベントを記録します。 この例では、実験の目標は、ボタンをクリックするユーザーを取得するのにです。

    [!code-cs[ExperimentExamples](./code/StoreSDKSamples/cs/ExperimentExamples.cs#Snippet8)]

## <a name="next-steps"></a>次のステップ

アプリで、実験のコード、したら、次の手順。
1. [デベロッパー センター ダッシュボードで実験を定義します](define-your-experiment-in-the-dev-center-dashboard.md)。 イベントの表示、コンバージョン イベント、および、1 つの一意のバリエーションを定義する実験を作成/B をテストします。
2. [デベロッパー センター ダッシュボードで実験を実行および管理します](manage-your-experiment.md)。


## <a name="related-topics"></a>関連トピック

* [プロジェクトを作成し、デベロッパー センター ダッシュボードでリモート変数を定義する](create-a-project-and-define-remote-variables-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [デベロッパー センター ダッシュボードで実験を管理する](manage-your-experiment.md)
* [A/B テストを使用して最初の実験を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)
* [A/B テストを使用してアプリの実験を実行する](run-app-experiments-with-a-b-testing.md)
