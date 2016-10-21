---
author: mcleblanc
ms.assetid: BC7E8130-A28A-443C-8D7E-353E7DA33AE3
description: "Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。"
title: "C# アプリでの Entity framework 7 と SQLite"
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: b453a2a6c3ab0b9418122ae27bf6a3a1c56e5873

---

# C# アプリでの Entity framework 7 と SQLite

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。 この記事では、ユニバーサル Windows アプリで SQLite データベースと共に Entity Framework 7 を使う方法について説明します。

本来 .NET 開発者向けの Entity Framework 7 は、ドメイン固有のオブジェクトを使ってリレーショナル データを格納したり操作したりするために、SQLite と共にユニバーサル Windows プラットフォーム (UWP) で使用できます。 .NET アプリから UWP アプリに EF コードを移行して、接続文字列に対する適切な変更と連携させることができます。

現在 EF は、UWP での SQLite のみをサポートしています。 Entity Framework 7 のインストールとモデル作成の詳しいチュートリアルについては、[ユニバーサル Windows プラットフォームの概要に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=735013)をご覧ください。 次のトピックについて説明しています。

-   前提条件
-   新しいプロジェクトの作成
-   Entity Framework のインストール
-   モデルの作成
-   データベースの作成
-   モデルの使用




<!--HONumber=Aug16_HO3-->


