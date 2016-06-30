---
author: DelfCo
Description: "Windows.Globalization.DateTimeFormatting API でカスタム パターンを使うと、日付と時刻を好みどおりの形式で表示することができます。"
title: "パターンを使った日付と時刻の書式設定"
ms.assetid: 012028B3-9DA2-4E72-8C0E-3E06BEC3B3FE
label: Use patterns to format dates and times
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: 59e02840c72d8bccda7e318197e4bf45ed667fa4
ms.openlocfilehash: 17cd1619a13adced643b4c8983dbf874bebaa740

---

# パターンを使った日付と時刻の書式設定





**重要な API**

-   [**Windows.Globalization.DateTimeFormatting**](https://msdn.microsoft.com/library/windows/apps/br206859)
-   [**DateTimeFormatter**](https://msdn.microsoft.com/library/windows/apps/br206828)
-   [**DateTime**](https://msdn.microsoft.com/library/windows/apps/br206576)

[
            **Windows.Globalization.DateTimeFormatting**](https://msdn.microsoft.com/library/windows/apps/br206859) API でカスタム パターンを使うと、日付と時刻を必要な形式で表示することができます。

## <span id="Introduction"></span><span id="introduction"></span><span id="INTRODUCTION"></span>概要


[
              **Windows.Globalization.DateTimeFormatting**
            ](https://msdn.microsoft.com/library/windows/apps/br206859) では、世界中の言語と地域に対応するように、日付と時刻をさまざまな方法で適切に書式設定できます。 年、月、日などの標準的な形式を使うことも、"longdate" や "month day" などの標準の文字列テンプレートを使うこともできます。

ただし、表示する [**DateTime**](https://msdn.microsoft.com/library/windows/apps/br206576) 文字列の構成要素の順序や形式をより細かく制御する場合は、"パターン" と呼ばれる文字列テンプレート パラメーター用の特別な構文を使うことができます。 パターン構文を使うと、任意に選んだカスタム形式で表示するために、**DateTime** オブジェクトの個々の構成要素を取得できます (たとえば、月の名称のみを取得したり、年の値のみを取得したりすることができます)。 さらに、パターンをローカライズして、他の言語や地域に対応させることができます。

**注**  ここで説明しているのは、書式パターンの概要です。 書式テンプレートと書式パターンについて詳しくは、[**DateTimeFormatter**](https://msdn.microsoft.com/library/windows/apps/br206828) クラスの「解説」セクションをご覧ください。

 

## <span id="What_you_need_to_know"></span><span id="what_you_need_to_know"></span><span id="WHAT_YOU_NEED_TO_KNOW"></span>理解しておく必要があること


パターンを使うときは、すべてのカルチャに対して有効であるとは限らないカスタム形式を構築するという点に注意してください。 たとえば、"month day" テンプレートについて考えてみます。

**C#**
```CSharp
var datefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
```
**JavaScript**
```JavaScript
var datefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
```

これにより、現在のコンテキストの言語や地域の値に基づいてフォーマッタが作成されます。 そのために、常に、適切なグローバル形式で月と日が一緒に表示されます。 たとえば、英語 (米国) の場合は "January 1"、フランス語 (フランス) の場合は "1 janvier"、日本語の場合は "1 月 1 日" と表示されます。 これは、テンプレートがパターン プロパティを使ってアクセスできるカルチャ固有のパターン文字列に基づいているためです。

**C#**
```CSharp
var monthdaypattern = datefmt.Patterns;
```
**JavaScript**
```JavaScript
var monthdaypattern = datefmt.patterns;
```

これにより、フォーマッタの言語と地域に応じて異なる結果が返されます。 さまざまな地域で、順序の違いや文字とスペースの追加の有無など、それぞれ異なる構成要素が使われる場合があります。

``` syntax
En-US: "{month.full} {day.integer}"
Fr-FR: "{day.integer} {month.full}"
Ja-JP: "{month.integer}月{day.integer}日"
```

パターンを使ってカスタムの [**DateTimeFormatter**](https://msdn.microsoft.com/library/windows/apps/br206828) を構築することができます。たとえば、この例は米国英語のパターンに基づいています。

**C#**
```CSharp
var datefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("{month.full} {day.integer}");
```
**JavaScript**
```JavaScript
var datefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("{month.full} {day.integer}");
```

Windows では、中かっこ {{}} 内の個々の構成要素についてカルチャ固有の値が返されます。 ただし、パターン構文を使った場合、構成要素の順序は不変です。 要求どおりのものが得られても、それがカルチャに適していない場合があります。

``` syntax
En-US: January 1
Fr-FR: janvier 1 (inappropriate for France; non-standard order)
Ja-JP: 1月1 (inappropriate for Japan; the day symbol is missing)
```

さらに、パターンは時間が経過しても一貫性が維持されるとは限りません。 国や地域で暦体系が変更されると、それに伴い書式テンプレートが変わる場合があります。 Windows では、このような変更に合わせてフォーマッタの出力を更新します。 したがって、次のような場合、[**DateTime**](https://msdn.microsoft.com/library/windows/apps/br206576) を書式設定するために必要な操作は、パターン構文を使うことだけです。

-   書式設定の特定の出力に依存していない。
-   カルチャ固有の標準に従うための書式設定を必要としない。
-   すべてのカルチャにわたってパターンが不変であることを特に意図している。
-   パターンのローカライズを意図している。

標準の文字列テンプレートと標準以外の文字列パターンとの間の相違のまとめ

**"month day" などの文字列テンプレート:**

-   月と日の値を含み、ある一定の順序を備えた [**DateTime**](https://msdn.microsoft.com/library/windows/apps/br206576) 形式の抽象化された表現です。
-   Windows でサポートされているすべての言語と地域にわたって有効な標準の形式を必ず返します。
-   特定の言語と地域のカルチャに適するように書式設定された文字列を必ず提供します。
-   構成要素のすべての組み合わせが有効であるとは限りません。 たとえば、"dayofweek day" に対応する文字列テンプレートはありません。

**"{{month.full}} {{day.integer}}" などの文字列パターン:**

-   月の完全な名前の後にスペースが挿入され、その後に日付の整数が続く、特定の順序の明示的に指定された文字列です。
-   任意の言語と地域のペアについて有効な標準の形式に対応しない場合があります。
-   カルチャに適するとは限りません。
-   任意の順序の構成要素のあらゆる組み合わせを指定できます。

## <span id="Tasks"></span><span id="tasks"></span><span id="TASKS"></span>処理手順


現在の月と日を特定の形式で現在時刻と一緒に表示するとします。 たとえば、米国英語のユーザーに次のように表示する必要があるとします。

``` syntax
June 25 | 1:38 PM
```

日付の部分は "month day" テンプレートに対応し、時刻の部分は "hour minute" テンプレートに対応します。 そのため、これらのテンプレートを構成するパターンを連結したカスタム形式を作ることができます。

まず、関連する日付のテンプレートと時刻のテンプレートのフォーマッタを取得してから、これらのテンプレートのパターンを取得します。

**C#**
```CSharp
// Get formatters for the date part and the time part.
var mydate = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("month day");
var mytime = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter("hour minute");

// Get the patterns from these formatters.
var mydatepattern = mydate.Patterns[0];
var mytimepattern = mytime.Patterns[0];
```
**JavaScript**
```JavaScript
// Get formatters for the date part and the time part.
var dtf = Windows.Globalization.DateTimeFormatting;
var mydate = dtf.DateTimeFormatter("month day");
var mytime = dtf.DateTimeFormatter("hour minute");

// Get the patterns from these formatters.
var mydatepattern = mydate.patterns[0];
var mytimepattern = mytime.patterns[0];
```

カスタム形式は、ローカライズ可能なリソース文字列として保存する必要があります。 たとえば、英語 (米国) の場合の文字列は "{{date}} | {{time}}" となります。 ローカライズ担当者は、必要に応じてこの文字列を調整することができます。 たとえば、時刻を日付より前に配置する方が一部の言語や地域では自然であると思われる場合は、構成要素の順序を変更できます。 また、"|" を別の区切り文字に置き換えることもできます。 実行時に、該当するパターンを使って文字列の {{date}} 部分と {{time}} 部分を置き換えます。

**C#**
```CSharp
// Assemble the custom pattern. This string comes from a resource, and should be localizable. 
var resourceLoader = new Windows.ApplicationModel.Resources.ResourceLoader();
var mydateplustime = resourceLoader.GetString("date_plus_time");
mydateplustime = mydateplustime.replace("{date}", mydatepattern);
mydateplustime = mydateplustime.replace("{time}", mytimepattern);
```
**JavaScript**
```JavaScript
// Assemble the custom pattern. This string comes from a resource, and should be localizable. 
var mydateplustime = WinJS.Resources.getString("date_plus_time");
mydateplustime = mydateplustime.replace("{date}", mydatepattern);
mydateplustime = mydateplustime.replace("{time}", mytimepattern);
```

これで、カスタム パターンに基づいて新しいフォーマッタを構築できるようになりました。

**C#**
```CSharp
// Get the custom formatter.
var mydateplustimefmt = new Windows.Globalization.DateTimeFormatting.DateTimeFormatter(mydateplustime);
```
**JavaScript**
```JavaScript
// Get the custom formatter.
var mydateplustimefmt = new dtf.DateTimeFormatter(mydateplustime);
```

## <span id="related_topics"></span>関連トピック


* [日付と時刻の書式設定のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=231618)
* [**Windows.Globalization.DateTimeFormatting**](https://msdn.microsoft.com/library/windows/apps/br206859)
* [**Windows.Foundation.DateTime**](https://msdn.microsoft.com/library/windows/apps/br206576)
 

 






<!--HONumber=Jun16_HO4-->


