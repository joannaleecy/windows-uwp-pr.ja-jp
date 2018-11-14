---
author: Karl-Bridge-Microsoft
Description: Learn how to manage issues with speech-recognition accuracy caused by audio-input quality.
title: オーディオ入力の問題の管理
ms.assetid: 3E36C683-C96A-4FEE-AD52-FDB87E0CC299
label: Manage audio input issues
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 094acdbcb5c5b3bf45bad757344be5187ae37cbc
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6207264"
---
# <a name="manage-issues-with-audio-input"></a><span data-ttu-id="97aca-103">音声入力の問題の管理</span><span class="sxs-lookup"><span data-stu-id="97aca-103">Manage issues with audio input</span></span>


<span data-ttu-id="97aca-104">オーディオ入力の品質が原因で発生する音声認識の精度の問題を管理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="97aca-104">Learn how to manage issues with speech-recognition accuracy caused by audio-input quality.</span></span>

> <span data-ttu-id="97aca-105">**重要な API**: [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226)、[**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243)、[**SpeechRecognitionAudioProblem**](https://msdn.microsoft.com/library/windows/apps/dn631406)</span><span class="sxs-lookup"><span data-stu-id="97aca-105">**Important APIs**: [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226), [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243), [**SpeechRecognitionAudioProblem**](https://msdn.microsoft.com/library/windows/apps/dn631406)</span></span>


## <a name="assess-audio-input-quality"></a><span data-ttu-id="97aca-106">オーディオ入力の品質を評価する</span><span class="sxs-lookup"><span data-stu-id="97aca-106">Assess audio-input quality</span></span>


<span data-ttu-id="97aca-107">音声認識がアクティブな場合は、音声認識エンジンの [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) イベントを使用して、1 つ以上のオーディオの問題によって音声入力が妨げられている可能性があるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="97aca-107">When speech recognition is active, use the [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) event of your speech recognizer to determine whether one or more audio issues might be interfering with speech input.</span></span> <span data-ttu-id="97aca-108">イベント引数 ([**SpeechRecognitionQualityDegradingEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn631430)) には、[**Problem**](https://msdn.microsoft.com/library/windows/apps/dn631431) プロパティがあり、音声入力で検出された問題の説明が含まれています。</span><span class="sxs-lookup"><span data-stu-id="97aca-108">The event argument ([**SpeechRecognitionQualityDegradingEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn631430)) provides the [**Problem**](https://msdn.microsoft.com/library/windows/apps/dn631431) property, which describes the issues detected with the audio input.</span></span>

<span data-ttu-id="97aca-109">認識は、多すぎる背景の雑音、ミュートされたマイク、およびスピーカーのボリュームや速度の影響を受ける場合があります。</span><span class="sxs-lookup"><span data-stu-id="97aca-109">Recognition can be affected by too much background noise, a muted microphone, and the volume or speed of the speaker.</span></span>

<span data-ttu-id="97aca-110">ここでは、音声認識エンジンを構成し、[**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) イベントのリッスンを開始します。</span><span class="sxs-lookup"><span data-stu-id="97aca-110">Here, we configure a speech recognizer and start listening for the [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) event.</span></span>

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
    speechRecognizer.UIOptions.ExampleText = "Ex. 'weather for London'";
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

## <a name="manage-the-speech-recognition-experience"></a><span data-ttu-id="97aca-111">音声認識エクスペリエンスを管理する</span><span class="sxs-lookup"><span data-stu-id="97aca-111">Manage the speech-recognition experience</span></span>


<span data-ttu-id="97aca-112">[**Problem**](https://msdn.microsoft.com/library/windows/apps/dn631431) プロパティにある説明を使用して、ユーザーが認識の状態を改善できるようにします。</span><span class="sxs-lookup"><span data-stu-id="97aca-112">Use the description provided by the [**Problem**](https://msdn.microsoft.com/library/windows/apps/dn631431) property to help the user improve conditions for recognition.</span></span>

<span data-ttu-id="97aca-113">ここでは、低い音量レベルをチェックする [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) イベント用のハンドラーを作成します。</span><span class="sxs-lookup"><span data-stu-id="97aca-113">Here, we create a handler for the [**RecognitionQualityDegrading**](https://msdn.microsoft.com/library/windows/apps/dn653243) event that checks for a low volume level.</span></span> <span data-ttu-id="97aca-114">次に、[**SpeechSynthesizer**](https://msdn.microsoft.com/library/windows/apps/dn298152) オブジェクトを使って、より大きな声で話すことをユーザーに提示します。</span><span class="sxs-lookup"><span data-stu-id="97aca-114">We then use a [**SpeechSynthesizer**](https://msdn.microsoft.com/library/windows/apps/dn298152) object to suggest that the user try speaking louder.</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="97aca-115">関連記事</span><span class="sxs-lookup"><span data-stu-id="97aca-115">Related articles</span></span>


* [<span data-ttu-id="97aca-116">音声操作</span><span class="sxs-lookup"><span data-stu-id="97aca-116">Speech interactions</span></span>](speech-interactions.md)

**<span data-ttu-id="97aca-117">サンプル</span><span class="sxs-lookup"><span data-stu-id="97aca-117">Samples</span></span>**
* [<span data-ttu-id="97aca-118">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="97aca-118">Speech recognition and speech synthesis sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




