---
title: Create and test a new Creators title
author: KevinAsgari
description: Learn how to create a new Xbox Live Creators Program title and publish to the test environment.
ms.assetid: ced4d708-e8c0-4b69-aad0-e953bfdacbbf
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, creators, test
ms.openlocfilehash: 0ba9b34ed229b9c7f59ef78711126980540059d7
ms.sourcegitcommit: b185729f0bb73569740d03be67dff9f59a4c4968
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/01/2017
---
# <a name="create-a-new-xbox-live-creators-program-title-and-publish-to-the-test-environment"></a>Create a new Xbox Live Creators Program title and publish to the test environment

## <a name="introduction"></a>Introduction

Before writing any code, you must setup a new title on your service configuration portal.  You can learn more about service configuration in [Xbox Live Service Configuration](../xbox-live-service-configuration.md)

この記事では、Windows デベロッパー センターでのタイトルの構成、新しいプロジェクトの作成、テストに向けた Xbox Live の準備に必要なすべての手順を説明します。 この記事では、以下を前提としています。

1. Xbox Live クリエーターズ プログラムを使用している。
2. You are developing a Universal Windows Platform (UWP) title.  UWP titles can run on Xbox One, Windows 10 desktop PCs, and mobile
3. You are configuring your title on Windows Dev Center at [http://dev.windows.com/](http://dev.windows.com).  If in doubt, you should use Windows Dev Center.
4. 開発用コンピュータが Windows 10 を実行している。

> [!NOTE]
> Xbox Live クリエーターズ プログラムに参加している場合は、上記の前提条件が適用されますので、この記事に従ってください。

## <a name="dev-center-setup"></a>Dev Center setup

You need an Xbox Live enabled title created on [Windows Dev Center](http://dev.windows.com) as a pre-requisite to any Xbox Live functionality working.

### <a name="create-a-microsoft-account"></a>Create a Microsoft account
Microsoft アカウント (MSA とも呼ばれます) をお持ちでない場合は、最初に [Microsoft アカウントのサインイン ページ](https://go.microsoft.com/fwlink/p/?LinkID=254486)でアカウントを作成する必要があります。 If you have an Office 365 account, use Outlook.com, or have an Xbox Live account - you probably already have an MSA.

### <a name="register-as-an-app-developer"></a>Register as an App Developer
デベロッパー センターで新しいタイトルを作成できるようにするには、アプリ開発者として登録する必要があります。

登録するには、[アプリ開発者として登録](https://developer.microsoft.com/store/register)し、サインアップ プロセスに従ってください。

### <a name="create-a-new-uwp-title"></a>Create a new UWP title
デベロッパー センターで UWP タイトルを定義する必要があります。 これを実行するには、まず [Windows デベロッパー センター ダッシュボード](https://developer.microsoft.com/dashboard/)に移動します。

次に、新しいタイトルを作成します。 You'll need to reserve a name.

![](../images/getting_started/first_xbltitle_newapp.png)

次のスクリーンショットは、Xbox Live を構成するための主要なページを開く **[サービス]** >  **[Xbox Live]** メニューを示しています。

![](../images/creators_udc/creators_udc_xboxlive_page.png)

## <a name="enable-xbox-live-services"></a>Xbox Live サービスを有効にする
製品に対して **[サービス]** の下にある **[Xbox Live]** リンクを初めてクリックすると、[Enable Xbox Live Creators Program] (Xbox Live クリエーターズ プログラムの有効化) ページが表示されます。  次に、**[有効化]** ボタンをクリックして、Xbox Live のセットアップ ダイアログを表示します。

![](../images/creators_udc/creators_udc_xboxlive_enable.png)

セットアップ ダイアログで、Xbox Live サービスを有効にするプラットフォームを選択します (既定では Xbox One と Windows 10 PC の両方が選択されています)。  **[確認]** ボタンをクリックして、ゲーム用に Xbox Live クリエーターズ プログラムを有効にします。

> [!IMPORTANT]
> Xbox Live は、ゲームに対してのみサポートされます。 ゲームを Xbox Live で正常に公開するためには、申請のプロパティ セクションで、製品の種類を "ゲーム" に設定する必要があります。

![](../images/creators_udc/creators_udc_xboxlive_enable_dialog.png)

## <a name="test-xbox-live-service-configuration-in-your-game"></a>ゲームで Xbox Live サービス構成をテストする
When you make changes to the Xbox Live configuration for your game, you need to publish the changes to a specific environment before they are picked up by the rest of Xbox Live and can be seen by your game.

When you are still working on your game, you publish to your own development sandbox.  開発サンドボックスでは、分離された環境でゲームへの変更に取り組むことができます。

ゲームを一般向けにリリースすると、Xbox Live 構成は自動的に RETAIL サンドボックスに公開されます。

既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。

### <a name="authorize-devices-and-users-for-the-development-sandbox"></a>Authorize devices and users for the development sandbox

Only authorized devices and users can access the Xbox Live configuration for the game in your development sandbox.

既定では、デベロッパー センター アカウントに追加したすべての Xbox One 開発機本体が開発サンドボックスにアクセスできます。  Xbox One 本体を追加するには、[Xbox One 本体の管理のページ](https://developer.microsoft.com/XboxDevices)に移動します。 既にデベロッパー センター アカウントにサインインしている場合は、**[アカウント設定]** > **[アカウント設定]** > **[Dev devices] (開発デバイス)** > **[Xbox One development consoles] (Xbox One 開発機本体)** の順に移動できます。

通常の Xbox Live アカウントに開発サンドボックスへのアクセスを承認することもできます。  Xbox Live アカウントに開発サンドボックスへのアクセスを承認するには、[アカウントの管理のページ](https://developer.microsoft.com/xboxtestaccounts/configurecreators)に移動します。

### <a name="publish-xbox-live-configuration-to-the-test-environment"></a>Xbox Live 構成をテスト環境に公開する

Whenever you enable Xbox Live services and make changes to Xbox Live service configuration, to make the changes effective, you need to publish these changes to your development sandbox.

現在の Xbox Live 構成を開発サンドボックスに公開するには、Xbox Live 構成ページで **[テスト]** ボタンをクリックします。

![](../images/creators_udc/creators_udc_xboxlive_config_test.png)

## <a name="next-steps"></a>次の手順
Now that you have a new title created, you can now setup an Xbox Live enabled title in your Game Engine, Visual Studio or build environment of choice.

See [Step by step guide to integrate Xbox Live](creators-step-by-step-guide.md)
