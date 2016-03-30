---
xx.xxxxxxx: XXYYYXYY-YYYY-YYYY-YXYY-YYYXYXYYXXYY
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxxx xxx xx xxx xxxxxxxx xxxxxxxxx xx xxxxxxxxxx xxxxxxx xxxx Xxxxxxxxx XxxxXxxxx xxxxxxx xxxxxxxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
xxxxx: Xxxxxxxx Xxxxxxxxx xxxx XxxxXxxxx
---

# Xxxxxxxx Xxxxxxxxx xxxx XxxxXxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

\[Xxxx xxxxxxxxxxx xxxxxxx xx xxx-xxxxxxxx xxxxxxx xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxx xxxxxx xx'x xxxxxxxxxxxx xxxxxxxx. Xxxxxxxxx xxxxx xx xxxxxxxxxx, xxxxxxx xx xxxxxxx, xxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xxxx.\]

Xxxx xxxxxxx xxxxxxxxx xxx xx xxx xxxxxxxx xxxxxxxxx xx xxxxxxxxxx xxxxxxx xxxx Xxxxxxxxx XxxxXxxxx xxxxxxx xxxxxxxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx. Xxxx xxxxxxx xxxxxxxxx xxxxxxxx xxxxxxxx xx Xxxx Xxxx Xxxxxxxxx (XXX) xxx Xxxxxxx Xxxxxxxxx xxxx XXXX (XXXX) xxxxxxx.

Xxxx xxxxxxx xxxx xxxxx xxxx xxx xxxxxxx xx xxxxxxxx xxxxxxxxx xxxxxxxx xx XxxxXxxxx. Xxx xxxxxxxxxxx xxxxx xxxxxxxxxxxx xxxxxxxx xxxxxxxxx xx xxxxxxx, xxx [Xxxxxxxx Xxxxxxxxx](adaptive-streaming.md).

Xxx xxxx xxxx xxx xxxxxxxxx xxxxx xxxxxxxxxx:

```csharp
using LicenseRequest;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Media.Protection;
using Windows.Media.Protection.PlayReady;
using Windows.Media.Streaming.Adaptive;
using Windows.UI.Xaml.Controls;
```

Xxx **XxxxxxxXxxxxxx** xxxxxxxxx xx xxxx **XxxxxxXxxxxxxXxxxxxx.xx**, x XxxxXxxxx xxxx xxxxxxxx xx Xxxxxxxxx xx xxxxxxxxx.

Xxx xxxx xxxx xx xxxxxxx x xxx xxxxxx xxxxxxxxx:

```csharp
private AdaptiveMediaSource ams = null;
private MediaProtectionManager protectionManager = null;
private string playReadyLicenseUrl = "";
private string playReadyChallengeCustomData = "";
```

Xxx xxxx xxxx xxxx xx xxxxxxx xxx xxxxxxxxx xxxxxxxx:

```csharp
private const int MSPR_E_CONTENT_ENABLING_ACTION_REQUIRED = -2147174251;
```

## Xxxxxxx xx xxx XxxxxXxxxxxxxxxXxxxxxx

Xx xxx XxxxXxxxx xxxxxxx xxxxxxxxxx xx xxxx XXX xxx, xxx xxxx xxxx xx xxx xx x [XxxxxXxxxxxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br207040) xxxxxx. Xxx xx xxxx xxxx xxxxxxxxxxxx xxxx [**XxxxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn946912) xxxxxx.

Xxx xxxxxxxxx xxxx xxxx xx x [XxxxxXxxxxxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br207040):

```csharp
private void SetUpProtectionManager(ref MediaElement mediaElement)
{
    protectionManager = new MediaProtectionManager();

    protectionManager.ComponentLoadFailed += 
        new ComponentLoadFailedEventHandler(ProtectionManager_ComponentLoadFailed);

    protectionManager.ServiceRequested += 
        new ServiceRequestedEventHandler(ProtectionManager_ServiceRequested);

    PropertySet cpSystems = new PropertySet();

    cpSystems.Add(
        "{F4637010-03C3-42CD-B932-B48ADF3A6A54}", 
        "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput");

    protectionManager.Properties.Add("Windows.Media.Protection.MediaProtectionSystemIdMapping", cpSystems);

    protectionManager.Properties.Add(
        "Windows.Media.Protection.MediaProtectionSystemId", 
        "{F4637010-03C3-42CD-B932-B48ADF3A6A54}");

    protectionManager.Properties.Add(
        "Windows.Media.Protection.MediaProtectionContainerGuid", 
        "{9A04F079-9840-4286-AB92-E65BE0885F95}");

    mediaElement.ProtectionManager = protectionManager;
}
```

Xxxx xxxx xxx xxxxxx xx xxxxxx xx xxxx xxx, xxxxx xx xx xxxxxxxxx xxx xxxxxxx xx xxxxxxx xxxxxxxxxx.

Xxx [XxxxxxxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/br207041) xxxxx xx xxxxx xxxx xxx xxxx xx xxxxxx xxxx xxxxx. Xx xxxx xx xxx xx xxxxx xxxxxxx xx xxxxxx xxxx, xxxxxxxxx xxxx xxx xxxx xxx xxx xxxxxxxx:

```csharp
private void ProtectionManager_ComponentLoadFailed(
    MediaProtectionManager sender, 
    ComponentLoadFailedEventArgs e)
{
    e.Completion.Complete(false);
}
```

Xxxxxxxxx, xx xxxx xx xxx xx xxxxx xxxxxxx xxx xxx [XxxxxxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/br207045) xxxxx, xxxxx xxxxx xxxx x xxxxxxx xx xxxxxxxxx. Xxxx xxxx xxxxxx xxxx xxxx xx xxxxxxx xx xx, xxx xxxxxxxx xxxxxxxxxxxxx:

```csharp
private async void ProtectionManager_ServiceRequested(
    MediaProtectionManager sender, 
    ServiceRequestedEventArgs e)
{
    if (e.Request is PlayReadyIndividualizationServiceRequest)
    {
        PlayReadyIndividualizationServiceRequest IndivRequest = 
            e.Request as PlayReadyIndividualizationServiceRequest;

        bool bResultIndiv = await ReactiveIndivRequest(IndivRequest, e.Completion);
    }
    else if (e.Request is PlayReadyLicenseAcquisitionServiceRequest)
    {
        PlayReadyLicenseAcquisitionServiceRequest licenseRequest = 
            e.Request as PlayReadyLicenseAcquisitionServiceRequest;

        LicenseAcquisitionRequest(
            licenseRequest, 
            e.Completion, 
            playReadyLicenseUrl, 
            playReadyChallengeCustomData);
    }
}
```

## Xxxxxxxxxxxxxxxxx xxxxxxx xxxxxxxx

Xxx xxxxxxxxx xxxx xxxxxxxxxx xxxxx x XxxxXxxxx xxxxxxxxxxxxxxxxx xxxxxxx xxxxxxx. Xx xxxx xx xxx xxxxxxx xx x xxxxxxxxx xx xxx xxxxxxxx. Xx xxxxxxxx xxx xxxx xx x xxx/xxxxx xxxxx, xxx xx xxxxx xxx xx xxxxxxxxxx, xx xxx xxx xxxxxxx xxxxxxxxx xxxxxxxxxxxx:

```csharp
async Task<bool> ReactiveIndivRequest(
    PlayReadyIndividualizationServiceRequest IndivRequest, 
    MediaProtectionServiceCompletion CompletionNotifier)
{
    bool bResult = false;
    Exception exception = null;

    try
    {
        await IndivRequest.BeginServiceRequest();
    }
    catch (Exception ex)
    {
        exception = ex;
    }
    finally
    {
        if (exception == null)
        {
            bResult = true;
        }
        else
        {
            COMException comException = exception as COMException;
            if (comException != null &amp;&amp; comException.HResult == MSPR_E_CONTENT_ENABLING_ACTION_REQUIRED)
            {
                IndivRequest.NextServiceRequest();
            }
        }
    }

    if (CompletionNotifier != null) CompletionNotifier.Complete(bResult);
    return bResult;
}
```

Xxxxxxxxxxxxx, xx xxx xxxx xx xxxxxxxxxxx xxxx xx xxxxxxxxxxxxxxxxx xxxxxxx xxxxxxx, xx xxxxx xxxx xx xxxx xxx xxxxxxxx xxxxx xx xxxxx xx xxx xxxx xxxxxxx `ReactiveIndivRequest` xx `ProtectionManager_ServiceRequested`:

```csharp
async void ProActiveIndivRequest()
{
    PlayReadyIndividualizationServiceRequest indivRequest = new PlayReadyIndividualizationServiceRequest();
    bool bResultIndiv = await ReactiveIndivRequest(indivRequest, null);
}
```

## Xxxxxxx xxxxxxxxxxx xxxxxxx xxxxxxxx

Xx xxxxxxx xxx xxxxxxx xxx x [XxxxXxxxxXxxxxxxXxxxxxxxxxxXxxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn986285), xx xxxx xxx xxxxx xxxxxxxx xx xxxxxxx xxx xxxxxxx xxx XxxxXxxxx xxxxxxx. Xx xxxx xxx XxxxxXxxxxxxxxxXxxxxxxXxxxxxxxxx xxxxxx xxxx xx xxxxxx xx xxxxxxx xxx xxxxxxx xxx xxxxxxxxxx xx xxx, xxx xx xxxxxxxx xxx xxxxxxx:

```csharp
async void LicenseAcquisitionRequest(
    PlayReadyLicenseAcquisitionServiceRequest licenseRequest, 
    MediaProtectionServiceCompletion CompletionNotifier, 
    string Url, 
    string ChallengeCustomData)
{
    bool bResult = false;
    string ExceptionMessage = string.Empty;

    try
    {
        if (!string.IsNullOrEmpty(Url))
        {
            if (!string.IsNullOrEmpty(ChallengeCustomData))
            {
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                byte[] b = encoding.GetBytes(ChallengeCustomData);
                licenseRequest.ChallengeCustomData = Convert.ToBase64String(b, 0, b.Length);
            }

            PlayReadySoapMessage soapMessage = licenseRequest.GenerateManualEnablingChallenge();

            byte[] messageBytes = soapMessage.GetMessageBody();
            HttpContent httpContent = new ByteArrayContent(messageBytes);

            IPropertySet propertySetHeaders = soapMessage.MessageHeaders;

            foreach (string strHeaderName in propertySetHeaders.Keys)
            {
                string strHeaderValue = propertySetHeaders[strHeaderName].ToString();

                if (strHeaderName.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                {
                    httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse(strHeaderValue);
                }
                else
                {
                    httpContent.Headers.Add(strHeaderName.ToString(), strHeaderValue);
                }
            }

            CommonLicenseRequest licenseAcquision = new CommonLicenseRequest();

            HttpContent responseHttpContent = 
                await licenseAcquision.AcquireLicense(new Uri(Url), httpContent);

            if (responseHttpContent != null)
            {
                Exception exResult = licenseRequest.ProcessManualEnablingResponse(
                                         await responseHttpContent.ReadAsByteArrayAsync());

                if (exResult != null)
                {
                    throw exResult;
                }
                bResult = true;
            }
            else
            {
                ExceptionMessage = licenseAcquision.GetLastErrorMessage();
            }
        }
        else
        {
            await licenseRequest.BeginServiceRequest();
            bResult = true;
        }
    }
    catch (Exception e)
    {
        ExceptionMessage = e.Message;
    }

    CompletionNotifier.Complete(bResult);
}
```

## Xxxxxxxxxxxx xxx XxxxxxxxXxxxxXxxxxx

Xxxxxxx, xxx xxxx xxxx x xxxxxxxx xx xxxxxxxxxx xxx [XxxxxxxxXxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/dn946912), xxxxxxx xxxx x xxxxx [Xxx](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) xxx [XxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/br242926). Xxx **Xxx** xxxxxx xx xxx xxxx xx xxx xxxxx xxxx (XXX xx XXXX); xxx **XxxxxXxxxxxx** xxxxxx xx xxxxxxx xx xxxx XXXX.

```csharp
async private void InitializeAdaptiveMediaSource(System.Uri uri, MediaElement m)
{
    AdaptiveMediaSourceCreationResult result = await AdaptiveMediaSource.CreateFromUriAsync(uri);
    if (result.Status == AdaptiveMediaSourceCreationStatus.Success)
    {
        ams = result.MediaSource;
        SetUpProtectionManager(ref m);
        m.SetMediaStreamSource(ams);
    }
    else
    {
        // Error handling
    }
}
```

Xxx xxx xxxx xxxx xxxxxxxx xx xxxxxxxxx xxxxx xxxxxxx xxx xxxxx xx xxxxxxxx xxxxxxxxx—xxx xxxxxxxx, xx x xxxxxx xxxxx xxxxx.

 

 




<!--HONumber=Mar16_HO1-->
