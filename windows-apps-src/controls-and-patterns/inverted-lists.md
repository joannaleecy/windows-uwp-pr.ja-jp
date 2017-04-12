---
author: Jwmsft
Description: "反転リストを使って新しい項目を下部に追加します。"
title: "反転リスト"
label: Inverted lists
template: detail.hbs
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 52c1d63d-69c1-48d6-a234-6f39296e4bfd
ms.openlocfilehash: 332271894b5e11657bd2b0b1ca40f0bd7620889d
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="inverted-lists"></a>反転リスト

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

リスト ビューを使って、送信者と受信者を見た目で区別しやすい項目を利用するチャット エクスペリエンスで会話を表示することができます。  異なる色と水平方向の配置を使って送信者と受信者のメッセージを区別すると、ユーザーはすばやく自分の会話の位置を確認できます。
 
通常では、上から下ではなく、下から上に一覧を表示することが必要になります。  新しいメッセージを受信して末尾に追加するときは、以前のメッセージを上にスライドして空きを作り、ユーザーの注目が新着メッセージに集まるようにします。  ただし、ユーザーが上にスクロールして以前の返信を確認している場合は、ユーザーの集中を妨害することのないように、新しいメッセージの受信で表示位置を変更しないでください。

![反転リストを使ったチャット アプリ](images/listview-inverted.png)

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**ListView クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)</li>
<li>[**ItemsStackPanel クラス**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx)</li>
<li>[**ItemsUpdatingScrollMode プロパティ**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.itemsupdatingscrollmode.aspx)</li>
</ul>
</div>


## <a name="create-an-inverted-list"></a>反転リストを作成する

反転リストを作成するには、リスト ビューと共に、項目パネルとして [**ItemsStackPanel**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.aspx) を使います。 ItemsStackPanel で、[**ItemsUpdatingScrollMode**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsstackpanel.itemsupdatingscrollmode.aspx) を [**KeepLastItemInView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemsupdatingscrollmode.aspx) に設定します。

> [!IMPORTANT]
> **KeepLastItemInView** 列挙値は、Windows 10 バージョン 1607 以上で利用できます。 この値は、アプリを以前のバージョンの Windows 10 で実行するときには使用できません。

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

## <a name="dos-and-donts"></a>推奨と非推奨

- 送信者のメッセージと受信者のメッセージを両側に配置して、ユーザーが会話のフローを簡単に理解できるようにします。
- ユーザーが既に会話の末尾を読んでいて次のメッセージを待っている場合は、既存のメッセージを上に移動して最新のメッセージを表示するアニメーションを表示します。
- ユーザーが会話の末尾を読んでいない場合は、項目を移動することによってユーザーの集中を妨害してはいけません。
