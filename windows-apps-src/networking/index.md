---
author: DelfCo
ms.assetid: 7bb9fd81-8ab5-4f8d-a854-ce285b0669a4
description: "ネットワークと Web サービスにアクセスするためのテクノロジ。"
title: "ネットワークと Web サービス"
translationtype: Human Translation
ms.sourcegitcommit: 82edf9c3ee7f7303788b7a1272ecb261d3748c5a
ms.openlocfilehash: 03a5ce2b8d5f501d4254cbe0ee3d47f575775f7a

---

# ネットワークと Web サービス

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

ユニバーサル Windows プラットフォーム (UWP) 開発者は、次のネットワークと Web サービス テクノロジを利用できます。

| トピック                                                                                   | 説明                                                                      |
|-----------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
| [ネットワークの基本](networking-basics.md)                                               | ネットワーク対応アプリで実行する必要がある事柄について説明します。                     |
| [アプリに適したネットワーク テクノロジ](which-networking-technology.md)                          | UWP 開発者が利用できるネットワーク テクノロジの概要と、アプリに適したテクノロジを選ぶ方法に関する提案事項について説明します。               |
| [バックグラウンドでのネットワーク通信](network-communications-in-the-background.md) | アプリは、フォアグラウンドでないとき、バックグラウンド タスクと 2 つの主要なメカニズム (ソケット ブローカーとコントロール チャネル トリガー) を使って通信を維持します。                  |
| [ソケット](sockets.md)                                                                   | UWP アプリ開発者として、[Windows.Networking.Sockets](https://msdn.microsoft.com/library/windows/apps/xaml/windows.networking.sockets.aspx) と [Winsock](https://msdn.microsoft.com/library/windows/desktop/ms737523) の両方を使って他のデバイスと通信できます。 このトピックでは、Windows.Networking.Sockets 名前空間を使ってネットワーク操作を実行する方法の詳しいガイダンスを示します。 |
| [WebSocket](websockets.md)                                                             | WebSocket は、クライアントとサーバー間の高速でセキュリティ保護された双方向通信を、HTTP(S) を使った Web 経由で実行するためのメカニズムを提供します。                 |
| [HttpClient](httpclient.md)                                                             | HTTP 2.0 プロトコルと HTTP 1.1 プロトコルを使って情報を送受信するには、[Windows.Web.Http](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間 API を使います。             |
| [RSS/Atom フィード](web-feeds.md)                                                          | [Windows.Web.Syndication](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間の機能を利用し、RSS や Atom の標準に従って生成される概要フィードを使って、最新の人気の高い Web コンテンツを取得または作成します。                   |
| [バックグラウンド転送](background-transfers.md)                                         | ネットワーク経由でファイルを確実にコピーするには、バックグラウンド転送 API を使います。           |



<!--HONumber=Aug16_HO5-->


