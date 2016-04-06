---
Description: 'This topic shows examples of the coding tasks needed to achieve some of the most common stream- and buffer-related enterprise data protection (EDP) scenarios.'
MS-HAID: 'dev\_files.use\_edp\_to\_protect\_streams\_and\_buffers'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: 'Use enterprise data protection (EDP) to protect streams and buffers'
---

# Use enterprise data protection (EDP) to protect streams and buffers

__Note__ Enterprise data protection (EDP) policy cannot be applied on Windows 10, Version 1511 (build 10586) or earlier.

This topic shows examples of the coding tasks needed to achieve some of the most common stream- and buffer-related enterprise data protection (EDP) scenarios. For the full developer picture of how EDP relates to files, streams, the clipboard, networking, background tasks, and data protection under lock, see [enterprise data protection (EDP)](../enterprise/edp-hub.md).

**Note**  The [enterprise data protection (EDP) sample](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409) covers many of the same scenarios demonstrated in this topic.

## Prerequisites


-   **Get set up for EDP**

    See [Set up your computer for EDP](../enterprise/edp-hub.md#set-up-your-computer-for-EDP).

-   **Commit to building an enterprise-enlightened app**

    An app that autonomously ensures that enterprise data stays under the managing enterprise’s control is known as an enterprise-enlightened app. An enlightened app is more powerful, smart, flexible, and trusted than an unenlightened one. Your app announces to the system that it is enlightened by declaring the restricted **enterpriseDataPolicy** capability. There's more to being enlightened than setting a capability, though. To learn more, see [Enterprise-enlightened apps](../enterprise/edp-hub.md#enterprise-enlightened-apps).

-   **Understand async programming for Universal Windows Platform (UWP) apps**

    To learn about how to write asynchronous apps in C\# or Visual Basic, see [Call asynchronous APIs in C\# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337). To learn about how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).

## Protect a stream of data to an enterprise identity


**Note**  Whenever you protect a stream or a buffer, it's highly recommended that you subscribe to the [**ProtectionPolicyManager.PolicyChanged**](https://msdn.microsoft.com/library/windows/apps/mt608411) event so that your app is aware in the event that EDP becomes disabled on the device. When this happens, you should unprotect any streams and buffers. Any stream or buffer that you leave protected becomes eligible to be revoked should the user un-enroll the device from mobile device management (MDM). And, if EDP was disabled when the resource was created, then that revocation is inappropriate. Unprotecting the resources when EDP is disabled prevents that.



In this scenario, your app has access to an unprotected stream that contains enterprise data. In order to ensure that this stream is protected when transferring it within and outside the device, your app protects the data to the enterprise identity that it belongs to. This allows wiping the data, when required, by the enterprise. In order to later determine whether or not to call an "unprotect" method on a stream, the app must maintain state that indicates whether the stream was protected, which is why the function in this code example returns that state. If the identity passed is not managed, or if the app is not allowed for the identity, the stream will not be protected and an ‘Unprotected’ status will be returned from the call to [**DataProtectionManager.ProtectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/dn706021).

```CSharp
using Windows.Storage.Streams;
using Windows.Security.EnterpriseData;

private async System.Threading.Tasks.Task<bool> ProtectAStream
    (InMemoryRandomAccessStream unprotectedInMemoryRandomAccessStream, string identity,
    InMemoryRandomAccessStream protectedInMemoryRandomAccessStream)
{
    IInputStream unprotectedStream = unprotectedInMemoryRandomAccessStream.GetInputStreamAt(0);
    IOutputStream protectedStream = protectedInMemoryRandomAccessStream.GetOutputStreamAt(0);

    // Protect "inputStream".
    DataProtectionInfo info = 
        await DataProtectionManager.ProtectStreamAsync(unprotectedStream, identity, protectedStream);

    // Indicate to the caller whether the stream was protected successfully. It will only be protected if
    // the identity is managed AND this app is allowed for this identity. Similar to buffers, this status
    // must be stored by the app. UnprotectStreamAsync must only be called if the stream was protected
    // successfully earlier.

    return (info.Status == DataProtectionStatus.Protected);
}
```

To show how you might use a method like the one in the code example above, here's a helper method that uses it to convert a string into an unprotected stream, and then protect the stream.

```CSharp
using Windows.Storage.Streams;

private async System.Threading.Tasks.Task<bool> ProtectStringAsStreamAsync
    (string unprotectedEnterpriseData, string identity, 
    InMemoryRandomAccessStream protectedInMemoryRandomAccessStream)
{
    using (var unprotectedInMemoryRandomAccessStream = new InMemoryRandomAccessStream())
    {
        using (var dataWriter = new DataWriter(unprotectedInMemoryRandomAccessStream))
        {
            dataWriter.WriteString(unprotectedEnterpriseData);
            await dataWriter.StoreAsync();
            await dataWriter.FlushAsync();
            return await this.ProtectAStream(unprotectedInMemoryRandomAccessStream,
                identity, protectedInMemoryRandomAccessStream);
        }
    }
}
```

## Retrieve the status of a stream


In this scenario, your app has previously protected a stream to which you must prevent unauthorized access. In order to retrieve the stream's contents back when needed, your app can check the status of the stream.

Note that the status of a stream is also returned from [**DataProtectionManager.UnprotectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/dn706023). This API will never return a status of ‘Unprotected’, since it requires that the input resource be protected (it is not possible to reliably verify that a resource is unprotected). Be aware if you have code that compares the result with 'Unprotected', then that suggests the presence of a design flaw. It's an indication that your code has lost track of whether the stream is protected.

```CSharp
using Windows.Storage.Streams;
using Windows.Security.EnterpriseData;

private async void CheckProtectedStreamStatus(IInputStream protectedStream)
{
    DataProtectionInfo dataProtectionInfo = 
        await DataProtectionManager.GetStreamProtectionInfoAsync(protectedStream);

    if (dataProtectionInfo.Status == DataProtectionStatus.Revoked)
    {
        // Code goes here to handle this situation. Perhaps, show UI
        // saying that the user's data has been revoked.
    }
    else if (dataProtectionInfo.Status != DataProtectionStatus.Protected)
    {
        // Code goes here to handle the unexpected protection status.
    }
}
```

## Unprotect a stream of data


In this scenario, your app wishes to unprotected a stream that it previously protected. This code example takes a protected stream (note that the stream must be protected for this process to work) and unprotects it with a call to [**DataProtectionManager.UnprotectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/dn706023). It then reads a string out of the stream and returns it.

```CSharp
using Windows.Storage.Streams;

private async System.Threading.Tasks.Task<string> UnprotectStreamIntoStringAsync
    (InMemoryRandomAccessStream protectedInMemoryRandomAccessStream)
{
    using (var unprotectedInMemoryRandomAccessStream = new InMemoryRandomAccessStream())
    {
        DataProtectionInfo dataProtectionInfo = 
            await DataProtectionManager.UnprotectStreamAsync(protectedInMemoryRandomAccessStream, 
            unprotectedInMemoryRandomAccessStream);

        using (var inputStream = unprotectedInMemoryRandomAccessStream.GetInputStreamAt(0))
        {
            using (var dataReader = new DataReader(inputStream))
            {
                await dataReader.LoadAsync((uint)unprotectedInMemoryRandomAccessStream.Size);
                return dataReader.ReadString((uint)unprotectedInMemoryRandomAccessStream.Size);
            }
        }
    }
}
```

To show how you might use the helper methods given so far, here's an event handler that takes a string from a text box, writes the string into a stream, protects the stream, unprotects the stream (if it was successfully protected), and finally reads the string back from the unprotected stream and displays it in the UI.

```CSharp
using Windows.Storage.Streams;

private async void ProtectAndThenUnprotectStream_Click(object sender, RoutedEventArgs e)
{
    var protectedInMemoryRandomAccessStream = new InMemoryRandomAccessStream();
    bool isStreamProtected = await this.ProtectStringAsStreamAsync
        (this.enterpriseDataTextBox.Text, MainPage.IDENTITY, protectedInMemoryRandomAccessStream);

    // Only unprotect the stream if we're sure that the stream actually was protected.
    if (isStreamProtected)
    {
        this.resultDataTextBlock.Text = 
            await this.UnprotectStreamIntoStringAsync(protectedInMemoryRandomAccessStream);
    }
}
```

## Retrieve the status of a static data buffer


In this scenario, your app has previously protected a buffer to which you must prevent unauthorized access. In order to retrieve the buffer's contents back when needed, your app can check the status of the buffer.

Note that the status of a buffer is also returned from [**DataProtectionManager.UnprotectAsync**](https://msdn.microsoft.com/library/windows/apps/dn706022). This API will never return a status of ‘Unprotected’, since it requires that the input resource be protected.

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage.Streams;

private async void CheckProtectedBufferStatus(IBuffer protectedData)
{
    DataProtectionInfo dataProtectionInfo = 
        await DataProtectionManager.GetProtectionInfoAsync(protectedData);

    if (dataProtectionInfo.Status == DataProtectionStatus.Revoked)
    {
        // Code goes here to handle this situation, perhaps show UI
        // saying that the user's data has been revoked.
    }
    else if (dataProtectionInfo.Status != DataProtectionStatus.Protected)
    {
        // Code goes here to handle the unexpected protection status.
    }
}
```

## Protect static data retrieved from an enterprise resource


This scenario covers the same ground as the stream code examples, except it works with a buffer of data. Again, you need to maintain state that indicates whether the buffer was protected, as shown. If the identity passed is not managed, or if the app is not allowed for the identity, the buffer will not be protected and an ‘Unprotected’ status will be returned from the call to [**DataProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn706020).

```CSharp
using Windows.Security.Cryptography;
using Windows.Security.EnterpriseData;
using Windows.Storage.Streams;

...

private IBuffer data = null;
private bool isProtected = false;

void StoreBuffer(IBuffer data, bool isProtected)
{
    this.data = data;
    this.isProtected = isProtected;
}

IBuffer GetStoredBuffer(out bool isProtected)
{
    isProtected = this.isProtected;
    return this.data;
}

private string identity = "contoso.com";

private async void ProtectAndThenUnprotectBuffer_Click(object sender, RoutedEventArgs e)
{
    BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;
    IBuffer inputData = CryptographicBuffer.ConvertStringToBinary
        (this.enterpriseDataTextBox.Text, encoding);
    BufferProtectUnprotectResult result =
        await DataProtectionManager.ProtectAsync(inputData, this.identity);

    // Record whether the buffer was protected successfully. It will only be protected if
    // the identity is managed AND this app is allowed for this identity. This status
    // must be stored by the app. UnprotectAsync must only be called if the buffer was
    // protected successfully earlier.
    bool isBufferProtected = 
        (result.ProtectionInfo.Status == DataProtectionStatus.Protected);
    IBuffer outputData = result.Buffer;

    // Store the data away...
    this.StoreBuffer(outputData, isBufferProtected);

    // ...and then later retrieve it.
    outputData = this.GetStoredBuffer(out isBufferProtected);

    string storedString = string.Empty;

    if (isBufferProtected)
    {
        result = await DataProtectionManager.UnprotectAsync(outputData);

        if (result.ProtectionInfo.Status != DataProtectionStatus.Unprotected)
        {
            // Code goes here to handle the situation where the buffer
            // is no longer accessible.
            return;
        }
        outputData = result.Buffer;
    }
    this.resultDataTextBlock.Text = CryptographicBuffer.ConvertBinaryToString(encoding, outputData);
}
```

## Enable UI-policy enforcement based on a stream's or buffer’s protected identity


When your app is about to display the contents of a protected stream or buffer on its UI, it must enable UI-policy enforcement based on the identity the resource is protected to. You should query the protection information of the resource and enable the system's UI-policy enforcement from the retrieved identity.

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage.Streams;

...

private async void EnableUIPolicyFromProtectedBuffer(IBuffer buffer)
{
    DataProtectionInfo protectionInfo = 
        await DataProtectionManager.GetProtectionInfoAsync(buffer);

    if (protectionInfo.Status != DataProtectionStatus.Protected)
    {
        // In this case, the app has lost access to the buffer
        // (ProtectedToOtherIdentity, Revoked). This must be handled.
        // &#39;Unprotected&#39; is never returned for GetProtectionInfoAsync().
        return;
    }

    ProtectionPolicyManager.TryApplyProcessUIPolicy(protectionInfo.Identity);
}

```

**Note**  This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps. If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

## Related topics


[enterprise data protection (EDP) sample](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)

[**Windows.Security.EnterpriseData namespace**](https://msdn.microsoft.com/library/windows/apps/dn279153)

 

 





<!--HONumber=Mar16_HO5-->


