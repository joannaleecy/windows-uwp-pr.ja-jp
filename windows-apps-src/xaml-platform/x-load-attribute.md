---
title: xLoad 属性
description: xLoad を使用すると、要素および子の動的な作成とデストラクションが可能になり、スタートアップ時間とメモリ使用量を削減できます。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 1fa0f12779ad56d57c92f667443644851dc3d5e5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57629367"
---
# <a name="xload-attribute"></a>x:Load 属性

スタートアップ、ビジュアル ツリーの作成、XAML アプリのメモリ使用量を最適化するには、**x:Load** を使用します。 **x:Load** の使用には、**Visibility** と同様の効果があります。ただし、要素が読み込まれていない場合はメモリが解放され、内部的に小さなプレースホルダーを使ってビジュアル ツリー内の場所がマークされます。

x:Load 属性が指定された UI 要素の読み込み/アンロードには、コードを使用することも、[x:Bind](x-bind-markup-extension.md) 式を使用することもできます。 これは、表示頻度の低い要素や条件付きで表示される要素のコストを削減するのに役立ちます。 Grid や StackPanel などのコンテナーに x:Load を使用した場合は、コンテナーおよびすべての子がグループとして読み込まれ、アンロードされます。

XAML フレームワークによる遅延要素の追跡では、x:Load 属性が指定された要素ごとに、プレースホルダー分として約 600 バイトがメモリ使用量に追加されます。 したがって、この属性を過剰に使うと実際のパフォーマンスが低下する可能性があります。 この属性は、非表示にする必要がある要素のみに対して使用することをお勧めします。 コンテナーに対して x:Load を使用した場合、その効果があるのは x:Load 属性を指定した要素のみです。

> [!IMPORTANT]
> X: 負荷属性では、Windows 10 バージョン 1703 (Creators Update) 以降を使用できます。 x:Load を使用するには、Visual Studio プロジェクトの対象とする最小バージョンを *Windows 10 Creators Update (10.0、ビルド 15063)* にする必要があります。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object x:Load="True" .../>
<object x:Load="False" .../>
<object x:Load="{x:Bind Path.to.a.boolean, Mode=OneWay}" .../>
```

## <a name="loading-elements"></a>要素の読み込み

要素を読み込むには、いくつかの方法があります。

- [x:Bind](x-bind-markup-extension.md) 式を使用して読み込み状態を指定します。 この式は、要素を読み込む場合は **true**、アンロードする場合は **false** を返す必要があります。
- 要素に対して定義した名前を指定して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出します。
- 要素に対して定義した名前を指定して [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) を呼び出します。
- [  **VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) で、x:Load をターゲットに設定している [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) または **Storyboard** アニメーションを使います。
- 任意の **Storyboard** のアンロード済み要素をターゲットに設定します。

> 注: 要素のインスタンス化が開始されたら、UI 途切れたりすぎる場合、一度に多く作成することになるため、UI スレッドで作成されます。

上に示したいずれかの方法で遅延要素が作成されると、以下の動作が発生します。

- 要素の [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) イベントが生成されます。
- x:Name のフィールドが設定されます。
- 要素に対する任意の x:Bind バインドが評価されます。
- 遅延要素を含むプロパティに関するプロパティ変更通知を受信するように登録した場合は、通知が生成されます。

## <a name="unloading-elements"></a>要素のアンロード

要素をアンロードするには:

- x:Bind 式を使用して読み込み状態を指定します。 この式は、要素を読み込む場合は **true**、アンロードする場合は **false** を返す必要があります。
- Page または UserControl で **UnloadObject** を呼び出し、オブジェクト参照を渡します。
- **Windows.UI.Xaml.Markup.XamlMarkupHelper.UnloadObject** オブジェクト参照を渡します。

オブジェクトが読み込まれると、ツリー内でプレース ホルダーに置き換えられます。 オブジェクトのインスタンスは、すべての参照が解放されるまでメモリ内に残ります。 Page/UserControl に対する UnloadObject API は、codegen で確保されている参照が x:Name および x:Bind 用に解放されるように設計されています。 アプリ コードで追加の参照を確保している場合は、これらも解放する必要があります。

要素が読み込まれると、要素関連の状態がすべて破棄されるため、x:Load を Visibility の最適化バージョンとして使用する場合は、すべての状態をバインド経由で適用するか、コードによって Loaded イベントの発生時に再適用する必要があります。

## <a name="restrictions"></a>制限

**x:Load** を使う際の制限事項は次のとおりです。

- 定義する必要があります、 [X:name](x-name-attribute.md) 要素にそこにある必要がありますを後で、要素を見つけることです。
- x:Load は、[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) または [**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249) から派生した型に対してのみ使用できます。
- [  **Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page)、[**UserControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol)、または [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348) のルート要素に x:Load を使用することはできません。
- [  **ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内の要素に x:Load を使用することはできません。
- [  **XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048) で読み込まれた Loose XAML に x:Load を使用することはできません。
- 親要素を移動すると、読み込まれていない要素はすべて消去されます。

## <a name="remarks"></a>注釈

入れ子になった要素に x:Load を使用することはできますが、最も外側の要素から実体化する必要があります。  親が実体化される前に子要素を実体化しようとすると、例外が生成されます。

通常は、最初のフレームに表示できないものを遅延させることをお勧めします。 遅延対象の候補を見つけるための指針の 1 つは、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) が折りたたまれた状態で作成されている要素を探すことです。 また、ユーザーの操作によってトリガーされる UI は、遅延できる要素がないか探す対象として適しています。

[  **ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) の遅延要素に注意してください。この場合、遅延要素により起動時間が短縮しますが、作成する内容によっては、パンのパフォーマンスも低下することがあります。 パンのパフォーマンスを向上させる方法については、[{x:Bind} マークアップ拡張](x-bind-markup-extension.md) および [x:Phase 属性](x-phase-attribute.md) に関するドキュメントをご覧ください。

**x:Load** と同時に [x:Phase 属性](x-phase-attribute.md)を使った場合、要素または要素ツリーが実体化されると、バインディングが現在のフェーズまで (現在のフェーズを含めて) 適用されます。 **x:Phase** に指定されたフェーズが、要素の読み込み状態に影響を与えたり、制御したりすることはありません。 パンの一部としてリスト項目がリサイクルされると、実現した要素は、アクティブな他の要素と同じように機能し、コンパイル済みバインド (**{x:Bind}** バインディング) は同じルール (フェージングを含む) を使って処理されます。

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

