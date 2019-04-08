---
Description: このトピックでは、新しい Windows UI の選択とテキスト、イメージ、およびコントロールの操作を記述し、UWP アプリでこれらの新しい選択と操作メカニズムを使用すると見なす必要があるユーザー エクスペリエンス ガイドラインを提供します。
title: テキストと画像の選択
ms.assetid: d973ffd8-602e-47b5-ab0b-4b2a964ec53d
label: Selecting text and images
template: detail.hbs
keywords: キーボード, テキスト, 入力, ユーザーの操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9679e6e658e7fa1eb50b41331e7e59ec2115fc14
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612507"
---
# <a name="selecting-text-and-images"></a><span data-ttu-id="e3601-104">テキストと画像の選択</span><span class="sxs-lookup"><span data-stu-id="e3601-104">Selecting text and images</span></span>


<span data-ttu-id="e3601-105">この記事では、テキスト、画像、コントロールの選択と操作について説明し、アプリでこれらのメカニズムを使うときに考慮する必要があるユーザー エクスペリエンスのガイドラインを示します。</span><span class="sxs-lookup"><span data-stu-id="e3601-105">This article describes selecting and manipulating text, images, and controls and provides user experience guidelines that should be considered when using these mechanisms in your apps.</span></span>

> <span data-ttu-id="e3601-106">**重要な API**:[**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)、 [ **Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)</span><span class="sxs-lookup"><span data-stu-id="e3601-106">**Important APIs**: [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994), [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)</span></span>
 


## <a name="dos-and-donts"></a><span data-ttu-id="e3601-107">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="e3601-107">Dos and don'ts</span></span>


-   <span data-ttu-id="e3601-108">独自のグリッパー UI を実装する場合は、フォント グリフを使います。</span><span class="sxs-lookup"><span data-stu-id="e3601-108">Use font glyphs when implementing your own gripper UI.</span></span> <span data-ttu-id="e3601-109">グリッパーは、システム全体で利用できる 2 つの Segoe UI フォントを組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="e3601-109">The gripper is a combination of two Segoe UI fonts that are available system-wide.</span></span> <span data-ttu-id="e3601-110">フォント リソースを使うと、さまざまな dpi におけるレンダリングの問題が軽減され、さまざまな UI 表示スケール プラトーに対応できます。</span><span class="sxs-lookup"><span data-stu-id="e3601-110">Using font resources simplifies rendering issues at different dpi and works well with the various UI scaling plateaus.</span></span> <span data-ttu-id="e3601-111">独自のグリッパーを実装する場合は、どのグリッパーにも次の UI の特性を持たせてください。</span><span class="sxs-lookup"><span data-stu-id="e3601-111">When implementing your own grippers, they should share the following UI traits:</span></span>

    -   <span data-ttu-id="e3601-112">円の図形</span><span class="sxs-lookup"><span data-stu-id="e3601-112">Circular shape</span></span>
    -   <span data-ttu-id="e3601-113">背景に隠れず表示される</span><span class="sxs-lookup"><span data-stu-id="e3601-113">Visible against any background</span></span>
    -   <span data-ttu-id="e3601-114">一貫したサイズ</span><span class="sxs-lookup"><span data-stu-id="e3601-114">Consistent size</span></span>
-   <span data-ttu-id="e3601-115">グリッパー UI が収まるように、選択可能なコンテンツの周囲に余白を設けます。</span><span class="sxs-lookup"><span data-stu-id="e3601-115">Provide a margin around the selectable content to accommodate the gripper UI.</span></span> <span data-ttu-id="e3601-116">パンとスクロールに対応していない領域でテキストを選択できる場合は、テキスト領域の左右に 1/2 のグリッパー余白を設け、テキスト領域の上下に 1 つのグリッパーの高さを設けます (次の図を参照)。</span><span class="sxs-lookup"><span data-stu-id="e3601-116">If your app enables text selection in a region that doesn't pan/scroll, allow a 1/2 gripper margin on the left and right sides of the text area and 1 gripper height on the top and bottom sides of the text area (as shown in the following images).</span></span> <span data-ttu-id="e3601-117">こうすることで、グリッパー UI 全体がユーザーに表示されるため、端に基づく他の UI が誤って操作されるのを防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="e3601-117">This ensures that the entire gripper UI is exposed to the user and minimizes unintended interactions with other edge-based UI.</span></span>

    ![テキスト選択グリッパーの余白](images/textselection-gripper-margins.png)

-   <span data-ttu-id="e3601-119">対話式操作中はグリッパー UI を非表示にします。</span><span class="sxs-lookup"><span data-stu-id="e3601-119">Hide grippers UI during interaction.</span></span> <span data-ttu-id="e3601-120">対話式操作中にグリッパーによって領域がふさがれないようにします。</span><span class="sxs-lookup"><span data-stu-id="e3601-120">Eliminates occlusion by the grippers during the interaction.</span></span> <span data-ttu-id="e3601-121">これは、グリッパーが指で完全に隠れない場合や、テキスト選択グリッパーが複数存在する場合に有効です。</span><span class="sxs-lookup"><span data-stu-id="e3601-121">This is useful when a gripper isn't completely obscured by the finger or there are multiple text selection grippers.</span></span> <span data-ttu-id="e3601-122">これにより、子ウィンドウを表示しているときは、視覚的なアーティファクトが取り除かれます。</span><span class="sxs-lookup"><span data-stu-id="e3601-122">This eliminates visual artifacts when displaying child windows.</span></span>

-   <span data-ttu-id="e3601-123">コントロール、ラベル、画像、独自のコンテンツなどの UI 要素は選択できないようにします。</span><span class="sxs-lookup"><span data-stu-id="e3601-123">Don't allow selection of UI elements such as controls, labels, images, proprietary content, and so on.</span></span> <span data-ttu-id="e3601-124">通常、Windows アプリケーションでは、特定のコントロール内でのみ選択できます。</span><span class="sxs-lookup"><span data-stu-id="e3601-124">Typically, Windows applications allow selection only within specific controls.</span></span> <span data-ttu-id="e3601-125">ボタン、ラベル、ロゴなどのコントロールは選択できません。</span><span class="sxs-lookup"><span data-stu-id="e3601-125">Controls such as buttons, labels, and logos are not selectable.</span></span> <span data-ttu-id="e3601-126">選択がアプリにとって問題になるかどうかを評価し、問題になる場合は、選択を禁止する UI 領域を特定します。</span><span class="sxs-lookup"><span data-stu-id="e3601-126">Assess whether selection is an issue for your app and, if so, identify the areas of the UI where selection should be prohibited.</span></span> 

## <a name="additional-usage-guidance"></a><span data-ttu-id="e3601-127">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="e3601-127">Additional usage guidance</span></span>


<span data-ttu-id="e3601-128">テキストの選択と操作は、タッチ操作で導入されたユーザー エクスペリエンスの問題の影響を特に受けやすくなっています。</span><span class="sxs-lookup"><span data-stu-id="e3601-128">Text selection and manipulation is particularly susceptible to user experience challenges introduced by touch interactions.</span></span> <span data-ttu-id="e3601-129">マウス、ペン/スタイラス、キーボード入力は非常に細かく制御されます。1 回のマウスのクリックまたはペン/スタイラスの接触は 1 ピクセルにマッピングされ、キーは押されるか、放されます。</span><span class="sxs-lookup"><span data-stu-id="e3601-129">Mouse, pen/stylus, and keyboard input are highly granular: a mouse click or pen/stylus contact is typically mapped to a single pixel, and a key is pressed or not pressed.</span></span> <span data-ttu-id="e3601-130">タッチ入力は細かく制御されません。指先の表面全体を、画面上の特定の x-y の位置にマッピングしてテキスト キャレットを正確に配置することは困難です。</span><span class="sxs-lookup"><span data-stu-id="e3601-130">Touch input is not granular; it's difficult to map the entire surface of a fingertip to a specific x-y location on the screen to place a text caret accurately.</span></span>

<span data-ttu-id="e3601-131">**考慮事項と推奨事項**</span><span class="sxs-lookup"><span data-stu-id="e3601-131">**Considerations and recommendations**</span></span>

<span data-ttu-id="e3601-132">Windows の言語フレームワークを通じて公開される組み込みのコントロールを使用すると、選択、および操作の動作を含む、プラットフォームの完全なユーザー操作のエクスペリエンスを提供するアプリを構築できます。</span><span class="sxs-lookup"><span data-stu-id="e3601-132">Use the built-in controls exposed through the language frameworks in Windows to build apps that provide the full platform user interaction experience, including selection and manipulation behaviors.</span></span> <span data-ttu-id="e3601-133">ビルトイン コントロールの対話式操作の機能は、大部分の UWP アプリにとって十分なものです。</span><span class="sxs-lookup"><span data-stu-id="e3601-133">You'll find the interaction functionality of the built-in controls sufficient for the majority of UWP apps.</span></span>

<span data-ttu-id="e3601-134">標準の UWP テキスト コントロールを使う場合、このトピックで説明した選択の動作と視覚効果はカスタマイズできません。</span><span class="sxs-lookup"><span data-stu-id="e3601-134">When using standard UWP text controls, the selection behaviors and visuals described in this topic cannot be customized.</span></span>

<span data-ttu-id="e3601-135">**テキストの選択**</span><span class="sxs-lookup"><span data-stu-id="e3601-135">**Text selection**</span></span>

<span data-ttu-id="e3601-136">アプリは、テキスト選択をサポートするカスタム UI を必要とする場合は、ここで説明する Windows の選択動作を実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e3601-136">If your app requires a custom UI that supports text selection, we recommend that you follow the Windows selection behaviors described here.</span></span>

<span data-ttu-id="e3601-137">**編集可能なとが編集可能なコンテンツ**</span><span class="sxs-lookup"><span data-stu-id="e3601-137">**Editable and non-editable content**</span></span>


<span data-ttu-id="e3601-138">タッチでは、選択操作は主に挿入カーソルの設定や単語の選択を行うタップ、選択範囲の変更を行うスライドなどのジェスチャを通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="e3601-138">With touch, selection interactions are performed primarily through gestures such as a tap to set an insertion cursor or select a word, and a slide to modify a selection.</span></span> <span data-ttu-id="e3601-139">その他の Windows では、タッチの操作と時間指定の相互作用は、キーを押してに制限されます情報 UI を表示するジェスチャを保持します。</span><span class="sxs-lookup"><span data-stu-id="e3601-139">As with other Windows touch interactions, timed interactions are limited to the press and hold gesture to display informational UI.</span></span> <span data-ttu-id="e3601-140">詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e3601-140">For more information, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md).</span></span>

<span data-ttu-id="e3601-141">Windows では、編集可能にし、編集可能な選択範囲の相互作用の 2 つの状態を認識し、UI の選択、フィードバック、および機能を適宜調整されます。</span><span class="sxs-lookup"><span data-stu-id="e3601-141">Windows recognizes two possible states for selection interactions, editable and non-editable, and adjusts selection UI, feedback, and functionality accordingly.</span></span>

<span data-ttu-id="e3601-142">**編集可能なコンテンツ**</span><span class="sxs-lookup"><span data-stu-id="e3601-142">**Editable content**</span></span>

<span data-ttu-id="e3601-143">単語内の左半分をタップすると、単語のすぐ左にカーソルが配置されます。単語内の右半分をタップすると、単語のすぐ右にカーソルが配置されます。</span><span class="sxs-lookup"><span data-stu-id="e3601-143">Tapping within the left half of a word places the cursor to the immediate left of the word, while tapping within the right half places the cursor to the immediate right of the word.</span></span>

<span data-ttu-id="e3601-144">次の図は、単語の先頭または終わりの近くでタップして、グリッパーを持つ最初の挿入カーソルを配置する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e3601-144">The following image demonstrates how to place an initial insertion cursor with gripper by tapping near the beginning or ending of a word.</span></span>

![単語の左側をタップ (または長押し) するとその単語の先頭にキャレットとグリッパーが配置されます。](images/textselection-place-caret.png)

<span data-ttu-id="e3601-147">次の図は、グリッパーをドラッグして選択範囲を調整する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="e3601-147">The following image demonstrates how to adjust a selection by dragging the gripper.</span></span>

![グリッパーをいずれかの方向にドラッグして選択範囲を調整します (最初のグリッパーは固定されたままで、2 つ目のグリッパーが表示されます)。](images/adjust-selection.png)

<span data-ttu-id="e3601-150">次の図は、選択範囲内またはグリッパー上でタップしてコンテキスト メニューを呼び出す方法を示しています (長押しを使うこともできます)。</span><span class="sxs-lookup"><span data-stu-id="e3601-150">The following images demonstrate how to invoke the context menu by tapping within the selection or on a gripper (press and hold can also be used).</span></span>

![選択範囲内またはグリッパー上でタップ (または長押し) してコンテキスト メニューを呼び出します。](images/textselection-show-context.png)

<span data-ttu-id="e3601-152">**注**  これらのインタラクションは、スペル ミスの単語の場合に、やや異なります。</span><span class="sxs-lookup"><span data-stu-id="e3601-152">**Note**  These interactions vary somewhat in the case of a misspelled word.</span></span> <span data-ttu-id="e3601-153">綴りに誤りがあるとしてマークされている単語をタップすると、単語全体が強調表示されて、スペル候補のコンテキスト メニューが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="e3601-153">Tapping a word that is marked as misspelled will both highlight the entire word and invoke the suggested spelling context menu.</span></span>

 

<span data-ttu-id="e3601-154">**非編集可能なコンテンツ**</span><span class="sxs-lookup"><span data-stu-id="e3601-154">**Non-editable content**</span></span>

<span data-ttu-id="e3601-155">次の図は、単語内でタップして単語を選ぶ方法を示しています (最初の選択にスペースは含まれていません)。</span><span class="sxs-lookup"><span data-stu-id="e3601-155">The following image demonstrates how to select a word by tapping within the word (no spaces are included in the initial selection).</span></span>

![単語内でタップしてその単語を選びます (最初の選択にスペースは含まれていません)。](images/select-word.png)

<span data-ttu-id="e3601-157">編集可能なテキストと同じ手順に従って、選択範囲を調整し、コンテキスト メニューを表示します。</span><span class="sxs-lookup"><span data-stu-id="e3601-157">Follow the same procedures as for editable text to adjust the selection and display the context menu.</span></span>

<span data-ttu-id="e3601-158">**オブジェクトの操作**</span><span class="sxs-lookup"><span data-stu-id="e3601-158">**Object manipulation**</span></span>

<span data-ttu-id="e3601-159">UWP アプリでカスタム オブジェクト操作を実装する場合は、できる限り、テキストの選択と同じ (類似する) グリッパー リソースを使います。</span><span class="sxs-lookup"><span data-stu-id="e3601-159">Wherever possible, use the same (or similar) gripper resources as text selection when implementing custom object manipulation in a UWP app.</span></span> <span data-ttu-id="e3601-160">そうすれば、プラットフォーム間で操作エクスペリエンスの一貫性が保たれます。</span><span class="sxs-lookup"><span data-stu-id="e3601-160">This helps provide a consistent interaction experience across the platform.</span></span>

<span data-ttu-id="e3601-161">たとえば、次の図に示すように、グリッパーは、サイズ変更とトリミングをサポートする画像処理アプリや、調節可能なプログレス バーを備えたメディア プレーヤー アプリでも利用できます。</span><span class="sxs-lookup"><span data-stu-id="e3601-161">For example, grippers can also be used in image processing apps that support resizing and cropping or media player apps that provide adjustable progress bars, as shown in the following images.</span></span>

![プログレス グリッパーを備えたメディア プレーヤー](images/gripper-mediaplayer.png)

<span data-ttu-id="e3601-163">*調整可能な進行状況バーでメディア プレーヤー。*</span><span class="sxs-lookup"><span data-stu-id="e3601-163">*Media player with adjustable progress bar.*</span></span>

![トリミング グリッパーが表示された図](images/gripper-imagemanip.png)

<span data-ttu-id="e3601-165">*イメージ エディター グリッパーをトリミングします。*</span><span class="sxs-lookup"><span data-stu-id="e3601-165">*Image editor with cropping grippers.*</span></span>

## <a name="related-articles"></a><span data-ttu-id="e3601-166">関連記事</span><span class="sxs-lookup"><span data-stu-id="e3601-166">Related articles</span></span>



<span data-ttu-id="e3601-167">**開発者向け**</span><span class="sxs-lookup"><span data-stu-id="e3601-167">**For developers**</span></span>
* [<span data-ttu-id="e3601-168">カスタム ユーザー操作</span><span class="sxs-lookup"><span data-stu-id="e3601-168">Custom user interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185599)

<span data-ttu-id="e3601-169">**サンプル**</span><span class="sxs-lookup"><span data-stu-id="e3601-169">**Samples**</span></span>
* [<span data-ttu-id="e3601-170">基本的な入力サンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-170">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="e3601-171">低待機時間の入力サンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-171">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="e3601-172">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-172">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="e3601-173">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-173">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

<span data-ttu-id="e3601-174">**サンプルのアーカイブ**</span><span class="sxs-lookup"><span data-stu-id="e3601-174">**Archive samples**</span></span>
* [<span data-ttu-id="e3601-175">入力:XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-175">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="e3601-176">入力:デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-176">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="e3601-177">入力:タッチ ヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-177">Input: Touch hit testing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="e3601-178">XAML のスクロール、パン、ズームのサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-178">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="e3601-179">入力:簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-179">Input: Simplified ink sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="e3601-180">入力:Windows 8 のジェスチャのサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-180">Input: Windows 8 gestures sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="e3601-181">入力:操作とジェスチャ (C++) のサンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-181">Input: Manipulations and gestures (C++) sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="e3601-182">DirectX のタッチ入力サンプル</span><span class="sxs-lookup"><span data-stu-id="e3601-182">DirectX touch input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 




