---
author: stevewhims
Description: "このトピックでは、修飾子の一般概念、使用方法、各修飾子名の目的について説明します。"
title: "言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する"
template: detail.hbs
ms.author: stwhi
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 99b76ad155818b56e5fd6873df19bc0400c0a218
ms.sourcegitcommit: 165f57223ba69c0b7b71b295d9e0d35ea9a50a27
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2017
---
# <a name="tailor-your-resources-for-language-scale-high-contrast-and-other-qualifiers"></a><span data-ttu-id="203ad-104">言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="203ad-104">Tailor your resources for language, scale, high contrast, and other qualifiers</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="203ad-105">このトピックでは、リソース修飾子の一般概念、使用方法、各修飾子名の目的について説明します。</span><span class="sxs-lookup"><span data-stu-id="203ad-105">This topic explains the general concept of resource qualifiers, how to use them, and the purpose of each of the qualifier names.</span></span> <span data-ttu-id="203ad-106">使用可能な修飾子の値を網羅したリファレンス テーブルについては、「[ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-106">See [ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) for a reference table of all the possible qualifier values.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="203ad-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="203ad-107">Important APIs</span></span></b><br/>
<ul>
<li>**[<span data-ttu-id="203ad-108">SetGlobalQualifierValue</span><span class="sxs-lookup"><span data-stu-id="203ad-108">SetGlobalQualifierValue</span></span>](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_)**</li>
</ul>
</div>

<span data-ttu-id="203ad-109">アプリでは、表示言語、ハイ コントラスト設定、[表示倍率](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)などのランタイム コンテキストに合わせて調整されたアセットやリソースを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="203ad-109">Your app can load assets and resources that are tailored to runtime contexts such as display language, high contrast, [display scale factor](../layout/screen-sizes-and-breakpoints-for-responsive-design.md), and many others.</span></span> <span data-ttu-id="203ad-110">これを行うには、リソースのフォルダーまたはファイルの名前を、これらのコンテキストに対応した修飾子の名前と値に一致させます。</span><span class="sxs-lookup"><span data-stu-id="203ad-110">The way you do this is to name your resources’ folders or files to match the qualifier names and qualifier values that correspond to those contexts.</span></span> <span data-ttu-id="203ad-111">たとえば、ハイ コントラスト モードでは別のセットのイメージ アセットをアプリに読み込む、ということもできます。</span><span class="sxs-lookup"><span data-stu-id="203ad-111">For example, you may want your app to load a different set of image assets in high contrast mode.</span></span>

## <a name="qualifier-name-qualifier-value-and-qualifier"></a><span data-ttu-id="203ad-112">修飾子名、修飾子の値、修飾子</span><span class="sxs-lookup"><span data-stu-id="203ad-112">Qualifier name, qualifier value, and qualifier</span></span>

<span data-ttu-id="203ad-113">修飾子名は、一連の修飾子の値にマップされるキーです。</span><span class="sxs-lookup"><span data-stu-id="203ad-113">A qualifier name is a key that maps to a set of qualifier values.</span></span> <span data-ttu-id="203ad-114">修飾子の名前と修飾子の値を次に示します。</span><span class="sxs-lookup"><span data-stu-id="203ad-114">Here are the qualifier name and qualifier values for contrast.</span></span>

| <span data-ttu-id="203ad-115">コンテキスト</span><span class="sxs-lookup"><span data-stu-id="203ad-115">Context</span></span> | <span data-ttu-id="203ad-116">修飾子名</span><span class="sxs-lookup"><span data-stu-id="203ad-116">Qualifier name</span></span> | <span data-ttu-id="203ad-117">修飾子の値</span><span class="sxs-lookup"><span data-stu-id="203ad-117">Qualifier values</span></span> |
| :--------------- | :--------------- | :--------------- |
| <span data-ttu-id="203ad-118">ハイ コントラスト設定</span><span class="sxs-lookup"><span data-stu-id="203ad-118">The high contrast setting</span></span> | <span data-ttu-id="203ad-119">contrast</span><span class="sxs-lookup"><span data-stu-id="203ad-119">contrast</span></span> | <span data-ttu-id="203ad-120">standard、high、black、white</span><span class="sxs-lookup"><span data-stu-id="203ad-120">standard, high, black, white</span></span> |

<span data-ttu-id="203ad-121">修飾子は、修飾子名と修飾子の値を組み合わせて作成します。</span><span class="sxs-lookup"><span data-stu-id="203ad-121">You combine a qualifier name with a qualifier value to form a qualifier.</span></span> `<qualifier name>-<qualifier value>` <span data-ttu-id="203ad-122">は修飾子の形式です。</span><span class="sxs-lookup"><span data-stu-id="203ad-122">is the format of a qualifier.</span></span> `contrast-standard` <span data-ttu-id="203ad-123">は修飾子の例です。</span><span class="sxs-lookup"><span data-stu-id="203ad-123">is an example of a qualifier.</span></span>

<span data-ttu-id="203ad-124">ハイ コントラストの場合、修飾子のセットは `contrast-standard`、`contrast-high`、`contrast-black`、`contrast-white` になります。</span><span class="sxs-lookup"><span data-stu-id="203ad-124">So, for high contrast, the set of qualifiers is `contrast-standard`, `contrast-high`, `contrast-black`, and `contrast-white`.</span></span> <span data-ttu-id="203ad-125">修飾子名と修飾子の値では、大文字と小文字が区別されません。</span><span class="sxs-lookup"><span data-stu-id="203ad-125">Qualifier names and qualifier values are not case sensitive.</span></span> <span data-ttu-id="203ad-126">たとえば、`contrast-standard` と `Contrast-Standard` は同じ修飾子であると見なされます。</span><span class="sxs-lookup"><span data-stu-id="203ad-126">For example, `contrast-standard` and `Contrast-Standard` are the same qualifier.</span></span>

## <a name="use-qualifiers-in-folder-names"></a><span data-ttu-id="203ad-127">修飾子をフォルダー名に使用する</span><span class="sxs-lookup"><span data-stu-id="203ad-127">Use qualifiers in folder names</span></span>

<span data-ttu-id="203ad-128">アセット ファイルが含まれるフォルダーに、修飾子を使用して名前を付ける例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="203ad-128">Here is an example of using qualifiers to name folders that contain asset files.</span></span> <span data-ttu-id="203ad-129">修飾子ごとに複数のアセット ファイルがある場合は、フォルダー名に修飾子を使用します。</span><span class="sxs-lookup"><span data-stu-id="203ad-129">Use qualifiers in folder names if you have several asset files per qualifier.</span></span> <span data-ttu-id="203ad-130">これにより、フォルダー レベルで一度だけ修飾子を設定すると、この修飾子がフォルダー内のすべての項目に適用されます。</span><span class="sxs-lookup"><span data-stu-id="203ad-130">That way, you set the qualifier once at the folder level, and the qualifier applies to everything inside the folder.</span></span>

```
\Assets\Images\contrast-standard\<logo.png, and other image files>
\Assets\Images\contrast-high\<logo.png, and other image files>
\Assets\Images\contrast-black\<logo.png, and other image files>
\Assets\Images\contrast-white\<logo.png, and other image files>
```

<span data-ttu-id="203ad-131">上の例のようにフォルダーの名前を付けた場合、アプリはハイ コントラスト設定を使用して、適切な修飾子名が適用されたフォルダーからリソース ファイルを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="203ad-131">If you name your folders as in the example above, then your app uses the high contrast setting to load resource files from the folder named for the appropriate qualifier.</span></span> <span data-ttu-id="203ad-132">このため、設定が [ハイ コントラスト 黒] であれば、`\Assets\Images\contrast-black` フォルダー内のリソース ファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-132">So, if the setting is High Contrast Black, then the resource files in the `\Assets\Images\contrast-black` folder are loaded.</span></span> <span data-ttu-id="203ad-133">設定が [なし] (コンピューターがハイ コントラスト モードではない) の場合は、`\Assets\Images\standard` フォルダー内のリソース ファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-133">If the setting is None (that is, the computer is not in high contrast mode), then the resource files in the `\Assets\Images\standard` folder are loaded.</span></span>

## <a name="use-qualifiers-in-file-names"></a><span data-ttu-id="203ad-134">修飾子をファイル名に使用する</span><span class="sxs-lookup"><span data-stu-id="203ad-134">Use qualifiers in file names</span></span>

<span data-ttu-id="203ad-135">フォルダーを作成して名前を付ける代わりに、修飾子を使用してリソース ファイル自体の名前を付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="203ad-135">Instead of creating and naming folders, you can use a qualifier to name the resource files themselves.</span></span> <span data-ttu-id="203ad-136">1 つの修飾子につきリソース ファイルが 1 つのみの場合は、この方法が適しています。</span><span class="sxs-lookup"><span data-stu-id="203ad-136">You might prefer to do this if you only have one resource file per qualifier.</span></span> <span data-ttu-id="203ad-137">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="203ad-137">Here’s an example.</span></span>

```
\Assets\Images\logo.contrast-standard.png
\Assets\Images\logo.contrast-high.png
\Assets\Images\logo.contrast-black.png
\Assets\Images\logo.contrast-white.png
```

<span data-ttu-id="203ad-138">読み込まれるのは、設定に最も適した修飾子を含む名前のファイルです。</span><span class="sxs-lookup"><span data-stu-id="203ad-138">The file whose name contains the qualifier most appropriate for the setting is the one that is loaded.</span></span> <span data-ttu-id="203ad-139">ファイル名についても、フォルダー名と同様の照合ロジックが使用されます。</span><span class="sxs-lookup"><span data-stu-id="203ad-139">This matching logic works the same way for file names as for folder names.</span></span>

## <a name="reference-a-string-or-image-resource-by-name"></a><span data-ttu-id="203ad-140">文字列または画像リソースを名前で参照する</span><span class="sxs-lookup"><span data-stu-id="203ad-140">Reference a string or image resource by name</span></span>

<span data-ttu-id="203ad-141">「[XAML マークアップから文字列リソース識別子を参照する](put-ui-strings-into-resources.md#refer-to-a-string-resource-identifier-from-xaml-markup)」、「[コードから文字列リソース識別子を参照する](put-ui-strings-into-resources.md#refer-to-a-string-resource-identifier-from-code)」、「[XAML マークアップとコードから画像リソースを参照する](image-qualifiers-loc-scale-accessibility.md#reference-an-image-resource-in-xaml-markup-and-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-141">See [Refer to a string resource identifier from XAML markup](put-ui-strings-into-resources.md#refer-to-a-string-resource-identifier-from-xaml-markup), [Refer to a string resource identifier from code](put-ui-strings-into-resources.md#refer-to-a-string-resource-identifier-from-code), and [Reference an image resource in XAML markup and code](image-qualifiers-loc-scale-accessibility.md#reference-an-image-resource-in-xaml-markup-and-code).</span></span>

## <a name="actual-and-neutral-qualifier-matches"></a><span data-ttu-id="203ad-142">修飾子の実際の一致と中立的な一致</span><span class="sxs-lookup"><span data-stu-id="203ad-142">Actual and neutral qualifier matches</span></span>
<span data-ttu-id="203ad-143">修飾子の値の*すべて*にリソース ファイルを指定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="203ad-143">You don’t need to provide a resource file for *every* qualifier value.</span></span> <span data-ttu-id="203ad-144">たとえば、ハイ コントラスト用と標準コントラスト用にビジュアル アセットを各 1 つのみ必要とする場合は、これらのアセット名を次のように付けることができます。</span><span class="sxs-lookup"><span data-stu-id="203ad-144">For example, if you find that you only need one visual asset for high contrast and one for standard contrast, then you can name those assets like this.</span></span>

```
\Assets\Images\logo.contrast-high.png
\Assets\Images\logo.png
```

<span data-ttu-id="203ad-145">最初のファイル名には、`contrast-high` 修飾子が含まれています。</span><span class="sxs-lookup"><span data-stu-id="203ad-145">The first file name contains the `contrast-high` qualifier.</span></span> <span data-ttu-id="203ad-146">ハイ コントラストが *[オン]* になっている場合、この修飾子は、あらゆるハイ コントラスト設定に対する*実際の*一致です。</span><span class="sxs-lookup"><span data-stu-id="203ad-146">That qualifier is an *actual* match for any high contrast setting when high contrast is *on*.</span></span> <span data-ttu-id="203ad-147">言い換えると、これは近似一致であり、優先されます。</span><span class="sxs-lookup"><span data-stu-id="203ad-147">In other words, it's a close match so it’s preferred.</span></span> <span data-ttu-id="203ad-148">この場合のように、*実際*の一致は、修飾子に*実際*の値が含まれている場合にのみ発生します。</span><span class="sxs-lookup"><span data-stu-id="203ad-148">An *actual* match can only occur if the qualifier contains an *actual* value, as this one does.</span></span> <span data-ttu-id="203ad-149">この場合、`high` が `contrast` に対する*実際*の値です。</span><span class="sxs-lookup"><span data-stu-id="203ad-149">In this case, `high` is an *actual* value for `contrast`.</span></span>

<span data-ttu-id="203ad-150">`logo.png` というファイル名には、contrast 修飾子がまったく含まれていません。</span><span class="sxs-lookup"><span data-stu-id="203ad-150">The file named `logo.png` has no contrast qualifier on it at all.</span></span> <span data-ttu-id="203ad-151">修飾子がない値は、*中立的*です。</span><span class="sxs-lookup"><span data-stu-id="203ad-151">The absence of a qualifier is a *neutral* value.</span></span> <span data-ttu-id="203ad-152">優先される一致が見つからない場合、中立値はフォールバックの一致として使用されます。</span><span class="sxs-lookup"><span data-stu-id="203ad-152">If no preferred match can be found, then the neutral value serves as a fallback match.</span></span> <span data-ttu-id="203ad-153">この例では、ハイ コントラストが*オフ*になっている場合、実際の一致はありません。</span><span class="sxs-lookup"><span data-stu-id="203ad-153">In this example, if high contrast is *off*, then there is no actual match.</span></span> <span data-ttu-id="203ad-154">見つかるベスト マッチが*中立的*な一致であるため、`logo.png` というアセットが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-154">The *neutral* match is the best match that can be found, and so the asset `logo.png` is loaded.</span></span>

<span data-ttu-id="203ad-155">`logo.png` の名前を `logo.contrast-standard.png` に変更すると、ファイル名に実際の修飾子の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-155">If you were to change the name of `logo.png` to `logo.contrast-standard.png`, then the file name would contain an actual qualifier value.</span></span> <span data-ttu-id="203ad-156">ハイ コントラストがオフになっている場合、`logo.contrast-standard.png` との実際の一致があり、このアセット ファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-156">With high contrast off, there would be an actual match with `logo.contrast-standard.png`, and that’s the asset file that would be loaded.</span></span> <span data-ttu-id="203ad-157">このため、別々の一致が原因ですが、同じ条件下で同じファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-157">So, the same files would be loaded, under the same conditions, but because of different matches.</span></span>

<span data-ttu-id="203ad-158">必要なアセット セットが、ハイ コントラスト用に 1 つと標準コントラスト用に 1 つのみである場合は、ファイル名の代わりにフォルダー名を使用できます。</span><span class="sxs-lookup"><span data-stu-id="203ad-158">If you only need one set of assets for high contrast and one set for standard contrast, then you can use folder names instead of file names.</span></span> <span data-ttu-id="203ad-159">この場合、フォルダー名を省略すると、完全に中立的な一致になります。</span><span class="sxs-lookup"><span data-stu-id="203ad-159">In this case, omitting the folder name entirely gives you the neutral match.</span></span>

```
\Assets\Images\contrast-high\<logo.png, and other images to load when high contrast theme is not None>
\Assets\Images\<logo.png, and other images to load when high contrast theme is None>
```

<span data-ttu-id="203ad-160">修飾子の照合について詳しくは、「[リソース管理システム](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj552947)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="203ad-160">For more details on how qualifier matching works, see [Resource Management System](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj552947).</span></span>

## <a name="multiple-qualifiers"></a><span data-ttu-id="203ad-161">複数の修飾子</span><span class="sxs-lookup"><span data-stu-id="203ad-161">Multiple qualifiers</span></span>

<span data-ttu-id="203ad-162">修飾子は、フォルダー名とファイル名で組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="203ad-162">You can combine qualifiers in folder and file names.</span></span> <span data-ttu-id="203ad-163">たとえば、ハイ コントラスト モードがオンであり**表示倍率が 400 のときに、イメージ アセットをアプリに読み込むとします。</span><span class="sxs-lookup"><span data-stu-id="203ad-163">For example, you may want your app to load image assets when high contrast mode is on *and* the display scale factor is 400.</span></span> <span data-ttu-id="203ad-164">これを行う方法の 1 つは、入れ子になったフォルダーの使用です。</span><span class="sxs-lookup"><span data-stu-id="203ad-164">One way to do this is with nested folders.</span></span>

```
\Assets\Images\contrast-high\scale-400\<logo.png, and other image files>
```

<span data-ttu-id="203ad-165">`logo.png` およびその他のファイルを読み込むには、設定が*両方*の修飾子と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="203ad-165">For `logo.png` and the other files to be loaded, the settings must match *both* qualifiers.</span></span>

<span data-ttu-id="203ad-166">もう 1 つのオプションは、複数の修飾子を結合して 1 つのフォルダー名にすることです。</span><span class="sxs-lookup"><span data-stu-id="203ad-166">Another option is to combine multiple qualifiers in one folder name.</span></span>

```
\Assets\Images\contrast-high_scale-400\<logo.png, and other image files>
```

<span data-ttu-id="203ad-167">フォルダー名として、複数の修飾子をアンダー スコアで結合します。</span><span class="sxs-lookup"><span data-stu-id="203ad-167">In a folder name, you combine multiple qualifiers separated with an underscore.</span></span> `<qualifier1>[_<qualifier2>...]` <span data-ttu-id="203ad-168"> という形式を使用します。</span><span class="sxs-lookup"><span data-stu-id="203ad-168">is the format.</span></span>

<span data-ttu-id="203ad-169">同じ形式で、複数の修飾子を結合して 1 つのファイル名にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="203ad-169">You can combine multiple qualifiers in a file name in the same format.</span></span>

```
\Assets\Images\logo.contrast-high_scale-400.png
```

<span data-ttu-id="203ad-170">アセット作成に使用するツールとワークフローや、読みやすさや管理のしやすさによって、すべての修飾子に単一の命名方法を選択することも、修飾子によって異なる方法を組み合わせることもできます。</span><span class="sxs-lookup"><span data-stu-id="203ad-170">Depending on the tools and workflow you use for asset-creation, or on what you find easiest to read and/or manage, you can either choose a single naming strategy for all qualifiers, or you can combine them for different qualifiers.</span></span>

## <a name="alternateform"></a><span data-ttu-id="203ad-171">AlternateForm</span><span class="sxs-lookup"><span data-stu-id="203ad-171">AlternateForm</span></span>

<span data-ttu-id="203ad-172">特別な目的でリソースの代替フォームを提供するには、`alternateform` 修飾子を使います。</span><span class="sxs-lookup"><span data-stu-id="203ad-172">The `alternateform` qualifier is used to provide an alternate form of a resource for some special purpose.</span></span> <span data-ttu-id="203ad-173">通常、日本のアプリ開発者によってふりがな文字列を提供する目的のみで使用されます。そのために、`msft-phonetic` という値が予約されています (「[ローカライズの準備をする方法](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh967762)」の「並べ替えることができる日本語文字列のふりがなのサポート」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="203ad-173">This is typically used only by Japanese app developers to provide a furigana string for which the value `msft-phonetic` is reserved (see the section “Support Furigana for Japanese strings that can be sorted” in [How to prepare for localization](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh967762)).</span></span>

<span data-ttu-id="203ad-174">ターゲット システムとアプリのうちいずれかが、`alternateform` 修飾子と一致する値を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="203ad-174">Either your target system or your app must provide a value against which `alternateform` qualifiers are matched.</span></span> <span data-ttu-id="203ad-175">カスタムの `alternateform` 修飾子の値に `msft-` プレフィックスを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="203ad-175">Do not use the `msft-` prefix for your own custom `alternateform` qualifier values.</span></span>

## <a name="configuration"></a><span data-ttu-id="203ad-176">Configuration</span><span class="sxs-lookup"><span data-stu-id="203ad-176">Configuration</span></span>

<span data-ttu-id="203ad-177">`configuration` 修飾子名が必要になる可能性は高くありません。</span><span class="sxs-lookup"><span data-stu-id="203ad-177">It’s unlikely that you’ll need the `configuration` qualifier name.</span></span> <span data-ttu-id="203ad-178">テストのみのリソースなど、オーサリング時環境にのみ使用されるリソースを指定するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="203ad-178">It can be used to specify resources that are applicable only to a given authoring-time environment, such as test-only resources.</span></span>

<span data-ttu-id="203ad-179">`configuration` 修飾子は、`MS_CONFIGURATION_ATTRIBUTE_VALUE` 環境変数の値と最も一致するリソースを読み込むために使用します。</span><span class="sxs-lookup"><span data-stu-id="203ad-179">The `configuration` qualifier is used to load a resource that best matches the value of the `MS_CONFIGURATION_ATTRIBUTE_VALUE` environment variable.</span></span> <span data-ttu-id="203ad-180">このため、この変数は、関連するリソースに割り当てられた文字列値 (`designer` や `test` など) に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="203ad-180">So, you can set the variable to the string value that has been assigned to the relevant resources, for example `designer`, or `test`.</span></span>

## <a name="contrast"></a><span data-ttu-id="203ad-181">Contrast</span><span class="sxs-lookup"><span data-stu-id="203ad-181">Contrast</span></span>

<span data-ttu-id="203ad-182">`contrast` 修飾子は、ハイ コントラスト設定と最も一致するリソースを提供するために使用します。</span><span class="sxs-lookup"><span data-stu-id="203ad-182">The `contrast` qualifier is used to provide resources that best match high contrast settings.</span></span>

## <a name="custom"></a><span data-ttu-id="203ad-183">Custom</span><span class="sxs-lookup"><span data-stu-id="203ad-183">Custom</span></span>

<span data-ttu-id="203ad-184">アプリで `custom` 修飾子の値を設定すると、その値に最も一致するリソースが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-184">Your app can set a value for the `custom` qualifier, and then resources are loaded that best match that value.</span></span> <span data-ttu-id="203ad-185">たとえば、アプリのライセンスに基づいてリソースを読み込む必要があるとします。</span><span class="sxs-lookup"><span data-stu-id="203ad-185">For example, you may want to load resources based on your app’s license.</span></span> <span data-ttu-id="203ad-186">アプリは、起動するとライセンスを確認し、[SetGlobalQualifierValue](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_) を呼び出すことによって、ライセンスを `custom` 修飾子の値として使用します。コード例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-186">When your app launches, it checks its license and uses that as the value for the `custom` qualifier by calling [SetGlobalQualifierValue](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_), as shown in the code example.</span></span>

```csharp
public void SetLicenseLevel(BrandID brand)
{
    if (brand == BrandID.Premium)
    {
        ResourceContext.SetGlobalQualifierValue("Custom", "Premium", ResourceQualifierPersistence.LocalMachine);
    }
    else if (brand == BrandID.Standard)
    {
        ResourceContext.SetGlobalQualifierValue("Custom", " Standard", ResourceQualifierPersistence.LocalMachine);
    }
    else
    {
        ResourceContext.SetGlobalQualifierValue("Custom", "Trial", ResourceQualifierPersistence.LocalMachine);
    }
}
```

<span data-ttu-id="203ad-187">このシナリオでは、修飾子 `custom-premium`、`custom-standard`、および `custom-trial` をそれぞれ含む名前をリソースに適用します。</span><span class="sxs-lookup"><span data-stu-id="203ad-187">In this scenario, you would then give your resources names that include the qualifiers `custom-premium`, `custom-standard`, and `custom-trial`.</span></span>

## <a name="devicefamily"></a><span data-ttu-id="203ad-188">DeviceFamily</span><span class="sxs-lookup"><span data-stu-id="203ad-188">DeviceFamily</span></span>

<span data-ttu-id="203ad-189">`devicefamily` という修飾子名が必要になる可能性は高くありません。</span><span class="sxs-lookup"><span data-stu-id="203ad-189">It’s unlikely that you’ll need the `devicefamily` qualifier name.</span></span> <span data-ttu-id="203ad-190">他にもっと便利で強力な修飾子を使う手法があるため、この修飾子名の使用はできる限り避けてください。</span><span class="sxs-lookup"><span data-stu-id="203ad-190">You can and should avoid using it whenever possible because there are techniques that you can use instead that are much more convenient and robust.</span></span> <span data-ttu-id="203ad-191">このような手法については、「[アプリが実行されているプラットフォームの検出](../porting/wpsl-to-uwp-input-and-sensors.md#detecting-the-platform-your-app-is-running-on)」および「[コードの記述](../get-started/universal-application-platform-guide.md#writing-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-191">Those techniques are described in [Detecting the platform your app is running on](../porting/wpsl-to-uwp-input-and-sensors.md#detecting-the-platform-your-app-is-running-on) and [Writing code](../get-started/universal-application-platform-guide.md#writing-code).</span></span>

<span data-ttu-id="203ad-192">ただし他に方法がなければ、XAML ビュー (XAML ビューは、UI レイアウトとコントロールを含む XAML ファイル) を格納するフォルダーの名前として devicefamily という修飾子を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="203ad-192">But as a last resort it is possible to use devicefamily qualifiers to name folders that contain your XAML views (a XAML view is a XAML file that contains UI layout and controls).</span></span>

```
\devicefamily-desktop\<MainPage.xaml, and other markup files to load when running on a desktop computer>
\devicefamily-mobile\<MainPage.xaml, and other markup files to load when running on a phone>
```

<span data-ttu-id="203ad-193">または、次のようにファイルに命名することもできます。</span><span class="sxs-lookup"><span data-stu-id="203ad-193">Or you can name files.</span></span>

```
\MainPage.devicefamily-desktop.xaml
\MainPage.devicefamily-mobile.xaml
```

<span data-ttu-id="203ad-194">いずれの場合も、`MainPage.[<qualifier>].xaml` の各コピーで、共通の `MainPage.xaml.cs` が使用されます (プロジェクト内で名前、場所、コンテンツが変わりません)。</span><span class="sxs-lookup"><span data-stu-id="203ad-194">In either case each copy of `MainPage.[<qualifier>].xaml` shares a common `MainPage.xaml.cs`, which remains unchanged in your project in terms of name, location, and contents.</span></span>

<span data-ttu-id="203ad-195">また、devicefamily 修飾子を使用してリソース ファイル (`.resw`) またはフォルダーに名前を付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="203ad-195">You can also use a devicefamily qualifier to name a Resources File (`.resw`), or folder.</span></span> <span data-ttu-id="203ad-196">たとえば、モバイル デバイス ファミリでアプリが実行されている場合、UI 要素 `<TextBlock x:Uid="DeviceFriendlyName"/>` では、`Resources.devicefamily-mobile.resw` ファイルに定義されているテキストと前景リソースが使用されます。以下はその例です。</span><span class="sxs-lookup"><span data-stu-id="203ad-196">For example, when your app is running on the mobile device family, the UI element `<TextBlock x:Uid="DeviceFriendlyName"/>` will use the text and foreground resources defined in your `Resources.devicefamily-mobile.resw` file if it contains</span></span>

```xml
<data name="DeviceFriendlyName.Foreground">
    <value>Red</value>
</data>
<data name="DeviceFriendlyName.Text">
    <value>Mobile device</value>
</data>
```

<span data-ttu-id="203ad-197">リソース ファイルの使用について詳しくは、[UI 文字列のローカライズ](put-ui-strings-into-resources.md)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-197">For more on using a Resources File, see [Localize your UI strings](put-ui-strings-into-resources.md).</span></span>

## <a name="dxfeaturelevel"></a><span data-ttu-id="203ad-198">DXFeatureLevel</span><span class="sxs-lookup"><span data-stu-id="203ad-198">DXFeatureLevel</span></span>

<span data-ttu-id="203ad-199">`dxfeaturelevel` という修飾子名が必要になる可能性は高くありません。</span><span class="sxs-lookup"><span data-stu-id="203ad-199">It’s unlikely that you’ll need the `dxfeaturelevel` qualifier name.</span></span> <span data-ttu-id="203ad-200">これは Direct3D ゲーム アセットで使用し、以前の特定な下位レベル ハードウェア構成に一致するように、下位レベルのリソースを読み込むために用意されたものです。</span><span class="sxs-lookup"><span data-stu-id="203ad-200">It was designed to be used with Direct3D game assets, to cause downlevel resources to be loaded to match a particular downlevel hardware configuration of the time.</span></span> <span data-ttu-id="203ad-201">ただ、このハードウェア構成はあまり普及していないため、この修飾子は使用しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="203ad-201">But the prevalence of that hardware configuration is now so low that we recommend you don’t use this qualifier.</span></span>

## <a name="homeregion"></a><span data-ttu-id="203ad-202">HomeRegion</span><span class="sxs-lookup"><span data-stu-id="203ad-202">HomeRegion</span></span>

<span data-ttu-id="203ad-203">`homeregion` 修飾子は、国または地域のユーザー設定に対応します。</span><span class="sxs-lookup"><span data-stu-id="203ad-203">The `homeregion` qualifier corresponds to the user’s setting for country or region.</span></span> <span data-ttu-id="203ad-204">ユーザーが住んでいる地域の場所を表します。</span><span class="sxs-lookup"><span data-stu-id="203ad-204">It represents the home location of the user.</span></span> <span data-ttu-id="203ad-205">値には、有効な [BCP-47 region タグ](http://go.microsoft.com/fwlink/p/?linkid=227302)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-205">Values include any valid [BCP-47 region tag](http://go.microsoft.com/fwlink/p/?linkid=227302).</span></span> <span data-ttu-id="203ad-206">つまり、**ISO 3166-1 alpha-2** の 2 文字の地域番号に、構成地域用の **ISO 3166-1 numeric** の 3 桁の地域番号のセットを加えた値となります ([国連統計部 M49 地域番号構成に関するページ](http://go.microsoft.com/fwlink/p/?linkid=247929)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="203ad-206">That is, any **ISO 3166-1 alpha-2** two-letter region code, plus the set of **ISO 3166-1 numeric** three-digit geographic codes for composed regions (see [United Nations Statistic Division M49 composition of region codes](http://go.microsoft.com/fwlink/p/?linkid=247929)).</span></span> <span data-ttu-id="203ad-207">"Selected economic and other groupings" の番号は有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="203ad-207">Codes for "Selected economic and other groupings" are not valid.</span></span>

## <a name="language"></a><span data-ttu-id="203ad-208">Language</span><span class="sxs-lookup"><span data-stu-id="203ad-208">Language</span></span>

<span data-ttu-id="203ad-209">`language` 修飾子は、表示言語設定に対応します。</span><span class="sxs-lookup"><span data-stu-id="203ad-209">A `language` qualifier corresponds to the display language setting.</span></span> <span data-ttu-id="203ad-210">値には、有効な [BCP 47 language タグ](http://go.microsoft.com/fwlink/p/?linkid=227302)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-210">Values include any valid [BCP-47 language tag](http://go.microsoft.com/fwlink/p/?linkid=227302).</span></span> <span data-ttu-id="203ad-211">言語の一覧については、[IANA 言語サブタグ レジストリに関するページ](http://go.microsoft.com/fwlink/p/?linkid=227303)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-211">For a list of languages, see the [IANA language subtag registry](http://go.microsoft.com/fwlink/p/?linkid=227303).</span></span>

<span data-ttu-id="203ad-212">アプリで複数の表示言語をサポートする必要があり、コードまたは XAML マークアップ内に文字列リテラルが含まれている場合は、その文字列をコードまたはマークアップからリソース ファイル (`.resw`) に移動します。</span><span class="sxs-lookup"><span data-stu-id="203ad-212">If you want your app to support different display languages, and you have string literals in your code or in your XAML markup, then move those strings out of the code/markup and into a Resources File (`.resw`).</span></span> <span data-ttu-id="203ad-213">アプリでサポートする各言語用に、このリソース ファイルを翻訳したコピーを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="203ad-213">You can then make a translated copy of that Resources File for each language that your app supports.</span></span>

<span data-ttu-id="203ad-214">`language` 修飾子は通常、リソース ファイル (`.resw`) が含まれているフォルダーの命名に使用します。</span><span class="sxs-lookup"><span data-stu-id="203ad-214">You typically use a `language` qualifier to name the folders that contain your Resources Files (`.resw`).</span></span>

```
\Strings\language-en\Resources.resw
\Strings\language-ja\Resources.resw
```

<span data-ttu-id="203ad-215">`language` 修飾子の `language-` の部分 (修飾子名) は省略することができます。</span><span class="sxs-lookup"><span data-stu-id="203ad-215">You can omit the `language-` part of a `language` qualifier (that is, the qualifier name).</span></span> <span data-ttu-id="203ad-216">これは他の種類の修飾子には適用されません。また、適用できるのはフォルダー名の場合のみです。</span><span class="sxs-lookup"><span data-stu-id="203ad-216">You can’t do this with the other kinds of qualifiers; and you can only do it in a folder name.</span></span>

```
\Strings\en\Resources.resw
\Strings\ja\Resources.resw
```

<span data-ttu-id="203ad-217">フォルダーに名前を付ける代わりに、`language` 修飾子を使用してリソース ファイル自体の名前を付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="203ad-217">Instead of naming folders, you can use `language` qualifiers to name the Resources Files themselves.</span></span>

```
\Strings\Resources.language-en.resw
\Strings\Resources.language-ja.resw
```

<span data-ttu-id="203ad-218">文字列リソースを使用してアプリをローカライズ可能にする方法と、アプリ内で文字列リソースを参照する方法について詳しくは、[UI 文字列のローカライズに関するページ](put-ui-strings-into-resources.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-218">See [Localize your UI strings](put-ui-strings-into-resources.md) for more information on making your app localizable by using string resources, and how to reference a string resource in your app.</span></span>

## <a name="layoutdirection"></a><span data-ttu-id="203ad-219">LayoutDirection</span><span class="sxs-lookup"><span data-stu-id="203ad-219">LayoutDirection</span></span>

<span data-ttu-id="203ad-220">`layoutdirection` 修飾子は、表示言語設定のレイアウト方向に対応します。</span><span class="sxs-lookup"><span data-stu-id="203ad-220">A `layoutdirection` qualifier corresponds to the layout direction of the display language setting.</span></span> <span data-ttu-id="203ad-221">たとえば、アラビア語やヘブライ語などの右から左に記述する言語では、イメージの反転が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="203ad-221">For example, an image may need to be mirrored for a right-to-left language such as Arabic or Hebrew.</span></span> <span data-ttu-id="203ad-222">UI のレイアウト パネルとイメージは、[FlowDirection](/uwp/api/Windows.UI.Xaml.FrameworkElement?branch=live#Windows_UI_Xaml_FrameworkElement_FlowDirection) プロパティを設定すると、レイアウト方向が正しく反映されます (「[レイアウトやフォントの調整と RTL のサポート](adjust-layout-and-fonts--and-support-rtl.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="203ad-222">Layout panels and images in your UI will respond to layout direction appropriately if you set their [FlowDirection](/uwp/api/Windows.UI.Xaml.FrameworkElement?branch=live#Windows_UI_Xaml_FrameworkElement_FlowDirection) property (see [Adjust layout and fonts, and support RTL](adjust-layout-and-fonts--and-support-rtl.md)).</span></span> <span data-ttu-id="203ad-223">`layoutdirection` 修飾子は、単純な反転だけでは十分でないケースを想定し、特定の読み取り順序の辞書やテキスト配置にも、より一般的な方法で対応することができます。</span><span class="sxs-lookup"><span data-stu-id="203ad-223">However, the `layoutdirection` qualifier is for cases where simple flipping isn't adequate, and it allows you to respond to the directionality of specific reading order and text alignment in more general ways.</span></span>

## <a name="scale"></a><span data-ttu-id="203ad-224">Scale</span><span class="sxs-lookup"><span data-stu-id="203ad-224">Scale</span></span>

<span data-ttu-id="203ad-225">特定の表示倍率に対応する正しいサイズのイメージを読み込むには、`scale` 修飾子を使用できます。</span><span class="sxs-lookup"><span data-stu-id="203ad-225">To load the correct size of image for a given display scale factor, you can use a `scale` qualifier.</span></span> <span data-ttu-id="203ad-226">これは一般に、画像が DPI の高いデバイスで表示された場合や、アプリが拡大された場合に使われます。</span><span class="sxs-lookup"><span data-stu-id="203ad-226">This is typically used for images viewed on a higher-DPI device or when the app is zoomed.</span></span> <span data-ttu-id="203ad-227">リソースのスケールは、[DisplayInformation.ResolutionScale](/uwp/api/windows.graphics.display.displayinformation?branch=live#Windows_Graphics_Display_DisplayInformation_ResolutionScale) の値、または次に大きい拡大リソースに一致します。</span><span class="sxs-lookup"><span data-stu-id="203ad-227">The scale of a resource matches the value of [DisplayInformation.ResolutionScale](/uwp/api/windows.graphics.display.displayinformation?branch=live#Windows_Graphics_Display_DisplayInformation_ResolutionScale), or the next-largest-scaled resource.</span></span>

<span data-ttu-id="203ad-228">フォルダー レベルで修飾子を設定する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="203ad-228">Here’s an example of setting the qualifier at the folder level.</span></span>

```
\Assets\Images\scale-100\<logo.png, and other image files>
\Assets\Images\scale-200\<logo.png, and other image files>
\Assets\Images\scale-400\<logo.png, and other image files>
```

<span data-ttu-id="203ad-229">この例では、ファイル レベルで修飾子を設定します。</span><span class="sxs-lookup"><span data-stu-id="203ad-229">And this example sets it at the file level.</span></span>

```
\Assets\Images\logo.scale-100.png
\Assets\Images\logo.scale-200.png
\Assets\Images\logo.scale-400.png
```

<span data-ttu-id="203ad-230">`scale` と `targetsize` でリソースを修飾する方法については、「[targetsize で画像リソースを修飾する](image-qualifiers-loc-scale-accessibility.md#qualify-an-image-resource-for-targetsize)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-230">For info about qualifying a resource for both `scale` and `targetsize`, see [Qualify an image resource for targetsize](image-qualifiers-loc-scale-accessibility.md#qualify-an-image-resource-for-targetsize).</span></span>

## <a name="targetsize"></a><span data-ttu-id="203ad-231">TargetSize</span><span class="sxs-lookup"><span data-stu-id="203ad-231">TargetSize</span></span>

<span data-ttu-id="203ad-232">`targetsize` 修飾子は主に、エクスプローラーに表示される[ファイルの種類の関連付け](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh127427)アイコンまたは[プロトコル アイコン](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/bb266530)の指定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="203ad-232">The `targetsize` qualifier is primarily used to specify [file type association icons](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh127427) or [protocol icons](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/bb266530) to be shown in File Explorer.</span></span> <span data-ttu-id="203ad-233">この修飾子の値は、正方形のイメージの辺の長さを RAW (物理) ピクセル単位で表します。</span><span class="sxs-lookup"><span data-stu-id="203ad-233">The qualifier value represents the side length of a square image in raw (physical) pixels.</span></span> <span data-ttu-id="203ad-234">エクスプローラーの表示設定に値が一致するリソースが読み込まれます。正確に一致する対象が存在しない場合は、次に大きな値のリソースが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="203ad-234">The resource whose value matches the View setting in File Explorer is loaded; or the resource with the next-largest value in the absence of an exact match.</span></span>

<span data-ttu-id="203ad-235">アプリ パッケージ マニフェスト デザイナーの [ビジュアル資産] タブで、複数サイズのアプリ アイコン (`/Assets/Square44x44Logo.png`) に対応する `targetsize` 修飾子の値を表すアセットを定義できます。</span><span class="sxs-lookup"><span data-stu-id="203ad-235">You can define assets that represent several sizes of `targetsize` qualifier value for the App Icon (`/Assets/Square44x44Logo.png`) in the Visual Assets tab of the app package manifest designer.</span></span>

<span data-ttu-id="203ad-236">`scale` と `targetsize` でリソースを修飾する方法については、「[targetsize で画像リソースを修飾する](image-qualifiers-loc-scale-accessibility.md#qualify-an-image-resource-for-targetsize)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="203ad-236">For info about qualifying a resource for both `scale` and `targetsize`, see [Qualify an image resource for targetsize](image-qualifiers-loc-scale-accessibility.md#qualify-an-image-resource-for-targetsize).</span></span>

## <a name="theme"></a><span data-ttu-id="203ad-237">Theme</span><span class="sxs-lookup"><span data-stu-id="203ad-237">Theme</span></span>

<span data-ttu-id="203ad-238">`theme` 修飾子は、既定のアプリ モード設定に最も一致するリソースか、[Application.RequestedTheme](/uwp/api/windows.ui.xaml.application?branch=master#Windows_UI_Xaml_Application_RequestedTheme) を使用してアプリのオーバーライドを提供するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="203ad-238">The `theme` qualifier is used to provide resources that best match the default app mode setting, or your app’s override using [Application.RequestedTheme](/uwp/api/windows.ui.xaml.application?branch=master#Windows_UI_Xaml_Application_RequestedTheme).</span></span>

## <a name="related-topics"></a><span data-ttu-id="203ad-239">関連トピック</span><span class="sxs-lookup"><span data-stu-id="203ad-239">Related topics</span></span>

* [<span data-ttu-id="203ad-240">表示倍率</span><span class="sxs-lookup"><span data-stu-id="203ad-240">display scale factor</span></span>](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)
* [<span data-ttu-id="203ad-241">リソース管理システム</span><span class="sxs-lookup"><span data-stu-id="203ad-241">Resource Management System</span></span>](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj552947)
* [<span data-ttu-id="203ad-242">ローカライズの準備をする方法</span><span class="sxs-lookup"><span data-stu-id="203ad-242">How to prepare for localization</span></span>](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh967762)
* [<span data-ttu-id="203ad-243">アプリが実行されているプラットフォームの検出</span><span class="sxs-lookup"><span data-stu-id="203ad-243">Detecting the platform your app is running on</span></span>](../porting/wpsl-to-uwp-input-and-sensors.md#detecting-the-platform-your-app-is-running-on)
* [<span data-ttu-id="203ad-244">コードの記述</span><span class="sxs-lookup"><span data-stu-id="203ad-244">Writing code</span></span>](../get-started/universal-application-platform-guide.md#writing-code)
* [<span data-ttu-id="203ad-245">UI 文字列のローカライズ</span><span class="sxs-lookup"><span data-stu-id="203ad-245">Localize your UI strings</span></span>](put-ui-strings-into-resources.md)
* [<span data-ttu-id="203ad-246">BCP-47</span><span class="sxs-lookup"><span data-stu-id="203ad-246">BCP-47</span></span>](http://go.microsoft.com/fwlink/p/?linkid=227302)
* [<span data-ttu-id="203ad-247">国連統計部 M49 地域番号構成</span><span class="sxs-lookup"><span data-stu-id="203ad-247">United Nations Statistic Division M49 composition of region codes</span></span>](http://go.microsoft.com/fwlink/p/?linkid=247929)
* [<span data-ttu-id="203ad-248">IANA 言語サブタグ レジストリ</span><span class="sxs-lookup"><span data-stu-id="203ad-248">IANA language subtag registry</span></span>](http://go.microsoft.com/fwlink/p/?linkid=227303)
* [<span data-ttu-id="203ad-249">レイアウトやフォントの調整と RTL のサポート</span><span class="sxs-lookup"><span data-stu-id="203ad-249">Adjust layout and fonts, and support RTL</span></span>](adjust-layout-and-fonts--and-support-rtl.md)