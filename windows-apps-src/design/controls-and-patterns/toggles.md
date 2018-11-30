---
Description: The toggle switch represents a physical switch that allows users to turn things on or off.
title: トグル スイッチ コントロールのガイドライン
ms.assetid: 753CFEA4-80D3-474C-B4A9-555F872A3DEF
label: Toggle switches
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: d0436f360facceb4a7ee0d02defd5fac2e33eaae
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8204335"
---
# <a name="toggle-switches"></a><span data-ttu-id="3e189-103">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="3e189-103">Toggle switches</span></span>

<span data-ttu-id="3e189-104">トグル スイッチは、ユーザーが項目をオンまたはオフに切り替えることができる、電気のスイッチのような物理的なスイッチを表します。</span><span class="sxs-lookup"><span data-stu-id="3e189-104">The toggle switch represents a physical switch that allows users to turn things on or off, like a light switch.</span></span> <span data-ttu-id="3e189-105">トグル スイッチ コントロールを使うと、ユーザーに 2 つの相互排他的なオプション (オン/オフのように) を表示できます。オプションの選択によって、即座に結果が提供されます。</span><span class="sxs-lookup"><span data-stu-id="3e189-105">Use toggle switch controls to present users with two mutually exclusive options (such as on/off), where choosing an option provides immediate results.</span></span>

<span data-ttu-id="3e189-106">トグル スイッチ コントロールを作成するには、[ToggleSwitch クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch)を使用します。</span><span class="sxs-lookup"><span data-stu-id="3e189-106">To create a toggle switch control, you use the  [ToggleSwitch class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch).</span></span>

> <span data-ttu-id="3e189-107">**重要な API**: [ToggleSwitch クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch)、[IsOn プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.ison)、[Toggled イベント](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.toggled)</span><span class="sxs-lookup"><span data-stu-id="3e189-107">**Important APIs**: [ToggleSwitch class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch), [IsOn property](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.ison), [Toggled event](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.toggled)</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="3e189-108">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="3e189-108">Is this the right control?</span></span>

<span data-ttu-id="3e189-109">トグル スイッチは、ユーザーがそのトグル スイッチをフリップした後すぐに有効になるバイナリ操作に対して使います。</span><span class="sxs-lookup"><span data-stu-id="3e189-109">Use a toggle switch for binary operations that take effect right after the user flips the toggle switch.</span></span>

![WiFi トグル スイッチ、オン/オフ](images/toggleswitches01.png)

<span data-ttu-id="3e189-111">トグル スイッチは、デバイスの物理的な電源スイッチと考えることができます。スイッチをオンまたはオフにフリップして、デバイスが実行する操作を有効にしたり無効にしたりします。</span><span class="sxs-lookup"><span data-stu-id="3e189-111">Think of the toggle switch as a physical power switch for a device: you flip it on or off when you want to enable or disable the action performed by the device.</span></span>

<span data-ttu-id="3e189-112">トグル スイッチをわかりやすくするには、制御対象の機能を説明する 1 ～ 2 単語 (できれば名詞) でラベルを付けます </span><span class="sxs-lookup"><span data-stu-id="3e189-112">To make the toggle switch easy to understand, label it with one or two words, preferably nouns, that describe the functionality it controls.</span></span> <span data-ttu-id="3e189-113">(例: "WiFi" や "台所の電気" など)。</span><span class="sxs-lookup"><span data-stu-id="3e189-113">For example, "WiFi" or "Kitchen lights."</span></span> 

## <a name="examples"></a><span data-ttu-id="3e189-114">例</span><span class="sxs-lookup"><span data-stu-id="3e189-114">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="3e189-115">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="3e189-115">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="3e189-116"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ToggleSwitch">ToggleSwitch</a> または <a href="xamlcontrolsgallery:/item/ToggleButton">ToggleButton</a> の動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="3e189-116">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to open the app and see the <a href="xamlcontrolsgallery:/item/ToggleSwitch">ToggleSwitch</a> or <a href="xamlcontrolsgallery:/item/ToggleButton">ToggleButton</a> in action.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="3e189-117">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="3e189-117">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="3e189-118">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="3e189-118">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="choosing-between-toggle-switch-and-check-box"></a><span data-ttu-id="3e189-119">トグル スイッチとチェック ボックスの選択</span><span class="sxs-lookup"><span data-stu-id="3e189-119">Choosing between toggle switch and check box</span></span>

<span data-ttu-id="3e189-120">操作によっては、トグル スイッチまたはチェック ボックスの両方が使えることがあります。</span><span class="sxs-lookup"><span data-stu-id="3e189-120">For some actions, either a toggle switch or a check box might work.</span></span> <span data-ttu-id="3e189-121">どちらのコントロールがより適切に動作するかを判断するには、次のヒントを参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="3e189-121">To decide which control would work better, follow these tips:</span></span>

- <span data-ttu-id="3e189-122">ユーザーが変更した後すぐに変更が有効になるようなバイナリ設定に対しては、トグル スイッチを使います。</span><span class="sxs-lookup"><span data-stu-id="3e189-122">Use a toggle switch for binary settings when changes become effective immediately after the user changes them.</span></span>

    ![トグル スイッチとチェック ボックス](images/toggleswitches02.png)

    <span data-ttu-id="3e189-124">この例では、トグル スイッチの場合は、台所の電気が "オン" になっていることが明らかです。</span><span class="sxs-lookup"><span data-stu-id="3e189-124">In this example, it's clear with the toggle switch that the kitchen lights are set to "On."</span></span> <span data-ttu-id="3e189-125">一方、チェック ボックスの場合は、電気が現在オンになっているのか、またはオンにするためにチェック ボックスをオンにする必要があるのか、ユーザーが考える必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e189-125">But with the checkbox, the user needs to think about whether the lights are on now or whether they need to check the box to turn the lights on.</span></span>

- <span data-ttu-id="3e189-126">チェック ボックスは、省略可能な (あると便利な) 項目に使います。</span><span class="sxs-lookup"><span data-stu-id="3e189-126">Use check boxes for optional ("nice to have") items.</span></span>
- <span data-ttu-id="3e189-127">変更を有効にするためにユーザーが追加の手順を実行する必要があるときは、チェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="3e189-127">Use a checkbox when the user has to perform extra steps for changes to be effective.</span></span> <span data-ttu-id="3e189-128">たとえば、ユーザーが [送信] や [次へ] などのボタンをクリックして変更を適用する必要がある場合は、チェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="3e189-128">For example, if the user must click a "submit" or "next" button to apply changes, use a check box.</span></span>
- <span data-ttu-id="3e189-129">1 つの設定または機能に関連する複数の項目をユーザーが選択できるようにする場合、チェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="3e189-129">Use check boxes when the user can select multiple items that are related to a single setting or feature.</span></span>

## <a name="toggle-switches-in-the-windows-ui"></a><span data-ttu-id="3e189-130">Windows UI のトグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="3e189-130">Toggle switches in the Windows UI</span></span>

<span data-ttu-id="3e189-131">以下の画像に、Windows UI でのトグル スイッチの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="3e189-131">These images show how the Windows UI uses toggle switches.</span></span> <span data-ttu-id="3e189-132">次に示すのは、スマート ストレージ設定画面でのトグル スイッチの使用例です。</span><span class="sxs-lookup"><span data-stu-id="3e189-132">Here's how the Smart Storage Settings screen uses toggle switches:</span></span>

![スマート ストレージ設定におけるトグル スイッチ](images/SmartStorageToggle.png)

<span data-ttu-id="3e189-134">以下に、夜間モード設定ページでの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="3e189-134">This example is from the Night Light Settings page:</span></span>

![Windows のスタート メニューの設定のトグル スイッチ](images/NightLightToggle.png)

## <a name="create-a-toggle-switch"></a><span data-ttu-id="3e189-136">トグル スイッチの作成</span><span class="sxs-lookup"><span data-stu-id="3e189-136">Create a toggle switch</span></span>

<span data-ttu-id="3e189-137">簡単なトグル スイッチを作成する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3e189-137">Here's how to create a simple toggle switch.</span></span> <span data-ttu-id="3e189-138">この XAML では、前に示したトグル スイッチを作成します。</span><span class="sxs-lookup"><span data-stu-id="3e189-138">This XAML creates the toggle switch shown previously.</span></span>

```xaml
<ToggleSwitch x:Name="lightToggle" Header="Kitchen Lights"/>
```

<span data-ttu-id="3e189-139">コードで同じトグル スイッチを作成する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3e189-139">Here's how to create the same toggle switch in code.</span></span>

```csharp
ToggleSwitch lightToggle = new ToggleSwitch();
lightToggle.Header = "Kitchen Lights";

// Add the toggle switch to a parent container in the visual tree.
stackPanel1.Children.Add(lightToggle);
```

### <a name="ison"></a><span data-ttu-id="3e189-140">IsOn</span><span class="sxs-lookup"><span data-stu-id="3e189-140">IsOn</span></span>

<span data-ttu-id="3e189-141">スイッチはオンまたはオフにできます。</span><span class="sxs-lookup"><span data-stu-id="3e189-141">The switch can be either on or off.</span></span> <span data-ttu-id="3e189-142">[IsOn](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.ison) プロパティを使って、スイッチの状態を判断します。</span><span class="sxs-lookup"><span data-stu-id="3e189-142">Use the [IsOn](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.ison) property to determine the state of the switch.</span></span> <span data-ttu-id="3e189-143">スイッチを使って別のバイナリ プロパティの状態を制御している場合、次に示すようにバインドを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="3e189-143">When the switch is used to control the state of another binary property, you can use a binding as shown here.</span></span>

```xaml
<StackPanel Orientation="Horizontal">
    <ToggleSwitch x:Name="ToggleSwitch1" IsOn="True"/>
    <ProgressRing IsActive="{x:Bind ToggleSwitch1.IsOn, Mode=OneWay}" Width="130"/>
</StackPanel>
```

### <a name="toggled"></a><span data-ttu-id="3e189-144">Toggled</span><span class="sxs-lookup"><span data-stu-id="3e189-144">Toggled</span></span>

<span data-ttu-id="3e189-145">状況によっては、[Toggled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.toggled) イベントを処理して状態の変化に対応することができます。</span><span class="sxs-lookup"><span data-stu-id="3e189-145">In other cases, you can handle the [Toggled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.toggled) event to respond to changes in the state.</span></span>

<span data-ttu-id="3e189-146">この例は、XAML とコードに Toggled イベント ハンドラーを追加する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="3e189-146">This example shows how to add a Toggled event handler in XAML and in code.</span></span> <span data-ttu-id="3e189-147">Toggled イベントを処理すると、進行状況リングのオフとオフが切り替えられ、表示が変更されます。</span><span class="sxs-lookup"><span data-stu-id="3e189-147">The Toggled event is handled to turn a progress ring on or off, and change its visibility.</span></span>

```xaml
<ToggleSwitch x:Name="toggleSwitch1" IsOn="True"
              Toggled="ToggleSwitch_Toggled"/>
```

<span data-ttu-id="3e189-148">コードで同じトグル スイッチを作成する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="3e189-148">Here's how to create the same toggle switch in code.</span></span>

```csharp
// Create a new toggle switch and add a Toggled event handler.
ToggleSwitch toggleSwitch1 = new ToggleSwitch();
toggleSwitch1.Toggled += ToggleSwitch_Toggled;

// Add the toggle switch to a parent container in the visual tree.
stackPanel1.Children.Add(toggleSwitch1);
```

<span data-ttu-id="3e189-149">Toggled イベントのハンドラーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="3e189-149">Here's the handler for the Toggled event.</span></span>

```csharp
private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
{
    ToggleSwitch toggleSwitch = sender as ToggleSwitch;
    if (toggleSwitch != null)
    {
        if (toggleSwitch.IsOn == true)
        {
            progress1.IsActive = true;
            progress1.Visibility = Visibility.Visible;
        }
        else
        {
            progress1.IsActive = false;
            progress1.Visibility = Visibility.Collapsed;
        }
    }
}
```

### <a name="onoff-labels"></a><span data-ttu-id="3e189-150">オン/オフ ラベル</span><span class="sxs-lookup"><span data-stu-id="3e189-150">On/Off labels</span></span>

<span data-ttu-id="3e189-151">既定では、トグル スイッチにはリテラルのオン/オフ ラベルが含まれており、自動的にローカライズされます。</span><span class="sxs-lookup"><span data-stu-id="3e189-151">By default, the toggle switch includes literal On and Off labels, which are localized automatically.</span></span> <span data-ttu-id="3e189-152">これらのラベルは、[OnContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.oncontent) プロパティと [OffContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.offcontent) プロパティを設定して置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="3e189-152">You can replace these labels by setting the [OnContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.oncontent), and [OffContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.offcontent) properties.</span></span>

<span data-ttu-id="3e189-153">この例では、オン/オフ ラベルを表示/非表示ラベルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="3e189-153">This example replaces the On/Off labels with Show/Hide labels.</span></span>

```xaml
<ToggleSwitch x:Name="imageToggle" Header="Show images"
              OffContent="Show" OnContent="Hide"
              Toggled="ToggleSwitch_Toggled"/>
```

<span data-ttu-id="3e189-154">[OnContentTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.oncontenttemplate) プロパティと [OffContentTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.offcontenttemplate) プロパティを設定することで、より複雑なコンテンツを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="3e189-154">You can also use more complex content by setting the [OnContentTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.oncontenttemplate) and [OffContentTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.offcontenttemplate) properties.</span></span>

## <a name="recommendations"></a><span data-ttu-id="3e189-155">推奨事項</span><span class="sxs-lookup"><span data-stu-id="3e189-155">Recommendations</span></span>

- <span data-ttu-id="3e189-156">できるだけ、既定の "オン" と "オフ" のラベルを使用してください。これらのラベルは、トグル スイッチの意味を理解しやすくするために必要な場合のみ置き換えるようにします。</span><span class="sxs-lookup"><span data-stu-id="3e189-156">Use the default On and Off labels when you can; only replace them when it's necessary for the toggle switch to make sense.</span></span> <span data-ttu-id="3e189-157">ラベルを置き換える場合に使用するのは、より的確にトグルを説明する 1 単語にしてください。</span><span class="sxs-lookup"><span data-stu-id="3e189-157">If you replace them, use a single word that more accurately describes the toggle.</span></span> <span data-ttu-id="3e189-158">一般的に、トグル スイッチに関連付けられている操作が "オン" と "オフ" という単語で表現されない場合は、別のコントロールが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="3e189-158">In general, if the words "On" and "Off" don't describe the action tied to a toggle switch, you might need a different control.</span></span>
- <span data-ttu-id="3e189-159">"オン" と "オフ" のラベルは、必要がない限り変更しないでください。独自のラベルが必要な場合以外は既定のラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="3e189-159">Avoid replacing the On and Off labels unless you must; stick with the default labels unless the situation calls for custom ones.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="3e189-160">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="3e189-160">Get the sample code</span></span>

- <span data-ttu-id="3e189-161">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="3e189-161">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="3e189-162">関連記事</span><span class="sxs-lookup"><span data-stu-id="3e189-162">Related articles</span></span>

- [<span data-ttu-id="3e189-163">ToggleSwitch クラス</span><span class="sxs-lookup"><span data-stu-id="3e189-163">ToggleSwitch class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch)
- [<span data-ttu-id="3e189-164">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="3e189-164">Radio buttons</span></span>](radio-button.md)
- [<span data-ttu-id="3e189-165">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="3e189-165">Toggle switches</span></span>](toggles.md)
- [<span data-ttu-id="3e189-166">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="3e189-166">Check boxes</span></span>](checkbox.md)
