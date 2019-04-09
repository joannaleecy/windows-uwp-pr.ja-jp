---
title: 顧客データベース アプリケーションの作成
description: 顧客のデータベース アプリケーションを作成し、基本的なエンタープライズ アプリの機能を実装する方法について説明します。
keywords: enterprise、チュートリアル、顧客データを読み取り、更新の削除、REST、認証を作成します。
ms.date: 05/07/2018
ms.topic: article
ms.localizationpriority: med
ms.openlocfilehash: 7bd3a180762c3ef06d7c24ae001fb2c7fb7fc55e
ms.sourcegitcommit: 6df46d7d5b5522805eab11a9c0e07754f28673c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/02/2019
ms.locfileid: "58808300"
---
# <a name="tutorial-create-a-customer-database-application"></a><span data-ttu-id="47192-104">チュートリアル:顧客データベース アプリケーションの作成</span><span class="sxs-lookup"><span data-stu-id="47192-104">Tutorial: Create a customer database application</span></span>

<span data-ttu-id="47192-105">このチュートリアルでは、顧客の一覧を管理するための簡単なアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="47192-105">This tutorial creates a simple app for managing a list of customers.</span></span> <span data-ttu-id="47192-106">これを行うには、UWP でエンタープライズ アプリケーションの基本的な概念の選択範囲が導入されています。</span><span class="sxs-lookup"><span data-stu-id="47192-106">In doing so, it introduces a selection of basic concepts for enterprise apps in UWP.</span></span> <span data-ttu-id="47192-107">次の方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="47192-107">You'll learn how to:</span></span>

* <span data-ttu-id="47192-108">作成、読み取り、更新プログラムを実装し、ローカルの SQL データベースに対する操作を削除します。</span><span class="sxs-lookup"><span data-stu-id="47192-108">Implement Create, Read, Update, and Delete operations against a local SQL database.</span></span>
* <span data-ttu-id="47192-109">表示し、編集、UI 内の顧客データへのデータ グリッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="47192-109">Add a data grid, to display and edit customer data in your UI.</span></span>
* <span data-ttu-id="47192-110">基本的なフォーム レイアウトで UI 要素を配置します。</span><span class="sxs-lookup"><span data-stu-id="47192-110">Arrange UI elements together in a basic form layout.</span></span>

<span data-ttu-id="47192-111">このチュートリアルの開始点は、最小限の UI との簡略化バージョンに基づく機能によるシングル ページ アプリ、[顧客注文データベース サンプル アプリ](https://github.com/Microsoft/Windows-appsample-customers-orders-database)します。</span><span class="sxs-lookup"><span data-stu-id="47192-111">The starting point for this tutorial is a single-page app with minimal UI and functionality, based on a simplified version of the [Customer Orders Database sample app](https://github.com/Microsoft/Windows-appsample-customers-orders-database).</span></span> <span data-ttu-id="47192-112">記述されてC#XAML、およびこれら両方の言語の基礎知識が得られたらを想定しているとします。</span><span class="sxs-lookup"><span data-stu-id="47192-112">It's written in C# and XAML, and we're expecting that you've got a basic familiarity with both those languages.</span></span>

![作業用アプリのメイン ページ](images/customer-database-tutorial/customer-list.png)

### <a name="prerequisites"></a><span data-ttu-id="47192-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="47192-114">Prerequisites</span></span>

* [<span data-ttu-id="47192-115">Visual Studio と Windows 10 SDK の最新バージョンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="47192-115">Ensure you have the latest version of Visual Studio and the Windows 10 SDK</span></span>](https://developer.microsoft.com/windows/downloads/windows-10-sdk)
* [<span data-ttu-id="47192-116">複製するか、顧客データベース チュートリアルのサンプルをダウンロード</span><span class="sxs-lookup"><span data-stu-id="47192-116">Clone or download the Customer Database Tutorial sample</span></span>](https://aka.ms/customer-database-tutorial)

<span data-ttu-id="47192-117">開き、プロジェクトを編集するには複製/をダウンロードしたら、リポジトリ、 **CustomerDatabaseTutorial.sln** Visual Studio を使用します。</span><span class="sxs-lookup"><span data-stu-id="47192-117">After you've cloned/downloaded the repo, you can edit the project by opening **CustomerDatabaseTutorial.sln** with Visual Studio.</span></span>

> [!NOTE]
> <span data-ttu-id="47192-118">チェック アウト、[完全な顧客注文データベース サンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)に、このチュートリアルに基づいていますが、アプリを参照してください。</span><span class="sxs-lookup"><span data-stu-id="47192-118">Check out the [full Customer Orders Database sample](https://github.com/Microsoft/Windows-appsample-customers-orders-database) to see the app this tutorial was based on.</span></span>

## <a name="part-1-code-of-interest"></a><span data-ttu-id="47192-119">作業 1:目的のコード</span><span class="sxs-lookup"><span data-stu-id="47192-119">Part 1: Code of Interest</span></span>

<span data-ttu-id="47192-120">アプリを開いた後すぐに実行する場合、空の画面の上部にある、いくつかのボタンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="47192-120">If you run your app immediately after opening it, you'll see a few buttons at the top of a blank screen.</span></span> <span data-ttu-id="47192-121">表示はされませんが、アプリが既にいくつかのテスト ユーザーのプロビジョニングされたローカルの SQLite データベースに含まれます。</span><span class="sxs-lookup"><span data-stu-id="47192-121">Though it's not visible to you, the app already includes a local SQLite database provisioned with a few test customers.</span></span> <span data-ttu-id="47192-122">ここは、顧客を表示する UI コントロールを実装することで開始し、データベースに対する処理の追加に移ります。</span><span class="sxs-lookup"><span data-stu-id="47192-122">From here, you'll start by implementing a UI control to display those customers, and then move on to adding in operations against the database.</span></span> <span data-ttu-id="47192-123">開始する前にする操作をここでは。</span><span class="sxs-lookup"><span data-stu-id="47192-123">Before you begin, here's where you'll be working.</span></span>

### <a name="views"></a><span data-ttu-id="47192-124">ビュー</span><span class="sxs-lookup"><span data-stu-id="47192-124">Views</span></span>

<span data-ttu-id="47192-125">**CustomerListPage.xaml**はアプリのビューは、このチュートリアルでは、1 つのページの UI を定義します。</span><span class="sxs-lookup"><span data-stu-id="47192-125">**CustomerListPage.xaml** is the app's View, which defines the UI for the single page in this tutorial.</span></span> <span data-ttu-id="47192-126">いつでも追加または UI では、視覚的要素を変更する必要があることを行いこのファイル。</span><span class="sxs-lookup"><span data-stu-id="47192-126">Any time you need to add or change a visual element in the UI, you'll do it in this file.</span></span> <span data-ttu-id="47192-127">このチュートリアルではこれらの要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="47192-127">This tutorial will walk you through adding these elements:</span></span>

* <span data-ttu-id="47192-128">A **RadDataGrid**を表示すると、顧客を編集します。</span><span class="sxs-lookup"><span data-stu-id="47192-128">A **RadDataGrid** for displaying and editing your customers.</span></span> 
* <span data-ttu-id="47192-129">A **StackPanel**新しい顧客の初期値を設定します。</span><span class="sxs-lookup"><span data-stu-id="47192-129">A **StackPanel** to set the initial values for a new customer.</span></span>

### <a name="viewmodels"></a><span data-ttu-id="47192-130">ViewModels</span><span class="sxs-lookup"><span data-stu-id="47192-130">ViewModels</span></span>

<span data-ttu-id="47192-131">**ViewModels\CustomerListPageViewModel.cs**はアプリケーションの基本的なロジックが存在します。</span><span class="sxs-lookup"><span data-stu-id="47192-131">**ViewModels\CustomerListPageViewModel.cs** is where the fundamental logic of the app is located.</span></span> <span data-ttu-id="47192-132">ビューで実行されるすべてのユーザー アクションは、このファイルを処理するために渡されます。</span><span class="sxs-lookup"><span data-stu-id="47192-132">Every user action taken in the view will be passed into this file for processing.</span></span> <span data-ttu-id="47192-133">このチュートリアルで、新しいコードを追加し、次のメソッドの実装します。</span><span class="sxs-lookup"><span data-stu-id="47192-133">In this tutorial, you'll add some new code, and implement the following methods:</span></span>

* <span data-ttu-id="47192-134">**CreateNewCustomerAsync**、新しい CustomerViewModel オブジェクトを初期化します。</span><span class="sxs-lookup"><span data-stu-id="47192-134">**CreateNewCustomerAsync**, which initializes a new CustomerViewModel object.</span></span>
* <span data-ttu-id="47192-135">**DeleteNewCustomerAsync**UI に表示される前に新しい顧客を削除します。</span><span class="sxs-lookup"><span data-stu-id="47192-135">**DeleteNewCustomerAsync**, which removes a new customer before it's displayed in the UI.</span></span>
* <span data-ttu-id="47192-136">**DeleteAndUpdateAsync**delete ボタンのロジックを処理します。</span><span class="sxs-lookup"><span data-stu-id="47192-136">**DeleteAndUpdateAsync**, which handles the delete button's logic.</span></span>
* <span data-ttu-id="47192-137">**GetCustomerListAsync**、データベースから顧客の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="47192-137">**GetCustomerListAsync**, which retrieves a list of customers from the database.</span></span>
* <span data-ttu-id="47192-138">**SaveInitialChangesAsync**データベースに新しい顧客の情報を追加します。</span><span class="sxs-lookup"><span data-stu-id="47192-138">**SaveInitialChangesAsync**, which adds a new customer's information to the database.</span></span>
* <span data-ttu-id="47192-139">**UpdateCustomersAsync**、すべての顧客を追加または削除を反映するように UI が更新されます。</span><span class="sxs-lookup"><span data-stu-id="47192-139">**UpdateCustomersAsync**, which refreshes the UI to reflect any customers added or deleted.</span></span>

<span data-ttu-id="47192-140">**CustomerViewModel**が最近変更されたがかどうかを追跡する顧客の情報用のラッパーです。</span><span class="sxs-lookup"><span data-stu-id="47192-140">**CustomerViewModel** is a wrapper for a customer's information, which tracks whether or not it's been recently modified.</span></span> <span data-ttu-id="47192-141">このクラスには何も追加する必要はありませんが、別の場所を追加するコードの一部は参照します。</span><span class="sxs-lookup"><span data-stu-id="47192-141">You won't need to add anything to this class, but some of the code you'll add elsewhere will reference it.</span></span>

<span data-ttu-id="47192-142">サンプルの構築方法の詳細については、のチェック アウト、[アプリ構造の概要](../enterprise/customer-database-app-structure.md)します。</span><span class="sxs-lookup"><span data-stu-id="47192-142">For more information on how the sample is constructed, check out the [app structure overview](../enterprise/customer-database-app-structure.md).</span></span>

## <a name="part-2-add-the-datagrid"></a><span data-ttu-id="47192-143">パート 2:DataGrid を追加します。</span><span class="sxs-lookup"><span data-stu-id="47192-143">Part 2: Add the DataGrid</span></span>

<span data-ttu-id="47192-144">顧客データを操作を開始する前に、これらの顧客を表示する UI コントロールを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-144">Before you begin to operate on customer data, you'll need to add a UI control to display those customers.</span></span> <span data-ttu-id="47192-145">事前に作成されたサード パーティには、使用する**RadDataGrid**コントロール。</span><span class="sxs-lookup"><span data-stu-id="47192-145">To do this, we'll be using a pre-made third-party **RadDataGrid** control.</span></span> <span data-ttu-id="47192-146">**Telerik.UI.for.UniversalWindowsPlatform** NuGet パッケージは、このプロジェクトに既に含まれています。</span><span class="sxs-lookup"><span data-stu-id="47192-146">The **Telerik.UI.for.UniversalWindowsPlatform** NuGet package has already been included in this project.</span></span> <span data-ttu-id="47192-147">グリッドをプロジェクトに追加してみましょう。</span><span class="sxs-lookup"><span data-stu-id="47192-147">Let's add the grid to our project.</span></span>

1. <span data-ttu-id="47192-148">開いている**Views\CustomerListPage.xaml**ソリューション エクスプ ローラーから。</span><span class="sxs-lookup"><span data-stu-id="47192-148">Open **Views\CustomerListPage.xaml** from the Solution Explorer.</span></span> <span data-ttu-id="47192-149">内のコードの次の行を追加、**ページ**データ グリッドを含む Telerik 名前空間へのマッピングを宣言するタグ。</span><span class="sxs-lookup"><span data-stu-id="47192-149">Add the following line of code within the **Page** tag to declare a mapping to the Telerik namespace containing the data grid.</span></span>

    ```xaml
        xmlns:telerikGrid="using:Telerik.UI.Xaml.Controls.Grid"
    ```

2. <span data-ttu-id="47192-150">以下、 **CommandBar**メイン内**RelativePanel** 、ビューの追加、 **RadDataGrid**いくつかの基本的な構成オプションを使用して、コントロール。</span><span class="sxs-lookup"><span data-stu-id="47192-150">Below the **CommandBar** within the main **RelativePanel** of the View, add a **RadDataGrid** control, with some basic configuration options:</span></span>

    ```xaml
    <Grid
        x:Name="CustomerListRoot"
        Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <RelativePanel>
            <CommandBar
                x:Name="mainCommandBar"
                HorizontalAlignment="Stretch"
                Background="AliceBlue">
                <!--CommandBar content-->
            </CommandBar>
            <telerikGrid:RadDataGrid
                x:Name="DataGrid"
                BorderThickness="0"
                ColumnDataOperationsMode="Flyout"
                GridLinesVisibility="None"
                GroupPanelPosition="Left"
                RelativePanel.AlignLeftWithPanel="True"
                RelativePanel.AlignRightWithPanel="True"
                RelativePanel.Below="mainCommandBar" />
        </RelativePanel>
    </Grid>
    ```

3. <span data-ttu-id="47192-151">データ グリッドを追加しましたが、データを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-151">You've added the data grid, but it needs data to display.</span></span> <span data-ttu-id="47192-152">これには、次のコード行を追加します。</span><span class="sxs-lookup"><span data-stu-id="47192-152">Add the following lines of code to it:</span></span>

    ```xaml
    ItemsSource="{x:Bind ViewModel.Customers}"
    UserEditMode="Inline"
    ```
    <span data-ttu-id="47192-153">表示するにはデータのソースを定義するところ**RadDataGrid**の UI ロジックのほとんどを処理します。</span><span class="sxs-lookup"><span data-stu-id="47192-153">Now that you have defined a source of data to display, **RadDataGrid** will handle most of the UI logic for you.</span></span> <span data-ttu-id="47192-154">ただし、プロジェクトを実行する場合もが表示されなくなりますデータ表示します。</span><span class="sxs-lookup"><span data-stu-id="47192-154">However, if you run your project, you still won't see any data on display.</span></span> <span data-ttu-id="47192-155">ViewModel がまだロードされていないためにです。</span><span class="sxs-lookup"><span data-stu-id="47192-155">That's because the ViewModel isn't loading it yet.</span></span>

![空のアプリで顧客がありません。](images/customer-database-tutorial/blank-customer-list.png)

## <a name="part-3-read-customers"></a><span data-ttu-id="47192-157">パート 3:顧客を読み取り</span><span class="sxs-lookup"><span data-stu-id="47192-157">Part 3: Read customers</span></span>

<span data-ttu-id="47192-158">初期化されると、 **ViewModels\CustomerListPageViewModel.cs**呼び出し、 **GetCustomerListAsync**メソッド。</span><span class="sxs-lookup"><span data-stu-id="47192-158">When it's initialized, **ViewModels\CustomerListPageViewModel.cs** calls the **GetCustomerListAsync** method.</span></span> <span data-ttu-id="47192-159">チュートリアルでは、SQLite からテストの顧客データを取得するメソッドの必要があるデータベースが含まれます。</span><span class="sxs-lookup"><span data-stu-id="47192-159">That method needs to retrieve the test Customer data from the SQLite database that's included in the tutorial.</span></span>

1. <span data-ttu-id="47192-160">**ViewModels\CustomerListPageViewModel.cs**、更新、 **GetCustomerListAsync**メソッドをこのコード。</span><span class="sxs-lookup"><span data-stu-id="47192-160">In **ViewModels\CustomerListPageViewModel.cs**, update your **GetCustomerListAsync** method with this code:</span></span>

    ```csharp
    public async Task GetCustomerListAsync()
    {
        var customers = await App.Repository.Customers.GetAsync(); 
        if (customers == null)
        {
            return;
        }
        await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
        {
            Customers.Clear();
            foreach (var c in customers)
            {
                Customers.Add(new CustomerViewModel(c));
            }
        });
    }
    ```
    <span data-ttu-id="47192-161">**GetCustomerListAsync**ビューモデルが読み込まれますが、この手順では、前に何も出力しないメソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="47192-161">The **GetCustomerListAsync** method is called when the ViewModel is loaded, but before this step, it didn't do anything.</span></span> <span data-ttu-id="47192-162">ここへの呼び出しが追加されました、 **GetAsync**メソッド**リポジトリ/SqlCustomerRepository**します。</span><span class="sxs-lookup"><span data-stu-id="47192-162">Here, we've added a call to the **GetAsync** method in **Repository/SqlCustomerRepository**.</span></span> <span data-ttu-id="47192-163">これによって、Customer オブジェクトの列挙可能なコレクションを取得するリポジトリにお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="47192-163">This allows it to contact the repository to retrieve an enumerable collection of Customer objects.</span></span> <span data-ttu-id="47192-164">解析の個々 のオブジェクトの内部に追加する前に**ObservableCollection**表示および編集できるようにします。</span><span class="sxs-lookup"><span data-stu-id="47192-164">It then parses them into individual objects, before adding them to its internal **ObservableCollection** so they can be displayed and edited.</span></span>

2. <span data-ttu-id="47192-165">-アプリの実行の顧客のリストを表示するデータ グリッドを今すぐ表示されます。</span><span class="sxs-lookup"><span data-stu-id="47192-165">Run your app - you'll now see the data grid displaying the list of customers.</span></span>

![最初に顧客のリスト](images/customer-database-tutorial/initial-customers.png)

## <a name="part-4-edit-customers"></a><span data-ttu-id="47192-167">パート 4:顧客を編集します。</span><span class="sxs-lookup"><span data-stu-id="47192-167">Part 4: Edit customers</span></span>

<span data-ttu-id="47192-168">ダブルクリックして、データ グリッド内のエントリを編集することができますが、UI に加えた変更はすべてが分離コード内の顧客のコレクションにも行われることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-168">You can edit the entries in the data grid by double-clicking them, but you need to ensure that any changes you make in the UI are also made to your collection of customers in the code-behind.</span></span> <span data-ttu-id="47192-169">つまり、双方向データ バインディングを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-169">This means you'll have to implement two-way data binding.</span></span> <span data-ttu-id="47192-170">この詳細についてを実行する場合に、チェック アウト、[データ バインディングの概要](../get-started/display-customers-in-list-learning-track.md)します。</span><span class="sxs-lookup"><span data-stu-id="47192-170">If you want more information about this, check out our [introduction to data binding](../get-started/display-customers-in-list-learning-track.md).</span></span>

1. <span data-ttu-id="47192-171">最初に、宣言する**ViewModels\CustomerListPageViewModel.cs**実装、 **INotifyPropertyChanged**インターフェイス。</span><span class="sxs-lookup"><span data-stu-id="47192-171">First, declare that **ViewModels\CustomerListPageViewModel.cs** implements the **INotifyPropertyChanged** interface:</span></span>

    ```csharp
    public class CustomerListPageViewModel : INotifyPropertyChanged
    ```

2. <span data-ttu-id="47192-172">次に、クラスのメイン本体では、次のイベントとメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="47192-172">Then, within the main body of the class, add the following event and method:</span></span>

    ```csharp
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    ```

    <span data-ttu-id="47192-173">**OnPropertyChanged**メソッドを簡単に発生させる、setter、 **PropertyChanged**双方向データ バインドに必要なは、そのイベント。</span><span class="sxs-lookup"><span data-stu-id="47192-173">The **OnPropertyChanged** method makes it easy for your setters to raise the **PropertyChanged** event, which is necessary for two-way data binding.</span></span>

3. <span data-ttu-id="47192-174">更新の set アクセス操作子**SelectedCustomer**のこの関数の呼び出しで。</span><span class="sxs-lookup"><span data-stu-id="47192-174">Update the setter for **SelectedCustomer** with this function call:</span></span>

    ```csharp
    public CustomerViewModel SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            if (_selectedCustomer != value)
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }
    }
    ```

4. <span data-ttu-id="47192-175">**Views\CustomerListPage.xaml**、追加、 **SelectedCustomer**プロパティをデータ グリッドに表示します。</span><span class="sxs-lookup"><span data-stu-id="47192-175">In **Views\CustomerListPage.xaml**, add the **SelectedCustomer** property to your data grid.</span></span>

    ```xaml
    SelectedItem="{x:Bind ViewModel.SelectedCustomer, Mode=TwoWay}"
    ```

    <span data-ttu-id="47192-176">これにより、データ グリッドで、ユーザーの選択が分離コード内の対応する顧客オブジェクトに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="47192-176">This associates the user's selection in the data grid with the corresponding Customer object in the code-behind.</span></span> <span data-ttu-id="47192-177">TwoWay バインド モードには、そのオブジェクトに反映されるまで、UI で行われた変更ができます。</span><span class="sxs-lookup"><span data-stu-id="47192-177">The TwoWay binding mode allows the changes made in the UI to be reflected on that object.</span></span>

5. <span data-ttu-id="47192-178">アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="47192-178">Run your app.</span></span> <span data-ttu-id="47192-179">お客様は、グリッドに表示され、UI を基になるデータに変更を加えることができますようになりました。</span><span class="sxs-lookup"><span data-stu-id="47192-179">You can now see the customers displayed in the grid, and make changes to the underlying data through your UI.</span></span>

![データ グリッド内の顧客の編集](images/customer-database-tutorial/edit-customer-inline.png)

## <a name="part-5-update-customers"></a><span data-ttu-id="47192-181">パート 5:お客様を更新します。</span><span class="sxs-lookup"><span data-stu-id="47192-181">Part 5: Update customers</span></span>

<span data-ttu-id="47192-182">これで、表示して、顧客を編集できるは、データベースに変更をプッシュし、他のユーザーによって行われたすべての更新プログラムを取得できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-182">Now that you can see and edit your customers, you'll need to be able to push your changes to the database, and to pull any updates that have been made by others.</span></span>

1. <span data-ttu-id="47192-183">戻り**ViewModels\CustomerListPageViewModel.cs**に移動し、 **UpdateCustomersAsync**メソッド。</span><span class="sxs-lookup"><span data-stu-id="47192-183">Return to **ViewModels\CustomerListPageViewModel.cs**, and navigate to the **UpdateCustomersAsync** method.</span></span> <span data-ttu-id="47192-184">このコードは、データベースに変更をプッシュして、新しい情報を取得すると、更新します。</span><span class="sxs-lookup"><span data-stu-id="47192-184">Update it with this code, to push changes to the database and to retrieve any new information:</span></span>

    ```csharp
    public async Task UpdateCustomersAsync()
    {
        foreach (var modifiedCustomer in Customers
            .Where(x => x.IsModified).Select(x => x.Model))
        {
            await App.Repository.Customers.UpsertAsync(modifiedCustomer);
        }
        await GetCustomerListAsync();
    }
    ```
    <span data-ttu-id="47192-185">このコードを利用、 **IsModified**プロパティの**ViewModels\CustomerViewModel.cs**顧客が変更されるたびに自動的に更新されます。</span><span class="sxs-lookup"><span data-stu-id="47192-185">This code utilizes the **IsModified** property of **ViewModels\CustomerViewModel.cs**, which is automatically updated whenever the customer is changed.</span></span> <span data-ttu-id="47192-186">これにより、のみ更新された顧客からデータベースに変更をプッシュして、不要な呼び出しを回避することができます。</span><span class="sxs-lookup"><span data-stu-id="47192-186">This allows you to avoid unnecessary calls, and to only push changes from updated customers to the database.</span></span>

## <a name="part-6-create-a-new-customer"></a><span data-ttu-id="47192-187">パート 6:新しい顧客を作成します。</span><span class="sxs-lookup"><span data-stu-id="47192-187">Part 6: Create a new customer</span></span>

<span data-ttu-id="47192-188">新しい顧客を追加するように、UI にそのプロパティの値を指定する前に追加する場合、空白行として、顧客が表示されます、課題を表示します。</span><span class="sxs-lookup"><span data-stu-id="47192-188">Adding a new customer presents a challenge, as the customer will appear as a blank row if you add it to the UI before providing values for its properties.</span></span> <span data-ttu-id="47192-189">問題ないが、ここで私たちを容易に顧客の初期値を設定します。</span><span class="sxs-lookup"><span data-stu-id="47192-189">That's not a problem, but here we'll make it easier to set a customer's initial values.</span></span> <span data-ttu-id="47192-190">このチュートリアルで、単純な折りたたみ可能なパネルを追加しますが、詳細については、追加した場合、この目的のため、別のページを作成できます。</span><span class="sxs-lookup"><span data-stu-id="47192-190">In this tutorial, we'll add a simple collapsible panel, but if you had more information to add you could create a separate page for this purpose.</span></span>

### <a name="update-the-code-behind"></a><span data-ttu-id="47192-191">分離コードを更新します。</span><span class="sxs-lookup"><span data-stu-id="47192-191">Update the code-behind</span></span>

1. <span data-ttu-id="47192-192">新しいプライベート フィールドとパブリック プロパティを追加**ViewModels\CustomerListPageViewModel.cs**します。</span><span class="sxs-lookup"><span data-stu-id="47192-192">Add a new private field and public property to **ViewModels\CustomerListPageViewModel.cs**.</span></span> <span data-ttu-id="47192-193">パネルが表示されるかどうかを制御するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="47192-193">This will be used to control whether or not the panel is visible.</span></span>

    ```csharp
    private bool _addingNewCustomer = false;

    public bool AddingNewCustomer
    {
        get => _addingNewCustomer;
        set
        {
            if (_addingNewCustomer != value)
            {
                _addingNewCustomer = value;
                OnPropertyChanged();
            }
        }
    }
    ```

2. <span data-ttu-id="47192-194">値の逆元、ViewModel に新しいパブリック プロパティを追加**AddingNewCustomer**します。</span><span class="sxs-lookup"><span data-stu-id="47192-194">Add a new public property to the ViewModel, an inverse of the value of **AddingNewCustomer**.</span></span> <span data-ttu-id="47192-195">パネルが表示されたら、通常コマンド バーのボタンを無効にするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="47192-195">This will be used to disable the regular command bar buttons when the panel is visible.</span></span>

    ```csharp
    public bool EnableCommandBar => !AddingNewCustomer;
    ```
    <span data-ttu-id="47192-196">折りたたみ可能なパネルを表示し、そこを編集する顧客を作成する方法を今すぐ必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-196">You'll now need a way to display the collapsible panel, and to create a customer to edit within it.</span></span> 

3. <span data-ttu-id="47192-197">新しく作成された顧客を保持するために、ViewModel に新しいプライベート フィーンドおよびパブリック プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="47192-197">Add a new private fiend and public property to the ViewModel, to hold the newly created customer.</span></span>

    ```csharp
    private CustomerViewModel _newCustomer;

    public CustomerViewModel NewCustomer
    {
        get => _newCustomer;
        set
        {
            if (_newCustomer != value)
            {
                _newCustomer = value;
                OnPropertyChanged();
            }
        }
    }
    ```

2.  <span data-ttu-id="47192-198">更新プログラム、 **CreateNewCustomerAsync**メソッドを新しい顧客を作成、リポジトリに追加され、選択した顧客として設定します。</span><span class="sxs-lookup"><span data-stu-id="47192-198">Update your **CreateNewCustomerAsync** method to create a new customer, add it to the repository, and set it as the selected customer:</span></span>

    ```csharp
    public async Task CreateNewCustomerAsync()
    {
        CustomerViewModel newCustomer = new CustomerViewModel(new Models.Customer());
        NewCustomer = newCustomer;
        await App.Repository.Customers.UpsertAsync(NewCustomer.Model);
        AddingNewCustomer = true;
    }
    ```

3. <span data-ttu-id="47192-199">更新、 **SaveInitialChangesAsync**リポジトリに新しく作成された顧客を追加するメソッド、UI を更新し、パネルを閉じます。</span><span class="sxs-lookup"><span data-stu-id="47192-199">Update the **SaveInitialChangesAsync** method to add a newly-created customer to the repository, update the UI, and close the panel.</span></span>

    ```csharp
    public async Task SaveInitialChangesAsync()
    {
        await App.Repository.Customers.UpsertAsync(NewCustomer.Model);
        await UpdateCustomersAsync();
        AddingNewCustomer = false;
    }
    ```
4. <span data-ttu-id="47192-200">Setter の最後の行として次のコード行を追加**AddingNewCustomer**:</span><span class="sxs-lookup"><span data-stu-id="47192-200">Add the following line of code as the final line in the setter for **AddingNewCustomer**:</span></span>

    ```csharp
    OnPropertyChanged(nameof(EnableCommandBar));
    ```

    <span data-ttu-id="47192-201">これにより**EnableCommandBar**が自動的に更新されるたびに**AddingNewCustomer**が変更されました。</span><span class="sxs-lookup"><span data-stu-id="47192-201">This will ensure that **EnableCommandBar** is automatically updated whenever **AddingNewCustomer** is changed.</span></span>

### <a name="update-the-ui"></a><span data-ttu-id="47192-202">UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="47192-202">Update the UI</span></span>

1. <span data-ttu-id="47192-203">戻る**Views\CustomerListPage.xaml**、追加、 **StackPanel**との間で次のプロパティ、 **CommandBar**と、データ グリッド。</span><span class="sxs-lookup"><span data-stu-id="47192-203">Navigate back to **Views\CustomerListPage.xaml**, and add a **StackPanel** with the following properties between your **CommandBar** and your data grid:</span></span>

    ```xaml
    <StackPanel
        x:Name="newCustomerPanel"
        Orientation="Horizontal"
        x:Load="{x:Bind ViewModel.AddingNewCustomer, Mode=OneWay}"
        RelativePanel.Below="mainCommandBar">
    </StackPanel>
    ```
    <span data-ttu-id="47192-204">**X: 負荷**属性により、新しい顧客を追加するときに、このパネルをのみ表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="47192-204">The **x:Load** attribute ensures that this panel only appears when you're adding a new customer.</span></span>

2. <span data-ttu-id="47192-205">新しいパネルが表示されたら、下へ移動することを確認して、データ グリッドの位置には、次の変更を加えます。</span><span class="sxs-lookup"><span data-stu-id="47192-205">Make the following change to the position of your data grid, to ensure that it moves down when the new panel appears:</span></span>

    ```xaml
    RelativePanel.Below="newCustomerPanel"
    ```

3. <span data-ttu-id="47192-206">4 つで、スタック パネルを更新**TextBox**コントロール。</span><span class="sxs-lookup"><span data-stu-id="47192-206">Update your stack panel with four **TextBox** controls.</span></span> <span data-ttu-id="47192-207">新規の顧客の個々 のプロパティにバインドし、データ グリッドに追加する前に、その値を編集することがあります。</span><span class="sxs-lookup"><span data-stu-id="47192-207">They'll bind to the individual properties of the new customer, and allow you to edit its values before you add it to the data grid.</span></span>

    ```xaml
    <StackPanel
        x:Name="newCustomerPanel"
        Orientation="Horizontal"
        x:Load="{x:Bind ViewModel.AddingNewCustomer, Mode=OneWay}"
        RelativePanel.Below="mainCommandBar">
        <TextBox
            Header="First name"
            PlaceholderText="First"
            Margin="8,8,16,8"
            MinWidth="120"
            Text="{x:Bind ViewModel.NewCustomer.FirstName, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
        <TextBox
            Header="Last name"
            PlaceholderText="Last"
            Margin="0,8,16,8"
            MinWidth="120"
            Text="{x:Bind ViewModel.NewCustomer.LastName, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
        <TextBox
            Header="Address"
            PlaceholderText="1234 Address St, Redmond WA 00000"
            Margin="0,8,16,8"
            MinWidth="280"
            Text="{x:Bind ViewModel.NewCustomer.Address, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
        <TextBox
            Header="Company"
            PlaceholderText="Company"
            Margin="0,8,16,8"
            MinWidth="120"
            Text="{x:Bind ViewModel.NewCustomer.Company, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
    </StackPanel>
    ```

4. <span data-ttu-id="47192-208">新しいスタック パネルが新たに作成された顧客を保存するには、単純なボタンを追加します。</span><span class="sxs-lookup"><span data-stu-id="47192-208">Add a simple button to your new stack panel to save the newly-created customer:</span></span>

    ```xaml
    <StackPanel>
        <!--Text boxes from step 3-->
        <AppBarButton
            x:Name="SaveNewCustomer"
            Click="{x:Bind ViewModel.SaveInitialChangesAsync}"
            Icon="Save"/>
    </StackPanel>
    ```

5. <span data-ttu-id="47192-209">更新、 **CommandBar**ので、スタック パネルが表示される場合、正規表現の作成、削除、および更新 ボタンが無効にします。</span><span class="sxs-lookup"><span data-stu-id="47192-209">Update the **CommandBar**, so the regular create, delete, and update buttons are disabled when the stack panel is visible:</span></span>

    ```xaml
    <CommandBar
        x:Name="mainCommandBar"
        HorizontalAlignment="Stretch"
        IsEnabled="{x:Bind ViewModel.EnableCommandBar, Mode=OneWay}"
        Background="AliceBlue">
        <!--App bar buttons-->
    </CommandBar>
    ```

6. <span data-ttu-id="47192-210">アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="47192-210">Run your app.</span></span> <span data-ttu-id="47192-211">顧客を作成し、スタック パネル内のデータを入力できます。</span><span class="sxs-lookup"><span data-stu-id="47192-211">You can now create a customer and input its data in the stack panel.</span></span>

![新しい顧客を作成します。](images/customer-database-tutorial/add-new-customer.png)

## <a name="part-7-delete-a-customer"></a><span data-ttu-id="47192-213">パート 7:顧客を削除します。</span><span class="sxs-lookup"><span data-stu-id="47192-213">Part 7: Delete a customer</span></span>

<span data-ttu-id="47192-214">実装する必要がある最後の基本的な操作は、顧客を削除しています。</span><span class="sxs-lookup"><span data-stu-id="47192-214">Deleting a customer is the final basic operation that you need to implement.</span></span> <span data-ttu-id="47192-215">データ グリッド内で選択した顧客を削除するときに、すぐに呼び出したい**UpdateCustomersAsync** UI を更新するためにします。</span><span class="sxs-lookup"><span data-stu-id="47192-215">When you delete a customer you've selected within the data grid, you'll want to immediately call **UpdateCustomersAsync** in order to update the UI.</span></span> <span data-ttu-id="47192-216">ただし、先ほど作成した顧客を削除する場合は、そのメソッドを呼び出す必要はありません。</span><span class="sxs-lookup"><span data-stu-id="47192-216">However, you don't need to call that method if you're deleting a customer you've just created.</span></span>

1. <span data-ttu-id="47192-217">移動します**ViewModels\CustomerListPageViewModel.cs**、し、更新、 **DeleteAndUpdateAsync**メソッド。</span><span class="sxs-lookup"><span data-stu-id="47192-217">Navigate to **ViewModels\CustomerListPageViewModel.cs**, and update the **DeleteAndUpdateAsync** method:</span></span>

    ```csharp
    public async void DeleteAndUpdateAsync()
    {
        if (SelectedCustomer != null)
        {
            await App.Repository.Customers.DeleteAsync(_selectedCustomer.Model.Id);
        }
        await UpdateCustomersAsync();
    }
    ```

2. <span data-ttu-id="47192-218">**Views\CustomerListPage.xaml**、2 番目のボタンが含まれるように、新しい顧客を追加するため、スタック パネルを更新します。</span><span class="sxs-lookup"><span data-stu-id="47192-218">In **Views\CustomerListPage.xaml**, update the stack panel for adding a new customer so it contains a second button:</span></span>

    ```xaml
    <StackPanel>
        <!--Text boxes for adding a new customer-->
        <AppBarButton
            x:Name="DeleteNewCustomer"
            Click="{x:Bind ViewModel.DeleteNewCustomerAsync}"
            Icon="Cancel"/>
        <AppBarButton
            x:Name="SaveNewCustomer"
            Click="{x:Bind ViewModel.SaveInitialChangesAsync}"
            Icon="Save"/>
    </StackPanel>
    ```

3. <span data-ttu-id="47192-219">**ViewModels\CustomerListPageViewModel.cs**、更新、 **DeleteNewCustomerAsync**メソッドは、新しい顧客を削除します。</span><span class="sxs-lookup"><span data-stu-id="47192-219">In **ViewModels\CustomerListPageViewModel.cs**, update the **DeleteNewCustomerAsync** method to delete the new customer:</span></span>

    ```csharp
    public async Task DeleteNewCustomerAsync()
    {
        if (NewCustomer != null)
        {
            await App.Repository.Customers.DeleteAsync(_newCustomer.Model.Id);
            AddingNewCustomer = false;
        }
    }
    ```

4. <span data-ttu-id="47192-220">アプリを実行します。</span><span class="sxs-lookup"><span data-stu-id="47192-220">Run your app.</span></span> <span data-ttu-id="47192-221">これで、スタック パネル内またはデータ グリッド内の顧客を削除することができます。</span><span class="sxs-lookup"><span data-stu-id="47192-221">You can now delete customers, either within the data grid or in the stack panel.</span></span>

![新しい顧客を削除します。](images/customer-database-tutorial/delete-new-customer.png)

## <a name="conclusion"></a><span data-ttu-id="47192-223">まとめ</span><span class="sxs-lookup"><span data-stu-id="47192-223">Conclusion</span></span>

<span data-ttu-id="47192-224">これで終了です。</span><span class="sxs-lookup"><span data-stu-id="47192-224">Congratulations!</span></span> <span data-ttu-id="47192-225">アプリではすべてこれを行う、ローカルのデータベース操作の完全なようになりましたが。</span><span class="sxs-lookup"><span data-stu-id="47192-225">With all this done, your app now has a full range of local database operations.</span></span> <span data-ttu-id="47192-226">作成、読み取り、更新、および、UI 内の顧客を削除し、これらの変更は、データベースに保存され、アプリのさまざまな起動の間で保持されます。</span><span class="sxs-lookup"><span data-stu-id="47192-226">You can create, read, update, and delete customers within your UI, and these changes are saved to your database and will persist across different launches of your app.</span></span>

<span data-ttu-id="47192-227">完了したら、これで、次を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="47192-227">Now that you're finished, consider the following:</span></span>
* <span data-ttu-id="47192-228">まだインストールしていない場合はチェック アウト、[アプリ構造の概要](../enterprise/customer-database-app-structure.md)はその理由の詳細については、アプリがビルドされます。</span><span class="sxs-lookup"><span data-stu-id="47192-228">If you haven't already, check out the [app structure overview](../enterprise/customer-database-app-structure.md) for more information on why the app is built how it is.</span></span>
* <span data-ttu-id="47192-229">探索、[完全な顧客注文データベース サンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)に、このチュートリアルに基づいていますが、アプリを参照してください。</span><span class="sxs-lookup"><span data-stu-id="47192-229">Explore the [full Customer Orders Database sample](https://github.com/Microsoft/Windows-appsample-customers-orders-database) to see the app this tutorial was based on.</span></span>

<span data-ttu-id="47192-230">または、以降続行する場合は、チャレンジにサインアップしたら、.</span><span class="sxs-lookup"><span data-stu-id="47192-230">Or if you're up for a challenge, you can continue onwards...</span></span>

## <a name="going-further-connect-to-a-remote-database"></a><span data-ttu-id="47192-231">さらにします。リモート データベースへの接続します。</span><span class="sxs-lookup"><span data-stu-id="47192-231">Going further: Connect to a remote database</span></span>

<span data-ttu-id="47192-232">ローカルの SQLite データベースに対してこれらの呼び出しを実装する方法の詳細なチュートリアルについてご紹介します。</span><span class="sxs-lookup"><span data-stu-id="47192-232">We've provided a step-by-step walkthrough of how to implement these calls against a local SQLite database.</span></span> <span data-ttu-id="47192-233">しかし、代わりに、リモートのデータベースを使用する場合でしょうか。</span><span class="sxs-lookup"><span data-stu-id="47192-233">But what if you want to use a remote database, instead?</span></span>

<span data-ttu-id="47192-234">実際にやってする場合は、自分の Azure Active Directory (AAD) アカウントと独自のデータ ソースをホストする機能が必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-234">If you want to give this a try, you'll need your own Azure Active Directory (AAD) account and the ability to host your own data source.</span></span>

<span data-ttu-id="47192-235">認証では、REST の呼び出しを処理し、やり取りするリモート データベースを作成する関数を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-235">You'll need to add authentication, functions to handle REST calls, and then create a remote database to interact with.</span></span> <span data-ttu-id="47192-236">完全なコードがある[顧客注文データベース サンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)のために必要な操作ごとに参照することができます。</span><span class="sxs-lookup"><span data-stu-id="47192-236">There's code in the full [Customer Orders Database sample](https://github.com/Microsoft/Windows-appsample-customers-orders-database) that you can reference for each necessary operation.</span></span>

### <a name="settings-and-configuration"></a><span data-ttu-id="47192-237">設定と構成</span><span class="sxs-lookup"><span data-stu-id="47192-237">Settings and configuration</span></span>

<span data-ttu-id="47192-238">リモート データベースへの接続に必要な手順が記述された、[サンプルの readme](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/README.md)します。</span><span class="sxs-lookup"><span data-stu-id="47192-238">The necessary steps to connect to your own remote database are spelled out in the [sample's readme](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/README.md).</span></span> <span data-ttu-id="47192-239">以下を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-239">You'll need to do the following:</span></span>

* <span data-ttu-id="47192-240">Azure アカウント クライアント Id を提供する[Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs)します。</span><span class="sxs-lookup"><span data-stu-id="47192-240">Provide your Azure account client Id to [Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs).</span></span>
* <span data-ttu-id="47192-241">リモート データベースへの url を指定して[Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs)します。</span><span class="sxs-lookup"><span data-stu-id="47192-241">Provide the url of the remote database to [Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs).</span></span>
* <span data-ttu-id="47192-242">データベースの接続文字列を指定[Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs)します。</span><span class="sxs-lookup"><span data-stu-id="47192-242">Provide the connection string for the database to [Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs).</span></span>
* <span data-ttu-id="47192-243">Microsoft Store アプリを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="47192-243">Associate your app with the Microsoft Store.</span></span>
* <span data-ttu-id="47192-244">経由でコピー、[サービス プロジェクト](https://github.com/Microsoft/Windows-appsample-customers-orders-database/tree/master/ContosoService)をアプリにし、Azure にデプロイします。</span><span class="sxs-lookup"><span data-stu-id="47192-244">Copy over the [Service project](https://github.com/Microsoft/Windows-appsample-customers-orders-database/tree/master/ContosoService) into your app, and deploy it to Azure.</span></span>

### <a name="authentication"></a><span data-ttu-id="47192-245">認証</span><span class="sxs-lookup"><span data-stu-id="47192-245">Authentication</span></span>

<span data-ttu-id="47192-246">認証シーケンスでは、ポップアップやユーザーの情報を収集するために、別のページを開始するボタンを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-246">You'll need to create a button to start an authentication sequence, and a popup or a separate page to gather a user's information.</span></span> <span data-ttu-id="47192-247">作成したら、ユーザーの情報を要求し、アクセス トークンを取得するために使用するコードを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-247">Once you've created that, you'll need to provide code that requests a user's information and uses it to acquire an access token.</span></span> <span data-ttu-id="47192-248">顧客注文データベース サンプルでは、Microsoft Graph 呼び出しをラップする、 **web アカウント マネージャー**トークンを取得して、AAD アカウントへの認証を処理するライブラリ。</span><span class="sxs-lookup"><span data-stu-id="47192-248">The Customer Orders Database sample wraps Microsoft Graph calls with the **WebAccountManager** library to acquire a token and handle the authentication to an AAD account.</span></span>

* <span data-ttu-id="47192-249">認証ロジックが実装されている[ **AuthenticationViewModel.cs**](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/ViewModels/AuthenticationViewModel.cs)します。</span><span class="sxs-lookup"><span data-stu-id="47192-249">The authentication logic is implemented in [**AuthenticationViewModel.cs**](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/ViewModels/AuthenticationViewModel.cs).</span></span>
* <span data-ttu-id="47192-250">認証プロセスは、カスタム表示[ **AuthenticationControl.xaml** ](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/UserControls/AuthenticationControl.xaml)コントロール。</span><span class="sxs-lookup"><span data-stu-id="47192-250">The authentication process is displayed in the custom [**AuthenticationControl.xaml**](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/UserControls/AuthenticationControl.xaml) control.</span></span>

### <a name="rest-calls"></a><span data-ttu-id="47192-251">REST の呼び出し</span><span class="sxs-lookup"><span data-stu-id="47192-251">REST calls</span></span>

<span data-ttu-id="47192-252">いずれかを変更する必要はありませんが、コードで追加されたこのチュートリアルの REST 呼び出しを実装するためにします。</span><span class="sxs-lookup"><span data-stu-id="47192-252">You won't need to modify any of the code we added in this tutorial in order to implement REST calls.</span></span> <span data-ttu-id="47192-253">代わりに、以下を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-253">Instead, you'll need to do the following:</span></span>

* <span data-ttu-id="47192-254">新しい実装を作成、 **ICustomerRepository**と**ITutorialRepository** SQLite の代わりに REST を使用して関数の同じセットを実装するインターフェイス。</span><span class="sxs-lookup"><span data-stu-id="47192-254">Create new implementations of the **ICustomerRepository** and **ITutorialRepository** interfaces, implementing the same set of functions through REST instead of SQLite.</span></span> <span data-ttu-id="47192-255">および JSON の逆シリアル化する必要があり、別の REST 呼び出しをラップできます**HttpHelper**クラスの場合する必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-255">You'll need to serialize and deserialize JSON, and can wrap your REST calls in a separate **HttpHelper** class if you need to.</span></span> <span data-ttu-id="47192-256">参照してください[完全なサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database/tree/master/ContosoRepository/Rest)固有です。</span><span class="sxs-lookup"><span data-stu-id="47192-256">Refer to [the full sample](https://github.com/Microsoft/Windows-appsample-customers-orders-database/tree/master/ContosoRepository/Rest) for specifics.</span></span>
* <span data-ttu-id="47192-257">**App.xaml.cs**REST リポジトリを初期化するために新しい関数を作成しての代わりにそれを呼び出す**SqliteDatabase**アプリが初期化されます。</span><span class="sxs-lookup"><span data-stu-id="47192-257">In **App.xaml.cs**, create a new function to initialize the REST repository, and call it instead of **SqliteDatabase** when the app is initialized.</span></span> <span data-ttu-id="47192-258">ここでもを参照してください。[完全なサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/App.xaml.cs)します。</span><span class="sxs-lookup"><span data-stu-id="47192-258">Again, refer to [the full sample](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/App.xaml.cs).</span></span>

<span data-ttu-id="47192-259">次の手順の 3 つすべてが完了したら、アプリで AAD アカウントに認証はずです。</span><span class="sxs-lookup"><span data-stu-id="47192-259">Once all three of these steps are complete, you should be able to authenticate to your AAD account through your app.</span></span> <span data-ttu-id="47192-260">リモート データベースへの REST 呼び出しが、ローカルの SQLite の呼び出しに置き換えられますが、ユーザー エクスペリエンスは同じにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="47192-260">REST calls to the remote database will replace the local SQLite calls, but the user experience should be the same.</span></span> <span data-ttu-id="47192-261">さらに取り組むは気分を場合は、2 つを動的に切り替えるユーザーを許可する設定 ページを追加できます。</span><span class="sxs-lookup"><span data-stu-id="47192-261">If you're feeling even more ambitious, you can add a settings page to allow the user to dynamically switch between the two.</span></span>
