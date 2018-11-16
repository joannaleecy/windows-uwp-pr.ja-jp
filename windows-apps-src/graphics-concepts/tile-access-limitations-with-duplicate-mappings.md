---
title: 重複するマッピングを含むタイルのアクセス制限
description: コピー元とコピー先が重複しているストリーミング リソースをコピーする場合や、レンダー領域内で共有されるタイルにレンダリングする場合などでは、重複するマッピングを含むタイル アクセスに制限があります。
ms.assetid: 6E40B1DC-BCF1-4B09-82A8-7B2D9B209A61
keywords:
- 重複するマッピングを含むタイルのアクセス制限
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ce8f71f126aa536f4e235c58f9f5c5ddf13654df
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6977794"
---
# <a name="tile-access-limitations-with-duplicate-mappings"></a>重複するマッピングを含むタイルのアクセス制限


コピー元とコピー先が重複しているストリーミング リソースをコピーする場合や、レンダー領域内で共有されるタイルにレンダリングする場合などでは、重複するマッピングを含むタイル アクセスに制限があります。

## <a name="span-idcopyingstreamingresourceswithoverlappingsourceanddestinationspanspan-idcopyingstreamingresourceswithoverlappingsourceanddestinationspanspan-idcopyingstreamingresourceswithoverlappingsourceanddestinationspancopying-streaming-resources-with-overlapping-source-and-destination"></a><span id="Copying_streaming_resources_with_overlapping_source_and_destination"></span><span id="copying_streaming_resources_with_overlapping_source_and_destination"></span><span id="COPYING_STREAMING_RESOURCES_WITH_OVERLAPPING_SOURCE_AND_DESTINATION"></span>コピー元とコピー先が重複しているストリーミング リソースのコピー


Copy\* 操作のコピー元とコピー先の領域内のタイルで、重なり合ったコピー領域に重複したマッピングがある場合、両方のリソースがストリーミング リソースではなく、Copy\* 操作が重なり合ったコピーをサポートしている場合でも、Copy\* 操作は正常に動作します (コピー先に移動する前にコピー元が一時的な場所にコピーされているように)。 しかし、重なりが明白でない場合 (コピー元とコピー先のリソースは異なるが、それらがマッピング共有しているか、特定のサーフェイス上でマッピングが重複している場合など)、共有されるタイルでのコピー操作の結果は定義されていません。

## <a name="span-idcopyingtostreamingresourcewithduplicatedtilesindestinationareaspanspan-idcopyingtostreamingresourcewithduplicatedtilesindestinationareaspanspan-idcopyingtostreamingresourcewithduplicatedtilesindestinationareaspancopying-to-streaming-resource-with-duplicated-tiles-in-destination-area"></a><span id="Copying_to_streaming_resource_with_duplicated_tiles_in_destination_area"></span><span id="copying_to_streaming_resource_with_duplicated_tiles_in_destination_area"></span><span id="COPYING_TO_STREAMING_RESOURCE_WITH_DUPLICATED_TILES_IN_DESTINATION_AREA"></span>コピー先の領域に重複するタイルがあるストリーミング リソースへのコピー


コピー先の領域に重複するタイルがあるストリーミング リソースにコピーすると、データ自体がまったく同じでない限り、それらのタイルでは未定義の結果になります。異なるタイルは異なる順序でタイルを書き込むことがあります。

## <a name="span-iduavaccessestoduplicatetilesmappingsspanspan-iduavaccessestoduplicatetilesmappingsspanspan-iduavaccessestoduplicatetilesmappingsspanuav-accesses-to-duplicate-tiles-mappings"></a><span id="UAV_accesses_to_duplicate_tiles_mappings"></span><span id="uav_accesses_to_duplicate_tiles_mappings"></span><span id="UAV_ACCESSES_TO_DUPLICATE_TILES_MAPPINGS"></span>重複するタイル マッピングへの UAV アクセス


ストリーミング リソースの順序指定されていないアクセス ビュー (UAV) に、その領域内に重複するタイル マッピングがあるか、またはパイプラインにバインドされた他のリソースとの重複があるとします。 一般に UAV へのメモリ アクセスの順序が指定されていないように、異なるスレッドによって実行された場合、これらの重複するタイルへのアクセスの順序指定は定義されていません。

## <a name="span-idrenderingaftertilemappingchangesorcontentupdatesfromoutsidemappingsspanspan-idrenderingaftertilemappingchangesorcontentupdatesfromoutsidemappingsspanspan-idrenderingaftertilemappingchangesorcontentupdatesfromoutsidemappingsspanrendering-after-tile-mapping-changes-or-content-updates-from-outside-mappings"></a><span id="Rendering_after_tile_mapping_changes_or_content_updates_from_outside_mappings"></span><span id="rendering_after_tile_mapping_changes_or_content_updates_from_outside_mappings"></span><span id="RENDERING_AFTER_TILE_MAPPING_CHANGES_OR_CONTENT_UPDATES_FROM_OUTSIDE_MAPPINGS"></span>タイル マッピングの変更後、または外部マッピングからのコンテンツ更新後のレンダリング


ストリーミング リソースのタイル マッピングが変更された場合、または別のストリーミング リソースのマッピングを使用して、マップされたタイル プールのタイルのコンテンツが変更され、ストリーミング リソースがレンダー ターゲット ビューまたは深度ステンシル ビューを介してレンダリングされる場合、アプリケーションはレンダリングされている領域内で変更されたタイルをクリアするか (固定関数の Clear API を使用)、Copy\*/Update\* API を使用して完全にコピーする必要があります。

これらの場合にアプリケーションがクリアまたはコピーに失敗すると、特定のレンダー ターゲット ビューまたは深度ステンシル ビューのハードウェア最適化構造が古くなり、さまざまなハードウェアにわたって一部のハードウェアと不整合に関するガベージ レンダリングの結果になります。 ハードウェアで使われるこれらの非表示の最適化データ構造は、個々のマッピングにローカルで、同じメモリへの他のマッピングには表示されないことがあります。

リソース ビューをクリアするとき (リソース ビュー内のすべての要素を 1 つの値に設定)、レンダー ターゲット ビューを長方形でクリアできます。 ストリーミング リソースをサポートするハードウェアの場合、リソース ビューをクリアする際は、深度のみのサーフェス (ステンシルなし) のために四角形による深度ステンシル ビューのクリアもサポートする必要があります。 この操作により、アプリケーションはサーフェスの必要領域だけをクリアできます。

アプリケーションは、マッピングが変更されているストリーミング リソース内の領域の既存のメモリ内容を維持する必要がある場合、クリアの要件を回避する必要があります。 アプリケーションは、まずタイル マッピングが変更された部分の内容を保存し (一時的なサーフェスにコピー)、必要なクリア コマンドを発行してから内容をコピーして戻すことで、この回避策を実現できます。 これで、段階的なレンダリング用にサーフェスの内容を維持するタスクは達成されますが、欠点は、レンダリングの最適化が失われる可能性があるため、そのサーフェス上での後続のレンダリングのパフォーマンスが低下する可能性があることです。

タイルが同時に複数のストリーミング リソースにマップされ、タイルのコンテンツがストリーミング リソースの 1 つを経由して何らかの手段 (レンダー、コピー、およびその他) で操作される場合、その同じタイルが他のストリーミング リソースによってレンダリングされる場合は、まず前述のようにタイルをクリアする必要があります。

## <a name="span-idrenderingtotilessharedoutsiderenderareaspanspan-idrenderingtotilessharedoutsiderenderareaspanspan-idrenderingtotilessharedoutsiderenderareaspanrendering-to-tiles-shared-outside-render-area"></a><span id="Rendering_to_tiles_shared_outside_render_area"></span><span id="rendering_to_tiles_shared_outside_render_area"></span><span id="RENDERING_TO_TILES_SHARED_OUTSIDE_RENDER_AREA"></span>レンダー領域の外部で共有されるタイルへのレンダリング


ストリーミング リソース内の領域がレンダリングされていて、レンダー領域によって参照されるタイル プールのタイルもレンダー領域の外部からマップされているとします (他のストリーミング リソース経由などで同時または同時ではなく)。 これらのタイルにレンダリングされるデータは、他のマッピングを通じて表示されると、基になるメモリ レイアウトに互換性がある場合でも正しく表示される保証はありません。 これは、ハードウェアで使われるこれらの非表示の最適化データ構造は、レンダリング可能なサーフェスの個々のマッピングにローカルなことがあり、同じメモリ位置への他のマッピングには表示されないことがあるためです。

レンダリングされたマッピングから、アクセス可能な同じメモリへの他のすべてのマッピングにコピーして (または、そのメモリをクリアするか、不要な古い内容の場合は他のデータをコピーして)、この制限を回避することができます。 この回避策は冗長に思えますが、同じメモリへの他のすべてのマッピングがその内容にアクセスする方法を正しく理解でき、少なくとも 1 つの物理メモリだけにバックアップすることによるメモリの節約はそのまま残ります。

また、マッピングを共有するストリーミング リソースの使用を切り替えるとき (読み込みのみの場合を除く)、複数のタイル リソース間、および切り替えの間のデータ アクセスの順序の制約 (障壁) を指定する必要があります。

## <a name="span-idrenderingtotilessharedwithinrenderareaspanspan-idrenderingtotilessharedwithinrenderareaspanspan-idrenderingtotilessharedwithinrenderareaspanrendering-to-tiles-shared-within-render-area"></a><span id="Rendering_to_tiles_shared_within_render_area"></span><span id="rendering_to_tiles_shared_within_render_area"></span><span id="RENDERING_TO_TILES_SHARED_WITHIN_RENDER_AREA"></span>レンダー領域の内部で共有されるタイルへのレンダリング


ストリーミング リソース内の領域がレンダリングされ、レンダー領域内で複数のタイルが同じタイル プールの場所にマップされている場合、それらのタイルでのレンダリングの結果は定義されていません。

## <a name="span-iddatacompatibilityacrossstreamingresourcessharingtilesspanspan-iddatacompatibilityacrossstreamingresourcessharingtilesspanspan-iddatacompatibilityacrossstreamingresourcessharingtilesspandata-compatibility-across-streaming-resources-sharing-tiles"></a><span id="Data_compatibility_across_streaming_resources_sharing_tiles"></span><span id="data_compatibility_across_streaming_resources_sharing_tiles"></span><span id="DATA_COMPATIBILITY_ACROSS_STREAMING_RESOURCES_SHARING_TILES"></span>タイルを共有するストリーミング リソース全体でのデータの互換性


複数のストリーミング リソースに同じタイル プールの場所へのマッピングがあり、各リソースが同じデータにアクセスするために使用されるとします。 このシナリオが有効なのは、ハードウェア最適化構造の問題を回避することに関するその他の規則が避けられ、適切な障壁が指定され (複数のタイル リソース間のデータ アクセス順序の制約を指定)、ストリーミング リソースに互いに互換性がある場合だけです。

後者はここでは、タイルを共有するストリーミング リソースに互換性がないという意味に関して記述されています。 重複するタイル マッピング全体で同じデータにアクセスすることに互換性がない条件は、異なるサーフェスのサイズや形式を使用していること、またはリソースに関するレンダー ターゲットまたは深度ステンシル バインド フラグの存在に違いがあることです。 1 種類のマッピングでメモリに書き込み、互換性のないリソースからのマッピングを使って続けて読み込んだりレンダリングしたりすると、定義されていない結果になります。

マッピングを共有する他のリソースが最初に新しい値で初期化された場合は (さまざまな目的でメモリをリサイクル)、データが互換性のない解釈で乱されないため、それに続く読み取りまたはレンダリング操作では問題が発生しません。 しかし、上記のように互換性のないマッピングへのアクセスの間で切り替える際は、障壁を指定する必要があります (複数のタイル リソース間のデータ アクセス順序の制約を指定)。

レンダー ターゲットまたは深度ステンシル バインド フラグが、互いにマッピングを共有するリソースのいずれにも設定されていない場合、制限ははるかに少なくなります。 形式とサーフェスの種類 (Texture2D など) が同じであれば、タイルを共有することができます。 異なる形式に互換性があるのは、BC6H と R32G32B32A32 のように、BC\* サーフェスと同等サイズのコンポーネントあたり非圧縮 32 ビットまたは 16 ビットの形式などの場合です。 要素あたり 32 ビットの形式の多くも、同様に R32\_\* とのエイリアスを設定できます (R10G10B10A2\_\*、R8G8B8A8\_\*、B8G8R8A8\_\*、B8G8R8X8\_\*,R16G16\_\*)。この操作は非ストリーミング リソースには常に許されました。

形式に互換性があり、タイルが単色で塗りつぶされている場合は、パックされたタイルとパックされていないタイルの間で共有することができます。

最後に、レンダー ターゲットまたは深度ステンシル バインド フラグがあるリソースがないこと以外、タイル マッピングを共有するリソースに関して何も共通していない場合、0 で満たされたメモリのみが安全に共有できます。マッピングは、特定のリソース形式の定義に関して 0 のデコード結果として表示されます (通常は 0 だけ)。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースへのパイプライン アクセス](pipeline-access-to-streaming-resources.md)

 

 




