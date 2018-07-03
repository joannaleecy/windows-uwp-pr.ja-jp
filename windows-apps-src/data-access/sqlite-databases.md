---
author: normesta
title: UWP アプリでの SQLite データベースの使用
description: UWP アプリでの SQLite データベースの使用。
ms.author: normesta
ms.date: 06/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP, SQLite, データベース
ms.localizationpriority: medium
ms.openlocfilehash: 01cac3c1b8c18e968c35acb01b3d3918d9efe60d
ms.sourcegitcommit: ee77826642fe8fd9cfd9858d61bc05a96ff1bad7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/11/2018
ms.locfileid: "2018598"
---
# <a name="use-a-sqlite-database-in-a-uwp-app"></a><span data-ttu-id="eab99-104">UWP アプリでの SQLite データベースの使用</span><span class="sxs-lookup"><span data-stu-id="eab99-104">Use a SQLite database in a UWP app</span></span>
<span data-ttu-id="eab99-105">SQLite を使用すると、ユーザー デバイス上の軽量なデータベースにデータを保存し、取得することができます。</span><span class="sxs-lookup"><span data-stu-id="eab99-105">You can use SQLite to store and retrieve data in a light-weight database on the users device.</span></span> <span data-ttu-id="eab99-106">このガイドでその方法を示します。</span><span class="sxs-lookup"><span data-stu-id="eab99-106">This guide shows you how.</span></span>

## <a name="some-benefits-of-using-sqlite-for-local-storage"></a><span data-ttu-id="eab99-107">ローカル ストレージに SQLite を使用するメリット</span><span class="sxs-lookup"><span data-stu-id="eab99-107">Some benefits of using SQLite for local storage</span></span>

<span data-ttu-id="eab99-108">:heavy_check_mark: SQLite は軽量で自己完結型です。</span><span class="sxs-lookup"><span data-stu-id="eab99-108">:heavy_check_mark: SQLite is light-weight and self-contained.</span></span> <span data-ttu-id="eab99-109">その他の依存関係がないコード ライブラリです。</span><span class="sxs-lookup"><span data-stu-id="eab99-109">It's a code library without any other dependencies.</span></span> <span data-ttu-id="eab99-110">構成する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="eab99-110">There's nothing to configure.</span></span>

<span data-ttu-id="eab99-111">:heavy_check_mark: データベース サーバーがありません。</span><span class="sxs-lookup"><span data-stu-id="eab99-111">:heavy_check_mark: There's no database server.</span></span> <span data-ttu-id="eab99-112">クライアントとサーバーは、同じプロセスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="eab99-112">The client and the server run in the same process.</span></span>

<span data-ttu-id="eab99-113">:heavy_check_mark: SQLite はパブリック ドメインにあるため、アプリで自由に使用して配布できます。</span><span class="sxs-lookup"><span data-stu-id="eab99-113">:heavy_check_mark: SQLite is in the public domain so you can freely use and distribute it with your app.</span></span>

<span data-ttu-id="eab99-114">:heavy_check_mark: SQLite はプラットフォームやアーキテクチャにかかわらず動作します。</span><span class="sxs-lookup"><span data-stu-id="eab99-114">:heavy_check_mark: SQLite works across platforms and architectures.</span></span>

<span data-ttu-id="eab99-115">SQLite について詳しくは、[こちら](https://sqlite.org/about.html)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eab99-115">You can read more about SQLite [here](https://sqlite.org/about.html).</span></span>

## <a name="choose-an-abstraction-layer"></a><span data-ttu-id="eab99-116">アブストラクション レイヤーを選択する</span><span class="sxs-lookup"><span data-stu-id="eab99-116">Choose an abstraction layer</span></span>

<span data-ttu-id="eab99-117">Entity Framework Core またはオープン ソースの [SQLite ライブラリ](https://github.com/aspnet/Microsoft.Data.Sqlite/) (Microsoft が構築) を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="eab99-117">We recommend that you use either the Entity Framework Core or the open-source [SQLite library](https://github.com/aspnet/Microsoft.Data.Sqlite/) built by Microsoft.</span></span>

### <a name="entity-framework-core"></a><span data-ttu-id="eab99-118">Entity Framework Core</span><span class="sxs-lookup"><span data-stu-id="eab99-118">Entity Framework Core</span></span>

<span data-ttu-id="eab99-119">Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。</span><span class="sxs-lookup"><span data-stu-id="eab99-119">Entity Framework (EF) is an object-relational mapper that you can use to work with relational data by using domain-specific objects.</span></span> <span data-ttu-id="eab99-120">既に他の .NET アプリでデータを操作するためにこのフレームワークを使用している場合は、そのコードを UWP アプリに移行することができ、アプリは接続文字列を適切に変更すると動作します。</span><span class="sxs-lookup"><span data-stu-id="eab99-120">If you've already used this framework to work with data in other .NET apps, you can migrate that code to a UWP app and it will work with appropriate changes to the connection string.</span></span>

<span data-ttu-id="eab99-121">これを試すには、「[新しいデータベースを使用した、ユニバーサル Windows プラットフォーム (UWP) 上の EF Core の概要](https://docs.microsoft.com/ef/core/get-started/uwp/getting-started)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eab99-121">To try it out, see [Getting started with EF Core on Universal Windows Platform (UWP) with a New Database](https://docs.microsoft.com/ef/core/get-started/uwp/getting-started).</span></span>

### <a name="sqlite-library"></a><span data-ttu-id="eab99-122">SQLite ライブラリ</span><span class="sxs-lookup"><span data-stu-id="eab99-122">SQLite library</span></span>

<span data-ttu-id="eab99-123">[Microsoft.Data.Sqlite](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-2.0.0) ライブラリは、[System.Data.Common](https://msdn.microsoft.com/library/system.data.common.aspx) 名前空間内にインターフェイスを実装します。</span><span class="sxs-lookup"><span data-stu-id="eab99-123">The [Microsoft.Data.Sqlite](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-2.0.0) library implements the interfaces in the [System.Data.Common](https://msdn.microsoft.com/library/system.data.common.aspx) namespace.</span></span> <span data-ttu-id="eab99-124">Microsoft はこれらの実装をアクティブに保守します。これらは、低レベルのネイティブ SQLite API の直感的なラッパーを提供します。</span><span class="sxs-lookup"><span data-stu-id="eab99-124">Microsoft actively maintains these implementations, and they provide an intuitive wrapper around the low-level native SQLite API.</span></span>

<span data-ttu-id="eab99-125">このガイドの残りの部分では、このライブラリーの使用について説明します。</span><span class="sxs-lookup"><span data-stu-id="eab99-125">The rest of this guide helps you to use this library.</span></span>

## <a name="set-up-your-solution-to-use-the-microsoftdatasqlite-library"></a><span data-ttu-id="eab99-126">Microsoft.Data.SQlite ライブラリを使用するようにソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="eab99-126">Set up your solution to use the Microsoft.Data.SQlite library</span></span>

<span data-ttu-id="eab99-127">基本的な UWP プロジェクトから始めて、クラス ライブラリを追加し、適切な Nuget パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="eab99-127">We'll start with a basic UWP project, add a class library, and then install the appropriate Nuget packages.</span></span>

<span data-ttu-id="eab99-128">ソリューションに追加するクラス ライブラリの種類、およびインストールする特定のパッケージは、アプリが対象とする Windows SDK の最小バージョンによって変わります。</span><span class="sxs-lookup"><span data-stu-id="eab99-128">The type of class library that you add to your solution,  and the specific packages that you install depends on the minimum version of the Windows SDK that your app targets.</span></span> <span data-ttu-id="eab99-129">UWP プロジェクトのプロパティ ページにその情報があります。</span><span class="sxs-lookup"><span data-stu-id="eab99-129">You can find that information in the properties page of your UWP project.</span></span>

![Windows SDK の最小バージョン](images/min-version.png)

<span data-ttu-id="eab99-131">UWP プロジェクトが対象とする Windows SDK の最小バージョンに応じて、次のいずれかのセクションを使用してください。</span><span class="sxs-lookup"><span data-stu-id="eab99-131">Use one of the following sections depending on the minimum version of the Windows SDK that your UWP project targets.</span></span>

### <a name="the-minimum-version-of-your-project-does-not-target-the-fall-creators-update"></a><span data-ttu-id="eab99-132">プロジェクトの最小バージョンが Fall Creators Update を対象としない場合</span><span class="sxs-lookup"><span data-stu-id="eab99-132">The minimum version of your project does not target the Fall Creators Update</span></span>

<span data-ttu-id="eab99-133">Visual Studio 2015 を使用している場合は、**[ヘルプ] **->** [Microsoft Visual Studio のバージョン情報]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="eab99-133">If you're using Visual Studio 2015, click **Help**->**About Microsoft Visual Studio**.</span></span> <span data-ttu-id="eab99-134">インストールされているプログラムの一覧で、NuGet パッケージ マネージャーのバージョンが **3.5** 以降であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="eab99-134">Then in the list of installed programs, make sure that you have NuGet package manager version of **3.5** or higher.</span></span> <span data-ttu-id="eab99-135">バージョン番号がこれより低い場合は、3.5 以降のバージョンの NuGet [こちら](https://www.nuget.org/downloads)をインストールします。</span><span class="sxs-lookup"><span data-stu-id="eab99-135">If your version number is lower than that, install a later version of NuGet [here](https://www.nuget.org/downloads).</span></span> <span data-ttu-id="eab99-136">このページで、見出し **[Visual Studio 2015]** の下にすべてのバージョンの Nuget が表示されます。</span><span class="sxs-lookup"><span data-stu-id="eab99-136">On that page, you'll find all of the versions of Nuget listed beneath the **Visual Studio 2015** heading.</span></span>

<span data-ttu-id="eab99-137">次に、クラス ライブラリをソリューションに追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-137">Next, add class library to your solution.</span></span> <span data-ttu-id="eab99-138">クラス ライブラリを使用してデータ アクセス コードを含める必要はありません。サンプルの 1 つを使用します。</span><span class="sxs-lookup"><span data-stu-id="eab99-138">You don't have to use a class library to contain your data access code, but we'll use one our example.</span></span> <span data-ttu-id="eab99-139">ライブラリに **DataAccessLibrary** という名前を付け、ライブラリ内のクラスに **DataAccess** という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="eab99-139">We'll name the library **DataAccessLibrary** and we'll name the class in the library to **DataAccess**.</span></span>

![クラス ライブラリ](images/class-library.png)

<span data-ttu-id="eab99-141">ソリューションを右クリックし、**[ソリューションの NuGet パッケージの管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="eab99-141">Right-click the solution, and then click **Manage NuGet Packages for Solution**.</span></span>

![NuGet パッケージの管理](images/manage-nuget.png)

<span data-ttu-id="eab99-143">Visual Studio 2015 を使用している場合は、**[インストール済み]** タブを選択し、**Microsoft.NETCore.UniversalWindowsPlatform** パッケージのバージョン番号が **5.2.2** 以降であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="eab99-143">If you're using Visual Studio 2015, Choose the **Installed** tab, and make sure that the version number of the **Microsoft.NETCore.UniversalWindowsPlatform** package is **5.2.2** or higher.</span></span>

![.NETCore のバージョン](images/package-version.png)

<span data-ttu-id="eab99-145">そうでない場合は、パッケージを新しいバージョンに更新します。</span><span class="sxs-lookup"><span data-stu-id="eab99-145">If it isn't, update the package to a newer version.</span></span>

<span data-ttu-id="eab99-146">**[参照]** タブを選択し、**Microsoft.Data.SQLite** パッケージを検索します。</span><span class="sxs-lookup"><span data-stu-id="eab99-146">Choose the **Browse** tab, and search for the **Microsoft.Data.SQLite** package.</span></span> <span data-ttu-id="eab99-147">そのパッケージのバージョン **1.1.1** (またはそれ以前) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="eab99-147">Install version **1.1.1** (or lower) of that package.</span></span>

![SQLite パッケージ](images/sqlite-package.png)

<span data-ttu-id="eab99-149">このガイドの「[SQLite データベースのデータの追加と取得](#use-data)」に移動します。</span><span class="sxs-lookup"><span data-stu-id="eab99-149">Move onto the [Add and retrieve data in a SQLite database](#use-data) section of this guide.</span></span>

### <a name="the-minimum-version-of-your-project-targets-the-fall-creators-update"></a><span data-ttu-id="eab99-150">プロジェクトの最小バージョンが Fall Creators Update を対象とする場合</span><span class="sxs-lookup"><span data-stu-id="eab99-150">The minimum version of your project targets the Fall Creators Update</span></span>

<span data-ttu-id="eab99-151">UWP プロジェクトの最小バージョンを Fall Creators Update に上げると、2 つのメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="eab99-151">There's a couple of benefits to raising the minimum version of your UWP project to the Fall Creators update.</span></span>

<span data-ttu-id="eab99-152">まず、標準のクラス ライブラリの代わりに、.NET Standard 2.0 ライブラリを使用できます。</span><span class="sxs-lookup"><span data-stu-id="eab99-152">First off, you can use .NET Standard 2.0 libraries instead of regular class libraries.</span></span> <span data-ttu-id="eab99-153">これによって、データ アクセス コードを WPF、Windows フォーム、Android、iOS、ASP.NET アプリなど、他の .NET ベースのアプリと共有することができます。</span><span class="sxs-lookup"><span data-stu-id="eab99-153">That means that you can share your data access code with any other .NET-based app such as a WPF, Windows Forms, Android, iOS, or ASP.NET app.</span></span>

<span data-ttu-id="eab99-154">2 つ目に、アプリにはパッケージの SQLite ライブラリは含まれません。</span><span class="sxs-lookup"><span data-stu-id="eab99-154">Secondly, your app does not have package SQLite libraries.</span></span> <span data-ttu-id="eab99-155">代わりに、アプリは Windows と共にインストールされるバージョンの SQLite を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="eab99-155">Instead, your app can use the version of SQLite that comes installed with Windows.</span></span> <span data-ttu-id="eab99-156">これにより、次のような利点が得られます。</span><span class="sxs-lookup"><span data-stu-id="eab99-156">This helps you in a few ways.</span></span>

<span data-ttu-id="eab99-157">:heavy_check_mark: SQLite バイナリをダウンロードして、アプリの一部としてパッケージ化する必要がないため、アプリケーションのサイズが小さくなります。</span><span class="sxs-lookup"><span data-stu-id="eab99-157">:heavy_check_mark: Reduces the size of your application because you don't have to download the SQLite binary, and then package it as part of your application.</span></span>

<span data-ttu-id="eab99-158">:heavy_check_mark: SQLite のバグやセキュリティの脆弱性に対する重要な修正プログラムが公開された場合でも、アプリの新しいバージョンをユーザーに勧める必要がありません。</span><span class="sxs-lookup"><span data-stu-id="eab99-158">:heavy_check_mark: Prevents you from having to push a new version of your app to users in the event that SQLite publishes critical fixes to bugs and security vulnerabilities in SQLite.</span></span> <span data-ttu-id="eab99-159">Windows 版の SQLite は、Microsoft が SQLite.org と連携して保守します。</span><span class="sxs-lookup"><span data-stu-id="eab99-159">The Windows version of SQLite is maintained by Microsoft in coordination with SQLite.org.</span></span>

<span data-ttu-id="eab99-160">:heavy_check_mark: SQLite の SDK バージョンが既にメモリーに読み込まれている可能性が高いため、アプリの読み込み時間が高速になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="eab99-160">:heavy_check_mark: App load time has the potential to be faster because most likely, the SDK version of SQLite will already be loaded into memory.</span></span>

<span data-ttu-id="eab99-161">まず、.NET Standard 2.0 クラス ライブラリをソリューションに追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="eab99-161">Lets start by adding a .NET Standard 2.0 class library to your solution.</span></span> <span data-ttu-id="eab99-162">クラス ライブラリを使用してデータ アクセス コードを含める必要はありません。サンプルの 1 つを使用します。</span><span class="sxs-lookup"><span data-stu-id="eab99-162">It's not necessary that you use a class library to contain your data access code, but we'll use one our example.</span></span> <span data-ttu-id="eab99-163">ライブラリに **DataAccessLibrary** という名前を付け、ライブラリ内のクラスに **DataAccess** という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="eab99-163">We'll name the library **DataAccessLibrary** and we'll name the class in the library to **DataAccess**.</span></span>

![クラス ライブラリ](images/dot-net-standard.png)

<span data-ttu-id="eab99-165">ソリューションを右クリックし、**[ソリューションの NuGet パッケージの管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="eab99-165">Right-click the solution, and then click **Manage NuGet Packages for Solution**.</span></span>

![NuGet パッケージの管理](images/manage-nuget-2.png)

<span data-ttu-id="eab99-167">この時点で 2 つの選択肢があります。</span><span class="sxs-lookup"><span data-stu-id="eab99-167">At this point, you have a choice.</span></span> <span data-ttu-id="eab99-168">Windows に含まれている SQLite のバージョンを使用することができます。何らかの理由で特定バージョンの SQLite を使用する場合は、パッケージに SQLite ライブラリを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="eab99-168">You can use the version of SQLite that is included with Windows or if you have some reason to use a specific version of SQLite, you can include the SQLite library in your package.</span></span>

<span data-ttu-id="eab99-169">まず、Windows に含まれている SQLite のバージョンを使用する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="eab99-169">Let's start with how you use the version of SQLite that included with Windows.</span></span>

#### <a name="to-use-the-version-of-sqlite-that-is-installed-with-windows"></a><span data-ttu-id="eab99-170">Windows と共にインストールされている SQLite のバージョンを使用するには</span><span class="sxs-lookup"><span data-stu-id="eab99-170">To use the version of SQLite that is installed with Windows</span></span>

<span data-ttu-id="eab99-171">**[参照]** タブを選択し、**Microsoft.Data.SQLite.core** パッケージを検索してインストールします。</span><span class="sxs-lookup"><span data-stu-id="eab99-171">Choose the **Browse** tab, and search for the **Microsoft.Data.SQLite.core** package, and then install it.</span></span>

![SQLite Core パッケージ](images/sqlite-core-package.png)

<span data-ttu-id="eab99-173">**SQLitePCLRaw.bundle_winsqlite3** パッケージを検索し、ソリューションの UWP プロジェクトにのみそれをインストールします。</span><span class="sxs-lookup"><span data-stu-id="eab99-173">Search for the **SQLitePCLRaw.bundle_winsqlite3** package, and then install it only to the UWP project in your solution.</span></span>

![SQLite PCL Raw パッケージ](images/sqlite-raw-package.png)

#### <a name="to-include-sqlite-with-your-app"></a><span data-ttu-id="eab99-175">アプリと共に SQLite を含めるには</span><span class="sxs-lookup"><span data-stu-id="eab99-175">To include SQLite with your app</span></span>

<span data-ttu-id="eab99-176">これを行う必要はありませんが、</span><span class="sxs-lookup"><span data-stu-id="eab99-176">You don't have to do this.</span></span> <span data-ttu-id="eab99-177">アプリと共に特定バージョンの SQLite を含める理由がある場合は、**[参照]** タブをクリックし、**Microsoft.Data.SQLite** パッケージを検索します。</span><span class="sxs-lookup"><span data-stu-id="eab99-177">But if you have a reason to include a specific version of SQLite with your app, choose the **Browse** tab, and search for the **Microsoft.Data.SQLite** package.</span></span> <span data-ttu-id="eab99-178">そのパッケージのバージョン **2.0** (またはそれ以前) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="eab99-178">Install version **2.0** (or lower) of that package.</span></span>

![SQLite パッケージ](images/sqlite-package-v2.png)

<a id="use-data" />

## <a name="add-and-retrieve-data-in-a-sqlite-database"></a><span data-ttu-id="eab99-180">SQLite データベースのデータの追加と取得</span><span class="sxs-lookup"><span data-stu-id="eab99-180">Add and retrieve data in a SQLite database</span></span>

<span data-ttu-id="eab99-181">以下の作業を行います。</span><span class="sxs-lookup"><span data-stu-id="eab99-181">We'll do these things:</span></span>

<span data-ttu-id="eab99-182">:1: データ アクセス クラスを準備します。</span><span class="sxs-lookup"><span data-stu-id="eab99-182">:one: Prepare the data access class.</span></span>

<span data-ttu-id="eab99-183">:2: SQLite データベースを初期化します。</span><span class="sxs-lookup"><span data-stu-id="eab99-183">:two: Initialize the SQLite database.</span></span>

<span data-ttu-id="eab99-184">:3: SQLite データベースにデータを挿入します。</span><span class="sxs-lookup"><span data-stu-id="eab99-184">:three: Insert data into the SQLite database.</span></span>

<span data-ttu-id="eab99-185">:4: SQLite データベースからデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="eab99-185">:four: Retrieve data from the SQLite database.</span></span>

<span data-ttu-id="eab99-186">:5: 基本的なユーザー インターフェイスを追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-186">:five: Add a basic user interface.</span></span>

### <a name="prepare-the-data-access-class"></a><span data-ttu-id="eab99-187">データ アクセス クラスを準備する</span><span class="sxs-lookup"><span data-stu-id="eab99-187">Prepare the data access class</span></span>

<span data-ttu-id="eab99-188">UWP プロジェクトから、ソリューションの **DataAccessLibrary** プロジェクトへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-188">From your UWP project, add a reference to the **DataAccessLibrary** project in your solution.</span></span>

![データ アクセス クラス ライブラリ](images/ref-class-library.png)

<span data-ttu-id="eab99-190">UWP プロジェクトの **App.xaml.cs** および **MainPage.xaml.cs** ファイルに、次の ``using`` ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-190">Add the following ``using`` statement to the **App.xaml.cs** and **MainPage.xaml.cs** files in your UWP project.</span></span>

```csharp
using DataAccessLibrary;
```

<span data-ttu-id="eab99-191">**DataAccessLibrary** ソリューションの **DataAccess** クラスを開き、それを静的クラスにします。</span><span class="sxs-lookup"><span data-stu-id="eab99-191">Open the **DataAccess** class in your **DataAccessLibrary** solution and make that class static.</span></span>

>[!NOTE]
><span data-ttu-id="eab99-192">この例ではデータ アクセス コードを静的クラスに配置していますが、これは設計の選択肢の 1 つで、完全に任意な方法です。</span><span class="sxs-lookup"><span data-stu-id="eab99-192">While our example will place data access code in a static class, it's just a design choice and is completely optional.</span></span>

```csharp
namespace DataAccessLibrary
{
    public static class DataAccess
    {

    }
}

```

<span data-ttu-id="eab99-193">このファイルの先頭に、次の using ステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-193">Add the following using statement to the top of this file.</span></span>

```csharp
using Microsoft.Data.Sqlite;
```

<a id="initialize" />

### <a name="initialize-the-sqlite-database"></a><span data-ttu-id="eab99-194">SQLite データベースを初期化する</span><span class="sxs-lookup"><span data-stu-id="eab99-194">Initialize the SQLite database</span></span>

<span data-ttu-id="eab99-195">**DataAccess** クラスに、SQLite データベースを初期化するメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-195">Add a method to the **DataAccess** class that initializes the SQLite database.</span></span>

```csharp
public static void InitializeDatabase()
{
    using (SqliteConnection db =
        new SqliteConnection("Filename=sqliteSample.db"))
    {
        db.Open();

        String tableCommand = "CREATE TABLE IF NOT " +
            "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
            "Text_Entry NVARCHAR(2048) NULL)";

        SqliteCommand createTable = new SqliteCommand(tableCommand, db);

        createTable.ExecuteReader();
    }
}
```

<span data-ttu-id="eab99-196">このコードは、SQLite データベースを作成し、アプリケーションのローカル データ ストアに保存します。</span><span class="sxs-lookup"><span data-stu-id="eab99-196">This code creates the SQLite database and stores it in the application's local data store.</span></span>

<span data-ttu-id="eab99-197">この例では、データベースに ``sqlliteSample.db`` という名前を付けますが、インスタンス化するすべての [SqliteConnection](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqliteconnection?view=msdata-sqlite-2.0.0) オブジェクトでその名前を使用する限り、任意の名前を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="eab99-197">In this example, we name the database ``sqlliteSample.db`` but you can use whatever name you want as long as you use that name in all [SqliteConnection](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqliteconnection?view=msdata-sqlite-2.0.0) objects that you instantiate.</span></span>

<span data-ttu-id="eab99-198">UWP プロジェクトの **App.xaml.cs** ファイルのコンス トラクターで、**DataAccess** クラスの ``InitializeDatabase`` メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="eab99-198">In the constructor of the **App.xaml.cs** file of your UWP project, call the ``InitializeDatabase`` method of the **DataAccess** class.</span></span>

```csharp
public App()
{
    this.InitializeComponent();
    this.Suspending += OnSuspending;

    DataAccess.InitializeDatabase();

}
```

<a id="insert" />

### <a name="insert-data-into-the-sqlite-database"></a><span data-ttu-id="eab99-199">SQLite データベースにデータを挿入する</span><span class="sxs-lookup"><span data-stu-id="eab99-199">Insert data into the SQLite database</span></span>

<span data-ttu-id="eab99-200">**DataAccess** クラスに、SQLite データベースにデータを挿入するメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-200">Add a method to the **DataAccess** class that inserts data into the SQLite database.</span></span> <span data-ttu-id="eab99-201">このコードでは、クエリでパラメーターを使用して SQL インジェクション攻撃を防ぎます。</span><span class="sxs-lookup"><span data-stu-id="eab99-201">This code uses parameters in the query to prevent SQL injection attacks.</span></span>

```csharp
public static void AddData(string inputText)
{
    using (SqliteConnection db =
        new SqliteConnection("Filename=sqliteSample.db"))
    {
        db.Open();

        SqliteCommand insertCommand = new SqliteCommand();
        insertCommand.Connection = db;

        // Use parameterized query to prevent SQL injection attacks
        insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
        insertCommand.Parameters.AddWithValue("@Entry", inputText);

        insertCommand.ExecuteReader();

        db.Close();
    }

}
```

<a id="retrieve" />

### <a name="retrieve-data-from-the-sqlite-database"></a><span data-ttu-id="eab99-202">SQLite データベースからデータを取得する</span><span class="sxs-lookup"><span data-stu-id="eab99-202">Retrieve data from the SQLite database</span></span>

<span data-ttu-id="eab99-203">SQLite データベースからデータの行を取得するメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-203">Add a method that gets rows of data from a SQLite database.</span></span>

```csharp
public static List<String> GetData()
{
    List<String> entries = new List<string>();

    using (SqliteConnection db =
        new SqliteConnection("Filename=sqliteSample.db"))
    {
        db.Open();

        SqliteCommand selectCommand = new SqliteCommand
            ("SELECT Text_Entry from MyTable", db);

        SqliteDataReader query = selectCommand.ExecuteReader();

        while (query.Read())
        {
            entries.Add(query.GetString(0));
        }

        db.Close();
    }

    return entries;
}
```

<span data-ttu-id="eab99-204">[Read](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.read?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_Read) メソッドは、返されるデータの行を次に進めます。</span><span class="sxs-lookup"><span data-stu-id="eab99-204">The [Read](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.read?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_Read) method advances through the rows of returned data.</span></span> <span data-ttu-id="eab99-205">このメソッドは、残りの行がある場合は **true** を返し、ない場合は **false** を返します。</span><span class="sxs-lookup"><span data-stu-id="eab99-205">It returns **true** if there are rows left, otherwise it returns **false**.</span></span>

<span data-ttu-id="eab99-206">[GetString](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getstring?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetString_System_Int32_) メソッドは、指定された列の値を文字列として返します。</span><span class="sxs-lookup"><span data-stu-id="eab99-206">The [GetString](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getstring?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetString_System_Int32_) method returns the value of the specified column as a string.</span></span> <span data-ttu-id="eab99-207">このメソッドは、必要なデータの 0 から始まる列の序数を表す整数値を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="eab99-207">It accepts an integer value that represents the zero-based column ordinal of the data that you want.</span></span> <span data-ttu-id="eab99-208">[GetDataTime](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getdatetime?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetDateTime_System_Int32_) や [GetBoolean](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getboolean?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetBoolean_System_Int32_) などの同様のメソッドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="eab99-208">You can use similar methods such as [GetDataTime](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getdatetime?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetDateTime_System_Int32_) and [GetBoolean](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getboolean?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetBoolean_System_Int32_).</span></span> <span data-ttu-id="eab99-209">列に格納されたデータの型に基づいてメソッドを選択します。</span><span class="sxs-lookup"><span data-stu-id="eab99-209">Choose a method based on what type of data the column contains.</span></span>

<span data-ttu-id="eab99-210">この例では 1 つの列のすべてのエントリを選択しているため、序数パラメーターはそれほど重要ではありません。</span><span class="sxs-lookup"><span data-stu-id="eab99-210">The ordinal parameter isn't as important in this example because we are selecting all of the entries in a single column.</span></span> <span data-ttu-id="eab99-211">ただし、クエリに複数の列が含まれる場合は、序数値を使用してデータをプルする列を取得します。</span><span class="sxs-lookup"><span data-stu-id="eab99-211">However, if multiple columns are part of your query, use the ordinal value to obtain the column you want to pull data from.</span></span>

## <a name="add-a-basic-user-interface"></a><span data-ttu-id="eab99-212">基本的なユーザー インターフェイスを追加する</span><span class="sxs-lookup"><span data-stu-id="eab99-212">Add a basic user interface</span></span>

<span data-ttu-id="eab99-213">UWP プロジェクトの **MainPage.xaml** ファイルに、次の XAML を追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-213">In the **MainPage.xaml** file of the UWP project, add the following XAML.</span></span>

```xml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <StackPanel>
        <TextBox Name="Input_Box"></TextBox>
        <Button Click="AddData">Add</Button>
        <ListView Name="Output">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding}"/>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </StackPanel>
</Grid>
```

<span data-ttu-id="eab99-214">この基本的なユーザー インターフェイスは、SQLite データベースに追加する文字列を入力するための ``TextBox`` をユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="eab99-214">This basic user interface gives the user a ``TextBox`` that they can use to type a string that we'll add to the SQLite database.</span></span> <span data-ttu-id="eab99-215">この UI の ``Button`` を、SQLite データベースからデータを取得して、``ListView`` にそのデータを表示するイベント ハンドラーに接続します。</span><span class="sxs-lookup"><span data-stu-id="eab99-215">We'll connect the ``Button`` in this UI to an event handler that will retrieve data from the SQLite database and then show that data in the ``ListView``.</span></span>

<span data-ttu-id="eab99-216">**MainPage.xaml.cs** ファイルで、次のハンドラーを追加します。</span><span class="sxs-lookup"><span data-stu-id="eab99-216">In the **MainPage.xaml.cs** file, add the following handler.</span></span> <span data-ttu-id="eab99-217">これは、UI で ``Button`` の ``Click`` イベントに関連付けたメソッドです。</span><span class="sxs-lookup"><span data-stu-id="eab99-217">This is the method that we associated with the ``Click`` event of the ``Button`` in the UI.</span></span>

```csharp
private void AddData(object sender, RoutedEventArgs e)
{
    DataAccess.AddData(Input_Box.Text);

    Output.ItemsSource = DataAccess.GetData();
}
```

<span data-ttu-id="eab99-218">以上で終わりです。</span><span class="sxs-lookup"><span data-stu-id="eab99-218">That's it.</span></span> <span data-ttu-id="eab99-219">[Microsoft.Data.Sqlite](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-2.0.0) を参照して、他に SQLite データベースと連携できるものを確認してください。</span><span class="sxs-lookup"><span data-stu-id="eab99-219">Explore the [Microsoft.Data.Sqlite](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-2.0.0) to see what other things you can do with your SQLite database.</span></span> <span data-ttu-id="eab99-220">UWP アプリでデータを使用するその他の方法については、次のリンクを参照してください。</span><span class="sxs-lookup"><span data-stu-id="eab99-220">Check out the links below to learn about other ways to use data in your UWP app.</span></span>

## <a name="next-steps"></a><span data-ttu-id="eab99-221">次のステップ</span><span class="sxs-lookup"><span data-stu-id="eab99-221">Next steps</span></span>

**<span data-ttu-id="eab99-222">アプリを SQL Server データベースに直接接続する</span><span class="sxs-lookup"><span data-stu-id="eab99-222">Connect your app directly to a SQL Server database</span></span>**

<span data-ttu-id="eab99-223">「[UWP アプリでの SQL Server データベースの使用](sql-server-databases.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eab99-223">See [Use a SQL Server database in a UWP app](sql-server-databases.md).</span></span>

**<span data-ttu-id="eab99-224">異なるプラットフォームにわたる異なるアプリの間でコードを共有する</span><span class="sxs-lookup"><span data-stu-id="eab99-224">Share code between different apps across different platforms</span></span>**

<span data-ttu-id="eab99-225">「[デスクトップと UWP でコードを共有する](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eab99-225">See [Share code between desktop and UWP](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate).</span></span>

**<span data-ttu-id="eab99-226">Azure SQL バックエンドでマスター/詳細ページを追加する</span><span class="sxs-lookup"><span data-stu-id="eab99-226">Add master detail pages with Azure SQL back ends</span></span>**

<span data-ttu-id="eab99-227">「[顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eab99-227">See [Customer Orders Database sample](https://github.com/Microsoft/Windows-appsample-customers-orders-database).</span></span>
