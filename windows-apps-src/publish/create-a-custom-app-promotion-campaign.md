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
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 7920e2ba2fd4222ba012a98751e35133b36ac334
ms.lasthandoff: 02/07/2017

---

# <a name="create-a-custom-app-promotion-campaign"></a>カスタム アプリ プロモーション キャンペーンの作成



Windows アプリ内で実行される[アプリの広告キャンペーン](create-an-ad-campaign-for-your-app.md)の作成に加えて、他のチャネルを使ってアプリを宣伝することもできます。 たとえば、サード パーティのアプリ マーケティング プロバイダーを使ってアプリを宣伝したり、ソーシャル メディア サイトにアプリのリンクを投稿したりできます。 これらの活動は*カスタム キャンペーン*と呼ばれます。

アプリのカスタム キャンペーンを実行する場合、カスタム キャンペーンごとに異なるキャンペーン ID を含んだ異なる Windows ストア アプリ URL を作成することによって、各キャンペーンの相対的な成果を追跡できます。 Windows 10 を実行しているユーザーがキャンペーン ID を含む URL をクリックすると、対応するカスタム キャンペーンに関連付けられて、そのデータが提供されます。

カスタム キャンペーンに関連付けられる 2 種類の主要なデータがあります。アプリのページ ビューと*コンバージョン*です。 コンバージョンとは、カスタム キャンペーンによって宣伝された URL からアプリの Windows ストアのページをクリックしたユーザーが、結果としてアプリを取得することです。 コンバージョンについて詳しくは、このトピックの「[アプリの取得がコンバージョンとして認められるしくみについて](#understanding-how-app-acquisitions-qualify-as-conversions)」をご覧ください。

次の方法でアプリのカスタム キャンペーンのパフォーマンス データが得られます。

-   アプリがユニバーサル Windows プラットフォーム (UWP) アプリの場合は、[**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt186445) メソッドを使って、コンバージョンの基となるカスタム キャンペーン ID をプログラムによって取得できます。
-   アプリやアドオンのページ ビューとコンバージョンに関するデータは、デベロッパー センター ダッシュボードの[チャネルとコンバージョン レポート](channels-and-conversions-report.md)から表示できます。

> **重要:** このデータは、Windows 10 を実行しているユーザーについてのみ追跡されます。 他のオペレーティング システムを使用しているユーザーも、アプリの内容へのリンクをたどることはできますが、それらのユーザーの活動に関するデータは含まれません。

 

## <a name="example-custom-campaign-scenario"></a>カスタム キャンペーンのシナリオの例


新しいゲームの作成を終えたゲーム開発者がおり、このゲームをこの開発者の以前のゲームのプレーヤーに宣伝したいと考えているとします。 開発者は、自分の Facebook のページで新しいゲームのリリースに関するお知らせを投稿し、その中にこのゲームの Windows ストアのページへのリンクを含めます。 また、Twitter でも多くのプレーヤーがこの開発者をフォローしているため、このゲームの Windows ストアのページへのリンクを含むお知らせをツイートします。

これらの各プロモーション チャネルの成果を追跡するためには、このゲームの Windows ストアのページ用に 2 種類の URL を作成します。

-   Facebook のページに投稿する URL には、カスタム キャンペーン ID `my-facebook-campaign` を含めます。
-   Twitter に投稿する URL には、カスタム キャンペーン ID `my-twitter-campaign` を含めます。

Facebook や Twitter のフォロワーがその URL をクリックすると、それが記録されて対応するカスタム キャンペーンに関連付けられます。 以降、ゲームおよびアドオンの購入に関して要件を満たすものは、カスタム キャンペーンと関連付けられてコンバージョンとして報告されます。

## <a name="understanding-how-app-acquisitions-qualify-as-conversions"></a>アプリの取得がコンバージョンとして認められるしくみについて


*コンバージョン*とは、カスタム キャンペーンによって宣伝された URL からアプリの Windows ストアのページをクリックしたユーザーが、結果としてアプリを取得することです。 デベロッパー センター ダッシュボードの[チャネルとコンバージョン レポート](channels-and-conversions-report.md)でコンバージョンであると認められるシナリオと、[プログラムによってキャンペーン ID を取得する](#programmatically)場合にコンバージョンであると認められるシナリオは異なります。

[チャネルとコンバージョン レポート](channels-and-conversions-report.md)でコンバージョンであると認められるには、次のシナリオが満たされている必要があります。

-   ユーザー (正式な Microsoft アカウントの有無にかかわらない) が、カスタム キャンペーン ID が含まれているアプリの URL をクリックし、アプリの Windows ストアのページにリダイレクトされた。 同じユーザーが、カスタム キャンペーン ID が含まれている Windows ストアの URL を最初にクリックしてから 24 時間以内にアプリを取得する。
-   カスタム キャンペーン ID が含まれている Windows ストアの URL をクリックしたのとは別のコンピューターまたはデバイスでアプリを取得した場合には、ユーザーが正式な Microsoft アカウントを持つ場合に限り、コンバージョンとしてカウントされます。

> **注:** カスタム キャンペーンのコンバージョンとしてカウントされるアプリの取得については、アプリ内で購入されたアドオンも、同じカスタム キャンペーンのコンバージョンとしてカウントされます。
     

アプリに関連付けられているキャンペーン ID をプログラムによって取得するときに、コンバージョンであると認められるには、次の条件を満たす必要があります。

-   ユーザー (正式な Microsoft アカウントの有無にかかわらない) が、カスタム キャンペーン ID が含まれているアプリの URL をクリックし、アプリの Windows ストアのページにリダイレクトされた。 ユーザーがこの URL をクリックした後で、同じ Windows ストア ページ ビューの間にアプリを取得する。
-   ユーザーがページを離れた後で (同じコンピューター/デバイス、またはユーザーが正式な Microsoft アカウントを持つ場合に別のコンピューター/デバイスで) 24 時間以内にページに戻ってアプリを取得した場合、[チャネルとコンバージョン レポート](channels-and-conversions-report.md)ではコンバージョンとして認識されます。 ただし、プログラムによってキャンペーン ID を取得する場合にはコンバージョンとして認められません。

## <a name="embed-a-custom-campaign-id-to-your-apps-windows-store-page-url"></a>アプリの Windows ストアのページの URL にカスタム キャンペーン ID を埋め込む


カスタム キャンペーン ID が含まれているアプリの Windows ストアのページの URL を作成するには、次の手順を実施します。

1.  カスタム キャンペーン用の ID 文字列を作成します。 この文字列は最大 100 文字にできますが、簡単に識別できる短いキャンペーン ID を定義することをお勧めします。 キャンペーン ID 文字列は、チャネルとコンバージョン レポートで他の開発者に表示される場合があることに注意してください。 これは、ユーザーがキャンペーン ID をクリックしてストアに入り、同じセッションで別の開発者のアプリを購入した場合に発生します。 この場合、そのキャンペーン ID の名前が別の開発者に表示されることがあっても、その開発者にはそのキャンペーン ID の最初のクリックによる、その開発者のアプリのコンバージョン数のみが表示されます。 その開発者には、あなたのキャンペーン ID をクリックしたあなたのアプリの購入者数に関するデータは表示されません。
2.  HTML またはプロトコル形式でアプリの Windows ストアのページの URL を取得します。 HTML 形式の URL は、[デベロッパー センター ダッシュボードの **[アプリ ID]** ページ](link-to-your-app.md)で確認できます。
    -   ユーザーがブラウザーでアプリの Windows ストアのページに移るようにする場合は、HTTP 形式を使います (Windows ストア アプリがインストールされている場合は、この URL によって Windows ストア アプリも起動し、アプリの掲載ページが表示されます)。 この URL の形式は **`https://www.microsoft.com/store/apps/*your app name*/*your app ID*`** です。 たとえば、Skype 用の HTTP URL は `https://www.microsoft.com/store/apps/skype/9wzdncrfj364` になります。 HTTP 形式の URL は、Windows 7 以降を実行しているコンピューターとタブレットや Windows Phone 8 以降を実行している携帯電話のブラウザーで、Windows ストアに移動するために使用できることに注意してください。
    -   Windows ストア アプリがインストールされたデバイスやコンピューター上で実行されている他の Windows アプリでアプリを宣伝し、ユーザーが Windows ストア アプリでアプリのページを開くようにする場合は、プロトコル形式を使います。 この URL の形式は **`ms-windows-store://pdp/?PRODUCTID=*your app id*`** です。 たとえば、Skype 用のプロトコル URL は `ms-windows-store://pdp/?PRODUCTID=9wzdncrfj364` になります。
3.  アプリの URL の末尾に次の文字列を追加します。
    -   HTTP 形式の URL の場合は **?cid=`?cid=*my custom campaign ID*`** を追加します。 たとえば、Skype でキャンペーン ID の値が **custom\_campaign** であるキャンペーンを紹介する場合、このキャンペーン ID を含む新しい HTTP URL は `https://www.microsoft.com/store/apps/skype/9wzdncrfj364?cid=custom\_campaign` になります。
    -   プロトコル形式の URL の場合は **`&cid=*my custom campaign ID*`** を追加します。 たとえば、Skype でキャンペーン ID の値が **custom\_campaign** であるキャンペーンを紹介する場合、このキャンペーン ID を含む新しいプロトコル URL は `ms-windows-store://pdp/?PRODUCTID=9wzdncrfj364&cid=custom\_campaign` になります。

## <a name="programmatically-retrieve-the-custom-campaign-id-for-an-app"></a>アプリのカスタム キャンペーン ID をプログラムで取得する


アプリが UWP アプリの場合、アプリに関連付けられているカスタム キャンペーン ID を、[**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt186445) メソッドを使ってプログラムで取得できます。 このメソッドによって、多くの分析シナリオや収益シナリオが可能になります。 たとえば、現在のユーザーが Facebook のキャンペーンによってアプリを見つけた後でアプリを取得したかどうかがわかるので、それに合わせてアプリのエクスペリエンスをカスタマイズできます。 また、サード パーティのアプリ マーケティング プロバイダーを使っている場合は、プロバイダーにデータを送ることができます。

> **注:** [**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt186445) メソッドは、ユーザーがキャンペーン ID が埋め込まれた URL をクリックし、アプリの Windows ストアのページにリダイレクトされ、このページから離れることなくアプリを取得する場合にのみキャンペーン ID 文字列を返します。 ユーザーがこのページから離れ、後で戻ってアプリを取得する場合、**GetAppPurchaseCampaignIdAsync** ではコンバージョンとして認められません。 詳しくは、このトピックの「[コンバージョンについて](#conversions)」をご覧ください。

 

次の例は、[**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt186445) メソッドを使ってアプリのカスタム キャンペーン ID を取得する方法を示しています。 アプリがコンバージョンの一環として取得されていない場合、このメソッドは空の文字列を返します。

``` csharp
string campaignId = await CurrentApp.GetAppPurchaseCampaignIdAsync();
```

``` cpp
HString campaignId;
HRESULT hr = CurrentApp::GetAppPurchaseCampaignIdAsync(campaignId.GetAddressOf());
```

[**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt186445) メソッドは Windows ストアのデータにアクセスします。 このメソッドを使う場合は次のガイドラインに従ってください。

-   呼び出しを完了できるように、非同期動作では、このメソッドの呼び出しをラップします。
-   アプリがまだ Windows ストアに公開されておらず、カスタム キャンペーンをテストする場合、[**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) クラスの代わりに [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) クラスの [**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt187034) メソッドを使います。 次のガイドラインに従ってください。
    -   次の例に示すように、WindowsStoreProxy.xml ファイルに **AppPurchaseCampaignId** 要素を追加します。 この要素の値にカスタム キャンペーン ID を割り当てます。 アプリを実行すると、[**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt187034) メソッドは常にこの値を返します。 WindowsStoreProxy.xml ファイルについて詳しくは、[**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) のドキュメントをご覧ください。

    ```        XML
    <CurrentApp>
        ....
        <AppPurchaseCampaignId>your custom campaign ID</AppPurchaseCampaignId>
    </CurrentApp>
    ```

    -   [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) と [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) の使用を簡単に切り替えるために、コードに次のステートメントを追加して **Store** エイリアスを定義し、[**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt187034) の呼び出しを **Store** エイリアスで修飾することをお勧めします。

    ```        CSharp
    #if DEBUG
            using Store = Windows.ApplicationMode.Store.CurrentAppSimulator;
            #else
            using Store = Windows.ApplicationMode.Store.CurrentApp;
            #endif   
    ```

## <a name="test-your-custom-campaign"></a>カスタム キャンペーンをテストする


カスタム キャンペーンの URL を宣伝する前に、次の手順でカスタム キャンペーンをテストすることをお勧めします。

1.  テストに使用するコンピューターまたはデバイスで Microsoft アカウントにサインインします。
2.  カスタム キャンペーンの URL をクリックします。 Windows ストアでアプリのページが正しく読み込まれることを確認し、Windows ストア アプリまたはブラウザーのページを閉じます。
3.  さらに URL を数回クリックします。アプリのページに移動した後は、毎回 Windows ストア アプリまたはブラウザーのページを閉じます。 アプリのページに移動したいずれかのときに、アプリを取得してコンバージョンを生成します。 URL をクリックした合計回数を覚えておきます。
4.  アプリでカスタム キャンペーン ID をプログラムによって取得している場合は、[**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) クラスの代わりに [**CurrentAppSimulator**](https://msdn.microsoft.com/library/windows/apps/hh779766) クラスの [**GetAppPurchaseCampaignIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt187034) メソッドを使ってこの動作をテストします。

 

 

