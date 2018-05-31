---
author: QuinnRadich
title: ボイスとトーン
description: アプリのテキストを設計と融合させるには、適切なボイスとトーンを使用することが重要です。
keywords: UWP, Windows 10, ボイス, トーン, テキスト, 書き込み, 設計, UI, UX
ms.author: quradic
ms.date: 8/52/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 8c95359afb148c6c77f3297aaacd5cb55e366c51
ms.sourcegitcommit: db09dcb08da5995c46c2729896e56be3774ee5ba
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2018
ms.locfileid: "1554542"
---
# <a name="voice-and-tone"></a><span data-ttu-id="23813-104">ボイスとトーン</span><span class="sxs-lookup"><span data-stu-id="23813-104">Voice and tone</span></span>

<span data-ttu-id="23813-105">詳細な操作手順から単純なヒントまで、テキストは、ほぼすべてのアプリに必要なコンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="23813-105">From detailed instructions to simple tooltips, text is a necessary component of almost all apps.</span></span> <span data-ttu-id="23813-106">そのようなユーザー エクスペリエンスの基本的な部分として、テキストはアプリの設計を強化するものであり、アプリの目的と視覚的なプレゼンテーションが調和している必要があります。</span><span class="sxs-lookup"><span data-stu-id="23813-106">As such a fundamental part of the user experience, text should augment an app's design, fitting the purpose of the app and the visual presentation.</span></span>

<span data-ttu-id="23813-107">あらゆるライティングと同様に、アプリのテキストを作成するときには、ボイスとトーンの選択についてじっくり考えることが必要です。</span><span class="sxs-lookup"><span data-stu-id="23813-107">As in all writing, when creating the text for your app, you should be deliberate about your choice of voice and tone.</span></span> <span data-ttu-id="23813-108">この 2 つはよく似ていますが異なります。ボイスは対象に対する姿勢であり、トーンはその実装であると考えることができます。</span><span class="sxs-lookup"><span data-stu-id="23813-108">These two are similar, but distinct — think of voice as your attitude towards the subject, while tone is its implementation.</span></span> <span data-ttu-id="23813-109">アプリ内にユーザー向けのテキストを書き込むときには、このボイスは常に友好的で自然であり、すぐにつながることができるものでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="23813-109">As the text in your app is written for the user, your voice should always be friendly and natural, something that can establish an immediate connection.</span></span> <span data-ttu-id="23813-110">トーンは、一般的なガイドラインに従っており、アプリのボイスやニーズと調和している限り、より柔軟にすることができます。</span><span class="sxs-lookup"><span data-stu-id="23813-110">Your tone can be more flexible, so long as it follows some general guidelines and works well with that voice and the needs of your app.</span></span> <span data-ttu-id="23813-111">適切な単語や語句を慎重に選択することにより、アプリのユーザー エクスペリエンスを向上させ、エラーの発生など、ユーザーにとってよくない状況において、ユーザーの負担を軽減し、少しでも快適なエクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="23813-111">By carefully choosing the right words and phrases, you can enhance the app's user experience, and make bad situations — such as encountering an error — easier and more pleasant for the user.</span></span>

## <a name="creating-a-friendly-natural-voice"></a><span data-ttu-id="23813-112">友好的で自然なボイスの作成</span><span class="sxs-lookup"><span data-stu-id="23813-112">Creating a friendly, natural voice</span></span>

<span data-ttu-id="23813-113">アプリのボイスは、その目的と設計を自然に、直感的に拡張したものです。</span><span class="sxs-lookup"><span data-stu-id="23813-113">The voice of your app is a natural and intuitive extension of its purpose and design.</span></span> <span data-ttu-id="23813-114">自分にとって心地よい言葉を選びます。それはユーザーにも心地よい言葉です。</span><span class="sxs-lookup"><span data-stu-id="23813-114">Pick words that sound comfortable to you — they'll feel comfortable to the user, too.</span></span>

<span data-ttu-id="23813-115">役に立つ方法の 1 つは、アプリの架空のユーザーに話していると想像してみることです。</span><span class="sxs-lookup"><span data-stu-id="23813-115">One helpful strategy is to imagine that you're talking to a hypothetical user of your app.</span></span> <span data-ttu-id="23813-116">自分の知っている人、友人や家族、会社の同僚を思い浮かべてください。</span><span class="sxs-lookup"><span data-stu-id="23813-116">Someone you know already, maybe a friend or family member or business associate.</span></span> <span data-ttu-id="23813-117">このアプリをその人たちにどのように説明しますか。</span><span class="sxs-lookup"><span data-stu-id="23813-117">How would you explain the app to them?</span></span> <span data-ttu-id="23813-118">その機能についてどのように説明しますか。操作の手順をどのように話しますか。</span><span class="sxs-lookup"><span data-stu-id="23813-118">How would you talk about its features, how would you give them instructions?</span></span> <span data-ttu-id="23813-119">話をするときに主題に合わせてボイスとトーンの変えているように、ライティングでもこのような方法が適切です。</span><span class="sxs-lookup"><span data-stu-id="23813-119">You're used to changing your voice and tone to fit the subject matter when talking, so this can put you on the right track for writing.</span></span>

<span data-ttu-id="23813-120">これに対して、まったく異なるアプリを説明する方法を想像してみることも役に立つ場合があります。</span><span class="sxs-lookup"><span data-stu-id="23813-120">For contrast, it could also be useful to imagine how you would describe a completely different app.</span></span> <span data-ttu-id="23813-121">ゲームを作っている場合は、財務アプリやニュース アプリを説明するのにどのように話したり、書いたりするかを考えてみてください。</span><span class="sxs-lookup"><span data-stu-id="23813-121">If you're making a game, think of what you'd say or write to describe a financial or a news app.</span></span> <span data-ttu-id="23813-122">生産性を向上させるアプリを設計している場合、教育アプリについて説明する方法を想像してください。</span><span class="sxs-lookup"><span data-stu-id="23813-122">If you're designing something to boost productivity, imagine how you'd talk about an educational app.</span></span> <span data-ttu-id="23813-123">さまざまなトピックについて話すときにどのような言葉や構造を使っているかを調べることによって、自分が記述しようとしている主題について、新しい見方ができるようになる場合があります。</span><span class="sxs-lookup"><span data-stu-id="23813-123">By exploring what language and structure you might use to talk about different topics, sometimes you can gain new insight into what you should be doing for the subject you're writing about.</span></span>

<span data-ttu-id="23813-124">さらに多くのアイデアを得るには、似たようなアプリを見てインスピレーションを得たり、Web で詳しいアドバイスを検索したりしてください。</span><span class="sxs-lookup"><span data-stu-id="23813-124">For more ideas, take a look at similar apps for inspiration or search the web for more advice.</span></span> <span data-ttu-id="23813-125">適切なボイスを見つけることは多くの人が苦労している問題であるため、適切だと感じるものを決めるのが容易ではない場合も悩まないでください。</span><span class="sxs-lookup"><span data-stu-id="23813-125">Finding the right voice is a problem that many people struggle with, so don't feel bad if it's not easy to settle on something that feels quite right.</span></span>

## <a name="general-tone-advice-for-uwp-apps"></a><span data-ttu-id="23813-126">UWP アプリ用のトーンに関する一般的なアドバイス</span><span class="sxs-lookup"><span data-stu-id="23813-126">General tone advice for UWP apps</span></span>

<span data-ttu-id="23813-127">アプリ内の領域は限られているため、それを上手に使用することが重要です。</span><span class="sxs-lookup"><span data-stu-id="23813-127">Space in apps is limited, and it's important to use it well.</span></span> <span data-ttu-id="23813-128">アプリで要求されている特定のトーンに関係なく、アプリのテキストを記述するときは、以下の原則を念頭に置くことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23813-128">No matter the specific tone your app requires, we recommend that you keep these principles in mind when writing its text:</span></span>

#### <a name="lead-with-whats-important"></a><span data-ttu-id="23813-129">大切なことから説明する</span><span class="sxs-lookup"><span data-stu-id="23813-129">Lead with what's important</span></span>

<span data-ttu-id="23813-130">テキストは、ユーザーが読んで一目で理解できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="23813-130">Users need to be able to read and understand your text at a glance.</span></span> <span data-ttu-id="23813-131">不要な前置きを付けて単語を長くしないでください。</span><span class="sxs-lookup"><span data-stu-id="23813-131">Don't pad your words with unnecessary introductions.</span></span> <span data-ttu-id="23813-132">重要なポイントが最も目立つようにします。常に、アイデアの中核部分を示した後で、説明を追加します。</span><span class="sxs-lookup"><span data-stu-id="23813-132">Give your key points the most visibility, and always present the core of an idea before you add onto it.</span></span>

<span data-ttu-id="23813-133">**適切:** [フィルター] を選択して画像に効果を追加します。</span><span class="sxs-lookup"><span data-stu-id="23813-133">**Good:** Select "filters" to add effects to your image.</span></span>

<span data-ttu-id="23813-134">**不適切:** 視覚効果や変更を画像に追加する場合は、[フィルター] を選択します。</span><span class="sxs-lookup"><span data-stu-id="23813-134">**Bad:** If you want to add visual effects or alterations to your image, select "filters."</span></span>

#### <a name="clarity-is-key"></a><span data-ttu-id="23813-135">わかりやすさが重要</span><span class="sxs-lookup"><span data-stu-id="23813-135">Clarity is key</span></span>

<span data-ttu-id="23813-136">対象読者が慣れ親しんでいる言葉を使用してください。</span><span class="sxs-lookup"><span data-stu-id="23813-136">Use language that will be familiar to your audience.</span></span> <span data-ttu-id="23813-137">通常、これは日常的な話し言葉を選択することを意味しますが、特殊な用途のアプリには独自の基準があります。</span><span class="sxs-lookup"><span data-stu-id="23813-137">Usually this means choosing everyday and conversational words, but apps for specialized uses will have their own standards.</span></span> <span data-ttu-id="23813-138">ユーザーがテキストを理解できないという状況は避ける必要があります。そのため、どのようなトーンを使用するか迷う場合は、わかりやすさを優先してください。</span><span class="sxs-lookup"><span data-stu-id="23813-138">Your users should never have to wonder what your text means, so favor simplicity if you're ever unsure of which tone to use.</span></span>

<span data-ttu-id="23813-139">**適切:** [設定] を選んで、アプリで写真を保存する方法を変更します。</span><span class="sxs-lookup"><span data-stu-id="23813-139">**Good:** Select "settings" to change how the app saves your pictures.</span></span>

<span data-ttu-id="23813-140">**不適切:** アプリの既定の動作は、[設定] メニューで構成することができます。</span><span class="sxs-lookup"><span data-stu-id="23813-140">**Bad:** The default behavior of the app can be configured in the "settings" menu.</span></span>

#### <a name="contractions-arent-a-problem"></a><span data-ttu-id="23813-141">短縮形は問題ない</span><span class="sxs-lookup"><span data-stu-id="23813-141">Contractions aren't a problem</span></span>

<span data-ttu-id="23813-142">短縮形は多くのユーザーが慣れ親しんだ、通常使用されている形式です。</span><span class="sxs-lookup"><span data-stu-id="23813-142">People are used to contractions, and expect to see them.</span></span> <span data-ttu-id="23813-143">短縮形を使わずに記述すると、アプリが堅苦しく、形式ばった印象になります。</span><span class="sxs-lookup"><span data-stu-id="23813-143">Avoiding them can make your app seem too formal or even stilted.</span></span>

<span data-ttu-id="23813-144">**適切:** When you're happy with your image, press "save" to add it to your gallery (画像に問題がなければ、[保存] をクリックしてギャラリーに追加します).</span><span class="sxs-lookup"><span data-stu-id="23813-144">**Good:** When you're happy with your image, press "save" to add it to your gallery.</span></span> <span data-ttu-id="23813-145">From there, you'll be able to share it with friends (ギャラリーから、友人と画像を共有できます).</span><span class="sxs-lookup"><span data-stu-id="23813-145">From there, you'll be able to share it with friends.</span></span>

<span data-ttu-id="23813-146">**不適切:** When you are happy with your image, press "save" to add it to your gallery (画像に問題がなければ、[保存] をクリックしてギャラリーに追加します).</span><span class="sxs-lookup"><span data-stu-id="23813-146">**Bad:** When you are happy with your image, press "save" to add it to your gallery.</span></span> <span data-ttu-id="23813-147">From there, you will be able to share it with friends (ギャラリーから、友人と画像を共有できます).</span><span class="sxs-lookup"><span data-stu-id="23813-147">From there, you will be able to share it with friends.</span></span>

#### <a name="emphasize-action"></a><span data-ttu-id="23813-148">アクションを強調する</span><span class="sxs-lookup"><span data-stu-id="23813-148">Emphasize action</span></span>

<span data-ttu-id="23813-149">アプリは、アクションによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="23813-149">Apps are defined by actions.</span></span> <span data-ttu-id="23813-150">ユーザーはアプリを使用するときにアクションを実行し、アプリはユーザーに応答するときにアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="23813-150">Users take action as they use the app, and the app takes action as it responds to the users.</span></span> <span data-ttu-id="23813-151">アプリ全体のテキストで*能動態*を使用していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="23813-151">Make sure your text uses the *active voice* throughout your app.</span></span> <span data-ttu-id="23813-152">ユーザーや機能は、アクションが実行される対象ではなく、アクションを実行するものとして記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23813-152">Users and functions should be described as doing things, instead of having things done to them.</span></span>

<span data-ttu-id="23813-153">**適切:** アプリを再起動して変更内容を表示します。</span><span class="sxs-lookup"><span data-stu-id="23813-153">**Good:** Restart the app to see your changes.</span></span>

<span data-ttu-id="23813-154">**不適切:** アプリが再起動されたときに、変更内容が適用されます。</span><span class="sxs-lookup"><span data-stu-id="23813-154">**Bad:** The changes will be applied when the app is restarted.</span></span>

#### <a name="short-and-sweet"></a><span data-ttu-id="23813-155">短く、わかりやすく</span><span class="sxs-lookup"><span data-stu-id="23813-155">Short and sweet</span></span>

<span data-ttu-id="23813-156">ユーザーはテキストをざっと見て、多くの場合、より大きな単語のブロック全体をスキップします。</span><span class="sxs-lookup"><span data-stu-id="23813-156">Users scan text, and will often skip over larger blocks of words entirely.</span></span> <span data-ttu-id="23813-157">必要な情報やプレゼンテーションを犠牲してはいけませんが、必要以上に語句を使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="23813-157">Don't sacrifice necessary information and presentation, but don't use more words than you have to.</span></span> <span data-ttu-id="23813-158">これは、短い文や語句を多用することを意味する場合もあれば、</span><span class="sxs-lookup"><span data-stu-id="23813-158">Sometimes, this will mean relying on many shorter sentences or fragments.</span></span> <span data-ttu-id="23813-159">長い文で単語や構造を慎重に選ぶことを意味する場合もあります。</span><span class="sxs-lookup"><span data-stu-id="23813-159">Other times, this will mean being extra choosy about the words and structure of longer sentences.</span></span>

<span data-ttu-id="23813-160">**適切:** 申し訳ありませんが、画像をアップロードできませんでした。</span><span class="sxs-lookup"><span data-stu-id="23813-160">**Good:** Sorry, we couldn't upload the picture.</span></span> <span data-ttu-id="23813-161">もう一度この問題が発生した場合は、アプリを再起動してください。</span><span class="sxs-lookup"><span data-stu-id="23813-161">If this happens again, try restarting the app.</span></span> <span data-ttu-id="23813-162">心配しないでください。再起動すると画像が復元されます。</span><span class="sxs-lookup"><span data-stu-id="23813-162">But don't worry — your picture will be waiting when you come back.</span></span>

<span data-ttu-id="23813-163">**不適切:** エラーが発生したため、画像をアップロードできませんでした。</span><span class="sxs-lookup"><span data-stu-id="23813-163">**Bad:** An error occured, and we weren't able to upload the picture.</span></span> <span data-ttu-id="23813-164">もう一度やり直してください。この問題をもう一度が発生した場合は、アプリを再起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23813-164">Please try again, and if you encounter this problem again, you may need to restart the app.</span></span> <span data-ttu-id="23813-165">心配は要りません。作業内容はローカルに保存されており、再起動すると復元されます。</span><span class="sxs-lookup"><span data-stu-id="23813-165">But don't worry - we've saved your work locally, and it'll be waiting for you when you come back.</span></span>

