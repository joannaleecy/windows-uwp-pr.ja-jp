---
author: jwmsft
description: "xBind マークアップ拡張は Binding の代わりです。 xBind では、Binding の機能のいくつかが省略されていますが、Binding よりも短い時間および少ないメモリで動作し、より適切なデバッグをサポートしています。"
title: "xBind マークアップ拡張"
ms.assetid: 529FBEB5-E589-486F-A204-B310ACDC5C06
translationtype: Human Translation
ms.sourcegitcommit: 0f9955b897c626e7f6abb5557658e1b1e5937ffd
ms.openlocfilehash: 7380386a77338c1fce7a7184b558a06605ffdf33

---

# {x:Bind} マークアップ拡張

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

**注**  **{x:Bind}** によりアプリでデータ バインディングを使う方法に関する一般的な情報 (および **{x:Bind}** と **{Binding}** の全体的な比較) については、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください。

Windows 10 では、**{Binding}** に代わり、**{x:Bind}** マークアップ拡張が新たに提供されています。 **{x:Bind}** では、**{Binding}** の機能のいくつかが省略されていますが、**{Binding}** よりも短い時間および少ないメモリで動作し、より適切なデバッグをサポートしています。

XAML のコンパイル時に、**{x:Bind}** は、データ ソースのプロパティから値を取得してマークアップで指定されたプロパティに設定するコードに変換されます。 必要な場合、バインディング オブジェクトは、データ ソース プロパティの値の変化を監視し、その変化に基づいて自分自身を更新するように構成できます。 また、その独自の値の変化をソース プロパティにプッシュするように構成することもできます。 **{x:Bind}** と **{Binding}** によって作成されたバインディング オブジェクトは、ほとんど機能的に同等です。 ただし、**{x:Bind}** は、コンパイル時に生成される特定用途のコードを実行し、**{Binding}** は、汎用的なランタイム オブジェクト検査を実行します。 したがって、**{x:Bind}** バインディング (多くの場合、コンパイル済みバインドと呼ばれます) はパフォーマンスが高く、コンパイル時にバインド式を検証したり、ページの部分クラスとして生成されたコード ファイル内にブレークポイントを設定し、デバッグを行ったりできます。 これらのファイルは `obj` フォルダー内にあり、`<view name>.g.cs` (C# の場合) などの名前が付けられています。

**{x:Bind} の使い方を示すサンプル アプリ**

-   [{x:Bind} のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619989)
-   [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame)
-   [XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619992)

## XAML 属性の使用方法

``` syntax
<object property="{x:Bind}" .../>
-or-
<object property="{x:Bind propertyPath}" .../>
-or-
<object property="{x:Bind bindingProperties}" .../>
-or-
<object property="{x:Bind propertyPath, bindingProperties}" .../>
```

| 用語 | 説明 |
|------|-------------|
| _propertyPath_ | バインドのプロパティ パスを指定する文字列。 詳しくは、以下の「[プロパティ パス](#property-path)」をご覧ください。 |
| _bindingProperties_ |
| _propName_=_value_\[, _propName_=_value_\]* | 名前と値のペアの構文を使って指定する、1 つ以上のバインド プロパティ。 |
| _propName_ | Binding オブジェクトで設定するプロパティの文字列名。 たとえば、"Converter" です。 |
| _value_ | プロパティに設定する値。 引数の構文は、設定されているプロパティによって異なります。 値がそれ自体マークアップ拡張である _propName_=_value_ の使用例を示します: `Converter={StaticResource myConverterClass}`。 詳しくは、以下の「[{x:Bind} で設定できるプロパティ](#properties-you-can-set)」をご覧ください。 | 

## プロパティ パス

*PropertyPath* は **{x:Bind}** 式の **Path** です。 **Path** は、バインディング先のプロパティ、サブプロパティ、フィールド、またはメソッドの値 (ソース) を指定するプロパティ パスです。 **Path** プロパティの名前は、`{Binding Path=...}` のように明示的に指定することができます。 または、`{Binding ...}` のように省略することもできます。

### プロパティのパスの解決

**{x:Bind}** は、既定のソースとして **DataContext** を使わず、代わりにページまたはユーザー コントロール自体を使います。 したがって、ページまたはユーザー コントロールのコード ビハインドでプロパティ、フィールド、およびメソッドが検索されます。 通常、ビュー モデルを **{x:Bind}** に公開するには、ページまたはユーザー コントロールのコード ビハインドに新しいフィールドまたはプロパティを追加する必要があります。 プロパティ パスのステップは、ドット (.) で区切ります。複数の区切り記号を指定することで、連続するサブプロパティを走査できます。 バインドされているオブジェクトを実装するために使用するプログラミング言語に関係なく、ドット区切り記号を使います。

たとえば、あるページで、**Text="{x:Bind Employee.FirstName}"** を指定すると、そのページの **Employee** メンバーが検索され、次に、**Employee** が返したオブジェクトの **FirstName** メンバーが検索されます。 従業員の扶養家族を含むプロパティに項目コントロールをバインドする場合、プロパティ パスは "Employee.Dependents" となり、"Dependents" の項目の表示には項目コントロールの項目テンプレートが使われます。

C++/CX の場合、**{x:Bind}** はページまたはデータ モデルのプライベート フィールドおよびプロパティにバインドできません。バインドできるようにするには、パブリック プロパティが必要です。 バインディング用のサーフェス領域を CX クラス/インターフェイスとして公開し、関連するメタデータを取得できるようにする必要があります。 **\[Bindable\]** 属性は必要ありません。

**x:Bind** では、**ElementName=xxx** をバインド式の一部として使用する必要はありません。 **x:Bind** では、要素の名前をバインディングのパスの先頭部分として使用できません。これは、名前付き要素が、ルート バインディング ソースを表すページまたはユーザー コントロール内のフィールドになるためです。

### コレクション

データ ソースがコレクションである場合、プロパティ パスには、位置またはインデックスによりコレクション内の項目を指定できます。 たとえば "Teams\[0\].Players" の場合、"0" をリテラル "\[\]" で囲むことで、インデックス 0 で始まるコレクション内の最初の項目を要求します。

インデクサーを使うには、インデックス化されるプロパティの型に基づいて、モデルで **IList&lt;T&gt;** または **IVector&lt;T&gt;** を実装する必要があります。 インデックス付きプロパティの型が **INotifyCollectionChanged** または **IObservableVector** をサポートしており、バインディングが OneWay または TwoWay の場合、そのプロパティは登録され、それらのインターフェイスで変更通知をリッスンします。 変更検出ロジックは、特定のインデックス付きの値に影響を与えない場合でも、すべてのコレクションの変更に基づいて更新されます。 これは、リッスンしているロジックがコレクションのすべてのインスタンス間で共通であるためです。

データ ソースがディクショナリまたはマップである場合、プロパティ パスには、文字列名によりコレクション内の項目を指定できます。 たとえば、**&lt;TextBlock Text="{x:Bind Players\['John Smith'\]" /&gt;** は、ディクショナリで "John Smith" という名前の項目を検索します。 名前は引用符で囲む必要があり、単一引用符と二重引用符のどちらでも使用できます。 文字列で引用符をエスケープするにはハット (^) を使用できます。 XAML 属性に使用されるものから代替引用符を使用するのが最も簡単です。

文字列インデクサーを使うには、インデックス化されるプロパティの型に基づいて、モデルで **IDictionary&lt;string, T&gt;** または **IMap&lt;string, T&gt;** を実装する必要があります。 インデックス付きプロパティの型が **IObservableMap** をサポートしており、バインディングが OneWay または TwoWay の場合、そのプロパティは登録され、それらのインターフェイスで変更通知をリッスンします。 変更検出ロジックは、特定のインデックス付きの値に影響を与えない場合でも、すべてのコレクションの変更に基づいて更新されます。 これは、リッスンしているロジックがコレクションのすべてのインスタンス間で共通であるためです。

### 添付プロパティ

添付プロパティにバインドするには、クラスおよびプロパティ名をドットの後のかっこ内に含める必要があります。 たとえば、**Text="{x:Bind Button22.(Grid.Row)}"** などです。 プロパティが Xaml 名前空間で宣言されていない場合は、そのプロパティの前に xml 名前空間を付ける必要があります。これはドキュメントの先頭でコード名前空間にマップする必要があります。

### キャスト

コンパイル済みのバインドは、厳密に型指定され、パスの各ステップの型を解決します。 返される型にメンバーがない場合は、コンパイル時に失敗します。 キャストを指定して、オブジェクトの実際の型をバインディングに通知することができます。 次の場合、**obj** は型オブジェクトのプロパティですが、テキスト ボックスを含んでいます。したがって、**Text="{x:Bind ((TextBox)obj).Text}"** または **Text="{x:Bind obj.(TextBox.Text)}"** を使用できます。
groups3 field in **Text="{x:Bind ((data:SampleDataGroup)groups3\[0\]).Title}"** の **groups3** フィールドは、オブジェクトのディクショナリです。したがって、**data:SampleDataGroup** にキャストする必要があります。 既定の XAML 名前空間の一部ではないコード名前空間にオブジェクトの型をマップするための xml **data:** 名前空間のプレフィックスの使用法に注意してください。

_注: C# スタイルのキャスト構文は添付プロパティ構文より柔軟であり、今後はこの構文が推奨されます。_

## バインディング パス内の関数

Windows 10 バージョン 1607 以降、**{x:Bind}** はバインド パスのリーフ ステップとしての関数の使用をサポートします。 これにより次のことが可能になります。
- 値の変換を実現するためのより簡単な方法
- 複数のパラメーターに依存するようにバインディングする方法

> [!NOTE]
> **{x:Bind}** で関数を使うには、アプリの対象が SDK バージョン 14393 以降である必要があります。 アプリがそれよりも前のバージョンの Windows 10 を対象としている場合は、関数を使えません。 ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。

次の例では、項目の背景と前景が、Color パラメーターに基づいて変換を行うために関数にバインドされています。

``` Xamlmarkup
<DataTemplate x:DataType="local:ColorEntry">
    <Grid Background="{x:Bind Brushify(Color)}" Width="240">
        <TextBlock Text="{x:Bind ColorName}" Foreground="{x:Bind TextColor(Color)}" Margin="10,5" />
    </Grid>
</DataTemplate>
```
``` C#
class ColorEntry
{
    public string ColorName { get; set; }
    public Color Color { get; set; }

    public static SolidColorBrush Brushify(Color c)
    {
        return new SolidColorBrush(c);
    }

    public static SolidColorBrush TextColor(Color c)
    {
        return new SolidColorBrush(((c.R * 0.299 + c.G * 0.587 + c.B * 0.114) > 150) ? Colors.Black : Colors.White);
    }
}

```
### 関数の構文
``` Syntax
Text="{x:Bind MyModel.Order.CalculateShipping(MyModel.Order.Weight, MyModel.Order.ShipAddr.Zip, 'Contoso'), Mode=OneTime}"
             |      Path to function         |    Path argument   |       Path argument       | Const arg |  Bind Props
```

### 関数へのパス
関数へのパスは、他のプロパティ パスと同じように指定され、関数を見つけるためにドット (.)、インデクサー、またはキャストを含めることができます。

静的関数は、XMLNamespace:ClassName.MethodName 構文を使って指定できます。 たとえば、ページの先頭で **xmlns:sys="using:System"** が指定されているものとすると、**&lt;CalendarDatePicker Date="\{x:Bind sys:DateTime.Parse(TextBlock1.Text)\}" /&gt;** は DateTime.Parse 関数にマップします。

モードが OneWay/TwoWay である場合、関数のパスでは変更の検出が実行され、それらのオブジェクトに変更があるとバインディングが再評価されます。

バインディングされる関数には以下のことが要求されます。
- コードとメタデータにアクセスできる必要があります。したがって、C# では internal/private を使用できますが、C++/CX ではメソッドをパブリック WinRT メソッドにする必要があります。
- オーバーロードは引数の型ではなく数に基づき、同じ数の引数を持つ最初のオーバーロードとの一致が試みられます。
- 引数の型は渡されるデータと一致する必要があります。縮小変換は行われません。
- 関数の戻り値の型は、バインディングを使用しているプロパティの型と一致する必要があります。


### 関数の引数
複数の関数引数をコンマ (,) で区切って指定できます。
- バインディング パス – そのオブジェクトにバインドする場合と同じ構文です。
  - モードが OneWay/TwoWay の場合は、変更検出が実行されて、オブジェクトが変化するとバインディングが再評価されます。
- 引用符で囲まれた定数文字列 – 文字列として指定するには引用符が必要です。 文字列で引用符をエスケープするにはハット (^) を使用できます
- 定数 - たとえば -123.456
- ブール値 – "x:True" または "x:False" と指定します

### 双方向の関数バインド
双方向のバインディング シナリオでは、逆方向のバインドのために第 2 の関数を指定する必要があります。 これは、**BindBack** バインド プロパティを使って行います (例: **Text="\{x:Bind a.MyFunc(b), BindBack=a.MyFunc2\}"**)。 関数が受け取る必要のある引数は 1 つで、モデルにプッシュバックする必要のある値です。

## イベント バインディング

イベント バインディングは、コンパイル済みのバインドの固有の機能です。 これにより、バインディングを使用するイベントのハンドラーを指定でき、それをコード ビハインドのメソッドにする必要はありません。 たとえば、**Click="{x:Bind rootFrame.GoForward}"** などです。

イベントの場合、対象のメソッドをオーバーロードしてはならず、以下の条件も満たしている必要があります。

-   イベントのシグネチャが一致している。
-   または、パラメーターを持たない。
-   または、イベント パラメーターの型から割り当て可能な型のパラメーターを同じ数だけ持つ。

生成されたコード ビハインドでは、コンパイル済みのバインドは、イベントを処理してモデルのメソッドにルーティングします。また、イベントが発生すると、バインド式のパスを評価します。 つまり、プロパティ バインディングとは異なり、モデルの変更を追跡しません。

プロパティ パスの文字列構文について詳しくは、ここで説明した **{x:Bind}** に対する違いに注意して、「[プロパティ パス構文](property-path-syntax.md)」をご覧ください。

##   {x:Bind} で設定できるプロパティ


**{x:Bind}** は、*bindingProperties* プレースホルダー構文で示されます。これは、マークアップ拡張で設定可能な読み取り/書き込みプロパティが複数あるためです。 プロパティは、*propName*=*value* ペアをコンマで区切ることにより、任意の順序で設定できます。 バインド式に改行を含めることはできないことに注意してください。 プロパティによっては、型変換をサポートしていない型が必要なものがあります。そのため、これらのプロパティでは、**{x:Bind}** 内で入れ子にされた独自のマークアップ拡張が必要です。

これらのプロパティは、[**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) クラスのプロパティとほぼ同じように機能します。

| プロパティ | 説明 |
|----------|-------------|
| **Path** | 上記の「[プロパティ パス](#property-path)」をご覧ください。 |
| **Converter** | バインド エンジンによって呼び出されるコンバーター オブジェクトを指定します。 コンバーターは XAML で設定できますが、リソース ディクショナリ内のオブジェクトへの [{StaticResource} マークアップ拡張](staticresource-markup-extension.md) 参照で割り当てたオブジェクト インスタンスを参照する場合に限られます。 |
| **ConverterLanguage** | コンバーターで使うカルチャを指定します  (**ConverterLanguage** を設定する場合は **Converter** も設定する必要があります)。カルチャは、標準ベースの識別子として設定できます。 詳しくは、「[**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/hh701880)」をご覧ください。 |
| **ConverterParameter** | コンバーター ロジックで使うことができるコンバーター パラメーターを指定します  (**ConverterParameter** を設定する場合は **Converter** も設定する必要があります)。 ほとんどのコンバーターは、渡された値から変換に必要なすべての情報を取得するという単純なロジックを使っており、**ConverterParameter** 値を必要としません。 **ConverterParameter** パラメーターは、**ConverterParameter** で渡された値を利用する複数のロジックを持つ、ある程度高度なコンバーターを実装するために存在します。 また、文字列以外の値を使うコンバーターも作成できますが、一般的ではありません。詳しくは、「[**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/br209827)」の「注釈」をご覧ください。 |
| **FallbackValue** | ソースまたはパスを解決できない場合に表示する値を指定します。 |
| **Mode** | "OneTime"、"OneWay"、"TwoWay" のいずれかの文字列として、バインド モードを指定します。 既定は "OneTime" です。 これは、**{Binding}** の既定値 (ほとんどの場合は "OneWay") とは異なる点に注意してください。 |
| **TargetNullValue** | ソース値が解決されるが、明示的に **null** である場合に表示する値を設定します。 |
| **BindBack** | 双方向バインディングの逆方向に使う関数を指定します。 | 

**注:** マークアップを **{Binding}** から **{x:Bind}** に変換する場合は、**Mode** プロパティの既定値の違いに注意してください。
 
## 注釈

**{x:Bind}** は、その利点を得るために、生成されたコードを使用するので、コンパイル時に型情報が必要です。 つまり、型が事前にわかっていない場合は、プロパティにバインドできません。 このため、**{x:Bind}** は、型が **Object** で、実行時に変更されることもある **DataContext** プロパティと共に使用することはできません。

**{x:Bind}** をデータ テンプレートと共に使用するときは、以下の例に示すように **x:DataType** 値を設定し、バインド先の型を指定する必要があります。 型をインターフェイスまたは基底クラス型に設定することもでき、完全な式を指定するために必要な場合は、キャストを使用できます。

コンパイル済みバインドは、コード生成によって異なります。 そのため、リソース ディクショナリで **{x:Bind}** を使う場合、リソース ディクショナリにはコード ビハインド クラスが必要です。 コード例については、「[リソース ディクショナリと {x:Bind}](../data-binding/data-binding-in-depth.md#resource-dictionaries-with-x-bind)」をご覧ください。

コンパイル済みバインドを含むページやユーザー コントロールでは、生成されたコードに "Bindings" プロパティが含まれます。 これには次のメソッドが含まれます。
- **Update()** - すべてのコンパイル済みバインドの値を更新します。 すべての 1 方向/双方向バインディングには、変更を検出するためにフックされたリスナーがあります。
- **Initiatlize()** - バインディングがまだ初期化されていない場合、Update() を呼び出してバインディングを初期化します。
- **StopTracking()** - 1 方向と双方向のバインディングに作成されたすべてのリスナーをフック解除します。 Update() メソッドを使って再初期化できます。

> [!NOTE]
> Windows 10、バージョン1607 以降では、XAML フレームワークにブール値と Visibility 値のコンバーターが組み込まれています。 コンバーターは、**Visible** 列挙値に対して **true** を、**Collapsed** に対して **false** をマッピングします。これにより、コンバーターを作成せずに Visibility プロパティをブール値にバインドできます。 組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。 アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。 ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。

**ヒント:** [**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) や [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/br209827) のように、値に 1 つの中かっこを指定する必要がある場合は、`\{` のように円記号 (バックスラッシュ) を中かっこの前に付けます。 別の方法として、エスケープする必要がある中かっこを含む文字列全体を `ConverterParameter='{Mix}'` のように別の種類の引用符で囲みます。

[**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826)、[**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/hh701880)、**ConverterLanguage** はいずれも、バインド ソースの値または型を、バインディング ターゲットのプロパティと互換性のある型または値に変換するシナリオに関係があります。 例や詳しい情報については、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」の「データの変換」をご覧ください。

**{x:Bind}** は、マークアップ拡張のみです。このようなバインディングをプログラムで作成したり操作したりする方法はありません。 マークアップ拡張について詳しくは、「[XAML の概要](xaml-overview.md)」をご覧ください。

## 例

```XML
<Page x:Class="QuizGame.View.HostView" ... >
    <Button Content="{x:Bind Path=ViewModel.NextButtonText, Mode=OneWay}" ... />
</Page>
```

この例の XAML では、**{x:Bind}** が **ListView.ItemTemplate** プロパティと共に使用されています。 **x:DataType** 値の宣言に注意してください。

```XML
  <DataTemplate x:Key="SimpleItemTemplate" x:DataType="data:SampleDataGroup">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{x:Bind Title}"/>
      <TextBlock Text="{x:Bind Description}"/>
    </StackPanel>
  </DataTemplate>
```



<!--HONumber=Aug16_HO3-->


