---
Description: This topic describes the new Windows UI for selecting and manipulating text, images, and controls and provides user experience guidelines that should be considered when using these new selection and manipulation mechanisms in your UWP app.
title: テキストと画像の選択
ms.assetid: d973ffd8-602e-47b5-ab0b-4b2a964ec53d
label: Selecting text and images
template: detail.hbs
keywords: キーボード, テキスト, 入力, ユーザーの操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9679e6e658e7fa1eb50b41331e7e59ec2115fc14
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8900502"
---
# <a name="selecting-text-and-images"></a><span data-ttu-id="080a9-103">テキストと画像の選択</span><span class="sxs-lookup"><span data-stu-id="080a9-103">Selecting text and images</span></span>


<span data-ttu-id="080a9-104">この記事では、テキスト、画像、コントロールの選択と操作について説明し、アプリでこれらのメカニズムを使うときに考慮する必要があるユーザー エクスペリエンスのガイドラインを示します。</span><span class="sxs-lookup"><span data-stu-id="080a9-104">This article describes selecting and manipulating text, images, and controls and provides user experience guidelines that should be considered when using these mechanisms in your apps.</span></span>

> <span data-ttu-id="080a9-105">**重要な API**: [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994)、[**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)</span><span class="sxs-lookup"><span data-stu-id="080a9-105">**Important APIs**: [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br227994), [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)</span></span>
 


## <a name="dos-and-donts"></a><span data-ttu-id="080a9-106">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="080a9-106">Dos and don'ts</span></span>


-   <span data-ttu-id="080a9-107">独自のグリッパー UI を実装する場合は、フォント グリフを使います。</span><span class="sxs-lookup"><span data-stu-id="080a9-107">Use font glyphs when implementing your own gripper UI.</span></span> <span data-ttu-id="080a9-108">グリッパーは、システム全体で利用できる 2 つの Segoe UI フォントを組み合わせたものです。</span><span class="sxs-lookup"><span data-stu-id="080a9-108">The gripper is a combination of two Segoe UI fonts that are available system-wide.</span></span> <span data-ttu-id="080a9-109">フォント リソースを使うと、さまざまな dpi におけるレンダリングの問題が軽減され、さまざまな UI 表示スケール プラトーに対応できます。</span><span class="sxs-lookup"><span data-stu-id="080a9-109">Using font resources simplifies rendering issues at different dpi and works well with the various UI scaling plateaus.</span></span> <span data-ttu-id="080a9-110">独自のグリッパーを実装する場合は、どのグリッパーにも次の UI の特性を持たせてください。</span><span class="sxs-lookup"><span data-stu-id="080a9-110">When implementing your own grippers, they should share the following UI traits:</span></span>

    -   <span data-ttu-id="080a9-111">円の図形</span><span class="sxs-lookup"><span data-stu-id="080a9-111">Circular shape</span></span>
    -   <span data-ttu-id="080a9-112">背景に隠れず表示される</span><span class="sxs-lookup"><span data-stu-id="080a9-112">Visible against any background</span></span>
    -   <span data-ttu-id="080a9-113">一貫したサイズ</span><span class="sxs-lookup"><span data-stu-id="080a9-113">Consistent size</span></span>
-   <span data-ttu-id="080a9-114">グリッパー UI が収まるように、選択可能なコンテンツの周囲に余白を設けます。</span><span class="sxs-lookup"><span data-stu-id="080a9-114">Provide a margin around the selectable content to accommodate the gripper UI.</span></span> <span data-ttu-id="080a9-115">パンとスクロールに対応していない領域でテキストを選択できる場合は、テキスト領域の左右に 1/2 のグリッパー余白を設け、テキスト領域の上下に 1 つのグリッパーの高さを設けます (次の図を参照)。</span><span class="sxs-lookup"><span data-stu-id="080a9-115">If your app enables text selection in a region that doesn't pan/scroll, allow a 1/2 gripper margin on the left and right sides of the text area and 1 gripper height on the top and bottom sides of the text area (as shown in the following images).</span></span> <span data-ttu-id="080a9-116">こうすることで、グリッパー UI 全体がユーザーに表示されるため、端に基づく他の UI が誤って操作されるのを防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="080a9-116">This ensures that the entire gripper UI is exposed to the user and minimizes unintended interactions with other edge-based UI.</span></span>

    ![テキスト選択グリッパーの余白](images/textselection-gripper-margins.png)

-   <span data-ttu-id="080a9-118">対話式操作中はグリッパー UI を非表示にします。</span><span class="sxs-lookup"><span data-stu-id="080a9-118">Hide grippers UI during interaction.</span></span> <span data-ttu-id="080a9-119">対話式操作中にグリッパーによって領域がふさがれないようにします。</span><span class="sxs-lookup"><span data-stu-id="080a9-119">Eliminates occlusion by the grippers during the interaction.</span></span> <span data-ttu-id="080a9-120">これは、グリッパーが指で完全に隠れない場合や、テキスト選択グリッパーが複数存在する場合に有効です。</span><span class="sxs-lookup"><span data-stu-id="080a9-120">This is useful when a gripper isn't completely obscured by the finger or there are multiple text selection grippers.</span></span> <span data-ttu-id="080a9-121">これにより、子ウィンドウを表示しているときは、視覚的なアーティファクトが取り除かれます。</span><span class="sxs-lookup"><span data-stu-id="080a9-121">This eliminates visual artifacts when displaying child windows.</span></span>

-   <span data-ttu-id="080a9-122">コントロール、ラベル、画像、独自のコンテンツなどの UI 要素は選択できないようにします。</span><span class="sxs-lookup"><span data-stu-id="080a9-122">Don't allow selection of UI elements such as controls, labels, images, proprietary content, and so on.</span></span> <span data-ttu-id="080a9-123">通常、Windows アプリケーションでは、特定のコントロール内でのみ選択できます。</span><span class="sxs-lookup"><span data-stu-id="080a9-123">Typically, Windows applications allow selection only within specific controls.</span></span> <span data-ttu-id="080a9-124">ボタン、ラベル、ロゴなどのコントロールは選択できません。</span><span class="sxs-lookup"><span data-stu-id="080a9-124">Controls such as buttons, labels, and logos are not selectable.</span></span> <span data-ttu-id="080a9-125">選択がアプリにとって問題になるかどうかを評価し、問題になる場合は、選択を禁止する UI 領域を特定します。</span><span class="sxs-lookup"><span data-stu-id="080a9-125">Assess whether selection is an issue for your app and, if so, identify the areas of the UI where selection should be prohibited.</span></span> 

## <a name="additional-usage-guidance"></a><span data-ttu-id="080a9-126">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="080a9-126">Additional usage guidance</span></span>


<span data-ttu-id="080a9-127">テキストの選択と操作は、タッチ操作で導入されたユーザー エクスペリエンスの問題の影響を特に受けやすくなっています。</span><span class="sxs-lookup"><span data-stu-id="080a9-127">Text selection and manipulation is particularly susceptible to user experience challenges introduced by touch interactions.</span></span> <span data-ttu-id="080a9-128">マウス、ペン/スタイラス、キーボード入力は非常に細かく制御されます。1 回のマウスのクリックまたはペン/スタイラスの接触は 1 ピクセルにマッピングされ、キーは押されるか、放されます。</span><span class="sxs-lookup"><span data-stu-id="080a9-128">Mouse, pen/stylus, and keyboard input are highly granular: a mouse click or pen/stylus contact is typically mapped to a single pixel, and a key is pressed or not pressed.</span></span> <span data-ttu-id="080a9-129">タッチ入力は細かく制御されません。指先の表面全体を、画面上の特定の x-y の位置にマッピングしてテキスト キャレットを正確に配置することは困難です。</span><span class="sxs-lookup"><span data-stu-id="080a9-129">Touch input is not granular; it's difficult to map the entire surface of a fingertip to a specific x-y location on the screen to place a text caret accurately.</span></span>

**<span data-ttu-id="080a9-130">考慮事項と推奨事項</span><span class="sxs-lookup"><span data-stu-id="080a9-130">Considerations and recommendations</span></span>**

<span data-ttu-id="080a9-131">選択と操作の動作を含む、プラットフォームの完全なユーザー操作エクスペリエンスを提供する Windowsto ビルドのアプリの言語フレームワークによって公開されるビルトイン コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="080a9-131">Use the built-in controls exposed through the language frameworks in Windowsto build apps that provide the full platform user interaction experience, including selection and manipulation behaviors.</span></span> <span data-ttu-id="080a9-132">ビルトイン コントロールの対話式操作の機能は、大部分の UWP アプリにとって十分なものです。</span><span class="sxs-lookup"><span data-stu-id="080a9-132">You'll find the interaction functionality of the built-in controls sufficient for the majority of UWP apps.</span></span>

<span data-ttu-id="080a9-133">標準の UWP テキスト コントロールを使う場合、このトピックで説明した選択の動作と視覚効果はカスタマイズできません。</span><span class="sxs-lookup"><span data-stu-id="080a9-133">When using standard UWP text controls, the selection behaviors and visuals described in this topic cannot be customized.</span></span>

**<span data-ttu-id="080a9-134">テキスト選択</span><span class="sxs-lookup"><span data-stu-id="080a9-134">Text selection</span></span>**

<span data-ttu-id="080a9-135">アプリでは、カスタムの UI テキストの選択をサポートしている必要がある場合は、ここで説明した Windowsselection 動作に従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="080a9-135">If your app requires a custom UI that supports text selection, we recommend that you follow the Windowsselection behaviors described here.</span></span>

**<span data-ttu-id="080a9-136">編集可能なコンテンツと編集不可のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="080a9-136">Editable and non-editable content</span></span>**


<span data-ttu-id="080a9-137">タッチでは、選択操作は主に挿入カーソルの設定や単語の選択を行うタップ、選択範囲の変更を行うスライドなどのジェスチャを通じて実行されます。</span><span class="sxs-lookup"><span data-stu-id="080a9-137">With touch, selection interactions are performed primarily through gestures such as a tap to set an insertion cursor or select a word, and a slide to modify a selection.</span></span> <span data-ttu-id="080a9-138">同様に Windowstouch 他の対話式操作時間制限のある対話式操作に制限は情報 UI を表示するジェスチャを保持します。</span><span class="sxs-lookup"><span data-stu-id="080a9-138">As with other Windowstouch interactions, timed interactions are limited to the press and hold gesture to display informational UI.</span></span> <span data-ttu-id="080a9-139">詳しくは、「[視覚的なフィードバックのガイドライン](guidelines-for-visualfeedback.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="080a9-139">For more information, see [Guidelines for visual feedback](guidelines-for-visualfeedback.md).</span></span>

<span data-ttu-id="080a9-140">Windowsrecognizes 2 つの可能な状態で、選択操作で編集可能なと編集不可し、それに応じて選択 UI、フィードバック、および機能を調整します。</span><span class="sxs-lookup"><span data-stu-id="080a9-140">Windowsrecognizes two possible states for selection interactions, editable and non-editable, and adjusts selection UI, feedback, and functionality accordingly.</span></span>

**<span data-ttu-id="080a9-141">編集可能なコンテンツ</span><span class="sxs-lookup"><span data-stu-id="080a9-141">Editable content</span></span>**

<span data-ttu-id="080a9-142">単語内の左半分をタップすると、単語のすぐ左にカーソルが配置されます。単語内の右半分をタップすると、単語のすぐ右にカーソルが配置されます。</span><span class="sxs-lookup"><span data-stu-id="080a9-142">Tapping within the left half of a word places the cursor to the immediate left of the word, while tapping within the right half places the cursor to the immediate right of the word.</span></span>

<span data-ttu-id="080a9-143">次の図は、単語の先頭または終わりの近くでタップして、グリッパーを持つ最初の挿入カーソルを配置する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="080a9-143">The following image demonstrates how to place an initial insertion cursor with gripper by tapping near the beginning or ending of a word.</span></span>

![単語の左側をタップ (または長押し) するとその単語の先頭にキャレットとグリッパーが配置されます。](images/textselection-place-caret.png)

<span data-ttu-id="080a9-146">次の図は、グリッパーをドラッグして選択範囲を調整する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="080a9-146">The following image demonstrates how to adjust a selection by dragging the gripper.</span></span>

![グリッパーをいずれかの方向にドラッグして選択範囲を調整します (最初のグリッパーは固定されたままで、2 つ目のグリッパーが表示されます)。](images/adjust-selection.png)

<span data-ttu-id="080a9-149">次の図は、選択範囲内またはグリッパー上でタップしてコンテキスト メニューを呼び出す方法を示しています (長押しを使うこともできます)。</span><span class="sxs-lookup"><span data-stu-id="080a9-149">The following images demonstrate how to invoke the context menu by tapping within the selection or on a gripper (press and hold can also be used).</span></span>

![選択範囲内またはグリッパー上でタップ (または長押し) してコンテキスト メニューを呼び出します。](images/textselection-show-context.png)

<span data-ttu-id="080a9-151">**注:** スペル ミスの場合はこのような操作が異なります。</span><span class="sxs-lookup"><span data-stu-id="080a9-151">**Note**These interactions vary somewhat in the case of a misspelled word.</span></span> <span data-ttu-id="080a9-152">綴りに誤りがあるとしてマークされている単語をタップすると、単語全体が強調表示されて、スペル候補のコンテキスト メニューが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="080a9-152">Tapping a word that is marked as misspelled will both highlight the entire word and invoke the suggested spelling context menu.</span></span>

 

**<span data-ttu-id="080a9-153">編集不可のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="080a9-153">Non-editable content</span></span>**

<span data-ttu-id="080a9-154">次の図は、単語内でタップして単語を選ぶ方法を示しています (最初の選択にスペースは含まれていません)。</span><span class="sxs-lookup"><span data-stu-id="080a9-154">The following image demonstrates how to select a word by tapping within the word (no spaces are included in the initial selection).</span></span>

![単語内でタップしてその単語を選びます (最初の選択にスペースは含まれていません)。](images/select-word.png)

<span data-ttu-id="080a9-156">編集可能なテキストと同じ手順に従って、選択範囲を調整し、コンテキスト メニューを表示します。</span><span class="sxs-lookup"><span data-stu-id="080a9-156">Follow the same procedures as for editable text to adjust the selection and display the context menu.</span></span>

**<span data-ttu-id="080a9-157">オブジェクトの操作</span><span class="sxs-lookup"><span data-stu-id="080a9-157">Object manipulation</span></span>**

<span data-ttu-id="080a9-158">UWP アプリでカスタム オブジェクト操作を実装する場合は、できる限り、テキストの選択と同じ (類似する) グリッパー リソースを使います。</span><span class="sxs-lookup"><span data-stu-id="080a9-158">Wherever possible, use the same (or similar) gripper resources as text selection when implementing custom object manipulation in a UWP app.</span></span> <span data-ttu-id="080a9-159">そうすれば、プラットフォーム間で操作エクスペリエンスの一貫性が保たれます。</span><span class="sxs-lookup"><span data-stu-id="080a9-159">This helps provide a consistent interaction experience across the platform.</span></span>

<span data-ttu-id="080a9-160">たとえば、次の図に示すように、グリッパーは、サイズ変更とトリミングをサポートする画像処理アプリや、調節可能なプログレス バーを備えたメディア プレーヤー アプリでも利用できます。</span><span class="sxs-lookup"><span data-stu-id="080a9-160">For example, grippers can also be used in image processing apps that support resizing and cropping or media player apps that provide adjustable progress bars, as shown in the following images.</span></span>

![プログレス グリッパーを備えたメディア プレーヤー](images/gripper-mediaplayer.png)

*<span data-ttu-id="080a9-162">調節可能なプログレス バーを備えたメディア プレーヤーです。</span><span class="sxs-lookup"><span data-stu-id="080a9-162">Media player with adjustable progress bar.</span></span>*

![トリミング グリッパーが表示された図](images/gripper-imagemanip.png)

*<span data-ttu-id="080a9-164">トリミング グリッパーが表示された画像エディターです。</span><span class="sxs-lookup"><span data-stu-id="080a9-164">Image editor with cropping grippers.</span></span>*

## <a name="related-articles"></a><span data-ttu-id="080a9-165">関連記事</span><span class="sxs-lookup"><span data-stu-id="080a9-165">Related articles</span></span>



**<span data-ttu-id="080a9-166">開発者向け</span><span class="sxs-lookup"><span data-stu-id="080a9-166">For developers</span></span>**
* [<span data-ttu-id="080a9-167">カスタム ユーザー操作</span><span class="sxs-lookup"><span data-stu-id="080a9-167">Custom user interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/mt185599)

**<span data-ttu-id="080a9-168">サンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-168">Samples</span></span>**
* [<span data-ttu-id="080a9-169">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-169">Basic input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="080a9-170">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-170">Low latency input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="080a9-171">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-171">User interaction mode sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [<span data-ttu-id="080a9-172">フォーカスの視覚効果のサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-172">Focus visuals sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=619895)

**<span data-ttu-id="080a9-173">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="080a9-173">Archive samples</span></span>**
* [<span data-ttu-id="080a9-174">入力: XAML ユーザー入力イベントのサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-174">Input: XAML user input events sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [<span data-ttu-id="080a9-175">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-175">Input: Device capabilities sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [<span data-ttu-id="080a9-176">入力: タッチのヒット テストのサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-176">Input: Touch hit testing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231590)
* [<span data-ttu-id="080a9-177">XAML のスクロール、パン、ズームのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="080a9-177">XAML scrolling, panning, and zooming sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [<span data-ttu-id="080a9-178">入力: 簡略化されたインクのサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-178">Input: Simplified ink sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246570)
* [<span data-ttu-id="080a9-179">入力: Windows 8 のジェスチャのサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="080a9-179">Input: Windows 8 gestures sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=264995)
* [<span data-ttu-id="080a9-180">入力: 操作とジェスチャ (C++) のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="080a9-180">Input: Manipulations and gestures (C++) sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231605)
* [<span data-ttu-id="080a9-181">DirectX タッチ入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="080a9-181">DirectX touch input sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=231627)
 

 




