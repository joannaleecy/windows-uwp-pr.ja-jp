---
author: Jwmsft
Description: "DatePicker は、ユーザーがタッチ、マウス、またはキーボード入力を使ってローカライズされた日付値を選択できる標準化された方法です。"
title: "日付の選択コントロール"
ms.assetid: d4a01425-4dee-4de3-9a05-3e85c3fc03cb
isNew: true
label: Date picker
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: c183f7390c5b4f99cf0f31426c1431066e1bc96d
ms.openlocfilehash: c237d4bc013ad0a1d0d16f695f4332a6aac7efdc

---

# 日付の選択コントロール

DatePicker は、ユーザーがタッチ、マウス、またはキーボード入力を使ってローカライズされた日付値を選択できる標準化された方法です。 

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**DatePicker クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)
-   [**Date プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.date.aspx)

## 適切なコントロールの選択
日付の選択コントロールは、ユーザーが誕生日などの既知の日付 (カレンダーのコンテキストが重要ではない日) を選べるようにする場合に使用します。

適切な日付コントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。

## 例

エントリ ポイントには、選んだ日付が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、日付を選べるようになります。 日付の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。

![展開した日付の選択コントロールの例](images/controls_datepicker_expand.png)

## 日付の選択コントロールの作成

次の例は、ヘッダーを含むシンプルな日付の選択コントロールを作成する方法を示しています。

```xaml
<DatePicker x:Name=birthDatePicker Header="Date of birth"/>
```

```csharp
DatePicker birthDatePicker = new DatePicker();
birthDatePicker.Header = "Date of birth";
```

結果として、日付の選択コントロールは、次のように表示されます。

![日付の選択コントロールの例](images/date-picker-closed.png)

> **注:**
            &nbsp;&nbsp;日付値の重要な情報については、「日付と時刻コントロール」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。



## 関連記事

- [日付と時刻コントロール](date-and-time.md)
- [カレンダーの日付の選択コントロール](calendar-date-picker.md)
- [カレンダー ビュー](calendar-view.md)
- [時刻の選択コントロール](time-picker.md)



<!--HONumber=Jun16_HO4-->


