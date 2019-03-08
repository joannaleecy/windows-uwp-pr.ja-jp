---
Description: 特別なタイル テンプレートは、アニメーション化や、アダプティブ タイルでは不可能な機能を実行できる独特なテンプレートです。
title: 特別なタイル テンプレート
ms.assetid: 1322C9BA-D5B2-45E2-B813-865884A467FF
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 09647347134463c8dd2d93f6b869796c8def44e2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57619807"
---
# <a name="special-tile-templates"></a><span data-ttu-id="a6ef6-104">特別なタイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="a6ef6-104">Special tile templates</span></span>
 

<span data-ttu-id="a6ef6-105">特別なタイル テンプレートは、アニメーション化や、アダプティブ タイルでは不可能な機能を実行できる独特なテンプレートです。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-105">Special tile templates are unique templates that are either animated, or just allow you to do things that aren't possible with adaptive tiles.</span></span> <span data-ttu-id="a6ef6-106">各タイルの特殊なテンプレートが向けに作成された Windows 10、象徴的なタイル テンプレートを除く Windows 10 用に更新されている従来の特殊なテンプレートです。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-106">Each special tile template was specifically built for Windows 10, except for the iconic tile template, a classic special template that has been updated for Windows 10.</span></span> <span data-ttu-id="a6ef6-107">この記事では、次の 3 つの特殊なタイル テンプレートについて説明します。アイコン、写真、およびユーザー。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-107">This article covers three special tile templates: Iconic, Photos, and People.</span></span>

## <a name="iconic-tile-template"></a><span data-ttu-id="a6ef6-108">アイコン タイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="a6ef6-108">Iconic tile template</span></span>


<span data-ttu-id="a6ef6-109">アイコン テンプレート ("IconWithBadge" テンプレートとも呼ばれます) を使うと、タイルの中央に小さい画像を表示できます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-109">The iconic template (also known as the "IconWithBadge" template) lets you display a small image in the center of the tile.</span></span> <span data-ttu-id="a6ef6-110">Windows 10 では、電話とタブレット/デスクトップの両方で、テンプレートをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-110">Windows 10 supports the template on both phone and tablet/desktop.</span></span>

![小サイズと普通サイズのメール タイル](images/iconic-template-mail-2sizes.png)

### <a name="how-to-create-an-iconic-tile"></a><span data-ttu-id="a6ef6-112">アイコン タイルを作成する方法</span><span class="sxs-lookup"><span data-stu-id="a6ef6-112">How to create an iconic tile</span></span>

<span data-ttu-id="a6ef6-113">次の手順では、Windows 10 のアイコンのタイルを作成するために必要なものすべてについて説明します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-113">The following steps cover everything you need to know to create an iconic tile for Windows 10.</span></span> <span data-ttu-id="a6ef6-114">大まかに言うと、まずアイコンの画像アセットを用意する必要があります。次に、アイコン テンプレートを使って通知をタイルに送信し、最後に、タイルに表示される番号を指定するバッジ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-114">At a high level, you need your iconic image asset, then you send a notification to the tile using the iconic template, and finally you send a badge notification that provides the number to be displayed on the tile.</span></span>

![アイコン タイルの開発フロー](images/iconic-template-dev-flow.png)

<span data-ttu-id="a6ef6-116">**手順 1: PNG 形式のイメージ アセットを作成します。**</span><span class="sxs-lookup"><span data-stu-id="a6ef6-116">**Step 1: Create your image assets in PNG format**</span></span>

<span data-ttu-id="a6ef6-117">タイルのアイコン アセットを作成し、他のアセットと共にプロジェクト リソースに配置します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-117">Create the icon assets for your tile and place those in your project resources with your other assets.</span></span> <span data-ttu-id="a6ef6-118">200 x 200 ピクセル以上のアイコンを作成してください。これは最小サイズで、電話やデスクトップ上の小サイズと普通サイズのタイルのどちらにも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-118">At a bare minimum, create a 200x200 pixel icon, which works for both small and medium tiles on phone and desktop.</span></span> <span data-ttu-id="a6ef6-119">最適なユーザー エクスペリエンスを実現するには、各サイズのアイコンを作成します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-119">To provide the best user experience, create an icon for each size.</span></span> <span data-ttu-id="a6ef6-120">これらのアセットにはパディングは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-120">No padding is needed on these assets.</span></span> <span data-ttu-id="a6ef6-121">サイズについて詳しくは、次の画像をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-121">See sizing details in the below image.</span></span>

<span data-ttu-id="a6ef6-122">透明度を設定し、PNG 形式でアイコン アセットを保存します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-122">Save icon assets in PNG format and with transparency.</span></span> <span data-ttu-id="a6ef6-123">Windows Phone では、透明でないピクセルは白色 (RGB 255, 255, 255) で表示されます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-123">On Windows Phone, every non-transparent pixel is displayed as white (RGB 255, 255, 255).</span></span> <span data-ttu-id="a6ef6-124">一貫性と簡素化を保つには、デスクトップのアイコンにも白色を使ってください。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-124">For consistency and simplicity, use white for desktop icons as well.</span></span>

<span data-ttu-id="a6ef6-125">タブレット、ノート PC、デスクトップの Windows 10 では、正方形のアイコン アセットのみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-125">Windows 10 on tablet, laptop, and desktop only supports square icon assets.</span></span> <span data-ttu-id="a6ef6-126">Windows Phone では、正方形のアセットと、電話アイコンなどの画像に便利な、高さが幅よりも大きいアセット (幅と高さの比率は最大 2:3) の両方がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-126">Phone supports both square assets and assets that are taller than they are wide, up to a 2:3 width:height ratio, which is useful for images such as a phone icon.</span></span>

![小サイズと普通サイズのタイルでのアイコンのサイズ (電話とデスクトップ)](images/iconic-template-sizing-info.png)

![バッジがあるアセットとバッジがないアセットのサイズ調整](images/assetguidance24.png)

<span data-ttu-id="a6ef6-129">正方形のアセットの場合、コンテナー内で自動的に中央に配置されます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-129">For square assets, automatic centering within the container occurs:</span></span>

![正方形のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance25.png)

<span data-ttu-id="a6ef6-131">正方形以外のアセットの場合、自動的に水平方向/垂直方向の中央に配置され、コンテナーの幅/高さに合わせてスナップされます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-131">For non-square assets, automatic horizontal/vertical centering and snapping to the width/height of the container occurs:</span></span>

![正方形以外のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance26a.png)

![正方形以外のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance26b.png)

<span data-ttu-id="a6ef6-134">**手順 2:基本タイルを作成します。**</span><span class="sxs-lookup"><span data-stu-id="a6ef6-134">**Step 2: Create your base tile**</span></span>

<span data-ttu-id="a6ef6-135">アイコン テンプレートは、プライマリ タイルとセカンダリ タイルのどちらでも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-135">You can use the iconic template on both primary and secondary tiles.</span></span> <span data-ttu-id="a6ef6-136">セカンダリ タイルで使う場合は、最初にセカンダリ タイルを作成するか、既にピン留めされているセカンダリ タイルを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-136">If you're using it on a secondary tile, you'll first have to create the secondary tile or use an already-pinned secondary tile.</span></span> <span data-ttu-id="a6ef6-137">プライマリ タイルは暗黙的にピン留めされるので、このタイルに対しては常に通知を送信することができます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-137">Primary tiles are implicitly pinned and can always be sent notifications.</span></span>

<span data-ttu-id="a6ef6-138">**手順 3:タイルに通知を送信します。**</span><span class="sxs-lookup"><span data-stu-id="a6ef6-138">**Step 3: Send a notification to your tile**</span></span>

<span data-ttu-id="a6ef6-139">この手順は、通知をローカルで送信するのか、サーバー プッシュを使って送信するのかによって異なります。ただし、送信する XML ペイロードは変わりません。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-139">Although this step can vary based on whether the notification is sent locally or via server push, the XML payload that you send remains the same.</span></span> <span data-ttu-id="a6ef6-140">ローカル タイル通知を送信するには、タイル (プライマリ タイルまたはセカンダリ タイル) に対して [**TileUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater) を作成してから、次に示すように、アイコン タイル テンプレートを使うタイルに通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-140">To send a local tile notification, create a [**TileUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater) for your tile (either primary or secondary tile), then send a notification to the tile that uses the iconic tile template as seen below.</span></span> <span data-ttu-id="a6ef6-141">また、[アダプティブ タイル テンプレート](create-adaptive-tiles.md)を使って、ワイド タイルや大きいタイルのバインドを含めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-141">Ideally, you should also include bindings for wide and large tile sizes using [adaptive tile templates](create-adaptive-tiles.md).</span></span>

<span data-ttu-id="a6ef6-142">XML ペイロードのサンプル コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-142">Here's sample code for the XML payload:</span></span>

```xml
<tile>
  <visual>

    <binding template="TileSquare150x150IconWithBadge">
      <image id="1" src="Iconic.png" alt="alt text"/>
    </binding>
    
    <binding template="TileSquare71x71IconWithBadge">
      <image id="1" src="Iconic.png" alt="alt text"/>
    </binding>

  </visual>
</tile>
```

<span data-ttu-id="a6ef6-143">このアイコン タイル テンプレートの XML ペイロードでは、手順 1. で作成した画像を示す image 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-143">This iconic tile template XML payload uses an image element that points to the image that you created in Step 1.</span></span> <span data-ttu-id="a6ef6-144">これで、タイルのアイコンの横にバッジを表示する準備ができました。あとは、バッジ通知を送信するだけです。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-144">Now your tile is ready to display the badge next to your icon; all that's left is sending badge notifications.</span></span>

<span data-ttu-id="a6ef6-145">**手順 4:タイルにバッジ通知を送信します。**</span><span class="sxs-lookup"><span data-stu-id="a6ef6-145">**Step 4: Send a badge notification to your tile**</span></span>

<span data-ttu-id="a6ef6-146">手順 3. と同様に、この手順は、通知をローカルで送信するのか、サーバー プッシュを使って送信するのかによって異なります。ただし、送信する XML ペイロードは変わりません。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-146">As with step 3, this step can vary based on whether the notification is sent locally or via server push, yet the XML payload that you send remains the same.</span></span> <span data-ttu-id="a6ef6-147">ローカル バッジ通知を送信するには、タイル (プライマリ タイルまたはセカンダリ タイル) に対して [**BadgeUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.BadgeUpdater) を作成してから、目的の値を使ってバッジ通知を送信します (またはバッジをクリアします)。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-147">To send a local badge notification, create a [**BadgeUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.BadgeUpdater) for your tile (either primary or secondary tile), then send a badge notification with your desired value (or clear the badge).</span></span>

<span data-ttu-id="a6ef6-148">XML ペイロードのサンプル コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-148">Here's sample code for the XML payload:</span></span>

```xml
<badge value="2"/>
```

<span data-ttu-id="a6ef6-149">タイルのバッジは状況に応じて適切に更新されます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-149">The tile's badge will update accordingly.</span></span>

<span data-ttu-id="a6ef6-150">**手順 5:正規表現のまとめ**</span><span class="sxs-lookup"><span data-stu-id="a6ef6-150">**Step 5: Putting it all together**</span></span>

<span data-ttu-id="a6ef6-151">次の図は、さまざまな API やペイロードがアイコン タイル テンプレートの各要素とどのように関連しているかを示しています。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-151">The following image illustrates how the various APIs and payloads are associated with each aspect of the iconic tile template.</span></span> <span data-ttu-id="a6ef6-152">[タイル通知](https://msdn.microsoft.com/library/windows/apps/hh779724) (&lt;binding&gt; 要素が含まれています) を使って、アイコン テンプレートと画像アセットを指定します。[バッジ通知](https://msdn.microsoft.com/library/windows/apps/hh779719)では、数値を指定し、タイル プロパティによってタイルの表示名や色などを制御します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-152">A [tile notification](https://msdn.microsoft.com/library/windows/apps/hh779724) (which contains those &lt;binding&gt; elements) is used to specify the iconic template and the image asset; a [badge notification](https://msdn.microsoft.com/library/windows/apps/hh779719) specifies the numerical value; tile properties control your tile's display name, color, and more.</span></span>

![アイコン タイル テンプレートに関連付けられている API とペイロード](images/iconic-template-properties-info.png)

## <a name="photos-tile-template"></a><span data-ttu-id="a6ef6-154">フォト タイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="a6ef6-154">Photos tile template</span></span>


<span data-ttu-id="a6ef6-155">フォト タイル テンプレートを使うと、ライブ タイルに写真のスライドショーを表示できます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-155">The photos tile template lets you display a slideshow of photos on your live tile.</span></span> <span data-ttu-id="a6ef6-156">このテンプレートは、すべてのタイルのサイズ (小サイズのタイルを含む) でサポートされており、各サイズのタイルで同じ動作をします。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-156">The template is supported on all tile sizes, including small, and behaves the same on each tile size.</span></span> <span data-ttu-id="a6ef6-157">次の例は、フォト テンプレートを使った普通サイズのタイルが持つ 5 つのフレームを示しています。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-157">The below example shows five frames of a medium tile that uses the photos template.</span></span> <span data-ttu-id="a6ef6-158">テンプレートには、ズームやクロスフェード アニメーションが用意されており、選んだ写真に対して繰り返し適用し、無限にループすることができます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-158">The template has a zoom and cross-fade animation that cycles through selected photos and loops indefinitely.</span></span>

![フォト タイル テンプレートを使った画像のスライド ショー](images/photo-tile-template-image01.jpg)

### <a name="how-to-use-the-photos-template"></a><span data-ttu-id="a6ef6-160">フォト テンプレートを使う方法</span><span class="sxs-lookup"><span data-stu-id="a6ef6-160">How to use the photos template</span></span>

<span data-ttu-id="a6ef6-161">[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)がインストールされていれば、フォト テンプレートを簡単に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-161">Using the photos template is easy if you've installed the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/).</span></span> <span data-ttu-id="a6ef6-162">生の XML を使うこともできますが、このライブラリの利用を強くお勧めします。これにより、開発者は有効な XML や XML エスケープされたコンテンツの生成について考える必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-162">Although you can use raw XML, we highly recommend using the library so you don't have to worry about generating valid XML or XML-escaping content.</span></span>

<span data-ttu-id="a6ef6-163">Windows Phone では、スライド ショーで最大 9 枚の写真を表示できます。タブレット、ノート PC、デスクトップでは、最大で 12 枚の写真を表示できます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-163">Windows Phone displays up to 9 photos in a slideshow; tablet, laptop, and desktop display up to 12.</span></span>

<span data-ttu-id="a6ef6-164">タイル通知の送信について詳しくは、[通知の送信に関する記事](index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-164">For information about sending the tile notification, see the [Send notifications article](index.md).</span></span>


```xml
<!--
 
To use the Photos template...
 
 - On any adaptive tile binding (like TileMedium or TileWide)
   - Set the hint-presentation attribute to "photos"
   - Add up to 12 images as children of the binding.
    
-->
 
<tile>
  <visual>
     
    <binding template="TileMedium" hint-presentation="photos">
       
      <image src="Assets/1.jpg" />
      <image src="ms-appdata:///local/Images/2.jpg"/>
      <image src="http://msn.com/images/3.jpg"/>
       
      <!--TODO: Can have 12 images total-->
       
    </binding>
     
    <!--TODO: Add bindings for other tile sizes-->
     
  </visual>
</tile>
```

```csharp
/*
 
To use the Photos template...
 
 - On any TileBinding object
   - Set Content property to new instance of TileBindingContentPhotos
   - Add up to 12 images to Images property of TileBindingContentPhotos.
 
*/
 
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentPhotos()
            {
                Images =
                {
                    new TileBasicImage() { Source = "Assets/1.jpg" },
                    new TileBasicImage() { Source = "ms-appdata:///local/Images/2.jpg" },
                    new TileBasicImage() { Source = "http://msn.com/images/3.jpg" }
 
                    // TODO: Can have 12 images total
                }
            }
        }
 
        // TODO: Add other tile sizes
    }
};
```

## <a name="people-tile-template"></a><span data-ttu-id="a6ef6-165">People タイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="a6ef6-165">People tile template</span></span>


<span data-ttu-id="a6ef6-166">Windows 10 の People アプリでは、円の中に画像のコレクションを表示する特別なタイル テンプレートを使います。これらの円は、タイル上で垂直方向または水平方向にスライドされます。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-166">The People app in Windows 10 uses a special tile template that displays a collection of images in circles that slide around vertically or horizontally on the tile.</span></span> <span data-ttu-id="a6ef6-167">このタイル テンプレートは以来、使用可能な Windows 10 ビルド 10572 とすべてのユーザーが自分のアプリで使用へようこそ。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-167">This tile template has been available since Windows 10 Build 10572, and anyone is welcome to use it in their app.</span></span>

<span data-ttu-id="a6ef6-168">People タイル テンプレートは、次のサイズのタイルで動作します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-168">The People tile template works on tiles of these sizes:</span></span>

<span data-ttu-id="a6ef6-169">**普通サイズのタイル** (TileMedium)</span><span class="sxs-lookup"><span data-stu-id="a6ef6-169">**Medium tile** (TileMedium)</span></span>

![普通サイズの People タイル](images/people-tile-medium.png)

 

<span data-ttu-id="a6ef6-171">**ワイド タイル** (TileWide)</span><span class="sxs-lookup"><span data-stu-id="a6ef6-171">**Wide tile** (TileWide)</span></span>

![ワイド People タイル](images/people-tile-wide.png)

 

<span data-ttu-id="a6ef6-173">**大きいタイル (デスクトップのみ)** (TileLarge)</span><span class="sxs-lookup"><span data-stu-id="a6ef6-173">**Large tile (desktop only)** (TileLarge)</span></span>

![大きい People タイル](images/people-tile-large.png)

 

<span data-ttu-id="a6ef6-175">[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使っている場合、People タイル テンプレートを利用するために必要な操作は、*TileBinding* コンテンツ用に新しい *TileBindingContentPeople* オブジェクトを作成することだけです。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-175">If you're using the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/), all you have to do to make use of the People tile template is create a new *TileBindingContentPeople* object for your *TileBinding* content.</span></span> <span data-ttu-id="a6ef6-176">*TileBindingContentPeople* クラスには、画像を追加するための Images プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-176">The *TileBindingContentPeople* class has an Images property where you add your images.</span></span>

<span data-ttu-id="a6ef6-177">生の XML を使っている場合は、*hint-presentation* を "people" に設定し、画像を binding 要素の子として追加します。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-177">If you're using raw XML, set the *hint-presentation* to "people" and add your images as children of the binding element.</span></span>

<span data-ttu-id="a6ef6-178">次の C# コード サンプルは、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) を使っていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-178">The following C# code sample assumes that you're using the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/).</span></span>

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentPeople()
            {
                Images =
                {
                    new TileBasicImage() { Source = "Assets/ProfilePics/1.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/2.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/3.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/4.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/5.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/6.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/7.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/8.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/9.jpg" }
                }
            }
        }
    }
};
```

```xml
<tile>
  <visual>
 
    <binding template="TileMedium" hint-presentation="people">
      <image src="Assets/ProfilePics/1.jpg"/>
      <image src="Assets/ProfilePics/2.jpg"/>
      <image src="Assets/ProfilePics/3.jpg"/>
      <image src="Assets/ProfilePics/4.jpg"/>
      <image src="Assets/ProfilePics/5.jpg"/>
      <image src="Assets/ProfilePics/6.jpg"/>
      <image src="Assets/ProfilePics/7.jpg"/>
      <image src="Assets/ProfilePics/8.jpg"/>
      <image src="Assets/ProfilePics/9.jpg"/>
    </binding>
 
  </visual>
</tile>
```

<span data-ttu-id="a6ef6-179">最適なユーザー エクスペリエンスを実現するには、タイルの各サイズに対して、写真の数を次のように指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-179">For the best user experience, we recommend that you provide the following number of photos for each tile size:</span></span>

-   <span data-ttu-id="a6ef6-180">中規模のタイル:9 の写真</span><span class="sxs-lookup"><span data-stu-id="a6ef6-180">Medium tile: 9 photos</span></span>
-   <span data-ttu-id="a6ef6-181">ワイド タイル:15 の写真</span><span class="sxs-lookup"><span data-stu-id="a6ef6-181">Wide tile: 15 photos</span></span>
-   <span data-ttu-id="a6ef6-182">大きいタイル:20 の写真</span><span class="sxs-lookup"><span data-stu-id="a6ef6-182">Large tile: 20 photos</span></span>

<span data-ttu-id="a6ef6-183">このように写真の枚数を指定することで、空の円をいくつか使うことができます。これにより、タイルが表示中にビジー状態になりません。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-183">Having that number of photos allows for a few empty circles, which means that the tile won't be too visually busy.</span></span> <span data-ttu-id="a6ef6-184">写真の数を自由に調整して、最適な表示状態を確認してください。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-184">Feel free to tweak the number of photos to get the look that works best for you.</span></span>

<span data-ttu-id="a6ef6-185">通知を送信するには、「[通知配信方法の選択](choosing-a-notification-delivery-method.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a6ef6-185">To send the notification, see [Choose a notification delivery method](choosing-a-notification-delivery-method.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="a6ef6-186">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a6ef6-186">Related topics</span></span>


* [<span data-ttu-id="a6ef6-187">GitHub の完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="a6ef6-187">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-people-tile-template)
* [<span data-ttu-id="a6ef6-188">通知ライブラリ</span><span class="sxs-lookup"><span data-stu-id="a6ef6-188">Notifications library</span></span>](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)
* [<span data-ttu-id="a6ef6-189">タイル、バッジ、通知</span><span class="sxs-lookup"><span data-stu-id="a6ef6-189">Tiles, badges, and notifications</span></span>](index.md)
* [<span data-ttu-id="a6ef6-190">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="a6ef6-190">Create adaptive tiles</span></span>](create-adaptive-tiles.md)
* [<span data-ttu-id="a6ef6-191">タイルのコンテンツ スキーマ</span><span class="sxs-lookup"><span data-stu-id="a6ef6-191">Tile content schema</span></span>](../tiles-and-notifications/tile-schema.md)
 

 




