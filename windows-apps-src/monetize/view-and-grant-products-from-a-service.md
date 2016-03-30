---
xx.xxxxxxx: XYYYXYXX-YYXY-YXYY-YYXX-YYYYXYXYYXXX
xxxxxxxxxxx: Xx xxx xxxx x xxxxxxx xx xxxx xxx xx-xxx xxxxxxxx (XXXx), xxx xxx xxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xxx Xxxxxxx Xxxxx xxxxxxxx XXX xx xxxxxx xxxxxxxxx xxxxxxxxxxx xxx xxxxx xxxxxxxx xxxx xxxx xxxxxxxx.
xxxxx: Xxxx xxx xxxxx xxxxxxxx xxxx x xxxxxxx
---

# Xxxx xxx xxxxx xxxxxxxx xxxx x xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xx xxx xxxx x xxxxxxx xx xxxx xxx xx-xxx xxxxxxxx (XXXx), xxx xxx xxx xxx *Xxxxxxx Xxxxx xxxxxxxxxx XXX* xxx *Xxxxxxx Xxxxx xxxxxxxx XXX* xx xxxxxx xxxxxxxxx xxxxxxxxxxx xxx xxxxx xxxxxxxx xxxx xxxx xxxxxxxx.

Xxxxx XXXx xxxxxxx xx XXXX xxxxxxx xxxx xxx xxxxxxxx xx xx xxxx xx xxxxxxxxxx xxxx XXX xxxxxxxx xxxx xxx xxxxxxxxx xx xxxxx-xxxxxxxx xxxxxxxx. Xxxxx XXXx xxxxxx xxx xx xx xxx xxxxxxxxx:

-   Xxxxxxx Xxxxx xxxxxxxxxx XXX: Xxxxx xxx xxxx xxx XXXx xxxxx xx x xxxxx xxxx, xx xxxxxx x xxxxxxxxxx xxxxxxx xx xxxxxxxxx.
-   Xxxxxxx Xxxxx xxxxxxxx XXX: Xxxxx x xxxx xxx xx XXX xx x xxxxx xxxx.

## Xxxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xxx Xxxxxxx Xxxxx xxxxxxxx XXX


Xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xxx xxxxxxxx XXX xxx Xxxxx Xxxxxx Xxxxxxxxx (Xxxxx XX) xxxxxxxxxxxxxx xx xxxxxx xxxxxxxx xxxxxxxxx xxxxxxxxxxx. Xxxxxx xxx xxx xxxx xxxxx XXXx, xxx xxxx xxxxx Xxxxx XX xxxxxxxx xx xxxx xxxxxxxxxxx xx xxx Xxxxxxx Xxx Xxxxxx xxxxxxxxx xxx xxxxxxxx xxxxxxx xxxxxxxx xxxxxx xxxxxx xxx xxxx. Xxx xxxxxxxxx xxxxx xxxxxxxx xxx xxx-xx-xxx xxxxxxx:

1.  [Xxxxxxxxx x Xxx xxxxxxxxxxx xx Xxxxx XX](#step-1:-configure-a-web-application-in-azure-ad). Xxxx xxxxxxxxxxx xxxxxxxxxx xxxx xxxxx-xxxxxxxx xxxxxxxx xx xxx xxxxxxx xx Xxxxx XX.
2.  [Xxxxxxxxx xxxx Xxxxx XX xxxxxx XX xxxx xxxx xxxxxxxxxxx xx xxx Xxxxxxx Xxx Xxxxxx xxxxxxxxx](#step-2:-associate-your-azure-ad-client-id-with-your-application-in-the-windows-dev-denter-dashboard).
3.  Xx xxxx xxxxxxx, [xxxxxxxx Xxxxx XX xxxxxx xxxxxx](#step-3:-retrieve-access-tokens-from-azure-ad) xxxx xxxxxxxxx xxxx xxxxxxxxx xxxxxxxx.
4.  Xx xxxxxx-xxxx xxxx xx xxxx Xxxxxxx xxx, [xxxxxxxx x Xxxxxxx Xxxxx XX xxx](#step-4:-generate-a-windows-store-id-key-from-client-side-code-in-your-app) xxxx xxxxxxxxxx xxx xxxxxxxx xx xxx xxxxxxx xxxx, xxx xxxx xxx Xxxxxxx Xxxxx XX xxx xxxx xx xxxx xxxxxxx.
5.  Xxxxx xxx xxxx xxx xxxxxxxx Xxxxx XX xxxxxx xxxxx xxx Xxxxxxx Xxxxx XX xxx, [xxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX xxxx xxxx xxxxxxx](#step-5:-call-the-windows-store-collection-api-or-purchase-api-from-your-service).

Xxx xxxxxxxxx xxxxxxxx xxxxxxx xxxx xxxxxxx xxxxx xxxx xx xxxxx xxxxx.

### Xxxx Y: Xxxxxxxxx x Xxx xxxxxxxxxxx xx Xxxxx XX

1.  Xxxxxx xxx xxxxxxxxxxxx xx [Xxxxxxxxxxx Xxxxxxxxxxxx xxxx Xxxxx Xxxxxx Xxxxxxxxx](http://go.microsoft.com/fwlink/?LinkId=722502) xx xxx x Xxx xxxxxxxxxxx xx Xxxxx XX.
    **Xxxx**  Xx xxx **Xxxx xx xxxxx xxxx xxxxxxxxxxx xxxx**, xxxx xxxx xxxx xxx xxxxxx **Xxx xxxxxxxxxxx xxx/xx xxx XXX**. Xxxx xx xxxxxxxx xx xxxx xxx xxx xxxxxx x xxx (xxxx xxxxxx x *xxxxxx xxxxxx*) xxx xxxx xxxxxxxxxxx. Xx xxxxx xx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX, xxx xxxx xxxxxxx x xxxxxx xxxxxx xxxx xxx xxxxxxx xx xxxxxx xxxxx xxxx Xxxxx XX xx x xxxxx xxxx.
2.  Xx xxx [Xxxxx Xxxxxxxxxx Xxxxxx](http://manage.windowsazure.com/), xxxxxxxx xx **Xxxxxx Xxxxxxxxx**. Xxxxxx xxxx xxxxxxxxx, xxxxx xxx **Xxxxxxxxxxxx** xxx xx xxx xxx, xxx xxxx xxxxxx xxxx xxxxxxxxxxx.
3.  Xxxxx xxx **Xxxxxxxxx** xxx. Xx xxxx xxx, xxxxxx xxx xxxxxx XX xxx xxxx xxxxxxxxxxx xxx xxxxxxx x xxx (xxxx xx xxxxxx x *xxxxxx xxxxxx* xx xxxxx xxxxx).
4.  Xx xxx xxxxxx xx xxx xxxxxx, xxxxx **Xxxxxx xxxxxxxx**. Xxxxxxxx xxxx Xxxxx XX xxxxxxxxxxx xxxxxxxx xxx xxxxxxx xxx `"identifierUris"` xxxxxxx xxxx xxx xxxxxxxxx xxxx.

    ```json
    "identifierUris" : [                                
            "https://onestore.microsoft.com",
            "https://onestore.microsoft.com/b2b/keys/create/collections",
            "https://onestore.microsoft.com/b2b/keys/create/purchase"
        ],
    ```

    Xxxxx xxxxxxx xxxxxxxxx xxx xxxxxxxxx xxxxxxxxx xx xxxx xxxxxxxxxxx. Xx x xxxxx xxxx, xxx xxxx xxxxxx Xxxxx XX xxxxxx xxxxxx xxxx xxx xxxxxxxxxx xxxx xxxx xx xxxxx xxxxxxxx xxxxxx. Xxx xxxx xxxxxxxxxxx xxxxx xxx xx xxxxxxxx xxxx xxxxxxxxxxx xxxxxxxx, xxx [Xxxxxxxxxxxxx xxx Xxxxx Xxxxxx Xxxxxxxxx xxxxxxxxxxx xxxxxxxx]( http://go.microsoft.com/fwlink/?LinkId=722500).

5.  Xxxx xxxx xxxxxxxxxxx xxxxxxxx xxx xxxxxx xx xx xxxx xxxxxxxxxxx xx xxx [Xxxxx Xxxxxxxxxx Xxxxxx](http://manage.windowsazure.com/).

### Xxxx Y: Xxxxxxxxx xxxx Xxxxx XX xxxxxx XX xxxx xxxx xxxxxxxxxxx xx xxx Xxxxxxx Xxx Xxxxxx xxxxxxxxx

Xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xxx xxxxxxxx XXX xxxx xxxxxxx xxxxxx xx x xxxx'x xxxxxxxxx xxxxxxxxxxx xxx xxxx xxx XXXx xxxx xxx xxxx xxxxxxxxxx xxxx xxxx Xxxxx XX xxxxxx XX.

1.  Xxxx xx xx xxx [Xxxxxxx Xxx Xxxxxx xxxxxxxxx](https://dev.windows.com/overview) xxx xxxxxx xxxx xxx.
2.  Xx xx xxx **Xxxxxxxx** &xx; **Xxxxxxx xxxxxxxxxxx xxx xxxxxxxxx** xxxx xxx xxxxx xxxx Xxxxx XX xxxxxx XX xxxx xxx xx xxx xxxxxxxxx xxxxxx.

### Xxxx Y: Xxxxxxxx xxxxxx xxxxxx xxxx Xxxxx XX

Xxxxxx xxx xxx xxxxxxxx x Xxxxxxx Xxxxx XX xxx xx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX, xxxx xxxxxxx xxxx xxxxxxx xxxxx Xxxxx XX xxxxxx xxxxxx xxxx xxxxxxxxx xxxx xxxxxxxxx xxxxxxxx. Xxxx xx xxxxx xxxxxx xxxxxx xx xxxxxxxxxx xxxx x xxxxxxxxx xxxxxxxx XXX, xxx xxxx xxxxx xxxx xx xxxx xxxx x xxxxxxxxx XXX xxxx. Xxx xxxxxxxx xx xxxx xxxxx xx YY xxxxxxx, xxx xxx xxx xxxxxxx xxxx xxxxx xxxx xxxxxx.

Xx xxxxxx xxx xxxxxx xxxxxx, xxx xxx XXxxx Y.Y XXX xx xxxx xxxxxxx xx xxxxxxxxx xxx xxxxxxxxxxxx xx [Xxxxxxx xx Xxxxxxx Xxxxx Xxxxx Xxxxxx Xxxxxxxxxxx](https://msdn.microsoft.com/library/azure/dn645543.aspx). Xxx xxxx xxxxx, xxxxxxx xxx xxxxxxxxx xxxxxxxxx xxxx:

-   Xxx xxx *xxxxxx\_xx* xxx *xxxxxx\_xxxxxx* xxxxxxxxxx, xxxxxxx xxx xxxxxx XX xxx xxx xxxxxx xxxxxx xxx xxxx xxxxxxxxxxx xx xxxxxxxx xxxx xxx [Xxxxx Xxxxxxxxxx Xxxxxx](http://manage.windowsazure.com/). Xxxx xx xxxxx xxxxxxxxxx xxx xxxxxxxx xx xxxxx xx xxxxxxxx xx xxxxxx xxxxx xxxx xxx xxxxx xx xxxxxxxxxxxxxx xxxxxxxx xx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX.
-   Xxx xxx *xxxxxxxx* xxxxxxxxx, xxxxxxx xxx xx xxx xxxxxxxxx xxx XX XXXx (xxxxx xxx xxx xxxx XXXx xxxx xxx xxxxxxxxxx xxxxx xx xxx `"identifierUris"` xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx). Xx xxx xxx xx xxxx xxxxxxx, xxx xxxxxx xxxx xxxxx xxxxxx xxxxxx xxxx xxxx xxxx xxx xx xxxxx xxx XX XXXx xxxxxxxxxx xxxx xxxx:
    -   **xxxxx://xxxxxxxx.xxxxxxxxx.xxx/xYx/xxxx/xxxxxx/xxxxxxxxxxx**: Xx x xxxxx xxxx, xxx xxxx xxx xxx xxxxxx xxxxx xxxx xxx xxxxxx xxxx xxxx XXX xx xxxxxxx x Xxxxxxx Xxxxx XX xxx xxxx xxx xxx xxx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX.
    -   **xxxxx://xxxxxxxx.xxxxxxxxx.xxx/xYx/xxxx/xxxxxx/xxxxxxxx**: Xx x xxxxx xxxx, xxx xxxx xxx xxx xxxxxx xxxxx xxxx xxx xxxxxx xxxx xxxx XXX xx xxxxxxx x Xxxxxxx Xxxxx XX xxx xxxx xxx xxx xxx xxxx xxx Xxxxxxx Xxxxx xxxxxxxx XXX.
    -   **xxxxx://xxxxxxxx.xxxxxxxxx.xxx**: Xx x xxxxx xxxx, xxx xxxx xxx xxx xxxxxx xxxxx xxxx xxx xxxxxx xxxx xxxx XXX xx xxxxxx xxxxx xx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX.

    **Xxxxxxxxx**  Xxx xxx **xxxxx://xxxxxxxx.xxxxxxxxx.xxx** xxxxxxxx xxxx xxxx xxxxxx xxxxxx xxxx xxx xxxxxx xxxxxxxx xxxxxx xxxx xxxxxxx. Xxxxxxxx xxxxxx xxxxxx xxxx xxxx xxxxxxxx xxxxxxx xxxx xxxxxxx xxxxx xxxx xxxx xxxxxxx xxxxxxxxxx xx xxxxxx xxxxxxx.

Xxx xxxx xxxxxxx xxxxx xxx xxxxxxxxx xx xx xxxxxx xxxxx, xxx [Xxxxxxxxx Xxxxx xxx Xxxxx Xxxxx](http://go.microsoft.com/fwlink/?LinkId=722501).

**Xxxxxxxxx**  Xxx xxxxxx xxxxxx Xxxxx XX xxxxxx xxxxxx xxxx xx xxx xxxxxxx xx xxxx xxxxxxx, xxx xx xxxx xxx. Xxxx xxxxxx xxxxxx xxxxx xx xxxxxxxxxxx xx xx xx xxxx xx xxxx xxx.

 

### Xxxx Y: Xxxxxxxx x Xxxxxxx Xxxxx XX xxx xxxx xxxxxx-xxxx xxxx xx xxxx xxx

Xxxxxx xxx xxx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX, xxxx xxxxxxx xxxx xxxxxx x Xxxxxxx Xxxxx XX xxx. Xxxx xx x XXXX Xxx Xxxxx (XXX) xxxx xxxxxxxxxx xxx xxxxxxxx xx xxx xxxx xxxxx xxxxxxx xxxxxxxxx xxxxxxxxxxx xxx xxxx xx xxxxxx. Xxx xxxx xxxxxxxxxxx xxxxx xxx xxxxxx xx xxxx xxx, xxx [Xxxxxx xx x Xxxxxxx Xxxxx XX xxx](#windowsstorekey).

Xxxxxxxxx, xxx xxxx xxx xx xxxxxx x Xxxxxxx Xxxxx XX xxx xx xx xxxxxxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) XXX xxxx xxxxxx-xxxx xxxx xx xxxx xxx xx xxxxxxxx xxx xxxxxxxx xx xxx xxxx xxx xx xxxxxxxxx xxxxxx xx xx xxx Xxxxxxx Xxxxx. Xx xxxxxxxx x Xxxxxxx Xxxxx XX xxx:

1.  Xxxx xxx xx xxx xxxxxxxxx xxxxxx xxxxxx xxxx xxxx xxxxxxx xx xxxx xxxxxx xxx:
    -   Xx xxx x Xxxxxxx Xxxxx XX xxx xxxx xxx xxx xxx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX, xxxx xxx Xxxxx XX xxxxxx xxxxx xxxx xxx xxxxxxx xxxx xxx **xxxxx://xxxxxxxx.xxxxxxxxx.xxx/xYx/xxxx/xxxxxx/xxxxxxxxxxx** xxxxxxxx XXX.
    -   Xx xxx x Xxxxxxx Xxxxx XX xxx xxxx xxx xxx xxx xxxx xxx Xxxxxxx Xxxxx xxxxxxxx XXX, xxxx xxx Xxxxx XX xxxxxx xxxxx xxxx xxx xxxxxxx xxxx xxx **xxxxx://xxxxxxxx.xxxxxxxxx.xxx/xYx/xxxx/xxxxxx/xxxxxxxx** xxxxxxxx XXX.

2.  Xx xxxx xxx xxxx, xxxx xxx xx xxx xxxxxxxxx xxxxxxx xx xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh779765) xxxxx xx xxxxxxxx x Xxxxxxx Xxxxx XX xxx.

    -   [
            **XxxXxxxxxxxXxxxxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/mt608674): Xxxx xxxx xxxxxx xx xxx xxxxxx xx xxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX.
    -   [
            **XxxXxxxxxxxXxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/mt608675): Xxxx xxxx xxxxxx xx xxx xxxxxx xx xxx xxx Xxxxxxx Xxxxx xxxxxxxx XXX.

    Xxx xxxxxx xxxxxx, xxxx xxxx Xxxxx XX xxxxxx xxxxx xx xxx *xxxxxxxXxxxxx* xxxxxxxxx. Xxx xxx xxxxxxxxxx xxxx xx XX xx xxx *xxxxxxxxxXxxxXx* xxxxxxxxx xxxx xxxxxxxxxx xxx xxxxxxx xxxx xx xxx xxxxxxx xx xxxx xxxxxxxx. Xx xxx xxxxxxxx xxxx XXx xxx xxxx xxxxxxxx, xxx xxx xxx xxxx xxxxxxxxx xx xxxxxxxxx xxxxx xxxx XXx xxxx xxx xxxxx xxx xxxx xx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX.

3.  Xxxxx xxxx xxx xxxxxxxxxxxx xxxxxxxxx x Xxxxxxx Xxxxx XX xxx, xxxx xxx xxx xxxx xx xxxx xxxxxxx.

**Xxxx**  Xxxx Xxxxxxx Xxxxx XX xxx xx xxxxx xxx YY xxxx. Xxxxx x xxx xxxxxxx, xxx xxx [xxxxx xxx xxx](renew-a-windows-store-id-key.md). Xx xxxxxxxxx xxxx xxx xxxxx xxxx Xxxxxxx Xxxxx XX xxxx xxxxxx xxxx xxxxxxxx xxx xxxx.

 

### Xxxx Y: Xxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX xxxx xxxx xxxxxxx

Xxxxx xxxx xxxxxxx xxx x Xxxxxxx Xxxxx XX xxx xxxx xxxxxxx xx xx xxxxxx x xxxxxxxx xxxx'x xxxxxxx xxxxxxxxx xxxxxxxxxxx, xxxx xxxxxxx xxx xxxx xxx Xxxxxxx Xxxxx xxxxxxxxxx XXX xx xxxxxxxx XXX. Xxx xxx xxxxxxxxxxxx xxxx xxxxx xx xxxx xxxxxxxx:

-   [Xxxxx xxx xxxxxxxx](query-for-products.md)
-   [Xxxxxx xxxxxxxxxx xxxxxxxx xx xxxxxxxxx](report-consumable-products-as-fulfilled.md)
-   [Xxxxx xxxx xxxxxxxx](grant-free-products.md)

Xxx xxxx xxxxxxxx, xxxx xxx xxxxxxxxx xxxxxxxxxxx xx xxx XXX:

-   Xxx Xxxxx XX xxxxxx xxxxx xxxx xxx xxxxxxx xxxxxxx xxxx xxx **xxxxx://xxxxxxxx.xxxxxxxxx.xxx** xxxxxxxx XXX. Xxxx xxxxx xxxxxxxxxx xxxx xxxxxxxxx xxxxxxxx. Xxxx xxxx xxxxx xx xxx xxxxxxx xxxxxx.
-   Xxx Xxxxxxx Xxxxx XX xxx xxx xxxxxxxxx xxxx [**XxxXxxxxxxxXxxxxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/mt608674) xx [**XxxXxxxxxxxXxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/mt608675) xx xxxx xxx. Xxxx xxx xxxxxxxxxx xxx xxxxxxxx xx xxx xxxx xxxxx xxxxxxx xxxxxxxxx xxxxxxxxxxx xxx xxxx xx xxxxxx.

## Xxxxxx xx x Xxxxxxx Xxxxx XX xxx


X Xxxxxxx Xxxxx XX xxx xx x XXXX Xxx Xxxxx (XXX) xxxx xxxxxxxxxx xxx xxxxxxxx xx xxx xxxx xxxxx xxxxxxx xxxxxxxxx xxxxxxxxxxx xxx xxxx xx xxxxxx. Xxxx xxxxxxx xxxxx XxxxYY, x Xxxxxxx Xxxxx XX xxx xxxxxxxx xxx xxxxxxxxx xxxxxx.

| Xxxxx xxxx                                                             | Xxxxxxxxxxx                                                                                                                                                                                                                                                                                                                                                                             |
|------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| xxx                                                                    | Xxxxxxxxxx xxx xxxx xx xxxxx xxx xxx xxx xxxxxx. Xxxx xxxxx xxx xx xxxx xx xxxxxxxxx xxx xxx xx xxx xxxxx. Xxxx xxxxx xx xxxxxxxxx xx xxxxx xxxx.                                                                                                                                                                                                                                       |
| xxx                                                                    | Xxxxxxxxxx xxx xxxxxx. Xxxx xxx xxx xxxx xxxxx xx xxx *xxx* xxxxx.                                                                                                                                                                                                                                                                                                                      |
| xxx                                                                    | Xxxxxxxxxx xxx xxxxxxxx. Xxxx xx xxx xx xxx xxxxxxxxx xxxxxx: **xxxxx://xxxxxxxxxxx.xx.xxxxxxxxx.xxx/xY.Y/xxxx** xx **xxxxx://xxxxxxxx.xx.xxxxxxxxx.xxx/xY.Y/xxxx**.                                                                                                                                                                                                                    |
| xxx                                                                    | Xxxxxxxxxx xxx xxxxxxxxxx xxxx xx xx xxxxx xxxxx xxx xxx xxxx xx xxxxxx xx xxxxxxxx xxx xxxxxxxxxx xxxxxxxx xxxxxx xxx xxxxxxxx xxxx. Xxx xxxxx xx xxxx xxxxx xx xxxxxxxxx xx xxxxx xxxx.                                                                                                                                                                                               |
| xxx                                                                    | Xxxxxxxxxx xxx xxxx xx xxxxx xxx xxxxx xxxx xx xxxxxxxx xxx xxxxxxxxxx. Xxx xxxxx xx xxxx xxxxx xx xxxxxxxxx xx xxxxx xxxx.                                                                                                                                                                                                                                                             |
| xxxx://xxxxxxx.xxxxxxxxx.xxx/xxxxxxxxxxx/YYYY/YY/xxxxxx/xxx/xxxxxxXx   | Xxx xxxxxx XX xxxx xxxxxxxxxx xxx xxxxxxxxx.                                                                                                                                                                                                                                                                                                                                            |
| xxxx://xxxxxxx.xxxxxxxxx.xxx/xxxxxxxxxxx/YYYY/YY/xxxxxx/xxx/xxxxxxx    | Xx xxxxxx xxxxxxx (xxxxxxxxx xxx XxxxYY xxxxxxx) xxxx xxxxxxxx xxxxxxxxxxx xxxx xx xxxxxxxx xxxx xxx xxx xx Xxxxxxx Xxxxx xxxxxxxx.                                                                                                                                                                                                                                                     |
| xxxx://xxxxxxx.xxxxxxxxx.xxx/xxxxxxxxxxx/YYYY/YY/xxxxxx/xxx/xxxxXx     | X xxxx XX xxxx xxxxxxxxxx xxx xxxxxxx xxxx xx xxx xxxxxxx xx xxxx xxxxxxxx. Xxxx xx xxx xxxx xxxxx xxx xxxx xxxx xxx xxxxxxxx *xxxxxxxxxXxxxXx* xxxxxxxxx xx xxx [**XxxXxxxxxxxXxxxxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/mt608674) xx [**XxxXxxxxxxxXxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/mt608675) xxxxxx xxxx xxx xxxxxx xxx xxx. |
| xxxx://xxxxxxx.xxxxxxxxx.xxx/xxxxxxxxxxx/YYYY/YY/xxxxxx/xxx/xxxxxxxXxx | Xxx XXX xxxx xxx xxx xxx xx xxxxx xxx xxx.                                                                                                                                                                                                                                                                                                                                              |

 

Xxxx xx xx xxxxxxx xx x xxxxxxx Xxxxxxx Xxxxx XX xxx xxxxxx.

```
{ 
    "typ":"JWT", 
    "alg":"RS256", 
    "x5t":"agA_pgJ7Twx_Ex2_rEeQ2o5fZ5g" 
} 
```

Xxxx xx xx xxxxxxx xx x xxxxxxx Xxxxxxx Xxxxx XX xxx xxxxx xxx.

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

## Xxxxxxx xxxxxx

* [Xxxxx xxx xxxxxxxx](query-for-products.md)
* [Xxxxxx xxxxxxxxxx xxxxxxxx xx xxxxxxxxx](report-consumable-products-as-fulfilled.md)
* [Xxxxx xxxx xxxxxxxx](grant-free-products.md)
* [Xxxxx x Xxxxxxx Xxxxx XX xxx](renew-a-windows-store-id-key.md)
* [Xxxxxxxxxxx Xxxxxxxxxxxx xxxx Xxxxx Xxxxxx Xxxxxxxxx](http://go.microsoft.com/fwlink/?LinkId=722502)
* [Xxxxxxxxxxxxx xxx Xxxxx Xxxxxx Xxxxxxxxx xxxxxxxxxxx xxxxxxxx]( http://go.microsoft.com/fwlink/?LinkId=722500)
* [Xxxxxxxxx Xxxxx xxx Xxxxx Xxxxx](http://go.microsoft.com/fwlink/?LinkId=722501)
 

 



<!--HONumber=Mar16_HO1-->
