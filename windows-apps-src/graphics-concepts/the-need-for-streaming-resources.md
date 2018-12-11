---
title: ストリーミング リソースのニーズ
description: ストリーミング リソースは、アクセスされないサーフェスの領域を保存して GPU メモリを無駄にしないために、また、隣接するタイルをまたいでフィルター処理する方法をハードウェアに伝えるために必要です。
ms.assetid: A88BE65B-104F-4176-9809-C12580A3684C
keywords:
- ストリーミング リソースのニーズ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0e0354b0e727e84d562bf63779e74be72f87198f
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8897047"
---
# <a name="the-need-for-streaming-resources"></a>ストリーミング リソースのニーズ


ストリーミング リソースは、アクセスされないサーフェスの領域を保存して GPU メモリを無駄にしないために、また、隣接するタイルをまたいでフィルター処理する方法をハードウェアに伝えるために必要です。

## <a name="span-idstreamingresourcesorsparsetexturesspanspan-idstreamingresourcesorsparsetexturesspanspan-idstreamingresourcesorsparsetexturesspanstreaming-resources-or-sparse-textures"></a><span id="Streaming_resources_or_sparse_textures"></span><span id="streaming_resources_or_sparse_textures"></span><span id="STREAMING_RESOURCES_OR_SPARSE_TEXTURES"></span>ストリーミング リソースまたはスパース テクスチャ


*ストリーミング リソース* (Direct3D 11 では*タイル リソース*と呼ばれます) は、少量の物理メモリを使用する大規模な論理リソースです。

ストリーミング リソースの別の名前が*スパース テクスチャ*です。 "スパース" には、リソースがタイルに分割されることと、それらすべてが一度にマップされないと予測されること (タイルに分割される主な理由) の両方の意味が含まれます。 実際、アプリケーションは、意図的にリソースのすべての領域およびミップス用にデータが作成されないストリーミング リソースを作成することもできます。 そのため、コンテンツ自体がスパースである可能性があり、特定時点でのグラフィックス処理装置 (GPU) のメモリ内のコンテンツのマッピングはそれのサブセットになります (さらにスパースになります)。

## <a name="span-idwithouttilingmemoryallocationsaremanagedatsubresourcegranularityspanspan-idwithouttilingmemoryallocationsaremanagedatsubresourcegranularityspanspan-idwithouttilingmemoryallocationsaremanagedatsubresourcegranularityspanwithout-tiling-memory-allocations-are-managed-at-subresource-granularity"></a><span id="Without_tiling__memory_allocations_are_managed_at_subresource_granularity"></span><span id="without_tiling__memory_allocations_are_managed_at_subresource_granularity"></span><span id="WITHOUT_TILING__MEMORY_ALLOCATIONS_ARE_MANAGED_AT_SUBRESOURCE_GRANULARITY"></span>タイル表示を行わない場合、メモリ割り当てはサブリソースの詳細レベルで管理される


ストリーミング リソースのサポートがないグラフィックス システム (オペレーティング システム、ディスプレイ ドライバー、およびグラフィックス ハードウェア) では、グラフィックス システムは、すべての Direct3D のメモリ割り当てをサブリソースの詳細レベルで管理します。

[バッファー](introduction-to-buffers.md)の場合、バッファー全体がサブリソースです。

[テクスチャ](textures.md) ([**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) など) の場合、各ミップ レベルがサブリソースです。テクスチャ配列 ([**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) など) の場合、特定の配列スライスの各ミップ レベルがサブリソースです。 グラフィックス システムは、このサブリソースの詳細レベルで割り当てのマッピングを管理できることだけを公開します。 ストリーミング リソースのコンテキストでは、"マッピング" はデータを GPU に見えるようにすることを指します。

## <a name="span-idwithouttilingcantaccessonlyasmallportionofmipmapchainspanspan-idwithouttilingcantaccessonlyasmallportionofmipmapchainspanspan-idwithouttilingcantaccessonlyasmallportionofmipmapchainspanwithout-tiling-cant-access-only-a-small-portion-of-mipmap-chain"></a><span id="Without_tiling__can_t_access_only_a_small_portion_of_mipmap_chain"></span><span id="without_tiling__can_t_access_only_a_small_portion_of_mipmap_chain"></span><span id="WITHOUT_TILING__CAN_T_ACCESS_ONLY_A_SMALL_PORTION_OF_MIPMAP_CHAIN"></span>タイル表示を行わない場合、ミップマップ チェーンの一部にのみアクセスすることはできない


特定のレンダリング操作で、画像のミップマップ チェーンの一部 (特定のミップマップの全領域でもない) にのみアクセスする必要があることがアプリケーションにわかっているとします。 理想的には、アプリはこの必要性についてグラフィックス システムに通知できます。 そして、グラフィックス システムは、大量のメモリでページングせず、必要なメモリが GPU にマップされることだけを考えればよくなります。

実際には、ストリーミング リソースのサポートがないと、グラフィックス システムには、サブリソースの詳細レベルで GPU にマップする必要があるメモリに関してのみ通知されます (たとえば、アクセスできる全体のミップマップ レベルの範囲)。 グラフィックス システムにはデマンド フォールトがないため、潜在的にはメモリのいずれかの部分を参照するレンダリング コマンドが実行される前に、サブリソースの完全なマッピングを行うために余分な GPU メモリを大量に使用することが必要になる可能性があります。 これは、ストリーミング リソースのサポートがないときに、Direct3D で大量のメモリの割り当てを使用することを難しくする問題の 1 つにすぎません。

## <a name="span-idsoftwarepagingtobreakthesurfaceintosmallertilesspanspan-idsoftwarepagingtobreakthesurfaceintosmallertilesspanspan-idsoftwarepagingtobreakthesurfaceintosmallertilesspansoftware-paging-to-break-the-surface-into-smaller-tiles"></a><span id="Software_paging_to_break_the_surface_into_smaller_tiles"></span><span id="software_paging_to_break_the_surface_into_smaller_tiles"></span><span id="SOFTWARE_PAGING_TO_BREAK_THE_SURFACE_INTO_SMALLER_TILES"></span>サーフェスを小さいタイルに分割するソフトウェア ページング


ソフトウェア ページングを使用して、サーフェスをハードウェアが処理できる小さいタイルに分割することができます。

Direct3D は、特定の辺で最大 16384 ピクセルある [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) サーフェスをサポートします。 幅 16384 × 高さ 16384、1 ピクセルあたり 4 バイトの画像は、1 GB のビデオ メモリを消費します (ミップマップを追加すると、その量の倍になります)。 実際には、1 つのレンダリング操作で 1 GB 全体の参照が必要になることはほとんどありません。

一部のゲーム開発者は、地形のサーフェスを 128 K × 128 K の大きさでモデル化します。 彼らがこれを既存の GPU で動作させる方法は、サーフェスをハードウェアが処理できる小さいタイルに分割することです。 アプリケーションは、どのタイルが必要になるかを調べて、それらを GPU でテクスチャのキャッシュに読み込む必要があります。これがソフトウェア ページング システムです。

その方法の大きな欠点は、ハードウェアが進行中のページングについて何もわからないことから生じます。画面に表示する必要がある画像の一部がタイルをまたいでいるとき、ハードウェアにはタイルをまたいで効率的にフィルター処理する固定関数を実行する方法がわかりません。 つまり、ソフトウェアのタイル処理を管理しているアプリケーションが、シェーダー コードでテクスチャのフィルター処理を手動で行うか (これは、高品質の異方性フィルターが必要な場合に非常に高価になります)、固定関数によるハードウェア フィルター処理が補助し続けられるように、メモリを浪費して隣接するタイルのデータを格納するガターをタイルの周囲に作成する必要があります。

## <a name="span-idmakingtiledrepresentationofsurfaceallocationsafirst-classfeaturespanspan-idmakingtiledrepresentationofsurfaceallocationsafirst-classfeaturespanspan-idmakingtiledrepresentationofsurfaceallocationsafirst-classfeaturespanmaking-tiled-representation-of-surface-allocations-a-first-class-feature"></a><span id="Making_tiled_representation_of_surface_allocations_a_first-class_feature"></span><span id="making_tiled_representation_of_surface_allocations_a_first-class_feature"></span><span id="MAKING_TILED_REPRESENTATION_OF_SURFACE_ALLOCATIONS_A_FIRST-CLASS_FEATURE"></span>サーフェスの割り当てのタイル表現を最上位の機能にする


サーフェスの割り当てのタイル表現がグラフィックス システムで最上位の機能であれば、アプリケーションはどのタイルを利用できるようにするかをハードウェアに伝えることができます。 この方法で、アクセスされないことがアプリケーションにわかっているサーフェイスの領域を保存するために浪費する GPU メモリが少なくなり、ハードウェアは隣接するタイルにわたってフィルター処理する方法を理解でき、ソフトウェアのタイル処理を実行している開発者が経験する問題点の一部が軽減されます。

しかし、完全なソリューションを提供するには、サーフェス内のタイル処理がサポートされるかどうかに関係なく、サーフェスの現在の最大サイズは既にアプリケーションが必要としている 128 K 以上にはほど遠い 16384 であることに対応するために何かをする必要があります。 ハードウェアにより大きいテクスチャ サイズをサポートするように求めることも 1 つの方法ですが、その方向に進むことには大きなコスト増やトレードオフがあります。

Direct3D のテクスチャ フィルター パスとレンダリング パスは、16 K テクスチャのサポートでの精度に関しては、レンダリング中にサーフェスから離れるビューポートの範囲のサポートや、フィルター処理中のサーフェスのエッジからのテクスチャの折り返しのサポートなど他の要求で既に飽和状態です。 可能な方法は、テクスチャ サイズが 16K を超えて増えるにつれて、機能/精度をある程度落とすようにトレードオフを定義することです。 ただし、ここで譲歩しても、より大きいテクスチャ サイズに移行できるようにハードウェア システム全体にわたる能力を増強するためには、追加のハードウェア コストが必要になることがあります。

## <a name="span-idissuewithlargetexturesprecisionforlocationsonsurfacespanspan-idissuewithlargetexturesprecisionforlocationsonsurfacespanspan-idissuewithlargetexturesprecisionforlocationsonsurfacespanissue-with-large-textures-precision-for-locations-on-surface"></a><span id="Issue_with_large_textures__precision_for_locations_on_surface"></span><span id="issue_with_large_textures__precision_for_locations_on_surface"></span><span id="ISSUE_WITH_LARGE_TEXTURES__PRECISION_FOR_LOCATIONS_ON_SURFACE"></span>大きいテクスチャの問題: サーフェス上の位置の精度


テクスチャが非常に大きくなるにつれて出てくる問題の 1 つは、単精度浮動小数点のテクスチャ座標 (およびラスター化をサポートするための関連する補間操作) では、サーフェス上の位置を正確に指定する精度が足りなくなることです。 テクスチャのフィルター処理が不安定になります。 高価なオプションの 1 つは倍精度の補間操作のサポートを求めることですが、妥当な代替案としては過剰になる可能性があります。

## <a name="span-idenablingmultipleresourcesofdifferentdimensionstosharememoryspanspan-idenablingmultipleresourcesofdifferentdimensionstosharememoryspanspan-idenablingmultipleresourcesofdifferentdimensionstosharememoryspanenabling-multiple-resources-of-different-dimensions-to-share-memory"></a><span id="Enabling_multiple_resources_of_different_dimensions_to_share_memory"></span><span id="enabling_multiple_resources_of_different_dimensions_to_share_memory"></span><span id="ENABLING_MULTIPLE_RESOURCES_OF_DIFFERENT_DIMENSIONS_TO_SHARE_MEMORY"></span>さまざまなサイズの複数のリソースがメモリを共有できるようにする


ストリーミング リソースによって処理できるもう 1 つのシナリオは、さまざまなサイズ/形式の複数のリソースが同じメモリを共有できるようにすることです。 アプリケーションで、同時に使用しないことがわかっている排他的なリソースのセットや、非常に短時間だけ使用するために作成されて破棄されるリソース (その後に他のリソースが作成される) を処理することがあります。 "ストリーミング リソース" から離れることが可能な一般論として、ユーザーが同じ (重なり合う) メモリにある複数の異なるリソースを指すことを許可することができます。 つまり、"リソース" の作成と破棄 (サイズ/形式を定義するなど) は、アプリケーションの視点からリソースの基になるメモリの管理から切り離すことができます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソース](streaming-resources.md)

 

 




