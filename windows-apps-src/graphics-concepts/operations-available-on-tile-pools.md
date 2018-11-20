---
title: タイル プールで利用可能な操作
description: タイル プールでの操作には、タイル プールのサイズ変更、リソースの提供 (タイル プール全体のためにメモリをシステムに一時的に生成)、リソースの解放などがあります。
ms.assetid: 90347F7F-C991-4287-BD70-494533ECDC8A
keywords:
- タイル プールで利用可能な操作
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ec546d467f338bbbe2f4dbf89015a4487e001718
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7306222"
---
# <a name="operations-available-on-tile-pools"></a><span data-ttu-id="26d92-104">タイル プールで利用可能な操作</span><span class="sxs-lookup"><span data-stu-id="26d92-104">Operations available on tile pools</span></span>


<span data-ttu-id="26d92-105">タイル プールでの操作には、タイル プールのサイズ変更、リソースの提供 (タイル プール全体のためにメモリをシステムに一時的に生成)、リソースの解放などがあります。</span><span class="sxs-lookup"><span data-stu-id="26d92-105">Operations on tile pools include resizing a tile pool, offering resources (yielding memory temporarily to the system for the entire tile pool), and reclaiming resources.</span></span>

-   <span data-ttu-id="26d92-106">タイル プールの有効期間は 他の Direct3D リソースと似ており、参照カウントによりサポートされています (この場合は、ストリーミング リソースからのマッピングの追跡を含む)。</span><span class="sxs-lookup"><span data-stu-id="26d92-106">The lifetime of tile pools works like any other Direct3D Resource, backed by reference counting, including in this case tracking of mappings from streaming resources.</span></span> <span data-ttu-id="26d92-107">アプリケーションがタイル プールを参照しなくなり、メモリへのタイル マッピングがなくなって、グラフィックス処理装置 (GPU) のアクセスが完了すると、オペレーティング システムはタイル プールの割り当てを解除します。</span><span class="sxs-lookup"><span data-stu-id="26d92-107">When the application no longer references a tile pool and any tile mappings to the memory are gone and graphics processing unit (GPU) accesses completed, the operating system will deallocate the tile pool.</span></span>
-   <span data-ttu-id="26d92-108">サーフェスの共有と同期に関連する API は、タイル プールで機能します (ただし、ストリーミング リソースでは直接機能しません)。</span><span class="sxs-lookup"><span data-stu-id="26d92-108">APIs related to surface sharing and synchronization work for tile pools (but not directly on streaming resources).</span></span> <span data-ttu-id="26d92-109">提供されたタイル プールの動作と同様、タイル プールが共有されており、現在別のデバイスとプロセスにより取得されている場合、タイル プールをポイントするストリーミング リソースにアクセスする Direct3D コマンドは破棄されます。</span><span class="sxs-lookup"><span data-stu-id="26d92-109">Similar to the behavior for offered tile pools, Direct3D commands that access streaming resources that point to a tile pool are dropped if the tile pool has been shared and is currently acquired by another device and process.</span></span>
-   <span data-ttu-id="26d92-110">プールのサイズ変更。</span><span class="sxs-lookup"><span data-stu-id="26d92-110">Resizing a tile pool.</span></span>
-   <span data-ttu-id="26d92-111">リソースの提供とリソースの解放 - システムに一時的にメモリを生成するこれらの操作は、タイル プール全体で機能します (個々のストリーミング リソースでは使うことができません)。</span><span class="sxs-lookup"><span data-stu-id="26d92-111">Offering resources and reclaiming resources - These operations for yielding memory temporarily to the system operate on the entire tile pool (and aren't available for individual streaming resources).</span></span> <span data-ttu-id="26d92-112">提供されたタイル プール内のタイルをストリーミング リソースがポイントする場合、ストリーミング リソースは提供されているかのように動作します (たとえば、ランタイムはそれを参照するコマンドを破棄します)。</span><span class="sxs-lookup"><span data-stu-id="26d92-112">If a streaming resource points to a tile in an offered tile pool, the streaming resource behaves as if it is offered (for example, the runtime drops commands that reference it).</span></span>

<span data-ttu-id="26d92-113">タイル プール メモリとの間で直接データをコピーすることはできません。</span><span class="sxs-lookup"><span data-stu-id="26d92-113">Data can't be copied to and from tile pool memory directly.</span></span> <span data-ttu-id="26d92-114">メモリへのアクセスは、常にストリーミング リソースを通じて行われます。</span><span class="sxs-lookup"><span data-stu-id="26d92-114">Accesses to the memory are always done through streaming resources.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="26d92-115"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="26d92-115"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="26d92-116">ストリーミング リソースの作成</span><span class="sxs-lookup"><span data-stu-id="26d92-116">Creating streaming resources</span></span>](creating-streaming-resources.md)

 

 




