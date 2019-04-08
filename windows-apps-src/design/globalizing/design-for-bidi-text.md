---
Description: アプリを設計する双方向のテキストのサポート (BiDi) を提供して、左から右 (LTR) と右から左 (RTL) には、通常のアルファベットのさまざまな種類のシステムを記述からスクリプトを組み合わせることができます。
title: 双方向テキストに対応したアプリを設計する
template: detail.hbs
ms.date: 11/10/2017
ms.topic: article
keywords: Windows 10, UWP, グローバリゼーション, ローカライズの可否, ローカライズ, RTL, LTR
ms.localizationpriority: medium
ms.openlocfilehash: 66a158a96fcab5391030f4517b6420ba4585bf04
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641127"
---
# <a name="design-your-app-for-bidirectional-text"></a><span data-ttu-id="23610-104">双方向テキストに対応したアプリを設計する</span><span class="sxs-lookup"><span data-stu-id="23610-104">Design your app for bidirectional text</span></span>

<span data-ttu-id="23610-105">通常はさまざまな種類のアルファベットを含む、右から左方向 (RTL) および左から右方向 (LTR) 書記体系のスクリプトを組み合わせることができるように、双方向テキスト サポート (BiDi) を備えたアプリを設計します。</span><span class="sxs-lookup"><span data-stu-id="23610-105">Design your app to provide bidirectional text support (BiDi) so that you can combine script from right to left (RTL) and left to right (LTR) writing systems, which generally contain different types of alphabets.</span></span>

<span data-ttu-id="23610-106">中東、中央アジアおよび南アジア、アフリカで使用される言語のように、右から左への書記体系には、独自の設計要件があります。</span><span class="sxs-lookup"><span data-stu-id="23610-106">Right-to-left writing systems, such as those used in the Middle East, Central and South Asia, and in Africa, have unique design requirements.</span></span> <span data-ttu-id="23610-107">これらの書記体系には双方向テキスト サポート (BiDi) が必要です。</span><span class="sxs-lookup"><span data-stu-id="23610-107">These writing systems require bidirectional text support (BiDi).</span></span> <span data-ttu-id="23610-108">BiDi サポートは、右から左 (RTL) または左から右 (LTR) の順序のテキスト レイアウトを入力して表示する機能です。</span><span class="sxs-lookup"><span data-stu-id="23610-108">BiDi support is the ability to input and display text layout in either right to left (RTL) or left to right (LTR) order.</span></span>

<span data-ttu-id="23610-109">Windows には合計 9 種類の BiDi 言語が含まれています。</span><span class="sxs-lookup"><span data-stu-id="23610-109">A total of nine BiDi languages are included with Windows.</span></span>
- <span data-ttu-id="23610-110">完全にローカライズされた 2 つの言語。</span><span class="sxs-lookup"><span data-stu-id="23610-110">Two fully localized languages.</span></span> <span data-ttu-id="23610-111">アラビア語とヘブライ語。</span><span class="sxs-lookup"><span data-stu-id="23610-111">Arabic, and Hebrew.</span></span>
- <span data-ttu-id="23610-112">新興市場向けの 7 種類の言語インターフェイス パック。</span><span class="sxs-lookup"><span data-stu-id="23610-112">Seven Language Interface Packs for emerging markets.</span></span> <span data-ttu-id="23610-113">ペルシャ語、ウルドゥー語、ダリー語、中央クルド語、シンド語、パンジャーブ語 (パキスタン)、ウイグル語。</span><span class="sxs-lookup"><span data-stu-id="23610-113">Persian, Urdu, Dari, Central Kurdish, Sindhi, Punjabi (Pakistan), and Uyghur.</span></span>

<span data-ttu-id="23610-114">このトピックでは、Windows に関する BiDi 対応の設計哲学を紹介し、BiDi 対応の設計時の考慮事項を示すケース スタディを取り上げます。</span><span class="sxs-lookup"><span data-stu-id="23610-114">This topic contains the Windows BiDi design philosophy, and case studies that show BiDi design considerations.</span></span>

## <a name="bidi-design-elements"></a><span data-ttu-id="23610-115">BiDi 対応の設計要素</span><span class="sxs-lookup"><span data-stu-id="23610-115">Bidi design elements</span></span>

<span data-ttu-id="23610-116">4 つの要素が、Windows の BiDi に関する設計上の決定に影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="23610-116">Four elements influence BiDi design decisions in Windows.</span></span>

- <span data-ttu-id="23610-117">**ユーザー インターフェイス (UI) のミラー化**。</span><span class="sxs-lookup"><span data-stu-id="23610-117">**User interface (UI) mirroring**.</span></span> <span data-ttu-id="23610-118">ユーザー インターフェイス (UI) のフローで右から左への読み取り順序のコンテンツをネイティブ レイアウトに表示できるようにします。</span><span class="sxs-lookup"><span data-stu-id="23610-118">User interface (UI) flow allows right-to-left content to be presented in its native layout.</span></span> <span data-ttu-id="23610-119">UI デザインが BiDi 市場に対してローカルなものになります。</span><span class="sxs-lookup"><span data-stu-id="23610-119">UI design feels local to BiDi markets.</span></span>
- <span data-ttu-id="23610-120">**ユーザー エクスペリエンスの一貫性**。</span><span class="sxs-lookup"><span data-stu-id="23610-120">**Consistency in user experience**.</span></span> <span data-ttu-id="23610-121">右から左の方向で自然に感じられるデザインを提供します。</span><span class="sxs-lookup"><span data-stu-id="23610-121">The design feels natural in right-to-left orientation.</span></span> <span data-ttu-id="23610-122">UI 要素が、共通した一貫性のあるレイアウト方向でユーザーの期待どおりに表示されます。</span><span class="sxs-lookup"><span data-stu-id="23610-122">UI elements share a consistent layout direction and appear as the user expects them.</span></span>
- <span data-ttu-id="23610-123">**タッチの最適化**。</span><span class="sxs-lookup"><span data-stu-id="23610-123">**Touch optimization**.</span></span> <span data-ttu-id="23610-124">ミラー化されていない UI におけるタッチ UI によく似た、簡単で自然なタッチによる対話式操作で UI 要素を操作できるようにします。</span><span class="sxs-lookup"><span data-stu-id="23610-124">Similar to touch UI in non-mirrored UI, elements are easy to reach, and they natural to touch interaction.</span></span>
- <span data-ttu-id="23610-125">**混在テキストのサポート**。</span><span class="sxs-lookup"><span data-stu-id="23610-125">**Mixed text support**.</span></span> <span data-ttu-id="23610-126">テキスト方向のサポートにより、混在テキストを美しく表示できます (BiDi ビルドに英語のテキストを表示、または英語ビルドに BiDi テキストを表示)。</span><span class="sxs-lookup"><span data-stu-id="23610-126">Text directionality support enables great mixed text presentation (English text on BiDi builds, and vice versa).</span></span>

## <a name="feature-design-overview"></a><span data-ttu-id="23610-127">機能設計の概要</span><span class="sxs-lookup"><span data-stu-id="23610-127">Feature design overview</span></span>

<span data-ttu-id="23610-128">Windows は、4 つの BiDi 対応の設計要素をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="23610-128">Windows supports the four BiDi design elements.</span></span> <span data-ttu-id="23610-129">ここでは、Windows の主な関連機能について説明し、それらの機能がアプリに影響するしくみに関するコンテキストを取り上げます。</span><span class="sxs-lookup"><span data-stu-id="23610-129">Let's look at some of the major relevant features in Windows, and provide some context around how they affect your app.</span></span>

### <a name="navigate-in-the-direction-that-feels-natural"></a><span data-ttu-id="23610-130">自然な形になる方向に配置する</span><span class="sxs-lookup"><span data-stu-id="23610-130">Navigate in the direction that feels natural</span></span>

<span data-ttu-id="23610-131">Windows では文字体裁グリッドの方向が右から左の順序になるように調整します。つまり、グリッド上の最初のタイルは右上隅に配置され、最後のタイルは左下隅に配置されます。</span><span class="sxs-lookup"><span data-stu-id="23610-131">Windows adjusts the direction of the typographic grid so that it flows from right to left, meaning that the first tile on the grid is placed at the top right corner, and the last tile at the bottom left.</span></span> <span data-ttu-id="23610-132">これは、本や雑誌などの刊行物の RTL パターンに一致します。読み取りパターンは常に右上隅から始まり、左に向かって進んでいくことになります。</span><span class="sxs-lookup"><span data-stu-id="23610-132">This matches the RTL pattern of printed publications such as books and magazines, where the reading pattern always starts at the top right corner and progresses to the left.</span></span>

<span data-ttu-id="23610-133">![[スタート] メニューの BiDi](images/56283_BIDI_01_startscreen_resized.png)
![BiDi チャームに [スタート] メニュー](images/56283_BIDI_02_startscreen_charm_resized.png)</span><span class="sxs-lookup"><span data-stu-id="23610-133">![BiDi start menu](images/56283_BIDI_01_startscreen_resized.png)
![BiDi start menu with charms](images/56283_BIDI_02_startscreen_charm_resized.png)</span></span>

<span data-ttu-id="23610-134">一貫性のある UI のフローを維持するために、タイルのコンテンツは常に右から左のレイアウトが保持されます。つまり、アプリの UI 言語に関係なく、アプリ名とロゴはタイルの右下隅に配置されます。</span><span class="sxs-lookup"><span data-stu-id="23610-134">To preserve a consistent UI flow, content on tiles retain a right-to-left layout, meaning that the app name and logo are positioned at the bottom right corner of the tile regardless of the app UI language.</span></span>

#### <a name="bidi-tile"></a><span data-ttu-id="23610-135">BiDi 対応のタイル</span><span class="sxs-lookup"><span data-stu-id="23610-135">BiDi tile</span></span>

![BiDi 対応のタイル](images/56284_BIDI_03_tile_callouts_withKey.png)

#### <a name="english-tile"></a><span data-ttu-id="23610-137">英語のタイル</span><span class="sxs-lookup"><span data-stu-id="23610-137">English tile</span></span>

![英語のタイル](images/56284_BIDI_03_tile_callouts_en-us.png)

### <a name="get-tile-notifications-that-read-correctly"></a><span data-ttu-id="23610-139">正しく読み取ることができるタイル通知を表示する</span><span class="sxs-lookup"><span data-stu-id="23610-139">Get tile notifications that read correctly</span></span>

<span data-ttu-id="23610-140">タイルは混在テキストをサポートします。</span><span class="sxs-lookup"><span data-stu-id="23610-140">Tiles have mixed text support.</span></span> <span data-ttu-id="23610-141">通知領域には、通知言語に応じてテキスト配置の方向を調整できる柔軟性が組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="23610-141">The notification region has built-in flexibility to adjust the text alignment based on the notification language.</span></span>  <span data-ttu-id="23610-142">アプリでアラビア語、ヘブライ語などの BiDi 言語の通知を送信する場合、テキストは右揃えに調整されます。</span><span class="sxs-lookup"><span data-stu-id="23610-142">When an app sends Arabic, Hebrew, or other BiDi language notifications, the text is aligned to the right.</span></span> <span data-ttu-id="23610-143">英語またはその他の左から右方向 (LTR) の言語の通知を受信した場合、その通知は左揃えに調整されます。</span><span class="sxs-lookup"><span data-stu-id="23610-143">And when an English (or other LTR) notification arrives, it will align to the left.</span></span>

![タイル通知](images/56285_BIDI_04_bidirectional_tiles_white.png)

### <a name="a-consistent-easy-to-touch-rtl-user-experience"></a><span data-ttu-id="23610-145">一貫性のあるタッチしやすい RTL ユーザー エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="23610-145">A consistent, easy-to-touch RTL user experience</span></span>

<span data-ttu-id="23610-146">Windows UI のすべての要素は、RTL の読み取り方向に適合します。</span><span class="sxs-lookup"><span data-stu-id="23610-146">Every element in the Windows UI fits into the RTL orientation.</span></span> <span data-ttu-id="23610-147">チャームとポップアップは画面の左端に配置されているため、検索結果に重ならず、快適なタッチ操作の邪魔になることもありません。</span><span class="sxs-lookup"><span data-stu-id="23610-147">Charms and flyouts have been positioned on the left edge of the screen so that they don't overlap search results or degrade touch optimization.</span></span> <span data-ttu-id="23610-148">親指で簡単に操作できます。</span><span class="sxs-lookup"><span data-stu-id="23610-148">They can be easily reached with the thumbs.</span></span>

<span data-ttu-id="23610-149">![双方向のスクリーン ショット](images/56286_BIDI_05_search_flyout_resized.png)
![双方向のスクリーン ショット](images/56286_BIDI_06_print_flyout_resized.png)</span><span class="sxs-lookup"><span data-stu-id="23610-149">![BiDi screenshot](images/56286_BIDI_05_search_flyout_resized.png)
![BiDi screenshot](images/56286_BIDI_06_print_flyout_resized.png)</span></span>

<span data-ttu-id="23610-150">![双方向のスクリーン ショット](images/56286_BIDI_07_settings_flyout_resized.png)
![双方向のスクリーン ショット](images/56286_BIDI_08_app_bars_resized.png)</span><span class="sxs-lookup"><span data-stu-id="23610-150">![BiDi screenshot](images/56286_BIDI_07_settings_flyout_resized.png)
![BiDi screenshot](images/56286_BIDI_08_app_bars_resized.png)</span></span>

### <a name="text-input-in-any-direction"></a><span data-ttu-id="23610-151">任意の方向へのテキスト入力</span><span class="sxs-lookup"><span data-stu-id="23610-151">Text input in any direction</span></span>

<span data-ttu-id="23610-152">Windows には、すっきり整理されたスクリーン タッチ キーボードが備わっています。</span><span class="sxs-lookup"><span data-stu-id="23610-152">Windows offers an on-screen touch keyboard that is clean and clutter-free.</span></span> <span data-ttu-id="23610-153">BiDi 言語の場合、テキスト方向のコントロール キーがあるため、テキスト入力の方向を必要に応じて切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="23610-153">For BiDi languages, there is a text direction control key so that the text input direction can be switched as needed.</span></span>

![BiDi 言語用のタッチ キーボード](images/56287_BIDI_09_keyboard_layout_resized.png)

### <a name="use-any-app-in-any-language"></a><span data-ttu-id="23610-155">任意の言語でのアプリの使用</span><span class="sxs-lookup"><span data-stu-id="23610-155">Use any app in any language</span></span>

<span data-ttu-id="23610-156">任意の言語でお気に入りのアプリをインストールして使うことができます。</span><span class="sxs-lookup"><span data-stu-id="23610-156">Install and use your favorite apps in any language.</span></span> <span data-ttu-id="23610-157">アプリは、BiDi 対応ではないバージョンの Windows の場合と同じように表示され、機能します。</span><span class="sxs-lookup"><span data-stu-id="23610-157">The apps appear and function as they would on non-BiDi versions of Windows.</span></span> <span data-ttu-id="23610-158">アプリの要素は常に一貫性のある予測可能な位置に配置されます。</span><span class="sxs-lookup"><span data-stu-id="23610-158">Elements within apps are always placed in a consistent and predictable position.</span></span>

![BiDi コンテンツを表示する英語のアプリ](images/56288_BIDI_10_english_app_resized.png)

### <a name="display-parentheses-correctly"></a><span data-ttu-id="23610-160">かっこの正しい表示</span><span class="sxs-lookup"><span data-stu-id="23610-160">Display parentheses correctly</span></span>

<span data-ttu-id="23610-161">BiDi Parenthesis Algorithm (BPA) を導入すると、言語やテキスト配置の方向に関係なく、ペアになったかっこは常に正しく表示されます。</span><span class="sxs-lookup"><span data-stu-id="23610-161">With the introduction of the BiDi Parenthesis Algorithm (BPA), paired parentheses always display properly regardless of language or text alignment properties.</span></span>

#### <a name="incorrect-parentheses"></a><span data-ttu-id="23610-162">不適切なかっこ</span><span class="sxs-lookup"><span data-stu-id="23610-162">Incorrect parentheses</span></span>

![不適切なかっこを表示している BiDi アプリ](images/56289_BIDI_11_parentheses_resized.png)

#### <a name="correct-parentheses"></a><span data-ttu-id="23610-164">適切なかっこ</span><span class="sxs-lookup"><span data-stu-id="23610-164">Correct parentheses</span></span>

![適切なかっこを表示している BiDi アプリ](images/56289_BIDI_12_parentheses_fixed_resized.png)

### <a name="typography"></a><span data-ttu-id="23610-166">文字体裁</span><span class="sxs-lookup"><span data-stu-id="23610-166">Typography</span></span>

<span data-ttu-id="23610-167">Windows では、Segoe UI フォントを使ってすべての BiDi 言語に対応しています。</span><span class="sxs-lookup"><span data-stu-id="23610-167">Windows uses the Segoe UI font for all BiDi languages.</span></span> <span data-ttu-id="23610-168">このフォントは、Windows UI に応じた外観と大きさになっています。</span><span class="sxs-lookup"><span data-stu-id="23610-168">This font is shaped and scaled for the Windows UI.</span></span>

<span data-ttu-id="23610-169">![双方向言語の Segoe UI フォント](images/56290_BIDI_13_start_screen_segoe.png)
![双方向言語の Segoe UI フォント](images/56290_BIDI_13_start_screen_segoe_arabic.png)</span><span class="sxs-lookup"><span data-stu-id="23610-169">![Segoe UI font for BiDi language](images/56290_BIDI_13_start_screen_segoe.png)
![Segoe UI font for BiDi language](images/56290_BIDI_13_start_screen_segoe_arabic.png)</span></span>

## <a name="case-study-1-a-bidi-music-app"></a><span data-ttu-id="23610-170">ケース スタディ 1:双方向のミュージック アプリ</span><span class="sxs-lookup"><span data-stu-id="23610-170">Case study #1: A BiDi music app</span></span>

### <a name="overview"></a><span data-ttu-id="23610-171">概要</span><span class="sxs-lookup"><span data-stu-id="23610-171">Overview</span></span>

<span data-ttu-id="23610-172">マルチメディア アプリは、非常に興味深い設計上の問題を提起します。一般にメディア コントロールは、BiDi 以外の言語の場合と同様の左から右のレイアウトであることが想定されているためです。</span><span class="sxs-lookup"><span data-stu-id="23610-172">Multimedia apps make for a very interesting design challenge, because media controls are generally expected to have a left-to-right layout similar to that of non-BiDi languages.</span></span>

![メディア コントロール (左から右)](images/56291_BIDI_1415_music_player_layouts_left-withcallouts.png)

![メディア コントロール (右から左)](images/56291_BIDI_1415_music_player_layouts_right-withcallouts.png)

### <a name="establishing-ui-directionality"></a><span data-ttu-id="23610-175">UI の方向の設定</span><span class="sxs-lookup"><span data-stu-id="23610-175">Establishing UI directionality</span></span>

<span data-ttu-id="23610-176">BiDi 市場向けの設計で一貫性を確保するためには、右から左への UI のフローを保持することが重要です。</span><span class="sxs-lookup"><span data-stu-id="23610-176">Retaining the right-to-left UI flow is important for consistent design for BiDi markets.</span></span> <span data-ttu-id="23610-177">このコンテキストで左から右へのフローの要素を追加するのは困難です。戻るボタンなどの一部のナビゲーション要素が、オーディオ コントロールの戻るボタンの方向と矛盾を生じる可能性があるからです。</span><span class="sxs-lookup"><span data-stu-id="23610-177">Adding elements that have left-to-right flow within this context is difficult, because some navigational elements such as the back button may contradict the directional orientation of the back button in the audio controls.</span></span>

![ミュージック アプリの追跡ページ](images/56292_BIDI_16_app_layout_callouts_resized.png)

<span data-ttu-id="23610-179">このミュージック アプリでは、右から左への方向のグリッドが保持されます。</span><span class="sxs-lookup"><span data-stu-id="23610-179">This music app retains a right-to-left-oriented grid.</span></span> <span data-ttu-id="23610-180">そのため、既に Windows UI でこの方向による操作を行っているユーザーにとっては、アプリで非常に自然な操作感が得られます。</span><span class="sxs-lookup"><span data-stu-id="23610-180">This gives the app a very natural feel for users who already navigate in this direction across the Windows UI.</span></span> <span data-ttu-id="23610-181">主な要素を右から左の読み取り順序にするだけでなく、セクション ヘッダーでも適切な方向の配置を行うことは、UI のフローを維持するために有効です。</span><span class="sxs-lookup"><span data-stu-id="23610-181">The flow is retained by ensuring that the main elements are not just ordered from right to left, but also aligned properly in the section headers to help maintain the UI flow.</span></span>

![ミュージック アプリのアルバム ページ](images/56292_BIDI_17_app_layout_callouts_resized.png)

### <a name="text-handling"></a><span data-ttu-id="23610-183">テキストの処理</span><span class="sxs-lookup"><span data-stu-id="23610-183">Text handling</span></span>

<span data-ttu-id="23610-184">上のスクリーンショットのアーティストの略歴は左揃えですが、アルバム名やトラック名などのその他のアーティスト関連テキストは右揃えが維持されています。</span><span class="sxs-lookup"><span data-stu-id="23610-184">The artist bio in the screenshot above is left-aligned, while other artist-related text pieces such as album and track names preserve right alignment.</span></span> <span data-ttu-id="23610-185">略歴のフィールドは非常に大きなテキスト要素であり、右揃えの場合、幅の広いテキスト ブロックを読み取るときに行を追うことが難しくなるため、読みづらくなります。</span><span class="sxs-lookup"><span data-stu-id="23610-185">The bio field is a fairly large text element, which reads poorly when aligned to the right simply because it's hard to track between the lines while reading a wider text block.</span></span> <span data-ttu-id="23610-186">一般に、5 つ以上の語句を含む行が 3 行以上あるテキスト要素で、同様の位置揃えの例外を考慮する必要があります。この場合、テキスト ブロックの位置揃えがアプリの全体的な方向レイアウトとは逆になります。</span><span class="sxs-lookup"><span data-stu-id="23610-186">In general, any text element with more than two or three lines containing five or more words should be considered for similar alignment exceptions, where the text block alignment is opposite to that of the overall app directional layout.</span></span>

<span data-ttu-id="23610-187">アプリ全体の位置揃えの操作は単純そうに見えますが、多くの場合、BiDi 文字列におけるニュートラル文字の配置の点で、レンダリング エンジンの限界や制限を伴います。</span><span class="sxs-lookup"><span data-stu-id="23610-187">Manipulating the alignment across the app can look simple, but it often exposes some of the boundaries and limitations of the rendering engines in terms of neutral character placement across BiDi strings.</span></span> <span data-ttu-id="23610-188">たとえば、次の文字列は位置揃えによって異なって表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="23610-188">For example, the following string can display differently based on alignment.</span></span>

| | <span data-ttu-id="23610-189">英語の文字列 (LTR)</span><span class="sxs-lookup"><span data-stu-id="23610-189">English String (LTR)</span></span> | <span data-ttu-id="23610-190">ヘブライ語の文字列 (RTL)</span><span class="sxs-lookup"><span data-stu-id="23610-190">Hebrew String (RTL)</span></span> |
| -------------- | ------------------- | ------------------- |
| <span data-ttu-id="23610-191">**左揃え**</span><span class="sxs-lookup"><span data-stu-id="23610-191">**Left-alignment**</span></span> | <span data-ttu-id="23610-192">Hello, World!</span><span class="sxs-lookup"><span data-stu-id="23610-192">Hello, World!</span></span> | <span data-ttu-id="23610-193">בוקר טוב!</span><span class="sxs-lookup"><span data-stu-id="23610-193">בוקר טוב!</span></span> |
| <span data-ttu-id="23610-194">**右揃え**</span><span class="sxs-lookup"><span data-stu-id="23610-194">**Right-alignment**</span></span> | <span data-ttu-id="23610-195">!Hello, World</span><span class="sxs-lookup"><span data-stu-id="23610-195">!Hello, World</span></span> | <span data-ttu-id="23610-196">!בוקר טוב</span><span class="sxs-lookup"><span data-stu-id="23610-196">!בוקר טוב</span></span> |

<span data-ttu-id="23610-197">ミュージック アプリでアーティスト情報が適切に表示されるようにするために、開発チームではテキスト レイアウトのプロパティを位置揃えから切り離しました。</span><span class="sxs-lookup"><span data-stu-id="23610-197">To ensure that artist information is properly displayed across the music app, the development team separated text layout properties from alignment.</span></span> <span data-ttu-id="23610-198">つまり、アーティスト情報は多くの場合に右揃えで表示されますが、文字列レイアウトの調整は、カスタマイズされたバックグラウンド処理に基づいて設定されます。</span><span class="sxs-lookup"><span data-stu-id="23610-198">In other words, the artist info might be displayed as right-aligned in many of the cases, but the string layout adjustment is set based on customized background processing.</span></span> <span data-ttu-id="23610-199">バックグラウンド処理では、文字列の内容に応じた最適な方向レイアウト設定が判断されます。</span><span class="sxs-lookup"><span data-stu-id="23610-199">The background processing determines the best directional layout setting based on the content of the string.</span></span>

![ミュージック アプリのアーティスト ページ](images/56292_BIDI_18_app_layout_callouts_resized.png)

<span data-ttu-id="23610-201">たとえば、カスタムの文字列レイアウト処理を適用しない場合、アーティスト名 "The Contoso Band." は </span><span class="sxs-lookup"><span data-stu-id="23610-201">For example, without custom string layout processing, the artist name "The Contoso Band."</span></span> <span data-ttu-id="23610-202">".The Contoso Band" と表示されます。</span><span class="sxs-lookup"><span data-stu-id="23610-202">would appear as ".The Contoso Band".</span></span>

### <a name="specialized-string-direction-preprocessing"></a><span data-ttu-id="23610-203">文字列の方向の特殊な前処理</span><span class="sxs-lookup"><span data-stu-id="23610-203">Specialized string direction preprocessing</span></span>

<span data-ttu-id="23610-204">メディア メタデータの有無についてアプリがサーバーと通信する場合、アプリはユーザーへの表示前に各文字列を前処理します。</span><span class="sxs-lookup"><span data-stu-id="23610-204">When the app contacts the server for media metadata, it preprocesses each string prior to displaying it to the user.</span></span> <span data-ttu-id="23610-205">また、この前処理の際に、アプリはテキストの方向を統一するための変換を行います。</span><span class="sxs-lookup"><span data-stu-id="23610-205">During this preprocessing, the app also does a transformation to make the text direction consistent.</span></span> <span data-ttu-id="23610-206">これを行うために、アプリは文字列の末尾にニュートラル文字がないかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="23610-206">To do this, it checks whether there are neutral characters on the ends of the string.</span></span> <span data-ttu-id="23610-207">また、文字列のテキストの方向が Windows の言語設定で設定されたアプリの方向と逆である場合は、Unicode 方向マーカーを追加 (場合によっては、先頭に追加) します。</span><span class="sxs-lookup"><span data-stu-id="23610-207">Also, if the text direction of the string is opposite to the app direction set by the Windows language settings, then it appends (and sometimes prepends) Unicode direction markers.</span></span> <span data-ttu-id="23610-208">この変換関数は、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="23610-208">The transformation function looks like this.</span></span>

```csharp
string NormalizeTextDirection(string data) 
{
    if (data.Length > 0) {
        var lastCharacterDirection = DetectCharacterDirection(data[data.Length - 1]);

        // If the last character has strong directionality (direction is not null), then the text direction for the string is already consistent.
        if (!lastCharacterDirection) {
            // If the last character has no directionality (neutral character, direction is null), then we may need to add a direction marker to
            // ensure that the last character doesn't inherit directionality from the outside context.
            var appTextDirection = GetAppTextDirection(); // checks the <html> element's "dir" attribute.
            var dataTextDirection = DetectStringDirection(data); // Run through the string until a non-neutral character is encountered,
                                                                 // which determines the text direction.

            if (appTextDirection != dataTextDirection) {
                // Add a direction marker only if the data text runs opposite to the directionality of the app as a whole,
                // which would cause the neutral characters at the ends to flip.
                var directionMarkerCharacter =
                    dataTextDirection == TextDirections.RightToLeft ?
                        UnicodeDirectionMarkers.RightToLeftDirectionMarker : // "\u200F"
                        UnicodeDirectionMarkers.LeftToRightDirectionMarker; // "\u200E"

                data += directionMarkerCharacter;

                // Prepend the direction marker if the data text begins with a neutral character.
                var firstCharacterDirection = DetectCharacterDirection(data[0]);
                if (!firstCharacterDirection) {
                    data = directionMarkerCharacter + data;
                }
            }
        }
    }

    return data;
}
```

<span data-ttu-id="23610-209">追加される Unicode 文字は幅が 0 であるため、文字列の間隔に影響を与えることはありません。</span><span class="sxs-lookup"><span data-stu-id="23610-209">The added Unicode characters are zero-width, so they don't impact the spacing of the strings.</span></span> <span data-ttu-id="23610-210">文字列の方向の検出は、ニュートラル以外の文字が検出されるまで文字列全体を対象に続ける必要があるため、このコードによってパフォーマンスの低下を招く可能性があります。</span><span class="sxs-lookup"><span data-stu-id="23610-210">This code carries a potential performance penalty, since detecting the direction of a string requires running through the string until a non-neutral character is encountered.</span></span> <span data-ttu-id="23610-211">また、ニュートラル文字であるかどうかの確認対象となるそれぞれの文字については、最初に複数の Unicode の範囲との照合も行われるため、これは単純なチェックではありません。</span><span class="sxs-lookup"><span data-stu-id="23610-211">Each character that's checked for neutrality is first compared against several Unicode ranges as well, so it isn't a trivial check.</span></span>

## <a name="case-study-2-a-bidi-mail-app"></a><span data-ttu-id="23610-212">ケース スタディ 2:双方向のメール アプリ</span><span class="sxs-lookup"><span data-stu-id="23610-212">Case study #2: A BiDi mail app</span></span>

### <a name="overview"></a><span data-ttu-id="23610-213">概要</span><span class="sxs-lookup"><span data-stu-id="23610-213">Overview</span></span>

<span data-ttu-id="23610-214">UI レイアウト要件の点では、メール クライアントは設計が非常に単純です。</span><span class="sxs-lookup"><span data-stu-id="23610-214">In terms of UI layout requirements, a mail client is fairly simple to design.</span></span> <span data-ttu-id="23610-215">Windows のメール アプリは既定でミラー化されています。</span><span class="sxs-lookup"><span data-stu-id="23610-215">The Mail app in Windows is mirrored by default.</span></span> <span data-ttu-id="23610-216">テキスト処理の観点から、メール アプリには、混在テキストのシナリオに対応するために、しっかりとしたテキスト表示機能とテキスト作成機能が必要です。</span><span class="sxs-lookup"><span data-stu-id="23610-216">From a text-handling perspective the mail app is required to have more robust text display and composition capabilities in order to accommodate mixed text scenarios.</span></span>

### <a name="establishing-ui-directionality"></a><span data-ttu-id="23610-217">UI の方向の設定</span><span class="sxs-lookup"><span data-stu-id="23610-217">Establishing UI directionality</span></span>

<span data-ttu-id="23610-218">メール アプリの UI レイアウトはミラー化されています。</span><span class="sxs-lookup"><span data-stu-id="23610-218">The UI layout for the Mail app is mirrored.</span></span> <span data-ttu-id="23610-219">3 つのウィンドウが配置し直され、フォルダー ウィンドウは画面の右端に配置され、メール項目一覧ウィンドウがその左に続き、さらにその左にメール作成ウィンドウが配置されます。</span><span class="sxs-lookup"><span data-stu-id="23610-219">The three panes have been reoriented so that the folder pane is positioned on the right edge of the screen, followed by the mail item list pane to the left, and then the email composition pane.</span></span>

![ミラー化されたメール アプリ](images/56293_BIDI_19_icon_realignment_cropped_resized.png)

<span data-ttu-id="23610-221">その他の項目も、UI のフロー全体とタッチの最適化に適合するように配置し直されます。</span><span class="sxs-lookup"><span data-stu-id="23610-221">Additional items have been reoriented to match the overall UI flow, and touch optimization.</span></span> <span data-ttu-id="23610-222">その他の項目には、アプリ バーや作成、返信、削除の各アイコンがあります。</span><span class="sxs-lookup"><span data-stu-id="23610-222">These include the app bar and the compose, reply, and delete icons.</span></span>

![ミラー化されたメール アプリ (アプリ バー付き)](images/56294_BIDI_20_email_orientation_email_resized.png)

### <a name="text-handling"></a><span data-ttu-id="23610-224">テキストの処理</span><span class="sxs-lookup"><span data-stu-id="23610-224">Text Handling</span></span>

#### <a name="ui"></a><span data-ttu-id="23610-225">UI</span><span class="sxs-lookup"><span data-stu-id="23610-225">UI</span></span>

<span data-ttu-id="23610-226">UI 全体のテキスト配置は、通常は右揃えです。</span><span class="sxs-lookup"><span data-stu-id="23610-226">Text alignment across the UI is usually right-aligned.</span></span> <span data-ttu-id="23610-227">これには、フォルダー ウィンドウや項目ウィンドウが含まれます。</span><span class="sxs-lookup"><span data-stu-id="23610-227">This includes the folder pane and items pane.</span></span> <span data-ttu-id="23610-228">項目ウィンドウはテキスト 2 行に制限されます (アドレスとタイトル)。</span><span class="sxs-lookup"><span data-stu-id="23610-228">The item pane is limited to two lines of text (Address, and Title).</span></span> <span data-ttu-id="23610-229">このことはテキスト ブロックを導入しないで右から左の配置を維持するうえで重要です。テキスト ブロックがあると、コンテンツの方向が UI の方向フローと逆であるときに読み取りが困難になります。</span><span class="sxs-lookup"><span data-stu-id="23610-229">This is important for retaining the right-to-left alignment, without introducing a block of text that would be difficult to read when the content direction is opposite to the UI direction flow.</span></span>

#### <a name="text-editing"></a><span data-ttu-id="23610-230">テキストの編集</span><span class="sxs-lookup"><span data-stu-id="23610-230">Text Editing</span></span>

<span data-ttu-id="23610-231">テキストを編集するには、右から左と左から右の両方の形式で記述できる機能が必要です。</span><span class="sxs-lookup"><span data-stu-id="23610-231">Text editing requires the ability to compose in both right-to-left and left-to-right form.</span></span> <span data-ttu-id="23610-232">形式を使用して、コンポジションのレイアウトを保持する必要がさらに、&mdash;リッチ テキストなど&mdash;方向の情報を保存する機能を持ちます。</span><span class="sxs-lookup"><span data-stu-id="23610-232">In addition, the composition layout must be preserved by using a format&mdash;such as rich text&mdash;that has the ability to save directional information.</span></span>

![メール アプリ (左から右)](images/56294_BIDI_21_email_orientation_LtR_resized.png)

![メール アプリ (右から左)](images/56294_BIDI_22_email_orientation_RtL_resized.png)
