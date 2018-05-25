---
title: Windows PC での Xbox Live セットアップのトラブルシューティング
author: KevinAsgari
description: Windows PC で Xbox Live 開発環境をトラブルシューティングする方法について説明します。
ms.assetid: 9cfebdcd-0c1c-4fc2-9457-e7e434b6374c
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, トラブルシューティング
ms.localizationpriority: low
ms.openlocfilehash: 13597552c5440023cffde8fc97226d9d23e845ad
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="troubleshooting-xbox-live-setup-on-windows-pc"></a>Windows PC での Xbox Live セットアップのトラブルシューティング

Windows 10 PC では、以下の手順を使用して、コンピューターが正しくセットアップされていることを確認できます。

1. 対象のコンピューターに移動し、サンプルを実行するように設計されている XDKS.1 サンドボックスを参照します。  それには次のスクリプトを実行します。

        {*SDK source root*}\Tools\SwitchSandbox.cmd XDKS.1

1. SDK に含まれる zip ファイル "SourcesAndSamples.zip" の内容を抽出します。
1. サンプルのソリューションを開きます。
    1. C++ API の場合: {*SDK ソース ルート*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln
    1. C# の WinRT API 場合: {*SDK ソース ルート*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln
    1. C++/CX の WinRT API の場合: {*SDK ソース ルート*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln
1. ビルド対象のプラットフォームを、"Win32" または "x64" に変更します。
1. ソリューションを右クリックして、すべてのものを再ビルドします。
1. デバッガーでアプリを起動します。
1. 作成した開発アカウントを使用して https://xdp.xboxlive.com にサインインします
1. Xbox Live の情報にアクセスする権限をアプリに付与します。
1. アプリが情報を取得できること、およびゲーマータグが表示されることを確認します。
