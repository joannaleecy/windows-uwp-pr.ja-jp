---
author: mcleanbyron
ms.assetid: 66400066-24BF-4AF2-B52A-577F5C3CA474
description: "Windows デベロッパー センター アカウントに登録するアプリのアドオンの申請を管理するには、以下の Windows ストア申請 API のメソッドを使います。"
title: "Windows ストア申請 API を使用したアドオンの申請の管理"
translationtype: Human Translation
ms.sourcegitcommit: f52059a37194b78db2f9bb29a5e8959b2df435b4
ms.openlocfilehash: a5e1f8940f53f228808e5a6540759199c4440645

---

# <a name="manage-add-on-submissions-using-the-windows-store-submission-api"></a>Windows ストア申請 API を使用したアドオンの申請の管理



Windows デベロッパー センター アカウントに登録するアプリのアドオン (アプリ内製品または IAP ともいう) の申請を管理するには、Windows ストア申請 API の以下のメソッドを使用します。 Windows ストア申請 API の概要については、「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。

>**注:**&nbsp;&nbsp;これらのメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。 これらのメソッドを使用してアドオンの申請を作成または管理するには、アドオンをお客様自身のデベロッパー センター アカウントに用意しておく必要があります。 アドオンは、[デベロッパー センター ダッシュボードを使用する](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions)か、「[アドオンの管理](manage-add-ons.md)」の説明に従って Windows ストア申請 API のメソッドを使用して、作成できます。

| メソッド        | URI    | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}``` | 既存のアドオンの申請のデータを取得します。 詳しくは、「[アドオンの申請の取得](get-an-add-on-submission.md)」をご覧ください。 |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/status``` | 既存のアドオンの申請の状態を取得します。 詳しくは、「[アドオンの申請の状態の取得](get-status-for-an-add-on-submission.md)」をご覧ください。 |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions``` | Windows デベロッパー センター アカウントに登録されているアプリのアドオンの申請を新規作成します。 詳しくは、「[アドオンの申請の作成](create-an-add-on-submission.md)」をご覧ください。 |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/commit``` | 新しいアドオンまたは更新されたアドオンの申請を Windows デベロッパー センターにコミットします。 詳しくは、「[アドオンの申請のコミット](commit-an-add-on-submission.md)」をご覧ください。 |
| PUT | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}``` | 既存のアドオンの申請を更新します。 詳しくは、「[アドオンの申請の更新](update-an-add-on-submission.md)」をご覧ください。 |
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}``` | アドオンの申請を削除します。 詳しくは、「[アドオンの申請の削除](delete-an-add-on-submission.md)」をご覧ください。 |

<span id="create-an-add-on-submission">
## <a name="create-an-add-on-submission"></a>アドオンの申請の作成

アドオンの申請を作成するには、次のプロセスに従います。

1. 「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」に記載されている前提条件が満たされていない場合は、前提条件を整えてください。これには、Azure AD アプリケーションの Windows デベロッパー センター アカウントへの関連付けや、クライアント ID およびキーの取得が含まれます。 この作業は 1 度行うだけでよく、クライアント ID とキーを入手したら、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。  

2. [Azure AD アクセス トークンを取得します](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)。 このアクセス トークンを Windows ストア申請 API のメソッドに渡す必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

3. Windows ストア申請 API の次のメソッドを実行します。 このメソッドによって、新しい申請が作成され、審議中になります。これは、前回発行した申請のコピーです。 詳しくは、「[アドオンの申請の作成](create-an-add-on-submission.md)」をご覧ください。

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions
  ```

  応答本文には、新しい申請の ID、新しい申請のデータ (すべての登録情報と価格情報が含まれます)、申請用のアドオン アイコンのアップロードに必要な共有アクセス署名 (SAS) URI の 3 つの項目が含まれます。 SAS について詳しくは、[共有アクセス署名についてのチュートリアルの第 1 部で SAS モデルの概要情報](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1/)をご覧ください。

4. 申請用に新しいアイコンを追加する場合は、[アイコンを準備](https://msdn.microsoft.com/windows/uwp/publish/create-iap-descriptions#icon)して、ZIP アーカイブに追加します。

5. 新しい申請用に必要な変更を行って申請データを更新し、次のメソッドを実行して申請を更新します。 詳しくは、「[アドオンの申請の更新](update-an-add-on-submission.md)」をご覧ください。

  ```
  PUT https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}
  ```

  >**注**&nbsp;&nbsp;申請用に新しいアイコンを追加する場合、ZIP アーカイブ内のアイコンのファイルの名前と相対パスを参照するように、申請データを更新してください。

4. 申請用に新しいアイコンを追加する場合は、手順 2. で呼び出した POST メソッドの応答本文に含まれていた SAS URI に ZIP アーカイブをアップロードします。 詳しくは、「[Shared Access Signature、第 2 部: BLOB ストレージでの SAS の作成と使用](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/)」をご覧ください。

  次のコード スニペットは、.NET 用 Azure Storage クライアント ライブラリの [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) クラスを使用してアーカイブをアップロードする方法を示しています。

  ```csharp
  string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";

  Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
      new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
  await blockBob.UploadFromStreamAsync(stream);
  ```

5. 次のメソッドを実行して、申請をコミットします。 これで、申請が完了し、更新がアカウントに適用されていることがデベロッパー センターに通知されます。 詳しくは、「[アドオンの申請のコミット](commit-an-add-on-submission.md)」をご覧ください。

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/commit
  ```

6. 次のメソッドを実行して、コミットの状態を確認します。 詳しくは、「[アドオンの申請の状態の取得](get-status-for-an-add-on-submission.md)」をご覧ください。

  ```
  GET https://manage.devcenter.microsoft.com/v1.0/my/inappproducts/{id}/submissions/{submissionId}/status
  ```

  申請の状態を確認するには、応答本文の *status* の値を確認します。 この値が **CommitStarted** から **PreProcessing** (要求が成功した場合) または **CommitFailed** (要求でエラーが発生した場合) に変わっています。 エラーがある場合は、*statusDetails* フィールドにエラーについての詳細情報が含まれています。

7. コミットが正常に処理されると、インジェストのために申請がストアに送信されます。 上記のメソッドを使うか、デベロッパー センターのダッシュボードから、申請の進行状況を引き続き監視できます。

## <a name="resources"></a>リソース

これらのメソッドでは、次のリソースを使用してデータの書式を設定します。

<span id="add-on-submission-object" />
### <a name="add-on-submission"></a>アドオンの申請

このリソースは、アドオンの申請を表します。 次の例は、このリソースの書式設定を示しています。

```json
{
  "id": "1152921504621243680",
  "contentType": "EMagazine",
  "keywords": [
    "books"
  ],
  "lifetime": "FiveDays",
  "listings": {
    "en": {
      "description": "English add-on description",
      "icon": {
        "fileName": "add-on-en-us-listing2.png",
        "fileStatus": "Uploaded"
      },
      "title": "Add-on Title (English)"
    },
    "ru": {
      "description": "Russian add-on description",
      "icon": {
        "fileName": "add-on-ru-listing.png",
        "fileStatus": "Uploaded"
      },
      "title": "Add-on Title (Russian)"
    }
  },
  "pricing": {
    "marketSpecificPricings": {
      "RU": "Tier3",
      "US": "Tier4",
    },
    "sales": [],
    "priceId": "Free"
  },
  "targetPublishDate": "2016-03-15T05:10:58.047Z",
  "targetPublishMode": "Immediate",
  "tag": "SampleTag",
  "visibility": "Public",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [
      {
        "code": "None",
        "details": "string"
      }
    ],
    "warnings": [
      {
        "code": "ListingOptOutWarning",
        "details": "You have removed listing language(s): []"
      }
    ],
    "certificationReports": [
      {
      }
    ]
  },

    "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl",
    "friendlyName": "Submission 2"
}
```

このリソースには、次の値があります。

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | 申請 ID。  |
| contentType           | string  |  アドオンで提供されている[コンテンツの種類](../publish/enter-add-on-properties.md#content-type)です。 次のいずれかの値を使用できます。 <ul><li>NotSet</li><li>BookDownload</li><li>EMagazine</li><li>ENewspaper</li><li>MusicDownload</li><li>MusicStream</li><li>OnlineDataStorage</li><li>VideoDownload</li><li>VideoStream</li><li>Asp</li><li>OnlineDownload</li></ul> |  
| keywords           | array  | アドオンの[キーワード](../publish/enter-add-on-properties.md#keywords)の文字列を最大 10 個含む配列です。 アプリでは、これらのキーワードを使ってアドオンを照会できます。   |
| lifetime           | string  |  アドオンの有効期間です。 次のいずれかの値を使用できます。 <ul><li>Forever</li><li>OneDay</li><li>ThreeDays</li><li>FiveDays</li><li>OneWeek</li><li>TwoWeeks</li><li>OneMonth</li><li>TwoMonths</li><li>ThreeMonths</li><li>SixMonths</li><li>OneYear</li></ul> |
| listings           | object  |  キーと値のペアのディクショナリです。各キーは 2 文字の ISO 3166-1 alpha-2 の国コードで、各値はアドオンの登録情報が保持される[登録情報リソース](#listing-object)オブジェクトです。  |
| pricing           | object  | アドオンの価格情報を含むオブジェクトです。 詳しくは、以下の「[価格リソース](#pricing-object)」セクションをご覧ください。  |
| targetPublishMode           | string  | 申請の公開モードです。 次のいずれかの値を使用できます。 <ul><li>Immediate</li><li>Manual</li><li>SpecificDate</li></ul> |
| targetPublishDate           | string  | *targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。  |
| tag           | string  |  アドオンの[カスタムの開発者データ](../publish/enter-add-on-properties.md#custom-developer-data)(この情報は従来*タグ*と呼ばれていました)。   |
| visibility  | string  |  アドオンの可視性です。 次のいずれかの値を使用できます。 <ul><li>Hidden</li><li>Public</li><li>Private</li><li>NotSet</li></ul>  |
| status  | string  |  申請の状態。 次のいずれかの値を使用できます。 <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>   |
| statusDetails           | object  |  エラーに関する情報など、申請ステータスに関する追加詳細情報が含まれています。 詳しくは、以下の「[状態の詳細](#status-details-object)」セクションをご覧ください。 |
| fileUploadUrl           | string  | 申請のパッケージのアップロードに使用する共有アクセス署名 (SAS) URI です。 申請用に新しいパッケージを追加する場合は、パッケージを含む ZIP アーカイブをこの URI にアップロードします。 詳しくは、「[アドオンの申請の作成](#create-an-add-on-submission)」をご覧ください。  |
| friendlyName  | string  |  表示目的で使用される、アドオンのフレンドリ名です。  |

<span id="listing-object" />
### <a name="listing"></a>登録情報

このリソースにはアドオンの登録情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  description               |    string     |   アドオンの登録情報についての説明です。   |     
|  icon               |   object      |  アドオンの登録情報に使われるアイコンのデータが保持されます。 詳しくは、以下の「[アイコン](#icon-object)」セクションをご覧ください。   |
|  title               |     string    |   アドオンの登録情報のタイトルです。   |  

<span id="icon-object" />
### <a name="icon"></a>アイコン

このリソースにはアドオンの登録情報のアイコン データが保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  fileName               |    string     |   申請用にアップロードした ZIP アーカイブに含まれているアイコン ファイルの名前です。    |     
|  fileStatus               |   string      |  アイコン ファイルの状態です。 次のいずれかの値を使用できます。 <ul><li>None</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>   |

<span id="pricing-object" />
### <a name="pricing"></a>価格設定

このリソースにはアドオンの価格設定情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明               |
|-----------------|---------|------|
|  marketSpecificPricings               |    object     |  キーと値のペアのディクショナリです。各キーは 2 文字の ISO 3166-1 alpha-2 の国コードで、各値は[価格帯](#price-tiers)です。 これらの項目は、[特定の市場でのアドオンのカスタム価格](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#markets-and-custom-prices)を表します。 このディクショナリに含まれる項目は、指定された市場の *priceId* の値によって指定されている基本価格を上書きします。     |     
|  sales               |   array      |  **推奨されなくなった値**です。 アドオンのセール情報が保持されるオブジェクト配列です。 詳しくは、以下の「[セール](#sale-object)」セクションをご覧ください。    |     
|  priceId               |   string      |  アドオンの[基本価格](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#base-price)を規定する[価格帯](#price-tiers)です。    |


<span id="sale-object" />
### <a name="sale"></a>セール

このリソースにはアドオンのセール情報が保持されます。

>**重要**&nbsp;&nbsp;**セール** リソースはサポートを終了しました。現在、Windows ストア申請 APIを使用して、アドオンの申請の販売データを取得し、変更することはできません。

   > * [アドオンの申請を取得する GET メソッド](get-an-add-on-submission.md)を呼び出すと、*セール* リソースは空になります。 引き続きデベロッパー センター ダッシュボードを使って、アドオンの申請のセール データを取得することができます。
   > * [アドオンの申請を更新する PUT メソッド](update-an-add-on-submission.md)を呼び出すとき、*セール*の値に含まれた情報は無視されます。 引き続きデベロッパー センター ダッシュボードを使って、アドオンの申請のセール データを変更することができます。

> 将来的には、Windows ストア申請 API を更新し、アドオンの申請のセール情報にプログラムでアクセスする新しい方法を導入する予定です。

このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  name               |    string     |   セールの名前です。    |     
|  basePriceId               |   string      |  セールの基本価格として使用する[価格帯](#price-tiers)です。    |     
|  startDate               |   string      |   ISO 8601 形式で表したセールの開始日です。  |     
|  endDate               |   string      |  ISO 8601 形式で表したセールの終了日です。      |     
|  marketSpecificPricings               |   object      |   キーと値のペアのディクショナリです。各キーは 2 文字の ISO 3166-1 alpha-2 の国コードで、各値は[価格帯](#price-tiers)です。 これらの項目は、[特定の市場でのアドオンのカスタム価格](https://msdn.microsoft.com/windows/uwp/publish/set-iap-pricing-and-availability#markets-and-custom-pricess)を表します。 このディクショナリに含まれる項目は、指定された市場の *basePriceId* の値によって指定されている基本価格を上書きします。    |



<span id="status-details-object" />
### <a name="status-details"></a>状態の詳細

このリソースには、申請の状態についての追加情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  errors               |    object     |   申請のエラーの詳細が保持されるオブジェクトの配列です。 詳しくは、以下の「[状態の詳細](#status-detail-object)」セクションをご覧ください。   |     
|  warnings               |   object      | 申請の警告の詳細が保持されるオブジェクトの配列です。 詳しくは、以下の「[状態の詳細](#status-detail-object)」セクションをご覧ください。     |
|  certificationReports               |     object    |   申請の認定レポート データへのアクセスを提供するオブジェクトの配列です。 認定されなかった場合に、これらのレポートから詳しい情報を知ることができます。 詳しくは、以下の「[認定レポート](#certification-report-object)」セクションをご覧ください。   |  


<span id="status-detail-object" />
### <a name="status-detail"></a>状態の詳細

このリソースには、申請に関連するエラーや警告についての追加情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  code               |    string     |   エラーや警告の種類を説明する文字列です。 詳しくは、以下の「[申請の状態コード](#submission-status-code)」セクションをご覧ください。   |     
|  details               |     string    |  問題についての詳細が含まれるメッセージです。     |


<span id="certification-report-object" />
### <a name="certification-report"></a>認定レポート

このリソースは、申請の認定レポート データへのアクセスを提供します。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|     date            |    string     |  ISO 8601 形式で表された、レポートが生成された日付と時刻です。    |
|     reportUrl            |    string     |  レポートにアクセスできる URL です。    |



## <a name="enums"></a>列挙型

これらのメソッドでは、次の列挙型が使用されます。


<span id="price-tiers" />
### <a name="price-tiers"></a>価格帯

次の値は、アドオンの申請に利用できる価格帯を表します。

| 値           | 説明                                                                                                                                                                                                                          |
|-----------------|------|
|  Base               |   価格帯が設定されていない場合、アドオンの基本価格が使用されます。      |     
|  NotAvailable              |   アドオンは指定された地域で提供されていません。    |     
|  Free              |   アドオンは無償です。    |    
|  Tier2 ～ Tier194               |   Tier2 は .99 USD の価格帯を表します。 Tier の数字が大きくなるにつれて、より高い価格帯を表します (1.29 USD、1.49 USD、1.99 USD など)。    |


<span id="submission-status-code" />
### <a name="submission-status-code"></a>申請の状態コード

次の値は、申請の状態コードを表します。

| 値           |  説明      |
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

## <a name="related-topics"></a>関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)
* [Windows ストア申請 API を使用したアドオンの管理](manage-add-ons.md)
* [デベロッパー センター ダッシュボードからのアドオンの申請](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions)



<!--HONumber=Dec16_HO1-->


