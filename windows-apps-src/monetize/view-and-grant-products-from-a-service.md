---
author: mcleanbyron
ms.assetid: B071F6BC-49D3-4E74-98EA-0461A1A55EFB
description: "アプリおよびアドオンのカタログがある場合は、Windows ストア コレクション API と Windows ストア購入 API を使って、サービスからこれらの製品の所有権情報にアクセスできます。"
title: "サービスからの製品の表示と許可"
translationtype: Human Translation
ms.sourcegitcommit: 1a2e856cddf9998eeb8b0132c2fb79f5188c218b
ms.openlocfilehash: d7677c85408af22e882444119dc0231eebe4fa9a

---

# <a name="view-and-grant-products-from-a-service"></a>サービスからの製品の表示と許可

アプリおよびアドオン (アプリ内製品 (IAP) とも呼ばれます) のカタログがある場合は、*Windows ストア コレクション API* と *Windows ストア購入 API* を使って、サービスからこれらの製品の所有権情報にアクセスできます。

これらの API は、クロスプラットフォームのサービスでサポートされるアドオン カタログを持つ開発者によって使用されるように設計された REST メソッドで構成されています。 これらの API を使用すると、次の操作を実行できます。

-   Windows ストア コレクション API: 特定のユーザーが所有するアプリおよびアドオンを照会、またはコンシューマブルな製品をフルフィルメント完了として報告します。
-   Windows ストア購入 API: 特定のユーザーに無料のアプリまたはアドオンを付与します。

## <a name="using-the-windows-store-collection-api-and-windows-store-purchase-api"></a>Windows ストア コレクション API と Windows ストア購入 API の使用


Windows ストア コレクション API と Windows ストア購入 API では、Azure Active Directory (Azure AD) 認証を使って顧客の所有権情報にアクセスします。 これらの API を呼び出すには、Windows デベロッパー センター ダッシュボードで Azure AD メタデータをアプリケーションに適用し、必要なアクセス トークンとキーを生成する必要があります。 次の手順で、このプロセスについて詳しく説明しています。

1.  [Azure AD で Web アプリケーションを構成します](#step-1)。 このアプリケーションは、Azure AD のコンテキストでのクロスプラットフォーム サービスを表します。
2.  [Windows デベロッパー センター ダッシュボードで、Azure AD クライアント ID をアプリケーションに関連付けます](#step-2)。
3.  サービスで、発行元 ID を表す [Azure AD アクセス トークンを生成](#step-3)します。
4.  Windows アプリのクライアント側コードで、現在のユーザーの ID を表す [Windows ストア ID キーを生成](#step-4)し、その Windows ストア ID キーをサービスに渡します。
5.  必要な Azure AD のアクセス トークンと Windows ストア ID キーを取得した後、[サービスから Windows ストア コレクション API または Windows ストア購入 API を呼び出します](#step-5)。

以降のセクションでは、これらの各手順についてさらに詳しく説明します。

<span id="step-1"/>
### <a name="step-1-configure-a-web-application-in-azure-ad"></a>手順 1: Azure AD で Web アプリケーションを構成する

1.  「[Azure Active Directory とアプリケーションの統合](http://go.microsoft.com/fwlink/?LinkId=722502)」の指示に従って、Azure AD に Web アプリケーションを追加します。

    > **注**&nbsp;&nbsp;**[アプリケーション情報の指定]** ページで、**[Web アプリケーションや Web API]** を選んでいることを確認します。 これは、アプリケーションのキー (*クライアント シークレット*とも呼ばれます) を取得するために必要です。 Windows ストア コレクション API または Windows ストア製品購入 API を呼び出すには、後の手順で Azure AD にアクセス トークンを要求するときにクライアント シークレットを指定する必要があります。

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

    これらの文字列は、アプリケーションでサポートされる対象ユーザーを表します。 後の手順で、各対象ユーザー値に関連付けられた Azure AD アクセス トークンを作成します。 アプリケーション マニフェストをダウンロードする方法について詳しくは、[Azure Active Directory アプリケーション マニフェストの概要に関するページ]( http://go.microsoft.com/fwlink/?LinkId=722500)をご覧ください。

5.  アプリケーション マニフェストを保存し、[Azure 管理ポータル](http://manage.windowsazure.com/)でアプリケーションにアップロードします。

<span id="step-2"/>
### <a name="step-2-associate-your-azure-ad-client-id-with-your-application-in-the-windows-dev-center-dashboard"></a>手順 2: Windows デベロッパー センター ダッシュ ボードで Azure AD クライアント ID をアプリケーションに関連付ける

Windows ストア コレクション API および Windows ストア購入 API は、Azure AD クライアント ID に関連付けられているアプリやアドオンに対するユーザーの所有権情報へのアクセスのみを提供します。

1.  [Windows デベロッパー センター ダッシュボード](https://dev.windows.com/overview)にサインインし、アプリを選びます。
2.  **[サービス]** &gt; **[製品のコレクションと購入]** ページの順に移動して、利用可能なフィールドの 1 つに Azure AD のクライアント ID を入力します。

<span id="step-3"/>
### <a name="step-3-retrieve-access-tokens-from-azure-ad"></a>手順 3: Azure AD からアクセス トークンを取得する

Windows ストア ID キーを取得したり、Windows ストア コレクション API または Windows ストア購入 API を呼び出したりする前に、サービスが発行元 ID を表す 3 つの Azure AD アクセス トークンを要求する必要があります。 これらのアクセス トークンは、それぞれ異なる対象ユーザー URI に関連付けられ、各トークンが異なる API 呼び出しで使用されます。 各トークンの有効期間は 60 分であり、有効期限を過ぎた場合は更新できます。

アクセス トークンを取得するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service/)」の手順に従って OAuth 2.0 API をサービスで使用し、HTTP POST を ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` エンドポイントに送信します。 要求の例を次に示します。

```
POST https://login.microsoftonline.com/<tenant_id>/oauth2/token HTTP/1.1
Host: login.microsoftonline.com
Content-Type: application/x-www-form-urlencoded; charset=utf-8

grant_type=client_credentials
&client_id=<your_client_id>
&client_secret=<your_client_secret>
&resource=https://onestore.microsoft.com
```

各トークンについて、次のパラメーター データを指定します。

* *client\_id* パラメーターと *client\_secret* パラメーターには、[Azure 管理ポータル](http://manage.windowsazure.com/)から取得したクライアント ID とアプリケーションのクライアント シークレットを指定します。 これらのパラメーターはいずれも、Windows ストア コレクション API や Windows ストア購入 API で必要な認証のレベルに基づいてアクセス トークンを生成するために必要です。

* *resource* パラメーターには、次のアプリ ID URI のいずれかを指定します (これらは、以前にアプリケーション マニフェストの `"identifierUris"` セクションに追加したものと同じ URI です)。 このプロセスを終了すると、それぞれにこれらのアプリ ID の URI のいずれかが関連付けられた 3 つのアクセス トークンを用意できます。
  * `https://onestore.microsoft.com/b2b/keys/create/collections`: 後の手順で、この URI で作成したアクセス トークンを使用して、Windows ストア コレクション API で使用できる Windows ストア ID キーを要求します。
  * `https://onestore.microsoft.com/b2b/keys/create/purchase`: 後の手順で、この URI で作成したアクセス トークンを使用して、Windows ストア購入 API で使用できる Windows ストア ID キーを要求します。
  * `https://onestore.microsoft.com`: 後の手順で、Windows ストア コレクション API または Windows ストア購入 API を直接呼び出すときに、この URI で作成したアクセス トークンを使用します。

  > **重要**&nbsp;&nbsp;`https://onestore.microsoft.com` 対象ユーザーには、サービス内に安全に格納されたアクセス トークンのみを使用してください。 この対象ユーザーのアクセス トークンがサービス外に公開されると、サービスがリプレイ攻撃に対して脆弱になる可能性があります。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。 アクセス トークンの構造について詳しくは、「[サポートされているトークンと要求の種類](http://go.microsoft.com/fwlink/?LinkId=722501)」をご覧ください。

> **重要**&nbsp;&nbsp;Azure AD アクセス トークンは、アプリ内ではなく、サービスのコンテキスト内でのみ作成してください。 このアクセス トークンがアプリに送信されると、クライアント シークレットが侵害される可能性があります。

<span id="step-4"/>
### <a name="step-4-generate-a-windows-store-id-key-from-client-side-code-in-your-app"></a>手順 4: アプリのクライアント側コードから Windows ストア ID キーを生成する

Windows ストア コレクション API または Windows ストア購入 API を呼び出す前に、サービスが Windows ストア ID キーを取得する必要があります。 これは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表す JSON Web トークン (JWT) です。 このキーの要求について詳しくは、「[Windows ストア ID キー内の要求](#claims)」をご覧ください。

現時点では、Windows ストア ID キーを取得する唯一の方法は、アプリのクライアント側コードからユニバーサル Windows プラットフォーム (UWP) API を呼び出し、現在 Windows ストアにサインインしているユーザーの ID を取得することです。 Windows ストア ID キーを生成するには:

1.  サービスからクライアント アプリに次のいずれかのアクセス トークンを渡します。

  * Windows ストア コレクション API で使用できる Windows ストア ID キーを取得するには、`https://onestore.microsoft.com/b2b/keys/create/collections` 対象ユーザー URI を使用して作成した Azure AD アクセス トークンを渡します。

  * Windows ストア購入 API で使用できる Windows ストア ID キーを取得するには、`https://onestore.microsoft.com/b2b/keys/create/purchase` 対象ユーザー URI を使用して作成した Azure AD アクセス トークンを渡します。

2.  アプリ コードで、次のメソッドのいずれかを呼び出して Windows ストア ID キーを取得します。

  * アプリで [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスを使用してアプリ内購入を管理する場合に、Windows ストア コレクション API を使用するときは [StoreContext.GetCustomerCollectionsIdAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getcustomercollectionsidasync.aspx)メソッドを、Windows ストア購入 API を使用するときは [StoreContext.GetCustomerPurchaseIdAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getcustomerpurchaseidasync.aspx) メソッドを使用します。

  * アプリで [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間の [CurrentApp](https://msdn.microsoft.com/library/windows/apps/hh779765) クラスを使用してアプリ内購入を管理する場合に、Windows ストア コレクション API を使用するときは [CurrentApp.GetCustomerCollectionsIdAsync](https://msdn.microsoft.com/library/windows/apps/mt608674)メソッドを、Windows ストア購入 API を使用するときは [CurrentApp.GetCustomerPurchaseIdAsync](https://msdn.microsoft.com/library/windows/apps/mt608675) メソッドを使用します。

    それぞれのメソッドで、Azure AD アクセス トークンを *serviceTicket* パラメーターに渡します。 必要に応じて、サービスのコンテキストで現在のユーザーを識別する *publisherUserId* パラメーターに、ID を渡すことができます。 サービス用のユーザー ID を保持している場合は、このパラメーターを使用して、Windows ストア コレクション API または Windows ストア購入 API に対する呼び出しにこれらのユーザー ID を関連付けます。

    >**注:**&nbsp;&nbsp;**Windows.Services.Store** 名前空間と **Windows.ApplicationModel.Store** 名前空間の違いについて詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。

3.  アプリで正常に Windows ストア ID キーを取得した後、そのキーをサービスに渡します。

> **注**&nbsp;&nbsp;各 Windows ストア ID キーは 90 日間有効です。 キーの有効期限が切れた後で、[キーを更新](renew-a-windows-store-id-key.md)できます。 新しい Windows ストア ID キーを作成するのではなく、更新することをお勧めします。

<span id="step-5"/>
### <a name="step-5-call-the-windows-store-collection-api-or-purchase-api-from-your-service"></a>手順 5: サービスから Windows ストア コレクション API または Windows ストア購入 API を呼び出す

特定のユーザーの所有権情報にアクセスできるようにする Windows ストア ID キーをサービスが取得した後で、サービス Windows ストア コレクション API または Windows ストア購入 API を呼び出すことができます。 シナリオに適用される指示に従います。

-   [製品の照会](query-for-products.md)
-   [コンシューマブルな製品をフルフィルメント完了として報告する](report-consumable-products-as-fulfilled.md)
-   [無料の製品の付与](grant-free-products.md)

各シナリオについて、次の情報を API に渡します。

-   前に `https://onestore.microsoft.com` 対象ユーザー URI を使って作成した Azure AD アクセス トークン。 このトークンは発行元 ID を表します。 このトークンを要求ヘッダーで渡します。
-   アプリのクライアント側コードから取得した Windows ストア ID キー。 このキーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表します。

<span id="claims"/>
## <a name="claims-in-a-windows-store-id-key"></a>Windows ストア ID キー内の要求

Windows ストア ID キーは、ユーザーの製品所有権情報にアクセスする場合にそのユーザーの ID を表す JSON Web トークン (JWT) です。 Base64 を使用してデコードされた Windows ストア ID キーには、次の要求が含まれています。

<table>
<colgroup>
<col width="30%" />
<col width="70%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">要求の名前</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr>
<td align="left">iat</td>
<td align="left">キーが発行された時刻を識別します。 この要求は、トークンの経過期間の判別に使用できます。 この値はエポック時間で表されます。</td>
</tr>
<tr>
<td align="left">iss</td>
<td align="left">発行者を識別します。 これは *aud* 要求と同じ値を持ちます。</td>
</tr>
<tr>
<td align="left">aud</td>
<td align="left">対象ユーザーを識別します。 `https://collections.mp.microsoft.com/v6.0/keys` または `https://purchase.mp.microsoft.com/v6.0/keys` のいずれかの値である必要があります。</td>
</tr>
<tr>
<td align="left">exp</td>
<td align="left">キーがキーの更新以外のどの処理も受け入れられなくなる有効期限を識別します。 この要求の値はエポック時間で表されます。</td>
</tr>
<tr>
<td align="left">nbf</td>
<td align="left">トークンの処理が受け入れられる時刻を識別します。 この要求の値はエポック時間で表されます。</td>
</tr>
<tr>
<td align="left">`http://schemas.microsoft.com/marketplace/2015/08/claims/key/clientId`</td>
<td align="left">開発者を識別するクライアント ID。</td>
</tr>
<tr>
<td align="left">`http://schemas.microsoft.com/marketplace/2015/08/claims/key/payload`</td>
<td align="left">Windows ストア サービスでのみ使用する情報が含まれている不透明なペイロード (暗号化され、Base64 でエンコード)。 </td>
</tr>
<tr>
<td align="left">`http://schemas.microsoft.com/marketplace/2015/08/claims/key/userId`</td>
<td align="left">サービスのコンテキストで現在のユーザーを識別するユーザー ID。 これは、[キーを生成するために使用するメソッド](view-and-grant-products-from-a-service.md#step-4)の省略可能な *publisherUserId* パラメーターに渡す値と同じ値です。</td>
</tr>
<tr>
<td align="left">`http://schemas.microsoft.com/marketplace/2015/08/claims/key/refreshUri`</td>
<td align="left">キーの更新に使用できる URI。</td>
</tr>
</tbody>
</table>

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
 

 



<!--HONumber=Dec16_HO4-->


