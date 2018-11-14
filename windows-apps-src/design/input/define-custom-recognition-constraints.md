---
author: Karl-Bridge-Microsoft
Description: Learn how to define and use custom constraints for speech recognition.
title: カスタム認識の制約の定義
ms.assetid: 26289DE5-6AC9-42C3-A160-E522AE62D2FC
label: Define custom recognition constraints
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 86ed884c3e9811c65d414dce6c0697e20dbd4711
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6189452"
---
# <a name="define-custom-recognition-constraints"></a><span data-ttu-id="97540-103">カスタム認識の制約の定義</span><span class="sxs-lookup"><span data-stu-id="97540-103">Define custom recognition constraints</span></span>



<span data-ttu-id="97540-104">音声認識のカスタム制約を定義して使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="97540-104">Learn how to define and use custom constraints for speech recognition.</span></span>

> <span data-ttu-id="97540-105">**重要な API**: [**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446)、[**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421)、[**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)</span><span class="sxs-lookup"><span data-stu-id="97540-105">**Important APIs**: [**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446), [**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421), [**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)</span></span>


<span data-ttu-id="97540-106">音声認識では、少なくとも 1 つの制約を使って、認識できるボキャブラリを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="97540-106">Speech recognition requires at least one constraint to define a recognizable vocabulary.</span></span> <span data-ttu-id="97540-107">制約が指定されていない場合、ユニバーサル Windows アプリで定義済みのディクテーション文法が使われます。</span><span class="sxs-lookup"><span data-stu-id="97540-107">If no constraint is specified, the predefined dictation grammar of Universal Windows apps is used.</span></span> <span data-ttu-id="97540-108">「[音声認識](speech-recognition.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97540-108">See [Speech recognition](speech-recognition.md).</span></span>


## <a name="add-constraints"></a><span data-ttu-id="97540-109">制約の追加</span><span class="sxs-lookup"><span data-stu-id="97540-109">Add constraints</span></span>


<span data-ttu-id="97540-110">[**SpeechRecognizer.Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) プロパティを使って、音声認識エンジンに制約を追加します。</span><span class="sxs-lookup"><span data-stu-id="97540-110">Use the [**SpeechRecognizer.Constraints**](https://msdn.microsoft.com/library/windows/apps/dn653241) property to add constraints to a speech recognizer.</span></span>

<span data-ttu-id="97540-111">ここでは、アプリ内から使われる 3 種類の音声認識制約について取り上げます。</span><span class="sxs-lookup"><span data-stu-id="97540-111">Here, we cover the three kinds of speech recognition constraints used from within an app.</span></span> <span data-ttu-id="97540-112">(音声コマンドの制約については、「[Cortana の音声コマンドを使ったフォアグラウンド アプリの起動](https://msdn.microsoft.com/cortana/voicecommands/launch-a-foreground-app-with-voice-commands-in-cortana)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="97540-112">(For voice command constraints, see [Launch a foreground app with voice commands in Cortana](https://msdn.microsoft.com/cortana/voicecommands/launch-a-foreground-app-with-voice-commands-in-cortana).)</span></span>

-   <span data-ttu-id="97540-113">[**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446)—定義済みの文法に基づく制約 (ディクテーションまたは Web 検索)。</span><span class="sxs-lookup"><span data-stu-id="97540-113">[**SpeechRecognitionTopicConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631446)—A constraint based on a predefined grammar (dictation or web search).</span></span>
-   <span data-ttu-id="97540-114">[**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421)—単語や語句の一覧に基づく制約。</span><span class="sxs-lookup"><span data-stu-id="97540-114">[**SpeechRecognitionListConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631421)—A constraint based on a list of words or phrases.</span></span>
-   <span data-ttu-id="97540-115">[**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)—音声認識文法仕様 (SRGS) ファイルで定義された制約。</span><span class="sxs-lookup"><span data-stu-id="97540-115">[**SpeechRecognitionGrammarFileConstraint**](https://msdn.microsoft.com/library/windows/apps/dn631412)—A constraint defined in a Speech Recognition Grammar Specification (SRGS) file.</span></span>

<span data-ttu-id="97540-116">音声認識エンジンはそれぞれ 1 つの制約コレクションを保持できます。</span><span class="sxs-lookup"><span data-stu-id="97540-116">Each speech recognizer can have one constraint collection.</span></span> <span data-ttu-id="97540-117">制約は次の組み合わせのみが有効です。</span><span class="sxs-lookup"><span data-stu-id="97540-117">Only these combinations of constraints are valid:</span></span>

- <span data-ttu-id="97540-118">単一トピック制約 (ディクテーションまたは Web 検索)</span><span class="sxs-lookup"><span data-stu-id="97540-118">A single-topic constraint (dictation or web search)</span></span>
- <span data-ttu-id="97540-119">Windows 10 Fall Creators Update (10.0.16299.15) 以降では、単一トピック制約は、一覧の制約と組み合わせることができます</span><span class="sxs-lookup"><span data-stu-id="97540-119">For Windows 10 Fall Creators Update (10.0.16299.15) and newer, a single topic constraint can be combined with a list constraint</span></span>
- <span data-ttu-id="97540-120">一覧の制約または文法ファイルの制約の組み合わせ。</span><span class="sxs-lookup"><span data-stu-id="97540-120">A combination of list constraints and/or grammar-file constraints.</span></span>

> [!Important]
> <span data-ttu-id="97540-121">認識プロセスを開始する前に制約をコンパイルするには、**[SpeechRecognizer.CompileConstraintsAsync](https://msdn.microsoft.com/library/windows/apps/dn653240)** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="97540-121">Call the **[SpeechRecognizer.CompileConstraintsAsync](https://msdn.microsoft.com/library/windows/apps/dn653240)** method to compile the constraints before starting the recognition process.</span></span>

## <a name="specify-a-web-search-grammar-speechrecognitiontopicconstraint"></a><span data-ttu-id="97540-122">Web 検索文法の指定 (SpeechRecognitionTopicConstraint) </span><span class="sxs-lookup"><span data-stu-id="97540-122">Specify a web-search grammar (SpeechRecognitionTopicConstraint)</span></span>

<span data-ttu-id="97540-123">トピック制約 (ディクテーションまたは Web 検索文法) は音声認識エンジンの制約コレクションに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="97540-123">Topic constraints (dictation or web-search grammar) must be added to the constraints collection of a speech recognizer.</span></span>

> [!NOTE]
> <span data-ttu-id="97540-124">[SpeechRecognitionListConstraint](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechRecognition.SpeechRecognitionListConstraint) を [SpeechRecognitionTopicConstraint](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechRecognition.SpeechRecognitionTopicConstraint) と共に使い、ディクテーション中に使うと予想されるドメイン固有の一連のキーワードを指定することにより、ディクテーションの精度を上げることができます。</span><span class="sxs-lookup"><span data-stu-id="97540-124">You can use a [SpeechRecognitionListConstraint](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechRecognition.SpeechRecognitionListConstraint) in conjunction with a [SpeechRecognitionTopicConstraint](https://docs.microsoft.com/uwp/api/Windows.Media.SpeechRecognition.SpeechRecognitionTopicConstraint) to increase dictation accuracy by providing a set of domain-specific keywords that you think are likely to be used during dictation.</span></span>

<span data-ttu-id="97540-125">以下では、制約コレクションに Web 検索文法を追加しています。</span><span class="sxs-lookup"><span data-stu-id="97540-125">Here, we add a web-search grammar to the constraints collection.</span></span>

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

## <a name="specify-a-programmatic-list-constraint-speechrecognitionlistconstraint"></a><span data-ttu-id="97540-126">プログラムによる一覧の制約の指定 (SpeechRecognitionListConstraint)</span><span class="sxs-lookup"><span data-stu-id="97540-126">Specify a programmatic list constraint (SpeechRecognitionListConstraint)</span></span>


<span data-ttu-id="97540-127">一覧の制約は音声認識エンジンの制約コレクションに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="97540-127">List constraints must be added to the constraints collection of a speech recognizer.</span></span>

<span data-ttu-id="97540-128">次の点に留意してください。</span><span class="sxs-lookup"><span data-stu-id="97540-128">Keep the following points in mind:</span></span>

-   <span data-ttu-id="97540-129">制約コレクションには、複数の一覧の制約を追加できます。</span><span class="sxs-lookup"><span data-stu-id="97540-129">You can add multiple list constraints to a constraints collection.</span></span>
-   <span data-ttu-id="97540-130">**IIterable&lt;String&gt;** を実装する任意のコレクションを文字列値に使用できます。</span><span class="sxs-lookup"><span data-stu-id="97540-130">You can use any collection that implements **IIterable&lt;String&gt;** for the string values.</span></span>

<span data-ttu-id="97540-131">以下では、プログラムによって一覧の制約として単語の配列を指定し、それを音声認識エンジンの制約コレクションに追加しています。</span><span class="sxs-lookup"><span data-stu-id="97540-131">Here, we programmatically specify an array of words as a list constraint and add it to the constraints collection of a speech recognizer.</span></span>

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

## <a name="specify-an-srgs-grammar-constraint-speechrecognitiongrammarfileconstraint"></a><span data-ttu-id="97540-132">SRGS 文法の制約の指定 (SpeechRecognitionGrammarFileConstraint)</span><span class="sxs-lookup"><span data-stu-id="97540-132">Specify an SRGS grammar constraint (SpeechRecognitionGrammarFileConstraint)</span></span>


<span data-ttu-id="97540-133">SRGS 文法ファイルは音声認識エンジンの制約コレクションに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="97540-133">SRGS grammar files must be added to the constraints collection of a speech recognizer.</span></span>

<span data-ttu-id="97540-134">SRGS Version 1.0 は、音声認識用に XML 形式の文法を作るための業界標準のマークアップ言語です。</span><span class="sxs-lookup"><span data-stu-id="97540-134">The SRGS Version 1.0 is the industry-standard markup language for creating XML-format grammars for speech recognition.</span></span> <span data-ttu-id="97540-135">ユニバーサル Windows アプリでは、SRGS 以外にも音声認識文法を作るための手段が用意されていますが、SRGS を使って文法を作ると、複雑な音声認識シナリオの場合は、特に優れた結果が得られます。</span><span class="sxs-lookup"><span data-stu-id="97540-135">Although Universal Windows apps provide alternatives to using SRGS for creating speech-recognition grammars, you might find that using SRGS to create grammars produces the best results, particularly for more involved speech recognition scenarios.</span></span>

<span data-ttu-id="97540-136">SRGS 文法は、アプリの複雑な音声操作を構築するときに役立つ機能をすべて備えています。</span><span class="sxs-lookup"><span data-stu-id="97540-136">SRGS grammars provide a full set of features to help you architect complex voice interaction for your apps.</span></span> <span data-ttu-id="97540-137">たとえば、SRGS 文法を使って以下を実行できます。</span><span class="sxs-lookup"><span data-stu-id="97540-137">For example, with SRGS grammars you can:</span></span>

-   <span data-ttu-id="97540-138">認識する単語と語句の発声順序を指定します。</span><span class="sxs-lookup"><span data-stu-id="97540-138">Specify the order in which words and phrases must be spoken to be recognized.</span></span>
-   <span data-ttu-id="97540-139">認識される複数のリストと語句から単語を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="97540-139">Combine words from multiple lists and phrases to be recognized.</span></span>
-   <span data-ttu-id="97540-140">他の文法にリンクする</span><span class="sxs-lookup"><span data-stu-id="97540-140">Link to other grammars.</span></span>
-   <span data-ttu-id="97540-141">音声入力に一致させるために使用される可能性を高くするか低くするために、別の単語または語句に重みを割り当てる</span><span class="sxs-lookup"><span data-stu-id="97540-141">Assign a weight to an alternative word or phrase to increase or decrease the likelihood that it will be used to match speech input.</span></span>
-   <span data-ttu-id="97540-142">オプションの単語または語句を含める</span><span class="sxs-lookup"><span data-stu-id="97540-142">Include optional words or phrases.</span></span>
-   <span data-ttu-id="97540-143">文法に一致しない不規則な音声や背景の雑音など、指定していない入力や予期していない入力を除外する特別な規則を使う。</span><span class="sxs-lookup"><span data-stu-id="97540-143">Use special rules that help filter out unspecified or unanticipated input, such as random speech that doesn't match the grammar, or background noise.</span></span>
-   <span data-ttu-id="97540-144">セマンティクスを使って、音声認識がアプリにもたらす意味を定義します。</span><span class="sxs-lookup"><span data-stu-id="97540-144">Use semantics to define what speech recognition means to your app.</span></span>
-   <span data-ttu-id="97540-145">文法内で、または用語集へのリンクを通じて発音を指定する</span><span class="sxs-lookup"><span data-stu-id="97540-145">Specify pronunciations, either inline in a grammar or via a link to a lexicon.</span></span>

<span data-ttu-id="97540-146">SRGS の要素と属性について詳しくは、[XML 文法の SRGS リファレンス](http://go.microsoft.com/fwlink/p/?LinkID=269886)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97540-146">For more info about SRGS elements and attributes, see the [SRGS Grammar XML Reference](http://go.microsoft.com/fwlink/p/?LinkID=269886) .</span></span> <span data-ttu-id="97540-147">SRGS 文法の作成を開始するには、[基本的な XML 文法の作成方法](http://go.microsoft.com/fwlink/p/?LinkID=269887)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="97540-147">To get started creating an SRGS grammar, see [How to Create a Basic XML Grammar](http://go.microsoft.com/fwlink/p/?LinkID=269887).</span></span>

<span data-ttu-id="97540-148">次の点に留意してください。</span><span class="sxs-lookup"><span data-stu-id="97540-148">Keep the following points in mind:</span></span>

-   <span data-ttu-id="97540-149">制約コレクションには、複数の文法ファイルの制約を追加できます。</span><span class="sxs-lookup"><span data-stu-id="97540-149">You can add multiple grammar-file constraints to a constraints collection.</span></span>
-   <span data-ttu-id="97540-150">SRGS 規則に準拠した XML ベースの文法ドキュメントには .grxml ファイル拡張子を使います。</span><span class="sxs-lookup"><span data-stu-id="97540-150">Use the .grxml file extension for XML-based grammar documents that conform to SRGS rules.</span></span>

<span data-ttu-id="97540-151">この例では、srgs.grxml という名前のファイル (後述) に定義された SRGS 文法を使います。</span><span class="sxs-lookup"><span data-stu-id="97540-151">This example uses an SRGS grammar defined in a file named srgs.grxml (described later).</span></span> <span data-ttu-id="97540-152">ファイルのプロパティで、**[パッケージ アクション]** が **[コンテンツ]** に設定され、**[出力ディレクトリにコピー]** が **[常にコピーする]** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="97540-152">In the file properties, the **Package Action** is set to **Content** with **Copy to Output Directory** set to **Copy always**:</span></span>

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

<span data-ttu-id="97540-153">この SRGS ファイル (srgs.grxml) は、解釈タグを含みます。</span><span class="sxs-lookup"><span data-stu-id="97540-153">This SRGS file (srgs.grxml) includes semantic interpretation tags.</span></span> <span data-ttu-id="97540-154">これらのタグは、文法に合致するデータをアプリに返すしくみです。</span><span class="sxs-lookup"><span data-stu-id="97540-154">These tags provide a mechanism for returning grammar match data to your app.</span></span> <span data-ttu-id="97540-155">文法は、World Wide Web コンソーシアム (W3C)[の音声認識 (Sisr) 1.0](http://go.microsoft.com/fwlink/p/?LinkID=201765)仕様に準拠する必要があります。</span><span class="sxs-lookup"><span data-stu-id="97540-155">Grammars must conform to the World Wide Web Consortium (W3C)[Semantic Interpretation for Speech Recognition (SISR) 1.0](http://go.microsoft.com/fwlink/p/?LinkID=201765) specification.</span></span>

<span data-ttu-id="97540-156">以下では、"yes" と "no" のバリエーションをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="97540-156">Here, we listen for variants of "yes" and "no".</span></span>

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

## <a name="manage-constraints"></a><span data-ttu-id="97540-157">制約の管理</span><span class="sxs-lookup"><span data-stu-id="97540-157">Manage constraints</span></span>


<span data-ttu-id="97540-158">制約コレクションが認識のために読み込まれると、アプリでは制約の [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn631402) プロパティを **true** または **false** に設定して、認識操作でどの制約を有効にするかを管理できます。</span><span class="sxs-lookup"><span data-stu-id="97540-158">After a constraint collection is loaded for recognition, your app can manage which constraints are enabled for recognition operations by setting the [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn631402) property of a constraint to **true** or **false**.</span></span> <span data-ttu-id="97540-159">既定の設定は **true** です。</span><span class="sxs-lookup"><span data-stu-id="97540-159">The default setting is **true**.</span></span>

<span data-ttu-id="97540-160">通常は、認識操作ごとに制約を読み込んでアンロードしコンパイルするよりも、いったん読み込んでから必要に応じて有効または無効にする方が効率的です。</span><span class="sxs-lookup"><span data-stu-id="97540-160">It's usually more efficient to load constraints once, enabling and disabling them as needed, rather than to load, unload, and compile constraints for each recognition operation.</span></span> <span data-ttu-id="97540-161">必要に応じて [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn631402) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="97540-161">Use the [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/dn631402) property, as required.</span></span>

<span data-ttu-id="97540-162">制約の数を制限すると、音声認識エンジンが音声入力の一致を探すときに必要となるデータ量を制限できます。</span><span class="sxs-lookup"><span data-stu-id="97540-162">Restricting the number of constraints serves to limit the amount of data that the speech recognizer needs to search and match against the speech input.</span></span> <span data-ttu-id="97540-163">これにより、音声認識のパフォーマンスと精度の両方が向上します。</span><span class="sxs-lookup"><span data-stu-id="97540-163">This can improve both the performance and the accuracy of speech recognition.</span></span>

<span data-ttu-id="97540-164">現在の認識操作のコンテキストでアプリが想定できる語句に基づいて、有効にする制約を決定します。</span><span class="sxs-lookup"><span data-stu-id="97540-164">Decide which constraints are enabled based on the phrases that your app can expect in the context of the current recognition operation.</span></span> <span data-ttu-id="97540-165">たとえば、現在のアプリのコンテキストが色を表示することである場合、おそらく動物の名前を認識する制約を有効にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="97540-165">For example, if the current app context is to display a color, you probably don't need to enable a constraint that recognizes the names of animals.</span></span>

<span data-ttu-id="97540-166">発声できる内容をユーザーに伝えるには、[**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) プロパティを使って設定できる、[**SpeechRecognizerUIOptions.AudiblePrompt**](https://msdn.microsoft.com/library/windows/apps/dn653235) プロパティと [**SpeechRecognizerUIOptions.ExampleText**](https://msdn.microsoft.com/library/windows/apps/dn653236) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="97540-166">To prompt the user for what can be spoken, use the [**SpeechRecognizerUIOptions.AudiblePrompt**](https://msdn.microsoft.com/library/windows/apps/dn653235) and [**SpeechRecognizerUIOptions.ExampleText**](https://msdn.microsoft.com/library/windows/apps/dn653236) properties, which are set by means of the [**SpeechRecognizer.UIOptions**](https://msdn.microsoft.com/library/windows/apps/dn653254) property.</span></span> <span data-ttu-id="97540-167">音声認識の操作時に何を発声できるか準備しておくことによって、アクティブな制約に一致する語句をユーザーが発声する可能性が高まります。</span><span class="sxs-lookup"><span data-stu-id="97540-167">Preparing users for what they can say during the recognition operation increases the likelihood that they will speak a phrase that can be matched to an active constraint.</span></span>

## <a name="related-articles"></a><span data-ttu-id="97540-168">関連記事</span><span class="sxs-lookup"><span data-stu-id="97540-168">Related articles</span></span>


* [<span data-ttu-id="97540-169">音声操作</span><span class="sxs-lookup"><span data-stu-id="97540-169">Speech interactions</span></span>](speech-interactions.md)

**<span data-ttu-id="97540-170">サンプル</span><span class="sxs-lookup"><span data-stu-id="97540-170">Samples</span></span>**
* [<span data-ttu-id="97540-171">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="97540-171">Speech recognition and speech synthesis sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




