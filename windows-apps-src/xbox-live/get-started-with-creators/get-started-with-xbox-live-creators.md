---
title: Get started with Xbox Live Creators Program
author: KevinAsgari
description: Provides links to help you get started with the Xbox Live Creators Program.
ms.assetid: 2a744405-7ee4-42b4-8f36-9916e8c3a530
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one
ms.openlocfilehash: 84e23fa904412fd1cc9900943b67b8df849b57be
ms.sourcegitcommit: 5bd030abc783aa78575190fae93056ad1f560bb7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/08/2017
---
# <a name="get-started-with-the-xbox-live-creators-program"></a>Get started with the Xbox Live Creators Program
 
Xbox Live クリエーターズ プログラムを利用すると、概念の承認を経ることなく、簡便な認定プロセスで Xbox One や Windows 10 にゲームをすばやく直接公開できます。 ゲームが Xbox Live を統合していて、[標準のストア ポリシー](https://msdn.microsoft.com/en-us/library/windows/apps/dn764944.aspx)に準拠していれば、公開する準備は完了です。 この記事では、ゲームに Xbox Live を統合するために必要な手順の概要を示します。 

Xbox Live クリエーターズ プログラムのゲームは、ユニバーサル Windows プラットフォーム (UWP) アプリケーションでなければなりません。 Xbox One については、「[Xbox One の UWP](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index)」と、特に「[Xbox One 上の UWP アプリとゲームのシステム リソース](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)」をご覧ください。 Xbox Live クリエーターズ プログラムを通じて公開したゲームは、実績サービスやオンライン マルチプレイヤー サービスにアクセスできません。 サポートされるサービスの一覧については、「開発者プログラムの概要」の「[機能表](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/developer-program-overview#feature-table)」をご覧ください。

## <a name="1-ensure-you-have-a-title-created-on-dev-center"></a>1. デベロッパー センターでタイトルが作成されていることを確認する
Every Xbox Live title must be defined on Dev Center before you will be able to sign-in and make Xbox Live Service calls.  これを行う方法は、「[新しいクリエーターズ タイトルの作成](create-and-test-a-new-creators-title.md)」で説明します。

## <a name="2-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a>2. 適切なガイドに従って IDE やゲーム エンジンをセットアップする
プラットフォームやエンジンに応じた適切な "ファースト ステップ ガイド" に従い、それに沿って学習することで、Xbox Live の基本を習得することができます。

* [Develop a Creators title with Visual Studio](develop-creators-title-with-visual-studio.md) will show you how to link your Visual Studio project with your Xbox Live configuration on Dev Center.
* 「[Unity を使用してクリエーターズ タイトルを開発する](develop-creators-title-with-unity.md)」では、Xbox Live 対応の新しい Unity ゲームを作成する方法、単一ユーザーとマルチユーザーのサインインを処理する方法、ランキングや統計などの機能を追加する方法、ネイティブの Visual Studio プロジェクトを生成する方法について説明します。

## <a name="3-xbox-live-concepts--testing"></a>3. Xbox Live の概念とテスト
タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。 サポートするすべてのプラットフォームでゲームをテストして、期待どおりに動作することを確認することも重要です。

- [クリエーターズ プログラムの Xbox Live サービス構成](xbox-live-service-configuration-creators.md)
- [Xbox Live のテスト環境](../xbox-live-sandboxes.md)
- [Xbox Live アカウントを承認する](authorize-xbox-live-accounts.md)

## <a name="4-enable-xbox-live-sign-in"></a>4. Xbox Live サインインを有効にする
Xbox Live クリエーターズ プログラムのゲームはすべて、Xbox Live サインインを統合し、ユーザー ID (ゲーマータグ、ゲーマー アイコンなど) を表示する必要があります。 ユーザーを自動的にサインインさせるか、ユーザーがボタンを押してからサインインを開始するかを選択できます。 いったんサインインしたら、正しいプロフィールを使っていることをプレイヤーが確認できるように、ゲーマータグを表示する必要があります。

- [Xbox Live ソーシャル プラットフォーム - プロフィール、フレンド、プレゼンス](../social-platform/social-platform.md)

## <a name="5-add-optional-xbox-live-features"></a>5. オプションの Xbox Live の機能を追加する

Xbox Live クリエーターズ プログラムには、ゲームの販売を促進し、ゲーマーの関心を引き付けておくために設計された一連の機能が用意されています。

- [Xbox Live データ プラットフォーム - 統計、ランキング](../data-platform/data-platform.md)を利用すると、ゲーマーがフレンドに勝ってランクを上げることが可能になり、ゲームに対するユーザーの関心を高めることができます。
- [Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ](../storage-platform/storage-platform.md)では、デバイス間でゲームのセーブ データを無料でローミングでき、ゲーマーは Xbox One と Windows PC の間で簡単にゲームの進行を継続できます。
- [Xbox Live ソーシャル プラットフォーム - プロフィール、フレンド、プレゼンス](../social-platform/social-platform.md)を使用すると、ゲーマーはフレンドと接続してゲームについて会話することができます。

ただし、Xbox Live クリエーターズ プログラムでは、オンライン マルチプレイヤー、実績、ゲーマースコアがサポートされない点に注意が必要です。

## <a name="6-release-your-game"></a>6. ゲームをリリースする

Xbox Live クリエーターズ プログラムを使っている場合、このプロセスは他の UWP アプリケーションをリリースするプロセスとまったく同じです。

- [Windows ストア ポリシー](https://msdn.microsoft.com/en-us/library/windows/apps/dn764944.aspx) ([ゲームと Xbox のポリシー](https://msdn.microsoft.com/en-us/library/windows/apps/dn764944.aspx#pol_10_13)を含む)
- [Windows アプリを公開する](https://developer.microsoft.com/en-us/store/publish-apps)