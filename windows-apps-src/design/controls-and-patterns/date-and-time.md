---
Description: 日付と時刻のコントロールでは、日付と時刻を表示および設定できます。 この記事では設計ガイドラインを示し、適切なコントロールを選ぶのに役立ちます。
title: 日付コントロールと時刻コントロールのガイドライン
ms.assetid: 4641FFBB-8D82-4290-94C1-D87617997F61
label: Calendar, date, and time controls
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: kisai
design-contact: ksulliv
dev-contact: joyate
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 93be1b0b947be84e795a29774b4b26cb888f5f1a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660277"
---
# <a name="calendar-date-and-time-controls"></a><span data-ttu-id="37585-105">カレンダー、日付、および時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-105">Calendar, date, and time controls</span></span>

 

<span data-ttu-id="37585-106">日付コントロールと時刻コントロールを使用することで、その地域に合った標準化された方法で、ユーザーがアプリで日付と時刻を表示および設定できるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="37585-106">Date and time controls give you standard, localized ways to let a user view and set date and time values in your app.</span></span> <span data-ttu-id="37585-107">この記事では設計ガイドラインを示し、適切なコントロールを選ぶのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="37585-107">This article provides design guidelines and helps you pick the right control.</span></span>

> <span data-ttu-id="37585-108">**重要な API**:[予定表ビュー クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)、 [CalendarDatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)、 [DatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)、 [TimePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span><span class="sxs-lookup"><span data-stu-id="37585-108">**Important APIs**: [CalendarView class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx), [CalendarDatePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx), [DatePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx), [TimePicker class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)</span></span>

<table>
<th align="left"><span data-ttu-id="37585-109">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="37585-109">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="37585-110"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合は、こちらをクリックして<a href="xamlcontrolsgallery:/category/DataInput">アプリを開き、これらのコントロールの動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="37585-110">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/category/DataInput">open the app and see these controls in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="37585-111"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></span><span class="sxs-lookup"><span data-stu-id="37585-111"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="37585-112"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></span><span class="sxs-lookup"><span data-stu-id="37585-112"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

## <a name="which-date-or-time-control-should-you-use"></a><span data-ttu-id="37585-113">日付または時刻コントロールの選択</span><span class="sxs-lookup"><span data-stu-id="37585-113">Which date or time control should you use?</span></span>

<span data-ttu-id="37585-114">4 つの日付および時刻コントロールから選択できますが、シナリオによって使用するコントロールは異なります。</span><span class="sxs-lookup"><span data-stu-id="37585-114">There are four date and time controls to choose from; the control you use depends on your scenario.</span></span> <span data-ttu-id="37585-115">以下の情報を参考にして、アプリに適切なコントロールを選んでください。</span><span class="sxs-lookup"><span data-stu-id="37585-115">Use this info to pick the right control to use in your app.</span></span>

&nbsp;|&nbsp;|&nbsp;                                                                                                                      
--------------------|-------|-------------------------------------------------------------------------------------------------------------------------------
<span data-ttu-id="37585-116">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="37585-116">Calendar view</span></span>       |![カレンダー ビューの例](images/controls_calendar_monthview_small.png)|<span data-ttu-id="37585-118">常に表示されるカレンダーから 1 つの日付または日付の範囲を選ぶ場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="37585-118">Use to pick a single date or a range of dates from an always visible calendar.</span></span>                   
<span data-ttu-id="37585-119">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-119">Calendar date picker</span></span>|![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-closed.png)|<span data-ttu-id="37585-121">コンテキストに沿ったカレンダーから 1 つの日付を選ぶ場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="37585-121">Use to pick a single date from a contextual calendar.</span></span> 
<span data-ttu-id="37585-122">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-122">Date picker</span></span>         |![日付の選択コントロールの例](images/date-picker-closed.png)|<span data-ttu-id="37585-124">コンテキスト情報が重要でない既知の 1 つの日付を選ぶ場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="37585-124">Use to pick a single known date when contextual info isn't important.</span></span>
<span data-ttu-id="37585-125">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-125">Time picker</span></span>         |![時刻の選択コントロールの例](images/time-picker-closed.png)|<span data-ttu-id="37585-127">1 つの時刻を選ぶ場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="37585-127">Use to pick a single time value.</span></span>                                        

<!-- This table seems redundant, not sure it's needed.-->

### <a name="calendar-view"></a><span data-ttu-id="37585-128">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="37585-128">Calendar view</span></span>

<span data-ttu-id="37585-129">**CalendarView** を使うと、ユーザーはカレンダーを表示し操作できます (カレンダーは、月、年、または 10 年単位で操作できます)。</span><span class="sxs-lookup"><span data-stu-id="37585-129">**CalendarView** lets a user view and interact with a calendar that they can navigate by month, year, or decade.</span></span> <span data-ttu-id="37585-130">ユーザーは 1 つの日付や日付の範囲を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="37585-130">A user can select a single date or a range of dates.</span></span> <span data-ttu-id="37585-131">カレンダー ビューには選択コントロール サーフェイスがなく、カレンダーは常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="37585-131">It doesn't have a picker surface and the calendar is always visible.</span></span>

<span data-ttu-id="37585-132">カレンダー ビューは、月ビュー、年ビュー、10 年ビューという 3 つの個別のビューで構成されています。</span><span class="sxs-lookup"><span data-stu-id="37585-132">The calendar view is made up of 3 separate views: the month view, year view, and decade view.</span></span> <span data-ttu-id="37585-133">既定では、月ビューが開きますが、任意のビューをスタートアップ ビューとして指定できます。</span><span class="sxs-lookup"><span data-stu-id="37585-133">By default, it starts with the month view open, but you can specify any view as the startup view.</span></span>

![カレンダーの日付の選択コントロールの例](images/calendar-view-3-views.png)

- <span data-ttu-id="37585-135">ユーザーが複数の日付を選べるようにする必要がある場合は、**CalendarView** を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="37585-135">If you need to let a user select multiple dates, you must use a **CalendarView**.</span></span>
- <span data-ttu-id="37585-136">ユーザーが 1 つの日付しか選べないようにする必要があり、カレンダーを常に表示する必要がない場合は、**CalendarDatePicker** または **DatePicker** を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="37585-136">If you need to let a user pick only a single date and don’t need a calendar to be always visible, consider using a **CalendarDatePicker** or **DatePicker** control.</span></span>

### <a name="calendar-date-picker"></a><span data-ttu-id="37585-137">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-137">Calendar date picker</span></span>

<span data-ttu-id="37585-138">**CalendarDatePicker** は、カレンダーの曜日や埋まり具合などのコンテキスト情報が必要となるカレンダー ビューから 1 つの日付を選ぶ用途に最適なドロップダウン コントロールです。</span><span class="sxs-lookup"><span data-stu-id="37585-138">**CalendarDatePicker** is a drop down control that’s optimized for picking a single date from a calendar view where contextual information like the day of the week or fullness of the calendar is important.</span></span> <span data-ttu-id="37585-139">追加のコンテキストを提供したり、使用可能な日付を制限したりするように、カレンダーを変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="37585-139">You can modify the calendar to provide additional context or to limit available dates.</span></span>

<span data-ttu-id="37585-140">日付が設定されていない場合、エントリ ポイントにはプレースホルダー テキストが表示されます。設定されている場合は、選んだ日付が表示されます。</span><span class="sxs-lookup"><span data-stu-id="37585-140">The entry point displays placeholder text if a date has not been set; otherwise, it displays the chosen date.</span></span> <span data-ttu-id="37585-141">ユーザーがエントリ ポイントを選ぶと、カレンダー ビューが展開されて、ユーザーが日付を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="37585-141">When the user selects the entry point, a calendar view expands for the user to make a date selection.</span></span> <span data-ttu-id="37585-142">カレンダー ビューは他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="37585-142">The calendar view overlays other UI; it doesn't push other UI out of the way.</span></span>

![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-2-views.png)

- <span data-ttu-id="37585-144">カレンダーの日付の選択コントロールは、予定日や出発日の選択などに使います。</span><span class="sxs-lookup"><span data-stu-id="37585-144">Use a calendar date picker for things like choosing an appointment or departure date.</span></span> 

### <a name="date-picker"></a><span data-ttu-id="37585-145">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-145">Date picker</span></span>

<span data-ttu-id="37585-146">**DatePicker** コントロールによって、標準化された方法で特定の日付を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="37585-146">The **DatePicker** control provides a standardized way to choose a specific date.</span></span> 

<span data-ttu-id="37585-147">エントリ ポイントには、選んだ日付が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、日付を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="37585-147">The entry point displays the chosen date, and when the user selects the entry point, a picker surface expands vertically from the middle for the user to make a selection.</span></span> <span data-ttu-id="37585-148">日付の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="37585-148">The date picker overlays other UI; it doesn't push other UI out of the way.</span></span>

![展開した日付の選択コントロールの例](images/controls_datepicker_expand.png)

- <span data-ttu-id="37585-150">日付の選択コントロールは、ユーザーが誕生日などの既知の日付 (カレンダーのコンテキストが重要ではない日) を選べるようにする場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="37585-150">Use a date picker to let a user pick a known date, such as a date of birth, where the context of the calendar is not important.</span></span>

### <a name="time-picker"></a><span data-ttu-id="37585-151">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-151">Time picker</span></span>

<span data-ttu-id="37585-152">**TimePicker** は、予定や出発時刻などの 1 つの時刻を選択する場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="37585-152">The **TimePicker** is used to select a single time value for things like appointments or a departure time.</span></span> <span data-ttu-id="37585-153">ユーザーまたはコードによって設定された静的な表示であるため、更新して現在の時刻を表示することはできません。</span><span class="sxs-lookup"><span data-stu-id="37585-153">It's a static display that is set by the user or in code, but it doesn't update to display the current time.</span></span> 

<span data-ttu-id="37585-154">エントリ ポイントには、選んだ時刻が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェスが中央から縦方向に展開されて、時刻を選べるようになります。</span><span class="sxs-lookup"><span data-stu-id="37585-154">The entry point displays the chosen time, and when the user selects the entry point, a picker surface expands vertically from the middle for the user to make a selection.</span></span> <span data-ttu-id="37585-155">時刻の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。</span><span class="sxs-lookup"><span data-stu-id="37585-155">The time picker overlays other UI; it doesn't push other UI out of the way.</span></span>

![展開した時刻の選択コントロールの例](images/controls_timepicker_expand.png)

- <span data-ttu-id="37585-157">時刻の選択コントロールを使って、ユーザーが 1 つの時刻を選べるようにします。</span><span class="sxs-lookup"><span data-stu-id="37585-157">Use a time picker to let a user pick a single time value.</span></span>

## <a name="create-a-date-or-time-control"></a><span data-ttu-id="37585-158">日付または時刻コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="37585-158">Create a date or time control</span></span>

<span data-ttu-id="37585-159">日付および時刻コントロールの詳細と例については、次の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="37585-159">See these articles for info and examples specific to each date and time control.</span></span>

- [<span data-ttu-id="37585-160">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="37585-160">Calendar view</span></span>](calendar-view.md)
- [<span data-ttu-id="37585-161">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-161">Calendar date picker</span></span>](calendar-date-picker.md)
- [<span data-ttu-id="37585-162">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="37585-162">Date picker</span></span>](date-picker.md)
- [<span data-ttu-id="37585-163">時刻の選択</span><span class="sxs-lookup"><span data-stu-id="37585-163">Time Picker</span></span>](time-picker.md)

### <a name="globalization"></a><span data-ttu-id="37585-164">Globalization</span><span class="sxs-lookup"><span data-stu-id="37585-164">Globalization</span></span>

<span data-ttu-id="37585-165">XAML の日付のコントロールでは、Windows でサポートされる各カレンダー システムがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="37585-165">The XAML date controls support each of the calendar systems supported by Windows.</span></span> <span data-ttu-id="37585-166">それらのカレンダーは [Windows.Globalization.CalendarIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendaridentifiers.aspx) クラスで指定されます。</span><span class="sxs-lookup"><span data-stu-id="37585-166">These calendars are specified in the [Windows.Globalization.CalendarIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendaridentifiers.aspx) class.</span></span> <span data-ttu-id="37585-167">各コントロールは、アプリの既定の言語に適したカレンダーを使います。または、**CalendarIdentifier** プロパティを設定して特定のカレンダー システムを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="37585-167">Each control uses the correct calendar for your app's default language, or you can set the **CalendarIdentifier** property to use a specific calendar system.</span></span>

<span data-ttu-id="37585-168">時刻の選択コントロールでは、[Windows.Globalization.ClockIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.clockidentifiers.aspx) クラスで指定される各クロック システムがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="37585-168">The time picker control supports each of the clock systems specified in the [Windows.Globalization.ClockIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.clockidentifiers.aspx) class.</span></span> <span data-ttu-id="37585-169">[ClockIdentifier](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.clockidentifier.aspx) プロパティを設定し、12 時間形式または 24 時間形式を指定できます。</span><span class="sxs-lookup"><span data-stu-id="37585-169">You can set the [ClockIdentifier](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.clockidentifier.aspx) property to use either a 12-hour clock or 24-hour clock.</span></span> <span data-ttu-id="37585-170">プロパティの型は文字列ですが、ClockIdentifiers クラスの静的な文字列プロパティに対応する値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="37585-170">The type of the property is String, but you must use values that correspond to the static string properties of the ClockIdentifiers class.</span></span> <span data-ttu-id="37585-171">それらを次に示します。TwelveHour ("12 hourclock"文字列) と TwentyFourHour (文字列"24 hourclock")。</span><span class="sxs-lookup"><span data-stu-id="37585-171">These are: TwelveHour (the string "12HourClock")and TwentyFourHour (the string "24HourClock").</span></span> <span data-ttu-id="37585-172">既定値は "12HourClock" です。</span><span class="sxs-lookup"><span data-stu-id="37585-172">"12HourClock" is the default value.</span></span>


### <a name="datetime-and-calendar-values"></a><span data-ttu-id="37585-173">DateTime と Calendar の値</span><span class="sxs-lookup"><span data-stu-id="37585-173">DateTime and Calendar values</span></span>

<span data-ttu-id="37585-174">XAML の日付および時刻コントロールで使用される日付オブジェクトでは、プログラミング言語によって表現方法が異なります。</span><span class="sxs-lookup"><span data-stu-id="37585-174">The date objects used in the XAML date and time controls have a different representation depending on your programming language.</span></span> 
- <span data-ttu-id="37585-175">C# および Visual Basic では、.NET の一部である [System.DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) 構造体が使用されます。</span><span class="sxs-lookup"><span data-stu-id="37585-175">C# and Visual Basic use the [System.DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) structure that is part of .NET.</span></span> 
- <span data-ttu-id="37585-176">C++/CX では、[Windows::Foundation::DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/br205770.aspx) 構造体が使用されます。</span><span class="sxs-lookup"><span data-stu-id="37585-176">C++/CX uses the [Windows::Foundation::DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/br205770.aspx) structure.</span></span> 

<span data-ttu-id="37585-177">関連する概念として Calendar クラスがあります。Calendar クラスは、コンテキストでの日付の解釈方法に影響を及ぼします。</span><span class="sxs-lookup"><span data-stu-id="37585-177">A related concept is the Calendar class, which influences how dates are interpreted in context.</span></span> <span data-ttu-id="37585-178">すべての Windows ランタイム アプリで、[Windows.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendar.aspx) クラスを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="37585-178">All Windows Runtime apps can use the [Windows.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendar.aspx) class.</span></span> <span data-ttu-id="37585-179">C# および Visual Basic アプリでは、代わりに機能が非常によく似た [System.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/system.globalization.calendar.aspx) クラスを使用することができます </span><span class="sxs-lookup"><span data-stu-id="37585-179">C# and Visual Basic apps can alternatively use the [System.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/system.globalization.calendar.aspx) class, which has very similar functionality.</span></span> <span data-ttu-id="37585-180">(Windows ランタイム アプリでは、基本の .NET Calendar クラスを使用することはできますが、GregorianCalendar などの具体的な実装を使用することはできません)。</span><span class="sxs-lookup"><span data-stu-id="37585-180">(Windows Runtime apps can use the base .NET Calendar class but not the specific implementations; for example, GregorianCalendar.)</span></span>

<span data-ttu-id="37585-181">.NET では、[DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) という名前の型もサポートされます。これは、暗黙的に [DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) と読み替えることができます。</span><span class="sxs-lookup"><span data-stu-id="37585-181">.NET also supports a type named [DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx), which is implicitly convertible to a [DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx).</span></span> <span data-ttu-id="37585-182">したがって、.NET コードで値を設定するために "DateTime" 型が使用されていた場合、それは実際には DateTimeOffset です。</span><span class="sxs-lookup"><span data-stu-id="37585-182">So you might see a "DateTime" type being used in .NET code that's used to set values that are really DateTimeOffset.</span></span> <span data-ttu-id="37585-183">DateTime と DateTimeOffset の違いについて詳しくは、「[DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx)クラス」の「注釈」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="37585-183">For more info on the difference between DateTime and DateTimeOffset, see Remarks in the [DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) class.</span></span>

> <span data-ttu-id="37585-184">**注:**&nbsp;&nbsp;日付オブジェクトを受け取るプロパティは、XAML 属性文字列として設定することはできません。これは、Windows ランタイム XAML パーサーには、文字列を DateTime/DateTimeOffset オブジェクトとして日付に変換する変換ロジックがないためです。</span><span class="sxs-lookup"><span data-stu-id="37585-184">**Note**&nbsp;&nbsp;Properties that take date objects can't be set as a XAML attribute string, because the Windows Runtime XAML parser doesn't have a conversion logic for converting strings to dates as DateTime/DateTimeOffset objects.</span></span> <span data-ttu-id="37585-185">通常、それらの値はコードで設定します。</span><span class="sxs-lookup"><span data-stu-id="37585-185">You typically set these values in code.</span></span> <span data-ttu-id="37585-186">もう 1 つの可能な手法は、データ オブジェクトとして、またはデータ コンテキストでは使用しを参照する XAML 属性としてプロパティを設定する日付を定義する、 [\{バインド\}マークアップ拡張機能](../../xaml-platform/binding-markup-extension.md)式日付としてデータにアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="37585-186">Another possible technique is to define a date that's available as a data object or in the data context, then set the property as a XAML attribute that references a [\{Binding\} markup extension](../../xaml-platform/binding-markup-extension.md) expression that can access the date as data.</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="37585-187">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="37585-187">Get the sample code</span></span>
* [<span data-ttu-id="37585-188">XAML UI の基本サンプル</span><span class="sxs-lookup"><span data-stu-id="37585-188">XAML UI basics sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)


## <a name="related-topics"></a><span data-ttu-id="37585-189">関連トピック</span><span class="sxs-lookup"><span data-stu-id="37585-189">Related topics</span></span>

<span data-ttu-id="37585-190">**開発者向け (XAML)**</span><span class="sxs-lookup"><span data-stu-id="37585-190">**For developers (XAML)**</span></span>
- [<span data-ttu-id="37585-191">予定表ビュー クラス</span><span class="sxs-lookup"><span data-stu-id="37585-191">CalendarView class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn890052)
- [<span data-ttu-id="37585-192">CalendarDatePicker クラス</span><span class="sxs-lookup"><span data-stu-id="37585-192">CalendarDatePicker class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn950083)
- [<span data-ttu-id="37585-193">DatePicker クラス</span><span class="sxs-lookup"><span data-stu-id="37585-193">DatePicker class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn298584)
- [<span data-ttu-id="37585-194">TimePicker クラス</span><span class="sxs-lookup"><span data-stu-id="37585-194">TimePicker class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn299280)
