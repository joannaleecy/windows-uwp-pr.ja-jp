---
Description: 'This is a hub topic covering the full developer picture of how enterprise data protection (EDP) relates to files, buffers, clipboard, networking, background tasks, and data protection under lock.'
MS-HAID: 'dev\_enterprise.edp\_hub'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: 'Enterprise data protection (EDP)'
---

# Enterprise data protection (EDP)

__Note__ Enterprise data protection (EDP) policy cannot be applied on Windows 10, Version 1511 (build 10586) or earlier.

This is a hub topic covering the full developer picture of how enterprise data protection (EDP) relates to files, buffers, clipboard, networking, background tasks, and data protection under lock.

For more info about EDP from the point of view of end-users and administrators, see [Enterprise data protection (EDP) overview](https://technet.microsoft.com/library/dn985838(v=vs.85).aspx).

## What is EDP?

EDP is a set of features on desktops, laptops, tablets, and phones for Mobile Device Management (MDM). EDP gives an enterprise greater control over how its data (enterprise files and data blobs) is handled on devices that the enterprise manages.

-   Enterprise data is tagged with encryption. This is "enterprise-protected data", or just "protected data" for short.
-   Only apps that the managing enterprise explicitly allows via EDP policy can access enterprise-protected data, for example, in files.
-   Only apps explicitly allowed via EDP policy have enterprise Virtual Private Network (VPN) access.
-   App-restriction policy also determines how allowed apps should handle enterprise data.
-   Policy-based restrictions apply even to enterprise content exchanged via the Windows clipboard or via the Share contract.
-   On demand, the managing enterprise can revoke the device's access to protected content, essentially wiping the device of enterprise data while leaving personal data intact.
-   A channel app is an app that downloads protected data. Examples include mail and file-synchronization apps.

EDP enhances the [Encrypting File System (EFS)](http://technet.microsoft.com/library/cc700811.aspx) and [Windows Selective Wipe](https://technet.microsoft.com/library/dn486874.aspx) to provide more security and flexibility options. New EDP APIs let you create apps that protect and revoke access to enterprise content, work with protected file properties, and access encrypted data in its raw form. In addition to introducing new APIs for protecting files and folders, it introduces APIs for protecting buffers and streams. It also introduces a set of APIs that allow apps to identify and indicate the enterprise that must enforce data protection policy.

So that the managing enterprise can control access to its protected data, the app-restriction policy defines a list of apps, and restrictions on those apps. By default, an app is unable to autonomously access protected data. To gain access, the app must be added to a list called the allowed list, and apps on the allowed list are called allowed apps. On a managed device, Windows can restrict and/or audit access to protected data on the clipboard or via the share contract, so that access by an app not on the allowed list is audited and/or requires user consent, or else is completely blocked.

Policy for EDP is provided to a device by the managing enterprise (this makes the device a "managed device"). Provisioning of policy can happen through enrollment by the user in mobile device management (MDM), through manual configuration by IT, or through another management and policy delivery mechanism such as System Center Configuration Manager (SCCM).

EDP file protection leverages Rights Management Service (RMS) keys, if provisioned, since these keys can roam across devices and therefore allow protected data to roam. In the absence of RMS keys, these APIs will fall back to local Selective Wipe keys and limit roaming functionality. Data that roams encrypted will be accessible on down-level Windows and on third-party devices via platform-specific RMS apps provided by Microsoft, as well as with RMS-enlightened third party apps.

In summary—data protected with the EDP APIs can be managed by the enterprise, so you can build your app in a way that helps the enterprise protect and manage its data. In other words, you can build an enterprise-ready app. And, helping you do just that is what the rest of this guide is about.

## Set up your computer for EDP


In order to properly develop your app, and test how it will behave in the enterprise, you'll want to set up your computer or device with the right conditions. That involves a few tasks ordinarily in the domain of IT administrators.

-   Have your development machine enrolled into mobile device management (MDM).
-   Have your app added to the allowed list via the [AppLocker configuration service provider](https://msdn.microsoft.com/library/windows/hardware/dn920019).

The next task is to build an app that's aware of, and can respond dynamically to, the managed identity of the enterprise it's running inside, and the protection policy in effect. That means "enlightening" your app. Apps that enlighten to follow policy are much more likely to be on the list allowed to access enterprise data.

## Enterprise-enlightened apps


Once your app is on the allowed list, it can read protected data. And, by default, any data output by your app is automatically protected by the system. That automatic protection is because the managing enterprise must, one way or another, ensure that enterprise data stays under its own control. But, keeping your app on such a short leash is only the default way to achieve that. A better way is to ask the system to trust you enough to give you more power and flexibility. And, the price of admission for that is to make your app smarter. That means going a step further than getting on the allowed list; it means making your app—and declaring it to be—enterprise-enlightened.

Your app is enlightened if it uses the techniques we'll describe to autonomously keep enterprise data protected whether the data is at rest, in use, or in flight. Your enlightened app recognizes enterprise data sources and enterprise data, and protects it when it arrives in your app. Being enlightened also means being aware of, and abiding by, EDP policy whenever enterprise data leaves your app. This includes disallowing content from going to a non-enterprise network end-point, wrapping the data in a portable encrypted form before allowing it to roam, and potentially (depending on policy settings), prompting the user before pasting enterprise data into an app not on the allowed list. Once you've made your app enlightened, your app announces to the system that it is enlightened by declaring the restricted **enterpriseDataPolicy** capability. For more info about working with restricted capabilities, see [Special and restricted capabilities](https://msdn.microsoft.com/library/windows/apps/mt270968#special_and_restricted_capabilities).

Ideally, all enterprise data is protected data, both at rest and in flight. But, inevitably, there must be some brief period between enterprise data being initially generated and it being protected. And, sometimes enterprise data can exist on an enterprise network endpoint without being encrypted. An enlightened app is capable of autonomously protecting such data; allowed-but-not-enlightened apps will need to have protection imposed by the system.

This is because an unenlightened app always runs in enterprise mode. The system makes sure of that. But, an enlightened app is free to move between enterprise mode and personal mode at will and as appropriate for the kind of data the app is working with at any given time. It's also important for an enlightened app to respect personal data, and not to tag personal data as enterprise data. An enlightened app may concurrently handle both enterprise data and personal data, so long as these promises are kept. The next section shows how to switch modes in code.

## Confirming an identity is managed, and determining protection policy enforcement level

Your app generally gets an enterprise identity from an external resource such as a mailbox email address, or a domain that is managed, or a uri hostname. You can call [**ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync**](https://msdn.microsoft.com/library/windows/apps/dn706027) to obtain the managed identity, if any, for a network endpoint hostname.

This code example illustrates the general structure for enlightened behavior, including how to determine whether an enterprise identity actually is managed, and what policy is currently in effect.

```CSharp
using Windows.Security.EnterpriseData;

...

string identity = "contoso.com";

if (ProtectionPolicyManager.IsIdentityManaged(identity))
{
    EnforcementLevel enforcementLevel = ProtectionPolicyManager.GetEnforcementLevel();

    // During UI activities or network access, call ProtectionPolicyManager APIs
    // (taking the enforcement level into account) to ensure that the system
    // tags data with the identity as appropriate.

    ProtectionPolicyManager.GetForCurrentView().Identity = identity;
    // The app is now in enterprise mode.

    ProtectionPolicyManager.GetForCurrentView().Identity = string.Empty;
    // The app is back in personal mode.
}
else
{
    // No policy enforcement is done on this identity.
}
```

As shown, you first determine whether EDP policy is set for the enterprise's identity. The term "managed" is short for "managed by an EDP policy". When EDP policy is set for a specific identity, [**ProtectionPolicyManager.IsIdentityManaged**](https://msdn.microsoft.com/library/windows/apps/dn705171) returns true for that identity. This is your cue to use EDP APIs with that identity. Although the file and buffer APIs are somewhat exceptional in that they will function as expected even for an unmanaged identity, that scenario doesn't make sense. If a device is managed, then it is managed for a enterprise identity. If an identity is not managed, then protecting data to that identity is meaningless.

The next step is to determine and implement the enforcement level for the policy. To determine the enforcement level for the policy, call the [**GetEnforcementLevel**](https://msdn.microsoft.com/library/windows/apps/mt608406) method. When an enterprise policy is enforced on the identity, your enlightened app must help the system with policy enforcement by calling [**ProtectionPolicyManager**](https://msdn.microsoft.com/library/windows/apps/dn705170) APIs during UI activities or network accesses to ensure that the system tags data transfers with this identity when necessary. More info about how to interpret the enforcement level and put it into practice is contained in this guide. The code example also shows how to enter enterprise mode, and return to personal mode, by setting the value of [**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) to the enterprise identity, or the empty string, respectively. Again, note that entering and exiting enterprise mode only makes sense with a managed identity.

## EDP features at a glance


**File and buffer protection.**

-   Your app can protect, containerize and wipe data associated with an enterprise identity.
-   Key-management is handled by Windows. Windows uses the enterprise’s RMS keys when they are available to the device; otherwise, Windows falls back to local Selective Wipe protection.

**Device policy management.**

-   Your app can query the identity (enterprise or organization) that is managing the device.
-   Your app can protect users from inadvertent data disclosure by associating an identity with the data in question.
-   Your app can protect enterprise resources over the network by checking for enterprise-owned network endpoint connections (servers, IP ranges), and associating the data to a managed (that is, MDM-enrolled) identity.
-   The EDP APIs only work with managed identities that have an EDP policy defined on the device. If an identity is not managed, then, the APIs indicate that to the application, when necessary.

Here's a list of links to topics that drill into EDP APIs and scenarios specific to these particular feature areas.

## Files

See [Use EDP to protect files](../files/protect-your-enterprise-data-with-edp.md).

## Streams and buffers

See [Use EDP to protect streams and buffers](../files/use-edp-to-protect-streams-and-buffers.md).

## Clipboard, share, and exchanging data between apps

See [Use EDP to protect enterprise data transferred between apps](../app-to-app/use-edp-to-protect-enterprise-data-transferred-between-apps.md).

## Networking

See [Tagging network connections with EDP identity](../networking/tagging_network_connections_with_edp_identity.md).

## Data protection under lock (DPL), and background tasks

An organization can choose to administer a secure "data protection under lock" (DPL) policy, where encryption keys required to access protected resources are temporarily removed from device memory when the device is locked. To prepare your app for this eventuality, see the [Handle device lock events and avoid leaving unprotected content in memory](#handle_lock_events) section in this topic. Also, if your app has a background task that needs to protect files, see [Protect enterprise data in a new file (for a background task)](../files/protect-your-enterprise-data-with-edp.md#protect_data_new_file_bg).

## UI-policy enforcement


In this section, we'll take the example of an enlightened mail app, which is currently displaying an enterprise mailbox among a set of mailboxes that include both enterprise and personal mailboxes belonging to the user. To ensure that there are no data leaks from the enterprise data in the enterprise mailbox, the app calls [**ProtectionPolicyManager.TryApplyProcessUIPolicy**](https://msdn.microsoft.com/library/windows/apps/dn705791) to make sure that the operating system knows about the current context of the app, whether enterprise or personal. The API returns false if the identity is not being managed by an enterprise policy.

```CSharp
using Windows.Security.EnterpriseData;

...

public class Mailbox
{
    public bool HasEnterpriseMail { get { /* implementation */ } }
    public string Identity { get { /* implementation */ } }
}

private void SwitchMailbox(Mailbox targetMailbox)
{
    // Code goes here to perform setup for "targetMailbox".

    if (targetMailbox.HasEnterpriseMail)
    {
        bool result = 
            ProtectionPolicyManager.TryApplyProcessUIPolicy(targetMailbox.Identity);

        // Code goes here to process "result", which indicates whether
        // or not policy enforcement is in place for the identity.
    }
    else
    {
        // For personal mailboxes, we clear policy enforcement (in case
        // it is still set from when we processed an enterprise mailbox).
        ProtectionPolicyManager.ClearProcessUIPolicy();
    }
}
```

## Handle device lock events and avoid leaving unprotected content in memory


In this scenario, we'll take the example of an enlightened mail app that's designed to handle both enterprise mail and personal mail. When the app is running in an organization that has chosen to administer a secure "data protection under lock" (DPL) policy, the app must be sure to remove all sensitive data from memory while the device is locked. To do this, it registers for the [**ProtectionPolicyManager.ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/dn705787) and [**ProtectionPolicyManager.ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/dn705786) events so that it's notified whenever the device is locked and unlocked (in case DPL is in effect).

[**ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/dn705787) is raised before data protection keys provisioned on the device are temporarily removed. The reason these keys are removed when the device is locked is to ensure that there can't be unauthorized access to encrypted data while the device is locked and also possibly not in possession of its owner. [**ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/dn705786) is raised once the keys are available again upon device unlock.

By handing these two events, the app can ensure that it protects any sensitive content in memory with [**DataProtectionManager**](https://msdn.microsoft.com/library/windows/apps/dn706017). It should also close any file streams open on its protected files to ensure that the system does not cache any sensitive data in memory. You can do this in one of several ways. To close a file stream returned from an Open method of a **StorageFile**, you can call the **Dispose** method on the stream. You can scope the use of stream with a using statement (C\# or VB). Or, you can wrap a **DataReader** or a **DataWriter** object around the stream and use the **Dispose** method or using statement with that object.

**Note**  
In an environment without a DPL policy configured, the [**ProtectedAccessResumed**](https://msdn.microsoft.com/library/windows/apps/dn705786) event is raised, but not the [**ProtectedAccessSuspending**](https://msdn.microsoft.com/library/windows/apps/dn705787) event. Be aware of this in your code, and be careful not to assume that the events always come in pairs on every system, nor that you can always use the events to determine the locked/unlocked state of the device. You can see that in the code example here that we are careful not to assume anything about the protected state of the currently displayed email nor about the open state of the database file stream.

Also, be aware that when resuming from lock on a device without a DPL policy configured, [**ProtectedAccessResumedEventArgs.Identities**](https://msdn.microsoft.com/library/windows/apps/dn705772) is an empty collection.

In the interest of brevity, this code example is slightly simplified, and it focuses on dealing with enterprise mail. In a real app, personal mails would be written to a different, unprotected, mail database file, and you wouldn't protect personal emails under lock.

```CSharp
using Windows.Security.Cryptography;
using Windows.Security.EnterpriseData;
using Windows.Storage;
using Windows.Storage.Streams;

...

public class DisplayedMail
{
    public string Body { get; set; }
    public IBuffer ProtectedBody { get; set; }
    public bool IsProtected { get; set; }
}

private IOutputStream mailDatabaseStream = null;
private string currentlyDisplayedMailIdentity = "contoso.com";
private DisplayedMail currentlyDisplayedMail = new DisplayedMail()
    { Body = "Lorem ipsum dolor...", ProtectedBody = null, IsProtected = false };

// Gets the app's protected mail database file, then opens and stores a stream on it.
private async void OpenMailDatabase()
{
    // Only attempt to open the database file stream if we know it&#39;s closed.
    if (this.mailDatabaseStream == null)
    {
        StorageFolder appDataStorageFolder = ApplicationData.Current.LocalFolder;
        StorageFile storageFile = await appDataStorageFolder.GetFileAsync("maildb.dat");
        using (IRandomAccessStream randomAccessStream =
            await storageFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            this.mailDatabaseStream = randomAccessStream.GetOutputStreamAt(0);
        }
    }
}

// Called once by the app when starting up.
private void AppSetup()
{
    ProtectionPolicyManager.ProtectedAccessSuspending +=
        this.ProtectionPolicyManager_ProtectedAccessSuspending;
    ProtectionPolicyManager.ProtectedAccessResumed +=
        this.ProtectionPolicyManager_ProtectedAccessResumed;
    this.OpenMailDatabase();
}

// Background work called when the app receives an email.
private async void AppMailReceived(string fauxEmail)
{
    // Only attempt to write to the database file stream if we know it&#39;s open.
    if (this.mailDatabaseStream != null)
    {
        IBuffer emailAsBuffer = CryptographicBuffer.ConvertStringToBinary
            (fauxEmail, BinaryStringEncoding.Utf8);
        await this.mailDatabaseStream.WriteAsync(emailAsBuffer);
        await this.mailDatabaseStream.FlushAsync();
    }
    else
    {
        // Code goes here to handle the case where the device is
        // locked and we can't access the protected mail database.
    }
}

// Called by ProtectionPolicyManager when the device is locked if under DPL.
private async void ProtectionPolicyManager_ProtectedAccessSuspending
    (object sender, ProtectedAccessSuspendingEventArgs e)
{
    if (!new System.Collections.Generic.List<string>(e.Identities).Contains
        (this.currentlyDisplayedMailIdentity))
    {
        // This event is not for our identity. Another will be sent for our identity.
        return;
    }

    // Get suspension deferral.
    Windows.Foundation.Deferral deferral = e.GetDeferral();

    // Protect the displayed mail content.
    if (!this.currentlyDisplayedMail.IsProtected)
    {
        IBuffer mailBodyBuffer = CryptographicBuffer.ConvertStringToBinary
            (this.currentlyDisplayedMail.Body, BinaryStringEncoding.Utf8);
        BufferProtectUnprotectResult result = await DataProtectionManager.ProtectAsync
            (mailBodyBuffer, this.currentlyDisplayedMailIdentity);
        if (result.ProtectionInfo.Status == DataProtectionStatus.Protected)
        {
            // Save the protected version and clear the unprotected version.
            this.currentlyDisplayedMail.ProtectedBody = result.Buffer;
            this.currentlyDisplayedMail.Body = null;
        }
    }

    // Close the mail database file stream to make sure that we have no unprotected
    // content in memory.
    this.mailDatabaseStream.Dispose();
    this.mailDatabaseStream = null;

    // Optionally, code goes here to use e.Deadline to determine whether we have more
    // than 15 seconds left before the suspension deadline. If we do then process any
    // messages queued up for sending while we are still able to access them.

    // All done. Complete deferral.
    deferral.Complete();
}

// Called by ProtectionPolicyManager when the device is unlocked.
private async void ProtectionPolicyManager_ProtectedAccessResumed
    (object sender, ProtectedAccessResumedEventArgs e)
{
    if (!new System.Collections.Generic.List<string>(e.Identities).Contains
        (this.currentlyDisplayedMailIdentity))
    {
        // This event is not for our identity. Another will be sent for our identity.
        return;
    }

    // Unprotect the displayed mail content.
    if (this.currentlyDisplayedMail.IsProtected)
    {
        BufferProtectUnprotectResult result = await DataProtectionManager.UnprotectAsync
            (this.currentlyDisplayedMail.ProtectedBody);
        if (result.ProtectionInfo.Status == DataProtectionStatus.Unprotected)
        {
            // Restore the unprotected version.
            this.currentlyDisplayedMail.Body = CryptographicBuffer.ConvertBinaryToString
                (BinaryStringEncoding.Utf8, result.Buffer);
            this.currentlyDisplayedMail.ProtectedBody = null;
        }
    }

    // Reopen the closed mail database.
    this.OpenMailDatabase();
}
```

## Register to be notified when protected content is revoked


Picture the scenario where a mail app has set up an enterprise mailbox on a user’s device. At some point—and for one of several possible reasons—the enterprise wishes to revoke access to the enterprise-protected emails and other resources on that device. There are several possible reasons for the revocation. It's more likely than not that the particular enterprise policy will trigger a revocation on un-enroll, so one scenario is that the user has un-enrolled their device from the enterprise (perhaps they're gifting or selling the device, they just want to use a different one, they're moving to another job, or they're retiring). Another scenario is that an un-enroll notification is sent by an IT administrator remotely via Mobile Device Management (MDM), perhaps if a device is reported as lost.

Whatever the specifics of the case, the enterprise sends a request to wipe all mail from the user’s device, since it's no longer needed on there. A remote management client on a device receives the request from the enterprise’s remote management server, and calls [**ProtectionPolicyManager.RevokeContent**](https://msdn.microsoft.com/library/windows/apps/dn705790) to revoke the keys that are required to access content protected on that device to that enterprise identity.

If your app needs to be notified when a revoke happens, then you can register with the [**ProtectionPolicyManager.ProtectedContentRevoked**](https://msdn.microsoft.com/library/windows/apps/dn705788) event. When your app receives the event, it can delete any metadata associated with the enterprise mailbox, which will no longer be required.

```CSharp
using Windows.Security.EnterpriseData;

...

private string mailIdentity = "contoso.com";

void MailAppSetup()
{
    ProtectionPolicyManager.ProtectedContentRevoked += ProtectionPolicyManager_ProtectedContentRevoked;
    // Code goes here to set up mailbox for &#39;mailIdentity&#39;.
}

private void ProtectionPolicyManager_ProtectedContentRevoked(object sender, ProtectedContentRevokedEventArgs e)
{
    if (!new System.Collections.Generic.List<string>(e.Identities).Contains
        (this.mailIdentity))
    {
        // This event is not for our identity.
        return;
    }

    // Code goes here to delete any metadata associated with &#39;mailIdentity&#39;.
}
```

## Remote management client initiates a wipe of enterprise-protected data


A user has several enterprise files on their personal device that are protected to the enterprise identity. The user loses their device. When the enterprise is notified that the user has lost their device, the enterprise sends a request to wipe all sensitive data from the user’s device to prevent that data from leaking. The remote management client on the device receives this request from the enterprise’s remote management server, and it calls [**ProtectionPolicyManager.RevokeContent**](https://msdn.microsoft.com/library/windows/apps/dn705790) to revoke the keys required to access content protected to the enterprise identity.

```CSharp
Windows.Security.EnterpriseData.ProtectionPolicyManager.RevokeContent("contoso.com");
```

 

 





<!--HONumber=Mar16_HO5-->


