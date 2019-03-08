---
title: Xbox Live サービス構成
description: Xbox Live サービスをゲーム向けに構成する方法について説明します。
ms.assetid: 631c415b-5366-4a84-ba4f-4f513b229c32
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, サービス構成
ms.localizationpriority: medium
ms.openlocfilehash: d12c66e61a189c13ddbcd96dd99caa351206ecf6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640907"
---
# <a name="xbox-live-service-configuration"></a>Xbox Live サービス構成

## <a name="what-is-service-configuration"></a>サービス構成とは

[実績](achievements-2017/achievements.md)、[ランキング](leaderboards-and-stats-2017/leaderboards.md)、[マッチメイキング](multiplayer/multiplayer-concepts.md#smartmatch-matchmaking)などのいくつかの Xbox Live 機能についてよくご存じかもしれません。

ご存じでない場合のために、例としてランキングについて簡単に説明します。 ランキングを使用すると、プレイヤーは実績を表す値を確認し、他のプレイヤーと比較できます。  たとえば、アーケード ゲームのハイスコアやレーシング ゲームのラップ タイム、一人称視点のシューティング ゲームのヘッドショットなどです。 ただし、アーケード マシンでは特定のマシンでプレイしたプレイヤーのトップ スコアのみが示されますが、Xbox Live では、世界中からのハイスコアを表示することができます。

また、これを実現するためには、Xbox Live でランキングを認識できるよう、一度限りの構成を実行する必要があります。 たとえば、値を昇順で並び替えるか、降順で並び替えるか、データのどの部分を並び替えるかなどを構成します。

この構成では、[パートナー センター](https://partner.microsoft.com/dashboard)ほとんどの時間。 しかし、[Xbox 開発者ポータル (XDP)](https://xdp.xboxlive.com) を使用する開発者もいます。

使用して、Xbox Live クリエーターズ プログラムの一部として、タイトルを開発する場合は、[パートナー センター](https://partner.microsoft.com/dashboard)、」を参照して[作業開始の Xbox Live](get-started-with-creators/get-started-with-xbox-live-creators.md)を設定する方法について説明します。

ID@Xbox の開発者である場合、または Microsoft パートナーのパブリッシャーと共同で作業を行っている場合は、続きをお読みください。

## <a name="choose-your-development-portal"></a>開発ポータルを選択する

前述のとおり、Xbox Live サービスの構成には、異なる 2 つのポータルを使用できます。 パートナー センターで[ https://partner.microsoft.com/dashboard ](https://partner.microsoft.com/dashboard)と Xbox 開発ポータル (XDP) に[ https://xdp.xboxlive.com](https://xdp.xboxlive.com)します。

パートナー センターは今後、すべてのタイトルをお勧めします。 特定の機能が場合でも、XDP を使用します。 このセクションでは、どこでタイトルを構成したらよいかを説明します。

選択したポータルに応じて、特定のサービスの構成ページについての情報を確認できます。

* [パートナー センターの構成](configure-xbl/windows-dev-center.md)
* [Xbox 開発ポータル構成](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-service-configuration)- このリンクにアクセスする Microsoft アカウント (MSA) Xbox Live のフル アクセスが有効になっている必要があります。

既にタイトルを構成済みの場合は、「[ID を取得する](#get_ids)」まで下にスクロールして、タイトルの設定に必要なさまざまな ID を取得する方法をご覧いただけます。

### <a name="pcmobile-uwp-game-only"></a>PC/Mobile UWP ゲーム専用
パートナー センターの構成と管理の UWP ゲームでは、Windows 10 Pc および Windows 10 mobile デバイスのみを実行しているお勧めします。

#### <a name="using-xdp-to-configure-uwp-titles"></a>XDP の使用による UWP タイトルの構成

次のいずれかの要件がある場合は、UWP タイトルの構成に XDP を使用することもできます。

1. アリーナを使用している。
2. XDP に、引き続き使用したい既存のユーザー、グループ、アクセス許可の設定がある。
3. Tournaments Tool や マルチプレイヤー セッション ディレクトリ セッション履歴ビューアーなど、XDP でのみ動作するツールを使用している。
4. Xbox One XDK ベースのゲームと、同じゲームの UWP PC/モバイル バージョンとの間のクロスプラットフォーム プレイ機能を持つタイトルを開発している。

これらのカテゴリのいずれかに該当するされない場合は、パートナー センターを使用する必要があります。 いずれかが該当する場合は、以下に示す XDP を使用して UWP タイトルを構成する方法をご覧ください。

XDP を使用した UWP アプリケーション用の Xbox Live サービスの構成に関して、いくつかの重要な注意事項があります。

* **ゲームの Xbox Live サービスの構成が XDP で製品版の証明書に公開されるがありません戻ります。** そのゲームの Xbox Live サービス構成は、ゲーム タイトルの寿命が終わるまで XDP にとどまる必要があります。
* **XDP からパートナー センターへの移行パスはありません。** XDP で、Xbox Live の構成を開始した場合必要があります手動で再作成する、パートナー センターで移動する場合。

これら 2 つの考慮事項をお勧め PC/モバイル ゲームでは、パートナー センターを使用して上記のカテゴリのいずれかに該当する場合を除き、します。

### <a name="cross-play-between-xbox-one-and-pcmobile-games"></a>Xbox One ゲームと PC/モバイル ゲーム間のクロスプレイ ###
クロスプレイと呼ばれる、Xbox One および PC 間のクロスデバイス ゲーミングは、注目に値する Windows 10 エクスペリエンスです。 このシナリオでは、ゲームの Xbox One バージョンと PC バージョンの両方が同じ Xbox Live 構成を共有します。

このシナリオは、既存の Xbox One XDK ゲームがあり、ゲームの UWP バージョンのためにクロスプレイ サポートを追加したいケースにも対応します。

クロスプレイを実装するには、次の手順に従います。

* **XDP を使用すると、構成して XDK ゲームを公開します。** パートナー センターは、この時点でゲームを Xbox One XDK をサポートしていません。
* **1 つ Xbox Live サービスの構成、XDK とゲームの UWP バージョンの両方の XDP で作成したを使用します。** XDP の新しい機能により、ゲームの XDK バージョンと UWP バージョンで単一の Xbox Live サービス構成を共有できます。
* **取り込んで、UWP ゲームを公開するには、パートナー センターを使用します。** ただし、ゲームが XDP で作成したサービスの構成を使用するためには、Xbox Live サービスを構成するのにパートナー センターを使用しないでください。
* **XDP とパートナー センターの間のサービス構成の Xbox Live は分割されません。** XDP とパートナー センターは、互いを認識しませんし、その他のソースからパブリッシュされた構成を上書きする 1 つのソースからのサービス構成を発行します。 これが原因でユーザー データが失われ (実績の達成状況が失われる、ゲームのセーブ データが消去されるなど)、ユーザー エクスペリエンスが損なわれる可能性があります。 この理由から、**クロスプレイ対応の XDK + UWP ゲームについては、Xbox Live サービス構成の 100% が XDP で行われることを要件とします。**

セルフサービスでは*ない*アイテムなど、このプロセスの詳細については「[クロスプレイ ゲームの概要](get-started-with-partner/get-started-with-cross-play-games.md)」ガイドを参照してください。

### <a name="separate-versions-of-xbox-one-and-pcmobile-games-that-are-not-cross-play"></a>クロスプレイに対応しない Xbox One ゲームと PC/モバイル ゲームのバージョンを分ける
ゲームの Xbox One バージョンを、同じゲームの PC/モバイル バージョンとは分けたままにしておくこともできます。 この場合、2 つの独立したプロダクトを作成し、Xbox One XDK 専用のガイダンスと PC/モバイル UWP ゲーム専用のガイダンスにそれぞれ従います。

両方のバージョンの同じサービスの構成をここでは、使用することはできませんしする必要があります手動で作成する各ゲームの別のバージョンのサービス構成 XDP またはパートナー センターで適切にします。

<a name="get_ids"></a>

## <a name="get-your-ids"></a>ID を取得する

Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。 これらの ID は、Xbox Live サービスの構成を行うことによって取得できます。

XDP またはパートナー センターでのタイトルがいない場合は、前のセクションを参照してください。 [Xbox Live サービスの構成ポータル](#xbox_live_portals)のガイダンスについてはします。

### <a name="critical-ids"></a>重要な ID

Xbox One 用のタイトルおよびアプリケーションの開発には、サンドボックス ID、タイトル ID、および SCID という 3 つの ID が重要です。

サンドボックス ID は開発キットを使用するために必要です。タイトル ID と SCID は初期開発には必要ありませんが、Xbox Live サービスを利用する場合に必要となります。 したがって、3 つの ID すべてを一度に取得することをお勧めします。

#### <a name="sandbox-ids"></a>サンドボックス ID

サンドボックスは、開発中に開発キットのコンテンツを分離し、クリーンな環境でタイトルを開発およびテストできるようにします。 サンドボックス ID はサンドボックスを識別します。 本体は、一度に 1 つのサンドボックスにのみアクセスできます。ただし、1 つのサンドボックスには複数の本体からアクセスできます。

サンド ボックス ID は大文字と小文字を区別します。

**パートナー センター**

パートナー センターで、タイトルを構成する場合は、"Xbox Live"ルート構成 ページで次のようにサンド ボックス ID を取得します。

![](images/getting_started/devcenter_sandbox_id.png)

**XDP**

XDP にタイトルを構成する場合、[概要] ページ、製品を次に示すように、サンド ボックス ID を取得します。

![](images/getting_started/xdp_sandbox_id.png)

#### <a name="service-configuration-id-scid"></a>サービス構成 ID (SCID)

開発の過程では、イベント、実績、他のオンライン機能のホストを作成します。 これらはすべてサービス構成の一部であり、アクセスするには SCID が必要です。

SCID は大文字と小文字を区別します。

**パートナー センター**

パートナー センターで、SCID を取得するには、Xbox Live サービス セクションに移動しに移動*Xbox Live セットアップ*します。 以下に示すテーブルに SCID が表示されます。

![](images/getting_started/devcenter_scid.png)

**XDP**

XDP で SCID を取得するには、タイトルの下にある [Product Setup] に移動します。タイトル ID と SCID の両方が表示されます。

![](images/getting_started/xdp_scid.png)

#### <a name="title-id"></a>タイトル ID

タイトル ID は Xbox Live サービスに対してタイトルを一意に識別するためのものです。 タイトル ID は、タイトルの Live コンテンツ、ユーザー統計情報、実績などにユーザーがアクセスするために、また、Live のマルチプレイヤー機能を有効にするためにサービス全体を通して使用されます。

タイトル ID は、使用される方法および場所によって、大文字と小文字が区別されることがあります。

**パートナー センター**

パートナー センターで、タイトルの ID がで SCID と同じテーブルで見つかった、 *Xbox Live セットアップ*ページ。

**XDP**

XDP のタイトル ID は、SCID と同じ場所から取得されます。

<a name="xbox_live_portals"></a>
