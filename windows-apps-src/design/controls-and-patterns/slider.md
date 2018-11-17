---
author: QuinnRadich
Description: Lets the user set a value in a given range.
title: スライダー
ms.assetid: 7EC7EA33-BE7E-4FD5-B205-B8FA7B729ACC
label: Sliders
template: detail.hbs
ms.author: quradic
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 2b6512782d5fa3423dcfee98c98223d77995deeb
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7150398"
---
# <a name="sliders"></a><span data-ttu-id="14eda-103">スライダー</span><span class="sxs-lookup"><span data-stu-id="14eda-103">Sliders</span></span>

 

<span data-ttu-id="14eda-104">スライダーはユーザーがトラックに沿って thumb コントロールを動かすことで値の範囲から選択できるようにするコントロールです。</span><span class="sxs-lookup"><span data-stu-id="14eda-104">A slider is a control that lets the user select from a range of values by moving a thumb control along a track.</span></span>

> <span data-ttu-id="14eda-105">**重要な API**: [Slider クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx)、[Value プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.value.aspx)、[ValueChanged イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.valuechanged.aspx)</span><span class="sxs-lookup"><span data-stu-id="14eda-105">**Important APIs**: [Slider class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx), [Value property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.value.aspx), [ValueChanged event](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.valuechanged.aspx)</span></span>

![スライダー コントロール](images/controls/slider.png)


## <a name="is-this-the-right-control"></a><span data-ttu-id="14eda-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="14eda-107">Is this the right control?</span></span>

<span data-ttu-id="14eda-108">定義された連続的な値 (音量や明るさなど) または個別の値の範囲 (画面解像度の設定など) をユーザーが設定できるようにする場合に、スライダーを使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-108">Use a slider when you want your users to be able to set defined, contiguous values (such as volume or brightness) or a range of discrete values (such as screen resolution settings).</span></span>

<span data-ttu-id="14eda-109">スライダーは、ユーザーが値を数値でなく相対的な量であると考えている場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="14eda-109">A slider is a good choice when you know that users think of the value as a relative quantity, not a numeric value.</span></span> <span data-ttu-id="14eda-110">たとえば、ユーザーはオーディオの音量を数値の 2 や 5 ではなく、低や中に設定しようと考えます。</span><span class="sxs-lookup"><span data-stu-id="14eda-110">For example, users think about setting their audio volume to low or medium—not about setting the value to 2 or 5.</span></span>

<span data-ttu-id="14eda-111">二者択一の設定には、スライダーは使いません。</span><span class="sxs-lookup"><span data-stu-id="14eda-111">Don't use a slider for binary settings.</span></span> <span data-ttu-id="14eda-112">代わりに[トグル スイッチ](toggles.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-112">Use a [toggle switch](toggles.md) instead.</span></span>

<span data-ttu-id="14eda-113">スライダーを使うかどうかを決める際には、他にも次のような点を考慮します。</span><span class="sxs-lookup"><span data-stu-id="14eda-113">Here are some additional factors to consider when deciding whether to use a slider:</span></span>

-   **<span data-ttu-id="14eda-114">設定が相対的な量のように見えるか?</span><span class="sxs-lookup"><span data-stu-id="14eda-114">Does the setting seem like a relative quantity?</span></span>** <span data-ttu-id="14eda-115">見えない場合は、[ラジオ ボタン](radio-button.md)または[リスト ボックス](lists.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-115">If not, use [radio buttons](radio-button.md) or a [list box](lists.md).</span></span>
-   **<span data-ttu-id="14eda-116">設定は正確な既知の数値か?</span><span class="sxs-lookup"><span data-stu-id="14eda-116">Is the setting an exact, known numeric value?</span></span>** <span data-ttu-id="14eda-117">その場合は、数値[テキスト ボックス](text-box.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-117">If so, use a numeric [text box](text-box.md).</span></span>
-   **<span data-ttu-id="14eda-118">設定の変更による効果をすぐに確認できると、ユーザーにとって便利か?</span><span class="sxs-lookup"><span data-stu-id="14eda-118">Would a user benefit from instant feedback on the effect of setting changes?</span></span>** <span data-ttu-id="14eda-119">便利である場合は、スライダーを使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-119">If so, use a slider.</span></span> <span data-ttu-id="14eda-120">たとえば、色合い、鮮やかさ、明度の値を変更した場合の効果をすぐに確認できると、ユーザーは色をより簡単に選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="14eda-120">For example, users can choose a color more easily by immediately seeing the effect of changes to hue, saturation, or luminosity values.</span></span>
-   **<span data-ttu-id="14eda-121">設定に 4 つ以上の値の範囲があるか?</span><span class="sxs-lookup"><span data-stu-id="14eda-121">Does the setting have a range of four or more values?</span></span>** <span data-ttu-id="14eda-122">ない場合は、[ラジオ ボタン](radio-button.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-122">If not, use [radio buttons](radio-button.md).</span></span>
-   **<span data-ttu-id="14eda-123">ユーザーが値を変えられるか?</span><span class="sxs-lookup"><span data-stu-id="14eda-123">Can the user change the value?</span></span>** <span data-ttu-id="14eda-124">スライダーは、ユーザーの操作用です。</span><span class="sxs-lookup"><span data-stu-id="14eda-124">Sliders are for user interaction.</span></span> <span data-ttu-id="14eda-125">ユーザーが値を変えられない場合は、代わりに読み取り専用のテキストを使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-125">If a user can't ever change the value, use read-only text instead.</span></span>

<span data-ttu-id="14eda-126">スライダーと数値テキスト ボックスのどちらを使うかを決める際に、次の場合には数値テキスト ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-126">If you are deciding between a slider and a numeric text box, use a numeric text box if:</span></span>

-   <span data-ttu-id="14eda-127">画面領域が狭い。</span><span class="sxs-lookup"><span data-stu-id="14eda-127">Screen space is tight.</span></span>
-   <span data-ttu-id="14eda-128">ユーザーがキーボードを使おうとする可能性が高い。</span><span class="sxs-lookup"><span data-stu-id="14eda-128">The user is likely to prefer using the keyboard.</span></span>

<span data-ttu-id="14eda-129">次の場合にはスライダーを使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-129">Use a slider if:</span></span>

-   <span data-ttu-id="14eda-130">ユーザーにとって、すぐに結果がわかると便利。</span><span class="sxs-lookup"><span data-stu-id="14eda-130">Users will benefit from instant feedback.</span></span>

## <a name="examples"></a><span data-ttu-id="14eda-131">例</span><span class="sxs-lookup"><span data-stu-id="14eda-131">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="14eda-132">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="14eda-132">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="14eda-133"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Slider">アプリを開き、Slider の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="14eda-133">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Slider">open the app and see the Slider in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="14eda-134">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="14eda-134">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="14eda-135">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="14eda-135">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="14eda-136">Windows Phone の音量を制御するためのスライダー。</span><span class="sxs-lookup"><span data-stu-id="14eda-136">A slider to control the volume on Windows Phone.</span></span>

![Windows Phone の音量を制御するためのスライダー](images/control-examples/slider-phone.png)

<span data-ttu-id="14eda-138">Windows 画面設定でテキスト サイズを変更するためのスライダー。</span><span class="sxs-lookup"><span data-stu-id="14eda-138">A slider to change text size in Windows display settings.</span></span>

![Windows 画面設定でテキスト サイズを変更するためのスライダー](images/control-examples/slider-display-settings.png)

## <a name="create-a-slider"></a><span data-ttu-id="14eda-140">スライダーの作成</span><span class="sxs-lookup"><span data-stu-id="14eda-140">Create a slider</span></span>

<span data-ttu-id="14eda-141">XAML でスライダーを作成する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-141">Here's how to create a slider in XAML.</span></span>

```xaml
<Slider x:Name="volumeSlider" Header="Volume" Width="200"
        ValueChanged="Slider_ValueChanged"/>
```

<span data-ttu-id="14eda-142">コードでスライダーを作成する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-142">Here's how to create a slider in code.</span></span>

```csharp
Slider volumeSlider = new Slider();
volumeSlider.Header = "Volume";
volumeSlider.Width = 200;
volumeSlider.ValueChanged += Slider_ValueChanged;

// Add the slider to a parent container in the visual tree.
stackPanel1.Children.Add(volumeSlider);
```

<span data-ttu-id="14eda-143">[Value](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.value.aspx) プロパティからスライダーの値を取得および設定します。</span><span class="sxs-lookup"><span data-stu-id="14eda-143">You get and set the value of the slider from the [Value](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.value.aspx) property.</span></span> <span data-ttu-id="14eda-144">値の変更に応答するには、Value プロパティにバインドするデータ バインディングを使うか、[ValueChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.valuechanged.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="14eda-144">To respond to value changes, you can use data binding to bind to the Value property, or handle the [ValueChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.valuechanged.aspx) event.</span></span>

```csharp
private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
{
    Slider slider = sender as Slider;
    if (slider != null)
    {
        media.Volume = slider.Value;
    }
}
```

## <a name="recommendations"></a><span data-ttu-id="14eda-145">推奨事項</span><span class="sxs-lookup"><span data-stu-id="14eda-145">Recommendations</span></span>

-   <span data-ttu-id="14eda-146">コントロールのサイズは、ユーザーが値を簡単に設定できる大きさにします。</span><span class="sxs-lookup"><span data-stu-id="14eda-146">Size the control so that users can easily set the value they want.</span></span> <span data-ttu-id="14eda-147">個別の値を設定する場合は、ユーザーがマウスを使って値を簡単に選べるようにします。</span><span class="sxs-lookup"><span data-stu-id="14eda-147">For settings with discrete values, make sure the user can easily select any value using the mouse.</span></span> <span data-ttu-id="14eda-148">スライダーのエンドポイントが、常にビューの境界内にあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="14eda-148">Make sure the endpoints of the slider always fit within the bounds of a view.</span></span>
-   <span data-ttu-id="14eda-149">ユーザーが選んでいるときまたは選んだ後で、すぐに結果が確認できるようにします (それが実際的な場合)。</span><span class="sxs-lookup"><span data-stu-id="14eda-149">Give immediate feedback while or after a user makes a selection (when practical).</span></span> <span data-ttu-id="14eda-150">たとえば、Windows のボリューム コントロールは、選ばれたオーディオ音量を示すためにビープ音を鳴らします。</span><span class="sxs-lookup"><span data-stu-id="14eda-150">For example, the Windows volume control beeps to indicate the selected audio volume.</span></span>
-   <span data-ttu-id="14eda-151">値の範囲を示すためにラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-151">Use labels to show the range of values.</span></span> <span data-ttu-id="14eda-152">例外: スライダーが垂直方向で、上部のラベルが最大、高、多などの場合、下部の意味は明らかであるため、ラベルを省略できます。</span><span class="sxs-lookup"><span data-stu-id="14eda-152">Exception: If the slider is vertically oriented and the top label is Maximum, High, More, or equivalent, you can omit the other labels because the meaning is clear.</span></span>
-   <span data-ttu-id="14eda-153">スライダーを無効にする場合は、関連するすべてのラベルまたはフィードバックの視覚効果も無効にします。</span><span class="sxs-lookup"><span data-stu-id="14eda-153">Disable all associated labels or feedback visuals when you disable the slider.</span></span>
-   <span data-ttu-id="14eda-154">スライダーのフロー方向や向きを設定するときには、テキストの方向を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="14eda-154">Consider the direction of text when setting the flow direction and/or orientation of your slider.</span></span> <span data-ttu-id="14eda-155">言語によって、左から右に書く場合と、右から左に書く場合があります。</span><span class="sxs-lookup"><span data-stu-id="14eda-155">Script flows from left to right in some languages, and from right to left in others.</span></span>
-   <span data-ttu-id="14eda-156">スライダーは、進行状況インジケーターとしては使いません。</span><span class="sxs-lookup"><span data-stu-id="14eda-156">Don't use a slider as a progress indicator.</span></span>
-   <span data-ttu-id="14eda-157">スライダーのつまみは、既定のサイズのままにします。</span><span class="sxs-lookup"><span data-stu-id="14eda-157">Don't change the size of the slider thumb from the default size.</span></span>
-   <span data-ttu-id="14eda-158">値の範囲が広く、ユーザーが選ぶのは範囲内のいくつかの代表的な値であることがほとんどの場合は、連続的なスライダーを作成しません。</span><span class="sxs-lookup"><span data-stu-id="14eda-158">Don't create a continuous slider if the range of values is large and users will most likely select one of several representative values from the range.</span></span> <span data-ttu-id="14eda-159">代わりに、それらの値だけを、許可される間隔として使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-159">Instead, use those values as the only steps allowed.</span></span> <span data-ttu-id="14eda-160">たとえば、時間の最大値は 1 か月であっても、ユーザーが 1 分、1 時間、1 日、1 か月のいずれかを選ぶ場合は、4 つの間隔位置だけのスライダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="14eda-160">For example if time value might be up to 1 month but users only need to pick from 1 minute, 1 hour, 1 day or 1 month, then create a slider with only 4 step points.</span></span>

## <a name="additional-usage-guidance"></a><span data-ttu-id="14eda-161">その他の使い方のガイダンス</span><span class="sxs-lookup"><span data-stu-id="14eda-161">Additional usage guidance</span></span>

### <a name="choosing-the-right-layout-horizontal-or-vertical"></a><span data-ttu-id="14eda-162">適切なレイアウトの選択: 水平または垂直</span><span class="sxs-lookup"><span data-stu-id="14eda-162">Choosing the right layout: horizontal or vertical</span></span>

<span data-ttu-id="14eda-163">スライダーは、水平方向または垂直方向に向きを設定できます。</span><span class="sxs-lookup"><span data-stu-id="14eda-163">You can orient your slider horizontally or vertically.</span></span> <span data-ttu-id="14eda-164">次のガイドラインを使って、使うレイアウトを決めます。</span><span class="sxs-lookup"><span data-stu-id="14eda-164">Use these guidelines to determine which layout to use.</span></span>

-   <span data-ttu-id="14eda-165">自然な方向を使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-165">Use a natural orientation.</span></span> <span data-ttu-id="14eda-166">たとえば、スライダーが現実世界の値を表していて、通常は垂直方向に表示される場合 (気温など) は、垂直方向にします。</span><span class="sxs-lookup"><span data-stu-id="14eda-166">For example, if the slider represents a real-world value that is normally shown vertically (such as temperature), use a vertical orientation.</span></span>
-   <span data-ttu-id="14eda-167">ビデオ アプリのように、メディア内をシークするためにコントロールが使われる場合は、水平方向にします。</span><span class="sxs-lookup"><span data-stu-id="14eda-167">If the control is used to seek within media, like in a video app, use a horizontal orientation.</span></span>
-   <span data-ttu-id="14eda-168">1 つの方向 (水平または垂直) にパンするページでスライダーを使う場合は、パンの方向とは異なる方向をスライダーに使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-168">When using a slider in page that can be panned in one direction (horizontally or vertically), use a different orientation for the slider than the panning direction.</span></span> <span data-ttu-id="14eda-169">そうしないと、ユーザーはページをパンしようとしてスライダーをスワイプし、誤って値を変えてしまう場合があります。</span><span class="sxs-lookup"><span data-stu-id="14eda-169">Otherwise, users might swipe the slider and change its value accidentally when they try to pan the page.</span></span>
-   <span data-ttu-id="14eda-170">使用する方向がまだ決まらない場合は、ページ レイアウトに適した方を使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-170">If you're still not sure which orientation to use, use the one that best fits your page layout.</span></span>

### <a name="range-direction"></a><span data-ttu-id="14eda-171">範囲方向</span><span class="sxs-lookup"><span data-stu-id="14eda-171">Range direction</span></span>

<span data-ttu-id="14eda-172">範囲方向とは、現在の値から最大値へスライダーを動かす方向のことです。</span><span class="sxs-lookup"><span data-stu-id="14eda-172">The range direction is the direction you move the slider when you slide it from its current value to its max value.</span></span>

-   <span data-ttu-id="14eda-173">垂直方向スライダーでは、読みの方向に関係なく、最大値をスライダーの上部に配置します。</span><span class="sxs-lookup"><span data-stu-id="14eda-173">For vertical slider, put the largest value at the top of the slider, regardless of reading direction.</span></span> <span data-ttu-id="14eda-174">たとえば、音量スライダーでは、最大の音量設定を常にスライダーの上部に配置します。</span><span class="sxs-lookup"><span data-stu-id="14eda-174">For example, for a volume slider, always put the maximum volume setting at the top of the slider.</span></span> <span data-ttu-id="14eda-175">他の種類の値 (曜日など) では、ページの読みの方向に従います。</span><span class="sxs-lookup"><span data-stu-id="14eda-175">For other types of values (such as days of the week), follow the reading direction of the page.</span></span>
-   <span data-ttu-id="14eda-176">水平方向のスタイルでは、ページ レイアウトが左から右への場合は、低い方の値をスライダーの左側に配置します。ページ レイアウトが右から左への場合は、右側に配置します。</span><span class="sxs-lookup"><span data-stu-id="14eda-176">For horizontal styles, put the lower value on the left side of the slider for left-to-right page layout, and on the right for right-to-left page layout.</span></span>
-   <span data-ttu-id="14eda-177">前のガイドラインの 1 つの例外は、メディア シーク バーです。このバーでは、低い方の値を常にスライダーの左側に配置します。</span><span class="sxs-lookup"><span data-stu-id="14eda-177">The one exception to the previous guideline is for media seek bars: always put the lower value on the left side of the slider.</span></span>

### <a name="steps-and-tick-marks"></a><span data-ttu-id="14eda-178">間隔と目盛り</span><span class="sxs-lookup"><span data-stu-id="14eda-178">Steps and tick marks</span></span>

-   <span data-ttu-id="14eda-179">スライダーで最小値から最大値までの任意の値を許可するのではない場合は、間隔位置を使います。たとえば、購入する映画のチケットの数を指定するためにスライダーを使う場合、浮動小数点値は許可しません。</span><span class="sxs-lookup"><span data-stu-id="14eda-179">Use step points if you don't want the slider to allow arbitrary values between min and max. For example, if you use a slider to specify the number of movie tickets to buy, don't allow floating point values.</span></span> <span data-ttu-id="14eda-180">間隔の値を 1 にします。</span><span class="sxs-lookup"><span data-stu-id="14eda-180">Give it a step value of 1.</span></span>
-   <span data-ttu-id="14eda-181">間隔 (スナップ位置とも言います) を指定する場合、最後のステップがスライダーの最大値に揃うようにします。</span><span class="sxs-lookup"><span data-stu-id="14eda-181">If you specify steps (also known as snap points), make sure that the final step aligns to the slider's max value.</span></span>
-   <span data-ttu-id="14eda-182">主な、または重要な値の位置をユーザーに示す場合は、目盛りを使います。</span><span class="sxs-lookup"><span data-stu-id="14eda-182">Use tick marks when you want to show users the location of major or significant values.</span></span> <span data-ttu-id="14eda-183">たとえば、ズームを制御するスライダーでは、50%、100%、200% の目盛りを設定します。</span><span class="sxs-lookup"><span data-stu-id="14eda-183">For example, a slider that controls a zoom might have tick marks for 50%, 100%, and 200%.</span></span>
-   <span data-ttu-id="14eda-184">設定のおおよその値をユーザーが知る必要がある場合に、目盛りを表示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-184">Show tick marks when users need to know the approximate value of the setting.</span></span>
-   <span data-ttu-id="14eda-185">選択した設定の正確な値を、コントロールを操作しなくてもユーザーが確認できるようにするには、目盛りと値ラベルを表示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-185">Show tick marks and a value label when users need to know the exact value of the setting they choose, without interacting with the control.</span></span> <span data-ttu-id="14eda-186">または、値ヒントを使って、正確な値が見られるようにします。</span><span class="sxs-lookup"><span data-stu-id="14eda-186">Otherwise, they can use the value tooltip to see the exact value.</span></span>
-   <span data-ttu-id="14eda-187">間隔位置が明白でない場合は、常に目盛りを表示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-187">Always show tick marks when step points aren't obvious.</span></span> <span data-ttu-id="14eda-188">たとえば、スライダーの幅が 200 ピクセルで、200 のスナップ位置がある場合は、ユーザーはスナップの動作に気付かないので、目盛りを非表示にできます。</span><span class="sxs-lookup"><span data-stu-id="14eda-188">For example, if the slider is 200 pixels wide and has 200 snap points, you can hide the tick marks because users won't notice the snapping behavior.</span></span> <span data-ttu-id="14eda-189">しかし、スナップ位置が 10 個しかない場合は、目盛りを表示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-189">But if there are only 10 snap points, show tick marks.</span></span>

### <a name="labels"></a><span data-ttu-id="14eda-190">ラベル</span><span class="sxs-lookup"><span data-stu-id="14eda-190">Labels</span></span>

-   **<span data-ttu-id="14eda-191">スライダー ラベル</span><span class="sxs-lookup"><span data-stu-id="14eda-191">Slider labels</span></span>**

    <span data-ttu-id="14eda-192">スライダー ラベルは、スライダーの使用目的を示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-192">The slider label indicates what the slider is used for.</span></span>

    -   <span data-ttu-id="14eda-193">ラベルを使うときは末尾に句点を付けません (これはすべてのコントロール ラベルでの規則です)。</span><span class="sxs-lookup"><span data-stu-id="14eda-193">Use a label with no ending punctuation (this is the convention for all control labels).</span></span>
    -   <span data-ttu-id="14eda-194">スライダーのあるフォームで、ほとんどのラベルがコントロールの上にある場合は、ラベルをスライダーの上に配置します。</span><span class="sxs-lookup"><span data-stu-id="14eda-194">Position labels above the slider when the slider is in a form that places most of its labels above their controls.</span></span>
    -   <span data-ttu-id="14eda-195">スライダーのあるフォームで、ほとんどのラベルがコントロールの横にある場合は、ラベルをスライダーの横に配置します。</span><span class="sxs-lookup"><span data-stu-id="14eda-195">Position labels to the sides when the slider is in a form that places most of its labels to the side of their controls.</span></span>
    -   <span data-ttu-id="14eda-196">ユーザーがスライダーにタッチするときに、指でラベルが見えなくなる場合があるので、ラベルをスライダーの下には配置しません。</span><span class="sxs-lookup"><span data-stu-id="14eda-196">Avoid placing labels below the slider because the user's finger might occlude the label when the user touches the slider.</span></span>
-   **<span data-ttu-id="14eda-197">範囲ラベル</span><span class="sxs-lookup"><span data-stu-id="14eda-197">Range labels</span></span>**

    <span data-ttu-id="14eda-198">範囲 (容量) ラベルは、スライダーの最小値と最大値を示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-198">The range, or fill, labels describe the slider's minimum and maximum values.</span></span>

    -   <span data-ttu-id="14eda-199">垂直方向であることによって明白である場合以外は、スライダーの範囲の両端をラベルに表示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-199">Label the two ends of the slider range, unless a vertical orientation makes this unnecessary.</span></span>
    -   <span data-ttu-id="14eda-200">各ラベルは、できれば 1 ワードだけにします。</span><span class="sxs-lookup"><span data-stu-id="14eda-200">Use only one word, if possible, for each label.</span></span>
    -   <span data-ttu-id="14eda-201">末尾に句点を付けません。</span><span class="sxs-lookup"><span data-stu-id="14eda-201">Don't use ending punctuation.</span></span>
    -   <span data-ttu-id="14eda-202">これらのラベルは、説明的で対比的なものにします。</span><span class="sxs-lookup"><span data-stu-id="14eda-202">Make sure these labels are descriptive and parallel.</span></span> <span data-ttu-id="14eda-203">例: 最大/最小、多/少、低/高、小/大</span><span class="sxs-lookup"><span data-stu-id="14eda-203">Examples: Maximum/Minimum, More/Less, Low/High, Soft/Loud.</span></span>
-   **<span data-ttu-id="14eda-204">値ラベル</span><span class="sxs-lookup"><span data-stu-id="14eda-204">Value labels</span></span>**

    <span data-ttu-id="14eda-205">値ラベルは、スライダーの現在の値を表示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-205">A value label displays the current value of the slider.</span></span>

    -   <span data-ttu-id="14eda-206">値ラベルが必要な場合は、スライダーの下に表示します。</span><span class="sxs-lookup"><span data-stu-id="14eda-206">If you need a value label, display it below the slider.</span></span>
    -   <span data-ttu-id="14eda-207">テキストをコントロールに対して中央に配置し、単位 (ピクセルなど) を付記します。</span><span class="sxs-lookup"><span data-stu-id="14eda-207">Center the text relative to the control and include the units (such as pixels).</span></span>
    -   <span data-ttu-id="14eda-208">スライダーのつまみはスクラブ中に隠れるため、ラベルや他の視覚効果で現在の値を表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="14eda-208">Since the slider’s thumb is covered during scrubbing, consider showing the current value some other way, with a label or other visual.</span></span> <span data-ttu-id="14eda-209">スライダー設定のテキスト サイズは、スライダー以外の適切なサイズのサンプル テキストに連動させることができます。</span><span class="sxs-lookup"><span data-stu-id="14eda-209">A slider setting text size could render some sample text of the right size beside the slider.</span></span>

### <a name="appearance-and-interaction"></a><span data-ttu-id="14eda-210">外観と操作</span><span class="sxs-lookup"><span data-stu-id="14eda-210">Appearance and interaction</span></span>

<span data-ttu-id="14eda-211">スライダーはトラックとつまみで構成されます。</span><span class="sxs-lookup"><span data-stu-id="14eda-211">A slider is composed of a track and a thumb.</span></span> <span data-ttu-id="14eda-212">トラックは入力できる値の範囲を表すバーです (オプションでさまざまなスタイルの目盛りを表示できます)。</span><span class="sxs-lookup"><span data-stu-id="14eda-212">The track is a bar (which can optionally show various styles of tick marks) representing the range of values that can be input.</span></span> <span data-ttu-id="14eda-213">つまみは、ユーザーがトラックをタップするか、トラックを前後にスクラブして位置を調整できるセレクターです。</span><span class="sxs-lookup"><span data-stu-id="14eda-213">The thumb is a selector, which the user can position by either tapping the track or by scrubbing back and forth on it.</span></span>

<span data-ttu-id="14eda-214">スライダーには大きなタッチ ターゲットが設定されています。</span><span class="sxs-lookup"><span data-stu-id="14eda-214">A slider has a large touch target.</span></span> <span data-ttu-id="14eda-215">タッチのアクセシビリティを維持するには、スライダーを表示の端から十分に離して配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="14eda-215">To maintain touch accessibility, a slider should be positioned far enough away from the edge of the display.</span></span>

<span data-ttu-id="14eda-216">カスタム スライダーを設計する際は、余分な要素をできるだけなくし、ユーザーに必要なすべての情報を示す方法を検討してください。</span><span class="sxs-lookup"><span data-stu-id="14eda-216">When you’re designing a custom slider, consider ways to present all the necessary info to the user with as little clutter as possible.</span></span> <span data-ttu-id="14eda-217">ユーザーが設定を理解できるように単位を表示する必要がある場合は、値ラベルを使います。これらの値を視覚的に示す方法を工夫してください。</span><span class="sxs-lookup"><span data-stu-id="14eda-217">Use a value label if a user needs to know the units in order to understand the setting; find creative ways to represent these values graphically.</span></span> <span data-ttu-id="14eda-218">たとえば、音量を調整するスライダーでは、スライダーの最小の端に音波のないスピーカーのグラフィック、最大の端に音波のあるスピーカーのグラフィックを表示できます。</span><span class="sxs-lookup"><span data-stu-id="14eda-218">A slider that controls volume, for example, could display a speaker graphic without sound waves at the minimum end of the slider, and a speaker graphic with sound waves at the maximum end.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="14eda-219">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="14eda-219">Get the sample code</span></span>

- <span data-ttu-id="14eda-220">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。</span><span class="sxs-lookup"><span data-stu-id="14eda-220">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-topics"></a><span data-ttu-id="14eda-221">関連トピック</span><span class="sxs-lookup"><span data-stu-id="14eda-221">Related topics</span></span>
- [<span data-ttu-id="14eda-222">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="14eda-222">Toggle switches</span></span>](toggles.md)
- [<span data-ttu-id="14eda-223">Slider クラス</span><span class="sxs-lookup"><span data-stu-id="14eda-223">Slider class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209614)
