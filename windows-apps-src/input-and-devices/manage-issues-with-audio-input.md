---
author: Karl-Bridge-Microsoft
Description: "オーディオ入力の品質が原因で発生する音声認識の精度の問題を管理する方法について説明します。"
title: "音声入力の問題の管理"
ms.assetid: 3E36C683-C96A-4FEE-AD52-FDB87E0CC299
label: Manage audio input issues
template: detail.hbs
ms.sourcegitcommit: a4e9a90edd2aae9d2fd5d7bead948422d43dad59
ms.openlocfilehash: 6dcab14a290367250e152fb8a1944a924d5aaf46

---

# 音声入力の問題の管理

オーディオ入力の品質が原因で発生する音声認識の精度の問題を管理する方法について説明します。

**重要な API**

-   [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226)
-   [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243)
-   [**SpeechRecognitionAudioProblem**](https://msdn.microsoft.com/library/windows/apps/dn631406)




## <span id="Assess_audio-input_quality"></span><span id="assess_audio-input_quality"></span><span id="ASSESS_AUDIO-INPUT_QUALITY"></span>オーディオ入力の品質を評価する


音声認識がアクティブな場合は、音声認識エンジンの [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) イベントを使用して、1 つ以上のオーディオの問題によって音声入力が妨げられている可能性があるかどうかを判断します。 イベント引数 ([**SpeechRecognitionQualityDegradingEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn631430)) には、[**Problem**](https://msdn.microsoft.com/library/windows/apps/dn631431) プロパティがあり、音声入力で検出された問題の説明が含まれています。

認識は、多すぎる背景の雑音、ミュートされたマイク、およびスピーカーのボリュームや速度の影響を受ける場合があります。

ここでは、音声認識エンジンを構成し、[**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) イベントのリッスンを開始します。

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

## <span id="Manage_the_speech-recognition_experience"></span><span id="manage_the_speech-recognition_experience"></span><span id="MANAGE_THE_SPEECH-RECOGNITION_EXPERIENCE"></span>音声認識エクスペリエンスを管理する


[
            **Problem**](https://msdn.microsoft.com/library/windows/apps/dn631431) プロパティにある説明を使用して、ユーザーが認識の状態を改善できるようにします。

ここでは、低い音量レベルをチェックする [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) イベント用のハンドラーを作成します。 次に、[**SpeechSynthesizer**](https://msdn.microsoft.com/library/windows/apps/dn298152) オブジェクトを使って、より大きな声で話すことをユーザーに提示します。

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

## <span id="related_topics"></span>関連記事


* [音声操作](speech-interactions.md)

**サンプル**
* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 







<!--HONumber=Jun16_HO3-->


