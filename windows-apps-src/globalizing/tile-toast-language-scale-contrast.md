---
author: stevewhims
Description: "タイルやトーストで、表示言語、表示倍率、ハイ コントラスト、その他の実行時のコンテキストに合わせた文字列や画像を読み込むことができます。"
title: "言語、スケール、ハイ コントラストに合わせたタイルとトースト通知のサポート"
template: detail.hbs
ms.author: stwhi
ms.date: 10/12/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 10aa6ca83e66e413ec3f417ed8c9034342995e54
ms.sourcegitcommit: 165f57223ba69c0b7b71b295d9e0d35ea9a50a27
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2017
---
# <a name="tile-and-toast-notification-support-for-language-scale-and-high-contrast"></a><span data-ttu-id="c7b93-104">言語、スケール、ハイ コントラストに合わせたタイルとトースト通知のサポート</span><span class="sxs-lookup"><span data-stu-id="c7b93-104">Tile and toast notification support for language, scale, and high contrast</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="c7b93-105">タイルやトーストで、表示言語、[表示倍率](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)、ハイ コントラスト、その他の実行時のコンテキストに合わせた文字列や画像を読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="c7b93-105">Your tiles and toasts can load strings and images tailored for display language, [display scale factor](../layout/screen-sizes-and-breakpoints-for-responsive-design.md), high contrast, and other runtime contexts.</span></span> <span data-ttu-id="c7b93-106">リソース ファイルの名前に修飾子を使用する方法の詳細については、「[言語、スケール、その他の修飾子用にリソースを調整する](how-to-name-resources-by-using-qualifiers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7b93-106">For background on how to use qualifiers in the names of your resource files, see [Tailor your resources for language, scale, and other qualifiers](how-to-name-resources-by-using-qualifiers.md).</span></span>

## <a name="refer-to-a-string-resource-from-a-template"></a><span data-ttu-id="c7b93-107">テンプレートから文字列リソースを参照する</span><span class="sxs-lookup"><span data-stu-id="c7b93-107">Refer to a string resource from a template</span></span>

<span data-ttu-id="c7b93-108">タイルまたはトースト テンプレートで、`ms-resource` という URI (Uniform Resource Identifier) スキームに単純な文字列リソース識別子を続けて指定することにより、文字列リソースを参照できます。</span><span class="sxs-lookup"><span data-stu-id="c7b93-108">In your tile or toast template, you can refer to a string resource using the `ms-resource` URI (Uniform Resource Identifier) scheme followed by a simple string resource identifier.</span></span> <span data-ttu-id="c7b93-109">たとえば、"Farewell" という名前のリソース エントリが含まれた Resources.resx ファイルがあれば、"Farewell" という識別子の文字列リソースがあります。</span><span class="sxs-lookup"><span data-stu-id="c7b93-109">For example, if you have a Resources.resx file that contains a resource entry whose name is "Farewell", then you have a string resource with the identifier "Farewell".</span></span> <span data-ttu-id="c7b93-110">文字列リソース識別子とリソース ファイル (.resw) について詳しくは、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](put-ui-strings-into-resources.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7b93-110">For more info on string resource identifiers and Resources Files (.resw), see [Localize strings in your UI and app package manifest](put-ui-strings-into-resources.md).</span></span>

<span data-ttu-id="c7b93-111">以下は、`ms-resource` を使用して "Farewell" 文字列リソース識別子への参照によってテンプレート コンテンツの[テキスト](/uwp/schemas/tiles/tilesschema/element-text?branch=live)本文を参照する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c7b93-111">This is how a reference to the "Farewell" string resource identifier would look in the [text](/uwp/schemas/tiles/tilesschema/element-text?branch=live) body of your template content, using `ms-resource`.</span></span>

```xml
<text id="1">ms-resource:Farewell</text>
```

<span data-ttu-id="c7b93-112">`ms-resource` URI スキームを省略した場合、テキスト本文は単なる文字列リテラルとなり、**識別子への参照にはなりません。</span><span class="sxs-lookup"><span data-stu-id="c7b93-112">If you omit the `ms-resource` URI scheme, then the text body is just a string literal, and *not* a reference to an identifier.</span></span>

```xml
<text id="1">Farewell</text>
```

## <a name="refer-to-an-image-resource-from-a-template"></a><span data-ttu-id="c7b93-113">テンプレートから画像リソースを参照する</span><span class="sxs-lookup"><span data-stu-id="c7b93-113">Refer to an image resource from a template</span></span>

<span data-ttu-id="c7b93-114">タイルまたはトースト テンプレートで、`ms-appx` という URI (Uniform Resource Identifier) スキームに画像リソースの名前を続けて指定することにより、画像リソースを参照できます。</span><span class="sxs-lookup"><span data-stu-id="c7b93-114">In your tile or toast template, you can refer to an image resource using the `ms-appx` URI (Uniform Resource Identifier) scheme followed by the name of the image resource.</span></span> <span data-ttu-id="c7b93-115">これは、XAML マークアップで画像リソースを参照する場合と同じ方法です (詳しくは、「[XAML マークアップとコードから画像リソースを参照する](image-qualifiers-loc-scale-accessibility.md#reference-an-image-resource-in-xaml-markup-and-code)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="c7b93-115">This is the same way that you refer to an image resource in XAML markup (for more details, see [Reference an image resource in XAML markup and code](image-qualifiers-loc-scale-accessibility.md#reference-an-image-resource-in-xaml-markup-and-code)).</span></span>

<span data-ttu-id="c7b93-116">たとえば、フォルダーに次のような名前を付けたとします。</span><span class="sxs-lookup"><span data-stu-id="c7b93-116">For example, you might name folders like this.</span></span>

```
\Assets\Images\contrast-standard\welcome.png
\Assets\Images\contrast-high\welcome.png
```

<span data-ttu-id="c7b93-117">この場合の画像リソースは 1 つで、名前 (絶対パス) は `/Assets/Images/welcome.png` です。</span><span class="sxs-lookup"><span data-stu-id="c7b93-117">In that case, you have a single image resource and its name (as an absolute path) is `/Assets/Images/welcome.png`.</span></span> <span data-ttu-id="c7b93-118">この名前をテンプレートで使用する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c7b93-118">Here’s how you use that name in your template.</span></span>

```xml
<image id="1" src="ms-appx:///Assets/Images/welcome.png"/>
```

<span data-ttu-id="c7b93-119">この例の URI で、スキーム ("`ms-appx`") の後に "`://`" が続き、その後に絶対パスが続くことに注意してください (絶対パスは "`/`" から始まる部分です)。</span><span class="sxs-lookup"><span data-stu-id="c7b93-119">Notice how in this example URI the scheme ("`ms-appx`") is followed by "`://`" which is followed by an absolute path (an absolute path begins with "`/`").</span></span>

## <a name="hosting-and-loading-images-in-the-cloud"></a><span data-ttu-id="c7b93-120">クラウド内の画像のホスティングと読み込み</span><span class="sxs-lookup"><span data-stu-id="c7b93-120">Hosting and loading images in the cloud</span></span>

<span data-ttu-id="c7b93-121">URI スキーム `ms-resource` および `ms-appx` が自動で修飾子の照合を実行して、現在のコンテキストに最も適切なリソースを見つけます。</span><span class="sxs-lookup"><span data-stu-id="c7b93-121">The `ms-resource` and `ms-appx` URI schemes perform automatic qualifier matching to find the resource that's most appropriate for the current context.</span></span> <span data-ttu-id="c7b93-122">Web URI スキーム (`http`、`https`、`ftp` など) では、このような自動的な照合が実行されません。</span><span class="sxs-lookup"><span data-stu-id="c7b93-122">Web URI schemes (for example, `http`, `https`, and `ftp`) do not perform any such automatic matching.</span></span>

<span data-ttu-id="c7b93-123">代わりとして、画像の URI には、要求された修飾子の 1 つ以上の値を記述したクエリ文字列を追加します。</span><span class="sxs-lookup"><span data-stu-id="c7b93-123">Instead, append onto your image's URI a query string describing the requested qualifier value or values.</span></span>

```xml
<image id="1" src="http://www.contoso.com/Assets/Images/welcome.png?ms-lang=en-US"/>
```

<span data-ttu-id="c7b93-124">次に、画像を提供するアプリ サービスに、どの画像を返すか決定するためのクエリ文字列を調べて使用する HTTP ハンドラーを実装します。</span><span class="sxs-lookup"><span data-stu-id="c7b93-124">Then, in the app service that provides your images, implement an HTTP handler that inspects and uses the query string to determine which image to return.</span></span>

<span data-ttu-id="c7b93-125">また、[タイル](/uwp/schemas/tiles/tilesschema/schema-root?branch=live)または[トースト](/uwp/schemas/tiles/toastschema/schema-root?branch=live)通知の XML ペイロードで [**addImageQuery**](/uwp/schemas/tiles/tilesschema/element-visual?branch=live) 属性を `true` に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7b93-125">You also need to set the [**addImageQuery**](/uwp/schemas/tiles/tilesschema/element-visual?branch=live) attribute to `true` in the [tile](/uwp/schemas/tiles/tilesschema/schema-root?branch=live) or [toast](/uwp/schemas/tiles/toastschema/schema-root?branch=live) notification XML payload.</span></span> <span data-ttu-id="c7b93-126">**addImageQuery** 属性は、タイルとトーストの両方のスキーマの `visual` 要素、`binding` 要素、`image` 要素にあります。</span><span class="sxs-lookup"><span data-stu-id="c7b93-126">The **addImageQuery** attribute appears in the `visual`, `binding`, and `image` elements of both the tile and toast schemas.</span></span> <span data-ttu-id="c7b93-127">要素に **addImageQuery** を明示的に設定すると、祖先に設定された値が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="c7b93-127">Explicitly setting **addImageQuery** on an element overrides any value set on an ancestor.</span></span> <span data-ttu-id="c7b93-128">たとえば、`image` 要素の **addImageQuery** の値が `true` であれば、その親の `binding` 要素の **addImageQuery** の `false` が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="c7b93-128">For instance, an **addImageQuery** value of `true` in an `image` element overrides an **addImageQuery** of `false` in its parent `binding` element.</span></span>

<span data-ttu-id="c7b93-129">使用できるクエリ文字列は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c7b93-129">These are the query strings you can use.</span></span>

| <span data-ttu-id="c7b93-130">修飾子</span><span class="sxs-lookup"><span data-stu-id="c7b93-130">Qualifier</span></span> | <span data-ttu-id="c7b93-131">クエリ文字列</span><span class="sxs-lookup"><span data-stu-id="c7b93-131">Query string</span></span> | <span data-ttu-id="c7b93-132">例</span><span class="sxs-lookup"><span data-stu-id="c7b93-132">Example</span></span> |
| --------- | ------------ | ------- |
| <span data-ttu-id="c7b93-133">Scale</span><span class="sxs-lookup"><span data-stu-id="c7b93-133">Scale</span></span> | <span data-ttu-id="c7b93-134">ms-scale</span><span class="sxs-lookup"><span data-stu-id="c7b93-134">ms-scale</span></span> | <span data-ttu-id="c7b93-135">?ms-scale=400</span><span class="sxs-lookup"><span data-stu-id="c7b93-135">?ms-scale=400</span></span> |
| <span data-ttu-id="c7b93-136">Language</span><span class="sxs-lookup"><span data-stu-id="c7b93-136">Language</span></span> | <span data-ttu-id="c7b93-137">ms-lang</span><span class="sxs-lookup"><span data-stu-id="c7b93-137">ms-lang</span></span> | <span data-ttu-id="c7b93-138">?ms-lang=en-US</span><span class="sxs-lookup"><span data-stu-id="c7b93-138">?ms-lang=en-US</span></span> |
| <span data-ttu-id="c7b93-139">Contrast</span><span class="sxs-lookup"><span data-stu-id="c7b93-139">Contrast</span></span> | <span data-ttu-id="c7b93-140">ms-contrast</span><span class="sxs-lookup"><span data-stu-id="c7b93-140">ms-contrast</span></span> | <span data-ttu-id="c7b93-141">?ms-contrast=high</span><span class="sxs-lookup"><span data-stu-id="c7b93-141">?ms-contrast=high</span></span> |

<span data-ttu-id="c7b93-142">クエリ文字列で使用可能な修飾子の値を網羅したリファレンス テーブルについては、「[ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c7b93-142">For a reference table of all the possible qualifier values that you can use in your query strings, see [ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues).</span></span>

## <a name="related-topics"></a><span data-ttu-id="c7b93-143">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c7b93-143">Related topics</span></span>

* [<span data-ttu-id="c7b93-144">言語、スケール、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="c7b93-144">Tailor your resources for language, scale, and other qualifiers</span></span>](how-to-name-resources-by-using-qualifiers.md)
* [<span data-ttu-id="c7b93-145">ResourceContext.QualifierValues</span><span class="sxs-lookup"><span data-stu-id="c7b93-145">ResourceContext.QualifierValues</span></span>](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues)
* [<span data-ttu-id="c7b93-146">UI とアプリ パッケージ マニフェスト内の文字列をローカライズする</span><span class="sxs-lookup"><span data-stu-id="c7b93-146">Localize strings in your UI and app package manifest</span></span>](put-ui-strings-into-resources.md)
* [<span data-ttu-id="c7b93-147">XAML マークアップとコードから画像リソースを参照する</span><span class="sxs-lookup"><span data-stu-id="c7b93-147">Reference an image resource in XAML markup and code</span></span>](image-qualifiers-loc-scale-accessibility.md#reference-an-image-resource-in-xaml-markup-and-code)
* [<span data-ttu-id="c7b93-148">addImageQuery</span><span class="sxs-lookup"><span data-stu-id="c7b93-148">addImageQuery</span></span>](/uwp/schemas/tiles/tilesschema/element-visual?branch=live)
* [<span data-ttu-id="c7b93-149">タイルのスキーマ</span><span class="sxs-lookup"><span data-stu-id="c7b93-149">Tile schema</span></span>](/uwp/schemas/tiles/tilesschema/schema-root?branch=live)
* [<span data-ttu-id="c7b93-150">トースト スキーマ</span><span class="sxs-lookup"><span data-stu-id="c7b93-150">Toast schema</span></span>](/uwp/schemas/tiles/toastschema/schema-root?branch=live)