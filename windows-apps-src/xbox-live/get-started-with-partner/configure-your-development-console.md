---
title: Xbox 開発機本体を構成する
description: Xbox Live の開発をサポートするように Xbox 開発機本体を構成する方法について説明します。
ms.assetid: f8fd1caa-b1e9-4882-a01f-8f17820dfb55
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 479be2401e0c54801645ad1c0d91b11b7ffb6869
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649017"
---
# <a name="configure-your-xbox-development-console"></a>Xbox 開発機本体を構成する

開発機本体を構成するには:
- ID を取得する
- 開発キットにサンドボックスを設定する
- 開発アカウントでサインインする

## <a name="get-your-ids"></a>ID を取得する
サンドボックスと Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。 これらは同じプロセスで行うことができます。

「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」に従って ID を取得します。

## <a name="set-your-sandbox-on-your-development-kits"></a>開発キットにサンドボックスを設定する
開発キットを起動するには、サンドボックス ID を設定する必要があります。 これを行うには、XDK で PC にインストールした "Xbox One Manager" を使用することも、XDK コマンド ウィンドウを開き、次のように構成コマンド (xbconfig.exe) を使用することもできます。

現在のサンドボックスを確認します。 コマンド プロンプトで「xbconfig sandboxid」と入力します。

想定したものでない場合は、サンドボックス ID を変更します。コマンド プロンプトで「xbconfig sandboxid=<your sandbox id>」と入力します。

コマンド プロンプトで Reboot (xbreboot.exe) を使用してコンソールを再起動します。

サンドボックスが正しくリセットされたことを確認します。 コマンド プロンプトで「xbconfig sandboxid」と入力します。

## <a name="sign-in-with-a-development-account"></a>開発アカウントでサインインする

サインインに使用される開発アカウントを作成する[Xbox 開発者ポータル (XDP)](https://xdp.xboxlive.com/User/Contact/MyAccess?selectedMenu=devaccounts)または[パートナー センター](https://partner.microsoft.com/dashboard)
