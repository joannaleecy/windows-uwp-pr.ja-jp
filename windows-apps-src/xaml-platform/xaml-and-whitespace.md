---
author: jwmsft
description: XAML で使われる空白処理規則について説明します。
title: XAML と空白
ms.assetid: 025F4A8E-9479-4668-8AFD-E20E7262DC24
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 560f820ec2ecc7f28145ec29c31a60c1e4573d7e
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5766023"
---
# <a name="xaml-and-whitespace"></a><span data-ttu-id="adde3-104">XAML と空白</span><span class="sxs-lookup"><span data-stu-id="adde3-104">XAML and whitespace</span></span>


<span data-ttu-id="adde3-105">XAML で使われる空白処理規則について説明します。</span><span class="sxs-lookup"><span data-stu-id="adde3-105">Learn about the whitespace processing rules as used by XAML.</span></span>

## <a name="whitespace-processing"></a><span data-ttu-id="adde3-106">空白処理</span><span class="sxs-lookup"><span data-stu-id="adde3-106">Whitespace processing</span></span>

<span data-ttu-id="adde3-107">XML で一貫性のある、XAML での空白文字領域とは、改行、タブです。これらはそれぞれ Unicode 値 0020、000 a、0009 になります。</span><span class="sxs-lookup"><span data-stu-id="adde3-107">Consistent with XML, whitespace characters in XAML are space, linefeed, and tab. These correspond to the Unicode values 0020, 000A, and 0009 respectively.</span></span> <span data-ttu-id="adde3-108">既定では、XAML プロセッサが XAML ファイル内の要素間にある内部テキストを検出すると、この空白の正規化が行われます。</span><span class="sxs-lookup"><span data-stu-id="adde3-108">By default this whitespace normalization occurs when a XAML processor encounters any inner text found between elements in a XAML file:</span></span>

-   <span data-ttu-id="adde3-109">東アジアの文字間の改行文字は削除されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-109">Linefeed characters between East Asian characters are removed.</span></span>
-   <span data-ttu-id="adde3-110">すべての空白文字 (スペース、改行、タブ) はスペースに変換されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-110">All whitespace characters (space, linefeed, tab) are converted into spaces.</span></span>
-   <span data-ttu-id="adde3-111">連続した複数のスペースはすべて削除され、1 つのスペースに置換されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-111">All consecutive spaces are deleted and replaced by one space.</span></span>
-   <span data-ttu-id="adde3-112">開始タグの直後にあるスペースは削除されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-112">A space immediately following the start tag is deleted.</span></span>
-   <span data-ttu-id="adde3-113">終了タグの直前にあるスペースは削除されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-113">A space immediately before the end tag is deleted.</span></span>
-   <span data-ttu-id="adde3-114">*東アジアの文字*は、Unicode 文字範囲 U+20000 から U+2FFFD と U+30000 から U+3FFFD のセットとして定義されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-114">*East Asian characters* is defined as a set of Unicode character ranges U+20000 to U+2FFFD and U+30000 to U+3FFFD.</span></span> <span data-ttu-id="adde3-115">このサブセットは *CJK 漢字*とも呼ばれることもあります。</span><span class="sxs-lookup"><span data-stu-id="adde3-115">This subset is also sometimes referred to as *CJK ideographs*.</span></span> <span data-ttu-id="adde3-116">詳細については、次を参照してください。http://www.unicode.orgします。</span><span class="sxs-lookup"><span data-stu-id="adde3-116">For more information, see http://www.unicode.org.</span></span>

<span data-ttu-id="adde3-117">"既定" とは、**xml:space** 属性の既定値によって示される状態に相当します。</span><span class="sxs-lookup"><span data-stu-id="adde3-117">"Default" corresponds to the state denoted by the default value of the **xml:space** attribute.</span></span>

### <a name="whitespace-in-inner-text-and-string-primitives"></a><span data-ttu-id="adde3-118">内部テキスト内の空白と文字列のプリミティブ</span><span class="sxs-lookup"><span data-stu-id="adde3-118">Whitespace in inner text, and string primitives</span></span>

<span data-ttu-id="adde3-119">上で説明した正規化規則は、XAML 要素内の内部テキストに適用されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-119">The above normalization rules apply to inner text within XAML elements.</span></span> <span data-ttu-id="adde3-120">正規化の後、XAML プロセッサが次のように内部テキストを適切な型に変換します。</span><span class="sxs-lookup"><span data-stu-id="adde3-120">After normalization, a XAML processor converts any inner text into an appropriate type like this:</span></span>

-   <span data-ttu-id="adde3-121">プロパティの型がコレクションではないが、直接的には **Object** 型ではない場合、XAML プロセッサは型コンバーターを使って型の変換を試みます。</span><span class="sxs-lookup"><span data-stu-id="adde3-121">If the type of the property is not a collection, but is not directly an **Object** type, the XAML processor tries to convert to that type using its type converter.</span></span> <span data-ttu-id="adde3-122">ここで変換が失敗すると、XAML 解析エラーになります。</span><span class="sxs-lookup"><span data-stu-id="adde3-122">A failed conversion here results in a XAML parse error.</span></span>
-   <span data-ttu-id="adde3-123">プロパティの型がコレクションで、内部テキストが連続的である (介在する要素タグがない) 場合、内部テキストは単一の **String** として解析されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-123">If the type of the property is a collection, and the inner text is contiguous (no intervening element tags), the inner text is parsed as a single **String**.</span></span> <span data-ttu-id="adde3-124">コレクションの型で **String** が許容されていない場合も、XAML 解析エラーになります。</span><span class="sxs-lookup"><span data-stu-id="adde3-124">If the collection type cannot accept **String**, this also results in a XAML parser error.</span></span>
-   <span data-ttu-id="adde3-125">プロパティの型が **Object** である場合、内部テキストは単一の **String** として解析されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-125">If the type of the property is **Object**, then the inner text is parsed as a single **String**.</span></span> <span data-ttu-id="adde3-126">介在する要素タグが存在する場合、XAML 解析エラーになります。これは、**Object** 型が単一のオブジェクト (**String** など) を前提としているためです。</span><span class="sxs-lookup"><span data-stu-id="adde3-126">If there are intervening element tags, this results in a XAML parser error, because the **Object** type implies a single object (**String** or otherwise).</span></span>
-   <span data-ttu-id="adde3-127">プロパティの型がコレクションであり、内部テキストが連続していない場合、最初の部分文字列が **String** に変換され、コレクション項目として追加されます。介在する要素は、コレクション項目として追加されます。最後に終了の部分文字列 (ある場合) が 3 番目の **String** 項目としてコレクションに追加されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-127">If the type of the property is a collection, and the inner text is not contiguous, then the first substring is converted into a **String** and added as a collection item, the intervening element is added as a collection item, and finally the trailing substring (if any) is added to the collection as a third **String** item.</span></span>

### <a name="whitespace-and-text-content-models"></a><span data-ttu-id="adde3-128">空白とテキスト コンテンツのモデル</span><span class="sxs-lookup"><span data-stu-id="adde3-128">Whitespace and text content models</span></span>

<span data-ttu-id="adde3-129">空白の保持は、実際には、考えられるすべてのコンテンツ モデルのサブセットに関してのみ関係するものです。</span><span class="sxs-lookup"><span data-stu-id="adde3-129">In practice, preserving whitespace is of concern only for a subset of all possible content models.</span></span> <span data-ttu-id="adde3-130">このサブセットは、特定の形式で単一の **String** 型を取ることができるコンテンツ モデルで構成されます。専用の **String** コレクション、**String** と一覧に記載されている他の型の混合、コレクション、または辞書で構成されます。</span><span class="sxs-lookup"><span data-stu-id="adde3-130">That subset is composed of content models that can take a singleton **String** type in some form, a dedicated **String** collection, or a mixture of **String** and other types in lists, collections, or dictionaries.</span></span>

<span data-ttu-id="adde3-131">文字列を使うことができるコンテンツ モデルの場合でも、これらのコンテンツ モデル内での既定の動作では、残される空白は重要なものとしては扱われません。</span><span class="sxs-lookup"><span data-stu-id="adde3-131">Even for content models that can take strings, the default behavior within these content models is that any whitespace that remains is not treated as significant.</span></span>

### <a name="preserving-whitespace"></a><span data-ttu-id="adde3-132">空白の保持</span><span class="sxs-lookup"><span data-stu-id="adde3-132">Preserving whitespace</span></span>

<span data-ttu-id="adde3-133">最終的な表示に関して、ソース XAML 内の空白を保持するためのいくつかの手法は XAML プロセッサによる空白の正規化の影響を受けません。</span><span class="sxs-lookup"><span data-stu-id="adde3-133">Several techniques for preserving whitespace in the source XAML for eventual presentation are not affected by XAML processor whitespace normalization.</span></span>

`xml:space="preserve"`<span data-ttu-id="adde3-134">: この属性は、空白を保持する必要がある要素のレベルで指定します。</span><span class="sxs-lookup"><span data-stu-id="adde3-134">: Specify this attribute at the level of the element where whitespace needs to be preserved.</span></span> <span data-ttu-id="adde3-135">これを指定すると、見た目に直感的な入れ子としてマークアップ要素を配置するためにコード エディターまたはデザイン サーフェイスによって追加される場合があるスペースも含め、すべての空白が保持されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="adde3-135">Note that this preserves all whitespace, including the spaces that might be added by code editors or design surfaces to align markup elements as a visually intuitive nesting.</span></span> <span data-ttu-id="adde3-136">これらのスペースのレンダリングは、包含要素のコンテンツ モデルの問題でもあります。</span><span class="sxs-lookup"><span data-stu-id="adde3-136">Whether those spaces render is again a matter of the content model for the containing element.</span></span> <span data-ttu-id="adde3-137">ルート レベルで `xml:space="preserve"` を指定することはお勧めしません。大半のオブジェクト モデルは、いずれにしても空白を重要なものと見なしていないためです。</span><span class="sxs-lookup"><span data-stu-id="adde3-137">We don't recommend that you specify `xml:space="preserve"` at the root level, because the majority of object models don't consider whitespace as significant one way or another.</span></span> <span data-ttu-id="adde3-138">文字列内で空白をレンダリングする要素、または空白が重要となるコレクションである要素のレベルに限定してこの属性を設定することが、より適切な方法です。</span><span class="sxs-lookup"><span data-stu-id="adde3-138">It is a better practice to only set the attribute specifically at the level of elements that render whitespace within strings, or are whitespace significant collections.</span></span>

<span data-ttu-id="adde3-139">エンティティと改行なしスペース: XAML は、テキスト オブジェクト モデル内への任意の Unicode エンティティの配置をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="adde3-139">Entities and nonbreaking spaces: XAML supports placing any Unicode entity within a text object model.</span></span> <span data-ttu-id="adde3-140">(UTF-8 エンコードでの) 改行なしスペースなど、専用のエンティティを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="adde3-140">You can use dedicated entities such as nonbreaking space (in UTF-8 encoding).</span></span> <span data-ttu-id="adde3-141">また、改行なしスペース文字をサポートするリッチ テキスト コントロールも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="adde3-141">You can also use rich text controls that support nonbreaking space characters.</span></span> <span data-ttu-id="adde3-142">インデントなどのレイアウト特性をシミュレートするのにエンティティを使っている場合は注意が必要です。その理由は、エンティティの実行時出力は、パネルや余白の適切な使用など、一般的なレイアウト機能よりも、数が多いほうの要因によって変わるためです。</span><span class="sxs-lookup"><span data-stu-id="adde3-142">Be cautious if you are using entities to simulate layout characteristics such as indents, because the run-time output of the entities vary based on a greater number of factors than would the general layout facilities, such as proper use of panels and margins.</span></span>

