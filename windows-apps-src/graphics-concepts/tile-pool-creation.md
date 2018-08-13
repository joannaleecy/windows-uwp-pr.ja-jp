---
title: タイル プールの作成
description: アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは、Direct3D 11 のリソース サイズの上限に制限されます。上限はグラフィックス処理装置 (GPU) の RAM の約 1/4 です。
ms.assetid: BD51EDD3-4AD3-4733-B014-DD77B9D743BB
keywords:
- タイル プールの作成
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 4336d38bca354da3c30cfe2d7e4b092cff15af83
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1043591"
---
# <a name="tile-pool-creation"></a>タイル プールの作成


アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは、Direct3D 11 のリソース サイズの上限に制限されます。上限はグラフィックス処理装置 (GPU) の RAM の約 1/4 です。

タイル プールは 64 KB のタイルで構成されますが、舞台裏ではオペレーティング システム (ディスプレイ ドライバー) が 1 つ以上の割り当てとしてプール全体を管理します。処理の詳細はアプリケーションには見えません。 ストリーミング リソースは、タイル プール内のタイルをポイントしてコンテンツを定義します。 ストリーミング リソースからのタイルのマッピング解除は、タイルに **NULL** を指させることで行われます。 このようなマップされていないタイルには、読み書きの動作に関する規則があります。詳しくは、「[ハザード追跡対タイル プール リソース](hazard-tracking-versus-tile-pool-resources.md)」をご覧ください。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[タイル プールにマッピングされます](mappings-are-into-a-tile-pool.md)

 

 




