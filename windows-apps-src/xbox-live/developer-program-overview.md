---
title: 開発者プログラムの概要
author: KevinAsgari
description: Xbox Live を使うために利用できる、さまざまな開発者プログラムについて説明します。
ms.assetid: 1166308a-4079-41b4-8550-ce04b82b4f72
ms.author: kevinasg
ms.date: 5/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 開発者プログラム, クリエーター
ms.localizationpriority: medium
ms.openlocfilehash: 4bbfcb38704512b3dbd709eb827768d073ad4c95
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4567340"
---
# <a name="developer-program-overview"></a>開発者プログラムの概要

Xbox Live 対応のタイトルを開発する場合、いくつかのオプションを利用可能です。 それぞれで、開発者に対する異なるレベルの時間投資、利用可能な機能、およびサポート オプションが提供されます。

## <a name="xbox-live-creators-program"></a>Xbox Live クリエーターズ プログラム

Xbox Live 開発を理解するには、Xbox Live クリエーターズ プログラムが Xbox Live の良い出発点になります。 このプログラムへの参加には、マイクロソフトによる承認プロセスは必要ありませんが、最小限の認定要件と公開要件があります。

Xbox Live クリエーターズ プログラムは、[ユニバーサル Windows プラットフォーム](https://msdn.microsoft.com/en-us/windows/uwp/get-started/universal-application-platform-guide) (UWP) 向けのタイトルの作成のみをサポートしています。  UWP ゲームとして作成されたタイトルは Windows 10 PC と Xbox One 本体で動作します。  Xbox One での UWP ゲームの実行の詳細については、「[Xbox One の UWP](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/index)」を参照してください。  

Xbox One では、ゲーマーに選りすぐりのストア エクスペリエンスが提供されます。Xbox Live クリエーターズ プログラムを通じて公開されたゲームは、Xbox の Microsoft Store の新しい [作成者のコレクション] セクションで販売されます。 これにより、だれでもゲームを開発し出荷できるオープンなプラットフォームの確保と、コンソール ゲーマーが知っていて期待する選りすぐりのストア エクスペリエンスとが両立します。 Windows 10 では、タイトルは Microsoft Store で他のすべての Xbox Live ゲームと一緒に公開されます。

### <a name="publishing-and-certification"></a>公開と認定
Xbox Live クリエーターズ プログラムの一部としてゲームをリリースするには、[デベロッパー センターの開発者プログラム](https://developer.microsoft.com/store/register)に登録されている必要があります。 ゲームが従う必要がある要件が 2 つあります。

1. Xbox Live のサインインを統合し、ユーザー ID (ゲーマータグ、ゲーマー アイコンなど) を表示します。 他のすべての Xbox Live サービスはオプションです。
2. 標準の [Microsoft Store ポリシー](https://msdn.microsoft.com/en-us/library/windows/apps/dn764944.aspx)に従います。

### <a name="supported-xbox-live-services"></a>サポートされる Xbox Live サービス
Xbox Live クリエーターズ プログラム対応のタイトルでは、ランキング、注目の統計、タイトル ストレージ、接続ストレージ、および制限されたソーシャル機能を使用できます。 実績、オンライン マルチプレイヤー、および多くのソーシャル機能は、Xbox Live クリエーターズ プログラムのタイトルではサポートされ**ません**。

サポートされるサービスの一覧については、[機能テーブル](#feature-table)をご覧ください。

### <a name="supported-third-party-game-development-engines"></a>サポートされているサード パーティ製ゲーム開発エンジン
Xbox Live クリエーターズ プログラム タイトルは、さまざまな人気のゲーム エンジンでビルドできる UWP ゲームです。 Microsoft では、[Unity ゲーム エンジン](https://unity.com)でビルドされた UWP ゲームに Xbox Live シリーズを統合するためのドキュメントを用意しています。 Xbox Live と Unity ゲームの統合に関する詳しい[ドキュメント](get-started-with-creators/develop-creators-title-with-unity.md)をこのサイトで確認できるだけでなく、Microsoft が作成した [Xbox Live Unity プラグイン](https://github.com/Microsoft/xbox-live-unity-plugin)をダウンロードして詳しく調べることもできます。

Xbox Live クリエーターズ プログラム タイトルは、ゲーム エンジン [Construct (2 & 3)](https://www.scirra.com/construct2) および [GameMaker Studio 2](https://www.yoyogames.com/gamemaker) を使ってビルドすることもできます。 どちらのゲーム エンジンにも Xbox Live サポートが追加されていますが、そのサポートは Microsoft ではなくゲーム エンジンの作成元によって処理されます。 Construct または GameMaker Studio 2 プロジェクトへの Xbox Live の追加に関する詳細とサポートについては、各ゲーム エンジンのドキュメントをご覧ください。

[Xbox Live を Construct プロジェクトに統合する方法について説明します。](https://www.scirra.com/tutorials/9540/using-xbox-live-in-uwp-apps)

[Xbox Live を GameMaker Studio 2 プロジェクトに統合する方法について説明します。](https://www.yoyogames.com/gamemaker/xblc)

[MonoGame](http://www.monogame.net/) や [Xenko](https://xenko.com/) など、Xbox Live の機能やプラグインが組み込まれていない他のゲーム開発エンジンについては、引き続き Xbox Live API を使って Xbox Live をタイトルに追加できます。 プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使ってバイナリへの参照を追加するか、API ソースを追加します。 NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。

### <a name="support-and-feedback"></a>サポートとフィードバック
[MSDN フォーラム](https://social.msdn.microsoft.com/Forums/en-US/home?forum=xboxlivedev)では、あらゆる質問を行うことができます。  プログラミング関連の質問は、"xbox live" タグを付けて [Stack Overflow](http://stackoverflow.com/questions/tagged/xbox-live) でたずねることもできます。  Xbox Live チームは、コミュニティと連携し、コミュニティに寄せられたフィードバックに基づいて API、ツール、ドキュメントを継続的に改善しています。

Xbox Live クリエーターズ プログラムの開発者は、[Xbox User Voice](https://xbox.uservoice.com/forums/363186--new-ideas) で、[新しいアイデアを提出](https://xbox.uservoice.com/forums/363186--new-ideas?category_id=196261)したり、[既存のアイデアに投票](https://xbox.uservoice.com/forums/251649?category_id=210838)したりすることができます。

## <a name="idxbox"></a>ID@Xbox

Xbox Live クリエーターズ プログラムは、多くのゲームや開発者に適しています。 ただし、オンライン マルチプレイヤー、実績、およびゲーマースコアを含む、フル Xbox Live スタックを利用したい場合、またはハードウェア開発キットを使用して Xbox One ファミリのデバイスのすべての機能を利用したい場合は、[ID@Xbox](http://www.xbox.com/en-US/developers/id) プログラムをお勧めします。

ID@Xbox プログラムでは、ゲームはコンセプトの承認を得て、Xbox One と Windows 10 の完全な認定を受ける必要があり、開発者はこれに多くの時間を費やします。
ID@Xbox タイトルは、ストアの [作成者のコレクション] セクションではなく、主要セクションに配置されるため、ユーザーへの露出が大きくなる可能性があります。

ID@Xbox プログラムの開発者は、マイクロソフトからの開発者サポートとプロモーションの支援を得られるうえ、非公開のホワイト ペーパーと開発者向け技術フォーラムもすべて利用できます。 必要に応じて、引き続き [MSDN フォーラム](https://social.msdn.microsoft.com/Forums/en-US/home?forum=xboxlivedev)を使用することや、[Stack Overflow](http://stackoverflow.com/questions/tagged/xbox-live) で "xbox-live" タグを使用してプログラミング関連の質問をすることができます。

## <a name="microsoft-partners"></a>Microsoft パートナー

Microsoft パートナーであるゲーム パブリッシャーと連携する開発者は、Xbox Live の機能の完全なセットを利用したり、マイクロソフトの専任担当者に問い合わせて、開発、認定、およびリリース プロセスの支援を受けたりすることができます。

## <a name="feature-table"></a>機能テーブル

下の表に、Xbox Live クリエーターズ プログラムで利用できる機能と、[ID@Xbox](http://www.xbox.com/en-US/developers/id) プログラムで利用できる機能を示します。  

<table>

<tr>
<th>機能領域</th>
<th>機能</th>
<th>説明</th>
<th> ID@Xbox </th>
<th>Xbox Live クリエーターズ プログラム</th>
</tr>

<tr>
<td rowspan="2" class="dev-program-feature-name">ID</td>
<td>サインイン/サインアップ</td>
<td>プレイヤーがタイトル内で Xbox Live にサインインすること、および必要に応じて新しい Xbox Live アカウントを作成することを許可します。</td>
<td class="xbl-features-required">必須</td>
<td class="xbl-features-required">必須</td>
</tr>

<tr>
<td>ユーザー ID</td>
<td>ゲーマータグ、ゲーマーアイコンなどを表示して Xbox Live ID を利用します。</td>
<td class="xbl-features-required">必須</td>
<td class="xbl-features-required">必須</td>
</tr>

<tr class="dev-program-feature-start">
<td rowspan="13" class="dev-program-feature-name">ソーシャル</td>

<td>基本的なプレゼンス</td>
<td>タイトル内のユーザーのアクティビティを示す基本的なプレゼンス文字列を表示します。  例: "Steve が Minecraft をプレイ中"</td>
<td class="xbl-features-automatic">自動</td>
<td class="xbl-features-automatic">自動</td>
</tr>

<tr>
<td>最近プレイしたゲーム</td>
<td>Xbox アプリや Xbox One で最近プレイしたタイトルが表示されます。</td>
<td class="xbl-features-automatic">自動</td>
<td class="xbl-features-automatic">自動</td>
</tr>

<tr>
<td>アクティビティ フィード</td>
<td>Xbox アプリや Xbox One でのアクティビティ フィードが表示されます。</td>
<td class="xbl-features-automatic">自動</td>
<td class="xbl-features-automatic">自動</td>
</tr>

<tr>
<td>ゲーム ハブ</td>
<td>ゲーム ハブにタイトルを関連付け、タイトルに固有の統計情報、ビデオ、および他のコンテンツをフィードに表示します。</td>
<td class="xbl-features-automatic">自動</td>
<td class="xbl-features-automatic">自動</td>
</tr>

<tr>
<td>クラブ</td>
<td>プレイヤーは、Xbox アプリまたは Xbox One を使用して、必要に応じてタイトルと関連付けることができるクラブを作成できます。</td>
<td class="xbl-features-automatic">自動</td>
<td class="xbl-features-automatic">自動</td>
</tr>

<tr>
<td>グループを検索 (LFG)</td>
<td>LFG を利用して、プレイヤーはゲーム外の他のプレイヤーを検索してマルチプレイヤー ゲームのスケジュールを設定できます。</td>
<td class="xbl-features-automatic">自動</td>
<td class="xbl-features-automatic">自動</td>
</tr>

<tr>
<td>GameDVR</td>
<td>プレイヤーは、ゲームプレイ セッションのビデオをキャプチャして、プレイ状況フィードでそのビデオを共有できます。</td>
<td class="xbl-features-automatic">自動</td>
<td class="xbl-features-automatic">自動</td>
</tr>

<tr>
<td>配信</td>
<td>プレイヤーは Mixer や Twitch などのストリーミング サービスを介してゲームプレイをライブ配信できます。</td>
<td class="xbl-features-automatic">自動</td>
<td class="xbl-features-automatic">自動</td>
</tr>

<tr>
<td>リッチ プレゼンス</td>
<td>タイトルでプレイヤーに関する詳しい情報を表示します。  基本的なプレゼンスの表示は "ユーザーがカー レーシング ゲームをプレイ中" のようなものですが、リッチ プレゼンスでは "ユーザーが RainyForest で SuperCar を運転中" などのより詳細な文字列を指定できます。</td>
<td class="xbl-features-required">必須</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>

<tr>
<td>フレンド</td>
<td>サインインしているユーザーのフレンド リストを取得して、タイトルでソーシャル ゲームプレイ シナリオを有効にします。</td>
<td class="xbl-features-required">必須</td>
<td class="xbl-features-limited">オプション/制限あり (タイトルをプレイしたことのあるフレンドのみが表示されます)</td>
</tr>

<tr>
<td>プライバシー</td>
<td>プレイヤーが他のプレイヤーをミュートしたり、ブロックしたりできるようにします。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-optional">オプション</td>
</tr>

<tr>
<td>評判</td>
<td>プレイヤーの評判は態度を通じて上がったり、下がったりします。 態度は、マッチメイキングで使用されます。タイトルでは、態度を独自の方法で使用できます。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>

<tr>
<td>Social Manager</td>
<td>プレイヤーのソーシャル グラフに関する情報を効率的に取得します。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-limited">オプション/制限あり (タイトルをプレイしたことのあるフレンドのみが表示されます)</td>
</tr>

<tr class="dev-program-feature-start">
<td rowspan="4" class="dev-program-feature-name">データ プラットフォーム</td>

<td>プレイヤーの統計情報</td>
<td>ランキングで使用できるプレイヤーの統計情報をアップロードします。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-optional">オプション (データ プラットフォーム 2017 のみ)</td>
</tr>

<tr>
<td>注目の統計</td>
<td>ゲーム ハブに表示する特定の統計情報を "注目の統計" として指定します。</td>
<td class="xbl-features-required">必須</td>
<td class="xbl-features-optional">オプション (データ プラットフォーム 2017 のみ)</td>
</tr>

<tr>
<td>ランキング</td>
<td>プレイヤーの統計情報を取得し、並べ替えて表示して、競争を促します。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-optional">オプション (データ プラットフォーム 2017 のみ)</td>
</tr>

<tr>
<td>ゲーマースコアと実績</td>
<td>ゲーム ハブに表示する特定の統計情報を "注目の統計" として指定します。</td>
<td class="xbl-features-required">必須</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>

<tr class="dev-program-feature-start">
<td rowspan="1" class="dev-program-feature-name">メディア</td>

<td>コンテキスト検索</td>
<td>ゲーム録画クリップにキーワードで注釈を付け、プレイヤーが視聴したい内容に該当するクリップを検索しやすくします。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>


<tr class="dev-program-feature-start">
<td rowspan="2" class="dev-program-feature-name">ストレージ</td>

<td>接続ストレージ</td>
<td>Xbox One 本体と PC でローミング ゲームを保存します。</td>
<td class="xbl-features-required">必須</td>
<td class="xbl-features-optional">オプション</td>
</tr>

<tr>
<td>タイトル ストレージ</td>
<td>ユーザーごとまたはタイトルごとの大量のデータ用のクラウド ストレージ。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-optional">オプション</td>
</tr>

<tr class="dev-program-feature-start">
<td rowspan="6" class="dev-program-feature-name">オンライン マルチプレーヤー</td>

<td>マルチプレイヤー セッション ディレクトリ (MPSD)</td>
<td>プレイヤーの一覧、状態など、マルチプレイヤー セッションに関する情報を保存します。</td>
<td class="xbl-features-optional">必須</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>

<tr>
<td>マッチメイキング</td>
<td>Xbox Live ではマルチプレイヤー セッションでさまざまなプレイヤーをまとめてマッチングできます。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>

<tr>
<td>アリーナ</td>
<td>プレイヤーはトーナメント スタイルで対戦できます。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>

<tr>
<td>ゲーム チャット</td>
<td>マルチプレイヤー ゲームのプレーヤー ボイス チャット</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>

<tr>
<td>Xbox Live エンジン</td>
<td>タイトルが通信できる実行可能ファイルとアセットを配置して、クライアントの計算を軽減します。</td>
<td class="xbl-features-optional">オプション</td>
<td class="xbl-features-notavailable">サポートされない</td>
</tr>

</table>
