---
Description: Design your app to be global-ready by appropriately formatting dates, times, numbers, phone numbers, and currencies. You'll then be able later to adapt your app for additional cultures, regions, and languages in the global market.
title: 日付、時刻、数値の形式のグローバル化
ms.assetid: 6ECE8BA4-9A7D-49A6-81EE-AB2BE7F0254F
template: detail.hbs
ms.date: 11/07/2017
ms.topic: article
keywords: Windows 10, UWP, グローバリゼーション, ローカライズの可否, ローカライズ
ms.localizationpriority: medium
ms.openlocfilehash: e8a2b0125944a8a4db66b41d26fcd4a0aa35b5b2
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7714979"
---
# <a name="globalize-your-datetimenumber-formats"></a>日付、時刻、数値の形式のグローバル化

日付、時刻、数値、電話番号、通貨を適切に書式設定することで、グローバル対応のアプリを設計します。 これを行うと、後でアプリを世界市場の他のカルチャ、地域、言語に適応させることができます。

## <a name="introduction"></a>概要

アプリを作成するときに、1 つの言語とカルチャに限定せずに広範に考えると、アプリが新しい市場に参入するときに予期しない問題があったとしても少なくなります。 たとえば、日付、時刻、数値、カレンダー、通貨、電話番号、計測単位、紙のサイズは、すべてカルチャや言語によって表示が異なる場合があります。

さまざまな地域やカルチャで、さまざまな日付と時刻の形式が使われています。 例として、日付の月と日の順、時刻の時と分との分離、セパレーターとして使われる句読点に関する規則があります。 また、日付にはさまざまな表示形式があり、長い形式 ("Wednesday, March 28, 2012") や短い形式 ("3/28/12") など、カルチャによってその表示形式が異なります。 当然ですが、曜日や月の名称と省略形は言語間で異なります。

さまざまな言語で使用される形式をプレビューすることができます。 **[設定]** > **[時刻と言語]** > **[地域と言語]** に移動し、**[日付、時刻、地域の追加設定]** > **[日付、時刻、または数値の形式の変更]** の順にクリックします。 **[形式]** タブで、**[表示形式]** ドロップダウンから言語を選択し、**[例]** で形式をプレビューします。

このトピックでは、"ユーザー プロファイルの言語の一覧"、"アプリ マニフェストの言語の一覧"、"アプリの実行時の言語の一覧" という用語を定義します。 これらの用語の正確な意味とその値にアクセスする方法の詳細については、「[ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)」を参照してください。

## <a name="format-dates-and-times-for-the-app-runtime-language-list"></a>アプリの実行時の言語の一覧の日付と時刻の書式設定

ユーザーが日付や時刻を選択できるようにする必要がある場合には、標準の[カレンダー、日付、および時刻コントロール](../controls-and-patterns/date-and-time.md)を使います。 これらのコントロールでは、アプリの実行時の言語の一覧に最適な日付と時刻の書式設定を自動的に使います。

日付や時刻を独自に表示する必要がある場合は、[**DateTimeFormatter**](/uwp/api/windows.globalization.datetimeformatting?branch=live) クラスを使用できます。 既定では、**DateTimeFormatter** は、アプリの実行時の言語の一覧については最適な日付と時刻の形式を自動的に使います。 そのため、次のコードでは、その一覧について最適な方法で特定の **DateTime** を書式設定します。 たとえば、アプリ マニフェストの言語の一覧には、既定である英語 (米国) とドイツ語 (ドイツ) が含まれると想定します。 現在の日付が 2017 年 11 月 6日で、ユーザー プロファイルの言語の一覧にドイツ語 (ドイツ) が最初に含まれている場合、フォーマッタでは "06.11.2017" を生成します。 ユーザー プロファイルの言語の一覧に英語 (米国) が最初に含まれる (または英語とドイツ語のどちらも含まれない) 場合、("en-US" が一致するか、既定で使用されるため) フォーマッタでは "11/6/2017" を生成します。

```csharp
    // Use the DateTimeFormatter class to display dates and times using basic formatters.

    var shortDateFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shortdate");
    var shortTimeFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shorttime");

    var dateTimeToFormat = DateTime.Now;

    var shortDate = shortDateFormatter.Format(dateTimeToFormat);
    var shortTime = shortTimeFormatter.Format(dateTimeToFormat);

    var results = "Short Date: " + shortDate + "\n" +
                  "Short Time: " + shortTime;
```

上のコードは、次のように個人の PC でテストできます。

- "en-US" と "de-DE" の両方に対して修飾されたリソース ファイルがプロジェクトにあることを確認します ([言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](../../app-resources/tailor-resources-lang-scale-contrast.md) を参照)。
- **[設定]** > **[時刻と言語]** > **[地域と言語]** > **[言語]** でユーザー プロファイルの言語の一覧を変更します。 ドイツ語 (ドイツ) を追加し、それを既定の言語にして、もう一度コードを実行します。

## <a name="format-dates-and-times-for-the-user-profile-language-list"></a>ユーザー プロファイルの言語の一覧の日付と時刻の書式設定

既定では、**DateTimeFormatter** がアプリの実行時の言語の一覧に一致することに注意してください。 それにより、"日付は &lt;date&gt; です" という文字列を表示する場合に、言語が日付形式に一致します。

何らかの理由でユーザー プロファイルの言語の一覧のみに従って日付または時刻を書式設定する場合は、下の例のようなコードを使って行うことができます。 ただし、その場合は、アプリに翻訳された文字列がない言語をユーザーが選択できる点を理解してください。 たとえば、アプリがドイツ語 (ドイツ) にローカライズされていないが、ユーザーがドイツ語 (ドイツ) を優先する言語として選択する場合、"日付は 06.11.2017 です" のような間違いなく変わった外観の文字列が表示される可能性があります。

```csharp
    // Use the DateTimeFormatter class to display dates and times using basic formatters.

    var userLanguages = Windows.System.UserProfile.GlobalizationPreferences.Languages;

    var shortDateFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shortdate", userLanguages);

    var results = "Short Date: " + shortDateFormatter.Format(DateTime.Now);
```

## <a name="format-numbers-and-currencies-appropriately"></a>数字と通貨を適切に書式設定する

数字の書式設定はカルチャによって異なります。 数字の書式設定が異なるものには、表示する小数の桁数、小数点記号に使う文字、通貨記号などがあります。 [**NumberFormatting**](/uwp/api/windows.globalization.numberformatting?branch=live) 名前空間のクラスを使って、小数、パーセントまたはパーミル数値、通貨を表示します。 多くの場合、これらのフォーマッタ クラスでユーザー プロファイル用の最適な形式を使う必要があります。 ただし、フォーマッタを使って任意の地域または形式の通貨を表示できます。

この例では、ユーザー プロファイルに従った通貨、および特定の通貨制度に対応した通貨を表示する方法を示しています。

```csharp
    // This scenario uses the CurrencyFormatter class to format a number as a currency.

    var userCurrency = Windows.System.UserProfile.GlobalizationPreferences.Currencies[0];

    var valueToBeFormatted = 12345.67;

    var userCurrencyFormatter = new Windows.Globalization.NumberFormatting.CurrencyFormatter(userCurrency);
    var userCurrencyValue = userCurrencyFormatter.Format(valueToBeFormatted);

    // Create a formatter initialized to a specific currency,
    // in this case US Dollar (specified as an ISO 4217 code) 
    // but with the default number formatting for the current user.
    var currencyFormatUSD = new Windows.Globalization.NumberFormatting.CurrencyFormatter("USD");
    var currencyValueUSD = currencyFormatUSD.Format(valueToBeFormatted);

    // Create a formatter initialized to a specific currency.
    // In this case it's the Euro with the default number formatting for France.
    var currencyFormatEuroFR = new Windows.Globalization.NumberFormatting.CurrencyFormatter("EUR", new[] { "fr-FR" }, "FR");
    var currencyValueEuroFR = currencyFormatEuroFR.Format(valueToBeFormatted);

    // Results for display.
    var results = "Fixed number (" + valueToBeFormatted + ")\n" +
                    "With user's default currency: " + userCurrencyValue + "\n" +
                    "Formatted US Dollar: " + currencyValueUSD + "\n" +
                    "Formatted Euro (fr-FR defaults): " + currencyValueEuroFR;
```

**[設定]** > **[時刻と言語]** > **[地域と言語]** > **[国/地域]** で国または地域を変更して、個人の PC で上のコードをテストできます。 国または地域 (アイスランドなど) を選択し、もう一度コードを実行します。

## <a name="use-a-culturally-appropriate-calendar"></a>カルチャに適したカレンダーを使用する

カレンダーは地域や言語によって異なります。 グレゴリオ暦がすべての地域で既定となっているわけではありません。 ある地域のユーザーは、日本の年号、アラビアの太陰暦など別のカレンダーを選ぶ場合があります。 カレンダーの日付や時刻も、さまざまなタイム ゾーンや夏時間に影響されます。

必要なカレンダー形式が使用されていることを確認するために、標準の[カレンダー、日付、および時刻コントロール](../controls-and-patterns/date-and-time.md)を使うことができます。 カレンダーの日付を直接操作することが必要な、さらに複雑なシナリオの場合、特定のカルチャ、地域、カレンダーの種類を表す適切なカレンダーを提供する [**Calendar**](/uwp/api/windows.globalization.calendar?branch=live) クラスが **Windows.Globalization** によって提供されています。

## <a name="format-phone-numbers-appropriately"></a>電話番号を適切に書式設定する

電話番号の書式設定は地域によって異なります。 電話番号の桁数、桁のグループ化、および特定部分の重要性は、国によって異なります。 Windows 10 Version 1607 以降では、[**PhoneNumberFormatting**](/uwp/api/windows.globalization.phonenumberformatting?branch=live) 名前空間のクラスを使って、電話番号を現在の地域に適した書式に設定できます。

[**PhoneNumberInfo**](/uwp/api/windows.globalization.phonenumberformatting.phonenumberinfo?branch=live) を使うと、数字の文字列を解析して、数字が現在の地域の電話番号として有効かどうかを判定し、2 つの番号が等しいかどうかを比較して、電話番号の国コードや地域コードなどの異なる機能部分を抽出できます。

[**PhoneNumberFormatter**](/uwp/api/windows.globalization.phonenumberformatting.phonenumberformatter?branch=live) は、数字の文字列または **PhoneNumberInfo** を表示用に書式設定します。数字の文字列が電話番号の一部だけを表している場合でも使用できます  この部分的な番号の書式設定を使って、ユーザーの番号入力に合わせて番号を書式設定できます。

次の例では、入力されている電話番号を **PhoneNumberFormatter** を使って書式設定する方法を示します。 phoneNumberInputTextBox という名前の **TextBox** のテキストが変わるたびに、現在の既定の地域を使ってテキスト ボックスの内容が書式設定されて、phoneNumberOutputTextBlock という名前の **TextBlock** に表示されます。 デモンストレーション用として、文字列は地域としてニュージーランドを使って書式設定され、phoneNumberOutputTextBlockNZ という名前の TextBlock にも表示されます。
  
```csharp
    using Windows.Globalization.PhoneNumberFormatting;

    PhoneNumberFormatter currentFormatter, NZFormatter;

    public MainPage()
    {
        this.InitializeComponent();

        // Use the default formatter for the current region
        this.currentFormatter = new PhoneNumberFormatter();

        // Create an explicit formatter for New Zealand. 
        PhoneNumberFormatter.TryCreate("NZ", out this.NZFormatter);
    }

    private void phoneNumberInputTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Format for the default region.
        this.phoneNumberOutputTextBlock.Text = currentFormatter.FormatPartialString(this.phoneNumberInputTextBox.Text);

        // If the NZFormatter was created successfully, format the partial string for the NZ TextBlock.
        if(this.NZFormatter != null)
        {
            this.phoneNumberOutputTextBlockNZ.Text = this.NZFormatter.FormatPartialString(this.phoneNumberInputTextBox.Text);
        }
    }
```    

**[設定]** > **[時刻と言語]** > **[地域と言語]** > **[国/地域]** で国または地域を変更して、個人の PC で上のコードをテストできます。 国または地域 (形式が一致することを確認するために、ニュージーランドなど) を選択し、もう一度コードを実行します。 テスト データでは、ニュージーランドの企業の電話番号を Web 検索することができます。

## <a name="the-users-language-and-cultural-preferences"></a>ユーザーの言語とカルチャの設定

ユーザーの言語、地域、カルチャの設定のみに基づいてさまざまな機能を提供するシナリオでは、[**Windows.System.UserProfile.GlobalizationPreferences**](/uwp/api/windows.system.userprofile.globalizationpreferences?branch=live) を使ってそれらの設定にアクセスするための方法が、Windows によって提供されます。 必要に応じて、**GlobalizationPreferences** クラスを使って、ユーザーの現在の地理的な地域、優先する言語や通貨などの値を取得します。 ただし、アプリの文字列/イメージが、ユーザーの優先する言語にローカライズされていない場合、優先する言語に合わせて書式設定された日付と時刻などのデータが、表示する文字列と一致しないことに注意してください。

## <a name="important-apis"></a>重要な API

* [DateTimeFormatter](/uwp/api/windows.globalization.datetimeformatting?branch=live)
* [NumberFormatting](/uwp/api/windows.globalization.numberformatting?branch=live)
* [Calendar](/uwp/api/windows.globalization.calendar?branch=live)
* [PhoneNumberFormatting](/uwp/api/windows.globalization.phonenumberformatting?branch=live)
* [GlobalizationPreferences](/uwp/api/windows.system.userprofile.globalizationpreferences?branch=live)

## <a name="related-topics"></a>関連トピック

* [カレンダー、日付、および時刻コントロール](../controls-and-patterns/date-and-time.md)
* [ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)
* [言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](../../app-resources/tailor-resources-lang-scale-contrast.md)

## <a name="samples"></a>サンプル

* [カレンダーの詳細と数値演算のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231636)
* [日付と時刻の書式設定のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231618)
* [グローバリゼーション設定サンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231608)
* [数字の書式設定と解析サンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231620)
