---
author: tbd
description: "XAML マークアップで、x:Bind の既定のモードを指定します"
title: "xDefaultBindMode マークアップ拡張"
ms.assetid: 
ms.author: 
ms.date: 
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 0fa037b4c59566cb1b9bacd4d2e36520a86c508d
ms.sourcegitcommit: ba0d20f6fad75ce98c25ceead78aab6661250571
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/24/2017
---
# <a name="xdefaultbindmode-markup-extension"></a><span data-ttu-id="13afe-104">{x:DefaultBindMode} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="13afe-104">{x:DefaultBindMode} markup extension</span></span>

<span data-ttu-id="13afe-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="13afe-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="13afe-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="13afe-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="13afe-107">XAML マークアップで、x:Bind の既定のモードを指定します。</span><span class="sxs-lookup"><span data-stu-id="13afe-107">In XAML markup, specifies a default mode for x:Bind.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="13afe-108">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="13afe-108">XAML attribute usage</span></span>

``` syntax
<object x:DefaultBindMode="OneTime \| OneWay \| TwoWay" .../>
```

## <a name="remarks"></a><span data-ttu-id="13afe-109">注釈</span><span class="sxs-lookup"><span data-stu-id="13afe-109">Remarks</span></span>

<span data-ttu-id="13afe-110">x:Bind の既定のモードは OneTime ですが、これはパフォーマンス上の理由から選ばれました。OneTime を使うと、接続して変更検出を処理するために生成されるコードが多くなります。</span><span class="sxs-lookup"><span data-stu-id="13afe-110">x:Bind has a default mode of OneTime, and this was chosen for performance reasons as using OneTime will cause more code to be generated to hookup and handle the change detection.</span></span> <span data-ttu-id="13afe-111">マークアップ ツリーの特定のセグメントで x:Bind の既定のモードを変更するには、**x:DefaultBindMode** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="13afe-111">**x:DefaultBindMode** can be used to change the default mode for x:Bind for a specific segment of the markup tree.</span></span> <span data-ttu-id="13afe-112">選択されたモードは、バインドの一部として明示的にモードが指定されている場合を除いて、対象の要素とその子に対するすべての x:Bind 式に適用されます。</span><span class="sxs-lookup"><span data-stu-id="13afe-112">The mode selected will apply any x:Bind expressions on that element and its children, that do not explicitly specify a mode as part of the binding.</span></span>

## <a name="related-topics"></a><span data-ttu-id="13afe-113">関連トピック</span><span class="sxs-lookup"><span data-stu-id="13afe-113">Related topics</span></span>

* [**<span data-ttu-id="13afe-114">x:Bind</span><span class="sxs-lookup"><span data-stu-id="13afe-114">x:Bind</span></span>**](https://docs.microsoft.com/en-us/windows/uwp/xaml-platform/x-bind-markup-extension)
