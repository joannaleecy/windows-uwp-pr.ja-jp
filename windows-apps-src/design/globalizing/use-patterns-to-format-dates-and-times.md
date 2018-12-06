---
Description: Use the Windows.Globalization.DateTimeFormatting API with custom templates and patterns to display dates and times in exactly the format you wish.
title: パターンを使った日付と時刻の書式設定
ms.assetid: 012028B3-9DA2-4E72-8C0E-3E06BEC3B3FE
label: Use patterns to format dates and times
template: detail.hbs
ms.date: 11/09/2017
ms.topic: article
keywords: Windows 10, UWP, グローバリゼーション, ローカライズの可否, ローカライズ
ms.localizationpriority: medium
ms.openlocfilehash: 9ffcbc3d1c11c8f756b6307b15b87c14b09f65c4
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8751106"
---
# <a name="use-templates-and-patterns-to-format-dates-and-times"></a><span data-ttu-id="5d2c1-103">テンプレートとパターンを使った日付と時刻の書式設定</span><span class="sxs-lookup"><span data-stu-id="5d2c1-103">Use templates and patterns to format dates and times</span></span>

<span data-ttu-id="5d2c1-104">[**Windows.Globalization.DateTimeFormatting**](/uwp/api/windows.globalization.datetimeformatting?branch=live) 名前空間のクラスでカスタムのテンプレートとパターンを使うと、日付と時刻を好みの形式で表示できます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-104">Use classes in the [**Windows.Globalization.DateTimeFormatting**](/uwp/api/windows.globalization.datetimeformatting?branch=live) namespace with custom templates and patterns to display dates and times in exactly the format you wish.</span></span>

## <a name="introduction"></a><span data-ttu-id="5d2c1-105">概要</span><span class="sxs-lookup"><span data-stu-id="5d2c1-105">Introduction</span></span>

<span data-ttu-id="5d2c1-106">[**DateTimeFormatter**](/uwp/api/windows.globalization.datetimeformatting?branch=live) クラスでは、世界中の言語と地域に対応するように、日付と時刻をさまざまな方法で適切に書式設定できます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-106">The [**DateTimeFormatter**](/uwp/api/windows.globalization.datetimeformatting?branch=live) class provides various ways to properly format dates and times for languages and regions around the world.</span></span> <span data-ttu-id="5d2c1-107">年、月、日などについて標準形式を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-107">You can use standard formats for year, month, day, and so on.</span></span> <span data-ttu-id="5d2c1-108">または、"longdate" または "month day" のような **DateTimeFormatter** コンストラクターの *formatTemplate* 引数に書式テンプレートを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-108">Or you can pass a format template to the *formatTemplate* argument of the **DateTimeFormatter** constructor, such as "longdate" or "month day".</span></span>

<span data-ttu-id="5d2c1-109">ただし、表示する [**DateTime**](/uwp/api/windows.foundation.datetime?branch=live) オブジェクトの構成要素の順序や形式をより細かく制御する場合は、コンストラクターの *formatTemplate* 引数に書式パターンを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-109">But when you want even more control over the order and format of the components of the [**DateTime**](/uwp/api/windows.foundation.datetime?branch=live) object you wish to display, you can pass a format pattern to the *formatTemplate* argument of the constructor.</span></span> <span data-ttu-id="5d2c1-110">書式パターンでは特別な構文を使用します。これにより、任意に選んだカスタム形式で表示するために、**DateTime** オブジェクトの個々のコンポーネントを取得できます (たとえば、月の名称のみを取得したり、年の値のみを取得したりすることができます)。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-110">A format pattern uses a special syntax, which allows you to obtain individual components of a **DateTime** object&mdash;just the month name, or just the year value, for example&mdash;in order to display them in whatever custom format you choose.</span></span> <span data-ttu-id="5d2c1-111">さらに、パターンをローカライズして、他の言語や地域に対応させることができます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-111">Furthermore, the pattern can be localized to adapt to other languages and regions.</span></span>

<span data-ttu-id="5d2c1-112">**注:** 書式パターンの概要だけです。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-112">**Note**This is only an overview of format patterns.</span></span> <span data-ttu-id="5d2c1-113">書式テンプレートと書式パターンについて詳しくは、[**DateTimeFormatter**](/uwp/api/windows.globalization.datetimeformatting?branch=live) クラスの「解説」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-113">For a more complete discussion of format templates and format patterns see the Remarks section of the [**DateTimeFormatter**](/uwp/api/windows.globalization.datetimeformatting?branch=live) class.</span></span>

## <a name="the-difference-between-format-templates-and-format-patterns"></a><span data-ttu-id="5d2c1-114">書式テンプレートと書式パターンの違い</span><span class="sxs-lookup"><span data-stu-id="5d2c1-114">The difference between format templates and format patterns</span></span>

<span data-ttu-id="5d2c1-115">書式テンプレートは、カルチャに依存しない形式の文字列です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-115">A format template is a culture-agnostic format string.</span></span> <span data-ttu-id="5d2c1-116">そのため、書式テンプレートを使用して **DateTimeFormatter** を作成する場合、フォーマッタでは現在の言語の正しい順序で書式コンポーネントを表示します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-116">So, if you construct a **DateTimeFormatter** using a format template, then the formatter displays your format components in the right order for the current language.</span></span> <span data-ttu-id="5d2c1-117">逆に、書式パターンはカルチャ固有です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-117">Conversely, a format pattern is culture-specific.</span></span> <span data-ttu-id="5d2c1-118">書式パターンを使用して **DateTimeFormatter** 作成している場合、フォーマッタでは与えられたとおりにパターンを使用します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-118">If you construct a **DateTimeFormatter** using a format pattern, then the formatter will use the pattern exactly as given.</span></span> <span data-ttu-id="5d2c1-119">その結果、パターンは、すべてのカルチャに対して有効であるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-119">Consequently, a pattern isn't necesssarily valid across cultures.</span></span>

<span data-ttu-id="5d2c1-120">例を使用してこの違いを説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-120">Let's illustrate this distinction with an example.</span></span> <span data-ttu-id="5d2c1-121">単純な書式テンプレート (パターンではない) を**DateTimeFormatter** コンストラクターに渡します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-121">We'll pass a simple format template (not a pattern) to the **DateTimeFormatter** constructor.</span></span> <span data-ttu-id="5d2c1-122">これは、書式テンプレート "month day" です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-122">This is the format template "month day".</span></span>

```csharp
var dateFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
```

<span data-ttu-id="5d2c1-123">これにより、現在のコンテキストの言語や地域の値に基づいてフォーマッタが作成されます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-123">This creates a formatter based on the language and region value of the current context.</span></span> <span data-ttu-id="5d2c1-124">書式テンプレート内のコンポーネントの順序は問題になりません。フォーマッタでは、現在の言語の正しい順序でそれらを表示します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-124">The order of the components in a format template doesn't matter; the formatter displays them in the right order for the current language.</span></span> <span data-ttu-id="5d2c1-125">たとえば、英語 (米国) の場合は "January 1"、フランス語 (フランス) の場合は "1 janvier"、日本語の場合は "1 月 1 日" と表示されます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-125">So, it displays "January 1" for English (United States), "1 janvier" for French (France), and "1月1日" for Japanese.</span></span>

<span data-ttu-id="5d2c1-126">その一方で、書式パターンはカルチャ固有です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-126">On the other hand, a format pattern is culture-specific.</span></span> <span data-ttu-id="5d2c1-127">書式テンプレートの書式パターンにアクセスしてみましょう。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-127">Let's access the format pattern for our format template.</span></span>

```csharp
IReadOnlyList<string> monthDayPatterns = dateFormatter.Patterns;
```

<span data-ttu-id="5d2c1-128">これにより、実行時の言語と地域に応じて異なる結果が返されます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-128">This yields different results depending on the runtime language and region.</span></span> <span data-ttu-id="5d2c1-129">さまざまな地域で、順序の違いや文字とスペースの追加の有無など、それぞれ異なるコンポーネントが使われる場合があります。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-129">Different regions might use different components, in different orders, with or without additional characters and spacing.</span></span>

```syntax
En-US: "{month.full} {day.integer}"
Fr-FR: "{day.integer} {month.full}"
Ja-JP: "{month.integer}月{day.integer}日"
```

<span data-ttu-id="5d2c1-130">上の例では、カルチャに依存しない書式設定文字列を入力し、カルチャ固有の書式設定文字列を再度取得しました (これは、`dateFormatter.Patterns` を呼び出したときに有効であった言語と地域の関数でした)。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-130">In the example above, we inputted a culture-agnostic format string, and we got back a culture-specific format string (which was a function of the language and region that happened to be in effect when we called `dateFormatter.Patterns`).</span></span> <span data-ttu-id="5d2c1-131">要するに、カルチャ固有の書式パターンから **DateTimeFormatter** を作成する場合、特定の言語または地域でのみ有効になります。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-131">It follows therefore that if you construct a **DateTimeFormatter** from a culture-specific format pattern, then it will only be valid for specific languages/regions.</span></span>

```csharp
var dateFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("{month.full} {day.integer}");
```

<span data-ttu-id="5d2c1-132">上のフォーマッタでは、角かっこ内の個々 のコンポーネントのカルチャ固有の値を返します。{}します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-132">The formatter above returns culture-specific values for the individual components inside the brackets {}.</span></span> <span data-ttu-id="5d2c1-133">ただし、書式パターンのコンポーネントの順序は不変です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-133">But the order of components in a format pattern is invariant.</span></span> <span data-ttu-id="5d2c1-134">要求どおりのものが得られても、それがカルチャに適している場合と適していない場合があります。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-134">You get precisely what you ask for, which may or may not be culturally appropriate.</span></span> <span data-ttu-id="5d2c1-135">このフォーマッタは英語 (米国) で有効ですが、フランス語 (フランス) または日本語では有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-135">This formatter is valid for English (United States), but not for French (France) nor for Japanese.</span></span>

``` syntax
En-US: January 1
Fr-FR: janvier 1 (inappropriate for France; non-standard order)
Ja-JP: 1月1 (inappropriate for Japan; the day symbol 日 is missing)
```

<span data-ttu-id="5d2c1-136">さらに、今日正しいパターンが、将来正しくなくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-136">Furthermore, a pattern that's correct today might not be correct in the future.</span></span> <span data-ttu-id="5d2c1-137">国や地域で暦体系が変更されると、それに伴い書式テンプレートが変わる場合があります。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-137">Countries or regions might change their calendar systems, which alters a format template.</span></span> <span data-ttu-id="5d2c1-138">Windows では、書式テンプレートに基づき、このような変更に合わせてフォーマッタの出力を更新します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-138">Windows updates the output of formatters based on format templates to accommodate such changes.</span></span> <span data-ttu-id="5d2c1-139">そのため、これらの 1 つ以上の条件下でのみパターン構文を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-139">Therefore, you should only use the pattern syntax under one or more of these conditions.</span></span>

-   <span data-ttu-id="5d2c1-140">書式設定の特定の出力に依存していない。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-140">You are not dependent on a particular output for a format.</span></span>
-   <span data-ttu-id="5d2c1-141">カルチャ固有の標準に従うための書式設定を必要としない。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-141">You do not need the format to follow some culture-specific standard.</span></span>
-   <span data-ttu-id="5d2c1-142">すべてのカルチャにわたってパターンが不変であることを特に意図している。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-142">You specifically intend the pattern to be invariant across cultures.</span></span>
-   <span data-ttu-id="5d2c1-143">実際の書式パターンの文字列自体をローカライズすることを意図している。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-143">You intend to localize the actual format pattern string itself.</span></span>

<span data-ttu-id="5d2c1-144">書式テンプレートと書式パターンの違いを、以下に簡単にまとめます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-144">Here's a summary of the distinction between format templates and format patterns.</span></span>

**<span data-ttu-id="5d2c1-145">"month day" などの書式テンプレート</span><span class="sxs-lookup"><span data-stu-id="5d2c1-145">Format templates, such as "month day"</span></span>**

-   <span data-ttu-id="5d2c1-146">月や日などの値を任意の順序で含む [DateTime](/uwp/api/windows.foundation.datetime?branch=live) 形式の抽象化された表現です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-146">Abstracted representation of a [DateTime](/uwp/api/windows.foundation.datetime?branch=live) format that includes values for the month, day, etc., in any order.</span></span>
-   <span data-ttu-id="5d2c1-147">Windows でサポートされているすべての言語と地域にわたって有効な標準の形式を必ず返します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-147">Guaranteed to return a valid standard format across all language-region values supported by Windows.</span></span>
-   <span data-ttu-id="5d2c1-148">特定の言語と地域のカルチャに適するように書式設定された文字列を必ず提供します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-148">Guaranteed to give you a culturally-appropriate formatted string for the given language-region.</span></span>
-   <span data-ttu-id="5d2c1-149">コンポーネントのすべての組み合わせが有効であるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-149">Not all combinations of components are valid.</span></span> <span data-ttu-id="5d2c1-150">たとえば、"dayofweek day" は正しくありません。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-150">For example, "dayofweek day" is not valid.</span></span>

**<span data-ttu-id="5d2c1-151">"{month.full} {day.integer}" などの書式パターン</span><span class="sxs-lookup"><span data-stu-id="5d2c1-151">Format patterns, such as "{month.full} {day.integer}"</span></span>**

-   <span data-ttu-id="5d2c1-152">月の完全な名前の後にスペースが挿入され、その後に日付の整数が続く、特定の順序、または指定した特定の書式パターンの明示的に指定された文字列です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-152">Explicitly ordered string that expresses the full month name, followed by a space, followed by the day integer, in that order, or whatever specific format pattern you specify.</span></span>
-   <span data-ttu-id="5d2c1-153">任意の言語と地域のペアについて有効な標準の形式に対応しない場合があります。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-153">May not correspond to a valid standard format for any language-region pair.</span></span>
-   <span data-ttu-id="5d2c1-154">カルチャに適するとは限りません。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-154">Not guaranteed to be culturally appropriate.</span></span>
-   <span data-ttu-id="5d2c1-155">任意の順序のコンポーネントのあらゆる組み合わせを指定できます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-155">Any combination of components may be specified, in any order.</span></span>

## <a name="examples"></a><span data-ttu-id="5d2c1-156">例</span><span class="sxs-lookup"><span data-stu-id="5d2c1-156">Examples</span></span>

<span data-ttu-id="5d2c1-157">現在の月と日を特定の形式で現在時刻と一緒に表示するとします。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-157">Suppose you wish to display the current month and day together with the current time, in a specific format.</span></span> <span data-ttu-id="5d2c1-158">たとえば、米国英語のユーザーに次のように表示する必要があるとします。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-158">For example, you would like US English users to see something like this:</span></span>

``` syntax
June 25 | 1:38 PM
```

<span data-ttu-id="5d2c1-159">日付の部分は "month day" 書式テンプレートに対応し、時刻の部分は "hour minute" 書式テンプレートに対応します。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-159">The date part corresponds to the "month day" format template, and the time part corresponds to the "hour minute" format template.</span></span> <span data-ttu-id="5d2c1-160">そのため、関連する日付と時刻の書式テンプレートのフォーマッタを構築し、ローカライズ可能な書式文字列を使用してその出力を連結できます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-160">So, you can construct formatters for the relevant date and time format templates, and then concatenate their ouput together using a localizable format string.</span></span>

```csharp
var dateToFormat = System.DateTime.Now;
var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();

var dateFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
var timeFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("hour minute");

var date = dateFormatter.Format(dateToFormat);
var time = timeFormatter.Format(dateToFormat);

string output = string.Format(resourceLoader.GetString("CustomDateTimeFormatString"), date, time);
```

`CustomDateTimeFormatString` <span data-ttu-id="5d2c1-161">は、リソース ファイル (.resw) でローカライズ可能なリソースを参照するリソース識別子です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-161">is a resource identifier referring to a localizable resource in a Resources File (.resw).</span></span> <span data-ttu-id="5d2c1-162">この、英語 (米国) の既定の言語の値を設定が"{0} |{1}"ことを示すコメントを"{0}"は日付と"{1}"は時間です。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-162">For a default language of English (United States), this would be set to a value of "{0} | {1}" along with a comment indicating that "{0}" is the date and "{1}" is the time.</span></span> <span data-ttu-id="5d2c1-163">このようにして、翻訳者は必要に応じて書式項目を調整できます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-163">That way, translators can adjust the format items as needed.</span></span> <span data-ttu-id="5d2c1-164">たとえば、時刻を日付より前に配置する方が一部の言語や地域では自然であると思われる場合は、項目の順序を変更できます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-164">For example, they can change the order of the items if it seems more natural in some language or region to have the time precede the date.</span></span> <span data-ttu-id="5d2c1-165">また、"|" を別の区切り文字に置き換えることもできます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-165">Or, they can replace "|" with some other separator character.</span></span>

<span data-ttu-id="5d2c1-166">また、この例を実装する別の方法として、2 つのフォーマッタを照会して書式パターンを検索し、それらの書式パターンを連結して、結果として生成される書式パターンから 3 つ目のフォーマッタを構築することができます。</span><span class="sxs-lookup"><span data-stu-id="5d2c1-166">Another way to implement this example is to query the two formatters for their format patterns, concatenate those together, and then construct a third formatter from the resultant format pattern.</span></span>

```csharp
var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();

var dateFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
var timeFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("hour minute");

string dateFormatterPattern = dateFormatter.Patterns[0];
string timeFormatterPattern = timeFormatter.Patterns[0];

string pattern = string.Format(resourceLoader.GetString("CustomDateTimeFormatString"), dateFormatterPattern, timeFormatterPattern);

var patternFormatter = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter(pattern);

string output = patternFormatter.Format(System.DateTime.Now);
```

## <a name="important-apis"></a><span data-ttu-id="5d2c1-167">重要な API</span><span class="sxs-lookup"><span data-stu-id="5d2c1-167">Important APIs</span></span>

* [<span data-ttu-id="5d2c1-168">Windows.Globalization.DateTimeFormatting</span><span class="sxs-lookup"><span data-stu-id="5d2c1-168">Windows.Globalization.DateTimeFormatting</span></span>](/uwp/api/windows.globalization.datetimeformatting?branch=live)
* [<span data-ttu-id="5d2c1-169">DateTimeFormatter</span><span class="sxs-lookup"><span data-stu-id="5d2c1-169">DateTimeFormatter</span></span>](/uwp/api/windows.globalization.datetimeformatting?branch=live)
* [<span data-ttu-id="5d2c1-170">DateTime</span><span class="sxs-lookup"><span data-stu-id="5d2c1-170">DateTime</span></span>](/uwp/api/windows.foundation.datetime?branch=live)

## <a name="related-topics"></a><span data-ttu-id="5d2c1-171">関連トピック</span><span class="sxs-lookup"><span data-stu-id="5d2c1-171">Related topics</span></span>

* [<span data-ttu-id="5d2c1-172">日付と時刻の書式設定のサンプル</span><span class="sxs-lookup"><span data-stu-id="5d2c1-172">Date and time formatting sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=231618)
