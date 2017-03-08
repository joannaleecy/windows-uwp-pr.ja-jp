---
author: mcleblanc
ms.assetid: BC7E8130-A28A-443C-8D7E-353E7DA33AE3
description: "Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。"
title: "C# アプリのための Entity Framework 7 と SQLite"
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, SQLite, C#, EF, Entity Framework
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 2ab2a12f6c2bc2f0f8853b404afaf13bf80635b7
ms.lasthandoff: 02/07/2017

---

# <a name="entity-framework-core-1-with-sqlite-for-c-apps"></a>C# アプリのための Entity framework Core 1 と SQLite

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。 この記事では、ユニバーサル Windows アプリで SQLite データベースと共に Entity Framework Core 1 を使う方法について説明します。

本来 .NET 開発者向けの Entity Framework Core 1 は、ドメイン固有のオブジェクトを使ってリレーショナル データを格納したり操作したりするために、SQLite と共にユニバーサル Windows プラットフォーム (UWP) で使用できます。 .NET アプリから UWP アプリに EF コードを移行して、接続文字列に対する適切な変更と連携させることができます。

現在 EF は、UWP での SQLite のみをサポートしています。 Entity Framework Core 1 のインストールとモデル作成の詳しいチュートリアルについては、[ユニバーサル Windows プラットフォームの概要に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=735013)をご覧ください。 次のトピックについて説明しています。

-   前提条件
-   新しいプロジェクトの作成
-   Entity Framework のインストール
-   モデルの作成
-   データベースの作成
-   モデルの使用

