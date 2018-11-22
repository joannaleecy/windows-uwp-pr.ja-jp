---
title: リソース データのコピーとアクセス
description: 使用法フラグは、アプリケーションがリソース データをどのように使用するかを示し、リソースを可能な限りメモリのパフォーマンスの高い領域に配置します。 リソース データはリソース間でコピーされ、CPU または GPU がパフォーマンスに影響を与えることなくリソースにアクセスできるようにします。
ms.assetid: 6A09702D-0FF2-4EA6-A353-0F95A3EE34E2
keywords:
- リソース データのコピーとアクセス
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e7b0f06711b4a908f8990dfb16968400c685c15f
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7563405"
---
# <a name="copying-and-accessing-resource-data"></a><span data-ttu-id="7c379-105">リソース データのコピーとアクセス</span><span class="sxs-lookup"><span data-stu-id="7c379-105">Copying and accessing resource data</span></span>


<span data-ttu-id="7c379-106">使用法フラグは、アプリケーションがリソース データをどのように使用するかを示し、リソースを可能な限りメモリのパフォーマンスの高い領域に配置します。</span><span class="sxs-lookup"><span data-stu-id="7c379-106">Usage flags indicate how the application intends to use the resource data, to place resources in the most performant area of memory possible.</span></span> <span data-ttu-id="7c379-107">リソース データはリソース間でコピーされ、CPU または GPU がパフォーマンスに影響を与えることなくリソースにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="7c379-107">Resource data is copied across resources so that the CPU or GPU can access it without impacting performance.</span></span>

<span data-ttu-id="7c379-108">リソースをビデオ メモリまたはシステム メモリのどちらに作成するかを考える必要はなく、ランタイムがメモリを管理するかどうかを決定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7c379-108">It isn't necessary to think about resources as being created in either video memory or system memory, or to decide whether or not the runtime should manage the memory.</span></span> <span data-ttu-id="7c379-109">WDDM (Windows Display Driver Model) のアーキテクチャでは、アプリケーションは、アプリケーションがリソース データをどのように使用するかを示すさまざまな使用法フラグを付けて、Direct3D リソースを作成します。</span><span class="sxs-lookup"><span data-stu-id="7c379-109">With the architecture of the WDDM (Windows Display Driver Model), applications create Direct3D resources with different usage flags to indicate how the application intends to use the resource data.</span></span> <span data-ttu-id="7c379-110">このドライバー モデルは、リソースが使用するメモリを仮想化します。予想される使用法を考慮して、リソースを可能な限りメモリのパフォーマンスの高い領域に配置するのは、オペレーティング システム/ドライバー/メモリ マネージャの役割です。</span><span class="sxs-lookup"><span data-stu-id="7c379-110">This driver model virtualizes the memory used by resources; it is the responsibility of the operating system/driver/memory manager to place resources in the most performant area of memory possible, given the expected usage.</span></span>

<span data-ttu-id="7c379-111">既定のケースは、GPU で使用できるリソースを対象としています。</span><span class="sxs-lookup"><span data-stu-id="7c379-111">The default case is for resources to be available to the GPU.</span></span> <span data-ttu-id="7c379-112">そのリソース データを CPU が使用する必要がある場合もあります。</span><span class="sxs-lookup"><span data-stu-id="7c379-112">There are times when the resource data needs to be available to the CPU.</span></span> <span data-ttu-id="7c379-113">パフォーマンスに影響を与えることなく、適切なプロセッサがリソース データにアクセスできるようにリソース データをコピーするには、API メソッドの仕組みに関する知識が必要になります。</span><span class="sxs-lookup"><span data-stu-id="7c379-113">Copying resource data around so that the appropriate processor can access it without impacting performance requires some knowledge of how the API methods work.</span></span>

## <a name="span-idcopyingspanspan-idcopyingspanspan-idcopyingspancopying-resource-data"></a><span data-ttu-id="7c379-114"><span id="Copying"></span><span id="copying"></span><span id="COPYING"></span>リソース データのコピー</span><span class="sxs-lookup"><span data-stu-id="7c379-114"><span id="Copying"></span><span id="copying"></span><span id="COPYING"></span>Copying resource data</span></span>


<span data-ttu-id="7c379-115">Direct3D が Create の呼び出しを実行すると、メモリ内にリソースが作成されます。</span><span class="sxs-lookup"><span data-stu-id="7c379-115">Resources are created in memory when Direct3D executes a Create call.</span></span> <span data-ttu-id="7c379-116">それらは、ビデオ メモリ、システム メモリ、または他の任意の種類のメモリに作成することができます。</span><span class="sxs-lookup"><span data-stu-id="7c379-116">They can be created in video memory, system memory, or any other kind of memory.</span></span> <span data-ttu-id="7c379-117">WDDM ドライバー モデルはこのメモリを仮想化するため、アプリケーションはリソースが作成されるメモリの種類を把握する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="7c379-117">Since WDDM driver model virtualizes this memory, applications no longer need to keep track of what kind of memory resources are created in.</span></span>

<span data-ttu-id="7c379-118">理想的には、GPU が直ちにアクセスできるように、すべてのリソースをビデオ メモリに配置します。</span><span class="sxs-lookup"><span data-stu-id="7c379-118">Ideally, all resources would be located in video memory so that the GPU can have immediate access to them.</span></span> <span data-ttu-id="7c379-119">ただし、CPU がリソース データを読み取ったり、CPU が書き込んだリソース データに GPU がアクセスしたりする必要がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="7c379-119">However, it is sometimes necessary for the CPU to read the resource data or for the GPU to access resource data the CPU has written to.</span></span> <span data-ttu-id="7c379-120">Direct3D では、アプリケーションが使用法を指定するように要求することにより、これらのさまざまなシナリオを処理し、さらに必要に応じてリソース データをコピーするためのメソッドをいくつか提供します。</span><span class="sxs-lookup"><span data-stu-id="7c379-120">Direct3D handles these different scenarios by requesting the application specify a usage, and then offers several methods for copying resource data when necessary.</span></span>

<span data-ttu-id="7c379-121">リソースの作成方法によっては、そのデータに直接アクセスできないことがあります。</span><span class="sxs-lookup"><span data-stu-id="7c379-121">Depending on how the resource was created, it is not always possible to directly access the underlying data.</span></span> <span data-ttu-id="7c379-122">つまり、ソース リソースから適切なプロセッサーがアクセスできる別のリソースに、リソース データをコピーする必要があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="7c379-122">This may mean that the resource data must be copied from the source resource to another resource that is accessible by the appropriate processor.</span></span> <span data-ttu-id="7c379-123">Direct3D では、既定のリソースには GPU から直接アクセスでき、動的リソースおよびステージング リソースには CPU から直接アクセスできます。</span><span class="sxs-lookup"><span data-stu-id="7c379-123">In terms of Direct3D, default resources can be accessed directly by the GPU, dynamic and staging resources can be directly accessed by the CPU.</span></span>

<span data-ttu-id="7c379-124">リソースが作成されると、その使用法を変更することはできません。</span><span class="sxs-lookup"><span data-stu-id="7c379-124">Once a resource has been created, its usage cannot be changed.</span></span> <span data-ttu-id="7c379-125">その代わりに、あるリソースの内容を別の使用法で作成された別のリソースにコピーします。</span><span class="sxs-lookup"><span data-stu-id="7c379-125">Instead, copy the contents of one resource to another resource that was created with a different usage.</span></span> <span data-ttu-id="7c379-126">あるリソースから別のリソースにリソース データをコピーするか、またはメモリからリソースにデータをコピーします。</span><span class="sxs-lookup"><span data-stu-id="7c379-126">You copy resource data from one resource to another, or copy data from memory to a resource.</span></span>

<span data-ttu-id="7c379-127">リソースには主に 2 種類があります。マッピング可能なものと、マッピング不可能なものです。</span><span class="sxs-lookup"><span data-stu-id="7c379-127">There are two main kinds of resources: mappable and non-mappable.</span></span> <span data-ttu-id="7c379-128">動的またはステージングの使用法で作成されたリソースはマッピング可能ですが、既定または固定の使用法で作成されたリソースはマッピング不可能です。</span><span class="sxs-lookup"><span data-stu-id="7c379-128">Resources created with dynamic or staging usages are mappable, while resources created with default or immutable usages are non-mappable.</span></span>

<span data-ttu-id="7c379-129">マッピング不可能なリソース間でのデータのコピーは、最も一般的なケースであり、適切に実行されるよう最適化されているため、非常に高速です。</span><span class="sxs-lookup"><span data-stu-id="7c379-129">Copying data among non-mappable resources is very fast because this is the most common case and has been optimized to perform well.</span></span> <span data-ttu-id="7c379-130">これらのリソースは CPU から直接アクセスできないため、GPU から高速に操作できるように最適化されています。</span><span class="sxs-lookup"><span data-stu-id="7c379-130">Since these resources are not directly accessible by the CPU, they are optimized so that the GPU can manipulate them quickly.</span></span>

<span data-ttu-id="7c379-131">マッピング可能なリソース間でのデータのコピーは、リソースの作成時の使用法によりパフォーマンスが異なるので、より問題が生じやすくなります。</span><span class="sxs-lookup"><span data-stu-id="7c379-131">Copying data among mappable resources is more problematic because the performance will depend on the usage the resource was created with.</span></span> <span data-ttu-id="7c379-132">たとえば、GPU は動的リソースをかなり高速で読み取ることができますが、書き込むことができません。また、GPU はステージング リソースの直接読み取り、または書き込みができません。</span><span class="sxs-lookup"><span data-stu-id="7c379-132">For example, the GPU can read a dynamic resource fairly quickly but cannot write to them, and the GPU cannot read or write to staging resources directly.</span></span>

<span data-ttu-id="7c379-133">使用法が既定のリソースから、使用法がステージングのリソースへデータをコピーしようとする (CPU でデータを読み取ることができるようにするため、つまり GPU のリードバックの問題) アプリケーションは、注意して実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c379-133">Applications that wish to copy data from a resource with default usage to a resource with staging usage (to allow the CPU to read the data -- that is, the GPU readback problem) must do so with care.</span></span> <span data-ttu-id="7c379-134">詳しくは、「[リソース データへのアクセス](#accessing)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c379-134">See [Accessing resource data](#accessing), below.</span></span>

## <a name="span-idaccessingspanspan-idaccessingspanspan-idaccessingspanaccessing-resource-data"></a><span data-ttu-id="7c379-135"><span id="Accessing"></span><span id="accessing"></span><span id="ACCESSING"></span>リソース データへのアクセス</span><span class="sxs-lookup"><span data-stu-id="7c379-135"><span id="Accessing"></span><span id="accessing"></span><span id="ACCESSING"></span>Accessing resource data</span></span>


<span data-ttu-id="7c379-136">リソースにアクセスするには、リソースをマッピングする必要があります。マッピングとは、基本的には、アプリケーションが CPU からメモリへのアクセスを行おうとすることです。</span><span class="sxs-lookup"><span data-stu-id="7c379-136">Accessing a resource requires mapping the resource; mapping essentially means the application is trying to give the CPU access to memory.</span></span> <span data-ttu-id="7c379-137">CPU から基になるメモリへアクセスできるようリソースをマッピングするプロセスでは、何らかのパフォーマンス ボトルネックが発生する場合があります。このため、このタスクをいつどのように実行するかについて、注意を払う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c379-137">The process of mapping a resource so that the CPU can access the underlying memory can cause some performance bottlenecks and for this reason, care must be taken as to how and when to perform this task.</span></span>

<span data-ttu-id="7c379-138">アプリケーションが不適切なときにリソースをマッピングしようとすると、パフォーマンスが大幅に低下することがあります。</span><span class="sxs-lookup"><span data-stu-id="7c379-138">Performance can grind to a halt if the application tries to map a resource at the wrong time.</span></span> <span data-ttu-id="7c379-139">ある操作が終了する前に、アプリケーションがその操作の結果にアクセスしようとすると、パイプライン ストールが発生します。</span><span class="sxs-lookup"><span data-stu-id="7c379-139">If the application tries to access the results of an operation before that operation is finished, a pipeline stall will occur.</span></span>

<span data-ttu-id="7c379-140">不適切なときにマッピング操作を実行すると、GPU および CPU が互いに強制的に同期させられ、パフォーマンスの深刻な低下を引き起こす潜在的な可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7c379-140">Performing a map operation at the wrong time could potentially cause a severe drop in performance by forcing the GPU and the CPU to synchronize with each other.</span></span> <span data-ttu-id="7c379-141">この同期化は、CPU がマッピング可能なリソースに GPU がリソースをコピーし終わる前に、アプリケーションがそのリソースにアクセスしようとすると発生します。</span><span class="sxs-lookup"><span data-stu-id="7c379-141">This synchronization will occur if the application wants to access a resource before the GPU is finished copying it into a resource the CPU can map.</span></span>

### <a name="span-idperformanceconsiderationsspanspan-idperformanceconsiderationsspanspan-idperformanceconsiderationsspanperformance-considerations"></a><span data-ttu-id="7c379-142"><span id="Performance_Considerations"></span><span id="performance_considerations"></span><span id="PERFORMANCE_CONSIDERATIONS"></span>パフォーマンスに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="7c379-142"><span id="Performance_Considerations"></span><span id="performance_considerations"></span><span id="PERFORMANCE_CONSIDERATIONS"></span>Performance considerations</span></span>

<span data-ttu-id="7c379-143">PC は、主に 2 種類のプロセッサを含む並列アーキテクチャとして動作しているマシンと考えてください。2 種類のプロセッサとは、1 つ以上の CPU のものと、1 つ以上の GPU のものです。</span><span class="sxs-lookup"><span data-stu-id="7c379-143">It is best to think of a PC as a machine running as a parallel architecture with two main types of processors: one or more CPU's and one or more GPU's.</span></span> <span data-ttu-id="7c379-144">どの並列アーキテクチャでも、最高のパフォーマンスが得られるのは、各プロセッサがアイドル状態にならないように十分なタスクがスケジュールされているときと、1 つのプロセッサの仕事が別のプロセッサの仕事を待機していないときです。</span><span class="sxs-lookup"><span data-stu-id="7c379-144">As in any parallel architecture, the best performance is achieved when each processor is scheduled with enough tasks to prevent it from going idle and when the work of one processor is not waiting on the work of another.</span></span>

<span data-ttu-id="7c379-145">GPU および CPU の並列処理の最悪のケースのシナリオは、あるプロセッサが別のプロセッサが行った仕事の結果を待機する必要があるという場合です。</span><span class="sxs-lookup"><span data-stu-id="7c379-145">The worst-case scenario for GPU/CPU parallelism is the need to force one processor to wait for the results of work done by another.</span></span> <span data-ttu-id="7c379-146">Direct3D では、コピー メソッドを非同期にすることにより、このコストを取り除こうとしています。コピーは、メソッドが返されるときまでに必ずしも実行しておく必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7c379-146">Direct3D removes this cost by making the copy methods asynchronous; the copy has not necessarily executed by the time the method returns.</span></span>

<span data-ttu-id="7c379-147">この方法の利点は、Map が呼び出されて CPU がデータにアクセスするまで、データを実際にコピーするというパフォーマンスのコストをアプリケーションが負担しないことです。</span><span class="sxs-lookup"><span data-stu-id="7c379-147">The benefit of this is that the application does not pay the performance cost of actually copying the data until the CPU accesses the data, which is when Map is called.</span></span> <span data-ttu-id="7c379-148">データが実際にコピーされた後に Map メソッドが呼び出されると、パフォーマンスの損失が発生しません。</span><span class="sxs-lookup"><span data-stu-id="7c379-148">If the Map method is called after the data has actually been copied, no performance loss occurs.</span></span> <span data-ttu-id="7c379-149">一方、データがコピーされる前に Map メソッドが呼び出される場合は、パイプライン ストールが発生します。</span><span class="sxs-lookup"><span data-stu-id="7c379-149">On the other hand, if the Map method is called before the data has been copied, then a pipeline stall will occur.</span></span>

<span data-ttu-id="7c379-150">Direct3D の非同期呼び出し (メソッドの大多数の呼び出し、および特にレンダリング呼び出し) は、*コマンド バッファー*と呼ばれる場所に格納されます。</span><span class="sxs-lookup"><span data-stu-id="7c379-150">Asynchronous calls in Direct3D (which are the vast majority of methods, and especially rendering calls) are stored in what is called a *command buffer*.</span></span> <span data-ttu-id="7c379-151">このバッファーは、グラフィックス ドライバー内部にあり、Microsoft Windows のユーザー モードからカーネル モードへの負荷の大きい切り替えができるだけ発生しないように、基になるハードウェアへの呼び出しをバッチ処理するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="7c379-151">This buffer is internal to the graphics driver and is used to batch calls to the underlying hardware so that the costly switch from user mode to kernel mode in Microsoft Windows occurs as rarely as possible.</span></span>

<span data-ttu-id="7c379-152">以下の 4 つの状況のいずれかで、コマンド バッファーがフラッシュされ、ユーザー モードとカーネル モードの切り替えが発生します。</span><span class="sxs-lookup"><span data-stu-id="7c379-152">The command buffer is flushed, thus causing a user/kernel mode switch, in one of four situations, which are as follows.</span></span>

1.  <span data-ttu-id="7c379-153">Present が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7c379-153">Present is called.</span></span>
2.  <span data-ttu-id="7c379-154">Flush が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7c379-154">Flush is called.</span></span>
3.  <span data-ttu-id="7c379-155">コマンド バッファーがいっぱいです。コマンド バッファーのサイズは動的で、オペレーティング システムとグラフィックス ドライバーで制御されます。</span><span class="sxs-lookup"><span data-stu-id="7c379-155">The command buffer is full; its size is dynamic and is controlled by the Operating System and the graphics driver.</span></span>
4.  <span data-ttu-id="7c379-156">CPU は、コマンド バッファーで実行を待っているコマンドの結果にアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c379-156">The CPU requires access to the results of a command waiting to execute in the command buffer.</span></span>

<span data-ttu-id="7c379-157">この 4 つの状況で、4 番目がパフォーマンスにおいて最も重要です。</span><span class="sxs-lookup"><span data-stu-id="7c379-157">Of the four situations above, number four is the most critical to performance.</span></span> <span data-ttu-id="7c379-158">アプリケーションがリソース コピーの呼び出しまたはサブリソース コピーの呼び出しを発行する場合、この呼び出しはコマンド バッファーにキューイングされます。</span><span class="sxs-lookup"><span data-stu-id="7c379-158">If the application issues a call to copy a resource, or subresource, this call is queued in the command buffer.</span></span>

<span data-ttu-id="7c379-159">そこでアプリケーションが、コピー呼び出しの対象だったステージング リソースを、コマンド バッファーがフラッシュされる前にマッピングしようとすると、Copy メソッドの呼び出しを実行する必要があるだけでなく、コマンド バッファー内にバッファーされたその他すべてのコマンドも実行しなければならないため、パイプライン ストールが発生します。</span><span class="sxs-lookup"><span data-stu-id="7c379-159">If the application then tries to map the staging resource that was the target of the copy call before the command buffer has been flushed, a pipeline stall will occur, because not only does the Copy method call need to execute, but all other buffered commands in the command buffer must execute as well.</span></span> <span data-ttu-id="7c379-160">れにより、GPU がコマンド バッファーを空にし、CPU が必要とするリソースに最終的にデータを格納する間、CPU はステージング リソースへのアクセスを待機するので、GPU と CPU の同期が発生します。</span><span class="sxs-lookup"><span data-stu-id="7c379-160">This will cause the GPU and CPU to synchronize because the CPU will be waiting to access the staging resource while the GPU is emptying the command buffer and finally filling the resource the CPU needs.</span></span> <span data-ttu-id="7c379-161">GPU がコピーを終了すると、CPU はステージング リソースへのアクセスを開始します。しかしこの間、GPU はアイドル状態となります。</span><span class="sxs-lookup"><span data-stu-id="7c379-161">Once the GPU finishes the copy, the CPU will begin accessing the staging resource, but during this time, the GPU will be sitting idle.</span></span>

<span data-ttu-id="7c379-162">ランタイムにこれを頻繁に行うと、パフォーマンスが著しく低下します。</span><span class="sxs-lookup"><span data-stu-id="7c379-162">Doing this frequently at runtime will severely degrade performance.</span></span> <span data-ttu-id="7c379-163">そのため、既定の使用法で作成されたリソースのマッピングは、注意して行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c379-163">For that reason, mapping of resources created with default usage should be done with care.</span></span> <span data-ttu-id="7c379-164">アプリケーションは、コマンド バッファーが空になるのに十分な時間待機し、対応するステージング リソースにマッピングしようとする前に、こうしたコマンドをすべて実行し終える必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c379-164">The application needs to wait long enough for the command buffer to be emptied and thus have all of those commands finish executing before it tries to map the corresponding staging resource.</span></span>

<span data-ttu-id="7c379-165">アプリケーションはどれだけ待機すればよいのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="7c379-165">How long should the application wait?</span></span> <span data-ttu-id="7c379-166">少なくとも 2 フレームです。これにより CPU と GPU 間の並列処理が最大限利用できるからです。</span><span class="sxs-lookup"><span data-stu-id="7c379-166">At least two frames because this will enable parallelism between the CPU(s) and the GPU to be maximally leveraged.</span></span> <span data-ttu-id="7c379-167">GPU がどのように動作するかというと、アプリケーションがコマンド バッファーに呼び出しを送信することにより N 番目のフレームを処理する間、GPU は前のフレームである N-1 番目からの呼び出しの実行でビジー状態です。</span><span class="sxs-lookup"><span data-stu-id="7c379-167">The way the GPU works is that while the application is processing frame N by submitting calls to the command buffer, the GPU is busy executing the calls from the previous frame, N-1.</span></span>

<span data-ttu-id="7c379-168">そこで、アプリケーションがビデオ メモリにあるリソースをマッピングしようとし、N 番目のフレームでリソースをコピーする場合、この呼び出しは実際には、アプリケーションが次のフレームの呼び出しを送信しているとき、N + 1 番目のフレームで実行を開始します。</span><span class="sxs-lookup"><span data-stu-id="7c379-168">So if an application wants to map a resource that originates in video memory and copies a resource at frame N, this call will actually begin to execute at frame N+1, when the application is submitting calls for the next frame.</span></span> <span data-ttu-id="7c379-169">コピーは、アプリケーションが N + 2 番目のフレームを処理しているときに完了します。</span><span class="sxs-lookup"><span data-stu-id="7c379-169">The copy should be finished when the application is processing frame N+2.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="7c379-170">フレーム</span><span class="sxs-lookup"><span data-stu-id="7c379-170">Frame</span></span></th>
<th align="left"><span data-ttu-id="7c379-171">GPU/CPU の状態</span><span class="sxs-lookup"><span data-stu-id="7c379-171">GPU/CPU Status</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="7c379-172">N</span><span class="sxs-lookup"><span data-stu-id="7c379-172">N</span></span></td>
<td align="left"><ul>
<li><span data-ttu-id="7c379-173">CPU が現在のフレームのレンダリング呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="7c379-173">CPU issues render calls for current frame.</span></span></li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="7c379-174">N+1</span><span class="sxs-lookup"><span data-stu-id="7c379-174">N+1</span></span></td>
<td align="left"><ul>
<li><span data-ttu-id="7c379-175">N 番目のフレームの間、GPU は CPU から送信された呼び出しを実行しています。</span><span class="sxs-lookup"><span data-stu-id="7c379-175">GPU executing calls sent from CPU during frame N.</span></span></li>
<li><span data-ttu-id="7c379-176">CPU が現在のフレームのレンダリング呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="7c379-176">CPU issues render calls for current frame.</span></span></li>
</ul></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="7c379-177">N+2</span><span class="sxs-lookup"><span data-stu-id="7c379-177">N+2</span></span></td>
<td align="left"><ul>
<li><span data-ttu-id="7c379-178">N 番目のフレームの間に、GPU は CPU から送信された呼び出しの実行を完了しました。結果の準備ができています。</span><span class="sxs-lookup"><span data-stu-id="7c379-178">GPU finished executing calls sent from CPU during frame N. Results ready.</span></span></li>
<li><span data-ttu-id="7c379-179">N + 1 番目のフレームの間、GPU は CPU から送信された呼び出しを実行しています。</span><span class="sxs-lookup"><span data-stu-id="7c379-179">GPU executing calls sent from CPU during frame N+1.</span></span></li>
<li><span data-ttu-id="7c379-180">CPU が現在のフレームのレンダリング呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="7c379-180">CPU issues render calls for current frame.</span></span></li>
</ul></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="7c379-181">N+3</span><span class="sxs-lookup"><span data-stu-id="7c379-181">N+3</span></span></td>
<td align="left"><ul>
<li><span data-ttu-id="7c379-182">N + 1 番目のフレームの間に、GPU は CPU から送信された呼び出しの実行を完了しました。</span><span class="sxs-lookup"><span data-stu-id="7c379-182">GPU finished executing calls sent from CPU during frame N+1.</span></span> <span data-ttu-id="7c379-183">結果の準備ができています。</span><span class="sxs-lookup"><span data-stu-id="7c379-183">Results ready.</span></span></li>
<li><span data-ttu-id="7c379-184">N + 2 番目のフレームの間、GPU は CPU から送信された呼び出しを実行しています。</span><span class="sxs-lookup"><span data-stu-id="7c379-184">GPU executing calls sent from CPU during frame N+2.</span></span></li>
<li><span data-ttu-id="7c379-185">CPU が現在のフレームのレンダリング呼び出しを行います。</span><span class="sxs-lookup"><span data-stu-id="7c379-185">CPU issues render calls for current frame.</span></span></li>
</ul></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="7c379-186">N+4</span><span class="sxs-lookup"><span data-stu-id="7c379-186">N+4</span></span></td>
<td align="left"><span data-ttu-id="7c379-187">...</span><span class="sxs-lookup"><span data-stu-id="7c379-187">...</span></span></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="7c379-188"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="7c379-188"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="7c379-189">リソース</span><span class="sxs-lookup"><span data-stu-id="7c379-189">Resources</span></span>](resources.md)

 

 




