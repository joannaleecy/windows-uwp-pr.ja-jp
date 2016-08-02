---
author: normesta
Description: 'This is a hub topic covering the full developer picture of how Windows Information Protection (WIP) relates to files, buffers, clipboard, networking, background tasks, and data protection under lock.'
MS-HAID: 'dev\_enterprise.edp\_hub'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: 'Windows Information Protection (WIP)'
---

# Windows Information Protection (WIP)

__Note__ Windows Information Protection (WIP) policy can be applied to Windows 10, version 1607.

This is a hub topic covering the full developer picture of how Windows Information Protection (WIP) relates to files, buffers, clipboard, networking, background tasks, and data protection under lock.

For more info about WIP from the point of view of end-users and administrators, see [Windows Information Protection (WIP) overview](https://technet.microsoft.com/library/dn985838(v=vs.85).aspx).

## What is WIP?

WIP is a set of features on desktops, laptops, tablets, and phones for Mobile Device Management (MDM). WIP gives an enterprise greater control over how its data (enterprise files and data blobs) is handled on devices that the enterprise manages.

-   Enterprise data is tagged with encryption. This is "enterprise-protected data", or just "protected data" for short.
-   Only apps that the managing enterprise explicitly allows via WIP policy can access enterprise-protected data, for example, in files.
-   Only apps explicitly allowed via WIP policy have enterprise Virtual Private Network (VPN) access.
-   App-restriction policy also determines how allowed apps should handle enterprise data.
-   Policy-based restrictions apply even to enterprise content exchanged via the Windows clipboard or via the Share contract.
-   On demand, the managing enterprise can revoke the device's access to protected content, essentially wiping the device of enterprise data while leaving personal data intact.
-   A channel app is an app that downloads protected data. Examples include mail and file-synchronization apps.

WIP enhances the [Encrypting File System (EFS)](http://technet.microsoft.com/library/cc700811.aspx) and [Windows Selective Wipe](https://technet.microsoft.com/library/dn486874.aspx) to provide more security and flexibility options. New WIP APIs let you create apps that protect and revoke access to enterprise content, work with protected file properties, and access encrypted data in its raw form. In addition to introducing new APIs for protecting files and folders, it introduces APIs for protecting buffers and streams. It also introduces a set of APIs that allow apps to identify and indicate the enterprise that must enforce data protection policy.

So that the managing enterprise can control access to its protected data, the app-restriction policy defines a list of apps, and restrictions on those apps. By default, an app is unable to autonomously access protected data. To gain access, the app must be added to a list called the allowed list, and apps on the allowed list are called allowed apps. On a managed device, Windows can restrict and/or audit access to protected data on the clipboard or via the share contract, so that access by an app not on the allowed list is audited and/or requires user consent, or else is completely blocked.

Policy for WIP is provided to a device by the managing enterprise (this makes the device a "managed device"). Provisioning of policy can happen through enrollment by the user in mobile device management (MDM), through manual configuration by IT, or through another management and policy delivery mechanism such as System Center Configuration Manager (SCCM).

WIP file protection leverages Rights Management Service (RMS) keys, if provisioned, since these keys can roam across devices and therefore allow protected data to roam. In the absence of RMS keys, these APIs will fall back to local Selective Wipe keys and limit roaming functionality. Data that roams encrypted will be accessible on down-level Windows and on third-party devices via platform-specific RMS apps provided by Microsoft, as well as with RMS-enlightened third party apps.

In summary—data protected with the WIP APIs can be managed by the enterprise, so you can build your app in a way that helps the enterprise protect and manage its data. In other words, you can build an enterprise-ready app. And, helping you do just that is what the rest of this guide is about.

## Enterprise-enlightened apps

Once your app is on the allowed list, it can read protected data. And, by default, any data output by your app is automatically protected by the system. That automatic protection is because the managing enterprise must, one way or another, ensure that enterprise data stays under its own control. But, keeping your app on such a short leash is only the default way to achieve that. A better way is to ask the system to trust you enough to give you more power and flexibility. And, the price of admission for that is to make your app smarter. That means going a step further than getting on the allowed list; it means making your app—and declaring it to be—enterprise-enlightened.

Your app is enlightened if it uses the techniques we'll describe to autonomously keep enterprise data protected whether the data is at rest, in use, or in flight. Your enlightened app recognizes enterprise data sources and enterprise data, and protects it when it arrives in your app. Being enlightened also means being aware of, and abiding by, WIP policy whenever enterprise data leaves your app. This includes disallowing content from going to a non-enterprise network end-point, wrapping the data in a portable encrypted form before allowing it to roam, and potentially (depending on policy settings), prompting the user before pasting enterprise data into an app not on the allowed list. Once you've made your app enlightened, your app announces to the system that it is enlightened by declaring the restricted **enterpriseDataPolicy** capability. For more info about working with restricted capabilities, see [Special and restricted capabilities](https://msdn.microsoft.com/library/windows/apps/mt270968#special_and_restricted_capabilities).

Ideally, all enterprise data is protected data, both at rest and in flight. But, inevitably, there must be some brief period between enterprise data being initially generated and it being protected. And, sometimes enterprise data can exist on an enterprise network endpoint without being encrypted. An enlightened app is capable of autonomously protecting such data; allowed-but-not-enlightened apps will need to have protection imposed by the system.

This is because an unenlightened app always runs in enterprise mode. The system makes sure of that. But, an enlightened app is free to move between enterprise mode and personal mode at will and as appropriate for the kind of data the app is working with at any given time. It's also important for an enlightened app to respect personal data, and not to tag personal data as enterprise data. An enlightened app may concurrently handle both enterprise data and personal data, so long as these promises are kept. The next section shows how to switch modes in code.

## WIP features at a glance

**File and buffer protection**

-   Your app can protect, containerize and wipe data associated with an enterprise identity.
-   Key-management is handled by Windows. Windows uses the enterprise’s RMS keys when they are available to the device; otherwise, Windows falls back to local Selective Wipe protection.

**Device policy management**

-   Your app can query the identity (enterprise or organization) that is managing the device.
-   Your app can protect users from inadvertent data disclosure by associating an identity with the data in question.
-   Your app can protect enterprise resources over the network by checking for enterprise-owned network endpoint connections (servers, IP ranges), and associating the data to a managed (that is, MDM-enrolled) identity.
-   The WIP APIs only work with managed identities that have an WIP policy defined on the device. If an identity is not managed, then, the APIs indicate that to the application, when necessary.

## Enlighten your app

If you're ready to enlighten your app, see one of these guides:

**For Universal Windows Platform (UWP) apps that you build by using C#**

[Build an enlightened app that consumes both enterprise and personal data](wip-dev-guide.md).

**For Desktop apps that you build by using C++**

[Build an enlightened app that consumes both enterprise and personal data (C++)](http://go.microsoft.com/fwlink/?LinkId=822192).


 
