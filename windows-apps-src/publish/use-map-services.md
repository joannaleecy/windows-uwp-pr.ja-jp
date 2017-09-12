---
author: jnHs
Description: "Windows Phone 8.1 以前を対象としたアプリでマップ サービスを使うには、アプリのコードに含めるマップ サービス アプリケーション ID とトークンが必要です。 このトークンは Windows デベロッパー センター ダッシュボードから入手できます。"
title: "マップ サービスの使用"
ms.assetid: E5EE6B56-B86F-4D62-B16A-F023FE98EFAB
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 875d3efd6e9b27d7fced140f3d53a473fad1ae3c
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="use-map-services"></a>マップ サービスの使用


Windows Phone 8.1 以前を対象としたアプリでマップ サービスを使うには、アプリのコードに含めるマップ サービス アプリケーション ID とトークンが必要です。 このトークンは、デベロッパー センター ダッシュボードで **[マップ]** ページに移動し、目的のアプリの **[サービス]** セクションから取得できます。

> **注**  他のオペレーティング システムを対象としたアプリでマップ サービスを使うには、[Bing Maps デベロッパー センター](http://go.microsoft.com/fwlink/p/?LinkId=614880)にアクセスしてください。 詳しくは、「[マップ認証キーの要求](https://msdn.microsoft.com/library/windows/apps/mt219694)」をご覧ください。

[アプリの名前を予約](create-your-app-by-reserving-a-name.md)したら、左側のナビゲーション メニューの **[サービス]** セクションを探し、そのセクションを展開して、**[マップ]** ページを表示します。 **[トークンの取得]** をクリックすると、**ApplicationID** と **AuthenticationToken** が生成され、このページに表示されます。

> **注**  この時点でアプリの申請を完了する必要はありません。 トークンと ID を要求した後も、情報はこのページに保存されます。 いつでもこのページに戻って、この情報を参照できます。

また、アプリをパッケージ化して申請する前に、必ずアプリのコードに **ApplicationID** と **AuthenticationToken** を追加する必要があります。 詳細については、「[Windows Phone 8 でマップ コントロールをページに追加する方法](http://go.microsoft.com/fwlink/p/?LinkId=614882)」を参照してください。

 

 




