---
Description: お客様の Microsoft Store でアプリの一覧にリンクすることで、アプリを検出することができます。
title: アプリへのリンク
ms.assetid: 5420B65C-7ECE-4364-8959-D1683684E146
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, リンク, windows store プロトコル, アプリにリンクする, アプリへのリンク
ms.localizationpriority: medium
ms.openlocfilehash: 56bc051c3c5a935f3b6b26e478731fcde9c06902
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661537"
---
# <a name="link-to-your-app"></a>アプリへのリンク


お客様の Microsoft Store でアプリの一覧にリンクすることで、アプリを検出することができます。

## <a name="getting-the-link-to-your-apps-store-listing"></a>アプリのストア登録情報へのリンク

アプリのストア登録情報の URL を取得するには、アプリの **[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページに移動します。 URL の形式は **`https://www.microsoft.com/store/apps/<your app's Store ID>`** です。

ユーザーがこのリンクをクリックすると、アプリの Web ベースの登録情報ページが開きます。 Windows デバイスでは、ストア アプリも起動して、アプリの登録情報を表示します。


## <a name="linking-to-your-apps-store-listing-with-the-microsoft-store-badge"></a>Microsoft Store バッジが付いた、アプリのストアの一覧へのリンク

Microsoft Store アプリがユーザーに知らせるにカスタム バッジでのアプリの一覧に直接リンクすることができます。

バッジを作成するを参照してください。、 [Microsoft Store のバッジ](https://go.microsoft.com/fwlink/p/?LinkID=534236)ページ。 バッジとリンクを生成するには、アプリの 12 文字の**ストア ID** が必要です。 アプリの**ストア ID** は、**[アプリ管理]** セクションの [[アプリ ID]](view-app-identity-details.md) ページで確認できます。

> [!NOTE]
> 参照してください[App marketing ガイドライン](app-marketing-guidelines.md)情報と Microsoft Store バッジの使用に関連する要件。


## <a name="linking-directly-to-your-app-in-the-microsoft-store"></a>Microsoft Store でアプリに直接リンク

Microsoft Store を起動しを使用して、ブラウザーを開くことがなく、アプリの一覧ページに直接移動するリンクを作成することができます、 **ms-windows ストア。** URI スキーム。

ユーザーが Windows デバイスを使っていることがわかっていて、ストアの登録情報ページにユーザーが直接アクセスできるようにする場合は、このリンクが便利です。 たとえば、ブラウザーのユーザー エージェント文字列を調べてユーザーのオペレーティング システムがストアをサポートしていることを確認した後や、既に UWP アプリを使って通信している場合に、このリンクを利用できます。

この URI スキームを使用して、一覧表示するアプリのストアに直接リンクする、次のリンクをアプリの Store ID を追加します。

`ms-windows-store://pdp/?ProductId=`

詳細については、Microsoft Store のプロトコルを使用して、次を参照してください。 [Microsoft アプリを起動](../launch-resume/launch-store-app.md)します。

 

 




