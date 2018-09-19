---
title: 接続ストレージの概要
author: aablackm
description: 接続ストレージを使ってデバイス間でゲーム データの保存と読み込みを行う方法について説明します。
ms.assetid: a0bacf59-120a-4ffc-85e1-fbeec5db1308
ms.author: aablackm
ms.date: 02/27/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 754367c1a8d2daaf37d236e65d241b05c52e84d5
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4055731"
---
# <a name="connected-storage"></a>接続ストレージ
接続ストレージは、複数のデバイス間でローミングされる必要があるゲームプレイ データや他の関連するアプリの状態データをタイトルが保存できるように設計されています。 接続ストレージ API を使うと、Xbox One とユニバーサル Windows プラットフォーム (UWP) のタイトルが、ローカルに保存されているタイトル データを保存、読み込み、削除できるようになるだけでなく、Xbox One または UWP タイトルがインターネットに接続されている場合は常にクラウドと同期されます。 保存されたデータは、同期されるとタイトルを実行する他のデバイスで利用できるようになります。 外出中でも最良の形でゲームをプレイできるように、開発者にはタイトルの状態をできる限り正確に保存することをお勧めします。 接続ストレージを利用すると、自宅でゲームのプレイを進めた後、同じゲームをサポートする他のデバイスで、ちょうどゲームを中断した場所から再開できるようになります。

## <a name="connected-storage-features"></a>接続ストレージの機能

接続ストレージ API は、次の機能を提供します。

- アプリでは一度に最大 16 MB のデータをメモリー バッファーにすばやく保存できます。その後データはシステムによって HDD のローカルにキャッシュされ、クラウドにアップロードされます。
- 対象パートナーおよび ID@Xbox 開発者向け:
    - ユーザー/アプリごとに 256 MB のクラウド ストレージ。
- Xbox Live クリエーターズ プログラム開発者向け:
    - ユーザー/アプリごとに 64 MB のクラウド ストレージ。
- 電源障害に対する堅牢な応答 - アプリでは、データの一部しか保存されないケースに対処する必要がありません
- アプリが実行されていない場合を含め、データはクラウドに自動的にアップロードされます。
- データは、Xbox Live に接続されている複数の Xbox One または UWP デバイスで使用できます。
- Xbox Live によってデバイス間の同期と競合の管理が処理されるため、アプリケーションが関与する必要はありません。

接続ストレージ システムでは、すべてのセーブが完全に行われるか、まったく行われません。 つまり、開発者は、電源障害が発生した場合や、ユーザーがアプリを手動で突然閉じたり、本体で別のアプリやゲームを開くことでアプリを閉じたりした場合に、部分的にセーブされたデータがゲームの状態に影響を与えることを心配する必要はありません。 これにより、タイトルのユーザーはゲーム プレイをよりスムーズに楽しむこともできるようになります。接続ストレージを利用することで、ユーザーがゲームやアプリをすばやく自由に切り替えることができると同時に、中断した場所から元のゲームを再開できるようになるからです。 作成したタイトルにこれらの機能を実装するには、接続ストレージ API について理解する必要があります。

## <a name="connected-storage-structure"></a>接続ストレージの構造

接続ストレージ システムにより、アプリはデータを 1 つ以上の BLOB としてコンテナーに格納できます。 大まかに言えば、接続ストレージ システム内のすべてのデータは、ユーザー (Xbox 開発キットで開発されたタイトルの場合はユーザーまたはコンピューター) に関連付けられます。 アプリによって保存される、特定のユーザーまたはマシンのすべてのデータは、接続ストレージ領域に保存されます。 アプリの各ユーザーは接続ストレージ領域を取得しますが、合計で 256 または 64 MB の容量に制限されます。 重要な注意点として、このストレージはアプリ専用であり、他のアプリとは共有されません。

### <a name="containers-and-blobs"></a>コンテナーと BLOB

接続ストレージ コンテナー (または単にコンテナー) はストレージの基本単位です。 次の図に示されているように、それぞれの接続ストレージ領域には多数のコンテナーを含めることができます。

接続ストレージ領域 (タイトル/マシンごとまたはタイトル/ユーザーごと)

![connected_storage_space_containers.png](../../images/connected_storage/connected_storage_space_containers.png)

 データは、BLOB と呼ばれる 1 つ以上のバッファーとしてコンテナー内に保存されます。 次の図は、ディスク上のコンテナーの内部システム表現を示しています。 コンテナーごとに、コンテナー内の各 BLOB に対応するデータ ファイルへの参照を含むコンテナー ファイルがあります。

コンテナーの図

![container_storage_blobs.png](../../images/connected_storage/container_storage_blobs.png)

コンテナーにデータを格納するには、名前および BLOB (Buffer オブジェクト) のマップを指定して、適切な API コンテナー メソッド SubmitUpdatesAsync を呼び出します。 SubmitUpdatesAsync 呼び出しで記述されたすべての変更はアトミックに適用されます。つまり、要求どおりすべての BLOB が更新されるか、操作全体が中止されてコンテナーが呼び出しの前の状態のままとなるかのどちらかです。

SubmitUpdatesAsync を使用する個々の保存処理では、一度に 16 MB のデータに制限されます。

## <a name="connected-storage-api"></a>接続ストレージ API

接続ストレージには、XDK アプリと UWP アプリ用の別個の API があります。 さいわい、これらの API は互いにとても似ています。 2 つの API の主な違いは、名前空間とクラス名です。 API を使ったデータの[保存](connected-storage-saving.md)、[読み込み](connected-storage-loading.md)、[削除](connected-storage-deleting.md)に必要な関数は、同じ名前です。

2 つの接続ストレージ API の他の違いについて詳しくは、「[XDK から UWP への Xbox Live コードの移植](../../using-xbox-live/porting-xbox-live-code-from-xdk-to-uwp.md)」の「接続ストレージ」をご覧ください。

XDK .chm ファイルで説明されている XDK 接続ストレージ API は、パス **Xbox ONE XDK >> API リファレンス >> プラットフォーム API リファレンス >> システム API リファレンス >> Windows.Xbox.Storage** にあります。
XDK API については、[developer.microsoft.com サイト](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/storage-xbox-microsoft-n)でも説明されています。
XDK API へのリンクを開くには、Xbox 開発キット (XDK) へのアクセスが有効になっている Microsoft アカウント (MSA) が必要です。
Windows.Xbox.Storage は、Xbox One 本体の接続ストレージ名前空間の名前です。

Xbox Live SDK .chm ファイルで説明されている UWP 接続ストレージ API は、パス **Xbox Live API >> Xbox Live Platform Extensions SDK API リファレンス >> Windows.Gaming.XboxLive.Storage** にあります。
UWP 接続ストレージ API については、オンラインの [Windows.Gaming.XboxLive.Storage 名前空間参照に関するページ](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.xboxlive.storage)もご覧ください。
Windows.Gaming.XboxLive.Storage は、UWP アプリの接続ストレージ名前空間の名前です。

接続ストレージを使い始めるには、接続ストレージ*領域*を取得する必要があります。 接続ストレージ領域は、ユーザーまたはコンピューターに関連付けられ、そのユーザーまたはコンピューターに関連付けられているすべての接続ストレージ データを*コンテナー*および *BLOB* の形式で保持しています。 コンピューターまたはユーザーの接続ストレージ領域を取得すると、そのエンティティが格納されているデータへの読み取り/書き込みアクセスが可能になります。 接続ストレージ領域を取得するため、XDK タイトルと UWP タイトルの両方が `GetForUserAsync` メソッドを呼び出します。XDK タイトルは `GetForMachineAsync` メソッドを呼び出すこともあります。UWP タイトルは `GetForMachineAsync` を呼び出すことができなくなります。 `GetForUserAsync` と `GetForMachineAsync` は、XDK の `ConnectedStorageSpace` クラスに含まれています。 `GetForUserAsync` は、UWP API の `GameSaveProvider` クラスに含まれています。 これらのメソッドは、特にユーザーがあるデバイス上でデータを保存しており、別のデバイス上で初めてゲームプレイを再開する場合に、実行時間が長くなる可能性があります。 `GetForUserAsync` は、ユーザーの接続ストレージ領域を取得します。これを使って、コンテナーの作成、アクセス、削除を実行できます。

コンテナーを作成したり、以前に作成したコンテナーにアクセスするには、`ConnectedStorageSpace` または `GameSaveProvider` クラスの `CreateContainer` 関数を呼び出します。これにより、コンテナーの作成に使用された `ConnectedStorageSpace` または `GameSaveProvider` に関連付けられているユーザーまたはコンピューターの名前付きコンテナーにアクセスできるようになります。 `ConnectedStorageSpace` クラスと `GameSaveProvider` クラスには、`DeleteContainerAsync` 関数も含まれています。この関数を使うと、削除するコンテナーの名前を指定すればコンテナーを削除できます。

コンテナー内の BLOB を更新するには、XDK の `ConnectedStorageContainer` クラスまたは UWP API の `GameSaveContainer` クラスで `SubmitUpdatesAsync` を呼び出します。 `SubmitUpdatesAsync` を使うと、BLOB に書き込むデータとしての名前とバッファーのリスト、削除する BLOB 名のリスト、呼び出し元セーブ コンテナーの表示名を指定できます。 これは、接続ストレージ領域でデータを更新するために最終的に呼び出す必要のある関数です。

接続ストレージ API の使用例については、接続ストレージに関する記事 ([データの保存](connected-storage-saving.md)
[データの読み込み](connected-storage-loading.md)
[データの削除](connected-storage-deleting.md)) をご覧ください。

> [!NOTE]
> セキュリティ メモ:
>
> PC で実行されているユニバーサル Windows プラットフォーム (UWP) アプリは、ローカル ユーザーがアクセスでき、本質的にユーザーによる改ざんから保護されていない場所にローカル データを保存します。
>ゲーム外でユーザーによってセーブ データが変更されないためには、ゲームのセーブ データに独自の暗号化や妥当性検査を適用することを考慮する必要があります。
>これと同じ理由から、ゲームの PC および Xbox バージョンによるセーブ データの共有を許可するか、別個のままにしておくかを決定してください。

## <a name="managing-local-storage"></a>ローカル ストレージの管理

Xbox 開発キットや UWP アプリで接続ストレージをテストするときは、開発デバイスのローカルに保存されたデータの操作が必要になることがあります。

xbstorage ツールには XDK が付属しています。これは、開発機本体でローカル ストレージを操作できるコマンド ライン ツールです。
UWP 開発者向けには、gamesaveutil.exe という PC 用の同じツールが Windows 10 SDK for Fall Creators Update(10.0.16299.91) 以降に用意されています。

どちらのツールでも、以下のコマンドを使ってデバイス上のローカル ストレージを操作できます。

|コマンド  |説明  |
|---------|---------|
|reset    | 接続ストレージを工場出荷時の状態にリセットします。 |
|import   | 指定された XML ファイルから接続ストレージ領域にデータをインポートします。 |
|export   | 接続ストレージ領域から指定された XML ファイルにデータをエクスポートします。 |
|delete   | 接続ストレージ領域からデータを削除します。 |
|generate | ダミー データを生成し、指定された XML ファイルに保存します。 |
|simulate | ストレージの領域不足状態をシミュレートします。 |

xbstorage ツールと gamesaveutils.exe で使用できる関数について詳しくは、「[ローカル接続ストレージの管理](connected-storage-xb-storage.md)」をご覧ください。

## <a name="technical-overview"></a>技術概要

XDK での接続ストレージのしくみについて詳しく調べるには、「[接続ストレージの技術的な概要](connected-storage-technical-overview.md)」をご覧ください。 技術概要は、XDK 開発者向けに執筆されましたが、含まれている概念は接続ストレージ全般に当てはまります。