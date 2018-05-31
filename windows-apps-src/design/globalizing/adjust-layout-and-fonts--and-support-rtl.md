---
author: stevewhims
Description: Design your app to support the layouts and fonts of multiple languages, including RTL (right-to-left) flow direction.
title: レイアウトやフォントの調整と RTL のサポート
ms.assetid: F2522B07-017D-40F1-B3C8-C4D0DFD03AC3
label: Adjust layout and fonts, and support RTL
template: detail.hbs
ms.author: stwhi
ms.date: 11/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ローカライズの可否, ローカライズ, RTL, LTR
ms.localizationpriority: medium
ms.openlocfilehash: cf3a2d781dc916fbda9a9d6386dee4e2e6144873
ms.sourcegitcommit: 2470c6596d67e1f5ca26b44fad56a2f89773e9cc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/22/2018
ms.locfileid: "1673979"
---
# <a name="adjust-layout-and-fonts-and-support-rtl"></a><span data-ttu-id="39b3c-103">レイアウトやフォントの調整と RTL のサポート</span><span class="sxs-lookup"><span data-stu-id="39b3c-103">Adjust layout and fonts, and support RTL</span></span>

<span data-ttu-id="39b3c-104">RTL (右から左) のテキストの方向を含め、複数の言語のレイアウトやフォントをサポートするアプリを設計します。</span><span class="sxs-lookup"><span data-stu-id="39b3c-104">Design your app to support the layouts and fonts of multiple languages, including RTL (right-to-left) flow direction.</span></span> <span data-ttu-id="39b3c-105">テキストの方向はスクリプトに書き込みが行われて表示される方向であり、ページの UI 要素は目で走査されます。</span><span class="sxs-lookup"><span data-stu-id="39b3c-105">Flow direction is the direction in which script is written and displayed, and the UI elements on the page are scanned by the eye.</span></span>

## <a name="layout-guidelines"></a><span data-ttu-id="39b3c-106">レイアウトのガイドライン</span><span class="sxs-lookup"><span data-stu-id="39b3c-106">Layout guidelines</span></span>

<span data-ttu-id="39b3c-107">ドイツ語やフィンランド語などの言語は通常、英語より多くの文字を使用します。</span><span class="sxs-lookup"><span data-stu-id="39b3c-107">Languages such as German and Finnish typically use more characters than English does.</span></span> <span data-ttu-id="39b3c-108">極東地域のフォントは通常、高さが必要です。</span><span class="sxs-lookup"><span data-stu-id="39b3c-108">Far Eastern fonts typically require more height.</span></span> <span data-ttu-id="39b3c-109">アラビア語やヘブライ語などの言語では、レイアウト パネルとテキスト要素を読む方向に合わせて右から左 (RTL) に配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-109">And languages such as Arabic and Hebrew require that layout panels and text elements be laid out in right-to-left (RTL) reading order.</span></span>

<span data-ttu-id="39b3c-110">翻訳済みテキストの可変長のため、絶対配置、固定幅、固定高ではなく、動的な UI レイアウト メカニズムを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-110">Because of the variable length of translated text, you should use dynamic UI layout mechanisms instead of absolute positioning, fixed widths, or fixed heights.</span></span> <span data-ttu-id="39b3c-111">アプリを擬似言語でローカライズすると、UI 要素がコンテンツに合わせて正しくサイズ変更されないという、問題のあるエッジ ケースが明らかになります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-111">Pseudo-localizing your app will uncover any problematic edge cases where your UI elements don't size to content properly.</span></span>

<span data-ttu-id="39b3c-112">RTL 言語の場合、[**FrameworkElement.FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを使用し、左右対称のパディングと余白を設定します。</span><span class="sxs-lookup"><span data-stu-id="39b3c-112">For RTL languages, use the [**FrameworkElement.FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) property, and set symmetrical padding and margins.</span></span> <span data-ttu-id="39b3c-113">[**Grid**](/uwp/api/Windows.UI.Xaml.Controls.Grid?branch=live) などのレイアウト パネルは、設定した **FlowDirection** の値を使って自動的に拡大縮小と反転を行います。</span><span class="sxs-lookup"><span data-stu-id="39b3c-113">Layout panels such as [**Grid**](/uwp/api/Windows.UI.Xaml.Controls.Grid?branch=live) scale and flip automatically with the value of **FlowDirection** that you set.</span></span>

<span data-ttu-id="39b3c-114">アプリ内に、ローカライズ担当者が適切に設定できるリソースとして FlowDirection プロパティを表示する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="39b3c-114">Here's an example of how you can expose a FlowDirection property in your app as a resource that localizers can set appropriately.</span></span>

<span data-ttu-id="39b3c-115">最初に、アプリのリソース ファイルの (.resw) で "MainPage.FlowDirection" という名前のプロパティ識別子を追加します ("MainPage" の代わりに任意の名前を使用できます)。</span><span class="sxs-lookup"><span data-stu-id="39b3c-115">First, in your app's Resources File (.resw), add a property identifier with the name "MainPage.FlowDirection" (instead of "MainPage", you can use any name you like).</span></span>

<span data-ttu-id="39b3c-116">次に、**x:Uid** を使用して主要な **Page** 要素をこのプロパティ識別子に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="39b3c-116">Then, use an **x:Uid** to associate your main **Page** element with this property identifier.</span></span>

```xaml
<Page x:Uid="MainPage">
```

<span data-ttu-id="39b3c-117">リソース ファイル (.resw)、プロパティ識別子、**x:Uid** について詳しくは、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../../app-resources/localize-strings-ui-manifest.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="39b3c-117">For more info about Resources Files (.resw), property identifiers, and **x:Uid**, see [Localize strings in your UI and app package manifest](../../app-resources/localize-strings-ui-manifest.md).</span></span>

<span data-ttu-id="39b3c-118">言語に基づいた UI 要素に絶対レイアウトの値を設定することは避ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-118">You should avoid setting absolute layout values on any UI element based on language.</span></span> <span data-ttu-id="39b3c-119">ただし、どうしても避けることができない場合、フォーム "TitleText.Width" のプロパティ識別子を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="39b3c-119">But if it's absolutely unavoidable, then you can create a property identifier of the form "TitleText.Width".</span></span>

```xaml
<TextBlock x:Uid="TitleText">
```

## <a name="fonts"></a><span data-ttu-id="39b3c-120">フォント</span><span class="sxs-lookup"><span data-stu-id="39b3c-120">Fonts</span></span>

<span data-ttu-id="39b3c-121">特定言語の推奨フォント ファミリー、サイズ、太さ、スタイルにプログラムを使ってアクセスする場合は、[**LanguageFont**](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live) フォント マッピング クラスを使ってください。</span><span class="sxs-lookup"><span data-stu-id="39b3c-121">Use the [**LanguageFont**](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live) font-mapping class for programmatic access to the recommended font family, size, weight, and style for a particular language.</span></span> <span data-ttu-id="39b3c-122">**LanguageFont** クラスを使うと、コンテンツのさまざまなカテゴリ (UI ヘッダー、通知、本文のテキスト、ユーザー自身で編集できるドキュメント本文のフォントなど) の正しいフォント情報にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="39b3c-122">The **LanguageFont** class provides access to the correct font info for various categories of content including UI headers, notifications, body text, and user-editable document body fonts.</span></span>

## <a name="mirroring-images"></a><span data-ttu-id="39b3c-123">画像の左右反転</span><span class="sxs-lookup"><span data-stu-id="39b3c-123">Mirroring images</span></span>

<span data-ttu-id="39b3c-124">RTL に対応するために左右反転が必要な画像がアプリに含まれる (つまり、同じ画像を反転できる) 場合は、**FlowDirection** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="39b3c-124">If your app has images that must be mirrored (that is, the same image can be flipped) for RTL, then you can use **FlowDirection**.</span></span>

```xaml
<!-- en-US\localized.xaml -->
<Image ... FlowDirection="LeftToRight" />

<!-- ar-SA\localized.xaml -->
<Image ... FlowDirection="RightToLeft" />
```

<span data-ttu-id="39b3c-125">画像を正しく反転させるためにアプリで別の画像が必要な場合は、`LayoutDirection` 修飾子 ([言語、スケール、その他の修飾子用にリソースを調整する](../../app-resources/tailor-resources-lang-scale-contrast.md#layoutdirection) の LayoutDirection セクションを参照) を指定してリソース管理システムを使用できます。</span><span class="sxs-lookup"><span data-stu-id="39b3c-125">If your app requires a different image to flip the image correctly, then you can use the resource management system with the `LayoutDirection` qualifier (see the LayoutDirection section of [Tailor your resources for language, scale, and other qualifiers](../../app-resources/tailor-resources-lang-scale-contrast.md#layoutdirection)).</span></span> <span data-ttu-id="39b3c-126">アプリのランタイム言語が RTL 言語に設定されている場合 (「[ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)」を参照)、システムは `file.layoutdir-rtl.png` という名前が付いたイメージを選びます。</span><span class="sxs-lookup"><span data-stu-id="39b3c-126">The system chooses an image named `file.layoutdir-rtl.png` when the app runtime language (see [Understand user profile languages and app manifest languages](manage-language-and-region.md)) is set to an RTL language.</span></span> <span data-ttu-id="39b3c-127">画像の一部を反転させ、他の部分は反転させないという場合には、この方法が必要になることもあります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-127">This approach may be necessary when some part of the image is flipped, but another part isn't.</span></span>

## <a name="best-practices-for-handling-right-to-left-rtl-languages"></a><span data-ttu-id="39b3c-128">右から左に書く (RTL) 言語を処理するためのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="39b3c-128">Best practices for handling right-to-left (RTL) languages</span></span>

<span data-ttu-id="39b3c-129">アプリを右から左に書く (RTL) 言語にローカライズする場合、API を使用して Page のルート レイアウト パネルの既定のテキストの方向を設定します。</span><span class="sxs-lookup"><span data-stu-id="39b3c-129">When your app is localized for right-to-left (RTL) languages, use APIs to set the default text direction for the root layout panel of your Page.</span></span> <span data-ttu-id="39b3c-130">これにより、ルート パネルに含まれているすべてのコントロールが、既定のテキストの方向に適切に対応します。</span><span class="sxs-lookup"><span data-stu-id="39b3c-130">This causes all of the controls contained within the root panel to respond appropriately to the default text direction.</span></span> <span data-ttu-id="39b3c-131">複数の言語をサポートする場合は、最も優先順位が高いアプリの実行時の言語の `LayoutDirection` を使用して [**FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) プロパティを設定します (以下のコード例を参照)。</span><span class="sxs-lookup"><span data-stu-id="39b3c-131">When more than one language is supported, use `LayoutDirection` for the top app runtime language to set the [**FlowDirection**](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection) property (see code example below).</span></span> <span data-ttu-id="39b3c-132">Windows に含まれているほとんどのコントロールでは、既に **FlowDirection** が使われています。</span><span class="sxs-lookup"><span data-stu-id="39b3c-132">Most controls included in Windows use **FlowDirection** already.</span></span> <span data-ttu-id="39b3c-133">カスタム コントロールを実装する場合は、**FlowDirection** を使って RTL 言語と LTR 言語で適切なレイアウト変更を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-133">If you are implementing custom controls, they should use **FlowDirection** to make appropriate layout changes for RTL and LTR languages.</span></span>

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

### <a name="rtl-faq"></a><span data-ttu-id="39b3c-134">RTL に関するよくある質問</span><span class="sxs-lookup"><span data-stu-id="39b3c-134">RTL FAQ</span></span> 

<span data-ttu-id="39b3c-135">**Q:** **FlowDirection** は、現在の言語の選択に基づいて自動的に設定されますか?</span><span class="sxs-lookup"><span data-stu-id="39b3c-135">**Q:** Is **FlowDirection** set automatically based on the current language selection?</span></span> <span data-ttu-id="39b3c-136">たとえば、英語を選択すると左から右へ、アラビア語を選択すると右から左へ表示されますか?</span><span class="sxs-lookup"><span data-stu-id="39b3c-136">For example, if I select English will it display left to right, and if I select Arabic, will it display right to left?</span></span>

> <span data-ttu-id="39b3c-137">**A:** **FlowDirection** には、言語によって動作を変える機能はありません。</span><span class="sxs-lookup"><span data-stu-id="39b3c-137">**A:** **FlowDirection** does not take into account the language.</span></span> <span data-ttu-id="39b3c-138">開発者は、現在表示している言語に応じて **FlowDirection** を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-138">You set **FlowDirection** appropriately for the language you are currently displaying.</span></span> <span data-ttu-id="39b3c-139">上のサンプル コードを参照してください。</span><span class="sxs-lookup"><span data-stu-id="39b3c-139">See the sample code above.</span></span>

<span data-ttu-id="39b3c-140">**Q:** ローカライズにあまり詳しくありません。</span><span class="sxs-lookup"><span data-stu-id="39b3c-140">**Q:** I'm not very familiar with localization.</span></span> <span data-ttu-id="39b3c-141">リソースには、テキストの方向があらかじめ含まれていますか?</span><span class="sxs-lookup"><span data-stu-id="39b3c-141">Do the resources already contain flow direction?</span></span> <span data-ttu-id="39b3c-142">現在の言語に基づいてテキストの方向を判断できますか?</span><span class="sxs-lookup"><span data-stu-id="39b3c-142">Is it possible to determine the flow direction from the current language?</span></span>

> <span data-ttu-id="39b3c-143">**A:** 現在のベスト プラクティスを使用している場合、リソースにはテキストの方向は含まれていません。</span><span class="sxs-lookup"><span data-stu-id="39b3c-143">**A:** If you are using current best practices, then resources do not contain flow direction directly.</span></span> <span data-ttu-id="39b3c-144">開発者は、現在の言語に応じてテキストの方向を決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-144">You must determine flow direction for the current language.</span></span> <span data-ttu-id="39b3c-145">これには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-145">Here are two ways to do this.</span></span>
> 
> <span data-ttu-id="39b3c-146">推奨されるのは、最も優先順位が高い言語の **LayoutDirection** を使用して、RootFrame の **FlowDirection** プロパティを設定する方法です。</span><span class="sxs-lookup"><span data-stu-id="39b3c-146">The preferred way is to use the **LayoutDirection** for the top preferred language to set the **FlowDirection** property of the RootFrame.</span></span> <span data-ttu-id="39b3c-147">RootFrame のすべてのコントロールは、RootFrame から FlowDirection を継承します。</span><span class="sxs-lookup"><span data-stu-id="39b3c-147">All the controls in the RootFrame inherit FlowDirection from the RootFrame.</span></span>
> 
> <span data-ttu-id="39b3c-148">もう 1 つは、ローカライズする RTL 言語の .resw ファイルで FlowDirection を設定する方法です。</span><span class="sxs-lookup"><span data-stu-id="39b3c-148">Another way is to set the FlowDirection in the .resw file for the RTL languages you are localizing for.</span></span> <span data-ttu-id="39b3c-149">たとえば、アラビア語にはアラビア語の resw ファイル、ヘブライ語にはヘブライ語の resw ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-149">For example, you might have an Arabic resw file and a Hebrew resw file.</span></span> <span data-ttu-id="39b3c-150">これらのファイルで、x:UID を使用して FlowDirection を設定できます。</span><span class="sxs-lookup"><span data-stu-id="39b3c-150">In these files you could use x:UID to set the FlowDirection.</span></span> <span data-ttu-id="39b3c-151">ただし、この方法はプログラムによる方法よりもエラーが発生しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="39b3c-151">This method is more prone to errors than the programmatic method, though.</span></span>

## <a name="important-apis"></a><span data-ttu-id="39b3c-152">重要な API</span><span class="sxs-lookup"><span data-stu-id="39b3c-152">Important APIs</span></span>

* [<span data-ttu-id="39b3c-153">FrameworkElement.FlowDirection</span><span class="sxs-lookup"><span data-stu-id="39b3c-153">FrameworkElement.FlowDirection</span></span>](/uwp/api/Windows.UI.Xaml.FrameworkElement.FlowDirection)
* [<span data-ttu-id="39b3c-154">LanguageFont</span><span class="sxs-lookup"><span data-stu-id="39b3c-154">LanguageFont</span></span>](/uwp/api/Windows.Globalization.Fonts.LanguageFont?branch=live)

## <a name="related-topics"></a><span data-ttu-id="39b3c-155">関連トピック</span><span class="sxs-lookup"><span data-stu-id="39b3c-155">Related topics</span></span>

* [<span data-ttu-id="39b3c-156">UI とアプリ パッケージ マニフェスト内の文字列をローカライズする</span><span class="sxs-lookup"><span data-stu-id="39b3c-156">Localize strings in your UI and app package manifest</span></span>](../../app-resources/localize-strings-ui-manifest.md)
* [<span data-ttu-id="39b3c-157">言語、スケール、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="39b3c-157">Tailor your resources for language, scale, and other qualifiers</span></span>](../../app-resources/tailor-resources-lang-scale-contrast.md)
* [<span data-ttu-id="39b3c-158">ユーザー プロファイルの言語とアプリ マニフェストの言語について</span><span class="sxs-lookup"><span data-stu-id="39b3c-158">Understand user profile languages and app manifest languages</span></span>](manage-language-and-region.md)