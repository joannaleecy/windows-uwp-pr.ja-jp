---
Description: 利用してユーザーの生産性と満足効果的でユーザー中心の通知を作成する方法について説明します。
title: トースト UX のガイダンス
label: Toast UX Guidance
template: detail.hbs
ms.date: 05/18/2018
ms.topic: article
keywords: windows 10、uwp、通知、コレクション、グループ、ux、ux のガイダンスについては、ガイダンス、アクション、トースト、アクション センター、noninterruptive、効果的な通知、非侵入型の通知、実行可能な管理、整理
ms.localizationpriority: medium
ms.openlocfilehash: 878df85db9ab0e33db06a86ddb726f07dc28f013
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57615767"
---
# <a name="toast-notification-ux-guidance"></a>トースト通知の UX のガイダンス
現代の暮らしにおいて; のために必要な一部である通知ユーザーの生産性とアプリと web サイト、すべての更新プログラムを最新に関与するのに役立ちます。 ただし、通知は一味に役立つ、侵入の場合は、ユーザー中心の方法で設計されていませんから簡単にできます。 通知は、無効にすることから 1 つを右クリックし、オフにするとはほとんどありません、もう一度には。  この engagement チャネルを開いたのままにしておくことができますが、通知、ユーザーの画面領域と時間、尊重を確認しておきます。

> **重要な Api**:[Windows コミュニティ Toolkit 通知 nuget パッケージ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)

Windows 利用統計情報、およびその他の最初とサード パーティ製のケース スタディ、こそが優れた通知ストーリーに関する 4 つのルールを考案する分析しました。  これらの規則は、プラットフォームに関係なく、幅広く適用できますし、通知、ユーザーに影響を与えるに役立つ確信しています。

## <a name="1-actionable-notifications"></a>1. 実践的な通知
実践的な通知を使用すると、ユーザー、アプリを開くことがなく生産性を向上します。  アプリが起動、そうでは成功した場合の唯一のメジャー、およびユーザーは有効にすると実現小さな良いことです、アプリに移動しなくてもタスク、ユーザーを喜ばせるで非常に強力なツールを使用できます。

![入力テキスト ボックスとアラームを設定し、通知に対応するボタンを含む実行可能な通知](images/actionable-notification-example01.png)

上記のアクションを利用している通知の例に示します。 終了した後のタスクの感情が例外なく肯定的感覚とそれらに実用的なコンテンツがある通知を送信することによって、アプリまたは web サイトをその感情に配置できます。 実践的な通知が生産性を向上できます、これらの小さいタスクを実行する前にアクションのユーザーに時間が減少し、エンタープライズおよびコンシューマーのシナリオでは、両方です。 ユーザーが定期的に実行するアクションなどを行うユーザーのトレーニングにしようとしていることをお勧めします。  次のような例があります。
* お気に入りに追加、フラグ、またはコンテンツね。 主演がよく
* 経費報告書承認または拒否、アクセス許可などをオフにします。
* インライン メッセージへの返信を電子メール、グループ チャット、コメントなど。
* 使用して注文完了[保留中の更新](toast-pending-update.md)
* 可能性のあるカレンダー時間を予約するほか、別の時間のアラートまたはリマインダーを設定します。

実践的な通知は、生産性の高いと思われる、タスクの実行、およびアプリや web サイトで優れたで効率的なの経験がある、ユーザーの非常に強力なツールです。  ここでの機会がたくさん! ヘルプのアイデアのブレーンストーミングを行う場合は、自由に、windows 通知チームに連絡できます。

## <a name="2-timing-and-urgency"></a>2. タイミングと緊急度
多くの場合、どのように通知についてとは対照的リアルタイムは必ずしも最適ではありません。 か開発者ユーザーについて考えてみましょうが送信されている通知は緊急の情報をお勧めします。 ユーザーは、情報が多すぎると簡単にオーバー ロードされたことができ、フォーカスしようとするときに割り込まれている場合は、不満を取得できます。 Windows には、送信する通知の割り込みの動作を考慮する方法のいくつかのオプションが用意されています。

**生の通知:** 使用して[生通知](raw-notification-overview.md)パフォーマンスを向上できます多くの理由からときに、特に注記がユーザーの中断を最小限に抑えることです。  生の通知の送信は、アプリを起動、バック グラウンドで、通知、アプリのコンテキストですぐに配信する意味があるかどうかを評価することができます。 思われるものを表示するかをユーザーにすぐ、ポップことができる場合、[ローカル トースト](send-local-toast.md)そこから。  ユーザーが確認する必要はないものである場合目下のところ、作成することができる、[トーストをスケジュール](https://blogs.msdn.microsoft.com/tiles_and_toasts/2016/09/30/quickstart-sending-an-alarm-in-windows-10/)は後で起動します。


**トーストのゴースト:** 画面の右下隅の下部でポップアップをスキップし、代わりにアクション センターに直接通知を送信する通知を起動することもできます。 これは、設定によって実現されます、 [SupressPopup プロパティ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotification.suppresspopup)を True にします。 アクション センターの外部でない通知をポップアップ表示に関するいくつかの懐疑的であるかもしれませんが、私たちに、2 を参照してください-3 回より高いトースト通知のアクション センター経由での live engagement ポップ トーストです。  ユーザーは、通知を受信する準備がされていて、ときにそれらが中断されると、これがアクション センターのコンテンツは、noninvasively ユーザーに通知するため、効果的な理由ですを制御できます。 ときに、応答性を高める。

## <a name="3-clear-out-the-clutter"></a>3.煩雑さをクリアします
通知は、アクション センターに非常に長い時間 (既定値は 3 日間) 保持できます。  ここでは存在するコンテンツは、最新の状態および関連する、ユーザーがアクション センターを開くたびに確認することが不可欠です。 、ユーザーの画面スペースを浪費して最新の情報を使用できるスロットを占有します。  たとえば、ユーザーが、電子メール管理アプリをインストールし、10 の電子メールと電子メールと共に 10 個の通知を受け取るとします。  必要な経験によって、ユーザーが、対応する電子メールの読み取りまたはアクション センターから古い煩雑さを削除する方法として、アプリを開いた場合、これらの通知をオフを検討する可能性があります。

一連のある[ToastNotificationHistory](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotificationhistory) Api を使用すると、どのようなコンテンツがアクション センター で、これらの通知を管理します。 ユーザーの画面領域を尊重し、のみをユーザーに関連があり、現在のコンテンツを表示していることに注意します。

## <a name="4-keeping-organized"></a>4。構成を維持する方法
前述のように、アクション センターのコンテンツは、3 日間保持します。  ユーザーが簡単に探している情報を取り出すために、アクション センターを使用して通知を整理[ヘッダー](https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/toast-headers)または[コレクション](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastcollection)します。 ヘッダーの下の例を見ることができます。

!['キャンプ場!!' というラベルの付いたヘッダーとトーストの例](images/toast-headers-action-center.png)

これらの方法で通知をグループ化して、関連するコンテンツの改 (スポーツ アプリケーションでは、さまざまなスポーツ リーグを分離するか、グループ チャットによるメッセージの並べ替えは考えるなど)。 コレクションは、ヘッダーより微妙なが、トリアージ、通知をより迅速に取り出すユーザーは、一方のグループの通知をより明確な方法です。

## <a name="other-resources"></a>その他のリソース
これら上記 4 つのポイントは、あることが効果的と 1 つ目とサード パーティ製の実験を使用して、テレメトリの独自の分析のガイダンスです。 注意してください、ただしがこれらのガイドラインがその: ガイドライン。  これらの規則の engagement と、通知の生産性を向上させるのに役立ちますが、ユーザー中心の考え方、および独自のデータから学習を置き換えることが何も確信しています。  

通知で変更点の分析を表示するには現在、UWP アプリに通知を送信する場合[パートナー センター](https://partner.microsoft.com/dashboard)! 使用する場合は、このデータは無料、[ストア サービス SDK](https://marketplace.visualstudio.com/items?itemName=AdMediator.MicrosoftStoreServicesSDK)または[WNS Api](https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview)します。 これらのメトリックが表示されます、windows プラットフォームで、通知の処理にもユーザー通知と対話する方法。 左側にあるエンゲージ、メニューに移動してこのデータにアクセス > 通知、[通知] ページ内の [分析] タブをクリックします。  これは、パートナー センターから通知を送信する移動は同じ場所にあります。

## <a name="related-topics"></a>関連トピック

* [トーストのコンテンツ](adaptive-interactive-toasts.md)
* [直接通知](raw-notification-overview.md)
* [保留中の更新](toast-pending-update.md)
* [GitHub (Windows の Community Toolkit の一部) の通知ライブラリ](https://github.com/Microsoft/UWPCommunityToolkit/tree/master/Microsoft.Toolkit.Uwp.Notifications)
