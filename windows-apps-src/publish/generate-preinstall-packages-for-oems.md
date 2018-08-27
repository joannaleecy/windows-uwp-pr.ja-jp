---
author: jnHs
Description: If your developer account has been granted the appropriate permissions, you can generate and download preinstall packages so that an OEM can include your app in their OS image.
title: OEM 向けのプレインストール パッケージの生成
ms.assetid: AC3A45E8-7BBD-44E9-B2D3-B74B7C9B2BC9
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 598a73b291d5f8b3c004f1e9adeddf0b92b841ab
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2857145"
---
# <a name="generate-preinstall-packages-for-oems"></a>OEM 向けのプレインストール パッケージの生成

開発者アカウントに適切なアクセス許可が付与されている場合、OEM が OS イメージにアプリを組み込めるプレインストール パッケージを生成してダウンロードできます。 プレインストールのアクセス許可は、OEM がスポンサーである開発者アカウントでのみ有効です。


## <a name="important-preinstall-policy--limitations"></a>重要なプレインストールに関するポリシーと制限事項

プレインストール アプリは、最新のストア ライセンスが適用されるように、Windows デベロッパー センターを通じて認定を受ける必要があります。これにより、プレインストール アプリでストアに接続し、アプリの更新プログラムを受信できます。

プレインストールされているアプリは、すべての市場で、現在も将来も無料である必要があります。


## <a name="generating-preinstall-packages"></a>プレインストール パッケージの生成

プレインストールのアクセス許可を持つアカウントが有効になったら、次の手順を実行します。

1.  ダッシュボードで、プレインストールするアプリに移動します。
2.  左側のナビゲーション メニューで、**[アプリ管理]** を展開し、**[現在のパッケージ]** を選びます。
3.  **[OS プレインストール用パッケージの要求]** で、**[ダウンロード可能なパッケージを有効にする]** を選びます。
4.  確認のダイアログ ボックスで、**[有効化]** を選びます。
5.  ダウンロードするパッケージを検索し、適切な **[Generate package] (パッケージの生成)** リンクを選びます。

    > [!NOTE]
    > プレインストール パッケージの生成時間は、選んだパッケージのサイズによって異なります。 パッケージの生成中は、このページから離れて後で再び戻ってくることも、このページを開いたままにしておくこともできます。

6.  パッケージが生成されると、**[パッケージのダウンロード]** リンクが表示されます。 このリンクを選んで .zip ファイルをダウンロードします。

この .zip ファイルを OEM に提供すると、OEM はこのファイルを OS イメージに含めることができます。


## <a name="support"></a>サポート

プレインストール パッケージの生成についてさらに不明な点がある場合は、<partnerops@microsoft.com> までメールでお問い合わせください。

 

 




