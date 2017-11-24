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
keywords: "Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子"
localizationpriority: medium
ms.openlocfilehash: d7ff64340de4688a53b5b6aee9bf18c26128de07
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

# <a name="load-images-and-assets-tailored-for-scale-theme-high-contrast-and-others"></a><span data-ttu-id="0fb4a-104">表示倍率、テーマ、ハイ コントラスト、その他の設定に合わせた画像とアセットの読み込み</span><span class="sxs-lookup"><span data-stu-id="0fb4a-104">Load images and assets tailored for scale, theme, high contrast, and others</span></span>

<span data-ttu-id="0fb4a-105">アプリで、[表示倍率](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)、テーマ、ハイ コントラスト、その他の実行時のコンテキストに合わせた画像リソース ファイル (またはその他のアセット ファイル) を読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-105">Your app can load image resource files (or other asset files) tailored for [display scale factor](../layout/screen-sizes-and-breakpoints-for-responsive-design.md), theme, high contrast, and other runtime contexts.</span></span> <span data-ttu-id="0fb4a-106">これらの画像は、命令型コードや XAML マークアップ (**Image** の **Source** プロパティなど) から参照できます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-106">These images can be referenced from imperative code or from XAML markup, for example as the **Source** property of an **Image**.</span></span> <span data-ttu-id="0fb4a-107">また、アプリ パッケージ マニフェスト (`Package.appxmanifest` ファイル) に (たとえば、Visual Studio マニフェスト デザイナーの [ビジュアル資産] タブでアプリ アイコンの値として) 表示することや、タイルやトースト通知に表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-107">They can also appear in your app package manifest (the `Package.appxmanifest` file)&mdash;for example, as the value for App Icon on the Visual Assets tab of the Visual Studio Manifest Designer&mdash;or on your tiles and toasts.</span></span> <span data-ttu-id="0fb4a-108">画像のファイル名に修飾子を使用し、必要に応じて [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live) を使って動的に読み込むことによって、ユーザーの実行時の表示倍率、テーマ、ハイ コントラスト、言語、その他のコンテキストの設定に最も一致する最適な画像ファイルを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-108">By using qualifiers in your images' file names, and optionally dynamically loading them with the help of a [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live), you can cause the most appropriate image file to be loaded that best matches the user's runtime settings for display scale, theme, high contrast, language, and other contexts.</span></span>

<span data-ttu-id="0fb4a-109">画像リソースは、画像リソース ファイルに含まれています。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-109">An image resource is contained in an image resource file.</span></span> <span data-ttu-id="0fb4a-110">画像はアセット、画像を含むファイルはアセット ファイルと考えることができ、これらの種類のリソース ファイルはプロジェクトの \Assets フォルダーにあります。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-110">You can also think of the image as an asset, and the file that contains it as an asset file; and you can find these kinds of resource files in your project's \Assets folder.</span></span> <span data-ttu-id="0fb4a-111">画像リソース ファイルの名前に修飾子を使用する方法の詳細については、「[言語、スケール、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-111">For background on how to use qualifiers in the names of your image resource files, see [Tailor your resources for language, scale, and other qualifiers](tailor-resources-lang-scale-contrast.md).</span></span>

<span data-ttu-id="0fb4a-112">画像の一般的な修飾子には、[scale](tailor-resources-lang-scale-contrast.md#scale)、[theme](tailor-resources-lang-scale-contrast.md#theme)、[contrast](tailor-resources-lang-scale-contrast.md#contrast)、[targetsize](tailor-resources-lang-scale-contrast.md#targetsize) があります。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-112">Some common qualifiers for images are [scale](tailor-resources-lang-scale-contrast.md#scale), [theme](tailor-resources-lang-scale-contrast.md#theme), [contrast](tailor-resources-lang-scale-contrast.md#contrast), and [targetsize](tailor-resources-lang-scale-contrast.md#targetsize).</span></span>

## <a name="qualify-an-image-resource-for-scale-theme-and-contrast"></a><span data-ttu-id="0fb4a-113">スケール、テーマ、コントラストに合わせて画像リソースを修飾する</span><span class="sxs-lookup"><span data-stu-id="0fb4a-113">Qualify an image resource for scale, theme, and contrast</span></span>

<span data-ttu-id="0fb4a-114">`scale` 修飾子の既定値は `scale-100` です。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-114">The default value for the `scale` qualifier is `scale-100`.</span></span> <span data-ttu-id="0fb4a-115">そのため、次の 2 つのバリエーションは同等です (いずれもスケール 100、つまり倍率 1 の画像を提供します)。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-115">So, these two variants are equivalent (they both provide an image at scale 100, or scale factor 1).</span></span>

```
\Assets\Images\logo.png
\Assets\Images\logo.scale-100.png
```

<span data-ttu-id="0fb4a-116">修飾子は、ファイル名の代わりにフォルダー名に使用できます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-116">You can use qualifiers in folder names instead of file names.</span></span> <span data-ttu-id="0fb4a-117">修飾子ごとにいくつかのアセット ファイルがある場合、この方法が適しています。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-117">That would be a better strategy if you have several asset files per qualifier.</span></span> <span data-ttu-id="0fb4a-118">わかりやすい例として、次の 2 つのバリエーションは上記の 2 つと同等です。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-118">For purposes of illustration, these two variants are equivalent to the two above.</span></span>

```
\Assets\Images\logo.png
\Assets\Images\scale-100\logo.png
```

<span data-ttu-id="0fb4a-119">次の例では、表示倍率、テーマ、ハイ コントラストのさまざまな設定に合わせて、`/Assets/Images/logo.png` という名前の画像リソースのバリエーションを提供する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-119">Next is an example of how you can provide variants of an image resource&mdash;named `/Assets/Images/logo.png`&mdash;for different settings of display scale, theme, and high contrast.</span></span> <span data-ttu-id="0fb4a-120">この例では、フォルダー名を使用しています。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-120">This example uses folder naming.</span></span>

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

## <a name="reference-an-image-or-other-asset-from-xaml-markup-and-code"></a><span data-ttu-id="0fb4a-121">XAML マークアップとコードから画像やその他のアセットを参照する</span><span class="sxs-lookup"><span data-stu-id="0fb4a-121">Reference an image or other asset from XAML markup and code</span></span>

<span data-ttu-id="0fb4a-122">画像リソースの名前 (つまり識別子) は、そのパスとファイル名からすべての修飾子を削除したものです。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-122">The name&mdash;or identifier&mdash;of an image resource is its path and file name with any and all qualifiers removed.</span></span> <span data-ttu-id="0fb4a-123">前のセクションの例のようにフォルダーやファイルに名前を付けている場合、画像リソースは 1 つであり、その (絶対パスとしての) 名前は `/Assets/Images/logo.png` です。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-123">If you name folders and/or files as in any of the examples in the previous section, then you have a single image resource and its name (as an absolute path) is `/Assets/Images/logo.png`.</span></span> <span data-ttu-id="0fb4a-124">この名前を XAML マークアップで使用する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-124">Here’s how you use that name in XAML markup.</span></span>

**<span data-ttu-id="0fb4a-125">XAML</span><span class="sxs-lookup"><span data-stu-id="0fb4a-125">XAML</span></span>**
```xml
<Image x:Name="myXAMLImageElement" Source="ms-appx:///Assets/Images/logo.png"/>
```

<span data-ttu-id="0fb4a-126">アプリのパッケージに付属しているファイルを参照するため、`ms-appx` URI スキームを使用していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-126">Notice that you use the `ms-appx` URI scheme because you're referring to a file that comes from your app's package.</span></span> <span data-ttu-id="0fb4a-127">「[URI スキーム](uri-schemes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-127">See [URI schemes](uri-schemes.md).</span></span> <span data-ttu-id="0fb4a-128">同じ画像リソースを命令型コード内で参照する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-128">And here’s how you refer to the same image resource in imperative code.</span></span>

**<span data-ttu-id="0fb4a-129">C#</span><span class="sxs-lookup"><span data-stu-id="0fb4a-129">C#</span></span>**
```csharp
this.myXAMLImageElement.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/logo.png"));
```

<span data-ttu-id="0fb4a-130">`ms-appx` を使用して、アプリ パッケージから任意のファイルを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-130">You can use `ms-appx` to load any arbitrary file from your app package.</span></span>

**<span data-ttu-id="0fb4a-131">C#</span><span class="sxs-lookup"><span data-stu-id="0fb4a-131">C#</span></span>**
```csharp
var uri = new System.Uri("ms-appx:///Assets/anyAsset.ext");
var storagefile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
```

<span data-ttu-id="0fb4a-132">`ms-appx-web` スキームは、`ms-appx` と同じファイルにアクセスしますが、このファイルは Web コンパートメントにあります。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-132">The `ms-appx-web` scheme accesses the same files as `ms-appx`, but in the web compartment.</span></span>

**<span data-ttu-id="0fb4a-133">XAML</span><span class="sxs-lookup"><span data-stu-id="0fb4a-133">XAML</span></span>**
```xml
<WebView x:Name="myXAMLWebViewElement" Source="ms-appx-web:///Pages/default.html"/>
```

**<span data-ttu-id="0fb4a-134">C#</span><span class="sxs-lookup"><span data-stu-id="0fb4a-134">C#</span></span>**
```csharp
this.myXAMLWebViewElement.Source = new Uri("ms-appx-web:///Pages/default.html");
```

<span data-ttu-id="0fb4a-135">これらの例に示されているどのシナリオの場合も、[UriKind](https://docs.microsoft.com/en-us/dotnet/api/system.urikind) を推測する [Uri コンストラクター](https://docs.microsoft.com/en-us/dotnet/api/system.uri.-ctor?view=netcore-2.0#System_Uri__ctor_System_String_)のオーバーロードを使用します。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-135">For any of the scenarios shown in these examples, use the [Uri constructor](https://docs.microsoft.com/en-us/dotnet/api/system.uri.-ctor?view=netcore-2.0#System_Uri__ctor_System_String_) overload that infers the [UriKind](https://docs.microsoft.com/en-us/dotnet/api/system.urikind).</span></span> <span data-ttu-id="0fb4a-136">スキームと機関を含む有効な絶対 URI を指定するか、上記の例のように、機関の既定をアプリのパッケージに自動的に設定します。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-136">Specify a valid absolute URI including the scheme and authority, or just let the authority default to the app's package as in the example above.</span></span>

<span data-ttu-id="0fb4a-137">これらの URI の例で、スキーム ("`ms-appx`" または "`ms-appx-web`") の後に "`://`" が続き、その後に絶対パスが続くことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-137">Notice how in these example URIs the scheme ("`ms-appx`" or "`ms-appx-web`") is followed by "`://`" which is followed by an absolute path.</span></span> <span data-ttu-id="0fb4a-138">絶対パスでは、先頭の "`/`" によって、パスはパッケージのルートからのパスとして解釈されます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-138">In an absolute path, the leading "`/`" causes the path to be interpreted from the root of the package.</span></span>

<span data-ttu-id="0fb4a-139">**Note** `ms-resource` ([文字列リソース](localize-strings-ui-manifest.md)の場合) および `ms-appx(-web)` (画像やその他のアセットの場合) URI スキームは、自動で修飾子の照合を実行して、現在のコンテキストに最も適切なリソースを見つけます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-139">**Note** The `ms-resource` (for [string resources](localize-strings-ui-manifest.md)) and `ms-appx(-web)` (for images and other assets) URI schemes perform automatic qualifier matching to find the resource that's most appropriate for the current context.</span></span> <span data-ttu-id="0fb4a-140">`ms-appdata` URI スキーム (アプリ データを読み込むために使用される) は、このような自動的な照合を実行しませんが、[ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) の内容に応答し、URI の完全な物理ファイル名を使用して、アプリ データから適切なアセットを明示的に読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-140">The `ms-appdata` URI scheme (which is used to load app data) does not perform any such automatic matching, but you can respond to the contents of [ResourceContext.QualifierValues](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) and explicitly load the appropriate assets from app data using their full physical file name in the URI.</span></span> <span data-ttu-id="0fb4a-141">アプリ データについては、「[設定と他のアプリ データを保存して取得する](../app-settings/store-and-retrieve-app-data.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-141">For info about app data, see [Store and retrieve settings and other app data](../app-settings/store-and-retrieve-app-data.md).</span></span> <span data-ttu-id="0fb4a-142">Web URI スキーム (`http`、`https`、`ftp` など) も、自動的な照合を実行しません。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-142">Web URI schemes (for example, `http`, `https`, and `ftp`) do not perform automatic matching, either.</span></span> <span data-ttu-id="0fb4a-143">その場合の対処方法については、「[クラウドでの画像のホスティングと読み込み](tile-toast-language-scale-contrast.md#hosting-and-loading-images-in-the-cloud)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-143">For info about what to do in that case, see [Hosting and loading images in the cloud](tile-toast-language-scale-contrast.md#hosting-and-loading-images-in-the-cloud).</span></span>

<span data-ttu-id="0fb4a-144">絶対パスは、画像ファイルがプロジェクト構造での場所に残っている場合に適切な選択肢です。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-144">Absolute paths are a good choice if your image files remain where they are in the project structure.</span></span> <span data-ttu-id="0fb4a-145">画像ファイルを移動できるようにする必要があるが、参照している XAML マークアップ ファイルから相対的に同じ場所に残るように注意している場合は、絶対パスの代わりに、ファイルを格納するマークアップ ファイルからの相対パスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-145">If you want to be able to move an image file, but you're careful that it remains in the same location relative to its referencing XAML markup file, then instead of an absolute path you might want to use a path that's relative to the containing markup file.</span></span> <span data-ttu-id="0fb4a-146">その場合、URI スキームを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-146">If you do that, then you needn't use a URI scheme.</span></span> <span data-ttu-id="0fb4a-147">この場合も、自動的な修飾子の照合のメリットはありますが、それは XAML マークアップで相対パスを使用していることにのみ起因します。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-147">You will still benefit from automatic qualifier matching in this case, but only because you are using the relative path in XAML markup.</span></span>

**<span data-ttu-id="0fb4a-148">XAML</span><span class="sxs-lookup"><span data-stu-id="0fb4a-148">XAML</span></span>**
```xml
<Image Source="Assets/Images/logo.png"/>
```

<span data-ttu-id="0fb4a-149">「[言語、スケール、ハイ コントラストに合わせたタイルとトーストのサポート](tile-toast-language-scale-contrast.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-149">Also see [Tile and toast support for language, scale, and high contrast](tile-toast-language-scale-contrast.md).</span></span>

## <a name="qualify-an-image-resource-for-targetsize"></a><span data-ttu-id="0fb4a-150">ターゲット サイズに合わせて画像リソースを修飾する</span><span class="sxs-lookup"><span data-stu-id="0fb4a-150">Qualify an image resource for targetsize</span></span>

<span data-ttu-id="0fb4a-151">同じ画像リソースのさまざまなバリエーションで `scale` 修飾子と `targetsize` 修飾子を使用できますが、リソースの 1 つのバリエーションでその両方を使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-151">You can use the `scale` and `targetsize` qualifiers on different variants of the same image resource; but you can't use them both on a single variant of a resource.</span></span> <span data-ttu-id="0fb4a-152">また、`TargetSize` 修飾子を持たないバリエーションを少なくとも 1 つ定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-152">Also, you need to define at least one variant without a `TargetSize` qualifier.</span></span> <span data-ttu-id="0fb4a-153">そのバリエーションでは、`scale` の値を定義するか、その既定値を `scale-100` にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-153">That variant must either define a value for `scale`, or let it default to `scale-100`.</span></span> <span data-ttu-id="0fb4a-154">したがって、`/Assets/Square44x44Logo.png` リソースのこれら 2 つのバリエーションは有効です。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-154">So, these two variants of the `/Assets/Square44x44Logo.png` resource are valid.</span></span>

```
\Assets\Square44x44Logo.scale-200.png
\Assets\Square44x44Logo.targetsize-24.png
```

<span data-ttu-id="0fb4a-155">また、次の 2 つのバリエーションは有効です。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-155">And these two variants are valid.</span></span> 

```
\Assets\Square44x44Logo.png // defaults to scale-100
\Assets\Square44x44Logo.targetsize-24.png
```

<span data-ttu-id="0fb4a-156">ただし、次のバリエーションは有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-156">But this variant is not valid.</span></span>

```
\Assets\Square44x44Logo.scale-200_targetsize-24.png
```

## <a name="refer-to-an-image-file-from-your-app-package-manifest"></a><span data-ttu-id="0fb4a-157">アプリ パッケージ マニフェストから画像ファイルを参照する</span><span class="sxs-lookup"><span data-stu-id="0fb4a-157">Refer to an image file from your app package manifest</span></span>

<span data-ttu-id="0fb4a-158">前のセクションの 2 つの有効な例のいずれかのように、フォルダーやファイルに名前を付けている場合、アプリ アイコンの画像リソースは 1 つであり、その (相対パスとしての) 名前は `Assets\Square44x44Logo.png` です。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-158">If you name folders and/or files as in either of the two valid examples in the previous section, then you have a single app icon image resource and its name (as a relative path) is `Assets\Square44x44Logo.png`.</span></span> <span data-ttu-id="0fb4a-159">アプリ パッケージ マニフェストでは、単に名前でリソースを参照します。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-159">In your app package manifest, simply refer to the resource by name.</span></span> <span data-ttu-id="0fb4a-160">URI スキームを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-160">There's no need to use any URI scheme.</span></span>

![リソースの追加 (英語)](images/app-icon.png)

<span data-ttu-id="0fb4a-162">必要な処理はこれだけです。OS が自動で修飾子の照合を実行して、現在のコンテキストに最も適切なリソースを見つけます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-162">That's all you need to do, and the OS will perform automatic qualifier matching to find the resource that's most appropriate for the current context.</span></span> <span data-ttu-id="0fb4a-163">アプリ パッケージ マニフェスト内で、このようにローカライズまたはその他の方法で修飾できるすべての項目の一覧については、「[マニフェストのローカライズ可能な項目](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-163">For a list of all items in the app package manifest that you can localize or otherwise qualify in this way, see [Localizable manifest items](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live).</span></span>

## <a name="qualify-an-image-resource-for-layoutdirection"></a><span data-ttu-id="0fb4a-164">レイアウト方向に合わせて画像リソースを修飾する</span><span class="sxs-lookup"><span data-stu-id="0fb4a-164">Qualify an image resource for layoutdirection</span></span>

<span data-ttu-id="0fb4a-165">「[画像の左右反転](../globalizing/adjust-layout-and-fonts--and-support-rtl.md#mirroring-images)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-165">See [Mirroring images](../globalizing/adjust-layout-and-fonts--and-support-rtl.md#mirroring-images).</span></span>

## <a name="load-an-image-for-a-specific-language-or-other-context"></a><span data-ttu-id="0fb4a-166">特定の言語または他のコンテキスト用の画像を読み込む</span><span class="sxs-lookup"><span data-stu-id="0fb4a-166">Load an image for a specific language or other context</span></span>

<span data-ttu-id="0fb4a-167">アプリのローカライズの価値提案の詳細については、「[グローバリゼーションとローカライズ](../globalizing/globalizing-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-167">For more info about the value proposition of localizing your app, see [Globalization and localization](../globalizing/globalizing-portal.md).</span></span>

<span data-ttu-id="0fb4a-168">既定の [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live) ([**ResourceContext.GetForCurrentView**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_GetForCurrentView) から取得された) には、既定の実行時コンテキスト (つまり、現在のユーザーとコンピューターの設定) を表す、各修飾子名の修飾子の値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-168">The default [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live) (obtained from [**ResourceContext.GetForCurrentView**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_GetForCurrentView)) contains a qualifier value for each qualifier name, representing the default runtime context (in other words, the settings for the current user and machine).</span></span> <span data-ttu-id="0fb4a-169">画像ファイルは、(その名前に含まれる修飾子に基づいて) 実行時コンテキストでの修飾子の値と比較されます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-169">Image files are matched&mdash;based on the qualifiers in their names&mdash;against the qualifier values in that runtime context.</span></span>

<span data-ttu-id="0fb4a-170">ただし、アプリでシステム設定を上書きし、読み込む画像を検索するときに使用する言語、スケール、その他の修飾子の値を明示的に指定することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-170">But there might be times when you want your app to override the system settings and be explicit about the language, scale, or other qualifier value to use when looking for a matching image to load.</span></span> <span data-ttu-id="0fb4a-171">たとえば、いつ、どのハイ コントラスト画像を読み込むかを正確に制御することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-171">For example, you might want to control exactly when and which high contrast images are loaded.</span></span>

<span data-ttu-id="0fb4a-172">そのためには、(既定のものを使用する代わりに) 新しい **ResourceContext** を作成し、その値をオーバーライドして、画像検索でそのコンテキスト オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-172">You can do that by constructing a new **ResourceContext** (instead of using the default one), overriding its values, and then using that context object in your image lookups.</span></span>

**<span data-ttu-id="0fb4a-173">C#</span><span class="sxs-lookup"><span data-stu-id="0fb4a-173">C#</span></span>**
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

<span data-ttu-id="0fb4a-174">グローバル レベルで同じ効果を実現するために、既定の **ResourceContext** で修飾子の値を上書きすることが*できます*。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-174">For the same effect at a global level, you *can* override the qualifier values in the default **ResourceContext**.</span></span> <span data-ttu-id="0fb4a-175">ただし、その代わりに、[**ResourceContext.SetGlobalQualifierValue**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_) を呼び出すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-175">But instead we advise you to call [**ResourceContext.SetGlobalQualifierValue**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_).</span></span> <span data-ttu-id="0fb4a-176">**SetGlobalQualifierValue** の呼び出しで一度値を設定すると、ResourceContext を検索に使用するたびに、これらの値が既定の **ResourceContext** で有効になります。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-176">You set values one time with a call to **SetGlobalQualifierValue** and then those values are in effect on the default **ResourceContext** each time you use it for lookups.</span></span> <span data-ttu-id="0fb4a-177">既定では、[**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) クラスは、既定の **ResourceContext** を使用します。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-177">By default, the [**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) class uses the default **ResourceContext**.</span></span>

**<span data-ttu-id="0fb4a-178">C#</span><span class="sxs-lookup"><span data-stu-id="0fb4a-178">C#</span></span>**
```csharp
Windows.ApplicationModel.Resources.Core.ResourceContext.SetGlobalQualifierValue("Contrast", "high");
var namedResource = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap[@"Files/Assets/Logo.png"];
this.myXAMLImageElement.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(namedResource.Uri);
```

## <a name="updating-images-in-response-to-qualifier-value-change-events"></a><span data-ttu-id="0fb4a-179">修飾子の値の変更イベントへの応答で画像を更新する</span><span class="sxs-lookup"><span data-stu-id="0fb4a-179">Updating images in response to qualifier value change events</span></span>

<span data-ttu-id="0fb4a-180">実行中のアプリは、既定のリソースのコンテキストで修飾子の値に影響を与えるシステム設定の変更に応答できます。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-180">Your running app can respond to changes in system settings that affect the qualifier values in the default resource context.</span></span> <span data-ttu-id="0fb4a-181">これらのシステム設定のいずれかが、[**ResourceContext.QualifierValues**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) の [**MapChanged**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_?branch=live#Windows_Foundation_Collections_IObservableMap_2_MapChanged) イベントを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-181">Any of these system settings invokes the [**MapChanged**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_?branch=live#Windows_Foundation_Collections_IObservableMap_2_MapChanged) event on [**ResourceContext.QualifierValues**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues).</span></span>

<span data-ttu-id="0fb4a-182">このイベントへの応答で、既定の **ResourceContext** を使用して画像を再読み込みすることができます。これは、[**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) が既定で使用するものです。</span><span class="sxs-lookup"><span data-stu-id="0fb4a-182">In response to this event, you can reload your images with the help of the default **ResourceContext**, which [**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) uses by default.</span></span>

**<span data-ttu-id="0fb4a-183">C#</span><span class="sxs-lookup"><span data-stu-id="0fb4a-183">C#</span></span>**
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

## <a name="important-apis"></a><span data-ttu-id="0fb4a-184">重要な API</span><span class="sxs-lookup"><span data-stu-id="0fb4a-184">Important APIs</span></span>

* [<span data-ttu-id="0fb4a-185">ResourceContext</span><span class="sxs-lookup"><span data-stu-id="0fb4a-185">ResourceContext</span></span>](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live)
* [<span data-ttu-id="0fb4a-186">MapChanged</span><span class="sxs-lookup"><span data-stu-id="0fb4a-186">MapChanged</span></span>](/uwp/api/windows.foundation.collections.iobservablemap_k_v_?branch=live#Windows_Foundation_Collections_IObservableMap_2_MapChanged)

## <a name="related-topics"></a><span data-ttu-id="0fb4a-187">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0fb4a-187">Related topics</span></span>

* [<span data-ttu-id="0fb4a-188">言語、スケール、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="0fb4a-188">Tailor your resources for language, scale, and other qualifiers</span></span>](tailor-resources-lang-scale-contrast.md)
* [<span data-ttu-id="0fb4a-189">UI とアプリ パッケージ マニフェスト内の文字列をローカライズする</span><span class="sxs-lookup"><span data-stu-id="0fb4a-189">Localize strings in your UI and app package manifest</span></span>](localize-strings-ui-manifest.md)
* [<span data-ttu-id="0fb4a-190">設定と他のアプリ データを保存して取得する</span><span class="sxs-lookup"><span data-stu-id="0fb4a-190">Store and retrieve settings and other app data</span></span>](../app-settings/store-and-retrieve-app-data.md)
* [<span data-ttu-id="0fb4a-191">言語、スケール、ハイ コントラストに合わせたタイルとトーストのサポート</span><span class="sxs-lookup"><span data-stu-id="0fb4a-191">Tile and toast support for language, scale, and high contrast</span></span>](tile-toast-language-scale-contrast.md)
* [<span data-ttu-id="0fb4a-192">マニフェストのローカライズ可能な項目</span><span class="sxs-lookup"><span data-stu-id="0fb4a-192">Localizable manifest items</span></span>](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live)
* [<span data-ttu-id="0fb4a-193">画像の左右反転</span><span class="sxs-lookup"><span data-stu-id="0fb4a-193">Mirroring images</span></span>](../globalizing/adjust-layout-and-fonts--and-support-rtl.md#mirroring-images)
* [<span data-ttu-id="0fb4a-194">グローバリゼーションとローカライズ</span><span class="sxs-lookup"><span data-stu-id="0fb4a-194">Globalization and localization</span></span>](../globalizing/globalizing-portal.md)