using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.Pickers;


//<SnippetNamespace>
using Windows.Media;
using Windows.UI.Xaml.Media;

//</SnippetNamespace>

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SMTCWin10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // <SnippetSystemMediaTransportControlsSetup>
        SystemMediaTransportControls systemMediaControls;

        public MainPage()
        {
            this.InitializeComponent();

            // Hook up app to system transport controls.
            systemMediaControls = SystemMediaTransportControls.GetForCurrentView();
            systemMediaControls.ButtonPressed += SystemControls_ButtonPressed;

            // Register to handle the following system transpot control buttons.
            systemMediaControls.IsPlayEnabled = true;
            systemMediaControls.IsPauseEnabled = true;
        }
        // </SnippetSystemMediaTransportControlsSetup>

        //<SnippetOpenMediaFile>
        StorageFile currentMediaFile;
        private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            filePicker.FileTypeFilter.Add(".mp3");
            filePicker.FileTypeFilter.Add(".wav");
            filePicker.FileTypeFilter.Add(".wma");
            filePicker.FileTypeFilter.Add(".m4a");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            currentMediaFile = await filePicker.PickSingleFileAsync();

            if (null != currentMediaFile)
            {
                var stream = await currentMediaFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                mediaElement.SetSource(stream, currentMediaFile.ContentType);
                mediaElement.Play();
            }
        }
        //</SnippetOpenMediaFile>

        // <SnippetSystemMediaTransportControlsStateChange>
        void MediaElement_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            switch (mediaElement.CurrentState)
            {
                case MediaElementState.Playing:
                    systemMediaControls.PlaybackStatus = MediaPlaybackStatus.Playing;
                    break;
                case MediaElementState.Paused:
                    systemMediaControls.PlaybackStatus = MediaPlaybackStatus.Paused;
                    break;
                case MediaElementState.Stopped:
                    systemMediaControls.PlaybackStatus = MediaPlaybackStatus.Stopped;
                    break;
                case MediaElementState.Closed:
                    systemMediaControls.PlaybackStatus = MediaPlaybackStatus.Closed;
                    break;
                default:
                    break;
            }
        }
        // </SnippetSystemMediaTransportControlsStateChange>

        // <SnippetSystemMediaTransportControlsButtonPressed>
        async void SystemControls_ButtonPressed(SystemMediaTransportControls sender,
            SystemMediaTransportControlsButtonPressedEventArgs args)
        {
            switch (args.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        mediaElement.Play();
                    });
                    break;
                case SystemMediaTransportControlsButton.Pause:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        mediaElement.Pause();
                    });
                    break;
                default:
                    break;
            }
        }

        // </SnippetSystemMediaTransportControlsButtonPressed>
        // <SnippetSystemMediaTransportControlsUpdater>
        async void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            // Get the updater.
            SystemMediaTransportControlsDisplayUpdater updater = systemMediaControls.DisplayUpdater;

            await updater.CopyFromFileAsync(MediaPlaybackType.Music, currentMediaFile);

            // Update the system media transport controls
            updater.Update();
        }
        // </SnippetSystemMediaTransportControlsUpdater>

       
        void UpdateSongInfoManually()
        {
            // <SnippetSystemMediaTransportControlsUpdaterManual>

            // Get the updater.
            SystemMediaTransportControlsDisplayUpdater updater = systemMediaControls.DisplayUpdater;

            // Music metadata.
            updater.MusicProperties.AlbumArtist = "artist";
            updater.MusicProperties.AlbumArtist = "album artist";
            updater.MusicProperties.Title = "song title";

            // Set the album art thumbnail.
            // RandomAccessStreamReference is defined in Windows.Storage.Streams
            updater.Thumbnail =
               RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Music/music1_AlbumArt.jpg"));

            // Update the system media transport controls.
            updater.Update();
            // </SnippetSystemMediaTransportControlsUpdaterManual>
        }


        void UpdateTimelineProperties()
        {
            //<SnippetUpdateTimelineProperties>
            // Create our timeline properties object 
            var timelineProperties = new SystemMediaTransportControlsTimelineProperties();

            // Fill in the data, using the media elements properties 
            timelineProperties.StartTime = TimeSpan.FromSeconds(0);
            timelineProperties.MinSeekTime = TimeSpan.FromSeconds(0);
            timelineProperties.Position = mediaElement.Position;
            timelineProperties.MaxSeekTime = mediaElement.NaturalDuration.TimeSpan;
            timelineProperties.EndTime = mediaElement.NaturalDuration.TimeSpan;

            // Update the System Media transport Controls 
            systemMediaControls.UpdateTimelineProperties(timelineProperties);
            //</SnippetUpdateTimelineProperties>
        }

        public void RegisterPlaybackChangedHandler()
        {
            //<SnippetRegisterPlaybackChangedHandler>
            systemMediaControls.PlaybackRateChangeRequested += SystemControls_PlaybackRateChangeRequested;
            //</SnippetRegisterPlaybackChangedHandler>
        }
        //<SnippetPlaybackChangedHandler>
        void systemControls_PlaybackRateChangeRequested(SystemMediaTransportControls sender, PlaybackRateChangeRequestedEventArgs args)
        {
            // Check the requested value to make sure it is within a valid and expected range
            if (args.RequestedPlaybackRate >= 0 && args.RequestedPlaybackRate <= 2)
            {
                // Set the requested value on the MediaElement
                mediaElement.PlaybackRate = args.RequestedPlaybackRate;

                // Update the system media controls to reflect the new value
                systemMediaControls.PlaybackRate = mediaElement.PlaybackRate;
            }
        }
        //</SnippetPlaybackChangedHandler>
    }
}
