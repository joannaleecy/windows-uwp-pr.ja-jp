---
Xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx xxx xxxxxx xxxxxxxxxxx xxx xxxxxx xxxxxxxxxxx.
xxxxx: Xxxxxx xxxxxx xxxxxxxxxxx xxxxxxxxxxx
xx.xxxxxxx: YYYYYXXY-YXXY-YYXY-XYYY-XYYYXXYYXYXX
xxxxx: Xxxxxx xxxxxx xxxxxxxxxxx xxxxxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxx xxxxxx xxxxxxxxxxx xxxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxx xx xxxxxx xxx xxx xxxxxx xxxxxxxxxxx xxx xxxxxx xxxxxxxxxxx.

**Xxxxxxxxx XXXx**

-   [**XxxxxxXxxxxxxxxxxXxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631446)
-   [**XxxxxxXxxxxxxxxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631421)
-   [**XxxxxxXxxxxxxxxxxXxxxxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631412)


Xxxxxx xxxxxxxxxxx xxxxxxxx xx xxxxx xxx xxxxxxxxxx xx xxxxxx x xxxxxxxxxxxx xxxxxxxxxx. Xx xx xxxxxxxxxx xx xxxxxxxxx, xxx xxxxxxxxxx xxxxxxxxx xxxxxxx xx Xxxxxxxxx Xxxxxxx xxxx xx xxxx. Xxx [Xxxxxx xxxxxxxxxxx](speech-recognition.md).


## <span id="Add_constraints">
            </span>
            <span id="add_constraints">
            </span>
            <span id="ADD_CONSTRAINTS">
            </span>Xxx xxxxxxxxxxx


Xxx xxx [**XxxxxxXxxxxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653241) xxxxxxxx xx xxx xxxxxxxxxxx xx x xxxxxx xxxxxxxxxx.

Xxxx, xx xxxxx xxx xxxxx xxxxx xx xxxxxx xxxxxxxxxxx xxxxxxxxxxx xxxx xxxx xxxxxx xx xxx. (Xxx xxxxx xxxxxxx xxxxxxxxxxx, xxx [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-foreground-app-with-voice-commands-in-cortana.md).)

-   [
            **XxxxxxXxxxxxxxxxxXxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631446)—X xxxxxxxxxx xxxxx xx x xxxxxxxxxx xxxxxxx (xxxxxxxxx xx xxx xxxxxx).
-   [
            **XxxxxxXxxxxxxxxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631421)—X xxxxxxxxxx xxxxx xx x xxxx xx xxxxx xx xxxxxxx.
-   [
            **XxxxxxXxxxxxxxxxxXxxxxxxXxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631412)—X xxxxxxxxxx xxxxxxx xx x Xxxxxx Xxxxxxxxxxx Xxxxxxx Xxxxxxxxxxxxx (XXXX) xxxx.

Xxxx xxxxxx xxxxxxxxxx xxx xxxx xxx xxxxxxxxxx xxxxxxxxxx. Xxxx xxxxx xxxxxxxxxxxx xx xxxxxxxxxxx xxx xxxxx:

-   X xxxxxx-xxxxx xxxxxxxxxx, xx xxxxxxxxxx xxxxxxx (xxxxxxxxx xx xxx xxxxxx). Xx xxxxx xxxxxxxxxxx xxx xxxxxxx.
-   X xxxxxxxxxxx xx xxxx xxxxxxxxxxx xxx/xx xxxxxxx-xxxx xxxxxxxxxxx.

**Xxxxxxxx:  **Xxxx xxx [**XxxxxxXxxxxxxxxx.XxxxxxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653240) xxxxxx xx xxxxxxx xxx xxxxxxxxxxx xxxxxx xxxxxxxx xxx xxxxxxxxxxx xxxxxxx.

## <span id="Specify_a_web-search_grammar__SpeechRecognitionTopicConstraint_">
            </span>
            <span id="specify_a_web-search_grammar__speechrecognitiontopicconstraint_">
            </span>
            <span id="SPECIFY_A_WEB-SEARCH_GRAMMAR__SPEECHRECOGNITIONTOPICCONSTRAINT_">
            </span>Xxxxxxx x xxx-xxxxxx xxxxxxx (XxxxxxXxxxxxxxxxxXxxxxXxxxxxxxxx)


Xxxxx xxxxxxxxxxx (xxxxxxxxx xx xxx-xxxxxx xxxxxxx) xxxx xx xxxxx xx xxx xxxxxxxxxxx xxxxxxxxxx xx x xxxxxx xxxxxxxxxx.

Xxxx, xx xxx x xxx-xxxxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxxxx.

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

## <span id="Specify_a_programmatic_list_constraint__SpeechRecognitionListConstraint_">
            </span>
            <span id="specify_a_programmatic_list_constraint__speechrecognitionlistconstraint_">
            </span>
            <span id="SPECIFY_A_PROGRAMMATIC_LIST_CONSTRAINT__SPEECHRECOGNITIONLISTCONSTRAINT_">
            </span>Xxxxxxx x xxxxxxxxxxxx xxxx xxxxxxxxxx (XxxxxxXxxxxxxxxxxXxxxXxxxxxxxxx)


Xxxx xxxxxxxxxxx xxxx xx xxxxx xx xxx xxxxxxxxxxx xxxxxxxxxx xx x xxxxxx xxxxxxxxxx.

Xxxx xxx xxxxxxxxx xxxxxx xx xxxx:

-   Xxx xxx xxx xxxxxxxx xxxx xxxxxxxxxxx xx x xxxxxxxxxxx xxxxxxxxxx.
-   Xxx xxx xxx xxx xxxxxxxxxx xxxx xxxxxxxxxx **XXxxxxxxx&xx;Xxxxxx&xx;** xxx xxx xxxxxx xxxxxx.

Xxxx, xx xxxxxxxxxxxxxxxx xxxxxxx xx xxxxx xx xxxxx xx x xxxx xxxxxxxxxx xxx xxx xx xx xxx xxxxxxxxxxx xxxxxxxxxx xx x xxxxxx xxxxxxxxxx.

```CSharp
private async void YesOrNo_Click(object sender, RoutedEventArgs e)
{
    // Create an instance of SpeechRecognizer.
    var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

    // You could create this array dynamically.
    string[] responses = { "Yes", "No" };


    // Add a list constraint to the recognizer.
    var listConstraint = new Windows.Media.SpeechRecognition.SpeechRecognitionListConstraint(responses, "yesOrNo");

    speechRecognizer.UIOptions.ExampleText = @"Ex. &#39;yes&#39;, &#39;no&#39;";
    speechRecognizer.Constraints.Add(listConstraint);

    // Compile the constraint.
    await speechRecognizer.CompileConstraintsAsync();

    // Start recognition.
    Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();

    // Do something with the recognition result.
    var messageDialog = new Windows.UI.Popups.MessageDialog(speechRecognitionResult.Text, "Text spoken");
    await messageDialog.ShowAsync();
}
```

## <span id="Specify_an_SRGS_grammar_constraint__SpeechRecognitionGrammarFileConstraint_">
            </span>
            <span id="specify_an_srgs_grammar_constraint__speechrecognitiongrammarfileconstraint_">
            </span>
            <span id="SPECIFY_AN_SRGS_GRAMMAR_CONSTRAINT__SPEECHRECOGNITIONGRAMMARFILECONSTRAINT_">
            </span>Xxxxxxx xx XXXX xxxxxxx xxxxxxxxxx (XxxxxxXxxxxxxxxxxXxxxxxxXxxxXxxxxxxxxx)


XXXX xxxxxxx xxxxx xxxx xx xxxxx xx xxx xxxxxxxxxxx xxxxxxxxxx xx x xxxxxx xxxxxxxxxx.

Xxx XXXX Xxxxxxx Y.Y xx xxx xxxxxxxx-xxxxxxxx xxxxxx xxxxxxxx xxx xxxxxxxx XXX-xxxxxx xxxxxxxx xxx xxxxxx xxxxxxxxxxx. Xxxxxxxx Xxxxxxxxx Xxxxxxx xxxx xxxxxxx xxxxxxxxxxxx xx xxxxx XXXX xxx xxxxxxxx xxxxxx-xxxxxxxxxxx xxxxxxxx, xxx xxxxx xxxx xxxx xxxxx XXXX xx xxxxxx xxxxxxxx xxxxxxxx xxx xxxx xxxxxxx, xxxxxxxxxxxx xxx xxxx xxxxxxxx xxxxxx xxxxxxxxxxx xxxxxxxxx.

XXXX xxxxxxxx xxxxxxx x xxxx xxx xx xxxxxxxx xx xxxx xxx xxxxxxxxx xxxxxxx xxxxx xxxxxxxxxxx xxx xxxx xxxx. Xxx xxxxxxx, xxxx XXXX xxxxxxxx xxx xxx:

-   Xxxxxxx xxx xxxxx xx xxxxx xxxxx xxx xxxxxxx xxxx xx xxxxxx xx xx xxxxxxxxxx.
-   Xxxxxxx xxxxx xxxx xxxxxxxx xxxxx xxx xxxxxxx xx xx xxxxxxxxxx.
-   Xxxx xx xxxxx xxxxxxxx.
-   Xxxxxx x xxxxxx xx xx xxxxxxxxxxx xxxx xx xxxxxx xx xxxxxxxx xx xxxxxxxx xxx xxxxxxxxxx xxxx xx xxxx xx xxxx xx xxxxx xxxxxx xxxxx.
-   Xxxxxxx xxxxxxxx xxxxx xx xxxxxxx.
-   Xxx xxxxxxx xxxxx xxxx xxxx xxxxxx xxx xxxxxxxxxxx xx xxxxxxxxxxxxx xxxxx, xxxx xx xxxxxx xxxxxx xxxx xxxxx'x xxxxx xxx xxxxxxx, xx xxxxxxxxxx xxxxx.
-   Xxx xxxxxxxxx xx xxxxxx xxxx xxxxxx xxxxxxxxxxx xxxxx xx xxxx xxx.
-   Xxxxxxx xxxxxxxxxxxxxx, xxxxxx xxxxxx xx x xxxxxxx xx xxx x xxxx xx x xxxxxxx.

Xxx xxxx xxxx xxxxx XXXX xxxxxxxx xxx xxxxxxxxxx, xxx xxx [XXXX Xxxxxxx XXX Xxxxxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=269886) . Xx xxx xxxxxxx xxxxxxxx xx XXXX xxxxxxx, xxx [Xxx xx Xxxxxx x Xxxxx XXX Xxxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=269887).

Xxxx xxx xxxxxxxxx xxxxxx xx xxxx:

-   Xxx xxx xxx xxxxxxxx xxxxxxx-xxxx xxxxxxxxxxx xx x xxxxxxxxxxx xxxxxxxxxx.
-   Xxx xxx .xxxxx xxxx xxxxxxxxx xxx XXX-xxxxx xxxxxxx xxxxxxxxx xxxx xxxxxxx xx XXXX xxxxx.

Xxxx xxxxxxx xxxx xx XXXX xxxxxxx xxxxxxx xx x xxxx xxxxx xxxx.xxxxx (xxxxxxxxx xxxxx). Xx xxx xxxx xxxxxxxxxx, xxx **Xxxxxxx Xxxxxx** xx xxx xx **Xxxxxxx** xxxx **Xxxx xx Xxxxxx Xxxxxxxxx** xxx xx **Xxxx xxxxxx**:

```CSharp
private async void Colors_Click(object sender, RoutedEventArgs e)
{
    // Create an instance of SpeechRecognizer.
    var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

    // Add a grammar file constraint to the recognizer.
    var storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Colors.grxml"));
    var grammarFileConstraint = new Windows.Media.SpeechRecognition.SpeechRecognitionGrammarFileConstraint(storageFile, "colors");

    speechRecognizer.UIOptions.ExampleText = @"Ex. &#39;blue background&#39;, &#39;green text&#39;";
    speechRecognizer.Constraints.Add(grammarFileConstraint);

    // Compile the constraint.
    await speechRecognizer.CompileConstraintsAsync();

    // Start recognition.
    Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();

    // Do something with the recognition result.
    var messageDialog = new Windows.UI.Popups.MessageDialog(speechRecognitionResult.Text, "Text spoken");
    await messageDialog.ShowAsync();
}
```

Xxxx XXXX xxxx (xxxx.xxxxx) xxxxxxxx xxxxxxxx xxxxxxxxxxxxxx xxxx. Xxxxx xxxx xxxxxxx x xxxxxxxxx xxx xxxxxxxxx xxxxxxx xxxxx xxxx xx xxxx xxx. Xxxxxxxx xxxx xxxxxxx xx xxx Xxxxx Xxxx Xxx Xxxxxxxxxx (XYX) [Xxxxxxxx Xxxxxxxxxxxxxx xxx Xxxxxx Xxxxxxxxxxx (XXXX) Y.Y](http://go.microsoft.com/fwlink/p/?LinkID=201765) xxxxxxxxxxxxx.

Xxxx, xx xxxxxx xxx xxxxxxxx xx "xxx" xxx "xx".

```CSharp
<grammar xml:lang="en-US" 
         root="yesOrNo"
         version="1.0" 
         tag-format="semantics/1.0"
         xmlns="http://www.w3.org/2001/06/grammar">

    <!-- The following rules recognize variants of yes and no. -->
      <rule id="yesOrNo">
         <one-of>
            <item>
              <one-of>
                 <item>yes</item>
                 <item>yeah</item>
                 <item>yep</item>
                 <item>yup</item>
                 <item>un huh</item>
                 <item>yay yus</item>
              </one-of>
              <tag>out="yes";</tag>
            </item>
            <item>
              <one-of>
                 <item>no</item>
                 <item>nope</item>
                 <item>nah</item>
                 <item>uh uh</item>
               </one-of>
               <tag>out="no";</tag>
            </item>
         </one-of>
      </rule>
</grammar>
```

## <span id="Manage_constraints">
            </span>
            <span id="manage_constraints">
            </span>
            <span id="MANAGE_CONSTRAINTS">
            </span>Xxxxxx xxxxxxxxxxx


Xxxxx x xxxxxxxxxx xxxxxxxxxx xx xxxxxx xxx xxxxxxxxxxx, xxxx xxx xxx xxxxxx xxxxx xxxxxxxxxxx xxx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xx xxxxxxx xxx [**XxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631402) xxxxxxxx xx x xxxxxxxxxx xx **xxxx** xx **xxxxx**. Xxx xxxxxxx xxxxxxx xx **xxxx**.

Xx'x xxxxxxx xxxx xxxxxxxxx xx xxxx xxxxxxxxxxx xxxx, xxxxxxxx xxx xxxxxxxxx xxxx xx xxxxxx, xxxxxx xxxx xx xxxx, xxxxxx, xxx xxxxxxx xxxxxxxxxxx xxx xxxx xxxxxxxxxxx xxxxxxxxx. Xxx xxx [**XxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631402) xxxxxxxx, xx xxxxxxxx.

Xxxxxxxxxxx xxx xxxxxx xx xxxxxxxxxxx xxxxxx xx xxxxx xxx xxxxxx xx xxxx xxxx xxx xxxxxx xxxxxxxxxx xxxxx xx xxxxxx xxx xxxxx xxxxxxx xxx xxxxxx xxxxx. Xxxx xxx xxxxxxx xxxx xxx xxxxxxxxxxx xxx xxx xxxxxxxx xx xxxxxx xxxxxxxxxxx.

Xxxxxx xxxxx xxxxxxxxxxx xxx xxxxxxx xxxxx xx xxx xxxxxxx xxxx xxxx xxx xxx xxxxxx xx xxx xxxxxxx xx xxx xxxxxxx xxxxxxxxxxx xxxxxxxxx. Xxx xxxxxxx, xx xxx xxxxxxx xxx xxxxxxx xx xx xxxxxxx x xxxxx, xxx xxxxxxxx xxx'x xxxx xx xxxxxx x xxxxxxxxxx xxxx xxxxxxxxxx xxx xxxxx xx xxxxxxx.

Xx xxxxxx xxx xxxx xxx xxxx xxx xx xxxxxx, xxx xxx [**XxxxxxXxxxxxxxxxXXXxxxxxx.XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653235) xxx [**XxxxxxXxxxxxxxxxXXXxxxxxx.XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn653236) xxxxxxxxxx, xxxxx xxx xxx xx xxxxx xx xxx [**XxxxxxXxxxxxxxxx.XXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653254) xxxxxxxx. Xxxxxxxxx xxxxx xxx xxxx xxxx xxx xxx xxxxxx xxx xxxxxxxxxxx xxxxxxxxx xxxxxxxxx xxx xxxxxxxxxx xxxx xxxx xxxx xxxxx x xxxxxx xxxx xxx xx xxxxxxx xx xx xxxxxx xxxxxxxxxx.

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


* [Xxxxxx xxxxxxxxxxxx](speech-interactions.md)

**Xxxxxxx**
* [Xxxxxx xxxxxxxxxxx xxx xxxxxx xxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




<!--HONumber=Mar16_HO1-->
