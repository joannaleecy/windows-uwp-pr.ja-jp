---
title: xLoad 属性
description: xLoad では、要素とその子は、起動時間とメモリ使用量を減らすの動的な作成と破棄できます。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 1fa0f12779ad56d57c92f667443644851dc3d5e5
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7976091"
---
# <a name="xload-attribute"></a>x:Load 属性

**X:load**を使用して、起動、ビジュアル ツリーの作成、および XAML アプリのメモリ使用量を最適化することができます。 **X:load**を使用して、要素が読み込まれていない場合、メモリが解放され、ビジュアル ツリー内の場所をマークする小さなプレース ホルダーを内部的に使用される点を除けば、**可視性**のような視覚効果があります。

X:load で属性が UI 要素は、ロードとアンロード経由でのコード、または[X:bind](x-bind-markup-extension.md)式を使用できます。 これは、表示頻度の低い要素や条件付きで表示される要素のコストを削減するのに役立ちます。 グリッドや StackPanel などのコンテナーで X:load を使用して、コンテナーとそのすべての子が読み込まれるか、グループとしてアンロードします。

XAML フレームワークによる遅延要素の追跡は、X:load を使ってに起因するアカウントのプレース ホルダーの各要素のメモリ使用量に約 600 バイトを追加します。 したがって、実際には、パフォーマンスが低下するは、この属性を過剰にことができます。 のみで使用することが非表示にする必要がある要素をお勧めします。 コンテナーの X:load を使用する場合は、X:load 属性を持つ要素に対してのみオーバーヘッドが支払われます。

> [!IMPORTANT]
> X:load 属性では、Windows 10 バージョン 1703 (Creators Update) 以降で利用できます。 x:Load を使用するには、Visual Studio プロジェクトの対象とする最小バージョンを *Windows 10 Creators Update (10.0、ビルド 15063)* にする必要があります。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object x:Load="True" .../>
<object x:Load="False" .../>
<object x:Load="{x:Bind Path.to.a.boolean, Mode=OneWay}" .../>
```

## <a name="loading-elements"></a>要素の読み込み

要素を読み込むのいくつかのさまざまな方法はあります。

- [X:bind](x-bind-markup-extension.md)式を使用して、負荷の状態を指定します。 **True**を読み込むと**false**要素をアンロードするのには、式を返す必要があります。
- 要素に対して定義した名前を指定して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出します。
- 要素に対して定義した名前を指定して [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) を呼び出します。
- [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007)では、 [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817)または**ストーリー ボード**のアニメーションで、要素をターゲットに X:load を使用します。
- 任意の**ストーリー ボード**にあるアンロード要素をターゲットにします。

> 注: 要素のインスタンス化が開始されると、インスタンスは UI スレッド上で作成されます。そのため、一度に作成されるインスタンスが多すぎると、UI で引っかかりが起きることがあります。

上に示したいずれかの方法で遅延要素が作成されると、以下の動作が発生します。

- 要素の [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) イベントが生成されます。
- X: Name のフィールドを設定します。
- 要素のすべての X:bind バインドが評価されます。
- 遅延要素を含むプロパティに関するプロパティ変更通知を受信するように登録した場合は、通知が生成されます。

## <a name="unloading-elements"></a>要素をアンロード

要素をアンロードするには。

- X:bind 式を使用して、負荷の状態を指定します。 **True**を読み込むと**false**要素をアンロードするのには、式を返す必要があります。
- ページまたはユーザー コントロールでは、 **UnloadObject**を呼び出すし、オブジェクト参照を渡す
- **Windows.UI.Xaml.Markup.XamlMarkupHelper.UnloadObject**を呼び出すし、オブジェクト参照を渡す

オブジェクトが読み込まれると、それに置き換えられますツリーのプレース ホルダーです。 すべての参照がリリースされるまで、オブジェクト インスタンスはメモリに残ります。 ページ/UserControl の UnloadObject API は、x: Name と X:bind codegen によって保持されている参照を解放する設計されています。 アプリ コードでその他の参照を保持する場合を解放する必要はも。

要素が読み込まれると、要素に関連付けられているすべての状態は破棄されますめ、可視性の最適化のバージョンとして X:load を使用している場合、バインディングを介してが適用されるすべての状態を確認しますか Loaded イベントが発生したときにコードを再適用します。

## <a name="restrictions"></a>制限

**X:load**を使用するための制限は次のとおりです。

- [X:name](x-name-attribute.md)を定義する必要があります要素、そこにする必要があります、要素を後で検索する手段です。
- X:load は[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911)または[**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249)から派生した型でのみ使用できます。
- [**ページ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page)、 [**UserControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol)、または[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348)のルート要素では、X:load を使うことはできません。
- [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794)内の要素では、X:load を使用できません。
- [**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048)で読み込まれた loose XAML では、X:load を使用できません。
- 親要素を移動すると、読み込まれていないすべての要素がクリアされます。

## <a name="remarks"></a>注釈

最も外側の要素から実体化される必要が、入れ子になった要素は、X:load を使用できます。 親が実体化される前に子要素を実体化しようとすると、例外が生成されます。

通常は、最初のフレームに表示できないものを遅延させることをお勧めします。遅延対象の候補を見つけるための指針の 1 つは、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) が折りたたまれた状態で作成されている要素を探すことです。 また、ユーザーの操作によってトリガーされる UI は、遅延できる要素がないか探す対象として適しています。

[**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) の遅延要素に注意してください。この場合、遅延要素により起動時間が短縮しますが、作成する内容によっては、パンのパフォーマンスも低下することがあります。 パンのパフォーマンスを向上させる方法については、[{x:Bind} マークアップ拡張](x-bind-markup-extension.md) および [x:Phase 属性](x-phase-attribute.md) に関するドキュメントをご覧ください。

[X:phase 属性](x-phase-attribute.md)は、要素または要素ツリーが実体化されると、 **X:load**と組み合わせて使用、現在のフェーズを含むバインディングが適用されます。 **X:phase**指定されたフェーズによって影響または要素の読み込み中の状態を制御します。 リスト項目がパンの一部として再利用、実現した要素が動作する同じ方法で、アクティブな他の要素と、コンパイル済みバインド (**{X:bind}** バインディング) は、フェージングを含む、同じ規則を使用して処理されます。

一般的なガイドラインでは、必要なパフォーマンスが得られていることを確認するために、作業の前と後にアプリのパフォーマンスを測定します。

## <a name="example"></a>例

```xml
<StackPanel>
    <Grid x:Name="DeferredGrid" x:Load="False">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>

        <Rectangle Height="100" Width="100" Fill="Orange" Margin="0,0,4,4"/>
        <Rectangle Height="100" Width="100" Fill="Green" Grid.Column="1" Margin="4,0,0,4"/>
        <Rectangle Height="100" Width="100" Fill="Blue" Grid.Row="1" Margin="0,4,4,0"/>
        <Rectangle Height="100" Width="100" Fill="Gold" Grid.Row="1" Grid.Column="1" Margin="4,4,0,0"
                   x:Name="one" x:Load="{x:Bind (x:Boolean)CheckBox1.IsChecked, Mode=OneWay}"/>
        <Rectangle Height="100" Width="100" Fill="Silver" Grid.Row="1" Grid.Column="1" Margin="4,4,0,0"
                   x:Name="two" x:Load="{x:Bind Not(CheckBox1.IsChecked), Mode=OneWay}"/>
    </Grid>

    <Button Content="Load elements" Click="LoadElements_Click"/>
    <Button Content="Unload elements" Click="UnloadElements_Click"/>
    <CheckBox x:Name="CheckBox1" Content="Swap Elements" />
</StackPanel>
```

```csharp
// This is used by the bindings between the rectangles and check box.
private bool Not(bool? value) { return !(value==true); }

private void LoadElements_Click(object sender, RoutedEventArgs e)
{
    // This will load the deferred grid, but not the nested
    // rectangles that have x:Load attributes.
    this.FindName("DeferredGrid"); 
}

private void UnloadElements_Click(object sender, RoutedEventArgs e)
{
     // This will unload the grid and all its child elements.
     this.UnloadObject(DeferredGrid);
}
```

