---
Description: Learn how to create effective and user-focused notifications that make your users productive and happy.
title: トーストの UX ガイダンス
label: Toast UX Guidance
template: detail.hbs
ms.date: 05/18/2018
ms.topic: article
keywords: windows 10, uwp, 通知, コレクション、グループ、ux, ux ガイダンスについては、ガイダンス、アクション、トースト、アクション センター、noninterruptive、効果的な通知、侵入通知、アクション可能な管理、整理
ms.localizationpriority: medium
ms.openlocfilehash: 17861760ea5640eca01d3e69c1ed36a023c8f9d3
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7989926"
---
# <a name="toast-notification-ux-guidance"></a>トースト通知の UX ガイダンス
通知は、現代の生活に必要な部分ユーザーの生産性とアプリと web サイト、任意の更新プログラムが現在のままに猶予期間に役立ちます。 ただし、通知は overbearing に便利で、ユーザーを中心とした方法でない設計されている場合、侵入からすぐにできます。 通知は 1 つを右クリックしてから、無効にされている可能性はほとんどありませんオフにすると、それらが再びオンになります。  開いているこのエンゲージメント チャネルを維持することができますが、通知、ユーザーの画面領域と時刻を尊重を確認しておきます。

> **重要な Api**: [Windows コミュニティ ツールキットの Notifications nuget パッケージ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)

Windows 利用統計情報、およびその他の最初とサード パーティ製のケース スタディを念頭に置いて、優れた通知ストーリーの周囲の 4 つの規則を分析します。  これらの規則が、プラットフォームに関係なく、広く適用されると、通知をユーザーに良い影響を与えるに役立つ確信しています。

## <a name="1-actionable-notifications"></a>1. 可能な通知
可能な通知では、アプリを開かずに生産性を向上するユーザーを許可します。  アプリが起動、のみの測定の成功した場合、これを有効にするユーザーを行ったり小さなを適切になっているタスクをアプリに移動することがなく、ユーザーを満足させる、非常に強力なツールを使用できます。

![テキスト入力ボックスとアラームを設定し、通知に応答するためのボタンを使った実践的な通知](images/actionable-notification-example01.png)

上記の操作を活用する通知の例を示します。 仕上げタスクの感覚が、ユニバーサル正の感覚とそれらに実践的なコンテンツがある通知を送信することによって、アプリまたは web サイトをその感情に表示することができます。 可能な通知が生産性を向上できます、これらの小さなタスクを実行するために通過両方をユーザーの操作に時間が減少することによって、企業とコンシューマーのシナリオでします。 ユーザーが定期的に実行できるアクションなどを行うには、ユーザーのトレーニングしようとしていることをお勧めします。  以下に例を挙げます。
* 必要に応じて、favoriting、このフラグを設定すると、またはコンテンツと
* 経費明細書の承認または拒否、無効、アクセス許可などの時刻。
* インライン メッセージへの返信、メール、グループ チャット、コメントなど。
* [保留中の更新プログラム](toast-pending-update.md)を使用して注文の完了
* 可能性のあるカレンダーで時間を予約するほか、別の時間のアラートやアラームの設定

ctionable 通知は、優れた効率の高いエクスペリエンスをアプリまたは web サイトの生産性の高いと思われる、タスクの実行して、ユーザーを支援非常に強力なツールです。  ここでの機会がたくさん! ブレーンストーミングのアイデアのヘルプを表示する場合に自由に windows 通知チームに問い合わせます。  お客様 

## <a name="2-timing-and-urgency"></a>2. タイミングと緊急度
多くの場合についての理解通知とリアルタイムには、必ずしも最適ではありません。 開発者ユーザーに関する考慮し、通知が送信されているは情報を緊急注意を払うする場合かとします。 ユーザーは、多くの情報で簡単にオーバー ロードされたことができ、フォーカスしようとするときに中断されている場合は、苛立ちを取得します。 Windows には、送信する通知の割り込みの動作を考慮する方法については、いくつかのオプションが用意されています。

**直接通知:**[直接通知](raw-notification-overview.md)を使う方法は多くの理由からときに特に、ユーザーの中断を最小限に抑えできません。  直接通知の送信がアプリを起動、バック グラウンドで通知考えるなら、アプリのコンテキストですぐに提供するかどうかを評価することができます。 かどうかを感じるものを表示するか、ユーザーにすぐにそこからの[ローカル トースト通知](send-local-toast.md)を表示することができます。  ユーザーが確認する必要はないものである場合ここでは、後で起動するための[スケジュールされたトースト](https://blogs.msdn.microsoft.com/tiles_and_toasts/2016/09/30/quickstart-sending-an-alarm-in-windows-10/)を作成することができます。

**ゴースト トースト:** 、画面の右下のポップアップをスキップし、代わりに通知がアクション センターに直接送信される通知を生成することもできます。 これを実現するには、 [SuppressPopup プロパティ](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotification.suppresspopup)を True に設定しています。 2 確認一部懐疑的ない通知が表示されるアクション センターの外部の周囲であるかもしれませんが、-3 倍高く経由でアクション センターで live トーストのエンゲージメント ポップ トーストします。  ユーザーは応答性の高いは、通知を受信する準備になるとそれらが中断される、アクション センター内のコンテンツを noninvasively ユーザーに通知するためにより効果的にすることができますが制御できます。

## <a name="3-clear-out-the-clutter"></a>3. 散乱をクリア
通知は、非常に長い時間 (既定値は 3 日) のアクション センターで保持できます。  ここで保存されるコンテンツは、最新の状態と関連するユーザーがアクション センターを開くたびにことが重要です。 ユーザーの画面のスペースを浪費してより最新の状態のものに使用できるスロットを占有します。  たとえば、ユーザーの電子メール管理アプリをインストールし、10 個のメールとそれらのメールと共に 10 個の通知を受信します。  エクスペリエンスには、目的に応じて、ユーザーが、対応するメールを読み取るかアクション センターから古いなくすを削除する方法として、アプリを開いた場合、それらの通知を消去を検討します。

お一連の[ToastNotificationHistory](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotificationhistory) 、アクション センターにどのようなコンテンツを参照できるようにする Api があるし、これらの通知を管理します。 ユーザーの画面領域を尊重し、だけをユーザーに関連して、現在のコンテンツを表示していることに注意します。

## <a name="4-keeping-organized"></a>4. 管理の構成
前述のように、アクション センターでのコンテンツの 3 日間も保持します。  ために、ユーザーがすばやく探している情報を選択、[ヘッダー](https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/toast-headers)または[コレクション](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastcollection)を使用してアクション センターに通知を整理します。 次のヘッダーの例を確認できます。

!["キャンプ場!"というラベルの付いたヘッダーを使ったトーストの例](images/toast-headers-action-center.png)

両方の関連のコンテンツが一緒に維持するための方法でこれらの gorup 通知 (つまりと思われるスポーツ アプリでのさまざまなスポーツ リーグを分離するグループ チャットでメッセージを並べ替える)。 コレクションは、ヘッダーより巧妙なが優先順位を決定しより迅速に通知を選択するユーザーは、一方のグループの通知をより明確な方法です。 

## <a name="other-resources"></a>その他のリソース
これら 4 つのポイント上記とは、ガイダンスが記載効果的な利用統計情報、当社の分析とファーストおよびサード パーティ製の実験を通じてです。 留意、ただしを次のガイドラインがその: ガイドライン。  これらの規則のエンゲージメントと、通知の生産性を向上させるのに役立ちますが、何もユーザーを中心としたと独自のデータから学習を置き換えることが確信しています。  

現在、UWP アプリに通知を送信する場合は、[パートナー センター](https://partner.microsoft.com/dashboard)で、通知で発生した問題を分析を表示する! [WNS Api](https://docs.microsoft.com/en-us/windows/uwp/design/shell/tiles-and-notifications/windows-push-notification-services--wns--overview)または[Store Services SDK](https://marketplace.visualstudio.com/items?itemName=AdMediator.MicrosoftStoreServicesSDK)を使用する場合、このデータは無料取得されます。 これらの測定値により、windows プラットフォームで、通知に何が起きる洞察もユーザーが通知と対話する方法とします。 このデータにアクセスで画面左側にある利用率の引き上げ] メニューに移動して > の通知ページ内で「分析」タブをクリックし、通知します。  これは、パートナー センターからの通知の送信に移動すると、同じ場所にあります。

## <a name="related-topics"></a>関連トピック

* [トーストのコンテンツ](adaptive-interactive-toasts.md)
* [直接通知](raw-notification-overview.md)
* [保留中の更新プログラム](toast-pending-update.md)
* [GitHub の通知ライブラリ (Windows コミュニティ ツールキットの一部)](https://github.com/Microsoft/UWPCommunityToolkit/tree/master/Microsoft.Toolkit.Uwp.Notifications)
