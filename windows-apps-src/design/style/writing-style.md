---
author: QuinnRadich
title: 記述スタイル
description: アプリのテキストを設計と融合させるには、適切なボイスとトーンを使用することが重要です。
keywords: UWP, Windows 10, テキスト, 記述, ボイス, トーン, 設計, UI, UX
ms.author: quradic
ms.date: 1/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: d38f22f896e31a925f07c5d6dffd357c211b3336
ms.sourcegitcommit: d780e3a087ab5240ea643346480a1427bea9e29b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/09/2018
ms.locfileid: "1573257"
---
# <a name="writing-style"></a><span data-ttu-id="4cb12-104">記述スタイル</span><span class="sxs-lookup"><span data-stu-id="4cb12-104">Writing style</span></span>

<span data-ttu-id="4cb12-105">エラー メッセージの表現や、ヘルプ ドキュメントの文章、ボタンのテキストは、アプリの使いやすさに大きな影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-105">The way you phrase an error message, the way you write help documentation, and even the text you choose for a button have a big impact on the usability of your app.</span></span> 

<span data-ttu-id="4cb12-106">記述スタイルによっては、ユーザー エクスペリエンスが不快にも</span><span class="sxs-lookup"><span data-stu-id="4cb12-106">Writing style can make a big difference between an awful user experience...</span></span>

![Windows 7 のブルー スクリーン](images/writing/bluescreen_old.png)

<span data-ttu-id="4cb12-108">快適にもなります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-108">...And a better one.</span></span>

![Windows 10 のブルー スクリーン](images/writing/bluescreen_new.png)


## <a name="writing-with-a-natural-voice-and-tone"></a><span data-ttu-id="4cb12-110">自然なボイスとトーンを使った表現</span><span class="sxs-lookup"><span data-stu-id="4cb12-110">Writing with a natural voice and tone</span></span>

<span data-ttu-id="4cb12-111">研究によると、ユーザーの好感度が最も高いのは、親しみやすく、有用で、簡潔な記述スタイルです。</span><span class="sxs-lookup"><span data-stu-id="4cb12-111">Research shows that users respond best to a writing style that's friendly, helpful, and concise.</span></span> 

## <a name="be-friendly"></a><span data-ttu-id="4cb12-112">親しみやすさ</span><span class="sxs-lookup"><span data-stu-id="4cb12-112">Be friendly</span></span>

<span data-ttu-id="4cb12-113">まずユーザーを萎縮させないことが、何よりも大切です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-113">Above all else, you don't want to scare off the user.</span></span> <span data-ttu-id="4cb12-114">堅苦しくない、打ち解けた口調を使います。ユーザーが理解できない用語を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-114">Be informal, be casual, and don't use terms they won't understand.</span></span> <span data-ttu-id="4cb12-115">問題が発生した場合も、ユーザーを非難してはなりません。</span><span class="sxs-lookup"><span data-stu-id="4cb12-115">Even when things break, don't blame the user for any problems.</span></span> <span data-ttu-id="4cb12-116">問題の責任はアプリが引き受け、ユーザーの操作を第一に考えて、親切に手順を説明してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-116">Your app should take responsibility instead, and offer welcoming guidance that puts the user's actions first.</span></span>

![変更前: エラーが発生し、画像をアップロードできませんでした。](images/writing/friendly_example.png)

## <a name="be-helpful"></a><span data-ttu-id="4cb12-121">有用さ</span><span class="sxs-lookup"><span data-stu-id="4cb12-121">Be helpful</span></span>

<span data-ttu-id="4cb12-122">常に、現在の状況説明とユーザーに必要な重要情報の提供に絞って記述します。不要な情報でユーザーに負担をかけないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-122">Always be focused on explaining what's going on and providing the relevant information that the user needs, without overloading them with unnecessary info.</span></span>

![変更前: ネットワークに接続できません。](images/writing/helpful_example.png)

## <a name="be-clear-and-concise"></a><span data-ttu-id="4cb12-127">明瞭さと簡潔さ</span><span class="sxs-lookup"><span data-stu-id="4cb12-127">Be clear and concise</span></span>

<span data-ttu-id="4cb12-128">ほとんどの場合、テキストはアプリの主役ではありません。</span><span class="sxs-lookup"><span data-stu-id="4cb12-128">Most of the time, text isn't the focus of an app.</span></span> <span data-ttu-id="4cb12-129">テキストはユーザーをガイドし、現在の状況と次に行う操作を説明するためにあります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-129">It's there to guide users, to teach them what's going on and what they should do next.</span></span> <span data-ttu-id="4cb12-130">アプリのテキストを作成する際には、この視点を忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-130">Don't lose sight of this when writing the text in your app.</span></span> <span data-ttu-id="4cb12-131">対象読者が慣れ親しんでいる言葉を使用してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-131">Use language that will be familiar to your audience.</span></span> <span data-ttu-id="4cb12-132">通常、これは日常的な話し言葉を選択することを意味しますが、特殊な用途のアプリには独自の基準があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-132">Usually this means choosing everyday and conversational words, but apps for specialized uses will have their own standards.</span></span> <span data-ttu-id="4cb12-133">ユーザーがテキストを理解できないという状況は避ける必要があります。そのため、どのようなトーンを使用するか迷う場合は、わかりやすさを優先してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-133">Your users should never have to wonder what your text means, so favor simplicity if you're ever unsure of which tone to use.</span></span>

![変更前: 不具合が発生し、ファイルを保存できませんでした。](images/writing/concise_example.png)

## <a name="writing-tips"></a><span data-ttu-id="4cb12-138">テキスト作成のヒント</span><span class="sxs-lookup"><span data-stu-id="4cb12-138">Writing tips</span></span>

<span data-ttu-id="4cb12-139">これらの一般原則は、アプリの限られたスペースの中で、数多くの方法によって実現できます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-139">There are many ways you can implement those general principles in the limited space your app has.</span></span> <span data-ttu-id="4cb12-140">以下では、これらの原則を実現するうえで役立つテクニックを示します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-140">Below are some strategies that we find useful to put those princples into action:</span></span>

### <a name="lead-with-whats-important"></a><span data-ttu-id="4cb12-141">大切なことから説明する</span><span class="sxs-lookup"><span data-stu-id="4cb12-141">Lead with what's important</span></span>

<span data-ttu-id="4cb12-142">テキストは、ユーザーが読んで一目で理解できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-142">Users need to be able to read and understand your text at a glance.</span></span> <span data-ttu-id="4cb12-143">不要な前置きを付けて単語を長くしないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-143">Don't pad your words with unnecessary introductions.</span></span> <span data-ttu-id="4cb12-144">重要なポイントが最も目立つようにします。常に、アイデアの中核部分を示した後で、説明を追加します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-144">Give your key points the most visibility, and always present the core of an idea before you add onto it.</span></span>

<span data-ttu-id="4cb12-145">**適切:** [フィルター] を選択して画像に効果を追加します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-145">**Good:** Select "filters" to add effects to your image.</span></span>

<span data-ttu-id="4cb12-146">**不適切:** 視覚効果や変更を画像に追加する場合は、[フィルター] を選択します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-146">**Bad:** If you want to add visual effects or alterations to your image, select "filters."</span></span>

### <a name="emphasize-action"></a><span data-ttu-id="4cb12-147">アクションを強調する</span><span class="sxs-lookup"><span data-stu-id="4cb12-147">Emphasize action</span></span>

<span data-ttu-id="4cb12-148">アプリは、アクションによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-148">Apps are defined by actions.</span></span> <span data-ttu-id="4cb12-149">ユーザーはアプリを使用するときにアクションを実行し、アプリはユーザーに応答するときにアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-149">Users take action as they use the app, and the app takes action as it responds to the users.</span></span> <span data-ttu-id="4cb12-150">アプリ全体のテキストで*能動態*を使用していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-150">Make sure your text uses the *active voice* throughout your app.</span></span> <span data-ttu-id="4cb12-151">ユーザーや機能は、アクションが実行される対象ではなく、アクションを実行するものとして記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-151">Users and functions should be described as doing things, instead of having things done to them.</span></span>

<span data-ttu-id="4cb12-152">**適切:** アプリを再起動して変更内容を表示します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-152">**Good:** Restart the app to see your changes.</span></span>

<span data-ttu-id="4cb12-153">**不適切:** アプリが再起動されたときに、変更内容が適用されます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-153">**Bad:** The changes will be applied when the app is restarted.</span></span>

### <a name="short-and-sweet"></a><span data-ttu-id="4cb12-154">短く、わかりやすく</span><span class="sxs-lookup"><span data-stu-id="4cb12-154">Short and sweet</span></span>

<span data-ttu-id="4cb12-155">ユーザーはテキストをざっと見て、多くの場合、より大きな単語のブロック全体をスキップします。</span><span class="sxs-lookup"><span data-stu-id="4cb12-155">Users scan text, and will often skip over larger blocks of words entirely.</span></span> <span data-ttu-id="4cb12-156">必要な情報やプレゼンテーションを犠牲してはいけませんが、必要以上に語句を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-156">Don't sacrifice necessary information and presentation, but don't use more words than you have to.</span></span> <span data-ttu-id="4cb12-157">これは、短い文や語句を多用することを意味する場合もあれば、</span><span class="sxs-lookup"><span data-stu-id="4cb12-157">Sometimes, this will mean relying on many shorter sentences or fragments.</span></span> <span data-ttu-id="4cb12-158">長い文で単語や構造を慎重に選ぶことを意味する場合もあります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-158">Other times, this will mean being extra choosy about the words and structure of longer sentences.</span></span>

<span data-ttu-id="4cb12-159">**適切:** 申し訳ありませんが、画像をアップロードできませんでした。</span><span class="sxs-lookup"><span data-stu-id="4cb12-159">**Good:** Sorry, we couldn't upload the picture.</span></span> <span data-ttu-id="4cb12-160">もう一度この問題が発生した場合は、アプリを再起動してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-160">If this happens again, try restarting the app.</span></span> <span data-ttu-id="4cb12-161">心配しないでください。再起動すると画像が復元されます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-161">But don't worry — your picture will be waiting when you come back.</span></span>

<span data-ttu-id="4cb12-162">**不適切:** エラーが発生したため、画像をアップロードできませんでした。</span><span class="sxs-lookup"><span data-stu-id="4cb12-162">**Bad:** An error occured, and we weren't able to upload the picture.</span></span> <span data-ttu-id="4cb12-163">もう一度やり直してください。この問題をもう一度が発生した場合は、アプリを再起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-163">Please try again, and if you encounter this problem again, you may need to restart the app.</span></span> <span data-ttu-id="4cb12-164">心配は要りません。作業内容はローカルに保存されており、再起動すると復元されます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-164">But don't worry - we've saved your work locally, and it'll be waiting for you when you come back.</span></span>

## <a name="style-conventions"></a><span data-ttu-id="4cb12-165">スタイルの規則</span><span class="sxs-lookup"><span data-stu-id="4cb12-165">Style conventions</span></span>

<span data-ttu-id="4cb12-166">日頃から書きなれていない限り、これらの原則や推奨事項を実際のテキストに応用すると考えただけで、しり込みしてしまうかもしれません。</span><span class="sxs-lookup"><span data-stu-id="4cb12-166">If you're don't consider yourself to be a writer, it can be intimidating to try to implement these principles and recommendations.</span></span> <span data-ttu-id="4cb12-167">しかし心配は要りません。シンプルで率直な言葉遣いこそが、優れたユーザー エクスペリエンスへの一番の近道です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-167">But don't worry — using simple and straightforward language is a great way to provide a good user experience.</span></span> <span data-ttu-id="4cb12-168">しかしそれでもなお、テキストの作成が不安な方のために、役立つガイドラインを以下にご紹介します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-168">And if you're still unsure how to structure your words, here's some helpful guidelines.</span></span>

### <a name="addressing-the-user"></a><span data-ttu-id="4cb12-169">ユーザーに対して話しかける</span><span class="sxs-lookup"><span data-stu-id="4cb12-169">Addressing the user</span></span>

<span data-ttu-id="4cb12-170">ユーザーに直接話しかけます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-170">Speak directly to the user.</span></span>

* <span data-ttu-id="4cb12-171">ユーザーを常に "あなた" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-171">Always address the user as "you."</span></span>

* <span data-ttu-id="4cb12-172">自分の視点から書く場合は、"私たち" を使います。</span><span class="sxs-lookup"><span data-stu-id="4cb12-172">Use "we" to refer to your own perspective.</span></span> <span data-ttu-id="4cb12-173">暖かい口調で、ユーザーが自分をアプリのエクスペリエンスの一部だと感じられるように話しかけます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-173">It's welcoming and helps the user feel like part of the experience.</span></span>

* <span data-ttu-id="4cb12-174">アプリの開発者が自分だけであっても、アプリの視点を "私" と表現しないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-174">Don't use "I" or "me" to refer to the app's perspective, even if you're the only one creating it.</span></span>

> <span data-ttu-id="4cb12-175">その場所にファイルを保存できませんでした。</span><span class="sxs-lookup"><span data-stu-id="4cb12-175">We couldn't save your file to that location.</span></span>

### <a name="abbreviations"></a><span data-ttu-id="4cb12-176">略語</span><span class="sxs-lookup"><span data-stu-id="4cb12-176">Abbreviations</span></span>

<span data-ttu-id="4cb12-177">略語は、同じ製品、場所、技術的概念をアプリ全体にわたって何度も参照する必要がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-177">Abbreviations can be useful when you need to refer to products, places, or technical concepts multiple times throughout your app.</span></span> <span data-ttu-id="4cb12-178">略語を使用することで、スペースを節約でき、テキストがより自然になります。ただし、それはあくまでユーザーが略語を理解している場合です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-178">They can save space and feel more natural, so long as the user understands them.</span></span>

* <span data-ttu-id="4cb12-179">一般的だと思われる略語でも、ユーザーが当然知っていると考えないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-179">Don't assume that users are already familiar with any abbreviations, even if you think they're common.</span></span>

* <span data-ttu-id="4cb12-180">すべての新しい略語は、必ず初出時にその意味を定義します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-180">Always define what a new abbreviation means the first time the user will see it.</span></span>

* <span data-ttu-id="4cb12-181">混同しやすい複数の略語を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-181">Don't use abbreviations that are too similar to one another.</span></span>

> <span data-ttu-id="4cb12-182">ユニバーサル Windows プラットフォーム (UWP) の設計ガイダンスは、美しく洗練されたアプリの設計と構築に役立つリソースです。</span><span class="sxs-lookup"><span data-stu-id="4cb12-182">The Universal Windows Playform (UWP) design guidance is a resource to help you design and build beautiful, polished apps.</span></span> <span data-ttu-id="4cb12-183">すべての UWP アプリに含まれている設計機能を使うと、デバイスに応じてスケーリングするユーザー インターフェイス (UI) を構築できます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-183">With the design features that are included in every UWP app, you can build user interfaces (UI) that scale across a range of devices.</span></span>

### <a name="contractions"></a><span data-ttu-id="4cb12-184">短縮形</span><span class="sxs-lookup"><span data-stu-id="4cb12-184">Contractions</span></span>

<span data-ttu-id="4cb12-185">短縮形は多くのユーザーが慣れ親しんだ、通常使用されている形式です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-185">People are used to contractions, and expect to see them.</span></span> <span data-ttu-id="4cb12-186">短縮形を使わずに記述すると、アプリが堅苦しく、形式ばった印象になります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-186">Avoiding them can make your app seem too formal or even stilted.</span></span>

* <span data-ttu-id="4cb12-187">テキストに自然に溶け込んでいる場合は、短縮形を使用してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-187">Use contractions when they're a natural fit for the text.</span></span>

* <span data-ttu-id="4cb12-188">スペースの節約や、テキストを堅苦しくするためだけに、不自然な短縮形を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-188">Don't use unnatural contractions just to save space, or when they would make your words sound less conversational.</span></span>

> <span data-ttu-id="4cb12-189">When you're happy with your image, press "save" to add it to your gallery (画像に問題がなければ、[保存] をクリックしてギャラリーに追加します).</span><span class="sxs-lookup"><span data-stu-id="4cb12-189">When you're happy with your image, press "save" to add it to your gallery.</span></span> <span data-ttu-id="4cb12-190">From there, you'll be able to share it with friends (ギャラリーから、友人と画像を共有できます).</span><span class="sxs-lookup"><span data-stu-id="4cb12-190">From there, you'll be able to share it with friends.</span></span>

### <a name="periods"></a><span data-ttu-id="4cb12-191">ピリオド</span><span class="sxs-lookup"><span data-stu-id="4cb12-191">Periods</span></span>

<span data-ttu-id="4cb12-192">テキストの末尾のピリオドは、そのテキストが完全文であることを暗に意味します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-192">Ending text with a period implies that that text is a full sentence.</span></span> <span data-ttu-id="4cb12-193">大きなブロックのテキストにはピリオドを使用し、完全文でないテキストの場合は使用を避けてください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-193">Use a period for larger blocks of text, and avoid them for text that's shorter than a complete sentence.</span></span>

* <span data-ttu-id="4cb12-194">ツールチップ、エラー メッセージ、ダイアログの完全文の末尾には、ピリオドを使用します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-194">Use periods to end full sentences in tooltips, error messages, and dialogs.</span></span>

* <span data-ttu-id="4cb12-195">ボタン、ラジオ ボタン、ラベル、チェック ボックスのテキストの末尾には、ピリオドを使用しません。</span><span class="sxs-lookup"><span data-stu-id="4cb12-195">Don't end text for buttons, radio buttons, labels, or checkboxes with a period.</span></span>

> **<span data-ttu-id="4cb12-196">接続されていません</span><span class="sxs-lookup"><span data-stu-id="4cb12-196">You're not connected</span></span>**
> * <span data-ttu-id="4cb12-197">ネットワーク ケーブルが接続されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-197">Check that your network cables are plugged in.</span></span>
> * <span data-ttu-id="4cb12-198">機内モードでないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-198">Make sure you're not in airplane mode.</span></span>
> * <span data-ttu-id="4cb12-199">ワイヤレス スイッチがオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-199">See if your wireless switch is turned on.</span></span>
> * <span data-ttu-id="4cb12-200">ルーターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-200">Restart your router.</span></span>

### <a name="capitalization"></a><span data-ttu-id="4cb12-201">大文字化</span><span class="sxs-lookup"><span data-stu-id="4cb12-201">Capitalization</span></span>

<span data-ttu-id="4cb12-202">大文字を使用することは重要ですが、使い過ぎに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-202">While capital letters are important, they're easy to overuse.</span></span>

* <span data-ttu-id="4cb12-203">固有名詞の先頭は大文字にします。</span><span class="sxs-lookup"><span data-stu-id="4cb12-203">Capitalize proper nouns.</span></span>

* <span data-ttu-id="4cb12-204">アプリ内のすべてのテキスト文字列の先頭 (すべての文、ラベル、タイトルの先頭) は大文字にします。</span><span class="sxs-lookup"><span data-stu-id="4cb12-204">Capitalize the start of every string of text in your app: the start of every sentence, label, and title.</span></span>

> **<span data-ttu-id="4cb12-205">Which part is giving you trouble? (何でお困りですか)</span><span class="sxs-lookup"><span data-stu-id="4cb12-205">Which part is giving you trouble?</span></span>**
> * <span data-ttu-id="4cb12-206">I forgot my password (パスワードを忘れた)</span><span class="sxs-lookup"><span data-stu-id="4cb12-206">I forgot my password</span></span>
> * <span data-ttu-id="4cb12-207">It won't accept my password (パスワードがエラーになる)</span><span class="sxs-lookup"><span data-stu-id="4cb12-207">It won't accept my password</span></span>
> * <span data-ttu-id="4cb12-208">Someone else might be using my account (他のユーザーが自分のパスワードを使用している可能性がある)</span><span class="sxs-lookup"><span data-stu-id="4cb12-208">Someone else might be using my account</span></span>

## <a name="error-messages"></a><span data-ttu-id="4cb12-209">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="4cb12-209">Error messages</span></span>

<span data-ttu-id="4cb12-210">アプリで問題が発生すると、ユーザーはそれに対して注意を払います。</span><span class="sxs-lookup"><span data-stu-id="4cb12-210">When something goes wrong in your app, users pay attention.</span></span> <span data-ttu-id="4cb12-211">エラー メッセージが発生するとユーザーは混乱したり、苛立ちを感じたりする可能性があるため、エラー メッセージで適切なボイスとトーンを使うことは特に大きな効果があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-211">Because users might be confused or frustrated when they encounter an error message, they're an area where good voice and tone can have a particularly significant impact.</span></span>

<span data-ttu-id="4cb12-212">何よりも重要なのは、エラー メッセージでユーザーを非難しないことです。</span><span class="sxs-lookup"><span data-stu-id="4cb12-212">More than anything else, it's important that your error message doesn't blame the user.</span></span> <span data-ttu-id="4cb12-213">また、理解できない情報で、ユーザーを困惑させないことも重要です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-213">But it's also important not to overwhelm them with information that they don't understand.</span></span> <span data-ttu-id="4cb12-214">ほとんどの場合、エラーに遭遇したユーザーは、できるだけ素早く簡単にエラー発生前の状態に戻ることだけを望んでいます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-214">Most of the time a user who encounters an error just wants to get back to what they were doing as quickly and as easily as they can.</span></span> <span data-ttu-id="4cb12-215">したがって、エラー メッセージは、以下の条件を備える必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-215">Therefore, any error message you write should:</span></span>

* <span data-ttu-id="4cb12-216">**親しみやすさ:** 発生した状況についての責任をアプリが引き受けます。また、なじみのない用語や技術的な専門用語を避けます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-216">**Be friendly** by taking responsibility for what happened, and by avoiding unfamiliar terms and technical jargon.</span></span>

* <span data-ttu-id="4cb12-217">**有用さ:** ユーザーにできる限り原因を明らかにし、その後の流れを説明すると共に、ユーザーが実行できる現実的な解決策を提示します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-217">**Be helpful** by telling the user what went wrong to the best of your ability, by telling them what will happen next, and by providing a realistic solution they can accomplish.</span></span>

* <span data-ttu-id="4cb12-218">**明瞭さと簡潔さ:** 余分な情報を除外します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-218">**Be clear and concise** by eliminating extraneous information.</span></span>

![適切なエラー メッセージの例](images/writing/connection_error.png)

## <a name="buttons"></a><span data-ttu-id="4cb12-220">ボタン</span><span class="sxs-lookup"><span data-stu-id="4cb12-220">Buttons</span></span>

<span data-ttu-id="4cb12-221">ボタンに表示するテキストは、ユーザーが一目で読み取ることができる簡潔さと、ボタンの機能がすぐにわかる明瞭さを備えている必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-221">Text on buttons needs to be concise enough that users can read it all at a glance and clear enough that the button's function is immediately obvious.</span></span> <span data-ttu-id="4cb12-222">ボタンのテキストは、2、3 語の短い単語が上限です。多くはそれよりも短くする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-222">The longest the text on a button should ever be is a couple short words, and many should be shorter than that.</span></span>

<span data-ttu-id="4cb12-223">ボタンのテキストを作成する際は、すべてのボタンがアクションを表すことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-223">When writing the text for buttons, remember that every button represents an action.</span></span> <span data-ttu-id="4cb12-224">ボタンのテキストは、必ず*能動態*を使用して、反応ではなく動作を表す単語を使用します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-224">Be sure to use the *active voice* in button text, to use words that represent actions rather than reactions.</span></span>

![適切なボタンの例](images/writing/install_button.png)

## <a name="dialogs"></a><span data-ttu-id="4cb12-226">ダイアログ</span><span class="sxs-lookup"><span data-stu-id="4cb12-226">Dialogs</span></span>

<span data-ttu-id="4cb12-227">エラー メッセージの作成に関するアドバイスは、その多くが、アプリのダイアログ向けにテキストを作成する際にも当てはまります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-227">Many of the same advice for writing error messages also applies when creating the text for any dialogs in your app.</span></span> <span data-ttu-id="4cb12-228">ユーザーはダイアログが表示されることを想定していますが、それでもアプリの通常の流れを中断することには変わりありません。ダイアログは、ユーザーが表示前の状態に戻ることができるように、有用かつ簡潔である必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-228">While dialogs are expected by the user, they still interrupt the normal flow of the app, and need to be helpful and concise so the user can get back to what they were doing.</span></span>

<span data-ttu-id="4cb12-229">しかし最も重要なのは、ダイアログのタイトルとそのボタンが "呼応" していることです。</span><span class="sxs-lookup"><span data-stu-id="4cb12-229">But most important is the "call and response" between the title of a dialog and its buttons.</span></span> <span data-ttu-id="4cb12-230">タイトルの質問に対して、ボタンが明確な答えとなっていること、またタイトルとボタンの形式がアプリ全体で一貫していることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-230">Make sure that your buttons are clear answers to the question posed by the title, and that their format is consistent across your app.</span></span>

![適切なダイアログの例](images/writing/password_dialog.png)

## <a name="spoken-experiences"></a><span data-ttu-id="4cb12-232">音声エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="4cb12-232">Spoken experiences</span></span>

<span data-ttu-id="4cb12-233">同じ一般原則と推奨事項は、Cortana などの音声エクスペリエンス用のテキストを作成する場合にも当てはまります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-233">The same general principles and recommendations apply when writing text for spoken experiences, such as Cortana.</span></span> <span data-ttu-id="4cb12-234">音声エクスペリエンスでは、他の視覚的デザイン要素をユーザーに提供して音声情報を補足できないため、適切なテキスト作成のための原則に従うことがさらに重要になります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-234">In those features, the principles of good writing are even more important, because you are unable to provide users with other visual design elements to supplement the spoken words.</span></span>

* <span data-ttu-id="4cb12-235">**親しみやすさ:** 会話的なトーンで、ユーザーに親近感を与えます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-235">**Be friendly** by engaging the user with a conversational tone.</span></span> <span data-ttu-id="4cb12-236">音声エクスペリエンスでは、暖かく親しみやすい印象と、ユーザーが抵抗なく話せることが他のどの領域よりも重要です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-236">More than in any other area, it's vital that a spoken experience sound warm and approachable, and be something that users aren't afraid to talk to.</span></span>

* <span data-ttu-id="4cb12-237">**有用さ:** ユーザーから不可能なことを要求されたときは、代替案を提示します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-237">**Be helpful** by providing alternative suggestions when the user asks the impossible.</span></span> <span data-ttu-id="4cb12-238">エラー メッセージと同様、何らかの理由でアプリがユーザーの要求を満たせない場合、ユーザーが代わりに要求できる現実的な代替案をアプリが提示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-238">Much like in an error message, if something went wrong and your app isn't able to fulfill the request, it should give the user a realistic alternative that they can try asking, instead.</span></span>

* <span data-ttu-id="4cb12-239">**明瞭さと簡潔さ:** 常にシンプルな言葉を使用します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-239">**Be clear and concise** by keeping your language simple.</span></span> <span data-ttu-id="4cb12-240">音声エクスペリエンスは、長い文章や複雑な単語には不向きです。</span><span class="sxs-lookup"><span data-stu-id="4cb12-240">Spoken experiences aren't suitable for long sentences or complicated words.</span></span>

## <a name="accessibility-and-localization"></a><span data-ttu-id="4cb12-241">アクセシビリティとローカライズ</span><span class="sxs-lookup"><span data-stu-id="4cb12-241">Accessibility and localization</span></span>

<span data-ttu-id="4cb12-242">アクセシビリティとローカライズを念頭に置いてテキストが作成されているアプリは、幅広いユーザーにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-242">Your app can reach a wider audience if it's written with accessibility and localization in mind.</span></span> <span data-ttu-id="4cb12-243">これはテキストによってのみ達成できる側面です。率直で親しみやすい言葉遣いが成功への第一歩となります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-243">This is something that can't only be accomplished through text, though straightforward and friendly language is a great start.</span></span> <span data-ttu-id="4cb12-244">詳しくは、弊社の[アクセシビリティの概要](https://docs.microsoft.com/windows/uwp/design/accessibility/accessibility-overview)と[ローカライズのガイドライン](https://docs.microsoft.com/windows/uwp/design/globalizing/globalizing-portal)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-244">For more information, see our [accessibility overview](https://docs.microsoft.com/windows/uwp/design/accessibility/accessibility-overview) and [localization guidelines](https://docs.microsoft.com/windows/uwp/design/globalizing/globalizing-portal).</span></span>

* <span data-ttu-id="4cb12-245">**親しみやすさと有用性:** さまざまなエクスペリエンスを考慮に入れてください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-245">**Be friendly and helpful** by taking different experiences into account.</span></span> <span data-ttu-id="4cb12-246">他国のユーザーに理解できない可能性のある語句を避けます。またユーザーに何ができ、何ができないかを想定する言葉を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-246">Avoid phrases that might not make sense to an international audience, and don't use words that make assumptions about what the user can and can't do.</span></span>

* <span data-ttu-id="4cb12-247">**明瞭さと簡潔さ:** 必要でない限り、特殊な専門用語を避けます。</span><span class="sxs-lookup"><span data-stu-id="4cb12-247">**Be clear and concise** by avoiding unusual and specialized words when they aren't necessary.</span></span> <span data-ttu-id="4cb12-248">テキストが率直であるほど、ローカライズが容易になります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-248">The more straightforward your text is, the easier it is to localize.</span></span>


## <a name="techniques-for-non-writers"></a><span data-ttu-id="4cb12-249">テキスト作成に慣れていない方のためのテクニック</span><span class="sxs-lookup"><span data-stu-id="4cb12-249">Techniques for non-writers</span></span>

<span data-ttu-id="4cb12-250">快適なエクスペリエンスをユーザーに提供するために、トレーニングを受け、経験を積んだ書き手である必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4cb12-250">You don't need to be a trained or experienced writer to provide your users with a good experience.</span></span> <span data-ttu-id="4cb12-251">自分にとって心地よい言葉を選びます。それはユーザーにも心地よい言葉です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-251">Pick words that sound comfortable to you — they'll feel comfortable to the user, too.</span></span> <span data-ttu-id="4cb12-252">しかしそれは、考えていたほど簡単でないことがあります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-252">But sometimes, that's not as easy as it sounds.</span></span> <span data-ttu-id="4cb12-253">行き詰まった場合は、以下のテクニックを試してみてください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-253">If you get stuck, these techniques can help you out.</span></span> 

* <span data-ttu-id="4cb12-254">アプリを友人に説明しているところを想像します。</span><span class="sxs-lookup"><span data-stu-id="4cb12-254">Imagine that you're talking to a friend about your app.</span></span> <span data-ttu-id="4cb12-255">このアプリをその人たちにどのように説明しますか。</span><span class="sxs-lookup"><span data-stu-id="4cb12-255">How would you explain the app to them?</span></span> <span data-ttu-id="4cb12-256">アプリの機能についてどのように話し、操作手順をどのように伝えますか。</span><span class="sxs-lookup"><span data-stu-id="4cb12-256">How would you talk about its features or give them instructions?</span></span> <span data-ttu-id="4cb12-257">さらに良いのは、まだ使用したことのない人にアプリを説明してみることです。</span><span class="sxs-lookup"><span data-stu-id="4cb12-257">Better yet, explain the app to an actual person who hasn't used it yet.</span></span> 

* <span data-ttu-id="4cb12-258">まったく異なるアプリを説明するとしたら、どのように説明するかを想像してください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-258">Imagine how you would describe a completely different app.</span></span> <span data-ttu-id="4cb12-259">たとえば、ゲームを作っている場合は、財務アプリやニュース アプリを説明するのにどのように話したり、書いたりするかを考えてみてください。</span><span class="sxs-lookup"><span data-stu-id="4cb12-259">For instance, if you're making a game, think of what you'd say or write to describe a financial or a news app.</span></span> <span data-ttu-id="4cb12-260">言葉遣いや構造の違いを意識すると、実際のアプリの説明に使う適切な単語がより明らかになります。</span><span class="sxs-lookup"><span data-stu-id="4cb12-260">The contrast in the language and stucture you use can give you more insight into the right words for what you're actually writing about.</span></span>

* <span data-ttu-id="4cb12-261">同種のアプリを見て、ヒントを得るのも良い方法です。</span><span class="sxs-lookup"><span data-stu-id="4cb12-261">Take a look at similar apps for inspiration.</span></span> 

<span data-ttu-id="4cb12-262">適切な言葉を見つけることは多くの人にとって簡単ではありません。自然に感じられる表現が見つからなくても、決して気に病むことはありません。</span><span class="sxs-lookup"><span data-stu-id="4cb12-262">Finding the right words is a problem that many people struggle with, so don't feel bad if it's not easy to settle on something that feels natural.</span></span>