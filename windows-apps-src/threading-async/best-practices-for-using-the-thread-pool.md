---
ms.assetid: 95CF7F3D-9E3A-40AC-A083-D8A375272181
title: スレッド プールを使うためのベスト プラクティス
description: このトピックでは、スレッド プールを使った操作のベスト プラクティスについて説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、スレッド、スレッド プール
ms.localizationpriority: medium
ms.openlocfilehash: 6c004feabf561c5a94fadba858762bf683c9ff0e
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7964824"
---
# <a name="best-practices-for-using-the-thread-pool"></a>スレッド プールを使うためのベスト プラクティス

このトピックでは、スレッド プールを使った操作のベスト プラクティスについて説明します。

## <a name="dos"></a>推奨


-   スレッド プールを使って、アプリの並列処理を実行します。

-   作業項目を使って、UI スレッドをブロックせずに広範なタスクを実行します。

-   有効期間が短く独立した作業項目を作成します。 作業項目は非同期に実行され、キューから任意の順番でプールに送ることができます。

-   [**Windows.UI.Core.CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/BR208211) を使って更新を UI スレッドにディスパッチします。

-   **Sleep** 関数ではなく [**ThreadPoolTimer.CreateTimer**](https://msdn.microsoft.com/library/windows/apps/Hh967921) 関数を使います。

-   独自のスレッド管理システムを作成するのではなく、スレッド プールを使います。 スレッド プールは、OS レベルで高度な機能を使って実行され、プロセス内およびシステム全体のデバイス リソースとアクティビティに従って動的にスケーリングされるように最適化されています。

-   C++ の場合、作業項目委任でアジャイル スレッド モデルを使うようにします (C++ 委任は既定でアジャイルです)。

-   使用の時点でリソース割り当ての失敗を許容できない場合は、あらかじめ割り当てられた作業項目を使用します。

## <a name="donts"></a>非推奨


-   *period* の値が 1 ミリ秒未満 (0 秒を含む) の定期タイマーを作成しないでください。 この場合、作業項目は 1 回限りのタイマーとして動作します。

-   *period* パラメーターで指定した時間よりも完了までに時間がかかる定期的な作業項目を送信しないでください。

-   バックグラウンド タスクからディスパッチされている作業項目から、UI 更新 (トーストと通知を除く) を送信しないでください。 代わりに、バックグラウンド タスクの進行ハンドラーと完了ハンドラー ([**IBackgroundTaskInstance.Progress**](https://msdn.microsoft.com/library/windows/apps/BR224800) など) を使います。

-   **async** キーワードを使用する作業項目ハンドラーを使用する場合は、ハンドラーのすべてのコードの実行が完了する前にスレッド プール作業項目が完了状態に設定される可能性があることに注意してください。 ハンドラー内の **await** キーワードに続くコードは、作業項目が完了状態に設定された後で実行される可能性があります。

-   あらかじめ割り当てられた作業項目を複数回実行する場合は、1 回実行するたびに再初期化してください。 [定期的な作業項目の作成](create-a-periodic-work-item.md)

## <a name="related-topics"></a>関連トピック


* [定期的な作業項目の作成](create-a-periodic-work-item.md)
* [スレッド プールへの作業項目の送信](submit-a-work-item-to-the-thread-pool.md)
* [タイマーを使った作業項目の送信](use-a-timer-to-submit-a-work-item.md)
