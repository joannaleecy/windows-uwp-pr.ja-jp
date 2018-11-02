---
author: Xansky
ms.assetid: B071F6BC-49D3-4E74-98EA-0461A1A55EFB
description: アプリとアドオンのカタログがある場合は、Microsoft Store コレクション API および Microsoft Store 購入 API を使って、サービスからこれらの製品の所有権情報にアクセスできます。
title: サービスから製品の権利を管理する
ms.author: mhopkins
ms.date: 08/01/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store コレクション API, Microsoft Store 購入 API, 製品の表示, 製品の付与
ms.localizationpriority: medium
ms.openlocfilehash: 41e1437e8b55474d3fcc0c34919e23d14a86ea89
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5940929"
---
# <a name="manage-product-entitlements-from-a-service"></a>サービスから製品の権利を管理する

アプリとアドオンのカタログがある場合は、*Microsoft Store コレクション API* と *Microsoft Store 購入 API* を使って、サービスからこれらの製品の権利の情報にアクセスできます。 "権利"** とは、Microsoft Store を通じて公開されたアプリまたはアドオンを顧客が使用する権利を表します。

これらの API は、クロスプラットフォーム サービスでサポートされるアドオン カタログを持つ開発者向けに設計された REST メソッドで構成されています。 これらの API を使用すると、次の操作を実行できます。

-   Microsoft Store コレクション API: [ユーザーが所有するアプリを照会](query-for-products.md)し、[コンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)する。
-   Microsoft Store 購入 API: [無料のアプリをユーザーに付与する](grant-free-products.md)、[ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)、[ユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)。

> [!NOTE]
> Microsoft Store コレクション API と Microsoft Store 購入 API では、Azure Active Directory (Azure AD) 認証を使って顧客の所有権情報にアクセスします。 これらの API を使用するには、ユーザー (またはユーザーの組織) が、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。

## <a name="overview"></a>概要

次の手順は、Microsoft Store コレクション API および購入 API を使用するプロセス全体を表したものです。

1.  [Azure ad アプリケーションを構成](#step-1)します。
2.  [Windows デベロッパー センター ダッシュ ボードでアプリに、Azure AD アプリケーション ID を関連付けます](#step-2)。
3.  サービスで、発行元 ID を表す [Azure AD アクセス トークンを作成します](#step-3)。
4.  クライアントの Windows アプリを[Microsoft Store ID キーを作成](#step-4)現在のユーザーとキーのパスの id を表す、サービスにバックアップします。
5.  必要な Azure AD のアクセス トークンと Microsoft Store ID キーを取得した後、[サービスから Microsoft Store コレクション API または Microsoft Store 購入 API を呼び出します](#step-5)。

このエンド ツー エンドのプロセスには、さまざまなタスクを実行する 2 つのソフトウェア コンポーネントが含まれます。

* **サービス**です。 これはお客様のビジネス環境のコンテキストで安全に実行されるアプリケーションであり、選択した任意の開発プラットフォームを使用して実装できます。 サービスは、Azure AD アクセス トークンを作成するために必要なシナリオと、Microsoft Store コレクションの残りの部分の Uri を呼び出す API および購入 API を担当します。
* **クライアント Windows アプリ**。 これは、アクセスし、(アプリのアドオンを含む) ユーザー資格情報を管理するアプリです。 このアプリは、Microsoft Store コレクション API を呼び出すし、サービスから API を購入する必要がある Microsoft Store ID キーを作成します。

<span id="step-1"/>

## <a name="step-1-configure-an-application-in-azure-ad"></a>手順 1: Azure ad アプリケーションを構成します。

Microsoft Store コレクション API または購入 API を使う前に、Azure AD Web アプリケーションを作成してテナント ID と、そのアプリケーションのアプリケーション ID を取得してキーを生成する必要があります。 Azure AD Web アプリケーションは、Microsoft Store コレクション API の呼び出しまたは購入 API サービスを表します。 テナント ID、アプリケーション ID およびキー API を呼び出す必要がある Azure AD アクセス トークンを生成する必要があります。

> [!NOTE]
> このセクションの作業は 1 回実行する必要があるだけです。 いつでも新しいを作成する必要があるをこれらの値を再利用することができます、Azure AD アプリケーション マニフェストを更新すると、テナント ID、アプリケーション ID とクライアント シークレットがある場合、Azure AD アクセス トークン。

1.  されている、準備していない場合は、指示に従って[Azure Active Directory とアプリケーションの統合](https://docs.microsoft.com/azure/active-directory/develop/active-directory-integrating-applications)を登録する**Web アプリ/API**と Azure AD アプリケーション。
    > [!NOTE]
    > 選択する必要があります、アプリケーションを登録すると、 **Web アプリ/API**アプリケーション入力できるように、アプリケーションのキー (*クライアント シークレット*とも呼ばれます) を取得することができます。 Microsoft Store コレクション API または購入 API を呼び出すには、後の手順で Azure AD からアクセス トークンを要求するときにクライアント シークレットを指定する必要があります。

2.  [Azure 管理ポータル](https://portal.azure.com/)で、 **Azure Active Directory**に移動します。 ディレクトリを選び、左側のナビゲーション ウィンドウで、**アプリの登録**をクリックし、アプリケーションを選びます。
3.  アプリケーションの登録のメイン ページが表示されます。 このページでは、後で使用の**アプリケーション ID**の値をコピーします。
4.  後で必要となるキーを作成 (これはすべてと呼ばれる*クライアント シークレット*)。 左側のウィンドウで**設定**し、**キー**をクリックします。 このページでは、[キーを作成](https://docs.microsoft.com/azure/active-directory/develop/active-directory-integrating-applications#to-add-application-credentials-or-permissions-to-access-web-apis)する手順を完了します。 後で使うには、このキーをコピーします。
5.  必要ないくつかのオーディエンス Uri を[アプリケーション マニフェスト](https://docs.microsoft.com/azure/active-directory/develop/active-directory-application-manifest)に追加します。 左側のウィンドウでは、**マニフェスト**をクリックします。 [**編集**] を置き換え、`"identifierUris"`セクションを次のテキストと**保存**] をクリックします。

    ```json
    "identifierUris" : [                                
            "https://onestore.microsoft.com",
            "https://onestore.microsoft.com/b2b/keys/create/collections",
            "https://onestore.microsoft.com/b2b/keys/create/purchase"
        ],
    ```

    これらの文字列は、アプリケーションでサポートされる対象ユーザーを表します。 後の手順で、各対象ユーザー値に関連付けられた Azure AD アクセス トークンを作成します。

<span id="step-2"/>

## <a name="step-2-associate-your-azure-ad-application-id-with-your-client-app-in-windows-dev-center"></a>手順 2: Azure AD アプリケーション ID を Windows デベロッパー センターで、クライアント アプリに関連付ける

Microsoft Store コレクション API または購入所有権と、アプリやアドオンの購入を構成する API を使う前に、デベロッパー センター ダッシュ ボードで、アプリ (またはアドオンを含むアプリ) で、Azure AD アプリケーション ID を関連付ける必要があります。

> [!NOTE]
> この作業を行うのは一度だけです。

1.  [デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインし、アプリを選択します。
2.  **サービス**に移動&gt;**製品のコレクションと購入**ページを利用可能な**クライアント ID**フィールドのいずれかに Azure AD アプリケーション ID を入力します。

<span id="step-3"/>

## <a name="step-3-create-azure-ad-access-tokens"></a>手順 3: Azure AD アクセス トークンを作成する

Microsoft Store ID キーを取得したり、Microsoft Store コレクション API または Microsoft Store 購入 API を呼び出したりする前に、発行元 ID を表すいくつかの Azure AD アクセス トークンをサービスで作成する必要があります。 各トークンは別々の API で使われます。 各トークンの有効期間は 60 分であり、有効期限が切れた場合は更新できます。

> [!IMPORTANT]
> Azure AD アクセス トークンは、アプリ内ではなく、サービスのコンテキスト内でのみ作成してください。 このアクセス トークンがアプリに送信されると、クライアント シークレットが侵害される可能性があります。

<span id="access-tokens" />

### <a name="understanding-the-different-tokens-and-audience-uris"></a>さまざまなトークンとオーディエンス URI を理解する

Microsoft Store コレクション API または購入 API で呼び出そうとしているメソッドに応じて、2 つまたは 3 つの異なるトークンを作成する必要があります。 各アクセス トークンは、別々のオーディエンス URI に関連付けられます (これらは、以前に Azure AD アプリケーション マニフェストの `"identifierUris"` セクションに追加した URI と同じです)。

  * いずれの場合も、`https://onestore.microsoft.com` オーディエンス URI のトークンを 1 つ作成する必要があります。 このトークンは、後の手順で Microsoft Store コレクション API または購入 API のメソッドの **Authorization** ヘッダーに渡します。
      > [!IMPORTANT]
      > `https://onestore.microsoft.com` 対象ユーザーには、サービス内に安全に格納されたアクセス トークンのみを使用してください。 このオーディエンスのアクセス トークンがサービス外に公開されると、サービスがリプレイ攻撃に対して脆弱になる可能性があります。

  * Microsoft Store コレクション API のメソッドを呼び出して、[特定のユーザーが所有する製品を照会](query-for-products.md)したり、[コンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)したりする場合は、`https://onestore.microsoft.com/b2b/keys/create/collections` オーディエンス URI のトークンも作成する必要があります。 後の手順で、このトークンを Windows SDK のクライアント メソッドに渡し、Microsoft Store コレクション API で使用できる Microsoft Store ID キーを要求します。

  * Microsoft Store 購入 API でメソッドを呼び出して[無料の製品をユーザーに付与する](grant-free-products.md)、[ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)、または[ユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)場合、`https://onestore.microsoft.com/b2b/keys/create/purchase` 対象ユーザー URI を使ってトークンも作成する必要があります。 後の手順で、このトークンを Windows SDK のクライアント メソッドに渡し、Microsoft Store 購入 API で使用できる Microsoft Store ID キーを要求します。

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

* *Client \_id*と*client \_secret*のパラメーターには、アプリケーション ID と[Azure 管理ポータル](http://manage.windowsazure.com)から取得したアプリケーションのクライアント シークレットを指定します。 これらのパラメーターはいずれも、Microsoft Store コレクション API または購入 API で必要とされる認証のレベルに基づいてアクセス トークンを生成するために必要です。

* *resource* パラメーターには、作成するアクセス トークンの種類に応じて、[前のセクション](#access-tokens)に記載したいずれかのオーディエンス URI を指定します。

アクセス トークンの有効期限が切れた後は、[こちらのトピック](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)の手順に従って更新できます。 アクセス トークンの構造について詳しくは、「[サポートされているトークンと要求の種類](http://go.microsoft.com/fwlink/?LinkId=722501)」をご覧ください。

<span id="step-4"/>

## <a name="step-4-create-a-microsoft-store-id-key"></a>手順 4: Microsoft Store ID キーを生成する

Microsoft Store コレクション API または Microsoft Store 購入 API のメソッドを呼び出すには、事前にアプリで Microsoft Store ID キーを作成し、サービスに送信する必要があります。 このキーは、アクセス対象の製品所有権情報を保持するユーザーの ID を表す JSON Web トークン (JWT) です。 このキーの要求について詳しくは、「[Microsoft Store ID キー内の要求](#claims-in-a-microsoft-store-id-key)」をご覧ください。

現時点では、Microsoft Store ID キーを作成する唯一の方法は、アプリ内のコードからユニバーサル Windows プラットフォーム (UWP) API を呼び出すことです。 生成されたキーは、デバイスで現在 Microsoft Store にサインインしているユーザーの ID を表します。

> [!NOTE]
> 各 Microsoft Store ID キーは 90 日間有効です。 キーの有効期限が切れた場合は、[キーを更新](renew-a-windows-store-id-key.md)できます。 新しい Microsoft Store ID キーを作成するのではなく、更新することをお勧めします。

<span />

### <a name="to-create-a-microsoft-store-id-key-for-the-microsoft-store-collection-api"></a>Microsoft Store コレクション API 用の Microsoft Store ID キーを作成するには

[特定のユーザーが所有する製品を照会](query-for-products.md)したり、[コンシューマブルな製品をフルフィルメント完了として報告](report-consumable-products-as-fulfilled.md)したりするために、Microsoft Store コレクション API で使用できる Microsoft Store ID キーを作成するには、次の手順に従います。

1.  オーディエンス URI 値 `https://onestore.microsoft.com/b2b/keys/create/collections` を持つ Azure AD アクセス トークンを、サービスからクライアント アプリに渡します。 これは、[前述の手順 3](#step-3) で作成したトークンのいずれかです。

2.  アプリ コードで次のいずれかのメソッドを呼び出して、Microsoft Store ID キーを取得します。

  * アプリで [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の [StoreContext](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext) クラスを使ってアプリ内購入を管理する場合は、[StoreContext.GetCustomerCollectionsIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getcustomercollectionsidasync) メソッドを使用します。

  * アプリで [Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store) 名前空間の  [CurrentApp](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使ってアプリ内購入を管理する場合は、[CurrentApp.GetCustomerCollectionsIdAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getcustomercollectionsidasync) メソッドを使用します。

    メソッドの *serviceTicket* パラメーターに、Azure AD アクセス トークンを渡します。 *PublisherUserId*パラメーターに関連付ける新しい Microsoft Store ID キー (ユーザーの ID になります em の現在のユーザーにユーザー ID を渡すことと、現在のアプリの発行元を管理するサービスのコンテキストで匿名ユーザー Id を保持している場合もできます。bedded キー)。 それ以外の場合、Microsoft Store ID キーを持つユーザー ID を関連付けるにはない場合は、任意の文字列値を*publisherUserId*パラメーターに渡すことができます。

3.  アプリで正しく Microsoft Store ID キーを作成したら、そのキーをサービスに渡します。

<span />

### <a name="to-create-a-microsoft-store-id-key-for-the-microsoft-store-purchase-api"></a>Microsoft Store 購入 API 用の Microsoft Store ID キーを作成するには

[無料の製品をユーザーに付与する](grant-free-products.md)、[ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)、または[ユーザーのサブスクリプションの請求状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)ために、Microsoft Store 購入 API と共に使うことができる Microsoft Store ID キーを作成するには、以下の手順に従います。

1.  オーディエンス URI 値 `https://onestore.microsoft.com/b2b/keys/create/purchase` を持つ Azure AD アクセス トークンを、サービスからクライアント アプリに渡します。 これは、[前述の手順 3](#step-3) で作成したトークンのいずれかです。

2.  アプリ コードで次のいずれかのメソッドを呼び出して、Microsoft Store ID キーを取得します。

  * アプリで [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の [StoreContext](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext) クラスを使ってアプリ内購入を管理する場合は、[StoreContext.GetCustomerPurchaseIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getcustomerpurchaseidasync) メソッドを使用します。

  * アプリで [Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store) 名前空間の [CurrentApp](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使ってアプリ内購入を管理する場合は、[CurrentApp.GetCustomerPurchaseIdAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getcustomerpurchaseidasync) メソッドを使用します。

    メソッドの *serviceTicket* パラメーターに、Azure AD アクセス トークンを渡します。 *PublisherUserId*パラメーターに関連付ける新しい Microsoft Store ID キー (ユーザーの ID になります em の現在のユーザーにユーザー ID を渡すことと、現在のアプリの発行元を管理するサービスのコンテキストで匿名ユーザー Id を保持している場合もできます。bedded キー)。 それ以外の場合、Microsoft Store ID キーを持つユーザー ID を関連付けるにはない場合は、任意の文字列値を*publisherUserId*パラメーターに渡すことができます。

3.  アプリで正しく Microsoft Store ID キーを作成したら、そのキーをサービスに渡します。

### <a name="diagram"></a>ダイアグラム

次の図は、Microsoft Store ID キーを作成するプロセスを示しています。

  ![Windows ストア ID キーを作成します。](images/b2b-1.png)

<span id="step-5"/>

## <a name="step-5-call-the-microsoft-store-collection-api-or-purchase-api-from-your-service"></a>手順 5: サービスから Microsoft Store コレクション API または購入 API を呼び出す

特定のユーザーの製品所有権情報にアクセスするための Microsoft Store ID キーをサービスで取得したら、次の手順に従って、サービスから Microsoft Store コレクション API または購入 API を呼び出すことができます。

* [製品の照会](query-for-products.md)
* [コンシューマブルな製品をフルフィルメント完了として報告する](report-consumable-products-as-fulfilled.md)
* [無料の製品の付与](grant-free-products.md)
* [ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)
* [ユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)

各シナリオについて、次の情報を API に渡します。

-   要求ヘッダーで、対象ユーザー URI 値 `https://onestore.microsoft.com` を持つ Azure AD アクセス トークンを渡します。 これは、[前述の手順 3](#step-3) で作成したトークンのいずれかです。 このトークンは発行元 ID を表します。
-   要求本文で、[前述の手順 4](#step-4) でアプリのクライアント側コードから取得した Microsoft Store ID キーを渡します。 このキーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表します。

### <a name="diagram"></a>ダイアグラム

次の図では、サービスから Microsoft Store コレクション API または購入 API でメソッドを呼び出すのプロセスについて説明します。

  ![コレクションまたは自社 API を呼び出す](images/b2b-2.png)

## <a name="claims-in-a-microsoft-store-id-key"></a>Microsoft Store ID キー内の要求

Microsoft Store ID キーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表す JSON Web トークン (JWT) です。 Base64 を使用してデコードされた Microsoft Store ID キーには、次の要求が含まれています。

* `iat`:&nbsp;&nbsp;&nbsp;キーが発行された時刻を識別します。 この要求は、トークンの経過期間を判別するために使用できます。 この値はエポック時間で表されます。
* `iss`:&nbsp;&nbsp;&nbsp;発行者を識別します。 これは `aud` 要求と同じ値を持ちます。
* `aud`:&nbsp;&nbsp;&nbsp;オーディエンスを識別します。 `https://collections.mp.microsoft.com/v6.0/keys` または `https://purchase.mp.microsoft.com/v6.0/keys` のいずれかの値である必要があります。
* `exp`:&nbsp;&nbsp;&nbsp;キーがキーの更新以外のどの処理も受け入れられなくなる有効期限を識別します。 この要求の値はエポック時間で表されます。
* `nbf`:&nbsp;&nbsp;&nbsp;トークンの処理が受け入れられる時刻を識別します。 この要求の値はエポック時間で表されます。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/clientId`:&nbsp;&nbsp;&nbsp;開発者を識別するクライアント ID。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/payload`:&nbsp;&nbsp;&nbsp;Microsoft Store サービスでのみ使用する情報が含まれている不透明なペイロード (暗号化され、Base64 でエンコード)。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/userId`:&nbsp;&nbsp;&nbsp;サービスのコンテキストで現在のユーザーを識別するユーザー ID。 これは、[キーの作成に使うメソッド](#step-4)の省略可能な *publisherUserId* パラメーターに渡す値と同じです。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/refreshUri`:&nbsp;&nbsp;&nbsp;キーの更新に使用できる URI。

デコードされた Microsoft Store ID キー ヘッダーの例を次に示します。

```json
{
    "typ":"JWT",
    "alg":"RS256",
    "x5t":"agA_pgJ7Twx_Ex2_rEeQ2o5fZ5g"
}
```

デコードされた Microsoft Store ID キー要求セットの例を次に示します。

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
* [ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)
* [ユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)
* [Microsoft Store ID キーの更新](renew-a-windows-store-id-key.md)
* [Azure Active Directory とアプリケーションの統合](http://go.microsoft.com/fwlink/?LinkId=722502)
* [Azure Active Directory アプリケーション マニフェストの概要]( http://go.microsoft.com/fwlink/?LinkId=722500)
* [サポートされているトークンと要求の種類](http://go.microsoft.com/fwlink/?LinkId=722501)
