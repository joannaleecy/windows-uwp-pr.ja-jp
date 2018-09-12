---
title: マルチプレイヤー用に AppXManifest を構成する
author: KevinAsgari
description: Xbox Live のマルチプレイヤー間の招待が有効になるように UWP AppXManifest を構成する方法について説明します。
ms.assetid: 72f179e7-4705-4161-9b8a-4d6a1a05b8f7
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, プロトコルのアクティブ化, マルチプレイヤー
ms.localizationpriority: medium
ms.openlocfilehash: bc20d183a16bd0f5be418699c8e7eb3b02ba889c
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881700"
---
# <a name="configure-your-appxmanifest-for-multiplayer"></a>マルチプレイヤー用に AppXManifest を構成する

次の条件に該当する場合、Visual Studio プロジェクトで .appxmanifest ファイルにいくつかの更新を行う必要があります。
- UWP を開発している
- プレイヤーが他のユーザーをタイトルに招待できる機能を実装する

この手順を実行しなかった場合、受信者のプレイヤーがプレイの招待を受け入れても、タイトルによってプロトコルがアクティブ化されません。

## <a name="open-your-packageappxmanifest"></a>Package.appxmanifest を開く

Package.appxmanifest ファイルは通常、Visual Studio プロジェクトのソリューション ファイルと同じディレクトリに置かれています。  ソリューション エクスプローラーで検索することもできます。

![](../../images/multiplayer/multiplayer_open_appxmanifest.png)

## <a name="add-new-entry"></a>新しいエントリを追加する

Package.appxmanifest ファイルの ```<Applications>``` 内にある ```<Extensions>``` 要素に以下のコードを追加する必要があります。

```
<Extensions>
  <uap:Extension Category="windows.protocol">
    <uap:Protocol Name="ms-xbl-multiplayer" />
  </uap:Extension>
</Extensions>
```

例:

![](../../images/multiplayer/multiplayer_appxmanifest_changes.png)

タイトルを保存してリビルドします。  Multiplayer Manager を使用してタイトルにプレイヤーを招待する機能を実装する方法については、「[フレンドとのマルチプレイヤーのプレイ](../multiplayer-manager/play-multiplayer-with-friends.md)」をご覧ください。
