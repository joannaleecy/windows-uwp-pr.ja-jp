---
author: jwmsft
description: "定義済みリソースへの参照を評価することで、任意の XAML 属性の値を提供します。 リソースは ResourceDictionary で定義されており、StaticResource の使用では ResourceDictionary 内のそのリソースのキーを参照します。"
title: "StaticResource マークアップ拡張"
ms.assetid: D50349B5-4588-4EBD-9458-75F629CCC395
translationtype: Human Translation
ms.sourcegitcommit: 98b9bca2528c041d2fdfc6a0adead321737932b4
ms.openlocfilehash: 3f486a8ac56e37a7401b9a87a4d560cac6b68f6f

---

# {StaticResource} マークアップ拡張

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

定義済みリソースへの参照を評価することで、任意の XAML 属性の値を提供します。 リソースは [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) で定義されており、**StaticResource** の使用では **ResourceDictionary** 内のそのリソースのキーを参照します。

## XAML 属性の使用方法

``` syntax
<object property="{StaticResource key}" .../>
```

## XAML 値

| 用語 | 説明 |
|------|-------------|
| key | 要求されたリソースのキー。 このキーは、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) によって最初に割当てられます。 リソース キーとしては、XamlName の文法で定義されている任意の文字列を使うことができます。 |

## 注釈

**StaticResource** は、XAML リソース ディクショナリ内の別の場所で定義されている XAML 属性の値を取得するための手法です。 値がリソース ディクショナリに格納される理由としては、複数のプロパティ値で共有されることや、XAML リソース ディクショナリが XAML パッケージングまたはファクタリング手法として使われることが挙げられます。 XAML パッケージング手法の例は、コントロールのテーマ ディクショナリです。 もう 1 つの例は、リソースのフォールバックに使われるマージされたリソース ディクショナリです。

**StaticResource** は、要求されたリソースについてキーを指定する 1 個の引数を受け取ります。 リソース キーは常に、Windows ランタイム XAML の文字列です。 リソース キーを最初に指定する方法について詳しくは、「[x:Key 属性](x-key-attribute.md)」をご覧ください。

**StaticResource** がリソース ディクショナリの項目に解決される規則は、このトピックでは説明していません。 そのような規則は、参照とリソースがいずれもテンプレートに存在するかどうかや、マージされたリソース ディクショナリを使うかどうかなどによって異なります。 リソースの定義方法と [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の適切な使用方法 (サンプル コードを含む) について詳しくは、「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。

**重要**  
**StaticResource** は、XAML ファイルの中で辞書的に定義されているリソースへの前方参照を行うことはできません。 そのようなことを試みることはサポートしていません。 前方参照が失敗しなかったとしても、そのようなことを試みるだけでパフォーマンスの低下を招きます。 最善の結果を得るには、前方参照を避けるようにリソース ディクショナリの構成を調整します。

解決できないキーに **StaticResource** を指定しようとすると、実行時に XAML の解析で例外が発生します。 デザイン ツールでも、警告やエラーが通知されることがあります。

Windows ランタイム XAML プロセッサの実装では、**StaticResource** 機能のバッキング クラス表現はありません。 **StaticResource** は、XAML マークアップでのみ使用できます。 コードで最も近いのは、[**Contains**](https://msdn.microsoft.com/library/windows/apps/jj635925) または [**TryGetValue**](https://msdn.microsoft.com/library/windows/apps/jj603139) を呼び出すなど、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) のコレクション API を使うことです。

[{ThemeResource} マークアップ拡張](themeresource-markup-extension.md)は、別の場所の名前付きリソースを参照する同様のマークアップ拡張です。 違いは、{ThemeResource} マークアップ拡張ではアクティブなシステム テーマに応じて異なるリソースを返すことができるという点です。 詳しくは、「[{ThemeResource} マークアップ拡張](themeresource-markup-extension.md)」をご覧ください。

**StaticResource** は、マークアップ拡張です。 通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。 XAML のすべてのマークアップ拡張では、それぞれの属性構文で "\{" と "\}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。

### {StaticResource} の使用例

この XAML 例は、[XAML データ バインディング サンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=226854)から抜粋したものです。

```xml
<StackPanel Margin="5">
    <!-- Add converter as a resource to reference it from a Binding. --> 
    <StackPanel.Resources>
        <local:S2Formatter x:Key="GradeConverter"/>
    </StackPanel.Resources>
    <TextBlock Style="{StaticResource BasicTextStyle}" Text="Percent grade:" Margin="5" />
    <Slider x:Name="sliderValueConverter" Minimum="1" Maximum="100" Value="70" Margin="5"/>
    <TextBlock Style="{StaticResource BasicTextStyle}" Text="Letter grade:" Margin="5"/>
    <TextBox x:Name="tbValueConverterDataBound"
      Text="{Binding ElementName=sliderValueConverter, Path=Value, Mode=OneWay,  
        Converter={StaticResource GradeConverter}}" Margin="5" Width="150"/> 
</StackPanel> 
```

この例では、カスタム クラスによってサポートされるオブジェクトを、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) のリソースとして作成しています。 有効なリソースにするには、ほかにも、この `local:S2Formatter` 要素に **x:Key** 属性値が必要です。 属性値は "GradeConverter" に設定されます。

XAML でもう少し先に進むと、リソースが要求されています。`{StaticResource GradeConverter}` というところです。

{StaticResource} マークアップ拡張を使って、別のマークアップ拡張 [{Binding} マークアップ拡張](binding-markup-extension.md)のプロパティを設定していることに注意してください。つまり、ここではマークアップ拡張が 2 つ、入れ子構造で使われています。 内側のものが最初に評価されます。このため、リソースが取得された後、値として使われます。 これと同じ例は、「{Binding} マークアップ拡張」にも記載してあります。

## 設計時ツールの **{StaticResource}** マークアップ拡張のサポート

Microsoft Visual Studio 2013 では、XAML ページで **{StaticResource}** マークアップ拡張を使うときに Microsoft IntelliSense のドロップダウンに可能なキー値を含めることができます。 たとえば、"{StaticResource" と入力するとすぐに、現在の検索範囲のリソース キーが IntelliSense のドロップダウンに表示されます。 ページ レベル ([**FrameworkElement.Resources**](https://msdn.microsoft.com/library/windows/apps/br208740)) とアプリ レベル ([**Application.Resources**](https://msdn.microsoft.com/library/windows/apps/br242338)) で持つ一般的なリソースに加えて、[XAML テーマ リソース](https://msdn.microsoft.com/library/windows/apps/mt187274)と、プロジェクトで使っている拡張機能のリソースも表示されます。

**{StaticResource}** の一部としてリソース キーが存在すると、**[定義へ移動]** (F12 キー) 機能でそのリソースを解決して、リソースが定義されているディクショナリを表示できます。 テーマ リソースの場合は、設計時の generic.xaml に移動します。

## 関連トピック

* [ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)
* [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794)
* [x:Key 属性](x-key-attribute.md)
* [{ThemeResource} マークアップ拡張](themeresource-markup-extension.md)




<!--HONumber=Jun16_HO4-->


