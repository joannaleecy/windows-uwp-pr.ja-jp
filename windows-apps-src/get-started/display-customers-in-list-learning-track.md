---
title: 学習トラック - 一覧での顧客の表示
description: 一覧で Customer オブジェクトのコレクションを表示するために行う必要があることについて説明します。
ms.date: 05/07/2018
ms.topic: article
keywords: 概要, uwp, windows 10, 学習トラック, データ バインディング, 一覧
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: bd4a1f6747ea68623039b7eac22ac08aaa15d9ea
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7975285"
---
# <a name="display-customers-in-a-list"></a><span data-ttu-id="c57af-104">一覧での顧客の表示</span><span class="sxs-lookup"><span data-stu-id="c57af-104">Display customers in a list</span></span>

<span data-ttu-id="c57af-105">UI 内で実際のデータを表示して操作することは多くのアプリの機能に不可欠です。</span><span class="sxs-lookup"><span data-stu-id="c57af-105">Displaying and manipulating real data in the UI is crucial to the functionality of many apps.</span></span> <span data-ttu-id="c57af-106">この記事では、一覧で Customer オブジェクトのコレクションを表示するために知っておく必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="c57af-106">This article will show you what you need to know to display a collection of Customer objects in a list.</span></span>

<span data-ttu-id="c57af-107">これはチュートリアルではありません。</span><span class="sxs-lookup"><span data-stu-id="c57af-107">This is not a tutorial.</span></span> <span data-ttu-id="c57af-108">チュートリアルが必要な場合は、「[データ バインディングのチュートリアル](../data-binding/xaml-basics-data-binding.md)」を参照してください。このチュートリアルでは、手順を説明したガイド付きのエクスペリエンスが提供されます。</span><span class="sxs-lookup"><span data-stu-id="c57af-108">If you want one, see our [data binding tutorial](../data-binding/xaml-basics-data-binding.md), which will provide you with a step-by-step guided experience.</span></span>

<span data-ttu-id="c57af-109">まず、データ バインディングの概要としくみに関する簡単な説明から始めます。</span><span class="sxs-lookup"><span data-stu-id="c57af-109">We’ll start with a quick discussion of data binding - what it is and how it works.</span></span> <span data-ttu-id="c57af-110">次に、**ListView** を UI に追加し、データ バインディングを追加し、データ バインディングを追加の機能でカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="c57af-110">Then we'll add a **ListView** to the UI, add data binding, and customize the data binding with additional features.</span></span> 

## <a name="what-do-you-need-to-know"></a><span data-ttu-id="c57af-111">理解しておく必要があること</span><span class="sxs-lookup"><span data-stu-id="c57af-111">What do you need to know?</span></span>

<span data-ttu-id="c57af-112">データ バインディングは、アプリのデータをその UI に表示する方法です。</span><span class="sxs-lookup"><span data-stu-id="c57af-112">Data binding is a way to display an app's data in its UI.</span></span> <span data-ttu-id="c57af-113">これにより、アプリで*役割の分離*を使用できるため、UI をその他のコードから分離することができます。</span><span class="sxs-lookup"><span data-stu-id="c57af-113">This allows for *separation of concerns* in your app, keeping your UI separate from your other code.</span></span> <span data-ttu-id="c57af-114">このため、読みやすく保守が容易なより明確な概念モデルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="c57af-114">This creates a cleaner conceptual model that’s easier to read and maintain.</span></span>

<span data-ttu-id="c57af-115">すべてのデータ バインディングには、次の 2 つの部分があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-115">Every data binding has two pieces:</span></span>

* <span data-ttu-id="c57af-116">バインドするデータを提供するソース。</span><span class="sxs-lookup"><span data-stu-id="c57af-116">A source which provides the data to be bound.</span></span>
* <span data-ttu-id="c57af-117">データが表示される UI でのターゲット。</span><span class="sxs-lookup"><span data-stu-id="c57af-117">A target in the UI where the data is displayed.</span></span>

<span data-ttu-id="c57af-118">データ バインディングを実装するには、バインディングにデータを提供するソースにコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-118">To implement a data binding, you'll need to add code to your source that provides data to the binding.</span></span> <span data-ttu-id="c57af-119">また、データ ソースのプロパティを指定する、XAML に 2 つのマークアップ拡張のいずれかを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-119">You'll also need to add one of two markup extensions to your XAML to specify the data source properties.</span></span> <span data-ttu-id="c57af-120">2 つの種類の主な違いを次に示します。</span><span class="sxs-lookup"><span data-stu-id="c57af-120">Here's the key difference between the two:</span></span>

* <span data-ttu-id="c57af-121">[**x:Bind**](../xaml-platform/x-bind-markup-extension.md) は厳密に型指定され、パフォーマンス向上のためコンパイル時にコードを生成します。</span><span class="sxs-lookup"><span data-stu-id="c57af-121">[**x:Bind**](../xaml-platform/x-bind-markup-extension.md) is strongly typed, and generates code at compile time for better performance.</span></span> <span data-ttu-id="c57af-122">x:Bind は既定では 1 回限りのバインディングが指定され、変更されない読み取り専用のデータの高速表示のために最適化されます。</span><span class="sxs-lookup"><span data-stu-id="c57af-122">x:Bind defaults to a one-time binding, which optimizes for the fast display of read-only data that doesn't change.</span></span>
* <span data-ttu-id="c57af-123">[**バインディング**](../xaml-platform/binding-markup-extension.md)は弱く型指定され、実行時にまとめられます。</span><span class="sxs-lookup"><span data-stu-id="c57af-123">[**Binding**](../xaml-platform/binding-markup-extension.md) is weakly typed and assembled at runtime.</span></span> <span data-ttu-id="c57af-124">その結果、パフォーマンスは x:Bind より低下します。</span><span class="sxs-lookup"><span data-stu-id="c57af-124">This results in poorer performance than with x:Bind.</span></span> <span data-ttu-id="c57af-125">ほとんどの場合、バインディングではなく x:Bind を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-125">In almost all cases, you should use x:Bind instead of Binding.</span></span> <span data-ttu-id="c57af-126">ただし、古いコードではこの問題が生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-126">However, you're likely to encounter it in older code.</span></span> <span data-ttu-id="c57af-127">バインディングは既定では一方向のデータ転送が指定され、ソースで変更できる読み取り専用のデータのために最適化されます。</span><span class="sxs-lookup"><span data-stu-id="c57af-127">Binding defaults to one-way data transfer, which optimizes for read-only data that can change at the source.</span></span>

<span data-ttu-id="c57af-128">可能な限り **x:Bind** を使用することをお勧めします。この記事のスニペットで x:Bind について説明します。</span><span class="sxs-lookup"><span data-stu-id="c57af-128">We recommend you use **x:Bind** whenever possible, and we'll be showing it in the snippets in this article.</span></span> <span data-ttu-id="c57af-129">相違点の詳細については、「[{x:Bind} と {Binding} の機能の比較](../data-binding/data-binding-in-depth.md#xbind-and-binding-feature-comparison)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c57af-129">For more information on the differences, see [{x:Bind} and {Binding} feature comparison](../data-binding/data-binding-in-depth.md#xbind-and-binding-feature-comparison).</span></span>

## <a name="create-a-data-source"></a><span data-ttu-id="c57af-130">データ ソースの作成</span><span class="sxs-lookup"><span data-stu-id="c57af-130">Create a data source</span></span>

<span data-ttu-id="c57af-131">最初に、Customer データを表すクラスを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-131">First, you'll need a class to represent your Customer data.</span></span> <span data-ttu-id="c57af-132">参考のために、この必要最小限の例でのプロセスを示します。</span><span class="sxs-lookup"><span data-stu-id="c57af-132">To give you a reference point, we'll be showing the process on this bare-bones example:</span></span>

```csharp
public class Customer
{
    public string Name { get; set; }
}
```

## <a name="create-a-list"></a><span data-ttu-id="c57af-133">一覧の作成</span><span class="sxs-lookup"><span data-stu-id="c57af-133">Create a list</span></span>

<span data-ttu-id="c57af-134">顧客を表示するには、まずそれを保持する一覧を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-134">Before you can display any customers, you need to create the list to hold them.</span></span> <span data-ttu-id="c57af-135">[一覧表示](../design/controls-and-patterns/listview-and-gridview.md)はこのタスクに最適な基本的な XAML コントロールです。</span><span class="sxs-lookup"><span data-stu-id="c57af-135">The [List View](../design/controls-and-patterns/listview-and-gridview.md) is a basic XAML control which is ideal for this task.</span></span> <span data-ttu-id="c57af-136">ListView には現在ページ内での位置が必要であり、**ItemSource** プロパティの値が後で必要になります。</span><span class="sxs-lookup"><span data-stu-id="c57af-136">Your ListView currently requires a position on the page, and will shortly need a value for its **ItemSource** property.</span></span>

```xaml
<ListView ItemsSource=""
    HorizontalAlignment="Center"
    VerticalAlignment="Center"/>
```

<span data-ttu-id="c57af-137">ListView にデータをバインドしたら、ドキュメントに戻り、ニーズに最も合うように外観やレイアウトのカスタマイズをテストすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c57af-137">Once you have bound data to your ListView, we encourage you to return to the documentation, and experiment with customizing its appearance and layout to best fit your needs.</span></span>

## <a name="bind-data-to-your-list"></a><span data-ttu-id="c57af-138">一覧へのデータのバインド</span><span class="sxs-lookup"><span data-stu-id="c57af-138">Bind data to your list</span></span>

<span data-ttu-id="c57af-139">バインディングを保持する基本的な UI を作成したので、ソースがバインディングを指定するように構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-139">Now that you've made a basic UI to hold your bindings, you need to configure your source to provide them.</span></span> <span data-ttu-id="c57af-140">その方法を示す例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="c57af-140">Here's an example of how this may be done:</span></span>

```csharp
public sealed partial class MainPage : Page
{
    public ObservableCollection<Customer> Customers { get; }
        = new ObservableCollection<Customer>();

    public MainPage()
    {
        this.InitializeComponent();
          // Add some customers
        this.Customers.Add(new Customer() { Name = "NAME1"});
        this.Customers.Add(new Customer() { Name = "NAME2"});
        this.Customers.Add(new Customer() { Name = "NAME3"});
    }
}
```
```xaml
<ListView ItemsSource="{x:Bind Customers}"
    HorizontalAlignment="Center"
    VerticalAlignment="Center">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="local:Customer">
            <TextBlock Text="{x:Bind Name}"/>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

<span data-ttu-id="c57af-141">「[データ バインディングの概要](../data-binding/data-binding-quickstart.md#binding-to-a-collection-of-items)」では、項目のコレクションへのバインティングに関するセクションで、同様の問題について説明します。</span><span class="sxs-lookup"><span data-stu-id="c57af-141">The [Data Binding overview](../data-binding/data-binding-quickstart.md#binding-to-a-collection-of-items) walks you through a similar problem, in its section about binding to a collection of items.</span></span> <span data-ttu-id="c57af-142">この例では、次の重要な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="c57af-142">Our example here shows the following crucial steps:</span></span>

* <span data-ttu-id="c57af-143">UI の分離コードでは、Customer オブジェクトを保持するための **ObservableCollection<T>** 型のプロパティを作成します。</span><span class="sxs-lookup"><span data-stu-id="c57af-143">In the code-behind of your UI, create a property of type **ObservableCollection<T>** to hold your Customer objects.</span></span>
* <span data-ttu-id="c57af-144">ListView の **ItemSource** をそのプロパティにバインドします。</span><span class="sxs-lookup"><span data-stu-id="c57af-144">Bind your ListView’s **ItemSource** to that property.</span></span>
* <span data-ttu-id="c57af-145">一覧の各項目の表示方法を構成する、ListView の基本的な **ItemTemplate** を指定します。</span><span class="sxs-lookup"><span data-stu-id="c57af-145">Provide a basic **ItemTemplate** for the ListView, which will configure how each item in the list is displayed.</span></span>

<span data-ttu-id="c57af-146">レイアウトをカスタマイズする場合は、[リスト ビュー](../design/controls-and-patterns/listview-and-gridview.md)のドキュメントに自由に戻って、先ほど作成した **DataTemplate** を調整します。</span><span class="sxs-lookup"><span data-stu-id="c57af-146">Feel free to look back at the [List View](../design/controls-and-patterns/listview-and-gridview.md) docs if you want to customize layout, add item selection, or tweak the **DataTemplate** you just made.</span></span> <span data-ttu-id="c57af-147">ただし、Customers を編集する場合はどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="c57af-147">But what if you want to edit your Customers?</span></span>

## <a name="edit-your-customers-through-the-ui"></a><span data-ttu-id="c57af-148">UI を通じた Customers の編集</span><span class="sxs-lookup"><span data-stu-id="c57af-148">Edit your Customers through the UI</span></span>

<span data-ttu-id="c57af-149">一覧で顧客を表示しましたが、データ B バインディングではより多くのことを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="c57af-149">You’ve displayed customers in a list, but data B=binding lets you do more.</span></span> <span data-ttu-id="c57af-150">UI から直接データを編集できるとしたらどうでしょうか。</span><span class="sxs-lookup"><span data-stu-id="c57af-150">What if you could edit your data directly from the UI?</span></span> <span data-ttu-id="c57af-151">これを行うには、まずデータ バインディングの 3 つのモデルについて説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="c57af-151">To do this, let’s first talk about the three modes of data binding:</span></span>

* <span data-ttu-id="c57af-152">*1 回限り*: このデータ バインディングは一度だけアクティブ化され、変更に対応しません。</span><span class="sxs-lookup"><span data-stu-id="c57af-152">*One-Time*: This data binding is only activated once, and doesn’t react to changes.</span></span>
* <span data-ttu-id="c57af-153">*一方向*: このデータ バインディングは、データ ソースに対して行われた変更で UI を更新します。</span><span class="sxs-lookup"><span data-stu-id="c57af-153">*One-Way*: This data binding will update the UI with any changes made to the data source.</span></span>
* <span data-ttu-id="c57af-154">*双方向*: このデータ バインディングは、データ ソースに対して行われた変更で UI を更新します。また、UI 内で行われた変更でデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="c57af-154">*Two-Way*: This data binding will update the UI with any changes made to the data source, and also update the data with any changes made within the UI.</span></span>

<span data-ttu-id="c57af-155">以前のコード スニペットに従った場合、行ったバインディングでは x:Bind を使用し、モードを使用しないため、1 回限りのバインディングになります。</span><span class="sxs-lookup"><span data-stu-id="c57af-155">If you've followed the code snippets from earlier, the binding you made uses x:Bind and doesn't specify a mode, making it a One-Time binding.</span></span> <span data-ttu-id="c57af-156">UI から直接 Customers を編集する場合は、データからの変更が Customer オブジェクトに戻されるように、双方向のバインディングに変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-156">If you want to edit your Customers directly from the UI, you'll need to change it to a Two-Way binding, so that changes from the data will be passed back to the Customer objects.</span></span> <span data-ttu-id="c57af-157">詳細については、「[データ バインディングの詳細](../data-binding/data-binding-in-depth.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c57af-157">[Data binding in depth](../data-binding/data-binding-in-depth.md) has more information.</span></span>

<span data-ttu-id="c57af-158">データ ソースが変更された場合は、双方向バインディングも更新されます。</span><span class="sxs-lookup"><span data-stu-id="c57af-158">Two-way binding will also update the UI if the data source is changed.</span></span> <span data-ttu-id="c57af-159">これが機能するためには、ソースで [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/system.componentmodel.inotifypropertychanged(d=robot).aspx) を実装し、そのプロパティの set アクセス操作子により **PropertyChanged** イベントが発生することを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-159">For this to work, you must implement [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/system.componentmodel.inotifypropertychanged(d=robot).aspx) on the source and ensure its property setters raise the **PropertyChanged** event.</span></span> <span data-ttu-id="c57af-160">一般的には、次に示すように **OnPropertyChanged** メソッドのようなヘルパー メソッドを呼び出すようにします。</span><span class="sxs-lookup"><span data-stu-id="c57af-160">Common practice is to have them call a helper method like the **OnPropertyChanged** method, as shown below:</span></span>

```csharp
public class Customer : INotifyPropertyChanged
{
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged();
                }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
```
<span data-ttu-id="c57af-161">次に、**TextBlock** の代わりに **TextBox** を使用して ListView 内のテキストを編集可能にして、データ バインディングの **Mode** を **TwoWay** に設定していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="c57af-161">Then make the text in your ListView editable by using a **TextBox** instead of a **TextBlock**, and ensure that you set the **Mode** on your data bindings to **TwoWay**.</span></span>

```xaml
<ListView ItemsSource="{x:Bind Customers}"
    HorizontalAlignment="Center"
    VerticalAlignment="Center">
    <ListView.ItemTemplate>
        <DataTemplate x:DataType="local:Customer">
            <TextBox Text="{x:Bind Name, Mode=TwoWay}"/>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

<span data-ttu-id="c57af-162">これが機能することを確認する簡単な方法は、TextBox コントロールと OneWay バインディングを持つ 2 つ目の ListView を追加することです。</span><span class="sxs-lookup"><span data-stu-id="c57af-162">A quick way to ensure that this works is to add a second ListView with TextBox controls and OneWay bindings.</span></span> <span data-ttu-id="c57af-163">1 つ目の一覧を編集すると、2 つ目の一覧の値が自動的に変更されます。</span><span class="sxs-lookup"><span data-stu-id="c57af-163">The values in the second list will automatically change as you edit the first one.</span></span>

> [!NOTE]
> <span data-ttu-id="c57af-164">ListView 内で直接編集することは、双方向のバインディングの動作を表示するための簡単な方法ですが、ユーザビリティが複雑になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c57af-164">Editing directly inside a ListView is a simple way to show Two-Way binding in action, but can lead to usability complications.</span></span> <span data-ttu-id="c57af-165">アプリをさらに進める場合は、[他の XAML コントロール](../design/controls-and-patterns/controls-and-events-intro.md)を使用してデータを編集し、ListView を表示専用として維持することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c57af-165">If you're looking to take your app further, consider using [other XAML controls](../design/controls-and-patterns/controls-and-events-intro.md) to edit your data, and keep your ListView as display-only.</span></span>

## <a name="going-further"></a><span data-ttu-id="c57af-166">追加情報</span><span class="sxs-lookup"><span data-stu-id="c57af-166">Going Further</span></span>

<span data-ttu-id="c57af-167">双方向バインディングで顧客の一覧を作成したので、リンクしたドキュメントに自由に戻ってテストしてください。</span><span class="sxs-lookup"><span data-stu-id="c57af-167">Now that you’ve created a list of customers with two-way binding, feel free to go back through the docs we’ve linked you to and experiment.</span></span> <span data-ttu-id="c57af-168">基本および詳細なバインディングの手順を説明したチュートリアルが必要な場合、または[マスター/詳細パターン](../design/controls-and-patterns/master-details.md)のようなコントロールを調査してより強力な UI を作成する場合は、[データ バインディングのチュートリアル](../data-binding/xaml-basics-data-binding.md)を参照することもできます。</span><span class="sxs-lookup"><span data-stu-id="c57af-168">You can also check out our [data binding tutorial](../data-binding/xaml-basics-data-binding.md) if you want a step-by-step walkthrough of basic and advanced bindings, or investigate controls like the [master/details pattern](../design/controls-and-patterns/master-details.md) to make a more robust UI.</span></span>

## <a name="useful-apis-and-docs"></a><span data-ttu-id="c57af-169">便利な API とドキュメント</span><span class="sxs-lookup"><span data-stu-id="c57af-169">Useful APIs and docs</span></span>

<span data-ttu-id="c57af-170">データ バインディングを操作するうえで役立つ API の簡単な概要とその他の役立つドキュメントを次に示します。</span><span class="sxs-lookup"><span data-stu-id="c57af-170">Here's a quick summary of APIs and other useful documentation to help you get started working with Data Binding.</span></span>

### <a name="useful-apis"></a><span data-ttu-id="c57af-171">便利な API</span><span class="sxs-lookup"><span data-stu-id="c57af-171">Useful APIs</span></span>

| <span data-ttu-id="c57af-172">API</span><span class="sxs-lookup"><span data-stu-id="c57af-172">API</span></span> | <span data-ttu-id="c57af-173">説明</span><span class="sxs-lookup"><span data-stu-id="c57af-173">Description</span></span> |
|------|---------------|
| [<span data-ttu-id="c57af-174">データ テンプレート</span><span class="sxs-lookup"><span data-stu-id="c57af-174">Data template</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.DataTemplate) | <span data-ttu-id="c57af-175">UI 内の特定の要素の表示を可能にするデータ オブジェクトの視覚的構造について説明します。</span><span class="sxs-lookup"><span data-stu-id="c57af-175">Describes the visual structure of a data object, allowing for the display of specific elements in the UI.</span></span> |
| [<span data-ttu-id="c57af-176">x:Bind</span><span class="sxs-lookup"><span data-stu-id="c57af-176">x:Bind</span></span>](../xaml-platform/x-bind-markup-extension.md) | <span data-ttu-id="c57af-177">推奨される x:Bind マークアップ拡張に関するドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="c57af-177">Documentation on the recommended x:Bind markup extension.</span></span> |
| [<span data-ttu-id="c57af-178">バインディング</span><span class="sxs-lookup"><span data-stu-id="c57af-178">Binding</span></span>](../xaml-platform/binding-markup-extension.md) | <span data-ttu-id="c57af-179">以前の Binding マークアップ拡張に関するドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="c57af-179">Documentation on the older Binding markup extension.</span></span> |
| [<span data-ttu-id="c57af-180">ListView</span><span class="sxs-lookup"><span data-stu-id="c57af-180">ListView</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) | <span data-ttu-id="c57af-181">データ アイテムの垂直のスタックを表示する UI コントロールです。</span><span class="sxs-lookup"><span data-stu-id="c57af-181">A UI control that displays data items in a vertical stack.</span></span> |
| [<span data-ttu-id="c57af-182">TextBox</span><span class="sxs-lookup"><span data-stu-id="c57af-182">TextBox</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBox) | <span data-ttu-id="c57af-183">UI で編集可能なテキスト データを表示するための基本的なテキスト コントロールです。</span><span class="sxs-lookup"><span data-stu-id="c57af-183">A basic text control for displaying editable text data in the UI.</span></span> |
| [<span data-ttu-id="c57af-184">INotifyPropertyChanged</span><span class="sxs-lookup"><span data-stu-id="c57af-184">INotifyPropertyChanged</span></span>](https://msdn.microsoft.com/library/system.componentmodel.inotifypropertychanged(d=robot).aspx) | <span data-ttu-id="c57af-185">データを監視可能にし、データ バインディングに提供するインターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="c57af-185">The interface for making data observable, providing it to a data binding.</span></span> |
| [<span data-ttu-id="c57af-186">ItemsControl</span><span class="sxs-lookup"><span data-stu-id="c57af-186">ItemsControl</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ItemsControl) | <span data-ttu-id="c57af-187">このクラスの **ItemsSource** プロパティにより、ListView がデータ ソースにバインドされます。</span><span class="sxs-lookup"><span data-stu-id="c57af-187">The **ItemsSource** property of this class allows a ListView to bind to a data source.</span></span> |

### <a name="useful-docs"></a><span data-ttu-id="c57af-188">役立つドキュメント</span><span class="sxs-lookup"><span data-stu-id="c57af-188">Useful docs</span></span>

| <span data-ttu-id="c57af-189">トピック</span><span class="sxs-lookup"><span data-stu-id="c57af-189">Topic</span></span> | <span data-ttu-id="c57af-190">説明</span><span class="sxs-lookup"><span data-stu-id="c57af-190">Description</span></span> |
|-------|----------------|
| [<span data-ttu-id="c57af-191">データ バインディングの詳細</span><span class="sxs-lookup"><span data-stu-id="c57af-191">Data binding in depth</span></span>](../data-binding/data-binding-in-depth.md) | <span data-ttu-id="c57af-192">データ バインディングの原則の基本的な概要</span><span class="sxs-lookup"><span data-stu-id="c57af-192">A basic overview of data binding principles</span></span> |
| [<span data-ttu-id="c57af-193">データ バインディングの概要</span><span class="sxs-lookup"><span data-stu-id="c57af-193">Data Binding overview</span></span>](../data-binding/data-binding-quickstart.md) | <span data-ttu-id="c57af-194">データ バインディングに関する詳細な概念情報です。</span><span class="sxs-lookup"><span data-stu-id="c57af-194">Detailed conceptual information on data binding.</span></span> |
| [<span data-ttu-id="c57af-195">リスト ビュー</span><span class="sxs-lookup"><span data-stu-id="c57af-195">List View</span></span>](../design/controls-and-patterns/listview-and-gridview.md) | <span data-ttu-id="c57af-196"> *\*DataTemplate** の実装を含む、ListView の作成と構成に関する情報</span><span class="sxs-lookup"><span data-stu-id="c57af-196">Information on creating and configuring a ListView, including implementation of a **DataTemplate**</span></span> |

## <a name="useful-code-samples"></a><span data-ttu-id="c57af-197">役立つコード サンプル</span><span class="sxs-lookup"><span data-stu-id="c57af-197">Useful code samples</span></span>

| <span data-ttu-id="c57af-198">コード サンプル</span><span class="sxs-lookup"><span data-stu-id="c57af-198">Code sample</span></span> | <span data-ttu-id="c57af-199">説明</span><span class="sxs-lookup"><span data-stu-id="c57af-199">Description</span></span> |
|-----------------|---------------|
| [<span data-ttu-id="c57af-200">データ バインディングのチュートリアル</span><span class="sxs-lookup"><span data-stu-id="c57af-200">Data binding tutorial</span></span>](../data-binding/xaml-basics-data-binding.md) | <span data-ttu-id="c57af-201">データ バインディングの基本に関する手順を説明したガイド付きエクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="c57af-201">A step-by-step guided experience through the basics of data binding.</span></span> |
| [<span data-ttu-id="c57af-202">ListView と GridView</span><span class="sxs-lookup"><span data-stu-id="c57af-202">ListView and GridView</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView) | <span data-ttu-id="c57af-203">データ バインディングを使用したより複雑な Listview を紹介します。</span><span class="sxs-lookup"><span data-stu-id="c57af-203">Explore more elaborate ListViews with data binding.</span></span> |
| [<span data-ttu-id="c57af-204">QuizGame</span><span class="sxs-lookup"><span data-stu-id="c57af-204">QuizGame</span></span>](https://github.com/Microsoft/Windows-appsample-networkhelper) | <span data-ttu-id="c57af-205">**INotifyPropertyChanged** の標準的な実装の **BindableBase** クラス ("Common" フォルダー内) を含む、データ バインディングの動作を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c57af-205">See data binding in action, including the **BindableBase** class (in the "Common" folder) for a standard implementation of **INotifyPropertyChanged**.</span></span> |
