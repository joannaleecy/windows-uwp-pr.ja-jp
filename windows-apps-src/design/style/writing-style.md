---
author: QuinnRadich
title: 記述スタイル
description: アプリのテキストを設計と融合させるには、適切なボイスとトーンを使用することが重要です。
keywords: UWP, Windows 10, テキスト, 記述, ボイス, トーン, 設計, UI, UX
ms.author: quradic
ms.date: 5/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1a2feb7f21f9a307632b08714ff617a4ce3aa649
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1843292"
---
# <a name="writing-style"></a><span data-ttu-id="3f64d-104">記述スタイル</span><span class="sxs-lookup"><span data-stu-id="3f64d-104">Writing style</span></span>

![ヘッダー画像](images/header-writing-style.gif)

<span data-ttu-id="3f64d-106">エラー メッセージの表現や、ヘルプ ドキュメントの文章、ボタンのテキストは、アプリの使いやすさに大きな影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-106">The way you phrase an error message, the way you write help documentation, and even the text you choose for a button have big impacts on the usability of your app.</span></span> <span data-ttu-id="3f64d-107">記述スタイルによって、ユーザー エクスペリエンスが不快にも快適にもなる大きな違いが生まれます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-107">Writing style can make a big difference between an awful user experience and a better one.</span></span>

## <a name="voice-and-tone-principles"></a><span data-ttu-id="3f64d-108">ボイスとトーンの原則</span><span class="sxs-lookup"><span data-stu-id="3f64d-108">Voice and tone principles</span></span>

<span data-ttu-id="3f64d-109">研究によると、ユーザーの好感度が最も高いのは、親しみやすく、有用で、簡潔な記述スタイルです。</span><span class="sxs-lookup"><span data-stu-id="3f64d-109">Research shows that people respond best to a writing style that's friendly, helpful, and concise.</span></span> <span data-ttu-id="3f64d-110">この調査の一貫として、Microsoft は、すべてのコンテンツ全体に適用するボイスとトーンに関する 3 つの原則を作成しました。これは Fluent Design の重要な一部です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-110">As a part of this research, Microsoft developed three voice and tone principles that we apply across all our content, and are an integral part of Fluent design.</span></span>

### <a name="be-warm-and-relaxed"></a><span data-ttu-id="3f64d-111">友好的で気取らない</span><span class="sxs-lookup"><span data-stu-id="3f64d-111">Be warm and relaxed</span></span>

<span data-ttu-id="3f64d-112">まずユーザーを萎縮させないことが、何よりも大切です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-112">Above all else, you don't want to scare off the user.</span></span> <span data-ttu-id="3f64d-113">堅苦しくない、打ち解けた口調を使います。ユーザーが理解できない用語を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-113">Be informal, be casual, and don't use terms they won't understand.</span></span> <span data-ttu-id="3f64d-114">問題が発生した場合も、ユーザーを非難してはなりません。</span><span class="sxs-lookup"><span data-stu-id="3f64d-114">Even when things break, don't blame the user for any problems.</span></span> <span data-ttu-id="3f64d-115">問題の責任はアプリが引き受け、ユーザーの操作を第一に考えて、親切に手順を説明してください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-115">Your app should take responsibility instead, and offer welcoming guidance that puts the user's actions first.</span></span>

### <a name="be-ready-to-lend-a-hand"></a><span data-ttu-id="3f64d-116">手助けになる</span><span class="sxs-lookup"><span data-stu-id="3f64d-116">Be ready to lend a hand</span></span>

<span data-ttu-id="3f64d-117">常に、文章で共感を示します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-117">Always show empathy in your writing.</span></span> <span data-ttu-id="3f64d-118">現在の状況説明とユーザーに必要な情報の提供に絞って記述します。不要な情報でユーザーに負担をかけないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-118">Be focused on explaining what's going on and providing the information that the user needs, without overloading them with unnecessary info.</span></span> <span data-ttu-id="3f64d-119">また、可能であれば、問題がある場合には常にソリューションを提供します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-119">And if possible, always provide a solution when there's a problem.</span></span>

### <a name="be-crisp-and-clear"></a><span data-ttu-id="3f64d-120">簡潔かつ明瞭である</span><span class="sxs-lookup"><span data-stu-id="3f64d-120">Be crisp and clear</span></span>

<span data-ttu-id="3f64d-121">ほとんどの場合、テキストはアプリの主役ではありません。</span><span class="sxs-lookup"><span data-stu-id="3f64d-121">Most of the time, text isn't the focus of an app.</span></span> <span data-ttu-id="3f64d-122">テキストはユーザーをガイドし、現在の状況と次に行う操作を説明するためにあります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-122">It's there to guide people, to teach them what's going on and what they should do next.</span></span> <span data-ttu-id="3f64d-123">アプリのテキストを作成する際には、この視点を忘れないでください。また、ユーザーがすべての言葉を読むと想定しないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-123">Don't lose sight of this when writing the text in your app, and don't assume that users will read every word.</span></span> <span data-ttu-id="3f64d-124">対象ユーザーにとって馴染みのある言葉を使用し、一目で理解しやすいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-124">Use language that is familiar to your audience, make sure it's easy to understand at a glance.</span></span>

## <a name="lead-with-whats-important"></a><span data-ttu-id="3f64d-125">大切なことから説明する</span><span class="sxs-lookup"><span data-stu-id="3f64d-125">Lead with what's important</span></span>

<span data-ttu-id="3f64d-126">テキストは、ユーザーが読んで一目で理解できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-126">Users need to be able to read and understand your text at a glance.</span></span> <span data-ttu-id="3f64d-127">不要な前置きを付けて単語を長くしないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-127">Don't pad your words with unnecessary introductions.</span></span> <span data-ttu-id="3f64d-128">重要なポイントが最も目立つようにします。常に、アイデアの中核部分を示した後で、説明を追加します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-128">Give your key points the most visibility, and always present the core of an idea before you add onto it.</span></span>

<span data-ttu-id="3f64d-129">:::row::: :::column::: ![Do](images/do.svg) **[フィルター]** を選択して画像に効果を追加します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-129">:::row::: :::column::: ![Do](images/do.svg) Select **filters** to add effects to your image.</span></span>
<span data-ttu-id="3f64d-130">:::column-end::: :::column::: ![不適切](images/dont.svg) 視覚効果や変更を画像に追加する場合は、**[フィルター]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-130">:::column-end::: :::column::: ![Don't](images/dont.svg) If you want to add visual effects or alterations to your image, select **filters.**</span></span>
<span data-ttu-id="3f64d-131">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-131">:::column-end::: :::row-end:::</span></span>

## <a name="emphasize-action"></a><span data-ttu-id="3f64d-132">アクションを強調する</span><span class="sxs-lookup"><span data-stu-id="3f64d-132">Emphasize action</span></span>

<span data-ttu-id="3f64d-133">アプリは、アクションによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-133">Apps are defined by actions.</span></span> <span data-ttu-id="3f64d-134">ユーザーはアプリを使用するときにアクションを実行し、アプリはユーザーに応答するときにアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-134">Users take action when they use the app, and the app takes action when it responds to the user.</span></span> <span data-ttu-id="3f64d-135">アプリ全体のテキストで*能動態*を使用していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-135">Make sure your text uses the *active voice* throughout your app.</span></span> <span data-ttu-id="3f64d-136">ユーザーや機能は、アクションが実行される対象ではなく、アクションを実行するものとして記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-136">People and functions should be described as doing things, instead of having things done to them.</span></span>

<span data-ttu-id="3f64d-137">:::row::: :::column::: ![適切](images/do.svg) アプリを再起動して変更内容を表示します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-137">:::row::: :::column::: ![Do](images/do.svg) Restart the app to see your changes.</span></span>
<span data-ttu-id="3f64d-138">:::column-end::: :::column::: ![不適切](images/dont.svg) アプリが再起動されたときに、変更内容が適用されます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-138">:::column-end::: :::column::: ![Don't](images/dont.svg) The changes will be applied when the app is restarted.</span></span>
<span data-ttu-id="3f64d-139">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-139">:::column-end::: :::row-end:::</span></span>

## <a name="short-and-sweet"></a><span data-ttu-id="3f64d-140">短く、わかりやすく</span><span class="sxs-lookup"><span data-stu-id="3f64d-140">Short and sweet</span></span>

<span data-ttu-id="3f64d-141">ユーザーはテキストをざっと見て、多くの場合、より大きな単語のブロック全体をスキップします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-141">Users scan text, and will often skip over larger blocks of words entirely.</span></span> <span data-ttu-id="3f64d-142">必要な情報やプレゼンテーションを犠牲してはいけませんが、必要以上に語句を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-142">Don't sacrifice necessary information and presentation, but don't use more words than you have to.</span></span> <span data-ttu-id="3f64d-143">これは、短い文や語句を多用することを意味する場合もあれば、</span><span class="sxs-lookup"><span data-stu-id="3f64d-143">Sometimes, this will mean relying on many shorter sentences or fragments.</span></span> <span data-ttu-id="3f64d-144">長い文で単語や構造を慎重に選ぶことを意味する場合もあります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-144">Other times, this will mean being extra choosy about the words and structure of longer sentences.</span></span>

<span data-ttu-id="3f64d-145">:::row::: :::column::: ![適切](images/do.svg) 画像をアップロードできませんでした。</span><span class="sxs-lookup"><span data-stu-id="3f64d-145">:::row::: :::column::: ![Do](images/do.svg) We couldn't upload the picture.</span></span> <span data-ttu-id="3f64d-146">もう一度この問題が発生した場合は、アプリを再起動してください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-146">If this happens again, try restarting the app.</span></span> <span data-ttu-id="3f64d-147">心配しないでください。再起動すると画像が復元されます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-147">But don't worry — your picture will be waiting when you come back.</span></span>
<span data-ttu-id="3f64d-148">:::column-end::: :::column::: ![不適切](images/dont.svg) エラーが発生したため、画像をアップロードできませんでした。</span><span class="sxs-lookup"><span data-stu-id="3f64d-148">:::column-end::: :::column::: ![Don't](images/dont.svg) An error occured, and we weren't able to upload the picture.</span></span> <span data-ttu-id="3f64d-149">もう一度やり直してください。この問題がもう一度発生した場合は、アプリを再起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-149">Please try again, and if you encounter this problem again, you may need to restart the app.</span></span> <span data-ttu-id="3f64d-150">心配は要りません。作業内容はローカルに保存されており、再起動すると復元されます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-150">But don't worry — we've saved your work locally, and it'll be waiting for you when you come back.</span></span>
<span data-ttu-id="3f64d-151">:::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-151">:::column-end::: :::row-end:::</span></span>

## <a name="style-conventions"></a><span data-ttu-id="3f64d-152">スタイルの規則</span><span class="sxs-lookup"><span data-stu-id="3f64d-152">Style conventions</span></span>

<span data-ttu-id="3f64d-153">日頃から書き慣れていない限り、これらの原則や推奨事項を実際のテキストに応用すると考えただけで、しり込みしてしまうかもしれません。</span><span class="sxs-lookup"><span data-stu-id="3f64d-153">If you don't consider yourself to be a writer, it can be intimidating to try to implement these principles and recommendations.</span></span> <span data-ttu-id="3f64d-154">しかし心配は要りません。シンプルで率直な言葉遣いこそが、優れたユーザー エクスペリエンスへの一番の近道です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-154">But don't worry — using simple and straightforward language is a great way to provide a good user experience.</span></span> <span data-ttu-id="3f64d-155">しかしそれでもなお、テキストの作成が不安な方のために、役立つガイドラインを以下にご紹介します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-155">And if you're still unsure how to structure your words, here are some helpful guidelines.</span></span> <span data-ttu-id="3f64d-156">また、詳細情報が必要な場合は、「[Microsoft スタイル ガイド](https://docs.microsoft.com/style-guide/welcome/)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-156">And if you want more information, check out the [Microsoft Style Guide](https://docs.microsoft.com/style-guide/welcome/).</span></span>

### <a name="addressing-the-user"></a><span data-ttu-id="3f64d-157">ユーザーに対して話しかける</span><span class="sxs-lookup"><span data-stu-id="3f64d-157">Addressing the user</span></span>

<span data-ttu-id="3f64d-158">ユーザーに直接話しかけます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-158">Speak directly to the user.</span></span>
* <span data-ttu-id="3f64d-159">ユーザーを常に "あなた" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-159">Always address the user as "you."</span></span>
* <span data-ttu-id="3f64d-160">自分の視点から書く場合は、"私たち" を使います。</span><span class="sxs-lookup"><span data-stu-id="3f64d-160">Use "we" to refer to your own perspective.</span></span> <span data-ttu-id="3f64d-161">暖かい口調で、ユーザーが自分をアプリのエクスペリエンスの一部だと感じられるように話しかけます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-161">It's welcoming and helps the user feel like part of the experience.</span></span>
* <span data-ttu-id="3f64d-162">アプリの開発者が自分だけであっても、アプリの視点を "私" と表現しないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-162">Don't use "I" or "me" to refer to the app's perspective, even if you're the only one creating it.</span></span>

<span data-ttu-id="3f64d-163">:::row::: :::column::: ![適切](images/do.svg) その場所にファイルを保存できませんでした。</span><span class="sxs-lookup"><span data-stu-id="3f64d-163">:::row::: :::column::: ![Do](images/do.svg) We couldn't save your file to that location.</span></span>
<span data-ttu-id="3f64d-164">:::column-end::: :::column::: :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-164">:::column-end::: :::column::: :::column-end::: :::row-end:::</span></span>

### <a name="abbreviations"></a><span data-ttu-id="3f64d-165">略語</span><span class="sxs-lookup"><span data-stu-id="3f64d-165">Abbreviations</span></span>

 <span data-ttu-id="3f64d-166">略語は、同じ製品、場所、技術的概念をアプリ全体にわたって何度も参照する必要がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-166">Abbreviations can be useful when you need to refer to products, places, or technical concepts multiple times throughout your app.</span></span> <span data-ttu-id="3f64d-167">略語を使用することで、スペースを節約でき、テキストがより自然になります。ただし、それはあくまでユーザーが略語を理解している場合です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-167">They can save space and feel more natural, as long as the user understands them.</span></span>
* <span data-ttu-id="3f64d-168">一般的だと思われる略語でも、ユーザーが当然知っていると考えないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-168">Don't assume that users are already familiar with any abbreviations, even if you think they're common.</span></span>
* <span data-ttu-id="3f64d-169">すべての新しい略語は、必ず初出時にその意味を定義します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-169">Always define what a new abbreviation means the first time the user will see it.</span></span>
* <span data-ttu-id="3f64d-170">混同しやすい複数の略語を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-170">Don't use abbreviations that are too similar to one another.</span></span>
* <span data-ttu-id="3f64d-171">アプリをローカライズしている場合、または、ユーザーが第二言語として英語を話す場合は、略語を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-171">Don't use abbreviations if you're localizing your app, or if your users speak English as a second language.</span></span>

<span data-ttu-id="3f64d-172">:::row::: :::column::: ![適切](images/do.svg) ユニバーサル Windows プラットフォーム (UWP) の設計ガイダンスは、美しく洗練されたアプリを設計および構築するのに役立つリソースです。</span><span class="sxs-lookup"><span data-stu-id="3f64d-172">:::row::: :::column::: ![Do](images/do.svg) The Universal Windows Platform (UWP) design guidance is a resource to help you design and build beautiful, polished apps.</span></span> <span data-ttu-id="3f64d-173">すべての UWP アプリに含まれている設計機能を使うと、デバイスに応じてスケーリングするユーザー インターフェイス (UI) を構築できます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-173">With the design features that are included in every UWP app, you can build user interfaces (UI) that scale across a range of devices.</span></span>
<span data-ttu-id="3f64d-174">:::column-end::: :::column::: :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-174">:::column-end::: :::column::: :::column-end::: :::row-end:::</span></span>

### <a name="contractions"></a><span data-ttu-id="3f64d-175">短縮形</span><span class="sxs-lookup"><span data-stu-id="3f64d-175">Contractions</span></span>

<span data-ttu-id="3f64d-176">短縮形は多くのユーザーが慣れ親しんだ、通常使用されている形式です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-176">People are used to contractions, and expect to see them.</span></span> <span data-ttu-id="3f64d-177">短縮形を使わずに記述すると、アプリが堅苦しく、形式ばった印象になります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-177">Avoiding them can make your app seem too formal or even stilted.</span></span>
* <span data-ttu-id="3f64d-178">テキストに自然に溶け込んでいる場合は、短縮形を使用してください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-178">Use contractions when they're a natural fit for the text.</span></span>
* <span data-ttu-id="3f64d-179">スペースの節約や、テキストを堅苦しくするためだけに、不自然な短縮形を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-179">Don't use unnatural contractions just to save space, or when they would make your words sound less conversational.</span></span>

<span data-ttu-id="3f64d-180">:::row::: :::column::: ![適切](images/do.svg) 画像に問題がなければ、**[保存]** をクリックしてギャラリーに追加します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-180">:::row::: :::column::: ![Do](images/do.svg) When you're happy with your image, select **save** to add it to your gallery.</span></span> <span data-ttu-id="3f64d-181">ギャラリーから、友人と画像を共有できます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-181">From there, you'll be able to share it with friends.</span></span>
<span data-ttu-id="3f64d-182">:::column-end::: :::column::: :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-182">:::column-end::: :::column::: :::column-end::: :::row-end:::</span></span>

### <a name="periods"></a><span data-ttu-id="3f64d-183">ピリオド</span><span class="sxs-lookup"><span data-stu-id="3f64d-183">Periods</span></span>

 <span data-ttu-id="3f64d-184">テキストの末尾のピリオドは、そのテキストが完全文であることを暗に意味します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-184">Ending text with a period implies that that text is a full sentence.</span></span> <span data-ttu-id="3f64d-185">大きなブロックのテキストにはピリオドを使用し、完全文でないテキストの場合は使用を避けてください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-185">Use a period for larger blocks of text, and avoid them for text that's shorter than a complete sentence.</span></span>
* <span data-ttu-id="3f64d-186">ツールチップ、エラー メッセージ、ダイアログの完全文の末尾には、ピリオドを使用します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-186">Use periods to end full sentences in tooltips, error messages, and dialogs.</span></span>
* <span data-ttu-id="3f64d-187">ボタン、ラジオ ボタン、ラベル、チェック ボックスのテキストの末尾には、ピリオドを使用しません。</span><span class="sxs-lookup"><span data-stu-id="3f64d-187">Don't end text for buttons, radio buttons, labels, or checkboxes with a period.</span></span>

<span data-ttu-id="3f64d-188">:::row::: :::column::: ![適切](images/do.svg) <b>接続していません.</b></span><span class="sxs-lookup"><span data-stu-id="3f64d-188">:::row::: :::column::: ![Do](images/do.svg) <b>You’re not connected.</b></span></span>
<span data-ttu-id="3f64d-189">\* ネットワーク ケーブルが接続されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-189">\* Check that your network cables are plugged in.</span></span>
<span data-ttu-id="3f64d-190">\* 機内モードでないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-190">\* Make sure you're not in airplane mode.</span></span>
<span data-ttu-id="3f64d-191">\* ワイヤレス スイッチがオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-191">\* See if your wireless switch is turned on.</span></span>
<span data-ttu-id="3f64d-192">\* ルーターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-192">\* Restart your router.</span></span>
<span data-ttu-id="3f64d-193">:::column-end::: :::column::: :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-193">:::column-end::: :::column::: :::column-end::: :::row-end:::</span></span>

### <a name="capitalization"></a><span data-ttu-id="3f64d-194">大文字化</span><span class="sxs-lookup"><span data-stu-id="3f64d-194">Capitalization</span></span>

<span data-ttu-id="3f64d-195">大文字を使用することは重要ですが、使い過ぎに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-195">While capital letters are important, they're easy to overuse.</span></span>
* <span data-ttu-id="3f64d-196">固有名詞の先頭は大文字にします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-196">Capitalize proper nouns.</span></span>
* <span data-ttu-id="3f64d-197">アプリ内のすべてのテキスト文字列の先頭 (すべての文、ラベル、タイトルの先頭) は大文字にします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-197">Capitalize the start of every string of text in your app: the start of every sentence, label, and title.</span></span>

<span data-ttu-id="3f64d-198">:::row::: :::column::: ![適切](images/do.svg) <b>Which part is giving you trouble? (何でお困りですか)</b></span><span class="sxs-lookup"><span data-stu-id="3f64d-198">:::row::: :::column::: ![Do](images/do.svg) <b>Which part is giving you trouble?</b></span></span>
<span data-ttu-id="3f64d-199">\* I forgot your password. (パスワードを忘れた)</span><span class="sxs-lookup"><span data-stu-id="3f64d-199">\* I forgot your password.</span></span>
<span data-ttu-id="3f64d-200">\* It won't accept password. (パスワードがエラーになる)</span><span class="sxs-lookup"><span data-stu-id="3f64d-200">\* It won't accept password.</span></span>
<span data-ttu-id="3f64d-201">Someone else might be using my account. (他のユーザーが自分のパスワードを使用している可能性がある)</span><span class="sxs-lookup"><span data-stu-id="3f64d-201">\* Someone else might be using my account.</span></span>
<span data-ttu-id="3f64d-202">:::column-end::: :::column::: :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-202">:::column-end::: :::column::: :::column-end::: :::row-end:::</span></span>

## <a name="error-messages"></a><span data-ttu-id="3f64d-203">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="3f64d-203">Error messages</span></span>

<span data-ttu-id="3f64d-204">アプリで問題が発生すると、ユーザーはそれに対して注意を払います。</span><span class="sxs-lookup"><span data-stu-id="3f64d-204">When something goes wrong in your app, users pay attention.</span></span> <span data-ttu-id="3f64d-205">エラー メッセージが発生するとユーザーは混乱したり、苛立ちを感じたりする可能性があるため、エラー メッセージで適切なボイスとトーンを使うことは特に大きな効果があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-205">Because users might be confused or frustrated when they encounter an error message, they're an area where good voice and tone can have a particularly significant impact.</span></span>

<span data-ttu-id="3f64d-206">何よりも重要なのは、エラー メッセージでユーザーを非難しないことです。</span><span class="sxs-lookup"><span data-stu-id="3f64d-206">More than anything else, it's important that your error message doesn't blame the user.</span></span> <span data-ttu-id="3f64d-207">また、理解できない情報で、ユーザーを困惑させないことも重要です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-207">But it's also important not to overwhelm them with information that they don't understand.</span></span> <span data-ttu-id="3f64d-208">ほとんどの場合、エラーに遭遇したユーザーは、できるだけ素早く簡単にエラー発生前の状態に戻ることだけを望んでいます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-208">Most of the time a user who encounters an error just wants to get back to what they were doing as quickly and as easily as they can.</span></span> <span data-ttu-id="3f64d-209">したがって、エラー メッセージは、以下の条件を備える必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-209">Therefore, any error message you write should:</span></span>

* <span data-ttu-id="3f64d-210">会話的なトーンを使用し、なじみのない用語や技術的な専門用語を避けることで、**友好的で気取らない**ようにします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-210">**Be warm and relaxed** by using a conversational tone and avoiding unfamiliar terms and technical jargon.</span></span>

* <span data-ttu-id="3f64d-211">ユーザーにできる限り原因を明らかにし、その後の流れを説明すると共に、ユーザーが実行できる現実的な解決策を提示することで、**手助けになる**ようにします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-211">**Be ready to lend a hand** by telling the user what went wrong to the best of your ability, by telling them what will happen next, and by providing a realistic solution they can accomplish.</span></span>

* <span data-ttu-id="3f64d-212">余分な情報を除外することで**簡潔かつ明瞭である**ようにします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-212">**Be crisp and clear** by eliminating extraneous information.</span></span>

<span data-ttu-id="3f64d-213">:::row::: :::column::: ![適切](images/do.svg) <b>接続していません。</b></span><span class="sxs-lookup"><span data-stu-id="3f64d-213">:::row::: :::column::: ![Do](images/do.svg) <b>You’re not connected.</b></span></span>
<span data-ttu-id="3f64d-214">\* ネットワーク ケーブルが接続されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-214">\* Check that your network cables are plugged in.</span></span>
<span data-ttu-id="3f64d-215">\* 機内モードでないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-215">\* Make sure you're not in airplane mode.</span></span>
<span data-ttu-id="3f64d-216">\* ワイヤレス スイッチがオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-216">\* See if your wireless switch is turned on.</span></span>
<span data-ttu-id="3f64d-217">\* ルーターを再起動します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-217">\* Restart your router.</span></span>
<span data-ttu-id="3f64d-218">:::column-end::: :::column::: :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-218">:::column-end::: :::column::: :::column-end::: :::row-end:::</span></span> 

## <a name="dialogs"></a><span data-ttu-id="3f64d-219">ダイアログ</span><span class="sxs-lookup"><span data-stu-id="3f64d-219">Dialogs</span></span>

<span data-ttu-id="3f64d-220">:::row::: :::column::: エラー メッセージの作成に関するアドバイスは、その多くが、アプリのダイアログ向けにテキストを作成する際にも当てはまります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-220">:::row::: :::column::: Many of the same advice for writing error messages also applies when creating the text for any dialogs in your app.</span></span> <span data-ttu-id="3f64d-221">ユーザーはダイアログが表示されることを想定していますが、それでもアプリの通常の流れを中断することには変わりありません。ダイアログは、ユーザーが表示前の状態に戻ることができるように、有用かつ簡潔である必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-221">While dialogs are expected by the user, they still interrupt the normal flow of the app, and need to be helpful and concise so the user can get back to what they were doing.</span></span>

        But most important is the "call and response" between the title of a dialog and its buttons. Make sure that your buttons are clear answers to the question posed by the title, and that their format is consistent across your app.
    :::column-end:::
    :::column:::
        ![Do](images/do.svg)
        <b>Which part is giving you trouble?</b>
        1. I forgot my password
        2. It won't accept my password
        3. Someone else might be using my account
    :::column-end:::
<span data-ttu-id="3f64d-222">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-222">:::row-end:::</span></span>

## <a name="buttons"></a><span data-ttu-id="3f64d-223">ボタン</span><span class="sxs-lookup"><span data-stu-id="3f64d-223">Buttons</span></span>

<span data-ttu-id="3f64d-224">:::row::: :::column::: ボタンに表示するテキストは、ユーザーが一目で読み取ることができる簡潔さと、ボタンの機能がすぐにわかる明瞭さを備えている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-224">:::row::: :::column::: Text on buttons needs to be concise enough that users can read it all at a glance and clear enough that the button's function is immediately obvious.</span></span> <span data-ttu-id="3f64d-225">ボタンのテキストは、2、3 語の短い単語が上限です。多くはそれよりも短くする必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-225">The longest the text on a button should ever be is a couple short words, and many should be shorter than that.</span></span>
<span data-ttu-id="3f64d-226">ボタンのテキストを作成する際は、すべてのボタンがアクションを表すことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-226">When writing the text for buttons, remember that every button represents an action.</span></span> <span data-ttu-id="3f64d-227">ボタンのテキストは、必ず*能動態*を使用して、反応ではなく動作を表す単語を使用します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-227">Be sure to use the *active voice* in button text, to use words that represent actions rather than reactions.</span></span>
<span data-ttu-id="3f64d-228">:::column-end::: :::column::: ![適切](images/do.svg) * 今すぐインストール * 共有 :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="3f64d-228">:::column-end::: :::column::: ![Do](images/do.svg) * Install now * Share :::column-end::: :::row-end:::</span></span>

## <a name="spoken-experiences"></a><span data-ttu-id="3f64d-229">音声エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="3f64d-229">Spoken experiences</span></span>

<span data-ttu-id="3f64d-230">同じ一般原則と推奨事項は、Cortana などの音声エクスペリエンス用のテキストを作成する場合にも当てはまります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-230">The same general principles and recommendations apply when writing text for spoken experiences, such as Cortana.</span></span> <span data-ttu-id="3f64d-231">音声エクスペリエンスでは、他の視覚的デザイン要素をユーザーに提供して音声情報を補足できないため、適切なテキスト作成のための原則に従うことがさらに重要になります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-231">In those features, the principles of good writing are even more important, because you are unable to provide users with other visual design elements to supplement the spoken words.</span></span>

* <span data-ttu-id="3f64d-232">会話的なトーンで、ユーザーに親近感を与えることで**友好的で気取らない**ようにします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-232">**Be warm and relaxed** by engaging your users with a conversational tone.</span></span> <span data-ttu-id="3f64d-233">音声エクスペリエンスでは、暖かく親しみやすい印象と、ユーザーが抵抗なく話せることが他のどの領域よりも重要です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-233">More than in any other area, it's vital that a spoken experience sound warm and approachable, and be something that users aren't afraid to talk to.</span></span>

* <span data-ttu-id="3f64d-234">ユーザーから不可能なことを要求されたときは、代替案を提示して、**手助けになる**ようにします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-234">**Be ready to lend a hand** by providing alternative suggestions when the user asks the impossible.</span></span> <span data-ttu-id="3f64d-235">エラー メッセージと同様、何らかの理由でアプリがユーザーの要求を満たせない場合、ユーザーが代わりに要求できる現実的な代替案をアプリが提示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-235">Much like in an error message, if something went wrong and your app isn't able to fulfill the request, it should give the user a realistic alternative that they can try asking, instead.</span></span>

* <span data-ttu-id="3f64d-236">常にシンプルな言葉を使用して**簡潔かつ明瞭である**ようにします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-236">**Be crisp and clear** by keeping your language simple.</span></span> <span data-ttu-id="3f64d-237">音声エクスペリエンスは、長い文章や複雑な単語には不向きです。</span><span class="sxs-lookup"><span data-stu-id="3f64d-237">Spoken experiences aren't suitable for long sentences or complicated words.</span></span>

## <a name="accessibility-and-localization"></a><span data-ttu-id="3f64d-238">アクセシビリティとローカライズ</span><span class="sxs-lookup"><span data-stu-id="3f64d-238">Accessibility and localization</span></span>

<span data-ttu-id="3f64d-239">アクセシビリティとローカライズを念頭に置いてテキストが作成されているアプリは、幅広いユーザーにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="3f64d-239">Your app can reach a wider audience if it's written with accessibility and localization in mind.</span></span> <span data-ttu-id="3f64d-240">これはテキストによってのみ達成できる側面です。率直で親しみやすい言葉遣いが成功への第一歩となります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-240">This is something that can't only be accomplished through text, though straightforward and friendly language is a great start.</span></span> <span data-ttu-id="3f64d-241">詳細については、弊社の[アクセシビリティの概要](https://docs.microsoft.com/windows/uwp/design/accessibility/accessibility-overview)と[ローカライズのガイドライン](https://docs.microsoft.com/windows/uwp/design/globalizing/globalizing-portal)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-241">For more information, see our [accessibility overview](https://docs.microsoft.com/windows/uwp/design/accessibility/accessibility-overview) and [localization guidelines](https://docs.microsoft.com/windows/uwp/design/globalizing/globalizing-portal).</span></span>

* <span data-ttu-id="3f64d-242">さまざまなエクスペリエンスを考慮に入れて、**手助けになる**ようにします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-242">**Be ready to lend a hand** by taking different experiences into account.</span></span> <span data-ttu-id="3f64d-243">他国のユーザーに理解できない可能性のある語句を避けます。またユーザーに何ができ、何ができないかを想定する言葉を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-243">Avoid phrases that might not make sense to an international audience, and don't use words that make assumptions about what the user can and can't do.</span></span>

* <span data-ttu-id="3f64d-244">必要でない限り、特殊な専門用語を避け、**簡潔かつ明瞭である**ようにします。</span><span class="sxs-lookup"><span data-stu-id="3f64d-244">**Be crisp and clear** by avoiding unusual and specialized words when they aren't necessary.</span></span> <span data-ttu-id="3f64d-245">テキストが率直であるほど、ローカライズが容易になります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-245">The more straightforward your text is, the easier it is to localize.</span></span>


## <a name="techniques-for-non-writers"></a><span data-ttu-id="3f64d-246">テキスト作成に慣れていない方のためのテクニック</span><span class="sxs-lookup"><span data-stu-id="3f64d-246">Techniques for non-writers</span></span>

<span data-ttu-id="3f64d-247">快適なエクスペリエンスをユーザーに提供するために、トレーニングを受け、経験を積んだ書き手である必要はありません。</span><span class="sxs-lookup"><span data-stu-id="3f64d-247">You don't need to be a trained or experienced writer to provide your users with a good experience.</span></span> <span data-ttu-id="3f64d-248">自分にとって心地よい言葉を選びます。それは他人にも心地よい言葉です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-248">Pick words that sound comfortable to you — they'll feel comfortable to others, too.</span></span> <span data-ttu-id="3f64d-249">しかしそれは、考えていたほど簡単でないことがあります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-249">But sometimes, that's not as easy as it sounds.</span></span> <span data-ttu-id="3f64d-250">行き詰まった場合は、以下のテクニックを試してみてください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-250">If you get stuck, these techniques can help you out.</span></span> 

* <span data-ttu-id="3f64d-251">アプリを友人に説明しているところを想像します。</span><span class="sxs-lookup"><span data-stu-id="3f64d-251">Imagine that you're talking to a friend about your app.</span></span> <span data-ttu-id="3f64d-252">このアプリをその人たちにどのように説明しますか。</span><span class="sxs-lookup"><span data-stu-id="3f64d-252">How would you explain the app to them?</span></span> <span data-ttu-id="3f64d-253">アプリの機能についてどのように話し、操作手順をどのように伝えますか。</span><span class="sxs-lookup"><span data-stu-id="3f64d-253">How would you talk about its features or give them instructions?</span></span> <span data-ttu-id="3f64d-254">さらに良いのは、まだ使用したことのない人にアプリを説明してみることです。</span><span class="sxs-lookup"><span data-stu-id="3f64d-254">Better yet, explain the app to an actual person who hasn't used it yet.</span></span> 

* <span data-ttu-id="3f64d-255">まったく異なるアプリを説明するとしたら、どのように説明するかを想像してください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-255">Imagine how you would describe a completely different app.</span></span> <span data-ttu-id="3f64d-256">たとえば、ゲームを作っている場合は、財務アプリやニュース アプリを説明するのにどのように話したり、書いたりするかを考えてみてください。</span><span class="sxs-lookup"><span data-stu-id="3f64d-256">For instance, if you're making a game, think of what you'd say or write to describe a financial or a news app.</span></span> <span data-ttu-id="3f64d-257">言葉遣いや構造の違いを意識すると、実際のアプリの説明に使う適切な単語がより明らかになります。</span><span class="sxs-lookup"><span data-stu-id="3f64d-257">The contrast in the language and stucture you use can give you more insight into the right words for what you're actually writing about.</span></span>

* <span data-ttu-id="3f64d-258">同種のアプリを見て、ヒントを得るのも良い方法です。</span><span class="sxs-lookup"><span data-stu-id="3f64d-258">Take a look at similar apps for inspiration.</span></span> 

<span data-ttu-id="3f64d-259">適切な言葉を見つけることは多くの人にとって簡単ではありません。自然に感じられる表現が見つからなくても、決して気に病むことはありません。</span><span class="sxs-lookup"><span data-stu-id="3f64d-259">Finding the right words is a problem that many people struggle with, so don't feel bad if it's not easy to settle on something that feels natural.</span></span>