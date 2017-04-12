---
author: mijacobs
Description: "タイル、バッジ、トースト、通知を使用して、アプリへのエントリ ポイントを提供し、ユーザーに最新情報を提示する方法について説明します。"
title: "タイル、バッジ、および通知"
ms.assetid: 48ee4328-7999-40c2-9354-7ea7d488c538
label: Tiles, badges, and notifications
template: detail.hbs
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 4a9a1b18984ed418fc31061ff2ee392230117609
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="tiles-badges-and-notifications-for-uwp-apps"></a>UWP アプリのタイル、バッジ、通知
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 


タイル、バッジ、トースト、通知を使用して、アプリへのエントリ ポイントを提供し、ユーザーに最新情報を提示する方法について説明します。

<p><img style="float: left; margin: 0px 15px 15px 0px;" src="images/tile-and-live-tile.png" />
タイルとは、スタート メニュー上でアプリを表すものです。 すべての UWP アプリにはタイルがあります。 さまざまなタイル サイズ (小、普通、大、ワイド) を有効にすることもできます。</p>

<p><em>タイル通知</em>を使用すると、タイルを更新して、新しい情報 (ニュース ヘッドライン、最新の未読メッセージの件名など) をユーザーに伝えることができます。</p>

<p><em>バッジ</em>を使用すると、システム提供のグリフまたは 1 ～ 99 の数値の形式で、状態情報または要約情報を提供できます。 バッジは、アプリのタスク バーのアイコンにも表示されます。 </p>

<p><em>トースト通知</em>は、<em>トースト</em> (または<em>バナー</em>) と呼ばれるポップアップ UI 要素を介してアプリがユーザーに送信する通知です。 通知は、ユーザーがアプリを使用中かどうかを問わず表示できます。</p>
<p><em>プッシュ通知</em>または <em>直接通知</em>は、Windows プッシュ通知サービス (WNS) またはバックグラウンド タスクのいずれかからアプリに送信される通知です。 これらの通知には、関心のあるイベントが発生したことをユーザーに通知することで応答するか、お好みの方法で応答することができます。</p>

 
## <a name="tiles"></a>タイル 
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">トピック</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[タイルの作成](tiles-and-notifications-creating-tiles.md)</p></td>
<td align="left"><p>アプリの既定のタイルをカスタマイズし、さまざまな画面サイズのアセットを提供します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)</p></td>
<td align="left"><p>アダプティブ タイル テンプレートは Windows 10 の新機能であり、シンプルで柔軟なマークアップ言語を使って、さまざまな画面密度に合わせて変化する独自のタイル通知コンテンツをデザインできるようになります。 この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリのアダプティブ ライブ タイルを作成する方法について説明します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[アダプティブ タイルのスキーマ](tiles-and-notifications-adaptive-tiles-schema.md)</p></td>
<td align="left"><p>アダプティブ タイルの作成に使う要素と属性を次に示します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[特別なタイル テンプレート](tiles-and-notifications-special-tile-templates-catalog.md)</p></td>
<td align="left"><p>特別なタイル テンプレートは、アニメーション化や、アダプティブ タイルでは不可能な機能を実行できる独特なテンプレートです。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[アプリ アイコン アセット](tiles-and-notifications-app-assets.md)</p></td>
<td align="left"><p>Windows 10 オペレーティング システム全体でさまざまな形式で表示される、アプリ アイコン アセットは、ユニバーサル Windows プラットフォーム (UWP) アプリの名刺です。 このガイドラインでは、システム内でアプリ アイコン アセットが表示される場所の詳細について説明し、最も洗練されたアイコンを作成する方法に関して詳細なデザインのヒントを提供します。</p></td>
</tr>
</tbody>
</table>

## <a name="notifications"></a>通知


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">トピック</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[アダプティブ トースト通知と対話型トースト通知](tiles-and-notifications-adaptive-interactive-toasts.md)</p></td>
<td align="left"><p>アダプティブ トースト通知と対話型トースト通知を使うと、より多くのコンテンツやオプションのインライン画像を含み、オプションのユーザー操作を備えた柔軟性のあるポップアップ通知を作成できます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Notifications Visualizer](tiles-and-notifications-notifications-visualizer.md)</p></td>
<td align="left"><p>Notifications Visualizer は、[ストア](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)の新しいユニバーサル Windows プラットフォーム (UWP) アプリで、Windows 10 のアダプティブ ライブ タイルをデザインする際に役立ちます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[通知配信方法の選択](tiles-and-notifications-choosing-a-notification-delivery-method.md)</p></td>
<td align="left"><p>この記事では、タイルとバッジの更新およびトースト通知のコンテンツを配信するための 4 つの通知オプション (ローカル、スケジュール、定期的、プッシュ) について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[ローカル タイル通知の送信](tiles-and-notifications-sending-a-local-tile-notification.md)</p></td>
<td align="left"><p>この記事では、アダプティブ タイル テンプレートを使って、ローカル タイル通知をプライマリ タイルやセカンダリ タイルに送信する方法について説明します </p></td>
</tr>
<tr class="odd">
<td align="left"><p>[定期的な通知の概要](tiles-and-notifications-periodic-notification-overview.md)</p></td>
<td align="left"><p>定期的な通知 (ポーリング通知とも呼ばれます) では、クラウド サービスから直接コンテンツをダウンロードして、一定の間隔でタイルやバッジを更新します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Windows プッシュ通知サービス (WNS) の概要](tiles-and-notifications-windows-push-notification-services--wns--overview.md)</p></td>
<td align="left"><p>Windows プッシュ通知サービス (WNS) を利用することで、サード パーティの開発者が独自のクラウド サービスからトースト更新、タイル更新、バッジ更新、直接更新を送ることができます。 これにより、新しい更新を電力効率に優れた信頼できる方法でユーザーに配信するためのメカニズムが提供されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[プッシュ通知ウィザードにより生成されるコード](tiles-and-notifications-the-code-generated-by-the-push-notification-wizard.md)</p></td>
<td align="left"><p>Visual Studio でウィザードを使うことで、Azure のモバイル サービスで作成されたモバイル サービスからプッシュ通知を生成できます。 Visual Studio ウィザードにより、この作業に役立つコードが生成されます。 このトピックでは、ウィザードによるプロジェクトの変更内容、生成されたコードによる実行内容、このコードを使う方法、プッシュ通知を最大限に活用するために次に行うことができる作業について説明します。 「[Windows プッシュ通知サービス (WNS) の概要](tiles-and-notifications-windows-push-notification-services--wns--overview.md)」をご覧ください。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[直接通知の概要](tiles-and-notifications-raw-notification-overview.md)</p></td>
<td align="left"><p>直接通知は、短い汎用のプッシュ通知です。 説明のみを目的としており、UI コンポーネントは含まれません。 他のプッシュ通知と同様に、WNS 機能は、クラウド サービスからアプリに直接通知を配信します。</p></td>
</tr>
</tbody>
</table>

 

 

 




