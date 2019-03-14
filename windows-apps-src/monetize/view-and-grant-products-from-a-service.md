---
ms.assetid: B071F6BC-49D3-4E74-98EA-0461A1A55EFB
description: アプリとアドオンのカタログがある場合は、Microsoft Store コレクション API および Microsoft Store 購入 API を使って、サービスからこれらの製品の所有権情報にアクセスできます。
title: サービスによる製品の権利の管理
ms.date: 08/01/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store コレクション API, Microsoft Store 購入 API, 製品の表示, 製品の付与
ms.localizationpriority: medium
ms.openlocfilehash: 0bf85a73cb35044b4be2282c9a13c1e65b836a92
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604007"
---
# <a name="manage-product-entitlements-from-a-service"></a>サービスによる製品の権利の管理

アプリとアドオンのカタログがある場合は、*Microsoft Store コレクション API* と *Microsoft Store 購入 API* を使って、サービスからこれらの製品の権利の情報にアクセスできます。 "*権利*" とは、Microsoft Store を通じて公開されたアプリまたはアドオンを顧客が使用する権利を表します。

これらの API は、クロスプラットフォーム サービスでサポートされるアドオン カタログを持つ開発者向けに設計された REST メソッドで構成されています。 これらの API を使用すると、次の操作を実行できます。

-   Microsoft Store コレクション API:[ユーザーによって所有されている製品のクエリ](query-for-products.md)と[fulfilled 消耗品をレポート](report-consumable-products-as-fulfilled.md)します。
-   Microsoft Store 購入 API:[無料の製品をユーザーに付与](grant-free-products.md)、[ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)、および[ユーザーのサブスクリプションの課金の状態を変更](change-the-billing-state-of-a-subscription-for-a-user.md)します。

> [!NOTE]
> Microsoft Store コレクション API と Microsoft Store 購入 API では、Azure Active Directory (Azure AD) 認証を使って顧客の所有権情報にアクセスします。 これらの API を使用するには、ユーザー (またはユーザーの組織) が、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](https://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。

## <a name="overview"></a>概要

次の手順は、Microsoft Store コレクション API および購入 API を使用するプロセス全体を表したものです。

1.  [Azure AD でアプリケーションを構成する](#step-1)します。
2.  [パートナー センターでアプリと Azure AD アプリケーション ID を関連付ける](#step-2)します。
3.  サービスで、発行元 ID を表す [Azure AD アクセス トークンを作成します](#step-3)。
4.  クライアントの Windows アプリで[Microsoft Store の ID キーを作成する](#step-4)現在のユーザーと、サービスにこのキーがバックアップ パスの id を表します。
5.  必要な Azure AD のアクセス トークンと Microsoft Store ID キーを取得した後、[サービスから Microsoft Store コレクション API または Microsoft Store 購入 API を呼び出します](#step-5)。

このエンド ツー エンド プロセスには、さまざまなタスクを実行する 2 つのソフトウェア コンポーネントが含まれます。

* **サービス**します。 これは、ビジネス環境のコンテキストで安全に実行されるアプリケーションであり、選択した任意の開発プラットフォームを使用して実装できます。 サービスは、Azure AD アクセス トークンを作成するために必要なシナリオでは、Microsoft Store のコレクションの REST Uri を呼び出すため API と API の購入にします。
* **クライアント Windows アプリ**します。 これは、アクセスし、お客様の資格情報 (アプリのアドオンを含む) を管理するアプリです。 このアプリは、Microsoft Store コレクション API を呼び出すし、サービスから API を購入する必要がある Microsoft Store の ID キーを作成する責任を負います。

<span id="step-1"/>

## <a name="step-1-configure-an-application-in-azure-ad"></a>手順 1:Azure AD でアプリケーションを構成します。

Microsoft Store コレクション API を使用したり、API を購入することが、前に、Azure AD Web アプリケーションを作成、テナント ID と、アプリケーションのアプリケーション ID を取得、キーを生成してください。 Azure AD Web アプリケーションでは、Microsoft Store コレクション API を呼び出し、または API を購入するサービスを表します。 テナント ID、アプリケーション ID とキー、API を呼び出す必要がある Azure AD アクセス トークンを生成する必要があります。

> [!NOTE]
> このセクションの作業は 1 回実行する必要があるだけです。 新規作成する必要がある任意の時間をこれらの値を再利用することができます、Azure AD アプリケーション マニフェストを更新すると、テナント ID、アプリケーション ID とクライアント シークレットがある場合、Azure AD アクセス トークン。

1.  したがまだ完了していない場合の指示に従って[Azure Active Directory とアプリケーションの統合](https://docs.microsoft.com/azure/active-directory/develop/active-directory-integrating-applications)を登録する、 **Web app/API**と Azure AD アプリケーション。
    > [!NOTE]
    > 選択する必要がある、アプリケーションを登録するときに**Web app/API**キーを取得できるように、アプリケーションの種類として (とも呼ばれます、*クライアント シークレット*) アプリケーション用。 Microsoft Store コレクション API または購入 API を呼び出すには、後の手順で Azure AD からアクセス トークンを要求するときにクライアント シークレットを指定する必要があります。

2.  [Azure 管理ポータル](https://portal.azure.com/)に移動します**Azure Active Directory**します。 ディレクトリを選択して、**アプリの登録**左側のナビゲーション ウィンドウでし、アプリケーションを選択します。
3.  アプリケーションのメイン登録ページが表示されます。 このページで、コピー、**アプリケーション ID**後で使用する値。
4.  後で必要なキーの作成 (これがすべて呼び出さ、*クライアント シークレット*)。 左側のウィンドウで次のようにクリックします。**設定**し**キー**します。 このページで、手順を完了[キーを作成する](https://docs.microsoft.com/azure/active-directory/develop/active-directory-integrating-applications#to-add-application-credentials-or-permissions-to-access-web-apis)します。 後で使用するためには、このキーをコピーします。
5.  いくつか必要なユーザーの Uri を追加する、[アプリケーション マニフェスト](https://docs.microsoft.com/azure/active-directory/develop/active-directory-application-manifest)します。 左側のウィンドウで次のようにクリックします。**マニフェスト**します。 をクリックして**編集**、置換、`"identifierUris"`セクションで、次のテキストをクリックして**保存**します。

    ```json
    "identifierUris" : [                                
            "https://onestore.microsoft.com",
            "https://onestore.microsoft.com/b2b/keys/create/collections",
            "https://onestore.microsoft.com/b2b/keys/create/purchase"
        ],
    ```

    これらの文字列は、アプリケーションでサポートされる対象ユーザーを表します。 後の手順で、各対象ユーザー値に関連付けられた Azure AD アクセス トークンを作成します。

<span id="step-2"/>

## <a name="step-2-associate-your-azure-ad-application-id-with-your-client-app-in-partner-center"></a>手順 2:パートナー センターで、クライアント アプリケーションで Azure AD アプリケーション ID を関連付ける

Microsoft Store コレクション API を使用したり、所有権とアプリまたはアドオンの購入を構成する API を購入することが、前に、パートナー センターで、アプリ (または、アプリ、アドオンを含む) で Azure AD アプリケーション ID を関連付ける必要があります。

> [!NOTE]
> この作業を行うのは一度だけです。

1.  サインインする[パートナー センター](https://partner.microsoft.com/dashboard)アプリを選択します。
2.  移動して、**サービス** &gt; **製品のコレクションと購入**ページし、の使用可能ないずれかに、Azure AD アプリケーション ID を入力します。**クライアント ID**フィールド。

<span id="step-3"/>

## <a name="step-3-create-azure-ad-access-tokens"></a>手順 3:Azure AD アクセス トークンを作成します。

Microsoft Store ID キーを取得したり、Microsoft Store コレクション API または Microsoft Store 購入 API を呼び出したりする前に、発行元 ID を表すいくつかの Azure AD アクセス トークンをサービスで作成する必要があります。 各トークンは別々の API で使われます。 各トークンの有効期間は 60 分であり、有効期限を過ぎた場合は更新できます。

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

* *クライアント\_id*と*クライアント\_シークレット*アプリケーション ID と、から取得したアプリケーションのクライアントシークレットを指定するパラメーター、[Azure 管理ポータル](https://manage.windowsazure.com)します。 これらのパラメーターはいずれも、Microsoft Store コレクション API または購入 API で必要とされる認証のレベルに基づいてアクセス トークンを生成するために必要です。

* *resource* パラメーターには、作成するアクセス トークンの種類に応じて、[前のセクション](#access-tokens)に記載したいずれかのオーディエンス URI を指定します。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。 アクセス トークンの構造について詳しくは、「[サポートされているトークンと要求の種類](https://go.microsoft.com/fwlink/?LinkId=722501)」をご覧ください。

<span id="step-4"/>

## <a name="step-4-create-a-microsoft-store-id-key"></a>手順 4:Microsoft Store の ID キーを作成します。

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

    メソッドの *serviceTicket* パラメーターに、Azure AD アクセス トークンを渡します。 ユーザー ID を渡すことも、現在のアプリの発行元として管理するサービスのコンテキスト内の匿名ユーザー Id を保持している場合、 *publisherUserId*パラメーターに、現在のユーザーを新しい Microsoft Store ID に関連付けるキー (ユーザー ID、キーに埋め込まれます)。 それ以外の場合、Microsoft Store の ID キーを持つユーザーの ID を関連付けるに不要な場合は、任意の文字列値を渡すことができます、 *publisherUserId*パラメーター。

3.  アプリで正しく Microsoft Store ID キーを作成したら、そのキーをサービスに渡します。

<span />

### <a name="to-create-a-microsoft-store-id-key-for-the-microsoft-store-purchase-api"></a>Microsoft Store 購入 API 用の Microsoft Store ID キーを作成するには

[無料の製品をユーザーに付与する](grant-free-products.md)、[ユーザーのサブスクリプションを取得する](get-subscriptions-for-a-user.md)、または[ユーザーのサブスクリプションの請求状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)ために、Microsoft Store 購入 API と共に使うことができる Microsoft Store ID キーを作成するには、以下の手順に従います。

1.  オーディエンス URI 値 `https://onestore.microsoft.com/b2b/keys/create/purchase` を持つ Azure AD アクセス トークンを、サービスからクライアント アプリに渡します。 これは、[前述の手順 3](#step-3) で作成したトークンのいずれかです。

2.  アプリ コードで次のいずれかのメソッドを呼び出して、Microsoft Store ID キーを取得します。

  * アプリで [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の [StoreContext](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext) クラスを使ってアプリ内購入を管理する場合は、[StoreContext.GetCustomerPurchaseIdAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getcustomerpurchaseidasync) メソッドを使用します。

  * アプリで [Windows.ApplicationModel.Store](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store) 名前空間の [CurrentApp](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使ってアプリ内購入を管理する場合は、[CurrentApp.GetCustomerPurchaseIdAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.getcustomerpurchaseidasync) メソッドを使用します。

    メソッドの *serviceTicket* パラメーターに、Azure AD アクセス トークンを渡します。 ユーザー ID を渡すことも、現在のアプリの発行元として管理するサービスのコンテキスト内の匿名ユーザー Id を保持している場合、 *publisherUserId*パラメーターに、現在のユーザーを新しい Microsoft Store ID に関連付けるキー (ユーザー ID、キーに埋め込まれます)。 それ以外の場合、Microsoft Store の ID キーを持つユーザーの ID を関連付けるに不要な場合は、任意の文字列値を渡すことができます、 *publisherUserId*パラメーター。

3.  アプリで正しく Microsoft Store ID キーを作成したら、そのキーをサービスに渡します。

### <a name="diagram"></a>ダイアグラム

次の図は、Microsoft Store の ID キーを作成するプロセスを示しています。

  ![Windows Store ID キーを作成します。](images/b2b-1.png)

<span id="step-5"/>

## <a name="step-5-call-the-microsoft-store-collection-api-or-purchase-api-from-your-service"></a>手順 5:Microsoft Store コレクション API を呼び出すか、API、サービスの購入

特定のユーザーの製品所有権情報にアクセスするための Microsoft Store ID キーをサービスで取得したら、次の手順に従って、サービスから Microsoft Store コレクション API または購入 API を呼び出すことができます。

* [製品のクエリ](query-for-products.md)
* [Fulfilled コンシューマブル製品をレポートします。](report-consumable-products-as-fulfilled.md)
* [無料の製品を付与します。](grant-free-products.md)
* [ユーザーのサブスクリプションを取得します。](get-subscriptions-for-a-user.md)
* [ユーザーのサブスクリプションの課金の状態を変更します。](change-the-billing-state-of-a-subscription-for-a-user.md)

各シナリオについて、次の情報を API に渡します。

-   要求ヘッダーで、対象ユーザー URI 値 `https://onestore.microsoft.com` を持つ Azure AD アクセス トークンを渡します。 これは、[前述の手順 3](#step-3) で作成したトークンのいずれかです。 このトークンは発行元 ID を表します。
-   要求本文で、[前述の手順 4](#step-4) でアプリのクライアント側コードから取得した Microsoft Store ID キーを渡します。 このキーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表します。

### <a name="diagram"></a>ダイアグラム

次の図では、サービスから Microsoft Store コレクションまたは購入する API の API のメソッドを呼び出すプロセスについて説明します。

  ![コレクションまたは購入 API を呼び出す](images/b2b-2.png)

## <a name="claims-in-a-microsoft-store-id-key"></a>Microsoft Store ID キー内の要求

Microsoft Store ID キーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表す JSON Web トークン (JWT) です。 Base64 を使用してデコードされた Microsoft Store ID キーには、次の要求が含まれています。

* `iat`:&nbsp;&nbsp;&nbsp;キーが発行された時刻を識別します。 この要求は、トークンの経過期間の判別に使用できます。 この値はエポック時間で表されます。
* `iss`:&nbsp;&nbsp;&nbsp;発行者を識別します。 これは `aud` 要求と同じ値を持ちます。
* `aud`:&nbsp;&nbsp;&nbsp;対象ユーザーを識別します。 `https://collections.mp.microsoft.com/v6.0/keys` または `https://purchase.mp.microsoft.com/v6.0/keys` のいずれかの値である必要があります。
* `exp`:&nbsp;&nbsp;&nbsp;またはこのキーは受け入れられなくなりますキーの更新を除くすべての処理の後に有効期限を識別します。 この要求の値はエポック時間で表されます。
* `nbf`:&nbsp;&nbsp;&nbsp;処理のため、トークンが受け付けられます時間を識別します。 この要求の値はエポック時間で表されます。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/clientId`:&nbsp;&nbsp;&nbsp;開発者を識別するクライアント ID。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/payload`:&nbsp;&nbsp;&nbsp;不透明なペイロードを (暗号化し、Base64 でエンコードされた) Microsoft Store サービスによって使用のみを目的とした情報を格納します。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/userId`:&nbsp;&nbsp;&nbsp;、サービスのコンテキストで現在のユーザーを識別するユーザー ID。 これは、[キーの作成に使うメソッド](#step-4)の省略可能な *publisherUserId* パラメーターに渡す値と同じです。
* `http://schemas.microsoft.com/marketplace/2015/08/claims/key/refreshUri`:&nbsp;&nbsp;&nbsp;キーを更新するために使用できる URI。

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

* [製品のクエリ](query-for-products.md)
* [Fulfilled コンシューマブル製品をレポートします。](report-consumable-products-as-fulfilled.md)
* [無料の製品を付与します。](grant-free-products.md)
* [ユーザーのサブスクリプションを取得します。](get-subscriptions-for-a-user.md)
* [ユーザーのサブスクリプションの課金の状態を変更します。](change-the-billing-state-of-a-subscription-for-a-user.md)
* [Microsoft Store の ID キーを更新します。](renew-a-windows-store-id-key.md)
* [Azure Active Directory とアプリケーションの統合](https://go.microsoft.com/fwlink/?LinkId=722502)
* [Azure Active Directory のアプリケーション マニフェストをについてください。]( https://go.microsoft.com/fwlink/?LinkId=722500)
* [サポートされているトークンとクレームの種類](https://go.microsoft.com/fwlink/?LinkId=722501)
