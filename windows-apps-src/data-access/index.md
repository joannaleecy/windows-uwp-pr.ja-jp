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
# <a name="data-access"></a><span data-ttu-id="345fe-104">データ アクセス</span><span class="sxs-lookup"><span data-stu-id="345fe-104">Data access</span></span>

<span data-ttu-id="345fe-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="345fe-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="345fe-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="345fe-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="345fe-107">このセクションでは、デバイス上のデータをプライベート データベースに保存する方法と、ユニバーサル Windows プラットフォーム (UWP) アプリでオブジェクト リレーショナル マッピングを使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="345fe-107">This section discusses storing data on the device in a private database and using object relational mapping in Universal Windows Platform (UWP) apps.</span></span>

<span data-ttu-id="345fe-108">SQLite は UWP SDK に付属しています。</span><span class="sxs-lookup"><span data-stu-id="345fe-108">SQLite is included in the UWP SDK.</span></span> <span data-ttu-id="345fe-109">Entity Framework Core は、UWP アプリで SQLite を操作します。</span><span class="sxs-lookup"><span data-stu-id="345fe-109">Entity Framework Core works with SQLite in UWP apps.</span></span> <span data-ttu-id="345fe-110">これらのテクノロジを使って、オフラインのシナリオや断続的な接続のシナリオ向けに開発を行い、アプリのセッション間でデータを保持します。</span><span class="sxs-lookup"><span data-stu-id="345fe-110">Use these technologies to develop for offline / intermittent connectivity scenarios, and to persist data across app sessions.</span></span>

| <span data-ttu-id="345fe-111">トピック</span><span class="sxs-lookup"><span data-stu-id="345fe-111">Topic</span></span> | <span data-ttu-id="345fe-112">説明</span><span class="sxs-lookup"><span data-stu-id="345fe-112">Description</span></span>|
|-------|------------|
| [<span data-ttu-id="345fe-113">C# アプリのための Entity Framework Core と SQLite</span><span class="sxs-lookup"><span data-stu-id="345fe-113">Entity framework Core with SQLite for C# apps</span></span>](entity-framework-7-with-sqlite-for-csharp-apps.md) | <span data-ttu-id="345fe-114">Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。</span><span class="sxs-lookup"><span data-stu-id="345fe-114">Entity Framework (EF) is an object-relational mapper that enables you to work with relational data using domain-specific objects.</span></span> <span data-ttu-id="345fe-115">この記事では、ユニバーサル Windows アプリで SQLite データベースと共に Entity Framework Core を使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="345fe-115">This article explains how you can use Entity Framework Core with a SQLite database in a Universal Windows app.</span></span> |
| [<span data-ttu-id="345fe-116">SQLite データベース</span><span class="sxs-lookup"><span data-stu-id="345fe-116">SQLite databases</span></span>](sqlite-databases.md) | <span data-ttu-id="345fe-117">SQLite は、サーバーを使わない埋め込みデータベース エンジンです。</span><span class="sxs-lookup"><span data-stu-id="345fe-117">SQLite is a server-less, embedded database engine.</span></span> <span data-ttu-id="345fe-118">この記事では、SDK に付属している SQLite ライブラリを使って、独自の SQLite ライブラリをユニバーサル Windows アプリにパッケージ化する方法、およびソースから SQLite ライブラリを構築する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="345fe-118">This article explains how to use the SQLite library included in the SDK, package your own SQLite library in a Universal Windows app, or build it from the source.</span></span> |
