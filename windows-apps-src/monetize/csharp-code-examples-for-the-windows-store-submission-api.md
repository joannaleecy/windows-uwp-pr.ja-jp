---
author: mcleanbyron
ms.assetid: FABA802F-9CB2-4894-9848-9BB040F9851F
description: "このセクションの C# コード例を使用して、Windows ストア申請 API を使用する方法をご確認ください。"
title: "申請 API 用の C# のコード例"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア申請 API, コード例"
ms.openlocfilehash: 59b9c0b2cc503a56e0a1c9a75ce5ef471983c699
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="c-code-examples-for-the-submission-api"></a>申請 API 用の C\# のコード例

この記事では、*Windows ストア申請 API* を使用するための C# コード例を紹介します。 この API について詳しくは、「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。

ここでは、次のタスクに対応するコード例を示します。

* [アプリの申請の更新](#update-app-submission)
* [新しいアドオンの申請を作成します](#create-add-on-submission)
* [アドオンの申請の更新](#update-add-on-submission)
* [パッケージ フライトの申請の更新](#update-flight-submission)

各例を確認して、それぞれが対応するタスクについて詳しく知ることができます。また、この記事のすべてのコード例を使って、コンソール アプリケーションをビルドすることもできます。 サンプルをビルドするには、Visual Studio で**DeveloperApiCSharpSample** という名前の C# コンソール アプリケーションを作成し、各サンプルをプロジェクトの別のコード ファイルにコピーして、プロジェクトをビルドします。

## <a name="prerequisites"></a>前提条件

以下の例では、次のライブラリを使用します。

* Microsoft.WindowsAzure.Storage.dll。 このライブラリは、[Azure SDK for .NET](https://azure.microsoft.com/downloads/) に含まれています。または [WindowsAzure.Storage NuGetパッケージ](https://www.nuget.org/packages/WindowsAzure.Storage)をインストールすると入手できます。
* Newtonsoft による [Json.NET](http://www.newtonsoft.com/json)。

## <a name="main-program"></a>メイン プログラム

次の例では、コマンド ライン プログラムを実装し、この記事の他の例のメソッドを呼び出して、Windows ストア申請 API を使用する別の方法を示します。 このプログラムを採用するには、次の手順を実行してください。

* ```ApplicationId```、```InAppProductId```、および ```FlightId``` プロパティを、管理するアプリ、アドオン (アドオンは "アプリ内製品"、略して "IAP" とも呼ばれます)、およびパッケージ フライトの ID に割り当てます。 これらの ID はデベロッパー センター ダッシュボードで確認できます。
* ```ClientId``` および ```ClientSecret``` プロパティをアプリのクライアント ID とキーに割り当て、```TokenEndpoint``` URL 内の文字列 *tenantid* をアプリのテナント ID に置き換えます。 詳しくは、[Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付ける方法](create-and-manage-submissions-using-windows-store-services.md#how-to-associate-an-azure-ad-application-with-your-windows-dev-center-account)をご覧ください。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/Program.cs#Main)]

<span id="clientconfiguration" />
## <a name="clientconfiguration-helper-class"></a>ClientConfiguration ヘルパー クラス

サンプル アプリでは ```ClientConfiguration``` ヘルパー クラスを使用して、Azure Active Directory データとアプリ データを Windows ストア申請 API を使用する各サンプル メソッドに渡しています。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/ClientConfiguration.cs#ClientConfiguration)]

<span id="update-app-submission" />
## <a name="update-an-app-submission"></a>アプリの申請の更新

次の例は、Windows ストア申請 API のいくつかのメソッドを使用するクラスを実装して、アプリの申請を更新する方法を示しています。 クラスの ```RunAppSubmissionUpdateSample``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。 具体的には、```RunAppSubmissionUpdateSample``` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたアプリのデータを取得](get-an-app.md)します。
2. 次に、[アプリの保留中の申請を削除](delete-an-app-submission.md)します (存在する場合)。
3. その後、[アプリの新しい申請を作成](create-an-app-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
4. 新しい申請の詳細を変更し、申請の新しいパッケージを Azure Blob Storage にアップロードします。
5. 次に、新しい申請を[更新](update-an-app-submission.md)してから Windows デベロッパー センターに[コミット](commit-an-app-submission.md)します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-app-submission.md)します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/AppSubmissionUpdateSample.cs#AppSubmissionUpdateSample)]

<span id="create-add-on-submission" />
## <a name="create-a-new-add-on-submission"></a>新しいアドオンの申請を作成します

次の例は、Windows ストア申請 API のいくつかのメソッドを使用するクラスを実装して、新しいアドオンの申請を作成する方法を示しています。 クラスの ```RunInAppProductSubmissionCreateSample``` メソッドは、次のタスクを実行します。

1. まず、メソッドは[新しアドオンを作成](create-an-add-on.md)します。
2. 次に、その[アドオンの新しい申請を作成](create-an-add-on-submission.md)します。
3. 申請のアイコンが含まれた ZIP アーカイブを Azure Blob Storage にアップロードします。
4. 次に、[Windows デベロッパー センターに新しい申請をコミット](commit-an-add-on-submission.md)します。
5. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-add-on-submission.md)します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/InAppProductSubmissionCreateSample.cs#InAppProductSubmissionCreateSample)]

<span id="update-add-on-submission" />
## <a name="update-an-add-on-submission"></a>アドオンの申請の更新

次の例は、Windows ストア申請 API のいくつかのメソッドを使用するクラスを実装して、既存のアドオンの申請を更新する方法を示しています。 クラスの ```RunInAppProductSubmissionUpdateSample``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。 具体的には、```RunInAppProductSubmissionUpdateSample``` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたアドオンのデータを取得](get-an-add-on.md)します。
2. 次に、[アドオンの保留中の申請を削除](delete-an-add-on-submission.md)します (存在する場合)。
3. その後、[アドオンの新しい申請を作成](create-an-add-on-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
5. 次に、新しい申請を[更新](update-an-add-on-submission.md)してから Windows デベロッパー センターに[コミット](commit-an-add-on-submission.md)します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-add-on-submission.md)します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/InAppProductSubmissionUpdateSample.cs#InAppProductSubmissionUpdateSample)]

<span id="update-flight-submission" />
## <a name="update-a-package-flight-submission"></a>パッケージ フライトの申請の更新

次の例は、Windows ストア申請 API のいくつかのメソッドを使用するクラスを実装して、パッケージ フライトの申請を更新する方法を示しています。 クラスの ```RunFlightSubmissionUpdateSample``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。 具体的には、```RunFlightSubmissionUpdateSample``` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたパッケージ フライトのデータを取得](get-a-flight.md)します。
2. 次に、[パッケージ フライトの保留中の申請を削除](delete-a-flight-submission.md)します (存在する場合)。
3. その後、[パッケージ フライトの新しい申請を作成](create-a-flight-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
4. 申請の新しいパッケージを Azure Blob Storage にアップロードします。
5. 次に、新しい申請を[更新](update-a-flight-submission.md)してから Windows デベロッパー センターに[コミット](commit-a-flight-submission.md)します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-a-flight-submission.md)します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/FlightSubmissionUpdateSample.cs#FlightSubmissionUpdateSample)]

<span id="ingestionclient" />
## <a name="ingestionclient-helper-class"></a>IngestionClient ヘルパー クラス

```IngestionClient``` クラスは、サンプル アプリのその他のメソッドが使用して、次のタスクを実行するヘルパー メソッドを提供します。

* Windows ストア申請 API のメソッドの呼び出しに使用できる [Azure AD アクセストークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)します。 トークンを取得した後、Windows ストア申請 API への呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
* アプリまたはアドオンの申請の新しいアセットが含まれた ZIP アーカイブを Azure Blob Storage にアップロードします。 アプリとアドオンの申請のために Azure Blob Storage に ZIP アーカイブをアップロードする方法について詳しくは、「[アプリの申請の作成](manage-app-submissions.md#create-an-app-submission)」と「[アドオンの申請の作成](manage-add-on-submissions.md#create-an-add-on-submission)」の関連する手順をご覧ください。
* Windows ストア申請 API の HTTP 要求を処理します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[SubmissionApi](./code/StoreServicesExamples_Submission/cs/IngestionClient.cs#IngestionClient)]

## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
