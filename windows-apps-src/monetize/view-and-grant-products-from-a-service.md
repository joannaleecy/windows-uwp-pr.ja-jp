---
ms.assetid: B071F6BC-49D3-4E74-98EA-0461A1A55EFB
description: If you have a catalog of apps and in-app products (IAPs), you can use the Windows Store collection API and Windows Store purchase API to access ownership information for these products from your services.
title: View and grant products from a service
---

# View and grant products from a service


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


If you have a catalog of apps and in-app products (IAPs), you can use the *Windows Store collection API* and *Windows Store purchase API* to access ownership information for these products from your services.

These APIs consist of REST methods that are designed to be used by developers with IAP catalogs that are supported by cross-platform services. These APIs enable you to do the following:

-   Windows Store collection API: Query for apps and IAPs owned by a given user, or report a consumable product as fulfilled.
-   Windows Store purchase API: Grant a free app or IAP to a given user.

## Using the Windows Store collection API and Windows Store purchase API


The Windows Store collection API and purchase API use Azure Active Directory (Azure AD) authentication to access customer ownership information. Before you can call these APIs, you must apply Azure AD metadata to your application in the Windows Dev Center dashboard and generate several required access tokens and keys. The following steps describe the end-to-end process:

1.  [Configure a Web application in Azure AD](#step-1:-configure-a-web-application-in-azure-ad). This application represents your cross-platform services in the context of Azure AD.
2.  [Associate your Azure AD client ID with your application in the Windows Dev Center dashboard](#step-2:-associate-your-azure-ad-client-id-with-your-application-in-the-windows-dev-denter-dashboard).
3.  In your service, [generate Azure AD access tokens](#step-3:-retrieve-access-tokens-from-azure-ad) that represent your publisher identity.
4.  In client-side code in your Windows app, [generate a Windows Store ID key](#step-4:-generate-a-windows-store-id-key-from-client-side-code-in-your-app) that represents the identity of the current user, and pass the Windows Store ID key back to your service.
5.  After you have the required Azure AD access token and Windows Store ID key, [call the Windows Store collection API or purchase API from your service](#step-5:-call-the-windows-store-collection-api-or-purchase-api-from-your-service).

The following sections provide more details about each of these steps.

### Step 1: Configure a Web application in Azure AD

1.  Follow the instructions in [Integrating Applications with Azure Active Directory](http://go.microsoft.com/fwlink/?LinkId=722502) to add a Web application to Azure AD.
    **Note**  On the **Tell us about your application page**, make sure that you choose **Web application and/or web API**. This is required so that you can obtain a key (also called a *client secret*) for your application. In order to call the Windows Store collection API or purchase API, you must provide a client secret when you request an access token from Azure AD in a later step.
2.  In the [Azure Management Portal](http://manage.windowsazure.com/), navigate to **Active Directory**. Select your directory, click the **Applications** tab at the top, and then select your application.
3.  Click the **Configure** tab. On this tab, obtain the client ID for your application and request a key (this is called a *client secret* in later steps).
4.  At the bottom of the screen, click **Manage manifest**. Download your Azure AD application manifest and replace the `"identifierUris"` section with the following text.

    ```json
    "identifierUris" : [                                
            "https://onestore.microsoft.com",
            "https://onestore.microsoft.com/b2b/keys/create/collections",
            "https://onestore.microsoft.com/b2b/keys/create/purchase"
        ],
    ```

    These strings represent the audiences supported by your application. In a later step, you will create Azure AD access tokens that are associated with each of these audience values. For more information about how to download your application manifest, see [Understanding the Azure Active Directory application manifest]( http://go.microsoft.com/fwlink/?LinkId=722500).

5.  Save your application manifest and upload it to your application in the [Azure Management Portal](http://manage.windowsazure.com/).

### Step 2: Associate your Azure AD client ID with your application in the Windows Dev Center dashboard

The Windows Store collection API and purchase API only provide access to a user's ownership information for apps and IAPs that you have associated with your Azure AD client ID.

1.  Sign in to the [Windows Dev Center dashboard](https://dev.windows.com/overview) and select your app.
2.  Go to the **Services** &gt; **Product collections and purchases** page and enter your Azure AD client ID into one of the available fields.

### Step 3: Retrieve access tokens from Azure AD

Before you can retrieve a Windows Store ID key or call the Windows Store collection API or purchase API, your service must request three Azure AD access tokens that represent your publisher identity. Each of these access tokens is associated with a different audience URI, and each token will be used with a different API call. The lifetime of each token is 60 minutes, and you can refresh them after they expire.

To create the access tokens, use the OAuth 2.0 API in your service by following the instructions in [Service to Service Calls Using Client Credentials](https://msdn.microsoft.com/library/azure/dn645543.aspx). For each token, specify the following parameter data:

-   For the *client\_id* and *client\_secret* parameters, specify the client ID and the client secret for your application as obtained from the [Azure Management Portal](http://manage.windowsazure.com/). Both of these parameters are required in order to generate an access token with the level of authentication required by the Windows Store collection API or purchase API.
-   For the *resource* parameter, specify one of the following app ID URIs (these are the same URIs that you previously added to the `"identifierUris"` section of the application manifest). At the end of this process, you should have three access tokens that each have one of these app ID URIs associated with them:
    -   **https://onestore.microsoft.com/b2b/keys/create/collections**: In a later step, you will use the access token that you create with this URI to request a Windows Store ID key that you can use with the Windows Store collection API.
    -   **https://onestore.microsoft.com/b2b/keys/create/purchase**: In a later step, you will use the access token that you create with this URI to request a Windows Store ID key that you can use with the Windows Store purchase API.
    -   **https://onestore.microsoft.com**: In a later step, you will use the access token that you create with this URI in direct calls to the Windows Store collection API or purchase API.

    **Important**  Use the **https://onestore.microsoft.com** audience only with access tokens that are stored securely within your service. Exposing access tokens with this audience outside your service could make your service vulnerable to replay attacks.

For more details about the structure of an access token, see [Supported Token and Claim Types](http://go.microsoft.com/fwlink/?LinkId=722501).

**Important**  You should create Azure AD access tokens only in the context of your service, not in your app. Your client secret could be compromised if it is sent to your app.

 

### Step 4: Generate a Windows Store ID key from client-side code in your app

Before you can call the Windows Store collection API or purchase API, your service must obtain a Windows Store ID key. This is a JSON Web Token (JWT) that represents the identity of the user whose product ownership information you want to access. For more information about the claims in this key, see [Claims in a Windows Store ID key](#windowsstorekey).

Currently, the only way to obtain a Windows Store ID key is by calling a Universal Windows Platform (UWP) API from client-side code in your app to retrieve the identity of the user who is currently signed in to the Windows Store. To generate a Windows Store ID key:

1.  Pass one of the following access tokens from your service to your client app:
    -   To get a Windows Store ID key that you can use with the Windows Store collection API, pass the Azure AD access token that you created with the **https://onestore.microsoft.com/b2b/keys/create/collections** audience URI.
    -   To get a Windows Store ID key that you can use with the Windows Store purchase API, pass the Azure AD access token that you created with the **https://onestore.microsoft.com/b2b/keys/create/purchase** audience URI.

2.  In your app code, call one of the following methods of the [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) class to retrieve a Windows Store ID key.

    -   [**GetCustomerCollectionsIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608674): Call this method if you intend to use the Windows Store collection API.
    -   [**GetCustomerPurchaseIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608675): Call this method if you intend to use the Windows Store purchase API.

    For either method, pass your Azure AD access token to the *serviceTicket* parameter. You can optionally pass an ID to the *publisherUserId* parameter that identifies the current user in the context of your services. If you maintain user IDs for your services, you can use this parameter to correlate these user IDs with the calls you make to the Windows Store collection API or purchase API.

3.  After your app successfully retrieves a Windows Store ID key, pass the key back to your service.

**Note**  Each Windows Store ID key is valid for 90 days. After a key expires, you can [renew the key](renew-a-windows-store-id-key.md). We recommend that you renew your Windows Store ID keys rather than creating new ones.

 

### Step 5: Call the Windows Store collection API or purchase API from your service

After your service has a Windows Store ID key that enables it to access a specific user's product ownership information, your service can call the Windows Store collection API or purchase API. Use the instructions that apply to your scenario:

-   [Query for products](query-for-products.md)
-   [Report consumable products as fulfilled](report-consumable-products-as-fulfilled.md)
-   [Grant free products](grant-free-products.md)

For each scenario, pass the following information to the API:

-   The Azure AD access token that you created earlier with the **https://onestore.microsoft.com** audience URI. This token represents your publisher identity. Pass this token in the request header.
-   The Windows Store ID key you retrieved from [**GetCustomerCollectionsIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608674) or [**GetCustomerPurchaseIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608675) in your app. This key represents the identity of the user whose product ownership information you want to access.

## Claims in a Windows Store ID key


A Windows Store ID key is a JSON Web Token (JWT) that represents the identity of the user whose product ownership information you want to access. When decoded using Base64, a Windows Store ID key contains the following claims.

| Claim name                                                             | Description                                                                                                                                                                                                                                                                                                                                                                             |
|------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| iat                                                                    | Identifies the time at which the key was issued. This claim can be used to determine the age of the token. This value is expressed as epoch time.                                                                                                                                                                                                                                       |
| iss                                                                    | Identifies the issuer. This has the same value as the *aud* claim.                                                                                                                                                                                                                                                                                                                      |
| aud                                                                    | Identifies the audience. Must be one of the following values: **https://collections.mp.microsoft.com/v6.0/keys** or **https://purchase.mp.microsoft.com/v6.0/keys**.                                                                                                                                                                                                                    |
| exp                                                                    | Identifies the expiration time on or after which the key will no longer be accepted for processing anything except for renewing keys. The value of this claim is expressed as epoch time.                                                                                                                                                                                               |
| nbf                                                                    | Identifies the time at which the token will be accepted for processing. The value of this claim is expressed as epoch time.                                                                                                                                                                                                                                                             |
| http://schemas.microsoft.com/marketplace/2015/08/claims/key/clientId   | The client ID that identifies the developer.                                                                                                                                                                                                                                                                                                                                            |
| http://schemas.microsoft.com/marketplace/2015/08/claims/key/payload    | An opaque payload (encrypted and Base64 encoded) that contains information that is intended only for use by Windows Store services.                                                                                                                                                                                                                                                     |
| http://schemas.microsoft.com/marketplace/2015/08/claims/key/userId     | A user ID that identifies the current user in the context of your services. This is the same value you pass into the optional *publisherUserId* parameter of the [**GetCustomerCollectionsIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608674) or [**GetCustomerPurchaseIdAsync**](https://msdn.microsoft.com/library/windows/apps/mt608675) method when you create the key. |
| http://schemas.microsoft.com/marketplace/2015/08/claims/key/refreshUri | The URI that you can use to renew the key.                                                                                                                                                                                                                                                                                                                                              |

 

Here is an example of a decoded Windows Store ID key header.

```
{ 
    "typ":"JWT", 
    "alg":"RS256", 
    "x5t":"agA_pgJ7Twx_Ex2_rEeQ2o5fZ5g" 
} 
```

Here is an example of a decoded Windows Store ID key claim set.

```
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

## Related topics

* [Query for products](query-for-products.md)
* [Report consumable products as fulfilled](report-consumable-products-as-fulfilled.md)
* [Grant free products](grant-free-products.md)
* [Renew a Windows Store ID key](renew-a-windows-store-id-key.md)
* [Integrating Applications with Azure Active Directory](http://go.microsoft.com/fwlink/?LinkId=722502)
* [Understanding the Azure Active Directory application manifest]( http://go.microsoft.com/fwlink/?LinkId=722500)
* [Supported Token and Claim Types](http://go.microsoft.com/fwlink/?LinkId=722501)
 

 





<!--HONumber=Mar16_HO1-->


