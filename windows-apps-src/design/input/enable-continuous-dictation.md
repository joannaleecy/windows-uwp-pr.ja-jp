---
Description: Learn how to capture and recognize long-form, continuous dictation speech input.
title: 継続的なディクテーションの有効化
ms.assetid: 383B3E23-1678-4FBB-B36E-6DE2DA9CA9DC
label: Continuous dictation
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 839dc024204ec9b76ffe621a35cbbbaffc248d02
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8324211"
---
# <a name="continuous-dictation"></a>継続的なディクテーション

長い形式の継続的なディクテーション音声入力をキャプチャし、認識する方法について説明します。

> **重要な API**: [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896)、[**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913)

「[音声認識](speech-recognition.md)」では、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) オブジェクトの [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) メソッドまたは [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) メソッドを使って、比較的短い音声入力をキャプチャし、認識する方法について説明しました。たとえば、ショート メッセージ サービス (SMS) のメッセージを作成したり、質問したりする場合です。

ディクテーションまたはメールなど、より長い継続的な音声認識セッションの場合は、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) の [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) プロパティを使って [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896) オブジェクトを取得します。

> [!NOTE]
> 音声入力言語のサポートは、アプリが実行されている[デバイス](https://docs.microsoft.com/windows/uwp/design/devices/)に依存します。 Pc とノート pc、EN-US のみ認識されると、音声認識でサポートされているすべての言語を認識できる Xbox と電話間です。 詳しくは、[音声認識の言語を指定する](specify-the-speech-recognizer-language.md)を参照してください。

## <a name="set-up"></a>設定

アプリには、継続的なディクテーション セッションを管理するためのオブジェクトがいくつか必要です。

- 1 インスタンスの [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) オブジェクト。
- ディクテーション中の UI を更新するための UI ディスパッチャーへの参照。
- ユーザーが発声し、蓄積された単語を追跡する方法。

ここでは、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) インスタンスを、コード ビハインド クラスのプライベート フィールドとして宣言します。 継続的なディクテーションが、1 つの XAML (Extensible Application Markup Language) ページを超えて持続する場合、アプリは、参照を別の場所に格納する必要があります。

```CSharp
private SpeechRecognizer speechRecognizer;
```

ディクテーション中に認識エンジンは、バックグラウンド スレッドからイベントを生成します。 バックグラウンド スレッドは、XAML の UI を直接更新できないため、アプリはディスパッチャーを使って、認識イベントに応答して UI を更新する必要があります。

ここでは、プライベート フィールドを宣言し、それが後で UI ディスパッチャーで初期化されます。

```CSharp
// Speech events may originate from a thread other than the UI thread.
// Keep track of the UI thread dispatcher so that we can update the
// UI in a thread-safe manner.
private CoreDispatcher dispatcher;
```

ユーザーが発声した内容を追跡するには、音声認識エンジンによって生成された認識イベントを処理する必要があります。 これらのイベントは、ユーザーの発声のチャンクを認識した結果を提供します。

ここでは、[**StringBuilder**](https://msdn.microsoft.com/library/system.text.stringbuilder.aspx) オブジェクトを使って、セッション中に取得したすべての認識結果を保持します。 新しい検索結果は、処理されるに従って **StringBuilder** に追加されます。

```CSharp
private StringBuilder dictatedTextBuilder;
```

## <a name="initialization"></a>初期化

継続的な音声認識の初期化時には、次の操作を行う必要があります。

- 連続的な認識のイベント ハンドラーでアプリの UI を更新する場合は、UI スレッドのディスパッチャーを取得します。
- 音声認識エンジンを初期化します。
- 組み込みのディクテーション文法をコンパイルします。
    **注:** 音声認識が少なくとも 1 つの制約を認識できるボキャブラリを定義する必要があります。 制約が指定されていない場合は、定義済みのディクテーション文法が使われます。 「[音声認識](speech-recognition.md)」をご覧ください。
- 認識イベントのイベント リスナーをセットアップします。

この例では、[**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) ページ イベントで音声認識を初期化します。

1. 音声認識エンジンが生成するイベントはバックグラウンド スレッドで発生するため、UI スレッドを更新するためのディスパッチャーへの参照を作成します。 [**OnNavigatedTo**
            ](https://msdn.microsoft.com/library/windows/apps/br227508) は、常に UI スレッド上で呼び出されます。
```csharp
this.dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
```

2.  その後、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) インスタンスを初期化します。
```csharp
this.speechRecognizer = new SpeechRecognizer();
```

3.  そして、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) によって認識される語句と単語をすべて定義する文法を追加し、コンパイルします。

    文法を明示的に指定しない場合は、既定で定義済みのディクテーション文法が使われます。 通常、一般的なディクテーションには、既定の文法が最適です。

    ここでは、文法を追加せずに、すぐに [**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) を呼び出します。

    
```csharp
SpeechRecognitionCompilationResult result =
      await speechRecognizer.CompileConstraintsAsync();
```

## <a name="handle-recognition-events"></a>認識イベントの処理

[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) または [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) を呼び出して、1 つの短い発声または語句をキャプチャできます。 

ただし、より長い継続的な認識セッションをキャプチャするには、ユーザーが話す間にバックグラウンドで動作するイベント リスナーを指定し、ディクテーション文字列を作成するためのハンドラーを定義します。

そして、認識エンジンの [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) プロパティを使って、継続的な認識セッションを管理するためのメソッドとイベントを提供する [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896) オブジェクトを取得します。

特に、次の 2 つのイベントが重要です。

- [**ResultGenerated**
            ](https://msdn.microsoft.com/library/windows/apps/dn913900)。これは、認識エンジンがいくつかの結果を生成したときに発生します。
- [**Completed**
            ](https://msdn.microsoft.com/library/windows/apps/dn913899)。継続的な認識セッションが終了したときに発生します。

[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントは、ユーザーが発声すると発生します。 認識エンジンは、ユーザーの発声を聞き続け、音声入力のチャンクを渡すイベントを定期的に生成します。 音声入力は、イベントの引数の [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) プロパティを使って確認し、イベント ハンドラーで適切な処置を行う必要があります。たとえば、StringBuilder オブジェクトにテキストを追加します。

[**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) のインスタンスである [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) プロパティは、音声入力を受け入れるかどうかを決定するために役立ちます。 [ **SpeechRecognitionResult** ](https://msdn.microsoft.com/library/windows/apps/dn631432) には、このための 2 つのプロパティが用意されています。

- [**Status**
            ](https://msdn.microsoft.com/library/windows/apps/dn631440) は、正常に認識できたかどうかを示します。 さまざまな原因により、認識できない場合もあります。
- [**Confidence**
            ](https://msdn.microsoft.com/library/windows/apps/dn631434) は、認識エンジンが、正しい単語を理解したことを比較的確信していることを示します。

継続的な認識をサポートするための基本的な手順は次のとおりです。  

1. ここでは、[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) 継続的認識イベントのハンドラーを [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) ページ イベントに登録します。
```csharp
speechRecognizer.ContinuousRecognitionSession.ResultGenerated +=
        ContinuousRecognitionSession_ResultGenerated;
```

2.  そして、[**Confidence**](https://msdn.microsoft.com/library/windows/apps/dn631434) プロパティを確認します。 Confidence の値が [**Medium**](https://msdn.microsoft.com/library/windows/apps/dn631409) 以上である場合は、StringBuilder にテキストを追加します。 入力の収集時に UI も更新します。

    **注:** [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900)イベントは、UI を直接更新できないバック グラウンド スレッドで発生します。 (「音声と TTS のサンプル」のように) ハンドラーが UI を更新する必要がある場合は、ディスパッチャーの [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) メソッドで更新を UI スレッドにディスパッチする必要があります。
```csharp
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

3.  その後、[**Completed**](https://msdn.microsoft.com/library/windows/apps/dn913899) イベントを処理します。これが、継続的なディクテーションの終了を示します。

    セッションは、[**StopAsync**](https://msdn.microsoft.com/library/windows/apps/dn913908) メソッドまたは [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) メソッド (次のセクションを参照) を呼び出すと終了します。 セッションは、エラーが発生したときや、ユーザーが発声を停止したときに終了することもあります。 イベントの引数の [**Status**](https://msdn.microsoft.com/library/windows/apps/dn631440) プロパティを確認して、セッションが終了した理由を特定してください ([**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433))。

    ここでは、[**Completed**](https://msdn.microsoft.com/library/windows/apps/dn913899) 継続的認識イベントのハンドラーを [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) ページ イベントに登録します。
```csharp
speechRecognizer.ContinuousRecognitionSession.Completed +=
      ContinuousRecognitionSession_Completed;
```

4.  イベント ハンドラーは Status プロパティを確認して、正常に認識できたかどうかを判断します。 また、ユーザーが発声を停止した場合の処理も行います。 多くの場合、[**TimeoutExceeded**](https://msdn.microsoft.com/library/windows/apps/dn631433) によって、正常に認識されたと見なされます。これは、ユーザーの発声が終了したことを意味するためです。 快適に使えるように、このケースをコード内で処理する必要があります。

    **注:** [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900)イベントは、UI を直接更新できないバック グラウンド スレッドで発生します。 (「音声と TTS のサンプル」のように) ハンドラーが UI を更新する必要がある場合は、ディスパッチャーの [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) メソッドで更新を UI スレッドにディスパッチする必要があります。
```csharp
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

## <a name="provide-ongoing-recognition-feedback"></a>実行中の認識に対するフィードバックの提供


人が会話する場合は、話の内容を完全に理解するためにコンテキストが必要であることがよくあります。 同様に、信頼性の高い認識結果を提供するために音声認識エンジンにコンテキストが必要である場合がよくあります。 たとえば、"weight" および "wait" という単語は、それ自体だけでは区別できないため、周囲の単語からコンテキストをさらに探り出す必要があります。 認識エンジンは、単語や語句を正しく認識したことを、ある程度確信するまでは、[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントを生成しません。

したがって、ユーザーが話し続けても、認識エンジンが [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントを生成できると確信するまでは結果が表示されないため、ユーザーにとって快適とはいえない結果になる場合があります。

この不十分な応答性を改善するには、[**HypothesisGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913914) イベントを処理します。 このイベントは、処理中の単語と一致すると思われる新しいセットを認識エンジンが生成するたびに発生します。 イベント引数は、現在一致している内容を含む [**Hypothesis**](https://msdn.microsoft.com/library/windows/apps/dn913911) プロパティを提供します。 話し続けるユーザーに、これらを表示して、処理がまだ続行されていることを知らせます。 認識エンジンが十分に確信し、認識結果が確定されたら、暫定の **Hypothesis** 結果を、[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントで提供される最終的な [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) に置き換えます。

ここでは、仮のテキストと省略記号 ("…") を、出力 [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) の現在の値に追加します。 テキスト ボックスの内容は、新しい仮の結果が生成されるたびに更新され、最後に、最終的な結果が [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントから取得されます。

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

## <a name="start-and-stop-recognition"></a>認識の開始と停止


認識セッションを開始する前に、音声認識エンジンの [**State**](https://msdn.microsoft.com/library/windows/apps/dn913915) プロパティの値を確認します。 音声認識エンジンは、[**Idle**](https://msdn.microsoft.com/library/windows/apps/dn653227) 状態である必要があります。

音声認識エンジンの状態を確認した後、音声認識エンジンの [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) プロパティの [**StartAsync**](https://msdn.microsoft.com/library/windows/apps/dn913901) メソッドを呼び出してセッションを開始します。

```CSharp
if (speechRecognizer.State == SpeechRecognizerState.Idle)
{
  await speechRecognizer.ContinuousRecognitionSession.StartAsync();
}
```

認識を停止するには、次の 2 つの方法があります。

-   [**StopAsync**
            ](https://msdn.microsoft.com/library/windows/apps/dn913908) を使うと、保留中のすべての認識イベントが完了します ([**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) は、保留中のすべての操作が完了するまで、引き続き発生します)。
-   [**CancelAsync**
            ](https://msdn.microsoft.com/library/windows/apps/dn913898) を使うと、すぐに認識セッションが終了し、保留中の結果はすべて破棄されます。

音声認識エンジンの状態を確認したら、音声認識エンジンの [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) プロパティの [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) メソッドを呼び出してセッションを停止します。

```CSharp
if (speechRecognizer.State != SpeechRecognizerState.Idle)
{
  await speechRecognizer.ContinuousRecognitionSession.CancelAsync();
}
```

> [!NOTE]
> [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) を呼び出した後に [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントが発生する場合があります。  
> マルチスレッドであるために、[**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) を呼び出したときに [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントがスタックに残っている可能性があります。 その場合は、**ResultGenerated** イベントも発生します。  
> プライベート フィールドを設定しているときに認識セッションをキャンセルした場合は、その値を常に [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) ハンドラーで確認してください。 たとえば、セッションをキャンセルしたときにプライベート フィールドを null に設定している場合はハンドラー内でフィールドが初期化されると想定しないでください。

 

## <a name="related-articles"></a>関連記事


* [音声操作](speech-interactions.md)

**サンプル**
* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




