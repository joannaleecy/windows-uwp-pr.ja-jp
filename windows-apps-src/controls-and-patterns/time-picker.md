---
author: Jwmsft
Description: "時刻の選択コントロールは、ユーザーがタッチ、マウス、またはキーボード入力を使って時刻値を選択できる標準化された方法です。"
title: "時刻の選択コントロール"
ms.assetid: 5124ecda-09e6-449e-9d4a-d969dca46aa3
label: Time picker
template: detail.hbs
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 83ef423ce4e6fd57726879dd83a704c47cc43744
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="time-picker"></a>時刻の選択コントロール
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

時刻の選択コントロールは、ユーザーがタッチ、マウス、またはキーボード入力を使って時刻値を選択できる標準化された方法です。 

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**TimePicker クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</li>
<li>[**Time プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.time.aspx)</li>
</ul>
</div>

## <a name="is-this-the-right-control"></a>適切なコントロールの選択
時刻の選択コントロールを使って、ユーザーが単一の時刻値を選べるようにします。

適切なコントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。

## <a name="examples"></a>例

エントリ ポイントには、選んだ時刻が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェスが中央から縦方向に展開されて、時刻を選べるようになります。 時刻の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。

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



## <a name="related-topics"></a>関連トピック

- [日付と時刻コントロール](date-and-time.md)
- [カレンダーの日付の選択コントロール](calendar-date-picker.md)
- [カレンダー ビュー](calendar-view.md)
- [日付の選択コントロール](date-picker.md)
