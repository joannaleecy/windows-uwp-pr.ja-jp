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
keywords: "Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子"
localizationpriority: medium
ms.openlocfilehash: 2b294ec2c6b019933547b828d55e7709690bf713
ms.sourcegitcommit: d0c93d734639bd31f264424ae5b6fead903a951d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2017
---
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

# <a name="tile-and-toast-notification-support-for-language-scale-and-high-contrast"></a><span data-ttu-id="529ed-104">言語、スケール、ハイ コントラストに合わせたタイルとトースト通知のサポート</span><span class="sxs-lookup"><span data-stu-id="529ed-104">Tile and toast notification support for language, scale, and high contrast</span></span>

<span data-ttu-id="529ed-105">タイルやトーストで、表示言語、[表示倍率](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)、ハイ コントラスト、その他の実行時のコンテキストに合わせた文字列や画像を読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="529ed-105">Your tiles and toasts can load strings and images tailored for display language, [display scale factor](../layout/screen-sizes-and-breakpoints-for-responsive-design.md), high contrast, and other runtime contexts.</span></span> <span data-ttu-id="529ed-106">リソース ファイルの名前に修飾子を使用する方法の詳細については、「[言語、スケール、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」と「[アセット サイズの一覧表](../controls-and-patterns/tiles-and-notifications-app-assets.md#asset-size-tables)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="529ed-106">For background on how to use qualifiers in the names of your resource files, see [Tailor your resources for language, scale, and other qualifiers](tailor-resources-lang-scale-contrast.md) and [Asset size tables](../controls-and-patterns/tiles-and-notifications-app-assets.md#asset-size-tables).</span></span>

<span data-ttu-id="529ed-107">アプリのローカライズの価値提案の詳細については、「[グローバリゼーションとローカライズ](../globalizing/globalizing-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="529ed-107">For more info about the value proposition of localizing your app, see [Globalization and localization](../globalizing/globalizing-portal.md).</span></span>

## <a name="refer-to-a-string-resource-from-a-template"></a><span data-ttu-id="529ed-108">テンプレートから文字列リソースを参照する</span><span class="sxs-lookup"><span data-stu-id="529ed-108">Refer to a string resource from a template</span></span>

<span data-ttu-id="529ed-109">タイルまたはトースト テンプレートで、`ms-resource` という URI (Uniform Resource Identifier) スキームに単純な文字列リソース識別子を続けて指定することにより、文字列リソースを参照できます。</span><span class="sxs-lookup"><span data-stu-id="529ed-109">In your tile or toast template, you can refer to a string resource using the `ms-resource` URI (Uniform Resource Identifier) scheme followed by a simple string resource identifier.</span></span> <span data-ttu-id="529ed-110">たとえば、"Farewell" という名前のリソース エントリが含まれた Resources.resx ファイルがあれば、"Farewell" という識別子の文字列リソースがあります。</span><span class="sxs-lookup"><span data-stu-id="529ed-110">For example, if you have a Resources.resx file that contains a resource entry whose name is "Farewell", then you have a string resource with the identifier "Farewell".</span></span> <span data-ttu-id="529ed-111">文字列リソース識別子とリソース ファイル (.resw) について詳しくは、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](localize-strings-ui-manifest.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="529ed-111">For more info on string resource identifiers and Resources Files (.resw), see [Localize strings in your UI and app package manifest](localize-strings-ui-manifest.md).</span></span>

<span data-ttu-id="529ed-112">以下は、`ms-resource` を使用して "Farewell" 文字列リソース識別子への参照によってテンプレート コンテンツの[テキスト](/uwp/schemas/tiles/tilesschema/element-text?branch=live)本文を参照する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="529ed-112">This is how a reference to the "Farewell" string resource identifier would look in the [text](/uwp/schemas/tiles/tilesschema/element-text?branch=live) body of your template content, using `ms-resource`.</span></span>

```xml
<text id="1">ms-resource:Farewell</text>
```

<span data-ttu-id="529ed-113">`ms-resource` URI スキームを省略した場合、テキスト本文は単なる文字列リテラルとなり、**識別子への参照にはなりません。</span><span class="sxs-lookup"><span data-stu-id="529ed-113">If you omit the `ms-resource` URI scheme, then the text body is just a string literal, and *not* a reference to an identifier.</span></span>

```xml
<text id="1">Farewell</text>
```

## <a name="refer-to-an-image-resource-from-a-template"></a><span data-ttu-id="529ed-114">テンプレートから画像リソースを参照する</span><span class="sxs-lookup"><span data-stu-id="529ed-114">Refer to an image resource from a template</span></span>

<span data-ttu-id="529ed-115">タイルまたはトースト テンプレートで、`ms-appx` という URI (Uniform Resource Identifier) スキームに画像リソースの名前を続けて指定することにより、画像リソースを参照できます。</span><span class="sxs-lookup"><span data-stu-id="529ed-115">In your tile or toast template, you can refer to an image resource using the `ms-appx` URI (Uniform Resource Identifier) scheme followed by the name of the image resource.</span></span> <span data-ttu-id="529ed-116">これは、XAML マークアップで画像リソースを参照する場合と同じ方法です (詳しくは、「[XAML マークアップとコードから画像やその他のアセットを参照する](images-tailored-for-scale-theme-contrast.md#reference-an-image-or-other-asset-from-xaml-markup-and-code)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="529ed-116">This is the same way that you refer to an image resource in XAML markup (for more details, see [Reference an image or other asset from XAML markup and code](images-tailored-for-scale-theme-contrast.md#reference-an-image-or-other-asset-from-xaml-markup-and-code)).</span></span>

<span data-ttu-id="529ed-117">たとえば、フォルダーに次のような名前を付けたとします。</span><span class="sxs-lookup"><span data-stu-id="529ed-117">For example, you might name folders like this.</span></span>

```
\Assets\Images\contrast-standard\welcome.png
\Assets\Images\contrast-high\welcome.png
```

<span data-ttu-id="529ed-118">この場合の画像リソースは 1 つで、名前 (絶対パス) は `/Assets/Images/welcome.png` です。</span><span class="sxs-lookup"><span data-stu-id="529ed-118">In that case, you have a single image resource and its name (as an absolute path) is `/Assets/Images/welcome.png`.</span></span> <span data-ttu-id="529ed-119">この名前をテンプレートで使用する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="529ed-119">Here’s how you use that name in your template.</span></span>

```xml
<image id="1" src="ms-appx:///Assets/Images/welcome.png"/>
```

<span data-ttu-id="529ed-120">この例の URI で、スキーム ("`ms-appx`") の後に "`://`" が続き、その後に絶対パスが続くことに注意してください (絶対パスは "`/`" から始まる部分です)。</span><span class="sxs-lookup"><span data-stu-id="529ed-120">Notice how in this example URI the scheme ("`ms-appx`") is followed by "`://`" which is followed by an absolute path (an absolute path begins with "`/`").</span></span>

## <a name="hosting-and-loading-images-in-the-cloud"></a><span data-ttu-id="529ed-121">クラウド内の画像のホスティングと読み込み</span><span class="sxs-lookup"><span data-stu-id="529ed-121">Hosting and loading images in the cloud</span></span>

<span data-ttu-id="529ed-122">URI スキーム `ms-resource` および `ms-appx` が自動で修飾子の照合を実行して、現在のコンテキストに最も適切なリソースを見つけます。</span><span class="sxs-lookup"><span data-stu-id="529ed-122">The `ms-resource` and `ms-appx` URI schemes perform automatic qualifier matching to find the resource that's most appropriate for the current context.</span></span> <span data-ttu-id="529ed-123">Web URI スキーム (`http`、`https`、`ftp` など) では、このような自動的な照合が実行されません。</span><span class="sxs-lookup"><span data-stu-id="529ed-123">Web URI schemes (for example, `http`, `https`, and `ftp`) do not perform any such automatic matching.</span></span>

<span data-ttu-id="529ed-124">代わりとして、画像の URI には、要求された修飾子の 1 つ以上の値を記述したクエリ文字列を追加します。</span><span class="sxs-lookup"><span data-stu-id="529ed-124">Instead, append onto your image's URI a query string describing the requested qualifier value or values.</span></span>

```xml
<image id="1" src="http://www.contoso.com/Assets/Images/welcome.png?ms-lang=en-US"/>
```

<span data-ttu-id="529ed-125">次に、画像を提供するアプリ サービスに、どの画像を返すか決定するためのクエリ文字列を調べて使用する HTTP ハンドラーを実装します。</span><span class="sxs-lookup"><span data-stu-id="529ed-125">Then, in the app service that provides your images, implement an HTTP handler that inspects and uses the query string to determine which image to return.</span></span>

<span data-ttu-id="529ed-126">また、[タイル](/uwp/schemas/tiles/tilesschema/schema-root?branch=live)または[トースト](/uwp/schemas/tiles/toastschema/schema-root?branch=live)通知の XML ペイロードで [**addImageQuery**](/uwp/schemas/tiles/tilesschema/element-visual?branch=live) 属性を `true` に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="529ed-126">You also need to set the [**addImageQuery**](/uwp/schemas/tiles/tilesschema/element-visual?branch=live) attribute to `true` in the [tile](/uwp/schemas/tiles/tilesschema/schema-root?branch=live) or [toast](/uwp/schemas/tiles/toastschema/schema-root?branch=live) notification XML payload.</span></span> <span data-ttu-id="529ed-127">**addImageQuery** 属性は、タイルとトーストの両方のスキーマの `visual` 要素、`binding` 要素、`image` 要素にあります。</span><span class="sxs-lookup"><span data-stu-id="529ed-127">The **addImageQuery** attribute appears in the `visual`, `binding`, and `image` elements of both the tile and toast schemas.</span></span> <span data-ttu-id="529ed-128">要素に **addImageQuery** を明示的に設定すると、祖先に設定された値が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="529ed-128">Explicitly setting **addImageQuery** on an element overrides any value set on an ancestor.</span></span> <span data-ttu-id="529ed-129">たとえば、`image` 要素の **addImageQuery** の値が `true` であれば、その親の `binding` 要素の **addImageQuery** の `false` が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="529ed-129">For instance, an **addImageQuery** value of `true` in an `image` element overrides an **addImageQuery** of `false` in its parent `binding` element.</span></span>

<span data-ttu-id="529ed-130">使用できるクエリ文字列は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="529ed-130">These are the query strings you can use.</span></span>

| <span data-ttu-id="529ed-131">修飾子</span><span class="sxs-lookup"><span data-stu-id="529ed-131">Qualifier</span></span> | <span data-ttu-id="529ed-132">クエリ文字列</span><span class="sxs-lookup"><span data-stu-id="529ed-132">Query string</span></span> | <span data-ttu-id="529ed-133">例</span><span class="sxs-lookup"><span data-stu-id="529ed-133">Example</span></span> |
| --------- | ------------ | ------- |
| <span data-ttu-id="529ed-134">Scale</span><span class="sxs-lookup"><span data-stu-id="529ed-134">Scale</span></span> | <span data-ttu-id="529ed-135">ms-scale</span><span class="sxs-lookup"><span data-stu-id="529ed-135">ms-scale</span></span> | <span data-ttu-id="529ed-136">?ms-scale=400</span><span class="sxs-lookup"><span data-stu-id="529ed-136">?ms-scale=400</span></span> |
| <span data-ttu-id="529ed-137">Language</span><span class="sxs-lookup"><span data-stu-id="529ed-137">Language</span></span> | <span data-ttu-id="529ed-138">ms-lang</span><span class="sxs-lookup"><span data-stu-id="529ed-138">ms-lang</span></span> | <span data-ttu-id="529ed-139">?ms-lang=en-US</span><span class="sxs-lookup"><span data-stu-id="529ed-139">?ms-lang=en-US</span></span> |
| <span data-ttu-id="529ed-140">Contrast</span><span class="sxs-lookup"><span data-stu-id="529ed-140">Contrast</span></span> | <span data-ttu-id="529ed-141">ms-contrast</span><span class="sxs-lookup"><span data-stu-id="529ed-141">ms-contrast</span></span> | <span data-ttu-id="529ed-142">?ms-contrast=high</span><span class="sxs-lookup"><span data-stu-id="529ed-142">?ms-contrast=high</span></span> |

<span data-ttu-id="529ed-143">クエリ文字列で使用可能な修飾子の値を網羅したリファレンス テーブルについては、「[ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="529ed-143">For a reference table of all the possible qualifier values that you can use in your query strings, see [ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues).</span></span>

## <a name="related-topics"></a><span data-ttu-id="529ed-144">関連トピック</span><span class="sxs-lookup"><span data-stu-id="529ed-144">Related topics</span></span>

* [<span data-ttu-id="529ed-145">言語、スケール、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="529ed-145">Tailor your resources for language, scale, and other qualifiers</span></span>](tailor-resources-lang-scale-contrast.md)
* [<span data-ttu-id="529ed-146">タイルとアイコン アセットのガイドライン</span><span class="sxs-lookup"><span data-stu-id="529ed-146">Guidelines for tile and icon assets</span></span>](../controls-and-patterns/tiles-and-notifications-app-assets.md)
* [<span data-ttu-id="529ed-147">ResourceContext.QualifierValues</span><span class="sxs-lookup"><span data-stu-id="529ed-147">ResourceContext.QualifierValues</span></span>](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues)
* [<span data-ttu-id="529ed-148">UI とアプリ パッケージ マニフェスト内の文字列をローカライズする</span><span class="sxs-lookup"><span data-stu-id="529ed-148">Localize strings in your UI and app package manifest</span></span>](localize-strings-ui-manifest.md)
* [<span data-ttu-id="529ed-149">XAML マークアップとコードから画像やその他のアセットを参照する</span><span class="sxs-lookup"><span data-stu-id="529ed-149">Reference an image or other asset from XAML markup and code</span></span>](images-tailored-for-scale-theme-contrast.md#reference-an-image-or-other-asset-from-xaml-markup-and-code)
* [<span data-ttu-id="529ed-150">addImageQuery</span><span class="sxs-lookup"><span data-stu-id="529ed-150">addImageQuery</span></span>](/uwp/schemas/tiles/tilesschema/element-visual?branch=live)
* [<span data-ttu-id="529ed-151">タイルのスキーマ</span><span class="sxs-lookup"><span data-stu-id="529ed-151">Tile schema</span></span>](/uwp/schemas/tiles/tilesschema/schema-root?branch=live)
* [<span data-ttu-id="529ed-152">トースト スキーマ</span><span class="sxs-lookup"><span data-stu-id="529ed-152">Toast schema</span></span>](/uwp/schemas/tiles/toastschema/schema-root?branch=live)