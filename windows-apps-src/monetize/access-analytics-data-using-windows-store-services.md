---
ms.assetid: 4BF9EF21-E9F0-49DB-81E4-062D6E68C8B1
description: Windows ストア分析 API を使って、自分または自分の組織の Windows デベロッパー センター アカウントに登録されたアプリの分析データをプログラムで取得することができます。
title: Windows ストア サービスを使った分析データへのアクセス
---

# Windows ストア サービスを使った分析データへのアクセス


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]


*Windows ストア分析 API* を使って、自分または自分の組織の Windows デベロッパー センター アカウントに登録されたアプリの分析データをプログラムで取得することができます。 この API では、アプリおよび IAP の入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

## Windows ストア分析 API を使うための前提条件


-   ユーザー (またはユーザーの組織) が Azure AD ディレクトリを持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、[こちらから無料で入手](http://go.microsoft.com/fwlink/p/?LinkId=703757) できます。
-   Windows デベロッパー センター アカウントに関連付ける Azure AD ディレクトリに [ユーザー アカウント](https://azure.microsoft.com/documentation/articles/active-directory-create-users/) を持っている必要があります。

## Windows ストア分析 API の使用


Windows ストア分析 API を使う前に、Azure AD アプリケーションをデベロッパー センター アカウントに関連付けて、Azure AD アクセス トークンを取得する必要があります。 Azure AD アプリケーションは、Windows ストア分析 API の呼び出し元のアプリまたはサービスを表します。 アクセス トークンがある場合、アプリまたはサービスから Windows ストア分析 API を呼び出すことができます。

次の手順で、このプロセスについて詳しく説明しています。

1.  [Azure AD アプリケーションを Windows デベロッパー センター アカウントに関連付けます](#associate-an-azure-ad-application-with-your-windows-dev-center-account)。
2.  [Azure AD のアクセス トークンを取得します](#obtain-an-azure-ad-access-token)。
3.  [Windows ストア分析 API を呼び出します](#call-the-windows-store-analytics-api)。


### Azure AD アプリケーションと Windows デベロッパー センター アカウントの関連付け

1.  デベロッパー センターで、**[アカウント設定]** に移動して **[ユーザーの管理]** をクリックし、組織のデベロッパー センター アカウントを組織の Azure AD ディレクトリに関連付けます。 詳しい手順については、「[アカウント ユーザーの管理](https://msdn.microsoft.com/library/windows/apps/mt489008)」をご覧ください。 必要に応じて、組織の Azure AD ディレクトリから他のユーザーを追加して、デベロッパー センター アカウントにもアクセスできるようにすることができます。

    **注**  Azure Active Directory に関連付けることができるデベロッパー センター アカウントは 1 つのみです。 同様に、デベロッパー センター アカウントに関連付けることができる Azure Active Directory は 1 つのみです。 一度関連付けを確立すると、その関連付けを削除するには、必ずサポートへの問い合わせが必要になります。

     

2.  **[ユーザーの管理]** ページで、**[Azure AD アプリケーションの追加]** をクリックして、デベロッパー センター アカウントの分析データへのアクセスに使う Azure AD アプリケーションを追加し、**マネージャー** ロールを割り当てます。 このアプリケーションが既に Azure AD ディレクトリに存在する場合、**[Azure AD アプリケーションの追加]** で選んでデベロッパー センター アカウントに追加できます。 それ以外の場合、**[Azure AD アプリケーションの追加]** ページで新しい Azure AD アプリケーションを作成できます。 詳しくは、「[アカウント ユーザーの管理](https://msdn.microsoft.com/library/windows/apps/mt489008)」の Azure AD アプリケーションの管理に関するセクションをご覧ください。

3.  **[ユーザーの管理]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[新しいキーの追加]** をクリックします。 次の画面で、**[クライアント ID]** と **[キー]** の値を書き留めます。 詳しくは、「[アカウント ユーザーの管理](https://msdn.microsoft.com/library/windows/apps/mt489008)」の Azure AD アプリケーションの管理に関するセクションをご覧ください。 これらのクライアント ID とキーは、Windows ストア分析 API を呼び出すときに使う Azure AD アクセス トークンを取得するために必要です。 このページから離れると、この情報に再度アクセスすることはできません。


### Azure AD アクセス トークンの取得

Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのクライアント ID とキーを取得すると、この情報を使って Azure AD アクセス トークンを取得できます。 Windows ストア分析 API で任意のメソッドを呼び出すには、アクセス トークンが必要です。

アクセス トークンを取得するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://msdn.microsoft.com/library/azure/dn645543.aspx)」の手順に従って、HTTP POST を次の Azure AD エンドポイントに送信します。

```
https://login.microsoftonline.com/<tenant id>/oauth2/token
```

-   テナント ID を取得するには、[Azure 管理ポータル](http://manage.windowsazure.com/) にログインし、**Active Directory** に移動し、デベロッパー センター アカウントにリンクされているディレクトリをクリックします。 以下の例にある *your\_tenant\_ID* 文字列からわかるように、このディレクトリのテナント ID がこのページの URL に埋め込まれます。

  ```
  https://manage.windowsazure.com/@<your_tenant_name>#Workspaces/ActiveDirectoryExtension/Directory/<your_tenant_ID>/directoryQuickStart
  ```

-   *client\_id* および *client\_secret* パラメーターには、前の手順でデベロッパー センターから取得したアプリケーションのクライアント ID とキーを指定します。
-   *resource* パラメーターには、次の URI を指定します: ```https://manage.devcenter.microsoft.com```。


### Windows ストア分析 API の呼び出し

Azure AD アクセス トークンを取得したら、Windows ストア分析 API を呼び出すことができます。 各メソッドの構文については、次の記事をご覧ください。 各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。

-   [アプリの入手数の取得](get-app-acquisitions.md)
-   [IAP の入手数の取得](get-in-app-acquisitions.md)
-   [エラー報告データの取得](get-error-reporting-data.md)
-   [アプリの評価の取得](get-app-ratings.md)
-   [アプリのレビューの取得](get-app-reviews.md)

## コードの例


次のコード例は、Azure AD アクセス トークンを取得し、C# コンソール アプリから Windows ストア分析 API を呼び出す方法を示しています。 このコード例を使う場合は、変数 *tenantId*、*clientId*、*clientSecret*、および *appID* を自分のシナリオに合った適切な値に割り当ててください。 この例では、Windows ストア分析 API から返される JSON データを逆シリアル化するときに、Newtonsoft から提供されている [Json.NET パッケージ](http://www.newtonsoft.com/json) が必要になります。

```CSharp
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestAnalyticsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string tenantId = "<your tenant ID>";
            string clientId = "<your client ID>";
            string clientSecret = "<your secret>";

            string scope = "https://manage.devcenter.microsoft.com";

            // Retrieve an Azure AD access token
            string accessToken = GetClientCredentialAccessToken(
                    tenantId,
                    clientId,
                    clientSecret,
                    scope).Result;

            // This is your app's product ID. This ID is embedded in the app's listing link
            // on the App identity page of the Dev Center dashboard.
            string appID = "<your app's product ID>";

            DateTime startDate = DateTime.Parse("08-01-2015");
            DateTime endDate = DateTime.Parse("11-01-2015");
            int pageSize = 1000;
            int startPageIndex = 0;

            // Call the Windows Store analytics API
            CallAnalyticsAPI(accessToken, appID, startDate, endDate, pageSize, startPageIndex);

            Console.Read();
        }

        private static void CallAnalyticsAPI(string accessToken, string appID, DateTime startDate, DateTime endDate, int top, int skip)
        {
            string requestURI;

            // Get app acquisitions
            requestURI = string.Format(
                "https://manage.devcenter.microsoft.com/v1.0/my/analytics/appacquisitions?applicationId={0}&startDate={1}&endDate={2}&top={3}&skip={4}",
                appID, startDate, endDate, top, skip);

            //// Get IAP acquisitions
            //requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/inappacquisitions?applicationId={0}&startDate={1}&endDate={2}&top={3}&skip={4}",
            //    appID, startDate, endDate, top, skip);

            //// Get app failures
            //requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/failurehits?applicationId={0}&startDate={1}&endDate={2}&top={3}&skip={4}",
            //    appID, startDate, endDate, top, skip);

            //// Get app ratings
            //requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/ratings?applicationId={0}&startDate={1}&endDate={2}top={3}&skip={4}",
            //    appID, startDate, endDate, top, skip);

            //// Get app reviews
            //requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews?applicationId={0}&startDate={1}&endDate={2}&top={3}&skip={4}",
            //    appID, startDate, endDate, top, skip);

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, requestURI);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            WebRequestHandler handler = new WebRequestHandler();
            HttpClient httpClient = new HttpClient(handler);

            HttpResponseMessage response = httpClient.SendAsync(requestMessage).Result;

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            response.Dispose();
        }

        public static async Task<string> GetClientCredentialAccessToken(string tenantId, string clientId, string clientSecret, string scope)
        {
            string tokenEndpointFormat = "https://login.microsoftonline.com/{0}/oauth2/token";
            string tokenEndpoint = string.Format(tokenEndpointFormat, tenantId);

            dynamic result;
            using (HttpClient client = new HttpClient())
            {
                string tokenUrl = tokenEndpoint;
                using (
                    HttpRequestMessage request = new HttpRequestMessage(
                        HttpMethod.Post,
                        tokenUrl))
                {
                    string content =
                        string.Format(
                            "grant_type=client_credentials&client_id={0}&client_secret={1}&resource={2}",
                            clientId,
                            clientSecret,
                            scope);

                    request.Content = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject(responseContent);
                    }
                }
            }

            return result.access_token;
        }
    }
}
```

## エラー応答


Windows ストア分析 API は、エラー コードとメッセージが含まれた JSON オブジェクトにエラー応答を返します。 次の例は、無効なパラメーターに対するエラー応答を示しています。

```json
{
    "code":"BadRequest",
    "data":[],
    "details":[],
    "innererror":{
        "code":"InvalidQueryParameters",
        "data":[
            "top parameter cannot be more than 10000"
        ],
        "details":[],
        "message":"One or More Query Parameters has invalid values.",
        "source":"AnalyticsAPI"
    },
    "message":"The calling client sent a bad request to the service.",
    "source":"AnalyticsAPI"
}
```

## 関連トピック

* [アプリの入手数の取得](get-app-acquisitions.md)
* [IAP の入手数の取得](get-in-app-acquisitions.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリの評価の取得](get-app-ratings.md)
* [アプリのレビューの取得](get-app-reviews.md)
 


<!--HONumber=Mar16_HO3-->


