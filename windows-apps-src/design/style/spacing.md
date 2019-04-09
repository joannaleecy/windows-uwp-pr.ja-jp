---
title: 空白文字とサイズ
description: 新しい Fluent 標準と Compact コントロールのスタイルは、デバイスと入力方法に関係なく快適なユーザー エクスペリエンスを確認します。
keywords: UWP、Windows 10、コントロール、サイズ、密度、standard、compact
ms.date: 4/4/2019
ms.topic: article
ms.localizationpriority: medium
ms.custom: 19H1
ms.openlocfilehash: 7b74e3dc2ad047d9e52509b71ef00b829ad63a0d
ms.sourcegitcommit: 7a1d5198345d114c58287d8a047eadc4fe10f012
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59249454"
---
# <a name="control-size-and-density"></a><span data-ttu-id="f9162-104">コントロールのサイズおよび密度</span><span class="sxs-lookup"><span data-stu-id="f9162-104">Control size and density</span></span>

<span data-ttu-id="f9162-105">コントロールのサイズおよび密度の組み合わせを使用して、ユニバーサル Windows プラットフォーム (UWP) アプリケーションを最適化し、アプリの機能との対話の要件について最適なユーザー エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="f9162-105">Use a combination of control size and density to optimize your Universal Windows Platform (UWP) application and provide a user experience that is most appropriate for your app's functionality and interaction requirements.</span></span>

<span data-ttu-id="f9162-106">既定では、UWP アプリをレンダリングする際、低密度 (または`Standard`) レイアウト。</span><span class="sxs-lookup"><span data-stu-id="f9162-106">By default, UWP apps are rendered with a low-density (or `Standard`) layout.</span></span> <span data-ttu-id="f9162-107">ただし、以降、高密度、WinUI 2.1 で (または`Compact`) レイアウト オプションでは、情報豊富な UI と同様の特殊なシナリオもサポートされます。</span><span class="sxs-lookup"><span data-stu-id="f9162-107">However, beginning with WinUI 2.1, a high-density (or `Compact`) layout option, for information rich UI and similar specialized scenarios, is also supported.</span></span> <span data-ttu-id="f9162-108">これは基本的なスタイル リソースを使用して指定できます (次の例を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="f9162-108">This can be specified through a basic style resource (see examples below).</span></span>

<span data-ttu-id="f9162-109">機能と動作が変更されていないと、2 つの間で一貫性が保た 14 px これら 2 つの密度のオプションをサポートするすべてのコントロールのサイズおよび密度のオプション、既定の本文フォント サイズが更新されました。</span><span class="sxs-lookup"><span data-stu-id="f9162-109">While functionality and behavior has not changed and remains consistent across the two size and density options, the default body font size has been updated to 14px for all controls to support these two density options.</span></span> <span data-ttu-id="f9162-110">このフォント サイズはリージョンとデバイス間で機能し、により、アプリケーションはバランスの取れたとユーザーの満足します。</span><span class="sxs-lookup"><span data-stu-id="f9162-110">This font size works across regions and devices and ensures your application remains balanced and comfortable for users.</span></span>

## <a name="fluent-standard-sizing"></a><span data-ttu-id="f9162-111">標準の Fluent のサイズ変更</span><span class="sxs-lookup"><span data-stu-id="f9162-111">Fluent Standard sizing</span></span>

<span data-ttu-id="f9162-112">*標準のサイズ変更の Fluent*情報密度とユーザーの快適性のバランスを提供するが作成されました。</span><span class="sxs-lookup"><span data-stu-id="f9162-112">*Fluent Standard sizing* was created to provide a balance between information density and user comfort.</span></span> <span data-ttu-id="f9162-113">実際には、画面上のすべての項目は、UI 要素をグリッドに合わせるし、適切にスケーリングできますが、システム レベルのスケールに基づいて、40 x 40 有効ピクセル (epx) のターゲットに揃えます。</span><span class="sxs-lookup"><span data-stu-id="f9162-113">Effectively, all items on the screen align to a 40x40 effective pixels (epx) target, which lets UI elements align to a grid and scale appropriately based on system level scaling.</span></span>

**<span data-ttu-id="f9162-114">標準のサイズは、タッチとポインター入力の両方に対応するために設計されています。</span><span class="sxs-lookup"><span data-stu-id="f9162-114">Standard sizing is designed to accommodate both touch and pointer input.</span></span>**

> [!NOTE]
><span data-ttu-id="f9162-115">有効ピクセルとスケーリングの詳細については、次を参照してください[UWP アプリのデザインの概要。](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)</span><span class="sxs-lookup"><span data-stu-id="f9162-115">For more info on effective pixels and scaling, see [Introduction to UWP app design](../basics/design-and-ui-intro.md#effective-pixels-and-scaling)</span></span>
>
> <span data-ttu-id="f9162-116">システム レベルのスケーリングの詳細については、次を参照してください。[配置、余白、パディング](../layout/alignment-margin-padding.md)します。</span><span class="sxs-lookup"><span data-stu-id="f9162-116">For more info on system level scaling, see [Alignment, margin, padding](../layout/alignment-margin-padding.md).</span></span>

<span data-ttu-id="f9162-117">Windows 10 年 10 月のすべての使用状況シナリオの使いやすさを向上させる 2018 Update (バージョンは 1809)、standard、UWP コントロールのすべての既定のサイズが減少しました。</span><span class="sxs-lookup"><span data-stu-id="f9162-117">For the Windows 10 October 2018 Update (version 1809), the standard, default size for all UWP controls was decreased to increase usability across all usage scenarios.</span></span>

<span data-ttu-id="f9162-118">次の図は、コントロールのレイアウトの変更、Windows で導入された 10 年 2018年 10 月の更新します。</span><span class="sxs-lookup"><span data-stu-id="f9162-118">The following image shows some of the control layout changes that were introduced with the Windows 10 October 2018 Update.</span></span> <span data-ttu-id="f9162-119">具体的には、ヘッダー コントロールの上端との間の余白に 8epx から 4epx に減少しましたし、44epx グリッドが 40epx グリッドに変更されました。</span><span class="sxs-lookup"><span data-stu-id="f9162-119">Specifically, the margin between a header and the top of a control was decreased from 8epx to 4epx, and the 44epx grid was changed to a 40epx grid.</span></span>

![標準コントロールのレイアウトの例](images/standarddensity.png)

*<span data-ttu-id="f9162-121">標準コントロールのレイアウトの例</span><span class="sxs-lookup"><span data-stu-id="f9162-121">Standard control layout example</span></span>*

<span data-ttu-id="f9162-122">この次の画像は、Windows 用のサイズの制御に加えられた変更を示しています。 10 年 10 月 2018 の更新。</span><span class="sxs-lookup"><span data-stu-id="f9162-122">This next image shows the changes made to control sizes for the Windows 10 October 2018 Update.</span></span> <span data-ttu-id="f9162-123">具体的には、40epx グリッドに配置します。</span><span class="sxs-lookup"><span data-stu-id="f9162-123">Specifically, alignment to the 40epx grid.</span></span>

![標準のコマンド実行例](images/standarddensitycommanding.png)

## <a name="fluent-compact-sizing"></a><span data-ttu-id="f9162-125">Fluent のコンパクト サイズ変更</span><span class="sxs-lookup"><span data-stu-id="f9162-125">Fluent Compact sizing</span></span>

<span data-ttu-id="f9162-126">Compact のサイズ変更は、コントロールの高密度、情報が豊富なグループを有効し、次のようにできます。</span><span class="sxs-lookup"><span data-stu-id="f9162-126">Compact sizing enables dense, information-rich groups of controls and can help with the following:</span></span>

- <span data-ttu-id="f9162-127">大量のコンテンツを参照します。</span><span class="sxs-lookup"><span data-stu-id="f9162-127">Browsing  large amounts of content.</span></span>
- <span data-ttu-id="f9162-128">ページに表示されるコンテンツの最大化します。</span><span class="sxs-lookup"><span data-stu-id="f9162-128">Maximizing visible content on a page.</span></span>
- <span data-ttu-id="f9162-129">移動して、コントロールやコンテンツと対話します。</span><span class="sxs-lookup"><span data-stu-id="f9162-129">Navigating and interacting with controls and content</span></span>

**<span data-ttu-id="f9162-130">Compact のサイズ変更は、ポインター入力の対応するために主に設計されています。</span><span class="sxs-lookup"><span data-stu-id="f9162-130">Compact sizing is designed primarily to accommodate pointer input.</span></span>**

### <a name="examples"></a><span data-ttu-id="f9162-131">例</span><span class="sxs-lookup"><span data-stu-id="f9162-131">Examples</span></span>

<span data-ttu-id="f9162-132">Compact のサイズ変更は、ページ レベルで、または特定のレイアウトで、アプリケーションで指定できる特殊なリソース ディクショナリを介して実装されます。</span><span class="sxs-lookup"><span data-stu-id="f9162-132">Compact sizing is implemented through a special resource dictionary that can be specified in your application at either the page level or on a specific layout.</span></span> <span data-ttu-id="f9162-133">リソース ディクショナリがで使用できる、 [WinUI](https://docs.microsoft.com/en-us/uwp/toolkits/winui/) Nuget パッケージ。</span><span class="sxs-lookup"><span data-stu-id="f9162-133">The resource dictionary is available in the [WinUI](https://docs.microsoft.com/en-us/uwp/toolkits/winui/) Nuget package.</span></span>

<span data-ttu-id="f9162-134">次の例に示す方法、`Compact`ページと個々 のグリッド コントロールのスタイルを適用できます。</span><span class="sxs-lookup"><span data-stu-id="f9162-134">The following examples show how the the `Compact` style can be applied for the page and an individual Grid control.</span></span>

#### <a name="page-level"></a><span data-ttu-id="f9162-135">ページレベルのロック</span><span class="sxs-lookup"><span data-stu-id="f9162-135">Page level</span></span>

```xaml
<Page.Resources>
    <ResourceDictionary Source="ms-appx:///Microsoft.UI.Xaml/DensityStyles/Compact.xaml" />
</Page.Resources>
```

#### <a name="grid-level"></a><span data-ttu-id="f9162-136">グリッド レベル</span><span class="sxs-lookup"><span data-stu-id="f9162-136">Grid level</span></span>

```xaml
<Grid>
    <Grid.Resources>
        <ResourceDictionary Source="ms-appx:///Microsoft.UI.Xaml/DensityStyles/Compact.xaml" />
    </Grid.Resources>
</Grid>
```

## <a name="related-articles"></a><span data-ttu-id="f9162-137">関連記事</span><span class="sxs-lookup"><span data-stu-id="f9162-137">Related articles</span></span>

- [<span data-ttu-id="f9162-138">タッチの対象とするためのガイドライン</span><span class="sxs-lookup"><span data-stu-id="f9162-138">Guidelines for touch targets</span></span>](../input/guidelines-for-targeting.md)
- [<span data-ttu-id="f9162-139">ResourceDictionary と XAML リソースの参照</span><span class="sxs-lookup"><span data-stu-id="f9162-139">ResourceDictionary and XAML resource references</span></span>](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/resourcedictionary-and-xaml-resource-references)
- [<span data-ttu-id="f9162-140">リソース ディクショナリ</span><span class="sxs-lookup"><span data-stu-id="f9162-140">Resource Dictionary</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.resourcedictionary)
- [<span data-ttu-id="f9162-141">XAML スタイル</span><span class="sxs-lookup"><span data-stu-id="f9162-141">XAML Styles</span></span>](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/xaml-styles) 
