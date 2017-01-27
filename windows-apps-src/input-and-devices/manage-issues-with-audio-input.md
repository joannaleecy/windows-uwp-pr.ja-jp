---
author: Karl-Bridge-Microsoft
Description: "オーディオ入力の品質が原因で発生する音声認識の精度の問題を管理する方法について説明します。"
title: "音声入力の問題の管理"
ms.assetid: 3E36C683-C96A-4FEE-AD52-FDB87E0CC299
label: Manage audio input issues
template: detail.hbs
keywords: "スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: 482530931fe5764f65d2564107318c272c5c7b7f
ms.openlocfilehash: a6f6e4c04f608898d2871113f38fe647b62bf8a5

---

# <a name="manage-issues-with-audio-input"></a>音声入力の問題の管理
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

オーディオ入力の品質が原因で発生する音声認識の精度の問題を管理する方法について説明します。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226)</li>
<li>[**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243)</li>
<li>[**SpeechRecognitionAudioProblem**](https://msdn.microsoft.com/library/windows/apps/dn631406)</li>

</ul>
</div>


## <a name="assess-audio-input-quality"></a>オーディオ入力の品質を評価する


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

## <a name="manage-the-speech-recognition-experience"></a>音声認識エクスペリエンスを管理する


[**Problem**](https://msdn.microsoft.com/library/windows/apps/dn631431) プロパティにある説明を使用して、ユーザーが認識の状態を改善できるようにします。

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

## <a name="related-articles"></a>関連記事


* [音声操作](speech-interactions.md)

**サンプル**
* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 







<!--HONumber=Dec16_HO3-->


