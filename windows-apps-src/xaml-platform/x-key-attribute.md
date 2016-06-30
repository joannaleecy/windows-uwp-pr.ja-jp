---
author: jwmsft
description: "リソースとして作成、参照され、ResourceDictionary 内に存在する要素を一意に識別します。"
title: "xKey 属性"
ms.assetid: 141FC5AF-80EE-4401-8A1B-17CB22C2277A
translationtype: Human Translation
ms.sourcegitcommit: ba620bc89265cbe8756947e1531759103c3cafef
ms.openlocfilehash: 00d801dc3ebb8894f8e21ba0c1b9f3aecc981f30

---

# x:Key 属性

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

リソースとして作成、参照され、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内に存在する要素を一意に識別します。

## XAML 属性の使用方法

``` syntax
<ResourceDictionary>
  <object x:Key="stringKeyValue".../>
</ResourceDictionary>
```

## XAML 属性の使用方法 (暗黙的な **ResourceDictionary**)

``` syntax
<object.Resources>
  <object x:Key="stringKeyValue".../>
</object.Resources>
```

## XAML 値

| 用語 | 説明 |
|------|-------------|
| object | 共有可能な任意のオブジェクト。 「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。 |
| stringKeyValue | _XamlName_> の文法に準拠する必要がある、キーとして使われる実際の文字列。 以下の「XamlName の文法」をご覧ください。 | 

##  XamlName の文法

ユニバーサル Windows プラットフォーム (UWP) の XAML 実装でキーとして使われる文字列の規範となる文法を次に示します。

``` syntax
XamlName ::= NameStartChar (NameChar)*
NameStartChar ::= LetterCharacter | '_'
NameChar ::= NameStartChar | DecimalDigit
LetterCharacter ::= ('a'-'z') | ('A'-'Z')
DecimalDigit ::= '0'-'9'
CombiningCharacter::= none
```

-   文字は下位の ASCII の範囲 (具体的には、英文字の大文字と小文字、数字、アンダースコア (\_) 文字) に制限されています。
-   Unicode 文字範囲はサポートされていません。
-   名前の先頭を数字にすることはできません。

## 注釈

通常、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の子要素は、そのディクショナリ内の一意のキー値を指定する **x:Key** 属性を含みます。 キーは、読み込み時に XAML プロセッサによって一意であることが要求されます。 **x:Key** 値が一意でない場合は、XAML の解析で例外が発生します。 [{StaticResource} マークアップ拡張](staticresource-markup-extension.md)によって要求された場合、解決されていないキーも XAML の解析での例外の原因になります。

**x:Key** と [x:Name](x-name-attribute.md) は同じ概念ではありません。 **x:Key** はリソース ディクショナリだけで使われます。 x:Name は、すべての XAML 領域で使われます。 キー値を使って [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出した場合、キーを持つリソースは取得されません。

ここに示す暗黙的な構文において、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) オブジェクトは XAML プロセッサが [**Resources**](https://msdn.microsoft.com/library/windows/apps/br208740) コレクションを取得するための新しいオブジェクトを生成する方法を暗黙的に決定することに注意してください。

**x:Key** の指定に相当するコードは、基になる [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) でキーを使う任意の操作です。 たとえば、あるリソースのマークアップで適用される **x:Key** は、リソースを **ResourceDictionary** に追加するときの **Insert** の *key* パラメーターの値と同じです。

リソース ディクショナリ内の項目は、ターゲットとなる [**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) または [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) である場合、**x:Key** の値を省略できます。どちらの場合も、リソース項目の暗黙的なキーは、文字列として解釈される **TargetType** 値です。 詳しくは、「[クイック スタート: コントロールのスタイル (JavaScript と HTML を使った Windows ストア アプリ)](https://msdn.microsoft.com/library/windows/apps/hh465498)」と「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。




<!--HONumber=Jun16_HO4-->


