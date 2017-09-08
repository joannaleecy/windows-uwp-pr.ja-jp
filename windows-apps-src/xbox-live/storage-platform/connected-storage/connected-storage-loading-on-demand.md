---
title: "接続ストレージのオンデマンド読み込み"
author: KevinAsgari
description: "接続ストレージ データをすべて一度に読み込むのではなくオンデマンドで読み込む方法について説明します。"
ms.assetid: a0797a14-c972-4017-864c-c6ba0d5a3363
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ"
ms.openlocfilehash: a0c1e15a163dce8e64eee177497ff8febad27e10
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="connected-storage-loading-on-demand"></a>接続ストレージのオンデマンド読み込み

*GetSyncOnDemandForUserAsync* を使用すると、クラウド バックアップ データを接続ストレージ領域から、一度にまとめてではなく、"オンデマンド" で読み込むことができます。 これにより、保存ファイルが特に大きい場合は、*GetForUserAsync* を使用するよりもパフォーマンスを向上させることができます。

### <a name="to-load-data-from-a-connected-storage-space-on-demand"></a>オンデマンドで接続ストレージ領域からデータを読み込むには

1.  *GetSyncOnDemandForUserAsync* を呼び出します。 これにより、コンテナーの内容ではなく、コンテナーのリストとメタデータをクラウドからダウンロードする部分的な同期がトリガーされます。 この操作は高速なので、適切なネットワーク条件下では、ユーザーには読み込み中の UI は表示されません。

2.  *GetContainerInfo2Async* を使用してコンテナー クエリを実行します。 これにより、3 つの新しいメタデータ フィールドを含む *ContainerInfo2* のコレクションが返されます。

    -   *DisplayName*: 表示名の文字列をパラメーターとして受け取る *SubmitUpdatesAsync* のオーバーロードを使用して作成した表示名。 常にこのフィールドを使用して、ユーザーにわかりやすい名前を格納することをお勧めします。
    -   *LastModifiedTime*: このコンテナーが最後に変更された時刻。 ローカルとリモートのタイムスタンプが競合する場合は、リモートのタイムスタンプが使用されます。
    -   *NeedsSync*: このコンテナーのデータをクラウドからダウンロードする必要があるかどうかを示すブール値。

    この追加のメタデータを使用することで、実際にはクラウドからの完全ダウンロードを実行せずに、セーブ データについての主要な情報 (名前、最後に使用された時刻、選択した場合にダウンロードが必要かどうかなど) をユーザーに表示できます。

3.  次のいずれかの既存の接続ストレージ API を呼び出すことによって同期をトリガーします。

    -   *BlobInfoQueryResult::GetBlobInfoAsync*
    -   *BlobInfoQueryResult::GetItemCountAsync*
    -   *ConnectedStorageContainer::GetAsync*
    -   *ConnectedStorageContainer::ReadAsync*
    -   *ConnectedStorageSpace::DeleteContainerAsync*

    これにより、選択したコンテナーのデータがダウンロードされていることを示す通常の同期 UI と進行状況バーがユーザーに表示されます。 選択したコンテナーのデータのみが同期され、その他のコンテナーのデータはダウンロードされません。

    オンデマンドによる同期のコンテキストでこれらの API を呼び出すと、それらの操作のすべてで、以下の新しいエラー コードが生成されます。

    -   *ConnectedStorageErrorStatus::ContainerSyncFailed*: このエラーは、操作が失敗し、コンテナーをクラウドと同期できなかったことを示します。 ほとんどの場合、同期に失敗するのはユーザーのネットワークの状態が原因です。 その場合、ユーザーはネットワークを調整した後にもう一度やり直すか、または同期を必要としないコンテナーを使用することを選択できます。 これらのオプションのいずれかを UI で選択できる必要があります。 システム UI の再試行のダイアログ ボックスはユーザーに既に表示されているので、再試行のダイアログ ボックスは必要ありません。

    -   *ConnectedStorageErrorStatus::ContainerNotInSync*: このエラーは、同期されていないコンテナーへの書き込みをタイトルが誤って実行しようとしたことを示します。 NeedsSync フラグが true に設定されているコンテナーに対して *ConnectedStorageContainer::SubmitUpdates* を呼び出すことはできません。 コンテナーに書き込む前に、まず、同期をトリガーするためにそのコンテナーを読み取る必要があります。 コンテナーの読み取りを行わずにそこに書き込む場合、そのタイトルは、ユーザーの進行状況を失うかもしれないという欠陥を持つ可能性があります。

        この動作は、ユーザーがオフラインでプレイする場合とは異なります。 オフライン時は、コンテナーが同期されているかどうかは示されないので、後で競合を解決するのはユーザーの責任となります。 ただし、この場合、システムはユーザーが同期を必要としていることを把握しているので、ユーザーが古いコンテナーを使用して間違った状態にすることは許可されません (ただし、ユーザーが希望する場合は、タイトルを再起動してオフラインでプレイすることもできます)。

4.  接続ストレージ API の残り部分を通常どおりに使用します。 その動作は、オンデマンドで同期するときもそのままです。
