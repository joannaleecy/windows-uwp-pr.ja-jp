---
author: Karl-Bridge-Microsoft
Description: Incorporate speech into your apps using Cortana voice commands, speech recognition, and speech synthesis.
title: 音声操作
ms.assetid: 646DB3CE-FA81-4727-8C21-936C81079439
label: Speech interactions
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 4006cdedffdbc601b498ce64caddfdefcbf4877a
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7145088"
---
# <a name="speech-interactions"></a><span data-ttu-id="58e57-103">音声操作</span><span class="sxs-lookup"><span data-stu-id="58e57-103">Speech interactions</span></span>

<span data-ttu-id="58e57-104">音声認識や音声合成 (TTS: text-to-speech) をアプリのユーザー エクスペリエンスに直接統合します。</span><span class="sxs-lookup"><span data-stu-id="58e57-104">Integrate speech recognition and text-to-speech (also known as TTS, or speech synthesis) directly into the user experience of your app.</span></span>

<span data-ttu-id="58e57-105">**音声認識:** ユーザーが発声した単語を、フォーム入力やテキストのディクテーション用にテキストに変換し、操作やコマンドを指定したり、タスクを実行したります。</span><span class="sxs-lookup"><span data-stu-id="58e57-105">**Speech recognition** Speech recognition converts words spoken by the user into text for form input, for text dictation, to specify an action or command, and to accomplish tasks.</span></span> <span data-ttu-id="58e57-106">この機能は、フリーテキストのディクテーションと Web 検索向けの定義済みの文法、および Speech Recognition Grammar Specification (SRGS) バージョン 1.0 を使って作成されたカスタム文法をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="58e57-106">Both pre-defined grammars for free-text dictation and web search, and custom grammars authored using Speech Recognition Grammar Specification (SRGS) Version 1.0 are supported.</span></span>

<span data-ttu-id="58e57-107">**TTS:** 音声合成エンジン (声) を使って、テキスト文字列を音声に変換します。</span><span class="sxs-lookup"><span data-stu-id="58e57-107">**TTS** TTS uses a speech synthesis engine (voice) to convert a text string into spoken words.</span></span> <span data-ttu-id="58e57-108">入力文字列は、基本的でシンプルなテキスト、またはより複雑な Speech Synthesis Markup Language (SSML) のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="58e57-108">The input string can be either basic, unadorned text or more complex Speech Synthesis Markup Language (SSML).</span></span> <span data-ttu-id="58e57-109">SSML は、発音、音量、ピッチ、速度、強調など、音声出力の特性を制御する標準的な方法です。</span><span class="sxs-lookup"><span data-stu-id="58e57-109">SSML provides a standard way to control characteristics of speech output, such as pronunciation, volume, pitch, rate or speed, and emphasis.</span></span>

<span data-ttu-id="58e57-110">**その他の音声関連のコンポーネント:**
Windows アプリケーションの **Cortana** ではカスタマイズした音声コマンド (発声したコマンドまたは入力したコマンド) を使って、アプリをフォアグラウンドで起動したり (スタート メニューから起動した場合と同様にアプリがフォーカスを取得します)、バック グラウンド サービスとしてアクティブ化したりすることができます (**Cortana** がフォーカスを維持しますが、アプリからの結果を表示します)。</span><span class="sxs-lookup"><span data-stu-id="58e57-110">**Other speech-related components:**
**Cortana** in Windows applications uses customized voice commands (spoken or typed) to launch your app to the foreground (the app takes focus, just as if it was launched from the Start menu) or activate as a background service (**Cortana** retains focus but provides results from the app).</span></span> <span data-ttu-id="58e57-111">**Cortana** UI でアプリの機能を公開する場合は、「[Cortana voice command (VCD) guidelines](https://docs.microsoft.com/en-us/cortana/voice-commands/vcd)」(Cortana 音声コマンド (VCD) のガイドライン) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="58e57-111">See the [Cortana voice command (VCD) guidelines](https://docs.microsoft.com/en-us/cortana/voice-commands/vcd) if you are exposing app functionality in the **Cortana** UI.</span></span>

## <a name="speech-interaction-design"></a><span data-ttu-id="58e57-112">音声操作の設計</span><span class="sxs-lookup"><span data-stu-id="58e57-112">Speech interaction design</span></span>

<span data-ttu-id="58e57-113">音声機能が適切に設計され、実装されていると、ユーザーがアプリを楽しく確実に操作できる手段になります。音声機能によって、キーボード、マウス、タッチ、ジェスチャを補完することも、場合によってはこれらの代替として使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="58e57-113">Designed and implemented thoughtfully, speech can be a robust and enjoyable way for people to interact with your app, complementing, or even replacing, keyboard, mouse, touch, and gestures.</span></span>

<span data-ttu-id="58e57-114">次のガイドラインと推奨事項では、最適な形で音声認識と TTS をアプリの操作エクスペリエンスに統合する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="58e57-114">These guidelines and recommendations describe how to best integrate both speech recognition and TTS into the interaction experience of your app.</span></span>

<span data-ttu-id="58e57-115">アプリで音声操作のサポートを検討している場合:</span><span class="sxs-lookup"><span data-stu-id="58e57-115">If you are considering supporting speech interactions in your app:</span></span>

-   <span data-ttu-id="58e57-116">音声認識では、どのような操作を実行できるか。</span><span class="sxs-lookup"><span data-stu-id="58e57-116">What actions can be taken through speech?</span></span> <span data-ttu-id="58e57-117">ユーザーは、ページ間の移動やコマンドの呼び出しを実行できるか。また、データをテキスト フィールド、簡単なメモ、長いメッセージとして入力できるか。</span><span class="sxs-lookup"><span data-stu-id="58e57-117">Can a user navigate between pages, invoke commands, or enter data as text fields, brief notes, or long messages?</span></span>
-   <span data-ttu-id="58e57-118">音声入力はタスクの実行に適した機能であるか。</span><span class="sxs-lookup"><span data-stu-id="58e57-118">Is speech input a good option for completing a task?</span></span>
-   <span data-ttu-id="58e57-119">音声入力が利用可能になっていることをユーザーはどのように認識するか。</span><span class="sxs-lookup"><span data-stu-id="58e57-119">How does a user know when speech input is available?</span></span>
-   <span data-ttu-id="58e57-120">アプリが常に聞き取りを行っているか、またはユーザーが操作を実行してアプリを聞き取りモードに切り替える必要があるか。</span><span class="sxs-lookup"><span data-stu-id="58e57-120">Is the app always listening, or does the user need to take an action for the app to enter listening mode?</span></span>
-   <span data-ttu-id="58e57-121">どのような語句が操作や動作を開始するか。</span><span class="sxs-lookup"><span data-stu-id="58e57-121">What phrases initiate an action or behavior?</span></span> <span data-ttu-id="58e57-122">語句と操作を画面に列挙する必要があるか。</span><span class="sxs-lookup"><span data-stu-id="58e57-122">Do the phrases and actions need to be enumerated on screen?</span></span>
-   <span data-ttu-id="58e57-123">プロンプト画面、確認画面、不明瞭解消画面、TTS が必要か。</span><span class="sxs-lookup"><span data-stu-id="58e57-123">Are prompt, confirmation, and disambiguation screens or TTS required?</span></span>
-   <span data-ttu-id="58e57-124">アプリとユーザー間の対話ダイアログは何か。</span><span class="sxs-lookup"><span data-stu-id="58e57-124">What is the interaction dialog between app and user?</span></span>
-   <span data-ttu-id="58e57-125">アプリのコンテキストに対してカスタムのボキャブラリや制約のあるボキャブラリが必要か (医学、科学、ロケールなど)。</span><span class="sxs-lookup"><span data-stu-id="58e57-125">Is a custom or constrained vocabulary required (such as medicine, science, or locale) for the context of your app?</span></span>
-   <span data-ttu-id="58e57-126">ネットワーク接続が必要か。</span><span class="sxs-lookup"><span data-stu-id="58e57-126">Is network connectivity required?</span></span>

## <a name="text-input"></a><span data-ttu-id="58e57-127">テキスト入力</span><span class="sxs-lookup"><span data-stu-id="58e57-127">Text input</span></span>

<span data-ttu-id="58e57-128">テキスト入力用の音声は、短い形式 (1 つの単語または語句) から長い形式 (継続的なディクテーション) までさまざまなものがあります。</span><span class="sxs-lookup"><span data-stu-id="58e57-128">Speech for text input can range from short form (single word or phrase) to long form (continuous dictation).</span></span> <span data-ttu-id="58e57-129">短い形式の入力は 10 秒未満の長さにする必要があり、長い形式の入力セッションは最大で 2 分の長さにすることができます </span><span class="sxs-lookup"><span data-stu-id="58e57-129">Short form input must be less than 10 seconds in length, while long form input session can be up to two minutes in length.</span></span> <span data-ttu-id="58e57-130">(長い形式の入力はユーザーが操作しなくても再開でき、継続的なディクテーションのような印象を与えることができます)。</span><span class="sxs-lookup"><span data-stu-id="58e57-130">(Long form input can be restarted without user intervention to give the impression of continuous dictation.)</span></span>

<span data-ttu-id="58e57-131">音声認識がサポートされていて、利用可能になっていること、およびユーザーが音声認識を有効にする必要があるかどうかを示すために、視覚的な合図を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="58e57-131">You should provide a visual cue to indicate that speech recognition is supported and available to the user and whether the user needs to turn it on.</span></span> <span data-ttu-id="58e57-132">たとえば、マイクのグリフが表示されるコマンド バー ボタン (「[コマンド バー](../controls-and-patterns/app-bars.md)」をご覧ください) を使って、音声認識が利用可能になっていることやその状態を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-132">For example, a command bar button with a microphone glyph (see [Command bars](../controls-and-patterns/app-bars.md)) can be used to show both availability and state.</span></span>

<span data-ttu-id="58e57-133">実行中の音声認識に対するフィードバックを提供することで、音声認識を実行しているときに、不十分な応答性を最小限に抑えることができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-133">Provide ongoing recognition feedback to minimize any apparent lack of response while recognition is being performed.</span></span>

<span data-ttu-id="58e57-134">キーボード入力、不明瞭解消のプロンプト、修正候補、追加の音声認識を使って、ユーザーが認識テキストを変更できるようにします。</span><span class="sxs-lookup"><span data-stu-id="58e57-134">Let users revise recognition text using keyboard input, disambiguation prompts, suggestions, or additional speech recognition.</span></span>

<span data-ttu-id="58e57-135">入力が音声認識以外のデバイス (タッチ入力やキーボードなど) から検出された場合は、認識を停止します。</span><span class="sxs-lookup"><span data-stu-id="58e57-135">Stop recognition if input is detected from a device other than speech recognition, such as touch or keyboard.</span></span> <span data-ttu-id="58e57-136">このような入力は、ユーザーが他のタスク (認識テキストの修正や他のフォーム フィールドの操作など) に移行したことを示している可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-136">This probably indicates that the user has moved onto another task, such as correcting the recognition text or interacting with other form fields.</span></span>

<span data-ttu-id="58e57-137">音声入力がないときに認識を終了までの時間を指定します。</span><span class="sxs-lookup"><span data-stu-id="58e57-137">Specify the length of time for which no speech input indicates that recognition is over.</span></span> <span data-ttu-id="58e57-138">この時間が経過した後で音声認識を自動的に再開しないでください。これは、ユーザーがアプリの操作を停止したことを示している場合が多いためです。</span><span class="sxs-lookup"><span data-stu-id="58e57-138">Do not automatically restart recognition after this period of time as it typically indicates the user has stopped engaging with your app.</span></span>

<span data-ttu-id="58e57-139">ネットワーク接続が利用できない場合は、すべての継続的な認識 UI を無効にし、認識セッションを停止します。</span><span class="sxs-lookup"><span data-stu-id="58e57-139">Disable all continuous recognition UI and terminate the recognition session if a network connection is not available.</span></span> <span data-ttu-id="58e57-140">継続的な認識では、ネットワーク接続が必要です。</span><span class="sxs-lookup"><span data-stu-id="58e57-140">Continuous recogntion requires a network connection.</span></span>

## <a name="commanding"></a><span data-ttu-id="58e57-141">コマンド実行</span><span class="sxs-lookup"><span data-stu-id="58e57-141">Commanding</span></span>

<span data-ttu-id="58e57-142">音声入力によって、操作の開始、コマンドの呼び出し、タスクの実行を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-142">Speech input can initiate actions, invoke commands, and accomplish tasks.</span></span>

<span data-ttu-id="58e57-143">画面に余裕がある場合は、現在のアプリのコンテキストでサポートされている応答を、有効な入力の例と一緒に表示することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="58e57-143">If space permits, consider displaying the supported responses for the current app context, with examples of valid input.</span></span> <span data-ttu-id="58e57-144">これにより、場合によっては、アプリで処理する必要がある応答を減らすことできます。また、ユーザーが入力に迷うことが少なくなる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="58e57-144">This reduces the potential responses your app has to process and also eliminates confusion for the user.</span></span>

<span data-ttu-id="58e57-145">できる限り具体的な応答を引き出せるように、質問を構成します。</span><span class="sxs-lookup"><span data-stu-id="58e57-145">Try to frame your questions such that they elicit as specific a response as possible.</span></span> <span data-ttu-id="58e57-146">たとえば、「今日は何をしたいですか?」</span><span class="sxs-lookup"><span data-stu-id="58e57-146">For example, "What do you want to do today?"</span></span> <span data-ttu-id="58e57-147">は何とおりもの応答ができる質問であり、さまざまな応答の可能性があるため膨大な量の文法定義が必要になります。</span><span class="sxs-lookup"><span data-stu-id="58e57-147">is very open ended and would require a very large grammar definition due to how varied the responses could be.</span></span> <span data-ttu-id="58e57-148">また、「ゲームをプレイしますか、それとも音楽を聴きますか?」</span><span class="sxs-lookup"><span data-stu-id="58e57-148">Alternatively, "Would you like to play a game or listen to music?"</span></span> <span data-ttu-id="58e57-149">という質問では、2 つの有効な回答のいずれか 1 つに応答が制限されます。このため、文法定義の量も少なくなります。</span><span class="sxs-lookup"><span data-stu-id="58e57-149">constrains the response to one of two valid answers with a correspondingly small grammar definition.</span></span> <span data-ttu-id="58e57-150">文法定義の量が少ないと作成が容易になり、認識結果の精度が向上します。</span><span class="sxs-lookup"><span data-stu-id="58e57-150">A small grammar is much easier to author and results in much more accurate recognition results.</span></span>

<span data-ttu-id="58e57-151">音声認識の信頼性が低い場合には、ユーザーに確認を求めます。</span><span class="sxs-lookup"><span data-stu-id="58e57-151">Request confirmation from the user when speech recognition confidence is low.</span></span> <span data-ttu-id="58e57-152">ユーザーの意図が明らかでない場合は、ユーザーが意図していない操作を開始するよりも、ユーザーの意図を明確にする方が、良い結果につながります。</span><span class="sxs-lookup"><span data-stu-id="58e57-152">If the user's intent is unclear, it's better to get clarification than to initiate an unintended action.</span></span>

<span data-ttu-id="58e57-153">音声認識がサポートされていて、利用可能になっていること、およびユーザーが音声認識を有効にする必要があるかどうかを示すために、視覚的な合図を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="58e57-153">You should provide a visual cue to indicate that speech recognition is supported and available to the user and whether the user needs to turn it on.</span></span> <span data-ttu-id="58e57-154">たとえば、マイクのグリフが表示されるコマンド バー ボタン (「[コマンド バーのガイドライン](../controls-and-patterns/app-bars.md)」をご覧ください) を使って、音声認識が利用可能になっていことやその状態を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-154">For example, a command bar button with a microphone glyph (see [Guidelines for command bars](../controls-and-patterns/app-bars.md)) can be used to show both availability and state.</span></span>

<span data-ttu-id="58e57-155">通常、音声認識のスイッチが画面から消える場合は、アプリのコンテンツ領域に状態インジケーターを表示することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="58e57-155">If the speech recognition switch is typically out of view, consider displaying a state indicator in the content area of the app.</span></span>

<span data-ttu-id="58e57-156">音声認識がユーザーによって開始される場合は、一貫性を維持するために組み込みの認識エクスペリエンスを使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="58e57-156">If recognition is initiated by the user, consider using the built-in recognition experience for consistency.</span></span> <span data-ttu-id="58e57-157">組み込みのエクスペリエンスには、プロンプト、例、不明瞭解消、確認、エラーが表示されるカスタマイズ可能な画面が含まれています。</span><span class="sxs-lookup"><span data-stu-id="58e57-157">The built-in experience includes customizable screens with prompts, examples, disambiguations, confirmations, and errors.</span></span>

<span data-ttu-id="58e57-158">画面は、指定した制約によって異なります。</span><span class="sxs-lookup"><span data-stu-id="58e57-158">The screens vary depending on the specified constraints:</span></span>

-   <span data-ttu-id="58e57-159">定義済みの文法の場合 (ディクテーションまたは Web 検索)</span><span class="sxs-lookup"><span data-stu-id="58e57-159">Pre-defined grammar (dictation or web search)</span></span>

    -   <span data-ttu-id="58e57-160">**[聞き取り中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="58e57-160">The **Listening** screen.</span></span>
    -   <span data-ttu-id="58e57-161">**[認識中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="58e57-161">The **Thinking** screen.</span></span>
    -   <span data-ttu-id="58e57-162">**[聞き取りの確認]** 画面またはエラー画面。</span><span class="sxs-lookup"><span data-stu-id="58e57-162">The **Heard you say** screen or the error screen.</span></span>
-   <span data-ttu-id="58e57-163">単語や語句の一覧または SGRS 文法ファイルの場合</span><span class="sxs-lookup"><span data-stu-id="58e57-163">List of words or phrases, or a SRGS grammar file</span></span>

    -   <span data-ttu-id="58e57-164">**[聞き取り中]** 画面。</span><span class="sxs-lookup"><span data-stu-id="58e57-164">The **Listening** screen.</span></span>
    -   <span data-ttu-id="58e57-165">**[確認]** 画面 (ユーザーの発言が複数の潜在的な結果として解釈できる場合)。</span><span class="sxs-lookup"><span data-stu-id="58e57-165">The **Did you say** screen, if what the user said could be interpreted as more than one potential result.</span></span>
    -   <span data-ttu-id="58e57-166">**[聞き取りの確認]** 画面またはエラー画面。</span><span class="sxs-lookup"><span data-stu-id="58e57-166">The **Heard you say** screen or the error screen.</span></span>

<span data-ttu-id="58e57-167">**[聞き取り中]** 画面では、次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="58e57-167">On the **Listening** screen you can:</span></span>

-   <span data-ttu-id="58e57-168">見出しテキストのカスタマイズ。</span><span class="sxs-lookup"><span data-stu-id="58e57-168">Customize the heading text.</span></span>
-   <span data-ttu-id="58e57-169">ユーザーが声に出すことができる内容のサンプル テキストの指定。</span><span class="sxs-lookup"><span data-stu-id="58e57-169">Provide example text of what the user can say.</span></span>
-   <span data-ttu-id="58e57-170">**[聞き取りの確認]** 画面が表示されるかどうかの指定。</span><span class="sxs-lookup"><span data-stu-id="58e57-170">Specify whether the **Heard you say** screen is shown.</span></span>
-   <span data-ttu-id="58e57-171">認識された文字列を **[聞き取りの確認]** 画面でユーザーに対して読み返す。</span><span class="sxs-lookup"><span data-stu-id="58e57-171">Read the recognized string back to the user on the **Heard you say** screen.</span></span>

<span data-ttu-id="58e57-172">SRGS で定義された制約を使う音声認識エンジンにおける組み込みの認識フローの例を、次に示します。</span><span class="sxs-lookup"><span data-stu-id="58e57-172">Here is an example of the built-in recognition flow for a speech recognizer that uses a SRGS-defined constraint.</span></span> <span data-ttu-id="58e57-173">この例では、音声認識に成功しています。</span><span class="sxs-lookup"><span data-stu-id="58e57-173">In this example, speech recognition is successful.</span></span>

![SGRS 文法ファイルに基づく制約の場合の、最初の認識画面](images/speech/speech-listening-initial.png)

![SGRS 文法ファイルに基づく制約の場合の、途中の認識画面](images/speech/speech-listening-intermediate.png)

![SGRS 文法ファイルに基づく制約の場合の、最終的な認識画面](images/speech/speech-listening-complete.png)

## <a name="always-listening"></a><span data-ttu-id="58e57-177">常に聞き取る</span><span class="sxs-lookup"><span data-stu-id="58e57-177">Always listening</span></span>

<span data-ttu-id="58e57-178">ユーザーが操作しなくても、アプリを起動してすぐに、音声入力の聞き取りと認識を実行できます。</span><span class="sxs-lookup"><span data-stu-id="58e57-178">Your app can listen for and recognize speech input as soon as the app is launched, without user intervention.</span></span>

<span data-ttu-id="58e57-179">アプリのコンテキストに基づいて、文法の制約をカスタマイズしてください。</span><span class="sxs-lookup"><span data-stu-id="58e57-179">You should customize the grammar constraints based on the app context.</span></span> <span data-ttu-id="58e57-180">これにより、音声認識エクスペリエンスがターゲットとして維持され、現在のタスクとの関連が継続されます。また、エラーを最小限に抑えることができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-180">This keeps the speech recognition experience very targeted and relevant to the current task, and minimizes errors.</span></span>

## <a name="what-can-i-say"></a><span data-ttu-id="58e57-181">音声操作の項目</span><span class="sxs-lookup"><span data-stu-id="58e57-181">"What can I say?"</span></span>

<span data-ttu-id="58e57-182">音声入力が有効になっているとき、どのような単語と語句が正確に理解されるか、またどのような操作を実行できるかを、ユーザーが検出できるようにすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="58e57-182">When speech input is enabled, it's important to help users discover what exactly can be understood and what actions can be performed.</span></span>

<span data-ttu-id="58e57-183">音声認識がユーザーよって有効化される場合は、コマンド バーやメニュー コマンドを使って、現在のコンテキストでサポートされているすべての単語と語句を表示することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="58e57-183">If speech recognition is user enabled, consider using the command bar or a menu command to show all words and phrases supported in the current context.</span></span>

<span data-ttu-id="58e57-184">音声認識が常に有効になっている場合は、すべてのページに "音声操作の項目" </span><span class="sxs-lookup"><span data-stu-id="58e57-184">If speech recognition is always on, consider adding the phrase "What can I say?"</span></span> <span data-ttu-id="58e57-185">という語句を追加することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="58e57-185">to every page.</span></span> <span data-ttu-id="58e57-186">ユーザーがこの語句を発声すると、現在のコンテキストでサポートされているすべての単語と語句が表示されます。</span><span class="sxs-lookup"><span data-stu-id="58e57-186">When the user says this phrase, display all words and phrases supported in the current context.</span></span> <span data-ttu-id="58e57-187">このフレーズを使うと、ユーザーは一貫した方法でシステムに実装されている音声機能を検出することができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-187">Using this phrase provides a consistent way for users to discover speech capabilities across the system.</span></span>

## <a name="recognition-failures"></a><span data-ttu-id="58e57-188">認識の失敗</span><span class="sxs-lookup"><span data-stu-id="58e57-188">Recognition failures</span></span>

<span data-ttu-id="58e57-189">音声認識は失敗する場合があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-189">Speech recognition will fail.</span></span> <span data-ttu-id="58e57-190">オーディオ品質が低い場合、語句の一部しか認識できない場合、または入力がまったく検出されない場合は、音声認識が失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-190">Failures happen when audio quality is poor, when only part of a phrase is recognized, or when no input is detected at all.</span></span>

<span data-ttu-id="58e57-191">失敗を適切に処理することで、ユーザーは認識が失敗した理由を理解し、回復することが可能になります。</span><span class="sxs-lookup"><span data-stu-id="58e57-191">Handle failure gracefully, help a user understand why recognition failed, and recover.</span></span>

<span data-ttu-id="58e57-192">音声入力が理解されなかった点と再試行する必要がある点を、アプリでユーザーに伝えてください。</span><span class="sxs-lookup"><span data-stu-id="58e57-192">Your app should inform the user that they weren't understood and that they need to try again.</span></span>

<span data-ttu-id="58e57-193">サポートされている 1 つ以上の語句を例として提示することを検討します。</span><span class="sxs-lookup"><span data-stu-id="58e57-193">Consider providing examples of one or more supported phrases.</span></span> <span data-ttu-id="58e57-194">ユーザーは提示された語句を再度入力する可能性があります。これにより、認識が成功する確率が高くなります。</span><span class="sxs-lookup"><span data-stu-id="58e57-194">The user is likely to repeat a suggested phrase, which increases recognition success.</span></span>

<span data-ttu-id="58e57-195">一致する可能性がある語句の一覧を表示し、ユーザーが選ぶことができるようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="58e57-195">You should display a list of potential matches for a user to select from.</span></span> <span data-ttu-id="58e57-196">こうした対処方法は、認識プロセスを再度やり直すよりも効率的です。</span><span class="sxs-lookup"><span data-stu-id="58e57-196">This can be far more efficient than going through the recognition process again.</span></span>

<span data-ttu-id="58e57-197">別の種類の入力方法を常にサポートしてください。認識の失敗が繰り返し発生した場合、その失敗を処理する際に特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="58e57-197">You should always support alternative input types, which is especially helpful for handling repeated recognition failures.</span></span> <span data-ttu-id="58e57-198">たとえば、キーボード、タッチ入力、またはマウスを使って、一致する可能性がある語句の一覧から選ぶように提案します。</span><span class="sxs-lookup"><span data-stu-id="58e57-198">For example, you could suggest that the user try to use a keyboard, or use touch or a mouse to select from a list of potential matches.</span></span>

<span data-ttu-id="58e57-199">組み込みの音声認識エクスペリエンスを使います。この音声認識エクスペリエンスには、音声認識に失敗したことをユーザーに通知し、ユーザーが音声認識をもう一度試行できる画面が含まれています。</span><span class="sxs-lookup"><span data-stu-id="58e57-199">Use the built-in speech recognition experience as it includes screens that inform the user that recognition was not successful and lets the user make another recognition attempt.</span></span>

<span data-ttu-id="58e57-200">オーディオ入力の問題を検出し、修正を試みます。</span><span class="sxs-lookup"><span data-stu-id="58e57-200">Listen for and try to correct issues in the audio input.</span></span> <span data-ttu-id="58e57-201">音声認識エンジンでは、音声認識の正確さにマイナスの影響を与える可能性があるオーディオ品質の問題を検出できます。</span><span class="sxs-lookup"><span data-stu-id="58e57-201">The speech recognizer can detect issues with the audio quality that might adversely affect speech recognition accuracy.</span></span> <span data-ttu-id="58e57-202">音声認識エンジンから提供される情報を使うと、問題をユーザーに通知し、可能であれば対処するように指示することができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-202">You can use the information provided by the speech recognizer to inform the user of the issue and let them take corrective action, if possible.</span></span> <span data-ttu-id="58e57-203">たとえば、マイクの音量設定が低すぎる場合は、もっと大きな声で話すことやボリュームを上げることをユーザーに求めることができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-203">For example, if the volume setting on the microphone is too low, you can prompt the user to speak louder or turn the volume up.</span></span>

## <a name="constraints"></a><span data-ttu-id="58e57-204">制約</span><span class="sxs-lookup"><span data-stu-id="58e57-204">Constraints</span></span>

<span data-ttu-id="58e57-205">制約 (文法) は、発声される単語や語句を定義します。これらの単語や語句は、音声認識エンジンによって照合することができる単語や語句です。</span><span class="sxs-lookup"><span data-stu-id="58e57-205">Constraints, or grammars, define the spoken words and phrases that can be matched by the speech recognizer.</span></span> <span data-ttu-id="58e57-206">定義済みの Web サービスの文法のいずれかを使ったり、アプリと共にインストールされるカスタムの文法を作成したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-206">You can specify one of the pre-defined web service grammars or you can create a custom grammar that is installed with your app.</span></span>

### <a name="predefined-grammars"></a><span data-ttu-id="58e57-207">定義済みの文法</span><span class="sxs-lookup"><span data-stu-id="58e57-207">Predefined grammars</span></span>

<span data-ttu-id="58e57-208">定義済みのディクテーション文法と Web 検索文法を使うと、文法を作らずにアプリに音声認識を実装できます。</span><span class="sxs-lookup"><span data-stu-id="58e57-208">Predefined dictation and web-search grammars provide speech recognition for your app without requiring you to author a grammar.</span></span> <span data-ttu-id="58e57-209">これらの文法を使った場合、音声認識がリモート Web サービスで実行され、結果がデバイスに返されます。</span><span class="sxs-lookup"><span data-stu-id="58e57-209">When using these grammars, speech recognition is performed by a remote web service and the results are returned to the device</span></span>

-   <span data-ttu-id="58e57-210">既定のフリーテキストのディクテーション文法では、ユーザーが特定の言語で話すほとんどの単語と語句を認識できます。これは短い語句の認識に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="58e57-210">The default free-text dictation grammar can recognize most words and phrases that a user can say in a particular language, and is optimized to recognize short phrases.</span></span> <span data-ttu-id="58e57-211">フリーテキストのディクテーションは、ユーザーが話す内容を限定しない場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="58e57-211">Free-text dictation is useful when you don't want to limit the kinds of things a user can say.</span></span> <span data-ttu-id="58e57-212">一般的な用途としては、メモの作成やメッセージ内容の口述などがあります。</span><span class="sxs-lookup"><span data-stu-id="58e57-212">Typical uses include creating notes or dictating the content for a message.</span></span>
-   <span data-ttu-id="58e57-213">Web 検索文法は、ユーザーが話す可能性のある多数の単語と語句を含んでいる点でディクテーション文法と似ています</span><span class="sxs-lookup"><span data-stu-id="58e57-213">The web-search grammar, like a dictation grammar, contains a large number of words and phrases that a user might say.</span></span> <span data-ttu-id="58e57-214">ただし、ユーザーが Web 検索で一般的に使う用語の認識に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="58e57-214">However, it is optimized to recognize terms that people typically use when searching the web.</span></span>

> [!NOTE]
> <span data-ttu-id="58e57-215">定義済みのディクテーション文法と Web 検索文法は容量が大きく、(デバイス上ではなく) オンライン上に存在するため、カスタム文法をデバイスにインストールした場合に比べるとパフォーマンスが劣る可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-215">Because predefined dictation and web-search grammars can be large, and because they are online (not on the device), performance might not be as fast as with a custom grammar installed on the device.</span></span>

<span data-ttu-id="58e57-216">このような定義済みの文法は、10 秒までの長さの音声入力を認識でき、開発者による作成作業は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="58e57-216">These predefined grammars can be used to recognize up to 10 seconds of speech input and require no authoring effort on your part.</span></span> <span data-ttu-id="58e57-217">ただし、ネットワークへの接続が必要になります。</span><span class="sxs-lookup"><span data-stu-id="58e57-217">However, they do require connection to a network.</span></span>

### <a name="custom-grammars"></a><span data-ttu-id="58e57-218">カスタム文法</span><span class="sxs-lookup"><span data-stu-id="58e57-218">Custom grammars</span></span>

<span data-ttu-id="58e57-219">カスタム文法はお客様が設計および作成を行い、アプリと共にインストールされます。</span><span class="sxs-lookup"><span data-stu-id="58e57-219">A custom grammar is designed and authored by you and is installed with your app.</span></span> <span data-ttu-id="58e57-220">カスタム制約を使う音声認識は、デバイスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="58e57-220">Speech recognition using a custom constraint is performed on the device.</span></span>

-   <span data-ttu-id="58e57-221">プログラムによる一覧の制約は、単語や語句の一覧を使って単純な文法を作成する手法で、軽量です。</span><span class="sxs-lookup"><span data-stu-id="58e57-221">Programmatic list constraints provide a lightweight approach to creating simple grammars using a list of words or phrases.</span></span> <span data-ttu-id="58e57-222">個別の短い語句を認識するには、一覧の制約が適しています。</span><span class="sxs-lookup"><span data-stu-id="58e57-222">A list constraint works well for recognizing short, distinct phrases.</span></span> <span data-ttu-id="58e57-223">文法にすべての単語を明示的に指定すると、音声認識エンジンは音声と単語の一致を確認する際に音声だけを処理すればよいので、認識の精度が向上します。</span><span class="sxs-lookup"><span data-stu-id="58e57-223">Explicitly specifying all words in a grammar also improves recognition accuracy, as the speech recognition engine must only process speech to confirm a match.</span></span> <span data-ttu-id="58e57-224">また、一覧はプログラムで更新することもできます。</span><span class="sxs-lookup"><span data-stu-id="58e57-224">The list can also be programmatically updated.</span></span>
-   <span data-ttu-id="58e57-225">SRGS 文法は静的ドキュメントで、プログラムによる一覧の制約とは異なり、[SRGS Version 1.0](http://go.microsoft.com/fwlink/p/?LinkID=262302) で定義された XML 形式を使います。</span><span class="sxs-lookup"><span data-stu-id="58e57-225">An SRGS grammar is a static document that, unlike a programmatic list constraint, uses the XML format defined by the [SRGS Version 1.0](http://go.microsoft.com/fwlink/p/?LinkID=262302).</span></span> <span data-ttu-id="58e57-226">SRGS 文法では、1 回の認識で複数の意味をキャプチャすることができるため、音声認識エクスペリエンスを最大限に制御することができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-226">An SRGS grammar provides the greatest control over the speech recognition experience by letting you capture multiple semantic meanings in a single recognition.</span></span>

    <span data-ttu-id="58e57-227">SRGS 文法を作成するためのヒントを次にいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="58e57-227">Here are some tips for authoring SRGS grammars:</span></span>

    -   <span data-ttu-id="58e57-228">各文法の規模を小さくします。</span><span class="sxs-lookup"><span data-stu-id="58e57-228">Keep each grammar small.</span></span> <span data-ttu-id="58e57-229">文法に含める語句を少なくする方が、規模の大きな文法に多数の語句が含まれている場合よりも、認識精度が高くなる傾向があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-229">Grammars that contain fewer phrases tend to provide more accurate recognition than larger grammars that contain many phrases.</span></span> <span data-ttu-id="58e57-230">アプリ全体に対して 1 つの文法を設定するよりも、特定のシナリオごとに別々の小規模な文法を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="58e57-230">It's better to have several smaller grammars for specific scenarios than to have a single grammar for your entire app.</span></span>
    -   <span data-ttu-id="58e57-231">ユーザーには、各アプリのコンテキストに基づいて何と話しかければよいかを知らせ、必要に応じて文法を無効にします。</span><span class="sxs-lookup"><span data-stu-id="58e57-231">Let users know what to say for each app context and enable and disable grammars as needed.</span></span>
    -   <span data-ttu-id="58e57-232">文法は、ユーザーがさまざまな形でコマンドを音声入力できるように設計します。</span><span class="sxs-lookup"><span data-stu-id="58e57-232">Design each grammar so users can speak a command in a variety of ways.</span></span> <span data-ttu-id="58e57-233">たとえば、**GARBAGE** 規則を使って、文法で定義されていない音声入力を照合することができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-233">For example, you can use the **GARBAGE** rule to match speech input that your grammar does not define.</span></span> <span data-ttu-id="58e57-234">これにより、ユーザーはアプリにとって意味を持たない語句を含めて話すことができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-234">This lets users speak additional words that have no meaning to your app.</span></span> <span data-ttu-id="58e57-235">たとえば、"お願い"、"それと"、"ええと"、"多分" などの語句を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="58e57-235">For example, "give me", "and", "uh", "maybe", and so on.</span></span>
    -   <span data-ttu-id="58e57-236">音声入力の認識率を高めるには、[sapi:subset](http://msdn.microsoft.com/library/windowsphone/design/jj572474.aspx) 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="58e57-236">Use the [sapi:subset](http://msdn.microsoft.com/library/windowsphone/design/jj572474.aspx) element to help match speech input.</span></span> <span data-ttu-id="58e57-237">この要素は、部分的な語句の照合をサポートするための、SRGS 仕様に対する Microsoft の拡張機能です。</span><span class="sxs-lookup"><span data-stu-id="58e57-237">This is a Microsoft extension to the SRGS specification to help match partial phrases.</span></span>
    -   <span data-ttu-id="58e57-238">音節が 1 つしかない語句は、文法に定義しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="58e57-238">Try to avoid defining phrases in your grammar that contain only one syllable.</span></span> <span data-ttu-id="58e57-239">音節が 2 つ以上ある語句の方が、正確に認識されやすくなります。</span><span class="sxs-lookup"><span data-stu-id="58e57-239">Recognition tends to be more accurate for phrases containing two or more syllables.</span></span>
    -   <span data-ttu-id="58e57-240">同じように聞こえる語句を使わないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="58e57-240">Avoid using phrases that sound similar.</span></span> <span data-ttu-id="58e57-241">たとえば、"hello"、"bellow"、"fellow" などの語句を使うと音声認識エンジンが混乱し、認識精度が低くなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-241">For example, phrases such as "hello", "bellow", and "fellow" can confuse the recognition engine and result in poor recognition accuracy.</span></span>

> [!NOTE]
> <span data-ttu-id="58e57-242">どの種類の制約を使うかは、作成する認識エクスペリエンスの複雑さによって決まります。</span><span class="sxs-lookup"><span data-stu-id="58e57-242">Which type of constraint type you use depends on the complexity of the recognition experience you want to create.</span></span> <span data-ttu-id="58e57-243">どの種類の制約も特定の認識タスクに最適な選択肢となる可能性があり、アプリですべての種類の制約を使う場合もあります。</span><span class="sxs-lookup"><span data-stu-id="58e57-243">Any could be the best choice for a specific recognition task, and you might find uses for all types of constraints in your app.</span></span>

### <a name="custom-pronunciations"></a><span data-ttu-id="58e57-244">カスタムの発音</span><span class="sxs-lookup"><span data-stu-id="58e57-244">Custom pronunciations</span></span>

<span data-ttu-id="58e57-245">一般的ではない単語や架空の単語を含む特殊なボキャブラリや、普通とは異なる発音の単語がアプリに含まれる場合は、カスタムの発音を定義することで、認識性能が高まる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-245">If your app contains specialized vocabulary with unusual or fictional words, or words with uncommon pronunciations, you might be able to improve recognition performance for those words by defining custom pronunciations.</span></span>

<span data-ttu-id="58e57-246">単語や語句の一覧が小規模な場合や、あまり使われない単語や語句の一覧の場合、カスタムの発音を SRGS 文法で作成できます。</span><span class="sxs-lookup"><span data-stu-id="58e57-246">For a small list of words and phrases, or a list of infrequently used words and phrases, you can create custom pronunciations in a SRGS grammar.</span></span> <span data-ttu-id="58e57-247">詳しくは、「[token 要素](http://msdn.microsoft.com/library/windowsphone/design/hh361600.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="58e57-247">See [token Element](http://msdn.microsoft.com/library/windowsphone/design/hh361600.aspx) for more info.</span></span>

<span data-ttu-id="58e57-248">単語や語句の一覧が大規模な場合や、頻繁に使われる単語や語句については、発音辞書のドキュメントを別途作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="58e57-248">For larger lists of words and phrases, or frequently used words and phrases, you can create separate pronunciation lexicon documents.</span></span> <span data-ttu-id="58e57-249">詳しくは、[辞書と音標文字に関するページ](http://msdn.microsoft.com/library/windowsphone/design/hh361646.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="58e57-249">See [About Lexicons and Phonetic Alphabets](http://msdn.microsoft.com/library/windowsphone/design/hh361646.aspx) for more info.</span></span>

## <a name="testing"></a><span data-ttu-id="58e57-250">テスト</span><span class="sxs-lookup"><span data-stu-id="58e57-250">Testing</span></span>

<span data-ttu-id="58e57-251">音声認識の精度のテストとサポートされている UI のテストは、アプリの対象ユーザーに対して行います。</span><span class="sxs-lookup"><span data-stu-id="58e57-251">Test speech recognition accuracy and any supporting UI with your app's target audience.</span></span> <span data-ttu-id="58e57-252">このようなテスト方法は、アプリの音声操作エクスペリエンスの有効性を判断するために最適な方法です。</span><span class="sxs-lookup"><span data-stu-id="58e57-252">This is the best way to determine the effectiveness of the speech interaction experience in your app.</span></span> <span data-ttu-id="58e57-253">たとえば、アプリが一般的な語句を聞き取らないために、ユーザーが良好な認識結果を得られない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-253">For example, are users getting poor recognition results because your app isn't listening for a common phrase?</span></span>

<span data-ttu-id="58e57-254">このような場合は、該当する語句をサポートするように文法を変更したり、サポートされている語句の一覧をユーザーに提供したりします。</span><span class="sxs-lookup"><span data-stu-id="58e57-254">Either modify the grammar to support this phrase or provide users with a list of supported phrases.</span></span> <span data-ttu-id="58e57-255">サポートされている語句の一覧を既に提供している場合は、その一覧を簡単に見つけることができるかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="58e57-255">If you already provide the list of supported phrases, ensure it is easily discoverable.</span></span>

## <a name="text-to-speech-tts"></a><span data-ttu-id="58e57-256">音声合成 (TTS)</span><span class="sxs-lookup"><span data-stu-id="58e57-256">Text-to-speech (TTS)</span></span>

<span data-ttu-id="58e57-257">TTS では、プレーンテキストまたは SSML から音声出力が生成されます。</span><span class="sxs-lookup"><span data-stu-id="58e57-257">TTS generates speech output from plain text or SSML.</span></span>

<span data-ttu-id="58e57-258">ていねいな言葉使いで音声入力を促すようなプロンプトを設計します。</span><span class="sxs-lookup"><span data-stu-id="58e57-258">Try to design prompts that are polite and encouraging.</span></span>

<span data-ttu-id="58e57-259">長いテキスト文字列を読み取る必要があるかどうかを検討します。</span><span class="sxs-lookup"><span data-stu-id="58e57-259">Consider whether you should read long strings of text.</span></span> <span data-ttu-id="58e57-260">1 つのテキスト メッセージを聞き取ることと、記憶するのが困難な長い検索結果の一覧を聞き取ることは別のことです。</span><span class="sxs-lookup"><span data-stu-id="58e57-260">It's one thing to listen to a text message, but quite another to listen to a long list of search results that are difficult to remember.</span></span>

<span data-ttu-id="58e57-261">ユーザーが TTS を一時停止または停止できるように、メディア コントロールを用意します。</span><span class="sxs-lookup"><span data-stu-id="58e57-261">You should provide media controls to let users pause, or stop, TTS.</span></span>

<span data-ttu-id="58e57-262">すべての TTS 文字列を聞き取り、それらの文字列が明瞭かつ自然な話し方になっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="58e57-262">You should listen to all TTS strings to ensure they are intelligible and sound natural.</span></span>

-   <span data-ttu-id="58e57-263">単語が不自然な順番で連続している場合や、文字列に含まれる数値や句読点を発声する場合に、語句が不明瞭になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-263">Stringing together an unusual sequence of words or speaking part numbers or punctuation might cause a phrase to become unintelligible.</span></span>
-   <span data-ttu-id="58e57-264">韻律や抑揚がネイティブ スピーカーによる発声と異なると、音声が不自然に聞こえる場合があります。</span><span class="sxs-lookup"><span data-stu-id="58e57-264">Speech can sound unnatural when the prosody or cadence is different from how a native speaker would say a phrase.</span></span>

<span data-ttu-id="58e57-265">どちらの問題も、スピーチ シンセサイザーへの入力にプレーンテキストではなく SSML を使うことで対処できます。</span><span class="sxs-lookup"><span data-stu-id="58e57-265">Both issues can be addressed bu using SSML instead of plain text as input to the speech synthesizer.</span></span> <span data-ttu-id="58e57-266">SSML について詳しくは、「[SSML による合成音声の制御](http://msdn.microsoft.com/library/windowsphone/design/hh378454.aspx)」と「[Speech Synthesis Markup Language (SSML) のリファレンス](http://msdn.microsoft.com/library/windowsphone/design/hh378377.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="58e57-266">For more info about SSML, see [Use SSML to Control Synthesized Speech](http://msdn.microsoft.com/library/windowsphone/design/hh378454.aspx) and [Speech Synthesis Markup Language Reference](http://msdn.microsoft.com/library/windowsphone/design/hh378377.aspx).</span></span>

## <a name="other-articles-in-this-section"></a><span data-ttu-id="58e57-267">このセクションの他の記事</span><span class="sxs-lookup"><span data-stu-id="58e57-267">Other articles in this section</span></span> 

| <span data-ttu-id="58e57-268">トピック</span><span class="sxs-lookup"><span data-stu-id="58e57-268">Topic</span></span> | <span data-ttu-id="58e57-269">説明</span><span class="sxs-lookup"><span data-stu-id="58e57-269">Description</span></span> |
| --- | --- |
| [<span data-ttu-id="58e57-270">音声認識</span><span class="sxs-lookup"><span data-stu-id="58e57-270">Speech recognition</span></span>](speech-recognition.md) | <span data-ttu-id="58e57-271">音声認識を使って、入力を行ったり、操作やコマンドを指定したり、タスクを実行したりできます。</span><span class="sxs-lookup"><span data-stu-id="58e57-271">Use speech recognition to provide input, specify an action or command, and accomplish tasks.</span></span> |
| [<span data-ttu-id="58e57-272">音声認識エンジンの言語の指定</span><span class="sxs-lookup"><span data-stu-id="58e57-272">Specify the speech recognizer language</span></span>](specify-the-speech-recognizer-language.md) | <span data-ttu-id="58e57-273">音声認識に使われるインストール済みの言語を選ぶ方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="58e57-273">Learn how to select an installed language to use for speech recognition.</span></span> |
| [<span data-ttu-id="58e57-274">カスタム認識の制約の定義</span><span class="sxs-lookup"><span data-stu-id="58e57-274">Define custom recognition constraints</span></span>](define-custom-recognition-constraints.md) | <span data-ttu-id="58e57-275">音声認識のカスタム制約を定義して使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="58e57-275">Learn how to define and use custom constraints for speech recognition.</span></span> |
| [<span data-ttu-id="58e57-276">継続的なディクテーションの有効化</span><span class="sxs-lookup"><span data-stu-id="58e57-276">Enable continuous dictation</span></span>](enable-continuous-dictation.md) |<span data-ttu-id="58e57-277">長い形式の継続的なディクテーション音声入力をキャプチャし、認識する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="58e57-277">Learn how to capture and recognize long-form, continuous dictation speech input.</span></span> |
| [<span data-ttu-id="58e57-278">音声入力の問題の管理</span><span class="sxs-lookup"><span data-stu-id="58e57-278">Manage issues with audio input</span></span>](manage-issues-with-audio-input.md) | <span data-ttu-id="58e57-279">オーディオ入力の品質が原因で発生する音声認識の精度の問題を管理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="58e57-279">Learn how to manage issues with speech-recognition accuracy caused by audio-input quality.</span></span> |
| [<span data-ttu-id="58e57-280">音声認識のタイムアウトの設定</span><span class="sxs-lookup"><span data-stu-id="58e57-280">Set speech recognition timeouts</span></span>](set-speech-recognition-timeouts.md) | <span data-ttu-id="58e57-281">音声認識エンジンが無音または認識できないサウンド (雑音) を無視し、音声入力を待機する時間の長さを設定します。</span><span class="sxs-lookup"><span data-stu-id="58e57-281">Set how long a speech recognizer ignores silence or unrecognizable sounds (babble) and continues listening for speech input.</span></span> |

## <a name="related-articles"></a><span data-ttu-id="58e57-282">関連記事</span><span class="sxs-lookup"><span data-stu-id="58e57-282">Related articles</span></span>

* [<span data-ttu-id="58e57-283">音声操作</span><span class="sxs-lookup"><span data-stu-id="58e57-283">Speech interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185614)
* [<span data-ttu-id="58e57-284">Cortana の操作</span><span class="sxs-lookup"><span data-stu-id="58e57-284">Cortana interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185598)

 **<span data-ttu-id="58e57-285">サンプル</span><span class="sxs-lookup"><span data-stu-id="58e57-285">Samples</span></span>**

* [<span data-ttu-id="58e57-286">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="58e57-286">Speech recognition and speech synthesis sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 



