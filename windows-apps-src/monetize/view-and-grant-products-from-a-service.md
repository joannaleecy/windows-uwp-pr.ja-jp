---
author: mcleanbyron
ms.assetid: B071F6BC-49D3-4E74-98EA-0461A1A55EFB
description: "アプリとアドオンのカタログがある場合は、Windows ストア コレクション API および Windows ストア購入 API を使って、サービスからこれらの製品の所有権情報にアクセスできます。"
title: "サービスから製品の権利を管理する"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, Windows ストア コレクション API, Windows ストア購入 API, 製品の表示, 製品の付与"
ms.openlocfilehash: 1f5930a9917933937a1a0103fe118a2ccdf2d47f
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="manage-product-entitlements-from-a-service"></a>サービスから製品の権利を管理する

アプリとアドオン (アプリ内製品 (IAP) とも呼ばれます) のカタログがある場合は、*Windows ストア コレクション API* および *Windows ストア購入 API* を使って、サービスからこれらの製品の権利情報にアクセスできます。 "権利"** とは、Windows ストアを通じて公開されたアプリまたはアドオンを顧客が使用する権利を表します。

これらの API は、クロスプラットフォーム サービスでサポートされるアドオン カタログを持つ開発者向けに設計された REST メソッドで構成されています。 これらの API を使用すると、次の操作を実行できます。

-   Windows ストア コレクション API: [ユーザーが所有するアプリを照会](query-for-products.md)し、[コンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)する。
-   Windows ストア購入 API: [無料のアプリをユーザーに付与](grant-free-products.md)する。

>**注**&nbsp;&nbsp;Windows ストア コレクション API と Windows ストア購入 API では、Azure Active Directory (Azure AD) 認証を使って顧客の所有権情報にアクセスします。 これらの API を使用するには、ユーザー (またはユーザーの組織) が、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。

## <a name="overview"></a>概要

次の手順は、Windows ストア コレクション API および購入 API を使用するプロセス全体を表したものです。

1.  [Azure AD で Web アプリケーションを構成します](#step-1)。
2.  [Windows デベロッパー センター ダッシュボードで、Azure AD クライアント ID をアプリケーションに関連付けます](#step-2)。
3.  サービスで、発行元 ID を表す [Azure AD アクセス トークンを作成します](#step-3)。
4.  Windows アプリのクライアント側コードで、現在のユーザーの ID を表す [Windows ストア ID キーを作成](#step-4)し、その Windows ストア ID キーをサービスに渡します。
5.  必要な Azure AD のアクセス トークンと Windows ストア ID キーを取得した後、[サービスから Windows ストア コレクション API または Windows ストア購入 API を呼び出します](#step-5)。

以降のセクションでは、これらの各手順についてさらに詳しく説明します。

<span id="step-1"/>
## <a name="step-1-configure-a-web-application-in-azure-ad"></a>手順 1: Azure AD で Web アプリケーションを構成する

Windows ストア コレクション API または購入 API を使うには、事前に Azure AD Web アプリケーションを作成し、そのアプリケーションのテナント ID とクライアント ID を取得して、キーを生成する必要があります。 Azure AD アプリケーションは、Windows ストア コレクション API または購入 API の呼び出し元となるアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。

>**注:**&nbsp;&nbsp;このセクションの作業は 1 回実行する必要があるだけです。 Azure AD アプリケーションのマニフェストを更新し、テナント ID、クライアント ID、クライアント シークレットを取得したら、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらの値を再利用できます。

1.  「[Azure Active Directory とアプリケーションの統合](http://go.microsoft.com/fwlink/?LinkId=722502)」の指示に従って、Azure AD に Web アプリケーションを追加します。

    > **注**&nbsp;&nbsp;**[アプリケーション情報の指定]** ページで、**[Web アプリケーションや Web API]** を選んでいることを確認してください。 これは、アプリケーションのキー ("クライアント シークレット"** とも呼ばれます) を取得するために必要です。 Windows ストア コレクション API または購入 API を呼び出すには、後の手順で Azure AD からアクセス トークンを要求するときにクライアント シークレットを指定する必要があります。

2.  [Azure 管理ポータル](http://manage.windowsazure.com/)で、**Active Directory** に移動します。 ディレクトリを選択し、上部にある **[アプリケーション]** タブをクリックして、アプリケーションを選択します。
3.  **[構成]** タブをクリックします。 このタブで、アプリケーションのクライアント ID を取得し、キー (後の手順ではこれを*クライアント シークレット*と呼びます) を要求します。
4.  画面の下部の **[マニフェストの管理]** をクリックします。 Azure AD アプリケーション マニフェストをダウンロードし、`"identifierUris"` セクションを次のテキストに置き換えます。

    ```json
    "identifierUris" : [                                
            "https://onestore.microsoft.com",
            "https://onestore.microsoft.com/b2b/keys/create/collections",
            "https://onestore.microsoft.com/b2b/keys/create/purchase"
        ],
    ```

    これらの文字列は、アプリケーションでサポートされる対象ユーザーを表します。 後の手順で、各対象ユーザー値に関連付けられた Azure AD アクセス トークンを作成します。 アプリケーション マニフェストをダウンロードする方法について詳しくは、[Azure Active Directory アプリケーション マニフェストの概要に関するページ](http://go.microsoft.com/fwlink/?LinkId=722500)をご覧ください。

5.  アプリケーション マニフェストを保存し、[Azure 管理ポータル](http://manage.windowsazure.com/)でアプリケーションにアップロードします。

<span id="step-2"/>
## <a name="step-2-associate-your-azure-ad-client-id-with-your-app-in-windows-dev-center"></a>手順 2: Windows デベロッパー センターで Azure AD クライアント ID をアプリに関連付ける

Windows ストア コレクション API または Windows ストア購入 API を使ってアプリやアドオンで処理を実行するには、事前にデベロッパー センター ダッシュボードで Azure AD クライアント ID をアプリ (またはアドオンを含むアプリ) に関連付ける必要があります。

>**注**&nbsp;&nbsp;この作業を行うのは一度だけです。

1.  [デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインし、アプリを選択します。
2.  **[サービス]** &gt; **[製品のコレクションと購入]** ページに移動して、利用可能なフィールドの 1 つに Azure AD のクライアント ID を入力します。

<span id="step-3"/>
## <a name="step-3-create-azure-ad-access-tokens"></a>手順 3: Azure AD アクセス トークンを作成する

Windows ストア ID キーを取得したり、Windows ストア コレクション API または Windows ストア購入 API を呼び出したりする前に、発行元 ID を表すいくつかの Azure AD アクセス トークンをサービスで作成する必要があります。 各トークンは別々の API で使われます。 各トークンの有効期間は 60 分であり、有効期限が切れた場合は更新できます。

<span id="access-tokens" />
### <a name="understanding-the-different-tokens-and-audience-uris"></a>さまざまなトークンとオーディエンス URI を理解する

Windows ストア コレクション API または購入 API で呼び出そうとしているメソッドに応じて、2 つまたは 3 つの異なるトークンを作成する必要があります。 各アクセス トークンは、別々のオーディエンス URI に関連付けられます (これらは、以前に Azure AD アプリケーション マニフェストの `"identifierUris"` セクションに追加した URI と同じです)。

  * いずれの場合も、`https://onestore.microsoft.com` オーディエンス URI のトークンを 1 つ作成する必要があります。 このトークンは、後の手順で Windows ストア コレクション API または購入 API のメソッドの **Authorization** ヘッダーに渡します。

  > **重要**&nbsp;&nbsp;`https://onestore.microsoft.com` オーディエンスは、サービス内に安全に格納されたアクセス トークンでのみ使用してください。 このオーディエンスのアクセス トークンがサービス外に公開されると、サービスがリプレイ攻撃に対して脆弱になる可能性があります。

  * Windows ストア コレクション API のメソッドを呼び出して、[特定のユーザーが所有する製品を照会](query-for-products.md)したり、[コンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)したりする場合は、`https://onestore.microsoft.com/b2b/keys/create/collections` オーディエンス URI のトークンも作成する必要があります。 後の手順で、このトークンを Windows SDK のクライアント メソッドに渡し、Windows ストア コレクション API で使用できる Windows ストア ID キーを要求します。

  * Windows ストア購入 API のメソッドを呼び出して[無料の製品をユーザーに付与](grant-free-products.md)する場合は、`https://onestore.microsoft.com/b2b/keys/create/purchase` オーディエンス URI のトークンも作成する必要があります。 後の手順で、このトークンを Windows SDK のクライアント メソッドに渡し、Windows ストア購入 API で使用できる Windows ストア ID キーを要求します。

<span />
### <a name="create-the-tokens"></a>トークンの作成

アクセス トークンを作成するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service)」の手順に従って OAuth 2.0 API をサービスで使用し、HTTP POST を ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` エンドポイントに送信します。 要求の例を次に示します。

``` syntax
POST https://login.microsoftonline.com/<tenant_id>/oauth2/token HTTP/1.1
Host: login.microsoftonline.com
Content-Type: application/x-www-form-urlencoded; charset=utf-8

grant_type=client_credentials
&client_id=<your_client_id>
&client_secret=<your_client_secret>
&resource=https://onestore.microsoft.com
```

各トークンについて、次のパラメーター データを指定します。

* *client\_id* パラメーターと *client\_secret* パラメーターには、[Azure 管理ポータル](http://manage.windowsazure.com)から取得したクライアント ID とアプリケーションのクライアント シークレットを指定します。 これらのパラメーターはいずれも、Windows ストア コレクション API または購入 API で必要とされる認証のレベルに基づいてアクセス トークンを生成するために必要です。

* *resource* パラメーターには、作成するアクセス トークンの種類に応じて、[前のセクション](#access-tokens)に記載したいずれかのオーディエンス URI を指定します。

アクセス トークンの有効期限が切れた後は、[こちらのトピック](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)の手順に従って更新できます。 アクセス トークンの構造について詳しくは、「[サポートされているトークンと要求の種類](http://go.microsoft.com/fwlink/?LinkId=722501)」をご覧ください。

> **重要**&nbsp;&nbsp;Azure AD アクセス トークンは、アプリ内ではなく、サービスのコンテキスト内でのみ作成してください。 このアクセス トークンがアプリに送信されると、クライアント シークレットが侵害される可能性があります。

<span id="step-4"/>
## <a name="step-4-create-a-windows-store-id-key"></a>手順 4: Windows ストア ID キーを生成する

Windows ストア コレクション API または Windows ストア購入 API のメソッドを呼び出すには、事前にアプリで Windows ストア ID キーを作成し、サービスに送信する必要があります。 このキーは、アクセス対象の製品所有権情報を保持するユーザーの ID を表す JSON Web トークン (JWT) です。 このキーの要求について詳しくは、「[Windows ストア ID キー内の要求](#claims)」をご覧ください。

現時点では、Windows ストア ID キーを作成する唯一の方法は、アプリ内のコードからユニバーサル Windows プラットフォーム (UWP) API を呼び出すことです。 生成されたキーは、デバイスで現在 Windows ストアにサインインしているユーザーの ID を表します。

> **注**&nbsp;&nbsp;各 Windows ストア ID キーは 90 日間有効です。 キーの有効期限が切れた場合は、[キーを更新](renew-a-windows-store-id-key.md)できます。 新しい Windows ストア ID キーを作成するのではなく、更新することをお勧めします。

<span />
### <a name="to-create-a-windows-store-id-key-for-the-windows-store-collection-api"></a>Windows ストア コレクション API 用の Windows ストア ID キーを作成するには

[特定のユーザーが所有する製品を照会](query-for-products.md)したり、[てコンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)したりするために、Windows ストア コレクション API で使用できる Windows ストア ID キーを作成するには、次の手順に従います。

1.  `https://onestore.microsoft.com/b2b/keys/create/collections` オーディエンス URI を使って作成した Azure AD アクセス トークンを、サービスからクライアント アプリに渡します。

2.  アプリ コードで次のいずれかのメソッドを呼び出して、Windows ストア ID キーを取得します。

  * アプリで [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスを使ってアプリ内購入を管理する場合は、[StoreContext.GetCustomerCollectionsIdAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getcustomercollectionsidasync.aspx) メソッドを使用します。

  * アプリで [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間の  [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) クラスを使ってアプリ内購入を管理する場合は、[CurrentApp.GetCustomerCollectionsIdAsync](https://msdn.microsoft.com/library/windows/apps/mt608674) メソッドを使用します。

  メソッドの *serviceTicket* パラメーターに、Azure AD アクセス トークンを渡します。 必要に応じて、*publisherUserId* パラメーターに、サービスのコンテキストで現在のユーザーを識別する ID を渡すことができます。 サービス用のユーザー ID を保持している場合は、このパラメーターを使用して、それらのユーザー ID を Windows ストア コレクション API の呼び出しに関連付けることができます。

3.  アプリで正しく Windows ストア ID キーを作成したら、そのキーをサービスに渡します。

<span />
### <a name="to-create-a-windows-store-id-key-for-the-windows-store-purchase-api"></a>Windows ストア購入 API 用の Windows ストア ID キーを作成するには

[無料の製品をユーザーに付与](grant-free-products.md)するために、Windows ストア購入 API で使用できる Windows ストア ID キーを作成するには、次の手順に従います。

1.  `https://onestore.microsoft.com/b2b/keys/create/purchase` オーディエンス URI を使って作成した Azure AD アクセス トークンを、サービスからクライアント アプリに渡します。

2.  アプリ コードで次のいずれかのメソッドを呼び出して、Windows ストア ID キーを取得します。

  * アプリで [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスを使ってアプリ内購入を管理する場合は、[StoreContext.GetCustomerPurchaseIdAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getcustomerpurchaseidasync.aspx) メソッドを使用します。

  * アプリで [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間の [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) クラスを使ってアプリ内購入を管理する場合は、[CurrentApp.GetCustomerPurchaseIdAsync](https://msdn.microsoft.com/library/windows/apps/mt608675) メソッドを使用します。

  メソッドの *serviceTicket* パラメーターに、Azure AD アクセス トークンを渡します。 必要に応じて、*publisherUserId* パラメーターに、サービスのコンテキストで現在のユーザーを識別する ID を渡すことができます。 サービス用のユーザー ID を保持している場合は、このパラメーターを使用して、それらのユーザー ID を Windows ストア購入 API の呼び出しに関連付けることができます。

3.  アプリで正しく Windows ストア ID キーを作成したら、そのキーをサービスに渡します。

<span id="step-5"/>
## <a name="step-5-call-the-windows-store-collection-api-or-purchase-api-from-your-service"></a>手順 5: サービスから Windows ストア コレクション API または Windows ストア購入 API を呼び出す

特定のユーザーの製品所有権情報にアクセスするための Windows ストア ID キーをサービスで取得したら、次の手順に従って、サービスから Windows ストア コレクション API または購入 API を呼び出すことができます。

* [製品の照会](query-for-products.md)
* [コンシューマブルな製品をフルフィルメント完了として報告する](report-consumable-products-as-fulfilled.md)
* [無料の製品の付与](grant-free-products.md)

各シナリオについて、次の情報を API に渡します。

-   前に `https://onestore.microsoft.com` 対象ユーザー URI を使って作成した Azure AD アクセス トークン。 このトークンは発行元 ID を表します。 このトークンを要求ヘッダーで渡します。
-   アプリのクライアント側コードから取得した Windows ストア ID キー。 このキーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表します。

<span id="claims"/>
## <a name="claims-in-a-windows-store-id-key"></a>Windows ストア ID キー内の要求

Windows ストア ID キーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表す JSON Web トークン (JWT) です。 Base64 を使用してデコードされた Windows ストア ID キーには、次の要求が含まれています。

* `iat`:&nbsp;&nbsp;&nbsp;キーが発行された時刻を識別します。 この要求は、トークンの経過期間を判別するために使用できます。 この値はエポック時間で表されます。
* `iss`:&nbsp;&nbsp;&nbsp;発行者を識別します。 これは `aud` 要求と同じ値を持ちます。
* `aud`:&nbsp;&nbsp;&nbsp;オーディエンスを識別します。 `https://collections.mp.microsoft.com/v6.0/keys` または `https://purchase.mp.microsoft.com/v6.0/keys` のいずれかの値である必要があります。
* `exp`:&nbsp;&nbsp;&nbsp;キーがキーの更新以外のどの処理も受け入れられなくなる有効期限を識別します。 この要求の値はエポック時間で表されます。
* `nbf`:&nbsp;&nbsp;&nbsp;トークンの処理が受け入れられる時刻を識別します。 この要求の値はエポック時間で表されます。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/clientId`:&nbsp;&nbsp;&nbsp;開発者を識別するクライアント ID。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/payload`:&nbsp;&nbsp;&nbsp;Windows ストア サービスでのみ使用する情報が含まれている不透明なペイロード (暗号化され、Base64 でエンコード)。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/userId`:&nbsp;&nbsp;&nbsp;サービスのコンテキストで現在のユーザーを識別するユーザー ID。 これは、[キーの作成に使うメソッド](#step-4)の省略可能な *publisherUserId* パラメーターに渡す値と同じです。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/refreshUri`:&nbsp;&nbsp;&nbsp;キーの更新に使用できる URI。

デコードされた Windows ストア ID キー ヘッダーの例を次に示します。

```json
{
    "typ":"JWT",
    "alg":"RS256",
    "x5t":"agA_pgJ7Twx_Ex2_rEeQ2o5fZ5g"
}
```

デコードされた Windows ストア ID キー要求セットの例を次に示します。

```json
{
    "http://schemas.microsoft.com/marketplace/2015/08/claims/key/clientId": "1d5773695a3b44928227393bfef1e13d",
    "http://schemas.microsoft.com/marketplace/2015/08/claims/key/payload": "ZdcOq0/N2rjytCRzCHSqnfczv3f0343wfSydx7hghfu0snWzMqyoAGy5DSJ5rMSsKoQFAccs1iNlwlGrX+/eIwh/VlUhLrncyP8c18mNAzAGK+lTAd2oiMQWRRAZxPwGrJrwiq2fTq5NOVDnQS9Za6/GdRjeiQrv6c0x+WNKxSQ7LV/uH1x+IEhYVtDu53GiXIwekltwaV6EkQGphYy7tbNsW2GqxgcoLLMUVOsQjI+FYBA3MdQpalV/aFN4UrJDkMWJBnmz3vrxBNGEApLWTS4Bd3cMswXsV9m+VhOEfnv+6PrL2jq8OZFoF3FUUpY8Fet2DfFr6xjZs3CBS1095J2yyNFWKBZxAXXNjn+zkvqqiVRjjkjNajhuaNKJk4MGHfk2rZiMy/aosyaEpCyncdisHVSx/S4JwIuxTnfnlY24vS0OXy7mFiZjjB8qL03cLsBXM4utCyXSIggb90GAx0+EFlVoJD7+ZKlm1M90xO/QSMDlrzFyuqcXXDBOnt7rPynPTrOZLVF+ODI5HhWEqArkVnc5MYnrZD06YEwClmTDkHQcxCvU+XUEvTbEk69qR2sfnuXV4cJRRWseUTfYoGyuxkQ2eWAAI1BXGxYECIaAnWF0W6ThweL5ZZDdadW9Ug5U3fZd4WxiDlB/EZ3aTy8kYXTW4Uo0adTkCmdLibw=",
    "http://schemas.microsoft.com/marketplace/2015/08/claims/key/userId": "infusQMLaYCrgtC0d/SZWoPB4FqLEwHXgZFuMJ6TuTY=",
    "http://schemas.microsoft.com/marketplace/2015/08/claims/key/refreshUri": "https://collections.mp.microsoft.com/v6.0/b2b/keys/renew",
    "iat": 1442395542,
    "iss": "https://collections.mp.microsoft.com/v6.0/keys",
    "aud": "https://collections.mp.microsoft.com/v6.0/keys",
    "exp": 1450171541,
    "nbf": 1442391941
}
```

## <a name="related-topics"></a>関連トピック

* [製品の照会](query-for-products.md)
* [コンシューマブルな製品をフルフィルメント完了として報告する](report-consumable-products-as-fulfilled.md)
* [無料の製品の付与](grant-free-products.md)
* [Windows ストア ID キーの更新](renew-a-windows-store-id-key.md)
* [Azure Active Directory とアプリケーションの統合](http://go.microsoft.com/fwlink/?LinkId=722502)
* [Azure Active Directory アプリケーション マニフェストの概要]( http://go.microsoft.com/fwlink/?LinkId=722500)
* [サポートされているトークンと要求の種類](http://go.microsoft.com/fwlink/?LinkId=722501)
