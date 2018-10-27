---
author: mijacobs
Description: Dialogs and flyouts display transient UI elements that appear when the user requests them or when something happens that requires notification or approval.
title: ダイアログとポップアップ
template: detail.hbs
ms.author: mijacobs
ms.date: 07/06/2018
ms.topic: article
keywords: Windows 10、UWP
ms.assetid: ad6affd9-a3c0-481f-a237-9a1ecd561be8
pm-contact: yulikl
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: d4ff66e988634cf1ba48809688ea6535e6e95b03
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5698334"
---
# <a name="dialogs-and-flyouts"></a>ダイアログとポップアップ



ダイアログ ボックスとポップアップは、通知、許可、またはユーザーからの追加の情報を必要とする状況が発生したときに表示される一時的な UI 要素です。

> **重要な API**: [ContentDialog クラス](/uwp/api/Windows.UI.Xaml.Controls.ContentDialog)、[Flyout クラス](/uwp/api/Windows.UI.Xaml.Controls.Flyout)


:::row:::
    :::column:::
        **Dialogs**
        
        ![Example of a dialog](../images/dialogs/dialog_RS2_delete_file.png)

        Dialogs are modal UI overlays that provide contextual app information. Dialogs block interactions with the app window until being explicitly dismissed. They often request some kind of action from the user.
    :::column-end:::
    :::column::: 
        **Flyouts**

        ![Example of a flyout](../images/flyout-example2.png)

        A flyout is a lightweight contextual popup that displays UI related to what the user is doing. It includes placement and sizing logic, and can be used to reveal a secondary control or show more detail about an item.

        Unlike a dialog, a flyout can be quickly dismissed by tapping or clicking somewhere outside the flyout, pressing the Escape key or Back button, resizing the app window, or changing the device's orientation.
    :::column-end:::
:::row-end:::


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

ダイアログとポップアップにより、ユーザーが重要な情報を認識していることを確認できますが、ユーザー エクスペリエンスは中断されます。 ダイアログはモーダル (ブロック) であるため、ユーザーは中断され、ダイアログの操作を行うまで他の操作を行うことはできません。 ポップアップの煩わしさはダイアログより低くなりますが、多用すると、煩わしくなります。

ダイアログかポップアップを使用すると決めた場合には、どちらを選択する必要があります。

ダイアログは操作をブロックし、ポップアップはブロックしないため、ダイアログの使用は、ユーザーが他のすべてを中断して情報や回答の提供に集中する必要がある状況に限定する必要があります。 一方ポップアップは、ユーザーに情報を知らせるが、ユーザーがそれを無視してもよい場合に使用します。

:::row:::
    :::column:::
   <p><b>ダイアログの用途:</b> <br/>
<ul>
<li>続行前にユーザーが読んだり確認したりする<b>必要のある重要な</b>情報を表示する場合。 次のようなシナリオが考えられます。
<ul>
  <li>ユーザーのセキュリティが侵害される可能性がある場合</li>
  <li>ユーザーが重要な資産に永続的な変更を加えようとしている場合</li>
  <li>ユーザーが重要な資産を削除しようとしている場合</li>
  <li>アプリ内購入を確認する場合</li>
</ul>

</li>
<li>接続エラーなど、アプリ全体の状況に適用されるエラー メッセージ</li>
<li>アプリからユーザーにブロック質問を表示する必要がある場合 (アプリで自動的に選ぶことができない場合など) ブロック質問とは、無視したり先送りにしたりできない質問です。この質問では、ユーザーに明確な選択肢を提示する必要があります。</li>
</ul>
</p>
    :::column-end:::
    :::column:::
   <p><b>ポップアップの用途:</b> <br/>
<ul>
<li>操作を完了する前に、必要な追加情報を収集する場合。</li>
<li>一部の場合のみに意味がある情報を表示する場合。 たとえばフォト ギャラリー アプリで、ユーザーが画像のサムネイルをクリックした場合に、大きな画像を表示するためにポップアップを使用できます。</li>
<li>詳細やページ上の項目の長い説明などの詳しい情報の表示。</li>
</ul></p>
    :::column-end:::
:::row-end:::


## <a name="ways-to-avoid-using-dialogs-and-flyouts"></a>ダイアログとポップアップを使用しないようにする方法

伝える情報の重要度が、ユーザーを中断させる必要があるものかどうかを、よく検討する必要があります。 また、情報の表示頻度を検討し、数分ごとにダイアログや通知を表示している場合には、代わりにプライマリ UI でこの情報用の領域を割り当てることを検討します。 たとえばチャット クライアントで、友人がログインするたびにポップアップを表示させるよりも、その時点でオンラインである友人の一覧を表示し、ログインが行われたときには強調表示させるなどの方法を検討します。

ダイアログは、アクション (ファイルの削除など) を実行する前に確認するために、よく使用されます。 ユーザーが特定の操作を頻繁に実行することが想定される場合には、ユーザーがアクションを毎回確認する必要があるようにするよりも、誤って操作した場合に、ユーザーが元に戻せる方法を提供することを検討します。

## <a name="how-to-create-a-dialog"></a>ダイアログを作成する方法

[ダイアログ ボックスの記事](dialogs.md)を参照してください。 

## <a name="how-to-create-a-flyout"></a>ポップアップを作成する方法

[ポップアップの記事](flyouts.md)をご覧ください。 

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="../images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックしてアプリを開き、<a href="xamlcontrolsgallery:/item/ContentDialog">ContentDialog</a> または <a href="xamlcontrolsgallery:/item/Flyout">Flyout</a> の動作を確認してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

