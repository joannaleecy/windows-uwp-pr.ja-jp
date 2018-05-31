---
author: stevewhims
Description: When a resource is requested, there may be several candidates that match the current resource context to some degree. The Resource Management System will analyze all of the candidates and determine the best candidate to return. This topic describes that process in detail and gives examples.
title: リソース管理システムでのリソースの照合と選択の仕組み
template: detail.hbs
ms.author: stwhi
ms.date: 10/23/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: bb1168401aaa715f8d1c459691dfa1b1ca38ccbe
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1690428"
---
# <a name="how-the-resource-management-system-matches-and-chooses-resources"></a><span data-ttu-id="46197-103">リソース管理システムでのリソースの照合と選択の仕組み</span><span class="sxs-lookup"><span data-stu-id="46197-103">How the Resource Management System matches and chooses resources</span></span>
<span data-ttu-id="46197-104">リソースを要求すると、現在のリソース コンテキストにある程度一致するリソース候補がいくつか存在する場合があります。</span><span class="sxs-lookup"><span data-stu-id="46197-104">When a resource is requested, there may be several candidates that match the current resource context to some degree.</span></span> <span data-ttu-id="46197-105">リソース管理システムはすべての候補を分析して、返すのに最もよい候補を決定します。</span><span class="sxs-lookup"><span data-stu-id="46197-105">The Resource Management System will analyze all of the candidates and determine the best candidate to return.</span></span> <span data-ttu-id="46197-106">これはすべての修飾子を考慮して、すべての候補をランク付けすることで実行されます。</span><span class="sxs-lookup"><span data-stu-id="46197-106">This is done by taking all qualifiers into consideration to rank all of the candidates.</span></span>

<span data-ttu-id="46197-107">このランク付けプロセスでは、修飾子が異なれば優先順位も異なります。言語は全体のランキングに最大の影響を及ぼし、コントラスト、スケールなどが続きます。</span><span class="sxs-lookup"><span data-stu-id="46197-107">In this ranking process, the different qualifiers are given different priorities: language has the greatest impact on the overall ranking, followed by contrast, then scale, and so on.</span></span> <span data-ttu-id="46197-108">修飾子ごとに、候補の修飾子がコンテキスト修飾子の値と比較され、一致度が決定されます。</span><span class="sxs-lookup"><span data-stu-id="46197-108">For each qualifier, candidate qualifiers are compared with the context qualifier value to determine a quality of match.</span></span> <span data-ttu-id="46197-109">どのように比較がなされるかは、修飾子に左右されます。</span><span class="sxs-lookup"><span data-stu-id="46197-109">How the comparison is done depends upon the qualifier.</span></span>

<span data-ttu-id="46197-110">言語タグの照合のしくみの詳細については、「[リソース管理システムでの言語タグの照合の仕組み](how-rms-matches-lang-tags.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="46197-110">For specific details on how language tag matching is done, see [How the Resource Management System matches language tags](how-rms-matches-lang-tags.md).</span></span>

<span data-ttu-id="46197-111">スケールやコントラストのような修飾子の場合、常に最低限の一致が存在します。</span><span class="sxs-lookup"><span data-stu-id="46197-111">For some qualifiers, such as scale and contrast, there is always some minimal degree of match.</span></span> <span data-ttu-id="46197-112">たとえば、"scale-400" というコンテキストに対して、"scale-100" で修飾された候補は、"scale-200" または (完全一致の) "scale-400" で修飾された候補ほどではなくても、ある程度は一致します。</span><span class="sxs-lookup"><span data-stu-id="46197-112">For example, a candidate qualified for "scale-100" matches a context of "scale-400" to some small degree, albeit not as well as a candidate qualified for "scale-200" or (for a perfect match) "scale-400".</span></span>

<span data-ttu-id="46197-113">しかし、言語や住んでいる地域のような修飾子の場合、比較してもまったく一致しないことがあります (ある程度の一致の他に)。</span><span class="sxs-lookup"><span data-stu-id="46197-113">For other qualifiers, however, such as language or home region, it is possible to have a non-match comparison (as well as degrees of matching).</span></span> <span data-ttu-id="46197-114">たとえば、言語が "en-US" で修飾された候補は、"en-GB" というコンテキストに対して部分的に一致しますが、"fr" で修飾された候補はまったく一致しません。</span><span class="sxs-lookup"><span data-stu-id="46197-114">For example, a candidate qualified for language as "en-US" is a partial match for a context of "en-GB", but a candidate qualified as "fr" is not a match at all.</span></span> <span data-ttu-id="46197-115">同様に、住んでいる地域が "155" (西欧) で修飾された候補は、住んでいる地域の設定が "FR" のユーザーのコンテキストにある程度一致しますが、"US" で修飾された候補はまったく一致しません。</span><span class="sxs-lookup"><span data-stu-id="46197-115">Similarly, a candidate qualified for home region as "155" (Western Europe) matches a context for a user with a home region setting of "FR" somewhat well, but a candidate qualified as "US" does not match at all.</span></span>

<span data-ttu-id="46197-116">候補を評価するとき、比較してもまったく一致しない修飾子がある場合、その候補は全体としてのランキングが非一致となり、選ばれることはありません。</span><span class="sxs-lookup"><span data-stu-id="46197-116">When a candidate is evaluated, if there is a non-match comparison for any qualifier, then that candidate will get an overall non-match ranking and will not be selected.</span></span> <span data-ttu-id="46197-117">このようにして、最適な一致を選ぶときに優先順位の高い修飾子に最大の重みが与えられますが、優先順位が低い修飾子の場合でも、非一致によって候補から除外されることはあります。</span><span class="sxs-lookup"><span data-stu-id="46197-117">In this way, the higher-priority qualifiers can have the greatest weight in selecting the best match, but even a low-priority qualifier can eliminate a candidate due to a non-match.</span></span>

<span data-ttu-id="46197-118">ある修飾子でまったくマークされていない場合、候補はその修飾子に関しては中立です。</span><span class="sxs-lookup"><span data-stu-id="46197-118">A candidate is neutral in relation to a qualifier if it is not marked for that qualifier at all.</span></span> <span data-ttu-id="46197-119">どの修飾子でも、中立の候補は常にコンテキスト修飾子の値に一致しますが、その修飾子でマークされ、ある程度の一致 (厳密または部分) の候補よりも一致度は低くなります。</span><span class="sxs-lookup"><span data-stu-id="46197-119">For any qualifier, a neutral candidate is always a match for the context qualifier value, but only with a lower quality of match than any candidate that was marked for that qualifier and has some degree of match (exact or partial).</span></span> <span data-ttu-id="46197-120">たとえば、"en-US"、"en"、"fr" で修飾された候補があり、言語中立のリソースもある場合、言語修飾子の値が "en-GB" のコンテキストでは、各候補は、"en"、"en-US"、中立、"fr" の順にランク付けされます。</span><span class="sxs-lookup"><span data-stu-id="46197-120">For example, if we have candidates qualified for "en-US", "en", "fr", and also a language-neutral candidate, then for a context with a language qualifier value of "en-GB", the candidates will be ranked in the following order: "en", "en-US", neutral, and "fr".</span></span> <span data-ttu-id="46197-121">この場合、"fr" はまったく一致しませんが、他の候補はある程度一致しています。</span><span class="sxs-lookup"><span data-stu-id="46197-121">In this case, "fr" does not match at all, while the other candidates match to some degree.</span></span>

<span data-ttu-id="46197-122">全体的なランク付けプロセスは、優先順位の最も高い修飾子である言語に関する候補の評価から始まります。</span><span class="sxs-lookup"><span data-stu-id="46197-122">The overall ranking process begins by evaluating candidates in relation to the highest-priority qualifier, which is language.</span></span> <span data-ttu-id="46197-123">非一致は除外されます。</span><span class="sxs-lookup"><span data-stu-id="46197-123">Non-matches are eliminated.</span></span> <span data-ttu-id="46197-124">残りの候補は、言語の一致度に応じてランク付けされます。</span><span class="sxs-lookup"><span data-stu-id="46197-124">The remaining candidates are ranked in relation to their quality of match for language.</span></span> <span data-ttu-id="46197-125">ランクが同じ場合、次に優先順位の高い修飾子であるコントラストが検討され、コントラストの一致度を使って、ランクの同じ候補が区別されます。</span><span class="sxs-lookup"><span data-stu-id="46197-125">If there are any ties, then the next-highest-priority qualifier, contrast, is considered, using the quality of match for contrast to differentiate among tied candidates.</span></span> <span data-ttu-id="46197-126">コントラストの後は、スケールの修飾子が残りの区別に使われます。同様にして、ランキングの順位が確定するまで、必要なだけ修飾子が比較されます。</span><span class="sxs-lookup"><span data-stu-id="46197-126">After contrast, the scale qualifier is used to differentiate remaining ties, and so on through as many qualifiers as are needed to arrive at a well-ordered ranking.</span></span>

<span data-ttu-id="46197-127">修飾子がコンテキストに一致しないためすべての候補が検討対象から除外された場合、リソース ローダーは、2 番目のパスに移行して、表示する既定の候補を検索します。</span><span class="sxs-lookup"><span data-stu-id="46197-127">If all candidates are removed from consideration due to qualifiers that don't match the context, the resource loader goes through a second pass looking for a default candidate to display.</span></span> <span data-ttu-id="46197-128">既定の候補は、PRI ファイルの作成時に決定され、どのランタイム コンテキストでも選択候補が常に残るようにするために必要です。</span><span class="sxs-lookup"><span data-stu-id="46197-128">Default candidates are determined during creation of the PRI file and are required to ensure there is always some candidate to select for any runtime context.</span></span> <span data-ttu-id="46197-129">候補が持ついずれかの修飾子が一致せず、既定値でない場合、そのリソース候補は完全に検討対象から除外されます。</span><span class="sxs-lookup"><span data-stu-id="46197-129">If a candidate has any qualifiers that don't match and aren't a default, that resource candidate is thrown permanently out of consideration.</span></span>

<span data-ttu-id="46197-130">検討対象として残っているすべてのリソース候補に対し、リソース ローダーは優先順位が最も高いコンテキスト修飾子の値に基づき、最も一致するものまたは既定のスコアが最も一致するものを選びます。</span><span class="sxs-lookup"><span data-stu-id="46197-130">For all the resource candidates still in consideration, the resource loader looks at the highest-priority context qualifier value and chooses the one that has the best match or best default score.</span></span> <span data-ttu-id="46197-131">実際に一致する値は、既定のスコアよりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="46197-131">Any actual match is considered better than a default score.</span></span>

<span data-ttu-id="46197-132">一致度が同じ場合、次に優先順位が高いコンテキスト修飾子の値が調べられます。最も一致するものが見つかるまで、この操作が続けられます。</span><span class="sxs-lookup"><span data-stu-id="46197-132">If there is a tie, the next-highest priority context qualifier value is inspected and the process continues, until a best match is found.</span></span>

## <a name="example-of-choosing-a-resource-candidate"></a><span data-ttu-id="46197-133">リソース候補を選択する例</span><span class="sxs-lookup"><span data-stu-id="46197-133">Example of choosing a resource candidate</span></span>
<span data-ttu-id="46197-134">次のようなファイルがあるとします。</span><span class="sxs-lookup"><span data-stu-id="46197-134">Consider these files.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
fr/images/contrast-high/logo.scale-400.jpg
fr/images/contrast-high/logo.scale-100.jpg
de/images/logo.jpg
```

<span data-ttu-id="46197-135">また、現在のコンテキストの設定は次のようになっているとします。</span><span class="sxs-lookup"><span data-stu-id="46197-135">And suppose that these are the settings in the current context.</span></span>

```
Application language: en-US; fr-FR;
Scale: 400
Contrast: Standard
```

<span data-ttu-id="46197-136">ハイ コントラストとドイツ語はこの設定に定義されているコンテキストに一致しないため、リソース管理システムによって 3 つのファイルが除外されます。</span><span class="sxs-lookup"><span data-stu-id="46197-136">The Resource Management System eliminates three of the files, because high contrast and the German language do not match the context defined by the settings.</span></span> <span data-ttu-id="46197-137">これによって、次の候補が残ります。</span><span class="sxs-lookup"><span data-stu-id="46197-137">That leaves these candidates.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
```

<span data-ttu-id="46197-138">これらの残りの候補について、リソース管理システムは、優先度が最も高いコンテキスト修飾子である言語を使用します。</span><span class="sxs-lookup"><span data-stu-id="46197-138">For those remaining candidates, the Resource Management System uses the highest-priority context qualifier, which is language.</span></span> <span data-ttu-id="46197-139">設定で英語がフランス語よりも先にリストされているため、英語のリソースはフランス語のリソースよりも一致率が高くなります。</span><span class="sxs-lookup"><span data-stu-id="46197-139">The English resources are a closer match than the French ones because English is listed before French in the settings.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
```

<span data-ttu-id="46197-140">次に、リソース管理システムでは、次に優先順位の高いコンテキスト修飾子であるスケールを使用します。</span><span class="sxs-lookup"><span data-stu-id="46197-140">Next, the Resource Management System uses the next-highest priority context qualifier, scale.</span></span> <span data-ttu-id="46197-141">このため、次のリソースが返されます。</span><span class="sxs-lookup"><span data-stu-id="46197-141">So this is the resource returned.</span></span>

```
en/images/logo.scale-400.jpg
```

<span data-ttu-id="46197-142">高度な [**NamedResource.ResolveAll**](/uwp/api/windows.applicationmodel.resources.core.namedresource.resolveall?branch=live) メソッドを使うと、コンテキスト設定に一致する順にすべての候補を取得できます。</span><span class="sxs-lookup"><span data-stu-id="46197-142">You can use the advanced [**NamedResource.ResolveAll**](/uwp/api/windows.applicationmodel.resources.core.namedresource.resolveall?branch=live) method to retrieve all of the candidates in the order that they match the context settings.</span></span> <span data-ttu-id="46197-143">前述の例では、**ResolveAll** は次の順序で候補を返します。</span><span class="sxs-lookup"><span data-stu-id="46197-143">For the example we just walked through, **ResolveAll** returns candidates in this order.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
```

## <a name="example-of-producing-a-fallback-choice"></a><span data-ttu-id="46197-144">フォールバック選択肢を生成する例</span><span class="sxs-lookup"><span data-stu-id="46197-144">Example of producing a fallback choice</span></span>
<span data-ttu-id="46197-145">次のようなファイルがあるとします。</span><span class="sxs-lookup"><span data-stu-id="46197-145">Consider these files.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/contrast-standard/logo.scale-400.jpg
fr/images/contrast-standard/logo.scale-100.jpg
de/images/contrast-standard/logo.jpg
```

<span data-ttu-id="46197-146">また、現在のコンテキストの設定は次のようになっているとします。</span><span class="sxs-lookup"><span data-stu-id="46197-146">And suppose that these are the settings in the current context.</span></span>

```
User language: de-DE;
Scale: 400
Contrast: High
```

<span data-ttu-id="46197-147">すべてのファイルがコンテキストに一致しないため、除外されます。</span><span class="sxs-lookup"><span data-stu-id="46197-147">All the files are eliminated because they do not match the context.</span></span> <span data-ttu-id="46197-148">そこで、既定のパスが使われます。PRI ファイルの作成時の既定値は次のようになっていました (「[MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="46197-148">So we enter a default pass, where the default (see [Compile resources manually with MakePri.exe](compile-resources-manually-with-makepri.md)) during creation of the PRI file was this.</span></span>

```
Language: fr-FR;
Scale: 400
Contrast: Standard
```

<span data-ttu-id="46197-149">これにより、現在のユーザーまたは既定値に一致するすべてのリソースが候補となります。</span><span class="sxs-lookup"><span data-stu-id="46197-149">This leaves all the resources that match either the current user or the default.</span></span>

```
fr/images/contrast-standard/logo.scale-400.jpg
fr/images/contrast-standard/logo.scale-100.jpg
de/images/contrast-standard/logo.jpg
```

<span data-ttu-id="46197-150">リソース管理システムは、優先順位が最も高いコンテキスト修飾子である言語を使って、スコアが最も高い名前付きリソースを返します。</span><span class="sxs-lookup"><span data-stu-id="46197-150">The Resource Management System uses the highest-priority context qualifier, language, to return the named resource with the highest score.</span></span>

```
de/images/contrast-standard/logo.jpg
```

## <a name="important-apis"></a><span data-ttu-id="46197-151">重要な API</span><span class="sxs-lookup"><span data-stu-id="46197-151">Important APIs</span></span>
* [<span data-ttu-id="46197-152">NamedResource.ResolveAll</span><span class="sxs-lookup"><span data-stu-id="46197-152">NamedResource.ResolveAll</span></span>](/uwp/api/windows.applicationmodel.resources.core.namedresource.resolveall?branch=live)

## <a name="related-topics"></a><span data-ttu-id="46197-153">関連トピック</span><span class="sxs-lookup"><span data-stu-id="46197-153">Related topics</span></span>
* [<span data-ttu-id="46197-154">MakePri.exe を使用して手動でリソースをコンパイルする</span><span class="sxs-lookup"><span data-stu-id="46197-154">Compile resources manually with MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)