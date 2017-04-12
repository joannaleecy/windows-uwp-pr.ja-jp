---
author: jnHs
Description: "ストアのアプリの内容ページにリンクすることで、ユーザーがアプリを見つけやすくすることができます。"
title: "アプリへのリンク"
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 145716d88cd6c940535cafe9c72fce3831151460
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="link-to-your-app"></a>アプリへのリンク


ストアのアプリの内容ページにリンクすることで、ユーザーがアプリを見つけやすくすることができます。

## <a name="getting-the-link-to-your-apps-store-listing"></a>ストアのアプリの内容へのリンク


ストアのアプリの内容へのリンクは、ダッシュボードにある各アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。

このリンクは、**`https://www.microsoft.com/store/apps/<your app's Store ID>`** の形式で示されます。

ユーザーがこのリンクをクリックすると、アプリの Web ベースの内容ページが開きます。 アプリがユーザーのデバイスで利用できる場合、ストア アプリも起動して、アプリの内容を表示します。

> **注**  対象としている OS のバージョンによって、複数のリンクが表示されることがあります。 すべてのアプリで Windows 10 向けの URL が表示されます。この URL は任意の OS で機能します。 Windows 8.1 以前や Windows Phone 8.1 以前向けの追加のリンクが表示されることもあります。それらは指定された OS バージョンでのみ機能します。

 

## <a name="linking-to-your-apps-store-listing-with-the-windows-store-badge"></a>Windows ストア バッジを使ったストアのアプリの内容へのリンク


カスタム バッジを使ってアプリの内容に直接リンクし、ユーザーにアプリが Windows ストアにあることを知らせることができます。

バッジを作成するには、[Windows ストア バッジ](http://go.microsoft.com/fwlink/p/?LinkID=534236)に関するページをご覧ください。 この形式を使ってバッジとリンクを生成するには、アプリのストア ID が必要です。 この ID は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに表示される **[Windows 10 の URL]** の末尾の 12 文字です。

> **注**  Windows ストア バッジの使用について詳しくは、[アプリのマーケティング ガイドライン](app-marketing-guidelines.md)をご覧ください。

 

## <a name="linking-directly-to-your-app-in-the-windows-store"></a>Windows ストアのアプリへの直接リンク


ブラウザーを開いて **ms-windows-store:** URI スキームを使わなくても、Windows ストアを起動して、直接アプリの内容ページに移動するリンクを作成できます。

これらのリンクは、ユーザーが Windows デバイスを使用しており、ユーザーが直接ストア内の内容ページにアクセスできるようにする必要がある場合に便利です。たとえば、ブラウザーでユーザー エージェント文字列を調べてユーザーのオペレーティング システムを確認した後や、既に UWP アプリを使って通信しているときに、このプロトコルを適用できます。

Windows ストア プロトコルを使って、ストアのアプリの内容に直接リンクするには、このリンクにアプリのストア ID を追加します。

`ms-windows-store://pdp/?ProductId=`

Windows ストア プロトコルの使用について詳しくは、「[Windows ストア アプリの起動](../launch-resume/launch-store-app.md)」をご覧ください。

 

 




