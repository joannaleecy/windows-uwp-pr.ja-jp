---
author: mijacobs
Description: This article lists and provides usage guidance for the glyphs that come with the Segoe MDL2 Assets font.
Search.Refinement.TopicID: 184
title: Segoe MDL2 アイコンのガイドライン
ms.assetid: DFB215C2-8A61-4957-B662-3B1991AC9BE1
label: Segoe MDL2 icons
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3480288035d98ab3f68da33f9121e7daaf86180f
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4148427"
---
# <a name="segoe-mdl2-icons"></a><span data-ttu-id="028e6-103">Segoe MDL2 アイコン</span><span class="sxs-lookup"><span data-stu-id="028e6-103">Segoe MDL2 icons</span></span>

 

<span data-ttu-id="028e6-104">この記事では、Segoe MDL2 アセット フォントによって提供されるアイコンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="028e6-104">This article lists the icons provided by the Segoe MDL2 Assets font.</span></span> 

> <span data-ttu-id="028e6-105">**重要な API**: [**Symbol 列挙値**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol), [**FontIcon クラス**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon)</span><span class="sxs-lookup"><span data-stu-id="028e6-105">**Important APIs**: [**Symbol enum**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol), [**FontIcon class**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon)</span></span>

## <a name="about-segoe-mdl2-assets"></a><span data-ttu-id="028e6-106">Segoe MDL2 アセットについて</span><span class="sxs-lookup"><span data-stu-id="028e6-106">About Segoe MDL2 Assets</span></span>

<span data-ttu-id="028e6-107">Windows 10 のリリースにより、従来の Windows 8/8.1 Segoe UI Symbol アイコン フォントが、Segoe MDL2 アセット フォントに置き換えられました。</span><span class="sxs-lookup"><span data-stu-id="028e6-107">With the release of Windows 10, the Segoe MDL2 Assets font replaced the Windows 8/8.1 Segoe UI Symbol icon font.</span></span> <!-- It can be used in much the same manner as the older font, but many glyphs have been redrawn in the Windows 10 icon style with the font’s metrics set so that icons are aligned within the font’s em-square instead of on a typographic baseline. --> <span data-ttu-id="028e6-108">(**Segoe UI Symbol** も「レガシ」リソースとして利用できますが、アプリを更新して新しい **Segoe MDL2 アセット**を使用することをお勧めします。)</span><span class="sxs-lookup"><span data-stu-id="028e6-108">(**Segoe UI Symbol** will still be available as a "legacy" resource, but we recommend updating your app to use the new **Segoe MDL2 Assets**.)</span></span>

<span data-ttu-id="028e6-109">**Segoe MDL2 アセット** フォントに含まれるアイコンや UI コントロールのほとんどは、Unicode の私用領域 (PUA) にマップされます。</span><span class="sxs-lookup"><span data-stu-id="028e6-109">Most of the icons and UI controls included in the **Segoe MDL2 Assets** font are mapped to the Private Use Area of Unicode (PUA).</span></span> <span data-ttu-id="028e6-110">フォント開発者は PUA を使って、既にあるコード ポイントにマップされないグリフにプライベート Unicode 値を割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="028e6-110">The PUA allows font developers to assign private Unicode values to glyphs that don’t map to existing code points.</span></span> <span data-ttu-id="028e6-111">これは、記号フォントを作成するときに役立ちますが、相互運用性の問題が生じます。</span><span class="sxs-lookup"><span data-stu-id="028e6-111">This is useful when creating a symbol font, but it creates an interoperability problem.</span></span> <span data-ttu-id="028e6-112">フォントが利用できない場合、グリフは表示されません。</span><span class="sxs-lookup"><span data-stu-id="028e6-112">If the font is not available, the glyphs won’t show up.</span></span> <span data-ttu-id="028e6-113">これらのグリフは、**Segoe MDL2 アセット** フォントを明示的に指定できる場合にのみ使います。</span><span class="sxs-lookup"><span data-stu-id="028e6-113">Only use these glyphs when you can specify the **Segoe MDL2 Assets** font.</span></span>

<span data-ttu-id="028e6-114">これらのグリフは、**Segoe MDL2 アセット** フォントを明示的に指定できる場合にのみ使います。</span><span class="sxs-lookup"><span data-stu-id="028e6-114">Use these glyphs only when you can explicitly specify the **Segoe MDL2 Assets** font.</span></span> <span data-ttu-id="028e6-115">タイルを使っている場合は、タイルのフォントを指定できず、フォントのフォールバックで PUA グリフを使うことができないため、これらのグリフは使うことができません。</span><span class="sxs-lookup"><span data-stu-id="028e6-115">If you are working with tiles, you can't use these glyphs because you can't specify the tile font and PUA glyphs are not available via font-fallback.</span></span>

<span data-ttu-id="028e6-116">**Segoe UI Symbol** と異なり、**Segoe MDL2 アセット** フォントのアイコンは、テキストとインラインで使用することは意図されていません。</span><span class="sxs-lookup"><span data-stu-id="028e6-116">Unlike with **Segoe UI Symbol**, the icons in the **Segoe MDL2 Assets** font are not intended for use in-line with text.</span></span> <span data-ttu-id="028e6-117">これは、段階的表示の矢印のような一部の古い方法は利用できなくなったことを意味します。</span><span class="sxs-lookup"><span data-stu-id="028e6-117">This means that some older "tricks" like the progressive disclosure arrows no longer apply.</span></span> <span data-ttu-id="028e6-118">さらに、新しいアイコンはすべて同じ場所に同じ大きさで表示されるため、幅を 0 にして作成する必要はありません。一組で機能することが確認済みです。</span><span class="sxs-lookup"><span data-stu-id="028e6-118">Likewise, since all of the new icons are sized and positioned the same, they do not have to be made with zero width; we have just made sure they work as a set.</span></span> <span data-ttu-id="028e6-119">一組として設計された 2 つのアイコンは、ぴったり重ねることができ、正しい位置に収まることが理想的です。</span><span class="sxs-lookup"><span data-stu-id="028e6-119">Ideally, you can overlay two icons that were designed as a set and they will fall into place.</span></span> <span data-ttu-id="028e6-120">これにより、コード内の色付けが可能になります。</span><span class="sxs-lookup"><span data-stu-id="028e6-120">We may do this to allow colorization in the code.</span></span> <span data-ttu-id="028e6-121">たとえば、スタート タイルのバッチ ステータス用に、U+EA3A と U+EA3B が作成されました。</span><span class="sxs-lookup"><span data-stu-id="028e6-121">For example, U+EA3A and U+EA3B were created for the Start tile Badge status.</span></span> <span data-ttu-id="028e6-122">これらは既に中央揃えされているため、ステータスが変わった場合に円を色で塗りつぶすことができます。</span><span class="sxs-lookup"><span data-stu-id="028e6-122">Because these are already centered the circle fill can be colored for different states.</span></span>

## <a name="layering-and-mirroring"></a><span data-ttu-id="028e6-123">重ね合わせとミラーリング</span><span class="sxs-lookup"><span data-stu-id="028e6-123">Layering and mirroring</span></span>

<span data-ttu-id="028e6-124">**Segoe MDL2 アセット**のグリフにはすべて、一貫した高さと、左を原点とした同一の固定幅が設定されているため、重ね合わせや色付けの効果はグリフどうしを直接重ねて描画することで表現できます。</span><span class="sxs-lookup"><span data-stu-id="028e6-124">All glyphs in **Segoe MDL2 Assets** have the same fixed width with a consistent height and left origin point, so layering and colorization effects can be achieved by drawing glyphs directly on top of each other.</span></span> <span data-ttu-id="028e6-125">この例では、幅が 0 の赤いハートに重ねて、黒の輪郭が描画されています。</span><span class="sxs-lookup"><span data-stu-id="028e6-125">This example show a black outline drawn on top of the zero-width red heart.</span></span>

![幅が 0 のグリフの使用](images/segoe-ui-symbol-layering.png)

<span data-ttu-id="028e6-127">また、アイコンの多くは、アラビア語、ペルシア語、ヘブライ語などの右から左に書く文字を使う言語でも利用できるように、左右が反転した形式も作成されています。</span><span class="sxs-lookup"><span data-stu-id="028e6-127">Many of the icons also have mirrored forms available for use in languages that use right-to-left text directionality such as Arabic, Farsi, and Hebrew.</span></span>

## <a name="using-the-icons"></a><span data-ttu-id="028e6-128">アイコンの使用</span><span class="sxs-lookup"><span data-stu-id="028e6-128">Using the icons</span></span>
<span data-ttu-id="028e6-129">C# #/vb/c + + と XAML のアプリを開発している場合は、 [Symbol 列挙値](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol)で指定されたグリフを Segoe MDL2 アセットを使用できます。</span><span class="sxs-lookup"><span data-stu-id="028e6-129">If you are developing an app in C#/VB/C++ and XAML, you can use specified glyphs from Segoe MDL2 Assets with the [Symbol enumeration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol).</span></span> 

```xaml
<SymbolIcon Symbol="GlobalNavigationButton"/>
```

<span data-ttu-id="028e6-130">Symbol 列挙値に含まれていない **Segoe MDL2 アセット** フォントのグリフを使用する場合は、[**FontIcon**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon) を使用します。</span><span class="sxs-lookup"><span data-stu-id="028e6-130">If you would like to use a glyph from the **Segoe MDL2 Assets** font that is not included in the Symbol enum, then use a [**FontIcon**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon).</span></span>

```xaml
<FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xE700;"/>
```

## <a name="how-do-i-get-this-font"></a><span data-ttu-id="028e6-131">このフォントの入手方法</span><span class="sxs-lookup"><span data-stu-id="028e6-131">How do I get this font?</span></span>
* <span data-ttu-id="028e6-132">Windows 10: を行うには必要ありませんが、フォントが Windows に付属します。</span><span class="sxs-lookup"><span data-stu-id="028e6-132">On Windows 10: There's nothing you need to do, the font comes with Windows.</span></span>
* <span data-ttu-id="028e6-133">Mac では、ダウンロードとフォントをインストールする必要があります: <a href="https://aka.ms/SegoeFonts">Segoe UI と MDL2 アイコン フォントを取得します。</a></span><span class="sxs-lookup"><span data-stu-id="028e6-133">On a Mac, you need to download and install the font: <a href="https://aka.ms/SegoeFonts">Get the Segoe UI and MDL2 icon fonts</a></span></span>

## <a name="icon-list"></a><span data-ttu-id="028e6-134">アイコン一覧</span><span class="sxs-lookup"><span data-stu-id="028e6-134">Icon list</span></span>
<span data-ttu-id="028e6-135">**Segoe MDL2 アセット** フォントには、以下に示すアイコンもあります。</span><span class="sxs-lookup"><span data-stu-id="028e6-135">Please keep in mind that the **Segoe MDL2 Assets** font includes many more icons than we can show here.</span></span> <span data-ttu-id="028e6-136">ここで紹介するアイコンの多くは、特殊な目的のために使用されるもので、それ以外の場合は通常使用しません。</span><span class="sxs-lookup"><span data-stu-id="028e6-136">Many of the icons are intended for specialized purposed and are not typically used anywhere else.</span></span>


<table style="background-color: white; color: black">

 <tr>
  <td><span data-ttu-id="028e6-137">記号</span><span class="sxs-lookup"><span data-stu-id="028e6-137">Symbol</span></span></td>
  <td><span data-ttu-id="028e6-138">Unicode ポイント</span><span class="sxs-lookup"><span data-stu-id="028e6-138">Unicode point</span></span></td>
  <td><span data-ttu-id="028e6-139">説明</span><span class="sxs-lookup"><span data-stu-id="028e6-139">Description</span></span></td>
 </tr>
 <tr><td><img src="images/segoe-mdl/E700.png" width="32" height="32" alt="GlobalNavigationButton" /></td>
  <td><span data-ttu-id="028e6-140">E700</span><span class="sxs-lookup"><span data-stu-id="028e6-140">E700</span></span></td>
  <td><span data-ttu-id="028e6-141">GlobalNavigationButton</span><span class="sxs-lookup"><span data-stu-id="028e6-141">GlobalNavigationButton</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E701.png" width="32" height="32" alt="Wifi" /></td>
  <td><span data-ttu-id="028e6-142">E701</span><span class="sxs-lookup"><span data-stu-id="028e6-142">E701</span></span></td>
  <td><span data-ttu-id="028e6-143">Wifi</span><span class="sxs-lookup"><span data-stu-id="028e6-143">Wifi</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E702.png" width="32" height="32" alt="Bluetooth" /></td>
  <td><span data-ttu-id="028e6-144">E702</span><span class="sxs-lookup"><span data-stu-id="028e6-144">E702</span></span></td>
  <td><span data-ttu-id="028e6-145">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="028e6-145">Bluetooth</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E703.png" width="32" height="32" alt="Connect" /></td>
  <td><span data-ttu-id="028e6-146">E703</span><span class="sxs-lookup"><span data-stu-id="028e6-146">E703</span></span></td>
  <td><span data-ttu-id="028e6-147">Connect</span><span class="sxs-lookup"><span data-stu-id="028e6-147">Connect</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E704.png" width="32" height="32" alt="InternetSharing" /></td>
  <td><span data-ttu-id="028e6-148">E704</span><span class="sxs-lookup"><span data-stu-id="028e6-148">E704</span></span></td>
  <td><span data-ttu-id="028e6-149">InternetSharing</span><span class="sxs-lookup"><span data-stu-id="028e6-149">InternetSharing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E705.png" width="32" height="32" alt="VPN" /></td>
  <td><span data-ttu-id="028e6-150">E705</span><span class="sxs-lookup"><span data-stu-id="028e6-150">E705</span></span></td>
  <td><span data-ttu-id="028e6-151">VPN</span><span class="sxs-lookup"><span data-stu-id="028e6-151">VPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E706.png" width="32" height="32" alt="Brightness" /></td>
  <td><span data-ttu-id="028e6-152">E706</span><span class="sxs-lookup"><span data-stu-id="028e6-152">E706</span></span></td>
  <td><span data-ttu-id="028e6-153">Brightness</span><span class="sxs-lookup"><span data-stu-id="028e6-153">Brightness</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E707.png" width="32" height="32" alt="MapPin" /></td>
  <td><span data-ttu-id="028e6-154">E707</span><span class="sxs-lookup"><span data-stu-id="028e6-154">E707</span></span></td>
  <td><span data-ttu-id="028e6-155">MapPin</span><span class="sxs-lookup"><span data-stu-id="028e6-155">MapPin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E708.png" width="32" height="32" alt="QuietHours" /></td>
  <td><span data-ttu-id="028e6-156">E708</span><span class="sxs-lookup"><span data-stu-id="028e6-156">E708</span></span></td>
  <td><span data-ttu-id="028e6-157">QuietHours</span><span class="sxs-lookup"><span data-stu-id="028e6-157">QuietHours</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E709.png" width="32" height="32" alt="Airplane" /></td>
  <td><span data-ttu-id="028e6-158">E709</span><span class="sxs-lookup"><span data-stu-id="028e6-158">E709</span></span></td>
  <td><span data-ttu-id="028e6-159">Airplane</span><span class="sxs-lookup"><span data-stu-id="028e6-159">Airplane</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70A.png" width="32" height="32" alt="Tablet" /></td>
  <td><span data-ttu-id="028e6-160">E70A</span><span class="sxs-lookup"><span data-stu-id="028e6-160">E70A</span></span></td>
  <td><span data-ttu-id="028e6-161">Tablet</span><span class="sxs-lookup"><span data-stu-id="028e6-161">Tablet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70B.png" width="32" height="32" alt="QuickNote" /></td>
  <td><span data-ttu-id="028e6-162">E70B</span><span class="sxs-lookup"><span data-stu-id="028e6-162">E70B</span></span></td>
  <td><span data-ttu-id="028e6-163">QuickNote</span><span class="sxs-lookup"><span data-stu-id="028e6-163">QuickNote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70C.png" width="32" height="32" alt="RememberedDevice" /></td>
  <td><span data-ttu-id="028e6-164">E70C</span><span class="sxs-lookup"><span data-stu-id="028e6-164">E70C</span></span></td>
  <td><span data-ttu-id="028e6-165">RememberedDevice</span><span class="sxs-lookup"><span data-stu-id="028e6-165">RememberedDevice</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70D.png" width="32" height="32" alt="ChevronDown" /></td>
  <td><span data-ttu-id="028e6-166">E70D</span><span class="sxs-lookup"><span data-stu-id="028e6-166">E70D</span></span></td>
  <td><span data-ttu-id="028e6-167">ChevronDown</span><span class="sxs-lookup"><span data-stu-id="028e6-167">ChevronDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70E.png" width="32" height="32" alt="ChevronUp" /></td>
  <td><span data-ttu-id="028e6-168">E70E</span><span class="sxs-lookup"><span data-stu-id="028e6-168">E70E</span></span></td>
  <td><span data-ttu-id="028e6-169">ChevronUp</span><span class="sxs-lookup"><span data-stu-id="028e6-169">ChevronUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70F.png" width="32" height="32" alt="Edit" /></td>
  <td><span data-ttu-id="028e6-170">E70F</span><span class="sxs-lookup"><span data-stu-id="028e6-170">E70F</span></span></td>
  <td><span data-ttu-id="028e6-171">Edit</span><span class="sxs-lookup"><span data-stu-id="028e6-171">Edit</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E710.png" width="32" height="32" alt="Add" /></td>
  <td><span data-ttu-id="028e6-172">E710</span><span class="sxs-lookup"><span data-stu-id="028e6-172">E710</span></span></td>
  <td><span data-ttu-id="028e6-173">Add</span><span class="sxs-lookup"><span data-stu-id="028e6-173">Add</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E711.png" width="32" height="32" alt="Cancel" /></td>
  <td><span data-ttu-id="028e6-174">E711</span><span class="sxs-lookup"><span data-stu-id="028e6-174">E711</span></span></td>
  <td><span data-ttu-id="028e6-175">Cancel</span><span class="sxs-lookup"><span data-stu-id="028e6-175">Cancel</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E712.png" width="32" height="32" alt="More" /></td>
  <td><span data-ttu-id="028e6-176">E712</span><span class="sxs-lookup"><span data-stu-id="028e6-176">E712</span></span></td>
  <td><span data-ttu-id="028e6-177">More</span><span class="sxs-lookup"><span data-stu-id="028e6-177">More</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E713.png" width="32" height="32" alt="Settings" /></td>
  <td><span data-ttu-id="028e6-178">E713</span><span class="sxs-lookup"><span data-stu-id="028e6-178">E713</span></span></td>
  <td><span data-ttu-id="028e6-179">Settings</span><span class="sxs-lookup"><span data-stu-id="028e6-179">Settings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E714.png" width="32" height="32" alt="Video" /></td>
  <td><span data-ttu-id="028e6-180">E714</span><span class="sxs-lookup"><span data-stu-id="028e6-180">E714</span></span></td>
  <td><span data-ttu-id="028e6-181">Video</span><span class="sxs-lookup"><span data-stu-id="028e6-181">Video</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E715.png" width="32" height="32" alt="Mail" /></td>
  <td><span data-ttu-id="028e6-182">E715</span><span class="sxs-lookup"><span data-stu-id="028e6-182">E715</span></span></td>
  <td><span data-ttu-id="028e6-183">Mail</span><span class="sxs-lookup"><span data-stu-id="028e6-183">Mail</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E716.png" width="32" height="32" alt="People" /></td>
  <td><span data-ttu-id="028e6-184">E716</span><span class="sxs-lookup"><span data-stu-id="028e6-184">E716</span></span></td>
  <td><span data-ttu-id="028e6-185">People</span><span class="sxs-lookup"><span data-stu-id="028e6-185">People</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E717.png" width="32" height="32" alt="Phone" /></td>
  <td><span data-ttu-id="028e6-186">E717</span><span class="sxs-lookup"><span data-stu-id="028e6-186">E717</span></span></td>
  <td><span data-ttu-id="028e6-187">Phone</span><span class="sxs-lookup"><span data-stu-id="028e6-187">Phone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E718.png" width="32" height="32" alt="Pin" /></td>
  <td><span data-ttu-id="028e6-188">E718</span><span class="sxs-lookup"><span data-stu-id="028e6-188">E718</span></span></td>
  <td><span data-ttu-id="028e6-189">Pin</span><span class="sxs-lookup"><span data-stu-id="028e6-189">Pin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E719.png" width="32" height="32" alt="Shop" /></td>
  <td><span data-ttu-id="028e6-190">E719</span><span class="sxs-lookup"><span data-stu-id="028e6-190">E719</span></span></td>
  <td><span data-ttu-id="028e6-191">Shop</span><span class="sxs-lookup"><span data-stu-id="028e6-191">Shop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71A.png" width="32" height="32" alt="Stop" /></td>
  <td><span data-ttu-id="028e6-192">E71A</span><span class="sxs-lookup"><span data-stu-id="028e6-192">E71A</span></span></td>
  <td><span data-ttu-id="028e6-193">Stop</span><span class="sxs-lookup"><span data-stu-id="028e6-193">Stop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71B.png" width="32" height="32" alt="Link" /></td>
  <td><span data-ttu-id="028e6-194">E71B</span><span class="sxs-lookup"><span data-stu-id="028e6-194">E71B</span></span></td>
  <td><span data-ttu-id="028e6-195">Link</span><span class="sxs-lookup"><span data-stu-id="028e6-195">Link</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71C.png" width="32" height="32" alt="Filter" /></td>
  <td><span data-ttu-id="028e6-196">E71C</span><span class="sxs-lookup"><span data-stu-id="028e6-196">E71C</span></span></td>
  <td><span data-ttu-id="028e6-197">Filter</span><span class="sxs-lookup"><span data-stu-id="028e6-197">Filter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71D.png" width="32" height="32" alt="AllApps" /></td>
  <td><span data-ttu-id="028e6-198">E71D</span><span class="sxs-lookup"><span data-stu-id="028e6-198">E71D</span></span></td>
  <td><span data-ttu-id="028e6-199">AllApps</span><span class="sxs-lookup"><span data-stu-id="028e6-199">AllApps</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71E.png" width="32" height="32" alt="Zoom" /></td>
  <td><span data-ttu-id="028e6-200">E71E</span><span class="sxs-lookup"><span data-stu-id="028e6-200">E71E</span></span></td>
  <td><span data-ttu-id="028e6-201">Zoom</span><span class="sxs-lookup"><span data-stu-id="028e6-201">Zoom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71F.png" width="32" height="32" alt="ZoomOut" /></td>
  <td><span data-ttu-id="028e6-202">E71F</span><span class="sxs-lookup"><span data-stu-id="028e6-202">E71F</span></span></td>
  <td><span data-ttu-id="028e6-203">ZoomOut</span><span class="sxs-lookup"><span data-stu-id="028e6-203">ZoomOut</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E720.png" width="32" height="32" alt="Microphone" /></td>
  <td><span data-ttu-id="028e6-204">E720</span><span class="sxs-lookup"><span data-stu-id="028e6-204">E720</span></span></td>
  <td><span data-ttu-id="028e6-205">Microphone</span><span class="sxs-lookup"><span data-stu-id="028e6-205">Microphone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E721.png" width="32" height="32" alt="Search" /></td>
  <td><span data-ttu-id="028e6-206">E721</span><span class="sxs-lookup"><span data-stu-id="028e6-206">E721</span></span></td>
  <td><span data-ttu-id="028e6-207">Search</span><span class="sxs-lookup"><span data-stu-id="028e6-207">Search</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E722.png" width="32" height="32" alt="Camera" /></td>
  <td><span data-ttu-id="028e6-208">E722</span><span class="sxs-lookup"><span data-stu-id="028e6-208">E722</span></span></td>
  <td><span data-ttu-id="028e6-209">Camera</span><span class="sxs-lookup"><span data-stu-id="028e6-209">Camera</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E723.png" width="32" height="32" alt="Attach" /></td>
  <td><span data-ttu-id="028e6-210">E723</span><span class="sxs-lookup"><span data-stu-id="028e6-210">E723</span></span></td>
  <td><span data-ttu-id="028e6-211">Attach</span><span class="sxs-lookup"><span data-stu-id="028e6-211">Attach</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E724.png" width="32" height="32" alt="Send" /></td>
  <td><span data-ttu-id="028e6-212">E724</span><span class="sxs-lookup"><span data-stu-id="028e6-212">E724</span></span></td>
  <td><span data-ttu-id="028e6-213">Send</span><span class="sxs-lookup"><span data-stu-id="028e6-213">Send</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E725.png" width="32" height="32" alt="SendFill" /></td>
  <td><span data-ttu-id="028e6-214">E725</span><span class="sxs-lookup"><span data-stu-id="028e6-214">E725</span></span></td>
  <td><span data-ttu-id="028e6-215">SendFill</span><span class="sxs-lookup"><span data-stu-id="028e6-215">SendFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E726.png" width="32" height="32" alt="WalkSolid" /></td>
  <td><span data-ttu-id="028e6-216">E726</span><span class="sxs-lookup"><span data-stu-id="028e6-216">E726</span></span></td>
  <td><span data-ttu-id="028e6-217">WalkSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-217">WalkSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E727.png" width="32" height="32" alt="InPrivate" /></td>
  <td><span data-ttu-id="028e6-218">E727</span><span class="sxs-lookup"><span data-stu-id="028e6-218">E727</span></span></td>
  <td><span data-ttu-id="028e6-219">InPrivate</span><span class="sxs-lookup"><span data-stu-id="028e6-219">InPrivate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E728.png" width="32" height="32" alt="FavoriteList" /></td>
  <td><span data-ttu-id="028e6-220">E728</span><span class="sxs-lookup"><span data-stu-id="028e6-220">E728</span></span></td>
  <td><span data-ttu-id="028e6-221">FavoriteList</span><span class="sxs-lookup"><span data-stu-id="028e6-221">FavoriteList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E729.png" width="32" height="32" alt="PageSolid" /></td>
  <td><span data-ttu-id="028e6-222">E729</span><span class="sxs-lookup"><span data-stu-id="028e6-222">E729</span></span></td>
  <td><span data-ttu-id="028e6-223">PageSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-223">PageSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72A.png" width="32" height="32" alt="Forward" /></td>
  <td><span data-ttu-id="028e6-224">E72A</span><span class="sxs-lookup"><span data-stu-id="028e6-224">E72A</span></span></td>
  <td><span data-ttu-id="028e6-225">Forward</span><span class="sxs-lookup"><span data-stu-id="028e6-225">Forward</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72B.png" width="32" height="32" alt="Back" /></td>
  <td><span data-ttu-id="028e6-226">E72B</span><span class="sxs-lookup"><span data-stu-id="028e6-226">E72B</span></span></td>
  <td><span data-ttu-id="028e6-227">Back</span><span class="sxs-lookup"><span data-stu-id="028e6-227">Back</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72C.png" width="32" height="32" alt="Refresh" /></td>
  <td><span data-ttu-id="028e6-228">E72C</span><span class="sxs-lookup"><span data-stu-id="028e6-228">E72C</span></span></td>
  <td><span data-ttu-id="028e6-229">Refresh</span><span class="sxs-lookup"><span data-stu-id="028e6-229">Refresh</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72D.png" width="32" height="32" alt="Share" /></td>
  <td><span data-ttu-id="028e6-230">E72D</span><span class="sxs-lookup"><span data-stu-id="028e6-230">E72D</span></span></td>
  <td><span data-ttu-id="028e6-231">Share</span><span class="sxs-lookup"><span data-stu-id="028e6-231">Share</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72E.png" width="32" height="32" alt="Lock" /></td>
  <td><span data-ttu-id="028e6-232">E72E</span><span class="sxs-lookup"><span data-stu-id="028e6-232">E72E</span></span></td>
  <td><span data-ttu-id="028e6-233">Lock</span><span class="sxs-lookup"><span data-stu-id="028e6-233">Lock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E730.png" width="32" height="32" alt="ReportHacked" /></td>
  <td><span data-ttu-id="028e6-234">E730</span><span class="sxs-lookup"><span data-stu-id="028e6-234">E730</span></span></td>
  <td><span data-ttu-id="028e6-235">ReportHacked</span><span class="sxs-lookup"><span data-stu-id="028e6-235">ReportHacked</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E731.png" width="32" height="32" alt="EMI" /></td>
  <td><span data-ttu-id="028e6-236">E731</span><span class="sxs-lookup"><span data-stu-id="028e6-236">E731</span></span></td>
  <td><span data-ttu-id="028e6-237">EMI</span><span class="sxs-lookup"><span data-stu-id="028e6-237">EMI</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E734.png" width="32" height="32" alt="FavoriteStar" /></td>
  <td><span data-ttu-id="028e6-238">E734</span><span class="sxs-lookup"><span data-stu-id="028e6-238">E734</span></span></td>
  <td><span data-ttu-id="028e6-239">FavoriteStar</span><span class="sxs-lookup"><span data-stu-id="028e6-239">FavoriteStar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E735.png" width="32" height="32" alt="FavoriteStarFill" /></td>
  <td><span data-ttu-id="028e6-240">E735</span><span class="sxs-lookup"><span data-stu-id="028e6-240">E735</span></span></td>
  <td><span data-ttu-id="028e6-241">FavoriteStarFill</span><span class="sxs-lookup"><span data-stu-id="028e6-241">FavoriteStarFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E737.png" width="32" height="32" alt="Favicon" /></td>
  <td><span data-ttu-id="028e6-242">E737</span><span class="sxs-lookup"><span data-stu-id="028e6-242">E737</span></span></td>
  <td><span data-ttu-id="028e6-243">お気に入りアイコン</span><span class="sxs-lookup"><span data-stu-id="028e6-243">Favicon</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E738.png" width="32" height="32" alt="Remove" /></td>
  <td><span data-ttu-id="028e6-244">E738</span><span class="sxs-lookup"><span data-stu-id="028e6-244">E738</span></span></td>
  <td><span data-ttu-id="028e6-245">Remove</span><span class="sxs-lookup"><span data-stu-id="028e6-245">Remove</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E739.png" width="32" height="32" alt="Checkbox" /></td>
  <td><span data-ttu-id="028e6-246">E739</span><span class="sxs-lookup"><span data-stu-id="028e6-246">E739</span></span></td>
  <td><span data-ttu-id="028e6-247">Checkbox</span><span class="sxs-lookup"><span data-stu-id="028e6-247">Checkbox</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73A.png" width="32" height="32" alt="CheckboxComposite" /></td>
  <td><span data-ttu-id="028e6-248">E73A</span><span class="sxs-lookup"><span data-stu-id="028e6-248">E73A</span></span></td>
  <td><span data-ttu-id="028e6-249">CheckboxComposite</span><span class="sxs-lookup"><span data-stu-id="028e6-249">CheckboxComposite</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73B.png" width="32" height="32" alt="CheckboxFill" /></td>
  <td><span data-ttu-id="028e6-250">E73B</span><span class="sxs-lookup"><span data-stu-id="028e6-250">E73B</span></span></td>
  <td><span data-ttu-id="028e6-251">CheckboxFill</span><span class="sxs-lookup"><span data-stu-id="028e6-251">CheckboxFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73C.png" width="32" height="32" alt="CheckboxIndeterminate" /></td>
  <td><span data-ttu-id="028e6-252">E73C</span><span class="sxs-lookup"><span data-stu-id="028e6-252">E73C</span></span></td>
  <td><span data-ttu-id="028e6-253">CheckboxIndeterminate</span><span class="sxs-lookup"><span data-stu-id="028e6-253">CheckboxIndeterminate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73D.png" width="32" height="32" alt="CheckboxCompositeReversed" /></td>
  <td><span data-ttu-id="028e6-254">E73D</span><span class="sxs-lookup"><span data-stu-id="028e6-254">E73D</span></span></td>
  <td><span data-ttu-id="028e6-255">CheckboxCompositeReversed</span><span class="sxs-lookup"><span data-stu-id="028e6-255">CheckboxCompositeReversed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73E.png" width="32" height="32" alt="CheckMark" /></td>
  <td><span data-ttu-id="028e6-256">E73E</span><span class="sxs-lookup"><span data-stu-id="028e6-256">E73E</span></span></td>
  <td><span data-ttu-id="028e6-257">CheckMark</span><span class="sxs-lookup"><span data-stu-id="028e6-257">CheckMark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73F.png" width="32" height="32" alt="BackToWindow" /></td>
  <td><span data-ttu-id="028e6-258">E73F</span><span class="sxs-lookup"><span data-stu-id="028e6-258">E73F</span></span></td>
  <td><span data-ttu-id="028e6-259">BackToWindow</span><span class="sxs-lookup"><span data-stu-id="028e6-259">BackToWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E740.png" width="32" height="32" alt="FullScreen" /></td>
  <td><span data-ttu-id="028e6-260">E740</span><span class="sxs-lookup"><span data-stu-id="028e6-260">E740</span></span></td>
  <td><span data-ttu-id="028e6-261">FullScreen</span><span class="sxs-lookup"><span data-stu-id="028e6-261">FullScreen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E741.png" width="32" height="32" alt="ResizeTouchLarger" /></td>
  <td><span data-ttu-id="028e6-262">E741</span><span class="sxs-lookup"><span data-stu-id="028e6-262">E741</span></span></td>
  <td><span data-ttu-id="028e6-263">ResizeTouchLarger</span><span class="sxs-lookup"><span data-stu-id="028e6-263">ResizeTouchLarger</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E742.png" width="32" height="32" alt="ResizeTouchSmaller" /></td>
  <td><span data-ttu-id="028e6-264">E742</span><span class="sxs-lookup"><span data-stu-id="028e6-264">E742</span></span></td>
  <td><span data-ttu-id="028e6-265">ResizeTouchSmaller</span><span class="sxs-lookup"><span data-stu-id="028e6-265">ResizeTouchSmaller</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E743.png" width="32" height="32" alt="ResizeMouseSmall" /></td>
  <td><span data-ttu-id="028e6-266">E743</span><span class="sxs-lookup"><span data-stu-id="028e6-266">E743</span></span></td>
  <td><span data-ttu-id="028e6-267">ResizeMouseSmall</span><span class="sxs-lookup"><span data-stu-id="028e6-267">ResizeMouseSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E744.png" width="32" height="32" alt="ResizeMouseMedium" /></td>
  <td><span data-ttu-id="028e6-268">E744</span><span class="sxs-lookup"><span data-stu-id="028e6-268">E744</span></span></td>
  <td><span data-ttu-id="028e6-269">ResizeMouseMedium</span><span class="sxs-lookup"><span data-stu-id="028e6-269">ResizeMouseMedium</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E745.png" width="32" height="32" alt="ResizeMouseWide" /></td>
  <td><span data-ttu-id="028e6-270">E745</span><span class="sxs-lookup"><span data-stu-id="028e6-270">E745</span></span></td>
  <td><span data-ttu-id="028e6-271">ResizeMouseWide</span><span class="sxs-lookup"><span data-stu-id="028e6-271">ResizeMouseWide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E746.png" width="32" height="32" alt="ResizeMouseTall" /></td>
  <td><span data-ttu-id="028e6-272">E746</span><span class="sxs-lookup"><span data-stu-id="028e6-272">E746</span></span></td>
  <td><span data-ttu-id="028e6-273">ResizeMouseTall</span><span class="sxs-lookup"><span data-stu-id="028e6-273">ResizeMouseTall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E747.png" width="32" height="32" alt="ResizeMouseLarge" /></td>
  <td><span data-ttu-id="028e6-274">E747</span><span class="sxs-lookup"><span data-stu-id="028e6-274">E747</span></span></td>
  <td><span data-ttu-id="028e6-275">ResizeMouseLarge</span><span class="sxs-lookup"><span data-stu-id="028e6-275">ResizeMouseLarge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E748.png" width="32" height="32" alt="SwitchUser" /></td>
  <td><span data-ttu-id="028e6-276">E748</span><span class="sxs-lookup"><span data-stu-id="028e6-276">E748</span></span></td>
  <td><span data-ttu-id="028e6-277">SwitchUser</span><span class="sxs-lookup"><span data-stu-id="028e6-277">SwitchUser</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E749.png" width="32" height="32" alt="Print" /></td>
  <td><span data-ttu-id="028e6-278">E749</span><span class="sxs-lookup"><span data-stu-id="028e6-278">E749</span></span></td>
  <td><span data-ttu-id="028e6-279">Print</span><span class="sxs-lookup"><span data-stu-id="028e6-279">Print</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74A.png" width="32" height="32" alt="Up" /></td>
  <td><span data-ttu-id="028e6-280">E74A</span><span class="sxs-lookup"><span data-stu-id="028e6-280">E74A</span></span></td>
  <td><span data-ttu-id="028e6-281">Up</span><span class="sxs-lookup"><span data-stu-id="028e6-281">Up</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74B.png" width="32" height="32" alt="Down" /></td>
  <td><span data-ttu-id="028e6-282">E74B</span><span class="sxs-lookup"><span data-stu-id="028e6-282">E74B</span></span></td>
  <td><span data-ttu-id="028e6-283">Down</span><span class="sxs-lookup"><span data-stu-id="028e6-283">Down</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74C.png" width="32" height="32" alt="OEM" /></td>
  <td><span data-ttu-id="028e6-284">E74C</span><span class="sxs-lookup"><span data-stu-id="028e6-284">E74C</span></span></td>
  <td><span data-ttu-id="028e6-285">OEM</span><span class="sxs-lookup"><span data-stu-id="028e6-285">OEM</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74D.png" width="32" height="32" alt="Delete" /></td>
  <td><span data-ttu-id="028e6-286">E74D</span><span class="sxs-lookup"><span data-stu-id="028e6-286">E74D</span></span></td>
  <td><span data-ttu-id="028e6-287">Delete</span><span class="sxs-lookup"><span data-stu-id="028e6-287">Delete</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74E.png" width="32" height="32" alt="Save" /></td>
  <td><span data-ttu-id="028e6-288">E74E</span><span class="sxs-lookup"><span data-stu-id="028e6-288">E74E</span></span></td>
  <td><span data-ttu-id="028e6-289">Save</span><span class="sxs-lookup"><span data-stu-id="028e6-289">Save</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74F.png" width="32" height="32" alt="Mute" /></td>
  <td><span data-ttu-id="028e6-290">E74F</span><span class="sxs-lookup"><span data-stu-id="028e6-290">E74F</span></span></td>
  <td><span data-ttu-id="028e6-291">Mute</span><span class="sxs-lookup"><span data-stu-id="028e6-291">Mute</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E750.png" width="32" height="32" alt="BackSpaceQWERTY" /></td>
  <td><span data-ttu-id="028e6-292">E750</span><span class="sxs-lookup"><span data-stu-id="028e6-292">E750</span></span></td>
  <td><span data-ttu-id="028e6-293">BackSpaceQWERTY</span><span class="sxs-lookup"><span data-stu-id="028e6-293">BackSpaceQWERTY</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E751.png" width="32" height="32" alt="ReturnKey" /></td>
  <td><span data-ttu-id="028e6-294">E751</span><span class="sxs-lookup"><span data-stu-id="028e6-294">E751</span></span></td>
  <td><span data-ttu-id="028e6-295">ReturnKey</span><span class="sxs-lookup"><span data-stu-id="028e6-295">ReturnKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E752.png" width="32" height="32" alt="UpArrowShiftKey" /></td>
  <td><span data-ttu-id="028e6-296">E752</span><span class="sxs-lookup"><span data-stu-id="028e6-296">E752</span></span></td>
  <td><span data-ttu-id="028e6-297">UpArrowShiftKey</span><span class="sxs-lookup"><span data-stu-id="028e6-297">UpArrowShiftKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E753.png" width="32" height="32" alt="Cloud" /></td>
  <td><span data-ttu-id="028e6-298">E753</span><span class="sxs-lookup"><span data-stu-id="028e6-298">E753</span></span></td>
  <td><span data-ttu-id="028e6-299">Cloud</span><span class="sxs-lookup"><span data-stu-id="028e6-299">Cloud</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E754.png" width="32" height="32" alt="Flashlight" /></td>
  <td><span data-ttu-id="028e6-300">E754</span><span class="sxs-lookup"><span data-stu-id="028e6-300">E754</span></span></td>
  <td><span data-ttu-id="028e6-301">Flashlight</span><span class="sxs-lookup"><span data-stu-id="028e6-301">Flashlight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E755.png" width="32" height="32" alt="RotationLock" /></td>
  <td><span data-ttu-id="028e6-302">E755</span><span class="sxs-lookup"><span data-stu-id="028e6-302">E755</span></span></td>
  <td><span data-ttu-id="028e6-303">RotationLock</span><span class="sxs-lookup"><span data-stu-id="028e6-303">RotationLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E756.png" width="32" height="32" alt="CommandPrompt" /></td>
  <td><span data-ttu-id="028e6-304">E756</span><span class="sxs-lookup"><span data-stu-id="028e6-304">E756</span></span></td>
  <td><span data-ttu-id="028e6-305">CommandPrompt</span><span class="sxs-lookup"><span data-stu-id="028e6-305">CommandPrompt</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E759.png" width="32" height="32" alt="SIPMove" /></td>
  <td><span data-ttu-id="028e6-306">E759</span><span class="sxs-lookup"><span data-stu-id="028e6-306">E759</span></span></td>
  <td><span data-ttu-id="028e6-307">SIPMove</span><span class="sxs-lookup"><span data-stu-id="028e6-307">SIPMove</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75A.png" width="32" height="32" alt="SIPUndock" /></td>
  <td><span data-ttu-id="028e6-308">E75A</span><span class="sxs-lookup"><span data-stu-id="028e6-308">E75A</span></span></td>
  <td><span data-ttu-id="028e6-309">SIPUndock</span><span class="sxs-lookup"><span data-stu-id="028e6-309">SIPUndock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75B.png" width="32" height="32" alt="SIPRedock" /></td>
  <td><span data-ttu-id="028e6-310">E75B</span><span class="sxs-lookup"><span data-stu-id="028e6-310">E75B</span></span></td>
  <td><span data-ttu-id="028e6-311">SIPRedock</span><span class="sxs-lookup"><span data-stu-id="028e6-311">SIPRedock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75C.png" width="32" height="32" alt="EraseTool" /></td>
  <td><span data-ttu-id="028e6-312">E75C</span><span class="sxs-lookup"><span data-stu-id="028e6-312">E75C</span></span></td>
  <td><span data-ttu-id="028e6-313">EraseTool</span><span class="sxs-lookup"><span data-stu-id="028e6-313">EraseTool</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75D.png" width="32" height="32" alt="UnderscoreSpace" /></td>
  <td><span data-ttu-id="028e6-314">E75D</span><span class="sxs-lookup"><span data-stu-id="028e6-314">E75D</span></span></td>
  <td><span data-ttu-id="028e6-315">UnderscoreSpace</span><span class="sxs-lookup"><span data-stu-id="028e6-315">UnderscoreSpace</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75E.png" width="32" height="32" alt="GripperTool" /></td>
  <td><span data-ttu-id="028e6-316">E75E</span><span class="sxs-lookup"><span data-stu-id="028e6-316">E75E</span></span></td>
  <td><span data-ttu-id="028e6-317">GripperTool</span><span class="sxs-lookup"><span data-stu-id="028e6-317">GripperTool</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75F.png" width="32" height="32" alt="Dialpad" /></td>
  <td><span data-ttu-id="028e6-318">E75F</span><span class="sxs-lookup"><span data-stu-id="028e6-318">E75F</span></span></td>
  <td><span data-ttu-id="028e6-319">Dialpad</span><span class="sxs-lookup"><span data-stu-id="028e6-319">Dialpad</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E760.png" width="32" height="32" alt="PageLeft" /></td>
  <td><span data-ttu-id="028e6-320">E760</span><span class="sxs-lookup"><span data-stu-id="028e6-320">E760</span></span></td>
  <td><span data-ttu-id="028e6-321">PageLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-321">PageLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E761.png" width="32" height="32" alt="PageRight" /></td>
  <td><span data-ttu-id="028e6-322">E761</span><span class="sxs-lookup"><span data-stu-id="028e6-322">E761</span></span></td>
  <td><span data-ttu-id="028e6-323">PageRight</span><span class="sxs-lookup"><span data-stu-id="028e6-323">PageRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E762.png" width="32" height="32" alt="MultiSelect" /></td>
  <td><span data-ttu-id="028e6-324">E762</span><span class="sxs-lookup"><span data-stu-id="028e6-324">E762</span></span></td>
  <td><span data-ttu-id="028e6-325">MultiSelect</span><span class="sxs-lookup"><span data-stu-id="028e6-325">MultiSelect</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E763.png" width="32" height="32" alt="KeyboardLeftHanded" /></td>
  <td><span data-ttu-id="028e6-326">E763</span><span class="sxs-lookup"><span data-stu-id="028e6-326">E763</span></span></td>
  <td><span data-ttu-id="028e6-327">KeyboardLeftHanded</span><span class="sxs-lookup"><span data-stu-id="028e6-327">KeyboardLeftHanded</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E764.png" width="32" height="32" alt="KeyboardRightHanded" /></td>
  <td><span data-ttu-id="028e6-328">E764</span><span class="sxs-lookup"><span data-stu-id="028e6-328">E764</span></span></td>
  <td><span data-ttu-id="028e6-329">KeyboardRightHanded</span><span class="sxs-lookup"><span data-stu-id="028e6-329">KeyboardRightHanded</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E765.png" width="32" height="32" alt="KeyboardClassic" /></td>
  <td><span data-ttu-id="028e6-330">E765</span><span class="sxs-lookup"><span data-stu-id="028e6-330">E765</span></span></td>
  <td><span data-ttu-id="028e6-331">KeyboardClassic</span><span class="sxs-lookup"><span data-stu-id="028e6-331">KeyboardClassic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E766.png" width="32" height="32" alt="KeyboardSplit" /></td>
  <td><span data-ttu-id="028e6-332">E766</span><span class="sxs-lookup"><span data-stu-id="028e6-332">E766</span></span></td>
  <td><span data-ttu-id="028e6-333">KeyboardSplit</span><span class="sxs-lookup"><span data-stu-id="028e6-333">KeyboardSplit</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E767.png" width="32" height="32" alt="Volume" /></td>
  <td><span data-ttu-id="028e6-334">E767</span><span class="sxs-lookup"><span data-stu-id="028e6-334">E767</span></span></td>
  <td><span data-ttu-id="028e6-335">Volume</span><span class="sxs-lookup"><span data-stu-id="028e6-335">Volume</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E768.png" width="32" height="32" alt="Play" /></td>
  <td><span data-ttu-id="028e6-336">E768</span><span class="sxs-lookup"><span data-stu-id="028e6-336">E768</span></span></td>
  <td><span data-ttu-id="028e6-337">Play</span><span class="sxs-lookup"><span data-stu-id="028e6-337">Play</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E769.png" width="32" height="32" alt="Pause" /></td>
  <td><span data-ttu-id="028e6-338">E769</span><span class="sxs-lookup"><span data-stu-id="028e6-338">E769</span></span></td>
  <td><span data-ttu-id="028e6-339">Pause</span><span class="sxs-lookup"><span data-stu-id="028e6-339">Pause</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76B.png" width="32" height="32" alt="ChevronLeft" /></td>
  <td><span data-ttu-id="028e6-340">E76B</span><span class="sxs-lookup"><span data-stu-id="028e6-340">E76B</span></span></td>
  <td><span data-ttu-id="028e6-341">ChevronLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-341">ChevronLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76C.png" width="32" height="32" alt="ChevronRight" /></td>
  <td><span data-ttu-id="028e6-342">E76C</span><span class="sxs-lookup"><span data-stu-id="028e6-342">E76C</span></span></td>
  <td><span data-ttu-id="028e6-343">ChevronRight</span><span class="sxs-lookup"><span data-stu-id="028e6-343">ChevronRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76D.png" width="32" height="32" alt="InkingTool" /></td>
  <td><span data-ttu-id="028e6-344">E76D</span><span class="sxs-lookup"><span data-stu-id="028e6-344">E76D</span></span></td>
  <td><span data-ttu-id="028e6-345">InkingTool</span><span class="sxs-lookup"><span data-stu-id="028e6-345">InkingTool</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76E.png" width="32" height="32" alt="Emoji2" /></td>
  <td><span data-ttu-id="028e6-346">E76E</span><span class="sxs-lookup"><span data-stu-id="028e6-346">E76E</span></span></td>
  <td><span data-ttu-id="028e6-347">Emoji2</span><span class="sxs-lookup"><span data-stu-id="028e6-347">Emoji2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76F.png" width="32" height="32" alt="GripperBarHorizontal" /></td>
  <td><span data-ttu-id="028e6-348">E76F</span><span class="sxs-lookup"><span data-stu-id="028e6-348">E76F</span></span></td>
  <td><span data-ttu-id="028e6-349">GripperBarHorizontal</span><span class="sxs-lookup"><span data-stu-id="028e6-349">GripperBarHorizontal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E770.png" width="32" height="32" alt="System" /></td>
  <td><span data-ttu-id="028e6-350">E770</span><span class="sxs-lookup"><span data-stu-id="028e6-350">E770</span></span></td>
  <td><span data-ttu-id="028e6-351">System</span><span class="sxs-lookup"><span data-stu-id="028e6-351">System</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E771.png" width="32" height="32" alt="Personalize" /></td>
  <td><span data-ttu-id="028e6-352">E771</span><span class="sxs-lookup"><span data-stu-id="028e6-352">E771</span></span></td>
  <td><span data-ttu-id="028e6-353">Personalize</span><span class="sxs-lookup"><span data-stu-id="028e6-353">Personalize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E772.png" width="32" height="32" alt="Devices" /></td>
  <td><span data-ttu-id="028e6-354">E772</span><span class="sxs-lookup"><span data-stu-id="028e6-354">E772</span></span></td>
  <td><span data-ttu-id="028e6-355">Devices</span><span class="sxs-lookup"><span data-stu-id="028e6-355">Devices</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E773.png" width="32" height="32" alt="SearchAndApps" /></td>
  <td><span data-ttu-id="028e6-356">E773</span><span class="sxs-lookup"><span data-stu-id="028e6-356">E773</span></span></td>
  <td><span data-ttu-id="028e6-357">SearchAndApps</span><span class="sxs-lookup"><span data-stu-id="028e6-357">SearchAndApps</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E774.png" width="32" height="32" alt="Globe" /></td>
  <td><span data-ttu-id="028e6-358">E774</span><span class="sxs-lookup"><span data-stu-id="028e6-358">E774</span></span></td>
  <td><span data-ttu-id="028e6-359">Globe</span><span class="sxs-lookup"><span data-stu-id="028e6-359">Globe</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E775.png" width="32" height="32" alt="TimeLanguage" /></td>
  <td><span data-ttu-id="028e6-360">E775</span><span class="sxs-lookup"><span data-stu-id="028e6-360">E775</span></span></td>
  <td><span data-ttu-id="028e6-361">TimeLanguage</span><span class="sxs-lookup"><span data-stu-id="028e6-361">TimeLanguage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E776.png" width="32" height="32" alt="EaseOfAccess" /></td>
  <td><span data-ttu-id="028e6-362">E776</span><span class="sxs-lookup"><span data-stu-id="028e6-362">E776</span></span></td>
  <td><span data-ttu-id="028e6-363">EaseOfAccess</span><span class="sxs-lookup"><span data-stu-id="028e6-363">EaseOfAccess</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E777.png" width="32" height="32" alt="UpdateRestore" /></td>
  <td><span data-ttu-id="028e6-364">E777</span><span class="sxs-lookup"><span data-stu-id="028e6-364">E777</span></span></td>
  <td><span data-ttu-id="028e6-365">UpdateRestore</span><span class="sxs-lookup"><span data-stu-id="028e6-365">UpdateRestore</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E778.png" width="32" height="32" alt="HangUp" /></td>
  <td><span data-ttu-id="028e6-366">E778</span><span class="sxs-lookup"><span data-stu-id="028e6-366">E778</span></span></td>
  <td><span data-ttu-id="028e6-367">HangUp</span><span class="sxs-lookup"><span data-stu-id="028e6-367">HangUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E779.png" width="32" height="32" alt="ContactInfo" /></td>
  <td><span data-ttu-id="028e6-368">E779</span><span class="sxs-lookup"><span data-stu-id="028e6-368">E779</span></span></td>
  <td><span data-ttu-id="028e6-369">ContactInfo</span><span class="sxs-lookup"><span data-stu-id="028e6-369">ContactInfo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E77A.png" width="32" height="32" alt="Unpin" /></td>
  <td><span data-ttu-id="028e6-370">E77A</span><span class="sxs-lookup"><span data-stu-id="028e6-370">E77A</span></span></td>
  <td><span data-ttu-id="028e6-371">Unpin</span><span class="sxs-lookup"><span data-stu-id="028e6-371">Unpin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E77B.png" width="32" height="32" alt="Contact" /></td>
  <td><span data-ttu-id="028e6-372">E77B</span><span class="sxs-lookup"><span data-stu-id="028e6-372">E77B</span></span></td>
  <td><span data-ttu-id="028e6-373">Contact</span><span class="sxs-lookup"><span data-stu-id="028e6-373">Contact</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E77C.png" width="32" height="32" alt="Memo" /></td>
  <td><span data-ttu-id="028e6-374">E77C</span><span class="sxs-lookup"><span data-stu-id="028e6-374">E77C</span></span></td>
  <td><span data-ttu-id="028e6-375">Memo</span><span class="sxs-lookup"><span data-stu-id="028e6-375">Memo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E77F.png" width="32" height="32" alt="Paste" /></td>
  <td><span data-ttu-id="028e6-376">E77F</span><span class="sxs-lookup"><span data-stu-id="028e6-376">E77F</span></span></td>
  <td><span data-ttu-id="028e6-377">Paste</span><span class="sxs-lookup"><span data-stu-id="028e6-377">Paste</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E780.png" width="32" height="32" alt="PhoneBook" /></td>
  <td><span data-ttu-id="028e6-378">E780</span><span class="sxs-lookup"><span data-stu-id="028e6-378">E780</span></span></td>
  <td><span data-ttu-id="028e6-379">PhoneBook</span><span class="sxs-lookup"><span data-stu-id="028e6-379">PhoneBook</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E781.png" width="32" height="32" alt="LEDLight" /></td>
  <td><span data-ttu-id="028e6-380">E781</span><span class="sxs-lookup"><span data-stu-id="028e6-380">E781</span></span></td>
  <td><span data-ttu-id="028e6-381">LEDLight</span><span class="sxs-lookup"><span data-stu-id="028e6-381">LEDLight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E783.png" width="32" height="32" alt="Error" /></td>
  <td><span data-ttu-id="028e6-382">E783</span><span class="sxs-lookup"><span data-stu-id="028e6-382">E783</span></span></td>
  <td><span data-ttu-id="028e6-383">Error</span><span class="sxs-lookup"><span data-stu-id="028e6-383">Error</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E784.png" width="32" height="32" alt="GripperBarVertical" /></td>
  <td><span data-ttu-id="028e6-384">E784</span><span class="sxs-lookup"><span data-stu-id="028e6-384">E784</span></span></td>
  <td><span data-ttu-id="028e6-385">GripperBarVertical</span><span class="sxs-lookup"><span data-stu-id="028e6-385">GripperBarVertical</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E785.png" width="32" height="32" alt="Unlock" /></td>
  <td><span data-ttu-id="028e6-386">E785</span><span class="sxs-lookup"><span data-stu-id="028e6-386">E785</span></span></td>
  <td><span data-ttu-id="028e6-387">Unlock</span><span class="sxs-lookup"><span data-stu-id="028e6-387">Unlock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E786.png" width="32" height="32" alt="Slideshow" /></td>
  <td><span data-ttu-id="028e6-388">E786</span><span class="sxs-lookup"><span data-stu-id="028e6-388">E786</span></span></td>
  <td><span data-ttu-id="028e6-389">Slideshow</span><span class="sxs-lookup"><span data-stu-id="028e6-389">Slideshow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E787.png" width="32" height="32" alt="Calendar" /></td>
  <td><span data-ttu-id="028e6-390">E787</span><span class="sxs-lookup"><span data-stu-id="028e6-390">E787</span></span></td>
  <td><span data-ttu-id="028e6-391">Calendar</span><span class="sxs-lookup"><span data-stu-id="028e6-391">Calendar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E788.png" width="32" height="32" alt="GripperResize" /></td>
  <td><span data-ttu-id="028e6-392">E788</span><span class="sxs-lookup"><span data-stu-id="028e6-392">E788</span></span></td>
  <td><span data-ttu-id="028e6-393">GripperResize</span><span class="sxs-lookup"><span data-stu-id="028e6-393">GripperResize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E789.png" width="32" height="32" alt="Megaphone" /></td>
  <td><span data-ttu-id="028e6-394">E789</span><span class="sxs-lookup"><span data-stu-id="028e6-394">E789</span></span></td>
  <td><span data-ttu-id="028e6-395">Megaphone</span><span class="sxs-lookup"><span data-stu-id="028e6-395">Megaphone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E78A.png" width="32" height="32" alt="Trim" /></td>
  <td><span data-ttu-id="028e6-396">E78A</span><span class="sxs-lookup"><span data-stu-id="028e6-396">E78A</span></span></td>
  <td><span data-ttu-id="028e6-397">Trim</span><span class="sxs-lookup"><span data-stu-id="028e6-397">Trim</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E78B.png" width="32" height="32" alt="NewWindow" /></td>
  <td><span data-ttu-id="028e6-398">E78B</span><span class="sxs-lookup"><span data-stu-id="028e6-398">E78B</span></span></td>
  <td><span data-ttu-id="028e6-399">NewWindow</span><span class="sxs-lookup"><span data-stu-id="028e6-399">NewWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E78C.png" width="32" height="32" alt="SaveLocal" /></td>
  <td><span data-ttu-id="028e6-400">E78C</span><span class="sxs-lookup"><span data-stu-id="028e6-400">E78C</span></span></td>
  <td><span data-ttu-id="028e6-401">SaveLocal</span><span class="sxs-lookup"><span data-stu-id="028e6-401">SaveLocal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E790.png" width="32" height="32" alt="Color" /></td>
  <td><span data-ttu-id="028e6-402">E790</span><span class="sxs-lookup"><span data-stu-id="028e6-402">E790</span></span></td>
  <td><span data-ttu-id="028e6-403">Color</span><span class="sxs-lookup"><span data-stu-id="028e6-403">Color</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E791.png" width="32" height="32" alt="DataSense" /></td>
  <td><span data-ttu-id="028e6-404">E791</span><span class="sxs-lookup"><span data-stu-id="028e6-404">E791</span></span></td>
  <td><span data-ttu-id="028e6-405">DataSense</span><span class="sxs-lookup"><span data-stu-id="028e6-405">DataSense</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E792.png" width="32" height="32" alt="SaveAs" /></td>
  <td><span data-ttu-id="028e6-406">E792</span><span class="sxs-lookup"><span data-stu-id="028e6-406">E792</span></span></td>
  <td><span data-ttu-id="028e6-407">SaveAs</span><span class="sxs-lookup"><span data-stu-id="028e6-407">SaveAs</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E793.png" width="32" height="32" alt="Light" /></td>
  <td><span data-ttu-id="028e6-408">E793</span><span class="sxs-lookup"><span data-stu-id="028e6-408">E793</span></span></td>
  <td><span data-ttu-id="028e6-409">Light</span><span class="sxs-lookup"><span data-stu-id="028e6-409">Light</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E799.png" width="32" height="32" alt="AspectRatio" /></td>
  <td><span data-ttu-id="028e6-410">E799</span><span class="sxs-lookup"><span data-stu-id="028e6-410">E799</span></span></td>
  <td><span data-ttu-id="028e6-411">AspectRatio</span><span class="sxs-lookup"><span data-stu-id="028e6-411">AspectRatio</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7A5.png" width="32" height="32" alt="DataSenseBar" /></td>
  <td><span data-ttu-id="028e6-412">E7A5</span><span class="sxs-lookup"><span data-stu-id="028e6-412">E7A5</span></span></td>
  <td><span data-ttu-id="028e6-413">DataSenseBar</span><span class="sxs-lookup"><span data-stu-id="028e6-413">DataSenseBar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7A6.png" width="32" height="32" alt="Redo" /></td>
  <td><span data-ttu-id="028e6-414">E7A6</span><span class="sxs-lookup"><span data-stu-id="028e6-414">E7A6</span></span></td>
  <td><span data-ttu-id="028e6-415">Redo</span><span class="sxs-lookup"><span data-stu-id="028e6-415">Redo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7A7.png" width="32" height="32" alt="Undo" /></td>
  <td><span data-ttu-id="028e6-416">E7A7</span><span class="sxs-lookup"><span data-stu-id="028e6-416">E7A7</span></span></td>
  <td><span data-ttu-id="028e6-417">Undo</span><span class="sxs-lookup"><span data-stu-id="028e6-417">Undo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7A8.png" width="32" height="32" alt="Crop" /></td>
  <td><span data-ttu-id="028e6-418">E7A8</span><span class="sxs-lookup"><span data-stu-id="028e6-418">E7A8</span></span></td>
  <td><span data-ttu-id="028e6-419">Crop</span><span class="sxs-lookup"><span data-stu-id="028e6-419">Crop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7AC.png" width="32" height="32" alt="OpenWith" /></td>
  <td><span data-ttu-id="028e6-420">E7AC</span><span class="sxs-lookup"><span data-stu-id="028e6-420">E7AC</span></span></td>
  <td><span data-ttu-id="028e6-421">OpenWith</span><span class="sxs-lookup"><span data-stu-id="028e6-421">OpenWith</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7AD.png" width="32" height="32" alt="Rotate" /></td>
  <td><span data-ttu-id="028e6-422">E7AD</span><span class="sxs-lookup"><span data-stu-id="028e6-422">E7AD</span></span></td>
  <td><span data-ttu-id="028e6-423">Rotate</span><span class="sxs-lookup"><span data-stu-id="028e6-423">Rotate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7B3.png" width="32" height="32" alt="RedEye" /></td>
  <td><span data-ttu-id="028e6-424">E7B3</span><span class="sxs-lookup"><span data-stu-id="028e6-424">E7B3</span></span></td>
  <td><span data-ttu-id="028e6-425">RedEye</span><span class="sxs-lookup"><span data-stu-id="028e6-425">RedEye</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7B5.png" width="32" height="32" alt="SetlockScreen" /></td>
  <td><span data-ttu-id="028e6-426">E7B5</span><span class="sxs-lookup"><span data-stu-id="028e6-426">E7B5</span></span></td>
  <td><span data-ttu-id="028e6-427">SetlockScreen</span><span class="sxs-lookup"><span data-stu-id="028e6-427">SetlockScreen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7B7.png" width="32" height="32" alt="MapPin2" /></td>
  <td><span data-ttu-id="028e6-428">E7B7</span><span class="sxs-lookup"><span data-stu-id="028e6-428">E7B7</span></span></td>
  <td><span data-ttu-id="028e6-429">MapPin2</span><span class="sxs-lookup"><span data-stu-id="028e6-429">MapPin2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7B8.png" width="32" height="32" alt="Package" /></td>
  <td><span data-ttu-id="028e6-430">E7B8</span><span class="sxs-lookup"><span data-stu-id="028e6-430">E7B8</span></span></td>
  <td><span data-ttu-id="028e6-431">Package</span><span class="sxs-lookup"><span data-stu-id="028e6-431">Package</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7BA.png" width="32" height="32" alt="Warning" /></td>
  <td><span data-ttu-id="028e6-432">E7BA</span><span class="sxs-lookup"><span data-stu-id="028e6-432">E7BA</span></span></td>
  <td><span data-ttu-id="028e6-433">Warning</span><span class="sxs-lookup"><span data-stu-id="028e6-433">Warning</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7BC.png" width="32" height="32" alt="ReadingList" /></td>
  <td><span data-ttu-id="028e6-434">E7BC</span><span class="sxs-lookup"><span data-stu-id="028e6-434">E7BC</span></span></td>
  <td><span data-ttu-id="028e6-435">ReadingList</span><span class="sxs-lookup"><span data-stu-id="028e6-435">ReadingList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7BE.png" width="32" height="32" alt="Education" /></td>
  <td><span data-ttu-id="028e6-436">E7BE</span><span class="sxs-lookup"><span data-stu-id="028e6-436">E7BE</span></span></td>
  <td><span data-ttu-id="028e6-437">Education</span><span class="sxs-lookup"><span data-stu-id="028e6-437">Education</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7BF.png" width="32" height="32" alt="ShoppingCart" /></td>
  <td><span data-ttu-id="028e6-438">E7BF</span><span class="sxs-lookup"><span data-stu-id="028e6-438">E7BF</span></span></td>
  <td><span data-ttu-id="028e6-439">ShoppingCart</span><span class="sxs-lookup"><span data-stu-id="028e6-439">ShoppingCart</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C0.png" width="32" height="32" alt="Train" /></td>
  <td><span data-ttu-id="028e6-440">E7C0</span><span class="sxs-lookup"><span data-stu-id="028e6-440">E7C0</span></span></td>
  <td><span data-ttu-id="028e6-441">Train</span><span class="sxs-lookup"><span data-stu-id="028e6-441">Train</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C1.png" width="32" height="32" alt="Flag" /></td>
  <td><span data-ttu-id="028e6-442">E7C1</span><span class="sxs-lookup"><span data-stu-id="028e6-442">E7C1</span></span></td>
  <td><span data-ttu-id="028e6-443">Flag</span><span class="sxs-lookup"><span data-stu-id="028e6-443">Flag</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C3.png" width="32" height="32" alt="Page" /></td>
  <td><span data-ttu-id="028e6-444">E7C3</span><span class="sxs-lookup"><span data-stu-id="028e6-444">E7C3</span></span></td>
  <td><span data-ttu-id="028e6-445">Page</span><span class="sxs-lookup"><span data-stu-id="028e6-445">Page</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C4.png" width="32" height="32" alt="TaskView" /></td>
  <td><span data-ttu-id="028e6-446">E7C4</span><span class="sxs-lookup"><span data-stu-id="028e6-446">E7C4</span></span></td>
  <td><span data-ttu-id="028e6-447">TaskView</span><span class="sxs-lookup"><span data-stu-id="028e6-447">TaskView</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C5.png" width="32" height="32" alt="BrowsePhotos" /></td>
  <td><span data-ttu-id="028e6-448">E7C5</span><span class="sxs-lookup"><span data-stu-id="028e6-448">E7C5</span></span></td>
  <td><span data-ttu-id="028e6-449">BrowsePhotos</span><span class="sxs-lookup"><span data-stu-id="028e6-449">BrowsePhotos</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C6.png" width="32" height="32" alt="HalfStarLeft" /></td>
  <td><span data-ttu-id="028e6-450">E7C6</span><span class="sxs-lookup"><span data-stu-id="028e6-450">E7C6</span></span></td>
  <td><span data-ttu-id="028e6-451">HalfStarLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-451">HalfStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C7.png" width="32" height="32" alt="HalfStarRight" /></td>
  <td><span data-ttu-id="028e6-452">E7C7</span><span class="sxs-lookup"><span data-stu-id="028e6-452">E7C7</span></span></td>
  <td><span data-ttu-id="028e6-453">HalfStarRight</span><span class="sxs-lookup"><span data-stu-id="028e6-453">HalfStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C8.png" width="32" height="32" alt="Record" /></td>
  <td><span data-ttu-id="028e6-454">E7C8</span><span class="sxs-lookup"><span data-stu-id="028e6-454">E7C8</span></span></td>
  <td><span data-ttu-id="028e6-455">Record</span><span class="sxs-lookup"><span data-stu-id="028e6-455">Record</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C9.png" width="32" height="32" alt="TouchPointer" /></td>
  <td><span data-ttu-id="028e6-456">E7C9</span><span class="sxs-lookup"><span data-stu-id="028e6-456">E7C9</span></span></td>
  <td><span data-ttu-id="028e6-457">TouchPointer</span><span class="sxs-lookup"><span data-stu-id="028e6-457">TouchPointer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7DE.png" width="32" height="32" alt="LangJPN" /></td>
  <td><span data-ttu-id="028e6-458">E7DE</span><span class="sxs-lookup"><span data-stu-id="028e6-458">E7DE</span></span></td>
  <td><span data-ttu-id="028e6-459">LangJPN</span><span class="sxs-lookup"><span data-stu-id="028e6-459">LangJPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7E3.png" width="32" height="32" alt="Ferry" /></td>
  <td><span data-ttu-id="028e6-460">E7E3</span><span class="sxs-lookup"><span data-stu-id="028e6-460">E7E3</span></span></td>
  <td><span data-ttu-id="028e6-461">Ferry</span><span class="sxs-lookup"><span data-stu-id="028e6-461">Ferry</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7E6.png" width="32" height="32" alt="Highlight" /></td>
  <td><span data-ttu-id="028e6-462">E7E6</span><span class="sxs-lookup"><span data-stu-id="028e6-462">E7E6</span></span></td>
  <td><span data-ttu-id="028e6-463">Highlight</span><span class="sxs-lookup"><span data-stu-id="028e6-463">Highlight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7E7.png" width="32" height="32" alt="ActionCenterNotification" /></td>
  <td><span data-ttu-id="028e6-464">E7E7</span><span class="sxs-lookup"><span data-stu-id="028e6-464">E7E7</span></span></td>
  <td><span data-ttu-id="028e6-465">ActionCenterNotification</span><span class="sxs-lookup"><span data-stu-id="028e6-465">ActionCenterNotification</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7E8.png" width="32" height="32" alt="PowerButton" /></td>
  <td><span data-ttu-id="028e6-466">E7E8</span><span class="sxs-lookup"><span data-stu-id="028e6-466">E7E8</span></span></td>
  <td><span data-ttu-id="028e6-467">PowerButton</span><span class="sxs-lookup"><span data-stu-id="028e6-467">PowerButton</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EA.png" width="32" height="32" alt="ResizeTouchNarrower" /></td>
  <td><span data-ttu-id="028e6-468">E7EA</span><span class="sxs-lookup"><span data-stu-id="028e6-468">E7EA</span></span></td>
  <td><span data-ttu-id="028e6-469">ResizeTouchNarrower</span><span class="sxs-lookup"><span data-stu-id="028e6-469">ResizeTouchNarrower</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EB.png" width="32" height="32" alt="ResizeTouchShorter" /></td>
  <td><span data-ttu-id="028e6-470">E7EB</span><span class="sxs-lookup"><span data-stu-id="028e6-470">E7EB</span></span></td>
  <td><span data-ttu-id="028e6-471">ResizeTouchShorter</span><span class="sxs-lookup"><span data-stu-id="028e6-471">ResizeTouchShorter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EC.png" width="32" height="32" alt="DrivingMode" /></td>
  <td><span data-ttu-id="028e6-472">E7EC</span><span class="sxs-lookup"><span data-stu-id="028e6-472">E7EC</span></span></td>
  <td><span data-ttu-id="028e6-473">DrivingMode</span><span class="sxs-lookup"><span data-stu-id="028e6-473">DrivingMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7ED.png" width="32" height="32" alt="RingerSilent" /></td>
  <td><span data-ttu-id="028e6-474">E7ED</span><span class="sxs-lookup"><span data-stu-id="028e6-474">E7ED</span></span></td>
  <td><span data-ttu-id="028e6-475">RingerSilent</span><span class="sxs-lookup"><span data-stu-id="028e6-475">RingerSilent</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EE.png" width="32" height="32" alt="OtherUser" /></td>
  <td><span data-ttu-id="028e6-476">E7EE</span><span class="sxs-lookup"><span data-stu-id="028e6-476">E7EE</span></span></td>
  <td><span data-ttu-id="028e6-477">OtherUser</span><span class="sxs-lookup"><span data-stu-id="028e6-477">OtherUser</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EF.png" width="32" height="32" alt="Admin" /></td>
  <td><span data-ttu-id="028e6-478">E7EF</span><span class="sxs-lookup"><span data-stu-id="028e6-478">E7EF</span></span></td>
  <td><span data-ttu-id="028e6-479">Admin</span><span class="sxs-lookup"><span data-stu-id="028e6-479">Admin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F0.png" width="32" height="32" alt="CC" /></td>
  <td><span data-ttu-id="028e6-480">E7F0</span><span class="sxs-lookup"><span data-stu-id="028e6-480">E7F0</span></span></td>
  <td><span data-ttu-id="028e6-481">CC</span><span class="sxs-lookup"><span data-stu-id="028e6-481">CC</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F1.png" width="32" height="32" alt="SDCard" /></td>
  <td><span data-ttu-id="028e6-482">E7F1</span><span class="sxs-lookup"><span data-stu-id="028e6-482">E7F1</span></span></td>
  <td><span data-ttu-id="028e6-483">SDCard</span><span class="sxs-lookup"><span data-stu-id="028e6-483">SDCard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F2.png" width="32" height="32" alt="CallForwarding" /></td>
  <td><span data-ttu-id="028e6-484">E7F2</span><span class="sxs-lookup"><span data-stu-id="028e6-484">E7F2</span></span></td>
  <td><span data-ttu-id="028e6-485">CallForwarding</span><span class="sxs-lookup"><span data-stu-id="028e6-485">CallForwarding</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F3.png" width="32" height="32" alt="SettingsDisplaySound" /></td>
  <td><span data-ttu-id="028e6-486">E7F3</span><span class="sxs-lookup"><span data-stu-id="028e6-486">E7F3</span></span></td>
  <td><span data-ttu-id="028e6-487">SettingsDisplaySound</span><span class="sxs-lookup"><span data-stu-id="028e6-487">SettingsDisplaySound</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F4.png" width="32" height="32" alt="TVMonitor" /></td>
  <td><span data-ttu-id="028e6-488">E7F4</span><span class="sxs-lookup"><span data-stu-id="028e6-488">E7F4</span></span></td>
  <td><span data-ttu-id="028e6-489">TVMonitor</span><span class="sxs-lookup"><span data-stu-id="028e6-489">TVMonitor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F5.png" width="32" height="32" alt="Speakers" /></td>
  <td><span data-ttu-id="028e6-490">E7F5</span><span class="sxs-lookup"><span data-stu-id="028e6-490">E7F5</span></span></td>
  <td><span data-ttu-id="028e6-491">Speakers</span><span class="sxs-lookup"><span data-stu-id="028e6-491">Speakers</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F6.png" width="32" height="32" alt="Headphone" /></td>
  <td><span data-ttu-id="028e6-492">E7F6</span><span class="sxs-lookup"><span data-stu-id="028e6-492">E7F6</span></span></td>
  <td><span data-ttu-id="028e6-493">Headphone</span><span class="sxs-lookup"><span data-stu-id="028e6-493">Headphone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F7.png" width="32" height="32" alt="DeviceLaptopPic" /></td>
  <td><span data-ttu-id="028e6-494">E7F7</span><span class="sxs-lookup"><span data-stu-id="028e6-494">E7F7</span></span></td>
  <td><span data-ttu-id="028e6-495">DeviceLaptopPic</span><span class="sxs-lookup"><span data-stu-id="028e6-495">DeviceLaptopPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F8.png" width="32" height="32" alt="DeviceLaptopNoPic" /></td>
  <td><span data-ttu-id="028e6-496">E7F8</span><span class="sxs-lookup"><span data-stu-id="028e6-496">E7F8</span></span></td>
  <td><span data-ttu-id="028e6-497">DeviceLaptopNoPic</span><span class="sxs-lookup"><span data-stu-id="028e6-497">DeviceLaptopNoPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F9.png" width="32" height="32" alt="DeviceMonitorRightPic" /></td>
  <td><span data-ttu-id="028e6-498">E7F9</span><span class="sxs-lookup"><span data-stu-id="028e6-498">E7F9</span></span></td>
  <td><span data-ttu-id="028e6-499">DeviceMonitorRightPic</span><span class="sxs-lookup"><span data-stu-id="028e6-499">DeviceMonitorRightPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7FA.png" width="32" height="32" alt="DeviceMonitorLeftPic" /></td>
  <td><span data-ttu-id="028e6-500">E7FA</span><span class="sxs-lookup"><span data-stu-id="028e6-500">E7FA</span></span></td>
  <td><span data-ttu-id="028e6-501">DeviceMonitorLeftPic</span><span class="sxs-lookup"><span data-stu-id="028e6-501">DeviceMonitorLeftPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7FB.png" width="32" height="32" alt="DeviceMonitorNoPic" /></td>
  <td><span data-ttu-id="028e6-502">E7FB</span><span class="sxs-lookup"><span data-stu-id="028e6-502">E7FB</span></span></td>
  <td><span data-ttu-id="028e6-503">DeviceMonitorNoPic</span><span class="sxs-lookup"><span data-stu-id="028e6-503">DeviceMonitorNoPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7FC.png" width="32" height="32" alt="Game" /></td>
  <td><span data-ttu-id="028e6-504">E7FC</span><span class="sxs-lookup"><span data-stu-id="028e6-504">E7FC</span></span></td>
  <td><span data-ttu-id="028e6-505">Game</span><span class="sxs-lookup"><span data-stu-id="028e6-505">Game</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7FD.png" width="32" height="32" alt="HorizontalTabKey" /></td>
  <td><span data-ttu-id="028e6-506">E7FD</span><span class="sxs-lookup"><span data-stu-id="028e6-506">E7FD</span></span></td>
  <td><span data-ttu-id="028e6-507">HorizontalTabKey</span><span class="sxs-lookup"><span data-stu-id="028e6-507">HorizontalTabKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E802.png" width="32" height="32" alt="StreetsideSplitMinimize" /></td>
  <td><span data-ttu-id="028e6-508">E802</span><span class="sxs-lookup"><span data-stu-id="028e6-508">E802</span></span></td>
  <td><span data-ttu-id="028e6-509">StreetsideSplitMinimize</span><span class="sxs-lookup"><span data-stu-id="028e6-509">StreetsideSplitMinimize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E803.png" width="32" height="32" alt="StreetsideSplitExpand" /></td>
  <td><span data-ttu-id="028e6-510">E803</span><span class="sxs-lookup"><span data-stu-id="028e6-510">E803</span></span></td>
  <td><span data-ttu-id="028e6-511">StreetsideSplitExpand</span><span class="sxs-lookup"><span data-stu-id="028e6-511">StreetsideSplitExpand</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E804.png" width="32" height="32" alt="Car" /></td>
  <td><span data-ttu-id="028e6-512">E804</span><span class="sxs-lookup"><span data-stu-id="028e6-512">E804</span></span></td>
  <td><span data-ttu-id="028e6-513">Car</span><span class="sxs-lookup"><span data-stu-id="028e6-513">Car</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E805.png" width="32" height="32" alt="Walk" /></td>
  <td><span data-ttu-id="028e6-514">E805</span><span class="sxs-lookup"><span data-stu-id="028e6-514">E805</span></span></td>
  <td><span data-ttu-id="028e6-515">Walk</span><span class="sxs-lookup"><span data-stu-id="028e6-515">Walk</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E806.png" width="32" height="32" alt="Bus" /></td>
  <td><span data-ttu-id="028e6-516">E806</span><span class="sxs-lookup"><span data-stu-id="028e6-516">E806</span></span></td>
  <td><span data-ttu-id="028e6-517">Bus</span><span class="sxs-lookup"><span data-stu-id="028e6-517">Bus</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E809.png" width="32" height="32" alt="TiltUp" /></td>
  <td><span data-ttu-id="028e6-518">E809</span><span class="sxs-lookup"><span data-stu-id="028e6-518">E809</span></span></td>
  <td><span data-ttu-id="028e6-519">TiltUp</span><span class="sxs-lookup"><span data-stu-id="028e6-519">TiltUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E80A.png" width="32" height="32" alt="TiltDown" /></td>
  <td><span data-ttu-id="028e6-520">E80A</span><span class="sxs-lookup"><span data-stu-id="028e6-520">E80A</span></span></td>
  <td><span data-ttu-id="028e6-521">TiltDown</span><span class="sxs-lookup"><span data-stu-id="028e6-521">TiltDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E80C.png" width="32" height="32" alt="RotateMapRight" /></td>
  <td><span data-ttu-id="028e6-522">E80C</span><span class="sxs-lookup"><span data-stu-id="028e6-522">E80C</span></span></td>
  <td><span data-ttu-id="028e6-523">RotateMapRight</span><span class="sxs-lookup"><span data-stu-id="028e6-523">RotateMapRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E80D.png" width="32" height="32" alt="RotateMapLeft" /></td>
  <td><span data-ttu-id="028e6-524">E80D</span><span class="sxs-lookup"><span data-stu-id="028e6-524">E80D</span></span></td>
  <td><span data-ttu-id="028e6-525">RotateMapLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-525">RotateMapLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E80F.png" width="32" height="32" alt="Home" /></td>
  <td><span data-ttu-id="028e6-526">E80F</span><span class="sxs-lookup"><span data-stu-id="028e6-526">E80F</span></span></td>
  <td><span data-ttu-id="028e6-527">Home</span><span class="sxs-lookup"><span data-stu-id="028e6-527">Home</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E811.png" width="32" height="32" alt="ParkingLocation" /></td>
  <td><span data-ttu-id="028e6-528">E811</span><span class="sxs-lookup"><span data-stu-id="028e6-528">E811</span></span></td>
  <td><span data-ttu-id="028e6-529">ParkingLocation</span><span class="sxs-lookup"><span data-stu-id="028e6-529">ParkingLocation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E812.png" width="32" height="32" alt="MapCompassTop" /></td>
  <td><span data-ttu-id="028e6-530">E812</span><span class="sxs-lookup"><span data-stu-id="028e6-530">E812</span></span></td>
  <td><span data-ttu-id="028e6-531">MapCompassTop</span><span class="sxs-lookup"><span data-stu-id="028e6-531">MapCompassTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E813.png" width="32" height="32" alt="MapCompassBottom" /></td>
  <td><span data-ttu-id="028e6-532">E813</span><span class="sxs-lookup"><span data-stu-id="028e6-532">E813</span></span></td>
  <td><span data-ttu-id="028e6-533">MapCompassBottom</span><span class="sxs-lookup"><span data-stu-id="028e6-533">MapCompassBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E814.png" width="32" height="32" alt="IncidentTriangle" /></td>
  <td><span data-ttu-id="028e6-534">E814</span><span class="sxs-lookup"><span data-stu-id="028e6-534">E814</span></span></td>
  <td><span data-ttu-id="028e6-535">IncidentTriangle</span><span class="sxs-lookup"><span data-stu-id="028e6-535">IncidentTriangle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E815.png" width="32" height="32" alt="Touch" /></td>
  <td><span data-ttu-id="028e6-536">E815</span><span class="sxs-lookup"><span data-stu-id="028e6-536">E815</span></span></td>
  <td><span data-ttu-id="028e6-537">Touch</span><span class="sxs-lookup"><span data-stu-id="028e6-537">Touch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E816.png" width="32" height="32" alt="MapDirections" /></td>
  <td><span data-ttu-id="028e6-538">E816</span><span class="sxs-lookup"><span data-stu-id="028e6-538">E816</span></span></td>
  <td><span data-ttu-id="028e6-539">MapDirections</span><span class="sxs-lookup"><span data-stu-id="028e6-539">MapDirections</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E819.png" width="32" height="32" alt="StartPoint" /></td>
  <td><span data-ttu-id="028e6-540">E819</span><span class="sxs-lookup"><span data-stu-id="028e6-540">E819</span></span></td>
  <td><span data-ttu-id="028e6-541">StartPoint</span><span class="sxs-lookup"><span data-stu-id="028e6-541">StartPoint</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81A.png" width="32" height="32" alt="StopPoint" /></td>
  <td><span data-ttu-id="028e6-542">E81A</span><span class="sxs-lookup"><span data-stu-id="028e6-542">E81A</span></span></td>
  <td><span data-ttu-id="028e6-543">StopPoint</span><span class="sxs-lookup"><span data-stu-id="028e6-543">StopPoint</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81B.png" width="32" height="32" alt="EndPoint" /></td>
  <td><span data-ttu-id="028e6-544">E81B</span><span class="sxs-lookup"><span data-stu-id="028e6-544">E81B</span></span></td>
  <td><span data-ttu-id="028e6-545">EndPoint</span><span class="sxs-lookup"><span data-stu-id="028e6-545">EndPoint</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81C.png" width="32" height="32" alt="History" /></td>
  <td><span data-ttu-id="028e6-546">E81C</span><span class="sxs-lookup"><span data-stu-id="028e6-546">E81C</span></span></td>
  <td><span data-ttu-id="028e6-547">History</span><span class="sxs-lookup"><span data-stu-id="028e6-547">History</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81D.png" width="32" height="32" alt="Location" /></td>
  <td><span data-ttu-id="028e6-548">E81D</span><span class="sxs-lookup"><span data-stu-id="028e6-548">E81D</span></span></td>
  <td><span data-ttu-id="028e6-549">Location</span><span class="sxs-lookup"><span data-stu-id="028e6-549">Location</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81E.png" width="32" height="32" alt="MapLayers" /></td>
  <td><span data-ttu-id="028e6-550">E81E</span><span class="sxs-lookup"><span data-stu-id="028e6-550">E81E</span></span></td>
  <td><span data-ttu-id="028e6-551">MapLayers</span><span class="sxs-lookup"><span data-stu-id="028e6-551">MapLayers</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81F.png" width="32" height="32" alt="Accident" /></td>
  <td><span data-ttu-id="028e6-552">E81F</span><span class="sxs-lookup"><span data-stu-id="028e6-552">E81F</span></span></td>
  <td><span data-ttu-id="028e6-553">Accident</span><span class="sxs-lookup"><span data-stu-id="028e6-553">Accident</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E821.png" width="32" height="32" alt="Work" /></td>
  <td><span data-ttu-id="028e6-554">E821</span><span class="sxs-lookup"><span data-stu-id="028e6-554">E821</span></span></td>
  <td><span data-ttu-id="028e6-555">Work</span><span class="sxs-lookup"><span data-stu-id="028e6-555">Work</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E822.png" width="32" height="32" alt="Construction" /></td>
  <td><span data-ttu-id="028e6-556">E822</span><span class="sxs-lookup"><span data-stu-id="028e6-556">E822</span></span></td>
  <td><span data-ttu-id="028e6-557">Construction</span><span class="sxs-lookup"><span data-stu-id="028e6-557">Construction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E823.png" width="32" height="32" alt="Recent" /></td>
  <td><span data-ttu-id="028e6-558">E823</span><span class="sxs-lookup"><span data-stu-id="028e6-558">E823</span></span></td>
  <td><span data-ttu-id="028e6-559">Recent</span><span class="sxs-lookup"><span data-stu-id="028e6-559">Recent</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E825.png" width="32" height="32" alt="Bank" /></td>
  <td><span data-ttu-id="028e6-560">E825</span><span class="sxs-lookup"><span data-stu-id="028e6-560">E825</span></span></td>
  <td><span data-ttu-id="028e6-561">Bank</span><span class="sxs-lookup"><span data-stu-id="028e6-561">Bank</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E826.png" width="32" height="32" alt="DownloadMap" /></td>
  <td><span data-ttu-id="028e6-562">E826</span><span class="sxs-lookup"><span data-stu-id="028e6-562">E826</span></span></td>
  <td><span data-ttu-id="028e6-563">DownloadMap</span><span class="sxs-lookup"><span data-stu-id="028e6-563">DownloadMap</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E829.png" width="32" height="32" alt="InkingToolFill2" /></td>
  <td><span data-ttu-id="028e6-564">E829</span><span class="sxs-lookup"><span data-stu-id="028e6-564">E829</span></span></td>
  <td><span data-ttu-id="028e6-565">InkingToolFill2</span><span class="sxs-lookup"><span data-stu-id="028e6-565">InkingToolFill2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82A.png" width="32" height="32" alt="HighlightFill2" /></td>
  <td><span data-ttu-id="028e6-566">E82A</span><span class="sxs-lookup"><span data-stu-id="028e6-566">E82A</span></span></td>
  <td><span data-ttu-id="028e6-567">HighlightFill2</span><span class="sxs-lookup"><span data-stu-id="028e6-567">HighlightFill2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82B.png" width="32" height="32" alt="EraseToolFill" /></td>
  <td><span data-ttu-id="028e6-568">E82B</span><span class="sxs-lookup"><span data-stu-id="028e6-568">E82B</span></span></td>
  <td><span data-ttu-id="028e6-569">EraseToolFill</span><span class="sxs-lookup"><span data-stu-id="028e6-569">EraseToolFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82C.png" width="32" height="32" alt="EraseToolFill2" /></td>
  <td><span data-ttu-id="028e6-570">E82C</span><span class="sxs-lookup"><span data-stu-id="028e6-570">E82C</span></span></td>
  <td><span data-ttu-id="028e6-571">EraseToolFill2</span><span class="sxs-lookup"><span data-stu-id="028e6-571">EraseToolFill2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82D.png" width="32" height="32" alt="Dictionary" /></td>
  <td><span data-ttu-id="028e6-572">E82D</span><span class="sxs-lookup"><span data-stu-id="028e6-572">E82D</span></span></td>
  <td><span data-ttu-id="028e6-573">Dictionary</span><span class="sxs-lookup"><span data-stu-id="028e6-573">Dictionary</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82E.png" width="32" height="32" alt="DictionaryAdd" /></td>
  <td><span data-ttu-id="028e6-574">E82E</span><span class="sxs-lookup"><span data-stu-id="028e6-574">E82E</span></span></td>
  <td><span data-ttu-id="028e6-575">DictionaryAdd</span><span class="sxs-lookup"><span data-stu-id="028e6-575">DictionaryAdd</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82F.png" width="32" height="32" alt="ToolTip" /></td>
  <td><span data-ttu-id="028e6-576">E82F</span><span class="sxs-lookup"><span data-stu-id="028e6-576">E82F</span></span></td>
  <td><span data-ttu-id="028e6-577">ToolTip</span><span class="sxs-lookup"><span data-stu-id="028e6-577">ToolTip</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E830.png" width="32" height="32" alt="ChromeBack" /></td>
  <td><span data-ttu-id="028e6-578">E830</span><span class="sxs-lookup"><span data-stu-id="028e6-578">E830</span></span></td>
  <td><span data-ttu-id="028e6-579">ChromeBack</span><span class="sxs-lookup"><span data-stu-id="028e6-579">ChromeBack</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E835.png" width="32" height="32" alt="ProvisioningPackage" /></td>
  <td><span data-ttu-id="028e6-580">E835</span><span class="sxs-lookup"><span data-stu-id="028e6-580">E835</span></span></td>
  <td><span data-ttu-id="028e6-581">ProvisioningPackage</span><span class="sxs-lookup"><span data-stu-id="028e6-581">ProvisioningPackage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E836.png" width="32" height="32" alt="AddRemoteDevice" /></td>
  <td><span data-ttu-id="028e6-582">E836</span><span class="sxs-lookup"><span data-stu-id="028e6-582">E836</span></span></td>
  <td><span data-ttu-id="028e6-583">AddRemoteDevice</span><span class="sxs-lookup"><span data-stu-id="028e6-583">AddRemoteDevice</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E838.png" width="32" height="32" alt="FolderOpen" /></td>
  <td><span data-ttu-id="028e6-584">E838</span><span class="sxs-lookup"><span data-stu-id="028e6-584">E838</span></span></td>
  <td><span data-ttu-id="028e6-585">FolderOpen</span><span class="sxs-lookup"><span data-stu-id="028e6-585">FolderOpen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E839.png" width="32" height="32" alt="Ethernet" /></td>
  <td><span data-ttu-id="028e6-586">E839</span><span class="sxs-lookup"><span data-stu-id="028e6-586">E839</span></span></td>
  <td><span data-ttu-id="028e6-587">Ethernet</span><span class="sxs-lookup"><span data-stu-id="028e6-587">Ethernet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83A.png" width="32" height="32" alt=" ShareBroadband" /></td>
  <td><span data-ttu-id="028e6-588">E83A</span><span class="sxs-lookup"><span data-stu-id="028e6-588">E83A</span></span></td>
  <td> <span data-ttu-id="028e6-589">ShareBroadband</span><span class="sxs-lookup"><span data-stu-id="028e6-589">ShareBroadband</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83B.png" width="32" height="32" alt="DirectAccess" /></td>
  <td><span data-ttu-id="028e6-590">E83B</span><span class="sxs-lookup"><span data-stu-id="028e6-590">E83B</span></span></td>
  <td><span data-ttu-id="028e6-591">DirectAccess</span><span class="sxs-lookup"><span data-stu-id="028e6-591">DirectAccess</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83C.png" width="32" height="32" alt=" DialUp" /></td>
  <td><span data-ttu-id="028e6-592">E83C</span><span class="sxs-lookup"><span data-stu-id="028e6-592">E83C</span></span></td>
  <td> <span data-ttu-id="028e6-593">DialUp</span><span class="sxs-lookup"><span data-stu-id="028e6-593">DialUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83D.png" width="32" height="32" alt="DefenderApp " /></td>
  <td><span data-ttu-id="028e6-594">E83D</span><span class="sxs-lookup"><span data-stu-id="028e6-594">E83D</span></span></td>
  <td><span data-ttu-id="028e6-595">DefenderApp</span><span class="sxs-lookup"><span data-stu-id="028e6-595">DefenderApp</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83E.png" width="32" height="32" alt="BatteryCharging9" /></td>
  <td><span data-ttu-id="028e6-596">E83E</span><span class="sxs-lookup"><span data-stu-id="028e6-596">E83E</span></span></td>
  <td><span data-ttu-id="028e6-597">BatteryCharging9</span><span class="sxs-lookup"><span data-stu-id="028e6-597">BatteryCharging9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83F.png" width="32" height="32" alt="Battery10" /></td>
  <td><span data-ttu-id="028e6-598">E83F</span><span class="sxs-lookup"><span data-stu-id="028e6-598">E83F</span></span></td>
  <td><span data-ttu-id="028e6-599">Battery10</span><span class="sxs-lookup"><span data-stu-id="028e6-599">Battery10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E840.png" width="32" height="32" alt="Pinned" /></td>
  <td><span data-ttu-id="028e6-600">E840</span><span class="sxs-lookup"><span data-stu-id="028e6-600">E840</span></span></td>
  <td><span data-ttu-id="028e6-601">Pinned</span><span class="sxs-lookup"><span data-stu-id="028e6-601">Pinned</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E841.png" width="32" height="32" alt="PinFill" /></td>
  <td><span data-ttu-id="028e6-602">E841</span><span class="sxs-lookup"><span data-stu-id="028e6-602">E841</span></span></td>
  <td><span data-ttu-id="028e6-603">PinFill</span><span class="sxs-lookup"><span data-stu-id="028e6-603">PinFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E842.png" width="32" height="32" alt="PinnedFill" /></td>
  <td><span data-ttu-id="028e6-604">E842</span><span class="sxs-lookup"><span data-stu-id="028e6-604">E842</span></span></td>
  <td><span data-ttu-id="028e6-605">PinnedFill</span><span class="sxs-lookup"><span data-stu-id="028e6-605">PinnedFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E843.png" width="32" height="32" alt="PeriodKey" /></td>
  <td><span data-ttu-id="028e6-606">E843</span><span class="sxs-lookup"><span data-stu-id="028e6-606">E843</span></span></td>
  <td><span data-ttu-id="028e6-607">PeriodKey</span><span class="sxs-lookup"><span data-stu-id="028e6-607">PeriodKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E844.png" width="32" height="32" alt="PuncKey" /></td>
  <td><span data-ttu-id="028e6-608">E844</span><span class="sxs-lookup"><span data-stu-id="028e6-608">E844</span></span></td>
  <td><span data-ttu-id="028e6-609">PuncKey</span><span class="sxs-lookup"><span data-stu-id="028e6-609">PuncKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E845.png" width="32" height="32" alt="RevToggleKey" /></td>
  <td><span data-ttu-id="028e6-610">E845</span><span class="sxs-lookup"><span data-stu-id="028e6-610">E845</span></span></td>
  <td><span data-ttu-id="028e6-611">RevToggleKey</span><span class="sxs-lookup"><span data-stu-id="028e6-611">RevToggleKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E846.png" width="32" height="32" alt="RightArrowKeyTime1" /></td>
  <td><span data-ttu-id="028e6-612">E846</span><span class="sxs-lookup"><span data-stu-id="028e6-612">E846</span></span></td>
  <td><span data-ttu-id="028e6-613">RightArrowKeyTime1</span><span class="sxs-lookup"><span data-stu-id="028e6-613">RightArrowKeyTime1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E847.png" width="32" height="32" alt="RightArrowKeyTime2" /></td>
  <td><span data-ttu-id="028e6-614">E847</span><span class="sxs-lookup"><span data-stu-id="028e6-614">E847</span></span></td>
  <td><span data-ttu-id="028e6-615">RightArrowKeyTime2</span><span class="sxs-lookup"><span data-stu-id="028e6-615">RightArrowKeyTime2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E848.png" width="32" height="32" alt="LeftQuote" /></td>
  <td><span data-ttu-id="028e6-616">E848</span><span class="sxs-lookup"><span data-stu-id="028e6-616">E848</span></span></td>
  <td><span data-ttu-id="028e6-617">LeftQuote</span><span class="sxs-lookup"><span data-stu-id="028e6-617">LeftQuote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E849.png" width="32" height="32" alt="RightQuote" /></td>
  <td><span data-ttu-id="028e6-618">E849</span><span class="sxs-lookup"><span data-stu-id="028e6-618">E849</span></span></td>
  <td><span data-ttu-id="028e6-619">RightQuote</span><span class="sxs-lookup"><span data-stu-id="028e6-619">RightQuote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84A.png" width="32" height="32" alt="DownShiftKey" /></td>
  <td><span data-ttu-id="028e6-620">E84A</span><span class="sxs-lookup"><span data-stu-id="028e6-620">E84A</span></span></td>
  <td><span data-ttu-id="028e6-621">DownShiftKey</span><span class="sxs-lookup"><span data-stu-id="028e6-621">DownShiftKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84B.png" width="32" height="32" alt="UpShiftKey" /></td>
  <td><span data-ttu-id="028e6-622">E84B</span><span class="sxs-lookup"><span data-stu-id="028e6-622">E84B</span></span></td>
  <td><span data-ttu-id="028e6-623">UpShiftKey</span><span class="sxs-lookup"><span data-stu-id="028e6-623">UpShiftKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84C.png" width="32" height="32" alt="PuncKey0" /></td>
  <td><span data-ttu-id="028e6-624">E84C</span><span class="sxs-lookup"><span data-stu-id="028e6-624">E84C</span></span></td>
  <td><span data-ttu-id="028e6-625">PuncKey0</span><span class="sxs-lookup"><span data-stu-id="028e6-625">PuncKey0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84D.png" width="32" height="32" alt="PuncKeyLeftBottom" /></td>
  <td><span data-ttu-id="028e6-626">E84D</span><span class="sxs-lookup"><span data-stu-id="028e6-626">E84D</span></span></td>
  <td><span data-ttu-id="028e6-627">PuncKeyLeftBottom</span><span class="sxs-lookup"><span data-stu-id="028e6-627">PuncKeyLeftBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84E.png" width="32" height="32" alt="RightArrowKeyTime3" /></td>
  <td><span data-ttu-id="028e6-628">E84E</span><span class="sxs-lookup"><span data-stu-id="028e6-628">E84E</span></span></td>
  <td><span data-ttu-id="028e6-629">RightArrowKeyTime3</span><span class="sxs-lookup"><span data-stu-id="028e6-629">RightArrowKeyTime3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84F.png" width="32" height="32" alt="RightArrowKeyTime4" /></td>
  <td><span data-ttu-id="028e6-630">E84F</span><span class="sxs-lookup"><span data-stu-id="028e6-630">E84F</span></span></td>
  <td><span data-ttu-id="028e6-631">RightArrowKeyTime4</span><span class="sxs-lookup"><span data-stu-id="028e6-631">RightArrowKeyTime4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E850.png" width="32" height="32" alt="Battery0" /></td>
  <td><span data-ttu-id="028e6-632">E850</span><span class="sxs-lookup"><span data-stu-id="028e6-632">E850</span></span></td>
  <td><span data-ttu-id="028e6-633">Battery0</span><span class="sxs-lookup"><span data-stu-id="028e6-633">Battery0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E851.png" width="32" height="32" alt="Battery1" /></td>
  <td><span data-ttu-id="028e6-634">E851</span><span class="sxs-lookup"><span data-stu-id="028e6-634">E851</span></span></td>
  <td><span data-ttu-id="028e6-635">Battery1</span><span class="sxs-lookup"><span data-stu-id="028e6-635">Battery1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E852.png" width="32" height="32" alt="Battery2" /></td>
  <td><span data-ttu-id="028e6-636">E852</span><span class="sxs-lookup"><span data-stu-id="028e6-636">E852</span></span></td>
  <td><span data-ttu-id="028e6-637">Battery2</span><span class="sxs-lookup"><span data-stu-id="028e6-637">Battery2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E853.png" width="32" height="32" alt="Battery3" /></td>
  <td><span data-ttu-id="028e6-638">E853</span><span class="sxs-lookup"><span data-stu-id="028e6-638">E853</span></span></td>
  <td><span data-ttu-id="028e6-639">Battery3</span><span class="sxs-lookup"><span data-stu-id="028e6-639">Battery3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E854.png" width="32" height="32" alt="Battery4" /></td>
  <td><span data-ttu-id="028e6-640">E854</span><span class="sxs-lookup"><span data-stu-id="028e6-640">E854</span></span></td>
  <td><span data-ttu-id="028e6-641">Battery4</span><span class="sxs-lookup"><span data-stu-id="028e6-641">Battery4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E855.png" width="32" height="32" alt="Battery5" /></td>
  <td><span data-ttu-id="028e6-642">E855</span><span class="sxs-lookup"><span data-stu-id="028e6-642">E855</span></span></td>
  <td><span data-ttu-id="028e6-643">Battery5</span><span class="sxs-lookup"><span data-stu-id="028e6-643">Battery5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E856.png" width="32" height="32" alt="Battery6" /></td>
  <td><span data-ttu-id="028e6-644">E856</span><span class="sxs-lookup"><span data-stu-id="028e6-644">E856</span></span></td>
  <td><span data-ttu-id="028e6-645">Battery6</span><span class="sxs-lookup"><span data-stu-id="028e6-645">Battery6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E857.png" width="32" height="32" alt="Battery7" /></td>
  <td><span data-ttu-id="028e6-646">E857</span><span class="sxs-lookup"><span data-stu-id="028e6-646">E857</span></span></td>
  <td><span data-ttu-id="028e6-647">Battery7</span><span class="sxs-lookup"><span data-stu-id="028e6-647">Battery7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E858.png" width="32" height="32" alt="Battery8" /></td>
  <td><span data-ttu-id="028e6-648">E858</span><span class="sxs-lookup"><span data-stu-id="028e6-648">E858</span></span></td>
  <td><span data-ttu-id="028e6-649">Battery8</span><span class="sxs-lookup"><span data-stu-id="028e6-649">Battery8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E859.png" width="32" height="32" alt="Battery9" /></td>
  <td><span data-ttu-id="028e6-650">E859</span><span class="sxs-lookup"><span data-stu-id="028e6-650">E859</span></span></td>
  <td><span data-ttu-id="028e6-651">Battery9</span><span class="sxs-lookup"><span data-stu-id="028e6-651">Battery9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85A.png" width="32" height="32" alt="BatteryCharging0" /></td>
  <td><span data-ttu-id="028e6-652">E85A</span><span class="sxs-lookup"><span data-stu-id="028e6-652">E85A</span></span></td>
  <td><span data-ttu-id="028e6-653">BatteryCharging0</span><span class="sxs-lookup"><span data-stu-id="028e6-653">BatteryCharging0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85B.png" width="32" height="32" alt="BatteryCharging1" /></td>
  <td><span data-ttu-id="028e6-654">E85B</span><span class="sxs-lookup"><span data-stu-id="028e6-654">E85B</span></span></td>
  <td><span data-ttu-id="028e6-655">BatteryCharging1</span><span class="sxs-lookup"><span data-stu-id="028e6-655">BatteryCharging1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85C.png" width="32" height="32" alt="BatteryCharging2" /></td>
  <td><span data-ttu-id="028e6-656">E85C</span><span class="sxs-lookup"><span data-stu-id="028e6-656">E85C</span></span></td>
  <td><span data-ttu-id="028e6-657">BatteryCharging2</span><span class="sxs-lookup"><span data-stu-id="028e6-657">BatteryCharging2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85D.png" width="32" height="32" alt="BatteryCharging3" /></td>
  <td><span data-ttu-id="028e6-658">E85D</span><span class="sxs-lookup"><span data-stu-id="028e6-658">E85D</span></span></td>
  <td><span data-ttu-id="028e6-659">BatteryCharging3</span><span class="sxs-lookup"><span data-stu-id="028e6-659">BatteryCharging3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85E.png" width="32" height="32" alt="BatteryCharging4" /></td>
  <td><span data-ttu-id="028e6-660">E85E</span><span class="sxs-lookup"><span data-stu-id="028e6-660">E85E</span></span></td>
  <td><span data-ttu-id="028e6-661">BatteryCharging4</span><span class="sxs-lookup"><span data-stu-id="028e6-661">BatteryCharging4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85F.png" width="32" height="32" alt="BatteryCharging5" /></td>
  <td><span data-ttu-id="028e6-662">E85F</span><span class="sxs-lookup"><span data-stu-id="028e6-662">E85F</span></span></td>
  <td><span data-ttu-id="028e6-663">BatteryCharging5</span><span class="sxs-lookup"><span data-stu-id="028e6-663">BatteryCharging5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E860.png" width="32" height="32" alt="BatteryCharging6" /></td>
  <td><span data-ttu-id="028e6-664">E860</span><span class="sxs-lookup"><span data-stu-id="028e6-664">E860</span></span></td>
  <td><span data-ttu-id="028e6-665">BatteryCharging6</span><span class="sxs-lookup"><span data-stu-id="028e6-665">BatteryCharging6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E861.png" width="32" height="32" alt="BatteryCharging7" /></td>
  <td><span data-ttu-id="028e6-666">E861</span><span class="sxs-lookup"><span data-stu-id="028e6-666">E861</span></span></td>
  <td><span data-ttu-id="028e6-667">BatteryCharging7</span><span class="sxs-lookup"><span data-stu-id="028e6-667">BatteryCharging7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E862.png" width="32" height="32" alt="BatteryCharging8" /></td>
  <td><span data-ttu-id="028e6-668">E862</span><span class="sxs-lookup"><span data-stu-id="028e6-668">E862</span></span></td>
  <td><span data-ttu-id="028e6-669">BatteryCharging8</span><span class="sxs-lookup"><span data-stu-id="028e6-669">BatteryCharging8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E863.png" width="32" height="32" alt="BatterySaver0" /></td>
  <td><span data-ttu-id="028e6-670">E863</span><span class="sxs-lookup"><span data-stu-id="028e6-670">E863</span></span></td>
  <td><span data-ttu-id="028e6-671">BatterySaver0</span><span class="sxs-lookup"><span data-stu-id="028e6-671">BatterySaver0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E864.png" width="32" height="32" alt="BatterySaver1" /></td>
  <td><span data-ttu-id="028e6-672">E864</span><span class="sxs-lookup"><span data-stu-id="028e6-672">E864</span></span></td>
  <td><span data-ttu-id="028e6-673">BatterySaver1</span><span class="sxs-lookup"><span data-stu-id="028e6-673">BatterySaver1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E865.png" width="32" height="32" alt="BatterySaver2" /></td>
  <td><span data-ttu-id="028e6-674">E865</span><span class="sxs-lookup"><span data-stu-id="028e6-674">E865</span></span></td>
  <td><span data-ttu-id="028e6-675">BatterySaver2</span><span class="sxs-lookup"><span data-stu-id="028e6-675">BatterySaver2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E866.png" width="32" height="32" alt="BatterySaver3" /></td>
  <td><span data-ttu-id="028e6-676">E866</span><span class="sxs-lookup"><span data-stu-id="028e6-676">E866</span></span></td>
  <td><span data-ttu-id="028e6-677">BatterySaver3</span><span class="sxs-lookup"><span data-stu-id="028e6-677">BatterySaver3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E867.png" width="32" height="32" alt="BatterySaver4" /></td>
  <td><span data-ttu-id="028e6-678">E867</span><span class="sxs-lookup"><span data-stu-id="028e6-678">E867</span></span></td>
  <td><span data-ttu-id="028e6-679">BatterySaver4</span><span class="sxs-lookup"><span data-stu-id="028e6-679">BatterySaver4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E868.png" width="32" height="32" alt="BatterySaver5" /></td>
  <td><span data-ttu-id="028e6-680">E868</span><span class="sxs-lookup"><span data-stu-id="028e6-680">E868</span></span></td>
  <td><span data-ttu-id="028e6-681">BatterySaver5</span><span class="sxs-lookup"><span data-stu-id="028e6-681">BatterySaver5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E869.png" width="32" height="32" alt="BatterySaver6" /></td>
  <td><span data-ttu-id="028e6-682">E869</span><span class="sxs-lookup"><span data-stu-id="028e6-682">E869</span></span></td>
  <td><span data-ttu-id="028e6-683">BatterySaver6</span><span class="sxs-lookup"><span data-stu-id="028e6-683">BatterySaver6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86A.png" width="32" height="32" alt="BatterySaver7" /></td>
  <td><span data-ttu-id="028e6-684">E86A</span><span class="sxs-lookup"><span data-stu-id="028e6-684">E86A</span></span></td>
  <td><span data-ttu-id="028e6-685">BatterySaver7</span><span class="sxs-lookup"><span data-stu-id="028e6-685">BatterySaver7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86B.png" width="32" height="32" alt="BatterySaver8" /></td>
  <td><span data-ttu-id="028e6-686">E86B</span><span class="sxs-lookup"><span data-stu-id="028e6-686">E86B</span></span></td>
  <td><span data-ttu-id="028e6-687">BatterySaver8</span><span class="sxs-lookup"><span data-stu-id="028e6-687">BatterySaver8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86C.png" width="32" height="32" alt="SignalBars1" /></td>
  <td><span data-ttu-id="028e6-688">E86C</span><span class="sxs-lookup"><span data-stu-id="028e6-688">E86C</span></span></td>
  <td><span data-ttu-id="028e6-689">SignalBars1</span><span class="sxs-lookup"><span data-stu-id="028e6-689">SignalBars1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86D.png" width="32" height="32" alt="SignalBars2" /></td>
  <td><span data-ttu-id="028e6-690">E86D</span><span class="sxs-lookup"><span data-stu-id="028e6-690">E86D</span></span></td>
  <td><span data-ttu-id="028e6-691">SignalBars2</span><span class="sxs-lookup"><span data-stu-id="028e6-691">SignalBars2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86E.png" width="32" height="32" alt="SignalBars3" /></td>
  <td><span data-ttu-id="028e6-692">E86E</span><span class="sxs-lookup"><span data-stu-id="028e6-692">E86E</span></span></td>
  <td><span data-ttu-id="028e6-693">SignalBars3</span><span class="sxs-lookup"><span data-stu-id="028e6-693">SignalBars3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86F.png" width="32" height="32" alt="SignalBars4" /></td>
  <td><span data-ttu-id="028e6-694">E86F</span><span class="sxs-lookup"><span data-stu-id="028e6-694">E86F</span></span></td>
  <td><span data-ttu-id="028e6-695">SignalBars4</span><span class="sxs-lookup"><span data-stu-id="028e6-695">SignalBars4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E870.png" width="32" height="32" alt="SignalBars5" /></td>
  <td><span data-ttu-id="028e6-696">E870</span><span class="sxs-lookup"><span data-stu-id="028e6-696">E870</span></span></td>
  <td><span data-ttu-id="028e6-697">SignalBars5</span><span class="sxs-lookup"><span data-stu-id="028e6-697">SignalBars5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E871.png" width="32" height="32" alt="SignalNotConnected" /></td>
  <td><span data-ttu-id="028e6-698">E871</span><span class="sxs-lookup"><span data-stu-id="028e6-698">E871</span></span></td>
  <td><span data-ttu-id="028e6-699">SignalNotConnected</span><span class="sxs-lookup"><span data-stu-id="028e6-699">SignalNotConnected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E872.png" width="32" height="32" alt="Wifi1" /></td>
  <td><span data-ttu-id="028e6-700">E872</span><span class="sxs-lookup"><span data-stu-id="028e6-700">E872</span></span></td>
  <td><span data-ttu-id="028e6-701">Wifi1</span><span class="sxs-lookup"><span data-stu-id="028e6-701">Wifi1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E873.png" width="32" height="32" alt="Wifi2" /></td>
  <td><span data-ttu-id="028e6-702">E873</span><span class="sxs-lookup"><span data-stu-id="028e6-702">E873</span></span></td>
  <td><span data-ttu-id="028e6-703">Wifi2</span><span class="sxs-lookup"><span data-stu-id="028e6-703">Wifi2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E874.png" width="32" height="32" alt="Wifi3" /></td>
  <td><span data-ttu-id="028e6-704">E874</span><span class="sxs-lookup"><span data-stu-id="028e6-704">E874</span></span></td>
  <td><span data-ttu-id="028e6-705">Wifi3</span><span class="sxs-lookup"><span data-stu-id="028e6-705">Wifi3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E875.png" width="32" height="32" alt="MobSIMLock" /></td>
  <td><span data-ttu-id="028e6-706">E875</span><span class="sxs-lookup"><span data-stu-id="028e6-706">E875</span></span></td>
  <td><span data-ttu-id="028e6-707">MobSIMLock</span><span class="sxs-lookup"><span data-stu-id="028e6-707">MobSIMLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E876.png" width="32" height="32" alt="MobSIMMissing" /></td>
  <td><span data-ttu-id="028e6-708">E876</span><span class="sxs-lookup"><span data-stu-id="028e6-708">E876</span></span></td>
  <td><span data-ttu-id="028e6-709">MobSIMMissing</span><span class="sxs-lookup"><span data-stu-id="028e6-709">MobSIMMissing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E877.png" width="32" height="32" alt="Vibrate" /></td>
  <td><span data-ttu-id="028e6-710">E877</span><span class="sxs-lookup"><span data-stu-id="028e6-710">E877</span></span></td>
  <td><span data-ttu-id="028e6-711">Vibrate</span><span class="sxs-lookup"><span data-stu-id="028e6-711">Vibrate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E878.png" width="32" height="32" alt="RoamingInternational" /></td>
  <td><span data-ttu-id="028e6-712">E878</span><span class="sxs-lookup"><span data-stu-id="028e6-712">E878</span></span></td>
  <td><span data-ttu-id="028e6-713">RoamingInternational</span><span class="sxs-lookup"><span data-stu-id="028e6-713">RoamingInternational</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E879.png" width="32" height="32" alt="RoamingDomestic" /></td>
  <td><span data-ttu-id="028e6-714">E879</span><span class="sxs-lookup"><span data-stu-id="028e6-714">E879</span></span></td>
  <td><span data-ttu-id="028e6-715">RoamingDomestic</span><span class="sxs-lookup"><span data-stu-id="028e6-715">RoamingDomestic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87A.png" width="32" height="32" alt="CallForwardInternational" /></td>
  <td><span data-ttu-id="028e6-716">E87A</span><span class="sxs-lookup"><span data-stu-id="028e6-716">E87A</span></span></td>
  <td><span data-ttu-id="028e6-717">CallForwardInternational</span><span class="sxs-lookup"><span data-stu-id="028e6-717">CallForwardInternational</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87B.png" width="32" height="32" alt="CallForwardRoaming" /></td>
  <td><span data-ttu-id="028e6-718">E87B</span><span class="sxs-lookup"><span data-stu-id="028e6-718">E87B</span></span></td>
  <td><span data-ttu-id="028e6-719">CallForwardRoaming</span><span class="sxs-lookup"><span data-stu-id="028e6-719">CallForwardRoaming</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87C.png" width="32" height="32" alt="JpnRomanji" /></td>
  <td><span data-ttu-id="028e6-720">E87C</span><span class="sxs-lookup"><span data-stu-id="028e6-720">E87C</span></span></td>
  <td><span data-ttu-id="028e6-721">JpnRomanji</span><span class="sxs-lookup"><span data-stu-id="028e6-721">JpnRomanji</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87D.png" width="32" height="32" alt="JpnRomanjiLock" /></td>
  <td><span data-ttu-id="028e6-722">E87D</span><span class="sxs-lookup"><span data-stu-id="028e6-722">E87D</span></span></td>
  <td><span data-ttu-id="028e6-723">JpnRomanjiLock</span><span class="sxs-lookup"><span data-stu-id="028e6-723">JpnRomanjiLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87E.png" width="32" height="32" alt="JpnRomanjiShift" /></td>
  <td><span data-ttu-id="028e6-724">E87E</span><span class="sxs-lookup"><span data-stu-id="028e6-724">E87E</span></span></td>
  <td><span data-ttu-id="028e6-725">JpnRomanjiShift</span><span class="sxs-lookup"><span data-stu-id="028e6-725">JpnRomanjiShift</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87F.png" width="32" height="32" alt="JpnRomanjiShiftLock" /></td>
  <td><span data-ttu-id="028e6-726">E87F</span><span class="sxs-lookup"><span data-stu-id="028e6-726">E87F</span></span></td>
  <td><span data-ttu-id="028e6-727">JpnRomanjiShiftLock</span><span class="sxs-lookup"><span data-stu-id="028e6-727">JpnRomanjiShiftLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E880.png" width="32" height="32" alt="StatusDataTransfer" /></td>
  <td><span data-ttu-id="028e6-728">E880</span><span class="sxs-lookup"><span data-stu-id="028e6-728">E880</span></span></td>
  <td><span data-ttu-id="028e6-729">StatusDataTransfer</span><span class="sxs-lookup"><span data-stu-id="028e6-729">StatusDataTransfer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E881.png" width="32" height="32" alt="StatusDataTransferVPN" /></td>
  <td><span data-ttu-id="028e6-730">E881</span><span class="sxs-lookup"><span data-stu-id="028e6-730">E881</span></span></td>
  <td><span data-ttu-id="028e6-731">StatusDataTransferVPN</span><span class="sxs-lookup"><span data-stu-id="028e6-731">StatusDataTransferVPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E882.png" width="32" height="32" alt="StatusDualSIM2" /></td>
  <td><span data-ttu-id="028e6-732">E882</span><span class="sxs-lookup"><span data-stu-id="028e6-732">E882</span></span></td>
  <td><span data-ttu-id="028e6-733">StatusDualSIM2</span><span class="sxs-lookup"><span data-stu-id="028e6-733">StatusDualSIM2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E883.png" width="32" height="32" alt="StatusDualSIM2VPN" /></td>
  <td><span data-ttu-id="028e6-734">E883</span><span class="sxs-lookup"><span data-stu-id="028e6-734">E883</span></span></td>
  <td><span data-ttu-id="028e6-735">StatusDualSIM2VPN</span><span class="sxs-lookup"><span data-stu-id="028e6-735">StatusDualSIM2VPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E884.png" width="32" height="32" alt="StatusDualSIM1" /></td>
  <td><span data-ttu-id="028e6-736">E884</span><span class="sxs-lookup"><span data-stu-id="028e6-736">E884</span></span></td>
  <td><span data-ttu-id="028e6-737">StatusDualSIM1</span><span class="sxs-lookup"><span data-stu-id="028e6-737">StatusDualSIM1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E885.png" width="32" height="32" alt="StatusDualSIM1VPN" /></td>
  <td><span data-ttu-id="028e6-738">E885</span><span class="sxs-lookup"><span data-stu-id="028e6-738">E885</span></span></td>
  <td><span data-ttu-id="028e6-739">StatusDualSIM1VPN</span><span class="sxs-lookup"><span data-stu-id="028e6-739">StatusDualSIM1VPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E886.png" width="32" height="32" alt="StatusSGLTE" /></td>
  <td><span data-ttu-id="028e6-740">E886</span><span class="sxs-lookup"><span data-stu-id="028e6-740">E886</span></span></td>
  <td><span data-ttu-id="028e6-741">StatusSGLTE</span><span class="sxs-lookup"><span data-stu-id="028e6-741">StatusSGLTE</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E887.png" width="32" height="32" alt="StatusSGLTECell" /></td>
  <td><span data-ttu-id="028e6-742">E887</span><span class="sxs-lookup"><span data-stu-id="028e6-742">E887</span></span></td>
  <td><span data-ttu-id="028e6-743">StatusSGLTECell</span><span class="sxs-lookup"><span data-stu-id="028e6-743">StatusSGLTECell</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E888.png" width="32" height="32" alt="StatusSGLTEDataVPN" /></td>
  <td><span data-ttu-id="028e6-744">E888</span><span class="sxs-lookup"><span data-stu-id="028e6-744">E888</span></span></td>
  <td><span data-ttu-id="028e6-745">StatusSGLTEDataVPN</span><span class="sxs-lookup"><span data-stu-id="028e6-745">StatusSGLTEDataVPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E889.png" width="32" height="32" alt="StatusVPN" /></td>
  <td><span data-ttu-id="028e6-746">E889</span><span class="sxs-lookup"><span data-stu-id="028e6-746">E889</span></span></td>
  <td><span data-ttu-id="028e6-747">StatusVPN</span><span class="sxs-lookup"><span data-stu-id="028e6-747">StatusVPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88A.png" width="32" height="32" alt="WifiHotspot" /></td>
  <td><span data-ttu-id="028e6-748">E88A</span><span class="sxs-lookup"><span data-stu-id="028e6-748">E88A</span></span></td>
  <td><span data-ttu-id="028e6-749">WifiHotspot</span><span class="sxs-lookup"><span data-stu-id="028e6-749">WifiHotspot</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88B.png" width="32" height="32" alt="LanguageKor" /></td>
  <td><span data-ttu-id="028e6-750">E88B</span><span class="sxs-lookup"><span data-stu-id="028e6-750">E88B</span></span></td>
  <td><span data-ttu-id="028e6-751">LanguageKor</span><span class="sxs-lookup"><span data-stu-id="028e6-751">LanguageKor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88C.png" width="32" height="32" alt="LanguageCht" /></td>
  <td><span data-ttu-id="028e6-752">E88C</span><span class="sxs-lookup"><span data-stu-id="028e6-752">E88C</span></span></td>
  <td><span data-ttu-id="028e6-753">LanguageCht</span><span class="sxs-lookup"><span data-stu-id="028e6-753">LanguageCht</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88D.png" width="32" height="32" alt="LanguageChs" /></td>
  <td><span data-ttu-id="028e6-754">E88D</span><span class="sxs-lookup"><span data-stu-id="028e6-754">E88D</span></span></td>
  <td><span data-ttu-id="028e6-755">LanguageChs</span><span class="sxs-lookup"><span data-stu-id="028e6-755">LanguageChs</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88E.png" width="32" height="32" alt="USB" /></td>
  <td><span data-ttu-id="028e6-756">E88E</span><span class="sxs-lookup"><span data-stu-id="028e6-756">E88E</span></span></td>
  <td><span data-ttu-id="028e6-757">USB</span><span class="sxs-lookup"><span data-stu-id="028e6-757">USB</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88F.png" width="32" height="32" alt="InkingToolFill" /></td>
  <td><span data-ttu-id="028e6-758">E88F</span><span class="sxs-lookup"><span data-stu-id="028e6-758">E88F</span></span></td>
  <td><span data-ttu-id="028e6-759">InkingToolFill</span><span class="sxs-lookup"><span data-stu-id="028e6-759">InkingToolFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E890.png" width="32" height="32" alt="View" /></td>
  <td><span data-ttu-id="028e6-760">E890</span><span class="sxs-lookup"><span data-stu-id="028e6-760">E890</span></span></td>
  <td><span data-ttu-id="028e6-761">View</span><span class="sxs-lookup"><span data-stu-id="028e6-761">View</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E891.png" width="32" height="32" alt="HighlightFill" /></td>
  <td><span data-ttu-id="028e6-762">E891</span><span class="sxs-lookup"><span data-stu-id="028e6-762">E891</span></span></td>
  <td><span data-ttu-id="028e6-763">HighlightFill</span><span class="sxs-lookup"><span data-stu-id="028e6-763">HighlightFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E892.png" width="32" height="32" alt="Previous" /></td>
  <td><span data-ttu-id="028e6-764">E892</span><span class="sxs-lookup"><span data-stu-id="028e6-764">E892</span></span></td>
  <td><span data-ttu-id="028e6-765">Previous</span><span class="sxs-lookup"><span data-stu-id="028e6-765">Previous</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E893.png" width="32" height="32" alt="Next" /></td>
  <td><span data-ttu-id="028e6-766">E893</span><span class="sxs-lookup"><span data-stu-id="028e6-766">E893</span></span></td>
  <td><span data-ttu-id="028e6-767">Next</span><span class="sxs-lookup"><span data-stu-id="028e6-767">Next</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E894.png" width="32" height="32" alt="Clear" /></td>
  <td><span data-ttu-id="028e6-768">E894</span><span class="sxs-lookup"><span data-stu-id="028e6-768">E894</span></span></td>
  <td><span data-ttu-id="028e6-769">Clear</span><span class="sxs-lookup"><span data-stu-id="028e6-769">Clear</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E895.png" width="32" height="32" alt="Sync" /></td>
  <td><span data-ttu-id="028e6-770">E895</span><span class="sxs-lookup"><span data-stu-id="028e6-770">E895</span></span></td>
  <td><span data-ttu-id="028e6-771">Sync</span><span class="sxs-lookup"><span data-stu-id="028e6-771">Sync</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E896.png" width="32" height="32" alt="Download" /></td>
  <td><span data-ttu-id="028e6-772">E896</span><span class="sxs-lookup"><span data-stu-id="028e6-772">E896</span></span></td>
  <td><span data-ttu-id="028e6-773">Download</span><span class="sxs-lookup"><span data-stu-id="028e6-773">Download</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E897.png" width="32" height="32" alt="Help" /></td>
  <td><span data-ttu-id="028e6-774">E897</span><span class="sxs-lookup"><span data-stu-id="028e6-774">E897</span></span></td>
  <td><span data-ttu-id="028e6-775">Help</span><span class="sxs-lookup"><span data-stu-id="028e6-775">Help</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E898.png" width="32" height="32" alt="Upload" /></td>
  <td><span data-ttu-id="028e6-776">E898</span><span class="sxs-lookup"><span data-stu-id="028e6-776">E898</span></span></td>
  <td><span data-ttu-id="028e6-777">Upload</span><span class="sxs-lookup"><span data-stu-id="028e6-777">Upload</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E899.png" width="32" height="32" alt="Emoji" /></td>
  <td><span data-ttu-id="028e6-778">E899</span><span class="sxs-lookup"><span data-stu-id="028e6-778">E899</span></span></td>
  <td><span data-ttu-id="028e6-779">Emoji</span><span class="sxs-lookup"><span data-stu-id="028e6-779">Emoji</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89A.png" width="32" height="32" alt="TwoPage" /></td>
  <td><span data-ttu-id="028e6-780">E89A</span><span class="sxs-lookup"><span data-stu-id="028e6-780">E89A</span></span></td>
  <td><span data-ttu-id="028e6-781">TwoPage</span><span class="sxs-lookup"><span data-stu-id="028e6-781">TwoPage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89B.png" width="32" height="32" alt="LeaveChat" /></td>
  <td><span data-ttu-id="028e6-782">E89B</span><span class="sxs-lookup"><span data-stu-id="028e6-782">E89B</span></span></td>
  <td><span data-ttu-id="028e6-783">LeaveChat</span><span class="sxs-lookup"><span data-stu-id="028e6-783">LeaveChat</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89C.png" width="32" height="32" alt="MailForward" /></td>
  <td><span data-ttu-id="028e6-784">E89C</span><span class="sxs-lookup"><span data-stu-id="028e6-784">E89C</span></span></td>
  <td><span data-ttu-id="028e6-785">MailForward</span><span class="sxs-lookup"><span data-stu-id="028e6-785">MailForward</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89E.png" width="32" height="32" alt="RotateCamera" /></td>
  <td><span data-ttu-id="028e6-786">E89E</span><span class="sxs-lookup"><span data-stu-id="028e6-786">E89E</span></span></td>
  <td><span data-ttu-id="028e6-787">RotateCamera</span><span class="sxs-lookup"><span data-stu-id="028e6-787">RotateCamera</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89F.png" width="32" height="32" alt="ClosePane" /></td>
  <td><span data-ttu-id="028e6-788">E89F</span><span class="sxs-lookup"><span data-stu-id="028e6-788">E89F</span></span></td>
  <td><span data-ttu-id="028e6-789">ClosePane</span><span class="sxs-lookup"><span data-stu-id="028e6-789">ClosePane</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A0.png" width="32" height="32" alt="OpenPane" /></td>
  <td><span data-ttu-id="028e6-790">E8A0</span><span class="sxs-lookup"><span data-stu-id="028e6-790">E8A0</span></span></td>
  <td><span data-ttu-id="028e6-791">OpenPane</span><span class="sxs-lookup"><span data-stu-id="028e6-791">OpenPane</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A1.png" width="32" height="32" alt="PreviewLink" /></td>
  <td><span data-ttu-id="028e6-792">E8A1</span><span class="sxs-lookup"><span data-stu-id="028e6-792">E8A1</span></span></td>
  <td><span data-ttu-id="028e6-793">PreviewLink</span><span class="sxs-lookup"><span data-stu-id="028e6-793">PreviewLink</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A2.png" width="32" height="32" alt="AttachCamera" /></td>
  <td><span data-ttu-id="028e6-794">E8A2</span><span class="sxs-lookup"><span data-stu-id="028e6-794">E8A2</span></span></td>
  <td><span data-ttu-id="028e6-795">AttachCamera</span><span class="sxs-lookup"><span data-stu-id="028e6-795">AttachCamera</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A3.png" width="32" height="32" alt="ZoomIn" /></td>
  <td><span data-ttu-id="028e6-796">E8A3</span><span class="sxs-lookup"><span data-stu-id="028e6-796">E8A3</span></span></td>
  <td><span data-ttu-id="028e6-797">ZoomIn</span><span class="sxs-lookup"><span data-stu-id="028e6-797">ZoomIn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A4.png" width="32" height="32" alt="Bookmarks" /></td>
  <td><span data-ttu-id="028e6-798">E8A4</span><span class="sxs-lookup"><span data-stu-id="028e6-798">E8A4</span></span></td>
  <td><span data-ttu-id="028e6-799">Bookmarks</span><span class="sxs-lookup"><span data-stu-id="028e6-799">Bookmarks</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A5.png" width="32" height="32" alt="Document" /></td>
  <td><span data-ttu-id="028e6-800">E8A5</span><span class="sxs-lookup"><span data-stu-id="028e6-800">E8A5</span></span></td>
  <td><span data-ttu-id="028e6-801">Document</span><span class="sxs-lookup"><span data-stu-id="028e6-801">Document</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A6.png" width="32" height="32" alt="ProtectedDocument" /></td>
  <td><span data-ttu-id="028e6-802">E8A6</span><span class="sxs-lookup"><span data-stu-id="028e6-802">E8A6</span></span></td>
  <td><span data-ttu-id="028e6-803">ProtectedDocument</span><span class="sxs-lookup"><span data-stu-id="028e6-803">ProtectedDocument</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A7.png" width="32" height="32" alt="OpenInNewWindow" /></td>
  <td><span data-ttu-id="028e6-804">E8A7</span><span class="sxs-lookup"><span data-stu-id="028e6-804">E8A7</span></span></td>
  <td><span data-ttu-id="028e6-805">OpenInNewWindow</span><span class="sxs-lookup"><span data-stu-id="028e6-805">OpenInNewWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A8.png" width="32" height="32" alt="MailFill" /></td>
  <td><span data-ttu-id="028e6-806">E8A8</span><span class="sxs-lookup"><span data-stu-id="028e6-806">E8A8</span></span></td>
  <td><span data-ttu-id="028e6-807">MailFill</span><span class="sxs-lookup"><span data-stu-id="028e6-807">MailFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A9.png" width="32" height="32" alt="ViewAll" /></td>
  <td><span data-ttu-id="028e6-808">E8A9</span><span class="sxs-lookup"><span data-stu-id="028e6-808">E8A9</span></span></td>
  <td><span data-ttu-id="028e6-809">ViewAll</span><span class="sxs-lookup"><span data-stu-id="028e6-809">ViewAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AA.png" width="32" height="32" alt="VideoChat" /></td>
  <td><span data-ttu-id="028e6-810">E8AA</span><span class="sxs-lookup"><span data-stu-id="028e6-810">E8AA</span></span></td>
  <td><span data-ttu-id="028e6-811">VideoChat</span><span class="sxs-lookup"><span data-stu-id="028e6-811">VideoChat</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AB.png" width="32" height="32" alt="Switch" /></td>
  <td><span data-ttu-id="028e6-812">E8AB</span><span class="sxs-lookup"><span data-stu-id="028e6-812">E8AB</span></span></td>
  <td><span data-ttu-id="028e6-813">Switch</span><span class="sxs-lookup"><span data-stu-id="028e6-813">Switch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AC.png" width="32" height="32" alt="Rename" /></td>
  <td><span data-ttu-id="028e6-814">E8AC</span><span class="sxs-lookup"><span data-stu-id="028e6-814">E8AC</span></span></td>
  <td><span data-ttu-id="028e6-815">Rename</span><span class="sxs-lookup"><span data-stu-id="028e6-815">Rename</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AD.png" width="32" height="32" alt="Go" /></td>
  <td><span data-ttu-id="028e6-816">E8AD</span><span class="sxs-lookup"><span data-stu-id="028e6-816">E8AD</span></span></td>
  <td><span data-ttu-id="028e6-817">Go</span><span class="sxs-lookup"><span data-stu-id="028e6-817">Go</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AE.png" width="32" height="32" alt="SurfaceHub" /></td>
  <td><span data-ttu-id="028e6-818">E8AE</span><span class="sxs-lookup"><span data-stu-id="028e6-818">E8AE</span></span></td>
  <td><span data-ttu-id="028e6-819">SurfaceHub</span><span class="sxs-lookup"><span data-stu-id="028e6-819">SurfaceHub</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AF.png" width="32" height="32" alt="Remote" /></td>
  <td><span data-ttu-id="028e6-820">E8AF</span><span class="sxs-lookup"><span data-stu-id="028e6-820">E8AF</span></span></td>
  <td><span data-ttu-id="028e6-821">Remote</span><span class="sxs-lookup"><span data-stu-id="028e6-821">Remote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B0.png" width="32" height="32" alt="Click" /></td>
  <td><span data-ttu-id="028e6-822">E8B0</span><span class="sxs-lookup"><span data-stu-id="028e6-822">E8B0</span></span></td>
  <td><span data-ttu-id="028e6-823">Click</span><span class="sxs-lookup"><span data-stu-id="028e6-823">Click</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B1.png" width="32" height="32" alt="Shuffle" /></td>
  <td><span data-ttu-id="028e6-824">E8B1</span><span class="sxs-lookup"><span data-stu-id="028e6-824">E8B1</span></span></td>
  <td><span data-ttu-id="028e6-825">Shuffle</span><span class="sxs-lookup"><span data-stu-id="028e6-825">Shuffle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B2.png" width="32" height="32" alt="Movies" /></td>
  <td><span data-ttu-id="028e6-826">E8B2</span><span class="sxs-lookup"><span data-stu-id="028e6-826">E8B2</span></span></td>
  <td><span data-ttu-id="028e6-827">Movies</span><span class="sxs-lookup"><span data-stu-id="028e6-827">Movies</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B3.png" width="32" height="32" alt="SelectAll" /></td>
  <td><span data-ttu-id="028e6-828">E8B3</span><span class="sxs-lookup"><span data-stu-id="028e6-828">E8B3</span></span></td>
  <td><span data-ttu-id="028e6-829">SelectAll</span><span class="sxs-lookup"><span data-stu-id="028e6-829">SelectAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B4.png" width="32" height="32" alt="Orientation" /></td>
  <td><span data-ttu-id="028e6-830">E8B4</span><span class="sxs-lookup"><span data-stu-id="028e6-830">E8B4</span></span></td>
  <td><span data-ttu-id="028e6-831">Orientation</span><span class="sxs-lookup"><span data-stu-id="028e6-831">Orientation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B5.png" width="32" height="32" alt="Import" /></td>
  <td><span data-ttu-id="028e6-832">E8B5</span><span class="sxs-lookup"><span data-stu-id="028e6-832">E8B5</span></span></td>
  <td><span data-ttu-id="028e6-833">Import</span><span class="sxs-lookup"><span data-stu-id="028e6-833">Import</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B6.png" width="32" height="32" alt="ImportAll" /></td>
  <td><span data-ttu-id="028e6-834">E8B6</span><span class="sxs-lookup"><span data-stu-id="028e6-834">E8B6</span></span></td>
  <td><span data-ttu-id="028e6-835">ImportAll</span><span class="sxs-lookup"><span data-stu-id="028e6-835">ImportAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B7.png" width="32" height="32" alt="Folder" /></td>
  <td><span data-ttu-id="028e6-836">E8B7</span><span class="sxs-lookup"><span data-stu-id="028e6-836">E8B7</span></span></td>
  <td><span data-ttu-id="028e6-837">Folder</span><span class="sxs-lookup"><span data-stu-id="028e6-837">Folder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B8.png" width="32" height="32" alt="Webcam" /></td>
  <td><span data-ttu-id="028e6-838">E8B8</span><span class="sxs-lookup"><span data-stu-id="028e6-838">E8B8</span></span></td>
  <td><span data-ttu-id="028e6-839">Webcam</span><span class="sxs-lookup"><span data-stu-id="028e6-839">Webcam</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B9.png" width="32" height="32" alt="Picture" /></td>
  <td><span data-ttu-id="028e6-840">E8B9</span><span class="sxs-lookup"><span data-stu-id="028e6-840">E8B9</span></span></td>
  <td><span data-ttu-id="028e6-841">Picture</span><span class="sxs-lookup"><span data-stu-id="028e6-841">Picture</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BA.png" width="32" height="32" alt="Caption" /></td>
  <td><span data-ttu-id="028e6-842">E8BA</span><span class="sxs-lookup"><span data-stu-id="028e6-842">E8BA</span></span></td>
  <td><span data-ttu-id="028e6-843">Caption</span><span class="sxs-lookup"><span data-stu-id="028e6-843">Caption</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BB.png" width="32" height="32" alt="ChromeClose" /></td>
  <td><span data-ttu-id="028e6-844">E8BB</span><span class="sxs-lookup"><span data-stu-id="028e6-844">E8BB</span></span></td>
  <td><span data-ttu-id="028e6-845">ChromeClose</span><span class="sxs-lookup"><span data-stu-id="028e6-845">ChromeClose</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BC.png" width="32" height="32" alt="ShowResults" /></td>
  <td><span data-ttu-id="028e6-846">E8BC</span><span class="sxs-lookup"><span data-stu-id="028e6-846">E8BC</span></span></td>
  <td><span data-ttu-id="028e6-847">ShowResults</span><span class="sxs-lookup"><span data-stu-id="028e6-847">ShowResults</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BD.png" width="32" height="32" alt="Message" /></td>
  <td><span data-ttu-id="028e6-848">E8BD</span><span class="sxs-lookup"><span data-stu-id="028e6-848">E8BD</span></span></td>
  <td><span data-ttu-id="028e6-849">Message</span><span class="sxs-lookup"><span data-stu-id="028e6-849">Message</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BE.png" width="32" height="32" alt="Leaf" /></td>
  <td><span data-ttu-id="028e6-850">E8BE</span><span class="sxs-lookup"><span data-stu-id="028e6-850">E8BE</span></span></td>
  <td><span data-ttu-id="028e6-851">Leaf</span><span class="sxs-lookup"><span data-stu-id="028e6-851">Leaf</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BF.png" width="32" height="32" alt="CalendarDay" /></td>
  <td><span data-ttu-id="028e6-852">E8BF</span><span class="sxs-lookup"><span data-stu-id="028e6-852">E8BF</span></span></td>
  <td><span data-ttu-id="028e6-853">CalendarDay</span><span class="sxs-lookup"><span data-stu-id="028e6-853">CalendarDay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C0.png" width="32" height="32" alt="CalendarWeek" /></td>
  <td><span data-ttu-id="028e6-854">E8C0</span><span class="sxs-lookup"><span data-stu-id="028e6-854">E8C0</span></span></td>
  <td><span data-ttu-id="028e6-855">CalendarWeek</span><span class="sxs-lookup"><span data-stu-id="028e6-855">CalendarWeek</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C1.png" width="32" height="32" alt="Characters" /></td>
  <td><span data-ttu-id="028e6-856">E8C1</span><span class="sxs-lookup"><span data-stu-id="028e6-856">E8C1</span></span></td>
  <td><span data-ttu-id="028e6-857">Characters</span><span class="sxs-lookup"><span data-stu-id="028e6-857">Characters</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C2.png" width="32" height="32" alt="MailReplyAll" /></td>
  <td><span data-ttu-id="028e6-858">E8C2</span><span class="sxs-lookup"><span data-stu-id="028e6-858">E8C2</span></span></td>
  <td><span data-ttu-id="028e6-859">MailReplyAll</span><span class="sxs-lookup"><span data-stu-id="028e6-859">MailReplyAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C3.png" width="32" height="32" alt="Read" /></td>
  <td><span data-ttu-id="028e6-860">E8C3</span><span class="sxs-lookup"><span data-stu-id="028e6-860">E8C3</span></span></td>
  <td><span data-ttu-id="028e6-861">Read</span><span class="sxs-lookup"><span data-stu-id="028e6-861">Read</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C4.png" width="32" height="32" alt="ShowBcc" /></td>
  <td><span data-ttu-id="028e6-862">E8C4</span><span class="sxs-lookup"><span data-stu-id="028e6-862">E8C4</span></span></td>
  <td><span data-ttu-id="028e6-863">ShowBcc</span><span class="sxs-lookup"><span data-stu-id="028e6-863">ShowBcc</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C5.png" width="32" height="32" alt="HideBcc" /></td>
  <td><span data-ttu-id="028e6-864">E8C5</span><span class="sxs-lookup"><span data-stu-id="028e6-864">E8C5</span></span></td>
  <td><span data-ttu-id="028e6-865">HideBcc</span><span class="sxs-lookup"><span data-stu-id="028e6-865">HideBcc</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C6.png" width="32" height="32" alt="Cut" /></td>
  <td><span data-ttu-id="028e6-866">E8C6</span><span class="sxs-lookup"><span data-stu-id="028e6-866">E8C6</span></span></td>
  <td><span data-ttu-id="028e6-867">Cut</span><span class="sxs-lookup"><span data-stu-id="028e6-867">Cut</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C7.png" width="32" height="32" alt="PaymentCard" /></td>
  <td><span data-ttu-id="028e6-868">E8C7</span><span class="sxs-lookup"><span data-stu-id="028e6-868">E8C7</span></span></td>
  <td><span data-ttu-id="028e6-869">PaymentCard</span><span class="sxs-lookup"><span data-stu-id="028e6-869">PaymentCard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C8.png" width="32" height="32" alt="Copy" /></td>
  <td><span data-ttu-id="028e6-870">E8C8</span><span class="sxs-lookup"><span data-stu-id="028e6-870">E8C8</span></span></td>
  <td><span data-ttu-id="028e6-871">Copy</span><span class="sxs-lookup"><span data-stu-id="028e6-871">Copy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C9.png" width="32" height="32" alt="Important" /></td>
  <td><span data-ttu-id="028e6-872">E8C9</span><span class="sxs-lookup"><span data-stu-id="028e6-872">E8C9</span></span></td>
  <td><span data-ttu-id="028e6-873">Important</span><span class="sxs-lookup"><span data-stu-id="028e6-873">Important</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CA.png" width="32" height="32" alt="MailReply" /></td>
  <td><span data-ttu-id="028e6-874">E8CA</span><span class="sxs-lookup"><span data-stu-id="028e6-874">E8CA</span></span></td>
  <td><span data-ttu-id="028e6-875">MailReply</span><span class="sxs-lookup"><span data-stu-id="028e6-875">MailReply</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CB.png" width="32" height="32" alt="Sort" /></td>
  <td><span data-ttu-id="028e6-876">E8CB</span><span class="sxs-lookup"><span data-stu-id="028e6-876">E8CB</span></span></td>
  <td><span data-ttu-id="028e6-877">Sort</span><span class="sxs-lookup"><span data-stu-id="028e6-877">Sort</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CC.png" width="32" height="32" alt="MobileTablet" /></td>
  <td><span data-ttu-id="028e6-878">E8CC</span><span class="sxs-lookup"><span data-stu-id="028e6-878">E8CC</span></span></td>
  <td><span data-ttu-id="028e6-879">MobileTablet</span><span class="sxs-lookup"><span data-stu-id="028e6-879">MobileTablet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CD.png" width="32" height="32" alt="DisconnectDrive" /></td>
  <td><span data-ttu-id="028e6-880">E8CD</span><span class="sxs-lookup"><span data-stu-id="028e6-880">E8CD</span></span></td>
  <td><span data-ttu-id="028e6-881">DisconnectDrive</span><span class="sxs-lookup"><span data-stu-id="028e6-881">DisconnectDrive</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CE.png" width="32" height="32" alt="MapDrive" /></td>
  <td><span data-ttu-id="028e6-882">E8CE</span><span class="sxs-lookup"><span data-stu-id="028e6-882">E8CE</span></span></td>
  <td><span data-ttu-id="028e6-883">MapDrive</span><span class="sxs-lookup"><span data-stu-id="028e6-883">MapDrive</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CF.png" width="32" height="32" alt="ContactPresence" /></td>
  <td><span data-ttu-id="028e6-884">E8CF</span><span class="sxs-lookup"><span data-stu-id="028e6-884">E8CF</span></span></td>
  <td><span data-ttu-id="028e6-885">ContactPresence</span><span class="sxs-lookup"><span data-stu-id="028e6-885">ContactPresence</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D0.png" width="32" height="32" alt="Priority" /></td>
  <td><span data-ttu-id="028e6-886">E8D0</span><span class="sxs-lookup"><span data-stu-id="028e6-886">E8D0</span></span></td>
  <td><span data-ttu-id="028e6-887">Priority</span><span class="sxs-lookup"><span data-stu-id="028e6-887">Priority</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D1.png" width="32" height="32" alt="GotoToday" /></td>
  <td><span data-ttu-id="028e6-888">E8D1</span><span class="sxs-lookup"><span data-stu-id="028e6-888">E8D1</span></span></td>
  <td><span data-ttu-id="028e6-889">GotoToday</span><span class="sxs-lookup"><span data-stu-id="028e6-889">GotoToday</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D2.png" width="32" height="32" alt="Font" /></td>
  <td><span data-ttu-id="028e6-890">E8D2</span><span class="sxs-lookup"><span data-stu-id="028e6-890">E8D2</span></span></td>
  <td><span data-ttu-id="028e6-891">Font</span><span class="sxs-lookup"><span data-stu-id="028e6-891">Font</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D3.png" width="32" height="32" alt="FontColor" /></td>
  <td><span data-ttu-id="028e6-892">E8D3</span><span class="sxs-lookup"><span data-stu-id="028e6-892">E8D3</span></span></td>
  <td><span data-ttu-id="028e6-893">FontColor</span><span class="sxs-lookup"><span data-stu-id="028e6-893">FontColor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D4.png" width="32" height="32" alt="Contact2" /></td>
  <td><span data-ttu-id="028e6-894">E8D4</span><span class="sxs-lookup"><span data-stu-id="028e6-894">E8D4</span></span></td>
  <td><span data-ttu-id="028e6-895">Contact2</span><span class="sxs-lookup"><span data-stu-id="028e6-895">Contact2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D5.png" width="32" height="32" alt="FolderFill" /></td>
  <td><span data-ttu-id="028e6-896">E8D5</span><span class="sxs-lookup"><span data-stu-id="028e6-896">E8D5</span></span></td>
  <td><span data-ttu-id="028e6-897">FolderFill</span><span class="sxs-lookup"><span data-stu-id="028e6-897">FolderFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D6.png" width="32" height="32" alt="Audio" /></td>
  <td><span data-ttu-id="028e6-898">E8D6</span><span class="sxs-lookup"><span data-stu-id="028e6-898">E8D6</span></span></td>
  <td><span data-ttu-id="028e6-899">Audio</span><span class="sxs-lookup"><span data-stu-id="028e6-899">Audio</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D7.png" width="32" height="32" alt="Permissions" /></td>
  <td><span data-ttu-id="028e6-900">E8D7</span><span class="sxs-lookup"><span data-stu-id="028e6-900">E8D7</span></span></td>
  <td><span data-ttu-id="028e6-901">Permissions</span><span class="sxs-lookup"><span data-stu-id="028e6-901">Permissions</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D8.png" width="32" height="32" alt="DisableUpdates" /></td>
  <td><span data-ttu-id="028e6-902">E8D8</span><span class="sxs-lookup"><span data-stu-id="028e6-902">E8D8</span></span></td>
  <td><span data-ttu-id="028e6-903">DisableUpdates</span><span class="sxs-lookup"><span data-stu-id="028e6-903">DisableUpdates</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D9.png" width="32" height="32" alt="Unfavorite" /></td>
  <td><span data-ttu-id="028e6-904">E8D9</span><span class="sxs-lookup"><span data-stu-id="028e6-904">E8D9</span></span></td>
  <td><span data-ttu-id="028e6-905">Unfavorite</span><span class="sxs-lookup"><span data-stu-id="028e6-905">Unfavorite</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DA.png" width="32" height="32" alt="OpenLocal" /></td>
  <td><span data-ttu-id="028e6-906">E8DA</span><span class="sxs-lookup"><span data-stu-id="028e6-906">E8DA</span></span></td>
  <td><span data-ttu-id="028e6-907">OpenLocal</span><span class="sxs-lookup"><span data-stu-id="028e6-907">OpenLocal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DB.png" width="32" height="32" alt="Italic" /></td>
  <td><span data-ttu-id="028e6-908">E8DB</span><span class="sxs-lookup"><span data-stu-id="028e6-908">E8DB</span></span></td>
  <td><span data-ttu-id="028e6-909">Italic</span><span class="sxs-lookup"><span data-stu-id="028e6-909">Italic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DC.png" width="32" height="32" alt="Underline" /></td>
  <td><span data-ttu-id="028e6-910">E8DC</span><span class="sxs-lookup"><span data-stu-id="028e6-910">E8DC</span></span></td>
  <td><span data-ttu-id="028e6-911">Underline</span><span class="sxs-lookup"><span data-stu-id="028e6-911">Underline</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DD.png" width="32" height="32" alt="Bold" /></td>
  <td><span data-ttu-id="028e6-912">E8DD</span><span class="sxs-lookup"><span data-stu-id="028e6-912">E8DD</span></span></td>
  <td><span data-ttu-id="028e6-913">Bold</span><span class="sxs-lookup"><span data-stu-id="028e6-913">Bold</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DE.png" width="32" height="32" alt="MoveToFolder" /></td>
  <td><span data-ttu-id="028e6-914">E8DE</span><span class="sxs-lookup"><span data-stu-id="028e6-914">E8DE</span></span></td>
  <td><span data-ttu-id="028e6-915">MoveToFolder</span><span class="sxs-lookup"><span data-stu-id="028e6-915">MoveToFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DF.png" width="32" height="32" alt="LikeDislike" /></td>
  <td><span data-ttu-id="028e6-916">E8DF</span><span class="sxs-lookup"><span data-stu-id="028e6-916">E8DF</span></span></td>
  <td><span data-ttu-id="028e6-917">LikeDislike</span><span class="sxs-lookup"><span data-stu-id="028e6-917">LikeDislike</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E0.png" width="32" height="32" alt="Dislike" /></td>
  <td><span data-ttu-id="028e6-918">E8E0</span><span class="sxs-lookup"><span data-stu-id="028e6-918">E8E0</span></span></td>
  <td><span data-ttu-id="028e6-919">Dislike</span><span class="sxs-lookup"><span data-stu-id="028e6-919">Dislike</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E1.png" width="32" height="32" alt="Like" /></td>
  <td><span data-ttu-id="028e6-920">E8E1</span><span class="sxs-lookup"><span data-stu-id="028e6-920">E8E1</span></span></td>
  <td><span data-ttu-id="028e6-921">Like</span><span class="sxs-lookup"><span data-stu-id="028e6-921">Like</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E2.png" width="32" height="32" alt="AlignRight" /></td>
  <td><span data-ttu-id="028e6-922">E8E2</span><span class="sxs-lookup"><span data-stu-id="028e6-922">E8E2</span></span></td>
  <td><span data-ttu-id="028e6-923">AlignRight</span><span class="sxs-lookup"><span data-stu-id="028e6-923">AlignRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E3.png" width="32" height="32" alt="AlignCenter" /></td>
  <td><span data-ttu-id="028e6-924">E8E3</span><span class="sxs-lookup"><span data-stu-id="028e6-924">E8E3</span></span></td>
  <td><span data-ttu-id="028e6-925">AlignCenter</span><span class="sxs-lookup"><span data-stu-id="028e6-925">AlignCenter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E4.png" width="32" height="32" alt="AlignLeft" /></td>
  <td><span data-ttu-id="028e6-926">E8E4</span><span class="sxs-lookup"><span data-stu-id="028e6-926">E8E4</span></span></td>
  <td><span data-ttu-id="028e6-927">AlignLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-927">AlignLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E5.png" width="32" height="32" alt="OpenFile" /></td>
  <td><span data-ttu-id="028e6-928">E8E5</span><span class="sxs-lookup"><span data-stu-id="028e6-928">E8E5</span></span></td>
  <td><span data-ttu-id="028e6-929">OpenFile</span><span class="sxs-lookup"><span data-stu-id="028e6-929">OpenFile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E6.png" width="32" height="32" alt="ClearSelection" /></td>
  <td><span data-ttu-id="028e6-930">E8E6</span><span class="sxs-lookup"><span data-stu-id="028e6-930">E8E6</span></span></td>
  <td><span data-ttu-id="028e6-931">ClearSelection</span><span class="sxs-lookup"><span data-stu-id="028e6-931">ClearSelection</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E7.png" width="32" height="32" alt="FontDecrease" /></td>
  <td><span data-ttu-id="028e6-932">E8E7</span><span class="sxs-lookup"><span data-stu-id="028e6-932">E8E7</span></span></td>
  <td><span data-ttu-id="028e6-933">FontDecrease</span><span class="sxs-lookup"><span data-stu-id="028e6-933">FontDecrease</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E8.png" width="32" height="32" alt="FontIncrease" /></td>
  <td><span data-ttu-id="028e6-934">E8E8</span><span class="sxs-lookup"><span data-stu-id="028e6-934">E8E8</span></span></td>
  <td><span data-ttu-id="028e6-935">FontIncrease</span><span class="sxs-lookup"><span data-stu-id="028e6-935">FontIncrease</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E9.png" width="32" height="32" alt="FontSize" /></td>
  <td><span data-ttu-id="028e6-936">E8E9</span><span class="sxs-lookup"><span data-stu-id="028e6-936">E8E9</span></span></td>
  <td><span data-ttu-id="028e6-937">FontSize</span><span class="sxs-lookup"><span data-stu-id="028e6-937">FontSize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EA.png" width="32" height="32" alt="CellPhone" /></td>
  <td><span data-ttu-id="028e6-938">E8EA</span><span class="sxs-lookup"><span data-stu-id="028e6-938">E8EA</span></span></td>
  <td><span data-ttu-id="028e6-939">CellPhone</span><span class="sxs-lookup"><span data-stu-id="028e6-939">CellPhone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EB.png" width="32" height="32" alt="Reshare" /></td>
  <td><span data-ttu-id="028e6-940">E8EB</span><span class="sxs-lookup"><span data-stu-id="028e6-940">E8EB</span></span></td>
  <td><span data-ttu-id="028e6-941">Reshare</span><span class="sxs-lookup"><span data-stu-id="028e6-941">Reshare</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EC.png" width="32" height="32" alt="Tag" /></td>
  <td><span data-ttu-id="028e6-942">E8EC</span><span class="sxs-lookup"><span data-stu-id="028e6-942">E8EC</span></span></td>
  <td><span data-ttu-id="028e6-943">Tag</span><span class="sxs-lookup"><span data-stu-id="028e6-943">Tag</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8ED.png" width="32" height="32" alt="RepeatOne" /></td>
  <td><span data-ttu-id="028e6-944">E8ED</span><span class="sxs-lookup"><span data-stu-id="028e6-944">E8ED</span></span></td>
  <td><span data-ttu-id="028e6-945">RepeatOne</span><span class="sxs-lookup"><span data-stu-id="028e6-945">RepeatOne</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EE.png" width="32" height="32" alt="RepeatAll" /></td>
  <td><span data-ttu-id="028e6-946">E8EE</span><span class="sxs-lookup"><span data-stu-id="028e6-946">E8EE</span></span></td>
  <td><span data-ttu-id="028e6-947">RepeatAll</span><span class="sxs-lookup"><span data-stu-id="028e6-947">RepeatAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EF.png" width="32" height="32" alt="Calculator" /></td>
  <td><span data-ttu-id="028e6-948">E8EF</span><span class="sxs-lookup"><span data-stu-id="028e6-948">E8EF</span></span></td>
  <td><span data-ttu-id="028e6-949">電卓</span><span class="sxs-lookup"><span data-stu-id="028e6-949">Calculator</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F0.png" width="32" height="32" alt="Directions" /></td>
  <td><span data-ttu-id="028e6-950">E8F0</span><span class="sxs-lookup"><span data-stu-id="028e6-950">E8F0</span></span></td>
  <td><span data-ttu-id="028e6-951">Directions</span><span class="sxs-lookup"><span data-stu-id="028e6-951">Directions</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F1.png" width="32" height="32" alt="Library" /></td>
  <td><span data-ttu-id="028e6-952">E8F1</span><span class="sxs-lookup"><span data-stu-id="028e6-952">E8F1</span></span></td>
  <td><span data-ttu-id="028e6-953">Library</span><span class="sxs-lookup"><span data-stu-id="028e6-953">Library</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F2.png" width="32" height="32" alt="ChatBubbles" /></td>
  <td><span data-ttu-id="028e6-954">E8F2</span><span class="sxs-lookup"><span data-stu-id="028e6-954">E8F2</span></span></td>
  <td><span data-ttu-id="028e6-955">ChatBubbles</span><span class="sxs-lookup"><span data-stu-id="028e6-955">ChatBubbles</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F3.png" width="32" height="32" alt="PostUpdate" /></td>
  <td><span data-ttu-id="028e6-956">E8F3</span><span class="sxs-lookup"><span data-stu-id="028e6-956">E8F3</span></span></td>
  <td><span data-ttu-id="028e6-957">PostUpdate</span><span class="sxs-lookup"><span data-stu-id="028e6-957">PostUpdate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F4.png" width="32" height="32" alt="NewFolder" /></td>
  <td><span data-ttu-id="028e6-958">E8F4</span><span class="sxs-lookup"><span data-stu-id="028e6-958">E8F4</span></span></td>
  <td><span data-ttu-id="028e6-959">NewFolder</span><span class="sxs-lookup"><span data-stu-id="028e6-959">NewFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F5.png" width="32" height="32" alt="CalendarReply" /></td>
  <td><span data-ttu-id="028e6-960">E8F5</span><span class="sxs-lookup"><span data-stu-id="028e6-960">E8F5</span></span></td>
  <td><span data-ttu-id="028e6-961">CalendarReply</span><span class="sxs-lookup"><span data-stu-id="028e6-961">CalendarReply</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F6.png" width="32" height="32" alt="UnsyncFolder" /></td>
  <td><span data-ttu-id="028e6-962">E8F6</span><span class="sxs-lookup"><span data-stu-id="028e6-962">E8F6</span></span></td>
  <td><span data-ttu-id="028e6-963">UnsyncFolder</span><span class="sxs-lookup"><span data-stu-id="028e6-963">UnsyncFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F7.png" width="32" height="32" alt="SyncFolder" /></td>
  <td><span data-ttu-id="028e6-964">E8F7</span><span class="sxs-lookup"><span data-stu-id="028e6-964">E8F7</span></span></td>
  <td><span data-ttu-id="028e6-965">SyncFolder</span><span class="sxs-lookup"><span data-stu-id="028e6-965">SyncFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F8.png" width="32" height="32" alt="BlockContact" /></td>
  <td><span data-ttu-id="028e6-966">E8F8</span><span class="sxs-lookup"><span data-stu-id="028e6-966">E8F8</span></span></td>
  <td><span data-ttu-id="028e6-967">BlockContact</span><span class="sxs-lookup"><span data-stu-id="028e6-967">BlockContact</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F9.png" width="32" height="32" alt="SwitchApps" /></td>
  <td><span data-ttu-id="028e6-968">E8F9</span><span class="sxs-lookup"><span data-stu-id="028e6-968">E8F9</span></span></td>
  <td><span data-ttu-id="028e6-969">SwitchApps</span><span class="sxs-lookup"><span data-stu-id="028e6-969">SwitchApps</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FA.png" width="32" height="32" alt="AddFriend" /></td>
  <td><span data-ttu-id="028e6-970">E8FA</span><span class="sxs-lookup"><span data-stu-id="028e6-970">E8FA</span></span></td>
  <td><span data-ttu-id="028e6-971">AddFriend</span><span class="sxs-lookup"><span data-stu-id="028e6-971">AddFriend</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FB.png" width="32" height="32" alt="Accept" /></td>
  <td><span data-ttu-id="028e6-972">E8FB</span><span class="sxs-lookup"><span data-stu-id="028e6-972">E8FB</span></span></td>
  <td><span data-ttu-id="028e6-973">Accept</span><span class="sxs-lookup"><span data-stu-id="028e6-973">Accept</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FC.png" width="32" height="32" alt="GoToStart" /></td>
  <td><span data-ttu-id="028e6-974">E8FC</span><span class="sxs-lookup"><span data-stu-id="028e6-974">E8FC</span></span></td>
  <td><span data-ttu-id="028e6-975">GoToStart</span><span class="sxs-lookup"><span data-stu-id="028e6-975">GoToStart</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FD.png" width="32" height="32" alt="BulletedList" /></td>
  <td><span data-ttu-id="028e6-976">E8FD</span><span class="sxs-lookup"><span data-stu-id="028e6-976">E8FD</span></span></td>
  <td><span data-ttu-id="028e6-977">BulletedList</span><span class="sxs-lookup"><span data-stu-id="028e6-977">BulletedList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FE.png" width="32" height="32" alt="Scan" /></td>
  <td><span data-ttu-id="028e6-978">E8FE</span><span class="sxs-lookup"><span data-stu-id="028e6-978">E8FE</span></span></td>
  <td><span data-ttu-id="028e6-979">Scan</span><span class="sxs-lookup"><span data-stu-id="028e6-979">Scan</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FF.png" width="32" height="32" alt="Preview" /></td>
  <td><span data-ttu-id="028e6-980">E8FF</span><span class="sxs-lookup"><span data-stu-id="028e6-980">E8FF</span></span></td>
  <td><span data-ttu-id="028e6-981">Preview</span><span class="sxs-lookup"><span data-stu-id="028e6-981">Preview</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E902.png" width="32" height="32" alt="Group" /></td>
  <td><span data-ttu-id="028e6-982">E902</span><span class="sxs-lookup"><span data-stu-id="028e6-982">E902</span></span></td>
  <td><span data-ttu-id="028e6-983">Group</span><span class="sxs-lookup"><span data-stu-id="028e6-983">Group</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E904.png" width="32" height="32" alt="ZeroBars" /></td>
  <td><span data-ttu-id="028e6-984">E904</span><span class="sxs-lookup"><span data-stu-id="028e6-984">E904</span></span></td>
  <td><span data-ttu-id="028e6-985">ZeroBars</span><span class="sxs-lookup"><span data-stu-id="028e6-985">ZeroBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E905.png" width="32" height="32" alt="OneBar" /></td>
  <td><span data-ttu-id="028e6-986">E905</span><span class="sxs-lookup"><span data-stu-id="028e6-986">E905</span></span></td>
  <td><span data-ttu-id="028e6-987">OneBar</span><span class="sxs-lookup"><span data-stu-id="028e6-987">OneBar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E906.png" width="32" height="32" alt="TwoBars" /></td>
  <td><span data-ttu-id="028e6-988">E906</span><span class="sxs-lookup"><span data-stu-id="028e6-988">E906</span></span></td>
  <td><span data-ttu-id="028e6-989">TwoBars</span><span class="sxs-lookup"><span data-stu-id="028e6-989">TwoBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E907.png" width="32" height="32" alt="ThreeBars" /></td>
  <td><span data-ttu-id="028e6-990">E907</span><span class="sxs-lookup"><span data-stu-id="028e6-990">E907</span></span></td>
  <td><span data-ttu-id="028e6-991">ThreeBars</span><span class="sxs-lookup"><span data-stu-id="028e6-991">ThreeBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E908.png" width="32" height="32" alt="FourBars" /></td>
  <td><span data-ttu-id="028e6-992">E908</span><span class="sxs-lookup"><span data-stu-id="028e6-992">E908</span></span></td>
  <td><span data-ttu-id="028e6-993">FourBars</span><span class="sxs-lookup"><span data-stu-id="028e6-993">FourBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E909.png" width="32" height="32" alt="World" /></td>
  <td><span data-ttu-id="028e6-994">E909</span><span class="sxs-lookup"><span data-stu-id="028e6-994">E909</span></span></td>
  <td><span data-ttu-id="028e6-995">World</span><span class="sxs-lookup"><span data-stu-id="028e6-995">World</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90A.png" width="32" height="32" alt="Comment" /></td>
  <td><span data-ttu-id="028e6-996">E90A</span><span class="sxs-lookup"><span data-stu-id="028e6-996">E90A</span></span></td>
  <td><span data-ttu-id="028e6-997">Comment</span><span class="sxs-lookup"><span data-stu-id="028e6-997">Comment</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90B.png" width="32" height="32" alt="MusicInfo" /></td>
  <td><span data-ttu-id="028e6-998">E90B</span><span class="sxs-lookup"><span data-stu-id="028e6-998">E90B</span></span></td>
  <td><span data-ttu-id="028e6-999">MusicInfo</span><span class="sxs-lookup"><span data-stu-id="028e6-999">MusicInfo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90C.png" width="32" height="32" alt="DockLeft" /></td>
  <td><span data-ttu-id="028e6-1000">E90C</span><span class="sxs-lookup"><span data-stu-id="028e6-1000">E90C</span></span></td>
  <td><span data-ttu-id="028e6-1001">DockLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-1001">DockLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90D.png" width="32" height="32" alt="DockRight" /></td>
  <td><span data-ttu-id="028e6-1002">E90D</span><span class="sxs-lookup"><span data-stu-id="028e6-1002">E90D</span></span></td>
  <td><span data-ttu-id="028e6-1003">DockRight</span><span class="sxs-lookup"><span data-stu-id="028e6-1003">DockRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90E.png" width="32" height="32" alt="DockBottom" /></td>
  <td><span data-ttu-id="028e6-1004">E90E</span><span class="sxs-lookup"><span data-stu-id="028e6-1004">E90E</span></span></td>
  <td><span data-ttu-id="028e6-1005">DockBottom</span><span class="sxs-lookup"><span data-stu-id="028e6-1005">DockBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90F.png" width="32" height="32" alt="Repair" /></td>
  <td><span data-ttu-id="028e6-1006">E90F</span><span class="sxs-lookup"><span data-stu-id="028e6-1006">E90F</span></span></td>
  <td><span data-ttu-id="028e6-1007">Repair</span><span class="sxs-lookup"><span data-stu-id="028e6-1007">Repair</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E910.png" width="32" height="32" alt="Accounts" /></td>
  <td><span data-ttu-id="028e6-1008">E910</span><span class="sxs-lookup"><span data-stu-id="028e6-1008">E910</span></span></td>
  <td><span data-ttu-id="028e6-1009">Accounts</span><span class="sxs-lookup"><span data-stu-id="028e6-1009">Accounts</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E911.png" width="32" height="32" alt="DullSound" /></td>
  <td><span data-ttu-id="028e6-1010">E911</span><span class="sxs-lookup"><span data-stu-id="028e6-1010">E911</span></span></td>
  <td><span data-ttu-id="028e6-1011">DullSound</span><span class="sxs-lookup"><span data-stu-id="028e6-1011">DullSound</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E912.png" width="32" height="32" alt="Manage" /></td>
  <td><span data-ttu-id="028e6-1012">E912</span><span class="sxs-lookup"><span data-stu-id="028e6-1012">E912</span></span></td>
  <td><span data-ttu-id="028e6-1013">Manage</span><span class="sxs-lookup"><span data-stu-id="028e6-1013">Manage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E913.png" width="32" height="32" alt="Street" /></td>
  <td><span data-ttu-id="028e6-1014">E913</span><span class="sxs-lookup"><span data-stu-id="028e6-1014">E913</span></span></td>
  <td><span data-ttu-id="028e6-1015">Street</span><span class="sxs-lookup"><span data-stu-id="028e6-1015">Street</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E914.png" width="32" height="32" alt="Printer3D" /></td>
  <td><span data-ttu-id="028e6-1016">E914</span><span class="sxs-lookup"><span data-stu-id="028e6-1016">E914</span></span></td>
  <td><span data-ttu-id="028e6-1017">Printer3D</span><span class="sxs-lookup"><span data-stu-id="028e6-1017">Printer3D</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E915.png" width="32" height="32" alt="RadioBullet" /></td>
  <td><span data-ttu-id="028e6-1018">E915</span><span class="sxs-lookup"><span data-stu-id="028e6-1018">E915</span></span></td>
  <td><span data-ttu-id="028e6-1019">RadioBullet</span><span class="sxs-lookup"><span data-stu-id="028e6-1019">RadioBullet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E916.png" width="32" height="32" alt="Stopwatch" /></td>
  <td><span data-ttu-id="028e6-1020">E916</span><span class="sxs-lookup"><span data-stu-id="028e6-1020">E916</span></span></td>
  <td><span data-ttu-id="028e6-1021">Stopwatch</span><span class="sxs-lookup"><span data-stu-id="028e6-1021">Stopwatch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E91B.png" width="32" height="32" alt="Photo" /></td>
  <td><span data-ttu-id="028e6-1022">E91B</span><span class="sxs-lookup"><span data-stu-id="028e6-1022">E91B</span></span></td>
  <td><span data-ttu-id="028e6-1023">Photo</span><span class="sxs-lookup"><span data-stu-id="028e6-1023">Photo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E91C.png" width="32" height="32" alt="ActionCenter" /></td>
  <td><span data-ttu-id="028e6-1024">E91C</span><span class="sxs-lookup"><span data-stu-id="028e6-1024">E91C</span></span></td>
  <td><span data-ttu-id="028e6-1025">ActionCenter</span><span class="sxs-lookup"><span data-stu-id="028e6-1025">ActionCenter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E91F.png" width="32" height="32" alt="FullCircleMask" /></td>
  <td><span data-ttu-id="028e6-1026">E91F</span><span class="sxs-lookup"><span data-stu-id="028e6-1026">E91F</span></span></td>
  <td><span data-ttu-id="028e6-1027">FullCircleMask</span><span class="sxs-lookup"><span data-stu-id="028e6-1027">FullCircleMask</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E921.png" width="32" height="32" alt="ChromeMinimize" /></td>
  <td><span data-ttu-id="028e6-1028">E921</span><span class="sxs-lookup"><span data-stu-id="028e6-1028">E921</span></span></td>
  <td><span data-ttu-id="028e6-1029">ChromeMinimize</span><span class="sxs-lookup"><span data-stu-id="028e6-1029">ChromeMinimize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E922.png" width="32" height="32" alt="ChromeMaximize" /></td>
  <td><span data-ttu-id="028e6-1030">E922</span><span class="sxs-lookup"><span data-stu-id="028e6-1030">E922</span></span></td>
  <td><span data-ttu-id="028e6-1031">ChromeMaximize</span><span class="sxs-lookup"><span data-stu-id="028e6-1031">ChromeMaximize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E923.png" width="32" height="32" alt="ChromeRestore" /></td>
  <td><span data-ttu-id="028e6-1032">E923</span><span class="sxs-lookup"><span data-stu-id="028e6-1032">E923</span></span></td>
  <td><span data-ttu-id="028e6-1033">ChromeRestore</span><span class="sxs-lookup"><span data-stu-id="028e6-1033">ChromeRestore</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E924.png" width="32" height="32" alt="Annotation" /></td>
  <td><span data-ttu-id="028e6-1034">E924</span><span class="sxs-lookup"><span data-stu-id="028e6-1034">E924</span></span></td>
  <td><span data-ttu-id="028e6-1035">Annotation</span><span class="sxs-lookup"><span data-stu-id="028e6-1035">Annotation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E925.png" width="32" height="32" alt="BackSpaceQWERTYSm" /></td>
  <td><span data-ttu-id="028e6-1036">E925</span><span class="sxs-lookup"><span data-stu-id="028e6-1036">E925</span></span></td>
  <td><span data-ttu-id="028e6-1037">BackSpaceQWERTYSm</span><span class="sxs-lookup"><span data-stu-id="028e6-1037">BackSpaceQWERTYSm</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E926.png" width="32" height="32" alt="BackSpaceQWERTYMd" /></td>
  <td><span data-ttu-id="028e6-1038">E926</span><span class="sxs-lookup"><span data-stu-id="028e6-1038">E926</span></span></td>
  <td><span data-ttu-id="028e6-1039">BackSpaceQWERTYMd</span><span class="sxs-lookup"><span data-stu-id="028e6-1039">BackSpaceQWERTYMd</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E927.png" width="32" height="32" alt="Swipe" /></td>
  <td><span data-ttu-id="028e6-1040">E927</span><span class="sxs-lookup"><span data-stu-id="028e6-1040">E927</span></span></td>
  <td><span data-ttu-id="028e6-1041">Swipe</span><span class="sxs-lookup"><span data-stu-id="028e6-1041">Swipe</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E928.png" width="32" height="32" alt="Fingerprint" /></td>
  <td><span data-ttu-id="028e6-1042">E928</span><span class="sxs-lookup"><span data-stu-id="028e6-1042">E928</span></span></td>
  <td><span data-ttu-id="028e6-1043">Fingerprint</span><span class="sxs-lookup"><span data-stu-id="028e6-1043">Fingerprint</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E929.png" width="32" height="32" alt="Handwriting" /></td>
  <td><span data-ttu-id="028e6-1044">E929</span><span class="sxs-lookup"><span data-stu-id="028e6-1044">E929</span></span></td>
  <td><span data-ttu-id="028e6-1045">Handwriting</span><span class="sxs-lookup"><span data-stu-id="028e6-1045">Handwriting</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E92C.png" width="32" height="32" alt="ChromeBackToWindow" /></td>
  <td><span data-ttu-id="028e6-1046">E92C</span><span class="sxs-lookup"><span data-stu-id="028e6-1046">E92C</span></span></td>
  <td><span data-ttu-id="028e6-1047">ChromeBackToWindow</span><span class="sxs-lookup"><span data-stu-id="028e6-1047">ChromeBackToWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E92D.png" width="32" height="32" alt="ChromeFullScreen" /></td>
  <td><span data-ttu-id="028e6-1048">E92D</span><span class="sxs-lookup"><span data-stu-id="028e6-1048">E92D</span></span></td>
  <td><span data-ttu-id="028e6-1049">ChromeFullScreen</span><span class="sxs-lookup"><span data-stu-id="028e6-1049">ChromeFullScreen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E92E.png" width="32" height="32" alt="KeyboardStandard" /></td>
  <td><span data-ttu-id="028e6-1050">E92E</span><span class="sxs-lookup"><span data-stu-id="028e6-1050">E92E</span></span></td>
  <td><span data-ttu-id="028e6-1051">KeyboardStandard</span><span class="sxs-lookup"><span data-stu-id="028e6-1051">KeyboardStandard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E92F.png" width="32" height="32" alt="KeyboardDismiss" /></td>
  <td><span data-ttu-id="028e6-1052">E92F</span><span class="sxs-lookup"><span data-stu-id="028e6-1052">E92F</span></span></td>
  <td><span data-ttu-id="028e6-1053">KeyboardDismiss</span><span class="sxs-lookup"><span data-stu-id="028e6-1053">KeyboardDismiss</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E930.png" width="32" height="32" alt="Completed" /></td>
  <td><span data-ttu-id="028e6-1054">E930</span><span class="sxs-lookup"><span data-stu-id="028e6-1054">E930</span></span></td>
  <td><span data-ttu-id="028e6-1055">Completed</span><span class="sxs-lookup"><span data-stu-id="028e6-1055">Completed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E931.png" width="32" height="32" alt="ChromeAnnotate" /></td>
  <td><span data-ttu-id="028e6-1056">E931</span><span class="sxs-lookup"><span data-stu-id="028e6-1056">E931</span></span></td>
  <td><span data-ttu-id="028e6-1057">ChromeAnnotate</span><span class="sxs-lookup"><span data-stu-id="028e6-1057">ChromeAnnotate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E932.png" width="32" height="32" alt="Label" /></td>
  <td><span data-ttu-id="028e6-1058">E932</span><span class="sxs-lookup"><span data-stu-id="028e6-1058">E932</span></span></td>
  <td><span data-ttu-id="028e6-1059">Label</span><span class="sxs-lookup"><span data-stu-id="028e6-1059">Label</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E933.png" width="32" height="32" alt="IBeam" /></td>
  <td><span data-ttu-id="028e6-1060">E933</span><span class="sxs-lookup"><span data-stu-id="028e6-1060">E933</span></span></td>
  <td><span data-ttu-id="028e6-1061">IBeam</span><span class="sxs-lookup"><span data-stu-id="028e6-1061">IBeam</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E934.png" width="32" height="32" alt="IBeamOutline" /></td>
  <td><span data-ttu-id="028e6-1062">E934</span><span class="sxs-lookup"><span data-stu-id="028e6-1062">E934</span></span></td>
  <td><span data-ttu-id="028e6-1063">IBeamOutline</span><span class="sxs-lookup"><span data-stu-id="028e6-1063">IBeamOutline</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E935.png" width="32" height="32" alt="FlickDown" /></td>
  <td><span data-ttu-id="028e6-1064">E935</span><span class="sxs-lookup"><span data-stu-id="028e6-1064">E935</span></span></td>
  <td><span data-ttu-id="028e6-1065">FlickDown</span><span class="sxs-lookup"><span data-stu-id="028e6-1065">FlickDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E936.png" width="32" height="32" alt="FlickUp" /></td>
  <td><span data-ttu-id="028e6-1066">E936</span><span class="sxs-lookup"><span data-stu-id="028e6-1066">E936</span></span></td>
  <td><span data-ttu-id="028e6-1067">FlickUp</span><span class="sxs-lookup"><span data-stu-id="028e6-1067">FlickUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E937.png" width="32" height="32" alt="FlickLeft" /></td>
  <td><span data-ttu-id="028e6-1068">E937</span><span class="sxs-lookup"><span data-stu-id="028e6-1068">E937</span></span></td>
  <td><span data-ttu-id="028e6-1069">FlickLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-1069">FlickLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E938.png" width="32" height="32" alt="FlickRight" /></td>
  <td><span data-ttu-id="028e6-1070">E938</span><span class="sxs-lookup"><span data-stu-id="028e6-1070">E938</span></span></td>
  <td><span data-ttu-id="028e6-1071">FlickRight</span><span class="sxs-lookup"><span data-stu-id="028e6-1071">FlickRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E939.png" width="32" height="32" alt="FeedbackApp" /></td>
  <td><span data-ttu-id="028e6-1072">E939</span><span class="sxs-lookup"><span data-stu-id="028e6-1072">E939</span></span></td>
  <td><span data-ttu-id="028e6-1073">FeedbackApp</span><span class="sxs-lookup"><span data-stu-id="028e6-1073">FeedbackApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E93C.png" width="32" height="32" alt="MusicAlbum" /></td>
  <td><span data-ttu-id="028e6-1074">E93C</span><span class="sxs-lookup"><span data-stu-id="028e6-1074">E93C</span></span></td>
  <td><span data-ttu-id="028e6-1075">MusicAlbum</span><span class="sxs-lookup"><span data-stu-id="028e6-1075">MusicAlbum</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E93E.png" width="32" height="32" alt="Streaming" /></td>
  <td><span data-ttu-id="028e6-1076">E93E</span><span class="sxs-lookup"><span data-stu-id="028e6-1076">E93E</span></span></td>
  <td><span data-ttu-id="028e6-1077">Streaming</span><span class="sxs-lookup"><span data-stu-id="028e6-1077">Streaming</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E943.png" width="32" height="32" alt="Code" /></td>
  <td><span data-ttu-id="028e6-1078">E943</span><span class="sxs-lookup"><span data-stu-id="028e6-1078">E943</span></span></td>
  <td><span data-ttu-id="028e6-1079">Code</span><span class="sxs-lookup"><span data-stu-id="028e6-1079">Code</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E944.png" width="32" height="32" alt="ReturnToWindow" /></td>
  <td><span data-ttu-id="028e6-1080">E944</span><span class="sxs-lookup"><span data-stu-id="028e6-1080">E944</span></span></td>
  <td><span data-ttu-id="028e6-1081">ReturnToWindow</span><span class="sxs-lookup"><span data-stu-id="028e6-1081">ReturnToWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E945.png" width="32" height="32" alt="LightningBolt" /></td>
  <td><span data-ttu-id="028e6-1082">E945</span><span class="sxs-lookup"><span data-stu-id="028e6-1082">E945</span></span></td>
  <td><span data-ttu-id="028e6-1083">LightningBolt</span><span class="sxs-lookup"><span data-stu-id="028e6-1083">LightningBolt</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E946.png" width="32" height="32" alt="Info" /></td>
  <td><span data-ttu-id="028e6-1084">E946</span><span class="sxs-lookup"><span data-stu-id="028e6-1084">E946</span></span></td>
  <td><span data-ttu-id="028e6-1085">Info</span><span class="sxs-lookup"><span data-stu-id="028e6-1085">Info</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E947.png" width="32" height="32" alt="CalculatorMultiply" /></td>
  <td><span data-ttu-id="028e6-1086">E947</span><span class="sxs-lookup"><span data-stu-id="028e6-1086">E947</span></span></td>
  <td><span data-ttu-id="028e6-1087">CalculatorMultiply</span><span class="sxs-lookup"><span data-stu-id="028e6-1087">CalculatorMultiply</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E948.png" width="32" height="32" alt="CalculatorAddition" /></td>
  <td><span data-ttu-id="028e6-1088">E948</span><span class="sxs-lookup"><span data-stu-id="028e6-1088">E948</span></span></td>
  <td><span data-ttu-id="028e6-1089">CalculatorAddition</span><span class="sxs-lookup"><span data-stu-id="028e6-1089">CalculatorAddition</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E949.png" width="32" height="32" alt="CalculatorSubtract" /></td>
  <td><span data-ttu-id="028e6-1090">E949</span><span class="sxs-lookup"><span data-stu-id="028e6-1090">E949</span></span></td>
  <td><span data-ttu-id="028e6-1091">CalculatorSubtract</span><span class="sxs-lookup"><span data-stu-id="028e6-1091">CalculatorSubtract</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94A.png" width="32" height="32" alt="CalculatorDivide" /></td>
  <td><span data-ttu-id="028e6-1092">E94A</span><span class="sxs-lookup"><span data-stu-id="028e6-1092">E94A</span></span></td>
  <td><span data-ttu-id="028e6-1093">CalculatorDivide</span><span class="sxs-lookup"><span data-stu-id="028e6-1093">CalculatorDivide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94B.png" width="32" height="32" alt="CalculatorSquareroot" /></td>
  <td><span data-ttu-id="028e6-1094">E94B</span><span class="sxs-lookup"><span data-stu-id="028e6-1094">E94B</span></span></td>
  <td><span data-ttu-id="028e6-1095">CalculatorSquareroot</span><span class="sxs-lookup"><span data-stu-id="028e6-1095">CalculatorSquareroot</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94C.png" width="32" height="32" alt="CalculatorPercentage" /></td>
  <td><span data-ttu-id="028e6-1096">E94C</span><span class="sxs-lookup"><span data-stu-id="028e6-1096">E94C</span></span></td>
  <td><span data-ttu-id="028e6-1097">CalculatorPercentage</span><span class="sxs-lookup"><span data-stu-id="028e6-1097">CalculatorPercentage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94D.png" width="32" height="32" alt="CalculatorNegate" /></td>
  <td><span data-ttu-id="028e6-1098">E94D</span><span class="sxs-lookup"><span data-stu-id="028e6-1098">E94D</span></span></td>
  <td><span data-ttu-id="028e6-1099">CalculatorNegate</span><span class="sxs-lookup"><span data-stu-id="028e6-1099">CalculatorNegate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94E.png" width="32" height="32" alt="CalculatorEqualTo" /></td>
  <td><span data-ttu-id="028e6-1100">E94E</span><span class="sxs-lookup"><span data-stu-id="028e6-1100">E94E</span></span></td>
  <td><span data-ttu-id="028e6-1101">CalculatorEqualTo</span><span class="sxs-lookup"><span data-stu-id="028e6-1101">CalculatorEqualTo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94F.png" width="32" height="32" alt="CalculatorBackspace" /></td>
  <td><span data-ttu-id="028e6-1102">E94F</span><span class="sxs-lookup"><span data-stu-id="028e6-1102">E94F</span></span></td>
  <td><span data-ttu-id="028e6-1103">CalculatorBackspace</span><span class="sxs-lookup"><span data-stu-id="028e6-1103">CalculatorBackspace</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E950.png" width="32" height="32" alt="Component" /></td>
  <td><span data-ttu-id="028e6-1104">E950</span><span class="sxs-lookup"><span data-stu-id="028e6-1104">E950</span></span></td>
  <td><span data-ttu-id="028e6-1105">Component</span><span class="sxs-lookup"><span data-stu-id="028e6-1105">Component</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E951.png" width="32" height="32" alt="DMC" /></td>
  <td><span data-ttu-id="028e6-1106">E951</span><span class="sxs-lookup"><span data-stu-id="028e6-1106">E951</span></span></td>
  <td><span data-ttu-id="028e6-1107">DMC</span><span class="sxs-lookup"><span data-stu-id="028e6-1107">DMC</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E952.png" width="32" height="32" alt="Dock" /></td>
  <td><span data-ttu-id="028e6-1108">E952</span><span class="sxs-lookup"><span data-stu-id="028e6-1108">E952</span></span></td>
  <td><span data-ttu-id="028e6-1109">Dock</span><span class="sxs-lookup"><span data-stu-id="028e6-1109">Dock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E953.png" width="32" height="32" alt="MultimediaDMS" /></td>
  <td><span data-ttu-id="028e6-1110">E953</span><span class="sxs-lookup"><span data-stu-id="028e6-1110">E953</span></span></td>
  <td><span data-ttu-id="028e6-1111">MultimediaDMS</span><span class="sxs-lookup"><span data-stu-id="028e6-1111">MultimediaDMS</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E954.png" width="32" height="32" alt="MultimediaDVR" /></td>
  <td><span data-ttu-id="028e6-1112">E954</span><span class="sxs-lookup"><span data-stu-id="028e6-1112">E954</span></span></td>
  <td><span data-ttu-id="028e6-1113">MultimediaDVR</span><span class="sxs-lookup"><span data-stu-id="028e6-1113">MultimediaDVR</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E955.png" width="32" height="32" alt="MultimediaPMP" /></td>
  <td><span data-ttu-id="028e6-1114">E955</span><span class="sxs-lookup"><span data-stu-id="028e6-1114">E955</span></span></td>
  <td><span data-ttu-id="028e6-1115">MultimediaPMP</span><span class="sxs-lookup"><span data-stu-id="028e6-1115">MultimediaPMP</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E956.png" width="32" height="32" alt="PrintfaxPrinterFile" /></td>
  <td><span data-ttu-id="028e6-1116">E956</span><span class="sxs-lookup"><span data-stu-id="028e6-1116">E956</span></span></td>
  <td><span data-ttu-id="028e6-1117">PrintfaxPrinterFile</span><span class="sxs-lookup"><span data-stu-id="028e6-1117">PrintfaxPrinterFile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E957.png" width="32" height="32" alt="Sensor" /></td>
  <td><span data-ttu-id="028e6-1118">E957</span><span class="sxs-lookup"><span data-stu-id="028e6-1118">E957</span></span></td>
  <td><span data-ttu-id="028e6-1119">Sensor</span><span class="sxs-lookup"><span data-stu-id="028e6-1119">Sensor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E958.png" width="32" height="32" alt="StorageOptical" /></td>
  <td><span data-ttu-id="028e6-1120">E958</span><span class="sxs-lookup"><span data-stu-id="028e6-1120">E958</span></span></td>
  <td><span data-ttu-id="028e6-1121">StorageOptical</span><span class="sxs-lookup"><span data-stu-id="028e6-1121">StorageOptical</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E95A.png" width="32" height="32" alt="Communications" /></td>
  <td><span data-ttu-id="028e6-1122">E95A</span><span class="sxs-lookup"><span data-stu-id="028e6-1122">E95A</span></span></td>
  <td><span data-ttu-id="028e6-1123">Communications</span><span class="sxs-lookup"><span data-stu-id="028e6-1123">Communications</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E95B.png" width="32" height="32" alt="Headset" /></td>
  <td><span data-ttu-id="028e6-1124">E95B</span><span class="sxs-lookup"><span data-stu-id="028e6-1124">E95B</span></span></td>
  <td><span data-ttu-id="028e6-1125">Headset</span><span class="sxs-lookup"><span data-stu-id="028e6-1125">Headset</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E95D.png" width="32" height="32" alt="Projector" /></td>
  <td><span data-ttu-id="028e6-1126">E95D</span><span class="sxs-lookup"><span data-stu-id="028e6-1126">E95D</span></span></td>
  <td><span data-ttu-id="028e6-1127">Projector</span><span class="sxs-lookup"><span data-stu-id="028e6-1127">Projector</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E95E.png" width="32" height="32" alt="Health" /></td>
  <td><span data-ttu-id="028e6-1128">E95E</span><span class="sxs-lookup"><span data-stu-id="028e6-1128">E95E</span></span></td>
  <td><span data-ttu-id="028e6-1129">Health</span><span class="sxs-lookup"><span data-stu-id="028e6-1129">Health</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E960.png" width="32" height="32" alt="Webcam2" /></td>
  <td><span data-ttu-id="028e6-1130">E960</span><span class="sxs-lookup"><span data-stu-id="028e6-1130">E960</span></span></td>
  <td><span data-ttu-id="028e6-1131">Webcam2</span><span class="sxs-lookup"><span data-stu-id="028e6-1131">Webcam2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E961.png" width="32" height="32" alt="Input" /></td>
  <td><span data-ttu-id="028e6-1132">E961</span><span class="sxs-lookup"><span data-stu-id="028e6-1132">E961</span></span></td>
  <td><span data-ttu-id="028e6-1133">Input</span><span class="sxs-lookup"><span data-stu-id="028e6-1133">Input</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E962.png" width="32" height="32" alt="Mouse" /></td>
  <td><span data-ttu-id="028e6-1134">E962</span><span class="sxs-lookup"><span data-stu-id="028e6-1134">E962</span></span></td>
  <td><span data-ttu-id="028e6-1135">Mouse</span><span class="sxs-lookup"><span data-stu-id="028e6-1135">Mouse</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E963.png" width="32" height="32" alt="Smartcard" /></td>
  <td><span data-ttu-id="028e6-1136">E963</span><span class="sxs-lookup"><span data-stu-id="028e6-1136">E963</span></span></td>
  <td><span data-ttu-id="028e6-1137">Smartcard</span><span class="sxs-lookup"><span data-stu-id="028e6-1137">Smartcard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E964.png" width="32" height="32" alt="SmartcardVirtual" /></td>
  <td><span data-ttu-id="028e6-1138">E964</span><span class="sxs-lookup"><span data-stu-id="028e6-1138">E964</span></span></td>
  <td><span data-ttu-id="028e6-1139">SmartcardVirtual</span><span class="sxs-lookup"><span data-stu-id="028e6-1139">SmartcardVirtual</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E965.png" width="32" height="32" alt="MediaStorageTower" /></td>
  <td><span data-ttu-id="028e6-1140">E965</span><span class="sxs-lookup"><span data-stu-id="028e6-1140">E965</span></span></td>
  <td><span data-ttu-id="028e6-1141">MediaStorageTower</span><span class="sxs-lookup"><span data-stu-id="028e6-1141">MediaStorageTower</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E966.png" width="32" height="32" alt="ReturnKeySm" /></td>
  <td><span data-ttu-id="028e6-1142">E966</span><span class="sxs-lookup"><span data-stu-id="028e6-1142">E966</span></span></td>
  <td><span data-ttu-id="028e6-1143">ReturnKeySm</span><span class="sxs-lookup"><span data-stu-id="028e6-1143">ReturnKeySm</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E967.png" width="32" height="32" alt="GameConsole" /></td>
  <td><span data-ttu-id="028e6-1144">E967</span><span class="sxs-lookup"><span data-stu-id="028e6-1144">E967</span></span></td>
  <td><span data-ttu-id="028e6-1145">GameConsole</span><span class="sxs-lookup"><span data-stu-id="028e6-1145">GameConsole</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E968.png" width="32" height="32" alt="Network" /></td>
  <td><span data-ttu-id="028e6-1146">E968</span><span class="sxs-lookup"><span data-stu-id="028e6-1146">E968</span></span></td>
  <td><span data-ttu-id="028e6-1147">Network</span><span class="sxs-lookup"><span data-stu-id="028e6-1147">Network</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E969.png" width="32" height="32" alt="StorageNetworkWireless" /></td>
  <td><span data-ttu-id="028e6-1148">E969</span><span class="sxs-lookup"><span data-stu-id="028e6-1148">E969</span></span></td>
  <td><span data-ttu-id="028e6-1149">StorageNetworkWireless</span><span class="sxs-lookup"><span data-stu-id="028e6-1149">StorageNetworkWireless</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E96A.png" width="32" height="32" alt="StorageTape" /></td>
  <td><span data-ttu-id="028e6-1150">E96A</span><span class="sxs-lookup"><span data-stu-id="028e6-1150">E96A</span></span></td>
  <td><span data-ttu-id="028e6-1151">StorageTape</span><span class="sxs-lookup"><span data-stu-id="028e6-1151">StorageTape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E96D.png" width="32" height="32" alt="ChevronUpSmall" /></td>
  <td><span data-ttu-id="028e6-1152">E96D</span><span class="sxs-lookup"><span data-stu-id="028e6-1152">E96D</span></span></td>
  <td><span data-ttu-id="028e6-1153">ChevronUpSmall</span><span class="sxs-lookup"><span data-stu-id="028e6-1153">ChevronUpSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E96E.png" width="32" height="32" alt="ChevronDownSmall" /></td>
  <td><span data-ttu-id="028e6-1154">E96E</span><span class="sxs-lookup"><span data-stu-id="028e6-1154">E96E</span></span></td>
  <td><span data-ttu-id="028e6-1155">ChevronDownSmall</span><span class="sxs-lookup"><span data-stu-id="028e6-1155">ChevronDownSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E96F.png" width="32" height="32" alt="ChevronLeftSmall" /></td>
  <td><span data-ttu-id="028e6-1156">E96F</span><span class="sxs-lookup"><span data-stu-id="028e6-1156">E96F</span></span></td>
  <td><span data-ttu-id="028e6-1157">ChevronLeftSmall</span><span class="sxs-lookup"><span data-stu-id="028e6-1157">ChevronLeftSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E970.png" width="32" height="32" alt="ChevronRightSmall" /></td>
  <td><span data-ttu-id="028e6-1158">E970</span><span class="sxs-lookup"><span data-stu-id="028e6-1158">E970</span></span></td>
  <td><span data-ttu-id="028e6-1159">ChevronRightSmall</span><span class="sxs-lookup"><span data-stu-id="028e6-1159">ChevronRightSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E971.png" width="32" height="32" alt="ChevronUpMed" /></td>
  <td><span data-ttu-id="028e6-1160">E971</span><span class="sxs-lookup"><span data-stu-id="028e6-1160">E971</span></span></td>
  <td><span data-ttu-id="028e6-1161">ChevronUpMed</span><span class="sxs-lookup"><span data-stu-id="028e6-1161">ChevronUpMed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E972.png" width="32" height="32" alt="ChevronDownMed" /></td>
  <td><span data-ttu-id="028e6-1162">E972</span><span class="sxs-lookup"><span data-stu-id="028e6-1162">E972</span></span></td>
  <td><span data-ttu-id="028e6-1163">ChevronDownMed</span><span class="sxs-lookup"><span data-stu-id="028e6-1163">ChevronDownMed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E973.png" width="32" height="32" alt="ChevronLeftMed" /></td>
  <td><span data-ttu-id="028e6-1164">E973</span><span class="sxs-lookup"><span data-stu-id="028e6-1164">E973</span></span></td>
  <td><span data-ttu-id="028e6-1165">ChevronLeftMed</span><span class="sxs-lookup"><span data-stu-id="028e6-1165">ChevronLeftMed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E974.png" width="32" height="32" alt="ChevronRightMed" /></td>
  <td><span data-ttu-id="028e6-1166">E974</span><span class="sxs-lookup"><span data-stu-id="028e6-1166">E974</span></span></td>
  <td><span data-ttu-id="028e6-1167">ChevronRightMed</span><span class="sxs-lookup"><span data-stu-id="028e6-1167">ChevronRightMed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E975.png" width="32" height="32" alt="Devices2" /></td>
  <td><span data-ttu-id="028e6-1168">E975</span><span class="sxs-lookup"><span data-stu-id="028e6-1168">E975</span></span></td>
  <td><span data-ttu-id="028e6-1169">Devices2</span><span class="sxs-lookup"><span data-stu-id="028e6-1169">Devices2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E976.png" width="32" height="32" alt="ExpandTile" /></td>
  <td><span data-ttu-id="028e6-1170">E976</span><span class="sxs-lookup"><span data-stu-id="028e6-1170">E976</span></span></td>
  <td><span data-ttu-id="028e6-1171">ExpandTile</span><span class="sxs-lookup"><span data-stu-id="028e6-1171">ExpandTile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E977.png" width="32" height="32" alt="PC1" /></td>
  <td><span data-ttu-id="028e6-1172">E977</span><span class="sxs-lookup"><span data-stu-id="028e6-1172">E977</span></span></td>
  <td><span data-ttu-id="028e6-1173">PC1</span><span class="sxs-lookup"><span data-stu-id="028e6-1173">PC1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E978.png" width="32" height="32" alt="PresenceChicklet" /></td>
  <td><span data-ttu-id="028e6-1174">E978</span><span class="sxs-lookup"><span data-stu-id="028e6-1174">E978</span></span></td>
  <td><span data-ttu-id="028e6-1175">PresenceChicklet</span><span class="sxs-lookup"><span data-stu-id="028e6-1175">PresenceChicklet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E979.png" width="32" height="32" alt="PresenceChickletVideo" /></td>
  <td><span data-ttu-id="028e6-1176">E979</span><span class="sxs-lookup"><span data-stu-id="028e6-1176">E979</span></span></td>
  <td><span data-ttu-id="028e6-1177">PresenceChickletVideo</span><span class="sxs-lookup"><span data-stu-id="028e6-1177">PresenceChickletVideo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97A.png" width="32" height="32" alt="Reply" /></td>
  <td><span data-ttu-id="028e6-1178">E97A</span><span class="sxs-lookup"><span data-stu-id="028e6-1178">E97A</span></span></td>
  <td><span data-ttu-id="028e6-1179">Reply</span><span class="sxs-lookup"><span data-stu-id="028e6-1179">Reply</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97B.png" width="32" height="32" alt="SetTile" /></td>
  <td><span data-ttu-id="028e6-1180">E97B</span><span class="sxs-lookup"><span data-stu-id="028e6-1180">E97B</span></span></td>
  <td><span data-ttu-id="028e6-1181">SetTile</span><span class="sxs-lookup"><span data-stu-id="028e6-1181">SetTile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97C.png" width="32" height="32" alt="Type" /></td>
  <td><span data-ttu-id="028e6-1182">E97C</span><span class="sxs-lookup"><span data-stu-id="028e6-1182">E97C</span></span></td>
  <td><span data-ttu-id="028e6-1183">Type</span><span class="sxs-lookup"><span data-stu-id="028e6-1183">Type</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97D.png" width="32" height="32" alt="Korean" /></td>
  <td><span data-ttu-id="028e6-1184">E97D</span><span class="sxs-lookup"><span data-stu-id="028e6-1184">E97D</span></span></td>
  <td><span data-ttu-id="028e6-1185">Korean</span><span class="sxs-lookup"><span data-stu-id="028e6-1185">Korean</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97E.png" width="32" height="32" alt="HalfAlpha" /></td>
  <td><span data-ttu-id="028e6-1186">E97E</span><span class="sxs-lookup"><span data-stu-id="028e6-1186">E97E</span></span></td>
  <td><span data-ttu-id="028e6-1187">HalfAlpha</span><span class="sxs-lookup"><span data-stu-id="028e6-1187">HalfAlpha</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97F.png" width="32" height="32" alt="FullAlpha" /></td>
  <td><span data-ttu-id="028e6-1188">E97F</span><span class="sxs-lookup"><span data-stu-id="028e6-1188">E97F</span></span></td>
  <td><span data-ttu-id="028e6-1189">FullAlpha</span><span class="sxs-lookup"><span data-stu-id="028e6-1189">FullAlpha</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E980.png" width="32" height="32" alt="Key12On" /></td>
  <td><span data-ttu-id="028e6-1190">E980</span><span class="sxs-lookup"><span data-stu-id="028e6-1190">E980</span></span></td>
  <td><span data-ttu-id="028e6-1191">Key12On</span><span class="sxs-lookup"><span data-stu-id="028e6-1191">Key12On</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E981.png" width="32" height="32" alt="ChineseChangjie" /></td>
  <td><span data-ttu-id="028e6-1192">E981</span><span class="sxs-lookup"><span data-stu-id="028e6-1192">E981</span></span></td>
  <td><span data-ttu-id="028e6-1193">ChineseChangjie</span><span class="sxs-lookup"><span data-stu-id="028e6-1193">ChineseChangjie</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E982.png" width="32" height="32" alt="QWERTYOn" /></td>
  <td><span data-ttu-id="028e6-1194">E982</span><span class="sxs-lookup"><span data-stu-id="028e6-1194">E982</span></span></td>
  <td><span data-ttu-id="028e6-1195">QWERTYOn</span><span class="sxs-lookup"><span data-stu-id="028e6-1195">QWERTYOn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E983.png" width="32" height="32" alt="QWERTYOff" /></td>
  <td><span data-ttu-id="028e6-1196">E983</span><span class="sxs-lookup"><span data-stu-id="028e6-1196">E983</span></span></td>
  <td><span data-ttu-id="028e6-1197">QWERTYOff</span><span class="sxs-lookup"><span data-stu-id="028e6-1197">QWERTYOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E984.png" width="32" height="32" alt="ChineseQuick" /></td>
  <td><span data-ttu-id="028e6-1198">E984</span><span class="sxs-lookup"><span data-stu-id="028e6-1198">E984</span></span></td>
  <td><span data-ttu-id="028e6-1199">ChineseQuick</span><span class="sxs-lookup"><span data-stu-id="028e6-1199">ChineseQuick</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E985.png" width="32" height="32" alt="Japanese" /></td>
  <td><span data-ttu-id="028e6-1200">E985</span><span class="sxs-lookup"><span data-stu-id="028e6-1200">E985</span></span></td>
  <td><span data-ttu-id="028e6-1201">Japanese</span><span class="sxs-lookup"><span data-stu-id="028e6-1201">Japanese</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E986.png" width="32" height="32" alt="FullHiragana" /></td>
  <td><span data-ttu-id="028e6-1202">E986</span><span class="sxs-lookup"><span data-stu-id="028e6-1202">E986</span></span></td>
  <td><span data-ttu-id="028e6-1203">FullHiragana</span><span class="sxs-lookup"><span data-stu-id="028e6-1203">FullHiragana</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E987.png" width="32" height="32" alt="FullKatakana" /></td>
  <td><span data-ttu-id="028e6-1204">E987</span><span class="sxs-lookup"><span data-stu-id="028e6-1204">E987</span></span></td>
  <td><span data-ttu-id="028e6-1205">FullKatakana</span><span class="sxs-lookup"><span data-stu-id="028e6-1205">FullKatakana</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E988.png" width="32" height="32" alt="HalfKatakana" /></td>
  <td><span data-ttu-id="028e6-1206">E988</span><span class="sxs-lookup"><span data-stu-id="028e6-1206">E988</span></span></td>
  <td><span data-ttu-id="028e6-1207">HalfKatakana</span><span class="sxs-lookup"><span data-stu-id="028e6-1207">HalfKatakana</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E989.png" width="32" height="32" alt="ChineseBoPoMoFo" /></td>
  <td><span data-ttu-id="028e6-1208">E989</span><span class="sxs-lookup"><span data-stu-id="028e6-1208">E989</span></span></td>
  <td><span data-ttu-id="028e6-1209">ChineseBoPoMoFo</span><span class="sxs-lookup"><span data-stu-id="028e6-1209">ChineseBoPoMoFo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E98A.png" width="32" height="32" alt="ChinesePinyin" /></td>
  <td><span data-ttu-id="028e6-1210">E98A</span><span class="sxs-lookup"><span data-stu-id="028e6-1210">E98A</span></span></td>
  <td><span data-ttu-id="028e6-1211">ChinesePinyin</span><span class="sxs-lookup"><span data-stu-id="028e6-1211">ChinesePinyin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E98F.png" width="32" height="32" alt="ConstructionCone" /></td>
  <td><span data-ttu-id="028e6-1212">E98F</span><span class="sxs-lookup"><span data-stu-id="028e6-1212">E98F</span></span></td>
  <td><span data-ttu-id="028e6-1213">ConstructionCone</span><span class="sxs-lookup"><span data-stu-id="028e6-1213">ConstructionCone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E990.png" width="32" height="32" alt="XboxOneConsole" /></td>
  <td><span data-ttu-id="028e6-1214">E990</span><span class="sxs-lookup"><span data-stu-id="028e6-1214">E990</span></span></td>
  <td><span data-ttu-id="028e6-1215">XboxOneConsole</span><span class="sxs-lookup"><span data-stu-id="028e6-1215">XboxOneConsole</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E992.png" width="32" height="32" alt="Volume0" /></td>
  <td><span data-ttu-id="028e6-1216">E992</span><span class="sxs-lookup"><span data-stu-id="028e6-1216">E992</span></span></td>
  <td><span data-ttu-id="028e6-1217">Volume0</span><span class="sxs-lookup"><span data-stu-id="028e6-1217">Volume0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E993.png" width="32" height="32" alt="Volume1" /></td>
  <td><span data-ttu-id="028e6-1218">E993</span><span class="sxs-lookup"><span data-stu-id="028e6-1218">E993</span></span></td>
  <td><span data-ttu-id="028e6-1219">Volume1</span><span class="sxs-lookup"><span data-stu-id="028e6-1219">Volume1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E994.png" width="32" height="32" alt="Volume2" /></td>
  <td><span data-ttu-id="028e6-1220">E994</span><span class="sxs-lookup"><span data-stu-id="028e6-1220">E994</span></span></td>
  <td><span data-ttu-id="028e6-1221">Volume2</span><span class="sxs-lookup"><span data-stu-id="028e6-1221">Volume2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E995.png" width="32" height="32" alt="Volume3" /></td>
  <td><span data-ttu-id="028e6-1222">E995</span><span class="sxs-lookup"><span data-stu-id="028e6-1222">E995</span></span></td>
  <td><span data-ttu-id="028e6-1223">Volume3</span><span class="sxs-lookup"><span data-stu-id="028e6-1223">Volume3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E996.png" width="32" height="32" alt="BatteryUnknown" /></td>
  <td><span data-ttu-id="028e6-1224">E996</span><span class="sxs-lookup"><span data-stu-id="028e6-1224">E996</span></span></td>
  <td><span data-ttu-id="028e6-1225">BatteryUnknown</span><span class="sxs-lookup"><span data-stu-id="028e6-1225">BatteryUnknown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E998.png" width="32" height="32" alt="WifiAttentionOverlay" /></td>
  <td><span data-ttu-id="028e6-1226">E998</span><span class="sxs-lookup"><span data-stu-id="028e6-1226">E998</span></span></td>
  <td><span data-ttu-id="028e6-1227">WifiAttentionOverlay</span><span class="sxs-lookup"><span data-stu-id="028e6-1227">WifiAttentionOverlay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E99A.png" width="32" height="32" alt="Robot" /></td>
  <td><span data-ttu-id="028e6-1228">E99A</span><span class="sxs-lookup"><span data-stu-id="028e6-1228">E99A</span></span></td>
  <td><span data-ttu-id="028e6-1229">Robot</span><span class="sxs-lookup"><span data-stu-id="028e6-1229">Robot</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9A1.png" width="32" height="32" alt="TapAndSend" /></td>
  <td><span data-ttu-id="028e6-1230">E9A1</span><span class="sxs-lookup"><span data-stu-id="028e6-1230">E9A1</span></span></td>
  <td><span data-ttu-id="028e6-1231">TapAndSend</span><span class="sxs-lookup"><span data-stu-id="028e6-1231">TapAndSend</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9A6.png" width="32" height="32" alt="FitPage" /></td>
  <td><span data-ttu-id="028e6-1232">E9A6</span><span class="sxs-lookup"><span data-stu-id="028e6-1232">E9A6</span></span></td>
  <td><span data-ttu-id="028e6-1233">FitPage</span><span class="sxs-lookup"><span data-stu-id="028e6-1233">FitPage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9A8.png" width="32" height="32" alt="PasswordKeyShow" /></td>
  <td><span data-ttu-id="028e6-1234">E9A8</span><span class="sxs-lookup"><span data-stu-id="028e6-1234">E9A8</span></span></td>
  <td><span data-ttu-id="028e6-1235">PasswordKeyShow</span><span class="sxs-lookup"><span data-stu-id="028e6-1235">PasswordKeyShow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9A9.png" width="32" height="32" alt="PasswordKeyHide" /></td>
  <td><span data-ttu-id="028e6-1236">E9A9</span><span class="sxs-lookup"><span data-stu-id="028e6-1236">E9A9</span></span></td>
  <td><span data-ttu-id="028e6-1237">PasswordKeyHide</span><span class="sxs-lookup"><span data-stu-id="028e6-1237">PasswordKeyHide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AA.png" width="32" height="32" alt="BidiLtr" /></td>
  <td><span data-ttu-id="028e6-1238">E9AA</span><span class="sxs-lookup"><span data-stu-id="028e6-1238">E9AA</span></span></td>
  <td><span data-ttu-id="028e6-1239">BidiLtr</span><span class="sxs-lookup"><span data-stu-id="028e6-1239">BidiLtr</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AB.png" width="32" height="32" alt="BidiRtl" /></td>
  <td><span data-ttu-id="028e6-1240">E9AB</span><span class="sxs-lookup"><span data-stu-id="028e6-1240">E9AB</span></span></td>
  <td><span data-ttu-id="028e6-1241">BidiRtl</span><span class="sxs-lookup"><span data-stu-id="028e6-1241">BidiRtl</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AC.png" width="32" height="32" alt="ForwardSm" /></td>
  <td><span data-ttu-id="028e6-1242">E9AC</span><span class="sxs-lookup"><span data-stu-id="028e6-1242">E9AC</span></span></td>
  <td><span data-ttu-id="028e6-1243">ForwardSm</span><span class="sxs-lookup"><span data-stu-id="028e6-1243">ForwardSm</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AD.png" width="32" height="32" alt="CommaKey" /></td>
  <td><span data-ttu-id="028e6-1244">E9AD</span><span class="sxs-lookup"><span data-stu-id="028e6-1244">E9AD</span></span></td>
  <td><span data-ttu-id="028e6-1245">CommaKey</span><span class="sxs-lookup"><span data-stu-id="028e6-1245">CommaKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AE.png" width="32" height="32" alt="DashKey" /></td>
  <td><span data-ttu-id="028e6-1246">E9AE</span><span class="sxs-lookup"><span data-stu-id="028e6-1246">E9AE</span></span></td>
  <td><span data-ttu-id="028e6-1247">DashKey</span><span class="sxs-lookup"><span data-stu-id="028e6-1247">DashKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AF.png" width="32" height="32" alt="DullSoundKey" /></td>
  <td><span data-ttu-id="028e6-1248">E9AF</span><span class="sxs-lookup"><span data-stu-id="028e6-1248">E9AF</span></span></td>
  <td><span data-ttu-id="028e6-1249">DullSoundKey</span><span class="sxs-lookup"><span data-stu-id="028e6-1249">DullSoundKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B0.png" width="32" height="32" alt="HalfDullSound" /></td>
  <td><span data-ttu-id="028e6-1250">E9B0</span><span class="sxs-lookup"><span data-stu-id="028e6-1250">E9B0</span></span></td>
  <td><span data-ttu-id="028e6-1251">HalfDullSound</span><span class="sxs-lookup"><span data-stu-id="028e6-1251">HalfDullSound</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B1.png" width="32" height="32" alt="RightDoubleQuote" /></td>
  <td><span data-ttu-id="028e6-1252">E9B1</span><span class="sxs-lookup"><span data-stu-id="028e6-1252">E9B1</span></span></td>
  <td><span data-ttu-id="028e6-1253">RightDoubleQuote</span><span class="sxs-lookup"><span data-stu-id="028e6-1253">RightDoubleQuote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B2.png" width="32" height="32" alt="LeftDoubleQuote" /></td>
  <td><span data-ttu-id="028e6-1254">E9B2</span><span class="sxs-lookup"><span data-stu-id="028e6-1254">E9B2</span></span></td>
  <td><span data-ttu-id="028e6-1255">LeftDoubleQuote</span><span class="sxs-lookup"><span data-stu-id="028e6-1255">LeftDoubleQuote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B3.png" width="32" height="32" alt="PuncKeyRightBottom" /></td>
  <td><span data-ttu-id="028e6-1256">E9B3</span><span class="sxs-lookup"><span data-stu-id="028e6-1256">E9B3</span></span></td>
  <td><span data-ttu-id="028e6-1257">PuncKeyRightBottom</span><span class="sxs-lookup"><span data-stu-id="028e6-1257">PuncKeyRightBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B4.png" width="32" height="32" alt="PuncKey1" /></td>
  <td><span data-ttu-id="028e6-1258">E9B4</span><span class="sxs-lookup"><span data-stu-id="028e6-1258">E9B4</span></span></td>
  <td><span data-ttu-id="028e6-1259">PuncKey1</span><span class="sxs-lookup"><span data-stu-id="028e6-1259">PuncKey1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B5.png" width="32" height="32" alt="PuncKey2" /></td>
  <td><span data-ttu-id="028e6-1260">E9B5</span><span class="sxs-lookup"><span data-stu-id="028e6-1260">E9B5</span></span></td>
  <td><span data-ttu-id="028e6-1261">PuncKey2</span><span class="sxs-lookup"><span data-stu-id="028e6-1261">PuncKey2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B6.png" width="32" height="32" alt="PuncKey3" /></td>
  <td><span data-ttu-id="028e6-1262">E9B6</span><span class="sxs-lookup"><span data-stu-id="028e6-1262">E9B6</span></span></td>
  <td><span data-ttu-id="028e6-1263">PuncKey3</span><span class="sxs-lookup"><span data-stu-id="028e6-1263">PuncKey3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B7.png" width="32" height="32" alt="PuncKey4" /></td>
  <td><span data-ttu-id="028e6-1264">E9B7</span><span class="sxs-lookup"><span data-stu-id="028e6-1264">E9B7</span></span></td>
  <td><span data-ttu-id="028e6-1265">PuncKey4</span><span class="sxs-lookup"><span data-stu-id="028e6-1265">PuncKey4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B8.png" width="32" height="32" alt="PuncKey5" /></td>
  <td><span data-ttu-id="028e6-1266">E9B8</span><span class="sxs-lookup"><span data-stu-id="028e6-1266">E9B8</span></span></td>
  <td><span data-ttu-id="028e6-1267">PuncKey5</span><span class="sxs-lookup"><span data-stu-id="028e6-1267">PuncKey5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B9.png" width="32" height="32" alt="PuncKey6" /></td>
  <td><span data-ttu-id="028e6-1268">E9B9</span><span class="sxs-lookup"><span data-stu-id="028e6-1268">E9B9</span></span></td>
  <td><span data-ttu-id="028e6-1269">PuncKey6</span><span class="sxs-lookup"><span data-stu-id="028e6-1269">PuncKey6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9BA.png" width="32" height="32" alt="PuncKey9" /></td>
  <td><span data-ttu-id="028e6-1270">E9BA</span><span class="sxs-lookup"><span data-stu-id="028e6-1270">E9BA</span></span></td>
  <td><span data-ttu-id="028e6-1271">PuncKey9</span><span class="sxs-lookup"><span data-stu-id="028e6-1271">PuncKey9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9BB.png" width="32" height="32" alt="PuncKey7" /></td>
  <td><span data-ttu-id="028e6-1272">E9BB</span><span class="sxs-lookup"><span data-stu-id="028e6-1272">E9BB</span></span></td>
  <td><span data-ttu-id="028e6-1273">PuncKey7</span><span class="sxs-lookup"><span data-stu-id="028e6-1273">PuncKey7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9BC.png" width="32" height="32" alt="PuncKey8" /></td>
  <td><span data-ttu-id="028e6-1274">E9BC</span><span class="sxs-lookup"><span data-stu-id="028e6-1274">E9BC</span></span></td>
  <td><span data-ttu-id="028e6-1275">PuncKey8</span><span class="sxs-lookup"><span data-stu-id="028e6-1275">PuncKey8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9CA.png" width="32" height="32" alt="Frigid" /></td>
  <td><span data-ttu-id="028e6-1276">E9CA</span><span class="sxs-lookup"><span data-stu-id="028e6-1276">E9CA</span></span></td>
  <td><span data-ttu-id="028e6-1277">Frigid</span><span class="sxs-lookup"><span data-stu-id="028e6-1277">Frigid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9CE.png" width="32" height="32" alt="Unknown" /></td>
  <td><span data-ttu-id="028e6-1278">E9CE</span><span class="sxs-lookup"><span data-stu-id="028e6-1278">E9CE</span></span></td>
  <td><span data-ttu-id="028e6-1279">Unknown</span><span class="sxs-lookup"><span data-stu-id="028e6-1279">Unknown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9D2.png" width="32" height="32" alt="AreaChart" /></td>
  <td><span data-ttu-id="028e6-1280">E9D2</span><span class="sxs-lookup"><span data-stu-id="028e6-1280">E9D2</span></span></td>
  <td><span data-ttu-id="028e6-1281">AreaChart</span><span class="sxs-lookup"><span data-stu-id="028e6-1281">AreaChart</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9D5.png" width="32" height="32" alt="CheckList" /></td>
  <td><span data-ttu-id="028e6-1282">E9D5</span><span class="sxs-lookup"><span data-stu-id="028e6-1282">E9D5</span></span></td>
  <td><span data-ttu-id="028e6-1283">チェックリスト</span><span class="sxs-lookup"><span data-stu-id="028e6-1283">CheckList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9D9.png" width="32" height="32" alt="Diagnostic" /></td>
  <td><span data-ttu-id="028e6-1284">E9D9</span><span class="sxs-lookup"><span data-stu-id="028e6-1284">E9D9</span></span></td>
  <td><span data-ttu-id="028e6-1285">Diagnostic</span><span class="sxs-lookup"><span data-stu-id="028e6-1285">Diagnostic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9E9.png" width="32" height="32" alt="Equalizer" /></td>
  <td><span data-ttu-id="028e6-1286">E9E9</span><span class="sxs-lookup"><span data-stu-id="028e6-1286">E9E9</span></span></td>
  <td><span data-ttu-id="028e6-1287">イコライザー</span><span class="sxs-lookup"><span data-stu-id="028e6-1287">Equalizer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9F3.png" width="32" height="32" alt="Process" /></td>
  <td><span data-ttu-id="028e6-1288">E9F3</span><span class="sxs-lookup"><span data-stu-id="028e6-1288">E9F3</span></span></td>
  <td><span data-ttu-id="028e6-1289">Process</span><span class="sxs-lookup"><span data-stu-id="028e6-1289">Process</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9F5.png" width="32" height="32" alt="Processing" /></td>
  <td><span data-ttu-id="028e6-1290">E9F5</span><span class="sxs-lookup"><span data-stu-id="028e6-1290">E9F5</span></span></td>
  <td><span data-ttu-id="028e6-1291">Processing</span><span class="sxs-lookup"><span data-stu-id="028e6-1291">Processing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9F9.png" width="32" height="32" alt="ReportDocument" /></td>
  <td><span data-ttu-id="028e6-1292">E9F9</span><span class="sxs-lookup"><span data-stu-id="028e6-1292">E9F9</span></span></td>
  <td><span data-ttu-id="028e6-1293">ReportDocument</span><span class="sxs-lookup"><span data-stu-id="028e6-1293">ReportDocument</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA0C.png" width="32" height="32" alt="VideoSolid" /></td>
  <td><span data-ttu-id="028e6-1294">EA0C</span><span class="sxs-lookup"><span data-stu-id="028e6-1294">EA0C</span></span></td>
  <td><span data-ttu-id="028e6-1295">VideoSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1295">VideoSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA14.png" width="32" height="32" alt="DisconnectDisplay" /></td>
  <td><span data-ttu-id="028e6-1296">EA14</span><span class="sxs-lookup"><span data-stu-id="028e6-1296">EA14</span></span></td>
  <td><span data-ttu-id="028e6-1297">DisconnectDisplay</span><span class="sxs-lookup"><span data-stu-id="028e6-1297">DisconnectDisplay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA18.png" width="32" height="32" alt="Shield" /></td>
  <td><span data-ttu-id="028e6-1298">EA18</span><span class="sxs-lookup"><span data-stu-id="028e6-1298">EA18</span></span></td>
  <td><span data-ttu-id="028e6-1299">盾</span><span class="sxs-lookup"><span data-stu-id="028e6-1299">Shield</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA1F.png" width="32" height="32" alt="Info2" /></td>
  <td><span data-ttu-id="028e6-1300">EA1F</span><span class="sxs-lookup"><span data-stu-id="028e6-1300">EA1F</span></span></td>
  <td><span data-ttu-id="028e6-1301">Info2</span><span class="sxs-lookup"><span data-stu-id="028e6-1301">Info2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA21.png" width="32" height="32" alt="ActionCenterAsterisk" /></td>
  <td><span data-ttu-id="028e6-1302">EA21</span><span class="sxs-lookup"><span data-stu-id="028e6-1302">EA21</span></span></td>
  <td><span data-ttu-id="028e6-1303">ActionCenterAsterisk</span><span class="sxs-lookup"><span data-stu-id="028e6-1303">ActionCenterAsterisk</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA24.png" width="32" height="32" alt="Beta" /></td>
  <td><span data-ttu-id="028e6-1304">EA24</span><span class="sxs-lookup"><span data-stu-id="028e6-1304">EA24</span></span></td>
  <td><span data-ttu-id="028e6-1305">Beta</span><span class="sxs-lookup"><span data-stu-id="028e6-1305">Beta</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA35.png" width="32" height="32" alt="SaveCopy" /></td>
  <td><span data-ttu-id="028e6-1306">EA35</span><span class="sxs-lookup"><span data-stu-id="028e6-1306">EA35</span></span></td>
  <td><span data-ttu-id="028e6-1307">SaveCopy</span><span class="sxs-lookup"><span data-stu-id="028e6-1307">SaveCopy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA37.png" width="32" height="32" alt="List" /></td>
  <td><span data-ttu-id="028e6-1308">EA37</span><span class="sxs-lookup"><span data-stu-id="028e6-1308">EA37</span></span></td>
  <td><span data-ttu-id="028e6-1309">List</span><span class="sxs-lookup"><span data-stu-id="028e6-1309">List</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA38.png" width="32" height="32" alt="Asterisk" /></td>
  <td><span data-ttu-id="028e6-1310">EA38</span><span class="sxs-lookup"><span data-stu-id="028e6-1310">EA38</span></span></td>
  <td><span data-ttu-id="028e6-1311">Asterisk</span><span class="sxs-lookup"><span data-stu-id="028e6-1311">Asterisk</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA39.png" width="32" height="32" alt="ErrorBadge" /></td>
  <td><span data-ttu-id="028e6-1312">EA39</span><span class="sxs-lookup"><span data-stu-id="028e6-1312">EA39</span></span></td>
  <td><span data-ttu-id="028e6-1313">ErrorBadge</span><span class="sxs-lookup"><span data-stu-id="028e6-1313">ErrorBadge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA3A.png" width="32" height="32" alt="CircleRing" /></td>
  <td><span data-ttu-id="028e6-1314">EA3A</span><span class="sxs-lookup"><span data-stu-id="028e6-1314">EA3A</span></span></td>
  <td><span data-ttu-id="028e6-1315">CircleRing</span><span class="sxs-lookup"><span data-stu-id="028e6-1315">CircleRing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA3B.png" width="32" height="32" alt="CircleFill" /></td>
  <td><span data-ttu-id="028e6-1316">EA3B</span><span class="sxs-lookup"><span data-stu-id="028e6-1316">EA3B</span></span></td>
  <td><span data-ttu-id="028e6-1317">CircleFill</span><span class="sxs-lookup"><span data-stu-id="028e6-1317">CircleFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA40.png" width="32" height="32" alt="AllAppsMirrored" /></td>
  <td><span data-ttu-id="028e6-1318">EA40</span><span class="sxs-lookup"><span data-stu-id="028e6-1318">EA40</span></span></td>
  <td><span data-ttu-id="028e6-1319">AllAppsMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1319">AllAppsMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA41.png" width="32" height="32" alt="BookmarksMirrored" /></td>
  <td><span data-ttu-id="028e6-1320">EA41</span><span class="sxs-lookup"><span data-stu-id="028e6-1320">EA41</span></span></td>
  <td><span data-ttu-id="028e6-1321">BookmarksMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1321">BookmarksMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA42.png" width="32" height="32" alt="BulletedListMirrored" /></td>
  <td><span data-ttu-id="028e6-1322">EA42</span><span class="sxs-lookup"><span data-stu-id="028e6-1322">EA42</span></span></td>
  <td><span data-ttu-id="028e6-1323">BulletedListMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1323">BulletedListMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA43.png" width="32" height="32" alt="CallForwardInternationalMirrored" /></td>
  <td><span data-ttu-id="028e6-1324">EA43</span><span class="sxs-lookup"><span data-stu-id="028e6-1324">EA43</span></span></td>
  <td><span data-ttu-id="028e6-1325">CallForwardInternationalMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1325">CallForwardInternationalMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA44.png" width="32" height="32" alt="CallForwardRoamingMirrored" /></td>
  <td><span data-ttu-id="028e6-1326">EA44</span><span class="sxs-lookup"><span data-stu-id="028e6-1326">EA44</span></span></td>
  <td><span data-ttu-id="028e6-1327">CallForwardRoamingMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1327">CallForwardRoamingMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA47.png" width="32" height="32" alt="ChromeBackMirrored" /></td>
  <td><span data-ttu-id="028e6-1328">EA47</span><span class="sxs-lookup"><span data-stu-id="028e6-1328">EA47</span></span></td>
  <td><span data-ttu-id="028e6-1329">ChromeBackMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1329">ChromeBackMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA48.png" width="32" height="32" alt="ClearSelectionMirrored" /></td>
  <td><span data-ttu-id="028e6-1330">EA48</span><span class="sxs-lookup"><span data-stu-id="028e6-1330">EA48</span></span></td>
  <td><span data-ttu-id="028e6-1331">ClearSelectionMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1331">ClearSelectionMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA49.png" width="32" height="32" alt="ClosePaneMirrored" /></td>
  <td><span data-ttu-id="028e6-1332">EA49</span><span class="sxs-lookup"><span data-stu-id="028e6-1332">EA49</span></span></td>
  <td><span data-ttu-id="028e6-1333">ClosePaneMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1333">ClosePaneMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4A.png" width="32" height="32" alt="ContactInfoMirrored" /></td>
  <td><span data-ttu-id="028e6-1334">EA4A</span><span class="sxs-lookup"><span data-stu-id="028e6-1334">EA4A</span></span></td>
  <td><span data-ttu-id="028e6-1335">ContactInfoMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1335">ContactInfoMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4B.png" width="32" height="32" alt="DockRightMirrored" /></td>
  <td><span data-ttu-id="028e6-1336">EA4B</span><span class="sxs-lookup"><span data-stu-id="028e6-1336">EA4B</span></span></td>
  <td><span data-ttu-id="028e6-1337">DockRightMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1337">DockRightMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4C.png" width="32" height="32" alt="DockLeftMirrored" /></td>
  <td><span data-ttu-id="028e6-1338">EA4C</span><span class="sxs-lookup"><span data-stu-id="028e6-1338">EA4C</span></span></td>
  <td><span data-ttu-id="028e6-1339">DockLeftMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1339">DockLeftMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4E.png" width="32" height="32" alt="ExpandTileMirrored" /></td>
  <td><span data-ttu-id="028e6-1340">EA4E</span><span class="sxs-lookup"><span data-stu-id="028e6-1340">EA4E</span></span></td>
  <td><span data-ttu-id="028e6-1341">ExpandTileMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1341">ExpandTileMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4F.png" width="32" height="32" alt="GoMirrored" /></td>
  <td><span data-ttu-id="028e6-1342">EA4F</span><span class="sxs-lookup"><span data-stu-id="028e6-1342">EA4F</span></span></td>
  <td><span data-ttu-id="028e6-1343">GoMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1343">GoMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA50.png" width="32" height="32" alt="GripperResizeMirrored" /></td>
  <td><span data-ttu-id="028e6-1344">EA50</span><span class="sxs-lookup"><span data-stu-id="028e6-1344">EA50</span></span></td>
  <td><span data-ttu-id="028e6-1345">GripperResizeMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1345">GripperResizeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA51.png" width="32" height="32" alt="HelpMirrored" /></td>
  <td><span data-ttu-id="028e6-1346">EA51</span><span class="sxs-lookup"><span data-stu-id="028e6-1346">EA51</span></span></td>
  <td><span data-ttu-id="028e6-1347">HelpMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1347">HelpMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA52.png" width="32" height="32" alt="ImportMirrored" /></td>
  <td><span data-ttu-id="028e6-1348">EA52</span><span class="sxs-lookup"><span data-stu-id="028e6-1348">EA52</span></span></td>
  <td><span data-ttu-id="028e6-1349">ImportMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1349">ImportMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA53.png" width="32" height="32" alt="ImportAllMirrored" /></td>
  <td><span data-ttu-id="028e6-1350">EA53</span><span class="sxs-lookup"><span data-stu-id="028e6-1350">EA53</span></span></td>
  <td><span data-ttu-id="028e6-1351">ImportAllMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1351">ImportAllMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA54.png" width="32" height="32" alt="LeaveChatMirrored" /></td>
  <td><span data-ttu-id="028e6-1352">EA54</span><span class="sxs-lookup"><span data-stu-id="028e6-1352">EA54</span></span></td>
  <td><span data-ttu-id="028e6-1353">LeaveChatMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1353">LeaveChatMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA55.png" width="32" height="32" alt="ListMirrored" /></td>
  <td><span data-ttu-id="028e6-1354">EA55</span><span class="sxs-lookup"><span data-stu-id="028e6-1354">EA55</span></span></td>
  <td><span data-ttu-id="028e6-1355">ListMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1355">ListMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA56.png" width="32" height="32" alt="MailForwardMirrored" /></td>
  <td><span data-ttu-id="028e6-1356">EA56</span><span class="sxs-lookup"><span data-stu-id="028e6-1356">EA56</span></span></td>
  <td><span data-ttu-id="028e6-1357">MailForwardMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1357">MailForwardMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA57.png" width="32" height="32" alt="MailReplyMirrored" /></td>
  <td><span data-ttu-id="028e6-1358">EA57</span><span class="sxs-lookup"><span data-stu-id="028e6-1358">EA57</span></span></td>
  <td><span data-ttu-id="028e6-1359">MailReplyMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1359">MailReplyMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA58.png" width="32" height="32" alt="MailReplyAllMirrored" /></td>
  <td><span data-ttu-id="028e6-1360">EA58</span><span class="sxs-lookup"><span data-stu-id="028e6-1360">EA58</span></span></td>
  <td><span data-ttu-id="028e6-1361">MailReplyAllMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1361">MailReplyAllMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA5B.png" width="32" height="32" alt="OpenPaneMirrored" /></td>
  <td><span data-ttu-id="028e6-1362">EA5B</span><span class="sxs-lookup"><span data-stu-id="028e6-1362">EA5B</span></span></td>
  <td><span data-ttu-id="028e6-1363">OpenPaneMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1363">OpenPaneMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA5C.png" width="32" height="32" alt="OpenWithMirrored" /></td>
  <td><span data-ttu-id="028e6-1364">EA5C</span><span class="sxs-lookup"><span data-stu-id="028e6-1364">EA5C</span></span></td>
  <td><span data-ttu-id="028e6-1365">OpenWithMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1365">OpenWithMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA5E.png" width="32" height="32" alt="ParkingLocationMirrored" /></td>
  <td><span data-ttu-id="028e6-1366">EA5E</span><span class="sxs-lookup"><span data-stu-id="028e6-1366">EA5E</span></span></td>
  <td><span data-ttu-id="028e6-1367">ParkingLocationMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1367">ParkingLocationMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA5F.png" width="32" height="32" alt="ResizeMouseMediumMirrored" /></td>
  <td><span data-ttu-id="028e6-1368">EA5F</span><span class="sxs-lookup"><span data-stu-id="028e6-1368">EA5F</span></span></td>
  <td><span data-ttu-id="028e6-1369">ResizeMouseMediumMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1369">ResizeMouseMediumMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA60.png" width="32" height="32" alt="ResizeMouseSmallMirrored" /></td>
  <td><span data-ttu-id="028e6-1370">EA60</span><span class="sxs-lookup"><span data-stu-id="028e6-1370">EA60</span></span></td>
  <td><span data-ttu-id="028e6-1371">ResizeMouseSmallMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1371">ResizeMouseSmallMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA61.png" width="32" height="32" alt="ResizeMouseTallMirrored" /></td>
  <td><span data-ttu-id="028e6-1372">EA61</span><span class="sxs-lookup"><span data-stu-id="028e6-1372">EA61</span></span></td>
  <td><span data-ttu-id="028e6-1373">ResizeMouseTallMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1373">ResizeMouseTallMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA62.png" width="32" height="32" alt="ResizeTouchNarrowerMirrored" /></td>
  <td><span data-ttu-id="028e6-1374">EA62</span><span class="sxs-lookup"><span data-stu-id="028e6-1374">EA62</span></span></td>
  <td><span data-ttu-id="028e6-1375">ResizeTouchNarrowerMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1375">ResizeTouchNarrowerMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA63.png" width="32" height="32" alt="SendMirrored" /></td>
  <td><span data-ttu-id="028e6-1376">EA63</span><span class="sxs-lookup"><span data-stu-id="028e6-1376">EA63</span></span></td>
  <td><span data-ttu-id="028e6-1377">SendMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1377">SendMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA64.png" width="32" height="32" alt="SendFillMirrored" /></td>
  <td><span data-ttu-id="028e6-1378">EA64</span><span class="sxs-lookup"><span data-stu-id="028e6-1378">EA64</span></span></td>
  <td><span data-ttu-id="028e6-1379">SendFillMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1379">SendFillMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA65.png" width="32" height="32" alt="ShowResultsMirrored" /></td>
  <td><span data-ttu-id="028e6-1380">EA65</span><span class="sxs-lookup"><span data-stu-id="028e6-1380">EA65</span></span></td>
  <td><span data-ttu-id="028e6-1381">ShowResultsMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1381">ShowResultsMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA69.png" width="32" height="32" alt="Media" /></td>
  <td><span data-ttu-id="028e6-1382">EA69</span><span class="sxs-lookup"><span data-stu-id="028e6-1382">EA69</span></span></td>
  <td><span data-ttu-id="028e6-1383">Media</span><span class="sxs-lookup"><span data-stu-id="028e6-1383">Media</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA6A.png" width="32" height="32" alt="SyncError" /></td>
  <td><span data-ttu-id="028e6-1384">EA6A</span><span class="sxs-lookup"><span data-stu-id="028e6-1384">EA6A</span></span></td>
  <td><span data-ttu-id="028e6-1385">SyncError</span><span class="sxs-lookup"><span data-stu-id="028e6-1385">SyncError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA6C.png" width="32" height="32" alt="Devices3" /></td>
  <td><span data-ttu-id="028e6-1386">EA6C</span><span class="sxs-lookup"><span data-stu-id="028e6-1386">EA6C</span></span></td>
  <td><span data-ttu-id="028e6-1387">Devices3</span><span class="sxs-lookup"><span data-stu-id="028e6-1387">Devices3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA79.png" width="32" height="32" alt="SlowMotionOn" /></td>
  <td><span data-ttu-id="028e6-1388">EA79</span><span class="sxs-lookup"><span data-stu-id="028e6-1388">EA79</span></span></td>
  <td><span data-ttu-id="028e6-1389">SlowMotionOn</span><span class="sxs-lookup"><span data-stu-id="028e6-1389">SlowMotionOn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA80.png" width="32" height="32" alt="Lightbulb" /></td>
  <td><span data-ttu-id="028e6-1390">EA80</span><span class="sxs-lookup"><span data-stu-id="028e6-1390">EA80</span></span></td>
  <td><span data-ttu-id="028e6-1391">Lightbulb</span><span class="sxs-lookup"><span data-stu-id="028e6-1391">Lightbulb</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA81.png" width="32" height="32" alt="StatusCircle" /></td>
  <td><span data-ttu-id="028e6-1392">EA81</span><span class="sxs-lookup"><span data-stu-id="028e6-1392">EA81</span></span></td>
  <td><span data-ttu-id="028e6-1393">StatusCircle</span><span class="sxs-lookup"><span data-stu-id="028e6-1393">StatusCircle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA82.png" width="32" height="32" alt="StatusTriangle" /></td>
  <td><span data-ttu-id="028e6-1394">EA82</span><span class="sxs-lookup"><span data-stu-id="028e6-1394">EA82</span></span></td>
  <td><span data-ttu-id="028e6-1395">StatusTriangle</span><span class="sxs-lookup"><span data-stu-id="028e6-1395">StatusTriangle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA83.png" width="32" height="32" alt="StatusError" /></td>
  <td><span data-ttu-id="028e6-1396">EA83</span><span class="sxs-lookup"><span data-stu-id="028e6-1396">EA83</span></span></td>
  <td><span data-ttu-id="028e6-1397">StatusError</span><span class="sxs-lookup"><span data-stu-id="028e6-1397">StatusError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA84.png" width="32" height="32" alt="StatusWarning" /></td>
  <td><span data-ttu-id="028e6-1398">EA84</span><span class="sxs-lookup"><span data-stu-id="028e6-1398">EA84</span></span></td>
  <td><span data-ttu-id="028e6-1399">StatusWarning</span><span class="sxs-lookup"><span data-stu-id="028e6-1399">StatusWarning</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA86.png" width="32" height="32" alt="Puzzle" /></td>
  <td><span data-ttu-id="028e6-1400">EA86</span><span class="sxs-lookup"><span data-stu-id="028e6-1400">EA86</span></span></td>
  <td><span data-ttu-id="028e6-1401">Puzzle</span><span class="sxs-lookup"><span data-stu-id="028e6-1401">Puzzle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA89.png" width="32" height="32" alt="CalendarSolid" /></td>
  <td><span data-ttu-id="028e6-1402">EA89</span><span class="sxs-lookup"><span data-stu-id="028e6-1402">EA89</span></span></td>
  <td><span data-ttu-id="028e6-1403">CalendarSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1403">CalendarSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8A.png" width="32" height="32" alt="HomeSolid" /></td>
  <td><span data-ttu-id="028e6-1404">EA8A</span><span class="sxs-lookup"><span data-stu-id="028e6-1404">EA8A</span></span></td>
  <td><span data-ttu-id="028e6-1405">HomeSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1405">HomeSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8B.png" width="32" height="32" alt="ParkingLocationSolid" /></td>
  <td><span data-ttu-id="028e6-1406">EA8B</span><span class="sxs-lookup"><span data-stu-id="028e6-1406">EA8B</span></span></td>
  <td><span data-ttu-id="028e6-1407">ParkingLocationSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1407">ParkingLocationSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8C.png" width="32" height="32" alt="ContactSolid" /></td>
  <td><span data-ttu-id="028e6-1408">EA8C</span><span class="sxs-lookup"><span data-stu-id="028e6-1408">EA8C</span></span></td>
  <td><span data-ttu-id="028e6-1409">ContactSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1409">ContactSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8D.png" width="32" height="32" alt="ConstructionSolid" /></td>
  <td><span data-ttu-id="028e6-1410">EA8D</span><span class="sxs-lookup"><span data-stu-id="028e6-1410">EA8D</span></span></td>
  <td><span data-ttu-id="028e6-1411">ConstructionSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1411">ConstructionSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8E.png" width="32" height="32" alt="AccidentSolid" /></td>
  <td><span data-ttu-id="028e6-1412">EA8E</span><span class="sxs-lookup"><span data-stu-id="028e6-1412">EA8E</span></span></td>
  <td><span data-ttu-id="028e6-1413">AccidentSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1413">AccidentSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8F.png" width="32" height="32" alt="Ringer" /></td>
  <td><span data-ttu-id="028e6-1414">EA8F</span><span class="sxs-lookup"><span data-stu-id="028e6-1414">EA8F</span></span></td>
  <td><span data-ttu-id="028e6-1415">Ringer</span><span class="sxs-lookup"><span data-stu-id="028e6-1415">Ringer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA91.png" width="32" height="32" alt="ThoughtBubble" /></td>
  <td><span data-ttu-id="028e6-1416">EA91</span><span class="sxs-lookup"><span data-stu-id="028e6-1416">EA91</span></span></td>
  <td><span data-ttu-id="028e6-1417">ThoughtBubble</span><span class="sxs-lookup"><span data-stu-id="028e6-1417">ThoughtBubble</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA92.png" width="32" height="32" alt="HeartBroken" /></td>
  <td><span data-ttu-id="028e6-1418">EA92</span><span class="sxs-lookup"><span data-stu-id="028e6-1418">EA92</span></span></td>
  <td><span data-ttu-id="028e6-1419">HeartBroken</span><span class="sxs-lookup"><span data-stu-id="028e6-1419">HeartBroken</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA93.png" width="32" height="32" alt="BatteryCharging10" /></td>
  <td><span data-ttu-id="028e6-1420">EA93</span><span class="sxs-lookup"><span data-stu-id="028e6-1420">EA93</span></span></td>
  <td><span data-ttu-id="028e6-1421">BatteryCharging10</span><span class="sxs-lookup"><span data-stu-id="028e6-1421">BatteryCharging10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA94.png" width="32" height="32" alt="BatterySaver9" /></td>
  <td><span data-ttu-id="028e6-1422">EA94</span><span class="sxs-lookup"><span data-stu-id="028e6-1422">EA94</span></span></td>
  <td><span data-ttu-id="028e6-1423">BatterySaver9</span><span class="sxs-lookup"><span data-stu-id="028e6-1423">BatterySaver9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA95.png" width="32" height="32" alt="BatterySaver10" /></td>
  <td><span data-ttu-id="028e6-1424">EA95</span><span class="sxs-lookup"><span data-stu-id="028e6-1424">EA95</span></span></td>
  <td><span data-ttu-id="028e6-1425">BatterySaver10</span><span class="sxs-lookup"><span data-stu-id="028e6-1425">BatterySaver10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA97.png" width="32" height="32" alt="CallForwardingMirrored" /></td>
  <td><span data-ttu-id="028e6-1426">EA97</span><span class="sxs-lookup"><span data-stu-id="028e6-1426">EA97</span></span></td>
  <td><span data-ttu-id="028e6-1427">CallForwardingMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1427">CallForwardingMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA98.png" width="32" height="32" alt="MultiSelectMirrored" /></td>
  <td><span data-ttu-id="028e6-1428">EA98</span><span class="sxs-lookup"><span data-stu-id="028e6-1428">EA98</span></span></td>
  <td><span data-ttu-id="028e6-1429">MultiSelectMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1429">MultiSelectMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA99.png" width="32" height="32" alt="Broom" /></td>
  <td><span data-ttu-id="028e6-1430">EA99</span><span class="sxs-lookup"><span data-stu-id="028e6-1430">EA99</span></span></td>
  <td><span data-ttu-id="028e6-1431">Broom</span><span class="sxs-lookup"><span data-stu-id="028e6-1431">Broom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EADF.png" width="32" height="32" alt="Trackers" /></td>
  <td><span data-ttu-id="028e6-1432">EADF</span><span class="sxs-lookup"><span data-stu-id="028e6-1432">EADF</span></span></td>
  <td><span data-ttu-id="028e6-1433">Trackers</span><span class="sxs-lookup"><span data-stu-id="028e6-1433">Trackers</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB05.png" width="32" height="32" alt="PieSingle" /></td>
  <td><span data-ttu-id="028e6-1434">EB05</span><span class="sxs-lookup"><span data-stu-id="028e6-1434">EB05</span></span></td>
  <td><span data-ttu-id="028e6-1435">PieSingle</span><span class="sxs-lookup"><span data-stu-id="028e6-1435">PieSingle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB0F.png" width="32" height="32" alt="StockDown" /></td>
  <td><span data-ttu-id="028e6-1436">EB0F</span><span class="sxs-lookup"><span data-stu-id="028e6-1436">EB0F</span></span></td>
  <td><span data-ttu-id="028e6-1437">StockDown</span><span class="sxs-lookup"><span data-stu-id="028e6-1437">StockDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB11.png" width="32" height="32" alt="StockUp" /></td>
  <td><span data-ttu-id="028e6-1438">EB11</span><span class="sxs-lookup"><span data-stu-id="028e6-1438">EB11</span></span></td>
  <td><span data-ttu-id="028e6-1439">StockUp</span><span class="sxs-lookup"><span data-stu-id="028e6-1439">StockUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB3C.png" width="32" height="32" alt="Design" /></td>
  <td><span data-ttu-id="028e6-1440">EB3C</span><span class="sxs-lookup"><span data-stu-id="028e6-1440">EB3C</span></span></td>
  <td><span data-ttu-id="028e6-1441">設計</span><span class="sxs-lookup"><span data-stu-id="028e6-1441">Design</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB41.png" width="32" height="32" alt="Website" /></td>
  <td><span data-ttu-id="028e6-1442">EB41</span><span class="sxs-lookup"><span data-stu-id="028e6-1442">EB41</span></span></td>
  <td><span data-ttu-id="028e6-1443">Web サイト</span><span class="sxs-lookup"><span data-stu-id="028e6-1443">Website</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB42.png" width="32" height="32" alt="Drop" /></td>
  <td><span data-ttu-id="028e6-1444">EB42</span><span class="sxs-lookup"><span data-stu-id="028e6-1444">EB42</span></span></td>
  <td><span data-ttu-id="028e6-1445">Drop</span><span class="sxs-lookup"><span data-stu-id="028e6-1445">Drop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB44.png" width="32" height="32" alt="Radar" /></td>
  <td><span data-ttu-id="028e6-1446">EB44</span><span class="sxs-lookup"><span data-stu-id="028e6-1446">EB44</span></span></td>
  <td><span data-ttu-id="028e6-1447">レーダー</span><span class="sxs-lookup"><span data-stu-id="028e6-1447">Radar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB47.png" width="32" height="32" alt="BusSolid" /></td>
  <td><span data-ttu-id="028e6-1448">EB47</span><span class="sxs-lookup"><span data-stu-id="028e6-1448">EB47</span></span></td>
  <td><span data-ttu-id="028e6-1449">BusSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1449">BusSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB48.png" width="32" height="32" alt="FerrySolid" /></td>
  <td><span data-ttu-id="028e6-1450">EB48</span><span class="sxs-lookup"><span data-stu-id="028e6-1450">EB48</span></span></td>
  <td><span data-ttu-id="028e6-1451">FerrySolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1451">FerrySolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB49.png" width="32" height="32" alt="StartPointSolid" /></td>
  <td><span data-ttu-id="028e6-1452">EB49</span><span class="sxs-lookup"><span data-stu-id="028e6-1452">EB49</span></span></td>
  <td><span data-ttu-id="028e6-1453">StartPointSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1453">StartPointSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4A.png" width="32" height="32" alt="StopPointSolid" /></td>
  <td><span data-ttu-id="028e6-1454">EB4A</span><span class="sxs-lookup"><span data-stu-id="028e6-1454">EB4A</span></span></td>
  <td><span data-ttu-id="028e6-1455">StopPointSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1455">StopPointSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4B.png" width="32" height="32" alt="EndPointSolid" /></td>
  <td><span data-ttu-id="028e6-1456">EB4B</span><span class="sxs-lookup"><span data-stu-id="028e6-1456">EB4B</span></span></td>
  <td><span data-ttu-id="028e6-1457">EndPointSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1457">EndPointSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4C.png" width="32" height="32" alt="AirplaneSolid" /></td>
  <td><span data-ttu-id="028e6-1458">EB4C</span><span class="sxs-lookup"><span data-stu-id="028e6-1458">EB4C</span></span></td>
  <td><span data-ttu-id="028e6-1459">AirplaneSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1459">AirplaneSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4D.png" width="32" height="32" alt="TrainSolid" /></td>
  <td><span data-ttu-id="028e6-1460">EB4D</span><span class="sxs-lookup"><span data-stu-id="028e6-1460">EB4D</span></span></td>
  <td><span data-ttu-id="028e6-1461">TrainSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1461">TrainSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4E.png" width="32" height="32" alt="WorkSolid" /></td>
  <td><span data-ttu-id="028e6-1462">EB4E</span><span class="sxs-lookup"><span data-stu-id="028e6-1462">EB4E</span></span></td>
  <td><span data-ttu-id="028e6-1463">WorkSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1463">WorkSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4F.png" width="32" height="32" alt="ReminderFill" /></td>
  <td><span data-ttu-id="028e6-1464">EB4F</span><span class="sxs-lookup"><span data-stu-id="028e6-1464">EB4F</span></span></td>
  <td><span data-ttu-id="028e6-1465">ReminderFill</span><span class="sxs-lookup"><span data-stu-id="028e6-1465">ReminderFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB50.png" width="32" height="32" alt="Reminder" /></td>
  <td><span data-ttu-id="028e6-1466">EB50</span><span class="sxs-lookup"><span data-stu-id="028e6-1466">EB50</span></span></td>
  <td><span data-ttu-id="028e6-1467">Reminder</span><span class="sxs-lookup"><span data-stu-id="028e6-1467">Reminder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB51.png" width="32" height="32" alt="Heart" /></td>
  <td><span data-ttu-id="028e6-1468">EB51</span><span class="sxs-lookup"><span data-stu-id="028e6-1468">EB51</span></span></td>
  <td><span data-ttu-id="028e6-1469">Heart</span><span class="sxs-lookup"><span data-stu-id="028e6-1469">Heart</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB52.png" width="32" height="32" alt="HeartFill" /></td>
  <td><span data-ttu-id="028e6-1470">EB52</span><span class="sxs-lookup"><span data-stu-id="028e6-1470">EB52</span></span></td>
  <td><span data-ttu-id="028e6-1471">HeartFill</span><span class="sxs-lookup"><span data-stu-id="028e6-1471">HeartFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB55.png" width="32" height="32" alt="EthernetError" /></td>
  <td><span data-ttu-id="028e6-1472">EB55</span><span class="sxs-lookup"><span data-stu-id="028e6-1472">EB55</span></span></td>
  <td><span data-ttu-id="028e6-1473">EthernetError</span><span class="sxs-lookup"><span data-stu-id="028e6-1473">EthernetError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB56.png" width="32" height="32" alt="EthernetWarning" /></td>
  <td><span data-ttu-id="028e6-1474">EB56</span><span class="sxs-lookup"><span data-stu-id="028e6-1474">EB56</span></span></td>
  <td><span data-ttu-id="028e6-1475">EthernetWarning</span><span class="sxs-lookup"><span data-stu-id="028e6-1475">EthernetWarning</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB57.png" width="32" height="32" alt="StatusConnecting1" /></td>
  <td><span data-ttu-id="028e6-1476">EB57</span><span class="sxs-lookup"><span data-stu-id="028e6-1476">EB57</span></span></td>
  <td><span data-ttu-id="028e6-1477">StatusConnecting1</span><span class="sxs-lookup"><span data-stu-id="028e6-1477">StatusConnecting1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB58.png" width="32" height="32" alt="StatusConnecting2" /></td>
  <td><span data-ttu-id="028e6-1478">EB58</span><span class="sxs-lookup"><span data-stu-id="028e6-1478">EB58</span></span></td>
  <td><span data-ttu-id="028e6-1479">StatusConnecting2</span><span class="sxs-lookup"><span data-stu-id="028e6-1479">StatusConnecting2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB59.png" width="32" height="32" alt="StatusUnsecure" /></td>
  <td><span data-ttu-id="028e6-1480">EB59</span><span class="sxs-lookup"><span data-stu-id="028e6-1480">EB59</span></span></td>
  <td><span data-ttu-id="028e6-1481">StatusUnsecure</span><span class="sxs-lookup"><span data-stu-id="028e6-1481">StatusUnsecure</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5A.png" width="32" height="32" alt="WifiError0" /></td>
  <td><span data-ttu-id="028e6-1482">EB5A</span><span class="sxs-lookup"><span data-stu-id="028e6-1482">EB5A</span></span></td>
  <td><span data-ttu-id="028e6-1483">WifiError0</span><span class="sxs-lookup"><span data-stu-id="028e6-1483">WifiError0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5B.png" width="32" height="32" alt="WifiError1" /></td>
  <td><span data-ttu-id="028e6-1484">EB5B</span><span class="sxs-lookup"><span data-stu-id="028e6-1484">EB5B</span></span></td>
  <td><span data-ttu-id="028e6-1485">WifiError1</span><span class="sxs-lookup"><span data-stu-id="028e6-1485">WifiError1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5C.png" width="32" height="32" alt="WifiError2" /></td>
  <td><span data-ttu-id="028e6-1486">EB5C</span><span class="sxs-lookup"><span data-stu-id="028e6-1486">EB5C</span></span></td>
  <td><span data-ttu-id="028e6-1487">WifiError2</span><span class="sxs-lookup"><span data-stu-id="028e6-1487">WifiError2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5D.png" width="32" height="32" alt="WifiError3" /></td>
  <td><span data-ttu-id="028e6-1488">EB5D</span><span class="sxs-lookup"><span data-stu-id="028e6-1488">EB5D</span></span></td>
  <td><span data-ttu-id="028e6-1489">WifiError3</span><span class="sxs-lookup"><span data-stu-id="028e6-1489">WifiError3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5E.png" width="32" height="32" alt="WifiError4" /></td>
  <td><span data-ttu-id="028e6-1490">EB5E</span><span class="sxs-lookup"><span data-stu-id="028e6-1490">EB5E</span></span></td>
  <td><span data-ttu-id="028e6-1491">WifiError4</span><span class="sxs-lookup"><span data-stu-id="028e6-1491">WifiError4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5F.png" width="32" height="32" alt="WifiWarning0" /></td>
  <td><span data-ttu-id="028e6-1492">EB5F</span><span class="sxs-lookup"><span data-stu-id="028e6-1492">EB5F</span></span></td>
  <td><span data-ttu-id="028e6-1493">WifiWarning0</span><span class="sxs-lookup"><span data-stu-id="028e6-1493">WifiWarning0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB60.png" width="32" height="32" alt="WifiWarning1" /></td>
  <td><span data-ttu-id="028e6-1494">EB60</span><span class="sxs-lookup"><span data-stu-id="028e6-1494">EB60</span></span></td>
  <td><span data-ttu-id="028e6-1495">WifiWarning1</span><span class="sxs-lookup"><span data-stu-id="028e6-1495">WifiWarning1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB61.png" width="32" height="32" alt="WifiWarning2" /></td>
  <td><span data-ttu-id="028e6-1496">EB61</span><span class="sxs-lookup"><span data-stu-id="028e6-1496">EB61</span></span></td>
  <td><span data-ttu-id="028e6-1497">WifiWarning2</span><span class="sxs-lookup"><span data-stu-id="028e6-1497">WifiWarning2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB62.png" width="32" height="32" alt="WifiWarning3" /></td>
  <td><span data-ttu-id="028e6-1498">EB62</span><span class="sxs-lookup"><span data-stu-id="028e6-1498">EB62</span></span></td>
  <td><span data-ttu-id="028e6-1499">WifiWarning3</span><span class="sxs-lookup"><span data-stu-id="028e6-1499">WifiWarning3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB63.png" width="32" height="32" alt="WifiWarning4" /></td>
  <td><span data-ttu-id="028e6-1500">EB63</span><span class="sxs-lookup"><span data-stu-id="028e6-1500">EB63</span></span></td>
  <td><span data-ttu-id="028e6-1501">WifiWarning4</span><span class="sxs-lookup"><span data-stu-id="028e6-1501">WifiWarning4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB66.png" width="32" height="32" alt="Devices4" /></td>
  <td><span data-ttu-id="028e6-1502">EB66</span><span class="sxs-lookup"><span data-stu-id="028e6-1502">EB66</span></span></td>
  <td><span data-ttu-id="028e6-1503">Devices4</span><span class="sxs-lookup"><span data-stu-id="028e6-1503">Devices4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB67.png" width="32" height="32" alt="NUIIris" /></td>
  <td><span data-ttu-id="028e6-1504">EB67</span><span class="sxs-lookup"><span data-stu-id="028e6-1504">EB67</span></span></td>
  <td><span data-ttu-id="028e6-1505">NUIIris</span><span class="sxs-lookup"><span data-stu-id="028e6-1505">NUIIris</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB68.png" width="32" height="32" alt="NUIFace" /></td>
  <td><span data-ttu-id="028e6-1506">EB68</span><span class="sxs-lookup"><span data-stu-id="028e6-1506">EB68</span></span></td>
  <td><span data-ttu-id="028e6-1507">NUIFace</span><span class="sxs-lookup"><span data-stu-id="028e6-1507">NUIFace</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB7E.png" width="32" height="32" alt="EditMirrored" /></td>
  <td><span data-ttu-id="028e6-1508">EB7E</span><span class="sxs-lookup"><span data-stu-id="028e6-1508">EB7E</span></span></td>
  <td><span data-ttu-id="028e6-1509">EditMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1509">EditMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB82.png" width="32" height="32" alt="NUIFPStartSlideHand " /></td>
  <td><span data-ttu-id="028e6-1510">EB82</span><span class="sxs-lookup"><span data-stu-id="028e6-1510">EB82</span></span></td>
  <td><span data-ttu-id="028e6-1511">NUIFPStartSlideHand</span><span class="sxs-lookup"><span data-stu-id="028e6-1511">NUIFPStartSlideHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB83.png" width="32" height="32" alt="NUIFPStartSlideAction " /></td>
  <td><span data-ttu-id="028e6-1512">EB83</span><span class="sxs-lookup"><span data-stu-id="028e6-1512">EB83</span></span></td>
  <td><span data-ttu-id="028e6-1513">NUIFPStartSlideAction</span><span class="sxs-lookup"><span data-stu-id="028e6-1513">NUIFPStartSlideAction</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB84.png" width="32" height="32" alt="NUIFPContinueSlideHand " /></td>
  <td><span data-ttu-id="028e6-1514">EB84</span><span class="sxs-lookup"><span data-stu-id="028e6-1514">EB84</span></span></td>
  <td><span data-ttu-id="028e6-1515">NUIFPContinueSlideHand</span><span class="sxs-lookup"><span data-stu-id="028e6-1515">NUIFPContinueSlideHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB85.png" width="32" height="32" alt="NUIFPContinueSlideAction" /></td>
  <td><span data-ttu-id="028e6-1516">EB85</span><span class="sxs-lookup"><span data-stu-id="028e6-1516">EB85</span></span></td>
  <td><span data-ttu-id="028e6-1517">NUIFPContinueSlideAction</span><span class="sxs-lookup"><span data-stu-id="028e6-1517">NUIFPContinueSlideAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB86.png" width="32" height="32" alt="NUIFPRollRightHand " /></td>
  <td><span data-ttu-id="028e6-1518">EB86</span><span class="sxs-lookup"><span data-stu-id="028e6-1518">EB86</span></span></td>
  <td><span data-ttu-id="028e6-1519">NUIFPRollRightHand</span><span class="sxs-lookup"><span data-stu-id="028e6-1519">NUIFPRollRightHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB87.png" width="32" height="32" alt="NUIFPRollRightHandAction" /></td>
  <td><span data-ttu-id="028e6-1520">EB87</span><span class="sxs-lookup"><span data-stu-id="028e6-1520">EB87</span></span></td>
  <td><span data-ttu-id="028e6-1521">NUIFPRollRightHandAction</span><span class="sxs-lookup"><span data-stu-id="028e6-1521">NUIFPRollRightHandAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB88.png" width="32" height="32" alt="NUIFPRollLeftHand " /></td>
  <td><span data-ttu-id="028e6-1522">EB88</span><span class="sxs-lookup"><span data-stu-id="028e6-1522">EB88</span></span></td>
  <td><span data-ttu-id="028e6-1523">NUIFPRollLeftHand</span><span class="sxs-lookup"><span data-stu-id="028e6-1523">NUIFPRollLeftHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB89.png" width="32" height="32" alt="NUIFPRollLeftAction" /></td>
  <td><span data-ttu-id="028e6-1524">EB89</span><span class="sxs-lookup"><span data-stu-id="028e6-1524">EB89</span></span></td>
  <td><span data-ttu-id="028e6-1525">NUIFPRollLeftAction</span><span class="sxs-lookup"><span data-stu-id="028e6-1525">NUIFPRollLeftAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB8A.png" width="32" height="32" alt="NUIFPPressHand " /></td>
  <td><span data-ttu-id="028e6-1526">EB8A</span><span class="sxs-lookup"><span data-stu-id="028e6-1526">EB8A</span></span></td>
  <td><span data-ttu-id="028e6-1527">NUIFPPressHand</span><span class="sxs-lookup"><span data-stu-id="028e6-1527">NUIFPPressHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB8B.png" width="32" height="32" alt="NUIFPPressAction" /></td>
  <td><span data-ttu-id="028e6-1528">EB8B</span><span class="sxs-lookup"><span data-stu-id="028e6-1528">EB8B</span></span></td>
  <td><span data-ttu-id="028e6-1529">NUIFPPressAction</span><span class="sxs-lookup"><span data-stu-id="028e6-1529">NUIFPPressAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB8C.png" width="32" height="32" alt="NUIFPPressRepeatHand " /></td>
  <td><span data-ttu-id="028e6-1530">EB8C</span><span class="sxs-lookup"><span data-stu-id="028e6-1530">EB8C</span></span></td>
  <td><span data-ttu-id="028e6-1531">NUIFPPressRepeatHand</span><span class="sxs-lookup"><span data-stu-id="028e6-1531">NUIFPPressRepeatHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB8D.png" width="32" height="32" alt="NUIFPPressRepeatAction" /></td>
  <td><span data-ttu-id="028e6-1532">EB8D</span><span class="sxs-lookup"><span data-stu-id="028e6-1532">EB8D</span></span></td>
  <td><span data-ttu-id="028e6-1533">NUIFPPressRepeatAction</span><span class="sxs-lookup"><span data-stu-id="028e6-1533">NUIFPPressRepeatAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB90.png" width="32" height="32" alt="StatusErrorFull" /></td>
  <td><span data-ttu-id="028e6-1534">EB90</span><span class="sxs-lookup"><span data-stu-id="028e6-1534">EB90</span></span></td>
  <td><span data-ttu-id="028e6-1535">StatusErrorFull</span><span class="sxs-lookup"><span data-stu-id="028e6-1535">StatusErrorFull</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB91.png" width="32" height="32" alt="TaskViewExpanded" /></td>
  <td><span data-ttu-id="028e6-1536">EB91</span><span class="sxs-lookup"><span data-stu-id="028e6-1536">EB91</span></span></td>
  <td><span data-ttu-id="028e6-1537">TaskViewExpanded</span><span class="sxs-lookup"><span data-stu-id="028e6-1537">TaskViewExpanded</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB95.png" width="32" height="32" alt="Certificate" /></td>
  <td><span data-ttu-id="028e6-1538">EB95</span><span class="sxs-lookup"><span data-stu-id="028e6-1538">EB95</span></span></td>
  <td><span data-ttu-id="028e6-1539">Certificate</span><span class="sxs-lookup"><span data-stu-id="028e6-1539">Certificate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB96.png" width="32" height="32" alt="BackSpaceQWERTYLg" /></td>
  <td><span data-ttu-id="028e6-1540">EB96</span><span class="sxs-lookup"><span data-stu-id="028e6-1540">EB96</span></span></td>
  <td><span data-ttu-id="028e6-1541">BackSpaceQWERTYLg</span><span class="sxs-lookup"><span data-stu-id="028e6-1541">BackSpaceQWERTYLg</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB97.png" width="32" height="32" alt="ReturnKeyLg" /></td>
  <td><span data-ttu-id="028e6-1542">EB97</span><span class="sxs-lookup"><span data-stu-id="028e6-1542">EB97</span></span></td>
  <td><span data-ttu-id="028e6-1543">ReturnKeyLg</span><span class="sxs-lookup"><span data-stu-id="028e6-1543">ReturnKeyLg</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB9D.png" width="32" height="32" alt="FastForward" /></td>
  <td><span data-ttu-id="028e6-1544">EB9D</span><span class="sxs-lookup"><span data-stu-id="028e6-1544">EB9D</span></span></td>
  <td><span data-ttu-id="028e6-1545">FastForward</span><span class="sxs-lookup"><span data-stu-id="028e6-1545">FastForward</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB9E.png" width="32" height="32" alt="Rewind" /></td>
  <td><span data-ttu-id="028e6-1546">EB9E</span><span class="sxs-lookup"><span data-stu-id="028e6-1546">EB9E</span></span></td>
  <td><span data-ttu-id="028e6-1547">Rewind</span><span class="sxs-lookup"><span data-stu-id="028e6-1547">Rewind</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB9F.png" width="32" height="32" alt="Photo2" /></td>
  <td><span data-ttu-id="028e6-1548">EB9F</span><span class="sxs-lookup"><span data-stu-id="028e6-1548">EB9F</span></span></td>
  <td><span data-ttu-id="028e6-1549">Photo2</span><span class="sxs-lookup"><span data-stu-id="028e6-1549">Photo2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA0.png" width="32" height="32" alt=" MobBattery0" /></td>
  <td><span data-ttu-id="028e6-1550">EBA0</span><span class="sxs-lookup"><span data-stu-id="028e6-1550">EBA0</span></span></td>
  <td> <span data-ttu-id="028e6-1551">MobBattery0</span><span class="sxs-lookup"><span data-stu-id="028e6-1551">MobBattery0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA1.png" width="32" height="32" alt=" MobBattery1" /></td>
  <td><span data-ttu-id="028e6-1552">EBA1</span><span class="sxs-lookup"><span data-stu-id="028e6-1552">EBA1</span></span></td>
  <td> <span data-ttu-id="028e6-1553">MobBattery1</span><span class="sxs-lookup"><span data-stu-id="028e6-1553">MobBattery1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA2.png" width="32" height="32" alt=" MobBattery2" /></td>
  <td><span data-ttu-id="028e6-1554">EBA2</span><span class="sxs-lookup"><span data-stu-id="028e6-1554">EBA2</span></span></td>
  <td> <span data-ttu-id="028e6-1555">MobBattery2</span><span class="sxs-lookup"><span data-stu-id="028e6-1555">MobBattery2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA3.png" width="32" height="32" alt=" MobBattery3" /></td>
  <td><span data-ttu-id="028e6-1556">EBA3</span><span class="sxs-lookup"><span data-stu-id="028e6-1556">EBA3</span></span></td>
  <td> <span data-ttu-id="028e6-1557">MobBattery3</span><span class="sxs-lookup"><span data-stu-id="028e6-1557">MobBattery3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA4.png" width="32" height="32" alt=" MobBattery4" /></td>
  <td><span data-ttu-id="028e6-1558">EBA4</span><span class="sxs-lookup"><span data-stu-id="028e6-1558">EBA4</span></span></td>
  <td> <span data-ttu-id="028e6-1559">MobBattery4</span><span class="sxs-lookup"><span data-stu-id="028e6-1559">MobBattery4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA5.png" width="32" height="32" alt=" MobBattery5" /></td>
  <td><span data-ttu-id="028e6-1560">EBA5</span><span class="sxs-lookup"><span data-stu-id="028e6-1560">EBA5</span></span></td>
  <td> <span data-ttu-id="028e6-1561">MobBattery5</span><span class="sxs-lookup"><span data-stu-id="028e6-1561">MobBattery5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA6.png" width="32" height="32" alt=" MobBattery6" /></td>
  <td><span data-ttu-id="028e6-1562">EBA6</span><span class="sxs-lookup"><span data-stu-id="028e6-1562">EBA6</span></span></td>
  <td> <span data-ttu-id="028e6-1563">MobBattery6</span><span class="sxs-lookup"><span data-stu-id="028e6-1563">MobBattery6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA7.png" width="32" height="32" alt=" MobBattery7" /></td>
  <td><span data-ttu-id="028e6-1564">EBA7</span><span class="sxs-lookup"><span data-stu-id="028e6-1564">EBA7</span></span></td>
  <td> <span data-ttu-id="028e6-1565">MobBattery7</span><span class="sxs-lookup"><span data-stu-id="028e6-1565">MobBattery7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA8.png" width="32" height="32" alt=" MobBattery8" /></td>
  <td><span data-ttu-id="028e6-1566">EBA8</span><span class="sxs-lookup"><span data-stu-id="028e6-1566">EBA8</span></span></td>
  <td> <span data-ttu-id="028e6-1567">MobBattery8</span><span class="sxs-lookup"><span data-stu-id="028e6-1567">MobBattery8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA9.png" width="32" height="32" alt=" MobBattery9" /></td>
  <td><span data-ttu-id="028e6-1568">EBA9</span><span class="sxs-lookup"><span data-stu-id="028e6-1568">EBA9</span></span></td>
  <td> <span data-ttu-id="028e6-1569">MobBattery9</span><span class="sxs-lookup"><span data-stu-id="028e6-1569">MobBattery9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAA.png" width="32" height="32" alt="MobBattery10" /></td>
  <td><span data-ttu-id="028e6-1570">EBAA</span><span class="sxs-lookup"><span data-stu-id="028e6-1570">EBAA</span></span></td>
  <td><span data-ttu-id="028e6-1571">MobBattery10</span><span class="sxs-lookup"><span data-stu-id="028e6-1571">MobBattery10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAB.png" width="32" height="32" alt=" MobBatteryCharging0" /></td>
  <td><span data-ttu-id="028e6-1572">EBAB</span><span class="sxs-lookup"><span data-stu-id="028e6-1572">EBAB</span></span></td>
  <td> <span data-ttu-id="028e6-1573">MobBatteryCharging0</span><span class="sxs-lookup"><span data-stu-id="028e6-1573">MobBatteryCharging0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAC.png" width="32" height="32" alt=" MobBatteryCharging1" /></td>
  <td><span data-ttu-id="028e6-1574">EBAC</span><span class="sxs-lookup"><span data-stu-id="028e6-1574">EBAC</span></span></td>
  <td> <span data-ttu-id="028e6-1575">MobBatteryCharging1</span><span class="sxs-lookup"><span data-stu-id="028e6-1575">MobBatteryCharging1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAD.png" width="32" height="32" alt=" MobBatteryCharging2" /></td>
  <td><span data-ttu-id="028e6-1576">EBAD</span><span class="sxs-lookup"><span data-stu-id="028e6-1576">EBAD</span></span></td>
  <td> <span data-ttu-id="028e6-1577">MobBatteryCharging2</span><span class="sxs-lookup"><span data-stu-id="028e6-1577">MobBatteryCharging2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAE.png" width="32" height="32" alt=" MobBatteryCharging3" /></td>
  <td><span data-ttu-id="028e6-1578">EBAE</span><span class="sxs-lookup"><span data-stu-id="028e6-1578">EBAE</span></span></td>
  <td> <span data-ttu-id="028e6-1579">MobBatteryCharging3</span><span class="sxs-lookup"><span data-stu-id="028e6-1579">MobBatteryCharging3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAF.png" width="32" height="32" alt=" MobBatteryCharging4" /></td>
  <td><span data-ttu-id="028e6-1580">EBAF</span><span class="sxs-lookup"><span data-stu-id="028e6-1580">EBAF</span></span></td>
  <td> <span data-ttu-id="028e6-1581">MobBatteryCharging4</span><span class="sxs-lookup"><span data-stu-id="028e6-1581">MobBatteryCharging4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB0.png" width="32" height="32" alt=" MobBatteryCharging5" /></td>
  <td><span data-ttu-id="028e6-1582">EBB0</span><span class="sxs-lookup"><span data-stu-id="028e6-1582">EBB0</span></span></td>
  <td> <span data-ttu-id="028e6-1583">MobBatteryCharging5</span><span class="sxs-lookup"><span data-stu-id="028e6-1583">MobBatteryCharging5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB1.png" width="32" height="32" alt=" MobBatteryCharging6" /></td>
  <td><span data-ttu-id="028e6-1584">EBB1</span><span class="sxs-lookup"><span data-stu-id="028e6-1584">EBB1</span></span></td>
  <td> <span data-ttu-id="028e6-1585">MobBatteryCharging6</span><span class="sxs-lookup"><span data-stu-id="028e6-1585">MobBatteryCharging6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB2.png" width="32" height="32" alt=" MobBatteryCharging7" /></td>
  <td><span data-ttu-id="028e6-1586">EBB2</span><span class="sxs-lookup"><span data-stu-id="028e6-1586">EBB2</span></span></td>
  <td> <span data-ttu-id="028e6-1587">MobBatteryCharging7</span><span class="sxs-lookup"><span data-stu-id="028e6-1587">MobBatteryCharging7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB3.png" width="32" height="32" alt=" MobBatteryCharging8" /></td>
  <td><span data-ttu-id="028e6-1588">EBB3</span><span class="sxs-lookup"><span data-stu-id="028e6-1588">EBB3</span></span></td>
  <td> <span data-ttu-id="028e6-1589">MobBatteryCharging8</span><span class="sxs-lookup"><span data-stu-id="028e6-1589">MobBatteryCharging8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB4.png" width="32" height="32" alt=" MobBatteryCharging9" /></td>
  <td><span data-ttu-id="028e6-1590">EBB4</span><span class="sxs-lookup"><span data-stu-id="028e6-1590">EBB4</span></span></td>
  <td> <span data-ttu-id="028e6-1591">MobBatteryCharging9</span><span class="sxs-lookup"><span data-stu-id="028e6-1591">MobBatteryCharging9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB5.png" width="32" height="32" alt=" MobBatteryCharging10" /></td>
  <td><span data-ttu-id="028e6-1592">EBB5</span><span class="sxs-lookup"><span data-stu-id="028e6-1592">EBB5</span></span></td>
  <td> <span data-ttu-id="028e6-1593">MobBatteryCharging10</span><span class="sxs-lookup"><span data-stu-id="028e6-1593">MobBatteryCharging10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB6.png" width="32" height="32" alt=" MobBatterySaver0" /></td>
  <td><span data-ttu-id="028e6-1594">EBB6</span><span class="sxs-lookup"><span data-stu-id="028e6-1594">EBB6</span></span></td>
  <td> <span data-ttu-id="028e6-1595">MobBatterySaver0</span><span class="sxs-lookup"><span data-stu-id="028e6-1595">MobBatterySaver0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB7.png" width="32" height="32" alt=" MobBatterySaver1" /></td>
  <td><span data-ttu-id="028e6-1596">EBB7</span><span class="sxs-lookup"><span data-stu-id="028e6-1596">EBB7</span></span></td>
  <td> <span data-ttu-id="028e6-1597">MobBatterySaver1</span><span class="sxs-lookup"><span data-stu-id="028e6-1597">MobBatterySaver1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB8.png" width="32" height="32" alt=" MobBatterySaver2" /></td>
  <td><span data-ttu-id="028e6-1598">EBB8</span><span class="sxs-lookup"><span data-stu-id="028e6-1598">EBB8</span></span></td>
  <td> <span data-ttu-id="028e6-1599">MobBatterySaver2</span><span class="sxs-lookup"><span data-stu-id="028e6-1599">MobBatterySaver2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB9.png" width="32" height="32" alt=" MobBatterySaver3" /></td>
  <td><span data-ttu-id="028e6-1600">EBB9</span><span class="sxs-lookup"><span data-stu-id="028e6-1600">EBB9</span></span></td>
  <td> <span data-ttu-id="028e6-1601">MobBatterySaver3</span><span class="sxs-lookup"><span data-stu-id="028e6-1601">MobBatterySaver3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBA.png" width="32" height="32" alt=" MobBatterySaver4" /></td>
  <td><span data-ttu-id="028e6-1602">EBBA</span><span class="sxs-lookup"><span data-stu-id="028e6-1602">EBBA</span></span></td>
  <td> <span data-ttu-id="028e6-1603">MobBatterySaver4</span><span class="sxs-lookup"><span data-stu-id="028e6-1603">MobBatterySaver4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBB.png" width="32" height="32" alt=" MobBatterySaver5" /></td>
  <td><span data-ttu-id="028e6-1604">EBBB</span><span class="sxs-lookup"><span data-stu-id="028e6-1604">EBBB</span></span></td>
  <td> <span data-ttu-id="028e6-1605">MobBatterySaver5</span><span class="sxs-lookup"><span data-stu-id="028e6-1605">MobBatterySaver5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBC.png" width="32" height="32" alt=" MobBatterySaver6" /></td>
  <td><span data-ttu-id="028e6-1606">EBBC</span><span class="sxs-lookup"><span data-stu-id="028e6-1606">EBBC</span></span></td>
  <td> <span data-ttu-id="028e6-1607">MobBatterySaver6</span><span class="sxs-lookup"><span data-stu-id="028e6-1607">MobBatterySaver6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBD.png" width="32" height="32" alt=" MobBatterySaver7" /></td>
  <td><span data-ttu-id="028e6-1608">EBBD</span><span class="sxs-lookup"><span data-stu-id="028e6-1608">EBBD</span></span></td>
  <td> <span data-ttu-id="028e6-1609">MobBatterySaver7</span><span class="sxs-lookup"><span data-stu-id="028e6-1609">MobBatterySaver7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBE.png" width="32" height="32" alt=" MobBatterySaver8" /></td>
  <td><span data-ttu-id="028e6-1610">EBBE</span><span class="sxs-lookup"><span data-stu-id="028e6-1610">EBBE</span></span></td>
  <td> <span data-ttu-id="028e6-1611">MobBatterySaver8</span><span class="sxs-lookup"><span data-stu-id="028e6-1611">MobBatterySaver8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBF.png" width="32" height="32" alt=" MobBatterySaver9" /></td>
  <td><span data-ttu-id="028e6-1612">EBBF</span><span class="sxs-lookup"><span data-stu-id="028e6-1612">EBBF</span></span></td>
  <td> <span data-ttu-id="028e6-1613">MobBatterySaver9</span><span class="sxs-lookup"><span data-stu-id="028e6-1613">MobBatterySaver9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC0.png" width="32" height="32" alt=" MobBatterySaver10" /></td>
  <td><span data-ttu-id="028e6-1614">EBC0</span><span class="sxs-lookup"><span data-stu-id="028e6-1614">EBC0</span></span></td>
  <td> <span data-ttu-id="028e6-1615">MobBatterySaver10</span><span class="sxs-lookup"><span data-stu-id="028e6-1615">MobBatterySaver10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC3.png" width="32" height="32" alt="DictionaryCloud" /></td>
  <td><span data-ttu-id="028e6-1616">EBC3</span><span class="sxs-lookup"><span data-stu-id="028e6-1616">EBC3</span></span></td>
  <td><span data-ttu-id="028e6-1617">DictionaryCloud</span><span class="sxs-lookup"><span data-stu-id="028e6-1617">DictionaryCloud</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC4.png" width="32" height="32" alt="ResetDrive" /></td>
  <td><span data-ttu-id="028e6-1618">EBC4</span><span class="sxs-lookup"><span data-stu-id="028e6-1618">EBC4</span></span></td>
  <td><span data-ttu-id="028e6-1619">ResetDrive</span><span class="sxs-lookup"><span data-stu-id="028e6-1619">ResetDrive</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC5.png" width="32" height="32" alt="VolumeBars" /></td>
  <td><span data-ttu-id="028e6-1620">EBC5</span><span class="sxs-lookup"><span data-stu-id="028e6-1620">EBC5</span></span></td>
  <td><span data-ttu-id="028e6-1621">VolumeBars</span><span class="sxs-lookup"><span data-stu-id="028e6-1621">VolumeBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC6.png" width="32" height="32" alt="Project" /></td>
  <td><span data-ttu-id="028e6-1622">EBC6</span><span class="sxs-lookup"><span data-stu-id="028e6-1622">EBC6</span></span></td>
  <td><span data-ttu-id="028e6-1623">Project</span><span class="sxs-lookup"><span data-stu-id="028e6-1623">Project</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD2.png" width="32" height="32" alt="AdjustHologram" /></td>
  <td><span data-ttu-id="028e6-1624">EBD2</span><span class="sxs-lookup"><span data-stu-id="028e6-1624">EBD2</span></span></td>
  <td><span data-ttu-id="028e6-1625">AdjustHologram</span><span class="sxs-lookup"><span data-stu-id="028e6-1625">AdjustHologram</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD4.png" width="32" height="32" alt="WifiCallBars" /></td>
  <td><span data-ttu-id="028e6-1626">EBD4</span><span class="sxs-lookup"><span data-stu-id="028e6-1626">EBD4</span></span></td>
  <td><span data-ttu-id="028e6-1627">WifiCallBars</span><span class="sxs-lookup"><span data-stu-id="028e6-1627">WifiCallBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD5.png" width="32" height="32" alt="WifiCall0" /></td>
  <td><span data-ttu-id="028e6-1628">EBD5</span><span class="sxs-lookup"><span data-stu-id="028e6-1628">EBD5</span></span></td>
  <td><span data-ttu-id="028e6-1629">WifiCall0</span><span class="sxs-lookup"><span data-stu-id="028e6-1629">WifiCall0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD6.png" width="32" height="32" alt="WifiCall1" /></td>
  <td><span data-ttu-id="028e6-1630">EBD6</span><span class="sxs-lookup"><span data-stu-id="028e6-1630">EBD6</span></span></td>
  <td><span data-ttu-id="028e6-1631">WifiCall1</span><span class="sxs-lookup"><span data-stu-id="028e6-1631">WifiCall1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD7.png" width="32" height="32" alt="WifiCall2" /></td>
  <td><span data-ttu-id="028e6-1632">EBD7</span><span class="sxs-lookup"><span data-stu-id="028e6-1632">EBD7</span></span></td>
  <td><span data-ttu-id="028e6-1633">WifiCall2</span><span class="sxs-lookup"><span data-stu-id="028e6-1633">WifiCall2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD8.png" width="32" height="32" alt="WifiCall3" /></td>
  <td><span data-ttu-id="028e6-1634">EBD8</span><span class="sxs-lookup"><span data-stu-id="028e6-1634">EBD8</span></span></td>
  <td><span data-ttu-id="028e6-1635">WifiCall3</span><span class="sxs-lookup"><span data-stu-id="028e6-1635">WifiCall3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD9.png" width="32" height="32" alt="WifiCall4" /></td>
  <td><span data-ttu-id="028e6-1636">EBD9</span><span class="sxs-lookup"><span data-stu-id="028e6-1636">EBD9</span></span></td>
  <td><span data-ttu-id="028e6-1637">WifiCall4</span><span class="sxs-lookup"><span data-stu-id="028e6-1637">WifiCall4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBDA.png" width="32" height="32" alt="Family" /></td>
  <td><span data-ttu-id="028e6-1638">EBDA</span><span class="sxs-lookup"><span data-stu-id="028e6-1638">EBDA</span></span></td>
  <td><span data-ttu-id="028e6-1639">Family (ファミリ)</span><span class="sxs-lookup"><span data-stu-id="028e6-1639">Family</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBDB.png" width="32" height="32" alt="LockFeedback" /></td>
  <td><span data-ttu-id="028e6-1640">EBDB</span><span class="sxs-lookup"><span data-stu-id="028e6-1640">EBDB</span></span></td>
  <td><span data-ttu-id="028e6-1641">LockFeedback</span><span class="sxs-lookup"><span data-stu-id="028e6-1641">LockFeedback</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBDE.png" width="32" height="32" alt="DeviceDiscovery" /></td>
  <td><span data-ttu-id="028e6-1642">EBDE</span><span class="sxs-lookup"><span data-stu-id="028e6-1642">EBDE</span></span></td>
  <td><span data-ttu-id="028e6-1643">DeviceDiscovery</span><span class="sxs-lookup"><span data-stu-id="028e6-1643">DeviceDiscovery</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBE6.png" width="32" height="32" alt="WindDirection" /></td>
  <td><span data-ttu-id="028e6-1644">EBE6</span><span class="sxs-lookup"><span data-stu-id="028e6-1644">EBE6</span></span></td>
  <td><span data-ttu-id="028e6-1645">WindDirection</span><span class="sxs-lookup"><span data-stu-id="028e6-1645">WindDirection</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBE7.png" width="32" height="32" alt="RightArrowKeyTime0" /></td>
  <td><span data-ttu-id="028e6-1646">EBE7</span><span class="sxs-lookup"><span data-stu-id="028e6-1646">EBE7</span></span></td>
  <td><span data-ttu-id="028e6-1647">RightArrowKeyTime0</span><span class="sxs-lookup"><span data-stu-id="028e6-1647">RightArrowKeyTime0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBE8.png" width="32" height="32" alt="Bug" /></td>
  <td><span data-ttu-id="028e6-1648">EBE8</span><span class="sxs-lookup"><span data-stu-id="028e6-1648">EBE8</span></span></td>
  <td><span data-ttu-id="028e6-1649">バグ</span><span class="sxs-lookup"><span data-stu-id="028e6-1649">Bug</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBFC.png" width="32" height="32" alt="TabletMode" /></td>
  <td><span data-ttu-id="028e6-1650">EBFC</span><span class="sxs-lookup"><span data-stu-id="028e6-1650">EBFC</span></span></td>
  <td><span data-ttu-id="028e6-1651">TabletMode</span><span class="sxs-lookup"><span data-stu-id="028e6-1651">TabletMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBFD.png" width="32" height="32" alt="StatusCircleLeft" /></td>
  <td><span data-ttu-id="028e6-1652">EBFD</span><span class="sxs-lookup"><span data-stu-id="028e6-1652">EBFD</span></span></td>
  <td><span data-ttu-id="028e6-1653">StatusCircleLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-1653">StatusCircleLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBFE.png" width="32" height="32" alt="StatusTriangleLeft" /></td>
  <td><span data-ttu-id="028e6-1654">EBFE</span><span class="sxs-lookup"><span data-stu-id="028e6-1654">EBFE</span></span></td>
  <td><span data-ttu-id="028e6-1655">StatusTriangleLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-1655">StatusTriangleLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBFF.png" width="32" height="32" alt="StatusErrorLeft" /></td>
  <td><span data-ttu-id="028e6-1656">EBFF</span><span class="sxs-lookup"><span data-stu-id="028e6-1656">EBFF</span></span></td>
  <td><span data-ttu-id="028e6-1657">StatusErrorLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-1657">StatusErrorLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC00.png" width="32" height="32" alt="StatusWarningLeft" /></td>
  <td><span data-ttu-id="028e6-1658">EC00</span><span class="sxs-lookup"><span data-stu-id="028e6-1658">EC00</span></span></td>
  <td><span data-ttu-id="028e6-1659">StatusWarningLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-1659">StatusWarningLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC02.png" width="32" height="32" alt="MobBatteryUnknown" /></td>
  <td><span data-ttu-id="028e6-1660">EC02</span><span class="sxs-lookup"><span data-stu-id="028e6-1660">EC02</span></span></td>
  <td><span data-ttu-id="028e6-1661">MobBatteryUnknown</span><span class="sxs-lookup"><span data-stu-id="028e6-1661">MobBatteryUnknown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC05.png" width="32" height="32" alt="NetworkTower" /></td>
  <td><span data-ttu-id="028e6-1662">EC05</span><span class="sxs-lookup"><span data-stu-id="028e6-1662">EC05</span></span></td>
  <td><span data-ttu-id="028e6-1663">NetworkTower</span><span class="sxs-lookup"><span data-stu-id="028e6-1663">NetworkTower</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC06.png" width="32" height="32" alt="CityNext" /></td>
  <td><span data-ttu-id="028e6-1664">EC06</span><span class="sxs-lookup"><span data-stu-id="028e6-1664">EC06</span></span></td>
  <td><span data-ttu-id="028e6-1665">CityNext</span><span class="sxs-lookup"><span data-stu-id="028e6-1665">CityNext</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC07.png" width="32" height="32" alt="CityNext2" /></td>
  <td><span data-ttu-id="028e6-1666">EC07</span><span class="sxs-lookup"><span data-stu-id="028e6-1666">EC07</span></span></td>
  <td><span data-ttu-id="028e6-1667">CityNext2</span><span class="sxs-lookup"><span data-stu-id="028e6-1667">CityNext2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC08.png" width="32" height="32" alt="Courthouse" /></td>
  <td><span data-ttu-id="028e6-1668">EC08</span><span class="sxs-lookup"><span data-stu-id="028e6-1668">EC08</span></span></td>
  <td><span data-ttu-id="028e6-1669">Courthouse</span><span class="sxs-lookup"><span data-stu-id="028e6-1669">Courthouse</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC09.png" width="32" height="32" alt="Groceries" /></td>
  <td><span data-ttu-id="028e6-1670">EC09</span><span class="sxs-lookup"><span data-stu-id="028e6-1670">EC09</span></span></td>
  <td><span data-ttu-id="028e6-1671">Groceries</span><span class="sxs-lookup"><span data-stu-id="028e6-1671">Groceries</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC0A.png" width="32" height="32" alt="Sustainable" /></td>
  <td><span data-ttu-id="028e6-1672">EC0A</span><span class="sxs-lookup"><span data-stu-id="028e6-1672">EC0A</span></span></td>
  <td><span data-ttu-id="028e6-1673">Sustainable</span><span class="sxs-lookup"><span data-stu-id="028e6-1673">Sustainable</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC0B.png" width="32" height="32" alt="BuildingEnergy" /></td>
  <td><span data-ttu-id="028e6-1674">EC0B</span><span class="sxs-lookup"><span data-stu-id="028e6-1674">EC0B</span></span></td>
  <td><span data-ttu-id="028e6-1675">BuildingEnergy</span><span class="sxs-lookup"><span data-stu-id="028e6-1675">BuildingEnergy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC11.png" width="32" height="32" alt="ToggleFilled" /></td>
  <td><span data-ttu-id="028e6-1676">EC11</span><span class="sxs-lookup"><span data-stu-id="028e6-1676">EC11</span></span></td>
  <td><span data-ttu-id="028e6-1677">ToggleFilled</span><span class="sxs-lookup"><span data-stu-id="028e6-1677">ToggleFilled</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC12.png" width="32" height="32" alt="ToggleBorder" /></td>
  <td><span data-ttu-id="028e6-1678">EC12</span><span class="sxs-lookup"><span data-stu-id="028e6-1678">EC12</span></span></td>
  <td><span data-ttu-id="028e6-1679">ToggleBorder</span><span class="sxs-lookup"><span data-stu-id="028e6-1679">ToggleBorder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC13.png" width="32" height="32" alt="SliderThumb" /></td>
  <td><span data-ttu-id="028e6-1680">EC13</span><span class="sxs-lookup"><span data-stu-id="028e6-1680">EC13</span></span></td>
  <td><span data-ttu-id="028e6-1681">SliderThumb</span><span class="sxs-lookup"><span data-stu-id="028e6-1681">SliderThumb</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC14.png" width="32" height="32" alt="ToggleThumb" /></td>
  <td><span data-ttu-id="028e6-1682">EC14</span><span class="sxs-lookup"><span data-stu-id="028e6-1682">EC14</span></span></td>
  <td><span data-ttu-id="028e6-1683">ToggleThumb</span><span class="sxs-lookup"><span data-stu-id="028e6-1683">ToggleThumb</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC15.png" width="32" height="32" alt="MiracastLogoSmall" /></td>
  <td><span data-ttu-id="028e6-1684">EC15</span><span class="sxs-lookup"><span data-stu-id="028e6-1684">EC15</span></span></td>
  <td><span data-ttu-id="028e6-1685">MiracastLogoSmall</span><span class="sxs-lookup"><span data-stu-id="028e6-1685">MiracastLogoSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC16.png" width="32" height="32" alt="MiracastLogoLarge" /></td>
  <td><span data-ttu-id="028e6-1686">EC16</span><span class="sxs-lookup"><span data-stu-id="028e6-1686">EC16</span></span></td>
  <td><span data-ttu-id="028e6-1687">MiracastLogoLarge</span><span class="sxs-lookup"><span data-stu-id="028e6-1687">MiracastLogoLarge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC19.png" width="32" height="32" alt="PLAP" /></td>
  <td><span data-ttu-id="028e6-1688">EC19</span><span class="sxs-lookup"><span data-stu-id="028e6-1688">EC19</span></span></td>
  <td><span data-ttu-id="028e6-1689">PLAP</span><span class="sxs-lookup"><span data-stu-id="028e6-1689">PLAP</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC1B.png" width="32" height="32" alt="Badge" /></td>
  <td><span data-ttu-id="028e6-1690">EC1B</span><span class="sxs-lookup"><span data-stu-id="028e6-1690">EC1B</span></span></td>
  <td><span data-ttu-id="028e6-1691">Badge</span><span class="sxs-lookup"><span data-stu-id="028e6-1691">Badge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC1E.png" width="32" height="32" alt="SignalRoaming" /></td>
  <td><span data-ttu-id="028e6-1692">EC1E</span><span class="sxs-lookup"><span data-stu-id="028e6-1692">EC1E</span></span></td>
  <td><span data-ttu-id="028e6-1693">SignalRoaming</span><span class="sxs-lookup"><span data-stu-id="028e6-1693">SignalRoaming</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC20.png" width="32" height="32" alt="MobileLocked" /></td>
  <td><span data-ttu-id="028e6-1694">EC20</span><span class="sxs-lookup"><span data-stu-id="028e6-1694">EC20</span></span></td>
  <td><span data-ttu-id="028e6-1695">MobileLocked</span><span class="sxs-lookup"><span data-stu-id="028e6-1695">MobileLocked</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC24.png" width="32" height="32" alt="InsiderHubApp" /></td>
  <td><span data-ttu-id="028e6-1696">EC24</span><span class="sxs-lookup"><span data-stu-id="028e6-1696">EC24</span></span></td>
  <td><span data-ttu-id="028e6-1697">InsiderHubApp</span><span class="sxs-lookup"><span data-stu-id="028e6-1697">InsiderHubApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC25.png" width="32" height="32" alt="PersonalFolder" /></td>
  <td><span data-ttu-id="028e6-1698">EC25</span><span class="sxs-lookup"><span data-stu-id="028e6-1698">EC25</span></span></td>
  <td><span data-ttu-id="028e6-1699">PersonalFolder</span><span class="sxs-lookup"><span data-stu-id="028e6-1699">PersonalFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC26.png" width="32" height="32" alt="HomeGroup" /></td>
  <td><span data-ttu-id="028e6-1700">EC26</span><span class="sxs-lookup"><span data-stu-id="028e6-1700">EC26</span></span></td>
  <td><span data-ttu-id="028e6-1701">ホームグループ</span><span class="sxs-lookup"><span data-stu-id="028e6-1701">HomeGroup</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC27.png" width="32" height="32" alt="MyNetwork" /></td>
  <td><span data-ttu-id="028e6-1702">EC27</span><span class="sxs-lookup"><span data-stu-id="028e6-1702">EC27</span></span></td>
  <td><span data-ttu-id="028e6-1703">MyNetwork</span><span class="sxs-lookup"><span data-stu-id="028e6-1703">MyNetwork</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC31.png" width="32" height="32" alt="KeyboardFull" /></td>
  <td><span data-ttu-id="028e6-1704">EC31</span><span class="sxs-lookup"><span data-stu-id="028e6-1704">EC31</span></span></td>
  <td><span data-ttu-id="028e6-1705">KeyboardFull</span><span class="sxs-lookup"><span data-stu-id="028e6-1705">KeyboardFull</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC32.png" width="32" height="32" alt="Cafe" /></td>
  <td><span data-ttu-id="028e6-1706">EC32</span><span class="sxs-lookup"><span data-stu-id="028e6-1706">EC32</span></span></td>
  <td><span data-ttu-id="028e6-1707">カフェ</span><span class="sxs-lookup"><span data-stu-id="028e6-1707">Cafe</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC37.png" width="32" height="32" alt="MobSignal1" /></td>
  <td><span data-ttu-id="028e6-1708">EC37</span><span class="sxs-lookup"><span data-stu-id="028e6-1708">EC37</span></span></td>
  <td><span data-ttu-id="028e6-1709">MobSignal1</span><span class="sxs-lookup"><span data-stu-id="028e6-1709">MobSignal1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC38.png" width="32" height="32" alt="MobSignal2" /></td>
  <td><span data-ttu-id="028e6-1710">EC38</span><span class="sxs-lookup"><span data-stu-id="028e6-1710">EC38</span></span></td>
  <td><span data-ttu-id="028e6-1711">MobSignal2</span><span class="sxs-lookup"><span data-stu-id="028e6-1711">MobSignal2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC39.png" width="32" height="32" alt="MobSignal3" /></td>
  <td><span data-ttu-id="028e6-1712">EC39</span><span class="sxs-lookup"><span data-stu-id="028e6-1712">EC39</span></span></td>
  <td><span data-ttu-id="028e6-1713">MobSignal3</span><span class="sxs-lookup"><span data-stu-id="028e6-1713">MobSignal3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3A.png" width="32" height="32" alt="MobSignal4" /></td>
  <td><span data-ttu-id="028e6-1714">EC3A</span><span class="sxs-lookup"><span data-stu-id="028e6-1714">EC3A</span></span></td>
  <td><span data-ttu-id="028e6-1715">MobSignal4</span><span class="sxs-lookup"><span data-stu-id="028e6-1715">MobSignal4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3B.png" width="32" height="32" alt="MobSignal5" /></td>
  <td><span data-ttu-id="028e6-1716">EC3B</span><span class="sxs-lookup"><span data-stu-id="028e6-1716">EC3B</span></span></td>
  <td><span data-ttu-id="028e6-1717">MobSignal5</span><span class="sxs-lookup"><span data-stu-id="028e6-1717">MobSignal5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3C.png" width="32" height="32" alt="MobWifi1" /></td>
  <td><span data-ttu-id="028e6-1718">EC3C</span><span class="sxs-lookup"><span data-stu-id="028e6-1718">EC3C</span></span></td>
  <td><span data-ttu-id="028e6-1719">MobWifi1</span><span class="sxs-lookup"><span data-stu-id="028e6-1719">MobWifi1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3D.png" width="32" height="32" alt="MobWifi2" /></td>
  <td><span data-ttu-id="028e6-1720">EC3D</span><span class="sxs-lookup"><span data-stu-id="028e6-1720">EC3D</span></span></td>
  <td><span data-ttu-id="028e6-1721">MobWifi2</span><span class="sxs-lookup"><span data-stu-id="028e6-1721">MobWifi2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3E.png" width="32" height="32" alt="MobWifi3" /></td>
  <td><span data-ttu-id="028e6-1722">EC3E</span><span class="sxs-lookup"><span data-stu-id="028e6-1722">EC3E</span></span></td>
  <td><span data-ttu-id="028e6-1723">MobWifi3</span><span class="sxs-lookup"><span data-stu-id="028e6-1723">MobWifi3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3F.png" width="32" height="32" alt="MobWifi4" /></td>
  <td><span data-ttu-id="028e6-1724">EC3F</span><span class="sxs-lookup"><span data-stu-id="028e6-1724">EC3F</span></span></td>
  <td><span data-ttu-id="028e6-1725">MobWifi4</span><span class="sxs-lookup"><span data-stu-id="028e6-1725">MobWifi4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC40.png" width="32" height="32" alt="MobAirplane" /></td>
  <td><span data-ttu-id="028e6-1726">EC40</span><span class="sxs-lookup"><span data-stu-id="028e6-1726">EC40</span></span></td>
  <td><span data-ttu-id="028e6-1727">MobAirplane</span><span class="sxs-lookup"><span data-stu-id="028e6-1727">MobAirplane</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC41.png" width="32" height="32" alt="MobBluetooth" /></td>
  <td><span data-ttu-id="028e6-1728">EC41</span><span class="sxs-lookup"><span data-stu-id="028e6-1728">EC41</span></span></td>
  <td><span data-ttu-id="028e6-1729">MobBluetooth</span><span class="sxs-lookup"><span data-stu-id="028e6-1729">MobBluetooth</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC42.png" width="32" height="32" alt="MobActionCenter" /></td>
  <td><span data-ttu-id="028e6-1730">EC42</span><span class="sxs-lookup"><span data-stu-id="028e6-1730">EC42</span></span></td>
  <td><span data-ttu-id="028e6-1731">MobActionCenter</span><span class="sxs-lookup"><span data-stu-id="028e6-1731">MobActionCenter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC43.png" width="32" height="32" alt="MobLocation" /></td>
  <td><span data-ttu-id="028e6-1732">EC43</span><span class="sxs-lookup"><span data-stu-id="028e6-1732">EC43</span></span></td>
  <td><span data-ttu-id="028e6-1733">MobLocation</span><span class="sxs-lookup"><span data-stu-id="028e6-1733">MobLocation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC44.png" width="32" height="32" alt="MobWifiHotspot" /></td>
  <td><span data-ttu-id="028e6-1734">EC44</span><span class="sxs-lookup"><span data-stu-id="028e6-1734">EC44</span></span></td>
  <td><span data-ttu-id="028e6-1735">MobWifiHotspot</span><span class="sxs-lookup"><span data-stu-id="028e6-1735">MobWifiHotspot</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC45.png" width="32" height="32" alt="LanguageJpn" /></td>
  <td><span data-ttu-id="028e6-1736">EC45</span><span class="sxs-lookup"><span data-stu-id="028e6-1736">EC45</span></span></td>
  <td><span data-ttu-id="028e6-1737">LanguageJpn</span><span class="sxs-lookup"><span data-stu-id="028e6-1737">LanguageJpn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC46.png" width="32" height="32" alt="MobQuietHours" /></td>
  <td><span data-ttu-id="028e6-1738">EC46</span><span class="sxs-lookup"><span data-stu-id="028e6-1738">EC46</span></span></td>
  <td><span data-ttu-id="028e6-1739">MobQuietHours</span><span class="sxs-lookup"><span data-stu-id="028e6-1739">MobQuietHours</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC47.png" width="32" height="32" alt="MobDrivingMode" /></td>
  <td><span data-ttu-id="028e6-1740">EC47</span><span class="sxs-lookup"><span data-stu-id="028e6-1740">EC47</span></span></td>
  <td><span data-ttu-id="028e6-1741">MobDrivingMode</span><span class="sxs-lookup"><span data-stu-id="028e6-1741">MobDrivingMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC48.png" width="32" height="32" alt="SpeedOff" /></td>
  <td><span data-ttu-id="028e6-1742">EC48</span><span class="sxs-lookup"><span data-stu-id="028e6-1742">EC48</span></span></td>
  <td><span data-ttu-id="028e6-1743">SpeedOff</span><span class="sxs-lookup"><span data-stu-id="028e6-1743">SpeedOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC49.png" width="32" height="32" alt="SpeedMedium" /></td>
  <td><span data-ttu-id="028e6-1744">EC49</span><span class="sxs-lookup"><span data-stu-id="028e6-1744">EC49</span></span></td>
  <td><span data-ttu-id="028e6-1745">SpeedMedium</span><span class="sxs-lookup"><span data-stu-id="028e6-1745">SpeedMedium</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC4A.png" width="32" height="32" alt="SpeedHigh" /></td>
  <td><span data-ttu-id="028e6-1746">EC4A</span><span class="sxs-lookup"><span data-stu-id="028e6-1746">EC4A</span></span></td>
  <td><span data-ttu-id="028e6-1747">SpeedHigh</span><span class="sxs-lookup"><span data-stu-id="028e6-1747">SpeedHigh</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC4E.png" width="32" height="32" alt="ThisPC" /></td>
  <td><span data-ttu-id="028e6-1748">EC4E</span><span class="sxs-lookup"><span data-stu-id="028e6-1748">EC4E</span></span></td>
  <td><span data-ttu-id="028e6-1749">ThisPC</span><span class="sxs-lookup"><span data-stu-id="028e6-1749">ThisPC</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC4F.png" width="32" height="32" alt="MusicNote" /></td>
  <td><span data-ttu-id="028e6-1750">EC4F</span><span class="sxs-lookup"><span data-stu-id="028e6-1750">EC4F</span></span></td>
  <td><span data-ttu-id="028e6-1751">MusicNote</span><span class="sxs-lookup"><span data-stu-id="028e6-1751">MusicNote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC50.png" width="32" height="32" alt="FileExplorer" /></td>
  <td><span data-ttu-id="028e6-1752">EC50</span><span class="sxs-lookup"><span data-stu-id="028e6-1752">EC50</span></span></td>
  <td><span data-ttu-id="028e6-1753">FileExplorer</span><span class="sxs-lookup"><span data-stu-id="028e6-1753">FileExplorer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC51.png" width="32" height="32" alt="FileExplorerApp" /></td>
  <td><span data-ttu-id="028e6-1754">EC51</span><span class="sxs-lookup"><span data-stu-id="028e6-1754">EC51</span></span></td>
  <td><span data-ttu-id="028e6-1755">FileExplorerApp</span><span class="sxs-lookup"><span data-stu-id="028e6-1755">FileExplorerApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC52.png" width="32" height="32" alt="LeftArrowKeyTime0" /></td>
  <td><span data-ttu-id="028e6-1756">EC52</span><span class="sxs-lookup"><span data-stu-id="028e6-1756">EC52</span></span></td>
  <td><span data-ttu-id="028e6-1757">LeftArrowKeyTime0</span><span class="sxs-lookup"><span data-stu-id="028e6-1757">LeftArrowKeyTime0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC54.png" width="32" height="32" alt="MicOff" /></td>
  <td><span data-ttu-id="028e6-1758">EC54</span><span class="sxs-lookup"><span data-stu-id="028e6-1758">EC54</span></span></td>
  <td><span data-ttu-id="028e6-1759">MicOff</span><span class="sxs-lookup"><span data-stu-id="028e6-1759">MicOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC55.png" width="32" height="32" alt="MicSleep" /></td>
  <td><span data-ttu-id="028e6-1760">EC55</span><span class="sxs-lookup"><span data-stu-id="028e6-1760">EC55</span></span></td>
  <td><span data-ttu-id="028e6-1761">MicSleep</span><span class="sxs-lookup"><span data-stu-id="028e6-1761">MicSleep</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC56.png" width="32" height="32" alt="MicError" /></td>
  <td><span data-ttu-id="028e6-1762">EC56</span><span class="sxs-lookup"><span data-stu-id="028e6-1762">EC56</span></span></td>
  <td><span data-ttu-id="028e6-1763">MicError</span><span class="sxs-lookup"><span data-stu-id="028e6-1763">MicError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC57.png" width="32" height="32" alt="PlaybackRate1x" /></td>
  <td><span data-ttu-id="028e6-1764">EC57</span><span class="sxs-lookup"><span data-stu-id="028e6-1764">EC57</span></span></td>
  <td><span data-ttu-id="028e6-1765">PlaybackRate1x</span><span class="sxs-lookup"><span data-stu-id="028e6-1765">PlaybackRate1x</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC58.png" width="32" height="32" alt="PlaybackRateOther" /></td>
  <td><span data-ttu-id="028e6-1766">EC58</span><span class="sxs-lookup"><span data-stu-id="028e6-1766">EC58</span></span></td>
  <td><span data-ttu-id="028e6-1767">PlaybackRateOther</span><span class="sxs-lookup"><span data-stu-id="028e6-1767">PlaybackRateOther</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC59.png" width="32" height="32" alt="CashDrawer" /></td>
  <td><span data-ttu-id="028e6-1768">EC59</span><span class="sxs-lookup"><span data-stu-id="028e6-1768">EC59</span></span></td>
  <td><span data-ttu-id="028e6-1769">CashDrawer</span><span class="sxs-lookup"><span data-stu-id="028e6-1769">CashDrawer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC5A.png" width="32" height="32" alt="BarcodeScanner" /></td>
  <td><span data-ttu-id="028e6-1770">EC5A</span><span class="sxs-lookup"><span data-stu-id="028e6-1770">EC5A</span></span></td>
  <td><span data-ttu-id="028e6-1771">BarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="028e6-1771">BarcodeScanner</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC5B.png" width="32" height="32" alt="ReceiptPrinter" /></td>
  <td><span data-ttu-id="028e6-1772">EC5B</span><span class="sxs-lookup"><span data-stu-id="028e6-1772">EC5B</span></span></td>
  <td><span data-ttu-id="028e6-1773">ReceiptPrinter</span><span class="sxs-lookup"><span data-stu-id="028e6-1773">ReceiptPrinter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC5C.png" width="32" height="32" alt="MagStripeReader" /></td>
  <td><span data-ttu-id="028e6-1774">EC5C</span><span class="sxs-lookup"><span data-stu-id="028e6-1774">EC5C</span></span></td>
  <td><span data-ttu-id="028e6-1775">MagStripeReader</span><span class="sxs-lookup"><span data-stu-id="028e6-1775">MagStripeReader</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC61.png" width="32" height="32" alt="CompletedSolid" /></td>
  <td><span data-ttu-id="028e6-1776">EC61</span><span class="sxs-lookup"><span data-stu-id="028e6-1776">EC61</span></span></td>
  <td><span data-ttu-id="028e6-1777">CompletedSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1777">CompletedSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC64.png" width="32" height="32" alt="CompanionApp" /></td>
  <td><span data-ttu-id="028e6-1778">EC64</span><span class="sxs-lookup"><span data-stu-id="028e6-1778">EC64</span></span></td>
  <td><span data-ttu-id="028e6-1779">CompanionApp</span><span class="sxs-lookup"><span data-stu-id="028e6-1779">CompanionApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC6D.png" width="32" height="32" alt="SwipeRevealArt" /></td>
  <td><span data-ttu-id="028e6-1780">EC6D</span><span class="sxs-lookup"><span data-stu-id="028e6-1780">EC6D</span></span></td>
  <td><span data-ttu-id="028e6-1781">SwipeRevealArt</span><span class="sxs-lookup"><span data-stu-id="028e6-1781">SwipeRevealArt</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC71.png" width="32" height="32" alt="MicOn" /></td>
  <td><span data-ttu-id="028e6-1782">EC71</span><span class="sxs-lookup"><span data-stu-id="028e6-1782">EC71</span></span></td>
  <td><span data-ttu-id="028e6-1783">MicOn</span><span class="sxs-lookup"><span data-stu-id="028e6-1783">MicOn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC72.png" width="32" height="32" alt="MicClipping" /></td>
  <td><span data-ttu-id="028e6-1784">EC72</span><span class="sxs-lookup"><span data-stu-id="028e6-1784">EC72</span></span></td>
  <td><span data-ttu-id="028e6-1785">MicClipping</span><span class="sxs-lookup"><span data-stu-id="028e6-1785">MicClipping</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC74.png" width="32" height="32" alt="TabletSelected" /></td>
  <td><span data-ttu-id="028e6-1786">EC74</span><span class="sxs-lookup"><span data-stu-id="028e6-1786">EC74</span></span></td>
  <td><span data-ttu-id="028e6-1787">TabletSelected</span><span class="sxs-lookup"><span data-stu-id="028e6-1787">TabletSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC75.png" width="32" height="32" alt="MobileSelected" /></td>
  <td><span data-ttu-id="028e6-1788">EC75</span><span class="sxs-lookup"><span data-stu-id="028e6-1788">EC75</span></span></td>
  <td><span data-ttu-id="028e6-1789">MobileSelected</span><span class="sxs-lookup"><span data-stu-id="028e6-1789">MobileSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC76.png" width="32" height="32" alt="LaptopSelected" /></td>
  <td><span data-ttu-id="028e6-1790">EC76</span><span class="sxs-lookup"><span data-stu-id="028e6-1790">EC76</span></span></td>
  <td><span data-ttu-id="028e6-1791">LaptopSelected</span><span class="sxs-lookup"><span data-stu-id="028e6-1791">LaptopSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC77.png" width="32" height="32" alt="TVMonitorSelected" /></td>
  <td><span data-ttu-id="028e6-1792">EC77</span><span class="sxs-lookup"><span data-stu-id="028e6-1792">EC77</span></span></td>
  <td><span data-ttu-id="028e6-1793">TVMonitorSelected</span><span class="sxs-lookup"><span data-stu-id="028e6-1793">TVMonitorSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC7A.png" width="32" height="32" alt="DeveloperTools" /></td>
  <td><span data-ttu-id="028e6-1794">EC7A</span><span class="sxs-lookup"><span data-stu-id="028e6-1794">EC7A</span></span></td>
  <td><span data-ttu-id="028e6-1795">DeveloperTools</span><span class="sxs-lookup"><span data-stu-id="028e6-1795">DeveloperTools</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC7E.png" width="32" height="32" alt="MobCallForwarding" /></td>
  <td><span data-ttu-id="028e6-1796">EC7E</span><span class="sxs-lookup"><span data-stu-id="028e6-1796">EC7E</span></span></td>
  <td><span data-ttu-id="028e6-1797">MobCallForwarding</span><span class="sxs-lookup"><span data-stu-id="028e6-1797">MobCallForwarding</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC7F.png" width="32" height="32" alt="MobCallForwardingMirrored" /></td>
  <td><span data-ttu-id="028e6-1798">EC7F</span><span class="sxs-lookup"><span data-stu-id="028e6-1798">EC7F</span></span></td>
  <td><span data-ttu-id="028e6-1799">MobCallForwardingMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1799">MobCallForwardingMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC80.png" width="32" height="32" alt="BodyCam" /></td>
  <td><span data-ttu-id="028e6-1800">EC80</span><span class="sxs-lookup"><span data-stu-id="028e6-1800">EC80</span></span></td>
  <td><span data-ttu-id="028e6-1801">BodyCam</span><span class="sxs-lookup"><span data-stu-id="028e6-1801">BodyCam</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC81.png" width="32" height="32" alt="PoliceCar" /></td>
  <td><span data-ttu-id="028e6-1802">EC81</span><span class="sxs-lookup"><span data-stu-id="028e6-1802">EC81</span></span></td>
  <td><span data-ttu-id="028e6-1803">PoliceCar</span><span class="sxs-lookup"><span data-stu-id="028e6-1803">PoliceCar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC87.png" width="32" height="32" alt="Draw" /></td>
  <td><span data-ttu-id="028e6-1804">EC87</span><span class="sxs-lookup"><span data-stu-id="028e6-1804">EC87</span></span></td>
  <td><span data-ttu-id="028e6-1805">Draw</span><span class="sxs-lookup"><span data-stu-id="028e6-1805">Draw</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC88.png" width="32" height="32" alt="DrawSolid" /></td>
  <td><span data-ttu-id="028e6-1806">EC88</span><span class="sxs-lookup"><span data-stu-id="028e6-1806">EC88</span></span></td>
  <td><span data-ttu-id="028e6-1807">DrawSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-1807">DrawSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC8A.png" width="32" height="32" alt="LowerBrightness" /></td>
  <td><span data-ttu-id="028e6-1808">EC8A</span><span class="sxs-lookup"><span data-stu-id="028e6-1808">EC8A</span></span></td>
  <td><span data-ttu-id="028e6-1809">LowerBrightness</span><span class="sxs-lookup"><span data-stu-id="028e6-1809">LowerBrightness</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC8F.png" width="32" height="32" alt="ScrollUpDown" /></td>
  <td><span data-ttu-id="028e6-1810">EC8F</span><span class="sxs-lookup"><span data-stu-id="028e6-1810">EC8F</span></span></td>
  <td><span data-ttu-id="028e6-1811">ScrollUpDown</span><span class="sxs-lookup"><span data-stu-id="028e6-1811">ScrollUpDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC92.png" width="32" height="32" alt="DateTime" /></td>
  <td><span data-ttu-id="028e6-1812">EC92</span><span class="sxs-lookup"><span data-stu-id="028e6-1812">EC92</span></span></td>
  <td><span data-ttu-id="028e6-1813">DateTime</span><span class="sxs-lookup"><span data-stu-id="028e6-1813">DateTime</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECA5.png" width="32" height="32" alt="Tiles" /></td>
  <td><span data-ttu-id="028e6-1814">ECA5</span><span class="sxs-lookup"><span data-stu-id="028e6-1814">ECA5</span></span></td>
  <td><span data-ttu-id="028e6-1815">Tiles</span><span class="sxs-lookup"><span data-stu-id="028e6-1815">Tiles</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECA7.png" width="32" height="32" alt="PartyLeader" /></td>
  <td><span data-ttu-id="028e6-1816">ECA7</span><span class="sxs-lookup"><span data-stu-id="028e6-1816">ECA7</span></span></td>
  <td><span data-ttu-id="028e6-1817">PartyLeader</span><span class="sxs-lookup"><span data-stu-id="028e6-1817">PartyLeader</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECAA.png" width="32" height="32" alt="AppIconDefault" /></td>
  <td><span data-ttu-id="028e6-1818">ECAA</span><span class="sxs-lookup"><span data-stu-id="028e6-1818">ECAA</span></span></td>
  <td><span data-ttu-id="028e6-1819">AppIconDefault</span><span class="sxs-lookup"><span data-stu-id="028e6-1819">AppIconDefault</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECAD.png" width="32" height="32" alt="Calories" /></td>
  <td><span data-ttu-id="028e6-1820">ECAD</span><span class="sxs-lookup"><span data-stu-id="028e6-1820">ECAD</span></span></td>
  <td><span data-ttu-id="028e6-1821">カロリー</span><span class="sxs-lookup"><span data-stu-id="028e6-1821">Calories</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECB9.png" width="32" height="32" alt="BandBattery0" /></td>
  <td><span data-ttu-id="028e6-1822">ECB9</span><span class="sxs-lookup"><span data-stu-id="028e6-1822">ECB9</span></span></td>
  <td><span data-ttu-id="028e6-1823">BandBattery0</span><span class="sxs-lookup"><span data-stu-id="028e6-1823">BandBattery0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBA.png" width="32" height="32" alt="BandBattery1" /></td>
  <td><span data-ttu-id="028e6-1824">ECBA</span><span class="sxs-lookup"><span data-stu-id="028e6-1824">ECBA</span></span></td>
  <td><span data-ttu-id="028e6-1825">BandBattery1</span><span class="sxs-lookup"><span data-stu-id="028e6-1825">BandBattery1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBB.png" width="32" height="32" alt="BandBattery2" /></td>
  <td><span data-ttu-id="028e6-1826">ECBB</span><span class="sxs-lookup"><span data-stu-id="028e6-1826">ECBB</span></span></td>
  <td><span data-ttu-id="028e6-1827">BandBattery2</span><span class="sxs-lookup"><span data-stu-id="028e6-1827">BandBattery2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBC.png" width="32" height="32" alt="BandBattery3" /></td>
  <td><span data-ttu-id="028e6-1828">ECBC</span><span class="sxs-lookup"><span data-stu-id="028e6-1828">ECBC</span></span></td>
  <td><span data-ttu-id="028e6-1829">BandBattery3</span><span class="sxs-lookup"><span data-stu-id="028e6-1829">BandBattery3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBD.png" width="32" height="32" alt="BandBattery4" /></td>
  <td><span data-ttu-id="028e6-1830">ECBD</span><span class="sxs-lookup"><span data-stu-id="028e6-1830">ECBD</span></span></td>
  <td><span data-ttu-id="028e6-1831">BandBattery4</span><span class="sxs-lookup"><span data-stu-id="028e6-1831">BandBattery4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBE.png" width="32" height="32" alt="BandBattery5" /></td>
  <td><span data-ttu-id="028e6-1832">ECBE</span><span class="sxs-lookup"><span data-stu-id="028e6-1832">ECBE</span></span></td>
  <td><span data-ttu-id="028e6-1833">BandBattery5</span><span class="sxs-lookup"><span data-stu-id="028e6-1833">BandBattery5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBF.png" width="32" height="32" alt="BandBattery6" /></td>
  <td><span data-ttu-id="028e6-1834">ECBF</span><span class="sxs-lookup"><span data-stu-id="028e6-1834">ECBF</span></span></td>
  <td><span data-ttu-id="028e6-1835">BandBattery6</span><span class="sxs-lookup"><span data-stu-id="028e6-1835">BandBattery6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC4.png" width="32" height="32" alt="AddSurfaceHub" /></td>
  <td><span data-ttu-id="028e6-1836">ECC4</span><span class="sxs-lookup"><span data-stu-id="028e6-1836">ECC4</span></span></td>
  <td><span data-ttu-id="028e6-1837">AddSurfaceHub</span><span class="sxs-lookup"><span data-stu-id="028e6-1837">AddSurfaceHub</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC5.png" width="32" height="32" alt="DevUpdate" /></td>
  <td><span data-ttu-id="028e6-1838">ECC5</span><span class="sxs-lookup"><span data-stu-id="028e6-1838">ECC5</span></span></td>
  <td><span data-ttu-id="028e6-1839">DevUpdate</span><span class="sxs-lookup"><span data-stu-id="028e6-1839">DevUpdate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC6.png" width="32" height="32" alt="Unit" /></td>
  <td><span data-ttu-id="028e6-1840">ECC6</span><span class="sxs-lookup"><span data-stu-id="028e6-1840">ECC6</span></span></td>
  <td><span data-ttu-id="028e6-1841">Unit</span><span class="sxs-lookup"><span data-stu-id="028e6-1841">Unit</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC8.png" width="32" height="32" alt="AddTo" /></td>
  <td><span data-ttu-id="028e6-1842">ECC8</span><span class="sxs-lookup"><span data-stu-id="028e6-1842">ECC8</span></span></td>
  <td><span data-ttu-id="028e6-1843">AddTo</span><span class="sxs-lookup"><span data-stu-id="028e6-1843">AddTo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC9.png" width="32" height="32" alt="RemoveFrom" /></td>
  <td><span data-ttu-id="028e6-1844">ECC9</span><span class="sxs-lookup"><span data-stu-id="028e6-1844">ECC9</span></span></td>
  <td><span data-ttu-id="028e6-1845">RemoveFrom</span><span class="sxs-lookup"><span data-stu-id="028e6-1845">RemoveFrom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECCA.png" width="32" height="32" alt="RadioBtnOff" /></td>
  <td><span data-ttu-id="028e6-1846">ECCA</span><span class="sxs-lookup"><span data-stu-id="028e6-1846">ECCA</span></span></td>
  <td><span data-ttu-id="028e6-1847">RadioBtnOff</span><span class="sxs-lookup"><span data-stu-id="028e6-1847">RadioBtnOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECCB.png" width="32" height="32" alt="RadioBtnOn" /></td>
  <td><span data-ttu-id="028e6-1848">ECCB</span><span class="sxs-lookup"><span data-stu-id="028e6-1848">ECCB</span></span></td>
  <td><span data-ttu-id="028e6-1849">RadioBtnOn</span><span class="sxs-lookup"><span data-stu-id="028e6-1849">RadioBtnOn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECCC.png" width="32" height="32" alt="RadioBullet2" /></td>
  <td><span data-ttu-id="028e6-1850">ECCC</span><span class="sxs-lookup"><span data-stu-id="028e6-1850">ECCC</span></span></td>
  <td><span data-ttu-id="028e6-1851">RadioBullet2</span><span class="sxs-lookup"><span data-stu-id="028e6-1851">RadioBullet2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECCD.png" width="32" height="32" alt="ExploreContent" /></td>
  <td><span data-ttu-id="028e6-1852">ECCD</span><span class="sxs-lookup"><span data-stu-id="028e6-1852">ECCD</span></span></td>
  <td><span data-ttu-id="028e6-1853">ExploreContent</span><span class="sxs-lookup"><span data-stu-id="028e6-1853">ExploreContent</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECE7.png" width="32" height="32" alt="ScrollMode" /></td>
  <td><span data-ttu-id="028e6-1854">ECE7</span><span class="sxs-lookup"><span data-stu-id="028e6-1854">ECE7</span></span></td>
  <td><span data-ttu-id="028e6-1855">ScrollMode</span><span class="sxs-lookup"><span data-stu-id="028e6-1855">ScrollMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECE8.png" width="32" height="32" alt="ZoomMode" /></td>
  <td><span data-ttu-id="028e6-1856">ECE8</span><span class="sxs-lookup"><span data-stu-id="028e6-1856">ECE8</span></span></td>
  <td><span data-ttu-id="028e6-1857">ZoomMode</span><span class="sxs-lookup"><span data-stu-id="028e6-1857">ZoomMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECE9.png" width="32" height="32" alt="PanMode" /></td>
  <td><span data-ttu-id="028e6-1858">ECE9</span><span class="sxs-lookup"><span data-stu-id="028e6-1858">ECE9</span></span></td>
  <td><span data-ttu-id="028e6-1859">PanMode</span><span class="sxs-lookup"><span data-stu-id="028e6-1859">PanMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECF0.png" width="32" height="32" alt="WiredUSB  " /></td>
  <td><span data-ttu-id="028e6-1860">ECF0</span><span class="sxs-lookup"><span data-stu-id="028e6-1860">ECF0</span></span></td>
  <td><span data-ttu-id="028e6-1861">WiredUSB</span><span class="sxs-lookup"><span data-stu-id="028e6-1861">WiredUSB</span></span>  </td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECF1.png" width="32" height="32" alt="WirelessUSB" /></td>
  <td><span data-ttu-id="028e6-1862">ECF1</span><span class="sxs-lookup"><span data-stu-id="028e6-1862">ECF1</span></span></td>
  <td><span data-ttu-id="028e6-1863">WirelessUSB</span><span class="sxs-lookup"><span data-stu-id="028e6-1863">WirelessUSB</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECF3.png" width="32" height="32" alt="USBSafeConnect" /></td>
  <td><span data-ttu-id="028e6-1864">ECF3</span><span class="sxs-lookup"><span data-stu-id="028e6-1864">ECF3</span></span></td>
  <td><span data-ttu-id="028e6-1865">USBSafeConnect</span><span class="sxs-lookup"><span data-stu-id="028e6-1865">USBSafeConnect</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED0C.png" width="32" height="32" alt="ActionCenterNotificationMirrored" /></td>
  <td><span data-ttu-id="028e6-1866">ED0C</span><span class="sxs-lookup"><span data-stu-id="028e6-1866">ED0C</span></span></td>
  <td><span data-ttu-id="028e6-1867">ActionCenterNotificationMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1867">ActionCenterNotificationMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED0D.png" width="32" height="32" alt="ActionCenterMirrored" /></td>
  <td><span data-ttu-id="028e6-1868">ED0D</span><span class="sxs-lookup"><span data-stu-id="028e6-1868">ED0D</span></span></td>
  <td><span data-ttu-id="028e6-1869">ActionCenterMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1869">ActionCenterMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED10.png" width="32" height="32" alt="ResetDevice" /></td>
  <td><span data-ttu-id="028e6-1870">ED10</span><span class="sxs-lookup"><span data-stu-id="028e6-1870">ED10</span></span></td>
  <td><span data-ttu-id="028e6-1871">ResetDevice</span><span class="sxs-lookup"><span data-stu-id="028e6-1871">ResetDevice</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED15.png" width="32" height="32" alt="Feedback" /></td>
  <td><span data-ttu-id="028e6-1872">ED15</span><span class="sxs-lookup"><span data-stu-id="028e6-1872">ED15</span></span></td>
  <td><span data-ttu-id="028e6-1873">Feedback</span><span class="sxs-lookup"><span data-stu-id="028e6-1873">Feedback</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED1E.png" width="32" height="32" alt="Subtitles" /></td>
  <td><span data-ttu-id="028e6-1874">ED1E</span><span class="sxs-lookup"><span data-stu-id="028e6-1874">ED1E</span></span></td>
  <td><span data-ttu-id="028e6-1875">Subtitles</span><span class="sxs-lookup"><span data-stu-id="028e6-1875">Subtitles</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED1F.png" width="32" height="32" alt="SubtitlesAudio" /></td>
  <td><span data-ttu-id="028e6-1876">ED1F</span><span class="sxs-lookup"><span data-stu-id="028e6-1876">ED1F</span></span></td>
  <td><span data-ttu-id="028e6-1877">SubtitlesAudio</span><span class="sxs-lookup"><span data-stu-id="028e6-1877">SubtitlesAudio</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED25.png" width="32" height="32" alt="OpenFolderHorizontal" /></td>
  <td><span data-ttu-id="028e6-1878">ED25</span><span class="sxs-lookup"><span data-stu-id="028e6-1878">ED25</span></span></td>
  <td><span data-ttu-id="028e6-1879">OpenFolderHorizontal</span><span class="sxs-lookup"><span data-stu-id="028e6-1879">OpenFolderHorizontal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED28.png" width="32" height="32" alt="CalendarMirrored" /></td>
  <td><span data-ttu-id="028e6-1880">ED28</span><span class="sxs-lookup"><span data-stu-id="028e6-1880">ED28</span></span></td>
  <td><span data-ttu-id="028e6-1881">CalendarMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1881">CalendarMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2A.png" width="32" height="32" alt="MobeSIM" /></td>
  <td><span data-ttu-id="028e6-1882">ED2A</span><span class="sxs-lookup"><span data-stu-id="028e6-1882">ED2A</span></span></td>
  <td><span data-ttu-id="028e6-1883">MobeSIM</span><span class="sxs-lookup"><span data-stu-id="028e6-1883">MobeSIM</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2B.png" width="32" height="32" alt="MobeSIMNoProfile" /></td>
  <td><span data-ttu-id="028e6-1884">ED2B</span><span class="sxs-lookup"><span data-stu-id="028e6-1884">ED2B</span></span></td>
  <td><span data-ttu-id="028e6-1885">MobeSIMNoProfile</span><span class="sxs-lookup"><span data-stu-id="028e6-1885">MobeSIMNoProfile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2C.png" width="32" height="32" alt="MobeSIMLocked" /></td>
  <td><span data-ttu-id="028e6-1886">ED2C</span><span class="sxs-lookup"><span data-stu-id="028e6-1886">ED2C</span></span></td>
  <td><span data-ttu-id="028e6-1887">MobeSIMLocked</span><span class="sxs-lookup"><span data-stu-id="028e6-1887">MobeSIMLocked</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2D.png" width="32" height="32" alt="MobeSIMBusy" /></td>
  <td><span data-ttu-id="028e6-1888">ED2D</span><span class="sxs-lookup"><span data-stu-id="028e6-1888">ED2D</span></span></td>
  <td><span data-ttu-id="028e6-1889">MobeSIMBusy</span><span class="sxs-lookup"><span data-stu-id="028e6-1889">MobeSIMBusy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2E.png" width="32" height="32" alt="SignalError" /></td>
  <td><span data-ttu-id="028e6-1890">ED2E</span><span class="sxs-lookup"><span data-stu-id="028e6-1890">ED2E</span></span></td>
  <td><span data-ttu-id="028e6-1891">SignalError</span><span class="sxs-lookup"><span data-stu-id="028e6-1891">SignalError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2F.png" width="32" height="32" alt="StreamingEnterprise" /></td>
  <td><span data-ttu-id="028e6-1892">ED2F</span><span class="sxs-lookup"><span data-stu-id="028e6-1892">ED2F</span></span></td>
  <td><span data-ttu-id="028e6-1893">StreamingEnterprise</span><span class="sxs-lookup"><span data-stu-id="028e6-1893">StreamingEnterprise</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED30.png" width="32" height="32" alt="Headphone0" /></td>
  <td><span data-ttu-id="028e6-1894">ED30</span><span class="sxs-lookup"><span data-stu-id="028e6-1894">ED30</span></span></td>
  <td><span data-ttu-id="028e6-1895">Headphone0</span><span class="sxs-lookup"><span data-stu-id="028e6-1895">Headphone0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED31.png" width="32" height="32" alt="Headphone1" /></td>
  <td><span data-ttu-id="028e6-1896">ED31</span><span class="sxs-lookup"><span data-stu-id="028e6-1896">ED31</span></span></td>
  <td><span data-ttu-id="028e6-1897">Headphone1</span><span class="sxs-lookup"><span data-stu-id="028e6-1897">Headphone1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED32.png" width="32" height="32" alt="Headphone2" /></td>
  <td><span data-ttu-id="028e6-1898">ED32</span><span class="sxs-lookup"><span data-stu-id="028e6-1898">ED32</span></span></td>
  <td><span data-ttu-id="028e6-1899">Headphone2</span><span class="sxs-lookup"><span data-stu-id="028e6-1899">Headphone2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED33.png" width="32" height="32" alt="Headphone3" /></td>
  <td><span data-ttu-id="028e6-1900">ED33</span><span class="sxs-lookup"><span data-stu-id="028e6-1900">ED33</span></span></td>
  <td><span data-ttu-id="028e6-1901">Headphone3</span><span class="sxs-lookup"><span data-stu-id="028e6-1901">Headphone3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED35.png" width="32" height="32" alt="Apps" /></td>
  <td><span data-ttu-id="028e6-1902">ED35</span><span class="sxs-lookup"><span data-stu-id="028e6-1902">ED35</span></span></td>
  <td><span data-ttu-id="028e6-1903">アプリ</span><span class="sxs-lookup"><span data-stu-id="028e6-1903">Apps</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED39.png" width="32" height="32" alt="KeyboardBrightness" /></td>
  <td><span data-ttu-id="028e6-1904">ED39</span><span class="sxs-lookup"><span data-stu-id="028e6-1904">ED39</span></span></td>
  <td><span data-ttu-id="028e6-1905">KeyboardBrightness</span><span class="sxs-lookup"><span data-stu-id="028e6-1905">KeyboardBrightness</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED3A.png" width="32" height="32" alt="KeyboardLowerBrightness" /></td>
  <td><span data-ttu-id="028e6-1906">ED3A</span><span class="sxs-lookup"><span data-stu-id="028e6-1906">ED3A</span></span></td>
  <td><span data-ttu-id="028e6-1907">KeyboardLowerBrightness</span><span class="sxs-lookup"><span data-stu-id="028e6-1907">KeyboardLowerBrightness</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED3C.png" width="32" height="32" alt="SkipBack10" /></td>
  <td><span data-ttu-id="028e6-1908">ED3C</span><span class="sxs-lookup"><span data-stu-id="028e6-1908">ED3C</span></span></td>
  <td><span data-ttu-id="028e6-1909">SkipBack10</span><span class="sxs-lookup"><span data-stu-id="028e6-1909">SkipBack10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED3D.png" width="32" height="32" alt="SkipForward30 " /></td>
  <td><span data-ttu-id="028e6-1910">ED3D</span><span class="sxs-lookup"><span data-stu-id="028e6-1910">ED3D</span></span></td>
  <td><span data-ttu-id="028e6-1911">SkipForward30</span><span class="sxs-lookup"><span data-stu-id="028e6-1911">SkipForward30</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED41.png" width="32" height="32" alt="TreeFolderFolder" /></td>
  <td><span data-ttu-id="028e6-1912">ED41</span><span class="sxs-lookup"><span data-stu-id="028e6-1912">ED41</span></span></td>
  <td><span data-ttu-id="028e6-1913">TreeFolderFolder</span><span class="sxs-lookup"><span data-stu-id="028e6-1913">TreeFolderFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED42.png" width="32" height="32" alt="TreeFolderFolderFill" /></td>
  <td><span data-ttu-id="028e6-1914">ED42</span><span class="sxs-lookup"><span data-stu-id="028e6-1914">ED42</span></span></td>
  <td><span data-ttu-id="028e6-1915">TreeFolderFolderFill</span><span class="sxs-lookup"><span data-stu-id="028e6-1915">TreeFolderFolderFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED43.png" width="32" height="32" alt="TreeFolderFolderOpen" /></td>
  <td><span data-ttu-id="028e6-1916">ED43</span><span class="sxs-lookup"><span data-stu-id="028e6-1916">ED43</span></span></td>
  <td><span data-ttu-id="028e6-1917">TreeFolderFolderOpen</span><span class="sxs-lookup"><span data-stu-id="028e6-1917">TreeFolderFolderOpen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED44.png" width="32" height="32" alt="TreeFolderFolderOpenFill" /></td>
  <td><span data-ttu-id="028e6-1918">ED44</span><span class="sxs-lookup"><span data-stu-id="028e6-1918">ED44</span></span></td>
  <td><span data-ttu-id="028e6-1919">TreeFolderFolderOpenFill</span><span class="sxs-lookup"><span data-stu-id="028e6-1919">TreeFolderFolderOpenFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED47.png" width="32" height="32" alt="MultimediaDMP" /></td>
  <td><span data-ttu-id="028e6-1920">ED47</span><span class="sxs-lookup"><span data-stu-id="028e6-1920">ED47</span></span></td>
  <td><span data-ttu-id="028e6-1921">MultimediaDMP</span><span class="sxs-lookup"><span data-stu-id="028e6-1921">MultimediaDMP</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED4C.png" width="32" height="32" alt="KeyboardOneHanded" /></td>
  <td><span data-ttu-id="028e6-1922">ED4C</span><span class="sxs-lookup"><span data-stu-id="028e6-1922">ED4C</span></span></td>
  <td><span data-ttu-id="028e6-1923">KeyboardOneHanded</span><span class="sxs-lookup"><span data-stu-id="028e6-1923">KeyboardOneHanded</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED4D.png" width="32" height="32" alt="Narrator" /></td>
  <td><span data-ttu-id="028e6-1924">ED4D</span><span class="sxs-lookup"><span data-stu-id="028e6-1924">ED4D</span></span></td>
  <td><span data-ttu-id="028e6-1925">Narrator</span><span class="sxs-lookup"><span data-stu-id="028e6-1925">Narrator</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED53.png" width="32" height="32" alt="EmojiTabPeople" /></td>
  <td><span data-ttu-id="028e6-1926">ED53</span><span class="sxs-lookup"><span data-stu-id="028e6-1926">ED53</span></span></td>
  <td><span data-ttu-id="028e6-1927">EmojiTabPeople</span><span class="sxs-lookup"><span data-stu-id="028e6-1927">EmojiTabPeople</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED54.png" width="32" height="32" alt="EmojiTabSmilesAnimals" /></td>
  <td><span data-ttu-id="028e6-1928">ED54</span><span class="sxs-lookup"><span data-stu-id="028e6-1928">ED54</span></span></td>
  <td><span data-ttu-id="028e6-1929">EmojiTabSmilesAnimals</span><span class="sxs-lookup"><span data-stu-id="028e6-1929">EmojiTabSmilesAnimals</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED55.png" width="32" height="32" alt="EmojiTabCelebrationObjects" /></td>
  <td><span data-ttu-id="028e6-1930">ED55</span><span class="sxs-lookup"><span data-stu-id="028e6-1930">ED55</span></span></td>
  <td><span data-ttu-id="028e6-1931">EmojiTabCelebrationObjects</span><span class="sxs-lookup"><span data-stu-id="028e6-1931">EmojiTabCelebrationObjects</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED56.png" width="32" height="32" alt="EmojiTabFoodPlants" /></td>
  <td><span data-ttu-id="028e6-1932">ED56</span><span class="sxs-lookup"><span data-stu-id="028e6-1932">ED56</span></span></td>
  <td><span data-ttu-id="028e6-1933">EmojiTabFoodPlants</span><span class="sxs-lookup"><span data-stu-id="028e6-1933">EmojiTabFoodPlants</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED57.png" width="32" height="32" alt="EmojiTabTransitPlaces" /></td>
  <td><span data-ttu-id="028e6-1934">ED57</span><span class="sxs-lookup"><span data-stu-id="028e6-1934">ED57</span></span></td>
  <td><span data-ttu-id="028e6-1935">EmojiTabTransitPlaces</span><span class="sxs-lookup"><span data-stu-id="028e6-1935">EmojiTabTransitPlaces</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED58.png" width="32" height="32" alt="EmojiTabSymbols" /></td>
  <td><span data-ttu-id="028e6-1936">ED58</span><span class="sxs-lookup"><span data-stu-id="028e6-1936">ED58</span></span></td>
  <td><span data-ttu-id="028e6-1937">EmojiTabSymbols</span><span class="sxs-lookup"><span data-stu-id="028e6-1937">EmojiTabSymbols</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED59.png" width="32" height="32" alt="EmojiTabTextSmiles" /></td>
  <td><span data-ttu-id="028e6-1938">ED59</span><span class="sxs-lookup"><span data-stu-id="028e6-1938">ED59</span></span></td>
  <td><span data-ttu-id="028e6-1939">EmojiTabTextSmiles</span><span class="sxs-lookup"><span data-stu-id="028e6-1939">EmojiTabTextSmiles</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5A.png" width="32" height="32" alt="EmojiTabFavorites" /></td>
  <td><span data-ttu-id="028e6-1940">ED5A</span><span class="sxs-lookup"><span data-stu-id="028e6-1940">ED5A</span></span></td>
  <td><span data-ttu-id="028e6-1941">EmojiTabFavorites</span><span class="sxs-lookup"><span data-stu-id="028e6-1941">EmojiTabFavorites</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5B.png" width="32" height="32" alt="EmojiSwatch" /></td>
  <td><span data-ttu-id="028e6-1942">ED5B</span><span class="sxs-lookup"><span data-stu-id="028e6-1942">ED5B</span></span></td>
  <td><span data-ttu-id="028e6-1943">EmojiSwatch</span><span class="sxs-lookup"><span data-stu-id="028e6-1943">EmojiSwatch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5C.png" width="32" height="32" alt="ConnectApp" /></td>
  <td><span data-ttu-id="028e6-1944">ED5C</span><span class="sxs-lookup"><span data-stu-id="028e6-1944">ED5C</span></span></td>
  <td><span data-ttu-id="028e6-1945">ConnectApp</span><span class="sxs-lookup"><span data-stu-id="028e6-1945">ConnectApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5D.png" width="32" height="32" alt="CompanionDeviceFramework" /></td>
  <td><span data-ttu-id="028e6-1946">ED5D</span><span class="sxs-lookup"><span data-stu-id="028e6-1946">ED5D</span></span></td>
  <td><span data-ttu-id="028e6-1947">CompanionDeviceFramework</span><span class="sxs-lookup"><span data-stu-id="028e6-1947">CompanionDeviceFramework</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5E.png" width="32" height="32" alt="Ruler" /></td>
  <td><span data-ttu-id="028e6-1948">ED5E</span><span class="sxs-lookup"><span data-stu-id="028e6-1948">ED5E</span></span></td>
  <td><span data-ttu-id="028e6-1949">Ruler</span><span class="sxs-lookup"><span data-stu-id="028e6-1949">Ruler</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5F.png" width="32" height="32" alt="FingerInking" /></td>
  <td><span data-ttu-id="028e6-1950">ED5F</span><span class="sxs-lookup"><span data-stu-id="028e6-1950">ED5F</span></span></td>
  <td><span data-ttu-id="028e6-1951">FingerInking</span><span class="sxs-lookup"><span data-stu-id="028e6-1951">FingerInking</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED60.png" width="32" height="32" alt="StrokeErase" /></td>
  <td><span data-ttu-id="028e6-1952">ED60</span><span class="sxs-lookup"><span data-stu-id="028e6-1952">ED60</span></span></td>
  <td><span data-ttu-id="028e6-1953">StrokeErase</span><span class="sxs-lookup"><span data-stu-id="028e6-1953">StrokeErase</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED61.png" width="32" height="32" alt="PointErase" /></td>
  <td><span data-ttu-id="028e6-1954">ED61</span><span class="sxs-lookup"><span data-stu-id="028e6-1954">ED61</span></span></td>
  <td><span data-ttu-id="028e6-1955">PointErase</span><span class="sxs-lookup"><span data-stu-id="028e6-1955">PointErase</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED62.png" width="32" height="32" alt="ClearAllInk" /></td>
  <td><span data-ttu-id="028e6-1956">ED62</span><span class="sxs-lookup"><span data-stu-id="028e6-1956">ED62</span></span></td>
  <td><span data-ttu-id="028e6-1957">ClearAllInk</span><span class="sxs-lookup"><span data-stu-id="028e6-1957">ClearAllInk</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED63.png" width="32" height="32" alt="Pencil" /></td>
  <td><span data-ttu-id="028e6-1958">ED63</span><span class="sxs-lookup"><span data-stu-id="028e6-1958">ED63</span></span></td>
  <td><span data-ttu-id="028e6-1959">Pencil</span><span class="sxs-lookup"><span data-stu-id="028e6-1959">Pencil</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED64.png" width="32" height="32" alt="Marker" /></td>
  <td><span data-ttu-id="028e6-1960">ED64</span><span class="sxs-lookup"><span data-stu-id="028e6-1960">ED64</span></span></td>
  <td><span data-ttu-id="028e6-1961">Marker</span><span class="sxs-lookup"><span data-stu-id="028e6-1961">Marker</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED65.png" width="32" height="32" alt="InkingCaret" /></td>
  <td><span data-ttu-id="028e6-1962">ED65</span><span class="sxs-lookup"><span data-stu-id="028e6-1962">ED65</span></span></td>
  <td><span data-ttu-id="028e6-1963">InkingCaret</span><span class="sxs-lookup"><span data-stu-id="028e6-1963">InkingCaret</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED66.png" width="32" height="32" alt="InkingColorOutline" /></td>
  <td><span data-ttu-id="028e6-1964">ED66</span><span class="sxs-lookup"><span data-stu-id="028e6-1964">ED66</span></span></td>
  <td><span data-ttu-id="028e6-1965">InkingColorOutline</span><span class="sxs-lookup"><span data-stu-id="028e6-1965">InkingColorOutline</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED67.png" width="32" height="32" alt="InkingColorFill" /></td>
  <td><span data-ttu-id="028e6-1966">ED67</span><span class="sxs-lookup"><span data-stu-id="028e6-1966">ED67</span></span></td>
  <td><span data-ttu-id="028e6-1967">InkingColorFill</span><span class="sxs-lookup"><span data-stu-id="028e6-1967">InkingColorFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA2.png" width="32" height="32" alt="HardDrive" /></td>
  <td><span data-ttu-id="028e6-1968">EDA2</span><span class="sxs-lookup"><span data-stu-id="028e6-1968">EDA2</span></span></td>
  <td><span data-ttu-id="028e6-1969">HardDrive</span><span class="sxs-lookup"><span data-stu-id="028e6-1969">HardDrive</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA3.png" width="32" height="32" alt="NetworkAdapter" /></td>
  <td><span data-ttu-id="028e6-1970">EDA3</span><span class="sxs-lookup"><span data-stu-id="028e6-1970">EDA3</span></span></td>
  <td><span data-ttu-id="028e6-1971">NetworkAdapter</span><span class="sxs-lookup"><span data-stu-id="028e6-1971">NetworkAdapter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA4.png" width="32" height="32" alt="Touchscreen" /></td>
  <td><span data-ttu-id="028e6-1972">EDA4</span><span class="sxs-lookup"><span data-stu-id="028e6-1972">EDA4</span></span></td>
  <td><span data-ttu-id="028e6-1973">Touchscreen</span><span class="sxs-lookup"><span data-stu-id="028e6-1973">Touchscreen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA5.png" width="32" height="32" alt="NetworkPrinter" /></td>
  <td><span data-ttu-id="028e6-1974">EDA5</span><span class="sxs-lookup"><span data-stu-id="028e6-1974">EDA5</span></span></td>
  <td><span data-ttu-id="028e6-1975">NetworkPrinter</span><span class="sxs-lookup"><span data-stu-id="028e6-1975">NetworkPrinter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA6.png" width="32" height="32" alt="CloudPrinter" /></td>
  <td><span data-ttu-id="028e6-1976">EDA6</span><span class="sxs-lookup"><span data-stu-id="028e6-1976">EDA6</span></span></td>
  <td><span data-ttu-id="028e6-1977">CloudPrinter</span><span class="sxs-lookup"><span data-stu-id="028e6-1977">CloudPrinter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA7.png" width="32" height="32" alt="KeyboardShortcut" /></td>
  <td><span data-ttu-id="028e6-1978">EDA7</span><span class="sxs-lookup"><span data-stu-id="028e6-1978">EDA7</span></span></td>
  <td><span data-ttu-id="028e6-1979">KeyboardShortcut</span><span class="sxs-lookup"><span data-stu-id="028e6-1979">KeyboardShortcut</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA8.png" width="32" height="32" alt="BrushSize" /></td>
  <td><span data-ttu-id="028e6-1980">EDA8</span><span class="sxs-lookup"><span data-stu-id="028e6-1980">EDA8</span></span></td>
  <td><span data-ttu-id="028e6-1981">BrushSize</span><span class="sxs-lookup"><span data-stu-id="028e6-1981">BrushSize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA9.png" width="32" height="32" alt="NarratorForward" /></td>
  <td><span data-ttu-id="028e6-1982">EDA9</span><span class="sxs-lookup"><span data-stu-id="028e6-1982">EDA9</span></span></td>
  <td><span data-ttu-id="028e6-1983">NarratorForward</span><span class="sxs-lookup"><span data-stu-id="028e6-1983">NarratorForward</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAA.png" width="32" height="32" alt="NarratorForwardMirrored" /></td>
  <td><span data-ttu-id="028e6-1984">EDAA</span><span class="sxs-lookup"><span data-stu-id="028e6-1984">EDAA</span></span></td>
  <td><span data-ttu-id="028e6-1985">NarratorForwardMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-1985">NarratorForwardMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAB.png" width="32" height="32" alt="SyncBadge12" /></td>
  <td><span data-ttu-id="028e6-1986">EDAB</span><span class="sxs-lookup"><span data-stu-id="028e6-1986">EDAB</span></span></td>
  <td><span data-ttu-id="028e6-1987">SyncBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-1987">SyncBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAC.png" width="32" height="32" alt="RingerBadge12" /></td>
  <td><span data-ttu-id="028e6-1988">EDAC</span><span class="sxs-lookup"><span data-stu-id="028e6-1988">EDAC</span></span></td>
  <td><span data-ttu-id="028e6-1989">RingerBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-1989">RingerBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAD.png" width="32" height="32" alt="AsteriskBadge12" /></td>
  <td><span data-ttu-id="028e6-1990">EDAD</span><span class="sxs-lookup"><span data-stu-id="028e6-1990">EDAD</span></span></td>
  <td><span data-ttu-id="028e6-1991">AsteriskBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-1991">AsteriskBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAE.png" width="32" height="32" alt="ErrorBadge12" /></td>
  <td><span data-ttu-id="028e6-1992">EDAE</span><span class="sxs-lookup"><span data-stu-id="028e6-1992">EDAE</span></span></td>
  <td><span data-ttu-id="028e6-1993">ErrorBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-1993">ErrorBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAF.png" width="32" height="32" alt="CircleRingBadge12" /></td>
  <td><span data-ttu-id="028e6-1994">EDAF</span><span class="sxs-lookup"><span data-stu-id="028e6-1994">EDAF</span></span></td>
  <td><span data-ttu-id="028e6-1995">CircleRingBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-1995">CircleRingBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB0.png" width="32" height="32" alt="CircleFillBadge12" /></td>
  <td><span data-ttu-id="028e6-1996">EDB0</span><span class="sxs-lookup"><span data-stu-id="028e6-1996">EDB0</span></span></td>
  <td><span data-ttu-id="028e6-1997">CircleFillBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-1997">CircleFillBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB1.png" width="32" height="32" alt="ImportantBadge12" /></td>
  <td><span data-ttu-id="028e6-1998">EDB1</span><span class="sxs-lookup"><span data-stu-id="028e6-1998">EDB1</span></span></td>
  <td><span data-ttu-id="028e6-1999">ImportantBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-1999">ImportantBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB3.png" width="32" height="32" alt="MailBadge12" /></td>
  <td><span data-ttu-id="028e6-2000">EDB3</span><span class="sxs-lookup"><span data-stu-id="028e6-2000">EDB3</span></span></td>
  <td><span data-ttu-id="028e6-2001">MailBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-2001">MailBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB4.png" width="32" height="32" alt="PauseBadge12" /></td>
  <td><span data-ttu-id="028e6-2002">EDB4</span><span class="sxs-lookup"><span data-stu-id="028e6-2002">EDB4</span></span></td>
  <td><span data-ttu-id="028e6-2003">PauseBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-2003">PauseBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB5.png" width="32" height="32" alt="PlayBadge12" /></td>
  <td><span data-ttu-id="028e6-2004">EDB5</span><span class="sxs-lookup"><span data-stu-id="028e6-2004">EDB5</span></span></td>
  <td><span data-ttu-id="028e6-2005">PlayBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-2005">PlayBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDC6.png" width="32" height="32" alt="PenWorkspace" /></td>
  <td><span data-ttu-id="028e6-2006">EDC6</span><span class="sxs-lookup"><span data-stu-id="028e6-2006">EDC6</span></span></td>
  <td><span data-ttu-id="028e6-2007">PenWorkspace</span><span class="sxs-lookup"><span data-stu-id="028e6-2007">PenWorkspace</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDD6.png" width="32" height="32" alt="CaretRight8" /></td>
  <td><span data-ttu-id="028e6-2008">EDD6</span><span class="sxs-lookup"><span data-stu-id="028e6-2008">EDD6</span></span></td>
  <td><span data-ttu-id="028e6-2009">CaretRight8</span><span class="sxs-lookup"><span data-stu-id="028e6-2009">CaretRight8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDD9.png" width="32" height="32" alt="CaretLeftSolid8" /></td>
  <td><span data-ttu-id="028e6-2010">EDD9</span><span class="sxs-lookup"><span data-stu-id="028e6-2010">EDD9</span></span></td>
  <td><span data-ttu-id="028e6-2011">CaretLeftSolid8</span><span class="sxs-lookup"><span data-stu-id="028e6-2011">CaretLeftSolid8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDDA.png" width="32" height="32" alt="CaretRightSolid8" /></td>
  <td><span data-ttu-id="028e6-2012">EDDA</span><span class="sxs-lookup"><span data-stu-id="028e6-2012">EDDA</span></span></td>
  <td><span data-ttu-id="028e6-2013">CaretRightSolid8</span><span class="sxs-lookup"><span data-stu-id="028e6-2013">CaretRightSolid8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDDB.png" width="32" height="32" alt="CaretUpSolid8" /></td>
  <td><span data-ttu-id="028e6-2014">EDDB</span><span class="sxs-lookup"><span data-stu-id="028e6-2014">EDDB</span></span></td>
  <td><span data-ttu-id="028e6-2015">CaretUpSolid8</span><span class="sxs-lookup"><span data-stu-id="028e6-2015">CaretUpSolid8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDDC.png" width="32" height="32" alt="CaretDownSolid8" /></td>
  <td><span data-ttu-id="028e6-2016">EDDC</span><span class="sxs-lookup"><span data-stu-id="028e6-2016">EDDC</span></span></td>
  <td><span data-ttu-id="028e6-2017">CaretDownSolid8</span><span class="sxs-lookup"><span data-stu-id="028e6-2017">CaretDownSolid8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE1.png" width="32" height="32" alt="Export" /></td>
  <td><span data-ttu-id="028e6-2018">EDE1</span><span class="sxs-lookup"><span data-stu-id="028e6-2018">EDE1</span></span></td>
  <td><span data-ttu-id="028e6-2019">Export</span><span class="sxs-lookup"><span data-stu-id="028e6-2019">Export</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE2.png" width="32" height="32" alt="ExportMirrored" /></td>
  <td><span data-ttu-id="028e6-2020">EDE2</span><span class="sxs-lookup"><span data-stu-id="028e6-2020">EDE2</span></span></td>
  <td><span data-ttu-id="028e6-2021">ExportMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2021">ExportMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE3.png" width="32" height="32" alt="ButtonMenu" /></td>
  <td><span data-ttu-id="028e6-2022">EDE3</span><span class="sxs-lookup"><span data-stu-id="028e6-2022">EDE3</span></span></td>
  <td><span data-ttu-id="028e6-2023">ボタン</span><span class="sxs-lookup"><span data-stu-id="028e6-2023">ButtonMenu</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE4.png" width="32" height="32" alt="CloudSeach" /></td>
  <td><span data-ttu-id="028e6-2024">EDE4</span><span class="sxs-lookup"><span data-stu-id="028e6-2024">EDE4</span></span></td>
  <td><span data-ttu-id="028e6-2025">CloudSeach</span><span class="sxs-lookup"><span data-stu-id="028e6-2025">CloudSeach</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE5.png" width="32" height="32" alt="PinyinIMELogo" /></td>
  <td><span data-ttu-id="028e6-2026">EDE5</span><span class="sxs-lookup"><span data-stu-id="028e6-2026">EDE5</span></span></td>
  <td><span data-ttu-id="028e6-2027">PinyinIMELogo</span><span class="sxs-lookup"><span data-stu-id="028e6-2027">PinyinIMELogo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDFB.png" width="32" height="32" alt="CalligraphyPen" /></td>
  <td><span data-ttu-id="028e6-2028">EDFB</span><span class="sxs-lookup"><span data-stu-id="028e6-2028">EDFB</span></span></td>
  <td><span data-ttu-id="028e6-2029">CalligraphyPen</span><span class="sxs-lookup"><span data-stu-id="028e6-2029">CalligraphyPen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE35.png" width="32" height="32" alt="ReplyMirrored" /></td>
  <td><span data-ttu-id="028e6-2030">EE35</span><span class="sxs-lookup"><span data-stu-id="028e6-2030">EE35</span></span></td>
  <td><span data-ttu-id="028e6-2031">ReplyMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2031">ReplyMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE3F.png" width="32" height="32" alt="LockscreenDesktop" /></td>
  <td><span data-ttu-id="028e6-2032">EE3F</span><span class="sxs-lookup"><span data-stu-id="028e6-2032">EE3F</span></span></td>
  <td><span data-ttu-id="028e6-2033">LockscreenDesktop</span><span class="sxs-lookup"><span data-stu-id="028e6-2033">LockscreenDesktop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE40.png" width="32" height="32" alt="TaskViewSettings" /></td>
  <td><span data-ttu-id="028e6-2034">EE40</span><span class="sxs-lookup"><span data-stu-id="028e6-2034">EE40</span></span></td>
  <td><span data-ttu-id="028e6-2035">TaskViewSettings</span><span class="sxs-lookup"><span data-stu-id="028e6-2035">TaskViewSettings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE4A.png" width="32" height="32" alt="Play36" /></td>
  <td><span data-ttu-id="028e6-2036">EE4A</span><span class="sxs-lookup"><span data-stu-id="028e6-2036">EE4A</span></span></td>
  <td><span data-ttu-id="028e6-2037">Play36</span><span class="sxs-lookup"><span data-stu-id="028e6-2037">Play36</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE56.png" width="32" height="32" alt="PenPalette" /></td>
  <td><span data-ttu-id="028e6-2038">EE56</span><span class="sxs-lookup"><span data-stu-id="028e6-2038">EE56</span></span></td>
  <td><span data-ttu-id="028e6-2039">PenPalette</span><span class="sxs-lookup"><span data-stu-id="028e6-2039">PenPalette</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE57.png" width="32" height="32" alt="GuestUser" /></td>
  <td><span data-ttu-id="028e6-2040">EE57</span><span class="sxs-lookup"><span data-stu-id="028e6-2040">EE57</span></span></td>
  <td><span data-ttu-id="028e6-2041">GuestUser</span><span class="sxs-lookup"><span data-stu-id="028e6-2041">GuestUser</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE63.png" width="32" height="32" alt="SettingsBattery" /></td>
  <td><span data-ttu-id="028e6-2042">EE63</span><span class="sxs-lookup"><span data-stu-id="028e6-2042">EE63</span></span></td>
  <td><span data-ttu-id="028e6-2043">SettingsBattery</span><span class="sxs-lookup"><span data-stu-id="028e6-2043">SettingsBattery</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE64.png" width="32" height="32" alt="TaskbarPhone" /></td>
  <td><span data-ttu-id="028e6-2044">EE64</span><span class="sxs-lookup"><span data-stu-id="028e6-2044">EE64</span></span></td>
  <td><span data-ttu-id="028e6-2045">TaskbarPhone</span><span class="sxs-lookup"><span data-stu-id="028e6-2045">TaskbarPhone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE65.png" width="32" height="32" alt="LockScreenGlance" /></td>
  <td><span data-ttu-id="028e6-2046">EE65</span><span class="sxs-lookup"><span data-stu-id="028e6-2046">EE65</span></span></td>
  <td><span data-ttu-id="028e6-2047">LockScreenGlance</span><span class="sxs-lookup"><span data-stu-id="028e6-2047">LockScreenGlance</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE71.png" width="32" height="32" alt="ImageExport " /></td>
  <td><span data-ttu-id="028e6-2048">EE71</span><span class="sxs-lookup"><span data-stu-id="028e6-2048">EE71</span></span></td>
  <td><span data-ttu-id="028e6-2049">ImageExport</span><span class="sxs-lookup"><span data-stu-id="028e6-2049">ImageExport</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE77.png" width="32" height="32" alt="WifiEthernet" /></td>
  <td><span data-ttu-id="028e6-2050">EE77</span><span class="sxs-lookup"><span data-stu-id="028e6-2050">EE77</span></span></td>
  <td><span data-ttu-id="028e6-2051">WifiEthernet</span><span class="sxs-lookup"><span data-stu-id="028e6-2051">WifiEthernet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE79.png" width="32" height="32" alt="ActionCenterQuiet" /></td>
  <td><span data-ttu-id="028e6-2052">EE79</span><span class="sxs-lookup"><span data-stu-id="028e6-2052">EE79</span></span></td>
  <td><span data-ttu-id="028e6-2053">ActionCenterQuiet</span><span class="sxs-lookup"><span data-stu-id="028e6-2053">ActionCenterQuiet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE7A.png" width="32" height="32" alt="ActionCenterQuietNotification" /></td>
  <td><span data-ttu-id="028e6-2054">EE7A</span><span class="sxs-lookup"><span data-stu-id="028e6-2054">EE7A</span></span></td>
  <td><span data-ttu-id="028e6-2055">ActionCenterQuietNotification</span><span class="sxs-lookup"><span data-stu-id="028e6-2055">ActionCenterQuietNotification</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE92.png" width="32" height="32" alt="TrackersMirrored" /></td>
  <td><span data-ttu-id="028e6-2056">EE92</span><span class="sxs-lookup"><span data-stu-id="028e6-2056">EE92</span></span></td>
  <td><span data-ttu-id="028e6-2057">TrackersMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2057">TrackersMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE93.png" width="32" height="32" alt="DateTimeMirrored" /></td>
  <td><span data-ttu-id="028e6-2058">EE93</span><span class="sxs-lookup"><span data-stu-id="028e6-2058">EE93</span></span></td>
  <td><span data-ttu-id="028e6-2059">DateTimeMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2059">DateTimeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE94.png" width="32" height="32" alt="Wheel" /></td>
  <td><span data-ttu-id="028e6-2060">EE94</span><span class="sxs-lookup"><span data-stu-id="028e6-2060">EE94</span></span></td>
  <td><span data-ttu-id="028e6-2061">Wheel</span><span class="sxs-lookup"><span data-stu-id="028e6-2061">Wheel</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EECA.png" width="32" height="32" alt="ButtonView2" /></td>
  <td><span data-ttu-id="028e6-2062">EECA</span><span class="sxs-lookup"><span data-stu-id="028e6-2062">EECA</span></span></td>
  <td><span data-ttu-id="028e6-2063">ButtonView2</span><span class="sxs-lookup"><span data-stu-id="028e6-2063">ButtonView2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF15.png" width="32" height="32" alt="PenWorkspaceMirrored" /></td>
  <td><span data-ttu-id="028e6-2064">EF15</span><span class="sxs-lookup"><span data-stu-id="028e6-2064">EF15</span></span></td>
  <td><span data-ttu-id="028e6-2065">PenWorkspaceMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2065">PenWorkspaceMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF16.png" width="32" height="32" alt="PenPaletteMirrored" /></td>
  <td><span data-ttu-id="028e6-2066">EF16</span><span class="sxs-lookup"><span data-stu-id="028e6-2066">EF16</span></span></td>
  <td><span data-ttu-id="028e6-2067">PenPaletteMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2067">PenPaletteMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF17.png" width="32" height="32" alt="StrokeEraseMirrored" /></td>
  <td><span data-ttu-id="028e6-2068">EF17</span><span class="sxs-lookup"><span data-stu-id="028e6-2068">EF17</span></span></td>
  <td><span data-ttu-id="028e6-2069">StrokeEraseMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2069">StrokeEraseMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF18.png" width="32" height="32" alt="PointEraseMirrored" /></td>
  <td><span data-ttu-id="028e6-2070">EF18</span><span class="sxs-lookup"><span data-stu-id="028e6-2070">EF18</span></span></td>
  <td><span data-ttu-id="028e6-2071">PointEraseMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2071">PointEraseMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF19.png" width="32" height="32" alt="ClearAllInkMirrored" /></td>
  <td><span data-ttu-id="028e6-2072">EF19</span><span class="sxs-lookup"><span data-stu-id="028e6-2072">EF19</span></span></td>
  <td><span data-ttu-id="028e6-2073">ClearAllInkMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2073">ClearAllInkMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF1F.png" width="32" height="32" alt="BackgroundToggle" /></td>
  <td><span data-ttu-id="028e6-2074">EF1F</span><span class="sxs-lookup"><span data-stu-id="028e6-2074">EF1F</span></span></td>
  <td><span data-ttu-id="028e6-2075">BackgroundToggle</span><span class="sxs-lookup"><span data-stu-id="028e6-2075">BackgroundToggle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF20.png" width="32" height="32" alt="Marquee" /></td>
  <td><span data-ttu-id="028e6-2076">EF20</span><span class="sxs-lookup"><span data-stu-id="028e6-2076">EF20</span></span></td>
  <td><span data-ttu-id="028e6-2077">Marquee</span><span class="sxs-lookup"><span data-stu-id="028e6-2077">Marquee</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF2C.png" width="32" height="32" alt="ChromeCloseContrast" /></td>
  <td><span data-ttu-id="028e6-2078">EF2C</span><span class="sxs-lookup"><span data-stu-id="028e6-2078">EF2C</span></span></td>
  <td><span data-ttu-id="028e6-2079">ChromeCloseContrast</span><span class="sxs-lookup"><span data-stu-id="028e6-2079">ChromeCloseContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF2D.png" width="32" height="32" alt="ChromeMinimizeContrast" /></td>
  <td><span data-ttu-id="028e6-2080">EF2D</span><span class="sxs-lookup"><span data-stu-id="028e6-2080">EF2D</span></span></td>
  <td><span data-ttu-id="028e6-2081">ChromeMinimizeContrast</span><span class="sxs-lookup"><span data-stu-id="028e6-2081">ChromeMinimizeContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF2E.png" width="32" height="32" alt="ChromeMaximizeContrast" /></td>
  <td><span data-ttu-id="028e6-2082">EF2E</span><span class="sxs-lookup"><span data-stu-id="028e6-2082">EF2E</span></span></td>
  <td><span data-ttu-id="028e6-2083">ChromeMaximizeContrast</span><span class="sxs-lookup"><span data-stu-id="028e6-2083">ChromeMaximizeContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF2F.png" width="32" height="32" alt="ChromeRestoreContrast" /></td>
  <td><span data-ttu-id="028e6-2084">EF2F</span><span class="sxs-lookup"><span data-stu-id="028e6-2084">EF2F</span></span></td>
  <td><span data-ttu-id="028e6-2085">ChromeRestoreContrast</span><span class="sxs-lookup"><span data-stu-id="028e6-2085">ChromeRestoreContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF31.png" width="32" height="32" alt="TrafficLight" /></td>
  <td><span data-ttu-id="028e6-2086">EF31</span><span class="sxs-lookup"><span data-stu-id="028e6-2086">EF31</span></span></td>
  <td><span data-ttu-id="028e6-2087">TrafficLight</span><span class="sxs-lookup"><span data-stu-id="028e6-2087">TrafficLight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3B.png" width="32" height="32" alt="Replay" /></td>
  <td><span data-ttu-id="028e6-2088">EF3B</span><span class="sxs-lookup"><span data-stu-id="028e6-2088">EF3B</span></span></td>
  <td><span data-ttu-id="028e6-2089">再生</span><span class="sxs-lookup"><span data-stu-id="028e6-2089">Replay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3C.png" width="32" height="32" alt="Eyedropper" /></td>
  <td><span data-ttu-id="028e6-2090">EF3C</span><span class="sxs-lookup"><span data-stu-id="028e6-2090">EF3C</span></span></td>
  <td><span data-ttu-id="028e6-2091">スポイト</span><span class="sxs-lookup"><span data-stu-id="028e6-2091">Eyedropper</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3D.png" width="32" height="32" alt="LineDisplay" /></td>
  <td><span data-ttu-id="028e6-2092">EF3D</span><span class="sxs-lookup"><span data-stu-id="028e6-2092">EF3D</span></span></td>
  <td><span data-ttu-id="028e6-2093">LineDisplay</span><span class="sxs-lookup"><span data-stu-id="028e6-2093">LineDisplay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3E.png" width="32" height="32" alt="PINPad" /></td>
  <td><span data-ttu-id="028e6-2094">EF3E</span><span class="sxs-lookup"><span data-stu-id="028e6-2094">EF3E</span></span></td>
  <td><span data-ttu-id="028e6-2095">PINPad</span><span class="sxs-lookup"><span data-stu-id="028e6-2095">PINPad</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3F.png" width="32" height="32" alt="SignatureCapture" /></td>
  <td><span data-ttu-id="028e6-2096">EF3F</span><span class="sxs-lookup"><span data-stu-id="028e6-2096">EF3F</span></span></td>
  <td><span data-ttu-id="028e6-2097">SignatureCapture</span><span class="sxs-lookup"><span data-stu-id="028e6-2097">SignatureCapture</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF40.png" width="32" height="32" alt="ChipCardCreditCardReader" /></td>
  <td><span data-ttu-id="028e6-2098">EF40</span><span class="sxs-lookup"><span data-stu-id="028e6-2098">EF40</span></span></td>
  <td><span data-ttu-id="028e6-2099">ChipCardCreditCardReader</span><span class="sxs-lookup"><span data-stu-id="028e6-2099">ChipCardCreditCardReader</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF58.png" width="32" height="32" alt="PlayerSettings" /></td>
  <td><span data-ttu-id="028e6-2100">EF58</span><span class="sxs-lookup"><span data-stu-id="028e6-2100">EF58</span></span></td>
  <td><span data-ttu-id="028e6-2101">PlayerSettings</span><span class="sxs-lookup"><span data-stu-id="028e6-2101">PlayerSettings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF6B.png" width="32" height="32" alt="LandscapeOrientation" /></td>
  <td><span data-ttu-id="028e6-2102">EF6B</span><span class="sxs-lookup"><span data-stu-id="028e6-2102">EF6B</span></span></td>
  <td><span data-ttu-id="028e6-2103">LandscapeOrientation</span><span class="sxs-lookup"><span data-stu-id="028e6-2103">LandscapeOrientation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EFA5.png" width="32" height="32" alt="Touchpad" /></td>
  <td><span data-ttu-id="028e6-2104">EFA5</span><span class="sxs-lookup"><span data-stu-id="028e6-2104">EFA5</span></span></td>
  <td><span data-ttu-id="028e6-2105">タッチパッド</span><span class="sxs-lookup"><span data-stu-id="028e6-2105">Touchpad</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EFA9.png" width="32" height="32" alt="Speech" /></td>
  <td><span data-ttu-id="028e6-2106">EFA9</span><span class="sxs-lookup"><span data-stu-id="028e6-2106">EFA9</span></span></td>
  <td><span data-ttu-id="028e6-2107">発声</span><span class="sxs-lookup"><span data-stu-id="028e6-2107">Speech</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F000.png" width="32" height="32" alt="KnowledgeArticle" /></td>
  <td><span data-ttu-id="028e6-2108">F000</span><span class="sxs-lookup"><span data-stu-id="028e6-2108">F000</span></span></td>
  <td><span data-ttu-id="028e6-2109">KnowledgeArticle</span><span class="sxs-lookup"><span data-stu-id="028e6-2109">KnowledgeArticle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F003.png" width="32" height="32" alt="Relationship" /></td>
  <td><span data-ttu-id="028e6-2110">F003</span><span class="sxs-lookup"><span data-stu-id="028e6-2110">F003</span></span></td>
  <td><span data-ttu-id="028e6-2111">Relationship</span><span class="sxs-lookup"><span data-stu-id="028e6-2111">Relationship</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F080.png" width="32" height="32" alt="DefaultAPN" /></td>
  <td><span data-ttu-id="028e6-2112">F080</span><span class="sxs-lookup"><span data-stu-id="028e6-2112">F080</span></span></td>
  <td><span data-ttu-id="028e6-2113">DefaultAPN</span><span class="sxs-lookup"><span data-stu-id="028e6-2113">DefaultAPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F081.png" width="32" height="32" alt="UserAPN " /></td>
  <td><span data-ttu-id="028e6-2114">F081</span><span class="sxs-lookup"><span data-stu-id="028e6-2114">F081</span></span></td>
  <td><span data-ttu-id="028e6-2115">UserAPN</span><span class="sxs-lookup"><span data-stu-id="028e6-2115">UserAPN</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/F085.png" width="32" height="32" alt="DoublePinyin" /></td>
  <td><span data-ttu-id="028e6-2116">F085</span><span class="sxs-lookup"><span data-stu-id="028e6-2116">F085</span></span></td>
  <td><span data-ttu-id="028e6-2117">DoublePinyin</span><span class="sxs-lookup"><span data-stu-id="028e6-2117">DoublePinyin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F08C.png" width="32" height="32" alt="BlueLight" /></td>
  <td><span data-ttu-id="028e6-2118">F08C</span><span class="sxs-lookup"><span data-stu-id="028e6-2118">F08C</span></span></td>
  <td><span data-ttu-id="028e6-2119">BlueLight</span><span class="sxs-lookup"><span data-stu-id="028e6-2119">BlueLight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F093.png" width="32" height="32" alt="ButtonA" /></td>
  <td><span data-ttu-id="028e6-2120">F093</span><span class="sxs-lookup"><span data-stu-id="028e6-2120">F093</span></span></td>
  <td><span data-ttu-id="028e6-2121">ButtonA</span><span class="sxs-lookup"><span data-stu-id="028e6-2121">ButtonA</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F094.png" width="32" height="32" alt="ButtonB" /></td>
  <td><span data-ttu-id="028e6-2122">F094</span><span class="sxs-lookup"><span data-stu-id="028e6-2122">F094</span></span></td>
  <td><span data-ttu-id="028e6-2123">ButtonB</span><span class="sxs-lookup"><span data-stu-id="028e6-2123">ButtonB</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F095.png" width="32" height="32" alt="ButtonY" /></td>
  <td><span data-ttu-id="028e6-2124">F095</span><span class="sxs-lookup"><span data-stu-id="028e6-2124">F095</span></span></td>
  <td><span data-ttu-id="028e6-2125">ButtonY</span><span class="sxs-lookup"><span data-stu-id="028e6-2125">ButtonY</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F096.png" width="32" height="32" alt="ButtonX" /></td>
  <td><span data-ttu-id="028e6-2126">F096</span><span class="sxs-lookup"><span data-stu-id="028e6-2126">F096</span></span></td>
  <td><span data-ttu-id="028e6-2127">ButtonX</span><span class="sxs-lookup"><span data-stu-id="028e6-2127">ButtonX</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0AD.png" width="32" height="32" alt="ArrowUp8" /></td>
  <td><span data-ttu-id="028e6-2128">F0AD</span><span class="sxs-lookup"><span data-stu-id="028e6-2128">F0AD</span></span></td>
  <td><span data-ttu-id="028e6-2129">ArrowUp8</span><span class="sxs-lookup"><span data-stu-id="028e6-2129">ArrowUp8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0AE.png" width="32" height="32" alt="ArrowDown8" /></td>
  <td><span data-ttu-id="028e6-2130">F0AE</span><span class="sxs-lookup"><span data-stu-id="028e6-2130">F0AE</span></span></td>
  <td><span data-ttu-id="028e6-2131">ArrowDown8</span><span class="sxs-lookup"><span data-stu-id="028e6-2131">ArrowDown8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0AF.png" width="32" height="32" alt="ArrowRight8" /></td>
  <td><span data-ttu-id="028e6-2132">F0AF</span><span class="sxs-lookup"><span data-stu-id="028e6-2132">F0AF</span></span></td>
  <td><span data-ttu-id="028e6-2133">ArrowRight8</span><span class="sxs-lookup"><span data-stu-id="028e6-2133">ArrowRight8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B0.png" width="32" height="32" alt="ArrowLeft8" /></td>
  <td><span data-ttu-id="028e6-2134">F0B0</span><span class="sxs-lookup"><span data-stu-id="028e6-2134">F0B0</span></span></td>
  <td><span data-ttu-id="028e6-2135">ArrowLeft8</span><span class="sxs-lookup"><span data-stu-id="028e6-2135">ArrowLeft8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B2.png" width="32" height="32" alt="QuarentinedItems" /></td>
  <td><span data-ttu-id="028e6-2136">F0B2</span><span class="sxs-lookup"><span data-stu-id="028e6-2136">F0B2</span></span></td>
  <td><span data-ttu-id="028e6-2137">QuarentinedItems</span><span class="sxs-lookup"><span data-stu-id="028e6-2137">QuarentinedItems</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B3.png" width="32" height="32" alt="QuarentinedItemsMirrored" /></td>
  <td><span data-ttu-id="028e6-2138">F0B3</span><span class="sxs-lookup"><span data-stu-id="028e6-2138">F0B3</span></span></td>
  <td><span data-ttu-id="028e6-2139">QuarentinedItemsMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2139">QuarentinedItemsMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B4.png" width="32" height="32" alt="Protractor" /></td>
  <td><span data-ttu-id="028e6-2140">F0B4</span><span class="sxs-lookup"><span data-stu-id="028e6-2140">F0B4</span></span></td>
  <td><span data-ttu-id="028e6-2141">Protractor</span><span class="sxs-lookup"><span data-stu-id="028e6-2141">Protractor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B5.png" width="32" height="32" alt="ChecklistMirrored" /></td>
  <td><span data-ttu-id="028e6-2142">F0B5</span><span class="sxs-lookup"><span data-stu-id="028e6-2142">F0B5</span></span></td>
  <td><span data-ttu-id="028e6-2143">ChecklistMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2143">ChecklistMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B6.png" width="32" height="32" alt="StatusCircle7" /></td>
  <td><span data-ttu-id="028e6-2144">F0B6</span><span class="sxs-lookup"><span data-stu-id="028e6-2144">F0B6</span></span></td>
  <td><span data-ttu-id="028e6-2145">StatusCircle7</span><span class="sxs-lookup"><span data-stu-id="028e6-2145">StatusCircle7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B7.png" width="32" height="32" alt="StatusCheckmark7" /></td>
  <td><span data-ttu-id="028e6-2146">F0B7</span><span class="sxs-lookup"><span data-stu-id="028e6-2146">F0B7</span></span></td>
  <td><span data-ttu-id="028e6-2147">StatusCheckmark7</span><span class="sxs-lookup"><span data-stu-id="028e6-2147">StatusCheckmark7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B8.png" width="32" height="32" alt="StatusErrorCircle7" /></td>
  <td><span data-ttu-id="028e6-2148">F0B8</span><span class="sxs-lookup"><span data-stu-id="028e6-2148">F0B8</span></span></td>
  <td><span data-ttu-id="028e6-2149">StatusErrorCircle7</span><span class="sxs-lookup"><span data-stu-id="028e6-2149">StatusErrorCircle7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B9.png" width="32" height="32" alt="Connected" /></td>
  <td><span data-ttu-id="028e6-2150">F0B9</span><span class="sxs-lookup"><span data-stu-id="028e6-2150">F0B9</span></span></td>
  <td><span data-ttu-id="028e6-2151">Connected</span><span class="sxs-lookup"><span data-stu-id="028e6-2151">Connected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0C6.png" width="32" height="32" alt="PencilFill" /></td>
  <td><span data-ttu-id="028e6-2152">F0C6</span><span class="sxs-lookup"><span data-stu-id="028e6-2152">F0C6</span></span></td>
  <td><span data-ttu-id="028e6-2153">PencilFill</span><span class="sxs-lookup"><span data-stu-id="028e6-2153">PencilFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0C7.png" width="32" height="32" alt="CalligraphyFill" /></td>
  <td><span data-ttu-id="028e6-2154">F0C7</span><span class="sxs-lookup"><span data-stu-id="028e6-2154">F0C7</span></span></td>
  <td><span data-ttu-id="028e6-2155">CalligraphyFill</span><span class="sxs-lookup"><span data-stu-id="028e6-2155">CalligraphyFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CA.png" width="32" height="32" alt="QuarterStarLeft" /></td>
  <td><span data-ttu-id="028e6-2156">F0CA</span><span class="sxs-lookup"><span data-stu-id="028e6-2156">F0CA</span></span></td>
  <td><span data-ttu-id="028e6-2157">QuarterStarLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2157">QuarterStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CB.png" width="32" height="32" alt="QuarterStarRight" /></td>
  <td><span data-ttu-id="028e6-2158">F0CB</span><span class="sxs-lookup"><span data-stu-id="028e6-2158">F0CB</span></span></td>
  <td><span data-ttu-id="028e6-2159">QuarterStarRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2159">QuarterStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CC.png" width="32" height="32" alt="ThreeQuarterStarLeft" /></td>
  <td><span data-ttu-id="028e6-2160">F0CC</span><span class="sxs-lookup"><span data-stu-id="028e6-2160">F0CC</span></span></td>
  <td><span data-ttu-id="028e6-2161">ThreeQuarterStarLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2161">ThreeQuarterStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CD.png" width="32" height="32" alt="ThreeQuarterStarRight" /></td>
  <td><span data-ttu-id="028e6-2162">F0CD</span><span class="sxs-lookup"><span data-stu-id="028e6-2162">F0CD</span></span></td>
  <td><span data-ttu-id="028e6-2163">ThreeQuarterStarRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2163">ThreeQuarterStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CE.png" width="32" height="32" alt="QuietHoursBadge12" /></td>
  <td><span data-ttu-id="028e6-2164">F0CE</span><span class="sxs-lookup"><span data-stu-id="028e6-2164">F0CE</span></span></td>
  <td><span data-ttu-id="028e6-2165">QuietHoursBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-2165">QuietHoursBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D2.png" width="32" height="32" alt="BackMirrored" /></td>
  <td><span data-ttu-id="028e6-2166">F0D2</span><span class="sxs-lookup"><span data-stu-id="028e6-2166">F0D2</span></span></td>
  <td><span data-ttu-id="028e6-2167">BackMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2167">BackMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D3.png" width="32" height="32" alt="ForwardMirrored" /></td>
  <td><span data-ttu-id="028e6-2168">F0D3</span><span class="sxs-lookup"><span data-stu-id="028e6-2168">F0D3</span></span></td>
  <td><span data-ttu-id="028e6-2169">ForwardMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2169">ForwardMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D5.png" width="32" height="32" alt="ChromeBackContrast" /></td>
  <td><span data-ttu-id="028e6-2170">F0D5</span><span class="sxs-lookup"><span data-stu-id="028e6-2170">F0D5</span></span></td>
  <td><span data-ttu-id="028e6-2171">ChromeBackContrast</span><span class="sxs-lookup"><span data-stu-id="028e6-2171">ChromeBackContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D6.png" width="32" height="32" alt="ChromeBackContrastMirrored" /></td>
  <td><span data-ttu-id="028e6-2172">F0D6</span><span class="sxs-lookup"><span data-stu-id="028e6-2172">F0D6</span></span></td>
  <td><span data-ttu-id="028e6-2173">ChromeBackContrastMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2173">ChromeBackContrastMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D7.png" width="32" height="32" alt="ChromeBackToWindowContrast" /></td>
  <td><span data-ttu-id="028e6-2174">F0D7</span><span class="sxs-lookup"><span data-stu-id="028e6-2174">F0D7</span></span></td>
  <td><span data-ttu-id="028e6-2175">ChromeBackToWindowContrast</span><span class="sxs-lookup"><span data-stu-id="028e6-2175">ChromeBackToWindowContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D8.png" width="32" height="32" alt="ChromeFullScreenContrast" /></td>
  <td><span data-ttu-id="028e6-2176">F0D8</span><span class="sxs-lookup"><span data-stu-id="028e6-2176">F0D8</span></span></td>
  <td><span data-ttu-id="028e6-2177">ChromeFullScreenContrast</span><span class="sxs-lookup"><span data-stu-id="028e6-2177">ChromeFullScreenContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E2.png" width="32" height="32" alt="GridView" /></td>
  <td><span data-ttu-id="028e6-2178">F0E2</span><span class="sxs-lookup"><span data-stu-id="028e6-2178">F0E2</span></span></td>
  <td><span data-ttu-id="028e6-2179">GridView</span><span class="sxs-lookup"><span data-stu-id="028e6-2179">GridView</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E3.png" width="32" height="32" alt="ClipboardList" /></td>
  <td><span data-ttu-id="028e6-2180">F0E3</span><span class="sxs-lookup"><span data-stu-id="028e6-2180">F0E3</span></span></td>
  <td><span data-ttu-id="028e6-2181">ClipboardList</span><span class="sxs-lookup"><span data-stu-id="028e6-2181">ClipboardList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E4.png" width="32" height="32" alt="ClipboardListMirrored" /></td>
  <td><span data-ttu-id="028e6-2182">F0E4</span><span class="sxs-lookup"><span data-stu-id="028e6-2182">F0E4</span></span></td>
  <td><span data-ttu-id="028e6-2183">ClipboardListMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2183">ClipboardListMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E5.png" width="32" height="32" alt="OutlineQuarterStarLeft" /></td>
  <td><span data-ttu-id="028e6-2184">F0E5</span><span class="sxs-lookup"><span data-stu-id="028e6-2184">F0E5</span></span></td>
  <td><span data-ttu-id="028e6-2185">OutlineQuarterStarLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2185">OutlineQuarterStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E6.png" width="32" height="32" alt="OutlineQuarterStarRight" /></td>
  <td><span data-ttu-id="028e6-2186">F0E6</span><span class="sxs-lookup"><span data-stu-id="028e6-2186">F0E6</span></span></td>
  <td><span data-ttu-id="028e6-2187">OutlineQuarterStarRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2187">OutlineQuarterStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E7.png" width="32" height="32" alt="OutlineHalfStarLeft" /></td>
  <td><span data-ttu-id="028e6-2188">F0E7</span><span class="sxs-lookup"><span data-stu-id="028e6-2188">F0E7</span></span></td>
  <td><span data-ttu-id="028e6-2189">OutlineHalfStarLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2189">OutlineHalfStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E8.png" width="32" height="32" alt="OutlineHalfStarRight" /></td>
  <td><span data-ttu-id="028e6-2190">F0E8</span><span class="sxs-lookup"><span data-stu-id="028e6-2190">F0E8</span></span></td>
  <td><span data-ttu-id="028e6-2191">OutlineHalfStarRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2191">OutlineHalfStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E9.png" width="32" height="32" alt="OutlineThreeQuarterStarLeft" /></td>
  <td><span data-ttu-id="028e6-2192">F0E9</span><span class="sxs-lookup"><span data-stu-id="028e6-2192">F0E9</span></span></td>
  <td><span data-ttu-id="028e6-2193">OutlineThreeQuarterStarLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2193">OutlineThreeQuarterStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0EA.png" width="32" height="32" alt="OutlineThreeQuarterStarRight" /></td>
  <td><span data-ttu-id="028e6-2194">F0EA</span><span class="sxs-lookup"><span data-stu-id="028e6-2194">F0EA</span></span></td>
  <td><span data-ttu-id="028e6-2195">OutlineThreeQuarterStarRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2195">OutlineThreeQuarterStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0EB.png" width="32" height="32" alt="SpatialVolume0" /></td>
  <td><span data-ttu-id="028e6-2196">F0EB</span><span class="sxs-lookup"><span data-stu-id="028e6-2196">F0EB</span></span></td>
  <td><span data-ttu-id="028e6-2197">SpatialVolume0</span><span class="sxs-lookup"><span data-stu-id="028e6-2197">SpatialVolume0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0EC.png" width="32" height="32" alt="SpatialVolume1" /></td>
  <td><span data-ttu-id="028e6-2198">F0EC</span><span class="sxs-lookup"><span data-stu-id="028e6-2198">F0EC</span></span></td>
  <td><span data-ttu-id="028e6-2199">SpatialVolume1</span><span class="sxs-lookup"><span data-stu-id="028e6-2199">SpatialVolume1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0ED.png" width="32" height="32" alt="SpatialVolume2" /></td>
  <td><span data-ttu-id="028e6-2200">F0ED</span><span class="sxs-lookup"><span data-stu-id="028e6-2200">F0ED</span></span></td>
  <td><span data-ttu-id="028e6-2201">SpatialVolume2</span><span class="sxs-lookup"><span data-stu-id="028e6-2201">SpatialVolume2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0EE.png" width="32" height="32" alt="SpatialVolume3" /></td>
  <td><span data-ttu-id="028e6-2202">F0EE</span><span class="sxs-lookup"><span data-stu-id="028e6-2202">F0EE</span></span></td>
  <td><span data-ttu-id="028e6-2203">SpatialVolume3</span><span class="sxs-lookup"><span data-stu-id="028e6-2203">SpatialVolume3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0F7.png" width="32" height="32" alt="OutlineStarLeftHalf" /></td>
  <td><span data-ttu-id="028e6-2204">F0F7</span><span class="sxs-lookup"><span data-stu-id="028e6-2204">F0F7</span></span></td>
  <td><span data-ttu-id="028e6-2205">OutlineStarLeftHalf</span><span class="sxs-lookup"><span data-stu-id="028e6-2205">OutlineStarLeftHalf</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0F8.png" width="32" height="32" alt="OutlineStarRightHalf" /></td>
  <td><span data-ttu-id="028e6-2206">F0F8</span><span class="sxs-lookup"><span data-stu-id="028e6-2206">F0F8</span></span></td>
  <td><span data-ttu-id="028e6-2207">OutlineStarRightHalf</span><span class="sxs-lookup"><span data-stu-id="028e6-2207">OutlineStarRightHalf</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0F9.png" width="32" height="32" alt="ChromeAnnotateContrast" /></td>
  <td><span data-ttu-id="028e6-2208">F0F9</span><span class="sxs-lookup"><span data-stu-id="028e6-2208">F0F9</span></span></td>
  <td><span data-ttu-id="028e6-2209">ChromeAnnotateContrast</span><span class="sxs-lookup"><span data-stu-id="028e6-2209">ChromeAnnotateContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0FB.png" width="32" height="32" alt="DefenderBadge12" /></td>
  <td><span data-ttu-id="028e6-2210">F0FB</span><span class="sxs-lookup"><span data-stu-id="028e6-2210">F0FB</span></span></td>
  <td><span data-ttu-id="028e6-2211">DefenderBadge12</span><span class="sxs-lookup"><span data-stu-id="028e6-2211">DefenderBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F103.png" width="32" height="32" alt="DetachablePC" /></td>
  <td><span data-ttu-id="028e6-2212">F103</span><span class="sxs-lookup"><span data-stu-id="028e6-2212">F103</span></span></td>
  <td><span data-ttu-id="028e6-2213">DetachablePC</span><span class="sxs-lookup"><span data-stu-id="028e6-2213">DetachablePC</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F108.png" width="32" height="32" alt="LeftStick" /></td>
  <td><span data-ttu-id="028e6-2214">F108</span><span class="sxs-lookup"><span data-stu-id="028e6-2214">F108</span></span></td>
  <td><span data-ttu-id="028e6-2215">LeftStick</span><span class="sxs-lookup"><span data-stu-id="028e6-2215">LeftStick</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F109.png" width="32" height="32" alt="RightStick" /></td>
  <td><span data-ttu-id="028e6-2216">F109</span><span class="sxs-lookup"><span data-stu-id="028e6-2216">F109</span></span></td>
  <td><span data-ttu-id="028e6-2217">RightStick</span><span class="sxs-lookup"><span data-stu-id="028e6-2217">RightStick</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10A.png" width="32" height="32" alt="TriggerLeft" /></td>
  <td><span data-ttu-id="028e6-2218">F10A</span><span class="sxs-lookup"><span data-stu-id="028e6-2218">F10A</span></span></td>
  <td><span data-ttu-id="028e6-2219">TriggerLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2219">TriggerLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10B.png" width="32" height="32" alt="TriggerRight" /></td>
  <td><span data-ttu-id="028e6-2220">F10B</span><span class="sxs-lookup"><span data-stu-id="028e6-2220">F10B</span></span></td>
  <td><span data-ttu-id="028e6-2221">TriggerRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2221">TriggerRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10C.png" width="32" height="32" alt="BumperLeft" /></td>
  <td><span data-ttu-id="028e6-2222">F10C</span><span class="sxs-lookup"><span data-stu-id="028e6-2222">F10C</span></span></td>
  <td><span data-ttu-id="028e6-2223">BumperLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2223">BumperLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10D.png" width="32" height="32" alt="BumperRight" /></td>
  <td><span data-ttu-id="028e6-2224">F10D</span><span class="sxs-lookup"><span data-stu-id="028e6-2224">F10D</span></span></td>
  <td><span data-ttu-id="028e6-2225">BumperRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2225">BumperRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10E.png" width="32" height="32" alt="Dpad" /></td>
  <td><span data-ttu-id="028e6-2226">F10E</span><span class="sxs-lookup"><span data-stu-id="028e6-2226">F10E</span></span></td>
  <td><span data-ttu-id="028e6-2227">Dpad</span><span class="sxs-lookup"><span data-stu-id="028e6-2227">Dpad</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F110.png" width="32" height="32" alt="EnglishPunctuation" /></td>
  <td><span data-ttu-id="028e6-2228">F110</span><span class="sxs-lookup"><span data-stu-id="028e6-2228">F110</span></span></td>
  <td><span data-ttu-id="028e6-2229">EnglishPunctuation</span><span class="sxs-lookup"><span data-stu-id="028e6-2229">EnglishPunctuation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F111.png" width="32" height="32" alt="ChinesePunctuation" /></td>
  <td><span data-ttu-id="028e6-2230">F111</span><span class="sxs-lookup"><span data-stu-id="028e6-2230">F111</span></span></td>
  <td><span data-ttu-id="028e6-2231">ChinesePunctuation</span><span class="sxs-lookup"><span data-stu-id="028e6-2231">ChinesePunctuation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F119.png" width="32" height="32" alt="HMD" /></td>
  <td><span data-ttu-id="028e6-2232">F119</span><span class="sxs-lookup"><span data-stu-id="028e6-2232">F119</span></span></td>
  <td><span data-ttu-id="028e6-2233">HMD</span><span class="sxs-lookup"><span data-stu-id="028e6-2233">HMD</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F11B.png" width="32" height="32" alt="CtrlSpatialRight" /></td>
  <td><span data-ttu-id="028e6-2234">F11B</span><span class="sxs-lookup"><span data-stu-id="028e6-2234">F11B</span></span></td>
  <td><span data-ttu-id="028e6-2235">CtrlSpatialRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2235">CtrlSpatialRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F126.png" width="32" height="32" alt="PaginationDotOutline10" /></td>
  <td><span data-ttu-id="028e6-2236">F126</span><span class="sxs-lookup"><span data-stu-id="028e6-2236">F126</span></span></td>
  <td><span data-ttu-id="028e6-2237">PaginationDotOutline10</span><span class="sxs-lookup"><span data-stu-id="028e6-2237">PaginationDotOutline10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F127.png" width="32" height="32" alt="PaginationDotSolid10" /></td>
  <td><span data-ttu-id="028e6-2238">F127</span><span class="sxs-lookup"><span data-stu-id="028e6-2238">F127</span></span></td>
  <td><span data-ttu-id="028e6-2239">PaginationDotSolid10</span><span class="sxs-lookup"><span data-stu-id="028e6-2239">PaginationDotSolid10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F128.png" width="32" height="32" alt="StrokeErase2" /></td>
  <td><span data-ttu-id="028e6-2240">F128</span><span class="sxs-lookup"><span data-stu-id="028e6-2240">F128</span></span></td>
  <td><span data-ttu-id="028e6-2241">StrokeErase2</span><span class="sxs-lookup"><span data-stu-id="028e6-2241">StrokeErase2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F129.png" width="32" height="32" alt="SmallErase" /></td>
  <td><span data-ttu-id="028e6-2242">F129</span><span class="sxs-lookup"><span data-stu-id="028e6-2242">F129</span></span></td>
  <td><span data-ttu-id="028e6-2243">SmallErase</span><span class="sxs-lookup"><span data-stu-id="028e6-2243">SmallErase</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F12A.png" width="32" height="32" alt="LargeErase" /></td>
  <td><span data-ttu-id="028e6-2244">F12A</span><span class="sxs-lookup"><span data-stu-id="028e6-2244">F12A</span></span></td>
  <td><span data-ttu-id="028e6-2245">LargeErase</span><span class="sxs-lookup"><span data-stu-id="028e6-2245">LargeErase</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F12B.png" width="32" height="32" alt="FolderHorizontal" /></td>
  <td><span data-ttu-id="028e6-2246">F12B</span><span class="sxs-lookup"><span data-stu-id="028e6-2246">F12B</span></span></td>
  <td><span data-ttu-id="028e6-2247">FolderHorizontal</span><span class="sxs-lookup"><span data-stu-id="028e6-2247">FolderHorizontal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F12E.png" width="32" height="32" alt="MicrophoneListening" /></td>
  <td><span data-ttu-id="028e6-2248">F12E</span><span class="sxs-lookup"><span data-stu-id="028e6-2248">F12E</span></span></td>
  <td><span data-ttu-id="028e6-2249">MicrophoneListening</span><span class="sxs-lookup"><span data-stu-id="028e6-2249">MicrophoneListening</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F12F.png" width="32" height="32" alt="StatusExclamationCircle7 " /></td>
  <td><span data-ttu-id="028e6-2250">F12F</span><span class="sxs-lookup"><span data-stu-id="028e6-2250">F12F</span></span></td>
  <td><span data-ttu-id="028e6-2251">StatusExclamationCircle7</span><span class="sxs-lookup"><span data-stu-id="028e6-2251">StatusExclamationCircle7</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/F131.png" width="32" height="32" alt="Video360" /></td>
  <td><span data-ttu-id="028e6-2252">F131</span><span class="sxs-lookup"><span data-stu-id="028e6-2252">F131</span></span></td>
  <td><span data-ttu-id="028e6-2253">Video360</span><span class="sxs-lookup"><span data-stu-id="028e6-2253">Video360</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F133.png" width="32" height="32" alt="GiftboxOpen" /></td>
  <td><span data-ttu-id="028e6-2254">F133</span><span class="sxs-lookup"><span data-stu-id="028e6-2254">F133</span></span></td>
  <td><span data-ttu-id="028e6-2255">GiftboxOpen</span><span class="sxs-lookup"><span data-stu-id="028e6-2255">GiftboxOpen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F136.png" width="32" height="32" alt="StatusCircleOuter" /></td>
  <td><span data-ttu-id="028e6-2256">F136</span><span class="sxs-lookup"><span data-stu-id="028e6-2256">F136</span></span></td>
  <td><span data-ttu-id="028e6-2257">StatusCircleOuter</span><span class="sxs-lookup"><span data-stu-id="028e6-2257">StatusCircleOuter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F137.png" width="32" height="32" alt="StatusCircleInner" /></td>
  <td><span data-ttu-id="028e6-2258">F137</span><span class="sxs-lookup"><span data-stu-id="028e6-2258">F137</span></span></td>
  <td><span data-ttu-id="028e6-2259">StatusCircleInner</span><span class="sxs-lookup"><span data-stu-id="028e6-2259">StatusCircleInner</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F138.png" width="32" height="32" alt="StatusCircleRing" /></td>
  <td><span data-ttu-id="028e6-2260">F138</span><span class="sxs-lookup"><span data-stu-id="028e6-2260">F138</span></span></td>
  <td><span data-ttu-id="028e6-2261">StatusCircleRing</span><span class="sxs-lookup"><span data-stu-id="028e6-2261">StatusCircleRing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F139.png" width="32" height="32" alt="StatusTriangleOuter" /></td>
  <td><span data-ttu-id="028e6-2262">F139</span><span class="sxs-lookup"><span data-stu-id="028e6-2262">F139</span></span></td>
  <td><span data-ttu-id="028e6-2263">StatusTriangleOuter</span><span class="sxs-lookup"><span data-stu-id="028e6-2263">StatusTriangleOuter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13A.png" width="32" height="32" alt="StatusTriangleInner" /></td>
  <td><span data-ttu-id="028e6-2264">F13A</span><span class="sxs-lookup"><span data-stu-id="028e6-2264">F13A</span></span></td>
  <td><span data-ttu-id="028e6-2265">StatusTriangleInner</span><span class="sxs-lookup"><span data-stu-id="028e6-2265">StatusTriangleInner</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13B.png" width="32" height="32" alt="StatusTriangleExclamation" /></td>
  <td><span data-ttu-id="028e6-2266">F13B</span><span class="sxs-lookup"><span data-stu-id="028e6-2266">F13B</span></span></td>
  <td><span data-ttu-id="028e6-2267">StatusTriangleExclamation</span><span class="sxs-lookup"><span data-stu-id="028e6-2267">StatusTriangleExclamation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13C.png" width="32" height="32" alt="StatusCircleExclamation" /></td>
  <td><span data-ttu-id="028e6-2268">F13C</span><span class="sxs-lookup"><span data-stu-id="028e6-2268">F13C</span></span></td>
  <td><span data-ttu-id="028e6-2269">StatusCircleExclamation</span><span class="sxs-lookup"><span data-stu-id="028e6-2269">StatusCircleExclamation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13D.png" width="32" height="32" alt="StatusCircleErrorX" /></td>
  <td><span data-ttu-id="028e6-2270">F13D</span><span class="sxs-lookup"><span data-stu-id="028e6-2270">F13D</span></span></td>
  <td><span data-ttu-id="028e6-2271">StatusCircleErrorX</span><span class="sxs-lookup"><span data-stu-id="028e6-2271">StatusCircleErrorX</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13E.png" width="32" height="32" alt="StatusCircleCheckmark" /></td>
  <td><span data-ttu-id="028e6-2272">F13E</span><span class="sxs-lookup"><span data-stu-id="028e6-2272">F13E</span></span></td>
  <td><span data-ttu-id="028e6-2273">StatusCircleCheckmark</span><span class="sxs-lookup"><span data-stu-id="028e6-2273">StatusCircleCheckmark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13F.png" width="32" height="32" alt="StatusCircleInfo" /></td>
  <td><span data-ttu-id="028e6-2274">F13F</span><span class="sxs-lookup"><span data-stu-id="028e6-2274">F13F</span></span></td>
  <td><span data-ttu-id="028e6-2275">StatusCircleInfo</span><span class="sxs-lookup"><span data-stu-id="028e6-2275">StatusCircleInfo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F140.png" width="32" height="32" alt="StatusCircleBlock" /></td>
  <td><span data-ttu-id="028e6-2276">F140</span><span class="sxs-lookup"><span data-stu-id="028e6-2276">F140</span></span></td>
  <td><span data-ttu-id="028e6-2277">StatusCircleBlock</span><span class="sxs-lookup"><span data-stu-id="028e6-2277">StatusCircleBlock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F141.png" width="32" height="32" alt="StatusCircleBlock2" /></td>
  <td><span data-ttu-id="028e6-2278">F141</span><span class="sxs-lookup"><span data-stu-id="028e6-2278">F141</span></span></td>
  <td><span data-ttu-id="028e6-2279">StatusCircleBlock2</span><span class="sxs-lookup"><span data-stu-id="028e6-2279">StatusCircleBlock2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F142.png" width="32" height="32" alt="StatusCircleQuestionMark" /></td>
  <td><span data-ttu-id="028e6-2280">F142</span><span class="sxs-lookup"><span data-stu-id="028e6-2280">F142</span></span></td>
  <td><span data-ttu-id="028e6-2281">StatusCircleQuestionMark</span><span class="sxs-lookup"><span data-stu-id="028e6-2281">StatusCircleQuestionMark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F143.png" width="32" height="32" alt="StatusCircleSync" /></td>
  <td><span data-ttu-id="028e6-2282">F143</span><span class="sxs-lookup"><span data-stu-id="028e6-2282">F143</span></span></td>
  <td><span data-ttu-id="028e6-2283">StatusCircleSync</span><span class="sxs-lookup"><span data-stu-id="028e6-2283">StatusCircleSync</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F146.png" width="32" height="32" alt="Dial1" /></td>
  <td><span data-ttu-id="028e6-2284">F146</span><span class="sxs-lookup"><span data-stu-id="028e6-2284">F146</span></span></td>
  <td><span data-ttu-id="028e6-2285">Dial1</span><span class="sxs-lookup"><span data-stu-id="028e6-2285">Dial1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F147.png" width="32" height="32" alt="Dial2" /></td>
  <td><span data-ttu-id="028e6-2286">F147</span><span class="sxs-lookup"><span data-stu-id="028e6-2286">F147</span></span></td>
  <td><span data-ttu-id="028e6-2287">Dial2</span><span class="sxs-lookup"><span data-stu-id="028e6-2287">Dial2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F148.png" width="32" height="32" alt="Dial3" /></td>
  <td><span data-ttu-id="028e6-2288">F148</span><span class="sxs-lookup"><span data-stu-id="028e6-2288">F148</span></span></td>
  <td><span data-ttu-id="028e6-2289">Dial3</span><span class="sxs-lookup"><span data-stu-id="028e6-2289">Dial3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F149.png" width="32" height="32" alt="Dial4" /></td>
  <td><span data-ttu-id="028e6-2290">F149</span><span class="sxs-lookup"><span data-stu-id="028e6-2290">F149</span></span></td>
  <td><span data-ttu-id="028e6-2291">Dial4</span><span class="sxs-lookup"><span data-stu-id="028e6-2291">Dial4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14A.png" width="32" height="32" alt="Dial5" /></td>
  <td><span data-ttu-id="028e6-2292">F14A</span><span class="sxs-lookup"><span data-stu-id="028e6-2292">F14A</span></span></td>
  <td><span data-ttu-id="028e6-2293">Dial5</span><span class="sxs-lookup"><span data-stu-id="028e6-2293">Dial5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14B.png" width="32" height="32" alt="Dial6" /></td>
  <td><span data-ttu-id="028e6-2294">F14B</span><span class="sxs-lookup"><span data-stu-id="028e6-2294">F14B</span></span></td>
  <td><span data-ttu-id="028e6-2295">Dial6</span><span class="sxs-lookup"><span data-stu-id="028e6-2295">Dial6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14C.png" width="32" height="32" alt="Dial7" /></td>
  <td><span data-ttu-id="028e6-2296">F14C</span><span class="sxs-lookup"><span data-stu-id="028e6-2296">F14C</span></span></td>
  <td><span data-ttu-id="028e6-2297">Dial7</span><span class="sxs-lookup"><span data-stu-id="028e6-2297">Dial7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14D.png" width="32" height="32" alt="Dial8" /></td>
  <td><span data-ttu-id="028e6-2298">F14D</span><span class="sxs-lookup"><span data-stu-id="028e6-2298">F14D</span></span></td>
  <td><span data-ttu-id="028e6-2299">Dial8</span><span class="sxs-lookup"><span data-stu-id="028e6-2299">Dial8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14E.png" width="32" height="32" alt="Dial9" /></td>
  <td><span data-ttu-id="028e6-2300">F14E</span><span class="sxs-lookup"><span data-stu-id="028e6-2300">F14E</span></span></td>
  <td><span data-ttu-id="028e6-2301">Dial9</span><span class="sxs-lookup"><span data-stu-id="028e6-2301">Dial9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14F.png" width="32" height="32" alt="Dial10" /></td>
  <td><span data-ttu-id="028e6-2302">F14F</span><span class="sxs-lookup"><span data-stu-id="028e6-2302">F14F</span></span></td>
  <td><span data-ttu-id="028e6-2303">Dial10</span><span class="sxs-lookup"><span data-stu-id="028e6-2303">Dial10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F150.png" width="32" height="32" alt="Dial11" /></td>
  <td><span data-ttu-id="028e6-2304">F150</span><span class="sxs-lookup"><span data-stu-id="028e6-2304">F150</span></span></td>
  <td><span data-ttu-id="028e6-2305">Dial11</span><span class="sxs-lookup"><span data-stu-id="028e6-2305">Dial11</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F151.png" width="32" height="32" alt="Dial12" /></td>
  <td><span data-ttu-id="028e6-2306">F151</span><span class="sxs-lookup"><span data-stu-id="028e6-2306">F151</span></span></td>
  <td><span data-ttu-id="028e6-2307">Dial12</span><span class="sxs-lookup"><span data-stu-id="028e6-2307">Dial12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F152.png" width="32" height="32" alt="Dial13" /></td>
  <td><span data-ttu-id="028e6-2308">F152</span><span class="sxs-lookup"><span data-stu-id="028e6-2308">F152</span></span></td>
  <td><span data-ttu-id="028e6-2309">Dial13</span><span class="sxs-lookup"><span data-stu-id="028e6-2309">Dial13</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F153.png" width="32" height="32" alt="Dial14" /></td>
  <td><span data-ttu-id="028e6-2310">F153</span><span class="sxs-lookup"><span data-stu-id="028e6-2310">F153</span></span></td>
  <td><span data-ttu-id="028e6-2311">Dial14</span><span class="sxs-lookup"><span data-stu-id="028e6-2311">Dial14</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F154.png" width="32" height="32" alt="Dial15" /></td>
  <td><span data-ttu-id="028e6-2312">F154</span><span class="sxs-lookup"><span data-stu-id="028e6-2312">F154</span></span></td>
  <td><span data-ttu-id="028e6-2313">Dial15</span><span class="sxs-lookup"><span data-stu-id="028e6-2313">Dial15</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F155.png" width="32" height="32" alt="Dial16" /></td>
  <td><span data-ttu-id="028e6-2314">F155</span><span class="sxs-lookup"><span data-stu-id="028e6-2314">F155</span></span></td>
  <td><span data-ttu-id="028e6-2315">Dial16</span><span class="sxs-lookup"><span data-stu-id="028e6-2315">Dial16</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F156.png" width="32" height="32" alt="DialShape1" /></td>
  <td><span data-ttu-id="028e6-2316">F156</span><span class="sxs-lookup"><span data-stu-id="028e6-2316">F156</span></span></td>
  <td><span data-ttu-id="028e6-2317">DialShape1</span><span class="sxs-lookup"><span data-stu-id="028e6-2317">DialShape1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F157.png" width="32" height="32" alt="DialShape2" /></td>
  <td><span data-ttu-id="028e6-2318">F157</span><span class="sxs-lookup"><span data-stu-id="028e6-2318">F157</span></span></td>
  <td><span data-ttu-id="028e6-2319">DialShape2</span><span class="sxs-lookup"><span data-stu-id="028e6-2319">DialShape2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F158.png" width="32" height="32" alt="DialShape3" /></td>
  <td><span data-ttu-id="028e6-2320">F158</span><span class="sxs-lookup"><span data-stu-id="028e6-2320">F158</span></span></td>
  <td><span data-ttu-id="028e6-2321">DialShape3</span><span class="sxs-lookup"><span data-stu-id="028e6-2321">DialShape3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F159.png" width="32" height="32" alt="DialShape4" /></td>
  <td><span data-ttu-id="028e6-2322">F159</span><span class="sxs-lookup"><span data-stu-id="028e6-2322">F159</span></span></td>
  <td><span data-ttu-id="028e6-2323">DialShape4</span><span class="sxs-lookup"><span data-stu-id="028e6-2323">DialShape4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F161.png" width="32" height="32" alt="TollSolid" /></td>
  <td><span data-ttu-id="028e6-2324">F161</span><span class="sxs-lookup"><span data-stu-id="028e6-2324">F161</span></span></td>
  <td><span data-ttu-id="028e6-2325">TollSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-2325">TollSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F163.png" width="32" height="32" alt="TrafficCongestionSolid" /></td>
  <td><span data-ttu-id="028e6-2326">F163</span><span class="sxs-lookup"><span data-stu-id="028e6-2326">F163</span></span></td>
  <td><span data-ttu-id="028e6-2327">TrafficCongestionSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-2327">TrafficCongestionSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F164.png" width="32" height="32" alt="ExploreContentSingle" /></td>
  <td><span data-ttu-id="028e6-2328">F164</span><span class="sxs-lookup"><span data-stu-id="028e6-2328">F164</span></span></td>
  <td><span data-ttu-id="028e6-2329">ExploreContentSingle</span><span class="sxs-lookup"><span data-stu-id="028e6-2329">ExploreContentSingle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F165.png" width="32" height="32" alt="CollapseContent" /></td>
  <td><span data-ttu-id="028e6-2330">F165</span><span class="sxs-lookup"><span data-stu-id="028e6-2330">F165</span></span></td>
  <td><span data-ttu-id="028e6-2331">CollapseContent</span><span class="sxs-lookup"><span data-stu-id="028e6-2331">CollapseContent</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F166.png" width="32" height="32" alt="CollapseContentSingle" /></td>
  <td><span data-ttu-id="028e6-2332">F166</span><span class="sxs-lookup"><span data-stu-id="028e6-2332">F166</span></span></td>
  <td><span data-ttu-id="028e6-2333">CollapseContentSingle</span><span class="sxs-lookup"><span data-stu-id="028e6-2333">CollapseContentSingle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F167.png" width="32" height="32" alt="InfoSolid" /></td>
  <td><span data-ttu-id="028e6-2334">F167</span><span class="sxs-lookup"><span data-stu-id="028e6-2334">F167</span></span></td>
  <td><span data-ttu-id="028e6-2335">InfoSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-2335">InfoSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F168.png" width="32" height="32" alt="GroupList" /></td>
  <td><span data-ttu-id="028e6-2336">F168</span><span class="sxs-lookup"><span data-stu-id="028e6-2336">F168</span></span></td>
  <td><span data-ttu-id="028e6-2337">GroupList</span><span class="sxs-lookup"><span data-stu-id="028e6-2337">GroupList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F169.png" width="32" height="32" alt="CaretBottomRightSolidCenter8" /></td>
  <td><span data-ttu-id="028e6-2338">F169</span><span class="sxs-lookup"><span data-stu-id="028e6-2338">F169</span></span></td>
  <td><span data-ttu-id="028e6-2339">CaretBottomRightSolidCenter8</span><span class="sxs-lookup"><span data-stu-id="028e6-2339">CaretBottomRightSolidCenter8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16A.png" width="32" height="32" alt="ProgressRingDots" /></td>
  <td><span data-ttu-id="028e6-2340">F16A</span><span class="sxs-lookup"><span data-stu-id="028e6-2340">F16A</span></span></td>
  <td><span data-ttu-id="028e6-2341">ProgressRingDots</span><span class="sxs-lookup"><span data-stu-id="028e6-2341">ProgressRingDots</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16B.png" width="32" height="32" alt="Checkbox14" /></td>
  <td><span data-ttu-id="028e6-2342">F16B</span><span class="sxs-lookup"><span data-stu-id="028e6-2342">F16B</span></span></td>
  <td><span data-ttu-id="028e6-2343">Checkbox14</span><span class="sxs-lookup"><span data-stu-id="028e6-2343">Checkbox14</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16C.png" width="32" height="32" alt="CheckboxComposite14" /></td>
  <td><span data-ttu-id="028e6-2344">F16C</span><span class="sxs-lookup"><span data-stu-id="028e6-2344">F16C</span></span></td>
  <td><span data-ttu-id="028e6-2345">CheckboxComposite14</span><span class="sxs-lookup"><span data-stu-id="028e6-2345">CheckboxComposite14</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16D.png" width="32" height="32" alt="CheckboxIndeterminateCombo14" /></td>
  <td><span data-ttu-id="028e6-2346">F16D</span><span class="sxs-lookup"><span data-stu-id="028e6-2346">F16D</span></span></td>
  <td><span data-ttu-id="028e6-2347">CheckboxIndeterminateCombo14</span><span class="sxs-lookup"><span data-stu-id="028e6-2347">CheckboxIndeterminateCombo14</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16E.png" width="32" height="32" alt="CheckboxIndeterminateCombo" /></td>
  <td><span data-ttu-id="028e6-2348">F16E</span><span class="sxs-lookup"><span data-stu-id="028e6-2348">F16E</span></span></td>
  <td><span data-ttu-id="028e6-2349">CheckboxIndeterminateCombo</span><span class="sxs-lookup"><span data-stu-id="028e6-2349">CheckboxIndeterminateCombo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F175.png" width="32" height="32" alt="StatusPause7" /></td>
  <td><span data-ttu-id="028e6-2350">F175</span><span class="sxs-lookup"><span data-stu-id="028e6-2350">F175</span></span></td>
  <td><span data-ttu-id="028e6-2351">StatusPause7</span><span class="sxs-lookup"><span data-stu-id="028e6-2351">StatusPause7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F17F.png" width="32" height="32" alt="CharacterAppearance" /></td>
  <td><span data-ttu-id="028e6-2352">F17F</span><span class="sxs-lookup"><span data-stu-id="028e6-2352">F17F</span></span></td>
  <td><span data-ttu-id="028e6-2353">CharacterAppearance</span><span class="sxs-lookup"><span data-stu-id="028e6-2353">CharacterAppearance</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F180.png" width="32" height="32" alt="Lexicon " /></td>
  <td><span data-ttu-id="028e6-2354">F180</span><span class="sxs-lookup"><span data-stu-id="028e6-2354">F180</span></span></td>
  <td><span data-ttu-id="028e6-2355">Lexicon</span><span class="sxs-lookup"><span data-stu-id="028e6-2355">Lexicon</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/F182.png" width="32" height="32" alt="ScreenTime" /></td>
  <td><span data-ttu-id="028e6-2356">F182</span><span class="sxs-lookup"><span data-stu-id="028e6-2356">F182</span></span></td>
  <td><span data-ttu-id="028e6-2357">ScreenTime</span><span class="sxs-lookup"><span data-stu-id="028e6-2357">ScreenTime</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F191.png" width="32" height="32" alt="HeadlessDevice" /></td>
  <td><span data-ttu-id="028e6-2358">F191</span><span class="sxs-lookup"><span data-stu-id="028e6-2358">F191</span></span></td>
  <td><span data-ttu-id="028e6-2359">HeadlessDevice</span><span class="sxs-lookup"><span data-stu-id="028e6-2359">HeadlessDevice</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F193.png" width="32" height="32" alt="NetworkSharing" /></td>
  <td><span data-ttu-id="028e6-2360">F193</span><span class="sxs-lookup"><span data-stu-id="028e6-2360">F193</span></span></td>
  <td><span data-ttu-id="028e6-2361">NetworkSharing</span><span class="sxs-lookup"><span data-stu-id="028e6-2361">NetworkSharing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F19D.png" width="32" height="32" alt="EyeGaze" /></td>
  <td><span data-ttu-id="028e6-2362">F19D</span><span class="sxs-lookup"><span data-stu-id="028e6-2362">F19D</span></span></td>
  <td><span data-ttu-id="028e6-2363">EyeGaze</span><span class="sxs-lookup"><span data-stu-id="028e6-2363">EyeGaze</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1AD.png" width="32" height="32" alt="WindowsInsider" /></td>
  <td><span data-ttu-id="028e6-2364">F1AD</span><span class="sxs-lookup"><span data-stu-id="028e6-2364">F1AD</span></span></td>
  <td><span data-ttu-id="028e6-2365">WindowsInsider</span><span class="sxs-lookup"><span data-stu-id="028e6-2365">WindowsInsider</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1CB.png" width="32" height="32" alt="ChromeSwitch" /></td>
  <td><span data-ttu-id="028e6-2366">F1CB</span><span class="sxs-lookup"><span data-stu-id="028e6-2366">F1CB</span></span></td>
  <td><span data-ttu-id="028e6-2367">ChromeSwitch</span><span class="sxs-lookup"><span data-stu-id="028e6-2367">ChromeSwitch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1CC.png" width="32" height="32" alt="ChromeSwitchContast" /></td>
  <td><span data-ttu-id="028e6-2368">F1CC</span><span class="sxs-lookup"><span data-stu-id="028e6-2368">F1CC</span></span></td>
  <td><span data-ttu-id="028e6-2369">ChromeSwitchContast</span><span class="sxs-lookup"><span data-stu-id="028e6-2369">ChromeSwitchContast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1D8.png" width="32" height="32" alt="StatusCheckmark" /></td>
  <td><span data-ttu-id="028e6-2370">F1D8</span><span class="sxs-lookup"><span data-stu-id="028e6-2370">F1D8</span></span></td>
  <td><span data-ttu-id="028e6-2371">StatusCheckmark</span><span class="sxs-lookup"><span data-stu-id="028e6-2371">StatusCheckmark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1D9.png" width="32" height="32" alt="StatusCheckmarkLeft" /></td>
  <td><span data-ttu-id="028e6-2372">F1D9</span><span class="sxs-lookup"><span data-stu-id="028e6-2372">F1D9</span></span></td>
  <td><span data-ttu-id="028e6-2373">StatusCheckmarkLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2373">StatusCheckmarkLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F20C.png" width="32" height="32" alt="KeyboardLeftAligned" /></td>
  <td><span data-ttu-id="028e6-2374">F20C</span><span class="sxs-lookup"><span data-stu-id="028e6-2374">F20C</span></span></td>
  <td><span data-ttu-id="028e6-2375">KeyboardLeftAligned</span><span class="sxs-lookup"><span data-stu-id="028e6-2375">KeyboardLeftAligned</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F20D.png" width="32" height="32" alt="KeyboardRightAligned" /></td>
  <td><span data-ttu-id="028e6-2376">F20D</span><span class="sxs-lookup"><span data-stu-id="028e6-2376">F20D</span></span></td>
  <td><span data-ttu-id="028e6-2377">KeyboardRightAligned</span><span class="sxs-lookup"><span data-stu-id="028e6-2377">KeyboardRightAligned</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F210.png" width="32" height="32" alt="KeyboardSettings" /></td>
  <td><span data-ttu-id="028e6-2378">F210</span><span class="sxs-lookup"><span data-stu-id="028e6-2378">F210</span></span></td>
  <td><span data-ttu-id="028e6-2379">KeyboardSettings</span><span class="sxs-lookup"><span data-stu-id="028e6-2379">KeyboardSettings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F22C.png" width="32" height="32" alt="IOT" /></td>
  <td><span data-ttu-id="028e6-2380">F22C</span><span class="sxs-lookup"><span data-stu-id="028e6-2380">F22C</span></span></td>
  <td><span data-ttu-id="028e6-2381">IOT</span><span class="sxs-lookup"><span data-stu-id="028e6-2381">IOT</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F22E.png" width="32" height="32" alt="UnknownMirrored" /></td>
  <td><span data-ttu-id="028e6-2382">F22E</span><span class="sxs-lookup"><span data-stu-id="028e6-2382">F22E</span></span></td>
  <td><span data-ttu-id="028e6-2383">UnknownMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2383">UnknownMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F246.png" width="32" height="32" alt="ViewDashboard" /></td>
  <td><span data-ttu-id="028e6-2384">F246</span><span class="sxs-lookup"><span data-stu-id="028e6-2384">F246</span></span></td>
  <td><span data-ttu-id="028e6-2385">ViewDashboard</span><span class="sxs-lookup"><span data-stu-id="028e6-2385">ViewDashboard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F259.png" width="32" height="32" alt="ExploitProtectionSettings" /></td>
  <td><span data-ttu-id="028e6-2386">F259</span><span class="sxs-lookup"><span data-stu-id="028e6-2386">F259</span></span></td>
  <td><span data-ttu-id="028e6-2387">ExploitProtectionSettings</span><span class="sxs-lookup"><span data-stu-id="028e6-2387">ExploitProtectionSettings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F260.png" width="32" height="32" alt="KeyboardNarrow" /></td>
  <td><span data-ttu-id="028e6-2388">F260</span><span class="sxs-lookup"><span data-stu-id="028e6-2388">F260</span></span></td>
  <td><span data-ttu-id="028e6-2389">KeyboardNarrow</span><span class="sxs-lookup"><span data-stu-id="028e6-2389">KeyboardNarrow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F261.png" width="32" height="32" alt="Keyboard12Key" /></td>
  <td><span data-ttu-id="028e6-2390">F261</span><span class="sxs-lookup"><span data-stu-id="028e6-2390">F261</span></span></td>
  <td><span data-ttu-id="028e6-2391">Keyboard12Key</span><span class="sxs-lookup"><span data-stu-id="028e6-2391">Keyboard12Key</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F26B.png" width="32" height="32" alt="KeyboardDock" /></td>
  <td><span data-ttu-id="028e6-2392">F26B</span><span class="sxs-lookup"><span data-stu-id="028e6-2392">F26B</span></span></td>
  <td><span data-ttu-id="028e6-2393">KeyboardDock</span><span class="sxs-lookup"><span data-stu-id="028e6-2393">KeyboardDock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F26C.png" width="32" height="32" alt="KeyboardUndock" /></td>
  <td><span data-ttu-id="028e6-2394">F26C</span><span class="sxs-lookup"><span data-stu-id="028e6-2394">F26C</span></span></td>
  <td><span data-ttu-id="028e6-2395">KeyboardUndock</span><span class="sxs-lookup"><span data-stu-id="028e6-2395">KeyboardUndock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F26D.png" width="32" height="32" alt="KeyboardLeftDock" /></td>
  <td><span data-ttu-id="028e6-2396">F26D</span><span class="sxs-lookup"><span data-stu-id="028e6-2396">F26D</span></span></td>
  <td><span data-ttu-id="028e6-2397">KeyboardLeftDock</span><span class="sxs-lookup"><span data-stu-id="028e6-2397">KeyboardLeftDock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F26E.png" width="32" height="32" alt="KeyboardRightDock" /></td>
  <td><span data-ttu-id="028e6-2398">F26E</span><span class="sxs-lookup"><span data-stu-id="028e6-2398">F26E</span></span></td>
  <td><span data-ttu-id="028e6-2399">KeyboardRightDock</span><span class="sxs-lookup"><span data-stu-id="028e6-2399">KeyboardRightDock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F270.png" width="32" height="32" alt="Ear" /></td>
  <td><span data-ttu-id="028e6-2400">F270</span><span class="sxs-lookup"><span data-stu-id="028e6-2400">F270</span></span></td>
  <td><span data-ttu-id="028e6-2401">Ear</span><span class="sxs-lookup"><span data-stu-id="028e6-2401">Ear</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F271.png" width="32" height="32" alt="PointerHand" /></td>
  <td><span data-ttu-id="028e6-2402">F271</span><span class="sxs-lookup"><span data-stu-id="028e6-2402">F271</span></span></td>
  <td><span data-ttu-id="028e6-2403">PointerHand</span><span class="sxs-lookup"><span data-stu-id="028e6-2403">PointerHand</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F272.png" width="32" height="32" alt="Bullseye" /></td>
  <td><span data-ttu-id="028e6-2404">F272</span><span class="sxs-lookup"><span data-stu-id="028e6-2404">F272</span></span></td>
  <td><span data-ttu-id="028e6-2405">Bullseye</span><span class="sxs-lookup"><span data-stu-id="028e6-2405">Bullseye</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F32A.png" width="32" height="32" alt="PassiveAuthentication" /></td>
  <td><span data-ttu-id="028e6-2406">F32A</span><span class="sxs-lookup"><span data-stu-id="028e6-2406">F32A</span></span></td>
  <td><span data-ttu-id="028e6-2407">PassiveAuthentication</span><span class="sxs-lookup"><span data-stu-id="028e6-2407">PassiveAuthentication</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F384.png" width="32" height="32" alt="NetworkOffline" /></td>
  <td><span data-ttu-id="028e6-2408">F384</span><span class="sxs-lookup"><span data-stu-id="028e6-2408">F384</span></span></td>
  <td><span data-ttu-id="028e6-2409">NetworkOffline</span><span class="sxs-lookup"><span data-stu-id="028e6-2409">NetworkOffline</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F385.png" width="32" height="32" alt="NetworkConnected" /></td>
  <td><span data-ttu-id="028e6-2410">F385</span><span class="sxs-lookup"><span data-stu-id="028e6-2410">F385</span></span></td>
  <td><span data-ttu-id="028e6-2411">NetworkConnected</span><span class="sxs-lookup"><span data-stu-id="028e6-2411">NetworkConnected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F386.png" width="32" height="32" alt="NetworkConnectedCheckmark" /></td>
  <td><span data-ttu-id="028e6-2412">F386</span><span class="sxs-lookup"><span data-stu-id="028e6-2412">F386</span></span></td>
  <td><span data-ttu-id="028e6-2413">NetworkConnectedCheckmark</span><span class="sxs-lookup"><span data-stu-id="028e6-2413">NetworkConnectedCheckmark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F3CC.png" width="32" height="32" alt="StatusInfo" /></td>
  <td><span data-ttu-id="028e6-2414">F3CC</span><span class="sxs-lookup"><span data-stu-id="028e6-2414">F3CC</span></span></td>
  <td><span data-ttu-id="028e6-2415">StatusInfo</span><span class="sxs-lookup"><span data-stu-id="028e6-2415">StatusInfo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F3CD.png" width="32" height="32" alt="StatusInfoLeft" /></td>
  <td><span data-ttu-id="028e6-2416">F3CD</span><span class="sxs-lookup"><span data-stu-id="028e6-2416">F3CD</span></span></td>
  <td><span data-ttu-id="028e6-2417">StatusInfoLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2417">StatusInfoLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F3E2.png" width="32" height="32" alt="NearbySharing" /></td>
  <td><span data-ttu-id="028e6-2418">F3E2</span><span class="sxs-lookup"><span data-stu-id="028e6-2418">F3E2</span></span></td>
  <td><span data-ttu-id="028e6-2419">NearbySharing</span><span class="sxs-lookup"><span data-stu-id="028e6-2419">NearbySharing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F3E7.png" width="32" height="32" alt="CtrlSpatialLeft" /></td>
  <td><span data-ttu-id="028e6-2420">F3E7</span><span class="sxs-lookup"><span data-stu-id="028e6-2420">F3E7</span></span></td>
  <td><span data-ttu-id="028e6-2421">CtrlSpatialLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2421">CtrlSpatialLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F404.png" width="32" height="32" alt="InteractiveDashboard" /></td>
  <td><span data-ttu-id="028e6-2422">F404</span><span class="sxs-lookup"><span data-stu-id="028e6-2422">F404</span></span></td>
  <td><span data-ttu-id="028e6-2423">InteractiveDashboard</span><span class="sxs-lookup"><span data-stu-id="028e6-2423">InteractiveDashboard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F406.png" width="32" height="32" alt="ClippingTool" /></td>
  <td><span data-ttu-id="028e6-2424">F406</span><span class="sxs-lookup"><span data-stu-id="028e6-2424">F406</span></span></td>
  <td><span data-ttu-id="028e6-2425">ClippingTool</span><span class="sxs-lookup"><span data-stu-id="028e6-2425">ClippingTool</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F407.png" width="32" height="32" alt="RectangularClipping " /></td>
  <td><span data-ttu-id="028e6-2426">F407</span><span class="sxs-lookup"><span data-stu-id="028e6-2426">F407</span></span></td>
  <td><span data-ttu-id="028e6-2427">RectangularClipping</span><span class="sxs-lookup"><span data-stu-id="028e6-2427">RectangularClipping</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/F408.png" width="32" height="32" alt="FreeFormClipping" /></td>
  <td><span data-ttu-id="028e6-2428">F408</span><span class="sxs-lookup"><span data-stu-id="028e6-2428">F408</span></span></td>
  <td><span data-ttu-id="028e6-2429">FreeFormClipping</span><span class="sxs-lookup"><span data-stu-id="028e6-2429">FreeFormClipping</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F413.png" width="32" height="32" alt="CopyTo" /></td>
  <td><span data-ttu-id="028e6-2430">F413</span><span class="sxs-lookup"><span data-stu-id="028e6-2430">F413</span></span></td>
  <td><span data-ttu-id="028e6-2431">CopyTo</span><span class="sxs-lookup"><span data-stu-id="028e6-2431">CopyTo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F439.png" width="32" height="32" alt="DynamicLock" /></td>
  <td><span data-ttu-id="028e6-2432">F439</span><span class="sxs-lookup"><span data-stu-id="028e6-2432">F439</span></span></td>
  <td><span data-ttu-id="028e6-2433">DynamicLock</span><span class="sxs-lookup"><span data-stu-id="028e6-2433">DynamicLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F45E.png" width="32" height="32" alt="PenTips" /></td>
  <td><span data-ttu-id="028e6-2434">F45E</span><span class="sxs-lookup"><span data-stu-id="028e6-2434">F45E</span></span></td>
  <td><span data-ttu-id="028e6-2435">PenTips</span><span class="sxs-lookup"><span data-stu-id="028e6-2435">PenTips</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F45F.png" width="32" height="32" alt="PenTipsMirrored" /></td>
  <td><span data-ttu-id="028e6-2436">F45F</span><span class="sxs-lookup"><span data-stu-id="028e6-2436">F45F</span></span></td>
  <td><span data-ttu-id="028e6-2437">PenTipsMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2437">PenTipsMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F460.png" width="32" height="32" alt="HWPJoin" /></td>
  <td><span data-ttu-id="028e6-2438">F460</span><span class="sxs-lookup"><span data-stu-id="028e6-2438">F460</span></span></td>
  <td><span data-ttu-id="028e6-2439">HWPJoin</span><span class="sxs-lookup"><span data-stu-id="028e6-2439">HWPJoin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F461.png" width="32" height="32" alt="HWPInsert" /></td>
  <td><span data-ttu-id="028e6-2440">F461</span><span class="sxs-lookup"><span data-stu-id="028e6-2440">F461</span></span></td>
  <td><span data-ttu-id="028e6-2441">HWPInsert</span><span class="sxs-lookup"><span data-stu-id="028e6-2441">HWPInsert</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F462.png" width="32" height="32" alt="HWPStrikeThrough" /></td>
  <td><span data-ttu-id="028e6-2442">F462</span><span class="sxs-lookup"><span data-stu-id="028e6-2442">F462</span></span></td>
  <td><span data-ttu-id="028e6-2443">HWPStrikeThrough</span><span class="sxs-lookup"><span data-stu-id="028e6-2443">HWPStrikeThrough</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F463.png" width="32" height="32" alt="HWPScratchOut" /></td>
  <td><span data-ttu-id="028e6-2444">F463</span><span class="sxs-lookup"><span data-stu-id="028e6-2444">F463</span></span></td>
  <td><span data-ttu-id="028e6-2445">HWPScratchOut</span><span class="sxs-lookup"><span data-stu-id="028e6-2445">HWPScratchOut</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F464.png" width="32" height="32" alt="HWPSplit" /></td>
  <td><span data-ttu-id="028e6-2446">F464</span><span class="sxs-lookup"><span data-stu-id="028e6-2446">F464</span></span></td>
  <td><span data-ttu-id="028e6-2447">HWPSplit</span><span class="sxs-lookup"><span data-stu-id="028e6-2447">HWPSplit</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F465.png" width="32" height="32" alt="HWPNewLine" /></td>
  <td><span data-ttu-id="028e6-2448">F465</span><span class="sxs-lookup"><span data-stu-id="028e6-2448">F465</span></span></td>
  <td><span data-ttu-id="028e6-2449">HWPNewLine</span><span class="sxs-lookup"><span data-stu-id="028e6-2449">HWPNewLine</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F466.png" width="32" height="32" alt="HWPOverwrite" /></td>
  <td><span data-ttu-id="028e6-2450">F466</span><span class="sxs-lookup"><span data-stu-id="028e6-2450">F466</span></span></td>
  <td><span data-ttu-id="028e6-2451">HWPOverwrite</span><span class="sxs-lookup"><span data-stu-id="028e6-2451">HWPOverwrite</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F473.png" width="32" height="32" alt="MobWifiWarning1" /></td>
  <td><span data-ttu-id="028e6-2452">F473</span><span class="sxs-lookup"><span data-stu-id="028e6-2452">F473</span></span></td>
  <td><span data-ttu-id="028e6-2453">MobWifiWarning1</span><span class="sxs-lookup"><span data-stu-id="028e6-2453">MobWifiWarning1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F474.png" width="32" height="32" alt="MobWifiWarning2" /></td>
  <td><span data-ttu-id="028e6-2454">F474</span><span class="sxs-lookup"><span data-stu-id="028e6-2454">F474</span></span></td>
  <td><span data-ttu-id="028e6-2455">MobWifiWarning2</span><span class="sxs-lookup"><span data-stu-id="028e6-2455">MobWifiWarning2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F475.png" width="32" height="32" alt="MobWifiWarning3" /></td>
  <td><span data-ttu-id="028e6-2456">F475</span><span class="sxs-lookup"><span data-stu-id="028e6-2456">F475</span></span></td>
  <td><span data-ttu-id="028e6-2457">MobWifiWarning3</span><span class="sxs-lookup"><span data-stu-id="028e6-2457">MobWifiWarning3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F476.png" width="32" height="32" alt="MobWifiWarning4" /></td>
  <td><span data-ttu-id="028e6-2458">F476</span><span class="sxs-lookup"><span data-stu-id="028e6-2458">F476</span></span></td>
  <td><span data-ttu-id="028e6-2459">MobWifiWarning4</span><span class="sxs-lookup"><span data-stu-id="028e6-2459">MobWifiWarning4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4A9.png" width="32" height="32" alt="GIF" /></td>
  <td><span data-ttu-id="028e6-2460">F4A9</span><span class="sxs-lookup"><span data-stu-id="028e6-2460">F4A9</span></span></td>
  <td><span data-ttu-id="028e6-2461">GIF</span><span class="sxs-lookup"><span data-stu-id="028e6-2461">GIF</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4AA.png" width="32" height="32" alt="Sticker2" /></td>
  <td><span data-ttu-id="028e6-2462">F4AA</span><span class="sxs-lookup"><span data-stu-id="028e6-2462">F4AA</span></span></td>
  <td><span data-ttu-id="028e6-2463">Sticker2</span><span class="sxs-lookup"><span data-stu-id="028e6-2463">Sticker2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4BE.png" width="32" height="32" alt="SurfaceHubSelected" /></td>
  <td><span data-ttu-id="028e6-2464">F4BE</span><span class="sxs-lookup"><span data-stu-id="028e6-2464">F4BE</span></span></td>
  <td><span data-ttu-id="028e6-2465">SurfaceHubSelected</span><span class="sxs-lookup"><span data-stu-id="028e6-2465">SurfaceHubSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4BF.png" width="32" height="32" alt="HoloLensSelected" /></td>
  <td><span data-ttu-id="028e6-2466">F4BF</span><span class="sxs-lookup"><span data-stu-id="028e6-2466">F4BF</span></span></td>
  <td><span data-ttu-id="028e6-2467">HoloLensSelected</span><span class="sxs-lookup"><span data-stu-id="028e6-2467">HoloLensSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4C0.png" width="32" height="32" alt="Earbud" /></td>
  <td><span data-ttu-id="028e6-2468">F4C0</span><span class="sxs-lookup"><span data-stu-id="028e6-2468">F4C0</span></span></td>
  <td><span data-ttu-id="028e6-2469">イヤホン</span><span class="sxs-lookup"><span data-stu-id="028e6-2469">Earbud</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4C3.png" width="32" height="32" alt="MixVolumes" /></td>
  <td><span data-ttu-id="028e6-2470">F4C3</span><span class="sxs-lookup"><span data-stu-id="028e6-2470">F4C3</span></span></td>
  <td><span data-ttu-id="028e6-2471">MixVolumes</span><span class="sxs-lookup"><span data-stu-id="028e6-2471">MixVolumes</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F540.png" width="32" height="32" alt="Safe" /></td>
  <td><span data-ttu-id="028e6-2472">F540</span><span class="sxs-lookup"><span data-stu-id="028e6-2472">F540</span></span></td>
  <td><span data-ttu-id="028e6-2473">セーフ</span><span class="sxs-lookup"><span data-stu-id="028e6-2473">Safe</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F552.png" width="32" height="32" alt="LaptopSecure" /></td>
  <td><span data-ttu-id="028e6-2474">F552</span><span class="sxs-lookup"><span data-stu-id="028e6-2474">F552</span></span></td>
  <td><span data-ttu-id="028e6-2475">LaptopSecure</span><span class="sxs-lookup"><span data-stu-id="028e6-2475">LaptopSecure</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F56D.png" width="32" height="32" alt="PrintDefault" /></td>
  <td><span data-ttu-id="028e6-2476">F56D</span><span class="sxs-lookup"><span data-stu-id="028e6-2476">F56D</span></span></td>
  <td><span data-ttu-id="028e6-2477">PrintDefault</span><span class="sxs-lookup"><span data-stu-id="028e6-2477">PrintDefault</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F56E.png" width="32" height="32" alt="PageMirrored" /></td>
  <td><span data-ttu-id="028e6-2478">F56E</span><span class="sxs-lookup"><span data-stu-id="028e6-2478">F56E</span></span></td>
  <td><span data-ttu-id="028e6-2479">PageMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2479">PageMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F56F.png" width="32" height="32" alt="LandscapeOrientationMirrored" /></td>
  <td><span data-ttu-id="028e6-2480">F56F</span><span class="sxs-lookup"><span data-stu-id="028e6-2480">F56F</span></span></td>
  <td><span data-ttu-id="028e6-2481">LandscapeOrientationMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2481">LandscapeOrientationMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F570.png" width="32" height="32" alt="ColorOff" /></td>
  <td><span data-ttu-id="028e6-2482">F570</span><span class="sxs-lookup"><span data-stu-id="028e6-2482">F570</span></span></td>
  <td><span data-ttu-id="028e6-2483">ColorOff</span><span class="sxs-lookup"><span data-stu-id="028e6-2483">ColorOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F571.png" width="32" height="32" alt="PrintAllPages" /></td>
  <td><span data-ttu-id="028e6-2484">F571</span><span class="sxs-lookup"><span data-stu-id="028e6-2484">F571</span></span></td>
  <td><span data-ttu-id="028e6-2485">PrintAllPages</span><span class="sxs-lookup"><span data-stu-id="028e6-2485">PrintAllPages</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F572.png" width="32" height="32" alt="PrintCustomRange" /></td>
  <td><span data-ttu-id="028e6-2486">F572</span><span class="sxs-lookup"><span data-stu-id="028e6-2486">F572</span></span></td>
  <td><span data-ttu-id="028e6-2487">PrintCustomRange</span><span class="sxs-lookup"><span data-stu-id="028e6-2487">PrintCustomRange</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F573.png" width="32" height="32" alt="PageMarginPortraitNarrow" /></td>
  <td><span data-ttu-id="028e6-2488">F573</span><span class="sxs-lookup"><span data-stu-id="028e6-2488">F573</span></span></td>
  <td><span data-ttu-id="028e6-2489">PageMarginPortraitNarrow</span><span class="sxs-lookup"><span data-stu-id="028e6-2489">PageMarginPortraitNarrow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F574.png" width="32" height="32" alt="PageMarginPortraitNormal" /></td>
  <td><span data-ttu-id="028e6-2490">F574</span><span class="sxs-lookup"><span data-stu-id="028e6-2490">F574</span></span></td>
  <td><span data-ttu-id="028e6-2491">PageMarginPortraitNormal</span><span class="sxs-lookup"><span data-stu-id="028e6-2491">PageMarginPortraitNormal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F575.png" width="32" height="32" alt="PageMarginPortraitModerate" /></td>
  <td><span data-ttu-id="028e6-2492">F575</span><span class="sxs-lookup"><span data-stu-id="028e6-2492">F575</span></span></td>
  <td><span data-ttu-id="028e6-2493">PageMarginPortraitModerate</span><span class="sxs-lookup"><span data-stu-id="028e6-2493">PageMarginPortraitModerate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F576.png" width="32" height="32" alt="PageMarginPortraitWide" /></td>
  <td><span data-ttu-id="028e6-2494">F576</span><span class="sxs-lookup"><span data-stu-id="028e6-2494">F576</span></span></td>
  <td><span data-ttu-id="028e6-2495">PageMarginPortraitWide</span><span class="sxs-lookup"><span data-stu-id="028e6-2495">PageMarginPortraitWide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F577.png" width="32" height="32" alt="PageMarginLandscapeNarrow" /></td>
  <td><span data-ttu-id="028e6-2496">F577</span><span class="sxs-lookup"><span data-stu-id="028e6-2496">F577</span></span></td>
  <td><span data-ttu-id="028e6-2497">PageMarginLandscapeNarrow</span><span class="sxs-lookup"><span data-stu-id="028e6-2497">PageMarginLandscapeNarrow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F578.png" width="32" height="32" alt="PageMarginLandscapeNormal" /></td>
  <td><span data-ttu-id="028e6-2498">F578</span><span class="sxs-lookup"><span data-stu-id="028e6-2498">F578</span></span></td>
  <td><span data-ttu-id="028e6-2499">PageMarginLandscapeNormal</span><span class="sxs-lookup"><span data-stu-id="028e6-2499">PageMarginLandscapeNormal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F579.png" width="32" height="32" alt="PageMarginLandscapeModerate" /></td>
  <td><span data-ttu-id="028e6-2500">F579</span><span class="sxs-lookup"><span data-stu-id="028e6-2500">F579</span></span></td>
  <td><span data-ttu-id="028e6-2501">PageMarginLandscapeModerate</span><span class="sxs-lookup"><span data-stu-id="028e6-2501">PageMarginLandscapeModerate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57A.png" width="32" height="32" alt="PageMarginLandscapeWide" /></td>
  <td><span data-ttu-id="028e6-2502">F57A</span><span class="sxs-lookup"><span data-stu-id="028e6-2502">F57A</span></span></td>
  <td><span data-ttu-id="028e6-2503">PageMarginLandscapeWide</span><span class="sxs-lookup"><span data-stu-id="028e6-2503">PageMarginLandscapeWide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57B.png" width="32" height="32" alt="CollateLandscape" /></td>
  <td><span data-ttu-id="028e6-2504">F57B</span><span class="sxs-lookup"><span data-stu-id="028e6-2504">F57B</span></span></td>
  <td><span data-ttu-id="028e6-2505">CollateLandscape</span><span class="sxs-lookup"><span data-stu-id="028e6-2505">CollateLandscape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57C.png" width="32" height="32" alt="CollatePortrait" /></td>
  <td><span data-ttu-id="028e6-2506">F57C</span><span class="sxs-lookup"><span data-stu-id="028e6-2506">F57C</span></span></td>
  <td><span data-ttu-id="028e6-2507">CollatePortrait</span><span class="sxs-lookup"><span data-stu-id="028e6-2507">CollatePortrait</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57D.png" width="32" height="32" alt="CollatePortraitSeparated" /></td>
  <td><span data-ttu-id="028e6-2508">F57D</span><span class="sxs-lookup"><span data-stu-id="028e6-2508">F57D</span></span></td>
  <td><span data-ttu-id="028e6-2509">CollatePortraitSeparated</span><span class="sxs-lookup"><span data-stu-id="028e6-2509">CollatePortraitSeparated</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57E.png" width="32" height="32" alt="DuplexLandscapeOneSided" /></td>
  <td><span data-ttu-id="028e6-2510">F57E</span><span class="sxs-lookup"><span data-stu-id="028e6-2510">F57E</span></span></td>
  <td><span data-ttu-id="028e6-2511">DuplexLandscapeOneSided</span><span class="sxs-lookup"><span data-stu-id="028e6-2511">DuplexLandscapeOneSided</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57F.png" width="32" height="32" alt="DuplexLandscapeOneSidedMirrored" /></td>
  <td><span data-ttu-id="028e6-2512">F57F</span><span class="sxs-lookup"><span data-stu-id="028e6-2512">F57F</span></span></td>
  <td><span data-ttu-id="028e6-2513">DuplexLandscapeOneSidedMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2513">DuplexLandscapeOneSidedMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F580.png" width="32" height="32" alt="DuplexLandscapeTwoSidedLongEdge" /></td>
  <td><span data-ttu-id="028e6-2514">F580</span><span class="sxs-lookup"><span data-stu-id="028e6-2514">F580</span></span></td>
  <td><span data-ttu-id="028e6-2515">DuplexLandscapeTwoSidedLongEdge</span><span class="sxs-lookup"><span data-stu-id="028e6-2515">DuplexLandscapeTwoSidedLongEdge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F581.png" width="32" height="32" alt="DuplexLandscapeTwoSidedLongEdgeMirrored" /></td>
  <td><span data-ttu-id="028e6-2516">F581</span><span class="sxs-lookup"><span data-stu-id="028e6-2516">F581</span></span></td>
  <td><span data-ttu-id="028e6-2517">DuplexLandscapeTwoSidedLongEdgeMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2517">DuplexLandscapeTwoSidedLongEdgeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F582.png" width="32" height="32" alt="DuplexLandscapeTwoSidedShortEdge" /></td>
  <td><span data-ttu-id="028e6-2518">F582</span><span class="sxs-lookup"><span data-stu-id="028e6-2518">F582</span></span></td>
  <td><span data-ttu-id="028e6-2519">DuplexLandscapeTwoSidedShortEdge</span><span class="sxs-lookup"><span data-stu-id="028e6-2519">DuplexLandscapeTwoSidedShortEdge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F583.png" width="32" height="32" alt="DuplexLandscapeTwoSidedShortEdgeMirrored" /></td>
  <td><span data-ttu-id="028e6-2520">F583</span><span class="sxs-lookup"><span data-stu-id="028e6-2520">F583</span></span></td>
  <td><span data-ttu-id="028e6-2521">DuplexLandscapeTwoSidedShortEdgeMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2521">DuplexLandscapeTwoSidedShortEdgeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F584.png" width="32" height="32" alt="DuplexPortraitOneSided" /></td>
  <td><span data-ttu-id="028e6-2522">F584</span><span class="sxs-lookup"><span data-stu-id="028e6-2522">F584</span></span></td>
  <td><span data-ttu-id="028e6-2523">DuplexPortraitOneSided</span><span class="sxs-lookup"><span data-stu-id="028e6-2523">DuplexPortraitOneSided</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F585.png" width="32" height="32" alt="DuplexPortraitOneSidedMirrored" /></td>
  <td><span data-ttu-id="028e6-2524">F585</span><span class="sxs-lookup"><span data-stu-id="028e6-2524">F585</span></span></td>
  <td><span data-ttu-id="028e6-2525">DuplexPortraitOneSidedMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2525">DuplexPortraitOneSidedMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F586.png" width="32" height="32" alt="DuplexPortraitTwoSidedLongEdge" /></td>
  <td><span data-ttu-id="028e6-2526">F586</span><span class="sxs-lookup"><span data-stu-id="028e6-2526">F586</span></span></td>
  <td><span data-ttu-id="028e6-2527">DuplexPortraitTwoSidedLongEdge</span><span class="sxs-lookup"><span data-stu-id="028e6-2527">DuplexPortraitTwoSidedLongEdge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F587.png" width="32" height="32" alt="DuplexPortraitTwoSidedLongEdgeMirrored" /></td>
  <td><span data-ttu-id="028e6-2528">F587</span><span class="sxs-lookup"><span data-stu-id="028e6-2528">F587</span></span></td>
  <td><span data-ttu-id="028e6-2529">DuplexPortraitTwoSidedLongEdgeMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2529">DuplexPortraitTwoSidedLongEdgeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F588.png" width="32" height="32" alt="DuplexPortraitTwoSidedShortEdge" /></td>
  <td><span data-ttu-id="028e6-2530">F588</span><span class="sxs-lookup"><span data-stu-id="028e6-2530">F588</span></span></td>
  <td><span data-ttu-id="028e6-2531">DuplexPortraitTwoSidedShortEdge</span><span class="sxs-lookup"><span data-stu-id="028e6-2531">DuplexPortraitTwoSidedShortEdge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F589.png" width="32" height="32" alt="DuplexPortraitTwoSidedShortEdgeMirrored" /></td>
  <td><span data-ttu-id="028e6-2532">F589</span><span class="sxs-lookup"><span data-stu-id="028e6-2532">F589</span></span></td>
  <td><span data-ttu-id="028e6-2533">DuplexPortraitTwoSidedShortEdgeMirrored</span><span class="sxs-lookup"><span data-stu-id="028e6-2533">DuplexPortraitTwoSidedShortEdgeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58A.png" width="32" height="32" alt="PPSOneLandscape" /></td>
  <td><span data-ttu-id="028e6-2534">F58A</span><span class="sxs-lookup"><span data-stu-id="028e6-2534">F58A</span></span></td>
  <td><span data-ttu-id="028e6-2535">PPSOneLandscape</span><span class="sxs-lookup"><span data-stu-id="028e6-2535">PPSOneLandscape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58B.png" width="32" height="32" alt="PPSTwoLandscape" /></td>
  <td><span data-ttu-id="028e6-2536">F58B</span><span class="sxs-lookup"><span data-stu-id="028e6-2536">F58B</span></span></td>
  <td><span data-ttu-id="028e6-2537">PPSTwoLandscape</span><span class="sxs-lookup"><span data-stu-id="028e6-2537">PPSTwoLandscape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58C.png" width="32" height="32" alt="PPSTwoPortrait" /></td>
  <td><span data-ttu-id="028e6-2538">F58C</span><span class="sxs-lookup"><span data-stu-id="028e6-2538">F58C</span></span></td>
  <td><span data-ttu-id="028e6-2539">PPSTwoPortrait</span><span class="sxs-lookup"><span data-stu-id="028e6-2539">PPSTwoPortrait</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58D.png" width="32" height="32" alt="PPSFourLandscape" /></td>
  <td><span data-ttu-id="028e6-2540">F58D</span><span class="sxs-lookup"><span data-stu-id="028e6-2540">F58D</span></span></td>
  <td><span data-ttu-id="028e6-2541">PPSFourLandscape</span><span class="sxs-lookup"><span data-stu-id="028e6-2541">PPSFourLandscape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58E.png" width="32" height="32" alt="PPSFourPortrait" /></td>
  <td><span data-ttu-id="028e6-2542">F58E</span><span class="sxs-lookup"><span data-stu-id="028e6-2542">F58E</span></span></td>
  <td><span data-ttu-id="028e6-2543">PPSFourPortrait</span><span class="sxs-lookup"><span data-stu-id="028e6-2543">PPSFourPortrait</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58F.png" width="32" height="32" alt="HolePunchOff" /></td>
  <td><span data-ttu-id="028e6-2544">F58F</span><span class="sxs-lookup"><span data-stu-id="028e6-2544">F58F</span></span></td>
  <td><span data-ttu-id="028e6-2545">HolePunchOff</span><span class="sxs-lookup"><span data-stu-id="028e6-2545">HolePunchOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F590.png" width="32" height="32" alt="HolePunchPortraitLeft" /></td>
  <td><span data-ttu-id="028e6-2546">F590</span><span class="sxs-lookup"><span data-stu-id="028e6-2546">F590</span></span></td>
  <td><span data-ttu-id="028e6-2547">HolePunchPortraitLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2547">HolePunchPortraitLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F591.png" width="32" height="32" alt="HolePunchPortraitRight" /></td>
  <td><span data-ttu-id="028e6-2548">F591</span><span class="sxs-lookup"><span data-stu-id="028e6-2548">F591</span></span></td>
  <td><span data-ttu-id="028e6-2549">HolePunchPortraitRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2549">HolePunchPortraitRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F592.png" width="32" height="32" alt="HolePunchPortraitTop" /></td>
  <td><span data-ttu-id="028e6-2550">F592</span><span class="sxs-lookup"><span data-stu-id="028e6-2550">F592</span></span></td>
  <td><span data-ttu-id="028e6-2551">HolePunchPortraitTop</span><span class="sxs-lookup"><span data-stu-id="028e6-2551">HolePunchPortraitTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F593.png" width="32" height="32" alt="HolePunchPortraitBottom" /></td>
  <td><span data-ttu-id="028e6-2552">F593</span><span class="sxs-lookup"><span data-stu-id="028e6-2552">F593</span></span></td>
  <td><span data-ttu-id="028e6-2553">HolePunchPortraitBottom</span><span class="sxs-lookup"><span data-stu-id="028e6-2553">HolePunchPortraitBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F594.png" width="32" height="32" alt="HolePunchLandscapeLeft" /></td>
  <td><span data-ttu-id="028e6-2554">F594</span><span class="sxs-lookup"><span data-stu-id="028e6-2554">F594</span></span></td>
  <td><span data-ttu-id="028e6-2555">HolePunchLandscapeLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2555">HolePunchLandscapeLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F595.png" width="32" height="32" alt="HolePunchLandscapeRight" /></td>
  <td><span data-ttu-id="028e6-2556">F595</span><span class="sxs-lookup"><span data-stu-id="028e6-2556">F595</span></span></td>
  <td><span data-ttu-id="028e6-2557">HolePunchLandscapeRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2557">HolePunchLandscapeRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F596.png" width="32" height="32" alt="HolePunchLandscapeTop" /></td>
  <td><span data-ttu-id="028e6-2558">F596</span><span class="sxs-lookup"><span data-stu-id="028e6-2558">F596</span></span></td>
  <td><span data-ttu-id="028e6-2559">HolePunchLandscapeTop</span><span class="sxs-lookup"><span data-stu-id="028e6-2559">HolePunchLandscapeTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F597.png" width="32" height="32" alt="HolePunchLandscapeBottom" /></td>
  <td><span data-ttu-id="028e6-2560">F597</span><span class="sxs-lookup"><span data-stu-id="028e6-2560">F597</span></span></td>
  <td><span data-ttu-id="028e6-2561">HolePunchLandscapeBottom</span><span class="sxs-lookup"><span data-stu-id="028e6-2561">HolePunchLandscapeBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F598.png" width="32" height="32" alt="StaplingOff" /></td>
  <td><span data-ttu-id="028e6-2562">F598</span><span class="sxs-lookup"><span data-stu-id="028e6-2562">F598</span></span></td>
  <td><span data-ttu-id="028e6-2563">StaplingOff</span><span class="sxs-lookup"><span data-stu-id="028e6-2563">StaplingOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F599.png" width="32" height="32" alt="StaplingPortraitTopLeft" /></td>
  <td><span data-ttu-id="028e6-2564">F599</span><span class="sxs-lookup"><span data-stu-id="028e6-2564">F599</span></span></td>
  <td><span data-ttu-id="028e6-2565">StaplingPortraitTopLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2565">StaplingPortraitTopLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59A.png" width="32" height="32" alt="StaplingPortraitTopRight" /></td>
  <td><span data-ttu-id="028e6-2566">F59A</span><span class="sxs-lookup"><span data-stu-id="028e6-2566">F59A</span></span></td>
  <td><span data-ttu-id="028e6-2567">StaplingPortraitTopRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2567">StaplingPortraitTopRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59B.png" width="32" height="32" alt="StaplingPortraitBottomRight" /></td>
  <td><span data-ttu-id="028e6-2568">F59B</span><span class="sxs-lookup"><span data-stu-id="028e6-2568">F59B</span></span></td>
  <td><span data-ttu-id="028e6-2569">StaplingPortraitBottomRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2569">StaplingPortraitBottomRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59C.png" width="32" height="32" alt="StaplingPortraitTwoLeft" /></td>
  <td><span data-ttu-id="028e6-2570">F59C</span><span class="sxs-lookup"><span data-stu-id="028e6-2570">F59C</span></span></td>
  <td><span data-ttu-id="028e6-2571">StaplingPortraitTwoLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2571">StaplingPortraitTwoLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59D.png" width="32" height="32" alt="StaplingPortraitTwoRight" /></td>
  <td><span data-ttu-id="028e6-2572">F59D</span><span class="sxs-lookup"><span data-stu-id="028e6-2572">F59D</span></span></td>
  <td><span data-ttu-id="028e6-2573">StaplingPortraitTwoRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2573">StaplingPortraitTwoRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59E.png" width="32" height="32" alt="StaplingPortraitTwoTop" /></td>
  <td><span data-ttu-id="028e6-2574">F59E</span><span class="sxs-lookup"><span data-stu-id="028e6-2574">F59E</span></span></td>
  <td><span data-ttu-id="028e6-2575">StaplingPortraitTwoTop</span><span class="sxs-lookup"><span data-stu-id="028e6-2575">StaplingPortraitTwoTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59F.png" width="32" height="32" alt="StaplingPortraitTwoBottom" /></td>
  <td><span data-ttu-id="028e6-2576">F59F</span><span class="sxs-lookup"><span data-stu-id="028e6-2576">F59F</span></span></td>
  <td><span data-ttu-id="028e6-2577">StaplingPortraitTwoBottom</span><span class="sxs-lookup"><span data-stu-id="028e6-2577">StaplingPortraitTwoBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A0.png" width="32" height="32" alt="StaplingPortraitBookBinding" /></td>
  <td><span data-ttu-id="028e6-2578">F5A0</span><span class="sxs-lookup"><span data-stu-id="028e6-2578">F5A0</span></span></td>
  <td><span data-ttu-id="028e6-2579">StaplingPortraitBookBinding</span><span class="sxs-lookup"><span data-stu-id="028e6-2579">StaplingPortraitBookBinding</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A1.png" width="32" height="32" alt="StaplingLandscapeTopLeft" /></td>
  <td><span data-ttu-id="028e6-2580">F5A1</span><span class="sxs-lookup"><span data-stu-id="028e6-2580">F5A1</span></span></td>
  <td><span data-ttu-id="028e6-2581">StaplingLandscapeTopLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2581">StaplingLandscapeTopLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A2.png" width="32" height="32" alt="StaplingLandscapeTopRight" /></td>
  <td><span data-ttu-id="028e6-2582">F5A2</span><span class="sxs-lookup"><span data-stu-id="028e6-2582">F5A2</span></span></td>
  <td><span data-ttu-id="028e6-2583">StaplingLandscapeTopRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2583">StaplingLandscapeTopRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A3.png" width="32" height="32" alt="StaplingLandscapeBottomLeft" /></td>
  <td><span data-ttu-id="028e6-2584">F5A3</span><span class="sxs-lookup"><span data-stu-id="028e6-2584">F5A3</span></span></td>
  <td><span data-ttu-id="028e6-2585">StaplingLandscapeBottomLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2585">StaplingLandscapeBottomLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A4.png" width="32" height="32" alt="StaplingLandscapeBottomRight" /></td>
  <td><span data-ttu-id="028e6-2586">F5A4</span><span class="sxs-lookup"><span data-stu-id="028e6-2586">F5A4</span></span></td>
  <td><span data-ttu-id="028e6-2587">StaplingLandscapeBottomRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2587">StaplingLandscapeBottomRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A5.png" width="32" height="32" alt="StaplingLandscapeTwoLeft" /></td>
  <td><span data-ttu-id="028e6-2588">F5A5</span><span class="sxs-lookup"><span data-stu-id="028e6-2588">F5A5</span></span></td>
  <td><span data-ttu-id="028e6-2589">StaplingLandscapeTwoLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2589">StaplingLandscapeTwoLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A6.png" width="32" height="32" alt="StaplingLandscapeTwoRight" /></td>
  <td><span data-ttu-id="028e6-2590">F5A6</span><span class="sxs-lookup"><span data-stu-id="028e6-2590">F5A6</span></span></td>
  <td><span data-ttu-id="028e6-2591">StaplingLandscapeTwoRight</span><span class="sxs-lookup"><span data-stu-id="028e6-2591">StaplingLandscapeTwoRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A7.png" width="32" height="32" alt="StaplingLandscapeTwoTop" /></td>
  <td><span data-ttu-id="028e6-2592">F5A7</span><span class="sxs-lookup"><span data-stu-id="028e6-2592">F5A7</span></span></td>
  <td><span data-ttu-id="028e6-2593">StaplingLandscapeTwoTop</span><span class="sxs-lookup"><span data-stu-id="028e6-2593">StaplingLandscapeTwoTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A8.png" width="32" height="32" alt="StaplingLandscapeTwoBottom" /></td>
  <td><span data-ttu-id="028e6-2594">F5A8</span><span class="sxs-lookup"><span data-stu-id="028e6-2594">F5A8</span></span></td>
  <td><span data-ttu-id="028e6-2595">StaplingLandscapeTwoBottom</span><span class="sxs-lookup"><span data-stu-id="028e6-2595">StaplingLandscapeTwoBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A9.png" width="32" height="32" alt="StaplingLandscapeBookBinding" /></td>
  <td><span data-ttu-id="028e6-2596">F5A9</span><span class="sxs-lookup"><span data-stu-id="028e6-2596">F5A9</span></span></td>
  <td><span data-ttu-id="028e6-2597">StaplingLandscapeBookBinding</span><span class="sxs-lookup"><span data-stu-id="028e6-2597">StaplingLandscapeBookBinding</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5AB.png" width="32" height="32" alt="MobSIMError" /></td>
  <td><span data-ttu-id="028e6-2598">F5AB</span><span class="sxs-lookup"><span data-stu-id="028e6-2598">F5AB</span></span></td>
  <td><span data-ttu-id="028e6-2599">MobSIMError</span><span class="sxs-lookup"><span data-stu-id="028e6-2599">MobSIMError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5AC.png" width="32" height="32" alt="CollateLandscapeSeparated" /></td>
  <td><span data-ttu-id="028e6-2600">F5AC</span><span class="sxs-lookup"><span data-stu-id="028e6-2600">F5AC</span></span></td>
  <td><span data-ttu-id="028e6-2601">CollateLandscapeSeparated</span><span class="sxs-lookup"><span data-stu-id="028e6-2601">CollateLandscapeSeparated</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5AD.png" width="32" height="32" alt="PPSOnePortrait" /></td>
  <td><span data-ttu-id="028e6-2602">F5AD</span><span class="sxs-lookup"><span data-stu-id="028e6-2602">F5AD</span></span></td>
  <td><span data-ttu-id="028e6-2603">PPSOnePortrait</span><span class="sxs-lookup"><span data-stu-id="028e6-2603">PPSOnePortrait</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5AE.png" width="32" height="32" alt="StaplingPortraitBottomLeft" /></td>
  <td><span data-ttu-id="028e6-2604">F5AE</span><span class="sxs-lookup"><span data-stu-id="028e6-2604">F5AE</span></span></td>
  <td><span data-ttu-id="028e6-2605">StaplingPortraitBottomLeft</span><span class="sxs-lookup"><span data-stu-id="028e6-2605">StaplingPortraitBottomLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5B0.png" width="32" height="32" alt="PlaySolid" /></td>
  <td><span data-ttu-id="028e6-2606">F5B0</span><span class="sxs-lookup"><span data-stu-id="028e6-2606">F5B0</span></span></td>
  <td><span data-ttu-id="028e6-2607">PlaySolid</span><span class="sxs-lookup"><span data-stu-id="028e6-2607">PlaySolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5ED.png" width="32" height="32" alt="Set" /></td>
  <td><span data-ttu-id="028e6-2608">F5ED</span><span class="sxs-lookup"><span data-stu-id="028e6-2608">F5ED</span></span></td>
  <td><span data-ttu-id="028e6-2609">設定</span><span class="sxs-lookup"><span data-stu-id="028e6-2609">Set</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5EE.png" width="32" height="32" alt="SetSolid" /></td>
  <td><span data-ttu-id="028e6-2610">F5EE</span><span class="sxs-lookup"><span data-stu-id="028e6-2610">F5EE</span></span></td>
  <td><span data-ttu-id="028e6-2611">SetSolid</span><span class="sxs-lookup"><span data-stu-id="028e6-2611">SetSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5EF.png" width="32" height="32" alt="FuzzyReading" /></td>
  <td><span data-ttu-id="028e6-2612">F5EF</span><span class="sxs-lookup"><span data-stu-id="028e6-2612">F5EF</span></span></td>
  <td><span data-ttu-id="028e6-2613">FuzzyReading</span><span class="sxs-lookup"><span data-stu-id="028e6-2613">FuzzyReading</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F2.png" width="32" height="32" alt="VerticalBattery0" /></td>
  <td><span data-ttu-id="028e6-2614">F5F2</span><span class="sxs-lookup"><span data-stu-id="028e6-2614">F5F2</span></span></td>
  <td><span data-ttu-id="028e6-2615">VerticalBattery0</span><span class="sxs-lookup"><span data-stu-id="028e6-2615">VerticalBattery0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F3.png" width="32" height="32" alt="VerticalBattery1" /></td>
  <td><span data-ttu-id="028e6-2616">F5F3</span><span class="sxs-lookup"><span data-stu-id="028e6-2616">F5F3</span></span></td>
  <td><span data-ttu-id="028e6-2617">VerticalBattery1</span><span class="sxs-lookup"><span data-stu-id="028e6-2617">VerticalBattery1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F4.png" width="32" height="32" alt="VerticalBattery2" /></td>
  <td><span data-ttu-id="028e6-2618">F5F4</span><span class="sxs-lookup"><span data-stu-id="028e6-2618">F5F4</span></span></td>
  <td><span data-ttu-id="028e6-2619">VerticalBattery2</span><span class="sxs-lookup"><span data-stu-id="028e6-2619">VerticalBattery2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F5.png" width="32" height="32" alt="VerticalBattery3" /></td>
  <td><span data-ttu-id="028e6-2620">F5F5</span><span class="sxs-lookup"><span data-stu-id="028e6-2620">F5F5</span></span></td>
  <td><span data-ttu-id="028e6-2621">VerticalBattery3</span><span class="sxs-lookup"><span data-stu-id="028e6-2621">VerticalBattery3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F6.png" width="32" height="32" alt="VerticalBattery4" /></td>
  <td><span data-ttu-id="028e6-2622">F5F6</span><span class="sxs-lookup"><span data-stu-id="028e6-2622">F5F6</span></span></td>
  <td><span data-ttu-id="028e6-2623">VerticalBattery4</span><span class="sxs-lookup"><span data-stu-id="028e6-2623">VerticalBattery4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F7.png" width="32" height="32" alt="VerticalBattery5" /></td>
  <td><span data-ttu-id="028e6-2624">F5F7</span><span class="sxs-lookup"><span data-stu-id="028e6-2624">F5F7</span></span></td>
  <td><span data-ttu-id="028e6-2625">VerticalBattery5</span><span class="sxs-lookup"><span data-stu-id="028e6-2625">VerticalBattery5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F8.png" width="32" height="32" alt="VerticalBattery6" /></td>
  <td><span data-ttu-id="028e6-2626">F5F8</span><span class="sxs-lookup"><span data-stu-id="028e6-2626">F5F8</span></span></td>
  <td><span data-ttu-id="028e6-2627">VerticalBattery6</span><span class="sxs-lookup"><span data-stu-id="028e6-2627">VerticalBattery6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F9.png" width="32" height="32" alt="VerticalBattery7" /></td>
  <td><span data-ttu-id="028e6-2628">F5F9</span><span class="sxs-lookup"><span data-stu-id="028e6-2628">F5F9</span></span></td>
  <td><span data-ttu-id="028e6-2629">VerticalBattery7</span><span class="sxs-lookup"><span data-stu-id="028e6-2629">VerticalBattery7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FA.png" width="32" height="32" alt="VerticalBattery8" /></td>
  <td><span data-ttu-id="028e6-2630">F5FA</span><span class="sxs-lookup"><span data-stu-id="028e6-2630">F5FA</span></span></td>
  <td><span data-ttu-id="028e6-2631">VerticalBattery8</span><span class="sxs-lookup"><span data-stu-id="028e6-2631">VerticalBattery8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FB.png" width="32" height="32" alt="VerticalBattery9" /></td>
  <td><span data-ttu-id="028e6-2632">F5FB</span><span class="sxs-lookup"><span data-stu-id="028e6-2632">F5FB</span></span></td>
  <td><span data-ttu-id="028e6-2633">VerticalBattery9</span><span class="sxs-lookup"><span data-stu-id="028e6-2633">VerticalBattery9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FC.png" width="32" height="32" alt="VerticalBattery10" /></td>
  <td><span data-ttu-id="028e6-2634">F5FC</span><span class="sxs-lookup"><span data-stu-id="028e6-2634">F5FC</span></span></td>
  <td><span data-ttu-id="028e6-2635">VerticalBattery10</span><span class="sxs-lookup"><span data-stu-id="028e6-2635">VerticalBattery10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FD.png" width="32" height="32" alt="VerticalBatteryCharging0" /></td>
  <td><span data-ttu-id="028e6-2636">F5FD</span><span class="sxs-lookup"><span data-stu-id="028e6-2636">F5FD</span></span></td>
  <td><span data-ttu-id="028e6-2637">VerticalBatteryCharging0</span><span class="sxs-lookup"><span data-stu-id="028e6-2637">VerticalBatteryCharging0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FE.png" width="32" height="32" alt="VerticalBatteryCharging1" /></td>
  <td><span data-ttu-id="028e6-2638">F5FE</span><span class="sxs-lookup"><span data-stu-id="028e6-2638">F5FE</span></span></td>
  <td><span data-ttu-id="028e6-2639">VerticalBatteryCharging1</span><span class="sxs-lookup"><span data-stu-id="028e6-2639">VerticalBatteryCharging1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FF.png" width="32" height="32" alt="VerticalBatteryCharging2" /></td>
  <td><span data-ttu-id="028e6-2640">F5FF</span><span class="sxs-lookup"><span data-stu-id="028e6-2640">F5FF</span></span></td>
  <td><span data-ttu-id="028e6-2641">VerticalBatteryCharging2</span><span class="sxs-lookup"><span data-stu-id="028e6-2641">VerticalBatteryCharging2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F600.png" width="32" height="32" alt="VerticalBatteryCharging3" /></td>
  <td><span data-ttu-id="028e6-2642">F600</span><span class="sxs-lookup"><span data-stu-id="028e6-2642">F600</span></span></td>
  <td><span data-ttu-id="028e6-2643">VerticalBatteryCharging3</span><span class="sxs-lookup"><span data-stu-id="028e6-2643">VerticalBatteryCharging3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F601.png" width="32" height="32" alt="VerticalBatteryCharging4" /></td>
  <td><span data-ttu-id="028e6-2644">F601</span><span class="sxs-lookup"><span data-stu-id="028e6-2644">F601</span></span></td>
  <td><span data-ttu-id="028e6-2645">VerticalBatteryCharging4</span><span class="sxs-lookup"><span data-stu-id="028e6-2645">VerticalBatteryCharging4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F602.png" width="32" height="32" alt="VerticalBatteryCharging5" /></td>
  <td><span data-ttu-id="028e6-2646">F602</span><span class="sxs-lookup"><span data-stu-id="028e6-2646">F602</span></span></td>
  <td><span data-ttu-id="028e6-2647">VerticalBatteryCharging5</span><span class="sxs-lookup"><span data-stu-id="028e6-2647">VerticalBatteryCharging5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F603.png" width="32" height="32" alt="VerticalBatteryCharging6" /></td>
  <td><span data-ttu-id="028e6-2648">F603</span><span class="sxs-lookup"><span data-stu-id="028e6-2648">F603</span></span></td>
  <td><span data-ttu-id="028e6-2649">VerticalBatteryCharging6</span><span class="sxs-lookup"><span data-stu-id="028e6-2649">VerticalBatteryCharging6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F604.png" width="32" height="32" alt="VerticalBatteryCharging7" /></td>
  <td><span data-ttu-id="028e6-2650">F604</span><span class="sxs-lookup"><span data-stu-id="028e6-2650">F604</span></span></td>
  <td><span data-ttu-id="028e6-2651">VerticalBatteryCharging7</span><span class="sxs-lookup"><span data-stu-id="028e6-2651">VerticalBatteryCharging7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F605.png" width="32" height="32" alt="VerticalBatteryCharging8" /></td>
  <td><span data-ttu-id="028e6-2652">F605</span><span class="sxs-lookup"><span data-stu-id="028e6-2652">F605</span></span></td>
  <td><span data-ttu-id="028e6-2653">VerticalBatteryCharging8</span><span class="sxs-lookup"><span data-stu-id="028e6-2653">VerticalBatteryCharging8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F606.png" width="32" height="32" alt="VerticalBatteryCharging9" /></td>
  <td><span data-ttu-id="028e6-2654">F606</span><span class="sxs-lookup"><span data-stu-id="028e6-2654">F606</span></span></td>
  <td><span data-ttu-id="028e6-2655">VerticalBatteryCharging9</span><span class="sxs-lookup"><span data-stu-id="028e6-2655">VerticalBatteryCharging9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F607.png" width="32" height="32" alt="VerticalBatteryCharging10" /></td>
  <td><span data-ttu-id="028e6-2656">F607</span><span class="sxs-lookup"><span data-stu-id="028e6-2656">F607</span></span></td>
  <td><span data-ttu-id="028e6-2657">VerticalBatteryCharging10</span><span class="sxs-lookup"><span data-stu-id="028e6-2657">VerticalBatteryCharging10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F608.png" width="32" height="32" alt="VerticalBatteryUnknown" /></td>
  <td><span data-ttu-id="028e6-2658">F608</span><span class="sxs-lookup"><span data-stu-id="028e6-2658">F608</span></span></td>
  <td><span data-ttu-id="028e6-2659">VerticalBatteryUnknown</span><span class="sxs-lookup"><span data-stu-id="028e6-2659">VerticalBatteryUnknown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F618.png" width="32" height="32" alt="SIMError" /></td>
  <td><span data-ttu-id="028e6-2660">F618</span><span class="sxs-lookup"><span data-stu-id="028e6-2660">F618</span></span></td>
  <td><span data-ttu-id="028e6-2661">SIMError</span><span class="sxs-lookup"><span data-stu-id="028e6-2661">SIMError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F619.png" width="32" height="32" alt="SIMMissing" /></td>
  <td><span data-ttu-id="028e6-2662">F619</span><span class="sxs-lookup"><span data-stu-id="028e6-2662">F619</span></span></td>
  <td><span data-ttu-id="028e6-2663">SIMMissing</span><span class="sxs-lookup"><span data-stu-id="028e6-2663">SIMMissing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61A.png" width="32" height="32" alt="SIMLock" /></td>
  <td><span data-ttu-id="028e6-2664">F61A</span><span class="sxs-lookup"><span data-stu-id="028e6-2664">F61A</span></span></td>
  <td><span data-ttu-id="028e6-2665">SIMLock</span><span class="sxs-lookup"><span data-stu-id="028e6-2665">SIMLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61B.png" width="32" height="32" alt="eSIM" /></td>
  <td><span data-ttu-id="028e6-2666">F61B</span><span class="sxs-lookup"><span data-stu-id="028e6-2666">F61B</span></span></td>
  <td><span data-ttu-id="028e6-2667">eSIM</span><span class="sxs-lookup"><span data-stu-id="028e6-2667">eSIM</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61C.png" width="32" height="32" alt="eSIMNoProfile" /></td>
  <td><span data-ttu-id="028e6-2668">F61C</span><span class="sxs-lookup"><span data-stu-id="028e6-2668">F61C</span></span></td>
  <td><span data-ttu-id="028e6-2669">eSIMNoProfile</span><span class="sxs-lookup"><span data-stu-id="028e6-2669">eSIMNoProfile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61D.png" width="32" height="32" alt="eSIMLocked" /></td>
  <td><span data-ttu-id="028e6-2670">F61D</span><span class="sxs-lookup"><span data-stu-id="028e6-2670">F61D</span></span></td>
  <td><span data-ttu-id="028e6-2671">eSIMLocked</span><span class="sxs-lookup"><span data-stu-id="028e6-2671">eSIMLocked</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61E.png" width="32" height="32" alt="eSIMBusy" /></td>
  <td><span data-ttu-id="028e6-2672">F61E</span><span class="sxs-lookup"><span data-stu-id="028e6-2672">F61E</span></span></td>
  <td><span data-ttu-id="028e6-2673">eSIMBusy</span><span class="sxs-lookup"><span data-stu-id="028e6-2673">eSIMBusy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61F.png" width="32" height="32" alt="NoiseCancelation" /></td>
  <td><span data-ttu-id="028e6-2674">F61F</span><span class="sxs-lookup"><span data-stu-id="028e6-2674">F61F</span></span></td>
  <td><span data-ttu-id="028e6-2675">NoiseCancelation</span><span class="sxs-lookup"><span data-stu-id="028e6-2675">NoiseCancelation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F620.png" width="32" height="32" alt="NoiseCancelationOff" /></td>
  <td><span data-ttu-id="028e6-2676">F620</span><span class="sxs-lookup"><span data-stu-id="028e6-2676">F620</span></span></td>
  <td><span data-ttu-id="028e6-2677">NoiseCancelationOff</span><span class="sxs-lookup"><span data-stu-id="028e6-2677">NoiseCancelationOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F623.png" width="32" height="32" alt="MusicSharing" /></td>
  <td><span data-ttu-id="028e6-2678">F623</span><span class="sxs-lookup"><span data-stu-id="028e6-2678">F623</span></span></td>
  <td><span data-ttu-id="028e6-2679">MusicSharing</span><span class="sxs-lookup"><span data-stu-id="028e6-2679">MusicSharing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F624.png" width="32" height="32" alt="MusicSharingOff" /></td>
  <td><span data-ttu-id="028e6-2680">F624</span><span class="sxs-lookup"><span data-stu-id="028e6-2680">F624</span></span></td>
  <td><span data-ttu-id="028e6-2681">MusicSharingOff</span><span class="sxs-lookup"><span data-stu-id="028e6-2681">MusicSharingOff</span></span></td>
 </tr>
</table>



## <a name="related-articles"></a><span data-ttu-id="028e6-2682">関連記事</span><span class="sxs-lookup"><span data-stu-id="028e6-2682">Related articles</span></span>

* [<span data-ttu-id="028e6-2683">アイコンのガイドライン</span><span class="sxs-lookup"><span data-stu-id="028e6-2683">Guidelines for icons</span></span>](../style/icons.md)
* [<span data-ttu-id="028e6-2684">Symbol 列挙値</span><span class="sxs-lookup"><span data-stu-id="028e6-2684">Symbol enumeration</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Symbol)
* [<span data-ttu-id="028e6-2685">FontIcon クラス</span><span class="sxs-lookup"><span data-stu-id="028e6-2685">FontIcon class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon)


