---
author: DelfCo
Description: "日付、時刻、数字、電話番号、通貨を適切に書式設定することで、グローバル対応のアプリを開発します。"
title: "グローバル対応の形式の使用"
ms.assetid: 6ECE8BA4-9A7D-49A6-81EE-AB2BE7F0254F
label: Use global-ready formats
template: detail.hbs
ms.author: bobdel
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 84e53b5093d2d288dbe95f51b0a3f9a8e5e06fe0
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="use-global-ready-formats"></a>グローバル対応の形式の使用

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

日付、時刻、数字、電話番号、通貨を適切に書式設定することで、グローバル対応のアプリを開発します。 これを行うと、後でアプリを世界市場の他のカルチャ、地域、言語に適応させることができます。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**Windows.Globalization.Calendar**](https://msdn.microsoft.com/library/windows/apps/br206724)</li>
<li>[**Windows.Globalization.DateTimeFormatting**](https://msdn.microsoft.com/library/windows/apps/br206859)</li>
<li>[**Windows.Globalization.NumberFormatting**](https://msdn.microsoft.com/library/windows/apps/br226136)</li>
<li>[**Windows.Globalization.PhoneNumberFormatting**](https://msdn.microsoft.com/library/windows/apps/Windows.Globalization.PhoneNumberFormatting)</li>
</ul>
</div>


## <a name="introduction"></a>概要

多くのアプリ開発者は、自然に自分たちの言語とカルチャだけを考慮してアプリを作ります。 しかし、そうしたアプリを新しい言語や地域に適応させて他の市場に参入しようとすると、予想しないことで困難に遭遇することがあります。 たとえば、日付、時刻、数値、カレンダー、通貨、電話番号、計測単位、紙のサイズは、すべてカルチャや言語によって表示が異なる場合があります。

アプリを開発する段階で、いくつかのことを考慮しておけば、新しい市場に参入するプロセスを簡単にできます。

## <a name="format-dates-and-times-appropriately"></a>日付と時刻を適切に書式設定する

日付と時刻は、さまざまな方法で表示することができます。 さまざまな地域やカルチャで、日付の月と日の順、時刻の時と分との分離、セパレーターとして使われる句読点について、さまざまな規則が使われています。 また、日付にはさまざまな表示形式があり、長い形式 ("Wednesday, March 28, 2012") や短い形式 ("3/28/12") など、カルチャによってその表示形式が異なる場合があります。 当然ですが、曜日や月の名称と省略形は言語によって異なります。

ユーザーが日付や時刻を選択できるようにする必要がある場合には、標準の[DatePicker と TimePicker](https://msdn.microsoft.com/library/windows/apps/hh465466) コントロールを使います。 これらのコントロールでは、ユーザーの優先する言語と地域に対応した日付と時刻の形式を自動的に使います。

日付や時刻を独自に表示する必要がある場合は、[**Date/Time**](https://msdn.microsoft.com/library/windows/apps/br206859) フォーマッタと [**Number**](https://msdn.microsoft.com/library/windows/apps/br226136) フォーマッタを使って、ユーザーの優先する形式で日付、時刻、数字を自動的に表示します。 次のコードは、現在設定されている言語と地域を使って特定の DateTime を書式設定します。 たとえば、現在の日付が 2012 年 6 月 3 日の場合、フォーマッタでは、ユーザーが英語 (米国) を選んだ場合は "6/3/2012" を生成しますが、ドイツ語 (ドイツ) を選んだ場合は "03.06.2012" を生成します。

```CSharp
    // Use the Windows.Globalization.DateTimeFormatting.DateTimeFormatter class
    // to display dates and times using basic formatters.

    // Formatters for dates and times, using shortdate format.
    var sdatefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shortdate");
    var stimefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shorttime");

    // Obtain the date that will be formatted.
    var dateToFormat = DateTime.Now;

    // Perform the actual formatting.
    var sdate = sdatefmt.Format(dateToFormat);
    var stime = stimefmt.Format(dateToFormat);

    // Results for display.
    var results = "Short Date: " + sdate + "\n" +
                  "Short Time: " + stime;
```

## <a name="format-numbers-and-currencies-appropriately"></a>数字と通貨を適切に書式設定する

数字の書式設定はカルチャによって異なります。 数字の書式設定が異なるものには、表示する小数の桁数、小数点記号に使う文字、通貨記号などがあります。 [**NumberFormatting**](https://msdn.microsoft.com/library/windows/apps/br226136) を使って、小数、パーセントまたはパーミル数値、通貨を表示します。 多くの場合、単にユーザーの通貨設定に従って数字や通貨を表示します。 ただし、フォーマッタを使って特定の地域または形式の通貨を表示することもできます。

以下のコードは、ユーザーの優先する言語と地域に対応した通貨、または特定の通貨制度に対応した通貨を表示する方法の例を示しています。

```CSharp
    // This scenario uses the Windows.Globalization.NumberFormatting.CurrencyFormatter class
    // to format a number as a currency.

    // Determine the current user's default currency.
    var userCurrency = Windows.System.UserProfile.GlobalizationPreferences.Currencies[0];

    // Number to be formatted.
    var fractionalNumber = 12345.67;

    // Currency formatter using the current user's preference settings for number formatting.
    var userCurrencyFormat = new Windows.Globalization.NumberFormatting.CurrencyFormatter(userCurrency);
    var currencyDefault = userCurrencyFormat.Format(fractionalNumber);

    // Create a formatter initialized to a specific currency,
    // in this case US Dollar (specified as an ISO 4217 code) 
    // but with the default number formatting for the current user.
    var currencyFormatUSD = new Windows.Globalization.NumberFormatting.CurrencyFormatter("USD"); 
    var currencyUSD = currencyFormatUSD.Format(fractionalNumber);

    // Create a formatter initialized to a specific currency.
    // In this case it's the Euro with the default number formatting for France.
    var currencyFormatEuroFR = new Windows.Globalization.NumberFormatting.CurrencyFormatter("EUR", new[] { "fr-FR" }, "FR");
    var currencyEuroFR = currencyFormatEuroFR.Format(fractionalNumber);

    // Results for display.
    var results = "Fixed number (" + fractionalNumber + ")\n" +
                  "With user's default currency: " + currencyDefault + "\n" +
                  "Formatted US Dollar: " + currencyUSD + "\n" +
                  "Formatted Euro (fr-FR defaults): " + currencyEuroFR;
```

## <a name="use-a-culturally-appropriate-calendar"></a>カルチャに適したカレンダーを使用する

カレンダーは地域や言語によって異なります。 グレゴリオ暦がすべての地域で既定となっているわけではありません。 ある地域のユーザーは、日本の年号、アラビアの太陰暦など別のカレンダーを選ぶ場合があります。 カレンダーの日付や時刻も、さまざまなタイム ゾーンや夏時間に影響されます。

必要なカレンダー形式を使うために、ユーザーが日付を選べるようにするには、標準の [DatePicker と TimePicker](https://msdn.microsoft.com/library/windows/apps/hh465466) コントロールを使います。 カレンダーの日付を直接操作することが必要な、さらに複雑なシナリオの場合、特定のカルチャ、地域、カレンダーの種類を表す適切なカレンダーを提供する [**Calendar**](https://msdn.microsoft.com/library/windows/apps/br206724) クラスが Windows.Globalization によって提供されています。

## <a name="format-phone-numbers-appropriately"></a>電話番号を適切に書式設定する
電話番号の書式設定は地域によって異なります。 電話番号の桁数、桁のグループ化、および特定部分の重要性は、国によって異なります。 Windows 10 Version 1607 以降では、[**PhoneNumberFormatting**](https://msdn.microsoft.com/library/windows/apps/Windows.Globalization.PhoneNumberFormatting) を使って、電話番号を現在の地域に適した書式に設定できます。

[**PhoneNumberInfo**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.phonenumberformatting.phonenumberinfo.aspx) を使うと、数字の文字列を解析して、数字が現在の地域の電話馬号として有効かどうかを判定し、2 つの番号が等しいかどうかを比較して、電話番号の国コードや地域コードなどの異なる機能部分を抽出できます。

[**PhoneNumberFormatter**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.globalization.phonenumberformatting.phonenumberformatter.aspx) は、数字の文字列または PhoneNumberInfo を表示用に書式設定します。数字の文字列が電話番号の一部だけを表している場合でも使用できます  (この部分的な番号の書式設定を使って、ユーザーの番号入力に合わせて番号を書式設定できます)。 

次のコードでは、入力されている電話番号を PhoneNumberFormatter を使って書式設定する方法を示します。 gradualInput という名前の TextBox のテキストが変わるたびに、現在の既定の地域を使ってテキスト ボックスの内容が書式設定されて、outBox という名前の TextBlock に表示されます。 デモンストレーション用として、文字列は地域としてニュージーランドを使って書式設定され、NZOutBox という名前の TextBlock にも表示されます。
    
```csharp
    using Windows.Globalization;

    PhoneNumberFormatter currentFormatter, NZFormatter;

    public MainPage()
    {
        this.InitializeComponent();

        // Use the default formatter for the current region
        currentFormatter = new PhoneNumberFormatter();

        // Create an explicit formatter for New Zealand. 
        // Note that you must check the results of TryCreate before you use the formatter.
        PhoneNumberFormatter.TryCreate("NZ", out NZFormatter);

    }

    private void gradualInput_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Format for the default region into outBox.
        outBox.Text = currentFormatter.FormatPartialString(gradualInput.Text);

        // If the NZFormatter was created successfully, format the partial string for the NZOutBox.
        if(NZFormatter != null)
        {
            NZOutBox.Text = NZFormatter.FormatPartialString(gradualInput.Text);
        }
    }
```    

## <a name="respect-the-users-language-and-cultural-preferences"></a>ユーザーの言語とカルチャを考慮する

ユーザーの言語、地域、カルチャの設定に基づいてさまざまな機能を提供するシナリオでは、[**Windows.System.UserProfile.GlobalizationPreferences**](https://msdn.microsoft.com/library/windows/apps/br241825) を使ってそれらの設定にアクセスするための方法が、Windows によって提供されます。 必要に応じて、**GlobalizationPreferences** クラスを使って、ユーザーの現在の地理的な地域、優先する言語や通貨などの値を取得します。

## <a name="related-topics"></a>関連トピック

* [世界市場向けの計画](https://msdn.microsoft.com/library/windows/apps/hh465405)
* [日付コントロールと時刻コントロールのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh465466)

**リファレンス**
* [**Windows.Globalization.Calendar**](https://msdn.microsoft.com/library/windows/apps/br206724)
* [**Windows.Globalization.DateTimeFormatting**](https://msdn.microsoft.com/library/windows/apps/br206859)
* [**Windows.Globalization.NumberFormatting**](https://msdn.microsoft.com/library/windows/apps/br226136)
* [**Windows.System.UserProfile.GlobalizationPreferences**](https://msdn.microsoft.com/library/windows/apps/br241825)

**サンプル**
* [カレンダーの詳細と数値演算のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231636)
* [日付と時刻の書式設定のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231618)
* [グローバリゼーション設定サンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231608)
* [数字の書式設定と解析サンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231620)
