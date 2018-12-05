---
Description: Identify the input devices connected to a Universal Windows Platform (UWP) device and identify their capabilities and attributes.
title: 入力デバイスの識別
ms.assetid: B2E93FBF-C508-44D9-BA46-ECFDAA8746F4
label: Identify input devices
template: detail.hbs
keywords: デバイス, デジタイザー, 入力, 操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c45ad71643b0d75efcb130c1175952822197a161
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8701015"
---
# <a name="identify-input-devices"></a><span data-ttu-id="ec398-103">入力デバイスの識別</span><span class="sxs-lookup"><span data-stu-id="ec398-103">Identify input devices</span></span>


<span data-ttu-id="ec398-104">ユニバーサル Windows プラットフォーム (UWP) デバイスに接続されている入力デバイスを識別し、その機能と属性を識別します。</span><span class="sxs-lookup"><span data-stu-id="ec398-104">Identify the input devices connected to a Universal Windows Platform (UWP) device and identify their capabilities and attributes.</span></span>

> <span data-ttu-id="ec398-105">**重要な API**: [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648)、[**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br208383)、[**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)</span><span class="sxs-lookup"><span data-stu-id="ec398-105">**Important APIs**: [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648), [**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br208383), [**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)</span></span>

## <a name="retrieve-mouse-properties"></a><span data-ttu-id="ec398-106">マウスのプロパティの取得</span><span class="sxs-lookup"><span data-stu-id="ec398-106">Retrieve mouse properties</span></span>


<span data-ttu-id="ec398-107">接続されているマウスによって公開されているプロパティを取得するには、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) 名前空間の [**MouseCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225626) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="ec398-107">The [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) namespace contains the [**MouseCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225626) class used to retrieve the properties exposed by one or more connected mice.</span></span> <span data-ttu-id="ec398-108">新しい **MouseCapabilities** オブジェクトを作成し、目的のプロパティを取得するだけです。</span><span class="sxs-lookup"><span data-stu-id="ec398-108">Just create a new **MouseCapabilities** object and get the properties you're interested in.</span></span>

<span data-ttu-id="ec398-109">**注:** ここで説明するプロパティによって返される値が検出されたすべてのマウスに基づきますブール型プロパティが 0 以外を返す場合は、少なくとも 1 つのマウスが特定の機能をサポートし、数値プロパティは、いずれかによって公開されている最大値を返します。マウスします。</span><span class="sxs-lookup"><span data-stu-id="ec398-109">**Note**The values returned by the properties discussed here are based on all detected mice: Boolean properties return non-zero if at least one mouse supports a specific capability, and numeric properties return the maximum value exposed by any one mouse.</span></span>

 

<span data-ttu-id="ec398-110">次のコードでは、一連の [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を使って、個別のマウスのプロパティと値を表示しています。</span><span class="sxs-lookup"><span data-stu-id="ec398-110">The following code uses a series of [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) elements to display the individual mouse properties and values.</span></span>

```CSharp
private void GetMouseProperties()
{
    MouseCapabilities mouseCapabilities = new Windows.Devices.Input.MouseCapabilities();
    MousePresent.Text = mouseCapabilities.MousePresent != 0 ? "Yes" : "No";
    VertWheel.Text = mouseCapabilities.VerticalWheelPresent != 0 ? "Yes" : "No";
    HorzWheel.Text = mouseCapabilities.HorizontalWheelPresent != 0 ? "Yes" : "No";
    SwappedButtons.Text = mouseCapabilities.SwapButtons != 0 ? "Yes" : "No";
    NumButtons.Text = mouseCapabilities.NumberOfButtons.ToString();
}
```

## <a name="retrieve-keyboard-properties"></a><span data-ttu-id="ec398-111">キーボードのプロパティの取得</span><span class="sxs-lookup"><span data-stu-id="ec398-111">Retrieve keyboard properties</span></span>


<span data-ttu-id="ec398-112">キーボードが接続されているかどうかを取得するには、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) 名前空間の [**KeyboardCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225623) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="ec398-112">The [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) namespace contains the [**KeyboardCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225623) class used to retrieve whether a keyboard is connected.</span></span> <span data-ttu-id="ec398-113">新しい **KeyboardCapabilities** オブジェクトを作成し、[**KeyboardPresent**](https://msdn.microsoft.com/library/windows/apps/br225625) プロパティを取得するだけです。</span><span class="sxs-lookup"><span data-stu-id="ec398-113">Just create a new **KeyboardCapabilities** object and get the [**KeyboardPresent**](https://msdn.microsoft.com/library/windows/apps/br225625) property.</span></span>

<span data-ttu-id="ec398-114">次のコードでは、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を使って、キーボードのプロパティと値を表示しています。</span><span class="sxs-lookup"><span data-stu-id="ec398-114">The following code uses a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) element to display the keyboard property and value.</span></span>

```CSharp
private void GetKeyboardProperties()
{
    KeyboardCapabilities keyboardCapabilities = new Windows.Devices.Input.KeyboardCapabilities();
    KeyboardPresent.Text = keyboardCapabilities.KeyboardPresent != 0 ? "Yes" : "No";
}
```

## <a name="retrieve-touch-properties"></a><span data-ttu-id="ec398-115">タッチのプロパティの取得</span><span class="sxs-lookup"><span data-stu-id="ec398-115">Retrieve touch properties</span></span>


<span data-ttu-id="ec398-116">タッチ デジタイザーが接続されているかどうかを取得するには、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) 名前空間の [**TouchCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225644) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="ec398-116">The [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) namespace contains the [**TouchCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225644) class used to retrieve whether any touch digitizers are connected.</span></span> <span data-ttu-id="ec398-117">新しい **TouchCapabilities** オブジェクトを作成し、目的のプロパティを取得するだけです。</span><span class="sxs-lookup"><span data-stu-id="ec398-117">Just create a new **TouchCapabilities** object and get the properties you're interested in.</span></span>

<span data-ttu-id="ec398-118">**注:** ここで説明するプロパティによって返される値はすべての検出されたタッチ デジタイザーに基づきますブール型プロパティが 0 以外を返す場合は、少なくとも 1 つのデジタイザーが特定の機能をサポートし、数値プロパティは、最大値を返します。任意の 1 つのデジタイザーで公開されます。</span><span class="sxs-lookup"><span data-stu-id="ec398-118">**Note**The values returned by the properties discussed here are based on all detected touch digitizers: Boolean properties return non-zero if at least one digitizer supports a specific capability, and numeric properties return the maximum value exposed by any one digitizer.</span></span>

 

<span data-ttu-id="ec398-119">次のコードでは、一連の [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を使って、タッチのプロパティと値を表示しています。</span><span class="sxs-lookup"><span data-stu-id="ec398-119">The following code uses a series of [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) elements to display the touch properties and values.</span></span>

```CSharp
private void GetTouchProperties()
{
    TouchCapabilities touchCapabilities = new Windows.Devices.Input.TouchCapabilities();
    TouchPresent.Text = touchCapabilities.TouchPresent != 0 ? "Yes" : "No";
    Contacts.Text = touchCapabilities.Contacts.ToString();
}
```

## <a name="retrieve-pointer-properties"></a><span data-ttu-id="ec398-120">ポインターのプロパティの取得</span><span class="sxs-lookup"><span data-stu-id="ec398-120">Retrieve pointer properties</span></span>


<span data-ttu-id="ec398-121">検出されたデバイスがポインター入力 (タッチ、タッチパッド、マウス、ペン) をサポートしているかどうかを取得するには、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) 名前空間の [**PointerDevice**](https://msdn.microsoft.com/library/windows/apps/br225633) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="ec398-121">The [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) namespace contains the [**PointerDevice**](https://msdn.microsoft.com/library/windows/apps/br225633) class used to retrieve whether any detected devices support pointer input (touch, touchpad, mouse, or pen).</span></span> <span data-ttu-id="ec398-122">新しい **PointerDevice** オブジェクトを作成し、目的のプロパティを取得するだけです。</span><span class="sxs-lookup"><span data-stu-id="ec398-122">Just create a new **PointerDevice** object and get the properties you're interested in.</span></span>

<span data-ttu-id="ec398-123">**注:** ここで説明するプロパティによって返される値はすべてのポインターが検出されたデバイスに基づきますブール型プロパティが 0 以外を返す場合は、少なくとも 1 つのデバイスが特定の機能をサポートし、数値プロパティが公開されている最大値を返します。によって任意の 1 つのポインター デバイス。</span><span class="sxs-lookup"><span data-stu-id="ec398-123">**Note**The values returned by the properties discussed here are based on all detected pointer devices: Boolean properties return non-zero if at least one device supports a specific capability, and numeric properties return the maximum value exposed by any one pointer device.</span></span>

<span data-ttu-id="ec398-124">次のコードでは、テーブルを使って、各ポインター デバイスのプロパティと値を表示しています。</span><span class="sxs-lookup"><span data-stu-id="ec398-124">The following code uses a table to display the properties and values for each pointer device.</span></span>

```CSharp
private void GetPointerDevices()
{
    IReadOnlyList<PointerDevice> pointerDevices = Windows.Devices.Input.PointerDevice.GetPointerDevices();
    int gridRow = 0;
    int gridColumn = 0;

    for (int i = 0; i < pointerDevices.Count; i++)
    {
        // Pointer device type.
        TextBlock textBlock1 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock1);
        textBlock1.Text = (i + 1).ToString() + " Pointer Device Type:";
        Grid.SetRow(textBlock1, gridRow);
        Grid.SetColumn(textBlock1, gridColumn);

        TextBlock textBlock2 = new TextBlock();
        textBlock2.Text = pointerDevices[i].PointerDeviceType.ToString();
        Grid_PointerProps.Children.Add(textBlock2);
        Grid.SetRow(textBlock2, gridRow++);
        Grid.SetColumn(textBlock2, gridColumn + 1);

        // Is external?
        TextBlock textBlock3 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock3);
        textBlock3.Text = (i + 1).ToString() + " Is External?";
        Grid.SetRow(textBlock3, gridRow);
        Grid.SetColumn(textBlock3, gridColumn);

        TextBlock textBlock4 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock4);
        textBlock4.Text = pointerDevices[i].IsIntegrated.ToString();
        Grid.SetRow(textBlock4, gridRow++);
        Grid.SetColumn(textBlock4, gridColumn + 1);

        // Maximum contacts.
        TextBlock textBlock5 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock5);
        textBlock5.Text = (i + 1).ToString() + " Max Contacts:";
        Grid.SetRow(textBlock5, gridRow);
        Grid.SetColumn(textBlock5, gridColumn);

        TextBlock textBlock6 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock6);
        textBlock6.Text = pointerDevices[i].MaxContacts.ToString();
        Grid.SetRow(textBlock6, gridRow++);
        Grid.SetColumn(textBlock6, gridColumn + 1);

        // Physical device rectangle.
        TextBlock textBlock7 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock7);
        textBlock7.Text = (i + 1).ToString() + " Physical Device Rect:";
        Grid.SetRow(textBlock7, gridRow);
        Grid.SetColumn(textBlock7, gridColumn);

        TextBlock textBlock8 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock8);
        textBlock8.Text = pointerDevices[i].PhysicalDeviceRect.X.ToString() + "," +
            pointerDevices[i].PhysicalDeviceRect.Y.ToString() + "," +
            pointerDevices[i].PhysicalDeviceRect.Width.ToString() + "," +
            pointerDevices[i].PhysicalDeviceRect.Height.ToString();
        Grid.SetRow(textBlock8, gridRow++);
        Grid.SetColumn(textBlock8, gridColumn + 1);

        // Screen rectangle.
        TextBlock textBlock9 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock9);
        textBlock9.Text = (i + 1).ToString() + " Screen Rect:";
        Grid.SetRow(textBlock9, gridRow);
        Grid.SetColumn(textBlock9, gridColumn);

        TextBlock textBlock10 = new TextBlock();
        Grid_PointerProps.Children.Add(textBlock10);
        textBlock10.Text = pointerDevices[i].ScreenRect.X.ToString() + "," +
            pointerDevices[i].ScreenRect.Y.ToString() + "," +
            pointerDevices[i].ScreenRect.Width.ToString() + "," +
            pointerDevices[i].ScreenRect.Height.ToString();
        Grid.SetRow(textBlock10, gridRow++);
        Grid.SetColumn(textBlock10, gridColumn + 1);

        gridColumn += 2;
        gridRow = 0;
    }
```

## <a name="related-articles"></a><span data-ttu-id="ec398-125">関連記事</span><span class="sxs-lookup"><span data-stu-id="ec398-125">Related articles</span></span>


**<span data-ttu-id="ec398-126">サンプル</span><span class="sxs-lookup"><span data-stu-id="ec398-126">Samples</span></span>**
* [<span data-ttu-id="ec398-127">基本的な入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="ec398-127">Basic input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [<span data-ttu-id="ec398-128">待機時間が短い入力のサンプル</span><span class="sxs-lookup"><span data-stu-id="ec398-128">Low latency input sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [<span data-ttu-id="ec398-129">ユーザー操作モードのサンプル</span><span class="sxs-lookup"><span data-stu-id="ec398-129">User interaction mode sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619894)

**<span data-ttu-id="ec398-130">サンプルのアーカイブ</span><span class="sxs-lookup"><span data-stu-id="ec398-130">Archive samples</span></span>**
* [<span data-ttu-id="ec398-131">入力: デバイス機能のサンプル</span><span class="sxs-lookup"><span data-stu-id="ec398-131">Input: Device capabilities sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231530)
 

 




