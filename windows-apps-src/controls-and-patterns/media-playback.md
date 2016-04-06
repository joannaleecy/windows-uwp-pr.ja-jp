---
Description: The media player is used to view and listen to video, audio, and images.
title: Media player
ms.assetid: 9AABB5DE-1D81-4791-AB47-7F058F64C491
dev.assetid: AF2F2008-9B53-430C-BBC3-8888F631B0B0
label: Media player
template: detail.hbs
author: mijacobs
---
# Media player

The media player is used to view and listen to video, audio, and images. Media playback can be inline (embedded in a page or with a group of other controls) or in a dedicated full-screen view. You can modify the player's button set, change the background of the control bar, and arrange layouts as you see fit. Just keep in mind that users expect a basic control set (play/pause, skip back, skip forward).

![Media element with transport controls](images/controls/media-transport-controls.png)

<span class="sidebar_heading" style="font-weight: bold;">Important APIs</span>

-   [**MediaElement class**](https://msdn.microsoft.com/library/windows/apps/br242926)
-   [**MediaTransportControls class**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediatransportcontrols)

## Is this the right control?

Use a media player when you want to play audio or video in your app. To display a collection of images, use a [Flip view](flipview.md).

## Examples

A media element in the Windows 10 Get Started app.

![A media elementin the Windows 10 Get Started app](images/control-examples/media-element-getstarted.png)

## Create a media player
Add media to your app by creating a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) object in XAML and set the [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) to a Uniform Resource Identifier (URI) that points to an audio or video file.

This XAML creates a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) and sets its [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) property to the URI of a video file that's local to the app. The **MediaElement** begins playing when the page loads. To suppress media from starting right away, you can set the [**AutoPlay**](https://msdn.microsoft.com/library/windows/apps/br227360) property to **false**.

```xaml
<MediaElement x:Name="mediaSimple" 
              Source="Videos/video1.mp4" 
              Width="400" AutoPlay="False"/>
```

This XAML creates a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) with the built in transport controls enabled and the [**AutoPlay**](https://msdn.microsoft.com/library/windows/apps/br227360) property set to **false.**


```csharp
<MediaElement x:Name="mediaPlayer" 
              Source="Videos/video1.mp4" 
              Width="400" 
              AutoPlay="False"
              AreTransportControlsEnabled="True"/>
```

### Media transport controls
MediaElement has built in transport controls that handle play, stop, pause, volume, mute, seeking/progress, and audio track selection. To enable these controls, set [**AreTransportControlsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn298977) to **true**. To disable them, set **AreTransportControlsEnabled** to **false**. The transport controls are represented by the [**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn831962) class. You can use the transport controls as-is, or customize them in various ways. For more info, see the [**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn831962) class reference and [Create custom transport controls](custom-transport-controls.md).

The transport controls let the user control most aspects of the [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926), but the **MediaElement** also provides numerous properties and methods that you can use to control audio and video playback. For more info, see the [Control MediaElement programmatically](#control_mediaelement_programmatically) section later in this article.

The transport controls support single- and double-row layouts. The first example here is a single-row layout, with the play/pause button located to the left of the media timeline. This layout is best reserved for compact screens. 

![Example of MTC controls on phone, single row](images/controls_mtc_singlerow_phone.png)

The double-row controls layout (below) is recommended for most usage scenarios, especially on larger screens. This layout provides more space for controls and makes the timeline easier for the user to operate.

![Example of MTC controls on phone, double row](images/controls_mtc_doublerow_phone.png)

**System media transport controls**

You can also integrate [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) with the system media transport controls. The system transport controls are the controls that pop up when hardware media keys are pressed, such as the media buttons on keyboards. If the user presses the pause key on a keyboard and your app supports the [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677), your app is notified and you can take the appropriate action. For more info, see [System Media Transport Controls](https://msdn.microsoft.com/library/windows/apps/mt228338).

### Set the media source
To play files on the network or files embedded with the app, set the [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) property to the path of the file.

**Tip**  To open files from the internet, you need to declare the **Internet (Client)** capability in your app's manifest (Package.appxmanifest). For more info about declaring capabilities, see [App capability declarations](https://msdn.microsoft.com/library/windows/apps/mt270968).

 

This code attempts to set the [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) property of the [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) defined in XAML to the path of a file entered into a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683).

```xaml
<TextBox x:Name="txtFilePath" Width="400" 
         FontSize="20"
         KeyUp="TxtFilePath_KeyUp"
         Header="File path"
         PlaceholderText="Enter file path"/>
```

```csharp
private void TxtFilePath_KeyUp(object sender, KeyRoutedEventArgs e)
{
    if (e.Key == Windows.System.VirtualKey.Enter)
    {
        TextBox tbPath = sender as TextBox;

        if (tbPath != null)
        {
            LoadMediaFromString(tbPath.Text);
        }
    }
}

private void LoadMediaFromString(string path)
{
    try
    {
        Uri pathUri = new Uri(path);
        mediaPlayer.Source = pathUri;
    }
    catch (Exception ex)
    {
        if (ex is FormatException)
        {
            // handle exception. 
            // For example: Log error or notify user problem with file
        }
    }
}
```

To set the media source to a media file embedded in the app, create a [**Uri**](https://msdn.microsoft.com/library/windows/apps/br226017) with the path prefixed with **ms-appx:///** and then set the [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) to it. For example, for a file called **video1.mp4** that is in a **Videos** subfolder, the path would look like: **ms-appx:///Videos/video1.mp4**

This code sets the [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) property of the [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) defined previously in XAML to **ms-appx:///Videos/video1.mp4**.

```csharp
private void LoadEmbeddedAppFile()
{
    try
    {
        Uri pathUri = new Uri("ms-appx:///Videos/video1.mp4");
        mediaPlayer.Source = pathUri;
    }
    catch (Exception ex)
    {
        if (ex is FormatException)
        {
            // handle exception. 
            // For example: Log error or notify user problem with file
        }
    }
}
```

### Open local media files
To open files on the local system or from OneDrive, you can use the [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) to get the file and [**SetSource**](https://msdn.microsoft.com/library/windows/apps/br244338) to set the media source, or you can programmatically access the user media folders.

If your app needs access without user interaction to the **Music** or **Video** folders, for example, if you are enumerating all the music or video files in the user's collection and displaying them in your app, then you need to declare the **Music Library** and **Video Library** capabilities. For more info, see [Files and folders in the Music, Pictures, and Videos libraries](https://msdn.microsoft.com/library/windows/apps/mt188703).

The [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) does not require special capabilities to access files on the local file system, such as the user's **Music** or **Video** folders, since the user has complete control over which file is being accessed. From a security and privacy standpoint, it is best to minimize the number of capabilities your app uses.

**To open local media using FileOpenPicker**

1.  Call [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) to let the user pick a media file.

    Use the [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) class to select a media file. Set the [**FileTypeFilter**](https://msdn.microsoft.com/library/windows/apps/br207850) to specify which file types the **FileOpenPicker** displays. Call [**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/jj635275) to launch the file picker and get the file.

2.  Call [**SetSource**](https://msdn.microsoft.com/library/windows/apps/br244338) to set the chosen media file as the [**MediaElement.Source**](https://msdn.microsoft.com/library/windows/apps/br227419).

    To set the [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) of the [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) to the [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) returned from the [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847), you need to open a stream. Call the [**OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn889851) method on the **StorageFile**, which returns a stream that you can pass into the [**MediaElement.SetSource**](https://msdn.microsoft.com/library/windows/apps/br244338) method. Then call [**Play**](https://msdn.microsoft.com/library/windows/apps/br227402) on the **MediaElement** to start the media.

This example shows how to use the [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) to choose a file and set the file as the [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) of a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926).

```xaml
<MediaElement x:Name="mediaPlayer"/>
...
<Button Content="Choose file" Click="Button_Click"/>
```

```csharp
private async void Button_Click(object sender, RoutedEventArgs e)
{
    await SetLocalMedia();
}

async private System.Threading.Tasks.Task SetLocalMedia()
{
    var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

    openPicker.FileTypeFilter.Add(".wmv");
    openPicker.FileTypeFilter.Add(".mp4");
    openPicker.FileTypeFilter.Add(".wma");
    openPicker.FileTypeFilter.Add(".mp3");

    var file = await openPicker.PickSingleFileAsync();
    
    // mediaPlayer is a MediaElement defined in XAML
    if (file != null)
    {
        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
        mediaPlayer.SetSource(stream, file.ContentType);

        mediaPlayer.Play();
    }
}
```

### Set the poster source
You can use the [**PosterSource**](https://msdn.microsoft.com/library/windows/apps/br227409) property to provide your [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) with a visual representation before the media is loaded. A **PosterSource** is an image, such as a screen shot or movie poster, that is displayed in place of the media. The **PosterSource** is displayed in the following situations:

-   When a valid source is not set. For example, [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) is not set, **Source** was set to **Null**, or the source is invalid (as is the case when a [**MediaFailed**](https://msdn.microsoft.com/library/windows/apps/br227393) event occurs).
-   While media is loading. For example, a valid source is set, but the [**MediaOpened**](https://msdn.microsoft.com/library/windows/apps/br227394) event has not occurred yet.
-   When media is streaming to another device.
-   When the media is audio only.

Here's a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) with its [**Source**](https://msdn.microsoft.com/library/windows/apps/br227419) set to an album track, and it's [**PosterSource**](https://msdn.microsoft.com/library/windows/apps/br227409) set to an image of the album cover.

```xaml
<MediaElement Source="Media/Track1.mp4" PosterSource="Media/AlbumCover.png"/> 
```

### Keep the device's screen active
Typically, a device dims the display (and eventually turns it off) to save battery life when the user is away, but video apps need to keep the screen on so the user can see the video. To prevent the display from being deactivated when user action is no longer detected, such as when an app is playing full-screen video, you can call [**DisplayRequest.RequestActive**](https://msdn.microsoft.com/library/windows/apps/br241818). The [**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816) class lets you tell Windows to keep the display turned on so the user can see the video.

To conserve power and battery life, you should call [**DisplayRequest.RequestRelease**](https://msdn.microsoft.com/library/windows/apps/br241819) to release the display request when it is no longer required. Windows automatically deactivates your app's active display requests when your app moves off screen, and re-activates them when your app comes back to the foreground.

Here are some situations when you should release the display request:

-   Video playback is paused, for example, by user action, buffering, or adjustment due to limited bandwidth.
-   Playback stops. For example, the video is done playing or the presentation is over.
-   A playback error has occurred. For example, network connectivity issues or a corrupted file.

**To keep the screen active**

1.  Create a global [**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816) variable. Initialize it to null.
```csharp
// Create this variable at a global scope. Set it to null.
private DisplayRequest appDisplayRequest = null;
```

2.  Call [**RequestActive**](https://msdn.microsoft.com/library/windows/apps/br241818) to notify Windows that the app requires the display to remain on.

3.  Call [**RequestRelease**](https://msdn.microsoft.com/library/windows/apps/br241819) to release the display request whenever video playback is stopped, paused, or interrupted by a playback error. When your app no longer has any active display requests, Windows saves battery life by dimming the display (and eventually turning it off) when the device is not being used.

    Here, you use the [**CurrentStateChanged**](https://msdn.microsoft.com/library/windows/apps/br227375) event to detect these situations. Then, use the [**IsAudioOnly**](https://msdn.microsoft.com/library/windows/apps/hh965334) property to determine whether an audio or video file is playing, and keep the screen active only if video is playing.
    ```xaml
<MediaElement Source="Media/video1.mp4"
              CurrentStateChanged="MediaElement_CurrentStateChanged"/>
    ```
 
    ```csharp
private void MediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
{
    MediaElement mediaElement = sender as MediaElement;
    if (mediaElement != null && mediaElement.IsAudioOnly == false)
    {
        if (mediaElement.CurrentState == Windows.UI.Xaml.Media.MediaElementState.Playing)
        {                
            if (appDisplayRequest == null)
            {
                // This call creates an instance of the DisplayRequest object. 
                appDisplayRequest = new DisplayRequest();
                appDisplayRequest.RequestActive();
            }
        }
        else // CurrentState is Buffering, Closed, Opening, Paused, or Stopped. 
        {
            if (appDisplayRequest != null)
            {
                // Deactivate the display request and set the var to null.
                appDisplayRequest.RequestRelease();
                appDisplayRequest = null;
            }
        }            
    }
} 
    ```

### Control the media player programmatically
[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) provides numerous properties, methods, and events for controlling audio and video playback. For a full listing of properties, methods, and events, see the [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) reference page.
    

### Select audio tracks in different languages

Use the [**AudioStreamIndex**](https://msdn.microsoft.com/library/windows/apps/br227358) property and the [**GetAudioStreamLanguage**](https://msdn.microsoft.com/library/windows/apps/br227384) method to change the audio to a different language track on a video. Videos can also contain multiple audio tracks in the same language, such as director commentaries on films. This example specifically shows how to switch between different languages, but you can modify this code to switch between any audio tracks.

**To select audio tracks in different languages**

1.  Get the audio tracks.

    To search for a track in a specific language, start by iterating through each audio track on the video. Use [**AudioStreamCount**](https://msdn.microsoft.com/library/windows/apps/br227356) as the max value for a **for** loop.

2.  Get the language of the audio track.

    Use the [**GetAudioStreamLanguage**](https://msdn.microsoft.com/library/windows/apps/br227384) method to get the language of the track. The language of the track is identified by a [language code](http://msdn.microsoft.com/library/ms533052(vs.85).aspx), such as **"en"** for English or **"ja"** for Japanese.

3.  Set the active audio track.

    When you find the track with the desired language, set the [**AudioStreamIndex**](https://msdn.microsoft.com/library/windows/apps/br227358) to the index of the track. Setting **AudioStreamIndex** to **null** selects the default audio track, which is defined by the content.

Here's some code that attempts to set the audio track to the specified language. It iterates through the audio tracks on a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) object and uses [**GetAudioStreamLanguage**](https://msdn.microsoft.com/library/windows/apps/br227384) to get the language of each track. If the desired language track exists, the [**AudioStreamIndex**](https://msdn.microsoft.com/library/windows/apps/br227358) is set to the index of that track.

```csharp
/// <summary>
/// Attemps to set the audio track of a video to a specific language
/// </summary>
/// <param name="lcid">The id of the language. For example, "en" or "ja"</param>
/// <returns>true if the track was set; otherwise, false.</returns>
private bool SetAudioLanguage(string lcid, MediaElement media)
{
    bool wasLanguageSet = false;

    for (int index = 0; index < media.AudioStreamCount; index++)
    {
        if (media.GetAudioStreamLanguage(index) == lcid)
        {
            media.AudioStreamIndex = index;
            wasLanguageSet = true;
        }
    }

    return wasLanguageSet;
}
```

### Enable full window video rendering

Set the [**IsFullWindow**](https://msdn.microsoft.com/library/windows/apps/dn298980) property to enable and disable full window rendering. When you programmatically set full window rendering in your app, you should always use **IsFullWindow** instead of doing it manually. **IsFullWindow** insures that system level optimizations are performed that improve performance and battery life. If full window rendering is not set up correctly, these optimizations may not be enabled.

Here is some code that creates an [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/dn279244) that toggles full window rendering.

```xaml
<AppBarButton Icon="FullScreen" 
              Label="Full Window"
              Click="FullWindow_Click"/>>
```

```csharp
private void FullWindow_Click(object sender, object e)
{
    mediaPlayer.IsFullWindow = !media.IsFullWindow;
}
```

### Resize and stretch video

Use the [**Stretch**](https://msdn.microsoft.com/library/windows/apps/br227422) property to change how the video content fills the container it's in. This resizes and stretches the video depending on the [**Stretch**](https://msdn.microsoft.com/library/windows/apps/br242968) value. The **Stretch** states are similar to picture size settings on many TV sets. You can hook this up to a button and allow the user to choose which setting they prefer.

-   [**None**](https://msdn.microsoft.com/library/windows/apps/br242968) displays the native resolution of the content in its original size.
-   [**Uniform**](https://msdn.microsoft.com/library/windows/apps/br242968) fills up as much of the space as possible while preserving the aspect ratio and the image content. This can result in horizontal or vertical black bars at the edges of the video. This is similar to wide-screen modes.
-   [**UniformToFill**](https://msdn.microsoft.com/library/windows/apps/br242968) fills up the entire space while preserving the aspect ratio. This can result in some of the image being cropped. This is similar to full-screen modes.
-   [**Fill**](https://msdn.microsoft.com/library/windows/apps/br242968) fills up the entire space, but does not preserve the aspect ratio. None of image is cropped, but stretching may occur. This is similar to stretch modes.

![Stretch enumeration values](images/Image_Stretch.jpg)
Here, an [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/dn279244) is used to cycle through the [**Stretch**](https://msdn.microsoft.com/library/windows/apps/br242968) options. A **switch** statement checks the current state of the [**Stretch**](https://msdn.microsoft.com/library/windows/apps/br227422) property and sets it to the next value in the **Stretch** enumeration. This lets the user cycle through the different stretch states.

```xaml
<AppBarButton Icon="Switch" 
              Label="Resize Video"
              Click="PictureSize_Click" />
```

```csharp
private void PictureSize_Click(object sender, RoutedEventArgs e)
{
    switch (mediaPlayer.Stretch)
    {
        case Stretch.Fill:
            mediaPlayer.Stretch = Stretch.None;
            break;
        case Stretch.None:
            mediaPlayer.Stretch = Stretch.Uniform;
            break;
        case Stretch.Uniform:
            mediaPlayer.Stretch = Stretch.UniformToFill;
            break;
        case Stretch.UniformToFill:
            mediaPlayer.Stretch = Stretch.Fill;
            break;
        default:
            break;
    }
}
```

### Enable low-latency playback

Set the [**RealTimePlayback**](https://msdn.microsoft.com/library/windows/apps/br227414) property to **true** on a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) to enable the media element to reduce the initial latency for playback. This is critical for two-way communications apps, and can be applicable to some gaming scenarios. Be aware that this mode is more resource intensive and less power-efficient.

This example creates a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) and sets [**RealTimePlayback**](https://msdn.microsoft.com/library/windows/apps/br227414) to **true**.

```xaml
<MediaElement x:Name="mediaPlayer" RealTimePlayback="True"/>
```

```csharp
MediaElement mediaPlayer = new MediaElement();
mediaPlayer.RealTimePlayback = true;
```
    
## Recommendations 

The media player comes in a dark theme and a light theme, but opt for the dark theme in most situations. The dark background provides better contrast, in particular for low-light conditions, and limits the control bar from interfering in the viewing experience.

Encourage a dedicated viewing experience by promoting full-screen mode over inline mode. The full-screen viewing experience is optimal, and options are restricted in the inline mode.

If you have the screen real estate, go with the double-row layout. It provides more space for controls than the compact single-row layout.

Add whatever custom options you need to the media player to provide the best experience for your app, but keep in mind the following:

-   Limit the customization of the default controls, which have been optimized for the media playback experience.
-   On phones and other mobile devices, the device chrome remains black, but on laptops and desktops, the device chrome inherits the user's theme color.
-   Try not to overload the control bar with too many options.
-   Don't shrink the media timeline below its default minimum size, which will severely limit its effectiveness.

\[This article contains information that is specific to Universal Windows Platform (UWP) apps and Windows 10. For Windows 8.1 guidance, please download the [Windows 8.1 guidelines PDF](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Related articles

- [Command design basics for UWP apps](https://msdn.microsoft.com/library/windows/apps/dn958433)
- [Content design basics for UWP apps](https://msdn.microsoft.com/library/windows/apps/dn958434)


<!--HONumber=Mar16_HO4-->


