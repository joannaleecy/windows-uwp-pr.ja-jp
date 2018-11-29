---
title: UWP アプリでの SQLite データベースの使用
description: UWP アプリでの SQLite データベースの使用。
ms.date: 06/08/2018
ms.topic: article
keywords: windows 10, UWP, SQLite, データベース
ms.localizationpriority: medium
ms.openlocfilehash: 1588dfbfb1c33b246caba0816c584135f2094f35
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7983348"
---
# <a name="use-a-sqlite-database-in-a-uwp-app"></a>UWP アプリでの SQLite データベースの使用
SQLite を使用すると、ユーザー デバイス上の軽量なデータベースにデータを保存し、取得することができます。 このガイドでその方法を示します。

## <a name="some-benefits-of-using-sqlite-for-local-storage"></a>ローカル ストレージに SQLite を使用するメリット

:heavy_check_mark: SQLite は軽量で自己完結型です。 その他の依存関係がないコード ライブラリです。 構成する必要がありません。

:heavy_check_mark: データベース サーバーがありません。 クライアントとサーバーは、同じプロセスで実行されます。

:heavy_check_mark: SQLite はパブリック ドメインにあるため、アプリで自由に使用して配布できます。

:heavy_check_mark: SQLite はプラットフォームやアーキテクチャにかかわらず動作します。

SQLite について詳しくは、[こちら](https://sqlite.org/about.html)をご覧ください。

## <a name="choose-an-abstraction-layer"></a>アブストラクション レイヤーを選択する

Entity Framework Core またはオープン ソースの [SQLite ライブラリ](https://github.com/aspnet/Microsoft.Data.Sqlite/) (Microsoft が構築) を使用することをお勧めします。

### <a name="entity-framework-core"></a>Entity Framework Core

Entity Framework (EF) は、ドメイン固有のオブジェクトを使ってリレーショナル データを操作できる、オブジェクト リレーショナル マッパーです。 既に他の .NET アプリでデータを操作するためにこのフレームワークを使用している場合は、そのコードを UWP アプリに移行することができ、アプリは接続文字列を適切に変更すると動作します。

これを試すには、「[新しいデータベースを使用した、ユニバーサル Windows プラットフォーム (UWP) 上の EF Core の概要](https://docs.microsoft.com/ef/core/get-started/uwp/getting-started)」をご覧ください。

### <a name="sqlite-library"></a>SQLite ライブラリ

[Microsoft.Data.Sqlite](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-2.0.0) ライブラリは、[System.Data.Common](https://msdn.microsoft.com/library/system.data.common.aspx) 名前空間内にインターフェイスを実装します。 Microsoft はこれらの実装をアクティブに保守します。これらは、低レベルのネイティブ SQLite API の直感的なラッパーを提供します。

このガイドの残りの部分では、このライブラリーの使用について説明します。

## <a name="set-up-your-solution-to-use-the-microsoftdatasqlite-library"></a>Microsoft.Data.SQlite ライブラリを使用するようにソリューションをセットアップする

基本的な UWP プロジェクトから始めて、クラス ライブラリを追加し、適切な Nuget パッケージをインストールします。

ソリューションに追加するクラス ライブラリの種類、およびインストールする特定のパッケージは、アプリが対象とする Windows SDK の最小バージョンによって変わります。 UWP プロジェクトのプロパティ ページにその情報があります。

![Windows SDK の最小バージョン](images/min-version.png)

UWP プロジェクトが対象とする Windows SDK の最小バージョンに応じて、次のいずれかのセクションを使用してください。

### <a name="the-minimum-version-of-your-project-does-not-target-the-fall-creators-update"></a>プロジェクトの最小バージョンが Fall Creators Update を対象としない場合

Visual Studio 2015 を使用している場合は、**[ヘルプ] **->** [Microsoft Visual Studio のバージョン情報]** の順にクリックします。 インストールされているプログラムの一覧で、NuGet パッケージ マネージャーのバージョンが **3.5** 以降であることを確認します。 バージョン番号がこれより低い場合は、3.5 以降のバージョンの NuGet [こちら](https://www.nuget.org/downloads)をインストールします。 このページで、見出し **[Visual Studio 2015]** の下にすべてのバージョンの Nuget が表示されます。

次に、クラス ライブラリをソリューションに追加します。 クラス ライブラリを使用してデータ アクセス コードを含める必要はありません。サンプルの 1 つを使用します。 ライブラリに **DataAccessLibrary** という名前を付け、ライブラリ内のクラスに **DataAccess** という名前を付けます。

![クラス ライブラリ](images/class-library.png)

ソリューションを右クリックし、**[ソリューションの NuGet パッケージの管理]** をクリックします。

![NuGet パッケージの管理](images/manage-nuget.png)

Visual Studio 2015 を使用している場合は、**[インストール済み]** タブを選択し、**Microsoft.NETCore.UniversalWindowsPlatform** パッケージのバージョン番号が **5.2.2** 以降であることを確認します。

![.NETCore のバージョン](images/package-version.png)

そうでない場合は、パッケージを新しいバージョンに更新します。

**[参照]** タブを選択し、**Microsoft.Data.SQLite** パッケージを検索します。 そのパッケージのバージョン **1.1.1** (またはそれ以前) をインストールします。

![SQLite パッケージ](images/sqlite-package.png)

このガイドの「[SQLite データベースのデータの追加と取得](#use-data)」に移動します。

### <a name="the-minimum-version-of-your-project-targets-the-fall-creators-update"></a>プロジェクトの最小バージョンが Fall Creators Update を対象とする場合

UWP プロジェクトの最小バージョンを Fall Creators Update に上げると、2 つのメリットがあります。

まず、標準のクラス ライブラリの代わりに、.NET Standard 2.0 ライブラリを使用できます。 これによって、データ アクセス コードを WPF、Windows フォーム、Android、iOS、ASP.NET アプリなど、他の .NET ベースのアプリと共有することができます。

2 つ目に、アプリにはパッケージの SQLite ライブラリは含まれません。 代わりに、アプリは Windows と共にインストールされるバージョンの SQLite を使用することができます。 これにより、次のような利点が得られます。

:heavy_check_mark: SQLite バイナリをダウンロードして、アプリの一部としてパッケージ化する必要がないため、アプリケーションのサイズが小さくなります。

:heavy_check_mark: SQLite のバグやセキュリティの脆弱性に対する重要な修正プログラムが公開された場合でも、アプリの新しいバージョンをユーザーに勧める必要がありません。 Windows 版の SQLite は、Microsoft が SQLite.org と連携して保守します。

:heavy_check_mark: SQLite の SDK バージョンが既にメモリーに読み込まれている可能性が高いため、アプリの読み込み時間が高速になる可能性があります。

まず、.NET Standard 2.0 クラス ライブラリをソリューションに追加しましょう。 クラス ライブラリを使用してデータ アクセス コードを含める必要はありません。サンプルの 1 つを使用します。 ライブラリに **DataAccessLibrary** という名前を付け、ライブラリ内のクラスに **DataAccess** という名前を付けます。

![クラス ライブラリ](images/dot-net-standard.png)

ソリューションを右クリックし、**[ソリューションの NuGet パッケージの管理]** をクリックします。

![NuGet パッケージの管理](images/manage-nuget-2.png)

この時点で 2 つの選択肢があります。 Windows に含まれている SQLite のバージョンを使用することができます。何らかの理由で特定バージョンの SQLite を使用する場合は、パッケージに SQLite ライブラリを含めることができます。

まず、Windows に含まれている SQLite のバージョンを使用する方法を説明します。

#### <a name="to-use-the-version-of-sqlite-that-is-installed-with-windows"></a>Windows と共にインストールされている SQLite のバージョンを使用するには

**[参照]** タブを選択し、**Microsoft.Data.SQLite.core** パッケージを検索してインストールします。

![SQLite Core パッケージ](images/sqlite-core-package.png)

**SQLitePCLRaw.bundle_winsqlite3** パッケージを検索し、ソリューションの UWP プロジェクトにのみそれをインストールします。

![SQLite PCL Raw パッケージ](images/sqlite-raw-package.png)

#### <a name="to-include-sqlite-with-your-app"></a>アプリと共に SQLite を含めるには

これを行う必要はありませんが、 アプリと共に特定バージョンの SQLite を含める理由がある場合は、**[参照]** タブをクリックし、**Microsoft.Data.SQLite** パッケージを検索します。 そのパッケージのバージョン **2.0** (またはそれ以前) をインストールします。

![SQLite パッケージ](images/sqlite-package-v2.png)

<a id="use-data" />

## <a name="add-and-retrieve-data-in-a-sqlite-database"></a>SQLite データベースのデータの追加と取得

以下の作業を行います。

:1: データ アクセス クラスを準備します。

:2: SQLite データベースを初期化します。

:3: SQLite データベースにデータを挿入します。

:4: SQLite データベースからデータを取得します。

:5: 基本的なユーザー インターフェイスを追加します。

### <a name="prepare-the-data-access-class"></a>データ アクセス クラスを準備する

UWP プロジェクトから、ソリューションの **DataAccessLibrary** プロジェクトへの参照を追加します。

![データ アクセス クラス ライブラリ](images/ref-class-library.png)

UWP プロジェクトの **App.xaml.cs** および **MainPage.xaml.cs** ファイルに、次の ``using`` ステートメントを追加します。

```csharp
using DataAccessLibrary;
```

**DataAccessLibrary** ソリューションの **DataAccess** クラスを開き、それを静的クラスにします。

>[!NOTE]
>この例ではデータ アクセス コードを静的クラスに配置していますが、これは設計の選択肢の 1 つで、完全に任意な方法です。

```csharp
namespace DataAccessLibrary
{
    public static class DataAccess
    {

    }
}

```

このファイルの先頭に、次の using ステートメントを追加します。

```csharp
using Microsoft.Data.Sqlite;
```

<a id="initialize" />

### <a name="initialize-the-sqlite-database"></a>SQLite データベースを初期化する

**DataAccess** クラスに、SQLite データベースを初期化するメソッドを追加します。

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

このコードは、SQLite データベースを作成し、アプリケーションのローカル データ ストアに保存します。

この例では、データベースに ``sqlliteSample.db`` という名前を付けますが、インスタンス化するすべての [SqliteConnection](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqliteconnection?view=msdata-sqlite-2.0.0) オブジェクトでその名前を使用する限り、任意の名前を使用することができます。

UWP プロジェクトの **App.xaml.cs** ファイルのコンス トラクターで、**DataAccess** クラスの ``InitializeDatabase`` メソッドを呼び出します。

```csharp
public App()
{
    this.InitializeComponent();
    this.Suspending += OnSuspending;

    DataAccess.InitializeDatabase();

}
```

<a id="insert" />

### <a name="insert-data-into-the-sqlite-database"></a>SQLite データベースにデータを挿入する

**DataAccess** クラスに、SQLite データベースにデータを挿入するメソッドを追加します。 このコードでは、クエリでパラメーターを使用して SQL インジェクション攻撃を防ぎます。

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

### <a name="retrieve-data-from-the-sqlite-database"></a>SQLite データベースからデータを取得する

SQLite データベースからデータの行を取得するメソッドを追加します。

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

[Read](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.read?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_Read) メソッドは、返されるデータの行を次に進めます。 このメソッドは、残りの行がある場合は **true** を返し、ない場合は **false** を返します。

[GetString](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getstring?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetString_System_Int32_) メソッドは、指定された列の値を文字列として返します。 このメソッドは、必要なデータの 0 から始まる列の序数を表す整数値を受け取ります。 [GetDataTime](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getdatetime?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetDateTime_System_Int32_) や [GetBoolean](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite.sqlitedatareader.getboolean?view=msdata-sqlite-2.0.0#Microsoft_Data_Sqlite_SqliteDataReader_GetBoolean_System_Int32_) などの同様のメソッドを使用できます。 列に格納されたデータの型に基づいてメソッドを選択します。

この例では 1 つの列のすべてのエントリを選択しているため、序数パラメーターはそれほど重要ではありません。 ただし、クエリに複数の列が含まれる場合は、序数値を使用してデータをプルする列を取得します。

## <a name="add-a-basic-user-interface"></a>基本的なユーザー インターフェイスを追加する

UWP プロジェクトの **MainPage.xaml** ファイルに、次の XAML を追加します。

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

この基本的なユーザー インターフェイスは、SQLite データベースに追加する文字列を入力するための ``TextBox`` をユーザーに提供します。 この UI の ``Button`` を、SQLite データベースからデータを取得して、``ListView`` にそのデータを表示するイベント ハンドラーに接続します。

**MainPage.xaml.cs** ファイルで、次のハンドラーを追加します。 これは、UI で ``Button`` の ``Click`` イベントに関連付けたメソッドです。

```csharp
private void AddData(object sender, RoutedEventArgs e)
{
    DataAccess.AddData(Input_Box.Text);

    Output.ItemsSource = DataAccess.GetData();
}
```

以上で終わりです。 [Microsoft.Data.Sqlite](https://docs.microsoft.com/dotnet/api/microsoft.data.sqlite?view=msdata-sqlite-2.0.0) を参照して、他に SQLite データベースと連携できるものを確認してください。 UWP アプリでデータを使用するその他の方法については、次のリンクを参照してください。

## <a name="next-steps"></a>次のステップ

**アプリを SQL Server データベースに直接接続する**

「[UWP アプリでの SQL Server データベースの使用](sql-server-databases.md)」をご覧ください。

**異なるプラットフォームにわたる異なるアプリの間でコードを共有する**

「[デスクトップと UWP でコードを共有する](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate)」をご覧ください。

**Azure SQL バックエンドでマスター/詳細ページを追加する**

「[顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)」をご覧ください。
