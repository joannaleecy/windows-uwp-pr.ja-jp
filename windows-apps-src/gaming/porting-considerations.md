---
author: mtoepke
title: DirectX 9 から DirectX 11 および UWP への移行
description: このセクションでは、DirectX 9 のデスクトップ ゲームを DirectX 11 とユニバーサル Windows プラットフォーム (UWP) に移植する方法について説明します。
ms.assetid: 7a3f8ddf-d5b2-1c05-b532-70459befda4e
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 9, DirectX 11, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 4e867129b5f684c7e77aebefcbe9a3f68b47b031
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6861235"
---
# <a name="moving-from-directx-9-to-directx-11-and-universal-windows-platform-uwp"></a><span data-ttu-id="f661c-104">DirectX 9 から DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への移行</span><span class="sxs-lookup"><span data-stu-id="f661c-104">Moving from DirectX 9 to DirectX 11 and Universal Windows Platform (UWP)</span></span>



<span data-ttu-id="f661c-105">このセクションでは、DirectX 9 のデスクトップ ゲームを DirectX 11 とユニバーサル Windows プラットフォーム (UWP) に移植する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f661c-105">This section has guidance on porting your DirectX 9 desktop game to DirectX 11 and Universal Windows Platform (UWP).</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="f661c-106">トピック</span><span class="sxs-lookup"><span data-stu-id="f661c-106">Topic</span></span></th>
<th align="left"><span data-ttu-id="f661c-107">説明</span><span class="sxs-lookup"><span data-stu-id="f661c-107">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="plan-your-directx-port.md"><span data-ttu-id="f661c-108">DirectX の移植の計画</span><span class="sxs-lookup"><span data-stu-id="f661c-108">Plan your DirectX port</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f661c-109">DirectX 9 から DirectX 11 と UWP へ、ゲーム移植プロジェクトを計画しましょう。グラフィックス コードをアップグレードして、ゲームを Windows ランタイム環境に置くことが必要になります。</span><span class="sxs-lookup"><span data-stu-id="f661c-109">Plan your game porting project from DirectX 9 to DirectX 11 and UWP: upgrade your graphics code, and put your game in the Windows Runtime environment.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="understand-direct3d-11-1-concepts.md"><span data-ttu-id="f661c-110">Direct3D 9 と Direct3D 11.1 の間の重要な変更点</span><span class="sxs-lookup"><span data-stu-id="f661c-110">Important changes from Direct3D 9 to Direct3D 11.1</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f661c-111">このトピックでは、DirectX 9 と DirectX 11 の大まかな違いについて説明します。</span><span class="sxs-lookup"><span data-stu-id="f661c-111">This topic explains the high-level differences between DirectX 9 and DirectX 11.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="feature-mapping.md"><span data-ttu-id="f661c-112">DirectX 11.1 API への DirectX 9 の機能のマッピング</span><span class="sxs-lookup"><span data-stu-id="f661c-112">Map DirectX 9 features to DirectX 11.1 APIs</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f661c-113">Direct3D 9 ゲームで使う機能が Direct3D 11 と UWP にどのように変換されるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="f661c-113">Understand how the features your Direct3D 9 game uses will translate to Direct3D 11 and the UWP.</span></span></p></td>
</tr>
</tbody>
</table>

 

 

 




