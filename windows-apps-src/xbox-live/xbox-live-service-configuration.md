---
title: Xbox Live サービス構成
author: KevinAsgari
description: Xbox Live サービスをゲーム向けに構成する方法について説明します。
ms.assetid: 631c415b-5366-4a84-ba4f-4f513b229c32
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, サービス構成
ms.localizationpriority: medium
ms.openlocfilehash: e1d3b21f98528afec5e97cac6f645c7835b6362a
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5157041"
---
# <a name="xbox-live-service-configuration"></a>Xbox Live サービス構成

## <a name="what-is-service-configuration"></a>サービス構成とは

[実績](achievements-2017/achievements.md)、[ランキング](leaderboards-and-stats-2017/leaderboards.md)、[マッチメイキング](multiplayer/multiplayer-concepts.md#smartmatch-matchmaking)などのいくつかの Xbox Live 機能についてよくご存じかもしれません。

ご存じでない場合のために、例としてランキングについて簡単に説明します。 ランキングを使用すると、プレイヤーは実績を表す値を確認し、他のプレイヤーと比較できます。  たとえば、アーケード ゲームのハイスコアやレーシング ゲームのラップ タイム、一人称視点のシューティング ゲームのヘッドショットなどです。 ただし、アーケード マシンでは特定のマシンでプレイしたプレイヤーのトップ スコアのみが示されますが、Xbox Live では、世界中からのハイスコアを表示することができます。

また、これを実現するためには、Xbox Live でランキングを認識できるよう、一度限りの構成を実行する必要があります。 たとえば、値を昇順で並び替えるか、降順で並び替えるか、データのどの部分を並び替えるかなどを構成します。

多くの場合、この構成は[デベロッパー センター](http://dev.windows.com)で行われます。 しかし、[Xbox 開発者ポータル (XDP)](http://xdp.xboxlive.com) を使用する開発者もいます。

Xbox Live クリエーターズ プログラムの一部としてタイトルを開発している場合は、[デベロッパー センター](http://dev.windows.com)をご利用ください。「[Xbox Live の概要](get-started-with-creators/get-started-with-xbox-live-creators.md)」にその設定方法が説明されています。

ID@Xbox の開発者である場合、または Microsoft パートナーのパブリッシャーと共同で作業を行っている場合は、続きをお読みください。

## <a name="choose-your-development-portal"></a>開発ポータルを選択する

前述のとおり、Xbox Live サービスの構成には、異なる 2 つのポータルを使用できます。 [http://dev.windows.com](http://dev.windows.com) の Windows デベロッパー センター [http://xdp.xboxlive.com](http://xdp.xboxlive.com) の Xbox デベロッパー ポータル (XDP)。

今後のすべてのタイトルでは Windows デベロッパー センターが推奨されますが、機能によっては引き続き XDP を使用することもできます。 このセクションでは、どこでタイトルを構成したらよいかを説明します。

特定のサービス構成ページの情報を確認するには、選択したポータルに応じて。

* [Windows デベロッパー センターの構成](configure-xbl/windows-dev-center.md)
* [Xbox デベロッパー ポータルの構成](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-service-configuration)- このリンクにアクセスすると、Microsoft アカウント (MSA) Xbox Live のフル アクセスが有効になっている必要があります。

既にタイトルを構成済みの場合は、「[ID を取得する](#get_ids)」まで下にスクロールして、タイトルの設定に必要なさまざまな ID を取得する方法をご覧いただけます。

### <a name="pcmobile-uwp-game-only"></a>PC/Mobile UWP ゲーム専用
Windows 10 PC と Windows 10 モバイル デバイスの一方または両方でのみ動作する UWP ゲームを構成および管理する場合は、Windows デベロッパー センターをお勧めします。

#### <a name="using-xdp-to-configure-uwp-titles"></a>XDP の使用による UWP タイトルの構成

次のいずれかの要件がある場合は、UWP タイトルの構成に XDP を使用することもできます。

1. アリーナを使用している。
2. XDP に、引き続き使用したい既存のユーザー、グループ、アクセス許可の設定がある。
3. Tournaments Tool や マルチプレイヤー セッション ディレクトリ セッション履歴ビューアーなど、XDP でのみ動作するツールを使用している。
4. Xbox One XDK ベースのゲームと、同じゲームの UWP PC/モバイル バージョンとの間のクロスプラットフォーム プレイ機能を持つタイトルを開発している。

これらのカテゴリのいずれも該当しない場合は、Windows デベロッパー センターを使用してください。 いずれかが該当する場合は、以下に示す XDP を使用して UWP タイトルを構成する方法をご覧ください。

XDP を使用した UWP アプリケーション用の Xbox Live サービスの構成に関して、いくつかの重要な注意事項があります。

* **ゲームの Xbox Live サービス構成をいったん XDP で CERT/RETAIL に公開すると、後戻りできません!** そのゲームの Xbox Live サービス構成は、ゲーム タイトルの寿命が終わるまで XDP にとどまる必要があります。
* **XDP から Windows デベロッパー センターへの移行パスはありません。** Xbox Live 構成を XDP で開始する場合、構成を移動したい場合は Windows デベロッパー センターで構成を手動で作成し直す必要があります。

これら 2 点の考慮事項により、PC/モバイル ゲームでは Windows デベロッパー センターを使用することをお勧めします。ただし、上記カテゴリのいずれかに該当する場合は除きます。

### <a name="cross-play-between-xbox-one-and-pcmobile-games"></a>Xbox One ゲームと PC/モバイル ゲーム間のクロスプレイ ###
クロスプレイと呼ばれる、Xbox One および PC 間のクロスデバイス ゲーミングは、注目に値する Windows 10 エクスペリエンスです。 このシナリオでは、ゲームの Xbox One バージョンと PC バージョンの両方が同じ Xbox Live 構成を共有します。

このシナリオは、既存の Xbox One XDK ゲームがあり、ゲームの UWP バージョンのためにクロスプレイ サポートを追加したいケースにも対応します。

クロスプレイを実装するには、次の手順に従います。

* **XDP を使用して XDK ゲームを構成し、公開します。** Windows デベロッパー センターは現時点で Xbox One XDK ゲームをサポートしていません。
* **XDP で作成した単一の Xbox Live サービス構成を、ゲームの XDK バージョンと UWP バージョンの両方に使用します。** XDP の新しい機能により、ゲームの XDK バージョンと UWP バージョンで単一の Xbox Live サービス構成を共有できます。
* **Windows デベロッパー センターを使用して UWP ゲームを取り込み、公開します。** ただし、ゲームで使用するのは XDP で作成したサービス構成なので、Windows デベロッパー センターを使用して Xbox Live サービスを構成しないでください。
* **Xbox Live サービス構成を XDP と Windows デベロッパー センターに分割しないでください。** XDP と Windows デベロッパー センターは互いを認識せず、一方のソースからサービス構成を公開すると、もう一方のソースから公開された構成が上書きされます。 これが原因でユーザー データが失われ (実績の達成状況が失われる、ゲームのセーブ データが消去されるなど)、ユーザー エクスペリエンスが損なわれる可能性があります。 この理由から、**クロスプレイ対応の XDK + UWP ゲームについては、Xbox Live サービス構成の 100% が XDP で行われることを要件とします。**

セルフサービスでは*ない*アイテムなど、このプロセスの詳細については「[クロスプレイ ゲームの概要](get-started-with-partner/get-started-with-cross-play-games.md)」ガイドを参照してください。

### <a name="separate-versions-of-xbox-one-and-pcmobile-games-that-are-not-cross-play"></a>クロスプレイに対応しない Xbox One ゲームと PC/モバイル ゲームのバージョンを分ける
ゲームの Xbox One バージョンを、同じゲームの PC/モバイル バージョンとは分けたままにしておくこともできます。 この場合、2 つの独立したプロダクトを作成し、Xbox One XDK 専用のガイダンスと PC/モバイル UWP ゲーム専用のガイダンスにそれぞれ従います。

この場合、両方のバージョンで同じサービス構成を使用することはできず、XDP または Windows デベロッパー センターのどちらか適切なほうで、ゲームの独立したバージョンごとにサービス構成を手動で作成する必要があります。

<a name="get_ids"></a>

## <a name="get-your-ids"></a>ID を取得する

Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。 これらの ID は、Xbox Live サービスの構成を行うことによって取得できます。

XDP またはデベロッパー センターにタイトルが現在ない場合、ガイダンスについて上記のセクション「[Xbox Live サービス構成ポータル](#xbox_live_portals)」を参照してください。

### <a name="critical-ids"></a>重要な ID

Xbox One 用のタイトルおよびアプリケーションの開発には、サンドボックス ID、タイトル ID、および SCID という 3 つの ID が重要です。

サンドボックス ID は開発キットを使用するために必要です。タイトル ID と SCID は初期開発には必要ありませんが、Xbox Live サービスを利用する場合に必要となります。 したがって、3 つの ID すべてを一度に取得することをお勧めします。

#### <a name="sandbox-ids"></a>サンドボックス ID

サンドボックスは、開発中に開発キットのコンテンツを分離し、クリーンな環境でタイトルを開発およびテストできるようにします。 サンドボックス ID はサンドボックスを識別します。 本体は、一度に 1 つのサンドボックスにのみアクセスできます。ただし、1 つのサンドボックスには複数の本体からアクセスできます。

サンド ボックス ID は大文字と小文字を区別します。

**デベロッパー センター**

デベロッパー センターでタイトルを構成する場合、以下に示す [Xbox Live] ルート構成ページでサンドボックス ID を取得します。

![](images/getting_started/devcenter_sandbox_id.png)

**XDP**

XDP でタイトルを構成する場合、概要ページで次に示すように、製品のサンド ボックス ID を取得します。

![](images/getting_started/xdp_sandbox_id.png)

#### <a name="service-configuration-id-scid"></a>サービス構成 ID (SCID)

開発の過程では、イベント、実績、他のオンライン機能のホストを作成します。 これらはすべてサービス構成の一部であり、アクセスするには SCID が必要です。

SCID は大文字と小文字を区別します。

**デベロッパー センター**

デベロッパー センターで SCID を取得するには、[Xbox Live サービス] セクション、*[Xbox Live Setup]* (Xbox Live のセットアップ) の順に移動します。 以下に示すテーブルに SCID が表示されます。

![](images/getting_started/devcenter_scid.png)

**XDP**

XDP で SCID を取得するには、タイトルの下にある [Product Setup] に移動します。タイトル ID と SCID の両方が表示されます。

![](images/getting_started/xdp_scid.png)

#### <a name="title-id"></a>タイトル ID

タイトル ID は Xbox Live サービスに対してタイトルを一意に識別するためのものです。 タイトル ID は、タイトルの Live コンテンツ、ユーザー統計情報、実績などにユーザーがアクセスするために、また、Live のマルチプレイヤー機能を有効にするためにサービス全体を通して使用されます。

タイトル ID は、使用される方法および場所によって、大文字と小文字が区別されることがあります。

**デベロッパー センター**

デベロッパー センターでタイトル ID を確認するには、*[Xbox Live Setup]* (Xbox Live のセットアップ) ページの SCID と同じテーブルを参照してください。

**XDP**

XDP のタイトル ID は、SCID と同じ場所から取得されます。

<a name="xbox_live_portals"></a>
