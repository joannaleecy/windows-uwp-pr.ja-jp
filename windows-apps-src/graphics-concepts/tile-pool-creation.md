---
title: タイル プールの作成
description: アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは約 1/4 グラフィックス処理装置 (GPU) メモリは、Direct3D11 のリソース サイズ制限に制限されます。
ms.assetid: BD51EDD3-4AD3-4733-B014-DD77B9D743BB
keywords:
- タイル プールの作成
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 5ce3824ab2d435b42df9586a6c229b68db10a0c9
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7848525"
---
# <a name="tile-pool-creation"></a>タイル プールの作成


アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは約 1/4 グラフィックス処理装置 (GPU) メモリは、Direct3D11 のリソース サイズ制限に制限されます。

タイル プールは 64 KB のタイルで構成されますが、舞台裏ではオペレーティング システム (ディスプレイ ドライバー) が 1 つ以上の割り当てとしてプール全体を管理します。処理の詳細はアプリケーションには見えません。 ストリーミング リソースは、タイル プール内のタイルをポイントしてコンテンツを定義します。 ストリーミング リソースからのタイルのマッピング解除は、タイルに **NULL** を指させることで行われます。 このようなマップされていないタイルには、読み書きの動作に関する規則があります。詳しくは、「[ハザード追跡対タイル プール リソース](hazard-tracking-versus-tile-pool-resources.md)」をご覧ください。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[タイル プールにマッピングされます](mappings-are-into-a-tile-pool.md)

 

 




