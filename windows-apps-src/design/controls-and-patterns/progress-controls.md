---
Description: プログレス コントロールは、時間のかかる操作が進行中であることを示すフィードバックをユーザーに返します。
title: プログレス コントロールのガイドライン
ms.assetid: FD53B716-C43D-408D-8B07-522BC1F3DF9D
label: Progress controls
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: kisai
design-contact: jeffarn
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a162d992390e8fc7d05d52303ec292fcf8e920a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57634427"
---
# <a name="progress-controls"></a>プログレス コントロール

 

プログレス コントロールは、時間のかかる操作が進行中であることを示すフィードバックをユーザーに返します。 使用されているインジケーターに応じて、進行状況インジケーターが表示されているときはユーザーはアプリを操作できないことを知らせたり、待ち時間の長さを示したりできます。

> **重要な API**:[ProgressBar クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx)、 [IsIndeterminate プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.isindeterminate.aspx)、 [ProgressRing クラス](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx)、 [IsActive プロパティ](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.isactive.aspx)

## <a name="types-of-progress"></a>プログレス コントロールの種類

操作が進行中であることをユーザー示すコントロールは 2 つあります。ProgressBar または ProgressRing を使います。

-   ProgressBar の*確定*状態では、タスクが完了しているパーセンテージを表示します。 これは、期間がわかっている操作の間に使いますが、その進行状況でユーザーのアプリとのやり取りはブロックされません。
-   ProgressBar の*不確定*状態は、操作が進行中であることを示します。ユーザーのアプリとのやり取りはブロックされず、完了時間は不明です。
-   ProgressRing には*不確定*状態だけがあり、操作が完了するまでさらにユーザーのやり取りがブロックされるときに使います。

なお、プログレス コントロールは読み取り専用で、対話型ではありません。 つまり、ユーザーはこれらのコントロールを直接呼び出したり、使ったりすることはできません。

![ProgressBar 状態](images/ProgressBar_TwoStates.png)

*上から下、不確定な ProgressBar と不確定の ProgressBar*

![ProgressRing 状態](images/ProgressRing_SingleState.png)

*中間の ProgressRing*

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ProgressBar">ProgressBar</a> または <a href="xamlcontrolsgallery:/item/ProgressRing">ProgressRing</a> の動作を確認してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

## <a name="when-to-use-each-control"></a>各コントロールを使う状況

何が起こっているかを表示するとき、どのコントロールを使うか、どの状態 (確定または不確定) を使うかが明白でない場合があります。 タスクの内容が明らかでプログレス コントロールを使う必要がないときもあり、プログレス コントロールを使う場合でも、どういう操作が進行中かをユーザーに説明するために 1 行のテキストが必要なときもあります。

### <a name="progressbar"></a>ProgressBar
-   **コントロールは、定義された期間または予測可能な終了にありますか。**

    確定 ProgressBar を使用し、パーセンテージや値を適宜更新します。

-   **ユーザーは、操作の進行状況を監視することがなく続行しますか。**

    ProgressBar の使用中、やり取りは非モーダルであり、通常はその操作が完了するまでユーザーがブロックされることはありません。操作が完了するまで、その他の方法でアプリを使い続けることができます。

-   **キーワード**

    操作で次のようなキーワードが表示される場合、または進行状況の処理と同時にこれらのキーワードと一致するテキストを表示する場合は、ProgressBar の使用を検討してください。

    - *読み込んでいます.*
    - *取得します。*
    - *作業しています.*

### <a name="progressring"></a>ProgressRing

-   **操作が原因がユーザーに続行を待機するでしょうか。**

    操作によって、操作が完了するまでアプリとのすべて (または大部分) のやり取りを待つことが必要になる場合は、ProgressRing の方が適しています。 ProgressRing コントロールはモーダル操作向けに使われます。つまり、ProgressRing が消えるまでユーザーはブロックされます。

-   **アプリがタスクを実行するユーザーを待機しているでしょうか。**

    待っている場合は、ProgressRing を使って不明の待ち時間をユーザーに示します。

-   **キーワード**

    操作で次のようなキーワードが表示される場合、または進行状況の処理と同時にこれらのキーワードと一致するテキストを表示する場合は、ProgressRing の使用を検討してください。

    - *更新します。*
    - *サインインしています.*
    - *接続しています.*

### <a name="no-progress-indication-necessary"></a>進行状況を示す必要なし
-   **ユーザーは、何かが発生していることを把握する必要がありますか。**

    たとえば、アプリがバックグラウンドで何かをダウンロードしていて、ダウンロードを開始したのがユーザーでない場合、ユーザーは必ずしもそのことを知る必要がありません。

-   **操作内のユーザーに (ただし、まだいくつかの) 最小限の関心のある、ユーザー アクティビティをブロックしないバック グラウンド アクティビティとは**

    アプリが、常に見えている必要はないものの、進行状況を表示する必要はあるタスクを実行している場合は、テキストを使います。

-   **ユーザーのみに注意、操作を完了しますか。**

    操作が完了したときだけ通知を表示するか、操作がすぐに完了したというビジュアルを表示し、最後の仕上げをバック グラウンドで実行することが最良のときがあります。

## <a name="progress-controls-best-practices"></a>プログレス コントロールのベスト プラクティス

これらのさまざまなプログレス コントロールを使用する状況と場所の視覚的な表現をいくつか表示することが最良のときがあります。

**ProgressBar の不確定です。**

![ProgressBar の確定状態の例](images/PB_DeterminateExample.png)

最初の例は確定 ProgressBar です。 操作の期間がわかっていて、インストール、ダウンロード、設定などを行うときは、確定 ProgressBar が最良です。

**ProgressBar の不確定**

![ProgressBar の不確定状態の例](images/PB_IndeterminateExample.png)

操作にどの程度の時間がかかるかがわからないときは、不確定 ProgressBar を使います。 不確定 ProgressBar は、仮想化されたリストに入力し、不確定 ProgressBar から確定 ProgressBar への滑らかな視覚的な遷移を作成するときにも適切です。

-   **操作は、仮想化されたコレクション内にあるでしょうか。**

    その場合は、各リスト項目に進行状況インジケーターを配置しないでください。 代わりに ProgressBar を使い、読み込まれている項目のコレクションの一番上にそれを配置して、項目が取得されていることを示します。

**ProgressRing - 不確定**

![ProgressRing の不確定状態の例](images/PR_IndeterminateExample.png)

ユーザーのそれ以上のアプリとのやり取りが停止されたとき、またはアプリがユーザーの入力を待っているときは、不確定 ProgressRing が使われます。 上記の「サインインしています…」の例は、 ProgressRing の完全なシナリオであり、ユーザーはサインインが完了するまでアプリの使用を続けることはできません。

## <a name="customizing-a-progress-control"></a>プログレス コントロールのカスタマイズ

両方のプログレス コントロールはかなりシンプルですが、コントロールの視覚的な機能の一部はカスタマイズの方法が明白ではありません。

**ProgressRing をサイズ変更**

ProgressRing は必要なサイズに変更できますが、20 x 20 epx までしか縮小できません。 ProgressRing のサイズを変更するには、高さと幅を設定する必要があります。 高さまたは幅だけが設定された場合、最小サイズ (20 x 20 epx) が想定されます。逆に高さと幅が 2 つの異なるサイズに設定された場合、小さい方のサイズが想定されます。
ProgressRing を必要な大きさにするには、高さと幅を同じ値に設定してください。

```XAML
<ProgressRing Height="100" Width="100"/>
```

ProgressRing を表示してアニメーション化するには、IsActive プロパティを true に設定する必要があります。

```XAML
<ProgressRing IsActive="True" Height="100" Width="100"/>
```

```C#
progressRing.IsActive = true;
```

**進行状況コントロールを色分け表示**

既定では、プログレス コントロールのメインの色はシステムのアクセント カラーに設定されます。 このブラシを上書きするには、どちらかのコントロールの foreground プロパティを変更します。

```XAML
<ProgressRing IsActive="True" Height="100" Width="100" Foreground="Blue"/>
<ProgressBar Width="100" Foreground="Green"/>
```

ProgressRing の前景色を変更すると、ドットの色が変更されます。 ProgressBar の foreground プロパティを変更すると、バーの塗りつぶしの色が変更されます。バーの塗りつぶされない部分を変更するには、background プロパティを上書きします。

**待機カーソルを表示**

アプリまたは操作で処理に少し時間がかかり、待機カーソルが表示されているアプリまたは領域では待機カーソルが消えるまでやり取りできないことをユーザーに示す必要があるときは、簡潔な待機カーソルを表示することをお勧めします。

```C#
Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 10);
```

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Xaml-Controls-Gallery) - インタラクティブな形で XAML コントロールのすべてを参照できます。

## <a name="related-articles"></a>関連記事

- [ProgressBar クラス](https://msdn.microsoft.com/library/windows/apps/br227529)
- [ProgressRing クラス](https://msdn.microsoft.com/library/windows/apps/br227538)

**開発者向け (XAML)**
- [進行状況コントロールを追加します。](https://msdn.microsoft.com/library/windows/apps/xaml/hh780651)
- [Windows Phone のカスタムの不確定な進行状況バーを作成する方法](https://go.microsoft.com/fwlink/p/?LinkID=392426)
