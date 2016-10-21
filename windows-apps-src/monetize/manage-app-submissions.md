---
author: mcleanbyron
ms.assetid: C7428551-4B31-4259-93CD-EE229007C4B8
description: "Windows デベロッパー センター アカウントに登録するアプリの申請を管理するには、以下の Windows ストア申請 API のメソッドを使います。"
title: "Windows ストア申請 API を使用したアプリの申請の管理"
translationtype: Human Translation
ms.sourcegitcommit: 178b70db1583790c174d65e060c8bce6e4f69243
ms.openlocfilehash: 448eafbdadb21476da43e7408bb8bad354ba486d

---

# Windows ストア申請 API を使用したアプリの申請の管理




Windows デベロッパー センター アカウントに登録するアプリの申請を管理するには、以下の Windows ストア申請 API のメソッドを使います。 Windows ストア申請 API の概要については、「[Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)」をご覧ください。この API を使用するための前提条件などの情報があります。

>**注:**&nbsp;&nbsp;これらのメソッドは、Windows ストア申請 API を使用するアクセス許可が付与された Windows デベロッパー センター アカウントにのみ使用できます。 すべてのアカウントでこのアクセス許可が有効になっているとは限りません。


| メソッド        | URI    | 説明                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}``` | 既存のアプリの申請のデータを取得します。 詳しくは、「[アプリの申請の取得](get-an-app-submission.md)」をご覧ください。 |
| GET | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/status``` | 既存のアプリの申請の状態を取得します。 詳しくは、「[アプリの申請の状態の取得](get-status-for-an-app-submission.md)」をご覧ください。 |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions``` | Windows デベロッパー センター アカウントに登録されているアプリの申請を新規作成します。 詳しくは、「[アプリの申請の作成](create-an-app-submission.md)」をご覧ください。 |
| POST | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/commit``` | 新しいアプリまたは更新されたアプリの申請を Windows デベロッパー センターにコミットします。 詳しくは、「[アプリの申請のコミット](commit-an-app-submission.md)」をご覧ください。 |
| PUT | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}``` | 既存のアプリの申請を更新します。 詳しくは、「[アプリの申請の更新](update-an-app-submission.md)」をご覧ください。 |
| DELETE | ```https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}``` | アプリの申請を削除します。 詳しくは、「[アプリの申請の削除](delete-an-app-submission.md)」をご覧ください。 |

<span id="create-an-app-submission">
## アプリの申請の作成

アプリの申請を作成するには、次のプロセスに従います。

1. Windows ストア申請 API に関するすべての[前提条件](create-and-manage-submissions-using-windows-store-services.md#prerequisites)を満たします (前提条件がまだ満たされていない場合)。

  >**注**&nbsp;&nbsp;[年齢区分](https://msdn.microsoft.com/windows/uwp/publish/age-ratings)の情報を含む 1 つ以上の申請がアプリで既に完了していることを確認します。

3. [Azure AD アクセス トークンを取得します](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)。 このアクセス トークンを Windows ストア申請 API のメソッドに渡す必要があります。 アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れたら新しいトークンを取得できます。

4. Windows ストア申請 API の次のメソッドを実行します。 このメソッドによって、新しい申請が作成され、審議中になります。これは、前回発行した申請のコピーです。 詳しくは、「[アプリの申請の作成](create-an-app-submission.md)」をご覧ください。

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions
  ```

  応答本文には、新しい申請の ID、新しい申請のデータ (すべての登録情報と価格情報が含まれます)、申請のアプリのパッケージと登録情報の画像のアップロードに必要な共有アクセス署名 (SAS) URI の 3 つの項目が含まれます。 SAS について詳しくは、[共有アクセス署名についてのチュートリアルの第 1 部で SAS モデルの概要情報](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-1/)をご覧ください。

3. 申請用の新しいパッケージまたは画像を追加する場合は、[アプリのパッケージを準備](https://msdn.microsoft.com/windows/uwp/publish/app-package-requirements)し、[アプリのスクリーンショットと画像を準備](https://msdn.microsoft.com/windows/uwp/publish/app-screenshots-and-images)します。 これらのファイルをすべてまとめて ZIP アーカイブに追加します。

4. 新しい申請用に必要な変更を行って申請データを更新し、次のメソッドを実行して申請を更新します。 詳しくは、「[アプリの申請の更新](update-an-app-submission.md)」をご覧ください。

  ```
  PUT https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}
  ```

  >**注**&nbsp;&nbsp;申請用に新しいパッケージまたは画像を追加する場合、ZIP アーカイブ内のアイコンのファイルの名前と相対パスを参照するように、申請データを更新してください。

4. 申請用に新しいパッケージまたは画像を追加する場合は、手順 2. で呼び出した POST メソッドの応答本文に含まれていた SAS URI に ZIP アーカイブをアップロードします。 詳しくは、「[Shared Access Signature、第 2 部: BLOB ストレージでの SAS の作成と使用](https://azure.microsoft.com/documentation/articles/storage-dotnet-shared-access-signature-part-2/)」をご覧ください。

  次のコード スニペットは、.NET 用 Azure Storage クライアント ライブラリの [CloudBlockBlob](https://msdn.microsoft.com/library/azure/microsoft.windowsazure.storage.blob.cloudblockblob.aspx) クラスを使用してアーカイブをアップロードする方法を示しています。

  ```csharp
  string sasUrl = "https://productingestionbin1.blob.core.windows.net/ingestion/26920f66-b592-4439-9a9d-fb0f014902ec?sv=2014-02-14&sr=b&sig=usAN0kNFNnYE2tGQBI%2BARQWejX1Guiz7hdFtRhyK%2Bog%3D&se=2016-06-17T20:45:51Z&sp=rwl";

  Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob blockBob =
      new Microsoft.WindowsAzure.Storage.Blob.CloudBlockBlob(new System.Uri(sasUrl));
  await blockBob.UploadFromStreamAsync(stream);
  ```

5. 次のメソッドを実行して、申請をコミットします。 これで、申請が完了し、更新がアカウントに適用されていることがデベロッパー センターに通知されます。 詳しくは、「[アプリの申請のコミット](commit-an-app-submission.md)」をご覧ください。

  ```
  POST https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/commit
  ```

6. 次のメソッドを実行して、コミットの状態を確認します。 詳しくは、「[アプリの申請の状態の取得](get-status-for-an-app-submission.md)」をご覧ください。

    ```
    GET https://manage.devcenter.microsoft.com/v1.0/my/applications/{applicationId}/submissions/{submissionId}/status
    ```

    申請の状態を確認するには、応答本文の *status* の値を確認します。 この値が **CommitStarted** から **PreProcessing** (要求が成功した場合) または **CommitFailed** (要求でエラーが発生した場合) に変わっています。 エラーがある場合は、*statusDetails* フィールドにエラーについての詳細情報が含まれています。

7. コミットが正常に処理されると、インジェストのために申請がストアに送信されます。 上記のメソッドを使うか、デベロッパー センターのダッシュボードから、申請の進行状況を引き続き監視できます。

## リソース

これらのメソッドでは、次のリソースを使用してデータの書式を設定します。

<span id="app-submission-object" />
### アプリの申請

このリソースは、アプリの申請を表します。 次の例は、このリソースの書式設定を示しています。

```json
{
  "id": "1152921504621243540",
  "applicationCategory": "BooksAndReference_EReader",
  "pricing": {
    "trialPeriod": "FifteenDays",
    "marketSpecificPricings": {},
    "sales": [],
    "priceId": "Tier2"
  },
  "visibility": "Public",
  "targetPublishMode": "Manual",
  "targetPublishDate": "1601-01-01T00:00:00Z",
  "listings": {
    "en-us": {
      "baseListing": {
        "copyrightAndTrademarkInfo": "",
        "keywords": [],
        "licenseTerms": "",
        "privacyPolicy": "",
        "supportContact": "",
        "websiteUrl": "",
        "description": "Description",
        "features": [],
        "releaseNotes": "",
        "images": [
          {
            "fileName": "contoso.png",
            "fileStatus": "Uploaded",
            "id": "1152921504672272757",
            "imageType": "Screenshot"
          }
        ],
        "recommendedHardware": [],
        "title": "ApiTestApp For Devbox"
      },
      "platformOverrides": {}
    }
  },
  "hardwarePreferences": [
    "Touch"
  ],
  "automaticBackupEnabled": false,
  "canInstallOnRemovableMedia": true,
  "isGameDvrEnabled": false,
  "hasExternalInAppProducts": false,
  "meetAccessibilityGuidelines": true,
  "notesForCertification": "",
  "status": "PendingCommit",
  "statusDetails": {
    "errors": [],
    "warnings": [],
    "certificationReports": []
  },
  "fileUploadUrl": "https://productingestionbin1.blob.core.windows.net/ingestion/387a9ea8-a412-43a9-8fb3-a38d03eb483d?sv=2014-02-14&sr=b&sig=sdd12JmoaT6BhvC%2BZUrwRweA%2Fkvj%2BEBCY09C2SZZowg%3D&se=2016-06-17T18:32:26Z&sp=rwl",
  "applicationPackages": [
    {
      "fileName": "contoso_app.appx",
      "fileStatus": "Uploaded",
      "id": "1152921504620138797",
      "version": "1.0.0.0",
      "architecture": "ARM",
      "languages": [
        "en-US"
      ],
      "capabilities": [
        "ID_RESOLUTION_HD720P",
        "ID_RESOLUTION_WVGA",
        "ID_RESOLUTION_WXGA"
      ],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None",
      "targetDeviceFamilies": [
        "Windows.Mobile min version 10.0.10240.0"
      ]
    }
  ],
  "enterpriseLicensing": "Online",
  "allowMicrosoftDecideAppAvailabilityToFutureDeviceFamilies": true,
  "allowTargetFutureDeviceFamilies": {
    "Desktop": false,
    "Mobile": true,
    "Holographic": true,
    "Xbox": false,
    "Team": true
  },
  "friendlyName": "Submission 2"
}
```

このリソースには、次の値があります。

| 値      | 型   | 説明                                                                                                                                                                                                                                                                         |
|------------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| id            | string  | 申請 ID。  |
| applicationCategory           | string  |   アプリの[カテゴリとサブカテゴリ](https://msdn.microsoft.com/windows/uwp/publish/category-and-subcategory-table)を指定する文字列です。 カテゴリとサブカテゴリは、アンダースコア "_" で 1 つの文字列に連結します (例: **BooksAndReference_EReader**)。      |  
| pricing           |  object  | アプリの価格情報を含むオブジェクトです。 詳しくは、以下の「[価格リソース](#pricing-object)」セクションをご覧ください。       |   
| visibility           |  string  |  アプリの可視性です。 次のいずれかの値を使用できます。 <ul><li>Hidden</li><li>Public</li><li>Private</li><li>NotSet</li></ul>       |   
| targetPublishMode           | string  | 申請の公開モードです。 次のいずれかの値を使用できます。 <ul><li>Immediate</li><li>Manual</li><li>SpecificDate</li></ul> |
| targetPublishDate           | string  | *targetPublishMode* が SpecificDate に設定されている場合、ISO 8601 形式での申請の公開日です。  |  
| listings           |   object  |  キーと値のペアのディクショナリです。各キーは国コード、各値はアプリの登録情報を含む[登録情報リソース](#listing-object) オブジェクトです。       |   
| hardwarePreferences           |  array  |   アプリの[ハードウェアの基本設定](https://msdn.microsoft.com/windows/uwp/publish/enter-app-properties#hardware_preferences)を定義する文字列の配列です。 次のいずれかの値を使用できます。 <ul><li>Touch</li><li>Keyboard</li><li>Mouse</li><li>Camera</li><li>NfcHce</li><li>Nfc</li><li>BluetoothLE</li><li>Telephony</li></ul>     |   
| automaticBackupEnabled           |  boolean  |   OneDrive への自動バックアップにアプリのデータを含めることができるかどうかを示します。 詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。   |   
| canInstallOnRemovableMedia           |  boolean  |   ユーザーがアプリをリムーバブル記憶域にインストールできるかどうかを示します。 詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。     |   
| isGameDvrEnabled           |  boolean |   アプリのゲーム録画が有効になっているかどうかを示します。    |   
| hasExternalInAppProducts           |     boolean          |   ユーザーが Windows ストア コマース システムを使わないで購入することをアプリが許可するかどうかを示します。 詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。     |   
| meetAccessibilityGuidelines           |    boolean           |  アプリがアクセシビリティ ガイドラインを満たことをテストされているかどうかを示します。 詳しくは、「[アプリの宣言](https://msdn.microsoft.com/windows/uwp/publish/app-declarations)」をご覧ください。      |   
| notesForCertification           |  string  |   アプリの[認定の注意書き](https://msdn.microsoft.com/windows/uwp/publish/notes-for-certification)が含まれます。    |    
| status           |   string  |  申請の状態。 次のいずれかの値を使用できます。 <ul><li>None</li><li>Canceled</li><li>PendingCommit</li><li>CommitStarted</li><li>CommitFailed</li><li>PendingPublication</li><li>Publishing</li><li>Published</li><li>PublishFailed</li><li>PreProcessing</li><li>PreProcessingFailed</li><li>Certification</li><li>CertificationFailed</li><li>Release</li><li>ReleaseFailed</li></ul>      |    
| statusDetails           |   object  |  エラーに関する情報など、申請ステータスに関する追加詳細情報が含まれています。 詳しくは、以下の「[状態の詳細](#status-details-object)」セクションをご覧ください。       |    
| fileUploadUrl           |   string  | 申請のパッケージのアップロードに使用する共有アクセス署名 (SAS) URI です。 申請用に新しいパッケージまたは画像を追加する場合は、パッケージと画像を含む ZIP アーカイブをこの URI にアップロードします。 詳しくは、「[アプリの申請の作成](#create-an-app-submission)」をご覧ください。       |    
| applicationPackages           |   array  | 申請の各パッケージに関する詳細を提供するオブジェクトが含まれています。 詳しくは、以下の「[アプリ パッケージ](#application-package-object)」セクションをご覧ください。 |    
| enterpriseLicensing           |  string  |  アプリのエンタープライズ ライセンス動作を示す[エンタープライズ ライセンス値](#enterprise-licensing)のいずれかです。  |    
| allowMicrosftDecideAppAvailabilityToFutureDeviceFamilies           |  boolean   |  [アプリを将来の Windows 10 デバイス ファミリで利用できるようにする](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families)ことを Microsoft が許可されているかどうかを示すします。    |    
| allowTargetFutureDeviceFamilies           | object   |  キーと値のペアのディクショナリです。各キーは [Windows 10 デバイス ファミリ](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability#windows-10-device-families) を表し、各値は指定されたデバイス ファミリをアプリがターゲットにできるかどうかを示すブール値です。     |    
| friendlyName           |   string  |  表示目的で使用される、アプリのフレンドリ名です。       |  


<span id="listing-object" />
### 登録情報

このリソースにはアプリの登録情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  baseListing               |   object      |  アプリの[基本の登録情報](#base-listing-object)です。これはすべてのプラットフォームで既定の登録情報となります。   |     
|  platformOverrides               | object |   キーと値のペアのディクショナリです。各キーは、登録情報を上書きするプラットフォームを示す文字列を表し、各値は、指定されたプラットフォームで上書きする登録情報を示す[基本の登録情報](#base-listing-object)オブジェクト (description から title までの値のみが保持されています) を表します。 キーには次の値を設定できます。 <ul><li>Unknown</li><li>Windows80</li><li>Windows81</li><li>WindowsPhone71</li><li>WindowsPhone80</li><li>WindowsPhone81</li></ul>     |      |     

<span id="base-listing-object" />
### 基本の登録情報

このリソースにはアプリの基本の登録情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  copyrightAndTrademarkInfo                |   string      |  (省略可能) [著作権や商標の情報](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#copyright-and-trademark-info)です。  |
|  keywords                |  array       |  結果にアプリが表示される確率を高める[キーワード](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#keywords)の配列です。    |
|  licenseTerms                |    string     | アプリの[ライセンス条項](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#additional-license-terms) (省略可能) です。     |
|  privacyPolicy                |   string      |   アプリの[プライバシー ポリシー](https://msdn.microsoft.com/windows/uwp/publish/privacy-policy)の URL です。    |
|  supportContact                |   string      |  アプリの[サポートの連絡先情報](https://msdn.microsoft.com/windows/uwp/publish/support-contact-info)の URL またはメール アドレスです。     |
|  websiteUrl                |   string      |  アプリの [Web ページ](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#website)の URL です。    |    
|  description               |    string     |   アプリの登録情報の[説明](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#description)です。   |     
|  features               |    array     |  アプリの[機能](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#app-features)を示す最大 20 個の文字列の配列です。     |
|  releaseNotes               |  string       |  アプリの[リリース ノート](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#release-notes)です。    |
|  images               |   array      |  アプリの登録情報の[画像とアイコン](#image-object)のデータの配列です。  |
|  recommendedHardware               |   array      |  アプリの[推奨されるハードウェア構成](https://msdn.microsoft.com/windows/uwp/publish/create-app-descriptions#recommended-hardware)を示す最大 11 個の文字列の配列です。     |
|  title               |     string    |   アプリの登録情報のタイトルです。   |  


<span id="image-object" />
### 画像

このリソースにはアプリの登録情報の画像とアイコンのデータが保持されます。 登録情報の画像とアイコンについて詳しくは、「[アプリのスクリーンショットと画像](https://msdn.microsoft.com/windows/uwp/publish/app-screenshots-and-images)」をご覧ください。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  fileName               |    string     |   申請用にアップロードした ZIP アーカイブに含まれている画像ファイルの名前です。    |     
|  fileStatus               |   string      |  画像ファイルの状態です。 次のいずれかの値を使用できます。 <ul><li>None</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>   |
|  id  |  string  | デベロッパー センターによって指定されたとおりの、画像の ID です。  |
|  description  |  string  | 画像の説明です。  |
|  imageType  |  string  | 画像の種類を示す以下の文字列のいずれかです。 <ul><li>Unknown</li><li>Screenshot</li><li>PromotionalArtwork414X180</li><li>PromotionalArtwork846X468</li><li>PromotionalArtwork558X756</li><li>PromotionalArtwork414X180</li><li>PromotionalArtwork558X756</li><li>PromotionalArtwork2400X1200</li><li>Icon</li><li>WideIcon358X173</li><li>BackgroundImage1000X800</li><li>SquareIcon358X358</li><li>MobileScreenshot</li><li>XboxScreenshot</li><li>SurfaceHubScreenshot</li><li>HoloLensScreenshot</li></ul>      |


<span id="pricing-object" />
### 価格設定

このリソースにはアプリの価格設定情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  trialPeriod               |    string     |  アプリの試用期間を示す文字列です。 次のいずれかの値を使用できます。 <ul><li>NoFreeTrial</li><li>OneDay</li><li>TrialNeverExpires</li><li>SevenDays</li><li>FifteenDays</li><li>ThirtyDays</li></ul>    |
|  marketSpecificPricings               |    object     |  キーと値のペアのディクショナリです。各キーは 2 文字の ISO 3166-1 alpha-2 の国コードで、各値は[価格帯](#price-tiers)です。 これらの項目は、[特定の市場でのアプリのカスタム価格](https://msdn.microsoft.com/windows/uwp/publish/define-pricing-and-market-selection#markets-and-custom-prices)を表します。 このディクショナリに含まれる項目は、指定された市場の *priceId* の値によって指定されている基本価格を上書きします。      |     
|  sales               |   array      |  アプリのセール情報が保持されるオブジェクト配列です。 詳しくは、以下の「[セール](#sale-object)」セクションをご覧ください。    |     
|  priceId               |   string      |  アプリの[基本価格](https://msdn.microsoft.com/windows/uwp/publish/define-pricing-and-market-selection#base-price)を規定する[価格帯](#price-tier)です。   |


<span id="sale-object" />
### セール

このリソースにはアプリのセール情報が保持されます。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|  name               |    string     |   セールの名前です。    |     
|  basePriceId               |   string      |  セールの基本価格として使用する[価格帯](#price-tiers)です。    |     
|  startDate               |   string      |   ISO 8601 形式で表したセールの開始日です。  |     
|  endDate               |   string      |  ISO 8601 形式で表したセールの終了日です。      |     
|  marketSpecificPricings               |   object      |   キーと値のペアのディクショナリです。各キーは 2 文字の ISO 3166-1 alpha-2 の国コードで、各値は[価格帯](#price-tiers)です。 これらの項目は、[特定の市場でのアプリのカスタム価格](https://msdn.microsoft.com/windows/uwp/publish/define-pricing-and-market-selection#markets-and-custom-prices)を表します。 このディクショナリに含まれる項目は、指定された市場の *basePriceId* の値によって指定されている基本価格を上書きします。    |


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


<span id="application-package-object" />
### アプリ パッケージ

このリソースには、申請のアプリ パッケージについての情報が保持されます。 次の例は、このリソースの書式設定を示しています。

```json
{
  "applicationPackages": [
    {
      "fileName": "contoso_app.appx",
      "fileStatus": "Uploaded",
      "id": "1152921504620138797",
      "version": "1.0.0.0",
      "architecture": "ARM",
      "languages": [
        "en-US"
      ],
      "capabilities": [
        "ID_RESOLUTION_HD720P",
        "ID_RESOLUTION_WVGA",
        "ID_RESOLUTION_WXGA"
      ],
      "minimumDirectXVersion": "None",
      "minimumSystemRam": "None",
      "targetDeviceFamilies": [
        "Windows.Mobile min version 10.0.10240.0"
      ]
    }
  ],
}
```

このリソースには、次の値があります。  

>**注**&nbsp;&nbsp;[アプリの申請の更新](update-an-app-submission.md)のメソッドを呼び出す場合、要求本文に必要なのは、このオブジェクトの *fileName*、*fileStatus*、*minimumDirectXVersion*、*minimumSystemRam* の値のみです。 他の値はデベロッパー センターによって設定されます。

| 値           | 型    | 説明                   |
|-----------------|---------|------|
| fileName   |   string      |  パッケージの名前です。    |  
| fileStatus    | string    |  パッケージの状態です。 次のいずれかの値を使用できます。 <ul><li>None</li><li>PendingUpload</li><li>Uploaded</li><li>PendingDelete</li></ul>    |  
| id    |  string   |  パッケージを一意に識別する ID です。 この値は、デベロッパー センターによって使用されます。   |     
| version    |  string   |  アプリ パッケージのバージョンです。 詳しくは、「[パッケージ バージョンの番号付け](https://msdn.microsoft.com/windows/uwp/publish/package-version-numbering)」をご覧ください。   |   
| architecture    |  string   |  パッケージのアーキテクチャ (ARM など) です。   |     
| languages    | array    |  アプリがサポートする言語の言語コードの配列です。 詳しくは、「[サポートされる言語パックと既定の](https://msdn.microsoft.com/windows/uwp/publish/supported-languages)」をご覧ください。    |     
| capabilities    |  array   |  パッケージに必要な機能の配列です。 機能について詳しくは、「[アプリ機能の宣言](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。   |     
| minimumDirectXVersion    |  string   |  アプリ パッケージによってサポートされる DirectX の最小バージョンです。 これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。 次のいずれかの値を使用できます。 <ul><li>None</li><li>DirectX93</li><li>DirectX100</li></ul>   |     
| minimumSystemRam    | string    |  アプリ パッケージに必要な RAM の最小サイズです。 これは Windows 8.x をターゲットにするアプリにしか設定できません。その他バージョンをターゲットにするアプリでは無視されます。 次のいずれかの値を使用できます。 <ul><li>None</li><li>Memory2GB</li></ul>   |       
| targetDeviceFamilies    | array    |  パッケージがターゲットにするデバイス ファミリを表す文字列の配列です。 この値は Windows 10 をターゲットにするパッケージにしか使用できません。以前のリリースをターゲットにするパッケージでは、この値は **None** になります。 Windows 10 パッケージには、現在、次のデバイス ファミリの文字列がサポートされます。*{0}* は Windows 10 のバージョン文字列で、10.0.10240.0、10.0.10586.0、または 10.0.14393.0 などです。 <ul><li>Windows.Universal min version *{0}*</li><li>Windows.Desktop min version *{0}*</li><li>Windows.Mobile min version *{0}*</li><li>Windows.Xbox min version *{0}*</li><li>Windows.Holographic min version *{0}*</li></ul>   |    

<span/>

<span id="certification-report-object" />
### 認定レポート

このリソースは、申請の認定レポート データへのアクセスを提供します。 このリソースには、次の値があります。

| 値           | 型    | 説明                                                                                                                                                                                                                          |
|-----------------|---------|------|
|     date            |    string     |  ISO 8601 形式で表された、レポートが生成された日付と時刻です。    |
|     reportUrl            |    string     |  レポートにアクセスできる URL です。    |



## 列挙型

これらのメソッドでは、次の列挙型が使用されます。


<span id="price-tiers" />
### 価格帯

次の値は、アプリの申請に利用できる価格帯を表します。

| 値           | 説明                                                                                                                                                                                                                          |
|-----------------|------|
|  Base               |   価格帯が設定されていない場合、アプリの基本価格が使用されます。      |     
|  NotAvailable              |   アプリは指定された地域で提供されていません。    |     
|  Free              |   アプリは無償です。    |    
|  Tier2 ～ Tier194               |   Tier2 は .99 USD の価格帯を表します。 Tier の数字が大きくなるにつれて、より高い価格帯を表します (1.29 USD、1.49 USD、1.99 USD など)。    |


<span id="enterprise-licensing" />
### エンタープライズ ライセンス値

次の値は、アプリのエンタープライズ ライセンス動作を表します。 これらのオプションについて詳しくは、「[組織のライセンス オプション](https://msdn.microsoft.com/windows/uwp/publish/organizational-licensing)」をご覧ください。

| 値           |  説明      |
|-----------------|---------------|
| None            |     ストアで管理される (オンラインの) ボリューム ライセンスがある企業に、アプリの利用を許可しません。         |     
| オンライン        |     ストアで管理される (オンラインの) ボリューム ライセンスがある企業に、アプリの利用を許可します。  |
| OnlineAndOffline | ストアで管理される (オンラインの) ボリューム ライセンスがある企業にアプリの利用を許可し、未接続状態 (オフライン) のライセンスのある企業にアプリの利用を許可します。 |


<span id="submission-status-code" />
### 申請の状態コード

次の値は、申請の状態コードを表します。

| 値           |  説明      |
|-----------------|---------------|
| None            |     コードが指定されていません。         |     
| InvalidArchive        |     パッケージが含まれる ZIP アーカイブは無効であるか、認識できないアーカイブ形式です。  |
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
* [Windows ストア申請 API を使用したアプリ データの取得](get-app-data.md)
* [デベロッパー センター ダッシュボードからのアプリの申請](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)



<!--HONumber=Aug16_HO5-->


