---
author: jnHs
Description: "アプリのストア登録情報ページにリンクすることで、ユーザーがアプリを見つけやすくすることができます。"
title: "アプリへのリンク"
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, リンク, windows store プロトコル, アプリにリンクする, アプリへのリンク"
ms.openlocfilehash: 2d0750493926937a6326c5f72f568d4294b137c5
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="link-to-your-app"></a>アプリへのリンク


アプリのストア登録情報ページにリンクすることで、ユーザーがアプリを見つけやすくすることができます。

## <a name="getting-the-link-to-your-apps-store-listing"></a>アプリのストア登録情報へのリンク

アプリのストア登録情報の URL を取得するには、アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに移動します。 URL の形式は **`https://www.microsoft.com/store/apps/<your app's Store ID>`** です。

ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。 Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。


## <a name="linking-to-your-apps-store-listing-with-the-windows-store-badge"></a>Windows ストア バッジを使ったアプリのストア登録情報へのリンク

カスタム バッジを使ってアプリの登録情報に直接リンクし、ユーザーにアプリが Windows ストアにあることを知らせることができます。

バッジを作成するには、[Windows ストア バッジ](http://go.microsoft.com/fwlink/p/?LinkID=534236)に関するページをご覧ください。 バッジとリンクを生成するには、アプリの 12 文字の**ストア ID** が必要です。 アプリの**ストア ID** は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。

> [!NOTE]
> Windows ストア バッジの使用に関する情報と要件については、[アプリのマーケティング ガイドライン](app-marketing-guidelines.md)をご覧ください。


## <a name="linking-directly-to-your-app-in-the-windows-store"></a>Windows ストアのアプリへの直接リンク

ブラウザーを開いて **ms-windows-store:** URI スキームを使わなくても、Windows ストアを起動して、直接アプリの登録情報ページに移動するリンクを作成できます。

ユーザーが Windows デバイスを使っていることがわかっていて、ストアの登録情報ページにユーザーが直接アクセスできるようにする場合は、このリンクが便利です。 たとえば、ブラウザーのユーザー エージェント文字列を調べてユーザーのオペレーティング システムがストアをサポートしていることを確認した後や、既に UWP アプリを使って通信している場合に、このリンクを利用できます。

Windows ストア プロトコルを使って、アプリのストア登録情報に直接リンクするには、このリンクにアプリのストア ID を追加します。

`ms-windows-store://pdp/?ProductId=`

Windows ストア プロトコルの使用について詳しくは、「[Windows ストア アプリの起動](../launch-resume/launch-store-app.md)」をご覧ください。

 

 




