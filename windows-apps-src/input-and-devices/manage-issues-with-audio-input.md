---
Xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxxxxx xxxx xxxxxx-xxxxxxxxxxx xxxxxxxx xxxxxx xx xxxxx-xxxxx xxxxxxx.
xxxxx: Xxxxxx xxxxxx xxxx xxxxx xxxxx
xx.xxxxxxx: YXYYXYYY-XYYX-YXXX-XXYY-XXXYYXYXXYYY
xxxxx: Xxxxxx xxxxx xxxxx xxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxx xxxxxx xxxx xxxxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653226)
-   [**XxxxxxxxxxxXxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653243)
-   [**XxxxxxXxxxxxxxxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631406)

Xxxxx xxx xx xxxxxx xxxxxx xxxx xxxxxx-xxxxxxxxxxx xxxxxxxx xxxxxx xx xxxxx-xxxxx xxxxxxx.


## <span id="Assess_audio-input_quality">
            </span>
            <span id="assess_audio-input_quality">
            </span>
            <span id="ASSESS_AUDIO-INPUT_QUALITY">
            </span>Xxxxxx xxxxx-xxxxx xxxxxxx


Xxxx xxxxxx xxxxxxxxxxx xx xxxxxx, xxx xxx [**XxxxxxxxxxxXxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653243) xxxxx xx xxxx xxxxxx xxxxxxxxxx xx xxxxxxxxx xxxxxxx xxx xx xxxx xxxxx xxxxxx xxxxx xx xxxxxxxxxxx xxxx xxxxxx xxxxx. Xxx xxxxx xxxxxxxx ([**XxxxxxXxxxxxxxxxxXxxxxxxXxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn631430)) xxxxxxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631431) xxxxxxxx, xxxxx xxxxxxxxx xxx xxxxxx xxxxxxxx xxxx xxx xxxxx xxxxx.

Xxxxxxxxxxx xxx xx xxxxxxxx xx xxx xxxx xxxxxxxxxx xxxxx, x xxxxx xxxxxxxxxx, xxx xxx xxxxxx xx xxxxx xx xxx xxxxxxx.

Xxxx, xx xxxxxxxxx x xxxxxx xxxxxxxxxx xxx xxxxx xxxxxxxxx xxx xxx [**XxxxxxxxxxxXxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653243) xxxxx.

```CSharp
private async void WeatherSearch_Click(object sender, RoutedEventArgs e)
{
    // Create an instance of SpeechRecognizer.
    var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

    // Listen for audio input issues.
    speechRecognizer.RecognitionQualityDegrading += speechRecognizer_RecognitionQualityDegrading;

    // Add a web search grammar to the recognizer.
    var webSearchGrammar = new Windows.Media.SpeechRecognition.SpeechRecognitionTopicConstraint(Windows.Media.SpeechRecognition.SpeechRecognitionScenario.WebSearch, "webSearch");


    speechRecognizer.UIOptions.AudiblePrompt = "Say what you want to search for...";
    speechRecognizer.UIOptions.ExampleText = @"Ex. &#39;weather for London&#39;";
    speechRecognizer.Constraints.Add(webSearchGrammar);

    // Compile the constraint.
    await speechRecognizer.CompileConstraintsAsync();

    // Start recognition.
    Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();
    //await speechRecognizer.RecognizeWithUIAsync();

    // Do something with the recognition result.
    var messageDialog = new Windows.UI.Popups.MessageDialog(speechRecognitionResult.Text, "Text spoken");
    await messageDialog.ShowAsync();
}
```

## <span id="Manage_the_speech-recognition_experience">
            </span>
            <span id="manage_the_speech-recognition_experience">
            </span>
            <span id="MANAGE_THE_SPEECH-RECOGNITION_EXPERIENCE">
            </span>Xxxxxx xxx xxxxxx-xxxxxxxxxxx xxxxxxxxxx


Xxx xxx xxxxxxxxxxx xxxxxxxx xx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631431) xxxxxxxx xx xxxx xxx xxxx xxxxxxx xxxxxxxxxx xxx xxxxxxxxxxx.

Xxxx, xx xxxxxx x xxxxxxx xxx xxx [**XxxxxxxxxxxXxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653243) xxxxx xxxx xxxxxx xxx x xxx xxxxxx xxxxx. Xx xxxx xxx x [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298152) xxxxxx xx xxxxxxx xxxx xxx xxxx xxx xxxxxxxx xxxxxx.

```CSharp
private async void speechRecognizer_RecognitionQualityDegrading(
    Windows.Media.SpeechRecognition.SpeechRecognizer sender,
    Windows.Media.SpeechRecognition.SpeechRecognitionQualityDegradingEventArgs args)
{
    // Create an instance of a speech synthesis engine (voice).
    var speechSynthesizer =
        new Windows.Media.SpeechSynthesis.SpeechSynthesizer();

    // If input speech is too quiet, prompt the user to speak louder.
    if (args.Problem == Windows.Media.SpeechRecognition.SpeechRecognitionAudioProblem.TooQuiet)
    {
        // Generate the audio stream from plain text.
        Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream;
        try
        {
            stream = await speechSynthesizer.SynthesizeTextToStreamAsync("Try speaking louder");
            stream.Seek(0);
        }
        catch (Exception)
        {
            stream = null;
        }

        // Send the stream to the MediaElement declared in XAML.
        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
        {
            this.media.SetSource(stream, stream.ContentType);
        });
    }
}
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


* [Xxxxxx xxxxxxxxxxxx](speech-interactions.md)

**Xxxxxxx**
* [Xxxxxx xxxxxxxxxxx xxx xxxxxx xxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




<!--HONumber=Mar16_HO1-->
