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
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5682846"
---
# <a name="xdefaultbindmode-attribute"></a><span data-ttu-id="363f5-104">x:DefaultBindMode 属性</span><span class="sxs-lookup"><span data-stu-id="363f5-104">x:DefaultBindMode attribute</span></span>

<span data-ttu-id="363f5-105">XAML マークアップで、x:Bind の既定のモードを指定します。</span><span class="sxs-lookup"><span data-stu-id="363f5-105">In XAML markup, specifies a default mode for x:Bind.</span></span>

<span data-ttu-id="363f5-106">**x:DefaultBindMode** は、Windows 10 バージョン 1607 (Anniversary Update) SDK バージョン 14393 以降で使用できます。</span><span class="sxs-lookup"><span data-stu-id="363f5-106">**x:DefaultBindMode** is available starting in Windows 10, version 1607 (Anniversary Update), SDK version 14393.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="363f5-107">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="363f5-107">XAML attribute usage</span></span>

``` syntax
<object x:DefaultBindMode="OneTime \| OneWay \| TwoWay" .../>
```

## <a name="remarks"></a><span data-ttu-id="363f5-108">注釈</span><span class="sxs-lookup"><span data-stu-id="363f5-108">Remarks</span></span>

<span data-ttu-id="363f5-109">[x:Bind](x-bind-markup-extension.md) の既定のモードは **OneTime** です。</span><span class="sxs-lookup"><span data-stu-id="363f5-109">[x:Bind](x-bind-markup-extension.md) has a default mode of **OneTime**.</span></span> <span data-ttu-id="363f5-110">これはパフォーマンス上の理由から選ばれました。**OneWay** を使うと、接続して変更検出を処理するために生成されるコードが多くなるためです。</span><span class="sxs-lookup"><span data-stu-id="363f5-110">This was chosen for performance reasons, as using **OneWay** causes more code to be generated to hookup and handle change detection.</span></span> <span data-ttu-id="363f5-111">マークアップ ツリーの特定のセグメントで x:Bind の既定のモードを変更するには、**x:DefaultBindMode** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="363f5-111">You can use **x:DefaultBindMode** to change the default mode for x:Bind for a specific segment of the markup tree.</span></span> <span data-ttu-id="363f5-112">指定されたモードは、バインドの一部として明示的にモードが指定されている場合を除いて、対象の要素とその子に対するすべての x:Bind 式に適用されます。</span><span class="sxs-lookup"><span data-stu-id="363f5-112">The specified mode applies to any x:Bind expressions on that element and its children, that do not explicitly specify a mode as part of the binding.</span></span>

## <a name="related-topics"></a><span data-ttu-id="363f5-113">関連トピック</span><span class="sxs-lookup"><span data-stu-id="363f5-113">Related topics</span></span>

* [<span data-ttu-id="363f5-114">x:Bind マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="363f5-114">x:Bind markup extension</span></span>](x-bind-markup-extension.md)
