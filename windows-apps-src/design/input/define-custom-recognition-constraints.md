---
Description: Learn how to define and use custom constraints for speech recognition.
title: カスタム認識の制約の定義
ms.assetid: 26289DE5-6AC9-42C3-A160-E522AE62D2FC
label: Define custom recognition constraints
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 53539c73137b40d154db00fa9e340d81412764da
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7826717"
---
# <a name="define-custom-recognition-constraints"></a>カスタム認識の制約の定義



音声認識のカスタム制約を定義して使う方法について説明します。

> **重要な API**: [**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446)、[**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421)、[**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)


音声認識では、少なくとも 1 つの制約を使って、認識できるボキャブラリを定義する必要があります。 制約が指定されていない場合、ユニバーサル Windows アプリで定義済みのディクテーション文法が使われます。 「[音声認識](speech-recognition.md)」をご覧ください。


## <a name="add-constraints"></a>制約の追加


[**SpeechRecognizer.Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) プロパティを使って、音声認識エンジンに制約を追加します。

ここでは、アプリ内から使われる 3 種類の音声認識制約について取り上げます。 (音声コマンドの制約については、「[Cortana の音声コマンドを使ったフォアグラウンド アプリの起動](https://msdn.microsoft.com/cortana/voicecommands/launch-a-foreground-app-with-voice-commands-in-cortana)」をご覧ください)。

-   [**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446)—定義済みの文法に基づく制約 (ディクテーションまたは Web 検索)。
-   [**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421)—単語や語句の一覧に基づく制約。
-   [**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)—音声認識文法仕様 (SRGS) ファイルで定義された制約。

音声認識エンジンはそれぞれ 1 つの制約コレクションを保持できます。 制約は次の組み合わせのみが有効です。

- 単一トピック制約 (ディクテーションまたは Web 検索)
- Windows 10 Fall Creators Update (10.0.16299.15) 以降では、単一トピック制約は、一覧の制約と組み合わせることができます
- 一覧の制約または文法ファイルの制約の組み合わせ。

> [!Important]
> 認識プロセスを開始する前に制約をコンパイルするには、**[SpeechRecognizer.CompileConstraintsAsync](https://msdn.microsoft.com/library/windows/apps/dn653240)** メソッドを呼び出します。

## <a name="specify-a-web-search-grammar-speechrecognitiontopicconstraint"></a>Web 検索文法の指定 (SpeechRecognitionTopicConstraint) 

トピック制約 (ディクテーションまたは Web 検索文法) は音声認識エンジンの制約コレクションに追加する必要があります。

> [!NOTE]
> [SpeechRecognitionListConstraint](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechRecognition.SpeechRecognitionListConstraint) を [SpeechRecognitionTopicConstraint](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechRecognition.SpeechRecognitionTopicConstraint) と共に使い、ディクテーション中に使うと予想されるドメイン固有の一連のキーワードを指定することにより、ディクテーションの精度を上げることができます。

以下では、制約コレクションに Web 検索文法を追加しています。

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

## <a name="specify-a-programmatic-list-constraint-speechrecognitionlistconstraint"></a>プログラムによる一覧の制約の指定 (SpeechRecognitionListConstraint)


一覧の制約は音声認識エンジンの制約コレクションに追加する必要があります。

次の点に留意してください。

-   制約コレクションには、複数の一覧の制約を追加できます。
-   **IIterable&lt;String&gt;** を実装する任意のコレクションを文字列値に使用できます。

以下では、プログラムによって一覧の制約として単語の配列を指定し、それを音声認識エンジンの制約コレクションに追加しています。

```CSharp
private async void YesOrNo_Click(object sender, RoutedEventArgs e)
{
    // Create an instance of SpeechRecognizer.
    var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

    // You could create this array dynamically.
    string[] responses = { "Yes", "No" };


    // Add a list constraint to the recognizer.
    var listConstraint = new Windows.Media.SpeechRecognition.SpeechRecognitionListConstraint(responses, "yesOrNo");

    speechRecognizer.UIOptions.ExampleText = @"Ex. 'yes', 'no'";
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

## <a name="specify-an-srgs-grammar-constraint-speechrecognitiongrammarfileconstraint"></a>SRGS 文法の制約の指定 (SpeechRecognitionGrammarFileConstraint)


SRGS 文法ファイルは音声認識エンジンの制約コレクションに追加する必要があります。

SRGS Version 1.0 は、音声認識用に XML 形式の文法を作るための業界標準のマークアップ言語です。 ユニバーサル Windows アプリでは、SRGS 以外にも音声認識文法を作るための手段が用意されていますが、SRGS を使って文法を作ると、複雑な音声認識シナリオの場合は、特に優れた結果が得られます。

SRGS 文法は、アプリの複雑な音声操作を構築するときに役立つ機能をすべて備えています。 たとえば、SRGS 文法を使って以下を実行できます。

-   認識する単語と語句の発声順序を指定します。
-   認識される複数のリストと語句から単語を組み合わせる
-   他の文法にリンクする
-   音声入力に一致させるために使用される可能性を高くするか低くするために、別の単語または語句に重みを割り当てる
-   オプションの単語または語句を含める
-   文法に一致しない不規則な音声や背景の雑音など、指定していない入力や予期していない入力を除外する特別な規則を使う。
-   セマンティクスを使って、音声認識がアプリにもたらす意味を定義します。
-   文法内で、または用語集へのリンクを通じて発音を指定する

SRGS の要素と属性について詳しくは、[XML 文法の SRGS リファレンス](http://go.microsoft.com/fwlink/p/?LinkID=269886)に関するページをご覧ください。 SRGS 文法の作成を開始するには、[基本的な XML 文法の作成方法](http://go.microsoft.com/fwlink/p/?LinkID=269887)に関するページをご覧ください。

次の点に留意してください。

-   制約コレクションには、複数の文法ファイルの制約を追加できます。
-   SRGS 規則に準拠した XML ベースの文法ドキュメントには .grxml ファイル拡張子を使います。

この例では、srgs.grxml という名前のファイル (後述) に定義された SRGS 文法を使います。 ファイルのプロパティで、**[パッケージ アクション]** が **[コンテンツ]** に設定され、**[出力ディレクトリにコピー]** が **[常にコピーする]** に設定されています。

```CSharp
private async void Colors_Click(object sender, RoutedEventArgs e)
{
    // Create an instance of SpeechRecognizer.
    var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

    // Add a grammar file constraint to the recognizer.
    var storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Colors.grxml"));
    var grammarFileConstraint = new Windows.Media.SpeechRecognition.SpeechRecognitionGrammarFileConstraint(storageFile, "colors");

    speechRecognizer.UIOptions.ExampleText = @"Ex. 'blue background', 'green text'";
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

この SRGS ファイル (srgs.grxml) は、解釈タグを含みます。 これらのタグは、文法に合致するデータをアプリに返すしくみです。 文法は、World Wide Web コンソーシアム (W3C)[の音声認識 (Sisr) 1.0](http://go.microsoft.com/fwlink/p/?LinkID=201765)仕様に準拠している必要があります。

以下では、"yes" と "no" のバリエーションをリッスンします。

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

## <a name="manage-constraints"></a>制約の管理


制約コレクションが認識のために読み込まれると、アプリでは制約の [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn631402) プロパティを **true** または **false** に設定して、認識操作でどの制約を有効にするかを管理できます。 既定の設定は **true** です。

通常は、認識操作ごとに制約を読み込んでアンロードしコンパイルするよりも、いったん読み込んでから必要に応じて有効または無効にする方が効率的です。 必要に応じて [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn631402) プロパティを使います。

制約の数を制限すると、音声認識エンジンが音声入力の一致を探すときに必要となるデータ量を制限できます。 これにより、音声認識のパフォーマンスと精度の両方が向上します。

現在の認識操作のコンテキストでアプリが想定できる語句に基づいて、有効にする制約を決定します。 たとえば、現在のアプリのコンテキストが色を表示することである場合、おそらく動物の名前を認識する制約を有効にする必要はありません。

発声できる内容をユーザーに伝えるには、[**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) プロパティを使って設定できる、[**SpeechRecognizerUIOptions.AudiblePrompt**](https://msdn.microsoft.com/library/windows/apps/dn653235) プロパティと [**SpeechRecognizerUIOptions.ExampleText**](https://msdn.microsoft.com/library/windows/apps/dn653236) プロパティを使います。 音声認識の操作時に何を発声できるか準備しておくことによって、アクティブな制約に一致する語句をユーザーが発声する可能性が高まります。

## <a name="related-articles"></a>関連記事


* [音声操作](speech-interactions.md)

**サンプル**
* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




