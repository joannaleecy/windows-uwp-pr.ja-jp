---
title: Xbox Live クリエーターズ向けステップ バイ ステップ ガイド
description: クリエーターズ プログラム向けに Xbox Live を統合するための手順に関するガイドラインについて説明します。
ms.assetid: 7f9d093e-479a-4ad4-9965-a4ea6f0b2ac3
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター
ms.localizationpriority: medium
ms.openlocfilehash: ae02fe412e6300ac74b3f1106cdf6a5bb304d36b
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8796575"
---
# <a name="step-by-step-guide-to-integrate-xbox-live-creators-program"></a>Xbox Live クリエーターズ プログラムを統合するためのステップ バイ ステップ ガイド

このセクションは、Xbox Live でタイトルを開始し実行する際に役立ちます。

## <a name="1-ensure-you-have-a-title-created-in-partner-center"></a>1. パートナー センターで作成されたタイトルがあることを確認します。
すべての Xbox Live タイトルは、サインインし、Xbox Live サービスを呼び出すことができます前に、[パートナー センター](https://partner.microsoft.com/dashboard)で定義する必要があります。  これを行う方法は、「[新しいクリエーターズ タイトルの作成](create-and-test-a-new-creators-title.md)」で説明します。

## <a name="2-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a>2. 適切なガイドに従って、IDE やゲーム エンジンをセットアップする
プラットフォームやエンジンに関する適切なファースト ステップ ガイドに従い、それに沿って学習することで、Xbox Live の基本を習得することができます。

* [Visual Studio を使用してクリエーターズ タイトルの開発](develop-creators-title-with-visual-studio.md)では、パートナー センターで Xbox Live 構成を Visual Studio プロジェクトをリンクする方法を説明します。

* 「[Unity を使用してクリエーターズ タイトルを開発する](develop-creators-title-with-unity.md)」では、Xbox Live 対応の新しい Unity タイトルを作成する方法、ランキングなどの機能をタイトルに追加する方法、およびネイティブの Visual Studio プロジェクトを生成する方法について説明します。

## <a name="3-xbox-live-concepts"></a>3. Xbox Live の概念
タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。

- [Xbox Live のテスト環境](../xbox-live-sandboxes.md)
- [Xbox Live アカウントを承認する](authorize-xbox-live-accounts.md)

## <a name="4-add-xbox-live-features"></a>4. Xbox Live の機能を追加する

Xbox Live の機能をゲームに追加します。

- [Xbox Live ソーシャル プラットフォーム - プロフィール、フレンド、プレゼンス](../social-platform/social-platform.md)
- [Xbox Live データ プラットフォーム - 統計、ランキング、実績](../data-platform/data-platform.md)
- [Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ](../storage-platform/storage-platform.md)

## <a name="5-release-your-title"></a>5. タイトルをリリースする

Xbox Live クリエーターズ プログラムを使用している場合、このリリースのプロセスは他の UWP のリリースとまったく同じです。  プロセスについて詳しくは、「[Windows アプリを公開する](https://developer.microsoft.com/en-us/store/publish-apps)」をご覧ください。
