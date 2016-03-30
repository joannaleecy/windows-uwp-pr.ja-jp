---
Xxxxxxxxxxx: Xxxxx xxx xx xxxxxxx xxx xxxxxxxxx xxxx-xxxx, xxxxxxxxxx xxxxxxxxx xxxxxx xxxxx.
xxxxx: Xxxxxx xxxxxxxxxx xxxxxxxxx
xx.xxxxxxx: YYYXYXYY-YYYY-YXXX-XYYX-YXXYXXYXXYXX
xxxxx: Xxxxxxxxxx xxxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxxxx xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxx xx xxxxxxx xxx xxxxxxxxx xxxx-xxxx, xxxxxxxxxx xxxxxxxxx xxxxxx xxxxx.

**Xxxxxxxxx XXXx**

-   [**XxxxxxXxxxxxxxxxXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913896)
-   [**XxxxxxxxxxXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913913)


Xx [Xxxxxx xxxxxxxxxxx](speech-recognition.md), xxx xxxxxxx xxx xx xxxxxxx xxx xxxxxxxxx xxxxxxxxxx xxxxx xxxxxx xxxxx xxxxx xxx [**XxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653244) xx [**XxxxxxxxxXxxxXXXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653245) xxxxxxx xx x [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653226) xxxxxx, xxx xxxxxxx, xxxx xxxxxxxxx x xxxxx xxxxxxx xxxxxxx (XXX) xxxxxxx xx xxxx xxxxxx x xxxxxxxx.

Xxx xxxxxx, xxxxxxxxxx xxxxxx xxxxxxxxxxx xxxxxxxx, xxxx xx xxxxxxxxx xx xxxxx, xxx xxx [**XxxxxxxxxxXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913913) xxxxxxxx xx x [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653226) xx xxxxxx x [**XxxxxxXxxxxxxxxxXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913896) xxxxxx.



## <span id="Set_up">
            </span>
            <span id="set_up">
            </span>
            <span id="SET_UP">
            </span>Xxx xx


Xxxx xxx xxxxx x xxx xxxxxxx xx xxxxxx x xxxxxxxxxx xxxxxxxxx xxxxxxx:

-   Xx xxxxxxxx xx x [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653226) xxxxxx.
-   X xxxxxxxxx xx x XX xxxxxxxxxx xx xxxxxx xxx XX xxxxxx xxxxxxxxx.
-   X xxx xx xxxxx xxx xxxxxxxxxxx xxxxx xxxxxx xx xxx xxxx.

Xxxx, xx xxxxxxx x [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653226) xxxxxxxx xx x xxxxxxx xxxxx xx xxx xxxx-xxxxxx xxxxx. Xxxx xxx xxxxx xx xxxxx x xxxxxxxxx xxxxxxxxx xx xxx xxxx xxxxxxxxxx xxxxxxxxx xx xxxxxxx xxxxxx x xxxxxx Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX) xxxx.

```CSharp
private SpeechRecognizer speechRecognizer;</code></pre></td>
</tr>
</tbody>
</table>
```

Xxxxxx xxxxxxxxx, xxx xxxxxxxxxx xxxxxx xxxxxx xxxx x xxxxxxxxxx xxxxxx. Xxxxxxx x xxxxxxxxxx xxxxxx xxxxxx xxxxxxxx xxxxxx xxx XX xx XXXX, xxxx xxx xxxx xxx x xxxxxxxxxx xx xxxxxx xxx XX xx xxxxxxxx xx xxxxxxxxxxx xxxxxx.

Xxxx, xx xxxxxxx x xxxxxxx xxxxx xxxx xxxx xx xxxxxxxxxxx xxxxx xxxx xxx XX xxxxxxxxxx.

<span codelanguage="CSharp"></span>
```CSharp
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
// Speech events may originate from a thread other than the UI thread.
// Keep track of the UI thread dispatcher so that we can update the
// UI in a thread-safe manner.
private CoreDispatcher dispatcher;
```

Xx xxxxx xxxx xxx xxxx xx xxxxxx, xxx xxxx xx xxxxxx xxxxxxxxxxx xxxxxx xxxxxx xx xxx xxxxxx xxxxxxxxxx. Xxxxx xxxxxx xxxxxxx xxx xxxxxxxxxxx xxxxxxx xxx xxxxxx xx xxxx xxxxxxxxxx.

Xxxx, xx xxx x [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/system.text.stringbuilder.aspx) xxxxxx xx xxxx xxx xxx xxxxxxxxxxx xxxxxxx xxxxxxxx xxxxxx xxx xxxxxxx. Xxx xxxxxxx xxx xxxxxxxx xx xxx **XxxxxxXxxxxxx** xx xxxx xxx xxxxxxxxx.

```CSharp
private StringBuilder dictatedTextBuilder;</code></pre></td>
</tr>
</tbody>
</table>
```

## <span id="Initialization">
            </span>
            <span id="initialization">
            </span>
            <span id="INITIALIZATION">
            </span>Xxxxxxxxxxxxxx


Xxxxxx xxx xxxxxxxxxxxxxx xx xxxxxxxxxx xxxxxx xxxxxxxxxxx, xxx xxxx:

-   Xxxxx xxx xxxxxxxxxx xxx xxx XX xxxxxx xx xxx xxxxxx xxx XX xx xxxx xxx xx xxx xxxxxxxxxx xxxxxxxxxxx xxxxx xxxxxxxx.
-   Xxxxxxxxxx xxx xxxxxx xxxxxxxxxx.
-   Xxxxxxx xxx xxxxx-xx xxxxxxxxx xxxxxxx.
    **Xxxx**   Xxxxxx xxxxxxxxxxx xxxxxxxx xx xxxxx xxx xxxxxxxxxx xx xxxxxx x xxxxxxxxxxxx xxxxxxxxxx. Xx xx xxxxxxxxxx xx xxxxxxxxx, x xxxxxxxxxx xxxxxxxxx xxxxxxx xx xxxx. Xxx [Xxxxxx xxxxxxxxxxx](speech-recognition.md).

     

-   Xxx xx xxx xxxxx xxxxxxxxx xxx xxxxxxxxxxx xxxxxx.

Xx xxxxxxxxxx xxxxxx xxxxxxxxxxx xx xxx [**XxXxxxxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br227508) xxxx xxxxx.

1.  Xxxxxxx xxxxxx xxxxxx xx xxx xxxxxx xxxxxxxxxx xxxxx xx x xxxxxxxxxx xxxxxx, xxxxxx x xxxxxxxxx xx xxx xxxxxxxxxx xxx xxxxxxx xx xxx XX xxxxxx. [
            **XxXxxxxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br227508) xx xxxxxx xxxxxxx xx xxx XX xxxxxx.

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
this.dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;</code></pre></td>
    </tr>
    </tbody>
    </table>
```

2.  Xx xxxx xxxxxxxxxx xxx [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653226) xxxxxxxx.

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
this.speechRecognizer = new SpeechRecognizer();</code></pre></td>
    </tr>
    </tbody>
    </table>
```

3.  Xx xxxx xxx xxx xxxxxxx xxx xxxxxxx xxxx xxxxxxx xxx xx xxx xxxxx xxx xxxxxxx xxxx xxx xx xxxxxxxxxx xx xxx [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653226).

    Xx xxx xxx'x xxxxxxx x xxxxxxx xxxxxxxxxx, x xxxxxxxxxx xxxxxxxxx xxxxxxx xx xxxx xx xxxxxxx. Xxxxxxxxx, xxx xxxxxxx xxxxxxx xx xxxx xxx xxxxxxx xxxxxxxxx.

    Xxxx, xx xxxx [**XxxxxxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653240) xxxxxxxxxxx xxxxxxx xxxxxx x xxxxxxx.

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
SpeechRecognitionCompilationResult result =
      await speechRecognizer.CompileConstraintsAsync();
```

## <span id="Handle_recognition_events">
            </span>
            <span id="handle_recognition_events">
            </span>
            <span id="HANDLE_RECOGNITION_EVENTS">
            </span>Xxxxxx xxxxxxxxxxx xxxxxx


Xxxx, xxx xxx xxxxxxx x xxxxxx, xxxxx xxxxxxxxx xx xxxxxx xx xxxxxxx [**XxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653244) xx [**XxxxxxxxxXxxxXXXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653245). Xxxxxxx, xx xxxx xx xxxxxxx x xxxxxx, xxxxxxxxxx xxxxxxxxxxx xxxxxxx.

Xx xx xxxx, xx xxxxxxx xxxxx xxxxxxxxx xx xxx xx xxx xxxxxxxxxx xx xxx xxxx xxxxxx xxx xxxxxx xxxxxxxx xx xxxxx xxx xxxxxxxxx xxxxxx.

Xx xxxx xxx xxx [**XxxxxxxxxxXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913913) xxxxxxxx xx xxx xxxxxxxxxx xx xxxxxx x [**XxxxxxXxxxxxxxxxXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913896) xxxxxx xxxx xxxxxxxx xxxxxxx xxx xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxxxxxxxxx xxxxxxx.

Xxx xxxxxx xx xxxxxxxxxx xxx xxxxxxxx:

-   [
            **XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900), xxxxx xxxxxx xxxx xxx xxxxxxxxxx xxx xxxxxxxxx xxxx xxxxxxx.
-   [
            **Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913899), xxxxx xxxxxx xxxx xxx xxxxxxxxxx xxxxxxxxxxx xxxxxxx xxx xxxxx.

Xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx xx xxxxxx xx xxx xxxx xxxxxx. Xxx xxxxxxxxxx xxxxxxxxxxxx xxxxxxx xx xxx xxxx xxx xxxxxxxxxxxx xxxxxx xx xxxxx xxxx xxxxxx x xxxxx xx xxxxxx xxxxx. Xxx xxxx xxxxxxx xxx xxxxxx xxxxx, xxxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913895) xxxxxxxx xx xxx xxxxx xxxxxxxx, xxx xxxx xxxxxxxxxxx xxxxxx xx xxx xxxxx xxxxxxx, xxxx xx xxxxxxxxx xxx xxxx xx x XxxxxxXxxxxxx xxxxxx.

Xx xx xxxxxxxx xx [**XxxxxxXxxxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631432), xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913895) xxxxxxxx xx xxxxxx xxx xxxxxxxxxxx xxxxxxx xxx xxxx xx xxxxxx xxx xxxxxx xxxxx:

-   [
            **Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631440) xxxxxxxxx xxxxxxx xxx xxxxxxxxxxx xxx xxxxxxxxxx. Xxxxxxxxxxx xxx xxxx xxx x xxxxxxx xx xxxxxxx.
-   [
            **Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631434) xxxxxxxxx xxx xxxxxxxx xxxxxxxxxx xxxx xxx xxxxxxxxxx xxxxxxxxxx xxx xxxxxxx xxxxx.

1.  Xxxx, xx xxxxxxxx xxx xxxxxxx xxx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxxxxxxx xxxxxxxxxxx xxxxx xx xxx [**XxXxxxxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br227508) xxxx xxxxx.

```    CSharp
speechRecognizer.ContinuousRecognitionSession.ResultGenerated +=
        ContinuousRecognitionSession_ResultGenerated;
```

2.  Xx xxxx xxxxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631434) xxxxxxxx. Xx xxx xxxxx xx Xxxxxxxxxx xx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631409) xx xxxxxx, xx xxxxxx xxx xxxx xx xxx XxxxxxXxxxxxx. Xx xxxx xxxxxx xxx XX xx xx xxxxxxx xxxxx.

    **Xxxx**  xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx xx xxxxxx xx x xxxxxxxxxx xxxxxx xxxx xxxxxx xxxxxx xxx XX xxxxxxxx. Xx x xxxxxxx xxxxx xx xxxxxx xxx XX (xx xxx \[Xxxxxx xxx XXX xxxxxx\] xxxx), xxx xxxx xxxxxxxx xxx xxxxxxx xx xxx XX xxxxxx xxxxxxx xxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh750317) xxxxxx xx xxx xxxxxxxxxx.

     

```    CSharp
private async void ContinuousRecognitionSession_ResultGenerated(
      SpeechContinuousRecognitionSession sender,
      SpeechContinuousRecognitionResultGeneratedEventArgs args)
      {

        if (args.Result.Confidence == SpeechRecognitionConfidence.Medium ||
          args.Result.Confidence == SpeechRecognitionConfidence.High)
          {
            dictatedTextBuilder.Append(args.Result.Text + " ");

            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
              dictationTextBox.Text = dictatedTextBuilder.ToString();
              btnClearText.IsEnabled = true;
            });
          }
        else
        {
          await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
              dictationTextBox.Text = dictatedTextBuilder.ToString();
            });
        }
      }
```

3.  Xx xxxx xxxxxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913899) xxxxx, xxxxx xxxxxxxxx xxx xxx xx xxxxxxxxxx xxxxxxxxx.

    Xxx xxxxxxx xxxx xxxx xxx xxxx xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913908) xx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913898) xxxxxxx (xxxxxxxxx xxx xxxx xxxxxxx). Xxx xxxxxxx xxx xxxx xxx xxxx xx xxxxx xxxxxx, xx xxxx xxx xxxx xxx xxxxxxx xxxxxxxx. Xxxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631440) xxxxxxxx xx xxx xxxxx xxxxxxxx xx xxxxxxxxx xxx xxx xxxxxxx xxxxx ([**XxxxxxXxxxxxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631433)).

    Xxxx, xx xxxxxxxx xxx xxxxxxx xxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913899) xxxxxxxxxx xxxxxxxxxxx xxxxx xx xxx [**XxXxxxxxxxxXx**](https://msdn.microsoft.com/library/windows/apps/br227508) xxxx xxxxx.

```    CSharp
speechRecognizer.ContinuousRecognitionSession.Completed +=
      ContinuousRecognitionSession_Completed;
```

4.  Xxx xxxxx xxxxxxx xxxxxx xxx Xxxxxx xxxxxxxx xx xxxxxxxxx xxxxxxx xxx xxxxxxxxxxx xxx xxxxxxxxxx. Xx xxxx xxxxxxx xxx xxxx xxxxx xxx xxxx xxx xxxxxxx xxxxxxxx. Xxxxx, x [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn631433) xx xxxxxxxxxx xxxxxxxxxx xxxxxxxxxxx xx xx xxxxx xxx xxxx xxx xxxxxxxx xxxxxxxx. Xxx xxxxxx xxxxxx xxxx xxxx xx xxxx xxxx xxx x xxxx xxxxxxxxxx.

    **Xxxx**  xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx xx xxxxxx xx x xxxxxxxxxx xxxxxx xxxx xxxxxx xxxxxx xxx XX xxxxxxxx. Xx x xxxxxxx xxxxx xx xxxxxx xxx XX (xx xxx \[Xxxxxx xxx XXX xxxxxx\] xxxx), xxx xxxx xxxxxxxx xxx xxxxxxx xx xxx XX xxxxxx xxxxxxx xxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh750317) xxxxxx xx xxx xxxxxxxxxx.

     

```    CSharp
private async void ContinuousRecognitionSession_Completed(
      SpeechContinuousRecognitionSession sender,
      SpeechContinuousRecognitionCompletedEventArgs args)
      {
        if (args.Status != SpeechRecognitionResultStatus.Success)
        {
          if (args.Status == SpeechRecognitionResultStatus.TimeoutExceeded)
          {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
              rootPage.NotifyUser(
                "Automatic Time Out of Dictation",
                NotifyType.StatusMessage);

              DictationButtonText.Text = " Continuous Recognition";
              dictationTextBox.Text = dictatedTextBuilder.ToString();
            });
          }
          else
          {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
              rootPage.NotifyUser(
                "Continuous Recognition Completed: " + args.Status.ToString(),
                NotifyType.StatusMessage);

              DictationButtonText.Text = " Continuous Recognition";
            });
          }
        }
      }
```

## <span id="Provide_ongoing_recognition_feedback">
            </span>
            <span id="provide_ongoing_recognition_feedback">
            </span>
            <span id="PROVIDE_ONGOING_RECOGNITION_FEEDBACK">
            </span>Xxxxxxx xxxxxxx xxxxxxxxxxx xxxxxxxx


Xxxx xxxxxx xxxxxxxx, xxxx xxxxx xxxx xx xxxxxxx xx xxxxx xxxxxxxxxx xxxx xx xxxxx xxxx. Xxxxxxxxx, xxx xxxxxx xxxxxxxxxx xxxxx xxxxx xxxxxxx xx xxxxxxx xxxx-xxxxxxxxxx xxxxxxxxxxx xxxxxxx. Xxx xxxxxxx, xx xxxxxxxxxx, xxx xxxxx "xxxxxx" xxx "xxxx" xxx xxxxxxxxxxxxxxxxx xxxxx xxxx xxxxxxx xxx xx xxxxxxx xxxx xxxxxxxxxxx xxxxx. Xxxxx xxx xxxxxxxxxx xxx xxxx xxxxxxxxxx xxxx x xxxx, xx xxxxx, xxxx xxxx xxxxxxxxxx xxxxxxxxx, xx xxxx xxx xxxxx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx.

Xxxx xxx xxxxxx xx x xxxx xxxx xxxxx xxxxxxxxxx xxx xxx xxxx xx xxxx xxxxxxxx xxxxxxxx xxx xx xxxxxxx xxx xxxxxxxx xxxxx xxx xxxxxxxxxx xxx xxxx xxxxxx xxxxxxxxxx xx xxxxx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx.

Xxxxxx xxx [**XxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913914) xxxxx xx xxxxxxx xxxx xxxxxxxx xxxx xx xxxxxxxxxxxxxx. Xxxx xxxxx xx xxxxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxxx x xxx xxx xx xxxxxxxxx xxxxxxx xxx xxx xxxx xxxxx xxxxxxxxx. Xxx xxxxx xxxxxxxx xxxxxxxx xx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913911) xxxxxxxx xxxx xxxxxxxx xxx xxxxxxx xxxxxxx. Xxxx xxxxx xx xxx xxxx xx xxxx xxxxxxxx xxxxxxxx xxx xxxxxxxx xxxx xxxx xxxxxxxxxx xx xxxxx xxxxxx. Xxxx xxxxxxxxxx xx xxxx xxx x xxxxxxxxxxx xxxxxx xxx xxxx xxxxxxxxxx, xxxxxxx xxx xxxxxxx **Xxxxxxxxxx** xxxxxxx xxxx xxx xxxxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913895) xxxxxxxx xx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx.

Xxxx, xx xxxxxx xxx xxxxxxxxxxxx xxxx xxx xx xxxxxxxx ("…") xx xxx xxxxxxx xxxxx xx xxx xxxxxx [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683). Xxx xxxxxxxx xx xxx xxxx xxx xxx xxxxxxx xx xxx xxxxxxxxxx xxx xxxxxxxxx xxx xxxxx xxx xxxxx xxxxxxx xxx xxxxxxxx xxxx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx.

```CSharp
private async void SpeechRecognizer_HypothesisGenerated(
  SpeechRecognizer sender,
  SpeechRecognitionHypothesisGeneratedEventArgs args)
  {

    string hypothesis = args.Hypothesis.Text;
    string textboxContent = dictatedTextBuilder.ToString() + " " + hypothesis + " ...";

    await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
      dictationTextBox.Text = textboxContent;
      btnClearText.IsEnabled = true;
    });
  }
```

## <span id="Start_and_stop_recognition">
            </span>
            <span id="start_and_stop_recognition">
            </span>
            <span id="START_AND_STOP_RECOGNITION">
            </span>Xxxxx xxx xxxx xxxxxxxxxxx


Xxxxxx xxxxxxxx x xxxxxxxxxxx xxxxxxx, xxxxx xxx xxxxx xx xxx xxxxxx xxxxxxxxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913915) xxxxxxxx. Xxx xxxxxx xxxxxxxxxx xxxx xx xx xx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn653227) xxxxx.

Xxxxx xxxxxxxx xxx xxxxx xx xxx xxxxxx xxxxxxxxxx, xx xxxxx xxx xxxxxxx xx xxxxxxx xxx [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913901) xxxxxx xx xxx xxxxxx xxxxxxxxxx'x [**XxxxxxxxxxXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913913) xxxxxxxx.

```CSharp
if (speechRecognizer.State == SpeechRecognizerState.Idle)
{
  await speechRecognizer.ContinuousRecognitionSession.StartAsync();
}
```

Xxxxxxxxxxx xxx xx xxxxxxx xx xxx xxxx:

-   [
            **XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913908) xxxx xxx xxxxxxx xxxxxxxxxxx xxxxxx xxxxxxxx ([**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxxxxxx xx xx xxxxxx xxxxx xxx xxxxxxx xxxxxxxxxxx xxxxxxxxxx xxx xxxxxxxx).
-   [
            **XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913898) xxxxxxxxxx xxx xxxxxxxxxxx xxxxxxx xxxxxxxxxxx xxx xxxxxxxx xxx xxxxxxx xxxxxxx.

Xxxxx xxxxxxxx xxx xxxxx xx xxx xxxxxx xxxxxxxxxx, xx xxxx xxx xxxxxxx xx xxxxxxx xxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913898) xxxxxx xx xxx xxxxxx xxxxxxxxxx'x [**XxxxxxxxxxXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913913) xxxxxxxx.

```CSharp
if (speechRecognizer.State != SpeechRecognizerState.Idle)
{
  await speechRecognizer.ContinuousRecognitionSession.CancelAsync();
}
```

**Xxxx**  
X [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx xxx xxxxx xxxxx x xxxx xx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913898).

Xxxxxxx xx xxxxxxxxxxxxxx, x [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxx xxxxx xxxxx xxxxxx xx xxx xxxxx xxxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913898) xx xxxxxx. Xx xx, xxx **XxxxxxXxxxxxxxx** xxxxx xxxxx xxxxx.

Xx xxx xxx xxx xxxxxxx xxxxxx xxxx xxxxxxxxx xxx xxxxxxxxxxx xxxxxxx, xxxxxx xxxxxxx xxxxx xxxxxx xx xxx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913900) xxxxxxx. Xxx xxxxxxx, xxx'x xxxxxx x xxxxx xx xxxxxxxxxxx xx xxxx xxxxxxx xx xxx xxx xxxx xx xxxx xxxx xxx xxxxxx xxx xxxxxxx.

 

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


* [Xxxxxx xxxxxxxxxxxx](speech-interactions.md)

**Xxxxxxx**
* [Xxxxxx xxxxxxxxxxx xxx xxxxxx xxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




<!--HONumber=Mar16_HO1-->
