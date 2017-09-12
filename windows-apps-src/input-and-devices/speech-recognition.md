---
author: Karl-Bridge-Microsoft
Description: "音声認識を使って、入力を行ったり、操作やコマンドを指定したり、タスクを実行したりできます。"
title: "音声認識"
ms.assetid: 553C0FB7-35BC-4894-9EF1-906139E17552
label: Speech recognition
template: detail.hbs
keywords: "スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 246db868cda1b1d6e61a33981fc756767ebdbd8d
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="speech-recognition"></a><span data-ttu-id="a69bb-104">音声認識</span><span class="sxs-lookup"><span data-stu-id="a69bb-104">Speech recognition</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="a69bb-105">音声認識を使って、入力を行ったり、操作やコマンドを指定したり、タスクを実行したりできます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-105">Use speech recognition to provide input, specify an action or command, and accomplish tasks.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="a69bb-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="a69bb-106">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="a69bb-107">Windows.Media.SpeechRecognition</span><span class="sxs-lookup"><span data-stu-id="a69bb-107">Windows.Media.SpeechRecognition</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn653262)</li>
</ul>
</div>

<span data-ttu-id="a69bb-108">音声認識機能は、音声認識ランタイム、ランタイムをプログラミングするための認識 API、ディクテーションと Web 検索のための定義済みの文法、ユーザーが音声認識機能を見つけて使うときに役立つ既定のシステム UI で構成されています。</span><span class="sxs-lookup"><span data-stu-id="a69bb-108">Speech recognition is made up of a speech runtime, recognition APIs for programming the runtime, ready-to-use grammars for dictation and web search, and a default system UI that helps users discover and use speech recognition features.</span></span>


## <a name="set-up-the-audio-feed"></a><span data-ttu-id="a69bb-109">オーディオ フィードの設定</span><span class="sxs-lookup"><span data-stu-id="a69bb-109">Set up the audio feed</span></span>


<span data-ttu-id="a69bb-110">使っているデバイスにマイクまたは同等の機能があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-110">Ensure that your device has a microphone or the equivalent.</span></span>

<span data-ttu-id="a69bb-111">[アプリ パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/br211474) (**package.appxmanifest** ファイル) で**マイク** デバイスの機能 ([**DeviceCapability**](https://msdn.microsoft.com/library/windows/apps/br211430)) を設定して、マイクのオーディオ フィードにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="a69bb-111">Set the **Microphone** device capability ([**DeviceCapability**](https://msdn.microsoft.com/library/windows/apps/br211430)) in the [App package manifest](https://msdn.microsoft.com/library/windows/apps/br211474) (**package.appxmanifest** file) to get access to the microphone’s audio feed.</span></span> <span data-ttu-id="a69bb-112">こうすることで、アプリは接続されたマイクからオーディオを録音できます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-112">This allows the app to record audio from connected microphones.</span></span>

<span data-ttu-id="a69bb-113">「[アプリ機能の宣言](https://msdn.microsoft.com/library/windows/apps/mt270968)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a69bb-113">See [App capability declarations](https://msdn.microsoft.com/library/windows/apps/mt270968).</span></span>

## <a name="recognize-speech-input"></a><span data-ttu-id="a69bb-114">音声入力の認識</span><span class="sxs-lookup"><span data-stu-id="a69bb-114">Recognize speech input</span></span>


<span data-ttu-id="a69bb-115">*制約*は、音声入力でアプリが認識する単語と語句 (ボキャブラリ) を定義します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-115">A *constraint* defines the words and phrases (vocabulary) that an app recognizes in speech input.</span></span> <span data-ttu-id="a69bb-116">制約は音声認識の中心であり、アプリの音声認識の精度に大きく影響します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-116">Constraints are at the core of speech recognition and give your app great over the accuracy of speech recognition.</span></span>

<span data-ttu-id="a69bb-117">音声認識の実行時には、さまざまな種類の制約を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-117">You can use various types of constraints when performing speech recognition:</span></span>

1.  <span data-ttu-id="a69bb-118">**定義済みの文法** ([**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446))。</span><span class="sxs-lookup"><span data-stu-id="a69bb-118">**Predefined grammars** ([**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446)).</span></span>

    <span data-ttu-id="a69bb-119">定義済みのディクテーション文法と Web 検索文法を使うと、文法を作らずにアプリに音声認識を実装できます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-119">Predefined dictation and web-search grammars provide speech recognition for your app without requiring you to author a grammar.</span></span> <span data-ttu-id="a69bb-120">これらの文法を使った場合、音声認識がリモート Web サービスで実行され、結果がデバイスに返されます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-120">When using these grammars, speech recognition is performed by a remote web service and the results are returned to the device.</span></span>

    <span data-ttu-id="a69bb-121">既定のフリーテキストのディクテーション文法では、ユーザーが特定の言語で話すほとんどの単語と語句を認識できます。これは短い語句の認識に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="a69bb-121">The default free-text dictation grammar can recognize most words and phrases that a user can say in a particular language, and is optimized to recognize short phrases.</span></span> <span data-ttu-id="a69bb-122">[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) オブジェクトに制約を指定しなかった場合は、定義済みのディクテーション文法が使われます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-122">The predefined dictation grammar is used if you don't specify any constraints for your [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) object.</span></span> <span data-ttu-id="a69bb-123">フリーテキストのディクテーションは、ユーザーが話す内容を限定しない場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="a69bb-123">Free-text dictation is useful when you don't want to limit the kinds of things a user can say.</span></span> <span data-ttu-id="a69bb-124">一般的な用途としては、メモの作成やメッセージ内容の口述などがあります。</span><span class="sxs-lookup"><span data-stu-id="a69bb-124">Typical uses include creating notes or dictating the content for a message.</span></span>

    <span data-ttu-id="a69bb-125">Web 検索文法は、ユーザーが話す可能性のある多数の単語と語句を含んでいる点でディクテーション文法と似ています</span><span class="sxs-lookup"><span data-stu-id="a69bb-125">The web-search grammar, like a dictation grammar, contains a large number of words and phrases that a user might say.</span></span> <span data-ttu-id="a69bb-126">ただし、ユーザーが Web 検索で一般的に使う用語の認識に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="a69bb-126">However, it is optimized to recognize terms that people typically use when searching the web.</span></span>

    <span data-ttu-id="a69bb-127">**注**  定義済みのディクテーション文法と Web 検索文法は容量が大きく、(デバイス上ではなく) オンライン上に存在するため、カスタム文法をデバイスにインストールした場合に比べるとパフォーマンスが劣る可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a69bb-127">**Note**  Because predefined dictation and web-search grammars can be large, and because they are online (not on the device), performance might not be as fast as with a custom grammar installed on the device.</span></span>     

    <span data-ttu-id="a69bb-128">このような定義済みの文法は、10 秒までの長さの音声入力を認識でき、開発者による作成作業は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="a69bb-128">These predefined grammars can be used to recognize up to 10 seconds of speech input and require no authoring effort on your part.</span></span> <span data-ttu-id="a69bb-129">ただし、ネットワークへの接続が必要になります。</span><span class="sxs-lookup"><span data-stu-id="a69bb-129">However, they do require a connection to a network.</span></span>

    <span data-ttu-id="a69bb-130">Web サービスの制約を使用するには、[設定] の [プライバシー] の [音声認識、手描き入力、入力の設定] ページで [自分を知ってもらう] をオンにして、**[設定]** で音声入力とディクテーションのサポートを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a69bb-130">To use web-service constraints, speech input and dictation support must be enabled in **Settings** by turning on the "Get to know me" option in the Settings -> Privacy -> Speech, inking, and typing page.</span></span>

    <span data-ttu-id="a69bb-131">ここでは、音声入力が有効になっているかどうかをテストし、有効になっていない場合は [設定]、[プライバシー] の [音声認識、手描き入力、入力の設定] ページを開く方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-131">Here, we show how to test whether speech input is enabled and open the Settings -> Privacy -> Speech, inking, and typing page, if not.</span></span>

    <span data-ttu-id="a69bb-132">まず、グローバル変数 (HResultPrivacyStatementDeclined) を HResult 値 0x80045509 に初期化します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-132">First, we initialize a global variable (HResultPrivacyStatementDeclined) to the HResult value of 0x80045509.</span></span> <span data-ttu-id="a69bb-133">「[C\# または Visual Basic での例外処理](https://msdn.microsoft.com/library/windows/apps/dn532194)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a69bb-133">See [Exception handling for in C\# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/dn532194).</span></span>

    ```csharp
    private static uint HResultPrivacyStatementDeclined = 0x80045509;
    ```

    <span data-ttu-id="a69bb-134">認識中に標準例外をキャッチし、[**HResult**](https://msdn.microsoft.com/library/windows/apps/br206579) 値が HResultPrivacyStatementDeclined 変数の値以下であるかどうかをテストします。</span><span class="sxs-lookup"><span data-stu-id="a69bb-134">We then catch any standard exceptions during recogntion and test if the [**HResult**](https://msdn.microsoft.com/library/windows/apps/br206579) value is equal to the value of the HResultPrivacyStatementDeclined variable.</span></span> <span data-ttu-id="a69bb-135">該当する場合は、警告を表示し、`await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts"));` を呼び出して [設定] ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-135">If so, we display a warning and call `await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts"));` to open the Settings page.</span></span>
    
    ```csharp
    catch (Exception exception)
    {
      // Handle the speech privacy policy error.
      if ((uint)exception.HResult == HResultPrivacyStatementDeclined)
      {
        resultTextBlock.Visibility = Visibility.Visible;
        resultTextBlock.Text = "The privacy statement was declined." + 
          "Go to Settings -> Privacy -> Speech, inking and typing, and ensure you" +
          "have viewed the privacy policy, and 'Get To Know You' is enabled.";
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

2.  <span data-ttu-id="a69bb-136">**プログラムによる一覧の制約** ([**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421))</span><span class="sxs-lookup"><span data-stu-id="a69bb-136">**Programmatic list constraints** ([**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421)).</span></span>

    <span data-ttu-id="a69bb-137">プログラムによる一覧の制約は、単語や語句の一覧を使って単純な文法を作成する手法で、軽量です。</span><span class="sxs-lookup"><span data-stu-id="a69bb-137">Programmatic list constraints provide a lightweight approach to creating simple grammars using a list of words or phrases.</span></span> <span data-ttu-id="a69bb-138">個別の短い語句を認識するには、一覧の制約が適しています。</span><span class="sxs-lookup"><span data-stu-id="a69bb-138">A list constraint works well for recognizing short, distinct phrases.</span></span> <span data-ttu-id="a69bb-139">文法にすべての単語を明示的に指定すると、音声認識エンジンは音声と単語の一致を確認する際に音声だけを処理すればよいので、認識の精度が向上します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-139">Explicitly specifying all words in a grammar also improves recognition accuracy, as the speech recognition engine must only process speech to confirm a match.</span></span> <span data-ttu-id="a69bb-140">また、一覧はプログラムで更新することもできます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-140">The list can also be programmatically updated.</span></span>

    <span data-ttu-id="a69bb-141">一覧の制約は、アプリで認識操作に利用できる音声入力を表した文字列の配列で構成されます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-141">A list constraint consists of an array of strings that represents speech input that your app will accept for a recognition operation.</span></span> <span data-ttu-id="a69bb-142">アプリで一覧の制約を作成するには、音声認識の一覧の制約オブジェクトを作って、文字列の配列を渡します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-142">You can create a list constraint in your app by creating a speech-recognition list-constraint object and passing an array of strings.</span></span> <span data-ttu-id="a69bb-143">次に、そのオブジェクトを認識エンジンの制約コレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-143">Then, add that object to the constraints collection of the recognizer.</span></span> <span data-ttu-id="a69bb-144">音声認識エンジンが配列内の文字列のどれかを認識したら、認識は成功です。</span><span class="sxs-lookup"><span data-stu-id="a69bb-144">Recognition is successful when the speech recognizer recognizes any one of the strings in the array.</span></span>

3.  <span data-ttu-id="a69bb-145">**SRGS 文法**([**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412))</span><span class="sxs-lookup"><span data-stu-id="a69bb-145">**SRGS grammars** ([**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)).</span></span>

    <span data-ttu-id="a69bb-146">Speech Recognition Grammar Specification (SRGS) 文法は静的ドキュメントで、プログラムによる一覧の制約とは異なり、[SRGS Version 1.0](http://go.microsoft.com/fwlink/p/?LinkID=262302) で定義された XML 形式を使います。</span><span class="sxs-lookup"><span data-stu-id="a69bb-146">An Speech Recognition Grammar Specification (SRGS) grammar is a static document that, unlike a programmatic list constraint, uses the XML format defined by the [SRGS Version 1.0](http://go.microsoft.com/fwlink/p/?LinkID=262302).</span></span> <span data-ttu-id="a69bb-147">SRGS 文法では、1 回の認識で複数の意味をキャプチャすることができるため、音声認識エクスペリエンスを最大限に制御することができます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-147">An SRGS grammar provides the greatest control over the speech recognition experience by letting you capture multiple semantic meanings in a single recognition.</span></span>

4.  <span data-ttu-id="a69bb-148">**音声コマンドの制約** ([**SpeechRecognitionVoiceCommandDefinitionConstraint**](https://msdn.microsoft.com/library/windows/apps/dn653220))</span><span class="sxs-lookup"><span data-stu-id="a69bb-148">**Voice command constraints** ([**SpeechRecognitionVoiceCommandDefinitionConstraint**](https://msdn.microsoft.com/library/windows/apps/dn653220))</span></span>

    <span data-ttu-id="a69bb-149">音声コマンド定義 (VCD) XML ファイルを使って、アプリをアクティブ化して操作を開始するためにユーザーが発声できる音声コマンドを定義します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-149">Use a Voice Command Definition (VCD) XML file to define the commands that the user can say to initiate actions when activating your app.</span></span> <span data-ttu-id="a69bb-150">詳しくは、「[Cortana の音声コマンドを使ったフォアグラウンド アプリの起動](launch-a-foreground-app-with-voice-commands-in-cortana.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a69bb-150">For more detail, see [Launch a foreground app with voice commands in Cortana](launch-a-foreground-app-with-voice-commands-in-cortana.md).</span></span>

<span data-ttu-id="a69bb-151">**注**  どの種類の制約を使うかは、作成する認識エクスペリエンスの複雑さによって決まります。</span><span class="sxs-lookup"><span data-stu-id="a69bb-151">**Note**  Which type of constraint type you use depends on the complexity of the recognition experience you want to create.</span></span> <span data-ttu-id="a69bb-152">どの種類の制約も特定の認識タスクに最適な選択肢となる可能性があり、アプリですべての種類の制約を使う場合もあります。</span><span class="sxs-lookup"><span data-stu-id="a69bb-152">Any could be the best choice for a specific recognition task, and you might find uses for all types of constraints in your app.</span></span>
<span data-ttu-id="a69bb-153">制約を使う場合は、「[カスタム認識の制約の定義](define-custom-recognition-constraints.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a69bb-153">To get started with constraints, see [Define custom recognition constraints](define-custom-recognition-constraints.md).</span></span>

 

<span data-ttu-id="a69bb-154">ユニバーサル Windows アプリで定義済みのディクテーション文法によって、言語のほとんどの単語と短い語句が認識されます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-154">The predefined Universal Windows app dictation grammar recognizes most words and short phrases in a language.</span></span> <span data-ttu-id="a69bb-155">これは、カスタム制約なしで音声認識エンジン オブジェクトをインスタンス化すると既定で有効になります。</span><span class="sxs-lookup"><span data-stu-id="a69bb-155">It is activated by default when a speech recognizer object is instantiated without custom constraints.</span></span>

<span data-ttu-id="a69bb-156">この例では、以下の操作を行う方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-156">In this example, we show how to:</span></span>

-   <span data-ttu-id="a69bb-157">音声認識エンジンを作成します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-157">Create a speech recognizer.</span></span>
-   <span data-ttu-id="a69bb-158">既定のユニバーサル Windows アプリ制約をコンパイルします (音声認識エンジンの文法セットには文法が追加されていません)。</span><span class="sxs-lookup"><span data-stu-id="a69bb-158">Compile the default Universal Windows app constraints (no grammars have been added to the speech recognizer's grammar set).</span></span>
-   <span data-ttu-id="a69bb-159">[**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) メソッドに用意された基本的な認識 UI と TTS フィードバックを使って音声の聞き取りを開始します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-159">Start listening for speech by using the basic recognition UI and TTS feedback provided by the [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) method.</span></span> <span data-ttu-id="a69bb-160">既定の UI が必要でない場合は、[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="a69bb-160">Use the [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) method if the default UI is not required.</span></span>

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

## <a name="customize-the-recognition-ui"></a><span data-ttu-id="a69bb-161">認識 UI をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="a69bb-161">Customize the recognition UI</span></span>


<span data-ttu-id="a69bb-162">アプリが [**SpeechRecognizer.RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) を呼び出して音声認識を試みると、複数の画面が次の順序で表示されます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-162">When your app attempts speech recognition by calling [**SpeechRecognizer.RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245), several screens are shown in the following order.</span></span>

<span data-ttu-id="a69bb-163">定義済みの文法に基づく制約を使っている場合 (ディクテーションまたは Web 検索):</span><span class="sxs-lookup"><span data-stu-id="a69bb-163">If you're using a constraint based on a predefined grammar (dictation or web search):</span></span>

-   <span data-ttu-id="a69bb-164">**[聞き取り中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="a69bb-164">The **Listening** screen.</span></span>
-   <span data-ttu-id="a69bb-165">**[認識中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="a69bb-165">The **Thinking** screen.</span></span>
-   <span data-ttu-id="a69bb-166">**[聞き取りの確認]** 画面またはエラー画面。</span><span class="sxs-lookup"><span data-stu-id="a69bb-166">The **Heard you say** screen or the error screen.</span></span>

<span data-ttu-id="a69bb-167">単語や語句の一覧に基づく制約、または、SGRS 文法ファイルに基づく制約を使っている場合:</span><span class="sxs-lookup"><span data-stu-id="a69bb-167">If you're using a constraint based on a list of words or phrases, or a constraint based on a SRGS grammar file:</span></span>

-   <span data-ttu-id="a69bb-168">**[聞き取り中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="a69bb-168">The **Listening** screen.</span></span>
-   <span data-ttu-id="a69bb-169">**[確認]** 画面 (ユーザーの発言が複数の潜在的な結果として解釈できる場合)。</span><span class="sxs-lookup"><span data-stu-id="a69bb-169">The **Did you say** screen, if what the user said could be interpreted as more than one potential result.</span></span>
-   <span data-ttu-id="a69bb-170">**[聞き取りの確認]** 画面またはエラー画面。</span><span class="sxs-lookup"><span data-stu-id="a69bb-170">The **Heard you say** screen or the error screen.</span></span>

<span data-ttu-id="a69bb-171">次の図に、SGRS 文法ファイルに基づく制約を使う音声認識エンジンの画面間のフロー例を示します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-171">The following image shows an example of the flow between screens for a speech recognizer that uses a constraint based on a SRGS grammar file.</span></span> <span data-ttu-id="a69bb-172">この例では、音声認識に成功しています。</span><span class="sxs-lookup"><span data-stu-id="a69bb-172">In this example, speech recognition was successful.</span></span>

![SGRS 文法ファイルに基づく制約の場合の、最初の認識画面](images/speech-listening-initial.png)

![SGRS 文法ファイルに基づく制約の場合の、途中の認識画面](images/speech-listening-intermediate.png)

![SGRS 文法ファイルに基づく制約の場合の、最終的な認識画面](images/speech-listening-complete.png)

<span data-ttu-id="a69bb-176">**[聞き取り中]** 画面では、アプリが認識できる単語または語句の例を表示できます。</span><span class="sxs-lookup"><span data-stu-id="a69bb-176">The **Listening** screen can provide examples of words or phrases that the app can recognize.</span></span> <span data-ttu-id="a69bb-177">ここでは、[**SpeechRecognizerUIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653234) クラス ([**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) プロパティを呼び出して取得する) のプロパティを使って **[聞き取り中]** 画面のコンテンツをカスタマイズする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a69bb-177">Here, we show how to use the properties of the [**SpeechRecognizerUIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653234) class (obtained by calling the [**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) property) to customize content on the **Listening** screen.</span></span>

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
    speechRecognizer.UIOptions.ExampleText = @"Ex. 'weather for London'";
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

## <a name="related-articles"></a><span data-ttu-id="a69bb-178">関連記事</span><span class="sxs-lookup"><span data-stu-id="a69bb-178">Related articles</span></span>


**<span data-ttu-id="a69bb-179">開発者向け</span><span class="sxs-lookup"><span data-stu-id="a69bb-179">Developers</span></span>**
* <span data-ttu-id="a69bb-180">[音声操作](speech-interactions.md)
**デザイナー向け**</span><span class="sxs-lookup"><span data-stu-id="a69bb-180">[Speech interactions](speech-interactions.md)
**Designers**</span></span>
* <span data-ttu-id="a69bb-181">[音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)
**サンプル**</span><span class="sxs-lookup"><span data-stu-id="a69bb-181">[Speech design guidelines](https://msdn.microsoft.com/library/windows/apps/dn596121)
**Samples**</span></span>
* [<span data-ttu-id="a69bb-182">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="a69bb-182">Speech recognition and speech synthesis sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




