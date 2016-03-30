---
Description: Xxxxxxxxxxx: Xxx xxxxxx xxxxxxxxxxx xx xxxxxxx xxxxx, xxxxxxx xx xxxxxx xx xxxxxxx, xxx xxxxxxxxxx xxxxx.
title: xxxxx: Xxxxxx xxxxxxxxxxx
ms.assetid: 553C0FB7-35BC-4894-9EF1-906139E17552
label: Speech recognition
template: detail.hbs
---

# xx.xxxxxxx: YYYXYXXY-YYXX-YYYY-YXXY-YYYYYYXYYYYY


xxxxx: Xxxxxx xxxxxxxxxxx xxxxxxxx: xxxxxx.xxx

Xxxxxx xxxxxxxxxxx

**\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY.**

-   [**Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]**](https://msdn.microsoft.com/library/windows/apps/dn653262)



Xxx xxxxxx xxxxxxxxxxx xx xxxxxxx xxxxx, xxxxxxx xx xxxxxx xx xxxxxxx, xxx xxxxxxxxxx xxxxx.


## Xxxxxxxxx XXXx


Xxxxxxx.Xxxxx.XxxxxxXxxxxxxxxxx

Xxxxxx xxxxxxxxxxx xx xxxx xx xx x xxxxxx xxxxxxx, xxxxxxxxxxx XXXx xxx xxxxxxxxxxx xxx xxxxxxx, xxxxx-xx-xxx xxxxxxxx xxx xxxxxxxxx xxx xxx xxxxxx, xxx x xxxxxxx xxxxxx XX xxxx xxxxx xxxxx xxxxxxxx xxx xxx xxxxxx xxxxxxxxxxx xxxxxxxx. <span id="Set_up_the_audio_feed">
            </span>
            <span id="set_up_the_audio_feed">
            </span>
            <span id="SET_UP_THE_AUDIO_FEED">
            </span>Xxx xx xxx xxxxx xxxx

Xxxxxx xxxx xxxx xxxxxx xxx x xxxxxxxxxx xx xxx xxxxxxxxxx.

## Xxx xxx **Xxxxxxxxxx** xxxxxx xxxxxxxxxx ([**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br211430)) xx xxx [Xxx xxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/br211474) (**xxxxxxx.xxxxxxxxxxxx** xxxx) xx xxx xxxxxx xx xxx xxxxxxxxxx’x xxxxx xxxx.


Xxxx xxxxxx xxx xxx xx xxxxxx xxxxx xxxx xxxxxxxxx xxxxxxxxxxx. Xxx [Xxx xxxxxxxxxx xxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt270968).

<span id="Recognize_speech_input">
            </span>
            <span id="recognize_speech_input">
            </span>
            <span id="RECOGNIZE_SPEECH_INPUT">
            </span>Xxxxxxxxx xxxxxx xxxxx

1.  X *xxxxxxxxxx* xxxxxxx xxx xxxxx xxx xxxxxxx (xxxxxxxxxx) xxxx xx xxx xxxxxxxxxx xx xxxxxx xxxxx.

    Xxxxxxxxxxx xxx xx xxx xxxx xx xxxxxx xxxxxxxxxxx xxx xxxx xxxx xxx xxxxx xxxx xxx xxxxxxxx xx xxxxxx xxxxxxxxxxx. Xxx xxx xxx xxxxxxx xxxxx xx xxxxxxxxxxx xxxx xxxxxxxxxx xxxxxx xxxxxxxxxxx:

    **Xxxxxxxxxx xxxxxxxx** ([**XxxxxxXxxxxxxxxxxXxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631446)). Xxxxxxxxxx xxxxxxxxx xxx xxx-xxxxxx xxxxxxxx xxxxxxx xxxxxx xxxxxxxxxxx xxx xxxx xxx xxxxxxx xxxxxxxxx xxx xx xxxxxx x xxxxxxx. Xxxx xxxxx xxxxx xxxxxxxx, xxxxxx xxxxxxxxxxx xx xxxxxxxxx xx x xxxxxx xxx xxxxxxx xxx xxx xxxxxxx xxx xxxxxxxx xx xxx xxxxxx. Xxx xxxxxxx xxxx-xxxx xxxxxxxxx xxxxxxx xxx xxxxxxxxx xxxx xxxxx xxx xxxxxxx xxxx x xxxx xxx xxx xx x xxxxxxxxxx xxxxxxxx, xxx xx xxxxxxxxx xx xxxxxxxxx xxxxx xxxxxxx.

    Xxx xxxxxxxxxx xxxxxxxxx xxxxxxx xx xxxx xx xxx xxx'x xxxxxxx xxx xxxxxxxxxxx xxx xxxx [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653226) xxxxxx. Xxxx-xxxx xxxxxxxxx xx xxxxxx xxxx xxx xxx'x xxxx xx xxxxx xxx xxxxx xx xxxxxx x xxxx xxx xxx.

    Xxxxxxx xxxx xxxxxxx xxxxxxxx xxxxx xx xxxxxxxxx xxx xxxxxxx xxx x xxxxxxx.

     

    These predefined grammars can be used to recognize up to 10 seconds of speech input and require no authoring effort on your part. However, they do require a connection to a network.

    To use web-service constraints, speech input and dictation support must be enabled in **Settings** by turning on the "Get to know me" option in the Settings -&gt; Privacy -&gt; Speech, inking, and typing page.

    Here, we show how to test whether speech input is enabled and open the Settings -&gt; Privacy -&gt; Speech, inking, and typing page, if not.

    First, we initialize a global variable (HResultPrivacyStatementDeclined) to the HResult value of 0x80045509. See [Exception handling for in C\# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/dn532194).

```    CSharp
private static uint HResultPrivacyStatementDeclined = 0x80045509;</code></pre></td>
    </tr>
    </tbody>
    </table>
```

    We then catch any standard exceptions during recogntion and test if the [**HResult**](https://msdn.microsoft.com/library/windows/apps/br206579) value is equal to the value of the HResultPrivacyStatementDeclined variable. If so, we display a warning and call `await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts"));` to open the Settings page.

    <span codelanguage="CSharp"></span>
```    CSharp
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">C#</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
catch (Exception exception)
    {
      // Handle the speech privacy policy error.
      if ((uint)exception.HResult == HResultPrivacyStatementDeclined)
      {
        resultTextBlock.Visibility = Visibility.Visible;
        resultTextBlock.Text = "The privacy statement was declined. 
          Go to Settings -> Privacy -> Speech, inking and typing, and ensure you 
          have viewed the privacy policy, and &#39;Get To Know You&#39; is enabled.";
        // Open the privacy/speech, inking, and typing settings page.
        await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts")); 
      }
      else
      {
        var messageDialog = new Windows.UI.Popups.MessageDialog(exception.Message, "Exception");
        await messageDialog.ShowAsync();
      }
    }
```

2.  Xxx xxx-xxxxxx xxxxxxx, xxxx x xxxxxxxxx xxxxxxx, xxxxxxxx x xxxxx xxxxxx xx xxxxx xxx xxxxxxx xxxx x xxxx xxxxx xxx.

    Xxxxxxx, xx xx xxxxxxxxx xx xxxxxxxxx xxxxx xxxx xxxxxx xxxxxxxxx xxx xxxx xxxxxxxxx xxx xxx. **Xxxx**  Xxxxxxx xxxxxxxxxx xxxxxxxxx xxx xxx-xxxxxx xxxxxxxx xxx xx xxxxx, xxx xxxxxxx xxxx xxx xxxxxx (xxx xx xxx xxxxxx), xxxxxxxxxxx xxxxx xxx xx xx xxxx xx xxxx x xxxxxx xxxxxxx xxxxxxxxx xx xxx xxxxxx. **Xxxxxxxxxxxx xxxx xxxxxxxxxxx** ([**XxxxxxXxxxxxxxxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631421)). Xxxxxxxxxxxx xxxx xxxxxxxxxxx xxxxxxx x xxxxxxxxxxx xxxxxxxx xx xxxxxxxx xxxxxx xxxxxxxx xxxxx x xxxx xx xxxxx xx xxxxxxx.

    X xxxx xxxxxxxxxx xxxxx xxxx xxx xxxxxxxxxxx xxxxx, xxxxxxxx xxxxxxx. Xxxxxxxxxx xxxxxxxxxx xxx xxxxx xx x xxxxxxx xxxx xxxxxxxx xxxxxxxxxxx xxxxxxxx, xx xxx xxxxxx xxxxxxxxxxx xxxxxx xxxx xxxx xxxxxxx xxxxxx xx xxxxxxx x xxxxx. Xxx xxxx xxx xxxx xx xxxxxxxxxxxxxxxx xxxxxxx. X xxxx xxxxxxxxxx xxxxxxxx xx xx xxxxx xx xxxxxxx xxxx xxxxxxxxxx xxxxxx xxxxx xxxx xxxx xxx xxxx xxxxxx xxx x xxxxxxxxxxx xxxxxxxxx.

3.  Xxx xxx xxxxxx x xxxx xxxxxxxxxx xx xxxx xxx xx xxxxxxxx x xxxxxx-xxxxxxxxxxx xxxx-xxxxxxxxxx xxxxxx xxx xxxxxxx xx xxxxx xx xxxxxxx.

    Xxxx, xxx xxxx xxxxxx xx xxx xxxxxxxxxxx xxxxxxxxxx xx xxx xxxxxxxxxx. Xxxxxxxxxxx xx xxxxxxxxxx xxxx xxx xxxxxx xxxxxxxxxx xxxxxxxxxx xxx xxx xx xxx xxxxxxx xx xxx xxxxx.

4.  **XXXX xxxxxxxx** ([**XxxxxxXxxxxxxxxxxXxxxxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631412)).

    Xx Xxxxxx Xxxxxxxxxxx Xxxxxxx Xxxxxxxxxxxxx (XXXX) xxxxxxx xx x xxxxxx xxxxxxxx xxxx, xxxxxx x xxxxxxxxxxxx xxxx xxxxxxxxxx, xxxx xxx XXX xxxxxx xxxxxxx xx xxx [XXXX Xxxxxxx Y.Y](http://go.microsoft.com/fwlink/p/?LinkID=262302). Xx XXXX xxxxxxx xxxxxxxx xxx xxxxxxxx xxxxxxx xxxx xxx xxxxxx xxxxxxxxxxx xxxxxxxxxx xx xxxxxxx xxx xxxxxxx xxxxxxxx xxxxxxxx xxxxxxxx xx x xxxxxx xxxxxxxxxxx.

**Xxxxx xxxxxxx xxxxxxxxxxx** ([**XxxxxxXxxxxxxxxxxXxxxxXxxxxxxXxxxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653220)) Xxx x Xxxxx Xxxxxxx Xxxxxxxxxx (XXX) XXX xxxx xx xxxxxx xxx xxxxxxxx xxxx xxx xxxx xxx xxx xx xxxxxxxx xxxxxxx xxxx xxxxxxxxxx xxxx xxx.
Xxx xxxx xxxxxx, xxx [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-foreground-app-with-voice-commands-in-cortana.md).

 

**Xxxx**  Xxxxx xxxx xx xxxxxxxxxx xxxx xxx xxx xxxxxxx xx xxx xxxxxxxxxx xx xxx xxxxxxxxxxx xxxxxxxxxx xxx xxxx xx xxxxxx. Xxx xxxxx xx xxx xxxx xxxxxx xxx x xxxxxxxx xxxxxxxxxxx xxxx, xxx xxx xxxxx xxxx xxxx xxx xxx xxxxx xx xxxxxxxxxxx xx xxxx xxx.

Xx xxx xxxxxxx xxxx xxxxxxxxxxx, xxx [Xxxxxx xxxxxx xxxxxxxxxxx xxxxxxxxxxx](define-custom-recognition-constraints.md).

-   Xxx xxxxxxxxxx Xxxxxxxxx Xxxxxxx xxx xxxxxxxxx xxxxxxx xxxxxxxxxx xxxx xxxxx xxx xxxxx xxxxxxx xx x xxxxxxxx.
-   Xx xx xxxxxxxxx xx xxxxxxx xxxx x xxxxxx xxxxxxxxxx xxxxxx xx xxxxxxxxxxxx xxxxxxx xxxxxx xxxxxxxxxxx.
-   Xx xxxx xxxxxxx, xx xxxx xxx xx: Xxxxxx x xxxxxx xxxxxxxxxx.

```CSharp
private async void StartRecognizing_Click(object sender, RoutedEventArgs e)
{
    // Create an instance of SpeechRecognizer.
    var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

    // Compile the dictation grammar by default.
    await speechRecognizer.CompileConstraintsAsync();

    // Start recognition.
    Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();

    // Do something with the recognition result.
    var messageDialog = new Windows.UI.Popups.MessageDialog(speechRecognitionResult.Text, "Text spoken");
    await messageDialog.ShowAsync();
}
```

## Xxxxxxx xxx xxxxxxx Xxxxxxxxx Xxxxxxx xxx xxxxxxxxxxx (xx xxxxxxxx xxxx xxxx xxxxx xx xxx xxxxxx xxxxxxxxxx'x xxxxxxx xxx).


Xxxxx xxxxxxxxx xxx xxxxxx xx xxxxx xxx xxxxx xxxxxxxxxxx XX xxx XXX xxxxxxxx xxxxxxxx xx xxx [**XxxxxxxxxXxxxXXXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653245) xxxxxx.

Xxx xxx [**XxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653244) xxxxxx xx xxx xxxxxxx XX xx xxx xxxxxxxx.

-   <span id="Customize_the_recognition_UI">
            </span>
            <span id="customize_the_recognition_ui">
            </span>
            <span id="CUSTOMIZE_THE_RECOGNITION_UI">
            </span>Xxxxxxxxx xxx xxxxxxxxxxx XX
-   Xxxx xxxx xxx xxxxxxxx xxxxxx xxxxxxxxxxx xx xxxxxxx [**XxxxxxXxxxxxxxxx.XxxxxxxxxXxxxXXXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653245), xxxxxxx xxxxxxx xxx xxxxx xx xxx xxxxxxxxx xxxxx.
-   Xx xxx'xx xxxxx x xxxxxxxxxx xxxxx xx x xxxxxxxxxx xxxxxxx (xxxxxxxxx xx xxx xxxxxx):

Xxx **Xxxxxxxxx** xxxxxx.

-   Xxx **Xxxxxxxx** xxxxxx.
-   Xxx **Xxxxx xxx xxx** xxxxxx xx xxx xxxxx xxxxxx.
-   Xx xxx'xx xxxxx x xxxxxxxxxx xxxxx xx x xxxx xx xxxxx xx xxxxxxx, xx x xxxxxxxxxx xxxxx xx x XXXX xxxxxxx xxxx:

Xxx **Xxxxxxxxx** xxxxxx. Xxx **Xxx xxx xxx** xxxxxx, xx xxxx xxx xxxx xxxx xxxxx xx xxxxxxxxxxx xx xxxx xxxx xxx xxxxxxxxx xxxxxx.

![Xxx **Xxxxx xxx xxx** xxxxxx xx xxx xxxxx xxxxxx.](images/speech-listening-initial.png)

![Xxx xxxxxxxxx xxxxx xxxxx xx xxxxxxx xx xxx xxxx xxxxxxx xxxxxxx xxx x xxxxxx xxxxxxxxxx xxxx xxxx x xxxxxxxxxx xxxxx xx x XXXX xxxxxxx xxxx.](images/speech-listening-intermediate.png)

![Xx xxxx xxxxxxx, xxxxxx xxxxxxxxxxx xxx xxxxxxxxxx.](images/speech-listening-complete.png)

xxxxxxx xxxxxxxxxxx xxxxxx xxx x xxxxxxxxxx xxxxx xx x xxxx xxxxxxx xxxx xxxxxxxxxxxx xxxxxxxxxxx xxxxxx xxx x xxxxxxxxxx xxxxx xx x xxxx xxxxxxx xxxx

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

## xxxxx xxxxxxxxxxx xxxxxx xxx x xxxxxxxxxx xxxxx xx x xxxx xxxxxxx xxxx


**Xxx **Xxxxxxxxx** xxxxxx xxx xxxxxxx xxxxxxxx xx xxxxx xx xxxxxxx xxxx xxx xxx xxx xxxxxxxxx.**
* [Xxxx, xx xxxx xxx xx xxx xxx xxxxxxxxxx xx xxx [**XxxxxxXxxxxxxxxxXXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653234) xxxxx (xxxxxxxx xx xxxxxxx xxx [**XxxxxxXxxxxxxxxx.XXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653254) xxxxxxxx) xx xxxxxxxxx xxxxxxx xx xxx **Xxxxxxxxx** xxxxxx.](speech-interactions.md)
**<span id="related_topics">
            </span>Xxxxxxx xxxxxxxx**
* [Xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn596121)
**[Xxxxxx xxxxxxxxxxxx](speech-interactions.md)**
* [**Xxxxxxxxx**](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




<!--HONumber=Mar16_HO4-->
