---
author: drewbatgit
ms.assetid: 0186EA01-8446-45BA-A109-C5EB4B80F368
description: The AdvancedPhotoCapture class allows you to capture High Dynamic Range (HDR) photos.
title: High Dynamic Range (HDR) photo capture
---

# High Dynamic Range (HDR) photo capture

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


The [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) class allows you to capture High Dynamic Range (HDR) photos. This API also allows you to obtain a reference frame from the HDR capture before the processing of the final image is complete.

Other articles related to HDR capture include:

-   You can use the [**SceneAnalysisEffect**](https://msdn.microsoft.com/library/windows/apps/dn948902) to allow the system to evaluate the content of the media capture preview stream to determine if HDR processing would improve the capture result. For more information, see [Scene Analysis for Media Capture](scene-analysis-for-media-capture.md).

-   Use the [**HdrVideoControl**](https://msdn.microsoft.com/library/windows/apps/dn926680) to capture video using the Windows built-in HDR processing algorithm. For more information, see [Capture device controls for video capture](capture-device-controls-for-video-capture.md).

-   You can use the [**VariablePhotoSequenceCapture**](https://msdn.microsoft.com/library/windows/apps/dn652564) to capture a sequence of photos, each with different capture settings, and implement your own HDR or other processing algorithm. For more information, see [Variable photo sequence](variable-photo-sequence.md).

**Note**
-   Concurrently recording video and photo capture using **AdvancedPhotoCapture** is not supported.

-   Using the camera flash during advanced photo capture is not supported.

**Note** This article builds on concepts and code discussed in [Capture Photos and Video with MediaCapture](capture-photos-and-video-with-mediacapture.md), which describes the steps for implementing basic photo and video capture. It is recommended that you familiarize yourself with the basic media capture pattern in that article before moving on to more advanced capture scenarios. The code in this article assumes that your app already has an instance of MediaCapture that has been properly initialized.

## HDR photo capture namespaces

To use HDR photo capture, your app must include the following namespaces in addition to the namespaces required for basic media capture.

[!code-cs[HDRPhotoUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHDRPhotoUsing)]


## Determine if HDR photo capture is supported on the current device

The HDR capture technique described in this article is performed using the [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) object. Not all devices support HDR capture with **AdvancedPhotoCapture**. Determine if the device on which your app is currently running supports the technique by getting the **MediaCapture** object's [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) and then getting the [**AdvancedPhotoControl**](https://msdn.microsoft.com/library/windows/apps/mt147840) property. Check the video device controller's [**SupportedModes**](https://msdn.microsoft.com/library/windows/apps/mt147844) collection to see if it includes [**AdvancedPhotoMode.Hdr**](https://msdn.microsoft.com/library/windows/apps/mt147845). If it does, HDR capture using **AdvancedPhotoCapture** is supported.

[!code-cs[HdrSupported](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHdrSupported)]

## Configure and prepare the AdvancedPhotoCapture object

Since you will need to access the [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) instance from multiple places within your code, you should declare a member variable to hold the object.

[!code-cs[DeclareAdvancedCapture](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDeclareAdvancedCapture)]

In your app, after you have initialized the **MediaCapture** object, create an [**AdvancedPhotoCaptureSettings**](https://msdn.microsoft.com/library/windows/apps/mt147837) object and set the mode to [**AdvancedPhotoMode.Hdr**](https://msdn.microsoft.com/library/windows/apps/mt147845). Call the [**AdvancedPhotoControl**](https://msdn.microsoft.com/library/windows/apps/mt147840) object's [**Configure**](https://msdn.microsoft.com/library/windows/apps/mt147841) method, passing in the **AdvancedPhotoCaptureSettings** object you created.

Call the **MediaCapture** object's [**PrepareAdvancedPhotoCaptureAsync**](https://msdn.microsoft.com/library/windows/apps/mt181403), passing in an [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) object specifying the type of encoding the capture should use. The **ImageEncodingProperties** class provides static methods for creating the image encodings that are supported by **MediaCapture**.

**PrepareAdvancedPhotoCaptureAsync** returns the [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) object you will use to initiate photo capture. You can use this object to register handlers for the [**OptionalReferencePhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181392) and [**AllPhotosCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181387) which are discussed later in this article.

[!code-cs[CreateAdvancedCaptureAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCreateAdvancedCaptureAsync)]

## Capture an HDR photo

Capture an HDR photo by calling the [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) object's [**CaptureAsync**](https://msdn.microsoft.com/library/windows/apps/mt181388) method. This method returns a [**AdvancedCapturedPhoto**](https://msdn.microsoft.com/library/windows/apps/mt181378) object that provides the captured photo in its [**Frame**](https://msdn.microsoft.com/library/windows/apps/mt181382) property.

[!code-cs[CaptureHdrPhotoAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCaptureHdrPhotoAsync)]

**ConvertOrientationToPhotoOrientation** and **ReencodeAndSavePhotoAsync** are helper methods that are discussed as part of the basic media capture scenario in the article [Capture Photos and Video with MediaCapture](capture-photos-and-video-with-mediacapture.md).

## Get optional reference frame

The HDR process captures multiple frames and then composites them into a single image after all of the frames have been captured. You can get access to a frame after it is captured but before the entire HDR process is complete by handling the [**OptionalReferencePhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181392) event. You don't need to do this if you are only interested in the final HDR photo result.

**Important** [**OptionalReferencePhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181392) is not raised on devices that support hardware HDR and therefore do not generate reference frames. Your app should handle the case where this event is not raised.

Because the reference frame arrives out of context of the call to **CaptureAsync**, a mechanism is provided to pass context information to the **OptionalReferencePhotoCaptured** handler. First you should an object that will contain your context information. The name and contents of this object is up to you. This example defines an object that has members to track the file name and camera orientation of the capture.

[!code-cs[AdvancedCaptureContext](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetAdvancedCaptureContext)]

Create a new instance of your context object, populate its members, and then pass it into the overload of [**CaptureAsync**](https://msdn.microsoft.com/library/windows/apps/mt181388) that accepts an object as a parameter.

[!code-cs[CaptureWithContext](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCaptureWithContext)]

In the [**OptionalReferencePhotoCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181392) event handler, cast the [**Context**](https://msdn.microsoft.com/library/windows/apps/mt181405) property of the [**OptionalReferencePhotoCapturedEventArgs**](https://msdn.microsoft.com/library/windows/apps/mt181404) object to your context object class. This example modifies the file name to distinguish the reference frame image from the final HDR image and then calls the **ReencodeAndSavePhotoAsync** helper method to save the image.

[!code-cs[OptionalReferencePhotoCaptured](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOptionalReferencePhotoCaptured)]

## Receive a notification when all frames have been captured

The HDR photo capture has two steps. First, multiple frames are captured, and then the frames are processed into the final HDR image. You can't initiate another capture while the source HDR frames are still being captured, but you can initiate a capture after all of the frames have been captured but before the HDR post-processing is complete. The [**AllPhotosCaptured**](https://msdn.microsoft.com/library/windows/apps/mt181387) event is raised when the HDR captures are complete, letting you know that you can initiate another capture. A typical scenario is to disable your UI's capture button when HDR capture begins and then reenable it when **AllPhotosCaptured** is raised.

[!code-cs[AllPhotosCaptured](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetAllPhotosCaptured)]

## Clean up the AdvancedPhotoCapture object

When your app is done capturing, before disposing of the **MediaCapture** object, you should shut down the [**AdvancedPhotoCapture**](https://msdn.microsoft.com/library/windows/apps/mt181386) object by calling [**FinishAsync**](https://msdn.microsoft.com/library/windows/apps/mt181391) and setting your member variable to null.

[!code-cs[CleanUpAdvancedPhotoCapture](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanUpAdvancedPhotoCapture)]

## Related topics

* [Capture photos and video with MediaCapture](capture-photos-and-video-with-mediacapture.md)
