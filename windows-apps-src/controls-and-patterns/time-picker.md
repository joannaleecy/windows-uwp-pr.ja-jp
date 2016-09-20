---
author: Jwmsft
Description: "TimePicker は、ユーザーがタッチ、マウス、またはキーボード入力を使って時刻値を選択できる標準化された方法です。"
title: "時刻の選択コントロール"
ms.assetid: 5124ecda-09e6-449e-9d4a-d969dca46aa3
label: Time picker
template: detail.hbs
ms.sourcegitcommit: a4e9a90edd2aae9d2fd5d7bead948422d43dad59
ms.openlocfilehash: 5056a9f304ca21c977b9cc65b8ead007eccd4288

---

# 時刻の選択コントロール

TimePicker は、ユーザーがタッチ、マウス、またはキーボード入力を使って時刻値を選択できる標準化された方法です。 

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**TimePicker クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)
-   [**Time プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.time.aspx)

## 適切なコントロールの選択
時刻の選択コントロールを使って、ユーザーが単一の時刻値を選べるようにします。

適切なコントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。

## 例

エントリ ポイントには、選んだ時刻が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェスが中央から縦方向に展開されて、時刻を選べるようになります。 時刻の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。

![展開した時刻の選択コントロールの例](images/controls_timepicker_expand.png)

## 時刻の選択コントロールの作成

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

> 
            **注:**
            &nbsp;&nbsp;日付値の重要な情報については、「*日付と時刻コントロール*」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。



## 関連トピック

- [日付と時刻コントロール](date-and-time.md)
- [カレンダーの日付の選択コントロール](calendar-date-picker.md)
- [カレンダー ビュー](calendar-view.md)
- [日付の選択コントロール](date-picker.md)



<!--HONumber=Jun16_HO4-->


