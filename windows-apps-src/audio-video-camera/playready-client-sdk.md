---
author: eliotcowley
ms.assetid: DD8FFA8C-DFF0-41E3-8F7A-345C5A248FC2
description: This topic describes how to add PlayReady protected media content to your Universal Windows Platform (UWP) app.
title: PlayReady DRM
---

# PlayReady DRM

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


This topic describes how to add PlayReady protected media content to your Universal Windows Platform (UWP) app.

PlayReady DRM enables developers to create UWP apps capable of providing PlayReady content to the user while enforcing the access rules defined by the content provider. This section describes changes made to Microsoft PlayReady DRM for Windows 10 and how to modify your PlayReady UWP app to support the changes made from the previous Windows 8.1 version to the Windows 10 version.
 
| Topic                                                                     | Description                                                                                                                                                                                                                                                                             |
|---------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Hardware DRM](hardware-drm.md)                                           | This topic provides an overview of how to add PlayReady hardware-based digital rights management (DRM) to your UWP app.                                                                                                                                                                 |
| [Adaptive Streaming with PlayReady](adaptive-streaming-with-playready.md) | This article describes how to add adaptive streaming of multimedia content with Microsoft PlayReady content protection to a Universal Windows Platform (UWP) app. This feature currently supports playback of Http Live Streaming (HLS) and Dynamic Streaming over HTTP (DASH) content. |

## What's New in PlayReady DRM

The following list describes the new features and changes made to PlayReady DRM for Windows 10.

-   Added hardware digital rights management (DRM).

    Hardware-based content protection support enables secure playback of high definition (HD) and ultra-high definition (UHD) content on multiple device platforms. Key material (including private keys, content keys, and any other key material used to derive or unlock said keys), and decrypted compressed and uncompressed video samples are protected by leveraging hardware security. When Hardware DRM is being used, neither unknown enabler (play to unknown / play to unknown with downres) has meaning as the HWDRM pipeline always knows the output being used. For more information, see [Hardware DRM](hardware-drm.md).

-   PlayReady is no longer an appX framework component, but instead is an in-box operating system component. The namespace was changed from **Microsoft.Media.PlayReadyClient** to [**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454).
-   The following headers defining the PlayReady error codes are now part of the Windows Software Development Kit (SDK): Windows.Media.Protection.PlayReadyErrors.h and Windows.Media.Protection.PlayReadyResults.h.
-   Provides proactive acquisition of non-persistent licenses.

    Previous versions of PlayReady DRM did not support proactive acquisition of non-persistent licenses. This capability has been added to this version. This can decrease the time to first frame. For more information, see [Proactively Acquire a Non-Persistent License Before Playback](#proactively_acquire_a_non_persistent_license_before_playback).

-   Provides acquisition of multiple licenses in one message.

    Allows the client app to acquire multiple non-persistent licenses in one license acquisition message. This can decrease the time to first frame by acquiring licenses for multiple pieces of content while the user is still browsing your content library; this prevents a delay for license acquisition when the user selects the content to play. In addition, it allows audio and video streams to be encrypted to separate keys by enabling a content header that includes multiple key identifiers (KIDs); this enables a single license acquisition to acquire all licenses for all streams within a content file instead of having to use custom logic and multiple license acquisition requests to achieve the same result.

-   Added real time expiration support, or limited duration license (LDL).

    Provides the ability to set real-time expiration on licenses and smoothly transition from an expiring license to another (valid) license in the middle of playback. When combined with acquisition of multiple licenses in one message, this allows an app to acquire several LDLs asynchronously while the user is still browsing the content library and only acquire a longer duration license once the user has selected content to playback. Playback will then start more quickly (because a license is already available) and, since the app will have acquired a longer duration license by the time the LDL expires, smoothly continue playback to the end of the content without interruption.

-   Added non-persistent license chains.
-   Added support for time-based restrictions (including expiration, expire after first play, and real time expiration) on non-persistent licenses.
-   Added HDCP Type 1 (version 2.2) policy support.

    See [Things to Consider](#things_to_consider) for more information.

-   Miracast is now implicit as an output.
-   Added secure stop.

    Secure stop provides the means for a PlayReady device to confidently assert to a media streaming service that media playback has stopped for any given piece of content. This capability ensures your media streaming services provide accurate enforcement and reporting of usage limitations on different devices for a given account.

-   Added audio and video license separation.

    Separate tracks prevent video from being decoded as audio; enabling more robust content protection. Emerging standards are requiring separate keys for audio and visual tracks.

-   Added MaxResDecode.

    This feature was added to limit playback of content to a maximum resolution even when in possession of a more capable key (but not a license). It supports cases where multiple stream sizes are encoded with a single key.

The following new interfaces, classes, and enumerations were added to PlayReady DRM:

-   [**IPlayReadyLicenseAcquisitionServiceRequest**](https://msdn.microsoft.com/library/windows/apps/dn986077) interface
-   [**IPlayReadyLicenseSession**](https://msdn.microsoft.com/library/windows/apps/dn986080) interface
-   [**IPlayReadySecureStopServiceRequest**](https://msdn.microsoft.com/library/windows/apps/dn986090) interface
-   [**PlayReadyLicenseSession**](https://msdn.microsoft.com/library/windows/apps/dn986309) class
-   [**PlayReadySecureStopIterable**](https://msdn.microsoft.com/library/windows/apps/dn986371) class
-   [**PlayReadySecureStopIterator**](https://msdn.microsoft.com/library/windows/apps/dn986375) class
-   [**PlayReadyHardwareDRMFeatures**](https://msdn.microsoft.com/library/windows/apps/dn986265) enumerator

A new sample has been created to demonstrate how to use the new features of PlayReady DRM. The sample can be downloaded from [http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670).

## Things to Consider

-   PlayReady DRM now supports HDCP Type 1 (version 2.2 or later). PlayReady carries the policy in the license for the device to enforce. This feature can be enabled in your PlayReady Server v3.0 SDK license (the server controls this policy in the license using the play enabler **GUID**). For more information, see the [PlayReady Compliance and Robustness Rules](http://www.microsoft.com/playready/licensing/compliance/).
-   Windows Media Video (also known as VC-1) is not supported in hardware DRM (see [Override Hardware DRM](hardware-drm.md#override-hardware-drm)).
-   PlayReady DRM now supports the High Efficiency Video Coding (HEVC /H.265) video compression standard. To support HEVC, your app must use Common Encryption Scheme (CENC) version 2 content which includes leaving the content's slice headers in the clear. Refer to ISO/IEC 23001-7 Information technology -- MPEG systems technologies -- Part 7: Common encryption in ISO base media file format files (Spec version ISO/IEC 23001-7:2015 or higher is required.) for more information. Microsoft also recommends using CENC version 2 for all HWDRM content. In addition, some hardware DRM will support HEVC and some will not (see [Override Hardware DRM](hardware-drm.md#override-hardware-drm)).
-   To take advantage of certain new PlayReady 3.0 features (including, but not limited to, SL3000 for hardware-based clients, acquiring multiple non-persistent licenses in one license acquisition message, and time-based restrictions on non-persistent licenses), the PlayReady server is required to be the Microsoft PlayReady Server Software Development Kit v3.0.2769 Release version or later.
-   Depending on the Output Protection Policy specified in the content license, media playback may fail for end users if their connected output does not support those requirements. The following table lists the set of common errors that occur as a result. For more information, see the [PlayReady Compliance and Robustness Rules](http://www.microsoft.com/playready/licensing/compliance/).

| Error                                                   | Value      | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|---------------------------------------------------------|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ERROR\_GRAPHICS\_OPM\_OUTPUT\_DOES\_NOT\_SUPPORT\_HDCP  | 0xC0262513 | The license's Output Protection Policy requires the monitor to engage HDCP, but HDCP was unable to be engaged.                                                                                                                                                                                                                                                                                                                                                                                              |
| MF\_E\_POLICY\_UNSUPPORTED                              | 0xC00D7159 | The license's Output Protection Policy requires the monitor to engage HDCP Type 1, but HDCP Type 1 was unable to be engaged.                                                                                                                                                                                                                                                                                                                                                                                |
| DRM\_E\_TEE\_OUTPUT\_PROTECTION\_REQUIREMENTS\_NOT\_MET | 0x8004CD22 | This error code only occurs when running under hardware DRM. The license's Output Protection Policy requires the monitor to engage HDCP or to reduce the content's effective resolution, but HDCP was unable to be engaged and the content's effective resolution could not be reduced because hardware DRM does not support reducing the content's resolution. Under software DRM, the content plays. See [Considerations for Using Hardware DRM](hardware-drm.md#considerations-for-using-hardware-drm). |
| ERROR\_GRAPHICS\_OPM\_NOT\_SUPPORTED                    | 0xc0262500 | The graphics driver does not support Output Protection. For example, the monitor is connected through VGA or an appropriate graphics driver for the digital output is not installed. In the latter case, the typical driver that is installed is the Microsoft Basic Display Adapter and installing an appropriate graphics driver will resolve the issue.                                                                                                                                                  |

## Prerequisites

Before you begin creating your PlayReady-protected UWP app, the following software needs to be installed on your system:

-   Windows 10.
-   If you are compiling any of the samples for PlayReady DRM for UWP apps, you must use Microsoft Visual Studio 2015 or later to compile the samples. You can still use Microsoft Visual Studio 2013 to compile any of the samples from PlayReady DRM for Windows 8.1 Store Apps.

If you are planning to play back MPEG-2/H.262 content on your app, you must also download and install [Windows 8.1 Media Center Pack](http://go.microsoft.com/fwlink/p/?LinkId=626876).

## PlayReady Windows Store App Migration Guide

This section includes information on how to migrate your existing PlayReady Windows 8.x Store apps to Windows 10.

The namespace for PlayReady UWP apps on Windows 10 was changed from **Microsoft.Media.PlayReadyClient** to [**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454). This means that you will need to search and replace the old namespace with the new one in your code. You will still be referencing a winmd file. It is part of windows.media.winmd on the Windows 10 operating system. It is in windows.winmd as part of the TH’s Windows SDK. For UWP, it’s referenced in windows.foundation.univeralappcontract.winmd.

To play back PlayReady-protected high definition (HD) content (1080p) and ultra-high definition (UHD) content, you will need to implement PlayReady hardware DRM. For information on how to implement PlayReady hardware DRM, see [Hardware DRM](hardware-drm.md).

Some content is not supported in hardware DRM. For information on disabling hardware DRM and enabling software DRM, see [Override Hardware DRM](hardware-drm.md#override-hardware-drm).

Regarding the media protection manager, make sure your code has the following settings if it doesn’t already:

```cs
var mediaProtectionManager = new Windows.Media.Protection.MediaProtectionManager();

mediaProtectionManager.properties["Windows.Media.Protection.MediaProtectionSystemId"] = 
             '{F4637010-03C3-42CD-B932-B48ADF3A6A54}'
var cpsystems = new Windows.Foundation.Collections.PropertySet();
cpsystems["{F4637010-03C3-42CD-B932-B48ADF3A6A54}"] = 
                "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput";
mediaProtectionManager.properties["Windows.Media.Protection.MediaProtectionSystemIdMapping"] = cpsystems;

mediaProtectionManager.properties["Windows.Media.Protection.MediaProtectionContainerGuid"] = 
                "{9A04F079-9840-4286-AB92-E65BE0885F95}";
```

## Proactively Acquire a Non-Persistent License Before Playback

This section describes how to acquire non-persistent licenses proactively before playback begins.

In previous versions of PlayReady DRM, non-persistent licenses could only be acquired reactively during playback. In this version, you can acquire non-persistent licenses proactively before playback begins.

1.  Proactively create a playback session where the non-persistent license can be stored. For example:

    ```cs
    var cpsystems = new Windows.Foundation.Collections.PropertySet();       
    cpsystems["{F4637010-03C3-42CD-B932-B48ADF3A6A54}"] = "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput"; // PlayReady

    var pmpSystemInfo = new Windows.Foundation.Collections.PropertySet();
    pmpSystemInfo["Windows.Media.Protection.MediaProtectionSystemId"] = "{F4637010-03C3-42CD-B932-B48ADF3A6A54}";
    pmpSystemInfo["Windows.Media.Protection.MediaProtectionSystemIdMapping"] = cpsystems;
    var pmpServer = new Windows.Media.Protection.MediaProtectionPMPServer( pmpSystemInfo );
    ```

2.  Tie that playback session to the license acquisition class. For example:

    ```cs
    var licenseSessionProperties = new Windows.Foundation.Collections.PropertySet();
    licenseSessionProperties["Windows.Media.Protection.MediaProtectionPMPServer"] = pmpServer;
    var licenseSession = new Windows.Media.Protection.PlayReady.PlayReadyLicenseSession( licenseSessionProperties );
    ```

3.  Create a license service request. For example:

    ```cs
    var laSR = licenseSession.CreateLAServiceRequest();
    ```

4.  Perform the license acquisition using the service request created from step 3. The license will be stored in the playback session.
5.  Tie the playback session to the media source for playback. For example:

    ```cs
    licenseSession.configureMediaProtectionManager( mediaProtectionManager );
    videoPlayer.msSetMediaProtectionManager( mediaProtectionManager );
    ```
    
## Add Secure Stop

This section describes how to add secure stop to your UWP app.

Secure stop provides the means for a PlayReady device to confidently assert to a media streaming service that media playback has stopped for any given piece of content. This capability ensures your media streaming services provide accurate enforcement and reporting of usage limitations on different devices for a given account.

There are two primary scenarios for sending a secure stop challenge:

-   When the media presentation stops because end of content was reached or when the user stopped the media presentation somewhere in the middle.
-   When the previous session ends unexpectedly (for example, due to a system or app crash). The app will need to query, either at startup or shutdown, for any outstanding secure stop sessions and send challenge(s) separate from any other media playback.

For a sample implementation of secure stop, see the securestop.cs file in the PlayReady sample located at [http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670).

 

 




