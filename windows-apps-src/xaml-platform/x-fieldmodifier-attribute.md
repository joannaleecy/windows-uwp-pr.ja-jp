---
description: 名前付きオブジェクトの参照のフィールドがプライベートの既定の動作ではなくパブリックのアクセスで定義されるように、XAML コンパイルの動作を変更します。
title: xFieldModifier 属性
ms.assetid: 6FBCC00B-848D-4454-8B1F-287CA8406DDF
---

# x:FieldModifier 属性

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

名前付きオブジェクトの参照のフィールドが**プライベート**の既定の動作ではなく**パブリック**のアクセスで定義されるように、XAML コンパイルの動作を変更します。

## XAML 属性の使用方法

``` syntax
<object x:FieldModifier="public".../>
```

## 依存関係

[x:Name attribute](x-name-attribute.md) は、同じ要素で指定する必要があります。

## 注釈

**x:FieldModifier** 属性の値はプログラミング言語によって異なります。 使われる文字列は、各言語で **CodeDomProvider** が実装される方法と、**TypeAttributes.Public** と **TypeAttributes.NotPublic** の意味を定義するために各言語で返される型コンバーターによって異なります。 C#、Microsoft Visual Basic、または Visual C++ コンポーネント拡張機能 (C++/CX) では、文字列値 "public" または "Public" を指定できます。パーサーは、この属性値の大文字/小文字を区別しません。

**NonPublic** (C# または C++/CX では **internal**、Visual Basic では **Friend**) を指定することもできますが、一般的な方法ではありません。 Windows ランタイム XAML コード生成モデルには、内部アクセスの用途はありません。 プライベート アクセスが既定です。

**x:FieldModifier** は、[x:Name 属性](x-name-attribute.md)を含む要素にのみ関係します。なぜなら、この名前はパブリックであるときにのみフィールドを参照するために使われるためです。

**注**  Windows ランタイム XAML では、**x:ClassModifier** または **x:Subclass** はサポートされていません。



<!--HONumber=Mar16_HO1-->


