---
author: Mtoepke
title: "Xbox One の UWP"
description: "Xbox One でユニバーサル Windows プラットフォーム (UWP) アプリを構築する方法。"
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 2d935f53-84db-4108-86dc-cb6a0749782f
ms.openlocfilehash: 82c8fd0945ed49f8accf5e101acfbea151caa3a1
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="uwp-on-xbox-one"></a>Xbox One の UWP

Xbox One でユニバーサル Windows プラットフォーム (UWP) 向けのアプリの構築を始めましょう。

Xbox One の UWP は、アプリ開発とゲーム開発の両方をサポートします。 Xbox でゲームやアプリを実験、作成、テストするために、開発者プログラムに参加する必要はありません。 Xbox One でゲームを公開し、販売する場合や、Windows 10 で Xbox Live を活用する場合は、参加する必要があります、[Xbox Live Creators プログラム](https://developer.microsoft.com/games/xbox/xboxlive/creator)に参加するか、[ID@Xbox](http://www.xbox.com/Developers/id) 開発者として登録する必要があります。 詳しくは、「[開発者プログラムの概要](https://developer.microsoft.com/games/xbox/docs/xboxlive/get-started/developer-program-overview.html)」をご覧ください。

このセクションでは、設定方法、承認手順のガイド、必要なバージョンの Visual Studio と Windows 10 ツールをインストールする方法、および簡単なアプリケーションを初めて構築、実行、デバッグする手順を説明します。 

| トピック      | 説明 |
|------------|-------------|
|[概要](getting-started.md)| Xbox One での UWP の開発の概要を説明します。 |
|[新機能](whats-new.md)| Xbox One の UWP の新機能について説明します。 |
|[Xbox ベスト プラクティス](tailoring-for-xbox.md)| マウス モードを無効にする方法、画面の端に描画する方法、スケーリングを無効にする方法について説明します。 |
|[既知の問題](known-issues.md)| Xbox One の UWP の既知の問題について説明します。 |
|[FAQ](frequently-asked-questions.md)| Xbox One の UWP に関してよく寄せられる質問です。 |
|[Xbox One 開発者モードのアクティブ化](devkit-activation.md)| Xbox One で開発者モードを有効にする方法について説明します。 |
|[ツール](introduction-to-xbox-tools.md)| Xbox One 固有のツールである _Dev Home_ の概要、Windows Device Portal の使い方、開発用の Visual Studio の設定方法について説明します。 また、このセクションでは、新しい開発者向けに初めての Xbox UWP アプリケーションを使って指針を示すと共に、Fiddler ツールを使用してネットワーク トラフィックを表示する方法について説明します。 |
|[Xbox の開発環境に UWP を設定する](development-environment-setup.md)| Xbox One の開発環境を設定してテストする手順について説明します。 |
|[Xbox One 上の UWP アプリとゲームのシステム リソース](system-resource-allocation.md)| アプリケーションが Xbox One で実行されている場合に利用できるリソースについて説明します。 | 
|[Xbox およびテレビ向け設計](..\input-and-devices\designing-for-tv.md)| テレビに表示して、コントローラーを使って入力するアプリを設計するための、ベスト プラクティスについて説明します。 |  
|[マルチ ユーザー アプリケーションの概要](multi-user-applications.md)| Xbox One での複数ユーザーのアプリケーション (MUA) について説明します。 |
|[サンプル](samples.md)| GitHub の場所 (TVHelpers) へのポインターです。TVHelpers には Xbox の開発を始めるのに役立つ、XAML と JavaScript のサンプルが掲載されています。 サンプルには、XAML メディア アプリの完全なテンプレート、自動コントローラー ナビゲーション、リッチ メディアの再生、Web ベース テクノロジの検索などが含まれています。 |
|[既存のゲームの Xbox への移行](development-lanes-landing.md)|ゲームを構築する際の基礎となるテクノロジに基づいて、UWP を使用した Xbox へのゲームの移行プロセスを迅速に処理するための詳しい手順について説明します。|
|[Xbox One で開発者モードを無効にする](devkit-deactivation.md)| Xbox One で開発者モードを無効にする方法について説明します。 |
|[Xbox One でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/p/?LinkId=760755)|  Xbox One でまだ完全に機能していない UWP 機能について説明します。|  

## <a name="see-also"></a>関連項目
- [Xbox One の UWP アプリの概要](http://go.microsoft.com/fwlink/p/?LinkId=780786) 
- [Windows 10 UWP アプリの自動起動](automate-launching-uwp-apps.md)
- [ゲーム開発用の CPUSets](cpusets-games.md)
  
