---
title: Xbox Live SDK の新規事項 - September 2015
author: KevinAsgari
description: Xbox Live SDK の新規事項 - September 2015
ms.assetid: 84b82fde-f6f3-4dc2-b2df-c7c7313a2cc3
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: cf5908dface210a1baffc18876fb349441618745
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5692110"
---
# <a name="whats-new-for-the-xbox-live-sdk---september-2015"></a>Xbox Live SDK の新規事項 - September 2015

August 2015 リリースで追加された内容については、「[新規事項 - August 2015](1508-whats-new.md)」を参照してください。

Xbox Live SDK の September リリースには以下の更新が含まれています。

## <a name="os-and-tool-support"></a>OS とツールのサポート ##
Xbox Live SDK では、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされます。

## <a name="contextual-search-apis"></a>コンテキスト検索 API
* タイトルやアプリケーションが、選択したリアルタイム統計情報を使ってゲームのブロードキャストを検索できるようにします。
* Microsoft::Xbox::Services::ContextualSearch の新しい API をご覧ください

## <a name="app-insights-for-events"></a>イベントの App Insights

| 注 |
|------|
| App Insights は、UWP タイトルにのみ適用されます。  XDK タイトルを開発している場合、このセクションは適用されません |

<p/>

* write_in_game_event() を使って書き込まれたイベントは、AppInsights を使って表示できます
* これに関するドキュメントは今後公開される予定です。それまでの間、DAM を使ってアクセスしてください

## <a name="logging"></a>ログ記録
* service_call_logging_config in xbox::services::experimental
* 起動し、本体で xbTrace.exe を通じてトレースを停止して、theservice_call_logging_config クラスで register_for_protocol_activation を呼び出すがあります。  この呼び出しは、ゲームの初期化中に 1 回行います。

## <a name="resync-for-rta"></a>RTA の再同期
* ユーザー情報が古い可能性があると RTA サービスが判断した場合、再同期が行われることがあります。
* タイトルは、サブスクライブしているサブスクリプションの対応する HTTP 呼び出しを呼び出す必要があります。
* タイトルが再サブスクライブする必要はありません
* xbox::services::real_time_activity_service::add_resync_handler が追加されました
* xbox::services::real_time_activity_service::remove_resync_handler が削除されました
* http_status_429_too_many_requests が追加されました
* このエラー状況は、送信した http 要求が多すぎるためにタイトルのスロットリングが発生しているときに見られます

## <a name="documentation"></a>ドキュメント
* Xbox Live Services API 2.0 への移行
* エラー処理
* Windows 10 での Xbox Live 認証
* コンテキスト検索
