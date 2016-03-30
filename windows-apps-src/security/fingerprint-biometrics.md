---
xxxxx: Xxxxxxxxxxx xxxxxxxxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxx xxx xx xxx xxxxxxxxxxx xxxxxxxxxx xx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
xx.xxxxxxx: YYYYYYYY-YXYX-YYYX-YYYY-YXXYYYXXXXXY
---

# Xxxxxxxxxxx xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxxxxxx xxxxxxxx xxx xx xxx xxxxxxxxxxx xxxxxxxxxx xx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx. Xxxxxxxxx x xxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxxxxx xxxx xxx xxxx xxxx xxxxxxx xx x xxxxxxxxxx xxxxxx xxxxxxxxx xxx xxxxxxxx xx xxxx xxx. Xxx xxxxxxx, xxx xxxxx xxxxxxx xxxxxxxxxxx xxxxxxxxxxxxxx xxxxxx xxxxxxxxxxx xx xx-xxx xxxxxxxx, xx xxxxxx xx xxxxxxxxxx xxxxxxxxx. Xxxxxxxxxxx xxxxxxxxxxxxxx xx xxxxxxx xxxxx xxx [**XxxxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279134) xxxxx xx xxx [**Xxxxxxx.Xxxxxxxx.Xxxxxxxxxxx.XX**](https://msdn.microsoft.com/library/windows/apps/hh701356) xxxxxxxxx.

## Xxxxx xxx xxxxxx xxx x xxxxxxxxxxx xxxxxx


Xx xxxx xxx xxxxxxx xxx xxxxxx xxx x xxxxxxxxxxx xxxxxx, xxxx [**XxxxXxxxxxxXxxxxxxx.XxxxxXxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279138). Xxxx xx x xxxxxx xxxxxxxx xxxxxxxxxxx xxxxxxxxxxxxxx, xxxx xxx xxxxxx xxxxx xxxxxxx xxxxx xxxx xx xxxxxx xx Xxxxxxxx xx xxxxxx xx xxxxxxx xx.

```cs
public async System.Threading.Tasks.Task<string> CheckFingerprintAvailability()
{
    string returnMessage = "";

    try
    {
        // Check the availability of fingerprint authentication.
        var ucvAvailability = await Windows.Security.Credentials.UI.UserConsentVerifier.CheckAvailabilityAsync();

        switch (ucvAvailability)
        {
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.Available:
                returnMessage = "Fingerprint verification is available.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.DeviceBusy:
                returnMessage = "Biometric device is busy.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.DeviceNotPresent:
                returnMessage = "No biometric device found.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.DisabledByPolicy:
                returnMessage = "Biometric verification is disabled by policy.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerifierAvailability.NotConfiguredForUser:
                returnMessage = "The user has no fingerprints registered. Please add a fingerprint to the " +
                                "fingerprint database and try again.";
                break;
            default:
                returnMessage = "Fingerprints verification is currently unavailable.";
                break;
        }
    }
    catch (Exception ex)
    {
        returnMessage = "Fingerprint authentication availability check failed: " + ex.ToString();
    }

    return returnMessage;
}
```

## Xxxxxxx xxxxxxx xxx xxxxxx xxxxxxx


Xx xxxxxxx xxxx xxxxxxx xxxx x xxxxxxxxxxx xxxx, xxxx xxx [**XxxxXxxxxxxXxxxxxxx.XxxxxxxXxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279139) xxxxxx. Xxx xxxxxxxxxxx xxxxxxxxxxxxxx xx xxxx, xxx xxxx xxxx xxxx xxxxxxxxxx xxxxx x xxxxxxxxxxx "xxxxxxxxx" xx xxx xxxxxxxxxxx xxxxxxxx.

Xxxx xxx xxxx xxx [**XxxxXxxxxxxXxxxxxxx.XxxxxxxXxxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279139), xxx xxxx xx xxxxxxxxx xxxx x xxxxx xxxxxx xxxxxxxxxx x xxxxxxxxxxx xxxx. Xxx xxx xxxxxx x xxxxxxx xx xxx **XxxxXxxxxxxXxxxxxxx.XxxxxxxXxxxxxxxxxxxXxxxx** xxxxxx xxxx xxxx xx xxxxxxxxx xx xxx xxxx xx xxxx xx xxx xxxxx xxxxxx, xx xxxxx xx xxx xxxxxxxxx xxxxx.

```cs
private async System.Threading.Tasks.Task<string> RequestConsent(string userMessage)
{
    string returnMessage;

    if (String.IsNullOrEmpty(userMessage))
    {
        userMessage = "Please provide fingerprint verification.";
    }

    try
    {
        // Request the logged on user&#39;s consent via fingerprint swipe.
        var consentResult = await Windows.Security.Credentials.UI.UserConsentVerifier.RequestVerificationAsync(userMessage);

        switch (consentResult)
        {
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.Verified:
                returnMessage = "Fingerprint verified.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.DeviceBusy:
                returnMessage = "Biometric device is busy.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.DeviceNotPresent:
                returnMessage = "No biometric device found.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.DisabledByPolicy:
                returnMessage = "Biometric verification is disabled by policy.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.NotConfiguredForUser:
                returnMessage = "The user has no fingerprints registered. Please add a fingerprint to the " +
                                "fingerprint database and try again.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.RetriesExhausted:
                returnMessage = "There have been too many failed attempts. Fingerprint authentication canceled.";
                break;
            case Windows.Security.Credentials.UI.UserConsentVerificationResult.Canceled:
                returnMessage = "Fingerprint authentication canceled.";
                break;
            default:
                returnMessage = "Fingerprint authentication is currently unavailable.";
                break;
        }
    }
    catch (Exception ex)
    {
        returnMessage = "Fingerprint authentication failed: " + ex.ToString();
    }

    return returnMessage;
}
```

 

 




<!--HONumber=Mar16_HO1-->
