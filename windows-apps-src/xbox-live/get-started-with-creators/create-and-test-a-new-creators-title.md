---
title: "新しいクリエーターズ タイトルを作成し、テストする"
author: KevinAsgari
description: "新しい Xbox Live クリエーターズ プログラム向けのタイトルを作成し、テスト環境に公開する方法について説明します。"
ms.assetid: ced4d708-e8c0-4b69-aad0-e953bfdacbbf
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター, テスト"
ms.openlocfilehash: 4b8fbba80d2151fef62c91d91c2e6cdb60d06710
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="create-a-new-xbox-live-creators-program-title-and-publish-to-the-test-environment"></a>新しい Xbox Live クリエーターズ プログラム向けのタイトルを作成し、テスト環境に公開する

## <a name="introduction"></a>はじめに

コードを記述する前に、サービス構成ポータルで、新しいタイトルをセットアップする必要があります。  サービス構成について詳しくは、「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」をご覧ください。

この記事では、新しいタイトルをセットアップする手順について説明します。前提条件は以下のとおりです。

1. Xbox Live クリエーターズ プログラムを使用している。
2. ユニバーサル Windows プラットフォーム (UWP) のタイトルを開発している。  UWPのタイトルは、Xbox One、Windows 10 デスクトップ PC、およびモバイルで実行できるタイトルです。
3. タイトルを、[http://dev.windows.com/](http://dev.windows.com) の Windows デベロッパー センターで構成している。  判断がつかない場合は、Windows デベロッパー センターをご利用ください。
4. 開発用コンピュータは Windows 10 を実行している。

上記の前提条件を満たしていることを想定し、この記事の残りの部分で、Windows デベロッパー センターでのタイトルの構成、新しいプロジェクトの作成、Xbox Live サインイン コードの記述とテストに必要なすべての手順を説明します。

> **注**: Xbox Live クリエーターズ プログラムに参加している場合は、上記の前提条件が適用されますので、この記事に従ってください。

## <a name="dev-center-setup"></a>デベロッパー センターのセットアップ

Xbox Live の機能が動作するための前提条件として、[Windows デベロッパー センター](http://dev.windows.com)で作成した Xbox Live 対応のタイトルが必要です。

### <a name="create-a-microsoft-account"></a>Microsoft アカウントを作成する
Microsoft アカウント (MSA とも呼ばれます) をお持ちでない場合は、最初に [https://go.microsoft.com/fwlink/p/?LinkID=254486](https://go.microsoft.com/fwlink/p/?LinkID=254486) でアカウントを作成する必要があります。  Office 365 アカウントをお持ちの場合は、Outlook.com を使用してください。または Xbox Live アカウントをお持ちの場合は、既に MSA を持っている可能性があります。

### <a name="register-as-an-app-developer"></a>アプリ開発者として登録する
デベロッパー センターで新しいタイトルを作成できるようにするには、アプリ開発者として登録する必要があります。

登録するには、[https://developer.microsoft.com/ja-jp/store/register](https://developer.microsoft.com/en-us/store/register) にアクセスし、サインアップ プロセスに従ってください。

### <a name="create-a-new-uwp-title"></a>新しい UWP タイトルを作成する
次に、デベロッパー センターで定義されている UWP タイトルが必要です。  これを実行するには、まずダッシュ ボードに移動します

![](../images/getting_started/first_xbltitle_dashboard.png)

<p>
</p>
<br>
<p>
</p>

ダッシュ ボードをクリックしてから、新しいタイトルを作成します。  名前を予約する必要があります。

![](../images/getting_started/first_xbltitle_newapp.png)

次に、アプリに関する *[アプリの概要]* ページが表示されます。  Xbox Live を構成するための主要なページは、以下に示すように [サービス] -> [Xbox Live] メニューにあります。

![](../images/getting_started/first_xbltitle_leftnav.png)

## <a name="enable-xbox-live-services"></a>Xbox Live サービスを有効にする
アプリの [サービス] の下にある [Xbox Live] リンクを初めてクリックすると、[Enable Xbox Live Creators Program] (Xbox Live クリエーターズ プログラムの有効化) ページが表示されます。  [有効化] ボタンをクリックすると、[有効化] ダイアログが表示されます。

![](../images/creators_udc/creators_udc_xboxlive_enable_page.png)

[有効化] ダイアログで、Xbox Live サービスを有効にするプラットフォームを選択します (Xbox One と Windows 10 PC の両方が既定で選択されています)。  [確認] ボタンをクリックして、ゲーム用に Xbox Live クリエーターズ プログラムを有効にします。

![](../images/creators_udc/creators_udc_xboxlive_enable_dialog.png)

## <a name="test-xbox-live-service-configuration-in-your-game"></a>ゲームで Xbox Live サービス構成をテストする
ゲーム用の Xbox Live 構成に変更を加える場合、それらの変更が Xbox Live の残りの部分によって取得されてゲームで表示されるようにするには、変更を特定の環境に公開する必要があります。

ゲームに対する作業を継続している間は、独自の開発サンドボックスに公開します。  開発サンドボックスでは、分離された環境でゲームへの変更に取り組むことができます。

ゲームを一般向けにリリースする場合は、Xbox Live 構成を RETAIL サンドボックスに公開します。

既定では、Xbox One 本体と Windows 10 PC は RETAIL サンドボックスに格納されます。

### <a name="authorize-devices-and-users-for-the-development-sandbox"></a>開発サンドボックス用にデバイスとユーザーを承認する

開発サンドボックス内のゲームの Xbox Live 構成には、承認済みのデバイスとユーザーのみがアクセスできます。

既定では、デベロッパー センター アカウントに追加したすべての Xbox One 開発機本体が開発サンドボックスにアクセスできます。  Xbox One 本体を追加するには、[https://developer.microsoft.com/ja-jp/XboxDevices](https://developer.microsoft.com/en-us/XboxDevices) にアクセスしてください。

通常の Xbox Live アカウントに開発サンドボックスへのアクセスを承認することもできます。  Xbox Live アカウントに開発サンドボックスへのアクセスを承認するには、[https://developer.microsoft.com/ja-jp/xboxtestaccounts/configurecreators](https://developer.microsoft.com/en-us/xboxtestaccounts/configurecreators) にアクセスしてください。

![](../images/creators_udc/creators_udc_testing_with_retail_accounts.png)

### <a name="publish-xbox-live-configuration-to-the-test-environment"></a>Xbox Live 構成をテスト環境に公開する

Xbox Live サービスを有効にした後で Xbox Live サービス構成に変更を加えた場合は必ず、変更を有効にするために、これらの変更を開発サンドボックスに公開する必要があります。

Xbox Live 構成ページで、[テスト] ボタンをクリックして、現在の Xbox Live 構成を開発サンドボックスに公開します。

![](../images/creators_udc/creators_udc_xboxlive_config_test.png)

## <a name="next-steps"></a>次の手順
これで新しいタイトルが作成されたので、次はゲーム エンジン、Visual Studio、任意のビルド環境で Xbox Live 対応のタイトルをセットアップできます。

「[Xbox Live を統合するためのステップ バイ ステップ ガイド](creators-step-by-step-guide.md)」をご覧ください
