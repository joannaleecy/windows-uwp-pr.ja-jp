---
author: jwmsft
title: xLoad 属性
description: 要素とその子、スタートアップ時間とメモリ使用量を減らすの動的な作成と破棄 xLoad を有効にします。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8f34ea43b981de65c81e9cce2b8a896c3577e595
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "610785"
---
# <a name="xload-attribute"></a>x:Load 属性

**X: 読み込み**スタートアップ、視覚的なツリーを作成、および XAML アプリのメモリ使用量を最適化するために使用できます。 **X: 負荷**を使用すると、ことを除き、要素が読み込まれず、メモリを解放され、ビジュアル ツリー内の場所をマークする小さいプレース ホルダーを使用する内部で、**表示**するような視覚効果があります。

X: 負荷の属性の UI 要素は読み込まれ、経由でアンロード コード、または[x: バインド](x-bind-markup-extension.md)式を使用できます。 これは、表示頻度の低い要素や条件付きで表示される要素のコストを削減するのに役立ちます。 グリッドまたは StackPanel などのコンテナーの x: 負荷を使用すると、コンテナーとそのすべての子が読み込まれているか、グループとしてアンロードします。

XAML フレームワークが遅延の要素の追跡、x: 負荷で属性がプレース ホルダーを考慮する各要素のメモリ使用量を約 600 バイトを追加します。 したがって、この属性に、パフォーマンスが低下することができます。 のみを使用することで要素を非表示にする必要があることをお勧めします。 コンテナーの x: 負荷を使用している場合は、x: 読み込み属性と要素に対してのみ、頭上が支払額

> [!IMPORTANT]
> X: 読み込み属性は、Windows 10、バージョン 1703 (作成者の更新プログラム) で始まる使用できます。 x:Load を使用するには、Visual Studio プロジェクトの対象とする最小バージョンを *Windows 10 Creators Update (10.0、ビルド 15063)* にする必要があります。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object x:Load="True" .../>
<object x:Load="False" .../>
<object x:Load="{x:Bind Path.to.a.boolean, Mode=OneWay}" .../>
```

## <a name="loading-elements"></a>要素の読み込み

要素を読み込むにはいくつかの方法があります。

- [X: バインド](x-bind-markup-extension.md)式を使用して、負荷の状態を指定します。 **True**を読み込むと**false**の要素を読み込み解除する式を返す必要があります。
- 要素に対して定義した名前を指定して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出します。
- 要素に対して定義した名前を指定して [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) を呼び出します。
- [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007)では、[x: 読み込み要素を対象とする[**設定**](https://msdn.microsoft.com/library/windows/apps/br208817)または**ストーリー ボード**アニメーションを使用します。
- ターゲット内の任意の**ストーリー ボード**アンロード要素。

> 注: 要素のインスタンス化が開始されると、インスタンスは UI スレッド上で作成されます。そのため、一度に作成されるインスタンスが多すぎると、UI で引っかかりが起きることがあります。

上に示したいずれかの方法で遅延要素が作成されると、以下の動作が発生します。

- 要素の [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) イベントが生成されます。
- [名前] フィールドが設定されています。
- 要素の任意の x: バインド バインドに評価されます。
- 遅延要素を含むプロパティに関するプロパティ変更通知を受信するように登録した場合は、通知が生成されます。

## <a name="unloading-elements"></a>アンロード要素

要素を読み込み解除します。

- X: バインド式を使用して、負荷の状態を指定します。 **True**を読み込むと**false**の要素を読み込み解除する式を返す必要があります。
- ページまたはコントロールの場合は、電話**UnloadObject**をオブジェクト参照で渡す
- 着信の**Windows.UI.Xaml.Markup.XamlMarkupHelper.UnloadObject**とオブジェクト参照で渡す

オブジェクトが読み込まれている場合は、それが置き換えられますツリーのプレース ホルダーします。 すべての参照がリリースされるまでメモリ内でオブジェクトのインスタンスが残ります。 ページ/コントロールの UnloadObject API は、名前、x: バインド codegen によって保持されている参照を解放する設計されています。 アプリ コードでその他の参照を保持するも場合はリリースされる予定です。

要素が読み込まれている場合は、要素に関連付けられたすべての状態は破棄され、ように最適化されたバージョンの表示設定として x: 負荷を使用する場合、[バインド経由で適用されるすべての状態を確認または読み込まれたイベントが発生したときにコードを再適用します。

## <a name="restrictions"></a>制限

**X: 負荷**を使う場合の制限事項は次のとおりです。

- 要素を後で検索する手段として、要素の [x:Name](x-name-attribute.md) を定義する必要があります。
- X: 読み込みは[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911)または[**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249)から派生する型でのみ使用できます。
- [**ページ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page)、[**コントロール**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol)、または[**データ テンプレート**](https://msdn.microsoft.com/library/windows/apps/br242348)のルート要素に x: 負荷を使うことはできません。
- の[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794)の要素の x: 負荷を使うことはできません。
- [**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048)で読み込ましっかり XAML に x: 負荷を使うことはできません。
- 親要素の移動が読み込まれているすべての要素が消去されます。

## <a name="remarks"></a>注釈

持っての最も外側の要素を実現するのには、入れ子になった要素は、[x: 負荷を使用できます。  親が実体化される前に子要素を実体化しようとすると、例外が生成されます。

通常は、最初のフレームに表示できないものを遅延させることをお勧めします。 遅延対象の候補を見つけるための指針の 1 つは、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) が折りたたまれた状態で作成されている要素を探すことです。 また、ユーザーの操作によってトリガーされる UI は、遅延できる要素がないか探す対象として適しています。

[**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) の遅延要素に注意してください。この場合、遅延要素により起動時間が短縮しますが、作成する内容によっては、パンのパフォーマンスも低下することがあります。 パンのパフォーマンスを向上させる方法については、[{x:Bind} マークアップ拡張](x-bind-markup-extension.md) および [x:Phase 属性](x-phase-attribute.md) に関するドキュメントをご覧ください。

[X: フェーズ属性](x-phase-attribute.md)と組み合わせて使用**x: 読み込み**要素または要素のツリーを基準にしている場合、現在のフェーズを含むバインドが適用されます。 **X: フェーズ**の指定されたフェーズに影響はまたは要素の読み込み中の状態を制御します。 リスト アイテムがパンの一部としてごみ箱に入れ、要素の他のアクティブな要素に同じように動作し、フェードアウトなど、同じ規則を使用してコンパイル済みバインド (**{x: バインド}** ) の処理を実現します。

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

