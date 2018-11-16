---
author: mtoepke
title: DirectX 9 からユニバーサル Windows プラットフォーム (UWP) への移植
description: このセクションでは、ユニバーサル Windows プラットフォーム (UWP) に DirectX 9 ゲームを移植する方法を説明した記事、概要、チュートリアルを紹介します。
ms.assetid: 536c0b99-cdf3-1527-1ee2-4187f50a2cf0
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX 9, DirectX 11, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 05549b0f3696067689f7e8fbd05dfb0f8f1bb528
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6845240"
---
# <a name="port-from-directx-9-to-universal-windows-platform-uwp"></a><span data-ttu-id="9452d-104">DirectX 9 からユニバーサル Windows プラットフォーム (UWP) への移植</span><span class="sxs-lookup"><span data-stu-id="9452d-104">Port from DirectX 9 to Universal Windows Platform (UWP)</span></span>



<span data-ttu-id="9452d-105">このセクションでは、ユニバーサル Windows プラットフォーム (UWP) に DirectX 9 ゲームを移植する方法を説明した記事、概要、チュートリアルを紹介します。</span><span class="sxs-lookup"><span data-stu-id="9452d-105">This section includes articles, overviews, and walkthroughs for porting DirectX 9 games to Universal Windows Platform (UWP).</span></span>

##  <a name="port-your-directx-9-game-to-uwp"></a><span data-ttu-id="9452d-106">UWP への DirectX 9 ゲームの移植</span><span class="sxs-lookup"><span data-stu-id="9452d-106">Port your DirectX 9 game to UWP</span></span>


-   <span data-ttu-id="9452d-107">UWP のユーザーにゲームを販売し、収益を得る。</span><span class="sxs-lookup"><span data-stu-id="9452d-107">Reach the UWP audiences and monetize your game.</span></span>
-   <span data-ttu-id="9452d-108">さまざまなデバイスをターゲットにし、そのすべてで少なくとも Direct3D 9.1 のグラフィックス機能セットをサポートする。</span><span class="sxs-lookup"><span data-stu-id="9452d-108">Target a wide array of devices, all of which support at least the Direct3D 9.1 set of graphics features.</span></span>
-   <span data-ttu-id="9452d-109">Direct3D 11、統合シェーダー モデル、Windows API、XAudio2、タッチ入力、C++/CX など、重要な新しい Windows ゲーム開発スキルを学ぶ。</span><span class="sxs-lookup"><span data-stu-id="9452d-109">Learn valuable new Windows game development skills - including Direct3D 11, the unified shader models, Windows APIs, XAudio2, touch input, C++/CX and more.</span></span>

## <a name="where-do-i-start"></a><span data-ttu-id="9452d-110">はじめに</span><span class="sxs-lookup"><span data-stu-id="9452d-110">Where do I start?</span></span>


-   <span data-ttu-id="9452d-111">ゲームの移植プロジェクトで計画する必要がある事項、Direct3D 11 の概念の確認、使い慣れた機能と DirectX 11 UWP アプリの対応の理解については、「[DirectX 9 から DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への移行](porting-considerations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9452d-111">Visit [Moving from DirectX 9 to DirectX 11 and UWP](porting-considerations.md) to learn what you should plan for in your game porting project, catch up on Direct3D 11 concepts, and understand how the features you're familiar with map to DirectX 11 UWP apps.</span></span>
-   <span data-ttu-id="9452d-112">Direct3D 9 と Direct3D 11 のグラフィックス フレームワークを直接比較するには、「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」に従ってください。</span><span class="sxs-lookup"><span data-stu-id="9452d-112">Follow the [Port a simple Direct3D 9 app to DirectX 11 and UWP](walkthrough--simple-port-from-direct3d-9-to-11-1.md) walkthrough article for a direct comparison of Direct3D 9 and Direct3D 11 graphics frameworks.</span></span> <span data-ttu-id="9452d-113">また、このチュートリアルには、アプリ ウィンドウとビューポートを設定するコードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="9452d-113">This walkthrough also has code for setting up an app window and viewport.</span></span>
-   <span data-ttu-id="9452d-114">DirectX 9 からの移植に関する一般的な質問への回答については、「[DirectX 11 の移植に関する FAQ](directx-porting-faq.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9452d-114">See the [DirectX 11 porting FAQ](directx-porting-faq.md) for answers to common questions about porting from DirectX 9.</span></span>

 

 




