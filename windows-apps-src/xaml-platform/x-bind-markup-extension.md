---
author: jwmsft
description: XBind マークアップ拡張には、バインド、高パフォーマンス代わりです。 xBind - Windows 10 の新規の短時間でおよび少ないメモリ動作バインディングとデバッグの向上をサポートしています。
title: xBind マークアップ拡張
ms.assetid: 529FBEB5-E589-486F-A204-B310ACDC5C06
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9674aeed846fab53de3ecb057ebcc46dbda560c3
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5862258"
---
# <a name="xbind-markup-extension"></a>{x:Bind} マークアップ拡張

**注:** データの使用についての一般的な情報は、 **{** x:bind} (および **{X:bind}** と **{Binding}**、全体的な比較)、アプリでのバインディングは、[データ バインディング](https://msdn.microsoft.com/library/windows/apps/mt210946)を参照してください。

**{X:bind}** マークアップ拡張機能: windows 10 の新機能: **{Binding}** に代わます。 **{X:bind}** は、および少ないメモリ **{Binding}** して適切なデバッグをサポートするよりも短い時間で実行されます。

XAML のコンパイル時に、**{x:Bind}** は、データ ソースのプロパティから値を取得してマークアップで指定されたプロパティに設定するコードに変換されます。 必要な場合、バインディング オブジェクトは、データ ソース プロパティの値の変化を監視し、その変化に基づいて自分自身を更新するように構成できます (`Mode="OneWay"`)。 また、その独自の値の変化をソース プロパティにプッシュするように構成することもできます (`Mode="TwoWay"`)。

**{x:Bind}** と **{Binding}** によって作成されたバインディング オブジェクトは、ほとんど機能的に同等です。 ただし、**{x:Bind}** は、コンパイル時に生成される特定用途のコードを実行し、**{Binding}** は、汎用的なランタイム オブジェクト検査を実行します。 したがって、**{x:Bind}** バインディング (多くの場合、コンパイル済みバインドと呼ばれます) はパフォーマンスが高く、コンパイル時にバインド式を検証したり、ページの部分クラスとして生成されたコード ファイル内にブレークポイントを設定し、デバッグを行ったりできます。 これらのファイルは `obj` フォルダー内にあり、`<view name>.g.cs` (C# の場合) などの名前が付けられています。

> [!TIP]
> **{Binding}** の既定のモードは **OneWay** ですが、**{x:Bind}** の既定のモードは **OneTime** です。 これはパフォーマンス上の理由から選ばれました。**OneWay** を使うと、接続して変更検出を処理するために生成されるコードが多くなるためです。 OneWay または TwoWay バインディングを使うようにモードを明示的に指定することができます。 [x:DefaultBindMode](x-defaultbindmode-attribute.md) を使って、マークアップ ツリーの特定のセグメントで **{x:Bind}** の既定のモードを変更することもできます。 指定されたモードは、バインドの一部として明示的にモードが指定されている場合を除いて、対象の要素とその子に対するすべての **{x:Bind}** 式に適用されます。

**{x:Bind} の使い方を示すサンプル アプリ**

-   [{x:Bind} のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619989)
-   [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame)
-   [XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619992)

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object property="{x:Bind}" .../>
-or-
<object property="{x:Bind propertyPath}" .../>
-or-
<object property="{x:Bind bindingProperties}" .../>
-or-
<object property="{x:Bind propertyPath, bindingProperties}" .../>
-or-
<object property="{x:Bind pathToFunction.functionName(functionParameter1, functionParameter2, ...), bindingProperties}" .../>
```

| 用語 | 説明 |
|------|-------------|
| _propertyPath_ | バインドのプロパティ パスを指定する文字列。 詳しくは、以下の「[プロパティ パス](#property-path)」をご覧ください。 |
| _bindingProperties_ |
| _propName_=_value_\[, _propName_=_value_\]* | 名前と値のペアの構文を使って指定する、1 つ以上のバインド プロパティ。 |
| _propName_ | Binding オブジェクトで設定するプロパティの文字列名。 たとえば、"Converter" です。 |
| _value_ | プロパティに設定する値。 引数の構文は、設定されているプロパティによって異なります。 値がそれ自体マークアップ拡張である _propName_=_value_ の使用例を示します: `Converter={StaticResource myConverterClass}`。 詳しくは、以下の「[{x:Bind} で設定できるプロパティ](#properties-you-can-set)」をご覧ください。 |

## <a name="examples"></a>例

```XAML
<Page x:Class="QuizGame.View.HostView" ... >
    <Button Content="{x:Bind Path=ViewModel.NextButtonText, Mode=OneWay}" ... />
</Page>
```

この例の XAML では、**{x:Bind}** が **ListView.ItemTemplate** プロパティと共に使用されています。 **x:DataType** 値の宣言に注意してください。

```XAML
  <DataTemplate x:Key="SimpleItemTemplate" x:DataType="data:SampleDataGroup">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{x:Bind Title}"/>
      <TextBlock Text="{x:Bind Description}"/>
    </StackPanel>
  </DataTemplate>
```

## <a name="property-path"></a>プロパティ パス

*PropertyPath* は **{x:Bind}** 式の **Path** です。 **Path** は、バインディング先のプロパティ、サブプロパティ、フィールド、またはメソッドの値 (ソース) を指定するプロパティ パスです。 **Path** プロパティの名前は、`{Binding Path=...}` のように明示的に指定することができます。 または、`{Binding ...}` のように省略することもできます。

### <a name="property-path-resolution"></a>プロパティのパスの解決

**{x:Bind}** は、既定のソースとして **DataContext** を使わず、代わりにページまたはユーザー コントロール自体を使います。 したがって、ページまたはユーザー コントロールのコード ビハインドでプロパティ、フィールド、およびメソッドが検索されます。 通常、ビュー モデルを **{x:Bind}** に公開するには、ページまたはユーザー コントロールのコード ビハインドに新しいフィールドまたはプロパティを追加する必要があります。 プロパティ パスのステップは、ドット (.) で区切ります。複数の区切り記号を指定することで、連続するサブプロパティを走査できます。 バインドされているオブジェクトを実装するために使用するプログラミング言語に関係なく、ドット区切り記号を使います。

たとえば、あるページで、**Text="{x:Bind Employee.FirstName}"** を指定すると、そのページの **Employee** メンバーが検索され、次に、**Employee** が返したオブジェクトの **FirstName** メンバーが検索されます。 従業員の扶養家族を含むプロパティに項目コントロールをバインドする場合、プロパティ パスは "Employee.Dependents" となり、"Dependents" の項目の表示には項目コントロールの項目テンプレートが使われます。

C++/CX の場合、**{x:Bind}** はページまたはデータ モデルのプライベート フィールドおよびプロパティにバインドできません。バインドできるようにするには、パブリック プロパティが必要です。 バインディング用のサーフェス領域を CX クラス/インターフェイスとして公開し、関連するメタデータを取得できるようにする必要があります。 **\[Bindable\]** 属性は必要ありません。

**x:Bind** では、**ElementName=xxx** をバインド式の一部として使用する必要はありません。 代わりに、名前付きの要素が、ルート バインディング ソースを表すページまたはユーザー コントロール内のフィールドになるためには、バインディングのパスの最初の部分として、要素の名前を使用することができます。 


### <a name="collections"></a>コレクション

データ ソースがコレクションである場合、プロパティ パスには、位置またはインデックスによりコレクション内の項目を指定できます。 たとえば "Teams\[0\].Players" の場合、"0" をリテラル "\[\]" で囲むことで、インデックス 0 で始まるコレクション内の最初の項目を要求します。

インデクサーを使うには、インデックス化されるプロパティの型に基づいて、モデルで **IList&lt;T&gt;** または **IVector&lt;T&gt;** を実装する必要があります。 インデックス付きプロパティの型が **INotifyCollectionChanged** または **IObservableVector** をサポートしており、バインディングが OneWay または TwoWay の場合、そのプロパティは登録され、それらのインターフェイスで変更通知をリッスンします。 変更検出ロジックは、特定のインデックス付きの値に影響を与えない場合でも、すべてのコレクションの変更に基づいて更新されます。 これは、リッスンしているロジックがコレクションのすべてのインスタンス間で共通であるためです。

データ ソースがディクショナリまたはマップである場合、プロパティ パスには、文字列名によりコレクション内の項目を指定できます。 たとえば、**&lt;TextBlock Text="{x:Bind Players\['John Smith'\]" /&gt;** は、ディクショナリで "John Smith" という名前の項目を検索します。 名前は引用符で囲む必要があり、単一引用符と二重引用符のどちらでも使用できます。 文字列で引用符をエスケープするにはハット (^) を使用できます。 XAML 属性に使用されるものから代替引用符を使用するのが最も簡単です。

文字列インデクサーを使うには、インデックス化されるプロパティの型に基づいて、モデルで **IDictionary&lt;string, T&gt;** または **IMap&lt;string, T&gt;** を実装する必要があります。 インデックス付きプロパティの型が **IObservableMap** をサポートしており、バインディングが OneWay または TwoWay の場合、そのプロパティは登録され、それらのインターフェイスで変更通知をリッスンします。 変更検出ロジックは、特定のインデックス付きの値に影響を与えない場合でも、すべてのコレクションの変更に基づいて更新されます。 これは、リッスンしているロジックがコレクションのすべてのインスタンス間で共通であるためです。

### <a name="attached-properties"></a>添付プロパティ

添付プロパティにバインドするには、クラスおよびプロパティ名をドットの後のかっこ内に含める必要があります。 たとえば、**Text="{x:Bind Button22.(Grid.Row)}"** などです。 プロパティが Xaml 名前空間で宣言されていない場合は、そのプロパティの前に xml 名前空間を付ける必要があります。これはドキュメントの先頭でコード名前空間にマップする必要があります。

### <a name="casting"></a>キャスト

コンパイル済みのバインドは、厳密に型指定され、パスの各ステップの型を解決します。 返される型にメンバーがない場合は、コンパイル時に失敗します。 キャストを指定して、オブジェクトの実際の型をバインディングに通知することができます。 次の場合、**obj** は型オブジェクトのプロパティですが、テキスト ボックスを含んでいます。したがって、**Text="{x:Bind ((TextBox)obj).Text}"** または **Text="{x:Bind obj.(TextBox.Text)}"** を使用できます。
groups3 field in **Text="{x:Bind ((data:SampleDataGroup)groups3\[0\]).Title}"** の **groups3** フィールドは、オブジェクトのディクショナリです。したがって、**data:SampleDataGroup** にキャストする必要があります。 既定の XAML 名前空間の一部ではないコード名前空間にオブジェクトの型をマップするための xml **data:** 名前空間のプレフィックスの使用法に注意してください。

_注: C# スタイルのキャスト構文は添付プロパティ構文より柔軟であり、今後はこの構文が推奨されます。_

## <a name="functions-in-binding-paths"></a>バインディング パス内の関数

Windows 10 バージョン 1607 以降、**{x:Bind}** はバインド パスのリーフ ステップとしての関数の使用をサポートします。 これは、マークアップでいくつかのシナリオを可能にするデータをバインドするための強力な機能です。 詳細については、[関数のバインディング](../data-binding/function-bindings.md)を参照してください。

## <a name="event-binding"></a>イベント バインディング

イベント バインディングは、コンパイル済みのバインドの固有の機能です。 これにより、バインディングを使用するイベントのハンドラーを指定でき、それをコード ビハインドのメソッドにする必要はありません。 たとえば、**Click="{x:Bind rootFrame.GoForward}"** などです。

イベントの場合、対象のメソッドをオーバーロードしてはならず、以下の条件も満たしている必要があります。

- イベントのシグネチャが一致している。
- または、パラメーターを持たない。
- または、イベント パラメーターの型から割り当て可能な型のパラメーターを同じ数だけ持つ。

生成されたコード ビハインドでは、コンパイル済みのバインドは、イベントを処理してモデルのメソッドにルーティングします。また、イベントが発生すると、バインド式のパスを評価します。 つまり、プロパティ バインディングとは異なり、モデルの変更を追跡しません。

プロパティ パスの文字列構文について詳しくは、ここで説明した **{x:Bind}** に対する違いに注意して、「[プロパティ パス構文](property-path-syntax.md)」をご覧ください。

## <a name="properties-that-you-can-set-with-xbind"></a> {x:Bind} で設定できるプロパティ

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
| **UpdateSourceTrigger** | コントロールから双方向バインディングのモデルに変更を戻すタイミングを指定します。 TextBox.Text を除くすべてのプロパティの既定値は PropertyChanged です。TextBox.Text の既定値は LostFocus です。|

> [!NOTE]
> マークアップを **{Binding}** から **{x:Bind}** に変換する場合は、**Mode** プロパティの既定値の違いに注意してください。
 
> マークアップ ツリーの特定のセグメントで x:Bind の既定のモードを変更するには、[**x:DefaultBindMode**](https://docs.microsoft.com/windows/uwp/xaml-platform/x-defaultbindmode-attribute) を使用できます。 選択されたモードは、バインドの一部として明示的にモードが指定されている場合を除いて、対象の要素とその子に対するすべての x:Bind 式に適用されます。 OneTime は、OneWay より重要です。OneWay を使うと、接続して変更検出を処理するために生成されるコードが多くなるためです。

## <a name="remarks"></a>注釈

**{x:Bind}** は、その利点を得るために、生成されたコードを使用するので、コンパイル時に型情報が必要です。 つまり、型が事前にわかっていない場合は、プロパティにバインドできません。 このため、**{x:Bind}** は、型が **Object** で、実行時に変更されることもある **DataContext** プロパティと共に使用することはできません。

**{x:Bind}** をデータ テンプレートと共に使用するときは、以下の例に示すように **x:DataType** 値を設定し、バインド先の型を指定する必要があります。 型をインターフェイスまたは基底クラス型に設定することもでき、完全な式を指定するために必要な場合は、キャストを使用できます。

コンパイル済みバインドは、コード生成によって異なります。 そのため、リソース ディクショナリで **{x:Bind}** を使う場合、リソース ディクショナリにはコード ビハインド クラスが必要です。 コード例については、「[リソース ディクショナリと {x:Bind}](../data-binding/data-binding-in-depth.md#resource-dictionaries-with-x-bind)」をご覧ください。

コンパイル済みバインドを含むページやユーザー コントロールでは、生成されたコードに "Bindings" プロパティが含まれます。 これには次のメソッドが含まれます。

- **Update()** - すべてのコンパイル済みバインドの値を更新します。 すべての 1 方向/双方向バインディングには、変更を検出するためにフックされたリスナーがあります。
- **Initialize()** - バインディングがまだ初期化されていない場合、Update() を呼び出してバインディングを初期化します。
- **StopTracking()** - 1 方向と双方向のバインディングに作成されたすべてのリスナーをフック解除します。 Update() メソッドを使って再初期化できます。

> [!NOTE]
> Windows 10、バージョン1607 以降では、XAML フレームワークにブール値と Visibility 値のコンバーターが組み込まれています。 コンバーターは、**Visible** 列挙値に対して **true** を、**Collapsed** に対して **false** をマッピングします。これにより、コンバーターを作成せずに Visibility プロパティをブール値にバインドできます。 これは、関数バインドの機能ではないことに注意してください。プロパティのバインドにすぎません。 組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。 アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。 ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。

**ヒント:** の値を 1 つの中かっこを指定する必要がある場合など、[**パス**](https://msdn.microsoft.com/library/windows/apps/br209830)または[**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/br209827)、前に付けますバック スラッシュ:`\{`します。 別の方法として、エスケープする必要がある中かっこを含む文字列全体を `ConverterParameter='{Mix}'` のように別の種類の引用符で囲みます。

[**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826)、[**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/hh701880)、**ConverterLanguage** はいずれも、バインド ソースの値または型を、バインディング ターゲットのプロパティと互換性のある型または値に変換するシナリオに関係があります。 例や詳しい情報については、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」の「データの変換」をご覧ください。

**{x:Bind}** は、マークアップ拡張のみです。このようなバインディングをプログラムで作成したり操作したりする方法はありません。 マークアップ拡張について詳しくは、「[XAML の概要](xaml-overview.md)」をご覧ください。

