---
author: JordanEllis6809
title: ユニバーサル Windows プラットフォーム (UWP) を使用した Xbox での C++ ゲーム開発
description: Xbox での C++ UWP ゲーム開発。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 6ae36021-94d3-43df-9e96-69a93cfe8b56
ms.localizationpriority: medium
ms.openlocfilehash: 2871e9f1a17bb96ddb601ab6d8446641e05b8ead
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "300366"
---
# <a name="bring-custom-c-games-to-uwp-on-xbox"></a><span data-ttu-id="189af-104">Xbox で UWP にユーザー設定の C++ ゲームを取り込む</span><span class="sxs-lookup"><span data-stu-id="189af-104">Bring custom C++ games to UWP on Xbox</span></span>

<span data-ttu-id="189af-105">カスタム C++ エンジンを作成する場合、Xbox One では C++ が完全にサポートされています。</span><span class="sxs-lookup"><span data-stu-id="189af-105">If you are writing a custom C++ engine, Xbox One has full support for C++.</span></span> 

<span data-ttu-id="189af-106">ユニバーサル Windows プラットフォーム (UWP) の C++ ゲームは、レンダリングに DirectX を使用します。</span><span class="sxs-lookup"><span data-stu-id="189af-106">C++ games on the Universal Windows Platform (UWP) use DirectX for rendering.</span></span> <span data-ttu-id="189af-107">詳しくは、「[DirectX のグラフィックスとゲーミング](https://msdn.microsoft.com/library/windows/desktop/ee663274(v=vs.85).aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="189af-107">Learn more at [DirectX Graphics and Gaming](https://msdn.microsoft.com/library/windows/desktop/ee663274(v=vs.85).aspx).</span></span>

<span data-ttu-id="189af-108">開発には、[C++ コンポーネント拡張機能](https://msdn.microsoft.com/library/windows/apps/hh699871.aspx) (C++/CX) または[標準 C++](https://msdn.microsoft.com/library/windows/apps/mt592904.aspx) (Win32 と COM) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="189af-108">You can write [C++ with component extensions](https://msdn.microsoft.com/library/windows/apps/hh699871.aspx) (C++/CX) or [standard C++](https://msdn.microsoft.com/library/windows/apps/mt592904.aspx) (Win32 and COM).</span></span>

<span data-ttu-id="189af-109">コンソールを開発キットとして使用する方法と Visual Studio から展開する方法については、「[ゲームと DirectX](../gaming/index.md)」および「[ファースト ステップ ガイド](getting-started.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="189af-109">To learn how to turn your console into a development kit and how to deploy from Visual Studio, see [Games and DirectX](../gaming/index.md) and the [getting started](getting-started.md) guide.</span></span>

> [!NOTE]
> <span data-ttu-id="189af-110">現時点では、Xbox One で DirectX 12 はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="189af-110">Xbox One does not support DirectX 12 at this time.</span></span>


## <a name="see-also"></a><span data-ttu-id="189af-111">関連項目</span><span class="sxs-lookup"><span data-stu-id="189af-111">See also</span></span>
- [<span data-ttu-id="189af-112">既存のゲームの Xbox への移行</span><span class="sxs-lookup"><span data-stu-id="189af-112">Bringing existing games to Xbox</span></span>](development-lanes-landing.md)
- [<span data-ttu-id="189af-113">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="189af-113">UWP on Xbox One</span></span>](index.md)

