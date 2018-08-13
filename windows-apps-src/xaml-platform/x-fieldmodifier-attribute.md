---
author: jwmsft
description: XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定のプライベートの動作ではなくパブリック アクセスとして定義されるようにします。
title: xFieldModifier 属性
ms.assetid: 6FBCC00B-848D-4454-8B1F-287CA8406DDF
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: cad84be24836bc6a33a4ab08f1ca4fa2d9e97512
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "244546"
---
# <a name="xfieldmodifier-attribute"></a><span data-ttu-id="e3870-104">x:FieldModifier 属性</span><span class="sxs-lookup"><span data-stu-id="e3870-104">x:FieldModifier attribute</span></span>

<span data-ttu-id="e3870-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="e3870-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="e3870-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="e3870-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="e3870-107">XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定の**プライベート**の動作ではなく**パブリック** アクセスとして定義されるようにします。</span><span class="sxs-lookup"><span data-stu-id="e3870-107">Modifies XAML compilation behavior, such that fields for named object references are defined with **public** access rather than the **private** default behavior.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="e3870-108">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="e3870-108">XAML attribute usage</span></span>

``` syntax
<object x:FieldModifier="public".../>
```

## <a name="dependencies"></a><span data-ttu-id="e3870-109">依存関係</span><span class="sxs-lookup"><span data-stu-id="e3870-109">Dependencies</span></span>

<span data-ttu-id="e3870-110">[x:Name attribute](x-name-attribute.md) は、同じ要素で指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e3870-110">[x:Name attribute](x-name-attribute.md) must also be provided on the same element.</span></span>

## <a name="remarks"></a><span data-ttu-id="e3870-111">注釈</span><span class="sxs-lookup"><span data-stu-id="e3870-111">Remarks</span></span>

<span data-ttu-id="e3870-112">**x:FieldModifier** 属性の値はプログラミング言語によって異なります。</span><span class="sxs-lookup"><span data-stu-id="e3870-112">The value for the **x:FieldModifier** attribute will vary by programming language.</span></span> <span data-ttu-id="e3870-113">有効な値は、**private**、**public**、**protected**、**internal**、**friend** です。</span><span class="sxs-lookup"><span data-stu-id="e3870-113">Valid values are **private**, **public**, **protected**, **internal** or **friend**.</span></span> <span data-ttu-id="e3870-114">C#、Microsoft Visual Basic、または Visual C++ コンポーネント拡張機能 (C++/CX) では、文字列値 "public" または "Public" を指定できます。パーサーは、この属性値の大文字/小文字を区別しません。</span><span class="sxs-lookup"><span data-stu-id="e3870-114">For C#, Microsoft Visual Basic or Visual C++ component extensions (C++/CX), you can give the string value "public" or "Public"; the parser doesn't enforce case on this attribute value.</span></span>

<span data-ttu-id="e3870-115">既定値は **Private** アクセスです。</span><span class="sxs-lookup"><span data-stu-id="e3870-115">**Private** access is the default.</span></span>

<span data-ttu-id="e3870-116">**x:FieldModifier** は、[x:Name 属性](x-name-attribute.md)を含む要素にのみ関係します。なぜなら、この名前はパブリックであるときにのみフィールドを参照するために使われるためです。</span><span class="sxs-lookup"><span data-stu-id="e3870-116">**x:FieldModifier** is only relevant for elements with an [x:Name attribute](x-name-attribute.md), because that name is used to reference the field once it is public.</span></span>

<span data-ttu-id="e3870-117">**注:** Windows ランタイム XAML では、**x:ClassModifier** または **x:Subclass** はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e3870-117">**Note**  Windows Runtime XAML doesn't support **x:ClassModifier** or **x:Subclass**.</span></span>

