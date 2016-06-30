---
author: Karl-Bridge-Microsoft
Description: "音声認識を使って、入力を行ったり、操作やコマンドを指定したり、タスクを実行したりできます。"
title: "音声認識"
ms.assetid: 553C0FB7-35BC-4894-9EF1-906139E17552
label: Speech recognition
template: detail.hbs
ms.sourcegitcommit: a2ec5e64b91c9d0e401c48902a18e5496fc987ab
ms.openlocfilehash: 66bab97e7108a1728e9659a04ea2f1ecf15f68b7

---

# 音声認識


音声認識を使って、入力を行ったり、操作やコマンドを指定したり、タスクを実行したりできます。

**重要な API**

-   [**Windows.Media.SpeechRecognition**](https://msdn.microsoft.com/library/windows/apps/dn653262)



音声認識機能は、音声認識ランタイム、ランタイムをプログラミングするための認識 API、ディクテーションと Web 検索のための定義済みの文法、ユーザーが音声認識機能を見つけて使うときに役立つ既定のシステム UI で構成されています。


## オーディオ フィードの設定


使っているデバイスにマイクまたは同等の機能があることを確認します。

[アプリ パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/br211474) (**package.appxmanifest** ファイル) で**マイク** デバイスの機能 ([**DeviceCapability**](https://msdn.microsoft.com/library/windows/apps/br211430)) を設定して、マイクのオーディオ フィードにアクセスできるようにします。 こうすることで、アプリは接続されたマイクからオーディオを録音できます。

「[アプリ機能の宣言](https://msdn.microsoft.com/library/windows/apps/mt270968)」をご覧ください。

## 音声入力の認識


*制約*は、音声入力でアプリが認識する単語と語句 (ボキャブラリ) を定義します。 制約は音声認識の中心であり、アプリの音声認識の精度に大きく影響します。

音声認識の実行時には、さまざまな種類の制約を使うことができます。

1.  **定義済みの文法** ([**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446))。

    定義済みのディクテーション文法と Web 検索文法を使うと、文法を作らずにアプリに音声認識を実装できます。 これらの文法を使った場合、音声認識がリモート Web サービスで実行され、結果がデバイスに返されます。

    既定のフリーテキストのディクテーション文法では、ユーザーが特定の言語で話すほとんどの単語と語句を認識できます。これは短い語句の認識に最適化されています。 [
            **SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) オブジェクトに制約を指定しなかった場合は、定義済みのディクテーション文法が使われます。 フリーテキストのディクテーションは、ユーザーが話す内容を限定しない場合に便利です。 一般的な用途としては、メモの作成やメッセージ内容の口述などがあります。

    Web 検索文法は、ユーザーが話す可能性のある多数の単語と語句を含んでいる点でディクテーション文法と似ています ただし、ユーザーが Web 検索で一般的に使う用語の認識に最適化されています。

    **注**  定義済みのディクテーション文法と Web 検索文法は容量が大きく、(デバイス上ではなく) オンライン上に存在するため、カスタム文法をデバイスにインストールした場合に比べるとパフォーマンスが劣る可能性があります。

     

    このような定義済みの文法は、10 秒までの長さの音声入力を認識でき、開発者による作成作業は必要ありません。 ただし、ネットワークへの接続が必要になります。

    Web サービスの制約を使用するには、[設定] の [プライバシー] の [音声認識、手書き入力、タイピング] ページで [自分を知ってもらう] をオンにして、**[設定]** で音声入力とディクテーションのサポートを有効にする必要があります。

    ここでは、音声入力が有効になっているかどうかをテストし、有効になっていない場合は [設定]、[プライバシー] の [音声認識、手書き入力、タイピング] ページを開く方法を示します。

    まず、グローバル変数 (HResultPrivacyStatementDeclined) を HResult 値 0x80045509 に初期化します。 「[C\# または Visual Basic での例外処理](https://msdn.microsoft.com/library/windows/apps/dn532194)」をご覧ください。

```    CSharp
private static uint HResultPrivacyStatementDeclined = 0x80045509;</code></pre></td>
    </tr>
    </tbody>
    </table>
```

    We then catch any standard exceptions during recogntion and test if the [**HResult**](https://msdn.microsoft.com/library/windows/apps/br206579) value is equal to the value of the HResultPrivacyStatementDeclined variable. If so, we display a warning and call `await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-accounts"));` to open the Settings page.

    
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

2.  **プログラムによる一覧の制約** ([**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421))

    プログラムによる一覧の制約は、単語や語句の一覧を使って単純な文法を作成する手法で、軽量です。 個別の短い語句を認識するには、一覧の制約が適しています。 文法にすべての単語を明示的に指定すると、音声認識エンジンは音声と単語の一致を確認する際に音声だけを処理すればよいので、認識の精度が向上します。 また、一覧はプログラムで更新することもできます。

    一覧の制約は、アプリで認識操作に利用できる音声入力を表した文字列の配列で構成されます。 アプリで一覧の制約を作成するには、音声認識の一覧の制約オブジェクトを作って、文字列の配列を渡します。 次に、そのオブジェクトを認識エンジンの制約コレクションに追加します。 音声認識エンジンが配列内の文字列のどれかを認識したら、認識は成功です。

3.  **SRGS 文法**([**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412))

    Speech Recognition Grammar Specification (SRGS) 文法は静的ドキュメントで、プログラムによる一覧の制約とは異なり、[SRGS Version 1.0](http://go.microsoft.com/fwlink/p/?LinkID=262302) で定義された XML 形式を使います。 SRGS 文法では、1 回の認識で複数の意味をキャプチャすることができるため、音声認識エクスペリエンスを最大限に制御することができます。

4.  **音声コマンドの制約** ([**SpeechRecognitionVoiceCommandDefinitionConstraint**](https://msdn.microsoft.com/library/windows/apps/dn653220))

    音声コマンド定義 (VCD) XML ファイルを使って、アプリをアクティブ化して操作を開始するためにユーザーが発声できる音声コマンドを定義します。 詳しくは、「[Cortana の音声コマンドを使ったフォアグラウンド アプリの起動](launch-a-foreground-app-with-voice-commands-in-cortana.md)」をご覧ください。

**注**  どの種類の制約を使うかは、作成する認識エクスペリエンスの複雑さによって決まります。 どの種類の制約も特定の認識タスクに最適な選択肢となる可能性があり、アプリですべての種類の制約を使う場合もあります。
制約を使う場合は、「[カスタム認識の制約の定義](define-custom-recognition-constraints.md)」をご覧ください。

 

ユニバーサル Windows アプリで定義済みのディクテーション文法によって、言語のほとんどの単語と短い語句が認識されます。 これは、カスタム制約なしで音声認識エンジン オブジェクトをインスタンス化すると既定で有効になります。

この例では、以下の操作を行う方法を示します。

-   音声認識エンジンを作成します。
-   既定のユニバーサル Windows アプリ制約をコンパイルします (音声認識エンジンの文法セットには文法が追加されていません)。
-   [
            **RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) メソッドに用意された基本的な認識 UI と TTS フィードバックを使って音声の聞き取りを開始します。 既定の UI が必要でない場合は、[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) メソッドを使います。

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

## 認識 UI をカスタマイズする


アプリが [**SpeechRecognizer.RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) を呼び出して音声認識を試みると、複数の画面が次の順序で表示されます。

定義済みの文法に基づく制約を使っている場合 (ディクテーションまたは Web 検索):

-   **[聞き取り中]** 画面。
-   **[認識中]** 画面。
-   **[聞き取りの確認]** 画面またはエラー画面。

単語や語句の一覧に基づく制約、または、SGRS 文法ファイルに基づく制約を使っている場合:

-   **[聞き取り中]** 画面。
-   **[確認]** 画面 (ユーザーの発言が複数の潜在的な結果として解釈できる場合)。
-   **[聞き取りの確認]** 画面またはエラー画面。

次の図に、SGRS 文法ファイルに基づく制約を使う音声認識エンジンの画面間のフロー例を示します。 この例では、音声認識に成功しています。

![SGRS 文法ファイルに基づく制約の場合の、最初の認識画面](images/speech-listening-initial.png)

![SGRS 文法ファイルに基づく制約の場合の、途中の認識画面](images/speech-listening-intermediate.png)

![SGRS 文法ファイルに基づく制約の場合の、最終的な認識画面](images/speech-listening-complete.png)

**[聞き取り中]** 画面では、アプリが認識できる単語または語句の例を表示できます。 ここでは、[**SpeechRecognizerUIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653234) クラス ([**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) プロパティを呼び出して取得する) のプロパティを使って **[聞き取り中]** 画面のコンテンツをカスタマイズする方法について説明します。

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

## 関連記事


**開発者向け**
* [音声操作](speech-interactions.md)
            
          
            **デザイナー向け**
* [音声認識の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596121)
            
          
            **サンプル**
* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 







<!--HONumber=Jun16_HO4-->


