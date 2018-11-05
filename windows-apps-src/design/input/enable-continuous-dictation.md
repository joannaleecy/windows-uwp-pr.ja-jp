---
author: Karl-Bridge-Microsoft
Description: Learn how to capture and recognize long-form, continuous dictation speech input.
title: 継続的なディクテーションの有効化
ms.assetid: 383B3E23-1678-4FBB-B36E-6DE2DA9CA9DC
label: Continuous dictation
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ea7c0b92c5900e468023dd5b972942a89c2833c3
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6023700"
---
# <a name="continuous-dictation"></a><span data-ttu-id="501ce-103">継続的なディクテーション</span><span class="sxs-lookup"><span data-stu-id="501ce-103">Continuous dictation</span></span>

<span data-ttu-id="501ce-104">長い形式の継続的なディクテーション音声入力をキャプチャし、認識する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="501ce-104">Learn how to capture and recognize long-form, continuous dictation speech input.</span></span>

> <span data-ttu-id="501ce-105">**重要な API**: [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896)、[**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913)</span><span class="sxs-lookup"><span data-stu-id="501ce-105">**Important APIs**: [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896), [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913)</span></span>

<span data-ttu-id="501ce-106">「[音声認識](speech-recognition.md)」では、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) オブジェクトの [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) メソッドまたは [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) メソッドを使って、比較的短い音声入力をキャプチャし、認識する方法について説明しました。たとえば、ショート メッセージ サービス (SMS) のメッセージを作成したり、質問したりする場合です。</span><span class="sxs-lookup"><span data-stu-id="501ce-106">In [Speech recognition](speech-recognition.md), you learned how to capture and recognize relatively short speech input using the [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) or [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) methods of a [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) object, for example, when composing a short message service (SMS) message or when asking a question.</span></span>

<span data-ttu-id="501ce-107">ディクテーションまたはメールなど、より長い継続的な音声認識セッションの場合は、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) の [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) プロパティを使って [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="501ce-107">For longer, continuous speech recognition sessions, such as dictation or email, use the [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) property of a [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) to obtain a [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896) object.</span></span>

> [!NOTE]
> <span data-ttu-id="501ce-108">音声入力言語のサポートは、アプリが実行されている[デバイス](https://docs.microsoft.com/windows/uwp/design/devices/)に依存します。</span><span class="sxs-lookup"><span data-stu-id="501ce-108">Dictation language support depends on the [device](https://docs.microsoft.com/windows/uwp/design/devices/) where your app is running.</span></span> <span data-ttu-id="501ce-109">Pc とノート pc、EN-US のみ認識されると、音声認識でサポートされているすべての言語を認識できる Xbox と電話間します。</span><span class="sxs-lookup"><span data-stu-id="501ce-109">For PCs and laptops, only en-US is recognized, while Xbox and phones can recognize all languages supported by speech recognition.</span></span> <span data-ttu-id="501ce-110">詳しくは、[音声認識の言語を指定する](specify-the-speech-recognizer-language.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="501ce-110">For more info, see [Specify the speech recognizer language](specify-the-speech-recognizer-language.md).</span></span>

## <a name="set-up"></a><span data-ttu-id="501ce-111">設定</span><span class="sxs-lookup"><span data-stu-id="501ce-111">Set up</span></span>

<span data-ttu-id="501ce-112">アプリには、継続的なディクテーション セッションを管理するためのオブジェクトがいくつか必要です。</span><span class="sxs-lookup"><span data-stu-id="501ce-112">Your app needs a few objects to manage a continuous dictation session:</span></span>

- <span data-ttu-id="501ce-113">1 インスタンスの [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="501ce-113">An instance of a [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) object.</span></span>
- <span data-ttu-id="501ce-114">ディクテーション中の UI を更新するための UI ディスパッチャーへの参照。</span><span class="sxs-lookup"><span data-stu-id="501ce-114">A reference to a UI dispatcher to update the UI during dictation.</span></span>
- <span data-ttu-id="501ce-115">ユーザーが発声し、蓄積された単語を追跡する方法。</span><span class="sxs-lookup"><span data-stu-id="501ce-115">A way to track the accumulated words spoken by the user.</span></span>

<span data-ttu-id="501ce-116">ここでは、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) インスタンスを、コード ビハインド クラスのプライベート フィールドとして宣言します。</span><span class="sxs-lookup"><span data-stu-id="501ce-116">Here, we declare a [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) instance as a private field of the code-behind class.</span></span> <span data-ttu-id="501ce-117">継続的なディクテーションが、1 つの XAML (Extensible Application Markup Language) ページを超えて持続する場合、アプリは、参照を別の場所に格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-117">Your app needs to store a reference elsewhere if you want continuous dictation to persist beyond a single Extensible Application Markup Language (XAML) page.</span></span>

```CSharp
private SpeechRecognizer speechRecognizer;
```

<span data-ttu-id="501ce-118">ディクテーション中に認識エンジンは、バックグラウンド スレッドからイベントを生成します。</span><span class="sxs-lookup"><span data-stu-id="501ce-118">During dictation, the recognizer raises events from a background thread.</span></span> <span data-ttu-id="501ce-119">バックグラウンド スレッドは、XAML の UI を直接更新できないため、アプリはディスパッチャーを使って、認識イベントに応答して UI を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-119">Because a background thread cannot directly update the UI in XAML, your app must use a dispatcher to update the UI in response to recognition events.</span></span>

<span data-ttu-id="501ce-120">ここでは、プライベート フィールドを宣言し、それが後で UI ディスパッチャーで初期化されます。</span><span class="sxs-lookup"><span data-stu-id="501ce-120">Here, we declare a private field that will be initialized later with the UI dispatcher.</span></span>

```CSharp
// Speech events may originate from a thread other than the UI thread.
// Keep track of the UI thread dispatcher so that we can update the
// UI in a thread-safe manner.
private CoreDispatcher dispatcher;
```

<span data-ttu-id="501ce-121">ユーザーが発声した内容を追跡するには、音声認識エンジンによって生成された認識イベントを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-121">To track what the user is saying, you need to handle recognition events raised by the speech recognizer.</span></span> <span data-ttu-id="501ce-122">これらのイベントは、ユーザーの発声のチャンクを認識した結果を提供します。</span><span class="sxs-lookup"><span data-stu-id="501ce-122">These events provide the recognition results for chunks of user utterances.</span></span>

<span data-ttu-id="501ce-123">ここでは、[**StringBuilder**](https://msdn.microsoft.com/library/system.text.stringbuilder.aspx) オブジェクトを使って、セッション中に取得したすべての認識結果を保持します。</span><span class="sxs-lookup"><span data-stu-id="501ce-123">Here, we use a [**StringBuilder**](https://msdn.microsoft.com/library/system.text.stringbuilder.aspx) object to hold all the recognition results obtained during the session.</span></span> <span data-ttu-id="501ce-124">新しい検索結果は、処理されるに従って **StringBuilder** に追加されます。</span><span class="sxs-lookup"><span data-stu-id="501ce-124">New results are appended to the **StringBuilder** as they are processed.</span></span>

```CSharp
private StringBuilder dictatedTextBuilder;
```

## <a name="initialization"></a><span data-ttu-id="501ce-125">初期化</span><span class="sxs-lookup"><span data-stu-id="501ce-125">Initialization</span></span>

<span data-ttu-id="501ce-126">継続的な音声認識の初期化時には、次の操作を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-126">During the initialization of continuous speech recognition, you must:</span></span>

- <span data-ttu-id="501ce-127">連続的な認識のイベント ハンドラーでアプリの UI を更新する場合は、UI スレッドのディスパッチャーを取得します。</span><span class="sxs-lookup"><span data-stu-id="501ce-127">Fetch the dispatcher for the UI thread if you update the UI of your app in the continuous recognition event handlers.</span></span>
- <span data-ttu-id="501ce-128">音声認識エンジンを初期化します。</span><span class="sxs-lookup"><span data-stu-id="501ce-128">Initialize the speech recognizer.</span></span>
- <span data-ttu-id="501ce-129">組み込みのディクテーション文法をコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="501ce-129">Compile the built-in dictation grammar.</span></span>
    <span data-ttu-id="501ce-130">**注:** 音声認識が少なくとも 1 つの制約を認識できるボキャブラリを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-130">**Note** Speech recognition requires at least one constraint to define a recognizable vocabulary.</span></span> <span data-ttu-id="501ce-131">制約が指定されていない場合は、定義済みのディクテーション文法が使われます。</span><span class="sxs-lookup"><span data-stu-id="501ce-131">If no constraint is specified, a predefined dictation grammar is used.</span></span> <span data-ttu-id="501ce-132">「[音声認識](speech-recognition.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="501ce-132">See [Speech recognition](speech-recognition.md).</span></span>
- <span data-ttu-id="501ce-133">認識イベントのイベント リスナーをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="501ce-133">Set up the event listeners for recognition events.</span></span>

<span data-ttu-id="501ce-134">この例では、[**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) ページ イベントで音声認識を初期化します。</span><span class="sxs-lookup"><span data-stu-id="501ce-134">In this example, we initialize speech recognition in the [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) page event.</span></span>

1. <span data-ttu-id="501ce-135">音声認識エンジンが生成するイベントはバックグラウンド スレッドで発生するため、UI スレッドを更新するためのディスパッチャーへの参照を作成します。</span><span class="sxs-lookup"><span data-stu-id="501ce-135">Because events raised by the speech recognizer occur on a background thread, create a reference to the dispatcher for updates to the UI thread.</span></span> <span data-ttu-id="501ce-136">[**OnNavigatedTo**
            ](https://msdn.microsoft.com/library/windows/apps/br227508) は、常に UI スレッド上で呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="501ce-136">[**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) is always invoked on the UI thread.</span></span>
```csharp
this.dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
```

2.  <span data-ttu-id="501ce-137">その後、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) インスタンスを初期化します。</span><span class="sxs-lookup"><span data-stu-id="501ce-137">We then initialize the [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) instance.</span></span>
```csharp
this.speechRecognizer = new SpeechRecognizer();
```

3.  <span data-ttu-id="501ce-138">そして、[**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226) によって認識される語句と単語をすべて定義する文法を追加し、コンパイルします。</span><span class="sxs-lookup"><span data-stu-id="501ce-138">We then add and compile the grammar that defines all of the words and phrases that can be recognized by the [**SpeechRecognizer**](https://msdn.microsoft.com/library/windows/apps/dn653226).</span></span>

    <span data-ttu-id="501ce-139">文法を明示的に指定しない場合は、既定で定義済みのディクテーション文法が使われます。</span><span class="sxs-lookup"><span data-stu-id="501ce-139">If you don't specify a grammar explicitly, a predefined dictation grammar is used by default.</span></span> <span data-ttu-id="501ce-140">通常、一般的なディクテーションには、既定の文法が最適です。</span><span class="sxs-lookup"><span data-stu-id="501ce-140">Typically, the default grammar is best for general dictation.</span></span>

    <span data-ttu-id="501ce-141">ここでは、文法を追加せずに、すぐに [**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="501ce-141">Here, we call [**CompileConstraintsAsync**](https://msdn.microsoft.com/library/windows/apps/dn653240) immediately without adding a grammar.</span></span>

    
```csharp
SpeechRecognitionCompilationResult result =
      await speechRecognizer.CompileConstraintsAsync();
```

## <a name="handle-recognition-events"></a><span data-ttu-id="501ce-142">認識イベントの処理</span><span class="sxs-lookup"><span data-stu-id="501ce-142">Handle recognition events</span></span>

<span data-ttu-id="501ce-143">[**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) または [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245) を呼び出して、1 つの短い発声または語句をキャプチャできます。</span><span class="sxs-lookup"><span data-stu-id="501ce-143">You can capture a single, brief utterance or phrase by calling [**RecognizeAsync**](https://msdn.microsoft.com/library/windows/apps/dn653244) or [**RecognizeWithUIAsync**](https://msdn.microsoft.com/library/windows/apps/dn653245).</span></span> 

<span data-ttu-id="501ce-144">ただし、より長い継続的な認識セッションをキャプチャするには、ユーザーが話す間にバックグラウンドで動作するイベント リスナーを指定し、ディクテーション文字列を作成するためのハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="501ce-144">However, to capture a longer, continuous recognition session, we specify event listeners to run in the background as the user speaks and define handlers to build the dictation string.</span></span>

<span data-ttu-id="501ce-145">そして、認識エンジンの [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) プロパティを使って、継続的な認識セッションを管理するためのメソッドとイベントを提供する [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="501ce-145">We then use the [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) property of our recognizer to obtain a [**SpeechContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913896) object that provides methods and events for managing a continuous recognition session.</span></span>

<span data-ttu-id="501ce-146">特に、次の 2 つのイベントが重要です。</span><span class="sxs-lookup"><span data-stu-id="501ce-146">Two events in particular are critical:</span></span>

- <span data-ttu-id="501ce-147">[**ResultGenerated**
            ](https://msdn.microsoft.com/library/windows/apps/dn913900)。これは、認識エンジンがいくつかの結果を生成したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="501ce-147">[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900), which occurs when the recognizer has generated some results.</span></span>
- <span data-ttu-id="501ce-148">[**Completed**
            ](https://msdn.microsoft.com/library/windows/apps/dn913899)。継続的な認識セッションが終了したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="501ce-148">[**Completed**](https://msdn.microsoft.com/library/windows/apps/dn913899), which occurs when the continuous recognition session has ended.</span></span>

<span data-ttu-id="501ce-149">[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントは、ユーザーが発声すると発生します。</span><span class="sxs-lookup"><span data-stu-id="501ce-149">The [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event is raised as the user speaks.</span></span> <span data-ttu-id="501ce-150">認識エンジンは、ユーザーの発声を聞き続け、音声入力のチャンクを渡すイベントを定期的に生成します。</span><span class="sxs-lookup"><span data-stu-id="501ce-150">The recognizer continuously listens to the user and periodically raises an event that passes a chunk of speech input.</span></span> <span data-ttu-id="501ce-151">音声入力は、イベントの引数の [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) プロパティを使って確認し、イベント ハンドラーで適切な処置を行う必要があります。たとえば、StringBuilder オブジェクトにテキストを追加します。</span><span class="sxs-lookup"><span data-stu-id="501ce-151">You must examine the speech input, using the [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) property of the event argument, and take appropriate action in the event handler, such as appending the text to a StringBuilder object.</span></span>

<span data-ttu-id="501ce-152">[**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) のインスタンスである [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) プロパティは、音声入力を受け入れるかどうかを決定するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="501ce-152">As an instance of [**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432), the [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) property is useful for determining whether you want to accept the speech input.</span></span> <span data-ttu-id="501ce-153">[ **SpeechRecognitionResult** ](https://msdn.microsoft.com/library/windows/apps/dn631432) には、このための 2 つのプロパティが用意されています。</span><span class="sxs-lookup"><span data-stu-id="501ce-153">A [**SpeechRecognitionResult**](https://msdn.microsoft.com/library/windows/apps/dn631432) provides two properties for this:</span></span>

- <span data-ttu-id="501ce-154">[**Status**
            ](https://msdn.microsoft.com/library/windows/apps/dn631440) は、正常に認識できたかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="501ce-154">[**Status**](https://msdn.microsoft.com/library/windows/apps/dn631440) indicates whether the recognition was successful.</span></span> <span data-ttu-id="501ce-155">さまざまな原因により、認識できない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="501ce-155">Recognition can fail for a variety of reasons.</span></span>
- <span data-ttu-id="501ce-156">[**Confidence**
            ](https://msdn.microsoft.com/library/windows/apps/dn631434) は、認識エンジンが、正しい単語を理解したことを比較的確信していることを示します。</span><span class="sxs-lookup"><span data-stu-id="501ce-156">[**Confidence**](https://msdn.microsoft.com/library/windows/apps/dn631434) indicates the relative confidence that the recognizer understood the correct words.</span></span>

<span data-ttu-id="501ce-157">継続的な認識をサポートするための基本的な手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="501ce-157">Here are the basic steps for supporting continuous recognition:</span></span>  

1. <span data-ttu-id="501ce-158">ここでは、[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) 継続的認識イベントのハンドラーを [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) ページ イベントに登録します。</span><span class="sxs-lookup"><span data-stu-id="501ce-158">Here, we register the handler for the [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) continuous recognition event in the [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) page event.</span></span>
```csharp
speechRecognizer.ContinuousRecognitionSession.ResultGenerated +=
        ContinuousRecognitionSession_ResultGenerated;
```

2.  <span data-ttu-id="501ce-159">そして、[**Confidence**](https://msdn.microsoft.com/library/windows/apps/dn631434) プロパティを確認します。</span><span class="sxs-lookup"><span data-stu-id="501ce-159">We then check the [**Confidence**](https://msdn.microsoft.com/library/windows/apps/dn631434) property.</span></span> <span data-ttu-id="501ce-160">Confidence の値が [**Medium**](https://msdn.microsoft.com/library/windows/apps/dn631409) 以上である場合は、StringBuilder にテキストを追加します。</span><span class="sxs-lookup"><span data-stu-id="501ce-160">If the value of Confidence is [**Medium**](https://msdn.microsoft.com/library/windows/apps/dn631409) or better, we append the text to the StringBuilder.</span></span> <span data-ttu-id="501ce-161">入力の収集時に UI も更新します。</span><span class="sxs-lookup"><span data-stu-id="501ce-161">We also update the UI as we collect input.</span></span>

    <span data-ttu-id="501ce-162">**注:** [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900)イベントは、UI を直接更新できないバック グラウンド スレッドで発生します。</span><span class="sxs-lookup"><span data-stu-id="501ce-162">**Note**the [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event is raised on a background thread that cannot update the UI directly.</span></span> <span data-ttu-id="501ce-163">(「音声と TTS のサンプル」のように) ハンドラーが UI を更新する必要がある場合は、ディスパッチャーの [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) メソッドで更新を UI スレッドにディスパッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-163">If a handler needs to update the UI (as the \[Speech and TTS sample\] does), you must dispatch the updates to the UI thread through the [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) method of the dispatcher.</span></span>
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

3.  <span data-ttu-id="501ce-164">その後、[**Completed**](https://msdn.microsoft.com/library/windows/apps/dn913899) イベントを処理します。これが、継続的なディクテーションの終了を示します。</span><span class="sxs-lookup"><span data-stu-id="501ce-164">We then handle the [**Completed**](https://msdn.microsoft.com/library/windows/apps/dn913899) event, which indicates the end of continuous dictation.</span></span>

    <span data-ttu-id="501ce-165">セッションは、[**StopAsync**](https://msdn.microsoft.com/library/windows/apps/dn913908) メソッドまたは [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) メソッド (次のセクションを参照) を呼び出すと終了します。</span><span class="sxs-lookup"><span data-stu-id="501ce-165">The session ends when you call the [**StopAsync**](https://msdn.microsoft.com/library/windows/apps/dn913908) or [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) methods (described the next section).</span></span> <span data-ttu-id="501ce-166">セッションは、エラーが発生したときや、ユーザーが発声を停止したときに終了することもあります。</span><span class="sxs-lookup"><span data-stu-id="501ce-166">The session can also end when an error occurs, or when the user has stopped speaking.</span></span> <span data-ttu-id="501ce-167">イベントの引数の [**Status**](https://msdn.microsoft.com/library/windows/apps/dn631440) プロパティを確認して、セッションが終了した理由を特定してください ([**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433))。</span><span class="sxs-lookup"><span data-stu-id="501ce-167">Check the [**Status**](https://msdn.microsoft.com/library/windows/apps/dn631440) property of the event argument to determine why the session ended ([**SpeechRecognitionResultStatus**](https://msdn.microsoft.com/library/windows/apps/dn631433)).</span></span>

    <span data-ttu-id="501ce-168">ここでは、[**Completed**](https://msdn.microsoft.com/library/windows/apps/dn913899) 継続的認識イベントのハンドラーを [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) ページ イベントに登録します。</span><span class="sxs-lookup"><span data-stu-id="501ce-168">Here, we register the handler for the [**Completed**](https://msdn.microsoft.com/library/windows/apps/dn913899) continuous recognition event in the [**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) page event.</span></span>
```csharp
speechRecognizer.ContinuousRecognitionSession.Completed +=
      ContinuousRecognitionSession_Completed;
```

4.  <span data-ttu-id="501ce-169">イベント ハンドラーは Status プロパティを確認して、正常に認識できたかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="501ce-169">The event handler checks the Status property to determine whether the recognition was successful.</span></span> <span data-ttu-id="501ce-170">また、ユーザーが発声を停止した場合の処理も行います。</span><span class="sxs-lookup"><span data-stu-id="501ce-170">It also handles the case where the user has stopped speaking.</span></span> <span data-ttu-id="501ce-171">多くの場合、[**TimeoutExceeded**](https://msdn.microsoft.com/library/windows/apps/dn631433) によって、正常に認識されたと見なされます。これは、ユーザーの発声が終了したことを意味するためです。</span><span class="sxs-lookup"><span data-stu-id="501ce-171">Often, a [**TimeoutExceeded**](https://msdn.microsoft.com/library/windows/apps/dn631433) is considered successful recognition as it means the user has finished speaking.</span></span> <span data-ttu-id="501ce-172">快適に使えるように、このケースをコード内で処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-172">You should handle this case in your code for a good experience.</span></span>

    <span data-ttu-id="501ce-173">**注:** [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900)イベントは、UI を直接更新できないバック グラウンド スレッドで発生します。</span><span class="sxs-lookup"><span data-stu-id="501ce-173">**Note**the [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event is raised on a background thread that cannot update the UI directly.</span></span> <span data-ttu-id="501ce-174">(「音声と TTS のサンプル」のように) ハンドラーが UI を更新する必要がある場合は、ディスパッチャーの [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) メソッドで更新を UI スレッドにディスパッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-174">If a handler needs to update the UI (as the \[Speech and TTS sample\] does), you must dispatch the updates to the UI thread through the [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) method of the dispatcher.</span></span>
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

## <a name="provide-ongoing-recognition-feedback"></a><span data-ttu-id="501ce-175">実行中の認識に対するフィードバックの提供</span><span class="sxs-lookup"><span data-stu-id="501ce-175">Provide ongoing recognition feedback</span></span>


<span data-ttu-id="501ce-176">人が会話する場合は、話の内容を完全に理解するためにコンテキストが必要であることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="501ce-176">When people converse, they often rely on context to fully understand what is being said.</span></span> <span data-ttu-id="501ce-177">同様に、信頼性の高い認識結果を提供するために音声認識エンジンにコンテキストが必要である場合がよくあります。</span><span class="sxs-lookup"><span data-stu-id="501ce-177">Similarly, the speech recognizer often needs context to provide high-confidence recognition results.</span></span> <span data-ttu-id="501ce-178">たとえば、"weight" および "wait" という単語は、それ自体だけでは区別できないため、周囲の単語からコンテキストをさらに探り出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-178">For example, by themselves, the words "weight" and "wait" are indistinguishable until more context can be gleaned from surrounding words.</span></span> <span data-ttu-id="501ce-179">認識エンジンは、単語や語句を正しく認識したことを、ある程度確信するまでは、[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントを生成しません。</span><span class="sxs-lookup"><span data-stu-id="501ce-179">Until the recognizer has some confidence that a word, or words, have been recognized correctly, it will not raise the [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event.</span></span>

<span data-ttu-id="501ce-180">したがって、ユーザーが話し続けても、認識エンジンが [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントを生成できると確信するまでは結果が表示されないため、ユーザーにとって快適とはいえない結果になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-180">This can result in a less than ideal experience for the user as they continue speaking and no results are provided until the recognizer has high enough confidence to raise the [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event.</span></span>

<span data-ttu-id="501ce-181">この不十分な応答性を改善するには、[**HypothesisGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913914) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="501ce-181">Handle the [**HypothesisGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913914) event to improve this apparent lack of responsiveness.</span></span> <span data-ttu-id="501ce-182">このイベントは、処理中の単語と一致すると思われる新しいセットを認識エンジンが生成するたびに発生します。</span><span class="sxs-lookup"><span data-stu-id="501ce-182">This event is raised whenever the recognizer generates a new set of potential matches for the word being processed.</span></span> <span data-ttu-id="501ce-183">イベント引数は、現在一致している内容を含む [**Hypothesis**](https://msdn.microsoft.com/library/windows/apps/dn913911) プロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="501ce-183">The event argument provides an [**Hypothesis**](https://msdn.microsoft.com/library/windows/apps/dn913911) property that contains the current matches.</span></span> <span data-ttu-id="501ce-184">話し続けるユーザーに、これらを表示して、処理がまだ続行されていることを知らせます。</span><span class="sxs-lookup"><span data-stu-id="501ce-184">Show these to the user as they continue speaking and reassure them that processing is still active.</span></span> <span data-ttu-id="501ce-185">認識エンジンが十分に確信し、認識結果が確定されたら、暫定の **Hypothesis** 結果を、[**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントで提供される最終的な [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="501ce-185">Once confidence is high and a recognition result has been determined, replace the interim **Hypothesis** results with the final [**Result**](https://msdn.microsoft.com/library/windows/apps/dn913895) provided in the [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event.</span></span>

<span data-ttu-id="501ce-186">ここでは、仮のテキストと省略記号 ("…") を、出力 [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683) の現在の値に追加します。</span><span class="sxs-lookup"><span data-stu-id="501ce-186">Here, we append the hypothetical text and an ellipsis ("…") to the current value of the output [**TextBox**](https://msdn.microsoft.com/library/windows/apps/br209683).</span></span> <span data-ttu-id="501ce-187">テキスト ボックスの内容は、新しい仮の結果が生成されるたびに更新され、最後に、最終的な結果が [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントから取得されます。</span><span class="sxs-lookup"><span data-stu-id="501ce-187">The contents of the text box are updated as new hypotheses are generated and until the final results are obtained from the [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event.</span></span>

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

## <a name="start-and-stop-recognition"></a><span data-ttu-id="501ce-188">認識の開始と停止</span><span class="sxs-lookup"><span data-stu-id="501ce-188">Start and stop recognition</span></span>


<span data-ttu-id="501ce-189">認識セッションを開始する前に、音声認識エンジンの [**State**](https://msdn.microsoft.com/library/windows/apps/dn913915) プロパティの値を確認します。</span><span class="sxs-lookup"><span data-stu-id="501ce-189">Before starting a recognition session, check the value of the speech recognizer [**State**](https://msdn.microsoft.com/library/windows/apps/dn913915) property.</span></span> <span data-ttu-id="501ce-190">音声認識エンジンは、[**Idle**](https://msdn.microsoft.com/library/windows/apps/dn653227) 状態である必要があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-190">The speech recognizer must be in an [**Idle**](https://msdn.microsoft.com/library/windows/apps/dn653227) state.</span></span>

<span data-ttu-id="501ce-191">音声認識エンジンの状態を確認した後、音声認識エンジンの [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) プロパティの [**StartAsync**](https://msdn.microsoft.com/library/windows/apps/dn913901) メソッドを呼び出してセッションを開始します。</span><span class="sxs-lookup"><span data-stu-id="501ce-191">After checking the state of the speech recognizer, we start the session by calling the [**StartAsync**](https://msdn.microsoft.com/library/windows/apps/dn913901) method of the speech recognizer's [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) property.</span></span>

```CSharp
if (speechRecognizer.State == SpeechRecognizerState.Idle)
{
  await speechRecognizer.ContinuousRecognitionSession.StartAsync();
}
```

<span data-ttu-id="501ce-192">認識を停止するには、次の 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-192">Recognition can be stopped in two ways:</span></span>

-   <span data-ttu-id="501ce-193">[**StopAsync**
            ](https://msdn.microsoft.com/library/windows/apps/dn913908) を使うと、保留中のすべての認識イベントが完了します ([**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) は、保留中のすべての操作が完了するまで、引き続き発生します)。</span><span class="sxs-lookup"><span data-stu-id="501ce-193">[**StopAsync**](https://msdn.microsoft.com/library/windows/apps/dn913908) lets any pending recognition events complete ([**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) continues to be raised until all pending recognition operations are complete).</span></span>
-   <span data-ttu-id="501ce-194">[**CancelAsync**
            ](https://msdn.microsoft.com/library/windows/apps/dn913898) を使うと、すぐに認識セッションが終了し、保留中の結果はすべて破棄されます。</span><span class="sxs-lookup"><span data-stu-id="501ce-194">[**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) terminates the recognition session immediately and discards any pending results.</span></span>

<span data-ttu-id="501ce-195">音声認識エンジンの状態を確認したら、音声認識エンジンの [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) プロパティの [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) メソッドを呼び出してセッションを停止します。</span><span class="sxs-lookup"><span data-stu-id="501ce-195">After checking the state of the speech recognizer, we stop the session by calling the [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) method of the speech recognizer's [**ContinuousRecognitionSession**](https://msdn.microsoft.com/library/windows/apps/dn913913) property.</span></span>

```CSharp
if (speechRecognizer.State != SpeechRecognizerState.Idle)
{
  await speechRecognizer.ContinuousRecognitionSession.CancelAsync();
}
```

> [!NOTE]
> <span data-ttu-id="501ce-196">[**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) を呼び出した後に [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントが発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-196">A [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event can occur after a call to [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898).</span></span>  
> <span data-ttu-id="501ce-197">マルチスレッドであるために、[**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) を呼び出したときに [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) イベントがスタックに残っている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="501ce-197">Because of multithreading, a [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) event might still remain on the stack when [**CancelAsync**](https://msdn.microsoft.com/library/windows/apps/dn913898) is called.</span></span> <span data-ttu-id="501ce-198">その場合は、**ResultGenerated** イベントも発生します。</span><span class="sxs-lookup"><span data-stu-id="501ce-198">If so, the **ResultGenerated** event still fires.</span></span>  
> <span data-ttu-id="501ce-199">プライベート フィールドを設定しているときに認識セッションをキャンセルした場合は、その値を常に [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) ハンドラーで確認してください。</span><span class="sxs-lookup"><span data-stu-id="501ce-199">If you set any private fields when canceling the recognition session, always confirm their values in the [**ResultGenerated**](https://msdn.microsoft.com/library/windows/apps/dn913900) handler.</span></span> <span data-ttu-id="501ce-200">たとえば、セッションをキャンセルしたときにプライベート フィールドを null に設定している場合はハンドラー内でフィールドが初期化されると想定しないでください。</span><span class="sxs-lookup"><span data-stu-id="501ce-200">For example, don't assume a field is initialized in your handler if you set them to null when you cancel the session.</span></span>

 

## <a name="related-articles"></a><span data-ttu-id="501ce-201">関連記事</span><span class="sxs-lookup"><span data-stu-id="501ce-201">Related articles</span></span>


* [<span data-ttu-id="501ce-202">音声操作</span><span class="sxs-lookup"><span data-stu-id="501ce-202">Speech interactions</span></span>](speech-interactions.md)

**<span data-ttu-id="501ce-203">サンプル</span><span class="sxs-lookup"><span data-stu-id="501ce-203">Samples</span></span>**
* [<span data-ttu-id="501ce-204">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="501ce-204">Speech recognition and speech synthesis sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




