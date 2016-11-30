---
author: normesta
Description: "このガイドは、Windows 情報保護 (WIP) ポリシーによって管理される企業データ、および個人データを処理するように、アプリを対応させる場合に役立ちます。"
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: "企業データと個人データの両方を使用する対応アプリの作成"
translationtype: Human Translation
ms.sourcegitcommit: bf1c47e9cca45b626a45ca664bf2bb4be9c529e0
ms.openlocfilehash: 82b674c72126c66aff34b0396a2c32f88023dd25

---

# 企業データと個人データの両方を使用する対応アプリの作成

__注__ Windows 情報保護 (WIP) ポリシーは、Windows 10 Version 1607 に適用することができます。

*対応*アプリは企業データと個人データを区別し、管理者によって定義された Windows 情報保護 (WIP) ポリシーに基づいて、どちらを保護するかを判別します。

このガイドでは、こうしたアプリの作成方法について説明します。 アプリの作成が完了すると、ポリシー管理者はこのようなアプリを信頼し、アプリによる組織のデータの利用を許可することができます。 また、従業員は、組織のモバイル デバイス管理 (MDM) から登録を解除した場合や、完全に組織を去ることになった場合でも、デバイス上の個人データをそのまま残す方法を望んでいます。

WIP と対応アプリについて詳しくは、「[Windows Information Protection (WIP)](wip-hub.md)」(Windows 情報保護 (WIP)) をご覧ください。

完全なサンプルは、[ここ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/EnterpriseDataProtection)にあります。

各作業を実行する準備ができたら、始めましょう。

## 最初に必要なものを収集する

以下が必要となります。

* Windows 10 Version 1607 を実行するテスト仮想マシン (VM)。 このテスト VM でアプリをデバッグします。

* Windows 10 Version 1607 を実行している開発コンピューター。 Visual Studio をテスト VM にインストールしている場合は、テスト VM を使用することもできます。

## 開発環境のセットアップ

以下の作業を行います。

* テスト VM に WIP Setup Developer Assistant をインストールします。

* WIP Setup Developer Assistant を使用して保護ポリシーを作成します。

* Visual Studio プロジェクトをセットアップします。

* リモート デバッグをセットアップします。

* 名前空間をコード ファイルに追加します。

**テスト VM に WIP Setup Developer Assistant をインストールする**

 テスト VM で Windows 情報保護ポリシーを設定するには、このツールを使用します。

 このツールは、[WIP Setup Developer Assistant に関するページ](https://www.microsoft.com/store/p/wip-setup-developer-assistant/9nblggh526jf)でダウンロードできます。

**保護ポリシーを作成する**

WIP Setup Developer Assistant 内の各セクションに情報を追加することによって、ポリシーを定義します。 その使用方法について詳しくは、すべての設定の横にある [ヘルプ] アイコンを選択します。

このツールの使用方法に関する一般的なガイダンスについては、アプリのダウンロード ページで、バージョンに関する注意事項のセクションを参照してください。

**Visual Studio プロジェクトをセットアップする**

1. 開発コンピューターで、プロジェクトを開きます。

2. ユニバーサル Windows プラットフォーム (UWP) 用のデスクトップ拡張機能とモバイル拡張機能への参照を追加します。

    ![UWP 拡張機能の追加](images/extensions.png)

3. 以下の機能をパッケージ マニフェスト ファイルに追加します。

    ```xml
       <Capability Name="privateNetworkClientServer" />
       <rescap:Capability Name="enterpriseDataPolicy"/>
    ```
   >*参考情報*: "rescap" プレフィックスは、*制限された機能* を意味しています。 「[特殊な用途および制限された用途に関する機能](https://msdn.microsoft.com/windows/uwp/packaging/app-capability-declarations)」をご覧ください。

4. 次の名前空間をパッケージ マニフェスト ファイルに追加します。

    ```xml
      xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
    ```
5. 名前空間のプレフィックスをパッケージ マニフェスト ファイルの ``<ignorableNamespaces>`` 要素に追加します。

    ```xml
        <IgnorableNamespaces="uap mp rescap">
    ```

    このようにすることで、制限された機能をサポートしていないバージョンの Windows オペレーティング システムでアプリを実行した場合に、Windows は ``enterpriseDataPolicy`` 機能を無視します。

**リモート デバッグをセットアップする**

VM 以外のコンピューターでアプリを開発している場合にのみ、テスト VM に Visual Studio リモート ツールをインストールします。 次に、開発用コンピューターでリモート デバッガーを起動し、アプリがテスト VM で実行されているかどうかを確認します。

「[リモート PC の手順](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps#remote-pc-instructions)」をご覧ください。

**名前空間をコード ファイルに追加する**

以下の using ステートメントをコード ファイルの先頭に追加します (このガイドのスニペットでこれらのステートメントが使用されます)。

```csharp
using System.Threading.Tasks;
using Windows.Security.EnterpriseData;
using Windows.ApplicationModel.DataTransfer;
using Windows.Web.Http;
using Windows.Storage.Streams;
using Windows.Web.Http.Filters;
using Windows.Storage;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Windows.Data.Xml.Dom;
```

## アプリを実行するオペレーティング システムが WIP をサポートしているかどうかを確認する

[**IsApiContractPresent**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.foundation.metadata.apiinformation.isapicontractpresent.aspx) 関数を使用して、これを確認します。

```csharp
bool wipSupported = ApiInformation.IsApiContractPresent("Windows.Security.EnterpriseData.EnterpriseDataContract", 3);

if (wipSupported)
{
    // WIP is supported on the platform
}
else
{
    // WIP is not supported on the platform
}
```

Windows 情報保護は、Windows 10 バージョン 1607 でサポートされます。

## 企業データの読み取り

ファイル、ネットワーク エンドポイント、クリップボードのデータ、および共有コントラクトから受け取ったデータはすべて、エンタープライズ ID を保持しています。

それらのソースからデータを読み取るには、アプリで、エンタープライズ ID がポリシーによって管理されていることを確認する必要があります。

最初にファイルの場合について説明します。

### データをファイルから読み取る

**手順 1: ファイル ハンドルを取得する**

```csharp
    Windows.Storage.StorageFolder storageFolder =
        Windows.Storage.ApplicationData.Current.LocalFolder;

    Windows.Storage.StorageFile file =
        await storageFolder.GetFileAsync(fileName);
```

**手順 2: アプリでファイルを開くことができるかどうかを確認する**

ファイルが保護されているかどうかを確認します。 保護されているファイルについては、以下の 2 つの条件に該当する場合にそのファイルを開くことができます。

* ファイルの ID がポリシーによって管理されている。
* アプリがポリシーの許可リストに登録されている。

これらの条件のどちらかに該当しない場合、[**ProtectionPolicyManager.IsIdentityManaged**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx) は **false** を返し、そのファイルを開くことはできません。

```csharp
FileProtectionInfo protectionInfo = await FileProtectionManager.GetProtectionInfoAsync(file);

if (protectionInfo.Status == FileProtectionStatus.Protected)
{
    if (!ProtectionPolicyManager.IsIdentityManaged(protectionInfo.Identity))
    {
        return false;
    }
}
else if (protectionInfo.Status == FileProtectionStatus.Revoked)
{
    // Code goes here to handle this situation. Perhaps, show UI
    // saying that the user's data has been revoked.
}
```
> **API** <br>
[FileProtectionManager.GetProtectionInfoAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.getprotectioninfoasync.aspx)<br>
[FileProtectionInfo](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.aspx)<br>
[FileProtectionStatus](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx)<br>
[ProtectionPolicyManager.IsIdentityManaged](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx)

**手順 3: ファイルをストリームまたはバッファーに読み取る**

*ファイルをストリームに読み取る*

```csharp
var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
```

*ファイルをバッファーに読み取る*

```csharp
var buffer = await Windows.Storage.FileIO.ReadBufferAsync(file);
```

### データをネットワーク エンドポイントから読み取る

企業のエンドポイントから読み取るように、保護されたスレッド コンテキストを作成します。

**手順 1: ネットワーク エンドポイントの ID を取得する**

```csharp
Uri resourceURI = new Uri("http://contoso.com/stockData.xml");

Windows.Networking.HostName hostName =
    new Windows.Networking.HostName(resourceURI.Host);

string identity = await ProtectionPolicyManager.
    GetPrimaryManagedIdentityForNetworkEndpointAsync(hostName);
```

エンドポイントがポリシーによって管理されていない場合、空の文字が返されます。

> **API** <br>
[ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getprimarymanagedidentityfornetworkendpointasync.aspx)


**手順 2: 保護されたスレッド コンテキストを作成する**

エンドポイントがポリシーによって管理されている場合は、保護されたスレッド コンテキストを作成します。 これにより、同じスレッドで確立されるネットワーク接続が、ID にタグ付けされます。

また、そのポリシーによって管理されている企業のネットワーク リソースにアクセスすることもできます。

```csharp
HttpClient client = null;

if (!string.IsNullOrEmpty(identity))
{
    using (ThreadNetworkContext threadNetworkContext =
            ProtectionPolicyManager.CreateCurrentThreadNetworkContext(identity))
    {
        client = new HttpClient();

        // Add code here to get data from the endpoint.
    }
}
```
この例では、ソケット呼び出しが ``using`` ブロック内に指定されています。 これを行わない場合は、リソースを取得した後で、スレッド コンテキストを必ず閉じてください。 「[ThreadNetworkContext.Close](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.threadnetworkcontext.close.aspx)」をご覧ください。

この保護されたスレッド上には個人用ファイルを作成しないでください。それらのファイルは自動的に暗号化されるためです。

[**ProtectionPolicyManager.CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx) メソッドは、エンドポイントがポリシーによって管理されているかどうかに関係なく、[**ThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.threadnetworkcontext.aspx) オブジェクトを返します。 アプリで個人のリソースと企業のリソースの両方を処理する場合は、すべての ID に対して [**ProtectionPolicyManager.CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx) を呼び出してください。  リソースを取得したら、ThreadNetworkContext を破棄して、現在のスレッドからすべての ID タグを消去します。

> **API** <br>
[ProtectionPolicyManager.GetForCurrentView](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[ProtectionPolicyManager.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)<br>
[ProtectionPolicyManager.CreateCurrentThreadNetworkContext](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx)

**手順 3: リソースをバッファーに読み取る**

```csharp
IBuffer data = await client.GetBufferAsync(resourceURI);
```


**ページのリダイレクトを処理する**

Web サーバーは、トラフィックをより最新バージョンのリソースにリダイレクトする場合があります。

これを処理するには、要求の応答状態の値が **OK** になるまで要求を行います。

その後で、その応答の URI を使用して、エンドポイントの ID を取得します。 その方法の 1 つを次に示します。

```csharp
public static async Task<IBuffer> getDataFromNetworkResource(Uri resourceURI)
{
    bool finalURL = false;

    HttpResponseMessage response = null;

    while (!finalURL)
    {

        Windows.Networking.HostName hostName =
            new Windows.Networking.HostName(resourceURI.Host);

        string identity = await ProtectionPolicyManager.
            GetPrimaryManagedIdentityForNetworkEndpointAsync(hostName);

        HttpClient client = null;

        HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
        filter.AllowAutoRedirect = false;

        if (!string.IsNullOrEmpty(m_EnterpriseId))
        {
            using (ThreadNetworkContext threadNetworkContext =
                    ProtectionPolicyManager.CreateCurrentThreadNetworkContext(identity))
            {
                client = new HttpClient(filter);
            }
        }
        else
        {
            client = new HttpClient(filter);
        }
        HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, resourceURI);
        response = await client.SendRequestAsync(message);

        if (response.StatusCode == HttpStatusCode.MultipleChoices &&
            response.StatusCode == HttpStatusCode.MovedPermanently &&
            response.StatusCode == HttpStatusCode.Found &&
            response.StatusCode == HttpStatusCode.SeeOther &&
            response.StatusCode == HttpStatusCode.NotModified &&
            response.StatusCode == HttpStatusCode.UseProxy &&
            response.StatusCode == HttpStatusCode.TemporaryRedirect &&
            response.StatusCode == HttpStatusCode.PermanentRedirect)
        {
            resourceURI = message.RequestUri;
        }
        else
        {
            finalURL = true;
        }
    }

    IBuffer data = await response.Content.ReadAsBufferAsync();

    return data;

}
```

> **API** <br>
[ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getprimarymanagedidentityfornetworkendpointasync.aspx)<br>
[ProtectionPolicyManager.CreateCurrentThreadNetworkContext](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx)<br>
[ProtectionPolicyManager.GetForCurrentView](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[ProtectionPolicyManager.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)

### クリップボードからデータを読み取る

**クリップボードからのデータを使用するアクセス許可を取得する**

クリップボードからデータを取得するには、アクセス許可を Windows に要求します。 そのためには、[**DataPackageView.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706645.aspx) を使用します。

```csharp
public static async Task PasteText(TextBox textBox)
{
    DataPackageView dataPackageView = Clipboard.GetContent();

    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        ProtectionPolicyEvaluationResult result = await dataPackageView.RequestAccessAsync();

        if (result == ProtectionPolicyEvaluationResult..Allowed)
        {
            string contentsOfClipboard = await dataPackageView.GetTextAsync();
            textBox.Text = contentsOfClipboard;
        }
    }
}
```

> **API** <br>
[DataPackageView.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/dn706645.aspx)

**クリップボードのデータを使用する機能を非表示にするか、無効にする**

現在のビューにクリップボードのデータを取得するためのアクセス許可があるかどうかを確認します。

アクセス許可がない場合は、ユーザーがクリップボードから情報を貼り付けたり、クリップボードの内容をプレビューしたりするためのコントロールを無効または非表示にすることができます。

```csharp
private bool IsClipboardAllowedAsync()
{
    ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult = ProtectionPolicyEvaluationResult.Blocked;

    DataPackageView dataPackageView = Clipboard.GetContent();

    if (dataPackageView.Contains(StandardDataFormats.Text))

        protectionPolicyEvaluationResult =
            ProtectionPolicyManager.CheckAccess(dataPackageView.Properties.EnterpriseId,
                ProtectionPolicyManager.GetForCurrentView().Identity);

    return (protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.Allowed |
        protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.ConsentRequired);
}
```

> **API** <br>
[ProtectionPolicyEvaluationResult](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicyevaluationresult.aspx)<br>
[ProtectionPolicyManager.GetForCurrentView](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[ProtectionPolicyManager.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)

**ユーザーに対して同意ダイアログ ボックスが表示されないようにする**

新しいドキュメントは、*個人用*でも*企業用*でもありません。 そのドキュメントは、単なる新規のドキュメントです。 ユーザーが企業データをそのドキュメントに貼り付ける場合、Windows によってポリシーが適用され、ユーザーに対して同意ダイアログ ボックスが表示されます。 次のコードを使用すると、このような状況が発生しなくなります。 このタスクは、データの保護に役立つものではありません。 このタスクは、アプリで完全に新規の項目を作成する場合に、同意ダイアログ ボックスがユーザーに表示されなくするためのものです。

```csharp
private async void PasteText(bool isNewEmptyDocument)
{
    DataPackageView dataPackageView = Clipboard.GetContent();

    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        if (!string.IsNullOrEmpty(dataPackageView.Properties.EnterpriseId))
        {
            if (isNewEmptyDocument)
            {
                ProtectionPolicyManager.TryApplyProcessUIPolicy(dataPackageView.Properties.EnterpriseId);
                string contentsOfClipboard = contentsOfClipboard = await dataPackageView.GetTextAsync();
                // add this string to the new item or document here.          

            }
            else
            {
                ProtectionPolicyEvaluationResult result = await dataPackageView.RequestAccessAsync();

                if (result == ProtectionPolicyEvaluationResult.Allowed)
                {
                    string contentsOfClipboard = contentsOfClipboard = await dataPackageView.GetTextAsync();
                    // add this string to the new item or document here.
                }
            }
        }
    }
}
```

> **API** <br>
[DataPackageView.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/dn706645.aspx)<br>
[ProtectionPolicyEvaluationResult](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicyevaluationresult.aspx)<br>
[ProtectionPolicyManager.TryApplyProcessUIPolicy](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.tryapplyprocessuipolicy.aspx)


### 共有コントラクトからデータを読み取る

従業員がアプリで自分の情報を共有するように選んだ場合、アプリではその情報の内容を含んでいる新しい項目が開きます。

前に説明したとおり、新しい項目は*個人用*でも*企業用*でもありません。 単なる新規の項目です。 コードで企業のコンテンツを項目に追加する場合、Windows によってポリシーが適用され、ユーザーに対して同意ダイアログ ボックスが表示されます。 次のコードを使用すると、このような状況が発生しなくなります。

```csharp
protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    bool isNewEmptyDocument = true;
    string identity = "corp.microsoft.com";

    ShareOperation shareOperation = args.ShareOperation;
    if (shareOperation.Data.Contains(StandardDataFormats.Text))
    {
        if (!string.IsNullOrEmpty(shareOperation.Data.Properties.EnterpriseId))
        {
            if (isNewEmptyDocument)
                // If this is a new and empty document, and we're allowed to access
                // the data, then we can avoid popping the consent dialog
                ProtectionPolicyManager.TryApplyProcessUIPolicy(shareOperation.Data.Properties.EnterpriseId);
            else
            {
                // In this case, we can't optimize the workflow, so we just
                // request consent from the user in this case.

                ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult = await shareOperation.Data.RequestAccessAsync();

                if (protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.Allowed)
                {
                    string text = await shareOperation.Data.GetTextAsync();

                    // Do something with that text.
                }
            }
        }
        else
        {
            // If the data has no enterprise identity, then we already have access.
            string text = await shareOperation.Data.GetTextAsync();

            // Do something with that text.
        }

    }

}
```

> **API** <br>
[ProtectionPolicyManager.RequestAccessAsync](https://msdn.microsoft.com/library/windows/apps/dn705789.aspx)<br>
[ProtectionPolicyEvaluationResult](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicyevaluationresult.aspx)<br>
[ProtectionPolicyManager.TryApplyProcessUIPolicy](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.tryapplyprocessuipolicy.aspx)

## 企業データの保護

アプリの外部に送られる企業データを保護します。 データをページ内に表示するとき、データをファイルやネットワーク エンドポイントに保存するとき、または共有コントラクトを使用してデータを保存するときに、データはアプリの外部に送られます。

### <a id="display-data"></a>ページ内に表示されるデータを保護する

データをページ内に表示するとき、Windows に対して、そのデータの種類 (個人用または企業用) を知らせます。 そのためには、現在のアプリ ビューに*タグ*を付けるか、アプリのプロセス全体にタグを付けます。

ビューまたはプロセスにタグを付けるとき、Windows によってポリシーが適用されます。 これにより、アプリで制御できない操作に起因するデータ漏洩を防ぐことができます。 たとえば、コンピューターでユーザーが Ctrl + V キーを使用して、ビューから企業の情報をコピーし、その情報を他のアプリに貼り付けるとします。 Windows では、この操作が行われるのを防ぎます。 また Windows は、共有コントラクトを適用する際にも役立ちます。

**現在のアプリ ビューにタグを付ける**

アプリに複数のビューがあり、一部のビューで企業データを扱い、一部のビューで個人データを扱う場合に、この操作を行います。

```csharp

// tag as enterprise data. "identity" the string that contains the enterprise ID.
// You'd get that from a file, network endpoint, or clipboard data package.
ProtectionPolicyManager.GetForCurrentView().Identity = identity;

// tag as personal data.
ProtectionPolicyManager.GetForCurrentView().Identity = String.Empty();
```

> **API** <br>
[ProtectionPolicyManager.GetForCurrentView](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[ProtectionPolicyManager.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)

**プロセスにタグを付ける**

アプリ内のすべてのビューで 1 種類だけのデータ (個人データまたは企業データ) を扱う場合に、この操作を行います。

これによって、個別にタグ付けされたビューを管理する必要がなくなります。

```csharp


// tag as enterprise data. "identity" the string that contains the enterprise ID.
// You'd get that from a file, network endpoint, or clipboard data package.
bool result =
            ProtectionPolicyManager.TryApplyProcessUIPolicy(identity);

// tag as personal data.
bool result =
            ProtectionPolicyManager.TryApplyProcessUIPolicy(String.Empty());
```

> **API** <br>
[ProtectionPolicyManager.TryApplyProcessUIPolicy](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.tryapplyprocessuipolicy.aspx)

### ファイルでデータを保護する

保護されたファイルを作成し、そのファイルに書き込みを行います。

**手順 1: アプリがエンタープライズ ファイルを作成できるかどうかを確認する**

ID 文字列がポリシーによって管理されており、アプリがポリシーの許可リストに登録されている場合、アプリはエンタープライズ ファイルを作成できます。

```csharp
  if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;
```

> **API** <br>
[ProtectionPolicyManager.IsIdentityManaged](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx)


**手順 2: ファイルを作成し、ID で保護する**

```csharp
StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
StorageFile storageFile = await storageFolder.CreateFileAsync("sample.txt",
    CreationCollisionOption.ReplaceExisting);

FileProtectionInfo fileProtectionInfo =
    await FileProtectionManager.ProtectAsync(storageFile, identity);
```

> **API** <br>
[FileProtectionManager.ProtectAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.protectasync.aspx)

**手順 3: ストリームやバッファーをファイルに書き込む**

*ストリームを書き込む*

```csharp
    if (fileProtectionInfo.Identity == identity &&
        fileProtectionInfo.Status == FileProtectionStatus.Protected)
    {
        var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);

        using (var outputStream = stream.GetOutputStreamAt(0))
        {
            using (var dataWriter = new DataWriter(outputStream))
            {
                dataWriter.WriteString(enterpriseData);
            }
        }

    }
```

*バッファーを書き込む*

```csharp
     if (fileProtectionInfo.Identity == identity &&
         fileProtectionInfo.Status == FileProtectionStatus.Protected)
     {
         var buffer = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
             enterpriseData, Windows.Security.Cryptography.BinaryStringEncoding.Utf8);

         await FileIO.WriteBufferAsync(storageFile, buffer);

      }
```

> **API** <br>
[FileProtectionInfo](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.aspx)<br>
[FileProtectionStatus](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx)<br>



### バック グラウンド プロセスとして、データをファイルで保護する

このコードは、デバイスの画面がロックされている間に実行できます。 管理者が "ロックの背後でのデータ保護 (DPL)" という安全なポリシーを構成した場合、Windows によって、保護されたリソースへのアクセスに必要な暗号化キーがデバイスのメモリから削除されます。 これにより、デバイスを紛失した場合のデータ漏洩を防ぐことができます。 これと同じ機能によって、保護されたファイルのハンドルを閉じたときに、ファイルに関連付けられているキーも削除されます。

ファイルを作成するときに、ファイルのハンドルを開いたままにする方法を使用する必要があります。  

**手順 1: エンタープライズ ファイルを作成できるかどうかを確認する**

使用している ID がポリシーによって管理されており、アプリがポリシーの許可リストに登録されている場合、エンタープライズ ファイルを作成できます。

```csharp
if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;
```

> **API** <br>
[ProtectionPolicyManager.IsIdentityManaged](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx)

**手順 2: ファイルを作成し、ID で保護する**

[**FileProtectionManager.CreateProtectedAndOpenAsync**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.createprotectedandopenasync.aspx) を使用して、保護されたファイルを作成し、そのファイルへの書き込み中はファイルのハンドルを開いたままにしておきます。

```csharp
StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

ProtectedFileCreateResult protectedFileCreateResult =
    await FileProtectionManager.CreateProtectedAndOpenAsync(storageFolder,
        "sample.txt", identity, CreationCollisionOption.ReplaceExisting);
```

> **API** <br>
[FileProtectionManager.CreateProtectedAndOpenAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.createprotectedandopenasync.aspx)

**手順 3: ストリームやバッファーをファイルに書き込む**

この例では、ストリームをファイルに書き込みます。

```csharp
if (protectedFileCreateResult.ProtectionInfo.Identity == identity &&
    protectedFileCreateResult.ProtectionInfo.Status == FileProtectionStatus.Protected)
{
    IOutputStream outputStream =
        protectedFileCreateResult.Stream.GetOutputStreamAt(0);

    using (DataWriter writer = new DataWriter(outputStream))
    {
        writer.WriteString(enterpriseData);
        await writer.StoreAsync();
        await writer.FlushAsync();
    }

    outputStream.Dispose();
}
else if (protectedFileCreateResult.ProtectionInfo.Status == FileProtectionStatus.AccessSuspended)
{
    // Perform any special processing for the access suspended case.
}

```

> **API** <br>
[ProtectedFileCreateResult.ProtectionInfo](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedfilecreateresult.protectioninfo.aspx)<br>
[FileProtectionStatus](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx)<br>
[ProtectedFileCreateResult.Stream](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedfilecreateresult.stream.aspx)<br>

### ファイルの一部を保護する

ほとんどの場合、企業データと個人データを別々に保管するとデータがよりわかりやすく整理されますが、必要に応じてこれらのデータを同じファイルに格納することもできます。 たとえば、Microsoft Outlook では、個人用のメールと共に企業用のメールを 1 つのアーカイブ ファイルに保管できます。

ファイル全体ではなく、企業データを暗号化します。 これにより、MDM から登録解除したり、企業データのアクセス権が失効している場合でも、ユーザーはそのファイルを引き続き使用することができます。 また、アプリでは、どのようなデータを暗号化するかを追跡する必要があります。これにより、アプリでファイルをメモリに読み取るときに、保護するデータを認識することができます。

**手順 1: 企業データを暗号化されたストリームまたはバッファーに追加する**

```csharp
string enterpriseDataString = "<employees><employee><name>Bill</name><social>xxx-xxx-xxxx</social></employee></employees>";

var enterpriseData= Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
        enterpriseDataString, Windows.Security.Cryptography.BinaryStringEncoding.Utf8);

BufferProtectUnprotectResult result =
   await DataProtectionManager.ProtectAsync(enterpriseData, identity);

enterpriseData= result.Buffer;
```

> **API** <br>
[DataProtectionManager.ProtectAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectionmanager.protectasync.aspx)<br>
[BufferProtectUnprotectResult.buffer](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.bufferprotectunprotectresult.buffer.aspx)


**手順 2: 個人データを暗号化されていないストリームまたはバッファーに追加する**

```csharp
string personalDataString = "<recipies><recipe><name>BillsCupCakes</name><cooktime>30</cooktime></recipe></recipies>";

var personalData = Windows.Security.Cryptography.CryptographicBuffer.ConvertStringToBinary(
    personalDataString, Windows.Security.Cryptography.BinaryStringEncoding.Utf8);
```

**手順 3: ストリームやバッファーをファイルに書き込む**

```csharp
StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

StorageFile storageFile = await storageFolder.CreateFileAsync("data.xml",
    CreationCollisionOption.ReplaceExisting);

 // Write both buffers to the file and save the file.

var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);

using (var outputStream = stream.GetOutputStreamAt(0))
{
    using (var dataWriter = new DataWriter(outputStream))
    {
        dataWriter.WriteBuffer(enterpriseData);
        dataWriter.WriteBuffer(personalData);

        await dataWriter.StoreAsync();
        await outputStream.FlushAsync();
    }
}
```

**手順 4: ファイル内の企業データの位置を追跡する**

ファイル内にある企業が所有しているのデータの追跡は、アプリで実行する必要があります。

そのような情報は、ファイルに関連付けられているプロパティ、データベース、またはファイル内のヘッダー テキストに保存できます。

次の例では、その情報を個別の XML ファイルに保存します。

```csharp
StorageFile metaDataFile = await storageFolder.CreateFileAsync("metadata.xml",
   CreationCollisionOption.ReplaceExisting);

await Windows.Storage.FileIO.WriteTextAsync
    (metaDataFile, "<EnterpriseDataMarker start='0' end='" + enterpriseData.Length.ToString() +
    "'></EnterpriseDataMarker>");
```

### ファイルの保護されている部分を読み取る

ファイルから企業データを読み取る方法を次に示します。

**手順 1: ファイル内の企業データの位置を取得する**

```csharp
Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;

 Windows.Storage.StorageFile metaDataFile =
   await storageFolder.GetFileAsync("metadata.xml");

string metaData = await Windows.Storage.FileIO.ReadTextAsync(metaDataFile);

XmlDocument doc = new XmlDocument();

doc.LoadXml(metaData);

uint startPosition =
    Convert.ToUInt16((doc.FirstChild.Attributes.GetNamedItem("start")).InnerText);

uint endPosition =
    Convert.ToUInt16((doc.FirstChild.Attributes.GetNamedItem("end")).InnerText);
```

**手順 2: データ ファイルを開き、保護されていないことを確認する**

```csharp
Windows.Storage.StorageFile dataFile =
    await storageFolder.GetFileAsync("data.xml");

FileProtectionInfo protectionInfo =
    await FileProtectionManager.GetProtectionInfoAsync(dataFile);

if (protectionInfo.Status == FileProtectionStatus.Protected)
    return false;
```

> **API** <br>
[FileProtectionManager.GetProtectionInfoAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.getprotectioninfoasync.aspx)<br>
[FileProtectionInfo](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.aspx)<br>
[FileProtectionStatus](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionstatus.aspx)<br>

**手順 3: ファイルから企業データを読み取る**

```csharp
var stream = await dataFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);

stream.Seek(startPosition);

Windows.Storage.Streams.Buffer tempBuffer = new Windows.Storage.Streams.Buffer(50000);

IBuffer enterpriseData = await stream.ReadAsync(tempBuffer, endPosition, InputStreamOptions.None);
```

**手順 4: 企業データを含んでいるバッファーの暗号化を解除する**

```csharp
DataProtectionInfo dataProtectionInfo =
   await DataProtectionManager.GetProtectionInfoAsync(enterpriseData);

if (dataProtectionInfo.Status == DataProtectionStatus.Protected)
{
    BufferProtectUnprotectResult result = await DataProtectionManager.UnprotectAsync(enterpriseData);
    enterpriseData = result.Buffer;
}
else if (dataProtectionInfo.Status == DataProtectionStatus.Revoked)
{
    // Code goes here to handle this situation. Perhaps, show UI
    // saying that the user's data has been revoked.
}

```

> **API** <br>
[DataProtectionInfo](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectioninfo.aspx)<br>
[DataProtectionManager.GetProtectionInfoAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectionmanager.getstreamprotectioninfoasync.aspx)<br>


### フォルダーでデータを保護する

フォルダーを作成し、保護することができます。 これにより、そのフォルダーに追加したすべての項目は自動的に保護されます。

```csharp
private async Task<bool> CreateANewFolderAndProtectItAsync(string folderName, string identity)
{
    if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;

    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
    StorageFolder newStorageFolder =
        await storageFolder.CreateFolderAsync(folderName);

    FileProtectionInfo fileProtectionInfo =
        await FileProtectionManager.ProtectAsync(newStorageFolder, identity);

    if (fileProtectionInfo.Identity != identity ||
        fileProtectionInfo.Status != FileProtectionStatus.Protected)
    {
        // Protection failed.
        return false;
    }
    return true;
}
```

保護する前に、フォルダーが空であることを確認してください。 項目が既に含まれているフォルダーを保護することはできません。

> **API** <br>
[ProtectionPolicyManager.IsIdentityManaged](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.isidentitymanaged.aspx)<br>
[FileProtectionManager.ProtectAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.protectasync.aspx)<br>
[FileProtectionInfo.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.identity.aspx)<br>
[FileProtectionInfo.Status](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectioninfo.status.aspx)


### ネットワーク エンドポイントでデータを保護する

保護されたスレッド コンテキストを作成し、そのデータを企業のエンドポイントに送信します。  

**手順 1: ネットワーク エンドポイントの ID を取得する**

```csharp
Windows.Networking.HostName hostName =
    new Windows.Networking.HostName(resourceURI.Host);

string identity = await ProtectionPolicyManager.
    GetPrimaryManagedIdentityForNetworkEndpointAsync(hostName);
```

> **API** <br>
[ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getprimarymanagedidentityfornetworkendpointasync.aspx)

**手順 2: 保護されたスレッド コンテキストを作成し、ネットワーク エンドポイントにデータを送信する**

```csharp
HttpClient client = null;

if (!string.IsNullOrEmpty(m_EnterpriseId))
{
    ProtectionPolicyManager.GetForCurrentView().Identity = identity;

    using (ThreadNetworkContext threadNetworkContext =
            ProtectionPolicyManager.CreateCurrentThreadNetworkContext(identity))
    {
        client = new HttpClient();
        HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, resourceURI);
        message.Content = new HttpStreamContent(dataToWrite);

        HttpResponseMessage response = await client.SendRequestAsync(message);

        if (response.StatusCode == HttpStatusCode.Ok)
            return true;
        else
            return false;
    }
}
else
{
    return false;
}
```

> **API** <br>
[ProtectionPolicyManager.GetForCurrentView](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[ProtectionPolicyManager.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)<br>
[ProtectionPolicyManager.CreateCurrentThreadNetworkContext](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.createcurrentthreadnetworkcontext.aspx)

### アプリが共有コントラクトを介して共有しているデータを保護する

ユーザーがアプリからコンテンツを共有できるようにする場合は、共有コントラクトを実装し、[**DataTransferManager.DataRequested**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested) イベントを処理する必要があります。

イベント ハンドラーで、データ パッケージ内に企業の資格情報のコンテキストを設定します。

```csharp
private void OnShareSourceOperation(object sender, RoutedEventArgs e)
{
    // Register the current page as a share source (or you could do this earlier in your app).
    DataTransferManager.GetForCurrentView().DataRequested += OnDataRequested;
    DataTransferManager.ShowShareUI();
}

private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
{
    if (!string.IsNullOrEmpty(this.shareSourceContent))
    {
        var protectionPolicyManager = ProtectionPolicyManager.GetForCurrentView();
        DataPackage requestData = args.Request.Data;
        requestData.Properties.Title = this.shareSourceTitle;
        requestData.Properties.EnterpriseId = protectionPolicyManager.Identity;
        requestData.SetText(this.shareSourceContent);
    }
}
```

> **API** <br>
[ProtectionPolicyManager.GetForCurrentView](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[ProtectionPolicyManager.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)


### 別の場所にコピーしたファイルを保護する

```csharp
private async void CopyProtectionFromOneFileToAnother
    (StorageFile sourceStorageFile, StorageFile targetStorageFile)
{
    bool copyResult = await
        FileProtectionManager.CopyProtectionAsync(sourceStorageFile, targetStorageFile);

    if (!copyResult)
    {
        // Copying failed. To diagnose, you could check the file's status.
        // (call FileProtectionManager.GetProtectionInfoAsync and
        // check FileProtectionInfo.Status).
    }
}
```

> **API** <br>
[FileProtectionManager.CopyProtectionAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.fileprotectionmanager.copyprotectionasync.aspx)<br>


### デバイスの画面がロックされているときに、企業データを保護する

デバイスがロックされているときは、メモリ内の機密データをすべて削除します。 ユーザーがデバイスをロック解除したとき、アプリではデータを安全に元に戻すことができます。

画面がロックされていることをアプリで認識できるように、[**ProtectionPolicyManager.ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccesssuspending.aspx) イベントを処理します。 このイベントは、管理者がロック ポリシーに従って安全なデータ保護を構成している場合にのみ発生します。 Windows では、デバイスにプロビジョニングされたデータ保護キーが一時的に削除されます。 Windows によってこれらのキーが削除されるため、デバイスがロックされている間 (デバイスが所有者の手元にない場合も考えられます)、暗号化されたデータに対して未承認のアクセスができなくなります。  

画面がロック解除されていることをアプリで認識できるように、[**ProtectionPolicyManager.ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccessresumed.aspx) イベントを処理します。 このイベントは、管理者がロック ポリシーに従って安全なデータ保護を構成しているかどうかに関係なく発生します。

#### 画面がロックされているときに、メモリの機密データを削除する

機密データを保護し、保護されたファイル上でアプリが開いていたすべてのファイル ストリームを閉じることによって、システムでは、機密データがメモリ内にキャッシュされなくなります。

次の例では、テキストブロックのコンテンツを暗号化されたバッファーに保存し、そのテキストブロックからコンテンツを削除します。

```csharp
private async void ProtectionPolicyManager_ProtectedAccessSuspending(object sender, ProtectedAccessSuspendingEventArgs e)
{
    Deferral deferral = e.GetDeferral();

    if (ProtectionPolicyManager.GetForCurrentView().Identity != String.Empty)
    {
        IBuffer documentBodyBuffer = CryptographicBuffer.ConvertStringToBinary
           (documentTextBlock.Text, BinaryStringEncoding.Utf8);

        BufferProtectUnprotectResult result = await DataProtectionManager.ProtectAsync
            (documentBodyBuffer, ProtectionPolicyManager.GetForCurrentView().Identity);

        if (result.ProtectionInfo.Status == DataProtectionStatus.Protected)
        {
            this.protectedDocumentBuffer = result.Buffer;
            documentTextBlock.Text = null;
        }
    }

    // Close any open streams that you are actively working with
    // to make sure that we have no unprotected content in memory.

    // Optionally, code goes here to use e.Deadline to determine whether we have more
    // than 15 seconds left before the suspension deadline. If we do then process any
    // messages queued up for sending while we are still able to access them.

    deferral.Complete();
}
```

> **API** <br>
[ProtectionPolicyManager.ProtectedAccessSuspending](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccesssuspending.aspx)<br>
[ProtectionPolicyManager.GetForCurrentView](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[ProtectionPolicyManager.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)</br>
[DataProtectionManager.ProtectAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectionmanager.protectasync.aspx)<br>
[BufferProtectUnprotectResult.buffer](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.bufferprotectunprotectresult.buffer.aspx)<br>
[ProtectedAccessSuspendingEventArgs.GetDeferral](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedaccesssuspendingeventargs.getdeferral.aspx)<br>
[Deferral.Complete](https://msdn.microsoft.com/library/windows/apps/windows.foundation.deferral.complete.aspx)<br>

#### デバイスがロック解除されたときに、機密データを元に戻す

[**ProtectionPolicyManager.ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccessresumed.aspx) は、デバイスがロック解除され、キーがデバイスで再び利用可能になったときに発生します。

[**ProtectedAccessResumedEventArgs.Identities**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectedaccessresumedeventargs.identities.aspx) は、管理者がロック ポリシーに従って安全なデータ保護を構成していない場合に、空のコレクションになります。

次の例では、前の例とは逆の処理を実行します。 バッファーの暗号化を解除し、そのバッファーからテキスト ボックスに情報を戻してから、バッファーを破棄します。

```csharp
private async void ProtectionPolicyManager_ProtectedAccessResumed(object sender, ProtectedAccessResumedEventArgs e)
{
    if (ProtectionPolicyManager.GetForCurrentView().Identity != String.Empty)
    {
        BufferProtectUnprotectResult result = await DataProtectionManager.UnprotectAsync
            (this.protectedDocumentBuffer);

        if (result.ProtectionInfo.Status == DataProtectionStatus.Unprotected)
        {
            // Restore the unprotected version.
            documentTextBlock.Text = CryptographicBuffer.ConvertBinaryToString
                (BinaryStringEncoding.Utf8, result.Buffer);
            this.protectedDocumentBuffer = null;
        }
    }

}
```

> **API** <br>
[ProtectionPolicyManager.ProtectedAccessResumed](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedaccessresumed.aspx)<br>
[ProtectionPolicyManager.GetForCurrentView](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.getforcurrentview.aspx)<br>
[ProtectionPolicyManager.Identity](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.aspx)</br>
[DataProtectionManager.UnprotectAsync](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.dataprotectionmanager.unprotectasync.aspx)<br>
[BufferProtectUnprotectResult.Status](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.bufferprotectunprotectresult.aspx)<br>

## 保護されたコンテンツが無効になった場合の企業データの処理

デバイスが MDM から登録解除されたとき、またはポリシー管理者が企業データへのアクセスを明示的に無効にしたときに、アプリに通知する必要がある場合は、[**ProtectionPolicyManager_ProtectedContentRevoked**](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedcontentrevoked.aspx) イベントを処理します。

次の例では、メール アプリ用の企業のメールボックス内にあるデータが無効になっているかどうかを確認します。

```csharp
private string mailIdentity = "contoso.com";

void MailAppSetup()
{
    ProtectionPolicyManager.ProtectedContentRevoked += ProtectionPolicyManager_ProtectedContentRevoked;
    // Code goes here to set up mailbox for 'mailIdentity'.
}

private void ProtectionPolicyManager_ProtectedContentRevoked(object sender, ProtectedContentRevokedEventArgs e)
{
    if (!new System.Collections.Generic.List<string>(e.Identities).Contains
        (this.mailIdentity))
    {
        // This event is not for our identity.
        return;
    }

    // Code goes here to delete any metadata associated with 'mailIdentity'.
}
```

> **API** <br>
[ProtectionPolicyManager_ProtectedContentRevoked](https://msdn.microsoft.com/library/windows/apps/windows.security.enterprisedata.protectionpolicymanager.protectedcontentrevoked.aspx)<br>

## 関連トピック

[Windows 情報保護 (WIP) API のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)
 

 



<!--HONumber=Nov16_HO1-->


