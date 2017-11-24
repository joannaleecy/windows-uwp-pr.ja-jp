---
author: stevewhims
Description: "アプリで複数の表示言語をサポートする必要があり、コード、XAML マークアップ、アプリ パッケージ マニフェスト内に文字列リテラルが含まれている場合は、その文字列をリソース ファイル (.resw) に移動します。 アプリでサポートする各言語用に、このリソース ファイルを翻訳したコピーを作成することができます。"
title: "UI とアプリ パッケージ マニフェスト内の文字列をローカライズする"
ms.assetid: E420B9BB-C0F6-4EC0-BA3A-BA2875B69722
label: Localize strings in your UI and app package manifest
template: detail.hbs
ms.author: stwhi
ms.date: 11/01/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子"
localizationpriority: medium
ms.openlocfilehash: cca9c9b731831ce1c87ee74b7f8b502130ef97fd
ms.sourcegitcommit: d0c93d734639bd31f264424ae5b6fead903a951d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2017
---
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

# <a name="localize-strings-in-your-ui-and-app-package-manifest"></a><span data-ttu-id="b8706-105">UI とアプリ パッケージ マニフェスト内の文字列をローカライズする</span><span class="sxs-lookup"><span data-stu-id="b8706-105">Localize strings in your UI and app package manifest</span></span>

<span data-ttu-id="b8706-106">アプリのローカライズの価値提案の詳細については、「[グローバリゼーションとローカライズ](../globalizing/globalizing-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b8706-106">For more info about the value proposition of localizing your app, see [Globalization and localization](../globalizing/globalizing-portal.md).</span></span>

<span data-ttu-id="b8706-107">アプリで複数の表示言語をサポートする必要があり、コード、XAML マークアップ、アプリ パッケージ マニフェスト内に文字列リテラルが含まれている場合は、その文字列をリソース ファイル (.resw) に移動します。</span><span class="sxs-lookup"><span data-stu-id="b8706-107">If you want your app to support different display languages, and you have string literals in your code or XAML markup or app package manifest, then move those strings into a Resources File (.resw).</span></span> <span data-ttu-id="b8706-108">アプリでサポートする各言語用に、このリソース ファイルを翻訳したコピーを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="b8706-108">You can then make a translated copy of that Resources File for each language that your app supports.</span></span>

<span data-ttu-id="b8706-109">ハードコードされた文字列リテラルは、命令型コードや XAML マークアップに (たとえば、**TextBlock** の **Text** プロパティとして)表示できます。</span><span class="sxs-lookup"><span data-stu-id="b8706-109">Hardcoded string literals can appear in imperative code or in XAML markup, for example as the **Text** property of a **TextBlock**.</span></span> <span data-ttu-id="b8706-110">また、アプリ パッケージ マニフェスト (`Package.appxmanifest` ファイル) に (たとえば、Visual Studio マニフェスト デザイナーの [アプリケーション] タブで表示名の値として) 表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="b8706-110">They can also appear in your app package manifest (the `Package.appxmanifest` file), for example as the value for Display name on the Application tab of the Visual Studio Manifest Designer.</span></span> <span data-ttu-id="b8706-111">これらの文字列をリソース ファイル (.resw) に移動し、アプリやリソース内のハードコードされた文字列リテラルをリソース識別子への参照に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="b8706-111">Move these strings into a Resources File (.resw), and replace the hardcoded string literals in your app and in your manifest with references to resource identifiers.</span></span>

<span data-ttu-id="b8706-112">画像リソース ファイルに画像リソースが 1 つだけ含まれている画像リソースとは異なり、文字列リソース ファイルには*複数の*文字列リソースが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b8706-112">Unlike image resources, where only one image resource is contained in an image resource file, *multiple* string resources are contained in a string resource file.</span></span> <span data-ttu-id="b8706-113">文字列リソース ファイルはリソース ファイル (.resw) であり、通常、この種類のリソース ファイルはプロジェクトの \Strings フォルダー内に作成します。</span><span class="sxs-lookup"><span data-stu-id="b8706-113">A string resource file is a Resources File (.resw), and you typically create this kind of resource file in a \Strings folder in your project.</span></span> <span data-ttu-id="b8706-114">リソース ファイル (.resw) の名前に修飾子を使用する方法の詳細については、「[言語、スケール、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b8706-114">For background on how to use qualifiers in the names of your Resources Files (.resw), see [Tailor your resources for language, scale, and other qualifiers](tailor-resources-lang-scale-contrast.md).</span></span>

## <a name="create-a-resources-file-resw-and-put-your-strings-in-it"></a><span data-ttu-id="b8706-115">リソース ファイル (.resw) を作成し、文字列を配置する</span><span class="sxs-lookup"><span data-stu-id="b8706-115">Create a Resources File (.resw) and put your strings in it</span></span>

1. <span data-ttu-id="b8706-116">アプリの既定の言語を設定します。</span><span class="sxs-lookup"><span data-stu-id="b8706-116">Set your app's default language.</span></span>
    1. <span data-ttu-id="b8706-117">Visual Studio でソリューションを開いた状態で、`Package.appxmanifest` を開きます。</span><span class="sxs-lookup"><span data-stu-id="b8706-117">With your solution open in Visual Studio, open `Package.appxmanifest`.</span></span>
    2. <span data-ttu-id="b8706-118">[アプリケーション] タブで、既定の言語が適切に設定されている ("en"や "en-us" など) ことを確認します。</span><span class="sxs-lookup"><span data-stu-id="b8706-118">On the Application tab, confirm that the Default language is set appropriately (for example, "en" or "en-US").</span></span> <span data-ttu-id="b8706-119">残りの手順では、既定の言語を "en-US" に設定していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="b8706-119">The remaining steps will assume that you have set the default language to "en-US".</span></span>
    <br><span data-ttu-id="b8706-120">**注:** 最低でも、この既定の言語のローカライズされた文字列リソースを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8706-120">**Note** At a minimum, you need to provide string resources localized for this default language.</span></span> <span data-ttu-id="b8706-121">これらは、ユーザーの優先する言語や表示言語の設定に一致するものが見つからない場合に読み込まれるリソースです。</span><span class="sxs-lookup"><span data-stu-id="b8706-121">Those are the resources that will be loaded if no better match can be found for the user's preferred language or display language settings.</span></span>
2. <span data-ttu-id="b8706-122">既定の言語のリソース ファイル (.resw) を作成します。</span><span class="sxs-lookup"><span data-stu-id="b8706-122">Create a Resources File (.resw) for the default language.</span></span>
    1. <span data-ttu-id="b8706-123">プロジェクト ノードで、新しいフォルダーを作成し、"Strings" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b8706-123">Under your project node, create a new folder and name it "Strings".</span></span>
    2. <span data-ttu-id="b8706-124">`Strings` で、新しいサブフォルダーを作成し、"en-US" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b8706-124">Under `Strings`, create a new sub-folder and name it "en-US".</span></span>
    3. <span data-ttu-id="b8706-125">`en-US` で、新しいリソース ファイル (.resw) を作成し、その名前が "Resources.resw" になっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b8706-125">Under `en-US`, create a new Resources File (.resw) and confirm that it is named "Resources.resw".</span></span>
    <br><span data-ttu-id="b8706-126">**注:** .NET リソース ファイル (.resx) を移植する場合は、「[XAML と UI の移植](../porting/wpsl-to-uwp-porting-xaml-and-ui.md#localization-and-globalization)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b8706-126">**Note** If you have .NET Resources Files (.resx) that you want to port, see [Porting XAML and UI](../porting/wpsl-to-uwp-porting-xaml-and-ui.md#localization-and-globalization).</span></span>
3.  <span data-ttu-id="b8706-127">`Resources.resw` を開き、次の文字列リソースを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8706-127">Open `Resources.resw` and add these string resources.</span></span>

    `Strings/en-US/Resources.resw`

    ![リソースの追加 (英語)](images/addresource-en-us.png)

    <span data-ttu-id="b8706-129">この例では、"Greeting" が、マークアップから参照できる文字列リソース識別子です。</span><span class="sxs-lookup"><span data-stu-id="b8706-129">In this example, "Greeting" is a string resource identifier that you can refer to from your markup, as we'll show.</span></span> <span data-ttu-id="b8706-130">識別子 "Greeting" について、Text プロパティの文字列が提供され、Width プロパティの文字列が提供されています。</span><span class="sxs-lookup"><span data-stu-id="b8706-130">For the identifier "Greeting", a string is provided for a Text property, and a string is provided for a Width property.</span></span> <span data-ttu-id="b8706-131">"Greeting.Text" は、UI 要素のプロパティに対応しているため、プロパティ識別子の例です。</span><span class="sxs-lookup"><span data-stu-id="b8706-131">"Greeting.Text" is an example of a property identifier because it corresponds to a property of a UI element.</span></span> <span data-ttu-id="b8706-132">また、たとえば、[名前] 列で "Greeting.Foreground" を追加し、その値を "Red" に設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="b8706-132">You could also, for example, add "Greeting.Foreground" in the Name column, and set its Value to "Red".</span></span> <span data-ttu-id="b8706-133">"Farewell" 識別子は、単純な文字列リソース識別子です。サブプロパティを持たず、後で説明するように、命令型コードから読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="b8706-133">The "Farewell" identifier is a simple string resource identifier; it has no sub-properties and it can be loaded from imperative code, as we'll show.</span></span> <span data-ttu-id="b8706-134">[コメント] 列は、翻訳者に特別な指示を提供するのに適しています。</span><span class="sxs-lookup"><span data-stu-id="b8706-134">The Comment column is a good place to provide any special instructions to translators.</span></span>

    <span data-ttu-id="b8706-135">この例では、"Farewell" という名前の単純な文字列リソース識別子エントリがあるため、同じ識別子に基づくプロパティ識別子*も*指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="b8706-135">In this example, since we have a simple string resource identifier entry named "Farewell", we cannot *also* have property identifiers based on that same identifier.</span></span> <span data-ttu-id="b8706-136">そのため、"Farewell.Text" を追加すると、`Resources.resw` をビルドするときに、重複したエントリのエラーが出力されます。</span><span class="sxs-lookup"><span data-stu-id="b8706-136">So, adding "Farewell.Text" would cause a Duplicate Entry error when building `Resources.resw`.</span></span>

## <a name="refer-to-a-string-resource-identifier-from-xaml-markup"></a><span data-ttu-id="b8706-137">XAML マークアップから文字列リソース識別子を参照する</span><span class="sxs-lookup"><span data-stu-id="b8706-137">Refer to a string resource identifier from XAML markup</span></span>

<span data-ttu-id="b8706-138">[x:Uid ディレクティブ](../xaml-platform/x-uid-directive.md)を使用して、マークアップ内のコントロールやその他の要素を文字列リソース識別子に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="b8706-138">You use an [x:Uid directive](../xaml-platform/x-uid-directive.md) to associate a control or other element in your markup with a string resource identifier.</span></span>

**<span data-ttu-id="b8706-139">XAML</span><span class="sxs-lookup"><span data-stu-id="b8706-139">XAML</span></span>**
```xml
<TextBlock x:Uid="Greeting"/>
```

<span data-ttu-id="b8706-140">実行時に、`\Strings\en-US\Resources.resw` が読み込まれます (現時点では、プロジェクト内の唯一のリソース ファイルであるためです)。</span><span class="sxs-lookup"><span data-stu-id="b8706-140">At run-time, `\Strings\en-US\Resources.resw` is loaded (since right now that's the only Resources File in the project).</span></span> <span data-ttu-id="b8706-141">**TextBlock** の **x:Uid** ディレクティブによって、参照が実行され、`Resources.resw` 内の "Greeting" 文字列リソース識別子を含むプロパティ識別子が見つかります。</span><span class="sxs-lookup"><span data-stu-id="b8706-141">The **x:Uid** directive on the **TextBlock** causes a lookup to take place, to find property identifiers inside `Resources.resw` that contain the string resource identifier "Greeting".</span></span> <span data-ttu-id="b8706-142">"Greeting.Text" および "Greeting.Width" プロパティ識別子が見つかり、その値が **TextBlock** に適用され、マークアップでローカルに設定されている値がオーバーライドされます。</span><span class="sxs-lookup"><span data-stu-id="b8706-142">The "Greeting.Text" and "Greeting.Width" property identifiers are found and their values are applied to the **TextBlock**, overriding any values set locally in the markup.</span></span> <span data-ttu-id="b8706-143">"Greeting.Foreground" 値を追加していた場合は、この値も適用されます。</span><span class="sxs-lookup"><span data-stu-id="b8706-143">The "Greeting.Foreground" value would be applied, too, if you'd added that.</span></span> <span data-ttu-id="b8706-144">ただし、XAML マークアップ要素でプロパティを設定するための使用されるのはプロパティ識別子のみであるため、この TextBlock で **x:Uid** を "Farewell" に設定しても効果はありません。</span><span class="sxs-lookup"><span data-stu-id="b8706-144">But only property identifiers are used to set properties on XAML markup elements, so setting **x:Uid** to "Farewell" on this TextBlock would have no effect.</span></span> `Resources.resw` <span data-ttu-id="b8706-145">文字列リソース識別子 "Farewell" が含まれて*います*が、そのプロパティ識別子はありません。</span><span class="sxs-lookup"><span data-stu-id="b8706-145">*does* contain the string resource identifier "Farewell", but it contains no property identifiers for it.</span></span>

<span data-ttu-id="b8706-146">XAML 要素に文字列リソース識別子を割り当てるときには、その識別子の*すべて*のプロパティ識別子が XAML 要素で適切であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b8706-146">When assigning a string resource identifier to a XAML element, be certain that *all* the property identifiers for that identifier are appropriate for the XAML element.</span></span> <span data-ttu-id="b8706-147">たとえば、**TextBlock** で `x:Uid="Greeting"` を設定する場合、**TextBlock**型は Text プロパティを持つため、"Greeting.Text" は解決されます。</span><span class="sxs-lookup"><span data-stu-id="b8706-147">For example, if you set `x:Uid="Greeting"` on a **TextBlock** then "Greeting.Text" will resolve because the **TextBlock** type has a Text property.</span></span> <span data-ttu-id="b8706-148">**Button** で `x:Uid="Greeting"` を設定する場合、**Button** 型には Text プロパティがないため、"Greeting.Text" によって実行時エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="b8706-148">But if you set `x:Uid="Greeting"` on a **Button** then "Greeting.Text" will cause a run-time error because the **Button** type does not have a Text property.</span></span> <span data-ttu-id="b8706-149">その場合の解決策の 1 つは、"ButtonGreeting.Content" という名前のプロパティ識別子を作成し、**Button** で `x:Uid="ButtonGreeting"` を設定することです。</span><span class="sxs-lookup"><span data-stu-id="b8706-149">One solution for that case is to author a property identifier named "ButtonGreeting.Content", and set `x:Uid="ButtonGreeting"` on the **Button**.</span></span>

<span data-ttu-id="b8706-150">リソース ファイルから **Width** を設定する代わりに、コンテンツに合わせてコントロールのサイズを動的に変更できるようにすることが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="b8706-150">Instead of setting **Width** from a Resources File, you'll probably want to allow controls to dynamically size to content.</span></span>

<span data-ttu-id="b8706-151">**注** [添付プロパティ](../xaml-platform/attached-properties-overview.md)の場合、.resw ファイルの [名前] 列で特別な構文が必要です。</span><span class="sxs-lookup"><span data-stu-id="b8706-151">**Note** For [attached properties](../xaml-platform/attached-properties-overview.md), you need a special syntax in the Name column of a .resw file.</span></span> <span data-ttu-id="b8706-152">たとえば、"Greeting" 識別子用に [AutomationProperties.Name](/uwp/api/windows.ui.xaml.automation.automationproperties?branch=live#Windows_UI_Xaml_Automation_AutomationProperties_NameProperty) 添付プロパティの値を設定するには、これが [名前] 列に入力する内容です。</span><span class="sxs-lookup"><span data-stu-id="b8706-152">For example, to set a value for the [AutomationProperties.Name](/uwp/api/windows.ui.xaml.automation.automationproperties?branch=live#Windows_UI_Xaml_Automation_AutomationProperties_NameProperty) attached property for the "Greeting" identifier, this is what you would enter in the Name column.</span></span>

```
Greeting.[using:Windows.UI.Xaml.Automation]AutomationProperties.Name
```

## <a name="refer-to-a-string-resource-identifier-from-code"></a><span data-ttu-id="b8706-153">コードから文字列リソース識別子を参照する</span><span class="sxs-lookup"><span data-stu-id="b8706-153">Refer to a string resource identifier from code</span></span>

<span data-ttu-id="b8706-154">単純な文字列リソース識別子に基づいて、文字列リソースを明示的に読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="b8706-154">You can explicitly load a string resource based on a simple string resource identifier.</span></span>

**<span data-ttu-id="b8706-155">C#</span><span class="sxs-lookup"><span data-stu-id="b8706-155">C#</span></span>**
```csharp
var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
this.myXAMLTextBlockElement.Text = resourceLoader.GetString("Farewell");
```

**<span data-ttu-id="b8706-156">C++</span><span class="sxs-lookup"><span data-stu-id="b8706-156">C++</span></span>**
```cpp
auto resourceLoader = Windows::ApplicationModel::Resources::ResourceLoader::GetForCurrentView();
this->myXAMLTextBlockElement->Text = resourceLoader->GetString("Farewell");
```

<span data-ttu-id="b8706-157">クラス ライブラリ (ユニバーサル Windows) または[Windows ランタイム ライブラリ (ユニバーサル Windows)](../winrt-components/index.md) プロジェクト内からこの同じコードを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="b8706-157">You can use this same code from within a Class Library (Universal Windows) or a [Windows Runtime Library (Universal Windows)](../winrt-components/index.md) project.</span></span> <span data-ttu-id="b8706-158">実行時に、ライブラリをホストしているアプリのリソースが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="b8706-158">At runtime, the resources of the app that's hosting the library are loaded.</span></span> <span data-ttu-id="b8706-159">アプリはローカライズの度合いが大きくなる可能性があるため、ライブラリでは、ライブラリをホストしているアプリからリソースを読み込むことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b8706-159">We recommend that a library loads resources from the app that hosts it, since the app is likely to have a greater degree of localization.</span></span> <span data-ttu-id="b8706-160">ライブラリがリソースを提供する必要がある場合、ライブラリをホストしているアプリがそれらのリソースを入力に置き換えられるようにするオプションを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8706-160">If a library does need to provide resources then it should give its hosting app the option to replace those resources as an input.</span></span>

<span data-ttu-id="b8706-161">**注** この方法で値を読み込むことができるのは単純な文字列リソース識別子のみであり、プロパティ識別子の値を読み込むことはできません。</span><span class="sxs-lookup"><span data-stu-id="b8706-161">**Note** You can only load the value for a simple string resource identifier this way, not for a property identifier.</span></span> <span data-ttu-id="b8706-162">したがって、このようなコードを使用して "Farewell" の値を読み込むことはできますが、"Greeting.Text" の値を読み込むことはできません。</span><span class="sxs-lookup"><span data-stu-id="b8706-162">So we can load the value for "Farewell" using code like this, but we cannot do so for "Greeting.Text".</span></span> <span data-ttu-id="b8706-163">これを試行すると、空の文字列が返されます。</span><span class="sxs-lookup"><span data-stu-id="b8706-163">Trying to do so will return an empty string.</span></span>

## <a name="refer-to-a-string-resource-identifier-from-your-app-package-manifest"></a><span data-ttu-id="b8706-164">アプリ パッケージ マニフェストから文字列リソース識別子を参照する</span><span class="sxs-lookup"><span data-stu-id="b8706-164">Refer to a string resource identifier from your app package manifest</span></span>

1. <span data-ttu-id="b8706-165">アプリ パッケージ マニフェスト (`Package.appxmanifest` ファイル) を開きます。既定では、アプリの表示名は文字列リテラルで表されます。</span><span class="sxs-lookup"><span data-stu-id="b8706-165">Open your app package manifest (the `Package.appxmanifest` file), in which by default your app's Display name is expressed as a string literal.</span></span>

   ![リソースの追加 (英語)](images/display-name-before.png)

2. <span data-ttu-id="b8706-167">この文字列のローカライズ可能なバージョンを作成するには、`Resources.resw` を開き、"AppDisplayName"という名前で、"Adventure Works Cycles" という値の新しい文字列リソースを追加します。</span><span class="sxs-lookup"><span data-stu-id="b8706-167">To make a localizable version of this string, open `Resources.resw` and add a new string resource with the name "AppDisplayName" and the value "Adventure Works Cycles".</span></span>

3. <span data-ttu-id="b8706-168">表示名の文字列リテラルを、作成した文字列リソース識別子 ("AppDisplayName") への参照に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="b8706-168">Replace the Display name string literal with a reference to the string resource identifier that you just created ("AppDisplayName").</span></span> <span data-ttu-id="b8706-169">これを行うには、`ms-resource` URI (Uniform Resource Identifier) スキームを使用します。</span><span class="sxs-lookup"><span data-stu-id="b8706-169">You use the `ms-resource` URI (Uniform Resource Identifier) scheme to do this.</span></span>

   ![リソースの追加 (英語)](images/display-name-after.png)

4. <span data-ttu-id="b8706-171">マニフェスト内のローカライズする各文字列について、この手順を繰り返します。</span><span class="sxs-lookup"><span data-stu-id="b8706-171">Repeat this process for each string in your manifest that you want to localize.</span></span> <span data-ttu-id="b8706-172">たとえば、アプリの短い名前 (スタート画面でアプリのタイルに表示されるように構成できる) です。</span><span class="sxs-lookup"><span data-stu-id="b8706-172">For example, your app's Short name (which you can configure to appear on your app's tile on Start).</span></span> <span data-ttu-id="b8706-173">アプリ パッケージ マニフェスト内で、ローカライズできるすべての項目の一覧については、「[マニフェストのローカライズ可能な項目](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b8706-173">For a list of all items in the app package manifest that you can localize, see [Localizable manifest items](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live).</span></span>

## <a name="localize-the-string-resources"></a><span data-ttu-id="b8706-174">文字列リソースをローカライズする</span><span class="sxs-lookup"><span data-stu-id="b8706-174">Localize the string resources</span></span>

1. <span data-ttu-id="b8706-175">別の言語用にリソース ファイル (.resw) のコピーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8706-175">Make a copy of your Resources File (.resw) for another language.</span></span>
    1. <span data-ttu-id="b8706-176">"Strings" の下に新しいサブフォルダーを作成し、Deutsch (Deutschland) を表す "de-DE" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b8706-176">Under "Strings", create a new sub-folder and name it "de-DE" for Deutsch (Deutschland).</span></span>
   <br><span data-ttu-id="b8706-177">**注** フォルダー名には、任意の [BCP 47 言語タグ](http://go.microsoft.com/fwlink/p/?linkid=227302)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="b8706-177">**Note** For the folder name, you can use any [BCP-47 language tag](http://go.microsoft.com/fwlink/p/?linkid=227302).</span></span> <span data-ttu-id="b8706-178">言語修飾子の詳しい情報と共通の言語タグの一覧は、「[言語、スケール、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b8706-178">See [Tailor your resources for language, scale, and other qualifiers](tailor-resources-lang-scale-contrast.md) for details on the language qualifier and a list of common language tags.</span></span>
   2. <span data-ttu-id="b8706-179">`Strings/de-DE` フォルダー内に `Strings/en-US/Resources.resw` のコピーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b8706-179">Make a copy of `Strings/en-US/Resources.resw` in the `Strings/de-DE` folder.</span></span>
2. <span data-ttu-id="b8706-180">文字列に変換します。</span><span class="sxs-lookup"><span data-stu-id="b8706-180">Translate the strings.</span></span>
    1. <span data-ttu-id="b8706-181">`Strings/de-DE/Resources.resw` を開き、[値] 列の値を翻訳します。</span><span class="sxs-lookup"><span data-stu-id="b8706-181">Open `Strings/de-DE/Resources.resw` and translate the values in the Value column.</span></span> <span data-ttu-id="b8706-182">コメントを翻訳する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="b8706-182">You don't need to translate the comments.</span></span>

    `Strings/de-DE/Resources.resw`

    ![リソースを追加する (ドイツ語)](images/addresource-de-de.png)

<span data-ttu-id="b8706-184">必要に応じて、他の言語について手順 1. と 2. を繰り返すことができます。</span><span class="sxs-lookup"><span data-stu-id="b8706-184">If you like, you can repeat steps 1 and 2 for a further language.</span></span>

`Strings/fr-FR/Resources.resw`

![リソースを追加する (フランス語)](images/addresource-fr-fr.png)

## <a name="test-your-app"></a><span data-ttu-id="b8706-186">アプリのテスト</span><span class="sxs-lookup"><span data-stu-id="b8706-186">Test your app</span></span>

<span data-ttu-id="b8706-187">既定の表示言語に対してアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="b8706-187">Test the app for your default display language.</span></span> <span data-ttu-id="b8706-188">**[設定]** > **[時刻と言語]** > **[地域と言語]** (または**[言語]**) で表示言語を変更し、アプリを再テストできます。</span><span class="sxs-lookup"><span data-stu-id="b8706-188">You can then change the display language in **Settings** > **Time & language** > **Region & language** (or **Language**) and re-test your app.</span></span> <span data-ttu-id="b8706-189">UI やシェルの文字列 (タイトル バー (表示名) やタイルの短い名前など) を確認します。</span><span class="sxs-lookup"><span data-stu-id="b8706-189">Look at strings in your UI and also in the shell (for example, your title bar&mdash;which is your Display name&mdash;and the Short name on your tiles).</span></span>

<span data-ttu-id="b8706-190">**注** 表示言語の設定に一致するフォルダー名が見つかった場合、そのフォルダー内のリソース ファイルが読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="b8706-190">**Note** If a folder name can be found that matches the display language setting, then the Resources File inside that folder is loaded.</span></span> <span data-ttu-id="b8706-191">それ以外の場合、フォールバックが行われ、最終的にはアプリの既定の言語用のリソースになります。</span><span class="sxs-lookup"><span data-stu-id="b8706-191">Otherwise, fallback takes place, ending with the resources for your app's default language.</span></span>

## <a name="factoring-strings-into-multiple-resources-files"></a><span data-ttu-id="b8706-192">文字列を複数のリソース ファイルにファクタリングする</span><span class="sxs-lookup"><span data-stu-id="b8706-192">Factoring strings into multiple Resources Files</span></span>

<span data-ttu-id="b8706-193">1 つのリソース ファイル (resw) にすべての文字列を保持することも、複数のリソース ファイルに文字列をファクタリングすることもできます。</span><span class="sxs-lookup"><span data-stu-id="b8706-193">You can keep all of your strings in a single Resources File (resw), or you can factor them across multiple Resources Files.</span></span> <span data-ttu-id="b8706-194">たとえば、エラー メッセージを 1 つのリソース ファイルに、アプリ パッケージ マニフェストの文字列を別のリソース ファイルに、UI の文字列を第 3 のリソース ファイルに保持することができます。</span><span class="sxs-lookup"><span data-stu-id="b8706-194">For example, you might want to keep your error messages in one Resources File, your app package manifest strings in another, and your UI strings in a third.</span></span> <span data-ttu-id="b8706-195">この場合、フォルダー構造は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="b8706-195">This is what your folder structure would look like in that case.</span></span>

![リソースの追加 (英語)](images/manifest-resources.png)

<span data-ttu-id="b8706-197">文字列リソース識別子の参照を特定のファイルに限定する場合は、識別子の前に `/<resources-file-name>/` を追加するだけです。</span><span class="sxs-lookup"><span data-stu-id="b8706-197">To scope a string resource identifier reference to a particular file, you just add `/<resources-file-name>/` before the identifier.</span></span> <span data-ttu-id="b8706-198">次のマークアップの例では、`ErrorMessages.resw` にリソースが含まれており、その名前が "PasswordTooWeak.Text" であり、その値がエラーの説明であることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="b8706-198">The markup example below assumes that `ErrorMessages.resw` contains a resource whose name is "PasswordTooWeak.Text" and whose value describes the error.</span></span>

**<span data-ttu-id="b8706-199">XAML</span><span class="sxs-lookup"><span data-stu-id="b8706-199">XAML</span></span>**
```xml
<TextBlock x:Uid="/ErrorMessages/PasswordTooWeak"/>
```

<span data-ttu-id="b8706-200">次のコードの例では、`ErrorMessages.resw` にリソースが含まれており、その名前が "MismatchedPasswords" であり、その値がエラーの説明であることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="b8706-200">The code example below assumes that `ErrorMessages.resw` contains a resource whose name is "MismatchedPasswords" and whose value describes the error.</span></span>

**<span data-ttu-id="b8706-201">C#</span><span class="sxs-lookup"><span data-stu-id="b8706-201">C#</span></span>**
```csharp
var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("ManifestResources");
this.myXAMLTextBlockElement.Text = resourceLoader.GetString("/ErrorMessages/MismatchedPasswords");
```

**<span data-ttu-id="b8706-202">C++</span><span class="sxs-lookup"><span data-stu-id="b8706-202">C++</span></span>**
```cpp
auto resourceLoader = Windows::ApplicationModel::Resources::ResourceLoader::GetForCurrentView("ManifestResources");
this->myXAMLTextBlockElement->Text = resourceLoader->GetString("/ErrorMessages/MismatchedPasswords");
```

<span data-ttu-id="b8706-203">"AppDisplayName" リソースを `Resources.resw` から `ManifestResources.resw` に移動する場合は、アプリ パッケージ マニフェストで `ms-resource:AppDisplayName` を `ms-resource:/ManifestResources/AppDisplayName` に変更します。</span><span class="sxs-lookup"><span data-stu-id="b8706-203">If you were to move your "AppDisplayName" resource out of `Resources.resw` and into `ManifestResources.resw` then in your app package manifest you would change `ms-resource:AppDisplayName` to `ms-resource:/ManifestResources/AppDisplayName`.</span></span>

<span data-ttu-id="b8706-204">`Resources.resw` *以外の*リソース ファイルの場合にのみ、文字列リソース識別子の前に `/<resources-file-name>/` を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b8706-204">You only need to add `/<resources-file-name>/` before the string resource identifier for Resources Files *other than* `Resources.resw`.</span></span> <span data-ttu-id="b8706-205">これは、"Resources.resw" が既定のファイル名であり、(このトピックの前の例で行ったように) ファイル名を省略した場合に既定のファイル名が想定されるためです。</span><span class="sxs-lookup"><span data-stu-id="b8706-205">That's because "Resources.resw" is the default file name, so that's what's assumed if you omit a file name (as we did in the earlier examples in this topic).</span></span>

## <a name="load-a-string-for-a-specific-language-or-other-context"></a><span data-ttu-id="b8706-206">特定の言語または他のコンテキスト用の文字列を読み込む</span><span class="sxs-lookup"><span data-stu-id="b8706-206">Load a string for a specific language or other context</span></span>

<span data-ttu-id="b8706-207">既定の [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live) ([**ResourceContext.GetForCurrentView**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_GetForCurrentView) から取得された) には、既定の実行時コンテキスト (つまり、現在のユーザーとコンピューターの設定) を表す、各修飾子名の修飾子の値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b8706-207">The default [**ResourceContext**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live) (obtained from [**ResourceContext.GetForCurrentView**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_GetForCurrentView)) contains a qualifier value for each qualifier name, representing the default runtime context (in other words, the settings for the current user and machine).</span></span> <span data-ttu-id="b8706-208">リソース ファイル (.resw) は、(その名前に含まれる修飾子に基づいて) 実行時コンテキストでの修飾子の値と比較されます。</span><span class="sxs-lookup"><span data-stu-id="b8706-208">Resources Files (.resw) are matched&mdash;based on the qualifiers in their names&mdash;against the qualifier values in that runtime context.</span></span>

<span data-ttu-id="b8706-209">ただし、アプリでシステム設定を上書きし、読み込むリソース ファイルを検索するときに使用する言語、スケール、その他の修飾子の値を明示的に指定することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="b8706-209">But there might be times when you want your app to override the system settings and be explicit about the language, scale, or other qualifier value to use when looking for a matching Resources File to load.</span></span> <span data-ttu-id="b8706-210">たとえば、ユーザーがヒントやエラー メッセージに別の言語を選ぶことができるように設定できます。</span><span class="sxs-lookup"><span data-stu-id="b8706-210">For example, you might want your users to be able to select an alternative language for tooltips or error messages.</span></span>

<span data-ttu-id="b8706-211">そのためには、(既定のものを使用する代わりに) 新しい **ResourceContext** を作成し、その値をオーバーライドして、文字列検索でそのコンテキスト オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="b8706-211">You can do that by constructing a new **ResourceContext** (instead of using the default one), overriding its values, and then using that context object in your string lookups.</span></span>

**<span data-ttu-id="b8706-212">C#</span><span class="sxs-lookup"><span data-stu-id="b8706-212">C#</span></span>**
```csharp
var resourceContext = new Windows.ApplicationModel.Resources.Core.ResourceContext(); // not using ResourceContext.GetForCurrentView
resourceContext.QualifierValues["Language"] = "de-DE";
var resourceMap = Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
this.myXAMLTextBlockElement.Text = resourceMap.GetValue("Farewell", resourceContext).ValueAsString;
```

<span data-ttu-id="b8706-213">上記のコード例で示した **QualifierValues** の使用方法は、任意の修飾子についても適用できます。</span><span class="sxs-lookup"><span data-stu-id="b8706-213">Using **QualifierValues** as in the code example above works for any qualifier.</span></span> <span data-ttu-id="b8706-214">言語の特殊な場合には、代わりに次のようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="b8706-214">For the special case of Language, you can alternatively do this instead.</span></span>

**<span data-ttu-id="b8706-215">C#</span><span class="sxs-lookup"><span data-stu-id="b8706-215">C#</span></span>**
```csharp
resourceContext.Languages = new string[] { "de-DE" };
```

<span data-ttu-id="b8706-216">グローバル レベルで同じ効果を実現するために、既定の **ResourceContext** で修飾子の値を上書きすることが*できます*。</span><span class="sxs-lookup"><span data-stu-id="b8706-216">For the same effect at a global level, you *can* override the qualifier values in the default **ResourceContext**.</span></span> <span data-ttu-id="b8706-217">ただし、その代わりに、[**ResourceContext.SetGlobalQualifierValue**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_) を呼び出すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b8706-217">But instead we advise you to call [**ResourceContext.SetGlobalQualifierValue**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_SetGlobalQualifierValue_System_String_System_String_Windows_ApplicationModel_Resources_Core_ResourceQualifierPersistence_).</span></span> <span data-ttu-id="b8706-218">**SetGlobalQualifierValue** の呼び出しで一度値を設定すると、ResourceContext を検索に使用するたびに、これらの値が既定の **ResourceContext** で有効になります。</span><span class="sxs-lookup"><span data-stu-id="b8706-218">You set values one time with a call to **SetGlobalQualifierValue** and then those values are in effect on the default **ResourceContext** each time you use it for lookups.</span></span>

**<span data-ttu-id="b8706-219">C#</span><span class="sxs-lookup"><span data-stu-id="b8706-219">C#</span></span>**
```csharp
Windows.ApplicationModel.Resources.Core.ResourceContext.SetGlobalQualifierValue("Language", "de-DE");
var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
this.myXAMLTextBlockElement.Text = resourceLoader.GetString("Farewell");
```

<span data-ttu-id="b8706-220">一部の修飾子には、システム データ プロバイダーがあります。</span><span class="sxs-lookup"><span data-stu-id="b8706-220">Some qualifiers have a system data provider.</span></span> <span data-ttu-id="b8706-221">したがって、**SetGlobalQualifierValue** を呼び出す代わりに、プロバイダー独自の API によってプロバイダーを調整できます。</span><span class="sxs-lookup"><span data-stu-id="b8706-221">So, instead of calling **SetGlobalQualifierValue** you could instead adjust the provider through its own API.</span></span> <span data-ttu-id="b8706-222">たとえば、次のコードは、[**PrimaryLanguageOverride**](/uwp/api/Windows.Globalization.ApplicationLanguages?branch=live#Windows_Globalization_ApplicationLanguages_PrimaryLanguageOverride) を設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b8706-222">For example, this code shows how to set [**PrimaryLanguageOverride**](/uwp/api/Windows.Globalization.ApplicationLanguages?branch=live#Windows_Globalization_ApplicationLanguages_PrimaryLanguageOverride).</span></span>

**<span data-ttu-id="b8706-223">C#</span><span class="sxs-lookup"><span data-stu-id="b8706-223">C#</span></span>**
```csharp
Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "de-DE";
```

## <a name="updating-strings-in-response-to-qualifier-value-change-events"></a><span data-ttu-id="b8706-224">修飾子の値の変更イベントへの応答で文字列を更新する</span><span class="sxs-lookup"><span data-stu-id="b8706-224">Updating strings in response to qualifier value change events</span></span>

<span data-ttu-id="b8706-225">実行中のアプリは、既定の **ResourceContext** で修飾子の値に影響を与えるシステム設定の変更に応答できます。</span><span class="sxs-lookup"><span data-stu-id="b8706-225">Your running app can respond to changes in system settings that affect the qualifier values in the default **ResourceContext**.</span></span> <span data-ttu-id="b8706-226">これらのシステム設定のいずれかが、[**ResourceContext.QualifierValues**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues) の [**MapChanged**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_?branch=live#Windows_Foundation_Collections_IObservableMap_2_MapChanged) イベントを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b8706-226">Any of these system settings invokes the [**MapChanged**](/uwp/api/windows.foundation.collections.iobservablemap_k_v_?branch=live#Windows_Foundation_Collections_IObservableMap_2_MapChanged) event on [**ResourceContext.QualifierValues**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live#Windows_ApplicationModel_Resources_Core_ResourceContext_QualifierValues).</span></span>

<span data-ttu-id="b8706-227">このイベントへの応答で、既定の **ResourceContext** から文字列を再読み込みすることができます。</span><span class="sxs-lookup"><span data-stu-id="b8706-227">In response to this event, you can reload your strings from the default **ResourceContext**.</span></span>

**<span data-ttu-id="b8706-228">C#</span><span class="sxs-lookup"><span data-stu-id="b8706-228">C#</span></span>**
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
    var dispatcher = this.myXAMLTextBlockElement.Dispatcher;
    if (dispatcher.HasThreadAccess)
    {
        this.RefreshUIText();
    }
    else
    {
        await dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => this.RefreshUIText());
    }
}

private void RefreshUIText()
{
    var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
    this.myXAMLTextBlockElement.Text = resourceLoader.GetString("Farewell");
}
```

## <a name="loading-strings-from-a-class-library-or-a-windows-runtime-library"></a><span data-ttu-id="b8706-229">クラス ライブラリまたは Windows ランタイム ライブラリから文字列を読み込む</span><span class="sxs-lookup"><span data-stu-id="b8706-229">Loading strings from a Class Library or a Windows Runtime Library</span></span>

<span data-ttu-id="b8706-230">参照されているクラス ライブラリ (ユニバーサル Windows) または [Windows ランタイム ライブラリ (ユニバーサル Windows)](../winrt-components/index.md) の文字列リソースは、通常、構築プロセス中にそれらが含まれているパッケージのサブフォルダーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b8706-230">The string resources of a referenced Class Library (Universal Windows) or [Windows Runtime Library (Universal Windows)](../winrt-components/index.md) are typically added into a subfolder of the package in which they're included during the build process.</span></span> <span data-ttu-id="b8706-231">このような文字列のリソース識別子は、通常、*LibraryName/ResourcesFileName/ResourceIdentifier* という形式になります。</span><span class="sxs-lookup"><span data-stu-id="b8706-231">The resource identifier of such a string usually takes the form *LibraryName/ResourcesFileName/ResourceIdentifier*.</span></span>

<span data-ttu-id="b8706-232">ライブラリは、独自のリソースについて、ResourceLoader を取得できます。</span><span class="sxs-lookup"><span data-stu-id="b8706-232">A library can get a ResourceLoader for its own resources.</span></span> <span data-ttu-id="b8706-233">たとえば、次のコードは、ライブラリ、またはそれを参照するアプリで、ライブラリの文字列リソースの ResourceLoader を取得できます。</span><span class="sxs-lookup"><span data-stu-id="b8706-233">For example, the following code illustrates how either a library or an app that references it can can get a ResourceLoader for the library's string resources.</span></span>

**<span data-ttu-id="b8706-234">C#</span><span class="sxs-lookup"><span data-stu-id="b8706-234">C#</span></span>**
```csharp
var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader("ContosoControl/Resources");
resourceLoader.GetString("string1");
```

## <a name="loading-strings-from-other-packages"></a><span data-ttu-id="b8706-235">他のパッケージから文字列を読み込む</span><span class="sxs-lookup"><span data-stu-id="b8706-235">Loading strings from other packages</span></span>

<span data-ttu-id="b8706-236">アプリ パッケージのリソースは、現在の [ResourceManager](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) からアクセスできる、パッケージ独自のトップ レベルの [ResourceMap](/uwp/api/windows.applicationmodel.resources.core.resourcemap?branch=live) を介して管理され、アクセスされます。</span><span class="sxs-lookup"><span data-stu-id="b8706-236">The resources for an app package are managed and accessed through the package's own top-level [ResourceMap](/uwp/api/windows.applicationmodel.resources.core.resourcemap?branch=live) that's accessible from the current [ResourceManager](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live).</span></span> <span data-ttu-id="b8706-237">各パッケージ内では、さまざまなコンポーネントが独自の ResourceMap サブツリーを持つことができます。これらは、[ResourceMap.GetSubtree](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceMap#Windows_ApplicationModel_Resources_Core_ResourceMap_GetSubtree_System_String_) によってアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="b8706-237">Within each package, various components can have their own ResourceMap subtrees, which you can access via [ResourceMap.GetSubtree](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceMap#Windows_ApplicationModel_Resources_Core_ResourceMap_GetSubtree_System_String_).</span></span>

<span data-ttu-id="b8706-238">フレームワーク パッケージは、絶対リソース識別子 URI を使って独自のリソースにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="b8706-238">A framework package can access its own resources with an absolute resource identifier URI.</span></span> <span data-ttu-id="b8706-239">「[URI スキーム](uri-schemes.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b8706-239">Also see [URI schemes](uri-schemes.md).</span></span>

## <a name="important-apis"></a><span data-ttu-id="b8706-240">重要な API</span><span class="sxs-lookup"><span data-stu-id="b8706-240">Important APIs</span></span>

* [<span data-ttu-id="b8706-241">ApplicationModel.Resources.ResourceLoader</span><span class="sxs-lookup"><span data-stu-id="b8706-241">ApplicationModel.Resources.ResourceLoader</span></span>](https://msdn.microsoft.com/library/windows/apps/br206014)

## <a name="related-topics"></a><span data-ttu-id="b8706-242">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b8706-242">Related topics</span></span>

* [<span data-ttu-id="b8706-243">XAML と UI の移植</span><span class="sxs-lookup"><span data-stu-id="b8706-243">Porting XAML and UI</span></span>](../porting/wpsl-to-uwp-porting-xaml-and-ui.md#localization-and-globalization)
* [<span data-ttu-id="b8706-244">x:Uid ディレクティブ</span><span class="sxs-lookup"><span data-stu-id="b8706-244">x:Uid directive</span></span>](../xaml-platform/x-uid-directive.md)
* [<span data-ttu-id="b8706-245">アタッチされるプロパティ</span><span class="sxs-lookup"><span data-stu-id="b8706-245">attached properties</span></span>](../xaml-platform/attached-properties-overview.md)
* [<span data-ttu-id="b8706-246">マニフェストのローカライズ可能な項目</span><span class="sxs-lookup"><span data-stu-id="b8706-246">Localizable manifest items</span></span>](/uwp/schemas/appxpackage/uapmanifestschema/localizable-manifest-items-win10?branch=live)
* [<span data-ttu-id="b8706-247">BCP-47 言語タグ</span><span class="sxs-lookup"><span data-stu-id="b8706-247">BCP-47 language tag</span></span>](http://go.microsoft.com/fwlink/p/?linkid=227302)
* [<span data-ttu-id="b8706-248">言語、スケール、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="b8706-248">Tailor your resources for language, scale, and other qualifiers</span></span>](tailor-resources-lang-scale-contrast.md)
* [<span data-ttu-id="b8706-249">文字列リソースを読み込む方法</span><span class="sxs-lookup"><span data-stu-id="b8706-249">How to load string resources</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)