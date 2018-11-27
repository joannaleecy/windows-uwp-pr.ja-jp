---
Description: Use speech recognition to provide input, specify an action or command, and accomplish tasks.
title: 音声認識
ms.assetid: 553C0FB7-35BC-4894-9EF1-906139E17552
label: Speech recognition
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.date: 10/25/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 8b6e0c6a751116ad03c4e8d69cb02e7147938097
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7718573"
---
# <a name="speech-recognition"></a><span data-ttu-id="a6fe6-103">音声認識</span><span class="sxs-lookup"><span data-stu-id="a6fe6-103">Speech recognition</span></span>


<span data-ttu-id="a6fe6-104">音声認識を使って、入力を行ったり、操作やコマンドを指定したり、タスクを実行したりできます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-104">Use speech recognition to provide input, specify an action or command, and accomplish tasks.</span></span>

> <span data-ttu-id="a6fe6-105">**重要な API**: [**Windows.Media.SpeechRecognition**](https://msdn.microsoft.com/library/windows/apps/dn653262)</span><span class="sxs-lookup"><span data-stu-id="a6fe6-105">**Important APIs**: [**Windows.Media.SpeechRecognition**](https://msdn.microsoft.com/library/windows/apps/dn653262)</span></span>

<span data-ttu-id="a6fe6-106">音声認識機能は、音声認識ランタイム、ランタイムをプログラミングするための認識 API、ディクテーションと Web 検索のための定義済みの文法、ユーザーが音声認識機能を見つけて使うときに役立つ既定のシステム UI で構成されています。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-106">Speech recognition is made up of a speech runtime, recognition APIs for programming the runtime, ready-to-use grammars for dictation and web search, and a default system UI that helps users discover and use speech recognition features.</span></span>

## <a name="configure-speech-recognition"></a><span data-ttu-id="a6fe6-107">音声認識を構成します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-107">Configure speech recognition</span></span>

<span data-ttu-id="a6fe6-108">ユーザーが接続する必要があります、アプリで音声認識をサポートするには、デバイスでマイクを有効にし、マイクロソフトのプライバシー ポリシー、アプリの許可を使うことに同意します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-108">To support speech recognition with your app, the user must connect and enable a microphone on their device, and accept the Microsoft Privacy Policy granting permission for your app to use it.</span></span>

<span data-ttu-id="a6fe6-109">自動的にアクセスして、マイクを使用するためのアクセス許可を要求しているシステム ダイアログをユーザーに求めるオーディオ フィード (から[音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)を次になど) が単なるセット**マイク**[デバイス機能](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-devicecapability)[アプリ パッケージ マニフェスト](https://docs.microsoft.com/uwp/schemas/appxpackage/appx-package-manifest)にします。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-109">To automatically prompt the user with a system dialog requesting permission to access and use the microphone's audio feed (example from the [Speech recognition and speech synthesis sample](http://go.microsoft.com/fwlink/p/?LinkID=619897) shown below), just set the **Microphone** [device capability](https://docs.microsoft.com/uwp/schemas/appxpackage/appxmanifestschema/element-devicecapability) in the [App package manifest](https://docs.microsoft.com/uwp/schemas/appxpackage/appx-package-manifest).</span></span> <span data-ttu-id="a6fe6-110">詳細については、[アプリ機能の宣言](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-110">For more detail, see [App capability declarations](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations).</span></span>

![マイク アクセス用のプライバシー ポリシー](images/speech/privacy.png)

<span data-ttu-id="a6fe6-112">ユーザー設定の承認済みアプリケーションの一覧にアプリが追加されたマイク、アクセスを許可するには、[はい] をクリックした場合は、[プライバシー]-> [マイク] ページ]-> [します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-112">If the user clicks Yes to grant access to the microphone, your app is added to the list of approved applications on the Settings -> Privacy -> Microphone page.</span></span> <span data-ttu-id="a6fe6-113">ただし、いつでもでもこの設定をオフにするには、ユーザーが選択できる、としてことは、アプリがマイクにアクセスして使用する前に確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-113">However, as the user can choose to turn this setting off at any time, you should confirm that your app has access to the microphone before attempting to use it.</span></span>

<span data-ttu-id="a6fe6-114">Cortana、ディクテーションをサポートする、またはサービス (トピック制約で定義されている[定義済みの文法](#predefined-grammars)) などの他の音声認識もことを確認して**Online の音声認識**(設定のプライバシー]-> [音声認識]-> [) は、有効になります。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-114">If you also want to support dictation, Cortana, or other speech recognition services (such as a [predefined grammar](#predefined-grammars) defined in a topic constraint), you must also confirm that **Online speech recognition** (Settings -> Privacy -> Speech) is enabled.</span></span>

<span data-ttu-id="a6fe6-115">このスニペットでは、アプリがマイクが存在する場合、それを使用するアクセス許可がある場合を確認する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-115">This snippet shows how your app can check if a microphone is present and if it has permission to use it.</span></span>

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

## <a name="recognize-speech-input"></a><span data-ttu-id="a6fe6-116">音声入力の認識</span><span class="sxs-lookup"><span data-stu-id="a6fe6-116">Recognize speech input</span></span>

<span data-ttu-id="a6fe6-117">*制約*は、音声入力でアプリが認識する単語と語句 (ボキャブラリ) を定義します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-117">A *constraint* defines the words and phrases (vocabulary) that an app recognizes in speech input.</span></span> <span data-ttu-id="a6fe6-118">制約は音声認識の中心であり、アプリの音声認識の精度に大きく影響します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-118">Constraints are at the core of speech recognition and give your app greater over the accuracy of speech recognition.</span></span>

<span data-ttu-id="a6fe6-119">音声入力を認識するため、次の種類の制約を使用できます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-119">You can use the following types of constraints for recognizing speech input.</span></span>

### <a name="predefined-grammars"></a><span data-ttu-id="a6fe6-120">定義済みの文法</span><span class="sxs-lookup"><span data-stu-id="a6fe6-120">Predefined grammars</span></span>

<span data-ttu-id="a6fe6-121">定義済みのディクテーション文法と Web 検索文法を使うと、文法を作らずにアプリに音声認識を実装できます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-121">Predefined dictation and web-search grammars provide speech recognition for your app without requiring you to author a grammar.</span></span> <span data-ttu-id="a6fe6-122">これらの文法を使った場合、音声認識がリモート Web サービスで実行され、結果がデバイスに返されます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-122">When using these grammars, speech recognition is performed by a remote web service and the results are returned to the device.</span></span>

<span data-ttu-id="a6fe6-123">既定のフリーテキストのディクテーション文法では、ユーザーが特定の言語で話すほとんどの単語と語句を認識できます。これは短い語句の認識に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-123">The default free-text dictation grammar can recognize most words and phrases that a user can say in a particular language, and is optimized to recognize short phrases.</span></span> <span data-ttu-id="a6fe6-124">[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) オブジェクトに制約を指定しなかった場合は、定義済みのディクテーション文法が使われます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-124">The predefined dictation grammar is used if you don't specify any constraints for your [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) object.</span></span> <span data-ttu-id="a6fe6-125">フリーテキストのディクテーションは、ユーザーが話す内容を限定しない場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-125">Free-text dictation is useful when you don't want to limit the kinds of things a user can say.</span></span> <span data-ttu-id="a6fe6-126">一般的な用途としては、メモの作成やメッセージ内容の口述などがあります。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-126">Typical uses include creating notes or dictating the content for a message.</span></span>

<span data-ttu-id="a6fe6-127">Web 検索文法は、ユーザーが話す可能性のある多数の単語と語句を含んでいる点でディクテーション文法と似ています</span><span class="sxs-lookup"><span data-stu-id="a6fe6-127">The web-search grammar, like a dictation grammar, contains a large number of words and phrases that a user might say.</span></span> <span data-ttu-id="a6fe6-128">ただし、ユーザーが Web 検索で一般的に使う用語の認識に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-128">However, it is optimized to recognize terms that people typically use when searching the web.</span></span>

<span data-ttu-id="a6fe6-129">**注:** 定義済みのディクテーションと web 検索文法は容量が大きく、し、オンラインため (デバイス上の) ではなくパフォーマンスできない可能性があります、カスタム文法をデバイスにインストールされていると同様に高速です。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-129">**Note**Because predefined dictation and web-search grammars can be large, and because they are online (not on the device), performance might not be as fast as with a custom grammar installed on the device.</span></span>     

<span data-ttu-id="a6fe6-130">このような定義済みの文法は、10 秒までの長さの音声入力を認識でき、開発者による作成作業は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-130">These predefined grammars can be used to recognize up to 10 seconds of speech input and require no authoring effort on your part.</span></span> <span data-ttu-id="a6fe6-131">ただし、ネットワークへの接続が必要になります。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-131">However, they do require a connection to a network.</span></span>

<span data-ttu-id="a6fe6-132">Web サービスの制約を使用するには、**[設定] -> [プライバシー] -> [音声認識、手描き入力、入力の設定]** で [自分を知ってもらう] オプションをオンにして、**[設定]** で音声入力とディクテーションのサポートを有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-132">To use web-service constraints, speech input and dictation support must be enabled in **Settings** by turning on the "Get to know me" option in  **Settings -> Privacy -> Speech, inking, and typing**.</span></span>

<span data-ttu-id="a6fe6-133">ここでは、音声入力が有効になっているかどうかをテストし、有効になっていない場合は [設定]、[プライバシー] の [音声認識、手描き入力、入力の設定] ページを開く方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-133">Here, we show how to test whether speech input is enabled and open the Settings -> Privacy -> Speech, inking, and typing page, if not.</span></span>

<span data-ttu-id="a6fe6-134">まず、グローバル変数 (HResultPrivacyStatementDeclined) を HResult 値 0x80045509 に初期化します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-134">First, we initialize a global variable (HResultPrivacyStatementDeclined) to the HResult value of 0x80045509.</span></span> <span data-ttu-id="a6fe6-135">「[C\# または Visual Basic での例外処理](https://msdn.microsoft.com/library/windows/apps/dn532194)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-135">See [Exception handling for in C\# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/dn532194).</span></span>

```csharp
private static uint HResultPrivacyStatementDeclined = 0x80045509;
```

<span data-ttu-id="a6fe6-136">認識中に標準例外をキャッチし、[**HResult**](https://msdn.microsoft.com/library/windows/apps/br206579) 値が HResultPrivacyStatementDeclined 変数の値以下であるかどうかをテストします。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-136">We then catch any standard exceptions during recogntion and test if the [**HResult**](https://msdn.microsoft.com/library/windows/apps/br206579) value is equal to the value of the HResultPrivacyStatementDeclined variable.</span></span> <span data-ttu-id="a6fe6-137">該当する場合は、警告を表示し、`await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts"));` を呼び出して [設定] ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-137">If so, we display a warning and call `await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts"));` to open the Settings page.</span></span>

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

<span data-ttu-id="a6fe6-138">[**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-138">See [**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446).</span></span>

### <a name="programmatic-list-constraints"></a><span data-ttu-id="a6fe6-139">プログラムによる一覧の制約</span><span class="sxs-lookup"><span data-stu-id="a6fe6-139">Programmatic list constraints</span></span> 

<span data-ttu-id="a6fe6-140">プログラムによる一覧の制約は、単語や語句の一覧を使って単純な文法を作成する手法で、軽量です。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-140">Programmatic list constraints provide a lightweight approach to creating simple grammars using a list of words or phrases.</span></span> <span data-ttu-id="a6fe6-141">個別の短い語句を認識するには、一覧の制約が適しています。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-141">A list constraint works well for recognizing short, distinct phrases.</span></span> <span data-ttu-id="a6fe6-142">文法にすべての単語を明示的に指定すると、音声認識エンジンは音声と単語の一致を確認する際に音声だけを処理すればよいので、認識の精度が向上します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-142">Explicitly specifying all words in a grammar also improves recognition accuracy, as the speech recognition engine must only process speech to confirm a match.</span></span> <span data-ttu-id="a6fe6-143">また、一覧はプログラムで更新することもできます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-143">The list can also be programmatically updated.</span></span>

<span data-ttu-id="a6fe6-144">一覧の制約は、アプリで認識操作に利用できる音声入力を表した文字列の配列で構成されます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-144">A list constraint consists of an array of strings that represents speech input that your app will accept for a recognition operation.</span></span> <span data-ttu-id="a6fe6-145">アプリで一覧の制約を作成するには、音声認識の一覧の制約オブジェクトを作って、文字列の配列を渡します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-145">You can create a list constraint in your app by creating a speech-recognition list-constraint object and passing an array of strings.</span></span> <span data-ttu-id="a6fe6-146">次に、そのオブジェクトを認識エンジンの制約コレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-146">Then, add that object to the constraints collection of the recognizer.</span></span> <span data-ttu-id="a6fe6-147">音声認識エンジンが配列内の文字列のどれかを認識したら、認識は成功です。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-147">Recognition is successful when the speech recognizer recognizes any one of the strings in the array.</span></span>

<span data-ttu-id="a6fe6-148">[**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-148">See [**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421).</span></span>

### <a name="srgs-grammars"></a><span data-ttu-id="a6fe6-149">SRGS 文法</span><span class="sxs-lookup"><span data-stu-id="a6fe6-149">SRGS grammars</span></span>

<span data-ttu-id="a6fe6-150">Speech Recognition Grammar Specification (SRGS) 文法は静的ドキュメントで、プログラムによる一覧の制約とは異なり、[SRGS Version 1.0](http://go.microsoft.com/fwlink/p/?LinkID=262302) で定義された XML 形式を使います。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-150">An Speech Recognition Grammar Specification (SRGS) grammar is a static document that, unlike a programmatic list constraint, uses the XML format defined by the [SRGS Version 1.0](http://go.microsoft.com/fwlink/p/?LinkID=262302).</span></span> <span data-ttu-id="a6fe6-151">SRGS 文法では、1 回の認識で複数の意味をキャプチャすることができるため、音声認識エクスペリエンスを最大限に制御することができます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-151">An SRGS grammar provides the greatest control over the speech recognition experience by letting you capture multiple semantic meanings in a single recognition.</span></span>

 <span data-ttu-id="a6fe6-152">[**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-152">See [**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412).</span></span>

### <a name="voice-command-constraints"></a><span data-ttu-id="a6fe6-153">音声コマンドの制約</span><span class="sxs-lookup"><span data-stu-id="a6fe6-153">Voice command constraints</span></span>

<span data-ttu-id="a6fe6-154">音声コマンド定義 (VCD) XML ファイルを使って、アプリをアクティブ化して操作を開始するためにユーザーが発声できる音声コマンドを定義します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-154">Use a Voice Command Definition (VCD) XML file to define the commands that the user can say to initiate actions when activating your app.</span></span> <span data-ttu-id="a6fe6-155">詳しくは、「[Cortana の音声コマンドを使ったフォアグラウンド アプリの起動](https://msdn.microsoft.com/cortana/voicecommands/launch-a-foreground-app-with-voice-commands-in-cortana)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-155">For more detail, see [Launch a foreground app with voice commands in Cortana](https://msdn.microsoft.com/cortana/voicecommands/launch-a-foreground-app-with-voice-commands-in-cortana).</span></span>

<span data-ttu-id="a6fe6-156">[ **SpeechRecognitionVoiceCommandDefinitionConstraint**を参照してください。](https://msdn.microsoft.com/library/windows/apps/dn653220)/</span><span class="sxs-lookup"><span data-stu-id="a6fe6-156">See [**SpeechRecognitionVoiceCommandDefinitionConstraint**](https://msdn.microsoft.com/library/windows/apps/dn653220)/</span></span>

<span data-ttu-id="a6fe6-157">**注:** 制約型を使用するは、作成する認識エクスペリエンスの複雑さによって決まります。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-157">**Note**The type of constraint type you use depends on the complexity of the recognition experience you want to create.</span></span> <span data-ttu-id="a6fe6-158">どの種類の制約も特定の認識タスクに最適な選択肢となる可能性があり、アプリですべての種類の制約を使う場合もあります。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-158">Any could be the best choice for a specific recognition task, and you might find uses for all types of constraints in your app.</span></span>
<span data-ttu-id="a6fe6-159">制約を使う場合は、「[カスタム認識の制約の定義](define-custom-recognition-constraints.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-159">To get started with constraints, see [Define custom recognition constraints](define-custom-recognition-constraints.md).</span></span>

<span data-ttu-id="a6fe6-160">ユニバーサル Windows アプリで定義済みのディクテーション文法によって、言語のほとんどの単語と短い語句が認識されます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-160">The predefined Universal Windows app dictation grammar recognizes most words and short phrases in a language.</span></span> <span data-ttu-id="a6fe6-161">これは、カスタム制約なしで音声認識エンジン オブジェクトをインスタンス化すると既定で有効になります。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-161">It is activated by default when a speech recognizer object is instantiated without custom constraints.</span></span>

<span data-ttu-id="a6fe6-162">この例では、以下の操作を行う方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-162">In this example, we show how to:</span></span>

- <span data-ttu-id="a6fe6-163">音声認識エンジンを作成します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-163">Create a speech recognizer.</span></span>
- <span data-ttu-id="a6fe6-164">既定のユニバーサル Windows アプリ制約をコンパイルします (音声認識エンジンの文法セットには文法が追加されていません)。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-164">Compile the default Universal Windows app constraints (no grammars have been added to the speech recognizer's grammar set).</span></span>
- <span data-ttu-id="a6fe6-165">[**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) メソッドに用意された基本的な認識 UI と TTS フィードバックを使って音声の聞き取りを開始します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-165">Start listening for speech by using the basic recognition UI and TTS feedback provided by the [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) method.</span></span> <span data-ttu-id="a6fe6-166">既定の UI が必要でない場合は、[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-166">Use the [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) method if the default UI is not required.</span></span>

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

## <a name="customize-the-recognition-ui"></a><span data-ttu-id="a6fe6-167">認識 UI をカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="a6fe6-167">Customize the recognition UI</span></span>


<span data-ttu-id="a6fe6-168">アプリが [**SpeechRecognizer.RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) を呼び出して音声認識を試みると、複数の画面が次の順序で表示されます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-168">When your app attempts speech recognition by calling [**SpeechRecognizer.RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245), several screens are shown in the following order.</span></span>

<span data-ttu-id="a6fe6-169">定義済みの文法に基づく制約を使っている場合 (ディクテーションまたは Web 検索):</span><span class="sxs-lookup"><span data-stu-id="a6fe6-169">If you're using a constraint based on a predefined grammar (dictation or web search):</span></span>

-   <span data-ttu-id="a6fe6-170">**[聞き取り中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-170">The **Listening** screen.</span></span>
-   <span data-ttu-id="a6fe6-171">**[認識中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-171">The **Thinking** screen.</span></span>
-   <span data-ttu-id="a6fe6-172">**[聞き取りの確認]** 画面またはエラー画面。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-172">The **Heard you say** screen or the error screen.</span></span>

<span data-ttu-id="a6fe6-173">単語や語句の一覧に基づく制約、または、SGRS 文法ファイルに基づく制約を使っている場合:</span><span class="sxs-lookup"><span data-stu-id="a6fe6-173">If you're using a constraint based on a list of words or phrases, or a constraint based on a SRGS grammar file:</span></span>

-   <span data-ttu-id="a6fe6-174">**[聞き取り中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-174">The **Listening** screen.</span></span>
-   <span data-ttu-id="a6fe6-175">**[確認]** 画面 (ユーザーの発言が複数の潜在的な結果として解釈できる場合)。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-175">The **Did you say** screen, if what the user said could be interpreted as more than one potential result.</span></span>
-   <span data-ttu-id="a6fe6-176">**[聞き取りの確認]** 画面またはエラー画面。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-176">The **Heard you say** screen or the error screen.</span></span>

<span data-ttu-id="a6fe6-177">次の図に、SGRS 文法ファイルに基づく制約を使う音声認識エンジンの画面間のフロー例を示します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-177">The following image shows an example of the flow between screens for a speech recognizer that uses a constraint based on a SRGS grammar file.</span></span> <span data-ttu-id="a6fe6-178">この例では、音声認識に成功しています。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-178">In this example, speech recognition was successful.</span></span>

![SGRS 文法ファイルに基づく制約の場合の、最初の認識画面](images/speech-listening-initial.png)

![SGRS 文法ファイルに基づく制約の場合の、途中の認識画面](images/speech-listening-intermediate.png)

![SGRS 文法ファイルに基づく制約の場合の、最終的な認識画面](images/speech-listening-complete.png)

<span data-ttu-id="a6fe6-182">**[聞き取り中]** 画面では、アプリが認識できる単語または語句の例を表示できます。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-182">The **Listening** screen can provide examples of words or phrases that the app can recognize.</span></span> <span data-ttu-id="a6fe6-183">ここでは、[**SpeechRecognizerUIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653234) クラス ([**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) プロパティを呼び出して取得する) のプロパティを使って **[聞き取り中]** 画面のコンテンツをカスタマイズする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a6fe6-183">Here, we show how to use the properties of the [**SpeechRecognizerUIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653234) class (obtained by calling the [**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) property) to customize content on the **Listening** screen.</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="a6fe6-184">関連記事</span><span class="sxs-lookup"><span data-stu-id="a6fe6-184">Related articles</span></span>


**<span data-ttu-id="a6fe6-185">開発者向け</span><span class="sxs-lookup"><span data-stu-id="a6fe6-185">Developers</span></span>**
* <span data-ttu-id="a6fe6-186">[音声操作](speech-interactions.md)
**デザイナー向け**</span><span class="sxs-lookup"><span data-stu-id="a6fe6-186">[Speech interactions](speech-interactions.md)
**Designers**</span></span>
* <span data-ttu-id="a6fe6-187">[音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)
**サンプル**</span><span class="sxs-lookup"><span data-stu-id="a6fe6-187">[Speech design guidelines](https://msdn.microsoft.com/library/windows/apps/dn596121)
**Samples**</span></span>
* [<span data-ttu-id="a6fe6-188">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="a6fe6-188">Speech recognition and speech synthesis sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




