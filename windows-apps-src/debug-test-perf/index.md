---
author: PatrickFarley
ms.assetid: 16976d00-1564-49fe-81ad-2568e25e9e41
title: デバッグ、テスト、パフォーマンス
description: Microsoft Visual Studio とその他のツールを使ってデバッグしアプリをテストして、Microsoft Store の認定プロセスを準備します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e2a919af3cb532ce19427967f305cb03adc149a1
ms.sourcegitcommit: 2c4daa36fb9fd3e8daa83c2bd0825f3989d24be8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5517846"
---
# <a name="debugging-testing-and-performance"></a>デバッグ、テスト、パフォーマンス


このセクションでは、Microsoft Visual Studio を使用して、デバッグ、テスト、およびアプリを最適化する方法を示します。 (デバイスの監視と構成の) 用 Windows Device Portal や、Windows アプリ認定キット (アプリを準備する、Microsoft Store 向け) などのツールも含まれています。

| トピック | 説明 |
|-------|-------------|
| [UWP アプリの展開とデバッグ](deploying-and-debugging-uwp-apps.md) | この記事では、さまざまな展開およびデバッグのターゲットを指定する手順について説明します。 |
| [プロセス ライフタイム管理 (PLM) のテスト ツールとデバッグ ツール](testing-debugging-plm.md) | アプリとプロセス ライフタイム管理がどのように連携するかをデバッグしてテストするためのツールと手法を紹介します。 |
| [Microsoft Emulator for Windows 10 Mobile を使ったテスト](test-with-the-emulator.md) | Microsoft Emulator for Windows 10 Mobile に用意されているツールを使って、デバイスでの実際の操作をシミュレートし、アプリの機能をテストします。 エミュレーターは、Windows 10 を実行するモバイル デバイスをエミュレートするデスクトップ アプリケーションです。 このアプリケーションを使用すると、仮想化された環境が提供されるため、物理デバイスを使用せずに Windows アプリのデバッグとテストを実行できます。 また、アプリケーションのプロトタイプのための隔離環境としても使用できます。 |
| [Visual Studio を使った Surface Hub アプリのテスト](test-surface-hub-apps-using-visual-studio.md) | Visual Studio シミュレーターは、ユニバーサル Windows プラットフォーム (UWP) アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Microsoft Surface Hub 用に作成されたアプリを含みます。 シミュレーターでは、Surface Hub と同じユーザー インターフェイスは使用できませんが、Surface Hub の画面サイズと解像度でのアプリの外観と動作をテストするために有用です。 |
| [ルーズ ファイルの登録によるアプリを展開します。](loose-file-registration.md) | このガイドでは、ルーズ ファイルのレイアウトの検証し、Windows 10 アプリをパッケージ化することがなく共有を使用する方法を示します。 |
| [ベータ テスト](beta-testing.md) | **ベータ テスト**を行うと、まだリリースされていないアプリをアプリ開発チームの外部の人に自分のデバイスで試してもらい、その人たちからのフィードバックに基づいてアプリを改善することができます。 |
| [Windows Device Portal](device-portal.md) | Windows Device Portal では、ネットワーク経由でリモートから、または USB 接続によって、デバイスの構成と管理を行えます。 |
| [Windows アプリ認定キット](windows-app-certification-kit.md) | アプリに、Microsoft Store で公開されているの最適な機会を提供したり、Windows が認定の検証し認定のために提出する前にローカルでテストします。 このトピックでは、Windows アプリ認定キットのインストール方法と実行方法について説明します。 |
| [パフォーマンス](performance-and-xaml-ui.md) | ユーザーは、高い応答性と自然な使用感、そしてバッテリーが消耗しないことをアプリに期待しています。 技術的には、パフォーマンスは機能要件ではありませんが、パフォーマンスを機能として扱うことで、ユーザーの期待に沿うことができます。 鍵となる要因は、目標の明確化と測定の実施です。 パフォーマンスが重要なシナリオを決定し、優れたパフォーマンスとは何を意味するかを定義します。 次に、プロジェクトの初期とライフサイクル全体で十分な回数の測定を行って、目標を達成できることを確認します。 |
| [バージョン アダプティブ アプリ](version-adaptive-apps.md) | 最新の API と機能を活用する一方で、可能な限り幅広いユーザーに対応します。 ランタイム API チェックを使うと、アプリが実行されている Windows 10 のバージョンに基づき、そのバージョンで利用可能な機能に合わせてコードと XAML を実行時に調整できます。 |
