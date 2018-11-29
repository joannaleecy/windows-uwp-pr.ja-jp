---
title: 階層 2
description: ストリーミング リソースの階層 2 のサポートで、サイズが 1 つ以上の標準タイル形状であるときのパックされないテクスチャ ミップマップの保証や、詳細レベル (LOD) をクランプするため、およびシェーダーの操作に関する状態を取得するためのシェーダー命令、サンプリングされた値をゼロとして 処理する NULL マッピングされたタイルからの読み取りなど、階層 1 に含まれない機能が追加されます。
ms.assetid: 111A28EA-661A-4D29-921A-F2E376A46DC5
keywords:
- 階層 2
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 6f9f9a69c0e30459929d1e31084ea88b3f7ebbd0
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7985892"
---
# <a name="tier-2"></a><span data-ttu-id="629c9-104">階層 2</span><span class="sxs-lookup"><span data-stu-id="629c9-104">Tier 2</span></span>


<span data-ttu-id="629c9-105">ストリーミング リソースの階層 2 のサポートで、サイズが 1 つ以上の標準タイル形状であるときのパックされないテクスチャ ミップマップの保証や、詳細レベル (LOD) をクランプするため、およびシェーダーの操作に関する状態を取得するためのシェーダー命令、サンプリングされた値をゼロとして 処理する NULL マッピングされたタイルからの読み取りなど、階層 1 に含まれない機能が追加されます。</span><span class="sxs-lookup"><span data-stu-id="629c9-105">Tier 2 support for streaming resources adds capabilities beyond Tier 1, such as guaranteeing nonpacked texture mipmap when the size is at least one standard tile shape; shader instructions for clamping level-of-detail (LOD) and for obtaining status about the shader operation; also, reading from NULL-mapped tiles treat that sampled value as zero.</span></span>

## <a name="span-idtier2generalsupportspanspan-idtier2generalsupportspanspan-idtier2generalsupportspantier-2-general-support"></a><span data-ttu-id="629c9-106"><span id="Tier_2_general_support"></span><span id="tier_2_general_support"></span><span id="TIER_2_GENERAL_SUPPORT"></span>階層 2 の一般的なサポート</span><span class="sxs-lookup"><span data-stu-id="629c9-106"><span id="Tier_2_general_support"></span><span id="tier_2_general_support"></span><span id="TIER_2_GENERAL_SUPPORT"></span>Tier 2 general support</span></span>


<span data-ttu-id="629c9-107">階層 2 のサポートには次のものが含まれます。</span><span class="sxs-lookup"><span data-stu-id="629c9-107">Tier 2 support includes the following.</span></span>

-   <span data-ttu-id="629c9-108">機能レベル 11.1 以上のハードウェア。</span><span class="sxs-lookup"><span data-stu-id="629c9-108">Hardware at Feature Level 11.1 minimum.</span></span>
-   <span data-ttu-id="629c9-109">前の階層のすべての機能 ([階層 1](tier-1.md) の特定の制限事項なし) に加えて、次のような項目での追加機能があります。</span><span class="sxs-lookup"><span data-stu-id="629c9-109">All features of the previous tier (without [Tier 1](tier-1.md) specific limitations) plus the additions in these following items:</span></span>
-   <span data-ttu-id="629c9-110">LOD のクランプとマップされた状態のフィードバックのためのシェーダー命令を利用できます。</span><span class="sxs-lookup"><span data-stu-id="629c9-110">Shader instructions for clamping LOD and mapped status feedback are available.</span></span> <span data-ttu-id="629c9-111">「[HLSL ストリーミング リソースの露出](hlsl-streaming-resources-exposure.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="629c9-111">See [HLSL streaming resources exposure](hlsl-streaming-resources-exposure.md).</span></span>

<span data-ttu-id="629c9-112">これらに加えて、次のような特定のサポート問題があります。</span><span class="sxs-lookup"><span data-stu-id="629c9-112">In addition to these, there are some specific support issues that follow.</span></span>

## <a name="span-idnon-mappedtilesspanspan-idnon-mappedtilesspanspan-idnon-mappedtilesspannon-mapped-tiles"></a><span data-ttu-id="629c9-113"><span id="Non-mapped_tiles"></span><span id="non-mapped_tiles"></span><span id="NON-MAPPED_TILES"></span>マップされていないタイル</span><span class="sxs-lookup"><span data-stu-id="629c9-113"><span id="Non-mapped_tiles"></span><span id="non-mapped_tiles"></span><span id="NON-MAPPED_TILES"></span>Non-mapped tiles</span></span>


<span data-ttu-id="629c9-114">マップされていないタイルからの読み取りでは、形式の欠落していないすべてのコンポーネントでは 0 を返し、欠落しているコンポーネントには既定値を返します。</span><span class="sxs-lookup"><span data-stu-id="629c9-114">Reads from non-mapped tiles return 0 in all non-missing components of the format, and the default for missing components.</span></span>

<span data-ttu-id="629c9-115">マップされていないタイルへの書き込みは、メモリに移動するのは止められますが、最後にはキャッシュに移動する可能性があり、それ以降の同じアドレスへの読み取りは取得されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="629c9-115">Writes to non-mapped tiles are stopped from going to memory but might end up in caches that subsequent reads to the same address might or might not pick up.</span></span>

## <a name="span-idtexturefilteringspanspan-idtexturefilteringspanspan-idtexturefilteringspantexture-filtering"></a><span data-ttu-id="629c9-116"><span id="Texture_filtering"></span><span id="texture_filtering"></span><span id="TEXTURE_FILTERING"></span>テクスチャ フィルタリング</span><span class="sxs-lookup"><span data-stu-id="629c9-116"><span id="Texture_filtering"></span><span id="texture_filtering"></span><span id="TEXTURE_FILTERING"></span>Texture filtering</span></span>


<span data-ttu-id="629c9-117">**NULL** のタイルと **NULL** でないタイルをまたぐフットプリントを含むテクスチャ フィルタリングでは、**NULL** タイル上のテクセルの場合に全体的なフィルター処理に 0 が送られます (欠落した形式コンポーネントの既定値と共に)。</span><span class="sxs-lookup"><span data-stu-id="629c9-117">Texture filtering with a footprint that straddles **NULL** and non-**NULL** tiles contributes 0 (with defaults for missing format components) for texels on **NULL** tiles into the overall filter operation.</span></span> <span data-ttu-id="629c9-118">一部の初期のハードウェアはこの要件を満たしていないため、いずれかのテクセル (0 以外の重み付き) が **NULL** タイルにかかる場合、完全なフィルター処理の結果に対して 0 を返します (欠落した形式コンポーネントの既定値と共に)。</span><span class="sxs-lookup"><span data-stu-id="629c9-118">Some early hardware don't meet this requirement and returns 0 (with defaults for missing format components) for the full filter result if any texels (with nonzero weight) fall on a **NULL** tile.</span></span> <span data-ttu-id="629c9-119">その他のハードウェアには、すべての (0 以外の重み付きの) テクセルをフィルター処理に含めるために要件の欠落は許されません。</span><span class="sxs-lookup"><span data-stu-id="629c9-119">No other hardware will be allowed to miss the requirement to include all (nonzero weighted) texels in the filter operation.</span></span>

<span data-ttu-id="629c9-120">**NULL** テクセルにアクセスすると、テクスチャの読み取りが false を返すように、状態のフィードバックに [**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) 操作が行われます。</span><span class="sxs-lookup"><span data-stu-id="629c9-120">**NULL** texel accesses cause the [**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) operation on the status feedback for a texture read to return false.</span></span> <span data-ttu-id="629c9-121">これは、テクスチャへのアクセスの結果で書き込みがシェーダーでどのようにマスクされるかや、テクスチャ形式に含まれるコンポーネントの数には関係なく行われます (これらの組み合わせによって、テクスチャへのアクセスが必要ないことがわかる場合があります)。</span><span class="sxs-lookup"><span data-stu-id="629c9-121">This is regardless of how the texture access result might get write masked in the shader and how many components are in the texture format (the combination of which might make it appear that the texture does not need to be accessed).</span></span>

## <a name="span-idalignmentconstraintsspanspan-idalignmentconstraintsspanspan-idalignmentconstraintsspanalignment-constraints"></a><span data-ttu-id="629c9-122"><span id="Alignment_constraints"></span><span id="alignment_constraints"></span><span id="ALIGNMENT_CONSTRAINTS"></span>配置の制約</span><span class="sxs-lookup"><span data-stu-id="629c9-122"><span id="Alignment_constraints"></span><span id="alignment_constraints"></span><span id="ALIGNMENT_CONSTRAINTS"></span>Alignment constraints</span></span>


<span data-ttu-id="629c9-123">標準のタイル形状の場合の配置の制約: すべての次元で 1 つ以上の標準のタイルを塗りつぶすミップマップは、標準のタイルを使用することが保証され、残りは 1 つの**ユニット**として N 個のタイルにパックされたと見なされます (N はアプリケーションに報告される)。</span><span class="sxs-lookup"><span data-stu-id="629c9-123">Alignment constraints for standard tile shapes: Mipmaps that fill at least one standard tile in all dimensions are guaranteed to use the standard tiling, with the remainder considered packed as a **unit** into N tiles (N reported to the application).</span></span> <span data-ttu-id="629c9-124">アプリケーションは、N 個のタイルをタイル プール内の分離された任意の場所にマッピングすることができますが、パックされたタイルのすべてをマッピングするか、すべてをマッピングしないかのいずれかにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="629c9-124">The application can map the N tiles into arbitrarily disjoint locations in a tile pool, but must either map all or none of the packed tiles.</span></span> <span data-ttu-id="629c9-125">ミップ パッキングは、配列スライスごとにパックされたタイルの一意のセットです。</span><span class="sxs-lookup"><span data-stu-id="629c9-125">The mip packing is a unique set of packed tiles per array slice.</span></span>

## <a name="span-idminmaxreductionfilteringspanspan-idminmaxreductionfilteringspanspan-idminmaxreductionfilteringspanminmax-reduction-filtering"></a><span data-ttu-id="629c9-126"><span id="Min_Max_reduction_filtering"></span><span id="min_max_reduction_filtering"></span><span id="MIN_MAX_REDUCTION_FILTERING"></span>最小/最大除去フィルタリング</span><span class="sxs-lookup"><span data-stu-id="629c9-126"><span id="Min_Max_reduction_filtering"></span><span id="min_max_reduction_filtering"></span><span id="MIN_MAX_REDUCTION_FILTERING"></span>Min/Max reduction filtering</span></span>


<span data-ttu-id="629c9-127">最小/最大除去フィルタリングはサポートされます。</span><span class="sxs-lookup"><span data-stu-id="629c9-127">Min/Max reduction filtering is supported.</span></span> <span data-ttu-id="629c9-128">「[ストリーミング リソース テクスチャ サンプリング機能](streaming-resources-texture-sampling-features.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="629c9-128">See [Streaming resources texture sampling features](streaming-resources-texture-sampling-features.md).</span></span>

## <a name="span-idlimitationsspanspan-idlimitationsspanspan-idlimitationsspanlimitations"></a><span data-ttu-id="629c9-129"><span id="Limitations"></span><span id="limitations"></span><span id="LIMITATIONS"></span>制限事項</span><span class="sxs-lookup"><span data-stu-id="629c9-129"><span id="Limitations"></span><span id="limitations"></span><span id="LIMITATIONS"></span>Limitations</span></span>


<span data-ttu-id="629c9-130">いずれかの次元で標準のタイル サイズより小さいミップマップが含まれるストリーミング リソースは、1 より大きい配列サイズを持つことはできません。</span><span class="sxs-lookup"><span data-stu-id="629c9-130">Streaming resources with any mipmaps less than standard tile size in any dimension are not allowed to have an array size larger than 1.</span></span>

<span data-ttu-id="629c9-131">重複するマッピングがあるときにタイルにアクセスする方法に関する制限は引き続き適用されます。</span><span class="sxs-lookup"><span data-stu-id="629c9-131">Limitations on how tiles can be accessed when there are duplicate mappings continue to apply.</span></span> <span data-ttu-id="629c9-132">「[重複するマッピングを含むタイルのアクセス制限](tile-access-limitations-with-duplicate-mappings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="629c9-132">See [Tile access limitations with duplicate mappings](tile-access-limitations-with-duplicate-mappings.md).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="629c9-133"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="629c9-133"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="629c9-134">ストリーミング リソース機能の階層</span><span class="sxs-lookup"><span data-stu-id="629c9-134">Streaming resources features tiers</span></span>](streaming-resources-features-tiers.md)

 

 




