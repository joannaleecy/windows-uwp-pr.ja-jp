---
ms.assetid: 2A454057-FF14-40D2-8ED2-CEB5F27E0226
description: Microsoft Store 送信 API でこれらのメソッドを使用すると、パートナー センター アカウントに登録されているアプリのパッケージのフライトの送信を管理できます。
title: パッケージ フライトの申請の管理
ms.date: 04/16/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store 申請 API, フライトの申請
ms.localizationpriority: medium
ms.openlocfilehash: 19ddd43d4e61480764882f1b10e6240aa2afeb8c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662727"
---
# <a name="manage-package-flight-submissions"></a>パッケージ フライトの申請の管理

Microsoft Store 申請 API には、段階的なパッケージのロールアウトなど、アプリのパッケージ フライトの申請を管理するために使用できるメソッドが用意されています。 Microsoft Store 申請 API の概要については、「[Microsoft Store サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。

> [!IMPORTANT]
> Microsoft Store 送信 API を使用してパッケージ フライトの提出を作成すると、必ず変更を加える提出にパートナー センターではなく、API を使用してのみ。 最初に API を使って作成した申請を、ダッシュボードを使って変更した場合、API を使ってその申請を変更またはコミットすることができなくなります。 場合によっては、申請がエラー状態のままになり、申請プロセスを進めることができなくなります。 この場合、申請を削除して新しい申請を作成する必要があります。

<span id="methods-for-package-flight-submissions" />

## <a name="methods-for-managing-package-flight-submissions"></a>パッケージ フライトの申請を管理するためのメソッド

パッケージ フライトの申請を取得、作成、更新、コミット、または削除するには、次のメソッドを使用します。 これらのメソッドを使用するには、パッケージ フライトが、パートナー センター既に存在する必要があります。 パッケージ フライトを作成することができます[パートナー センターで](https://msdn.microsoft.com/windows/uwp/publish/package-flights)で説明されている Microsoft Store の送信 API メソッドを使用してまたは[管理パッケージ フライト](manage-flights.md)。

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">メソッド</th>
<th align="left">URI</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr>
<td align="left">GET</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><a href="get-a-flight-submission.md">既存のパッケージのフライトの送信を取得します。</a></td>
</tr>
<tr>
<td align="left">GET</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status</td>
<td align="left"><a href="get-status-for-a-flight-submission.md">既存のパッケージのフライトの送信の状態を取得します。</a></td>
</tr>
<tr>
<td align="left">POST</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions</td>
<td align="left"><a href="create-a-flight-submission.md">新しいパッケージのフライトの提出を作成します。</a></td>
</tr>
<tr>
<td align="left">PUT</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><a href="update-a-flight-submission.md">既存のパッケージのフライト申請を更新します。</a></td>
</tr>
<tr>
<td align="left">POST</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit</td>
<td align="left"><a href="commit-a-flight-submission.md">新しいまたは更新されたパッケージのフライト送信をコミットします。</a></td>
</tr>
<tr>
<td align="left">DELETE</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}</td>
<td align="left"><a href="delete-a-flight-submission.md">パッケージのフライトの送信を削除します。</a></td>
</tr>
</tbody>
</table>

<span id="create-a-package-flight-submission">

## <a name="create-a-package-flight-submission"></a>パッケージ フライトの申請の作成

パッケージ フライトの申請を作成するには、次のプロセスに従います。

1. まだ行っていないため、完全な前提条件に記載されている[作成 Microsoft Store サービスを使用して送信の管理と](create-and-manage-submissions-using-windows-store-services.md)(パートナー センター アカウントと Azure AD アプリケーションの関連付けを取得するなど)、クライアント ID とキー。 この作業は 1 度行うだけでよく、クライアント ID とキーを入手したら、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。  

2. [Azure AD のアクセス トークンを取得します](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)。 このアクセス トークンを Microsoft Store 申請 API のメソッドに渡す必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

3. Microsoft Store 申請 API の次のメソッドを実行して、[パッケージ フライトの申請を作成](create-a-flight-submission.md)します。 このメソッドによって、新しい申請が作成され、審査中になります。これは、前回発行した申請のコピーです。

    ```
    POST https://manage.devcenter.microsoft.com/v1.0/my/applications{applicationId}/flights/{flightId}/submissions
    ```

    応答本文には、新しい申請の ID、申請用のパッケージを Azure Blob Storage にアップロードするための共有アクセス署名 (SAS) URI、および新しい申請のデータ (すべての登録情報と価格情報が含まれます) を含む[フライトの申請](#flight-submission-object)リソースが含まれます。

    > [!NOTE]
    > SAS URI では、アカウント キーを必要とせずに、Azure Storage 内のセキュリティで保護されたリソースにアクセスできます。 SAS URI の背景情報と Azure Blob Storage での SAS URI の使用については、[Shared Access Signature 第 1 部: SAS モデルについて](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1)と[Shared Access Signature、第 2 部。作成し、Blob storage では、SAS を使用して](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/)します。

4. 申請用に新しいパッケージを追加する場合は、[パッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)して、ZIP アーカイブに追加します。

5. 新しい申請用に必要な変更を行って[フライトの申請](#flight-submission-object)のデータを更新し、次のメソッドを実行して[パッケージ フライトの申請を更新](update-a-flight-submission.md)します。

    ```
    PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}
    ```
      > [!NOTE]
      > 申請用に新しいパッケージを追加する場合、ZIP アーカイブ内のアイコンのファイルの名前と相対パスを参照するように、申請データを更新してください。

4. 申請用に新しいパッケージを追加する場合は、上記で呼び出した POST メソッドの応答本文に含まれていた SAS URI を使用して、ZIP アーカイブを [Azure Blob Storage](https://docs.microsoft.com/azure/storage/storage-introduction#blob-storage) にアップロードします。 さまざまなプラットフォームでこれを行うために使用できる、次のようなさまざまな Azure ライブラリがあります。

    * [.NET 用 azure Storage クライアント ライブラリ](https://docs.microsoft.com/azure/storage/storage-dotnet-how-to-use-blobs)
    * [Azure Storage SDK for Java](https://docs.microsoft.com/azure/storage/storage-java-how-to-use-blob-storage)
    * [Azure Storage SDK for Python](https://docs.microsoft.com/azure/storage/storage-python-how-to-use-blob-storage)

    次の C# コード例は、.NET 用 Azure Storage クライアント ライブラリの [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) クラスを使用して ZIP アーカイブを Azure Blob Storage にアップロードする方法を示しています。 この例では、ZIP アーカイブが既にストリーム オブジェクトに書き込まれていることを前提としています。

    ```csharp
    string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";
    Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
        new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
    await blockBob.UploadFromStreamAsync(stream);
    ```

5. 次のメソッドを実行して、[パッケージ フライトの申請をコミット](commit-a-flight-submission.md)します。 お客様の提出を終了することと、自分のアカウントに、更新プログラムが適用されるようになりましたことは、パートナー センターが警告されます。

    ```
    POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit
    ```

6. 次のメソッドを実行して[パッケージ フライトの申請の状態を取得](get-status-for-a-flight-submission.md)して、コミット状態を確認します。

    ```
    GET https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status
    ```

    申請の状態を確認するには、応答本文の *status* の値を確認します。 この値が **CommitStarted** から **PreProcessing** (要求が成功した場合) または **CommitFailed** (要求でエラーが発生した場合) に変わっています。 エラーがある場合は、*statusDetails* フィールドにエラーについての詳細情報が含まれています。

7. コミットが正常に処理されると、インジェストのために申請がストアに送信されます。 前のメソッドを使用するか、パートナー センターにアクセスして、送信進行状況を監視できます。

<span/>

## <a name="code-examples"></a>コード例

次の記事では、さまざまなプログラミング言語でパッケージ フライトの申請を作成する方法を説明する詳しいコード例を紹介します。

* [C#コード例](csharp-code-examples-for-the-windows-store-submission-api.md)
* [Java のコード例](java-code-examples-for-the-windows-store-submission-api.md)
* [Python のコード例](python-code-examples-for-the-windows-store-submission-api.md)

## <a name="storebroker-powershell-module"></a>StoreBroker PowerShell モジュール

Microsoft Store 申請 API を直接呼び出す代わりに、API の上にコマンド ライン インターフェイスを実装するオープンソースの PowerShell モジュールも用意されています。 このモジュールは、[StoreBroker](https://aka.ms/storebroker) と呼ばれています。 このモジュールを使うと、Microsoft Store 申請 API を直接呼び出さずに、コマンド ラインからアプリ、フライト、アドオンの申請を管理できます。また、ソースを参照して、この API を呼び出す方法の例を確認することもできます。 StoreBroker モジュールは、多くのファースト パーティ アプリケーションをストアに申請する主要な方法として Microsoft 内で積極的に使っています。

詳しくは、[GitHub の StoreBroker に関するページ](https://aka.ms/storebroker)をご覧ください。

<span id="manage-gradual-package-rollout">

## <a name="manage-a-gradual-package-rollout-for-a-package-flight-submission"></a>パッケージ フライトの申請の段階的なパッケージのロールアウトを管理する

パッケージ フライトの申請で更新されたパッケージを、アプリの Windows 10 のユーザーの一部に、段階的にロールアウトできます。 これにより、更新に確信が持てるよう、特定のパッケージのフィードバックと分析データを監視してから、より広くロールアウトできます。 新しい申請を作成することなく、公開された申請のロールアウトの割合を変更する (または更新を停止する) ことができます。 詳細については、有効にして、パートナー センターでのパッケージを段階的なロールアウトを管理する方法の手順などを参照してください[今回](../publish/gradual-package-rollout.md)します。

パッケージ フライトの申請の段階的なパッケージのロールアウトをプログラムによって有効化するには、Microsoft Store 申請 API のメソッドを使用して、次の手順に従います。

  1. [パッケージ フライトの申請の作成](create-a-flight-submission.md)、または[パッケージ フライトの申請の取得](get-a-flight-submission.md)を行います。
  2. 応答データで、[packageRollout](#package-rollout-object) リソースを探し、*[isPackageRollout]* フィールドを [true] に設定し、*[packageRolloutPercentage]* フィールドに、アプリのユーザーが更新されたパッケージを取得する割合を設定します。
  3. 更新されたパッケージ フライトの申請のデータを[パッケージ フライトの申請を更新する](update-a-flight-submission.md)メソッドに渡します。

パッケージ フライトの申請の段階的なパッケージのロールアウトが有効化された後、段階的なロールアウトをプログラムで取得、更新、停止、または完了するには、次のメソッドを使用できます。

<table>
<colgroup>
<col width="10%" />
<col width="30%" />
<col width="60%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">メソッド</th>
<th align="left">URI</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr>
<td align="left">GET</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/packagerollout</td>
<td align="left"><a href="get-package-rollout-info-for-a-flight-submission.md">パッケージのフライトの送信の段階的なロールアウト情報を取得します。</a></td>
</tr>
<tr>
<td align="left">POST</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/updatepackagerolloutpercentage</td>
<td align="left"><a href="update-the-package-rollout-percentage-for-a-flight-submission.md">更新プログラム パッケージのフライトの段階的なロールアウトの割合</a></td>
</tr>
<tr>
<td align="left">POST</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/haltpackagerollout</td>
<td align="left"><a href="halt-the-package-rollout-for-a-flight-submission.md">パッケージのフライトの段階的なロールアウトを停止します。</a></td>
</tr>
<tr>
<td align="left">POST</td>
<td align="left">https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/finalizepackagerollout</td>
<td align="left"><a href="finalize-the-package-rollout-for-a-flight-submission.md">パッケージのフライトの段階的なロールアウトを最終処理します。</a></td>
</tr>
</tbody>
</table>

<span/>

## <a name="data-resources"></a>データ リソース

パッケージ フライトの申請を管理するための Microsoft Store 申請 API のメソッドでは、次の JSON データ リソースが使われます。

<span id="flight-submission-object" />

### <a name="flight-submission-resource"></a>フライトの申請のリソース

このリソースは、パッケージ フライトの申請を記述しています。

```json
{
  "id": "1152921504621243649",
  "flightId": "cd2e368a-0da5-4026-9f34-0e7934bc6f23",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
  "flightPackages": [
    {
      "fileName": "newPackage.appx",
      "fileStatus": "PendingUpload",
      "id": "",
      "version": "1.0.0.0",
      "languages": ["en-us"],
      "capabilities": [],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None"
    }
  ],
  "packageDeliveryOptions": {
    "packageRollout": {
        "isPackageRollout": false,
        "packageRolloutPercentage": 0.0,
        "packageRolloutStatus": "PackageRolloutNotStarted",
        "fallbackSubmissionId": "0"
    },
    "isMandatoryUpdate": false,
    "mandatoryUpdateEffectiveDate": "1601-01-01T00:00:00.0000000Z"
  },
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/8b389577-5d5e-4cbe-a744-1ff2e97a9eb8?sv=2014-02-14&sr=b&sig=wgMCQPjPDkuuxNLkeG35rfHaMToebCxBNMPw7WABdXU%3D&se=2016-06-17T21:29:44Z&sp=rwl",
  "targetPublishMode": "Immediate",
  "targetPublishDate": "",
  "notesForCertification": "No special steps are required for certification of this app."
}
```

このリソースには、次の値があります。

| Value      | 種類   | 説明              |
|------------|--------|------------------------------|
| id            | string  | 申請の ID です。  |
| flightId           | string  |  申請が関連付けられているパッケージ フライトの ID です。  |  
| status           | string  | 申請の状態。 次のいずれかの値を使用できます。 <ul><li>なし</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>公開</li><li>公開済み</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>認定</li><li>CertificationFailed</li><li>リリース</li><li>ReleaseFailed</li></ul>   |
| statusDetails           | オブジェクト  |  エラーに関する情報など、申請のステータスに関する追加情報が保持される[ステータスの詳細に関するリソース](#status-details-object)です。  |
| flightPackages           | array  | 申請の各パッケージに関する詳細を提供する[フライト パッケージ リソース](#flight-package-object)が含まれています。   |
| packageDeliveryOptions    | オブジェクト  | 申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれた[パッケージ配布オプション リソース](#package-delivery-options-object)です。   |
| fileUploadUrl           | string  | 申請のパッケージのアップロードに使用する共有アクセス署名 (SAS) URI です。 申請用に新しいパッケージを追加する場合は、パッケージを含む ZIP アーカイブをこの URI にアップロードします。 詳しくは、「[パッケージ フライトの申請の作成](#create-a-package-flight-submission)」をご覧ください。  |
| targetPublishMode           | string  | 申請の公開モードです。 次のいずれかの値を使用できます。 <ul><li>即時</li><li>Manual</li><li>SpecificDate</li></ul> |
| targetPublishDate           | string  | *targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。  |
| notesForCertification           | string  |  テスト アカウントの資格情報や、機能のアクセスおよび検証手順など、審査担当者に対して追加情報を提供します。 詳しくは、「[認定の注意書き](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification)」をご覧ください。 |

<span id="status-details-object" />

### <a name="status-details-resource"></a>ステータスの詳細に関するリソース

このリソースには、申請の状態についての追加情報が保持されます。 このリソースには、次の値があります。

| Value           | 種類    | 説明                   |
|-----------------|---------|------|
|  errors               |    オブジェクト     |   申請のエラーの詳細が保持される[ステータスの詳細リソース](#status-detail-object)の配列です。   |     
|  warnings               |   オブジェクト      | 申請の警告の詳細が保持される[ステータスの詳細リソース](#status-detail-object)の配列です。     |
|  certificationReports               |     オブジェクト    |   申請の認定レポート データへのアクセスを提供する[認定レポート リソース](#certification-report-object)です。 認定されなかった場合に、これらのレポートから詳しい情報を知ることができます。    |  


<span id="status-detail-object" />

### <a name="status-detail-resource"></a>ステータスの詳細に関するリソース

このリソースには、申請に関連するエラーや警告についての追加情報が保持されます。 このリソースには、次の値があります。

| Value           | 種類    | 説明       |
|-----------------|---------|------|
|  code               |    string     |   エラーや警告の種類を説明する[申請ステータス コード](#submission-status-code)です。 |  
|  details               |     string    |  問題についての詳細が含まれるメッセージです。     |


<span id="certification-report-object" />

### <a name="certification-report-resource"></a>認定レポート リソース

このリソースは、申請の認定レポート データへのアクセスを提供します。 このリソースには、次の値があります。

| Value           | 種類    | 説明         |
|-----------------|---------|------|
|     date            |    string     |  日付と ISO 8601 形式でレポートが生成された時刻。    |
|     reportUrl            |    string     |  レポートにアクセスできる URL です。    |


<span id="flight-package-object" />

### <a name="flight-package-resource"></a>フライト パッケージ リソース

このリソースは、申請に含まれるパッケージについての詳細情報を提供します。

```json
{
  "flightPackages": [
    {
      "fileName": "newPackage.appx",
      "fileStatus": "PendingUpload",
      "id": "",
      "version": "1.0.0.0",
      "languages": ["en-us"],
      "capabilities": [],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None"
    }
  ],
}
```

このリソースには、次の値があります。

> [!NOTE]
> [パッケージ フライトの申請の更新](update-a-flight-submission.md)のメソッドを呼び出す場合、要求本文に必要なのは、このオブジェクトの *fileName*、*fileStatus*、*minimumDirectXVersion*、*minimumSystemRam* の値のみです。 パートナー センターでは、その他の値が設定されます。

| Value           | 種類    | 説明              |
|-----------------|---------|------|
| fileName   |   string      |  パッケージの名前。    |  
| fileStatus    | string    |  パッケージの状態です。 次のいずれかの値を使用できます。 <ul><li>なし</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>    |  
| id    |  string   |  パッケージを一意に識別する ID です。 この値は、パートナー センターで使用されます。   |     
| version    |  string   |  アプリ パッケージのバージョンです。 詳しくは、「[パッケージ バージョンの番号付け](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering)」をご覧ください。   |   
| architecture    |  string   |  アプリ パッケージのアーキテクチャ (ARM など) です。   |     
| languages    | array    |  アプリがサポートする言語の言語コードの配列です。 詳しくは、「[サポートされる言語パックと既定の](https://msdn.microsoft.com/windows/uwp/publish/supported-languages)」をご覧ください。    |     
| capabilities    |  array   |  パッケージに必要な機能の配列です。 機能について詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。   |     
| minimumDirectXVersion    |  string   |  アプリ パッケージによってサポートされる DirectX の最小バージョンです。 これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。 次のいずれかの値を使用できます。 <ul><li>なし</li><li>DirectX93</li><li>DirectX100</li></ul>   |     
| minimumSystemRam    | string    |  アプリ パッケージに必要な RAM の最小サイズです。 これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。 次のいずれかの値を使用できます。 <ul><li>なし</li><li>Memory2GB</li></ul>   |    


<span id="package-delivery-options-object" />

### <a name="package-delivery-options-resource"></a>パッケージの配信オプション リソース

このリソースには、申請の段階的なパッケージのロールアウトと必須の更新の設定が含まれています。

```json
{
  "packageDeliveryOptions": {
    "packageRollout": {
        "isPackageRollout": false,
        "packageRolloutPercentage": 0.0,
        "packageRolloutStatus": "PackageRolloutNotStarted",
        "fallbackSubmissionId": "0"
    },
    "isMandatoryUpdate": false,
    "mandatoryUpdateEffectiveDate": "1601-01-01T00:00:00.0000000Z"
  },
}
```

このリソースには、次の値があります。

| Value           | 種類    | 説明        |
|-----------------|---------|------|
| packageRollout   |   オブジェクト      |   申請の段階的なパッケージのロールアウトの設定が含まれた[パッケージのロールアウトのリソース](#package-rollout-object)です。    |  
| isMandatoryUpdate    | boolean    |  この申請のパッケージを自己インストールのアプリの更新のために必須として扱うかどうかを指定します。 自己インストールのアプリの更新のために必須なパッケージについて詳しくは、「[アプリのパッケージの更新をダウンロードしてインストールする](../packaging/self-install-package-updates.md)」をご覧ください。    |  
| mandatoryUpdateEffectiveDate    |  date   |  この申請のパッケージが必須となる日時 (ISO 8601 形式、UTC タイムゾーン)。   |        

<span id="package-rollout-object" />

### <a name="package-rollout-resource"></a>パッケージのロールアウトのリソース

このリソースには、申請の段階的な[パッケージのロールアウトの設定](#manage-gradual-package-rollout)が含まれています。 このリソースには、次の値があります。

| Value           | 種類    | 説明        |
|-----------------|---------|------|
| isPackageRollout   |   boolean      |  申請の段階的なパッケージのロールアウトが有効化されているかどうかを示します。    |  
| packageRolloutPercentage    | float    |  段階的なロールアウトでパッケージを受信するユーザーの割合。    |  
| packageRolloutStatus    |  string   |  段階的なパッケージのロールアウトの状態を示す、次の文字列のいずれかです。 <ul><li>PackageRolloutNotStarted</li><li>PackageRolloutInProgress</li><li>PackageRolloutComplete</li><li>PackageRolloutStopped</li></ul>  |  
| fallbackSubmissionId    |  string   |  段階的なロールアウトのパッケージを入手しないユーザーが受信する申請のID。   |          

> [!NOTE]
> *PackageRolloutStatus*と*fallbackSubmissionId*値は、パートナー センターで割り当てられているし、開発者によって設定するためのものはありません。 これらの値を要求本文に含めると、これらの値は無視されます。

<span/>

## <a name="enums"></a>列挙型

これらのメソッドでは、次の列挙型が使用されます。

<span id="submission-status-code" />

### <a name="submission-status-code"></a>申請の状態コード

次のコードは、申請の状態を表します。

| コード           |  説明      |
|-----------------|---------------|
|  なし            |     コードが指定されていません。         |     
|      InvalidArchive        |     パッケージが含まれる ZIP アーカイブは無効であるか、認識できないアーカイブ形式です。  |
| MissingFiles | ZIP アーカイブに、申請データで指定されているすべてのファイルが含まれていないか、ファイルのアーカイブ内の場所が正しくありません。 |
| PackageValidationFailed | 申請の 1 つ以上のパッケージを検証できませんでした。 |
| InvalidParameterValue | 要求本文に含まれるパラメーターの 1 つが無効です。 |
| InvalidOperation | 実行された操作は無効です。 |
| InvalidState | 実行された操作は、パッケージ フライトの現在の状態では無効です。 |
| ResourceNotFound | 指定されたパッケージ フライトは見つかりませんでした。 |
| ServiceError | 内部サービス エラーのため、要求を処理できませんでした。 もう一度要求を行ってください。 |
| ListingOptOutWarning | 開発者が以前の申請の登録情報を削除しているか、パッケージによってサポートされる登録情報を含めていませんでした。 |
| ListingOptInWarning  | 開発者が登録情報を追加しました。 |
| UpdateOnlyWarning | 開発者が、更新サポートしかないものを挿入しようとしています。 |
| その他  | 申請が非認識または未分類の状態です。 |
| PackageValidationWarning | パッケージ検証プロセスの結果、警告が生成されました。 |

<span/>

## <a name="related-topics"></a>関連トピック

* [作成し、Microsoft Store サービスを使用して送信の管理](create-and-manage-submissions-using-windows-store-services.md)
* [Microsoft Store 送信 API を使用してパッケージのフライトを管理します。](manage-flights.md)
* [パッケージのフライトの送信を取得します。](get-a-flight-submission.md)
* [パッケージのフライトの提出を作成します。](create-a-flight-submission.md)
* [更新プログラム パッケージのフライトの送信](update-a-flight-submission.md)
* [パッケージのフライトの送信をコミットします。](commit-a-flight-submission.md)
* [パッケージのフライトの送信を削除します。](delete-a-flight-submission.md)
* [パッケージのフライトの送信の状態を取得します。](get-status-for-a-flight-submission.md)
