---
Description: Search is one of the top ways users can find content in your app. The guidance in this article covers elements of the search experience, search scopes, implementation, and examples of search in context.
title: 検索とページ内検索
ms.assetid: C328FAA3-F6AE-4970-8372-B413F1290C39
label: Search
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: miguelrb
design-contact: ksulliv
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: caf0e8e63716f6ba140ef9346257687f0e7293bb
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7978362"
---
# <a name="search-and-find-in-page"></a><span data-ttu-id="0f42c-103">検索とページ内検索</span><span class="sxs-lookup"><span data-stu-id="0f42c-103">Search and find-in-page</span></span>

 

<span data-ttu-id="0f42c-104">検索は、ユーザーがアプリでコンテンツを見つけることができる 2 つの方法のうちの 1 つです。</span><span class="sxs-lookup"><span data-stu-id="0f42c-104">Search is one of the top ways users can find content in your app.</span></span> <span data-ttu-id="0f42c-105">この記事のガイダンスでは、検索エクスペリエンスの構成要素、検索スコープ、実装、コンテキストでの検索の例について説明します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-105">The guidance in this article covers elements of the search experience, search scopes, implementation, and examples of search in context.</span></span>

> <span data-ttu-id="0f42c-106">**重要な API**: [AutoSuggestBox クラス](https://msdn.microsoft.com/library/windows/apps/dn633874)</span><span class="sxs-lookup"><span data-stu-id="0f42c-106">**Important APIs**: [AutoSuggestBox class](https://msdn.microsoft.com/library/windows/apps/dn633874)</span></span>

## <a name="elements-of-the-search-experience"></a><span data-ttu-id="0f42c-107">検索エクスペリエンスの構成要素</span><span class="sxs-lookup"><span data-stu-id="0f42c-107">Elements of the search experience</span></span>


<span data-ttu-id="0f42c-108">**入力**。テキスト検索入力の最も一般的なモードは、このガイドのフォーカス。</span><span class="sxs-lookup"><span data-stu-id="0f42c-108">**Input.** Text is the most common mode of search input and is the focus of this guidance.</span></span> <span data-ttu-id="0f42c-109">その他の一般的な入力モードには音声やカメラがありますが、通常、それらにはデバイス ハードウェアを操作する機能が必要であり、追加のコントロールやカスタム UI がアプリ内で必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-109">Other common input modes include voice and camera, but these typically require the ability to interface with device hardware and may require additional controls or custom UI within the app.</span></span>

<span data-ttu-id="0f42c-110">**0 を入力します**。されたら、ユーザーが入力フィールドをアクティブには、ユーザーがテキストを入力すると、前に、「ゼロ入力キャンバス」と呼ばれるものを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-110">**Zero input.** Once the user has activated the input field, but before the user has entered text, you can display what's called a "zero input canvas."</span></span> <span data-ttu-id="0f42c-111">通常、ゼロ入力キャンバスは、アプリのキャンバスに表示され、ユーザーがクエリの入力を開始したときに、このコンテンツが[自動提案](auto-suggest-box.md)で置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-111">The zero input canvas will commonly appear in the app canvas, so that [auto-suggest](auto-suggest-box.md) replaces this content when the user begins to input their query.</span></span> <span data-ttu-id="0f42c-112">最近の検索履歴、トレンド検索、状況依存の検索候補、ヒントが、すべてゼロ入力状態の候補となります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-112">Recent search history, trending searches, contextual search suggestions, hints and tips are all good candidates for the zero input state.</span></span>

![ゼロ入力キャンバスでの Cortana の例](images/search-cortana-example.png)

 

<span data-ttu-id="0f42c-114">**クエリの生成/自動提案します**。クエリの生成により、ユーザーが入力を開始するとすぐにゼロ入力のコンテンツが置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-114">**Query formulation/auto-suggest.** Query formulation replaces zero input content as soon as the user begins to enter input.</span></span> <span data-ttu-id="0f42c-115">ユーザーがクエリ文字列を入力すると、入力プロセスを高速化し、有効なクエリを生成できるように、継続的に更新される一連のクエリ候補、または不明瞭解消オプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-115">As the user enters a query string, they are provided with a continuously updated set of query suggestions or disambiguation options to help them expedite the input process and formulate an effective query.</span></span> <span data-ttu-id="0f42c-116">このクエリ候補の表示動作は、[自動提案コントロール](auto-suggest-box.md)に組み込まれ、検索内部にアイコンを表示する方法にもなります (マイク アイコンやコミット アイコンなど)。</span><span class="sxs-lookup"><span data-stu-id="0f42c-116">This behavior of query suggestions is built into the [auto-suggest control](auto-suggest-box.md), and is also a way to show the icon inside the search (like a microphone or a commit icon).</span></span> <span data-ttu-id="0f42c-117">これ以外のすべての動作は、アプリに基づきます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-117">Any behavior outside of this falls to the app.</span></span>

![クエリの生成/自動提案の例](images/search-autosuggest-example.png)

 

<span data-ttu-id="0f42c-119">**結果セットです**。検索結果がよく検索入力フィールドのすぐ下に表示します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-119">**Results set.** Search results commonly appear directly under the search input field.</span></span> <span data-ttu-id="0f42c-120">これは必須ではありませんが、入力と結果の並置によりコンテキストが維持され、ユーザーは前のクエリの編集や新しいクエリの入力をすぐに開始できます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-120">While this isn't a requirement, the juxtaposition of input and results maintains context and provides the user with immediate access to edit the previous query or enter a new query.</span></span> <span data-ttu-id="0f42c-121">このつながりは、ヒント テキストを、結果セットを作成したクエリで置き換えることで、さらに強化できます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-121">This connection can be further communicated by replacing the hint text with the query that created the results set.</span></span>

<span data-ttu-id="0f42c-122">前のクエリの編集と新しいクエリの入力の両方を効率的に開始できるようにする 1 つの方法として、フィールドが再アクティブ化されたときに、前のクエリを強調表示します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-122">One method to enable efficient access to both edit the previous query and enter a new query is to highlight the previous query when the field is reactivated.</span></span> <span data-ttu-id="0f42c-123">これにより、任意のキー入力によって前の文字列が置き換えられますが、文字列が保持されるため、ユーザーはカーソルを移動して、前の文字列を編集または追加することができます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-123">This way, any keystroke will replace the previous string, but the string is maintained so that the user can position a cursor to edit or append the previous string.</span></span>

<span data-ttu-id="0f42c-124">結果のセットは、コンテンツを最適に伝える任意の形式で表示できます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-124">The results set can appear in any form that best communicates the content.</span></span> <span data-ttu-id="0f42c-125">[リスト ビュー](lists.md)は十分な柔軟性を備えており、ほとんどの検索に最適です。</span><span class="sxs-lookup"><span data-stu-id="0f42c-125">A [list view](lists.md) provides a good deal of flexibility and is well-suited to most searches.</span></span> <span data-ttu-id="0f42c-126">グリッド ビューはイメージまたはその他のメディアに適しており、地図を使って空間的な配布を伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-126">A grid view works well for images or other media, and a map can be used to communicate spatial distribution.</span></span>

## <a name="search-scopes"></a><span data-ttu-id="0f42c-127">検索スコープ</span><span class="sxs-lookup"><span data-stu-id="0f42c-127">Search scopes</span></span>


<span data-ttu-id="0f42c-128">検索は共通の機能であり、シェルおよび多くのアプリ内で検索 UI がユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-128">Search is a common feature, and users will encounter search UI in the shell and within many apps.</span></span> <span data-ttu-id="0f42c-129">検索のエントリ ポイントは同じように視覚化される傾向がありますが、広い範囲 (Web またはデバイスの検索) から狭い範囲 (ユーザーの連絡先一覧) までの結果を提供できます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-129">Although search entry points tend to be similarly visualized, they can provide access to results that range from broad (web or device searches) to narrow (a user's contact list).</span></span> <span data-ttu-id="0f42c-130">検索エントリ ポイントは、検索対象のコンテンツに対して並置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-130">The search entry point should be juxtaposed against the content being searched.</span></span>

<span data-ttu-id="0f42c-131">一般的な検索スコープは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="0f42c-131">Some common search scopes include:</span></span>

<span data-ttu-id="0f42c-132">**グローバル**と**コンテキスト/絞り込み**。クラウドとローカル コンテンツの複数のソースにわたる検索します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-132">**Global** and **contextual/refine.** Search across multiple sources of cloud and local content.</span></span> <span data-ttu-id="0f42c-133">結果には、URL、ドキュメント、メディア、操作、アプリなどが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-133">Varied results include URLs, documents, media, actions, apps, and more.</span></span>

<span data-ttu-id="0f42c-134">**Web** 。Web インデックスを検索します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-134">**Web.** Search a web index.</span></span> <span data-ttu-id="0f42c-135">結果には、ページ、エンティティ、回答が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-135">Results include pages, entities, and answers.</span></span>

<span data-ttu-id="0f42c-136">**自分のコンテンツ**。デバイス、クラウド、ソーシャル グラフなど、複数の間で検索します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-136">**My stuff.** Search across device(s), cloud, social graphs, and more.</span></span> <span data-ttu-id="0f42c-137">結果はさまざまですが、ユーザー アカウントへの接続によって制限されます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-137">Results are varied, but are constrained by the connection to user account(s).</span></span>

<span data-ttu-id="0f42c-138">ヒントのテキストを使って検索スコープを伝えます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-138">Use hint text to communicate search scope.</span></span> <span data-ttu-id="0f42c-139">次のようなシナリオが考えられます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-139">Examples include:</span></span>

<span data-ttu-id="0f42c-140">"Windows と Web を検索する"</span><span class="sxs-lookup"><span data-stu-id="0f42c-140">"Search Windows and the Web"</span></span>

<span data-ttu-id="0f42c-141">"連絡先の一覧を検索する"</span><span class="sxs-lookup"><span data-stu-id="0f42c-141">"Search contacts list"</span></span>

<span data-ttu-id="0f42c-142">"メールボックスを検索する"</span><span class="sxs-lookup"><span data-stu-id="0f42c-142">"Search mailbox"</span></span>

<span data-ttu-id="0f42c-143">"検索の設定"</span><span class="sxs-lookup"><span data-stu-id="0f42c-143">"Search settings"</span></span>

<span data-ttu-id="0f42c-144">"場所を探す"</span><span class="sxs-lookup"><span data-stu-id="0f42c-144">"Search for a place"</span></span>

![検索のヒントのテキストの例](images/search-windowsandweb.png)

 

<span data-ttu-id="0f42c-146">検索入力ポイントの範囲を効果的に伝えることにより、実行中の検索の機能がユーザーの期待事項を満たし、不満が発生する可能性を減らすことができます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-146">By effectively communicating the scope of a search input point, you can help to ensure that the user expectation will be met by the capabilities of the search you are performing and reduce the possibility of frustration.</span></span>

## <a name="implementation"></a><span data-ttu-id="0f42c-147">実装</span><span class="sxs-lookup"><span data-stu-id="0f42c-147">Implementation</span></span>


<span data-ttu-id="0f42c-148">ほとんどのアプリでは、検索のエントリ ポイントとしてテキスト入力フィールドを用意することをお勧めします。これにより、目立つ視覚的なフットプリントが提供されます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-148">For most apps, it's best to have a text input field as the search entry point, which provides a prominent visual footprint.</span></span> <span data-ttu-id="0f42c-149">さらに、ヒントのテキストは検索機能を支援し、検索スコープを伝えることができます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-149">In addition, hint text helps with discoverability and communicating the search scope.</span></span> <span data-ttu-id="0f42c-150">検索がよりセカンダリ操作であるか、またはスペースに制約がある場合、検索アイコンは、関連する入力フィールドのないエントリ ポイントとなります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-150">When search is a more secondary action, or when space is constrained, the search icon can serve as an entry point without the accompanying input field.</span></span> <span data-ttu-id="0f42c-151">アイコンとして視覚化するときは、次の例のように、必ずモーダルな検索ボックスの余地があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-151">When visualized as an icon, be sure that there's room for a modal search box, as seen in the below examples.</span></span>

<span data-ttu-id="0f42c-152">検索アイコンをクリックする前:</span><span class="sxs-lookup"><span data-stu-id="0f42c-152">Before clicking search icon:</span></span>

![検索アイコンと折りたたまれている検索ボックスの例](images/search-icon-collapsed.png)

 

<span data-ttu-id="0f42c-154">検索アイコンをクリックした後:</span><span class="sxs-lookup"><span data-stu-id="0f42c-154">After clicking search icon:</span></span>

![検索アイコンと展開された検索ボックスの例](images/search-icon-expanded.png)

 

<span data-ttu-id="0f42c-156">検索では、常にエントリ ポイントに右向きの虫眼鏡グリフを使います。</span><span class="sxs-lookup"><span data-stu-id="0f42c-156">Search always uses a right-pointing magnifying glass glyph for the entry point.</span></span> <span data-ttu-id="0f42c-157">使用するグリフは Segoe UI Symbol、16 進数の文字のコード 0xE0094 で、通常は 15 epx のフォント サイズです。</span><span class="sxs-lookup"><span data-stu-id="0f42c-157">The glyph to use is Segoe UI Symbol, hex character code 0xE0094, and usually at 15 epx font size.</span></span>

<span data-ttu-id="0f42c-158">検索のエントリ ポイントは、多数のさまざまな領域に配置でき、それによって検索スコープとコンテキストの両方が伝わります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-158">The search entry point can be placed in a number of different areas, and its placement communicates both search scope and context.</span></span> <span data-ttu-id="0f42c-159">さまざまなエクスペリエンスや外部からの結果をアプリに収集する検索は、通常、グローバル コマンド バーやナビゲーションなど、最上位にあるアプリのクロム内に配置されます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-159">Searches that gather results from across an experience or external to the app are typically located within top-level app chrome, such as global command bars or navigation.</span></span>

<span data-ttu-id="0f42c-160">検索スコープが狭くなるかにコンテキストに依存するにつれて、通常、配置は検索するコンテンツとより直接的に関連付けられます (キャンバス上、リスト ヘッダーとして、状況依存のコマンド バー内など)。</span><span class="sxs-lookup"><span data-stu-id="0f42c-160">As the search scope becomes more narrow or contextual, the placement will typically be more directly associated with the content to be searched, such as on a canvas, as a list header, or within contextual command bars.</span></span> <span data-ttu-id="0f42c-161">いずれの場合も、検索入力と結果のつながり、または絞り込まれたコンテンツが視覚的に明確になります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-161">In all cases, the connection between search input and results or filtered content should be visually clear.</span></span>

<span data-ttu-id="0f42c-162">スクロール可能なリストの場合、常に検索入力を表示すると便利です。</span><span class="sxs-lookup"><span data-stu-id="0f42c-162">In the case of scrollable lists, it's helpful to always have search input be visible.</span></span> <span data-ttu-id="0f42c-163">検索入力は固定し、コンテンツが背後をスクロールするようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0f42c-163">We recommend making the search input sticky and have content scroll behind it.</span></span>

<span data-ttu-id="0f42c-164">ゼロ入力とクエリの生成機能は、コンテキスト/絞り込み検索ではオプションであり、リストはユーザーの入力によってリアルタイムで絞り込まれます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-164">Zero input and query formulation functionality is optional for contextual/refine searches in which the list will be filtered in real-time by user input.</span></span> <span data-ttu-id="0f42c-165">例外には、受信トレイのフィルター オプション (宛先:&lt;入力文字列&gt;、差出人: &lt;入力文字列&gt;、件名: &lt;入力文字列&gt;) など、クエリの書式設定の候補が表示される場合などがあります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-165">Exceptions include cases where query formatting suggestions may be available, such as inbox filtering options (to:&lt;input string&gt;, from: &lt;input string&gt;, subject: &lt;input string&gt;, and so on).</span></span>

## <a name="example"></a><span data-ttu-id="0f42c-166">例</span><span class="sxs-lookup"><span data-stu-id="0f42c-166">Example</span></span>


<span data-ttu-id="0f42c-167">このセクションの例では、コンテキストに検索を配置します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-167">The examples in this section show search placed in context.</span></span>

<span data-ttu-id="0f42c-168">Windows ツール バーの操作としての検索:</span><span class="sxs-lookup"><span data-stu-id="0f42c-168">Search as an action in the Windows tool bar:</span></span>

![Windows ツール バーの操作としての検索の例](images/search-toolbar-action.png)

 

<span data-ttu-id="0f42c-170">アプリ キャンバスでの入力としての検索:</span><span class="sxs-lookup"><span data-stu-id="0f42c-170">Search as an input on the app canvas:</span></span>

![アプリ キャンバスでの検索の例](images/search-canvas-contacts.png)

 

<span data-ttu-id="0f42c-172">ナビゲーション ウィンドウでの検索:</span><span class="sxs-lookup"><span data-stu-id="0f42c-172">Search in a navigation pane:</span></span>

![ナビゲーション メニューの検索の例](images/search-navmenu.png)

 

<span data-ttu-id="0f42c-174">検索が頻繁にアクセスされないか、コンテキスト依存が高い場合に予約されるのが最適なインライン検索:</span><span class="sxs-lookup"><span data-stu-id="0f42c-174">Inline search is best reserved for cases where search is infrequently accessed or is highly contextual:</span></span>

![インライン検索の例](images/patterns-search-results-desktop.png)


## <a name="guidelines-for-find-in-page"></a><span data-ttu-id="0f42c-176">ページ内検索のガイドライン</span><span class="sxs-lookup"><span data-stu-id="0f42c-176">Guidelines for find-in-page</span></span>


<span data-ttu-id="0f42c-177">ページ内検索により、ユーザーは現在のテキスト本文からテキストの一致を検索できるようになります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-177">Find-in-page enables users to find text matches in the current body of text.</span></span> <span data-ttu-id="0f42c-178">ページ内検索が提供される最も一般的なアプリは、ドキュメント ビューアー、リーダー、ブラウザーです。</span><span class="sxs-lookup"><span data-stu-id="0f42c-178">Document viewers, readers, and browsers are the most typical apps that provide find-in-page.</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="0f42c-179">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="0f42c-179">Do's and don'ts</span></span>


-   <span data-ttu-id="0f42c-180">ユーザーがページ内のテキストを検索できるように、ページ内検索機能を備えたコマンド バーをアプリ内に配置します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-180">Place a command bar in your app with find-in-page functionality to let the user search for on-page text.</span></span> <span data-ttu-id="0f42c-181">配置について詳しくは、「例」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f42c-181">For placement details, see the Examples section.</span></span>

    -   <span data-ttu-id="0f42c-182">ページ内検索を提供するアプリでは、必要なすべてのコントロールがコマンド バーに含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-182">Apps that provide find-in-page should have all necessary controls in a command bar.</span></span>
    -   <span data-ttu-id="0f42c-183">ページ検索以外に多くの機能をアプリに含める場合は、ページ内検索のすべてのコントロールが含まれる別のコマンド バーへのエントリ ポイントとしてトップ レベルのコマンド バーに **[検索]** ボタンを追加できます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-183">If your app includes a lot of functionality beyond find-in-page, you can provide a **Find** button in the top-level command bar as an entry point to another command bar that contains all of your find-in-page controls.</span></span>
    -   <span data-ttu-id="0f42c-184">ユーザーがタッチ キーボードを操作しているときもページ内検索のコマンド バーが表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="0f42c-184">The find-in-page command bar should remain visible when the user is interacting with the touch keyboard.</span></span> <span data-ttu-id="0f42c-185">タッチ キーボードは、ユーザーが入力ボックスをタップすると表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-185">The touch keyboard appears when a user taps the input box.</span></span> <span data-ttu-id="0f42c-186">ページ内検索のコマンド バーは、タッチ キーボードに隠れないように上へ移動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-186">The find-in-page command bar should move up, so it's not obscured by the touch keyboard.</span></span>

    -   <span data-ttu-id="0f42c-187">ユーザーが表示を操作しているときもページ内検索を利用できるようにする。</span><span class="sxs-lookup"><span data-stu-id="0f42c-187">Find-in-page should remain available while the user interacts with the view.</span></span> <span data-ttu-id="0f42c-188">ユーザーは、ページ内検索を使いながら表示内のテキストを操作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-188">Users need to interact with the in-view text while using find-in-page.</span></span> <span data-ttu-id="0f42c-189">たとえば、ユーザーはテキストを読むために、ドキュメントを拡大表示または縮小表示したり、表示をパンしたりすることがあります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-189">For example, users may want to zoom in or out of a document or pan the view to read the text.</span></span> <span data-ttu-id="0f42c-190">ユーザーがページ内検索を使い始めたら、コマンド バーはページ内検索を終了するための **[閉じる]** ボタンと共に表示されたままにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-190">Once the user starts using find-in-page, the command bar should remain available with a **Close** button to exit find-in-page.</span></span>

    -   <span data-ttu-id="0f42c-191">キーボード ショートカット (Ctrl + F) を有効にする。</span><span class="sxs-lookup"><span data-stu-id="0f42c-191">Enable the keyboard shortcut (CTRL+F).</span></span> <span data-ttu-id="0f42c-192">キーボード ショートカット Ctrl + F を実装し、ページ内検索のコマンド バーをユーザーがすぐに呼び出すことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="0f42c-192">Implement the keyboard shortcut CTRL+F to enable the user to invoke the find-in-page command bar quickly.</span></span>

    -   <span data-ttu-id="0f42c-193">ページ内検索機能の基本要素を含める。</span><span class="sxs-lookup"><span data-stu-id="0f42c-193">Include the basics of find-in-page functionality.</span></span> <span data-ttu-id="0f42c-194">ページ内検索を実装するために必要な UI 要素を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-194">These are the UI elements that you need in order to implement find-in-page:</span></span>

        -   <span data-ttu-id="0f42c-195">入力ボックス</span><span class="sxs-lookup"><span data-stu-id="0f42c-195">Input box</span></span>
        -   <span data-ttu-id="0f42c-196">[前へ] ボタンと [次へ] ボタン</span><span class="sxs-lookup"><span data-stu-id="0f42c-196">Previous and Next buttons</span></span>
        -   <span data-ttu-id="0f42c-197">一致数</span><span class="sxs-lookup"><span data-stu-id="0f42c-197">A match count</span></span>
        -   <span data-ttu-id="0f42c-198">[閉じる] (デスクトップのみ)</span><span class="sxs-lookup"><span data-stu-id="0f42c-198">Close (desktop-only)</span></span>
    -   <span data-ttu-id="0f42c-199">表示で一致した結果が強調表示され、スクロールして次の一致が画面に表示されるようにする。</span><span class="sxs-lookup"><span data-stu-id="0f42c-199">The view should highlight matches and scroll to show the next match on screen.</span></span> <span data-ttu-id="0f42c-200">ユーザーは、**[前へ]** ボタンと **[次へ]** ボタンの使用、スクロール バーの使用、またはタッチによる直接操作によってドキュメントをすばやく移動できます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-200">Users can move quickly through the document by using the **Previous** and **Next** buttons and by using scroll bars or direct manipulation with touch.</span></span>

    -   <span data-ttu-id="0f42c-201">検索と置換の機能が基本的なページ内検索機能と共に機能するようにする。</span><span class="sxs-lookup"><span data-stu-id="0f42c-201">Find-and-replace functionality should work alongside the basic find-in-page functionality.</span></span> <span data-ttu-id="0f42c-202">検索と置換の機能があるアプリでは、ページ内検索が検索と置換の機能の妨げにならないようにします。</span><span class="sxs-lookup"><span data-stu-id="0f42c-202">For apps that have find-and-replace, ensure that find-in-page doesn't interfere with find-and-replace functionality.</span></span>

-   <span data-ttu-id="0f42c-203">ページ上にあるテキスト一致数をユーザーに示すために、一致カウンターを追加します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-203">Include a match counter to indicate to the user the number of text matches there are on the page.</span></span>
-   <span data-ttu-id="0f42c-204">キーボード ショートカット (Ctrl + F) を有効にする。</span><span class="sxs-lookup"><span data-stu-id="0f42c-204">Enable the keyboard shortcut (CTRL+F).</span></span>

## <a name="examples"></a><span data-ttu-id="0f42c-205">例</span><span class="sxs-lookup"><span data-stu-id="0f42c-205">Examples</span></span>


<span data-ttu-id="0f42c-206">ページ内検索機能にアクセスする簡単な方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-206">Provide an easy way to access the find-in-page feature.</span></span> <span data-ttu-id="0f42c-207">ここに示すモバイル UI の例では、展開可能なメニューで、2 つの追加コマンドの後に [ページ内を検索] が表示されています。</span><span class="sxs-lookup"><span data-stu-id="0f42c-207">In this example on a mobile UI, "Find on page" appears after two "Add to..." commands in an expandable menu:</span></span>

![ページ内検索の例 1](images/findinpage-01.png)

 

<span data-ttu-id="0f42c-209">ユーザーは、[ページ内を検索] を選択してから検索語句を入力します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-209">After selecting find-in-page, the user enters a search term.</span></span> <span data-ttu-id="0f42c-210">検索語句の入力中に、テキスト入力候補を表示できます。</span><span class="sxs-lookup"><span data-stu-id="0f42c-210">Text suggestions can appear when a search term is being entered:</span></span>

![ページ内検索の例 2](images/findinpage-02.png)

 

<span data-ttu-id="0f42c-212">検索で一致するテキストがなかった場合は、結果ボックスに "検索結果が見つかりませんでした" というテキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-212">If there isn't a text match in the search, a "No results" text string should appear in the results box:</span></span>

![ページ内検索の例 3](images/findinpage-03.png)

 

<span data-ttu-id="0f42c-214">検索で一致するテキストがあった場合は、最初の語句を区別できる色で強調表示します。以降の一致は、例に示されているように、同じカラー パレットのもう少し淡いトーンで強調表示します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-214">If there is a text match in the search, the first term should be highlighted in a distinct color, with succeeding matches in a more subtle tone of that same color palette, as seen in this example:</span></span>

![ページ内検索の例 4](images/findinpage-04.png)

 

<span data-ttu-id="0f42c-216">ページ内検索には、一致カウンターがあります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-216">Find-in-page has a match counter:</span></span>

![ページ内検索の一致カウンターの例](images/findinpage-counter.png)




## **<a name="implementing-find-in-page"></a><span data-ttu-id="0f42c-218">ページ内検索の実装</span><span class="sxs-lookup"><span data-stu-id="0f42c-218">Implementing find-in-page</span></span>**

-   <span data-ttu-id="0f42c-219">ドキュメント ビューアー、リーダー、ブラウザーは、ページ内検索が提供される最も一般的なアプリの種類であり、全画面での表示/読み取りエクスペリエンスをユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="0f42c-219">Document viewers, readers, and browsers are the likeliest app types to provide find-in-page, and enable the user to have a full screen viewing/reading experience.</span></span>
-   <span data-ttu-id="0f42c-220">ページ内検索機能は補助的な機能であり、コマンド バーに配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f42c-220">Find-in-page functionality is secondary and should be located in a command bar.</span></span>

<span data-ttu-id="0f42c-221">コマンドをコマンド バーに追加する方法について詳しくは、「[コマンド バー](app-bars.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f42c-221">For more info about adding commands to your command bar, see [Command bar](app-bars.md).</span></span>

 


## <a name="related-articles"></a><span data-ttu-id="0f42c-222">関連記事</span><span class="sxs-lookup"><span data-stu-id="0f42c-222">Related articles</span></span>

* [<span data-ttu-id="0f42c-223">自動提案ボックス</span><span class="sxs-lookup"><span data-stu-id="0f42c-223">Auto-suggest box</span></span>](auto-suggest-box.md)


 

 
