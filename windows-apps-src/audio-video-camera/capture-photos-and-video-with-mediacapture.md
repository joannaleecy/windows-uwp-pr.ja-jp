---
author: drewbatgit
ms.assetid: 1361E82A-202F-40F7-9239-56F00DFCA54B
description: This article describes the steps for capturing photos and video using the MediaCapture API, including initializing and shutting down the MediaCapture and handling changes in device orientation.
title: Capture photos and video with MediaCapture
---

# Capture photos and video with MediaCapture

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


This article describes the steps for capturing photos and video using the [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) API, including initializing and shutting down the **MediaCapture** and handling changes in device orientation.

**MediaCapture** is provided to support apps that require low-level control of the media capture process and that implement scenarios that require advanced capture capabilities. Using **MediaCapture** also requires you to provide your own capture UI. If your app only needs to capture a photo or video and is unconcerned with advanced capture techniques, the [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) makes it easy to capture a photo or video with only a few lines of code. For more information, see [Capture photos and video with CameraCaptureUI](capture-photos-and-video-with-cameracaptureui.md).

The code in this article was adapted from the [CameraStarterKit sample](http://go.microsoft.com/fwlink/?LinkId=619479). You can download the sample to see the code used in context or to use the sample as a starting point for your own app.

## Configure your project

### Add capability declarations to the app manifest

In order for your app to access a device's camera, you must declare that your app uses the *webcam* and *microphone* device capabilities. If you want to save captured photos and videos to the users's Pictures or Videos library, you must also declare the *picturesLibrary* and *videosLibrary* capability.

**Add capabilities to the app manifest**

1.  In Microsoft Visual Studio, in **Solution Explorer**, open the designer for the application manifest by double-clicking the **package.appxmanifest** item.
2.  Select the **Capabilities** tab.
3.  Check the box for **Webcam** and the box for **Microphone**.
4.  For access to the Pictures and Videos library check the boxes for **Pictures Library** and the box for **Videos Library**.

### Add using directives for media capture-related APIs

The following code listing shows the namespaces that are referenced by the sample code in this article and describes what functionality each namespace provides.

[!code-cs[Using](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUsing)]

## Initialize the MediaCapture object

The [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) class in the [**Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/br226738) namespace is the fundamental interface for all media capture operations. Apps typically declare a variable of this type scoped to a single page. Your app needs to track the current state of the **MediaCapture**, so you should declare boolean variables for the initialization, previewing, and recording state of the object.

[!code-cs[MediaCaptureVariables](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetMediaCaptureVariables)]

To help orient the preview video correctly, create member variables to track whether the camera is external and whether the app is currently mirroring the preview stream. Your app should mirror the preview stream when you think the video feed is capturing the user because that is a more natural user experience.

[!code-cs[PreviewVariables](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPreviewVariables)]

The following example method initializes the media capture object. First, the code searches for a video capture device that can be used for media capture. Once found, the **MediaCapture** object is initialized and handlers for its events are registered. Next a [**MediaCaptureInitializationSettings**](https://msdn.microsoft.com/library/windows/desktop/hh802710) object is created using the ID of the video capture device. The **MediaCapture** is then initialized with a call to [**InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598).

[!code-cs[InitializeCameraAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetInitializeCameraAsync)]

-   The [**DeviceInformation.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) method can be used to find all devices of a specified type. In this example, the **DeviceClass.VideoCapture** enumeration value is passed in to indicate that only video capture devices should be returned. Note that a video capture device is used for capturing both photos and videos.

-   **FindAllAsync** returns a [**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) object that contains a [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) object for each found device of the requested type. The **FirstOrDefault** extension method from the **System.Linq** namespace provides an easy syntax for selecting an item from a list based on specified conditions. The first call attempts to select the first **DeviceInformation** in the list that has an [**EnclosureLocation.Panel**](https://msdn.microsoft.com/library/windows/apps/br229906) value of **Panel.Back**, indicating that the camera is on the back panel of the device's enclosure. If the device does not have a camera on the back panel, the first available camera is used.

-   If you do not specify a device ID when you initialize the [**MediaCaptureInitializationSettings**](https://msdn.microsoft.com/library/windows/apps/br226573), the system will choose the first device in its internal list of devices.

-   The call to [**MediaCapture.InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) initializes the object to use the specified capture device. This call is made inside a **try** block because it will throw an **UnauthorizedAccessException** if the user has denied the calling app access to the camera. If the call succeeds, the **\_isInitialized** variable is set to true so that subsequent method calls can determine if the capture device has been initialized.

- **Important** On some device families, a user consent prompt is displayed to the user before your app is granted access to the device's camera. For this reason, you must only call [**MediaCapture.InitializeAsync**](https://msdn.microsoft.com/library/windows/apps/br226598) from the main UI thread. Attempting to initialize the camera from another thread may result in initialization failure.

-   If the initialization of the capture device is successful, variables are set to reflect whether the capture device is external, or if it is on the front panel of the device. These values will be used to orient the capture preview correctly for the user. Finally, the UI is updated to reflect that capture is available and the preview stream from the capture device is started. All of these tasks are performed in helper methods that will be described later in this article.

## Start the capture preview

For the user to be able to see what they are capturing, you need to provide a preview of what the video capture device is currently seeing in your UI.

**Important** You must start the capture preview in order for the capture device to enable auto focus, auto exposure, and auto white balance.

The [**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) control is provided to enable capture preview. The following shows example XAML code that defines the capture element.

[!code-xml[CaptureElement](./code/BasicMediaCaptureWin10/cs/MainPage.xaml#SnippetCaptureElement)]

Users expect that the screen will stay on while they are previewing the video capture screen and not turn off due to inactivity. To enable this, you must create a [**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816) object. Declare this variable with page scope so that it persists throughout the capture session.

[!code-cs[DisplayRequest](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDisplayRequest)]

The following method starts up the media capture preview. First, it requests that the display remain active by calling [**RequestActive**](https://msdn.microsoft.com/library/windows/apps/br241818) on the [**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816). Next, the preview is started by calling [**StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226613).

[!code-cs[StartPreviewAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStartPreviewAsync)]

-   The [**RequestActive**](https://msdn.microsoft.com/library/windows/apps/br241818) method is called on the **DisplayRequest** object to request that the system leave the screen on.

-   The [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) property of the **CaptureElement** is set to the app's **MediaCapture** object to define the source of the preview.

-   The [**FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) property is provided by the XAML framework to support bi-directional user interfaces. Setting the flow direction of the **CaptureElement** to [**FlowDirection.RightToLeft**](https://msdn.microsoft.com/library/windows/apps/br242397) causes the preview video to be flipped horizontally. This is used when the capture device is on the front panel of the device so that the preview in the correct direction from the user's perspective.

-   The [**StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226613) method starts the display of the preview stream within the **CaptureElement**. If the preview is started successfully, the **\_isPreviewing** variable is set to allow other parts of the app to know that the app is currently previewing, and the helper method for setting the preview rotation is called. This method is defined in the next section.

## Detect screen and device orientation

There are several areas of a media capture app that, when running on a mobile device like a phone or a tablet, are impacted by the current orientation of the device. These areas include properly rotating the preview stream from the camera and properly encoding captured images and videos so that, when viewed by the user, they are correctly oriented.

The term "display orientation" refers to the way the system rotates the XAML page on the device to keep it upright for the user. "Device orientation" refers to the orientation of the device in world space and, therefore, the orientation of the physical camera device in world space. Both kinds of orientation a relevant to a media capture app. To handle display orientation, declare and initialize a page-scoped variable for the [**DisplayInformation**](https://msdn.microsoft.com/library/windows/apps/dn264258) class. Declare another variable of type [**DisplayOrientations**](https://msdn.microsoft.com/library/windows/apps/br226142) to track the current orientation of the display. Declare a [**SimpleOrientationSensor**](https://msdn.microsoft.com/library/windows/apps/br206400) variable and a [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/br206399) variable to track device orientation.

[!code-cs[DisplayInformationAndOrientation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDisplayInformationAndOrientation)]

The following helper methods register and unregister event handlers for the [**DisplayInformation.OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) and [**SimpleOrientationSensor.OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/br206407) events and initialize the tracking variables with the current orientation. Note that not all devices have a [**SimpleOrientationSensor**](https://msdn.microsoft.com/library/windows/apps/br206400), so you should check before registering the handler or attempting to get the current orientation.

[!code-cs[RegisterOrientationEventHandlers](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterOrientationEventHandlers)]

[!code-cs[UnregisterOrientationEventHandlers](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUnregisterOrientationEventHandlers)]

In the event handler for the **SimpleOrientationSensor.OrientationChanged** event, update the device orientation variable with the current orientation. You should not update the orientation if the device is facing up or down.

[!code-cs[SimpleOrientationChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSimpleOrientationChanged)]

In the event handler for the **DisplayInformation.OrientationChanged** event, update the display orientation variable with the current orientation. If the video preview of the capture device is currently being displayed, update the rotation of the preview video stream. The **SetPreviewRotationAsync** helper method is described in the following section.

[!code-cs[DisplayOrientationChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDisplayOrientationChanged)]

## Set the media capture preview rotation

Users expect for UI controls to rotate when the orientation of their mobile device changes, so that the text in the UI is vertically aligned and readable. For the **CaptureElement** control, however, users typically do not want the orientation of the video preview to rotate when the device does. In order to provide the expected user experience, you should rotate the preview stream to match the orientation of the device.

The preview stream orientation must be expressed in degrees. The following helper method to converts the [**DisplayOrientations**](https://msdn.microsoft.com/library/windows/apps/br226142) enumeration values into degrees.

[!code-cs[ConvertDisplayOrientationToDegrees](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetConvertDisplayOrientationToDegrees)]

And this helper method converts a [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/br206399) enumeration value, which is used by the [**SimpleOrientationSensor**](https://msdn.microsoft.com/library/windows/apps/br206400) to express the rotation of the device, into degrees.

[!code-cs[ConvertDeviceOrientationToDegrees](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetConvertDeviceOrientationToDegrees)]

At a low-level, the rotation of a stream is actually performed by the Microsoft Media Foundation framework. The rotation is specified using the [MF\_MT\_VIDEO\_ROTATION](https://msdn.microsoft.com/library/windows/desktop/hh162880) attribute. Since this is a Windows Runtime app, the rotation is specified using the GUID for the attribute, rather than the attribute name. Define the following GUID to identify the video rotation attribute.

[!code-cs[RotationKey](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRotationKey)]

The following method sets the rotation of the preview stream. The [**GetMediaStreamProperties**](https://msdn.microsoft.com/library/windows/apps/br211995) method of the media capture's [**VideoDeviceController**](https://msdn.microsoft.com/library/windows/apps/br226825) returns a property set made up of key/value pairs. [**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) is specified to indicate that we want the properties for the video preview stream, as opposed to the video recording stream or the audio stream. The property set is a general purpose interface for setting stream properties, but for this task the video rotation GUID defined above is added as the property key and the desired orientation of the video stream, in degrees, is specified as the value. [**SetEncodingPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/dn297781) updates the encoding properties with the new values. Once again, **MediaStreamType.VideoPreview** is specified to indicate that the properies being set are for the video preview stream.

[!code-cs[SetPreviewRotation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSetPreviewRotation)]

-   For devices with external cameras, the user does not expect for the camera stream to be rotated when the device rotates.

-   If the preview is being mirrored for a camera on the front panel, the rotation direction must be inverted to match the rotation of the device.

-   Some devices, typically phones, support setting [**DisplayInformation.AutoRotationPreferences**](https://msdn.microsoft.com/library/windows/apps/dn264259) to an orientation value such as [**DisplayOrientations.Landscape**](https://msdn.microsoft.com/library/windows/apps/br226142) to force the display to rotate with the device. You should set this value because it provides a good experience on devices that support it, but you should still implement the above pattern in your app to support devices that don't support auto-rotation preferences.

-   In previous releases, the [**SetPreviewRotation**](https://msdn.microsoft.com/library/windows/apps/br226611) method was the only way to rotate the preview stream. This method is still present in the API surface to support existing apps, but this method inefficient and should not be used for new apps.

## Capture a photo

The following method captures a photo using the [**CapturePhotoToStreamAsync**](https://msdn.microsoft.com/library/windows/apps/hh700840) method and passing in the requested encoding properties and an [**InMemoryRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241720) object that will contain the output of the capture operation. The [**ImageEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh700993) class provides helper methods, like [**CreateJpeg**](https://msdn.microsoft.com/library/windows/apps/hh700994), to generate encoding properties for the file types supported by media capture.

[!code-cs[TakePhotoAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetTakePhotoAsync)]

Before saving the photo to a file, you need to determine the correct orientation of the photo. The **MediaCapture** object doesn't know about the device's orientation and so it encodes the captured photo data as if the capture device is in its default orientation. This can result in a negative user experience when the user is viewing the captured photo, as the photo will be oriented incorrectly. The following helper methods determine the correct photo orientation and then save the file with the correct orientation.

The **GetCameraOrientation** helper method starts with the current device orientation and then rotates that value depending on the native orientation of the device and the location of the camera on the device. If the camera is mounted on the front panel of the device, as indicated in this example by the **\_mirroringPreview** variable, then the camera orientation should be inverted.

[!code-cs[GetCameraOrientation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetGetCameraOrientation)]

The following helper method simply converts values from the [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/br206399) enumeration values used by the orientation sensor to the equivalent [**PhotoOrientation**](https://msdn.microsoft.com/library/windows/apps/hh965476) value used by the bitmap encoder that will be used to save the file.

[!code-cs[ConvertOrientationToPhotoOrientation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetConvertOrientationToPhotoOrientation)]

Finally, the captured photo can be encoded and saved. Create a [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) object from the input stream containing the captured photo data. Create a new [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) and open it for reading and writing. Create a [**BitmapEncoder**](https://msdn.microsoft.com/library/windows/apps/br226206) object, passing in the output file and the decoder containing the image data. Create a new [**BitmapPropertySet**](https://msdn.microsoft.com/library/windows/apps/hh974338) and add a new property. The key for the property, "System.Photo.Orientation" specifies that the property represents the orientation of the photo. The value is the [**PhotoOrientation**](https://msdn.microsoft.com/library/windows/apps/hh965476) value that was previously calculated. Call [**SetPropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/br226252) to update the properties on the encoder and then call [**FlushAsync**](https://msdn.microsoft.com/library/dn237883) to write the photo to the storage file.

[!code-cs[ReencodeAndSavePhotoAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetReencodeAndSavePhotoAsync)]

-   Setting the "System.Photo.Orientation" bitmap property encodes the orientation of the photo into the metadata of the file. It does not cause the actual image data to be encoded differently. For more information about embedding metadata into image files, see [Image metadata](image-metadata.md).

-   For more information about working with images, including encoding and decoding images, see [Imaging](imaging.md).

## Capture a video

To start capturing video, first create a storage file to which the video will be recorded. Next create the [**MediaEncodingProfile**](https://msdn.microsoft.com/library/windows/apps/hh701026) that the **MediaCapture** will use to encode the video to the file. The **MediaEncodingProfile** class provides methods, like [**CreateMp4**](https://msdn.microsoft.com/library/windows/apps/hh701078), that create encoding profiles for the supported video formats. Use the helper methods discussed previously to get the correct rotation for the video, in degrees. Unlike the photo scenario, the video rotation information is encoded into the stream by the **MediaCapture**. Add the rotation information to the encoding profile by adding it to the [**VideoEncodingProperties.Properties**](https://msdn.microsoft.com/library/windows/apps/hh701254) collection. The previously defined GUID for video rotation is used as the key and the rotation, in degrees, is the value. Finally, call [**MediaCapture.StartRecordToStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh700863), specifying the encoding properties and the output file to begin recording.

[!code-cs[StartRecordingAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStartRecordingAsync)]

To stop recording, simply call [**MediaCapture.StopRecordAsync**](https://msdn.microsoft.com/library/windows/apps/br226623).

[!code-cs[StopRecordingAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStopRecordingAsync)]

A handler for the [**MediaCapture.RecordLimitationExceeded**](https://msdn.microsoft.com/library/windows/apps/hh973312) event was registered when the **MediaCapture** was initialized. In the handler, call the **StopRecordingAsync** method to stop video recording.

[!code-cs[RecordLimitationExceeded](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRecordLimitationExceeded)]

## Pause and resume video capture

For some scenarios you may want to pause and resume an ongoing video capture rather than stopping the capture and starting a new one. To pause recording call [**PauseRecordAsync**](https://msdn.microsoft.com/library/windows/apps/dn858102). If you specify [**MediaCapturePauseBehavior.RetainHardwareResources**](https://msdn.microsoft.com/library/windows/apps/dn926686), then on devices that don't support simultaneous video and photo capture, the app will be unable to capture photos while the video is paused. For information on determining if a device supports simultaneous photo and video capture, see [Camera profiles](camera-profiles.md).

[!code-cs[PauseRecordingAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPauseRecordingAsync)]

To resume a previously paused video capture, call [**ResumeRecordAsync**](https://msdn.microsoft.com/library/windows/apps/dn858103).

[!code-cs[ResumeRecordingAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetResumeRecordingAsync)]

## Clean up capture resources

It is very important that you shut down and release the media capture resources properly. Failure to do so can cause unexpected camera behavior after your app closes, which results in a negative user experience for your app. The following sections walk through the different steps you should take to shut down the camera.

### Shut down the capture preview

To shut down the capture preview, first call [**MediaCapture.StopPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226622). Set the [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) property of your [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) to null. Then, call the [**RequestRelease**](https://msdn.microsoft.com/library/windows/apps/br241819) on your [**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816) variable to allow the system to turn off the display when needed.

[!code-cs[StopPreviewAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetStopPreviewAsync)]

-   You can't access the UI from a non-UI thread, so the setting the **MediaElement.Source** property and calling **RequestRelease** must be made using the [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) method so that the calls execute on the UI thread.

### Shut down and dispose of the MediaCapture object

Before disposing of the **MediaCapture** object, stop any recording that is ongoing and stop the preview stream by calling the helper methods defined previously. Once this has been done, remove any event handlers registered with the **MediaCapture**, then call [**Dispose**](https://msdn.microsoft.com/library/windows/apps/dn278858) to free any resources associated with the object and set the **MediaCapture** variable to null

[!code-cs[CleanupCameraAsync](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCleanupCameraAsync)]

You should call this method to shut down and dispose of the **MediaCapture** object from inside the handler for the [**MediaCapture.Failed**](https://msdn.microsoft.com/library/windows/apps/br226593) event.

[!code-cs[CaptureFailed](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCaptureFailed)]

### Handle app lifetime and page navigation events

The app lifetime events give your app an opportunity to initialize and release resources. This is especially important with the **Application.Suspending** event, where it is essential that your app properly disposes of media capture resources.

You can register handlers for the application lifetime events in your page's constructor.

[!code-cs[RegisterAppLifetimeEvents](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterAppLifetimeEvents)]

In the handler for the **Application.Suspending** event, you should unregister the handlers for the display and device orientation events and shut down the **MediaCapture** object. The [**SystemMediaTransportControls.PropertyChanged**](https://msdn.microsoft.com/library/windows/apps/dn278720) event unregistered here is needed for another application lifecycle-related task that is described later in this article.

**Caution** 
You must request a suspending deferral by calling [**SuspendingOperation.GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) at the beginning of your suspending event handler. This requests that the system wait for you to signal that the operation is complete before tearing down your app. This is necessary because the **MediaCapture** shutdown operations are asynchronous, so the **Application.Suspending** event handler may complete before the camera is properly shut down. After your awaited asynchronous calls complete, you should release the deferral by calling [**SuspendingDeferral.Complete**](https://msdn.microsoft.com/library/windows/apps/br224685).

[!code-cs[Suspending](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSuspending)]

In the handler for the **Application.Resuming** event, you should register handlers for the display and device orientation events, register the **SystemMediaTransportControls.PropertyChanged** event, and initialize the **MediaCapture** object.

[!code-cs[Resuming](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetResuming)]

The [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) event gives an opportunity to initially register handlers for the display and device orientation events and initialize the **MediaCapture** object.

[!code-cs[OnNavigatedTo](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOnNavigatedTo)]

If your app has multiple pages, you should clean up your media capture objects in the [**OnNavigatingFrom**](https://msdn.microsoft.com/library/windows/apps/br227509) event handler.

[!code-cs[OnNavigatingFrom](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetOnNavigatingFrom)]

For your app to behave properly on devices that support multiple simultaneous windows, you must respond when your app is minimized or restored. To do this, you must handle the [**SystemMediaTransportControls.PropertyChanged**](https://msdn.microsoft.com/library/windows/apps/dn278720) event. Initialize a member variable to store a reference to the [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) object for your app.

[!code-cs[DeclareSystemMediaTransportControls](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetDeclareSystemMediaTransportControls)]

The code to register and unregister the **PropertyChanged** event should be added to the app life cycle events as shown in the examples above. In the handler for the event, check to see if the property change that triggered the event was the [**SystemMediaTransportControlsProperty.SoundLevel**](https://msdn.microsoft.com/library/windows/apps/dn278721) property. If this was the property that changed, check the value of the property. If the value is [**SoundLevel.Muted**](https://msdn.microsoft.com/library/windows/apps/hh700852), then your app was minimized and you should clean up your media capture resources appropriately. Otherwise, the event signals that your app window was restored and you should reinitialize you media capture resources. The **SoundLevel** property must be accessed on the UI thread, so the code in this method is wrapped in a call to [**Dispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317).

[!code-cs[SystemMediaControlsPropertyChanged](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSystemMediaControlsPropertyChanged)]

## Additional UI considerations for media capture

### Set auto-rotation preferences

As mentioned in the previous section on rotating the preview stream, some devices support setting [**DisplayInformation.AutoRotationPreferences**](https://msdn.microsoft.com/library/windows/apps/dn264259) to prevent the page, including the [**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) that displays the preview, from rotating as the device is rotating. This provides a good user experience on devices that support it. Set this value when your app launches or when you begin displaying the preview. Note that you should still implement preview rotation handling for devices that don't support auto-rotation preferences.

[!code-cs[SetAutoRotationPreferences](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetSetAutoRotationPreferences)]

### Handle UI element orientation

Users typically expect for the UI elements in a camera app, such as the buttons for initiating photo or video capture, to rotate along with the video preview. The following method illustrates the use of the previously defined orientation helper methods to properly orient the buttons in the camera UI. You should call this method from the [**DisplayInformation.OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/dn264268) and [**SimpleOrientationSensor.OrientationChanged**](https://msdn.microsoft.com/library/windows/apps/br206407) event handlers and when your app first launches. Your implementation my vary depending on your app's UI.

[!code-cs[UpdateButtonOrientation](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUpdateButtonOrientation)]

When your app is shutting down or if you navigate to a page that is unrelated to media capture, set the auto-rotation preference to [**None**](https://msdn.microsoft.com/library/windows/apps/br226142) to allow the UI to rotate normally.

[!code-cs[RevertAutoRotationPreferences](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRevertAutoRotationPreferences)]

### Support simultaneous photo and video capture

The [**Windows.Media.Capture**](https://msdn.microsoft.com/library/windows/apps/br226738) API allows you to capture photos and videos simultaneously on devices that support it. For brevity, this example uses the [**ConcurrentRecordAndPhotoSupported**](https://msdn.microsoft.com/library/windows/apps/dn278843) property to determine if simultaneous video and photo capture is supported, but a more robust and recommended way to do this is to use camera profiles. For more information, see [Camera profiles](camera-profiles.md).

The following helper method updates the app's controls to match the current capture state of the app. Call this method whenever the capture state of your app changes, such as when video capture is started or stopped.

[!code-cs[UpdateCaptureControls](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUpdateCaptureControls)]

### Support mobile-specific UI features

All of the code shown in this article will work in a Universal Windows app. With a few additional lines of code, you can take advantage of special UI features that are only present on mobile devices. To use these features, you must add a reference to the Microsoft Mobile Extension SDK for Universal App Platform to your project.

**To add a reference to the mobile extension SDK for hardware camera button support**

1.  In **Solution Explorer**, right-click **References** and select **Add Reference...**

2.  Expand the **Windows Universal** node and select **Extensions**.

3.  Click the checkbox next to **Microsoft Mobile Extension SDK for Universal App Platform**.

Mobile devices have a [**StatusBar**](https://msdn.microsoft.com/library/windows/apps/dn633864) control that provides the user with status information about the device. This control takes up space on the screen that can interfere with the media capture UI. You can hide the status bar by calling [**HideAsync**](https://msdn.microsoft.com/library/windows/apps/dn610339), but you must make this call from within a conditional block where you use the [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/dn949016) method to determine if the API is available. This method will only return true on mobile devices that support the status bar. You should hide the status bar when your app launches or when you begin previewing from the camera.

[!code-cs[HideStatusBar](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetHideStatusBar)]

When your app is shutting down or when the user navigates away from the media capture page of your app, you make the control visible again.

[!code-cs[ShowStatusBar](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetShowStatusBar)]

Some mobile devices have a dedicated hardware camera button that some users prefer over an on-screen control. To be notified when the hardware camera button is pressed, register a handler for the [**HardwareButtons.CameraPressed**](https://msdn.microsoft.com/library/windows/apps/dn653805) event. Because this API is available on mobile devices only, you must again use the **IsTypePresent** to make sure the API is supported on the current device before attempting to access it.

[!code-cs[PhoneUsing](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetPhoneUsing)]

[!code-cs[RegisterCameraButtonHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetRegisterCameraButtonHandler)]

In the handler for the **CameraPressed** event, you can initiate a photo capture.

[!code-cs[CameraPressed](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetCameraPressed)]

When your app is shutting down or the user moves away from the media capture page of your app, unregister the hardware button handler.

[!code-cs[UnregisterCameraButtonHandler](./code/BasicMediaCaptureWin10/cs/MainPage.xaml.cs#SnippetUnregisterCameraButtonHandler)]

**Note** This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps. If you're developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).

## Related topics

* [Camera profiles](camera-profiles.md)
* [High Dynamic Range (HDR) photo capture](high-dynamic-range-hdr-photo-capture.md)
* [Capture device controls for photo and video capture](capture-device-controls-for-photo-and-video-capture.md)
* [Capture device controls for video capture](capture-device-controls-for-video-capture.md)
* [Effects for video capture](effects-for-video-capture.md)
* [Scene analysis for media capture](scene-analysis-for-media-capture.md)
* [Variable photo sequence](variable-photo-sequence.md)
* [Get a preview frame](get-a-preview-frame.md)
* [CameraStarterKit sample](http://go.microsoft.com/fwlink/?LinkId=619479)
