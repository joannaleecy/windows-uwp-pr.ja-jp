---
author: jwmsft
description: Binding マークアップ拡張は、XAML の読み込み時に Binding クラスのインスタンスに変換されます。
title: Binding マークアップ拡張
ms.assetid: 3BAFE7B5-AF33-487F-9AD5-BEAFD65D04C3
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9f90821fdadea0939dbad316ad9be4424b31a926
ms.sourcegitcommit: d780e3a087ab5240ea643346480a1427bea9e29b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/09/2018
ms.locfileid: "1573049"
---
# <a name="binding-markup-extension"></a>{Binding} マークアップ拡張


**注:** Windows 10 では、パフォーマンスと開発者の生産性向上のために最適化された新しいバインド メカニズムが利用できます。 「[{x:Bind} マークアップ拡張](x-bind-markup-extension.md)」をご覧ください。

**注:** **{Binding}** によりアプリでデータ バインディングを使う方法に関する一般的な情報 (および **{x:Bind}** と **{Binding}** の全体的な比較) については、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください。

**{Binding}** マークアップ拡張は、コントロールのプロパティをコードなどのデータ ソースの値にデータ バインドするために使われます。 **{Binding}** マークアップ拡張は、XAML の読み込み時に [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) クラスのインスタンスに変換されます。 このバインド オブジェクトは、データ ソースのプロパティから値を取得し、その値をコントロールのプロパティにプッシュします。 必要な場合、バインディング オブジェクトは、データ ソース プロパティの値の変化を監視し、その変化に基づいて自分自身を更新するように構成できます。 また、そのコントロールの値の変化をソース プロパティにプッシュするように構成することもできます。 データ バインディングのターゲットとなるプロパティは、依存関係プロパティである必要があります。 詳しくは、「[依存関係プロパティの概要](dependency-properties-overview.md)」をご覧ください。

**{Binding}** には、ローカル値と同じ依存関係プロパティの優先順位があります。命令型コードにローカル値を設定すると、マークアップに設定されたすべての **{Binding}** の影響がなくなります。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法


``` syntax
<object property="{Binding}" .../>
-or-
<object property="{Binding propertyPath}" .../>
-or-
<object property="{Binding bindingProperties}" .../>
-or-
<object property="{Binding propertyPath, bindingProperties}" .../>
```

| 用語 | 説明 |
|------|-------------|
| *propertyPath* | バインドのプロパティ パスを指定する文字列。 詳しくは、以下の「[プロパティ パス](#property-path)」をご覧ください。 |
| *bindingProperties* | *propName*=*value*\[, *propName*=*value*\]*<br/>名前と値のペアの構文を使って指定する、1 つ以上のバインド プロパティ。 |
| *propName* | [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) オブジェクトで設定するプロパティの文字列名。 たとえば、"Converter" です。 |
| *value* | プロパティに設定する値。 引数の構文は、下記の「[{Binding} で設定できる Binding クラスのプロパティ](#properties-of-the-binding-class-that-can-be-set-with-binding)」セクションで示しているプロパティによって異なります。 |

## <a name="property-path"></a>プロパティ パス

[**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) は、バインド先のプロパティ (ソース プロパティ) を表します。 Path は位置パラメーターであるため、パラメーター名を明示的に使用する (`{Binding Path=EmployeeID}`) ことも、最初の無名パラメーターとして指定する (`{Binding EmployeeID}`) こともできます。

[**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) の型はプロパティ パスであり、この文字列は、カスタム型または framework 型のプロパティまたはサブプロパティに評価されます。 型は [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) にすることができますが、そうしなければならないわけではありません。 プロパティ パスのステップは、ドット (.) で区切ります。複数の区切り記号を指定することで、連続するサブプロパティを走査できます。 バインドされているオブジェクトを実装するために使用するプログラミング言語に関係なく、ドット区切り記号を使います。

たとえば、UI を従業員オブジェクトの名プロパティにバインドする場合、プロパティ パスは "Employee.FirstName" のようになります。 従業員の扶養家族を含むプロパティに項目コントロールをバインドする場合、プロパティ パスは "Employee.Dependents" となり、"Dependents" の項目の表示には項目コントロールの項目テンプレートが使われます。

データ ソースがコレクションである場合、プロパティ パスには、位置またはインデックスによりコレクション内の項目を指定できます。 たとえば "Teams\[0\].Players" の場合、"0" をリテラル "\[\]" で囲むことで、コレクション内の最初の項目が指定されます。

既にある [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) への [**ElementName**](https://msdn.microsoft.com/library/windows/apps/br209828) バインドを使う場合は、プロパティ パスの一部として添付プロパティを使うことができます。 添付プロパティの名前に含まれるドットがプロパティ パスへのステップとは見なされないように、添付プロパティを明確に示すには、所有者で修飾された添付プロパティの名前を、`(AutomationProperties.Name)` のようにかっこで囲みます。

プロパティ パスの中間オブジェクトは、実行時の形式で [**PropertyPath**](https://msdn.microsoft.com/library/windows/apps/br244259) オブジェクトとして格納されますが、ほとんどのシナリオでは、コードで **PropertyPath** オブジェクトを操作する必要はありません。 通常、XAML を使って必要なバインド情報を指定できます。

プロパティ パスの文字列の構文、アニメーション機能領域のプロパティ パス、[**PropertyPath**](https://msdn.microsoft.com/library/windows/apps/br244259) オブジェクトの作成について詳しくは、「[プロパティ パス構文](property-path-syntax.md)」をご覧ください。

## <a name="properties-of-the-binding-class-that-can-be-set-with-binding"></a>{Binding} で設定できる Binding クラスのプロパティ


**{Binding}** は、*bindingProperties* プレースホルダー構文で示されます。これは、マークアップ拡張で設定可能な [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) の読み取り/書き込みプロパティが複数あるためです。 プロパティは、*propName*=*value* ペアをコンマで区切ることにより、任意の順序で設定できます。 プロパティによっては、型変換をサポートしていない型が必要なものがあります。そのため、これらのプロパティでは、**{Binding}** 内で入れ子にされた独自のマークアップ拡張が必要です。

| プロパティ | 説明 |
|----------|-------------|
| [**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) | 上記の「[プロパティ パス](#property-path)」をご覧ください。 |
| [**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) | バインド エンジンによって呼び出されるコンバーター オブジェクトを指定します。 コンバーターは、[{StaticResource} マークアップ拡張](staticresource-markup-extension.md)を使ってリソース ディクショナリのそのオブジェクトを参照するマークアップで設定できます。 |
| [**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/hh701880) | コンバーターで使うカルチャを指定します  ([**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) を設定する場合)。カルチャは、標準ベースの識別子として設定できます。 詳しくは、「[**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/hh701880)」をご覧ください。 |
| [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/br209827) | コンバーター ロジックで使うことができるコンバーター パラメーターを指定します  ([**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) を設定する場合)。ほとんどのコンバーターは、渡された値から変換に必要なすべての情報を取得するという単純なロジックを使っており、**ConverterParameter** 値を必要としません。 **ConverterParameter** パラメーターは、**ConverterParameter** で渡された値を利用する条件付きロジックを持つ、より複雑なコンバーターを実装するために存在します。 また、文字列以外の値を使うコンバーターも作成できますが、一般的ではありません。詳しくは、「**ConverterParameter**」の「注釈」をご覧ください。 |
| [**ElementName**](https://msdn.microsoft.com/library/windows/apps/br209828) | **Name** プロパティまたは [x:Name 属性](x-name-attribute.md) がある別の要素を同じ XAML コンストラクトで参照して、データ ソースを指定します。 通常は、関連する値を共有するか、1 つの UI 要素のサブプロパティを使って別の要素の特定の値を指定するために使われます (XAML コントロール テンプレートなどで)。 |
| [**FallbackValue**](https://msdn.microsoft.com/library/windows/apps/dn279345) | ソースまたはパスを解決できない場合に表示する値を指定します。 |
| [**Mode**](https://msdn.microsoft.com/library/windows/apps/br209829) | バインド モードを、"OneTime"、"OneWay"、"TwoWay" のいずれかの値で指定します。 これらは、[**BindingMode**](https://msdn.microsoft.com/library/windows/apps/br209822) 列挙体の定数名に対応します。 既定は "OneWay" です。 これは、**{x:Bind}** の既定値 (OneTime) とは異なる点に注意してください。 | 
| [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831) | バインディング ターゲットの位置に対するバインド ソースの位置を記述することで、データ ソースを指定します。 これは、XAML コントロール テンプレート内のバインドで最もよく使われます。 [{RelativeSource} マークアップ拡張](relativesource-markup-extension.md) を設定します。 |
| [**Source**](https://msdn.microsoft.com/library/windows/apps/br209832) | オブジェクトのデータ ソースを指定します。 **Binding** マークアップ拡張では、[**Source**](https://msdn.microsoft.com/library/windows/apps/br209832) プロパティに [{StaticResource} マークアップ拡張](staticresource-markup-extension.md)参照などのオブジェクト参照を指定する必要があります。 このプロパティを指定しない場合、実行中のデータ コンテキストによりソースが指定されます。 個々のバインドで Source 値を指定する代わりに、複数のバインドで共有 **DataContext** を利用する方が一般的です。 詳しくは、「[**DataContext**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.datacontext.aspx)」または「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」を参照してください。 |
| [**TargetNullValue**](https://msdn.microsoft.com/library/windows/apps/dn279347) | ソース値が解決されるが、明示的に **null** である場合に表示する値を設定します。 |
| [**UpdateSourceTrigger**](https://msdn.microsoft.com/library/windows/apps/dn279350) | バインド ソースの更新のタイミングを指定します。 指定されていない場合は、既定値は **Default** です。 |

**注:** マークアップを **{x:Bind}** から **{Binding}** に変換する場合は、**Mode** プロパティの既定値の違いに注意してください。

[**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826)、[**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/hh701880)、**ConverterLanguage** はいずれも、バインド ソースの値または型を、バインディング ターゲットのプロパティと互換性のある型または値に変換するシナリオに関係があります。 例や詳しい情報については、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」の「データの変換」をご覧ください。

> [!NOTE]
> Windows 10、バージョン1607 以降では、XAML フレームワークにブール値と Visibility 値のコンバーターが組み込まれています。 コンバーターは、**Visible** 列挙値に対して **true** を、**Collapsed** に対して **false** をマッピングします。これにより、コンバーターを作成せずに Visibility プロパティをブール値にバインドできます。 組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。 アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。 ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。

[**Source**](https://msdn.microsoft.com/library/windows/apps/br209832)、[**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831)、[**ElementName**](https://msdn.microsoft.com/library/windows/apps/br209828) では、バインド ソースを指定します。そのため、これらは相互に排他的です。

**ヒント:** [**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) や [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/br209827) のように、値に 1 つの中かっこを指定する必要がある場合は、`\{` のように円記号 (バックスラッシュ) を中かっこの前に付けます。 別の方法として、エスケープする必要がある中かっこを含む文字列全体を `ConverterParameter='{Mix}'` のように別の種類の引用符で囲みます。

## <a name="examples"></a>例

```XML
<!-- binding a UI element to a view model -->    
<Page ... >
    <Page.DataContext>
        <local:BookstoreViewModel/>
    </Page.DataContext>

    <GridView ItemsSource="{Binding BookSkus}" SelectedItem="{Binding SelectedBookSku, Mode=TwoWay}" ... />
</Page>
```

```XML
<!-- binding a UI element to another UI element -->
<Page ... >
    <Page.Resources>
        <local:S2Formatter x:Key="GradeConverter"/>
    </Page.Resources>

    <Slider x:Name="sliderValueConverter" ... />
    <TextBox Text="{Binding Path=Value, ElementName=sliderValueConverter,
        Mode=OneWay,
        Converter={StaticResource GradeConverter}}"/>
</Page>
```

2 番目の例では、[**ElementName**](https://msdn.microsoft.com/library/windows/apps/br209828)、[**Path**](https://msdn.microsoft.com/library/windows/apps/br209830)、[**Mode**](https://msdn.microsoft.com/library/windows/apps/br209829)、[**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) の 4 種類の [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) プロパティを設定します。 **Path** はここで、**Binding** プロパティであることが明示的に示された状態で表示されています。 **Path** は、データ バインド ソースに評価されます。このデータ バインド ソースは、同じランタイム オブジェクト ツリーにある別のオブジェクト、具体的には `sliderValueConverter` という名前の [**Slider**](https://msdn.microsoft.com/library/windows/apps/br209614) です。

[**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) プロパティの値が別のマークアップ拡張 [{StaticResource} マークアップ拡張](staticresource-markup-extension.md) を使っていることに注意してください。つまり、ここでは入れ子になったマークアップ拡張が 2 つ使われています。 内側のものが最初に評価されます。このため、リソースが取得されると、バインドに使える実用的な [**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/br209903) (リソースの `local:S2Formatter` 要素によってインスタンス化されるカスタム クラス) が存在することになります。

## <a name="tools-support"></a>ツールのサポート

Microsoft Visual Studio の Microsoft IntelliSense では、XAML マークアップ エディターで **{Binding}** を作成している間、データ コンテキストのプロパティが表示されます。 「{Binding」と入力するとすぐに、[**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) に適したデータ コンテキスト プロパティがドロップダウンに表示されます。 IntelliSense は、[**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) の他のプロパティに関しても役立ちます。 これが機能するためには、マークアップ ページにデータ コンテキストまたは設計時のデータ コンテキストを設定する必要があります。 **[定義へ移動]** (F12) は、**{Binding}** でも機能します。 または、データ バインディングのダイアログを使うこともできます。

 
