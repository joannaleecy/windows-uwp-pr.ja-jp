---
Description: パートナー センターの登録プロセス中に、VAT ID 番号を指定する必要がある場合、開始するためのいくつかの情報を示します。
title: 付加価値税情報
ms.assetid: 93834A6B-86D6-4647-AC01-CBCA3CB7A578
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3d8b11815d7762179ad982edaf3985c06f9f54e4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57648977"
---
# <a name="vat-info"></a>付加価値税情報


パートナー センターの登録プロセス中に、VAT ID 番号を指定する必要がある場合、開始するためのいくつかの情報を示します。

## <a name="understanding-vat-numbers"></a>VAT 番号について


付加価値税 (VAT) 番号は、欧州連合の国と地域に使用されている識別番号です。 詳しくは、欧州連合の公式 [VIES サイト](https://go.microsoft.com/fwlink/p/?LinkId=258372)をご覧ください。

## <a name="accepted-formats-for-vat-numbers"></a>VAT 番号で使用される形式


Microsoft では税務に関する助言を提供しておらず、次の情報はガイダンスとしてのみ提供しています。 Microsoft に対して VAT 番号を提供するうえでこのガイダンスが十分でない場合は、最新の変更について管轄の税務機関に確認してください。

<table Responsive="true">
<tr><th>国/地域</th><th>付加価値税情報</th></tr>
<tr><td data-th="Country/region">オーストリア
</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:1 つの文字と 8 桁の数字</li>
<li>国/地域コード。AT</li>
<li>以下に例を示します。U12345678</li>
<li>注:最初の文字は、'U' 常になります。
</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ベルギー</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:10 桁の数字</li>
<li>国/地域コード。BE</li>
<li>以下に例を示します。1234567890</li>
<li>注:2007 年 1 月 1 日より前の 9 桁。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ブルガリア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:9 または 10 桁の数字</li>
<li>国/地域コード。BG</li>
<li>以下に例を示します。123456789 または 0123456789</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">クロアチア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:2 つの文字と 11 桁の数字</li>
<li>国/地域コード。HR</li>
<li>以下に例を示します。HR12345678901</li>
<li>注:最初の文字は、'HR' 常になります。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">キプロス</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:2 文字の 8 桁の数字と 1 つの文字</li>
<li>国/地域コード。CY</li>
<li>以下に例を示します。12345678、123456789、または 0123456789</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">チェコ共和国</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:8、9、または 10 桁の数字</li>
<li>国/地域コード。CZ</li>
<li>以下に例を示します。12345678、123456789、または 0123456789</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">デンマーク</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:8 桁の数字</li>
<li>国/地域コード。DK</li>
<li>以下に例を示します。12345678</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">エストニア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:9 桁の数字</li>
<li>国/地域コード。EE</li>
<li>以下に例を示します。123456789</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">フィンランド</td><td data-th="VAT info">
<ul>
<li>VAT 番号形式: 8 桁の数字</li>
<li>国/地域コード。FI</li>
<li>以下に例を示します。12345678</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">フランス</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:11 桁の数字</li>
<li>国/地域コード。FR</li>
<li>以下に例を示します。12345678901、X1234567890、1 x 123456789 または XX123456789</li>
<li>注:最初または 2 番目の文字、または 9 の数字が続く、最初と 2 番目の文字として、または Q のアルファベット文字を含めることができます。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ドイツ</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:9 桁の数字</li>
<li>国/地域コード。DE</li>
<li>以下に例を示します。123456789</li>
<li>注:9 桁 ' Umsatzsteur Identifikationnummer' (Ust ID Nr) にする必要があります。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ギリシャ</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:9 桁の数字</li>
<li>国/地域コード。EL、GR</li>
<li>以下に例を示します。123456789</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ハンガリー</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:8 桁の数字</li>
<li>国/地域コード。HU</li>
<li>以下に例を示します。12345678</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">アイルランド</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:8 桁の数字</li>
<li>国/地域コード。Internet Explorer</li>
<li>以下に例を示します。1234567 X または 1X34567X</li>
<li>注:1 つまたは 2 のアルファベット文字が含まれています。 最後に、いずれかまたは 2 番目と最後の。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">イタリア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:11 桁の数字</li>
<li>国/地域コード。IT</li>
<li>以下に例を示します。12345678901</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ラトビア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:11 桁の数字</li>
<li>国/地域コード。LV</li>
<li>以下に例を示します。01234567890</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">リトアニア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:9、または 12 桁の数字</li>
<li>国/地域コード。LT</li>
<li>以下に例を示します。123456789 または 012345678901</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ルクセンブルク</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:8 桁の数字</li>
<li>国/地域コード。LU</li>
<li>以下に例を示します。12345678</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">マルタ</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:2 つの文字および数字の 8</li>
<li>国/地域コード。MT</li>
<li>以下に例を示します。MT12345678</li>
<li>注:最初の文字は、'MT' 常になります。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">オランダ</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:11 桁の数字と 1 つの文字</li>
<li>国/地域コード。NL</li>
<li>以下に例を示します。123456789B01</li>
<li>注:10 番目の文字は、常に、'B' です。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ポーランド</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:10 桁の数字</li>
<li>国/地域コード。PL</li>
<li>以下に例を示します。1234567890</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ポルトガル</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:9 桁の数字</li>
<li>国/地域コード。PT</li>
<li>以下に例を示します。123456789</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">ルーマニア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:2 つの文字および数字の 8-10</li>
<li>国/地域コード。RO</li>
<li>以下に例を示します。RO12345678、RO123456789、または RO1234567890</li>
<li>注:最初の文字は、'RO' 常になります。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">スロバキア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:10 桁の数字</li>
<li>国/地域コード。SK</li>
<li>以下に例を示します。1234567890</li>
<li>注:最初の文字は、「SI」常になります。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">スロベニア</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:2 つの文字および数字の 8</li>
<li>国/地域コード。SI</li>
<li>以下に例を示します。SI12345678</li>
<li>注:最初の文字は、「SI」常になります。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">スペイン</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:9 桁の数字</li>
<li>国/地域コード。ES</li>
<li>以下に例を示します。X12345678、12345678 X、または X1234567X</li>
<li>注:1 つまたは 2 文字が含まれています: 初、最後、または最初と最後です。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">スウェーデン</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:12 桁の数字</li>
<li>国/地域コード。SE</li>
<li>以下に例を示します。123456789001</li>
<li>注:最後の 2 つの文字は、'01' である必要があります。</li>
</ul>
</td></tr>
<tr><td data-th="Country/region">イギリス</td><td data-th="VAT info">
<ul>
<li>VAT 番号の形式:9、または 12 桁の数字</li>
<li>国/地域コード。GB</li>
<li>以下に例を示します。123456789 または 123456789001</li>
<li>注:9 桁の数字の数は、グループ内のサブ サイトを表している場合、12 桁ですが一般に、します。</li>
</ul>
</td></tr>
</table>
                                                                                                                                                                  

 

 




