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
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8191416"
---
# <a name="identify-input-devices"></a>入力デバイスの識別


ユニバーサル Windows プラットフォーム (UWP) デバイスに接続されている入力デバイスを識別し、その機能と属性を識別します。

> **重要な API**: [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648)、[**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br208383)、[**Windows.UI.Xaml.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)

## <a name="retrieve-mouse-properties"></a>マウスのプロパティの取得


接続されているマウスによって公開されているプロパティを取得するには、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) 名前空間の [**MouseCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225626) クラスを使います。 新しい **MouseCapabilities** オブジェクトを作成し、目的のプロパティを取得するだけです。

**注:** ここで説明するプロパティによって返される値が検出されたすべてのマウスに基づきますブール型プロパティが 0 以外を返す場合は、少なくとも 1 つのマウスが特定の機能をサポートし、数値プロパティは、いずれかによって公開されている最大値を返します。マウスします。

 

次のコードでは、一連の [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を使って、個別のマウスのプロパティと値を表示しています。

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

## <a name="retrieve-keyboard-properties"></a>キーボードのプロパティの取得


キーボードが接続されているかどうかを取得するには、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) 名前空間の [**KeyboardCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225623) クラスを使います。 新しい **KeyboardCapabilities** オブジェクトを作成し、[**KeyboardPresent**](https://msdn.microsoft.com/library/windows/apps/br225625) プロパティを取得するだけです。

次のコードでは、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を使って、キーボードのプロパティと値を表示しています。

```CSharp
private void GetKeyboardProperties()
{
    KeyboardCapabilities keyboardCapabilities = new Windows.Devices.Input.KeyboardCapabilities();
    KeyboardPresent.Text = keyboardCapabilities.KeyboardPresent != 0 ? "Yes" : "No";
}
```

## <a name="retrieve-touch-properties"></a>タッチのプロパティの取得


タッチ デジタイザーが接続されているかどうかを取得するには、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) 名前空間の [**TouchCapabilities**](https://msdn.microsoft.com/library/windows/apps/br225644) クラスを使います。 新しい **TouchCapabilities** オブジェクトを作成し、目的のプロパティを取得するだけです。

**注:** ここで説明するプロパティによって返される値はすべての検出されたタッチ デジタイザーに基づきますブール型プロパティが 0 以外を返す場合は、少なくとも 1 つのデジタイザーが特定の機能をサポートし、数値プロパティは、最大値を返します。任意の 1 つのデジタイザーで公開されます。

 

次のコードでは、一連の [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素を使って、タッチのプロパティと値を表示しています。

```CSharp
private void GetTouchProperties()
{
    TouchCapabilities touchCapabilities = new Windows.Devices.Input.TouchCapabilities();
    TouchPresent.Text = touchCapabilities.TouchPresent != 0 ? "Yes" : "No";
    Contacts.Text = touchCapabilities.Contacts.ToString();
}
```

## <a name="retrieve-pointer-properties"></a>ポインターのプロパティの取得


検出されたデバイスがポインター入力 (タッチ、タッチパッド、マウス、ペン) をサポートしているかどうかを取得するには、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648) 名前空間の [**PointerDevice**](https://msdn.microsoft.com/library/windows/apps/br225633) クラスを使います。 新しい **PointerDevice** オブジェクトを作成し、目的のプロパティを取得するだけです。

**注:** ここで説明するプロパティによって返される値はすべてのポインターが検出されたデバイスに基づきますブール型プロパティが 0 以外を返す場合は、少なくとも 1 つのデバイスが特定の機能をサポートし、数値プロパティが公開されている最大値を返します。によって任意の 1 つのポインター デバイス。

次のコードでは、テーブルを使って、各ポインター デバイスのプロパティと値を表示しています。

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

## <a name="related-articles"></a>関連記事


**サンプル**
* [基本的な入力のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [待機時間が短い入力のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [ユーザー操作モードのサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619894)

**サンプルのアーカイブ**
* [入力: デバイス機能のサンプル](http://go.microsoft.com/fwlink/p/?linkid=231530)
 

 




