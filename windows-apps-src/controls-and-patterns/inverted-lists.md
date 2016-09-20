---
author: Jwmsft
Description: "反転リストを使って新しい項目を下部に追加します。"
title: "反転リスト"
label: Inverted lists
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: eb6744968a4bf06a3766c45b73b428ad690edc06
ms.openlocfilehash: c70cafe4d1dd3db46d48e9844ba9086dbba9acaa

---
# 反転リスト

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

リスト ビューを使って、送信者と受信者を見た目で区別しやすい項目を利用するチャット エクスペリエンスで会話を表示することができます。  異なる色と水平方向の配置を使って送信者と受信者のメッセージを区別すると、ユーザーはすばやく自分の会話の位置を確認できます。
 
通常では、上から下ではなく、下から上に一覧を表示することが必要になります。  新しいメッセージを受信して末尾に追加するときは、以前のメッセージを上にスライドして空きを作り、ユーザーの注目が新着メッセージに集まるようにします。  ただし、ユーザーが上にスクロールして以前の返信を確認している場合は、ユーザーの集中を妨害することのないように、新しいメッセージの受信で表示位置を変更しないでください。

![反転リストを使ったチャット アプリ](images/listview-inverted.png)

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li><a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx"><strong>ListView クラス</strong></a></li>
<li><a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx"><strong>ItemsStackPanel クラス</strong></a></li>
<li><a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.itemsupdatingscrollmode.aspx"><strong>ItemsUpdatingScrollMode プロパティ</strong></a></li>
</ul>

</div>
</div>






## 反転リストを作成する

反転リストを作成するには、リスト ビューと共に、項目パネルとして [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx) を使います。 ItemsStackPanel で、[**ItemsUpdatingScrollMode**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.itemsupdatingscrollmode.aspx) を [**KeepLastItemInView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsupdatingscrollmode.aspx) に設定します。

> **重要**&nbsp;&nbsp;**KeepLastItemInView** 列挙値は、Windows 10 バージョン 1607 以上で利用できます。 この値は、アプリを以前のバージョンの Windows 10 で実行するときには使用できません。

この例は、リスト ビューの項目を下部に配置する方法や、項目に変更があったときに最後の項目をビュー内に維持するように指定する方法を示しています。
 
 **XAML**
 ```xaml
<ListView>
    <ListView.ItemsPanel>
        <ItemsPanelTemplate>
            <ItemsStackPanel VerticalAlignment="Bottom"
                             ItemsUpdatingScrollMode="KeepLastItemInView"/>
        </ItemsPanelTemplate>
    </ListView.ItemsPanel>
</ListView>
```

## 推奨事項

- 送信者のメッセージと受信者のメッセージを両側に配置して、ユーザーが会話のフローを簡単に理解できるようにします。
- ユーザーが既に会話の末尾を読んでいて次のメッセージを待っている場合は、既存のメッセージを上に移動して最新のメッセージを表示するアニメーションを表示します。
- ユーザーが会話の末尾を読んでいない場合は、項目を移動することによってユーザーの集中を妨害してはいけません。



<!--HONumber=Aug16_HO3-->


