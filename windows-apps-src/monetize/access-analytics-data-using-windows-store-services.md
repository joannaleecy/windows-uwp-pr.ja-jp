---
author: mcleanbyron
ms.assetid: 4BF9EF21-E9F0-49DB-81E4-062D6E68C8B1
description: "Windows ストア分析 API を使って、自分または自分の組織の Windows デベロッパー センター アカウントに登録されたアプリの分析データをプログラムで取得することができます。"
title: "Windows ストア サービスを使った分析データへのアクセス"
translationtype: Human Translation
ms.sourcegitcommit: dcf4c263ff3fd8df846d1d5620ba31a9da7a5e6c
ms.openlocfilehash: 5ae5dcbe6684aa34a1428760cd5c7e9b8f599ebf

---

# <a name="access-analytics-data-using-windows-store-services"></a>Windows ストア サービスを使った分析データへのアクセス

*Windows ストア分析 API* を使って、自分または自分の組織の Windows デベロッパー センター アカウントに登録されたアプリの分析データをプログラムで取得することができます。 この API では、アプリおよびアドオン (アプリ内製品または IAP とも呼ばれます) の入手数、エラー、アプリの評価とレビューに関するデータを取得できます。 この API は、Azure Active Directory (Azure AD) を使って、アプリまたはサービスからの呼び出しを認証します。

次の手順で、このプロセスについて詳しく説明しています。

1.  すべての[前提条件](#prerequisites)を完了したことを確認します。
2.  Windows ストア分析 API でメソッドを呼び出す前に、[Azure AD アクセス トークンを取得](#obtain-an-azure-ad-access-token)する必要があります。 トークンを取得した後、Windows ストア分析 API への呼び出しでこのトークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、新しいトークンを生成できます。
3.  [Windows ストア分析 API を呼び出します](#call-the-windows-store-analytics-api)。

<span id="prerequisites" />
## <a name="step-1-complete-prerequisites-for-using-the-windows-store-analytics-api"></a>手順 1: Windows ストア分析 API を使うための前提条件を完了する

Windows ストア分析 API を呼び出すコードの作成を開始する前に、次の前提条件が完了していることを確認します。

* ユーザー (またはユーザーの組織) は、Azure AD ディレクトリと、そのディレクトリに対する[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可を持っている必要があります。 Office 365 または Microsoft の他のビジネス サービスを既に使っている場合は、既に Azure AD ディレクトリをお持ちです。 それ以外の場合は、追加料金なしで[デベロッパー センター内から新しい Azure AD を作成](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users)できます。

* Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、アプリケーションのテナント ID とクライアント ID を取得してキーを生成する必要があります。 Azure AD アプリケーションは、Windows ストア分析 API の呼び出し元のアプリまたはサービスを表します。 テナント ID、クライアント ID、およびキーは、API に渡す Azure AD アクセス トークンを取得するために必要です。

  >**注:**&nbsp;&nbsp;この作業を行うのは一度だけです。 テナント ID、クライアント ID、キーがあれば、新しい Azure AD アクセス トークンの作成が必要になったときに、いつでもそれらを再利用できます。

Azure AD アプリケーションをデベロッパー センター アカウントに関連付け、必要な値を取得するには:

1.  デベロッパー センターで、**[アカウント設定]** に移動して **[ユーザーの管理]** をクリックし、組織のデベロッパー センター アカウントを組織の Azure AD ディレクトリに関連付けます。 詳しい手順については、「[アカウント ユーザーの管理](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users)」をご覧ください。

2.  **[ユーザーの管理]** ページで、**[Azure AD アプリケーションの追加]** をクリックして、デベロッパー センター アカウントの分析データへのアクセスに使うアプリやサービスを表す Azure AD アプリケーションを追加し、**マネージャー** ロールを割り当てます。 このアプリケーションが既に Azure AD ディレクトリに存在する場合、**[Azure AD アプリケーションの追加]** ページで選んでデベロッパー センター アカウントに追加できます。 それ以外の場合、**[Azure AD アプリケーションの追加]** ページで新しい Azure AD アプリケーションを作成できます。 詳しくは、「[Azure AD アプリケーションを追加して管理する](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users#add-and-manage-azure-ad-applications)」をご覧ください。

3.  **[ユーザーの管理]** ページに戻り、Azure AD アプリケーションの名前をクリックしてアプリケーション設定に移動し、**[テナント ID]** と **[クライアント ID]** の値を書き留めます。

4. **[新しいキーの追加]** をクリックします。 次の画面で、**[キー]** の値を書き留めます。 このページから離れると、この情報に再度アクセスすることはできません。 詳しくは、「[Azure AD アプリケーションを追加して管理する](https://msdn.microsoft.com/windows/uwp/publish/manage-account-users#add-and-manage-azure-ad-applications)」でキーの管理に関する情報をご覧ください。

<span id="obtain-an-azure-ad-access-token" />
## <a name="step-2-obtain-an-azure-ad-access-token"></a>手順 2: Azure AD のアクセス トークンを取得する

Windows ストア分析 API で任意のメソッドを呼び出す前に、API 内の各メソッドの **Authorization** ヘッダーに渡す Azure AD アクセス トークンをまず取得する必要があります アクセス トークンを取得した後、アクセス トークンを使用できるのは、その有効期限が切れるまでの 60 分間です。 トークンの有効期限が切れた後は、トークンを更新してそれ以降の API 呼び出しで引き続き使用できます。

アクセス トークンを取得するには、「[クライアント資格情報を使用したサービス間の呼び出し](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-service-to-service/)」の手順に従って、HTTP POST を ```https://login.microsoftonline.com/<tenant_id>/oauth2/token``` エンドポイントに送信します。 要求の例を次に示します。

```
POST https://login.microsoftonline.com/<your_tenant_id>/oauth2/token HTTP/1.1
Host: login.microsoftonline.com
Content-Type: application/x-www-form-urlencoded; charset=utf-8

grant_type=client_credentials
&client_id=<your_client_id>
&client_secret=<your_client_secret>
&resource=https://manage.devcenter.microsoft.com
```

*tenant\_id*、*client \_id*、*client \_secret* の各パラメーターには、前のセクションでデベロッパー センターから取得したテナント ID、クライアント ID、キーを指定します。 *resource* パラメーターには、```https://manage.devcenter.microsoft.com``` という URI を指定します。

アクセス トークンの有効期限が切れた後は、[この](https://azure.microsoft.com/documentation/articles/active-directory-protocols-oauth-code/#refreshing-the-access-tokens)手順に従って更新できます。

<span id="call-the-windows-store-analytics-api" />
## <a name="step-3-call-the-windows-store-analytics-api"></a>手順 3: Windows ストア分析 API を呼び出す

Azure AD アクセス トークンを取得したら、Windows ストア分析 API を呼び出すことができます。 各メソッドの構文については、次の記事をご覧ください。 各メソッドの **Authorization** ヘッダーにアクセス トークンを渡す必要があります。

* [アプリの入手数の取得](get-app-acquisitions.md)
* [アドオンの入手数の取得](get-in-app-acquisitions.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)
* [アプリのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-app.md)
* [アプリの評価の取得](get-app-ratings.md)
* [アプリのレビューの取得](get-app-reviews.md)
* [広告のパフォーマンス データの取得](get-ad-performance-data.md)
* [広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md)

## <a name="code-example"></a>コードの例


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

            // This is your app's Store ID. This ID is available on
            // the App identity page of the Dev Center dashboard.
            string appID = "<your app's Store ID>";

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

            //// Get add-on acquisitions
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

## <a name="error-responses"></a>エラー応答


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

## <a name="related-topics"></a>関連トピック

* [アプリの入手数の取得](get-app-acquisitions.md)
* [アドオンの入手数の取得](get-in-app-acquisitions.md)
* [エラー報告データの取得](get-error-reporting-data.md)
* [アプリのエラーに関する詳細情報の取得](get-details-for-an-error-in-your-app.md)
* [アプリのエラーに関するスタック トレースの取得](get-the-stack-trace-for-an-error-in-your-app.md)
* [アプリの評価の取得](get-app-ratings.md)
* [アプリのレビューの取得](get-app-reviews.md)
* [広告のパフォーマンス データの取得](get-ad-performance-data.md)
* [広告キャンペーンのパフォーマンス データの取得](get-ad-campaign-performance-data.md)
 



<!--HONumber=Dec16_HO1-->


