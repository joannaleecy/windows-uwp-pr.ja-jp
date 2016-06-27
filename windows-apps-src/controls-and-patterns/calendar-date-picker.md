---
author: Jwmsft
Description: "カレンダーの日付の選択コントロールは、カレンダーの曜日や埋まり具合などのコンテキスト情報が必要となるカレンダー ビューから単一の日付を選ぶ用途に最適なドロップダウン コントロールです。"
title: "カレンダーの日付の選択コントロール"
ms.assetid: 9e0213e0-046a-4906-ba86-0b49be51ca99
label: Calendar date picker
template: detail.hbs
ms.sourcegitcommit: c183f7390c5b4f99cf0f31426c1431066e1bc96d
ms.openlocfilehash: 75f6bb925db63838e4985df15b50977b93805ffe

---

# カレンダーの日付の選択コントロール

カレンダーの日付の選択コントロールは、カレンダーの曜日や埋まり具合などのコンテキスト情報が必要となるカレンダー ビューから単一の日付を選ぶ用途に最適なドロップダウン コントロールです。 追加のコンテキストを提供する場合、または利用可能日を制限する場合は、カレンダーを変更できます。

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**TimePicker クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)
-   [**Time プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.time.aspx)

## 適切なコントロールの選択
**カレンダーの日付の選択コントロール**を使うと、ユーザーはコンテキストに沿ったカレンダー ビューから 1 つの日付を選ぶことができます。 予定日や出発日の選択などに使います。

ユーザーが誕生日などの既知の日付 (カレンダーのコンテキストとしては重要ではない日) を選べるようにするには、[**日付の選択コントロール**](date-picker.md) を使うことを検討してください。

適切なコントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。

## 例

日付が設定されていない場合、エントリ ポイントにはプレースホルダー テキストが表示されます。設定されている場合は、選んだ日付が表示されます。 ユーザーがエントリ ポイントを選ぶと、カレンダー ビューが展開されて、ユーザーが日付を選べるようになります。 カレンダー ビューは他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。

![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-2-views.png)

## 日付の選択コントロールの作成

```xaml
<CalendarDatePicker x:Name="arrivalCalendarDatePicker" Header="Arrival date"/>
```

```csharp
CalendarDatePicker arrivalCalendarDatePicker = new CalendarDatePicker();
arrivalCalendarDatePicker.Header = "Arrival date";
```

結果として、カレンダーの日付の選択コントロールは、次のように表示されます。

![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-closed.png)

カレンダーの日付の選択コントロールの内部には、日付選択用の [**CalendarView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx) があります。 CalendarDatePicker には [**IsTodayHighlighted**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.istodayhighlighted.aspx) や [**FirstDayOfWeek**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.firstdayofweek.aspx) のような CalendarView プロパティのサブセットが存在し、内部の CalendarView に転送されるため、このサブセットを使って内部の CalendarView を変更できます。 

ただし、複数選択を許可するために、内部の CalendarView の [**SelectionMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectionmode.aspx) を変更することはできません。 ユーザーが複数の日付を選べるようにしたり、カレンダーを常に表示しておく必要がある場合、カレンダーの日付の選択コントロールではなく、カレンダー ビューを使うことを検討してください。 カレンダー表示を変更する方法について詳しくは、「[カレンダー ビュー](calendar-view.md)」をご覧ください。

### 日付の選択

選んだ日付を取得または設定するには、[**Date**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.date.aspx) プロパティを使います。 既定では、Date プロパティは **null** です。 ユーザーがカレンダー ビューで日付を選ぶと、このプロパティが更新されます。 日付をクリアするには、カレンダー ビュー内で選んだ日付をクリックして選択を解除します。 

次のようなコードで日付を設定できます。

```csharp
myCalendarDatePicker.Date = new DateTime(1977, 1, 5);
```

コードで Date を設定するときに、その値は [**MinDate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.mindate.aspx) プロパティと [**MaxDate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.maxdate.aspx) プロパティの制約を受けます。
- **Date** の値が **MinDate** よりも小さい場合、Date の値は **MinDate** に設定されます。
- **Date** の値が **MaxDate** よりも大きい場合、Date の値は **MaxDate** に設定されます。

Date 値が変化したときに通知を受け取るには、[**DateChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.datechanged.aspx) イベントを処理します。

> **注:**
            &nbsp;&nbsp;日付値の重要な情報については、「日付と時刻コントロール」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。

### ヘッダーとプレースホルダー テキストの設定

[
            **Header**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.header.aspx) (ラベル) と [**PlaceholderText**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.placeholdertext.aspx) (透かし) をカレンダーの日付の選択コントロールに追加すると、ユーザーに用途を示すことができます。 ヘッダーの外観をカスタマイズするには、Header ではなく [**HeaderTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.headertemplate.aspx) プロパティを設定します。

既定のプレースホルダー テキストは、"日付を選択" です。 PlaceholderText プロパティに空の文字列を設定してこのテキストを削除するか、次のようにカスタム テキストを指定することもできます。

```xaml
<CalendarDatePicker x:Name="arrivalCalendarDatePicker" Header="Arrival date" PlaceholderText="Choose your arrival date"/>
```


## 関連記事

- [日付と時刻コントロール](date-and-time.md)
- [カレンダー ビュー](calendar-view.md)
- [日付の選択コントロール](date-picker.md)
- [時刻の選択コントロール](time-picker.md)



<!--HONumber=Jun16_HO3-->


