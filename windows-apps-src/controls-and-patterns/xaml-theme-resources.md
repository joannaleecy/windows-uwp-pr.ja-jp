---
author: Jwmsft
Description: "XAML のテーマ リソースは、アクティブなシステム テーマに応じて異なる値を適用するリソースのセットです。"
MS-HAID: dev\_ctrl\_layout\_txt.xaml\_theme\_resources
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: "XAML テーマ リソース"
ms.assetid: 41B87DBF-E7A2-44E9-BEBA-AF6EEBABB81B
label: XAML theme resources
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 74b16b95e1ca4e8583efa2b4967e2287c4cf5ffb
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="xaml-theme-resources"></a><span data-ttu-id="cf006-104">XAML テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="cf006-104">XAML theme resources</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="cf006-105">XAML のテーマ リソースは、アクティブなシステム テーマに応じて異なる値を適用するリソースのセットです。</span><span class="sxs-lookup"><span data-stu-id="cf006-105">Theme resources in XAML are a set of resources that apply different values depending on which system theme is active.</span></span> <span data-ttu-id="cf006-106">XAML フレームワークがサポートするテーマは "Light"、"Dark"、"HighContrast" の 3 つです。</span><span class="sxs-lookup"><span data-stu-id="cf006-106">There are 3 themes that the XAML framework supports: "Light", "Dark", and "HighContrast".</span></span>

**<span data-ttu-id="cf006-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="cf006-107">Prerequisites</span></span>**

<span data-ttu-id="cf006-108">このトピックでは、既に「[ResourceDictionary と XAML リソースの参照](resourcedictionary-and-xaml-resource-references.md)」を読んでいることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="cf006-108">This topic assumes that you have read [ResourceDictionary and XAML resource references](resourcedictionary-and-xaml-resource-references.md).</span></span>

## <a name="how-theme-resources-differ-from-static-resources"></a><span data-ttu-id="cf006-109">静的なリソースとのテーマ リソースの違い</span><span class="sxs-lookup"><span data-stu-id="cf006-109">How theme resources differ from static resources</span></span>

<span data-ttu-id="cf006-110">既存の XAML リソース ディクショナリから XAML リソースを参照できる XAML マークアップ拡張には、[{StaticResource} マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)と [{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)の 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="cf006-110">There are two XAML markup extensions that can reference a XAML resource from an existing XAML resource dictionary: [{StaticResource} markup extension](../xaml-platform/staticresource-markup-extension.md) and [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md).</span></span>

<span data-ttu-id="cf006-111">[{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)はアプリの読み込み時に評価され、その後、実行時にテーマが変更されたときにもそのつど評価されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-111">Evaluation of a [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md) occurs when the app loads and subsequently each time the theme changes at runtime.</span></span> <span data-ttu-id="cf006-112">これは通常、ユーザーがデバイスの設定を変更した場合、またはアプリ内でプログラムによってアプリの現在のテーマが変更された場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="cf006-112">This is typically the result of the user changing their device settings or from a programmatic change within the app that alters its current theme.</span></span>

<span data-ttu-id="cf006-113">これに対して [{StaticResource} マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)は、XAML が最初にアプリに読み込まれるときにのみ評価されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-113">In contrast, a [{StaticResource} markup extension](../xaml-platform/staticresource-markup-extension.md) is evaluated only when the XAML is first loaded by the app.</span></span> <span data-ttu-id="cf006-114">これが更新されることはありません。</span><span class="sxs-lookup"><span data-stu-id="cf006-114">It does not update.</span></span> <span data-ttu-id="cf006-115">これは、アプリの起動時に XAML を検索し、実際のランタイム値に置き換えるようなものです。</span><span class="sxs-lookup"><span data-stu-id="cf006-115">It’s similar to a find and replace in your XAML with the actual runtime value at app launch.</span></span>

## <a name="theme-resources-and-where-they-fit-in-the-resource-dictionary-structure"></a><span data-ttu-id="cf006-116">テーマ リソースとリソース ディクショナリ構造での適切な場所</span><span class="sxs-lookup"><span data-stu-id="cf006-116">Theme resources and where they fit in the resource dictionary structure</span></span>


<span data-ttu-id="cf006-117">各テーマ リソースは、XAML ファイル themeresources.xaml の一部です。</span><span class="sxs-lookup"><span data-stu-id="cf006-117">Each theme resource is part of the XAML file themeresources.xaml.</span></span> <span data-ttu-id="cf006-118">設計の目的には、Windows ソフトウェア開発キット (Windows SDK) のインストール先の \\(Program Files)\\Windows Kits\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\&lt;SDK version&gt;\\Generic フォルダーにある themeresources.xaml を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="cf006-118">For design purposes, themeresources.xaml is available in the \\(Program Files)\\Windows Kits\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\&lt;SDK version&gt;\\Generic folder from a Windows Software Development Kit (SDK) installation.</span></span> <span data-ttu-id="cf006-119">themeresources.xaml 内のリソース ディクショナリは、同じディレクトリの generic.xaml にも複製されています。</span><span class="sxs-lookup"><span data-stu-id="cf006-119">The resource dictionaries in themeresources.xaml are also reproduced in generic.xaml in the same directory.</span></span>

> <span data-ttu-id="cf006-120">**注:**&nbsp;&nbsp;これらの物理ファイルは Windows ランタイムでランタイム検索に使われません。</span><span class="sxs-lookup"><span data-stu-id="cf006-120">**Note**&nbsp;&nbsp;The Windows Runtime doesn't use these physical files for runtime lookup.</span></span> <span data-ttu-id="cf006-121">そのため、明示的に DesignTime フォルダー内にあり、既定ではアプリにコピーされません。</span><span class="sxs-lookup"><span data-stu-id="cf006-121">That's why they are specifically in a DesignTime folder, and they aren't copied into apps by default.</span></span> <span data-ttu-id="cf006-122">代わりに、これらのリソース ディクショナリは Windows ランタイム自体の一部としてメモリ内に存在し、テーマ リソース (またはシステム リソース) へのアプリの XAML リソース参照は実行時にメモリ内で解決されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-122">Instead, these resource dictionaries exist in memory as part of the Windows Runtime itself, and your app's XAML resource references to theme resources (or system resources) resolve there at runtime.</span></span>

 ## <a name="guidelines-for-using-theme-resources"></a><span data-ttu-id="cf006-123">テーマ リソースの使用のガイドライン</span><span class="sxs-lookup"><span data-stu-id="cf006-123">Guidelines for using theme resources</span></span>

<span data-ttu-id="cf006-124">独自のカスタム テーマ リソースを定義して使うときは、次のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="cf006-124">Follow these guidelines when you define and consume your own custom theme resources.</span></span>

<span data-ttu-id="cf006-125">推奨:</span><span class="sxs-lookup"><span data-stu-id="cf006-125">DO:</span></span>

-   <span data-ttu-id="cf006-126">"HighContrast" ディクショナリに加えて、"Light" と "Dark" の両方のテーマ ディクショナリを指定します。</span><span class="sxs-lookup"><span data-stu-id="cf006-126">Specify theme dictionaries for both "Light" and "Dark" in addition to your "HighContrast" dictionary.</span></span> <span data-ttu-id="cf006-127">"Default" をキーとする [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) を作成することもできますが、明示的に "Light"、"Dark"、"HighContrast" を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cf006-127">Although you can create a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) with "Default" as the key, it’s preferred to be explicit and instead use "Light", "Dark", and "HighContrast".</span></span>
-   <span data-ttu-id="cf006-128">スタイル、セッター、コントロール テンプレート、プロパティ セッター、アニメーションでは、[{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="cf006-128">Use the [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md) in: Styles, Setters, Control templates, Property setters, and Animations.</span></span>

<span data-ttu-id="cf006-129">非推奨:</span><span class="sxs-lookup"><span data-stu-id="cf006-129">DO NOT:</span></span>

-   <span data-ttu-id="cf006-130">[ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) 内のリソース定義では、[{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md) を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="cf006-130">Use the [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md) in your resource definitions inside your [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807).</span></span> <span data-ttu-id="cf006-131">代わりに、[{StaticResource} マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="cf006-131">Use [{StaticResource} markup extension](../xaml-platform/staticresource-markup-extension.md) instead.</span></span>

    <span data-ttu-id="cf006-132">例外: [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) 内のアプリ テーマに依存しないリソースを参照するために [{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)を使うことは問題ありません。</span><span class="sxs-lookup"><span data-stu-id="cf006-132">EXCEPTION: it is alright to use the [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md) to reference resources that are agnostic to the app theme in your [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807).</span></span> <span data-ttu-id="cf006-133">このようなリソースの例として、`SystemAccentColor` などのアクセント カラー リソースや、通常は "SystemColor" というプレフィックスの付いた `SystemColorButtonFaceColor` などのシステム カラー リソースがあります。</span><span class="sxs-lookup"><span data-stu-id="cf006-133">Examples of these resources are accent color resources like `SystemAccentColor`, or system color resources, which are typically prefixed with "SystemColor" like `SystemColorButtonFaceColor`.</span></span>

<span data-ttu-id="cf006-134">**注意:** これらのガイドラインに従わないと、テーマに関連する予期しない動作がアプリで発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="cf006-134">**Caution**  If you don’t follow these guidelines, you might see unexpected behavior related to themes in your app.</span></span> <span data-ttu-id="cf006-135">詳しくは、「[テーマ リソースのトラブルシューティング](#troubleshooting-theme-resources)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cf006-135">For more info, see the [Troubleshooting theme resources](#troubleshooting-theme-resources) section.</span></span>
 

## <a name="the-xaml-color-ramp-and-theme-dependent-brushes"></a><span data-ttu-id="cf006-136">XAML 色見本とテーマ依存のブラシ</span><span class="sxs-lookup"><span data-stu-id="cf006-136">The XAML color ramp and theme-dependent brushes</span></span>

<span data-ttu-id="cf006-137">XAML における *Windows 色見本*は、"Light"、"Dark"、"HighContrast" の各テーマの色のセットを組み合わせることで構成されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-137">The combined set of colors for "Light", "Dark", and "HighContrast" themes make up the *Windows color ramp* in XAML.</span></span> <span data-ttu-id="cf006-138">システム テーマを変更する場合でも、システム テーマを独自の XAML 要素に適用する場合でも、カラー リソースがどのように構成されるかを理解することが重要です。</span><span class="sxs-lookup"><span data-stu-id="cf006-138">Whether you want to modify the system themes, or apply a system theme to your own XAML elements, it’s important to understand how the color resources are structured.</span></span>

### <a name="light-and-dark-theme-colors"></a><span data-ttu-id="cf006-139">Light テーマと Dark テーマの色</span><span class="sxs-lookup"><span data-stu-id="cf006-139">Light and Dark theme colors</span></span>

<span data-ttu-id="cf006-140">XAML フレームワークには、"Light" と "Dark" のテーマに合わせてカスタマイズされた名前付きの [Color](https://msdn.microsoft.com/library/windows/apps/hh673723) リソースのセットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="cf006-140">The XAML framework provides a set of named [Color](https://msdn.microsoft.com/library/windows/apps/hh673723) resources with values that are tailored for the "Light" and "Dark" themes.</span></span> <span data-ttu-id="cf006-141">これらを参照するために使うキーは、`System[Simple Light/Dark Name]Color` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="cf006-141">The keys you use to reference these follow the naming format: `System[Simple Light/Dark Name]Color`.</span></span>

<span data-ttu-id="cf006-142">次の表は、XAML フレームワークで提供される "Light" と "Dark" のリソースについて、それぞれのキー、簡易名、色の文字列表現 (\#aarrggbb 形式) の一覧を示しています。</span><span class="sxs-lookup"><span data-stu-id="cf006-142">This table lists the key, simple name, and string representation of the color (using the \#aarrggbb format) for the "Light" and "Dark" resources provided by the XAML framework.</span></span> <span data-ttu-id="cf006-143">キーは、アプリでリソースを参照するときに使われます。</span><span class="sxs-lookup"><span data-stu-id="cf006-143">The key is used to reference the resource in an app.</span></span> <span data-ttu-id="cf006-144">"Light/Dark 簡易名" は、後で説明するブラシの名前付け規則の一部として使われます。</span><span class="sxs-lookup"><span data-stu-id="cf006-144">The "Simple light/dark name" is used as part of the brush naming convention that we explain later.</span></span>

| <span data-ttu-id="cf006-145">キー</span><span class="sxs-lookup"><span data-stu-id="cf006-145">Key</span></span>                             | <span data-ttu-id="cf006-146">Light/Dark 簡易名</span><span class="sxs-lookup"><span data-stu-id="cf006-146">Simple light/dark name</span></span> | <span data-ttu-id="cf006-147">Light</span><span class="sxs-lookup"><span data-stu-id="cf006-147">Light</span></span>      | <span data-ttu-id="cf006-148">Dark</span><span class="sxs-lookup"><span data-stu-id="cf006-148">Dark</span></span>       |
|---------------------------------|------------------------|------------|------------|
| <span data-ttu-id="cf006-149">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-149">SystemAltHighColor</span></span>              | <span data-ttu-id="cf006-150">AltHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-150">AltHigh</span></span>                | <span data-ttu-id="cf006-151">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-151">\#FFFFFFFF</span></span> | <span data-ttu-id="cf006-152">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="cf006-152">\#FF000000</span></span> |
| <span data-ttu-id="cf006-153">SystemAltLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-153">SystemAltLowColor</span></span>               | <span data-ttu-id="cf006-154">AltLow</span><span class="sxs-lookup"><span data-stu-id="cf006-154">AltLow</span></span>                 | <span data-ttu-id="cf006-155">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-155">\#33FFFFFF</span></span> | <span data-ttu-id="cf006-156">\#33000000</span><span class="sxs-lookup"><span data-stu-id="cf006-156">\#33000000</span></span> |
| <span data-ttu-id="cf006-157">SystemAltMediumColor</span><span class="sxs-lookup"><span data-stu-id="cf006-157">SystemAltMediumColor</span></span>            | <span data-ttu-id="cf006-158">AltMedium</span><span class="sxs-lookup"><span data-stu-id="cf006-158">AltMedium</span></span>              | <span data-ttu-id="cf006-159">\#99FFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-159">\#99FFFFFF</span></span> | <span data-ttu-id="cf006-160">\#99000000</span><span class="sxs-lookup"><span data-stu-id="cf006-160">\#99000000</span></span> |
| <span data-ttu-id="cf006-161">SystemAltMediumHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-161">SystemAltMediumHighColor</span></span>        | <span data-ttu-id="cf006-162">AltMediumHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-162">AltMediumHigh</span></span>          | <span data-ttu-id="cf006-163">\#CCFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-163">\#CCFFFFFF</span></span> | <span data-ttu-id="cf006-164">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="cf006-164">\#CC000000</span></span> |
| <span data-ttu-id="cf006-165">SystemAltMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-165">SystemAltMediumLowColor</span></span>         | <span data-ttu-id="cf006-166">AltMediumLow</span><span class="sxs-lookup"><span data-stu-id="cf006-166">AltMediumLow</span></span>           | <span data-ttu-id="cf006-167">\#66FFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-167">\#66FFFFFF</span></span> | <span data-ttu-id="cf006-168">\#66000000</span><span class="sxs-lookup"><span data-stu-id="cf006-168">\#66000000</span></span> |
| <span data-ttu-id="cf006-169">SystemBaseHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-169">SystemBaseHighColor</span></span>             | <span data-ttu-id="cf006-170">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-170">BaseHigh</span></span>               | <span data-ttu-id="cf006-171">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="cf006-171">\#FF000000</span></span> | <span data-ttu-id="cf006-172">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-172">\#FFFFFFFF</span></span> |
| <span data-ttu-id="cf006-173">SystemBaseLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-173">SystemBaseLowColor</span></span>              | <span data-ttu-id="cf006-174">BaseLow</span><span class="sxs-lookup"><span data-stu-id="cf006-174">BaseLow</span></span>                | <span data-ttu-id="cf006-175">\#33000000</span><span class="sxs-lookup"><span data-stu-id="cf006-175">\#33000000</span></span> | <span data-ttu-id="cf006-176">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-176">\#33FFFFFF</span></span> |
| <span data-ttu-id="cf006-177">SystemBaseMediumColor</span><span class="sxs-lookup"><span data-stu-id="cf006-177">SystemBaseMediumColor</span></span>           | <span data-ttu-id="cf006-178">BaseMedium</span><span class="sxs-lookup"><span data-stu-id="cf006-178">BaseMedium</span></span>             | <span data-ttu-id="cf006-179">\#99000000</span><span class="sxs-lookup"><span data-stu-id="cf006-179">\#99000000</span></span> | <span data-ttu-id="cf006-180">\#99FFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-180">\#99FFFFFF</span></span> |
| <span data-ttu-id="cf006-181">SystemBaseMediumHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-181">SystemBaseMediumHighColor</span></span>       | <span data-ttu-id="cf006-182">BaseMediumHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-182">BaseMediumHigh</span></span>         | <span data-ttu-id="cf006-183">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="cf006-183">\#CC000000</span></span> | <span data-ttu-id="cf006-184">\#CCFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-184">\#CCFFFFFF</span></span> |
| <span data-ttu-id="cf006-185">SystemBaseMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-185">SystemBaseMediumLowColor</span></span>        | <span data-ttu-id="cf006-186">BaseMediumLow</span><span class="sxs-lookup"><span data-stu-id="cf006-186">BaseMediumLow</span></span>          | <span data-ttu-id="cf006-187">\#66000000</span><span class="sxs-lookup"><span data-stu-id="cf006-187">\#66000000</span></span> | <span data-ttu-id="cf006-188">\#66FFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-188">\#66FFFFFF</span></span> |
| <span data-ttu-id="cf006-189">SystemChromeAltLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-189">SystemChromeAltLowColor</span></span>         | <span data-ttu-id="cf006-190">ChromeAltLow</span><span class="sxs-lookup"><span data-stu-id="cf006-190">ChromeAltLow</span></span>           | <span data-ttu-id="cf006-191">\#FF171717</span><span class="sxs-lookup"><span data-stu-id="cf006-191">\#FF171717</span></span> | <span data-ttu-id="cf006-192">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="cf006-192">\#FFF2F2F2</span></span> |
| <span data-ttu-id="cf006-193">SystemChromeBlackHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-193">SystemChromeBlackHighColor</span></span>      | <span data-ttu-id="cf006-194">ChromeBlackHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-194">ChromeBlackHigh</span></span>        | <span data-ttu-id="cf006-195">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="cf006-195">\#FF000000</span></span> | <span data-ttu-id="cf006-196">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="cf006-196">\#FF000000</span></span> |
| <span data-ttu-id="cf006-197">SystemChromeBlackLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-197">SystemChromeBlackLowColor</span></span>       | <span data-ttu-id="cf006-198">ChromeBlackLow</span><span class="sxs-lookup"><span data-stu-id="cf006-198">ChromeBlackLow</span></span>         | <span data-ttu-id="cf006-199">\#33000000</span><span class="sxs-lookup"><span data-stu-id="cf006-199">\#33000000</span></span> | <span data-ttu-id="cf006-200">\#33000000</span><span class="sxs-lookup"><span data-stu-id="cf006-200">\#33000000</span></span> |
| <span data-ttu-id="cf006-201">SystemChromeBlackMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-201">SystemChromeBlackMediumLowColor</span></span> | <span data-ttu-id="cf006-202">ChromeBlackMediumLow</span><span class="sxs-lookup"><span data-stu-id="cf006-202">ChromeBlackMediumLow</span></span>   | <span data-ttu-id="cf006-203">\#66000000</span><span class="sxs-lookup"><span data-stu-id="cf006-203">\#66000000</span></span> | <span data-ttu-id="cf006-204">\#66000000</span><span class="sxs-lookup"><span data-stu-id="cf006-204">\#66000000</span></span> |
| <span data-ttu-id="cf006-205">SystemChromeBlackMediumColor</span><span class="sxs-lookup"><span data-stu-id="cf006-205">SystemChromeBlackMediumColor</span></span>    | <span data-ttu-id="cf006-206">ChromeBlackMedium</span><span class="sxs-lookup"><span data-stu-id="cf006-206">ChromeBlackMedium</span></span>      | <span data-ttu-id="cf006-207">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="cf006-207">\#CC000000</span></span> | <span data-ttu-id="cf006-208">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="cf006-208">\#CC000000</span></span> |
| <span data-ttu-id="cf006-209">SystemChromeDisabledHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-209">SystemChromeDisabledHighColor</span></span>   | <span data-ttu-id="cf006-210">ChromeDisabledHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-210">ChromeDisabledHigh</span></span>     | <span data-ttu-id="cf006-211">\#FFCCCCCC</span><span class="sxs-lookup"><span data-stu-id="cf006-211">\#FFCCCCCC</span></span> | <span data-ttu-id="cf006-212">\#FF333333</span><span class="sxs-lookup"><span data-stu-id="cf006-212">\#FF333333</span></span> |
| <span data-ttu-id="cf006-213">SystemChromeDisabledLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-213">SystemChromeDisabledLowColor</span></span>    | <span data-ttu-id="cf006-214">ChromeDisabledLow</span><span class="sxs-lookup"><span data-stu-id="cf006-214">ChromeDisabledLow</span></span>      | <span data-ttu-id="cf006-215">\#FF7A7A7A</span><span class="sxs-lookup"><span data-stu-id="cf006-215">\#FF7A7A7A</span></span> | <span data-ttu-id="cf006-216">\#FF858585</span><span class="sxs-lookup"><span data-stu-id="cf006-216">\#FF858585</span></span> |
| <span data-ttu-id="cf006-217">SystemChromeHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-217">SystemChromeHighColor</span></span>           | <span data-ttu-id="cf006-218">ChromeHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-218">ChromeHigh</span></span>             | <span data-ttu-id="cf006-219">\#FFCCCCCC</span><span class="sxs-lookup"><span data-stu-id="cf006-219">\#FFCCCCCC</span></span> | <span data-ttu-id="cf006-220">\#FF767676</span><span class="sxs-lookup"><span data-stu-id="cf006-220">\#FF767676</span></span> |
| <span data-ttu-id="cf006-221">SystemChromeLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-221">SystemChromeLowColor</span></span>            | <span data-ttu-id="cf006-222">ChromeLow</span><span class="sxs-lookup"><span data-stu-id="cf006-222">ChromeLow</span></span>              | <span data-ttu-id="cf006-223">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="cf006-223">\#FFF2F2F2</span></span> | <span data-ttu-id="cf006-224">\#FF171717</span><span class="sxs-lookup"><span data-stu-id="cf006-224">\#FF171717</span></span> |
| <span data-ttu-id="cf006-225">SystemChromeMediumColor</span><span class="sxs-lookup"><span data-stu-id="cf006-225">SystemChromeMediumColor</span></span>         | <span data-ttu-id="cf006-226">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="cf006-226">ChromeMedium</span></span>           | <span data-ttu-id="cf006-227">\#FFE6E6E6</span><span class="sxs-lookup"><span data-stu-id="cf006-227">\#FFE6E6E6</span></span> | <span data-ttu-id="cf006-228">\#FF1F1F1F</span><span class="sxs-lookup"><span data-stu-id="cf006-228">\#FF1F1F1F</span></span> |
| <span data-ttu-id="cf006-229">SystemChromeMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-229">SystemChromeMediumLowColor</span></span>      | <span data-ttu-id="cf006-230">ChromeMediumLow</span><span class="sxs-lookup"><span data-stu-id="cf006-230">ChromeMediumLow</span></span>        | <span data-ttu-id="cf006-231">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="cf006-231">\#FFF2F2F2</span></span> | <span data-ttu-id="cf006-232">\#FF2B2B2B</span><span class="sxs-lookup"><span data-stu-id="cf006-232">\#FF2B2B2B</span></span> |
| <span data-ttu-id="cf006-233">SystemChromeWhiteColor</span><span class="sxs-lookup"><span data-stu-id="cf006-233">SystemChromeWhiteColor</span></span>          | <span data-ttu-id="cf006-234">ChromeWhite</span><span class="sxs-lookup"><span data-stu-id="cf006-234">ChromeWhite</span></span>            | <span data-ttu-id="cf006-235">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-235">\#FFFFFFFF</span></span> | <span data-ttu-id="cf006-236">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-236">\#FFFFFFFF</span></span> |
| <span data-ttu-id="cf006-237">SystemListLowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-237">SystemListLowColor</span></span>              | <span data-ttu-id="cf006-238">ListLow</span><span class="sxs-lookup"><span data-stu-id="cf006-238">ListLow</span></span>                | <span data-ttu-id="cf006-239">\#19000000</span><span class="sxs-lookup"><span data-stu-id="cf006-239">\#19000000</span></span> | <span data-ttu-id="cf006-240">\#19FFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-240">\#19FFFFFF</span></span> |
| <span data-ttu-id="cf006-241">SystemListMediumColor</span><span class="sxs-lookup"><span data-stu-id="cf006-241">SystemListMediumColor</span></span>           | <span data-ttu-id="cf006-242">ListMedium</span><span class="sxs-lookup"><span data-stu-id="cf006-242">ListMedium</span></span>             | <span data-ttu-id="cf006-243">\#33000000</span><span class="sxs-lookup"><span data-stu-id="cf006-243">\#33000000</span></span> | <span data-ttu-id="cf006-244">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-244">\#33FFFFFF</span></span> |


### <a name="windows-system-high-contrast-colors"></a><span data-ttu-id="cf006-245">Windows システムのハイ コントラストの色</span><span class="sxs-lookup"><span data-stu-id="cf006-245">Windows system high-contrast colors</span></span>

<span data-ttu-id="cf006-246">XAML フレームワークによって提供されるリソースのセットのほかに、Windows のシステム パレットから派生するカラー値のセットがあります。</span><span class="sxs-lookup"><span data-stu-id="cf006-246">In addition to the set of resources provided by the XAML framework, there's a set of color values derived from the Windows system palette.</span></span> <span data-ttu-id="cf006-247">これらの色は、Windows ランタイムやユニバーサル Windows プラットフォーム (UWP) アプリに固有のものではありません。</span><span class="sxs-lookup"><span data-stu-id="cf006-247">These colors are not specific to the Windows Runtime or Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="cf006-248">しかし、"HighContrast" テーマでシステムが動作しているとき (およびアプリが実行されているとき) には、XAML [Brush](https://msdn.microsoft.com/library/windows/apps/br228076) リソースの多くでこれらの色が使われます。</span><span class="sxs-lookup"><span data-stu-id="cf006-248">However, many of the XAML [Brush](https://msdn.microsoft.com/library/windows/apps/br228076) resources consume these colors when the system is operating (and the app is running) using the "HighContrast" theme.</span></span> <span data-ttu-id="cf006-249">XAML フレームワークには、このようなシステム全体の色がキーを持つリソースとして用意されています。</span><span class="sxs-lookup"><span data-stu-id="cf006-249">The XAML framework provides these system-wide colors as keyed resources.</span></span> <span data-ttu-id="cf006-250">これらのキーは、`SystemColor[name]Color` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="cf006-250">The keys follow the naming format: `SystemColor[name]Color`.</span></span>

<span data-ttu-id="cf006-251">次の表は、Windows システム パレットから派生したリソース オブジェクトとして XAML に用意されているシステム全体の色を示します。</span><span class="sxs-lookup"><span data-stu-id="cf006-251">This table lists the system-wide colors that XAML provides as resource objects derived from the Windows system palette.</span></span> <span data-ttu-id="cf006-252">"簡単操作での名前" 列は、その色が Windows の設定の UI でどのように表現されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="cf006-252">The "Ease of Access name" column shows how color is labeled in the Windows settings UI.</span></span> <span data-ttu-id="cf006-253">"HighContrast 簡易名" 列は、その色が XAML コモン コントロールにどのように適用されるかをひとことで表す単語になっています。</span><span class="sxs-lookup"><span data-stu-id="cf006-253">The "Simple HighContrast name" column is a one word description of how the color is applied across the XAML common controls.</span></span> <span data-ttu-id="cf006-254">これは、後で説明するブラシの名前付け規則の一部として使われます。</span><span class="sxs-lookup"><span data-stu-id="cf006-254">It's used as part of the brush naming convention that we explain later.</span></span> <span data-ttu-id="cf006-255">"初期既定値" 列は、システムがハイ コントラストで動作していない場合に使われる値を示します。</span><span class="sxs-lookup"><span data-stu-id="cf006-255">The "Initial default" column shows the values you'd get if the system is not running in high contrast at all.</span></span>

| <span data-ttu-id="cf006-256">キー</span><span class="sxs-lookup"><span data-stu-id="cf006-256">Key</span></span>                           | <span data-ttu-id="cf006-257">簡単操作での名前</span><span class="sxs-lookup"><span data-stu-id="cf006-257">Ease of Access name</span></span>            | <span data-ttu-id="cf006-258">HighContrast 簡易名</span><span class="sxs-lookup"><span data-stu-id="cf006-258">Simple HighContrast name</span></span> | <span data-ttu-id="cf006-259">初期既定値</span><span class="sxs-lookup"><span data-stu-id="cf006-259">Initial default</span></span> |
|-------------------------------|--------------------------------|--------------------------|-----------------|
| <span data-ttu-id="cf006-260">SystemColorButtonFaceColor</span><span class="sxs-lookup"><span data-stu-id="cf006-260">SystemColorButtonFaceColor</span></span>    | <span data-ttu-id="cf006-261">**ボタン テキスト** (背景)</span><span class="sxs-lookup"><span data-stu-id="cf006-261">**Button Text** (background)</span></span>   | <span data-ttu-id="cf006-262">Background</span><span class="sxs-lookup"><span data-stu-id="cf006-262">Background</span></span>               | <span data-ttu-id="cf006-263">\#FFF0F0F0</span><span class="sxs-lookup"><span data-stu-id="cf006-263">\#FFF0F0F0</span></span>      |
| <span data-ttu-id="cf006-264">SystemColorButtonTextColor</span><span class="sxs-lookup"><span data-stu-id="cf006-264">SystemColorButtonTextColor</span></span>    | <span data-ttu-id="cf006-265">**ボタン テキスト** (前景)</span><span class="sxs-lookup"><span data-stu-id="cf006-265">**Button Text** (foreground)</span></span>   | <span data-ttu-id="cf006-266">Foreground</span><span class="sxs-lookup"><span data-stu-id="cf006-266">Foreground</span></span>               | <span data-ttu-id="cf006-267">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="cf006-267">\#FF000000</span></span>      |
| <span data-ttu-id="cf006-268">SystemColorGrayTextColor</span><span class="sxs-lookup"><span data-stu-id="cf006-268">SystemColorGrayTextColor</span></span>      | **<span data-ttu-id="cf006-269">淡色表示のテキスト</span><span class="sxs-lookup"><span data-stu-id="cf006-269">Disabled Text</span></span>**              | <span data-ttu-id="cf006-270">Disabled</span><span class="sxs-lookup"><span data-stu-id="cf006-270">Disabled</span></span>                 | <span data-ttu-id="cf006-271">\#FF6D6D6D</span><span class="sxs-lookup"><span data-stu-id="cf006-271">\#FF6D6D6D</span></span>      |
| <span data-ttu-id="cf006-272">SystemColorHighlightColor</span><span class="sxs-lookup"><span data-stu-id="cf006-272">SystemColorHighlightColor</span></span>     | <span data-ttu-id="cf006-273">**選択されたテキスト** (背景)</span><span class="sxs-lookup"><span data-stu-id="cf006-273">**Selected Text** (background)</span></span> | <span data-ttu-id="cf006-274">Highlight</span><span class="sxs-lookup"><span data-stu-id="cf006-274">Highlight</span></span>                | <span data-ttu-id="cf006-275">\#FF3399FF</span><span class="sxs-lookup"><span data-stu-id="cf006-275">\#FF3399FF</span></span>      |
| <span data-ttu-id="cf006-276">SystemColorHighlightTextColor</span><span class="sxs-lookup"><span data-stu-id="cf006-276">SystemColorHighlightTextColor</span></span> | <span data-ttu-id="cf006-277">**選択されたテキスト** (前景)</span><span class="sxs-lookup"><span data-stu-id="cf006-277">**Selected Text** (foreground)</span></span> | <span data-ttu-id="cf006-278">HighlightAlt</span><span class="sxs-lookup"><span data-stu-id="cf006-278">HighlightAlt</span></span>             | <span data-ttu-id="cf006-279">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-279">\#FFFFFFFF</span></span>      |
| <span data-ttu-id="cf006-280">SystemColorHotlightColor</span><span class="sxs-lookup"><span data-stu-id="cf006-280">SystemColorHotlightColor</span></span>      | **<span data-ttu-id="cf006-281">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="cf006-281">Hyperlinks</span></span>**                 | <span data-ttu-id="cf006-282">Hyperlink</span><span class="sxs-lookup"><span data-stu-id="cf006-282">Hyperlink</span></span>                | <span data-ttu-id="cf006-283">\#FF0066CC</span><span class="sxs-lookup"><span data-stu-id="cf006-283">\#FF0066CC</span></span>      |
| <span data-ttu-id="cf006-284">SystemColorWindowColor</span><span class="sxs-lookup"><span data-stu-id="cf006-284">SystemColorWindowColor</span></span>        | **<span data-ttu-id="cf006-285">背景</span><span class="sxs-lookup"><span data-stu-id="cf006-285">Background</span></span>**                 | <span data-ttu-id="cf006-286">PageBackground</span><span class="sxs-lookup"><span data-stu-id="cf006-286">PageBackground</span></span>           | <span data-ttu-id="cf006-287">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-287">\#FFFFFFFF</span></span>      |
| <span data-ttu-id="cf006-288">SystemColorWindowTextColor</span><span class="sxs-lookup"><span data-stu-id="cf006-288">SystemColorWindowTextColor</span></span>    | **<span data-ttu-id="cf006-289">テキスト</span><span class="sxs-lookup"><span data-stu-id="cf006-289">Text</span></span>**                       | <span data-ttu-id="cf006-290">PageText</span><span class="sxs-lookup"><span data-stu-id="cf006-290">PageText</span></span>                 | <span data-ttu-id="cf006-291">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="cf006-291">\#FF000000</span></span>      |


<span data-ttu-id="cf006-292">Windows には複数のハイ コントラスト テーマが用意されているほか、次のように、コンピューターの簡単操作を通じて、独自のハイ コントラスト設定で使う特定の色をユーザーが設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="cf006-292">Windows provides different high-contrast themes, and enables the user to set the specific colors to for their high-contrast settings through the Ease of Access Center, as shown here.</span></span> <span data-ttu-id="cf006-293">このため、ハイ コントラストのカラー値の確定的な一覧を提供することはできません。</span><span class="sxs-lookup"><span data-stu-id="cf006-293">Therefore, it's not possible to provide a definitive list of high-contrast color values.</span></span>

![Windows のハイ コントラストの設定 UI](images/high-contrast-settings.png)

<span data-ttu-id="cf006-295">ハイ コントラスト テーマのサポートについて詳しくは、「[ハイ コントラスト テーマ](https://msdn.microsoft.com/library/windows/apps/mt244346)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cf006-295">For more info about supporting high-contrast themes, see [High-contrast themes](https://msdn.microsoft.com/library/windows/apps/mt244346).</span></span>

### <a name="system-accent-color"></a><span data-ttu-id="cf006-296">システムのアクセント カラー</span><span class="sxs-lookup"><span data-stu-id="cf006-296">System accent color</span></span>

<span data-ttu-id="cf006-297">システムのハイ コントラスト テーマの色に加えて、システムのアクセント カラーも、`SystemAccentColor` というキーを使う特別なカラー リソースとして用意されています。</span><span class="sxs-lookup"><span data-stu-id="cf006-297">In addition to the system high-contrast theme colors, the system accent color is provided as a special color resource using the key `SystemAccentColor`.</span></span> <span data-ttu-id="cf006-298">このリソースは、ユーザーが Windows の個人設定でアクセント カラーとして指定した色を実行時に取得します。</span><span class="sxs-lookup"><span data-stu-id="cf006-298">At runtime, this resource gets the color that the user has specified as the accent color in the Windows personalization settings.</span></span>

> <span data-ttu-id="cf006-299">**注:**&nbsp;&nbsp;ハイ コントラスト カラーとアクセント カラーのシステム カラー リソースは、同じ名前を持つリソースを作成してオーバーライドすることもできますが、特にハイ コントラスト設定についてはユーザーによる色の選択を尊重することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cf006-299">**Note**&nbsp;&nbsp;It’s possible to override the system color resources for high-contrast color and accent color by creating resources with the same names, but it’s a best practice to respect the user’s color choices, especially for high-contrast settings.</span></span>

### <a name="theme-dependent-brushes"></a><span data-ttu-id="cf006-300">テーマ依存のブラシ</span><span class="sxs-lookup"><span data-stu-id="cf006-300">Theme-dependent brushes</span></span>

<span data-ttu-id="cf006-301">システム テーマ リソース ディクショナリの [SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/br242962) リソースの [Color](https://msdn.microsoft.com/library/windows/apps/br242963) プロパティは、前のセクションに示したカラー リソースを使って設定されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-301">The color resources shown in the preceding sections are used to set the [Color](https://msdn.microsoft.com/library/windows/apps/br242963) property of [SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/br242962) resources in the system theme resource dictionaries.</span></span> <span data-ttu-id="cf006-302">XAML 要素に色を適用するには、ブラシ リソースが使われます。</span><span class="sxs-lookup"><span data-stu-id="cf006-302">You use the brush resources to apply the color to XAML elements.</span></span> <span data-ttu-id="cf006-303">ブラシ リソースのキーは、`SystemControl[Simple HighContrast name][Simple light/dark name]Brush` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="cf006-303">The keys for the brush resources follow the naming format: `SystemControl[Simple HighContrast name][Simple light/dark name]Brush`.</span></span> <span data-ttu-id="cf006-304">たとえば、`SystemControlBackroundAltHighBrush` と記述します。</span><span class="sxs-lookup"><span data-stu-id="cf006-304">For example, `SystemControlBackroundAltHighBrush`.</span></span>

<span data-ttu-id="cf006-305">このブラシの色の値が実行時にどのように決定されるかを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="cf006-305">Let’s look at how the color value for this brush is determined at run-time.</span></span> <span data-ttu-id="cf006-306">"Light" と "Dark" の各リソース ディクショナリでは、このブラシは次のように定義されています。</span><span class="sxs-lookup"><span data-stu-id="cf006-306">In the "Light" and "Dark" resource dictionaries, this brush is defined like this:</span></span>

`<SolidColorBrush x:Key="SystemControlBackgroundAltHighBrush" Color="{StaticResource SystemAltHighColor}"/>`

<span data-ttu-id="cf006-307">"HighContrast" リソース ディクショナリでは、このブラシは次のように定義されています。</span><span class="sxs-lookup"><span data-stu-id="cf006-307">In the "HighContrast" resource dictionary, this brush is defined like this:</span></span>

`<SolidColorBrush x:Key="SystemControlBackgroundAltHighBrush" Color="{ThemeResource SystemColorButtonFaceColor}"/>`

<span data-ttu-id="cf006-308">このブラシが XAML 要素に適用されるとき、その色は、次の表に示すように現在のテーマによって実行時に決定されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-308">When this brush is applied to a XAML element, its color is determined at run-time by the current theme, as shown in this table.</span></span>

| <span data-ttu-id="cf006-309">テーマ</span><span class="sxs-lookup"><span data-stu-id="cf006-309">Theme</span></span>        | <span data-ttu-id="cf006-310">色の簡易名</span><span class="sxs-lookup"><span data-stu-id="cf006-310">Color simple name</span></span> | <span data-ttu-id="cf006-311">カラー リソース</span><span class="sxs-lookup"><span data-stu-id="cf006-311">Color resource</span></span>             | <span data-ttu-id="cf006-312">ランタイム値</span><span class="sxs-lookup"><span data-stu-id="cf006-312">Runtime value</span></span>                                              |
|--------------|-------------------|----------------------------|------------------------------------------------------------|
| <span data-ttu-id="cf006-313">Light</span><span class="sxs-lookup"><span data-stu-id="cf006-313">Light</span></span>        | <span data-ttu-id="cf006-314">AltHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-314">AltHigh</span></span>           | <span data-ttu-id="cf006-315">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-315">SystemAltHighColor</span></span>         | <span data-ttu-id="cf006-316">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="cf006-316">\#FFFFFFFF</span></span>                                                 |
| <span data-ttu-id="cf006-317">Dark</span><span class="sxs-lookup"><span data-stu-id="cf006-317">Dark</span></span>         | <span data-ttu-id="cf006-318">AltHigh</span><span class="sxs-lookup"><span data-stu-id="cf006-318">AltHigh</span></span>           | <span data-ttu-id="cf006-319">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="cf006-319">SystemAltHighColor</span></span>         | <span data-ttu-id="cf006-320">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="cf006-320">\#FF000000</span></span>                                                 |
| <span data-ttu-id="cf006-321">HighContrast</span><span class="sxs-lookup"><span data-stu-id="cf006-321">HighContrast</span></span> | <span data-ttu-id="cf006-322">Background</span><span class="sxs-lookup"><span data-stu-id="cf006-322">Background</span></span>        | <span data-ttu-id="cf006-323">SystemColorButtonFaceColor</span><span class="sxs-lookup"><span data-stu-id="cf006-323">SystemColorButtonFaceColor</span></span> | <span data-ttu-id="cf006-324">設定でボタンの背景として指定された色。</span><span class="sxs-lookup"><span data-stu-id="cf006-324">The color specified in settings for the button background.</span></span> |

<span data-ttu-id="cf006-325">独自の XAML 要素に適用するブラシを決めるには、`SystemControl[Simple HighContrast name][Simple light/dark name]Brush` という名前付けスキームを使います。</span><span class="sxs-lookup"><span data-stu-id="cf006-325">You can use the `SystemControl[Simple HighContrast name][Simple light/dark name]Brush` naming scheme to determine which brush to apply to your own XAML elements.</span></span> 

<!--
For many examples of how the brushes are used in the XAML control templates, see the [Default control styles and templates](default-control-styles-and-templates.md).
-->

> <span data-ttu-id="cf006-326">**注:**&nbsp;&nbsp;\[*HighContrast 簡易名*\]\[*Light/Dark 簡易名*\] のすべての組み合わせがブラシ リソースとして提供されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="cf006-326">**Note**&nbsp;&nbsp;Not every combination of \[*Simple HighContrast name*\]\[*Simple light/dark name*\] is provided as a brush resource.</span></span>

## <a name="the-xaml-type-ramp"></a><span data-ttu-id="cf006-327">XAML の書体見本</span><span class="sxs-lookup"><span data-stu-id="cf006-327">The XAML type ramp</span></span>

<span data-ttu-id="cf006-328">themeresources.xaml ファイルには、UI 上のテキスト コンテナー (具体的には [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) または [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)) に適用できる [Style](https://msdn.microsoft.com/library/windows/apps/br208849) を定義するリソースがいくつか定義されています。</span><span class="sxs-lookup"><span data-stu-id="cf006-328">The themeresources.xaml file defines several resources that define a [Style](https://msdn.microsoft.com/library/windows/apps/br208849) that you can apply to text containers in your UI, specifically for either [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) or [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565).</span></span> <span data-ttu-id="cf006-329">これらは、既定の暗黙的なスタイルとは異なります。</span><span class="sxs-lookup"><span data-stu-id="cf006-329">These are not the default implicit styles.</span></span> <span data-ttu-id="cf006-330">これらのスタイルを使うと、「[フォントのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh700394)」で説明されている *Windows の書体見本*に一致する XAML UI 定義を簡単に作成できるようになります。</span><span class="sxs-lookup"><span data-stu-id="cf006-330">They are provided to make it easier for you to create XAML UI definitions that match the *Windows type ramp* documented in [Guidelines for fonts](https://msdn.microsoft.com/library/windows/apps/hh700394).</span></span>

<span data-ttu-id="cf006-331">これらのスタイルは、テキスト コンテナー全体に適用されるテキスト属性を設定するものです。</span><span class="sxs-lookup"><span data-stu-id="cf006-331">These styles are for text attributes that you want applied to the whole text container.</span></span> <span data-ttu-id="cf006-332">テキストの一部にのみスタイルを適用する場合は、コンテナー内のテキスト要素に属性を設定します。たとえば、[TextBlock.Inlines](https://msdn.microsoft.com/library/windows/apps/br209668) の [Run](https://msdn.microsoft.com/library/windows/apps/br209959) や [RichTextBlock.Blocks](https://msdn.microsoft.com/library/windows/apps/br244347) の [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="cf006-332">If you want styles applied just to sections of the text, set attributes on the text elements within the container, such as on a [Run](https://msdn.microsoft.com/library/windows/apps/br209959) in [TextBlock.Inlines](https://msdn.microsoft.com/library/windows/apps/br209668) or on a [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) in [RichTextBlock.Blocks](https://msdn.microsoft.com/library/windows/apps/br244347).</span></span>

<span data-ttu-id="cf006-333">スタイルを [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) に適用すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="cf006-333">The styles look like this when applied to a [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652):</span></span>

![テキスト ブロック スタイル](images/text-block-type-ramp.png)

### <a name="basetextblockstyle"></a><span data-ttu-id="cf006-335">BaseTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-335">BaseTextBlockStyle</span></span>

<span data-ttu-id="cf006-336">**TargetType**: [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)</span><span class="sxs-lookup"><span data-stu-id="cf006-336">**TargetType**: [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)</span></span>

<span data-ttu-id="cf006-337">他のすべての [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) コンテナー スタイルに対する一般的なプロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="cf006-337">Supplies the common properties for all the other [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) container styles.</span></span>

```XAML
<!-- Usage -->
<TextBlock Text="Base" Style="{StaticResource BaseTextBlockStyle}"/>

<!-- Style definition -->
<Style x:Key="BaseTextBlockStyle" TargetType="TextBlock">
    <Setter Property="FontFamily" Value="Segoe UI"/>
    <Setter Property="FontWeight" Value="SemiBold"/>
    <Setter Property="FontSize" Value="15"/>
    <Setter Property="TextTrimming" Value="None"/>
    <Setter Property="TextWrapping" Value="Wrap"/>
    <Setter Property="LineStackingStrategy" Value="MaxHeight"/>
    <Setter Property="TextLineBounds" Value="Full"/>
</Style>
```

### <a name="headertextblockstyle"></a><span data-ttu-id="cf006-338">HeaderTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-338">HeaderTextBlockStyle</span></span>

```XAML
<!-- Usage -->
<TextBlock Text="Header" Style="{StaticResource HeaderTextBlockStyle}"/>

<!-- Style definition -->
<Style x:Key="HeaderTextBlockStyle" TargetType="TextBlock"
       BasedOn="{StaticResource BaseTextBlockStyle}">
    <Setter Property="FontSize" Value="46"/>
    <Setter Property="FontWeight" Value="Light"/>
    <Setter Property="OpticalMarginAlignment" Value="TrimSideBearings"/>
</Style>
```

### <a name="subheadertextblockstyle"></a><span data-ttu-id="cf006-339">SubheaderTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-339">SubheaderTextBlockStyle</span></span>

```XAML
<!-- Usage -->
<TextBlock Text="SubHeader" Style="{StaticResource SubheaderTextBlockStyle}"/>

<!-- Style definition -->
<Style x:Key="SubheaderTextBlockStyle" TargetType="TextBlock" 
       BasedOn="{StaticResource BaseTextBlockStyle}">
    <Setter Property="FontSize" Value="34"/>
    <Setter Property="FontWeight" Value="Light"/>
    <Setter Property="OpticalMarginAlignment" Value="TrimSideBearings"/>
</Style>
```

### <a name="titletextblockstyle"></a><span data-ttu-id="cf006-340">TitleTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-340">TitleTextBlockStyle</span></span>

```XAML
<!-- Usage -->
<TextBlock Text="Title" Style="{StaticResource TitleTextBlockStyle}"/>

<!-- Style definition -->
<Style x:Key="TitleTextBlockStyle" TargetType="TextBlock" 
       BasedOn="{StaticResource BaseTextBlockStyle}">
    <Setter Property="FontWeight" Value="SemiLight"/>
    <Setter Property="FontSize" Value="24"/>
    <Setter Property="OpticalMarginAlignment" Value="TrimSideBearings"/>
</Style>
```

### <a name="subtitletextblockstyle"></a><span data-ttu-id="cf006-341">SubtitleTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-341">SubtitleTextBlockStyle</span></span>

```XAML
<!-- Usage -->
<TextBlock Text="SubTitle" Style="{StaticResource SubtitleTextBlockStyle}"/>

<!-- Style definition -->
<Style x:Key="SubtitleTextBlockStyle" TargetType="TextBlock" 
       BasedOn="{StaticResource BaseTextBlockStyle}">
    <Setter Property="FontWeight" Value="Normal"/>
    <Setter Property="FontSize" Value="20"/>
    <Setter Property="OpticalMarginAlignment" Value="TrimSideBearings"/>
</Style>
```

### <a name="bodytextblockstyle"></a><span data-ttu-id="cf006-342">BodyTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-342">BodyTextBlockStyle</span></span>

```XAML
<!-- Usage -->
<TextBlock Text="Body" Style="{StaticResource BodyTextBlockStyle}"/>

<!-- Style definition -->
<Style x:Key="BodyTextBlockStyle" TargetType="TextBlock" 
       BasedOn="{StaticResource BaseTextBlockStyle}">
    <Setter Property="FontWeight" Value="Normal"/>
    <Setter Property="FontSize" Value="15"/>
</Style>
```

### <a name="captiontextblockstyle"></a><span data-ttu-id="cf006-343">CaptionTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-343">CaptionTextBlockStyle</span></span>

```XAML
<!-- Usage -->
<TextBlock Text="Caption" Style="{StaticResource CaptionTextBlockStyle}"/>

<!-- Style definition -->
<Style x:Key="CaptionTextBlockStyle" TargetType="TextBlock" 
       BasedOn="{StaticResource BaseTextBlockStyle}">
    <Setter Property="FontSize" Value="12"/>
    <Setter Property="FontWeight" Value="Normal"/>
</Style>
```

### <a name="baserichtextblockstyle"></a><span data-ttu-id="cf006-344">BaseRichTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-344">BaseRichTextBlockStyle</span></span>

<span data-ttu-id="cf006-345">**TargetType**: [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)</span><span class="sxs-lookup"><span data-stu-id="cf006-345">**TargetType**: [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)</span></span>

<span data-ttu-id="cf006-346">他のすべての [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) コンテナー スタイルに対する一般的なプロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="cf006-346">Supplies the common properties for all the other [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) container styles.</span></span>

```XAML
<!-- Usage -->
<RichTextBlock Style="{StaticResource BaseRichTextBlockStyle}">
    <Paragraph>Rich text.</Paragraph>
</RichTextBlock>

<!-- Style definition -->
<Style x:Key="BaseRichTextBlockStyle" TargetType="RichTextBlock">
    <Setter Property="FontFamily" Value="Segoe UI"/>
    <Setter Property="FontWeight" Value="SemiBold"/>
    <Setter Property="FontSize" Value="15"/>
    <Setter Property="TextTrimming" Value="None"/>
    <Setter Property="TextWrapping" Value="Wrap"/>
    <Setter Property="LineStackingStrategy" Value="MaxHeight"/>
    <Setter Property="TextLineBounds" Value="Full"/>
    <Setter Property="OpticalMarginAlignment" Value="TrimSideBearings"/>
</Style>
```

### <a name="bodyrichtextblockstyle"></a><span data-ttu-id="cf006-347">BodyRichTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-347">BodyRichTextBlockStyle</span></span>

```XAML
<!-- Usage -->
<RichTextBlock Style="{StaticResource BodyRichTextBlockStyle}">
    <Paragraph>Rich text.</Paragraph>
</RichTextBlock>

<!-- Style definition -->
<Style x:Key="BodyRichTextBlockStyle" TargetType="RichTextBlock" BasedOn="{StaticResource BaseRichTextBlockStyle}">
    <Setter Property="FontWeight" Value="Normal"/>
</Style>
```

> <span data-ttu-id="cf006-348">**注:**&nbsp;&nbsp;[RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) スタイルには、[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) に含まれているテキスト見本スタイルのすべては含まれていません。これは主に、**RichTextBlock** のブロック ベースのドキュメント オブジェクト モデルでは、個々のテキスト要素への属性の設定がより簡単になっているためです。</span><span class="sxs-lookup"><span data-stu-id="cf006-348">**Note**&nbsp;&nbsp;  The [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) styles don't have all the text ramp styles that [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) does, mainly because the block-based document object model for **RichTextBlock** makes it easier to set attributes on the individual text elements.</span></span> <span data-ttu-id="cf006-349">また、XAML コンテンツ プロパティを使って [TextBlock.Text](https://msdn.microsoft.com/library/windows/apps/br209676) を設定する方式では、スタイルを設定できるテキスト要素が存在しない状況になるため、コンテナーにスタイルを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf006-349">Also, setting [TextBlock.Text](https://msdn.microsoft.com/library/windows/apps/br209676) using the XAML content property introduces a situation where there is no text element to style and thus you'd have to style the container.</span></span> <span data-ttu-id="cf006-350">これに対して **RichTextBlock** では、テキスト コンテンツは常に [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) などの固有のテキスト要素になり、そこにページ ヘッダーやページ サブヘッダー、類似のテキスト見本定義の XAML スタイルを適用できるため、この問題はありません。</span><span class="sxs-lookup"><span data-stu-id="cf006-350">That isn't an issue for **RichTextBlock** because its text content always has to be in specific text elements like [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503), which is where you might apply XAML styles for page header, page subheader and similar text ramp definitions.</span></span>

## <a name="miscellaneous-named-styles"></a><span data-ttu-id="cf006-351">その他の名前付きスタイル</span><span class="sxs-lookup"><span data-stu-id="cf006-351">Miscellaneous Named styles</span></span>

<span data-ttu-id="cf006-352">[Button](https://msdn.microsoft.com/library/windows/apps/br209265) には、キーを持つ [Style](https://msdn.microsoft.com/library/windows/apps/br208849) 定義の追加のセットを適用することもできます。これにより、既定の暗黙的なスタイルとは異なるスタイルを設定できます。</span><span class="sxs-lookup"><span data-stu-id="cf006-352">There's an additional set of keyed [Style](https://msdn.microsoft.com/library/windows/apps/br208849) definitions you can apply to style a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) differently than its default implicit style.</span></span>

### <a name="textblockbuttonstyle"></a><span data-ttu-id="cf006-353">TextBlockButtonStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-353">TextBlockButtonStyle</span></span>

<span data-ttu-id="cf006-354">**TargetType**: [ButtonBase](https://msdn.microsoft.com/library/windows/apps/br227736)</span><span class="sxs-lookup"><span data-stu-id="cf006-354">**TargetType**: [ButtonBase](https://msdn.microsoft.com/library/windows/apps/br227736)</span></span>

<span data-ttu-id="cf006-355">ユーザーがクリックしてアクションを実行できるテキストを表示する必要がある場合は、このスタイルを [Button](https://msdn.microsoft.com/library/windows/apps/br209265) に適用します。</span><span class="sxs-lookup"><span data-stu-id="cf006-355">Apply this style to a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) when you need to show text that a user can click to take action.</span></span> <span data-ttu-id="cf006-356">このテキストには、対話型であることがわかるように現在のアクセント カラーを使ったスタイルが設定され、テキストに適したフォーカス四角形が表示されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-356">The text is styled using the current accent color to distinguish it as interactive and has focus rectangles that work well for text.</span></span> <span data-ttu-id="cf006-357">[HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/br242739) の暗黙的なスタイルとは異なり、**TextBlockButtonStyle** のテキストには下線は付きません。</span><span class="sxs-lookup"><span data-stu-id="cf006-357">Unlike the implicit style of a [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/br242739), the **TextBlockButtonStyle** does not underline the text.</span></span>

<span data-ttu-id="cf006-358">このテンプレートは、表示テキストにもスタイルを設定して、**SystemControlHyperlinkBaseMediumBrush** ("PointerOver" 状態の場合)、**SystemControlHighlightBaseMediumLowBrush** ("Pressed" 状態の場合)、**SystemControlDisabledBaseLowBrush** ("Disabled" 状態の場合) が使われるようにします。</span><span class="sxs-lookup"><span data-stu-id="cf006-358">The template also styles the presented text to use **SystemControlHyperlinkBaseMediumBrush** (for "PointerOver" state), **SystemControlHighlightBaseMediumLowBrush** (for "Pressed" state) and **SystemControlDisabledBaseLowBrush** (for "Disabled" state).</span></span>

<span data-ttu-id="cf006-359">**TextBlockButtonStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="cf006-359">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **TextBlockButtonStyle** resource applied to it.</span></span>

```XAML
<Button Content="Clickable text" Style="{StaticResource TextBlockButtonStyle}" 
        Click="Button_Click"/>
```

<span data-ttu-id="cf006-360">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="cf006-360">It looks like this:</span></span>

![テキストのような外観にスタイル設定されたボタン](images/styles-textblock-button-style.png)

### <a name="navigationbackbuttonnormalstyle"></a><span data-ttu-id="cf006-362">NavigationBackButtonNormalStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-362">NavigationBackButtonNormalStyle</span></span>

<span data-ttu-id="cf006-363">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span><span class="sxs-lookup"><span data-stu-id="cf006-363">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span></span>

<span data-ttu-id="cf006-364">この [Style](https://msdn.microsoft.com/library/windows/apps/br208849) は、ナビゲーション アプリの戻るボタンとして使うことができる [Button](https://msdn.microsoft.com/library/windows/apps/br209265) 用の完全なテンプレートを提供します。</span><span class="sxs-lookup"><span data-stu-id="cf006-364">This [Style](https://msdn.microsoft.com/library/windows/apps/br208849) provides a complete template for a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) that can be the navigation back button for a navigation app.</span></span> <span data-ttu-id="cf006-365">スタイルに含まれているいくつかのテーマ リソース参照により、このボタンでは Segoe MDL2 Assets 記号フォントが使われるようになります。このため、コンテンツでは、テキストではなく [Symbol](https://msdn.microsoft.com/library/windows/apps/dn252842) 値を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf006-365">It includes theme resource references that make this button use the Segoe MDL2 Assets symbol font, so you should use a [Symbol](https://msdn.microsoft.com/library/windows/apps/dn252842) value as the content rather than text.</span></span> <span data-ttu-id="cf006-366">既定の寸法は 40 x 40 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="cf006-366">The default dimensions are 40 x 40 pixels.</span></span> <span data-ttu-id="cf006-367">スタイルを調整するには、**Button** の [Height](https://msdn.microsoft.com/library/windows/apps/br208718)、[Width](https://msdn.microsoft.com/library/windows/apps/br208751)、[FontSize](https://msdn.microsoft.com/library/windows/apps/br209406)、その他のプロパティを明示的に設定するか、[BasedOn](https://msdn.microsoft.com/library/windows/apps/br208852) を使って派生スタイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="cf006-367">To tailor the styling you can either explicitly set the [Height](https://msdn.microsoft.com/library/windows/apps/br208718), [Width](https://msdn.microsoft.com/library/windows/apps/br208751), [FontSize](https://msdn.microsoft.com/library/windows/apps/br209406), and other properties on your **Button** or create a derived style using [BasedOn](https://msdn.microsoft.com/library/windows/apps/br208852).</span></span>

<span data-ttu-id="cf006-368">**NavigationBackButtonNormalStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="cf006-368">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **NavigationBackButtonNormalStyle** resource applied to it.</span></span>

```XAML
<Button Content="&amp;#xE830;" Style="{StaticResource NavigationBackButtonNormalStyle}" 
        Click="Button_Click"/>
```

<span data-ttu-id="cf006-369">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="cf006-369">It looks like this:</span></span>

!["戻る" ボタンとしてスタイル設定されたボタン](images/styles-back-button-normal.png)

### <a name="navigationbackbuttonsmallstyle"></a><span data-ttu-id="cf006-371">NavigationBackButtonSmallStyle</span><span class="sxs-lookup"><span data-stu-id="cf006-371">NavigationBackButtonSmallStyle</span></span>

<span data-ttu-id="cf006-372">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span><span class="sxs-lookup"><span data-stu-id="cf006-372">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span></span>

<span data-ttu-id="cf006-373">この [Style](https://msdn.microsoft.com/library/windows/apps/br208849) は、ナビゲーション アプリの戻るボタンとして使うことができる [Button](https://msdn.microsoft.com/library/windows/apps/br209265) 用の完全なテンプレートを提供します。</span><span class="sxs-lookup"><span data-stu-id="cf006-373">This [Style](https://msdn.microsoft.com/library/windows/apps/br208849) provides a complete template for a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) that can be the navigation back button for a navigation app.</span></span> <span data-ttu-id="cf006-374">**NavigationBackButtonNormalStyle** と同様ですが、寸法は 30 x 30 ピクセルになります。</span><span class="sxs-lookup"><span data-stu-id="cf006-374">It's similar to **NavigationBackButtonNormalStyle**, but its dimensions are 30 by 30 pixels.</span></span>

<span data-ttu-id="cf006-375">**NavigationBackButtonSmallStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="cf006-375">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **NavigationBackButtonSmallStyle** resource applied to it.</span></span>

```XAML
<Button Content="&amp;#xE830;" Style="{StaticResource NavigationBackButtonSmallStyle}" 
        Click="Button_Click"/>
```

## <a name="troubleshooting-theme-resources"></a><span data-ttu-id="cf006-376">テーマ リソースのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="cf006-376">Troubleshooting theme resources</span></span>


<span data-ttu-id="cf006-377">[テーマ リソースの使用に関するガイドライン](#guidelines-for-using-theme-resources)に従わないと、テーマに関連する予期しない動作がアプリで発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="cf006-377">If you don’t follow the [guidelines for using theme resources](#guidelines-for-using-theme-resources), you might see unexpected behavior related to themes in your app.</span></span>

<span data-ttu-id="cf006-378">たとえば、淡色テーマのポップアップを開いたときに、濃色テーマのアプリの部分まで淡色テーマのように変更される場合があります。</span><span class="sxs-lookup"><span data-stu-id="cf006-378">For example, when you open a light-themed flyout, parts of your dark-themed app also change as if they were in the light theme.</span></span> <span data-ttu-id="cf006-379">または、淡色テーマのページに移動してから戻ってくると、元の濃色テーマのページ (またはその部分) が淡色テーマのように表示される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="cf006-379">Or if you navigate to a light-themed page and then navigate back, the original dark-themed page (or parts of it) now looks as though it is in the light theme.</span></span>

<span data-ttu-id="cf006-380">このような問題は、通常、"Default" テーマと "HighContrast" テーマを用意してハイ コントラスト シナリオをサポートした状態で、"Light" と "Dark" の両方のテーマをアプリ内の別々の部分で使っている場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="cf006-380">Typically, these types of issues occur when you provide a "Default" theme and a "HighContrast" theme to support high-contrast scenarios, and then use both "Light" and "Dark" themes in different parts of your app.</span></span>

<span data-ttu-id="cf006-381">たとえば、次のテーマ ディクショナリの定義について考えてみます。</span><span class="sxs-lookup"><span data-stu-id="cf006-381">For example, consider this theme dictionary definition:</span></span>

```XAML
<!-- DO NOT USE. THIS XAML DEMONSTRATES AN ERROR. -->
<ResourceDictionary>
  <ResourceDictionary.ThemeDictionaries>
    <ResourceDictionary x:Key="Default">
      <SolidColorBrush x:Key="myBrush" Color="{ThemeResource SystemBaseHighColor}"/>
    </ResourceDictionary>
    <ResourceDictionary x:Key="HighContrast">
      <SolidColorBrush x:Key="myBrush" Color="{ThemeResource SystemColorButtonFaceColor}"/>
    </ResourceDictionary>
  </ResourceDictionary.ThemeDictionaries>
</ResourceDictionary>
```

<span data-ttu-id="cf006-382">直感的には、これは正しく見えます。</span><span class="sxs-lookup"><span data-stu-id="cf006-382">Intuitively, this looks correct.</span></span> <span data-ttu-id="cf006-383">ハイ コントラストのときは `myBrush` が指す色を変更しますが、ハイ コントラストでない場合は、[{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)を利用することで `myBrush` がテーマに適した色を指すようにしています。</span><span class="sxs-lookup"><span data-stu-id="cf006-383">You want to change the color pointed to by `myBrush` when in high-contrast, but when not in high-contrast, you rely on the [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md) to make sure that `myBrush` points to the right color for your theme.</span></span> <span data-ttu-id="cf006-384">これは通常、アプリのビジュアル ツリー内に [FrameworkElement.RequestedTheme](https://msdn.microsoft.com/library/windows/apps/dn298515) が設定された要素がなければ期待どおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="cf006-384">If your app never has [FrameworkElement.RequestedTheme](https://msdn.microsoft.com/library/windows/apps/dn298515) set on elements within its visual tree, this will typically work as expected.</span></span> <span data-ttu-id="cf006-385">しかし、ビジュアル ツリーの各部分にテーマを再設定し始めたとたんに、アプリで問題が発生することになります。</span><span class="sxs-lookup"><span data-stu-id="cf006-385">However, you run into problems in your app as soon as you start to re-theme different parts of your visual tree.</span></span>

<span data-ttu-id="cf006-386">問題が発生する原因は、他のほとんどの XAML 型とは異なり、ブラシが共有リソースであるためです。</span><span class="sxs-lookup"><span data-stu-id="cf006-386">The problem occurs because brushes are shared resources, unlike most other XAML types.</span></span> <span data-ttu-id="cf006-387">XAML サブツリーに 2 つの要素があり、同じブラシ リソースを参照する別々のテーマが設定されている場合、フレームワークが各サブツリーを走査してそれぞれの [{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)表現を更新していくと、それにつれて共有ブラシ リソースに対する変更が他のサブツリーに反映されます。これは意図した結果とは異なります。</span><span class="sxs-lookup"><span data-stu-id="cf006-387">If you have 2 elements in XAML sub-trees with different themes that reference the same brush resource, then as the framework walks each sub-tree to update its [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md) expressions, changes to the shared brush resource are reflected in the other sub-tree, which is not your intended result.</span></span>

<span data-ttu-id="cf006-388">これを修正するには、"Default" ディクショナリを置き換えて、"HighContrast" に加えて "Light" テーマと "Dark" テーマのディクショナリも個別に指定します。</span><span class="sxs-lookup"><span data-stu-id="cf006-388">To fix this, replace the "Default" dictionary with separate theme dictionaries for both "Light" and "Dark" themes in addition to "HighContrast":</span></span>

```XAML
<!-- DO NOT USE. THIS XAML DEMONSTRATES AN ERROR. -->
<ResourceDictionary>
  <ResourceDictionary.ThemeDictionaries>
    <ResourceDictionary x:Key="Light">
      <SolidColorBrush x:Key="myBrush" Color="{ThemeResource SystemBaseHighColor}"/>
    </ResourceDictionary>    
    <ResourceDictionary x:Key="Dark">
      <SolidColorBrush x:Key="myBrush" Color="{ThemeResource SystemBaseHighColor}"/>
    </ResourceDictionary>
    <ResourceDictionary x:Key="HighContrast">
      <SolidColorBrush x:Key="myBrush" Color="{ThemeResource SystemColorButtonFaceColor}"/>
    </ResourceDictionary>
  </ResourceDictionary.ThemeDictionaries>
</ResourceDictionary>
```

<span data-ttu-id="cf006-389">ただし、これらのリソースのいずれかが [Foreground](https://msdn.microsoft.com/library/windows/apps/br209414) などの継承されたプロパティで参照されていると、引き続き問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="cf006-389">However, problems still occur if any of these resources are referenced in inherited properties like [Foreground](https://msdn.microsoft.com/library/windows/apps/br209414).</span></span> <span data-ttu-id="cf006-390">カスタム コントロール テンプレートでは、[{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)を使って要素の前景色を指定している場合がありますが、継承された値がフレームワークによって子要素に伝達されるときは、{ThemeResource} マークアップ拡張表現で解決されたリソースへの直接参照が提供されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-390">Your custom control template might specify the foreground color of an element using the [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md), but when the framework propagates the inherited value to child elements, it provides a direct reference to the resource that was resolved by the {ThemeResource} markup extension expression.</span></span> <span data-ttu-id="cf006-391">フレームワークがコントロールのビジュアル ツリーを走査する過程でテーマの変更が処理されると、問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="cf006-391">This causes problems when the framework processes theme changes as it walks your control's visual tree.</span></span> <span data-ttu-id="cf006-392">フレームワークは {ThemeResource} マークアップ拡張表現を再評価して新しいブラシ リソースを取得しますが、この参照はまだコントロールの子に伝達されません。子への伝達は、次回の測定パスの間など、後で行われます。</span><span class="sxs-lookup"><span data-stu-id="cf006-392">It re-evaluates the {ThemeResource} markup extension expression to get a new brush resource but doesn’t yet propagate this reference down to the children of your control; this happens later, such as during the next measure pass.</span></span>

<span data-ttu-id="cf006-393">結果として、テーマの変更に応答してコントロールのビジュアル ツリーを走査した後、フレームワークは子を走査し、それぞれに設定されている [{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)表現、または子のプロパティに設定されているオブジェクト上の表現をすべて更新します。</span><span class="sxs-lookup"><span data-stu-id="cf006-393">As a result, after walking the control visual tree in response to a theme change, the framework walks the children and updates any [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md) expressions set on them, or on objects set on their properties.</span></span> <span data-ttu-id="cf006-394">ここで問題が発生します。フレームワークがブラシ リソースを走査すると、その色は {ThemeResource} マークアップ拡張を使って指定されているため、ブラシ リソースが再評価されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-394">This is where the problem occurs; the framework walks the brush resource and because it specifies its color using a {ThemeResource} markup extension, it's re-evaluated.</span></span>

<span data-ttu-id="cf006-395">この時点で、あるディクショナリのリソースに別のディクショナリから設定された色が適用され、フレームワークがテーマ ディクショナリを汚染した形になります。</span><span class="sxs-lookup"><span data-stu-id="cf006-395">At this point, the framework appears to have polluted your theme dictionary because it now has a resource from one dictionary that has its color set from another dictionary.</span></span>

<span data-ttu-id="cf006-396">この問題を解決するには、[{ThemeResource} マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)の代わりに [{StaticResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="cf006-396">To fix this problem, use the [{StaticResource} markup extension](../xaml-platform/staticresource-markup-extension.md) instead of [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md).</span></span> <span data-ttu-id="cf006-397">ガイドラインを適用したテーマ ディクショナリは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="cf006-397">With the guidelines applied, the theme dictionaries look like this:</span></span>

```XAML
<ResourceDictionary>
  <ResourceDictionary.ThemeDictionaries>
    <ResourceDictionary x:Key="Light">
      <SolidColorBrush x:Key="myBrush" Color="{StaticResource SystemBaseHighColor}"/>
    </ResourceDictionary>    
    <ResourceDictionary x:Key="Dark">
      <SolidColorBrush x:Key="myBrush" Color="{StaticResource SystemBaseHighColor}"/>
    </ResourceDictionary>
    <ResourceDictionary x:Key="HighContrast">
      <SolidColorBrush x:Key="myBrush" Color="{ThemeResource SystemColorButtonFaceColor}"/>
    </ResourceDictionary>
  </ResourceDictionary.ThemeDictionaries>
</ResourceDictionary>
```

<span data-ttu-id="cf006-398">"HighContrast" ディクショナリでは、[{StaticResource} マークアップ拡張](../xaml-platform/staticresource-markup-extension.md)ではなく [{ThemeResource} マークアップ拡張](../xaml-platform/themeresource-markup-extension.md)が引き続き使われていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="cf006-398">Notice that the [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md) is still used in the "HighContrast" dictionary instead of [{StaticResource} markup extension](../xaml-platform/staticresource-markup-extension.md).</span></span> <span data-ttu-id="cf006-399">この状況は、ガイドラインで既に説明した例外に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="cf006-399">This situation falls under the exception given earlier in the guidelines.</span></span> <span data-ttu-id="cf006-400">"HighContrast" テーマに使われるブラシの値のほとんどは、システムによって全体的に制御される色から選択されますが、これらは特別な名前付きのリソース (名前に 'SystemColor' というプレフィックスが付いているもの) として XAML に公開されています。</span><span class="sxs-lookup"><span data-stu-id="cf006-400">Most of the brush values that are used for the "HighContrast" theme are using color choices that are globally controlled by the system, but exposed to XAML as a specially-named resource (those prefixed with ‘SystemColor’ in the name).</span></span> <span data-ttu-id="cf006-401">ハイ コントラスト設定で使う特定の色は、コンピューターの簡単操作を通じてユーザーが設定できるようになっています。</span><span class="sxs-lookup"><span data-stu-id="cf006-401">The system enables the user to set the specific colors that should be used for their high contrast settings through the Ease of Access Center.</span></span> <span data-ttu-id="cf006-402">これらの色の選択は、特別な名前付きのリソースに適用されます。</span><span class="sxs-lookup"><span data-stu-id="cf006-402">Those color choices are applied to the specially-named resources.</span></span> <span data-ttu-id="cf006-403">XAML フレームワークでは、システム レベルでの変更の検出時にこれらのブラシを更新する場合にも、同じテーマ変更イベントを使用します。</span><span class="sxs-lookup"><span data-stu-id="cf006-403">The XAML framework uses the same theme changed event to also update these brushes when it detects they’ve changed at the system level.</span></span> <span data-ttu-id="cf006-404">ここで {ThemeResource} マークアップ拡張が使われているのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="cf006-404">This is why the {ThemeResource} markup extension is used here.</span></span>


