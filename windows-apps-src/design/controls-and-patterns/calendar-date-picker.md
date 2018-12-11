---
Description: The calendar date picker is a drop down control that’s optimized for picking a single date from a calendar view where contextual information like the day of the week or fullness of the calendar is important.
title: カレンダーの日付の選択コントロール
ms.assetid: 9e0213e0-046a-4906-ba86-0b49be51ca99
label: Calendar date picker
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 960628156777e18781c82eeda9348823be3dbf4c
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8900612"
---
# <a name="calendar-date-picker"></a><span data-ttu-id="546ab-103">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="546ab-103">Calendar date picker</span></span>

 

<span data-ttu-id="546ab-104">カレンダーの日付の選択コントロールは、カレンダーの曜日や埋まり具合などのコンテキスト情報が必要となるカレンダー ビューから単一の日付を選ぶ用途に最適なドロップダウン コントロールです。</span><span class="sxs-lookup"><span data-stu-id="546ab-104">The calendar date picker is a drop down control that’s optimized for picking a single date from a calendar view where contextual information like the day of the week or fullness of the calendar is important.</span></span> <span data-ttu-id="546ab-105">追加のコンテキストを提供したり、使用可能な日付を制限したりするように、カレンダーを変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="546ab-105">You can modify the calendar to provide additional context or to limit available dates.</span></span>

> <span data-ttu-id="546ab-106">**重要な API**: [CalendarDatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)、[Date プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.date.aspx)、[DateChanged イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.datechanged.aspx)</span><span class="sxs-lookup"><span data-stu-id="546ab-106">**Important APIs**: [CalendarDatePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx), [Date property](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.date.aspx), [DateChanged event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.datechanged.aspx)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="546ab-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="546ab-107">Is this the right control?</span></span>
<span data-ttu-id="546ab-108">**カレンダーの日付の選択コントロール**を使うと、ユーザーはコンテキストに沿ったカレンダー ビューから 1 つの日付を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="546ab-108">Use a **calendar date picker** to let a user pick a single date from a contextual calendar view.</span></span> <span data-ttu-id="546ab-109">予定日や出発日の選択などに使います。</span><span class="sxs-lookup"><span data-stu-id="546ab-109">Use it for things like choosing an appointment or departure date.</span></span>

<span data-ttu-id="546ab-110">ユーザーが誕生日などの既知の日付 (カレンダーのコンテキストとしては重要ではない日) を選べるようにするには、[日付の選択コントロール](date-picker.md)を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="546ab-110">To let a user pick a known date, such as a date of birth, where the context of the calendar is not important, consider using a [date picker](date-picker.md).</span></span>

<span data-ttu-id="546ab-111">適切なコントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="546ab-111">For more info about choosing the right control, see the [Date and time controls](date-and-time.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="546ab-112">例</span><span class="sxs-lookup"><span data-stu-id="546ab-112">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="546ab-113">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="546ab-113">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="546ab-114"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/CalendarDatePicker">アプリを開き、CalendarDatePicker の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="546ab-114">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CalendarDatePicker">open the app and see the CalendarDatePicker in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="546ab-115">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="546ab-115">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="546ab-116">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="546ab-116">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="546ab-117">日付が設定されていない場合、エントリ ポイントにはプレースホルダー テキストが表示されます。設定されている場合は、選んだ日付が表示されます。</span><span class="sxs-lookup"><span data-stu-id="546ab-117">The entry point displays placeholder text if a date has not been set; otherwise, it displays the chosen date.</span></span> <span data-ttu-id="546ab-118">ユーザーがエントリ ポイントを選ぶと、カレンダー ビューが展開されて、ユーザーが日付を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="546ab-118">When the user selects the entry point, a calendar view expands for the user to make a date selection.</span></span> <span data-ttu-id="546ab-119">カレンダー ビューは他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="546ab-119">The calendar view overlays other UI; it doesn't push other UI out of the way.</span></span>

![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-2-views.png)

## <a name="create-a-date-picker"></a><span data-ttu-id="546ab-121">日付の選択コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="546ab-121">Create a date picker</span></span>

```xaml
<CalendarDatePicker x:Name="arrivalCalendarDatePicker" Header="Arrival date"/>
```

```csharp
CalendarDatePicker arrivalCalendarDatePicker = new CalendarDatePicker();
arrivalCalendarDatePicker.Header = "Arrival date";
```

<span data-ttu-id="546ab-122">結果として、カレンダーの日付の選択コントロールは、次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="546ab-122">The resulting calendar date picker looks like this:</span></span>

![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-closed.png)

<span data-ttu-id="546ab-124">カレンダーの日付の選択コントロールの内部には、日付選択用の [CalendarView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx) があります。</span><span class="sxs-lookup"><span data-stu-id="546ab-124">The calendar date picker has an internal [CalendarView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx) for picking a date.</span></span> <span data-ttu-id="546ab-125">CalendarDatePicker には [IsTodayHighlighted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.istodayhighlighted.aspx) や [FirstDayOfWeek](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.firstdayofweek.aspx) のような CalendarView プロパティのサブセットが存在し、内部の CalendarView に転送されるため、このサブセットを使って内部の CalendarView を変更できます。</span><span class="sxs-lookup"><span data-stu-id="546ab-125">A subset of CalendarView properties, like [IsTodayHighlighted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.istodayhighlighted.aspx) and [FirstDayOfWeek](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.firstdayofweek.aspx), exist on CalendarDatePicker and are forwarded to the internal CalendarView to let you modify it.</span></span> 

<span data-ttu-id="546ab-126">ただし、複数選択を許可するために、内部の CalendarView の [SelectionMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectionmode.aspx) を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="546ab-126">However, you can't change the [SelectionMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectionmode.aspx) of the internal CalendarView to allow multiple selection.</span></span> <span data-ttu-id="546ab-127">ユーザーが複数の日付を選べるようにしたり、カレンダーを常に表示しておく必要がある場合、カレンダーの日付の選択コントロールではなく、カレンダー ビューを使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="546ab-127">If you need to let a user pick multiple dates or need a calendar to be always visible, consider using a calendar view instead of a calendar date picker.</span></span> <span data-ttu-id="546ab-128">カレンダー表示を変更する方法について詳しくは、「[カレンダー ビュー](calendar-view.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="546ab-128">See the [Calendar view](calendar-view.md) article for more info on how you can modify the calendar display.</span></span>

### <a name="selecting-dates"></a><span data-ttu-id="546ab-129">日付の選択</span><span class="sxs-lookup"><span data-stu-id="546ab-129">Selecting dates</span></span>

<span data-ttu-id="546ab-130">選んだ日付を取得または設定するには、[Date](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.date.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="546ab-130">Use the [Date](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.date.aspx) property to get or set the selected date.</span></span> <span data-ttu-id="546ab-131">既定では、Date プロパティは **null** です。</span><span class="sxs-lookup"><span data-stu-id="546ab-131">By default, the Date property is **null**.</span></span> <span data-ttu-id="546ab-132">ユーザーがカレンダー ビューで日付を選ぶと、このプロパティが更新されます。</span><span class="sxs-lookup"><span data-stu-id="546ab-132">When a user selects a date in the calendar view, this property is updated.</span></span> <span data-ttu-id="546ab-133">日付をクリアするには、カレンダー ビュー内で選んだ日付をクリックして選択を解除します。</span><span class="sxs-lookup"><span data-stu-id="546ab-133">A user can clear the date by clicking the selected date in the calendar view to deselect it.</span></span> 

<span data-ttu-id="546ab-134">次のようなコードで日付を設定できます。</span><span class="sxs-lookup"><span data-stu-id="546ab-134">You can set the date in your code like this.</span></span>

```csharp
myCalendarDatePicker.Date = new DateTime(1977, 1, 5);
```

<span data-ttu-id="546ab-135">コードで Date を設定するときに、その値は [MinDate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.mindate.aspx) プロパティと [MaxDate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.maxdate.aspx) プロパティの制約を受けます。</span><span class="sxs-lookup"><span data-stu-id="546ab-135">When you set the Date in code, the value is constrained by the [MinDate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.mindate.aspx) and [MaxDate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.maxdate.aspx) properties.</span></span>
- <span data-ttu-id="546ab-136">**Date** の値が **MinDate** よりも小さい場合、Date の値は **MinDate** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="546ab-136">If **Date** is smaller than **MinDate**, the value is set to **MinDate**.</span></span>
- <span data-ttu-id="546ab-137">**Date** の値が **MaxDate** よりも大きい場合、Date の値は **MaxDate** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="546ab-137">If **Date** is greater than **MaxDate**, the value is set to **MaxDate**.</span></span>

<span data-ttu-id="546ab-138">Date 値が変化したときに通知を受け取るには、[DateChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.datechanged.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="546ab-138">You can handle the [DateChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.datechanged.aspx) event to be notified when the Date value has changed.</span></span>

> [!NOTE]
<span data-ttu-id="546ab-139">日付値の重要な情報については、「日付と時刻コントロール」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="546ab-139">For important info about date values, see [DateTime and Calendar values](date-and-time.md#datetime-and-calendar-values) in the Date and time controls article.</span></span>

### <a name="setting-a-header-and-placeholder-text"></a><span data-ttu-id="546ab-140">ヘッダーとプレースホルダー テキストの設定</span><span class="sxs-lookup"><span data-stu-id="546ab-140">Setting a header and placeholder text</span></span>

<span data-ttu-id="546ab-141">[Header](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.header.aspx) (ラベル) と [PlaceholderText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.placeholdertext.aspx) (透かし) をカレンダーの日付の選択コントロールに追加すると、ユーザーに用途を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="546ab-141">You can add a [Header](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.header.aspx) (or label) and [PlaceholderText](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.placeholdertext.aspx) (or watermark) to the calendar date picker to give the user an indication of what it's used for.</span></span> <span data-ttu-id="546ab-142">ヘッダーの外観をカスタマイズするには、Header ではなく [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.headertemplate.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="546ab-142">To customize the look of the header, you can set the [HeaderTemplate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.headertemplate.aspx) property instead of Header.</span></span>

<span data-ttu-id="546ab-143">既定のプレースホルダー テキストは、"日付を選択" です。</span><span class="sxs-lookup"><span data-stu-id="546ab-143">The default placeholder text is "select a date".</span></span> <span data-ttu-id="546ab-144">PlaceholderText プロパティに空の文字列を設定してこのテキストを削除するか、次のようにカスタム テキストを指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="546ab-144">You can remove this by setting the PlaceholderText property to an empty string, or you can provide custom text as shown here.</span></span>

```xaml
<CalendarDatePicker x:Name="arrivalCalendarDatePicker" Header="Arrival date" 
                    PlaceholderText="Choose your arrival date"/>
```

## <a name="get-the-sample-code"></a><span data-ttu-id="546ab-145">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="546ab-145">Get the sample code</span></span>

- <span data-ttu-id="546ab-146">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="546ab-146">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="546ab-147">関連記事</span><span class="sxs-lookup"><span data-stu-id="546ab-147">Related articles</span></span>

- [<span data-ttu-id="546ab-148">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="546ab-148">Date and time controls</span></span>](date-and-time.md)
- [<span data-ttu-id="546ab-149">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="546ab-149">Calendar view</span></span>](calendar-view.md)
- [<span data-ttu-id="546ab-150">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="546ab-150">Date picker</span></span>](date-picker.md)
- [<span data-ttu-id="546ab-151">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="546ab-151">Time picker</span></span>](time-picker.md)
