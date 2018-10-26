---
title: 新しいクリエーターズ タイトルを作成し、テストする
author: KevinAsgari
description: 新しい Xbox Live クリエーターズ プログラム向けのタイトルを作成し、テスト環境に公開する方法について説明します。
ms.assetid: ced4d708-e8c0-4b69-aad0-e953bfdacbbf
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター, テスト
ms.localizationpriority: medium
ms.openlocfilehash: 1e51364ee87ee592420c88ac5808d24d010cfa25
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5666139"
---
# <a name="create-a-new-xbox-live-creators-program-title-and-publish-to-the-test-environment"></a>新しい Xbox Live クリエーターズ プログラム向けのタイトルを作成し、テスト環境に公開する

## <a name="introduction"></a>はじめに

Xbox Live コードを記述する前に、サービス構成ポータルで、新しいタイトルをセットアップする必要があります。  サービス構成について詳しくは、「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」をご覧ください。

この記事では、Windows デベロッパー センターでのタイトルの構成、新しいプロジェクトの作成、テストに向けた Xbox Live の準備に必要なすべての手順を説明します。 この記事では、以下を前提としています。

1. Xbox Live クリエーターズ プログラムを使用している。
2. ユニバーサル Windows プラットフォーム (UWP) のタイトルを開発している。  UWPのタイトルは、Xbox One、Windows 10 デスクトップ PC、およびモバイルで実行できるタイトルです。
3. Windows デベロッパー センターでタイトルを構成する[http://dev.windows.com/](http://dev.windows.com)します。  判断がつかない場合は、Windows デベロッパー センターをご利用ください。
4. 開発用コンピュータが Windows 10 を実行している。

> [!NOTE]
> Xbox Live クリエーターズ プログラムに参加している場合は、上記の前提条件が適用されますので、この記事に従ってください。

## <a name="dev-center-setup"></a>デベロッパー センターのセットアップ

Xbox Live の機能を使うための前提条件として、[Windows デベロッパー センター](http://dev.windows.com)で作成した Xbox Live 対応のタイトルが必要です。

### <a name="create-a-microsoft-account"></a>Microsoft アカウントを作成する
Microsoft アカウント (MSA とも呼ばれます) をお持ちでない場合は、最初に [Microsoft アカウントのサインイン ページ](https://go.microsoft.com/fwlink/p/?LinkID=254486)でアカウントを作成する必要があります。 Office 365 アカウントをお持ちの場合は、Outlook.com を使用してください。または Xbox Live アカウントをお持ちの場合は、既に MSA を持っている可能性があります。

### <a name="register-as-an-app-developer"></a>アプリ開発者として登録する
デベロッパー センターで新しいタイトルを作成できるようにするには、アプリ開発者として登録する必要があります。

登録するには、[アプリ開発者として登録](https://developer.microsoft.com/store/register)し、サインアップ プロセスに従ってください。

### <a name="create-a-new-uwp-title"></a>新しい UWP タイトルを作成する
デベロッパー センターで UWP タイトルを定義する必要があります。 これを実行するには、まず [Windows デベロッパー センター ダッシュボード](https://developer.microsoft.com/dashboard/)に移動します。

次に、新しいタイトルを作成します。 名前を予約する必要があります。

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
ゲーム用の Xbox Live 構成に変更を加える場合、それらの変更が Xbox Live の残りの部分によって取得されてゲームで表示されるようにするには、変更を特定の環境に公開する必要があります。

ゲームに対する作業を継続している間は、独自の開発サンドボックスに公開します。  開発サンドボックスでは、分離された環境でゲームへの変更に取り組むことができます。

ゲームを一般向けにリリースすると、Xbox Live 構成は自動的に RETAIL サンドボックスに公開されます。

既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスになっています。

### <a name="publish-xbox-live-configuration-to-the-test-environment"></a>Xbox Live 構成をテスト環境に公開する

Xbox Live サービスを有効にした後で Xbox Live サービス構成に変更を加えた場合は必ず、変更を有効にするために、これらの変更を開発サンドボックスに公開する必要があります。

現在の Xbox Live 構成を開発サンドボックスに公開するには、Xbox Live 構成ページで **[テスト]** ボタンをクリックします。

![](../images/creators_udc/creators_udc_xboxlive_config_test.png)

### <a name="authorize-devices-and-users-for-the-development-sandbox"></a>開発サンドボックス用にデバイスとユーザーを承認する

開発サンドボックス内のゲームの Xbox Live 構成には、承認済みのデバイスとユーザーのみがアクセスできます。

既定では、デベロッパー センター アカウントに追加したすべての Xbox One 開発機本体が開発サンドボックスにアクセスできます。  Xbox One 本体を追加するには、[Xbox One 本体の管理のページ](https://partner.microsoft.com/XboxDevices)に移動します。 既にデベロッパー センター アカウントにサインインしている場合は、**[アカウント設定]** > **[アカウント設定]** > **[Dev devices] (開発デバイス)** > **[Xbox One development consoles] (Xbox One 開発機本体)** の順に移動できます。

通常の Xbox Live アカウントに開発サンドボックスへのアクセスを承認することもできます。  Xbox Live アカウントに開発サンドボックスへのアクセスを承認するには、[アカウントの管理のページ](https://developer.microsoft.com/xboxtestaccounts/configurecreators)に移動します。

## <a name="next-steps"></a>次の手順
これで新しいタイトルが作成されたので、次はゲーム エンジン、Visual Studio、任意のビルド環境で Xbox Live 対応のタイトルをセットアップできます。

「[Xbox Live を統合するためのステップ バイ ステップ ガイド](creators-step-by-step-guide.md)」をご覧ください
