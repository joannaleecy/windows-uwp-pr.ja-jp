---
description: XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定のプライベートの動作ではなくパブリック アクセスとして定義されるようにします。
title: xFieldModifier 属性
ms.assetid: 6FBCC00B-848D-4454-8B1F-287CA8406DDF
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 751cda36fc58d0e6add9204327a74ec947c9fc53
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8345796"
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

**x:FieldModifier** 属性の値はプログラミング言語によって異なります。 有効な値は、**private**、**public**、**protected**、**internal**、**friend** です。 C#、Microsoft Visual Basic または VisualC ではコンポーネント拡張機能 (、C++/cli CX)、文字列を提供する値"public"または"Public"パーサーには、この属性の値の大文字を区別しません。

既定値は **Private** アクセスです。

**x:FieldModifier** は、[x:Name 属性](x-name-attribute.md)を含む要素にのみ関係します。なぜなら、この名前はパブリックであるときにのみフィールドを参照するために使われるためです。

**注:** **X:classmodifier**または**X:subclass**Windows ランタイム XAML はサポートしていません。

