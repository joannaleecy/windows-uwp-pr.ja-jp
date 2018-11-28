---
description: XAML マークアップで、プロパティに null 値を指定します。
title: xNull マークアップ拡張
ms.assetid: E6A4038E-4ADA-4E82-9824-582FC16AB037
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f0d6fd8f194a3c9c98fb969034cab5a3e9e2f0de
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7837481"
---
# <a name="xnull-markup-extension"></a>{x:Null} マークアップ拡張


XAML マークアップで、プロパティに **null** 値を指定します。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object property="{x:Null}" .../>
```

## <a name="remarks"></a>注釈

**null** は、C# と C++ の null 参照キーワードです。 Microsoft Visual Basic の null 参照キーワードは **Nothing** です。

初期の既定値は、依存関係プロパティごとに異なる場合があり、必ずしも **null** というわけではありません。 また、依存関係プロパティの多くは、その内部実装により、(マークアップまたはコードのいずれによる場合でも) **null** を値として受け入れません。 このような場合、**{x:Null}** で XAML 属性値を設定すると、パーサー例外が発生することがあります。

一部の Windows ランタイム型では、null を使うことができます。 null 許容型に **null** が既定値として設定されていない場合に備え、**{x:Null}** を使って XAML 内で **null** 値に設定することができます。 VisualC ではコンポーネント拡張機能を使用している場合 (、C++/cli CX)、null 許容型として表されます[**platform::ibox<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/jj606120.aspx)します。 Microsoft .NET 言語を使う場合、null 許容型は [**Nullable<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx) として表されます。

## <a name="related-topics"></a>関連トピック

* [**Nullable<T>**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx)
* [**IReference<T>**](https://msdn.microsoft.com/library/windows/apps/br225864)
 

