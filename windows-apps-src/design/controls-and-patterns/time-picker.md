---
Description: The time picker gives you a standardized way to let users pick a time value using touch, mouse, or keyboard input.
title: 時刻の選択
ms.assetid: 5124ecda-09e6-449e-9d4a-d969dca46aa3
label: Time picker
template: detail.hbs
ms.date: 05/08/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 2f9947f2910855b5d55b5140f043d65fd0befeae
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8343160"
---
# <a name="time-picker"></a>時刻の選択コントロール
 

時刻の選択は、ユーザーがタッチ、マウス、またはキーボード入力を使って時刻値を選択できる標準化された方法です。 

> **重要な API**: [TimePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)、[Time プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.time.aspx)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択
時刻の選択コントロールを使って、ユーザーが単一の時刻値を選べるようにします。

適切なコントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/TimePicker">アプリを開き、TimePicker の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

エントリ ポイントには、選んだ時刻が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、時刻を選べるようになります。 時刻の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。

![展開した時刻の選択コントロールの例](images/controls_timepicker_expand.png)

## <a name="create-a-time-picker"></a>時刻の選択コントロールの作成

次の例は、ヘッダーを含むシンプルな時刻の選択コントロールを作成する方法を示しています。

```xaml
<TimePicker x:Name=arrivalTimePicker Header="Arrival time"/>
```

```csharp
TimePicker arrivalTimePicker = new TimePicker();
arrivalTimePicker.Header = "Arrival time";
```

結果として、時刻の選択コントロールは、次のように表示されます。

![時刻の選択コントロールの例](images/time-picker-closed.png)

> [!NOTE]
> 日付と時刻の値の重要な情報については、「*日付と時刻コントロール*」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。

## <a name="related-topics"></a>関連トピック

- [日付と時刻コントロール](date-and-time.md)
- [カレンダーの日付の選択コントロール](calendar-date-picker.md)
- [カレンダー ビュー](calendar-view.md)
- [日付の選択コントロール](date-picker.md)
