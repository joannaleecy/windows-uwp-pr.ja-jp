---
title: "タイル プールの作成"
description: "アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは、Direct3D 11 のリソース サイズの上限に制限されます。上限はグラフィックス処理装置 (GPU) の RAM の約 1/4 です。"
ms.assetid: BD51EDD3-4AD3-4733-B014-DD77B9D743BB
keywords:
- "タイル プールの作成"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 5289bcb57572ede45c6853b0077f5baa82af7ca2
ms.lasthandoff: 02/07/2017

---

# <a name="tile-pool-creation"></a>タイル プールの作成


アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは、Direct3D 11 のリソース サイズの上限に制限されます。上限はグラフィックス処理装置 (GPU) の RAM の約 1/4 です。

タイル プールは 64 KB のタイルで構成されますが、舞台裏ではオペレーティング システム (ディスプレイ ドライバー) が 1 つ以上の割り当てとしてプール全体を管理します。処理の詳細はアプリケーションには見えません。 ストリーミング リソースは、タイル プール内のタイルをポイントしてコンテンツを定義します。 ストリーミング リソースからのタイルのマッピング解除は、タイルに **NULL** を指させることで行われます。 このようなマップされていないタイルには、読み書きの動作に関する規則があります。詳しくは、「[ハザード追跡対タイル プール リソース](hazard-tracking-versus-tile-pool-resources.md)」をご覧ください。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[タイル プールにマッピングされます](mappings-are-into-a-tile-pool.md)

 

 





