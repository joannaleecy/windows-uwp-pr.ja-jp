---
description: XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定のプライベートの動作ではなくパブリック アクセスとして定義されるようにします。
title: xFieldModifier 属性
ms.assetid: 6FBCC00B-848D-4454-8B1F-287CA8406DDF
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 751cda36fc58d0e6add9204327a74ec947c9fc53
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660917"
---
# <a name="xfieldmodifier-attribute"></a>x:FieldModifier 属性


XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定の**プライベート**の動作ではなく**パブリック** アクセスとして定義されるようにします。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object x:FieldModifier="public".../>
```

## <a name="dependencies"></a>依存関係

[x:Name attribute](x-name-attribute.md) は、同じ要素で指定する必要があります。

## <a name="remarks"></a>注釈

**x:FieldModifier** 属性の値はプログラミング言語によって異なります。 有効な値は、**private**、**public**、**protected**、**internal**、**friend** です。 C#、Microsoft Visual Basic または Visual C コンポーネント拡張 (C +/cli CX)、文字列を与えることができます"public"または「パブリック」の値パーサーは、この属性値の大文字と小文字を強制しません。

既定値は **Private** アクセスです。

**x:FieldModifier** は、[x:Name 属性](x-name-attribute.md)を含む要素にのみ関係します。なぜなら、この名前はパブリックであるときにのみフィールドを参照するために使われるためです。

**注**  Windows ランタイムの XAML をサポートしていない**X:classmodifier**または**X:subclass**します。

