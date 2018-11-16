---
author: stevewhims
Description: Design and develop your app in such a way that it functions appropriately on systems with different language and culture configurations.
Search.Refinement.TopicID: 180
title: グローバリゼーションのガイドライン
ms.assetid: 0342DC3F-DDD1-4DD4-872E-A4EC340CAE79
template: detail.hbs
ms.author: stwhi
ms.date: 11/02/2017
ms.topic: article
keywords: Windows 10, UWP, グローバリゼーション, ローカライズの可否, ローカライズ
ms.localizationpriority: medium
ms.openlocfilehash: 177332515db26eca7cef7a7be75c5752a239a8f1
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6674683"
---
# <a name="guidelines-for-globalization"></a>グローバリゼーションのガイドライン

言語とカルチャの構成が異なるシステムで適切に機能するようにアプリを設計して開発します。 [**グローバリゼーション**](/uwp/api/Windows.Globalization?branch=live) API を使用してデータの書式を設定します。言語、地域、文字の分類、書記体系、日付や時刻の書式設定、数値、通貨、重さ、並べ替えのルールに関する前提条件をコードに記述することを回避します。

| 推奨 | 説明 |
| ------------- | ----------- |
| 文字列を操作して比較するときには、カルチャを考慮する。 | たとえば、文字列を比較する前に、文字列の大文字と小文字を変更しないでください。 「[文字列の使用に関する推奨事項](/dotnet/standard/base-types/best-practices-strings?branch=live#recommendations_for_string_usage)」を参照してください。 |
| 文字列やその他のデータの照合 (並べ替え) を行うときは、常にアルファベット順に行われると想定しない。 | ラテン文字を使わない言語の場合、照合は発音またはペン ストロークの数などの要素に基づいて行われます。 ラテン文字を使う言語でも、常にアルファベット順の並べ替えを行うわけではありません。 たとえば、一部のカルチャでは電話帳はアルファベット順では並んでいない場合があります。 Windows によって並べ替えが自動的に行われますが、自分で独自の並べ替えアルゴリズムを作る場合は、必ず、アプリの対象市場で使われている並べ替え方法を考慮してください。 |
| 数値、日付、時刻、住所、電話番号を適切に書式設定する。 | これらの形式は、カルチャ、地域、言語、市場によって異なります。 これらのデータを表示する場合は、 [**グローバリゼーション**](/uwp/api/Windows.Globalization?branch=live) API を使って特定のユーザーに適した形式を取得します。 「[日付、時刻、数値の形式のグローバル化](use-global-ready-formats.md)」を参照してください。 姓名の表示順序と住所の形式も異なる場合があります。 標準の日付、時刻の表示と数値の表示を使います。 標準の DatePicker と TimePicker コントロールを使います。 標準のアドレス情報を使います。 |
| 国際的な計測単位と通貨をサポートする。 | 使われる単位と尺度は国によって異なりますが、最も使われているのはメートル法とヤード ポンド法です。 長さ、温度、範囲などの計測を扱う場合は、正しいシステム計測をサポートしてください。 [**GeographicRegion.CurrenciesInUse**](/uwp/api/windows.globalization.geographicregion.CurrenciesInUse) プロパティを使って、地域で使用されている通貨のセットを取得します。 |
| 文字エンコードに Unicode を使う。 | 既定では、Microsoft Visual Studio は、すべてのドキュメントに Unicode 文字エンコードを使います。 別のエディターを使っている場合は、適切な Unicode 文字エンコードでソース ファイルが保存されるようにしてください。 UWP API はどれも、UTF-16 エンコードの文字列を返します。 |
| 国際的な用紙サイズをサポートする。 | 最も一般的な用紙サイズは国によって異なるため、用紙サイズによって変化する機能 (印刷など) を含める場合には、必ず一般的な国際サイズをサポートし、テストしてください。 |
| キーボードまたは IME の言語を記録する。 | アプリがユーザーにテキスト入力を求めるときに、現在有効なキーボード レイアウトまたは入力方式エディター (IME) の言語タグが記録されるようにします。 こうすると、その入力が後で表示されるときに適切な書式設定でユーザーに提示されます。 現在の入力言語の取得には、[**Language.CurrentInputMethodLanguageTag**](/uwp/api/windows.globalization.language.CurrentInputMethodLanguageTag) プロパティを使います。 |
| 言語からユーザーの地域を想定する、または地域からユーザーの言語を想定することはしない。 | 言語と地域は別の概念です。 特定の地理的な言語バリアント (en-GB (英国で話される英語) など) を話しても、住んでいる国または地域はまったく異なる場合があります。 UI テキストなどのためにアプリがユーザーの言語について認識する必要があるか、ライセンスなどのためにアプリがユーザーの地域について認識する必要があるかを検討してください。 詳細については、「[ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)」を参照してください。 |
| 言語タグを比較するためのルールは重要となる。 | [BCP-47 言語タグ](http://go.microsoft.com/fwlink/p/?linkid=227302)は複雑です。 言語タグの比較では、スクリプト情報、前のタグ、複数の地域バリアントの対応付けに伴う問題など、多数の問題が発生します。 Windows のリソース管理システムでは、対応付けが自動的に行われます。 開発者はどの言語で作られたリソース セットでも指定でき、システムがユーザーとアプリのために適切なものを選びます。 「[アプリ リソースとリソース管理システム](../../app-resources/index.md)」および「[リソース管理システムでの言語タグの照合の仕組み](../../app-resources/how-rms-matches-lang-tags.md)」を参照してください。 |
| 異なるテキストの長さとフォント サイズがラベルとテキストの入力コントロールに対応するように UI を設計する。 | 異なる言語に翻訳された文字列は、長さが大きく異なる場合があるため、コンテンツに合わせて UI コントロールのサイズを動的に変更する必要があります。 他の言語には、通常のアルファベットの上や下に記号が付いている文字 (Å、Ņ など) があります。 標準的なフォント サイズと行の高さを使って、縦方向に十分なスペースを確保します。 言語のフォントによっては、フォントの最小サイズを大きくして読みやすさを維持する必要がある場合があります。 [Windows.Globalization.Fonts](/uwp/api/windows.globalization.fonts?branch=live) 名前空間のクラスを参照してください。 |
| 読み取り順序のミラーリングをサポートする。 | テキストの配置と読み取りは、英語のように左から右の順にも、アラビア語やヘブライ語のように右から左の順 (RTL) にも行うことができます。 読み取り順が自国語とは異なる言語に製品をローカライズする場合は、UI 要素のレイアウトが左右反転をサポートする必要があります。 戻るボタン、UI 切り替え効果、画像などのアイテムですら、左右反転が必要になることがあります。 詳細については、「[レイアウトやフォントの調整と RTL のサポート](adjust-layout-and-fonts--and-support-rtl.md)」を参照してください。 |
| テキストとフォントを正しく表示する。 | テキストに適したフォント、フォント サイズ、方向は、市場によって異なります。 詳細については、「[**レイアウトやフォントの調整と RTL のサポート**](adjust-layout-and-fonts--and-support-rtl.md)」および「[国際フォント](loc-international-fonts.md)」を参照してください。 |

## <a name="important-apis"></a>重要な API
 
* [Globalization](/uwp/api/Windows.Globalization?branch=live)
* [GeographicRegion.CurrenciesInUse](/uwp/api/windows.globalization.geographicregion.CurrenciesInUse)
* [Language.CurrentInputMethodLanguageTag](/uwp/api/windows.globalization.language.CurrentInputMethodLanguageTag)
* [Windows.Globalization.Fonts](/uwp/api/windows.globalization.fonts?branch=live)

## <a name="related-topics"></a>関連トピック

* [文字列の使用に関する推奨事項](/dotnet/standard/base-types/best-practices-strings?branch=live#recommendations_for_string_usage)
* [日付、時刻、数値の形式のグローバル化](use-global-ready-formats.md)
* [ユーザー プロファイルの言語とアプリ マニフェストの言語について](manage-language-and-region.md)
* [BCP-47 言語タグに関するページ](http://go.microsoft.com/fwlink/p/?linkid=227302)
* [アプリ リソースとリソース管理システム](../../app-resources/index.md)
* [リソース管理システムでの言語タグの照合の仕組み](../../app-resources/how-rms-matches-lang-tags.md)
* [レイアウトやフォントの調整と RTL のサポート](adjust-layout-and-fonts--and-support-rtl.md)
* [国際フォント](loc-international-fonts.md)
* [アプリをローカライズ可能にする](prepare-your-app-for-localization.md)

## <a name="samples"></a>サンプル

* [グローバリゼーション設定サンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231608)
