---
title: Xbox Live クリエーターズ サービス構成
description: クリエーターズ プログラムの Xbox Live サービス構成について説明します。
ms.assetid: 22b8f893-abb3-426e-9840-f79de0753702
ms.date: 10/03/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 76d25a48caadb908e30e6e1897c19178e2b837e1
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8738540"
---
# <a name="xbox-live-service-configuration-for-the-creators-program"></a>クリエーターズ プログラムの Xbox Live サービス構成

## <a name="what-is-service-configuration"></a>サービス構成とは

[ランキング](../leaderboards-and-stats-2017/leaderboards.md)や[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)などのいくつかの Xbox Live 機能についてよくご存じかもしれません。

ご存じでない場合のために、例としてランキングについて簡単に説明します。 ランキングを使用すると、プレイヤーは実績を表す値を確認し、他のプレイヤーと比較できます。 たとえば、アーケード ゲームのハイスコアやレーシング ゲームのラップ タイム、一人称視点のシューティング ゲームのヘッドショットなどです。 ただし、アーケード マシンでは特定のマシンでプレイしたプレイヤーのトップ スコアのみが示されますが、Xbox Live では、世界中からのハイスコアを表示することができます。

また、これを実現するためには、Xbox Live でランキングを認識できるよう、一度限りの構成を実行する必要があります。 たとえば、値を昇順で並び替えるか、降順で並び替えるか、データのどの部分を並び替えるかなどを構成します。

この構成は Xbox Live クリエーターズ プログラムの[パートナー センター](https://partner.microsoft.com/dashboard)で発生し、 [Xbox Live の概要](get-started-with-xbox-live-creators.md)をセットアップする方法についてを読み取ることができます。

## <a name="get-your-ids"></a>ID を取得する

Xbox Live サービスを有効にするには、開発環境とタイトルを構成するためのいくつかの ID を取得する必要があります。 これらの ID は、Xbox Live サービスの構成を更新することによって取得できます。

パートナー センターでタイトルがいない場合、ガイダンスを[作成およびテスト新しいクリエーターズ タイトル](create-and-test-a-new-creators-title.md)をご覧ください。

### <a name="critical-ids"></a>重要な ID

Xbox One 用のタイトルおよびアプリケーションの開発には、サンドボックス ID、タイトル ID、およびサービス構成 ID (SCID) という 3 つの ID が重要です。

サンドボックス ID は開発環境をセットアップするために必要です。タイトル ID と SCID は初期開発には必要ありませんが、Xbox Live サービスを利用する場合に必要となります。 したがって、3 つの ID すべてを一度に取得することをお勧めします。 すべての ID は、以下に示す ”Xbox Live” のルート構成ページで取得できます。

![](../images/getting_started/devcenter_sandbox_id.png)

#### <a name="sandbox-ids"></a>サンドボックス ID

サンドボックスは、開発中に環境のコンテンツを分離し、クリーンにタイトルを開発およびテストできるようにします。 サンドボックス ID はサンドボックスを識別します。 本体は、一度に 1 つのサンドボックスにのみアクセスできます。ただし、1 つのサンドボックスには複数の本体からアクセスできます。

サンド ボックス ID は大文字と小文字を区別します。

#### <a name="service-configuration-id-scid"></a>サービス構成 ID (SCID)

開発の過程では、統計、ランキング、他のオンライン機能のホストを作成します。 これらはすべてサービス構成の一部であり、アクセスするには SCID が必要です。 SCID は大文字と小文字を区別します。

#### <a name="title-id"></a>タイトル ID

タイトル ID は Xbox Live サービスに対してタイトルを一意に識別するためのものです。 タイトル ID は、タイトルの Live コンテンツ、ユーザー統計情報、実績などにユーザーがアクセスするために、また、Live のマルチプレイヤー機能を有効にするためにサービス全体を通して使用されます。

タイトル ID は、使用される方法および場所によって、大文字と小文字が区別されることがあります。

## <a name="publish-your-xbox-live-service-configuration"></a>Xbox Live サービス構成を公開する

ゲーム用の Xbox Live 構成に変更を加える場合、それらの変更を Xbox Live の残りの部分が取得してゲームに表示されるには、変更を公開する必要があります。 ゲームに対する作業を継続している間は、独自の開発サンドボックスに公開します。 開発サンドボックスでは、分離された環境でゲームへの変更に取り組むことができます。 ゲームを一般向けにリリースすると、Xbox Live 構成は自動的に RETAIL サンドボックスに公開されます。
既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。

現在の Xbox Live 構成を開発サンドボックスに公開するには、Xbox Live 構成ページで **[テスト]** ボタンをクリックします。

![](../images/creators_udc/creators_udc_xboxlive_config_test.png)