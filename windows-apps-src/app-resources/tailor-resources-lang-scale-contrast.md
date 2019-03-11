---
Description: このトピックでは、修飾子の一般概念、使用方法、各修飾子名の目的について説明します。
title: 言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する
template: detail.hbs
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 1ac80888019044beabc44335290bc6ad59cf377c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608137"
---
# <a name="tailor-your-resources-for-language-scale-high-contrast-and-other-qualifiers"></a><span data-ttu-id="27719-104">言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="27719-104">Tailor your resources for language, scale, high contrast, and other qualifiers</span></span>

<span data-ttu-id="27719-105">このトピックでは、リソース修飾子の一般概念、使用方法、各修飾子名の目的について説明します。</span><span class="sxs-lookup"><span data-stu-id="27719-105">This topic explains the general concept of resource qualifiers, how to use them, and the purpose of each of the qualifier names.</span></span> <span data-ttu-id="27719-106">使用可能な修飾子の値を網羅したリファレンス テーブルについては、「[**ResourceContext.QualifierValues**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext.QualifierValues)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="27719-106">See [**ResourceContext.QualifierValues**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext.QualifierValues) for a reference table of all the possible qualifier values.</span></span>

<span data-ttu-id="27719-107">アプリでは、表示言語、ハイ コントラスト設定、[表示倍率](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md#effective-pixels-and-scale-factor)などのランタイム コンテキストに合わせて調整されたアセットやリソースを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="27719-107">Your app can load assets and resources that are tailored to runtime contexts such as display language, high contrast, [display scale factor](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md#effective-pixels-and-scale-factor), and many others.</span></span> <span data-ttu-id="27719-108">これを行うには、リソースのフォルダーまたはファイルの名前を、これらのコンテキストに対応した修飾子の名前と値に一致させます。</span><span class="sxs-lookup"><span data-stu-id="27719-108">The way you do this is to name your resources’ folders or files to match the qualifier names and qualifier values that correspond to those contexts.</span></span> <span data-ttu-id="27719-109">たとえば、ハイ コントラスト モードでは別のセットのイメージ アセットをアプリに読み込む、ということもできます。</span><span class="sxs-lookup"><span data-stu-id="27719-109">For example, you may want your app to load a different set of image assets in high contrast mode.</span></span>

<span data-ttu-id="27719-110">アプリのローカライズの価値提案の詳細については、「[グローバリゼーションとローカライズ](../design/globalizing/globalizing-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-110">For more info about the value proposition of localizing your app, see [Globalization and localization](../design/globalizing/globalizing-portal.md).</span></span>

## <a name="qualifier-name-qualifier-value-and-qualifier"></a><span data-ttu-id="27719-111">修飾子名、修飾子の値、修飾子</span><span class="sxs-lookup"><span data-stu-id="27719-111">Qualifier name, qualifier value, and qualifier</span></span>

<span data-ttu-id="27719-112">修飾子名は、一連の修飾子の値にマップされるキーです。</span><span class="sxs-lookup"><span data-stu-id="27719-112">A qualifier name is a key that maps to a set of qualifier values.</span></span> <span data-ttu-id="27719-113">修飾子の名前と修飾子の値を次に示します。</span><span class="sxs-lookup"><span data-stu-id="27719-113">Here are the qualifier name and qualifier values for contrast.</span></span>

| <span data-ttu-id="27719-114">コンテキスト</span><span class="sxs-lookup"><span data-stu-id="27719-114">Context</span></span> | <span data-ttu-id="27719-115">修飾子名</span><span class="sxs-lookup"><span data-stu-id="27719-115">Qualifier name</span></span> | <span data-ttu-id="27719-116">修飾子の値</span><span class="sxs-lookup"><span data-stu-id="27719-116">Qualifier values</span></span> |
| :--------------- | :--------------- | :--------------- |
| <span data-ttu-id="27719-117">ハイ コントラスト設定</span><span class="sxs-lookup"><span data-stu-id="27719-117">The high contrast setting</span></span> | <span data-ttu-id="27719-118">contrast</span><span class="sxs-lookup"><span data-stu-id="27719-118">contrast</span></span> | <span data-ttu-id="27719-119">standard、high、black、white</span><span class="sxs-lookup"><span data-stu-id="27719-119">standard, high, black, white</span></span> |

<span data-ttu-id="27719-120">修飾子は、修飾子名と修飾子の値を組み合わせて作成します。</span><span class="sxs-lookup"><span data-stu-id="27719-120">You combine a qualifier name with a qualifier value to form a qualifier.</span></span> <span data-ttu-id="27719-121">`<qualifier name>-<qualifier value>` 修飾子の形式です。</span><span class="sxs-lookup"><span data-stu-id="27719-121">`<qualifier name>-<qualifier value>` is the format of a qualifier.</span></span> <span data-ttu-id="27719-122">`contrast-standard` 修飾子の例に示します。</span><span class="sxs-lookup"><span data-stu-id="27719-122">`contrast-standard` is an example of a qualifier.</span></span>

<span data-ttu-id="27719-123">ハイ コントラストの場合、修飾子のセットは `contrast-standard`、`contrast-high`、`contrast-black`、`contrast-white` になります。</span><span class="sxs-lookup"><span data-stu-id="27719-123">So, for high contrast, the set of qualifiers is `contrast-standard`, `contrast-high`, `contrast-black`, and `contrast-white`.</span></span> <span data-ttu-id="27719-124">修飾子名と修飾子の値では、大文字と小文字が区別されません。</span><span class="sxs-lookup"><span data-stu-id="27719-124">Qualifier names and qualifier values are not case sensitive.</span></span> <span data-ttu-id="27719-125">たとえば、`contrast-standard` と `Contrast-Standard` は同じ修飾子であると見なされます。</span><span class="sxs-lookup"><span data-stu-id="27719-125">For example, `contrast-standard` and `Contrast-Standard` are the same qualifier.</span></span>

## <a name="use-qualifiers-in-folder-names"></a><span data-ttu-id="27719-126">修飾子をフォルダー名に使用する</span><span class="sxs-lookup"><span data-stu-id="27719-126">Use qualifiers in folder names</span></span>

<span data-ttu-id="27719-127">アセット ファイルが含まれるフォルダーに、修飾子を使用して名前を付ける例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="27719-127">Here is an example of using qualifiers to name folders that contain asset files.</span></span> <span data-ttu-id="27719-128">修飾子ごとに複数のアセット ファイルがある場合は、フォルダー名に修飾子を使用します。</span><span class="sxs-lookup"><span data-stu-id="27719-128">Use qualifiers in folder names if you have several asset files per qualifier.</span></span> <span data-ttu-id="27719-129">これにより、フォルダー レベルで一度だけ修飾子を設定すると、この修飾子がフォルダー内のすべての項目に適用されます。</span><span class="sxs-lookup"><span data-stu-id="27719-129">That way, you set the qualifier once at the folder level, and the qualifier applies to everything inside the folder.</span></span>

```console
\Assets\Images\contrast-standard\<logo.png, and other image files>
\Assets\Images\contrast-high\<logo.png, and other image files>
\Assets\Images\contrast-black\<logo.png, and other image files>
\Assets\Images\contrast-white\<logo.png, and other image files>
```

<span data-ttu-id="27719-130">上の例のようにフォルダーの名前を付けた場合、アプリはハイ コントラスト設定を使用して、適切な修飾子名が適用されたフォルダーからリソース ファイルを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="27719-130">If you name your folders as in the example above, then your app uses the high contrast setting to load resource files from the folder named for the appropriate qualifier.</span></span> <span data-ttu-id="27719-131">このため、設定が [ハイ コントラスト 黒] であれば、`\Assets\Images\contrast-black` フォルダー内のリソース ファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-131">So, if the setting is High Contrast Black, then the resource files in the `\Assets\Images\contrast-black` folder are loaded.</span></span> <span data-ttu-id="27719-132">設定が [なし] (コンピューターがハイ コントラスト モードではない) の場合は、`\Assets\Images\contrast-standard` フォルダー内のリソース ファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-132">If the setting is None (that is, the computer is not in high contrast mode), then the resource files in the `\Assets\Images\contrast-standard` folder are loaded.</span></span>

## <a name="use-qualifiers-in-file-names"></a><span data-ttu-id="27719-133">修飾子をファイル名に使用する</span><span class="sxs-lookup"><span data-stu-id="27719-133">Use qualifiers in file names</span></span>

<span data-ttu-id="27719-134">フォルダーを作成して名前を付ける代わりに、修飾子を使用してリソース ファイル自体の名前を付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="27719-134">Instead of creating and naming folders, you can use a qualifier to name the resource files themselves.</span></span> <span data-ttu-id="27719-135">1 つの修飾子につきリソース ファイルが 1 つのみの場合は、この方法が適しています。</span><span class="sxs-lookup"><span data-stu-id="27719-135">You might prefer to do this if you only have one resource file per qualifier.</span></span> <span data-ttu-id="27719-136">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="27719-136">Here’s an example.</span></span>

```console
\Assets\Images\logo.contrast-standard.png
\Assets\Images\logo.contrast-high.png
\Assets\Images\logo.contrast-black.png
\Assets\Images\logo.contrast-white.png
```

<span data-ttu-id="27719-137">読み込まれるのは、設定に最も適した修飾子を含む名前のファイルです。</span><span class="sxs-lookup"><span data-stu-id="27719-137">The file whose name contains the qualifier most appropriate for the setting is the one that is loaded.</span></span> <span data-ttu-id="27719-138">ファイル名についても、フォルダー名と同様の照合ロジックが使用されます。</span><span class="sxs-lookup"><span data-stu-id="27719-138">This matching logic works the same way for file names as for folder names.</span></span>

## <a name="reference-a-string-or-image-resource-by-name"></a><span data-ttu-id="27719-139">文字列または画像リソースを名前で参照する</span><span class="sxs-lookup"><span data-stu-id="27719-139">Reference a string or image resource by name</span></span>

<span data-ttu-id="27719-140">「[XAML マークアップから文字列リソース識別子を参照する](localize-strings-ui-manifest.md#refer-to-a-string-resource-identifier-from-xaml-markup)」、「[コードから文字列リソース識別子を参照する](localize-strings-ui-manifest.md#refer-to-a-string-resource-identifier-from-code)」、「[XAML マークアップとコードから画像やその他のアセットを参照する](images-tailored-for-scale-theme-contrast.md#reference-an-image-or-other-asset-from-xaml-markup-and-code)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-140">See [Refer to a string resource identifier from XAML markup](localize-strings-ui-manifest.md#refer-to-a-string-resource-identifier-from-xaml-markup), [Refer to a string resource identifier from code](localize-strings-ui-manifest.md#refer-to-a-string-resource-identifier-from-code), and [Reference an image or other asset from XAML markup and code](images-tailored-for-scale-theme-contrast.md#reference-an-image-or-other-asset-from-xaml-markup-and-code).</span></span>

## <a name="actual-and-neutral-qualifier-matches"></a><span data-ttu-id="27719-141">修飾子の実際の一致と中立的な一致</span><span class="sxs-lookup"><span data-stu-id="27719-141">Actual and neutral qualifier matches</span></span>
<span data-ttu-id="27719-142">修飾子の値の*すべて*にリソース ファイルを指定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="27719-142">You don’t need to provide a resource file for *every* qualifier value.</span></span> <span data-ttu-id="27719-143">たとえば、ハイ コントラスト用と標準コントラスト用にビジュアル アセットを各 1 つのみ必要とする場合は、これらのアセット名を次のように付けることができます。</span><span class="sxs-lookup"><span data-stu-id="27719-143">For example, if you find that you only need one visual asset for high contrast and one for standard contrast, then you can name those assets like this.</span></span>

```console
\Assets\Images\logo.contrast-high.png
\Assets\Images\logo.png
```

<span data-ttu-id="27719-144">最初のファイル名には、`contrast-high` 修飾子が含まれています。</span><span class="sxs-lookup"><span data-stu-id="27719-144">The first file name contains the `contrast-high` qualifier.</span></span> <span data-ttu-id="27719-145">ハイ コントラストが *[オン]* になっている場合、この修飾子は、あらゆるハイ コントラスト設定に対する*実際の*一致です。</span><span class="sxs-lookup"><span data-stu-id="27719-145">That qualifier is an *actual* match for any high contrast setting when high contrast is *on*.</span></span> <span data-ttu-id="27719-146">言い換えると、これは近似一致であり、優先されます。</span><span class="sxs-lookup"><span data-stu-id="27719-146">In other words, it's a close match so it’s preferred.</span></span> <span data-ttu-id="27719-147">この場合のように、*実際*の一致は、修飾子に*実際*の値が含まれている場合にのみ発生します。</span><span class="sxs-lookup"><span data-stu-id="27719-147">An *actual* match can only occur if the qualifier contains an *actual* value, as this one does.</span></span> <span data-ttu-id="27719-148">この場合、`high` が `contrast` に対する*実際*の値です。</span><span class="sxs-lookup"><span data-stu-id="27719-148">In this case, `high` is an *actual* value for `contrast`.</span></span>

<span data-ttu-id="27719-149">`logo.png` というファイル名には、contrast 修飾子がまったく含まれていません。</span><span class="sxs-lookup"><span data-stu-id="27719-149">The file named `logo.png` has no contrast qualifier on it at all.</span></span> <span data-ttu-id="27719-150">修飾子がない値は、*中立的*です。</span><span class="sxs-lookup"><span data-stu-id="27719-150">The absence of a qualifier is a *neutral* value.</span></span> <span data-ttu-id="27719-151">優先される一致が見つからない場合、中立値はフォールバックの一致として使用されます。</span><span class="sxs-lookup"><span data-stu-id="27719-151">If no preferred match can be found, then the neutral value serves as a fallback match.</span></span> <span data-ttu-id="27719-152">この例では、ハイ コントラストが*オフ*になっている場合、実際の一致はありません。</span><span class="sxs-lookup"><span data-stu-id="27719-152">In this example, if high contrast is *off*, then there is no actual match.</span></span> <span data-ttu-id="27719-153">見つかるベスト マッチが*中立的*な一致であるため、`logo.png` というアセットが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-153">The *neutral* match is the best match that can be found, and so the asset `logo.png` is loaded.</span></span>

<span data-ttu-id="27719-154">`logo.png` の名前を `logo.contrast-standard.png` に変更すると、ファイル名に実際の修飾子の値が含まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-154">If you were to change the name of `logo.png` to `logo.contrast-standard.png`, then the file name would contain an actual qualifier value.</span></span> <span data-ttu-id="27719-155">ハイ コントラストがオフになっている場合、`logo.contrast-standard.png` との実際の一致があり、このアセット ファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-155">With high contrast off, there would be an actual match with `logo.contrast-standard.png`, and that’s the asset file that would be loaded.</span></span> <span data-ttu-id="27719-156">このため、別々の一致が原因ですが、同じ条件下で同じファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-156">So, the same files would be loaded, under the same conditions, but because of different matches.</span></span>

<span data-ttu-id="27719-157">必要なアセット セットが、ハイ コントラスト用に 1 つと標準コントラスト用に 1 つのみである場合は、ファイル名の代わりにフォルダー名を使用できます。</span><span class="sxs-lookup"><span data-stu-id="27719-157">If you only need one set of assets for high contrast and one set for standard contrast, then you can use folder names instead of file names.</span></span> <span data-ttu-id="27719-158">この場合、フォルダー名を省略すると、完全に中立的な一致になります。</span><span class="sxs-lookup"><span data-stu-id="27719-158">In this case, omitting the folder name entirely gives you the neutral match.</span></span>

```console
\Assets\Images\contrast-high\<logo.png, and other images to load when high contrast theme is not None>
\Assets\Images\<logo.png, and other images to load when high contrast theme is None>
```

<span data-ttu-id="27719-159">修飾子の照合について詳しくは、「[リソース管理システム](resource-management-system.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="27719-159">For more details on how qualifier matching works, see [Resource Management System](resource-management-system.md).</span></span>

## <a name="multiple-qualifiers"></a><span data-ttu-id="27719-160">複数の修飾子</span><span class="sxs-lookup"><span data-stu-id="27719-160">Multiple qualifiers</span></span>

<span data-ttu-id="27719-161">修飾子は、フォルダー名とファイル名で組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="27719-161">You can combine qualifiers in folder and file names.</span></span> <span data-ttu-id="27719-162">たとえば、ハイ コントラスト モードがオンであり*表示倍率が* 400 のときに、イメージ アセットをアプリに読み込むとします。</span><span class="sxs-lookup"><span data-stu-id="27719-162">For example, you may want your app to load image assets when high contrast mode is on *and* the display scale factor is 400.</span></span> <span data-ttu-id="27719-163">これを行う方法の 1 つは、入れ子になったフォルダーの使用です。</span><span class="sxs-lookup"><span data-stu-id="27719-163">One way to do this is with nested folders.</span></span>

```console
\Assets\Images\contrast-high\scale-400\<logo.png, and other image files>
```

<span data-ttu-id="27719-164">`logo.png` およびその他のファイルを読み込むには、設定が*両方*の修飾子と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="27719-164">For `logo.png` and the other files to be loaded, the settings must match *both* qualifiers.</span></span>

<span data-ttu-id="27719-165">もう 1 つのオプションは、複数の修飾子を結合して 1 つのフォルダー名にすることです。</span><span class="sxs-lookup"><span data-stu-id="27719-165">Another option is to combine multiple qualifiers in one folder name.</span></span>

```console
\Assets\Images\contrast-high_scale-400\<logo.png, and other image files>
```

<span data-ttu-id="27719-166">フォルダー名として、複数の修飾子をアンダー スコアで結合します。</span><span class="sxs-lookup"><span data-stu-id="27719-166">In a folder name, you combine multiple qualifiers separated with an underscore.</span></span> <span data-ttu-id="27719-167">`<qualifier1>[_<qualifier2>...]` 形式です。</span><span class="sxs-lookup"><span data-stu-id="27719-167">`<qualifier1>[_<qualifier2>...]` is the format.</span></span>

<span data-ttu-id="27719-168">同じ形式で、複数の修飾子を結合して 1 つのファイル名にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="27719-168">You can combine multiple qualifiers in a file name in the same format.</span></span>

```console
\Assets\Images\logo.contrast-high_scale-400.png
```

<span data-ttu-id="27719-169">アセット作成に使用するツールとワークフローや、読みやすさや管理のしやすさによって、すべての修飾子に単一の命名方法を選択することも、修飾子によって異なる方法を組み合わせることもできます。</span><span class="sxs-lookup"><span data-stu-id="27719-169">Depending on the tools and workflow you use for asset-creation, or on what you find easiest to read and/or manage, you can either choose a single naming strategy for all qualifiers, or you can combine them for different qualifiers.</span></span>

## <a name="alternateform"></a><span data-ttu-id="27719-170">AlternateForm</span><span class="sxs-lookup"><span data-stu-id="27719-170">AlternateForm</span></span>

<span data-ttu-id="27719-171">特別な目的でリソースの代替フォームを提供するには、`alternateform` 修飾子を使います。</span><span class="sxs-lookup"><span data-stu-id="27719-171">The `alternateform` qualifier is used to provide an alternate form of a resource for some special purpose.</span></span> <span data-ttu-id="27719-172">通常、日本のアプリ開発者によってふりがな文字列を提供する目的のみで使用されます。そのために、`msft-phonetic` という値が予約されています (「[ローカライズの準備をする方法](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh967762)」の「並べ替えることができる日本語文字列のふりがなのサポート」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="27719-172">This is typically used only by Japanese app developers to provide a furigana string for which the value `msft-phonetic` is reserved (see the section “Support Furigana for Japanese strings that can be sorted” in [How to prepare for localization](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh967762)).</span></span>

<span data-ttu-id="27719-173">ターゲット システムとアプリのうちいずれかが、`alternateform` 修飾子と一致する値を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="27719-173">Either your target system or your app must provide a value against which `alternateform` qualifiers are matched.</span></span> <span data-ttu-id="27719-174">カスタムの `alternateform` 修飾子の値に `msft-` プレフィックスを使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="27719-174">Do not use the `msft-` prefix for your own custom `alternateform` qualifier values.</span></span>

## <a name="configuration"></a><span data-ttu-id="27719-175">構成</span><span class="sxs-lookup"><span data-stu-id="27719-175">Configuration</span></span>

<span data-ttu-id="27719-176">`configuration` 修飾子名が必要になる可能性は高くありません。</span><span class="sxs-lookup"><span data-stu-id="27719-176">It’s unlikely that you’ll need the `configuration` qualifier name.</span></span> <span data-ttu-id="27719-177">テストのみのリソースなど、オーサリング時環境にのみ使用されるリソースを指定するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="27719-177">It can be used to specify resources that are applicable only to a given authoring-time environment, such as test-only resources.</span></span>

<span data-ttu-id="27719-178">`configuration` 修飾子は、`MS_CONFIGURATION_ATTRIBUTE_VALUE` 環境変数の値と最も一致するリソースを読み込むために使用します。</span><span class="sxs-lookup"><span data-stu-id="27719-178">The `configuration` qualifier is used to load a resource that best matches the value of the `MS_CONFIGURATION_ATTRIBUTE_VALUE` environment variable.</span></span> <span data-ttu-id="27719-179">このため、この変数は、関連するリソースに割り当てられた文字列値 (`designer` や `test` など) に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="27719-179">So, you can set the variable to the string value that has been assigned to the relevant resources, for example `designer`, or `test`.</span></span>

## <a name="contrast"></a><span data-ttu-id="27719-180">Contrast</span><span class="sxs-lookup"><span data-stu-id="27719-180">Contrast</span></span>

<span data-ttu-id="27719-181">`contrast` 修飾子は、ハイ コントラスト設定と最も一致するリソースを提供するために使用します。</span><span class="sxs-lookup"><span data-stu-id="27719-181">The `contrast` qualifier is used to provide resources that best match high contrast settings.</span></span>

## <a name="custom"></a><span data-ttu-id="27719-182">カスタム</span><span class="sxs-lookup"><span data-stu-id="27719-182">Custom</span></span>

<span data-ttu-id="27719-183">アプリで `custom` 修飾子の値を設定すると、その値に最も一致するリソースが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-183">Your app can set a value for the `custom` qualifier, and then resources are loaded that best match that value.</span></span> <span data-ttu-id="27719-184">たとえば、アプリのライセンスに基づいてリソースを読み込む必要があるとします。</span><span class="sxs-lookup"><span data-stu-id="27719-184">For example, you may want to load resources based on your app’s license.</span></span> <span data-ttu-id="27719-185">アプリは、起動するとライセンスを確認し、[SetGlobalQualifierValue](/uwp/api/windows.applicationmodel.resources.core.resourcecontext.setglobalqualifiervalue) を呼び出すことによって、ライセンスを `custom` 修飾子の値として使用します。コード例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-185">When your app launches, it checks its license and uses that as the value for the `custom` qualifier by calling [SetGlobalQualifierValue](/uwp/api/windows.applicationmodel.resources.core.resourcecontext.setglobalqualifiervalue), as shown in the code example.</span></span>

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

<span data-ttu-id="27719-186">このシナリオでは、修飾子 `custom-premium`、`custom-standard`、および `custom-trial` をそれぞれ含む名前をリソースに適用します。</span><span class="sxs-lookup"><span data-stu-id="27719-186">In this scenario, you would then give your resources names that include the qualifiers `custom-premium`, `custom-standard`, and `custom-trial`.</span></span>

## <a name="devicefamily"></a><span data-ttu-id="27719-187">DeviceFamily</span><span class="sxs-lookup"><span data-stu-id="27719-187">DeviceFamily</span></span>

<span data-ttu-id="27719-188">`devicefamily` 修飾子名が必要になる可能性は高くありません。</span><span class="sxs-lookup"><span data-stu-id="27719-188">It’s unlikely that you’ll need the `devicefamily` qualifier name.</span></span> <span data-ttu-id="27719-189">他にもっと便利で強力な修飾子を使う手法があるため、この修飾子名の使用はできる限り避けてください。</span><span class="sxs-lookup"><span data-stu-id="27719-189">You can and should avoid using it whenever possible because there are techniques that you can use instead that are much more convenient and robust.</span></span> <span data-ttu-id="27719-190">このような手法については、「[アプリが実行されているプラットフォームの検出](../porting/wpsl-to-uwp-input-and-sensors.md#detecting-the-platform-your-app-is-running-on)」および「[バージョン アダプティブ コード](https://docs.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="27719-190">Those techniques are described in [Detecting the platform your app is running on](../porting/wpsl-to-uwp-input-and-sensors.md#detecting-the-platform-your-app-is-running-on) and [Version adaptive code](https://docs.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code).</span></span>

<span data-ttu-id="27719-191">ただし他に方法がなければ、XAML ビュー (XAML ビューは、UI レイアウトとコントロールを含む XAML ファイル) を格納するフォルダーの名前として devicefamily という修飾子を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="27719-191">But as a last resort it is possible to use devicefamily qualifiers to name folders that contain your XAML views (a XAML view is a XAML file that contains UI layout and controls).</span></span>

```console
\devicefamily-desktop\<MainPage.xaml, and other markup files to load when running on a desktop computer>
\devicefamily-mobile\<MainPage.xaml, and other markup files to load when running on a phone>
```

<span data-ttu-id="27719-192">または、次のようにファイルに命名することもできます。</span><span class="sxs-lookup"><span data-stu-id="27719-192">Or you can name files.</span></span>

```console
\MainPage.devicefamily-desktop.xaml
\MainPage.devicefamily-mobile.xaml
```

<span data-ttu-id="27719-193">いずれの場合も、`MainPage.[<qualifier>].xaml` の各コピーで、共通の `MainPage.xaml.cs` が使用されます (プロジェクト内で名前、場所、コンテンツが変わりません)。</span><span class="sxs-lookup"><span data-stu-id="27719-193">In either case each copy of `MainPage.[<qualifier>].xaml` shares a common `MainPage.xaml.cs`, which remains unchanged in your project in terms of name, location, and contents.</span></span>

<span data-ttu-id="27719-194">また、devicefamily 修飾子を使用してリソース ファイル (`.resw`) またはフォルダーに名前を付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="27719-194">You can also use a devicefamily qualifier to name a Resources File (`.resw`), or folder.</span></span> <span data-ttu-id="27719-195">たとえば、モバイル デバイス ファミリでアプリが実行されている場合、UI 要素 `<TextBlock x:Uid="DeviceFriendlyName"/>` では、`Resources.devicefamily-mobile.resw` ファイルに定義されているテキストと前景リソースが使用されます。以下はその例です。</span><span class="sxs-lookup"><span data-stu-id="27719-195">For example, when your app is running on the mobile device family, the UI element `<TextBlock x:Uid="DeviceFriendlyName"/>` will use the text and foreground resources defined in your `Resources.devicefamily-mobile.resw` file if it contains</span></span>

```xml
<data name="DeviceFriendlyName.Foreground">
    <value>Red</value>
</data>
<data name="DeviceFriendlyName.Text">
    <value>Mobile device</value>
</data>
```

<span data-ttu-id="27719-196">リソース ファイルの使用について詳しくは、[UI 文字列のローカライズ](localize-strings-ui-manifest.md)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-196">For more on using a Resources File, see [Localize your UI strings](localize-strings-ui-manifest.md).</span></span>

## <a name="dxfeaturelevel"></a><span data-ttu-id="27719-197">DXFeatureLevel</span><span class="sxs-lookup"><span data-stu-id="27719-197">DXFeatureLevel</span></span>

<span data-ttu-id="27719-198">`dxfeaturelevel` 修飾子名が必要になる可能性は高くありません。</span><span class="sxs-lookup"><span data-stu-id="27719-198">It’s unlikely that you’ll need the `dxfeaturelevel` qualifier name.</span></span> <span data-ttu-id="27719-199">これは Direct3D ゲーム アセットで使用し、以前の特定な下位レベル ハードウェア構成に一致するように、下位レベルのリソースを読み込むために用意されたものです。</span><span class="sxs-lookup"><span data-stu-id="27719-199">It was designed to be used with Direct3D game assets, to cause downlevel resources to be loaded to match a particular downlevel hardware configuration of the time.</span></span> <span data-ttu-id="27719-200">ただ、このハードウェア構成はあまり普及していないため、この修飾子は使用しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="27719-200">But the prevalence of that hardware configuration is now so low that we recommend you don’t use this qualifier.</span></span>

## <a name="homeregion"></a><span data-ttu-id="27719-201">HomeRegion</span><span class="sxs-lookup"><span data-stu-id="27719-201">HomeRegion</span></span>

<span data-ttu-id="27719-202">`homeregion` 修飾子は、国または地域のユーザー設定に対応します。</span><span class="sxs-lookup"><span data-stu-id="27719-202">The `homeregion` qualifier corresponds to the user’s setting for country or region.</span></span> <span data-ttu-id="27719-203">ユーザーが住んでいる地域の場所を表します。</span><span class="sxs-lookup"><span data-stu-id="27719-203">It represents the home location of the user.</span></span> <span data-ttu-id="27719-204">値には、有効な [BCP-47 region タグ](https://go.microsoft.com/fwlink/p/?linkid=227302)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-204">Values include any valid [BCP-47 region tag](https://go.microsoft.com/fwlink/p/?linkid=227302).</span></span> <span data-ttu-id="27719-205">つまり、**ISO 3166-1 alpha-2** の 2 文字の地域番号に、構成地域用の **ISO 3166-1 numeric** の 3 桁の地域番号のセットを加えた値となります ([国連統計部 M49 地域番号構成に関するページ](https://go.microsoft.com/fwlink/p/?linkid=247929)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="27719-205">That is, any **ISO 3166-1 alpha-2** two-letter region code, plus the set of **ISO 3166-1 numeric** three-digit geographic codes for composed regions (see [United Nations Statistic Division M49 composition of region codes](https://go.microsoft.com/fwlink/p/?linkid=247929)).</span></span> <span data-ttu-id="27719-206">"Selected economic and other groupings" の番号は有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="27719-206">Codes for "Selected economic and other groupings" are not valid.</span></span>

## <a name="language"></a><span data-ttu-id="27719-207">言語</span><span class="sxs-lookup"><span data-stu-id="27719-207">Language</span></span>

<span data-ttu-id="27719-208">`language` 修飾子は、表示言語設定に対応します。</span><span class="sxs-lookup"><span data-stu-id="27719-208">A `language` qualifier corresponds to the display language setting.</span></span> <span data-ttu-id="27719-209">値には、有効な [BCP 47 language タグ](https://go.microsoft.com/fwlink/p/?linkid=227302)が含まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-209">Values include any valid [BCP-47 language tag](https://go.microsoft.com/fwlink/p/?linkid=227302).</span></span> <span data-ttu-id="27719-210">言語の一覧については、[IANA 言語サブタグ レジストリに関するページ](https://go.microsoft.com/fwlink/p/?linkid=227303)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-210">For a list of languages, see the [IANA language subtag registry](https://go.microsoft.com/fwlink/p/?linkid=227303).</span></span>

<span data-ttu-id="27719-211">アプリで複数の表示言語をサポートする必要があり、コードまたは XAML マークアップ内に文字列リテラルが含まれている場合は、その文字列をコードまたはマークアップからリソース ファイル (`.resw`) に移動します。</span><span class="sxs-lookup"><span data-stu-id="27719-211">If you want your app to support different display languages, and you have string literals in your code or in your XAML markup, then move those strings out of the code/markup and into a Resources File (`.resw`).</span></span> <span data-ttu-id="27719-212">アプリでサポートする各言語用に、このリソース ファイルを翻訳したコピーを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="27719-212">You can then make a translated copy of that Resources File for each language that your app supports.</span></span>

<span data-ttu-id="27719-213">`language` 修飾子は通常、リソース ファイル (`.resw`) が含まれているフォルダーの命名に使用します。</span><span class="sxs-lookup"><span data-stu-id="27719-213">You typically use a `language` qualifier to name the folders that contain your Resources Files (`.resw`).</span></span>

```console
\Strings\language-en\Resources.resw
\Strings\language-ja\Resources.resw
```

<span data-ttu-id="27719-214">`language` 修飾子の `language-` の部分 (修飾子名) は省略することができます。</span><span class="sxs-lookup"><span data-stu-id="27719-214">You can omit the `language-` part of a `language` qualifier (that is, the qualifier name).</span></span> <span data-ttu-id="27719-215">これは他の種類の修飾子には適用されません。また、適用できるのはフォルダー名の場合のみです。</span><span class="sxs-lookup"><span data-stu-id="27719-215">You can’t do this with the other kinds of qualifiers; and you can only do it in a folder name.</span></span>

```console
\Strings\en\Resources.resw
\Strings\ja\Resources.resw
```

<span data-ttu-id="27719-216">フォルダーに名前を付ける代わりに、`language` 修飾子を使用してリソース ファイル自体の名前を付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="27719-216">Instead of naming folders, you can use `language` qualifiers to name the Resources Files themselves.</span></span>

```console
\Strings\Resources.language-en.resw
\Strings\Resources.language-ja.resw
```

<span data-ttu-id="27719-217">文字列リソースを使用してアプリをローカライズ可能にする方法と、アプリ内で文字列リソースを参照する方法について詳しくは、[UI 文字列のローカライズに関するページ](localize-strings-ui-manifest.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-217">See [Localize your UI strings](localize-strings-ui-manifest.md) for more information on making your app localizable by using string resources, and how to reference a string resource in your app.</span></span>

## <a name="layoutdirection"></a><span data-ttu-id="27719-218">LayoutDirection</span><span class="sxs-lookup"><span data-stu-id="27719-218">LayoutDirection</span></span>

<span data-ttu-id="27719-219">`layoutdirection` 修飾子は、表示言語設定のレイアウト方向に対応します。</span><span class="sxs-lookup"><span data-stu-id="27719-219">A `layoutdirection` qualifier corresponds to the layout direction of the display language setting.</span></span> <span data-ttu-id="27719-220">たとえば、アラビア語やヘブライ語などの右から左に記述する言語では、イメージの反転が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="27719-220">For example, an image may need to be mirrored for a right-to-left language such as Arabic or Hebrew.</span></span> <span data-ttu-id="27719-221">UI のレイアウト パネルとイメージは、[FlowDirection](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを設定すると、レイアウト方向が正しく反映されます (「[レイアウトやフォントの調整と RTL のサポート](../design/globalizing/adjust-layout-and-fonts--and-support-rtl.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="27719-221">Layout panels and images in your UI will respond to layout direction appropriately if you set their [FlowDirection](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) property (see [Adjust layout and fonts, and support RTL](../design/globalizing/adjust-layout-and-fonts--and-support-rtl.md)).</span></span> <span data-ttu-id="27719-222">`layoutdirection` 修飾子は、単純な反転だけでは十分でないケースを想定し、特定の読み取り順序の辞書やテキスト配置にも、より一般的な方法で対応することができます。</span><span class="sxs-lookup"><span data-stu-id="27719-222">However, the `layoutdirection` qualifier is for cases where simple flipping isn't adequate, and it allows you to respond to the directionality of specific reading order and text alignment in more general ways.</span></span>

## <a name="scale"></a><span data-ttu-id="27719-223">Scale</span><span class="sxs-lookup"><span data-stu-id="27719-223">Scale</span></span>

<span data-ttu-id="27719-224">Windows では、ディスプレイの DPI (1 インチあたりのドット数) と、デバイスの視聴距離に基づいて各ディスプレイの倍率が自動的に選択されます。</span><span class="sxs-lookup"><span data-stu-id="27719-224">Windows automatically selects a scale factor for each display based on its DPI (dots-per-inch) and the viewing distance of the device.</span></span> <span data-ttu-id="27719-225">「[有効ピクセルと倍率](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md#effective-pixels-and-scale-factor)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-225">See [Effective pixels and scale factor](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md#effective-pixels-and-scale-factor).</span></span> <span data-ttu-id="27719-226">Windows で最適なサイズを選択したり、最も近いサイズを使用して拡大または縮小したりできるように、いくつかの推奨されるサイズ (少なくとも、100、200、400) で画像を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="27719-226">You should create your images at several recommended sizes (at least 100, 200, and 400) so that Windows can either choose the perfect size or can use the nearest size and scale it.</span></span> <span data-ttu-id="27719-227">Windows で表示倍率に対して正確なサイズの画像を含む物理ファイルを識別できるように、`scale` 修飾子を使用します。</span><span class="sxs-lookup"><span data-stu-id="27719-227">So that Windows can identify which physical file contains the correct size of image for the display scale factor, you use a `scale` qualifier.</span></span> <span data-ttu-id="27719-228">リソースのスケールは、[DisplayInformation.ResolutionScale](/uwp/api/windows.graphics.display.displayinformation.ResolutionScale) の値、または次に大きい拡大リソースに一致します。</span><span class="sxs-lookup"><span data-stu-id="27719-228">The scale of a resource matches the value of [DisplayInformation.ResolutionScale](/uwp/api/windows.graphics.display.displayinformation.ResolutionScale), or the next-largest-scaled resource.</span></span>

<span data-ttu-id="27719-229">フォルダー レベルで修飾子を設定する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="27719-229">Here’s an example of setting the qualifier at the folder level.</span></span>

```console
\Assets\Images\scale-100\<logo.png, and other image files>
\Assets\Images\scale-200\<logo.png, and other image files>
\Assets\Images\scale-400\<logo.png, and other image files>
```

<span data-ttu-id="27719-230">この例では、ファイル レベルで修飾子を設定します。</span><span class="sxs-lookup"><span data-stu-id="27719-230">And this example sets it at the file level.</span></span>

```console
\Assets\Images\logo.scale-100.png
\Assets\Images\logo.scale-200.png
\Assets\Images\logo.scale-400.png
```

<span data-ttu-id="27719-231">`scale` と `targetsize` でリソースを修飾する方法については、「[targetsize で画像リソースを修飾する](images-tailored-for-scale-theme-contrast.md#qualify-an-image-resource-for-targetsize)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-231">For info about qualifying a resource for both `scale` and `targetsize`, see [Qualify an image resource for targetsize](images-tailored-for-scale-theme-contrast.md#qualify-an-image-resource-for-targetsize).</span></span>

## <a name="targetsize"></a><span data-ttu-id="27719-232">TargetSize</span><span class="sxs-lookup"><span data-stu-id="27719-232">TargetSize</span></span>

<span data-ttu-id="27719-233">`targetsize` 修飾子は主に、エクスプローラーに表示される[ファイルの種類の関連付け](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh127427)アイコンまたは[プロトコル アイコン](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/bb266530)の指定に使用されます。</span><span class="sxs-lookup"><span data-stu-id="27719-233">The `targetsize` qualifier is primarily used to specify [file type association icons](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh127427) or [protocol icons](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/bb266530) to be shown in File Explorer.</span></span> <span data-ttu-id="27719-234">この修飾子の値は、正方形のイメージの辺の長さを RAW (物理) ピクセル単位で表します。</span><span class="sxs-lookup"><span data-stu-id="27719-234">The qualifier value represents the side length of a square image in raw (physical) pixels.</span></span> <span data-ttu-id="27719-235">エクスプローラーの表示設定に値が一致するリソースが読み込まれます。正確に一致する対象が存在しない場合は、次に大きな値のリソースが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="27719-235">The resource whose value matches the View setting in File Explorer is loaded; or the resource with the next-largest value in the absence of an exact match.</span></span>

<span data-ttu-id="27719-236">アプリ パッケージ マニフェスト デザイナーの [ビジュアル資産] タブで、複数サイズのアプリ アイコン (`/Assets/Square44x44Logo.png`) に対応する `targetsize` 修飾子の値を表すアセットを定義できます。</span><span class="sxs-lookup"><span data-stu-id="27719-236">You can define assets that represent several sizes of `targetsize` qualifier value for the App Icon (`/Assets/Square44x44Logo.png`) in the Visual Assets tab of the app package manifest designer.</span></span>

<span data-ttu-id="27719-237">`scale` と `targetsize` でリソースを修飾する方法については、「[targetsize で画像リソースを修飾する](images-tailored-for-scale-theme-contrast.md#qualify-an-image-resource-for-targetsize)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="27719-237">For info about qualifying a resource for both `scale` and `targetsize`, see [Qualify an image resource for targetsize](images-tailored-for-scale-theme-contrast.md#qualify-an-image-resource-for-targetsize).</span></span>

## <a name="theme"></a><span data-ttu-id="27719-238">Theme</span><span class="sxs-lookup"><span data-stu-id="27719-238">Theme</span></span>

<span data-ttu-id="27719-239">`theme` 修飾子は、既定のアプリ モード設定に最も一致するリソースか、[Application.RequestedTheme](/uwp/api/windows.ui.xaml.application.requestedtheme) を使用してアプリのオーバーライドを提供するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="27719-239">The `theme` qualifier is used to provide resources that best match the default app mode setting, or your app’s override using [Application.RequestedTheme](/uwp/api/windows.ui.xaml.application.requestedtheme).</span></span>

## <a name="important-apis"></a><span data-ttu-id="27719-240">重要な API</span><span class="sxs-lookup"><span data-stu-id="27719-240">Important APIs</span></span>

* [<span data-ttu-id="27719-241">ResourceContext.QualifierValues</span><span class="sxs-lookup"><span data-stu-id="27719-241">ResourceContext.QualifierValues</span></span>](/uwp/api/windows.applicationmodel.resources.core.resourcecontext.QualifierValues)
* [<span data-ttu-id="27719-242">SetGlobalQualifierValue</span><span class="sxs-lookup"><span data-stu-id="27719-242">SetGlobalQualifierValue</span></span>](/uwp/api/windows.applicationmodel.resources.core.resourcecontext.setglobalqualifiervalue)

## <a name="related-topics"></a><span data-ttu-id="27719-243">関連トピック</span><span class="sxs-lookup"><span data-stu-id="27719-243">Related topics</span></span>

* [<span data-ttu-id="27719-244">有効ピクセルとスケール ファクター</span><span class="sxs-lookup"><span data-stu-id="27719-244">Effective pixels and scale factor</span></span>](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md#effective-pixels-and-scale-factor)
* [<span data-ttu-id="27719-245">リソース管理システム</span><span class="sxs-lookup"><span data-stu-id="27719-245">Resource Management System</span></span>](resource-management-system.md)
* [<span data-ttu-id="27719-246">ローカライズを準備する方法</span><span class="sxs-lookup"><span data-stu-id="27719-246">How to prepare for localization</span></span>](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh967762)
* [<span data-ttu-id="27719-247">を検出、プラットフォーム、アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="27719-247">Detecting the platform your app is running on</span></span>](../porting/wpsl-to-uwp-input-and-sensors.md#detecting-the-platform-your-app-is-running-on)
* [<span data-ttu-id="27719-248">デバイスのファミリの概要</span><span class="sxs-lookup"><span data-stu-id="27719-248">Device families overview</span></span>](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)
* [<span data-ttu-id="27719-249">UI 文字列をローカライズします。</span><span class="sxs-lookup"><span data-stu-id="27719-249">Localize your UI strings</span></span>](localize-strings-ui-manifest.md)
* [<span data-ttu-id="27719-250">BCP-47</span><span class="sxs-lookup"><span data-stu-id="27719-250">BCP-47</span></span>](https://go.microsoft.com/fwlink/p/?linkid=227302)
* [<span data-ttu-id="27719-251">地域コードの United Nations 統計除算 M49 コンポジション</span><span class="sxs-lookup"><span data-stu-id="27719-251">United Nations Statistic Division M49 composition of region codes</span></span>](https://go.microsoft.com/fwlink/p/?linkid=247929)
* [<span data-ttu-id="27719-252">IANA 言語サブタグ レジストリ</span><span class="sxs-lookup"><span data-stu-id="27719-252">IANA language subtag registry</span></span>](https://go.microsoft.com/fwlink/p/?linkid=227303)
* [<span data-ttu-id="27719-253">レイアウトやフォントの調整と RTL のサポート</span><span class="sxs-lookup"><span data-stu-id="27719-253">Adjust layout and fonts, and support RTL</span></span>](../design/globalizing/adjust-layout-and-fonts--and-support-rtl.md)
