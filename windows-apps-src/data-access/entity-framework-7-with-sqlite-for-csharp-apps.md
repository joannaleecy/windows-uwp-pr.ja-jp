---
author: mcleblanc
ms.assetid: BC7E8130-A28A-443C-8D7E-353E7DA33AE3
description: "Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。"
title: "C# アプリのための Entity Framework Core と SQLite"
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, SQLite, C#, EF, Entity Framework
ms.openlocfilehash: 015030774c7d148d3a9be757c80de827987347a9
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
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
