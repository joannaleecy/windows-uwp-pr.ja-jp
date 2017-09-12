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
# <a name="entity-framework-core-with-sqlite-for-c-apps"></a><span data-ttu-id="1e05a-104">C# アプリのための Entity Framework Core と SQLite</span><span class="sxs-lookup"><span data-stu-id="1e05a-104">Entity Framework Core with SQLite for C# apps</span></span>

<span data-ttu-id="1e05a-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="1e05a-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="1e05a-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="1e05a-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="1e05a-107">Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。</span><span class="sxs-lookup"><span data-stu-id="1e05a-107">Entity Framework (EF) is an object-relational mapper that enables you to work with relational data using domain-specific objects.</span></span> <span data-ttu-id="1e05a-108">この記事では、ユニバーサル Windows アプリで SQLite データベースと共に Entity Framework Core を使う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1e05a-108">This article explains how you can use Entity Framework Core with a SQLite database in a Universal Windows app.</span></span>

<span data-ttu-id="1e05a-109">本来 .NET 開発者向けの Entity Framework Core は、ドメイン固有のオブジェクトを使ってリレーショナル データを格納したり操作したりするために、SQLite と共にユニバーサル Windows プラットフォーム (UWP) で使用できます。</span><span class="sxs-lookup"><span data-stu-id="1e05a-109">Originally for .NET developers, Entity Framework Core can be used with SQLite on Universal Windows Platform (UWP) to store and manipulate relational data using domain specific objects.</span></span> <span data-ttu-id="1e05a-110">.NET アプリから UWP アプリに EF コードを移行して、接続文字列に対する適切な変更と連携させることができます。</span><span class="sxs-lookup"><span data-stu-id="1e05a-110">You can migrate EF code from a .NET app to a UWP app and expect it work with appropriate changes to the connection string.</span></span>

<span data-ttu-id="1e05a-111">現在 EF は、UWP での SQLite のみをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="1e05a-111">Currently EF only supports SQLite on UWP.</span></span> <span data-ttu-id="1e05a-112">Entity Framework Core のインストールとモデル作成の詳しいチュートリアルについては、[ユニバーサル Windows プラットフォームの概要に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=735013)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1e05a-112">A detailed walkthrough on installing Entity Framework Core, and creating models is available at the [Getting Started on Universal Windows Platform page](http://go.microsoft.com/fwlink/p/?LinkId=735013).</span></span> <span data-ttu-id="1e05a-113">次のトピックについて説明しています。</span><span class="sxs-lookup"><span data-stu-id="1e05a-113">It covers the following topics:</span></span>

-   <span data-ttu-id="1e05a-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="1e05a-114">Prerequisites</span></span>
-   <span data-ttu-id="1e05a-115">新しいプロジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="1e05a-115">Create a new project</span></span>
-   <span data-ttu-id="1e05a-116">Entity Framework のインストール</span><span class="sxs-lookup"><span data-stu-id="1e05a-116">Install Entity Framework</span></span>
-   <span data-ttu-id="1e05a-117">モデルの作成</span><span class="sxs-lookup"><span data-stu-id="1e05a-117">Create your model</span></span>
-   <span data-ttu-id="1e05a-118">データベースの作成</span><span class="sxs-lookup"><span data-stu-id="1e05a-118">Create your database</span></span>
-   <span data-ttu-id="1e05a-119">モデルの使用</span><span class="sxs-lookup"><span data-stu-id="1e05a-119">Use your model</span></span>
