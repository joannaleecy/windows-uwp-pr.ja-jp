---
title: Xbox Live SDK の新規事項 - February 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - February 2016
ms.assetid: 7ff34ea4-f07d-4584-98e4-13977994ccca
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: c59e4f1940f507a1fcb43743171fa79ffbcefd8c
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5970950"
---
# <a name="whats-new-for-the-xbox-live-sdk---february-2016"></a>Xbox Live SDK の新規事項 - February 2016

1510 で追加された内容については、「[新規事項 - October 2015](1510-whats-new.md)」の記事を参照してください。

## <a name="os-and-tool-support"></a>OS とツールのサポート
Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。

## <a name="throttling"></a>抑制 (スロットリング)
- 間もなくほとんどの Xbox Live サービスに、きめ細かなスロットリングが導入される予定です。  Xbox Service API (XSAPI) が再試行を自動的に処理し、開発中にスロットリングされている呼び出しについて通知します。  詳細については、ドキュメントの記事「[ベスト プラクティス: Xbox Live の呼び出し](../using-xbox-live/best-practices/best-practices-for-calling-xbox-live.md)」を参照してください。

## <a name="leaderboards"></a>スコアボード
- GetLeaderboard API によって複数列のランキングにアクセスできます。 追加する列の名前のベクトルを指定した場合、それらの列が存在する場合、結果では列のベクトルに内容が格納されます。

## <a name="documentation"></a>ドキュメント
- [Application Insights](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/event-driven-data-platform/application-insights) のドキュメントが提供されています。  無料の Azure アカウントで Application Insights を使って、ほぼリアルタイムにデータ プラットフォームのイベントを表示できます。  この機能は現在、デスクトップの Windows 10 上で実行されている UWP アプリケーションに対してのみ使うことができます。
- データ プラットフォーム イベントを送信するためのラッパーを生成する方法について説明している、UWP デベロッパーに向けた Xbox 共通イベント ツールのドキュメントが更新されました。  これは任意であり、WriteInGameEvent API を引き続き使うこともできます。
- Fiddler を使ってデータ プラットフォーム イベントをデバッグすることに関する情報が提供されています。このツールを使って、それらのイベントが正常に送信されていることを確認してください。  このツールは UWP イベント専用です。
- Live トレース分析ツールのためにログを収集する方法に関する情報が提供されています。  「[Xbox Live サービスへの呼び出しを分析する](../tools/analyze-service-calls.md)」をご覧ください。
