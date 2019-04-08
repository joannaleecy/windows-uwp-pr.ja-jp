---
Description: RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを設計します。
title: レイアウトやフォントの調整と RTL のサポート
ms.assetid: F2522B07-017D-40F1-B3C8-C4D0DFD03AC3
label: Adjust layout and fonts, and support RTL
template: detail.hbs
ms.date: 05/11/2018
ms.topic: article
keywords: Windows 10, UWP, ローカライズの可否, ローカライズ, RTL, LTR
ms.localizationpriority: medium
ms.openlocfilehash: e428dd068337ecd79992e8e27cd193bed112d9c2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645307"
---
# <a name="adjust-layout-and-fonts-and-support-rtl"></a><span data-ttu-id="3aeb2-104">レイアウトやフォントの調整と RTL のサポート</span><span class="sxs-lookup"><span data-stu-id="3aeb2-104">Adjust layout and fonts, and support RTL</span></span>
<span data-ttu-id="3aeb2-105">RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを設計します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-105">Design your app to support the layouts and fonts of multiple languages, including RTL (right-to-left) flow direction.</span></span> <span data-ttu-id="3aeb2-106">テキストの方向はスクリプトに書き込みが行われて表示される方向であり、ページの UI 要素は目で走査されます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-106">Flow direction is the direction in which script is written and displayed, and the UI elements on the page are scanned by the eye.</span></span>

## <a name="layout-guidelines"></a><span data-ttu-id="3aeb2-107">レイアウトのガイドライン</span><span class="sxs-lookup"><span data-stu-id="3aeb2-107">Layout guidelines</span></span>
<span data-ttu-id="3aeb2-108">ドイツ語やフィンランド語などの言語は通常、英語より多くの文字を使用します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-108">Languages such as German and Finnish typically use more characters than English does.</span></span> <span data-ttu-id="3aeb2-109">極東地域のフォントは通常、高さが必要です。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-109">Far Eastern fonts typically require more height.</span></span> <span data-ttu-id="3aeb2-110">アラビア語やヘブライ語などの言語では、レイアウト パネルとテキスト要素を読む方向に合わせて右から左 (RTL) に配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-110">And languages such as Arabic and Hebrew require that layout panels and text elements be laid out in right-to-left (RTL) reading order.</span></span>

<span data-ttu-id="3aeb2-111">翻訳済みのテキストのメトリックでのこれらのバリエーションのため、絶対配置、固定幅、固定高をユーザー インターフェイス (UI) に組み込まないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-111">Because of these variations in the metrics of translated text, we recommend that you don't bake absolute positioning, fixed widths, or fixed heights into your user interface (UI).</span></span> <span data-ttu-id="3aeb2-112">代わりに、Windows UI 要素に組み込まれている動的なレイアウト メカニズムを利用します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-112">Instead, take advantage of the dynamic layout mechanisms that are built into the Windows UI elements.</span></span> <span data-ttu-id="3aeb2-113">たとえば、コンテンツ コントロール (ボタンなど)、アイテム コントロール (グリッド ビューやリスト ビューなど)、レイアウト パネル (グリッドや StackPanel など) は自動的にサイズ変更され、既定ではコンテンツに合わせて再配置されます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-113">For example, content controls (such as buttons), items controls (such as grid views and list views), and layout panels (such as grids and stackpanels) automatically resize and reflow by default to fit their content.</span></span> <span data-ttu-id="3aeb2-114">アプリを擬似言語でローカライズすると、UI 要素がコンテンツに合わせて正しくサイズ変更されないという、問題のあるエッジ ケースが明らかになります。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-114">Pseudo-localize your app to uncover any problematic edge cases where your UI elements don't size to content properly.</span></span>

<span data-ttu-id="3aeb2-115">動的レイアウトは推奨される手法で、ほとんどの場合に使用することができます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-115">Dynamic layout is the recommended technique, and you'll be able to use it in the majority of cases.</span></span> <span data-ttu-id="3aeb2-116">あまり好ましくありませんが、UI マークアップにサイズを組み込むことより望ましい方法として、レイアウト値を言語の関数として設定します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-116">Less preferable, but still better than baking sizes into your UI markup, is to set layout values as a function of language.</span></span> <span data-ttu-id="3aeb2-117">アプリ内に、ローカライズ担当者が言語ごとに適切に設定できるリソースとして Width プロパティを表示する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-117">Here's an example of how you can expose a Width property in your app as a resource that localizers can set appropriately per language.</span></span> <span data-ttu-id="3aeb2-118">最初に、アプリのリソース ファイル (.resw) で "TitleText.Width" という名前のプロパティ識別子を追加します ("TitleText" の代わりに任意の名前を使用できます)。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-118">First, in your app's Resources File (.resw), add a property identifier with the name "TitleText.Width" (instead of "TitleText", you can use any name you like).</span></span> <span data-ttu-id="3aeb2-119">次に、**x:Uid** を使用して 1 つ以上の UI 要素をこのプロパティ識別子に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-119">Then, use an **x:Uid** to associate one or more UI elements with this property identifier.</span></span>

```xaml
<TextBlock x:Uid="TitleText">
```

<span data-ttu-id="3aeb2-120">リソース ファイル (.resw)、プロパティ識別子、**x:Uid** の詳細については、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../../app-resources/localize-strings-ui-manifest.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-120">For more info about Resources Files (.resw), property identifiers, and **x:Uid**, see [Localize strings in your UI and app package manifest](../../app-resources/localize-strings-ui-manifest.md).</span></span>

## <a name="fonts"></a><span data-ttu-id="3aeb2-121">フォント</span><span class="sxs-lookup"><span data-stu-id="3aeb2-121">Fonts</span></span>
<span data-ttu-id="3aeb2-122">特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[**LanguageFont**](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live) フォント マッピング クラスを使ってください。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-122">Use the [**LanguageFont**](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live) font-mapping class for programmatic access to the recommended font family, size, weight, and style for a particular language.</span></span> <span data-ttu-id="3aeb2-123">**LanguageFont** クラスを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-123">The **LanguageFont** class provides access to the correct font info for various categories of content including UI headers, notifications, body text, and user-editable document body fonts.</span></span>

## <a name="mirroring-images"></a><span data-ttu-id="3aeb2-124">画像の左右反転</span><span class="sxs-lookup"><span data-stu-id="3aeb2-124">Mirroring images</span></span>
<span data-ttu-id="3aeb2-125">RTL に対応するために左右反転が必要な画像がアプリに含まれる (つまり、同じ画像を反転できる) 場合は、**FlowDirection** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-125">If your app has images that must be mirrored (that is, the same image can be flipped) for RTL, then you can use **FlowDirection**.</span></span>

```xaml
<!-- en-US\localized.xaml -->
<Image ... FlowDirection="LeftToRight" />

<!-- ar-SA\localized.xaml -->
<Image ... FlowDirection="RightToLeft" />
```

<span data-ttu-id="3aeb2-126">画像を正しく反転させるためにアプリで別の画像が必要な場合は、`LayoutDirection` 修飾子 ([言語、スケール、その他の修飾子用にリソースを調整する](../../app-resources/tailor-resources-lang-scale-contrast.md#layoutdirection) の LayoutDirection セクションを参照) を指定してリソース管理システムを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-126">If your app requires a different image to flip the image correctly, then you can use the resource management system with the `LayoutDirection` qualifier (see the LayoutDirection section of [Tailor your resources for language, scale, and other qualifiers](../../app-resources/tailor-resources-lang-scale-contrast.md#layoutdirection)).</span></span> <span data-ttu-id="3aeb2-127">アプリのランタイム言語が RTL 言語に設定されている場合 (「[ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)」を参照)、システムは `file.layoutdir-rtl.png` という名前が付いたイメージを選びます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-127">The system chooses an image named `file.layoutdir-rtl.png` when the app runtime language (see [Understand user profile languages and app manifest languages](manage-language-and-region.md)) is set to an RTL language.</span></span> <span data-ttu-id="3aeb2-128">画像の一部を反転させ、他の部分は反転させないという場合には、この方法が必要になることもあります。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-128">This approach may be necessary when some part of the image is flipped, but another part isn't.</span></span>

## <a name="handling-right-to-left-rtl-languages"></a><span data-ttu-id="3aeb2-129">右から左に書く (RTL) 言語の処理</span><span class="sxs-lookup"><span data-stu-id="3aeb2-129">Handling right-to-left (RTL) languages</span></span>
<span data-ttu-id="3aeb2-130">右から左に書く (RTL) 言語用にアプリをローカライズする場合、[**FrameworkElement.FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを使用し、左右対称のパディングと余白を設定します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-130">When your app is localized for right-to-left (RTL) languages, use the [**FrameworkElement.FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) property, and set symmetrical padding and margins.</span></span> <span data-ttu-id="3aeb2-131">[  **Grid**](/uwp/api/Windows.UI.Xaml.Controls.Grid?branch=live) などのレイアウト パネルは、設定した **FlowDirection** の値を使って自動的に拡大縮小と反転を行います。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-131">Layout panels such as [**Grid**](/uwp/api/Windows.UI.Xaml.Controls.Grid?branch=live) scale and flip automatically with the value of **FlowDirection** that you set.</span></span>

<span data-ttu-id="3aeb2-132">Page のルート レイアウト パネル (フレーム) または Page 自体で **FlowDirection** を設定します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-132">Set **FlowDirection** on the root layout panel (or frame) of your Page, or on the Page itself.</span></span> <span data-ttu-id="3aeb2-133">これにより、内部に含まれるすべてのコントロールがそのプロパティを継承します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-133">This causes all of the controls contained within to inherit that property.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="3aeb2-134">ただし、**FlowDirection** は Windows 設定のユーザーが選択した表示言語に基づいて自動的に設定されるものでは*なく*、ユーザーの表示言語の切り替えに応じて動的に変更されるものでもありません。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-134">However, **FlowDirection** is *not* set automatically based on the user's selected display language in Windows settings; nor does it change dynamically in response to the user switching display language.</span></span> <span data-ttu-id="3aeb2-135">たとえば、ユーザーが Windows 設定を英語からアラビア語に切り替えた場合、**FlowDirection** プロパティは (左から右) から (右から左) に自動的に変更*されません*。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-135">If the user switches Windows settings from English to Arabic, for example, then the **FlowDirection** property will *not* automatically change from left-to-right to right-to-left.</span></span> <span data-ttu-id="3aeb2-136">アプリ開発者は、現在表示している言語に応じて **FlowDirection** を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-136">As the app developer, you have to set **FlowDirection** appropriately for the language that you are currently displaying.</span></span>

<span data-ttu-id="3aeb2-137">プログラムによる手法は、ユーザーの優先される表示言語の `LayoutDirection` プロパティを使用して [**FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを設定することです (以下のコード例を参照)。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-137">The programmatic technique is to use the `LayoutDirection` property of the preferred user display language to set the [**FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) property (see the code example below).</span></span> <span data-ttu-id="3aeb2-138">Windows に含まれているほとんどのコントロールでは、既に **FlowDirection** が使われています。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-138">Most controls included in Windows use **FlowDirection** already.</span></span> <span data-ttu-id="3aeb2-139">カスタム コントロールを実装する場合は、**FlowDirection** を使って RTL 言語と LTR 言語で適切なレイアウト変更を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-139">If you're implementing a custom control, it should use **FlowDirection** to make appropriate layout changes for RTL and LTR languages.</span></span>

```csharp    
this.languageTag = Windows.Globalization.ApplicationLanguages.Languages[0];

// For bidirectional languages, determine flow direction for the root layout panel, and all contained UI.

var flowDirectionSetting = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues["LayoutDirection"];
if (flowDirectionSetting == "LTR")
{
    this.layoutRoot.FlowDirection = Windows.UI.Xaml.FlowDirection.LeftToRight;
}
else
{
    this.layoutRoot.FlowDirection = Windows.UI.Xaml.FlowDirection.RightToLeft;
}
```

```cppwinrt
#include <winrt/Windows.ApplicationModel.Resources.Core.h>
#include <winrt/Windows.Globalization.h>
...

m_languageTag = Windows::Globalization::ApplicationLanguages::Languages().GetAt(0);

// For bidirectional languages, determine flow direction for the root layout panel, and all contained UI.

auto flowDirectionSetting = Windows::ApplicationModel::Resources::Core::ResourceContext::GetForCurrentView().QualifierValues().Lookup(L"LayoutDirection");
if (flowDirectionSetting == L"LTR")
{
    layoutRoot().FlowDirection(Windows::UI::Xaml::FlowDirection::LeftToRight);
}
else
{
    layoutRoot().FlowDirection(Windows::UI::Xaml::FlowDirection::RightToLeft);
}
```

```cpp
this->languageTag = Windows::Globalization::ApplicationLanguages::Languages->GetAt(0);

// For bidirectional languages, determine flow direction for the root layout panel, and all contained UI.

auto flowDirectionSetting = Windows::ApplicationModel::Resources::Core::ResourceContext::GetForCurrentView()->QualifierValues->Lookup("LayoutDirection");
if (flowDirectionSetting == "LTR")
{
    this->layoutRoot->FlowDirection = Windows::UI::Xaml::FlowDirection::LeftToRight;
}
else
{
    this->layoutRoot->FlowDirection = Windows::UI::Xaml::FlowDirection::RightToLeft;
}
```

<span data-ttu-id="3aeb2-140">前に示した手法により **FlowDirection** がユーザーの優先される表示言語の `LayoutDirection` プロパティの関数になります。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-140">The technique above makes **FlowDirection** a function of the `LayoutDirection` property of the preferred user display language.</span></span> <span data-ttu-id="3aeb2-141">何らかの理由でそのロジックを使用しない場合は、アプリ内に、ローカライズ担当者が翻訳対象の各言語用に適切に設定できるリソースとして FlowDirection プロパティを表示できます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-141">If for whatever reason you don't want that logic, then you can expose a FlowDirection property in your app as a resource that localizers can set appropriately for each language they translate into.</span></span>

<span data-ttu-id="3aeb2-142">最初に、アプリのリソース ファイルの (.resw) で "MainPage.FlowDirection" という名前のプロパティ識別子を追加します ("MainPage" の代わりに任意の名前を使用できます)。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-142">First, in your app's Resources File (.resw), add a property identifier with the name "MainPage.FlowDirection" (instead of "MainPage", you can use any name you like).</span></span> <span data-ttu-id="3aeb2-143">次に、**x:Uid** を使用して主要な **Page** 要素 (またはそのルート レイアウト パネルかフレーム) をこのプロパティ識別子に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-143">Then, use an **x:Uid** to associate your main **Page** element (or its root layout panel or frame) with this property identifier.</span></span>

```xaml
<Page x:Uid="MainPage">
```

<span data-ttu-id="3aeb2-144">すべての言語で単一コード行を使用する代わりに、この手法は、翻訳者が翻訳される各言語用にこのプロパティ リソースを正しく "翻訳する" ことに依存します。そのため、この手法を使用する場合は、余分な人的ミスが生じることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-144">Instead of a single line of code for all languages, this depends on the translator "translating" this property resource correctly for each translated language; so be aware that there's that extra opportunity for human error when you use this technique.</span></span>

## <a name="important-apis"></a><span data-ttu-id="3aeb2-145">重要な API</span><span class="sxs-lookup"><span data-stu-id="3aeb2-145">Important APIs</span></span>
* [<span data-ttu-id="3aeb2-146">FrameworkElement.FlowDirection</span><span class="sxs-lookup"><span data-stu-id="3aeb2-146">FrameworkElement.FlowDirection</span></span>](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection)
* [<span data-ttu-id="3aeb2-147">LanguageFont</span><span class="sxs-lookup"><span data-stu-id="3aeb2-147">LanguageFont</span></span>](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live)

## <a name="related-topics"></a><span data-ttu-id="3aeb2-148">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3aeb2-148">Related topics</span></span>
* [<span data-ttu-id="3aeb2-149">UI とアプリ パッケージ マニフェスト内の文字列をローカライズする</span><span class="sxs-lookup"><span data-stu-id="3aeb2-149">Localize strings in your UI and app package manifest</span></span>](../../app-resources/localize-strings-ui-manifest.md)
* [<span data-ttu-id="3aeb2-150">言語、スケール、およびその他の修飾子のためのリソースを調整します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-150">Tailor your resources for language, scale, and other qualifiers</span></span>](../../app-resources/tailor-resources-lang-scale-contrast.md)
* [<span data-ttu-id="3aeb2-151">ユーザー プロファイルの言語とアプリ マニフェストの言語を理解します。</span><span class="sxs-lookup"><span data-stu-id="3aeb2-151">Understand user profile languages and app manifest languages</span></span>](manage-language-and-region.md)