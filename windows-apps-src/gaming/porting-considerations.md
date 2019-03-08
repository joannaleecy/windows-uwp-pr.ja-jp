---
title: DirectX 9 から DirectX 11 および UWP への移行
description: このセクションでは、DirectX 9 のデスクトップ ゲームを DirectX 11 とユニバーサル Windows プラットフォーム (UWP) に移植する方法について説明します。
ms.assetid: 7a3f8ddf-d5b2-1c05-b532-70459befda4e
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 9, DirectX 11, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 90a9273c33dd45904e2050af02fd52ddeaedb7e5
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658227"
---
# <a name="moving-from-directx-9-to-directx-11-and-universal-windows-platform-uwp"></a><span data-ttu-id="64d3f-104">DirectX 9 から DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への移行</span><span class="sxs-lookup"><span data-stu-id="64d3f-104">Moving from DirectX 9 to DirectX 11 and Universal Windows Platform (UWP)</span></span>



<span data-ttu-id="64d3f-105">このセクションでは、DirectX 9 のデスクトップ ゲームを DirectX 11 とユニバーサル Windows プラットフォーム (UWP) に移植する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="64d3f-105">This section has guidance on porting your DirectX 9 desktop game to DirectX 11 and Universal Windows Platform (UWP).</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="64d3f-106">トピック</span><span class="sxs-lookup"><span data-stu-id="64d3f-106">Topic</span></span></th>
<th align="left"><span data-ttu-id="64d3f-107">説明</span><span class="sxs-lookup"><span data-stu-id="64d3f-107">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="64d3f-108"><a href="plan-your-directx-port.md">DirectX、ポートを計画します。</a></span><span class="sxs-lookup"><span data-stu-id="64d3f-108"><a href="plan-your-directx-port.md">Plan your DirectX port</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64d3f-109">DirectX 9 から DirectX 11 と UWP へのゲーム移植プロジェクトを計画してください。グラフィックス コードのアップグレードと、Windows ランタイム環境へのゲームの配置が必要です。</span><span class="sxs-lookup"><span data-stu-id="64d3f-109">Plan your game porting project from DirectX 9 to DirectX 11 and UWP: upgrade your graphics code, and put your game in the Windows Runtime environment.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="64d3f-110"><a href="understand-direct3d-11-1-concepts.md">Direct3D 11.1 Direct3D 9 からの重要な変更</a></span><span class="sxs-lookup"><span data-stu-id="64d3f-110"><a href="understand-direct3d-11-1-concepts.md">Important changes from Direct3D 9 to Direct3D 11.1</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64d3f-111">このトピックでは、DirectX 9 と DirectX 11 の大まかな違いについて説明します。</span><span class="sxs-lookup"><span data-stu-id="64d3f-111">This topic explains the high-level differences between DirectX 9 and DirectX 11.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="64d3f-112"><a href="feature-mapping.md">DirectX 9 の機能を DirectX 11.1 Api にマップします。</a></span><span class="sxs-lookup"><span data-stu-id="64d3f-112"><a href="feature-mapping.md">Map DirectX 9 features to DirectX 11.1 APIs</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64d3f-113">Direct3D 9 ゲームで使う機能が Direct3D 11 と UWP にどのように変換されるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="64d3f-113">Understand how the features your Direct3D 9 game uses will translate to Direct3D 11 and the UWP.</span></span></p></td>
</tr>
</tbody>
</table>

 

 

 




