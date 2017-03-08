---
author: jwmsft
description: "XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定のプライベートの動作ではなくパブリック アクセスとして定義されるようにします。"
title: "xFieldModifier 属性"
ms.assetid: 6FBCC00B-848D-4454-8B1F-287CA8406DDF
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 2c1bf910303f0c26761a3c63c3e1159dd2d0c6bb
ms.lasthandoff: 02/07/2017

---

# <a name="xfieldmodifier-attribute"></a>x:FieldModifier 属性

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定の**プライベート**の動作ではなく**パブリック** アクセスとして定義されるようにします。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object x:FieldModifier="public".../>
```

## <a name="dependencies"></a>依存関係

[x:Name attribute](x-name-attribute.md) は、同じ要素で指定する必要があります。

## <a name="remarks"></a>注釈

**x:FieldModifier** 属性の値はプログラミング言語によって異なります。 有効な値は、**private**、**public**、**protected**、**internal**、**friend** です。 C#、Microsoft Visual Basic、または Visual C++ コンポーネント拡張機能 (C++/CX) では、文字列値 "public" または "Public" を指定できます。パーサーは、この属性値の大文字/小文字を区別しません。

既定値は **Private** アクセスです。

**x:FieldModifier** は、[x:Name 属性](x-name-attribute.md)を含む要素にのみ関係します。なぜなら、この名前はパブリックであるときにのみフィールドを参照するために使われるためです。

**注:** Windows ランタイム XAML では、**x:ClassModifier** または **x:Subclass** はサポートされていません。


