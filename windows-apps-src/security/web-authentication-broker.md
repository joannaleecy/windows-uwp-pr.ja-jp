---
xxxxx: Xxx xxxxxxxxxxxxxx xxxxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxx xxx xx xxxxxxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xx xx xxxxxx xxxxxxxx xxxxxxxx xxxx xxxx xxxxxxxxxxxxxx xxxxxxxxx xxxx XxxxXX xx XXxxx, xxxx xx Xxxxxxxx, Xxxxxxx, Xxxxxx, Xxxxxxxxx, xxx xx xx.
xx.xxxxxxx: YYXYYYYY-YYYY-YYXY-XYYY-XXXXYYYYYXYY
---

# Xxx xxxxxxxxxxxxxx xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxxxxxx xxxxxxxx xxx xx xxxxxxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xx xx xxxxxx xxxxxxxx xxxxxxxx xxxx xxxx xxxxxxxxxxxxxx xxxxxxxxx xxxx XxxxXX xx XXxxx, xxxx xx Xxxxxxxx, Xxxxxxx, Xxxxxx, Xxxxxxxxx, xxx xx xx. Xxx [**XxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br212066) xxxxxx xxxxx x xxxxxxx xx xxx xxxxxx xxxxxxxx xxxxxxxx xxx xxxx xxxx xx xxxxxx xxxxx xxxx xxxxxxxxx xxx xxxxxxxx xxxxxxxxx xx xxxxx xxx xxx xxx xxxxxx.

**Xxxx**  Xxx x xxxxxxxx, xxxxxxx xxxx xxxxxx, xxxxx xxx [XxxXxxxxxxxxxxxxxXxxxxx xxxx xx XxxXxx](http://go.microsoft.com/fwlink/p/?LinkId=620622).

 

## Xxxxxxxx xxxx xxx xxxx xxxx xxxxxx xxxxxxxx


Xxx xxxx xxxxxxxx xxxx xxx xxxx xxx xxxxxx xxxxxxxx xxxxxxxx xx xxxxx xxx xxxx xx xxxxxxx. Xxx xxx xxxx xxx xxx xx xxxxxxxx xxxx xxx xxxx xxx xxxxxxxx xxxxxxxx. Xxxxx xxxxxxxxxxx, xxx xxxxxx xxxxxxxx xxxxxxxxx xxxxx xxx xx Xx xx xxxxxx xxx xxx xxxx xxx.

## Xxxxx xxx xxxxxxxxxxxxxx xxxxxxx XXX


Xxx xxxxxxx XXX xxxxxxxx xx xxx xxxxxxx xxxxx xxx xxxx xxx xxxxxxxxxxxxxx xxxxxxx xx xxxx xxxxxx xxxxxxxx xxxxxxxx xxxx xxxxx xxxxxxxx xxxxxxxxxxx, xxxx xx xx xxx XX xx xxxxxx, x xxxxxxxx XXX xxxxx xxx xxxx xx xxxx xxxxx xxxxxxxxxx xxxxxxxxxxxxxx, xxx xxx xxxxxxxx xxxxxxxx xxxx. Xxx xxx xxxx xxx xxxx xxxx xxxxxxxx xxxx xxxxxxxxxx xxx xxxxxxxx.

Xxx xxxxxxx XXX xx xxxx xx xxx *xxxxxxxXxx* xxxxxxxxx xx xxx [**XxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br212066) xxxxxx. Xx xxxx xx x xxxxxx xxxxxxx (xx xxxx xxxxx xxxx xxxxx://)

Xxx xxxxxxxxx xxxxxxx xxxxx xxx xx xxxxx xxx xxxxxxx XXX.

```cs
string startURL = "https://<providerendpoint>?client_id=<clientid>&amp;scope=<scopes>&amp;response_type=token";
string endURL = "http://<appendpoint>";

System.Uri startURI = new System.Uri(startURL);
System.Uri endURI = new System.Uri(endURL);
```

## Xxxxxxx xx xxx xxxxxx xxxxxxxx


Xxx xxxx xxx [**XxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br212066) xxxxxx xx xxxxxxx xx xxx xxxxxx xxxxxxxx xxxxxxxx xxx xxx xx xxxxxx xxxxx. Xxx xxxxxx xxxxx xxx XXX xxxxxxxxxxx xx xxx xxxxxxxx xxxx xx xxx *xxxxxxxXxx* xxxxxxxxx, xxx x XXX xx xxxxx xxx xxxx xxx xxxx xx xx xxxxxxxxxx xx xxx *xxxxxxxxXxx* xxxxxxxxx.

```cs
string result;

try
{
    var webAuthenticationResult = 
        await Windows.Security.Authentication.Web.WebAuthenticationBroker.AuthenticateAsync( 
        Windows.Security.Authentication.Web.WebAuthenticationOptions.None, 
        startURI, 
        endURI);

    switch (webAuthenticationResult.ResponseStatus)
    {
        case Windows.Security.Authentication.Web.WebAuthenticationStatus.Success:
            // Successful authentication. 
            result = webAuthenticationResult.ResponseData.ToString(); 
            break;
        case Windows.Security.Authentication.Web.WebAuthenticationStatus.ErrorHttp:
            // HTTP error. 
            result = webAuthenticationResult.ResponseErrorDetail.ToString(); 
            break;
        default:
            // Other error.
            result = webAuthenticationResult.ResponseData.ToString(); 
            break;
    } 
}
catch (Exception ex)
{
    // Authentication failed. Handle parameter, SSL/TLS, and Network Unavailable errors here. 
    result = ex.Message;
}
```

Xx xxxxxxxx xx [**XxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br212066), xxx [**Xxxxxxx.Xxxxxxxx.Xxxxxxxxxxxxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/br227044) xxxxxxxxx xxxxxxxx xx [**XxxxxxxxxxxxXxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn632425) xxxxxx. Xx xxx xxxx xxxx xxxxxx. Xx xx xxxxxxxx xxx xxxx xxxxxxxxx Xxxxxxx Xxxxx Y.Y xxxx xxx xx xxxxxxxxxx xxxxxxxx xxxx Xxxxxxx YY.

## Xxxxxxxxxx xxxx xxxxxx xxxx-xx (XXX).


Xx xxxxxxx, Xxx xxxxxxxxxxxxxx xxxxxx xxxx xxx xxxxx xxxxxxx xx xxxxxxx. Xxxxxxx xx xxxx, xxxx xx xxx xxx xxxx xxxxxxxxx xxxx xxxx xxxx xx xxxx xxxxxx xx (xxx xxxxxxx, xx xxxxxxxxx x xxxxx xxx xx xxx xxxxxxxx'x xxxxx xxxxxx), xxxx xxxx xxxx xx xxxxx xxxx xxxx xxxx xxxx xx xxxxxx xxxxxxxxx xxx xxxx xxxxxxxx. Xx xxxxx xxxx XXX, xxxx xxxxxx xxxxxxxx xxxxxxxx xxxx xxxx xxxxxxx XXX xxx Xxx xxxxxxxxxxxxxx xxxxxx, xxx xxxx xxx xxxx xxxx xxx xxxxxxxx xx [**XxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br212068) xxxx xxxx xxx xxxx x *xxxxxxxxXxx* xxxxxxxxx.

Xx xxxxxxx XXX, xxx xxxxxx xxxxxxxx xxxx xxxxx xxx xx xxxxxxxx x xxxxxxxx XXX xx xxx xxxx `ms-app://`*xxxXXX*, xxxxx *xxxXXX* xx xxx XXX xxx xxxx xxx. Xxx xxx xxxx xxxx xxx'x XXX xxxx xxx xxx xxxxxxxxx xxxx xxx xxxx xxx, xx xx xxxxxxx xxx [**XxxXxxxxxxXxxxxxxxxxxXxxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br212069) xxxxxx.

```cs
string result;

try
{
    var webAuthenticationResult = 
        await Windows.Security.Authentication.Web.WebAuthenticationBroker.AuthenticateAsync( 
        Windows.Security.Authentication.Web.WebAuthenticationOptions.None, 
        startURI);

    switch (webAuthenticationResult.ResponseStatus)
    {
        case Windows.Security.Authentication.Web.WebAuthenticationStatus.Success:
            // Successful authentication. 
            result = webAuthenticationResult.ResponseData.ToString(); 
            break;
        case Windows.Security.Authentication.Web.WebAuthenticationStatus.ErrorHttp:
            // HTTP error. 
            result = webAuthenticationResult.ResponseErrorDetail.ToString(); 
            break;
        default:
            // Other error.
            result = webAuthenticationResult.ResponseData.ToString(); 
            break;
    } 
}
catch (Exception ex)
{
    // Authentication failed. Handle parameter, SSL/TLS, and Network Unavailable errors here. 
    result = ex.Message;
}
```

## Xxxxxxxxx


Xxxxx xxx xxxxxxx xxxx xx xxxxxxxxxxxx xxx xxx xxxxxxxxxxxxxx xxxxxx XXXx, xxxxxxxxx xxxxxxxxx xxxxxxxxxxx xxxx xxx xxxxxxxxx xxx xxxxxxxx xxx xxxxxxxxx xxxxx Xxxxxxx.

### Xxxxxxxxxxx xxxx

Xxxxx xxx xxx xxxxxxxxx xxxx xx xxx xxxxxxx xx xxxxx xxx xxxxxxxxxxx xxxx. Xxxxx xx x xxxxxxxxx xxxxx xxx xxxxxxx Xxxxxxxxx-Xxxxxxx-XxxXxxx\\Xxxxxxxxxxx xxxx xxxxxx xxxxxxx xxxxxxxxxx xx xxxxxxxxxx xxx xxxxx xxx xxxxx xxx xxxxx xxxxxxxxx xx xxx Xxx xxxxxxxxxxxxxx xxxxxx. Xx xxxxxx xx, xxxxxx xxxxxxxx.xxx xxx xxxxxx Xxxxxxxxxxx xxx xxxxx xxx Xxxxxxxxxxx xxx Xxxxxxxx\\Xxxxxxxxx\\Xxxxxxx\\XxxXxxx. Xxxx, xxx Xxx xxxxxxxxxxxxxx xxxxxx xxxxxxx x xxxxxx xxxxxx xx xxx xxxx xxxxx xxxxxx xx xxxxxxxx xxxxxx xx xxx xxx xxxxxx. Xxx xxxxxx xx "XXXxxxXxxx/Y.Y". Xxxx xxxx xxx xxxxxxx xxxxxx xxx xxxxxx xx xxx xxxxxx, xx xxx xxxxxx xxx xx xxxxxx xx xxxx xxxxxxx xxxxxx xx xxxx xxxx. Xx xxxxxxx xx xxx xxxx xxxx xxxxx xxxxxx, xxxxxxxx xx xxxx xxxxxxxxx xxxxx, xx xx xxxxxxx.

`User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Win64; x64; Trident/6.0; MSAuthHost/1.0)`

1.  Xxxxxx xxxxxxxxxxx xxxx.
2.  Xxx Xxxxxxx xxxxxx xxxxxxxxxxx. ![xxxxx xxxxxx xxxxxxxxxx xxx xxxxxxx xxxxxxxxxxx xxxx](images/wab-event-viewer-1.png)
3.  Xxx xxxxxxxxx xxxx xxxxxxx xxx xx xxxx xx xxxxxxxxxx xxx xxxxxxxx xx Xxx xxxxxxxxxxxxxx xxxxxx xx xxxxxxx xxxxxx. Xx xxxx xxxx, xxxxx xxx xxxxxxx:
    -   Xxxxxxxxxx Xxxxx: Xxxx xxxx xxx XxxxXxxx xx xxxxxxx xxx xxxxxxxx xxxxxxxxxxx xxxxx xxx xxxxx xxx xxxxxxxxxxx XXXx.
    -   ![xxxxxxxxxxx xxx xxxxxxx xx xxxxxxxxxx xxxxx](images/wab-event-viewer-2.png)
    -   Xxxxxxxxxx Xxxxxxxx: Xxxx xxx xxxxxxxxxx xx xxxxxxx x xxx xxxx.
    -   Xxxx Xxx: Xxxx xxxx x xxxx-xxx xx xxxxxxxxxxx xxxxxxxxx xxx xxxxxxx.
    -   Xxxxxxxxxx Xxxxxxxxx: Xxxxxxxxxx xxxxxxxxxx xx xxx xxxx.
    -   Xxxxxxxxxx Xxxxx: XxxxXxxx xxxxxxxxxx x xxxxxxxxxx xxxxx xx x XXX xxxxxxxxx XxxxXxxxxxXxxx.
    -   Xxxxxxxxxx Xxx: Xxxxxxxxxxx XXX xx xxxxxxxxxxx.

### Xxxxxxx

Xxx Xxxxxxx xxx xxxxxxxx xxx xx xxxx xxxx xxxx.

1.  Xxxxx xxx XxxxXxxx xxxx xx xxx xxx xxx xxxxxxxxx xx xxxx xx xxx xxxxxxx xxxxxxx xxxxxxxxxx, xxx xxxx xxx x xxxxxxxx xxx: Xxxxxxx Xxxxxxxx Xxxxxx Xxxxxxx Y.YY

    **XXXX\_XXXXX\_XXXXXXX**\\**XXXXXXXX**\\**Xxxxxxxxx**\\**Xxxxxxx XX**\\**XxxxxxxXxxxxxx**\\**Xxxxx Xxxx Xxxxxxxxx Xxxxxxx**\\**xxxxxxxx.xxx**\\**XxxxxxXxxxxxxXxxxxxx** = YYYYYYYY

                         Data type  
                         DWORD

2.  Xxx x xxxx xxx xxx XxxxXxxx xx xxxx xx xxxx xx xxxxxxxxxx xxx xxxxxxxx xxxxxxx.
    ```syntax
    CheckNetIsolation.exe LoopbackExempt -a -n=microsoft.windows.authhost.a.p_8wekyb3d8bbwe
    CheckNetIsolation.exe LoopbackExempt -a -n=microsoft.windows.authhost.sso.p_8wekyb3d8bbwe
    CheckNetIsolation.exe LoopbackExempt -a -n=microsoft.windows.authhost.sso.c_8wekyb3d8bbwe
    D:\Windows\System32>CheckNetIsolation.exe LoopbackExempt -s
    List Loopback Exempted AppContainers
    [1] -----------------------------------------------------------------
        Name: microsoft.windows.authhost.sso.c_8wekyb3d8bbwe
        SID:  S-1-15-2-1973105767-3975693666-32999980-3747492175-1074076486-3102532000-500629349
    [2] -----------------------------------------------------------------
        Name: microsoft.windows.authhost.sso.p_8wekyb3d8bbwe
        SID:  S-1-15-2-166260-4150837609-3669066492-3071230600-3743290616-3683681078-2492089544
    [3] -----------------------------------------------------------------
        Name: microsoft.windows.authhost.a.p_8wekyb3d8bbwe
        SID:  S-1-15-2-3506084497-1208594716-3384433646-2514033508-1838198150-1980605558-3480344935
    ```

3.  Xxx x xxxxxxxx xxxx xxx xxxxxxxx xxxxxxx xx Xxxxxxx.

 

 




<!--HONumber=Mar16_HO1-->
