---
title: "ツール"
author: KevinAsgari
description: "Xbox Live 対応タイトルを開発およびテストするために用意されているツールについて説明します。"
ms.assetid: 380a29bf-41a7-4817-9c57-f48f2b824b52
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ツール"
ms.openlocfilehash: 0f41f81596ece36a03605ca58e5f521c036f4e0e
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="tools"></a>ツール

ここでは、Xbox Live を使用するときに便利な、さまざまなツールについて説明します。

[Xbox Live Trace Analyzer](analyze-service-calls.md)  
Xbox Live Services API では、タイトル デベロッパーがすべてのサービス呼び出しをキャプチャーし、呼び出しパターンに違反がないかオフラインで分析できるようになりました。 サービス呼び出しトレースをアクティベーションするには、xbtrace コマンド ライン ツールで利用できる新しい機能を使用するか、またはより高度なシナリオ向けのプロトコル アクティベーションを使用します。 また、タイトル コードから直接サービス呼び出しトレースをアクティベーションすることもできます。 Xbox Live Trace Analyzer (XBLTraceAnalyzer.exe) と呼ばれるオフライン分析ツールは Game Developer Network で入手できます。

[Xbox Live Account Tool](xbox-live-account-tool.md)   
Xbox Live Account Tool は、タイトル デベロッパーが既存のデベロッパー アカウントをゲーム シナリオのテスト用にセットアップするときに使用できるように作られています。 たとえば、Xbox Live Account Tool を使用すると、デベロッパー アカウントのゲーマータグを変更したり、アカウントのフレンド リストに 1000 人のフォロワーをすばやく追加したりできます。

[Xbox Live PowerShell モジュール](https://github.com/Microsoft/xbox-live-powershell-module/blob/master/docs/XboxLivePsModule.md)  
XboxlivePSModule には、Xbox Live 開発に役立つさまざまなユーティリティが含まれています。
* [PowerShell ギャラリー](https://www.powershellgallery.com/packages/XboxlivePSModule)からこのモジュールを使うには、PowerShell ウィンドウを開きます。
    1. 次のコマンドを実行して、モジュールをダウンロードしてインストールします。 `Install-Module XboxlivePSModule -Scope CurrentUser`
    2. 次のコマンドを実行して使用を開始します。 `Import-Module XboxlivePSModule`
    3. コマンドレット Set-XblSandbox XDKS.1、Get-XblSandbox を実行します。

* ダウンロードした zip ファイルを使うには、PowerShell ウィンドウを開きます。
    1. 以下のコマンドを実行します。 `Import-Module <path to unzipped folder>\XboxLivePsModule\XboxLivePsModule.psd1`
    2. コマンドレット Set-XblSandbox XDKS.1、Get-XblSandbox を実行します。

使用可能なコマンドレットと使用方法について詳しくは、[github](https://github.com/Microsoft/xbox-live-powershell-module/blob/master/docs/XboxLivePsModule.md) のオンライン ドキュメントをご覧ください。
