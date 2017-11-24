---
author: stevewhims
Description: "アプリで、表示倍率、テーマ、ハイ コントラスト、その他の実行時のコンテキストに合わせた画像を含む画像リソース ファイルを読み込むことができます。"
title: "表示倍率、テーマ、ハイ コントラスト、その他の設定に合わせた画像とアセットの読み込み"
template: detail.hbs
ms.author: stwhi
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 9387473bc829f3d2eaa12e5be25752d4b0091708
ms.sourcegitcommit: 27f7829f6d86ad8e13de3d13bff72825c1dbab7f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/18/2017
---
# <a name="load-images-and-assets-tailored-for-scale-theme-high-contrast-and-others"></a><span data-ttu-id="d9337-104">表示倍率、テーマ、ハイ コントラスト、その他の設定に合わせた画像とアセットの読み込み</span><span class="sxs-lookup"><span data-stu-id="d9337-104">Load images and assets tailored for scale, theme, high contrast, and others</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="d9337-105">アプリで、[表示倍率](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)、テーマ、ハイ コントラスト、その他の実行時のコンテキストに合わせた画像リソース ファイル (またはその他のアセット ファイル) を読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d9337-105">Your app can load image resource files (or other asset files) tailored for [display scale factor](../layout/screen-sizes-and-breakpoints-for-responsive-design.md), theme, high contrast, and other runtime contexts.</span></span> <span data-ttu-id="d9337-106">これらの画像は、命令型コードや XAML マークアップ (**Image** の **Source** プロパティなど) から参照できます。</span><span class="sxs-lookup"><span data-stu-id="d9337-106">These images can be referenced from imperative code or from XAML markup, for example as the **Source** property of an **Image**.</span></span> <span data-ttu-id="d9337-107">また、アプリ パッケージ マニフェスト (`Package.appxmanifest` ファイル) に (たとえば、Visual Studio マニフェスト デザイナーの [ビジュアル資産] タブでアプリ アイコンの値として) 表示することや、タイルやトースト通知に表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="d9337-107">They can also appear in your app package manifest (the `Package.appxmanifest` file)&mdash;for example, as the value for App Icon on the Visual Assets tab of the Visual Studio Manifest Designer&mdash;or on your tiles and toasts.</span></span> <span data-ttu-id="d9337-108">画像のファイル名に修飾子を使用し、必要に応じて [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live) を使って動的に読み込むことによって、ユーザーの実行時の表示倍率、テーマ、ハイ コントラスト、言語、その他のコンテキストの設定に最も一致する最適な画像ファイルを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d9337-108">By using qualifiers in your images' file names, and optionally dynamically loading them with the help of a [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live), you can cause the most appropriate image file to be loaded that best matches the user's runtime settings for display scale, theme, high contrast, language, and other contexts.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="d9337-109">重要な API</span><span class="sxs-lookup"><span data-stu-id="d9337-109">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="d9337-110">ResourceContext</span><span class="sxs-lookup"><span data-stu-id="d9337-110">ResourceContext</span></span>**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live)</li>
<li>[**<span data-ttu-id="d9337-111">MapChanged</span><span class="sxs-lookup"><span data-stu-id="d9337-111">MapChanged</span></span>**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_?branch=live#Windows_Foundation_Collections_IObservableMap_2_MapChanged)</li></ul>
</div>

<span data-ttu-id="d9337-112">画像リソースは、画像リソース ファイルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="d9337-112">An image resource is contained in an image resource file.</span></span> <span data-ttu-id="d9337-113">画像はアセット、画像を含むファイルはアセット ファイルと考えることができ、これらの種類のリソース ファイルはプロジェクトの \Assets フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="d9337-113">You can also think of the image as an asset, and the file that contains it as an asset file; and you can find these kinds of resource files in your project's \Assets folder.</span></span> <span data-ttu-id="d9337-114">画像リソース ファイルの名前に修飾子を使用する方法の詳細については、「[言語、スケール、その他の修飾子用にリソースを調整する](how-to-name-resources-by-using-qualifiers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9337-114">For background on how to use qualifiers in the names of your image resource files, see [Tailor your resources for language, scale, and other qualifiers](how-to-name-resources-by-using-qualifiers.md).</span></span>

<span data-ttu-id="d9337-115">画像の一般的な修飾子には、[scale](how-to-name-resources-by-using-qualifiers.md#scale)、[theme](how-to-name-resources-by-using-qualifiers.md#theme)、[contrast](how-to-name-resources-by-using-qualifiers.md#contrast)、[targetsize](how-to-name-resources-by-using-qualifiers.md#targetsize) があります。</span><span class="sxs-lookup"><span data-stu-id="d9337-115">Some common qualifiers for images are [scale](how-to-name-resources-by-using-qualifiers.md#scale), [theme](how-to-name-resources-by-using-qualifiers.md#theme), [contrast](how-to-name-resources-by-using-qualifiers.md#contrast), and [targetsize](how-to-name-resources-by-using-qualifiers.md#targetsize).</span></span>

## <a name="qualify-an-image-resource-for-scale-theme-and-contrast"></a><span data-ttu-id="d9337-116">スケール、テーマ、コントラストに合わせて画像リソースを修飾する</span><span class="sxs-lookup"><span data-stu-id="d9337-116">Qualify an image resource for scale, theme, and contrast</span></span>

<span data-ttu-id="d9337-117">`scale` 修飾子の既定値は `scale-100` です。</span><span class="sxs-lookup"><span data-stu-id="d9337-117">The default value for the `scale` qualifier is `scale-100`.</span></span> <span data-ttu-id="d9337-118">そのため、次の 2 つのバリエーションは同等です (いずれもスケール 100、つまり倍率 1 の画像を提供します)。</span><span class="sxs-lookup"><span data-stu-id="d9337-118">So, these two variants are equivalent (they both provide an image at scale 100, or scale factor 1).</span></span>

```
\Assets\Images\logo.png
\Assets\Images\logo.scale-100.png
```

<span data-ttu-id="d9337-119">修飾子は、ファイル名の代わりにフォルダー名に使用できます。</span><span class="sxs-lookup"><span data-stu-id="d9337-119">You can use qualifiers in folder names instead of file names.</span></span> <span data-ttu-id="d9337-120">修飾子ごとにいくつかのアセット ファイルがある場合、この方法が適しています。</span><span class="sxs-lookup"><span data-stu-id="d9337-120">That would be a better strategy if you have several asset files per qualifier.</span></span> <span data-ttu-id="d9337-121">わかりやすい例として、次の 2 つのバリエーションは上記の 2 つと同等です。</span><span class="sxs-lookup"><span data-stu-id="d9337-121">For purposes of illustration, these two variants are equivalent to the two above.</span></span>

```
\Assets\Images\logo.png
\Assets\Images\scale-100\logo.png
```

<span data-ttu-id="d9337-122">次の例では、表示倍率、テーマ、ハイ コントラストのさまざまな設定に合わせて、`/Assets/Images/logo.png` という名前の画像リソースのバリエーションを提供する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d9337-122">Next is an example of how you can provide variants of an image resource&mdash;named `/Assets/Images/logo.png`&mdash;for different settings of display scale, theme, and high contrast.</span></span> <span data-ttu-id="d9337-123">この例では、フォルダー名を使用しています。</span><span class="sxs-lookup"><span data-stu-id="d9337-123">This example uses folder naming.</span></span>

```
\Assets\Images\contrast-standard\theme-dark
    \scale-100\logo.png
    \scale-200\logo.png
\Assets\Images\contrast-standard\theme-light
    \scale-100\logo.png
    \scale-200\logo.png
\Assets\Images\contrast-high
    \scale-100\logo.png
    \scale-200\logo.png
```

## <a name="reference-an-image-or-other-asset-from-xaml-markup-and-code"></a><span data-ttu-id="d9337-124">XAML マークアップとコードから画像やその他のアセットを参照する</span><span class="sxs-lookup"><span data-stu-id="d9337-124">Reference an image or other asset from XAML markup and code</span></span>

<span data-ttu-id="d9337-125">画像リソースの名前 (つまり識別子) は、そのパスとファイル名からすべての修飾子を削除したものです。</span><span class="sxs-lookup"><span data-stu-id="d9337-125">The name&mdash;or identifier&mdash;of an image resource is its path and file name with any and all qualifiers removed.</span></span> <span data-ttu-id="d9337-126">前のセクションの例のようにフォルダーやファイルに名前を付けている場合、画像リソースは 1 つであり、その (絶対パスとしての) 名前は `/Assets/Images/logo.png` です。</span><span class="sxs-lookup"><span data-stu-id="d9337-126">If you name folders and/or files as in any of the examples in the previous section, then you have a single image resource and its name (as an absolute path) is `/Assets/Images/logo.png`.</span></span> <span data-ttu-id="d9337-127">この名前を XAML マークアップで使用する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="d9337-127">Here’s how you use that name in XAML markup.</span></span>

**<span data-ttu-id="d9337-128">XAML</span><span class="sxs-lookup"><span data-stu-id="d9337-128">XAML</span></span>**
```xml
<Image x:Name="myXAMLImageElement" Source="ms-appx:///Assets/Images/logo.png"/>
```

<span data-ttu-id="d9337-129">アプリのパッケージに付属しているファイルを参照するため、`ms-appx` URI スキームを使用していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d9337-129">Notice that you use the `ms-appx` URI scheme because you're referring to a file that comes from your app's package.</span></span> <span data-ttu-id="d9337-130">「[URI スキーム](uri-schemes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9337-130">See [URI schemes](uri-schemes.md).</span></span> <span data-ttu-id="d9337-131">同じ画像リソースを命令型コード内で参照する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="d9337-131">And here’s how you refer to the same image resource in imperative code.</span></span>

**<span data-ttu-id="d9337-132">C#</span><span class="sxs-lookup"><span data-stu-id="d9337-132">C#</span></span>**
```csharp
this.myXAMLImageElement.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/logo.png"));
```

<span data-ttu-id="d9337-133">`ms-appx` を使用して、アプリ パッケージから任意のファイルを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d9337-133">You can use `ms-appx` to load any arbitrary file from your app package.</span></span>

**<span data-ttu-id="d9337-134">C#</span><span class="sxs-lookup"><span data-stu-id="d9337-134">C#</span></span>**
```csharp
var uri = new System.Uri("ms-appx:///Assets/anyAsset.ext");
var storagefile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
```

<span data-ttu-id="d9337-135">`ms-appx-web` スキームは、`ms-appx` と同じファイルにアクセスしますが、このファイルは Web コンパートメントにあります。</span><span class="sxs-lookup"><span data-stu-id="d9337-135">The `ms-appx-web` scheme accesses the same files as `ms-appx`, but in the web compartment.</span></span>

**<span data-ttu-id="d9337-136">XAML</span><span class="sxs-lookup"><span data-stu-id="d9337-136">XAML</span></span>**
```xml
<WebView x:Name="myXAMLWebViewElement" Source="ms-appx-web:///Pages/default.html"/>
```

**<span data-ttu-id="d9337-137">C#</span><span class="sxs-lookup"><span data-stu-id="d9337-137">C#</span></span>**
```csharp
this.myXAMLWebViewElement.Source = new Uri("ms-appx-web:///Pages/default.html");
```

<span data-ttu-id="d9337-138">これらの例に示されているどのシナリオの場合も、[UriKind](https://docs.microsoft.com/en-us/dotnet/api/system.urikind) を推測する [Uri コンストラクター](https://docs.microsoft.com/en-us/dotnet/api/system.uri.-ctor?view=netcore-2.0#System_Uri__ctor_System_String_)のオーバーロードを使用します。</span><span class="sxs-lookup"><span data-stu-id="d9337-138">For any of the scenarios shown in these examples, use the [Uri constructor](https://docs.microsoft.com/en-us/dotnet/api/system.uri.-ctor?view=netcore-2.0#System_Uri__ctor_System_String_) overload that infers the [UriKind](https://docs.microsoft.com/en-us/dotnet/api/system.urikind).</span></span> <span data-ttu-id="d9337-139">スキームと機関を含む有効な絶対 URI を指定するか、上記の例のように、機関の既定をアプリのパッケージに自動的に設定します。</span><span class="sxs-lookup"><span data-stu-id="d9337-139">Specify a valid absolute URI including the scheme and authority, or just let the authority default to the app's package as in the example above.</span></span>

<span data-ttu-id="d9337-140">これらの URI の例で、スキーム ("`ms-appx`" または "`ms-appx-web`") の後に "`://`" が続き、その後に絶対パスが続くことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d9337-140">Notice how in these example URIs the scheme ("`ms-appx`" or "`ms-appx-web`") is followed by "`://`" which is followed by an absolute path.</span></span> <span data-ttu-id="d9337-141">絶対パスでは、先頭の "`/`" によって、パスはパッケージのルートからのパスとして解釈されます。</span><span class="sxs-lookup"><span data-stu-id="d9337-141">In an absolute path, the leading "`/`" causes the path to be interpreted from the root of the package.</span></span>

<span data-ttu-id="d9337-142">**メモ:** `ms-resource` ([文字列リソース](put-ui-strings-into-resources.md)の場合) および `ms-appx(-web)` (画像やその他のアセットの場合) URI スキームは、自動で修飾子の照合を実行して、現在のコンテキストに最も適切なリソースを見つけます。</span><span class="sxs-lookup"><span data-stu-id="d9337-142">**Note** The `ms-resource` (for [string resources](put-ui-strings-into-resources.md)) and `ms-appx(-web)` (for images and other assets) URI schemes perform automatic qualifier matching to find the resource that's most appropriate for the current context.</span></span> <span data-ttu-id="d9337-143">`ms-appdata` URI スキーム (アプリ データを読み込むために使用される) は、このような自動的な照合を実行しませんが、[ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) の内容に応答し、URI の完全な物理ファイル名を使用して、アプリ データから適切なアセットを明示的に読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d9337-143">The `ms-appdata` URI scheme (which is used to load app data) does not perform any such automatic matching, but you can respond to the contents of [ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) and explicitly load the appropriate assets from app data using their full physical file name in the URI.</span></span> <span data-ttu-id="d9337-144">アプリ データについては、「[設定と他のアプリ データを保存して取得する](../app-settings/store-and-retrieve-app-data)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9337-144">For info about app data, see [Store and retrieve settings and other app data](../app-settings/store-and-retrieve-app-data).</span></span> <span data-ttu-id="d9337-145">Web URI スキーム (`http`、`https`、`ftp` など) も、自動的な照合を実行しません。</span><span class="sxs-lookup"><span data-stu-id="d9337-145">Web URI schemes (for example, `http`, `https`, and `ftp`) do not perform automatic matching, either.</span></span> <span data-ttu-id="d9337-146">その場合の対処方法については、「[クラウドでの画像のホスティングと読み込み](tile-toast-language-scale-contrast.md#hosting-and-loading-images-in-the-cloud)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9337-146">For info about what to do in that case, see [Hosting and loading images in the cloud](tile-toast-language-scale-contrast.md#hosting-and-loading-images-in-the-cloud).</span></span>

<span data-ttu-id="d9337-147">絶対パスは、画像ファイルがプロジェクト構造内で元の場所に残る場合に適切な選択肢です。</span><span class="sxs-lookup"><span data-stu-id="d9337-147">Absolute paths are a good choice if your image files remain where they are in the project structure.</span></span> <span data-ttu-id="d9337-148">画像ファイルを移動できるようにする必要があるが、参照している XAML マークアップ ファイルから相対的に同じ場所に残るように注意している場合は、絶対パスの代わりに、ファイルを格納するマークアップ ファイルからの相対パスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="d9337-148">If you want to be able to move an image file, but you're careful that it remains in the same location relative to its referencing XAML markup file, then instead of an absolute path you might want to use a path that's relative to the containing markup file.</span></span> <span data-ttu-id="d9337-149">その場合、URI スキームを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d9337-149">If you do that, then you needn't use a URI scheme.</span></span> <span data-ttu-id="d9337-150">この場合も、自動的な修飾子の照合のメリットはありますが、それは XAML マークアップで相対パスを使用していることにのみ起因します。</span><span class="sxs-lookup"><span data-stu-id="d9337-150">You will still benefit from automatic qualifier matching in this case, but only because you are using the relative path in XAML markup.</span></span>

**<span data-ttu-id="d9337-151">XAML</span><span class="sxs-lookup"><span data-stu-id="d9337-151">XAML</span></span>**
```xml
<Image Source="Assets/Images/logo.png"/>
```

<span data-ttu-id="d9337-152">「[言語、スケール、ハイ コントラストに合わせたタイルとトーストのサポート](tile-toast-language-scale-contrast.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9337-152">Also see [Tile and toast support for language, scale, and high contrast](tile-toast-language-scale-contrast.md).</span></span>

## <a name="qualify-an-image-resource-for-targetsize"></a><span data-ttu-id="d9337-153">ターゲット サイズに合わせて画像リソースを修飾する</span><span class="sxs-lookup"><span data-stu-id="d9337-153">Qualify an image resource for targetsize</span></span>

<span data-ttu-id="d9337-154">同じ画像リソースの異なるバリエーションでは `scale` 修飾子と `targetsize` 修飾子を別々に使用できますが、リソースの 1 つのバリエーションでその両方を使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="d9337-154">You can use the `scale` and `targetsize` qualifiers on different variants of the same image resource; but you can't use them both on a single variant of a resource.</span></span> <span data-ttu-id="d9337-155">また、`TargetSize` 修飾子を持たないバリエーションを少なくとも 1 つ定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9337-155">Also, you need to define at least one variant without a `TargetSize` qualifier.</span></span> <span data-ttu-id="d9337-156">そのバリエーションでは、`scale` の値を定義するか、その既定値を `scale-100` にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9337-156">That variant must either define a value for `scale`, or let it default to `scale-100`.</span></span> <span data-ttu-id="d9337-157">したがって、`/Assets/Square44x44Logo.png` リソースのこれら 2 つのバリエーションは有効です。</span><span class="sxs-lookup"><span data-stu-id="d9337-157">So, these two variants of the `/Assets/Square44x44Logo.png` resource are valid.</span></span>

```
\Assets\Square44x44Logo.scale-200.png
\Assets\Square44x44Logo.targetsize-24.png
```

<span data-ttu-id="d9337-158">また、次の 2 つのバリエーションは有効です。</span><span class="sxs-lookup"><span data-stu-id="d9337-158">And these two variants are valid.</span></span> 

```
\Assets\Square44x44Logo.png // defaults to scale-100
\Assets\Square44x44Logo.targetsize-24.png
```

<span data-ttu-id="d9337-159">ただし、次のバリエーションは有効ではありません。 </span><span class="sxs-lookup"><span data-stu-id="d9337-159">But this variant is not valid.</span></span>

```
\Assets\Square44x44Logo.scale-200_targetsize-24.png
```

## <a name="refer-to-an-image-file-from-your-app-package-manifest"></a><span data-ttu-id="d9337-160">アプリ パッケージ マニフェストから画像ファイルを参照する</span><span class="sxs-lookup"><span data-stu-id="d9337-160">Refer to an image file from your app package manifest</span></span>

<span data-ttu-id="d9337-161">前のセクションの 2 つの有効な例のいずれかのように、フォルダーやファイルに名前を付けている場合、アプリ アイコンの画像リソースは 1 つであり、その (相対パスとしての) 名前は `Assets\Square44x44Logo.png` です。</span><span class="sxs-lookup"><span data-stu-id="d9337-161">If you name folders and/or files as in either of the two valid examples in the previous section, then you have a single app icon image resource and its name (as a relative path) is `Assets\Square44x44Logo.png`.</span></span> <span data-ttu-id="d9337-162">アプリ パッケージ マニフェストでは、単に名前でリソースを参照します。</span><span class="sxs-lookup"><span data-stu-id="d9337-162">In your app package manifest, simply refer to the resource by name.</span></span> <span data-ttu-id="d9337-163">URI スキームを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d9337-163">There's no need to use any URI scheme.</span></span>

![リソースの追加 (英語)](images/app-icon.png)

<span data-ttu-id="d9337-165">必要な処理はこれだけです。OS が自動で修飾子の照合を実行して、現在のコンテキストに最も適切なリソースを見つけます。</span><span class="sxs-lookup"><span data-stu-id="d9337-165">That's all you need to do, and the OS will perform automatic qualifier matching to find the resource that's most appropriate for the current context.</span></span> <span data-ttu-id="d9337-166">アプリ パッケージ マニフェスト内で、このようにローカライズまたはその他の方法で修飾できるすべての項目の一覧については、「[マニフェストのローカライズ可能な項目](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9337-166">For a list of all items in the app package manifest that you can localize or otherwise qualify in this way, see [Localizable manifest items](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live).</span></span>

## <a name="qualify-an-image-resource-for-layoutdirection"></a><span data-ttu-id="d9337-167">レイアウト方向に合わせて画像リソースを修飾する</span><span class="sxs-lookup"><span data-stu-id="d9337-167">Qualify an image resource for layoutdirection</span></span>

<span data-ttu-id="d9337-168">「[画像の左右反転](adjust-layout-and-fonts--and-support-rtl#mirroring-images)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d9337-168">See [Mirroring images](adjust-layout-and-fonts--and-support-rtl#mirroring-images).</span></span>

## <a name="load-an-image-for-a-specific-language-or-other-context"></a><span data-ttu-id="d9337-169">特定の言語または他のコンテキスト用の画像を読み込む</span><span class="sxs-lookup"><span data-stu-id="d9337-169">Load an image for a specific language or other context</span></span>

<span data-ttu-id="d9337-170">既定の [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live) ([**ResourceContext.GetForCurrentView**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_GetForCurrentView) から取得された) には、既定の実行時コンテキスト (つまり、現在のユーザーとコンピューターの設定) を表す、各修飾子名の修飾子の値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d9337-170">The default [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live) (obtained from [**ResourceContext.GetForCurrentView**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_GetForCurrentView)) contains a qualifier value for each qualifier name, representing the default runtime context (in other words, the settings for the current user and machine).</span></span> <span data-ttu-id="d9337-171">画像ファイルは、(その名前に含まれる修飾子に基づいて) 実行時コンテキストでの修飾子の値と比較されます。</span><span class="sxs-lookup"><span data-stu-id="d9337-171">Image files are matched&mdash;based on the qualifiers in their names&mdash;against the qualifier values in that runtime context.</span></span>

<span data-ttu-id="d9337-172">ただし、アプリでシステム設定を上書きし、読み込む画像を検索するときに使用する言語、スケール、その他の修飾子の値を明示的に指定することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="d9337-172">But there might be times when you want your app to override the system settings and be explicit about the language, scale, or other qualifier value to use when looking for a matching image to load.</span></span> <span data-ttu-id="d9337-173">たとえば、いつ、どのハイ コントラスト画像を読み込むかを正確に制御することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="d9337-173">For example, you might want to control exactly when and which high contrast images are loaded.</span></span>

<span data-ttu-id="d9337-174">そのためには、(既定のものを使用する代わりに) 新しい **ResourceContext** を作成し、その値をオーバーライドして、画像検索でそのコンテキスト オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="d9337-174">You can do that by constructing a new **ResourceContext** (instead of using the default one), overriding its values, and then using that context object in your image lookups.</span></span>

**<span data-ttu-id="d9337-175">C#</span><span class="sxs-lookup"><span data-stu-id="d9337-175">C#</span></span>**
```csharp
var resourceContext = new Windows.ApplicationModel.Resources.Core.ResourceContext(); // not using ResourceContext.GetForCurrentView 
resourceContext.QualifierValues["Contrast"] = "high";
var namedResource = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap[@"Files/Assets/Logo.png"];
var resourceCandidate = namedResource.Resolve(resourceContext);
var imageFileStream = resourceCandidate.GetValueAsStreamAsync().GetResults();
var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
bitmapImage.SetSourceAsync(imageFileStream);
this.myXAMLImageElement.Source = bitmapImage;
```

<span data-ttu-id="d9337-176">グローバル レベルで同じ効果を実現するために、既定の **ResourceContext** で修飾子の値を上書きすることが*できます*。</span><span class="sxs-lookup"><span data-stu-id="d9337-176">For the same effect at a global level, you *can* override the qualifier values in the default **ResourceContext**.</span></span> <span data-ttu-id="d9337-177">ただし、その代わりに、[**ResourceContext.SetGlobalQualifierValue**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_) を呼び出すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d9337-177">But instead we advise you to call [**ResourceContext.SetGlobalQualifierValue**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_).</span></span> <span data-ttu-id="d9337-178">**SetGlobalQualifierValue** の呼び出しで一度値を設定すると、ResourceContext を検索に使用するたびに、これらの値が既定の **ResourceContext** で有効になります。</span><span class="sxs-lookup"><span data-stu-id="d9337-178">You set values one time with a call to **SetGlobalQualifierValue** and then those values are in effect on the default **ResourceContext** each time you use it for lookups.</span></span> <span data-ttu-id="d9337-179">既定では、[**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) クラスは、既定の **ResourceContext** を使用します。</span><span class="sxs-lookup"><span data-stu-id="d9337-179">By default, the [**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) class uses the default **ResourceContext**.</span></span>

**<span data-ttu-id="d9337-180">C#</span><span class="sxs-lookup"><span data-stu-id="d9337-180">C#</span></span>**
```csharp
Windows.ApplicationModel.Resources.Core.ResourceContext.SetGlobalQualifierValue("Contrast", "high");
var namedResource = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap[@"Files/Assets/Logo.png"];
this.myXAMLImageElement.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(namedResource.Uri);
```

## <a name="updating-images-in-response-to-qualifier-value-change-events"></a><span data-ttu-id="d9337-181">修飾子の値の変更イベントへの応答で画像を更新する</span><span class="sxs-lookup"><span data-stu-id="d9337-181">Updating images in response to qualifier value change events</span></span>

<span data-ttu-id="d9337-182">実行中のアプリは、既定のリソースのコンテキストで修飾子の値に影響を与えるシステム設定の変更に応答できます。</span><span class="sxs-lookup"><span data-stu-id="d9337-182">Your running app can respond to changes in system settings that affect the qualifier values in the default resource context.</span></span> <span data-ttu-id="d9337-183">これらのシステム設定のいずれかが、[**ResourceContext.QualifierValues**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) の [**MapChanged**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_?branch=live#Windows_Foundation_Collections_IObservableMap_2_MapChanged) イベントを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d9337-183">Any of these system settings invokes the [**MapChanged**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_?branch=live#Windows_Foundation_Collections_IObservableMap_2_MapChanged) event on [**ResourceContext.QualifierValues**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues).</span></span>

<span data-ttu-id="d9337-184">このイベントへの応答で、既定の **ResourceContext** を使用して画像を再読み込みすることができます。これは、[**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) が既定で使用するものです。</span><span class="sxs-lookup"><span data-stu-id="d9337-184">In response to this event, you can reload your images with the help of the default **ResourceContext**, which [**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) uses by default.</span></span>

**<span data-ttu-id="d9337-185">C#</span><span class="sxs-lookup"><span data-stu-id="d9337-185">C#</span></span>**
```csharp
public MainPage()
{
    this.InitializeComponent();

    ...

    // Subscribe to the event that's raised when a qualifier value changes.
    var qualifierValues = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues;
    qualifierValues.MapChanged += new Windows.Foundation.Collections.MapChangedEventHandler<string, string>(QualifierValues_MapChanged);
}

private async void QualifierValues_MapChanged(IObservableMap<string, string> sender, IMapChangedEventArgs<string> @event)
{
    var dispatcher = this.myImageXAMLElement.Dispatcher;
    if (dispatcher.HasThreadAccess)
    {
        this.RefreshUIImages();
    }
    else
    {
        await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => this.RefreshUIImages());
    }
}

private void RefreshUIImages()
{
    var namedResource = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap[@"Files/Assets/Logo.png"];
    this.myImageXAMLElement.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(namedResource.Uri);
}
```

## <a name="related-topics"></a><span data-ttu-id="d9337-186">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d9337-186">Related topics</span></span>

* [<span data-ttu-id="d9337-187">言語、スケール、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="d9337-187">Tailor your resources for language, scale, and other qualifiers</span></span>](how-to-name-resources-by-using-qualifiers.md)
* [<span data-ttu-id="d9337-188">UI とアプリ パッケージ マニフェスト内の文字列をローカライズする</span><span class="sxs-lookup"><span data-stu-id="d9337-188">Localize strings in your UI and app package manifest</span></span>](put-ui-strings-into-resources.md)
* [<span data-ttu-id="d9337-189">設定と他のアプリ データを保存して取得する</span><span class="sxs-lookup"><span data-stu-id="d9337-189">Store and retrieve settings and other app data</span></span>](../app-settings/store-and-retrieve-app-data)
* [<span data-ttu-id="d9337-190">言語、スケール、ハイ コントラストに合わせたタイルとトーストのサポート</span><span class="sxs-lookup"><span data-stu-id="d9337-190">Tile and toast support for language, scale, and high contrast</span></span>](tile-toast-language-scale-contrast.md)
* [<span data-ttu-id="d9337-191">マニフェストのローカライズ可能な項目</span><span class="sxs-lookup"><span data-stu-id="d9337-191">Localizable manifest items</span></span>](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live)
* [<span data-ttu-id="d9337-192">画像の左右反転</span><span class="sxs-lookup"><span data-stu-id="d9337-192">Mirroring images</span></span>](adjust-layout-and-fonts--and-support-rtl#mirroring-images)