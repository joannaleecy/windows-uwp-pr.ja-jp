---
title: Windows PC での Xbox Live セットアップのトラブルシューティング
description: Windows PC で Xbox Live 開発環境をトラブルシューティングする方法について説明します。
ms.assetid: 9cfebdcd-0c1c-4fc2-9457-e7e434b6374c
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: c1f055a49fe34be35335e50dc8b1efbfb7b9b922
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8344106"
---
# <a name="troubleshooting-xbox-live-setup-on-windows-pc"></a>Windows PC での Xbox Live セットアップのトラブルシューティング

Windows 10 の PC で、コンピューターは、次の手順を使用して正しくセットアップを確保できます。

1. コンピューターにサンプルを実行するもので、XDKS.1 サンド ボックスを変更します。  それには次のスクリプトを実行します。

        {*SDK source root*}\Tools\SwitchSandbox.cmd XDKS.1

1. SDK に含まれる zip ファイル "SourcesAndSamples.zip" の内容を抽出します。
1. サンプルのソリューションを開きます。
    1. C++ API の場合: {*SDK ソース ルート*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln
    1. C# の WinRT API 場合: {*SDK ソース ルート*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln
    1. C++/CX の WinRT API の場合: {*SDK ソース ルート*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln
1. ビルド対象のプラットフォームを、"Win32" または "x64" に変更します。
1. ソリューションを右クリックして、すべてのものを再ビルドします。
1. デバッガーでアプリを起動します。
1. サインイン[Xbox デベロッパー ポータル](https://xdp.xboxlive.com)で、作成した開発アカウントまたは[パートナー センター](https://partner.microsoft.com/dashboard)で承認されて製品版の開発者アカウントを使用します。
1. Xbox Live の情報にアクセスする権限をアプリに付与します。
1. アプリが情報を取得できること、およびゲーマータグが表示されることを確認します。