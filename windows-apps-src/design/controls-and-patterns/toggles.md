---
author: QuinnRadich
Description: The toggle switch represents a physical switch that allows users to turn things on or off.
title: トグル スイッチ コントロールのガイドライン
ms.assetid: 753CFEA4-80D3-474C-B4A9-555F872A3DEF
label: Toggle switches
template: detail.hbs
ms.author: quradic
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: daffbc5ff74adc234ac6c2b414a7e1b85763849d
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3382678"
---
# <a name="toggle-switches"></a>トグル スイッチ

トグル スイッチは、ユーザーが項目をオンまたはオフに切り替えることができる、電気のスイッチのような物理的なスイッチを表します。 トグル スイッチ コントロールを使うと、ユーザーに 2 つの相互排他的なオプション (オン/オフのように) を表示できます。オプションの選択によって、即座に結果が提供されます。

トグル スイッチ コントロールを作成するには、[ToggleSwitch クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch)を使用します。

> **重要な API**: [ToggleSwitch クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch)、[IsOn プロパティ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.ison)、[Toggled イベント](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.toggled)

## <a name="is-this-the-right-control"></a>適切なコントロールの選択

トグル スイッチは、ユーザーがそのトグル スイッチをフリップした後すぐに有効になるバイナリ操作に対して使います。

![WiFi トグル スイッチ、オン/オフ](images/toggleswitches01.png)

トグル スイッチは、デバイスの物理的な電源スイッチと考えることができます。スイッチをオンまたはオフにフリップして、デバイスが実行する操作を有効にしたり無効にしたりします。

トグル スイッチをわかりやすくするには、制御対象の機能を説明する 1 ～ 2 単語 (できれば名詞) でラベルを付けます  (例: "WiFi" や "台所の電気" など)。 

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ToggleSwitch">ToggleSwitch</a> または <a href="xamlcontrolsgallery:/item/ToggleButton">ToggleButton</a> の動作を確認してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="choosing-between-toggle-switch-and-check-box"></a>トグル スイッチとチェック ボックスの選択

操作によっては、トグル スイッチまたはチェック ボックスの両方が使えることがあります。 どちらのコントロールがより適切に動作するかを判断するには、次のヒントを参考にしてください。

- ユーザーが変更した後すぐに変更が有効になるようなバイナリ設定に対しては、トグル スイッチを使います。

    ![トグル スイッチとチェック ボックス](images/toggleswitches02.png)

    この例では、トグル スイッチの場合は、台所の電気が "オン" になっていることが明らかです。 一方、チェック ボックスの場合は、電気が現在オンになっているのか、またはオンにするためにチェック ボックスをオンにする必要があるのか、ユーザーが考える必要があります。

- チェック ボックスは、省略可能な (あると便利な) 項目に使います。
- 変更を有効にするためにユーザーが追加の手順を実行する必要があるときは、チェック ボックスを使います。 たとえば、ユーザーが [送信] や [次へ] などのボタンをクリックして変更を適用する必要がある場合は、チェック ボックスを使います。
- 1 つの設定または機能に関連する複数の項目をユーザーが選択できるようにする場合、チェック ボックスを使います。

## <a name="toggle-switches-in-the-the-windows-ui"></a>Windows UI のトグル スイッチ

以下の画像に、Windows UI でのトグル スイッチの使用例を示します。 次に示すのは、スマート ストレージ設定画面でのトグル スイッチの使用例です。

![スマート ストレージ設定におけるトグル スイッチ](images/SmartStorageToggle.png)

以下に、夜間モード設定ページでの使用例を示します。

![Windows のスタート メニューの設定のトグル スイッチ](images/NightLightToggle.png)

## <a name="create-a-toggle-switch"></a>トグル スイッチの作成

簡単なトグル スイッチを作成する方法を次に示します。 この XAML では、前に示したトグル スイッチを作成します。

```xaml
<ToggleSwitch x:Name="lightToggle" Header="Kitchen Lights"/>
```

コードで同じトグル スイッチを作成する方法を次に示します。

```csharp
ToggleSwitch lightToggle = new ToggleSwitch();
lightToggle.Header = "Kitchen Lights";

// Add the toggle switch to a parent container in the visual tree.
stackPanel1.Children.Add(lightToggle);
```

### <a name="ison"></a>IsOn

スイッチはオンまたはオフにできます。 [IsOn](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.ison) プロパティを使って、スイッチの状態を判断します。 スイッチを使って別のバイナリ プロパティの状態を制御している場合、次に示すようにバインドを使うことができます。

```xaml
<StackPanel Orientation="Horizontal">
    <ToggleSwitch x:Name="ToggleSwitch1" IsOn="True"/>
    <ProgressRing IsActive="{x:Bind ToggleSwitch1.IsOn, Mode=OneWay}" Width="130"/>
</StackPanel>
```

### <a name="toggled"></a>Toggled

状況によっては、[Toggled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.toggled) イベントを処理して状態の変化に対応することができます。

この例は、XAML とコードに Toggled イベント ハンドラーを追加する方法を示しています。 Toggled イベントを処理すると、進行状況リングのオフとオフが切り替えられ、表示が変更されます。

```xaml
<ToggleSwitch x:Name="toggleSwitch1" IsOn="True"
              Toggled="ToggleSwitch_Toggled"/>
```

コードで同じトグル スイッチを作成する方法を次に示します。

```csharp
// Create a new toggle switch and add a Toggled event handler.
ToggleSwitch toggleSwitch1 = new ToggleSwitch();
toggleSwitch1.Toggled += ToggleSwitch_Toggled;

// Add the toggle switch to a parent container in the visual tree.
stackPanel1.Children.Add(toggleSwitch1);
```

Toggled イベントのハンドラーを次に示します。

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

### <a name="onoff-labels"></a>オン/オフ ラベル

既定では、トグル スイッチにはリテラルのオン/オフ ラベルが含まれており、自動的にローカライズされます。 これらのラベルは、[OnContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.oncontent) プロパティと [OffContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.offcontent) プロパティを設定して置き換えることができます。

この例では、オン/オフ ラベルを表示/非表示ラベルに置き換えます。

```xaml
<ToggleSwitch x:Name="imageToggle" Header="Show images"
              OffContent="Show" OnContent="Hide"
              Toggled="ToggleSwitch_Toggled"/>
```

[OnContentTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.oncontenttemplate) プロパティと [OffContentTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch.offcontenttemplate) プロパティを設定することで、より複雑なコンテンツを使うこともできます。

## <a name="recommendations"></a>推奨事項

- できるだけ、既定の "オン" と "オフ" のラベルを使用してください。これらのラベルは、トグル スイッチの意味を理解しやすくするために必要な場合のみ置き換えるようにします。 ラベルを置き換える場合に使用するのは、より的確にトグルを説明する 1 単語にしてください。 一般的に、トグル スイッチに関連付けられている操作が "オン" と "オフ" という単語で表現されない場合は、別のコントロールが必要になる場合があります。
- "オン" と "オフ" のラベルは、必要がない限り変更しないでください。独自のラベルが必要な場合以外は既定のラベルを使います。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [ToggleSwitch クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.toggleswitch)
- [ラジオ ボタン](radio-button.md)
- [トグル スイッチ](toggles.md)
- [チェック ボックス](checkbox.md)
