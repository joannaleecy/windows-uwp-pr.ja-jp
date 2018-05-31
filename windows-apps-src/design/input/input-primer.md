---
author: Karl-Bridge-Microsoft
Description: User interactions in the Universal Windows Platform (UWP) are a combination of input and output sources (such as mouse, keyboard, pen, touch, touchpad, speech, Cortana, controller, gesture, gaze, and so on), along with various modes or modifiers that enable extended experiences (including mouse wheel and buttons, pen eraser and barrel buttons, touch keyboard, and background app services).
title: 操作の基本情報
ms.assetid: 73008F80-FE62-457D-BAEC-412ED6BAB0C8
label: Interaction primer
template: detail.hbs
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 910920c1f5eb5bdc3e55b51d7886be1632559c14
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
ms.locfileid: "1396611"
---
# <a name="interaction-primer"></a><span data-ttu-id="2239a-103">操作の基本情報</span><span class="sxs-lookup"><span data-stu-id="2239a-103">Interaction primer</span></span>


![Windows の入力の種類](images/input-interactions/icons-inputdevices03.png)

<span data-ttu-id="2239a-105">ユニバーサル Windows プラットフォーム (UWP) のユーザー操作は、入力/出力ソース (マウス、キーボード、ペン、タッチ、タッチパッド、音声、**Cortana**、コントローラー、ジェスチャ、視線入力など) の組み合わせと、拡張エクスペリエンスを可能にするさまざまなモード (修飾子) (マウス ホイールとボタン、ペンの消しゴムとバレル ボタン、タッチ キーボード、バックグラウンド アプリ サービスなど) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="2239a-105">User interactions in the Universal Windows Platform (UWP) are a combination of input and output sources (such as mouse, keyboard, pen, touch, touchpad, speech, **Cortana**, controller, gesture, gaze, and so on), along with various modes or modifiers that enable extended experiences (including mouse wheel and buttons, pen eraser and barrel buttons, touch keyboard, and background app services).</span></span>

<span data-ttu-id="2239a-106">UWP では "スマート" な状況依存の対話式操作システムが採用されているため、ほとんどの場合、アプリが受け取った固有の入力の種類を個別に処理する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="2239a-106">The UWP uses a "smart" contextual interaction system that, in most cases, eliminates the need to individually handle the unique types of input received by your app.</span></span> <span data-ttu-id="2239a-107">たとえば、タップや長押しなどの静的ジェスチャ、スライドでのパン操作などの操作ジェスチャ、またはデジタル インクのレンダリング操作をサポートするために、汎用的なポインターの種類として処理されるタッチ、タッチパッド、マウス、ペン入力があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-107">This includes handling touch, touchpad, mouse, and pen input as a generic pointer type to support static gestures such as tap or press-and-hold, manipulation gestures such as slide for panning, or rendering digital ink.</span></span>

<span data-ttu-id="2239a-108">特定のフォームファクターと組み合わせて使うときの各入力デバイスの種類とその動作、機能、制限事項を把握しておきましょう。</span><span class="sxs-lookup"><span data-stu-id="2239a-108">Familiarize yourself with each input device type and its behaviors, capabilities, and limitations when paired with certain form factors.</span></span> <span data-ttu-id="2239a-109">これにより、プラットフォームのコントロールとアフォーダンスがアプリに十分であるか、カスタマイズした操作エクスペリエンスの提供が必要であるかを判断しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="2239a-109">This can help you decide whether the platform controls and affordances are sufficient for your app, or require you to provide customized interaction experiences.</span></span>

## <a name="surface-dial"></a><span data-ttu-id="2239a-110">Surface Dial</span><span class="sxs-lookup"><span data-stu-id="2239a-110">Surface Dial</span></span>

<span data-ttu-id="2239a-111">Windows 10 Anniversary Update では、Windows Wheel と呼ばれる新しいカテゴリの入力デバイスを導入しています。</span><span class="sxs-lookup"><span data-stu-id="2239a-111">For Windows 10 Anniversary Update, we're introducing a new category of input device called Windows Wheel.</span></span> <span data-ttu-id="2239a-112">Surface Dial は、このクラスのデバイスの中で最初のものです。</span><span class="sxs-lookup"><span data-stu-id="2239a-112">The Surface Dial is the first in this class of device.</span></span> 

### <a name="device-support"></a><span data-ttu-id="2239a-113">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-113">Device support</span></span>

-   <span data-ttu-id="2239a-114">タブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-114">Tablet</span></span>
-   <span data-ttu-id="2239a-115">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-115">PCs and laptops</span></span>

### <a name="typical-usage"></a><span data-ttu-id="2239a-116">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-116">Typical usage</span></span>

<span data-ttu-id="2239a-117">回転動作 (またはジェスチャ) に基づくフォームファクタを持つ Surface Dial は、プライマリ デバイスからの入力を補完または変更する、セカンダリのマルチ モーダル入力デバイスとして設計されています。</span><span class="sxs-lookup"><span data-stu-id="2239a-117">With a form factor based on a rotate action (or gesture), the Surface Dial is intended as a secondary, multi-modal input device that complements or modifies input from a primary device.</span></span> <span data-ttu-id="2239a-118">このデバイスは多くの場合、ユーザーが優先的な手でタスクを実行している間に (たとえばペンでインク操作をするときなど)、従属的な手で操作されます。</span><span class="sxs-lookup"><span data-stu-id="2239a-118">In most cases, the device is manipulated by a user's non-dominant hand while they perform a task with their dominant hand (such as inking with a pen).</span></span>

### <a name="more-info"></a><span data-ttu-id="2239a-119">詳細</span><span class="sxs-lookup"><span data-stu-id="2239a-119">More info</span></span>

[<span data-ttu-id="2239a-120">Surface Dial の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2239a-120">Surface Dial design guidelines</span></span>](windows-wheel-interactions.md)


## <a name="cortana"></a><span data-ttu-id="2239a-121">Cortana</span><span class="sxs-lookup"><span data-stu-id="2239a-121">Cortana</span></span>

<span data-ttu-id="2239a-122">Windows 10 では、**Cortana** の機能拡張を利用して、ユーザーの音声コマンドを処理し、アプリケーションを起動して、単一のアクションを実行することができます。</span><span class="sxs-lookup"><span data-stu-id="2239a-122">In Windows 10, **Cortana** extensibility lets you handle voice commands from a user and launch your application to carry out a single action.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-123">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-123">Device support</span></span>

-   <span data-ttu-id="2239a-124">電話とファブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-124">Phones and phablets</span></span>
-   <span data-ttu-id="2239a-125">タブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-125">Tablet</span></span>
-   <span data-ttu-id="2239a-126">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-126">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-127">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="2239a-127">Surface Hub</span></span>
-   <span data-ttu-id="2239a-128">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-128">IoT</span></span>
-   <span data-ttu-id="2239a-129">Xbox</span><span class="sxs-lookup"><span data-stu-id="2239a-129">Xbox</span></span>
-   <span data-ttu-id="2239a-130">HoloLens</span><span class="sxs-lookup"><span data-stu-id="2239a-130">HoloLens</span></span>

![Cortana](images/input-interactions/icons-cortana01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-132">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-132">Typical usage</span></span>

<span data-ttu-id="2239a-133">音声コマンドは、1 つの言葉を声に出すことであり、音声コマンド定義 (VCD) ファイルで定義されています。**Cortana** を通じてインストール済みアプリに指示が伝えられます。</span><span class="sxs-lookup"><span data-stu-id="2239a-133">A voice command is a single utterance, defined in a Voice Command Definition (VCD) file, directed at an installed app through **Cortana**.</span></span> <span data-ttu-id="2239a-134">アプリは、操作のレベルと複雑さに応じて、フォアグラウンドまたはバックグラウンドで起動することができます。</span><span class="sxs-lookup"><span data-stu-id="2239a-134">The app can be launched in the foreground or background, depending on the level and complexity of the interaction.</span></span> <span data-ttu-id="2239a-135">たとえば、追加のコンテキストやユーザー入力が必要な音声コマンドはフォアグラウンドで処理するのが最適ですが、基本的なコマンドはバックグラウンドで処理できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-135">For instance, voice commands that require additional context or user input are best handled in the foreground, while basic commands can be handled in the background.</span></span>

<span data-ttu-id="2239a-136">アプリの基本的な機能を統合して、ユーザーが直接アプリを開かずにほとんどのタスクを実行できる中心的エントリ ポイントを提供することで、**Cortana** はアプリとユーザーの仲介役となります。</span><span class="sxs-lookup"><span data-stu-id="2239a-136">Integrating the basic functionality of your app, and providing a central entry point for the user to accomplish most of the tasks without opening your app directly, lets **Cortana** become a liaison between your app and the user.</span></span> <span data-ttu-id="2239a-137">多くの場合、これによってユーザーの時間と労力を大幅に減らすことができます。</span><span class="sxs-lookup"><span data-stu-id="2239a-137">In many cases, this can save the user significant time and effort.</span></span> <span data-ttu-id="2239a-138">詳しくは、「[Cortana の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn974233)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2239a-138">For more info, see [Cortana design guidelines](https://msdn.microsoft.com/library/windows/apps/dn974233).</span></span>

### <a name="more-info"></a><span data-ttu-id="2239a-139">詳細</span><span class="sxs-lookup"><span data-stu-id="2239a-139">More info</span></span>

[<span data-ttu-id="2239a-140">Cortana の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2239a-140">Cortana design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/dn974233)
 

## <a name="speech"></a><span data-ttu-id="2239a-141">音声認識</span><span class="sxs-lookup"><span data-stu-id="2239a-141">Speech</span></span>

<span data-ttu-id="2239a-142">音声認識により、アプリケーションを効果的かつ自然に操作できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-142">Speech is an effective and natural way for people to interact with applications.</span></span> <span data-ttu-id="2239a-143">また、音声認識により、アプリケーションを正確かつ容易に操作し、さまざまな状況で生産性を高め、いつでも新しい情報を入手することができます。</span><span class="sxs-lookup"><span data-stu-id="2239a-143">It's an easy and accurate way to communicate with applications, and lets people be productive and stay informed in a variety of situations.</span></span>

<span data-ttu-id="2239a-144">音声認識は補完的な入力手段としてだけでなく、ユーザーのデバイスに応じて、多くの状況でメインの入力手段として利用できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-144">Speech can complement or, in many cases, be the primary input type, depending on the user's device.</span></span> <span data-ttu-id="2239a-145">たとえば、HoloLens、Xbox などのデバイスでは、従来の入力の種類がサポートされません (特定のシナリオのソフトウェア キーボードを除く)。</span><span class="sxs-lookup"><span data-stu-id="2239a-145">For example, devices such as HoloLens and Xbox do not support traditional input types (aside from a software keyboard in specific scenarios).</span></span> <span data-ttu-id="2239a-146">こうしたデバイスでは、ほとんどのユーザー操作で音声入出力が使われています (多くの場合、視線、ジェスチャなどの他の非標準的な種類の入力と組み合わせて使われます)。</span><span class="sxs-lookup"><span data-stu-id="2239a-146">Instead, they rely on speech input and output (often combined with other non-traditional input types such as gaze and gesture) for most user interactions.</span></span>

<span data-ttu-id="2239a-147">ユーザーへの通知や指示には、音声合成 (TTS とも呼ばれます) が使用されています。</span><span class="sxs-lookup"><span data-stu-id="2239a-147">Text-to-speech (also known as TTS, or speech synthesis) is used to inform or direct the user.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-148">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-148">Device support</span></span>

-   <span data-ttu-id="2239a-149">電話とファブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-149">Phones and phablets</span></span>
-   <span data-ttu-id="2239a-150">タブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-150">Tablet</span></span>
-   <span data-ttu-id="2239a-151">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-151">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-152">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="2239a-152">Surface Hub</span></span>
-   <span data-ttu-id="2239a-153">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-153">IoT</span></span>
-   <span data-ttu-id="2239a-154">Xbox</span><span class="sxs-lookup"><span data-stu-id="2239a-154">Xbox</span></span>
-   <span data-ttu-id="2239a-155">HoloLens</span><span class="sxs-lookup"><span data-stu-id="2239a-155">HoloLens</span></span>

![音声認識](images/input-interactions/icons-speech01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-157">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-157">Typical usage</span></span>

<span data-ttu-id="2239a-158">音声操作には 3 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="2239a-158">There are three modes of Speech interaction:</span></span>

**<span data-ttu-id="2239a-159">自然言語</span><span class="sxs-lookup"><span data-stu-id="2239a-159">Natural language</span></span>**

<span data-ttu-id="2239a-160">自然言語とは、人が人とコミュニケーションをとるために通常使っている言葉のことです。</span><span class="sxs-lookup"><span data-stu-id="2239a-160">Natural language is how we verbally interact with people on a regular basis.</span></span> <span data-ttu-id="2239a-161">表現は人や状況によって異なるため、一般的に解釈されます。</span><span class="sxs-lookup"><span data-stu-id="2239a-161">Our speech varies from person to person and situation to situation, and is generally understood.</span></span> <span data-ttu-id="2239a-162">解釈されない場合は、人は単語や語順を変えて、同じ考えを伝えようとします。</span><span class="sxs-lookup"><span data-stu-id="2239a-162">When it's not, we often use different words and word order to get the same idea across.</span></span>

<span data-ttu-id="2239a-163">自然言語によるアプリの操作はこれと似ています。私たちは人に話しかけるようにアプリに話しかけ、話しかけた内容をアプリが理解し、その内容に従って応答することを期待します。</span><span class="sxs-lookup"><span data-stu-id="2239a-163">Natural language interactions with an app are similar: we speak to the app through our device as if it were a person and expect it to understand and react accordingly.</span></span>

<span data-ttu-id="2239a-164">自然言語は最も高度な音声操作で、**Cortana** によって実装および公開できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-164">Natural language is the most advanced mode of speech interaction, and can be implemented and exposed through **Cortana**.</span></span>

**<span data-ttu-id="2239a-165">音声コマンド</span><span class="sxs-lookup"><span data-stu-id="2239a-165">Command and control</span></span>**

<span data-ttu-id="2239a-166">音声コマンドを使うと、ボタンのクリック、メニューの選択などのコントロールと機能を音声でアクティブ化できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-166">Command and control is the use of verbal commands to activate controls and functionality such as clicking a button or selecting a menu item.</span></span>

<span data-ttu-id="2239a-167">音声コマンドは、優れたユーザー エクスペリエンスには欠かせません。このため入力の種類を 1 つにすることは、通常お勧めしません。</span><span class="sxs-lookup"><span data-stu-id="2239a-167">As command and control is critical to a successful user experience, a single input type is generally not recommended.</span></span> <span data-ttu-id="2239a-168">音声認識は、通常、基本設定やハードウェア機能に基づいて、ユーザー向け入力オプションの 1 つとして含まれています。</span><span class="sxs-lookup"><span data-stu-id="2239a-168">Speech is typically one of several input options for a user based on their preferences or hardware capabilities.</span></span>

**<span data-ttu-id="2239a-169">ディクテーション</span><span class="sxs-lookup"><span data-stu-id="2239a-169">Dictation</span></span>**

<span data-ttu-id="2239a-170">最も基本的な音声入力方法です。</span><span class="sxs-lookup"><span data-stu-id="2239a-170">The most basic speech input method.</span></span> <span data-ttu-id="2239a-171">発声した各語句がテキストに変換されます。</span><span class="sxs-lookup"><span data-stu-id="2239a-171">Each utterance is converted to text.</span></span>

<span data-ttu-id="2239a-172">ディクテーションは通常、アプリが語句の意味や意図を理解する必要がない場合に使われます。</span><span class="sxs-lookup"><span data-stu-id="2239a-172">Dictation is typically used when an app doesn’t need to understand meaning or intent.</span></span>

### <a name="more-info"></a><span data-ttu-id="2239a-173">詳細</span><span class="sxs-lookup"><span data-stu-id="2239a-173">More info</span></span>

[<span data-ttu-id="2239a-174">音声認識の設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2239a-174">Speech design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/dn596121)
 

## <a name="pen"></a><span data-ttu-id="2239a-175">ペン</span><span class="sxs-lookup"><span data-stu-id="2239a-175">Pen</span></span>

<span data-ttu-id="2239a-176">ペン (スタイラス) は、マウス同様ピクセル単位のポインティング デバイスとして動作し、デジタル インク入力には最適なデバイスです。</span><span class="sxs-lookup"><span data-stu-id="2239a-176">A pen (or stylus) can serve as a pixel precise pointing device, like a mouse, and is the optimal device for digital ink input.</span></span>

<span data-ttu-id="2239a-177">**注**  ペン デバイスには、アクティブとパッシブの 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-177">**Note**  There are two types of pen devices: active and passive.</span></span>
  -   <span data-ttu-id="2239a-178">電気的な回路が組み込まれていないパッシブなペンは、1 本の指からのタッチ入力を効果的にエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="2239a-178">Passive pens do not contain electronics, and effectively emulate touch input from a finger.</span></span> <span data-ttu-id="2239a-179">このペンには、接触の圧力に基づいて入力を認識する基本的なデバイス ディスプレイが必要です。</span><span class="sxs-lookup"><span data-stu-id="2239a-179">They require a basic device display that recognizes input based on contact pressure.</span></span> <span data-ttu-id="2239a-180">ユーザーは入力サーフェスに手を置きながら書き込むことがよくあるため、パーム リジェクションの失敗が原因で入力データが汚染されることがあります。</span><span class="sxs-lookup"><span data-stu-id="2239a-180">Because users often rest their hand as they write on the input surface, input data can become polluted due to unsuccessful palm rejection.</span></span>
  -   <span data-ttu-id="2239a-181">アクティブなペンには電気的な回路が組み込まれています。このペンは複雑なデバイス ディスプレイで動作して、より広範な入力データ (ホバー、近接通信データを含む) をシステムやアプリに提供できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-181">Active pens contain electronics and can work with complex device displays to provide much more extensive input data (including hover, or proximity data) to the system and your app.</span></span> <span data-ttu-id="2239a-182">パーム リジェクションは、はるかに堅牢です。</span><span class="sxs-lookup"><span data-stu-id="2239a-182">Palm rejection is much more robust.</span></span>

<span data-ttu-id="2239a-183">ここでペン デバイスと言う場合、高度な入力データを提供し、主に正確なインク操作やポイント操作に使われるアクティブなペンを指します。</span><span class="sxs-lookup"><span data-stu-id="2239a-183">When we refer to pen devices here, we are referring to active pens that provide rich input data and are used primarily for precise ink and pointing interactions.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-184">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-184">Device support</span></span>

-   <span data-ttu-id="2239a-185">電話とファブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-185">Phones and phablets</span></span>
-   <span data-ttu-id="2239a-186">タブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-186">Tablet</span></span>
-   <span data-ttu-id="2239a-187">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-187">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-188">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="2239a-188">Surface Hub</span></span>
-   <span data-ttu-id="2239a-189">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-189">IoT</span></span>

![ペン](images/input-interactions/icons-pen01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-191">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-191">Typical usage</span></span>

<span data-ttu-id="2239a-192">Windows のインク プラットフォームでペンを使うと、自然な形で手書きのノート、描画、コメントを作成できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-192">The Windows ink platform, together with a pen, provides a natural way to create handwritten notes, drawings, and annotations.</span></span> <span data-ttu-id="2239a-193">このプラットフォームは、デジタイザー入力からのインク データのキャプチャ、インク データの生成、出力デバイスへのひと筆としてのデータのレンダリング、インク データの管理、手書き認識の実行をサポートします。</span><span class="sxs-lookup"><span data-stu-id="2239a-193">The platform supports capturing ink data from digitizer input, generating ink data, rendering that data as ink strokes on the output device, managing the ink data, and performing handwriting recognition.</span></span> <span data-ttu-id="2239a-194">ユーザーが書いたり描画したりするときのペンの空間移動のキャプチャに加えて、アプリで筆圧、形状、色、不透明度などの情報を収集して、紙の上でペン、鉛筆、ブラシを使っているときに近いユーザー エクスペリエンスを実現することもできます。</span><span class="sxs-lookup"><span data-stu-id="2239a-194">In addition to capturing the spatial movements of the pen as the user writes or draws, your app can also collect info such as pressure, shape, color, and opacity, to offer user experiences that closely resemble drawing on paper with a pen, pencil, or brush.</span></span>

<span data-ttu-id="2239a-195">ペン入力とタッチ入力が異なるのは、タッチでは画面上の UI 要素に対する物理的なジェスチャ (スワイプ、スライド、ドラッグ、回転など) を通じて、それらのオブジェクトへの直接の操作をエミュレートする機能があることです。</span><span class="sxs-lookup"><span data-stu-id="2239a-195">Where pen and touch input diverge is the ability for touch to emulate direct manipulation of UI elements on the screen through physical gestures performed on those objects (such as swiping, sliding, dragging, rotating, and so on).</span></span>

<span data-ttu-id="2239a-196">このような操作をサポートするには、ペン固有の UI コマンド、またはアフォーダンスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-196">You should provide pen-specific UI commands, or affordances, to support these interactions.</span></span> <span data-ttu-id="2239a-197">たとえば、"前へ" ボタンと "次へ" ボタン (または "+" ボタンと "-" ボタン) を使ってコンテンツのページをフリップしたり、オブジェクトを回転、サイズ変更、ズームしたりできるようにします。</span><span class="sxs-lookup"><span data-stu-id="2239a-197">For example, use previous and next (or + and -) buttons to let users flip through pages of content, or rotate, resize, and zoom objects.</span></span>

### <a name="more-info"></a><span data-ttu-id="2239a-198">詳細</span><span class="sxs-lookup"><span data-stu-id="2239a-198">More info</span></span>

[<span data-ttu-id="2239a-199">ペンの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2239a-199">Pen design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/dn456352)
 

## <a name="touch"></a><span data-ttu-id="2239a-200">タッチ</span><span class="sxs-lookup"><span data-stu-id="2239a-200">Touch</span></span>

<span data-ttu-id="2239a-201">タッチ操作では、(マウスやペンのように) 代替の入力方法として、または相補的な入力方法として (汚れ、ペンで描くひと筆などの他の入力を変更)、UI 要素の直接的な操作 (パン、回転、サイズ変更、移動など) をエミュレートするために、1 つまたは複数の指から物理的なジェスチャを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-201">With touch, physical gestures from one or more fingers can be used to either emulate the direct manipulation of UI elements (such as panning, rotating, resizing, or moving), as an alternative input method (similar to mouse or pen), or as a complementary input method (to modify aspects of other input, such as smudging an ink stroke drawn with a pen).</span></span> <span data-ttu-id="2239a-202">このような触覚的なエクスペリエンスは、ユーザーが画面の要素を操作するときに、より自然で現実的で感覚を提供します。</span><span class="sxs-lookup"><span data-stu-id="2239a-202">Tactile experiences such as this can provide more natural, real-world sensations for users as they interact with elements on a screen.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-203">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-203">Device support</span></span>

-   <span data-ttu-id="2239a-204">電話とファブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-204">Phones and phablets</span></span>
-   <span data-ttu-id="2239a-205">タブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-205">Tablet</span></span>
-   <span data-ttu-id="2239a-206">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-206">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-207">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="2239a-207">Surface Hub</span></span>
-   <span data-ttu-id="2239a-208">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-208">IoT</span></span>

![タッチ](images/input-interactions/icons-touch01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-210">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-210">Typical usage</span></span>

<span data-ttu-id="2239a-211">タッチ入力のサポートは、デバイスによって大きく異なることがあります。</span><span class="sxs-lookup"><span data-stu-id="2239a-211">Support for touch input can vary significantly, depending on the device.</span></span>

<span data-ttu-id="2239a-212">たとえば、デバイスによって、タッチ操作をまったくサポートしなかったり、1 か所の接触のみ、またはマルチタッチ操作 (2 か所以上の接触) をサポートしたりします。</span><span class="sxs-lookup"><span data-stu-id="2239a-212">Some devices don't support touch at all, some devices support a single touch contact, while others support multi-touch (two or more contacts).</span></span>

<span data-ttu-id="2239a-213">マルチタッチ入力をサポートするデバイスのほとんどは、通常、10 か所の独自の同時接触を認識します。</span><span class="sxs-lookup"><span data-stu-id="2239a-213">Most devices that support multi-touch input, typically recognize ten unique, concurrent contacts.</span></span>

<span data-ttu-id="2239a-214">Surface Hub デバイスは、100 か所の独自の同時タッチ接触を認識します。</span><span class="sxs-lookup"><span data-stu-id="2239a-214">Surface Hub devices recognize 100 unique, concurrent touch contacts.</span></span>

<span data-ttu-id="2239a-215">一般的にタッチには、次のような特徴があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-215">In general, touch is:</span></span>

-   <span data-ttu-id="2239a-216">単一ユーザー。ただし、共同作業が強調されている Surface Hub などの Microsoft チーム デバイスで使用されている場合を除きます。</span><span class="sxs-lookup"><span data-stu-id="2239a-216">Single user, unless being used with a Microsoft Team device like Surface Hub, where collaboration is emphasized.</span></span>
-   <span data-ttu-id="2239a-217">デバイスの向きに制限されない。</span><span class="sxs-lookup"><span data-stu-id="2239a-217">Not constrained to device orientation.</span></span>
-   <span data-ttu-id="2239a-218">すべての操作 (テキスト入力 (タッチ キーボード)、手描き入力 (アプリで構成) を含む) で使用される。</span><span class="sxs-lookup"><span data-stu-id="2239a-218">Used for all interactions, including text input (touch keyboard) and inking (app-configured).</span></span>

### <a name="more-info"></a><span data-ttu-id="2239a-219">詳細</span><span class="sxs-lookup"><span data-stu-id="2239a-219">More info</span></span>

[<span data-ttu-id="2239a-220">タッチの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2239a-220">Touch design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/hh465370)
 

## <a name="touchpad"></a><span data-ttu-id="2239a-221">タッチパッド</span><span class="sxs-lookup"><span data-stu-id="2239a-221">Touchpad</span></span>

<span data-ttu-id="2239a-222">タッチパッドは、間接的なマルチタッチ入力と、マウスのようなポインティング デバイスの精密入力を組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="2239a-222">A touchpad combines both indirect multi-touch input with the precision input of a pointing device, such as a mouse.</span></span> <span data-ttu-id="2239a-223">この組み合わせにより、タッチパッドはタッチに最適化された UI にも、生産性アプリのより小さいターゲットにも適しています。</span><span class="sxs-lookup"><span data-stu-id="2239a-223">This combination makes the touchpad suited to both a touch-optimized UI and the smaller targets of productivity apps.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-224">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-224">Device support</span></span>

-   <span data-ttu-id="2239a-225">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-225">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-226">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-226">IoT</span></span>

![タッチパッド](images/input-interactions/icons-touchpad01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-228">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-228">Typical usage</span></span>

<span data-ttu-id="2239a-229">通常、タッチパッドは、オブジェクトと UI の直接的な操作に使われるタッチと同様のサポートを実現する、一連のタッチ ジェスチャをサポートします。</span><span class="sxs-lookup"><span data-stu-id="2239a-229">Touchpads typically support a set of touch gestures that provide support similar to touch for direct manipulation of objects and UI.</span></span>

<span data-ttu-id="2239a-230">タッチパッドでサポートされている対話式操作のエクスペリエンスは複合的であるため、単にタッチ入力のサポートに依存するのではなく、マウス スタイル UI コマンドまたはアフォーダンスも提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2239a-230">Because of this convergence of interaction experiences supported by touchpads, we recommend also providing mouse-style UI commands or affordances rather than relying solely on support for touch input.</span></span> <span data-ttu-id="2239a-231">このような操作をサポートするには、タッチパッド固有の UI コマンド、またはアフォーダンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="2239a-231">Provide touchpad-specific UI commands, or affordances, to support these interactions.</span></span>

<span data-ttu-id="2239a-232">このような操作をサポートするには、マウス固有の UI コマンド、またはアフォーダンスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-232">You should provide mouse-specific UI commands, or affordances, to support these interactions.</span></span> <span data-ttu-id="2239a-233">たとえば、"前へ" ボタンと "次へ" ボタン (または "+" ボタンと "-" ボタン) を使ってコンテンツのページをフリップしたり、オブジェクトを回転、サイズ変更、ズームしたりできるようにします。</span><span class="sxs-lookup"><span data-stu-id="2239a-233">For example, use previous and next (or + and -) buttons to let users flip through pages of content, or rotate, resize, and zoom objects.</span></span>

### <a name="more-info"></a><span data-ttu-id="2239a-234">詳細</span><span class="sxs-lookup"><span data-stu-id="2239a-234">More info</span></span>

[<span data-ttu-id="2239a-235">タッチパッドの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2239a-235">Touchpad design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/dn456353)
 

## <a name="keyboard"></a><span data-ttu-id="2239a-236">キーボード</span><span class="sxs-lookup"><span data-stu-id="2239a-236">Keyboard</span></span>

<span data-ttu-id="2239a-237">キーボードはテキスト用の主要な入力デバイスであり、多くの場合、特定の障碍のあるユーザーや、キーボードを使った方がアプリをすばやく効率よく操作できると考えるユーザーにとって欠かせません。</span><span class="sxs-lookup"><span data-stu-id="2239a-237">A keyboard is the primary input device for text, and is often indispensable to people with certain disabilities or users who consider it a faster and more efficient way to interact with an app.</span></span>

<span data-ttu-id="2239a-238">互換性のある Windows 10 Mobile デバイスの新しいエクスペリエンスである[電話用 Continuum](http://go.microsoft.com/fwlink/p/?LinkID=699431) を利用すると、ユーザーは電話をマウスやキーボードに接続して、その電話をノート PC のように使うことができます。</span><span class="sxs-lookup"><span data-stu-id="2239a-238">With [Continuum for Phone](http://go.microsoft.com/fwlink/p/?LinkID=699431), a new experience for compatible Windows 10 mobile devices, users can connect their phones to a mouse and keyboard to make their phones work like a laptop.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-239">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-239">Device support</span></span>

-   <span data-ttu-id="2239a-240">電話とファブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-240">Phones and phablets</span></span>
-   <span data-ttu-id="2239a-241">タブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-241">Tablet</span></span>
-   <span data-ttu-id="2239a-242">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-242">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-243">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="2239a-243">Surface Hub</span></span>
-   <span data-ttu-id="2239a-244">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-244">IoT</span></span>
-   <span data-ttu-id="2239a-245">Xbox</span><span class="sxs-lookup"><span data-stu-id="2239a-245">Xbox</span></span>
-   <span data-ttu-id="2239a-246">HoloLens</span><span class="sxs-lookup"><span data-stu-id="2239a-246">HoloLens</span></span>

![キーボード](images/input-interactions/icons-keyboard01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-248">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-248">Typical usage</span></span>

<span data-ttu-id="2239a-249">ユーザーはハードウェア キーボードと 2 つのソフトウェア キーボード (スクリーン キーボード (OSK) およびタッチ キーボード) を通じて、ユニバーサル Windows アプリを操作できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-249">Users can interact with Universal Windows apps through a hardware keyboard and two software keyboards: the On-Screen Keyboard (OSK) and the touch keyboard.</span></span>

<span data-ttu-id="2239a-250">OSK は、物理的なキーボードの代わりに使うことができる視覚的なソフトウェア キーボードです。タッチ、マウス、ペン/スタイラス、またはその他のポインティング デバイスを通じてデータを入力します (タッチ スクリーンは必須ではありません)。</span><span class="sxs-lookup"><span data-stu-id="2239a-250">The OSK is a visual, software keyboard that you can use instead of the physical keyboard to type and enter data using touch, mouse, pen/stylus or other pointing device (a touch screen is not required).</span></span> <span data-ttu-id="2239a-251">OSK は、物理的なキーボードが存在しないシステムや、運動障碍により一般的な物理入力デバイスを使うことができないユーザーのために用意されています。</span><span class="sxs-lookup"><span data-stu-id="2239a-251">The OSK is provided for systems that don't have a physical keyboard, or for users whose mobility impairments prevent them from using traditional physical input devices.</span></span> <span data-ttu-id="2239a-252">OSK は、ハードウェア キーボードの機能のすべて、または少なくともほとんどをエミュレートします。</span><span class="sxs-lookup"><span data-stu-id="2239a-252">The OSK emulates most, if not all, the functionality of a hardware keyboard.</span></span>

<span data-ttu-id="2239a-253">タッチ キーボードは、タッチ入力でのテキスト入力に使われる、視覚的なソフトウェア キーボードです。</span><span class="sxs-lookup"><span data-stu-id="2239a-253">The touch keyboard is a visual, software keyboard used for text entry with touch input.</span></span> <span data-ttu-id="2239a-254">タッチ キーボードはテキスト入力専用であり (ハードウェア キーボードをエミュレートしません)、テキスト フィールドや編集可能なテキスト コントロールにフォーカスがあるときにだけ表示されるので、OSK の代わりになるものではありません。</span><span class="sxs-lookup"><span data-stu-id="2239a-254">The touch keyboard is not a replacement for the OSK as it is used for text input only (it doesn't emulate the hardware keyboard) and appears only when a text field or other editable text control gets focus.</span></span> <span data-ttu-id="2239a-255">タッチ キーボードは、アプリ コマンドやシステム コマンドをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="2239a-255">The touch keyboard does not support app or system commands.</span></span>

<span data-ttu-id="2239a-256">**注**  OSK の方がタッチ キーボードより優先され、OSK が表示されている場合はタッチ キーボードは表示されません。</span><span class="sxs-lookup"><span data-stu-id="2239a-256">**Note**  The OSK has priority over the touch keyboard, which won't be shown if the OSK is present.</span></span>

<span data-ttu-id="2239a-257">一般的にキーボードには、次のような特徴があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-257">In general, a keyboard is:</span></span>

-   <span data-ttu-id="2239a-258">単一ユーザー。</span><span class="sxs-lookup"><span data-stu-id="2239a-258">Single user.</span></span>
-   <span data-ttu-id="2239a-259">デバイスの向きに制限されない。</span><span class="sxs-lookup"><span data-stu-id="2239a-259">Not constrained to device orientation.</span></span>
-   <span data-ttu-id="2239a-260">テキスト入力、ナビゲーション、ゲームプレイ、およびアクセシビリティのために使用される。</span><span class="sxs-lookup"><span data-stu-id="2239a-260">Used for text input, navigation, gameplay, and accessibility.</span></span>
-   <span data-ttu-id="2239a-261">常に利用可能 (事前または事後)。</span><span class="sxs-lookup"><span data-stu-id="2239a-261">Always available, either proactively or reactively.</span></span>

### <a name="more-info"></a><span data-ttu-id="2239a-262">詳細</span><span class="sxs-lookup"><span data-stu-id="2239a-262">More info</span></span>

[<span data-ttu-id="2239a-263">キーボードの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2239a-263">Keyboard design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/hh972345)
 

## <a name="mouse"></a><span data-ttu-id="2239a-264">マウス</span><span class="sxs-lookup"><span data-stu-id="2239a-264">Mouse</span></span>

<span data-ttu-id="2239a-265">マウスは、ユーザー操作でターゲット設定とコマンド実行にピクセルレベルの精度を必要とする、生産性アプリや高密度 UI に最適です。</span><span class="sxs-lookup"><span data-stu-id="2239a-265">A mouse is best suited for productivity apps and high-density UI where user interactions require pixel-level precision for targeting and commanding.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-266">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-266">Device support</span></span>

-   <span data-ttu-id="2239a-267">電話とファブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-267">Phones and phablets</span></span>
-   <span data-ttu-id="2239a-268">タブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-268">Tablet</span></span>
-   <span data-ttu-id="2239a-269">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-269">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-270">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="2239a-270">Surface Hub</span></span>
-   <span data-ttu-id="2239a-271">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-271">IoT</span></span>

![マウス](images/input-interactions/icons-mouse01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-273">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-273">Typical usage</span></span>

<span data-ttu-id="2239a-274">マウス入力は、キーボードのさまざまなキー (Ctrl、Shift、Alt キーなど) を追加して変更できます。</span><span class="sxs-lookup"><span data-stu-id="2239a-274">Mouse input can be modified with the addition of various keyboard keys (Ctrl, Shift, Alt, and so on).</span></span> <span data-ttu-id="2239a-275">これらのキーは、マウスの左ボタンや右ボタン、ホイール ボタン、X ボタンと組み合わせて、マウスに最適化した拡張コマンド セットを作成できます </span><span class="sxs-lookup"><span data-stu-id="2239a-275">These keys can be combined with the left mouse button, the right mouse button, the wheel button, and the X buttons for an expanded mouse-optimized command set.</span></span> <span data-ttu-id="2239a-276">(一部の Microsoft マウス デバイスでは、追加のボタン (X ボタン) は通常、Web ブラウザーで前後のページに移動するために使います)。</span><span class="sxs-lookup"><span data-stu-id="2239a-276">(Some Microsoft mouse devices have two additional buttons, referred to as X buttons, typically used to navigate back and forward in Web browsers).</span></span>

<span data-ttu-id="2239a-277">ペンと同様に、マウス入力とタッチ入力が異なるのは、タッチでは画面上の UI 要素に対する物理的なジェスチャ (スワイプ、スライド、ドラッグ、回転など) を通じて、それらのオブジェクトへの直接の操作をエミュレートする機能があることです。</span><span class="sxs-lookup"><span data-stu-id="2239a-277">Similar to pen, where mouse and touch input diverge is the ability for touch to emulate direct manipulation of UI elements on the screen through physical gestures performed on those objects (such as swiping, sliding, dragging, rotating, and so on).</span></span>

<span data-ttu-id="2239a-278">このような操作をサポートするには、マウス固有の UI コマンド、またはアフォーダンスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-278">You should provide mouse-specific UI commands, or affordances, to support these interactions.</span></span> <span data-ttu-id="2239a-279">たとえば、"前へ" ボタンと "次へ" ボタン (または "+" ボタンと "-" ボタン) を使ってコンテンツのページをフリップしたり、オブジェクトを回転、サイズ変更、ズームしたりできるようにします。</span><span class="sxs-lookup"><span data-stu-id="2239a-279">For example, use previous and next (or + and -) buttons to let users flip through pages of content, or rotate, resize, and zoom objects.</span></span>

### <a name="more-info"></a><span data-ttu-id="2239a-280">詳細</span><span class="sxs-lookup"><span data-stu-id="2239a-280">More info</span></span>

[<span data-ttu-id="2239a-281">マウスの設計ガイドライン</span><span class="sxs-lookup"><span data-stu-id="2239a-281">Mouse design guidelines</span></span>](https://msdn.microsoft.com/library/windows/apps/dn456351)
 

## <a name="gesture"></a><span data-ttu-id="2239a-282">ジェスチャ</span><span class="sxs-lookup"><span data-stu-id="2239a-282">Gesture</span></span>

<span data-ttu-id="2239a-283">ジェスチャは、アプリケーションを制御または操作するための入力として認識される、なんらかの形式のユーザーの動きです。</span><span class="sxs-lookup"><span data-stu-id="2239a-283">A gesture is any form of user movement that is recognized as input for controlling or interacting with an application.</span></span> <span data-ttu-id="2239a-284">ジェスチャには、手を使って画面上の何かをターゲットにするだけの単純なものから、特定の学習されたパターンの動きをターゲットにしたり、体全体を使った連続的な動きの長いストレッチまで、さまざまな形式があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-284">Gestures take many forms, from simply using a hand to target something on the screen, to specific, learned patterns of movement, to long stretches of continuous movement using the entire body.</span></span> <span data-ttu-id="2239a-285">カスタム ジェスチャを設計するときは、その意味がロケールやカルチャによって異なる場合があるため、注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="2239a-285">Be careful when designing custom gestures, as their meaning can vary depending on locale and culture.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-286">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-286">Device support</span></span>

-   <span data-ttu-id="2239a-287">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-287">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-288">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-288">IoT</span></span>
-   <span data-ttu-id="2239a-289">Xbox</span><span class="sxs-lookup"><span data-stu-id="2239a-289">Xbox</span></span>
-   <span data-ttu-id="2239a-290">HoloLens</span><span class="sxs-lookup"><span data-stu-id="2239a-290">HoloLens</span></span>

![ジェスチャ](images/input-interactions/icons-gesture01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-292">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-292">Typical usage</span></span>

<span data-ttu-id="2239a-293">静的ジェスチャ イベントは、対話式操作が完了した後に発生します。</span><span class="sxs-lookup"><span data-stu-id="2239a-293">Static gesture events are fired after an interaction is complete.</span></span>

- <span data-ttu-id="2239a-294">静的ジェスチャ イベントには、Tapped、DoubleTapped、RightTapped、Holding があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-294">Static gesture events include Tapped, DoubleTapped, RightTapped, and Holding.</span></span>

<span data-ttu-id="2239a-295">操作ジェスチャ イベントは継続的な対話式操作を示します。</span><span class="sxs-lookup"><span data-stu-id="2239a-295">Manipulation gesture events indicate an ongoing interaction.</span></span> <span data-ttu-id="2239a-296">操作ジェスチャ イベントはユーザーが要素にタッチしたときに発生し、ユーザーが指を離すか操作が取り消されるまで続きます。</span><span class="sxs-lookup"><span data-stu-id="2239a-296">They start firing when the user touches an element and continue until the user lifts their finger(s), or the manipulation is canceled.</span></span>

- <span data-ttu-id="2239a-297">操作イベントには、ズーム、パン、回転などのマルチタッチ操作や、ドラッグなどの慣性と速度データを使った操作の場合は、操作イベントを使います。</span><span class="sxs-lookup"><span data-stu-id="2239a-297">Manipulation events include multi-touch interactions such as zooming, panning, or rotating, and interactions that use inertia and velocity data such as dragging.</span></span> <span data-ttu-id="2239a-298">(操作イベントで提供される情報は、実行された操作のフォームを識別するのではなく、位置、変換デルタ、速度などのタッチ データを含みます。)</span><span class="sxs-lookup"><span data-stu-id="2239a-298">(The information provided by the manipulation events doesn't identify the interaction, but rather provides data such as position, translation delta, and velocity.)</span></span>

- <span data-ttu-id="2239a-299">PointerPressed や PointerMoved などのポインター イベントは、ポインター モーションや、押すイベントと離すイベントの識別機能などの下位レベルの詳細を提供します。</span><span class="sxs-lookup"><span data-stu-id="2239a-299">Pointer events such as PointerPressed and PointerMoved provide low-level details for each touch contact, including pointer motion and the ability to distinguish press and release events.</span></span>

<span data-ttu-id="2239a-300">Windows でサポートされている対話式操作のエクスペリエンスは複合的であるため、単にタッチ入力のサポートに依存するのではなく、マウス スタイル UI コマンドまたはアフォーダンスも提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2239a-300">Because of the convergence of interaction experiences supported by Windows, we recommend also providing mouse-style UI commands or affordances rather than relying solely on support for touch input.</span></span> <span data-ttu-id="2239a-301">たとえば、"前へ" ボタンと "次へ" ボタン (または "+" ボタンと "-" ボタン) を使ってコンテンツのページをフリップしたり、オブジェクトを回転、サイズ変更、ズームしたりできるようにします。</span><span class="sxs-lookup"><span data-stu-id="2239a-301">For example, use previous and next (or + and -) buttons to let users flip through pages of content, or rotate, resize, and zoom objects.</span></span>


## <a name="gamepadcontroller"></a><span data-ttu-id="2239a-302">ゲームパッド/コントローラー</span><span class="sxs-lookup"><span data-stu-id="2239a-302">Gamepad/Controller</span></span>

<span data-ttu-id="2239a-303">ゲームパッド/コントローラーは、通常はゲーム専用の高度に専門化されたデバイスです。</span><span class="sxs-lookup"><span data-stu-id="2239a-303">The gamepad/controller is a highly specialized device typically dedicated to playing games.</span></span> <span data-ttu-id="2239a-304">ただし、基本的なキーボード入力をエミュレートするためにも使われ、キーボードとよく似た UI ナビゲーション エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="2239a-304">However, it is also used for to emulate basic keyboard input and provides a UI navigation experience very similar to the keyboard.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-305">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-305">Device support</span></span>

-   <span data-ttu-id="2239a-306">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-306">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-307">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-307">IoT</span></span>
-   <span data-ttu-id="2239a-308">Xbox</span><span class="sxs-lookup"><span data-stu-id="2239a-308">Xbox</span></span>

![コントローラー](images/input-interactions/icons-controller01.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-310">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-310">Typical usage</span></span>

<span data-ttu-id="2239a-311">ゲームをプレイしたり、特殊なコンソールを操作したりします。</span><span class="sxs-lookup"><span data-stu-id="2239a-311">Playing games and interacting with a specialized console.</span></span>


## <a name="multiple-inputs"></a><span data-ttu-id="2239a-312">複数の入力</span><span class="sxs-lookup"><span data-stu-id="2239a-312">Multiple inputs</span></span>

<span data-ttu-id="2239a-313">できるだけ多くのユーザーやデバイスに対応し、可能な限り多くの入力の種類 (ジェスチャ、音声、タッチ、タッチパッド、マウス、キーボード) と連携するようにアプリを設計すると、最大の柔軟性、操作性、ユーザー補助が得られます。</span><span class="sxs-lookup"><span data-stu-id="2239a-313">Accommodating as many users and devices as possible and designing your apps to work with as many input types (gesture, speech, touch, touchpad, mouse, and keyboard) as possible maximizes flexibility, usability, and accessibility.</span></span>

### <a name="device-support"></a><span data-ttu-id="2239a-314">デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="2239a-314">Device support</span></span>

-   <span data-ttu-id="2239a-315">電話とファブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-315">Phones and phablets</span></span>
-   <span data-ttu-id="2239a-316">タブレット</span><span class="sxs-lookup"><span data-stu-id="2239a-316">Tablet</span></span>
-   <span data-ttu-id="2239a-317">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="2239a-317">PCs and laptops</span></span>
-   <span data-ttu-id="2239a-318">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="2239a-318">Surface Hub</span></span>
-   <span data-ttu-id="2239a-319">IoT</span><span class="sxs-lookup"><span data-stu-id="2239a-319">IoT</span></span>
-   <span data-ttu-id="2239a-320">Xbox</span><span class="sxs-lookup"><span data-stu-id="2239a-320">Xbox</span></span>
-   <span data-ttu-id="2239a-321">HoloLens</span><span class="sxs-lookup"><span data-stu-id="2239a-321">HoloLens</span></span>

![複数の入力](images/input-interactions/icons-inputdevices03-vertical.png)

### <a name="typical-usage"></a><span data-ttu-id="2239a-323">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="2239a-323">Typical usage</span></span>

<span data-ttu-id="2239a-324">人がお互いにコミュニケーションをとる際に音声とジェスチャを組み合わせて使うように、アプリの操作では、複数の種類とモードの入力を使うと便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-324">Just as people use a combination of voice and gesture when communicating with each other, multiple types and modes of input can also be useful when interacting with an app.</span></span> <span data-ttu-id="2239a-325">ただし、これら複合的な操作は混乱を招くこともあるため、できる限り直感的で自然である必要があります。</span><span class="sxs-lookup"><span data-stu-id="2239a-325">However, these combined interactions need to be as intuitive and natural as possible as they can also create a very confusing experience.</span></span>





 

 
