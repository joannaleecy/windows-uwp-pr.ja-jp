---
author: Xansky
description: ハイ コントラスト テーマがアクティブになっているときにユニバーサル Windows プラットフォーム (UWP) アプリを使用できることを確かめるために必要な手順について説明します。
ms.assetid: FD7CA6F6-A8F1-47D8-AA6C-3F2EC3168C45
title: ハイ コントラスト テーマ
template: detail.hbs
ms.author: mhopkins
ms.date: 09/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0a0fde9aecd4b9a07fcddbb1e97c11d2681b41a0
ms.sourcegitcommit: 1773bec0f46906d7b4d71451ba03f47017a87fec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/17/2018
ms.locfileid: "1662162"
---
# <a name="high-contrast-themes"></a><span data-ttu-id="d442f-104">ハイ コントラスト テーマ</span><span class="sxs-lookup"><span data-stu-id="d442f-104">High contrast themes</span></span>  

<span data-ttu-id="d442f-105">Windows では、OS やアプリでハイ コントラスト テーマがサポートされていて、必要に応じて有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="d442f-105">Windows supports high contrast themes for the OS and apps that users may choose to enable.</span></span> <span data-ttu-id="d442f-106">ハイ コントラスト テーマは、少ない数のコントラスト カラーで構成されるパレットを使い、インターフェイスを見やすくします。</span><span class="sxs-lookup"><span data-stu-id="d442f-106">High contrast themes use a small palette of contrasting colors that makes the interface easier to see.</span></span>

![淡色テーマと黒のハイ コントラスト テーマで表示された電卓。](images/high-contrast-calculators.png)

*<span data-ttu-id="d442f-108">淡色テーマと黒のハイ コントラスト テーマで表示された電卓</span><span class="sxs-lookup"><span data-stu-id="d442f-108">Calculator shown in light theme and High Contrast Black theme.</span></span>*

<span data-ttu-id="d442f-109">ハイ コントラスト テーマに切り替えるには、*[設定]、[簡単操作]、[ハイ コントラスト]* の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="d442f-109">You can switch to a high contrast theme by using *Settings > Ease of access > High contrast*.</span></span>

> [!NOTE]
> <span data-ttu-id="d442f-110">ハイ コントラスト テーマは、淡色テーマおよび濃色テーマとは異なることに注意してください。淡色テーマと濃色テーマのカラー パレットは色の種類が豊富で、ハイ コントラストとは見なされません。</span><span class="sxs-lookup"><span data-stu-id="d442f-110">Don't confuse high contrast themes with light and dark themes, which allow a much larger color palette that isn't considered to have high contrast.</span></span> <span data-ttu-id="d442f-111">淡色テーマと濃色テーマについて詳しくは、「[色](../style/color.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d442f-111">For more light and dark themes, see the article on [color](../style/color.md).</span></span>

<span data-ttu-id="d442f-112">コモン コントロールでは、ハイ コントラストが無償で完全にサポートされていますが、UI をカスタマイズする場合は注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d442f-112">While common controls come with full high contrast support for free, care needs to be taken while customizing your UI.</span></span> <span data-ttu-id="d442f-113">ハイ コントラストに関する最も一般的なバグは、コントロールにインラインで色をハードコーディングすることで生じます。</span><span class="sxs-lookup"><span data-stu-id="d442f-113">The most common high contrast bug is caused by hard-coding a color on a control inline.</span></span>

```xaml
<!-- Don't do this! -->
<Grid Background="#E6E6E6">

<!-- Instead, create BrandedPageBackgroundBrush and do this. -->
<Grid Background="{ThemeResource BrandedPageBackgroundBrush}">
```

<span data-ttu-id="d442f-114">最初の例で `#E6E6E6` をインラインで設定すると、グリッドはすべてのテーマでその背景色を保持します。</span><span class="sxs-lookup"><span data-stu-id="d442f-114">When the `#E6E6E6` color is set inline in the first example, the Grid will retain that background color in all themes.</span></span> <span data-ttu-id="d442f-115">ユーザーが黒のハイ コントラスト テーマに切り替えたら、彼らはアプリの背景が黒で表示されることを期待します。</span><span class="sxs-lookup"><span data-stu-id="d442f-115">If the user switches to the High Contrast Black theme, they'll expect your app to have a black background.</span></span> <span data-ttu-id="d442f-116">`#E6E6E6` はほぼ白一色であるため、ユーザーによってはアプリを操作できない場合があります。</span><span class="sxs-lookup"><span data-stu-id="d442f-116">Since `#E6E6E6` is almost white, some users may not be able to interact with your app.</span></span>

<span data-ttu-id="d442f-117">2 番目の例では、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/BR208794) 要素の専用プロパティである [**ThemeDictionaries**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.resourcedictionary.themedictionaries.aspx) コレクション内の色を参照するために [**{ThemeResource} マークアップ拡張**](../../xaml-platform/themeresource-markup-extension.md)を使っています。</span><span class="sxs-lookup"><span data-stu-id="d442f-117">In the second example, the [**{ThemeResource} markup extension**](../../xaml-platform/themeresource-markup-extension.md) is used to reference a color in the [**ThemeDictionaries**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.resourcedictionary.themedictionaries.aspx) collection, a dedicated property of a [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/BR208794) element.</span></span> <span data-ttu-id="d442f-118">**ThemeDictionaries** により、XAML はユーザーの現在のテーマに基づいて自動的に色を変えることができます。</span><span class="sxs-lookup"><span data-stu-id="d442f-118">**ThemeDictionaries** allows XAML to automatically swap colors for you based on the user's current theme.</span></span>

## <a name="theme-dictionaries"></a><span data-ttu-id="d442f-119">テーマ ディクショナリ</span><span class="sxs-lookup"><span data-stu-id="d442f-119">Theme dictionaries</span></span>

<span data-ttu-id="d442f-120">システムの既定の色を変更する必要がある場合は、アプリの ThemeDictionaries コレクションを作成します。</span><span class="sxs-lookup"><span data-stu-id="d442f-120">When you need to change a color from its system default, create a ThemeDictionaries collection for your app.</span></span>

1. <span data-ttu-id="d442f-121">まず、適切なプラミングを作成します (プラミングがまだない場合)。</span><span class="sxs-lookup"><span data-stu-id="d442f-121">Start by creating the proper plumbing, if it doesn't already exist.</span></span> <span data-ttu-id="d442f-122">App.xaml で、少なくとも **Default** と **HighContrast** を含む **ThemeDictionaries** コレクションを作成します。</span><span class="sxs-lookup"><span data-stu-id="d442f-122">In App.xaml, create a **ThemeDictionaries** collection, including **Default** and **HighContrast** at a minimum.</span></span>
2. <span data-ttu-id="d442f-123">**Default** では、必要な種類の [Brush](http://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.brush.aspx) を作成します。通常は、**SolidColorBrush** です。</span><span class="sxs-lookup"><span data-stu-id="d442f-123">In **Default**, create the type of [Brush](http://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.brush.aspx) you need, usually a **SolidColorBrush**.</span></span> <span data-ttu-id="d442f-124">このクラスに対して、具体的な使用目的を示す *x:Key* 名を指定します。</span><span class="sxs-lookup"><span data-stu-id="d442f-124">Give it a *x:Key* name specific to what it is being used for.</span></span>
3. <span data-ttu-id="d442f-125">必要な **Color** を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="d442f-125">Assign the **Color** you want for it.</span></span>
4. <span data-ttu-id="d442f-126">この **Brush** を **HighContrast** にコピーします。</span><span class="sxs-lookup"><span data-stu-id="d442f-126">Copy that **Brush** into **HighContrast**.</span></span>

``` xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <!-- Default is a fallback if a more precise theme isn't called
            out below -->
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>

            <!-- Optional, Light is used in light theme.
            If included, Default will be used for Dark theme -->
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>

            <!-- HighContrast is used in all high contrast themes -->
            <ResourceDictionary x:Key="HighContrast">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

<span data-ttu-id="d442f-127">最後に、ハイ コントラストで使用する色を決定します。これについては、次のセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="d442f-127">The last step is to determine what color to use in high contrast, which is covered in the next section.</span></span>

> [!NOTE]
> <span data-ttu-id="d442f-128">**HighContrast** のみが、利用可能なキー名というわけではありません。</span><span class="sxs-lookup"><span data-stu-id="d442f-128">**HighContrast** is not the only available key name.</span></span> <span data-ttu-id="d442f-129">**HighContrastBlack**、**HighContrastWhite**、**HighContrastCustom** も利用可能なキー名です。</span><span class="sxs-lookup"><span data-stu-id="d442f-129">There's also **HighContrastBlack**, **HighContrastWhite**, and **HighContrastCustom**.</span></span> <span data-ttu-id="d442f-130">ほとんどの場合、**HighContrast** が必要になります。</span><span class="sxs-lookup"><span data-stu-id="d442f-130">In most cases, **HighContrast** is all you need.</span></span>

## <a name="high-contrast-colors"></a><span data-ttu-id="d442f-131">ハイ コントラストの色</span><span class="sxs-lookup"><span data-stu-id="d442f-131">High contrast colors</span></span>

<span data-ttu-id="d442f-132">*[設定]、[簡単操作]、[ハイ コントラスト]* の順に選択すると、既定の 4 つのハイ コントラスト テーマが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d442f-132">On the *Settings > Ease of access > High contrast* page, there are 4 high contrast themes by default.</span></span> 


![ハイ コントラスト設定](images/high-contrast-settings.png)  

*<span data-ttu-id="d442f-134">ユーザーがオプションを選ぶと、ページにはプレビューが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d442f-134">After the user selects an option, the page shows a preview.</span></span>*  

![ハイ コントラスト リソース](images/high-contrast-resources.png)  

*<span data-ttu-id="d442f-136">プレビューに表示される色の見本をクリックすると、その値を変更できます。</span><span class="sxs-lookup"><span data-stu-id="d442f-136">Every color swatch on the preview can be clicked to change its value.</span></span> <span data-ttu-id="d442f-137">また各見本は、XAML のカラー リソースに直接マップされます。</span><span class="sxs-lookup"><span data-stu-id="d442f-137">Every swatch also directly maps to an XAML color resource.</span></span>*  

<span data-ttu-id="d442f-138">各 **SystemColor\*Color** リソースは、ユーザーがハイ コントラスト テーマに切り替えたときに自動的に色を更新する変数です。</span><span class="sxs-lookup"><span data-stu-id="d442f-138">Each **SystemColor\*Color** resource is a variable that automatically updates color when the user switches high contrast themes.</span></span> <span data-ttu-id="d442f-139">各リソースをいつどこで使用するかについてのガイドラインを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="d442f-139">Following are guidelines for where and when to use each resource.</span></span>

<span data-ttu-id="d442f-140">リソース</span><span class="sxs-lookup"><span data-stu-id="d442f-140">Resource</span></span> | <span data-ttu-id="d442f-141">用途</span><span class="sxs-lookup"><span data-stu-id="d442f-141">Usage</span></span> |
|--------|-------|
**<span data-ttu-id="d442f-142">SystemColorWindowTextColor</span><span class="sxs-lookup"><span data-stu-id="d442f-142">SystemColorWindowTextColor</span></span>** | <span data-ttu-id="d442f-143">本文、見出し、一覧など、操作できないテキスト</span><span class="sxs-lookup"><span data-stu-id="d442f-143">Body copy, headings, lists; any text that can't be interacted with</span></span> |
| **<span data-ttu-id="d442f-144">SystemColorHotlightColor</span><span class="sxs-lookup"><span data-stu-id="d442f-144">SystemColorHotlightColor</span></span>** | <span data-ttu-id="d442f-145">ハイパーリンク</span><span class="sxs-lookup"><span data-stu-id="d442f-145">Hyperlinks</span></span> |
| **<span data-ttu-id="d442f-146">SystemColorGrayTextColor</span><span class="sxs-lookup"><span data-stu-id="d442f-146">SystemColorGrayTextColor</span></span>** | <span data-ttu-id="d442f-147">無効な UI</span><span class="sxs-lookup"><span data-stu-id="d442f-147">Disabled UI</span></span> |
| **<span data-ttu-id="d442f-148">SystemColorHighlightTextColor</span><span class="sxs-lookup"><span data-stu-id="d442f-148">SystemColorHighlightTextColor</span></span>** | <span data-ttu-id="d442f-149">処理中、選択されている、または現在操作されているテキストや UI の前景色</span><span class="sxs-lookup"><span data-stu-id="d442f-149">Foreground color for text or UI that's in progress, selected, or currently being interacted with</span></span> |
| **<span data-ttu-id="d442f-150">SystemColorHighlightColor</span><span class="sxs-lookup"><span data-stu-id="d442f-150">SystemColorHighlightColor</span></span>** | <span data-ttu-id="d442f-151">処理中、選択されている、または現在操作されているテキストや UI の背景色</span><span class="sxs-lookup"><span data-stu-id="d442f-151">Background color for text or UI that's in progress, selected, or currently being interacted with</span></span> |
| **<span data-ttu-id="d442f-152">SystemColorButtonTextColor</span><span class="sxs-lookup"><span data-stu-id="d442f-152">SystemColorButtonTextColor</span></span>** | <span data-ttu-id="d442f-153">ボタンなど、操作可能な UI の前景色</span><span class="sxs-lookup"><span data-stu-id="d442f-153">Foreground color for buttons; any UI that can be interacted with</span></span> |
| **<span data-ttu-id="d442f-154">SystemColorButtonFaceColor</span><span class="sxs-lookup"><span data-stu-id="d442f-154">SystemColorButtonFaceColor</span></span>** | <span data-ttu-id="d442f-155">ボタンなど、操作可能な UI の背景色</span><span class="sxs-lookup"><span data-stu-id="d442f-155">Background color for buttons; any UI that can be interacted with</span></span> |
| **<span data-ttu-id="d442f-156">SystemColorWindowColor</span><span class="sxs-lookup"><span data-stu-id="d442f-156">SystemColorWindowColor</span></span>** | <span data-ttu-id="d442f-157">ページ、ウィンドウ、ポップアップ、およびバーの背景</span><span class="sxs-lookup"><span data-stu-id="d442f-157">Background of pages, panes, popups, and bars</span></span> |

<span data-ttu-id="d442f-158">既存のアプリ、スタート画面、またはコモン コントロールを確認すると、ハイ コントラストのデザインの参考になります。</span><span class="sxs-lookup"><span data-stu-id="d442f-158">It's often helpful to look to existing apps, Start, or the common controls to see how others have solved high contrast design problems that are similar to your own.</span></span>

**<span data-ttu-id="d442f-159">推奨される事項</span><span class="sxs-lookup"><span data-stu-id="d442f-159">Do</span></span>**

* <span data-ttu-id="d442f-160">可能な限り、背景と前景の組み合わせを考慮します。</span><span class="sxs-lookup"><span data-stu-id="d442f-160">Respect the background/foreground pairs where possible.</span></span>
* <span data-ttu-id="d442f-161">アプリの実行中に、4 つのハイ コントラスト テーマをすべてテストします。</span><span class="sxs-lookup"><span data-stu-id="d442f-161">Test in all 4 high contrast themes while your app is running.</span></span> <span data-ttu-id="d442f-162">ユーザーがテーマを切り替えたときに、アプリを再起動しなくても良いようにします。</span><span class="sxs-lookup"><span data-stu-id="d442f-162">The user should not have to restart your app when they switch themes.</span></span>
* <span data-ttu-id="d442f-163">一貫性を保ちます。</span><span class="sxs-lookup"><span data-stu-id="d442f-163">Be consistent.</span></span>

**<span data-ttu-id="d442f-164">非推奨</span><span class="sxs-lookup"><span data-stu-id="d442f-164">Don't</span></span>**

* <span data-ttu-id="d442f-165">**SystemColor\*Color** リソースを使って **HighContrast** テーマの色をハードコーディングしないようにします。</span><span class="sxs-lookup"><span data-stu-id="d442f-165">Hard code a color in the **HighContrast** theme; use the **SystemColor\*Color** resources.</span></span>
* <span data-ttu-id="d442f-166">見栄えを良くすることを目的としてカラー リソースを選ばないようにします。</span><span class="sxs-lookup"><span data-stu-id="d442f-166">Choose a color resource for aesthetics.</span></span> <span data-ttu-id="d442f-167">カラー リソースはテーマによって変わることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d442f-167">Remember, they change with the theme!</span></span>
* <span data-ttu-id="d442f-168">**SystemColorGrayTextColor** を、セカンダリ テキストの本文やヒント目的の本文に使用しないようにします。</span><span class="sxs-lookup"><span data-stu-id="d442f-168">Don't use **SystemColorGrayTextColor** for body copy that's secondary or acts as a hint.</span></span>


<span data-ttu-id="d442f-169">先ほどの例を続けるには、**BrandedPageBackgroundBrush** のリソースを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d442f-169">To continue the earlier example, you need to pick a resource for **BrandedPageBackgroundBrush**.</span></span> <span data-ttu-id="d442f-170">背景に使用されることを名前が示しているため、**SystemColorWindowColor** が最適です。</span><span class="sxs-lookup"><span data-stu-id="d442f-170">Because the name indicates that it will be used for a background, **SystemColorWindowColor** is a good choice.</span></span>

``` xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <!-- Default is a fallback if a more precise theme isn't called
            out below -->
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>

            <!-- Optional, Light is used in light theme.
            If included, Default will be used for Dark theme -->
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>

            <!-- HighContrast is used in all high contrast themes -->
            <ResourceDictionary x:Key="HighContrast">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="{ThemeResource SystemColorWindowColor}" />
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

<span data-ttu-id="d442f-171">その後、アプリで背景を設定できます。</span><span class="sxs-lookup"><span data-stu-id="d442f-171">Later in your app, you can now set the background.</span></span>

```xaml
<Grid Background="{ThemeResource BrandedPageBackgroundBrush}">
```

<span data-ttu-id="d442f-172">**\{ThemeResource\}** は、**SystemColorWindowColor** の参照と **BrandedPageBackgroundBrush** の参照とで、2 回使われることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d442f-172">Note how **\{ThemeResource\}** is used twice, once to reference **SystemColorWindowColor** and again to reference **BrandedPageBackgroundBrush**.</span></span> <span data-ttu-id="d442f-173">実行時に正しいテーマを使うためには、両方の参照がアプリに必要です。</span><span class="sxs-lookup"><span data-stu-id="d442f-173">Both are required for your app to theme correctly at run time.</span></span> <span data-ttu-id="d442f-174">ここで、アプリでハイ コントラストの機能をテストすると良いでしょう。</span><span class="sxs-lookup"><span data-stu-id="d442f-174">This is a good time to test out the functionality in your app.</span></span> <span data-ttu-id="d442f-175">ハイ コントラスト テーマに切り替えると、グリッドの背景が自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="d442f-175">The Grid's background will automatically update as you switch to a high contrast theme.</span></span> <span data-ttu-id="d442f-176">また、別のハイ コントラスト テーマに切り替えたときにも更新されます。</span><span class="sxs-lookup"><span data-stu-id="d442f-176">It will also update when switching between different high contrast themes.</span></span>

## <a name="when-to-use-borders"></a><span data-ttu-id="d442f-177">境界線を使う状況</span><span class="sxs-lookup"><span data-stu-id="d442f-177">When to use borders</span></span>

<span data-ttu-id="d442f-178">ページ、ウィンドウ、ポップアップ、およびバーでは、ハイ コントラストの背景に **SystemColorWindowColor** を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="d442f-178">Pages, panes, popups, and bars should all use **SystemColorWindowColor** for their background in high contrast.</span></span> <span data-ttu-id="d442f-179">UI で重要な境界を維持する必要がある場合、ハイ コントラストのみの境界線を追加します。</span><span class="sxs-lookup"><span data-stu-id="d442f-179">Add a high contrast-only border where necessary to preserve important boundaries in your UI.</span></span>

![ページの他の部分と区別されたナビゲーション ウィンドウ](images/high-contrast-actions-content.png)  

*<span data-ttu-id="d442f-181">ナビゲーション ウィンドウとページはハイ コントラストで同じ背景色を共有するので、</span><span class="sxs-lookup"><span data-stu-id="d442f-181">The navigation pane and the page both share the same background color in high contrast.</span></span> <span data-ttu-id="d442f-182">分割するには、ハイ コントラストのみの境界線が不可欠です。</span><span class="sxs-lookup"><span data-stu-id="d442f-182">A high contrast-only border to divide them is essential.</span></span>*


## <a name="list-items"></a><span data-ttu-id="d442f-183">リスト項目</span><span class="sxs-lookup"><span data-stu-id="d442f-183">List items</span></span>

<span data-ttu-id="d442f-184">ハイ コントラストでは、ポイント、押下、または選択時に [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) の項目の背景が **SystemColorHighlightColor** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="d442f-184">In high contrast, items in a [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) have their background set to **SystemColorHighlightColor** when they are hovered, pressed, or selected.</span></span> <span data-ttu-id="d442f-185">複雑なリスト項目では、項目のポイント、押下、選択時に色の反転に失敗するというバグがよく生じ、</span><span class="sxs-lookup"><span data-stu-id="d442f-185">Complex list items commonly have a bug where the content of the list item fails to invert its color when the item is hovered, pressed, or selected.</span></span> <span data-ttu-id="d442f-186">項目が読めなくなってしまいます。</span><span class="sxs-lookup"><span data-stu-id="d442f-186">This makes the item impossible to read.</span></span>

![単色テーマと黒のハイ コントラスト テーマの簡単なリスト](images/high-contrast-list1.png)

*<span data-ttu-id="d442f-188">淡色テーマ (左) と黒のハイ コントラスト テーマ (右) の簡単なリスト。</span><span class="sxs-lookup"><span data-stu-id="d442f-188">A simple list in light theme (left) and High Contrast Black theme (right).</span></span> <span data-ttu-id="d442f-189">2 番目の項目が選択されています。テキストの色が、ハイ コントラストでは反転されていることに注目してください。</span><span class="sxs-lookup"><span data-stu-id="d442f-189">The second item is selected; note how its text color is inverted in high contrast.</span></span>*


### <a name="list-items-with-colored-text"></a><span data-ttu-id="d442f-190">テキストに色が付いているリスト項目</span><span class="sxs-lookup"><span data-stu-id="d442f-190">List items with colored text</span></span>

<span data-ttu-id="d442f-191">問題の原因の 1 つが、ListView の [DataTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) で TextBlock.Foreground を設定することです。</span><span class="sxs-lookup"><span data-stu-id="d442f-191">One culprit is setting TextBlock.Foreground in the ListView's [DataTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx).</span></span> <span data-ttu-id="d442f-192">TextBlock.Foreground は一般的に、視覚的な階層を確立するために設定します。</span><span class="sxs-lookup"><span data-stu-id="d442f-192">This is commonly done to establish visual hierarchy.</span></span> <span data-ttu-id="d442f-193">Foreground プロパティは [ListViewItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewitem.aspx) で設定され、DataTemplate 内の TextBlock は、項目がポイント、押下、または選択されたときに適切な Foreground 色を継承します。</span><span class="sxs-lookup"><span data-stu-id="d442f-193">The Foreground property is set on the [ListViewItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewitem.aspx), and TextBlocks in the DataTemplate inherit the correct Foreground color when the item is hovered, pressed, or selected.</span></span> <span data-ttu-id="d442f-194">ところが、Foreground を設定すると継承が中断されてしまいます。</span><span class="sxs-lookup"><span data-stu-id="d442f-194">However, setting Foreground breaks the inheritance.</span></span>

![淡色テーマと黒のハイ コントラスト テーマの複雑なリスト](images/high-contrast-list2.png)

*<span data-ttu-id="d442f-196">淡色テーマ (左) と黒のハイ コントラスト テーマ (右) の複雑なリスト。</span><span class="sxs-lookup"><span data-stu-id="d442f-196">Complex list in light theme (left) and High Contrast Black theme (right).</span></span> <span data-ttu-id="d442f-197">ハイ コントラストでは、選択された項目の 2 行目が反転に失敗しています。</span><span class="sxs-lookup"><span data-stu-id="d442f-197">In high contrast, the second line of the selected item failed to invert.</span></span>*  

<span data-ttu-id="d442f-198">この問題を回避するには、**ThemeDictionaries** コレクションに含まれている Style を使って、条件付きで Foreground を設定します。</span><span class="sxs-lookup"><span data-stu-id="d442f-198">You can work around this by setting Foreground conditionally via a Style that's in a **ThemeDictionaries** collection.</span></span> <span data-ttu-id="d442f-199">**Foreground** が、**HighContrast** の **SecondaryBodyTextBlockStyle** によって設定されていないため、色が正しく反転します。</span><span class="sxs-lookup"><span data-stu-id="d442f-199">Because the **Foreground** is not set by **SecondaryBodyTextBlockStyle** in **HighContrast**, its color will correctly invert.</span></span>

```xaml
<!-- In App.xaml... -->
<ResourceDictionary.ThemeDictionaries>
    <ResourceDictionary x:Key="Default">
        <Style
            x:Key="SecondaryBodyTextBlockStyle"
            TargetType="TextBlock"
            BasedOn="{StaticResource BodyTextBlockStyle}">
            <Setter Property="Foreground" Value="{StaticResource SystemControlForegroundBaseMediumBrush}" />
        </Style>
    </ResourceDictionary>

    <ResourceDictionary x:Key="Light">
        <Style
            x:Key="SecondaryBodyTextBlockStyle"
            TargetType="TextBlock"
            BasedOn="{StaticResource BodyTextBlockStyle}">
            <Setter Property="Foreground" Value="{StaticResource SystemControlForegroundBaseMediumBrush}" />
        </Style>
    </ResourceDictionary>

    <ResourceDictionary x:Key="HighContrast">
        <!-- The Foreground Setter is omitted in HighContrast -->
        <Style
            x:Key="SecondaryBodyTextBlockStyle"
            TargetType="TextBlock"
            BasedOn="{StaticResource BodyTextBlockStyle}" />
    </ResourceDictionary>
</ResourceDictionary.ThemeDictionaries>

<!-- Usage in your DataTemplate... -->
<DataTemplate>
    <StackPanel>
        <TextBlock Style="{StaticResource BodyTextBlockStyle}" Text="Double line list item" />

        <!-- Note how ThemeResource is used to reference the Style -->
        <TextBlock Style="{ThemeResource SecondaryBodyTextBlockStyle}" Text="Second line of text" />
    </StackPanel>
</DataTemplate>
```


## <a name="detecting-high-contrast"></a><span data-ttu-id="d442f-200">ハイ コントラストを検出する</span><span class="sxs-lookup"><span data-stu-id="d442f-200">Detecting high contrast</span></span>

<span data-ttu-id="d442f-201">[**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237) クラスのメンバーを使えば、現在のテーマがハイ コントラストであるかどうかをプログラムで確認することができます。</span><span class="sxs-lookup"><span data-stu-id="d442f-201">You can programmatically check if the current theme is a high contrast theme by using members of the [**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237) class.</span></span>

> [!NOTE]
> <span data-ttu-id="d442f-202">アプリが初期化され、既にコンテンツが表示されているスコープから **AccessibilitySettings** コンストラクターを呼び出すようにします。</span><span class="sxs-lookup"><span data-stu-id="d442f-202">Make sure you call the **AccessibilitySettings** constructor from a scope where the app is initialized and is already displaying content.</span></span>

## <a name="related-topics"></a><span data-ttu-id="d442f-203">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d442f-203">Related topics</span></span>  
* [<span data-ttu-id="d442f-204">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="d442f-204">Accessibility</span></span>](accessibility.md)
* [<span data-ttu-id="d442f-205">UI コントラストと設定のサンプル</span><span class="sxs-lookup"><span data-stu-id="d442f-205">UI contrast and settings sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231539)
* [<span data-ttu-id="d442f-206">XAML アクセシビリティ サンプル</span><span class="sxs-lookup"><span data-stu-id="d442f-206">XAML accessibility sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=238570)
* [<span data-ttu-id="d442f-207">XAML ハイ コントラスト サンプル</span><span class="sxs-lookup"><span data-stu-id="d442f-207">XAML high contrast sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=254993)
* [**<span data-ttu-id="d442f-208">AccessibilitySettings</span><span class="sxs-lookup"><span data-stu-id="d442f-208">AccessibilitySettings</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR242237)
