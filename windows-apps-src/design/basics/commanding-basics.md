---
author: mijacobs
Description: In a Universal Windows Platform (UWP) app, command elements are the interactive UI elements that enable the user to perform actions, such as sending an email, deleting an item, or submitting a form.
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコマンド設計の基本
ms.assetid: 1DB48285-07B7-4952-80EF-02B57D4469F2
label: Command design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 07b9ce7b5a57f6dc1ba202ed57e8b2d4d93e583f
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1654391"
---
#  <a name="command-design-basics-for-uwp-apps"></a>UWP アプリのコマンド設計の基本

ユニバーサル Windows プラットフォーム (UWP) アプリでは、*コマンド要素*は、ユーザーがメール送信、項目の削除、フォームの送信などのアクションを実行できる対話型の UI 要素です。 

この記事では、一般的なコマンド要素、それらの要素でサポートされる操作、それらの要素をホストするためのコマンド サーフェスについて説明します。

![マップ アプリのコマンド要素](images/maps.png)

上に、マップ アプリのコマンド要素の例を示しています。

## <a name="provide-the-right-type-of-interactions"></a>適切な種類の操作の提供

コマンド インターフェイスを設計する際、最も重要な決定はユーザーが何を実行できる必要があるかという点です。 適切な種類の操作を計画するには、アプリに集中して、有効にするユーザー エクスペリエンス、およびユーザーが行う必要がある操作の手順を検討します。 ユーザーが実行できる操作を決定したら、それを行うためのツールを提供します。

アプリで提供する操作には次のものがあります。

- 情報の送信または提出 
- 設定とオプションの選択
- コンテンツの検索とフィルター処理
- ファイルを開く、保存する、削除する
- コンテンツの編集または作成

## <a name="use-the-right-command-element-for-the-interaction"></a>操作に適切なコマンド要素を使用

適切な要素を使ってコマンド操作を実行することは、直感的で使いやすいアプリとなるか、使いにくくてややこしいアプリとなるかの分かれ目になります。 ユニバーサル Windows プラットフォーム (UWP) には、アプリで使うことができる多くのコマンド要素セットが用意されています。 最も一般的ないくつかのコントロールの一覧と、それによって可能になる操作の概要を以下に示します。

<div class="mx-responsive-img">
<table>
<thead>
<tr class="header">
<th align="left">カテゴリ</th>
<th align="left">要素</th>
<th align="left">操作</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><b>ボタン</b><br/><br/>
    <img src="../controls-and-patterns/images/controls/button.png" alt="button" /></td>
<td align="left"><a href="../controls-and-patterns/buttons.md">ボタン</a></td>
<td align="left">即座にアクションをトリガーします。 メールの送信、フォーム データの送信、ダイアログでのアクションの確認などの操作です。</td>
</tr>
<tr class="even">
<td align="left">リスト<br/><br/>
    <img src="../controls-and-patterns/images/controls/combo-box-open.png" alt="drop down list" /></td>
<td align="left"><a href="../controls-and-patterns/lists.md">ドロップダウン リスト、リスト ボックス、リスト ビューとグリッド ビュー</a></td>
<td align="left">対話型のリストまたはグリッド内に項目を表示します。 通常、オプションや表示項目が多い場合に使用されます。</td>
</tr>
<tr class="odd">
<td align="left">選択コントロール<br/><br/>
    <img src="../controls-and-patterns/images/controls/radio-button.png" alt="radio button" /></td>
<td align="left"><a href="../controls-and-patterns/checkbox.md">チェック ボックス</a>、<a href="../controls-and-patterns/radio-button.md">ラジオ ボタン</a>、<a href="../controls-and-patterns/toggles.md">トグル スイッチ</a></td>
<td align="left">アンケートに入力するときや、アプリ設定を構成するときなどに、ユーザーがいくつかのオプションから選択できるようにします。</td>
</tr>
<tr class="even">
<td align="left">日付/時刻選択ツール<br/><br/>
    <img src="../controls-and-patterns/images/controls/calendar-date-picker-open.png" alt="date picker" /></td>
<td align="left"><a href="../controls-and-patterns/date-and-time.md">カレンダーの日付選択ツール、カレンダー ビュー、日付の選択、時刻の選択</a></td>
<td align="left">イベントを作成するときや、アラームを設定するときなどに、ユーザーが日時情報を表示して変更できるようにします。</td>
</tr>
<tr class="odd">
<td align="left">テキスト予測入力<br/><br/>
    <img src="../controls-and-patterns/images/controls/auto-suggest-box.png" alt="autosuggest box" /></td>
<td align="left"><a href="../controls-and-patterns/auto-suggest-box.md">自動提案ボックス</a></td>
<td align="left">データを入力したりクエリを実行したりするときに、ユーザーが入力するにつれて入力候補を表示します。</td>
</tr>
</tbody>
</table>
</div>

全一覧については、「[コントロールと UI 要素](https://dev.windows.com/design/controls-patterns)」をご覧ください。

##  <a name="place-commands-on-the-right-surface"></a>適切なサーフェスへのコマンドの配置
アプリのキャンバスや、コマンド バー、メニュー、ダイアログ、ポップアップなどの特殊なコマンド要素を含む、アプリの多くのサーフェスにコマンド要素を配置できます。

できる限り、コンテンツを操作するコマンドを用意せず、ユーザーがコンテンツを直接操作できるようにしてください。 たとえば、上下に移動するコマンド ボタンを使うのではなく、リスト項目をドラッグ アンド ドロップしてリストを並べ替えることができるようにします。
  
ユーザーが直接コンテンツを操作できない場合は、コマンド要素をアプリのコマンド サーフェスに配置します。

<div class="mx-responsive-img">
<table class="uwpd-top-aligned-table">

<tr class="header">
<th align="left">サーフェス</th>
<th align="left">説明</th>
<th align="left">例</th>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top">アプリのキャンバス (コンテンツ領域)
<p><img src="images/content-area.png" alt="The content area of an app" /></p></td>

<td align="left" style="vertical-align: top;">ユーザーがコア シナリオを完了するためにあるコマンドが常に必要な場合は、そのコマンドをキャンバスに配置できます。 コマンドは影響を与えるオブジェクトの近く (またはその上) に配置できるため、キャンバスにコマンドを配置すると使い方がわかりやすくなります。
<p>ただし、キャンバスに配置するコマンドは慎重に選んでください。 アプリのキャンバスにコマンドが多すぎると、貴重な画面のスペースがなくなり、ユーザーを困惑させる可能性があります。 それほど頻繁に使わないコマンドの場合、別のコマンド サーフェスに配置することを検討してください。</p> 
</td><td>
マップ アプリのキャンバス上の自動提案ボックス。
<br></br>
  <img src="images/maps-canvas.png" alt="autosuggest box on Maps app canvas"/>
</td>
</tr>

<tr class="even">
<td align="left" style="vertical-align: top;"><a href="../controls-and-patterns/app-bars.md">コマンド バー</a>
<p><img src="../controls-and-patterns/images/controls_appbar_icons.png" alt="Example of a command bar with icons" /></p></td>
<td align="left" style="vertical-align: top;"> コマンド バーを使うと、コマンドを整理しやすくなり、アクセスしやすくなります。 コマンド バーは画面の上部または画面の下部、あるいは画面の上部と下部の両方に配置できます。 
</td>
<td>
マップ アプリの上部のコマンド バー。
<br></br>
<img src="images/maps-commandbar.png" alt="command bar in Maps app"/>
</td>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top;"><a href="../controls-and-patterns/menus.md">メニューとコンテキスト メニュー</a>
<p><img src="images/controls-contextmenu-singlepane.png" alt="Example of a single-pane context menu" /></p></td>
<td align="left" style="vertical-align: top;">複数のコマンドをコマンド メニューにグループ化してスペースを節約することで、効率性が高まる場合があります。 メニューとコンテキスト メニューは、ユーザーが要求したときにコマンドやオプションの一覧を表示します。
<p>ショートカット メニューは、よく使うアクションへのショートカットを提供し、クリップボードやカスタム コマンドなど、特定のコンテキストにのみ関連するセカンダリ コマンドにアクセスできるようにします。 コンテキスト メニューは通常、ユーザーが右クリックすることで表示されます。</p>
</td><td>
マップ アプリでユーザーが右クリックすると、コンテキスト メニューが表示されます。
<br></br>
  <img src="images/maps-contextmenu.png" alt="context menu in Maps app"/>
</td>
</tr>
</table>
</div>

## <a name="provide-feedback-for-interactions"></a>操作に対するフィードバックの提供

フィードバックでコマンドの実行結果を伝えると、ユーザーは実行したことと次に実行できることを把握することができます。 フィードバックが UI に自然に統合されていて、ユーザーの介在が不要であるか、どうしても必要な場合以外は他の操作が不要であることが理想的です。 

アプリでフィードバックを提供する方法をいくつか示します。

<div class="mx-responsive-img">
<table class="uwpd-top-aligned-table">

<tr class="header">
<th align="left">サーフェス</th>
<th align="left">説明</th>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top;"> <a href="../controls-and-patterns/app-bars.md">コマンド バー</a>
<p><img src="../controls-and-patterns/images/controls_appbar_icons.png" alt="Example of a command bar with icons" /></p>
</td>
<td align="left" style="vertical-align: top;"> コマンド バーのコンテンツ領域は、ユーザーがフィードバックの表示を求めている場合にユーザーに状態を伝えるための直感的でわかりやすい場所です。
<p>
  <img src="images/commandbar_anatomy.png" alt="Command bar content area for feedback"/>
  </p>
</td>
</tr>

<tr class="even">
<td align="left" style="vertical-align: top;"><a href="../controls-and-patterns/dialogs.md">ポップアップ</a>
<p><img src="images/controls-flyout-default-200.png" alt="Image of default flyout" /></p></td>
<td align="left" style="vertical-align: top;">
その外側をタップするかクリックすることで閉じることができる、軽量な状況依存のポップアップ。
<p>
  <img src="../controls-and-patterns/images/controls/flyout.png" alt="Flyout above button"/>
  </p>
</td>
</tr>

<tr class="odd">
<td align="left" style="vertical-align: top;"><a href="../controls-and-patterns/dialogs.md">ダイアログ コントロール</a>
<p><img src="images/controls-dialog-twobutton-200.png" alt="Example of a simple two-button dialog" /></p></td>
<td align="left" style="vertical-align: top;">ダイアログは、状況依存のアプリ情報を表示するモーダル UI オーバーレイです。 ほとんどの場合、ダイアログは明示的に閉じられまでアプリ ウィンドウの操作を妨げます。また、多くの場合、ユーザーに操作を要求します。
<p>ダイアログは、煩わしく感じることがあるため、特定の状況でのみ使用してください。 詳しくは、「[アクションを確認または元に戻すタイミング](#when-to-confirm-or-undo-actions)」をご覧ください。</p>
<p>
  <img src="../controls-and-patterns/images/dialogs/dialog_RS2_delete_file.png" alt="dialog delete file"/></p>
</td>
</tr>

</table>
</div>

> [!TIP]
> アプリで使う確認ダイアログの量に注意してください。ユーザーが間違えたときはとても役に立ちますが、ユーザーが意図的にアクションを実行しようとしているときは邪魔になります。

### <a name="when-to-confirm-or-undo-actions"></a>アクションを確認または元に戻すタイミング

適切に設計されたユーザー インターフェイスであっても、ユーザーがどれほど慎重に作業したとしても、すべてのユーザーは必ず意図しないアクションを実行します。 ユーザーにアクションの確認を求めたり、最近のアクションを元に戻す方法を用意したりして、アプリでこのような状況に対処することができます。

-   元に戻すことができず、実行結果が重大な操作の場合は、確認ダイアログ ボックスの使用をお勧めします。 このような操作の例は、次のとおりです。
    -   ファイルを上書きする
    -   ファイルを保存せずに終了する
    -   ファイルやデータを完全に削除することを確認する
    -   購入する (確認メッセージを表示しないことをユーザーが選択した場合を除く)
    -   何かへのサインアップなどのフォームを送信する
-   元に戻すことができる操作の場合は、通常、単純な "元に戻す" コマンドを提供すれば十分です。 このような操作の例は、次のとおりです。
    -   ファイルを削除する
    -   メールを削除する (完全には削除しない)
    -   コンテンツを変更する、またはテキストを編集する
    -   ファイル名を変更する

##  <a name="optimize-for-specific-input-types"></a>特定の入力タイプの最適化

特定の入力の種類やデバイスを中心としたユーザー エクスペリエンスの最適化について詳しくは、「[操作の基本情報](../input/index.md)」をご覧ください。