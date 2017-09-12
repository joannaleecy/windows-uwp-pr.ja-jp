---
author: normesta
ms.assetid: 5A47301A-2291-4FC8-8BA7-55DB2A5C653F
title: "SQLite データベース"
description: "SQLite は、サーバーを使わない埋め込みデータベース エンジンです。 この記事では、SDK に付属している SQLite ライブラリを使って、独自の SQLite ライブラリをユニバーサル Windows アプリにパッケージ化する方法、およびソースから SQLite ライブラリを構築する方法について説明します。"
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, UWP, SQLite, データベース"
ms.openlocfilehash: 3b075a6c55373e91e9f12fb5359f5aa4a985f602
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
---
# <a name="sqlite-databases"></a><span data-ttu-id="7767e-105">SQLite データベース</span><span class="sxs-lookup"><span data-stu-id="7767e-105">SQLite databases</span></span>

<span data-ttu-id="7767e-106">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="7767e-106">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="7767e-107">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="7767e-107">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="7767e-108">SQLite は、サーバーを使わない埋め込みデータベース エンジンです。</span><span class="sxs-lookup"><span data-stu-id="7767e-108">SQLite is a server-less, embedded database engine.</span></span> <span data-ttu-id="7767e-109">この記事では、SDK に付属している SQLite ライブラリを使って、独自の SQLite ライブラリをユニバーサル Windows アプリにパッケージ化する方法、およびソースから SQLite ライブラリを構築する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7767e-109">This article explains how to use the SQLite library included in the SDK, package your own SQLite library in a Universal Windows app, or build it from the source.</span></span>

## <a name="what-sqlite-is-and-when-to-use-it"></a><span data-ttu-id="7767e-110">SQLite についての説明と SQLite を使う状況</span><span class="sxs-lookup"><span data-stu-id="7767e-110">What SQLite is and when to use it</span></span>

<span data-ttu-id="7767e-111">SQLite は、オープン ソースの埋め込みデータベース エンジンで、サーバーを使いません。</span><span class="sxs-lookup"><span data-stu-id="7767e-111">SQLite is an open source, embedded, server-less database.</span></span> <span data-ttu-id="7767e-112">SQLite は、長い年月をかけて、さまざまなプラットフォームやデバイスでデータを保管するために使われる、デバイス側の主要なテクノロジとして登場しました。</span><span class="sxs-lookup"><span data-stu-id="7767e-112">Over the years it has emerged as the dominant device side technology for data storage on many platforms and devices.</span></span> <span data-ttu-id="7767e-113">ユニバーサル Windows プラットフォーム (UWP) では、すべての Windows 10 デバイス ファミリで、ローカル記憶域用に SQLite をサポートしており、その利用を推奨しています。</span><span class="sxs-lookup"><span data-stu-id="7767e-113">Universal Windows Platform (UWP) supports and recommends SQLite for local storage across all Windows 10 device families.</span></span>

<span data-ttu-id="7767e-114">SQLite は、電話アプリや、Windows 10 IoT Core (IoT Core) 用埋め込みアプリケーションに最適です。また、企業向けのリレーショナル データベース サーバー (RDBS) のデータ用キャッシュとしても適しています。</span><span class="sxs-lookup"><span data-stu-id="7767e-114">SQLite is best suited for phone apps, embedded applications for Windows 10 IoT Core (IoT Core), and as a cache for enterprise relations database server (RDBS) data.</span></span> <span data-ttu-id="7767e-115">ほとんどのローカル データ アクセスのニーズを満たします。条件として、高負荷の同時実行の書き込みを伴わない (ビッグ データ規模のシナリオでない) ことが挙げられますが、この条件はほとんどのアプリで発生する可能性が低いと考えられます。</span><span class="sxs-lookup"><span data-stu-id="7767e-115">It will satisfy most local data access needs unless they entail heavy concurrent writes, or a big data scale—scenarios unlikely for most apps.</span></span>

<span data-ttu-id="7767e-116">メディア再生アプリケーションやゲーム アプリケーションでは、SQLite を、ストア カタログや他のアセット (ゲームのレベルなど) を保存するためのファイル形式として使うことができます。この形式で保存したデータは、Web サーバーから手を加えない状態でダウンロードすることができます。</span><span class="sxs-lookup"><span data-stu-id="7767e-116">In media playback and gaming applications, SQLite can also be used as a file format to store catalogues or other assets, such as levels of a game, that can be downloaded as-is from a web server.</span></span>

## <a name="adding-sqlite-to-a-uwp-app-project"></a><span data-ttu-id="7767e-117">UWP アプリ プロジェクトへの SQLite の追加</span><span class="sxs-lookup"><span data-stu-id="7767e-117">Adding SQLite to a UWP app project</span></span>

<span data-ttu-id="7767e-118">SQLite を UWP プロジェクトに追加するには、次の 3 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="7767e-118">There are three ways of adding SQLite to a UWP project.</span></span>

1.  [<span data-ttu-id="7767e-119">SDK の SQLite を使う</span><span class="sxs-lookup"><span data-stu-id="7767e-119">Using the SDK SQLite</span></span>](#using-the-sdk-sqlite)
2.  [<span data-ttu-id="7767e-120">SQLite をアプリ パッケージに含める</span><span class="sxs-lookup"><span data-stu-id="7767e-120">Including SQLite in the App Package</span></span>](#including-sqlite-in-the-app-package)
3.  [<span data-ttu-id="7767e-121">Visual Studio でソースから SQLite を構築する</span><span class="sxs-lookup"><span data-stu-id="7767e-121">Building SQLite from source in Visual Studio</span></span>](#building-sqlite-from-source-in-visual-studio)

### <a name="using-the-sdk-sqlite"></a><span data-ttu-id="7767e-122">SDK の SQLite を使う</span><span class="sxs-lookup"><span data-stu-id="7767e-122">Using the SDK SQLite</span></span>

<span data-ttu-id="7767e-123">UWP SDK に含まれている SQLite ライブラリを使って、アプリケーション パッケージのサイズを小さくし、プラットフォームに依存してライブラリを定期的に更新することができます。</span><span class="sxs-lookup"><span data-stu-id="7767e-123">You may wish to use the SQLite library included in the UWP SDK to reduce the size of your application package, and rely on the platform to update the library periodically.</span></span> <span data-ttu-id="7767e-124">SDK の SQLite を利用すると、パフォーマンスが向上する場合もあります。たとえば、システム コンポーネントで利用される際に SQLite ライブラリが既にメモリに読み込まれていれば、起動時間が短縮される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7767e-124">Using the SDK SQLite might also lead to performance advantages such as faster launch times given the SQLite library is highly likely to already be loaded in memory for use by system components.</span></span>

<span data-ttu-id="7767e-125">SDK の SQLite を参照するには、次のヘッダーをプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="7767e-125">To reference the SDK SQLite, include the following header in your project.</span></span> <span data-ttu-id="7767e-126">ヘッダーには、プラットフォームでサポートされている SQLite のバージョンも含まれています。</span><span class="sxs-lookup"><span data-stu-id="7767e-126">The header also contains the version of SQLite supported in the platform.</span></span>

`#include <winsqlite/winsqlite3.h>`

<span data-ttu-id="7767e-127">winsqlite3.lib にリンクするようにプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="7767e-127">Configure the project to link to winsqlite3.lib.</span></span> <span data-ttu-id="7767e-128">**ソリューション エクスプ ローラー**でプロジェクトを右クリックし、**[プロパティ]** &gt; **[リンカー]** &gt; **[入力]** の順に選択して、winsqlite3.lib を **[追加の依存関係]** に追加します。</span><span class="sxs-lookup"><span data-stu-id="7767e-128">In **Solution Explorer**, right-click your project and select **Properties** &gt; **Linker** &gt; **Input**, then add winsqlite3.lib to **Additional Dependencies**.</span></span>

### <a name="including-sqlite-in-the-app-package"></a><span data-ttu-id="7767e-129">SQLite をアプリ パッケージに含める</span><span class="sxs-lookup"><span data-stu-id="7767e-129">Including SQLite in the App Package</span></span>

<span data-ttu-id="7767e-130">場合によっては、SDK バージョンを使うのではなく、独自のライブラリをパッケージ化することができます。たとえば、クロスプラットフォーム クライアントで特定のバージョンの SQLite を使うとき、SDK に含まれている SQLite のバージョンとは異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="7767e-130">Sometimes, you might wish to package your own library instead of using the SDK version, for example, you might wish to use a particular version of it in your cross-platform clients that is different from the version of SQLite included in the SDK.</span></span>

<span data-ttu-id="7767e-131">SQLite.org から、または [拡張機能と更新プログラム] ツールを使って、利用可能なユニバーサル Windows プラットフォームの Visual Studio の拡張機能に SQLite ライブラリをインストールします。</span><span class="sxs-lookup"><span data-stu-id="7767e-131">Install the SQLite library on the Universal Windows Platform Visual Studio extension available from SQLite.org, or through the Extensions and Updates tool.</span></span>

![[拡張機能と更新プログラム] 画面](./images/extensions-and-updates.png)

<span data-ttu-id="7767e-133">拡張機能をインストールしたら、コードで次のヘッダー ファイルを参照します。</span><span class="sxs-lookup"><span data-stu-id="7767e-133">Once the extension is installed, reference the following header file in your code.</span></span>

`#include <sqlite3.h>`

### <a name="building-sqlite-from-source-in-visual-studio"></a><span data-ttu-id="7767e-134">Visual Studio でソースから SQLite を構築する</span><span class="sxs-lookup"><span data-stu-id="7767e-134">Building SQLite from source in Visual Studio</span></span>

<span data-ttu-id="7767e-135">場合によっては、[さまざまなコンパイラ オプション](http://www.sqlite.org/compile.html) を使って独自の SQLite バイナリをコンパイルし、ファイル サイズを小さくしたり、ライブラリのパフォーマンスを調整したり、アプリケーションに合わせて機能セットを調整したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="7767e-135">Sometimes you might wish to compile your own SQLite binary to use [various compiler options](http://www.sqlite.org/compile.html) to reduce the file size, performance tune the library, or tailor the feature set to your application.</span></span> <span data-ttu-id="7767e-136">SQLite には、プラットフォーム構成向けのオプションが用意されており、既定のパラメーター値の設定、サイズ制限の設定、動作特性の制御、通常は無効になっている機能の有効化、通常は有効になっている機能の無効化、機能の省略、分析とデバッグの有効化、および Windows でのメモリ割り当て動作の管理などを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="7767e-136">SQLite provides options for platform configuration, setting default parameter values, setting size limits, controlling operating characteristics, enabling features normally turned off, disabling features normally turned on, omitting features, enabling analysis and debugging, and managing memory allocation behavior on Windows.</span></span>

*<span data-ttu-id="7767e-137">ソースを Visual Studio プロジェクトに追加する</span><span class="sxs-lookup"><span data-stu-id="7767e-137">Adding source to a Visual Studio project</span></span>*

<span data-ttu-id="7767e-138">SQLite のソース コードは、[SQLite.org のダウンロード ページ](https://www.sqlite.org/download.html)でダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="7767e-138">The SQLite source code is available for download at the [SQLite.org download page](https://www.sqlite.org/download.html).</span></span> <span data-ttu-id="7767e-139">このファイルを、SQLite を使うアプリケーションの Visual Studio プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="7767e-139">Add this file to the Visual Studio project of the application you wish to use SQLite in.</span></span>

*<span data-ttu-id="7767e-140">プリプロセッサを構成する</span><span class="sxs-lookup"><span data-stu-id="7767e-140">Configure Preprocessors</span></span>*

<span data-ttu-id="7767e-141">他の[コンパイル時のオプション](http://www.sqlite.org/compile.html)に加えて、常に SQLITE\_OS\_WINRT と SQLITE\_API=\_\_declspec(dllexport) を使います。</span><span class="sxs-lookup"><span data-stu-id="7767e-141">Always use SQLITE\_OS\_WINRT and SQLITE\_API=\_\_declspec(dllexport) in addition to any other [compile time options](http://www.sqlite.org/compile.html).</span></span>

![[SQLite プロパティ ページ] 画面](./images/property-pages.png)

## <a name="managing-a-sqlite-database"></a><span data-ttu-id="7767e-143">SQLite データベースの管理</span><span class="sxs-lookup"><span data-stu-id="7767e-143">Managing a SQLite Database</span></span>

<span data-ttu-id="7767e-144">SQLite データベースは、SQLite C API を使って、作成、更新、削除することができます。</span><span class="sxs-lookup"><span data-stu-id="7767e-144">SQLite databases can be created, updated, and deleted with the SQLite C APIs.</span></span> <span data-ttu-id="7767e-145">SQLite C API について詳しくは、SQLite.org の「[SQLite C/C++ インターフェイスの概要](http://www.sqlite.org/cintro.html)」のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7767e-145">Details of the SQLite C API can be found at the SQLite.org [Introduction To The SQLite C/C++ Interface](http://www.sqlite.org/cintro.html) page.</span></span>

<span data-ttu-id="7767e-146">SQLite のしくみを正しく理解するには、SQL データベースの主なタスクである SQL ステートメントの評価からさかのぼって作業を行います。</span><span class="sxs-lookup"><span data-stu-id="7767e-146">To gain sound understanding of how SQLite works, work backwards from the main task of the SQL database which is to evaluate SQL statements.</span></span> <span data-ttu-id="7767e-147">そのためには、2 つのオブジェクトを把握しておいてください。</span><span class="sxs-lookup"><span data-stu-id="7767e-147">There are two objects to keep in mind:</span></span>

-   [<span data-ttu-id="7767e-148">データベース接続ハンドル</span><span class="sxs-lookup"><span data-stu-id="7767e-148">The database connection handle</span></span>](https://www.sqlite.org/c3ref/sqlite3.html)
-   [<span data-ttu-id="7767e-149">prepared ステートメント オブジェクト</span><span class="sxs-lookup"><span data-stu-id="7767e-149">The prepared statement object</span></span>](https://www.sqlite.org/c3ref/stmt.html)

<span data-ttu-id="7767e-150">これらのオブジェクトでデータベース操作を実行するために、次の 6 つのインターフェイスがあります。</span><span class="sxs-lookup"><span data-stu-id="7767e-150">There are six interfaces to perform database operations on these objects:</span></span>

-   [<span data-ttu-id="7767e-151">sqlite3\_open()</span><span class="sxs-lookup"><span data-stu-id="7767e-151">sqlite3\_open()</span></span>](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/open.html)
-   [<span data-ttu-id="7767e-152">sqlite3\_prepare()</span><span class="sxs-lookup"><span data-stu-id="7767e-152">sqlite3\_prepare()</span></span>](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/prepare.html)
-   [<span data-ttu-id="7767e-153">sqlite3\_step()</span><span class="sxs-lookup"><span data-stu-id="7767e-153">sqlite3\_step()</span></span>](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/step.html)
-   [<span data-ttu-id="7767e-154">sqlite3\_column()</span><span class="sxs-lookup"><span data-stu-id="7767e-154">sqlite3\_column()</span></span>](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/column_blob.html)
-   [<span data-ttu-id="7767e-155">sqlite3\_finalize()</span><span class="sxs-lookup"><span data-stu-id="7767e-155">sqlite3\_finalize()</span></span>](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/finalize.html)
-   [<span data-ttu-id="7767e-156">sqlite3\_close()</span><span class="sxs-lookup"><span data-stu-id="7767e-156">sqlite3\_close()</span></span>](https://web.archive.org/web/20141228070025/http:/www.sqlite.org/c3ref/close.html)

 

 
