---
author: normesta
title: UWP アプリでの SQL Server データベースの使用
description: UWP アプリでの SQL Server データベースの使用。
ms.author: normesta
ms.date: 11/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP, SQL Server, データベース
ms.localizationpriority: medium
ms.openlocfilehash: 31a173efbe30cffed85336a302ced504a4cad50d
ms.sourcegitcommit: ce45a2bc5ca6794e97d188166172f58590e2e434
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/06/2018
ms.locfileid: "1983493"
---
# <a name="use-a-sql-server-database-in-a-uwp-app"></a><span data-ttu-id="0150f-104">UWP アプリでの SQL Server データベースの使用</span><span class="sxs-lookup"><span data-stu-id="0150f-104">Use a SQL Server database in a UWP app</span></span>
<span data-ttu-id="0150f-105">アプリで [System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) 名前空間のクラスを使用して、SQL Server データベースに直接接続し、データを保存および取得することができます。</span><span class="sxs-lookup"><span data-stu-id="0150f-105">Your app can connect directly to a SQL Server database and then store and retrieve data by using classes in the [System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) namespace.</span></span>

<span data-ttu-id="0150f-106">このガイドでは、それを行う方法の 1 つを示します。</span><span class="sxs-lookup"><span data-stu-id="0150f-106">In this guide, we'll show you one way to do that.</span></span> <span data-ttu-id="0150f-107">[Northwind](https://docs.microsoft.com/dotnet/framework/data/adonet/sql/linq/downloading-sample-databases) サンプル データベースを SQL Server インスタンスにインストールし、ここで示すスニペットを使用して、Northwind サンプルのデータベースから取得した製品を表示する基本的な UI を作成します。</span><span class="sxs-lookup"><span data-stu-id="0150f-107">If you install the [Northwind](https://docs.microsoft.com/dotnet/framework/data/adonet/sql/linq/downloading-sample-databases) sample database onto your SQL Server instance, and then use these snippets, you'll end up with a basic UI that shows products from the Northwind sample database.</span></span>

![Northwind 製品](images/products-northwind.png)

<span data-ttu-id="0150f-109">このガイドで示すスニペットは、このもっと[完全なサンプル](https://github.com/StefanWickDev/IgniteDemos/tree/master/NorthwindDemo)に基づいています。</span><span class="sxs-lookup"><span data-stu-id="0150f-109">The snippets that appear in this guide are based on this more [complete sample](https://github.com/StefanWickDev/IgniteDemos/tree/master/NorthwindDemo).</span></span>

## <a name="first-set-up-your-solution"></a><span data-ttu-id="0150f-110">まず、ソリューションをセットアップする</span><span class="sxs-lookup"><span data-stu-id="0150f-110">First, set up your solution</span></span>

<span data-ttu-id="0150f-111">アプリを SQL Server データベースに直接接続するために、プロジェクトの最小バージョンが Fall Creators Update を対象にしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0150f-111">To connect your app directly to a SQL Server database, make sure that the minimum version of your project targets the Fall Creators update.</span></span>  <span data-ttu-id="0150f-112">UWP プロジェクトのプロパティ ページにその情報があります。</span><span class="sxs-lookup"><span data-stu-id="0150f-112">You can find that information in the properties page of your UWP project.</span></span>

![Windows SDK の最小バージョン](images/min-version-fall-creators.png)

<span data-ttu-id="0150f-114">マニフェスト デザイナーで、UWP プロジェクトの **Package.appxmanifest** ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="0150f-114">Open the **Package.appxmanifest** file of your UWP project in the manifest designer.</span></span>

<span data-ttu-id="0150f-115">**[機能]** タブで、**[エンタープライズ認証]** チェックボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="0150f-115">In the **Capabilities** tab, select the **Enterprise Authentication** checkbox.</span></span>

![エンタープライズ認証機能](images/enterprise-authentication.png)

<a id="use-data" />

## <a name="add-and-retrieve-data-in-a-sql-server-database"></a><span data-ttu-id="0150f-117">SQL Server データベースのデータの追加と取得</span><span class="sxs-lookup"><span data-stu-id="0150f-117">Add and retrieve data in a SQL Server database</span></span>

<span data-ttu-id="0150f-118">このセクションでは、以下のことを行います。</span><span class="sxs-lookup"><span data-stu-id="0150f-118">In this section,  we'll do these things:</span></span>

<span data-ttu-id="0150f-119">:1: 接続文字列を追加します。</span><span class="sxs-lookup"><span data-stu-id="0150f-119">:one: Add a connection string.</span></span>

<span data-ttu-id="0150f-120">:2: 製品データを保持するクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="0150f-120">:two: Create a class to hold product data.</span></span>

<span data-ttu-id="0150f-121">:3: SQL Server データベースから製品を取得します。</span><span class="sxs-lookup"><span data-stu-id="0150f-121">:three: Retrieve products from the SQL Server database.</span></span>

<span data-ttu-id="0150f-122">:4: 基本的なユーザー インターフェイスを追加します。</span><span class="sxs-lookup"><span data-stu-id="0150f-122">:four: Add a basic user interface.</span></span>

<span data-ttu-id="0150f-123">:5: UI に製品を追加します。</span><span class="sxs-lookup"><span data-stu-id="0150f-123">:five: Populate the UI with Products.</span></span>

>[!NOTE]
> <span data-ttu-id="0150f-124">このセクションでは、データ アクセス コードを編成する方法の 1 つを示します。</span><span class="sxs-lookup"><span data-stu-id="0150f-124">This section illustrates one way to organize your data access code.</span></span> <span data-ttu-id="0150f-125">つまり、[System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) を使用して、SQL Server データベースのデータを保存および取得する方法の例を示すだけです。</span><span class="sxs-lookup"><span data-stu-id="0150f-125">It's meant only to provide an example of how you can use  [System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) to store and retrieve data from a SQL Server database.</span></span> <span data-ttu-id="0150f-126">アプリケーションの設計に最も適した方法でコードを編成してください。</span><span class="sxs-lookup"><span data-stu-id="0150f-126">You can organize your code in any way that makes the most sense to your application's design.</span></span>

### <a name="add-a-connection-string"></a><span data-ttu-id="0150f-127">接続文字列を追加する</span><span class="sxs-lookup"><span data-stu-id="0150f-127">Add a connection string</span></span>

<span data-ttu-id="0150f-128">**App.xaml.cs** ファイルで、``App`` クラスにプロパティを追加します。これにより、ソリューションに含まれる他のクラスが接続文字列にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="0150f-128">In the **App.xaml.cs** file, add a property to the ``App`` class, that gives other classes in your solution access to the connection string.</span></span>

<span data-ttu-id="0150f-129">接続文字列は、SQL Server Express のインスタンスの Northwind データベースを指しています。</span><span class="sxs-lookup"><span data-stu-id="0150f-129">Our connection string points to the Northwind database in a SQL Server Express instance.</span></span>

```csharp
sealed partial class App : Application
{
    private string connectionString =
        @"Data Source=YourServerName\SQLEXPRESS;Initial Catalog=NORTHWIND;Integrated Security=SSPI";

    public string ConnectionString { get => connectionString; set => connectionString = value; }

    ...
}
```

### <a name="create-a-class-to-hold-product-data"></a><span data-ttu-id="0150f-130">製品データを保持するクラスを作成する</span><span class="sxs-lookup"><span data-stu-id="0150f-130">Create a class to hold product data</span></span>

<span data-ttu-id="0150f-131">XAML UI でこのクラスのプロパティに属性をバインドできるように、[INotifyPropertyChanged](https://msdn.microsoft.com/library/system.componentmodel.inotifypropertychanged.aspx) イベントを実装するクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="0150f-131">We'll create a class that implements the [INotifyPropertyChanged](https://msdn.microsoft.com/library/system.componentmodel.inotifypropertychanged.aspx) event so that we can bind attributes in our XAML UI to the properties in this class.</span></span>

```csharp
public class Product : INotifyPropertyChanged
{
    public int ProductID { get; set; }
    public string ProductCode { get { return ProductID.ToString(); } }
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public string UnitPriceString { get { return UnitPrice.ToString("######.00"); } }
    public int UnitsInStock { get; set; }
    public string UnitsInStockString { get { return UnitsInStock.ToString("#####0"); } }
    public int CategoryId { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
```

### <a name="retrieve-products-from-the-sql-server-database"></a><span data-ttu-id="0150f-132">SQL Server データベースから製品を取得する</span><span class="sxs-lookup"><span data-stu-id="0150f-132">Retrieve products from the SQL Server database</span></span>

<span data-ttu-id="0150f-133">Northwind サンプル データベースから製品を取得し、``Product`` インスタンスの [ObservableCollection](https://msdn.microsoft.com/library/windows/apps/ms668604.aspx) コレクションとしてそれらを返すメソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="0150f-133">Create a method that gets products from the Northwind sample database, and then returns them as an [ObservableCollection](https://msdn.microsoft.com/library/windows/apps/ms668604.aspx) collection of ``Product`` instances.</span></span>

```csharp
public ObservableCollection<Product> GetProducts(string connectionString)
{
    const string GetProductsQuery = "select ProductID, ProductName, QuantityPerUnit," +
       " UnitPrice, UnitsInStock, Products.CategoryID " +
       " from Products inner join Categories on Products.CategoryID = Categories.CategoryID " +
       " where Discontinued = 0";

    var products = new ObservableCollection<Product>();
    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = GetProductsQuery;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product();
                            product.ProductID = reader.GetInt32(0);
                            product.ProductName = reader.GetString(1);
                            product.QuantityPerUnit = reader.GetString(2);
                            product.UnitPrice = reader.GetDecimal(3);
                            product.UnitsInStock = reader.GetInt16(4);
                            product.CategoryId = reader.GetInt32(5);
                            products.Add(product);
                        }
                    }
                }
            }
        }
        return products;
    }
    catch (Exception eSql)
    {
        Debug.WriteLine("Exception: " + eSql.Message);
    }
    return null;
}
```

### <a name="add-a-basic-user-interface"></a><span data-ttu-id="0150f-134">基本的なユーザー インターフェイスを追加する</span><span class="sxs-lookup"><span data-stu-id="0150f-134">Add a basic user interface</span></span>

 <span data-ttu-id="0150f-135">次の XAML を、UWP プロジェクトの **MainPage.xaml** ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="0150f-135">Add the following XAML to the **MainPage.xaml** file of the UWP project.</span></span>

 <span data-ttu-id="0150f-136">この XAML では、[ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) を作成して前のスニペットで返された各製品を表示し、[ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) 内の各行の属性を ``Product`` クラスで定義したプロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="0150f-136">This XAML creates a [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) to show each product that you returned in the previous snippet, and binds the attributes of each row in the [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) to the properties that we defined in the ``Product`` class.</span></span>

```xml
<Grid Background="{ThemeResource SystemControlAcrylicWindowBrush}">
    <RelativePanel>
        <ListView Name="InventoryList"
                  SelectionMode="Single"
                  ScrollViewer.VerticalScrollBarVisibility="Auto"
                  ScrollViewer.IsVerticalRailEnabled="True"
                  ScrollViewer.VerticalScrollMode="Enabled"
                  ScrollViewer.HorizontalScrollMode="Enabled"
                  ScrollViewer.HorizontalScrollBarVisibility="Auto"
                  ScrollViewer.IsHorizontalRailEnabled="True"
                  Margin="20">
            <ListView.HeaderTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal"  >
                        <TextBlock Text="ID" Margin="8,0" Width="50" Foreground="DarkRed" />
                        <TextBlock Text="Product description" Width="300" Foreground="DarkRed" />
                        <TextBlock Text="Packaging" Width="200" Foreground="DarkRed" />
                        <TextBlock Text="Price" Width="80" Foreground="DarkRed" />
                        <TextBlock Text="In stock" Width="80" Foreground="DarkRed" />
                    </StackPanel>
                </DataTemplate>
            </ListView.HeaderTemplate>
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:Product">
                    <StackPanel Orientation="Horizontal" >
                        <TextBlock Name="ItemId"
                                    Text="{x:Bind ProductCode}"
                                    Width="50" />
                        <TextBlock Name="ItemName"
                                    Text="{x:Bind ProductName}"
                                    Width="300" />
                        <TextBlock Text="{x:Bind QuantityPerUnit}"
                                   Width="200" />
                        <TextBlock Text="{x:Bind UnitPriceString}"
                                   Width="80" />
                        <TextBlock Text="{x:Bind UnitsInStockString}"
                                   Width="80" />
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </RelativePanel>
</Grid>
```

### <a name="show-products-in-the-listview"></a><span data-ttu-id="0150f-137">ListView で製品を表示する</span><span class="sxs-lookup"><span data-stu-id="0150f-137">Show products in the ListView</span></span>

<span data-ttu-id="0150f-138">**MainPage.xaml.cs** ファイルを開き、[ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) の **ItemSource** プロパティを ``Product`` インスタンスの [ObservableCollection](https://msdn.microsoft.com/library/windows/apps/ms668604.aspx) に設定するコードを、``MainPage`` クラスのコンストラクターに追加します。</span><span class="sxs-lookup"><span data-stu-id="0150f-138">Open the **MainPage.xaml.cs** file, and add code to the constructor of the ``MainPage`` class that sets the **ItemSource** property of the [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) to the [ObservableCollection](https://msdn.microsoft.com/library/windows/apps/ms668604.aspx) of ``Product`` instances.</span></span>

```csharp
public MainPage()
{
    this.InitializeComponent();
    InventoryList.ItemsSource = GetProducts((App.Current as App).ConnectionString);
}
```

<span data-ttu-id="0150f-139">プロジェクトを開始すると、Northwind サンプル データベースから取得した製品が UI に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0150f-139">Start the project and see products from the Northwind sample database appear in the UI.</span></span>

![Northwind 製品](images/products-northwind.png)

<span data-ttu-id="0150f-141">[System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) 名前空間を調べて、SQL Server データベース内のデータを使用して他に何ができるかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="0150f-141">Explore the [System.Data.SqlClient](https://msdn.microsoft.com/library/system.data.sqlclient.aspx) namespace to see what other things you can do with data in your SQL Server database.</span></span>

## <a name="trouble-connecting-to-your-database"></a><span data-ttu-id="0150f-142">データベースへの接続で問題が発生した場合</span><span class="sxs-lookup"><span data-stu-id="0150f-142">Trouble connecting to your database?</span></span>

<span data-ttu-id="0150f-143">ほとんどの場合、SQL Server 構成のいくつかの側面を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0150f-143">In most cases, some aspect of the SQL Server configuration needs to be changed.</span></span> <span data-ttu-id="0150f-144">Windows フォームや WPF アプリケーションなどの別の種類のデスクトップ アプリケーションからデータベースに接続できる場合は、SQL Server の TCP/IP を有効にしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0150f-144">If you're able to connect to your database from another type of desktop application such as a Windows Forms or WPF application, ensure that you've enabled TCP/IP for SQL Server.</span></span> <span data-ttu-id="0150f-145">これは、**コンピューターの管理**コンソールで行うことができます。</span><span class="sxs-lookup"><span data-stu-id="0150f-145">You can do that in the **Computer Management** console.</span></span>

![コンピューターの管理](images/computer-management.png)

<span data-ttu-id="0150f-147">次に、SQL Server Browser サービスが実行されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0150f-147">Then, make sure that your SQL Server Browser service is running.</span></span>

![SQL Server Browser サービス](images/sql-browser-service.png)

## <a name="next-steps"></a><span data-ttu-id="0150f-149">次のステップ</span><span class="sxs-lookup"><span data-stu-id="0150f-149">Next steps</span></span>

**<span data-ttu-id="0150f-150">軽量なデータベースを使用して、ユーザー デバイスにデータを保存する</span><span class="sxs-lookup"><span data-stu-id="0150f-150">Use a light-weight database to store data on the users device</span></span>**

<span data-ttu-id="0150f-151">「[UWP アプリでの SQLite データベースの使用](sqlite-databases.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0150f-151">See [Use a SQLite database in a UWP app](sqlite-databases.md).</span></span>

**<span data-ttu-id="0150f-152">異なるプラットフォームにわたる異なるアプリの間でコードを共有する</span><span class="sxs-lookup"><span data-stu-id="0150f-152">Share code between different apps across different platforms</span></span>**

<span data-ttu-id="0150f-153">「[デスクトップと UWP でコードを共有する](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0150f-153">See [Share code between desktop and UWP](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-migrate).</span></span>

**<span data-ttu-id="0150f-154">Azure SQL バックエンドでマスター/詳細ページを追加する</span><span class="sxs-lookup"><span data-stu-id="0150f-154">Add master detail pages with Azure SQL back ends</span></span>**

<span data-ttu-id="0150f-155">「[顧客注文データベースのサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0150f-155">See [Customer Orders Database sample](https://github.com/Microsoft/Windows-appsample-customers-orders-database).</span></span>