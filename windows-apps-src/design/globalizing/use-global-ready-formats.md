---
author: stevewhims
Description: Design your app to be global-ready by appropriately formatting dates, times, numbers, phone numbers, and currencies. You'll then be able later to adapt your app for additional cultures, regions, and languages in the global market.
title: 日付、時刻、数値の形式のグローバル化
ms.assetid: 6ECE8BA4-9A7D-49A6-81EE-AB2BE7F0254F
template: detail.hbs
ms.author: stwhi
ms.date: 11/07/2017
ms.topic: article
keywords: Windows 10, UWP, グローバリゼーション, ローカライズの可否, ローカライズ
ms.localizationpriority: medium
ms.openlocfilehash: 173198c2c61530704dad02e2e92e6a7e47aae420
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7437558"
---
# <a name="globalize-your-datetimenumber-formats"></a><span data-ttu-id="9beff-103">日付、時刻、数値の形式のグローバル化</span><span class="sxs-lookup"><span data-stu-id="9beff-103">Globalize your date/time/number formats</span></span>

<span data-ttu-id="9beff-104">日付、時刻、数値、電話番号、通貨を適切に書式設定することで、グローバル対応のアプリを設計します。</span><span class="sxs-lookup"><span data-stu-id="9beff-104">Design your app to be global-ready by appropriately formatting dates, times, numbers, phone numbers, and currencies.</span></span> <span data-ttu-id="9beff-105">これを行うと、後でアプリを世界市場の他のカルチャ、地域、言語に適応させることができます。</span><span class="sxs-lookup"><span data-stu-id="9beff-105">You'll then be able later to adapt your app for additional cultures, regions, and languages in the global market.</span></span>

## <a name="introduction"></a><span data-ttu-id="9beff-106">概要</span><span class="sxs-lookup"><span data-stu-id="9beff-106">Introduction</span></span>

<span data-ttu-id="9beff-107">アプリを作成するときに、1 つの言語とカルチャに限定せずに広範に考えると、アプリが新しい市場に参入するときに予期しない問題があったとしても少なくなります。</span><span class="sxs-lookup"><span data-stu-id="9beff-107">When creating your app, if you think more broadly than a single language and culture then you'll have fewer (if any) unexpected issues when your app grows into new markets.</span></span> <span data-ttu-id="9beff-108">たとえば、日付、時刻、数値、カレンダー、通貨、電話番号、計測単位、紙のサイズは、すべてカルチャや言語によって表示が異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="9beff-108">For example, dates, times, numbers, calendars, currency, telephone numbers, units of measurement, and paper sizes are all items that can be displayed differently in different cultures or languages.</span></span>

<span data-ttu-id="9beff-109">さまざまな地域やカルチャで、さまざまな日付と時刻の形式が使われています。</span><span class="sxs-lookup"><span data-stu-id="9beff-109">Different regions and cultures use different date and time formats.</span></span> <span data-ttu-id="9beff-110">例として、日付の月と日の順、時刻の時と分との分離、セパレーターとして使われる句読点に関する規則があります。</span><span class="sxs-lookup"><span data-stu-id="9beff-110">These include conventions for the order of day and month in the date, for the separation of hours and minutes in the time, and even for what punctuation is used as a separator.</span></span> <span data-ttu-id="9beff-111">また、日付にはさまざまな表示形式があり、長い形式 ("Wednesday, March 28, 2012") や短い形式 ("3/28/12") など、カルチャによってその表示形式が異なります。</span><span class="sxs-lookup"><span data-stu-id="9beff-111">In addition, dates may be displayed in various long formats ("Wednesday, March 28, 2012") or short formats ("3/28/12"), which vary across cultures.</span></span> <span data-ttu-id="9beff-112">当然ですが、曜日や月の名称と省略形は言語間で異なります。</span><span class="sxs-lookup"><span data-stu-id="9beff-112">And, of course, the names and abbreviations for the days of the week and months of the year differ between languages.</span></span>

<span data-ttu-id="9beff-113">さまざまな言語で使用される形式をプレビューすることができます。</span><span class="sxs-lookup"><span data-stu-id="9beff-113">You can preview the formats used for different languages.</span></span> <span data-ttu-id="9beff-114">**[設定]** > **[時刻と言語]** > **[地域と言語]** に移動し、**[日付、時刻、地域の追加設定]** > **[日付、時刻、または数値の形式の変更]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="9beff-114">Go to **Settings** > **Time & Language** > **Region & language**, and click **Additional date, time, & regional settings** > **Change date, time, or number formats**.</span></span> <span data-ttu-id="9beff-115">**[形式]** タブで、**[表示形式]** ドロップダウンから言語を選択し、**[例]** で形式をプレビューします。</span><span class="sxs-lookup"><span data-stu-id="9beff-115">On the **Formats** tab, select a language from the **Format** drop-down and preview the formats in **Examples**.</span></span>

<span data-ttu-id="9beff-116">このトピックでは、"ユーザー プロファイルの言語の一覧"、"アプリ マニフェストの言語の一覧"、"アプリの実行時の言語の一覧" という用語を定義します。</span><span class="sxs-lookup"><span data-stu-id="9beff-116">This topic uses the terms "user profile language list", "app manifest language list", and "app runtime language list".</span></span> <span data-ttu-id="9beff-117">これらの用語の正確な意味とその値にアクセスする方法の詳細については、「[ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="9beff-117">For details on exactly what those terms mean and how to access their values, see [Understand user profile languages and app manifest languages](manage-language-and-region.md).</span></span>

## <a name="format-dates-and-times-for-the-app-runtime-language-list"></a><span data-ttu-id="9beff-118">アプリの実行時の言語の一覧の日付と時刻の書式設定</span><span class="sxs-lookup"><span data-stu-id="9beff-118">Format dates and times for the app runtime language list</span></span>

<span data-ttu-id="9beff-119">ユーザーが日付や時刻を選択できるようにする必要がある場合には、標準の[カレンダー、日付、および時刻コントロール](../controls-and-patterns/date-and-time.md)を使います。</span><span class="sxs-lookup"><span data-stu-id="9beff-119">If you need to allow users to choose a date, or to select a time, then use the standard [calendar, date, and time controls](../controls-and-patterns/date-and-time.md).</span></span> <span data-ttu-id="9beff-120">これらのコントロールでは、アプリの実行時の言語の一覧に最適な日付と時刻の書式設定を自動的に使います。</span><span class="sxs-lookup"><span data-stu-id="9beff-120">These automatically use the best date and time format for the app runtime language list.</span></span>

<span data-ttu-id="9beff-121">日付や時刻を独自に表示する必要がある場合は、[**DateTimeFormatter**](/uwp/api/windows.globalization.datetimeformatting?branch=live) クラスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="9beff-121">If you need to display dates or times yourself then you can use the [**DateTimeFormatter**](/uwp/api/windows.globalization.datetimeformatting?branch=live) class.</span></span> <span data-ttu-id="9beff-122">既定では、**DateTimeFormatter** は、アプリの実行時の言語の一覧については最適な日付と時刻の形式を自動的に使います。</span><span class="sxs-lookup"><span data-stu-id="9beff-122">By default, **DateTimeFormatter** automatically uses the best date and time format for the app runtime language list.</span></span> <span data-ttu-id="9beff-123">そのため、次のコードでは、その一覧について最適な方法で特定の **DateTime** を書式設定します。</span><span class="sxs-lookup"><span data-stu-id="9beff-123">So, the code below formats a given **DateTime** in the best way for that list.</span></span> <span data-ttu-id="9beff-124">たとえば、アプリ マニフェストの言語の一覧には、既定である英語 (米国) とドイツ語 (ドイツ) が含まれると想定します。</span><span class="sxs-lookup"><span data-stu-id="9beff-124">As an example, assume that your app manifest language list includes English (United States), which is also your default, and German (Germany).</span></span> <span data-ttu-id="9beff-125">現在の日付が 2017 年 11 月 6日で、ユーザー プロファイルの言語の一覧にドイツ語 (ドイツ) が最初に含まれている場合、フォーマッタでは "06.11.2017" を生成します。</span><span class="sxs-lookup"><span data-stu-id="9beff-125">If the current date is Nov 6 2017 and the user profile language list contains German (Germany) first, then the formatter gives "06.11.2017".</span></span> <span data-ttu-id="9beff-126">ユーザー プロファイルの言語の一覧に英語 (米国) が最初に含まれる (または英語とドイツ語のどちらも含まれない) 場合、("en-US" が一致するか、既定で使用されるため) フォーマッタでは "11/6/2017" を生成します。</span><span class="sxs-lookup"><span data-stu-id="9beff-126">If the user profile language list contains English (United States) first (or if it contains neither English nor German), then the formatter gives "11/6/2017" (since "en-US" matches, or is used as the default).</span></span>

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

<span data-ttu-id="9beff-127">上のコードは、次のように個人の PC でテストできます。</span><span class="sxs-lookup"><span data-stu-id="9beff-127">You can test the code above on your own PC like this.</span></span>

- <span data-ttu-id="9beff-128">"en-US" と "de-DE" の両方に対して修飾されたリソース ファイルがプロジェクトにあることを確認します ([言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](../../app-resources/tailor-resources-lang-scale-contrast.md) を参照)。</span><span class="sxs-lookup"><span data-stu-id="9beff-128">Make sure that you have resource files in your project qualified for both "en-US" and "de-DE" (see [Tailor your resources for language, scale, high contrast, and other qualifiers](../../app-resources/tailor-resources-lang-scale-contrast.md)).</span></span>
- <span data-ttu-id="9beff-129">**[設定]** > **[時刻と言語]** > **[地域と言語]** > **[言語]** でユーザー プロファイルの言語の一覧を変更します。</span><span class="sxs-lookup"><span data-stu-id="9beff-129">Change your user profile language list in **Settings** > **Time & Language** > **Region & language** > **Languages**.</span></span> <span data-ttu-id="9beff-130">ドイツ語 (ドイツ) を追加し、それを既定の言語にして、もう一度コードを実行します。</span><span class="sxs-lookup"><span data-stu-id="9beff-130">Add German (Germany), make it the default, and run the code again.</span></span>

## <a name="format-dates-and-times-for-the-user-profile-language-list"></a><span data-ttu-id="9beff-131">ユーザー プロファイルの言語の一覧の日付と時刻の書式設定</span><span class="sxs-lookup"><span data-stu-id="9beff-131">Format dates and times for the user profile language list</span></span>

<span data-ttu-id="9beff-132">既定では、**DateTimeFormatter** がアプリの実行時の言語の一覧に一致することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="9beff-132">Remember that, by default, **DateTimeFormatter** matches the app runtime language list.</span></span> <span data-ttu-id="9beff-133">それにより、"日付は &lt;date&gt; です" という文字列を表示する場合に、言語が日付形式に一致します。</span><span class="sxs-lookup"><span data-stu-id="9beff-133">That way, if you display strings such as "The date is &lt;date&gt;", then the language will match the date format.</span></span>

<span data-ttu-id="9beff-134">何らかの理由でユーザー プロファイルの言語の一覧のみに従って日付または時刻を書式設定する場合は、下の例のようなコードを使って行うことができます。</span><span class="sxs-lookup"><span data-stu-id="9beff-134">If for whatever reason you want to format dates and/or times only according to the user profile language list, then you can do that using code like the example below.</span></span> <span data-ttu-id="9beff-135">ただし、その場合は、アプリに翻訳された文字列がない言語をユーザーが選択できる点を理解してください。</span><span class="sxs-lookup"><span data-stu-id="9beff-135">But if you do so then understand that the user can choose a language for which your app doesn't have translated strings.</span></span> <span data-ttu-id="9beff-136">たとえば、アプリがドイツ語 (ドイツ) にローカライズされていないが、ユーザーがドイツ語 (ドイツ) を優先する言語として選択する場合、"日付は 06.11.2017 です" のような間違いなく変わった外観の文字列が表示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9beff-136">For example, if your app is not localized into German (Germany), but the user chooses that as their preferred language, then that could result in the display of arguably odd-looking strings such as "The date is 06.11.2017".</span></span>

```csharp
    // Use the DateTimeFormatter class to display dates and times using basic formatters.

    var userLanguages = Windows.System.UserProfile.GlobalizationPreferences.Languages;

    var shortDateFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("shortdate", userLanguages);

    var results = "Short Date: " + shortDateFormatter.Format(DateTime.Now);
```

## <a name="format-numbers-and-currencies-appropriately"></a><span data-ttu-id="9beff-137">数字と通貨を適切に書式設定する</span><span class="sxs-lookup"><span data-stu-id="9beff-137">Format numbers and currencies appropriately</span></span>

<span data-ttu-id="9beff-138">数字の書式設定はカルチャによって異なります。</span><span class="sxs-lookup"><span data-stu-id="9beff-138">Different cultures format numbers differently.</span></span> <span data-ttu-id="9beff-139">数字の書式設定が異なるものには、表示する小数の桁数、小数点記号に使う文字、通貨記号などがあります。</span><span class="sxs-lookup"><span data-stu-id="9beff-139">Format differences may include how many decimal digits to display, what characters to use as decimal separators, and what currency symbol to use.</span></span> <span data-ttu-id="9beff-140">[**NumberFormatting**](/uwp/api/windows.globalization.numberformatting?branch=live) 名前空間のクラスを使って、小数、パーセントまたはパーミル数値、通貨を表示します。</span><span class="sxs-lookup"><span data-stu-id="9beff-140">Use classes in the [**NumberFormatting**](/uwp/api/windows.globalization.numberformatting?branch=live) namespace to display decimal, percent, or permille numbers, and currencies.</span></span> <span data-ttu-id="9beff-141">多くの場合、これらのフォーマッタ クラスでユーザー プロファイル用の最適な形式を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="9beff-141">Most of the time, you will want these formatter classes to use the best format for the user profile.</span></span> <span data-ttu-id="9beff-142">ただし、フォーマッタを使って任意の地域または形式の通貨を表示できます。</span><span class="sxs-lookup"><span data-stu-id="9beff-142">But you may use the formatters to display a currency for any region or format.</span></span>

<span data-ttu-id="9beff-143">この例では、ユーザー プロファイルに従った通貨、および特定の通貨制度に対応した通貨を表示する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="9beff-143">This example shows how to display currencies both per the user profile, and for a specific given currency system.</span></span>

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

<span data-ttu-id="9beff-144">**[設定]** > **[時刻と言語]** > **[地域と言語]** > **[国/地域]** で国または地域を変更して、個人の PC で上のコードをテストできます。</span><span class="sxs-lookup"><span data-stu-id="9beff-144">You can test the code above on your own PC by changing the country or region in **Settings** > **Time & Language** > **Region & language** > **Country or region**.</span></span> <span data-ttu-id="9beff-145">国または地域 (アイスランドなど) を選択し、もう一度コードを実行します。</span><span class="sxs-lookup"><span data-stu-id="9beff-145">Choose a country or region (perhaps Iceland), and run the code again.</span></span>

## <a name="use-a-culturally-appropriate-calendar"></a><span data-ttu-id="9beff-146">カルチャに適したカレンダーを使用する</span><span class="sxs-lookup"><span data-stu-id="9beff-146">Use a culturally appropriate calendar</span></span>

<span data-ttu-id="9beff-147">カレンダーは地域や言語によって異なります。</span><span class="sxs-lookup"><span data-stu-id="9beff-147">The calendar differs across regions and languages.</span></span> <span data-ttu-id="9beff-148">グレゴリオ暦がすべての地域で既定となっているわけではありません。</span><span class="sxs-lookup"><span data-stu-id="9beff-148">The Gregorian calendar is not the default for every region.</span></span> <span data-ttu-id="9beff-149">ある地域のユーザーは、日本の年号、アラビアの太陰暦など別のカレンダーを選ぶ場合があります。</span><span class="sxs-lookup"><span data-stu-id="9beff-149">Users in some regions may choose alternate calendars, such as the Japanese era calendar, or Arabic lunar calendars.</span></span> <span data-ttu-id="9beff-150">カレンダーの日付や時刻も、さまざまなタイム ゾーンや夏時間に影響されます。</span><span class="sxs-lookup"><span data-stu-id="9beff-150">Dates and times on the calendar are also sensitive to different time zones and daylight-saving time.</span></span>

<span data-ttu-id="9beff-151">必要なカレンダー形式が使用されていることを確認するために、標準の[カレンダー、日付、および時刻コントロール](../controls-and-patterns/date-and-time.md)を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="9beff-151">To ensure that the preferred calendar format is used, you can use the standard [calendar, date, and time controls](../controls-and-patterns/date-and-time.md).</span></span> <span data-ttu-id="9beff-152">カレンダーの日付を直接操作することが必要な、さらに複雑なシナリオの場合、特定のカルチャ、地域、カレンダーの種類を表す適切なカレンダーを提供する [**Calendar**](/uwp/api/windows.globalization.calendar?branch=live) クラスが **Windows.Globalization** によって提供されています。</span><span class="sxs-lookup"><span data-stu-id="9beff-152">For more complex scenarios, where working directly with operations on calendar dates may be required, **Windows.Globalization** provides a [**Calendar**](/uwp/api/windows.globalization.calendar?branch=live) class that gives an appropriate calendar representation for the given culture, region, and calendar type.</span></span>

## <a name="format-phone-numbers-appropriately"></a><span data-ttu-id="9beff-153">電話番号を適切に書式設定する</span><span class="sxs-lookup"><span data-stu-id="9beff-153">Format phone numbers appropriately</span></span>

<span data-ttu-id="9beff-154">電話番号の書式設定は地域によって異なります。</span><span class="sxs-lookup"><span data-stu-id="9beff-154">Phone numbers are formatted differently across regions.</span></span> <span data-ttu-id="9beff-155">電話番号の桁数、桁のグループ化、および特定部分の重要性は、国によって異なります。</span><span class="sxs-lookup"><span data-stu-id="9beff-155">The number of digits, how the digits are grouped, and the significance of certain parts of the phone number vary between countries.</span></span> <span data-ttu-id="9beff-156">Windows 10 Version 1607 以降では、[**PhoneNumberFormatting**](/uwp/api/windows.globalization.phonenumberformatting?branch=live) 名前空間のクラスを使って、電話番号を現在の地域に適した書式に設定できます。</span><span class="sxs-lookup"><span data-stu-id="9beff-156">Starting in Windows 10, version 1607, you can use classes in the [**PhoneNumberFormatting**](/uwp/api/windows.globalization.phonenumberformatting?branch=live) namespace to format phone numbers appropriately for the current region.</span></span>

<span data-ttu-id="9beff-157">[**PhoneNumberInfo**](/uwp/api/windows.globalization.phonenumberformatting.phonenumberinfo?branch=live) を使うと、数字の文字列を解析して、数字が現在の地域の電話番号として有効かどうかを判定し、2 つの番号が等しいかどうかを比較して、電話番号の国コードや地域コードなどの異なる機能部分を抽出できます。</span><span class="sxs-lookup"><span data-stu-id="9beff-157">[**PhoneNumberInfo**](/uwp/api/windows.globalization.phonenumberformatting.phonenumberinfo?branch=live) parses a string of digits and allows you to: determine whether the digits are a valid phone number in the current region; compare two numbers for equality; and to extract the different functional parts of the phone number, such as country code or geographical area code.</span></span>

<span data-ttu-id="9beff-158">[**PhoneNumberFormatter**](/uwp/api/windows.globalization.phonenumberformatting.phonenumberformatter?branch=live) は、数字の文字列または **PhoneNumberInfo** を表示用に書式設定します。数字の文字列が電話番号の一部だけを表している場合でも使用できます </span><span class="sxs-lookup"><span data-stu-id="9beff-158">[**PhoneNumberFormatter**](/uwp/api/windows.globalization.phonenumberformatting.phonenumberformatter?branch=live) formats a string of digits or a **PhoneNumberInfo** for display, even when the string of digits represents a partial phone number.</span></span> <span data-ttu-id="9beff-159">この部分的な番号の書式設定を使って、ユーザーの番号入力に合わせて番号を書式設定できます。</span><span class="sxs-lookup"><span data-stu-id="9beff-159">You can use this partial number formatting to format a number as a user is entering the number.</span></span>

<span data-ttu-id="9beff-160">次の例では、入力されている電話番号を **PhoneNumberFormatter** を使って書式設定する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9beff-160">The example below shows how to use **PhoneNumberFormatter** to format a phone number as it is being entered.</span></span> <span data-ttu-id="9beff-161">phoneNumberInputTextBox という名前の **TextBox** のテキストが変わるたびに、現在の既定の地域を使ってテキスト ボックスの内容が書式設定されて、phoneNumberOutputTextBlock という名前の **TextBlock** に表示されます。</span><span class="sxs-lookup"><span data-stu-id="9beff-161">Each time text changes in a **TextBox** named phoneNumberInputTextBox, the contents of the text box are formatted using the current default region and displayed in a **TextBlock** named phoneNumberOutputTextBlock.</span></span> <span data-ttu-id="9beff-162">デモンストレーション用として、文字列は地域としてニュージーランドを使って書式設定され、phoneNumberOutputTextBlockNZ という名前の TextBlock にも表示されます。</span><span class="sxs-lookup"><span data-stu-id="9beff-162">For demonstration purposes, the string is also formatted using the region for New Zealand, and displayed in a TextBlock named phoneNumberOutputTextBlockNZ.</span></span>
  
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

<span data-ttu-id="9beff-163">**[設定]** > **[時刻と言語]** > **[地域と言語]** > **[国/地域]** で国または地域を変更して、個人の PC で上のコードをテストできます。</span><span class="sxs-lookup"><span data-stu-id="9beff-163">You can test the code above on your own PC by changing the country or region in **Settings** > **Time & Language** > **Region & language** > **Country or region**.</span></span> <span data-ttu-id="9beff-164">国または地域 (形式が一致することを確認するために、ニュージーランドなど) を選択し、もう一度コードを実行します。</span><span class="sxs-lookup"><span data-stu-id="9beff-164">Choose a country or region (perhaps New Zealand to confirm that the formats match), and run the code again.</span></span> <span data-ttu-id="9beff-165">テスト データでは、ニュージーランドの企業の電話番号を Web 検索することができます。</span><span class="sxs-lookup"><span data-stu-id="9beff-165">For test data, you can do a web search for the phone number of a business in New Zealand.</span></span>

## <a name="the-users-language-and-cultural-preferences"></a><span data-ttu-id="9beff-166">ユーザーの言語とカルチャの設定</span><span class="sxs-lookup"><span data-stu-id="9beff-166">The user's language and cultural preferences</span></span>

<span data-ttu-id="9beff-167">ユーザーの言語、地域、カルチャの設定のみに基づいてさまざまな機能を提供するシナリオでは、[**Windows.System.UserProfile.GlobalizationPreferences**](/uwp/api/windows.system.userprofile.globalizationpreferences?branch=live) を使ってそれらの設定にアクセスするための方法が、Windows によって提供されます。</span><span class="sxs-lookup"><span data-stu-id="9beff-167">For scenarios where you wish to provide different functionality based solely on the user's language, region, or cultural preferences, Windows gives you a way to access those preferences, through [**Windows.System.UserProfile.GlobalizationPreferences**](/uwp/api/windows.system.userprofile.globalizationpreferences?branch=live).</span></span> <span data-ttu-id="9beff-168">必要に応じて、**GlobalizationPreferences** クラスを使って、ユーザーの現在の地理的な地域、優先する言語や通貨などの値を取得します。</span><span class="sxs-lookup"><span data-stu-id="9beff-168">When needed, use the **GlobalizationPreferences** class to get the value of the user's current geographic region, preferred languages, preferred currencies, and so on.</span></span> <span data-ttu-id="9beff-169">ただし、アプリの文字列/イメージが、ユーザーの優先する言語にローカライズされていない場合、優先する言語に合わせて書式設定された日付と時刻などのデータが、表示する文字列と一致しないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="9beff-169">But remember that if your app's strings/images aren't localized for the user's preferred language then dates and times and other data formatted for that preferred language won't match the strings that you display.</span></span>

## <a name="important-apis"></a><span data-ttu-id="9beff-170">重要な API</span><span class="sxs-lookup"><span data-stu-id="9beff-170">Important APIs</span></span>

* [<span data-ttu-id="9beff-171">DateTimeFormatter</span><span class="sxs-lookup"><span data-stu-id="9beff-171">DateTimeFormatter</span></span>](/uwp/api/windows.globalization.datetimeformatting?branch=live)
* [<span data-ttu-id="9beff-172">NumberFormatting</span><span class="sxs-lookup"><span data-stu-id="9beff-172">NumberFormatting</span></span>](/uwp/api/windows.globalization.numberformatting?branch=live)
* [<span data-ttu-id="9beff-173">Calendar</span><span class="sxs-lookup"><span data-stu-id="9beff-173">Calendar</span></span>](/uwp/api/windows.globalization.calendar?branch=live)
* [<span data-ttu-id="9beff-174">PhoneNumberFormatting</span><span class="sxs-lookup"><span data-stu-id="9beff-174">PhoneNumberFormatting</span></span>](/uwp/api/windows.globalization.phonenumberformatting?branch=live)
* [<span data-ttu-id="9beff-175">GlobalizationPreferences</span><span class="sxs-lookup"><span data-stu-id="9beff-175">GlobalizationPreferences</span></span>](/uwp/api/windows.system.userprofile.globalizationpreferences?branch=live)

## <a name="related-topics"></a><span data-ttu-id="9beff-176">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9beff-176">Related topics</span></span>

* [<span data-ttu-id="9beff-177">カレンダー、日付、および時刻コントロール</span><span class="sxs-lookup"><span data-stu-id="9beff-177">Calendar, date, and time controls</span></span>](../controls-and-patterns/date-and-time.md)
* [<span data-ttu-id="9beff-178">ユーザー プロファイルの言語とアプリ マニフェストの言語について</span><span class="sxs-lookup"><span data-stu-id="9beff-178">Understand user profile languages and app manifest languages</span></span>](manage-language-and-region.md)
* [<span data-ttu-id="9beff-179">言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="9beff-179">Tailor your resources for language, scale, high contrast, and other qualifiers</span></span>](../../app-resources/tailor-resources-lang-scale-contrast.md)

## <a name="samples"></a><span data-ttu-id="9beff-180">サンプル</span><span class="sxs-lookup"><span data-stu-id="9beff-180">Samples</span></span>

* [<span data-ttu-id="9beff-181">カレンダーの詳細と数値演算のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="9beff-181">Calendar details and math sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231636)
* [<span data-ttu-id="9beff-182">日付と時刻の書式設定のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="9beff-182">Date and time formatting sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231618)
* [<span data-ttu-id="9beff-183">グローバリゼーション設定サンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="9beff-183">Globalization preferences sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231608)
* [<span data-ttu-id="9beff-184">数字の書式設定と解析サンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="9beff-184">Number formatting and parsing sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231620)
