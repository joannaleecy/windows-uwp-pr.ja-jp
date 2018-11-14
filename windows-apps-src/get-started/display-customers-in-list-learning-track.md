---
author: QuinnRadich
title: 学習トラック - 一覧での顧客の表示
description: 一覧で Customer オブジェクトのコレクションを表示するために行う必要があることについて説明します。
ms.author: quradic
ms.date: 05/07/2018
ms.topic: article
keywords: 概要, uwp, windows 10, 学習トラック, データ バインディング, 一覧
ms.localizationpriority: medium
ms.openlocfilehash: 4e58231d644616a088eb06f24a2465c240e10c16
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6184144"
---
# <a name="display-customers-in-a-list"></a>一覧での顧客の表示

UI 内で実際のデータを表示して操作することは多くのアプリの機能に不可欠です。 この記事では、一覧で Customer オブジェクトのコレクションを表示するために知っておく必要があることを示します。

これはチュートリアルではありません。 チュートリアルが必要な場合は、「[データ バインディングのチュートリアル](../data-binding/xaml-basics-data-binding.md)」を参照してください。このチュートリアルでは、手順を説明したガイド付きのエクスペリエンスが提供されます。

まず、データ バインディングの概要としくみに関する簡単な説明から始めます。 次に、**ListView** を UI に追加し、データ バインディングを追加し、データ バインディングを追加の機能でカスタマイズします。 

## <a name="what-do-you-need-to-know"></a>理解しておく必要があること

データ バインディングは、アプリのデータをその UI に表示する方法です。 これにより、アプリで*役割の分離*を使用できるため、UI をその他のコードから分離することができます。 このため、読みやすく保守が容易なより明確な概念モデルが作成されます。

すべてのデータ バインディングには、次の 2 つの部分があります。

* バインドするデータを提供するソース。
* データが表示される UI でのターゲット。

データ バインディングを実装するには、バインディングにデータを提供するソースにコードを追加する必要があります。 また、データ ソースのプロパティを指定する、XAML に 2 つのマークアップ拡張のいずれかを追加する必要があります。 2 つの種類の主な違いを次に示します。

* [**x:Bind**](../xaml-platform/x-bind-markup-extension.md) は厳密に型指定され、パフォーマンス向上のためコンパイル時にコードを生成します。 x:Bind は既定では 1 回限りのバインディングが指定され、変更されない読み取り専用のデータの高速表示のために最適化されます。
* [**バインディング**](../xaml-platform/binding-markup-extension.md)は弱く型指定され、実行時にまとめられます。 その結果、パフォーマンスは x:Bind より低下します。 ほとんどの場合、バインディングではなく x:Bind を使用する必要があります。 ただし、古いコードではこの問題が生じる可能性があります。 バインディングは既定では一方向のデータ転送が指定され、ソースで変更できる読み取り専用のデータのために最適化されます。

可能な限り **x:Bind** を使用することをお勧めします。この記事のスニペットで x:Bind について説明します。 相違点の詳細については、「[{x:Bind} と {Binding} の機能の比較](../data-binding/data-binding-in-depth.md#xbind-and-binding-feature-comparison)」を参照してください。

## <a name="create-a-data-source"></a>データ ソースの作成

最初に、Customer データを表すクラスを作成する必要があります。 参考のために、この必要最小限の例でのプロセスを示します。

```csharp
public class Customer
{
    public string Name { get; set; }
}
```

## <a name="create-a-list"></a>一覧の作成

顧客を表示するには、まずそれを保持する一覧を作成する必要があります。 [一覧表示](../design/controls-and-patterns/listview-and-gridview.md)はこのタスクに最適な基本的な XAML コントロールです。 ListView には現在ページ内での位置が必要であり、**ItemSource** プロパティの値が後で必要になります。

```xaml
<ListView ItemsSource=""
    HorizontalAlignment="Center"
    VerticalAlignment="Center"/>
```

ListView にデータをバインドしたら、ドキュメントに戻り、ニーズに最も合うように外観やレイアウトのカスタマイズをテストすることをお勧めします。

## <a name="bind-data-to-your-list"></a>一覧へのデータのバインド

バインディングを保持する基本的な UI を作成したので、ソースがバインディングを指定するように構成する必要があります。 その方法を示す例を以下に示します。

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

「[データ バインディングの概要](../data-binding/data-binding-quickstart.md#binding-to-a-collection-of-items)」では、項目のコレクションへのバインティングに関するセクションで、同様の問題について説明します。 この例では、次の重要な手順を示します。

* UI の分離コードでは、Customer オブジェクトを保持するための **ObservableCollection<T>** 型のプロパティを作成します。
* ListView の **ItemSource** をそのプロパティにバインドします。
* 一覧の各項目の表示方法を構成する、ListView の基本的な **ItemTemplate** を指定します。

レイアウトをカスタマイズする場合は、[リスト ビュー](../design/controls-and-patterns/listview-and-gridview.md)のドキュメントに自由に戻って、先ほど作成した **DataTemplate** を調整します。 ただし、Customers を編集する場合はどうすればよいでしょうか。

## <a name="edit-your-customers-through-the-ui"></a>UI を通じた Customers の編集

一覧で顧客を表示しましたが、データ B バインディングではより多くのことを行うことができます。 UI から直接データを編集できるとしたらどうでしょうか。 これを行うには、まずデータ バインディングの 3 つのモデルについて説明しましょう。

* *1 回限り*: このデータ バインディングは一度だけアクティブ化され、変更に対応しません。
* *一方向*: このデータ バインディングは、データ ソースに対して行われた変更で UI を更新します。
* *双方向*: このデータ バインディングは、データ ソースに対して行われた変更で UI を更新します。また、UI 内で行われた変更でデータを更新します。

以前のコード スニペットに従った場合、行ったバインディングでは x:Bind を使用し、モードを使用しないため、1 回限りのバインディングになります。 UI から直接 Customers を編集する場合は、データからの変更が Customer オブジェクトに戻されるように、双方向のバインディングに変更する必要があります。 詳細については、「[データ バインディングの詳細](../data-binding/data-binding-in-depth.md)」を参照してください。

データ ソースが変更された場合は、双方向バインディングも更新されます。 これが機能するためには、ソースで [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/system.componentmodel.inotifypropertychanged(d=robot).aspx) を実装し、そのプロパティの set アクセス操作子により **PropertyChanged** イベントが発生することを確認する必要があります。 一般的には、次に示すように **OnPropertyChanged** メソッドのようなヘルパー メソッドを呼び出すようにします。

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
次に、**TextBlock** の代わりに **TextBox** を使用して ListView 内のテキストを編集可能にして、データ バインディングの **Mode** を **TwoWay** に設定していることを確認します。

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

これが機能することを確認する簡単な方法は、TextBox コントロールと OneWay バインディングを持つ 2 つ目の ListView を追加することです。 1 つ目の一覧を編集すると、2 つ目の一覧の値が自動的に変更されます。

> [!NOTE]
> ListView 内で直接編集することは、双方向のバインディングの動作を表示するための簡単な方法ですが、ユーザビリティが複雑になる可能性があります。 アプリをさらに進める場合は、[他の XAML コントロール](../design/controls-and-patterns/controls-and-events-intro.md)を使用してデータを編集し、ListView を表示専用として維持することを検討してください。

## <a name="going-further"></a>追加情報

双方向バインディングで顧客の一覧を作成したので、リンクしたドキュメントに自由に戻ってテストしてください。 基本および詳細なバインディングの手順を説明したチュートリアルが必要な場合、または[マスター/詳細パターン](../design/controls-and-patterns/master-details.md)のようなコントロールを調査してより強力な UI を作成する場合は、[データ バインディングのチュートリアル](../data-binding/xaml-basics-data-binding.md)を参照することもできます。

## <a name="useful-apis-and-docs"></a>便利な API とドキュメント

データ バインディングを操作するうえで役立つ API の簡単な概要とその他の役立つドキュメントを次に示します。

### <a name="useful-apis"></a>便利な API

| API | 説明 |
|------|---------------|
| [データ テンプレート](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.DataTemplate) | UI 内の特定の要素の表示を可能にするデータ オブジェクトの視覚的構造について説明します。 |
| [x:Bind](../xaml-platform/x-bind-markup-extension.md) | 推奨される x:Bind マークアップ拡張に関するドキュメントです。 |
| [バインディング](../xaml-platform/binding-markup-extension.md) | 以前の Binding マークアップ拡張に関するドキュメントです。 |
| [ListView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ListView) | データ アイテムの垂直のスタックを表示する UI コントロールです。 |
| [TextBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.TextBox) | UI で編集可能なテキスト データを表示するための基本的なテキスト コントロールです。 |
| [INotifyPropertyChanged](https://msdn.microsoft.com/library/system.componentmodel.inotifypropertychanged(d=robot).aspx) | データを監視可能にし、データ バインディングに提供するインターフェイスです。 |
| [ItemsControl](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ItemsControl) | このクラスの **ItemsSource** プロパティにより、ListView がデータ ソースにバインドされます。 |

### <a name="useful-docs"></a>役立つドキュメント

| トピック | 説明 |
|-------|----------------|
| [データ バインディングの詳細](../data-binding/data-binding-in-depth.md) | データ バインディングの原則の基本的な概要 |
| [データ バインディングの概要](../data-binding/data-binding-quickstart.md) | データ バインディングに関する詳細な概念情報です。 |
| [リスト ビュー](../design/controls-and-patterns/listview-and-gridview.md) |  **DataTemplate** の実装を含む、ListView の作成と構成に関する情報 |

## <a name="useful-code-samples"></a>役立つコード サンプル

| コード サンプル | 説明 |
|-----------------|---------------|
| [データ バインディングのチュートリアル](../data-binding/xaml-basics-data-binding.md) | データ バインディングの基本に関する手順を説明したガイド付きエクスペリエンスです。 |
| [ListView と GridView](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView) | データ バインディングを使用したより複雑な Listview を紹介します。 |
| [QuizGame](https://github.com/Microsoft/Windows-appsample-networkhelper) | **INotifyPropertyChanged** の標準的な実装の **BindableBase** クラス ("Common" フォルダー内) を含む、データ バインディングの動作を参照してください。 |
