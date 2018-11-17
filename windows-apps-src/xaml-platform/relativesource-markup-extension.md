---
author: jwmsft
description: ランタイム オブジェクト グラフの相対関係に関するバインドのソースを指定する手段を提供します。
title: RelativeSource マークアップ拡張
ms.assetid: B87DEF36-BE1F-4C16-B32E-7A896BD09272
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5bb9d241569afdbbc9df95fa11cd2261e78c077a
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7164941"
---
# <a name="relativesource-markup-extension"></a>{RelativeSource} マークアップ拡張


ランタイム オブジェクト グラフの相対関係に関するバインドのソースを指定する手段を提供します。

## <a name="xaml-attribute-usage-self-mode"></a>XAML 属性の使用方法 (Self モード)

``` syntax
<Binding RelativeSource="{RelativeSource Self}" .../>
-or-
<object property="{Binding RelativeSource={RelativeSource Self} ...}" .../>
```

## <a name="xaml-attribute-usage-templatedparent-mode"></a>XAML 属性の使用方法 (TemplatedParent モード)

``` syntax
<Binding RelativeSource="{RelativeSource TemplatedParent}" .../>
-or-
<object property="{Binding RelativeSource={RelativeSource TemplatedParent} ...}" .../>
```

## <a name="xaml-values"></a>XAML 値

| 用語 | 説明 |
|------|-------------|
| {RelativeSource Self} | <strong>Self</strong> の [<strong>Mode</strong>](https://msdn.microsoft.com/library/windows/apps/br209915) 値を生成します。 ターゲット要素をこのバインドのソースとして使う必要があります。 要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合に便利です。 |
| {RelativeSource TemplatedParent} | このバインドのソースとして適用される [<strong>ControlTemplate</strong>](https://msdn.microsoft.com/library/windows/apps/br209391) を生成します。 ランタイム情報をテンプレート レベルでバインドに適用する場合に便利です。 | 

## <a name="remarks"></a>注釈

[**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) では、**Binding** オブジェクト要素の属性または [{Binding} マークアップ拡張](binding-markup-extension.md)内のコンポーネントとして [**Binding.RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831) を設定できます。 これが、2 つの異なる XAML 構文が示されている理由です。

**RelativeSource** は [{Binding} マークアップ拡張](binding-markup-extension.md)に似ています。  具体的には、自分自身のインスタンスを返すことができ、基本的に引数をコンストラクターに渡す文字列ベースの構築をサポートできるマークアップ拡張機能であるという点です。 この場合、渡される引数は [**Mode**](https://msdn.microsoft.com/library/windows/apps/br209915) 値になります。

**Self** モードは、要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合に便利です。これは、要素の名前の指定の後に自己参照を必要としない、[**ElementName**](https://msdn.microsoft.com/library/windows/apps/br209828) バインドの 1 つのバリエーションです。 要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合、プロパティで同じプロパティの型を使うか、またはバインドに対して [**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) を使って値を変換する必要があります。 たとえば、[**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) は変換せずに [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) のソースとして使用できますが、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/br209419) のソースとして [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/br209006) を使う場合には、コンバーターが必要です。

次に例を示します。 この [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) は [**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height) と [**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width) が常に等しく、正方形として表示されるように [{Binding} マークアップ拡張](binding-markup-extension.md) を使います。 Height のみが固定値として設定されます。 この **Rectangle** の既定の[**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) は**これ**ではなく **null** です。 そこで、データ コンテキストのソースをオブジェクト自体にするために (そして他のプロパティにバインドできるようにするために)、{Binding} マークアップ拡張の使用時に `RelativeSource={RelativeSource Self}` 引数を使います。

```XML
<Rectangle
  Fill="Orange" Width="200"
  Height="{Binding RelativeSource={RelativeSource Self}, Path=Width}"
/>
```

オブジェクトの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) を自分自身に設定する方法として `RelativeSource={RelativeSource Self}` を使うこともできます。  たとえば、独自のデータ バインドのために準備の完了したビュー モデルを既に提供しているカスタム プロパティによって [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラスが拡張されている SDK のサンプルで、この技法を確認できます。 `<common:LayoutAwarePage ... DataContext="{Binding DefaultViewModel, RelativeSource={RelativeSource Self}}">`

**注:** **RelativeSource**用の XAML の使用方法は対象となる使用方法のみを示しています。 バインド式の一部として XAML で[**Binding.RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831)の値を設定します。 ただし、値が [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209913) のプロパティを設定する場合は、理論的にそれ以外の使用法も可能です。

## <a name="related-topics"></a>関連トピック

* [XAML の概要](xaml-overview.md)
* [データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [{Binding} マークアップ拡張](binding-markup-extension.md)
* [**バインディング**](https://msdn.microsoft.com/library/windows/apps/br209820)
* [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209913)

