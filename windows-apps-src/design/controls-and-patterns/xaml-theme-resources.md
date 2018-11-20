---
author: Jwmsft
Description: Theme resources in XAML are a set of resources that apply different values depending on which system theme is active.
MS-HAID: dev\_ctrl\_layout\_txt.xaml\_theme\_resources
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: XAML テーマ リソース
ms.assetid: 41B87DBF-E7A2-44E9-BEBA-AF6EEBABB81B
label: XAML theme resources
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e576814617204749a37963ac5f2724f290520349
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7418356"
---
# <a name="xaml-theme-resources"></a><span data-ttu-id="b3dc1-103">XAML テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="b3dc1-103">XAML theme resources</span></span>

<span data-ttu-id="b3dc1-104">XAML のテーマ リソースは、アクティブなシステム テーマに応じて異なる値を適用するリソースのセットです。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-104">Theme resources in XAML are a set of resources that apply different values depending on which system theme is active.</span></span> <span data-ttu-id="b3dc1-105">XAML フレームワークがサポートするテーマは "Light"、"Dark"、"HighContrast" の 3 つです。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-105">There are 3 themes that the XAML framework supports: "Light", "Dark", and "HighContrast".</span></span>

<span data-ttu-id="b3dc1-106">**前提条件**: このトピックでは、既に「[ResourceDictionary と XAML リソースの参照](resourcedictionary-and-xaml-resource-references.md)」を読んでいることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-106">**Prerequisites**: This topic assumes that you have read [ResourceDictionary and XAML resource references](resourcedictionary-and-xaml-resource-references.md).</span></span>

## <a name="theme-resources-v-static-resources"></a><span data-ttu-id="b3dc1-107">テーマ リソース v</span><span class="sxs-lookup"><span data-stu-id="b3dc1-107">Theme resources v.</span></span> <span data-ttu-id="b3dc1-108">静的なリソース</span><span class="sxs-lookup"><span data-stu-id="b3dc1-108">static resources</span></span>

<span data-ttu-id="b3dc1-109">既存の XAML リソース ディクショナリから XAML リソースを参照できる XAML マークアップ拡張には、[{StaticResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)と [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)の 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-109">There are two XAML markup extensions that can reference a XAML resource from an existing XAML resource dictionary: [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md) and [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md).</span></span>

<span data-ttu-id="b3dc1-110">[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)はアプリの読み込み時に評価され、その後、実行時にテーマが変更されたときにもそのつど評価されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-110">Evaluation of a [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) occurs when the app loads and subsequently each time the theme changes at runtime.</span></span> <span data-ttu-id="b3dc1-111">これは通常、ユーザーがデバイスの設定を変更した場合、またはアプリ内でプログラムによってアプリの現在のテーマが変更された場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-111">This is typically the result of the user changing their device settings or from a programmatic change within the app that alters its current theme.</span></span>

<span data-ttu-id="b3dc1-112">これに対して [{StaticResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)は、XAML が最初にアプリに読み込まれるときにのみ評価されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-112">In contrast, a [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md) is evaluated only when the XAML is first loaded by the app.</span></span> <span data-ttu-id="b3dc1-113">これが更新されることはありません。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-113">It does not update.</span></span> <span data-ttu-id="b3dc1-114">これは、アプリの起動時に XAML を検索し、実際のランタイム値に置き換えるようなものです。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-114">It’s similar to a find and replace in your XAML with the actual runtime value at app launch.</span></span>

## <a name="theme-resources-in-the-resource-dictionary-structure"></a><span data-ttu-id="b3dc1-115">リソース ディクショナリ構造でのテーマ リソース</span><span class="sxs-lookup"><span data-stu-id="b3dc1-115">Theme resources in the resource dictionary structure</span></span>

<span data-ttu-id="b3dc1-116">各テーマ リソースは、XAML ファイル themeresources.xaml の一部です。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-116">Each theme resource is part of the XAML file themeresources.xaml.</span></span> <span data-ttu-id="b3dc1-117">設計の目的には、Windows ソフトウェア開発キット (Windows SDK) のインストール先の \\(Program Files)\\Windows Kits\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\&lt;SDK version&gt;\\Generic フォルダーにある themeresources.xaml を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-117">For design purposes, themeresources.xaml is available in the \\(Program Files)\\Windows Kits\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\&lt;SDK version&gt;\\Generic folder from a Windows Software Development Kit (SDK) installation.</span></span> <span data-ttu-id="b3dc1-118">themeresources.xaml 内のリソース ディクショナリは、同じディレクトリの generic.xaml にも複製されています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-118">The resource dictionaries in themeresources.xaml are also reproduced in generic.xaml in the same directory.</span></span>

<span data-ttu-id="b3dc1-119">これらの物理ファイルは Windows ランタイムでランタイム検索に使われません。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-119">The Windows Runtime doesn't use these physical files for runtime lookup.</span></span> <span data-ttu-id="b3dc1-120">そのため、明示的に DesignTime フォルダー内にあり、既定ではアプリにコピーされません。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-120">That's why they are specifically in a DesignTime folder, and they aren't copied into apps by default.</span></span> <span data-ttu-id="b3dc1-121">代わりに、これらのリソース ディクショナリは Windows ランタイム自体の一部としてメモリ内に存在し、テーマ リソース (またはシステム リソース) へのアプリの XAML リソース参照は実行時にメモリ内で解決されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-121">Instead, these resource dictionaries exist in memory as part of the Windows Runtime itself, and your app's XAML resource references to theme resources (or system resources) resolve there at runtime.</span></span>

## <a name="guidelines-for-custom-theme-resources"></a><span data-ttu-id="b3dc1-122">カスタム テーマ リソースのガイドライン</span><span class="sxs-lookup"><span data-stu-id="b3dc1-122">Guidelines for custom theme resources</span></span>

<span data-ttu-id="b3dc1-123">独自のカスタム テーマ リソースを定義して使うときは、次のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-123">Follow these guidelines when you define and consume your own custom theme resources:</span></span>

- <span data-ttu-id="b3dc1-124">"HighContrast" ディクショナリに加えて、"Light" と "Dark" の両方のテーマ ディクショナリを指定します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-124">Specify theme dictionaries for both "Light" and "Dark" in addition to your "HighContrast" dictionary.</span></span> <span data-ttu-id="b3dc1-125">"Default" をキーとする [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) を作成することもできますが、明示的に "Light"、"Dark"、"HighContrast" を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-125">Although you can create a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) with "Default" as the key, it’s preferred to be explicit and instead use "Light", "Dark", and "HighContrast".</span></span>

- <span data-ttu-id="b3dc1-126">スタイル、セッター、コントロール テンプレート、プロパティ セッター、アニメーションでは、[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-126">Use the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) in: Styles, Setters, Control templates, Property setters, and Animations.</span></span>

- <span data-ttu-id="b3dc1-127">[ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) 内のリソース定義では、[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md) を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-127">Don't use the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) in your resource definitions inside your [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807).</span></span> <span data-ttu-id="b3dc1-128">代わりに、[{StaticResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-128">Use [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md) instead.</span></span>

    <span data-ttu-id="b3dc1-129">例外: [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) 内のアプリ テーマに依存しないリソースを参照するために [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-129">EXCEPTION: You can use the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) to reference resources that are agnostic to the app theme in your [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807).</span></span> <span data-ttu-id="b3dc1-130">このようなリソースの例として、`SystemAccentColor` などのアクセント カラー リソースや、通常は "SystemColor" というプレフィックスの付いた `SystemColorButtonFaceColor` などのシステム カラー リソースがあります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-130">Examples of these resources are accent color resources like `SystemAccentColor`, or system color resources, which are typically prefixed with "SystemColor" like `SystemColorButtonFaceColor`.</span></span>

> [!CAUTION]
> <span data-ttu-id="b3dc1-131">これらのガイドラインに従わないと、テーマに関連する予期しない動作がアプリで発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-131">If you don’t follow these guidelines, you might see unexpected behavior related to themes in your app.</span></span> <span data-ttu-id="b3dc1-132">詳しくは、「[テーマ リソースのトラブルシューティング](#troubleshooting-theme-resources)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-132">For more info, see the [Troubleshooting theme resources](#troubleshooting-theme-resources) section.</span></span>

## <a name="the-xaml-color-ramp-and-theme-dependent-brushes"></a><span data-ttu-id="b3dc1-133">XAML 色見本とテーマ依存のブラシ</span><span class="sxs-lookup"><span data-stu-id="b3dc1-133">The XAML color ramp and theme-dependent brushes</span></span>

<span data-ttu-id="b3dc1-134">XAML における *Windows 色見本*は、"Light"、"Dark"、"HighContrast" の各テーマの色のセットを組み合わせることで構成されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-134">The combined set of colors for "Light", "Dark", and "HighContrast" themes make up the *Windows color ramp* in XAML.</span></span> <span data-ttu-id="b3dc1-135">システム テーマを変更する場合でも、システム テーマを独自の XAML 要素に適用する場合でも、カラー リソースがどのように構成されるかを理解することが重要です。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-135">Whether you want to modify the system themes, or apply a system theme to your own XAML elements, it’s important to understand how the color resources are structured.</span></span>

<span data-ttu-id="b3dc1-136">UWP アプリで色を適用する方法の詳細については、「[UWP アプリでの色使い](../style/color.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-136">For additional information about how to apply color in your UWP app, please see [Color in UWP apps](../style/color.md).</span></span>

### <a name="light-and-dark-theme-colors"></a><span data-ttu-id="b3dc1-137">Light テーマと Dark テーマの色</span><span class="sxs-lookup"><span data-stu-id="b3dc1-137">Light and Dark theme colors</span></span>

<span data-ttu-id="b3dc1-138">XAML フレームワークには、"Light" と "Dark" のテーマに合わせてカスタマイズされた名前付きの [Color](/uwp/api/Windows.UI.Color) リソースのセットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-138">The XAML framework provides a set of named [Color](/uwp/api/Windows.UI.Color) resources with values that are tailored for the "Light" and "Dark" themes.</span></span> <span data-ttu-id="b3dc1-139">これらを参照するために使うキーは、`System[Simple Light/Dark Name]Color` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-139">The keys you use to reference these follow the naming format: `System[Simple Light/Dark Name]Color`.</span></span>

<span data-ttu-id="b3dc1-140">次の表は、XAML フレームワークで提供される "Light" と "Dark" のリソースについて、それぞれのキー、簡易名、色の文字列表現 (\#aarrggbb 形式) の一覧を示しています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-140">This table lists the key, simple name, and string representation of the color (using the \#aarrggbb format) for the "Light" and "Dark" resources provided by the XAML framework.</span></span> <span data-ttu-id="b3dc1-141">キーは、アプリでリソースを参照するときに使われます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-141">The key is used to reference the resource in an app.</span></span> <span data-ttu-id="b3dc1-142">"Light/Dark 簡易名" は、後で説明するブラシの名前付け規則の一部として使われます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-142">The "Simple light/dark name" is used as part of the brush naming convention that we explain later.</span></span>

| <span data-ttu-id="b3dc1-143">キー</span><span class="sxs-lookup"><span data-stu-id="b3dc1-143">Key</span></span>                             | <span data-ttu-id="b3dc1-144">Light/Dark 簡易名</span><span class="sxs-lookup"><span data-stu-id="b3dc1-144">Simple light/dark name</span></span> | <span data-ttu-id="b3dc1-145">Light</span><span class="sxs-lookup"><span data-stu-id="b3dc1-145">Light</span></span>      | <span data-ttu-id="b3dc1-146">Dark</span><span class="sxs-lookup"><span data-stu-id="b3dc1-146">Dark</span></span>       |
|---------------------------------|------------------------|------------|------------|
| <span data-ttu-id="b3dc1-147">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-147">SystemAltHighColor</span></span>              | <span data-ttu-id="b3dc1-148">AltHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-148">AltHigh</span></span>                | <span data-ttu-id="b3dc1-149">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-149">\#FFFFFFFF</span></span> | <span data-ttu-id="b3dc1-150">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-150">\#FF000000</span></span> |
| <span data-ttu-id="b3dc1-151">SystemAltLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-151">SystemAltLowColor</span></span>               | <span data-ttu-id="b3dc1-152">AltLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-152">AltLow</span></span>                 | <span data-ttu-id="b3dc1-153">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-153">\#33FFFFFF</span></span> | <span data-ttu-id="b3dc1-154">\#33000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-154">\#33000000</span></span> |
| <span data-ttu-id="b3dc1-155">SystemAltMediumColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-155">SystemAltMediumColor</span></span>            | <span data-ttu-id="b3dc1-156">AltMedium</span><span class="sxs-lookup"><span data-stu-id="b3dc1-156">AltMedium</span></span>              | <span data-ttu-id="b3dc1-157">\#99FFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-157">\#99FFFFFF</span></span> | <span data-ttu-id="b3dc1-158">\#99000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-158">\#99000000</span></span> |
| <span data-ttu-id="b3dc1-159">SystemAltMediumHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-159">SystemAltMediumHighColor</span></span>        | <span data-ttu-id="b3dc1-160">AltMediumHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-160">AltMediumHigh</span></span>          | <span data-ttu-id="b3dc1-161">\#CCFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-161">\#CCFFFFFF</span></span> | <span data-ttu-id="b3dc1-162">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-162">\#CC000000</span></span> |
| <span data-ttu-id="b3dc1-163">SystemAltMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-163">SystemAltMediumLowColor</span></span>         | <span data-ttu-id="b3dc1-164">AltMediumLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-164">AltMediumLow</span></span>           | <span data-ttu-id="b3dc1-165">\#66FFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-165">\#66FFFFFF</span></span> | <span data-ttu-id="b3dc1-166">\#66000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-166">\#66000000</span></span> |
| <span data-ttu-id="b3dc1-167">SystemBaseHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-167">SystemBaseHighColor</span></span>             | <span data-ttu-id="b3dc1-168">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-168">BaseHigh</span></span>               | <span data-ttu-id="b3dc1-169">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-169">\#FF000000</span></span> | <span data-ttu-id="b3dc1-170">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-170">\#FFFFFFFF</span></span> |
| <span data-ttu-id="b3dc1-171">SystemBaseLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-171">SystemBaseLowColor</span></span>              | <span data-ttu-id="b3dc1-172">BaseLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-172">BaseLow</span></span>                | <span data-ttu-id="b3dc1-173">\#33000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-173">\#33000000</span></span> | <span data-ttu-id="b3dc1-174">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-174">\#33FFFFFF</span></span> |
| <span data-ttu-id="b3dc1-175">SystemBaseMediumColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-175">SystemBaseMediumColor</span></span>           | <span data-ttu-id="b3dc1-176">BaseMedium</span><span class="sxs-lookup"><span data-stu-id="b3dc1-176">BaseMedium</span></span>             | <span data-ttu-id="b3dc1-177">\#99000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-177">\#99000000</span></span> | <span data-ttu-id="b3dc1-178">\#99FFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-178">\#99FFFFFF</span></span> |
| <span data-ttu-id="b3dc1-179">SystemBaseMediumHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-179">SystemBaseMediumHighColor</span></span>       | <span data-ttu-id="b3dc1-180">BaseMediumHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-180">BaseMediumHigh</span></span>         | <span data-ttu-id="b3dc1-181">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-181">\#CC000000</span></span> | <span data-ttu-id="b3dc1-182">\#CCFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-182">\#CCFFFFFF</span></span> |
| <span data-ttu-id="b3dc1-183">SystemBaseMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-183">SystemBaseMediumLowColor</span></span>        | <span data-ttu-id="b3dc1-184">BaseMediumLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-184">BaseMediumLow</span></span>          | <span data-ttu-id="b3dc1-185">\#66000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-185">\#66000000</span></span> | <span data-ttu-id="b3dc1-186">\#66FFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-186">\#66FFFFFF</span></span> |
| <span data-ttu-id="b3dc1-187">SystemChromeAltLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-187">SystemChromeAltLowColor</span></span>         | <span data-ttu-id="b3dc1-188">ChromeAltLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-188">ChromeAltLow</span></span>           | <span data-ttu-id="b3dc1-189">\#FF171717</span><span class="sxs-lookup"><span data-stu-id="b3dc1-189">\#FF171717</span></span> | <span data-ttu-id="b3dc1-190">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="b3dc1-190">\#FFF2F2F2</span></span> |
| <span data-ttu-id="b3dc1-191">SystemChromeBlackHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-191">SystemChromeBlackHighColor</span></span>      | <span data-ttu-id="b3dc1-192">ChromeBlackHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-192">ChromeBlackHigh</span></span>        | <span data-ttu-id="b3dc1-193">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-193">\#FF000000</span></span> | <span data-ttu-id="b3dc1-194">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-194">\#FF000000</span></span> |
| <span data-ttu-id="b3dc1-195">SystemChromeBlackLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-195">SystemChromeBlackLowColor</span></span>       | <span data-ttu-id="b3dc1-196">ChromeBlackLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-196">ChromeBlackLow</span></span>         | <span data-ttu-id="b3dc1-197">\#33000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-197">\#33000000</span></span> | <span data-ttu-id="b3dc1-198">\#33000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-198">\#33000000</span></span> |
| <span data-ttu-id="b3dc1-199">SystemChromeBlackMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-199">SystemChromeBlackMediumLowColor</span></span> | <span data-ttu-id="b3dc1-200">ChromeBlackMediumLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-200">ChromeBlackMediumLow</span></span>   | <span data-ttu-id="b3dc1-201">\#66000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-201">\#66000000</span></span> | <span data-ttu-id="b3dc1-202">\#66000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-202">\#66000000</span></span> |
| <span data-ttu-id="b3dc1-203">SystemChromeBlackMediumColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-203">SystemChromeBlackMediumColor</span></span>    | <span data-ttu-id="b3dc1-204">ChromeBlackMedium</span><span class="sxs-lookup"><span data-stu-id="b3dc1-204">ChromeBlackMedium</span></span>      | <span data-ttu-id="b3dc1-205">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-205">\#CC000000</span></span> | <span data-ttu-id="b3dc1-206">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-206">\#CC000000</span></span> |
| <span data-ttu-id="b3dc1-207">SystemChromeDisabledHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-207">SystemChromeDisabledHighColor</span></span>   | <span data-ttu-id="b3dc1-208">ChromeDisabledHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-208">ChromeDisabledHigh</span></span>     | <span data-ttu-id="b3dc1-209">\#FFCCCCCC</span><span class="sxs-lookup"><span data-stu-id="b3dc1-209">\#FFCCCCCC</span></span> | <span data-ttu-id="b3dc1-210">\#FF333333</span><span class="sxs-lookup"><span data-stu-id="b3dc1-210">\#FF333333</span></span> |
| <span data-ttu-id="b3dc1-211">SystemChromeDisabledLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-211">SystemChromeDisabledLowColor</span></span>    | <span data-ttu-id="b3dc1-212">ChromeDisabledLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-212">ChromeDisabledLow</span></span>      | <span data-ttu-id="b3dc1-213">\#FF7A7A7A</span><span class="sxs-lookup"><span data-stu-id="b3dc1-213">\#FF7A7A7A</span></span> | <span data-ttu-id="b3dc1-214">\#FF858585</span><span class="sxs-lookup"><span data-stu-id="b3dc1-214">\#FF858585</span></span> |
| <span data-ttu-id="b3dc1-215">SystemChromeHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-215">SystemChromeHighColor</span></span>           | <span data-ttu-id="b3dc1-216">ChromeHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-216">ChromeHigh</span></span>             | <span data-ttu-id="b3dc1-217">\#FFCCCCCC</span><span class="sxs-lookup"><span data-stu-id="b3dc1-217">\#FFCCCCCC</span></span> | <span data-ttu-id="b3dc1-218">\#FF767676</span><span class="sxs-lookup"><span data-stu-id="b3dc1-218">\#FF767676</span></span> |
| <span data-ttu-id="b3dc1-219">SystemChromeLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-219">SystemChromeLowColor</span></span>            | <span data-ttu-id="b3dc1-220">ChromeLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-220">ChromeLow</span></span>              | <span data-ttu-id="b3dc1-221">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="b3dc1-221">\#FFF2F2F2</span></span> | <span data-ttu-id="b3dc1-222">\#FF171717</span><span class="sxs-lookup"><span data-stu-id="b3dc1-222">\#FF171717</span></span> |
| <span data-ttu-id="b3dc1-223">SystemChromeMediumColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-223">SystemChromeMediumColor</span></span>         | <span data-ttu-id="b3dc1-224">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="b3dc1-224">ChromeMedium</span></span>           | <span data-ttu-id="b3dc1-225">\#FFE6E6E6</span><span class="sxs-lookup"><span data-stu-id="b3dc1-225">\#FFE6E6E6</span></span> | <span data-ttu-id="b3dc1-226">\#FF1F1F1F</span><span class="sxs-lookup"><span data-stu-id="b3dc1-226">\#FF1F1F1F</span></span> |
| <span data-ttu-id="b3dc1-227">SystemChromeMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-227">SystemChromeMediumLowColor</span></span>      | <span data-ttu-id="b3dc1-228">ChromeMediumLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-228">ChromeMediumLow</span></span>        | <span data-ttu-id="b3dc1-229">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="b3dc1-229">\#FFF2F2F2</span></span> | <span data-ttu-id="b3dc1-230">\#FF2B2B2B</span><span class="sxs-lookup"><span data-stu-id="b3dc1-230">\#FF2B2B2B</span></span> |
| <span data-ttu-id="b3dc1-231">SystemChromeWhiteColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-231">SystemChromeWhiteColor</span></span>          | <span data-ttu-id="b3dc1-232">ChromeWhite</span><span class="sxs-lookup"><span data-stu-id="b3dc1-232">ChromeWhite</span></span>            | <span data-ttu-id="b3dc1-233">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-233">\#FFFFFFFF</span></span> | <span data-ttu-id="b3dc1-234">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-234">\#FFFFFFFF</span></span> |
| <span data-ttu-id="b3dc1-235">SystemListLowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-235">SystemListLowColor</span></span>              | <span data-ttu-id="b3dc1-236">ListLow</span><span class="sxs-lookup"><span data-stu-id="b3dc1-236">ListLow</span></span>                | <span data-ttu-id="b3dc1-237">\#19000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-237">\#19000000</span></span> | <span data-ttu-id="b3dc1-238">\#19FFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-238">\#19FFFFFF</span></span> |
| <span data-ttu-id="b3dc1-239">SystemListMediumColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-239">SystemListMediumColor</span></span>           | <span data-ttu-id="b3dc1-240">ListMedium</span><span class="sxs-lookup"><span data-stu-id="b3dc1-240">ListMedium</span></span>             | <span data-ttu-id="b3dc1-241">\#33000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-241">\#33000000</span></span> | <span data-ttu-id="b3dc1-242">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-242">\#33FFFFFF</span></span> |

:::row:::
    :::column:::
        #### Light theme
    :::column-end:::
    :::column:::
        #### Dark theme
    :::column-end:::
:::row-end:::

#### <a name="base"></a><span data-ttu-id="b3dc1-243">基本</span><span class="sxs-lookup"><span data-stu-id="b3dc1-243">Base</span></span>

:::row:::
    :::column:::
        ![The base light theme](images/themes/light-base.png)
    :::column-end:::
    :::column:::
        ![The base dark theme](images/themes/dark-base.png)
    :::column-end:::
:::row-end:::

#### <a name="alt"></a><span data-ttu-id="b3dc1-244">代替</span><span class="sxs-lookup"><span data-stu-id="b3dc1-244">Alt</span></span>

:::row:::
    :::column:::
        ![The alt light theme](images/themes/light-alt.png)
    :::column-end:::
    :::column:::
        ![The alt dark theme](images/themes/dark-alt.png)
    :::column-end:::
:::row-end:::

#### <a name="list"></a><span data-ttu-id="b3dc1-245">リスト</span><span class="sxs-lookup"><span data-stu-id="b3dc1-245">List</span></span>

:::row:::
    :::column:::
        ![The list light theme](images/themes/light-list.png)
    :::column-end:::
    :::column:::
        ![The list dark theme](images/themes/dark-list.png)
    :::column-end:::
:::row-end:::

#### <a name="chrome"></a><span data-ttu-id="b3dc1-246">クロム</span><span class="sxs-lookup"><span data-stu-id="b3dc1-246">Chrome</span></span>

:::row:::
    :::column:::
        ![The chrome light theme](images/themes/light-chrome.png)
    :::column-end:::
    :::column:::
        ![The chrome dark theme](images/themes/dark-chrome.png)
    :::column-end:::
:::row-end:::

### <a name="windows-system-high-contrast-colors"></a><span data-ttu-id="b3dc1-247">Windows システムのハイ コントラストの色</span><span class="sxs-lookup"><span data-stu-id="b3dc1-247">Windows system high-contrast colors</span></span>

<span data-ttu-id="b3dc1-248">XAML フレームワークによって提供されるリソースのセットのほかに、Windows のシステム パレットから派生するカラー値のセットがあります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-248">In addition to the set of resources provided by the XAML framework, there's a set of color values derived from the Windows system palette.</span></span> <span data-ttu-id="b3dc1-249">これらの色は、Windows ランタイムやユニバーサル Windows プラットフォーム (UWP) アプリに固有のものではありません。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-249">These colors are not specific to the Windows Runtime or Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="b3dc1-250">しかし、"HighContrast" テーマでシステムが動作しているとき (およびアプリが実行されているとき) には、XAML [Brush](/uwp/api/Windows.UI.Xaml.Media.Brush) リソースの多くでこれらの色が使われます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-250">However, many of the XAML [Brush](/uwp/api/Windows.UI.Xaml.Media.Brush) resources consume these colors when the system is operating (and the app is running) using the "HighContrast" theme.</span></span> <span data-ttu-id="b3dc1-251">XAML フレームワークには、このようなシステム全体の色がキーを持つリソースとして用意されています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-251">The XAML framework provides these system-wide colors as keyed resources.</span></span> <span data-ttu-id="b3dc1-252">これらのキーは、`SystemColor[name]Color` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-252">The keys follow the naming format: `SystemColor[name]Color`.</span></span>

<span data-ttu-id="b3dc1-253">次の表は、Windows システム パレットから派生したリソース オブジェクトとして XAML に用意されているシステム全体の色を示します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-253">This table lists the system-wide colors that XAML provides as resource objects derived from the Windows system palette.</span></span> <span data-ttu-id="b3dc1-254">"簡単操作での名前" 列は、その色が Windows の設定の UI でどのように表現されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-254">The "Ease of Access name" column shows how color is labeled in the Windows settings UI.</span></span> <span data-ttu-id="b3dc1-255">"HighContrast 簡易名" 列は、その色が XAML コモン コントロールにどのように適用されるかをひとことで表す単語になっています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-255">The "Simple HighContrast name" column is a one word description of how the color is applied across the XAML common controls.</span></span> <span data-ttu-id="b3dc1-256">これは、後で説明するブラシの名前付け規則の一部として使われます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-256">It's used as part of the brush naming convention that we explain later.</span></span> <span data-ttu-id="b3dc1-257">"初期既定値" 列は、システムがハイ コントラストで動作していない場合に使われる値を示します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-257">The "Initial default" column shows the values you'd get if the system is not running in high contrast at all.</span></span>

| <span data-ttu-id="b3dc1-258">キー</span><span class="sxs-lookup"><span data-stu-id="b3dc1-258">Key</span></span>                           | <span data-ttu-id="b3dc1-259">簡単操作での名前</span><span class="sxs-lookup"><span data-stu-id="b3dc1-259">Ease of Access name</span></span>            | <span data-ttu-id="b3dc1-260">HighContrast 簡易名</span><span class="sxs-lookup"><span data-stu-id="b3dc1-260">Simple HighContrast name</span></span> | <span data-ttu-id="b3dc1-261">初期既定値</span><span class="sxs-lookup"><span data-stu-id="b3dc1-261">Initial default</span></span> |
|-------------------------------|--------------------------------|--------------------------|-----------------|
| <span data-ttu-id="b3dc1-262">SystemColorButtonFaceColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-262">SystemColorButtonFaceColor</span></span>    | <span data-ttu-id="b3dc1-263">**ボタン テキスト** (背景)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-263">**Button Text** (background)</span></span>   | <span data-ttu-id="b3dc1-264">Background</span><span class="sxs-lookup"><span data-stu-id="b3dc1-264">Background</span></span>               | <span data-ttu-id="b3dc1-265">\#FFF0F0F0</span><span class="sxs-lookup"><span data-stu-id="b3dc1-265">\#FFF0F0F0</span></span>      |
| <span data-ttu-id="b3dc1-266">SystemColorButtonTextColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-266">SystemColorButtonTextColor</span></span>    | <span data-ttu-id="b3dc1-267">**ボタン テキスト** (前景)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-267">**Button Text** (foreground)</span></span>   | <span data-ttu-id="b3dc1-268">Foreground</span><span class="sxs-lookup"><span data-stu-id="b3dc1-268">Foreground</span></span>               | <span data-ttu-id="b3dc1-269">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-269">\#FF000000</span></span>      |
| <span data-ttu-id="b3dc1-270">SystemColorGrayTextColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-270">SystemColorGrayTextColor</span></span>      | **<span data-ttu-id="b3dc1-271">淡色表示のテキスト</span><span class="sxs-lookup"><span data-stu-id="b3dc1-271">Disabled Text</span></span>**              | <span data-ttu-id="b3dc1-272">Disabled</span><span class="sxs-lookup"><span data-stu-id="b3dc1-272">Disabled</span></span>                 | <span data-ttu-id="b3dc1-273">\#FF6D6D6D</span><span class="sxs-lookup"><span data-stu-id="b3dc1-273">\#FF6D6D6D</span></span>      |
| <span data-ttu-id="b3dc1-274">SystemColorHighlightColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-274">SystemColorHighlightColor</span></span>     | <span data-ttu-id="b3dc1-275">**選択されたテキスト** (背景)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-275">**Selected Text** (background)</span></span> | <span data-ttu-id="b3dc1-276">Highlight</span><span class="sxs-lookup"><span data-stu-id="b3dc1-276">Highlight</span></span>                | <span data-ttu-id="b3dc1-277">\#FF3399FF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-277">\#FF3399FF</span></span>      |
| <span data-ttu-id="b3dc1-278">SystemColorHighlightTextColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-278">SystemColorHighlightTextColor</span></span> | <span data-ttu-id="b3dc1-279">**選択されたテキスト** (前景)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-279">**Selected Text** (foreground)</span></span> | <span data-ttu-id="b3dc1-280">HighlightAlt</span><span class="sxs-lookup"><span data-stu-id="b3dc1-280">HighlightAlt</span></span>             | <span data-ttu-id="b3dc1-281">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-281">\#FFFFFFFF</span></span>      |
| <span data-ttu-id="b3dc1-282">SystemColorHotlightColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-282">SystemColorHotlightColor</span></span>      | **<span data-ttu-id="b3dc1-283">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="b3dc1-283">Hyperlinks</span></span>**                 | <span data-ttu-id="b3dc1-284">Hyperlink</span><span class="sxs-lookup"><span data-stu-id="b3dc1-284">Hyperlink</span></span>                | <span data-ttu-id="b3dc1-285">\#FF0066CC</span><span class="sxs-lookup"><span data-stu-id="b3dc1-285">\#FF0066CC</span></span>      |
| <span data-ttu-id="b3dc1-286">SystemColorWindowColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-286">SystemColorWindowColor</span></span>        | **<span data-ttu-id="b3dc1-287">背景</span><span class="sxs-lookup"><span data-stu-id="b3dc1-287">Background</span></span>**                 | <span data-ttu-id="b3dc1-288">PageBackground</span><span class="sxs-lookup"><span data-stu-id="b3dc1-288">PageBackground</span></span>           | <span data-ttu-id="b3dc1-289">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-289">\#FFFFFFFF</span></span>      |
| <span data-ttu-id="b3dc1-290">SystemColorWindowTextColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-290">SystemColorWindowTextColor</span></span>    | **<span data-ttu-id="b3dc1-291">テキスト</span><span class="sxs-lookup"><span data-stu-id="b3dc1-291">Text</span></span>**                       | <span data-ttu-id="b3dc1-292">PageText</span><span class="sxs-lookup"><span data-stu-id="b3dc1-292">PageText</span></span>                 | <span data-ttu-id="b3dc1-293">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-293">\#FF000000</span></span>      |

<span data-ttu-id="b3dc1-294">Windows には複数のハイ コントラスト テーマが用意されているほか、次のように、コンピューターの簡単操作を通じて、独自のハイ コントラスト設定で使う特定の色をユーザーが設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-294">Windows provides different high-contrast themes, and enables the user to set the specific colors to for their high-contrast settings through the Ease of Access Center, as shown here.</span></span> <span data-ttu-id="b3dc1-295">このため、ハイ コントラストのカラー値の確定的な一覧を提供することはできません。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-295">Therefore, it's not possible to provide a definitive list of high-contrast color values.</span></span>

![Windows のハイ コントラストの設定 UI](images/high-contrast-settings.png)

<span data-ttu-id="b3dc1-297">ハイ コントラスト テーマのサポートについて詳しくは、「[ハイ コントラスト テーマ](https://msdn.microsoft.com/library/windows/apps/mt244346)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-297">For more info about supporting high-contrast themes, see [High-contrast themes](https://msdn.microsoft.com/library/windows/apps/mt244346).</span></span>

### <a name="system-accent-color"></a><span data-ttu-id="b3dc1-298">システムのアクセント カラー</span><span class="sxs-lookup"><span data-stu-id="b3dc1-298">System accent color</span></span>

<span data-ttu-id="b3dc1-299">システムのハイ コントラスト テーマの色に加えて、システムのアクセント カラーも、`SystemAccentColor` というキーを使う特別なカラー リソースとして用意されています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-299">In addition to the system high-contrast theme colors, the system accent color is provided as a special color resource using the key `SystemAccentColor`.</span></span> <span data-ttu-id="b3dc1-300">このリソースは、ユーザーが Windows の個人設定でアクセント カラーとして指定した色を実行時に取得します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-300">At runtime, this resource gets the color that the user has specified as the accent color in the Windows personalization settings.</span></span>

> [!NOTE]
> <span data-ttu-id="b3dc1-301">システム カラー リソースをオーバーライドすることもできますが、特にハイ コントラスト設定については、ユーザーによる色の選択を尊重することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-301">While it’s possible to override the system color resources, it’s a best practice to respect the user’s color choices, especially for high-contrast settings.</span></span>

### <a name="theme-dependent-brushes"></a><span data-ttu-id="b3dc1-302">テーマ依存のブラシ</span><span class="sxs-lookup"><span data-stu-id="b3dc1-302">Theme-dependent brushes</span></span>

<span data-ttu-id="b3dc1-303">システム テーマ リソース ディクショナリの [SolidColorBrush](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush) リソースの [Color](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush.Color) プロパティは、前のセクションに示したカラー リソースを使って設定されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-303">The color resources shown in the preceding sections are used to set the [Color](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush.Color) property of [SolidColorBrush](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush) resources in the system theme resource dictionaries.</span></span> <span data-ttu-id="b3dc1-304">XAML 要素に色を適用するには、ブラシ リソースが使われます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-304">You use the brush resources to apply the color to XAML elements.</span></span> <span data-ttu-id="b3dc1-305">ブラシ リソースのキーは、`SystemControl[Simple HighContrast name][Simple light/dark name]Brush` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-305">The keys for the brush resources follow the naming format: `SystemControl[Simple HighContrast name][Simple light/dark name]Brush`.</span></span> <span data-ttu-id="b3dc1-306">たとえば、`SystemControlBackroundAltHighBrush` と記述します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-306">For example, `SystemControlBackroundAltHighBrush`.</span></span>

<span data-ttu-id="b3dc1-307">このブラシの色の値が実行時にどのように決定されるかを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-307">Let’s look at how the color value for this brush is determined at run-time.</span></span> <span data-ttu-id="b3dc1-308">"Light" と "Dark" の各リソース ディクショナリでは、このブラシは次のように定義されています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-308">In the "Light" and "Dark" resource dictionaries, this brush is defined like this:</span></span>

`<SolidColorBrush x:Key="SystemControlBackgroundAltHighBrush" Color="{StaticResource SystemAltHighColor}"/>`

<span data-ttu-id="b3dc1-309">"HighContrast" リソース ディクショナリでは、このブラシは次のように定義されています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-309">In the "HighContrast" resource dictionary, this brush is defined like this:</span></span>

`<SolidColorBrush x:Key="SystemControlBackgroundAltHighBrush" Color="{ThemeResource SystemColorButtonFaceColor}"/>`

<span data-ttu-id="b3dc1-310">このブラシが XAML 要素に適用されるとき、その色は、次の表に示すように現在のテーマによって実行時に決定されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-310">When this brush is applied to a XAML element, its color is determined at run-time by the current theme, as shown in this table.</span></span>

| <span data-ttu-id="b3dc1-311">テーマ</span><span class="sxs-lookup"><span data-stu-id="b3dc1-311">Theme</span></span>        | <span data-ttu-id="b3dc1-312">色の簡易名</span><span class="sxs-lookup"><span data-stu-id="b3dc1-312">Color simple name</span></span> | <span data-ttu-id="b3dc1-313">カラー リソース</span><span class="sxs-lookup"><span data-stu-id="b3dc1-313">Color resource</span></span>             | <span data-ttu-id="b3dc1-314">ランタイム値</span><span class="sxs-lookup"><span data-stu-id="b3dc1-314">Runtime value</span></span>                                              |
|--------------|-------------------|----------------------------|------------------------------------------------------------|
| <span data-ttu-id="b3dc1-315">Light</span><span class="sxs-lookup"><span data-stu-id="b3dc1-315">Light</span></span>        | <span data-ttu-id="b3dc1-316">AltHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-316">AltHigh</span></span>           | <span data-ttu-id="b3dc1-317">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-317">SystemAltHighColor</span></span>         | <span data-ttu-id="b3dc1-318">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="b3dc1-318">\#FFFFFFFF</span></span>                                                 |
| <span data-ttu-id="b3dc1-319">Dark</span><span class="sxs-lookup"><span data-stu-id="b3dc1-319">Dark</span></span>         | <span data-ttu-id="b3dc1-320">AltHigh</span><span class="sxs-lookup"><span data-stu-id="b3dc1-320">AltHigh</span></span>           | <span data-ttu-id="b3dc1-321">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-321">SystemAltHighColor</span></span>         | <span data-ttu-id="b3dc1-322">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="b3dc1-322">\#FF000000</span></span>                                                 |
| <span data-ttu-id="b3dc1-323">HighContrast</span><span class="sxs-lookup"><span data-stu-id="b3dc1-323">HighContrast</span></span> | <span data-ttu-id="b3dc1-324">Background</span><span class="sxs-lookup"><span data-stu-id="b3dc1-324">Background</span></span>        | <span data-ttu-id="b3dc1-325">SystemColorButtonFaceColor</span><span class="sxs-lookup"><span data-stu-id="b3dc1-325">SystemColorButtonFaceColor</span></span> | <span data-ttu-id="b3dc1-326">設定でボタンの背景として指定された色。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-326">The color specified in settings for the button background.</span></span> |

<span data-ttu-id="b3dc1-327">独自の XAML 要素に適用するブラシを決めるには、`SystemControl[Simple HighContrast name][Simple light/dark name]Brush` という名前付けスキームを使います。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-327">You can use the `SystemControl[Simple HighContrast name][Simple light/dark name]Brush` naming scheme to determine which brush to apply to your own XAML elements.</span></span>

<!--
For many examples of how the brushes are used in the XAML control templates, see the [Default control styles and templates](default-control-styles-and-templates.md).
-->

> [!NOTE]
> <span data-ttu-id="b3dc1-328">\[*HighContrast 簡易名*\]\[*Light/Dark 簡易名*\] のすべての組み合わせがブラシ リソースとして提供されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-328">Not every combination of \[*Simple HighContrast name*\]\[*Simple light/dark name*\] is provided as a brush resource.</span></span>

## <a name="the-xaml-type-ramp"></a><span data-ttu-id="b3dc1-329">XAML の書体見本</span><span class="sxs-lookup"><span data-stu-id="b3dc1-329">The XAML type ramp</span></span>

<span data-ttu-id="b3dc1-330">themeresources.xaml ファイルには、UI 上のテキスト コンテナー (具体的には [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) または [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)) に適用できる [Style](https://msdn.microsoft.com/library/windows/apps/br208849) を定義するリソースがいくつか定義されています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-330">The themeresources.xaml file defines several resources that define a [Style](https://msdn.microsoft.com/library/windows/apps/br208849) that you can apply to text containers in your UI, specifically for either [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) or [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565).</span></span> <span data-ttu-id="b3dc1-331">これらは、既定の暗黙的なスタイルとは異なります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-331">These are not the default implicit styles.</span></span> <span data-ttu-id="b3dc1-332">これらのスタイルを使うと、「[フォントのガイドライン](../style/typography.md)」で説明されている *Windows の書体見本*に一致する XAML UI 定義を簡単に作成できるようになります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-332">They are provided to make it easier for you to create XAML UI definitions that match the *Windows type ramp* documented in [Guidelines for fonts](../style/typography.md).</span></span>

<span data-ttu-id="b3dc1-333">これらのスタイルは、テキスト コンテナー全体に適用されるテキスト属性を設定するものです。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-333">These styles are for text attributes that you want applied to the whole text container.</span></span> <span data-ttu-id="b3dc1-334">テキストの一部にのみスタイルを適用する場合は、コンテナー内のテキスト要素に属性を設定します。たとえば、[TextBlock.Inlines](https://msdn.microsoft.com/library/windows/apps/br209668) の [Run](https://msdn.microsoft.com/library/windows/apps/br209959) や [RichTextBlock.Blocks](https://msdn.microsoft.com/library/windows/apps/br244347) の [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-334">If you want styles applied just to sections of the text, set attributes on the text elements within the container, such as on a [Run](https://msdn.microsoft.com/library/windows/apps/br209959) in [TextBlock.Inlines](https://msdn.microsoft.com/library/windows/apps/br209668) or on a [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) in [RichTextBlock.Blocks](https://msdn.microsoft.com/library/windows/apps/br244347).</span></span>

<span data-ttu-id="b3dc1-335">スタイルを [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) に適用すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-335">The styles look like this when applied to a [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652):</span></span>

![テキスト ブロック スタイル](../style/images/type/text-block-type-ramp.svg)

```XAML
<TextBlock Text="Header" Style="{StaticResource HeaderTextBlockStyle}"/>
<TextBlock Text="SubHeader" Style="{StaticResource SubheaderTextBlockStyle}"/>
<TextBlock Text="Title" Style="{StaticResource TitleTextBlockStyle}"/>
<TextBlock Text="SubTitle" Style="{StaticResource SubtitleTextBlockStyle}"/>
<TextBlock Text="Base" Style="{StaticResource BaseTextBlockStyle}"/>
<TextBlock Text="Body" Style="{StaticResource BodyTextBlockStyle}"/>
<TextBlock Text="Caption" Style="{StaticResource CaptionTextBlockStyle}"/>
```

<span data-ttu-id="b3dc1-337">アプリで UWP 書体見本を使用する方法のガイダンスについては、「[UWP アプリの文字体裁](../style/typography.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-337">For guidance on how to use the UWP type ramp in your app, see [Typography in UWP apps](../style/typography.md).</span></span>

### <a name="basetextblockstyle"></a><span data-ttu-id="b3dc1-338">BaseTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-338">BaseTextBlockStyle</span></span>

<span data-ttu-id="b3dc1-339">**TargetType**: [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-339">**TargetType**: [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)</span></span>

<span data-ttu-id="b3dc1-340">他のすべての [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) コンテナー スタイルに対する一般的なプロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-340">Supplies the common properties for all the other [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) container styles.</span></span>

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

### <a name="headertextblockstyle"></a><span data-ttu-id="b3dc1-341">HeaderTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-341">HeaderTextBlockStyle</span></span>

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

### <a name="subheadertextblockstyle"></a><span data-ttu-id="b3dc1-342">SubheaderTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-342">SubheaderTextBlockStyle</span></span>

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

### <a name="titletextblockstyle"></a><span data-ttu-id="b3dc1-343">TitleTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-343">TitleTextBlockStyle</span></span>

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

### <a name="subtitletextblockstyle"></a><span data-ttu-id="b3dc1-344">SubtitleTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-344">SubtitleTextBlockStyle</span></span>

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

### <a name="bodytextblockstyle"></a><span data-ttu-id="b3dc1-345">BodyTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-345">BodyTextBlockStyle</span></span>

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

### <a name="captiontextblockstyle"></a><span data-ttu-id="b3dc1-346">CaptionTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-346">CaptionTextBlockStyle</span></span>

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

### <a name="baserichtextblockstyle"></a><span data-ttu-id="b3dc1-347">BaseRichTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-347">BaseRichTextBlockStyle</span></span>

<span data-ttu-id="b3dc1-348">**TargetType**: [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-348">**TargetType**: [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)</span></span>

<span data-ttu-id="b3dc1-349">他のすべての [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) コンテナー スタイルに対する一般的なプロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-349">Supplies the common properties for all the other [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) container styles.</span></span>

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

### <a name="bodyrichtextblockstyle"></a><span data-ttu-id="b3dc1-350">BodyRichTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-350">BodyRichTextBlockStyle</span></span>

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

<span data-ttu-id="b3dc1-351">**注**: **RichTextBlock**のブロック ベースのドキュメント オブジェクト モデルでは、簡単に個々 のテキストで属性を設定するために主に、 [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)スタイルは[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)は、すべてのテキスト見本スタイルがないです。要素です。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-351">**Note**:The [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) styles don't have all the text ramp styles that [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) does, mainly because the block-based document object model for **RichTextBlock** makes it easier to set attributes on the individual text elements.</span></span> <span data-ttu-id="b3dc1-352">また、XAML コンテンツ プロパティを使って [TextBlock.Text](https://msdn.microsoft.com/library/windows/apps/br209676) を設定する方式では、スタイルを設定できるテキスト要素が存在しない状況になるため、コンテナーにスタイルを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-352">Also, setting [TextBlock.Text](https://msdn.microsoft.com/library/windows/apps/br209676) using the XAML content property introduces a situation where there is no text element to style and thus you'd have to style the container.</span></span> <span data-ttu-id="b3dc1-353">これに対して **RichTextBlock** では、テキスト コンテンツは常に [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) などの固有のテキスト要素になり、そこにページ ヘッダーやページ サブヘッダー、類似のテキスト見本定義の XAML スタイルを適用できるため、この問題はありません。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-353">That isn't an issue for **RichTextBlock** because its text content always has to be in specific text elements like [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503), which is where you might apply XAML styles for page header, page subheader and similar text ramp definitions.</span></span>

## <a name="miscellaneous-named-styles"></a><span data-ttu-id="b3dc1-354">その他の名前付きスタイル</span><span class="sxs-lookup"><span data-stu-id="b3dc1-354">Miscellaneous Named styles</span></span>

<span data-ttu-id="b3dc1-355">[Button](https://msdn.microsoft.com/library/windows/apps/br209265) には、キーを持つ [Style](https://msdn.microsoft.com/library/windows/apps/br208849) 定義の追加のセットを適用することもできます。これにより、既定の暗黙的なスタイルとは異なるスタイルを設定できます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-355">There's an additional set of keyed [Style](https://msdn.microsoft.com/library/windows/apps/br208849) definitions you can apply to style a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) differently than its default implicit style.</span></span>

### <a name="textblockbuttonstyle"></a><span data-ttu-id="b3dc1-356">TextBlockButtonStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-356">TextBlockButtonStyle</span></span>

<span data-ttu-id="b3dc1-357">**TargetType**: [ButtonBase](https://msdn.microsoft.com/library/windows/apps/br227736)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-357">**TargetType**: [ButtonBase](https://msdn.microsoft.com/library/windows/apps/br227736)</span></span>

<span data-ttu-id="b3dc1-358">ユーザーがクリックしてアクションを実行できるテキストを表示する必要がある場合は、このスタイルを [Button](https://msdn.microsoft.com/library/windows/apps/br209265) に適用します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-358">Apply this style to a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) when you need to show text that a user can click to take action.</span></span> <span data-ttu-id="b3dc1-359">このテキストには、対話型であることがわかるように現在のアクセント カラーを使ったスタイルが設定され、テキストに適したフォーカス四角形が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-359">The text is styled using the current accent color to distinguish it as interactive and has focus rectangles that work well for text.</span></span> <span data-ttu-id="b3dc1-360">[HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/br242739) の暗黙的なスタイルとは異なり、**TextBlockButtonStyle** のテキストには下線は付きません。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-360">Unlike the implicit style of a [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/br242739), the **TextBlockButtonStyle** does not underline the text.</span></span>

<span data-ttu-id="b3dc1-361">このテンプレートは、表示テキストにもスタイルを設定して、**SystemControlHyperlinkBaseMediumBrush** ("PointerOver" 状態の場合)、**SystemControlHighlightBaseMediumLowBrush** ("Pressed" 状態の場合)、**SystemControlDisabledBaseLowBrush** ("Disabled" 状態の場合) が使われるようにします。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-361">The template also styles the presented text to use **SystemControlHyperlinkBaseMediumBrush** (for "PointerOver" state), **SystemControlHighlightBaseMediumLowBrush** (for "Pressed" state) and **SystemControlDisabledBaseLowBrush** (for "Disabled" state).</span></span>

<span data-ttu-id="b3dc1-362">**TextBlockButtonStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-362">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **TextBlockButtonStyle** resource applied to it.</span></span>

```XAML
<Button Content="Clickable text" Style="{StaticResource TextBlockButtonStyle}"
        Click="Button_Click"/>
```

<span data-ttu-id="b3dc1-363">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-363">It looks like this:</span></span>

![テキストのような外観にスタイル設定されたボタン](images/styles-textblock-button-style.png)

### <a name="navigationbackbuttonnormalstyle"></a><span data-ttu-id="b3dc1-365">NavigationBackButtonNormalStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-365">NavigationBackButtonNormalStyle</span></span>

<span data-ttu-id="b3dc1-366">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-366">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span></span>

<span data-ttu-id="b3dc1-367">この [Style](https://msdn.microsoft.com/library/windows/apps/br208849) は、ナビゲーション アプリの戻るボタンとして使うことができる [Button](https://msdn.microsoft.com/library/windows/apps/br209265) 用の完全なテンプレートを提供します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-367">This [Style](https://msdn.microsoft.com/library/windows/apps/br208849) provides a complete template for a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) that can be the navigation back button for a navigation app.</span></span> <span data-ttu-id="b3dc1-368">既定の寸法は 40 x 40 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-368">The default dimensions are 40 x 40 pixels.</span></span> <span data-ttu-id="b3dc1-369">スタイルを調整するには、**Button** の [Height](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height)、[Width](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width)、[FontSize](https://msdn.microsoft.com/library/windows/apps/br209406)、その他のプロパティを明示的に設定するか、[BasedOn](https://msdn.microsoft.com/library/windows/apps/br208852) を使って派生スタイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-369">To tailor the styling you can either explicitly set the [Height](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height), [Width](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width), [FontSize](https://msdn.microsoft.com/library/windows/apps/br209406), and other properties on your **Button** or create a derived style using [BasedOn](https://msdn.microsoft.com/library/windows/apps/br208852).</span></span>

<span data-ttu-id="b3dc1-370">**NavigationBackButtonNormalStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-370">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **NavigationBackButtonNormalStyle** resource applied to it.</span></span>

```XAML
<Button Style="{StaticResource NavigationBackButtonNormalStyle}" />
```

<span data-ttu-id="b3dc1-371">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-371">It looks like this:</span></span>

!["戻る" ボタンとしてスタイル設定されたボタン](images/styles-back-button-normal.png)

### <a name="navigationbackbuttonsmallstyle"></a><span data-ttu-id="b3dc1-373">NavigationBackButtonSmallStyle</span><span class="sxs-lookup"><span data-stu-id="b3dc1-373">NavigationBackButtonSmallStyle</span></span>

<span data-ttu-id="b3dc1-374">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span><span class="sxs-lookup"><span data-stu-id="b3dc1-374">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span></span>

<span data-ttu-id="b3dc1-375">この [Style](https://msdn.microsoft.com/library/windows/apps/br208849) は、ナビゲーション アプリの戻るボタンとして使うことができる [Button](https://msdn.microsoft.com/library/windows/apps/br209265) 用の完全なテンプレートを提供します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-375">This [Style](https://msdn.microsoft.com/library/windows/apps/br208849) provides a complete template for a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) that can be the navigation back button for a navigation app.</span></span> <span data-ttu-id="b3dc1-376">**NavigationBackButtonNormalStyle** と同様ですが、寸法は 30 x 30 ピクセルになります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-376">It's similar to **NavigationBackButtonNormalStyle**, but its dimensions are 30 x 30 pixels.</span></span>

<span data-ttu-id="b3dc1-377">**NavigationBackButtonSmallStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-377">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **NavigationBackButtonSmallStyle** resource applied to it.</span></span>

```XAML
<Button Style="{StaticResource NavigationBackButtonSmallStyle}" />
```

## <a name="troubleshooting-theme-resources"></a><span data-ttu-id="b3dc1-378">テーマ リソースのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="b3dc1-378">Troubleshooting theme resources</span></span>

<span data-ttu-id="b3dc1-379">[テーマ リソースの使用に関するガイドライン](#guidelines-for-using-theme-resources)に従わないと、テーマに関連する予期しない動作がアプリで発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-379">If you don’t follow the [guidelines for using theme resources](#guidelines-for-using-theme-resources), you might see unexpected behavior related to themes in your app.</span></span>

<span data-ttu-id="b3dc1-380">たとえば、淡色テーマのポップアップを開いたときに、濃色テーマのアプリの部分まで淡色テーマのように変更される場合があります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-380">For example, when you open a light-themed flyout, parts of your dark-themed app also change as if they were in the light theme.</span></span> <span data-ttu-id="b3dc1-381">または、淡色テーマのページに移動してから戻ってくると、元の濃色テーマのページ (またはその部分) が淡色テーマのように表示される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-381">Or if you navigate to a light-themed page and then navigate back, the original dark-themed page (or parts of it) now looks as though it is in the light theme.</span></span>

<span data-ttu-id="b3dc1-382">このような問題は、通常、"Default" テーマと "HighContrast" テーマを用意してハイ コントラスト シナリオをサポートした状態で、"Light" と "Dark" の両方のテーマをアプリ内の別々の部分で使っている場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-382">Typically, these types of issues occur when you provide a "Default" theme and a "HighContrast" theme to support high-contrast scenarios, and then use both "Light" and "Dark" themes in different parts of your app.</span></span>

<span data-ttu-id="b3dc1-383">たとえば、次のテーマ ディクショナリの定義について考えてみます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-383">For example, consider this theme dictionary definition:</span></span>

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

<span data-ttu-id="b3dc1-384">直感的には、これは正しく見えます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-384">Intuitively, this looks correct.</span></span> <span data-ttu-id="b3dc1-385">ハイ コントラストのときは `myBrush` が指す色を変更しますが、ハイ コントラストでない場合は、[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を利用することで `myBrush` がテーマに適した色を指すようにしています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-385">You want to change the color pointed to by `myBrush` when in high-contrast, but when not in high-contrast, you rely on the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) to make sure that `myBrush` points to the right color for your theme.</span></span> <span data-ttu-id="b3dc1-386">これは通常、アプリのビジュアル ツリー内に [FrameworkElement.RequestedTheme](https://msdn.microsoft.com/library/windows/apps/dn298515) が設定された要素がなければ期待どおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-386">If your app never has [FrameworkElement.RequestedTheme](https://msdn.microsoft.com/library/windows/apps/dn298515) set on elements within its visual tree, this will typically work as expected.</span></span> <span data-ttu-id="b3dc1-387">しかし、ビジュアル ツリーの各部分にテーマを再設定し始めたとたんに、アプリで問題が発生することになります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-387">However, you run into problems in your app as soon as you start to re-theme different parts of your visual tree.</span></span>

<span data-ttu-id="b3dc1-388">問題が発生する原因は、他のほとんどの XAML 型とは異なり、ブラシが共有リソースであるためです。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-388">The problem occurs because brushes are shared resources, unlike most other XAML types.</span></span> <span data-ttu-id="b3dc1-389">XAML サブツリーに 2 つの要素があり、同じブラシ リソースを参照する別々のテーマが設定されている場合、フレームワークが各サブツリーを走査してそれぞれの [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)表現を更新していくと、それにつれて共有ブラシ リソースに対する変更が他のサブツリーに反映されます。これは意図した結果とは異なります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-389">If you have 2 elements in XAML sub-trees with different themes that reference the same brush resource, then as the framework walks each sub-tree to update its [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) expressions, changes to the shared brush resource are reflected in the other sub-tree, which is not your intended result.</span></span>

<span data-ttu-id="b3dc1-390">これを修正するには、"Default" ディクショナリを置き換えて、"HighContrast" に加えて "Light" テーマと "Dark" テーマのディクショナリも個別に指定します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-390">To fix this, replace the "Default" dictionary with separate theme dictionaries for both "Light" and "Dark" themes in addition to "HighContrast":</span></span>

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

<span data-ttu-id="b3dc1-391">ただし、これらのリソースのいずれかが [Foreground](https://msdn.microsoft.com/library/windows/apps/br209414) などの継承されたプロパティで参照されていると、引き続き問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-391">However, problems still occur if any of these resources are referenced in inherited properties like [Foreground](https://msdn.microsoft.com/library/windows/apps/br209414).</span></span> <span data-ttu-id="b3dc1-392">カスタム コントロール テンプレートでは、[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を使って要素の前景色を指定している場合がありますが、継承された値がフレームワークによって子要素に伝達されるときは、{ThemeResource} マークアップ拡張表現で解決されたリソースへの直接参照が提供されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-392">Your custom control template might specify the foreground color of an element using the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md), but when the framework propagates the inherited value to child elements, it provides a direct reference to the resource that was resolved by the {ThemeResource} markup extension expression.</span></span> <span data-ttu-id="b3dc1-393">フレームワークがコントロールのビジュアル ツリーを走査する過程でテーマの変更が処理されると、問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-393">This causes problems when the framework processes theme changes as it walks your control's visual tree.</span></span> <span data-ttu-id="b3dc1-394">フレームワークは {ThemeResource} マークアップ拡張表現を再評価して新しいブラシ リソースを取得しますが、この参照はまだコントロールの子に伝達されません。子への伝達は、次回の測定パスの間など、後で行われます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-394">It re-evaluates the {ThemeResource} markup extension expression to get a new brush resource but doesn’t yet propagate this reference down to the children of your control; this happens later, such as during the next measure pass.</span></span>

<span data-ttu-id="b3dc1-395">結果として、テーマの変更に応答してコントロールのビジュアル ツリーを走査した後、フレームワークは子を走査し、それぞれに設定されている [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)表現、または子のプロパティに設定されているオブジェクト上の表現をすべて更新します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-395">As a result, after walking the control visual tree in response to a theme change, the framework walks the children and updates any [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) expressions set on them, or on objects set on their properties.</span></span> <span data-ttu-id="b3dc1-396">ここで問題が発生します。フレームワークがブラシ リソースを走査すると、その色は {ThemeResource} マークアップ拡張を使って指定されているため、ブラシ リソースが再評価されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-396">This is where the problem occurs; the framework walks the brush resource and because it specifies its color using a {ThemeResource} markup extension, it's re-evaluated.</span></span>

<span data-ttu-id="b3dc1-397">この時点で、あるディクショナリのリソースに別のディクショナリから設定された色が適用され、フレームワークがテーマ ディクショナリを汚染した形になります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-397">At this point, the framework appears to have polluted your theme dictionary because it now has a resource from one dictionary that has its color set from another dictionary.</span></span>

<span data-ttu-id="b3dc1-398">この問題を解決するには、[{ThemeResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)の代わりに [{StaticResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-398">To fix this problem, use the [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md) instead of [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md).</span></span> <span data-ttu-id="b3dc1-399">ガイドラインを適用したテーマ ディクショナリは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-399">With the guidelines applied, the theme dictionaries look like this:</span></span>

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

<span data-ttu-id="b3dc1-400">"HighContrast" ディクショナリでは、[{StaticResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)ではなく [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)が引き続き使われていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-400">Notice that the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) is still used in the "HighContrast" dictionary instead of [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md).</span></span> <span data-ttu-id="b3dc1-401">この状況は、ガイドラインで既に説明した例外に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-401">This situation falls under the exception given earlier in the guidelines.</span></span> <span data-ttu-id="b3dc1-402">"HighContrast" テーマに使われるブラシの値のほとんどは、システムによって全体的に制御される色から選択されますが、これらは特別な名前付きのリソース (名前に 'SystemColor' というプレフィックスが付いているもの) として XAML に公開されています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-402">Most of the brush values that are used for the "HighContrast" theme are using color choices that are globally controlled by the system, but exposed to XAML as a specially-named resource (those prefixed with ‘SystemColor’ in the name).</span></span> <span data-ttu-id="b3dc1-403">ハイ コントラスト設定で使う特定の色は、コンピューターの簡単操作を通じてユーザーが設定できるようになっています。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-403">The system enables the user to set the specific colors that should be used for their high contrast settings through the Ease of Access Center.</span></span> <span data-ttu-id="b3dc1-404">これらの色の選択は、特別な名前付きのリソースに適用されます。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-404">Those color choices are applied to the specially-named resources.</span></span> <span data-ttu-id="b3dc1-405">XAML フレームワークでは、システム レベルでの変更の検出時にこれらのブラシを更新する場合にも、同じテーマ変更イベントを使用します。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-405">The XAML framework uses the same theme changed event to also update these brushes when it detects they’ve changed at the system level.</span></span> <span data-ttu-id="b3dc1-406">ここで {ThemeResource} マークアップ拡張が使われているのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="b3dc1-406">This is why the {ThemeResource} markup extension is used here.</span></span>