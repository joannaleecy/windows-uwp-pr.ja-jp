---
author: andrewleader
Description: Special tile templates are unique templates that are either animated, or just allow you to do things that aren't possible with adaptive tiles.
title: 特別なタイル テンプレート
ms.assetid: 1322C9BA-D5B2-45E2-B813-865884A467FF
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5e408509f4cebbc89587237c6e0dc67bc88b1558
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3928234"
---
# <a name="special-tile-templates"></a><span data-ttu-id="60cb6-103">特別なタイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="60cb6-103">Special tile templates</span></span>
 

<span data-ttu-id="60cb6-104">特別なタイル テンプレートは、アニメーション化や、アダプティブ タイルでは不可能な機能を実行できる独特なテンプレートです。</span><span class="sxs-lookup"><span data-stu-id="60cb6-104">Special tile templates are unique templates that are either animated, or just allow you to do things that aren't possible with adaptive tiles.</span></span> <span data-ttu-id="60cb6-105">特別なタイル テンプレートは、それぞれ Windows 10 用に特別に構築されたテンプレートです。ただし、アイコン タイル テンプレートは、特別に構築されたテンプレートではなく、従来の特別なテンプレートが Windows 10 向けに更新されたものです。</span><span class="sxs-lookup"><span data-stu-id="60cb6-105">Each special tile template was specifically built for Windows 10, except for the iconic tile template, a classic special template that has been updated for Windows 10.</span></span> <span data-ttu-id="60cb6-106">この記事では、3 つの特別なタイル テンプレートである、アイコン タイル テンプレート、フォト タイル テンプレート、および People タイル テンプレートについて取り上げています。</span><span class="sxs-lookup"><span data-stu-id="60cb6-106">This article covers three special tile templates: Iconic, Photos, and People.</span></span>

## <a name="iconic-tile-template"></a><span data-ttu-id="60cb6-107">アイコン タイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="60cb6-107">Iconic tile template</span></span>


<span data-ttu-id="60cb6-108">アイコン テンプレート ("IconWithBadge" テンプレートとも呼ばれます) を使うと、タイルの中央に小さい画像を表示できます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-108">The iconic template (also known as the "IconWithBadge" template) lets you display a small image in the center of the tile.</span></span> <span data-ttu-id="60cb6-109">Windows 10 では、電話とタブレット/デスクトップの両方でテンプレートがサポートされています </span><span class="sxs-lookup"><span data-stu-id="60cb6-109">Windows 10 supports the template on both phone and tablet/desktop.</span></span>

![小サイズと普通サイズのメール タイル](images/iconic-template-mail-2sizes.png)

### <a name="how-to-create-an-iconic-tile"></a><span data-ttu-id="60cb6-111">アイコン タイルを作成する方法</span><span class="sxs-lookup"><span data-stu-id="60cb6-111">How to create an iconic tile</span></span>

<span data-ttu-id="60cb6-112">次の手順では、Windows 10 のアイコン タイルを作成するために必要なすべての情報について説明します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-112">The following steps cover everything you need to know to create an iconic tile for Windows 10.</span></span> <span data-ttu-id="60cb6-113">大まかに言うと、まずアイコンの画像アセットを用意する必要があります。次に、アイコン テンプレートを使って通知をタイルに送信し、最後に、タイルに表示される番号を指定するバッジ通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-113">At a high level, you need your iconic image asset, then you send a notification to the tile using the iconic template, and finally you send a badge notification that provides the number to be displayed on the tile.</span></span>

![アイコン タイルの開発フロー](images/iconic-template-dev-flow.png)

**<span data-ttu-id="60cb6-115">手順 1: 画像アセットを PNG 形式で作成する</span><span class="sxs-lookup"><span data-stu-id="60cb6-115">Step 1: Create your image assets in PNG format</span></span>**

<span data-ttu-id="60cb6-116">タイルのアイコン アセットを作成し、他のアセットと共にプロジェクト リソースに配置します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-116">Create the icon assets for your tile and place those in your project resources with your other assets.</span></span> <span data-ttu-id="60cb6-117">200 x 200 ピクセル以上のアイコンを作成してください。これは最小サイズで、電話やデスクトップ上の小サイズと普通サイズのタイルのどちらにも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-117">At a bare minimum, create a 200x200 pixel icon, which works for both small and medium tiles on phone and desktop.</span></span> <span data-ttu-id="60cb6-118">最適なユーザー エクスペリエンスを実現するには、各サイズのアイコンを作成します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-118">To provide the best user experience, create an icon for each size.</span></span> <span data-ttu-id="60cb6-119">これらのアセットにはパディングは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="60cb6-119">No padding is needed on these assets.</span></span> <span data-ttu-id="60cb6-120">サイズについて詳しくは、次の画像をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="60cb6-120">See sizing details in the below image.</span></span>

<span data-ttu-id="60cb6-121">透明度を設定し、PNG 形式でアイコン アセットを保存します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-121">Save icon assets in PNG format and with transparency.</span></span> <span data-ttu-id="60cb6-122">Windows Phone では、透明でないピクセルは白色 (RGB 255, 255, 255) で表示されます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-122">On Windows Phone, every non-transparent pixel is displayed as white (RGB 255, 255, 255).</span></span> <span data-ttu-id="60cb6-123">一貫性と簡素化を保つには、デスクトップのアイコンにも白色を使ってください。</span><span class="sxs-lookup"><span data-stu-id="60cb6-123">For consistency and simplicity, use white for desktop icons as well.</span></span>

<span data-ttu-id="60cb6-124">タブレット、ノート PC、デスクトップの Windows 10 では、正方形のアイコン アセットのみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-124">Windows 10 on tablet, laptop, and desktop only supports square icon assets.</span></span> <span data-ttu-id="60cb6-125">Windows Phone では、正方形のアセットと、電話アイコンなどの画像に便利な、高さが幅よりも大きいアセット (幅と高さの比率は最大 2:3) の両方がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-125">Phone supports both square assets and assets that are taller than they are wide, up to a 2:3 width:height ratio, which is useful for images such as a phone icon.</span></span>

![小サイズと普通サイズのタイルでのアイコンのサイズ (電話とデスクトップ)](images/iconic-template-sizing-info.png)

![バッジがあるアセットとバッジがないアセットのサイズ調整](images/assetguidance24.png)

<span data-ttu-id="60cb6-128">正方形のアセットの場合、コンテナー内で自動的に中央に配置されます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-128">For square assets, automatic centering within the container occurs:</span></span>

![正方形のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance25.png)

<span data-ttu-id="60cb6-130">正方形以外のアセットの場合、自動的に水平方向/垂直方向の中央に配置され、コンテナーの幅/高さに合わせてスナップされます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-130">For non-square assets, automatic horizontal/vertical centering and snapping to the width/height of the container occurs:</span></span>

![正方形以外のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance26a.png)

![正方形以外のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance26b.png)

**<span data-ttu-id="60cb6-133">手順 2: ベース タイルを作成する</span><span class="sxs-lookup"><span data-stu-id="60cb6-133">Step 2: Create your base tile</span></span>**

<span data-ttu-id="60cb6-134">アイコン テンプレートは、プライマリ タイルとセカンダリ タイルのどちらでも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-134">You can use the iconic template on both primary and secondary tiles.</span></span> <span data-ttu-id="60cb6-135">セカンダリ タイルで使う場合は、最初にセカンダリ タイルを作成するか、既にピン留めされているセカンダリ タイルを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="60cb6-135">If you're using it on a secondary tile, you'll first have to create the secondary tile or use an already-pinned secondary tile.</span></span> <span data-ttu-id="60cb6-136">プライマリ タイルは暗黙的にピン留めされるので、このタイルに対しては常に通知を送信することができます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-136">Primary tiles are implicitly pinned and can always be sent notifications.</span></span>

**<span data-ttu-id="60cb6-137">手順 3: 通知をタイルに送信する</span><span class="sxs-lookup"><span data-stu-id="60cb6-137">Step 3: Send a notification to your tile</span></span>**

<span data-ttu-id="60cb6-138">この手順は、通知をローカルで送信するのか、サーバー プッシュを使って送信するのかによって異なります。ただし、送信する XML ペイロードは変わりません。</span><span class="sxs-lookup"><span data-stu-id="60cb6-138">Although this step can vary based on whether the notification is sent locally or via server push, the XML payload that you send remains the same.</span></span> <span data-ttu-id="60cb6-139">ローカル タイル通知を送信するには、タイル (プライマリ タイルまたはセカンダリ タイル) に対して [**TileUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater) を作成してから、次に示すように、アイコン タイル テンプレートを使うタイルに通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-139">To send a local tile notification, create a [**TileUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater) for your tile (either primary or secondary tile), then send a notification to the tile that uses the iconic tile template as seen below.</span></span> <span data-ttu-id="60cb6-140">また、[アダプティブ タイル テンプレート](create-adaptive-tiles.md)を使って、ワイド タイルや大きいタイルのバインドを含めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="60cb6-140">Ideally, you should also include bindings for wide and large tile sizes using [adaptive tile templates](create-adaptive-tiles.md).</span></span>

<span data-ttu-id="60cb6-141">XML ペイロードのサンプル コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-141">Here's sample code for the XML payload:</span></span>

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

<span data-ttu-id="60cb6-142">このアイコン タイル テンプレートの XML ペイロードでは、手順 1. で作成した画像を示す image 要素を使います。</span><span class="sxs-lookup"><span data-stu-id="60cb6-142">This iconic tile template XML payload uses an image element that points to the image that you created in Step 1.</span></span> <span data-ttu-id="60cb6-143">これで、タイルのアイコンの横にバッジを表示する準備ができました。あとは、バッジ通知を送信するだけです。</span><span class="sxs-lookup"><span data-stu-id="60cb6-143">Now your tile is ready to display the badge next to your icon; all that's left is sending badge notifications.</span></span>

**<span data-ttu-id="60cb6-144">手順 4: バッジ通知をタイルに送信する</span><span class="sxs-lookup"><span data-stu-id="60cb6-144">Step 4: Send a badge notification to your tile</span></span>**

<span data-ttu-id="60cb6-145">手順 3. と同様に、この手順は、通知をローカルで送信するのか、サーバー プッシュを使って送信するのかによって異なります。ただし、送信する XML ペイロードは変わりません。</span><span class="sxs-lookup"><span data-stu-id="60cb6-145">As with step 3, this step can vary based on whether the notification is sent locally or via server push, yet the XML payload that you send remains the same.</span></span> <span data-ttu-id="60cb6-146">ローカル バッジ通知を送信するには、タイル (プライマリ タイルまたはセカンダリ タイル) に対して [**BadgeUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.BadgeUpdater) を作成してから、目的の値を使ってバッジ通知を送信します (またはバッジをクリアします)。</span><span class="sxs-lookup"><span data-stu-id="60cb6-146">To send a local badge notification, create a [**BadgeUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.BadgeUpdater) for your tile (either primary or secondary tile), then send a badge notification with your desired value (or clear the badge).</span></span>

<span data-ttu-id="60cb6-147">XML ペイロードのサンプル コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-147">Here's sample code for the XML payload:</span></span>

```xml
<badge value="2"/>
```

<span data-ttu-id="60cb6-148">タイルのバッジは状況に応じて適切に更新されます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-148">The tile's badge will update accordingly.</span></span>

**<span data-ttu-id="60cb6-149">手順 5: 組み立てる</span><span class="sxs-lookup"><span data-stu-id="60cb6-149">Step 5: Putting it all together</span></span>**

<span data-ttu-id="60cb6-150">次の図は、さまざまな API やペイロードがアイコン タイル テンプレートの各要素とどのように関連しているかを示しています。</span><span class="sxs-lookup"><span data-stu-id="60cb6-150">The following image illustrates how the various APIs and payloads are associated with each aspect of the iconic tile template.</span></span> <span data-ttu-id="60cb6-151">[タイル通知](https://msdn.microsoft.com/library/windows/apps/hh779724) (&lt;binding&gt; 要素が含まれています) を使って、アイコン テンプレートと画像アセットを指定します。[バッジ通知](https://msdn.microsoft.com/library/windows/apps/hh779719)では、数値を指定し、タイル プロパティによってタイルの表示名や色などを制御します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-151">A [tile notification](https://msdn.microsoft.com/library/windows/apps/hh779724) (which contains those &lt;binding&gt; elements) is used to specify the iconic template and the image asset; a [badge notification](https://msdn.microsoft.com/library/windows/apps/hh779719) specifies the numerical value; tile properties control your tile's display name, color, and more.</span></span>

![アイコン タイル テンプレートに関連付けられている API とペイロード](images/iconic-template-properties-info.png)

## <a name="photos-tile-template"></a><span data-ttu-id="60cb6-153">フォト タイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="60cb6-153">Photos tile template</span></span>


<span data-ttu-id="60cb6-154">フォト タイル テンプレートを使うと、ライブ タイルに写真のスライドショーを表示できます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-154">The photos tile template lets you display a slideshow of photos on your live tile.</span></span> <span data-ttu-id="60cb6-155">このテンプレートは、すべてのタイルのサイズ (小サイズのタイルを含む) でサポートされており、各サイズのタイルで同じ動作をします。</span><span class="sxs-lookup"><span data-stu-id="60cb6-155">The template is supported on all tile sizes, including small, and behaves the same on each tile size.</span></span> <span data-ttu-id="60cb6-156">次の例は、フォト テンプレートを使った普通サイズのタイルが持つ 5 つのフレームを示しています。</span><span class="sxs-lookup"><span data-stu-id="60cb6-156">The below example shows five frames of a medium tile that uses the photos template.</span></span> <span data-ttu-id="60cb6-157">テンプレートには、ズームやクロスフェード アニメーションが用意されており、選んだ写真に対して繰り返し適用し、無限にループすることができます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-157">The template has a zoom and cross-fade animation that cycles through selected photos and loops indefinitely.</span></span>

![フォト タイル テンプレートを使った画像のスライド ショー](images/photo-tile-template-image01.jpg)

### <a name="how-to-use-the-photos-template"></a><span data-ttu-id="60cb6-159">フォト テンプレートを使う方法</span><span class="sxs-lookup"><span data-stu-id="60cb6-159">How to use the photos template</span></span>

<span data-ttu-id="60cb6-160">[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)がインストールされていれば、フォト テンプレートを簡単に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-160">Using the photos template is easy if you've installed the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/).</span></span> <span data-ttu-id="60cb6-161">生の XML を使うこともできますが、このライブラリの利用を強くお勧めします。これにより、開発者は有効な XML や XML エスケープされたコンテンツの生成について考える必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="60cb6-161">Although you can use raw XML, we highly recommend using the library so you don't have to worry about generating valid XML or XML-escaping content.</span></span>

<span data-ttu-id="60cb6-162">Windows Phone では、スライド ショーで最大 9 枚の写真を表示できます。タブレット、ノート PC、デスクトップでは、最大で 12 枚の写真を表示できます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-162">Windows Phone displays up to 9 photos in a slideshow; tablet, laptop, and desktop display up to 12.</span></span>

<span data-ttu-id="60cb6-163">タイル通知の送信について詳しくは、[通知の送信に関する記事](index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="60cb6-163">For information about sending the tile notification, see the [Send notifications article](index.md).</span></span>


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

## <a name="people-tile-template"></a><span data-ttu-id="60cb6-164">People タイル テンプレート</span><span class="sxs-lookup"><span data-stu-id="60cb6-164">People tile template</span></span>


<span data-ttu-id="60cb6-165">Windows 10 の People アプリでは、円の中に画像のコレクションを表示する特別なタイル テンプレートを使います。これらの円は、タイル上で垂直方向または水平方向にスライドされます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-165">The People app in Windows 10 uses a special tile template that displays a collection of images in circles that slide around vertically or horizontally on the tile.</span></span> <span data-ttu-id="60cb6-166">このタイル テンプレートは、Windows 10 ビルド 10572 以降で利用でき、すべてのユーザーがアプリで使うことができます。</span><span class="sxs-lookup"><span data-stu-id="60cb6-166">This tile template has been available since Windows 10 Build 10572, and anyone is welcome to use it in their app.</span></span>

<span data-ttu-id="60cb6-167">People タイル テンプレートは、次のサイズのタイルで動作します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-167">The People tile template works on tiles of these sizes:</span></span>

<span data-ttu-id="60cb6-168">**普通サイズのタイル** (TileMedium)</span><span class="sxs-lookup"><span data-stu-id="60cb6-168">**Medium tile** (TileMedium)</span></span>

![普通サイズの People タイル](images/people-tile-medium.png)

 

<span data-ttu-id="60cb6-170">**ワイド タイル** (TileWide)</span><span class="sxs-lookup"><span data-stu-id="60cb6-170">**Wide tile** (TileWide)</span></span>

![ワイド People タイル](images/people-tile-wide.png)

 

<span data-ttu-id="60cb6-172">**大きいタイル (デスクトップのみ)** (TileLarge)</span><span class="sxs-lookup"><span data-stu-id="60cb6-172">**Large tile (desktop only)** (TileLarge)</span></span>

![大きい People タイル](images/people-tile-large.png)

 

<span data-ttu-id="60cb6-174">[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使っている場合、People タイル テンプレートを利用するために必要な操作は、*TileBinding* コンテンツ用に新しい *TileBindingContentPeople* オブジェクトを作成することだけです。</span><span class="sxs-lookup"><span data-stu-id="60cb6-174">If you're using the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/), all you have to do to make use of the People tile template is create a new *TileBindingContentPeople* object for your *TileBinding* content.</span></span> <span data-ttu-id="60cb6-175">*TileBindingContentPeople* クラスには、画像を追加するための Images プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="60cb6-175">The *TileBindingContentPeople* class has an Images property where you add your images.</span></span>

<span data-ttu-id="60cb6-176">生の XML を使っている場合は、*hint-presentation* を "people" に設定し、画像を binding 要素の子として追加します。</span><span class="sxs-lookup"><span data-stu-id="60cb6-176">If you're using raw XML, set the *hint-presentation* to "people" and add your images as children of the binding element.</span></span>

<span data-ttu-id="60cb6-177">次の C# コード サンプルは、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) を使っていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="60cb6-177">The following C# code sample assumes that you're using the [Notifications library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/).</span></span>

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

<span data-ttu-id="60cb6-178">最適なユーザー エクスペリエンスを実現するには、タイルの各サイズに対して、写真の数を次のように指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="60cb6-178">For the best user experience, we recommend that you provide the following number of photos for each tile size:</span></span>

-   <span data-ttu-id="60cb6-179">普通サイズのタイル: 9 枚の写真</span><span class="sxs-lookup"><span data-stu-id="60cb6-179">Medium tile: 9 photos</span></span>
-   <span data-ttu-id="60cb6-180">ワイド タイル: 15 枚の写真</span><span class="sxs-lookup"><span data-stu-id="60cb6-180">Wide tile: 15 photos</span></span>
-   <span data-ttu-id="60cb6-181">大きいタイル: 20 枚の写真</span><span class="sxs-lookup"><span data-stu-id="60cb6-181">Large tile: 20 photos</span></span>

<span data-ttu-id="60cb6-182">このように写真の枚数を指定することで、空の円をいくつか使うことができます。これにより、タイルが表示中にビジー状態になりません。</span><span class="sxs-lookup"><span data-stu-id="60cb6-182">Having that number of photos allows for a few empty circles, which means that the tile won't be too visually busy.</span></span> <span data-ttu-id="60cb6-183">写真の数を自由に調整して、最適な表示状態を確認してください。</span><span class="sxs-lookup"><span data-stu-id="60cb6-183">Feel free to tweak the number of photos to get the look that works best for you.</span></span>

<span data-ttu-id="60cb6-184">通知を送信するには、「[通知配信方法の選択](choosing-a-notification-delivery-method.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="60cb6-184">To send the notification, see [Choose a notification delivery method](choosing-a-notification-delivery-method.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="60cb6-185">関連トピック</span><span class="sxs-lookup"><span data-stu-id="60cb6-185">Related topics</span></span>


* [<span data-ttu-id="60cb6-186">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="60cb6-186">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-people-tile-template)
* [<span data-ttu-id="60cb6-187">Notifications ライブラリ</span><span class="sxs-lookup"><span data-stu-id="60cb6-187">Notifications library</span></span>](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)
* [<span data-ttu-id="60cb6-188">タイル、バッジ、および通知</span><span class="sxs-lookup"><span data-stu-id="60cb6-188">Tiles, badges, and notifications</span></span>](index.md)
* [<span data-ttu-id="60cb6-189">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="60cb6-189">Create adaptive tiles</span></span>](create-adaptive-tiles.md)
* [<span data-ttu-id="60cb6-190">タイルのコンテンツのスキーマ</span><span class="sxs-lookup"><span data-stu-id="60cb6-190">Tile content schema</span></span>](../tiles-and-notifications/tile-schema.md)
 

 




