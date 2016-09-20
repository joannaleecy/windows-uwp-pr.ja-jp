---
author: jwmsft
description: "ランタイム オブジェクト グラフの相対関係に関するバインドのソースを指定する手段を提供します。"
title: "RelativeSource マークアップ拡張"
ms.assetid: B87DEF36-BE1F-4C16-B32E-7A896BD09272
ms.sourcegitcommit: ec4c9b87655425e82a1cb792d0acc6bee265e9d2
ms.openlocfilehash: 9f0bb49e701806f8635d93fa495cdab6486a4ea3

---

# {RelativeSource} マークアップ拡張

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

ランタイム オブジェクト グラフの相対関係に関するバインドのソースを指定する手段を提供します。

## XAML 属性の使用方法 (Self モード)

``` syntax
<Binding RelativeSource="{RelativeSource Self}" .../>
-or-
<object property="{Binding RelativeSource={RelativeSource Self} ...}" .../>
```

## XAML 属性の使用方法 (TemplatedParent モード)

``` syntax
<Binding RelativeSource="{RelativeSource TemplatedParent}" .../>
-or-
<object property="{Binding RelativeSource={RelativeSource TemplatedParent} ...}" .../>
```

## XAML 値

| 用語 | 説明 |
|------|-------------|
| {RelativeSource Self} | <strong>Self</strong> の [<strong>Mode</strong>](https://msdn.microsoft.com/library/windows/apps/br209915) 値を生成します。 ターゲット要素をこのバインドのソースとして使う必要があります。 要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合に便利です。 |
| {RelativeSource TemplatedParent} | このバインドのソースとして適用される [<strong>ControlTemplate</strong>](https://msdn.microsoft.com/library/windows/apps/br209391) を生成します。 ランタイム情報をテンプレート レベルでバインドに適用する場合に便利です。 | 

## 注釈

[**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) では、**Binding** オブジェクト要素の属性または [{Binding} マークアップ拡張](binding-markup-extension.md)内のコンポーネントとして [**Binding.RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831) を設定できます。 これが、2 つの異なる XAML 構文が示されている理由です。


            **RelativeSource** は [{Binding} マークアップ拡張](binding-markup-extension.md)に似ています。  具体的には、自分自身のインスタンスを返すことができ、基本的に引数をコンストラクターに渡す文字列ベースの構築をサポートできるマークアップ拡張機能であるという点です。 この場合、渡される引数は [**Mode**](https://msdn.microsoft.com/library/windows/apps/br209915) 値になります。

**Self** モードは、要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合に便利です。これは、要素の名前の指定の後に自己参照を必要としない、[**ElementName**](https://msdn.microsoft.com/library/windows/apps/br209828) バインドの 1 つのバリエーションです。 要素の 1 つのプロパティを同じ要素の別のプロパティにバインドする場合、プロパティで同じプロパティの型を使うか、またはバインドに対して [**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826) を使って値を変換する必要があります。 たとえば、[**Height**](https://msdn.microsoft.com/library/windows/apps/br208718) は変換せずに [**Width**](https://msdn.microsoft.com/library/windows/apps/br208751) のソースとして使用できますが、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/br209419) のソースとして [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/br209006) を使う場合には、コンバーターが必要です。

次に例を示します。 この [**Rectangle**](https://msdn.microsoft.com/library/windows/apps/br243371) は [**Height**](https://msdn.microsoft.com/library/windows/apps/br208718) と [**Width**](https://msdn.microsoft.com/library/windows/apps/br208751) が常に等しく、正方形として表示されるように [{Binding} マークアップ拡張](binding-markup-extension.md) を使います。 Height のみが固定値として設定されます。 この **Rectangle** の既定の[**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) は**これ**ではなく **null** です。 そこで、データ コンテキストのソースをオブジェクト自体にするために (そして他のプロパティにバインドできるようにするために)、{Binding} マークアップ拡張の使用時に `RelativeSource={RelativeSource Self}` 引数を使います。

```XML
<Rectangle
  Fill="Orange" Width="200"
  Height="{Binding RelativeSource={RelativeSource Self}, Path=Width}"
/>
```

オブジェクトの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) を自分自身に設定する方法として `RelativeSource={RelativeSource Self}` を使うこともできます。  たとえば、独自のデータ バインドのために準備の完了したビュー モデルを既に提供しているカスタム プロパティによって [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラスが拡張されている SDK のサンプルで、この技法を確認できます。 `<common:LayoutAwarePage ... DataContext="{Binding DefaultViewModel, RelativeSource={RelativeSource Self}}">`


            **注**  XAML での **RelativeSource** の使用法には、意図されている使用法、つまり、バインド式の一部として XAML で [**Binding.RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209831) の値を設定する方法のみが示されています。 ただし、値が [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209913) のプロパティを設定する場合は、理論的にそれ以外の使用法も可能です。

## 関連トピック

* [XAML の概要](xaml-overview.md)
* [データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [{Binding} マークアップ拡張](binding-markup-extension.md)
* [**バインディング**](https://msdn.microsoft.com/library/windows/apps/br209820)
* [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/br209913)




<!--HONumber=Jun16_HO5-->


