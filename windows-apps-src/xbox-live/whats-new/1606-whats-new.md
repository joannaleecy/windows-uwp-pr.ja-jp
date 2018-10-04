---
title: Xbox Live SDK の新規事項 - June 2016
author: KevinAsgari
description: Xbox Live SDK の新規事項 - June 2016
ms.assetid: 306e7fa8-14f0-437f-a991-6693f5c0d6a8
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: c7101dd5cb5e481c1ccfb03e6f33f759196bbd1d
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4352904"
---
# <a name="whats-new-for-the-xbox-live-sdk---june-2016"></a>Xbox Live SDK の新規事項 - June 2016

April 2016 リリースで追加された内容については、「[新規事項 - April 2016](1604-whats-new.md)」を参照してください。

> **注:** Xbox 開発キット (XDK) を使用している場合、「*新規事項 - April 2016*」で、March XDK リリース以降に追加された新しい機能について説明しています。

## <a name="os-and-tool-support"></a>OS とツールのサポート
Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。

## <a name="contextual-search"></a>コンテキスト検索
`contextual_search` API に、ゲーム クリップを取得するための新しいクラスが以下のとおり追加されました。

* `contextual_search_game_clip`
* `contextual_search_game_clip_stat`
* `contextual_search_game_clip_thumbnail`
* `contextual_search_game_clip_uri_info`
* `contextual_search_game_clips_result`

詳細については、リファレンス ドキュメントを参照してください。

## <a name="networking"></a>ネットワーキング
単一のタイトル インスタンスでユーザーあたり 5 つ以上の WebSocket が作成された場合に、そのことを検出する新しいアサートが Xbox Live SDK に追加されました。

このアサートは、`disable_asserts_for_maximum_number_of_websockets_activated()` を呼び出すことによって無効化できます。

> **注:** Social Manager および Multiplayer Manager では、タイトルでこれらの機能を使用する場合、単一の結合された WebSocket を使用します。

## <a name="tools"></a>ツール
* Xbox Live Resiliency Plugin For Fiddler が Xbox Live SDK に含まれるようになりました。  
これは Fiddler のアドオンであり、デベロッパーが Xbox Live の呼び出しを選択的にブロックできるようにします。
デベロッパーはこのプラグインを使用して、ゲーム タイトルの部分的なサービス中断における回復性をテストすることができます。
ツールには、多数の Xbox Live サービス エンドポイントの組み込みと、テスト対象のさまざまなエラー タイプが含まれています。
すべての Xbox One および UWP タイトルがサポートされています。
