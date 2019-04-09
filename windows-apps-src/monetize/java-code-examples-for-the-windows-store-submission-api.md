---
ms.assetid: 4920D262-B810-409E-BA3A-F68AADF1B1BC
description: このセクションの Java コード例を使用して、Microsoft Store 申請 API を使用する方法をご確認ください。
title: Java のコード例 - アプリ、アドオン、およびフライトの申請
ms.date: 07/10/2017
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, コード例, Java
ms.localizationpriority: medium
ms.openlocfilehash: db87b1f8f3fdf039fe6e8ee8ca8a0bc91d26b428
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58334500"
---
# <a name="java-sample-submissions-for-apps-add-ons-and-flights"></a>Java のコード例: アプリ、アドオン、およびフライトの申請

この記事では、次のタスクで [Microsoft Store 申請 API](create-and-manage-submissions-using-windows-store-services.md) を使用する方法を示す Java コード例を提供します。

* [Azure AD アクセス トークンを取得します。](#token)
* [アドオンを作成します。](#create-add-on)
* [パッケージをフライトします。](#create-package-flight)
* [アプリの提出を作成します。](#create-app-submission)
* [アドオンを提出を作成します。](#create-add-on-submission)
* [パッケージのフライトの提出を作成します。](#create-flight-submission)

各例を確認して、それぞれが対応するタスクについて詳しく知ることができます。また、この記事のすべてのコード例を使って、コンソール アプリケーションをビルドすることもできます。 完全なコードについては、この記事の最後の「[完全なコード](java-code-examples-for-the-windows-store-submission-api.md#code-listing)」のセクションをご覧ください。

## <a name="prerequisites"></a>前提条件

以下の例では、次のライブラリを使用します。

* [Apache Commons Logging 1.2](https://commons.apache.org/proper/commons-logging)  (commons-logging-1.2.jar)。
* [Apache HttpComponents Core 4.4.5 および Apache HttpComponents Client 4.5.2](https://hc.apache.org/) (httpcore-4.4.5.jar and httpclient-4.5.2.jar)。
* [JSR 353 JSON Processing API 1.0](https://mvnrepository.com/artifact/javax.json/javax.json-api/1.0) および [JSR 353 JSON Processing Default Provider API 1.0.4](https://mvnrepository.com/artifact/org.glassfish/javax.json/1.0.4) (javax.json-api-1.0.jar and javax.json-1.0.4.jar)。

## <a name="main-program-and-imports"></a>メイン プログラムとインポート

次の例は、この記事のすべてのコード例で使用されている import ステートメントを示しています。このコード例によって、他のメソッドの例を呼び出すコマンド ライン プログラムが実装されます。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/MainExample.java#L1-L64)]

<span id="token" />

## <a name="obtain-an-azure-ad-access-token"></a>Azure AD アクセス トークンの取得

次の例は、Microsoft Store 申請 API のメソッドを呼び出すために使用できる [Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)する方法を示しています。 トークンを取得した後、Microsoft Store 申請 API の呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L65-L95)]

<span id="create-add-on" />

## <a name="create-an-add-on"></a>アドオンの作成

次の例は、アドオンを[作成](create-an-add-on.md)してから[削除](delete-an-add-on.md)する方法を示しています。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L310-L345)]

<span id="create-package-flight" />

## <a name="create-a-package-flight"></a>パッケージ フライトの作成

次の例は、パッケージ フライトを[作成](create-a-flight.md)してから[削除](delete-a-flight.md)する方法を示しています。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L185-L221)]

<span id="create-app-submission" />

## <a name="create-an-app-submission"></a>アプリの申請の作成

次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、アプリの申請を作成する方法を示しています。 これを行う、`SubmitNewApplicationSubmission`メソッドは、パブリッシュされた最後の送信の複製として新しい送信を作成し、更新し、パートナー センターに複製された送信をコミットします。 具体的には、`SubmitNewApplicationSubmission` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたアプリのデータを取得](get-an-app.md)します。
2. 次に、[アプリの保留中の申請を削除](delete-an-app-submission.md)します (存在する場合)。
3. その後、[アプリの新しい申請を作成](create-an-app-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
4. 新しい申請の詳細を変更し、申請の新しいパッケージを Azure Blob Storage にアップロードします。
5. 次に、その[更新](update-an-app-submission.md)し[コミット](commit-an-app-submission.md)パートナー センターに新しい送信します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-app-submission.md)します。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L97-L183)]

<span id="create-add-on-submission" />

## <a name="create-an-add-on-submission"></a>アドオンの申請の作成

次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、アドオンの申請を作成する方法を示しています。 これを行う、`SubmitNewInAppProductSubmission`メソッドの最後のパブリッシュされた提出マテリアルの新着のクローンとして作成し更新し、パートナー センターに複製された送信をコミットします。 具体的には、`SubmitNewInAppProductSubmission` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたアドオンのデータを取得](get-an-add-on.md)します。
2. 次に、[アドオンの保留中の申請を削除](delete-an-add-on-submission.md)します (存在する場合)。
3. その後、[アドオンの新しい申請を作成](create-an-add-on-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
4. 申請のアイコンが含まれた ZIP アーカイブを Azure Blob Storage にアップロードします。
5. 次に、その[更新](update-an-add-on-submission.md)し[コミット](commit-an-add-on-submission.md)パートナー センターに新しい送信します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-an-add-on-submission.md)します。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L347-L431)]

<span id="create-flight-submission" />

## <a name="create-a-package-flight-submission"></a>パッケージ フライトの申請の作成

次の例は、Microsoft Store 申請 API のいくつかのメソッドを使用して、パッケージ フライトの申請を作成する方法を示しています。 これを行う、`SubmitNewFlightSubmission`メソッドの最後のパブリッシュされた提出マテリアルの新着のクローンとして作成し更新し、パートナー センターに複製された送信をコミットします。 具体的には、`SubmitNewFlightSubmission` メソッドは次のタスクを実行します。

1. まず、メソッドは[指定されたパッケージ フライトのデータを取得](get-a-flight.md)します。
2. 次に、[パッケージ フライトの保留中の申請を削除](delete-a-flight-submission.md)します (存在する場合)。
3. その後、[パッケージ フライトの新しい申請を作成](create-a-flight-submission.md)します (新しい申請は、最後に公開された申請のコピーです)。
4. 申請の新しいパッケージを Azure Blob Storage にアップロードします。
5. 次に、その[更新](update-a-flight-submission.md)し[コミット](commit-a-flight-submission.md)PartnerCenter への新しい送信します。
6. 最後に、申請が正常にコミットされるまで、定期的に[新しい申請の状態をチェック](get-status-for-a-flight-submission.md)します。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L223-L308)]

<span id="utilities" />

## <a name="utility-methods-to-upload-submission-files-and-handle-request-responses"></a>申請ファイルをアップロードし要求の応答を処理するユーティリティ メソッド

ここでは、次のタスクに対応するユーティリティ メソッドを示します。

* アプリまたはアドオンの申請の新しいアセットが含まれた ZIP アーカイブを Azure Blob Storage にアップロードする方法。 アプリとアドオンの申請のために Azure Blob Storage に ZIP アーカイブをアップロードする方法について詳しくは、「[アプリの申請の作成](manage-app-submissions.md#create-an-app-submission)」、「[アドオンの申請の作成](manage-add-on-submissions.md#create-an-add-on-submission)」、「[パッケージ フライトの申請の作成](manage-flight-submissions.md#create-a-package-flight-submission)」の関連する手順をご覧ください。
* 要求の応答を処理する方法。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L433-L490)]

<span id="code-listing" />

## <a name="complete-code-listing"></a>完全なコード

次のコードは、上記のすべての例を 1 つのソース ファイルにまとめた状態です。

[!code-java[SubmissionApi](./code/StoreServicesExamples_Submission/java/CompleteExample.java#L1-L491)]

## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
