---
title: 顧客データベース アプリケーションの作成
description: 顧客のデータベース アプリケーションを作成し、基本的なエンタープライズ アプリの機能を実装する方法について説明します。
keywords: enterprise、チュートリアル、顧客データを読み取り、更新の削除、REST、認証を作成します。
ms.date: 05/07/2018
ms.topic: article
ms.localizationpriority: med
ms.openlocfilehash: 9c09e0fb73e42fd8a3d0c70bbb5396be32624387
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623247"
---
# <a name="tutorial-create-a-customer-database-application"></a>チュートリアル: 顧客データベース アプリケーションの作成

このチュートリアルでは、顧客の一覧を管理するための簡単なアプリを作成します。 これを行うには、UWP でエンタープライズ アプリケーションの基本的な概念の選択範囲が導入されています。 次の方法について説明します。

* 作成、読み取り、更新プログラムを実装し、ローカルの SQL データベースに対する操作を削除します。
* 表示し、編集、UI 内の顧客データへのデータ グリッドを追加します。
* 基本的なフォーム レイアウトで UI 要素を配置します。

このチュートリアルの開始点は、最小限の UI との簡略化バージョンに基づく機能によるシングル ページ アプリ、[顧客注文データベース サンプル アプリ](https://github.com/Microsoft/Windows-appsample-customers-orders-database)します。 記述されてC#XAML、およびこれら両方の言語の基礎知識が得られたらを想定しているとします。

![作業用アプリのメイン ページ](images/customer-database-tutorial/customer-list.png)

### <a name="prerequisites"></a>前提条件

* [Visual Studio と Windows 10 SDK の最新バージョンであることを確認します。](https://developer.microsoft.com/windows/downloads/windows-10-sdk)
* [複製するか、顧客データベース チュートリアルのサンプルをダウンロード](https://aka.ms/customer-database-tutorial)

開き、プロジェクトを編集するには複製/をダウンロードしたら、リポジトリ、 **CustomerDatabaseTutorial.sln** Visual Studio を使用します。

> [!NOTE]
> チェック アウト、[完全な顧客注文データベース サンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)に、このチュートリアルに基づいていますが、アプリを参照してください。

## <a name="part-1-code-of-interest"></a>第 1 部:目的のコード

アプリを開いた後すぐに実行する場合、空の画面の上部にある、いくつかのボタンが表示されます。 表示はされませんが、アプリが既にいくつかのテスト ユーザーのプロビジョニングされたローカルの SQLite データベースに含まれます。 ここは、顧客を表示する UI コントロールを実装することで開始し、データベースに対する処理の追加に移ります。 開始する前にする操作をここでは。

### <a name="views"></a>ビュー

**CustomerListPage.xaml**はアプリのビューは、このチュートリアルでは、1 つのページの UI を定義します。 いつでも追加または UI では、視覚的要素を変更する必要があることを行いこのファイル。 このチュートリアルではこれらの要素を追加します。

* A **RadDataGrid**を表示すると、顧客を編集します。 
* A **StackPanel**新しい顧客の初期値を設定します。

### <a name="viewmodels"></a>ビューモデル

**ViewModels\CustomerListPageViewModel.cs**はアプリケーションの基本的なロジックが存在します。 ビューで実行されるすべてのユーザー アクションは、このファイルを処理するために渡されます。 このチュートリアルで、新しいコードを追加し、次のメソッドの実装します。

* **CreateNewCustomerAsync**、新しい CustomerViewModel オブジェクトを初期化します。
* **DeleteNewCustomerAsync**UI に表示される前に新しい顧客を削除します。
* **DeleteAndUpdateAsync**delete ボタンのロジックを処理します。
* **GetCustomerListAsync**、データベースから顧客の一覧を取得します。
* **SaveInitialChangesAsync**データベースに新しい顧客の情報を追加します。
* **UpdateCustomersAsync**、すべての顧客を追加または削除を反映するように UI が更新されます。

**CustomerViewModel**が最近変更されたがかどうかを追跡する顧客の情報用のラッパーです。 このクラスには何も追加する必要はありませんが、別の場所を追加するコードの一部は参照します。

サンプルの構築方法の詳細については、のチェック アウト、[アプリ構造の概要](../enterprise/customer-database-app-structure.md)します。

## <a name="part-2-add-the-datagrid"></a>パート 2:DataGrid を追加します。

顧客データを操作を開始する前に、これらの顧客を表示する UI コントロールを追加する必要があります。 事前に作成されたサード パーティには、使用する**RadDataGrid**コントロール。 **Telerik.UI.for.UniversalWindowsPlatform** NuGet パッケージは、このプロジェクトに既に含まれています。 グリッドをプロジェクトに追加してみましょう。

1. 開いている**Views\CustomerListPage.xaml**ソリューション エクスプ ローラーから。 内のコードの次の行を追加、**ページ**データ グリッドを含む Telerik 名前空間へのマッピングを宣言するタグ。

    ```xaml
        xmlns:telerikGrid="using:Telerik.UI.Xaml.Controls.Grid"
    ```

2. 以下、 **CommandBar**メイン内**RelativePanel** 、ビューの追加、 **RadDataGrid**いくつかの基本的な構成オプションを使用して、コントロール。

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

3. データ グリッドを追加しましたが、データを表示する必要があります。 これには、次のコード行を追加します。

    ```xaml
    ItemsSource="{x:Bind ViewModel.Customers}"
    UserEditMode="Inline"
    ```
    表示するにはデータのソースを定義するところ**RadDataGrid**の UI ロジックのほとんどを処理します。 ただし、プロジェクトを実行する場合もが表示されなくなりますデータ表示します。 ViewModel がまだロードされていないためにです。

![空のアプリで顧客がありません。](images/customer-database-tutorial/blank-customer-list.png)

## <a name="part-3-read-customers"></a>パート 3:顧客を読み取り

初期化されると、 **ViewModels\CustomerListPageViewModel.cs**呼び出し、 **GetCustomerListAsync**メソッド。 チュートリアルでは、SQLite からテストの顧客データを取得するメソッドの必要があるデータベースが含まれます。

1. **ViewModels\CustomerListPageViewModel.cs**、更新、 **GetCustomerListAsync**メソッドをこのコード。

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
    **GetCustomerListAsync**ビューモデルが読み込まれますが、この手順では、前に何も出力しないメソッドが呼び出されます。 ここへの呼び出しが追加されました、 **GetAsync**メソッド**リポジトリ/SqlCustomerRepository**します。 これによって、Customer オブジェクトの列挙可能なコレクションを取得するリポジトリにお問い合わせください。 解析の個々 のオブジェクトの内部に追加する前に**ObservableCollection**表示および編集できるようにします。

2. -アプリの実行の顧客のリストを表示するデータ グリッドを今すぐ表示されます。

![最初に顧客のリスト](images/customer-database-tutorial/initial-customers.png)

## <a name="part-4-edit-customers"></a>パート 4:顧客を編集します。

ダブルクリックして、データ グリッド内のエントリを編集することができますが、UI に加えた変更はすべてが分離コード内の顧客のコレクションにも行われることを確認する必要があります。 つまり、双方向データ バインディングを実装する必要があります。 この詳細についてを実行する場合に、チェック アウト、[データ バインディングの概要](../get-started/display-customers-in-list-learning-track.md)します。

1. 最初に、宣言する**ViewModels\CustomerListPageViewModel.cs**実装、 **INotifyPropertyChanged**インターフェイス。

    ```csharp
    public class CustomerListPageViewModel : INotifyPropertyChanged
    ```

2. 次に、クラスのメイン本体では、次のイベントとメソッドを追加します。

    ```csharp
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    ```

    **OnPropertyChanged**メソッドを簡単に発生させる、setter、 **PropertyChanged**双方向データ バインドに必要なは、そのイベント。

3. 更新の set アクセス操作子**SelectedCustomer**のこの関数の呼び出しで。

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

4. **Views\CustomerListPage.xaml**、追加、 **SelectedCustomer**プロパティをデータ グリッドに表示します。

    ```xaml
    SelectedItem="{x:Bind ViewModel.SelectedCustomer, Mode=TwoWay}"
    ```

    これにより、データ グリッドで、ユーザーの選択が分離コード内の対応する顧客オブジェクトに関連付けられます。 TwoWay バインド モードには、そのオブジェクトに反映されるまで、UI で行われた変更ができます。

5. アプリを実行します。 お客様は、グリッドに表示され、UI を基になるデータに変更を加えることができますようになりました。

![データ グリッド内の顧客の編集](images/customer-database-tutorial/edit-customer-inline.png)

## <a name="part-5-update-customers"></a>パート 5:お客様を更新します。

これで、表示して、顧客を編集できるは、データベースに変更をプッシュし、他のユーザーによって行われたすべての更新プログラムを取得できる必要があります。

1. 戻り**ViewModels\CustomerListPageViewModel.cs**に移動し、 **UpdateCustomersAsync**メソッド。 このコードは、データベースに変更をプッシュして、新しい情報を取得すると、更新します。

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
    このコードを利用、 **IsModified**プロパティの**ViewModels\CustomerViewModel.cs**顧客が変更されるたびに自動的に更新されます。 これにより、のみ更新された顧客からデータベースに変更をプッシュして、不要な呼び出しを回避することができます。

## <a name="part-6-create-a-new-customer"></a>パート 6:新しい顧客を作成します。

新しい顧客を追加するように、UI にそのプロパティの値を指定する前に追加する場合、空白行として、顧客が表示されます、課題を表示します。 問題ないが、ここで私たちを容易に顧客の初期値を設定します。 このチュートリアルで、単純な折りたたみ可能なパネルを追加しますが、詳細については、追加した場合、この目的のため、別のページを作成できます。

### <a name="update-the-code-behind"></a>分離コードを更新します。

1. 新しいプライベート フィールドとパブリック プロパティを追加**ViewModels\CustomerListPageViewModel.cs**します。 パネルが表示されるかどうかを制御するために使用されます。

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

2. 値の逆元、ViewModel に新しいパブリック プロパティを追加**AddingNewCustomer**します。 パネルが表示されたら、通常コマンド バーのボタンを無効にするために使用されます。

    ```csharp
    public bool EnableCommandBar => !AddingNewCustomer;
    ```
    折りたたみ可能なパネルを表示し、そこを編集する顧客を作成する方法を今すぐ必要があります。 

3. 新しく作成された顧客を保持するために、ViewModel に新しいプライベート フィーンドおよびパブリック プロパティを追加します。

    ```csharp
    private CustomerViewModel _newCustomer;

    public CustomerViewModel NewCustomer
    {
        get => _newCustomer;
        set
        {
            if {_newCustomer != value}
            {
                _newCustomer = value;
                OnPropertyChanged();
            }
        }
    }
    ```

2.  更新プログラム、 **CreateNewCustomerAsync**メソッドを新しい顧客を作成、リポジトリに追加され、選択した顧客として設定します。

    ```csharp
    public async Task CreateNewCustomerAsync()
    {
        CustomerViewModel newCustomer = new CustomerViewModel(new Models.Customer());
        NewCustomer = newCustomer;
        await App.Repository.Customers.UpsertAsync(NewCustomer.Model);
        AddingNewCustomer = true;
    }
    ```

3. 更新、 **SaveInitialChangesAsync**リポジトリに新しく作成された顧客を追加するメソッド、UI を更新し、パネルを閉じます。

    ```csharp
    public async Task SaveInitialChangesAsync()
    {
        await App.Repository.Customers.UpsertAsync(NewCustomer.Model);
        await UpdateCustomersAsync();
        AddingNewCustomer = false;
    }
    ```
4. Setter の最後の行として次のコード行を追加**AddingNewCustomer**:

    ```csharp
    OnPropertyChanged(nameof(EnableCommandBar));
    ```

    これにより**EnableCommandBar**が自動的に更新されるたびに**AddingNewCustomer**が変更されました。

### <a name="update-the-ui"></a>UI を更新します。

1. 戻る**Views\CustomerListPage.xaml**、追加、 **StackPanel**との間で次のプロパティ、 **CommandBar**と、データ グリッド。

    ```xaml
    <StackPanel
        x:Name="newCustomerPanel"
        Orientation="Horizontal"
        x:Load="{x:Bind ViewModel.AddingNewCustomer, Mode=OneWay}"
        RelativePanel.Below="mainCommandBar">
    </StackPanel>
    ```
    **X: 負荷**属性により、新しい顧客を追加するときに、このパネルをのみ表示されるようになります。

2. 新しいパネルが表示されたら、下へ移動することを確認して、データ グリッドの位置には、次の変更を加えます。

    ```xaml
    RelativePanel.Below="newCustomerPanel"
    ```

3. 4 つで、スタック パネルを更新**TextBox**コントロール。 新規の顧客の個々 のプロパティにバインドし、データ グリッドに追加する前に、その値を編集することがあります。

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

4. 新しいスタック パネルが新たに作成された顧客を保存するには、単純なボタンを追加します。

    ```xaml
    <StackPanel>
        <!--Text boxes from step 3-->
        <AppBarButton
            x:Name="SaveNewCustomer"
            Click="{x:Bind ViewModel.SaveInitialChangesAsync}"
            Icon="Save"/>
    </StackPanel>
    ```

5. 更新、 **CommandBar**ので、スタック パネルが表示される場合、正規表現の作成、削除、および更新 ボタンが無効にします。

    ```xaml
    <CommandBar
        x:Name="mainCommandBar"
        HorizontalAlignment="Stretch"
        IsEnabled="{x:Bind ViewModel.EnableCommandBar, Mode=OneWay}"
        Background="AliceBlue">
        <!--App bar buttons-->
    </CommandBar>
    ```

6. アプリを実行します。 顧客を作成し、スタック パネル内のデータを入力できます。

![新しい顧客を作成します。](images/customer-database-tutorial/add-new-customer.png)

## <a name="part-7-delete-a-customer"></a>パート 7:顧客を削除します。

実装する必要がある最後の基本的な操作は、顧客を削除しています。 データ グリッド内で選択した顧客を削除するときに、すぐに呼び出したい**UpdateCustomersAsync** UI を更新するためにします。 ただし、先ほど作成した顧客を削除する場合は、そのメソッドを呼び出す必要はありません。

1. 移動します**ViewModels\CustomerListPageViewModel.cs**、し、更新、 **DeleteAndUpdateAsync**メソッド。

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

2. **Views\CustomerListPage.xaml**、2 番目のボタンが含まれるように、新しい顧客を追加するため、スタック パネルを更新します。

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

3. **ViewModels\CustomerListPageViewModel.cs**、更新、 **DeleteNewCustomerAsync**メソッドは、新しい顧客を削除します。

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

4. アプリを実行します。 これで、スタック パネル内またはデータ グリッド内の顧客を削除することができます。

![新しい顧客を削除します。](images/customer-database-tutorial/delete-new-customer.png)

## <a name="conclusion"></a>まとめ

これで終了です。 アプリではすべてこれを行う、ローカルのデータベース操作の完全なようになりましたが。 作成、読み取り、更新、および、UI 内の顧客を削除し、これらの変更は、データベースに保存され、アプリのさまざまな起動の間で保持されます。

完了したら、これで、次を考慮してください。
* まだインストールしていない場合はチェック アウト、[アプリ構造の概要](../enterprise/customer-database-app-structure.md)はその理由の詳細については、アプリがビルドされます。
* 探索、[完全な顧客注文データベース サンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)に、このチュートリアルに基づいていますが、アプリを参照してください。

または、以降続行する場合は、チャレンジにサインアップしたら、.

## <a name="going-further-connect-to-a-remote-database"></a>さらにします。リモート データベースへの接続します。

ローカルの SQLite データベースに対してこれらの呼び出しを実装する方法の詳細なチュートリアルについてご紹介します。 しかし、代わりに、リモートのデータベースを使用する場合でしょうか。

実際にやってする場合は、自分の Azure Active Directory (AAD) アカウントと独自のデータ ソースをホストする機能が必要があります。

認証では、REST の呼び出しを処理し、やり取りするリモート データベースを作成する関数を追加する必要があります。 完全なコードがある[顧客注文データベース サンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database)のために必要な操作ごとに参照することができます。

### <a name="settings-and-configuration"></a>設定と構成

リモート データベースへの接続に必要な手順が記述された、[サンプルの readme](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/README.md)します。 以下を行う必要があります。

* Azure アカウント クライアント Id を提供する[Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs)します。
* リモート データベースへの url を指定して[Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs)します。
* データベースの接続文字列を指定[Constants.cs](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoRepository/Constants.cs)します。
* Microsoft Store アプリを関連付けます。
* 経由でコピー、[サービス プロジェクト](https://github.com/Microsoft/Windows-appsample-customers-orders-database/tree/master/ContosoService)をアプリにし、Azure にデプロイします。

### <a name="authentication"></a>認証

認証シーケンスでは、ポップアップやユーザーの情報を収集するために、別のページを開始するボタンを作成する必要があります。 作成したら、ユーザーの情報を要求し、アクセス トークンを取得するために使用するコードを提供する必要があります。 顧客注文データベース サンプルでは、Microsoft Graph 呼び出しをラップする、 **web アカウント マネージャー**トークンを取得して、AAD アカウントへの認証を処理するライブラリ。

* 認証ロジックが実装されている[ **AuthenticationViewModel.cs**](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/ViewModels/AuthenticationViewModel.cs)します。
* 認証プロセスは、カスタム表示[ **AuthenticationControl.xaml** ](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/UserControls/AuthenticationControl.xaml)コントロール。

### <a name="rest-calls"></a>REST の呼び出し

いずれかを変更する必要はありませんが、コードで追加されたこのチュートリアルの REST 呼び出しを実装するためにします。 代わりに、以下を行う必要があります。

* 新しい実装を作成、 **ICustomerRepository**と**ITutorialRepository** SQLite の代わりに REST を使用して関数の同じセットを実装するインターフェイス。 および JSON の逆シリアル化する必要があり、別の REST 呼び出しをラップできます**HttpHelper**クラスの場合する必要があります。 参照してください[完全なサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database/tree/master/ContosoRepository/Rest)固有です。
* **App.xaml.cs**REST リポジトリを初期化するために新しい関数を作成しての代わりにそれを呼び出す**SqliteDatabase**アプリが初期化されます。 ここでもを参照してください。[完全なサンプル](https://github.com/Microsoft/Windows-appsample-customers-orders-database/blob/master/ContosoApp/App.xaml.cs)します。

次の手順の 3 つすべてが完了したら、アプリで AAD アカウントに認証はずです。 リモート データベースへの REST 呼び出しが、ローカルの SQLite の呼び出しに置き換えられますが、ユーザー エクスペリエンスは同じにする必要があります。 さらに取り組むは気分を場合は、2 つを動的に切り替えるユーザーを許可する設定 ページを追加できます。