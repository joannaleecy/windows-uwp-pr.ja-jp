---
author: mtoepke
title: グラフィックス診断ツール
description: Visual Studio でグラフィックス デバッグ、グラフィックス フレーム分析、GPU 使用率などのグラフィックス診断機能を取得して使用する方法について説明します。
ms.assetid: 629ea462-18ed-a333-07e9-cc87ea2dcd93
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, グラフィックス, 診断, ツール, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: aa1c14d15a966f23b86753cf8e5e62e067d10310
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7433899"
---
# <a name="graphics-diagnostics-tools"></a><span data-ttu-id="4570f-104">グラフィックス診断ツール</span><span class="sxs-lookup"><span data-stu-id="4570f-104">Graphics diagnostics tools</span></span>



<span data-ttu-id="4570f-105">Windows 10 では、グラフィックス診断ツールにで Windows 内から利用できるオプション機能として。</span><span class="sxs-lookup"><span data-stu-id="4570f-105">With Windows10, the graphics diagnostic tools are now available from within Windows as an optional feature.</span></span> <span data-ttu-id="4570f-106">DirectX のアプリやゲームを開発するために、ランタイムや Visual Studio で提供されるグラフィックス診断機能を使うには、次の手順に従ってオプションのグラフィックス ツール機能をインストールします。</span><span class="sxs-lookup"><span data-stu-id="4570f-106">To use the graphics diagnostic features provided in the runtime and Visual Studio to develop DirectX apps or games, install the optional Graphics Tools feature:</span></span>

1.  <span data-ttu-id="4570f-107">**設定**に移動し、**アプリ**を選択し、**オプション機能の管理**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4570f-107">Go to **Settings**, select **Apps**, and then click **Manage optional features**.</span></span>
2.  <span data-ttu-id="4570f-108">**[機能の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4570f-108">Click **Add a feature**</span></span>   
3.  <span data-ttu-id="4570f-109">**[オプション機能]** の一覧から **[グラフィックス ツール]** を選び、**[インストール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4570f-109">In the **Optional features** list, select **Graphics Tools** and then click **Install**.</span></span>

<span data-ttu-id="4570f-110">グラフィックス診断機能には、DirectX ランタイム、またグラフィックス デバッグ、フレーム分析、GPU 使用率で Direct3D SDK デバッグ デバイス (Direct3D SDK レイヤー経由) を作成する機能が備わっています。</span><span class="sxs-lookup"><span data-stu-id="4570f-110">Graphics diagnostics features include the ability to create Direct3D debug devices (via Direct3D SDK Layers) in the DirectX runtime, plus Graphics Debugging, Frame Analysis, and GPU Usage.</span></span>

-   <span data-ttu-id="4570f-111">グラフィックス デバッグ機能を使うと、アプリによる Direct3D 呼び出しをトレースできます。</span><span class="sxs-lookup"><span data-stu-id="4570f-111">Graphics Debugging lets you trace the Direct3D calls being made by your app.</span></span> <span data-ttu-id="4570f-112">これらの呼び出しを再生し、パラメーターを調べることで、また、シェーダーのデバッグや検証を実行したり、グラフィックス アセットを視覚化したりすることでレンダリングの問題を診断することもできます。</span><span class="sxs-lookup"><span data-stu-id="4570f-112">Then, you can replay those calls, inspect parameters, debug and experiment with shaders, and visualize graphics assets to diagnose rendering issues.</span></span> <span data-ttu-id="4570f-113">Windows PC、シミュレーター、またはデバイスでログを収集し、別のハードウェアで再生できます。</span><span class="sxs-lookup"><span data-stu-id="4570f-113">Logs can be taken on Windows PCs, simulators, or devices, and be played back on different hardware.</span></span>
-   <span data-ttu-id="4570f-114">Visual Studio のグラフィックス フレーム分析機能は、グラフィックス デバッグ ログに対して実行され、Direct3D 描画呼び出しのベースライン タイミングを収集します。</span><span class="sxs-lookup"><span data-stu-id="4570f-114">Graphics Frame Analysis in Visual Studio runs on a graphics debugging log and gathers baseline timing for the Direct3D draw calls.</span></span> <span data-ttu-id="4570f-115">また、さまざまなグラフィックス設定を変更して一連の検証を行い、タイミング結果のテーブルを生成します。</span><span class="sxs-lookup"><span data-stu-id="4570f-115">It then performs a set of experiments by modifying various graphics settings and produces a table of timing results.</span></span> <span data-ttu-id="4570f-116">このデータを使うと、アプリのグラフィックス パフォーマンスに関する問題点を把握し、さまざまな検証の結果を確認して、パフォーマンス向上の可能性を探ることができます。</span><span class="sxs-lookup"><span data-stu-id="4570f-116">You can use this data to understand graphics performance issues in your app, and you can review results of the various experiments to identify opportunities for performance improvements.</span></span>
-   <span data-ttu-id="4570f-117">Visual Studio の GPU 使用率では、リアルタイムで GPU の使用状況を監視できます。</span><span class="sxs-lookup"><span data-stu-id="4570f-117">GPU Usage in Visual Studio allows you to monitor GPU use in real time.</span></span> <span data-ttu-id="4570f-118">CPU や GPU で処理されるワークロードのタイミング データを収集し分析することで、ボトルネックがどこにあるかを特定できます。</span><span class="sxs-lookup"><span data-stu-id="4570f-118">It collects and analyzes the timing data of the workloads being handled by the CPU and GPU, so you can determine where the bottlenecks are.</span></span>

## <a name="related-topics"></a><span data-ttu-id="4570f-119">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4570f-119">Related topics</span></span>


[<span data-ttu-id="4570f-120">Visual Studio でのグラフィックス診断の概要</span><span class="sxs-lookup"><span data-stu-id="4570f-120">Graphics Diagnostics Overview in Visual Studio</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=526382)

 

 




