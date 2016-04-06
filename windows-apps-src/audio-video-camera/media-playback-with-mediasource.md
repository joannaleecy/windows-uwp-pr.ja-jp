---
ms.assetid: C5623861-6280-4352-8F22-80EB009D662C
description: The MediaSource class provides a common way to reference and play back media from different sources such as local or remote files and exposes a common model for accessing media data, regardless of the underlying media format.
title: Media playback with MediaSource
---

# Media playback with MediaSource

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


\[Some information relates to pre-released product which may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.\]

The [**MediaSource**](https://msdn.microsoft.com/library/windows/apps/dn930905) class provides a common way to reference and play back media from different sources such as local or remote files and exposes a common model for accessing media data, regardless of the underlying media format. The [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/dn930939) class extends the functionality of **MediaSource**, allowing you to manage and select from multiple audio, video, and metadata tracks contained in a media item. [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955) allows you to create playback lists from one or more media playback items.

The code in this article was adapted from the [Video Playback SDK](http://go.microsoft.com/fwlink/p/?LinkId=620020&clcid=0x409) sample. You can download this sample to see the code used in context or to use as a starting point for your own app.

## Create and play a MediaSource

Create a new instance of **MediaSource** by calling one of the factory methods exposed by the class:

-   [**CreateFromAdaptiveMediaSource**](https://msdn.microsoft.com/library/windows/apps/dn930906)
-   [**CreateFromIMediaSource**](https://msdn.microsoft.com/library/windows/apps/dn965527)
-   [**CreateFromMediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn930907)
-   [**CreateFromMseStreamSource**](https://msdn.microsoft.com/library/windows/apps/dn930908)
-   [**CreateFromStorageFile**](https://msdn.microsoft.com/library/windows/apps/dn930909)
-   [**CreateFromStream**](https://msdn.microsoft.com/library/windows/apps/dn930910)
-   [**CreateFromStreamReference**](https://msdn.microsoft.com/library/windows/apps/dn930911)
-   [**CreateFromUri**](https://msdn.microsoft.com/library/windows/apps/dn930912)

After creating a **MediaSource** you can play the source directly with a [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926), by calling [**SetPlaybackSource**](https://msdn.microsoft.com/library/windows/apps/dn899085), or with a [**MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/dn652535), by setting the [**Source**](https://msdn.microsoft.com/library/windows/apps/dn987010) property. The following example shows how to play back a user-selected media file in a **MediaElement** using **MediaSource**.

You will need to include the [**Windows.Media.Core**](https://msdn.microsoft.com/library/windows/apps/dn278962) and [**Windows.Media.Playback**](https://msdn.microsoft.com/library/windows/apps/dn640562) namespaces in order to complete this scenario.

[!code-cs[Using](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetUsing)]

Declare a variable of type **MediaSource**. For the examples in this article, the media source is declared as a class member so that it can be accessed from multiple locations.

[!code-cs[DeclareMediaSource](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetDeclareMediaSource)]

To allow the user to pick a media file to play, use a [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847). With the [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object returned from the picker's [**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/jj635275) method, initialize a new MediaObject by calling [**MediaSource.CreateFromStorageFile**](https://msdn.microsoft.com/library/windows/apps/dn930909). Finally, set the media source as the playback source for the **MediaElement** by calling the [**SetPlaybackSource**](https://msdn.microsoft.com/library/windows/apps/dn899085) method.

[!code-cs[PlayMediaSource](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetPlayMediaSource)]

## Handle multiple audio, video, and metadata tracks with MediaPlaybackItem

Using a [**MediaSource**](https://msdn.microsoft.com/library/windows/apps/dn930905) for playback is convenient because it provides a common way to playback media from different kinds of sources, but more advanced behavior can be accessed by using a [**MediaPlaybackItem**](https://msdn.microsoft.com/library/windows/apps/dn930939). This includes the ability to access and manage multiple audio, video, and data tracks for a media item.

Declare a variable to store your **MediaPlaybackItem**.

[!code-cs[DeclareMediaPlaybackItem](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetDeclareMediaPlaybackItem)]

Create a **MediaPlaybackItem** by calling the constructor and passing in an initialized **MediaSource** object.

If your app supports multiple audio, video, or data tracks in a media playback item, register event handlers for the [**AudioTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930948), [**VideoTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930954), or [**TimedMetadataTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930952) events.

Finally, set the playback source of the **MediaElement** or **MediaPlayer** to your **MediaPlaybackItem**.

[!code-cs[PlayMediaPlaybackItem](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetPlayMediaPlaybackItem)]

**Note**  
A **MediaSource** can only be associated with a single **MediaPlaybackItem**. After creating a **MediaPlaybackItem** from a source, attempting to create another playback item from the same source will result in an error. Also, after creating a **MediaPlaybackItem** from a media source, you can't set the **MediaSource** object directly as the source for a **MediaElement** or **MediaPlayer** but should instead use the **MediaPlaybackItem**.

The [**VideoTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930954) event is raised after a **MediaPlaybackItem** containing multiple video tracks is assigned as a playback source, and can be raised again if the list of video tracks changes for the item changes. The handler for this event gives you the opportunity to update your UI to allow the user to switch between available tracks. This example uses a [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/br209348) to display the available video tracks.

[!code-xml[VideoComboBox](./code/MediaSource_Win10/cs/MainPage.xaml#SnippetVideoComboBox)]

In the **VideoTracksChanged** handler, loop through all of the tracks in the playback item's [**VideoTracks**](https://msdn.microsoft.com/library/windows/apps/dn930953) list. For each track, a new [**ComboBoxItem**](https://msdn.microsoft.com/library/windows/apps/br209349) is created. If the track does not already have a label, a label is generated from the track index. The [**Tag**](https://msdn.microsoft.com/library/windows/apps/br208745) property of the combo box item is set to the track index so that it can be identified later. Finally, the item is added to the combo box. Note that these operations are performed within a [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) call because all UI changes must be made on the UI thread and this event is raised on a different thread.

[!code-cs[VideoTracksChanged](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetVideoTracksChanged)]

In the [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/br209776) handler for the combo box, the track index is retrieved from the selected item's **Tag** property. Setting the [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/dn956634) property of the media playback item's [**VideoTracks**](https://msdn.microsoft.com/library/windows/apps/dn930953) list causes the **MediaElement** or **MediaPlayer** to switch the active video track to the specified index.

[!code-cs[VideoTracksSelectionChanged](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetVideoTracksSelectionChanged)]

Managing media items with multiple audio tracks works exactly the same as with video tracks. Handle the [**AudioTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930948) to update your UI with the audio tracks found in the playback item's [**AudioTracks**](https://msdn.microsoft.com/library/windows/apps/dn930947) list. When the user selects an audio track, set the [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/dn930937) property of the **AudioTracks** list to cause the **MediaElement** or **MediaPlayer** to switch the active audio track to the specified index.

[!code-xml[AudioComboBox](./code/MediaSource_Win10/cs/MainPage.xaml#SnippetAudioComboBox)]

[!code-cs[AudioTracksChanged](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetAudioTracksChanged)]

[!code-cs[AudioTracksSelectionChanged](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetAudioTracksSelectionChanged)]

In addition to audio and video, a **MediaPlaybackItem** object may contain zero or more [**TimedMetadataTrack**](https://msdn.microsoft.com/library/windows/apps/dn956580) objects. A timed metadata track can contain subtitle or caption text, or it may contain custom data that is proprietary to your app. A timed metadata track contains a list of cues represented by objects that inherit from [**IMediaCue**](https://msdn.microsoft.com/library/windows/apps/dn930899), such as a [**DataCue**](https://msdn.microsoft.com/library/windows/apps/dn930892) or a [**TimedTextCue**](https://msdn.microsoft.com/library/windows/apps/dn956655). Each cue has a start time and a duration that determines when the cue is activated and for how long.

Similar to audio tracks and video tracks, the timed metadata tracks for a media item can be discovered by handling the [**TimedMetadataTracksChanged**](https://msdn.microsoft.com/library/windows/apps/dn930952) event of a **MediaPlaybackItem**. With timed metadata tracks, however, the user may want to enable more than one metadata track at a time. Also, depending on your app scenario, you may want to enable or disable metadata tracks automatically, without user intervention. For illustration purposes, this example adds a [**ToggleButton**](https://msdn.microsoft.com/library/windows/apps/br209795) for each metadata track in a media item to allow the user to enable and disable the track. The **Tag** property of each button is set to the index of the associated metadata track so that it can be identified when the button is toggled.

[!code-xml[MetaStackPanel](./code/MediaSource_Win10/cs/MainPage.xaml#SnippetMetaStackPanel)]

[!code-cs[TimedMetadataTrackschanged](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetTimedMetadataTrackschanged)]

Because more than one metadata track can be active at a time, you don't simply set the active index for the metadata track list. Instead, call the **MediaPlaybackItem** object's [**SetPresentationMode**](https://msdn.microsoft.com/library/windows/apps/dn986977) method, passing in the index of the track you want to toggle, and then providing a value from the [**TimedMetadataTrackPresentationMode**](https://msdn.microsoft.com/library/windows/apps/dn987016) enumeration. The presentation mode you choose depends on the implementation of your app. In this example, the metadata track is set to **PlatformPresented** when enabled. For text-based tracks, this means that the system will automatically display the text cues in the track. When the toggle button is toggled off, the presentation mode is set to **Disabled**, which means that no text is displayed and no cue events are raised. Cue events are discussed later in this article.

[!code-cs[ToggleChecked](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetToggleChecked)]

[!code-cs[ToggleUnchecked](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetToggleUnchecked)]

## Add external timed text with TimedTextSource

For some scenarios, you may have external files that contains timed text associated with a media item, such as separate files that contain subtitles for different locales. Use the [**TimedTextSource**](https://msdn.microsoft.com/library/windows/apps/dn956679) class to load in external timed text files from a stream or URI.

This example uses a **Dictionary** collection to store a list of the timed text sources for the media item using the source URI and the **TimedTextSource** object as the key/value pair in order to identify the tracks after they have been resolved.

[!code-cs[TimedTextSourceMap](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetTimedTextSourceMap)]

Create a new **TimedTextSource** for each external timed text file by calling [**CreateFromUri**](https://msdn.microsoft.com/library/windows/apps/dn708190). Add an entry to the **Dictionary** for the timed text source. Add a handler for the [**TimedTextSource.Resolved**](https://msdn.microsoft.com/library/windows/apps/dn965540) event to handle if the item failed to load or to set additional properties after the item was loaded successfully.

Register all of your **TimedTextSource** objects with the **MediaSource** by adding them to the [**ExternalTimedTextSources**](https://msdn.microsoft.com/library/windows/apps/dn930916) collection. Note that external timed text sources are added to directly the **MediaSource** and not the **MediaPlaybackItem** created from the source. To update your UI to reflect the external text tracks, register and handle the **TimedMetadataTracksChanged** event as described previously in this article.

[!code-cs[TimedTextSource](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetTimedTextSource)]

In the handler for the [**TimedTextSource.Resolved**](https://msdn.microsoft.com/library/windows/apps/dn965540) event, check the **Error** property of the [**TimedTextSourceResolveResultEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn965537) passed into the handler to determine if an error occurred while trying to load the timed text data. If the item was resolved successfully, you can use this handler to update additional properties of the resolved track. This example adds a label for each track based on the URI previously stored in the **Dictionary**.

[!code-cs[TimedTextSourceResolved](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetTimedTextSourceResolved)]

## Add additional metadata tracks

You can dynamically create custom metadata tracks in code and associate them with a media source. The tracks you create can contain subtitle or caption text, or they can contain your proprietary app data.

Create a new [**TimedMetadataTrack**](https://msdn.microsoft.com/library/windows/apps/dn956580) by calling the constructor and specifying an ID, the language identifier, and a value from the [**TimedMetadataKind**](https://msdn.microsoft.com/library/windows/apps/dn956578) enumeration. Register handlers for the [**CueEntered**](https://msdn.microsoft.com/library/windows/apps/dn956583) and [**CueExited**](https://msdn.microsoft.com/library/windows/apps/dn956584) events. These events are raised when the start time for a cue has been reached and when the duration for a cue has expired, respectively.

Create a new cue object, appropriate for the type of metadata track you created, and set the ID, start time, and duration for the track. This example creates a data track, so a set of [**DataCue**](https://msdn.microsoft.com/library/windows/apps/dn930892) objects are generated and a buffer containing app-specific data is provided for each cue. To register the new track, add it to the [**ExternalTimedMetadataTracks**](https://msdn.microsoft.com/library/windows/apps/dn930915) collection of the **MediaSource** object.

[!code-cs[AddDataTrack](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetAddDataTrack)]

The **CueEntered** event is raised when a cue's start time has been reached as long as the associated track has a presentation mode of **ApplicationPresented**, **Hidden**, or **PlatformPresented.** Cue events are not raised for metadata tracks while the presentation mode for the track is **Disabled**. This example simply outputs the custom data associated with the cue to the debug window.

[!code-cs[DataCueEntered](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetDataCueEntered)]

This example adds a custom text track by specifying **TimedMetadataKind.Caption** when creating the track and using [**TimedTextCue**](https://msdn.microsoft.com/library/windows/apps/dn956655) objects to add cues to the track.

[!code-cs[AddTextTrack](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetAddTextTrack)]

[!code-cs[TextCueEntered](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetTextCueEntered)]

## Play a list of media items with MediaPlaybackList

The [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955) allows you to create a playlist of media items, which are represented by **MediaPlaybackItem** objects.

**Note**  Items in a [**MediaPlaybackList**](https://msdn.microsoft.com/library/windows/apps/dn930955) are rendered using gapless playback. The system will use provided metadata in MP3 or AAC encoded files to determine the delay or padding compensation needed for gapless playback. If the MP3 or AAC encoded files don't provide this metadata, then the system determines the delay or padding heuristically. For lossless formats, such as PCM, FLAC, or ALAC, the system takes no action because these encoders don't introduce delay or padding.

To get started, declare a variable to store your **MediaPlaybackList**.

[!code-cs[DeclareMediaPlaybackList](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetDeclareMediaPlaybackList)]

Create a **MediaPlaybackItem** for each media item you want to add to your list using the same procedure described previously in this article. Initialize your **MediaPlaybackList** object and add the media playback items to it. Register a handler for the [**CurrentItemChanged**](https://msdn.microsoft.com/library/windows/apps/dn930957) event. This event allows you to update your UI to reflect the currently playing media item. Finally, set the playback source of the **MediaElement** or **MediaPlayer** to your **MediaPlaybackList**.

[!code-cs[PlayMediaPlaybackList](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetPlayMediaPlaybackList)]

In the **CurrentItemChanged** event handler, update your UI to reflect the currently playing item, which can be retrieved using the [**NewItem**](https://msdn.microsoft.com/library/windows/apps/dn930930) property of the [**CurrentMediaPlaybackItemChangedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn930929) object passed into the event. Remember that if you update the UI from this event, you should do so within a call to [**CoreDispatcher.RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) so that the updates are made on the UI thread.

[!code-cs[MediaPlaybackListItemChanged](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetMediaPlaybackListItemChanged)]

Call [**MovePrevious**](https://msdn.microsoft.com/library/windows/apps/mt146455) or [**MoveNext**](https://msdn.microsoft.com/library/windows/apps/mt146454) to cause the media player to play the previous or next item in your **MediaPlaybackList**.

[!code-cs[PrevButton](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetPrevButton)]

[!code-cs[NextButton](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetNextButton)]

Set the [**ShuffleEnabled**](https://msdn.microsoft.com/library/windows/apps/mt146457) property to specify whether the media player should play the items in your list in random order.

[!code-cs[ShuffleButton](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetShuffleButton)]

Set the [**AutoRepeatEnabled**](https://msdn.microsoft.com/library/windows/apps/mt146452) property to specify whether the media player should loop playback of your list.

[!code-cs[RepeatButton](./code/MediaSource_Win10/cs/MainPage.xaml.cs#SnippetRepeatButton)]

 

 






<!--HONumber=Mar16_HO1-->


