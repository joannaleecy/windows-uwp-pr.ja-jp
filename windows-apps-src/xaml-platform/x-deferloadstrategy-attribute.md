---
title: xDeferLoadStrategy 属性
description: xDeferLoadStrategy は、要素とその子の作成を遅延させます。起動時間は短くなりますが、メモリ使用量は若干増加します。影響を受けるそれぞれの要素によって、メモリ使用量が約 600 バイト増加します。
ms.assetid: E763898E-13FF-4412-B502-B54DBFE2D4E4
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4432362db74f830774a2c4f74401c472c128a120
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8854553"
---
# <a name="xdeferloadstrategy-attribute"></a>x:DeferLoadStrategy 属性

> [!IMPORTANT]
> Windows 10 Version 1703 (Creators Update) 以降、**x:DeferLoadStrategy** は [**x:Load attribute**](x-load-attribute.md) に置き換わります。 `x:Load="False"` を使うと、`x:DeferLoadStrategy="Lazy"` と同じ効果がありますが、さらに必要に応じて UI のアンロードも可能です。 詳しくは、「[x:Load 属性](x-load-attribute.md)」をご覧ください。

**x:DeferLoadStrategy="Lazy"** を使うと、XAML アプリの起動やツリー作成パフォーマンスを最適化できます。 **x:DeferLoadStrategy="Lazy"** を使うと、要素とその子の作成が遅延されるため、起動時間とメモリ コストが縮小されます。 これは、表示頻度の低い要素や条件付きで表示される要素のコストを削減するのに役立ちます。 要素は、コードまたは VisualStateManager から参照された時点で実体化されます。

ただし、XAML フレームワークによる遅延要素の追跡で、影響を受ける各要素のメモリ使用量に約 600 バイトが追加されます。 遅延させる要素ツリーが大きいほど、起動時間がより節約されます。ただし、メモリ使用量のコストは増加します。 したがって、この属性を過剰に使うとパフォーマンスが低下する可能性があります。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object x:DeferLoadStrategy="Lazy" .../>
```

## <a name="remarks"></a>注釈

**x:DeferLoadStrategy** を使う際の制約を以下に示します。

- [X: Name](x-name-attribute.md)を定義する必要があります、要素として存在する必要があります、要素を後で検索する手段です。
- 遅延できるのは、[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) または [**FlyoutBase**](https://msdn.microsoft.com/library/windows/apps/dn279249) から派生した型のみです。
- [**Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page)、[**UserControl**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol)、または [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348) のルート要素は遅延できません。
- [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の要素は遅延できません。
- [**XamlReader.Load**](https://msdn.microsoft.com/library/windows/apps/br228048) で読み込まれた Loose XAML は遅延できません。
- 親要素を移動すると、実体化されていない要素はすべて消去されます。

遅延要素を実体化するには、いくつかの方法があります。

- 要素に対して定義した名前を指定して [**FindName**](https://msdn.microsoft.com/library/windows/apps/br208715) を呼び出します。
- 要素に対して定義した名前を指定して [**GetTemplateChild**](https://msdn.microsoft.com/library/windows/apps/br209416) を呼び出します。
- [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) で、遅延要素をターゲットに設定している [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) または **Storyboard** アニメーションを使います。
- 任意の **Storyboard** で遅延要素をターゲットに設定します。
- 遅延要素をターゲットに設定しているバインドを使います。

> 注: 要素のインスタンス化が開始されると、インスタンスは UI スレッド上で作成されます。そのため、一度に作成されるインスタンスが多すぎると、UI で引っかかりが起きることがあります。

上に示したいずれかの方法で遅延要素が作成されると、以下の動作が発生します。

- 要素の [**Loaded**](https://msdn.microsoft.com/library/windows/apps/br208723) イベントが生成されます。
- 要素のバインドが評価されます。
- 遅延要素を含むプロパティに関するプロパティ変更通知を受信するように登録した場合は、通知が生成されます。

遅延要素は入れ子にできますが、最も外側の要素から実体化する必要があります。 親が実体化される前に子要素を実体化しようとすると、例外が生成されます。

通常は、最初のフレームに表示できないものを遅延させることをお勧めします。遅延対象の候補を見つけるための指針の 1 つは、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) が折りたたまれた状態で作成されている要素を探すことです。 また、ユーザーの操作によってトリガーされる UI は、遅延できる要素がないか探す対象として適しています。

[**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) の遅延要素に注意してください。この場合、遅延要素により起動時間が短縮しますが、作成する内容によっては、パンのパフォーマンスも低下することがあります。 パンのパフォーマンスを向上させる方法については、[{x:Bind} マークアップ拡張](x-bind-markup-extension.md) および [x:Phase 属性](x-phase-attribute.md) に関するドキュメントをご覧ください。

**x:DeferLoadStrategy** と同時に [x:Phase 属性](x-phase-attribute.md)を使った場合、要素または要素ツリーが実体化されると、バインディングが現在のフェーズまで (現在のフェーズを含めて) 適用されます。 **x:Phase** に指定されたフェーズによって、要素の遅延が影響または制御されることはありません。 パンの一部としてリスト項目がリサイクルされると、実体化された要素は、アクティブな他の要素と同じように機能し、コンパイル済みバインド (**{x:Bind}** バインディング) は同じルール (フェージングを含む) を使って処理されます。

一般的なガイドラインでは、必要なパフォーマンスが得られていることを確認するために、作業の前と後にアプリのパフォーマンスを測定します。

## <a name="example"></a>例

```xml
<Grid x:Name="DeferredGrid" x:DeferLoadStrategy="Lazy">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="Auto" />
    </Grid.ColumnDefinitions>

    <Rectangle Height="100" Width="100" Fill="#F65314" Margin="0,0,4,4" />
    <Rectangle Height="100" Width="100" Fill="#7CBB00" Grid.Column="1" Margin="4,0,0,4" />
    <Rectangle Height="100" Width="100" Fill="#00A1F1" Grid.Row="1" Margin="0,4,4,0" />
    <Rectangle Height="100" Width="100" Fill="#FFBB00" Grid.Row="1" Grid.Column="1" Margin="4,4,0,0" />
</Grid>
<Button x:Name="RealizeElements" Content="Realize Elements" Click="RealizeElements_Click"/>
```

```csharp
private void RealizeElements_Click(object sender, RoutedEventArgs e)
{
    // This will realize the deferred grid.
    this.FindName("DeferredGrid");
}
```
