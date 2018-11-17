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
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7158871"
---
# <a name="calendar-date-and-time-controls"></a>カレンダー、日付、および時刻コントロール

 

日付コントロールと時刻コントロールを使用することで、その地域に合った標準化された方法で、ユーザーがアプリで日付と時刻を表示および設定できるようにすることができます。 この記事では設計ガイドラインを示し、適切なコントロールを選ぶのに役立ちます。

> **重要な API**: [CalendarView クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx)、[CalendarDatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx)、[DatePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx)、[TimePicker クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx)

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合は、こちらをクリックして<a href="xamlcontrolsgallery:/category/DataInput">アプリを開き、これらのコントロールの動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="which-date-or-time-control-should-you-use"></a>日付または時刻コントロールの選択

4 つの日付および時刻コントロールから選択できますが、シナリオによって使用するコントロールは異なります。 以下の情報を参考にして、アプリに適切なコントロールを選んでください。

&nbsp;|&nbsp;|&nbsp;                                                                                                                      
--------------------|-------|-------------------------------------------------------------------------------------------------------------------------------
カレンダー ビュー       |![カレンダー ビューの例](images/controls_calendar_monthview_small.png)|常に表示されるカレンダーから 1 つの日付または日付の範囲を選ぶ場合に使用します。                   
カレンダーの日付の選択コントロール|![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-closed.png)|コンテキストに沿ったカレンダーから 1 つの日付を選ぶ場合に使用します。 
日付の選択コントロール         |![日付の選択コントロールの例](images/date-picker-closed.png)|コンテキスト情報が重要でない既知の 1 つの日付を選ぶ場合に使用します。
時刻の選択コントロール         |![時刻の選択コントロールの例](images/time-picker-closed.png)|1 つの時刻を選ぶ場合に使用します。                                        

<!-- This table seems redundant, not sure it's needed.-->

### <a name="calendar-view"></a>カレンダー ビュー

**CalendarView** を使うと、ユーザーはカレンダーを表示し操作できます (カレンダーは、月、年、または 10 年単位で操作できます)。 ユーザーは 1 つの日付や日付の範囲を選ぶことができます。 カレンダー ビューには選択コントロール サーフェイスがなく、カレンダーは常に表示されます。

カレンダー ビューは、月ビュー、年ビュー、10 年ビューという 3 つの個別のビューで構成されています。 既定では、月ビューが開きますが、任意のビューをスタートアップ ビューとして指定できます。

![カレンダーの日付の選択コントロールの例](images/calendar-view-3-views.png)

- ユーザーが複数の日付を選べるようにする必要がある場合は、**CalendarView** を使う必要があります。
- ユーザーが 1 つの日付しか選べないようにする必要があり、カレンダーを常に表示する必要がない場合は、**CalendarDatePicker** または **DatePicker** を使うことを検討してください。

### <a name="calendar-date-picker"></a>カレンダーの日付の選択コントロール

**CalendarDatePicker** は、カレンダーの曜日や埋まり具合などのコンテキスト情報が必要となるカレンダー ビューから単一の日付を選ぶ用途に最適なドロップダウン コントロールです。 追加のコンテキストを提供する場合、または利用可能日を制限する場合は、カレンダーを変更できます。

日付が設定されていない場合、エントリ ポイントにはプレースホルダー テキストが表示されます。設定されている場合は、選んだ日付が表示されます。 ユーザーがエントリ ポイントを選ぶと、カレンダー ビューが展開されて、ユーザーが日付を選べるようになります。 カレンダー ビューは他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。

![カレンダーの日付の選択コントロールの例](images/calendar-date-picker-2-views.png)

- カレンダーの日付の選択コントロールは、予定日や出発日の選択などに使います。 

### <a name="date-picker"></a>日付の選択コントロール

**DatePicker** コントロールによって、標準化された方法で特定の日付を選ぶことができます。 

エントリ ポイントには、選んだ日付が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、日付を選べるようになります。 日付の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。

![展開した日付の選択コントロールの例](images/controls_datepicker_expand.png)

- 日付の選択コントロールは、ユーザーが誕生日などの既知の日付 (カレンダーのコンテキストが重要ではない日) を選べるようにする場合に使用します。

### <a name="time-picker"></a>時刻の選択コントロール

**TimePicker** は、予定や出発時刻などの 1 つの時刻を選択する場合に使用します。 ユーザーまたはコードによって設定された静的な表示であるため、更新して現在の時刻を表示することはできません。 

エントリ ポイントには、選んだ時刻が表示されます。ユーザーがエントリ ポイントを選ぶと、選択ツール サーフェイスが中央から縦方向に展開されて、時刻を選べるようになります。 時刻の選択は他の UI をオーバーレイし、他の UI を別の位置に移動させることはありません。

![展開した時刻の選択コントロールの例](images/controls_timepicker_expand.png)

- 時刻の選択コントロールを使って、ユーザーが 1 つの時刻を選べるようにします。

## <a name="create-a-date-or-time-control"></a>日付または時刻コントロールの作成

日付および時刻コントロールの詳細と例については、次の記事をご覧ください。

- [カレンダー ビュー](calendar-view.md)
- [カレンダーの日付の選択コントロール](calendar-date-picker.md)
- [日付の選択コントロール](date-picker.md)
- [時刻の選択コントロール](time-picker.md)

### <a name="globalization"></a>グローバリゼーション

XAML の日付のコントロールでは、Windows でサポートされる各カレンダー システムがサポートされます。 それらのカレンダーは [Windows.Globalization.CalendarIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendaridentifiers.aspx) クラスで指定されます。 各コントロールは、アプリの既定の言語に適したカレンダーを使います。または、**CalendarIdentifier** プロパティを設定して特定のカレンダー システムを使うこともできます。

時刻の選択コントロールでは、[Windows.Globalization.ClockIdentifiers](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.clockidentifiers.aspx) クラスで指定される各クロック システムがサポートされます。 [ClockIdentifier](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.clockidentifier.aspx) プロパティを設定し、12 時間形式または 24 時間形式を指定できます。 プロパティの型は文字列ですが、ClockIdentifiers クラスの静的な文字列プロパティに対応する値を使用する必要があります。 それらの値とは、TwelveHour (文字列 "12HourClock") と TwentyFourHour (文字列 "24HourClock") です。 既定値は "12HourClock" です。


### <a name="datetime-and-calendar-values"></a>DateTime と Calendar の値

XAML の日付および時刻コントロールで使用される日付オブジェクトでは、プログラミング言語によって表現方法が異なります。 
- C# および Visual Basic では、.NET の一部である [System.DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) 構造体が使用されます。 
- C++/CX では、[Windows::Foundation::DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/br205770.aspx) 構造体が使用されます。 

関連する概念として Calendar クラスがあります。Calendar クラスは、コンテキストでの日付の解釈方法に影響を及ぼします。 すべての Windows ランタイム アプリで、[Windows.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.calendar.aspx) クラスを使用することができます。 C# および Visual Basic アプリでは、代わりに機能が非常によく似た [System.Globalization.Calendar](https://msdn.microsoft.com/library/windows/apps/xaml/system.globalization.calendar.aspx) クラスを使用することができます  (Windows ランタイム アプリでは、基本の .NET Calendar クラスを使用することはできますが、GregorianCalendar などの具体的な実装を使用することはできません)。

.NET では、[DateTime](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) という名前の型もサポートされます。これは、暗黙的に [DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx) と読み替えることができます。 したがって、.NET コードで値を設定するために "DateTime" 型が使用されていた場合、それは実際には DateTimeOffset です。 DateTime と DateTimeOffset の違いについて詳しくは、「[DateTimeOffset](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetimeoffset.aspx)クラス」の「注釈」をご覧ください。

> **注:**&nbsp;&nbsp;日付オブジェクトを受け取るプロパティは、XAML 属性文字列として設定することはできません。これは、Windows ランタイム XAML パーサーには、文字列を DateTime/DateTimeOffset オブジェクトとして日付に変換する変換ロジックがないためです。 通常、それらの値はコードで設定します。 考えられる別の方法として、データ オブジェクトとして (またはデータ コンテキストで) 利用可能な日付を定義し、その日付をデータとしてアクセスできる [\{Binding\} マークアップ拡張](../../xaml-platform/binding-markup-extension.md)表現を参照する XAML 属性をプロパティとして設定することができます。

## <a name="get-the-sample-code"></a>サンプル コードを入手する
* [XAML UI の基本のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)


## <a name="related-topics"></a>関連トピック

**開発者向け (XAML)**
- [CalendarView クラス](https://msdn.microsoft.com/library/windows/apps/dn890052)
- [CalendarDatePicker クラス](https://msdn.microsoft.com/library/windows/apps/dn950083)
- [DatePicker クラス](https://msdn.microsoft.com/library/windows/apps/dn298584)
- [TimePicker クラス](https://msdn.microsoft.com/library/windows/apps/dn299280)
