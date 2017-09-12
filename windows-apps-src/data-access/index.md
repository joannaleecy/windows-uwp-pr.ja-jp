---
author: normesta
ms.assetid: 76776b0f-3163-48c9-835b-3f4213968079
title: "データ アクセス"
description: "このセクションでは、デバイス上のデータをプライベート データベースに保存する方法と、ユニバーサル Windows プラットフォーム (UWP) アプリでオブジェクト リレーショナル マッピングを使う方法について説明します。"
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, データ, データベース, リレーショナル, テーブル, sqlite"
ms.openlocfilehash: 19690b6877fb4304b7740e6098711ca0b097d567
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
---
# <a name="data-access"></a>データ アクセス

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

このセクションでは、デバイス上のデータをプライベート データベースに保存する方法と、ユニバーサル Windows プラットフォーム (UWP) アプリでオブジェクト リレーショナル マッピングを使う方法について説明します。

SQLite は UWP SDK に付属しています。 Entity Framework Core は、UWP アプリで SQLite を操作します。 これらのテクノロジを使って、オフラインのシナリオや断続的な接続のシナリオ向けに開発を行い、アプリのセッション間でデータを保持します。

| トピック | 説明|
|-------|------------|
| [C# アプリのための Entity Framework Core と SQLite](entity-framework-7-with-sqlite-for-csharp-apps.md) | Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。 この記事では、ユニバーサル Windows アプリで SQLite データベースと共に Entity Framework Core を使う方法について説明します。 |
| [SQLite データベース](sqlite-databases.md) | SQLite は、サーバーを使わない埋め込みデータベース エンジンです。 この記事では、SDK に付属している SQLite ライブラリを使って、独自の SQLite ライブラリをユニバーサル Windows アプリにパッケージ化する方法、およびソースから SQLite ライブラリを構築する方法について説明します。 |
