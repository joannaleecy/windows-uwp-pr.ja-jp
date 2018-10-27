---
author: muhsinking
Description: Date and time controls let you view and set the date and time. This article provides design guidelines and helps you pick the right control.
title: 日付コントロールと時刻コントロールのガイドライン
ms.assetid: 4641FFBB-8D82-4290-94C1-D87617997F61
label: Calendar, date, and time controls
template: detail.hbs
ms.author: mukin
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 363c60a9aeaaa98d808e015f96e4096cf889a501
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5683094"
---
# <a name="calendar-date-and-time-controls"></a><span data-ttu-id="fd9d2-103">カレンダー、日付、および時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-103">Calendar, date, and time controls</span></span>

 

<span data-ttu-id="fd9d2-104">日付コントロールと時刻コントロールを使用することで、その地域に合った標準化された方法で、ユーザーがアプリで日付と時刻を表示および設定できるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-104">Date and time controls give you standard, localized ways to let a user view and set date and time values in your app.</span></span> <span data-ttu-id="fd9d2-105">この記事では設計ガイドラインを示し、適切なコントロールを選ぶのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-105">This article provides design guidelines and helps you pick the right control.</span></span>

> <span data-ttu-id="fd9d2-106">**重要な API**: [CalendarView クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)、[CalendarDatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)、[DatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)、[TimePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="fd9d2-106">**Important APIs**: [CalendarView class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx), [CalendarDatePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx), [DatePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx), [TimePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span></span>

<table>
<th align="left"><span data-ttu-id="fd9d2-107">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="fd9d2-107">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="fd9d2-108"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合は、こちらをクリックして<a href="xamlcontrolsgallery:/category/DataInput">アプリを開き、これらのコントロールの動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-108">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/category/DataInput">open the app and see these controls in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="fd9d2-109">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="fd9d2-109">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="fd9d2-110">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="fd9d2-110">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="which-date-or-time-control-should-you-use"></a><span data-ttu-id="fd9d2-111">日付または時刻コントロールの選択</span><span class="sxs-lookup"><span data-stu-id="fd9d2-111">Which date or time control should you use?</span></span>

<span data-ttu-id="fd9d2-112">4 つの日付および時刻コントロールから選択できますが、シナリオによって使用するコントロールは異なります。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-112">There are four date and time controls to choose from; the control you use depends on your scenario.</span></span> <span data-ttu-id="fd9d2-113">以下の情報を参考にして、アプリに適切なコントロールを選んでください。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-113">Use this info to pick the right control to use in your app.</span></span>

&nbsp;|&nbsp;|&nbsp;                                                                                                                      
--------------------|-------|-------------------------------------------------------------------------------------------------------------------------------
<span data-ttu-id="fd9d2-114">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="fd9d2-114">Calendar view</span></span>       |![カレンダー ビューの例](images/controls_calendar_monthview_small.png)|<span data-ttu-id="fd9d2-116">常に表示されるカレンダーから 1 つの日付または日付の範囲を選ぶ場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-116">Use to pick a single date or a range of dates from an always visible calendar.</span></span>                   
<span data-ttu-id="fd9d2-117">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-117">Calendar date picker</span></span>|![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-closed.png)|<span data-ttu-id="fd9d2-119">コンテキストに沿ったカレンダーから 1 つの日付を選ぶ場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-119">Use to pick a single date from a contextual calendar.</span></span> 
<span data-ttu-id="fd9d2-120">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-120">Date picker</span></span>         |![日付の選択コントロールの例](images/date-picker-closed.png)|<span data-ttu-id="fd9d2-122">コンテキスト情報が重要でない既知の 1 つの日付を選ぶ場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-122">Use to pick a single known date when contextual info isn't important.</span></span>
<span data-ttu-id="fd9d2-123">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-123">Time picker</span></span>         |![時刻の選択コントロールの例](images/time-picker-closed.png)|<span data-ttu-id="fd9d2-125">1 つの時刻を選ぶ場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-125">Use to pick a single time value.</span></span>                                        

<!-- This table seems redundant, not sure it's needed.-->

### <a name="calendar-view"></a><span data-ttu-id="fd9d2-126">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="fd9d2-126">Calendar view</span></span>

<span data-ttu-id="fd9d2-127">**CalendarView** を使うと、ユーザーはカレンダーを表示し操作できます (カレンダーは、月、年、または 10 年単位で操作できます)。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-127">**CalendarView** lets a user view and interact with a calendar that they can navigate by month, year, or decade.</span></span> <span data-ttu-id="fd9d2-128">ユーザーは 1 つの日付や日付の範囲を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-128">A user can select a single date or a range of dates.</span></span> <span data-ttu-id="fd9d2-129">カレンダー ビューには選択コントロール サーフェイスがなく、カレンダーは常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-129">It doesn't have a picker surface and the calendar is always visible.</span></span>

<span data-ttu-id="fd9d2-130">カレンダー ビューは、月ビュー、年ビュー、10 年ビューという 3 つの個別のビューで構成されています。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-130">The calendar view is made up of 3 separate views: the month view, year view, and decade view.</span></span> <span data-ttu-id="fd9d2-131">既定では、月ビューが開きますが、任意のビューをスタートアップ ビューとして指定できます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-131">By default, it starts with the month view open, but you can specify any view as the startup view.</span></span>

![カレンダーの日付の選択コントロールの例](images/calendar-view-3-views.png)

- <span data-ttu-id="fd9d2-133">ユーザーが複数の日付を選べるようにする必要がある場合は、**CalendarView** を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-133">If you need to let a user select multiple dates, you must use a **CalendarView**.</span></span>
- <span data-ttu-id="fd9d2-134">ユーザーが 1 つの日付しか選べないようにする必要があり、カレンダーを常に表示する必要がない場合は、**CalendarDatePicker** または **DatePicker** を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-134">If you need to let a user pick only a single date and don’t need a calendar to be always visible, consider using a **CalendarDatePicker** or **DatePicker** control.</span></span>

### <a name="calendar-date-picker"></a><span data-ttu-id="fd9d2-135">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-135">Calendar date picker</span></span>

<span data-ttu-id="fd9d2-136">**CalendarDatePicker** は、カレンダーの曜日や埋まり具合などのコンテキスト情報が必要となるカレンダー ビューから単一の日付を選ぶ用途に最適なドロップダウン コントロールです。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-136">**CalendarDatePicker** is a drop down control that’s optimized for picking a single date from a calendar view where contextual information like the day of the week or fullness of the calendar is important.</span></span> <span data-ttu-id="fd9d2-137">追加のコンテキストを提供する場合、または利用可能日を制限する場合は、カレンダーを変更できます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-137">You can modify the calendar to provide additional context or to limit available dates.</span></span>

<span data-ttu-id="fd9d2-138">日付が設定されていない場合、エントリ ポイントにはプレースホルダー テキストが表示されます。設定されている場合は、選んだ日付が表示されます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-138">The entry point displays placeholder text if a date has not been set; otherwise, it displays the chosen date.</span></span> <span data-ttu-id="fd9d2-139">ユーザーがエントリ ポイントを選ぶと、カレンダー ビューが展開されて、ユーザーが日付を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-139">When the user selects the entry point, a calendar view expands for the user to make a date selection.</span></span> <span data-ttu-id="fd9d2-140">カレンダー ビューは他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-140">The calendar view overlays other UI; it doesn't push other UI out of the way.</span></span>

![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-2-views.png)

- <span data-ttu-id="fd9d2-142">カレンダーの日付の選択コントロールは、予定日や出発日の選択などに使います。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-142">Use a calendar date picker for things like choosing an appointment or departure date.</span></span> 

### <a name="date-picker"></a><span data-ttu-id="fd9d2-143">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-143">Date picker</span></span>

<span data-ttu-id="fd9d2-144">**DatePicker** コントロールによって、標準化された方法で特定の日付を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-144">The **DatePicker** control provides a standardized way to choose a specific date.</span></span> 

<span data-ttu-id="fd9d2-145">エントリ ポイントには、選んだ日付が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、日付を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-145">The entry point displays the chosen date, and when the user selects the entry point, a picker surface expands vertically from the middle for the user to make a selection.</span></span> <span data-ttu-id="fd9d2-146">日付の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-146">The date picker overlays other UI; it doesn't push other UI out of the way.</span></span>

![展開した日付の選択コントロールの例](images/controls_datepicker_expand.png)

- <span data-ttu-id="fd9d2-148">日付の選択コントロールは、ユーザーが誕生日などの既知の日付 (カレンダーのコンテキストが重要ではない日) を選べるようにする場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-148">Use a date picker to let a user pick a known date, such as a date of birth, where the context of the calendar is not important.</span></span>

### <a name="time-picker"></a><span data-ttu-id="fd9d2-149">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-149">Time picker</span></span>

<span data-ttu-id="fd9d2-150">**TimePicker** は、予定や出発時刻などの 1 つの時刻を選択する場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-150">The **TimePicker** is used to select a single time value for things like appointments or a departure time.</span></span> <span data-ttu-id="fd9d2-151">ユーザーまたはコードによって設定された静的な表示であるため、更新して現在の時刻を表示することはできません。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-151">It's a static display that is set by the user or in code, but it doesn't update to display the current time.</span></span> 

<span data-ttu-id="fd9d2-152">エントリ ポイントには、選んだ時刻が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、時刻を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-152">The entry point displays the chosen time, and when the user selects the entry point, a picker surface expands vertically from the middle for the user to make a selection.</span></span> <span data-ttu-id="fd9d2-153">時刻の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-153">The time picker overlays other UI; it doesn't push other UI out of the way.</span></span>

![展開した時刻の選択コントロールの例](images/controls_timepicker_expand.png)

- <span data-ttu-id="fd9d2-155">時刻の選択コントロールを使って、ユーザーが 1 つの時刻を選べるようにします。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-155">Use a time picker to let a user pick a single time value.</span></span>

## <a name="create-a-date-or-time-control"></a><span data-ttu-id="fd9d2-156">日付または時刻コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="fd9d2-156">Create a date or time control</span></span>

<span data-ttu-id="fd9d2-157">日付および時刻コントロールの詳細と例については、次の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-157">See these articles for info and examples specific to each date and time control.</span></span>

- [<span data-ttu-id="fd9d2-158">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="fd9d2-158">Calendar view</span></span>](calendar-view.md)
- [<span data-ttu-id="fd9d2-159">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-159">Calendar date picker</span></span>](calendar-date-picker.md)
- [<span data-ttu-id="fd9d2-160">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-160">Date picker</span></span>](date-picker.md)
- [<span data-ttu-id="fd9d2-161">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="fd9d2-161">Time Picker</span></span>](time-picker.md)

### <a name="globalization"></a><span data-ttu-id="fd9d2-162">グローバリゼーション</span><span class="sxs-lookup"><span data-stu-id="fd9d2-162">Globalization</span></span>

<span data-ttu-id="fd9d2-163">XAML の日付のコントロールでは、Windows でサポートされる各カレンダー システムがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-163">The XAML date controls support each of the calendar systems supported by Windows.</span></span> <span data-ttu-id="fd9d2-164">それらのカレンダーは [Windows.Globalization.CalendarIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendaridentifiers.aspx) クラスで指定されます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-164">These calendars are specified in the [Windows.Globalization.CalendarIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendaridentifiers.aspx) class.</span></span> <span data-ttu-id="fd9d2-165">各コントロールは、アプリの既定の言語に適したカレンダーを使います。または、**CalendarIdentifier** プロパティを設定して特定のカレンダー システムを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-165">Each control uses the correct calendar for your app's default language, or you can set the **CalendarIdentifier** property to use a specific calendar system.</span></span>

<span data-ttu-id="fd9d2-166">時刻の選択コントロールでは、[Windows.Globalization.ClockIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.clockidentifiers.aspx) クラスで指定される各クロック システムがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-166">The time picker control supports each of the clock systems specified in the [Windows.Globalization.ClockIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.clockidentifiers.aspx) class.</span></span> <span data-ttu-id="fd9d2-167">[ClockIdentifier](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.clockidentifier.aspx) プロパティを設定し、12 時間形式または 24 時間形式を指定できます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-167">You can set the [ClockIdentifier](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.clockidentifier.aspx) property to use either a 12-hour clock or 24-hour clock.</span></span> <span data-ttu-id="fd9d2-168">プロパティの型は文字列ですが、ClockIdentifiers クラスの静的な文字列プロパティに対応する値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-168">The type of the property is String, but you must use values that correspond to the static string properties of the ClockIdentifiers class.</span></span> <span data-ttu-id="fd9d2-169">それらの値とは、TwelveHour (文字列 "12HourClock") と TwentyFourHour (文字列 "24HourClock") です。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-169">These are: TwelveHour (the string "12HourClock")and TwentyFourHour (the string "24HourClock").</span></span> <span data-ttu-id="fd9d2-170">既定値は "12HourClock" です。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-170">"12HourClock" is the default value.</span></span>


### <a name="datetime-and-calendar-values"></a><span data-ttu-id="fd9d2-171">DateTime と Calendar の値</span><span class="sxs-lookup"><span data-stu-id="fd9d2-171">DateTime and Calendar values</span></span>

<span data-ttu-id="fd9d2-172">XAML の日付および時刻コントロールで使用される日付オブジェクトでは、プログラミング言語によって表現方法が異なります。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-172">The date objects used in the XAML date and time controls have a different representation depending on your programming language.</span></span> 
- <span data-ttu-id="fd9d2-173">C# および Visual Basic では、.NET の一部である [System.DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) 構造体が使用されます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-173">C# and Visual Basic use the [System.DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) structure that is part of .NET.</span></span> 
- <span data-ttu-id="fd9d2-174">C++/CX では、[Windows::Foundation::DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/br205770.aspx) 構造体が使用されます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-174">C++/CX uses the [Windows::Foundation::DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/br205770.aspx) structure.</span></span> 

<span data-ttu-id="fd9d2-175">関連する概念として Calendar クラスがあります。Calendar クラスは、コンテキストでの日付の解釈方法に影響を及ぼします。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-175">A related concept is the Calendar class, which influences how dates are interpreted in context.</span></span> <span data-ttu-id="fd9d2-176">すべての Windows ランタイム アプリで、[Windows.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendar.aspx) クラスを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-176">All Windows Runtime apps can use the [Windows.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendar.aspx) class.</span></span> <span data-ttu-id="fd9d2-177">C# および Visual Basic アプリでは、代わりに機能が非常によく似た [System.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/system.globalization.calendar.aspx) クラスを使用することができます </span><span class="sxs-lookup"><span data-stu-id="fd9d2-177">C# and Visual Basic apps can alternatively use the [System.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/system.globalization.calendar.aspx) class, which has very similar functionality.</span></span> <span data-ttu-id="fd9d2-178">(Windows ランタイム アプリでは、基本の .NET Calendar クラスを使用することはできますが、GregorianCalendar などの具体的な実装を使用することはできません)。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-178">(Windows Runtime apps can use the base .NET Calendar class but not the specific implementations; for example, GregorianCalendar.)</span></span>

<span data-ttu-id="fd9d2-179">.NET では、[DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) という名前の型もサポートされます。これは、暗黙的に [DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) と読み替えることができます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-179">.NET also supports a type named [DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx), which is implicitly convertible to a [DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx).</span></span> <span data-ttu-id="fd9d2-180">したがって、.NET コードで値を設定するために "DateTime" 型が使用されていた場合、それは実際には DateTimeOffset です。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-180">So you might see a "DateTime" type being used in .NET code that's used to set values that are really DateTimeOffset.</span></span> <span data-ttu-id="fd9d2-181">DateTime と DateTimeOffset の違いについて詳しくは、「[DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx)クラス」の「注釈」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-181">For more info on the difference between DateTime and DateTimeOffset, see Remarks in the [DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) class.</span></span>

> <span data-ttu-id="fd9d2-182">**注:**&nbsp;&nbsp;日付オブジェクトを受け取るプロパティは、XAML 属性文字列として設定することはできません。これは、Windows ランタイム XAML パーサーには、文字列を DateTime/DateTimeOffset オブジェクトとして日付に変換する変換ロジックがないためです。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-182">**Note**&nbsp;&nbsp;Properties that take date objects can't be set as a XAML attribute string, because the Windows Runtime XAML parser doesn't have a conversion logic for converting strings to dates as DateTime/DateTimeOffset objects.</span></span> <span data-ttu-id="fd9d2-183">通常、それらの値はコードで設定します。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-183">You typically set these values in code.</span></span> <span data-ttu-id="fd9d2-184">考えられる別の方法として、データ オブジェクトとして (またはデータ コンテキストで) 利用可能な日付を定義し、その日付をデータとしてアクセスできる [\{Binding\} マークアップ拡張](../../xaml-platform/binding-markup-extension.md)表現を参照する XAML 属性をプロパティとして設定することができます。</span><span class="sxs-lookup"><span data-stu-id="fd9d2-184">Another possible technique is to define a date that's available as a data object or in the data context, then set the property as a XAML attribute that references a [\{Binding\} markup extension](../../xaml-platform/binding-markup-extension.md) expression that can access the date as data.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="fd9d2-185">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="fd9d2-185">Get the sample code</span></span>
* [<span data-ttu-id="fd9d2-186">XAML UI の基本のサンプル</span><span class="sxs-lookup"><span data-stu-id="fd9d2-186">XAML UI basics sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)


## <a name="related-topics"></a><span data-ttu-id="fd9d2-187">関連トピック</span><span class="sxs-lookup"><span data-stu-id="fd9d2-187">Related topics</span></span>

**<span data-ttu-id="fd9d2-188">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="fd9d2-188">For developers (XAML)</span></span>**
- [<span data-ttu-id="fd9d2-189">CalendarView クラス</span><span class="sxs-lookup"><span data-stu-id="fd9d2-189">CalendarView class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn890052)
- [<span data-ttu-id="fd9d2-190">CalendarDatePicker クラス</span><span class="sxs-lookup"><span data-stu-id="fd9d2-190">CalendarDatePicker class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn950083)
- [<span data-ttu-id="fd9d2-191">DatePicker クラス</span><span class="sxs-lookup"><span data-stu-id="fd9d2-191">DatePicker class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn298584)
- [<span data-ttu-id="fd9d2-192">TimePicker クラス</span><span class="sxs-lookup"><span data-stu-id="fd9d2-192">TimePicker class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn299280)
