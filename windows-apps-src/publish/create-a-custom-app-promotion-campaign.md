---
description: Windows アプリ内で実行されるアプリの広告キャンペーンの作成に加えて、他のチャネルを使ってアプリを宣伝することができます。
title: カスタム アプリ プロモーション キャンペーンの作成
ms.assetid: 7C9BF73E-B811-4FC7-B1DD-4A0C2E17E95D
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10、UWP、カスタム、アプリ、プロモーション、キャンペーン
ms.localizationpriority: medium
ms.openlocfilehash: 407a34294155e688e672db392c262e1607c01a39
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653737"
---
# <a name="create-a-custom-app-promotion-campaign"></a>カスタム アプリ プロモーション キャンペーンの作成

Windows アプリ内で実行される[アプリの広告キャンペーン](create-an-ad-campaign-for-your-app.md)の作成に加えて、他のチャネルを使ってアプリを宣伝することもできます。 たとえば、サード パーティのアプリ マーケティング プロバイダーを使ってアプリを宣伝したり、ソーシャル メディア サイトにアプリのリンクを投稿したりできます。 これらの活動は*カスタム キャンペーン*と呼ばれます。

アプリのカスタム キャンペーンを実行する場合、カスタム キャンペーンごとに異なる*キャンペーン ID* を含んだ異なる URL を作成することによって、各キャンペーンの相対的な成果を追跡できます。 Windows 10 を実行しているお客様は、キャンペーンの ID を含む URL をクリックすると、Microsoft のクリックを対応するカスタム キャンペーンに関連付けられでこのデータを使用できるように[パートナー センター](https://partner.microsoft.com/dashboard)します。

> [!IMPORTANT]
> このデータは、Windows 10 でのみお客様に追跡されます。 他のオペレーティング システムを使用しているユーザーも、アプリの登録情報へのリンクをたどることはできますが、それらのユーザーの活動に関するデータは含まれません。

カスタム キャンペーンに関連付けられる 2 種類の主要なデータがあります。アプリの Store 登録情報の*ページ ビュー*と*コンバージョン*です。 コンバージョンとは、カスタム キャンペーン ID を含む URL からアプリのストア登録情報ページを閲覧したユーザーが、結果としてアプリを取得することです。 コンバージョンについて詳しくは、このトピックの「[アプリの取得がコンバージョンとして認められるしくみについて](#understanding-how-acquisitions-qualify-as-conversions)」をご覧ください。

次の方法でアプリのカスタム キャンペーンのパフォーマンス データが得られます。

* ページ ビューと、アプリやアドオンからの変換に関するデータを表示することができます、**アプリ ページのビューとキャンペーン ID によって変換**と**キャンペーンの変換の合計**でグラフが、[買収レポート](acquisitions-report.md)します。
* アプリがユニバーサル Windows プラットフォーム (UWP) アプリの場合は、Windows SDK の API を使って、コンバージョンの基となるカスタム キャンペーン ID をプログラムによって取得できます。

## <a name="example-custom-campaign-scenario"></a>カスタム キャンペーンのシナリオの例

新しいゲームの作成を終えたゲーム開発者がおり、このゲームをこの開発者の以前のゲームのプレーヤーに宣伝したいと考えているとします。 開発者は、自分の Facebook のページで新しいゲームのリリースに関するお知らせを投稿し、その中にこのゲームの Store 登録情報へのリンクを含めます。 また、Twitter でも多くのプレーヤーがこの開発者をフォローしているため、このゲームの Store 登録情報へのリンクを含むお知らせをツイートします。

これらの各プロモーション チャネルの成果を追跡するためには、このゲームの Store 登録情報への URL を 2 種類作成します。

* 彼女は自分の Facebook ページに投稿が URL にキャンペーンのカスタム ID が含まれています `my-facebook-campaign`

* Twitter に投稿彼女は URL にキャンペーンのカスタム ID が含まれています `my-twitter-campaign`

Facebook や Twitter のフォロワーがその URL をクリックすると、それが記録されて対応するカスタム キャンペーンに関連付けられます。 以降、ゲームおよびアドオンの購入に関して要件を満たすものは、カスタム キャンペーンと関連付けられてコンバージョンとして報告されます。

<span id="conversions" />

## <a name="understanding-how-acquisitions-qualify-as-conversions"></a>取得がコンバージョンとして認められるしくみについて

カスタム キャンペーンの*コンバージョン*とは、カスタム キャンペーンによって宣伝された URL をクリックしたユーザーが、結果としてアプリを取得することです。 変換として修飾するさまざまなシナリオがある、**アプリ ページのビューとキャンペーン ID によって変換**と**キャンペーンの変換の合計**でグラフが、[買収レポート](acquisitions-report.md)との変換として修飾[キャンペーン ID をプログラムで取得する](#programmatically)します。

### <a name="qualifying-conversions-in-the-acquisitions-report"></a>修飾買収レポートでの変換

[[取得] レポート](acquisitions-report.md)の **[キャンペーン ID ごとのアプリ ページ ビューとコンバージョン]** グラフと **[キャンペーンのコンバージョン合計]** グラフで、コンバージョンとして認められるシナリオは次のとおりです。

* ユーザー (*認識されている Microsoft アカウントを使っているかどうかにかかわらない*) が、カスタム キャンペーン ID が含まれているアプリの URL をクリックし、アプリのストア登録情報のページにリダイレクトされ、 その後、同じユーザーが、カスタム キャンペーン ID が含まれている Microsoft Store の URL を最初にクリックしてから 24 時間以内にアプリを取得している。

* カスタム キャンペーン ID が含まれている Windows ストアの URL をクリックしたのとは別のデバイスでアプリを取得した場合には、URL をクリックしたときと同じ Microsoft アカウントを使ってユーザーがサインインしている場合に限り、コンバージョンとしてカウントされる。

> [!NOTE]
> カスタム キャンペーンのコンバージョンとしてカウントされるアプリの取得については、アプリ内で購入されたアドオンも、同じカスタム キャンペーンのコンバージョンとしてカウントされます。

### <a name="qualifying-conversions-when-programmatically-retrieving-the-campaign-id"></a>プログラムによってキャンペーン ID を取得する場合にコンバージョンと認められる条件

アプリに関連付けられているキャンペーン ID をプログラムによって取得するときに、コンバージョンであると認められるには、次の条件を満たす必要があります。

* 実行しているデバイスで**Windows 10 バージョン 1607、またはそれ以降**:顧客 (かどうか、認識されている Microsoft アカウントにサインイン) かどうかをカスタム キャンペーン ID を含み、アプリのストアの一覧ページにリダイレクト URL をクリックします。 URL をクリックした結果としてストア登録情報を閲覧している最中にアプリを取得している。

* 実行しているデバイスで**Windows 10 バージョン 1511、またはそれ以前**:(認識されている Microsoft アカウントを使用して署名する必要があります) を行った顧客をカスタム キャンペーン ID を含み、アプリのストアの一覧ページにリダイレクト URL をクリックします。 URL をクリックした結果としてストア登録情報を閲覧している最中にアプリを取得している。 Windows 10 のこれらのバージョンでは、キャンペーン ID をプログラムによって取得するときに、アプリの取得がコンバージョンであると認められるには、認識されている Microsoft アカウントを使ってユーザーがサインインしている必要があります。

> [!NOTE]
> ユーザーがストア登録情報ページから離れても、(同じデバイスを使うか、別のデバイスの場合は同じ Microsoft アカウントでサインインした状態で) 24 時間以内にページに再びアクセスし、アプリを取得した場合、これは [[取得] レポート](acquisitions-report.md)の **[キャンペーン ID ごとのアプリ ページ ビューとコンバージョン]** グラフと **[キャンペーンのコンバージョン合計]** グラフでコンバージョンとして**認められます**。 ただし、プログラムによってキャンペーン ID を取得した場合にはコンバージョンとして**認められません**。

## <a name="embed-a-custom-campaign-id-to-your-apps-microsoft-store-page-url"></a>アプリの Microsoft Store のページの URL にカスタム キャンペーン ID を埋め込む

カスタム キャンペーン ID が含まれているアプリの Microsoft Store のページの URL を作成するには、次の手順を実施します。

1.  カスタム キャンペーン用の ID 文字列を作成します。 この文字列は最大 100 文字にできますが、簡単に識別できる短いキャンペーン ID を定義することをお勧めします。

   > [!NOTE]
   > キャンペーン ID 文字列は、他の開発者がその開発者のアプリの [[取得] レポート](acquisitions-report.md)を閲覧するときに、表示される場合があります。 これは、ユーザーがカスタム キャンペーン ID をクリックしてストアに入り、同じセッション中に別の開発者のアプリを購入した場合、つまり、そのコンバージョンにそのカスタム キャンペーン ID が寄与した場合に発生します。 その開発者には、最初にこのキャンペーン ID をクリックした結果として発生したその開発者のアプリのコンバージョン数とキャンペーン ID の名前が表示されますが、このキャンペーン ID をクリックしてキャンペーン ID の所有者 (またはその他の開発者) のアプリを購入したユーザー数についてのデータは表示されません。

2.  HTML またはプロトコル形式でアプリの Store 登録情報のリンクを取得します。

    * どのオペレーティング システムであっても、ユーザーがブラウザーからアプリの Web ベースのストア登録情報に移動できるようにするには、HTML URL を使います。 Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。 この URL の形式は **`https://www.microsoft.com/store/apps/*your app ID*`** です。 たとえば、Skype 用の HTML URL は `https://www.microsoft.com/store/apps/9wzdncrfj364` になります。 この URL は、[[アプリ ID]](view-app-identity-details.md#link-to-your-apps-listing) ページで確認できます。

    * UWP アプリがインストールされたデバイスやコンピューター上で実行されている他の Windows アプリ内でアプリを宣伝するか、ユーザーが Microsoft Store をサポートするデバイスを使用していることが確かな場合は、プロトコル形式を使います。 このリンクは、ブラウザーを開かずに直接アプリのストア登録情報に移動します。 この URL の形式は **`ms-windows-store://pdp/?PRODUCTID=*your app id*`** です。 たとえば、Skype 用のプロトコル URL は `ms-windows-store://pdp/?PRODUCTID=9wzdncrfj364` になります。

3.  アプリの URL の末尾に次の文字列を追加します。

    * HTML 形式の URL の場合は **?cid=`?cid=*my custom campaign ID*`** を追加します。 たとえば、Skype の紹介、値を持つキャンペーン ID**カスタム\_キャンペーン**、キャンペーンの id を含む新しい URL:`https://www.microsoft.com/store/apps/skype/9wzdncrfj364?cid=custom\_campaign`します。

    * プロトコル形式の URL の場合は **`&cid=*my custom campaign ID*`** を追加します。 たとえば、Skype の紹介、値を持つキャンペーン ID**カスタム\_キャンペーン**、キャンペーンの id を含む新しいプロトコル URL:`ms-windows-store://pdp/?PRODUCTID=9wzdncrfj364&cid=custom\_campaign`します。

<span id="programmatically" />

## <a name="programmatically-retrieve-the-custom-campaign-id-for-an-app"></a>アプリのカスタム キャンペーン ID をプログラムで取得する

アプリが UWP アプリの場合、アプリの取得に関連付けられているカスタム キャンペーン ID を、Windows SDK の API を使ってプログラムで取得できます。 これらの API によって、多くの分析シナリオや収益化シナリオが可能になります。 たとえば、現在のユーザーが Facebook のキャンペーンによってアプリを見つけた後でアプリを取得したかどうかがわかるので、それに合わせてアプリのエクスペリエンスをカスタマイズできます。 また、サード パーティのアプリ マーケティング プロバイダーを使っている場合は、プロバイダーにデータを送ることができます。

これらの API は、ユーザーがキャンペーン ID が埋め込まれた URL をクリックし、アプリの Microsoft Store のページを閲覧し、Store 登録情報ページから離れることなくアプリを取得する場合にのみキャンペーン ID 文字列を返します。 ユーザーがこのページから離れ、後で戻ってアプリを取得する場合、これらの API では[コンバージョン](#conversions)として認められません。

アプリが対象とする Windows 10 のバージョンに応じて、異なる API が用意されています。

* Windows 10 バージョン 1607、またはそれ以降:使用して、 [ **StoreContext** ](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext)クラス、 **Windows.Services.Store**名前空間。 この API を使用するときは、認識されている Microsoft アカウントを使ってユーザーがサインインしているかどうかに関係なく、[条件を満たしている取得](#conversions)についてカスタム キャンペーン ID を取得できます。

* Windows 10 バージョン 1511、またはそれ以前:使用して、 [ **CurrentApp** ](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp)クラス、 **Windows.ApplicationModel.Store**名前空間。 この API を使用するときは、認識されている Microsoft アカウントを使ってユーザーがサインインしている場合にのみ、[条件を満たしている取得](#conversions)についてカスタム キャンペーン ID を取得できます。

> [!NOTE]
> **Windows.ApplicationModel.Store** 名前空間は、すべてのバージョンの Windows 10 で利用できますが、アプリが Windows 10 バージョン 1607 以降をターゲットにしている場合は、**Windows.Services.Store** 名前空間の API を使うことをお勧めします。 これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md#choose-namespace)」をご覧ください。 次のコード例は、同じプロジェクトで両方の API を使用するコードを構築する方法を示しています。

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

2. 次に、現在のユーザーが認識されている Microsoft アカウントを使っている場合は、カスタム キャンペーン ID の取得を試行します。 これを行うために、コードは、現在のアプリの SKU を表す [**StoreSku**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreSku) オブジェクトを取得した後、[**CampaignId**](https://docs.microsoft.com/uwp/api/windows.services.store.storecollectiondata.CampaignId) プロパティにアクセスしてキャンペーン ID (利用可能な場合) を取得します。
3. 次に、コードは、現在のユーザーが認識されている Microsoft アカウントを使っていない場合のキャンペーン ID の取得を試行します。 この場合、キャンペーン ID はアプリのライセンスに埋め込まれています。 コードは、[**GetAppLicenseAsync**](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.GetAppLicenseAsync) メソッドを使用してライセンスを取得した後、ライセンスの JSON コンテンツを解析して *customPolicyField1* というキーの値を取得します。 この値にキャンペーン ID が含まれています。

4. **Windows.Services.Store** 名前空間の [**StoreContext**](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext) クラスが利用できない場合、コードは、**Windows.ApplicationModel.Store** 名前空間 (この名前空間は、バージョン 1511 以前を含め、Windows 10 のすべてのバージョンで利用できます) の [**GetAppPurchaseCampaignIdAsync**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp#Windows_ApplicationModel_Store_CurrentApp_GetAppPurchaseCampaignIdAsync) メソッドを使用する方法にフォールバックして、カスタム キャンペーン ID を取得します。 このメソッドを使用するときは、ユーザーが正式な Microsoft アカウントを持っている場合にのみ、[条件を満たしている取得](#conversions)についてカスタム キャンペーン ID を取得できることに注意してください。

### <a name="specify-the-campaign-id-in-the-proxy-file-for-the-windowsapplicationmodelstore-namespace"></a>プロキシ ファイルで Windows.ApplicationModel.Store 名前空間のキャンペーン ID を指定します。

**Windows.ApplicationModel.Store** 名前空間には [**CurrentAppSimulator**](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator) が含まれています。これは、ストアにアプリを提出する前に、ストアの操作をシミュレートしてコードをテストするための特別なクラスです。 このクラスは、[Windows.StoreProxy.xml ファイルという名前のローカル ファイル](../monetize/in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#using-the-windowsstoreproxyxml-file-with-currentappsimulator)からデータを取得します。 前のコード例は、プロジェクトのデバッグおよび非デバッグ コードに **CurrentApp** と **CurrentAppSimulator** の両方を含める方法を示しています。 デバッグ環境でこのコードをテストするには、次の例のように、開発用コンピューターの WindowsStoreProxy.xml ファイルに **AppPurchaseCampaignId** 要素を追加します。 アプリを実行すると、[**GetAppPurchaseCampaignIdAsync**](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentappsimulator.GetAppPurchaseCampaignIdAsync) メソッドは常にこの値を返します。

``` xml
<CurrentApp>
    ...
    <AppPurchaseCampaignId>your custom campaign ID</AppPurchaseCampaignId>
</CurrentApp>
```

**Windows.Services.Store** 名前空間には、テスト中にライセンス情報をシミュレートするために使用できるクラスが用意されていません。 代わりに、アプリをストアに公開し、そのアプリを開発用デバイスにダウンロードして、そのライセンスをテストに使用する必要があります。 詳しくは、「[アプリ内購入と試用版](../monetize/in-app-purchases-and-trials.md#testing)」をご覧ください。

## <a name="test-your-custom-campaign"></a>カスタム キャンペーンをテストする

カスタム キャンペーンの URL を宣伝する前に、次の手順でカスタム キャンペーンをテストすることをお勧めします。

1.  テストに使用するデバイスで Microsoft アカウントにサインインします。

2.  カスタム キャンペーンの URL をクリックします。 アプリのページに移動することを確認し、UWP アプリまたはブラウザーのページを閉じます。

3.  さらに URL を数回クリックします。アプリのページに移動した後は、毎回 UWP アプリまたはブラウザーのページを閉じます。 アプリのページに移動した**いずれかのとき**に、アプリを取得してコンバージョンを生成します。 URL をクリックした合計回数を覚えておきます。

4. 予想されるページ ビューとの変換で表示されるかどうかを確認、**アプリ ページのビューとキャンペーン ID によって変換**と**キャンペーンの変換の合計**でグラフが、[買収レポート](acquisitions-report.md)、し、上記で説明した Api を使用して、キャンペーンの ID を正常に取得できるかどうかを確認する、アプリのコードをテストします。
