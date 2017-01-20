---
author: mcleanbyron
ms.assetid: 4920D262-B810-409E-BA3A-F68AADF1B1BC
description: "このセクションの Java コード例を使用して、Windows ストア申請 API を使用する方法をご確認ください。"
title: "Windows ストア申請 API の Java コード例"
translationtype: Human Translation
ms.sourcegitcommit: ccc7cfea885cc9c8803cfc70d2e043192a7fee84
ms.openlocfilehash: 7f7de7c7d9fa9131d38da48e13ce449f4440962d

---

# <a name="java-code-examples-for-the-windows-store-submission-api"></a>Windows ストア申請 API の Java コード例

この記事では、*Windows ストア申請 API* を使用するための Java コード例を紹介します。 この API について詳しくは、｢[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)｣をご覧ください。

ここでは、次のタスクに対応するコード例を示します。

* [Azure AD アクセス トークンの取得](#token)
* [アドオンの作成](#create-add-on)
* [パッケージ フライトの作成](#create-package-flight)
* [アプリの申請の作成](#create-app-submission)
* [アドオンの申請の作成](#create-add-on-submission)
* [パッケージ フライトの申請の作成](#create-flight-submission)

各例を確認して、それぞれが対応するタスクについて詳しく知ることができます。また、この記事のすべてのコード例を使って、コンソール アプリケーションをビルドすることもできます。 完全なコードについては、この記事の最後の「[完全なコード](java-code-examples-for-the-windows-store-submission-api.md#code-listing)」のセクションをご覧ください。

## <a name="prerequisites"></a>前提条件

以下の例では、次のライブラリを使用します。

* [Apache Commons Logging 1.2](http://commons.apache.org/proper/commons-logging)  (commons-logging-1.2.jar)。
* [Apache HttpComponents Core 4.4.5 および Apache HttpComponents Client 4.5.2](https://hc.apache.org/) (httpcore-4.4.5.jar and httpclient-4.5.2.jar)。
* [JSR 353 JSON Processing API 1.0](https://mvnrepository.com/artifact/javax.json/javax.json-api/1.0) および [JSR 353 JSON Processing Default Provider API 1.0.4](https://mvnrepository.com/artifact/org.glassfish/javax.json/1.0.4) (javax.json-api-1.0.jar and javax.json-1.0.4.jar)。

## <a name="main-program-and-imports"></a>メイン プログラムとインポート

次の例は、この記事のすべてのコード例で使用されている import ステートメントを示しています。このコード例によって、他のメソッドの例を呼び出すコマンド ライン プログラムが実装されます。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/MainExample.java#L1-L64)]

<span id="token" />
## <a name="obtain-an-azure-ad-access-token"></a>Azure AD アクセス トークンの取得

次の例は、Windows ストア申請 API のメソッドを呼び出すために使用できる [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)する方法を示しています。 トークンを取得した後、Windows ストア申請 API への呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L65-L95)]

<span id="create-add-on" />
## <a name="create-an-add-on"></a>アドオンの作成

次の例は、アドオンを[作成](create-an-add-on.md)してから[削除](delete-an-add-on.md)する方法を示しています (アドオンは "アプリ内製品"、略して "IAP" とも呼ばれます)。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L310-L345)]

<span id="create-package-flight" />
## <a name="create-a-package-flight"></a>パッケージ フライトの作成

次の例は、パッケージ フライトを[作成](create-a-flight.md)してから[削除](delete-a-flight.md)する方法を示しています。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L185-L221)]

<span id="create-app-submission" />
## <a name="create-an-app-submission"></a>アプリの申請の作成

次の例は、Windows ストア申請 API のいくつかのメソッドを使用して、アプリの申請を作成する方法を示しています。 これを行うために、```SubmitNewApplicationSubmission``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。 具体的には、```SubmitNewApplicationSubmission``` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたアプリのデータを取得](get-an-app.md)します。
2. 次に、[アプリの保留中の申請を削除](delete-an-app-submission.md)します (存在する場合)。
3. その後、[アプリの新しい申請を作成](create-an-app-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
4. 新しい申請の詳細を変更し、申請の新しいパッケージを Azure Blob Storage にアップロードします。
5. 次に、新しい申請を[更新](update-an-app-submission.md)してから Windows デベロッパー センターに[コミット](commit-an-app-submission.md)します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-app-submission.md)します。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L97-L183)]

<span id="create-add-on-submission" />
## <a name="create-an-add-on-submission"></a>アドオンの申請の作成

次の例は、Windows ストア申請 API のいくつかのメソッドを使用して、アドオンの申請を作成する方法を示しています。 これを行うために、```SubmitNewInAppProductSubmission``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。 具体的には、```SubmitNewInAppProductSubmission``` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたアドオンのデータを取得](get-an-add-on.md)します。
2. 次に、[アドオンの保留中の申請を削除](delete-an-add-on-submission.md)します (存在する場合)。
3. その後、[アドオンの新しい申請を作成](create-an-add-on-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
4. 申請のアイコンが含まれた ZIP アーカイブを Azure Blob Storage にアップロードします。
5. 次に、新しい申請を[更新](update-an-add-on-submission.md)してから Windows デベロッパー センターに[コミット](commit-an-add-on-submission.md)します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-add-on-submission.md)します。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L347-L431)]

<span id="create-flight-submission" />
## <a name="create-a-package-flight-submission"></a>パッケージ フライトの申請の作成

次の例は、Windows ストア申請 API のいくつかのメソッドを使用して、パッケージ フライトの申請を作成する方法を示しています。 これを行うために、```SubmitNewFlightSubmission``` メソッドは、新しい申請を最後に公開された申請の複製として作成し、複製された申請を更新して Windows デベロッパー センターにコミットします。 具体的には、```SubmitNewFlightSubmission``` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたパッケージ フライトのデータを取得](get-a-flight.md)します。
2. 次に、[パッケージ フライトの保留中の申請を削除](delete-a-flight-submission.md)します (存在する場合)。
3. その後、[パッケージ フライトの新しい申請を作成](create-a-flight-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
4. 申請の新しいパッケージを Azure Blob Storage にアップロードします。
5. 次に、新しい申請を[更新](update-a-flight-submission.md)してから Windows デベロッパー センターに[コミット](commit-a-flight-submission.md)します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-a-flight-submission.md)します。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L223-L308)]

<span id="utilities" />
## <a name="utility-methods-to-upload-submission-files-and-handle-request-responses"></a>申請ファイルをアップロードし要求の応答を処理するユーティリティ メソッド

ここでは、次のタスクに対応するユーティリティ メソッドを示します。

* アプリまたはアドオンの申請の新しいアセットが含まれた ZIP アーカイブを Azure Blob Storage にアップロードする方法。 アプリとアドオンの申請のために Azure Blob Storage に ZIP アーカイブをアップロードする方法について詳しくは、「[アプリの申請の作成](manage-app-submissions.md#create-an-app-submission)」、「[アドオンの申請の作成](manage-add-on-submissions.md#create-an-add-on-submission)」、「[パッケージ フライトの申請の作成](manage-flight-submissions.md#create-a-package-flight-submission)」の関連する手順をご覧ください。
* 要求の応答を処理する方法。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L433-L490)]

<span id="code-listing" />
## <a name="complete-code-listing"></a>完全なコード

次のコードは、上記のすべての例を 1 つのソース ファイルにまとめた状態です。

[!code[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L1-L491)]

## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)



<!--HONumber=Dec16_HO3-->


