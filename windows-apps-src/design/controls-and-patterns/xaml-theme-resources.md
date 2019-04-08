---
Description: XAML のテーマ リソースは、アクティブなシステム テーマに応じて異なる値を適用するリソースのセットです。
MS-HAID: dev\_ctrl\_layout\_txt.xaml\_theme\_resources
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: XAML テーマ リソース
ms.assetid: 41B87DBF-E7A2-44E9-BEBA-AF6EEBABB81B
label: XAML theme resources
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: e65ad1f4dcb5a83eb7336fc8e1eb794b107dcf01
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57634647"
---
# <a name="xaml-theme-resources"></a><span data-ttu-id="e6a7f-104">XAML テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="e6a7f-104">XAML theme resources</span></span>

<span data-ttu-id="e6a7f-105">XAML のテーマ リソースは、アクティブなシステム テーマに応じて異なる値を適用するリソースのセットです。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-105">Theme resources in XAML are a set of resources that apply different values depending on which system theme is active.</span></span> <span data-ttu-id="e6a7f-106">これには、XAML フレームワークをサポートする 3 つのテーマがあります。"Light"、「ダーク」および「ハイコントラスト」。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-106">There are 3 themes that the XAML framework supports: "Light", "Dark", and "HighContrast".</span></span>

<span data-ttu-id="e6a7f-107">**前提条件**:このトピックでは、既に「[ResourceDictionary と XAML リソースの参照](resourcedictionary-and-xaml-resource-references.md)」を読んでいることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-107">**Prerequisites**: This topic assumes that you have read [ResourceDictionary and XAML resource references](resourcedictionary-and-xaml-resource-references.md).</span></span>

## <a name="theme-resources-v-static-resources"></a><span data-ttu-id="e6a7f-108">テーマ リソース v</span><span class="sxs-lookup"><span data-stu-id="e6a7f-108">Theme resources v.</span></span> <span data-ttu-id="e6a7f-109">静的なリソース</span><span class="sxs-lookup"><span data-stu-id="e6a7f-109">static resources</span></span>

<span data-ttu-id="e6a7f-110">既存の XAML リソース ディクショナリから XAML リソースを参照できる XAML マークアップ拡張には、[{StaticResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)と [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)の 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-110">There are two XAML markup extensions that can reference a XAML resource from an existing XAML resource dictionary: [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md) and [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md).</span></span>

<span data-ttu-id="e6a7f-111">[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)はアプリの読み込み時に評価され、その後、実行時にテーマが変更されたときにもそのつど評価されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-111">Evaluation of a [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) occurs when the app loads and subsequently each time the theme changes at runtime.</span></span> <span data-ttu-id="e6a7f-112">これは通常、ユーザーがデバイスの設定を変更した場合、またはアプリ内でプログラムによってアプリの現在のテーマが変更された場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-112">This is typically the result of the user changing their device settings or from a programmatic change within the app that alters its current theme.</span></span>

<span data-ttu-id="e6a7f-113">これに対して [{StaticResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)は、XAML が最初にアプリに読み込まれるときにのみ評価されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-113">In contrast, a [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md) is evaluated only when the XAML is first loaded by the app.</span></span> <span data-ttu-id="e6a7f-114">これが更新されることはありません。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-114">It does not update.</span></span> <span data-ttu-id="e6a7f-115">これは、アプリの起動時に XAML を検索し、実際のランタイム値に置き換えるようなものです。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-115">It’s similar to a find and replace in your XAML with the actual runtime value at app launch.</span></span>

## <a name="theme-resources-in-the-resource-dictionary-structure"></a><span data-ttu-id="e6a7f-116">リソース ディクショナリ構造でのテーマ リソース</span><span class="sxs-lookup"><span data-stu-id="e6a7f-116">Theme resources in the resource dictionary structure</span></span>

<span data-ttu-id="e6a7f-117">各テーマ リソースは、XAML ファイル themeresources.xaml の一部です。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-117">Each theme resource is part of the XAML file themeresources.xaml.</span></span> <span data-ttu-id="e6a7f-118">設計のために、themeresources.xaml が記載されて、 \\(Program Files)\\Windows キット\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\ &lt;SDK バージョン&gt;\\Generic フォルダー、Windows ソフトウェア開発キット (SDK) をインストールからします。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-118">For design purposes, themeresources.xaml is available in the \\(Program Files)\\Windows Kits\\10\\DesignTime\\CommonConfiguration\\Neutral\\UAP\\&lt;SDK version&gt;\\Generic folder from a Windows Software Development Kit (SDK) installation.</span></span> <span data-ttu-id="e6a7f-119">themeresources.xaml 内のリソース ディクショナリは、同じディレクトリの generic.xaml にも複製されています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-119">The resource dictionaries in themeresources.xaml are also reproduced in generic.xaml in the same directory.</span></span>

<span data-ttu-id="e6a7f-120">これらの物理ファイルは Windows ランタイムでランタイム検索に使われません。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-120">The Windows Runtime doesn't use these physical files for runtime lookup.</span></span> <span data-ttu-id="e6a7f-121">そのため、明示的に DesignTime フォルダー内にあり、既定ではアプリにコピーされません。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-121">That's why they are specifically in a DesignTime folder, and they aren't copied into apps by default.</span></span> <span data-ttu-id="e6a7f-122">代わりに、これらのリソース ディクショナリは Windows ランタイム自体の一部としてメモリ内に存在し、テーマ リソース (またはシステム リソース) へのアプリの XAML リソース参照は実行時にメモリ内で解決されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-122">Instead, these resource dictionaries exist in memory as part of the Windows Runtime itself, and your app's XAML resource references to theme resources (or system resources) resolve there at runtime.</span></span>

## <a name="guidelines-for-custom-theme-resources"></a><span data-ttu-id="e6a7f-123">カスタム テーマ リソースのガイドライン</span><span class="sxs-lookup"><span data-stu-id="e6a7f-123">Guidelines for custom theme resources</span></span>

<span data-ttu-id="e6a7f-124">独自のカスタム テーマ リソースを定義して使うときは、次のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-124">Follow these guidelines when you define and consume your own custom theme resources:</span></span>

- <span data-ttu-id="e6a7f-125">"HighContrast" ディクショナリに加えて、"Light" と "Dark" の両方のテーマ ディクショナリを指定します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-125">Specify theme dictionaries for both "Light" and "Dark" in addition to your "HighContrast" dictionary.</span></span> <span data-ttu-id="e6a7f-126">"Default" をキーとする [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) を作成することもできますが、明示的に "Light"、"Dark"、"HighContrast" を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-126">Although you can create a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/br208794) with "Default" as the key, it’s preferred to be explicit and instead use "Light", "Dark", and "HighContrast".</span></span>

- <span data-ttu-id="e6a7f-127">使用して、 [{ThemeResource} マークアップ拡張機能](../../xaml-platform/themeresource-markup-extension.md)で。スタイル、Setter、テンプレート、プロパティ set アクセス操作子、およびアニメーションを制御します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-127">Use the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) in: Styles, Setters, Control templates, Property setters, and Animations.</span></span>

- <span data-ttu-id="e6a7f-128">[ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807) 内のリソース定義では、[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md) を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-128">Don't use the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) in your resource definitions inside your [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807).</span></span> <span data-ttu-id="e6a7f-129">代わりに、[{StaticResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-129">Use [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md) instead.</span></span>

    <span data-ttu-id="e6a7f-130">例外:使用することができます、 [{ThemeResource} マークアップ拡張機能](../../xaml-platform/themeresource-markup-extension.md)はで、テーマをアプリに依存しないリソースの参照を[ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807)します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-130">EXCEPTION: You can use the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) to reference resources that are agnostic to the app theme in your [ThemeDictionaries](https://msdn.microsoft.com/library/windows/apps/br208807).</span></span> <span data-ttu-id="e6a7f-131">このようなリソースの例として、`SystemAccentColor` などのアクセント カラー リソースや、通常は "SystemColor" というプレフィックスの付いた `SystemColorButtonFaceColor` などのシステム カラー リソースがあります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-131">Examples of these resources are accent color resources like `SystemAccentColor`, or system color resources, which are typically prefixed with "SystemColor" like `SystemColorButtonFaceColor`.</span></span>

> [!CAUTION]
> <span data-ttu-id="e6a7f-132">これらのガイドラインに従わないと、テーマに関連する予期しない動作がアプリで発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-132">If you don’t follow these guidelines, you might see unexpected behavior related to themes in your app.</span></span> <span data-ttu-id="e6a7f-133">詳しくは、「[テーマ リソースのトラブルシューティング](#troubleshooting-theme-resources)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-133">For more info, see the [Troubleshooting theme resources](#troubleshooting-theme-resources) section.</span></span>

## <a name="the-xaml-color-ramp-and-theme-dependent-brushes"></a><span data-ttu-id="e6a7f-134">XAML 色見本とテーマ依存のブラシ</span><span class="sxs-lookup"><span data-stu-id="e6a7f-134">The XAML color ramp and theme-dependent brushes</span></span>

<span data-ttu-id="e6a7f-135">XAML における *Windows 色見本*は、"Light"、"Dark"、"HighContrast" の各テーマの色のセットを組み合わせることで構成されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-135">The combined set of colors for "Light", "Dark", and "HighContrast" themes make up the *Windows color ramp* in XAML.</span></span> <span data-ttu-id="e6a7f-136">システム テーマを変更する場合でも、システム テーマを独自の XAML 要素に適用する場合でも、カラー リソースがどのように構成されるかを理解することが重要です。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-136">Whether you want to modify the system themes, or apply a system theme to your own XAML elements, it’s important to understand how the color resources are structured.</span></span>

<span data-ttu-id="e6a7f-137">UWP アプリで色を適用する方法の詳細については、「[UWP アプリでの色使い](../style/color.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-137">For additional information about how to apply color in your UWP app, please see [Color in UWP apps](../style/color.md).</span></span>

### <a name="light-and-dark-theme-colors"></a><span data-ttu-id="e6a7f-138">Light テーマと Dark テーマの色</span><span class="sxs-lookup"><span data-stu-id="e6a7f-138">Light and Dark theme colors</span></span>

<span data-ttu-id="e6a7f-139">XAML フレームワークには、"Light" と "Dark" のテーマに合わせてカスタマイズされた名前付きの [Color](/uwp/api/Windows.UI.Color) リソースのセットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-139">The XAML framework provides a set of named [Color](/uwp/api/Windows.UI.Color) resources with values that are tailored for the "Light" and "Dark" themes.</span></span> <span data-ttu-id="e6a7f-140">これらを参照するために使うキーは、`System[Simple Light/Dark Name]Color` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-140">The keys you use to reference these follow the naming format: `System[Simple Light/Dark Name]Color`.</span></span>

<span data-ttu-id="e6a7f-141">このテーブルには、キー、簡易名、および色の文字列表現が一覧表示されます (を使用して、 \#aarrggbb 書式)、XAML フレームワークによって提供される"Light"と「ダーク」のリソース。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-141">This table lists the key, simple name, and string representation of the color (using the \#aarrggbb format) for the "Light" and "Dark" resources provided by the XAML framework.</span></span> <span data-ttu-id="e6a7f-142">キーは、アプリでリソースを参照するときに使われます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-142">The key is used to reference the resource in an app.</span></span> <span data-ttu-id="e6a7f-143">"Light/Dark 簡易名" は、後で説明するブラシの名前付け規則の一部として使われます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-143">The "Simple light/dark name" is used as part of the brush naming convention that we explain later.</span></span>

| <span data-ttu-id="e6a7f-144">Key</span><span class="sxs-lookup"><span data-stu-id="e6a7f-144">Key</span></span>                             | <span data-ttu-id="e6a7f-145">Light/Dark 簡易名</span><span class="sxs-lookup"><span data-stu-id="e6a7f-145">Simple light/dark name</span></span> | <span data-ttu-id="e6a7f-146">明るい</span><span class="sxs-lookup"><span data-stu-id="e6a7f-146">Light</span></span>      | <span data-ttu-id="e6a7f-147">暗い</span><span class="sxs-lookup"><span data-stu-id="e6a7f-147">Dark</span></span>       |
|---------------------------------|------------------------|------------|------------|
| <span data-ttu-id="e6a7f-148">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-148">SystemAltHighColor</span></span>              | <span data-ttu-id="e6a7f-149">AltHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-149">AltHigh</span></span>                | <span data-ttu-id="e6a7f-150">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-150">\#FFFFFFFF</span></span> | <span data-ttu-id="e6a7f-151">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-151">\#FF000000</span></span> |
| <span data-ttu-id="e6a7f-152">SystemAltLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-152">SystemAltLowColor</span></span>               | <span data-ttu-id="e6a7f-153">AltLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-153">AltLow</span></span>                 | <span data-ttu-id="e6a7f-154">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-154">\#33FFFFFF</span></span> | <span data-ttu-id="e6a7f-155">\#33000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-155">\#33000000</span></span> |
| <span data-ttu-id="e6a7f-156">SystemAltMediumColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-156">SystemAltMediumColor</span></span>            | <span data-ttu-id="e6a7f-157">AltMedium</span><span class="sxs-lookup"><span data-stu-id="e6a7f-157">AltMedium</span></span>              | <span data-ttu-id="e6a7f-158">\#99FFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-158">\#99FFFFFF</span></span> | <span data-ttu-id="e6a7f-159">\#99000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-159">\#99000000</span></span> |
| <span data-ttu-id="e6a7f-160">SystemAltMediumHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-160">SystemAltMediumHighColor</span></span>        | <span data-ttu-id="e6a7f-161">AltMediumHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-161">AltMediumHigh</span></span>          | <span data-ttu-id="e6a7f-162">\#CCFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-162">\#CCFFFFFF</span></span> | <span data-ttu-id="e6a7f-163">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-163">\#CC000000</span></span> |
| <span data-ttu-id="e6a7f-164">SystemAltMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-164">SystemAltMediumLowColor</span></span>         | <span data-ttu-id="e6a7f-165">AltMediumLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-165">AltMediumLow</span></span>           | <span data-ttu-id="e6a7f-166">\#66FFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-166">\#66FFFFFF</span></span> | <span data-ttu-id="e6a7f-167">\#66000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-167">\#66000000</span></span> |
| <span data-ttu-id="e6a7f-168">SystemBaseHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-168">SystemBaseHighColor</span></span>             | <span data-ttu-id="e6a7f-169">BaseHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-169">BaseHigh</span></span>               | <span data-ttu-id="e6a7f-170">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-170">\#FF000000</span></span> | <span data-ttu-id="e6a7f-171">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-171">\#FFFFFFFF</span></span> |
| <span data-ttu-id="e6a7f-172">SystemBaseLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-172">SystemBaseLowColor</span></span>              | <span data-ttu-id="e6a7f-173">BaseLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-173">BaseLow</span></span>                | <span data-ttu-id="e6a7f-174">\#33000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-174">\#33000000</span></span> | <span data-ttu-id="e6a7f-175">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-175">\#33FFFFFF</span></span> |
| <span data-ttu-id="e6a7f-176">SystemBaseMediumColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-176">SystemBaseMediumColor</span></span>           | <span data-ttu-id="e6a7f-177">BaseMedium</span><span class="sxs-lookup"><span data-stu-id="e6a7f-177">BaseMedium</span></span>             | <span data-ttu-id="e6a7f-178">\#99000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-178">\#99000000</span></span> | <span data-ttu-id="e6a7f-179">\#99FFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-179">\#99FFFFFF</span></span> |
| <span data-ttu-id="e6a7f-180">SystemBaseMediumHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-180">SystemBaseMediumHighColor</span></span>       | <span data-ttu-id="e6a7f-181">BaseMediumHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-181">BaseMediumHigh</span></span>         | <span data-ttu-id="e6a7f-182">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-182">\#CC000000</span></span> | <span data-ttu-id="e6a7f-183">\#CCFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-183">\#CCFFFFFF</span></span> |
| <span data-ttu-id="e6a7f-184">SystemBaseMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-184">SystemBaseMediumLowColor</span></span>        | <span data-ttu-id="e6a7f-185">BaseMediumLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-185">BaseMediumLow</span></span>          | <span data-ttu-id="e6a7f-186">\#66000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-186">\#66000000</span></span> | <span data-ttu-id="e6a7f-187">\#66FFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-187">\#66FFFFFF</span></span> |
| <span data-ttu-id="e6a7f-188">SystemChromeAltLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-188">SystemChromeAltLowColor</span></span>         | <span data-ttu-id="e6a7f-189">ChromeAltLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-189">ChromeAltLow</span></span>           | <span data-ttu-id="e6a7f-190">\#FF171717</span><span class="sxs-lookup"><span data-stu-id="e6a7f-190">\#FF171717</span></span> | <span data-ttu-id="e6a7f-191">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="e6a7f-191">\#FFF2F2F2</span></span> |
| <span data-ttu-id="e6a7f-192">SystemChromeBlackHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-192">SystemChromeBlackHighColor</span></span>      | <span data-ttu-id="e6a7f-193">ChromeBlackHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-193">ChromeBlackHigh</span></span>        | <span data-ttu-id="e6a7f-194">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-194">\#FF000000</span></span> | <span data-ttu-id="e6a7f-195">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-195">\#FF000000</span></span> |
| <span data-ttu-id="e6a7f-196">SystemChromeBlackLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-196">SystemChromeBlackLowColor</span></span>       | <span data-ttu-id="e6a7f-197">ChromeBlackLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-197">ChromeBlackLow</span></span>         | <span data-ttu-id="e6a7f-198">\#33000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-198">\#33000000</span></span> | <span data-ttu-id="e6a7f-199">\#33000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-199">\#33000000</span></span> |
| <span data-ttu-id="e6a7f-200">SystemChromeBlackMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-200">SystemChromeBlackMediumLowColor</span></span> | <span data-ttu-id="e6a7f-201">ChromeBlackMediumLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-201">ChromeBlackMediumLow</span></span>   | <span data-ttu-id="e6a7f-202">\#66000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-202">\#66000000</span></span> | <span data-ttu-id="e6a7f-203">\#66000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-203">\#66000000</span></span> |
| <span data-ttu-id="e6a7f-204">SystemChromeBlackMediumColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-204">SystemChromeBlackMediumColor</span></span>    | <span data-ttu-id="e6a7f-205">ChromeBlackMedium</span><span class="sxs-lookup"><span data-stu-id="e6a7f-205">ChromeBlackMedium</span></span>      | <span data-ttu-id="e6a7f-206">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-206">\#CC000000</span></span> | <span data-ttu-id="e6a7f-207">\#CC000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-207">\#CC000000</span></span> |
| <span data-ttu-id="e6a7f-208">SystemChromeDisabledHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-208">SystemChromeDisabledHighColor</span></span>   | <span data-ttu-id="e6a7f-209">ChromeDisabledHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-209">ChromeDisabledHigh</span></span>     | <span data-ttu-id="e6a7f-210">\#FFCCCCCC</span><span class="sxs-lookup"><span data-stu-id="e6a7f-210">\#FFCCCCCC</span></span> | <span data-ttu-id="e6a7f-211">\#FF333333</span><span class="sxs-lookup"><span data-stu-id="e6a7f-211">\#FF333333</span></span> |
| <span data-ttu-id="e6a7f-212">SystemChromeDisabledLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-212">SystemChromeDisabledLowColor</span></span>    | <span data-ttu-id="e6a7f-213">ChromeDisabledLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-213">ChromeDisabledLow</span></span>      | <span data-ttu-id="e6a7f-214">\#FF7A7A7A</span><span class="sxs-lookup"><span data-stu-id="e6a7f-214">\#FF7A7A7A</span></span> | <span data-ttu-id="e6a7f-215">\#FF858585</span><span class="sxs-lookup"><span data-stu-id="e6a7f-215">\#FF858585</span></span> |
| <span data-ttu-id="e6a7f-216">SystemChromeHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-216">SystemChromeHighColor</span></span>           | <span data-ttu-id="e6a7f-217">ChromeHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-217">ChromeHigh</span></span>             | <span data-ttu-id="e6a7f-218">\#FFCCCCCC</span><span class="sxs-lookup"><span data-stu-id="e6a7f-218">\#FFCCCCCC</span></span> | <span data-ttu-id="e6a7f-219">\#FF767676</span><span class="sxs-lookup"><span data-stu-id="e6a7f-219">\#FF767676</span></span> |
| <span data-ttu-id="e6a7f-220">SystemChromeLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-220">SystemChromeLowColor</span></span>            | <span data-ttu-id="e6a7f-221">ChromeLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-221">ChromeLow</span></span>              | <span data-ttu-id="e6a7f-222">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="e6a7f-222">\#FFF2F2F2</span></span> | <span data-ttu-id="e6a7f-223">\#FF171717</span><span class="sxs-lookup"><span data-stu-id="e6a7f-223">\#FF171717</span></span> |
| <span data-ttu-id="e6a7f-224">SystemChromeMediumColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-224">SystemChromeMediumColor</span></span>         | <span data-ttu-id="e6a7f-225">ChromeMedium</span><span class="sxs-lookup"><span data-stu-id="e6a7f-225">ChromeMedium</span></span>           | <span data-ttu-id="e6a7f-226">\#FFE6E6E6</span><span class="sxs-lookup"><span data-stu-id="e6a7f-226">\#FFE6E6E6</span></span> | <span data-ttu-id="e6a7f-227">\#FF1F1F1F</span><span class="sxs-lookup"><span data-stu-id="e6a7f-227">\#FF1F1F1F</span></span> |
| <span data-ttu-id="e6a7f-228">SystemChromeMediumLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-228">SystemChromeMediumLowColor</span></span>      | <span data-ttu-id="e6a7f-229">ChromeMediumLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-229">ChromeMediumLow</span></span>        | <span data-ttu-id="e6a7f-230">\#FFF2F2F2</span><span class="sxs-lookup"><span data-stu-id="e6a7f-230">\#FFF2F2F2</span></span> | <span data-ttu-id="e6a7f-231">\#FF2B2B2B</span><span class="sxs-lookup"><span data-stu-id="e6a7f-231">\#FF2B2B2B</span></span> |
| <span data-ttu-id="e6a7f-232">SystemChromeWhiteColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-232">SystemChromeWhiteColor</span></span>          | <span data-ttu-id="e6a7f-233">ChromeWhite</span><span class="sxs-lookup"><span data-stu-id="e6a7f-233">ChromeWhite</span></span>            | <span data-ttu-id="e6a7f-234">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-234">\#FFFFFFFF</span></span> | <span data-ttu-id="e6a7f-235">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-235">\#FFFFFFFF</span></span> |
| <span data-ttu-id="e6a7f-236">SystemListLowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-236">SystemListLowColor</span></span>              | <span data-ttu-id="e6a7f-237">ListLow</span><span class="sxs-lookup"><span data-stu-id="e6a7f-237">ListLow</span></span>                | <span data-ttu-id="e6a7f-238">\#19000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-238">\#19000000</span></span> | <span data-ttu-id="e6a7f-239">\#19FFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-239">\#19FFFFFF</span></span> |
| <span data-ttu-id="e6a7f-240">SystemListMediumColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-240">SystemListMediumColor</span></span>           | <span data-ttu-id="e6a7f-241">ListMedium</span><span class="sxs-lookup"><span data-stu-id="e6a7f-241">ListMedium</span></span>             | <span data-ttu-id="e6a7f-242">\#33000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-242">\#33000000</span></span> | <span data-ttu-id="e6a7f-243">\#33FFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-243">\#33FFFFFF</span></span> |

:::row:::
    :::column:::
        #### Light theme
    :::column-end:::
    :::column:::
        #### Dark theme
    :::column-end:::
:::row-end:::

#### <a name="base"></a><span data-ttu-id="e6a7f-244">基本</span><span class="sxs-lookup"><span data-stu-id="e6a7f-244">Base</span></span>

:::row:::
    :::column:::
        ![The base light theme](images/themes/light-base.png)
    :::column-end:::
    :::column:::
        ![The base dark theme](images/themes/dark-base.png)
    :::column-end:::
:::row-end:::

#### <a name="alt"></a><span data-ttu-id="e6a7f-245">代替</span><span class="sxs-lookup"><span data-stu-id="e6a7f-245">Alt</span></span>

:::row:::
    :::column:::
        ![The alt light theme](images/themes/light-alt.png)
    :::column-end:::
    :::column:::
        ![The alt dark theme](images/themes/dark-alt.png)
    :::column-end:::
:::row-end:::

#### <a name="list"></a><span data-ttu-id="e6a7f-246">一覧</span><span class="sxs-lookup"><span data-stu-id="e6a7f-246">List</span></span>

:::row:::
    :::column:::
        ![The list light theme](images/themes/light-list.png)
    :::column-end:::
    :::column:::
        ![The list dark theme](images/themes/dark-list.png)
    :::column-end:::
:::row-end:::

#### <a name="chrome"></a><span data-ttu-id="e6a7f-247">クロム</span><span class="sxs-lookup"><span data-stu-id="e6a7f-247">Chrome</span></span>

:::row:::
    :::column:::
        ![The chrome light theme](images/themes/light-chrome.png)
    :::column-end:::
    :::column:::
        ![The chrome dark theme](images/themes/dark-chrome.png)
    :::column-end:::
:::row-end:::

### <a name="windows-system-high-contrast-colors"></a><span data-ttu-id="e6a7f-248">Windows システムのハイ コントラストの色</span><span class="sxs-lookup"><span data-stu-id="e6a7f-248">Windows system high-contrast colors</span></span>

<span data-ttu-id="e6a7f-249">XAML フレームワークによって提供されるリソースのセットのほかに、Windows のシステム パレットから派生するカラー値のセットがあります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-249">In addition to the set of resources provided by the XAML framework, there's a set of color values derived from the Windows system palette.</span></span> <span data-ttu-id="e6a7f-250">これらの色は、Windows ランタイムやユニバーサル Windows プラットフォーム (UWP) アプリに固有のものではありません。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-250">These colors are not specific to the Windows Runtime or Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="e6a7f-251">しかし、"HighContrast" テーマでシステムが動作しているとき (およびアプリが実行されているとき) には、XAML [Brush](/uwp/api/Windows.UI.Xaml.Media.Brush) リソースの多くでこれらの色が使われます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-251">However, many of the XAML [Brush](/uwp/api/Windows.UI.Xaml.Media.Brush) resources consume these colors when the system is operating (and the app is running) using the "HighContrast" theme.</span></span> <span data-ttu-id="e6a7f-252">XAML フレームワークには、このようなシステム全体の色がキーを持つリソースとして用意されています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-252">The XAML framework provides these system-wide colors as keyed resources.</span></span> <span data-ttu-id="e6a7f-253">これらのキーは、`SystemColor[name]Color` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-253">The keys follow the naming format: `SystemColor[name]Color`.</span></span>

<span data-ttu-id="e6a7f-254">次の表は、Windows システム パレットから派生したリソース オブジェクトとして XAML に用意されているシステム全体の色を示します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-254">This table lists the system-wide colors that XAML provides as resource objects derived from the Windows system palette.</span></span> <span data-ttu-id="e6a7f-255">"簡単操作での名前" 列は、その色が Windows の設定の UI でどのように表現されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-255">The "Ease of Access name" column shows how color is labeled in the Windows settings UI.</span></span> <span data-ttu-id="e6a7f-256">"HighContrast 簡易名" 列は、その色が XAML コモン コントロールにどのように適用されるかをひとことで表す単語になっています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-256">The "Simple HighContrast name" column is a one word description of how the color is applied across the XAML common controls.</span></span> <span data-ttu-id="e6a7f-257">これは、後で説明するブラシの名前付け規則の一部として使われます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-257">It's used as part of the brush naming convention that we explain later.</span></span> <span data-ttu-id="e6a7f-258">"初期既定値" 列は、システムがハイ コントラストで動作していない場合に使われる値を示します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-258">The "Initial default" column shows the values you'd get if the system is not running in high contrast at all.</span></span>

| <span data-ttu-id="e6a7f-259">Key</span><span class="sxs-lookup"><span data-stu-id="e6a7f-259">Key</span></span>                           | <span data-ttu-id="e6a7f-260">簡単操作での名前</span><span class="sxs-lookup"><span data-stu-id="e6a7f-260">Ease of Access name</span></span>            | <span data-ttu-id="e6a7f-261">HighContrast 簡易名</span><span class="sxs-lookup"><span data-stu-id="e6a7f-261">Simple HighContrast name</span></span> | <span data-ttu-id="e6a7f-262">初期既定値</span><span class="sxs-lookup"><span data-stu-id="e6a7f-262">Initial default</span></span> |
|-------------------------------|--------------------------------|--------------------------|-----------------|
| <span data-ttu-id="e6a7f-263">SystemColorButtonFaceColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-263">SystemColorButtonFaceColor</span></span>    | <span data-ttu-id="e6a7f-264">**ボタン テキスト** (背景)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-264">**Button Text** (background)</span></span>   | <span data-ttu-id="e6a7f-265">背景</span><span class="sxs-lookup"><span data-stu-id="e6a7f-265">Background</span></span>               | <span data-ttu-id="e6a7f-266">\#FFF0F0F0</span><span class="sxs-lookup"><span data-stu-id="e6a7f-266">\#FFF0F0F0</span></span>      |
| <span data-ttu-id="e6a7f-267">SystemColorButtonTextColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-267">SystemColorButtonTextColor</span></span>    | <span data-ttu-id="e6a7f-268">**ボタン テキスト** (前景)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-268">**Button Text** (foreground)</span></span>   | <span data-ttu-id="e6a7f-269">Foreground</span><span class="sxs-lookup"><span data-stu-id="e6a7f-269">Foreground</span></span>               | <span data-ttu-id="e6a7f-270">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-270">\#FF000000</span></span>      |
| <span data-ttu-id="e6a7f-271">SystemColorGrayTextColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-271">SystemColorGrayTextColor</span></span>      | <span data-ttu-id="e6a7f-272">**無効なテキスト**</span><span class="sxs-lookup"><span data-stu-id="e6a7f-272">**Disabled Text**</span></span>              | <span data-ttu-id="e6a7f-273">Disabled</span><span class="sxs-lookup"><span data-stu-id="e6a7f-273">Disabled</span></span>                 | <span data-ttu-id="e6a7f-274">\#FF6D6D6D</span><span class="sxs-lookup"><span data-stu-id="e6a7f-274">\#FF6D6D6D</span></span>      |
| <span data-ttu-id="e6a7f-275">SystemColorHighlightColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-275">SystemColorHighlightColor</span></span>     | <span data-ttu-id="e6a7f-276">**選択されたテキスト** (背景)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-276">**Selected Text** (background)</span></span> | <span data-ttu-id="e6a7f-277">Highlight</span><span class="sxs-lookup"><span data-stu-id="e6a7f-277">Highlight</span></span>                | <span data-ttu-id="e6a7f-278">\#FF3399FF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-278">\#FF3399FF</span></span>      |
| <span data-ttu-id="e6a7f-279">SystemColorHighlightTextColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-279">SystemColorHighlightTextColor</span></span> | <span data-ttu-id="e6a7f-280">**選択されたテキスト** (前景)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-280">**Selected Text** (foreground)</span></span> | <span data-ttu-id="e6a7f-281">HighlightAlt</span><span class="sxs-lookup"><span data-stu-id="e6a7f-281">HighlightAlt</span></span>             | <span data-ttu-id="e6a7f-282">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-282">\#FFFFFFFF</span></span>      |
| <span data-ttu-id="e6a7f-283">SystemColorHotlightColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-283">SystemColorHotlightColor</span></span>      | <span data-ttu-id="e6a7f-284">**ハイパーリンク**</span><span class="sxs-lookup"><span data-stu-id="e6a7f-284">**Hyperlinks**</span></span>                 | <span data-ttu-id="e6a7f-285">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="e6a7f-285">Hyperlink</span></span>                | <span data-ttu-id="e6a7f-286">\#FF0066CC</span><span class="sxs-lookup"><span data-stu-id="e6a7f-286">\#FF0066CC</span></span>      |
| <span data-ttu-id="e6a7f-287">SystemColorWindowColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-287">SystemColorWindowColor</span></span>        | <span data-ttu-id="e6a7f-288">**バック グラウンド**</span><span class="sxs-lookup"><span data-stu-id="e6a7f-288">**Background**</span></span>                 | <span data-ttu-id="e6a7f-289">PageBackground</span><span class="sxs-lookup"><span data-stu-id="e6a7f-289">PageBackground</span></span>           | <span data-ttu-id="e6a7f-290">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-290">\#FFFFFFFF</span></span>      |
| <span data-ttu-id="e6a7f-291">SystemColorWindowTextColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-291">SystemColorWindowTextColor</span></span>    | <span data-ttu-id="e6a7f-292">**テキスト**</span><span class="sxs-lookup"><span data-stu-id="e6a7f-292">**Text**</span></span>                       | <span data-ttu-id="e6a7f-293">PageText</span><span class="sxs-lookup"><span data-stu-id="e6a7f-293">PageText</span></span>                 | <span data-ttu-id="e6a7f-294">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-294">\#FF000000</span></span>      |

<span data-ttu-id="e6a7f-295">Windows には複数のハイ コントラスト テーマが用意されているほか、次のように、コンピューターの簡単操作を通じて、独自のハイ コントラスト設定で使う特定の色をユーザーが設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-295">Windows provides different high-contrast themes, and enables the user to set the specific colors to for their high-contrast settings through the Ease of Access Center, as shown here.</span></span> <span data-ttu-id="e6a7f-296">このため、ハイ コントラストのカラー値の確定的な一覧を提供することはできません。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-296">Therefore, it's not possible to provide a definitive list of high-contrast color values.</span></span>

![Windows のハイ コントラストの設定 UI](images/high-contrast-settings.png)

<span data-ttu-id="e6a7f-298">ハイ コントラスト テーマのサポートについて詳しくは、「[ハイ コントラスト テーマ](https://msdn.microsoft.com/library/windows/apps/mt244346)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-298">For more info about supporting high-contrast themes, see [High-contrast themes](https://msdn.microsoft.com/library/windows/apps/mt244346).</span></span>

### <a name="system-accent-color"></a><span data-ttu-id="e6a7f-299">システムのアクセント カラー</span><span class="sxs-lookup"><span data-stu-id="e6a7f-299">System accent color</span></span>

<span data-ttu-id="e6a7f-300">システムのハイ コントラスト テーマの色に加えて、システムのアクセント カラーも、`SystemAccentColor` というキーを使う特別なカラー リソースとして用意されています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-300">In addition to the system high-contrast theme colors, the system accent color is provided as a special color resource using the key `SystemAccentColor`.</span></span> <span data-ttu-id="e6a7f-301">このリソースは、ユーザーが Windows の個人設定でアクセント カラーとして指定した色を実行時に取得します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-301">At runtime, this resource gets the color that the user has specified as the accent color in the Windows personalization settings.</span></span>

> [!NOTE]
> <span data-ttu-id="e6a7f-302">システム カラー リソースをオーバーライドすることもできますが、特にハイ コントラスト設定については、ユーザーによる色の選択を尊重することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-302">While it’s possible to override the system color resources, it’s a best practice to respect the user’s color choices, especially for high-contrast settings.</span></span>

### <a name="theme-dependent-brushes"></a><span data-ttu-id="e6a7f-303">テーマ依存のブラシ</span><span class="sxs-lookup"><span data-stu-id="e6a7f-303">Theme-dependent brushes</span></span>

<span data-ttu-id="e6a7f-304">システム テーマ リソース ディクショナリの [SolidColorBrush](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush) リソースの [Color](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush.Color) プロパティは、前のセクションに示したカラー リソースを使って設定されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-304">The color resources shown in the preceding sections are used to set the [Color](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush.Color) property of [SolidColorBrush](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush) resources in the system theme resource dictionaries.</span></span> <span data-ttu-id="e6a7f-305">XAML 要素に色を適用するには、ブラシ リソースが使われます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-305">You use the brush resources to apply the color to XAML elements.</span></span> <span data-ttu-id="e6a7f-306">ブラシ リソースのキーは、`SystemControl[Simple HighContrast name][Simple light/dark name]Brush` という名前付け形式に従います。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-306">The keys for the brush resources follow the naming format: `SystemControl[Simple HighContrast name][Simple light/dark name]Brush`.</span></span> <span data-ttu-id="e6a7f-307">たとえば、`SystemControlBackroundAltHighBrush` と記述します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-307">For example, `SystemControlBackroundAltHighBrush`.</span></span>

<span data-ttu-id="e6a7f-308">このブラシの色の値が実行時にどのように決定されるかを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-308">Let’s look at how the color value for this brush is determined at run-time.</span></span> <span data-ttu-id="e6a7f-309">"Light" と "Dark" の各リソース ディクショナリでは、このブラシは次のように定義されています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-309">In the "Light" and "Dark" resource dictionaries, this brush is defined like this:</span></span>

`<SolidColorBrush x:Key="SystemControlBackgroundAltHighBrush" Color="{StaticResource SystemAltHighColor}"/>`

<span data-ttu-id="e6a7f-310">"HighContrast" リソース ディクショナリでは、このブラシは次のように定義されています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-310">In the "HighContrast" resource dictionary, this brush is defined like this:</span></span>

`<SolidColorBrush x:Key="SystemControlBackgroundAltHighBrush" Color="{ThemeResource SystemColorButtonFaceColor}"/>`

<span data-ttu-id="e6a7f-311">このブラシが XAML 要素に適用されるとき、その色は、次の表に示すように現在のテーマによって実行時に決定されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-311">When this brush is applied to a XAML element, its color is determined at run-time by the current theme, as shown in this table.</span></span>

| <span data-ttu-id="e6a7f-312">Theme</span><span class="sxs-lookup"><span data-stu-id="e6a7f-312">Theme</span></span>        | <span data-ttu-id="e6a7f-313">色の簡易名</span><span class="sxs-lookup"><span data-stu-id="e6a7f-313">Color simple name</span></span> | <span data-ttu-id="e6a7f-314">カラー リソース</span><span class="sxs-lookup"><span data-stu-id="e6a7f-314">Color resource</span></span>             | <span data-ttu-id="e6a7f-315">ランタイム値</span><span class="sxs-lookup"><span data-stu-id="e6a7f-315">Runtime value</span></span>                                              |
|--------------|-------------------|----------------------------|------------------------------------------------------------|
| <span data-ttu-id="e6a7f-316">明るい</span><span class="sxs-lookup"><span data-stu-id="e6a7f-316">Light</span></span>        | <span data-ttu-id="e6a7f-317">AltHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-317">AltHigh</span></span>           | <span data-ttu-id="e6a7f-318">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-318">SystemAltHighColor</span></span>         | <span data-ttu-id="e6a7f-319">\#FFFFFFFF</span><span class="sxs-lookup"><span data-stu-id="e6a7f-319">\#FFFFFFFF</span></span>                                                 |
| <span data-ttu-id="e6a7f-320">暗い</span><span class="sxs-lookup"><span data-stu-id="e6a7f-320">Dark</span></span>         | <span data-ttu-id="e6a7f-321">AltHigh</span><span class="sxs-lookup"><span data-stu-id="e6a7f-321">AltHigh</span></span>           | <span data-ttu-id="e6a7f-322">SystemAltHighColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-322">SystemAltHighColor</span></span>         | <span data-ttu-id="e6a7f-323">\#FF000000</span><span class="sxs-lookup"><span data-stu-id="e6a7f-323">\#FF000000</span></span>                                                 |
| <span data-ttu-id="e6a7f-324">HighContrast</span><span class="sxs-lookup"><span data-stu-id="e6a7f-324">HighContrast</span></span> | <span data-ttu-id="e6a7f-325">背景</span><span class="sxs-lookup"><span data-stu-id="e6a7f-325">Background</span></span>        | <span data-ttu-id="e6a7f-326">SystemColorButtonFaceColor</span><span class="sxs-lookup"><span data-stu-id="e6a7f-326">SystemColorButtonFaceColor</span></span> | <span data-ttu-id="e6a7f-327">設定でボタンの背景として指定された色。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-327">The color specified in settings for the button background.</span></span> |

<span data-ttu-id="e6a7f-328">独自の XAML 要素に適用するブラシを決めるには、`SystemControl[Simple HighContrast name][Simple light/dark name]Brush` という名前付けスキームを使います。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-328">You can use the `SystemControl[Simple HighContrast name][Simple light/dark name]Brush` naming scheme to determine which brush to apply to your own XAML elements.</span></span>

<!--
For many examples of how the brushes are used in the XAML control templates, see the [Default control styles and templates](default-control-styles-and-templates.md).
-->

> [!NOTE]
> <span data-ttu-id="e6a7f-329">すべての組み合わせ\[*単純なハイコントラスト名前*\]\[*/暗の簡易名*\]ブラシ リソースとして提供されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-329">Not every combination of \[*Simple HighContrast name*\]\[*Simple light/dark name*\] is provided as a brush resource.</span></span>

## <a name="the-xaml-type-ramp"></a><span data-ttu-id="e6a7f-330">XAML の書体見本</span><span class="sxs-lookup"><span data-stu-id="e6a7f-330">The XAML type ramp</span></span>

<span data-ttu-id="e6a7f-331">themeresources.xaml ファイルには、UI 上のテキスト コンテナー (具体的には [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) または [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)) に適用できる [Style](https://msdn.microsoft.com/library/windows/apps/br208849) を定義するリソースがいくつか定義されています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-331">The themeresources.xaml file defines several resources that define a [Style](https://msdn.microsoft.com/library/windows/apps/br208849) that you can apply to text containers in your UI, specifically for either [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) or [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565).</span></span> <span data-ttu-id="e6a7f-332">これらは、既定の暗黙的なスタイルとは異なります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-332">These are not the default implicit styles.</span></span> <span data-ttu-id="e6a7f-333">これらのスタイルを使うと、「[フォントのガイドライン](../style/typography.md)」で説明されている *Windows の書体見本*に一致する XAML UI 定義を簡単に作成できるようになります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-333">They are provided to make it easier for you to create XAML UI definitions that match the *Windows type ramp* documented in [Guidelines for fonts](../style/typography.md).</span></span>

<span data-ttu-id="e6a7f-334">これらのスタイルは、テキスト コンテナー全体に適用されるテキスト属性を設定するものです。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-334">These styles are for text attributes that you want applied to the whole text container.</span></span> <span data-ttu-id="e6a7f-335">テキストの一部にのみスタイルを適用する場合は、コンテナー内のテキスト要素に属性を設定します。たとえば、[TextBlock.Inlines](https://msdn.microsoft.com/library/windows/apps/br209668) の [Run](https://msdn.microsoft.com/library/windows/apps/br209959) や [RichTextBlock.Blocks](https://msdn.microsoft.com/library/windows/apps/br244347) の [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-335">If you want styles applied just to sections of the text, set attributes on the text elements within the container, such as on a [Run](https://msdn.microsoft.com/library/windows/apps/br209959) in [TextBlock.Inlines](https://msdn.microsoft.com/library/windows/apps/br209668) or on a [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) in [RichTextBlock.Blocks](https://msdn.microsoft.com/library/windows/apps/br244347).</span></span>

<span data-ttu-id="e6a7f-336">スタイルを [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) に適用すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-336">The styles look like this when applied to a [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652):</span></span>

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

<span data-ttu-id="e6a7f-338">アプリで UWP 書体見本を使用する方法のガイダンスについては、「[UWP アプリの文字体裁](../style/typography.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-338">For guidance on how to use the UWP type ramp in your app, see [Typography in UWP apps](../style/typography.md).</span></span>

### <a name="basetextblockstyle"></a><span data-ttu-id="e6a7f-339">BaseTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-339">BaseTextBlockStyle</span></span>

<span data-ttu-id="e6a7f-340">**TargetType**:[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-340">**TargetType**: [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)</span></span>

<span data-ttu-id="e6a7f-341">他のすべての [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) コンテナー スタイルに対する一般的なプロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-341">Supplies the common properties for all the other [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) container styles.</span></span>

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

### <a name="headertextblockstyle"></a><span data-ttu-id="e6a7f-342">HeaderTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-342">HeaderTextBlockStyle</span></span>

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

### <a name="subheadertextblockstyle"></a><span data-ttu-id="e6a7f-343">SubheaderTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-343">SubheaderTextBlockStyle</span></span>

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

### <a name="titletextblockstyle"></a><span data-ttu-id="e6a7f-344">TitleTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-344">TitleTextBlockStyle</span></span>

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

### <a name="subtitletextblockstyle"></a><span data-ttu-id="e6a7f-345">SubtitleTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-345">SubtitleTextBlockStyle</span></span>

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

### <a name="bodytextblockstyle"></a><span data-ttu-id="e6a7f-346">BodyTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-346">BodyTextBlockStyle</span></span>

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

### <a name="captiontextblockstyle"></a><span data-ttu-id="e6a7f-347">CaptionTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-347">CaptionTextBlockStyle</span></span>

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

### <a name="baserichtextblockstyle"></a><span data-ttu-id="e6a7f-348">BaseRichTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-348">BaseRichTextBlockStyle</span></span>

<span data-ttu-id="e6a7f-349">**TargetType**:[RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-349">**TargetType**: [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)</span></span>

<span data-ttu-id="e6a7f-350">他のすべての [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) コンテナー スタイルに対する一般的なプロパティを提供します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-350">Supplies the common properties for all the other [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) container styles.</span></span>

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

### <a name="bodyrichtextblockstyle"></a><span data-ttu-id="e6a7f-351">BodyRichTextBlockStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-351">BodyRichTextBlockStyle</span></span>

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

<span data-ttu-id="e6a7f-352">**注意**:  [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565)スタイルは、すべてのテキストがないをスタイル設定ごとの傾斜増加[TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652)は、ブロック ベースのドキュメント オブジェクト モデル化のために主に**RichTextBlock**なります個々 のテキスト要素に属性を設定する簡単にします。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-352">**Note**:  The [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/br227565) styles don't have all the text ramp styles that [TextBlock](https://msdn.microsoft.com/library/windows/apps/br209652) does, mainly because the block-based document object model for **RichTextBlock** makes it easier to set attributes on the individual text elements.</span></span> <span data-ttu-id="e6a7f-353">また、XAML コンテンツ プロパティを使って [TextBlock.Text](https://msdn.microsoft.com/library/windows/apps/br209676) を設定する方式では、スタイルを設定できるテキスト要素が存在しない状況になるため、コンテナーにスタイルを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-353">Also, setting [TextBlock.Text](https://msdn.microsoft.com/library/windows/apps/br209676) using the XAML content property introduces a situation where there is no text element to style and thus you'd have to style the container.</span></span> <span data-ttu-id="e6a7f-354">これに対して **RichTextBlock** では、テキスト コンテンツは常に [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503) などの固有のテキスト要素になり、そこにページ ヘッダーやページ サブヘッダー、類似のテキスト見本定義の XAML スタイルを適用できるため、この問題はありません。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-354">That isn't an issue for **RichTextBlock** because its text content always has to be in specific text elements like [Paragraph](https://msdn.microsoft.com/library/windows/apps/br244503), which is where you might apply XAML styles for page header, page subheader and similar text ramp definitions.</span></span>

## <a name="miscellaneous-named-styles"></a><span data-ttu-id="e6a7f-355">その他の名前付きスタイル</span><span class="sxs-lookup"><span data-stu-id="e6a7f-355">Miscellaneous Named styles</span></span>

<span data-ttu-id="e6a7f-356">[Button](https://msdn.microsoft.com/library/windows/apps/br209265) には、キーを持つ [Style](https://msdn.microsoft.com/library/windows/apps/br208849) 定義の追加のセットを適用することもできます。これにより、既定の暗黙的なスタイルとは異なるスタイルを設定できます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-356">There's an additional set of keyed [Style](https://msdn.microsoft.com/library/windows/apps/br208849) definitions you can apply to style a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) differently than its default implicit style.</span></span>

### <a name="textblockbuttonstyle"></a><span data-ttu-id="e6a7f-357">TextBlockButtonStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-357">TextBlockButtonStyle</span></span>

<span data-ttu-id="e6a7f-358">**TargetType**:[ButtonBase](https://msdn.microsoft.com/library/windows/apps/br227736)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-358">**TargetType**: [ButtonBase](https://msdn.microsoft.com/library/windows/apps/br227736)</span></span>

<span data-ttu-id="e6a7f-359">ユーザーがクリックしてアクションを実行できるテキストを表示する必要がある場合は、このスタイルを [Button](https://msdn.microsoft.com/library/windows/apps/br209265) に適用します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-359">Apply this style to a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) when you need to show text that a user can click to take action.</span></span> <span data-ttu-id="e6a7f-360">このテキストには、対話型であることがわかるように現在のアクセント カラーを使ったスタイルが設定され、テキストに適したフォーカス四角形が表示されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-360">The text is styled using the current accent color to distinguish it as interactive and has focus rectangles that work well for text.</span></span> <span data-ttu-id="e6a7f-361">[HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/br242739) の暗黙的なスタイルとは異なり、**TextBlockButtonStyle** のテキストには下線は付きません。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-361">Unlike the implicit style of a [HyperlinkButton](https://msdn.microsoft.com/library/windows/apps/br242739), the **TextBlockButtonStyle** does not underline the text.</span></span>

<span data-ttu-id="e6a7f-362">このテンプレートは、表示テキストにもスタイルを設定して、**SystemControlHyperlinkBaseMediumBrush** ("PointerOver" 状態の場合)、**SystemControlHighlightBaseMediumLowBrush** ("Pressed" 状態の場合)、**SystemControlDisabledBaseLowBrush** ("Disabled" 状態の場合) が使われるようにします。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-362">The template also styles the presented text to use **SystemControlHyperlinkBaseMediumBrush** (for "PointerOver" state), **SystemControlHighlightBaseMediumLowBrush** (for "Pressed" state) and **SystemControlDisabledBaseLowBrush** (for "Disabled" state).</span></span>

<span data-ttu-id="e6a7f-363">**TextBlockButtonStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-363">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **TextBlockButtonStyle** resource applied to it.</span></span>

```XAML
<Button Content="Clickable text" Style="{StaticResource TextBlockButtonStyle}"
        Click="Button_Click"/>
```

<span data-ttu-id="e6a7f-364">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-364">It looks like this:</span></span>

![テキストのような外観にスタイル設定されたボタン](images/styles-textblock-button-style.png)

### <a name="navigationbackbuttonnormalstyle"></a><span data-ttu-id="e6a7f-366">NavigationBackButtonNormalStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-366">NavigationBackButtonNormalStyle</span></span>

<span data-ttu-id="e6a7f-367">**TargetType**:[ボタン](https://msdn.microsoft.com/library/windows/apps/br209265)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-367">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span></span>

<span data-ttu-id="e6a7f-368">この [Style](https://msdn.microsoft.com/library/windows/apps/br208849) は、ナビゲーション アプリの戻るボタンとして使うことができる [Button](https://msdn.microsoft.com/library/windows/apps/br209265) 用の完全なテンプレートを提供します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-368">This [Style](https://msdn.microsoft.com/library/windows/apps/br208849) provides a complete template for a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) that can be the navigation back button for a navigation app.</span></span> <span data-ttu-id="e6a7f-369">既定の寸法は 40 x 40 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-369">The default dimensions are 40 x 40 pixels.</span></span> <span data-ttu-id="e6a7f-370">スタイルを調整するには、**Button** の [Height](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height)、[Width](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width)、[FontSize](https://msdn.microsoft.com/library/windows/apps/br209406)、その他のプロパティを明示的に設定するか、[BasedOn](https://msdn.microsoft.com/library/windows/apps/br208852) を使って派生スタイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-370">To tailor the styling you can either explicitly set the [Height](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height), [Width](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width), [FontSize](https://msdn.microsoft.com/library/windows/apps/br209406), and other properties on your **Button** or create a derived style using [BasedOn](https://msdn.microsoft.com/library/windows/apps/br208852).</span></span>

<span data-ttu-id="e6a7f-371">**NavigationBackButtonNormalStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-371">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **NavigationBackButtonNormalStyle** resource applied to it.</span></span>

```XAML
<Button Style="{StaticResource NavigationBackButtonNormalStyle}" />
```

<span data-ttu-id="e6a7f-372">次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-372">It looks like this:</span></span>

!["戻る" ボタンとしてスタイル設定されたボタン](images/styles-back-button-normal.png)

### <a name="navigationbackbuttonsmallstyle"></a><span data-ttu-id="e6a7f-374">NavigationBackButtonSmallStyle</span><span class="sxs-lookup"><span data-stu-id="e6a7f-374">NavigationBackButtonSmallStyle</span></span>

<span data-ttu-id="e6a7f-375">**TargetType**:[ボタン](https://msdn.microsoft.com/library/windows/apps/br209265)</span><span class="sxs-lookup"><span data-stu-id="e6a7f-375">**TargetType**: [Button](https://msdn.microsoft.com/library/windows/apps/br209265)</span></span>

<span data-ttu-id="e6a7f-376">この [Style](https://msdn.microsoft.com/library/windows/apps/br208849) は、ナビゲーション アプリの戻るボタンとして使うことができる [Button](https://msdn.microsoft.com/library/windows/apps/br209265) 用の完全なテンプレートを提供します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-376">This [Style](https://msdn.microsoft.com/library/windows/apps/br208849) provides a complete template for a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) that can be the navigation back button for a navigation app.</span></span> <span data-ttu-id="e6a7f-377">**NavigationBackButtonNormalStyle** と同様ですが、寸法は 30 x 30 ピクセルになります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-377">It's similar to **NavigationBackButtonNormalStyle**, but its dimensions are 30 x 30 pixels.</span></span>

<span data-ttu-id="e6a7f-378">**NavigationBackButtonSmallStyle** リソースを適用した [Button](https://msdn.microsoft.com/library/windows/apps/br209265) の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-378">Here's a [Button](https://msdn.microsoft.com/library/windows/apps/br209265) with the **NavigationBackButtonSmallStyle** resource applied to it.</span></span>

```XAML
<Button Style="{StaticResource NavigationBackButtonSmallStyle}" />
```

## <a name="troubleshooting-theme-resources"></a><span data-ttu-id="e6a7f-379">テーマ リソースのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="e6a7f-379">Troubleshooting theme resources</span></span>

<span data-ttu-id="e6a7f-380">[テーマ リソースの使用に関するガイドライン](#guidelines-for-custom-theme-resources)に従わないと、テーマに関連する予期しない動作がアプリで発生することがあります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-380">If you don’t follow the [guidelines for using theme resources](#guidelines-for-custom-theme-resources), you might see unexpected behavior related to themes in your app.</span></span>

<span data-ttu-id="e6a7f-381">たとえば、淡色テーマのポップアップを開いたときに、濃色テーマのアプリの部分まで淡色テーマのように変更される場合があります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-381">For example, when you open a light-themed flyout, parts of your dark-themed app also change as if they were in the light theme.</span></span> <span data-ttu-id="e6a7f-382">または、淡色テーマのページに移動してから戻ってくると、元の濃色テーマのページ (またはその部分) が淡色テーマのように表示される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-382">Or if you navigate to a light-themed page and then navigate back, the original dark-themed page (or parts of it) now looks as though it is in the light theme.</span></span>

<span data-ttu-id="e6a7f-383">このような問題は、通常、"Default" テーマと "HighContrast" テーマを用意してハイ コントラスト シナリオをサポートした状態で、"Light" と "Dark" の両方のテーマをアプリ内の別々の部分で使っている場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-383">Typically, these types of issues occur when you provide a "Default" theme and a "HighContrast" theme to support high-contrast scenarios, and then use both "Light" and "Dark" themes in different parts of your app.</span></span>

<span data-ttu-id="e6a7f-384">たとえば、次のテーマ ディクショナリの定義について考えてみます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-384">For example, consider this theme dictionary definition:</span></span>

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

<span data-ttu-id="e6a7f-385">直感的には、これは正しく見えます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-385">Intuitively, this looks correct.</span></span> <span data-ttu-id="e6a7f-386">ハイ コントラストのときは `myBrush` が指す色を変更しますが、ハイ コントラストでない場合は、[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を利用することで `myBrush` がテーマに適した色を指すようにしています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-386">You want to change the color pointed to by `myBrush` when in high-contrast, but when not in high-contrast, you rely on the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) to make sure that `myBrush` points to the right color for your theme.</span></span> <span data-ttu-id="e6a7f-387">これは通常、アプリのビジュアル ツリー内に [FrameworkElement.RequestedTheme](https://msdn.microsoft.com/library/windows/apps/dn298515) が設定された要素がなければ期待どおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-387">If your app never has [FrameworkElement.RequestedTheme](https://msdn.microsoft.com/library/windows/apps/dn298515) set on elements within its visual tree, this will typically work as expected.</span></span> <span data-ttu-id="e6a7f-388">しかし、ビジュアル ツリーの各部分にテーマを再設定し始めたとたんに、アプリで問題が発生することになります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-388">However, you run into problems in your app as soon as you start to re-theme different parts of your visual tree.</span></span>

<span data-ttu-id="e6a7f-389">問題が発生する原因は、他のほとんどの XAML 型とは異なり、ブラシが共有リソースであるためです。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-389">The problem occurs because brushes are shared resources, unlike most other XAML types.</span></span> <span data-ttu-id="e6a7f-390">XAML サブツリーに 2 つの要素があり、同じブラシ リソースを参照する別々のテーマが設定されている場合、フレームワークが各サブツリーを走査してそれぞれの [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)表現を更新していくと、それにつれて共有ブラシ リソースに対する変更が他のサブツリーに反映されます。これは意図した結果とは異なります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-390">If you have 2 elements in XAML sub-trees with different themes that reference the same brush resource, then as the framework walks each sub-tree to update its [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) expressions, changes to the shared brush resource are reflected in the other sub-tree, which is not your intended result.</span></span>

<span data-ttu-id="e6a7f-391">これを修正するには、"Default" ディクショナリを置き換えて、"HighContrast" に加えて "Light" テーマと "Dark" テーマのディクショナリも個別に指定します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-391">To fix this, replace the "Default" dictionary with separate theme dictionaries for both "Light" and "Dark" themes in addition to "HighContrast":</span></span>

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

<span data-ttu-id="e6a7f-392">ただし、これらのリソースのいずれかが [Foreground](https://msdn.microsoft.com/library/windows/apps/br209414) などの継承されたプロパティで参照されていると、引き続き問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-392">However, problems still occur if any of these resources are referenced in inherited properties like [Foreground](https://msdn.microsoft.com/library/windows/apps/br209414).</span></span> <span data-ttu-id="e6a7f-393">カスタム コントロール テンプレートでは、[{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を使って要素の前景色を指定している場合がありますが、継承された値がフレームワークによって子要素に伝達されるときは、{ThemeResource} マークアップ拡張表現で解決されたリソースへの直接参照が提供されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-393">Your custom control template might specify the foreground color of an element using the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md), but when the framework propagates the inherited value to child elements, it provides a direct reference to the resource that was resolved by the {ThemeResource} markup extension expression.</span></span> <span data-ttu-id="e6a7f-394">フレームワークがコントロールのビジュアル ツリーを走査する過程でテーマの変更が処理されると、問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-394">This causes problems when the framework processes theme changes as it walks your control's visual tree.</span></span> <span data-ttu-id="e6a7f-395">フレームワークは {ThemeResource} マークアップ拡張表現を再評価して新しいブラシ リソースを取得しますが、この参照はまだコントロールの子に伝達されません。子への伝達は、次回の測定パスの間など、後で行われます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-395">It re-evaluates the {ThemeResource} markup extension expression to get a new brush resource but doesn’t yet propagate this reference down to the children of your control; this happens later, such as during the next measure pass.</span></span>

<span data-ttu-id="e6a7f-396">結果として、テーマの変更に応答してコントロールのビジュアル ツリーを走査した後、フレームワークは子を走査し、それぞれに設定されている [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)表現、または子のプロパティに設定されているオブジェクト上の表現をすべて更新します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-396">As a result, after walking the control visual tree in response to a theme change, the framework walks the children and updates any [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) expressions set on them, or on objects set on their properties.</span></span> <span data-ttu-id="e6a7f-397">ここで問題が発生します。フレームワークがブラシ リソースを走査すると、その色は {ThemeResource} マークアップ拡張を使って指定されているため、ブラシ リソースが再評価されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-397">This is where the problem occurs; the framework walks the brush resource and because it specifies its color using a {ThemeResource} markup extension, it's re-evaluated.</span></span>

<span data-ttu-id="e6a7f-398">この時点で、あるディクショナリのリソースに別のディクショナリから設定された色が適用され、フレームワークがテーマ ディクショナリを汚染した形になります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-398">At this point, the framework appears to have polluted your theme dictionary because it now has a resource from one dictionary that has its color set from another dictionary.</span></span>

<span data-ttu-id="e6a7f-399">この問題を解決するには、[{ThemeResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)の代わりに [{StaticResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-399">To fix this problem, use the [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md) instead of [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md).</span></span> <span data-ttu-id="e6a7f-400">ガイドラインを適用したテーマ ディクショナリは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-400">With the guidelines applied, the theme dictionaries look like this:</span></span>

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

<span data-ttu-id="e6a7f-401">"HighContrast" ディクショナリでは、[{StaticResource} マークアップ拡張](../../xaml-platform/staticresource-markup-extension.md)ではなく [{ThemeResource} マークアップ拡張](../../xaml-platform/themeresource-markup-extension.md)が引き続き使われていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-401">Notice that the [{ThemeResource} markup extension](../../xaml-platform/themeresource-markup-extension.md) is still used in the "HighContrast" dictionary instead of [{StaticResource} markup extension](../../xaml-platform/staticresource-markup-extension.md).</span></span> <span data-ttu-id="e6a7f-402">この状況は、ガイドラインで既に説明した例外に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-402">This situation falls under the exception given earlier in the guidelines.</span></span> <span data-ttu-id="e6a7f-403">"HighContrast" テーマに使われるブラシの値のほとんどは、システムによって全体的に制御される色から選択されますが、これらは特別な名前付きのリソース (名前に 'SystemColor' というプレフィックスが付いているもの) として XAML に公開されています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-403">Most of the brush values that are used for the "HighContrast" theme are using color choices that are globally controlled by the system, but exposed to XAML as a specially-named resource (those prefixed with ‘SystemColor’ in the name).</span></span> <span data-ttu-id="e6a7f-404">ハイ コントラスト設定で使う特定の色は、コンピューターの簡単操作を通じてユーザーが設定できるようになっています。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-404">The system enables the user to set the specific colors that should be used for their high contrast settings through the Ease of Access Center.</span></span> <span data-ttu-id="e6a7f-405">これらの色の選択は、特別な名前付きのリソースに適用されます。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-405">Those color choices are applied to the specially-named resources.</span></span> <span data-ttu-id="e6a7f-406">XAML フレームワークでは、システム レベルでの変更の検出時にこれらのブラシを更新する場合にも、同じテーマ変更イベントを使用します。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-406">The XAML framework uses the same theme changed event to also update these brushes when it detects they’ve changed at the system level.</span></span> <span data-ttu-id="e6a7f-407">ここで {ThemeResource} マークアップ拡張が使われているのはこのためです。</span><span class="sxs-lookup"><span data-stu-id="e6a7f-407">This is why the {ThemeResource} markup extension is used here.</span></span>