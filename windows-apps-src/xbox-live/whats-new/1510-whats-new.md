---
title: Xbox Live SDK の新規事項 - October 2015
author: KevinAsgari
description: Xbox Live SDK の新規事項 - October 2015
ms.assetid: 052be4aa-5f18-4eb7-ba5f-80c5f5cab6f2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: b8a8612aa97f92a1651feb6db547bb76a398d15d
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4683071"
---
# <a name="whats-new-for-the-xbox-live-sdk---october-2015"></a>Xbox Live SDK の新規事項 - October 2015

September 2015 リリースで追加された内容については、「[新規事項 - September 2015](1509-whats-new.md)」を参照してください。


## <a name="os-and-tool-support"></a>OS とツールのサポート
Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。

## <a name="social-manager"></a>Social Manager
* Social Manager は、Xbox Live Social API を簡単に使用できるようにするためのものです。  ユーザーのソーシャル グラフをインテリジェントにキャッシュし、より単純な API などを提供します。  詳細についてはドキュメントを参照してください。

## <a name="samples"></a>サンプル
* API の使い方がわかる新しい Social Manager サンプルがあります。

## <a name="tools"></a>ツール
* Xbox Live Trace Analyzer が Xbox Live SDK に含まれるようになりました。  「[Xbox Live サービスへの呼び出しを分析する](../tools/analyze-service-calls.md)」の説明に従ってトレースを収集した後、Live Trace Analyzer を実行して、繰り返されている呼び出しや呼び出しの頻度などについての統計情報を見ることにより、タイトルでの Xbox Live の使用方法が最適であることを確認します。

## <a name="bug-fixes"></a>バグ修正
* HTTP ソケット操作の既定のタイムアウトが、5 分から 30 秒に変更されました。  タイトル ストレージのアップロードやダウンロードの呼び出しのような時間のかかる HTTP ソケット操作については、タイムアウトは 5 分のままになっています。

## <a name="documentation"></a>ドキュメント
* Social Manager の概要が追加されました
* Multiplayer Manager の概要が更新されました
