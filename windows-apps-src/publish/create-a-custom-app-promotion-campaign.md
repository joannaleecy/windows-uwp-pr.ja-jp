---
author: shawjohn
Description: "Windows アプリ内で実行されるアプリの広告キャンペーンの作成に加えて、他のチャネルを使ってアプリを宣伝することもできます。"
title: "カスタム アプリ プロモーション キャンペーンの作成"
ms.assetid: 7C9BF73E-B811-4FC7-B1DD-4A0C2E17E95D
ms.author: johnshaw
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、カスタム、アプリ、プロモーション、キャンペーン"
ms.openlocfilehash: 1e56b1df4b5501ded5db799c3ad67f97c0e1cfcd
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="create-a-custom-app-promotion-campaign"></a>カスタム アプリ プロモーション キャンペーンの作成

Windows アプリ内で実行される[アプリの広告キャンペーン](create-an-ad-campaign-for-your-app.md)の作成に加えて、他のチャネルを使ってアプリを宣伝することもできます。 たとえば、サード パーティのアプリ マーケティング プロバイダーを使ってアプリを宣伝したり、ソーシャル メディア サイトにアプリのリンクを投稿したりできます。 これらの活動は*カスタム キャンペーン*と呼ばれます。

アプリのカスタム キャンペーンを実行する場合、カスタム キャンペーンごとに異なるキャンペーン ID を含んだ異なる Windows ストア アプリ URL を作成することによって、各キャンペーンの相対的な成果を追跡できます。 Windows 10 を実行しているユーザーがキャンペーン ID を含む URL をクリックすると、対応するカスタム キャンペーンに関連付けられて、そのデータが提供されます。

カスタム キャンペーンに関連付けられる 2 種類の主要なデータがあります。アプリのページ ビューと*コンバージョン*です。 コンバージョンとは、カスタム キャンペーンによって宣伝された URL からアプリの Windows ストアのページをクリックしたユーザーが、結果としてアプリを取得することです。 コンバージョンについて詳しくは、このトピックの「[アプリの取得がコンバージョンとして認められるしくみについて](#understanding-how-app-acquisitions-qualify-as-conversions)」をご覧ください。

次の方法でアプリのカスタム キャンペーンのパフォーマンス データが得られます。

* アプリやアドオンのページ ビューとコンバージョンに関するデータは、デベロッパー センター ダッシュボードの[チャネルとコンバージョン レポート](channels-and-conversions-report.md)から表示できます。
* アプリがユニバーサル Windows プラットフォーム (UWP) アプリの場合は、Windows SDK の API を使って、コンバージョンの基となるカスタム キャンペーン ID をプログラムによって取得できます。

> **重要:**&nbsp;&nbsp;このデータは、Windows 10 を実行しているユーザーについてのみ追跡されます。 他のオペレーティング システムを使用しているユーザーも、アプリの内容へのリンクをたどることはできますが、それらのユーザーの活動に関するデータは含まれません。

## <a name="example-custom-campaign-scenario"></a>カスタム キャンペーンのシナリオの例

新しいゲームの作成を終えたゲーム開発者がおり、このゲームをこの開発者の以前のゲームのプレーヤーに宣伝したいと考えているとします。 開発者は、自分の Facebook のページで新しいゲームのリリースに関するお知らせを投稿し、その中にこのゲームの Windows ストアのページへのリンクを含めます。 また、Twitter でも多くのプレーヤーがこの開発者をフォローしているため、このゲームの Windows ストアのページへのリンクを含むお知らせをツイートします。

これらの各プロモーション チャネルの成果を追跡するためには、このゲームの Windows ストアのページ用に 2 種類の URL を作成します。

* Facebook のページに投稿する URL には、カスタム キャンペーン ID `my-facebook-campaign` を含めます。
* Twitter に投稿する URL には、カスタム キャンペーン ID `my-twitter-campaign` を含めます。

Facebook や Twitter のフォロワーがその URL をクリックすると、それが記録されて対応するカスタム キャンペーンに関連付けられます。 以降、ゲームおよびアドオンの購入に関して要件を満たすものは、カスタム キャンペーンと関連付けられてコンバージョンとして報告されます。

<span id="conversions" />
## <a name="understanding-how-app-acquisitions-qualify-as-conversions"></a>アプリの取得がコンバージョンとして認められるしくみについて

*コンバージョン*とは、カスタム キャンペーンによって宣伝された URL からアプリの Windows ストアのページをクリックしたユーザーが、結果としてアプリを取得することです。 デベロッパー センター ダッシュボードの[チャネルとコンバージョン レポート](channels-and-conversions-report.md)でコンバージョンであると認められるシナリオと、[プログラムによってキャンペーン ID を取得する](#programmatically)場合にコンバージョンであると認められるシナリオは異なります。

### <a name="qualifying-conversions-for-the-dashboard-report"></a>ダッシュボード レポートでコンバージョンと認められる条件

[チャネルとコンバージョン レポート](channels-and-conversions-report.md)でコンバージョンであると認められるには、次のシナリオが満たされている必要があります。

* ユーザー (*正式な Microsoft アカウントの有無にかかわらない*) が、カスタム キャンペーン ID が含まれているアプリの URL をクリックし、アプリの Windows ストアのページにリダイレクトされた。 同じユーザーが、カスタム キャンペーン ID が含まれている Windows ストアの URL を最初にクリックしてから 24 時間以内にアプリを取得する。

* カスタム キャンペーン ID が含まれている Windows ストアの URL をクリックしたのとは別のコンピューターまたはデバイスでアプリを取得した場合には、ユーザーが Microsoft アカウントを持つ場合に限り、コンバージョンとしてカウントされます。

> **注:**&nbsp;&nbsp;カスタム キャンペーンのコンバージョンとしてカウントされるアプリの取得については、アプリ内で購入されたアドオンも、同じカスタム キャンペーンのコンバージョンとしてカウントされます。

### <a name="qualifying-conversions-for-programmatically-retrieving-the-campaign-id"></a>プログラムによってキャンペーン ID を取得する場合にコンバージョンと認められる条件

アプリに関連付けられているキャンペーン ID をプログラムによって取得するときに、コンバージョンであると認められるには、次の条件を満たす必要があります。

* **Windows 10 バージョン 1607 以降**を実行しているデバイスの場合: ユーザー (*正式な Microsoft アカウントの有無にかかわらない*) が、カスタム キャンペーン ID が含まれているアプリの URL をクリックし、アプリの Windows ストアのページにリダイレクトされた。 ユーザーがこの URL をクリックした後で、同じ Windows ストア ページ ビューの間にアプリを取得する。

* **Windows 10 バージョン 1511 以前**を実行しているデバイスの場合: *正式な Microsoft アカウントを持つ*ユーザーが、カスタム キャンペーン ID が含まれているアプリの URL をクリックし、アプリの Windows ストアのページにリダイレクトされた。 ユーザーがこの URL をクリックした後で、同じ Windows ストア ページ ビューの間にアプリを取得する。 Windows 10 のこれらのバージョンでは、キャンペーン ID をプログラムによって取得するときに、アプリの取得がコンバージョンであると認められるには、ユーザーが正式な Microsoft アカウントを持っている必要があります。

>**注:**&nbsp;&nbsp;ユーザーがページを離れた後で (同じコンピューター/デバイス、またはユーザーが Microsoft アカウントを持つ場合に別のコンピューター/デバイスで) 24 時間以内にページに戻ってアプリを取得した場合、[チャネルとコンバージョン レポート](channels-and-conversions-report.md)ではコンバージョンとして認識されます。 ただし、プログラムによってキャンペーン ID を取得する場合にはコンバージョンとして認められません。

## <a name="embed-a-custom-campaign-id-to-your-apps-windows-store-page-url"></a>アプリの Windows ストアのページの URL にカスタム キャンペーン ID を埋め込む

カスタム キャンペーン ID が含まれているアプリの Windows ストアのページの URL を作成するには、次の手順を実施します。

1.  カスタム キャンペーン用の ID 文字列を作成します。 この文字列は最大 100 文字にできますが、簡単に識別できる短いキャンペーン ID を定義することをお勧めします。

  >**注:**&nbsp;&nbsp;キャンペーン ID 文字列は、チャネルとコンバージョン レポートで他の開発者に表示される場合があることに注意してください。 これは、ユーザーがキャンペーン ID をクリックしてストアに入り、同じセッションで別の開発者のアプリを購入した場合に発生します。 この場合、そのキャンペーン ID の名前が別の開発者に表示されることがあっても、その開発者にはそのキャンペーン ID の最初のクリックによる、その開発者のアプリのコンバージョン数のみが表示されます。 その開発者には、あなたのキャンペーン ID をクリックしたあなたのアプリの購入者数に関するデータは表示されません。

2.  HTML またはプロトコル形式でアプリの Windows ストアのページの URL を取得します。

    * ユーザーがブラウザーでアプリの Windows ストアのページに移るようにする場合は、HTTP 形式を使います (Windows ストア アプリがインストールされている場合は、この URL によって Windows ストア アプリも起動し、アプリの掲載ページが表示されます)。 この URL の形式は **`https://www.microsoft.com/store/apps/*your app name*/*your app ID*`** です。 たとえば、Skype 用の HTTP URL は `https://www.microsoft.com/store/apps/skype/9wzdncrfj364` になります。 HTML 形式の URL は、[デベロッパー センター ダッシュボードの **[アプリ ID]** ページ](link-to-your-app.md)で確認できます。 HTTP 形式の URL は、Windows 7 以降を実行しているコンピューターとタブレットや Windows Phone 8 以降を実行している携帯電話のブラウザーで、Windows ストアに移動するために使用できることに注意してください。

    * Windows ストア アプリがインストールされたデバイスやコンピューター上で実行されている他の Windows アプリでアプリを宣伝し、ユーザーが Windows ストア アプリでアプリのページを開くようにする場合は、プロトコル形式を使います。 この URL の形式は **`ms-windows-store://pdp/?PRODUCTID=*your app id*`** です。 たとえば、Skype 用のプロトコル URL は `ms-windows-store://pdp/?PRODUCTID=9wzdncrfj364` になります。

3.  アプリの URL の末尾に次の文字列を追加します。

    * HTTP 形式の URL の場合は **?cid=`?cid=*my custom campaign ID*`** を追加します。 たとえば、Skype でキャンペーン ID の値が **custom\_campaign** であるキャンペーンを紹介する場合、このキャンペーン ID を含む新しい HTTP URL は `https://www.microsoft.com/store/apps/skype/9wzdncrfj364?cid=custom\_campaign` になります。

    * プロトコル形式の URL の場合は **`&cid=*my custom campaign ID*`** を追加します。 たとえば、Skype でキャンペーン ID の値が **custom\_campaign** であるキャンペーンを紹介する場合、このキャンペーン ID を含む新しいプロトコル URL は `ms-windows-store://pdp/?PRODUCTID=9wzdncrfj364&cid=custom\_campaign` になります。

<span id="programmatically" />
## <a name="programmatically-retrieve-the-custom-campaign-id-for-an-app"></a>アプリのカスタム キャンペーン ID をプログラムで取得する

アプリが UWP アプリの場合、アプリに関連付けられているカスタム キャンペーン ID を、Windows SDK の API を使ってプログラムで取得できます。 これらの API によって、多くの分析シナリオや収益化シナリオが可能になります。 たとえば、現在のユーザーが Facebook のキャンペーンによってアプリを見つけた後でアプリを取得したかどうかがわかるので、それに合わせてアプリのエクスペリエンスをカスタマイズできます。 また、サード パーティのアプリ マーケティング プロバイダーを使っている場合は、プロバイダーにデータを送ることができます。

これらの API は、ユーザーがキャンペーン ID が埋め込まれた URL をクリックし、アプリの Windows ストアのページにリダイレクトされ、このページから離れることなくアプリを取得する場合にのみキャンペーン ID 文字列を返します。 ユーザーがこのページから離れ、後で戻ってアプリを取得する場合、これらの API では[コンバージョン](#conversions)として認められません。

アプリが対象とする Windows 10 のバージョンに応じて、異なる API が用意されています。

* Windows 10 バージョン 1607 以降: **Windows.Services.Store** 名前空間の [**StoreContext**](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスを使います。 この API を使用するときは、ユーザーが正式な Microsoft アカウントを持っているかどうかに関係なく、[条件を満たしている取得](#conversions)についてカスタム キャンペーン ID を取得できます。
* Windows 10 バージョン 1511 以前の場合: **Windows.ApplicationModel.Store**名前空間の [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.aspx) クラスを使います。 この API を使用するときは、ユーザーが正式な Microsoft アカウントを持っている場合にのみ、[条件を満たしている取得](#conversions)についてカスタム キャンペーン ID を取得できます。

>**注:**&nbsp;&nbsp;**Windows.ApplicationModel.Store** 名前空間は、すべてのバージョンの Windows 10 で利用できますが、アプリが Windows 10 バージョン 1607 以降をターゲットにしている場合は、**Windows.Services.Store** 名前空間の API を使うことをお勧めします。 これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md#choose-namespace)」を参照してください。 次のコード例は、同じプロジェクトで両方の API を使用するコードを構築する方法を示しています。

### <a name="code-example"></a>コードの例

次のコード例は、カスタム キャンペーン ID を取得する方法を示しています。 この例では、[バージョン アダプティブ コード](../debug-test-perf/version-adaptive-code.md)を使用することによって、**Windows.Services.Store** 名前空間と **Windows.ApplicationModel.Store** 名前空間の両方の API のセットを使用しています。 この手順に従うことで、Windows 10 のすべてのバージョンでコードを実行できます。 このコードを使用するには、プロジェクトのターゲット OS のバージョンが、**Windows 10 Anniversary Edition (10.0、ビルド 14394)** 以降である必要があります。ただし、最小 OS バージョンは以前のバージョンにすることができます。

``` csharp
// This example assumes the code file has using statements for
// System.Linq, System.Threading.Tasks, Windows.Data.Json,
// and Windows.Services.Store.
public async Task<string> GetCampaignId()
{
    // Use APIs in the Windows.Services.Store namespace if they are available
    // (the app is running on a device with Windows 10, version 1607, or later).
    if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(
         "Windows.Services.Store.StoreContext"))
    {
        StoreContext context = StoreContext.GetDefault();

        // Try to get the campaign ID for users with a recognized Microsoft account.
        StoreProductResult result = await context.GetStoreProductForCurrentAppAsync();
        if (result.Product != null)
        {
            StoreSku sku = result.Product.Skus.FirstOrDefault(s => s.IsInUserCollection);

            if (sku != null)
            {
                return sku.CollectionData.CampaignId;
            }
        }

        // Try to get the campaign ID from the license data for users without a
        // recognized Microsoft account.
        StoreAppLicense license = await context.GetAppLicenseAsync();
        JsonObject json = JsonObject.Parse(license.ExtendedJsonData);
        if (json.ContainsKey("customPolicyField1"))
        {
            return json["customPolicyField1"].GetString();
        }

        // No campaign ID was found.
        return String.Empty;
    }
    // Fall back to using APIs in the Windows.ApplicationModel.Store namespace instead
    // (the app is running on a device with Windows 10, version 1577, or earlier).
    else
    {
#if DEBUG
        return await Windows.ApplicationModel.Store.CurrentAppSimulator.GetAppPurchaseCampaignIdAsync();
#else
        return await Windows.ApplicationModel.Store.CurrentApp.GetAppPurchaseCampaignIdAsync() ;
#endif
    }
}
```

このコードは、次の処理を実行します。

1. まず、現在のデバイスで **Windows.Services.Store** 名前空間の [**StoreContext**](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスが利用可能かどうか (つまり、デバイスで Windows 10 バージョン1607 以降が実行されているかどうか) を確認します。 利用可能な場合、コードはこのクラスを使って処理を進めます。

2. 次に、現在のユーザーが正式な Microsoft アカウントを持っている場合は、カスタム キャンペーン ID の取得を試行します。 これを行うために、コードは、現在のアプリの SKU を表す [**StoreSku**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreSku) オブジェクトを取得した後、[**CampaignId**](https://docs.microsoft.com/uwp/api/windows.services.store.storecollectiondata#Windows_Services_Store_StoreCollectionData_CampaignId) プロパティにアクセスしてキャンペーン ID (利用可能な場合) を取得します。

2. 次に、コードは、現在のユーザーが正式な Microsoft アカウントを持っていない場合のキャンペーン ID の取得を試行します。 この場合、キャンペーン ID はアプリのライセンスに埋め込まれています。 コードは、[**GetAppLicenseAsync**](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext#Windows_Services_Store_StoreContext_GetAppLicenseAsync) メソッドを使用してライセンスを取得した後、ライセンスの JSON コンテンツを解析して *customPolicyField1* というキーの値を取得します。 この値にキャンペーン ID が含まれています。

3. **Windows.Services.Store** 名前空間の [**StoreContext**](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスが利用できない場合、コードは、**Windows.ApplicationModel.Store** 名前空間 (この名前空間は、バージョン 1511 以前を含め、Windows 10 のすべてのバージョンで利用できます) の [**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.currentapp.getapppurchasecampaignidasync.aspx) メソッドを使用する方法にフォールバックして、カスタム キャンペーン ID を取得します。 このメソッドを使用するときは、ユーザーが正式な Microsoft アカウントを持っている場合にのみ、[条件を満たしている取得](#conversions)についてカスタム キャンペーン ID を取得できることに注意してください。

  >**注:**&nbsp;&nbsp;**Windows.ApplicationModel.Store** 名前空間には [**CurrentAppSimulator**](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator) が含まれています。これは、ストアにアプリを提出する前に、ストアの操作をシミュレートしてコードをテストするための特別なクラスです。 このクラスは、[Windows.StoreProxy.xml ファイルという名前のローカル ファイル](../monetize/in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#using-the-windowsstoreproxyxml-file-with-currentappsimulator)からデータを取得します。 前のコード例は、プロジェクトのデバッグおよび非デバッグ コードに **CurrentApp** と **CurrentAppSimulator** の両方を含める方法を示しています。 デバッグ環境でこのコードをテストするには、次の例のように、開発用コンピューターの WindowsStoreProxy.xml ファイルに **AppPurchaseCampaignId** 要素を追加します。 アプリを実行すると、[**GetAppPurchaseCampaignIdAsync**](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator#Windows_ApplicationModel_Store_CurrentAppSimulator_GetAppPurchaseCampaignIdAsync) メソッドは常にこの値を返します。

  ``` xml
  <CurrentApp>
      ...
      <AppPurchaseCampaignId>your custom campaign ID</AppPurchaseCampaignId>
  </CurrentApp>
  ```

  >**注:**&nbsp;&nbsp;**Windows.Services.Store** 名前空間には、テスト中にライセンス情報をシミュレートするために使用できるクラスが用意されていません。 代わりに、アプリをストアに公開し、そのアプリを開発用デバイスにダウンロードして、そのライセンスをテストに使用する必要があります。 詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md#testing)」をご覧ください。

## <a name="test-your-custom-campaign"></a>カスタム キャンペーンをテストする

カスタム キャンペーンの URL を宣伝する前に、次の手順でカスタム キャンペーンをテストすることをお勧めします。

1.  テストに使用するコンピューターまたはデバイスで Microsoft アカウントにサインインします。
2.  カスタム キャンペーンの URL をクリックします。 Windows ストアでアプリのページが正しく読み込まれることを確認し、Windows ストア アプリまたはブラウザーのページを閉じます。
3.  さらに URL を数回クリックします。アプリのページに移動した後は、毎回 Windows ストア アプリまたはブラウザーのページを閉じます。 アプリのページに移動したいずれかのときに、アプリを取得してコンバージョンを生成します。 URL をクリックした合計回数を覚えておきます。
4. 予想されたページ ビューとコンバージョンが[チャネルとコンバージョン レポート](channels-and-conversions-report.md)に表示されるかどうかを確認し、アプリのコードをテストしてキャンペーン ID を正常に取得できるかどうかを確認します。
