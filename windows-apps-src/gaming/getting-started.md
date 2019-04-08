---
title: 概要
description: ゲーム開発の学習ガイド
ms.assetid: 40490837-6c7f-4f82-96b5-14f6858982b3
ms.date: 01/25/2018
ms.topic: article
keywords: windows 10、uwp、ゲーム、作業の開始
localizationpriority: medium
ms.openlocfilehash: f818837a6f8703721520a8be8c0ed9b062cf797a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653557"
---
# <a name="getting-started"></a>概要

この記事では、ファースト ステップ ガイドでは、Windows、Xbox のゲームの開発を希望する作成者用です。 

必要な情報を探すのに役立ついくつかの質問を次に示します。
* すべての詳細が必要し、する、経験豊富なゲーム開発者ですか。 参照してください、 [Windows 10 ゲームの開発ガイド](e2e.md)します。
* コーディングにまったく新しいですか。 ような何か楽しい、[コードのチュートリアルの Minecraft 時間](https://code.org/minecraft)関心のある可能性があります。
* 優れたゲームをプレイする探しだけですか。 チェック アウト、 [Microsoft Store](https://www.microsoft.com/store)します。
* Windows または Xbox 向けの優れたゲームの開発を開始する準備ができてですか。  適切な場所にできました。

## <a name="quick-start-guide"></a>クイック スタート ガイド

ゲームの開発をすぐに取得する手順を実行します。

### <a name="step-1-get-the-software-and-tools"></a>手順 1:ソフトウェアとツールを取得します。

最新を Windows 10 のデバイスにインストールして確認します。 更新プログラムをインストールします。

Visual Studio などの適切な IDE をインストールします。 Visual Studio Community 2017 では無償でダウンロードします。 詳細については、次を参照してください。 [Visual Studio のダウンロード](https://www.visualstudio.com/downloads/)します。

ゲーム エンジンとその他のミドルウェアを使用する場合は「[ブリッジ、ゲーム エンジン、およびミドルウェア](e2e.md#bridges-game-engines-and-middleware)セクション、 [Windows 10 ゲームの開発ガイド](e2e.md)します。 特定のゲーム エンジンを使用して Windows と Xbox のゲームの開発については、ゲーム エンジンのドキュメントに移動する必要があります。

### <a name="step-2-prepare-your-hardware-for-development"></a>手順 2:開発用にハードウェアを準備します。

初めて開発を実行している場合は、デバイスで開発者モードを有効にする必要があります。 詳細については、次を参照してください。[開発用にデバイスを有効にする](../get-started/enable-your-device-for-development.md)します。

ユーザーにとって、製品版の Xbox コンソールを使用して、Xbox ゲームを開発しようとしている、する必要もありますをアクティブ化し、これで開発者モードを有効にします。 詳細については、次を参照してください。 [Xbox 開発者モードは 1 つのアクティブ化](../xbox-apps/devkit-activation.md)と[Xbox で UWP アプリ開発入門](../xbox-apps/getting-started.md)します。 

> [!Note]
> サインアップする必要があります、[パートナー センター](https://partner.microsoft.com/dashboard)アカウントを Xbox コンソールで開発者モードを有効にすることができます。 パートナー センター アカウントにサインアップする詳細については、次を参照してください。[手順 5](#step-5-sign-up-for-a-partner-center-account)以下。

### <a name="step-3-run-a-sample-and-see-how-it-works"></a>手順 3:サンプルを実行して、そのしくみを参照してください。

UWP の DirectX の開発を開始するを参照してください。 [UWP の簡単なゲームを DirectX を使った作成](tutorial--create-your-first-uwp-directx-game.md)です。 読み取り、どのようなバッファーは DirectX の概念について理解してを参照してくださいにする場合[Direct3D グラフィックス概念](../graphics-concepts/index.md)します。

その他のサンプルを参照してください。[サンプルのゲーム](e2e.md#game-samples)します。

### <a name="step-4-consider-joining-a-program"></a>手順 4:プログラムに参加を検討してください。

Xbox ゲームを開発またはゲームの Xbox Live の機能を使用する場合は、いずれかの参加、 [Xbox Live クリエーターズ プログラム](https://developer.microsoft.com/games/xbox/xboxlive/creator)または[ ID@Xbox ](https://www.xbox.com/Developers/id)プログラム。 

各プログラムに使用できる Xbox Live の機能の詳細については、次を参照してください。[機能テーブル](../xbox-live/developer-program-overview.md#feature-table)します。 詳細については、次を参照してください。[開発者プログラム](e2e.md#developer-programs)します。

> [!Note]
> Xbox Live クリエーターズ プログラムは、すべての開発者が利用できます。 **すべてのユーザー** Xbox ゲームを公開することができます。 Xbox Live クリエーターズ プログラムのタイトル部分をするためは、単に、パートナー センターからこのオプションを有効にする必要があります。 パートナー センター アカウントにサインアップする詳細については、次を参照してください。[手順 5](#step-5-sign-up-for-a-partner-center-account)以下。

### <a name="step-5-sign-up-for-a-partner-center-account"></a>手順 5:パートナー センター アカウントにサインアップします。

パートナー センター アカウントへのアクセスを提供する[パートナー センター](https://partner.microsoft.com/dashboard)、管理し、すべてのアプリと 1 つの場所で Windows デバイス用のゲームを送信することができます。

Windows のゲーム開発のゲームに Xbox Live の機能を使用する場合またはパートナー センターにアクセスするまで待機することができます。

Xbox のゲーム開発の必要がありますへのサインアップ、パートナー センター アカウントの開発、retail Xbox を設定する必要があるよう。 参照してください[手順 2.](#step-2-prepare-your-hardware-for-development)詳細についてはします。

詳細については、次を参照してください。[発行の Windows アプリやゲーム](../publish/index.md)します。

## <a name="useful-links"></a>役に立つリンク

* [Windows 10 ゲーム開発ガイド](e2e.md)
* [UWP アプリとは](../get-started/universal-application-platform-guide.md)
* [UWP ゲーム向けクラウド サービスを使用します。](cloud-for-games.md)
* [ゲームにアクセスできるように](accessibility-for-games.md)