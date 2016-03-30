---
xxxxx: Xxxxxxxxxx xxxxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx xxx xxx Xxxxxxxxxx Xxxxxx xx xxxxxxxx xxxxx xxx xxxxxxxx xxxx xxxxxxxxxxx, xxx xxxx xxxx xxxxxxx xxxxxxx xxxx xxx xxxx'x Xxxxxxxxx xxxxxxx.
xx.xxxxxxx: YXXXYYYX-YXYX-YYYX-XYYY-YYYYXYXXXYYY
---

# Xxxxxxxxxx xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxxxxxx xxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx xxx xxx Xxxxxxxxxx Xxxxxx xx xxxxxxxx xxxxx xxx xxxxxxxx xxxx xxxxxxxxxxx, xxx xxxx xxxx xxxxxxx xxxxxxx xxxx xxx xxxx'x Xxxxxxxxx xxxxxxx.

Xxx xxxxxxx, xxx xxxx xx xxx xxxx xxxxxxxx xx x xxxxxxx xx xxxxxx xxxxxxxxx xxxxxxxxx xxxx xx xxxxx xxxxx, xx xxxxxx xxxxxxxxxx. Xxxx xxxxxxx xxxxxxxx xxxxx xxxxxxxxxxx xxx xxxx xxxx. Xxx’xx xxxxx XX xxxx xxxx xxx xxxx xxxx xxx xxxxxxxx xxx xxxxxxxx xxx xxx xxxx, xxxxx xx xxxx xxxx xx xxx xxx xxxx xxxx xxx xxxxxxx. Xxxxx xxx Xxxxxxxxxx Xxxxxx XXX, xxx xxx xxxxx xxx xxxxxxxx xxx xxxxxxxx xxx xxxx xxxx xxx xxxxxx xxxxxxxx xxxx xxx xxx xxx xxxx xx xxxxxxxxxxxxx xxx xxxx xxxx xxxx xxxx xxxx xxx, xxxxxxxxxx xx xxxx xxxxxx xxxx'xx xx.

Xxxxxxxxxx xxxxxx xxxxx x xxxxxx xxxxxxxxxxx xxx xxxxxx xxxxxxxx. Xx xxxxx xxx xxxxxxxxxxx xxxxxx xxxx xxxx Xxxxxxxxx xxxxxxx, xxx xxx xxxxxxxxx xxxx xxxxxxx xxxx x xxxxxx xxxxxxx (xxxx xx xxx xxxxxxx xxxx xxx xxx xx xxxx), xxxx xxxxxxxxxxx xxxx xxxx xx xxxx xxxxxx xxxxxxx. Xxxxxxx, xxx xxx xxxxxxxxxxx xxxxx xxxx xxxxxx xx xxxx xxx xxxxxx xxxxxxx xxx’x xxxx. Xxxx xxxxxxx xxxx xxxxxxx xxxxxxxxxxx xxx xxx xxxxxx xxxx’x xxxxxxx xxxxxxx xx xxx xxxxxx.

## Xxxxxxx xxxx xxxxxxxxxxx


1.  Xxxxxx x xxxxxxxxx xx xxx Xxxxxxxxxx Xxxxxx xxxxx xxx [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227081) xxxxxx xxxx xxx [**Xxxxxxx.Xxxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227089) xxxxxxxxx.
2.  Xxxxxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227061) xxxxxx xxxx xxxxxxxx xx xxxxxxxxxx xxx xxxx xxx, xxx xxxxxxxx xxx xxx xxxxxxxx, xxx xxxx xxxx xx xxx [**XxxxxxxxXxxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/hh701231) xxxxxx xx xxx xxx xxxxxxxxxx xx xxx xxxxxx.

```cs
var vault = new Windows.Security.Credentials.PasswordVault();
vault.Add(new Windows.Security.Credentials.PasswordCredential(
    "My App", username, password));
```

## Xxxxxxxxxx xxxx xxxxxxxxxxx


Xxx xxxx xxxxxxx xxxxxxx xxx xxxxxxxxxx xxxx xxxxxxxxxxx xxxx xxx Xxxxxxxxxx Xxxxxx xxxxx xxx xxxx x xxxxxxxxx xx xxx [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227081) xxxxxx.

-   Xxx xxx xxxxxxxx xxx xxx xxxxxxxxxxx xxx xxxx xxx xxxxxxxx xxx xxxx xxx xx xxx xxxxxx xxxx xxx [**XxxxxxxxXxxxx.XxxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br227088) xxxxxx.

-   Xx xxx xxxx xxx xxxxxxxx xxx xxx xxxxxx xxxxxxxxxxx, xxx xxx xxxxxxxx xxx xxx xxxxxxxxxxx xxx xxxx xxxxxxxx xxxx xxx [**XxxxxxxxXxxxx.XxxxXxxXxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227084) xxxxxx.

-   Xx xxx xxxx xxx xxxxxxxx xxxx xxx xxx xxxxxx xxxxxxxxxxx, xxx xxx xxxxxxxx xxx xxx xxxxxxxxxxx xxx xxxx xxxxxxxx xxxx xxxx xxx [**XxxxxxxxXxxxx.XxxxXxxXxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227083) xxxxxx.

-   Xxxxxxx, xx xxx xxxx xxxx xxx xxxxxxxx xxx xxx xxxxxxxx xxxx xxx x xxxxxxxxxx, xxx xxx xxxxxxxx xxxx xxxx xxxxxxxxxx xxxx xxx [**XxxxxxxxXxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227087) xxxxxx.

Xxx’x xxxx xx xx xxxxxxx xxxxx xx xxxx xxxxxx xxx xxxxxxxx xxxx xxxxxxxx xx xx xxx xxx xx xxx xxx xxxx xx xxxxxxxxxxxxx xx xx xxxx x xxxxxxxxxx xxx xxxx. Xx xx xxxx xxxxxxxx xxxxxxxxxxx xxx xxx xxxx xxxx, xx xxx xxx xxxx xx xxxxxx x xxxxxxx xxxxxxxxxx xx xxx xxxx xxxxxxx xx.

```cs
private string resourceName = "My App";
private string defaultUserName;

private void Login()
{
    var loginCredential = GetCredentialFromLocker();

    if (loginCredential != null)
    {
        // There is a credential stored in the locker.
        // Populate the Password property of the credential
        // for automatic login.
        loginCredential.RetrievePassword();
    }
    else
    {
        // There is no credential stored in the locker.
        // Display UI to get user credentials.
        loginCredential = GetLoginCredentialUI();
    }

    // Log the user in.
    ServerLogin(loginCredential.UserName, loginCredential.Password);
}


private Windows.Security.Credentials.PasswordCredential GetCredentialFromLocker()
{
    Windows.Security.Credentials.PasswordCredential credential = null;

    var vault = new Windows.Security.Credentials.PasswordVault();
    var credentialList = vault.FindAllByResource(resourceName);
    if (credentialList.Count > 0)
    {
        if (credentialList.Count == 1)
        {
            credential = credentialList[0];
        }
        else
        {
            // When there are multiple usernames,
            // retrieve the default username. If one doesn’t
            // exist, then display UI to have the user select
            // a default username.

            defaultUserName = GetDefaultUserNameUI();

            credential = vault.Retrieve(resourceName, defaultUserName);
        }
    }

    return credential;
}
```

## Xxxxxxxx xxxx xxxxxxxxxxx


Xxxxxxxx xxxx xxxxxxxxxxx xx xxx Xxxxxxxxxx Xxxxxx xx xxxx x xxxxx, xxx-xxxx xxxxxxx.

1.  Xxxxxx x xxxxxxxxx xx xxx Xxxxxxxxxx Xxxxxx xxxxx xxx [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227081) xxxxxx xxxx xxx [**Xxxxxxx.Xxxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227089) xxxxxxxxx.

2.  Xxxx xxx xxxxxxxxxx xxx xxxx xx xxxxxx xx xxx [**XxxxxxxxXxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701242) xxxxxx.

```cs
var vault = new Windows.Security.Credentials.PasswordVault();
vault.Remove(new Windows.Security.Credentials.PasswordCredential(
    "My App", username, password));
```

## Xxxx xxxxxxxxx


Xxxx xxx xxx xxxxxxxxxx xxxxxx xxx xxxxxxxxx xxx xxx xxx xxxxxx xxxx xxxxx.

Xxxx xxxxxxxxx xx xxx xxxxxxxxxx xxxxxx xxxx xx xxx xxxxxxxxx xxxxxxxx xxx xxx:

-   Xxx xxxx xxx xxxxxxxxxxxx xxxxxx xx.
-   Xxx xxxx xxx xxxxx xx xxxx xxxxxxxxx.

Xxxxx xxxxx xxxxxxxxxxx xx xxxxx-xxxx xxxxx xxx xxxx xx xxxxxxx xxxxxxxx.

 

 




<!--HONumber=Mar16_HO1-->
