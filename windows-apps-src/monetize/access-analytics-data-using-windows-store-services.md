---
xx.xxxxxxx: YXXYXXYY-XYXY-YYXX-YYXY-YYYXYXYYXYXY
xxxxxxxxxxx: Xxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX xx xxxxxxxxxxxxxxxx xxxxxxxx xxxxxxxxx xxxx xxx xxxx xxxx xxx xxxxxxxxxx xx xxxx xx xxxx xxxxxxxxxxxx''x Xxxxxxx Xxx Xxxxxx xxxxxxx.
xxxxx: Xxxxxx xxxxxxxxx xxxx xxxxx Xxxxxxx Xxxxx xxxxxxxx
---

# Xxxxxx xxxxxxxxx xxxx xxxxx Xxxxxxx Xxxxx xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxx xxx *Xxxxxxx Xxxxx xxxxxxxxx XXX* xx xxxxxxxxxxxxxxxx xxxxxxxx xxxxxxxxx xxxx xxx xxxx xxxx xxx xxxxxxxxxx xx xxxx xx xxxx xxxxxxxxxxxx'x Xxxxxxx Xxx Xxxxxx xxxxxxx. Xxxx XXX xxxxxxx xxx xx xxxxxxxx xxxx xxx xxx xxx XXX xxxxxxxxxxxx, xxxxxx, xxx xxxxxxx xxx xxxxxxx. Xxxx XXX xxxx Xxxxx Xxxxxx Xxxxxxxxx (Xxxxx XX) xx xxxxxxxxxxxx xxx xxxxx xxxx xxxx xxx xx xxxxxxx.

## Xxxxxxxxxxxxx xxx xxxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX


-   Xxx (xx xxxx xxxxxxxxxxxx) xxxx xxxx xx Xxxxx XX xxxxxxxxx. Xx xxx xxxxxxx xxx Xxxxxx YYY xx xxxxx xxxxxxxx xxxxxxxx xxxx Xxxxxxxxx, xxx xxxxxxx xxxx Xxxxx XX xxxxxxxxx. Xxxxxxxxx, xxx xxx [xxx xxx xxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=703757).
-   Xxx xxxx xxxx x [xxxx xxxxxxx](https://azure.microsoft.com/documentation/articles/active-directory-create-users/) xx xxx Xxxxx XX xxxxxxxxx xxxx xxx xxxx xx xxxxxxxxx xxxx xxxx Xxxxxxx Xxx Xxxxxx xxxxxxx.

## Xxxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX


Xxxxxx xxx xxx xxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX, xxx xxxx xxxxxxxxx xx Xxxxx XX xxxxxxxxxxx xxxx xxxx Xxx Xxxxxx xxxxxxx xxx xxxxxx xx Xxxxx XX xxxxxx xxxxx. Xxx Xxxxx XX xxxxxxxxxxx xxxxxxxxxx xxx xxx xx xxxxxxx xxxx xxxxx xxx xxxx xx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX. Xxxxx xxx xxxx xx xxxxxx xxxxx, xxx xxx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX xxxx xxxx xxx xx xxxxxxx.

Xxx xxxxxxxxx xxxxx xxxxxxxx xxx xxx-xx-xxx xxxxxxx:

1.  [Xxxxxxxxx xx Xxxxx XX xxxxxxxxxxx xxxx xxxx Xxxxxxx Xxx Xxxxxx xxxxxxx](#associate-an-azure-ad-application-with-your-windows-dev-center-account).
2.  [Xxxxxx xx Xxxxx XX xxxxxx xxxxx](#obtain-an-azure-ad-access-token).
3.  [Xxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX](#call-the-windows-store-analytics-api).


### Xxxxxxxxx xx Xxxxx XX xxxxxxxxxxx xxxx xxxx Xxxxxxx Xxx Xxxxxx xxxxxxx

1.  Xx Xxx Xxxxxx, xx xx xxxx **Xxxxxxx xxxxxxxx**, xxxxx **Xxxxxx xxxxx**, xxx xxxxxxxxx xxxx xxxxxxxxxxxx'x Xxx Xxxxxx xxxxxxx xxxx xxxx xxxxxxxxxxxx'x Xxxxx XX xxxxxxxxx. Xxx xxxxxxxx xxxxxxxxxxxx, xxx [Xxxxxx xxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt489008). Xxx xxx xxxxxxxxxx xxx xxxxx xxxxx xxxx xxxx xxxxxxxxxxxx'x Xxxxx XX xxxxxxxxx xx xxxx xxx xxxx xxxxxx xxx Xxx Xxxxxx xxxxxxx.

    **Xxxx**  Xxxx xxx Xxx Xxxxxx xxxxxxx xxx xx xxxxxxxxxx xxxx xx Xxxxx Xxxxxx Xxxxxxxxx. Xxxxxxxxx, xxxx xxx Xxxxx Xxxxxx Xxxxxxxxx xxx xx xxxxxxxxxx xxxx x Xxx Xxxxxx xxxxxxx. Xxxxx xxx xxxxxxxxx xxxx xxxxxxxxxxx, xxx xxx'x xx xxxx xx xxxxxx xx xxxxxxx xxxxxxxxxx xxxxxxx.

     

2.  Xx xxx **Xxxxxx xxxxx** xxxx, xxxxx **Xxx Xxxxx XX xxxxxxxxxxxx**, xxx xxx Xxxxx XX xxxxxxxxxxx xxxx xxx xxxx xxx xx xxxxxx xxxxxxxxx xxxx xxx xxxx Xxx Xxxxxx xxxxxxx, xxx xxxxxx xx xxx **Xxxxxxx** xxxx. Xx xxxx xxxxxxxxxxx xxxxxxx xxxxxx xx xxxx Xxxxx XX xxxxxxxxx, xxx xxx xxxxxx xx xx xxx **Xxx Xxxxx XX xxxxxxxxxxxx** xx xxx xx xx xxxx Xxx Xxxxxx xxxxxxx. Xxxxxxxxx, xxx xxx xxxxxx x xxx Xxxxx XX xxxxxxxxxxx xx xxx **Xxx Xxxxx XX xxxxxxxxxxxx** xxxx. Xxx xxxx xxxxxxxxxxx, xxx xxx xxxxxxx xxxxx xxxxxxxx Xxxxx XX xxxxxxxxxxxx xx [Xxxxxx xxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt489008).

3.  Xxxxxx xx xxx **Xxxxxx xxxxx** xxxx, xxxxx xxx xxxx xx xxxx Xxxxx XX xxxxxxxxxxx xx xx xx xxx xxxxxxxxxxx xxxxxxxx, xxx xxxxx **Xxx xxx xxx**. Xx xxx xxxxxxxxx xxxxxx, xxxx xxxx xxx **Xxxxxx XX** xxx **Xxx** xxxxxx. Xxx xxxx xxxxxxxxxxx, xxx xxx xxxxxxx xxxxx xxxxxxxx Xxxxx XX xxxxxxxxxxxx xx [Xxxxxx xxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt489008). Xxx xxxx xxxxx xxx xxxxxx XX xxx xxx xx xxxxxx xx Xxxxx XX xxxxxx xxxxx xx xxx xxxx xxxxxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX. Xxx xxx'x xx xxxx xx xxxxxx xxxx xxxx xxxxx xxxxx xxx xxxxx xxxx xxxx.


### Xxxxxx xx Xxxxx XX xxxxxx xxxxx

Xxxxx xxx xxxxxxxxx xx Xxxxx XX xxxxxxxxxxx xxxx xxxx Xxx Xxxxxx xxxxxxx xxx xxx xxxxxxxx xxx xxxxxx XX xxx xxx xxx xxx xxxxxxxxxxx, xxx xxx xxx xxxx xxxx xx xxxxxx xx Xxxxx XX xxxxxx xxxxx. Xxx xxxx xx xxxxxx xxxxx xxxxxx xxx xxx xxxx xxx xx xxx xxxxxxx xx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX.

Xx xxxxxx xxx xxxxxx xxxxx, xxxxxx xxx xxxxxxxxxxxx xx [Xxxxxxx xx Xxxxxxx Xxxxx Xxxxx Xxxxxx Xxxxxxxxxxx](https://msdn.microsoft.com/library/azure/dn645543.aspx) xx xxxx xx XXXX XXXX xx xxx xxxxxxxxx Xxxxx XX xxxxxxxx.

```
https://login.microsoftonline.com/<tenant id>/oauth2/token
```

-   Xx xxx xxxx xxxxxx XX, xxx xx xx xxx [Xxxxx Xxxxxxxxxx Xxxxxx](http://manage.windowsazure.com/), xxxxxxxx xx **Xxxxxx Xxxxxxxxx**, xxx xxxxx xxx xxxxxxxxx xxxx xxx xxxxxx xx xxxx Xxx Xxxxxx xxxxxxx. Xxx xxxxxx XX xxx xxxx xxxxxxxxx xx xxxxxxxx xx xxx XXX xxx xxxx xxxx, xx xxxxx xx xxx *xxxx\_xxxxxx\_XX* xxxxxx xx xxx xxxxxxx xxxxx.

  ```
  https://manage.windowsazure.com/@&lt;your_tenant_name&gt;#Workspaces/ActiveDirectoryExtension/Directory/&lt;your_tenant_ID&gt;/directoryQuickStart
  ```

-   Xxx xxx *xxxxxx\_xx* xxx *xxxxxx\_xxxxxx* xxxxxxxxxx, xxxxxxx xxx xxxxxx XX xxx xxx xxx xxx xxxx xxxxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxx xxxx Xxx Xxxxxx.
-   Xxx xxx *xxxxxxxx* xxxxxxxxx, xxxxxxx xxx xxxxxxxxx XXX: **xxxxx://xxxxxx.xxxxxxxxx.xxxxxxxxx.xxx**.


### Xxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX

Xxxxx xxx xxxx xx Xxxxx XX xxxxxx xxxxx, xxx xxx xxxxx xx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX. Xxx xxxxxxxxxxx xxxxx xxx xxxxxx xx xxxx xxxxxx, xxx xxx xxxxxxxxx xxxxxxxx. Xxx xxxx xxxx xxx xxxxxx xxxxx xx xxx **Xxxxxxxxxxxxx** xxxxxx xx xxxx xxxxxx.

-   [Xxx xxx xxxxxxxxxxxx](get-app-acquisitions.md)
-   [Xxx XXX xxxxxxxxxxxx](get-in-app-acquisitions.md)
-   [Xxx xxxxx xxxxxxxxx xxxx](get-error-reporting-data.md)
-   [Xxx xxx xxxxxxx](get-app-ratings.md)
-   [Xxx xxx xxxxxxx](get-app-reviews.md)

## Xxxx xxxxxxx


Xxx xxxxxxxxx xxxx xxxxxxx xxxxxxxxxxxx xxx xx xxxxxx xx Xxxxx XX xxxxxx xxxxx xxx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX xxxx x X\# xxxxxxx xxx. Xx xxx xxxx xxxx xxxxxxx, xxxxxx xxx *xxxxxxXx*, *xxxxxxXx*, *xxxxxxXxxxxx*, xxx *xxxXX* xxxxxxxxx xx xxx xxxxxxxxxxx xxxxxx xxx xxxx xxxxxxxx. Xxxx xxxxxxx xxxxxxxx xxx [Xxxx.XXX xxxxxxx](http://www.newtonsoft.com/json) xxxx Xxxxxxxxxx xx xxxxxxxxxxx xxx XXXX xxxx xxxxxxxx xx xxx Xxxxxxx Xxxxx xxxxxxxxx XXX.

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

            // This is your app&#39;s product ID. This ID is embedded in the app&#39;s listing link
            // on the App identity page of the Dev Center dashboard.
            string appID = "<your app&#39;s product ID>";

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
                "https://manage.devcenter.microsoft.com/v1.0/my/analytics/appacquisitions?applicationId={0}&amp;startDate={1}&amp;endDate={2}&amp;top={3}&amp;skip={4}",
                appID, startDate, endDate, top, skip);

            //// Get IAP acquisitions
            //requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/inappacquisitions?applicationId={0}&amp;startDate={1}&amp;endDate={2}&amp;top={3}&amp;skip={4}",
            //    appID, startDate, endDate, top, skip);

            //// Get app failures
            //requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/failurehits?applicationId={0}&amp;startDate={1}&amp;endDate={2}&amp;top={3}&amp;skip={4}",
            //    appID, startDate, endDate, top, skip);

            //// Get app ratings
            //requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/ratings?applicationId={0}&amp;startDate={1}&amp;endDate={2}&amp;top={3}&amp;skip={4}",
            //    appID, startDate, endDate, top, skip);

            //// Get app reviews
            //requestURI = string.Format(
            //    "https://manage.devcenter.microsoft.com/v1.0/my/analytics/reviews?applicationId={0}&amp;startDate={1}&amp;endDate={2}&amp;top={3}&amp;skip={4}",
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
                            "grant_type=client_credentials&amp;client_id={0}&amp;client_secret={1}&amp;resource={2}",
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

## Xxxxx xxxxxxxxx


Xxx Xxxxxxx Xxxxx xxxxxxxxx XXX xxxxxxx xxxxx xxxxxxxxx xx x XXXX xxxxxx xxxx xxxxxxxx xxxxx xxxxx xxx xxxxxxxx. Xxx xxxxxxxxx xxxxxxx xxxxxxxxxxxx xx xxxxx xxxxxxxx xxxxxx xx xx xxxxxxx xxxxxxxxx.

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

## Xxxxxxx xxxxxx

* [Xxx xxx xxxxxxxxxxxx](get-app-acquisitions.md)
* [Xxx XXX xxxxxxxxxxxx](get-in-app-acquisitions.md)
* [Xxx xxxxx xxxxxxxxx xxxx](get-error-reporting-data.md)
* [Xxx xxx xxxxxxx](get-app-ratings.md)
* [Xxx xxx xxxxxxx](get-app-reviews.md)
 
<!--HONumber=Mar16_HO1-->
