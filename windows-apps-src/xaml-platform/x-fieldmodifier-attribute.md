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
# <a name="xfieldmodifier-attribute"></a><span data-ttu-id="b906a-104">x:FieldModifier 属性</span><span class="sxs-lookup"><span data-stu-id="b906a-104">x:FieldModifier attribute</span></span>


<span data-ttu-id="b906a-105">XAML コンパイルの動作を変更して、名前付きオブジェクトの参照のフィールドが、既定の**プライベート**の動作ではなく**パブリック** アクセスとして定義されるようにします。</span><span class="sxs-lookup"><span data-stu-id="b906a-105">Modifies XAML compilation behavior, such that fields for named object references are defined with **public** access rather than the **private** default behavior.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="b906a-106">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="b906a-106">XAML attribute usage</span></span>

``` syntax
<object x:FieldModifier="public".../>
```

## <a name="dependencies"></a><span data-ttu-id="b906a-107">依存関係</span><span class="sxs-lookup"><span data-stu-id="b906a-107">Dependencies</span></span>

<span data-ttu-id="b906a-108">[x:Name attribute](x-name-attribute.md) は、同じ要素で指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b906a-108">[x:Name attribute](x-name-attribute.md) must also be provided on the same element.</span></span>

## <a name="remarks"></a><span data-ttu-id="b906a-109">注釈</span><span class="sxs-lookup"><span data-stu-id="b906a-109">Remarks</span></span>

<span data-ttu-id="b906a-110">**x:FieldModifier** 属性の値はプログラミング言語によって異なります。</span><span class="sxs-lookup"><span data-stu-id="b906a-110">The value for the **x:FieldModifier** attribute will vary by programming language.</span></span> <span data-ttu-id="b906a-111">有効な値は、**private**、**public**、**protected**、**internal**、**friend** です。</span><span class="sxs-lookup"><span data-stu-id="b906a-111">Valid values are **private**, **public**, **protected**, **internal** or **friend**.</span></span> <span data-ttu-id="b906a-112">C#、Microsoft Visual Basic または Visual C コンポーネント拡張 (C +/cli CX)、文字列を与えることができます"public"または「パブリック」の値パーサーは、この属性値の大文字と小文字を強制しません。</span><span class="sxs-lookup"><span data-stu-id="b906a-112">For C#, Microsoft Visual Basic or Visual C++ component extensions (C++/CX), you can give the string value "public" or "Public"; the parser doesn't enforce case on this attribute value.</span></span>

<span data-ttu-id="b906a-113">既定値は **Private** アクセスです。</span><span class="sxs-lookup"><span data-stu-id="b906a-113">**Private** access is the default.</span></span>

<span data-ttu-id="b906a-114">**x:FieldModifier** は、[x:Name 属性](x-name-attribute.md)を含む要素にのみ関係します。なぜなら、この名前はパブリックであるときにのみフィールドを参照するために使われるためです。</span><span class="sxs-lookup"><span data-stu-id="b906a-114">**x:FieldModifier** is only relevant for elements with an [x:Name attribute](x-name-attribute.md), because that name is used to reference the field once it is public.</span></span>

<span data-ttu-id="b906a-115">**注**  Windows ランタイムの XAML をサポートしていない**X:classmodifier**または**X:subclass**します。</span><span class="sxs-lookup"><span data-stu-id="b906a-115">**Note**  Windows Runtime XAML doesn't support **x:ClassModifier** or **x:Subclass**.</span></span>

