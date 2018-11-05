---
author: jwmsft
description: XAML マークアップで、x:Bind の既定のモードを指定します。
title: xDefaultBindMode 属性
ms.author: jimwalk
ms.date: 02/08/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 2696cb46591757421795b15083ea7fdab54943c5
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6035438"
---
# <a name="xdefaultbindmode-attribute"></a>x:DefaultBindMode 属性

XAML マークアップで、x:Bind の既定のモードを指定します。

**x:DefaultBindMode** は、Windows 10 バージョン 1607 (Anniversary Update) SDK バージョン 14393 以降で使用できます。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object x:DefaultBindMode="OneTime \| OneWay \| TwoWay" .../>
```

## <a name="remarks"></a>注釈

[x:Bind](x-bind-markup-extension.md) の既定のモードは **OneTime** です。 これはパフォーマンス上の理由から選ばれました。**OneWay** を使うと、接続して変更検出を処理するために生成されるコードが多くなるためです。 マークアップ ツリーの特定のセグメントで x:Bind の既定のモードを変更するには、**x:DefaultBindMode** を使用できます。 指定されたモードは、バインドの一部として明示的にモードが指定されている場合を除いて、対象の要素とその子に対するすべての x:Bind 式に適用されます。

## <a name="related-topics"></a>関連トピック

* [x:Bind マークアップ拡張](x-bind-markup-extension.md)
