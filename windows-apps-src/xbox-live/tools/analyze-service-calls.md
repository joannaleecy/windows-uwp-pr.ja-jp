---
title: Xbox Live Trace Analyzer
author: KevinAsgari
description: Xbox Live Trace Analyzer を使ってタイトルにより行われるサービス呼び出しを確認する方法について説明します。
ms.assetid: b4490fae-d554-403d-bbbc-601af38af0ef
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, サービス呼び出し, テスト, trace analyzer
ms.localizationpriority: medium
ms.openlocfilehash: 196505a9ed3fb62ef609415c292e98850588102f
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4390687"
---
# <a name="xbox-live-trace-analyzer"></a>Xbox Live Trace Analyzer

Xbox Live Services API では、タイトル デベロッパーがすべてのサービス呼び出しをキャプチャーし、呼び出しパターンに違反がないかオフラインで分析できるようになりました。 サービス呼び出しトレースをアクティベーションするには、xbtrace コマンド ライン ツールで利用できる新しい機能を使用するか、またはより高度なシナリオ向けのプロトコル アクティベーションを使用します。 また、タイトル コードから直接サービス呼び出しトレースをアクティベーションすることもできます。 Xbox Live ツール パッケージの一部として Xbox Live Trace Analyzer (XBLTraceAnalyzer.exe) と呼ばれるオフライン分析ツールが見つかりません[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools)します。


## <a name="gather-logs-and-analyze-the-service-calls"></a>ログの収集とサービス呼び出しの分析

サービス呼び出しの記録を含むログを収集し、Xbox Live Trace Analyzer を使用してそれらを分析するために必要な手順は以下のとおりです。

1.  Xbox 開発キット (XDK) の July 2015 以降に含まれているバージョンの Xbox Live Services API を使用してタイトルをビルドします。
2.  後述の説明に従って、タイトルを変更してトレースを有効にします。
3.  タイトルを配置します。
4.  タイトルを起動して、Xbox Live Services API を初期化するために Xbox Live サービスを少なくとも 1 回呼び出します。
5.  タイトル内の分析したいポイントからトレースを開始します。
6.  トレースを停止します。
7.  開発用 PC で Xbox Live Trace Analyzer ツールを実行し、出力を確認します。

## <a name="starting-and-stopping-tracing"></a>トレースの開始と停止

トレースを開始および停止するには以下の 3 つの方法があります。

1.  一連の Xbox Live Services API をタイトルから直接呼び出す。
2.  *xbtrace* コマンド ライン ツールを使用する。
3.  *アプリケーション管理 (xbapp.exe)* コマンド ライン ツールを通じてプロトコル アクティベーションを使用する。


### <a name="starting-and-stopping-tracing-directly-from-your-title"></a>タイトルから直接トレースを開始および停止する

タイトルから直接トレースを開始および停止するには、次の手順に従います。

1.  `Microsoft::Xbox::Services::Experimental` 名前空間で、`EnableServiceCallTracking` クラスの `ServiceCallTrackerSettings` プロパティを true に設定します。
2.  `StartServiceCallTracking()` を呼び出して、サービス呼び出しトレースを開始します。
3.  `StopServiceCallTracking()` を呼び出して、サービス呼び出しトレースを停止します。
4.  トレースの停止後、Xbox Live Trace Analyzer を使用して分析するために、*ファイル コピー (xbcp.exe)* または *Xbox One Neighborhood* を使用して、結果のトレース ファイルを本体のデベロッパー スクラッチ ドライブから PC にコピーします。

### <a name="starting-and-stopping-tracing-by-using-the-xbtrace-command-line-tool"></a>xbtrace コマンド ライン ツールを使用してトレースを開始および停止する

トレースを開始する最も簡便な方法は、トレースの種類に xboxliveservices を指定して xbtrace コマンド ライン ツールを使用することです。 xbTrace を使用する場合、結果のトレース ファイルは自動的に PC にコピーされます。

xbtrace によるトレースの開始と停止はプロトコル アクティベーションに依存します。 xbtrace を使用してトレースを開始および停止する前に、`RegisterForProtcolActivation` クラスで `ServiceCallTrackerSettings` メソッドを呼び出してプロトコル アクティベーションを初期化する必要があります。

次の例は、xbTrace を使用して Xbox Live サービスのトレースを開始および停止する方法を示しています。

    xbtrace start xboxliveservices
    xbtrace stop


xbtrace でトレースを開始および停止するには、タイトルが実行されており、プロトコル アクティベーションが初期化されている必要があることを忘れないでください。 トレースの停止後、xbtrace によってトレース ファイルが開発用 PC にコピーされ、"xbtrace" とタイムスタンプを含む名前のディレクトリに配置されます。 このディレクトリの名前は、xbtrace の \[etlfile\] オプションを使用して変更することができます。

<a name="starting-and-stopping-tracing-by-using-protocol-activation"></a>プロトコル アクティベーションを使用してトレースを開始および停止する
----------------------------------------------------------

"xbApp launch" のプロトコル アクティベーション機能を使用してトレースを制御することもできます。 プロトコル アクティベーションを通じてトレースを開始および停止するには、タイトルの titleid がわかっている必要があります。 titleid はタイトルのマニフェスト ファイル内にあります。 "serviceCallTracking" パラメーターを含む URI を通じてトレースを制御できます。 次の例は、titleid が 12345678 のタイトルのトレースを開始および停止する方法を示しています。

    xbapp launch "ms-xbl-12345678://serviceCallTracking?state=start"
    xbapp launch "ms-xbl-12345678://serviceCallTracking?state=stop"

プロトコル アクティベーションを使用する場合、結果のトレース ファイルは本体のデベロッパー スクラッチ ドライブに保存されます。 そのファイルを、xbcp または Xbox One Neighborhood を使用して PC にコピーする必要があります。 xbtrace を使用する場合のようにファイルが自動的に PC にコピーされることはありません。

プロトコル アクティベーションでは、verbosity などの追加のトレース パラメーターを設定できます。 verbosity には quiet、diagnostic、detailed、minimal の 4 つのレベルを設定できます。 次の例は、verbosity のレベルを設定する方法を示しています。

    xbapp launch "ms-xbl-12345678://serviceCallTracking?verbosity=diagnostic"

## <a name="analyze-the-trace-file"></a>トレース ファイルを分析する

トレース ファイルが PC にコピーされたら、GNDP の Xbox Live Trace Analyzer ツールを使用して、タイトルでの Xbox Live サービスの使用状況を分析できます。 Xbox Live Trace Analyzer ツールを呼び出してその出力を解釈する方法の詳細については、Game Developer Network でこのツールに付属するドキュメントを参照してください。 また、コマンド ライン オプションの -?  または -h を指定して XBLTraceAnalyzer.exe を実行することによって、コマンド ライン ヘルプを参照することもできます。
