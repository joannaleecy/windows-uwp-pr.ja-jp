---
Description: 音声認識を使って、入力を行ったり、操作やコマンドを指定したり、タスクを実行したりできます。
title: 音声認識
ms.assetid: 553C0FB7-35BC-4894-9EF1-906139E17552
label: Speech recognition
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.date: 10/25/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1b7eec51044a70b0738e246d3aa516c37643cf68
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608077"
---
# <a name="speech-recognition"></a><span data-ttu-id="1f264-104">音声認識</span><span class="sxs-lookup"><span data-stu-id="1f264-104">Speech recognition</span></span>


<span data-ttu-id="1f264-105">音声認識を使って、入力を行ったり、操作やコマンドを指定したり、タスクを実行したりできます。</span><span class="sxs-lookup"><span data-stu-id="1f264-105">Use speech recognition to provide input, specify an action or command, and accomplish tasks.</span></span>

> <span data-ttu-id="1f264-106">**重要な Api**:[**Windows.Media.SpeechRecognition**](https://msdn.microsoft.com/library/windows/apps/dn653262)</span><span class="sxs-lookup"><span data-stu-id="1f264-106">**Important APIs**: [**Windows.Media.SpeechRecognition**](https://msdn.microsoft.com/library/windows/apps/dn653262)</span></span>

<span data-ttu-id="1f264-107">音声認識機能は、音声認識ランタイム、ランタイムをプログラミングするための認識 API、ディクテーションと Web 検索のための定義済みの文法、ユーザーが音声認識機能を見つけて使うときに役立つ既定のシステム UI で構成されています。</span><span class="sxs-lookup"><span data-stu-id="1f264-107">Speech recognition is made up of a speech runtime, recognition APIs for programming the runtime, ready-to-use grammars for dictation and web search, and a default system UI that helps users discover and use speech recognition features.</span></span>

## <a name="configure-speech-recognition"></a><span data-ttu-id="1f264-108">音声認識を構成します。</span><span class="sxs-lookup"><span data-stu-id="1f264-108">Configure speech recognition</span></span>

<span data-ttu-id="1f264-109">ユーザーが接続する必要があります、アプリと音声認識をサポートするには、自分のデバイスのマイクを有効にするし、それを使用するには、Microsoft プライバシー ポリシーがアプリのアクセス許可を付与に同意します。</span><span class="sxs-lookup"><span data-stu-id="1f264-109">To support speech recognition with your app, the user must connect and enable a microphone on their device, and accept the Microsoft Privacy Policy granting permission for your app to use it.</span></span>

<span data-ttu-id="1f264-110">自動的にユーザーにアクセスして、マイクのオーディオ フィードを使用するためのアクセス許可を要求するシステム ダイアログを確認する (例から、[音声認識と音声合成のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619897)次に示す) に設定した、 **マイク**[デバイス機能](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-devicecapability)で、[アプリ パッケージのマニフェスト](https://docs.microsoft.com/uwp/schemas/appxpackage/appx-package-manifest)します。</span><span class="sxs-lookup"><span data-stu-id="1f264-110">To automatically prompt the user with a system dialog requesting permission to access and use the microphone's audio feed (example from the [Speech recognition and speech synthesis sample](https://go.microsoft.com/fwlink/p/?LinkID=619897) shown below), just set the **Microphone** [device capability](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-devicecapability) in the [App package manifest](https://docs.microsoft.com/uwp/schemas/appxpackage/appx-package-manifest).</span></span> <span data-ttu-id="1f264-111">詳細については、[アプリ機能の宣言](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1f264-111">For more detail, see [App capability declarations](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations).</span></span>

![マイクへのアクセスのプライバシー ポリシー](images/speech/privacy.png)

<span data-ttu-id="1f264-113">ユーザーが承認済みのアプリケーションの設定の一覧にアプリを追加、マイクへのアクセスを許可するには、はい をクリックした場合は、プライバシー-> マイクのページ-> です。</span><span class="sxs-lookup"><span data-stu-id="1f264-113">If the user clicks Yes to grant access to the microphone, your app is added to the list of approved applications on the Settings -> Privacy -> Microphone page.</span></span> <span data-ttu-id="1f264-114">ただし、この設定はいつでもオフにするユーザーを選択できるように、アプリが使用する前に、マイクへのアクセスが確認してください。</span><span class="sxs-lookup"><span data-stu-id="1f264-114">However, as the user can choose to turn this setting off at any time, you should confirm that your app has access to the microphone before attempting to use it.</span></span>

<span data-ttu-id="1f264-115">ディクテーション、Cortana、またはその他の音声認識サービスをサポートする場合 (など、[定義済みの文法](#predefined-grammars)トピック制約で定義されている)、ことを確認する必要があります**オンライン音声認識**(設定]、[プライバシー] メニューの [Speech) を有効にします。</span><span class="sxs-lookup"><span data-stu-id="1f264-115">If you also want to support dictation, Cortana, or other speech recognition services (such as a [predefined grammar](#predefined-grammars) defined in a topic constraint), you must also confirm that **Online speech recognition** (Settings -> Privacy -> Speech) is enabled.</span></span>

<span data-ttu-id="1f264-116">このスニペットでは、アプリがマイクが存在する場合、また使用する権限がある場合を確認する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1f264-116">This snippet shows how your app can check if a microphone is present and if it has permission to use it.</span></span>

```csharp
public class AudioCapturePermissions
{
    // If no microphone is present, an exception is thrown with the following HResult value.
    private static int NoCaptureDevicesHResult = -1072845856;

    /// <summary>
    /// Note that this method only checks the Settings->Privacy->Microphone setting, it does not handle
    /// the Cortana/Dictation privacy check.
    ///
    /// You should perform this check every time the app gets focus, in case the user has changed
    /// the setting while the app was suspended or not in focus.
    /// </summary>
    /// <returns>True, if the microphone is available.</returns>
    public async static Task<bool> RequestMicrophonePermission()
    {
        try
        {
            // Request access to the audio capture device.
            MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings();
            settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
            settings.MediaCategory = MediaCategory.Speech;
            MediaCapture capture = new MediaCapture();

            await capture.InitializeAsync(settings);
        }
        catch (TypeLoadException)
        {
            // Thrown when a media player is not available.
            var messageDialog = new Windows.UI.Popups.MessageDialog("Media player components are unavailable.");
            await messageDialog.ShowAsync();
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            // Thrown when permission to use the audio capture device is denied.
            // If this occurs, show an error or disable recognition functionality.
            return false;
        }
        catch (Exception exception)
        {
            // Thrown when an audio capture device is not present.
            if (exception.HResult == NoCaptureDevicesHResult)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("No Audio Capture devices are present on this system.");
                await messageDialog.ShowAsync();
                return false;
            }
            else
            {
                throw;
            }
        }
        return true;
    }
}
```

```cpp
/// <summary>
/// Note that this method only checks the Settings->Privacy->Microphone setting, it does not handle
/// the Cortana/Dictation privacy check.
///
/// You should perform this check every time the app gets focus, in case the user has changed
/// the setting while the app was suspended or not in focus.
/// </summary>
/// <returns>True, if the microphone is available.</returns>
IAsyncOperation<bool>^  AudioCapturePermissions::RequestMicrophonePermissionAsync()
{
    return create_async([]() 
    {
        try
        {
            // Request access to the audio capture device.
            MediaCaptureInitializationSettings^ settings = ref new MediaCaptureInitializationSettings();
            settings->StreamingCaptureMode = StreamingCaptureMode::Audio;
            settings->MediaCategory = MediaCategory::Speech;
            MediaCapture^ capture = ref new MediaCapture();

            return create_task(capture->InitializeAsync(settings))
                .then([](task<void> previousTask) -> bool
            {
                try
                {
                    previousTask.get();
                }
                catch (AccessDeniedException^)
                {
                    // Thrown when permission to use the audio capture device is denied.
                    // If this occurs, show an error or disable recognition functionality.
                    return false;
                }
                catch (Exception^ exception)
                {
                    // Thrown when an audio capture device is not present.
                    if (exception->HResult == AudioCapturePermissions::NoCaptureDevicesHResult)
                    {
                        auto messageDialog = ref new Windows::UI::Popups::MessageDialog("No Audio Capture devices are present on this system.");
                        create_task(messageDialog->ShowAsync());
                        return false;
                    }

                    throw;
                }
                return true;
            });
        }
        catch (Platform::ClassNotRegisteredException^ ex)
        {
            // Thrown when a media player is not available. 
            auto messageDialog = ref new Windows::UI::Popups::MessageDialog("Media Player Components unavailable.");
            create_task(messageDialog->ShowAsync());
            return create_task([] {return false; });
        }
    });
}
```

```js
var AudioCapturePermissions = WinJS.Class.define(
    function () { }, {},
    {
        requestMicrophonePermission: function () {
            /// <summary>
            /// Note that this method only checks the Settings->Privacy->Microphone setting, it does not handle
            /// the Cortana/Dictation privacy check.
            ///
            /// You should perform this check every time the app gets focus, in case the user has changed
            /// the setting while the app was suspended or not in focus.
            /// </summary>
            /// <returns>True, if the microphone is available.</returns>
            return new WinJS.Promise(function (completed, error) {

                try {
                    // Request access to the audio capture device.
                    var captureSettings = new Windows.Media.Capture.MediaCaptureInitializationSettings();
                    captureSettings.streamingCaptureMode = Windows.Media.Capture.StreamingCaptureMode.audio;
                    captureSettings.mediaCategory = Windows.Media.Capture.MediaCategory.speech;

                    var capture = new Windows.Media.Capture.MediaCapture();
                    capture.initializeAsync(captureSettings).then(function () {
                        completed(true);
                    },
                    function (error) {
                        // Audio Capture can fail to initialize if there's no audio devices on the system, or if
                        // the user has disabled permission to access the microphone in the Privacy settings.
                        if (error.number == -2147024891) { // Access denied (microphone disabled in settings)
                            completed(false);
                        } else if (error.number == -1072845856) { // No recording device present.
                            var messageDialog = new Windows.UI.Popups.MessageDialog("No Audio Capture devices are present on this system.");
                            messageDialog.showAsync();
                            completed(false);
                        } else {
                            error(error);
                        }
                    });
                } catch (exception) {
                    if (exception.number == -2147221164) { // REGDB_E_CLASSNOTREG
                        var messageDialog = new Windows.UI.Popups.MessageDialog("Media Player components not available on this system.");
                        messageDialog.showAsync();
                        return false;
                    }
                }
            });
        }
    })
```

## <a name="recognize-speech-input"></a><span data-ttu-id="1f264-117">音声入力の認識</span><span class="sxs-lookup"><span data-stu-id="1f264-117">Recognize speech input</span></span>

<span data-ttu-id="1f264-118">*制約*は、音声入力でアプリが認識する単語と語句 (ボキャブラリ) を定義します。</span><span class="sxs-lookup"><span data-stu-id="1f264-118">A *constraint* defines the words and phrases (vocabulary) that an app recognizes in speech input.</span></span> <span data-ttu-id="1f264-119">制約は音声認識の中心であり、アプリの音声認識の精度に大きく影響します。</span><span class="sxs-lookup"><span data-stu-id="1f264-119">Constraints are at the core of speech recognition and give your app greater over the accuracy of speech recognition.</span></span>

<span data-ttu-id="1f264-120">音声入力を認識するため、次の種類の制約を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="1f264-120">You can use the following types of constraints for recognizing speech input.</span></span>

### <a name="predefined-grammars"></a><span data-ttu-id="1f264-121">定義済みの文法</span><span class="sxs-lookup"><span data-stu-id="1f264-121">Predefined grammars</span></span>

<span data-ttu-id="1f264-122">定義済みのディクテーション文法と Web 検索文法を使うと、文法を作らずにアプリに音声認識を実装できます。</span><span class="sxs-lookup"><span data-stu-id="1f264-122">Predefined dictation and web-search grammars provide speech recognition for your app without requiring you to author a grammar.</span></span> <span data-ttu-id="1f264-123">これらの文法を使った場合、音声認識がリモート Web サービスで実行され、結果がデバイスに返されます。</span><span class="sxs-lookup"><span data-stu-id="1f264-123">When using these grammars, speech recognition is performed by a remote web service and the results are returned to the device.</span></span>

<span data-ttu-id="1f264-124">既定のフリーテキストのディクテーション文法では、ユーザーが特定の言語で話すほとんどの単語と語句を認識できます。これは短い語句の認識に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="1f264-124">The default free-text dictation grammar can recognize most words and phrases that a user can say in a particular language, and is optimized to recognize short phrases.</span></span> <span data-ttu-id="1f264-125">[  **SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) オブジェクトに制約を指定しなかった場合は、定義済みのディクテーション文法が使われます。</span><span class="sxs-lookup"><span data-stu-id="1f264-125">The predefined dictation grammar is used if you don't specify any constraints for your [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) object.</span></span> <span data-ttu-id="1f264-126">フリーテキストのディクテーションは、ユーザーが話す内容を限定しない場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="1f264-126">Free-text dictation is useful when you don't want to limit the kinds of things a user can say.</span></span> <span data-ttu-id="1f264-127">一般的な用途としては、メモの作成やメッセージ内容の口述などがあります。</span><span class="sxs-lookup"><span data-stu-id="1f264-127">Typical uses include creating notes or dictating the content for a message.</span></span>

<span data-ttu-id="1f264-128">Web 検索文法は、ユーザーが話す可能性のある多数の単語と語句を含んでいる点でディクテーション文法と似ています</span><span class="sxs-lookup"><span data-stu-id="1f264-128">The web-search grammar, like a dictation grammar, contains a large number of words and phrases that a user might say.</span></span> <span data-ttu-id="1f264-129">ただし、ユーザーが Web 検索で一般的に使う用語の認識に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="1f264-129">However, it is optimized to recognize terms that people typically use when searching the web.</span></span>

<span data-ttu-id="1f264-130">**注**  オンラインでは、定義済みの音声入力と web 検索の文法が大きくなるため、(デバイス) ではなくパフォーマンスできない可能性があります、デバイスにインストールされているカスタムの文法と同様に高速です。</span><span class="sxs-lookup"><span data-stu-id="1f264-130">**Note**  Because predefined dictation and web-search grammars can be large, and because they are online (not on the device), performance might not be as fast as with a custom grammar installed on the device.</span></span>     

<span data-ttu-id="1f264-131">このような定義済みの文法は、10 秒までの長さの音声入力を認識でき、開発者による作成作業は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="1f264-131">These predefined grammars can be used to recognize up to 10 seconds of speech input and require no authoring effort on your part.</span></span> <span data-ttu-id="1f264-132">ただし、ネットワークへの接続が必要になります。</span><span class="sxs-lookup"><span data-stu-id="1f264-132">However, they do require a connection to a network.</span></span>

<span data-ttu-id="1f264-133">Web サービスの制約を使用するには、**[設定] -> [プライバシー] -> [音声認識、手描き入力、入力の設定]** で [自分を知ってもらう] オプションをオンにして、**[設定]** で音声入力とディクテーションのサポートを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f264-133">To use web-service constraints, speech input and dictation support must be enabled in **Settings** by turning on the "Get to know me" option in  **Settings -> Privacy -> Speech, inking, and typing**.</span></span>

<span data-ttu-id="1f264-134">ここでは、音声入力が有効になっているかどうかをテストし、有効になっていない場合は [設定]、[プライバシー] の [音声認識、手描き入力、入力の設定] ページを開く方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1f264-134">Here, we show how to test whether speech input is enabled and open the Settings -> Privacy -> Speech, inking, and typing page, if not.</span></span>

<span data-ttu-id="1f264-135">まず、グローバル変数 (HResultPrivacyStatementDeclined) を HResult 値 0x80045509 に初期化します。</span><span class="sxs-lookup"><span data-stu-id="1f264-135">First, we initialize a global variable (HResultPrivacyStatementDeclined) to the HResult value of 0x80045509.</span></span> <span data-ttu-id="1f264-136">参照してください[例外 C での処理\#または Visual Basic](https://msdn.microsoft.com/library/windows/apps/dn532194)します。</span><span class="sxs-lookup"><span data-stu-id="1f264-136">See [Exception handling for in C\# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/dn532194).</span></span>

```csharp
private static uint HResultPrivacyStatementDeclined = 0x80045509;
```

<span data-ttu-id="1f264-137">認識中に標準例外をキャッチし、[**HResult**](https://msdn.microsoft.com/library/windows/apps/br206579) 値が HResultPrivacyStatementDeclined 変数の値以下であるかどうかをテストします。</span><span class="sxs-lookup"><span data-stu-id="1f264-137">We then catch any standard exceptions during recogntion and test if the [**HResult**](https://msdn.microsoft.com/library/windows/apps/br206579) value is equal to the value of the HResultPrivacyStatementDeclined variable.</span></span> <span data-ttu-id="1f264-138">該当する場合は、警告を表示し、`await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts"));` を呼び出して [設定] ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="1f264-138">If so, we display a warning and call `await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts"));` to open the Settings page.</span></span>

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

<span data-ttu-id="1f264-139">参照してください[ **SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446)します。</span><span class="sxs-lookup"><span data-stu-id="1f264-139">See [**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446).</span></span>

### <a name="programmatic-list-constraints"></a><span data-ttu-id="1f264-140">プログラムの一覧の制約</span><span class="sxs-lookup"><span data-stu-id="1f264-140">Programmatic list constraints</span></span> 

<span data-ttu-id="1f264-141">プログラムによる一覧の制約は、単語や語句の一覧を使って単純な文法を作成する手法で、軽量です。</span><span class="sxs-lookup"><span data-stu-id="1f264-141">Programmatic list constraints provide a lightweight approach to creating simple grammars using a list of words or phrases.</span></span> <span data-ttu-id="1f264-142">個別の短い語句を認識するには、一覧の制約が適しています。</span><span class="sxs-lookup"><span data-stu-id="1f264-142">A list constraint works well for recognizing short, distinct phrases.</span></span> <span data-ttu-id="1f264-143">文法にすべての単語を明示的に指定すると、音声認識エンジンは音声と単語の一致を確認する際に音声だけを処理すればよいので、認識の精度が向上します。</span><span class="sxs-lookup"><span data-stu-id="1f264-143">Explicitly specifying all words in a grammar also improves recognition accuracy, as the speech recognition engine must only process speech to confirm a match.</span></span> <span data-ttu-id="1f264-144">また、一覧はプログラムで更新することもできます。</span><span class="sxs-lookup"><span data-stu-id="1f264-144">The list can also be programmatically updated.</span></span>

<span data-ttu-id="1f264-145">一覧の制約は、アプリで認識操作に利用できる音声入力を表した文字列の配列で構成されます。</span><span class="sxs-lookup"><span data-stu-id="1f264-145">A list constraint consists of an array of strings that represents speech input that your app will accept for a recognition operation.</span></span> <span data-ttu-id="1f264-146">アプリで一覧の制約を作成するには、音声認識の一覧の制約オブジェクトを作って、文字列の配列を渡します。</span><span class="sxs-lookup"><span data-stu-id="1f264-146">You can create a list constraint in your app by creating a speech-recognition list-constraint object and passing an array of strings.</span></span> <span data-ttu-id="1f264-147">次に、そのオブジェクトを認識エンジンの制約コレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="1f264-147">Then, add that object to the constraints collection of the recognizer.</span></span> <span data-ttu-id="1f264-148">音声認識エンジンが配列内の文字列のどれかを認識したら、認識は成功です。</span><span class="sxs-lookup"><span data-stu-id="1f264-148">Recognition is successful when the speech recognizer recognizes any one of the strings in the array.</span></span>

<span data-ttu-id="1f264-149">参照してください[ **SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421)します。</span><span class="sxs-lookup"><span data-stu-id="1f264-149">See [**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421).</span></span>

### <a name="srgs-grammars"></a><span data-ttu-id="1f264-150">SRGS 文法</span><span class="sxs-lookup"><span data-stu-id="1f264-150">SRGS grammars</span></span>

<span data-ttu-id="1f264-151">Speech Recognition Grammar Specification (SRGS) 文法は静的ドキュメントで、プログラムによる一覧の制約とは異なり、[SRGS Version 1.0](https://go.microsoft.com/fwlink/p/?LinkID=262302) で定義された XML 形式を使います。</span><span class="sxs-lookup"><span data-stu-id="1f264-151">An Speech Recognition Grammar Specification (SRGS) grammar is a static document that, unlike a programmatic list constraint, uses the XML format defined by the [SRGS Version 1.0](https://go.microsoft.com/fwlink/p/?LinkID=262302).</span></span> <span data-ttu-id="1f264-152">SRGS 文法では、1 回の認識で複数の意味をキャプチャすることができるため、音声認識エクスペリエンスを最大限に制御することができます。</span><span class="sxs-lookup"><span data-stu-id="1f264-152">An SRGS grammar provides the greatest control over the speech recognition experience by letting you capture multiple semantic meanings in a single recognition.</span></span>

 <span data-ttu-id="1f264-153">参照してください[ **SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)します。</span><span class="sxs-lookup"><span data-stu-id="1f264-153">See [**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412).</span></span>

### <a name="voice-command-constraints"></a><span data-ttu-id="1f264-154">音声コマンドの制約</span><span class="sxs-lookup"><span data-stu-id="1f264-154">Voice command constraints</span></span>

<span data-ttu-id="1f264-155">音声コマンド定義 (VCD) XML ファイルを使って、アプリをアクティブ化して操作を開始するためにユーザーが発声できる音声コマンドを定義します。</span><span class="sxs-lookup"><span data-stu-id="1f264-155">Use a Voice Command Definition (VCD) XML file to define the commands that the user can say to initiate actions when activating your app.</span></span> <span data-ttu-id="1f264-156">詳しくは、「[Cortana の音声コマンドを使ったフォアグラウンド アプリの起動](https://msdn.microsoft.com/cortana/voicecommands/launch-a-foreground-app-with-voice-commands-in-cortana)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1f264-156">For more detail, see [Launch a foreground app with voice commands in Cortana](https://msdn.microsoft.com/cortana/voicecommands/launch-a-foreground-app-with-voice-commands-in-cortana).</span></span>

<span data-ttu-id="1f264-157">参照してください[ **SpeechRecognitionVoiceCommandDefinitionConstraint**](https://msdn.microsoft.com/library/windows/apps/dn653220)/</span><span class="sxs-lookup"><span data-stu-id="1f264-157">See [**SpeechRecognitionVoiceCommandDefinitionConstraint**](https://msdn.microsoft.com/library/windows/apps/dn653220)/</span></span>

<span data-ttu-id="1f264-158">**注**  の制約の種類を使用する型を作成する認識エクスペリエンスの複雑さに依存します。</span><span class="sxs-lookup"><span data-stu-id="1f264-158">**Note**  The type of constraint type you use depends on the complexity of the recognition experience you want to create.</span></span> <span data-ttu-id="1f264-159">どの種類の制約も特定の認識タスクに最適な選択肢となる可能性があり、アプリですべての種類の制約を使う場合もあります。</span><span class="sxs-lookup"><span data-stu-id="1f264-159">Any could be the best choice for a specific recognition task, and you might find uses for all types of constraints in your app.</span></span>
<span data-ttu-id="1f264-160">制約を使う場合は、「[カスタム認識の制約の定義](define-custom-recognition-constraints.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1f264-160">To get started with constraints, see [Define custom recognition constraints](define-custom-recognition-constraints.md).</span></span>

<span data-ttu-id="1f264-161">ユニバーサル Windows アプリで定義済みのディクテーション文法によって、言語のほとんどの単語と短い語句が認識されます。</span><span class="sxs-lookup"><span data-stu-id="1f264-161">The predefined Universal Windows app dictation grammar recognizes most words and short phrases in a language.</span></span> <span data-ttu-id="1f264-162">これは、カスタム制約なしで音声認識エンジン オブジェクトをインスタンス化すると既定で有効になります。</span><span class="sxs-lookup"><span data-stu-id="1f264-162">It is activated by default when a speech recognizer object is instantiated without custom constraints.</span></span>

<span data-ttu-id="1f264-163">この例では、以下の操作を行う方法を示します。</span><span class="sxs-lookup"><span data-stu-id="1f264-163">In this example, we show how to:</span></span>

- <span data-ttu-id="1f264-164">音声認識エンジンを作成します。</span><span class="sxs-lookup"><span data-stu-id="1f264-164">Create a speech recognizer.</span></span>
- <span data-ttu-id="1f264-165">既定のユニバーサル Windows アプリ制約をコンパイルします (音声認識エンジンの文法セットには文法が追加されていません)。</span><span class="sxs-lookup"><span data-stu-id="1f264-165">Compile the default Universal Windows app constraints (no grammars have been added to the speech recognizer's grammar set).</span></span>
- <span data-ttu-id="1f264-166">[  **RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) メソッドに用意された基本的な認識 UI と TTS フィードバックを使って音声の聞き取りを開始します。</span><span class="sxs-lookup"><span data-stu-id="1f264-166">Start listening for speech by using the basic recognition UI and TTS feedback provided by the [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) method.</span></span> <span data-ttu-id="1f264-167">既定の UI が必要でない場合は、[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="1f264-167">Use the [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) method if the default UI is not required.</span></span>

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

## <a name="customize-the-recognition-ui"></a><span data-ttu-id="1f264-168">認識 UI をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="1f264-168">Customize the recognition UI</span></span>


<span data-ttu-id="1f264-169">アプリが [**SpeechRecognizer.RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) を呼び出して音声認識を試みると、複数の画面が次の順序で表示されます。</span><span class="sxs-lookup"><span data-stu-id="1f264-169">When your app attempts speech recognition by calling [**SpeechRecognizer.RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245), several screens are shown in the following order.</span></span>

<span data-ttu-id="1f264-170">定義済みの文法に基づく制約を使っている場合 (ディクテーションまたは Web 検索):</span><span class="sxs-lookup"><span data-stu-id="1f264-170">If you're using a constraint based on a predefined grammar (dictation or web search):</span></span>

-   <span data-ttu-id="1f264-171">**[聞き取り中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="1f264-171">The **Listening** screen.</span></span>
-   <span data-ttu-id="1f264-172">**[認識中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="1f264-172">The **Thinking** screen.</span></span>
-   <span data-ttu-id="1f264-173">**[聞き取りの確認]** 画面またはエラー画面。</span><span class="sxs-lookup"><span data-stu-id="1f264-173">The **Heard you say** screen or the error screen.</span></span>

<span data-ttu-id="1f264-174">単語や語句の一覧に基づく制約、または、SGRS 文法ファイルに基づく制約を使っている場合:</span><span class="sxs-lookup"><span data-stu-id="1f264-174">If you're using a constraint based on a list of words or phrases, or a constraint based on a SRGS grammar file:</span></span>

-   <span data-ttu-id="1f264-175">**[聞き取り中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="1f264-175">The **Listening** screen.</span></span>
-   <span data-ttu-id="1f264-176">**[確認]** 画面 (ユーザーの発言が複数の潜在的な結果として解釈できる場合)。</span><span class="sxs-lookup"><span data-stu-id="1f264-176">The **Did you say** screen, if what the user said could be interpreted as more than one potential result.</span></span>
-   <span data-ttu-id="1f264-177">**[聞き取りの確認]** 画面またはエラー画面。</span><span class="sxs-lookup"><span data-stu-id="1f264-177">The **Heard you say** screen or the error screen.</span></span>

<span data-ttu-id="1f264-178">次の図に、SGRS 文法ファイルに基づく制約を使う音声認識エンジンの画面間のフロー例を示します。</span><span class="sxs-lookup"><span data-stu-id="1f264-178">The following image shows an example of the flow between screens for a speech recognizer that uses a constraint based on a SRGS grammar file.</span></span> <span data-ttu-id="1f264-179">この例では、音声認識に成功しています。</span><span class="sxs-lookup"><span data-stu-id="1f264-179">In this example, speech recognition was successful.</span></span>

![SGRS 文法ファイルに基づく制約の場合の、最初の認識画面](images/speech-listening-initial.png)

![SGRS 文法ファイルに基づく制約の場合の、途中の認識画面](images/speech-listening-intermediate.png)

![SGRS 文法ファイルに基づく制約の場合の、最終的な認識画面](images/speech-listening-complete.png)

<span data-ttu-id="1f264-183">**[聞き取り中]** 画面では、アプリが認識できる単語または語句の例を表示できます。</span><span class="sxs-lookup"><span data-stu-id="1f264-183">The **Listening** screen can provide examples of words or phrases that the app can recognize.</span></span> <span data-ttu-id="1f264-184">ここでは、[**SpeechRecognizerUIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653234) クラス ([**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) プロパティを呼び出して取得する) のプロパティを使って **[聞き取り中]** 画面のコンテンツをカスタマイズする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1f264-184">Here, we show how to use the properties of the [**SpeechRecognizerUIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653234) class (obtained by calling the [**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) property) to customize content on the **Listening** screen.</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="1f264-185">関連記事</span><span class="sxs-lookup"><span data-stu-id="1f264-185">Related articles</span></span>


<span data-ttu-id="1f264-186">**開発者向け**</span><span class="sxs-lookup"><span data-stu-id="1f264-186">**Developers**</span></span>
* <span data-ttu-id="1f264-187">[音声操作](speech-interactions.md)
**デザイナー向け**</span><span class="sxs-lookup"><span data-stu-id="1f264-187">[Speech interactions](speech-interactions.md)
**Designers**</span></span>
* <span data-ttu-id="1f264-188">[音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)
**サンプル**</span><span class="sxs-lookup"><span data-stu-id="1f264-188">[Speech design guidelines](https://msdn.microsoft.com/library/windows/apps/dn596121)
**Samples**</span></span>
* [<span data-ttu-id="1f264-189">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="1f264-189">Speech recognition and speech synthesis sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




