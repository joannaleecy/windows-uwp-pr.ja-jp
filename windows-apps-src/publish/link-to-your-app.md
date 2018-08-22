---
author: jnHs
Description: You can help customers discover your app by linking to your app's listing in the Microsoft Store.
title: アプリへのリンク
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.author: wdg-dev-content
ms.date: 10/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, リンク, windows store プロトコル, アプリにリンクする, アプリへのリンク
ms.localizationpriority: medium
ms.openlocfilehash: 0025321aa73a66cc0a976bd347e613de3c3c4765
ms.sourcegitcommit: f2f4820dd2026f1b47a2b1bf2bc89d7220a79c1a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/22/2018
ms.locfileid: "2788057"
---
# <a name="link-to-your-app"></a>アプリへのリンク


お客様の Microsoft ストアのアプリの一覧にリンクすることで、アプリを見つけることができます。

## <a name="getting-the-link-to-your-apps-store-listing"></a>ストアのアプリの内容へのリンク

アプリのストア登録情報の URL を取得するには、アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに移動します。 URL の形式は **`https://www.microsoft.com/store/apps/<your app's Store ID>`** です。

ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。 Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。


## <a name="linking-to-your-apps-store-listing-with-the-microsoft-store-badge"></a>Microsoft ストア バッジ アプリのストア一覧へのリンク

直接、Microsoft ストアにアプリを顧客に伝えますにユーザー設定のバッジのアプリの一覧にリンクすることができます。

自分のバッジを作成するには、 [Microsoft ストア バッジ](http://go.microsoft.com/fwlink/p/?LinkID=534236)のページを参照してください。 バッジとリンクを生成するには、アプリの 12 文字の**ストア ID** が必要です。 アプリの**ストア ID** は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。

> [!NOTE]
> 情報を Microsoft ストア バッジの使用に関連する要件[アプリ マーケティング ガイドライン](app-marketing-guidelines.md)を参照してください。


## <a name="linking-directly-to-your-app-in-the-microsoft-store"></a>Microsoft ストアにアプリへの直接のリンク

Microsoft ストアを起動しを開かずに、ブラウザーを使用して、アプリの一覧のページに直接移動するリンクを作成する、 **ms windows-ストア:** uri します。

ユーザーが Windows デバイスを使っていることがわかっていて、ストアの登録情報ページにユーザーが直接アクセスできるようにする場合は、このリンクが便利です。 たとえば、ブラウザーのユーザー エージェント文字列を調べてユーザーのオペレーティング システムがストアをサポートしていることを確認した後や、既に UWP アプリを使って通信している場合に、このリンクを利用できます。

この uri を一覧表示するアプリのストアに直接リンクを使用するのには、このリンクをアプリのストア ID を追加します。

`ms-windows-store://pdp/?ProductId=`

詳細については、Microsoft ストア プロトコルを使用して、 [Microsoft のアプリの起動](../launch-resume/launch-store-app.md)を参照してください。

 

 




