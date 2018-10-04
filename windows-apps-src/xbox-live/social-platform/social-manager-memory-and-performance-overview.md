---
title: Social Manager のメモリーとパフォーマンス
author: KevinAsgari
description: Xbox Live Social Manager API マネージャーを使う場合のメモリとパフォーマンスに関する考慮事項について説明します。
ms.assetid: 2540145e-b8e2-4ab5-9390-65e2c9b19792
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, social manager, people
ms.localizationpriority: medium
ms.openlocfilehash: 4e32ea2c1938bc72642d8affa031dffd538d4feb
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4317953"
---
# <a name="social-manager-memory-and-performance-overview"></a>Social Manager のメモリーとパフォーマンスの概要

## <a name="memory"></a>メモリ
Social Manager は、割り当てられた永続的なメモリーをタイトル領域内に保持できるようになりました。 Social Manager が使用するためのカスタム メモリー アロケーターを指定するには、`xbox_live_services_settings::set_memory_allocation_hooks()` を呼び出します。 このメモリー アロケーターのフックは、Xbox Live API (XSAPI) が使用する将来の大規模なメモリーの割り当てに使用することもできます。

Social Manager によるメモリーの割り当ては、既定では最も少ない場合で約 4.75 MB です (1)。 RTA および HTTP の更新に基づいて、Social Manager によって追加のオーバーヘッドが割り当てられる場合もあります。 リストから `xbox_social_user_group` を作成する場合、追加されるメンバーごとにさらに 2.43 KB が使用されます。 ユーザーが `create_social_social_user_group_from_list` もしくは `update_social_user_group` を介して追加された場合、またはユーザーがタイトルの外部でフレンドを追加した場合には、連続したメモリー領域を検索するために再割り当てが行われることがあります。

(1) 4.75 MB の根拠は、`xbox_social_user` 1000人分 (各 2.43 KB × 2) です。 2 倍は、ソーシャル マネージャーが保持するメモリ バッファーが 2 つあるからです。

## <a name="additional-user-limits"></a>その他のユーザーの制限
現在、Social Manager にはグラフに追加できるユーザー数に 100 人の制限があります。 これは、以下の 2 つの問題が原因です。

1. ユーザーが持つことができる RTA サブスクリプションの最大数は、1100 です。 ローカルのユーザーに、1000 人のフレンドがいる場合は、追加のサブスクリプションは 100 人分だけです。
2. PeopleHub に送信できるユーザーの最大バッチ数は現在、約 100 です。

Social Manager は、これらの制限のために、リストのソーシャル ユーザー グループに 100 人を超えるユーザーを追加することを許可しません。 `create_social_user_group_from_list` を介して任意の時点でシステム内に存在できる追加ユーザーの合計には、100 というグローバルな制限があります。

## <a name="processing-time"></a>Processing Time の収集
Social Manager は、最も少ない場合で 1100 人のユーザーを処理します。 Xbox One の Social Manager のパフォーマンス特性は、作成するソーシャル グラフの数に応じて、`do_work` について最も低い場合で 0.3 ms ～ 0.5 ms です。 典型的な例では、グループが作成されない場合は 0.01 ms、中に 1000 人のユーザーがいるグループの場合は最大 0.2 ms です。
