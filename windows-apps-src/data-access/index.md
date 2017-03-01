---
author: mcleblanc
ms.assetid: 76776b0f-3163-48c9-835b-3f4213968079
title: "データ アクセス"
description: "このセクションでは、デバイス上のデータをプライベート データベースに保存する方法と、ユニバーサル Windows プラットフォーム (UWP) アプリでオブジェクト リレーショナル マッピングを使う方法について説明します。"
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, データ, データベース, リレーショナル, テーブル, sqlite"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 0f7aff1c9e7354fcf92d24ed8acb88b41a23d377
ms.lasthandoff: 02/07/2017

---
# <a name="data-access"></a>データ アクセス

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

このセクションでは、デバイス上のデータをプライベート データベースに保存する方法と、ユニバーサル Windows プラットフォーム (UWP) アプリでオブジェクト リレーショナル マッピングを使う方法について説明します。

SQLite は UWP SDK に付属しています。 Entity Framework 7 は、UWP アプリで SQLite を操作します。 これらのテクノロジを使って、オフラインのシナリオや断続的な接続のシナリオ向けに開発を行い、アプリのセッション間でデータを保持します。

| トピック | 説明|
|-------|------------|
| [C# アプリでの Entity framework 7 と SQLite](entity-framework-7-with-sqlite-for-csharp-apps.md) | Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。 この記事では、ユニバーサル Windows アプリで SQLite データベースと共に Entity Framework 7 を使う方法について説明します。 |
| [SQLite データベース](sqlite-databases.md) | SQLite は、サーバーを使わない埋め込みデータベース エンジンです。 この記事では、SDK に付属している SQLite ライブラリを使って、独自の SQLite ライブラリをユニバーサル Windows アプリにパッケージ化する方法、およびソースから SQLite ライブラリを構築する方法について説明します。 |

