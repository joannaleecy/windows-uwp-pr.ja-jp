---
author: stevewhims
Description: "リソースを要求すると、現在のリソース コンテキストにある程度一致するリソース候補がいくつか存在する場合があります。 リソース管理システムはすべての候補を分析して、返すのに最もよい候補を決定します。 このトピックでは、そのプロセスの詳細について説明し、例を示します。"
title: "リソース管理システムでのリソースの照合と選択の仕組み"
template: detail.hbs
ms.author: stwhi
ms.date: 10/23/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子"
localizationpriority: medium
ms.openlocfilehash: 4731ae7add7d5b969ab98da60b3f6740dbbbee1b
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

# <a name="how-the-resource-management-system-matches-and-chooses-resources"></a><span data-ttu-id="0d22c-106">リソース管理システムでのリソースの照合と選択の仕組み</span><span class="sxs-lookup"><span data-stu-id="0d22c-106">How the Resource Management System matches and chooses resources</span></span>

<span data-ttu-id="0d22c-107">リソースを要求すると、現在のリソース コンテキストにある程度一致するリソース候補がいくつか存在する場合があります。</span><span class="sxs-lookup"><span data-stu-id="0d22c-107">When a resource is requested, there may be several candidates that match the current resource context to some degree.</span></span> <span data-ttu-id="0d22c-108">リソース管理システムはすべての候補を分析して、返すのに最もよい候補を決定します。</span><span class="sxs-lookup"><span data-stu-id="0d22c-108">The Resource Management System will analyze all of the candidates and determine the best candidate to return.</span></span> <span data-ttu-id="0d22c-109">これはすべての修飾子を考慮して、すべての候補をランク付けすることで実行されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-109">This is done by taking all qualifiers into consideration to rank all of the candidates.</span></span>

<span data-ttu-id="0d22c-110">このランク付けプロセスでは、修飾子が異なれば優先順位も異なります。言語は全体のランキングに最大の影響を及ぼし、コントラスト、スケールなどが続きます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-110">In this ranking process, the different qualifiers are given different priorities: language has the greatest impact on the overall ranking, followed by contrast, then scale, and so on.</span></span> <span data-ttu-id="0d22c-111">修飾子ごとに、候補の修飾子がコンテキスト修飾子の値と比較され、一致度が決定されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-111">For each qualifier, candidate qualifiers are compared with the context qualifier value to determine a quality of match.</span></span> <span data-ttu-id="0d22c-112">どのように比較がなされるかは、修飾子に左右されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-112">How the comparison is done depends upon the qualifier.</span></span>

<span data-ttu-id="0d22c-113">スケールやコントラストのような修飾子の場合、常に最低限の一致が存在します。</span><span class="sxs-lookup"><span data-stu-id="0d22c-113">For some qualifiers, such as scale and contrast, there is always some minimal degree of match.</span></span> <span data-ttu-id="0d22c-114">たとえば、"scale-400" というコンテキストに対して、"scale-100" で修飾された候補は、"scale-200" または (完全一致の) "scale-400" で修飾された候補ほどではなくても、ある程度は一致します。</span><span class="sxs-lookup"><span data-stu-id="0d22c-114">For example, a candidate qualified for "scale-100" matches a context of "scale-400" to some small degree, albeit not as well as a candidate qualified for "scale-200" or (for a perfect match) "scale-400".</span></span>

<span data-ttu-id="0d22c-115">しかし、言語や住んでいる地域のような修飾子の場合、比較してもまったく一致しないことがあります (ある程度の一致の他に)。</span><span class="sxs-lookup"><span data-stu-id="0d22c-115">For other qualifiers, however, such as language or home region, it is possible to have a non-match comparison (as well as degrees of matching).</span></span> <span data-ttu-id="0d22c-116">たとえば、言語が "en-US" で修飾された候補は、"en-GB" というコンテキストに対して部分的に一致しますが、"fr" で修飾された候補はまったく一致しません。</span><span class="sxs-lookup"><span data-stu-id="0d22c-116">For example, a candidate qualified for language as "en-US" is a partial match for a context of "en-GB", but a candidate qualified as "fr" is not a match at all.</span></span> <span data-ttu-id="0d22c-117">同様に、住んでいる地域が "155" (西欧) で修飾された候補は、住んでいる地域の設定が "FR" のユーザーのコンテキストにある程度一致しますが、"US" で修飾された候補はまったく一致しません。</span><span class="sxs-lookup"><span data-stu-id="0d22c-117">Similarly, a candidate qualified for home region as "155" (Western Europe) matches a context for a user with a home region setting of "FR" somewhat well, but a candidate qualified as "US" does not match at all.</span></span>

<span data-ttu-id="0d22c-118">候補を評価するとき、比較してもまったく一致しない修飾子がある場合、その候補は全体としてのランキングが非一致となり、選ばれることはありません。</span><span class="sxs-lookup"><span data-stu-id="0d22c-118">When a candidate is evaluated, if there is a non-match comparison for any qualifier, then that candidate will get an overall non-match ranking and will not be selected.</span></span> <span data-ttu-id="0d22c-119">このようにして、最適な一致を選ぶときに優先順位の高い修飾子に最大の重みが与えられますが、優先順位が低い修飾子の場合でも、非一致によって候補から除外されることはあります。</span><span class="sxs-lookup"><span data-stu-id="0d22c-119">In this way, the higher-priority qualifiers can have the greatest weight in selecting the best match, but even a low-priority qualifier can eliminate a candidate due to a non-match.</span></span>

<span data-ttu-id="0d22c-120">ある修飾子でまったくマークされていない場合、候補はその修飾子に関しては中立です。</span><span class="sxs-lookup"><span data-stu-id="0d22c-120">A candidate is neutral in relation to a qualifier if it is not marked for that qualifier at all.</span></span> <span data-ttu-id="0d22c-121">どの修飾子でも、中立の候補は常にコンテキスト修飾子の値に一致しますが、その修飾子でマークされ、ある程度の一致 (厳密または部分) の候補よりも一致度は低くなります。</span><span class="sxs-lookup"><span data-stu-id="0d22c-121">For any qualifier, a neutral candidate is always a match for the context qualifier value, but only with a lower quality of match than any candidate that was marked for that qualifier and has some degree of match (exact or partial).</span></span> <span data-ttu-id="0d22c-122">たとえば、"en-US"、"en"、"fr" で修飾された候補があり、言語中立のリソースもある場合、言語修飾子の値が "en-GB" のコンテキストでは、各候補は、"en"、"en-US"、中立、"fr" の順にランク付けされます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-122">For example, if we have candidates qualified for "en-US", "en", "fr", and also a language-neutral candidate, then for a context with a language qualifier value of "en-GB", the candidates will be ranked in the following order: "en", "en-US", neutral, and "fr".</span></span> <span data-ttu-id="0d22c-123">この場合、"fr" はまったく一致しませんが、他の候補はある程度一致しています。</span><span class="sxs-lookup"><span data-stu-id="0d22c-123">In this case, "fr" does not match at all, while the other candidates match to some degree.</span></span>

<span data-ttu-id="0d22c-124">全体的なランク付けプロセスは、優先順位の最も高い修飾子である言語に関する候補の評価から始まります。</span><span class="sxs-lookup"><span data-stu-id="0d22c-124">The overall ranking process begins by evaluating candidates in relation to the highest-priority qualifier, which is language.</span></span> <span data-ttu-id="0d22c-125">非一致は除外されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-125">Non-matches are eliminated.</span></span> <span data-ttu-id="0d22c-126">残りの候補は、言語の一致度に応じてランク付けされます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-126">The remaining candidates are ranked in relation to their quality of match for language.</span></span> <span data-ttu-id="0d22c-127">ランクが同じ場合、次に優先順位の高い修飾子であるコントラストが検討され、コントラストの一致度を使って、ランクの同じ候補が区別されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-127">If there are any ties, then the next-highest-priority qualifier, contrast, is considered, using the quality of match for contrast to differentiate among tied candidates.</span></span> <span data-ttu-id="0d22c-128">コントラストの後は、スケールの修飾子が残りの区別に使われます。同様にして、ランキングの順位が確定するまで、必要なだけ修飾子が比較されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-128">After contrast, the scale qualifier is used to differentiate remaining ties, and so on through as many qualifiers as are needed to arrive at a well-ordered ranking.</span></span>

<span data-ttu-id="0d22c-129">修飾子がコンテキストに一致しないためすべての候補が検討対象から除外された場合、リソース ローダーは、2 番目のパスに移行して、表示する既定の候補を検索します。</span><span class="sxs-lookup"><span data-stu-id="0d22c-129">If all candidates are removed from consideration due to qualifiers that don't match the context, the resource loader goes through a second pass looking for a default candidate to display.</span></span> <span data-ttu-id="0d22c-130">既定の候補は、PRI ファイルの作成時に決定され、どのランタイム コンテキストでも選択候補が常に残るようにするために必要です。</span><span class="sxs-lookup"><span data-stu-id="0d22c-130">Default candidates are determined during creation of the PRI file and are required to ensure there is always some candidate to select for any runtime context.</span></span> <span data-ttu-id="0d22c-131">候補が持ついずれかの修飾子が一致せず、既定値でない場合、そのリソース候補は完全に検討対象から除外されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-131">If a candidate has any qualifiers that don't match and aren't a default, that resource candidate is thrown permanently out of consideration.</span></span>

<span data-ttu-id="0d22c-132">検討対象として残っているすべてのリソース候補に対し、リソース ローダーは優先順位が最も高いコンテキスト修飾子の値に基づき、最も一致するものまたは既定のスコアが最も一致するものを選びます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-132">For all the resource candidates still in consideration, the resource loader looks at the highest-priority context qualifier value and chooses the one that has the best match or best default score.</span></span> <span data-ttu-id="0d22c-133">実際に一致する値は、既定のスコアよりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-133">Any actual match is considered better than a default score.</span></span>

<span data-ttu-id="0d22c-134">一致度が同じ場合、次に優先順位が高いコンテキスト修飾子の値が調べられます。最も一致するものが見つかるまで、この操作が続けられます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-134">If there is a tie, the next-highest priority context qualifier value is inspected and the process continues, until a best match is found.</span></span>

## <a name="example-of-choosing-a-resource-candidate"></a><span data-ttu-id="0d22c-135">リソース候補を選択する例</span><span class="sxs-lookup"><span data-stu-id="0d22c-135">Example of choosing a resource candidate</span></span>

<span data-ttu-id="0d22c-136">次のようなファイルがあるとします。</span><span class="sxs-lookup"><span data-stu-id="0d22c-136">Consider these files.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
fr/images/contrast-high/logo.scale-400.jpg
fr/images/contrast-high/logo.scale-100.jpg
de/images/logo.jpg
```

<span data-ttu-id="0d22c-137">また、現在のコンテキストの設定は次のようになっているとします。</span><span class="sxs-lookup"><span data-stu-id="0d22c-137">And suppose that these are the settings in the current context.</span></span>

```
Application language: en-US; fr-FR;
Scale: 400
Contrast: Standard
```

<span data-ttu-id="0d22c-138">ハイ コントラストとドイツ語はこの設定に定義されているコンテキストに一致しないため、リソース管理システムによって 3 つのファイルが除外されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-138">The Resource Management System eliminates three of the files, because high contrast and the German language do not match the context defined by the settings.</span></span> <span data-ttu-id="0d22c-139">これによって、次の候補が残ります。</span><span class="sxs-lookup"><span data-stu-id="0d22c-139">That leaves these candidates.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
```

<span data-ttu-id="0d22c-140">これらの残りの候補について、リソース管理システムは、優先度が最も高いコンテキスト修飾子である言語を使用します。</span><span class="sxs-lookup"><span data-stu-id="0d22c-140">For those remaining candidates, the Resource Management System uses the highest-priority context qualifier, which is language.</span></span> <span data-ttu-id="0d22c-141">設定で英語がフランス語よりも先にリストされているため、英語のリソースはフランス語のリソースよりも一致率が高くなります。</span><span class="sxs-lookup"><span data-stu-id="0d22c-141">The English resources are a closer match than the French ones because English is listed before French in the settings.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
```

<span data-ttu-id="0d22c-142">次に、リソース管理システムでは、次に優先順位の高いコンテキスト修飾子であるスケールを使用します。</span><span class="sxs-lookup"><span data-stu-id="0d22c-142">Next, the Resource Management System uses the next-highest priority context qualifier, scale.</span></span> <span data-ttu-id="0d22c-143">このため、次のリソースが返されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-143">So this is the resource returned.</span></span>

```
en/images/logo.scale-400.jpg
```

<span data-ttu-id="0d22c-144">高度な [**NamedResource.ResolveAll**](/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResource?branch=live#Windows_ApplicationModel_Resources_Core_NamedResource_ResolveAll_Windows_ApplicationModel_Resources_Core_ResourceContext_) メソッドを使うと、コンテキスト設定に一致する順にすべての候補を取得できます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-144">You can use the advanced [**NamedResource.ResolveAll**](/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResource?branch=live#Windows_ApplicationModel_Resources_Core_NamedResource_ResolveAll_Windows_ApplicationModel_Resources_Core_ResourceContext_) method to retrieve all of the candidates in the order that they match the context settings.</span></span> <span data-ttu-id="0d22c-145">前述の例では、**ResolveAll** は次の順序で候補を返します。</span><span class="sxs-lookup"><span data-stu-id="0d22c-145">For the example we just walked through, **ResolveAll** returns candidates in this order.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/logo.scale-100.jpg
```

## <a name="example-of-producing-a-fallback-choice"></a><span data-ttu-id="0d22c-146">フォールバック選択肢を生成する例</span><span class="sxs-lookup"><span data-stu-id="0d22c-146">Example of producing a fallback choice</span></span>

<span data-ttu-id="0d22c-147">次のようなファイルがあるとします。</span><span class="sxs-lookup"><span data-stu-id="0d22c-147">Consider these files.</span></span>

```
en/images/logo.scale-400.jpg
en/images/logo.scale-200.jpg
en/images/logo.scale-100.jpg  
fr/images/contrast-standard/logo.scale-400.jpg
fr/images/contrast-standard/logo.scale-100.jpg
de/images/contrast-standard/logo.jpg
```

<span data-ttu-id="0d22c-148">また、現在のコンテキストの設定は次のようになっているとします。</span><span class="sxs-lookup"><span data-stu-id="0d22c-148">And suppose that these are the settings in the current context.</span></span>

```
User language: de-DE;
Scale: 400
Contrast: High
```

<span data-ttu-id="0d22c-149">すべてのファイルがコンテキストに一致しないため、除外されます。</span><span class="sxs-lookup"><span data-stu-id="0d22c-149">All the files are eliminated because they do not match the context.</span></span> <span data-ttu-id="0d22c-150">そこで、既定のパスが使われます。PRI ファイルの作成時の既定値は次のようになっていました (「[MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="0d22c-150">So we enter a default pass, where the default (see [Compile resources manually with MakePri.exe](compile-resources-manually-with-makepri.md)) during creation of the PRI file was this.</span></span>

```
Language: fr-FR;
Scale: 400
Contrast: Standard
```

<span data-ttu-id="0d22c-151">これにより、現在のユーザーまたは既定値に一致するすべてのリソースが候補となります。</span><span class="sxs-lookup"><span data-stu-id="0d22c-151">This leaves all the resources that match either the current user or the default.</span></span>

```
fr/images/contrast-standard/logo.scale-400.jpg
fr/images/contrast-standard/logo.scale-100.jpg
de/images/contrast-standard/logo.jpg
```

<span data-ttu-id="0d22c-152">リソース管理システムは、優先順位が最も高いコンテキスト修飾子である言語を使って、スコアが最も高い名前付きリソースを返します。</span><span class="sxs-lookup"><span data-stu-id="0d22c-152">The Resource Management System uses the highest-priority context qualifier, language, to return the named resource with the highest score.</span></span>

```
de/images/contrast-standard/logo.jpg
```

## <a name="important-apis"></a><span data-ttu-id="0d22c-153">重要な API</span><span class="sxs-lookup"><span data-stu-id="0d22c-153">Important APIs</span></span>

* [<span data-ttu-id="0d22c-154">NamedResource.ResolveAll</span><span class="sxs-lookup"><span data-stu-id="0d22c-154">NamedResource.ResolveAll</span></span>](/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResource?branch=live#Windows_ApplicationModel_Resources_Core_NamedResource_ResolveAll_Windows_ApplicationModel_Resources_Core_ResourceContext_)

## <a name="related-topics"></a><span data-ttu-id="0d22c-155">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0d22c-155">Related topics</span></span>

* [<span data-ttu-id="0d22c-156">MakePri.exe を使用して手動でリソースをコンパイルする</span><span class="sxs-lookup"><span data-stu-id="0d22c-156">Compile resources manually with MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)