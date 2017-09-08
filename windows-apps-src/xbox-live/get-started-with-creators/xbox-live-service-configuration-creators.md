---
title: "Xbox Live クリエーターズ サービス構成"
author: KevinAsgari
description: "クリエーターズ プログラムの Xbox Live サービス構成について説明します。"
ms.assetid: 22b8f893-abb3-426e-9840-f79de0753702
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: 5cb146f3cd316a88a66bcc3057e30d11baa3aab1
ms.sourcegitcommit: a7a1b41c7dce6d56250ce3113137391d65d9e401
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/11/2017
---
# <a name="xbox-live-service-configuration-for-the-creators-program"></a>クリエーターズ プログラムの Xbox Live サービス構成

## <a name="what-is-service-configuration"></a>サービス構成とは

[実績](../achievements-2017/achievements.md)、[ランキング](../leaderboards-and-stats-2017/leaderboards.md)、[マッチメイキング](../multiplayer/multiplayer-concepts.md#SmartMatch)などのいくつかの Xbox Live 機能についてよくご存じかもしれません。

ご存じでない場合のために、例としてランキングについて簡単に説明します。  ランキングを使用すると、プレイヤーは実績を表す値を確認し、他のプレイヤーと比較できます。  たとえば、アーケード ゲームのハイスコアやレーシング ゲームのラップ タイム、一人称視点のシューティング ゲームのヘッドショットなどです。  ただし、アーケード マシンでは特定のマシンでプレイしたプレイヤーのトップ スコアのみが示されますが、Xbox Live では、世界中からのハイスコアを表示することができます。

また、これを実現するためには、Xbox Live でランキングを認識できるよう、一度限りの構成を実行する必要があります。  たとえば、値を昇順で並び替えるか、降順で並び替えるか、データのどの部分を並び替えるかなどを構成します。

この構成は、Xbox Live クリエーターズ プログラム用の[デベロッパー センター](http://dev.windows.com)で行われます。セットアップ方法については、「[Xbox Live の概要](get-started-with-xbox-live-creators.md)」をご覧ください。

## <a name="get-your-ids"></a>ID を取得する

Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。 これらの ID は、Xbox Live サービスの構成を行うことによって取得できます。

デベロッパー センターに現在タイトルがない場合は、ガイダンスについて、「[新しいクリエーターズ タイトルを作成し、テストする](create-and-test-a-new-creators-title.md)」をご覧ください。

### <a name="critical-ids"></a>重要な ID

Xbox One 用のタイトルおよびアプリケーションの開発には、サンドボックス ID、タイトル ID、およびサービス構成 ID (SCID) という 3 つの ID が重要です。

サンドボックス ID は開発キットを使用するために必要です。タイトル ID と SCID は初期開発には必要ありませんが、Xbox Live サービスを利用する場合に必要となります。 したがって、3 つの ID すべてを一度に取得することをお勧めします。

#### <a name="sandbox-ids"></a>サンドボックス ID

サンドボックスは、開発中に開発キットのコンテンツを分離し、クリーンな環境でタイトルを開発およびテストできるようにします。 サンドボックス ID はサンドボックスを識別します。 本体は、一度に 1 つのサンドボックスにのみアクセスできます。ただし、1 つのサンドボックスには複数の本体からアクセスできます。

サンド ボックス ID は大文字と小文字を区別します。

サンドボックス ID は、以下に示す ”Xbox Live” のルート構成ページで取得できます。

![](../images/getting_started/devcenter_sandbox_id.png)

#### <a name="service-configuration-id-scid"></a>サービス構成 ID (SCID)

開発の過程では、イベント、実績、他のオンライン機能のホストを作成します。 これらはすべてサービス構成の一部であり、アクセスするには SCID が必要です。 1 つのタイトルに複数のサービス構成が存在する場合があり、構成ごとに独自の SCID が割り当てられます。

SCID は大文字と小文字を区別します。

デベロッパー センターで SCID を取得するには、[Xbox Live サービス] セクション、*[Xbox Live Setup]* (Xbox Live のセットアップ) の順に移動します。  以下に示すテーブルに SCID が表示されます。

![](../images/getting_started/devcenter_scid.png)

#### <a name="titleid"></a>タイトル ID

タイトル ID は Xbox Live サービスに対してタイトルを一意に識別するためのものです。 タイトル ID は、タイトルの Live コンテンツ、ユーザー統計情報、実績などにユーザーがアクセスするために、また、Live のマルチプレイヤー機能を有効にするためにサービス全体を通して使用されます。

タイトル ID は、使用される方法および場所によって、大文字と小文字が区別されることがあります。

デベロッパー センターでタイトル ID を確認するには、*[Xbox Live Setup]* (Xbox Live のセットアップ) ページの SCID と同じテーブルを参照してください。
