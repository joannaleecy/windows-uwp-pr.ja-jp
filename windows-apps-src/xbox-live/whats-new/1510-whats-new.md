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
ms.localizationpriority: low
ms.openlocfilehash: 374955dd4cbb200d19d08f01535869cfbc3d14e7
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
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
