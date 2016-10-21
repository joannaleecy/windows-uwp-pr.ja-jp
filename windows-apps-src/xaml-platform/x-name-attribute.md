---
author: jwmsft
description: "コード ビハインドまたは一般的なコードからインスタンス化されたオブジェクトにアクセスするために、オブジェクト要素を一意に識別します。"
title: "xName 属性"
ms.assetid: 4FF1F3ED-903A-4305-B2BD-DCD29E0C9E6D
translationtype: Human Translation
ms.sourcegitcommit: ebda34ce4d9483ea72dec3bf620de41c98d7a9aa
ms.openlocfilehash: 1a70bffd6e6990ece4565b919846503b95ae8f61

---

# x:Name 属性

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

コード ビハインドまたは一般的なコードからインスタンス化されたオブジェクトにアクセスするために、オブジェクト要素を一意に識別します。 基になるプログラミング モデルに適用後の **x:Name** は、コンストラクターによって返されるオブジェクト参照を保持する変数と等価であると見なすことができます。

## XAML 属性の使用方法

``` syntax
<object x:Name="XAMLNameValue".../>
```

## XAML 値

| 用語 | 説明 |
|------|-------------|
| XAMLNameValue | XamlName の文法の制限に準拠する文字列。 |

##  XamlName の文法

XAML 実装でキーとして使われる文字列の規範となる文法を次に示します。

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
-   名前の先頭を数字にすることはできません。 一部のツールの実装では、ユーザーが数字を先頭文字として指定した場合、文字列の先頭にアンダースコア (\_) 文字が付加されます。または、ツールによって、数字が含まれる他の値に基づいて **x:Name** 値が自動生成されます。

## 注釈

指定した **x:Name** は、XAML が処理されるときに基になるコードで生成されるフィールドの名前となり、そのフィールドにオブジェクトへの参照が保持されます。 このフィールドの作成は、MSBuild ターゲットの手順で実行されます。この手順で、XAML ファイルの部分クラスとそのコード ビハインドも加えられます。 この動作は、必ずしも XAML 言語で指定されているわけではなく、XAML のユニバーサル Windows プラットフォーム (UWP) のプログラミング モデルやアプリケーション モデルで **x:Name** を使うために適用されている特別な実装です。

定義されている各 **x:Name** は、XAML 名前スコープ内で一意である必要があります。 XAML 名前スコープは一般に、読み込まれたページのルート要素レベルで定義され、1 つの XAML ページ内のルート要素の下にすべての要素が含まれます。 それ以外の XAML 名前スコープは、そのページで定義されているコントロール テンプレートやデータ テンプレートで定義されます。 実行時には、適用されたコントロール テンプレートから作成されるオブジェクト ツリーのルートにまた別の XAML 名前スコープが作成されます。この XAML 名前空間はほかにも、[**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048) の呼び出しで作成されるオブジェクト ツリーによっても作成されます。 詳しくは、「[XAML 名前スコープ](xaml-namescopes.md)」をご覧ください。

デザイン ツールでは、要素をデザイン サーフェイスに取り込むと要素の **x:Name** の値が自動生成されることがよくあります。 自動生成方式は使っているデザイナーによって異なりますが、一般的な方式では、要素をサポートするクラス名で始まり、その後に増加していく整数が続く文字列が生成されます。 たとえば、最初の [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) 要素をデザイナーに取り込むと、XAML ではこの要素の **x:Name** 属性の値が Button1 になります。

**x:Name** は、XAML プロパティ要素構文で設定することも、[**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) を使うコードで設定することもできません。 **x:Name** は、要素の XAML 属性構文を使うことでのみ設定できます。

**注:** 特に C++/CX アプリの場合、**x:Name** 参照のバッキング フィールドが、XAML ファイルまたはページのルート要素に対して作成されません。 C++ のコード ビハインドからルート オブジェクトを参照する必要がある場合は、他の API またはツリー走査を使ってください。 たとえば、既知の名前付き子要素に対して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出した後、[**Parent**](https://msdn.microsoft.com/library/windows/apps/br208739) を呼び出します。

### x:Name などの Name プロパティ

UWP XAML で使われる一部の型にも、**Name** という名前のプロパティがあります。 [**FrameworkElement.Name**](https://msdn.microsoft.com/library/windows/apps/br208735)、[**TextElement.Name**](https://msdn.microsoft.com/library/windows/apps/hh702125) などです。

要素で設定可能なプロパティとして **Name** が使用できる場合、XAML では **Name** と **x:Name** のどちらも使うことができますが、両方の属性を同じ要素で指定するとエラーが発生します。 また、**Name** プロパティがあるものの、読み取り専用であるという場合もあります ([**VisualState.Name**](https://msdn.microsoft.com/library/windows/apps/br209031) など)。 そのような場合には、XAML 内の要素に名前を付けるときには常に **x:Name** を使います。読み取り専用の **Name** は、それほど一般的ではないコードのシナリオのために存在します。

**注**  [**FrameworkElement.Name**](https://msdn.microsoft.com/library/windows/apps/br208735) は通常、**x:Name** で設定された値を変更するときには使いませんが、この原則の例外となるシナリオもあります。 一般的なシナリオでは、XAML 名前スコープの作成と定義は XAML プロセッサの操作です。 **FrameworkElement.Name** を実行時に変更すると、XAML 名前スコープとプライベート フィールドの名前付けの調整の整合性が損なわれ、コード ビハインドで追跡するのが難しくなる可能性があります。

### x:Name と x:Key

[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内の要素に属性として **x:Name** を適用すると、[x:Key 属性](x-key-attribute.md)の代わりとしての役割を果たします (**ResourceDictionary** 内のどの要素にも x:Key または x:Name 属性があるというのが規則です)。これは、[ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/mt187354)によく見られます。 詳しくは、「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」の各セクションをご覧ください。




<!--HONumber=Aug16_HO3-->


