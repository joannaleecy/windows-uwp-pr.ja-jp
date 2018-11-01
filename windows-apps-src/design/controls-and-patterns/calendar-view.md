---
author: muhsinking
Description: A calendar view lets a user view and interact with a calendar that they can navigate by month, year, or decade.
title: カレンダー ビュー
ms.assetid: d8ec5ba8-7a9d-405d-a1a5-5a1b502b9e64
label: Calendar view
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
ms.openlocfilehash: fba6d8ee56e4d9a3d187721b4b2f1c5daa9b1b1f
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5882580"
---
# <a name="calendar-view"></a><span data-ttu-id="007ee-103">カレンダー ビュー</span><span class="sxs-lookup"><span data-stu-id="007ee-103">Calendar view</span></span>

<span data-ttu-id="007ee-104">カレンダー ビューを使うと、ユーザーはカレンダーを表示し操作できます (カレンダーは、月、年、または 10 年単位で操作できます)。</span><span class="sxs-lookup"><span data-stu-id="007ee-104">A calendar view lets a user view and interact with a calendar that they can navigate by month, year, or decade.</span></span> <span data-ttu-id="007ee-105">ユーザーは 1 つの日付や日付の範囲を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="007ee-105">A user can select a single date or a range of dates.</span></span> <span data-ttu-id="007ee-106">カレンダー ビューには選択コントロール サーフェイスがなく、カレンダーは常に表示されます。</span><span class="sxs-lookup"><span data-stu-id="007ee-106">It doesn't have a picker surface and the calendar is always visible.</span></span> 

> <span data-ttu-id="007ee-107">**重要な API**: [CalendarView クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)、[SelectedDatesChanged イベント](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddateschanged.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-107">**Important APIs**:  [CalendarView class](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx), [SelectedDatesChanged event](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddateschanged.aspx)</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="007ee-108">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="007ee-108">Is this the right control?</span></span>
<span data-ttu-id="007ee-109">カレンダー ビューを使うと、ユーザーは常に表示されているカレンダーから 1 つの日付または日付の範囲を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="007ee-109">Use a calendar view to let a user pick a single date or a range of dates from an always visible calendar.</span></span>

<span data-ttu-id="007ee-110">ユーザーが一度に複数の日付を選べるようにする必要がある場合は、カレンダー ビューを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="007ee-110">If you need to let a user select multiple dates at one time, you must use a calendar view.</span></span> <span data-ttu-id="007ee-111">ユーザーが 1 つの日付しか選べないようにする必要があり、カレンダーを常に表示する必要がない場合は、[カレンダーの日付の選択コントロール](calendar-date-picker.md) または [日付の選択コントロール](date-picker.md) を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="007ee-111">If you need to let a user pick only a single date and don’t need a calendar to be always visible, consider using a [calendar date picker](calendar-date-picker.md) or [date picker](date-picker.md) control.</span></span>

<span data-ttu-id="007ee-112">適切なコントロールの選択について詳しくは、「[日付と時刻コントロール](date-and-time.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="007ee-112">For more info about choosing the right control, see the [Date and time controls](date-and-time.md) article.</span></span>

## <a name="examples"></a><span data-ttu-id="007ee-113">例</span><span class="sxs-lookup"><span data-stu-id="007ee-113">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="007ee-114">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="007ee-114">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="007ee-115"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/CalendarView">アプリを開き、CalendarView の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="007ee-115">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CalendarView">open the app and see the CalendarView in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="007ee-116">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="007ee-116">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="007ee-117">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="007ee-117">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="007ee-118">カレンダー ビューは、月ビュー、年ビュー、10 年ビューという 3 つの個別のビューで構成されています。</span><span class="sxs-lookup"><span data-stu-id="007ee-118">The calendar view is made up of 3 separate views: the month view, year view, and decade view.</span></span> <span data-ttu-id="007ee-119">既定では、月ビューが開きます。</span><span class="sxs-lookup"><span data-stu-id="007ee-119">By default, it starts with the month view open.</span></span> <span data-ttu-id="007ee-120">スタートアップ表示を指定するには、[DisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.displaymode.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="007ee-120">You can specify a startup view by setting the [DisplayMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.displaymode.aspx) property.</span></span>

![カレンダー ビューの 3 つのビュー](images/calendar-view-3-views.png)

<span data-ttu-id="007ee-122">ユーザーが月ビューのヘッダーをクリックすると年ビューが開き、年ビューのヘッダーをクリックすると 10 年ビューが開きます。</span><span class="sxs-lookup"><span data-stu-id="007ee-122">Users click the header in the month view to open the year view, and click the header in the year view to open the decade view.</span></span> <span data-ttu-id="007ee-123">また、10 年ビューで年を選ぶと年ビューに戻り、年ビューで月を選ぶと月ビューに戻ります。</span><span class="sxs-lookup"><span data-stu-id="007ee-123">Users pick a year in the decade view to return to the year view, and pick a month in the year view to return to the month view.</span></span> <span data-ttu-id="007ee-124">ヘッダーの横にある 2 つの矢印を使うと、月、年、10 年単位で前後に移動できます。</span><span class="sxs-lookup"><span data-stu-id="007ee-124">The two arrows to the side of the header navigate forward or backward by month, by year, or by decade.</span></span> 

## <a name="create-a-calendar-view"></a><span data-ttu-id="007ee-125">カレンダー ビューの作成</span><span class="sxs-lookup"><span data-stu-id="007ee-125">Create a calendar view</span></span>

<span data-ttu-id="007ee-126">次の例は、1 つのカレンダー ビューを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="007ee-126">This example shows how to create a simple calendar view.</span></span>

```xaml
<CalendarView/>
```

<span data-ttu-id="007ee-127">結果のカレンダー ビューは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="007ee-127">The resulting calendar view looks like this:</span></span>

![カレンダー ビューの例](images/controls_calendar_monthview.png)

### <a name="selecting-dates"></a><span data-ttu-id="007ee-129">日付の選択</span><span class="sxs-lookup"><span data-stu-id="007ee-129">Selecting dates</span></span>

<span data-ttu-id="007ee-130">既定では、[SelectionMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectionmode.aspx) プロパティは **Single** に設定されています。</span><span class="sxs-lookup"><span data-stu-id="007ee-130">By default, the [SelectionMode](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectionmode.aspx) property is set to **Single**.</span></span> <span data-ttu-id="007ee-131">このため、ユーザーはカレンダー内の 1 つの日付を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="007ee-131">This lets a user pick a single date in the calendar.</span></span> <span data-ttu-id="007ee-132">日付の選択を無効にするには、SelectionMode を **None** に設定します。</span><span class="sxs-lookup"><span data-stu-id="007ee-132">Set SelectionMode to **None** to disable date selection.</span></span> 

<span data-ttu-id="007ee-133">ユーザーが複数の日付を選べるようにするには、SelectionMode を **Multiple** に設定します。</span><span class="sxs-lookup"><span data-stu-id="007ee-133">Set SelectionMode to **Multiple** to let a user select multiple dates.</span></span> <span data-ttu-id="007ee-134">次のように [SelectedDates](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddates.aspx) コレクションに [DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx)/[DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) オブジェクトを追加すると、プログラムから複数の日付を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="007ee-134">You can select multiple dates programmatically by adding [DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx)/[DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) objects to the [SelectedDates](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddates.aspx) collection, as shown here:</span></span>

```csharp
calendarView1.SelectedDates.Add(DateTimeOffset.Now);
calendarView1.SelectedDates.Add(new DateTime(1977, 1, 5));
```

<span data-ttu-id="007ee-135">ユーザーは、選択済みの日付をカレンダー グリッドでクリックまたはタップすると、その日付の選択を解除できます。</span><span class="sxs-lookup"><span data-stu-id="007ee-135">A user can deselect a selected date by clicking or tapping it in the calendar grid.</span></span>

<span data-ttu-id="007ee-136">[SelectedDates](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddates.aspx) コレクションが変化したときに通知を受け取るようにするには、[SelectedDatesChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddateschanged.aspx) イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="007ee-136">You can handle the [SelectedDatesChanged](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddateschanged.aspx) event to be notified when the [SelectedDates](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selecteddates.aspx) collection has changed.</span></span>

> [!NOTE]
> <span data-ttu-id="007ee-137">日付値の重要な情報については、「日付と時刻コントロール」の「[DateTime と Calendar の値](date-and-time.md#datetime-and-calendar-values)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="007ee-137">For important info about date values, see [DateTime and Calendar values](date-and-time.md#datetime-and-calendar-values) in the Date and time controls article.</span></span>

### <a name="customizing-the-calendar-views-appearance"></a><span data-ttu-id="007ee-138">カレンダー ビューの外観のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="007ee-138">Customizing the calendar view's appearance</span></span>

<span data-ttu-id="007ee-139">カレンダー ビューは、ControlTemplate で定義される XAML 要素と、コントロールによって直接レンダリングされるビジュアル要素で構成されます。</span><span class="sxs-lookup"><span data-stu-id="007ee-139">The calendar view is composed of both XAML elements defined in the ControlTemplate and visual elements rendered directly by the control.</span></span> 
- <span data-ttu-id="007ee-140">コントロール テンプレートで定義される XAML 要素には、コントロールを囲む境界線、ヘッダー、[前へ] ボタンと [次へ] ボタン、および DayOfWeek 要素が含まれています。</span><span class="sxs-lookup"><span data-stu-id="007ee-140">The XAML elements defined in the control template include the border that encloses the control, the header, previous and next buttons, and DayOfWeek elements.</span></span> <span data-ttu-id="007ee-141">すべての XAML コントロールと同様、これらの要素にスタイルを指定し、テンプレートを再適用することができます。</span><span class="sxs-lookup"><span data-stu-id="007ee-141">You can style and re-template these elements like any XAML control.</span></span> 
- <span data-ttu-id="007ee-142">カレンダー グリッドは、[CalendarViewDayItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) オブジェクトで構成されています。</span><span class="sxs-lookup"><span data-stu-id="007ee-142">The calendar grid is composed of [CalendarViewDayItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) objects.</span></span> <span data-ttu-id="007ee-143">これらの要素のスタイルを指定したり、テンプレートを再適用することはできませんが、それらの外観をカスタマイズできるさまざまなプロパティが用意されています。</span><span class="sxs-lookup"><span data-stu-id="007ee-143">You can’t style or re-template these elements, but various properties are provided to let you to customize their appearance.</span></span>

<span data-ttu-id="007ee-144">次の図は、カレンダーの月ビューを構成する要素を示しています。</span><span class="sxs-lookup"><span data-stu-id="007ee-144">This diagram shows the elements that make up the month view of the calendar.</span></span> <span data-ttu-id="007ee-145">詳しくは、[CalendarViewDayItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) クラスの「解説」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="007ee-145">For more info, see the Remarks on the [CalendarViewDayItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) class.</span></span>

![カレンダーの月ビューの要素](images/calendar-view-month-elements.png)

<span data-ttu-id="007ee-147">次の表は、カレンダー要素の外観を変えるために変更できるプロパティを示しています。</span><span class="sxs-lookup"><span data-stu-id="007ee-147">This table lists the properties you can change to modify the appearance of calendar elements.</span></span>

<span data-ttu-id="007ee-148">要素</span><span class="sxs-lookup"><span data-stu-id="007ee-148">Element</span></span> | <span data-ttu-id="007ee-149">プロパティ</span><span class="sxs-lookup"><span data-stu-id="007ee-149">Properties</span></span>
--------|-----------
<span data-ttu-id="007ee-150">DayOfWeek</span><span class="sxs-lookup"><span data-stu-id="007ee-150">DayOfWeek</span></span> | [<span data-ttu-id="007ee-151">DayOfWeekFormat</span><span class="sxs-lookup"><span data-stu-id="007ee-151">DayOfWeekFormat</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayofweekformat.aspx)  
<span data-ttu-id="007ee-152">CalendarItem</span><span class="sxs-lookup"><span data-stu-id="007ee-152">CalendarItem</span></span> | <span data-ttu-id="007ee-153">[CalendarItemBackground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritembackground.aspx)、[CalendarItemBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemborderbrush.aspx)、[CalendarItemBorderThickness](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemborderthickness.aspx)、[CalendarItemForeground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemforeground.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-153">[CalendarItemBackground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritembackground.aspx), [CalendarItemBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemborderbrush.aspx), [CalendarItemBorderThickness](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemborderthickness.aspx), [CalendarItemForeground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendaritemforeground.aspx)</span></span>  
<span data-ttu-id="007ee-154">DayItem</span><span class="sxs-lookup"><span data-stu-id="007ee-154">DayItem</span></span> | <span data-ttu-id="007ee-155">[DayItemFontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontfamily.aspx)、[DayItemFontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontsize.aspx)、[DayItemFontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontstyle.aspx)、[DayItemFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontweight.aspx)、[HorizontalDayItemAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.horizontaldayitemalignment.aspx)、[VerticalDayItemAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.verticaldayitemalignment.aspx)、[CalendarViewDayItemStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendarviewdayitemstyle.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-155">[DayItemFontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontfamily.aspx), [DayItemFontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontsize.aspx), [DayItemFontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontstyle.aspx), [DayItemFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.dayitemfontweight.aspx), [HorizontalDayItemAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.horizontaldayitemalignment.aspx), [VerticalDayItemAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.verticaldayitemalignment.aspx), [CalendarViewDayItemStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendarviewdayitemstyle.aspx)</span></span>  
<span data-ttu-id="007ee-156">MonthYearItem (年ビューと 10 年ビューに含まれていて DayItem と等価)</span><span class="sxs-lookup"><span data-stu-id="007ee-156">MonthYearItem (in the year and decade views, equivalent to DayItem)</span></span> | <span data-ttu-id="007ee-157">[MonthYearItemFontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontfamily.aspx)、[MonthYearItemFontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontsize.aspx)、[MonthYearItemFontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontstyle.aspx)、[MonthYearItemFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontweight.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-157">[MonthYearItemFontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontfamily.aspx), [MonthYearItemFontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontsize.aspx), [MonthYearItemFontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontstyle.aspx), [MonthYearItemFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.monthyearitemfontweight.aspx)</span></span>  
<span data-ttu-id="007ee-158">FirstOfMonthLabel</span><span class="sxs-lookup"><span data-stu-id="007ee-158">FirstOfMonthLabel</span></span> | <span data-ttu-id="007ee-159">[FirstOfMonthLabelFontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontfamily.aspx)、[FirstOfMonthLabelFontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontsize.aspx)、[FirstOfMonthLabelFontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontstyle.aspx)、[FirstOfMonthLabelFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontweight.aspx)、[HorizontalFirstOfMonthLabelAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.horizontalfirstofmonthlabelalignment.aspx)、[VerticalFirstOfMonthLabelAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.verticalfirstofmonthlabelalignment.aspx)、[IsGroupLabelVisible](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.isgrouplabelvisible.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-159">[FirstOfMonthLabelFontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontfamily.aspx), [FirstOfMonthLabelFontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontsize.aspx), [FirstOfMonthLabelFontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontstyle.aspx), [FirstOfMonthLabelFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofmonthlabelfontweight.aspx), [HorizontalFirstOfMonthLabelAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.horizontalfirstofmonthlabelalignment.aspx), [VerticalFirstOfMonthLabelAlignment](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.verticalfirstofmonthlabelalignment.aspx), [IsGroupLabelVisible](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.isgrouplabelvisible.aspx)</span></span>  
<span data-ttu-id="007ee-160">FirstofYearDecadeLabel (年ビューと 10 年ビューに含まれていて、FirstOfMonthLabel と等価)</span><span class="sxs-lookup"><span data-stu-id="007ee-160">FirstofYearDecadeLabel (in the year and decade views, equivalent to FirstOfMonthLabel)</span></span> | <span data-ttu-id="007ee-161">[FirstOfYearDecadeLabelFontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontfamily.aspx)、[FirstOfYearDecadeLabelFontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontsize.aspx)、[FirstOfYearDecadeLabelFontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontstyle.aspx)、[FirstOfYearDecadeLabelFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontweight.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-161">[FirstOfYearDecadeLabelFontFamily](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontfamily.aspx), [FirstOfYearDecadeLabelFontSize](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontsize.aspx), [FirstOfYearDecadeLabelFontStyle](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontstyle.aspx), [FirstOfYearDecadeLabelFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.firstofyeardecadelabelfontweight.aspx)</span></span>  
<span data-ttu-id="007ee-162">表示状態の境界線</span><span class="sxs-lookup"><span data-stu-id="007ee-162">Visual State Borders</span></span> | <span data-ttu-id="007ee-163">[FocusBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.focusborderbrush.aspx)、[HoverBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.hoverborderbrush.aspx)、[PressedBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.pressedborderbrush.aspx)、[SelectedBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedborderbrush.aspx)、[SelectedForeground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedforeground.aspx)、[SelectedHoverBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedhoverborderbrush.aspx)、[SelectedPressedBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedpressedborderbrush.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-163">[FocusBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.focusborderbrush.aspx), [HoverBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.hoverborderbrush.aspx), [PressedBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.pressedborderbrush.aspx), [SelectedBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedborderbrush.aspx), [SelectedForeground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedforeground.aspx), [SelectedHoverBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedhoverborderbrush.aspx), [SelectedPressedBorderBrush](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.selectedpressedborderbrush.aspx)</span></span>  
<span data-ttu-id="007ee-164">OutofScope</span><span class="sxs-lookup"><span data-stu-id="007ee-164">OutofScope</span></span> | <span data-ttu-id="007ee-165">[IsOutOfScopeEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.isoutofscopeenabled.aspx)、[OutOfScopeBackground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.outofscopebackground.aspx)、[OutOfScopeForeground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.outofscopeforeground.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-165">[IsOutOfScopeEnabled](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.isoutofscopeenabled.aspx), [OutOfScopeBackground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.outofscopebackground.aspx), [OutOfScopeForeground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.outofscopeforeground.aspx)</span></span>  
<span data-ttu-id="007ee-166">Today</span><span class="sxs-lookup"><span data-stu-id="007ee-166">Today</span></span> | <span data-ttu-id="007ee-167">[IsTodayHighlighted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.istodayhighlighted.aspx)、[TodayFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.todayfontweight.aspx)、[TodayForeground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.todayforeground.aspx)</span><span class="sxs-lookup"><span data-stu-id="007ee-167">[IsTodayHighlighted](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.istodayhighlighted.aspx), [TodayFontWeight](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.todayfontweight.aspx), [TodayForeground](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.todayforeground.aspx)</span></span>  

 <span data-ttu-id="007ee-168">既定では、月ビューは一度に 6 週間を表示します。</span><span class="sxs-lookup"><span data-stu-id="007ee-168">By default, the month view shows 6 weeks at a time.</span></span> <span data-ttu-id="007ee-169">表示する週数を変更するには、[NumberOfWeeksInView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.numberofweeksinview.aspx)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="007ee-169">You can change the number of weeks shown by setting the [NumberOfWeeksInView](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.numberofweeksinview.aspx) property.</span></span> <span data-ttu-id="007ee-170">表示する週数の最小値は 2 で、最大値は 8 です。</span><span class="sxs-lookup"><span data-stu-id="007ee-170">The minimum number of weeks to show is 2; the maximum is 8.</span></span>

<span data-ttu-id="007ee-171">既定では、年ビューと 10 年ビューは 4x4 のグリッドに表示されます。</span><span class="sxs-lookup"><span data-stu-id="007ee-171">By default, the year and decade views show in a 4x4 grid.</span></span> <span data-ttu-id="007ee-172">行または列の数を変更するには、目的の行数と列数を指定して [SetYearDecadeDisplayDimensions](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.setyeardecadedisplaydimensions.aspx) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="007ee-172">To change the number of rows or columns, call [SetYearDecadeDisplayDimensions](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.setyeardecadedisplaydimensions.aspx) with the your desired number of rows and columns.</span></span> <span data-ttu-id="007ee-173">これにより、年ビューと 10 年ビューの両方のグリッドが変更されます。</span><span class="sxs-lookup"><span data-stu-id="007ee-173">This will change the grid for both the year and decade views.</span></span>

<span data-ttu-id="007ee-174">次の例は、年ビューと 10 年ビューを 3x4 のグリッドに表示するよう設定しています。</span><span class="sxs-lookup"><span data-stu-id="007ee-174">Here, the year and decade views are set to show in a 3x4 grid.</span></span>

```csharp
calendarView1.SetYearDecadeDisplayDimensions(3, 4);
```

<span data-ttu-id="007ee-175">既定では、カレンダー ビューに表示される日付の最小値は 100 年前の現在日で、表示される日付の最大値は 100 年後の現在日です。</span><span class="sxs-lookup"><span data-stu-id="007ee-175">By default, the minimum date shown in the calendar view is 100 years prior to the current date, and the maximum date shown is 100 years past the current date.</span></span> <span data-ttu-id="007ee-176">カレンダーに表示する最小日付と最大日付を変更するには、[MinDate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.mindate.aspx) プロパティと [MaxDate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.maxdate.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="007ee-176">You can change the minimum and maximum dates that the calendar shows by setting the [MinDate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.mindate.aspx) and [MaxDate](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.maxdate.aspx) properties.</span></span>

```csharp
calendarView1.MinDate = new DateTime(2000, 1, 1);
calendarView1.MaxDate = new DateTime(2099, 12, 31);
```

### <a name="updating-calendar-day-items"></a><span data-ttu-id="007ee-177">カレンダーの日付項目の更新</span><span class="sxs-lookup"><span data-stu-id="007ee-177">Updating calendar day items</span></span>

<span data-ttu-id="007ee-178">カレンダーの各日付は、[CalendarViewDayItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) オブジェクトで表されます。</span><span class="sxs-lookup"><span data-stu-id="007ee-178">Each day in the calendar is represented by a [CalendarViewDayItem](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.aspx) object.</span></span> <span data-ttu-id="007ee-179">個々の日付項目にアクセスしてそのプロパティとメソッドを使うには、[CalendarViewDayItemChanging](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendarviewdayitemchanging.aspx) イベントを処理し、イベント引数の Item プロパティを使って CalendarViewDayItem にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="007ee-179">To access an individual day item and use its properties and methods, handle the [CalendarViewDayItemChanging](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.calendarviewdayitemchanging.aspx) event and use the Item property of the event args to access the CalendarViewDayItem.</span></span>

<span data-ttu-id="007ee-180">カレンダー ビュー内の特定の日付を選択できないようにするには、その日付の [CalendarViewDayItem.IsBlackout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.isblackout.aspx) プロパティを **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="007ee-180">You can make a day not selectable in the calendar view by setting its [CalendarViewDayItem.IsBlackout](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarviewdayitem.isblackout.aspx) property to **true**.</span></span> 

<span data-ttu-id="007ee-181">ある日付のイベントの埋まり具合についてのコンテキスト情報を表示するには、[CalendarViewDayItem.SetDensityColors](https://msdn.microsoft.com/library/windows/apps/xaml/dn890067.aspx) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="007ee-181">You can show contextual information about the density of events in a day by calling the [CalendarViewDayItem.SetDensityColors](https://msdn.microsoft.com/library/windows/apps/xaml/dn890067.aspx) method.</span></span> <span data-ttu-id="007ee-182">日付ごとに 0 ～ 10 の範囲の密度コントロール バーを表示し、各バーの色を設定します。</span><span class="sxs-lookup"><span data-stu-id="007ee-182">You can show from 0 to 10 density bars for each day, and set the color of each bar.</span></span> 

<span data-ttu-id="007ee-183">カレンダーの日付項目のいくつかを次に示します。</span><span class="sxs-lookup"><span data-stu-id="007ee-183">Here are some day items in a calendar.</span></span> <span data-ttu-id="007ee-184">日付 1 と 2 は暗転しています。日付 2、3、および 4 には、さまざまな密度コントロール バーが設定されています。</span><span class="sxs-lookup"><span data-stu-id="007ee-184">Days 1 and 2 are blacked out. Days 2, 3, and 4 have various density bars set.</span></span>

![密度コントロール バーが設定されたカレンダーの日付](images/calendar-view-density-bars.png)

### <a name="phased-rendering"></a><span data-ttu-id="007ee-186">段階的なレンダリング</span><span class="sxs-lookup"><span data-stu-id="007ee-186">Phased rendering</span></span>

<span data-ttu-id="007ee-187">カレンダー ビューには、多数の CalendarViewDayItem オブジェクトを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="007ee-187">A calendar view can contain a large number of CalendarViewDayItem objects.</span></span> <span data-ttu-id="007ee-188">UI の応答性を保ち、カレンダー内をスムーズに移動できるようにするため、カレンダー ビューでは段階的なレンダリングがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="007ee-188">To keep the UI responsive and enable smooth navigation through the calendar, calendar view supports phased rendering.</span></span> <span data-ttu-id="007ee-189">そのため、日付項目の処理を複数のフェーズに分けることができます。</span><span class="sxs-lookup"><span data-stu-id="007ee-189">This lets you break up processing of a day item into phases.</span></span> <span data-ttu-id="007ee-190">すべてのフェーズが完了する前に日付がビューの範囲外に移動すると、その項目の処理とレンダリングはそれ以上行われません。</span><span class="sxs-lookup"><span data-stu-id="007ee-190">If a day is moved out of view before all the phases are complete, no more time is used trying to process and render that item.</span></span>

<span data-ttu-id="007ee-191">次の例は、予定のスケジュール設定を目的とした、カレンダー ビューの段階的なレンダリングを示しています。</span><span class="sxs-lookup"><span data-stu-id="007ee-191">This example shows phased rendering of a calendar view for scheduling appointments.</span></span> 
- <span data-ttu-id="007ee-192">フェーズ 0 では、既定の日付項目をレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="007ee-192">In phase 0, the default day item is rendered.</span></span> 
- <span data-ttu-id="007ee-193">フェーズ 1 では、予約できない日付を暗転します。</span><span class="sxs-lookup"><span data-stu-id="007ee-193">In phase 1, you blackout dates that can't be booked.</span></span> <span data-ttu-id="007ee-194">これには、過去の日付、日曜日、既に予定がすべて埋まっている日付などがあります。</span><span class="sxs-lookup"><span data-stu-id="007ee-194">This includes past dates, Sundays, and dates that are already fully booked.</span></span> 
- <span data-ttu-id="007ee-195">フェーズ 2 では、その日の予定をそれぞれチェックします。</span><span class="sxs-lookup"><span data-stu-id="007ee-195">In phase 2, you check each appointment that's booked for the day.</span></span> <span data-ttu-id="007ee-196">確定済みの予定には緑色の濃度コントロール バーを、仮の予定には青色の濃度コントロール バーを表示します。</span><span class="sxs-lookup"><span data-stu-id="007ee-196">You show a green density bar for each confirmed appointment and a blue density bar for each tentative appointment.</span></span> 

<span data-ttu-id="007ee-197">この例の `Bookings` クラスは、架空の予約アプリであるため、そのクラスは示されていません。</span><span class="sxs-lookup"><span data-stu-id="007ee-197">The `Bookings` class in this example is from a fictitious appointment booking app, and is not shown.</span></span>

```xaml
<CalendarView CalendarViewDayItemChanging="CalendarView_CalendarViewDayItemChanging"/>
```

```csharp
private void CalendarView_CalendarViewDayItemChanging(CalendarView sender, 
                                   CalendarViewDayItemChangingEventArgs args)
{
    // Render basic day items.
    if (args.Phase == 0)
    {
        // Register callback for next phase.
        args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
    }
    // Set blackout dates.
    else if (args.Phase == 1)
    {   
        // Blackout dates in the past, Sundays, and dates that are fully booked.
        if (args.Item.Date < DateTimeOffset.Now ||
            args.Item.Date.DayOfWeek == DayOfWeek.Sunday ||
            Bookings.HasOpenings(args.Item.Date) == false)
        {
            args.Item.IsBlackout = true;
        }
        // Register callback for next phase.
        args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
    }
    // Set density bars.
    else if (args.Phase == 2)
    {
        // Avoid unnecessary processing.
        // You don't need to set bars on past dates or Sundays.
        if (args.Item.Date > DateTimeOffset.Now &&
            args.Item.Date.DayOfWeek != DayOfWeek.Sunday)
        {
            // Get bookings for the date being rendered.
            var currentBookings = Bookings.GetBookings(args.Item.Date);

            List<Color> densityColors = new List<Color>();
            // Set a density bar color for each of the days bookings.
            // It's assumed that there can't be more than 10 bookings in a day. Otherwise,
            // further processing is needed to fit within the max of 10 density bars.
            foreach (booking in currentBookings)
            {
                if (booking.IsConfirmed == true)
                {
                    densityColors.Add(Colors.Green);
                }
                else
                {
                    densityColors.Add(Colors.Blue);
                }
            }
            args.Item.SetDensityColors(densityColors);
        }
    }
}
```

## <a name="get-the-sample-code"></a><span data-ttu-id="007ee-198">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="007ee-198">Get the sample code</span></span>

- <span data-ttu-id="007ee-199">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="007ee-199">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="007ee-200">関連記事</span><span class="sxs-lookup"><span data-stu-id="007ee-200">Related articles</span></span>

- [<span data-ttu-id="007ee-201">日付と時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="007ee-201">Date and time controls</span></span>](date-and-time.md)
- [<span data-ttu-id="007ee-202">カレンダーの日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="007ee-202">Calendar date picker</span></span>](calendar-date-picker.md)
- [<span data-ttu-id="007ee-203">日付の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="007ee-203">Date picker</span></span>](date-picker.md)
- [<span data-ttu-id="007ee-204">時刻の選択コントロール</span><span class="sxs-lookup"><span data-stu-id="007ee-204">Time picker</span></span>](time-picker.md)
