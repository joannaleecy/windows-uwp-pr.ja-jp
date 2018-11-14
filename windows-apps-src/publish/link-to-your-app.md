---
author: jnHs
Description: You can help customers discover your app by linking to your app's listing in the Microsoft Store.
title: アプリへのリンク
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, リンク, windows store プロトコル, アプリにリンクする, アプリへのリンク
ms.localizationpriority: medium
ms.openlocfilehash: d0d0a9fc862734611167e5118392126cb42687f2
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6455889"
---
# <a name="link-to-your-app"></a>アプリへのリンク


顧客の Microsoft Store でアプリの登録情報にリンクして、アプリを見つけることができます。

## <a name="getting-the-link-to-your-apps-store-listing"></a>ストアのアプリの内容へのリンク

アプリのストア登録情報の URL を取得するには、アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに移動します。 URL の形式は **`https://www.microsoft.com/store/apps/<your app's Store ID>`** です。

ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。 Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。


## <a name="linking-to-your-apps-store-listing-with-the-microsoft-store-badge"></a>Microsoft ストア バッジを使ったアプリのストア登録情報へのリンク

カスタム バッジを知らせる、Microsoft ストアにアプリを使って、アプリの登録情報に直接リンクすることができます。

バッジを作成するには、 [Microsoft Store バッジ](http://go.microsoft.com/fwlink/p/?LinkID=534236)のページをご覧ください。 バッジとリンクを生成するには、アプリの 12 文字の**ストア ID** が必要です。 アプリの**ストア ID** は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。

> [!NOTE]
> 詳細と Microsoft Store バッジの使用に関連する要件については、[アプリのマーケティング ガイドライン](app-marketing-guidelines.md)を参照してください。


## <a name="linking-directly-to-your-app-in-the-microsoft-store"></a>Microsoft Store のアプリへの直接リンク

Microsoft ストアを起動し、直接アプリの登録情報ページを使用して、ブラウザーを開かずにリンクを作成する、 **ms windows ストア:** URI スキーム。

ユーザーが Windows デバイスを使っていることがわかっていて、ストアの登録情報ページにユーザーが直接アクセスできるようにする場合は、このリンクが便利です。 たとえば、ブラウザーのユーザー エージェント文字列を調べてユーザーのオペレーティング システムがストアをサポートしていることを確認した後や、既に UWP アプリを使って通信している場合に、このリンクを利用できます。

アプリのストア登録情報に直接リンクをこの URI スキームを使用するには、このリンクをアプリのストア ID を追加します。

`ms-windows-store://pdp/?ProductId=`

Microsoft ストア プロトコルの使用について詳しくは、 [Microsoft アプリの起動](../launch-resume/launch-store-app.md)を参照してください。

 

 




