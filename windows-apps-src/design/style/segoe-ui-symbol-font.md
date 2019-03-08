---
Description: この記事には、Segoe MDL2 Assets フォントに付属しているグリフの一覧と、その使い方のガイダンスが含まれています。
Search.Refinement.TopicID: 184
title: Segoe MDL2 アイコンのガイドライン
ms.assetid: DFB215C2-8A61-4957-B662-3B1991AC9BE1
label: Segoe MDL2 icons
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 076e4b0ddf30a23271bbb6b488f235f7233b28c2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649057"
---
# <a name="segoe-mdl2-icons"></a><span data-ttu-id="59098-104">Segoe MDL2 アイコン</span><span class="sxs-lookup"><span data-stu-id="59098-104">Segoe MDL2 icons</span></span>

 

<span data-ttu-id="59098-105">この記事では、Segoe MDL2 アセット フォントによって提供されるアイコンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="59098-105">This article lists the icons provided by the Segoe MDL2 Assets font.</span></span> 

> <span data-ttu-id="59098-106">**重要な Api**:[**列挙型のシンボル**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol)、 [ **FontIcon クラス**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon)</span><span class="sxs-lookup"><span data-stu-id="59098-106">**Important APIs**: [**Symbol enum**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol), [**FontIcon class**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon)</span></span>

## <a name="about-segoe-mdl2-assets"></a><span data-ttu-id="59098-107">Segoe MDL2 アセットについて</span><span class="sxs-lookup"><span data-stu-id="59098-107">About Segoe MDL2 Assets</span></span>

<span data-ttu-id="59098-108">Windows 10 のリリースにより、従来の Windows 8/8.1 Segoe UI Symbol アイコン フォントが、Segoe MDL2 アセット フォントに置き換えられました。</span><span class="sxs-lookup"><span data-stu-id="59098-108">With the release of Windows 10, the Segoe MDL2 Assets font replaced the Windows 8/8.1 Segoe UI Symbol icon font.</span></span> <span data-ttu-id="59098-109"><!-- It can be used in much the same manner as the older font, but many glyphs have been redrawn in the Windows 10 icon style with the font’s metrics set so that icons are aligned within the font’s em-square instead of on a typographic baseline. --> (**Segoe UI Symbol**は引き続き「レガシ」のリソースとして使用できますが、新しいアプリの更新をお勧めします**Segoe MDL2 資産**。)。</span><span class="sxs-lookup"><span data-stu-id="59098-109"><!-- It can be used in much the same manner as the older font, but many glyphs have been redrawn in the Windows 10 icon style with the font’s metrics set so that icons are aligned within the font’s em-square instead of on a typographic baseline. --> (**Segoe UI Symbol** will still be available as a "legacy" resource, but we recommend updating your app to use the new **Segoe MDL2 Assets**.)</span></span>

<span data-ttu-id="59098-110">**Segoe MDL2 アセット** フォントに含まれるアイコンや UI コントロールのほとんどは、Unicode の私用領域 (PUA) にマップされます。</span><span class="sxs-lookup"><span data-stu-id="59098-110">Most of the icons and UI controls included in the **Segoe MDL2 Assets** font are mapped to the Private Use Area of Unicode (PUA).</span></span> <span data-ttu-id="59098-111">フォント開発者は PUA を使って、既にあるコード ポイントにマップされないグリフにプライベート Unicode 値を割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="59098-111">The PUA allows font developers to assign private Unicode values to glyphs that don’t map to existing code points.</span></span> <span data-ttu-id="59098-112">これは、記号フォントを作成するときに役立ちますが、相互運用性の問題が生じます。</span><span class="sxs-lookup"><span data-stu-id="59098-112">This is useful when creating a symbol font, but it creates an interoperability problem.</span></span> <span data-ttu-id="59098-113">フォントが利用できない場合、グリフは表示されません。</span><span class="sxs-lookup"><span data-stu-id="59098-113">If the font is not available, the glyphs won’t show up.</span></span> <span data-ttu-id="59098-114">これらのグリフは、 **Segoe MDL2 アセット** フォントを明示的に指定できる場合にのみ使います。</span><span class="sxs-lookup"><span data-stu-id="59098-114">Only use these glyphs when you can specify the **Segoe MDL2 Assets** font.</span></span>

<span data-ttu-id="59098-115">これらのグリフは、**Segoe MDL2 アセット** フォントを明示的に指定できる場合にのみ使います。</span><span class="sxs-lookup"><span data-stu-id="59098-115">Use these glyphs only when you can explicitly specify the **Segoe MDL2 Assets** font.</span></span> <span data-ttu-id="59098-116">タイルを使っている場合は、タイルのフォントを指定できず、フォントのフォールバックで PUA グリフを使うことができないため、これらのグリフは使うことができません。</span><span class="sxs-lookup"><span data-stu-id="59098-116">If you are working with tiles, you can't use these glyphs because you can't specify the tile font and PUA glyphs are not available via font-fallback.</span></span>

<span data-ttu-id="59098-117">**Segoe UI Symbol** と異なり、**Segoe MDL2 アセット** フォントのアイコンは、テキストとインラインで使用することは意図されていません。</span><span class="sxs-lookup"><span data-stu-id="59098-117">Unlike with **Segoe UI Symbol**, the icons in the **Segoe MDL2 Assets** font are not intended for use in-line with text.</span></span> <span data-ttu-id="59098-118">これは、段階的表示の矢印のような一部の古い方法は利用できなくなったことを意味します。</span><span class="sxs-lookup"><span data-stu-id="59098-118">This means that some older "tricks" like the progressive disclosure arrows no longer apply.</span></span> <span data-ttu-id="59098-119">さらに、新しいアイコンはすべて同じ場所に同じ大きさで表示されるため、幅を 0 にして作成する必要はありません。一組で機能することが確認済みです。</span><span class="sxs-lookup"><span data-stu-id="59098-119">Likewise, since all of the new icons are sized and positioned the same, they do not have to be made with zero width; we have just made sure they work as a set.</span></span> <span data-ttu-id="59098-120">一組として設計された 2 つのアイコンは、ぴったり重ねることができ、正しい位置に収まることが理想的です。</span><span class="sxs-lookup"><span data-stu-id="59098-120">Ideally, you can overlay two icons that were designed as a set and they will fall into place.</span></span> <span data-ttu-id="59098-121">これにより、コード内の色付けが可能になります。</span><span class="sxs-lookup"><span data-stu-id="59098-121">We may do this to allow colorization in the code.</span></span> <span data-ttu-id="59098-122">たとえば、スタート タイルのバッチ ステータス用に、U+EA3A と U+EA3B が作成されました。</span><span class="sxs-lookup"><span data-stu-id="59098-122">For example, U+EA3A and U+EA3B were created for the Start tile Badge status.</span></span> <span data-ttu-id="59098-123">これらは既に中央揃えされているため、ステータスが変わった場合に円を色で塗りつぶすことができます。</span><span class="sxs-lookup"><span data-stu-id="59098-123">Because these are already centered the circle fill can be colored for different states.</span></span>

## <a name="layering-and-mirroring"></a><span data-ttu-id="59098-124">重ね合わせとミラーリング</span><span class="sxs-lookup"><span data-stu-id="59098-124">Layering and mirroring</span></span>

<span data-ttu-id="59098-125">**Segoe MDL2 アセット**のグリフにはすべて、一貫した高さと、左を原点とした同一の固定幅が設定されているため、重ね合わせや色付けの効果はグリフどうしを直接重ねて描画することで表現できます。</span><span class="sxs-lookup"><span data-stu-id="59098-125">All glyphs in **Segoe MDL2 Assets** have the same fixed width with a consistent height and left origin point, so layering and colorization effects can be achieved by drawing glyphs directly on top of each other.</span></span> <span data-ttu-id="59098-126">この例では、幅が 0 の赤いハートに重ねて、黒の輪郭が描画されています。</span><span class="sxs-lookup"><span data-stu-id="59098-126">This example show a black outline drawn on top of the zero-width red heart.</span></span>

![幅が 0 のグリフの使用](images/segoe-ui-symbol-layering.png)

<span data-ttu-id="59098-128">また、アイコンの多くは、アラビア語、ペルシア語、ヘブライ語などの右から左に書く文字を使う言語でも利用できるように、左右が反転した形式も作成されています。</span><span class="sxs-lookup"><span data-stu-id="59098-128">Many of the icons also have mirrored forms available for use in languages that use right-to-left text directionality such as Arabic, Farsi, and Hebrew.</span></span>

## <a name="using-the-icons"></a><span data-ttu-id="59098-129">アイコンの使用</span><span class="sxs-lookup"><span data-stu-id="59098-129">Using the icons</span></span>
<span data-ttu-id="59098-130">アプリを開発している場合C#Segoe MDL2 資産から指定したグリフを使用するには VB と C++ と XAML では、/、[列挙型のシンボル](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol)します。</span><span class="sxs-lookup"><span data-stu-id="59098-130">If you are developing an app in C#/VB/C++ and XAML, you can use specified glyphs from Segoe MDL2 Assets with the [Symbol enumeration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symbol).</span></span> 

```xaml
<SymbolIcon Symbol="GlobalNavigationButton"/>
```

<span data-ttu-id="59098-131">Symbol 列挙値に含まれていない **Segoe MDL2 アセット** フォントのグリフを使用する場合は、[**FontIcon**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon) を使用します。</span><span class="sxs-lookup"><span data-stu-id="59098-131">If you would like to use a glyph from the **Segoe MDL2 Assets** font that is not included in the Symbol enum, then use a [**FontIcon**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon).</span></span>

```xaml
<FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xE700;"/>
```

<span data-ttu-id="59098-132">静的リソースを使用することもできます。`SymbolThemeFontFamily`にアクセスする**Segoe MDL2 資産**、名前で、フォントを指定する代わりにします。</span><span class="sxs-lookup"><span data-stu-id="59098-132">You can also use the static resource `SymbolThemeFontFamily` to access **Segoe MDL2 Assets**, instead of specifying the font by name:</span></span>
```xaml
<FontIcon FontFamily="{StaticResource SymbolThemeFontFamily}" Glyph="&#xE700;"/>
```


## <a name="how-do-i-get-this-font"></a><span data-ttu-id="59098-133">このフォントの入手方法</span><span class="sxs-lookup"><span data-stu-id="59098-133">How do I get this font?</span></span>
* <span data-ttu-id="59098-134">Windows 10 の場合。何も行う必要があるを使用する必要がある、Windows に付属のフォント。</span><span class="sxs-lookup"><span data-stu-id="59098-134">On Windows 10: There's nothing you need to do, the font comes with Windows.</span></span>
* <span data-ttu-id="59098-135">Mac では、ダウンロードして、フォントをインストールする必要があります。<a href="https://aka.ms/SegoeFonts">Segoe UI と MDL2 アイコンのフォントを取得します。</a></span><span class="sxs-lookup"><span data-stu-id="59098-135">On a Mac, you need to download and install the font: <a href="https://aka.ms/SegoeFonts">Get the Segoe UI and MDL2 icon fonts</a></span></span>

## <a name="icon-list"></a><span data-ttu-id="59098-136">アイコン一覧</span><span class="sxs-lookup"><span data-stu-id="59098-136">Icon list</span></span>
<span data-ttu-id="59098-137">**Segoe MDL2 アセット** フォントには、以下に示すアイコンもあります。</span><span class="sxs-lookup"><span data-stu-id="59098-137">Please keep in mind that the **Segoe MDL2 Assets** font includes many more icons than we can show here.</span></span> <span data-ttu-id="59098-138">ここで紹介するアイコンの多くは、特殊な目的のために使用されるもので、それ以外の場合は通常使用しません。</span><span class="sxs-lookup"><span data-stu-id="59098-138">Many of the icons are intended for specialized purposed and are not typically used anywhere else.</span></span>


<table style="background-color: white; color: black">

 <tr>
  <td><span data-ttu-id="59098-139">記号</span><span class="sxs-lookup"><span data-stu-id="59098-139">Symbol</span></span></td>
  <td><span data-ttu-id="59098-140">Unicode ポイント</span><span class="sxs-lookup"><span data-stu-id="59098-140">Unicode point</span></span></td>
  <td><span data-ttu-id="59098-141">説明</span><span class="sxs-lookup"><span data-stu-id="59098-141">Description</span></span></td>
 </tr>
 <tr><td><img src="images/segoe-mdl/E700.png" width="32" height="32" alt="GlobalNavigationButton" /></td>
  <td><span data-ttu-id="59098-142">E700</span><span class="sxs-lookup"><span data-stu-id="59098-142">E700</span></span></td>
  <td><span data-ttu-id="59098-143">GlobalNavigationButton</span><span class="sxs-lookup"><span data-stu-id="59098-143">GlobalNavigationButton</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E701.png" width="32" height="32" alt="Wifi" /></td>
  <td><span data-ttu-id="59098-144">E701</span><span class="sxs-lookup"><span data-stu-id="59098-144">E701</span></span></td>
  <td><span data-ttu-id="59098-145">Wifi</span><span class="sxs-lookup"><span data-stu-id="59098-145">Wifi</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E702.png" width="32" height="32" alt="Bluetooth" /></td>
  <td><span data-ttu-id="59098-146">E702</span><span class="sxs-lookup"><span data-stu-id="59098-146">E702</span></span></td>
  <td><span data-ttu-id="59098-147">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="59098-147">Bluetooth</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E703.png" width="32" height="32" alt="Connect" /></td>
  <td><span data-ttu-id="59098-148">E703</span><span class="sxs-lookup"><span data-stu-id="59098-148">E703</span></span></td>
  <td><span data-ttu-id="59098-149">接続</span><span class="sxs-lookup"><span data-stu-id="59098-149">Connect</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E704.png" width="32" height="32" alt="InternetSharing" /></td>
  <td><span data-ttu-id="59098-150">E704</span><span class="sxs-lookup"><span data-stu-id="59098-150">E704</span></span></td>
  <td><span data-ttu-id="59098-151">InternetSharing</span><span class="sxs-lookup"><span data-stu-id="59098-151">InternetSharing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E705.png" width="32" height="32" alt="VPN" /></td>
  <td><span data-ttu-id="59098-152">E705</span><span class="sxs-lookup"><span data-stu-id="59098-152">E705</span></span></td>
  <td><span data-ttu-id="59098-153">VPN</span><span class="sxs-lookup"><span data-stu-id="59098-153">VPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E706.png" width="32" height="32" alt="Brightness" /></td>
  <td><span data-ttu-id="59098-154">E706</span><span class="sxs-lookup"><span data-stu-id="59098-154">E706</span></span></td>
  <td><span data-ttu-id="59098-155">Brightness</span><span class="sxs-lookup"><span data-stu-id="59098-155">Brightness</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E707.png" width="32" height="32" alt="MapPin" /></td>
  <td><span data-ttu-id="59098-156">E707</span><span class="sxs-lookup"><span data-stu-id="59098-156">E707</span></span></td>
  <td><span data-ttu-id="59098-157">MapPin</span><span class="sxs-lookup"><span data-stu-id="59098-157">MapPin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E708.png" width="32" height="32" alt="QuietHours" /></td>
  <td><span data-ttu-id="59098-158">E708</span><span class="sxs-lookup"><span data-stu-id="59098-158">E708</span></span></td>
  <td><span data-ttu-id="59098-159">QuietHours</span><span class="sxs-lookup"><span data-stu-id="59098-159">QuietHours</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E709.png" width="32" height="32" alt="Airplane" /></td>
  <td><span data-ttu-id="59098-160">E709</span><span class="sxs-lookup"><span data-stu-id="59098-160">E709</span></span></td>
  <td><span data-ttu-id="59098-161">Airplane</span><span class="sxs-lookup"><span data-stu-id="59098-161">Airplane</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70A.png" width="32" height="32" alt="Tablet" /></td>
  <td><span data-ttu-id="59098-162">E70A</span><span class="sxs-lookup"><span data-stu-id="59098-162">E70A</span></span></td>
  <td><span data-ttu-id="59098-163">タブレット</span><span class="sxs-lookup"><span data-stu-id="59098-163">Tablet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70B.png" width="32" height="32" alt="QuickNote" /></td>
  <td><span data-ttu-id="59098-164">E70B</span><span class="sxs-lookup"><span data-stu-id="59098-164">E70B</span></span></td>
  <td><span data-ttu-id="59098-165">QuickNote</span><span class="sxs-lookup"><span data-stu-id="59098-165">QuickNote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70C.png" width="32" height="32" alt="RememberedDevice" /></td>
  <td><span data-ttu-id="59098-166">E70C</span><span class="sxs-lookup"><span data-stu-id="59098-166">E70C</span></span></td>
  <td><span data-ttu-id="59098-167">RememberedDevice</span><span class="sxs-lookup"><span data-stu-id="59098-167">RememberedDevice</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70D.png" width="32" height="32" alt="ChevronDown" /></td>
  <td><span data-ttu-id="59098-168">E70D</span><span class="sxs-lookup"><span data-stu-id="59098-168">E70D</span></span></td>
  <td><span data-ttu-id="59098-169">ChevronDown</span><span class="sxs-lookup"><span data-stu-id="59098-169">ChevronDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70E.png" width="32" height="32" alt="ChevronUp" /></td>
  <td><span data-ttu-id="59098-170">E70E</span><span class="sxs-lookup"><span data-stu-id="59098-170">E70E</span></span></td>
  <td><span data-ttu-id="59098-171">ChevronUp</span><span class="sxs-lookup"><span data-stu-id="59098-171">ChevronUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E70F.png" width="32" height="32" alt="Edit" /></td>
  <td><span data-ttu-id="59098-172">E70F</span><span class="sxs-lookup"><span data-stu-id="59098-172">E70F</span></span></td>
  <td><span data-ttu-id="59098-173">Edit</span><span class="sxs-lookup"><span data-stu-id="59098-173">Edit</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E710.png" width="32" height="32" alt="Add" /></td>
  <td><span data-ttu-id="59098-174">E710</span><span class="sxs-lookup"><span data-stu-id="59098-174">E710</span></span></td>
  <td><span data-ttu-id="59098-175">Add</span><span class="sxs-lookup"><span data-stu-id="59098-175">Add</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E711.png" width="32" height="32" alt="Cancel" /></td>
  <td><span data-ttu-id="59098-176">E711</span><span class="sxs-lookup"><span data-stu-id="59098-176">E711</span></span></td>
  <td><span data-ttu-id="59098-177">Cancel</span><span class="sxs-lookup"><span data-stu-id="59098-177">Cancel</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E712.png" width="32" height="32" alt="More" /></td>
  <td><span data-ttu-id="59098-178">E712</span><span class="sxs-lookup"><span data-stu-id="59098-178">E712</span></span></td>
  <td><span data-ttu-id="59098-179">More</span><span class="sxs-lookup"><span data-stu-id="59098-179">More</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E713.png" width="32" height="32" alt="Settings" /></td>
  <td><span data-ttu-id="59098-180">E713</span><span class="sxs-lookup"><span data-stu-id="59098-180">E713</span></span></td>
  <td><span data-ttu-id="59098-181">設定</span><span class="sxs-lookup"><span data-stu-id="59098-181">Settings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E714.png" width="32" height="32" alt="Video" /></td>
  <td><span data-ttu-id="59098-182">E714</span><span class="sxs-lookup"><span data-stu-id="59098-182">E714</span></span></td>
  <td><span data-ttu-id="59098-183">Video</span><span class="sxs-lookup"><span data-stu-id="59098-183">Video</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E715.png" width="32" height="32" alt="Mail" /></td>
  <td><span data-ttu-id="59098-184">E715</span><span class="sxs-lookup"><span data-stu-id="59098-184">E715</span></span></td>
  <td><span data-ttu-id="59098-185">Mail</span><span class="sxs-lookup"><span data-stu-id="59098-185">Mail</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E716.png" width="32" height="32" alt="People" /></td>
  <td><span data-ttu-id="59098-186">E716</span><span class="sxs-lookup"><span data-stu-id="59098-186">E716</span></span></td>
  <td><span data-ttu-id="59098-187">People</span><span class="sxs-lookup"><span data-stu-id="59098-187">People</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E717.png" width="32" height="32" alt="Phone" /></td>
  <td><span data-ttu-id="59098-188">E717</span><span class="sxs-lookup"><span data-stu-id="59098-188">E717</span></span></td>
  <td><span data-ttu-id="59098-189">Phone</span><span class="sxs-lookup"><span data-stu-id="59098-189">Phone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E718.png" width="32" height="32" alt="Pin" /></td>
  <td><span data-ttu-id="59098-190">E718</span><span class="sxs-lookup"><span data-stu-id="59098-190">E718</span></span></td>
  <td><span data-ttu-id="59098-191">Pin</span><span class="sxs-lookup"><span data-stu-id="59098-191">Pin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E719.png" width="32" height="32" alt="Shop" /></td>
  <td><span data-ttu-id="59098-192">E719</span><span class="sxs-lookup"><span data-stu-id="59098-192">E719</span></span></td>
  <td><span data-ttu-id="59098-193">Shop</span><span class="sxs-lookup"><span data-stu-id="59098-193">Shop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71A.png" width="32" height="32" alt="Stop" /></td>
  <td><span data-ttu-id="59098-194">E71A</span><span class="sxs-lookup"><span data-stu-id="59098-194">E71A</span></span></td>
  <td><span data-ttu-id="59098-195">Stop</span><span class="sxs-lookup"><span data-stu-id="59098-195">Stop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71B.png" width="32" height="32" alt="Link" /></td>
  <td><span data-ttu-id="59098-196">E71B</span><span class="sxs-lookup"><span data-stu-id="59098-196">E71B</span></span></td>
  <td><span data-ttu-id="59098-197">リンク</span><span class="sxs-lookup"><span data-stu-id="59098-197">Link</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71C.png" width="32" height="32" alt="Filter" /></td>
  <td><span data-ttu-id="59098-198">E71C</span><span class="sxs-lookup"><span data-stu-id="59098-198">E71C</span></span></td>
  <td><span data-ttu-id="59098-199">フィルター</span><span class="sxs-lookup"><span data-stu-id="59098-199">Filter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71D.png" width="32" height="32" alt="AllApps" /></td>
  <td><span data-ttu-id="59098-200">E71D</span><span class="sxs-lookup"><span data-stu-id="59098-200">E71D</span></span></td>
  <td><span data-ttu-id="59098-201">AllApps</span><span class="sxs-lookup"><span data-stu-id="59098-201">AllApps</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71E.png" width="32" height="32" alt="Zoom" /></td>
  <td><span data-ttu-id="59098-202">E71E</span><span class="sxs-lookup"><span data-stu-id="59098-202">E71E</span></span></td>
  <td><span data-ttu-id="59098-203">ズーム</span><span class="sxs-lookup"><span data-stu-id="59098-203">Zoom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E71F.png" width="32" height="32" alt="ZoomOut" /></td>
  <td><span data-ttu-id="59098-204">E71F</span><span class="sxs-lookup"><span data-stu-id="59098-204">E71F</span></span></td>
  <td><span data-ttu-id="59098-205">ZoomOut</span><span class="sxs-lookup"><span data-stu-id="59098-205">ZoomOut</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E720.png" width="32" height="32" alt="Microphone" /></td>
  <td><span data-ttu-id="59098-206">E720</span><span class="sxs-lookup"><span data-stu-id="59098-206">E720</span></span></td>
  <td><span data-ttu-id="59098-207">マイク</span><span class="sxs-lookup"><span data-stu-id="59098-207">Microphone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E721.png" width="32" height="32" alt="Search" /></td>
  <td><span data-ttu-id="59098-208">E721</span><span class="sxs-lookup"><span data-stu-id="59098-208">E721</span></span></td>
  <td><span data-ttu-id="59098-209">検索</span><span class="sxs-lookup"><span data-stu-id="59098-209">Search</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E722.png" width="32" height="32" alt="Camera" /></td>
  <td><span data-ttu-id="59098-210">E722</span><span class="sxs-lookup"><span data-stu-id="59098-210">E722</span></span></td>
  <td><span data-ttu-id="59098-211">Camera</span><span class="sxs-lookup"><span data-stu-id="59098-211">Camera</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E723.png" width="32" height="32" alt="Attach" /></td>
  <td><span data-ttu-id="59098-212">E723</span><span class="sxs-lookup"><span data-stu-id="59098-212">E723</span></span></td>
  <td><span data-ttu-id="59098-213">Attach</span><span class="sxs-lookup"><span data-stu-id="59098-213">Attach</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E724.png" width="32" height="32" alt="Send" /></td>
  <td><span data-ttu-id="59098-214">E724</span><span class="sxs-lookup"><span data-stu-id="59098-214">E724</span></span></td>
  <td><span data-ttu-id="59098-215">Send</span><span class="sxs-lookup"><span data-stu-id="59098-215">Send</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E725.png" width="32" height="32" alt="SendFill" /></td>
  <td><span data-ttu-id="59098-216">E725</span><span class="sxs-lookup"><span data-stu-id="59098-216">E725</span></span></td>
  <td><span data-ttu-id="59098-217">SendFill</span><span class="sxs-lookup"><span data-stu-id="59098-217">SendFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E726.png" width="32" height="32" alt="WalkSolid" /></td>
  <td><span data-ttu-id="59098-218">E726</span><span class="sxs-lookup"><span data-stu-id="59098-218">E726</span></span></td>
  <td><span data-ttu-id="59098-219">WalkSolid</span><span class="sxs-lookup"><span data-stu-id="59098-219">WalkSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E727.png" width="32" height="32" alt="InPrivate" /></td>
  <td><span data-ttu-id="59098-220">E727</span><span class="sxs-lookup"><span data-stu-id="59098-220">E727</span></span></td>
  <td><span data-ttu-id="59098-221">InPrivate</span><span class="sxs-lookup"><span data-stu-id="59098-221">InPrivate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E728.png" width="32" height="32" alt="FavoriteList" /></td>
  <td><span data-ttu-id="59098-222">E728</span><span class="sxs-lookup"><span data-stu-id="59098-222">E728</span></span></td>
  <td><span data-ttu-id="59098-223">FavoriteList</span><span class="sxs-lookup"><span data-stu-id="59098-223">FavoriteList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E729.png" width="32" height="32" alt="PageSolid" /></td>
  <td><span data-ttu-id="59098-224">E729</span><span class="sxs-lookup"><span data-stu-id="59098-224">E729</span></span></td>
  <td><span data-ttu-id="59098-225">PageSolid</span><span class="sxs-lookup"><span data-stu-id="59098-225">PageSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72A.png" width="32" height="32" alt="Forward" /></td>
  <td><span data-ttu-id="59098-226">E72A</span><span class="sxs-lookup"><span data-stu-id="59098-226">E72A</span></span></td>
  <td><span data-ttu-id="59098-227">Forward</span><span class="sxs-lookup"><span data-stu-id="59098-227">Forward</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72B.png" width="32" height="32" alt="Back" /></td>
  <td><span data-ttu-id="59098-228">E72B</span><span class="sxs-lookup"><span data-stu-id="59098-228">E72B</span></span></td>
  <td><span data-ttu-id="59098-229">Back</span><span class="sxs-lookup"><span data-stu-id="59098-229">Back</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72C.png" width="32" height="32" alt="Refresh" /></td>
  <td><span data-ttu-id="59098-230">E72C</span><span class="sxs-lookup"><span data-stu-id="59098-230">E72C</span></span></td>
  <td><span data-ttu-id="59098-231">Refresh</span><span class="sxs-lookup"><span data-stu-id="59098-231">Refresh</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72D.png" width="32" height="32" alt="Share" /></td>
  <td><span data-ttu-id="59098-232">E72D</span><span class="sxs-lookup"><span data-stu-id="59098-232">E72D</span></span></td>
  <td><span data-ttu-id="59098-233">Share</span><span class="sxs-lookup"><span data-stu-id="59098-233">Share</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E72E.png" width="32" height="32" alt="Lock" /></td>
  <td><span data-ttu-id="59098-234">E72E</span><span class="sxs-lookup"><span data-stu-id="59098-234">E72E</span></span></td>
  <td><span data-ttu-id="59098-235">Lock</span><span class="sxs-lookup"><span data-stu-id="59098-235">Lock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E730.png" width="32" height="32" alt="ReportHacked" /></td>
  <td><span data-ttu-id="59098-236">E730</span><span class="sxs-lookup"><span data-stu-id="59098-236">E730</span></span></td>
  <td><span data-ttu-id="59098-237">ReportHacked</span><span class="sxs-lookup"><span data-stu-id="59098-237">ReportHacked</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E731.png" width="32" height="32" alt="EMI" /></td>
  <td><span data-ttu-id="59098-238">E731</span><span class="sxs-lookup"><span data-stu-id="59098-238">E731</span></span></td>
  <td><span data-ttu-id="59098-239">EMI</span><span class="sxs-lookup"><span data-stu-id="59098-239">EMI</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E734.png" width="32" height="32" alt="FavoriteStar" /></td>
  <td><span data-ttu-id="59098-240">E734</span><span class="sxs-lookup"><span data-stu-id="59098-240">E734</span></span></td>
  <td><span data-ttu-id="59098-241">FavoriteStar</span><span class="sxs-lookup"><span data-stu-id="59098-241">FavoriteStar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E735.png" width="32" height="32" alt="FavoriteStarFill" /></td>
  <td><span data-ttu-id="59098-242">E735</span><span class="sxs-lookup"><span data-stu-id="59098-242">E735</span></span></td>
  <td><span data-ttu-id="59098-243">FavoriteStarFill</span><span class="sxs-lookup"><span data-stu-id="59098-243">FavoriteStarFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E737.png" width="32" height="32" alt="Favicon" /></td>
  <td><span data-ttu-id="59098-244">E737</span><span class="sxs-lookup"><span data-stu-id="59098-244">E737</span></span></td>
  <td><span data-ttu-id="59098-245">Favicon</span><span class="sxs-lookup"><span data-stu-id="59098-245">Favicon</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E738.png" width="32" height="32" alt="Remove" /></td>
  <td><span data-ttu-id="59098-246">E738</span><span class="sxs-lookup"><span data-stu-id="59098-246">E738</span></span></td>
  <td><span data-ttu-id="59098-247">Remove</span><span class="sxs-lookup"><span data-stu-id="59098-247">Remove</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E739.png" width="32" height="32" alt="Checkbox" /></td>
  <td><span data-ttu-id="59098-248">E739</span><span class="sxs-lookup"><span data-stu-id="59098-248">E739</span></span></td>
  <td><span data-ttu-id="59098-249">チェックボックス</span><span class="sxs-lookup"><span data-stu-id="59098-249">Checkbox</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73A.png" width="32" height="32" alt="CheckboxComposite" /></td>
  <td><span data-ttu-id="59098-250">E73A</span><span class="sxs-lookup"><span data-stu-id="59098-250">E73A</span></span></td>
  <td><span data-ttu-id="59098-251">CheckboxComposite</span><span class="sxs-lookup"><span data-stu-id="59098-251">CheckboxComposite</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73B.png" width="32" height="32" alt="CheckboxFill" /></td>
  <td><span data-ttu-id="59098-252">E73B</span><span class="sxs-lookup"><span data-stu-id="59098-252">E73B</span></span></td>
  <td><span data-ttu-id="59098-253">CheckboxFill</span><span class="sxs-lookup"><span data-stu-id="59098-253">CheckboxFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73C.png" width="32" height="32" alt="CheckboxIndeterminate" /></td>
  <td><span data-ttu-id="59098-254">E73C</span><span class="sxs-lookup"><span data-stu-id="59098-254">E73C</span></span></td>
  <td><span data-ttu-id="59098-255">CheckboxIndeterminate</span><span class="sxs-lookup"><span data-stu-id="59098-255">CheckboxIndeterminate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73D.png" width="32" height="32" alt="CheckboxCompositeReversed" /></td>
  <td><span data-ttu-id="59098-256">E73D</span><span class="sxs-lookup"><span data-stu-id="59098-256">E73D</span></span></td>
  <td><span data-ttu-id="59098-257">CheckboxCompositeReversed</span><span class="sxs-lookup"><span data-stu-id="59098-257">CheckboxCompositeReversed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73E.png" width="32" height="32" alt="CheckMark" /></td>
  <td><span data-ttu-id="59098-258">E73E</span><span class="sxs-lookup"><span data-stu-id="59098-258">E73E</span></span></td>
  <td><span data-ttu-id="59098-259">CheckMark</span><span class="sxs-lookup"><span data-stu-id="59098-259">CheckMark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E73F.png" width="32" height="32" alt="BackToWindow" /></td>
  <td><span data-ttu-id="59098-260">E73F</span><span class="sxs-lookup"><span data-stu-id="59098-260">E73F</span></span></td>
  <td><span data-ttu-id="59098-261">BackToWindow</span><span class="sxs-lookup"><span data-stu-id="59098-261">BackToWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E740.png" width="32" height="32" alt="FullScreen" /></td>
  <td><span data-ttu-id="59098-262">E740</span><span class="sxs-lookup"><span data-stu-id="59098-262">E740</span></span></td>
  <td><span data-ttu-id="59098-263">FullScreen</span><span class="sxs-lookup"><span data-stu-id="59098-263">FullScreen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E741.png" width="32" height="32" alt="ResizeTouchLarger" /></td>
  <td><span data-ttu-id="59098-264">E741</span><span class="sxs-lookup"><span data-stu-id="59098-264">E741</span></span></td>
  <td><span data-ttu-id="59098-265">ResizeTouchLarger</span><span class="sxs-lookup"><span data-stu-id="59098-265">ResizeTouchLarger</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E742.png" width="32" height="32" alt="ResizeTouchSmaller" /></td>
  <td><span data-ttu-id="59098-266">E742</span><span class="sxs-lookup"><span data-stu-id="59098-266">E742</span></span></td>
  <td><span data-ttu-id="59098-267">ResizeTouchSmaller</span><span class="sxs-lookup"><span data-stu-id="59098-267">ResizeTouchSmaller</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E743.png" width="32" height="32" alt="ResizeMouseSmall" /></td>
  <td><span data-ttu-id="59098-268">E743</span><span class="sxs-lookup"><span data-stu-id="59098-268">E743</span></span></td>
  <td><span data-ttu-id="59098-269">ResizeMouseSmall</span><span class="sxs-lookup"><span data-stu-id="59098-269">ResizeMouseSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E744.png" width="32" height="32" alt="ResizeMouseMedium" /></td>
  <td><span data-ttu-id="59098-270">E744</span><span class="sxs-lookup"><span data-stu-id="59098-270">E744</span></span></td>
  <td><span data-ttu-id="59098-271">ResizeMouseMedium</span><span class="sxs-lookup"><span data-stu-id="59098-271">ResizeMouseMedium</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E745.png" width="32" height="32" alt="ResizeMouseWide" /></td>
  <td><span data-ttu-id="59098-272">E745</span><span class="sxs-lookup"><span data-stu-id="59098-272">E745</span></span></td>
  <td><span data-ttu-id="59098-273">ResizeMouseWide</span><span class="sxs-lookup"><span data-stu-id="59098-273">ResizeMouseWide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E746.png" width="32" height="32" alt="ResizeMouseTall" /></td>
  <td><span data-ttu-id="59098-274">E746</span><span class="sxs-lookup"><span data-stu-id="59098-274">E746</span></span></td>
  <td><span data-ttu-id="59098-275">ResizeMouseTall</span><span class="sxs-lookup"><span data-stu-id="59098-275">ResizeMouseTall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E747.png" width="32" height="32" alt="ResizeMouseLarge" /></td>
  <td><span data-ttu-id="59098-276">E747</span><span class="sxs-lookup"><span data-stu-id="59098-276">E747</span></span></td>
  <td><span data-ttu-id="59098-277">ResizeMouseLarge</span><span class="sxs-lookup"><span data-stu-id="59098-277">ResizeMouseLarge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E748.png" width="32" height="32" alt="SwitchUser" /></td>
  <td><span data-ttu-id="59098-278">E748</span><span class="sxs-lookup"><span data-stu-id="59098-278">E748</span></span></td>
  <td><span data-ttu-id="59098-279">SwitchUser</span><span class="sxs-lookup"><span data-stu-id="59098-279">SwitchUser</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E749.png" width="32" height="32" alt="Print" /></td>
  <td><span data-ttu-id="59098-280">E749</span><span class="sxs-lookup"><span data-stu-id="59098-280">E749</span></span></td>
  <td><span data-ttu-id="59098-281">印刷</span><span class="sxs-lookup"><span data-stu-id="59098-281">Print</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74A.png" width="32" height="32" alt="Up" /></td>
  <td><span data-ttu-id="59098-282">E74A</span><span class="sxs-lookup"><span data-stu-id="59098-282">E74A</span></span></td>
  <td><span data-ttu-id="59098-283">Up</span><span class="sxs-lookup"><span data-stu-id="59098-283">Up</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74B.png" width="32" height="32" alt="Down" /></td>
  <td><span data-ttu-id="59098-284">E74B</span><span class="sxs-lookup"><span data-stu-id="59098-284">E74B</span></span></td>
  <td><span data-ttu-id="59098-285">Down</span><span class="sxs-lookup"><span data-stu-id="59098-285">Down</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74C.png" width="32" height="32" alt="OEM" /></td>
  <td><span data-ttu-id="59098-286">E74C</span><span class="sxs-lookup"><span data-stu-id="59098-286">E74C</span></span></td>
  <td><span data-ttu-id="59098-287">OEM</span><span class="sxs-lookup"><span data-stu-id="59098-287">OEM</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74D.png" width="32" height="32" alt="Delete" /></td>
  <td><span data-ttu-id="59098-288">E74D</span><span class="sxs-lookup"><span data-stu-id="59098-288">E74D</span></span></td>
  <td><span data-ttu-id="59098-289">削除</span><span class="sxs-lookup"><span data-stu-id="59098-289">Delete</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74E.png" width="32" height="32" alt="Save" /></td>
  <td><span data-ttu-id="59098-290">E74E</span><span class="sxs-lookup"><span data-stu-id="59098-290">E74E</span></span></td>
  <td><span data-ttu-id="59098-291">Save</span><span class="sxs-lookup"><span data-stu-id="59098-291">Save</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E74F.png" width="32" height="32" alt="Mute" /></td>
  <td><span data-ttu-id="59098-292">E74F</span><span class="sxs-lookup"><span data-stu-id="59098-292">E74F</span></span></td>
  <td><span data-ttu-id="59098-293">Mute</span><span class="sxs-lookup"><span data-stu-id="59098-293">Mute</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E750.png" width="32" height="32" alt="BackSpaceQWERTY" /></td>
  <td><span data-ttu-id="59098-294">E750</span><span class="sxs-lookup"><span data-stu-id="59098-294">E750</span></span></td>
  <td><span data-ttu-id="59098-295">BackSpaceQWERTY</span><span class="sxs-lookup"><span data-stu-id="59098-295">BackSpaceQWERTY</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E751.png" width="32" height="32" alt="ReturnKey" /></td>
  <td><span data-ttu-id="59098-296">E751</span><span class="sxs-lookup"><span data-stu-id="59098-296">E751</span></span></td>
  <td><span data-ttu-id="59098-297">ReturnKey</span><span class="sxs-lookup"><span data-stu-id="59098-297">ReturnKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E752.png" width="32" height="32" alt="UpArrowShiftKey" /></td>
  <td><span data-ttu-id="59098-298">E752</span><span class="sxs-lookup"><span data-stu-id="59098-298">E752</span></span></td>
  <td><span data-ttu-id="59098-299">UpArrowShiftKey</span><span class="sxs-lookup"><span data-stu-id="59098-299">UpArrowShiftKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E753.png" width="32" height="32" alt="Cloud" /></td>
  <td><span data-ttu-id="59098-300">E753</span><span class="sxs-lookup"><span data-stu-id="59098-300">E753</span></span></td>
  <td><span data-ttu-id="59098-301">Cloud</span><span class="sxs-lookup"><span data-stu-id="59098-301">Cloud</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E754.png" width="32" height="32" alt="Flashlight" /></td>
  <td><span data-ttu-id="59098-302">E754</span><span class="sxs-lookup"><span data-stu-id="59098-302">E754</span></span></td>
  <td><span data-ttu-id="59098-303">Flashlight</span><span class="sxs-lookup"><span data-stu-id="59098-303">Flashlight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E755.png" width="32" height="32" alt="RotationLock" /></td>
  <td><span data-ttu-id="59098-304">E755</span><span class="sxs-lookup"><span data-stu-id="59098-304">E755</span></span></td>
  <td><span data-ttu-id="59098-305">RotationLock</span><span class="sxs-lookup"><span data-stu-id="59098-305">RotationLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E756.png" width="32" height="32" alt="CommandPrompt" /></td>
  <td><span data-ttu-id="59098-306">E756</span><span class="sxs-lookup"><span data-stu-id="59098-306">E756</span></span></td>
  <td><span data-ttu-id="59098-307">CommandPrompt</span><span class="sxs-lookup"><span data-stu-id="59098-307">CommandPrompt</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E759.png" width="32" height="32" alt="SIPMove" /></td>
  <td><span data-ttu-id="59098-308">E759</span><span class="sxs-lookup"><span data-stu-id="59098-308">E759</span></span></td>
  <td><span data-ttu-id="59098-309">SIPMove</span><span class="sxs-lookup"><span data-stu-id="59098-309">SIPMove</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75A.png" width="32" height="32" alt="SIPUndock" /></td>
  <td><span data-ttu-id="59098-310">E75A</span><span class="sxs-lookup"><span data-stu-id="59098-310">E75A</span></span></td>
  <td><span data-ttu-id="59098-311">SIPUndock</span><span class="sxs-lookup"><span data-stu-id="59098-311">SIPUndock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75B.png" width="32" height="32" alt="SIPRedock" /></td>
  <td><span data-ttu-id="59098-312">E75B</span><span class="sxs-lookup"><span data-stu-id="59098-312">E75B</span></span></td>
  <td><span data-ttu-id="59098-313">SIPRedock</span><span class="sxs-lookup"><span data-stu-id="59098-313">SIPRedock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75C.png" width="32" height="32" alt="EraseTool" /></td>
  <td><span data-ttu-id="59098-314">E75C</span><span class="sxs-lookup"><span data-stu-id="59098-314">E75C</span></span></td>
  <td><span data-ttu-id="59098-315">EraseTool</span><span class="sxs-lookup"><span data-stu-id="59098-315">EraseTool</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75D.png" width="32" height="32" alt="UnderscoreSpace" /></td>
  <td><span data-ttu-id="59098-316">E75D</span><span class="sxs-lookup"><span data-stu-id="59098-316">E75D</span></span></td>
  <td><span data-ttu-id="59098-317">UnderscoreSpace</span><span class="sxs-lookup"><span data-stu-id="59098-317">UnderscoreSpace</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75E.png" width="32" height="32" alt="GripperTool" /></td>
  <td><span data-ttu-id="59098-318">E75E</span><span class="sxs-lookup"><span data-stu-id="59098-318">E75E</span></span></td>
  <td><span data-ttu-id="59098-319">GripperTool</span><span class="sxs-lookup"><span data-stu-id="59098-319">GripperTool</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E75F.png" width="32" height="32" alt="Dialpad" /></td>
  <td><span data-ttu-id="59098-320">E75F</span><span class="sxs-lookup"><span data-stu-id="59098-320">E75F</span></span></td>
  <td><span data-ttu-id="59098-321">Dialpad</span><span class="sxs-lookup"><span data-stu-id="59098-321">Dialpad</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E760.png" width="32" height="32" alt="PageLeft" /></td>
  <td><span data-ttu-id="59098-322">E760</span><span class="sxs-lookup"><span data-stu-id="59098-322">E760</span></span></td>
  <td><span data-ttu-id="59098-323">PageLeft</span><span class="sxs-lookup"><span data-stu-id="59098-323">PageLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E761.png" width="32" height="32" alt="PageRight" /></td>
  <td><span data-ttu-id="59098-324">E761</span><span class="sxs-lookup"><span data-stu-id="59098-324">E761</span></span></td>
  <td><span data-ttu-id="59098-325">PageRight</span><span class="sxs-lookup"><span data-stu-id="59098-325">PageRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E762.png" width="32" height="32" alt="MultiSelect" /></td>
  <td><span data-ttu-id="59098-326">E762</span><span class="sxs-lookup"><span data-stu-id="59098-326">E762</span></span></td>
  <td><span data-ttu-id="59098-327">MultiSelect</span><span class="sxs-lookup"><span data-stu-id="59098-327">MultiSelect</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E763.png" width="32" height="32" alt="KeyboardLeftHanded" /></td>
  <td><span data-ttu-id="59098-328">E763</span><span class="sxs-lookup"><span data-stu-id="59098-328">E763</span></span></td>
  <td><span data-ttu-id="59098-329">KeyboardLeftHanded</span><span class="sxs-lookup"><span data-stu-id="59098-329">KeyboardLeftHanded</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E764.png" width="32" height="32" alt="KeyboardRightHanded" /></td>
  <td><span data-ttu-id="59098-330">E764</span><span class="sxs-lookup"><span data-stu-id="59098-330">E764</span></span></td>
  <td><span data-ttu-id="59098-331">KeyboardRightHanded</span><span class="sxs-lookup"><span data-stu-id="59098-331">KeyboardRightHanded</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E765.png" width="32" height="32" alt="KeyboardClassic" /></td>
  <td><span data-ttu-id="59098-332">E765</span><span class="sxs-lookup"><span data-stu-id="59098-332">E765</span></span></td>
  <td><span data-ttu-id="59098-333">KeyboardClassic</span><span class="sxs-lookup"><span data-stu-id="59098-333">KeyboardClassic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E766.png" width="32" height="32" alt="KeyboardSplit" /></td>
  <td><span data-ttu-id="59098-334">E766</span><span class="sxs-lookup"><span data-stu-id="59098-334">E766</span></span></td>
  <td><span data-ttu-id="59098-335">KeyboardSplit</span><span class="sxs-lookup"><span data-stu-id="59098-335">KeyboardSplit</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E767.png" width="32" height="32" alt="Volume" /></td>
  <td><span data-ttu-id="59098-336">E767</span><span class="sxs-lookup"><span data-stu-id="59098-336">E767</span></span></td>
  <td><span data-ttu-id="59098-337">[ボリューム]</span><span class="sxs-lookup"><span data-stu-id="59098-337">Volume</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E768.png" width="32" height="32" alt="Play" /></td>
  <td><span data-ttu-id="59098-338">E768</span><span class="sxs-lookup"><span data-stu-id="59098-338">E768</span></span></td>
  <td><span data-ttu-id="59098-339">Play</span><span class="sxs-lookup"><span data-stu-id="59098-339">Play</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E769.png" width="32" height="32" alt="Pause" /></td>
  <td><span data-ttu-id="59098-340">E769</span><span class="sxs-lookup"><span data-stu-id="59098-340">E769</span></span></td>
  <td><span data-ttu-id="59098-341">一時停止</span><span class="sxs-lookup"><span data-stu-id="59098-341">Pause</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76B.png" width="32" height="32" alt="ChevronLeft" /></td>
  <td><span data-ttu-id="59098-342">E76B</span><span class="sxs-lookup"><span data-stu-id="59098-342">E76B</span></span></td>
  <td><span data-ttu-id="59098-343">ChevronLeft</span><span class="sxs-lookup"><span data-stu-id="59098-343">ChevronLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76C.png" width="32" height="32" alt="ChevronRight" /></td>
  <td><span data-ttu-id="59098-344">E76C</span><span class="sxs-lookup"><span data-stu-id="59098-344">E76C</span></span></td>
  <td><span data-ttu-id="59098-345">ChevronRight</span><span class="sxs-lookup"><span data-stu-id="59098-345">ChevronRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76D.png" width="32" height="32" alt="InkingTool" /></td>
  <td><span data-ttu-id="59098-346">E76D</span><span class="sxs-lookup"><span data-stu-id="59098-346">E76D</span></span></td>
  <td><span data-ttu-id="59098-347">InkingTool</span><span class="sxs-lookup"><span data-stu-id="59098-347">InkingTool</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76E.png" width="32" height="32" alt="Emoji2" /></td>
  <td><span data-ttu-id="59098-348">E76E</span><span class="sxs-lookup"><span data-stu-id="59098-348">E76E</span></span></td>
  <td><span data-ttu-id="59098-349">Emoji2</span><span class="sxs-lookup"><span data-stu-id="59098-349">Emoji2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E76F.png" width="32" height="32" alt="GripperBarHorizontal" /></td>
  <td><span data-ttu-id="59098-350">E76F</span><span class="sxs-lookup"><span data-stu-id="59098-350">E76F</span></span></td>
  <td><span data-ttu-id="59098-351">GripperBarHorizontal</span><span class="sxs-lookup"><span data-stu-id="59098-351">GripperBarHorizontal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E770.png" width="32" height="32" alt="System" /></td>
  <td><span data-ttu-id="59098-352">E770</span><span class="sxs-lookup"><span data-stu-id="59098-352">E770</span></span></td>
  <td><span data-ttu-id="59098-353">System</span><span class="sxs-lookup"><span data-stu-id="59098-353">System</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E771.png" width="32" height="32" alt="Personalize" /></td>
  <td><span data-ttu-id="59098-354">E771</span><span class="sxs-lookup"><span data-stu-id="59098-354">E771</span></span></td>
  <td><span data-ttu-id="59098-355">Personalize</span><span class="sxs-lookup"><span data-stu-id="59098-355">Personalize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E772.png" width="32" height="32" alt="Devices" /></td>
  <td><span data-ttu-id="59098-356">E772</span><span class="sxs-lookup"><span data-stu-id="59098-356">E772</span></span></td>
  <td><span data-ttu-id="59098-357">デバイス</span><span class="sxs-lookup"><span data-stu-id="59098-357">Devices</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E773.png" width="32" height="32" alt="SearchAndApps" /></td>
  <td><span data-ttu-id="59098-358">E773</span><span class="sxs-lookup"><span data-stu-id="59098-358">E773</span></span></td>
  <td><span data-ttu-id="59098-359">SearchAndApps</span><span class="sxs-lookup"><span data-stu-id="59098-359">SearchAndApps</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E774.png" width="32" height="32" alt="Globe" /></td>
  <td><span data-ttu-id="59098-360">E774</span><span class="sxs-lookup"><span data-stu-id="59098-360">E774</span></span></td>
  <td><span data-ttu-id="59098-361">Globe</span><span class="sxs-lookup"><span data-stu-id="59098-361">Globe</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E775.png" width="32" height="32" alt="TimeLanguage" /></td>
  <td><span data-ttu-id="59098-362">E775</span><span class="sxs-lookup"><span data-stu-id="59098-362">E775</span></span></td>
  <td><span data-ttu-id="59098-363">TimeLanguage</span><span class="sxs-lookup"><span data-stu-id="59098-363">TimeLanguage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E776.png" width="32" height="32" alt="EaseOfAccess" /></td>
  <td><span data-ttu-id="59098-364">E776</span><span class="sxs-lookup"><span data-stu-id="59098-364">E776</span></span></td>
  <td><span data-ttu-id="59098-365">EaseOfAccess</span><span class="sxs-lookup"><span data-stu-id="59098-365">EaseOfAccess</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E777.png" width="32" height="32" alt="UpdateRestore" /></td>
  <td><span data-ttu-id="59098-366">E777</span><span class="sxs-lookup"><span data-stu-id="59098-366">E777</span></span></td>
  <td><span data-ttu-id="59098-367">UpdateRestore</span><span class="sxs-lookup"><span data-stu-id="59098-367">UpdateRestore</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E778.png" width="32" height="32" alt="HangUp" /></td>
  <td><span data-ttu-id="59098-368">E778</span><span class="sxs-lookup"><span data-stu-id="59098-368">E778</span></span></td>
  <td><span data-ttu-id="59098-369">HangUp</span><span class="sxs-lookup"><span data-stu-id="59098-369">HangUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E779.png" width="32" height="32" alt="ContactInfo" /></td>
  <td><span data-ttu-id="59098-370">E779</span><span class="sxs-lookup"><span data-stu-id="59098-370">E779</span></span></td>
  <td><span data-ttu-id="59098-371">ContactInfo</span><span class="sxs-lookup"><span data-stu-id="59098-371">ContactInfo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E77A.png" width="32" height="32" alt="Unpin" /></td>
  <td><span data-ttu-id="59098-372">E77A</span><span class="sxs-lookup"><span data-stu-id="59098-372">E77A</span></span></td>
  <td><span data-ttu-id="59098-373">Unpin</span><span class="sxs-lookup"><span data-stu-id="59098-373">Unpin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E77B.png" width="32" height="32" alt="Contact" /></td>
  <td><span data-ttu-id="59098-374">E77B</span><span class="sxs-lookup"><span data-stu-id="59098-374">E77B</span></span></td>
  <td><span data-ttu-id="59098-375">Contact</span><span class="sxs-lookup"><span data-stu-id="59098-375">Contact</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E77C.png" width="32" height="32" alt="Memo" /></td>
  <td><span data-ttu-id="59098-376">E77C</span><span class="sxs-lookup"><span data-stu-id="59098-376">E77C</span></span></td>
  <td><span data-ttu-id="59098-377">Memo</span><span class="sxs-lookup"><span data-stu-id="59098-377">Memo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E77F.png" width="32" height="32" alt="Paste" /></td>
  <td><span data-ttu-id="59098-378">E77F</span><span class="sxs-lookup"><span data-stu-id="59098-378">E77F</span></span></td>
  <td><span data-ttu-id="59098-379">Paste</span><span class="sxs-lookup"><span data-stu-id="59098-379">Paste</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E780.png" width="32" height="32" alt="PhoneBook" /></td>
  <td><span data-ttu-id="59098-380">E780</span><span class="sxs-lookup"><span data-stu-id="59098-380">E780</span></span></td>
  <td><span data-ttu-id="59098-381">PhoneBook</span><span class="sxs-lookup"><span data-stu-id="59098-381">PhoneBook</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E781.png" width="32" height="32" alt="LEDLight" /></td>
  <td><span data-ttu-id="59098-382">E781</span><span class="sxs-lookup"><span data-stu-id="59098-382">E781</span></span></td>
  <td><span data-ttu-id="59098-383">LEDLight</span><span class="sxs-lookup"><span data-stu-id="59098-383">LEDLight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E783.png" width="32" height="32" alt="Error" /></td>
  <td><span data-ttu-id="59098-384">E783</span><span class="sxs-lookup"><span data-stu-id="59098-384">E783</span></span></td>
  <td><span data-ttu-id="59098-385">エラー</span><span class="sxs-lookup"><span data-stu-id="59098-385">Error</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E784.png" width="32" height="32" alt="GripperBarVertical" /></td>
  <td><span data-ttu-id="59098-386">E784</span><span class="sxs-lookup"><span data-stu-id="59098-386">E784</span></span></td>
  <td><span data-ttu-id="59098-387">GripperBarVertical</span><span class="sxs-lookup"><span data-stu-id="59098-387">GripperBarVertical</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E785.png" width="32" height="32" alt="Unlock" /></td>
  <td><span data-ttu-id="59098-388">E785</span><span class="sxs-lookup"><span data-stu-id="59098-388">E785</span></span></td>
  <td><span data-ttu-id="59098-389">Unlock</span><span class="sxs-lookup"><span data-stu-id="59098-389">Unlock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E786.png" width="32" height="32" alt="Slideshow" /></td>
  <td><span data-ttu-id="59098-390">E786</span><span class="sxs-lookup"><span data-stu-id="59098-390">E786</span></span></td>
  <td><span data-ttu-id="59098-391">Slideshow</span><span class="sxs-lookup"><span data-stu-id="59098-391">Slideshow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E787.png" width="32" height="32" alt="Calendar" /></td>
  <td><span data-ttu-id="59098-392">E787</span><span class="sxs-lookup"><span data-stu-id="59098-392">E787</span></span></td>
  <td><span data-ttu-id="59098-393">カレンダー</span><span class="sxs-lookup"><span data-stu-id="59098-393">Calendar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E788.png" width="32" height="32" alt="GripperResize" /></td>
  <td><span data-ttu-id="59098-394">E788</span><span class="sxs-lookup"><span data-stu-id="59098-394">E788</span></span></td>
  <td><span data-ttu-id="59098-395">GripperResize</span><span class="sxs-lookup"><span data-stu-id="59098-395">GripperResize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E789.png" width="32" height="32" alt="Megaphone" /></td>
  <td><span data-ttu-id="59098-396">E789</span><span class="sxs-lookup"><span data-stu-id="59098-396">E789</span></span></td>
  <td><span data-ttu-id="59098-397">Megaphone</span><span class="sxs-lookup"><span data-stu-id="59098-397">Megaphone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E78A.png" width="32" height="32" alt="Trim" /></td>
  <td><span data-ttu-id="59098-398">E78A</span><span class="sxs-lookup"><span data-stu-id="59098-398">E78A</span></span></td>
  <td><span data-ttu-id="59098-399">Trim</span><span class="sxs-lookup"><span data-stu-id="59098-399">Trim</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E78B.png" width="32" height="32" alt="NewWindow" /></td>
  <td><span data-ttu-id="59098-400">E78B</span><span class="sxs-lookup"><span data-stu-id="59098-400">E78B</span></span></td>
  <td><span data-ttu-id="59098-401">NewWindow</span><span class="sxs-lookup"><span data-stu-id="59098-401">NewWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E78C.png" width="32" height="32" alt="SaveLocal" /></td>
  <td><span data-ttu-id="59098-402">E78C</span><span class="sxs-lookup"><span data-stu-id="59098-402">E78C</span></span></td>
  <td><span data-ttu-id="59098-403">SaveLocal</span><span class="sxs-lookup"><span data-stu-id="59098-403">SaveLocal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E790.png" width="32" height="32" alt="Color" /></td>
  <td><span data-ttu-id="59098-404">E790</span><span class="sxs-lookup"><span data-stu-id="59098-404">E790</span></span></td>
  <td><span data-ttu-id="59098-405">色</span><span class="sxs-lookup"><span data-stu-id="59098-405">Color</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E791.png" width="32" height="32" alt="DataSense" /></td>
  <td><span data-ttu-id="59098-406">E791</span><span class="sxs-lookup"><span data-stu-id="59098-406">E791</span></span></td>
  <td><span data-ttu-id="59098-407">DataSense</span><span class="sxs-lookup"><span data-stu-id="59098-407">DataSense</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E792.png" width="32" height="32" alt="SaveAs" /></td>
  <td><span data-ttu-id="59098-408">E792</span><span class="sxs-lookup"><span data-stu-id="59098-408">E792</span></span></td>
  <td><span data-ttu-id="59098-409">SaveAs</span><span class="sxs-lookup"><span data-stu-id="59098-409">SaveAs</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E793.png" width="32" height="32" alt="Light" /></td>
  <td><span data-ttu-id="59098-410">E793</span><span class="sxs-lookup"><span data-stu-id="59098-410">E793</span></span></td>
  <td><span data-ttu-id="59098-411">明るい</span><span class="sxs-lookup"><span data-stu-id="59098-411">Light</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E799.png" width="32" height="32" alt="AspectRatio" /></td>
  <td><span data-ttu-id="59098-412">E799</span><span class="sxs-lookup"><span data-stu-id="59098-412">E799</span></span></td>
  <td><span data-ttu-id="59098-413">AspectRatio</span><span class="sxs-lookup"><span data-stu-id="59098-413">AspectRatio</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7A5.png" width="32" height="32" alt="DataSenseBar" /></td>
  <td><span data-ttu-id="59098-414">E7A5</span><span class="sxs-lookup"><span data-stu-id="59098-414">E7A5</span></span></td>
  <td><span data-ttu-id="59098-415">DataSenseBar</span><span class="sxs-lookup"><span data-stu-id="59098-415">DataSenseBar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7A6.png" width="32" height="32" alt="Redo" /></td>
  <td><span data-ttu-id="59098-416">E7A6</span><span class="sxs-lookup"><span data-stu-id="59098-416">E7A6</span></span></td>
  <td><span data-ttu-id="59098-417">Redo</span><span class="sxs-lookup"><span data-stu-id="59098-417">Redo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7A7.png" width="32" height="32" alt="Undo" /></td>
  <td><span data-ttu-id="59098-418">E7A7</span><span class="sxs-lookup"><span data-stu-id="59098-418">E7A7</span></span></td>
  <td><span data-ttu-id="59098-419">元に戻す</span><span class="sxs-lookup"><span data-stu-id="59098-419">Undo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7A8.png" width="32" height="32" alt="Crop" /></td>
  <td><span data-ttu-id="59098-420">E7A8</span><span class="sxs-lookup"><span data-stu-id="59098-420">E7A8</span></span></td>
  <td><span data-ttu-id="59098-421">Crop</span><span class="sxs-lookup"><span data-stu-id="59098-421">Crop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7AC.png" width="32" height="32" alt="OpenWith" /></td>
  <td><span data-ttu-id="59098-422">E7AC</span><span class="sxs-lookup"><span data-stu-id="59098-422">E7AC</span></span></td>
  <td><span data-ttu-id="59098-423">OpenWith</span><span class="sxs-lookup"><span data-stu-id="59098-423">OpenWith</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7AD.png" width="32" height="32" alt="Rotate" /></td>
  <td><span data-ttu-id="59098-424">E7AD</span><span class="sxs-lookup"><span data-stu-id="59098-424">E7AD</span></span></td>
  <td><span data-ttu-id="59098-425">回転</span><span class="sxs-lookup"><span data-stu-id="59098-425">Rotate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7B3.png" width="32" height="32" alt="RedEye" /></td>
  <td><span data-ttu-id="59098-426">E7B3</span><span class="sxs-lookup"><span data-stu-id="59098-426">E7B3</span></span></td>
  <td><span data-ttu-id="59098-427">RedEye</span><span class="sxs-lookup"><span data-stu-id="59098-427">RedEye</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7B5.png" width="32" height="32" alt="SetlockScreen" /></td>
  <td><span data-ttu-id="59098-428">E7B5</span><span class="sxs-lookup"><span data-stu-id="59098-428">E7B5</span></span></td>
  <td><span data-ttu-id="59098-429">SetlockScreen</span><span class="sxs-lookup"><span data-stu-id="59098-429">SetlockScreen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7B7.png" width="32" height="32" alt="MapPin2" /></td>
  <td><span data-ttu-id="59098-430">E7B7</span><span class="sxs-lookup"><span data-stu-id="59098-430">E7B7</span></span></td>
  <td><span data-ttu-id="59098-431">MapPin2</span><span class="sxs-lookup"><span data-stu-id="59098-431">MapPin2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7B8.png" width="32" height="32" alt="Package" /></td>
  <td><span data-ttu-id="59098-432">E7B8</span><span class="sxs-lookup"><span data-stu-id="59098-432">E7B8</span></span></td>
  <td><span data-ttu-id="59098-433">パッケージ化</span><span class="sxs-lookup"><span data-stu-id="59098-433">Package</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7BA.png" width="32" height="32" alt="Warning" /></td>
  <td><span data-ttu-id="59098-434">E7BA</span><span class="sxs-lookup"><span data-stu-id="59098-434">E7BA</span></span></td>
  <td><span data-ttu-id="59098-435">Warning</span><span class="sxs-lookup"><span data-stu-id="59098-435">Warning</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7BC.png" width="32" height="32" alt="ReadingList" /></td>
  <td><span data-ttu-id="59098-436">E7BC</span><span class="sxs-lookup"><span data-stu-id="59098-436">E7BC</span></span></td>
  <td><span data-ttu-id="59098-437">ReadingList</span><span class="sxs-lookup"><span data-stu-id="59098-437">ReadingList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7BE.png" width="32" height="32" alt="Education" /></td>
  <td><span data-ttu-id="59098-438">E7BE</span><span class="sxs-lookup"><span data-stu-id="59098-438">E7BE</span></span></td>
  <td><span data-ttu-id="59098-439">Education</span><span class="sxs-lookup"><span data-stu-id="59098-439">Education</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7BF.png" width="32" height="32" alt="ShoppingCart" /></td>
  <td><span data-ttu-id="59098-440">E7BF</span><span class="sxs-lookup"><span data-stu-id="59098-440">E7BF</span></span></td>
  <td><span data-ttu-id="59098-441">ShoppingCart</span><span class="sxs-lookup"><span data-stu-id="59098-441">ShoppingCart</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C0.png" width="32" height="32" alt="Train" /></td>
  <td><span data-ttu-id="59098-442">E7C0</span><span class="sxs-lookup"><span data-stu-id="59098-442">E7C0</span></span></td>
  <td><span data-ttu-id="59098-443">Train</span><span class="sxs-lookup"><span data-stu-id="59098-443">Train</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C1.png" width="32" height="32" alt="Flag" /></td>
  <td><span data-ttu-id="59098-444">E7C1</span><span class="sxs-lookup"><span data-stu-id="59098-444">E7C1</span></span></td>
  <td><span data-ttu-id="59098-445">Flag</span><span class="sxs-lookup"><span data-stu-id="59098-445">Flag</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C3.png" width="32" height="32" alt="Page" /></td>
  <td><span data-ttu-id="59098-446">E7C3</span><span class="sxs-lookup"><span data-stu-id="59098-446">E7C3</span></span></td>
  <td><span data-ttu-id="59098-447">ページ</span><span class="sxs-lookup"><span data-stu-id="59098-447">Page</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C4.png" width="32" height="32" alt="TaskView" /></td>
  <td><span data-ttu-id="59098-448">E7C4</span><span class="sxs-lookup"><span data-stu-id="59098-448">E7C4</span></span></td>
  <td><span data-ttu-id="59098-449">TaskView</span><span class="sxs-lookup"><span data-stu-id="59098-449">TaskView</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C5.png" width="32" height="32" alt="BrowsePhotos" /></td>
  <td><span data-ttu-id="59098-450">E7C5</span><span class="sxs-lookup"><span data-stu-id="59098-450">E7C5</span></span></td>
  <td><span data-ttu-id="59098-451">BrowsePhotos</span><span class="sxs-lookup"><span data-stu-id="59098-451">BrowsePhotos</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C6.png" width="32" height="32" alt="HalfStarLeft" /></td>
  <td><span data-ttu-id="59098-452">E7C6</span><span class="sxs-lookup"><span data-stu-id="59098-452">E7C6</span></span></td>
  <td><span data-ttu-id="59098-453">HalfStarLeft</span><span class="sxs-lookup"><span data-stu-id="59098-453">HalfStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C7.png" width="32" height="32" alt="HalfStarRight" /></td>
  <td><span data-ttu-id="59098-454">E7C7</span><span class="sxs-lookup"><span data-stu-id="59098-454">E7C7</span></span></td>
  <td><span data-ttu-id="59098-455">HalfStarRight</span><span class="sxs-lookup"><span data-stu-id="59098-455">HalfStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C8.png" width="32" height="32" alt="Record" /></td>
  <td><span data-ttu-id="59098-456">E7C8</span><span class="sxs-lookup"><span data-stu-id="59098-456">E7C8</span></span></td>
  <td><span data-ttu-id="59098-457">Record</span><span class="sxs-lookup"><span data-stu-id="59098-457">Record</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7C9.png" width="32" height="32" alt="TouchPointer" /></td>
  <td><span data-ttu-id="59098-458">E7C9</span><span class="sxs-lookup"><span data-stu-id="59098-458">E7C9</span></span></td>
  <td><span data-ttu-id="59098-459">TouchPointer</span><span class="sxs-lookup"><span data-stu-id="59098-459">TouchPointer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7DE.png" width="32" height="32" alt="LangJPN" /></td>
  <td><span data-ttu-id="59098-460">E7DE</span><span class="sxs-lookup"><span data-stu-id="59098-460">E7DE</span></span></td>
  <td><span data-ttu-id="59098-461">LangJPN</span><span class="sxs-lookup"><span data-stu-id="59098-461">LangJPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7E3.png" width="32" height="32" alt="Ferry" /></td>
  <td><span data-ttu-id="59098-462">E7E3</span><span class="sxs-lookup"><span data-stu-id="59098-462">E7E3</span></span></td>
  <td><span data-ttu-id="59098-463">Ferry</span><span class="sxs-lookup"><span data-stu-id="59098-463">Ferry</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7E6.png" width="32" height="32" alt="Highlight" /></td>
  <td><span data-ttu-id="59098-464">E7E6</span><span class="sxs-lookup"><span data-stu-id="59098-464">E7E6</span></span></td>
  <td><span data-ttu-id="59098-465">Highlight</span><span class="sxs-lookup"><span data-stu-id="59098-465">Highlight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7E7.png" width="32" height="32" alt="ActionCenterNotification" /></td>
  <td><span data-ttu-id="59098-466">E7E7</span><span class="sxs-lookup"><span data-stu-id="59098-466">E7E7</span></span></td>
  <td><span data-ttu-id="59098-467">ActionCenterNotification</span><span class="sxs-lookup"><span data-stu-id="59098-467">ActionCenterNotification</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7E8.png" width="32" height="32" alt="PowerButton" /></td>
  <td><span data-ttu-id="59098-468">E7E8</span><span class="sxs-lookup"><span data-stu-id="59098-468">E7E8</span></span></td>
  <td><span data-ttu-id="59098-469">PowerButton</span><span class="sxs-lookup"><span data-stu-id="59098-469">PowerButton</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EA.png" width="32" height="32" alt="ResizeTouchNarrower" /></td>
  <td><span data-ttu-id="59098-470">E7EA</span><span class="sxs-lookup"><span data-stu-id="59098-470">E7EA</span></span></td>
  <td><span data-ttu-id="59098-471">ResizeTouchNarrower</span><span class="sxs-lookup"><span data-stu-id="59098-471">ResizeTouchNarrower</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EB.png" width="32" height="32" alt="ResizeTouchShorter" /></td>
  <td><span data-ttu-id="59098-472">E7EB</span><span class="sxs-lookup"><span data-stu-id="59098-472">E7EB</span></span></td>
  <td><span data-ttu-id="59098-473">ResizeTouchShorter</span><span class="sxs-lookup"><span data-stu-id="59098-473">ResizeTouchShorter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EC.png" width="32" height="32" alt="DrivingMode" /></td>
  <td><span data-ttu-id="59098-474">E7EC</span><span class="sxs-lookup"><span data-stu-id="59098-474">E7EC</span></span></td>
  <td><span data-ttu-id="59098-475">DrivingMode</span><span class="sxs-lookup"><span data-stu-id="59098-475">DrivingMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7ED.png" width="32" height="32" alt="RingerSilent" /></td>
  <td><span data-ttu-id="59098-476">E7ED</span><span class="sxs-lookup"><span data-stu-id="59098-476">E7ED</span></span></td>
  <td><span data-ttu-id="59098-477">RingerSilent</span><span class="sxs-lookup"><span data-stu-id="59098-477">RingerSilent</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EE.png" width="32" height="32" alt="OtherUser" /></td>
  <td><span data-ttu-id="59098-478">E7EE</span><span class="sxs-lookup"><span data-stu-id="59098-478">E7EE</span></span></td>
  <td><span data-ttu-id="59098-479">OtherUser</span><span class="sxs-lookup"><span data-stu-id="59098-479">OtherUser</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7EF.png" width="32" height="32" alt="Admin" /></td>
  <td><span data-ttu-id="59098-480">E7EF</span><span class="sxs-lookup"><span data-stu-id="59098-480">E7EF</span></span></td>
  <td><span data-ttu-id="59098-481">管理者</span><span class="sxs-lookup"><span data-stu-id="59098-481">Admin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F0.png" width="32" height="32" alt="CC" /></td>
  <td><span data-ttu-id="59098-482">E7F0</span><span class="sxs-lookup"><span data-stu-id="59098-482">E7F0</span></span></td>
  <td><span data-ttu-id="59098-483">CC</span><span class="sxs-lookup"><span data-stu-id="59098-483">CC</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F1.png" width="32" height="32" alt="SDCard" /></td>
  <td><span data-ttu-id="59098-484">E7F1</span><span class="sxs-lookup"><span data-stu-id="59098-484">E7F1</span></span></td>
  <td><span data-ttu-id="59098-485">SDCard</span><span class="sxs-lookup"><span data-stu-id="59098-485">SDCard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F2.png" width="32" height="32" alt="CallForwarding" /></td>
  <td><span data-ttu-id="59098-486">E7F2</span><span class="sxs-lookup"><span data-stu-id="59098-486">E7F2</span></span></td>
  <td><span data-ttu-id="59098-487">CallForwarding</span><span class="sxs-lookup"><span data-stu-id="59098-487">CallForwarding</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F3.png" width="32" height="32" alt="SettingsDisplaySound" /></td>
  <td><span data-ttu-id="59098-488">E7F3</span><span class="sxs-lookup"><span data-stu-id="59098-488">E7F3</span></span></td>
  <td><span data-ttu-id="59098-489">SettingsDisplaySound</span><span class="sxs-lookup"><span data-stu-id="59098-489">SettingsDisplaySound</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F4.png" width="32" height="32" alt="TVMonitor" /></td>
  <td><span data-ttu-id="59098-490">E7F4</span><span class="sxs-lookup"><span data-stu-id="59098-490">E7F4</span></span></td>
  <td><span data-ttu-id="59098-491">TVMonitor</span><span class="sxs-lookup"><span data-stu-id="59098-491">TVMonitor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F5.png" width="32" height="32" alt="Speakers" /></td>
  <td><span data-ttu-id="59098-492">E7F5</span><span class="sxs-lookup"><span data-stu-id="59098-492">E7F5</span></span></td>
  <td><span data-ttu-id="59098-493">スピーカー</span><span class="sxs-lookup"><span data-stu-id="59098-493">Speakers</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F6.png" width="32" height="32" alt="Headphone" /></td>
  <td><span data-ttu-id="59098-494">E7F6</span><span class="sxs-lookup"><span data-stu-id="59098-494">E7F6</span></span></td>
  <td><span data-ttu-id="59098-495">Headphone</span><span class="sxs-lookup"><span data-stu-id="59098-495">Headphone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F7.png" width="32" height="32" alt="DeviceLaptopPic" /></td>
  <td><span data-ttu-id="59098-496">E7F7</span><span class="sxs-lookup"><span data-stu-id="59098-496">E7F7</span></span></td>
  <td><span data-ttu-id="59098-497">DeviceLaptopPic</span><span class="sxs-lookup"><span data-stu-id="59098-497">DeviceLaptopPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F8.png" width="32" height="32" alt="DeviceLaptopNoPic" /></td>
  <td><span data-ttu-id="59098-498">E7F8</span><span class="sxs-lookup"><span data-stu-id="59098-498">E7F8</span></span></td>
  <td><span data-ttu-id="59098-499">DeviceLaptopNoPic</span><span class="sxs-lookup"><span data-stu-id="59098-499">DeviceLaptopNoPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7F9.png" width="32" height="32" alt="DeviceMonitorRightPic" /></td>
  <td><span data-ttu-id="59098-500">E7F9</span><span class="sxs-lookup"><span data-stu-id="59098-500">E7F9</span></span></td>
  <td><span data-ttu-id="59098-501">DeviceMonitorRightPic</span><span class="sxs-lookup"><span data-stu-id="59098-501">DeviceMonitorRightPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7FA.png" width="32" height="32" alt="DeviceMonitorLeftPic" /></td>
  <td><span data-ttu-id="59098-502">E7FA</span><span class="sxs-lookup"><span data-stu-id="59098-502">E7FA</span></span></td>
  <td><span data-ttu-id="59098-503">DeviceMonitorLeftPic</span><span class="sxs-lookup"><span data-stu-id="59098-503">DeviceMonitorLeftPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7FB.png" width="32" height="32" alt="DeviceMonitorNoPic" /></td>
  <td><span data-ttu-id="59098-504">E7FB</span><span class="sxs-lookup"><span data-stu-id="59098-504">E7FB</span></span></td>
  <td><span data-ttu-id="59098-505">DeviceMonitorNoPic</span><span class="sxs-lookup"><span data-stu-id="59098-505">DeviceMonitorNoPic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7FC.png" width="32" height="32" alt="Game" /></td>
  <td><span data-ttu-id="59098-506">E7FC</span><span class="sxs-lookup"><span data-stu-id="59098-506">E7FC</span></span></td>
  <td><span data-ttu-id="59098-507">Game</span><span class="sxs-lookup"><span data-stu-id="59098-507">Game</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E7FD.png" width="32" height="32" alt="HorizontalTabKey" /></td>
  <td><span data-ttu-id="59098-508">E7FD</span><span class="sxs-lookup"><span data-stu-id="59098-508">E7FD</span></span></td>
  <td><span data-ttu-id="59098-509">HorizontalTabKey</span><span class="sxs-lookup"><span data-stu-id="59098-509">HorizontalTabKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E802.png" width="32" height="32" alt="StreetsideSplitMinimize" /></td>
  <td><span data-ttu-id="59098-510">E802</span><span class="sxs-lookup"><span data-stu-id="59098-510">E802</span></span></td>
  <td><span data-ttu-id="59098-511">StreetsideSplitMinimize</span><span class="sxs-lookup"><span data-stu-id="59098-511">StreetsideSplitMinimize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E803.png" width="32" height="32" alt="StreetsideSplitExpand" /></td>
  <td><span data-ttu-id="59098-512">E803</span><span class="sxs-lookup"><span data-stu-id="59098-512">E803</span></span></td>
  <td><span data-ttu-id="59098-513">StreetsideSplitExpand</span><span class="sxs-lookup"><span data-stu-id="59098-513">StreetsideSplitExpand</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E804.png" width="32" height="32" alt="Car" /></td>
  <td><span data-ttu-id="59098-514">E804</span><span class="sxs-lookup"><span data-stu-id="59098-514">E804</span></span></td>
  <td><span data-ttu-id="59098-515">Car</span><span class="sxs-lookup"><span data-stu-id="59098-515">Car</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E805.png" width="32" height="32" alt="Walk" /></td>
  <td><span data-ttu-id="59098-516">E805</span><span class="sxs-lookup"><span data-stu-id="59098-516">E805</span></span></td>
  <td><span data-ttu-id="59098-517">Walk</span><span class="sxs-lookup"><span data-stu-id="59098-517">Walk</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E806.png" width="32" height="32" alt="Bus" /></td>
  <td><span data-ttu-id="59098-518">E806</span><span class="sxs-lookup"><span data-stu-id="59098-518">E806</span></span></td>
  <td><span data-ttu-id="59098-519">Bus</span><span class="sxs-lookup"><span data-stu-id="59098-519">Bus</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E809.png" width="32" height="32" alt="TiltUp" /></td>
  <td><span data-ttu-id="59098-520">E809</span><span class="sxs-lookup"><span data-stu-id="59098-520">E809</span></span></td>
  <td><span data-ttu-id="59098-521">TiltUp</span><span class="sxs-lookup"><span data-stu-id="59098-521">TiltUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E80A.png" width="32" height="32" alt="TiltDown" /></td>
  <td><span data-ttu-id="59098-522">E80A</span><span class="sxs-lookup"><span data-stu-id="59098-522">E80A</span></span></td>
  <td><span data-ttu-id="59098-523">TiltDown</span><span class="sxs-lookup"><span data-stu-id="59098-523">TiltDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E80C.png" width="32" height="32" alt="RotateMapRight" /></td>
  <td><span data-ttu-id="59098-524">E80C</span><span class="sxs-lookup"><span data-stu-id="59098-524">E80C</span></span></td>
  <td><span data-ttu-id="59098-525">RotateMapRight</span><span class="sxs-lookup"><span data-stu-id="59098-525">RotateMapRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E80D.png" width="32" height="32" alt="RotateMapLeft" /></td>
  <td><span data-ttu-id="59098-526">E80D</span><span class="sxs-lookup"><span data-stu-id="59098-526">E80D</span></span></td>
  <td><span data-ttu-id="59098-527">RotateMapLeft</span><span class="sxs-lookup"><span data-stu-id="59098-527">RotateMapLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E80F.png" width="32" height="32" alt="Home" /></td>
  <td><span data-ttu-id="59098-528">E80F</span><span class="sxs-lookup"><span data-stu-id="59098-528">E80F</span></span></td>
  <td><span data-ttu-id="59098-529">Home</span><span class="sxs-lookup"><span data-stu-id="59098-529">Home</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E811.png" width="32" height="32" alt="ParkingLocation" /></td>
  <td><span data-ttu-id="59098-530">E811</span><span class="sxs-lookup"><span data-stu-id="59098-530">E811</span></span></td>
  <td><span data-ttu-id="59098-531">ParkingLocation</span><span class="sxs-lookup"><span data-stu-id="59098-531">ParkingLocation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E812.png" width="32" height="32" alt="MapCompassTop" /></td>
  <td><span data-ttu-id="59098-532">E812</span><span class="sxs-lookup"><span data-stu-id="59098-532">E812</span></span></td>
  <td><span data-ttu-id="59098-533">MapCompassTop</span><span class="sxs-lookup"><span data-stu-id="59098-533">MapCompassTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E813.png" width="32" height="32" alt="MapCompassBottom" /></td>
  <td><span data-ttu-id="59098-534">E813</span><span class="sxs-lookup"><span data-stu-id="59098-534">E813</span></span></td>
  <td><span data-ttu-id="59098-535">MapCompassBottom</span><span class="sxs-lookup"><span data-stu-id="59098-535">MapCompassBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E814.png" width="32" height="32" alt="IncidentTriangle" /></td>
  <td><span data-ttu-id="59098-536">E814</span><span class="sxs-lookup"><span data-stu-id="59098-536">E814</span></span></td>
  <td><span data-ttu-id="59098-537">IncidentTriangle</span><span class="sxs-lookup"><span data-stu-id="59098-537">IncidentTriangle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E815.png" width="32" height="32" alt="Touch" /></td>
  <td><span data-ttu-id="59098-538">E815</span><span class="sxs-lookup"><span data-stu-id="59098-538">E815</span></span></td>
  <td><span data-ttu-id="59098-539">タッチ</span><span class="sxs-lookup"><span data-stu-id="59098-539">Touch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E816.png" width="32" height="32" alt="MapDirections" /></td>
  <td><span data-ttu-id="59098-540">E816</span><span class="sxs-lookup"><span data-stu-id="59098-540">E816</span></span></td>
  <td><span data-ttu-id="59098-541">MapDirections</span><span class="sxs-lookup"><span data-stu-id="59098-541">MapDirections</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E819.png" width="32" height="32" alt="StartPoint" /></td>
  <td><span data-ttu-id="59098-542">E819</span><span class="sxs-lookup"><span data-stu-id="59098-542">E819</span></span></td>
  <td><span data-ttu-id="59098-543">StartPoint</span><span class="sxs-lookup"><span data-stu-id="59098-543">StartPoint</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81A.png" width="32" height="32" alt="StopPoint" /></td>
  <td><span data-ttu-id="59098-544">E81A</span><span class="sxs-lookup"><span data-stu-id="59098-544">E81A</span></span></td>
  <td><span data-ttu-id="59098-545">StopPoint</span><span class="sxs-lookup"><span data-stu-id="59098-545">StopPoint</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81B.png" width="32" height="32" alt="EndPoint" /></td>
  <td><span data-ttu-id="59098-546">E81B</span><span class="sxs-lookup"><span data-stu-id="59098-546">E81B</span></span></td>
  <td><span data-ttu-id="59098-547">EndPoint</span><span class="sxs-lookup"><span data-stu-id="59098-547">EndPoint</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81C.png" width="32" height="32" alt="History" /></td>
  <td><span data-ttu-id="59098-548">E81C</span><span class="sxs-lookup"><span data-stu-id="59098-548">E81C</span></span></td>
  <td><span data-ttu-id="59098-549">履歴</span><span class="sxs-lookup"><span data-stu-id="59098-549">History</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81D.png" width="32" height="32" alt="Location" /></td>
  <td><span data-ttu-id="59098-550">E81D</span><span class="sxs-lookup"><span data-stu-id="59098-550">E81D</span></span></td>
  <td><span data-ttu-id="59098-551">Location</span><span class="sxs-lookup"><span data-stu-id="59098-551">Location</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81E.png" width="32" height="32" alt="MapLayers" /></td>
  <td><span data-ttu-id="59098-552">E81E</span><span class="sxs-lookup"><span data-stu-id="59098-552">E81E</span></span></td>
  <td><span data-ttu-id="59098-553">MapLayers</span><span class="sxs-lookup"><span data-stu-id="59098-553">MapLayers</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E81F.png" width="32" height="32" alt="Accident" /></td>
  <td><span data-ttu-id="59098-554">E81F</span><span class="sxs-lookup"><span data-stu-id="59098-554">E81F</span></span></td>
  <td><span data-ttu-id="59098-555">Accident</span><span class="sxs-lookup"><span data-stu-id="59098-555">Accident</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E821.png" width="32" height="32" alt="Work" /></td>
  <td><span data-ttu-id="59098-556">E821</span><span class="sxs-lookup"><span data-stu-id="59098-556">E821</span></span></td>
  <td><span data-ttu-id="59098-557">仕事用</span><span class="sxs-lookup"><span data-stu-id="59098-557">Work</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E822.png" width="32" height="32" alt="Construction" /></td>
  <td><span data-ttu-id="59098-558">E822</span><span class="sxs-lookup"><span data-stu-id="59098-558">E822</span></span></td>
  <td><span data-ttu-id="59098-559">Construction</span><span class="sxs-lookup"><span data-stu-id="59098-559">Construction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E823.png" width="32" height="32" alt="Recent" /></td>
  <td><span data-ttu-id="59098-560">E823</span><span class="sxs-lookup"><span data-stu-id="59098-560">E823</span></span></td>
  <td><span data-ttu-id="59098-561">Recent</span><span class="sxs-lookup"><span data-stu-id="59098-561">Recent</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E825.png" width="32" height="32" alt="Bank" /></td>
  <td><span data-ttu-id="59098-562">E825</span><span class="sxs-lookup"><span data-stu-id="59098-562">E825</span></span></td>
  <td><span data-ttu-id="59098-563">Bank</span><span class="sxs-lookup"><span data-stu-id="59098-563">Bank</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E826.png" width="32" height="32" alt="DownloadMap" /></td>
  <td><span data-ttu-id="59098-564">E826</span><span class="sxs-lookup"><span data-stu-id="59098-564">E826</span></span></td>
  <td><span data-ttu-id="59098-565">DownloadMap</span><span class="sxs-lookup"><span data-stu-id="59098-565">DownloadMap</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E829.png" width="32" height="32" alt="InkingToolFill2" /></td>
  <td><span data-ttu-id="59098-566">E829</span><span class="sxs-lookup"><span data-stu-id="59098-566">E829</span></span></td>
  <td><span data-ttu-id="59098-567">InkingToolFill2</span><span class="sxs-lookup"><span data-stu-id="59098-567">InkingToolFill2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82A.png" width="32" height="32" alt="HighlightFill2" /></td>
  <td><span data-ttu-id="59098-568">E82A</span><span class="sxs-lookup"><span data-stu-id="59098-568">E82A</span></span></td>
  <td><span data-ttu-id="59098-569">HighlightFill2</span><span class="sxs-lookup"><span data-stu-id="59098-569">HighlightFill2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82B.png" width="32" height="32" alt="EraseToolFill" /></td>
  <td><span data-ttu-id="59098-570">E82B</span><span class="sxs-lookup"><span data-stu-id="59098-570">E82B</span></span></td>
  <td><span data-ttu-id="59098-571">EraseToolFill</span><span class="sxs-lookup"><span data-stu-id="59098-571">EraseToolFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82C.png" width="32" height="32" alt="EraseToolFill2" /></td>
  <td><span data-ttu-id="59098-572">E82C</span><span class="sxs-lookup"><span data-stu-id="59098-572">E82C</span></span></td>
  <td><span data-ttu-id="59098-573">EraseToolFill2</span><span class="sxs-lookup"><span data-stu-id="59098-573">EraseToolFill2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82D.png" width="32" height="32" alt="Dictionary" /></td>
  <td><span data-ttu-id="59098-574">E82D</span><span class="sxs-lookup"><span data-stu-id="59098-574">E82D</span></span></td>
  <td><span data-ttu-id="59098-575">Dictionary</span><span class="sxs-lookup"><span data-stu-id="59098-575">Dictionary</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82E.png" width="32" height="32" alt="DictionaryAdd" /></td>
  <td><span data-ttu-id="59098-576">E82E</span><span class="sxs-lookup"><span data-stu-id="59098-576">E82E</span></span></td>
  <td><span data-ttu-id="59098-577">DictionaryAdd</span><span class="sxs-lookup"><span data-stu-id="59098-577">DictionaryAdd</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E82F.png" width="32" height="32" alt="ToolTip" /></td>
  <td><span data-ttu-id="59098-578">E82F</span><span class="sxs-lookup"><span data-stu-id="59098-578">E82F</span></span></td>
  <td><span data-ttu-id="59098-579">ToolTip</span><span class="sxs-lookup"><span data-stu-id="59098-579">ToolTip</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E830.png" width="32" height="32" alt="ChromeBack" /></td>
  <td><span data-ttu-id="59098-580">E830</span><span class="sxs-lookup"><span data-stu-id="59098-580">E830</span></span></td>
  <td><span data-ttu-id="59098-581">ChromeBack</span><span class="sxs-lookup"><span data-stu-id="59098-581">ChromeBack</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E835.png" width="32" height="32" alt="ProvisioningPackage" /></td>
  <td><span data-ttu-id="59098-582">E835</span><span class="sxs-lookup"><span data-stu-id="59098-582">E835</span></span></td>
  <td><span data-ttu-id="59098-583">ProvisioningPackage</span><span class="sxs-lookup"><span data-stu-id="59098-583">ProvisioningPackage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E836.png" width="32" height="32" alt="AddRemoteDevice" /></td>
  <td><span data-ttu-id="59098-584">E836</span><span class="sxs-lookup"><span data-stu-id="59098-584">E836</span></span></td>
  <td><span data-ttu-id="59098-585">AddRemoteDevice</span><span class="sxs-lookup"><span data-stu-id="59098-585">AddRemoteDevice</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E838.png" width="32" height="32" alt="FolderOpen" /></td>
  <td><span data-ttu-id="59098-586">E838</span><span class="sxs-lookup"><span data-stu-id="59098-586">E838</span></span></td>
  <td><span data-ttu-id="59098-587">FolderOpen</span><span class="sxs-lookup"><span data-stu-id="59098-587">FolderOpen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E839.png" width="32" height="32" alt="Ethernet" /></td>
  <td><span data-ttu-id="59098-588">E839</span><span class="sxs-lookup"><span data-stu-id="59098-588">E839</span></span></td>
  <td><span data-ttu-id="59098-589">Ethernet</span><span class="sxs-lookup"><span data-stu-id="59098-589">Ethernet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83A.png" width="32" height="32" alt=" ShareBroadband" /></td>
  <td><span data-ttu-id="59098-590">E83A</span><span class="sxs-lookup"><span data-stu-id="59098-590">E83A</span></span></td>
  <td> <span data-ttu-id="59098-591">ShareBroadband</span><span class="sxs-lookup"><span data-stu-id="59098-591">ShareBroadband</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83B.png" width="32" height="32" alt="DirectAccess" /></td>
  <td><span data-ttu-id="59098-592">E83B</span><span class="sxs-lookup"><span data-stu-id="59098-592">E83B</span></span></td>
  <td><span data-ttu-id="59098-593">DirectAccess</span><span class="sxs-lookup"><span data-stu-id="59098-593">DirectAccess</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83C.png" width="32" height="32" alt=" DialUp" /></td>
  <td><span data-ttu-id="59098-594">E83C</span><span class="sxs-lookup"><span data-stu-id="59098-594">E83C</span></span></td>
  <td> <span data-ttu-id="59098-595">DialUp</span><span class="sxs-lookup"><span data-stu-id="59098-595">DialUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83D.png" width="32" height="32" alt="DefenderApp " /></td>
  <td><span data-ttu-id="59098-596">E83D</span><span class="sxs-lookup"><span data-stu-id="59098-596">E83D</span></span></td>
  <td><span data-ttu-id="59098-597">DefenderApp</span><span class="sxs-lookup"><span data-stu-id="59098-597">DefenderApp</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83E.png" width="32" height="32" alt="BatteryCharging9" /></td>
  <td><span data-ttu-id="59098-598">E83E</span><span class="sxs-lookup"><span data-stu-id="59098-598">E83E</span></span></td>
  <td><span data-ttu-id="59098-599">BatteryCharging9</span><span class="sxs-lookup"><span data-stu-id="59098-599">BatteryCharging9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E83F.png" width="32" height="32" alt="Battery10" /></td>
  <td><span data-ttu-id="59098-600">E83F</span><span class="sxs-lookup"><span data-stu-id="59098-600">E83F</span></span></td>
  <td><span data-ttu-id="59098-601">Battery10</span><span class="sxs-lookup"><span data-stu-id="59098-601">Battery10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E840.png" width="32" height="32" alt="Pinned" /></td>
  <td><span data-ttu-id="59098-602">E840</span><span class="sxs-lookup"><span data-stu-id="59098-602">E840</span></span></td>
  <td><span data-ttu-id="59098-603">Pinned</span><span class="sxs-lookup"><span data-stu-id="59098-603">Pinned</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E841.png" width="32" height="32" alt="PinFill" /></td>
  <td><span data-ttu-id="59098-604">E841</span><span class="sxs-lookup"><span data-stu-id="59098-604">E841</span></span></td>
  <td><span data-ttu-id="59098-605">PinFill</span><span class="sxs-lookup"><span data-stu-id="59098-605">PinFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E842.png" width="32" height="32" alt="PinnedFill" /></td>
  <td><span data-ttu-id="59098-606">E842</span><span class="sxs-lookup"><span data-stu-id="59098-606">E842</span></span></td>
  <td><span data-ttu-id="59098-607">PinnedFill</span><span class="sxs-lookup"><span data-stu-id="59098-607">PinnedFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E843.png" width="32" height="32" alt="PeriodKey" /></td>
  <td><span data-ttu-id="59098-608">E843</span><span class="sxs-lookup"><span data-stu-id="59098-608">E843</span></span></td>
  <td><span data-ttu-id="59098-609">PeriodKey</span><span class="sxs-lookup"><span data-stu-id="59098-609">PeriodKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E844.png" width="32" height="32" alt="PuncKey" /></td>
  <td><span data-ttu-id="59098-610">E844</span><span class="sxs-lookup"><span data-stu-id="59098-610">E844</span></span></td>
  <td><span data-ttu-id="59098-611">PuncKey</span><span class="sxs-lookup"><span data-stu-id="59098-611">PuncKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E845.png" width="32" height="32" alt="RevToggleKey" /></td>
  <td><span data-ttu-id="59098-612">E845</span><span class="sxs-lookup"><span data-stu-id="59098-612">E845</span></span></td>
  <td><span data-ttu-id="59098-613">RevToggleKey</span><span class="sxs-lookup"><span data-stu-id="59098-613">RevToggleKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E846.png" width="32" height="32" alt="RightArrowKeyTime1" /></td>
  <td><span data-ttu-id="59098-614">E846</span><span class="sxs-lookup"><span data-stu-id="59098-614">E846</span></span></td>
  <td><span data-ttu-id="59098-615">RightArrowKeyTime1</span><span class="sxs-lookup"><span data-stu-id="59098-615">RightArrowKeyTime1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E847.png" width="32" height="32" alt="RightArrowKeyTime2" /></td>
  <td><span data-ttu-id="59098-616">E847</span><span class="sxs-lookup"><span data-stu-id="59098-616">E847</span></span></td>
  <td><span data-ttu-id="59098-617">RightArrowKeyTime2</span><span class="sxs-lookup"><span data-stu-id="59098-617">RightArrowKeyTime2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E848.png" width="32" height="32" alt="LeftQuote" /></td>
  <td><span data-ttu-id="59098-618">E848</span><span class="sxs-lookup"><span data-stu-id="59098-618">E848</span></span></td>
  <td><span data-ttu-id="59098-619">LeftQuote</span><span class="sxs-lookup"><span data-stu-id="59098-619">LeftQuote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E849.png" width="32" height="32" alt="RightQuote" /></td>
  <td><span data-ttu-id="59098-620">E849</span><span class="sxs-lookup"><span data-stu-id="59098-620">E849</span></span></td>
  <td><span data-ttu-id="59098-621">RightQuote</span><span class="sxs-lookup"><span data-stu-id="59098-621">RightQuote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84A.png" width="32" height="32" alt="DownShiftKey" /></td>
  <td><span data-ttu-id="59098-622">E84A</span><span class="sxs-lookup"><span data-stu-id="59098-622">E84A</span></span></td>
  <td><span data-ttu-id="59098-623">DownShiftKey</span><span class="sxs-lookup"><span data-stu-id="59098-623">DownShiftKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84B.png" width="32" height="32" alt="UpShiftKey" /></td>
  <td><span data-ttu-id="59098-624">E84B</span><span class="sxs-lookup"><span data-stu-id="59098-624">E84B</span></span></td>
  <td><span data-ttu-id="59098-625">UpShiftKey</span><span class="sxs-lookup"><span data-stu-id="59098-625">UpShiftKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84C.png" width="32" height="32" alt="PuncKey0" /></td>
  <td><span data-ttu-id="59098-626">E84C</span><span class="sxs-lookup"><span data-stu-id="59098-626">E84C</span></span></td>
  <td><span data-ttu-id="59098-627">PuncKey0</span><span class="sxs-lookup"><span data-stu-id="59098-627">PuncKey0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84D.png" width="32" height="32" alt="PuncKeyLeftBottom" /></td>
  <td><span data-ttu-id="59098-628">E84D</span><span class="sxs-lookup"><span data-stu-id="59098-628">E84D</span></span></td>
  <td><span data-ttu-id="59098-629">PuncKeyLeftBottom</span><span class="sxs-lookup"><span data-stu-id="59098-629">PuncKeyLeftBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84E.png" width="32" height="32" alt="RightArrowKeyTime3" /></td>
  <td><span data-ttu-id="59098-630">E84E</span><span class="sxs-lookup"><span data-stu-id="59098-630">E84E</span></span></td>
  <td><span data-ttu-id="59098-631">RightArrowKeyTime3</span><span class="sxs-lookup"><span data-stu-id="59098-631">RightArrowKeyTime3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E84F.png" width="32" height="32" alt="RightArrowKeyTime4" /></td>
  <td><span data-ttu-id="59098-632">E84F</span><span class="sxs-lookup"><span data-stu-id="59098-632">E84F</span></span></td>
  <td><span data-ttu-id="59098-633">RightArrowKeyTime4</span><span class="sxs-lookup"><span data-stu-id="59098-633">RightArrowKeyTime4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E850.png" width="32" height="32" alt="Battery0" /></td>
  <td><span data-ttu-id="59098-634">E850</span><span class="sxs-lookup"><span data-stu-id="59098-634">E850</span></span></td>
  <td><span data-ttu-id="59098-635">Battery0</span><span class="sxs-lookup"><span data-stu-id="59098-635">Battery0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E851.png" width="32" height="32" alt="Battery1" /></td>
  <td><span data-ttu-id="59098-636">E851</span><span class="sxs-lookup"><span data-stu-id="59098-636">E851</span></span></td>
  <td><span data-ttu-id="59098-637">Battery1</span><span class="sxs-lookup"><span data-stu-id="59098-637">Battery1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E852.png" width="32" height="32" alt="Battery2" /></td>
  <td><span data-ttu-id="59098-638">E852</span><span class="sxs-lookup"><span data-stu-id="59098-638">E852</span></span></td>
  <td><span data-ttu-id="59098-639">Battery2</span><span class="sxs-lookup"><span data-stu-id="59098-639">Battery2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E853.png" width="32" height="32" alt="Battery3" /></td>
  <td><span data-ttu-id="59098-640">E853</span><span class="sxs-lookup"><span data-stu-id="59098-640">E853</span></span></td>
  <td><span data-ttu-id="59098-641">Battery3</span><span class="sxs-lookup"><span data-stu-id="59098-641">Battery3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E854.png" width="32" height="32" alt="Battery4" /></td>
  <td><span data-ttu-id="59098-642">E854</span><span class="sxs-lookup"><span data-stu-id="59098-642">E854</span></span></td>
  <td><span data-ttu-id="59098-643">Battery4</span><span class="sxs-lookup"><span data-stu-id="59098-643">Battery4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E855.png" width="32" height="32" alt="Battery5" /></td>
  <td><span data-ttu-id="59098-644">E855</span><span class="sxs-lookup"><span data-stu-id="59098-644">E855</span></span></td>
  <td><span data-ttu-id="59098-645">Battery5</span><span class="sxs-lookup"><span data-stu-id="59098-645">Battery5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E856.png" width="32" height="32" alt="Battery6" /></td>
  <td><span data-ttu-id="59098-646">E856</span><span class="sxs-lookup"><span data-stu-id="59098-646">E856</span></span></td>
  <td><span data-ttu-id="59098-647">Battery6</span><span class="sxs-lookup"><span data-stu-id="59098-647">Battery6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E857.png" width="32" height="32" alt="Battery7" /></td>
  <td><span data-ttu-id="59098-648">E857</span><span class="sxs-lookup"><span data-stu-id="59098-648">E857</span></span></td>
  <td><span data-ttu-id="59098-649">Battery7</span><span class="sxs-lookup"><span data-stu-id="59098-649">Battery7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E858.png" width="32" height="32" alt="Battery8" /></td>
  <td><span data-ttu-id="59098-650">E858</span><span class="sxs-lookup"><span data-stu-id="59098-650">E858</span></span></td>
  <td><span data-ttu-id="59098-651">Battery8</span><span class="sxs-lookup"><span data-stu-id="59098-651">Battery8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E859.png" width="32" height="32" alt="Battery9" /></td>
  <td><span data-ttu-id="59098-652">E859</span><span class="sxs-lookup"><span data-stu-id="59098-652">E859</span></span></td>
  <td><span data-ttu-id="59098-653">Battery9</span><span class="sxs-lookup"><span data-stu-id="59098-653">Battery9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85A.png" width="32" height="32" alt="BatteryCharging0" /></td>
  <td><span data-ttu-id="59098-654">E85A</span><span class="sxs-lookup"><span data-stu-id="59098-654">E85A</span></span></td>
  <td><span data-ttu-id="59098-655">BatteryCharging0</span><span class="sxs-lookup"><span data-stu-id="59098-655">BatteryCharging0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85B.png" width="32" height="32" alt="BatteryCharging1" /></td>
  <td><span data-ttu-id="59098-656">E85B</span><span class="sxs-lookup"><span data-stu-id="59098-656">E85B</span></span></td>
  <td><span data-ttu-id="59098-657">BatteryCharging1</span><span class="sxs-lookup"><span data-stu-id="59098-657">BatteryCharging1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85C.png" width="32" height="32" alt="BatteryCharging2" /></td>
  <td><span data-ttu-id="59098-658">E85C</span><span class="sxs-lookup"><span data-stu-id="59098-658">E85C</span></span></td>
  <td><span data-ttu-id="59098-659">BatteryCharging2</span><span class="sxs-lookup"><span data-stu-id="59098-659">BatteryCharging2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85D.png" width="32" height="32" alt="BatteryCharging3" /></td>
  <td><span data-ttu-id="59098-660">E85D</span><span class="sxs-lookup"><span data-stu-id="59098-660">E85D</span></span></td>
  <td><span data-ttu-id="59098-661">BatteryCharging3</span><span class="sxs-lookup"><span data-stu-id="59098-661">BatteryCharging3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85E.png" width="32" height="32" alt="BatteryCharging4" /></td>
  <td><span data-ttu-id="59098-662">E85E</span><span class="sxs-lookup"><span data-stu-id="59098-662">E85E</span></span></td>
  <td><span data-ttu-id="59098-663">BatteryCharging4</span><span class="sxs-lookup"><span data-stu-id="59098-663">BatteryCharging4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E85F.png" width="32" height="32" alt="BatteryCharging5" /></td>
  <td><span data-ttu-id="59098-664">E85F</span><span class="sxs-lookup"><span data-stu-id="59098-664">E85F</span></span></td>
  <td><span data-ttu-id="59098-665">BatteryCharging5</span><span class="sxs-lookup"><span data-stu-id="59098-665">BatteryCharging5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E860.png" width="32" height="32" alt="BatteryCharging6" /></td>
  <td><span data-ttu-id="59098-666">E860</span><span class="sxs-lookup"><span data-stu-id="59098-666">E860</span></span></td>
  <td><span data-ttu-id="59098-667">BatteryCharging6</span><span class="sxs-lookup"><span data-stu-id="59098-667">BatteryCharging6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E861.png" width="32" height="32" alt="BatteryCharging7" /></td>
  <td><span data-ttu-id="59098-668">E861</span><span class="sxs-lookup"><span data-stu-id="59098-668">E861</span></span></td>
  <td><span data-ttu-id="59098-669">BatteryCharging7</span><span class="sxs-lookup"><span data-stu-id="59098-669">BatteryCharging7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E862.png" width="32" height="32" alt="BatteryCharging8" /></td>
  <td><span data-ttu-id="59098-670">E862</span><span class="sxs-lookup"><span data-stu-id="59098-670">E862</span></span></td>
  <td><span data-ttu-id="59098-671">BatteryCharging8</span><span class="sxs-lookup"><span data-stu-id="59098-671">BatteryCharging8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E863.png" width="32" height="32" alt="BatterySaver0" /></td>
  <td><span data-ttu-id="59098-672">E863</span><span class="sxs-lookup"><span data-stu-id="59098-672">E863</span></span></td>
  <td><span data-ttu-id="59098-673">BatterySaver0</span><span class="sxs-lookup"><span data-stu-id="59098-673">BatterySaver0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E864.png" width="32" height="32" alt="BatterySaver1" /></td>
  <td><span data-ttu-id="59098-674">E864</span><span class="sxs-lookup"><span data-stu-id="59098-674">E864</span></span></td>
  <td><span data-ttu-id="59098-675">BatterySaver1</span><span class="sxs-lookup"><span data-stu-id="59098-675">BatterySaver1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E865.png" width="32" height="32" alt="BatterySaver2" /></td>
  <td><span data-ttu-id="59098-676">E865</span><span class="sxs-lookup"><span data-stu-id="59098-676">E865</span></span></td>
  <td><span data-ttu-id="59098-677">BatterySaver2</span><span class="sxs-lookup"><span data-stu-id="59098-677">BatterySaver2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E866.png" width="32" height="32" alt="BatterySaver3" /></td>
  <td><span data-ttu-id="59098-678">E866</span><span class="sxs-lookup"><span data-stu-id="59098-678">E866</span></span></td>
  <td><span data-ttu-id="59098-679">BatterySaver3</span><span class="sxs-lookup"><span data-stu-id="59098-679">BatterySaver3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E867.png" width="32" height="32" alt="BatterySaver4" /></td>
  <td><span data-ttu-id="59098-680">E867</span><span class="sxs-lookup"><span data-stu-id="59098-680">E867</span></span></td>
  <td><span data-ttu-id="59098-681">BatterySaver4</span><span class="sxs-lookup"><span data-stu-id="59098-681">BatterySaver4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E868.png" width="32" height="32" alt="BatterySaver5" /></td>
  <td><span data-ttu-id="59098-682">E868</span><span class="sxs-lookup"><span data-stu-id="59098-682">E868</span></span></td>
  <td><span data-ttu-id="59098-683">BatterySaver5</span><span class="sxs-lookup"><span data-stu-id="59098-683">BatterySaver5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E869.png" width="32" height="32" alt="BatterySaver6" /></td>
  <td><span data-ttu-id="59098-684">E869</span><span class="sxs-lookup"><span data-stu-id="59098-684">E869</span></span></td>
  <td><span data-ttu-id="59098-685">BatterySaver6</span><span class="sxs-lookup"><span data-stu-id="59098-685">BatterySaver6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86A.png" width="32" height="32" alt="BatterySaver7" /></td>
  <td><span data-ttu-id="59098-686">E86A</span><span class="sxs-lookup"><span data-stu-id="59098-686">E86A</span></span></td>
  <td><span data-ttu-id="59098-687">BatterySaver7</span><span class="sxs-lookup"><span data-stu-id="59098-687">BatterySaver7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86B.png" width="32" height="32" alt="BatterySaver8" /></td>
  <td><span data-ttu-id="59098-688">E86B</span><span class="sxs-lookup"><span data-stu-id="59098-688">E86B</span></span></td>
  <td><span data-ttu-id="59098-689">BatterySaver8</span><span class="sxs-lookup"><span data-stu-id="59098-689">BatterySaver8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86C.png" width="32" height="32" alt="SignalBars1" /></td>
  <td><span data-ttu-id="59098-690">E86C</span><span class="sxs-lookup"><span data-stu-id="59098-690">E86C</span></span></td>
  <td><span data-ttu-id="59098-691">SignalBars1</span><span class="sxs-lookup"><span data-stu-id="59098-691">SignalBars1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86D.png" width="32" height="32" alt="SignalBars2" /></td>
  <td><span data-ttu-id="59098-692">E86D</span><span class="sxs-lookup"><span data-stu-id="59098-692">E86D</span></span></td>
  <td><span data-ttu-id="59098-693">SignalBars2</span><span class="sxs-lookup"><span data-stu-id="59098-693">SignalBars2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86E.png" width="32" height="32" alt="SignalBars3" /></td>
  <td><span data-ttu-id="59098-694">E86E</span><span class="sxs-lookup"><span data-stu-id="59098-694">E86E</span></span></td>
  <td><span data-ttu-id="59098-695">SignalBars3</span><span class="sxs-lookup"><span data-stu-id="59098-695">SignalBars3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E86F.png" width="32" height="32" alt="SignalBars4" /></td>
  <td><span data-ttu-id="59098-696">E86F</span><span class="sxs-lookup"><span data-stu-id="59098-696">E86F</span></span></td>
  <td><span data-ttu-id="59098-697">SignalBars4</span><span class="sxs-lookup"><span data-stu-id="59098-697">SignalBars4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E870.png" width="32" height="32" alt="SignalBars5" /></td>
  <td><span data-ttu-id="59098-698">E870</span><span class="sxs-lookup"><span data-stu-id="59098-698">E870</span></span></td>
  <td><span data-ttu-id="59098-699">SignalBars5</span><span class="sxs-lookup"><span data-stu-id="59098-699">SignalBars5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E871.png" width="32" height="32" alt="SignalNotConnected" /></td>
  <td><span data-ttu-id="59098-700">E871</span><span class="sxs-lookup"><span data-stu-id="59098-700">E871</span></span></td>
  <td><span data-ttu-id="59098-701">SignalNotConnected</span><span class="sxs-lookup"><span data-stu-id="59098-701">SignalNotConnected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E872.png" width="32" height="32" alt="Wifi1" /></td>
  <td><span data-ttu-id="59098-702">E872</span><span class="sxs-lookup"><span data-stu-id="59098-702">E872</span></span></td>
  <td><span data-ttu-id="59098-703">Wifi1</span><span class="sxs-lookup"><span data-stu-id="59098-703">Wifi1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E873.png" width="32" height="32" alt="Wifi2" /></td>
  <td><span data-ttu-id="59098-704">E873</span><span class="sxs-lookup"><span data-stu-id="59098-704">E873</span></span></td>
  <td><span data-ttu-id="59098-705">Wifi2</span><span class="sxs-lookup"><span data-stu-id="59098-705">Wifi2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E874.png" width="32" height="32" alt="Wifi3" /></td>
  <td><span data-ttu-id="59098-706">E874</span><span class="sxs-lookup"><span data-stu-id="59098-706">E874</span></span></td>
  <td><span data-ttu-id="59098-707">Wifi3</span><span class="sxs-lookup"><span data-stu-id="59098-707">Wifi3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E875.png" width="32" height="32" alt="MobSIMLock" /></td>
  <td><span data-ttu-id="59098-708">E875</span><span class="sxs-lookup"><span data-stu-id="59098-708">E875</span></span></td>
  <td><span data-ttu-id="59098-709">MobSIMLock</span><span class="sxs-lookup"><span data-stu-id="59098-709">MobSIMLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E876.png" width="32" height="32" alt="MobSIMMissing" /></td>
  <td><span data-ttu-id="59098-710">E876</span><span class="sxs-lookup"><span data-stu-id="59098-710">E876</span></span></td>
  <td><span data-ttu-id="59098-711">MobSIMMissing</span><span class="sxs-lookup"><span data-stu-id="59098-711">MobSIMMissing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E877.png" width="32" height="32" alt="Vibrate" /></td>
  <td><span data-ttu-id="59098-712">E877</span><span class="sxs-lookup"><span data-stu-id="59098-712">E877</span></span></td>
  <td><span data-ttu-id="59098-713">Vibrate</span><span class="sxs-lookup"><span data-stu-id="59098-713">Vibrate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E878.png" width="32" height="32" alt="RoamingInternational" /></td>
  <td><span data-ttu-id="59098-714">E878</span><span class="sxs-lookup"><span data-stu-id="59098-714">E878</span></span></td>
  <td><span data-ttu-id="59098-715">RoamingInternational</span><span class="sxs-lookup"><span data-stu-id="59098-715">RoamingInternational</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E879.png" width="32" height="32" alt="RoamingDomestic" /></td>
  <td><span data-ttu-id="59098-716">E879</span><span class="sxs-lookup"><span data-stu-id="59098-716">E879</span></span></td>
  <td><span data-ttu-id="59098-717">RoamingDomestic</span><span class="sxs-lookup"><span data-stu-id="59098-717">RoamingDomestic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87A.png" width="32" height="32" alt="CallForwardInternational" /></td>
  <td><span data-ttu-id="59098-718">E87A</span><span class="sxs-lookup"><span data-stu-id="59098-718">E87A</span></span></td>
  <td><span data-ttu-id="59098-719">CallForwardInternational</span><span class="sxs-lookup"><span data-stu-id="59098-719">CallForwardInternational</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87B.png" width="32" height="32" alt="CallForwardRoaming" /></td>
  <td><span data-ttu-id="59098-720">E87B</span><span class="sxs-lookup"><span data-stu-id="59098-720">E87B</span></span></td>
  <td><span data-ttu-id="59098-721">CallForwardRoaming</span><span class="sxs-lookup"><span data-stu-id="59098-721">CallForwardRoaming</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87C.png" width="32" height="32" alt="JpnRomanji" /></td>
  <td><span data-ttu-id="59098-722">E87C</span><span class="sxs-lookup"><span data-stu-id="59098-722">E87C</span></span></td>
  <td><span data-ttu-id="59098-723">JpnRomanji</span><span class="sxs-lookup"><span data-stu-id="59098-723">JpnRomanji</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87D.png" width="32" height="32" alt="JpnRomanjiLock" /></td>
  <td><span data-ttu-id="59098-724">E87D</span><span class="sxs-lookup"><span data-stu-id="59098-724">E87D</span></span></td>
  <td><span data-ttu-id="59098-725">JpnRomanjiLock</span><span class="sxs-lookup"><span data-stu-id="59098-725">JpnRomanjiLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87E.png" width="32" height="32" alt="JpnRomanjiShift" /></td>
  <td><span data-ttu-id="59098-726">E87E</span><span class="sxs-lookup"><span data-stu-id="59098-726">E87E</span></span></td>
  <td><span data-ttu-id="59098-727">JpnRomanjiShift</span><span class="sxs-lookup"><span data-stu-id="59098-727">JpnRomanjiShift</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E87F.png" width="32" height="32" alt="JpnRomanjiShiftLock" /></td>
  <td><span data-ttu-id="59098-728">E87F</span><span class="sxs-lookup"><span data-stu-id="59098-728">E87F</span></span></td>
  <td><span data-ttu-id="59098-729">JpnRomanjiShiftLock</span><span class="sxs-lookup"><span data-stu-id="59098-729">JpnRomanjiShiftLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E880.png" width="32" height="32" alt="StatusDataTransfer" /></td>
  <td><span data-ttu-id="59098-730">E880</span><span class="sxs-lookup"><span data-stu-id="59098-730">E880</span></span></td>
  <td><span data-ttu-id="59098-731">StatusDataTransfer</span><span class="sxs-lookup"><span data-stu-id="59098-731">StatusDataTransfer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E881.png" width="32" height="32" alt="StatusDataTransferVPN" /></td>
  <td><span data-ttu-id="59098-732">E881</span><span class="sxs-lookup"><span data-stu-id="59098-732">E881</span></span></td>
  <td><span data-ttu-id="59098-733">StatusDataTransferVPN</span><span class="sxs-lookup"><span data-stu-id="59098-733">StatusDataTransferVPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E882.png" width="32" height="32" alt="StatusDualSIM2" /></td>
  <td><span data-ttu-id="59098-734">E882</span><span class="sxs-lookup"><span data-stu-id="59098-734">E882</span></span></td>
  <td><span data-ttu-id="59098-735">StatusDualSIM2</span><span class="sxs-lookup"><span data-stu-id="59098-735">StatusDualSIM2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E883.png" width="32" height="32" alt="StatusDualSIM2VPN" /></td>
  <td><span data-ttu-id="59098-736">E883</span><span class="sxs-lookup"><span data-stu-id="59098-736">E883</span></span></td>
  <td><span data-ttu-id="59098-737">StatusDualSIM2VPN</span><span class="sxs-lookup"><span data-stu-id="59098-737">StatusDualSIM2VPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E884.png" width="32" height="32" alt="StatusDualSIM1" /></td>
  <td><span data-ttu-id="59098-738">E884</span><span class="sxs-lookup"><span data-stu-id="59098-738">E884</span></span></td>
  <td><span data-ttu-id="59098-739">StatusDualSIM1</span><span class="sxs-lookup"><span data-stu-id="59098-739">StatusDualSIM1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E885.png" width="32" height="32" alt="StatusDualSIM1VPN" /></td>
  <td><span data-ttu-id="59098-740">E885</span><span class="sxs-lookup"><span data-stu-id="59098-740">E885</span></span></td>
  <td><span data-ttu-id="59098-741">StatusDualSIM1VPN</span><span class="sxs-lookup"><span data-stu-id="59098-741">StatusDualSIM1VPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E886.png" width="32" height="32" alt="StatusSGLTE" /></td>
  <td><span data-ttu-id="59098-742">E886</span><span class="sxs-lookup"><span data-stu-id="59098-742">E886</span></span></td>
  <td><span data-ttu-id="59098-743">StatusSGLTE</span><span class="sxs-lookup"><span data-stu-id="59098-743">StatusSGLTE</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E887.png" width="32" height="32" alt="StatusSGLTECell" /></td>
  <td><span data-ttu-id="59098-744">E887</span><span class="sxs-lookup"><span data-stu-id="59098-744">E887</span></span></td>
  <td><span data-ttu-id="59098-745">StatusSGLTECell</span><span class="sxs-lookup"><span data-stu-id="59098-745">StatusSGLTECell</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E888.png" width="32" height="32" alt="StatusSGLTEDataVPN" /></td>
  <td><span data-ttu-id="59098-746">E888</span><span class="sxs-lookup"><span data-stu-id="59098-746">E888</span></span></td>
  <td><span data-ttu-id="59098-747">StatusSGLTEDataVPN</span><span class="sxs-lookup"><span data-stu-id="59098-747">StatusSGLTEDataVPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E889.png" width="32" height="32" alt="StatusVPN" /></td>
  <td><span data-ttu-id="59098-748">E889</span><span class="sxs-lookup"><span data-stu-id="59098-748">E889</span></span></td>
  <td><span data-ttu-id="59098-749">StatusVPN</span><span class="sxs-lookup"><span data-stu-id="59098-749">StatusVPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88A.png" width="32" height="32" alt="WifiHotspot" /></td>
  <td><span data-ttu-id="59098-750">E88A</span><span class="sxs-lookup"><span data-stu-id="59098-750">E88A</span></span></td>
  <td><span data-ttu-id="59098-751">WifiHotspot</span><span class="sxs-lookup"><span data-stu-id="59098-751">WifiHotspot</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88B.png" width="32" height="32" alt="LanguageKor" /></td>
  <td><span data-ttu-id="59098-752">E88B</span><span class="sxs-lookup"><span data-stu-id="59098-752">E88B</span></span></td>
  <td><span data-ttu-id="59098-753">LanguageKor</span><span class="sxs-lookup"><span data-stu-id="59098-753">LanguageKor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88C.png" width="32" height="32" alt="LanguageCht" /></td>
  <td><span data-ttu-id="59098-754">E88C</span><span class="sxs-lookup"><span data-stu-id="59098-754">E88C</span></span></td>
  <td><span data-ttu-id="59098-755">LanguageCht</span><span class="sxs-lookup"><span data-stu-id="59098-755">LanguageCht</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88D.png" width="32" height="32" alt="LanguageChs" /></td>
  <td><span data-ttu-id="59098-756">E88D</span><span class="sxs-lookup"><span data-stu-id="59098-756">E88D</span></span></td>
  <td><span data-ttu-id="59098-757">LanguageChs</span><span class="sxs-lookup"><span data-stu-id="59098-757">LanguageChs</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88E.png" width="32" height="32" alt="USB" /></td>
  <td><span data-ttu-id="59098-758">E88E</span><span class="sxs-lookup"><span data-stu-id="59098-758">E88E</span></span></td>
  <td><span data-ttu-id="59098-759">USB</span><span class="sxs-lookup"><span data-stu-id="59098-759">USB</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E88F.png" width="32" height="32" alt="InkingToolFill" /></td>
  <td><span data-ttu-id="59098-760">E88F</span><span class="sxs-lookup"><span data-stu-id="59098-760">E88F</span></span></td>
  <td><span data-ttu-id="59098-761">InkingToolFill</span><span class="sxs-lookup"><span data-stu-id="59098-761">InkingToolFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E890.png" width="32" height="32" alt="View" /></td>
  <td><span data-ttu-id="59098-762">E890</span><span class="sxs-lookup"><span data-stu-id="59098-762">E890</span></span></td>
  <td><span data-ttu-id="59098-763">ビュー</span><span class="sxs-lookup"><span data-stu-id="59098-763">View</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E891.png" width="32" height="32" alt="HighlightFill" /></td>
  <td><span data-ttu-id="59098-764">E891</span><span class="sxs-lookup"><span data-stu-id="59098-764">E891</span></span></td>
  <td><span data-ttu-id="59098-765">HighlightFill</span><span class="sxs-lookup"><span data-stu-id="59098-765">HighlightFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E892.png" width="32" height="32" alt="Previous" /></td>
  <td><span data-ttu-id="59098-766">E892</span><span class="sxs-lookup"><span data-stu-id="59098-766">E892</span></span></td>
  <td><span data-ttu-id="59098-767">戻る</span><span class="sxs-lookup"><span data-stu-id="59098-767">Previous</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E893.png" width="32" height="32" alt="Next" /></td>
  <td><span data-ttu-id="59098-768">E893</span><span class="sxs-lookup"><span data-stu-id="59098-768">E893</span></span></td>
  <td><span data-ttu-id="59098-769">次へ</span><span class="sxs-lookup"><span data-stu-id="59098-769">Next</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E894.png" width="32" height="32" alt="Clear" /></td>
  <td><span data-ttu-id="59098-770">E894</span><span class="sxs-lookup"><span data-stu-id="59098-770">E894</span></span></td>
  <td><span data-ttu-id="59098-771">[クリア]</span><span class="sxs-lookup"><span data-stu-id="59098-771">Clear</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E895.png" width="32" height="32" alt="Sync" /></td>
  <td><span data-ttu-id="59098-772">E895</span><span class="sxs-lookup"><span data-stu-id="59098-772">E895</span></span></td>
  <td><span data-ttu-id="59098-773">同期</span><span class="sxs-lookup"><span data-stu-id="59098-773">Sync</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E896.png" width="32" height="32" alt="Download" /></td>
  <td><span data-ttu-id="59098-774">E896</span><span class="sxs-lookup"><span data-stu-id="59098-774">E896</span></span></td>
  <td><span data-ttu-id="59098-775">ダウンロード</span><span class="sxs-lookup"><span data-stu-id="59098-775">Download</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E897.png" width="32" height="32" alt="Help" /></td>
  <td><span data-ttu-id="59098-776">E897</span><span class="sxs-lookup"><span data-stu-id="59098-776">E897</span></span></td>
  <td><span data-ttu-id="59098-777">Help</span><span class="sxs-lookup"><span data-stu-id="59098-777">Help</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E898.png" width="32" height="32" alt="Upload" /></td>
  <td><span data-ttu-id="59098-778">E898</span><span class="sxs-lookup"><span data-stu-id="59098-778">E898</span></span></td>
  <td><span data-ttu-id="59098-779">Upload</span><span class="sxs-lookup"><span data-stu-id="59098-779">Upload</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E899.png" width="32" height="32" alt="Emoji" /></td>
  <td><span data-ttu-id="59098-780">E899</span><span class="sxs-lookup"><span data-stu-id="59098-780">E899</span></span></td>
  <td><span data-ttu-id="59098-781">Emoji</span><span class="sxs-lookup"><span data-stu-id="59098-781">Emoji</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89A.png" width="32" height="32" alt="TwoPage" /></td>
  <td><span data-ttu-id="59098-782">E89A</span><span class="sxs-lookup"><span data-stu-id="59098-782">E89A</span></span></td>
  <td><span data-ttu-id="59098-783">TwoPage</span><span class="sxs-lookup"><span data-stu-id="59098-783">TwoPage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89B.png" width="32" height="32" alt="LeaveChat" /></td>
  <td><span data-ttu-id="59098-784">E89B</span><span class="sxs-lookup"><span data-stu-id="59098-784">E89B</span></span></td>
  <td><span data-ttu-id="59098-785">LeaveChat</span><span class="sxs-lookup"><span data-stu-id="59098-785">LeaveChat</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89C.png" width="32" height="32" alt="MailForward" /></td>
  <td><span data-ttu-id="59098-786">E89C</span><span class="sxs-lookup"><span data-stu-id="59098-786">E89C</span></span></td>
  <td><span data-ttu-id="59098-787">MailForward</span><span class="sxs-lookup"><span data-stu-id="59098-787">MailForward</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89E.png" width="32" height="32" alt="RotateCamera" /></td>
  <td><span data-ttu-id="59098-788">E89E</span><span class="sxs-lookup"><span data-stu-id="59098-788">E89E</span></span></td>
  <td><span data-ttu-id="59098-789">RotateCamera</span><span class="sxs-lookup"><span data-stu-id="59098-789">RotateCamera</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E89F.png" width="32" height="32" alt="ClosePane" /></td>
  <td><span data-ttu-id="59098-790">E89F</span><span class="sxs-lookup"><span data-stu-id="59098-790">E89F</span></span></td>
  <td><span data-ttu-id="59098-791">ClosePane</span><span class="sxs-lookup"><span data-stu-id="59098-791">ClosePane</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A0.png" width="32" height="32" alt="OpenPane" /></td>
  <td><span data-ttu-id="59098-792">E8A0</span><span class="sxs-lookup"><span data-stu-id="59098-792">E8A0</span></span></td>
  <td><span data-ttu-id="59098-793">OpenPane</span><span class="sxs-lookup"><span data-stu-id="59098-793">OpenPane</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A1.png" width="32" height="32" alt="PreviewLink" /></td>
  <td><span data-ttu-id="59098-794">E8A1</span><span class="sxs-lookup"><span data-stu-id="59098-794">E8A1</span></span></td>
  <td><span data-ttu-id="59098-795">PreviewLink</span><span class="sxs-lookup"><span data-stu-id="59098-795">PreviewLink</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A2.png" width="32" height="32" alt="AttachCamera" /></td>
  <td><span data-ttu-id="59098-796">E8A2</span><span class="sxs-lookup"><span data-stu-id="59098-796">E8A2</span></span></td>
  <td><span data-ttu-id="59098-797">AttachCamera</span><span class="sxs-lookup"><span data-stu-id="59098-797">AttachCamera</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A3.png" width="32" height="32" alt="ZoomIn" /></td>
  <td><span data-ttu-id="59098-798">E8A3</span><span class="sxs-lookup"><span data-stu-id="59098-798">E8A3</span></span></td>
  <td><span data-ttu-id="59098-799">ZoomIn</span><span class="sxs-lookup"><span data-stu-id="59098-799">ZoomIn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A4.png" width="32" height="32" alt="Bookmarks" /></td>
  <td><span data-ttu-id="59098-800">E8A4</span><span class="sxs-lookup"><span data-stu-id="59098-800">E8A4</span></span></td>
  <td><span data-ttu-id="59098-801">Bookmarks</span><span class="sxs-lookup"><span data-stu-id="59098-801">Bookmarks</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A5.png" width="32" height="32" alt="Document" /></td>
  <td><span data-ttu-id="59098-802">E8A5</span><span class="sxs-lookup"><span data-stu-id="59098-802">E8A5</span></span></td>
  <td><span data-ttu-id="59098-803">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="59098-803">Document</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A6.png" width="32" height="32" alt="ProtectedDocument" /></td>
  <td><span data-ttu-id="59098-804">E8A6</span><span class="sxs-lookup"><span data-stu-id="59098-804">E8A6</span></span></td>
  <td><span data-ttu-id="59098-805">ProtectedDocument</span><span class="sxs-lookup"><span data-stu-id="59098-805">ProtectedDocument</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A7.png" width="32" height="32" alt="OpenInNewWindow" /></td>
  <td><span data-ttu-id="59098-806">E8A7</span><span class="sxs-lookup"><span data-stu-id="59098-806">E8A7</span></span></td>
  <td><span data-ttu-id="59098-807">OpenInNewWindow</span><span class="sxs-lookup"><span data-stu-id="59098-807">OpenInNewWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A8.png" width="32" height="32" alt="MailFill" /></td>
  <td><span data-ttu-id="59098-808">E8A8</span><span class="sxs-lookup"><span data-stu-id="59098-808">E8A8</span></span></td>
  <td><span data-ttu-id="59098-809">MailFill</span><span class="sxs-lookup"><span data-stu-id="59098-809">MailFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8A9.png" width="32" height="32" alt="ViewAll" /></td>
  <td><span data-ttu-id="59098-810">E8A9</span><span class="sxs-lookup"><span data-stu-id="59098-810">E8A9</span></span></td>
  <td><span data-ttu-id="59098-811">ViewAll</span><span class="sxs-lookup"><span data-stu-id="59098-811">ViewAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AA.png" width="32" height="32" alt="VideoChat" /></td>
  <td><span data-ttu-id="59098-812">E8AA</span><span class="sxs-lookup"><span data-stu-id="59098-812">E8AA</span></span></td>
  <td><span data-ttu-id="59098-813">VideoChat</span><span class="sxs-lookup"><span data-stu-id="59098-813">VideoChat</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AB.png" width="32" height="32" alt="Switch" /></td>
  <td><span data-ttu-id="59098-814">E8AB</span><span class="sxs-lookup"><span data-stu-id="59098-814">E8AB</span></span></td>
  <td><span data-ttu-id="59098-815">Switch</span><span class="sxs-lookup"><span data-stu-id="59098-815">Switch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AC.png" width="32" height="32" alt="Rename" /></td>
  <td><span data-ttu-id="59098-816">E8AC</span><span class="sxs-lookup"><span data-stu-id="59098-816">E8AC</span></span></td>
  <td><span data-ttu-id="59098-817">Rename</span><span class="sxs-lookup"><span data-stu-id="59098-817">Rename</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AD.png" width="32" height="32" alt="Go" /></td>
  <td><span data-ttu-id="59098-818">E8AD</span><span class="sxs-lookup"><span data-stu-id="59098-818">E8AD</span></span></td>
  <td><span data-ttu-id="59098-819">Go</span><span class="sxs-lookup"><span data-stu-id="59098-819">Go</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AE.png" width="32" height="32" alt="SurfaceHub" /></td>
  <td><span data-ttu-id="59098-820">E8AE</span><span class="sxs-lookup"><span data-stu-id="59098-820">E8AE</span></span></td>
  <td><span data-ttu-id="59098-821">SurfaceHub</span><span class="sxs-lookup"><span data-stu-id="59098-821">SurfaceHub</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8AF.png" width="32" height="32" alt="Remote" /></td>
  <td><span data-ttu-id="59098-822">E8AF</span><span class="sxs-lookup"><span data-stu-id="59098-822">E8AF</span></span></td>
  <td><span data-ttu-id="59098-823">リモート</span><span class="sxs-lookup"><span data-stu-id="59098-823">Remote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B0.png" width="32" height="32" alt="Click" /></td>
  <td><span data-ttu-id="59098-824">E8B0</span><span class="sxs-lookup"><span data-stu-id="59098-824">E8B0</span></span></td>
  <td><span data-ttu-id="59098-825">Click</span><span class="sxs-lookup"><span data-stu-id="59098-825">Click</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B1.png" width="32" height="32" alt="Shuffle" /></td>
  <td><span data-ttu-id="59098-826">E8B1</span><span class="sxs-lookup"><span data-stu-id="59098-826">E8B1</span></span></td>
  <td><span data-ttu-id="59098-827">Shuffle</span><span class="sxs-lookup"><span data-stu-id="59098-827">Shuffle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B2.png" width="32" height="32" alt="Movies" /></td>
  <td><span data-ttu-id="59098-828">E8B2</span><span class="sxs-lookup"><span data-stu-id="59098-828">E8B2</span></span></td>
  <td><span data-ttu-id="59098-829">Movies</span><span class="sxs-lookup"><span data-stu-id="59098-829">Movies</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B3.png" width="32" height="32" alt="SelectAll" /></td>
  <td><span data-ttu-id="59098-830">E8B3</span><span class="sxs-lookup"><span data-stu-id="59098-830">E8B3</span></span></td>
  <td><span data-ttu-id="59098-831">SelectAll</span><span class="sxs-lookup"><span data-stu-id="59098-831">SelectAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B4.png" width="32" height="32" alt="Orientation" /></td>
  <td><span data-ttu-id="59098-832">E8B4</span><span class="sxs-lookup"><span data-stu-id="59098-832">E8B4</span></span></td>
  <td><span data-ttu-id="59098-833">Orientation</span><span class="sxs-lookup"><span data-stu-id="59098-833">Orientation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B5.png" width="32" height="32" alt="Import" /></td>
  <td><span data-ttu-id="59098-834">E8B5</span><span class="sxs-lookup"><span data-stu-id="59098-834">E8B5</span></span></td>
  <td><span data-ttu-id="59098-835">Import</span><span class="sxs-lookup"><span data-stu-id="59098-835">Import</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B6.png" width="32" height="32" alt="ImportAll" /></td>
  <td><span data-ttu-id="59098-836">E8B6</span><span class="sxs-lookup"><span data-stu-id="59098-836">E8B6</span></span></td>
  <td><span data-ttu-id="59098-837">ImportAll</span><span class="sxs-lookup"><span data-stu-id="59098-837">ImportAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B7.png" width="32" height="32" alt="Folder" /></td>
  <td><span data-ttu-id="59098-838">E8B7</span><span class="sxs-lookup"><span data-stu-id="59098-838">E8B7</span></span></td>
  <td><span data-ttu-id="59098-839">Folder</span><span class="sxs-lookup"><span data-stu-id="59098-839">Folder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B8.png" width="32" height="32" alt="Webcam" /></td>
  <td><span data-ttu-id="59098-840">E8B8</span><span class="sxs-lookup"><span data-stu-id="59098-840">E8B8</span></span></td>
  <td><span data-ttu-id="59098-841">Web カメラ</span><span class="sxs-lookup"><span data-stu-id="59098-841">Webcam</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8B9.png" width="32" height="32" alt="Picture" /></td>
  <td><span data-ttu-id="59098-842">E8B9</span><span class="sxs-lookup"><span data-stu-id="59098-842">E8B9</span></span></td>
  <td><span data-ttu-id="59098-843">画像</span><span class="sxs-lookup"><span data-stu-id="59098-843">Picture</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BA.png" width="32" height="32" alt="Caption" /></td>
  <td><span data-ttu-id="59098-844">E8BA</span><span class="sxs-lookup"><span data-stu-id="59098-844">E8BA</span></span></td>
  <td><span data-ttu-id="59098-845">Caption</span><span class="sxs-lookup"><span data-stu-id="59098-845">Caption</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BB.png" width="32" height="32" alt="ChromeClose" /></td>
  <td><span data-ttu-id="59098-846">E8BB</span><span class="sxs-lookup"><span data-stu-id="59098-846">E8BB</span></span></td>
  <td><span data-ttu-id="59098-847">ChromeClose</span><span class="sxs-lookup"><span data-stu-id="59098-847">ChromeClose</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BC.png" width="32" height="32" alt="ShowResults" /></td>
  <td><span data-ttu-id="59098-848">E8BC</span><span class="sxs-lookup"><span data-stu-id="59098-848">E8BC</span></span></td>
  <td><span data-ttu-id="59098-849">ShowResults</span><span class="sxs-lookup"><span data-stu-id="59098-849">ShowResults</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BD.png" width="32" height="32" alt="Message" /></td>
  <td><span data-ttu-id="59098-850">E8BD</span><span class="sxs-lookup"><span data-stu-id="59098-850">E8BD</span></span></td>
  <td><span data-ttu-id="59098-851">メッセージ</span><span class="sxs-lookup"><span data-stu-id="59098-851">Message</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BE.png" width="32" height="32" alt="Leaf" /></td>
  <td><span data-ttu-id="59098-852">E8BE</span><span class="sxs-lookup"><span data-stu-id="59098-852">E8BE</span></span></td>
  <td><span data-ttu-id="59098-853">Leaf</span><span class="sxs-lookup"><span data-stu-id="59098-853">Leaf</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8BF.png" width="32" height="32" alt="CalendarDay" /></td>
  <td><span data-ttu-id="59098-854">E8BF</span><span class="sxs-lookup"><span data-stu-id="59098-854">E8BF</span></span></td>
  <td><span data-ttu-id="59098-855">CalendarDay</span><span class="sxs-lookup"><span data-stu-id="59098-855">CalendarDay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C0.png" width="32" height="32" alt="CalendarWeek" /></td>
  <td><span data-ttu-id="59098-856">E8C0</span><span class="sxs-lookup"><span data-stu-id="59098-856">E8C0</span></span></td>
  <td><span data-ttu-id="59098-857">CalendarWeek</span><span class="sxs-lookup"><span data-stu-id="59098-857">CalendarWeek</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C1.png" width="32" height="32" alt="Characters" /></td>
  <td><span data-ttu-id="59098-858">E8C1</span><span class="sxs-lookup"><span data-stu-id="59098-858">E8C1</span></span></td>
  <td><span data-ttu-id="59098-859">Characters</span><span class="sxs-lookup"><span data-stu-id="59098-859">Characters</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C2.png" width="32" height="32" alt="MailReplyAll" /></td>
  <td><span data-ttu-id="59098-860">E8C2</span><span class="sxs-lookup"><span data-stu-id="59098-860">E8C2</span></span></td>
  <td><span data-ttu-id="59098-861">MailReplyAll</span><span class="sxs-lookup"><span data-stu-id="59098-861">MailReplyAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C3.png" width="32" height="32" alt="Read" /></td>
  <td><span data-ttu-id="59098-862">E8C3</span><span class="sxs-lookup"><span data-stu-id="59098-862">E8C3</span></span></td>
  <td><span data-ttu-id="59098-863">Read</span><span class="sxs-lookup"><span data-stu-id="59098-863">Read</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C4.png" width="32" height="32" alt="ShowBcc" /></td>
  <td><span data-ttu-id="59098-864">E8C4</span><span class="sxs-lookup"><span data-stu-id="59098-864">E8C4</span></span></td>
  <td><span data-ttu-id="59098-865">ShowBcc</span><span class="sxs-lookup"><span data-stu-id="59098-865">ShowBcc</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C5.png" width="32" height="32" alt="HideBcc" /></td>
  <td><span data-ttu-id="59098-866">E8C5</span><span class="sxs-lookup"><span data-stu-id="59098-866">E8C5</span></span></td>
  <td><span data-ttu-id="59098-867">HideBcc</span><span class="sxs-lookup"><span data-stu-id="59098-867">HideBcc</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C6.png" width="32" height="32" alt="Cut" /></td>
  <td><span data-ttu-id="59098-868">E8C6</span><span class="sxs-lookup"><span data-stu-id="59098-868">E8C6</span></span></td>
  <td><span data-ttu-id="59098-869">切り取り</span><span class="sxs-lookup"><span data-stu-id="59098-869">Cut</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C7.png" width="32" height="32" alt="PaymentCard" /></td>
  <td><span data-ttu-id="59098-870">E8C7</span><span class="sxs-lookup"><span data-stu-id="59098-870">E8C7</span></span></td>
  <td><span data-ttu-id="59098-871">PaymentCard</span><span class="sxs-lookup"><span data-stu-id="59098-871">PaymentCard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C8.png" width="32" height="32" alt="Copy" /></td>
  <td><span data-ttu-id="59098-872">E8C8</span><span class="sxs-lookup"><span data-stu-id="59098-872">E8C8</span></span></td>
  <td><span data-ttu-id="59098-873">コピー</span><span class="sxs-lookup"><span data-stu-id="59098-873">Copy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8C9.png" width="32" height="32" alt="Important" /></td>
  <td><span data-ttu-id="59098-874">E8C9</span><span class="sxs-lookup"><span data-stu-id="59098-874">E8C9</span></span></td>
  <td><span data-ttu-id="59098-875">重要</span><span class="sxs-lookup"><span data-stu-id="59098-875">Important</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CA.png" width="32" height="32" alt="MailReply" /></td>
  <td><span data-ttu-id="59098-876">E8CA</span><span class="sxs-lookup"><span data-stu-id="59098-876">E8CA</span></span></td>
  <td><span data-ttu-id="59098-877">MailReply</span><span class="sxs-lookup"><span data-stu-id="59098-877">MailReply</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CB.png" width="32" height="32" alt="Sort" /></td>
  <td><span data-ttu-id="59098-878">E8CB</span><span class="sxs-lookup"><span data-stu-id="59098-878">E8CB</span></span></td>
  <td><span data-ttu-id="59098-879">Sort</span><span class="sxs-lookup"><span data-stu-id="59098-879">Sort</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CC.png" width="32" height="32" alt="MobileTablet" /></td>
  <td><span data-ttu-id="59098-880">E8CC</span><span class="sxs-lookup"><span data-stu-id="59098-880">E8CC</span></span></td>
  <td><span data-ttu-id="59098-881">MobileTablet</span><span class="sxs-lookup"><span data-stu-id="59098-881">MobileTablet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CD.png" width="32" height="32" alt="DisconnectDrive" /></td>
  <td><span data-ttu-id="59098-882">E8CD</span><span class="sxs-lookup"><span data-stu-id="59098-882">E8CD</span></span></td>
  <td><span data-ttu-id="59098-883">DisconnectDrive</span><span class="sxs-lookup"><span data-stu-id="59098-883">DisconnectDrive</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CE.png" width="32" height="32" alt="MapDrive" /></td>
  <td><span data-ttu-id="59098-884">E8CE</span><span class="sxs-lookup"><span data-stu-id="59098-884">E8CE</span></span></td>
  <td><span data-ttu-id="59098-885">MapDrive</span><span class="sxs-lookup"><span data-stu-id="59098-885">MapDrive</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8CF.png" width="32" height="32" alt="ContactPresence" /></td>
  <td><span data-ttu-id="59098-886">E8CF</span><span class="sxs-lookup"><span data-stu-id="59098-886">E8CF</span></span></td>
  <td><span data-ttu-id="59098-887">ContactPresence</span><span class="sxs-lookup"><span data-stu-id="59098-887">ContactPresence</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D0.png" width="32" height="32" alt="Priority" /></td>
  <td><span data-ttu-id="59098-888">E8D0</span><span class="sxs-lookup"><span data-stu-id="59098-888">E8D0</span></span></td>
  <td><span data-ttu-id="59098-889">Priority</span><span class="sxs-lookup"><span data-stu-id="59098-889">Priority</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D1.png" width="32" height="32" alt="GotoToday" /></td>
  <td><span data-ttu-id="59098-890">E8D1</span><span class="sxs-lookup"><span data-stu-id="59098-890">E8D1</span></span></td>
  <td><span data-ttu-id="59098-891">GotoToday</span><span class="sxs-lookup"><span data-stu-id="59098-891">GotoToday</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D2.png" width="32" height="32" alt="Font" /></td>
  <td><span data-ttu-id="59098-892">E8D2</span><span class="sxs-lookup"><span data-stu-id="59098-892">E8D2</span></span></td>
  <td><span data-ttu-id="59098-893">Font</span><span class="sxs-lookup"><span data-stu-id="59098-893">Font</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D3.png" width="32" height="32" alt="FontColor" /></td>
  <td><span data-ttu-id="59098-894">E8D3</span><span class="sxs-lookup"><span data-stu-id="59098-894">E8D3</span></span></td>
  <td><span data-ttu-id="59098-895">FontColor</span><span class="sxs-lookup"><span data-stu-id="59098-895">FontColor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D4.png" width="32" height="32" alt="Contact2" /></td>
  <td><span data-ttu-id="59098-896">E8D4</span><span class="sxs-lookup"><span data-stu-id="59098-896">E8D4</span></span></td>
  <td><span data-ttu-id="59098-897">Contact2</span><span class="sxs-lookup"><span data-stu-id="59098-897">Contact2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D5.png" width="32" height="32" alt="FolderFill" /></td>
  <td><span data-ttu-id="59098-898">E8D5</span><span class="sxs-lookup"><span data-stu-id="59098-898">E8D5</span></span></td>
  <td><span data-ttu-id="59098-899">FolderFill</span><span class="sxs-lookup"><span data-stu-id="59098-899">FolderFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D6.png" width="32" height="32" alt="Audio" /></td>
  <td><span data-ttu-id="59098-900">E8D6</span><span class="sxs-lookup"><span data-stu-id="59098-900">E8D6</span></span></td>
  <td><span data-ttu-id="59098-901">オーディオ</span><span class="sxs-lookup"><span data-stu-id="59098-901">Audio</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D7.png" width="32" height="32" alt="Permissions" /></td>
  <td><span data-ttu-id="59098-902">E8D7</span><span class="sxs-lookup"><span data-stu-id="59098-902">E8D7</span></span></td>
  <td><span data-ttu-id="59098-903">アクセス許可</span><span class="sxs-lookup"><span data-stu-id="59098-903">Permissions</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D8.png" width="32" height="32" alt="DisableUpdates" /></td>
  <td><span data-ttu-id="59098-904">E8D8</span><span class="sxs-lookup"><span data-stu-id="59098-904">E8D8</span></span></td>
  <td><span data-ttu-id="59098-905">DisableUpdates</span><span class="sxs-lookup"><span data-stu-id="59098-905">DisableUpdates</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8D9.png" width="32" height="32" alt="Unfavorite" /></td>
  <td><span data-ttu-id="59098-906">E8D9</span><span class="sxs-lookup"><span data-stu-id="59098-906">E8D9</span></span></td>
  <td><span data-ttu-id="59098-907">Unfavorite</span><span class="sxs-lookup"><span data-stu-id="59098-907">Unfavorite</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DA.png" width="32" height="32" alt="OpenLocal" /></td>
  <td><span data-ttu-id="59098-908">E8DA</span><span class="sxs-lookup"><span data-stu-id="59098-908">E8DA</span></span></td>
  <td><span data-ttu-id="59098-909">OpenLocal</span><span class="sxs-lookup"><span data-stu-id="59098-909">OpenLocal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DB.png" width="32" height="32" alt="Italic" /></td>
  <td><span data-ttu-id="59098-910">E8DB</span><span class="sxs-lookup"><span data-stu-id="59098-910">E8DB</span></span></td>
  <td><span data-ttu-id="59098-911">Italic</span><span class="sxs-lookup"><span data-stu-id="59098-911">Italic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DC.png" width="32" height="32" alt="Underline" /></td>
  <td><span data-ttu-id="59098-912">E8DC</span><span class="sxs-lookup"><span data-stu-id="59098-912">E8DC</span></span></td>
  <td><span data-ttu-id="59098-913">Underline</span><span class="sxs-lookup"><span data-stu-id="59098-913">Underline</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DD.png" width="32" height="32" alt="Bold" /></td>
  <td><span data-ttu-id="59098-914">E8DD</span><span class="sxs-lookup"><span data-stu-id="59098-914">E8DD</span></span></td>
  <td><span data-ttu-id="59098-915">Bold</span><span class="sxs-lookup"><span data-stu-id="59098-915">Bold</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DE.png" width="32" height="32" alt="MoveToFolder" /></td>
  <td><span data-ttu-id="59098-916">E8DE</span><span class="sxs-lookup"><span data-stu-id="59098-916">E8DE</span></span></td>
  <td><span data-ttu-id="59098-917">MoveToFolder</span><span class="sxs-lookup"><span data-stu-id="59098-917">MoveToFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8DF.png" width="32" height="32" alt="LikeDislike" /></td>
  <td><span data-ttu-id="59098-918">E8DF</span><span class="sxs-lookup"><span data-stu-id="59098-918">E8DF</span></span></td>
  <td><span data-ttu-id="59098-919">LikeDislike</span><span class="sxs-lookup"><span data-stu-id="59098-919">LikeDislike</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E0.png" width="32" height="32" alt="Dislike" /></td>
  <td><span data-ttu-id="59098-920">E8E0</span><span class="sxs-lookup"><span data-stu-id="59098-920">E8E0</span></span></td>
  <td><span data-ttu-id="59098-921">Dislike</span><span class="sxs-lookup"><span data-stu-id="59098-921">Dislike</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E1.png" width="32" height="32" alt="Like" /></td>
  <td><span data-ttu-id="59098-922">E8E1</span><span class="sxs-lookup"><span data-stu-id="59098-922">E8E1</span></span></td>
  <td><span data-ttu-id="59098-923">Like</span><span class="sxs-lookup"><span data-stu-id="59098-923">Like</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E2.png" width="32" height="32" alt="AlignRight" /></td>
  <td><span data-ttu-id="59098-924">E8E2</span><span class="sxs-lookup"><span data-stu-id="59098-924">E8E2</span></span></td>
  <td><span data-ttu-id="59098-925">AlignRight</span><span class="sxs-lookup"><span data-stu-id="59098-925">AlignRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E3.png" width="32" height="32" alt="AlignCenter" /></td>
  <td><span data-ttu-id="59098-926">E8E3</span><span class="sxs-lookup"><span data-stu-id="59098-926">E8E3</span></span></td>
  <td><span data-ttu-id="59098-927">AlignCenter</span><span class="sxs-lookup"><span data-stu-id="59098-927">AlignCenter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E4.png" width="32" height="32" alt="AlignLeft" /></td>
  <td><span data-ttu-id="59098-928">E8E4</span><span class="sxs-lookup"><span data-stu-id="59098-928">E8E4</span></span></td>
  <td><span data-ttu-id="59098-929">AlignLeft</span><span class="sxs-lookup"><span data-stu-id="59098-929">AlignLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E5.png" width="32" height="32" alt="OpenFile" /></td>
  <td><span data-ttu-id="59098-930">E8E5</span><span class="sxs-lookup"><span data-stu-id="59098-930">E8E5</span></span></td>
  <td><span data-ttu-id="59098-931">OpenFile</span><span class="sxs-lookup"><span data-stu-id="59098-931">OpenFile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E6.png" width="32" height="32" alt="ClearSelection" /></td>
  <td><span data-ttu-id="59098-932">E8E6</span><span class="sxs-lookup"><span data-stu-id="59098-932">E8E6</span></span></td>
  <td><span data-ttu-id="59098-933">ClearSelection</span><span class="sxs-lookup"><span data-stu-id="59098-933">ClearSelection</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E7.png" width="32" height="32" alt="FontDecrease" /></td>
  <td><span data-ttu-id="59098-934">E8E7</span><span class="sxs-lookup"><span data-stu-id="59098-934">E8E7</span></span></td>
  <td><span data-ttu-id="59098-935">FontDecrease</span><span class="sxs-lookup"><span data-stu-id="59098-935">FontDecrease</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E8.png" width="32" height="32" alt="FontIncrease" /></td>
  <td><span data-ttu-id="59098-936">E8E8</span><span class="sxs-lookup"><span data-stu-id="59098-936">E8E8</span></span></td>
  <td><span data-ttu-id="59098-937">FontIncrease</span><span class="sxs-lookup"><span data-stu-id="59098-937">FontIncrease</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8E9.png" width="32" height="32" alt="FontSize" /></td>
  <td><span data-ttu-id="59098-938">E8E9</span><span class="sxs-lookup"><span data-stu-id="59098-938">E8E9</span></span></td>
  <td><span data-ttu-id="59098-939">FontSize</span><span class="sxs-lookup"><span data-stu-id="59098-939">FontSize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EA.png" width="32" height="32" alt="CellPhone" /></td>
  <td><span data-ttu-id="59098-940">E8EA</span><span class="sxs-lookup"><span data-stu-id="59098-940">E8EA</span></span></td>
  <td><span data-ttu-id="59098-941">CellPhone</span><span class="sxs-lookup"><span data-stu-id="59098-941">CellPhone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EB.png" width="32" height="32" alt="Reshare" /></td>
  <td><span data-ttu-id="59098-942">E8EB</span><span class="sxs-lookup"><span data-stu-id="59098-942">E8EB</span></span></td>
  <td><span data-ttu-id="59098-943">Reshare</span><span class="sxs-lookup"><span data-stu-id="59098-943">Reshare</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EC.png" width="32" height="32" alt="Tag" /></td>
  <td><span data-ttu-id="59098-944">E8EC</span><span class="sxs-lookup"><span data-stu-id="59098-944">E8EC</span></span></td>
  <td><span data-ttu-id="59098-945">Tag</span><span class="sxs-lookup"><span data-stu-id="59098-945">Tag</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8ED.png" width="32" height="32" alt="RepeatOne" /></td>
  <td><span data-ttu-id="59098-946">E8ED</span><span class="sxs-lookup"><span data-stu-id="59098-946">E8ED</span></span></td>
  <td><span data-ttu-id="59098-947">RepeatOne</span><span class="sxs-lookup"><span data-stu-id="59098-947">RepeatOne</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EE.png" width="32" height="32" alt="RepeatAll" /></td>
  <td><span data-ttu-id="59098-948">E8EE</span><span class="sxs-lookup"><span data-stu-id="59098-948">E8EE</span></span></td>
  <td><span data-ttu-id="59098-949">RepeatAll</span><span class="sxs-lookup"><span data-stu-id="59098-949">RepeatAll</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8EF.png" width="32" height="32" alt="Calculator" /></td>
  <td><span data-ttu-id="59098-950">E8EF</span><span class="sxs-lookup"><span data-stu-id="59098-950">E8EF</span></span></td>
  <td><span data-ttu-id="59098-951">電卓</span><span class="sxs-lookup"><span data-stu-id="59098-951">Calculator</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F0.png" width="32" height="32" alt="Directions" /></td>
  <td><span data-ttu-id="59098-952">E8F0</span><span class="sxs-lookup"><span data-stu-id="59098-952">E8F0</span></span></td>
  <td><span data-ttu-id="59098-953">Directions</span><span class="sxs-lookup"><span data-stu-id="59098-953">Directions</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F1.png" width="32" height="32" alt="Library" /></td>
  <td><span data-ttu-id="59098-954">E8F1</span><span class="sxs-lookup"><span data-stu-id="59098-954">E8F1</span></span></td>
  <td><span data-ttu-id="59098-955">Library</span><span class="sxs-lookup"><span data-stu-id="59098-955">Library</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F2.png" width="32" height="32" alt="ChatBubbles" /></td>
  <td><span data-ttu-id="59098-956">E8F2</span><span class="sxs-lookup"><span data-stu-id="59098-956">E8F2</span></span></td>
  <td><span data-ttu-id="59098-957">ChatBubbles</span><span class="sxs-lookup"><span data-stu-id="59098-957">ChatBubbles</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F3.png" width="32" height="32" alt="PostUpdate" /></td>
  <td><span data-ttu-id="59098-958">E8F3</span><span class="sxs-lookup"><span data-stu-id="59098-958">E8F3</span></span></td>
  <td><span data-ttu-id="59098-959">PostUpdate</span><span class="sxs-lookup"><span data-stu-id="59098-959">PostUpdate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F4.png" width="32" height="32" alt="NewFolder" /></td>
  <td><span data-ttu-id="59098-960">E8F4</span><span class="sxs-lookup"><span data-stu-id="59098-960">E8F4</span></span></td>
  <td><span data-ttu-id="59098-961">NewFolder</span><span class="sxs-lookup"><span data-stu-id="59098-961">NewFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F5.png" width="32" height="32" alt="CalendarReply" /></td>
  <td><span data-ttu-id="59098-962">E8F5</span><span class="sxs-lookup"><span data-stu-id="59098-962">E8F5</span></span></td>
  <td><span data-ttu-id="59098-963">CalendarReply</span><span class="sxs-lookup"><span data-stu-id="59098-963">CalendarReply</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F6.png" width="32" height="32" alt="UnsyncFolder" /></td>
  <td><span data-ttu-id="59098-964">E8F6</span><span class="sxs-lookup"><span data-stu-id="59098-964">E8F6</span></span></td>
  <td><span data-ttu-id="59098-965">UnsyncFolder</span><span class="sxs-lookup"><span data-stu-id="59098-965">UnsyncFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F7.png" width="32" height="32" alt="SyncFolder" /></td>
  <td><span data-ttu-id="59098-966">E8F7</span><span class="sxs-lookup"><span data-stu-id="59098-966">E8F7</span></span></td>
  <td><span data-ttu-id="59098-967">SyncFolder</span><span class="sxs-lookup"><span data-stu-id="59098-967">SyncFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F8.png" width="32" height="32" alt="BlockContact" /></td>
  <td><span data-ttu-id="59098-968">E8F8</span><span class="sxs-lookup"><span data-stu-id="59098-968">E8F8</span></span></td>
  <td><span data-ttu-id="59098-969">BlockContact</span><span class="sxs-lookup"><span data-stu-id="59098-969">BlockContact</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8F9.png" width="32" height="32" alt="SwitchApps" /></td>
  <td><span data-ttu-id="59098-970">E8F9</span><span class="sxs-lookup"><span data-stu-id="59098-970">E8F9</span></span></td>
  <td><span data-ttu-id="59098-971">SwitchApps</span><span class="sxs-lookup"><span data-stu-id="59098-971">SwitchApps</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FA.png" width="32" height="32" alt="AddFriend" /></td>
  <td><span data-ttu-id="59098-972">E8FA</span><span class="sxs-lookup"><span data-stu-id="59098-972">E8FA</span></span></td>
  <td><span data-ttu-id="59098-973">AddFriend</span><span class="sxs-lookup"><span data-stu-id="59098-973">AddFriend</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FB.png" width="32" height="32" alt="Accept" /></td>
  <td><span data-ttu-id="59098-974">E8FB</span><span class="sxs-lookup"><span data-stu-id="59098-974">E8FB</span></span></td>
  <td><span data-ttu-id="59098-975">OK</span><span class="sxs-lookup"><span data-stu-id="59098-975">Accept</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FC.png" width="32" height="32" alt="GoToStart" /></td>
  <td><span data-ttu-id="59098-976">E8FC</span><span class="sxs-lookup"><span data-stu-id="59098-976">E8FC</span></span></td>
  <td><span data-ttu-id="59098-977">GoToStart</span><span class="sxs-lookup"><span data-stu-id="59098-977">GoToStart</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FD.png" width="32" height="32" alt="BulletedList" /></td>
  <td><span data-ttu-id="59098-978">E8FD</span><span class="sxs-lookup"><span data-stu-id="59098-978">E8FD</span></span></td>
  <td><span data-ttu-id="59098-979">BulletedList</span><span class="sxs-lookup"><span data-stu-id="59098-979">BulletedList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FE.png" width="32" height="32" alt="Scan" /></td>
  <td><span data-ttu-id="59098-980">E8FE</span><span class="sxs-lookup"><span data-stu-id="59098-980">E8FE</span></span></td>
  <td><span data-ttu-id="59098-981">Scan</span><span class="sxs-lookup"><span data-stu-id="59098-981">Scan</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E8FF.png" width="32" height="32" alt="Preview" /></td>
  <td><span data-ttu-id="59098-982">E8FF</span><span class="sxs-lookup"><span data-stu-id="59098-982">E8FF</span></span></td>
  <td><span data-ttu-id="59098-983">Preview</span><span class="sxs-lookup"><span data-stu-id="59098-983">Preview</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E902.png" width="32" height="32" alt="Group" /></td>
  <td><span data-ttu-id="59098-984">E902</span><span class="sxs-lookup"><span data-stu-id="59098-984">E902</span></span></td>
  <td><span data-ttu-id="59098-985">グループ</span><span class="sxs-lookup"><span data-stu-id="59098-985">Group</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E904.png" width="32" height="32" alt="ZeroBars" /></td>
  <td><span data-ttu-id="59098-986">E904</span><span class="sxs-lookup"><span data-stu-id="59098-986">E904</span></span></td>
  <td><span data-ttu-id="59098-987">ZeroBars</span><span class="sxs-lookup"><span data-stu-id="59098-987">ZeroBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E905.png" width="32" height="32" alt="OneBar" /></td>
  <td><span data-ttu-id="59098-988">E905</span><span class="sxs-lookup"><span data-stu-id="59098-988">E905</span></span></td>
  <td><span data-ttu-id="59098-989">OneBar</span><span class="sxs-lookup"><span data-stu-id="59098-989">OneBar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E906.png" width="32" height="32" alt="TwoBars" /></td>
  <td><span data-ttu-id="59098-990">E906</span><span class="sxs-lookup"><span data-stu-id="59098-990">E906</span></span></td>
  <td><span data-ttu-id="59098-991">TwoBars</span><span class="sxs-lookup"><span data-stu-id="59098-991">TwoBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E907.png" width="32" height="32" alt="ThreeBars" /></td>
  <td><span data-ttu-id="59098-992">E907</span><span class="sxs-lookup"><span data-stu-id="59098-992">E907</span></span></td>
  <td><span data-ttu-id="59098-993">ThreeBars</span><span class="sxs-lookup"><span data-stu-id="59098-993">ThreeBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E908.png" width="32" height="32" alt="FourBars" /></td>
  <td><span data-ttu-id="59098-994">E908</span><span class="sxs-lookup"><span data-stu-id="59098-994">E908</span></span></td>
  <td><span data-ttu-id="59098-995">FourBars</span><span class="sxs-lookup"><span data-stu-id="59098-995">FourBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E909.png" width="32" height="32" alt="World" /></td>
  <td><span data-ttu-id="59098-996">E909</span><span class="sxs-lookup"><span data-stu-id="59098-996">E909</span></span></td>
  <td><span data-ttu-id="59098-997">World</span><span class="sxs-lookup"><span data-stu-id="59098-997">World</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90A.png" width="32" height="32" alt="Comment" /></td>
  <td><span data-ttu-id="59098-998">E90A</span><span class="sxs-lookup"><span data-stu-id="59098-998">E90A</span></span></td>
  <td><span data-ttu-id="59098-999">Comment</span><span class="sxs-lookup"><span data-stu-id="59098-999">Comment</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90B.png" width="32" height="32" alt="MusicInfo" /></td>
  <td><span data-ttu-id="59098-1000">E90B</span><span class="sxs-lookup"><span data-stu-id="59098-1000">E90B</span></span></td>
  <td><span data-ttu-id="59098-1001">MusicInfo</span><span class="sxs-lookup"><span data-stu-id="59098-1001">MusicInfo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90C.png" width="32" height="32" alt="DockLeft" /></td>
  <td><span data-ttu-id="59098-1002">E90C</span><span class="sxs-lookup"><span data-stu-id="59098-1002">E90C</span></span></td>
  <td><span data-ttu-id="59098-1003">DockLeft</span><span class="sxs-lookup"><span data-stu-id="59098-1003">DockLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90D.png" width="32" height="32" alt="DockRight" /></td>
  <td><span data-ttu-id="59098-1004">E90D</span><span class="sxs-lookup"><span data-stu-id="59098-1004">E90D</span></span></td>
  <td><span data-ttu-id="59098-1005">DockRight</span><span class="sxs-lookup"><span data-stu-id="59098-1005">DockRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90E.png" width="32" height="32" alt="DockBottom" /></td>
  <td><span data-ttu-id="59098-1006">E90E</span><span class="sxs-lookup"><span data-stu-id="59098-1006">E90E</span></span></td>
  <td><span data-ttu-id="59098-1007">DockBottom</span><span class="sxs-lookup"><span data-stu-id="59098-1007">DockBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E90F.png" width="32" height="32" alt="Repair" /></td>
  <td><span data-ttu-id="59098-1008">E90F</span><span class="sxs-lookup"><span data-stu-id="59098-1008">E90F</span></span></td>
  <td><span data-ttu-id="59098-1009">Repair</span><span class="sxs-lookup"><span data-stu-id="59098-1009">Repair</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E910.png" width="32" height="32" alt="Accounts" /></td>
  <td><span data-ttu-id="59098-1010">E910</span><span class="sxs-lookup"><span data-stu-id="59098-1010">E910</span></span></td>
  <td><span data-ttu-id="59098-1011">Accounts</span><span class="sxs-lookup"><span data-stu-id="59098-1011">Accounts</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E911.png" width="32" height="32" alt="DullSound" /></td>
  <td><span data-ttu-id="59098-1012">E911</span><span class="sxs-lookup"><span data-stu-id="59098-1012">E911</span></span></td>
  <td><span data-ttu-id="59098-1013">DullSound</span><span class="sxs-lookup"><span data-stu-id="59098-1013">DullSound</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E912.png" width="32" height="32" alt="Manage" /></td>
  <td><span data-ttu-id="59098-1014">E912</span><span class="sxs-lookup"><span data-stu-id="59098-1014">E912</span></span></td>
  <td><span data-ttu-id="59098-1015">管理</span><span class="sxs-lookup"><span data-stu-id="59098-1015">Manage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E913.png" width="32" height="32" alt="Street" /></td>
  <td><span data-ttu-id="59098-1016">E913</span><span class="sxs-lookup"><span data-stu-id="59098-1016">E913</span></span></td>
  <td><span data-ttu-id="59098-1017">Street</span><span class="sxs-lookup"><span data-stu-id="59098-1017">Street</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E914.png" width="32" height="32" alt="Printer3D" /></td>
  <td><span data-ttu-id="59098-1018">E914</span><span class="sxs-lookup"><span data-stu-id="59098-1018">E914</span></span></td>
  <td><span data-ttu-id="59098-1019">Printer3D</span><span class="sxs-lookup"><span data-stu-id="59098-1019">Printer3D</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E915.png" width="32" height="32" alt="RadioBullet" /></td>
  <td><span data-ttu-id="59098-1020">E915</span><span class="sxs-lookup"><span data-stu-id="59098-1020">E915</span></span></td>
  <td><span data-ttu-id="59098-1021">RadioBullet</span><span class="sxs-lookup"><span data-stu-id="59098-1021">RadioBullet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E916.png" width="32" height="32" alt="Stopwatch" /></td>
  <td><span data-ttu-id="59098-1022">E916</span><span class="sxs-lookup"><span data-stu-id="59098-1022">E916</span></span></td>
  <td><span data-ttu-id="59098-1023">Stopwatch</span><span class="sxs-lookup"><span data-stu-id="59098-1023">Stopwatch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E91B.png" width="32" height="32" alt="Photo" /></td>
  <td><span data-ttu-id="59098-1024">E91B</span><span class="sxs-lookup"><span data-stu-id="59098-1024">E91B</span></span></td>
  <td><span data-ttu-id="59098-1025">Photo</span><span class="sxs-lookup"><span data-stu-id="59098-1025">Photo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E91C.png" width="32" height="32" alt="ActionCenter" /></td>
  <td><span data-ttu-id="59098-1026">E91C</span><span class="sxs-lookup"><span data-stu-id="59098-1026">E91C</span></span></td>
  <td><span data-ttu-id="59098-1027">ActionCenter</span><span class="sxs-lookup"><span data-stu-id="59098-1027">ActionCenter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E91F.png" width="32" height="32" alt="FullCircleMask" /></td>
  <td><span data-ttu-id="59098-1028">E91F</span><span class="sxs-lookup"><span data-stu-id="59098-1028">E91F</span></span></td>
  <td><span data-ttu-id="59098-1029">FullCircleMask</span><span class="sxs-lookup"><span data-stu-id="59098-1029">FullCircleMask</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E921.png" width="32" height="32" alt="ChromeMinimize" /></td>
  <td><span data-ttu-id="59098-1030">E921</span><span class="sxs-lookup"><span data-stu-id="59098-1030">E921</span></span></td>
  <td><span data-ttu-id="59098-1031">ChromeMinimize</span><span class="sxs-lookup"><span data-stu-id="59098-1031">ChromeMinimize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E922.png" width="32" height="32" alt="ChromeMaximize" /></td>
  <td><span data-ttu-id="59098-1032">E922</span><span class="sxs-lookup"><span data-stu-id="59098-1032">E922</span></span></td>
  <td><span data-ttu-id="59098-1033">ChromeMaximize</span><span class="sxs-lookup"><span data-stu-id="59098-1033">ChromeMaximize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E923.png" width="32" height="32" alt="ChromeRestore" /></td>
  <td><span data-ttu-id="59098-1034">E923</span><span class="sxs-lookup"><span data-stu-id="59098-1034">E923</span></span></td>
  <td><span data-ttu-id="59098-1035">ChromeRestore</span><span class="sxs-lookup"><span data-stu-id="59098-1035">ChromeRestore</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E924.png" width="32" height="32" alt="Annotation" /></td>
  <td><span data-ttu-id="59098-1036">E924</span><span class="sxs-lookup"><span data-stu-id="59098-1036">E924</span></span></td>
  <td><span data-ttu-id="59098-1037">Annotation</span><span class="sxs-lookup"><span data-stu-id="59098-1037">Annotation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E925.png" width="32" height="32" alt="BackSpaceQWERTYSm" /></td>
  <td><span data-ttu-id="59098-1038">E925</span><span class="sxs-lookup"><span data-stu-id="59098-1038">E925</span></span></td>
  <td><span data-ttu-id="59098-1039">BackSpaceQWERTYSm</span><span class="sxs-lookup"><span data-stu-id="59098-1039">BackSpaceQWERTYSm</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E926.png" width="32" height="32" alt="BackSpaceQWERTYMd" /></td>
  <td><span data-ttu-id="59098-1040">E926</span><span class="sxs-lookup"><span data-stu-id="59098-1040">E926</span></span></td>
  <td><span data-ttu-id="59098-1041">BackSpaceQWERTYMd</span><span class="sxs-lookup"><span data-stu-id="59098-1041">BackSpaceQWERTYMd</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E927.png" width="32" height="32" alt="Swipe" /></td>
  <td><span data-ttu-id="59098-1042">E927</span><span class="sxs-lookup"><span data-stu-id="59098-1042">E927</span></span></td>
  <td><span data-ttu-id="59098-1043">スワイプ</span><span class="sxs-lookup"><span data-stu-id="59098-1043">Swipe</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E928.png" width="32" height="32" alt="Fingerprint" /></td>
  <td><span data-ttu-id="59098-1044">E928</span><span class="sxs-lookup"><span data-stu-id="59098-1044">E928</span></span></td>
  <td><span data-ttu-id="59098-1045">Fingerprint</span><span class="sxs-lookup"><span data-stu-id="59098-1045">Fingerprint</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E929.png" width="32" height="32" alt="Handwriting" /></td>
  <td><span data-ttu-id="59098-1046">E929</span><span class="sxs-lookup"><span data-stu-id="59098-1046">E929</span></span></td>
  <td><span data-ttu-id="59098-1047">Handwriting</span><span class="sxs-lookup"><span data-stu-id="59098-1047">Handwriting</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E92C.png" width="32" height="32" alt="ChromeBackToWindow" /></td>
  <td><span data-ttu-id="59098-1048">E92C</span><span class="sxs-lookup"><span data-stu-id="59098-1048">E92C</span></span></td>
  <td><span data-ttu-id="59098-1049">ChromeBackToWindow</span><span class="sxs-lookup"><span data-stu-id="59098-1049">ChromeBackToWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E92D.png" width="32" height="32" alt="ChromeFullScreen" /></td>
  <td><span data-ttu-id="59098-1050">E92D</span><span class="sxs-lookup"><span data-stu-id="59098-1050">E92D</span></span></td>
  <td><span data-ttu-id="59098-1051">ChromeFullScreen</span><span class="sxs-lookup"><span data-stu-id="59098-1051">ChromeFullScreen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E92E.png" width="32" height="32" alt="KeyboardStandard" /></td>
  <td><span data-ttu-id="59098-1052">E92E</span><span class="sxs-lookup"><span data-stu-id="59098-1052">E92E</span></span></td>
  <td><span data-ttu-id="59098-1053">KeyboardStandard</span><span class="sxs-lookup"><span data-stu-id="59098-1053">KeyboardStandard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E92F.png" width="32" height="32" alt="KeyboardDismiss" /></td>
  <td><span data-ttu-id="59098-1054">E92F</span><span class="sxs-lookup"><span data-stu-id="59098-1054">E92F</span></span></td>
  <td><span data-ttu-id="59098-1055">KeyboardDismiss</span><span class="sxs-lookup"><span data-stu-id="59098-1055">KeyboardDismiss</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E930.png" width="32" height="32" alt="Completed" /></td>
  <td><span data-ttu-id="59098-1056">E930</span><span class="sxs-lookup"><span data-stu-id="59098-1056">E930</span></span></td>
  <td><span data-ttu-id="59098-1057">Completed</span><span class="sxs-lookup"><span data-stu-id="59098-1057">Completed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E931.png" width="32" height="32" alt="ChromeAnnotate" /></td>
  <td><span data-ttu-id="59098-1058">E931</span><span class="sxs-lookup"><span data-stu-id="59098-1058">E931</span></span></td>
  <td><span data-ttu-id="59098-1059">ChromeAnnotate</span><span class="sxs-lookup"><span data-stu-id="59098-1059">ChromeAnnotate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E932.png" width="32" height="32" alt="Label" /></td>
  <td><span data-ttu-id="59098-1060">E932</span><span class="sxs-lookup"><span data-stu-id="59098-1060">E932</span></span></td>
  <td><span data-ttu-id="59098-1061">Label</span><span class="sxs-lookup"><span data-stu-id="59098-1061">Label</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E933.png" width="32" height="32" alt="IBeam" /></td>
  <td><span data-ttu-id="59098-1062">E933</span><span class="sxs-lookup"><span data-stu-id="59098-1062">E933</span></span></td>
  <td><span data-ttu-id="59098-1063">IBeam</span><span class="sxs-lookup"><span data-stu-id="59098-1063">IBeam</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E934.png" width="32" height="32" alt="IBeamOutline" /></td>
  <td><span data-ttu-id="59098-1064">E934</span><span class="sxs-lookup"><span data-stu-id="59098-1064">E934</span></span></td>
  <td><span data-ttu-id="59098-1065">IBeamOutline</span><span class="sxs-lookup"><span data-stu-id="59098-1065">IBeamOutline</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E935.png" width="32" height="32" alt="FlickDown" /></td>
  <td><span data-ttu-id="59098-1066">E935</span><span class="sxs-lookup"><span data-stu-id="59098-1066">E935</span></span></td>
  <td><span data-ttu-id="59098-1067">FlickDown</span><span class="sxs-lookup"><span data-stu-id="59098-1067">FlickDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E936.png" width="32" height="32" alt="FlickUp" /></td>
  <td><span data-ttu-id="59098-1068">E936</span><span class="sxs-lookup"><span data-stu-id="59098-1068">E936</span></span></td>
  <td><span data-ttu-id="59098-1069">FlickUp</span><span class="sxs-lookup"><span data-stu-id="59098-1069">FlickUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E937.png" width="32" height="32" alt="FlickLeft" /></td>
  <td><span data-ttu-id="59098-1070">E937</span><span class="sxs-lookup"><span data-stu-id="59098-1070">E937</span></span></td>
  <td><span data-ttu-id="59098-1071">FlickLeft</span><span class="sxs-lookup"><span data-stu-id="59098-1071">FlickLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E938.png" width="32" height="32" alt="FlickRight" /></td>
  <td><span data-ttu-id="59098-1072">E938</span><span class="sxs-lookup"><span data-stu-id="59098-1072">E938</span></span></td>
  <td><span data-ttu-id="59098-1073">FlickRight</span><span class="sxs-lookup"><span data-stu-id="59098-1073">FlickRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E939.png" width="32" height="32" alt="FeedbackApp" /></td>
  <td><span data-ttu-id="59098-1074">E939</span><span class="sxs-lookup"><span data-stu-id="59098-1074">E939</span></span></td>
  <td><span data-ttu-id="59098-1075">FeedbackApp</span><span class="sxs-lookup"><span data-stu-id="59098-1075">FeedbackApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E93C.png" width="32" height="32" alt="MusicAlbum" /></td>
  <td><span data-ttu-id="59098-1076">E93C</span><span class="sxs-lookup"><span data-stu-id="59098-1076">E93C</span></span></td>
  <td><span data-ttu-id="59098-1077">MusicAlbum</span><span class="sxs-lookup"><span data-stu-id="59098-1077">MusicAlbum</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E93E.png" width="32" height="32" alt="Streaming" /></td>
  <td><span data-ttu-id="59098-1078">E93E</span><span class="sxs-lookup"><span data-stu-id="59098-1078">E93E</span></span></td>
  <td><span data-ttu-id="59098-1079">Streaming</span><span class="sxs-lookup"><span data-stu-id="59098-1079">Streaming</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E943.png" width="32" height="32" alt="Code" /></td>
  <td><span data-ttu-id="59098-1080">E943</span><span class="sxs-lookup"><span data-stu-id="59098-1080">E943</span></span></td>
  <td><span data-ttu-id="59098-1081">コード</span><span class="sxs-lookup"><span data-stu-id="59098-1081">Code</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E944.png" width="32" height="32" alt="ReturnToWindow" /></td>
  <td><span data-ttu-id="59098-1082">E944</span><span class="sxs-lookup"><span data-stu-id="59098-1082">E944</span></span></td>
  <td><span data-ttu-id="59098-1083">ReturnToWindow</span><span class="sxs-lookup"><span data-stu-id="59098-1083">ReturnToWindow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E945.png" width="32" height="32" alt="LightningBolt" /></td>
  <td><span data-ttu-id="59098-1084">E945</span><span class="sxs-lookup"><span data-stu-id="59098-1084">E945</span></span></td>
  <td><span data-ttu-id="59098-1085">LightningBolt</span><span class="sxs-lookup"><span data-stu-id="59098-1085">LightningBolt</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E946.png" width="32" height="32" alt="Info" /></td>
  <td><span data-ttu-id="59098-1086">E946</span><span class="sxs-lookup"><span data-stu-id="59098-1086">E946</span></span></td>
  <td><span data-ttu-id="59098-1087">Info</span><span class="sxs-lookup"><span data-stu-id="59098-1087">Info</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E947.png" width="32" height="32" alt="CalculatorMultiply" /></td>
  <td><span data-ttu-id="59098-1088">E947</span><span class="sxs-lookup"><span data-stu-id="59098-1088">E947</span></span></td>
  <td><span data-ttu-id="59098-1089">CalculatorMultiply</span><span class="sxs-lookup"><span data-stu-id="59098-1089">CalculatorMultiply</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E948.png" width="32" height="32" alt="CalculatorAddition" /></td>
  <td><span data-ttu-id="59098-1090">E948</span><span class="sxs-lookup"><span data-stu-id="59098-1090">E948</span></span></td>
  <td><span data-ttu-id="59098-1091">CalculatorAddition</span><span class="sxs-lookup"><span data-stu-id="59098-1091">CalculatorAddition</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E949.png" width="32" height="32" alt="CalculatorSubtract" /></td>
  <td><span data-ttu-id="59098-1092">E949</span><span class="sxs-lookup"><span data-stu-id="59098-1092">E949</span></span></td>
  <td><span data-ttu-id="59098-1093">CalculatorSubtract</span><span class="sxs-lookup"><span data-stu-id="59098-1093">CalculatorSubtract</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94A.png" width="32" height="32" alt="CalculatorDivide" /></td>
  <td><span data-ttu-id="59098-1094">E94A</span><span class="sxs-lookup"><span data-stu-id="59098-1094">E94A</span></span></td>
  <td><span data-ttu-id="59098-1095">CalculatorDivide</span><span class="sxs-lookup"><span data-stu-id="59098-1095">CalculatorDivide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94B.png" width="32" height="32" alt="CalculatorSquareroot" /></td>
  <td><span data-ttu-id="59098-1096">E94B</span><span class="sxs-lookup"><span data-stu-id="59098-1096">E94B</span></span></td>
  <td><span data-ttu-id="59098-1097">CalculatorSquareroot</span><span class="sxs-lookup"><span data-stu-id="59098-1097">CalculatorSquareroot</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94C.png" width="32" height="32" alt="CalculatorPercentage" /></td>
  <td><span data-ttu-id="59098-1098">E94C</span><span class="sxs-lookup"><span data-stu-id="59098-1098">E94C</span></span></td>
  <td><span data-ttu-id="59098-1099">CalculatorPercentage</span><span class="sxs-lookup"><span data-stu-id="59098-1099">CalculatorPercentage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94D.png" width="32" height="32" alt="CalculatorNegate" /></td>
  <td><span data-ttu-id="59098-1100">E94D</span><span class="sxs-lookup"><span data-stu-id="59098-1100">E94D</span></span></td>
  <td><span data-ttu-id="59098-1101">CalculatorNegate</span><span class="sxs-lookup"><span data-stu-id="59098-1101">CalculatorNegate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94E.png" width="32" height="32" alt="CalculatorEqualTo" /></td>
  <td><span data-ttu-id="59098-1102">E94E</span><span class="sxs-lookup"><span data-stu-id="59098-1102">E94E</span></span></td>
  <td><span data-ttu-id="59098-1103">CalculatorEqualTo</span><span class="sxs-lookup"><span data-stu-id="59098-1103">CalculatorEqualTo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E94F.png" width="32" height="32" alt="CalculatorBackspace" /></td>
  <td><span data-ttu-id="59098-1104">E94F</span><span class="sxs-lookup"><span data-stu-id="59098-1104">E94F</span></span></td>
  <td><span data-ttu-id="59098-1105">CalculatorBackspace</span><span class="sxs-lookup"><span data-stu-id="59098-1105">CalculatorBackspace</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E950.png" width="32" height="32" alt="Component" /></td>
  <td><span data-ttu-id="59098-1106">E950</span><span class="sxs-lookup"><span data-stu-id="59098-1106">E950</span></span></td>
  <td><span data-ttu-id="59098-1107">Component</span><span class="sxs-lookup"><span data-stu-id="59098-1107">Component</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E951.png" width="32" height="32" alt="DMC" /></td>
  <td><span data-ttu-id="59098-1108">E951</span><span class="sxs-lookup"><span data-stu-id="59098-1108">E951</span></span></td>
  <td><span data-ttu-id="59098-1109">DMC</span><span class="sxs-lookup"><span data-stu-id="59098-1109">DMC</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E952.png" width="32" height="32" alt="Dock" /></td>
  <td><span data-ttu-id="59098-1110">E952</span><span class="sxs-lookup"><span data-stu-id="59098-1110">E952</span></span></td>
  <td><span data-ttu-id="59098-1111">Dock</span><span class="sxs-lookup"><span data-stu-id="59098-1111">Dock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E953.png" width="32" height="32" alt="MultimediaDMS" /></td>
  <td><span data-ttu-id="59098-1112">E953</span><span class="sxs-lookup"><span data-stu-id="59098-1112">E953</span></span></td>
  <td><span data-ttu-id="59098-1113">MultimediaDMS</span><span class="sxs-lookup"><span data-stu-id="59098-1113">MultimediaDMS</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E954.png" width="32" height="32" alt="MultimediaDVR" /></td>
  <td><span data-ttu-id="59098-1114">E954</span><span class="sxs-lookup"><span data-stu-id="59098-1114">E954</span></span></td>
  <td><span data-ttu-id="59098-1115">MultimediaDVR</span><span class="sxs-lookup"><span data-stu-id="59098-1115">MultimediaDVR</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E955.png" width="32" height="32" alt="MultimediaPMP" /></td>
  <td><span data-ttu-id="59098-1116">E955</span><span class="sxs-lookup"><span data-stu-id="59098-1116">E955</span></span></td>
  <td><span data-ttu-id="59098-1117">MultimediaPMP</span><span class="sxs-lookup"><span data-stu-id="59098-1117">MultimediaPMP</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E956.png" width="32" height="32" alt="PrintfaxPrinterFile" /></td>
  <td><span data-ttu-id="59098-1118">E956</span><span class="sxs-lookup"><span data-stu-id="59098-1118">E956</span></span></td>
  <td><span data-ttu-id="59098-1119">PrintfaxPrinterFile</span><span class="sxs-lookup"><span data-stu-id="59098-1119">PrintfaxPrinterFile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E957.png" width="32" height="32" alt="Sensor" /></td>
  <td><span data-ttu-id="59098-1120">E957</span><span class="sxs-lookup"><span data-stu-id="59098-1120">E957</span></span></td>
  <td><span data-ttu-id="59098-1121">センサー</span><span class="sxs-lookup"><span data-stu-id="59098-1121">Sensor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E958.png" width="32" height="32" alt="StorageOptical" /></td>
  <td><span data-ttu-id="59098-1122">E958</span><span class="sxs-lookup"><span data-stu-id="59098-1122">E958</span></span></td>
  <td><span data-ttu-id="59098-1123">StorageOptical</span><span class="sxs-lookup"><span data-stu-id="59098-1123">StorageOptical</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E95A.png" width="32" height="32" alt="Communications" /></td>
  <td><span data-ttu-id="59098-1124">E95A</span><span class="sxs-lookup"><span data-stu-id="59098-1124">E95A</span></span></td>
  <td><span data-ttu-id="59098-1125">Communications</span><span class="sxs-lookup"><span data-stu-id="59098-1125">Communications</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E95B.png" width="32" height="32" alt="Headset" /></td>
  <td><span data-ttu-id="59098-1126">E95B</span><span class="sxs-lookup"><span data-stu-id="59098-1126">E95B</span></span></td>
  <td><span data-ttu-id="59098-1127">ヘッドセット</span><span class="sxs-lookup"><span data-stu-id="59098-1127">Headset</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E95D.png" width="32" height="32" alt="Projector" /></td>
  <td><span data-ttu-id="59098-1128">E95D</span><span class="sxs-lookup"><span data-stu-id="59098-1128">E95D</span></span></td>
  <td><span data-ttu-id="59098-1129">Projector</span><span class="sxs-lookup"><span data-stu-id="59098-1129">Projector</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E95E.png" width="32" height="32" alt="Health" /></td>
  <td><span data-ttu-id="59098-1130">E95E</span><span class="sxs-lookup"><span data-stu-id="59098-1130">E95E</span></span></td>
  <td><span data-ttu-id="59098-1131">Health</span><span class="sxs-lookup"><span data-stu-id="59098-1131">Health</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E960.png" width="32" height="32" alt="Webcam2" /></td>
  <td><span data-ttu-id="59098-1132">E960</span><span class="sxs-lookup"><span data-stu-id="59098-1132">E960</span></span></td>
  <td><span data-ttu-id="59098-1133">Webcam2</span><span class="sxs-lookup"><span data-stu-id="59098-1133">Webcam2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E961.png" width="32" height="32" alt="Input" /></td>
  <td><span data-ttu-id="59098-1134">E961</span><span class="sxs-lookup"><span data-stu-id="59098-1134">E961</span></span></td>
  <td><span data-ttu-id="59098-1135">入力</span><span class="sxs-lookup"><span data-stu-id="59098-1135">Input</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E962.png" width="32" height="32" alt="Mouse" /></td>
  <td><span data-ttu-id="59098-1136">E962</span><span class="sxs-lookup"><span data-stu-id="59098-1136">E962</span></span></td>
  <td><span data-ttu-id="59098-1137">マウス</span><span class="sxs-lookup"><span data-stu-id="59098-1137">Mouse</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E963.png" width="32" height="32" alt="Smartcard" /></td>
  <td><span data-ttu-id="59098-1138">E963</span><span class="sxs-lookup"><span data-stu-id="59098-1138">E963</span></span></td>
  <td><span data-ttu-id="59098-1139">Smartcard</span><span class="sxs-lookup"><span data-stu-id="59098-1139">Smartcard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E964.png" width="32" height="32" alt="SmartcardVirtual" /></td>
  <td><span data-ttu-id="59098-1140">E964</span><span class="sxs-lookup"><span data-stu-id="59098-1140">E964</span></span></td>
  <td><span data-ttu-id="59098-1141">SmartcardVirtual</span><span class="sxs-lookup"><span data-stu-id="59098-1141">SmartcardVirtual</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E965.png" width="32" height="32" alt="MediaStorageTower" /></td>
  <td><span data-ttu-id="59098-1142">E965</span><span class="sxs-lookup"><span data-stu-id="59098-1142">E965</span></span></td>
  <td><span data-ttu-id="59098-1143">MediaStorageTower</span><span class="sxs-lookup"><span data-stu-id="59098-1143">MediaStorageTower</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E966.png" width="32" height="32" alt="ReturnKeySm" /></td>
  <td><span data-ttu-id="59098-1144">E966</span><span class="sxs-lookup"><span data-stu-id="59098-1144">E966</span></span></td>
  <td><span data-ttu-id="59098-1145">ReturnKeySm</span><span class="sxs-lookup"><span data-stu-id="59098-1145">ReturnKeySm</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E967.png" width="32" height="32" alt="GameConsole" /></td>
  <td><span data-ttu-id="59098-1146">E967</span><span class="sxs-lookup"><span data-stu-id="59098-1146">E967</span></span></td>
  <td><span data-ttu-id="59098-1147">GameConsole</span><span class="sxs-lookup"><span data-stu-id="59098-1147">GameConsole</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E968.png" width="32" height="32" alt="Network" /></td>
  <td><span data-ttu-id="59098-1148">E968</span><span class="sxs-lookup"><span data-stu-id="59098-1148">E968</span></span></td>
  <td><span data-ttu-id="59098-1149">ネットワーク</span><span class="sxs-lookup"><span data-stu-id="59098-1149">Network</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E969.png" width="32" height="32" alt="StorageNetworkWireless" /></td>
  <td><span data-ttu-id="59098-1150">E969</span><span class="sxs-lookup"><span data-stu-id="59098-1150">E969</span></span></td>
  <td><span data-ttu-id="59098-1151">StorageNetworkWireless</span><span class="sxs-lookup"><span data-stu-id="59098-1151">StorageNetworkWireless</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E96A.png" width="32" height="32" alt="StorageTape" /></td>
  <td><span data-ttu-id="59098-1152">E96A</span><span class="sxs-lookup"><span data-stu-id="59098-1152">E96A</span></span></td>
  <td><span data-ttu-id="59098-1153">StorageTape</span><span class="sxs-lookup"><span data-stu-id="59098-1153">StorageTape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E96D.png" width="32" height="32" alt="ChevronUpSmall" /></td>
  <td><span data-ttu-id="59098-1154">E96D</span><span class="sxs-lookup"><span data-stu-id="59098-1154">E96D</span></span></td>
  <td><span data-ttu-id="59098-1155">ChevronUpSmall</span><span class="sxs-lookup"><span data-stu-id="59098-1155">ChevronUpSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E96E.png" width="32" height="32" alt="ChevronDownSmall" /></td>
  <td><span data-ttu-id="59098-1156">E96E</span><span class="sxs-lookup"><span data-stu-id="59098-1156">E96E</span></span></td>
  <td><span data-ttu-id="59098-1157">ChevronDownSmall</span><span class="sxs-lookup"><span data-stu-id="59098-1157">ChevronDownSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E96F.png" width="32" height="32" alt="ChevronLeftSmall" /></td>
  <td><span data-ttu-id="59098-1158">E96F</span><span class="sxs-lookup"><span data-stu-id="59098-1158">E96F</span></span></td>
  <td><span data-ttu-id="59098-1159">ChevronLeftSmall</span><span class="sxs-lookup"><span data-stu-id="59098-1159">ChevronLeftSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E970.png" width="32" height="32" alt="ChevronRightSmall" /></td>
  <td><span data-ttu-id="59098-1160">E970</span><span class="sxs-lookup"><span data-stu-id="59098-1160">E970</span></span></td>
  <td><span data-ttu-id="59098-1161">ChevronRightSmall</span><span class="sxs-lookup"><span data-stu-id="59098-1161">ChevronRightSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E971.png" width="32" height="32" alt="ChevronUpMed" /></td>
  <td><span data-ttu-id="59098-1162">E971</span><span class="sxs-lookup"><span data-stu-id="59098-1162">E971</span></span></td>
  <td><span data-ttu-id="59098-1163">ChevronUpMed</span><span class="sxs-lookup"><span data-stu-id="59098-1163">ChevronUpMed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E972.png" width="32" height="32" alt="ChevronDownMed" /></td>
  <td><span data-ttu-id="59098-1164">E972</span><span class="sxs-lookup"><span data-stu-id="59098-1164">E972</span></span></td>
  <td><span data-ttu-id="59098-1165">ChevronDownMed</span><span class="sxs-lookup"><span data-stu-id="59098-1165">ChevronDownMed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E973.png" width="32" height="32" alt="ChevronLeftMed" /></td>
  <td><span data-ttu-id="59098-1166">E973</span><span class="sxs-lookup"><span data-stu-id="59098-1166">E973</span></span></td>
  <td><span data-ttu-id="59098-1167">ChevronLeftMed</span><span class="sxs-lookup"><span data-stu-id="59098-1167">ChevronLeftMed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E974.png" width="32" height="32" alt="ChevronRightMed" /></td>
  <td><span data-ttu-id="59098-1168">E974</span><span class="sxs-lookup"><span data-stu-id="59098-1168">E974</span></span></td>
  <td><span data-ttu-id="59098-1169">ChevronRightMed</span><span class="sxs-lookup"><span data-stu-id="59098-1169">ChevronRightMed</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E975.png" width="32" height="32" alt="Devices2" /></td>
  <td><span data-ttu-id="59098-1170">E975</span><span class="sxs-lookup"><span data-stu-id="59098-1170">E975</span></span></td>
  <td><span data-ttu-id="59098-1171">Devices2</span><span class="sxs-lookup"><span data-stu-id="59098-1171">Devices2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E976.png" width="32" height="32" alt="ExpandTile" /></td>
  <td><span data-ttu-id="59098-1172">E976</span><span class="sxs-lookup"><span data-stu-id="59098-1172">E976</span></span></td>
  <td><span data-ttu-id="59098-1173">ExpandTile</span><span class="sxs-lookup"><span data-stu-id="59098-1173">ExpandTile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E977.png" width="32" height="32" alt="PC1" /></td>
  <td><span data-ttu-id="59098-1174">E977</span><span class="sxs-lookup"><span data-stu-id="59098-1174">E977</span></span></td>
  <td><span data-ttu-id="59098-1175">PC1</span><span class="sxs-lookup"><span data-stu-id="59098-1175">PC1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E978.png" width="32" height="32" alt="PresenceChicklet" /></td>
  <td><span data-ttu-id="59098-1176">E978</span><span class="sxs-lookup"><span data-stu-id="59098-1176">E978</span></span></td>
  <td><span data-ttu-id="59098-1177">PresenceChicklet</span><span class="sxs-lookup"><span data-stu-id="59098-1177">PresenceChicklet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E979.png" width="32" height="32" alt="PresenceChickletVideo" /></td>
  <td><span data-ttu-id="59098-1178">E979</span><span class="sxs-lookup"><span data-stu-id="59098-1178">E979</span></span></td>
  <td><span data-ttu-id="59098-1179">PresenceChickletVideo</span><span class="sxs-lookup"><span data-stu-id="59098-1179">PresenceChickletVideo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97A.png" width="32" height="32" alt="Reply" /></td>
  <td><span data-ttu-id="59098-1180">E97A</span><span class="sxs-lookup"><span data-stu-id="59098-1180">E97A</span></span></td>
  <td><span data-ttu-id="59098-1181">Reply</span><span class="sxs-lookup"><span data-stu-id="59098-1181">Reply</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97B.png" width="32" height="32" alt="SetTile" /></td>
  <td><span data-ttu-id="59098-1182">E97B</span><span class="sxs-lookup"><span data-stu-id="59098-1182">E97B</span></span></td>
  <td><span data-ttu-id="59098-1183">SetTile</span><span class="sxs-lookup"><span data-stu-id="59098-1183">SetTile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97C.png" width="32" height="32" alt="Type" /></td>
  <td><span data-ttu-id="59098-1184">E97C</span><span class="sxs-lookup"><span data-stu-id="59098-1184">E97C</span></span></td>
  <td><span data-ttu-id="59098-1185">種類</span><span class="sxs-lookup"><span data-stu-id="59098-1185">Type</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97D.png" width="32" height="32" alt="Korean" /></td>
  <td><span data-ttu-id="59098-1186">E97D</span><span class="sxs-lookup"><span data-stu-id="59098-1186">E97D</span></span></td>
  <td><span data-ttu-id="59098-1187">韓国語</span><span class="sxs-lookup"><span data-stu-id="59098-1187">Korean</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97E.png" width="32" height="32" alt="HalfAlpha" /></td>
  <td><span data-ttu-id="59098-1188">E97E</span><span class="sxs-lookup"><span data-stu-id="59098-1188">E97E</span></span></td>
  <td><span data-ttu-id="59098-1189">HalfAlpha</span><span class="sxs-lookup"><span data-stu-id="59098-1189">HalfAlpha</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E97F.png" width="32" height="32" alt="FullAlpha" /></td>
  <td><span data-ttu-id="59098-1190">E97F</span><span class="sxs-lookup"><span data-stu-id="59098-1190">E97F</span></span></td>
  <td><span data-ttu-id="59098-1191">FullAlpha</span><span class="sxs-lookup"><span data-stu-id="59098-1191">FullAlpha</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E980.png" width="32" height="32" alt="Key12On" /></td>
  <td><span data-ttu-id="59098-1192">E980</span><span class="sxs-lookup"><span data-stu-id="59098-1192">E980</span></span></td>
  <td><span data-ttu-id="59098-1193">Key12On</span><span class="sxs-lookup"><span data-stu-id="59098-1193">Key12On</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E981.png" width="32" height="32" alt="ChineseChangjie" /></td>
  <td><span data-ttu-id="59098-1194">E981</span><span class="sxs-lookup"><span data-stu-id="59098-1194">E981</span></span></td>
  <td><span data-ttu-id="59098-1195">ChineseChangjie</span><span class="sxs-lookup"><span data-stu-id="59098-1195">ChineseChangjie</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E982.png" width="32" height="32" alt="QWERTYOn" /></td>
  <td><span data-ttu-id="59098-1196">E982</span><span class="sxs-lookup"><span data-stu-id="59098-1196">E982</span></span></td>
  <td><span data-ttu-id="59098-1197">QWERTYOn</span><span class="sxs-lookup"><span data-stu-id="59098-1197">QWERTYOn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E983.png" width="32" height="32" alt="QWERTYOff" /></td>
  <td><span data-ttu-id="59098-1198">E983</span><span class="sxs-lookup"><span data-stu-id="59098-1198">E983</span></span></td>
  <td><span data-ttu-id="59098-1199">QWERTYOff</span><span class="sxs-lookup"><span data-stu-id="59098-1199">QWERTYOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E984.png" width="32" height="32" alt="ChineseQuick" /></td>
  <td><span data-ttu-id="59098-1200">E984</span><span class="sxs-lookup"><span data-stu-id="59098-1200">E984</span></span></td>
  <td><span data-ttu-id="59098-1201">ChineseQuick</span><span class="sxs-lookup"><span data-stu-id="59098-1201">ChineseQuick</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E985.png" width="32" height="32" alt="Japanese" /></td>
  <td><span data-ttu-id="59098-1202">E985</span><span class="sxs-lookup"><span data-stu-id="59098-1202">E985</span></span></td>
  <td><span data-ttu-id="59098-1203">Japanese</span><span class="sxs-lookup"><span data-stu-id="59098-1203">Japanese</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E986.png" width="32" height="32" alt="FullHiragana" /></td>
  <td><span data-ttu-id="59098-1204">E986</span><span class="sxs-lookup"><span data-stu-id="59098-1204">E986</span></span></td>
  <td><span data-ttu-id="59098-1205">FullHiragana</span><span class="sxs-lookup"><span data-stu-id="59098-1205">FullHiragana</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E987.png" width="32" height="32" alt="FullKatakana" /></td>
  <td><span data-ttu-id="59098-1206">E987</span><span class="sxs-lookup"><span data-stu-id="59098-1206">E987</span></span></td>
  <td><span data-ttu-id="59098-1207">FullKatakana</span><span class="sxs-lookup"><span data-stu-id="59098-1207">FullKatakana</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E988.png" width="32" height="32" alt="HalfKatakana" /></td>
  <td><span data-ttu-id="59098-1208">E988</span><span class="sxs-lookup"><span data-stu-id="59098-1208">E988</span></span></td>
  <td><span data-ttu-id="59098-1209">HalfKatakana</span><span class="sxs-lookup"><span data-stu-id="59098-1209">HalfKatakana</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E989.png" width="32" height="32" alt="ChineseBoPoMoFo" /></td>
  <td><span data-ttu-id="59098-1210">E989</span><span class="sxs-lookup"><span data-stu-id="59098-1210">E989</span></span></td>
  <td><span data-ttu-id="59098-1211">ChineseBoPoMoFo</span><span class="sxs-lookup"><span data-stu-id="59098-1211">ChineseBoPoMoFo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E98A.png" width="32" height="32" alt="ChinesePinyin" /></td>
  <td><span data-ttu-id="59098-1212">E98A</span><span class="sxs-lookup"><span data-stu-id="59098-1212">E98A</span></span></td>
  <td><span data-ttu-id="59098-1213">ChinesePinyin</span><span class="sxs-lookup"><span data-stu-id="59098-1213">ChinesePinyin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E98F.png" width="32" height="32" alt="ConstructionCone" /></td>
  <td><span data-ttu-id="59098-1214">E98F</span><span class="sxs-lookup"><span data-stu-id="59098-1214">E98F</span></span></td>
  <td><span data-ttu-id="59098-1215">ConstructionCone</span><span class="sxs-lookup"><span data-stu-id="59098-1215">ConstructionCone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E990.png" width="32" height="32" alt="XboxOneConsole" /></td>
  <td><span data-ttu-id="59098-1216">E990</span><span class="sxs-lookup"><span data-stu-id="59098-1216">E990</span></span></td>
  <td><span data-ttu-id="59098-1217">XboxOneConsole</span><span class="sxs-lookup"><span data-stu-id="59098-1217">XboxOneConsole</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E992.png" width="32" height="32" alt="Volume0" /></td>
  <td><span data-ttu-id="59098-1218">E992</span><span class="sxs-lookup"><span data-stu-id="59098-1218">E992</span></span></td>
  <td><span data-ttu-id="59098-1219">Volume0</span><span class="sxs-lookup"><span data-stu-id="59098-1219">Volume0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E993.png" width="32" height="32" alt="Volume1" /></td>
  <td><span data-ttu-id="59098-1220">E993</span><span class="sxs-lookup"><span data-stu-id="59098-1220">E993</span></span></td>
  <td><span data-ttu-id="59098-1221">Volume1</span><span class="sxs-lookup"><span data-stu-id="59098-1221">Volume1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E994.png" width="32" height="32" alt="Volume2" /></td>
  <td><span data-ttu-id="59098-1222">E994</span><span class="sxs-lookup"><span data-stu-id="59098-1222">E994</span></span></td>
  <td><span data-ttu-id="59098-1223">Volume2</span><span class="sxs-lookup"><span data-stu-id="59098-1223">Volume2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E995.png" width="32" height="32" alt="Volume3" /></td>
  <td><span data-ttu-id="59098-1224">E995</span><span class="sxs-lookup"><span data-stu-id="59098-1224">E995</span></span></td>
  <td><span data-ttu-id="59098-1225">Volume3</span><span class="sxs-lookup"><span data-stu-id="59098-1225">Volume3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E996.png" width="32" height="32" alt="BatteryUnknown" /></td>
  <td><span data-ttu-id="59098-1226">E996</span><span class="sxs-lookup"><span data-stu-id="59098-1226">E996</span></span></td>
  <td><span data-ttu-id="59098-1227">BatteryUnknown</span><span class="sxs-lookup"><span data-stu-id="59098-1227">BatteryUnknown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E998.png" width="32" height="32" alt="WifiAttentionOverlay" /></td>
  <td><span data-ttu-id="59098-1228">E998</span><span class="sxs-lookup"><span data-stu-id="59098-1228">E998</span></span></td>
  <td><span data-ttu-id="59098-1229">WifiAttentionOverlay</span><span class="sxs-lookup"><span data-stu-id="59098-1229">WifiAttentionOverlay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E99A.png" width="32" height="32" alt="Robot" /></td>
  <td><span data-ttu-id="59098-1230">E99A</span><span class="sxs-lookup"><span data-stu-id="59098-1230">E99A</span></span></td>
  <td><span data-ttu-id="59098-1231">Robot</span><span class="sxs-lookup"><span data-stu-id="59098-1231">Robot</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9A1.png" width="32" height="32" alt="TapAndSend" /></td>
  <td><span data-ttu-id="59098-1232">E9A1</span><span class="sxs-lookup"><span data-stu-id="59098-1232">E9A1</span></span></td>
  <td><span data-ttu-id="59098-1233">TapAndSend</span><span class="sxs-lookup"><span data-stu-id="59098-1233">TapAndSend</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9A6.png" width="32" height="32" alt="FitPage" /></td>
  <td><span data-ttu-id="59098-1234">E9A6</span><span class="sxs-lookup"><span data-stu-id="59098-1234">E9A6</span></span></td>
  <td><span data-ttu-id="59098-1235">FitPage</span><span class="sxs-lookup"><span data-stu-id="59098-1235">FitPage</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9A8.png" width="32" height="32" alt="PasswordKeyShow" /></td>
  <td><span data-ttu-id="59098-1236">E9A8</span><span class="sxs-lookup"><span data-stu-id="59098-1236">E9A8</span></span></td>
  <td><span data-ttu-id="59098-1237">PasswordKeyShow</span><span class="sxs-lookup"><span data-stu-id="59098-1237">PasswordKeyShow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9A9.png" width="32" height="32" alt="PasswordKeyHide" /></td>
  <td><span data-ttu-id="59098-1238">E9A9</span><span class="sxs-lookup"><span data-stu-id="59098-1238">E9A9</span></span></td>
  <td><span data-ttu-id="59098-1239">PasswordKeyHide</span><span class="sxs-lookup"><span data-stu-id="59098-1239">PasswordKeyHide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AA.png" width="32" height="32" alt="BidiLtr" /></td>
  <td><span data-ttu-id="59098-1240">E9AA</span><span class="sxs-lookup"><span data-stu-id="59098-1240">E9AA</span></span></td>
  <td><span data-ttu-id="59098-1241">BidiLtr</span><span class="sxs-lookup"><span data-stu-id="59098-1241">BidiLtr</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AB.png" width="32" height="32" alt="BidiRtl" /></td>
  <td><span data-ttu-id="59098-1242">E9AB</span><span class="sxs-lookup"><span data-stu-id="59098-1242">E9AB</span></span></td>
  <td><span data-ttu-id="59098-1243">BidiRtl</span><span class="sxs-lookup"><span data-stu-id="59098-1243">BidiRtl</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AC.png" width="32" height="32" alt="ForwardSm" /></td>
  <td><span data-ttu-id="59098-1244">E9AC</span><span class="sxs-lookup"><span data-stu-id="59098-1244">E9AC</span></span></td>
  <td><span data-ttu-id="59098-1245">ForwardSm</span><span class="sxs-lookup"><span data-stu-id="59098-1245">ForwardSm</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AD.png" width="32" height="32" alt="CommaKey" /></td>
  <td><span data-ttu-id="59098-1246">E9AD</span><span class="sxs-lookup"><span data-stu-id="59098-1246">E9AD</span></span></td>
  <td><span data-ttu-id="59098-1247">CommaKey</span><span class="sxs-lookup"><span data-stu-id="59098-1247">CommaKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AE.png" width="32" height="32" alt="DashKey" /></td>
  <td><span data-ttu-id="59098-1248">E9AE</span><span class="sxs-lookup"><span data-stu-id="59098-1248">E9AE</span></span></td>
  <td><span data-ttu-id="59098-1249">DashKey</span><span class="sxs-lookup"><span data-stu-id="59098-1249">DashKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9AF.png" width="32" height="32" alt="DullSoundKey" /></td>
  <td><span data-ttu-id="59098-1250">E9AF</span><span class="sxs-lookup"><span data-stu-id="59098-1250">E9AF</span></span></td>
  <td><span data-ttu-id="59098-1251">DullSoundKey</span><span class="sxs-lookup"><span data-stu-id="59098-1251">DullSoundKey</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B0.png" width="32" height="32" alt="HalfDullSound" /></td>
  <td><span data-ttu-id="59098-1252">E9B0</span><span class="sxs-lookup"><span data-stu-id="59098-1252">E9B0</span></span></td>
  <td><span data-ttu-id="59098-1253">HalfDullSound</span><span class="sxs-lookup"><span data-stu-id="59098-1253">HalfDullSound</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B1.png" width="32" height="32" alt="RightDoubleQuote" /></td>
  <td><span data-ttu-id="59098-1254">E9B1</span><span class="sxs-lookup"><span data-stu-id="59098-1254">E9B1</span></span></td>
  <td><span data-ttu-id="59098-1255">RightDoubleQuote</span><span class="sxs-lookup"><span data-stu-id="59098-1255">RightDoubleQuote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B2.png" width="32" height="32" alt="LeftDoubleQuote" /></td>
  <td><span data-ttu-id="59098-1256">E9B2</span><span class="sxs-lookup"><span data-stu-id="59098-1256">E9B2</span></span></td>
  <td><span data-ttu-id="59098-1257">LeftDoubleQuote</span><span class="sxs-lookup"><span data-stu-id="59098-1257">LeftDoubleQuote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B3.png" width="32" height="32" alt="PuncKeyRightBottom" /></td>
  <td><span data-ttu-id="59098-1258">E9B3</span><span class="sxs-lookup"><span data-stu-id="59098-1258">E9B3</span></span></td>
  <td><span data-ttu-id="59098-1259">PuncKeyRightBottom</span><span class="sxs-lookup"><span data-stu-id="59098-1259">PuncKeyRightBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B4.png" width="32" height="32" alt="PuncKey1" /></td>
  <td><span data-ttu-id="59098-1260">E9B4</span><span class="sxs-lookup"><span data-stu-id="59098-1260">E9B4</span></span></td>
  <td><span data-ttu-id="59098-1261">PuncKey1</span><span class="sxs-lookup"><span data-stu-id="59098-1261">PuncKey1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B5.png" width="32" height="32" alt="PuncKey2" /></td>
  <td><span data-ttu-id="59098-1262">E9B5</span><span class="sxs-lookup"><span data-stu-id="59098-1262">E9B5</span></span></td>
  <td><span data-ttu-id="59098-1263">PuncKey2</span><span class="sxs-lookup"><span data-stu-id="59098-1263">PuncKey2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B6.png" width="32" height="32" alt="PuncKey3" /></td>
  <td><span data-ttu-id="59098-1264">E9B6</span><span class="sxs-lookup"><span data-stu-id="59098-1264">E9B6</span></span></td>
  <td><span data-ttu-id="59098-1265">PuncKey3</span><span class="sxs-lookup"><span data-stu-id="59098-1265">PuncKey3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B7.png" width="32" height="32" alt="PuncKey4" /></td>
  <td><span data-ttu-id="59098-1266">E9B7</span><span class="sxs-lookup"><span data-stu-id="59098-1266">E9B7</span></span></td>
  <td><span data-ttu-id="59098-1267">PuncKey4</span><span class="sxs-lookup"><span data-stu-id="59098-1267">PuncKey4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B8.png" width="32" height="32" alt="PuncKey5" /></td>
  <td><span data-ttu-id="59098-1268">E9B8</span><span class="sxs-lookup"><span data-stu-id="59098-1268">E9B8</span></span></td>
  <td><span data-ttu-id="59098-1269">PuncKey5</span><span class="sxs-lookup"><span data-stu-id="59098-1269">PuncKey5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9B9.png" width="32" height="32" alt="PuncKey6" /></td>
  <td><span data-ttu-id="59098-1270">E9B9</span><span class="sxs-lookup"><span data-stu-id="59098-1270">E9B9</span></span></td>
  <td><span data-ttu-id="59098-1271">PuncKey6</span><span class="sxs-lookup"><span data-stu-id="59098-1271">PuncKey6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9BA.png" width="32" height="32" alt="PuncKey9" /></td>
  <td><span data-ttu-id="59098-1272">E9BA</span><span class="sxs-lookup"><span data-stu-id="59098-1272">E9BA</span></span></td>
  <td><span data-ttu-id="59098-1273">PuncKey9</span><span class="sxs-lookup"><span data-stu-id="59098-1273">PuncKey9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9BB.png" width="32" height="32" alt="PuncKey7" /></td>
  <td><span data-ttu-id="59098-1274">E9BB</span><span class="sxs-lookup"><span data-stu-id="59098-1274">E9BB</span></span></td>
  <td><span data-ttu-id="59098-1275">PuncKey7</span><span class="sxs-lookup"><span data-stu-id="59098-1275">PuncKey7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9BC.png" width="32" height="32" alt="PuncKey8" /></td>
  <td><span data-ttu-id="59098-1276">E9BC</span><span class="sxs-lookup"><span data-stu-id="59098-1276">E9BC</span></span></td>
  <td><span data-ttu-id="59098-1277">PuncKey8</span><span class="sxs-lookup"><span data-stu-id="59098-1277">PuncKey8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9CA.png" width="32" height="32" alt="Frigid" /></td>
  <td><span data-ttu-id="59098-1278">E9CA</span><span class="sxs-lookup"><span data-stu-id="59098-1278">E9CA</span></span></td>
  <td><span data-ttu-id="59098-1279">Frigid</span><span class="sxs-lookup"><span data-stu-id="59098-1279">Frigid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9CE.png" width="32" height="32" alt="Unknown" /></td>
  <td><span data-ttu-id="59098-1280">E9CE</span><span class="sxs-lookup"><span data-stu-id="59098-1280">E9CE</span></span></td>
  <td><span data-ttu-id="59098-1281">Unknown</span><span class="sxs-lookup"><span data-stu-id="59098-1281">Unknown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9D2.png" width="32" height="32" alt="AreaChart" /></td>
  <td><span data-ttu-id="59098-1282">E9D2</span><span class="sxs-lookup"><span data-stu-id="59098-1282">E9D2</span></span></td>
  <td><span data-ttu-id="59098-1283">AreaChart</span><span class="sxs-lookup"><span data-stu-id="59098-1283">AreaChart</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9D5.png" width="32" height="32" alt="CheckList" /></td>
  <td><span data-ttu-id="59098-1284">E9D5</span><span class="sxs-lookup"><span data-stu-id="59098-1284">E9D5</span></span></td>
  <td><span data-ttu-id="59098-1285">チェックリスト</span><span class="sxs-lookup"><span data-stu-id="59098-1285">CheckList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9D9.png" width="32" height="32" alt="Diagnostic" /></td>
  <td><span data-ttu-id="59098-1286">E9D9</span><span class="sxs-lookup"><span data-stu-id="59098-1286">E9D9</span></span></td>
  <td><span data-ttu-id="59098-1287">Diagnostic</span><span class="sxs-lookup"><span data-stu-id="59098-1287">Diagnostic</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9E9.png" width="32" height="32" alt="Equalizer" /></td>
  <td><span data-ttu-id="59098-1288">E9E9</span><span class="sxs-lookup"><span data-stu-id="59098-1288">E9E9</span></span></td>
  <td><span data-ttu-id="59098-1289">イコライザー</span><span class="sxs-lookup"><span data-stu-id="59098-1289">Equalizer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9F3.png" width="32" height="32" alt="Process" /></td>
  <td><span data-ttu-id="59098-1290">E9F3</span><span class="sxs-lookup"><span data-stu-id="59098-1290">E9F3</span></span></td>
  <td><span data-ttu-id="59098-1291">Process</span><span class="sxs-lookup"><span data-stu-id="59098-1291">Process</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9F5.png" width="32" height="32" alt="Processing" /></td>
  <td><span data-ttu-id="59098-1292">E9F5</span><span class="sxs-lookup"><span data-stu-id="59098-1292">E9F5</span></span></td>
  <td><span data-ttu-id="59098-1293">Processing</span><span class="sxs-lookup"><span data-stu-id="59098-1293">Processing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/E9F9.png" width="32" height="32" alt="ReportDocument" /></td>
  <td><span data-ttu-id="59098-1294">E9F9</span><span class="sxs-lookup"><span data-stu-id="59098-1294">E9F9</span></span></td>
  <td><span data-ttu-id="59098-1295">ReportDocument</span><span class="sxs-lookup"><span data-stu-id="59098-1295">ReportDocument</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA0C.png" width="32" height="32" alt="VideoSolid" /></td>
  <td><span data-ttu-id="59098-1296">EA0C</span><span class="sxs-lookup"><span data-stu-id="59098-1296">EA0C</span></span></td>
  <td><span data-ttu-id="59098-1297">VideoSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1297">VideoSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA14.png" width="32" height="32" alt="DisconnectDisplay" /></td>
  <td><span data-ttu-id="59098-1298">EA14</span><span class="sxs-lookup"><span data-stu-id="59098-1298">EA14</span></span></td>
  <td><span data-ttu-id="59098-1299">DisconnectDisplay</span><span class="sxs-lookup"><span data-stu-id="59098-1299">DisconnectDisplay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA18.png" width="32" height="32" alt="Shield" /></td>
  <td><span data-ttu-id="59098-1300">EA18</span><span class="sxs-lookup"><span data-stu-id="59098-1300">EA18</span></span></td>
  <td><span data-ttu-id="59098-1301">シールド</span><span class="sxs-lookup"><span data-stu-id="59098-1301">Shield</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA1F.png" width="32" height="32" alt="Info2" /></td>
  <td><span data-ttu-id="59098-1302">EA1F</span><span class="sxs-lookup"><span data-stu-id="59098-1302">EA1F</span></span></td>
  <td><span data-ttu-id="59098-1303">Info2</span><span class="sxs-lookup"><span data-stu-id="59098-1303">Info2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA21.png" width="32" height="32" alt="ActionCenterAsterisk" /></td>
  <td><span data-ttu-id="59098-1304">EA21</span><span class="sxs-lookup"><span data-stu-id="59098-1304">EA21</span></span></td>
  <td><span data-ttu-id="59098-1305">ActionCenterAsterisk</span><span class="sxs-lookup"><span data-stu-id="59098-1305">ActionCenterAsterisk</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA24.png" width="32" height="32" alt="Beta" /></td>
  <td><span data-ttu-id="59098-1306">EA24</span><span class="sxs-lookup"><span data-stu-id="59098-1306">EA24</span></span></td>
  <td><span data-ttu-id="59098-1307">Beta</span><span class="sxs-lookup"><span data-stu-id="59098-1307">Beta</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA35.png" width="32" height="32" alt="SaveCopy" /></td>
  <td><span data-ttu-id="59098-1308">EA35</span><span class="sxs-lookup"><span data-stu-id="59098-1308">EA35</span></span></td>
  <td><span data-ttu-id="59098-1309">SaveCopy</span><span class="sxs-lookup"><span data-stu-id="59098-1309">SaveCopy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA37.png" width="32" height="32" alt="List" /></td>
  <td><span data-ttu-id="59098-1310">EA37</span><span class="sxs-lookup"><span data-stu-id="59098-1310">EA37</span></span></td>
  <td><span data-ttu-id="59098-1311">一覧</span><span class="sxs-lookup"><span data-stu-id="59098-1311">List</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA38.png" width="32" height="32" alt="Asterisk" /></td>
  <td><span data-ttu-id="59098-1312">EA38</span><span class="sxs-lookup"><span data-stu-id="59098-1312">EA38</span></span></td>
  <td><span data-ttu-id="59098-1313">Asterisk</span><span class="sxs-lookup"><span data-stu-id="59098-1313">Asterisk</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA39.png" width="32" height="32" alt="ErrorBadge" /></td>
  <td><span data-ttu-id="59098-1314">EA39</span><span class="sxs-lookup"><span data-stu-id="59098-1314">EA39</span></span></td>
  <td><span data-ttu-id="59098-1315">ErrorBadge</span><span class="sxs-lookup"><span data-stu-id="59098-1315">ErrorBadge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA3A.png" width="32" height="32" alt="CircleRing" /></td>
  <td><span data-ttu-id="59098-1316">EA3A</span><span class="sxs-lookup"><span data-stu-id="59098-1316">EA3A</span></span></td>
  <td><span data-ttu-id="59098-1317">CircleRing</span><span class="sxs-lookup"><span data-stu-id="59098-1317">CircleRing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA3B.png" width="32" height="32" alt="CircleFill" /></td>
  <td><span data-ttu-id="59098-1318">EA3B</span><span class="sxs-lookup"><span data-stu-id="59098-1318">EA3B</span></span></td>
  <td><span data-ttu-id="59098-1319">CircleFill</span><span class="sxs-lookup"><span data-stu-id="59098-1319">CircleFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA40.png" width="32" height="32" alt="AllAppsMirrored" /></td>
  <td><span data-ttu-id="59098-1320">EA40</span><span class="sxs-lookup"><span data-stu-id="59098-1320">EA40</span></span></td>
  <td><span data-ttu-id="59098-1321">AllAppsMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1321">AllAppsMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA41.png" width="32" height="32" alt="BookmarksMirrored" /></td>
  <td><span data-ttu-id="59098-1322">EA41</span><span class="sxs-lookup"><span data-stu-id="59098-1322">EA41</span></span></td>
  <td><span data-ttu-id="59098-1323">BookmarksMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1323">BookmarksMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA42.png" width="32" height="32" alt="BulletedListMirrored" /></td>
  <td><span data-ttu-id="59098-1324">EA42</span><span class="sxs-lookup"><span data-stu-id="59098-1324">EA42</span></span></td>
  <td><span data-ttu-id="59098-1325">BulletedListMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1325">BulletedListMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA43.png" width="32" height="32" alt="CallForwardInternationalMirrored" /></td>
  <td><span data-ttu-id="59098-1326">EA43</span><span class="sxs-lookup"><span data-stu-id="59098-1326">EA43</span></span></td>
  <td><span data-ttu-id="59098-1327">CallForwardInternationalMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1327">CallForwardInternationalMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA44.png" width="32" height="32" alt="CallForwardRoamingMirrored" /></td>
  <td><span data-ttu-id="59098-1328">EA44</span><span class="sxs-lookup"><span data-stu-id="59098-1328">EA44</span></span></td>
  <td><span data-ttu-id="59098-1329">CallForwardRoamingMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1329">CallForwardRoamingMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA47.png" width="32" height="32" alt="ChromeBackMirrored" /></td>
  <td><span data-ttu-id="59098-1330">EA47</span><span class="sxs-lookup"><span data-stu-id="59098-1330">EA47</span></span></td>
  <td><span data-ttu-id="59098-1331">ChromeBackMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1331">ChromeBackMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA48.png" width="32" height="32" alt="ClearSelectionMirrored" /></td>
  <td><span data-ttu-id="59098-1332">EA48</span><span class="sxs-lookup"><span data-stu-id="59098-1332">EA48</span></span></td>
  <td><span data-ttu-id="59098-1333">ClearSelectionMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1333">ClearSelectionMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA49.png" width="32" height="32" alt="ClosePaneMirrored" /></td>
  <td><span data-ttu-id="59098-1334">EA49</span><span class="sxs-lookup"><span data-stu-id="59098-1334">EA49</span></span></td>
  <td><span data-ttu-id="59098-1335">ClosePaneMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1335">ClosePaneMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4A.png" width="32" height="32" alt="ContactInfoMirrored" /></td>
  <td><span data-ttu-id="59098-1336">EA4A</span><span class="sxs-lookup"><span data-stu-id="59098-1336">EA4A</span></span></td>
  <td><span data-ttu-id="59098-1337">ContactInfoMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1337">ContactInfoMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4B.png" width="32" height="32" alt="DockRightMirrored" /></td>
  <td><span data-ttu-id="59098-1338">EA4B</span><span class="sxs-lookup"><span data-stu-id="59098-1338">EA4B</span></span></td>
  <td><span data-ttu-id="59098-1339">DockRightMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1339">DockRightMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4C.png" width="32" height="32" alt="DockLeftMirrored" /></td>
  <td><span data-ttu-id="59098-1340">EA4C</span><span class="sxs-lookup"><span data-stu-id="59098-1340">EA4C</span></span></td>
  <td><span data-ttu-id="59098-1341">DockLeftMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1341">DockLeftMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4E.png" width="32" height="32" alt="ExpandTileMirrored" /></td>
  <td><span data-ttu-id="59098-1342">EA4E</span><span class="sxs-lookup"><span data-stu-id="59098-1342">EA4E</span></span></td>
  <td><span data-ttu-id="59098-1343">ExpandTileMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1343">ExpandTileMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA4F.png" width="32" height="32" alt="GoMirrored" /></td>
  <td><span data-ttu-id="59098-1344">EA4F</span><span class="sxs-lookup"><span data-stu-id="59098-1344">EA4F</span></span></td>
  <td><span data-ttu-id="59098-1345">GoMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1345">GoMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA50.png" width="32" height="32" alt="GripperResizeMirrored" /></td>
  <td><span data-ttu-id="59098-1346">EA50</span><span class="sxs-lookup"><span data-stu-id="59098-1346">EA50</span></span></td>
  <td><span data-ttu-id="59098-1347">GripperResizeMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1347">GripperResizeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA51.png" width="32" height="32" alt="HelpMirrored" /></td>
  <td><span data-ttu-id="59098-1348">EA51</span><span class="sxs-lookup"><span data-stu-id="59098-1348">EA51</span></span></td>
  <td><span data-ttu-id="59098-1349">HelpMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1349">HelpMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA52.png" width="32" height="32" alt="ImportMirrored" /></td>
  <td><span data-ttu-id="59098-1350">EA52</span><span class="sxs-lookup"><span data-stu-id="59098-1350">EA52</span></span></td>
  <td><span data-ttu-id="59098-1351">ImportMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1351">ImportMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA53.png" width="32" height="32" alt="ImportAllMirrored" /></td>
  <td><span data-ttu-id="59098-1352">EA53</span><span class="sxs-lookup"><span data-stu-id="59098-1352">EA53</span></span></td>
  <td><span data-ttu-id="59098-1353">ImportAllMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1353">ImportAllMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA54.png" width="32" height="32" alt="LeaveChatMirrored" /></td>
  <td><span data-ttu-id="59098-1354">EA54</span><span class="sxs-lookup"><span data-stu-id="59098-1354">EA54</span></span></td>
  <td><span data-ttu-id="59098-1355">LeaveChatMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1355">LeaveChatMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA55.png" width="32" height="32" alt="ListMirrored" /></td>
  <td><span data-ttu-id="59098-1356">EA55</span><span class="sxs-lookup"><span data-stu-id="59098-1356">EA55</span></span></td>
  <td><span data-ttu-id="59098-1357">ListMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1357">ListMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA56.png" width="32" height="32" alt="MailForwardMirrored" /></td>
  <td><span data-ttu-id="59098-1358">EA56</span><span class="sxs-lookup"><span data-stu-id="59098-1358">EA56</span></span></td>
  <td><span data-ttu-id="59098-1359">MailForwardMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1359">MailForwardMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA57.png" width="32" height="32" alt="MailReplyMirrored" /></td>
  <td><span data-ttu-id="59098-1360">EA57</span><span class="sxs-lookup"><span data-stu-id="59098-1360">EA57</span></span></td>
  <td><span data-ttu-id="59098-1361">MailReplyMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1361">MailReplyMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA58.png" width="32" height="32" alt="MailReplyAllMirrored" /></td>
  <td><span data-ttu-id="59098-1362">EA58</span><span class="sxs-lookup"><span data-stu-id="59098-1362">EA58</span></span></td>
  <td><span data-ttu-id="59098-1363">MailReplyAllMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1363">MailReplyAllMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA5B.png" width="32" height="32" alt="OpenPaneMirrored" /></td>
  <td><span data-ttu-id="59098-1364">EA5B</span><span class="sxs-lookup"><span data-stu-id="59098-1364">EA5B</span></span></td>
  <td><span data-ttu-id="59098-1365">OpenPaneMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1365">OpenPaneMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA5C.png" width="32" height="32" alt="OpenWithMirrored" /></td>
  <td><span data-ttu-id="59098-1366">EA5C</span><span class="sxs-lookup"><span data-stu-id="59098-1366">EA5C</span></span></td>
  <td><span data-ttu-id="59098-1367">OpenWithMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1367">OpenWithMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA5E.png" width="32" height="32" alt="ParkingLocationMirrored" /></td>
  <td><span data-ttu-id="59098-1368">EA5E</span><span class="sxs-lookup"><span data-stu-id="59098-1368">EA5E</span></span></td>
  <td><span data-ttu-id="59098-1369">ParkingLocationMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1369">ParkingLocationMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA5F.png" width="32" height="32" alt="ResizeMouseMediumMirrored" /></td>
  <td><span data-ttu-id="59098-1370">EA5F</span><span class="sxs-lookup"><span data-stu-id="59098-1370">EA5F</span></span></td>
  <td><span data-ttu-id="59098-1371">ResizeMouseMediumMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1371">ResizeMouseMediumMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA60.png" width="32" height="32" alt="ResizeMouseSmallMirrored" /></td>
  <td><span data-ttu-id="59098-1372">EA60</span><span class="sxs-lookup"><span data-stu-id="59098-1372">EA60</span></span></td>
  <td><span data-ttu-id="59098-1373">ResizeMouseSmallMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1373">ResizeMouseSmallMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA61.png" width="32" height="32" alt="ResizeMouseTallMirrored" /></td>
  <td><span data-ttu-id="59098-1374">EA61</span><span class="sxs-lookup"><span data-stu-id="59098-1374">EA61</span></span></td>
  <td><span data-ttu-id="59098-1375">ResizeMouseTallMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1375">ResizeMouseTallMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA62.png" width="32" height="32" alt="ResizeTouchNarrowerMirrored" /></td>
  <td><span data-ttu-id="59098-1376">EA62</span><span class="sxs-lookup"><span data-stu-id="59098-1376">EA62</span></span></td>
  <td><span data-ttu-id="59098-1377">ResizeTouchNarrowerMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1377">ResizeTouchNarrowerMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA63.png" width="32" height="32" alt="SendMirrored" /></td>
  <td><span data-ttu-id="59098-1378">EA63</span><span class="sxs-lookup"><span data-stu-id="59098-1378">EA63</span></span></td>
  <td><span data-ttu-id="59098-1379">SendMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1379">SendMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA64.png" width="32" height="32" alt="SendFillMirrored" /></td>
  <td><span data-ttu-id="59098-1380">EA64</span><span class="sxs-lookup"><span data-stu-id="59098-1380">EA64</span></span></td>
  <td><span data-ttu-id="59098-1381">SendFillMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1381">SendFillMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA65.png" width="32" height="32" alt="ShowResultsMirrored" /></td>
  <td><span data-ttu-id="59098-1382">EA65</span><span class="sxs-lookup"><span data-stu-id="59098-1382">EA65</span></span></td>
  <td><span data-ttu-id="59098-1383">ShowResultsMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1383">ShowResultsMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA69.png" width="32" height="32" alt="Media" /></td>
  <td><span data-ttu-id="59098-1384">EA69</span><span class="sxs-lookup"><span data-stu-id="59098-1384">EA69</span></span></td>
  <td><span data-ttu-id="59098-1385">メディア</span><span class="sxs-lookup"><span data-stu-id="59098-1385">Media</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA6A.png" width="32" height="32" alt="SyncError" /></td>
  <td><span data-ttu-id="59098-1386">EA6A</span><span class="sxs-lookup"><span data-stu-id="59098-1386">EA6A</span></span></td>
  <td><span data-ttu-id="59098-1387">SyncError</span><span class="sxs-lookup"><span data-stu-id="59098-1387">SyncError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA6C.png" width="32" height="32" alt="Devices3" /></td>
  <td><span data-ttu-id="59098-1388">EA6C</span><span class="sxs-lookup"><span data-stu-id="59098-1388">EA6C</span></span></td>
  <td><span data-ttu-id="59098-1389">Devices3</span><span class="sxs-lookup"><span data-stu-id="59098-1389">Devices3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA79.png" width="32" height="32" alt="SlowMotionOn" /></td>
  <td><span data-ttu-id="59098-1390">EA79</span><span class="sxs-lookup"><span data-stu-id="59098-1390">EA79</span></span></td>
  <td><span data-ttu-id="59098-1391">SlowMotionOn</span><span class="sxs-lookup"><span data-stu-id="59098-1391">SlowMotionOn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA80.png" width="32" height="32" alt="Lightbulb" /></td>
  <td><span data-ttu-id="59098-1392">EA80</span><span class="sxs-lookup"><span data-stu-id="59098-1392">EA80</span></span></td>
  <td><span data-ttu-id="59098-1393">Lightbulb</span><span class="sxs-lookup"><span data-stu-id="59098-1393">Lightbulb</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA81.png" width="32" height="32" alt="StatusCircle" /></td>
  <td><span data-ttu-id="59098-1394">EA81</span><span class="sxs-lookup"><span data-stu-id="59098-1394">EA81</span></span></td>
  <td><span data-ttu-id="59098-1395">StatusCircle</span><span class="sxs-lookup"><span data-stu-id="59098-1395">StatusCircle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA82.png" width="32" height="32" alt="StatusTriangle" /></td>
  <td><span data-ttu-id="59098-1396">EA82</span><span class="sxs-lookup"><span data-stu-id="59098-1396">EA82</span></span></td>
  <td><span data-ttu-id="59098-1397">StatusTriangle</span><span class="sxs-lookup"><span data-stu-id="59098-1397">StatusTriangle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA83.png" width="32" height="32" alt="StatusError" /></td>
  <td><span data-ttu-id="59098-1398">EA83</span><span class="sxs-lookup"><span data-stu-id="59098-1398">EA83</span></span></td>
  <td><span data-ttu-id="59098-1399">StatusError</span><span class="sxs-lookup"><span data-stu-id="59098-1399">StatusError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA84.png" width="32" height="32" alt="StatusWarning" /></td>
  <td><span data-ttu-id="59098-1400">EA84</span><span class="sxs-lookup"><span data-stu-id="59098-1400">EA84</span></span></td>
  <td><span data-ttu-id="59098-1401">StatusWarning</span><span class="sxs-lookup"><span data-stu-id="59098-1401">StatusWarning</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA86.png" width="32" height="32" alt="Puzzle" /></td>
  <td><span data-ttu-id="59098-1402">EA86</span><span class="sxs-lookup"><span data-stu-id="59098-1402">EA86</span></span></td>
  <td><span data-ttu-id="59098-1403">Puzzle</span><span class="sxs-lookup"><span data-stu-id="59098-1403">Puzzle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA89.png" width="32" height="32" alt="CalendarSolid" /></td>
  <td><span data-ttu-id="59098-1404">EA89</span><span class="sxs-lookup"><span data-stu-id="59098-1404">EA89</span></span></td>
  <td><span data-ttu-id="59098-1405">CalendarSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1405">CalendarSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8A.png" width="32" height="32" alt="HomeSolid" /></td>
  <td><span data-ttu-id="59098-1406">EA8A</span><span class="sxs-lookup"><span data-stu-id="59098-1406">EA8A</span></span></td>
  <td><span data-ttu-id="59098-1407">HomeSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1407">HomeSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8B.png" width="32" height="32" alt="ParkingLocationSolid" /></td>
  <td><span data-ttu-id="59098-1408">EA8B</span><span class="sxs-lookup"><span data-stu-id="59098-1408">EA8B</span></span></td>
  <td><span data-ttu-id="59098-1409">ParkingLocationSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1409">ParkingLocationSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8C.png" width="32" height="32" alt="ContactSolid" /></td>
  <td><span data-ttu-id="59098-1410">EA8C</span><span class="sxs-lookup"><span data-stu-id="59098-1410">EA8C</span></span></td>
  <td><span data-ttu-id="59098-1411">ContactSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1411">ContactSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8D.png" width="32" height="32" alt="ConstructionSolid" /></td>
  <td><span data-ttu-id="59098-1412">EA8D</span><span class="sxs-lookup"><span data-stu-id="59098-1412">EA8D</span></span></td>
  <td><span data-ttu-id="59098-1413">ConstructionSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1413">ConstructionSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8E.png" width="32" height="32" alt="AccidentSolid" /></td>
  <td><span data-ttu-id="59098-1414">EA8E</span><span class="sxs-lookup"><span data-stu-id="59098-1414">EA8E</span></span></td>
  <td><span data-ttu-id="59098-1415">AccidentSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1415">AccidentSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA8F.png" width="32" height="32" alt="Ringer" /></td>
  <td><span data-ttu-id="59098-1416">EA8F</span><span class="sxs-lookup"><span data-stu-id="59098-1416">EA8F</span></span></td>
  <td><span data-ttu-id="59098-1417">Ringer</span><span class="sxs-lookup"><span data-stu-id="59098-1417">Ringer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA91.png" width="32" height="32" alt="ThoughtBubble" /></td>
  <td><span data-ttu-id="59098-1418">EA91</span><span class="sxs-lookup"><span data-stu-id="59098-1418">EA91</span></span></td>
  <td><span data-ttu-id="59098-1419">ThoughtBubble</span><span class="sxs-lookup"><span data-stu-id="59098-1419">ThoughtBubble</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA92.png" width="32" height="32" alt="HeartBroken" /></td>
  <td><span data-ttu-id="59098-1420">EA92</span><span class="sxs-lookup"><span data-stu-id="59098-1420">EA92</span></span></td>
  <td><span data-ttu-id="59098-1421">HeartBroken</span><span class="sxs-lookup"><span data-stu-id="59098-1421">HeartBroken</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA93.png" width="32" height="32" alt="BatteryCharging10" /></td>
  <td><span data-ttu-id="59098-1422">EA93</span><span class="sxs-lookup"><span data-stu-id="59098-1422">EA93</span></span></td>
  <td><span data-ttu-id="59098-1423">BatteryCharging10</span><span class="sxs-lookup"><span data-stu-id="59098-1423">BatteryCharging10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA94.png" width="32" height="32" alt="BatterySaver9" /></td>
  <td><span data-ttu-id="59098-1424">EA94</span><span class="sxs-lookup"><span data-stu-id="59098-1424">EA94</span></span></td>
  <td><span data-ttu-id="59098-1425">BatterySaver9</span><span class="sxs-lookup"><span data-stu-id="59098-1425">BatterySaver9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA95.png" width="32" height="32" alt="BatterySaver10" /></td>
  <td><span data-ttu-id="59098-1426">EA95</span><span class="sxs-lookup"><span data-stu-id="59098-1426">EA95</span></span></td>
  <td><span data-ttu-id="59098-1427">BatterySaver10</span><span class="sxs-lookup"><span data-stu-id="59098-1427">BatterySaver10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA97.png" width="32" height="32" alt="CallForwardingMirrored" /></td>
  <td><span data-ttu-id="59098-1428">EA97</span><span class="sxs-lookup"><span data-stu-id="59098-1428">EA97</span></span></td>
  <td><span data-ttu-id="59098-1429">CallForwardingMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1429">CallForwardingMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA98.png" width="32" height="32" alt="MultiSelectMirrored" /></td>
  <td><span data-ttu-id="59098-1430">EA98</span><span class="sxs-lookup"><span data-stu-id="59098-1430">EA98</span></span></td>
  <td><span data-ttu-id="59098-1431">MultiSelectMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1431">MultiSelectMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EA99.png" width="32" height="32" alt="Broom" /></td>
  <td><span data-ttu-id="59098-1432">EA99</span><span class="sxs-lookup"><span data-stu-id="59098-1432">EA99</span></span></td>
  <td><span data-ttu-id="59098-1433">Broom</span><span class="sxs-lookup"><span data-stu-id="59098-1433">Broom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EADF.png" width="32" height="32" alt="Trackers" /></td>
  <td><span data-ttu-id="59098-1434">EADF</span><span class="sxs-lookup"><span data-stu-id="59098-1434">EADF</span></span></td>
  <td><span data-ttu-id="59098-1435">Trackers</span><span class="sxs-lookup"><span data-stu-id="59098-1435">Trackers</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB05.png" width="32" height="32" alt="PieSingle" /></td>
  <td><span data-ttu-id="59098-1436">EB05</span><span class="sxs-lookup"><span data-stu-id="59098-1436">EB05</span></span></td>
  <td><span data-ttu-id="59098-1437">PieSingle</span><span class="sxs-lookup"><span data-stu-id="59098-1437">PieSingle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB0F.png" width="32" height="32" alt="StockDown" /></td>
  <td><span data-ttu-id="59098-1438">EB0F</span><span class="sxs-lookup"><span data-stu-id="59098-1438">EB0F</span></span></td>
  <td><span data-ttu-id="59098-1439">StockDown</span><span class="sxs-lookup"><span data-stu-id="59098-1439">StockDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB11.png" width="32" height="32" alt="StockUp" /></td>
  <td><span data-ttu-id="59098-1440">EB11</span><span class="sxs-lookup"><span data-stu-id="59098-1440">EB11</span></span></td>
  <td><span data-ttu-id="59098-1441">StockUp</span><span class="sxs-lookup"><span data-stu-id="59098-1441">StockUp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB3C.png" width="32" height="32" alt="Design" /></td>
  <td><span data-ttu-id="59098-1442">EB3C</span><span class="sxs-lookup"><span data-stu-id="59098-1442">EB3C</span></span></td>
  <td><span data-ttu-id="59098-1443">設計</span><span class="sxs-lookup"><span data-stu-id="59098-1443">Design</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB41.png" width="32" height="32" alt="Website" /></td>
  <td><span data-ttu-id="59098-1444">EB41</span><span class="sxs-lookup"><span data-stu-id="59098-1444">EB41</span></span></td>
  <td><span data-ttu-id="59098-1445">Web サイト</span><span class="sxs-lookup"><span data-stu-id="59098-1445">Website</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB42.png" width="32" height="32" alt="Drop" /></td>
  <td><span data-ttu-id="59098-1446">EB42</span><span class="sxs-lookup"><span data-stu-id="59098-1446">EB42</span></span></td>
  <td><span data-ttu-id="59098-1447">Drop</span><span class="sxs-lookup"><span data-stu-id="59098-1447">Drop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB44.png" width="32" height="32" alt="Radar" /></td>
  <td><span data-ttu-id="59098-1448">EB44</span><span class="sxs-lookup"><span data-stu-id="59098-1448">EB44</span></span></td>
  <td><span data-ttu-id="59098-1449">レーダー チャート</span><span class="sxs-lookup"><span data-stu-id="59098-1449">Radar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB47.png" width="32" height="32" alt="BusSolid" /></td>
  <td><span data-ttu-id="59098-1450">EB47</span><span class="sxs-lookup"><span data-stu-id="59098-1450">EB47</span></span></td>
  <td><span data-ttu-id="59098-1451">BusSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1451">BusSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB48.png" width="32" height="32" alt="FerrySolid" /></td>
  <td><span data-ttu-id="59098-1452">EB48</span><span class="sxs-lookup"><span data-stu-id="59098-1452">EB48</span></span></td>
  <td><span data-ttu-id="59098-1453">FerrySolid</span><span class="sxs-lookup"><span data-stu-id="59098-1453">FerrySolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB49.png" width="32" height="32" alt="StartPointSolid" /></td>
  <td><span data-ttu-id="59098-1454">EB49</span><span class="sxs-lookup"><span data-stu-id="59098-1454">EB49</span></span></td>
  <td><span data-ttu-id="59098-1455">StartPointSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1455">StartPointSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4A.png" width="32" height="32" alt="StopPointSolid" /></td>
  <td><span data-ttu-id="59098-1456">EB4A</span><span class="sxs-lookup"><span data-stu-id="59098-1456">EB4A</span></span></td>
  <td><span data-ttu-id="59098-1457">StopPointSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1457">StopPointSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4B.png" width="32" height="32" alt="EndPointSolid" /></td>
  <td><span data-ttu-id="59098-1458">EB4B</span><span class="sxs-lookup"><span data-stu-id="59098-1458">EB4B</span></span></td>
  <td><span data-ttu-id="59098-1459">EndPointSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1459">EndPointSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4C.png" width="32" height="32" alt="AirplaneSolid" /></td>
  <td><span data-ttu-id="59098-1460">EB4C</span><span class="sxs-lookup"><span data-stu-id="59098-1460">EB4C</span></span></td>
  <td><span data-ttu-id="59098-1461">AirplaneSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1461">AirplaneSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4D.png" width="32" height="32" alt="TrainSolid" /></td>
  <td><span data-ttu-id="59098-1462">EB4D</span><span class="sxs-lookup"><span data-stu-id="59098-1462">EB4D</span></span></td>
  <td><span data-ttu-id="59098-1463">TrainSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1463">TrainSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4E.png" width="32" height="32" alt="WorkSolid" /></td>
  <td><span data-ttu-id="59098-1464">EB4E</span><span class="sxs-lookup"><span data-stu-id="59098-1464">EB4E</span></span></td>
  <td><span data-ttu-id="59098-1465">WorkSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1465">WorkSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB4F.png" width="32" height="32" alt="ReminderFill" /></td>
  <td><span data-ttu-id="59098-1466">EB4F</span><span class="sxs-lookup"><span data-stu-id="59098-1466">EB4F</span></span></td>
  <td><span data-ttu-id="59098-1467">ReminderFill</span><span class="sxs-lookup"><span data-stu-id="59098-1467">ReminderFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB50.png" width="32" height="32" alt="Reminder" /></td>
  <td><span data-ttu-id="59098-1468">EB50</span><span class="sxs-lookup"><span data-stu-id="59098-1468">EB50</span></span></td>
  <td><span data-ttu-id="59098-1469">Reminder</span><span class="sxs-lookup"><span data-stu-id="59098-1469">Reminder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB51.png" width="32" height="32" alt="Heart" /></td>
  <td><span data-ttu-id="59098-1470">EB51</span><span class="sxs-lookup"><span data-stu-id="59098-1470">EB51</span></span></td>
  <td><span data-ttu-id="59098-1471">Heart</span><span class="sxs-lookup"><span data-stu-id="59098-1471">Heart</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB52.png" width="32" height="32" alt="HeartFill" /></td>
  <td><span data-ttu-id="59098-1472">EB52</span><span class="sxs-lookup"><span data-stu-id="59098-1472">EB52</span></span></td>
  <td><span data-ttu-id="59098-1473">HeartFill</span><span class="sxs-lookup"><span data-stu-id="59098-1473">HeartFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB55.png" width="32" height="32" alt="EthernetError" /></td>
  <td><span data-ttu-id="59098-1474">EB55</span><span class="sxs-lookup"><span data-stu-id="59098-1474">EB55</span></span></td>
  <td><span data-ttu-id="59098-1475">EthernetError</span><span class="sxs-lookup"><span data-stu-id="59098-1475">EthernetError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB56.png" width="32" height="32" alt="EthernetWarning" /></td>
  <td><span data-ttu-id="59098-1476">EB56</span><span class="sxs-lookup"><span data-stu-id="59098-1476">EB56</span></span></td>
  <td><span data-ttu-id="59098-1477">EthernetWarning</span><span class="sxs-lookup"><span data-stu-id="59098-1477">EthernetWarning</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB57.png" width="32" height="32" alt="StatusConnecting1" /></td>
  <td><span data-ttu-id="59098-1478">EB57</span><span class="sxs-lookup"><span data-stu-id="59098-1478">EB57</span></span></td>
  <td><span data-ttu-id="59098-1479">StatusConnecting1</span><span class="sxs-lookup"><span data-stu-id="59098-1479">StatusConnecting1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB58.png" width="32" height="32" alt="StatusConnecting2" /></td>
  <td><span data-ttu-id="59098-1480">EB58</span><span class="sxs-lookup"><span data-stu-id="59098-1480">EB58</span></span></td>
  <td><span data-ttu-id="59098-1481">StatusConnecting2</span><span class="sxs-lookup"><span data-stu-id="59098-1481">StatusConnecting2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB59.png" width="32" height="32" alt="StatusUnsecure" /></td>
  <td><span data-ttu-id="59098-1482">EB59</span><span class="sxs-lookup"><span data-stu-id="59098-1482">EB59</span></span></td>
  <td><span data-ttu-id="59098-1483">StatusUnsecure</span><span class="sxs-lookup"><span data-stu-id="59098-1483">StatusUnsecure</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5A.png" width="32" height="32" alt="WifiError0" /></td>
  <td><span data-ttu-id="59098-1484">EB5A</span><span class="sxs-lookup"><span data-stu-id="59098-1484">EB5A</span></span></td>
  <td><span data-ttu-id="59098-1485">WifiError0</span><span class="sxs-lookup"><span data-stu-id="59098-1485">WifiError0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5B.png" width="32" height="32" alt="WifiError1" /></td>
  <td><span data-ttu-id="59098-1486">EB5B</span><span class="sxs-lookup"><span data-stu-id="59098-1486">EB5B</span></span></td>
  <td><span data-ttu-id="59098-1487">WifiError1</span><span class="sxs-lookup"><span data-stu-id="59098-1487">WifiError1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5C.png" width="32" height="32" alt="WifiError2" /></td>
  <td><span data-ttu-id="59098-1488">EB5C</span><span class="sxs-lookup"><span data-stu-id="59098-1488">EB5C</span></span></td>
  <td><span data-ttu-id="59098-1489">WifiError2</span><span class="sxs-lookup"><span data-stu-id="59098-1489">WifiError2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5D.png" width="32" height="32" alt="WifiError3" /></td>
  <td><span data-ttu-id="59098-1490">EB5D</span><span class="sxs-lookup"><span data-stu-id="59098-1490">EB5D</span></span></td>
  <td><span data-ttu-id="59098-1491">WifiError3</span><span class="sxs-lookup"><span data-stu-id="59098-1491">WifiError3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5E.png" width="32" height="32" alt="WifiError4" /></td>
  <td><span data-ttu-id="59098-1492">EB5E</span><span class="sxs-lookup"><span data-stu-id="59098-1492">EB5E</span></span></td>
  <td><span data-ttu-id="59098-1493">WifiError4</span><span class="sxs-lookup"><span data-stu-id="59098-1493">WifiError4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB5F.png" width="32" height="32" alt="WifiWarning0" /></td>
  <td><span data-ttu-id="59098-1494">EB5F</span><span class="sxs-lookup"><span data-stu-id="59098-1494">EB5F</span></span></td>
  <td><span data-ttu-id="59098-1495">WifiWarning0</span><span class="sxs-lookup"><span data-stu-id="59098-1495">WifiWarning0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB60.png" width="32" height="32" alt="WifiWarning1" /></td>
  <td><span data-ttu-id="59098-1496">EB60</span><span class="sxs-lookup"><span data-stu-id="59098-1496">EB60</span></span></td>
  <td><span data-ttu-id="59098-1497">WifiWarning1</span><span class="sxs-lookup"><span data-stu-id="59098-1497">WifiWarning1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB61.png" width="32" height="32" alt="WifiWarning2" /></td>
  <td><span data-ttu-id="59098-1498">EB61</span><span class="sxs-lookup"><span data-stu-id="59098-1498">EB61</span></span></td>
  <td><span data-ttu-id="59098-1499">WifiWarning2</span><span class="sxs-lookup"><span data-stu-id="59098-1499">WifiWarning2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB62.png" width="32" height="32" alt="WifiWarning3" /></td>
  <td><span data-ttu-id="59098-1500">EB62</span><span class="sxs-lookup"><span data-stu-id="59098-1500">EB62</span></span></td>
  <td><span data-ttu-id="59098-1501">WifiWarning3</span><span class="sxs-lookup"><span data-stu-id="59098-1501">WifiWarning3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB63.png" width="32" height="32" alt="WifiWarning4" /></td>
  <td><span data-ttu-id="59098-1502">EB63</span><span class="sxs-lookup"><span data-stu-id="59098-1502">EB63</span></span></td>
  <td><span data-ttu-id="59098-1503">WifiWarning4</span><span class="sxs-lookup"><span data-stu-id="59098-1503">WifiWarning4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB66.png" width="32" height="32" alt="Devices4" /></td>
  <td><span data-ttu-id="59098-1504">EB66</span><span class="sxs-lookup"><span data-stu-id="59098-1504">EB66</span></span></td>
  <td><span data-ttu-id="59098-1505">Devices4</span><span class="sxs-lookup"><span data-stu-id="59098-1505">Devices4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB67.png" width="32" height="32" alt="NUIIris" /></td>
  <td><span data-ttu-id="59098-1506">EB67</span><span class="sxs-lookup"><span data-stu-id="59098-1506">EB67</span></span></td>
  <td><span data-ttu-id="59098-1507">NUIIris</span><span class="sxs-lookup"><span data-stu-id="59098-1507">NUIIris</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB68.png" width="32" height="32" alt="NUIFace" /></td>
  <td><span data-ttu-id="59098-1508">EB68</span><span class="sxs-lookup"><span data-stu-id="59098-1508">EB68</span></span></td>
  <td><span data-ttu-id="59098-1509">NUIFace</span><span class="sxs-lookup"><span data-stu-id="59098-1509">NUIFace</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB7E.png" width="32" height="32" alt="EditMirrored" /></td>
  <td><span data-ttu-id="59098-1510">EB7E</span><span class="sxs-lookup"><span data-stu-id="59098-1510">EB7E</span></span></td>
  <td><span data-ttu-id="59098-1511">EditMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1511">EditMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB82.png" width="32" height="32" alt="NUIFPStartSlideHand " /></td>
  <td><span data-ttu-id="59098-1512">EB82</span><span class="sxs-lookup"><span data-stu-id="59098-1512">EB82</span></span></td>
  <td><span data-ttu-id="59098-1513">NUIFPStartSlideHand</span><span class="sxs-lookup"><span data-stu-id="59098-1513">NUIFPStartSlideHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB83.png" width="32" height="32" alt="NUIFPStartSlideAction " /></td>
  <td><span data-ttu-id="59098-1514">EB83</span><span class="sxs-lookup"><span data-stu-id="59098-1514">EB83</span></span></td>
  <td><span data-ttu-id="59098-1515">NUIFPStartSlideAction</span><span class="sxs-lookup"><span data-stu-id="59098-1515">NUIFPStartSlideAction</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB84.png" width="32" height="32" alt="NUIFPContinueSlideHand " /></td>
  <td><span data-ttu-id="59098-1516">EB84</span><span class="sxs-lookup"><span data-stu-id="59098-1516">EB84</span></span></td>
  <td><span data-ttu-id="59098-1517">NUIFPContinueSlideHand</span><span class="sxs-lookup"><span data-stu-id="59098-1517">NUIFPContinueSlideHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB85.png" width="32" height="32" alt="NUIFPContinueSlideAction" /></td>
  <td><span data-ttu-id="59098-1518">EB85</span><span class="sxs-lookup"><span data-stu-id="59098-1518">EB85</span></span></td>
  <td><span data-ttu-id="59098-1519">NUIFPContinueSlideAction</span><span class="sxs-lookup"><span data-stu-id="59098-1519">NUIFPContinueSlideAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB86.png" width="32" height="32" alt="NUIFPRollRightHand " /></td>
  <td><span data-ttu-id="59098-1520">EB86</span><span class="sxs-lookup"><span data-stu-id="59098-1520">EB86</span></span></td>
  <td><span data-ttu-id="59098-1521">NUIFPRollRightHand</span><span class="sxs-lookup"><span data-stu-id="59098-1521">NUIFPRollRightHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB87.png" width="32" height="32" alt="NUIFPRollRightHandAction" /></td>
  <td><span data-ttu-id="59098-1522">EB87</span><span class="sxs-lookup"><span data-stu-id="59098-1522">EB87</span></span></td>
  <td><span data-ttu-id="59098-1523">NUIFPRollRightHandAction</span><span class="sxs-lookup"><span data-stu-id="59098-1523">NUIFPRollRightHandAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB88.png" width="32" height="32" alt="NUIFPRollLeftHand " /></td>
  <td><span data-ttu-id="59098-1524">EB88</span><span class="sxs-lookup"><span data-stu-id="59098-1524">EB88</span></span></td>
  <td><span data-ttu-id="59098-1525">NUIFPRollLeftHand</span><span class="sxs-lookup"><span data-stu-id="59098-1525">NUIFPRollLeftHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB89.png" width="32" height="32" alt="NUIFPRollLeftAction" /></td>
  <td><span data-ttu-id="59098-1526">EB89</span><span class="sxs-lookup"><span data-stu-id="59098-1526">EB89</span></span></td>
  <td><span data-ttu-id="59098-1527">NUIFPRollLeftAction</span><span class="sxs-lookup"><span data-stu-id="59098-1527">NUIFPRollLeftAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB8A.png" width="32" height="32" alt="NUIFPPressHand " /></td>
  <td><span data-ttu-id="59098-1528">EB8A</span><span class="sxs-lookup"><span data-stu-id="59098-1528">EB8A</span></span></td>
  <td><span data-ttu-id="59098-1529">NUIFPPressHand</span><span class="sxs-lookup"><span data-stu-id="59098-1529">NUIFPPressHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB8B.png" width="32" height="32" alt="NUIFPPressAction" /></td>
  <td><span data-ttu-id="59098-1530">EB8B</span><span class="sxs-lookup"><span data-stu-id="59098-1530">EB8B</span></span></td>
  <td><span data-ttu-id="59098-1531">NUIFPPressAction</span><span class="sxs-lookup"><span data-stu-id="59098-1531">NUIFPPressAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB8C.png" width="32" height="32" alt="NUIFPPressRepeatHand " /></td>
  <td><span data-ttu-id="59098-1532">EB8C</span><span class="sxs-lookup"><span data-stu-id="59098-1532">EB8C</span></span></td>
  <td><span data-ttu-id="59098-1533">NUIFPPressRepeatHand</span><span class="sxs-lookup"><span data-stu-id="59098-1533">NUIFPPressRepeatHand</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB8D.png" width="32" height="32" alt="NUIFPPressRepeatAction" /></td>
  <td><span data-ttu-id="59098-1534">EB8D</span><span class="sxs-lookup"><span data-stu-id="59098-1534">EB8D</span></span></td>
  <td><span data-ttu-id="59098-1535">NUIFPPressRepeatAction</span><span class="sxs-lookup"><span data-stu-id="59098-1535">NUIFPPressRepeatAction</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB90.png" width="32" height="32" alt="StatusErrorFull" /></td>
  <td><span data-ttu-id="59098-1536">EB90</span><span class="sxs-lookup"><span data-stu-id="59098-1536">EB90</span></span></td>
  <td><span data-ttu-id="59098-1537">StatusErrorFull</span><span class="sxs-lookup"><span data-stu-id="59098-1537">StatusErrorFull</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB91.png" width="32" height="32" alt="TaskViewExpanded" /></td>
  <td><span data-ttu-id="59098-1538">EB91</span><span class="sxs-lookup"><span data-stu-id="59098-1538">EB91</span></span></td>
  <td><span data-ttu-id="59098-1539">TaskViewExpanded</span><span class="sxs-lookup"><span data-stu-id="59098-1539">TaskViewExpanded</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB95.png" width="32" height="32" alt="Certificate" /></td>
  <td><span data-ttu-id="59098-1540">EB95</span><span class="sxs-lookup"><span data-stu-id="59098-1540">EB95</span></span></td>
  <td><span data-ttu-id="59098-1541">Certificate</span><span class="sxs-lookup"><span data-stu-id="59098-1541">Certificate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB96.png" width="32" height="32" alt="BackSpaceQWERTYLg" /></td>
  <td><span data-ttu-id="59098-1542">EB96</span><span class="sxs-lookup"><span data-stu-id="59098-1542">EB96</span></span></td>
  <td><span data-ttu-id="59098-1543">BackSpaceQWERTYLg</span><span class="sxs-lookup"><span data-stu-id="59098-1543">BackSpaceQWERTYLg</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB97.png" width="32" height="32" alt="ReturnKeyLg" /></td>
  <td><span data-ttu-id="59098-1544">EB97</span><span class="sxs-lookup"><span data-stu-id="59098-1544">EB97</span></span></td>
  <td><span data-ttu-id="59098-1545">ReturnKeyLg</span><span class="sxs-lookup"><span data-stu-id="59098-1545">ReturnKeyLg</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB9D.png" width="32" height="32" alt="FastForward" /></td>
  <td><span data-ttu-id="59098-1546">EB9D</span><span class="sxs-lookup"><span data-stu-id="59098-1546">EB9D</span></span></td>
  <td><span data-ttu-id="59098-1547">FastForward</span><span class="sxs-lookup"><span data-stu-id="59098-1547">FastForward</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB9E.png" width="32" height="32" alt="Rewind" /></td>
  <td><span data-ttu-id="59098-1548">EB9E</span><span class="sxs-lookup"><span data-stu-id="59098-1548">EB9E</span></span></td>
  <td><span data-ttu-id="59098-1549">Rewind</span><span class="sxs-lookup"><span data-stu-id="59098-1549">Rewind</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EB9F.png" width="32" height="32" alt="Photo2" /></td>
  <td><span data-ttu-id="59098-1550">EB9F</span><span class="sxs-lookup"><span data-stu-id="59098-1550">EB9F</span></span></td>
  <td><span data-ttu-id="59098-1551">Photo2</span><span class="sxs-lookup"><span data-stu-id="59098-1551">Photo2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA0.png" width="32" height="32" alt=" MobBattery0" /></td>
  <td><span data-ttu-id="59098-1552">EBA0</span><span class="sxs-lookup"><span data-stu-id="59098-1552">EBA0</span></span></td>
  <td> <span data-ttu-id="59098-1553">MobBattery0</span><span class="sxs-lookup"><span data-stu-id="59098-1553">MobBattery0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA1.png" width="32" height="32" alt=" MobBattery1" /></td>
  <td><span data-ttu-id="59098-1554">EBA1</span><span class="sxs-lookup"><span data-stu-id="59098-1554">EBA1</span></span></td>
  <td> <span data-ttu-id="59098-1555">MobBattery1</span><span class="sxs-lookup"><span data-stu-id="59098-1555">MobBattery1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA2.png" width="32" height="32" alt=" MobBattery2" /></td>
  <td><span data-ttu-id="59098-1556">EBA2</span><span class="sxs-lookup"><span data-stu-id="59098-1556">EBA2</span></span></td>
  <td> <span data-ttu-id="59098-1557">MobBattery2</span><span class="sxs-lookup"><span data-stu-id="59098-1557">MobBattery2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA3.png" width="32" height="32" alt=" MobBattery3" /></td>
  <td><span data-ttu-id="59098-1558">EBA3</span><span class="sxs-lookup"><span data-stu-id="59098-1558">EBA3</span></span></td>
  <td> <span data-ttu-id="59098-1559">MobBattery3</span><span class="sxs-lookup"><span data-stu-id="59098-1559">MobBattery3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA4.png" width="32" height="32" alt=" MobBattery4" /></td>
  <td><span data-ttu-id="59098-1560">EBA4</span><span class="sxs-lookup"><span data-stu-id="59098-1560">EBA4</span></span></td>
  <td> <span data-ttu-id="59098-1561">MobBattery4</span><span class="sxs-lookup"><span data-stu-id="59098-1561">MobBattery4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA5.png" width="32" height="32" alt=" MobBattery5" /></td>
  <td><span data-ttu-id="59098-1562">EBA5</span><span class="sxs-lookup"><span data-stu-id="59098-1562">EBA5</span></span></td>
  <td> <span data-ttu-id="59098-1563">MobBattery5</span><span class="sxs-lookup"><span data-stu-id="59098-1563">MobBattery5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA6.png" width="32" height="32" alt=" MobBattery6" /></td>
  <td><span data-ttu-id="59098-1564">EBA6</span><span class="sxs-lookup"><span data-stu-id="59098-1564">EBA6</span></span></td>
  <td> <span data-ttu-id="59098-1565">MobBattery6</span><span class="sxs-lookup"><span data-stu-id="59098-1565">MobBattery6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA7.png" width="32" height="32" alt=" MobBattery7" /></td>
  <td><span data-ttu-id="59098-1566">EBA7</span><span class="sxs-lookup"><span data-stu-id="59098-1566">EBA7</span></span></td>
  <td> <span data-ttu-id="59098-1567">MobBattery7</span><span class="sxs-lookup"><span data-stu-id="59098-1567">MobBattery7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA8.png" width="32" height="32" alt=" MobBattery8" /></td>
  <td><span data-ttu-id="59098-1568">EBA8</span><span class="sxs-lookup"><span data-stu-id="59098-1568">EBA8</span></span></td>
  <td> <span data-ttu-id="59098-1569">MobBattery8</span><span class="sxs-lookup"><span data-stu-id="59098-1569">MobBattery8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBA9.png" width="32" height="32" alt=" MobBattery9" /></td>
  <td><span data-ttu-id="59098-1570">EBA9</span><span class="sxs-lookup"><span data-stu-id="59098-1570">EBA9</span></span></td>
  <td> <span data-ttu-id="59098-1571">MobBattery9</span><span class="sxs-lookup"><span data-stu-id="59098-1571">MobBattery9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAA.png" width="32" height="32" alt="MobBattery10" /></td>
  <td><span data-ttu-id="59098-1572">EBAA</span><span class="sxs-lookup"><span data-stu-id="59098-1572">EBAA</span></span></td>
  <td><span data-ttu-id="59098-1573">MobBattery10</span><span class="sxs-lookup"><span data-stu-id="59098-1573">MobBattery10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAB.png" width="32" height="32" alt=" MobBatteryCharging0" /></td>
  <td><span data-ttu-id="59098-1574">EBAB</span><span class="sxs-lookup"><span data-stu-id="59098-1574">EBAB</span></span></td>
  <td> <span data-ttu-id="59098-1575">MobBatteryCharging0</span><span class="sxs-lookup"><span data-stu-id="59098-1575">MobBatteryCharging0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAC.png" width="32" height="32" alt=" MobBatteryCharging1" /></td>
  <td><span data-ttu-id="59098-1576">EBAC</span><span class="sxs-lookup"><span data-stu-id="59098-1576">EBAC</span></span></td>
  <td> <span data-ttu-id="59098-1577">MobBatteryCharging1</span><span class="sxs-lookup"><span data-stu-id="59098-1577">MobBatteryCharging1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAD.png" width="32" height="32" alt=" MobBatteryCharging2" /></td>
  <td><span data-ttu-id="59098-1578">EBAD</span><span class="sxs-lookup"><span data-stu-id="59098-1578">EBAD</span></span></td>
  <td> <span data-ttu-id="59098-1579">MobBatteryCharging2</span><span class="sxs-lookup"><span data-stu-id="59098-1579">MobBatteryCharging2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAE.png" width="32" height="32" alt=" MobBatteryCharging3" /></td>
  <td><span data-ttu-id="59098-1580">EBAE</span><span class="sxs-lookup"><span data-stu-id="59098-1580">EBAE</span></span></td>
  <td> <span data-ttu-id="59098-1581">MobBatteryCharging3</span><span class="sxs-lookup"><span data-stu-id="59098-1581">MobBatteryCharging3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBAF.png" width="32" height="32" alt=" MobBatteryCharging4" /></td>
  <td><span data-ttu-id="59098-1582">EBAF</span><span class="sxs-lookup"><span data-stu-id="59098-1582">EBAF</span></span></td>
  <td> <span data-ttu-id="59098-1583">MobBatteryCharging4</span><span class="sxs-lookup"><span data-stu-id="59098-1583">MobBatteryCharging4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB0.png" width="32" height="32" alt=" MobBatteryCharging5" /></td>
  <td><span data-ttu-id="59098-1584">EBB0</span><span class="sxs-lookup"><span data-stu-id="59098-1584">EBB0</span></span></td>
  <td> <span data-ttu-id="59098-1585">MobBatteryCharging5</span><span class="sxs-lookup"><span data-stu-id="59098-1585">MobBatteryCharging5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB1.png" width="32" height="32" alt=" MobBatteryCharging6" /></td>
  <td><span data-ttu-id="59098-1586">EBB1</span><span class="sxs-lookup"><span data-stu-id="59098-1586">EBB1</span></span></td>
  <td> <span data-ttu-id="59098-1587">MobBatteryCharging6</span><span class="sxs-lookup"><span data-stu-id="59098-1587">MobBatteryCharging6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB2.png" width="32" height="32" alt=" MobBatteryCharging7" /></td>
  <td><span data-ttu-id="59098-1588">EBB2</span><span class="sxs-lookup"><span data-stu-id="59098-1588">EBB2</span></span></td>
  <td> <span data-ttu-id="59098-1589">MobBatteryCharging7</span><span class="sxs-lookup"><span data-stu-id="59098-1589">MobBatteryCharging7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB3.png" width="32" height="32" alt=" MobBatteryCharging8" /></td>
  <td><span data-ttu-id="59098-1590">EBB3</span><span class="sxs-lookup"><span data-stu-id="59098-1590">EBB3</span></span></td>
  <td> <span data-ttu-id="59098-1591">MobBatteryCharging8</span><span class="sxs-lookup"><span data-stu-id="59098-1591">MobBatteryCharging8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB4.png" width="32" height="32" alt=" MobBatteryCharging9" /></td>
  <td><span data-ttu-id="59098-1592">EBB4</span><span class="sxs-lookup"><span data-stu-id="59098-1592">EBB4</span></span></td>
  <td> <span data-ttu-id="59098-1593">MobBatteryCharging9</span><span class="sxs-lookup"><span data-stu-id="59098-1593">MobBatteryCharging9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB5.png" width="32" height="32" alt=" MobBatteryCharging10" /></td>
  <td><span data-ttu-id="59098-1594">EBB5</span><span class="sxs-lookup"><span data-stu-id="59098-1594">EBB5</span></span></td>
  <td> <span data-ttu-id="59098-1595">MobBatteryCharging10</span><span class="sxs-lookup"><span data-stu-id="59098-1595">MobBatteryCharging10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB6.png" width="32" height="32" alt=" MobBatterySaver0" /></td>
  <td><span data-ttu-id="59098-1596">EBB6</span><span class="sxs-lookup"><span data-stu-id="59098-1596">EBB6</span></span></td>
  <td> <span data-ttu-id="59098-1597">MobBatterySaver0</span><span class="sxs-lookup"><span data-stu-id="59098-1597">MobBatterySaver0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB7.png" width="32" height="32" alt=" MobBatterySaver1" /></td>
  <td><span data-ttu-id="59098-1598">EBB7</span><span class="sxs-lookup"><span data-stu-id="59098-1598">EBB7</span></span></td>
  <td> <span data-ttu-id="59098-1599">MobBatterySaver1</span><span class="sxs-lookup"><span data-stu-id="59098-1599">MobBatterySaver1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB8.png" width="32" height="32" alt=" MobBatterySaver2" /></td>
  <td><span data-ttu-id="59098-1600">EBB8</span><span class="sxs-lookup"><span data-stu-id="59098-1600">EBB8</span></span></td>
  <td> <span data-ttu-id="59098-1601">MobBatterySaver2</span><span class="sxs-lookup"><span data-stu-id="59098-1601">MobBatterySaver2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBB9.png" width="32" height="32" alt=" MobBatterySaver3" /></td>
  <td><span data-ttu-id="59098-1602">EBB9</span><span class="sxs-lookup"><span data-stu-id="59098-1602">EBB9</span></span></td>
  <td> <span data-ttu-id="59098-1603">MobBatterySaver3</span><span class="sxs-lookup"><span data-stu-id="59098-1603">MobBatterySaver3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBA.png" width="32" height="32" alt=" MobBatterySaver4" /></td>
  <td><span data-ttu-id="59098-1604">EBBA</span><span class="sxs-lookup"><span data-stu-id="59098-1604">EBBA</span></span></td>
  <td> <span data-ttu-id="59098-1605">MobBatterySaver4</span><span class="sxs-lookup"><span data-stu-id="59098-1605">MobBatterySaver4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBB.png" width="32" height="32" alt=" MobBatterySaver5" /></td>
  <td><span data-ttu-id="59098-1606">EBBB</span><span class="sxs-lookup"><span data-stu-id="59098-1606">EBBB</span></span></td>
  <td> <span data-ttu-id="59098-1607">MobBatterySaver5</span><span class="sxs-lookup"><span data-stu-id="59098-1607">MobBatterySaver5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBC.png" width="32" height="32" alt=" MobBatterySaver6" /></td>
  <td><span data-ttu-id="59098-1608">EBBC</span><span class="sxs-lookup"><span data-stu-id="59098-1608">EBBC</span></span></td>
  <td> <span data-ttu-id="59098-1609">MobBatterySaver6</span><span class="sxs-lookup"><span data-stu-id="59098-1609">MobBatterySaver6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBD.png" width="32" height="32" alt=" MobBatterySaver7" /></td>
  <td><span data-ttu-id="59098-1610">EBBD</span><span class="sxs-lookup"><span data-stu-id="59098-1610">EBBD</span></span></td>
  <td> <span data-ttu-id="59098-1611">MobBatterySaver7</span><span class="sxs-lookup"><span data-stu-id="59098-1611">MobBatterySaver7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBE.png" width="32" height="32" alt=" MobBatterySaver8" /></td>
  <td><span data-ttu-id="59098-1612">EBBE</span><span class="sxs-lookup"><span data-stu-id="59098-1612">EBBE</span></span></td>
  <td> <span data-ttu-id="59098-1613">MobBatterySaver8</span><span class="sxs-lookup"><span data-stu-id="59098-1613">MobBatterySaver8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBBF.png" width="32" height="32" alt=" MobBatterySaver9" /></td>
  <td><span data-ttu-id="59098-1614">EBBF</span><span class="sxs-lookup"><span data-stu-id="59098-1614">EBBF</span></span></td>
  <td> <span data-ttu-id="59098-1615">MobBatterySaver9</span><span class="sxs-lookup"><span data-stu-id="59098-1615">MobBatterySaver9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC0.png" width="32" height="32" alt=" MobBatterySaver10" /></td>
  <td><span data-ttu-id="59098-1616">EBC0</span><span class="sxs-lookup"><span data-stu-id="59098-1616">EBC0</span></span></td>
  <td> <span data-ttu-id="59098-1617">MobBatterySaver10</span><span class="sxs-lookup"><span data-stu-id="59098-1617">MobBatterySaver10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC3.png" width="32" height="32" alt="DictionaryCloud" /></td>
  <td><span data-ttu-id="59098-1618">EBC3</span><span class="sxs-lookup"><span data-stu-id="59098-1618">EBC3</span></span></td>
  <td><span data-ttu-id="59098-1619">DictionaryCloud</span><span class="sxs-lookup"><span data-stu-id="59098-1619">DictionaryCloud</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC4.png" width="32" height="32" alt="ResetDrive" /></td>
  <td><span data-ttu-id="59098-1620">EBC4</span><span class="sxs-lookup"><span data-stu-id="59098-1620">EBC4</span></span></td>
  <td><span data-ttu-id="59098-1621">ResetDrive</span><span class="sxs-lookup"><span data-stu-id="59098-1621">ResetDrive</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC5.png" width="32" height="32" alt="VolumeBars" /></td>
  <td><span data-ttu-id="59098-1622">EBC5</span><span class="sxs-lookup"><span data-stu-id="59098-1622">EBC5</span></span></td>
  <td><span data-ttu-id="59098-1623">VolumeBars</span><span class="sxs-lookup"><span data-stu-id="59098-1623">VolumeBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBC6.png" width="32" height="32" alt="Project" /></td>
  <td><span data-ttu-id="59098-1624">EBC6</span><span class="sxs-lookup"><span data-stu-id="59098-1624">EBC6</span></span></td>
  <td><span data-ttu-id="59098-1625">Project</span><span class="sxs-lookup"><span data-stu-id="59098-1625">Project</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD2.png" width="32" height="32" alt="AdjustHologram" /></td>
  <td><span data-ttu-id="59098-1626">EBD2</span><span class="sxs-lookup"><span data-stu-id="59098-1626">EBD2</span></span></td>
  <td><span data-ttu-id="59098-1627">AdjustHologram</span><span class="sxs-lookup"><span data-stu-id="59098-1627">AdjustHologram</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD4.png" width="32" height="32" alt="WifiCallBars" /></td>
  <td><span data-ttu-id="59098-1628">EBD4</span><span class="sxs-lookup"><span data-stu-id="59098-1628">EBD4</span></span></td>
  <td><span data-ttu-id="59098-1629">WifiCallBars</span><span class="sxs-lookup"><span data-stu-id="59098-1629">WifiCallBars</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD5.png" width="32" height="32" alt="WifiCall0" /></td>
  <td><span data-ttu-id="59098-1630">EBD5</span><span class="sxs-lookup"><span data-stu-id="59098-1630">EBD5</span></span></td>
  <td><span data-ttu-id="59098-1631">WifiCall0</span><span class="sxs-lookup"><span data-stu-id="59098-1631">WifiCall0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD6.png" width="32" height="32" alt="WifiCall1" /></td>
  <td><span data-ttu-id="59098-1632">EBD6</span><span class="sxs-lookup"><span data-stu-id="59098-1632">EBD6</span></span></td>
  <td><span data-ttu-id="59098-1633">WifiCall1</span><span class="sxs-lookup"><span data-stu-id="59098-1633">WifiCall1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD7.png" width="32" height="32" alt="WifiCall2" /></td>
  <td><span data-ttu-id="59098-1634">EBD7</span><span class="sxs-lookup"><span data-stu-id="59098-1634">EBD7</span></span></td>
  <td><span data-ttu-id="59098-1635">WifiCall2</span><span class="sxs-lookup"><span data-stu-id="59098-1635">WifiCall2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD8.png" width="32" height="32" alt="WifiCall3" /></td>
  <td><span data-ttu-id="59098-1636">EBD8</span><span class="sxs-lookup"><span data-stu-id="59098-1636">EBD8</span></span></td>
  <td><span data-ttu-id="59098-1637">WifiCall3</span><span class="sxs-lookup"><span data-stu-id="59098-1637">WifiCall3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBD9.png" width="32" height="32" alt="WifiCall4" /></td>
  <td><span data-ttu-id="59098-1638">EBD9</span><span class="sxs-lookup"><span data-stu-id="59098-1638">EBD9</span></span></td>
  <td><span data-ttu-id="59098-1639">WifiCall4</span><span class="sxs-lookup"><span data-stu-id="59098-1639">WifiCall4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBDA.png" width="32" height="32" alt="Family" /></td>
  <td><span data-ttu-id="59098-1640">EBDA</span><span class="sxs-lookup"><span data-stu-id="59098-1640">EBDA</span></span></td>
  <td><span data-ttu-id="59098-1641">Family (ファミリ)</span><span class="sxs-lookup"><span data-stu-id="59098-1641">Family</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBDB.png" width="32" height="32" alt="LockFeedback" /></td>
  <td><span data-ttu-id="59098-1642">EBDB</span><span class="sxs-lookup"><span data-stu-id="59098-1642">EBDB</span></span></td>
  <td><span data-ttu-id="59098-1643">LockFeedback</span><span class="sxs-lookup"><span data-stu-id="59098-1643">LockFeedback</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBDE.png" width="32" height="32" alt="DeviceDiscovery" /></td>
  <td><span data-ttu-id="59098-1644">EBDE</span><span class="sxs-lookup"><span data-stu-id="59098-1644">EBDE</span></span></td>
  <td><span data-ttu-id="59098-1645">DeviceDiscovery</span><span class="sxs-lookup"><span data-stu-id="59098-1645">DeviceDiscovery</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBE6.png" width="32" height="32" alt="WindDirection" /></td>
  <td><span data-ttu-id="59098-1646">EBE6</span><span class="sxs-lookup"><span data-stu-id="59098-1646">EBE6</span></span></td>
  <td><span data-ttu-id="59098-1647">WindDirection</span><span class="sxs-lookup"><span data-stu-id="59098-1647">WindDirection</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBE7.png" width="32" height="32" alt="RightArrowKeyTime0" /></td>
  <td><span data-ttu-id="59098-1648">EBE7</span><span class="sxs-lookup"><span data-stu-id="59098-1648">EBE7</span></span></td>
  <td><span data-ttu-id="59098-1649">RightArrowKeyTime0</span><span class="sxs-lookup"><span data-stu-id="59098-1649">RightArrowKeyTime0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBE8.png" width="32" height="32" alt="Bug" /></td>
  <td><span data-ttu-id="59098-1650">EBE8</span><span class="sxs-lookup"><span data-stu-id="59098-1650">EBE8</span></span></td>
  <td><span data-ttu-id="59098-1651">バグ</span><span class="sxs-lookup"><span data-stu-id="59098-1651">Bug</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBFC.png" width="32" height="32" alt="TabletMode" /></td>
  <td><span data-ttu-id="59098-1652">EBFC</span><span class="sxs-lookup"><span data-stu-id="59098-1652">EBFC</span></span></td>
  <td><span data-ttu-id="59098-1653">TabletMode</span><span class="sxs-lookup"><span data-stu-id="59098-1653">TabletMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBFD.png" width="32" height="32" alt="StatusCircleLeft" /></td>
  <td><span data-ttu-id="59098-1654">EBFD</span><span class="sxs-lookup"><span data-stu-id="59098-1654">EBFD</span></span></td>
  <td><span data-ttu-id="59098-1655">StatusCircleLeft</span><span class="sxs-lookup"><span data-stu-id="59098-1655">StatusCircleLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBFE.png" width="32" height="32" alt="StatusTriangleLeft" /></td>
  <td><span data-ttu-id="59098-1656">EBFE</span><span class="sxs-lookup"><span data-stu-id="59098-1656">EBFE</span></span></td>
  <td><span data-ttu-id="59098-1657">StatusTriangleLeft</span><span class="sxs-lookup"><span data-stu-id="59098-1657">StatusTriangleLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EBFF.png" width="32" height="32" alt="StatusErrorLeft" /></td>
  <td><span data-ttu-id="59098-1658">EBFF</span><span class="sxs-lookup"><span data-stu-id="59098-1658">EBFF</span></span></td>
  <td><span data-ttu-id="59098-1659">StatusErrorLeft</span><span class="sxs-lookup"><span data-stu-id="59098-1659">StatusErrorLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC00.png" width="32" height="32" alt="StatusWarningLeft" /></td>
  <td><span data-ttu-id="59098-1660">EC00</span><span class="sxs-lookup"><span data-stu-id="59098-1660">EC00</span></span></td>
  <td><span data-ttu-id="59098-1661">StatusWarningLeft</span><span class="sxs-lookup"><span data-stu-id="59098-1661">StatusWarningLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC02.png" width="32" height="32" alt="MobBatteryUnknown" /></td>
  <td><span data-ttu-id="59098-1662">EC02</span><span class="sxs-lookup"><span data-stu-id="59098-1662">EC02</span></span></td>
  <td><span data-ttu-id="59098-1663">MobBatteryUnknown</span><span class="sxs-lookup"><span data-stu-id="59098-1663">MobBatteryUnknown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC05.png" width="32" height="32" alt="NetworkTower" /></td>
  <td><span data-ttu-id="59098-1664">EC05</span><span class="sxs-lookup"><span data-stu-id="59098-1664">EC05</span></span></td>
  <td><span data-ttu-id="59098-1665">NetworkTower</span><span class="sxs-lookup"><span data-stu-id="59098-1665">NetworkTower</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC06.png" width="32" height="32" alt="CityNext" /></td>
  <td><span data-ttu-id="59098-1666">EC06</span><span class="sxs-lookup"><span data-stu-id="59098-1666">EC06</span></span></td>
  <td><span data-ttu-id="59098-1667">CityNext</span><span class="sxs-lookup"><span data-stu-id="59098-1667">CityNext</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC07.png" width="32" height="32" alt="CityNext2" /></td>
  <td><span data-ttu-id="59098-1668">EC07</span><span class="sxs-lookup"><span data-stu-id="59098-1668">EC07</span></span></td>
  <td><span data-ttu-id="59098-1669">CityNext2</span><span class="sxs-lookup"><span data-stu-id="59098-1669">CityNext2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC08.png" width="32" height="32" alt="Courthouse" /></td>
  <td><span data-ttu-id="59098-1670">EC08</span><span class="sxs-lookup"><span data-stu-id="59098-1670">EC08</span></span></td>
  <td><span data-ttu-id="59098-1671">Courthouse</span><span class="sxs-lookup"><span data-stu-id="59098-1671">Courthouse</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC09.png" width="32" height="32" alt="Groceries" /></td>
  <td><span data-ttu-id="59098-1672">EC09</span><span class="sxs-lookup"><span data-stu-id="59098-1672">EC09</span></span></td>
  <td><span data-ttu-id="59098-1673">Groceries</span><span class="sxs-lookup"><span data-stu-id="59098-1673">Groceries</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC0A.png" width="32" height="32" alt="Sustainable" /></td>
  <td><span data-ttu-id="59098-1674">EC0A</span><span class="sxs-lookup"><span data-stu-id="59098-1674">EC0A</span></span></td>
  <td><span data-ttu-id="59098-1675">Sustainable</span><span class="sxs-lookup"><span data-stu-id="59098-1675">Sustainable</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC0B.png" width="32" height="32" alt="BuildingEnergy" /></td>
  <td><span data-ttu-id="59098-1676">EC0B</span><span class="sxs-lookup"><span data-stu-id="59098-1676">EC0B</span></span></td>
  <td><span data-ttu-id="59098-1677">BuildingEnergy</span><span class="sxs-lookup"><span data-stu-id="59098-1677">BuildingEnergy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC11.png" width="32" height="32" alt="ToggleFilled" /></td>
  <td><span data-ttu-id="59098-1678">EC11</span><span class="sxs-lookup"><span data-stu-id="59098-1678">EC11</span></span></td>
  <td><span data-ttu-id="59098-1679">ToggleFilled</span><span class="sxs-lookup"><span data-stu-id="59098-1679">ToggleFilled</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC12.png" width="32" height="32" alt="ToggleBorder" /></td>
  <td><span data-ttu-id="59098-1680">EC12</span><span class="sxs-lookup"><span data-stu-id="59098-1680">EC12</span></span></td>
  <td><span data-ttu-id="59098-1681">ToggleBorder</span><span class="sxs-lookup"><span data-stu-id="59098-1681">ToggleBorder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC13.png" width="32" height="32" alt="SliderThumb" /></td>
  <td><span data-ttu-id="59098-1682">EC13</span><span class="sxs-lookup"><span data-stu-id="59098-1682">EC13</span></span></td>
  <td><span data-ttu-id="59098-1683">SliderThumb</span><span class="sxs-lookup"><span data-stu-id="59098-1683">SliderThumb</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC14.png" width="32" height="32" alt="ToggleThumb" /></td>
  <td><span data-ttu-id="59098-1684">EC14</span><span class="sxs-lookup"><span data-stu-id="59098-1684">EC14</span></span></td>
  <td><span data-ttu-id="59098-1685">ToggleThumb</span><span class="sxs-lookup"><span data-stu-id="59098-1685">ToggleThumb</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC15.png" width="32" height="32" alt="MiracastLogoSmall" /></td>
  <td><span data-ttu-id="59098-1686">EC15</span><span class="sxs-lookup"><span data-stu-id="59098-1686">EC15</span></span></td>
  <td><span data-ttu-id="59098-1687">MiracastLogoSmall</span><span class="sxs-lookup"><span data-stu-id="59098-1687">MiracastLogoSmall</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC16.png" width="32" height="32" alt="MiracastLogoLarge" /></td>
  <td><span data-ttu-id="59098-1688">EC16</span><span class="sxs-lookup"><span data-stu-id="59098-1688">EC16</span></span></td>
  <td><span data-ttu-id="59098-1689">MiracastLogoLarge</span><span class="sxs-lookup"><span data-stu-id="59098-1689">MiracastLogoLarge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC19.png" width="32" height="32" alt="PLAP" /></td>
  <td><span data-ttu-id="59098-1690">EC19</span><span class="sxs-lookup"><span data-stu-id="59098-1690">EC19</span></span></td>
  <td><span data-ttu-id="59098-1691">PLAP</span><span class="sxs-lookup"><span data-stu-id="59098-1691">PLAP</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC1B.png" width="32" height="32" alt="Badge" /></td>
  <td><span data-ttu-id="59098-1692">EC1B</span><span class="sxs-lookup"><span data-stu-id="59098-1692">EC1B</span></span></td>
  <td><span data-ttu-id="59098-1693">バッジ</span><span class="sxs-lookup"><span data-stu-id="59098-1693">Badge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC1E.png" width="32" height="32" alt="SignalRoaming" /></td>
  <td><span data-ttu-id="59098-1694">EC1E</span><span class="sxs-lookup"><span data-stu-id="59098-1694">EC1E</span></span></td>
  <td><span data-ttu-id="59098-1695">SignalRoaming</span><span class="sxs-lookup"><span data-stu-id="59098-1695">SignalRoaming</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC20.png" width="32" height="32" alt="MobileLocked" /></td>
  <td><span data-ttu-id="59098-1696">EC20</span><span class="sxs-lookup"><span data-stu-id="59098-1696">EC20</span></span></td>
  <td><span data-ttu-id="59098-1697">MobileLocked</span><span class="sxs-lookup"><span data-stu-id="59098-1697">MobileLocked</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC24.png" width="32" height="32" alt="InsiderHubApp" /></td>
  <td><span data-ttu-id="59098-1698">EC24</span><span class="sxs-lookup"><span data-stu-id="59098-1698">EC24</span></span></td>
  <td><span data-ttu-id="59098-1699">InsiderHubApp</span><span class="sxs-lookup"><span data-stu-id="59098-1699">InsiderHubApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC25.png" width="32" height="32" alt="PersonalFolder" /></td>
  <td><span data-ttu-id="59098-1700">EC25</span><span class="sxs-lookup"><span data-stu-id="59098-1700">EC25</span></span></td>
  <td><span data-ttu-id="59098-1701">PersonalFolder</span><span class="sxs-lookup"><span data-stu-id="59098-1701">PersonalFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC26.png" width="32" height="32" alt="HomeGroup" /></td>
  <td><span data-ttu-id="59098-1702">EC26</span><span class="sxs-lookup"><span data-stu-id="59098-1702">EC26</span></span></td>
  <td><span data-ttu-id="59098-1703">ホームグループ</span><span class="sxs-lookup"><span data-stu-id="59098-1703">HomeGroup</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC27.png" width="32" height="32" alt="MyNetwork" /></td>
  <td><span data-ttu-id="59098-1704">EC27</span><span class="sxs-lookup"><span data-stu-id="59098-1704">EC27</span></span></td>
  <td><span data-ttu-id="59098-1705">MyNetwork</span><span class="sxs-lookup"><span data-stu-id="59098-1705">MyNetwork</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC31.png" width="32" height="32" alt="KeyboardFull" /></td>
  <td><span data-ttu-id="59098-1706">EC31</span><span class="sxs-lookup"><span data-stu-id="59098-1706">EC31</span></span></td>
  <td><span data-ttu-id="59098-1707">KeyboardFull</span><span class="sxs-lookup"><span data-stu-id="59098-1707">KeyboardFull</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC32.png" width="32" height="32" alt="Cafe" /></td>
  <td><span data-ttu-id="59098-1708">EC32</span><span class="sxs-lookup"><span data-stu-id="59098-1708">EC32</span></span></td>
  <td><span data-ttu-id="59098-1709">カフェ</span><span class="sxs-lookup"><span data-stu-id="59098-1709">Cafe</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC37.png" width="32" height="32" alt="MobSignal1" /></td>
  <td><span data-ttu-id="59098-1710">EC37</span><span class="sxs-lookup"><span data-stu-id="59098-1710">EC37</span></span></td>
  <td><span data-ttu-id="59098-1711">MobSignal1</span><span class="sxs-lookup"><span data-stu-id="59098-1711">MobSignal1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC38.png" width="32" height="32" alt="MobSignal2" /></td>
  <td><span data-ttu-id="59098-1712">EC38</span><span class="sxs-lookup"><span data-stu-id="59098-1712">EC38</span></span></td>
  <td><span data-ttu-id="59098-1713">MobSignal2</span><span class="sxs-lookup"><span data-stu-id="59098-1713">MobSignal2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC39.png" width="32" height="32" alt="MobSignal3" /></td>
  <td><span data-ttu-id="59098-1714">EC39</span><span class="sxs-lookup"><span data-stu-id="59098-1714">EC39</span></span></td>
  <td><span data-ttu-id="59098-1715">MobSignal3</span><span class="sxs-lookup"><span data-stu-id="59098-1715">MobSignal3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3A.png" width="32" height="32" alt="MobSignal4" /></td>
  <td><span data-ttu-id="59098-1716">EC3A</span><span class="sxs-lookup"><span data-stu-id="59098-1716">EC3A</span></span></td>
  <td><span data-ttu-id="59098-1717">MobSignal4</span><span class="sxs-lookup"><span data-stu-id="59098-1717">MobSignal4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3B.png" width="32" height="32" alt="MobSignal5" /></td>
  <td><span data-ttu-id="59098-1718">EC3B</span><span class="sxs-lookup"><span data-stu-id="59098-1718">EC3B</span></span></td>
  <td><span data-ttu-id="59098-1719">MobSignal5</span><span class="sxs-lookup"><span data-stu-id="59098-1719">MobSignal5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3C.png" width="32" height="32" alt="MobWifi1" /></td>
  <td><span data-ttu-id="59098-1720">EC3C</span><span class="sxs-lookup"><span data-stu-id="59098-1720">EC3C</span></span></td>
  <td><span data-ttu-id="59098-1721">MobWifi1</span><span class="sxs-lookup"><span data-stu-id="59098-1721">MobWifi1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3D.png" width="32" height="32" alt="MobWifi2" /></td>
  <td><span data-ttu-id="59098-1722">EC3D</span><span class="sxs-lookup"><span data-stu-id="59098-1722">EC3D</span></span></td>
  <td><span data-ttu-id="59098-1723">MobWifi2</span><span class="sxs-lookup"><span data-stu-id="59098-1723">MobWifi2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3E.png" width="32" height="32" alt="MobWifi3" /></td>
  <td><span data-ttu-id="59098-1724">EC3E</span><span class="sxs-lookup"><span data-stu-id="59098-1724">EC3E</span></span></td>
  <td><span data-ttu-id="59098-1725">MobWifi3</span><span class="sxs-lookup"><span data-stu-id="59098-1725">MobWifi3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC3F.png" width="32" height="32" alt="MobWifi4" /></td>
  <td><span data-ttu-id="59098-1726">EC3F</span><span class="sxs-lookup"><span data-stu-id="59098-1726">EC3F</span></span></td>
  <td><span data-ttu-id="59098-1727">MobWifi4</span><span class="sxs-lookup"><span data-stu-id="59098-1727">MobWifi4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC40.png" width="32" height="32" alt="MobAirplane" /></td>
  <td><span data-ttu-id="59098-1728">EC40</span><span class="sxs-lookup"><span data-stu-id="59098-1728">EC40</span></span></td>
  <td><span data-ttu-id="59098-1729">MobAirplane</span><span class="sxs-lookup"><span data-stu-id="59098-1729">MobAirplane</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC41.png" width="32" height="32" alt="MobBluetooth" /></td>
  <td><span data-ttu-id="59098-1730">EC41</span><span class="sxs-lookup"><span data-stu-id="59098-1730">EC41</span></span></td>
  <td><span data-ttu-id="59098-1731">MobBluetooth</span><span class="sxs-lookup"><span data-stu-id="59098-1731">MobBluetooth</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC42.png" width="32" height="32" alt="MobActionCenter" /></td>
  <td><span data-ttu-id="59098-1732">EC42</span><span class="sxs-lookup"><span data-stu-id="59098-1732">EC42</span></span></td>
  <td><span data-ttu-id="59098-1733">MobActionCenter</span><span class="sxs-lookup"><span data-stu-id="59098-1733">MobActionCenter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC43.png" width="32" height="32" alt="MobLocation" /></td>
  <td><span data-ttu-id="59098-1734">EC43</span><span class="sxs-lookup"><span data-stu-id="59098-1734">EC43</span></span></td>
  <td><span data-ttu-id="59098-1735">MobLocation</span><span class="sxs-lookup"><span data-stu-id="59098-1735">MobLocation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC44.png" width="32" height="32" alt="MobWifiHotspot" /></td>
  <td><span data-ttu-id="59098-1736">EC44</span><span class="sxs-lookup"><span data-stu-id="59098-1736">EC44</span></span></td>
  <td><span data-ttu-id="59098-1737">MobWifiHotspot</span><span class="sxs-lookup"><span data-stu-id="59098-1737">MobWifiHotspot</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC45.png" width="32" height="32" alt="LanguageJpn" /></td>
  <td><span data-ttu-id="59098-1738">EC45</span><span class="sxs-lookup"><span data-stu-id="59098-1738">EC45</span></span></td>
  <td><span data-ttu-id="59098-1739">LanguageJpn</span><span class="sxs-lookup"><span data-stu-id="59098-1739">LanguageJpn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC46.png" width="32" height="32" alt="MobQuietHours" /></td>
  <td><span data-ttu-id="59098-1740">EC46</span><span class="sxs-lookup"><span data-stu-id="59098-1740">EC46</span></span></td>
  <td><span data-ttu-id="59098-1741">MobQuietHours</span><span class="sxs-lookup"><span data-stu-id="59098-1741">MobQuietHours</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC47.png" width="32" height="32" alt="MobDrivingMode" /></td>
  <td><span data-ttu-id="59098-1742">EC47</span><span class="sxs-lookup"><span data-stu-id="59098-1742">EC47</span></span></td>
  <td><span data-ttu-id="59098-1743">MobDrivingMode</span><span class="sxs-lookup"><span data-stu-id="59098-1743">MobDrivingMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC48.png" width="32" height="32" alt="SpeedOff" /></td>
  <td><span data-ttu-id="59098-1744">EC48</span><span class="sxs-lookup"><span data-stu-id="59098-1744">EC48</span></span></td>
  <td><span data-ttu-id="59098-1745">SpeedOff</span><span class="sxs-lookup"><span data-stu-id="59098-1745">SpeedOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC49.png" width="32" height="32" alt="SpeedMedium" /></td>
  <td><span data-ttu-id="59098-1746">EC49</span><span class="sxs-lookup"><span data-stu-id="59098-1746">EC49</span></span></td>
  <td><span data-ttu-id="59098-1747">SpeedMedium</span><span class="sxs-lookup"><span data-stu-id="59098-1747">SpeedMedium</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC4A.png" width="32" height="32" alt="SpeedHigh" /></td>
  <td><span data-ttu-id="59098-1748">EC4A</span><span class="sxs-lookup"><span data-stu-id="59098-1748">EC4A</span></span></td>
  <td><span data-ttu-id="59098-1749">SpeedHigh</span><span class="sxs-lookup"><span data-stu-id="59098-1749">SpeedHigh</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC4E.png" width="32" height="32" alt="ThisPC" /></td>
  <td><span data-ttu-id="59098-1750">EC4E</span><span class="sxs-lookup"><span data-stu-id="59098-1750">EC4E</span></span></td>
  <td><span data-ttu-id="59098-1751">ThisPC</span><span class="sxs-lookup"><span data-stu-id="59098-1751">ThisPC</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC4F.png" width="32" height="32" alt="MusicNote" /></td>
  <td><span data-ttu-id="59098-1752">EC4F</span><span class="sxs-lookup"><span data-stu-id="59098-1752">EC4F</span></span></td>
  <td><span data-ttu-id="59098-1753">MusicNote</span><span class="sxs-lookup"><span data-stu-id="59098-1753">MusicNote</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC50.png" width="32" height="32" alt="FileExplorer" /></td>
  <td><span data-ttu-id="59098-1754">EC50</span><span class="sxs-lookup"><span data-stu-id="59098-1754">EC50</span></span></td>
  <td><span data-ttu-id="59098-1755">FileExplorer</span><span class="sxs-lookup"><span data-stu-id="59098-1755">FileExplorer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC51.png" width="32" height="32" alt="FileExplorerApp" /></td>
  <td><span data-ttu-id="59098-1756">EC51</span><span class="sxs-lookup"><span data-stu-id="59098-1756">EC51</span></span></td>
  <td><span data-ttu-id="59098-1757">FileExplorerApp</span><span class="sxs-lookup"><span data-stu-id="59098-1757">FileExplorerApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC52.png" width="32" height="32" alt="LeftArrowKeyTime0" /></td>
  <td><span data-ttu-id="59098-1758">EC52</span><span class="sxs-lookup"><span data-stu-id="59098-1758">EC52</span></span></td>
  <td><span data-ttu-id="59098-1759">LeftArrowKeyTime0</span><span class="sxs-lookup"><span data-stu-id="59098-1759">LeftArrowKeyTime0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC54.png" width="32" height="32" alt="MicOff" /></td>
  <td><span data-ttu-id="59098-1760">EC54</span><span class="sxs-lookup"><span data-stu-id="59098-1760">EC54</span></span></td>
  <td><span data-ttu-id="59098-1761">MicOff</span><span class="sxs-lookup"><span data-stu-id="59098-1761">MicOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC55.png" width="32" height="32" alt="MicSleep" /></td>
  <td><span data-ttu-id="59098-1762">EC55</span><span class="sxs-lookup"><span data-stu-id="59098-1762">EC55</span></span></td>
  <td><span data-ttu-id="59098-1763">MicSleep</span><span class="sxs-lookup"><span data-stu-id="59098-1763">MicSleep</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC56.png" width="32" height="32" alt="MicError" /></td>
  <td><span data-ttu-id="59098-1764">EC56</span><span class="sxs-lookup"><span data-stu-id="59098-1764">EC56</span></span></td>
  <td><span data-ttu-id="59098-1765">MicError</span><span class="sxs-lookup"><span data-stu-id="59098-1765">MicError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC57.png" width="32" height="32" alt="PlaybackRate1x" /></td>
  <td><span data-ttu-id="59098-1766">EC57</span><span class="sxs-lookup"><span data-stu-id="59098-1766">EC57</span></span></td>
  <td><span data-ttu-id="59098-1767">PlaybackRate1x</span><span class="sxs-lookup"><span data-stu-id="59098-1767">PlaybackRate1x</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC58.png" width="32" height="32" alt="PlaybackRateOther" /></td>
  <td><span data-ttu-id="59098-1768">EC58</span><span class="sxs-lookup"><span data-stu-id="59098-1768">EC58</span></span></td>
  <td><span data-ttu-id="59098-1769">PlaybackRateOther</span><span class="sxs-lookup"><span data-stu-id="59098-1769">PlaybackRateOther</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC59.png" width="32" height="32" alt="CashDrawer" /></td>
  <td><span data-ttu-id="59098-1770">EC59</span><span class="sxs-lookup"><span data-stu-id="59098-1770">EC59</span></span></td>
  <td><span data-ttu-id="59098-1771">CashDrawer</span><span class="sxs-lookup"><span data-stu-id="59098-1771">CashDrawer</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC5A.png" width="32" height="32" alt="BarcodeScanner" /></td>
  <td><span data-ttu-id="59098-1772">EC5A</span><span class="sxs-lookup"><span data-stu-id="59098-1772">EC5A</span></span></td>
  <td><span data-ttu-id="59098-1773">BarcodeScanner</span><span class="sxs-lookup"><span data-stu-id="59098-1773">BarcodeScanner</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC5B.png" width="32" height="32" alt="ReceiptPrinter" /></td>
  <td><span data-ttu-id="59098-1774">EC5B</span><span class="sxs-lookup"><span data-stu-id="59098-1774">EC5B</span></span></td>
  <td><span data-ttu-id="59098-1775">ReceiptPrinter</span><span class="sxs-lookup"><span data-stu-id="59098-1775">ReceiptPrinter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC5C.png" width="32" height="32" alt="MagStripeReader" /></td>
  <td><span data-ttu-id="59098-1776">EC5C</span><span class="sxs-lookup"><span data-stu-id="59098-1776">EC5C</span></span></td>
  <td><span data-ttu-id="59098-1777">MagStripeReader</span><span class="sxs-lookup"><span data-stu-id="59098-1777">MagStripeReader</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC61.png" width="32" height="32" alt="CompletedSolid" /></td>
  <td><span data-ttu-id="59098-1778">EC61</span><span class="sxs-lookup"><span data-stu-id="59098-1778">EC61</span></span></td>
  <td><span data-ttu-id="59098-1779">CompletedSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1779">CompletedSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC64.png" width="32" height="32" alt="CompanionApp" /></td>
  <td><span data-ttu-id="59098-1780">EC64</span><span class="sxs-lookup"><span data-stu-id="59098-1780">EC64</span></span></td>
  <td><span data-ttu-id="59098-1781">CompanionApp</span><span class="sxs-lookup"><span data-stu-id="59098-1781">CompanionApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC6D.png" width="32" height="32" alt="SwipeRevealArt" /></td>
  <td><span data-ttu-id="59098-1782">EC6D</span><span class="sxs-lookup"><span data-stu-id="59098-1782">EC6D</span></span></td>
  <td><span data-ttu-id="59098-1783">SwipeRevealArt</span><span class="sxs-lookup"><span data-stu-id="59098-1783">SwipeRevealArt</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC71.png" width="32" height="32" alt="MicOn" /></td>
  <td><span data-ttu-id="59098-1784">EC71</span><span class="sxs-lookup"><span data-stu-id="59098-1784">EC71</span></span></td>
  <td><span data-ttu-id="59098-1785">MicOn</span><span class="sxs-lookup"><span data-stu-id="59098-1785">MicOn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC72.png" width="32" height="32" alt="MicClipping" /></td>
  <td><span data-ttu-id="59098-1786">EC72</span><span class="sxs-lookup"><span data-stu-id="59098-1786">EC72</span></span></td>
  <td><span data-ttu-id="59098-1787">MicClipping</span><span class="sxs-lookup"><span data-stu-id="59098-1787">MicClipping</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC74.png" width="32" height="32" alt="TabletSelected" /></td>
  <td><span data-ttu-id="59098-1788">EC74</span><span class="sxs-lookup"><span data-stu-id="59098-1788">EC74</span></span></td>
  <td><span data-ttu-id="59098-1789">TabletSelected</span><span class="sxs-lookup"><span data-stu-id="59098-1789">TabletSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC75.png" width="32" height="32" alt="MobileSelected" /></td>
  <td><span data-ttu-id="59098-1790">EC75</span><span class="sxs-lookup"><span data-stu-id="59098-1790">EC75</span></span></td>
  <td><span data-ttu-id="59098-1791">MobileSelected</span><span class="sxs-lookup"><span data-stu-id="59098-1791">MobileSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC76.png" width="32" height="32" alt="LaptopSelected" /></td>
  <td><span data-ttu-id="59098-1792">EC76</span><span class="sxs-lookup"><span data-stu-id="59098-1792">EC76</span></span></td>
  <td><span data-ttu-id="59098-1793">LaptopSelected</span><span class="sxs-lookup"><span data-stu-id="59098-1793">LaptopSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC77.png" width="32" height="32" alt="TVMonitorSelected" /></td>
  <td><span data-ttu-id="59098-1794">EC77</span><span class="sxs-lookup"><span data-stu-id="59098-1794">EC77</span></span></td>
  <td><span data-ttu-id="59098-1795">TVMonitorSelected</span><span class="sxs-lookup"><span data-stu-id="59098-1795">TVMonitorSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC7A.png" width="32" height="32" alt="DeveloperTools" /></td>
  <td><span data-ttu-id="59098-1796">EC7A</span><span class="sxs-lookup"><span data-stu-id="59098-1796">EC7A</span></span></td>
  <td><span data-ttu-id="59098-1797">DeveloperTools</span><span class="sxs-lookup"><span data-stu-id="59098-1797">DeveloperTools</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC7E.png" width="32" height="32" alt="MobCallForwarding" /></td>
  <td><span data-ttu-id="59098-1798">EC7E</span><span class="sxs-lookup"><span data-stu-id="59098-1798">EC7E</span></span></td>
  <td><span data-ttu-id="59098-1799">MobCallForwarding</span><span class="sxs-lookup"><span data-stu-id="59098-1799">MobCallForwarding</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC7F.png" width="32" height="32" alt="MobCallForwardingMirrored" /></td>
  <td><span data-ttu-id="59098-1800">EC7F</span><span class="sxs-lookup"><span data-stu-id="59098-1800">EC7F</span></span></td>
  <td><span data-ttu-id="59098-1801">MobCallForwardingMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1801">MobCallForwardingMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC80.png" width="32" height="32" alt="BodyCam" /></td>
  <td><span data-ttu-id="59098-1802">EC80</span><span class="sxs-lookup"><span data-stu-id="59098-1802">EC80</span></span></td>
  <td><span data-ttu-id="59098-1803">BodyCam</span><span class="sxs-lookup"><span data-stu-id="59098-1803">BodyCam</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC81.png" width="32" height="32" alt="PoliceCar" /></td>
  <td><span data-ttu-id="59098-1804">EC81</span><span class="sxs-lookup"><span data-stu-id="59098-1804">EC81</span></span></td>
  <td><span data-ttu-id="59098-1805">PoliceCar</span><span class="sxs-lookup"><span data-stu-id="59098-1805">PoliceCar</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC87.png" width="32" height="32" alt="Draw" /></td>
  <td><span data-ttu-id="59098-1806">EC87</span><span class="sxs-lookup"><span data-stu-id="59098-1806">EC87</span></span></td>
  <td><span data-ttu-id="59098-1807">Draw</span><span class="sxs-lookup"><span data-stu-id="59098-1807">Draw</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC88.png" width="32" height="32" alt="DrawSolid" /></td>
  <td><span data-ttu-id="59098-1808">EC88</span><span class="sxs-lookup"><span data-stu-id="59098-1808">EC88</span></span></td>
  <td><span data-ttu-id="59098-1809">DrawSolid</span><span class="sxs-lookup"><span data-stu-id="59098-1809">DrawSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC8A.png" width="32" height="32" alt="LowerBrightness" /></td>
  <td><span data-ttu-id="59098-1810">EC8A</span><span class="sxs-lookup"><span data-stu-id="59098-1810">EC8A</span></span></td>
  <td><span data-ttu-id="59098-1811">LowerBrightness</span><span class="sxs-lookup"><span data-stu-id="59098-1811">LowerBrightness</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC8F.png" width="32" height="32" alt="ScrollUpDown" /></td>
  <td><span data-ttu-id="59098-1812">EC8F</span><span class="sxs-lookup"><span data-stu-id="59098-1812">EC8F</span></span></td>
  <td><span data-ttu-id="59098-1813">ScrollUpDown</span><span class="sxs-lookup"><span data-stu-id="59098-1813">ScrollUpDown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EC92.png" width="32" height="32" alt="DateTime" /></td>
  <td><span data-ttu-id="59098-1814">EC92</span><span class="sxs-lookup"><span data-stu-id="59098-1814">EC92</span></span></td>
  <td><span data-ttu-id="59098-1815">DateTime</span><span class="sxs-lookup"><span data-stu-id="59098-1815">DateTime</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECA5.png" width="32" height="32" alt="Tiles" /></td>
  <td><span data-ttu-id="59098-1816">ECA5</span><span class="sxs-lookup"><span data-stu-id="59098-1816">ECA5</span></span></td>
  <td><span data-ttu-id="59098-1817">タイル</span><span class="sxs-lookup"><span data-stu-id="59098-1817">Tiles</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECA7.png" width="32" height="32" alt="PartyLeader" /></td>
  <td><span data-ttu-id="59098-1818">ECA7</span><span class="sxs-lookup"><span data-stu-id="59098-1818">ECA7</span></span></td>
  <td><span data-ttu-id="59098-1819">PartyLeader</span><span class="sxs-lookup"><span data-stu-id="59098-1819">PartyLeader</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECAA.png" width="32" height="32" alt="AppIconDefault" /></td>
  <td><span data-ttu-id="59098-1820">ECAA</span><span class="sxs-lookup"><span data-stu-id="59098-1820">ECAA</span></span></td>
  <td><span data-ttu-id="59098-1821">AppIconDefault</span><span class="sxs-lookup"><span data-stu-id="59098-1821">AppIconDefault</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECAD.png" width="32" height="32" alt="Calories" /></td>
  <td><span data-ttu-id="59098-1822">ECAD</span><span class="sxs-lookup"><span data-stu-id="59098-1822">ECAD</span></span></td>
  <td><span data-ttu-id="59098-1823">カロリー</span><span class="sxs-lookup"><span data-stu-id="59098-1823">Calories</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECB9.png" width="32" height="32" alt="BandBattery0" /></td>
  <td><span data-ttu-id="59098-1824">ECB9</span><span class="sxs-lookup"><span data-stu-id="59098-1824">ECB9</span></span></td>
  <td><span data-ttu-id="59098-1825">BandBattery0</span><span class="sxs-lookup"><span data-stu-id="59098-1825">BandBattery0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBA.png" width="32" height="32" alt="BandBattery1" /></td>
  <td><span data-ttu-id="59098-1826">ECBA</span><span class="sxs-lookup"><span data-stu-id="59098-1826">ECBA</span></span></td>
  <td><span data-ttu-id="59098-1827">BandBattery1</span><span class="sxs-lookup"><span data-stu-id="59098-1827">BandBattery1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBB.png" width="32" height="32" alt="BandBattery2" /></td>
  <td><span data-ttu-id="59098-1828">ECBB</span><span class="sxs-lookup"><span data-stu-id="59098-1828">ECBB</span></span></td>
  <td><span data-ttu-id="59098-1829">BandBattery2</span><span class="sxs-lookup"><span data-stu-id="59098-1829">BandBattery2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBC.png" width="32" height="32" alt="BandBattery3" /></td>
  <td><span data-ttu-id="59098-1830">ECBC</span><span class="sxs-lookup"><span data-stu-id="59098-1830">ECBC</span></span></td>
  <td><span data-ttu-id="59098-1831">BandBattery3</span><span class="sxs-lookup"><span data-stu-id="59098-1831">BandBattery3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBD.png" width="32" height="32" alt="BandBattery4" /></td>
  <td><span data-ttu-id="59098-1832">ECBD</span><span class="sxs-lookup"><span data-stu-id="59098-1832">ECBD</span></span></td>
  <td><span data-ttu-id="59098-1833">BandBattery4</span><span class="sxs-lookup"><span data-stu-id="59098-1833">BandBattery4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBE.png" width="32" height="32" alt="BandBattery5" /></td>
  <td><span data-ttu-id="59098-1834">ECBE</span><span class="sxs-lookup"><span data-stu-id="59098-1834">ECBE</span></span></td>
  <td><span data-ttu-id="59098-1835">BandBattery5</span><span class="sxs-lookup"><span data-stu-id="59098-1835">BandBattery5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECBF.png" width="32" height="32" alt="BandBattery6" /></td>
  <td><span data-ttu-id="59098-1836">ECBF</span><span class="sxs-lookup"><span data-stu-id="59098-1836">ECBF</span></span></td>
  <td><span data-ttu-id="59098-1837">BandBattery6</span><span class="sxs-lookup"><span data-stu-id="59098-1837">BandBattery6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC4.png" width="32" height="32" alt="AddSurfaceHub" /></td>
  <td><span data-ttu-id="59098-1838">ECC4</span><span class="sxs-lookup"><span data-stu-id="59098-1838">ECC4</span></span></td>
  <td><span data-ttu-id="59098-1839">AddSurfaceHub</span><span class="sxs-lookup"><span data-stu-id="59098-1839">AddSurfaceHub</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC5.png" width="32" height="32" alt="DevUpdate" /></td>
  <td><span data-ttu-id="59098-1840">ECC5</span><span class="sxs-lookup"><span data-stu-id="59098-1840">ECC5</span></span></td>
  <td><span data-ttu-id="59098-1841">DevUpdate</span><span class="sxs-lookup"><span data-stu-id="59098-1841">DevUpdate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC6.png" width="32" height="32" alt="Unit" /></td>
  <td><span data-ttu-id="59098-1842">ECC6</span><span class="sxs-lookup"><span data-stu-id="59098-1842">ECC6</span></span></td>
  <td><span data-ttu-id="59098-1843">Unit</span><span class="sxs-lookup"><span data-stu-id="59098-1843">Unit</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC8.png" width="32" height="32" alt="AddTo" /></td>
  <td><span data-ttu-id="59098-1844">ECC8</span><span class="sxs-lookup"><span data-stu-id="59098-1844">ECC8</span></span></td>
  <td><span data-ttu-id="59098-1845">AddTo</span><span class="sxs-lookup"><span data-stu-id="59098-1845">AddTo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECC9.png" width="32" height="32" alt="RemoveFrom" /></td>
  <td><span data-ttu-id="59098-1846">ECC9</span><span class="sxs-lookup"><span data-stu-id="59098-1846">ECC9</span></span></td>
  <td><span data-ttu-id="59098-1847">RemoveFrom</span><span class="sxs-lookup"><span data-stu-id="59098-1847">RemoveFrom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECCA.png" width="32" height="32" alt="RadioBtnOff" /></td>
  <td><span data-ttu-id="59098-1848">ECCA</span><span class="sxs-lookup"><span data-stu-id="59098-1848">ECCA</span></span></td>
  <td><span data-ttu-id="59098-1849">RadioBtnOff</span><span class="sxs-lookup"><span data-stu-id="59098-1849">RadioBtnOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECCB.png" width="32" height="32" alt="RadioBtnOn" /></td>
  <td><span data-ttu-id="59098-1850">ECCB</span><span class="sxs-lookup"><span data-stu-id="59098-1850">ECCB</span></span></td>
  <td><span data-ttu-id="59098-1851">RadioBtnOn</span><span class="sxs-lookup"><span data-stu-id="59098-1851">RadioBtnOn</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECCC.png" width="32" height="32" alt="RadioBullet2" /></td>
  <td><span data-ttu-id="59098-1852">ECCC</span><span class="sxs-lookup"><span data-stu-id="59098-1852">ECCC</span></span></td>
  <td><span data-ttu-id="59098-1853">RadioBullet2</span><span class="sxs-lookup"><span data-stu-id="59098-1853">RadioBullet2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECCD.png" width="32" height="32" alt="ExploreContent" /></td>
  <td><span data-ttu-id="59098-1854">ECCD</span><span class="sxs-lookup"><span data-stu-id="59098-1854">ECCD</span></span></td>
  <td><span data-ttu-id="59098-1855">ExploreContent</span><span class="sxs-lookup"><span data-stu-id="59098-1855">ExploreContent</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECE7.png" width="32" height="32" alt="ScrollMode" /></td>
  <td><span data-ttu-id="59098-1856">ECE7</span><span class="sxs-lookup"><span data-stu-id="59098-1856">ECE7</span></span></td>
  <td><span data-ttu-id="59098-1857">ScrollMode</span><span class="sxs-lookup"><span data-stu-id="59098-1857">ScrollMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECE8.png" width="32" height="32" alt="ZoomMode" /></td>
  <td><span data-ttu-id="59098-1858">ECE8</span><span class="sxs-lookup"><span data-stu-id="59098-1858">ECE8</span></span></td>
  <td><span data-ttu-id="59098-1859">ZoomMode</span><span class="sxs-lookup"><span data-stu-id="59098-1859">ZoomMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECE9.png" width="32" height="32" alt="PanMode" /></td>
  <td><span data-ttu-id="59098-1860">ECE9</span><span class="sxs-lookup"><span data-stu-id="59098-1860">ECE9</span></span></td>
  <td><span data-ttu-id="59098-1861">PanMode</span><span class="sxs-lookup"><span data-stu-id="59098-1861">PanMode</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECF0.png" width="32" height="32" alt="WiredUSB  " /></td>
  <td><span data-ttu-id="59098-1862">ECF0</span><span class="sxs-lookup"><span data-stu-id="59098-1862">ECF0</span></span></td>
  <td><span data-ttu-id="59098-1863">WiredUSB</span><span class="sxs-lookup"><span data-stu-id="59098-1863">WiredUSB</span></span>  </td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECF1.png" width="32" height="32" alt="WirelessUSB" /></td>
  <td><span data-ttu-id="59098-1864">ECF1</span><span class="sxs-lookup"><span data-stu-id="59098-1864">ECF1</span></span></td>
  <td><span data-ttu-id="59098-1865">WirelessUSB</span><span class="sxs-lookup"><span data-stu-id="59098-1865">WirelessUSB</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ECF3.png" width="32" height="32" alt="USBSafeConnect" /></td>
  <td><span data-ttu-id="59098-1866">ECF3</span><span class="sxs-lookup"><span data-stu-id="59098-1866">ECF3</span></span></td>
  <td><span data-ttu-id="59098-1867">USBSafeConnect</span><span class="sxs-lookup"><span data-stu-id="59098-1867">USBSafeConnect</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED0C.png" width="32" height="32" alt="ActionCenterNotificationMirrored" /></td>
  <td><span data-ttu-id="59098-1868">ED0C</span><span class="sxs-lookup"><span data-stu-id="59098-1868">ED0C</span></span></td>
  <td><span data-ttu-id="59098-1869">ActionCenterNotificationMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1869">ActionCenterNotificationMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED0D.png" width="32" height="32" alt="ActionCenterMirrored" /></td>
  <td><span data-ttu-id="59098-1870">ED0D</span><span class="sxs-lookup"><span data-stu-id="59098-1870">ED0D</span></span></td>
  <td><span data-ttu-id="59098-1871">ActionCenterMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1871">ActionCenterMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED10.png" width="32" height="32" alt="ResetDevice" /></td>
  <td><span data-ttu-id="59098-1872">ED10</span><span class="sxs-lookup"><span data-stu-id="59098-1872">ED10</span></span></td>
  <td><span data-ttu-id="59098-1873">ResetDevice</span><span class="sxs-lookup"><span data-stu-id="59098-1873">ResetDevice</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED15.png" width="32" height="32" alt="Feedback" /></td>
  <td><span data-ttu-id="59098-1874">ED15</span><span class="sxs-lookup"><span data-stu-id="59098-1874">ED15</span></span></td>
  <td><span data-ttu-id="59098-1875">Feedback</span><span class="sxs-lookup"><span data-stu-id="59098-1875">Feedback</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED1E.png" width="32" height="32" alt="Subtitles" /></td>
  <td><span data-ttu-id="59098-1876">ED1E</span><span class="sxs-lookup"><span data-stu-id="59098-1876">ED1E</span></span></td>
  <td><span data-ttu-id="59098-1877">Subtitles</span><span class="sxs-lookup"><span data-stu-id="59098-1877">Subtitles</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED1F.png" width="32" height="32" alt="SubtitlesAudio" /></td>
  <td><span data-ttu-id="59098-1878">ED1F</span><span class="sxs-lookup"><span data-stu-id="59098-1878">ED1F</span></span></td>
  <td><span data-ttu-id="59098-1879">SubtitlesAudio</span><span class="sxs-lookup"><span data-stu-id="59098-1879">SubtitlesAudio</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED25.png" width="32" height="32" alt="OpenFolderHorizontal" /></td>
  <td><span data-ttu-id="59098-1880">ED25</span><span class="sxs-lookup"><span data-stu-id="59098-1880">ED25</span></span></td>
  <td><span data-ttu-id="59098-1881">OpenFolderHorizontal</span><span class="sxs-lookup"><span data-stu-id="59098-1881">OpenFolderHorizontal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED28.png" width="32" height="32" alt="CalendarMirrored" /></td>
  <td><span data-ttu-id="59098-1882">ED28</span><span class="sxs-lookup"><span data-stu-id="59098-1882">ED28</span></span></td>
  <td><span data-ttu-id="59098-1883">CalendarMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1883">CalendarMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2A.png" width="32" height="32" alt="MobeSIM" /></td>
  <td><span data-ttu-id="59098-1884">ED2A</span><span class="sxs-lookup"><span data-stu-id="59098-1884">ED2A</span></span></td>
  <td><span data-ttu-id="59098-1885">MobeSIM</span><span class="sxs-lookup"><span data-stu-id="59098-1885">MobeSIM</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2B.png" width="32" height="32" alt="MobeSIMNoProfile" /></td>
  <td><span data-ttu-id="59098-1886">ED2B</span><span class="sxs-lookup"><span data-stu-id="59098-1886">ED2B</span></span></td>
  <td><span data-ttu-id="59098-1887">MobeSIMNoProfile</span><span class="sxs-lookup"><span data-stu-id="59098-1887">MobeSIMNoProfile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2C.png" width="32" height="32" alt="MobeSIMLocked" /></td>
  <td><span data-ttu-id="59098-1888">ED2C</span><span class="sxs-lookup"><span data-stu-id="59098-1888">ED2C</span></span></td>
  <td><span data-ttu-id="59098-1889">MobeSIMLocked</span><span class="sxs-lookup"><span data-stu-id="59098-1889">MobeSIMLocked</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2D.png" width="32" height="32" alt="MobeSIMBusy" /></td>
  <td><span data-ttu-id="59098-1890">ED2D</span><span class="sxs-lookup"><span data-stu-id="59098-1890">ED2D</span></span></td>
  <td><span data-ttu-id="59098-1891">MobeSIMBusy</span><span class="sxs-lookup"><span data-stu-id="59098-1891">MobeSIMBusy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2E.png" width="32" height="32" alt="SignalError" /></td>
  <td><span data-ttu-id="59098-1892">ED2E</span><span class="sxs-lookup"><span data-stu-id="59098-1892">ED2E</span></span></td>
  <td><span data-ttu-id="59098-1893">SignalError</span><span class="sxs-lookup"><span data-stu-id="59098-1893">SignalError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED2F.png" width="32" height="32" alt="StreamingEnterprise" /></td>
  <td><span data-ttu-id="59098-1894">ED2F</span><span class="sxs-lookup"><span data-stu-id="59098-1894">ED2F</span></span></td>
  <td><span data-ttu-id="59098-1895">StreamingEnterprise</span><span class="sxs-lookup"><span data-stu-id="59098-1895">StreamingEnterprise</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED30.png" width="32" height="32" alt="Headphone0" /></td>
  <td><span data-ttu-id="59098-1896">ED30</span><span class="sxs-lookup"><span data-stu-id="59098-1896">ED30</span></span></td>
  <td><span data-ttu-id="59098-1897">Headphone0</span><span class="sxs-lookup"><span data-stu-id="59098-1897">Headphone0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED31.png" width="32" height="32" alt="Headphone1" /></td>
  <td><span data-ttu-id="59098-1898">ED31</span><span class="sxs-lookup"><span data-stu-id="59098-1898">ED31</span></span></td>
  <td><span data-ttu-id="59098-1899">Headphone1</span><span class="sxs-lookup"><span data-stu-id="59098-1899">Headphone1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED32.png" width="32" height="32" alt="Headphone2" /></td>
  <td><span data-ttu-id="59098-1900">ED32</span><span class="sxs-lookup"><span data-stu-id="59098-1900">ED32</span></span></td>
  <td><span data-ttu-id="59098-1901">Headphone2</span><span class="sxs-lookup"><span data-stu-id="59098-1901">Headphone2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED33.png" width="32" height="32" alt="Headphone3" /></td>
  <td><span data-ttu-id="59098-1902">ED33</span><span class="sxs-lookup"><span data-stu-id="59098-1902">ED33</span></span></td>
  <td><span data-ttu-id="59098-1903">Headphone3</span><span class="sxs-lookup"><span data-stu-id="59098-1903">Headphone3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED35.png" width="32" height="32" alt="Apps" /></td>
  <td><span data-ttu-id="59098-1904">ED35</span><span class="sxs-lookup"><span data-stu-id="59098-1904">ED35</span></span></td>
  <td><span data-ttu-id="59098-1905">アプリ</span><span class="sxs-lookup"><span data-stu-id="59098-1905">Apps</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED39.png" width="32" height="32" alt="KeyboardBrightness" /></td>
  <td><span data-ttu-id="59098-1906">ED39</span><span class="sxs-lookup"><span data-stu-id="59098-1906">ED39</span></span></td>
  <td><span data-ttu-id="59098-1907">KeyboardBrightness</span><span class="sxs-lookup"><span data-stu-id="59098-1907">KeyboardBrightness</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED3A.png" width="32" height="32" alt="KeyboardLowerBrightness" /></td>
  <td><span data-ttu-id="59098-1908">ED3A</span><span class="sxs-lookup"><span data-stu-id="59098-1908">ED3A</span></span></td>
  <td><span data-ttu-id="59098-1909">KeyboardLowerBrightness</span><span class="sxs-lookup"><span data-stu-id="59098-1909">KeyboardLowerBrightness</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED3C.png" width="32" height="32" alt="SkipBack10" /></td>
  <td><span data-ttu-id="59098-1910">ED3C</span><span class="sxs-lookup"><span data-stu-id="59098-1910">ED3C</span></span></td>
  <td><span data-ttu-id="59098-1911">SkipBack10</span><span class="sxs-lookup"><span data-stu-id="59098-1911">SkipBack10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED3D.png" width="32" height="32" alt="SkipForward30 " /></td>
  <td><span data-ttu-id="59098-1912">ED3D</span><span class="sxs-lookup"><span data-stu-id="59098-1912">ED3D</span></span></td>
  <td><span data-ttu-id="59098-1913">SkipForward30</span><span class="sxs-lookup"><span data-stu-id="59098-1913">SkipForward30</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED41.png" width="32" height="32" alt="TreeFolderFolder" /></td>
  <td><span data-ttu-id="59098-1914">ED41</span><span class="sxs-lookup"><span data-stu-id="59098-1914">ED41</span></span></td>
  <td><span data-ttu-id="59098-1915">TreeFolderFolder</span><span class="sxs-lookup"><span data-stu-id="59098-1915">TreeFolderFolder</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED42.png" width="32" height="32" alt="TreeFolderFolderFill" /></td>
  <td><span data-ttu-id="59098-1916">ED42</span><span class="sxs-lookup"><span data-stu-id="59098-1916">ED42</span></span></td>
  <td><span data-ttu-id="59098-1917">TreeFolderFolderFill</span><span class="sxs-lookup"><span data-stu-id="59098-1917">TreeFolderFolderFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED43.png" width="32" height="32" alt="TreeFolderFolderOpen" /></td>
  <td><span data-ttu-id="59098-1918">ED43</span><span class="sxs-lookup"><span data-stu-id="59098-1918">ED43</span></span></td>
  <td><span data-ttu-id="59098-1919">TreeFolderFolderOpen</span><span class="sxs-lookup"><span data-stu-id="59098-1919">TreeFolderFolderOpen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED44.png" width="32" height="32" alt="TreeFolderFolderOpenFill" /></td>
  <td><span data-ttu-id="59098-1920">ED44</span><span class="sxs-lookup"><span data-stu-id="59098-1920">ED44</span></span></td>
  <td><span data-ttu-id="59098-1921">TreeFolderFolderOpenFill</span><span class="sxs-lookup"><span data-stu-id="59098-1921">TreeFolderFolderOpenFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED47.png" width="32" height="32" alt="MultimediaDMP" /></td>
  <td><span data-ttu-id="59098-1922">ED47</span><span class="sxs-lookup"><span data-stu-id="59098-1922">ED47</span></span></td>
  <td><span data-ttu-id="59098-1923">MultimediaDMP</span><span class="sxs-lookup"><span data-stu-id="59098-1923">MultimediaDMP</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED4C.png" width="32" height="32" alt="KeyboardOneHanded" /></td>
  <td><span data-ttu-id="59098-1924">ED4C</span><span class="sxs-lookup"><span data-stu-id="59098-1924">ED4C</span></span></td>
  <td><span data-ttu-id="59098-1925">KeyboardOneHanded</span><span class="sxs-lookup"><span data-stu-id="59098-1925">KeyboardOneHanded</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED4D.png" width="32" height="32" alt="Narrator" /></td>
  <td><span data-ttu-id="59098-1926">ED4D</span><span class="sxs-lookup"><span data-stu-id="59098-1926">ED4D</span></span></td>
  <td><span data-ttu-id="59098-1927">Narrator</span><span class="sxs-lookup"><span data-stu-id="59098-1927">Narrator</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED53.png" width="32" height="32" alt="EmojiTabPeople" /></td>
  <td><span data-ttu-id="59098-1928">ED53</span><span class="sxs-lookup"><span data-stu-id="59098-1928">ED53</span></span></td>
  <td><span data-ttu-id="59098-1929">EmojiTabPeople</span><span class="sxs-lookup"><span data-stu-id="59098-1929">EmojiTabPeople</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED54.png" width="32" height="32" alt="EmojiTabSmilesAnimals" /></td>
  <td><span data-ttu-id="59098-1930">ED54</span><span class="sxs-lookup"><span data-stu-id="59098-1930">ED54</span></span></td>
  <td><span data-ttu-id="59098-1931">EmojiTabSmilesAnimals</span><span class="sxs-lookup"><span data-stu-id="59098-1931">EmojiTabSmilesAnimals</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED55.png" width="32" height="32" alt="EmojiTabCelebrationObjects" /></td>
  <td><span data-ttu-id="59098-1932">ED55</span><span class="sxs-lookup"><span data-stu-id="59098-1932">ED55</span></span></td>
  <td><span data-ttu-id="59098-1933">EmojiTabCelebrationObjects</span><span class="sxs-lookup"><span data-stu-id="59098-1933">EmojiTabCelebrationObjects</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED56.png" width="32" height="32" alt="EmojiTabFoodPlants" /></td>
  <td><span data-ttu-id="59098-1934">ED56</span><span class="sxs-lookup"><span data-stu-id="59098-1934">ED56</span></span></td>
  <td><span data-ttu-id="59098-1935">EmojiTabFoodPlants</span><span class="sxs-lookup"><span data-stu-id="59098-1935">EmojiTabFoodPlants</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED57.png" width="32" height="32" alt="EmojiTabTransitPlaces" /></td>
  <td><span data-ttu-id="59098-1936">ED57</span><span class="sxs-lookup"><span data-stu-id="59098-1936">ED57</span></span></td>
  <td><span data-ttu-id="59098-1937">EmojiTabTransitPlaces</span><span class="sxs-lookup"><span data-stu-id="59098-1937">EmojiTabTransitPlaces</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED58.png" width="32" height="32" alt="EmojiTabSymbols" /></td>
  <td><span data-ttu-id="59098-1938">ED58</span><span class="sxs-lookup"><span data-stu-id="59098-1938">ED58</span></span></td>
  <td><span data-ttu-id="59098-1939">EmojiTabSymbols</span><span class="sxs-lookup"><span data-stu-id="59098-1939">EmojiTabSymbols</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED59.png" width="32" height="32" alt="EmojiTabTextSmiles" /></td>
  <td><span data-ttu-id="59098-1940">ED59</span><span class="sxs-lookup"><span data-stu-id="59098-1940">ED59</span></span></td>
  <td><span data-ttu-id="59098-1941">EmojiTabTextSmiles</span><span class="sxs-lookup"><span data-stu-id="59098-1941">EmojiTabTextSmiles</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5A.png" width="32" height="32" alt="EmojiTabFavorites" /></td>
  <td><span data-ttu-id="59098-1942">ED5A</span><span class="sxs-lookup"><span data-stu-id="59098-1942">ED5A</span></span></td>
  <td><span data-ttu-id="59098-1943">EmojiTabFavorites</span><span class="sxs-lookup"><span data-stu-id="59098-1943">EmojiTabFavorites</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5B.png" width="32" height="32" alt="EmojiSwatch" /></td>
  <td><span data-ttu-id="59098-1944">ED5B</span><span class="sxs-lookup"><span data-stu-id="59098-1944">ED5B</span></span></td>
  <td><span data-ttu-id="59098-1945">EmojiSwatch</span><span class="sxs-lookup"><span data-stu-id="59098-1945">EmojiSwatch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5C.png" width="32" height="32" alt="ConnectApp" /></td>
  <td><span data-ttu-id="59098-1946">ED5C</span><span class="sxs-lookup"><span data-stu-id="59098-1946">ED5C</span></span></td>
  <td><span data-ttu-id="59098-1947">ConnectApp</span><span class="sxs-lookup"><span data-stu-id="59098-1947">ConnectApp</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5D.png" width="32" height="32" alt="CompanionDeviceFramework" /></td>
  <td><span data-ttu-id="59098-1948">ED5D</span><span class="sxs-lookup"><span data-stu-id="59098-1948">ED5D</span></span></td>
  <td><span data-ttu-id="59098-1949">CompanionDeviceFramework</span><span class="sxs-lookup"><span data-stu-id="59098-1949">CompanionDeviceFramework</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5E.png" width="32" height="32" alt="Ruler" /></td>
  <td><span data-ttu-id="59098-1950">ED5E</span><span class="sxs-lookup"><span data-stu-id="59098-1950">ED5E</span></span></td>
  <td><span data-ttu-id="59098-1951">Ruler</span><span class="sxs-lookup"><span data-stu-id="59098-1951">Ruler</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED5F.png" width="32" height="32" alt="FingerInking" /></td>
  <td><span data-ttu-id="59098-1952">ED5F</span><span class="sxs-lookup"><span data-stu-id="59098-1952">ED5F</span></span></td>
  <td><span data-ttu-id="59098-1953">FingerInking</span><span class="sxs-lookup"><span data-stu-id="59098-1953">FingerInking</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED60.png" width="32" height="32" alt="StrokeErase" /></td>
  <td><span data-ttu-id="59098-1954">ED60</span><span class="sxs-lookup"><span data-stu-id="59098-1954">ED60</span></span></td>
  <td><span data-ttu-id="59098-1955">StrokeErase</span><span class="sxs-lookup"><span data-stu-id="59098-1955">StrokeErase</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED61.png" width="32" height="32" alt="PointErase" /></td>
  <td><span data-ttu-id="59098-1956">ED61</span><span class="sxs-lookup"><span data-stu-id="59098-1956">ED61</span></span></td>
  <td><span data-ttu-id="59098-1957">PointErase</span><span class="sxs-lookup"><span data-stu-id="59098-1957">PointErase</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED62.png" width="32" height="32" alt="ClearAllInk" /></td>
  <td><span data-ttu-id="59098-1958">ED62</span><span class="sxs-lookup"><span data-stu-id="59098-1958">ED62</span></span></td>
  <td><span data-ttu-id="59098-1959">ClearAllInk</span><span class="sxs-lookup"><span data-stu-id="59098-1959">ClearAllInk</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED63.png" width="32" height="32" alt="Pencil" /></td>
  <td><span data-ttu-id="59098-1960">ED63</span><span class="sxs-lookup"><span data-stu-id="59098-1960">ED63</span></span></td>
  <td><span data-ttu-id="59098-1961">Pencil</span><span class="sxs-lookup"><span data-stu-id="59098-1961">Pencil</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED64.png" width="32" height="32" alt="Marker" /></td>
  <td><span data-ttu-id="59098-1962">ED64</span><span class="sxs-lookup"><span data-stu-id="59098-1962">ED64</span></span></td>
  <td><span data-ttu-id="59098-1963">Marker</span><span class="sxs-lookup"><span data-stu-id="59098-1963">Marker</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED65.png" width="32" height="32" alt="InkingCaret" /></td>
  <td><span data-ttu-id="59098-1964">ED65</span><span class="sxs-lookup"><span data-stu-id="59098-1964">ED65</span></span></td>
  <td><span data-ttu-id="59098-1965">InkingCaret</span><span class="sxs-lookup"><span data-stu-id="59098-1965">InkingCaret</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED66.png" width="32" height="32" alt="InkingColorOutline" /></td>
  <td><span data-ttu-id="59098-1966">ED66</span><span class="sxs-lookup"><span data-stu-id="59098-1966">ED66</span></span></td>
  <td><span data-ttu-id="59098-1967">InkingColorOutline</span><span class="sxs-lookup"><span data-stu-id="59098-1967">InkingColorOutline</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/ED67.png" width="32" height="32" alt="InkingColorFill" /></td>
  <td><span data-ttu-id="59098-1968">ED67</span><span class="sxs-lookup"><span data-stu-id="59098-1968">ED67</span></span></td>
  <td><span data-ttu-id="59098-1969">InkingColorFill</span><span class="sxs-lookup"><span data-stu-id="59098-1969">InkingColorFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA2.png" width="32" height="32" alt="HardDrive" /></td>
  <td><span data-ttu-id="59098-1970">EDA2</span><span class="sxs-lookup"><span data-stu-id="59098-1970">EDA2</span></span></td>
  <td><span data-ttu-id="59098-1971">HardDrive</span><span class="sxs-lookup"><span data-stu-id="59098-1971">HardDrive</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA3.png" width="32" height="32" alt="NetworkAdapter" /></td>
  <td><span data-ttu-id="59098-1972">EDA3</span><span class="sxs-lookup"><span data-stu-id="59098-1972">EDA3</span></span></td>
  <td><span data-ttu-id="59098-1973">NetworkAdapter</span><span class="sxs-lookup"><span data-stu-id="59098-1973">NetworkAdapter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA4.png" width="32" height="32" alt="Touchscreen" /></td>
  <td><span data-ttu-id="59098-1974">EDA4</span><span class="sxs-lookup"><span data-stu-id="59098-1974">EDA4</span></span></td>
  <td><span data-ttu-id="59098-1975">Touchscreen</span><span class="sxs-lookup"><span data-stu-id="59098-1975">Touchscreen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA5.png" width="32" height="32" alt="NetworkPrinter" /></td>
  <td><span data-ttu-id="59098-1976">EDA5</span><span class="sxs-lookup"><span data-stu-id="59098-1976">EDA5</span></span></td>
  <td><span data-ttu-id="59098-1977">NetworkPrinter</span><span class="sxs-lookup"><span data-stu-id="59098-1977">NetworkPrinter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA6.png" width="32" height="32" alt="CloudPrinter" /></td>
  <td><span data-ttu-id="59098-1978">EDA6</span><span class="sxs-lookup"><span data-stu-id="59098-1978">EDA6</span></span></td>
  <td><span data-ttu-id="59098-1979">CloudPrinter</span><span class="sxs-lookup"><span data-stu-id="59098-1979">CloudPrinter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA7.png" width="32" height="32" alt="KeyboardShortcut" /></td>
  <td><span data-ttu-id="59098-1980">EDA7</span><span class="sxs-lookup"><span data-stu-id="59098-1980">EDA7</span></span></td>
  <td><span data-ttu-id="59098-1981">KeyboardShortcut</span><span class="sxs-lookup"><span data-stu-id="59098-1981">KeyboardShortcut</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA8.png" width="32" height="32" alt="BrushSize" /></td>
  <td><span data-ttu-id="59098-1982">EDA8</span><span class="sxs-lookup"><span data-stu-id="59098-1982">EDA8</span></span></td>
  <td><span data-ttu-id="59098-1983">BrushSize</span><span class="sxs-lookup"><span data-stu-id="59098-1983">BrushSize</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDA9.png" width="32" height="32" alt="NarratorForward" /></td>
  <td><span data-ttu-id="59098-1984">EDA9</span><span class="sxs-lookup"><span data-stu-id="59098-1984">EDA9</span></span></td>
  <td><span data-ttu-id="59098-1985">NarratorForward</span><span class="sxs-lookup"><span data-stu-id="59098-1985">NarratorForward</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAA.png" width="32" height="32" alt="NarratorForwardMirrored" /></td>
  <td><span data-ttu-id="59098-1986">EDAA</span><span class="sxs-lookup"><span data-stu-id="59098-1986">EDAA</span></span></td>
  <td><span data-ttu-id="59098-1987">NarratorForwardMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-1987">NarratorForwardMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAB.png" width="32" height="32" alt="SyncBadge12" /></td>
  <td><span data-ttu-id="59098-1988">EDAB</span><span class="sxs-lookup"><span data-stu-id="59098-1988">EDAB</span></span></td>
  <td><span data-ttu-id="59098-1989">SyncBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-1989">SyncBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAC.png" width="32" height="32" alt="RingerBadge12" /></td>
  <td><span data-ttu-id="59098-1990">EDAC</span><span class="sxs-lookup"><span data-stu-id="59098-1990">EDAC</span></span></td>
  <td><span data-ttu-id="59098-1991">RingerBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-1991">RingerBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAD.png" width="32" height="32" alt="AsteriskBadge12" /></td>
  <td><span data-ttu-id="59098-1992">EDAD</span><span class="sxs-lookup"><span data-stu-id="59098-1992">EDAD</span></span></td>
  <td><span data-ttu-id="59098-1993">AsteriskBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-1993">AsteriskBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAE.png" width="32" height="32" alt="ErrorBadge12" /></td>
  <td><span data-ttu-id="59098-1994">EDAE</span><span class="sxs-lookup"><span data-stu-id="59098-1994">EDAE</span></span></td>
  <td><span data-ttu-id="59098-1995">ErrorBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-1995">ErrorBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDAF.png" width="32" height="32" alt="CircleRingBadge12" /></td>
  <td><span data-ttu-id="59098-1996">EDAF</span><span class="sxs-lookup"><span data-stu-id="59098-1996">EDAF</span></span></td>
  <td><span data-ttu-id="59098-1997">CircleRingBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-1997">CircleRingBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB0.png" width="32" height="32" alt="CircleFillBadge12" /></td>
  <td><span data-ttu-id="59098-1998">EDB0</span><span class="sxs-lookup"><span data-stu-id="59098-1998">EDB0</span></span></td>
  <td><span data-ttu-id="59098-1999">CircleFillBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-1999">CircleFillBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB1.png" width="32" height="32" alt="ImportantBadge12" /></td>
  <td><span data-ttu-id="59098-2000">EDB1</span><span class="sxs-lookup"><span data-stu-id="59098-2000">EDB1</span></span></td>
  <td><span data-ttu-id="59098-2001">ImportantBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-2001">ImportantBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB3.png" width="32" height="32" alt="MailBadge12" /></td>
  <td><span data-ttu-id="59098-2002">EDB3</span><span class="sxs-lookup"><span data-stu-id="59098-2002">EDB3</span></span></td>
  <td><span data-ttu-id="59098-2003">MailBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-2003">MailBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB4.png" width="32" height="32" alt="PauseBadge12" /></td>
  <td><span data-ttu-id="59098-2004">EDB4</span><span class="sxs-lookup"><span data-stu-id="59098-2004">EDB4</span></span></td>
  <td><span data-ttu-id="59098-2005">PauseBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-2005">PauseBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDB5.png" width="32" height="32" alt="PlayBadge12" /></td>
  <td><span data-ttu-id="59098-2006">EDB5</span><span class="sxs-lookup"><span data-stu-id="59098-2006">EDB5</span></span></td>
  <td><span data-ttu-id="59098-2007">PlayBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-2007">PlayBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDC6.png" width="32" height="32" alt="PenWorkspace" /></td>
  <td><span data-ttu-id="59098-2008">EDC6</span><span class="sxs-lookup"><span data-stu-id="59098-2008">EDC6</span></span></td>
  <td><span data-ttu-id="59098-2009">PenWorkspace</span><span class="sxs-lookup"><span data-stu-id="59098-2009">PenWorkspace</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDD6.png" width="32" height="32" alt="CaretRight8" /></td>
  <td><span data-ttu-id="59098-2010">EDD6</span><span class="sxs-lookup"><span data-stu-id="59098-2010">EDD6</span></span></td>
  <td><span data-ttu-id="59098-2011">CaretRight8</span><span class="sxs-lookup"><span data-stu-id="59098-2011">CaretRight8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDD9.png" width="32" height="32" alt="CaretLeftSolid8" /></td>
  <td><span data-ttu-id="59098-2012">EDD9</span><span class="sxs-lookup"><span data-stu-id="59098-2012">EDD9</span></span></td>
  <td><span data-ttu-id="59098-2013">CaretLeftSolid8</span><span class="sxs-lookup"><span data-stu-id="59098-2013">CaretLeftSolid8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDDA.png" width="32" height="32" alt="CaretRightSolid8" /></td>
  <td><span data-ttu-id="59098-2014">EDDA</span><span class="sxs-lookup"><span data-stu-id="59098-2014">EDDA</span></span></td>
  <td><span data-ttu-id="59098-2015">CaretRightSolid8</span><span class="sxs-lookup"><span data-stu-id="59098-2015">CaretRightSolid8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDDB.png" width="32" height="32" alt="CaretUpSolid8" /></td>
  <td><span data-ttu-id="59098-2016">EDDB</span><span class="sxs-lookup"><span data-stu-id="59098-2016">EDDB</span></span></td>
  <td><span data-ttu-id="59098-2017">CaretUpSolid8</span><span class="sxs-lookup"><span data-stu-id="59098-2017">CaretUpSolid8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDDC.png" width="32" height="32" alt="CaretDownSolid8" /></td>
  <td><span data-ttu-id="59098-2018">EDDC</span><span class="sxs-lookup"><span data-stu-id="59098-2018">EDDC</span></span></td>
  <td><span data-ttu-id="59098-2019">CaretDownSolid8</span><span class="sxs-lookup"><span data-stu-id="59098-2019">CaretDownSolid8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE1.png" width="32" height="32" alt="Export" /></td>
  <td><span data-ttu-id="59098-2020">EDE1</span><span class="sxs-lookup"><span data-stu-id="59098-2020">EDE1</span></span></td>
  <td><span data-ttu-id="59098-2021">Export</span><span class="sxs-lookup"><span data-stu-id="59098-2021">Export</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE2.png" width="32" height="32" alt="ExportMirrored" /></td>
  <td><span data-ttu-id="59098-2022">EDE2</span><span class="sxs-lookup"><span data-stu-id="59098-2022">EDE2</span></span></td>
  <td><span data-ttu-id="59098-2023">ExportMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2023">ExportMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE3.png" width="32" height="32" alt="ButtonMenu" /></td>
  <td><span data-ttu-id="59098-2024">EDE3</span><span class="sxs-lookup"><span data-stu-id="59098-2024">EDE3</span></span></td>
  <td><span data-ttu-id="59098-2025">ボタン</span><span class="sxs-lookup"><span data-stu-id="59098-2025">ButtonMenu</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE4.png" width="32" height="32" alt="CloudSeach" /></td>
  <td><span data-ttu-id="59098-2026">EDE4</span><span class="sxs-lookup"><span data-stu-id="59098-2026">EDE4</span></span></td>
  <td><span data-ttu-id="59098-2027">CloudSeach</span><span class="sxs-lookup"><span data-stu-id="59098-2027">CloudSeach</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDE5.png" width="32" height="32" alt="PinyinIMELogo" /></td>
  <td><span data-ttu-id="59098-2028">EDE5</span><span class="sxs-lookup"><span data-stu-id="59098-2028">EDE5</span></span></td>
  <td><span data-ttu-id="59098-2029">PinyinIMELogo</span><span class="sxs-lookup"><span data-stu-id="59098-2029">PinyinIMELogo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EDFB.png" width="32" height="32" alt="CalligraphyPen" /></td>
  <td><span data-ttu-id="59098-2030">EDFB</span><span class="sxs-lookup"><span data-stu-id="59098-2030">EDFB</span></span></td>
  <td><span data-ttu-id="59098-2031">CalligraphyPen</span><span class="sxs-lookup"><span data-stu-id="59098-2031">CalligraphyPen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE35.png" width="32" height="32" alt="ReplyMirrored" /></td>
  <td><span data-ttu-id="59098-2032">EE35</span><span class="sxs-lookup"><span data-stu-id="59098-2032">EE35</span></span></td>
  <td><span data-ttu-id="59098-2033">ReplyMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2033">ReplyMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE3F.png" width="32" height="32" alt="LockscreenDesktop" /></td>
  <td><span data-ttu-id="59098-2034">EE3F</span><span class="sxs-lookup"><span data-stu-id="59098-2034">EE3F</span></span></td>
  <td><span data-ttu-id="59098-2035">LockscreenDesktop</span><span class="sxs-lookup"><span data-stu-id="59098-2035">LockscreenDesktop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE40.png" width="32" height="32" alt="TaskViewSettings" /></td>
  <td><span data-ttu-id="59098-2036">EE40</span><span class="sxs-lookup"><span data-stu-id="59098-2036">EE40</span></span></td>
  <td><span data-ttu-id="59098-2037">TaskViewSettings</span><span class="sxs-lookup"><span data-stu-id="59098-2037">TaskViewSettings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE4A.png" width="32" height="32" alt="Play36" /></td>
  <td><span data-ttu-id="59098-2038">EE4A</span><span class="sxs-lookup"><span data-stu-id="59098-2038">EE4A</span></span></td>
  <td><span data-ttu-id="59098-2039">Play36</span><span class="sxs-lookup"><span data-stu-id="59098-2039">Play36</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE56.png" width="32" height="32" alt="PenPalette" /></td>
  <td><span data-ttu-id="59098-2040">EE56</span><span class="sxs-lookup"><span data-stu-id="59098-2040">EE56</span></span></td>
  <td><span data-ttu-id="59098-2041">PenPalette</span><span class="sxs-lookup"><span data-stu-id="59098-2041">PenPalette</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE57.png" width="32" height="32" alt="GuestUser" /></td>
  <td><span data-ttu-id="59098-2042">EE57</span><span class="sxs-lookup"><span data-stu-id="59098-2042">EE57</span></span></td>
  <td><span data-ttu-id="59098-2043">GuestUser</span><span class="sxs-lookup"><span data-stu-id="59098-2043">GuestUser</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE63.png" width="32" height="32" alt="SettingsBattery" /></td>
  <td><span data-ttu-id="59098-2044">EE63</span><span class="sxs-lookup"><span data-stu-id="59098-2044">EE63</span></span></td>
  <td><span data-ttu-id="59098-2045">SettingsBattery</span><span class="sxs-lookup"><span data-stu-id="59098-2045">SettingsBattery</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE64.png" width="32" height="32" alt="TaskbarPhone" /></td>
  <td><span data-ttu-id="59098-2046">EE64</span><span class="sxs-lookup"><span data-stu-id="59098-2046">EE64</span></span></td>
  <td><span data-ttu-id="59098-2047">TaskbarPhone</span><span class="sxs-lookup"><span data-stu-id="59098-2047">TaskbarPhone</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE65.png" width="32" height="32" alt="LockScreenGlance" /></td>
  <td><span data-ttu-id="59098-2048">EE65</span><span class="sxs-lookup"><span data-stu-id="59098-2048">EE65</span></span></td>
  <td><span data-ttu-id="59098-2049">LockScreenGlance</span><span class="sxs-lookup"><span data-stu-id="59098-2049">LockScreenGlance</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE71.png" width="32" height="32" alt="ImageExport " /></td>
  <td><span data-ttu-id="59098-2050">EE71</span><span class="sxs-lookup"><span data-stu-id="59098-2050">EE71</span></span></td>
  <td><span data-ttu-id="59098-2051">ImageExport</span><span class="sxs-lookup"><span data-stu-id="59098-2051">ImageExport</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE77.png" width="32" height="32" alt="WifiEthernet" /></td>
  <td><span data-ttu-id="59098-2052">EE77</span><span class="sxs-lookup"><span data-stu-id="59098-2052">EE77</span></span></td>
  <td><span data-ttu-id="59098-2053">WifiEthernet</span><span class="sxs-lookup"><span data-stu-id="59098-2053">WifiEthernet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE79.png" width="32" height="32" alt="ActionCenterQuiet" /></td>
  <td><span data-ttu-id="59098-2054">EE79</span><span class="sxs-lookup"><span data-stu-id="59098-2054">EE79</span></span></td>
  <td><span data-ttu-id="59098-2055">ActionCenterQuiet</span><span class="sxs-lookup"><span data-stu-id="59098-2055">ActionCenterQuiet</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE7A.png" width="32" height="32" alt="ActionCenterQuietNotification" /></td>
  <td><span data-ttu-id="59098-2056">EE7A</span><span class="sxs-lookup"><span data-stu-id="59098-2056">EE7A</span></span></td>
  <td><span data-ttu-id="59098-2057">ActionCenterQuietNotification</span><span class="sxs-lookup"><span data-stu-id="59098-2057">ActionCenterQuietNotification</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE92.png" width="32" height="32" alt="TrackersMirrored" /></td>
  <td><span data-ttu-id="59098-2058">EE92</span><span class="sxs-lookup"><span data-stu-id="59098-2058">EE92</span></span></td>
  <td><span data-ttu-id="59098-2059">TrackersMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2059">TrackersMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE93.png" width="32" height="32" alt="DateTimeMirrored" /></td>
  <td><span data-ttu-id="59098-2060">EE93</span><span class="sxs-lookup"><span data-stu-id="59098-2060">EE93</span></span></td>
  <td><span data-ttu-id="59098-2061">DateTimeMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2061">DateTimeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EE94.png" width="32" height="32" alt="Wheel" /></td>
  <td><span data-ttu-id="59098-2062">EE94</span><span class="sxs-lookup"><span data-stu-id="59098-2062">EE94</span></span></td>
  <td><span data-ttu-id="59098-2063">Wheel</span><span class="sxs-lookup"><span data-stu-id="59098-2063">Wheel</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EECA.png" width="32" height="32" alt="ButtonView2" /></td>
  <td><span data-ttu-id="59098-2064">EECA</span><span class="sxs-lookup"><span data-stu-id="59098-2064">EECA</span></span></td>
  <td><span data-ttu-id="59098-2065">ButtonView2</span><span class="sxs-lookup"><span data-stu-id="59098-2065">ButtonView2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF15.png" width="32" height="32" alt="PenWorkspaceMirrored" /></td>
  <td><span data-ttu-id="59098-2066">EF15</span><span class="sxs-lookup"><span data-stu-id="59098-2066">EF15</span></span></td>
  <td><span data-ttu-id="59098-2067">PenWorkspaceMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2067">PenWorkspaceMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF16.png" width="32" height="32" alt="PenPaletteMirrored" /></td>
  <td><span data-ttu-id="59098-2068">EF16</span><span class="sxs-lookup"><span data-stu-id="59098-2068">EF16</span></span></td>
  <td><span data-ttu-id="59098-2069">PenPaletteMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2069">PenPaletteMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF17.png" width="32" height="32" alt="StrokeEraseMirrored" /></td>
  <td><span data-ttu-id="59098-2070">EF17</span><span class="sxs-lookup"><span data-stu-id="59098-2070">EF17</span></span></td>
  <td><span data-ttu-id="59098-2071">StrokeEraseMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2071">StrokeEraseMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF18.png" width="32" height="32" alt="PointEraseMirrored" /></td>
  <td><span data-ttu-id="59098-2072">EF18</span><span class="sxs-lookup"><span data-stu-id="59098-2072">EF18</span></span></td>
  <td><span data-ttu-id="59098-2073">PointEraseMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2073">PointEraseMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF19.png" width="32" height="32" alt="ClearAllInkMirrored" /></td>
  <td><span data-ttu-id="59098-2074">EF19</span><span class="sxs-lookup"><span data-stu-id="59098-2074">EF19</span></span></td>
  <td><span data-ttu-id="59098-2075">ClearAllInkMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2075">ClearAllInkMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF1F.png" width="32" height="32" alt="BackgroundToggle" /></td>
  <td><span data-ttu-id="59098-2076">EF1F</span><span class="sxs-lookup"><span data-stu-id="59098-2076">EF1F</span></span></td>
  <td><span data-ttu-id="59098-2077">BackgroundToggle</span><span class="sxs-lookup"><span data-stu-id="59098-2077">BackgroundToggle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF20.png" width="32" height="32" alt="Marquee" /></td>
  <td><span data-ttu-id="59098-2078">EF20</span><span class="sxs-lookup"><span data-stu-id="59098-2078">EF20</span></span></td>
  <td><span data-ttu-id="59098-2079">Marquee</span><span class="sxs-lookup"><span data-stu-id="59098-2079">Marquee</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF2C.png" width="32" height="32" alt="ChromeCloseContrast" /></td>
  <td><span data-ttu-id="59098-2080">EF2C</span><span class="sxs-lookup"><span data-stu-id="59098-2080">EF2C</span></span></td>
  <td><span data-ttu-id="59098-2081">ChromeCloseContrast</span><span class="sxs-lookup"><span data-stu-id="59098-2081">ChromeCloseContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF2D.png" width="32" height="32" alt="ChromeMinimizeContrast" /></td>
  <td><span data-ttu-id="59098-2082">EF2D</span><span class="sxs-lookup"><span data-stu-id="59098-2082">EF2D</span></span></td>
  <td><span data-ttu-id="59098-2083">ChromeMinimizeContrast</span><span class="sxs-lookup"><span data-stu-id="59098-2083">ChromeMinimizeContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF2E.png" width="32" height="32" alt="ChromeMaximizeContrast" /></td>
  <td><span data-ttu-id="59098-2084">EF2E</span><span class="sxs-lookup"><span data-stu-id="59098-2084">EF2E</span></span></td>
  <td><span data-ttu-id="59098-2085">ChromeMaximizeContrast</span><span class="sxs-lookup"><span data-stu-id="59098-2085">ChromeMaximizeContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF2F.png" width="32" height="32" alt="ChromeRestoreContrast" /></td>
  <td><span data-ttu-id="59098-2086">EF2F</span><span class="sxs-lookup"><span data-stu-id="59098-2086">EF2F</span></span></td>
  <td><span data-ttu-id="59098-2087">ChromeRestoreContrast</span><span class="sxs-lookup"><span data-stu-id="59098-2087">ChromeRestoreContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF31.png" width="32" height="32" alt="TrafficLight" /></td>
  <td><span data-ttu-id="59098-2088">EF31</span><span class="sxs-lookup"><span data-stu-id="59098-2088">EF31</span></span></td>
  <td><span data-ttu-id="59098-2089">TrafficLight</span><span class="sxs-lookup"><span data-stu-id="59098-2089">TrafficLight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3B.png" width="32" height="32" alt="Replay" /></td>
  <td><span data-ttu-id="59098-2090">EF3B</span><span class="sxs-lookup"><span data-stu-id="59098-2090">EF3B</span></span></td>
  <td><span data-ttu-id="59098-2091">再生</span><span class="sxs-lookup"><span data-stu-id="59098-2091">Replay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3C.png" width="32" height="32" alt="Eyedropper" /></td>
  <td><span data-ttu-id="59098-2092">EF3C</span><span class="sxs-lookup"><span data-stu-id="59098-2092">EF3C</span></span></td>
  <td><span data-ttu-id="59098-2093">スポイト ツール</span><span class="sxs-lookup"><span data-stu-id="59098-2093">Eyedropper</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3D.png" width="32" height="32" alt="LineDisplay" /></td>
  <td><span data-ttu-id="59098-2094">EF3D</span><span class="sxs-lookup"><span data-stu-id="59098-2094">EF3D</span></span></td>
  <td><span data-ttu-id="59098-2095">LineDisplay</span><span class="sxs-lookup"><span data-stu-id="59098-2095">LineDisplay</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3E.png" width="32" height="32" alt="PINPad" /></td>
  <td><span data-ttu-id="59098-2096">EF3E</span><span class="sxs-lookup"><span data-stu-id="59098-2096">EF3E</span></span></td>
  <td><span data-ttu-id="59098-2097">PINPad</span><span class="sxs-lookup"><span data-stu-id="59098-2097">PINPad</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF3F.png" width="32" height="32" alt="SignatureCapture" /></td>
  <td><span data-ttu-id="59098-2098">EF3F</span><span class="sxs-lookup"><span data-stu-id="59098-2098">EF3F</span></span></td>
  <td><span data-ttu-id="59098-2099">SignatureCapture</span><span class="sxs-lookup"><span data-stu-id="59098-2099">SignatureCapture</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF40.png" width="32" height="32" alt="ChipCardCreditCardReader" /></td>
  <td><span data-ttu-id="59098-2100">EF40</span><span class="sxs-lookup"><span data-stu-id="59098-2100">EF40</span></span></td>
  <td><span data-ttu-id="59098-2101">ChipCardCreditCardReader</span><span class="sxs-lookup"><span data-stu-id="59098-2101">ChipCardCreditCardReader</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF58.png" width="32" height="32" alt="PlayerSettings" /></td>
  <td><span data-ttu-id="59098-2102">EF58</span><span class="sxs-lookup"><span data-stu-id="59098-2102">EF58</span></span></td>
  <td><span data-ttu-id="59098-2103">PlayerSettings</span><span class="sxs-lookup"><span data-stu-id="59098-2103">PlayerSettings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EF6B.png" width="32" height="32" alt="LandscapeOrientation" /></td>
  <td><span data-ttu-id="59098-2104">EF6B</span><span class="sxs-lookup"><span data-stu-id="59098-2104">EF6B</span></span></td>
  <td><span data-ttu-id="59098-2105">LandscapeOrientation</span><span class="sxs-lookup"><span data-stu-id="59098-2105">LandscapeOrientation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EFA5.png" width="32" height="32" alt="Touchpad" /></td>
  <td><span data-ttu-id="59098-2106">EFA5</span><span class="sxs-lookup"><span data-stu-id="59098-2106">EFA5</span></span></td>
  <td><span data-ttu-id="59098-2107">タッチパッド</span><span class="sxs-lookup"><span data-stu-id="59098-2107">Touchpad</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/EFA9.png" width="32" height="32" alt="Speech" /></td>
  <td><span data-ttu-id="59098-2108">EFA9</span><span class="sxs-lookup"><span data-stu-id="59098-2108">EFA9</span></span></td>
  <td><span data-ttu-id="59098-2109">音声認識</span><span class="sxs-lookup"><span data-stu-id="59098-2109">Speech</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F000.png" width="32" height="32" alt="KnowledgeArticle" /></td>
  <td><span data-ttu-id="59098-2110">F000</span><span class="sxs-lookup"><span data-stu-id="59098-2110">F000</span></span></td>
  <td><span data-ttu-id="59098-2111">KnowledgeArticle</span><span class="sxs-lookup"><span data-stu-id="59098-2111">KnowledgeArticle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F003.png" width="32" height="32" alt="Relationship" /></td>
  <td><span data-ttu-id="59098-2112">F003</span><span class="sxs-lookup"><span data-stu-id="59098-2112">F003</span></span></td>
  <td><span data-ttu-id="59098-2113">Relationship</span><span class="sxs-lookup"><span data-stu-id="59098-2113">Relationship</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F080.png" width="32" height="32" alt="DefaultAPN" /></td>
  <td><span data-ttu-id="59098-2114">F080</span><span class="sxs-lookup"><span data-stu-id="59098-2114">F080</span></span></td>
  <td><span data-ttu-id="59098-2115">DefaultAPN</span><span class="sxs-lookup"><span data-stu-id="59098-2115">DefaultAPN</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F081.png" width="32" height="32" alt="UserAPN " /></td>
  <td><span data-ttu-id="59098-2116">F081</span><span class="sxs-lookup"><span data-stu-id="59098-2116">F081</span></span></td>
  <td><span data-ttu-id="59098-2117">UserAPN</span><span class="sxs-lookup"><span data-stu-id="59098-2117">UserAPN</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/F085.png" width="32" height="32" alt="DoublePinyin" /></td>
  <td><span data-ttu-id="59098-2118">F085</span><span class="sxs-lookup"><span data-stu-id="59098-2118">F085</span></span></td>
  <td><span data-ttu-id="59098-2119">DoublePinyin</span><span class="sxs-lookup"><span data-stu-id="59098-2119">DoublePinyin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F08C.png" width="32" height="32" alt="BlueLight" /></td>
  <td><span data-ttu-id="59098-2120">F08C</span><span class="sxs-lookup"><span data-stu-id="59098-2120">F08C</span></span></td>
  <td><span data-ttu-id="59098-2121">BlueLight</span><span class="sxs-lookup"><span data-stu-id="59098-2121">BlueLight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F093.png" width="32" height="32" alt="ButtonA" /></td>
  <td><span data-ttu-id="59098-2122">F093</span><span class="sxs-lookup"><span data-stu-id="59098-2122">F093</span></span></td>
  <td><span data-ttu-id="59098-2123">ButtonA</span><span class="sxs-lookup"><span data-stu-id="59098-2123">ButtonA</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F094.png" width="32" height="32" alt="ButtonB" /></td>
  <td><span data-ttu-id="59098-2124">F094</span><span class="sxs-lookup"><span data-stu-id="59098-2124">F094</span></span></td>
  <td><span data-ttu-id="59098-2125">ButtonB</span><span class="sxs-lookup"><span data-stu-id="59098-2125">ButtonB</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F095.png" width="32" height="32" alt="ButtonY" /></td>
  <td><span data-ttu-id="59098-2126">F095</span><span class="sxs-lookup"><span data-stu-id="59098-2126">F095</span></span></td>
  <td><span data-ttu-id="59098-2127">ButtonY</span><span class="sxs-lookup"><span data-stu-id="59098-2127">ButtonY</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F096.png" width="32" height="32" alt="ButtonX" /></td>
  <td><span data-ttu-id="59098-2128">F096</span><span class="sxs-lookup"><span data-stu-id="59098-2128">F096</span></span></td>
  <td><span data-ttu-id="59098-2129">ButtonX</span><span class="sxs-lookup"><span data-stu-id="59098-2129">ButtonX</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0AD.png" width="32" height="32" alt="ArrowUp8" /></td>
  <td><span data-ttu-id="59098-2130">F0AD</span><span class="sxs-lookup"><span data-stu-id="59098-2130">F0AD</span></span></td>
  <td><span data-ttu-id="59098-2131">ArrowUp8</span><span class="sxs-lookup"><span data-stu-id="59098-2131">ArrowUp8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0AE.png" width="32" height="32" alt="ArrowDown8" /></td>
  <td><span data-ttu-id="59098-2132">F0AE</span><span class="sxs-lookup"><span data-stu-id="59098-2132">F0AE</span></span></td>
  <td><span data-ttu-id="59098-2133">ArrowDown8</span><span class="sxs-lookup"><span data-stu-id="59098-2133">ArrowDown8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0AF.png" width="32" height="32" alt="ArrowRight8" /></td>
  <td><span data-ttu-id="59098-2134">F0AF</span><span class="sxs-lookup"><span data-stu-id="59098-2134">F0AF</span></span></td>
  <td><span data-ttu-id="59098-2135">ArrowRight8</span><span class="sxs-lookup"><span data-stu-id="59098-2135">ArrowRight8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B0.png" width="32" height="32" alt="ArrowLeft8" /></td>
  <td><span data-ttu-id="59098-2136">F0B0</span><span class="sxs-lookup"><span data-stu-id="59098-2136">F0B0</span></span></td>
  <td><span data-ttu-id="59098-2137">ArrowLeft8</span><span class="sxs-lookup"><span data-stu-id="59098-2137">ArrowLeft8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B2.png" width="32" height="32" alt="QuarentinedItems" /></td>
  <td><span data-ttu-id="59098-2138">F0B2</span><span class="sxs-lookup"><span data-stu-id="59098-2138">F0B2</span></span></td>
  <td><span data-ttu-id="59098-2139">QuarentinedItems</span><span class="sxs-lookup"><span data-stu-id="59098-2139">QuarentinedItems</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B3.png" width="32" height="32" alt="QuarentinedItemsMirrored" /></td>
  <td><span data-ttu-id="59098-2140">F0B3</span><span class="sxs-lookup"><span data-stu-id="59098-2140">F0B3</span></span></td>
  <td><span data-ttu-id="59098-2141">QuarentinedItemsMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2141">QuarentinedItemsMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B4.png" width="32" height="32" alt="Protractor" /></td>
  <td><span data-ttu-id="59098-2142">F0B4</span><span class="sxs-lookup"><span data-stu-id="59098-2142">F0B4</span></span></td>
  <td><span data-ttu-id="59098-2143">Protractor</span><span class="sxs-lookup"><span data-stu-id="59098-2143">Protractor</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B5.png" width="32" height="32" alt="ChecklistMirrored" /></td>
  <td><span data-ttu-id="59098-2144">F0B5</span><span class="sxs-lookup"><span data-stu-id="59098-2144">F0B5</span></span></td>
  <td><span data-ttu-id="59098-2145">ChecklistMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2145">ChecklistMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B6.png" width="32" height="32" alt="StatusCircle7" /></td>
  <td><span data-ttu-id="59098-2146">F0B6</span><span class="sxs-lookup"><span data-stu-id="59098-2146">F0B6</span></span></td>
  <td><span data-ttu-id="59098-2147">StatusCircle7</span><span class="sxs-lookup"><span data-stu-id="59098-2147">StatusCircle7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B7.png" width="32" height="32" alt="StatusCheckmark7" /></td>
  <td><span data-ttu-id="59098-2148">F0B7</span><span class="sxs-lookup"><span data-stu-id="59098-2148">F0B7</span></span></td>
  <td><span data-ttu-id="59098-2149">StatusCheckmark7</span><span class="sxs-lookup"><span data-stu-id="59098-2149">StatusCheckmark7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B8.png" width="32" height="32" alt="StatusErrorCircle7" /></td>
  <td><span data-ttu-id="59098-2150">F0B8</span><span class="sxs-lookup"><span data-stu-id="59098-2150">F0B8</span></span></td>
  <td><span data-ttu-id="59098-2151">StatusErrorCircle7</span><span class="sxs-lookup"><span data-stu-id="59098-2151">StatusErrorCircle7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0B9.png" width="32" height="32" alt="Connected" /></td>
  <td><span data-ttu-id="59098-2152">F0B9</span><span class="sxs-lookup"><span data-stu-id="59098-2152">F0B9</span></span></td>
  <td><span data-ttu-id="59098-2153">Connected</span><span class="sxs-lookup"><span data-stu-id="59098-2153">Connected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0C6.png" width="32" height="32" alt="PencilFill" /></td>
  <td><span data-ttu-id="59098-2154">F0C6</span><span class="sxs-lookup"><span data-stu-id="59098-2154">F0C6</span></span></td>
  <td><span data-ttu-id="59098-2155">PencilFill</span><span class="sxs-lookup"><span data-stu-id="59098-2155">PencilFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0C7.png" width="32" height="32" alt="CalligraphyFill" /></td>
  <td><span data-ttu-id="59098-2156">F0C7</span><span class="sxs-lookup"><span data-stu-id="59098-2156">F0C7</span></span></td>
  <td><span data-ttu-id="59098-2157">CalligraphyFill</span><span class="sxs-lookup"><span data-stu-id="59098-2157">CalligraphyFill</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CA.png" width="32" height="32" alt="QuarterStarLeft" /></td>
  <td><span data-ttu-id="59098-2158">F0CA</span><span class="sxs-lookup"><span data-stu-id="59098-2158">F0CA</span></span></td>
  <td><span data-ttu-id="59098-2159">QuarterStarLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2159">QuarterStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CB.png" width="32" height="32" alt="QuarterStarRight" /></td>
  <td><span data-ttu-id="59098-2160">F0CB</span><span class="sxs-lookup"><span data-stu-id="59098-2160">F0CB</span></span></td>
  <td><span data-ttu-id="59098-2161">QuarterStarRight</span><span class="sxs-lookup"><span data-stu-id="59098-2161">QuarterStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CC.png" width="32" height="32" alt="ThreeQuarterStarLeft" /></td>
  <td><span data-ttu-id="59098-2162">F0CC</span><span class="sxs-lookup"><span data-stu-id="59098-2162">F0CC</span></span></td>
  <td><span data-ttu-id="59098-2163">ThreeQuarterStarLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2163">ThreeQuarterStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CD.png" width="32" height="32" alt="ThreeQuarterStarRight" /></td>
  <td><span data-ttu-id="59098-2164">F0CD</span><span class="sxs-lookup"><span data-stu-id="59098-2164">F0CD</span></span></td>
  <td><span data-ttu-id="59098-2165">ThreeQuarterStarRight</span><span class="sxs-lookup"><span data-stu-id="59098-2165">ThreeQuarterStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0CE.png" width="32" height="32" alt="QuietHoursBadge12" /></td>
  <td><span data-ttu-id="59098-2166">F0CE</span><span class="sxs-lookup"><span data-stu-id="59098-2166">F0CE</span></span></td>
  <td><span data-ttu-id="59098-2167">QuietHoursBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-2167">QuietHoursBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D2.png" width="32" height="32" alt="BackMirrored" /></td>
  <td><span data-ttu-id="59098-2168">F0D2</span><span class="sxs-lookup"><span data-stu-id="59098-2168">F0D2</span></span></td>
  <td><span data-ttu-id="59098-2169">BackMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2169">BackMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D3.png" width="32" height="32" alt="ForwardMirrored" /></td>
  <td><span data-ttu-id="59098-2170">F0D3</span><span class="sxs-lookup"><span data-stu-id="59098-2170">F0D3</span></span></td>
  <td><span data-ttu-id="59098-2171">ForwardMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2171">ForwardMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D5.png" width="32" height="32" alt="ChromeBackContrast" /></td>
  <td><span data-ttu-id="59098-2172">F0D5</span><span class="sxs-lookup"><span data-stu-id="59098-2172">F0D5</span></span></td>
  <td><span data-ttu-id="59098-2173">ChromeBackContrast</span><span class="sxs-lookup"><span data-stu-id="59098-2173">ChromeBackContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D6.png" width="32" height="32" alt="ChromeBackContrastMirrored" /></td>
  <td><span data-ttu-id="59098-2174">F0D6</span><span class="sxs-lookup"><span data-stu-id="59098-2174">F0D6</span></span></td>
  <td><span data-ttu-id="59098-2175">ChromeBackContrastMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2175">ChromeBackContrastMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D7.png" width="32" height="32" alt="ChromeBackToWindowContrast" /></td>
  <td><span data-ttu-id="59098-2176">F0D7</span><span class="sxs-lookup"><span data-stu-id="59098-2176">F0D7</span></span></td>
  <td><span data-ttu-id="59098-2177">ChromeBackToWindowContrast</span><span class="sxs-lookup"><span data-stu-id="59098-2177">ChromeBackToWindowContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0D8.png" width="32" height="32" alt="ChromeFullScreenContrast" /></td>
  <td><span data-ttu-id="59098-2178">F0D8</span><span class="sxs-lookup"><span data-stu-id="59098-2178">F0D8</span></span></td>
  <td><span data-ttu-id="59098-2179">ChromeFullScreenContrast</span><span class="sxs-lookup"><span data-stu-id="59098-2179">ChromeFullScreenContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E2.png" width="32" height="32" alt="GridView" /></td>
  <td><span data-ttu-id="59098-2180">F0E2</span><span class="sxs-lookup"><span data-stu-id="59098-2180">F0E2</span></span></td>
  <td><span data-ttu-id="59098-2181">GridView</span><span class="sxs-lookup"><span data-stu-id="59098-2181">GridView</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E3.png" width="32" height="32" alt="ClipboardList" /></td>
  <td><span data-ttu-id="59098-2182">F0E3</span><span class="sxs-lookup"><span data-stu-id="59098-2182">F0E3</span></span></td>
  <td><span data-ttu-id="59098-2183">ClipboardList</span><span class="sxs-lookup"><span data-stu-id="59098-2183">ClipboardList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E4.png" width="32" height="32" alt="ClipboardListMirrored" /></td>
  <td><span data-ttu-id="59098-2184">F0E4</span><span class="sxs-lookup"><span data-stu-id="59098-2184">F0E4</span></span></td>
  <td><span data-ttu-id="59098-2185">ClipboardListMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2185">ClipboardListMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E5.png" width="32" height="32" alt="OutlineQuarterStarLeft" /></td>
  <td><span data-ttu-id="59098-2186">F0E5</span><span class="sxs-lookup"><span data-stu-id="59098-2186">F0E5</span></span></td>
  <td><span data-ttu-id="59098-2187">OutlineQuarterStarLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2187">OutlineQuarterStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E6.png" width="32" height="32" alt="OutlineQuarterStarRight" /></td>
  <td><span data-ttu-id="59098-2188">F0E6</span><span class="sxs-lookup"><span data-stu-id="59098-2188">F0E6</span></span></td>
  <td><span data-ttu-id="59098-2189">OutlineQuarterStarRight</span><span class="sxs-lookup"><span data-stu-id="59098-2189">OutlineQuarterStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E7.png" width="32" height="32" alt="OutlineHalfStarLeft" /></td>
  <td><span data-ttu-id="59098-2190">F0E7</span><span class="sxs-lookup"><span data-stu-id="59098-2190">F0E7</span></span></td>
  <td><span data-ttu-id="59098-2191">OutlineHalfStarLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2191">OutlineHalfStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E8.png" width="32" height="32" alt="OutlineHalfStarRight" /></td>
  <td><span data-ttu-id="59098-2192">F0E8</span><span class="sxs-lookup"><span data-stu-id="59098-2192">F0E8</span></span></td>
  <td><span data-ttu-id="59098-2193">OutlineHalfStarRight</span><span class="sxs-lookup"><span data-stu-id="59098-2193">OutlineHalfStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0E9.png" width="32" height="32" alt="OutlineThreeQuarterStarLeft" /></td>
  <td><span data-ttu-id="59098-2194">F0E9</span><span class="sxs-lookup"><span data-stu-id="59098-2194">F0E9</span></span></td>
  <td><span data-ttu-id="59098-2195">OutlineThreeQuarterStarLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2195">OutlineThreeQuarterStarLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0EA.png" width="32" height="32" alt="OutlineThreeQuarterStarRight" /></td>
  <td><span data-ttu-id="59098-2196">F0EA</span><span class="sxs-lookup"><span data-stu-id="59098-2196">F0EA</span></span></td>
  <td><span data-ttu-id="59098-2197">OutlineThreeQuarterStarRight</span><span class="sxs-lookup"><span data-stu-id="59098-2197">OutlineThreeQuarterStarRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0EB.png" width="32" height="32" alt="SpatialVolume0" /></td>
  <td><span data-ttu-id="59098-2198">F0EB</span><span class="sxs-lookup"><span data-stu-id="59098-2198">F0EB</span></span></td>
  <td><span data-ttu-id="59098-2199">SpatialVolume0</span><span class="sxs-lookup"><span data-stu-id="59098-2199">SpatialVolume0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0EC.png" width="32" height="32" alt="SpatialVolume1" /></td>
  <td><span data-ttu-id="59098-2200">F0EC</span><span class="sxs-lookup"><span data-stu-id="59098-2200">F0EC</span></span></td>
  <td><span data-ttu-id="59098-2201">SpatialVolume1</span><span class="sxs-lookup"><span data-stu-id="59098-2201">SpatialVolume1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0ED.png" width="32" height="32" alt="SpatialVolume2" /></td>
  <td><span data-ttu-id="59098-2202">F0ED</span><span class="sxs-lookup"><span data-stu-id="59098-2202">F0ED</span></span></td>
  <td><span data-ttu-id="59098-2203">SpatialVolume2</span><span class="sxs-lookup"><span data-stu-id="59098-2203">SpatialVolume2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0EE.png" width="32" height="32" alt="SpatialVolume3" /></td>
  <td><span data-ttu-id="59098-2204">F0EE</span><span class="sxs-lookup"><span data-stu-id="59098-2204">F0EE</span></span></td>
  <td><span data-ttu-id="59098-2205">SpatialVolume3</span><span class="sxs-lookup"><span data-stu-id="59098-2205">SpatialVolume3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0F7.png" width="32" height="32" alt="OutlineStarLeftHalf" /></td>
  <td><span data-ttu-id="59098-2206">F0F7</span><span class="sxs-lookup"><span data-stu-id="59098-2206">F0F7</span></span></td>
  <td><span data-ttu-id="59098-2207">OutlineStarLeftHalf</span><span class="sxs-lookup"><span data-stu-id="59098-2207">OutlineStarLeftHalf</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0F8.png" width="32" height="32" alt="OutlineStarRightHalf" /></td>
  <td><span data-ttu-id="59098-2208">F0F8</span><span class="sxs-lookup"><span data-stu-id="59098-2208">F0F8</span></span></td>
  <td><span data-ttu-id="59098-2209">OutlineStarRightHalf</span><span class="sxs-lookup"><span data-stu-id="59098-2209">OutlineStarRightHalf</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0F9.png" width="32" height="32" alt="ChromeAnnotateContrast" /></td>
  <td><span data-ttu-id="59098-2210">F0F9</span><span class="sxs-lookup"><span data-stu-id="59098-2210">F0F9</span></span></td>
  <td><span data-ttu-id="59098-2211">ChromeAnnotateContrast</span><span class="sxs-lookup"><span data-stu-id="59098-2211">ChromeAnnotateContrast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F0FB.png" width="32" height="32" alt="DefenderBadge12" /></td>
  <td><span data-ttu-id="59098-2212">F0FB</span><span class="sxs-lookup"><span data-stu-id="59098-2212">F0FB</span></span></td>
  <td><span data-ttu-id="59098-2213">DefenderBadge12</span><span class="sxs-lookup"><span data-stu-id="59098-2213">DefenderBadge12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F103.png" width="32" height="32" alt="DetachablePC" /></td>
  <td><span data-ttu-id="59098-2214">F103</span><span class="sxs-lookup"><span data-stu-id="59098-2214">F103</span></span></td>
  <td><span data-ttu-id="59098-2215">DetachablePC</span><span class="sxs-lookup"><span data-stu-id="59098-2215">DetachablePC</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F108.png" width="32" height="32" alt="LeftStick" /></td>
  <td><span data-ttu-id="59098-2216">F108</span><span class="sxs-lookup"><span data-stu-id="59098-2216">F108</span></span></td>
  <td><span data-ttu-id="59098-2217">LeftStick</span><span class="sxs-lookup"><span data-stu-id="59098-2217">LeftStick</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F109.png" width="32" height="32" alt="RightStick" /></td>
  <td><span data-ttu-id="59098-2218">F109</span><span class="sxs-lookup"><span data-stu-id="59098-2218">F109</span></span></td>
  <td><span data-ttu-id="59098-2219">RightStick</span><span class="sxs-lookup"><span data-stu-id="59098-2219">RightStick</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10A.png" width="32" height="32" alt="TriggerLeft" /></td>
  <td><span data-ttu-id="59098-2220">F10A</span><span class="sxs-lookup"><span data-stu-id="59098-2220">F10A</span></span></td>
  <td><span data-ttu-id="59098-2221">TriggerLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2221">TriggerLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10B.png" width="32" height="32" alt="TriggerRight" /></td>
  <td><span data-ttu-id="59098-2222">F10B</span><span class="sxs-lookup"><span data-stu-id="59098-2222">F10B</span></span></td>
  <td><span data-ttu-id="59098-2223">TriggerRight</span><span class="sxs-lookup"><span data-stu-id="59098-2223">TriggerRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10C.png" width="32" height="32" alt="BumperLeft" /></td>
  <td><span data-ttu-id="59098-2224">F10C</span><span class="sxs-lookup"><span data-stu-id="59098-2224">F10C</span></span></td>
  <td><span data-ttu-id="59098-2225">BumperLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2225">BumperLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10D.png" width="32" height="32" alt="BumperRight" /></td>
  <td><span data-ttu-id="59098-2226">F10D</span><span class="sxs-lookup"><span data-stu-id="59098-2226">F10D</span></span></td>
  <td><span data-ttu-id="59098-2227">BumperRight</span><span class="sxs-lookup"><span data-stu-id="59098-2227">BumperRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F10E.png" width="32" height="32" alt="Dpad" /></td>
  <td><span data-ttu-id="59098-2228">F10E</span><span class="sxs-lookup"><span data-stu-id="59098-2228">F10E</span></span></td>
  <td><span data-ttu-id="59098-2229">Dpad</span><span class="sxs-lookup"><span data-stu-id="59098-2229">Dpad</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F110.png" width="32" height="32" alt="EnglishPunctuation" /></td>
  <td><span data-ttu-id="59098-2230">F110</span><span class="sxs-lookup"><span data-stu-id="59098-2230">F110</span></span></td>
  <td><span data-ttu-id="59098-2231">EnglishPunctuation</span><span class="sxs-lookup"><span data-stu-id="59098-2231">EnglishPunctuation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F111.png" width="32" height="32" alt="ChinesePunctuation" /></td>
  <td><span data-ttu-id="59098-2232">F111</span><span class="sxs-lookup"><span data-stu-id="59098-2232">F111</span></span></td>
  <td><span data-ttu-id="59098-2233">ChinesePunctuation</span><span class="sxs-lookup"><span data-stu-id="59098-2233">ChinesePunctuation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F119.png" width="32" height="32" alt="HMD" /></td>
  <td><span data-ttu-id="59098-2234">F119</span><span class="sxs-lookup"><span data-stu-id="59098-2234">F119</span></span></td>
  <td><span data-ttu-id="59098-2235">HMD</span><span class="sxs-lookup"><span data-stu-id="59098-2235">HMD</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F11B.png" width="32" height="32" alt="CtrlSpatialRight" /></td>
  <td><span data-ttu-id="59098-2236">F11B</span><span class="sxs-lookup"><span data-stu-id="59098-2236">F11B</span></span></td>
  <td><span data-ttu-id="59098-2237">CtrlSpatialRight</span><span class="sxs-lookup"><span data-stu-id="59098-2237">CtrlSpatialRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F126.png" width="32" height="32" alt="PaginationDotOutline10" /></td>
  <td><span data-ttu-id="59098-2238">F126</span><span class="sxs-lookup"><span data-stu-id="59098-2238">F126</span></span></td>
  <td><span data-ttu-id="59098-2239">PaginationDotOutline10</span><span class="sxs-lookup"><span data-stu-id="59098-2239">PaginationDotOutline10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F127.png" width="32" height="32" alt="PaginationDotSolid10" /></td>
  <td><span data-ttu-id="59098-2240">F127</span><span class="sxs-lookup"><span data-stu-id="59098-2240">F127</span></span></td>
  <td><span data-ttu-id="59098-2241">PaginationDotSolid10</span><span class="sxs-lookup"><span data-stu-id="59098-2241">PaginationDotSolid10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F128.png" width="32" height="32" alt="StrokeErase2" /></td>
  <td><span data-ttu-id="59098-2242">F128</span><span class="sxs-lookup"><span data-stu-id="59098-2242">F128</span></span></td>
  <td><span data-ttu-id="59098-2243">StrokeErase2</span><span class="sxs-lookup"><span data-stu-id="59098-2243">StrokeErase2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F129.png" width="32" height="32" alt="SmallErase" /></td>
  <td><span data-ttu-id="59098-2244">F129</span><span class="sxs-lookup"><span data-stu-id="59098-2244">F129</span></span></td>
  <td><span data-ttu-id="59098-2245">SmallErase</span><span class="sxs-lookup"><span data-stu-id="59098-2245">SmallErase</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F12A.png" width="32" height="32" alt="LargeErase" /></td>
  <td><span data-ttu-id="59098-2246">F12A</span><span class="sxs-lookup"><span data-stu-id="59098-2246">F12A</span></span></td>
  <td><span data-ttu-id="59098-2247">LargeErase</span><span class="sxs-lookup"><span data-stu-id="59098-2247">LargeErase</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F12B.png" width="32" height="32" alt="FolderHorizontal" /></td>
  <td><span data-ttu-id="59098-2248">F12B</span><span class="sxs-lookup"><span data-stu-id="59098-2248">F12B</span></span></td>
  <td><span data-ttu-id="59098-2249">FolderHorizontal</span><span class="sxs-lookup"><span data-stu-id="59098-2249">FolderHorizontal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F12E.png" width="32" height="32" alt="MicrophoneListening" /></td>
  <td><span data-ttu-id="59098-2250">F12E</span><span class="sxs-lookup"><span data-stu-id="59098-2250">F12E</span></span></td>
  <td><span data-ttu-id="59098-2251">MicrophoneListening</span><span class="sxs-lookup"><span data-stu-id="59098-2251">MicrophoneListening</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F12F.png" width="32" height="32" alt="StatusExclamationCircle7 " /></td>
  <td><span data-ttu-id="59098-2252">F12F</span><span class="sxs-lookup"><span data-stu-id="59098-2252">F12F</span></span></td>
  <td><span data-ttu-id="59098-2253">StatusExclamationCircle7</span><span class="sxs-lookup"><span data-stu-id="59098-2253">StatusExclamationCircle7</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/F131.png" width="32" height="32" alt="Video360" /></td>
  <td><span data-ttu-id="59098-2254">F131</span><span class="sxs-lookup"><span data-stu-id="59098-2254">F131</span></span></td>
  <td><span data-ttu-id="59098-2255">Video360</span><span class="sxs-lookup"><span data-stu-id="59098-2255">Video360</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F133.png" width="32" height="32" alt="GiftboxOpen" /></td>
  <td><span data-ttu-id="59098-2256">F133</span><span class="sxs-lookup"><span data-stu-id="59098-2256">F133</span></span></td>
  <td><span data-ttu-id="59098-2257">GiftboxOpen</span><span class="sxs-lookup"><span data-stu-id="59098-2257">GiftboxOpen</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F136.png" width="32" height="32" alt="StatusCircleOuter" /></td>
  <td><span data-ttu-id="59098-2258">F136</span><span class="sxs-lookup"><span data-stu-id="59098-2258">F136</span></span></td>
  <td><span data-ttu-id="59098-2259">StatusCircleOuter</span><span class="sxs-lookup"><span data-stu-id="59098-2259">StatusCircleOuter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F137.png" width="32" height="32" alt="StatusCircleInner" /></td>
  <td><span data-ttu-id="59098-2260">F137</span><span class="sxs-lookup"><span data-stu-id="59098-2260">F137</span></span></td>
  <td><span data-ttu-id="59098-2261">StatusCircleInner</span><span class="sxs-lookup"><span data-stu-id="59098-2261">StatusCircleInner</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F138.png" width="32" height="32" alt="StatusCircleRing" /></td>
  <td><span data-ttu-id="59098-2262">F138</span><span class="sxs-lookup"><span data-stu-id="59098-2262">F138</span></span></td>
  <td><span data-ttu-id="59098-2263">StatusCircleRing</span><span class="sxs-lookup"><span data-stu-id="59098-2263">StatusCircleRing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F139.png" width="32" height="32" alt="StatusTriangleOuter" /></td>
  <td><span data-ttu-id="59098-2264">F139</span><span class="sxs-lookup"><span data-stu-id="59098-2264">F139</span></span></td>
  <td><span data-ttu-id="59098-2265">StatusTriangleOuter</span><span class="sxs-lookup"><span data-stu-id="59098-2265">StatusTriangleOuter</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13A.png" width="32" height="32" alt="StatusTriangleInner" /></td>
  <td><span data-ttu-id="59098-2266">F13A</span><span class="sxs-lookup"><span data-stu-id="59098-2266">F13A</span></span></td>
  <td><span data-ttu-id="59098-2267">StatusTriangleInner</span><span class="sxs-lookup"><span data-stu-id="59098-2267">StatusTriangleInner</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13B.png" width="32" height="32" alt="StatusTriangleExclamation" /></td>
  <td><span data-ttu-id="59098-2268">F13B</span><span class="sxs-lookup"><span data-stu-id="59098-2268">F13B</span></span></td>
  <td><span data-ttu-id="59098-2269">StatusTriangleExclamation</span><span class="sxs-lookup"><span data-stu-id="59098-2269">StatusTriangleExclamation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13C.png" width="32" height="32" alt="StatusCircleExclamation" /></td>
  <td><span data-ttu-id="59098-2270">F13C</span><span class="sxs-lookup"><span data-stu-id="59098-2270">F13C</span></span></td>
  <td><span data-ttu-id="59098-2271">StatusCircleExclamation</span><span class="sxs-lookup"><span data-stu-id="59098-2271">StatusCircleExclamation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13D.png" width="32" height="32" alt="StatusCircleErrorX" /></td>
  <td><span data-ttu-id="59098-2272">F13D</span><span class="sxs-lookup"><span data-stu-id="59098-2272">F13D</span></span></td>
  <td><span data-ttu-id="59098-2273">StatusCircleErrorX</span><span class="sxs-lookup"><span data-stu-id="59098-2273">StatusCircleErrorX</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13E.png" width="32" height="32" alt="StatusCircleCheckmark" /></td>
  <td><span data-ttu-id="59098-2274">F13E</span><span class="sxs-lookup"><span data-stu-id="59098-2274">F13E</span></span></td>
  <td><span data-ttu-id="59098-2275">StatusCircleCheckmark</span><span class="sxs-lookup"><span data-stu-id="59098-2275">StatusCircleCheckmark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F13F.png" width="32" height="32" alt="StatusCircleInfo" /></td>
  <td><span data-ttu-id="59098-2276">F13F</span><span class="sxs-lookup"><span data-stu-id="59098-2276">F13F</span></span></td>
  <td><span data-ttu-id="59098-2277">StatusCircleInfo</span><span class="sxs-lookup"><span data-stu-id="59098-2277">StatusCircleInfo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F140.png" width="32" height="32" alt="StatusCircleBlock" /></td>
  <td><span data-ttu-id="59098-2278">F140</span><span class="sxs-lookup"><span data-stu-id="59098-2278">F140</span></span></td>
  <td><span data-ttu-id="59098-2279">StatusCircleBlock</span><span class="sxs-lookup"><span data-stu-id="59098-2279">StatusCircleBlock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F141.png" width="32" height="32" alt="StatusCircleBlock2" /></td>
  <td><span data-ttu-id="59098-2280">F141</span><span class="sxs-lookup"><span data-stu-id="59098-2280">F141</span></span></td>
  <td><span data-ttu-id="59098-2281">StatusCircleBlock2</span><span class="sxs-lookup"><span data-stu-id="59098-2281">StatusCircleBlock2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F142.png" width="32" height="32" alt="StatusCircleQuestionMark" /></td>
  <td><span data-ttu-id="59098-2282">F142</span><span class="sxs-lookup"><span data-stu-id="59098-2282">F142</span></span></td>
  <td><span data-ttu-id="59098-2283">StatusCircleQuestionMark</span><span class="sxs-lookup"><span data-stu-id="59098-2283">StatusCircleQuestionMark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F143.png" width="32" height="32" alt="StatusCircleSync" /></td>
  <td><span data-ttu-id="59098-2284">F143</span><span class="sxs-lookup"><span data-stu-id="59098-2284">F143</span></span></td>
  <td><span data-ttu-id="59098-2285">StatusCircleSync</span><span class="sxs-lookup"><span data-stu-id="59098-2285">StatusCircleSync</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F146.png" width="32" height="32" alt="Dial1" /></td>
  <td><span data-ttu-id="59098-2286">F146</span><span class="sxs-lookup"><span data-stu-id="59098-2286">F146</span></span></td>
  <td><span data-ttu-id="59098-2287">Dial1</span><span class="sxs-lookup"><span data-stu-id="59098-2287">Dial1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F147.png" width="32" height="32" alt="Dial2" /></td>
  <td><span data-ttu-id="59098-2288">F147</span><span class="sxs-lookup"><span data-stu-id="59098-2288">F147</span></span></td>
  <td><span data-ttu-id="59098-2289">Dial2</span><span class="sxs-lookup"><span data-stu-id="59098-2289">Dial2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F148.png" width="32" height="32" alt="Dial3" /></td>
  <td><span data-ttu-id="59098-2290">F148</span><span class="sxs-lookup"><span data-stu-id="59098-2290">F148</span></span></td>
  <td><span data-ttu-id="59098-2291">Dial3</span><span class="sxs-lookup"><span data-stu-id="59098-2291">Dial3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F149.png" width="32" height="32" alt="Dial4" /></td>
  <td><span data-ttu-id="59098-2292">F149</span><span class="sxs-lookup"><span data-stu-id="59098-2292">F149</span></span></td>
  <td><span data-ttu-id="59098-2293">Dial4</span><span class="sxs-lookup"><span data-stu-id="59098-2293">Dial4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14A.png" width="32" height="32" alt="Dial5" /></td>
  <td><span data-ttu-id="59098-2294">F14A</span><span class="sxs-lookup"><span data-stu-id="59098-2294">F14A</span></span></td>
  <td><span data-ttu-id="59098-2295">Dial5</span><span class="sxs-lookup"><span data-stu-id="59098-2295">Dial5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14B.png" width="32" height="32" alt="Dial6" /></td>
  <td><span data-ttu-id="59098-2296">F14B</span><span class="sxs-lookup"><span data-stu-id="59098-2296">F14B</span></span></td>
  <td><span data-ttu-id="59098-2297">Dial6</span><span class="sxs-lookup"><span data-stu-id="59098-2297">Dial6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14C.png" width="32" height="32" alt="Dial7" /></td>
  <td><span data-ttu-id="59098-2298">F14C</span><span class="sxs-lookup"><span data-stu-id="59098-2298">F14C</span></span></td>
  <td><span data-ttu-id="59098-2299">Dial7</span><span class="sxs-lookup"><span data-stu-id="59098-2299">Dial7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14D.png" width="32" height="32" alt="Dial8" /></td>
  <td><span data-ttu-id="59098-2300">F14D</span><span class="sxs-lookup"><span data-stu-id="59098-2300">F14D</span></span></td>
  <td><span data-ttu-id="59098-2301">Dial8</span><span class="sxs-lookup"><span data-stu-id="59098-2301">Dial8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14E.png" width="32" height="32" alt="Dial9" /></td>
  <td><span data-ttu-id="59098-2302">F14E</span><span class="sxs-lookup"><span data-stu-id="59098-2302">F14E</span></span></td>
  <td><span data-ttu-id="59098-2303">Dial9</span><span class="sxs-lookup"><span data-stu-id="59098-2303">Dial9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F14F.png" width="32" height="32" alt="Dial10" /></td>
  <td><span data-ttu-id="59098-2304">F14F</span><span class="sxs-lookup"><span data-stu-id="59098-2304">F14F</span></span></td>
  <td><span data-ttu-id="59098-2305">Dial10</span><span class="sxs-lookup"><span data-stu-id="59098-2305">Dial10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F150.png" width="32" height="32" alt="Dial11" /></td>
  <td><span data-ttu-id="59098-2306">F150</span><span class="sxs-lookup"><span data-stu-id="59098-2306">F150</span></span></td>
  <td><span data-ttu-id="59098-2307">Dial11</span><span class="sxs-lookup"><span data-stu-id="59098-2307">Dial11</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F151.png" width="32" height="32" alt="Dial12" /></td>
  <td><span data-ttu-id="59098-2308">F151</span><span class="sxs-lookup"><span data-stu-id="59098-2308">F151</span></span></td>
  <td><span data-ttu-id="59098-2309">Dial12</span><span class="sxs-lookup"><span data-stu-id="59098-2309">Dial12</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F152.png" width="32" height="32" alt="Dial13" /></td>
  <td><span data-ttu-id="59098-2310">F152</span><span class="sxs-lookup"><span data-stu-id="59098-2310">F152</span></span></td>
  <td><span data-ttu-id="59098-2311">Dial13</span><span class="sxs-lookup"><span data-stu-id="59098-2311">Dial13</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F153.png" width="32" height="32" alt="Dial14" /></td>
  <td><span data-ttu-id="59098-2312">F153</span><span class="sxs-lookup"><span data-stu-id="59098-2312">F153</span></span></td>
  <td><span data-ttu-id="59098-2313">Dial14</span><span class="sxs-lookup"><span data-stu-id="59098-2313">Dial14</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F154.png" width="32" height="32" alt="Dial15" /></td>
  <td><span data-ttu-id="59098-2314">F154</span><span class="sxs-lookup"><span data-stu-id="59098-2314">F154</span></span></td>
  <td><span data-ttu-id="59098-2315">Dial15</span><span class="sxs-lookup"><span data-stu-id="59098-2315">Dial15</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F155.png" width="32" height="32" alt="Dial16" /></td>
  <td><span data-ttu-id="59098-2316">F155</span><span class="sxs-lookup"><span data-stu-id="59098-2316">F155</span></span></td>
  <td><span data-ttu-id="59098-2317">Dial16</span><span class="sxs-lookup"><span data-stu-id="59098-2317">Dial16</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F156.png" width="32" height="32" alt="DialShape1" /></td>
  <td><span data-ttu-id="59098-2318">F156</span><span class="sxs-lookup"><span data-stu-id="59098-2318">F156</span></span></td>
  <td><span data-ttu-id="59098-2319">DialShape1</span><span class="sxs-lookup"><span data-stu-id="59098-2319">DialShape1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F157.png" width="32" height="32" alt="DialShape2" /></td>
  <td><span data-ttu-id="59098-2320">F157</span><span class="sxs-lookup"><span data-stu-id="59098-2320">F157</span></span></td>
  <td><span data-ttu-id="59098-2321">DialShape2</span><span class="sxs-lookup"><span data-stu-id="59098-2321">DialShape2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F158.png" width="32" height="32" alt="DialShape3" /></td>
  <td><span data-ttu-id="59098-2322">F158</span><span class="sxs-lookup"><span data-stu-id="59098-2322">F158</span></span></td>
  <td><span data-ttu-id="59098-2323">DialShape3</span><span class="sxs-lookup"><span data-stu-id="59098-2323">DialShape3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F159.png" width="32" height="32" alt="DialShape4" /></td>
  <td><span data-ttu-id="59098-2324">F159</span><span class="sxs-lookup"><span data-stu-id="59098-2324">F159</span></span></td>
  <td><span data-ttu-id="59098-2325">DialShape4</span><span class="sxs-lookup"><span data-stu-id="59098-2325">DialShape4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F161.png" width="32" height="32" alt="TollSolid" /></td>
  <td><span data-ttu-id="59098-2326">F161</span><span class="sxs-lookup"><span data-stu-id="59098-2326">F161</span></span></td>
  <td><span data-ttu-id="59098-2327">TollSolid</span><span class="sxs-lookup"><span data-stu-id="59098-2327">TollSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F163.png" width="32" height="32" alt="TrafficCongestionSolid" /></td>
  <td><span data-ttu-id="59098-2328">F163</span><span class="sxs-lookup"><span data-stu-id="59098-2328">F163</span></span></td>
  <td><span data-ttu-id="59098-2329">TrafficCongestionSolid</span><span class="sxs-lookup"><span data-stu-id="59098-2329">TrafficCongestionSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F164.png" width="32" height="32" alt="ExploreContentSingle" /></td>
  <td><span data-ttu-id="59098-2330">F164</span><span class="sxs-lookup"><span data-stu-id="59098-2330">F164</span></span></td>
  <td><span data-ttu-id="59098-2331">ExploreContentSingle</span><span class="sxs-lookup"><span data-stu-id="59098-2331">ExploreContentSingle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F165.png" width="32" height="32" alt="CollapseContent" /></td>
  <td><span data-ttu-id="59098-2332">F165</span><span class="sxs-lookup"><span data-stu-id="59098-2332">F165</span></span></td>
  <td><span data-ttu-id="59098-2333">CollapseContent</span><span class="sxs-lookup"><span data-stu-id="59098-2333">CollapseContent</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F166.png" width="32" height="32" alt="CollapseContentSingle" /></td>
  <td><span data-ttu-id="59098-2334">F166</span><span class="sxs-lookup"><span data-stu-id="59098-2334">F166</span></span></td>
  <td><span data-ttu-id="59098-2335">CollapseContentSingle</span><span class="sxs-lookup"><span data-stu-id="59098-2335">CollapseContentSingle</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F167.png" width="32" height="32" alt="InfoSolid" /></td>
  <td><span data-ttu-id="59098-2336">F167</span><span class="sxs-lookup"><span data-stu-id="59098-2336">F167</span></span></td>
  <td><span data-ttu-id="59098-2337">InfoSolid</span><span class="sxs-lookup"><span data-stu-id="59098-2337">InfoSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F168.png" width="32" height="32" alt="GroupList" /></td>
  <td><span data-ttu-id="59098-2338">F168</span><span class="sxs-lookup"><span data-stu-id="59098-2338">F168</span></span></td>
  <td><span data-ttu-id="59098-2339">GroupList</span><span class="sxs-lookup"><span data-stu-id="59098-2339">GroupList</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F169.png" width="32" height="32" alt="CaretBottomRightSolidCenter8" /></td>
  <td><span data-ttu-id="59098-2340">F169</span><span class="sxs-lookup"><span data-stu-id="59098-2340">F169</span></span></td>
  <td><span data-ttu-id="59098-2341">CaretBottomRightSolidCenter8</span><span class="sxs-lookup"><span data-stu-id="59098-2341">CaretBottomRightSolidCenter8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16A.png" width="32" height="32" alt="ProgressRingDots" /></td>
  <td><span data-ttu-id="59098-2342">F16A</span><span class="sxs-lookup"><span data-stu-id="59098-2342">F16A</span></span></td>
  <td><span data-ttu-id="59098-2343">ProgressRingDots</span><span class="sxs-lookup"><span data-stu-id="59098-2343">ProgressRingDots</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16B.png" width="32" height="32" alt="Checkbox14" /></td>
  <td><span data-ttu-id="59098-2344">F16B</span><span class="sxs-lookup"><span data-stu-id="59098-2344">F16B</span></span></td>
  <td><span data-ttu-id="59098-2345">Checkbox14</span><span class="sxs-lookup"><span data-stu-id="59098-2345">Checkbox14</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16C.png" width="32" height="32" alt="CheckboxComposite14" /></td>
  <td><span data-ttu-id="59098-2346">F16C</span><span class="sxs-lookup"><span data-stu-id="59098-2346">F16C</span></span></td>
  <td><span data-ttu-id="59098-2347">CheckboxComposite14</span><span class="sxs-lookup"><span data-stu-id="59098-2347">CheckboxComposite14</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16D.png" width="32" height="32" alt="CheckboxIndeterminateCombo14" /></td>
  <td><span data-ttu-id="59098-2348">F16D</span><span class="sxs-lookup"><span data-stu-id="59098-2348">F16D</span></span></td>
  <td><span data-ttu-id="59098-2349">CheckboxIndeterminateCombo14</span><span class="sxs-lookup"><span data-stu-id="59098-2349">CheckboxIndeterminateCombo14</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F16E.png" width="32" height="32" alt="CheckboxIndeterminateCombo" /></td>
  <td><span data-ttu-id="59098-2350">F16E</span><span class="sxs-lookup"><span data-stu-id="59098-2350">F16E</span></span></td>
  <td><span data-ttu-id="59098-2351">CheckboxIndeterminateCombo</span><span class="sxs-lookup"><span data-stu-id="59098-2351">CheckboxIndeterminateCombo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F175.png" width="32" height="32" alt="StatusPause7" /></td>
  <td><span data-ttu-id="59098-2352">F175</span><span class="sxs-lookup"><span data-stu-id="59098-2352">F175</span></span></td>
  <td><span data-ttu-id="59098-2353">StatusPause7</span><span class="sxs-lookup"><span data-stu-id="59098-2353">StatusPause7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F17F.png" width="32" height="32" alt="CharacterAppearance" /></td>
  <td><span data-ttu-id="59098-2354">F17F</span><span class="sxs-lookup"><span data-stu-id="59098-2354">F17F</span></span></td>
  <td><span data-ttu-id="59098-2355">CharacterAppearance</span><span class="sxs-lookup"><span data-stu-id="59098-2355">CharacterAppearance</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F180.png" width="32" height="32" alt="Lexicon " /></td>
  <td><span data-ttu-id="59098-2356">F180</span><span class="sxs-lookup"><span data-stu-id="59098-2356">F180</span></span></td>
  <td><span data-ttu-id="59098-2357">Lexicon</span><span class="sxs-lookup"><span data-stu-id="59098-2357">Lexicon</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/F182.png" width="32" height="32" alt="ScreenTime" /></td>
  <td><span data-ttu-id="59098-2358">F182</span><span class="sxs-lookup"><span data-stu-id="59098-2358">F182</span></span></td>
  <td><span data-ttu-id="59098-2359">ScreenTime</span><span class="sxs-lookup"><span data-stu-id="59098-2359">ScreenTime</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F191.png" width="32" height="32" alt="HeadlessDevice" /></td>
  <td><span data-ttu-id="59098-2360">F191</span><span class="sxs-lookup"><span data-stu-id="59098-2360">F191</span></span></td>
  <td><span data-ttu-id="59098-2361">HeadlessDevice</span><span class="sxs-lookup"><span data-stu-id="59098-2361">HeadlessDevice</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F193.png" width="32" height="32" alt="NetworkSharing" /></td>
  <td><span data-ttu-id="59098-2362">F193</span><span class="sxs-lookup"><span data-stu-id="59098-2362">F193</span></span></td>
  <td><span data-ttu-id="59098-2363">NetworkSharing</span><span class="sxs-lookup"><span data-stu-id="59098-2363">NetworkSharing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F19D.png" width="32" height="32" alt="EyeGaze" /></td>
  <td><span data-ttu-id="59098-2364">F19D</span><span class="sxs-lookup"><span data-stu-id="59098-2364">F19D</span></span></td>
  <td><span data-ttu-id="59098-2365">EyeGaze</span><span class="sxs-lookup"><span data-stu-id="59098-2365">EyeGaze</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1AD.png" width="32" height="32" alt="WindowsInsider" /></td>
  <td><span data-ttu-id="59098-2366">F1AD</span><span class="sxs-lookup"><span data-stu-id="59098-2366">F1AD</span></span></td>
  <td><span data-ttu-id="59098-2367">WindowsInsider</span><span class="sxs-lookup"><span data-stu-id="59098-2367">WindowsInsider</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1CB.png" width="32" height="32" alt="ChromeSwitch" /></td>
  <td><span data-ttu-id="59098-2368">F1CB</span><span class="sxs-lookup"><span data-stu-id="59098-2368">F1CB</span></span></td>
  <td><span data-ttu-id="59098-2369">ChromeSwitch</span><span class="sxs-lookup"><span data-stu-id="59098-2369">ChromeSwitch</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1CC.png" width="32" height="32" alt="ChromeSwitchContast" /></td>
  <td><span data-ttu-id="59098-2370">F1CC</span><span class="sxs-lookup"><span data-stu-id="59098-2370">F1CC</span></span></td>
  <td><span data-ttu-id="59098-2371">ChromeSwitchContast</span><span class="sxs-lookup"><span data-stu-id="59098-2371">ChromeSwitchContast</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1D8.png" width="32" height="32" alt="StatusCheckmark" /></td>
  <td><span data-ttu-id="59098-2372">F1D8</span><span class="sxs-lookup"><span data-stu-id="59098-2372">F1D8</span></span></td>
  <td><span data-ttu-id="59098-2373">StatusCheckmark</span><span class="sxs-lookup"><span data-stu-id="59098-2373">StatusCheckmark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F1D9.png" width="32" height="32" alt="StatusCheckmarkLeft" /></td>
  <td><span data-ttu-id="59098-2374">F1D9</span><span class="sxs-lookup"><span data-stu-id="59098-2374">F1D9</span></span></td>
  <td><span data-ttu-id="59098-2375">StatusCheckmarkLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2375">StatusCheckmarkLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F20C.png" width="32" height="32" alt="KeyboardLeftAligned" /></td>
  <td><span data-ttu-id="59098-2376">F20C</span><span class="sxs-lookup"><span data-stu-id="59098-2376">F20C</span></span></td>
  <td><span data-ttu-id="59098-2377">KeyboardLeftAligned</span><span class="sxs-lookup"><span data-stu-id="59098-2377">KeyboardLeftAligned</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F20D.png" width="32" height="32" alt="KeyboardRightAligned" /></td>
  <td><span data-ttu-id="59098-2378">F20D</span><span class="sxs-lookup"><span data-stu-id="59098-2378">F20D</span></span></td>
  <td><span data-ttu-id="59098-2379">KeyboardRightAligned</span><span class="sxs-lookup"><span data-stu-id="59098-2379">KeyboardRightAligned</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F210.png" width="32" height="32" alt="KeyboardSettings" /></td>
  <td><span data-ttu-id="59098-2380">F210</span><span class="sxs-lookup"><span data-stu-id="59098-2380">F210</span></span></td>
  <td><span data-ttu-id="59098-2381">KeyboardSettings</span><span class="sxs-lookup"><span data-stu-id="59098-2381">KeyboardSettings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F22C.png" width="32" height="32" alt="IOT" /></td>
  <td><span data-ttu-id="59098-2382">F22C</span><span class="sxs-lookup"><span data-stu-id="59098-2382">F22C</span></span></td>
  <td><span data-ttu-id="59098-2383">IOT</span><span class="sxs-lookup"><span data-stu-id="59098-2383">IOT</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F22E.png" width="32" height="32" alt="UnknownMirrored" /></td>
  <td><span data-ttu-id="59098-2384">F22E</span><span class="sxs-lookup"><span data-stu-id="59098-2384">F22E</span></span></td>
  <td><span data-ttu-id="59098-2385">UnknownMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2385">UnknownMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F246.png" width="32" height="32" alt="ViewDashboard" /></td>
  <td><span data-ttu-id="59098-2386">F246</span><span class="sxs-lookup"><span data-stu-id="59098-2386">F246</span></span></td>
  <td><span data-ttu-id="59098-2387">ViewDashboard</span><span class="sxs-lookup"><span data-stu-id="59098-2387">ViewDashboard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F259.png" width="32" height="32" alt="ExploitProtectionSettings" /></td>
  <td><span data-ttu-id="59098-2388">F259</span><span class="sxs-lookup"><span data-stu-id="59098-2388">F259</span></span></td>
  <td><span data-ttu-id="59098-2389">ExploitProtectionSettings</span><span class="sxs-lookup"><span data-stu-id="59098-2389">ExploitProtectionSettings</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F260.png" width="32" height="32" alt="KeyboardNarrow" /></td>
  <td><span data-ttu-id="59098-2390">F260</span><span class="sxs-lookup"><span data-stu-id="59098-2390">F260</span></span></td>
  <td><span data-ttu-id="59098-2391">KeyboardNarrow</span><span class="sxs-lookup"><span data-stu-id="59098-2391">KeyboardNarrow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F261.png" width="32" height="32" alt="Keyboard12Key" /></td>
  <td><span data-ttu-id="59098-2392">F261</span><span class="sxs-lookup"><span data-stu-id="59098-2392">F261</span></span></td>
  <td><span data-ttu-id="59098-2393">Keyboard12Key</span><span class="sxs-lookup"><span data-stu-id="59098-2393">Keyboard12Key</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F26B.png" width="32" height="32" alt="KeyboardDock" /></td>
  <td><span data-ttu-id="59098-2394">F26B</span><span class="sxs-lookup"><span data-stu-id="59098-2394">F26B</span></span></td>
  <td><span data-ttu-id="59098-2395">KeyboardDock</span><span class="sxs-lookup"><span data-stu-id="59098-2395">KeyboardDock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F26C.png" width="32" height="32" alt="KeyboardUndock" /></td>
  <td><span data-ttu-id="59098-2396">F26C</span><span class="sxs-lookup"><span data-stu-id="59098-2396">F26C</span></span></td>
  <td><span data-ttu-id="59098-2397">KeyboardUndock</span><span class="sxs-lookup"><span data-stu-id="59098-2397">KeyboardUndock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F26D.png" width="32" height="32" alt="KeyboardLeftDock" /></td>
  <td><span data-ttu-id="59098-2398">F26D</span><span class="sxs-lookup"><span data-stu-id="59098-2398">F26D</span></span></td>
  <td><span data-ttu-id="59098-2399">KeyboardLeftDock</span><span class="sxs-lookup"><span data-stu-id="59098-2399">KeyboardLeftDock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F26E.png" width="32" height="32" alt="KeyboardRightDock" /></td>
  <td><span data-ttu-id="59098-2400">F26E</span><span class="sxs-lookup"><span data-stu-id="59098-2400">F26E</span></span></td>
  <td><span data-ttu-id="59098-2401">KeyboardRightDock</span><span class="sxs-lookup"><span data-stu-id="59098-2401">KeyboardRightDock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F270.png" width="32" height="32" alt="Ear" /></td>
  <td><span data-ttu-id="59098-2402">F270</span><span class="sxs-lookup"><span data-stu-id="59098-2402">F270</span></span></td>
  <td><span data-ttu-id="59098-2403">Ear</span><span class="sxs-lookup"><span data-stu-id="59098-2403">Ear</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F271.png" width="32" height="32" alt="PointerHand" /></td>
  <td><span data-ttu-id="59098-2404">F271</span><span class="sxs-lookup"><span data-stu-id="59098-2404">F271</span></span></td>
  <td><span data-ttu-id="59098-2405">PointerHand</span><span class="sxs-lookup"><span data-stu-id="59098-2405">PointerHand</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F272.png" width="32" height="32" alt="Bullseye" /></td>
  <td><span data-ttu-id="59098-2406">F272</span><span class="sxs-lookup"><span data-stu-id="59098-2406">F272</span></span></td>
  <td><span data-ttu-id="59098-2407">Bullseye</span><span class="sxs-lookup"><span data-stu-id="59098-2407">Bullseye</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F32A.png" width="32" height="32" alt="PassiveAuthentication" /></td>
  <td><span data-ttu-id="59098-2408">F32A</span><span class="sxs-lookup"><span data-stu-id="59098-2408">F32A</span></span></td>
  <td><span data-ttu-id="59098-2409">PassiveAuthentication</span><span class="sxs-lookup"><span data-stu-id="59098-2409">PassiveAuthentication</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F384.png" width="32" height="32" alt="NetworkOffline" /></td>
  <td><span data-ttu-id="59098-2410">F384</span><span class="sxs-lookup"><span data-stu-id="59098-2410">F384</span></span></td>
  <td><span data-ttu-id="59098-2411">NetworkOffline</span><span class="sxs-lookup"><span data-stu-id="59098-2411">NetworkOffline</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F385.png" width="32" height="32" alt="NetworkConnected" /></td>
  <td><span data-ttu-id="59098-2412">F385</span><span class="sxs-lookup"><span data-stu-id="59098-2412">F385</span></span></td>
  <td><span data-ttu-id="59098-2413">NetworkConnected</span><span class="sxs-lookup"><span data-stu-id="59098-2413">NetworkConnected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F386.png" width="32" height="32" alt="NetworkConnectedCheckmark" /></td>
  <td><span data-ttu-id="59098-2414">F386</span><span class="sxs-lookup"><span data-stu-id="59098-2414">F386</span></span></td>
  <td><span data-ttu-id="59098-2415">NetworkConnectedCheckmark</span><span class="sxs-lookup"><span data-stu-id="59098-2415">NetworkConnectedCheckmark</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F3CC.png" width="32" height="32" alt="StatusInfo" /></td>
  <td><span data-ttu-id="59098-2416">F3CC</span><span class="sxs-lookup"><span data-stu-id="59098-2416">F3CC</span></span></td>
  <td><span data-ttu-id="59098-2417">StatusInfo</span><span class="sxs-lookup"><span data-stu-id="59098-2417">StatusInfo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F3CD.png" width="32" height="32" alt="StatusInfoLeft" /></td>
  <td><span data-ttu-id="59098-2418">F3CD</span><span class="sxs-lookup"><span data-stu-id="59098-2418">F3CD</span></span></td>
  <td><span data-ttu-id="59098-2419">StatusInfoLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2419">StatusInfoLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F3E2.png" width="32" height="32" alt="NearbySharing" /></td>
  <td><span data-ttu-id="59098-2420">F3E2</span><span class="sxs-lookup"><span data-stu-id="59098-2420">F3E2</span></span></td>
  <td><span data-ttu-id="59098-2421">NearbySharing</span><span class="sxs-lookup"><span data-stu-id="59098-2421">NearbySharing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F3E7.png" width="32" height="32" alt="CtrlSpatialLeft" /></td>
  <td><span data-ttu-id="59098-2422">F3E7</span><span class="sxs-lookup"><span data-stu-id="59098-2422">F3E7</span></span></td>
  <td><span data-ttu-id="59098-2423">CtrlSpatialLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2423">CtrlSpatialLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F404.png" width="32" height="32" alt="InteractiveDashboard" /></td>
  <td><span data-ttu-id="59098-2424">F404</span><span class="sxs-lookup"><span data-stu-id="59098-2424">F404</span></span></td>
  <td><span data-ttu-id="59098-2425">InteractiveDashboard</span><span class="sxs-lookup"><span data-stu-id="59098-2425">InteractiveDashboard</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F406.png" width="32" height="32" alt="ClippingTool" /></td>
  <td><span data-ttu-id="59098-2426">F406</span><span class="sxs-lookup"><span data-stu-id="59098-2426">F406</span></span></td>
  <td><span data-ttu-id="59098-2427">ClippingTool</span><span class="sxs-lookup"><span data-stu-id="59098-2427">ClippingTool</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F407.png" width="32" height="32" alt="RectangularClipping " /></td>
  <td><span data-ttu-id="59098-2428">F407</span><span class="sxs-lookup"><span data-stu-id="59098-2428">F407</span></span></td>
  <td><span data-ttu-id="59098-2429">RectangularClipping</span><span class="sxs-lookup"><span data-stu-id="59098-2429">RectangularClipping</span></span> </td>
 </tr>
<tr><td><img src="images/segoe-mdl/F408.png" width="32" height="32" alt="FreeFormClipping" /></td>
  <td><span data-ttu-id="59098-2430">F408</span><span class="sxs-lookup"><span data-stu-id="59098-2430">F408</span></span></td>
  <td><span data-ttu-id="59098-2431">FreeFormClipping</span><span class="sxs-lookup"><span data-stu-id="59098-2431">FreeFormClipping</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F413.png" width="32" height="32" alt="CopyTo" /></td>
  <td><span data-ttu-id="59098-2432">F413</span><span class="sxs-lookup"><span data-stu-id="59098-2432">F413</span></span></td>
  <td><span data-ttu-id="59098-2433">CopyTo</span><span class="sxs-lookup"><span data-stu-id="59098-2433">CopyTo</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F439.png" width="32" height="32" alt="DynamicLock" /></td>
  <td><span data-ttu-id="59098-2434">F439</span><span class="sxs-lookup"><span data-stu-id="59098-2434">F439</span></span></td>
  <td><span data-ttu-id="59098-2435">DynamicLock</span><span class="sxs-lookup"><span data-stu-id="59098-2435">DynamicLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F45E.png" width="32" height="32" alt="PenTips" /></td>
  <td><span data-ttu-id="59098-2436">F45E</span><span class="sxs-lookup"><span data-stu-id="59098-2436">F45E</span></span></td>
  <td><span data-ttu-id="59098-2437">PenTips</span><span class="sxs-lookup"><span data-stu-id="59098-2437">PenTips</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F45F.png" width="32" height="32" alt="PenTipsMirrored" /></td>
  <td><span data-ttu-id="59098-2438">F45F</span><span class="sxs-lookup"><span data-stu-id="59098-2438">F45F</span></span></td>
  <td><span data-ttu-id="59098-2439">PenTipsMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2439">PenTipsMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F460.png" width="32" height="32" alt="HWPJoin" /></td>
  <td><span data-ttu-id="59098-2440">F460</span><span class="sxs-lookup"><span data-stu-id="59098-2440">F460</span></span></td>
  <td><span data-ttu-id="59098-2441">HWPJoin</span><span class="sxs-lookup"><span data-stu-id="59098-2441">HWPJoin</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F461.png" width="32" height="32" alt="HWPInsert" /></td>
  <td><span data-ttu-id="59098-2442">F461</span><span class="sxs-lookup"><span data-stu-id="59098-2442">F461</span></span></td>
  <td><span data-ttu-id="59098-2443">HWPInsert</span><span class="sxs-lookup"><span data-stu-id="59098-2443">HWPInsert</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F462.png" width="32" height="32" alt="HWPStrikeThrough" /></td>
  <td><span data-ttu-id="59098-2444">F462</span><span class="sxs-lookup"><span data-stu-id="59098-2444">F462</span></span></td>
  <td><span data-ttu-id="59098-2445">HWPStrikeThrough</span><span class="sxs-lookup"><span data-stu-id="59098-2445">HWPStrikeThrough</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F463.png" width="32" height="32" alt="HWPScratchOut" /></td>
  <td><span data-ttu-id="59098-2446">F463</span><span class="sxs-lookup"><span data-stu-id="59098-2446">F463</span></span></td>
  <td><span data-ttu-id="59098-2447">HWPScratchOut</span><span class="sxs-lookup"><span data-stu-id="59098-2447">HWPScratchOut</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F464.png" width="32" height="32" alt="HWPSplit" /></td>
  <td><span data-ttu-id="59098-2448">F464</span><span class="sxs-lookup"><span data-stu-id="59098-2448">F464</span></span></td>
  <td><span data-ttu-id="59098-2449">HWPSplit</span><span class="sxs-lookup"><span data-stu-id="59098-2449">HWPSplit</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F465.png" width="32" height="32" alt="HWPNewLine" /></td>
  <td><span data-ttu-id="59098-2450">F465</span><span class="sxs-lookup"><span data-stu-id="59098-2450">F465</span></span></td>
  <td><span data-ttu-id="59098-2451">HWPNewLine</span><span class="sxs-lookup"><span data-stu-id="59098-2451">HWPNewLine</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F466.png" width="32" height="32" alt="HWPOverwrite" /></td>
  <td><span data-ttu-id="59098-2452">F466</span><span class="sxs-lookup"><span data-stu-id="59098-2452">F466</span></span></td>
  <td><span data-ttu-id="59098-2453">HWPOverwrite</span><span class="sxs-lookup"><span data-stu-id="59098-2453">HWPOverwrite</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F473.png" width="32" height="32" alt="MobWifiWarning1" /></td>
  <td><span data-ttu-id="59098-2454">F473</span><span class="sxs-lookup"><span data-stu-id="59098-2454">F473</span></span></td>
  <td><span data-ttu-id="59098-2455">MobWifiWarning1</span><span class="sxs-lookup"><span data-stu-id="59098-2455">MobWifiWarning1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F474.png" width="32" height="32" alt="MobWifiWarning2" /></td>
  <td><span data-ttu-id="59098-2456">F474</span><span class="sxs-lookup"><span data-stu-id="59098-2456">F474</span></span></td>
  <td><span data-ttu-id="59098-2457">MobWifiWarning2</span><span class="sxs-lookup"><span data-stu-id="59098-2457">MobWifiWarning2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F475.png" width="32" height="32" alt="MobWifiWarning3" /></td>
  <td><span data-ttu-id="59098-2458">F475</span><span class="sxs-lookup"><span data-stu-id="59098-2458">F475</span></span></td>
  <td><span data-ttu-id="59098-2459">MobWifiWarning3</span><span class="sxs-lookup"><span data-stu-id="59098-2459">MobWifiWarning3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F476.png" width="32" height="32" alt="MobWifiWarning4" /></td>
  <td><span data-ttu-id="59098-2460">F476</span><span class="sxs-lookup"><span data-stu-id="59098-2460">F476</span></span></td>
  <td><span data-ttu-id="59098-2461">MobWifiWarning4</span><span class="sxs-lookup"><span data-stu-id="59098-2461">MobWifiWarning4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4A9.png" width="32" height="32" alt="GIF" /></td>
  <td><span data-ttu-id="59098-2462">F4A9</span><span class="sxs-lookup"><span data-stu-id="59098-2462">F4A9</span></span></td>
  <td><span data-ttu-id="59098-2463">GIF</span><span class="sxs-lookup"><span data-stu-id="59098-2463">GIF</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4AA.png" width="32" height="32" alt="Sticker2" /></td>
  <td><span data-ttu-id="59098-2464">F4AA</span><span class="sxs-lookup"><span data-stu-id="59098-2464">F4AA</span></span></td>
  <td><span data-ttu-id="59098-2465">Sticker2</span><span class="sxs-lookup"><span data-stu-id="59098-2465">Sticker2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4BE.png" width="32" height="32" alt="SurfaceHubSelected" /></td>
  <td><span data-ttu-id="59098-2466">F4BE</span><span class="sxs-lookup"><span data-stu-id="59098-2466">F4BE</span></span></td>
  <td><span data-ttu-id="59098-2467">SurfaceHubSelected</span><span class="sxs-lookup"><span data-stu-id="59098-2467">SurfaceHubSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4BF.png" width="32" height="32" alt="HoloLensSelected" /></td>
  <td><span data-ttu-id="59098-2468">F4BF</span><span class="sxs-lookup"><span data-stu-id="59098-2468">F4BF</span></span></td>
  <td><span data-ttu-id="59098-2469">HoloLensSelected</span><span class="sxs-lookup"><span data-stu-id="59098-2469">HoloLensSelected</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4C0.png" width="32" height="32" alt="Earbud" /></td>
  <td><span data-ttu-id="59098-2470">F4C0</span><span class="sxs-lookup"><span data-stu-id="59098-2470">F4C0</span></span></td>
  <td><span data-ttu-id="59098-2471">イヤホン</span><span class="sxs-lookup"><span data-stu-id="59098-2471">Earbud</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F4C3.png" width="32" height="32" alt="MixVolumes" /></td>
  <td><span data-ttu-id="59098-2472">F4C3</span><span class="sxs-lookup"><span data-stu-id="59098-2472">F4C3</span></span></td>
  <td><span data-ttu-id="59098-2473">MixVolumes</span><span class="sxs-lookup"><span data-stu-id="59098-2473">MixVolumes</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F540.png" width="32" height="32" alt="Safe" /></td>
  <td><span data-ttu-id="59098-2474">F540</span><span class="sxs-lookup"><span data-stu-id="59098-2474">F540</span></span></td>
  <td><span data-ttu-id="59098-2475">Safe</span><span class="sxs-lookup"><span data-stu-id="59098-2475">Safe</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F552.png" width="32" height="32" alt="LaptopSecure" /></td>
  <td><span data-ttu-id="59098-2476">F552</span><span class="sxs-lookup"><span data-stu-id="59098-2476">F552</span></span></td>
  <td><span data-ttu-id="59098-2477">LaptopSecure</span><span class="sxs-lookup"><span data-stu-id="59098-2477">LaptopSecure</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F56D.png" width="32" height="32" alt="PrintDefault" /></td>
  <td><span data-ttu-id="59098-2478">F56D</span><span class="sxs-lookup"><span data-stu-id="59098-2478">F56D</span></span></td>
  <td><span data-ttu-id="59098-2479">PrintDefault</span><span class="sxs-lookup"><span data-stu-id="59098-2479">PrintDefault</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F56E.png" width="32" height="32" alt="PageMirrored" /></td>
  <td><span data-ttu-id="59098-2480">F56E</span><span class="sxs-lookup"><span data-stu-id="59098-2480">F56E</span></span></td>
  <td><span data-ttu-id="59098-2481">PageMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2481">PageMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F56F.png" width="32" height="32" alt="LandscapeOrientationMirrored" /></td>
  <td><span data-ttu-id="59098-2482">F56F</span><span class="sxs-lookup"><span data-stu-id="59098-2482">F56F</span></span></td>
  <td><span data-ttu-id="59098-2483">LandscapeOrientationMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2483">LandscapeOrientationMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F570.png" width="32" height="32" alt="ColorOff" /></td>
  <td><span data-ttu-id="59098-2484">F570</span><span class="sxs-lookup"><span data-stu-id="59098-2484">F570</span></span></td>
  <td><span data-ttu-id="59098-2485">ColorOff</span><span class="sxs-lookup"><span data-stu-id="59098-2485">ColorOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F571.png" width="32" height="32" alt="PrintAllPages" /></td>
  <td><span data-ttu-id="59098-2486">F571</span><span class="sxs-lookup"><span data-stu-id="59098-2486">F571</span></span></td>
  <td><span data-ttu-id="59098-2487">PrintAllPages</span><span class="sxs-lookup"><span data-stu-id="59098-2487">PrintAllPages</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F572.png" width="32" height="32" alt="PrintCustomRange" /></td>
  <td><span data-ttu-id="59098-2488">F572</span><span class="sxs-lookup"><span data-stu-id="59098-2488">F572</span></span></td>
  <td><span data-ttu-id="59098-2489">PrintCustomRange</span><span class="sxs-lookup"><span data-stu-id="59098-2489">PrintCustomRange</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F573.png" width="32" height="32" alt="PageMarginPortraitNarrow" /></td>
  <td><span data-ttu-id="59098-2490">F573</span><span class="sxs-lookup"><span data-stu-id="59098-2490">F573</span></span></td>
  <td><span data-ttu-id="59098-2491">PageMarginPortraitNarrow</span><span class="sxs-lookup"><span data-stu-id="59098-2491">PageMarginPortraitNarrow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F574.png" width="32" height="32" alt="PageMarginPortraitNormal" /></td>
  <td><span data-ttu-id="59098-2492">F574</span><span class="sxs-lookup"><span data-stu-id="59098-2492">F574</span></span></td>
  <td><span data-ttu-id="59098-2493">PageMarginPortraitNormal</span><span class="sxs-lookup"><span data-stu-id="59098-2493">PageMarginPortraitNormal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F575.png" width="32" height="32" alt="PageMarginPortraitModerate" /></td>
  <td><span data-ttu-id="59098-2494">F575</span><span class="sxs-lookup"><span data-stu-id="59098-2494">F575</span></span></td>
  <td><span data-ttu-id="59098-2495">PageMarginPortraitModerate</span><span class="sxs-lookup"><span data-stu-id="59098-2495">PageMarginPortraitModerate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F576.png" width="32" height="32" alt="PageMarginPortraitWide" /></td>
  <td><span data-ttu-id="59098-2496">F576</span><span class="sxs-lookup"><span data-stu-id="59098-2496">F576</span></span></td>
  <td><span data-ttu-id="59098-2497">PageMarginPortraitWide</span><span class="sxs-lookup"><span data-stu-id="59098-2497">PageMarginPortraitWide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F577.png" width="32" height="32" alt="PageMarginLandscapeNarrow" /></td>
  <td><span data-ttu-id="59098-2498">F577</span><span class="sxs-lookup"><span data-stu-id="59098-2498">F577</span></span></td>
  <td><span data-ttu-id="59098-2499">PageMarginLandscapeNarrow</span><span class="sxs-lookup"><span data-stu-id="59098-2499">PageMarginLandscapeNarrow</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F578.png" width="32" height="32" alt="PageMarginLandscapeNormal" /></td>
  <td><span data-ttu-id="59098-2500">F578</span><span class="sxs-lookup"><span data-stu-id="59098-2500">F578</span></span></td>
  <td><span data-ttu-id="59098-2501">PageMarginLandscapeNormal</span><span class="sxs-lookup"><span data-stu-id="59098-2501">PageMarginLandscapeNormal</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F579.png" width="32" height="32" alt="PageMarginLandscapeModerate" /></td>
  <td><span data-ttu-id="59098-2502">F579</span><span class="sxs-lookup"><span data-stu-id="59098-2502">F579</span></span></td>
  <td><span data-ttu-id="59098-2503">PageMarginLandscapeModerate</span><span class="sxs-lookup"><span data-stu-id="59098-2503">PageMarginLandscapeModerate</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57A.png" width="32" height="32" alt="PageMarginLandscapeWide" /></td>
  <td><span data-ttu-id="59098-2504">F57A</span><span class="sxs-lookup"><span data-stu-id="59098-2504">F57A</span></span></td>
  <td><span data-ttu-id="59098-2505">PageMarginLandscapeWide</span><span class="sxs-lookup"><span data-stu-id="59098-2505">PageMarginLandscapeWide</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57B.png" width="32" height="32" alt="CollateLandscape" /></td>
  <td><span data-ttu-id="59098-2506">F57B</span><span class="sxs-lookup"><span data-stu-id="59098-2506">F57B</span></span></td>
  <td><span data-ttu-id="59098-2507">CollateLandscape</span><span class="sxs-lookup"><span data-stu-id="59098-2507">CollateLandscape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57C.png" width="32" height="32" alt="CollatePortrait" /></td>
  <td><span data-ttu-id="59098-2508">F57C</span><span class="sxs-lookup"><span data-stu-id="59098-2508">F57C</span></span></td>
  <td><span data-ttu-id="59098-2509">CollatePortrait</span><span class="sxs-lookup"><span data-stu-id="59098-2509">CollatePortrait</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57D.png" width="32" height="32" alt="CollatePortraitSeparated" /></td>
  <td><span data-ttu-id="59098-2510">F57D</span><span class="sxs-lookup"><span data-stu-id="59098-2510">F57D</span></span></td>
  <td><span data-ttu-id="59098-2511">CollatePortraitSeparated</span><span class="sxs-lookup"><span data-stu-id="59098-2511">CollatePortraitSeparated</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57E.png" width="32" height="32" alt="DuplexLandscapeOneSided" /></td>
  <td><span data-ttu-id="59098-2512">F57E</span><span class="sxs-lookup"><span data-stu-id="59098-2512">F57E</span></span></td>
  <td><span data-ttu-id="59098-2513">DuplexLandscapeOneSided</span><span class="sxs-lookup"><span data-stu-id="59098-2513">DuplexLandscapeOneSided</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F57F.png" width="32" height="32" alt="DuplexLandscapeOneSidedMirrored" /></td>
  <td><span data-ttu-id="59098-2514">F57F</span><span class="sxs-lookup"><span data-stu-id="59098-2514">F57F</span></span></td>
  <td><span data-ttu-id="59098-2515">DuplexLandscapeOneSidedMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2515">DuplexLandscapeOneSidedMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F580.png" width="32" height="32" alt="DuplexLandscapeTwoSidedLongEdge" /></td>
  <td><span data-ttu-id="59098-2516">F580</span><span class="sxs-lookup"><span data-stu-id="59098-2516">F580</span></span></td>
  <td><span data-ttu-id="59098-2517">DuplexLandscapeTwoSidedLongEdge</span><span class="sxs-lookup"><span data-stu-id="59098-2517">DuplexLandscapeTwoSidedLongEdge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F581.png" width="32" height="32" alt="DuplexLandscapeTwoSidedLongEdgeMirrored" /></td>
  <td><span data-ttu-id="59098-2518">F581</span><span class="sxs-lookup"><span data-stu-id="59098-2518">F581</span></span></td>
  <td><span data-ttu-id="59098-2519">DuplexLandscapeTwoSidedLongEdgeMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2519">DuplexLandscapeTwoSidedLongEdgeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F582.png" width="32" height="32" alt="DuplexLandscapeTwoSidedShortEdge" /></td>
  <td><span data-ttu-id="59098-2520">F582</span><span class="sxs-lookup"><span data-stu-id="59098-2520">F582</span></span></td>
  <td><span data-ttu-id="59098-2521">DuplexLandscapeTwoSidedShortEdge</span><span class="sxs-lookup"><span data-stu-id="59098-2521">DuplexLandscapeTwoSidedShortEdge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F583.png" width="32" height="32" alt="DuplexLandscapeTwoSidedShortEdgeMirrored" /></td>
  <td><span data-ttu-id="59098-2522">F583</span><span class="sxs-lookup"><span data-stu-id="59098-2522">F583</span></span></td>
  <td><span data-ttu-id="59098-2523">DuplexLandscapeTwoSidedShortEdgeMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2523">DuplexLandscapeTwoSidedShortEdgeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F584.png" width="32" height="32" alt="DuplexPortraitOneSided" /></td>
  <td><span data-ttu-id="59098-2524">F584</span><span class="sxs-lookup"><span data-stu-id="59098-2524">F584</span></span></td>
  <td><span data-ttu-id="59098-2525">DuplexPortraitOneSided</span><span class="sxs-lookup"><span data-stu-id="59098-2525">DuplexPortraitOneSided</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F585.png" width="32" height="32" alt="DuplexPortraitOneSidedMirrored" /></td>
  <td><span data-ttu-id="59098-2526">F585</span><span class="sxs-lookup"><span data-stu-id="59098-2526">F585</span></span></td>
  <td><span data-ttu-id="59098-2527">DuplexPortraitOneSidedMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2527">DuplexPortraitOneSidedMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F586.png" width="32" height="32" alt="DuplexPortraitTwoSidedLongEdge" /></td>
  <td><span data-ttu-id="59098-2528">F586</span><span class="sxs-lookup"><span data-stu-id="59098-2528">F586</span></span></td>
  <td><span data-ttu-id="59098-2529">DuplexPortraitTwoSidedLongEdge</span><span class="sxs-lookup"><span data-stu-id="59098-2529">DuplexPortraitTwoSidedLongEdge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F587.png" width="32" height="32" alt="DuplexPortraitTwoSidedLongEdgeMirrored" /></td>
  <td><span data-ttu-id="59098-2530">F587</span><span class="sxs-lookup"><span data-stu-id="59098-2530">F587</span></span></td>
  <td><span data-ttu-id="59098-2531">DuplexPortraitTwoSidedLongEdgeMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2531">DuplexPortraitTwoSidedLongEdgeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F588.png" width="32" height="32" alt="DuplexPortraitTwoSidedShortEdge" /></td>
  <td><span data-ttu-id="59098-2532">F588</span><span class="sxs-lookup"><span data-stu-id="59098-2532">F588</span></span></td>
  <td><span data-ttu-id="59098-2533">DuplexPortraitTwoSidedShortEdge</span><span class="sxs-lookup"><span data-stu-id="59098-2533">DuplexPortraitTwoSidedShortEdge</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F589.png" width="32" height="32" alt="DuplexPortraitTwoSidedShortEdgeMirrored" /></td>
  <td><span data-ttu-id="59098-2534">F589</span><span class="sxs-lookup"><span data-stu-id="59098-2534">F589</span></span></td>
  <td><span data-ttu-id="59098-2535">DuplexPortraitTwoSidedShortEdgeMirrored</span><span class="sxs-lookup"><span data-stu-id="59098-2535">DuplexPortraitTwoSidedShortEdgeMirrored</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58A.png" width="32" height="32" alt="PPSOneLandscape" /></td>
  <td><span data-ttu-id="59098-2536">F58A</span><span class="sxs-lookup"><span data-stu-id="59098-2536">F58A</span></span></td>
  <td><span data-ttu-id="59098-2537">PPSOneLandscape</span><span class="sxs-lookup"><span data-stu-id="59098-2537">PPSOneLandscape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58B.png" width="32" height="32" alt="PPSTwoLandscape" /></td>
  <td><span data-ttu-id="59098-2538">F58B</span><span class="sxs-lookup"><span data-stu-id="59098-2538">F58B</span></span></td>
  <td><span data-ttu-id="59098-2539">PPSTwoLandscape</span><span class="sxs-lookup"><span data-stu-id="59098-2539">PPSTwoLandscape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58C.png" width="32" height="32" alt="PPSTwoPortrait" /></td>
  <td><span data-ttu-id="59098-2540">F58C</span><span class="sxs-lookup"><span data-stu-id="59098-2540">F58C</span></span></td>
  <td><span data-ttu-id="59098-2541">PPSTwoPortrait</span><span class="sxs-lookup"><span data-stu-id="59098-2541">PPSTwoPortrait</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58D.png" width="32" height="32" alt="PPSFourLandscape" /></td>
  <td><span data-ttu-id="59098-2542">F58D</span><span class="sxs-lookup"><span data-stu-id="59098-2542">F58D</span></span></td>
  <td><span data-ttu-id="59098-2543">PPSFourLandscape</span><span class="sxs-lookup"><span data-stu-id="59098-2543">PPSFourLandscape</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58E.png" width="32" height="32" alt="PPSFourPortrait" /></td>
  <td><span data-ttu-id="59098-2544">F58E</span><span class="sxs-lookup"><span data-stu-id="59098-2544">F58E</span></span></td>
  <td><span data-ttu-id="59098-2545">PPSFourPortrait</span><span class="sxs-lookup"><span data-stu-id="59098-2545">PPSFourPortrait</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F58F.png" width="32" height="32" alt="HolePunchOff" /></td>
  <td><span data-ttu-id="59098-2546">F58F</span><span class="sxs-lookup"><span data-stu-id="59098-2546">F58F</span></span></td>
  <td><span data-ttu-id="59098-2547">HolePunchOff</span><span class="sxs-lookup"><span data-stu-id="59098-2547">HolePunchOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F590.png" width="32" height="32" alt="HolePunchPortraitLeft" /></td>
  <td><span data-ttu-id="59098-2548">F590</span><span class="sxs-lookup"><span data-stu-id="59098-2548">F590</span></span></td>
  <td><span data-ttu-id="59098-2549">HolePunchPortraitLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2549">HolePunchPortraitLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F591.png" width="32" height="32" alt="HolePunchPortraitRight" /></td>
  <td><span data-ttu-id="59098-2550">F591</span><span class="sxs-lookup"><span data-stu-id="59098-2550">F591</span></span></td>
  <td><span data-ttu-id="59098-2551">HolePunchPortraitRight</span><span class="sxs-lookup"><span data-stu-id="59098-2551">HolePunchPortraitRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F592.png" width="32" height="32" alt="HolePunchPortraitTop" /></td>
  <td><span data-ttu-id="59098-2552">F592</span><span class="sxs-lookup"><span data-stu-id="59098-2552">F592</span></span></td>
  <td><span data-ttu-id="59098-2553">HolePunchPortraitTop</span><span class="sxs-lookup"><span data-stu-id="59098-2553">HolePunchPortraitTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F593.png" width="32" height="32" alt="HolePunchPortraitBottom" /></td>
  <td><span data-ttu-id="59098-2554">F593</span><span class="sxs-lookup"><span data-stu-id="59098-2554">F593</span></span></td>
  <td><span data-ttu-id="59098-2555">HolePunchPortraitBottom</span><span class="sxs-lookup"><span data-stu-id="59098-2555">HolePunchPortraitBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F594.png" width="32" height="32" alt="HolePunchLandscapeLeft" /></td>
  <td><span data-ttu-id="59098-2556">F594</span><span class="sxs-lookup"><span data-stu-id="59098-2556">F594</span></span></td>
  <td><span data-ttu-id="59098-2557">HolePunchLandscapeLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2557">HolePunchLandscapeLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F595.png" width="32" height="32" alt="HolePunchLandscapeRight" /></td>
  <td><span data-ttu-id="59098-2558">F595</span><span class="sxs-lookup"><span data-stu-id="59098-2558">F595</span></span></td>
  <td><span data-ttu-id="59098-2559">HolePunchLandscapeRight</span><span class="sxs-lookup"><span data-stu-id="59098-2559">HolePunchLandscapeRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F596.png" width="32" height="32" alt="HolePunchLandscapeTop" /></td>
  <td><span data-ttu-id="59098-2560">F596</span><span class="sxs-lookup"><span data-stu-id="59098-2560">F596</span></span></td>
  <td><span data-ttu-id="59098-2561">HolePunchLandscapeTop</span><span class="sxs-lookup"><span data-stu-id="59098-2561">HolePunchLandscapeTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F597.png" width="32" height="32" alt="HolePunchLandscapeBottom" /></td>
  <td><span data-ttu-id="59098-2562">F597</span><span class="sxs-lookup"><span data-stu-id="59098-2562">F597</span></span></td>
  <td><span data-ttu-id="59098-2563">HolePunchLandscapeBottom</span><span class="sxs-lookup"><span data-stu-id="59098-2563">HolePunchLandscapeBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F598.png" width="32" height="32" alt="StaplingOff" /></td>
  <td><span data-ttu-id="59098-2564">F598</span><span class="sxs-lookup"><span data-stu-id="59098-2564">F598</span></span></td>
  <td><span data-ttu-id="59098-2565">StaplingOff</span><span class="sxs-lookup"><span data-stu-id="59098-2565">StaplingOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F599.png" width="32" height="32" alt="StaplingPortraitTopLeft" /></td>
  <td><span data-ttu-id="59098-2566">F599</span><span class="sxs-lookup"><span data-stu-id="59098-2566">F599</span></span></td>
  <td><span data-ttu-id="59098-2567">StaplingPortraitTopLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2567">StaplingPortraitTopLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59A.png" width="32" height="32" alt="StaplingPortraitTopRight" /></td>
  <td><span data-ttu-id="59098-2568">F59A</span><span class="sxs-lookup"><span data-stu-id="59098-2568">F59A</span></span></td>
  <td><span data-ttu-id="59098-2569">StaplingPortraitTopRight</span><span class="sxs-lookup"><span data-stu-id="59098-2569">StaplingPortraitTopRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59B.png" width="32" height="32" alt="StaplingPortraitBottomRight" /></td>
  <td><span data-ttu-id="59098-2570">F59B</span><span class="sxs-lookup"><span data-stu-id="59098-2570">F59B</span></span></td>
  <td><span data-ttu-id="59098-2571">StaplingPortraitBottomRight</span><span class="sxs-lookup"><span data-stu-id="59098-2571">StaplingPortraitBottomRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59C.png" width="32" height="32" alt="StaplingPortraitTwoLeft" /></td>
  <td><span data-ttu-id="59098-2572">F59C</span><span class="sxs-lookup"><span data-stu-id="59098-2572">F59C</span></span></td>
  <td><span data-ttu-id="59098-2573">StaplingPortraitTwoLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2573">StaplingPortraitTwoLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59D.png" width="32" height="32" alt="StaplingPortraitTwoRight" /></td>
  <td><span data-ttu-id="59098-2574">F59D</span><span class="sxs-lookup"><span data-stu-id="59098-2574">F59D</span></span></td>
  <td><span data-ttu-id="59098-2575">StaplingPortraitTwoRight</span><span class="sxs-lookup"><span data-stu-id="59098-2575">StaplingPortraitTwoRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59E.png" width="32" height="32" alt="StaplingPortraitTwoTop" /></td>
  <td><span data-ttu-id="59098-2576">F59E</span><span class="sxs-lookup"><span data-stu-id="59098-2576">F59E</span></span></td>
  <td><span data-ttu-id="59098-2577">StaplingPortraitTwoTop</span><span class="sxs-lookup"><span data-stu-id="59098-2577">StaplingPortraitTwoTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F59F.png" width="32" height="32" alt="StaplingPortraitTwoBottom" /></td>
  <td><span data-ttu-id="59098-2578">F59F</span><span class="sxs-lookup"><span data-stu-id="59098-2578">F59F</span></span></td>
  <td><span data-ttu-id="59098-2579">StaplingPortraitTwoBottom</span><span class="sxs-lookup"><span data-stu-id="59098-2579">StaplingPortraitTwoBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A0.png" width="32" height="32" alt="StaplingPortraitBookBinding" /></td>
  <td><span data-ttu-id="59098-2580">F5A0</span><span class="sxs-lookup"><span data-stu-id="59098-2580">F5A0</span></span></td>
  <td><span data-ttu-id="59098-2581">StaplingPortraitBookBinding</span><span class="sxs-lookup"><span data-stu-id="59098-2581">StaplingPortraitBookBinding</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A1.png" width="32" height="32" alt="StaplingLandscapeTopLeft" /></td>
  <td><span data-ttu-id="59098-2582">F5A1</span><span class="sxs-lookup"><span data-stu-id="59098-2582">F5A1</span></span></td>
  <td><span data-ttu-id="59098-2583">StaplingLandscapeTopLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2583">StaplingLandscapeTopLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A2.png" width="32" height="32" alt="StaplingLandscapeTopRight" /></td>
  <td><span data-ttu-id="59098-2584">F5A2</span><span class="sxs-lookup"><span data-stu-id="59098-2584">F5A2</span></span></td>
  <td><span data-ttu-id="59098-2585">StaplingLandscapeTopRight</span><span class="sxs-lookup"><span data-stu-id="59098-2585">StaplingLandscapeTopRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A3.png" width="32" height="32" alt="StaplingLandscapeBottomLeft" /></td>
  <td><span data-ttu-id="59098-2586">F5A3</span><span class="sxs-lookup"><span data-stu-id="59098-2586">F5A3</span></span></td>
  <td><span data-ttu-id="59098-2587">StaplingLandscapeBottomLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2587">StaplingLandscapeBottomLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A4.png" width="32" height="32" alt="StaplingLandscapeBottomRight" /></td>
  <td><span data-ttu-id="59098-2588">F5A4</span><span class="sxs-lookup"><span data-stu-id="59098-2588">F5A4</span></span></td>
  <td><span data-ttu-id="59098-2589">StaplingLandscapeBottomRight</span><span class="sxs-lookup"><span data-stu-id="59098-2589">StaplingLandscapeBottomRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A5.png" width="32" height="32" alt="StaplingLandscapeTwoLeft" /></td>
  <td><span data-ttu-id="59098-2590">F5A5</span><span class="sxs-lookup"><span data-stu-id="59098-2590">F5A5</span></span></td>
  <td><span data-ttu-id="59098-2591">StaplingLandscapeTwoLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2591">StaplingLandscapeTwoLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A6.png" width="32" height="32" alt="StaplingLandscapeTwoRight" /></td>
  <td><span data-ttu-id="59098-2592">F5A6</span><span class="sxs-lookup"><span data-stu-id="59098-2592">F5A6</span></span></td>
  <td><span data-ttu-id="59098-2593">StaplingLandscapeTwoRight</span><span class="sxs-lookup"><span data-stu-id="59098-2593">StaplingLandscapeTwoRight</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A7.png" width="32" height="32" alt="StaplingLandscapeTwoTop" /></td>
  <td><span data-ttu-id="59098-2594">F5A7</span><span class="sxs-lookup"><span data-stu-id="59098-2594">F5A7</span></span></td>
  <td><span data-ttu-id="59098-2595">StaplingLandscapeTwoTop</span><span class="sxs-lookup"><span data-stu-id="59098-2595">StaplingLandscapeTwoTop</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A8.png" width="32" height="32" alt="StaplingLandscapeTwoBottom" /></td>
  <td><span data-ttu-id="59098-2596">F5A8</span><span class="sxs-lookup"><span data-stu-id="59098-2596">F5A8</span></span></td>
  <td><span data-ttu-id="59098-2597">StaplingLandscapeTwoBottom</span><span class="sxs-lookup"><span data-stu-id="59098-2597">StaplingLandscapeTwoBottom</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5A9.png" width="32" height="32" alt="StaplingLandscapeBookBinding" /></td>
  <td><span data-ttu-id="59098-2598">F5A9</span><span class="sxs-lookup"><span data-stu-id="59098-2598">F5A9</span></span></td>
  <td><span data-ttu-id="59098-2599">StaplingLandscapeBookBinding</span><span class="sxs-lookup"><span data-stu-id="59098-2599">StaplingLandscapeBookBinding</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5AB.png" width="32" height="32" alt="MobSIMError" /></td>
  <td><span data-ttu-id="59098-2600">F5AB</span><span class="sxs-lookup"><span data-stu-id="59098-2600">F5AB</span></span></td>
  <td><span data-ttu-id="59098-2601">MobSIMError</span><span class="sxs-lookup"><span data-stu-id="59098-2601">MobSIMError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5AC.png" width="32" height="32" alt="CollateLandscapeSeparated" /></td>
  <td><span data-ttu-id="59098-2602">F5AC</span><span class="sxs-lookup"><span data-stu-id="59098-2602">F5AC</span></span></td>
  <td><span data-ttu-id="59098-2603">CollateLandscapeSeparated</span><span class="sxs-lookup"><span data-stu-id="59098-2603">CollateLandscapeSeparated</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5AD.png" width="32" height="32" alt="PPSOnePortrait" /></td>
  <td><span data-ttu-id="59098-2604">F5AD</span><span class="sxs-lookup"><span data-stu-id="59098-2604">F5AD</span></span></td>
  <td><span data-ttu-id="59098-2605">PPSOnePortrait</span><span class="sxs-lookup"><span data-stu-id="59098-2605">PPSOnePortrait</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5AE.png" width="32" height="32" alt="StaplingPortraitBottomLeft" /></td>
  <td><span data-ttu-id="59098-2606">F5AE</span><span class="sxs-lookup"><span data-stu-id="59098-2606">F5AE</span></span></td>
  <td><span data-ttu-id="59098-2607">StaplingPortraitBottomLeft</span><span class="sxs-lookup"><span data-stu-id="59098-2607">StaplingPortraitBottomLeft</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5B0.png" width="32" height="32" alt="PlaySolid" /></td>
  <td><span data-ttu-id="59098-2608">F5B0</span><span class="sxs-lookup"><span data-stu-id="59098-2608">F5B0</span></span></td>
  <td><span data-ttu-id="59098-2609">PlaySolid</span><span class="sxs-lookup"><span data-stu-id="59098-2609">PlaySolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5ED.png" width="32" height="32" alt="Set" /></td>
  <td><span data-ttu-id="59098-2610">F5ED</span><span class="sxs-lookup"><span data-stu-id="59098-2610">F5ED</span></span></td>
  <td><span data-ttu-id="59098-2611">設定</span><span class="sxs-lookup"><span data-stu-id="59098-2611">Set</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5EE.png" width="32" height="32" alt="SetSolid" /></td>
  <td><span data-ttu-id="59098-2612">F5EE</span><span class="sxs-lookup"><span data-stu-id="59098-2612">F5EE</span></span></td>
  <td><span data-ttu-id="59098-2613">SetSolid</span><span class="sxs-lookup"><span data-stu-id="59098-2613">SetSolid</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5EF.png" width="32" height="32" alt="FuzzyReading" /></td>
  <td><span data-ttu-id="59098-2614">F5EF</span><span class="sxs-lookup"><span data-stu-id="59098-2614">F5EF</span></span></td>
  <td><span data-ttu-id="59098-2615">FuzzyReading</span><span class="sxs-lookup"><span data-stu-id="59098-2615">FuzzyReading</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F2.png" width="32" height="32" alt="VerticalBattery0" /></td>
  <td><span data-ttu-id="59098-2616">F5F2</span><span class="sxs-lookup"><span data-stu-id="59098-2616">F5F2</span></span></td>
  <td><span data-ttu-id="59098-2617">VerticalBattery0</span><span class="sxs-lookup"><span data-stu-id="59098-2617">VerticalBattery0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F3.png" width="32" height="32" alt="VerticalBattery1" /></td>
  <td><span data-ttu-id="59098-2618">F5F3</span><span class="sxs-lookup"><span data-stu-id="59098-2618">F5F3</span></span></td>
  <td><span data-ttu-id="59098-2619">VerticalBattery1</span><span class="sxs-lookup"><span data-stu-id="59098-2619">VerticalBattery1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F4.png" width="32" height="32" alt="VerticalBattery2" /></td>
  <td><span data-ttu-id="59098-2620">F5F4</span><span class="sxs-lookup"><span data-stu-id="59098-2620">F5F4</span></span></td>
  <td><span data-ttu-id="59098-2621">VerticalBattery2</span><span class="sxs-lookup"><span data-stu-id="59098-2621">VerticalBattery2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F5.png" width="32" height="32" alt="VerticalBattery3" /></td>
  <td><span data-ttu-id="59098-2622">F5F5</span><span class="sxs-lookup"><span data-stu-id="59098-2622">F5F5</span></span></td>
  <td><span data-ttu-id="59098-2623">VerticalBattery3</span><span class="sxs-lookup"><span data-stu-id="59098-2623">VerticalBattery3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F6.png" width="32" height="32" alt="VerticalBattery4" /></td>
  <td><span data-ttu-id="59098-2624">F5F6</span><span class="sxs-lookup"><span data-stu-id="59098-2624">F5F6</span></span></td>
  <td><span data-ttu-id="59098-2625">VerticalBattery4</span><span class="sxs-lookup"><span data-stu-id="59098-2625">VerticalBattery4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F7.png" width="32" height="32" alt="VerticalBattery5" /></td>
  <td><span data-ttu-id="59098-2626">F5F7</span><span class="sxs-lookup"><span data-stu-id="59098-2626">F5F7</span></span></td>
  <td><span data-ttu-id="59098-2627">VerticalBattery5</span><span class="sxs-lookup"><span data-stu-id="59098-2627">VerticalBattery5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F8.png" width="32" height="32" alt="VerticalBattery6" /></td>
  <td><span data-ttu-id="59098-2628">F5F8</span><span class="sxs-lookup"><span data-stu-id="59098-2628">F5F8</span></span></td>
  <td><span data-ttu-id="59098-2629">VerticalBattery6</span><span class="sxs-lookup"><span data-stu-id="59098-2629">VerticalBattery6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5F9.png" width="32" height="32" alt="VerticalBattery7" /></td>
  <td><span data-ttu-id="59098-2630">F5F9</span><span class="sxs-lookup"><span data-stu-id="59098-2630">F5F9</span></span></td>
  <td><span data-ttu-id="59098-2631">VerticalBattery7</span><span class="sxs-lookup"><span data-stu-id="59098-2631">VerticalBattery7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FA.png" width="32" height="32" alt="VerticalBattery8" /></td>
  <td><span data-ttu-id="59098-2632">F5FA</span><span class="sxs-lookup"><span data-stu-id="59098-2632">F5FA</span></span></td>
  <td><span data-ttu-id="59098-2633">VerticalBattery8</span><span class="sxs-lookup"><span data-stu-id="59098-2633">VerticalBattery8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FB.png" width="32" height="32" alt="VerticalBattery9" /></td>
  <td><span data-ttu-id="59098-2634">F5FB</span><span class="sxs-lookup"><span data-stu-id="59098-2634">F5FB</span></span></td>
  <td><span data-ttu-id="59098-2635">VerticalBattery9</span><span class="sxs-lookup"><span data-stu-id="59098-2635">VerticalBattery9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FC.png" width="32" height="32" alt="VerticalBattery10" /></td>
  <td><span data-ttu-id="59098-2636">F5FC</span><span class="sxs-lookup"><span data-stu-id="59098-2636">F5FC</span></span></td>
  <td><span data-ttu-id="59098-2637">VerticalBattery10</span><span class="sxs-lookup"><span data-stu-id="59098-2637">VerticalBattery10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FD.png" width="32" height="32" alt="VerticalBatteryCharging0" /></td>
  <td><span data-ttu-id="59098-2638">F5FD</span><span class="sxs-lookup"><span data-stu-id="59098-2638">F5FD</span></span></td>
  <td><span data-ttu-id="59098-2639">VerticalBatteryCharging0</span><span class="sxs-lookup"><span data-stu-id="59098-2639">VerticalBatteryCharging0</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FE.png" width="32" height="32" alt="VerticalBatteryCharging1" /></td>
  <td><span data-ttu-id="59098-2640">F5FE</span><span class="sxs-lookup"><span data-stu-id="59098-2640">F5FE</span></span></td>
  <td><span data-ttu-id="59098-2641">VerticalBatteryCharging1</span><span class="sxs-lookup"><span data-stu-id="59098-2641">VerticalBatteryCharging1</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F5FF.png" width="32" height="32" alt="VerticalBatteryCharging2" /></td>
  <td><span data-ttu-id="59098-2642">F5FF</span><span class="sxs-lookup"><span data-stu-id="59098-2642">F5FF</span></span></td>
  <td><span data-ttu-id="59098-2643">VerticalBatteryCharging2</span><span class="sxs-lookup"><span data-stu-id="59098-2643">VerticalBatteryCharging2</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F600.png" width="32" height="32" alt="VerticalBatteryCharging3" /></td>
  <td><span data-ttu-id="59098-2644">F600</span><span class="sxs-lookup"><span data-stu-id="59098-2644">F600</span></span></td>
  <td><span data-ttu-id="59098-2645">VerticalBatteryCharging3</span><span class="sxs-lookup"><span data-stu-id="59098-2645">VerticalBatteryCharging3</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F601.png" width="32" height="32" alt="VerticalBatteryCharging4" /></td>
  <td><span data-ttu-id="59098-2646">F601</span><span class="sxs-lookup"><span data-stu-id="59098-2646">F601</span></span></td>
  <td><span data-ttu-id="59098-2647">VerticalBatteryCharging4</span><span class="sxs-lookup"><span data-stu-id="59098-2647">VerticalBatteryCharging4</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F602.png" width="32" height="32" alt="VerticalBatteryCharging5" /></td>
  <td><span data-ttu-id="59098-2648">F602</span><span class="sxs-lookup"><span data-stu-id="59098-2648">F602</span></span></td>
  <td><span data-ttu-id="59098-2649">VerticalBatteryCharging5</span><span class="sxs-lookup"><span data-stu-id="59098-2649">VerticalBatteryCharging5</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F603.png" width="32" height="32" alt="VerticalBatteryCharging6" /></td>
  <td><span data-ttu-id="59098-2650">F603</span><span class="sxs-lookup"><span data-stu-id="59098-2650">F603</span></span></td>
  <td><span data-ttu-id="59098-2651">VerticalBatteryCharging6</span><span class="sxs-lookup"><span data-stu-id="59098-2651">VerticalBatteryCharging6</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F604.png" width="32" height="32" alt="VerticalBatteryCharging7" /></td>
  <td><span data-ttu-id="59098-2652">F604</span><span class="sxs-lookup"><span data-stu-id="59098-2652">F604</span></span></td>
  <td><span data-ttu-id="59098-2653">VerticalBatteryCharging7</span><span class="sxs-lookup"><span data-stu-id="59098-2653">VerticalBatteryCharging7</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F605.png" width="32" height="32" alt="VerticalBatteryCharging8" /></td>
  <td><span data-ttu-id="59098-2654">F605</span><span class="sxs-lookup"><span data-stu-id="59098-2654">F605</span></span></td>
  <td><span data-ttu-id="59098-2655">VerticalBatteryCharging8</span><span class="sxs-lookup"><span data-stu-id="59098-2655">VerticalBatteryCharging8</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F606.png" width="32" height="32" alt="VerticalBatteryCharging9" /></td>
  <td><span data-ttu-id="59098-2656">F606</span><span class="sxs-lookup"><span data-stu-id="59098-2656">F606</span></span></td>
  <td><span data-ttu-id="59098-2657">VerticalBatteryCharging9</span><span class="sxs-lookup"><span data-stu-id="59098-2657">VerticalBatteryCharging9</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F607.png" width="32" height="32" alt="VerticalBatteryCharging10" /></td>
  <td><span data-ttu-id="59098-2658">F607</span><span class="sxs-lookup"><span data-stu-id="59098-2658">F607</span></span></td>
  <td><span data-ttu-id="59098-2659">VerticalBatteryCharging10</span><span class="sxs-lookup"><span data-stu-id="59098-2659">VerticalBatteryCharging10</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F608.png" width="32" height="32" alt="VerticalBatteryUnknown" /></td>
  <td><span data-ttu-id="59098-2660">F608</span><span class="sxs-lookup"><span data-stu-id="59098-2660">F608</span></span></td>
  <td><span data-ttu-id="59098-2661">VerticalBatteryUnknown</span><span class="sxs-lookup"><span data-stu-id="59098-2661">VerticalBatteryUnknown</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F618.png" width="32" height="32" alt="SIMError" /></td>
  <td><span data-ttu-id="59098-2662">F618</span><span class="sxs-lookup"><span data-stu-id="59098-2662">F618</span></span></td>
  <td><span data-ttu-id="59098-2663">SIMError</span><span class="sxs-lookup"><span data-stu-id="59098-2663">SIMError</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F619.png" width="32" height="32" alt="SIMMissing" /></td>
  <td><span data-ttu-id="59098-2664">F619</span><span class="sxs-lookup"><span data-stu-id="59098-2664">F619</span></span></td>
  <td><span data-ttu-id="59098-2665">SIMMissing</span><span class="sxs-lookup"><span data-stu-id="59098-2665">SIMMissing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61A.png" width="32" height="32" alt="SIMLock" /></td>
  <td><span data-ttu-id="59098-2666">F61A</span><span class="sxs-lookup"><span data-stu-id="59098-2666">F61A</span></span></td>
  <td><span data-ttu-id="59098-2667">SIMLock</span><span class="sxs-lookup"><span data-stu-id="59098-2667">SIMLock</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61B.png" width="32" height="32" alt="eSIM" /></td>
  <td><span data-ttu-id="59098-2668">F61B</span><span class="sxs-lookup"><span data-stu-id="59098-2668">F61B</span></span></td>
  <td><span data-ttu-id="59098-2669">eSIM</span><span class="sxs-lookup"><span data-stu-id="59098-2669">eSIM</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61C.png" width="32" height="32" alt="eSIMNoProfile" /></td>
  <td><span data-ttu-id="59098-2670">F61C</span><span class="sxs-lookup"><span data-stu-id="59098-2670">F61C</span></span></td>
  <td><span data-ttu-id="59098-2671">eSIMNoProfile</span><span class="sxs-lookup"><span data-stu-id="59098-2671">eSIMNoProfile</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61D.png" width="32" height="32" alt="eSIMLocked" /></td>
  <td><span data-ttu-id="59098-2672">F61D</span><span class="sxs-lookup"><span data-stu-id="59098-2672">F61D</span></span></td>
  <td><span data-ttu-id="59098-2673">eSIMLocked</span><span class="sxs-lookup"><span data-stu-id="59098-2673">eSIMLocked</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61E.png" width="32" height="32" alt="eSIMBusy" /></td>
  <td><span data-ttu-id="59098-2674">F61E</span><span class="sxs-lookup"><span data-stu-id="59098-2674">F61E</span></span></td>
  <td><span data-ttu-id="59098-2675">eSIMBusy</span><span class="sxs-lookup"><span data-stu-id="59098-2675">eSIMBusy</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F61F.png" width="32" height="32" alt="NoiseCancelation" /></td>
  <td><span data-ttu-id="59098-2676">F61F</span><span class="sxs-lookup"><span data-stu-id="59098-2676">F61F</span></span></td>
  <td><span data-ttu-id="59098-2677">NoiseCancelation</span><span class="sxs-lookup"><span data-stu-id="59098-2677">NoiseCancelation</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F620.png" width="32" height="32" alt="NoiseCancelationOff" /></td>
  <td><span data-ttu-id="59098-2678">F620</span><span class="sxs-lookup"><span data-stu-id="59098-2678">F620</span></span></td>
  <td><span data-ttu-id="59098-2679">NoiseCancelationOff</span><span class="sxs-lookup"><span data-stu-id="59098-2679">NoiseCancelationOff</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F623.png" width="32" height="32" alt="MusicSharing" /></td>
  <td><span data-ttu-id="59098-2680">F623</span><span class="sxs-lookup"><span data-stu-id="59098-2680">F623</span></span></td>
  <td><span data-ttu-id="59098-2681">MusicSharing</span><span class="sxs-lookup"><span data-stu-id="59098-2681">MusicSharing</span></span></td>
 </tr>
<tr><td><img src="images/segoe-mdl/F624.png" width="32" height="32" alt="MusicSharingOff" /></td>
  <td><span data-ttu-id="59098-2682">F624</span><span class="sxs-lookup"><span data-stu-id="59098-2682">F624</span></span></td>
  <td><span data-ttu-id="59098-2683">MusicSharingOff</span><span class="sxs-lookup"><span data-stu-id="59098-2683">MusicSharingOff</span></span></td>
 </tr>
</table>



## <a name="related-articles"></a><span data-ttu-id="59098-2684">関連記事</span><span class="sxs-lookup"><span data-stu-id="59098-2684">Related articles</span></span>

* [<span data-ttu-id="59098-2685">アイコンのガイドライン</span><span class="sxs-lookup"><span data-stu-id="59098-2685">Guidelines for icons</span></span>](../style/icons.md)
* [<span data-ttu-id="59098-2686">Symbol 列挙型</span><span class="sxs-lookup"><span data-stu-id="59098-2686">Symbol enumeration</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Symbol)
* [<span data-ttu-id="59098-2687">FontIcon クラス</span><span class="sxs-lookup"><span data-stu-id="59098-2687">FontIcon class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticon)


