---
author: andrewleader
Description: Adaptive tile templates are a new feature in Windows 10, allowing you to design your own tile notification content using a simple and flexible markup language that adapts to different screen densities.
title: アダプティブ タイルの作成
ms.assetid: 1246B58E-D6E3-48C7-AD7F-475D113600F9
label: Create adaptive tiles
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 761d87654ef340f4b539dbefa0950c58f627d310
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4471228"
---
# <a name="create-adaptive-tiles"></a><span data-ttu-id="0f65e-103">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="0f65e-103">Create adaptive tiles</span></span>

<span data-ttu-id="0f65e-104">アダプティブ タイル テンプレートは Windows 10 の新機能であり、シンプルで柔軟なマークアップ言語を使って、さまざまな画面密度に合わせて変化する独自のタイル通知コンテンツをデザインできるようになります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-104">Adaptive tile templates are a new feature in Windows 10, allowing you to design your own tile notification content using a simple and flexible markup language that adapts to different screen densities.</span></span> <span data-ttu-id="0f65e-105">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリのアダプティブ ライブ タイルを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-105">This article tells you how to create adaptive live tiles for your Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="0f65e-106">アダプティブ タイルのすべての要素と属性の一覧については、「[アダプティブ タイルのスキーマ](../tiles-and-notifications/tile-schema.md)」をご覧ください </span><span class="sxs-lookup"><span data-stu-id="0f65e-106">For the complete list of adaptive elements and attributes, see the [Adaptive tiles schema](../tiles-and-notifications/tile-schema.md).</span></span>

<span data-ttu-id="0f65e-107">(必要に応じて、Windows 10 の通知をデザインするときは、[Windows 8 タイル テンプレート カタログ](https://msdn.microsoft.com/library/windows/apps/hh761491)のプリセット テンプレートを引き続き使うことができます)。</span><span class="sxs-lookup"><span data-stu-id="0f65e-107">(If you'd like, you can still use the preset templates from the [Windows 8 tile template catalog](https://msdn.microsoft.com/library/windows/apps/hh761491) when designing notifications for Windows 10.)</span></span>


## <a name="getting-started"></a><span data-ttu-id="0f65e-108">概要</span><span class="sxs-lookup"><span data-stu-id="0f65e-108">Getting started</span></span>

**<span data-ttu-id="0f65e-109">Notifications ライブラリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="0f65e-109">Install Notifications library.</span></span>** <span data-ttu-id="0f65e-110">XML の代わりに C# を使って通知を生成する場合は、[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) という名前の NuGet パッケージをインストールします (「notifications uwp」を検索してください)。</span><span class="sxs-lookup"><span data-stu-id="0f65e-110">If you'd like to use C# instead of XML to generate notifications, install the NuGet package named [Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) (search for "notifications uwp").</span></span> <span data-ttu-id="0f65e-111">この記事で示している C# のサンプルでは、NuGet パッケージの Version 1.0.0 を使っています。</span><span class="sxs-lookup"><span data-stu-id="0f65e-111">The C# samples provided in this article use version 1.0.0 of the NuGet package.</span></span>

**<span data-ttu-id="0f65e-112">Notifications Visualizer をインストールします。</span><span class="sxs-lookup"><span data-stu-id="0f65e-112">Install Notifications Visualizer.</span></span>** <span data-ttu-id="0f65e-113">この無料の UWP アプリは、Visual Studio の XAML エディター/デザイン ビューと同様、タイルの編集時に視覚的なプレビューが即座に表示されるため、アダプティブ ライブ タイルのデザインに便利です。</span><span class="sxs-lookup"><span data-stu-id="0f65e-113">This free UWP app helps you design adaptive live tiles by providing an instant visual preview of your tile as you edit it, similar to Visual Studio's XAML editor/design view.</span></span> <span data-ttu-id="0f65e-114">詳しくは、「[Notifications Visualizer](notifications-visualizer.md)」をご覧になるか、[Notifications Visualizer を Microsoft Store からダウンロード](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)してください。</span><span class="sxs-lookup"><span data-stu-id="0f65e-114">See [Notifications Visualizer](notifications-visualizer.md) for more information, or [download Notifications Visualizer from the Store](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1).</span></span>


## <a name="how-to-send-a-tile-notification"></a><span data-ttu-id="0f65e-115">タイル通知を送信する方法</span><span class="sxs-lookup"><span data-stu-id="0f65e-115">How to send a tile notification</span></span>

<span data-ttu-id="0f65e-116">詳しくは、「[Quickstart on sending local tile notifications (ローカル タイル通知の送信に関するクイックスタート)](sending-a-local-tile-notification.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0f65e-116">Please read our [Quickstart on sending local tile notifications](sending-a-local-tile-notification.md).</span></span> <span data-ttu-id="0f65e-117">以下では、アダプティブ タイルを使って作成できるあらゆる視覚的 UI について説明します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-117">The documentation below explains all the visual UI possibilities you have with adaptive tiles.</span></span>


## <a name="usage-guidance"></a><span data-ttu-id="0f65e-118">使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="0f65e-118">Usage guidance</span></span>


<span data-ttu-id="0f65e-119">アダプティブ テンプレートはさまざまな種類のフォーム ファクターと通知で動作するようにデザインされています。</span><span class="sxs-lookup"><span data-stu-id="0f65e-119">Adaptive templates are designed to work across different form factors and notification types.</span></span> <span data-ttu-id="0f65e-120">グループやサブグループのような要素はコンテンツと共にリンクされますが、それらのグループ自体には特に視覚的な動作はありません。</span><span class="sxs-lookup"><span data-stu-id="0f65e-120">Elements such as group and subgroup link together content and don't imply a particular visual behavior on their own.</span></span> <span data-ttu-id="0f65e-121">通知の最終的な外観は、表示先のデバイスがスマートフォン、タブレット、デスクトップ、その他のデバイスのいずれであっても、特定のデバイスに基づきます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-121">The final appearance of a notification should be based on the specific device on which it will appear, whether it's phone, tablet, or desktop, or another device.</span></span>

<span data-ttu-id="0f65e-122">hint は、特定の視覚的な動作を実現するために要素に追加できる省略可能な属性です。</span><span class="sxs-lookup"><span data-stu-id="0f65e-122">Hints are optional attributes that can be added to elements in order to achieve a specific visual behavior.</span></span> <span data-ttu-id="0f65e-123">デバイス固有または通知固有の hint を追加できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-123">Hints can be device-specific or notification-specific.</span></span>

## <a name="a-basic-example"></a><span data-ttu-id="0f65e-124">基本的な例</span><span class="sxs-lookup"><span data-stu-id="0f65e-124">A basic example</span></span>


<span data-ttu-id="0f65e-125">次の例では、アダプティブ タイル テンプレートで何を作成できるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="0f65e-125">This example demonstrates what the adaptive tile templates can produce.</span></span>

```xml
<tile>
  <visual>
  
    <binding template="TileMedium">
      ...
    </binding>
  
    <binding template="TileWide">
      <text hint-style="subtitle">Jennifer Parker</text>
      <text hint-style="captionSubtle">Photos from our trip</text>
      <text hint-style="captionSubtle">Check out these awesome photos I took while in New Zealand!</text>
    </binding>
  
    <binding template="TileLarge">
      ...
    </binding>
  
  </visual>
</tile>
```

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = ...
  
        TileWide = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Jennifer Parker",
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },
  
                    new AdaptiveText()
                    {
                        Text = "Photos from our trip",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },
  
                    new AdaptiveText()
                    {
                        Text = "Check out these awesome photos I took while in New Zealand!",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
            }
        },
  
        TileLarge = ...
    }
};
```

**<span data-ttu-id="0f65e-126">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-126">Result:</span></span>**

![クイック サンプル タイル](images/adaptive-tiles-quicksample.png)

## <a name="tile-sizes"></a><span data-ttu-id="0f65e-128">タイルのサイズ</span><span class="sxs-lookup"><span data-stu-id="0f65e-128">Tile sizes</span></span>


<span data-ttu-id="0f65e-129">各タイル サイズのコンテンツは XML ペイロード内でそれぞれ個別の [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) 要素で指定します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-129">Content for each tile size is individually specified in separate [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) elements within the XML payload.</span></span> <span data-ttu-id="0f65e-130">template 属性を次のいずれかの値に設定することで、目的のサイズを選びます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-130">Choose the target size by setting the template attribute to one of the following values:</span></span>

-   <span data-ttu-id="0f65e-131">TileSmall</span><span class="sxs-lookup"><span data-stu-id="0f65e-131">TileSmall</span></span>
-   <span data-ttu-id="0f65e-132">TileMedium</span><span class="sxs-lookup"><span data-stu-id="0f65e-132">TileMedium</span></span>
-   <span data-ttu-id="0f65e-133">TileWide</span><span class="sxs-lookup"><span data-stu-id="0f65e-133">TileWide</span></span>
-   <span data-ttu-id="0f65e-134">TileLarge (デスクトップの場合のみ)</span><span class="sxs-lookup"><span data-stu-id="0f65e-134">TileLarge (only for desktop)</span></span>

<span data-ttu-id="0f65e-135">次の例では、1 つのタイル通知 XML ペイロード内で、サポートする各タイル サイズを &lt;binding&gt; 要素で指定しています。</span><span class="sxs-lookup"><span data-stu-id="0f65e-135">For a single tile notification XML payload, provide &lt;binding&gt; elements for each tile size that you'd like to support, as shown in this example:</span></span>

```xml
<tile>
  <visual>
  
    <binding template="TileSmall">
      <text>Small</text>
    </binding>
  
    <binding template="TileMedium">
      <text>Medium</text>
    </binding>
  
    <binding template="TileWide">
      <text>Wide</text>
    </binding>
  
    <binding template="TileLarge">
      <text>Large</text>
    </binding>
  
  </visual>
</tile>
```

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileSmall = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText() { Text = "Small" }
                }
            }
        },
  
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText() { Text = "Medium" }
                }
            }
        },
  
        TileWide = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText() { Text = "Wide" }
                }
            }
        },
  
        TileLarge = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText() { Text = "Large" }
                }
            }
        }
    }
};
```

**<span data-ttu-id="0f65e-136">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-136">Result:</span></span>**

![アダプティブ タイル サイズ: 小、中、ワイド、大](images/adaptive-tiles-sizes.png)

## <a name="branding"></a><span data-ttu-id="0f65e-138">ブランディング</span><span class="sxs-lookup"><span data-stu-id="0f65e-138">Branding</span></span>


<span data-ttu-id="0f65e-139">通知ペイロード内で branding 属性を使って、ライブ タイルの下部でブランディング (表示名とコーナー ロゴ) を制御できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-139">You can control the branding on the bottom of a live tile (the display name and corner logo) by using the branding attribute on the notification payload.</span></span> <span data-ttu-id="0f65e-140">表示なし ("none")、名前のみ表示 ("name")、ロゴのみ表示 ("logo")、名前とロゴの両方を表示 ("nameAndLogo") のいずれかを選べます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-140">You can choose to display "none," only the "name," only the "logo," or both with "nameAndLogo."</span></span>

<span data-ttu-id="0f65e-141">**注**  Windows Mobile では、コーナー ロゴはサポートされていないため、"logo" と "nameAndLogo" は "name" に既定で設定されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-141">**Note**  Windows Mobile doesn't support the corner logo, so "logo" and "nameAndLogo" default to "name" on Mobile.</span></span>

 

```xml
<visual branding="logo">
  ...
</visual>
```

```csharp
new TileVisual()
{
    Branding = TileBranding.Logo,
    ...
}
```

**<span data-ttu-id="0f65e-142">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-142">Result:</span></span>**

![アダプティブ タイル、表示名、ロゴ](images/adaptive-tiles-namelogo.png)

<span data-ttu-id="0f65e-144">ブランディングは次の 2 つのいずれかの方法で特定のタイル サイズに合わせて適用できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-144">Branding can be applied for specific tile sizes one of two ways:</span></span>

1. <span data-ttu-id="0f65e-145">その属性を [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) 要素で適用する。</span><span class="sxs-lookup"><span data-stu-id="0f65e-145">By applying the attribute on the [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) element</span></span>
2. <span data-ttu-id="0f65e-146">その属性を [TileVisual](../tiles-and-notifications/tile-schema.md#tilevisual) 要素で適用する。通知ペイロード全体に影響を与えます。binding 要素でブランディングを指定しない場合は、visual 要素で指定したブランディングが使われます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-146">By applying the attribute on the [TileVisual](../tiles-and-notifications/tile-schema.md#tilevisual) element, which affects the entire notification payload If you don't specify branding for a binding, it will use the branding that's provided on the visual element.</span></span>

```xml
<tile>
  <visual branding="nameAndLogo">
 
    <binding template="TileMedium" branding="logo">
      ...
    </binding>
 
    <!--Inherits branding from visual-->
    <binding template="TileWide">
      ...
    </binding>
 
  </visual>
</tile>
```

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        Branding = TileBranding.NameAndLogo,

        TileMedium = new TileBinding()
        {
            Branding = TileBranding.Logo,
            ...
        },

        // Inherits branding from Visual
        TileWide = new TileBinding()
        {
            ...
        }
    }
};
```

**<span data-ttu-id="0f65e-147">既定のブランディングの結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-147">Default branding result:</span></span>**

![タイル上の既定のブランディング](images/adaptive-tiles-defaultbranding.png)

<span data-ttu-id="0f65e-149">通知ペイロード内でブランディングを指定しない場合は、ベース タイルのプロパティによってブランディングが決まります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-149">If you don't specify the branding in your notification payload, the base tile's properties will determine the branding.</span></span> <span data-ttu-id="0f65e-150">ベース タイルに表示名が表示される場合、ブランディングは既定で "name" に設定されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-150">If the base tile shows the display name, then the branding will default to "name."</span></span> <span data-ttu-id="0f65e-151">表示名が表示されない場合、ブランディングは既定で "none" に設定されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-151">Otherwise, the branding will default to "none" if the display name isn't shown.</span></span>

<span data-ttu-id="0f65e-152">**注**   これは、既定のブランディングが "logo" であった Windows 8.x からの変更点です。</span><span class="sxs-lookup"><span data-stu-id="0f65e-152">**Note**   This is a change from Windows 8.x, in which the default branding was "logo."</span></span>

 

## <a name="display-name"></a><span data-ttu-id="0f65e-153">表示名</span><span class="sxs-lookup"><span data-stu-id="0f65e-153">Display name</span></span>


<span data-ttu-id="0f65e-154">**displayName** 属性に任意のテキスト文字列を入力することで、通知の表示名を上書きすることができます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-154">You can override the display name of a notification by entering the text string of your choice with the **displayName** attribute.</span></span> <span data-ttu-id="0f65e-155">ブランディングと同様、通知ペイロード全体に影響を与える [TileVisual](../tiles-and-notifications/tile-schema.md#tilevisual) 要素で、または個々のタイルにのみ影響を与える [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) 要素で、表示名を指定できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-155">As with branding, you can specify this on the [TileVisual](../tiles-and-notifications/tile-schema.md#tilevisual) element, which affects the entire notification payload, or on the [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) element, which only affects individual tiles.</span></span>

<span data-ttu-id="0f65e-156">**既知の問題**  Windows Mobile でタイルの ShortName を指定した場合、通知で提供される表示名は使用されません (ShortName が常に表示されます)。</span><span class="sxs-lookup"><span data-stu-id="0f65e-156">**Known Issue**  On Windows Mobile, if you specify a ShortName for your Tile, the display name provided in your notification will not be used (the ShortName will always be displayed).</span></span> 

```xml
<tile>
  <visual branding="nameAndLogo" displayName="Wednesday 22">
 
    <binding template="TileMedium" displayName="Wed. 22">
      ...
    </binding>
 
    <!--Inherits displayName from visual-->
    <binding template="TileWide">
      ...
    </binding>
 
  </visual>
</tile>
```

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        Branding = TileBranding.NameAndLogo,
        DisplayName = "Wednesday 22",

        TileMedium = new TileBinding()
        {
            DisplayName = "Wed. 22",
            ...
        },

        // Inherits DisplayName from Visual
        TileWide = new TileBinding()
        {
            ...
        }
    }
};
```

**<span data-ttu-id="0f65e-157">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-157">Result:</span></span>**

![アダプティブ タイルの表示名](images/adaptive-tiles-displayname.png)

## <a name="text"></a><span data-ttu-id="0f65e-159">テキスト</span><span class="sxs-lookup"><span data-stu-id="0f65e-159">Text</span></span>


<span data-ttu-id="0f65e-160">テキストの表示には、[AdaptiveText](../tiles-and-notifications/tile-schema.md#adaptivetext) 要素を使用します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-160">The [AdaptiveText](../tiles-and-notifications/tile-schema.md#adaptivetext) element is used to display text.</span></span> <span data-ttu-id="0f65e-161">ヒントを使用して、テキストの表示方法を変更できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-161">You can use hints to modify how text appears.</span></span>

```xml
<text>This is a line of text</text>
```


```csharp
new AdaptiveText()
{
    Text = "This is a line of text"
};
```

**<span data-ttu-id="0f65e-162">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-162">Result:</span></span>**

![アダプティブ タイルのテキスト](images/adaptive-tiles-text.png)

## <a name="text-wrapping"></a><span data-ttu-id="0f65e-164">テキストの折り返し</span><span class="sxs-lookup"><span data-stu-id="0f65e-164">Text wrapping</span></span>


<span data-ttu-id="0f65e-165">既定では、テキストは折り返されず、タイルの端からはみ出します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-165">By default, text doesn't wrap and will continue off the edge of the tile.</span></span> <span data-ttu-id="0f65e-166">**hint-wrap** 属性を使って、text 要素のテキストの折り返しを設定します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-166">Use the **hint-wrap** attribute to set text wrapping on a text element.</span></span> <span data-ttu-id="0f65e-167">また、**hint-minLines** と **hint-maxLines** (正の整数のみを受け取り) を使って、行の最小数と最大数を制御することもできます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-167">You can also control the minimum and maximum number of lines by using **hint-minLines** and **hint-maxLines**, both of which accept positive integers.</span></span>

```xml
<text hint-wrap="true">This is a line of wrapping text</text>
```


```csharp
new AdaptiveText()
{
    Text = "This is a line of wrapping text",
    HintWrap = true
};
```

**<span data-ttu-id="0f65e-168">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-168">Result:</span></span>**

![テキストが折り返されるアダプティブ タイル](images/adaptive-tiles-textwrapping.png)

## <a name="text-styles"></a><span data-ttu-id="0f65e-170">テキスト スタイル</span><span class="sxs-lookup"><span data-stu-id="0f65e-170">Text styles</span></span>


<span data-ttu-id="0f65e-171">スタイルを使って、text 要素のフォントのサイズ、色、太さを制御します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-171">Styles control the font size, color, and weight of text elements.</span></span> <span data-ttu-id="0f65e-172">多数のスタイルを使えます。たとえば、各スタイルの "Subtle" バリエーションを使って、テキストの不透明度を 60% に設定して、テキストの色を淡い灰色で暗くすることができます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-172">There are a number of available styles, including a "subtle" variation of each style that sets the opacity to 60%, which usually makes the text color a shade of light gray.</span></span>

```xml
<text hint-style="base">Header content</text>
<text hint-style="captionSubtle">Subheader content</text>
```

```csharp
new AdaptiveText()
{
    Text = "Header content",
    HintStyle = AdaptiveTextStyle.Base
},

new AdaptiveText()
{
    Text = "Subheader content",
    HintStyle = AdaptiveTextStyle.CaptionSubtle
}
```

**<span data-ttu-id="0f65e-173">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-173">Result:</span></span>**

![アダプティブ タイルのテキスト スタイル](images/adaptive-tiles-textstyles.png)

<span data-ttu-id="0f65e-175">**注**  hint-style を指定しない場合、スタイルは既定で caption に設定されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-175">**Note**  The style defaults to caption if hint-style isn't specified.</span></span>

 

**<span data-ttu-id="0f65e-176">基本的なテキスト スタイル</span><span class="sxs-lookup"><span data-stu-id="0f65e-176">Basic text styles</span></span>**

|                                |                           |             |
|--------------------------------|---------------------------|-------------|
| <span data-ttu-id="0f65e-177">&lt;text hint-style="\*" /&gt;</span><span class="sxs-lookup"><span data-stu-id="0f65e-177">&lt;text hint-style="\*" /&gt;</span></span> | <span data-ttu-id="0f65e-178">フォントの高さ</span><span class="sxs-lookup"><span data-stu-id="0f65e-178">Font height</span></span>               | <span data-ttu-id="0f65e-179">フォントの太さ</span><span class="sxs-lookup"><span data-stu-id="0f65e-179">Font weight</span></span> |
| <span data-ttu-id="0f65e-180">caption</span><span class="sxs-lookup"><span data-stu-id="0f65e-180">caption</span></span>                        | <span data-ttu-id="0f65e-181">12 epx (有効ピクセル)</span><span class="sxs-lookup"><span data-stu-id="0f65e-181">12 effective pixels (epx)</span></span> | <span data-ttu-id="0f65e-182">Regular</span><span class="sxs-lookup"><span data-stu-id="0f65e-182">Regular</span></span>     |
| <span data-ttu-id="0f65e-183">body</span><span class="sxs-lookup"><span data-stu-id="0f65e-183">body</span></span>                           | <span data-ttu-id="0f65e-184">15 epx</span><span class="sxs-lookup"><span data-stu-id="0f65e-184">15 epx</span></span>                    | <span data-ttu-id="0f65e-185">Regular</span><span class="sxs-lookup"><span data-stu-id="0f65e-185">Regular</span></span>     |
| <span data-ttu-id="0f65e-186">base</span><span class="sxs-lookup"><span data-stu-id="0f65e-186">base</span></span>                           | <span data-ttu-id="0f65e-187">15 epx</span><span class="sxs-lookup"><span data-stu-id="0f65e-187">15 epx</span></span>                    | <span data-ttu-id="0f65e-188">Semibold</span><span class="sxs-lookup"><span data-stu-id="0f65e-188">Semibold</span></span>    |
| <span data-ttu-id="0f65e-189">subtitle</span><span class="sxs-lookup"><span data-stu-id="0f65e-189">subtitle</span></span>                       | <span data-ttu-id="0f65e-190">20 epx</span><span class="sxs-lookup"><span data-stu-id="0f65e-190">20 epx</span></span>                    | <span data-ttu-id="0f65e-191">Regular</span><span class="sxs-lookup"><span data-stu-id="0f65e-191">Regular</span></span>     |
| <span data-ttu-id="0f65e-192">title</span><span class="sxs-lookup"><span data-stu-id="0f65e-192">title</span></span>                          | <span data-ttu-id="0f65e-193">24 epx</span><span class="sxs-lookup"><span data-stu-id="0f65e-193">24 epx</span></span>                    | <span data-ttu-id="0f65e-194">Semilight</span><span class="sxs-lookup"><span data-stu-id="0f65e-194">Semilight</span></span>   |
| <span data-ttu-id="0f65e-195">subheader</span><span class="sxs-lookup"><span data-stu-id="0f65e-195">subheader</span></span>                      | <span data-ttu-id="0f65e-196">34 epx</span><span class="sxs-lookup"><span data-stu-id="0f65e-196">34 epx</span></span>                    | <span data-ttu-id="0f65e-197">Light</span><span class="sxs-lookup"><span data-stu-id="0f65e-197">Light</span></span>       |
| <span data-ttu-id="0f65e-198">header</span><span class="sxs-lookup"><span data-stu-id="0f65e-198">header</span></span>                         | <span data-ttu-id="0f65e-199">46 epx</span><span class="sxs-lookup"><span data-stu-id="0f65e-199">46 epx</span></span>                    | <span data-ttu-id="0f65e-200">Light</span><span class="sxs-lookup"><span data-stu-id="0f65e-200">Light</span></span>       |

 

**<span data-ttu-id="0f65e-201">テキスト スタイルの Numeral バリエーション</span><span class="sxs-lookup"><span data-stu-id="0f65e-201">Numeral text style variations</span></span>**

<span data-ttu-id="0f65e-202">次のバリエーションでは、テキストに上下のコンテンツが近づくように、行の高さを減らすことができます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-202">These variations reduce the line height so that content above and below come much closer to the text.</span></span>

|                  |
|------------------|
| <span data-ttu-id="0f65e-203">titleNumeral</span><span class="sxs-lookup"><span data-stu-id="0f65e-203">titleNumeral</span></span>     |
| <span data-ttu-id="0f65e-204">subheaderNumeral</span><span class="sxs-lookup"><span data-stu-id="0f65e-204">subheaderNumeral</span></span> |
| <span data-ttu-id="0f65e-205">headerNumeral</span><span class="sxs-lookup"><span data-stu-id="0f65e-205">headerNumeral</span></span>    |

 

**<span data-ttu-id="0f65e-206">テキスト スタイルの Subtle バリエーション</span><span class="sxs-lookup"><span data-stu-id="0f65e-206">Subtle text style variations</span></span>**

<span data-ttu-id="0f65e-207">各スタイルの "Subtle" バリエーションでは、テキストの不透明度を 60% に設定して、テキストの色を淡い灰色で暗くすることができます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-207">Each style has a subtle variation that gives the text a 60% opacity, which usually makes the text color a shade of light gray.</span></span>

|                        |
|------------------------|
| <span data-ttu-id="0f65e-208">captionSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-208">captionSubtle</span></span>          |
| <span data-ttu-id="0f65e-209">bodySubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-209">bodySubtle</span></span>             |
| <span data-ttu-id="0f65e-210">baseSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-210">baseSubtle</span></span>             |
| <span data-ttu-id="0f65e-211">subtitleSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-211">subtitleSubtle</span></span>         |
| <span data-ttu-id="0f65e-212">titleSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-212">titleSubtle</span></span>            |
| <span data-ttu-id="0f65e-213">titleNumeralSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-213">titleNumeralSubtle</span></span>     |
| <span data-ttu-id="0f65e-214">subheaderSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-214">subheaderSubtle</span></span>        |
| <span data-ttu-id="0f65e-215">subheaderNumeralSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-215">subheaderNumeralSubtle</span></span> |
| <span data-ttu-id="0f65e-216">headerSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-216">headerSubtle</span></span>           |
| <span data-ttu-id="0f65e-217">headerNumeralSubtle</span><span class="sxs-lookup"><span data-stu-id="0f65e-217">headerNumeralSubtle</span></span>    |

 

## <a name="text-alignment"></a><span data-ttu-id="0f65e-218">テキストの配置</span><span class="sxs-lookup"><span data-stu-id="0f65e-218">Text alignment</span></span>


<span data-ttu-id="0f65e-219">テキストは、横方向の配置 (左揃え、中央揃え、または右揃え) を設定できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-219">Text can be horizontally aligned left, center, or right.</span></span> <span data-ttu-id="0f65e-220">英語のように左から右へと表記される言語では、テキストは既定で左揃えになります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-220">In left-to-right languages like English, text defaults to left-aligned.</span></span> <span data-ttu-id="0f65e-221">アラビア語のように右から左へと表記される言語では、テキストは既定で右揃えになります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-221">In right-to-left languages like Arabic, text defaults to right-aligned.</span></span> <span data-ttu-id="0f65e-222">テキストの配置は要素の **hint-align** 属性で手動で設定できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-222">You can manually set alignment with the **hint-align** attribute on elements.</span></span>

```xml
<text hint-align="center">Hello</text>
```


```csharp
new AdaptiveText()
{
    Text = "Hello",
    HintAlign = AdaptiveTextAlign.Center
};
```

**<span data-ttu-id="0f65e-223">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-223">Result:</span></span>**

![アダプティブ タイルのテキストの配置](images/adaptive-tiles-textalignment.png)

## <a name="groups-and-subgroups"></a><span data-ttu-id="0f65e-225">グループとサブグループ</span><span class="sxs-lookup"><span data-stu-id="0f65e-225">Groups and subgroups</span></span>


<span data-ttu-id="0f65e-226">グループを使って、グループ内のコンテンツが互いに関連していて意味をなすまとまりで表示される必要があることを宣言できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-226">Groups allow you to semantically declare that the content inside the group is related and must be displayed in its entirety for the content to make sense.</span></span> <span data-ttu-id="0f65e-227">たとえば、2 つの text 要素、1 つのヘッダー、1 つのサブヘッダーがあるとすると、ヘッダーのみが表示されても意味をなしません。</span><span class="sxs-lookup"><span data-stu-id="0f65e-227">For example, you might have two text elements, a header, and a subheader, and it would not make sense for only the header to be shown.</span></span> <span data-ttu-id="0f65e-228">要素をサブグループにまとめることで、それらの要素はすべて表示されるか (画面に収まる場合)、まったく表示されません (画面に収まらない場合)。</span><span class="sxs-lookup"><span data-stu-id="0f65e-228">By grouping those elements inside a subgroup, the elements will either all be displayed (if they can fit) or not be displayed at all (because they can't fit).</span></span>

<span data-ttu-id="0f65e-229">デバイスや画面間でのエクスペリエンスを最大限に高めるには、複数のグループを用意します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-229">To provide the best experience across devices and screens, provide multiple groups.</span></span> <span data-ttu-id="0f65e-230">複数のグループを使うと、タイルをより大きい画面に合わせて調整できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-230">Having multiple groups allows your tile to adapt to larger screens.</span></span>

<span data-ttu-id="0f65e-231">**注**  グループの有効な子はサブグループのみです。</span><span class="sxs-lookup"><span data-stu-id="0f65e-231">**Note**  The only valid child of a group is a subgroup.</span></span>

 

```xml
<binding template="TileWide" branding="nameAndLogo">
  <group>
    <subgroup>
      <text hint-style="subtitle">Jennifer Parker</text>
      <text hint-style="captionSubtle">Photos from our trip</text>
      <text hint-style="captionSubtle">Check out these awesome photos I took while in New Zealand!</text>
    </subgroup>
  </group>
 
  <text />
 
  <group>
    <subgroup>
      <text hint-style="subtitle">Steve Bosniak</text>
      <text hint-style="captionSubtle">Build 2015 Dinner</text>
      <text hint-style="captionSubtle">Want to go out for dinner after Build tonight?</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Branding = TileBranding.NameAndLogo,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            CreateGroup(
                from: "Jennifer Parker",
                subject: "Photos from our trip",
                body: "Check out these awesome photos I took while in New Zealand!"),

            // For spacing
            new AdaptiveText(),

            CreateGroup(
                from: "Steve Bosniak",
                subject: "Build 2015 Dinner",
                body: "Want to go out for dinner after Build tonight?")
        }
    }
}

...

private static AdaptiveGroup CreateGroup(string from, string subject, string body)
{
    return new AdaptiveGroup()
    {
        Children =
        {
            new AdaptiveSubgroup()
            {
                Children =
                {
                    new AdaptiveText()
                    {
                        Text = from,
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },
                    new AdaptiveText()
                    {
                        Text = subject,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },
                    new AdaptiveText()
                    {
                        Text = body,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
            }
        }
    };
}
```

**<span data-ttu-id="0f65e-232">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-232">Result:</span></span>**

![アダプティブ タイルのグループとサブグループ](images/adaptive-tiles-groups-subgroups.png)

## <a name="subgroups-columns"></a><span data-ttu-id="0f65e-234">サブグループ (列)</span><span class="sxs-lookup"><span data-stu-id="0f65e-234">Subgroups (columns)</span></span>


<span data-ttu-id="0f65e-235">サブグループを使って、グループのデータを意味をなすまとまりに分けることもできます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-235">Subgroups also allow you to divide data into semantic sections within a group.</span></span> <span data-ttu-id="0f65e-236">ライブ タイルの場合、このまとまりは視覚的には列になります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-236">For live tiles, this visually translates to columns.</span></span>

<span data-ttu-id="0f65e-237">**hint-weight** 属性を使うと、列の幅を制御できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-237">The **hint-weight** attribute lets you to control the widths of columns.</span></span> <span data-ttu-id="0f65e-238">**hint-weight** の値は、空いているスペースに適用される重みとして表され、**GridUnitType.Star** と同じ動作になります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-238">The value of **hint-weight** is expressed as a weighted proportion of available space, which is identical to **GridUnitType.Star** behavior.</span></span> <span data-ttu-id="0f65e-239">各列の幅を同じにする場合は、各列に 1 の重みを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-239">For equal-width columns, assign each weight to 1.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f65e-240">hint-weight</span><span class="sxs-lookup"><span data-stu-id="0f65e-240">hint-weight</span></span></td>
<td align="left"><span data-ttu-id="0f65e-241">幅の割合</span><span class="sxs-lookup"><span data-stu-id="0f65e-241">Percentage of width</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f65e-242">1</span><span class="sxs-lookup"><span data-stu-id="0f65e-242">1</span></span></td>
<td align="left"><span data-ttu-id="0f65e-243">25%</span><span class="sxs-lookup"><span data-stu-id="0f65e-243">25%</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f65e-244">1</span><span class="sxs-lookup"><span data-stu-id="0f65e-244">1</span></span></td>
<td align="left"><span data-ttu-id="0f65e-245">25%</span><span class="sxs-lookup"><span data-stu-id="0f65e-245">25%</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f65e-246">1</span><span class="sxs-lookup"><span data-stu-id="0f65e-246">1</span></span></td>
<td align="left"><span data-ttu-id="0f65e-247">25%</span><span class="sxs-lookup"><span data-stu-id="0f65e-247">25%</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f65e-248">1</span><span class="sxs-lookup"><span data-stu-id="0f65e-248">1</span></span></td>
<td align="left"><span data-ttu-id="0f65e-249">25%</span><span class="sxs-lookup"><span data-stu-id="0f65e-249">25%</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f65e-250">重み合計: 4</span><span class="sxs-lookup"><span data-stu-id="0f65e-250">Total weight: 4</span></span></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![サブグループ、等列幅](images/adaptive-tiles-subgroups01.png)

<span data-ttu-id="0f65e-252">ある列の幅を別の列の幅の 2 倍にするには、狭い方の列に 1 の重みを割り当て、広い方の列に 2 の重みを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-252">To make one column twice as large as another column, assign the smaller column a weight of 1 and the larger column a weight of 2.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f65e-253">hint-weight</span><span class="sxs-lookup"><span data-stu-id="0f65e-253">hint-weight</span></span></td>
<td align="left"><span data-ttu-id="0f65e-254">幅の割合</span><span class="sxs-lookup"><span data-stu-id="0f65e-254">Percentage of width</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f65e-255">1</span><span class="sxs-lookup"><span data-stu-id="0f65e-255">1</span></span></td>
<td align="left"><span data-ttu-id="0f65e-256">33.3%</span><span class="sxs-lookup"><span data-stu-id="0f65e-256">33.3%</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f65e-257">2</span><span class="sxs-lookup"><span data-stu-id="0f65e-257">2</span></span></td>
<td align="left"><span data-ttu-id="0f65e-258">66.7%</span><span class="sxs-lookup"><span data-stu-id="0f65e-258">66.7%</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f65e-259">重み合計: 3</span><span class="sxs-lookup"><span data-stu-id="0f65e-259">Total weight: 3</span></span></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![サブグループ、ある列幅が別の列幅の 2 倍](images/adaptive-tiles-subgroups02.png)

<span data-ttu-id="0f65e-261">最初の列が全体の幅の 80% を占め、2 番目の列が全体の幅の 20% を占めるようにする場合は、最初の列に 20 の重みを割り当て、2 番目の列に 80 の重みを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-261">If you want your first column to take up 20% of the total width and your second column to take up 80% of the total width, assign the first weight to 20 and the second weight to 80.</span></span> <span data-ttu-id="0f65e-262">重み合計が 100 に等しい場合、重みの値はパーセンテージとして扱われます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-262">If your total weights equal 100, they'll act as percentages.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="0f65e-263">hint-weight</span><span class="sxs-lookup"><span data-stu-id="0f65e-263">hint-weight</span></span></td>
<td align="left"><span data-ttu-id="0f65e-264">幅の割合</span><span class="sxs-lookup"><span data-stu-id="0f65e-264">Percentage of width</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f65e-265">20</span><span class="sxs-lookup"><span data-stu-id="0f65e-265">20</span></span></td>
<td align="left"><span data-ttu-id="0f65e-266">20%</span><span class="sxs-lookup"><span data-stu-id="0f65e-266">20%</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="0f65e-267">80</span><span class="sxs-lookup"><span data-stu-id="0f65e-267">80</span></span></td>
<td align="left"><span data-ttu-id="0f65e-268">80%</span><span class="sxs-lookup"><span data-stu-id="0f65e-268">80%</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="0f65e-269">重み合計: 100</span><span class="sxs-lookup"><span data-stu-id="0f65e-269">Total weight: 100</span></span></td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![サブグループ、重み合計が 100](images/adaptive-tiles-subgroups03.png)

<span data-ttu-id="0f65e-271">**注**  8 ピクセルの余白が列の間に自動的に追加されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-271">**Note**  An 8-pixel margin is automatically added between the columns.</span></span>

 

<span data-ttu-id="0f65e-272">サブグループが 3 つ以上あるときは、正の整数のみを受け取る **hint-weight** を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-272">When you have more than two subgroups, you should specify the **hint-weight**, which only accepts positive integers.</span></span> <span data-ttu-id="0f65e-273">1 番目のサブグループの hint-weight を指定しない場合、そのサブグループには 50 の重みが割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-273">If you don't specify hint-weight for the first subgroup, it will be assigned a weight of 50.</span></span> <span data-ttu-id="0f65e-274">hint-weight を指定していない次のサブグループには、100 から前の重みの合計を引いた値に等しい重みが割り当てられます。または、引いた結果がゼロであれば、1 が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-274">The next subgroup that doesn't have a specified hint-weight will be assigned a weight equal to 100 minus the sum of the preceding weights, or to 1 if the result is zero.</span></span> <span data-ttu-id="0f65e-275">hint-weight を指定していない残りのサブグループには、1 の重みが割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-275">The remaining subgroups that don't have specified hint-weights will be assigned a weight of 1.</span></span>

<span data-ttu-id="0f65e-276">ここで示しているのは、天気タイルのサンプル コードで、等幅の 5 つの列で構成されたタイルになります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-276">Here's sample code for a weather tile that shows how you can achieve a tile with five columns of equal width:</span></span>

```xml
<binding template="TileWide" displayName="Seattle" branding="name">
  <group>
    <subgroup hint-weight="1">
      <text hint-align="center">Mon</text>
      <image src="Assets\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Tue</text>
      <image src="Assets\Weather\Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-align="center" hint-style="captionsubtle">38°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Wed</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">59°</text>
      <text hint-align="center" hint-style="captionsubtle">43°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Thu</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">62°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Fri</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">71°</text>
      <text hint-align="center" hint-style="captionsubtle">66°</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    DisplayName = "Seattle",
    Branding = TileBranding.Name,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°"),
                    CreateSubgroup("Tue", "Cloudy.png", "57°", "38°"),
                    CreateSubgroup("Wed", "Sunny.png", "59°", "43°"),
                    CreateSubgroup("Thu", "Sunny.png", "62°", "42°"),
                    CreateSubgroup("Fri", "Sunny.png", "71°", "66°")
                }
            }
        }
    }
}

...

private static AdaptiveSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new AdaptiveSubgroup()
    {
        HintWeight = 1,
        Children =
        {
            new AdaptiveText()
            {
                Text = day,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveImage()
            {
                Source = "Assets/Weather/" + image,
                HintRemoveMargin = true
            },
            new AdaptiveText()
            {
                Text = highTemp,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = lowTemp,
                HintAlign = AdaptiveTextAlign.Center,
                HintStyle = AdaptiveTextStyle.CaptionSubtle
            }
        }
    };
}
```

**<span data-ttu-id="0f65e-277">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-277">Result:</span></span>**

![天気タイルの例](images/adaptive-tiles-weathertile.png)

## <a name="images"></a><span data-ttu-id="0f65e-279">画像</span><span class="sxs-lookup"><span data-stu-id="0f65e-279">Images</span></span>


<span data-ttu-id="0f65e-280">&lt;image&gt; 要素を使って、タイル通知に画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-280">The &lt;image&gt; element is used to display images on the tile notification.</span></span> <span data-ttu-id="0f65e-281">画像はタイル コンテンツ (既定) 内に、背景画像としてか、タイルでアニメーション化されるプレビュー画像として、インラインで配置できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-281">Images can be placed inline within the tile content (default), as a background image behind your content, or as a peek image that animates in from the top of the notification.</span></span>

> [!NOTE]
> <span data-ttu-id="0f65e-282">画像は、アプリのパッケージ、アプリのローカル ストレージ、または Web から使用できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-282">Images can be used from the app's package, the app's local storage, or from the web.</span></span> <span data-ttu-id="0f65e-283">Fall Creators Update の時点で、Web 画像の上限は通常の接続で 3 MB、従量制課金接続で 1 MB です。</span><span class="sxs-lookup"><span data-stu-id="0f65e-283">As of the Fall Creators Update, web images can be up to 3 MB on normal connections and 1 MB on metered connections.</span></span> <span data-ttu-id="0f65e-284">まだ Fall Creators Update を実行していないデバイスでは、Web イメージは 200 KB を上限とします。</span><span class="sxs-lookup"><span data-stu-id="0f65e-284">On devices not yet running the Fall Creators Update, web images must be no larger than 200 KB.</span></span>

 

<span data-ttu-id="0f65e-285">特に動作が指定されていない場合、幅に合わせて縦横比を保ったまま拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-285">With no extra behaviors specified, images will uniformly shrink or expand to fill the available width.</span></span> <span data-ttu-id="0f65e-286">次のサンプルでは、2 列とインライン画像を使用したタイルを示しています。</span><span class="sxs-lookup"><span data-stu-id="0f65e-286">This example shows a tile using two columns and inline images.</span></span> <span data-ttu-id="0f65e-287">インライン画像は列幅に合わせて拡大されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-287">The inline images stretch to fill the width of the column.</span></span>

```xml
<binding template="TileMedium" displayName="Seattle" branding="name">
  <group>
    <subgroup>
      <text hint-align="center">Mon</text>
      <image src="Assets\Apps\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-style="captionsubtle" hint-align="center">42°</text>
    </subgroup>
    <subgroup>
      <text hint-align="center">Tue</text>
      <image src="Assets\Apps\Weather\Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-style="captionSubtle" hint-align="center">38°</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileMedium = new TileBinding()
{
    DisplayName = "Seattle",
    Branding = TileBranding.Name,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°"),
                    CreateSubgroup("Tue", "Cloudy.png", "57°", "38°")
                }
            }
        }
    }
}
...
private static AdaptiveSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new AdaptiveSubgroup()
    {
        Children =
        {
            new AdaptiveText()
            {
                Text = day,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveImage()
            {
                Source = "Assets/Weather/" + image,
                HintRemoveMargin = true
            },
            new AdaptiveText()
            {
                Text = highTemp,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = lowTemp,
                HintAlign = AdaptiveTextAlign.Center,
                HintStyle = AdaptiveTextStyle.CaptionSubtle
            }
        }
    };
}
```

**<span data-ttu-id="0f65e-288">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-288">Result:</span></span>**

![画像の例](images/adaptive-tiles-images01.png)

<span data-ttu-id="0f65e-290">&lt;binding&gt; のルート、つまり最初のグループに配置された画像も、空いている高さに合わせて拡大されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-290">Images placed in the &lt;binding&gt; root, or in the first group, will also stretch to fit the available height.</span></span>

### <a name="image-alignment"></a><span data-ttu-id="0f65e-291">画像の配置</span><span class="sxs-lookup"><span data-stu-id="0f65e-291">Image alignment</span></span>

<span data-ttu-id="0f65e-292">画像は、**hint-align** 属性を使って、左揃え、中央揃え、または右揃えに設定できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-292">Images can be set to align left, center, or right using the **hint-align** attribute.</span></span> <span data-ttu-id="0f65e-293">また、これにより画像は、幅を埋めるように拡大されずに、ネイティブの解像度で表示されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-293">This will also cause images to display at their native resolution instead of stretching to fill width.</span></span>

```xml
<binding template="TileLarge">
  <image src="Assets/fable.jpg" hint-align="center"/>
</binding>
```

```csharp
TileLarge = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveImage()
            {
                Source = "Assets/fable.jpg",
                HintAlign = AdaptiveImageAlign.Center
            }
        }
    }
}
```

**<span data-ttu-id="0f65e-294">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-294">Result:</span></span>**

![画像の配置の例 (左、中央、右)](images/adaptive-tiles-imagealignment.png)

### <a name="image-margins"></a><span data-ttu-id="0f65e-296">画像の余白</span><span class="sxs-lookup"><span data-stu-id="0f65e-296">Image margins</span></span>

<span data-ttu-id="0f65e-297">既定では、インライン画像の上または下には、コンテンツとの間に 8 ピクセルの余白が追加されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-297">By default, inline images have an 8-pixel margin between any content above or below the image.</span></span> <span data-ttu-id="0f65e-298">この余白は、画像の **hint-removeMargin** 属性を使って削除できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-298">This margin can be removed by using the **hint-removeMargin** attribute on the image.</span></span> <span data-ttu-id="0f65e-299">ただし、画像では常にタイルの端から 8 ピクセルの余白が保持され、サブグループ (列) では常に列の間に 8 ピクセルのパディングが保持されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-299">However, images always retain the 8-pixel margin from the edge of the tile, and subgroups (columns) always retain the 8-pixel padding between columns.</span></span>

```xml
<binding template="TileMedium" branding="none">
  <group>
    <subgroup>
      <text hint-align="center">Mon</text>
      <image src="Assets\Numbers\4.jpg" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-style="captionsubtle" hint-align="center">42°</text>
    </subgroup>
    <subgroup>
      <text hint-align="center">Tue</text>
      <image src="Assets\Numbers\3.jpg" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-style="captionsubtle" hint-align="center">38°</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileMedium = new TileBinding()
{
    Branding = TileBranding.None,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "4.jpg", "63°", "42°"),
                    CreateSubgroup("Tue", "3.jpg", "57°", "38°")
                }
            }
        }
    }
}

...

private static AdaptiveSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new AdaptiveSubgroup()
    {
        HintWeight = 1,
        Children =
        {
            new AdaptiveText()
            {
                Text = day,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveImage()
            {
                Source = "Assets/Numbers/" + image,
                HintRemoveMargin = true
            },
            new AdaptiveText()
            {
                Text = highTemp,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = lowTemp,
                HintAlign = AdaptiveTextAlign.Center,
                HintStyle = AdaptiveTextStyle.CaptionSubtle
            }
        }
    };
}
```

![画像の余白削除の例](images/adaptive-tiles-removemargin.png)

### <a name="image-cropping"></a><span data-ttu-id="0f65e-301">画像のトリミング</span><span class="sxs-lookup"><span data-stu-id="0f65e-301">Image cropping</span></span>

<span data-ttu-id="0f65e-302">**hint-crop** 属性を使って、画像を円形にトリミングできます。現時点では、"none" (既定) または "circle" のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0f65e-302">Images can be cropped into a circle using the **hint-crop** attribute, which currently only supports the values "none" (default) or "circle."</span></span>

```xml
<binding template="TileLarge" hint-textStacking="center">
  <group>
    <subgroup hint-weight="1"/>
    <subgroup hint-weight="2">
      <image src="Assets/Apps/Hipstame/hipster.jpg" hint-crop="circle"/>
    </subgroup>
    <subgroup hint-weight="1"/>
  </group>
 
  <text hint-style="title" hint-align="center">Hi,</text>
  <text hint-style="subtitleSubtle" hint-align="center">MasterHip</text>
</binding>
```

```csharp
TileLarge = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        TextStacking = TileTextStacking.Center,
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    new AdaptiveSubgroup() { HintWeight = 1 },
                    new AdaptiveSubgroup()
                    {
                        HintWeight = 2,
                        Children =
                        {
                            new AdaptiveImage()
                            {
                                Source = "Assets/Apps/Hipstame/hipster.jpg",
                                HintCrop = AdaptiveImageCrop.Circle
                            }
                        }
                    },
                    new AdaptiveSubgroup() { HintWeight = 1 }
                }
            },
            new AdaptiveText()
            {
                Text = "Hi,",
                HintStyle = AdaptiveTextStyle.Title,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = "MasterHip",
                HintStyle = AdaptiveTextStyle.SubtitleSubtle,
                HintAlign = AdaptiveTextAlign.Center
            }
        }
    }
}
```

**<span data-ttu-id="0f65e-303">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-303">Result:</span></span>**

![画像のトリミングの例](images/adaptive-tiles-imagecropping.png)

### <a name="background-image"></a><span data-ttu-id="0f65e-305">バックグラウンド画像</span><span class="sxs-lookup"><span data-stu-id="0f65e-305">Background image</span></span>

<span data-ttu-id="0f65e-306">背景画像を設定するには、&lt;binding&gt; のルートに image 要素を追加し、placement 属性を "background" に設定します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-306">To set a background image, place an image element in the root of the &lt;binding&gt; and set the placement attribute to "background."</span></span>

```xml
<binding template="TileWide">
  <image src="Assets\Mostly Cloudy-Background.jpg" placement="background"/>
  <group>
    <subgroup hint-weight="1">
      <text hint-align="center">Mon</text>
      <image src="Assets\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    ...
  </group>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        BackgroundImage = new TileBackgroundImage()
        {
            Source = "Assets/Mostly Cloudy-Background.jpg"
        },

        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°")
                    ...
                }
            }
        }
    }
}

...

private static AdaptiveSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new AdaptiveSubgroup()
    {
        HintWeight = 1,
        Children =
        {
            new AdaptiveText()
            {
                Text = day,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveImage()
            {
                Source = "Assets/Weather/" + image,
                HintRemoveMargin = true
            },
            new AdaptiveText()
            {
                Text = highTemp,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = lowTemp,
                HintAlign = AdaptiveTextAlign.Center,
                HintStyle = AdaptiveTextStyle.CaptionSubtle
            }
        }
    };
}
```

**<span data-ttu-id="0f65e-307">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-307">Result:</span></span>**

![背景画像の例](images/adaptive-tiles-backgroundimage.png)

### <a name="peek-image"></a><span data-ttu-id="0f65e-309">プレビュー画像</span><span class="sxs-lookup"><span data-stu-id="0f65e-309">Peek image</span></span>

<span data-ttu-id="0f65e-310">タイルでアニメーション化されるプレビュー画像を指定できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-310">You can specify an image that "peeks" in from the top of the tile.</span></span> <span data-ttu-id="0f65e-311">プレビュー画像はタイルでアニメーション化されます。コンテンツが下にスライドしてプレビューが現れ、上にスライドしてプレビューが隠れます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-311">The peek image uses an animation to slide down/up from the top of the tile, peeking into view, and then later sliding back out to reveal the main content on the tile.</span></span> <span data-ttu-id="0f65e-312">プレビュー画像を設定するには、&lt;binding&gt; のルートに image 要素を追加し、placement 属性を "peek" に設定します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-312">To set a peek image, place an image element in the root of the &lt;binding&gt;, and set the placement attribute to "peek."</span></span>

```xml
<binding template="TileMedium" branding="name">
  <image placement="peek" src="Assets/Apps/Hipstame/hipster.jpg"/>
  <text>New Message</text>
  <text hint-style="captionsubtle" hint-wrap="true">Hey, have you tried Windows 10 yet?</text>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Branding = TileBranding.Name,
    Content = new TileBindingContentAdaptive()
    {
        PeekImage = new TilePeekImage()
        {
            Source = "Assets/Apps/Hipstame/hipster.jpg"
        },
        Children =
        {
            new AdaptiveText()
            {
                Text = "New Message"
            },
            new AdaptiveText()
            {
                Text = "Hey, have you tried Windows 10 yet?",
                HintStyle = AdaptiveTextStyle.CaptionSubtle,
                HintWrap = true
            }
        }
    }
}
```

![プレビュー画像の例](images/adaptive-tiles-imagepeeking.png)

**<span data-ttu-id="0f65e-314">プレビュー画像と背景画像の円トリミング</span><span class="sxs-lookup"><span data-stu-id="0f65e-314">Circle crop for peek and background images</span></span>**

<span data-ttu-id="0f65e-315">円トリミングを行うには、プレビュー画像と背景画像で hint-crop 属性を使用します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-315">Use the hint-crop attribute on peek and background images to do a circle crop:</span></span>

```xml
<image placement="peek" hint-crop="circle" src="Assets/Apps/Hipstame/hipster.jpg"/>
```

```csharp
new TilePeekImage()
{
    HintCrop = TilePeekImageCrop.Circle,
    Source = "Assets/Apps/Hipstame/hipster.jpg"
}
```

<span data-ttu-id="0f65e-316">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-316">The result will look like this:</span></span>

![プレビュー画像と背景画像の円トリミング](images/circlecrop-image.png)

**<span data-ttu-id="0f65e-318">プレビュー画像と背景画像の両方を使用</span><span class="sxs-lookup"><span data-stu-id="0f65e-318">Use both peek and background image</span></span>**

<span data-ttu-id="0f65e-319">タイル通知でプレビュー画像と背景画像の両方を使用するには、通知ペイロードでプレビュー画像と背景画像の両方を指定します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-319">To use both a peek and a background image on a tile notification, specify both a peek image and a background image in your notification payload.</span></span>

<span data-ttu-id="0f65e-320">結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="0f65e-320">The result will look like this:</span></span>

![一緒に使用されているプレビュー画像と背景画像](images/peekandbackground.png)


### <a name="peek-and-background-image-overlays"></a><span data-ttu-id="0f65e-322">プレビュー画像と背景画像のオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="0f65e-322">Peek and background image overlays</span></span>

<span data-ttu-id="0f65e-323">**hint-overlay** を使って、背景画像とプレビュー画像上に黒のオーバーレイを設定できます。この属性は 0 ～ 100 の整数を受け取ります。0 はオーバーレイなし、100 は完全な黒のオーバーレイを表します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-323">You can set a black overlay on your background and peek images using **hint-overlay**, which accepts integers from 0-100, with 0 being no overlay and 100 being full black overlay.</span></span> <span data-ttu-id="0f65e-324">オーバーレイを使うことで、タイル上のテキストを読みやすく表示できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-324">You can use the overlay to help ensure that text on your tile is readable.</span></span>

**<span data-ttu-id="0f65e-325">背景画像での hint-overlay の使用</span><span class="sxs-lookup"><span data-stu-id="0f65e-325">Use hint-overlay on a background image</span></span>**

<span data-ttu-id="0f65e-326">ペイロードにテキスト要素が含まれている場合、背景画像のオーバーレイは既定で 20% です (そうでない場合、既定のオーバーレイは 0% です)。</span><span class="sxs-lookup"><span data-stu-id="0f65e-326">Your background image will default to 20% overlay as long as you have some text elements in your payload (otherwise it will default to 0% overlay).</span></span>

```xml
<binding template="TileWide">
  <image placement="background" hint-overlay="60" src="Assets\Mostly Cloudy-Background.jpg"/>
  ...
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        BackgroundImage = new TileBackgroundImage()
        {
            Source = "Assets/Mostly Cloudy-Background.jpg",
            HintOverlay = 60
        },

        ...
    }
}
```

**<span data-ttu-id="0f65e-327">結果:</span><span class="sxs-lookup"><span data-stu-id="0f65e-327">hint-overlay Result:</span></span>**

![画像のオーバーレイの例](images/adaptive-tiles-image-hintoverlay.png)

**<span data-ttu-id="0f65e-329">プレビュー画像での hint-overlay の使用</span><span class="sxs-lookup"><span data-stu-id="0f65e-329">Use hint-overlay on a peek image</span></span>**

<span data-ttu-id="0f65e-330">Windows 10 Version 1511 では、背景画像と同様、プレビュー画像のオーバーレイもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0f65e-330">In Version 1511 of Windows 10, we support an overlay for your peek image too, just like your background image.</span></span> <span data-ttu-id="0f65e-331">プレビュー画像要素の hint-overlay には、0 ～ 100 の整数を指定します。</span><span class="sxs-lookup"><span data-stu-id="0f65e-331">Specify hint-overlay on the peek image element as an integer from 0-100.</span></span> <span data-ttu-id="0f65e-332">プレビュー画像の既定のオーバーレイは、0 (オーバーレイなし) です。</span><span class="sxs-lookup"><span data-stu-id="0f65e-332">The default overlay for peek images is 0 (no overlay).</span></span>

```xml
<binding template="TileMedium">
  <image hint-overlay="20" src="Assets\Map.jpg" placement="peek"/>
  ...
</binding>
```

```csharp
TileMedium = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        PeekImage = new TilePeekImage()
        {
            Source = "Assets/Map.jpg",
            HintOverlay = 20
        },
        ...
    }
}
```

<span data-ttu-id="0f65e-333">以下の例では、20% の不透明度 (左) と 0% の不透明度 (右) のプレビュー画像を示しています。</span><span class="sxs-lookup"><span data-stu-id="0f65e-333">This example shows a peek image at 20% opacity (left) and at 0% opacity (right):</span></span>

![プレビュー画像での hint-overlay](images/hintoverlay.png)

## <a name="vertical-alignment-text-stacking"></a><span data-ttu-id="0f65e-335">縦方向の配置 (テキストの積み重ね)</span><span class="sxs-lookup"><span data-stu-id="0f65e-335">Vertical alignment (text stacking)</span></span>


<span data-ttu-id="0f65e-336">[TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) 要素と [AdaptiveSubgroup](../tiles-and-notifications/tile-schema.md#adaptivesubgroup) 要素のいずれに対しても **hint-textStacking** 属性を使って、タイルのコンテンツの縦方向の配置を制御できます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-336">You can control the vertical alignment of content on your tile by using the **hint-textStacking** attribute on both the [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) element and [AdaptiveSubgroup](../tiles-and-notifications/tile-schema.md#adaptivesubgroup) element.</span></span> <span data-ttu-id="0f65e-337">既定では、コンテンツは上揃えになりますが、下揃えまたは中央揃えに設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-337">By default, everything is vertically aligned to the top, but you can also align content to the bottom or center.</span></span>

### <a name="text-stacking-on-binding-element"></a><span data-ttu-id="0f65e-338">binding 要素でのテキストの積み重ね</span><span class="sxs-lookup"><span data-stu-id="0f65e-338">Text stacking on binding element</span></span>

<span data-ttu-id="0f65e-339">テキストの積み重ねを [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) レベルで適用すると、ブランディング/バッジ領域の上にある縦方向のスペースに収まるように、通知コンテンツ全体の縦方向の配置が設定されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-339">When applied at the [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) level, text stacking sets the vertical alignment of the notification content as a whole, aligning in the available vertical space above the branding/badge area.</span></span>

```xml
<binding template="TileMedium" hint-textStacking="center" branding="logo">
  <text hint-style="base" hint-align="center">Hi,</text>
  <text hint-style="captionSubtle" hint-align="center">MasterHip</text>
</binding>
```

```csharp
TileMedium = new TileBinding()
{
    Branding = TileBranding.Logo,
    Content = new TileBindingContentAdaptive()
    {
        TextStacking = TileTextStacking.Center,
        Children =
        {
            new AdaptiveText()
            {
                Text = "Hi,",
                HintStyle = AdaptiveTextStyle.Base,
                HintAlign = AdaptiveTextAlign.Center
            },

            new AdaptiveText()
            {
                Text = "MasterHip",
                HintStyle = AdaptiveTextStyle.CaptionSubtle,
                HintAlign = AdaptiveTextAlign.Center
            }
        }
    }
}
```

![binding 要素でのテキストの積み重ね](images/adaptive-tiles-textstack-bindingelement.png)

### <a name="text-stacking-on-subgroup-element"></a><span data-ttu-id="0f65e-341">subgroup 要素でのテキストの積み重ね</span><span class="sxs-lookup"><span data-stu-id="0f65e-341">Text stacking on subgroup element</span></span>

<span data-ttu-id="0f65e-342">テキストの積み重ねを [AdaptiveSubgroup](../tiles-and-notifications/tile-schema.md#adaptivesubgroup) レベルで適用すると、そのグループ内の縦方向のスペースに収まるように、サブグループ (列) コンテンツの縦方向の配置が設定されます。</span><span class="sxs-lookup"><span data-stu-id="0f65e-342">When applied at the [AdaptiveSubgroup](../tiles-and-notifications/tile-schema.md#adaptivesubgroup) level, text stacking sets the vertical alignment of the subgroup (column) content, aligning in the available vertical space within the entire group.</span></span>

```xml
<binding template="TileWide" branding="nameAndLogo">
  <group>
    <subgroup hint-weight="33">
      <image src="Assets/Apps/Hipstame/hipster.jpg" hint-crop="circle"/>
    </subgroup>
    <subgroup hint-textStacking="center">
      <text hint-style="subtitle">Hi,</text>
      <text hint-style="bodySubtle">MasterHip</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Branding = TileBranding.NameAndLogo,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    // Image column
                    new AdaptiveSubgroup()
                    {
                        HintWeight = 33,
                        Children =
                        {
                            new AdaptiveImage()
                            {
                                Source = "Assets/Apps/Hipstame/hipster.jpg",
                                HintCrop = AdaptiveImageCrop.Circle
                            }
                        }
                    },

                    // Text column
                    new AdaptiveSubgroup()
                    {
                        // Vertical align its contents
                        TextStacking = TileTextStacking.Center,
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "Hi,",
                                HintStyle = AdaptiveTextStyle.Subtitle
                            },

                            new AdaptiveText()
                            {
                                Text = "MasterHip",
                                HintStyle = AdaptiveTextStyle.BodySubtle
                            }
                        }
                    }
                }
            }
        }
    }
}
```

## <a name="related-topics"></a><span data-ttu-id="0f65e-343">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0f65e-343">Related topics</span></span>
* [<span data-ttu-id="0f65e-344">タイルのコンテンツのスキーマ</span><span class="sxs-lookup"><span data-stu-id="0f65e-344">Tile content schema</span></span>](../tiles-and-notifications/tile-schema.md)
* [<span data-ttu-id="0f65e-345">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="0f65e-345">Send a local tile notification</span></span>](sending-a-local-tile-notification.md)
* [<span data-ttu-id="0f65e-346">特別なタイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="0f65e-346">Special tile templates</span></span>](special-tile-templates-catalog.md)
* [<span data-ttu-id="0f65e-347">UWP コミュニティ ツールキット - Notifications</span><span class="sxs-lookup"><span data-stu-id="0f65e-347">UWP Community Toolkit - Notifications</span></span>](https://github.com/Microsoft/UWPCommunityToolkit/tree/master/Microsoft.Toolkit.Uwp.Notifications)
* [<span data-ttu-id="0f65e-348">GitHub の Windows Notifications</span><span class="sxs-lookup"><span data-stu-id="0f65e-348">Windows Notifications on GitHub</span></span>](https://github.com/WindowsNotifications)

 

 




