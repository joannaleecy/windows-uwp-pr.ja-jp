---
title: Xbox Live クリエーターズ プログラムの概要
description: Xbox Live クリエーターズ プログラムの利用を始める際に役立つリンクを紹介します。
ms.assetid: 2a744405-7ee4-42b4-8f36-9916e8c3a530
ms.date: 12/13/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cce9d34679884d48475b7a7ae0fa8286204a6289
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57615877"
---
# <a name="get-started-with-the-xbox-live-creators-program"></a>Xbox Live クリエーターズ プログラムの概要
 
Xbox Live クリエーターズ プログラムを利用すると、概念の承認を経ることなく、簡便な認定プロセスで Xbox One や Windows 10 にゲームをすばやく直接公開できます。 ゲームが Xbox Live を統合していて、[標準のストア ポリシー](https://msdn.microsoft.com/en-us/library/windows/apps/dn764944.aspx)に準拠していれば、公開する準備は完了です。 この記事では、ゲームに Xbox Live を統合するために必要な手順の概要を示します。 

Xbox Live クリエーターズ プログラムのゲームは、ユニバーサル Windows プラットフォーム (UWP) アプリケーションでなければなりません。 Xbox One については、「[Xbox One の UWP](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index)」と、特に「[Xbox One 上の UWP アプリとゲームのシステム リソース](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)」をご覧ください。 Xbox Live クリエーターズ プログラムを通じて公開したゲームは、実績サービスやオンライン マルチプレイヤー サービスにアクセスできません。 サポートされるサービスの一覧については、「開発者プログラムの概要」の「[機能表](https://docs.microsoft.com/en-us/windows/uwp/xbox-live/developer-program-overview#feature-table)」をご覧ください。

## <a name="1-ensure-you-have-a-title-created-in-partner-center"></a>1. パートナー センターで作成したタイトルがあることを確認します。
Xbox Live のすべてのタイトルを定義する必要があります[パートナー センター](https://partner.microsoft.com/dashboard)前に、サインインし、Xbox Live サービスを呼び出すことができます。  これを行う方法は、「[新しいクリエーターズ タイトルの作成](create-and-test-a-new-creators-title.md)」で説明します。

## <a name="2-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a>2. IDE、ゲーム エンジンを設定する適切なガイドに従ってください。
プラットフォームやエンジンに応じた適切な "ファースト ステップ ガイド" に従い、それに沿って学習することで、Xbox Live の基本を習得することができます。

* [Visual Studio を使用した Creators タイトルを開発](develop-creators-title-with-visual-studio.md)はパートナー センターで、Xbox Live の構成と、Visual Studio プロジェクトをリンクする方法を説明します。
* 「[Unity を使用してクリエーターズ タイトルを開発する](develop-creators-title-with-unity.md)」では、Xbox Live 対応の新しい Unity ゲームを作成する方法、単一ユーザーとマルチユーザーのサインインを処理する方法、ランキングや統計などの機能を追加する方法、ネイティブの Visual Studio プロジェクトを生成する方法について説明します。

Unity はゲーム エンジンのドキュメントを提供されていますのみのサード パーティ ゲーム エンジン[コンストラクト (2 & 3)](https://www.scirra.com/construct2)と[ゲームのメーカー Studio](https://www.yoyogames.com/gamemaker)も Xbox Live を統合するためにドキュメントがあります。それぞれ、コンス トラクターやゲームのメーカー Studio ゲームです。

* [ゲームのメーカー Studio 2 UWP ようになりました Xbox Live クリエーターズ プログラム](https://www.yoyogames.com/gamemaker/xblc)は Xbox One と Windows 10 PC 上で再生するゲーム メーカー Studio プロジェクトをエクスポートする方法を説明します。
* [UWP アプリ - コンストラクトで Xbox Live を使用して](https://www.scirra.com/tutorials/9540/using-xbox-live-in-uwp-apps)は、Construct 2 と 3 つのゲームの Xbox Live を使用する方法を説明します。

文書化されている Xbox Live の統合のないゲーム開発エン ジンがその他、タイトルに Xbox Live を追加するのに Xbox Live Api を使用することもできます。 プロジェクトから Xbox Live API を使用するには、NuGet パッケージを使ってバイナリへの参照を追加するか、API ソースを追加します。 NuGet パッケージを追加するとコンパイルが高速になりますが、ソースを追加するとデバッグが簡単になります。

サポートの Unity ではないサード パーティのゲーム エンジンで Xbox Live サービスを使用する場合、質問に回答するための適切なゲーム エンジン スタッフを使用します。

## <a name="3-xbox-live-concepts--testing"></a>3.Xbox Live の概念とテスト
タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。 サポートするすべてのプラットフォームでゲームをテストして、期待どおりに動作することを確認することも重要です。

- [クリエイターズ プログラムのサービス構成の Xbox Live](xbox-live-service-configuration-creators.md)
- [テスト環境の Xbox Live](../xbox-live-sandboxes.md)
- [Xbox Live アカウントを承認します。](authorize-xbox-live-accounts.md)

## <a name="4-enable-xbox-live-sign-in"></a>4。Xbox Live サインインを有効にします。
Xbox Live クリエーターズ プログラムのゲームはすべて、Xbox Live サインインを統合し、ユーザー ID (ゲーマータグ、ゲーマー アイコンなど) を表示する必要があります。 ユーザーを自動的にサインインさせるか、ユーザーがボタンを押してからサインインを開始するかを選択できます。 いったんサインインしたら、正しいプロフィールを使っていることをプレイヤーが確認できるように、ゲーマータグを表示する必要があります。

- [Xbox Live ソーシャル プラットフォームのプロファイル、友人、プレゼンス](../social-platform/social-platform.md)

## <a name="5-add-optional-xbox-live-features"></a>5。Xbox Live の省略可能な機能を追加します。

Xbox Live クリエーターズ プログラムには、ゲームの販売を促進し、ゲーマーの関心を引き付けておくために設計された一連の機能が用意されています。

- [Xbox Live データ プラットフォーム - 統計、ランキング](../data-platform/data-platform.md)を利用すると、ゲーマーがフレンドに勝ってランクを上げることが可能になり、ゲームに対するユーザーの関心を高めることができます。
- [Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ](../storage-platform/storage-platform.md)では、デバイス間でゲームのセーブ データを無料でローミングでき、ゲーマーは Xbox One と Windows PC の間で簡単にゲームの進行を継続できます。
- [Xbox Live ソーシャル プラットフォーム - プロフィール、フレンド、プレゼンス](../social-platform/social-platform.md)を使用すると、ゲーマーはフレンドと接続してゲームについて会話することができます。

ただし、Xbox Live クリエーターズ プログラムでは、オンライン マルチプレイヤー、実績、ゲーマースコアがサポートされない点に注意が必要です。

## <a name="6-release-your-game"></a>6。ゲームをリリースします。

Xbox Live クリエーターズ プログラムを使っている場合、このプロセスは他の UWP アプリケーションをリリースするプロセスとまったく同じです。

- [Microsoft Store ポリシー](https://msdn.microsoft.com/en-us/library/windows/apps/dn764944.aspx)など[ゲームと Xbox のポリシー](https://msdn.microsoft.com/en-us/library/windows/apps/dn764944.aspx#pol_10_13)
- [Windows アプリを発行します。](https://developer.microsoft.com/en-us/store/publish-apps)