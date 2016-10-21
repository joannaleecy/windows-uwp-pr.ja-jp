---
author: mcleanbyron
ms.assetid: 2A454057-FF14-40D2-8ED2-CEB5F27E0226
description: "Windows デベロッパー センター アカウントに登録するアプリのパッケージ フライトの申請を管理するには、以下の Windows ストア申請 API のメソッドを使います。"
title: "Windows ストア申請 API を使用したパッケージ フライトの申請の管理"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 18d28495b80101cf5cfe53869b0f5cd3d61b50c9

---

# Windows ストア申請 API を使用したパッケージ フライトの申請の管理




Windows デベロッパー センター アカウントに登録するアプリのパッケージ フライトの申請を管理するには、以下の Windows ストア申請 API のメソッドを使います。 Windows ストア申請 API の概要については、「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。

>**注:**&nbsp;&nbsp;これらのメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。 これらのメソッドを使用してパッケージ フライトの申請を作成または管理するには、パッケージ フライトをお客様自身のデベロッパー センター アカウントに用意しておく必要があります。 パッケージ フライトは、[デベロッパー センター ダッシュボードを使用する](https://msdn.microsoft.com/windows/uwp/publish/package-flights)か、「[パッケージ フライトの管理](manage-flights.md)」の説明に従って Windows ストア申請 API のメソッドを使用して、作成できます。

| メソッド        | URI    | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}``` | 既存のパッケージ フライトの申請のデータを取得します。 詳しくは、「[パッケージ フライトの申請の取得](get-a-flight-submission.md)」をご覧ください。 |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status``` | 既存のパッケージ フライトの申請の取得を取得します。 詳しくは、「[パッケージ フライトの申請の状態の取得](get-status-for-a-flight-submission.md)」をご覧ください。 |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/applications/{applicationId}/flights/{flightId}/submissions``` | Windows デベロッパー センター アカウントに登録されているアプリのパッケージ フライトの申請を新規作成します。 詳しくは、「[パッケージ フライトの申請の作成](create-a-flight-submission.md)」をご覧ください。 |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit``` | 新しいパッケージ フライトまたは更新されたパッケージ フライトの申請を Windows デベロッパー センターにコミットします。 詳しくは、「[パッケージ フライトの申請のコミット](commit-a-flight-submission.md)」をご覧ください。 |
| PUT | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}``` | 既存のパッケージ フライトの申請のデータを更新します。 詳しくは、「[パッケージ フライトの申請の更新](update-a-flight-submission.md)」をご覧ください。 |
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}``` | パッケージ フライトの申請を削除します。 詳しくは、「[パッケージ フライトの申請の削除](delete-a-flight-submission.md)」をご覧ください。 |

<span id="create-a-package-flight-submission">
## パッケージ フライトの申請の作成

パッケージ フライトの申請を作成するには、次のプロセスに従います。

1. 「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」に記載されている前提条件が満たされていない場合は、前提条件を整えてください。これには、Azure AD アプリケーションの Windows デベロッパー センター アカウントへの関連付けや、クライアント ID およびキーの取得が含まれます。 この作業は 1 度行うだけでよく、クライアント ID とキーを入手したら、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。  

2. [Azure AD アクセス トークンを取得します](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)。 このアクセス トークンを Windows ストア申請 API のメソッドに渡す必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

3. Windows ストア申請 API の次のメソッドを実行します。 このメソッドによって、新しい申請が作成され、審議中になります。これは、前回発行した申請のコピーです。 詳しくは、「[パッケージ フライトの申請の作成](create-a-flight-submission.md)」をご覧ください。

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/applications{applicationId}/flights/{flightId}/submissions
  ```

  応答本文には、新しい申請の ID、新しい申請のデータ (すべての登録情報と価格情報が含まれます)、申請用のパッケージのアップロードに必要な共有アクセス署名 (SAS) URI の 3 つの項目が含まれます。 SAS について詳しくは、[共有アクセス署名についてのチュートリアルの第 1 部で SAS モデルの概要情報](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1/)をご覧ください。

4. 申請用に新しいパッケージを追加する場合は、[パッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)して、ZIP アーカイブに追加します。

5. 新しい申請用に必要な変更を行って申請データを更新し、次のメソッドを実行して申請を更新します。 詳しくは、「[パッケージ フライトの申請の更新](update-a-flight-submission.md)」をご覧ください。

  ```
  PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}
  ```

  >**注**&nbsp;&nbsp;申請用に新しいパッケージを追加する場合、ZIP アーカイブ内のパッケージのファイルの名前と相対パスを参照するように、申請データを更新してください。

4. 申請用に新しいパッケージを追加する場合は、手順 2. で呼び出した POST メソッドの応答本文に含まれていた SAS URI に ZIP アーカイブをアップロードします。 詳しくは、「[Shared Access Signature、第 2 部: BLOB ストレージでの SAS の作成と使用](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/)」をご覧ください。

  次のコード スニペットは、.NET 用 Azure Storage クライアント ライブラリの [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) クラスを使用してアーカイブをアップロードする方法を示しています。

  ```csharp
  string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";

  Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
      new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
  await blockBob.UploadFromStreamAsync(stream);
  ```

5. 次のメソッドを実行して、申請をコミットします。 これで、申請が完了し、更新がアカウントに適用されていることがデベロッパー センターに通知されます。 詳しくは、「[パッケージ フライトの申請のコミット](commit-a-flight-submission.md)」をご覧ください。

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/commit
  ```

6. 次のメソッドを実行して、コミットの状態を確認します。 詳しくは、「[パッケージ フライトの申請の状態の取得](get-status-for-a-flight-submission.md)」をご覧ください。

  ```
  GET https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/flights/{flightId}/submissions/{submissionId}/status
  ```

  申請の状態を確認するには、応答本文の *status* の値を確認します。 この値が **CommitStarted** から **PreProcessing** (要求が成功した場合) または **CommitFailed** (要求でエラーが発生した場合) に変わっています。 エラーがある場合は、*statusDetails* フィールドにエラーについての詳細情報が含まれています。

7. コミットが正常に処理されると、インジェストのために申請がストアに送信されます。 上記のメソッドを使うか、デベロッパー センターのダッシュボードから、申請の進行状況を引き続き監視できます。

## リソース

これらのメソッドでは、以下のデータ リソースを使用します。

<span id="flight-submission-object" />
### パッケージ フライトの申請

このリソースは、パッケージ フライトの申請を表します。 次の例は、このリソースの書式設定を示しています。

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
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/8b389577-5d5e-4cbe-a744-1ff2e97a9eb8?sv=2014-02-14&sr=b&sig=wgMCQPjPDkuuxNLkeG35rfHaMToebCxBNMPw7WABdXU%3D&se=2016-06-17T21:29:44Z&sp=rwl",
  "targetPublishMode": "Immediate",
  "targetPublishDate": "",
  "notesForCertification": "No special steps are required for certification of this app."
}
```

このリソースには、次の値があります。

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | 申請の ID です。  |
| flightId           | string  |  申請が関連付けられているパッケージ フライトの ID です。  |  
| status           | string  | 申請の状態。 次のいずれかの値を使用できます。 <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>   |
| statusDetails           | object  |  エラーに関する情報など、申請ステータスに関する追加詳細情報が含まれています。 詳しくは、以下の「[状態の詳細](#status-details-object)」セクションをご覧ください。 |
| flightPackages           | array  | 申請の各パッケージに関する詳細を提供するオブジェクトが含まれています。 詳しくは、以下の「[フライト パッケージ](#flight-package-object)」セクションをご覧ください。  |
| fileUploadUrl           | string  | 申請のパッケージのアップロードに使用する共有アクセス署名 (SAS) URI です。 申請用に新しいパッケージを追加する場合は、パッケージを含む ZIP アーカイブをこの URI にアップロードします。 詳しくは、「[パッケージ フライトの申請の作成](#create-a-package-flight-submission)」をご覧ください。  |
| targetPublishMode           | string  | 申請の公開モードです。 次のいずれかの値を使用できます。 <ul><li>Immediate</li><li>Manual</li><li>SpecificDate</li></ul> |
| targetPublishDate           | string  | *targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。  |
| notesForCertification           | string  |  テスト アカウントの資格情報や、機能のアクセスおよび検証手順など、審査担当者に対して追加情報を提供します。 詳しくは、「[認定の注意書き](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification)」をご覧ください。 |

<span id="status-details-object" />
### 状態の詳細

このリソースには、申請の状態についての追加情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  errors               |    object     |   申請のエラーの詳細が保持されるオブジェクトの配列です。 詳しくは、以下の「[状態の詳細](#status-detail-object)」セクションをご覧ください。   |     
|  warnings               |   object      | 申請の警告の詳細が保持されるオブジェクトの配列です。 詳しくは、以下の「[状態の詳細](#status-detail-object)」セクションをご覧ください。     |
|  certificationReports               |     object    |   申請の認定レポート データへのアクセスを提供するオブジェクトの配列です。 認定されなかった場合に、これらのレポートから詳しい情報を知ることができます。 詳しくは、以下の「[認定レポート](#certification-report-object)」セクションをご覧ください。   |  


<span id="status-detail-object" />
### 状態の詳細

このリソースには、申請に関連するエラーや警告についての追加情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  code               |    string     |   エラーや警告の種類を説明する文字列です。 詳しくは、以下の「[申請の状態コード](#submission-status-code)」セクションをご覧ください。   |     
|  details               |     string    |  問題についての詳細が含まれるメッセージです。     |


<span id="certification-report-object" />
### 認定レポート

このリソースは、申請の認定レポート データへのアクセスを提供します。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|     date            |    string     |  ISO 8601 形式で表された、レポートが生成された日付と時刻です。    |
|     reportUrl            |    string     |  レポートにアクセスできる URL です。    |


<span id="flight-package-object" />
### フライト パッケージ

このリソースは、申請に含まれるパッケージについての詳細情報を提供します。 次の例は、このリソースの書式設定を示しています。

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

>**注**&nbsp;&nbsp;[パッケージ フライトの申請の更新](update-a-flight-submission.md)のメソッドを呼び出す場合、要求本文に必要なのは、このオブジェクトの *fileName*、*fileStatus*、*minimumDirectXVersion*、*minimumSystemRam* の値のみです。 他の値はデベロッパー センターによって設定されます。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
| fileName   |   string      |  パッケージの名前です。    |  
| fileStatus    | string    |  パッケージの状態です。 次のいずれかの値を使用できます。 <ul><li>None</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>    |  
| id    |  string   |  パッケージを一意に識別する ID です。 この値は、デベロッパー センターによって使用されます。   |     
| version    |  string   |  アプリ パッケージのバージョンです。 詳しくは、「[パッケージ バージョンの番号付け](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering)」をご覧ください。   |   
| architecture    |  string   |  アプリ パッケージのアーキテクチャ (ARM など) です。   |     
| languages    | array    |  アプリがサポートする言語の言語コードの配列です。 詳しくは、「[サポートされる言語パックと既定の](https://msdn.microsoft.com/windows/uwp/publish/supported-languages)」をご覧ください。    |     
| capabilities    |  array   |  パッケージに必要な機能の配列です。 機能について詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。   |     
| minimumDirectXVersion    |  string   |  アプリ パッケージによってサポートされる DirectX の最小バージョンです。 これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。 次のいずれかの値を使用できます。 <ul><li>None</li><li>DirectX93</li><li>DirectX100</li></ul>   |     
| minimumSystemRam    | string    |  アプリ パッケージに必要な RAM の最小サイズです。 これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。 次のいずれかの値を使用できます。 <ul><li>None</li><li>Memory2GB</li></ul>   |    

<span/>

## 列挙型

これらのメソッドでは、次の列挙型が使用されます。

<span id="submission-status-code" />
### 申請の状態コード

次のコードは、申請の状態を表します。

| コード           |  説明      |
|-----------------|---------------|
|  None            |     コードが指定されていません。         |     
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
| Other  | 申請が非認識または未分類の状態です。 |
| PackageValidationWarning | パッケージ検証プロセスの結果、警告が生成されました。 |

<span/>

## 関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [Windows ストア申請 API を使用したパッケージ フライトの管理](manage-flights.md)
* [パッケージ フライトの申請の取得](get-a-flight-submission.md)
* [パッケージ フライトの申請の作成](create-a-flight-submission.md)
* [パッケージ フライトの申請の更新](update-a-flight-submission.md)
* [パッケージ フライトの申請のコミット](commit-a-flight-submission.md)
* [パッケージ フライトの申請の削除](delete-a-flight-submission.md)
* [パッケージ フライトの申請の状態の取得](get-status-for-a-flight-submission.md)



<!--HONumber=Aug16_HO5-->


