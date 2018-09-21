---
title: Xbox 開発機本体を構成する
author: KevinAsgari
description: Xbox Live の開発をサポートするように Xbox 開発機本体を構成する方法について説明します。
ms.assetid: f8fd1caa-b1e9-4882-a01f-8f17820dfb55
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 53126e185b9d94c911abab8999e3ca1da8691c7c
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4085894"
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

想定していたサンドボックスでない場合は、サンドボックス ID を変更します。コマンド プロンプトで、「xbconfig sandboxid=<your sandbox id>」と入力します。

コマンド プロンプトで Reboot (xbreboot.exe) を使用してコンソールを再起動します。

サンドボックスが正しくリセットされたことを確認します。 コマンド プロンプトで「xbconfig sandboxid」と入力します。

## <a name="sign-in-with-a-development-account"></a>開発アカウントでサインインする

サインインに使用する開発アカウントは、[Xbox デベロッパー ポータル (XDP)](https://xdp.xboxlive.com/User/Contact/MyAccess?selectedMenu=devaccounts) または [Windows デベロッパー センター](https://developer.microsoft.com/en-us/windows)で作成できます。
