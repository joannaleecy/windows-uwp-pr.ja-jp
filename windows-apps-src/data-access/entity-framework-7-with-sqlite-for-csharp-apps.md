---
author: normesta
ms.assetid: BC7E8130-A28A-443C-8D7E-353E7DA33AE3
description: "Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。"
title: "C# アプリのための Entity Framework Core と SQLite"
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, SQLite, C#, EF, Entity Framework
ms.openlocfilehash: 9d447b8a197ed7eaea0f991749064912dffb66d7
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
---
# <a name="entity-framework-core-with-sqlite-for-c-apps"></a>C# アプリのための Entity Framework Core と SQLite

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。 この記事では、ユニバーサル Windows アプリで SQLite データベースと共に Entity Framework Core を使う方法について説明します。

本来 .NET 開発者向けの Entity Framework Core は、ドメイン固有のオブジェクトを使ってリレーショナル データを格納したり操作したりするために、SQLite と共にユニバーサル Windows プラットフォーム (UWP) で使用できます。 .NET アプリから UWP アプリに EF コードを移行して、接続文字列に対する適切な変更と連携させることができます。

現在 EF は、UWP での SQLite のみをサポートしています。 Entity Framework Core のインストールとモデル作成の詳しいチュートリアルについては、[ユニバーサル Windows プラットフォームの概要に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=735013)をご覧ください。 次のトピックについて説明しています。

-   前提条件
-   新しいプロジェクトの作成
-   Entity Framework のインストール
-   モデルの作成
-   データベースの作成
-   モデルの使用
