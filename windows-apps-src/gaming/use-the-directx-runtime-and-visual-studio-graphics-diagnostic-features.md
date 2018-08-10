---
author: mtoepke
title: グラフィックス診断ツール
description: Visual Studio でグラフィックス デバッグ、グラフィックス フレーム分析、GPU 使用率などのグラフィックス診断機能を取得して使用する方法について説明します。
ms.assetid: 629ea462-18ed-a333-07e9-cc87ea2dcd93
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, グラフィックス, 診断, ツール, DirectX
ms.openlocfilehash: 076020d88889a9cc8b417befa2dd54b41d688e5e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243269"
---
# <a name="graphics-diagnostics-tools"></a><span data-ttu-id="63e72-104">グラフィックス診断ツール</span><span class="sxs-lookup"><span data-stu-id="63e72-104">Graphics diagnostics tools</span></span>


<span data-ttu-id="63e72-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="63e72-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="63e72-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="63e72-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="63e72-107">Windows 10 では、オプション機能として、グラフィックス診断ツールを Windows 内から使うことができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="63e72-107">With Windows 10, the graphics diagnostic tools are now available from within Windows as an optional feature.</span></span> <span data-ttu-id="63e72-108">DirectX のアプリやゲームを開発するために、ランタイムや Visual Studio で提供されるグラフィックス診断機能を使うには、次の手順に従ってオプションのグラフィックス ツール機能をインストールします。</span><span class="sxs-lookup"><span data-stu-id="63e72-108">To use the graphics diagnostic features provided in the runtime and Visual Studio to develop DirectX apps or games, install the optional Graphics Tools feature:</span></span>

1.  <span data-ttu-id="63e72-109">**[設定]** に移動し、**[システム]**、**[アプリと機能]** の順に選んで、**[オプション機能の管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="63e72-109">Go to **Settings**, select **System**, select **Apps & Features**, and then click **Manage optional features**.</span></span>
2.  <span data-ttu-id="63e72-110">**[機能の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="63e72-110">Click **Add a feature**</span></span>   
3.  <span data-ttu-id="63e72-111">**[オプション機能]** の一覧から **[グラフィックス ツール]** を選び、**[インストール]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="63e72-111">In the **Optional features** list, select **Graphics Tools** and then click **Install**.</span></span>

<span data-ttu-id="63e72-112">グラフィックス診断機能には、DirectX ランタイム、またグラフィックス デバッグ、フレーム分析、GPU 使用率で Direct3D SDK デバッグ デバイス (Direct3D SDK レイヤー経由) を作成する機能が備わっています。</span><span class="sxs-lookup"><span data-stu-id="63e72-112">Graphics diagnostics features include the ability to create Direct3D debug devices (via Direct3D SDK Layers) in the DirectX runtime, plus Graphics Debugging, Frame Analysis, and GPU Usage.</span></span>

-   <span data-ttu-id="63e72-113">グラフィックス デバッグ機能を使うと、アプリによる Direct3D 呼び出しをトレースできます。</span><span class="sxs-lookup"><span data-stu-id="63e72-113">Graphics Debugging lets you trace the Direct3D calls being made by your app.</span></span> <span data-ttu-id="63e72-114">これらの呼び出しを再生し、パラメーターを調べることで、また、シェーダーのデバッグや検証を実行したり、グラフィックス アセットを視覚化したりすることでレンダリングの問題を診断することもできます。</span><span class="sxs-lookup"><span data-stu-id="63e72-114">Then, you can replay those calls, inspect parameters, debug and experiment with shaders, and visualize graphics assets to diagnose rendering issues.</span></span> <span data-ttu-id="63e72-115">Windows PC、シミュレーター、またはデバイスでログを収集し、別のハードウェアで再生できます。</span><span class="sxs-lookup"><span data-stu-id="63e72-115">Logs can be taken on Windows PCs, simulators, or devices, and be played back on different hardware.</span></span>
-   <span data-ttu-id="63e72-116">Visual Studio のグラフィックス フレーム分析機能は、グラフィックス デバッグ ログに対して実行され、Direct3D 描画呼び出しのベースライン タイミングを収集します。</span><span class="sxs-lookup"><span data-stu-id="63e72-116">Graphics Frame Analysis in Visual Studio runs on a graphics debugging log and gathers baseline timing for the Direct3D draw calls.</span></span> <span data-ttu-id="63e72-117">また、さまざまなグラフィックス設定を変更して一連の検証を行い、タイミング結果のテーブルを生成します。</span><span class="sxs-lookup"><span data-stu-id="63e72-117">It then performs a set of experiments by modifying various graphics settings and produces a table of timing results.</span></span> <span data-ttu-id="63e72-118">このデータを使うと、アプリのグラフィックス パフォーマンスに関する問題点を把握し、さまざまな検証の結果を確認して、パフォーマンス向上の可能性を探ることができます。</span><span class="sxs-lookup"><span data-stu-id="63e72-118">You can use this data to understand graphics performance issues in your app, and you can review results of the various experiments to identify opportunities for performance improvements.</span></span>
-   <span data-ttu-id="63e72-119">Visual Studio の GPU 使用率では、リアルタイムで GPU の使用状況を監視できます。</span><span class="sxs-lookup"><span data-stu-id="63e72-119">GPU Usage in Visual Studio allows you to monitor GPU use in real time.</span></span> <span data-ttu-id="63e72-120">CPU や GPU で処理されるワークロードのタイミング データを収集し分析することで、ボトルネックがどこにあるかを特定できます。</span><span class="sxs-lookup"><span data-stu-id="63e72-120">It collects and analyzes the timing data of the workloads being handled by the CPU and GPU, so you can determine where the bottlenecks are.</span></span>

## <a name="related-topics"></a><span data-ttu-id="63e72-121">関連トピック</span><span class="sxs-lookup"><span data-stu-id="63e72-121">Related topics</span></span>


[<span data-ttu-id="63e72-122">Visual Studio でのグラフィックス診断の概要</span><span class="sxs-lookup"><span data-stu-id="63e72-122">Graphics Diagnostics Overview in Visual Studio</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=526382)

 

 




