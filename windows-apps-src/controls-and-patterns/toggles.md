---
author: Jwmsft
Description: "トグル スイッチは、ユーザーが項目をオンまたはオフに切り替えることができる物理的なスイッチを表します。"
title: "トグル スイッチ コントロールのガイドライン"
ms.assetid: 753CFEA4-80D3-474C-B4A9-555F872A3DEF
label: Toggle switches
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.openlocfilehash: 7cc1d11035d072fdd52bdfa4a1d0c6e66926ba9f
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="toggle-switches"></a><span data-ttu-id="4b3b2-104">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="4b3b2-104">Toggle switches</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="4b3b2-105">[トグル スイッチ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.aspx)は、ユーザーが項目をオンまたはオフに切り替えることができる、電気のスイッチのような物理的なスイッチを表します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-105">The [toggle switch](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.aspx) represents a physical switch that allows users to turn things on or off, like a light switch.</span></span> <span data-ttu-id="4b3b2-106">トグル スイッチ コントロールを使うと、ユーザーに 2 つの相互排他的なオプション (オン/オフのように) を表示できます。オプションの選択によって、即座に結果が提供されます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-106">Use toggle switch controls to present users with two mutually exclusive options (such as on/off), where choosing an option provides immediate results.</span></span> 

<span data-ttu-id="4b3b2-107">トグル スイッチ コントロールを作成するには、[ToggleSwitch クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.aspx)を使用します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-107">To create a toggle switch control, you use the  [ToggleSwitch class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.aspx).</span></span>

> <span data-ttu-id="4b3b2-108">**重要な API**: [ToggleSwitch クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.aspx)、[IsOn プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.ison.aspx)、[Toggled イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.toggled.aspx)</span><span class="sxs-lookup"><span data-stu-id="4b3b2-108">**Important APIs**: [ToggleSwitch class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.aspx), [IsOn property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.ison.aspx), [Toggled event](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.toggled.aspx)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="4b3b2-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="4b3b2-109">Is this the right control?</span></span>

<span data-ttu-id="4b3b2-110">トグル スイッチは、ユーザーがそのトグル スイッチをフリップした後すぐに有効になるバイナリ操作に対して使います。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-110">Use a toggle switch for binary operations that take effect right after the user flips the toggle switch.</span></span>

![WiFi トグル スイッチ、オン/オフ](images/toggleswitches01.png)

<span data-ttu-id="4b3b2-112">トグル スイッチは、デバイスの物理的な電源スイッチと考えることができます。スイッチをオンまたはオフにフリップして、デバイスが実行する操作を有効にしたり無効にしたりします。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-112">Think of the toggle switch as a physical power switch for a device: you flip it on or off when you want to enable or disable the action performed by the device.</span></span>

<span data-ttu-id="4b3b2-113">トグル スイッチをわかりやすくするには、制御対象の機能を説明する 1 ～ 2 単語 (できれば名詞) でラベルを付けます </span><span class="sxs-lookup"><span data-stu-id="4b3b2-113">To make the toggle switch easy to understand, label it with one or two words, preferably nouns, that describe the functionality it controls.</span></span> <span data-ttu-id="4b3b2-114">(例: "WiFi" や "台所の電気" など)。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-114">For example, "WiFi" or "Kitchen lights."</span></span>  


### <a name="choosing-between-toggle-switch-and-check-box"></a><span data-ttu-id="4b3b2-115">トグル スイッチとチェック ボックスの選択</span><span class="sxs-lookup"><span data-stu-id="4b3b2-115">Choosing between toggle switch and check box</span></span>

<span data-ttu-id="4b3b2-116">操作によっては、トグル スイッチまたはチェック ボックスの両方が使えることがあります。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-116">For some actions, either a toggle switch or a check box might work.</span></span> <span data-ttu-id="4b3b2-117">どちらのコントロールがより適切に動作するかを判断するには、次のヒントを参考にしてください。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-117">To decide which control would work better, follow these tips:</span></span>

-   <span data-ttu-id="4b3b2-118">ユーザーが変更した後すぐに変更が有効になるようなバイナリ設定に対しては、トグル スイッチを使います。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-118">Use a toggle switch for binary settings when changes become effective immediately after the user changes them.</span></span>

    ![トグル スイッチとチェック ボックス](images/toggleswitches02.png)

    <span data-ttu-id="4b3b2-120">この例では、トグル スイッチの場合は、ワイヤレスが "オン" になっていることが明らかです。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-120">In this example, it's clear with the toggle switch that the wireless is set to "On."</span></span> <span data-ttu-id="4b3b2-121">一方、チェック ボックスの場合は、ワイヤレスが現在オンになっているのか、またはオンにするためにチェック ボックスをオンにする必要があるのか、ユーザーが考える必要があります。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-121">But with the checkbox, the user needs to think about whether the wireless is on now or whether they need to check the box to turn wireless on.</span></span>

-   <span data-ttu-id="4b3b2-122">チェック ボックスは、省略可能な (あると便利な) 項目に使います。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-122">Use check boxes for optional ("nice to have") items.</span></span> 
-   <span data-ttu-id="4b3b2-123">変更を有効にするためにユーザーが追加の手順を実行する必要があるときは、チェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-123">Use a checkbox when the user has to perform extra steps for changes to be effective.</span></span> <span data-ttu-id="4b3b2-124">たとえば、ユーザーが [送信] や [次へ] などのボタンをクリックして変更を適用する必要がある場合は、チェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-124">For example, if the user must click a "submit" or "next" button to apply changes, use a check box.</span></span>
-   <span data-ttu-id="4b3b2-125">1 つの設定または機能に関連する複数の項目をユーザーが選択できるようにする場合、チェック ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-125">Use check boxes when the user can select multiple items that are related to a single setting or feature.</span></span> 

## <a name="toggle-switches-in-the-the-windows-ui"></a><span data-ttu-id="4b3b2-126">Windows UI のトグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="4b3b2-126">Toggle switches in the the Windows UI</span></span>

<span data-ttu-id="4b3b2-127">以下の画像に、Windows UI でのトグル スイッチの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-127">These images show how the Windows UI uses toggle switches.</span></span> <span data-ttu-id="4b3b2-128">次に示すのは、スマート ストレージ設定画面でのトグル スイッチの使用例です。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-128">Here's how the Smart Storage Settings screen uses toggle switches:</span></span>

![スマート ストレージ設定におけるトグル スイッチ](images/SmartStorageToggle.png)

<span data-ttu-id="4b3b2-130">以下に、夜間モード設定ページでの使用例を示します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-130">This example is from the Night Light Settings page:</span></span>

![Windows のスタート メニューの設定のトグル スイッチ](images/NightLightToggle.png)

## <a name="create-a-toggle-switch"></a><span data-ttu-id="4b3b2-132">トグル スイッチの作成</span><span class="sxs-lookup"><span data-stu-id="4b3b2-132">Create a toggle switch</span></span>

<span data-ttu-id="4b3b2-133">簡単なトグル スイッチを作成する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-133">Here's how to create a simple toggle switch.</span></span> <span data-ttu-id="4b3b2-134">この XAML では、前に示した WiFi トグル スイッチを作成します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-134">This XAML creates the WiFi toggle switch shown previously.</span></span>

```xaml
<ToggleSwitch x:Name="wiFiToggle" Header="Wifi"/>
```
<span data-ttu-id="4b3b2-135">コードで同じトグル スイッチを作成する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-135">Here's how to create the same toggle switch in code.</span></span>

```csharp
ToggleSwitch wiFiToggle = new ToggleSwitch();
wiFiToggle.Header = "WiFi";

// Add the toggle switch to a parent container in the visual tree.
stackPanel1.Children.Add(wiFiToggle);
```

### <a name="ison"></a><span data-ttu-id="4b3b2-136">IsOn</span><span class="sxs-lookup"><span data-stu-id="4b3b2-136">IsOn</span></span>

<span data-ttu-id="4b3b2-137">スイッチはオンまたはオフにできます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-137">The switch can be either on or off.</span></span> <span data-ttu-id="4b3b2-138">[IsOn](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.ison.aspx) プロパティを使って、スイッチの状態を判断します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-138">Use the [IsOn](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.ison.aspx) property to determine the state of the switch.</span></span> <span data-ttu-id="4b3b2-139">スイッチを使って別のバイナリ プロパティの状態を制御している場合、次に示すようにバインドを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-139">When the switch is used to control the state of another binary property, you can use a binding as shown here.</span></span>

```
<StackPanel Orientation="Horizontal">
    <ToggleSwitch x:Name="ToggleSwitch1" IsOn="True"/>
    <ProgressRing IsActive="{x:Bind ToggleSwitch1.IsOn, Mode=OneWay}" Width="130"/>
</StackPanel>
```

### <a name="toggled"></a><span data-ttu-id="4b3b2-140">Toggled</span><span class="sxs-lookup"><span data-stu-id="4b3b2-140">Toggled</span></span>

<span data-ttu-id="4b3b2-141">状況によっては、[Toggled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.toggled.aspx) イベントを処理して状態の変化に対応することができます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-141">In other cases, you can handle the [Toggled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.toggled.aspx) event to respond to changes in the state.</span></span>

<span data-ttu-id="4b3b2-142">この例は、XAML とコードに Toggled イベント ハンドラーを追加する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-142">This example shows how to add a Toggled event handler in XAML and in code.</span></span> <span data-ttu-id="4b3b2-143">Toggled イベントを処理すると、進行状況リングのオフとオフが切り替えられ、表示が変更されます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-143">The Toggled event is handled to turn a progress ring on or off, and change its visibility.</span></span>

```xaml
<ToggleSwitch x:Name="toggleSwitch1" IsOn="True"
              Toggled="ToggleSwitch_Toggled"/>
```

<span data-ttu-id="4b3b2-144">コードで同じトグル スイッチを作成する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-144">Here's how to create the same toggle switch in code.</span></span>

```csharp
// Create a new toggle switch and add a Toggled event handler.
ToggleSwitch toggleSwitch1 = new ToggleSwitch();
toggleSwitch1.Toggled += ToggleSwitch_Toggled;

// Add the toggle switch to a parent container in the visual tree.
stackPanel1.Children.Add(toggleSwitch1);
```

<span data-ttu-id="4b3b2-145">Toggled イベントのハンドラーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-145">Here's the handler for the Toggled event.</span></span>

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

### <a name="onoff-labels"></a><span data-ttu-id="4b3b2-146">オン/オフ ラベル</span><span class="sxs-lookup"><span data-stu-id="4b3b2-146">On/Off labels</span></span>

<span data-ttu-id="4b3b2-147">既定では、トグル スイッチにはリテラルのオン/オフ ラベルが含まれており、自動的にローカライズされます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-147">By default, the toggle switch includes literal On and Off labels, which are localized automatically.</span></span> <span data-ttu-id="4b3b2-148">これらのラベルは、[OnContent](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.oncontent.aspx) プロパティと [OffContent](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.offcontent.aspx) プロパティを設定して置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-148">You can replace these labels by setting the [OnContent](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.oncontent.aspx), and [OffContent](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.offcontent.aspx) properties.</span></span>

<span data-ttu-id="4b3b2-149">この例では、オン/オフ ラベルを表示/非表示ラベルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-149">This example replaces the On/Off labels with Show/Hide labels.</span></span>  

```xaml
<ToggleSwitch x:Name="imageToggle" Header="Show images"
              OffContent="Show" OnContent="Hide"
              Toggled="ToggleSwitch_Toggled"/>
```

<span data-ttu-id="4b3b2-150">[OnContentTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.oncontenttemplate.aspx) プロパティと [OffContentTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.offcontenttemplate.aspx) プロパティを設定することで、より複雑なコンテンツを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-150">You can also use more complex content by setting the [OnContentTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.oncontenttemplate.aspx) and [OffContentTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.offcontenttemplate.aspx) properties.</span></span>

## <a name="recommendations"></a><span data-ttu-id="4b3b2-151">推奨事項</span><span class="sxs-lookup"><span data-stu-id="4b3b2-151">Recommendations</span></span>

-    <span data-ttu-id="4b3b2-152">できるだけ、既定の "オン" と "オフ" のラベルを使用してください。これらのラベルは、トグル スイッチの意味を理解しやすくするために必要な場合のみ置き換えるようにします。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-152">Use the default On and Off labels when you can; only replace them when it's necessary for the toggle switch to make sense.</span></span> <span data-ttu-id="4b3b2-153">ラベルを置き換える場合に使用するのは、より的確にトグルを説明する 1 単語にしてください。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-153">If you replace them, use a single word that more accurately describes the toggle.</span></span> <span data-ttu-id="4b3b2-154">一般的に、トグル スイッチに関連付けられている操作が "オン" と "オフ" という単語で表現されない場合は、別のコントロールが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-154">In general, if the words "On" and "Off" don't describe the action tied to a toggle switch, you might need a different control.</span></span>
-    <span data-ttu-id="4b3b2-155">"オン" と "オフ" のラベルは、必要がない限り変更しないでください。独自のラベルが必要な場合以外は既定のラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="4b3b2-155">Avoid replacing the On and Off labels unless you must; stick with the default labels unless the situation calls for custom ones.</span></span>


## <a name="related-articles"></a><span data-ttu-id="4b3b2-156">関連記事</span><span class="sxs-lookup"><span data-stu-id="4b3b2-156">Related articles</span></span>

- [<span data-ttu-id="4b3b2-157">ToggleSwitch クラス</span><span class="sxs-lookup"><span data-stu-id="4b3b2-157">ToggleSwitch class</span></span>](https://msdn.microsoft.com/library/windows/apps/hh701411)
- [<span data-ttu-id="4b3b2-158">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="4b3b2-158">Radio buttons</span></span>](radio-button.md)
- [<span data-ttu-id="4b3b2-159">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="4b3b2-159">Toggle switches</span></span>](toggles.md)
- [<span data-ttu-id="4b3b2-160">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="4b3b2-160">Check boxes</span></span>](checkbox.md)
