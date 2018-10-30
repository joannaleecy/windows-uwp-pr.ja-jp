---
title: タイル プールの作成
description: アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは、グラフィックス処理装置 (GPU) メモリの 1/4 ではほぼ Direct3D11 のリソース サイズ制限に制限されます。
ms.assetid: BD51EDD3-4AD3-4733-B014-DD77B9D743BB
keywords:
- タイル プールの作成
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: cbb8b61c8eeef1a842a7c6b61d09670f056bb409
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5758037"
---
# <a name="tile-pool-creation"></a>タイル プールの作成


アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは、グラフィックス処理装置 (GPU) メモリの 1/4 ではほぼ Direct3D11 のリソース サイズ制限に制限されます。

タイル プールは 64 KB のタイルで構成されますが、舞台裏ではオペレーティング システム (ディスプレイ ドライバー) が 1 つ以上の割り当てとしてプール全体を管理します。処理の詳細はアプリケーションには見えません。 ストリーミング リソースは、タイル プール内のタイルをポイントしてコンテンツを定義します。 ストリーミング リソースからのタイルのマッピング解除は、タイルに **NULL** を指させることで行われます。 このようなマップされていないタイルには、読み書きの動作に関する規則があります。詳しくは、「[ハザード追跡対タイル プール リソース](hazard-tracking-versus-tile-pool-resources.md)」をご覧ください。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[タイル プールにマッピングされます](mappings-are-into-a-tile-pool.md)

 

 




