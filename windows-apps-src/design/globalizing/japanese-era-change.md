---
title: アプリケーションの新元号対応
description: 2019 年 5 月に行われる改元と、アプリケーションでの対応方法について説明します。
ms.assetid: 5A945F9A-8632-4038-ADD6-C0568091EF27
ms.date: 11/29/2018
ms.topic: article
keywords: 'Windows 10, UWP, ローカライズの可否, ローカライズ, 日本, 元号'
ms.localizationpriority: high
---

# アプリケーションの新元号対応

和暦には元号が使用されており、現在のコンピューター時代のほとんどは平成に含まれていました。この元号が、2019 年 5 月 1 日から新元号に変更されます。 元号が変わるのは約 30 年ぶりであるため、和暦をサポートしているソフトウェアについてはテストを行い、新元号になっても正しく動作するか確認する必要があります。

以下の各セクションでは、新元号への対応としてアプリケーションの準備とテストを実施する方法について説明します。

> [!NOTE]
> テストに使用する変更内容はコンピューター全体の動作に影響するため、テストにはテスト用コンピューターの使用をお勧めします。

## 新元号のレジストリ キーを追加する

元号が新しくなる前に、互換性の問題が発生しないかテストしておくことが重要です。元号名のプレースホルダーを使用して、今からテストすることができます。 これを行うには、**レジストリ エディター**を使用して、新元号のレジストリ キーを追加します。

1. **Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Nls\Calendars\Japanese\Eras** に移動します。
2. **[編集] > [新規] > [文字列値]** を選択し、「**2019 05 01**」という名前をつけます。
3. キーを右クリックし、**[修正]** を選択します。
4. **[値のデータ]** フィールドに、「**？？\_？\_??????\_?**」と入力します  (ここからコピーして貼り付けると簡単です)。

これらのレジストリ キーの書式については、「[和暦での元号処理](https://docs.microsoft.com/windows/desktop/Intl/era-handling-for-the-japanese-calendar)」をご覧ください。

新しい元号が発表されると、サポートされている Windows バージョンでは新しいレジストリ キーを伴う更新プログラムにこの元号が反映されるため、アプリケーションで正しく処理できるかどうかを確認できます。 この更新は、Windows 10 だけでなく Windows 8 および 7 の以前のサポート対象リリースにも反映されます。

プレースホルダーを使用したレジストリ キーは、アプリケーションのテストが終了したら削除できます。 削除しておくと、Windows の更新時に追加される新しいレジストリ キーに干渉する心配がなくなります。

## デバイスのカレンダー形式を変更する

新元号のレジストリ キーを追加したら、和暦が使用されるようにデバイスを構成する必要があります。 これを行うために日本語のデバイスは必要ありません。 綿密なテストを行うためには日本語の言語パックをインストールすることもできますが、基本的なテスト用には必須ではありません。

和暦が使用されるようにデバイスを構成するには:

1. **intl.cpl** (Windows 検索バーで検索してください) を開きます。
2. **[形式]** ドロップダウンから **[日本語 (日本)]** を選択します。
3. **[追加の設定]** を選択します。
4. **[日付]** タブを選択します。
5. **[カレンダーの種類]** ドロップダウンで、**[和暦]** ("*和暦*" とは日本のカレンダーの意味) を選択します。 2 番目のオプションが [和暦] です
6. **[OK]** をクリックします。
7. **[地域]** ウィンドウで **[OK]** をクリックします。

デバイスは和暦を使用するように構成され、レジストリにある元号が反映されます。 以下は、画面の右下に表示される日付形式の例です。

![和暦形式の日付と時刻](images/japanese-calendar-format.png)

## デバイスのクロックを調整する

アプリケーションが新元号に対応していることをテストするには、コンピューターのクロックを 2019 年 5 月 1日以降に進める必要があります。 次の手順は Windows 10 用ですが、Windows 8 および 7 でも同様の手順になります。

1. 画面の右下隅にある日付と時刻の領域を右クリックします。
2. **[日付と時刻の調整]** を選択します。
3. 設定アプリの **[日付と時刻を変更する]** で、**[変更]** を選択します。
4. 日付を 2019 年 5 月 1 日以降に変更します。

> [!NOTE]
> 組織単位の設定によっては、日付を変更できないことがあります。その場合は、管理者にお問い合わせください。または、プレースホルダーを使用したレジストリ キーを編集して、過去の日付を設定することもできます。

## アプリケーションをテストする

では、アプリケーションで新元号を処理できるかどうかをテストしましょう。 タイムスタンプや日付の選択コントロールなど、日付が表示される場所で表示を確認します。 2019 年 5 月 1 日より前の元号と (平成) と 2019 年 5 月 1 日以降の元号 (？？) が正しいことを確認します。

### *元年*

和暦の年は通常、**&lt;元号&gt; &lt;元号年&gt;** という形式で表記します。 たとえば、2018 年は "**平成 30 年**" です。  ただし、各元号の最初の年には特殊な表記法を使用し、"**&lt;元号&gt; 1 年**" ではなく "**&lt;元号&gt; 元年**"** と表記します。 このため、平成の最初の年は "*平成元年*" となります。 各アプリケーションでは、新元号の最初の年を適切に処理し、正しく "？？元年" と出力してください。

## 関連する API

いくつかの WinRT、.NET、Win32 API は、改元を処理できるよう更新されるため、これらを使用する場合にはそれほど心配する必要はありません。 ただし、全面的にこれらの API を使用している場合も (解析などの特殊処理を行う場合は特に)、アプリケーションをテストして、動作に問題がないか確認することをお勧めします。

OS および SDK の最新情報については、「[2019 年 5 月の新元号への変更に関する更新](https://support.microsoft.com/help/4470918/updates-for-may-2019-japan-era-change)」をご覧ください。

影響を受けるのは次の API です。

### WinRT

* [Windows.Globalization 名前空間](https://docs.microsoft.com/uwp/api/windows.globalization)
    * [Calendar クラス](https://docs.microsoft.com/uwp/api/windows.globalization.calendar)
        * [AddDays メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.adddays)
        * [AddEras メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.adderas)
        * [AddHours メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addhours)
        * [AddMinutes メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addminutes)
        * [AddMonths メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addmonths)
        * [AddNanoseconds メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addnanoseconds)
        * [AddPeriods メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addperiods)
        * [AddSeconds メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addseconds)
        * [AddWeeks メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addweeks)
        * [AddYears メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addyears)
        * [Era プロパティ](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.era)
        * [EraAsString メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.eraasstring)
        * [FirstYearInThisEra プロパティ](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.firstyearinthisera)
        * [LastEra プロパティ](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.lastera)
        * [LastYearInThisEra プロパティ](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.lastyearinthisera)
        * [NumberOfYearsInThisEra プロパティ](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.numberofyearsinthisera)     
* [Windows.Globalization.DateTimeFormatting 名前空間](https://docs.microsoft.com/uwp/api/windows.globalization.datetimeformatting)
    * [DateTimeFormatter クラス](https://docs.microsoft.com/uwp/api/windows.globalization.datetimeformatting.datetimeformatter)
        * [Format メソッド](https://docs.microsoft.com/uwp/api/windows.globalization.datetimeformatting.datetimeformatter.format)

### .NET

* [System 名前空間](https://docs.microsoft.com/dotnet/api/system)
    * [DateTime 構造体](https://docs.microsoft.com/dotnet/api/system.datetime)
    * [DateTimeOffset 構造体](https://docs.microsoft.com/dotnet/api/system.datetimeoffset)
* [System.Globalization 名前空間](https://docs.microsoft.com/dotnet/api/system.globalization)
    * [Calendar クラス](https://docs.microsoft.com/dotnet/api/system.globalization.calendar)
    * [DateTimeFormatInfo クラス](https://docs.microsoft.com/dotnet/api/system.globalization.datetimeformatinfo)
    * [JapaneseCalendar クラス](https://docs.microsoft.com/dotnet/api/system.globalization.japanesecalendar)
    * [JapaneseLunisolarCalendar クラス](https://docs.microsoft.com/dotnet/api/system.globalization.japaneselunisolarcalendar)

### Win32

* [datetimeapi.h ヘッダー](https://docs.microsoft.com/windows/desktop/api/datetimeapi/)
    * [GetDateFormatA 関数](https://docs.microsoft.com/windows/desktop/api/datetimeapi/nf-datetimeapi-getdateformata)
    * [GetDateFormatEx 関数](https://docs.microsoft.com/windows/desktop/api/datetimeapi/nf-datetimeapi-getdateformatex)
    * [GetDateFormatW 関数](https://docs.microsoft.com/windows/desktop/api/datetimeapi/nf-datetimeapi-getdateformatw)
* [winnls.h ヘッダー](https://docs.microsoft.com/windows/desktop/api/winnls/)
    * [EnumDateFormatsA 関数](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsa)
    * [EnumDateFormatsExA 関数](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsexa)
    * [EnumDateFormatsExEx 関数](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsexex)
    * [EnumDateFormatsExW 関数](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsexw)
    * [EnumDateFormatsW 関数](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsw)
    * [GetCalendarInfoA 関数](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-getcalendarinfoa)
    * [GetCalendarInfoEx 関数](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-getcalendarinfoex)
    * [GetCalendarInfoW 関数](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-getcalendarinfow)

## 関連項目

* [和暦での元号処理](https://docs.microsoft.com/windows/desktop/Intl/era-handling-for-the-japanese-calendar)
* [2000 年対応を思わせる和暦の節目](https://blogs.msdn.microsoft.com/shawnste/2018/04/12/the-japanese-calendars-y2k-moment/)
* [Windows でレジストリを使用して新元号をテストする](https://blogs.msdn.microsoft.com/shawnste/2018/08/07/using-the-registry-to-test-the-new-japanese-era-on-windows/)
* [元年と 1 年](https://blogs.msdn.microsoft.com/shawnste/2018/11/12/gannen-vs-ichinen/)
* [2019 年 5 月の新元号への変更に関する更新](https://support.microsoft.com/help/4470918/updates-for-may-2019-japan-era-change)
* [.NET で日本の新元号を処理する](https://blogs.msdn.microsoft.com/dotnet/2018/11/14/handling-a-new-era-in-the-japanese-calendar-in-net/)

<!--HONumber=12月18_HO1-->

