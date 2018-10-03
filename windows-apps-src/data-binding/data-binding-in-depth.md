---
author: mcleblanc
ms.assetid: 41E1B4F1-6CAF-4128-A61A-4E400B149011
title: データ バインディングの詳細
description: データ バインディングは、アプリの UI でデータを表示し、必要に応じてそのデータとの同期を保つ方法です。
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 72c7037e9e99ad69ff13c65fb2195bc6e3f8110f
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/02/2018
ms.locfileid: "4259157"
---
# <a name="data-binding-in-depth"></a>データ バインディングの詳細



**重要な API**

-   [**{x:Bind} マークアップ拡張**](../xaml-platform/x-bind-markup-extension.md)
-   [**Binding クラス**](https://msdn.microsoft.com/library/windows/apps/BR209820)
-   [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713)
-   [**INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899)

> [!Note]
> このトピックでは、データ バインディングの機能について詳しく説明します。 簡潔で実用的な紹介については、「[データ バインディングの概要](data-binding-quickstart.md)」をご覧ください。


データ バインディングは、アプリの UI でデータを表示し、必要に応じてそのデータとの同期を保つ方法です。 データ バインディングによって、UI の問題からデータの問題を切り離すことができるため、概念的なモデルが簡素化されると共に、アプリの読みやすさ、テストの容易性、保守容易性が向上します。

データ バインディングは、UI が最初に表示されたときにデータ ソースからの値を表示するだけの場合に使うことができ、それらの値の変化に応答するために使うことはできません。 これは 1 回限りのバインディングと呼ばれており、実行時に値が変更しないデータに適しています。 さらに、値を "監視" し、値が変化したときに UI を更新することを選択できます。 これは一方向バインディングと呼ばれており、読み取り専用のデータに適しています。 最終的には、ユーザーが UI で値に対して行った変更が自動的にデータ ソースにプッシュバックされるように、監視と更新の両方を行うことを選択できます。 これは双方向バインディングと呼ばれており、読み書き可能なデータに適しています。 例をいくつか紹介します。

-   1 回限りのバインディングを使って、[**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) を現在のユーザーの写真にバインドできます。
-   一方向バインディングを使って、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) を新聞のセクションでグループ化された、リアルタイムのニュース記事のコレクションにバインドできます。
-   双方向バインディングを使って、[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) をフォーム内の顧客の名前にバインドできます。

バインディングには 2 つの種類があり、いずれも通常は UI のマークアップで宣言されます。 [{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)と [{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)のいずれを使うかを選択できます。 また、同じアプリや同じ UI 要素で、この 2 つを組み合わせて使うこともできます。 {x:Bind} は Windows 10 の新機能で、パフォーマンスが向上しています。 このトピックで説明されているすべての詳細は、特に明記していない限り、両方の種類のバインディングに適用されます。

**{x:Bind} の使い方を示すサンプル アプリ**

-   [{x:Bind} のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619989)。
-   [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame)。
-   [XAML UI の基本のサンプル](http://go.microsoft.com/fwlink/p/?linkid=619992)。

**{Binding} の使い方を示すサンプル アプリ**

-   [Bookstore1](http://go.microsoft.com/fwlink/?linkid=532950) アプリのダウンロード。
-   [Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) アプリのダウンロード。

## <a name="every-binding-involves-these-pieces"></a>すべてのバインディングに関連する要素

-   *バインディング ソース*。 これは、バインディング用のデータのソースで、UI に表示する値を持つメンバーが含まれる、任意のクラスのインスタンスを使うことができます。
-   *バインディング ターゲット*。 これは、データを表示する UI の [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) の [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) です。
-   *バインディング オブジェクト*。 これは、ソースからターゲットに、および必要に応じてターゲットからソースに、データ値を転送する要素です。 バインディング オブジェクトは、XAML の読み込み時に [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) または [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) マークアップ拡張から作成されます。

次のセクションでは、バインディング ソース、バインディング ターゲット、バインド オブジェクトについて詳しく見てみます。 また、以下のセクションでは、**HostViewModel** という名前のクラスに属する **NextButtonText** という名前の文字列プロパティに、ボタンのコンテンツをバインドする例へのリンクも示します。

### <a name="binding-source"></a>バインディング ソース

バインディング ソースとして使用できるクラスの非常に基本的な実装を次に示します。

> [!Note]
> Visual C コンポーネント拡張機能と[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)を使用しているかどうか (、C++/cli CX) [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)属性をバインディング ソース クラスに追加する必要があります。 [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) を使用している場合、この属性は必要ありません。 コード スニペットについては、「[詳細ビューの追加](data-binding-quickstart.md#adding-a-details-view)」をご覧ください。

```csharp
public class HostViewModel
{
    public HostViewModel()
    {
        this.NextButtonText = "Next";
    }

    public string NextButtonText { get; set; }
}
```

**HostViewModel** の実装とその **NextButtonText** プロパティは、1 回限りのバインディングにのみ適しています。 ただし、一方向バインディングと双方向バインディングは非常に一般的であり、これらの種類のバインディングでは、UI はバインディング ソースのデータ値の変化に対応して自動的に更新されます。 これらの種類のバインディングが正常に動作するには、バインディング ソースをバインディング オブジェクトから "監視可能" にする必要があります。 この例では、**NextButtonText** プロパティに対して一方向または双方向バインディングを設定する場合、実行時にこのプロパティの値に対して発生するすべての変更を、バインディング オブジェクトから監視可能にする必要があります。

そのための方法の 1 つは、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/BR242356) からバインディング ソースを表すクラスを派生させ、[**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) を通じてデータ値を公開することです。 これが、[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) を監視可能にする方法です。 **FrameworkElements** は、そのまま利用できる優れたバインディング ソースです。

より簡単にクラスを監視可能にする方法 (および既に基底クラスがあるクラスで必要な方法) は、[**System.ComponentModel.INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) を実装することです。 この方法は、**PropertyChanged** という名前の単一のイベントを実装するだけです。 **HostViewModel** を使った例を次に示します。

> [!Note]
> C++/cli CX、 [**Windows::UI::Xaml::Data::INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899)を実装して、バインディング ソース クラスのある[**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872)または[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878)を実装する必要があります。

```csharp
public class HostViewModel : INotifyPropertyChanged
{
    private string nextButtonText;

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    public HostViewModel()
    {
        this.NextButtonText = "Next";
    }

    public string NextButtonText
    {
        get { return this.nextButtonText; }
        set
        {
            this.nextButtonText = value;
            this.OnPropertyChanged();
        }
    }

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        // Raise the PropertyChanged event, passing the name of the property whose value has changed.
        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
```

これで、**NextButtonText** プロパティは監視可能です。 そのプロパティへの一方向または双方向のバインディングを作成する場合 (方法については後述)、作成したバインディング オブジェクトは **PropertyChanged** イベントを受信登録します。 そのイベントが発生すると、バインディング オブジェクトのハンドラーは、変更されたプロパティの名前を含む引数を受け取ります。 このようにして、バインディング オブジェクトはどのプロパティの値が残っており、再び読み取る必要があるかを識別します。

前に示したパターンを何度も実装する必要はありません。[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) サンプル (Common フォルダー) に含まれている **BindableBase** 基底クラスから派生させることができます。 どのようになるかを示す例を以下に示します。

```csharp
public class HostViewModel : BindableBase
{
    private string nextButtonText;

    public HostViewModel()
    {
        this.NextButtonText = "Next";
    }

    public string NextButtonText
    {
        get { return this.nextButtonText; }
        set { this.SetProperty(ref this.nextButtonText, value); }
    }
}
```

[**String.Empty**](https://msdn.microsoft.com/library/windows/apps/xaml/system.string.empty.aspx) または **null** の引数を使って **PropertyChanged** イベントを発生させることは、オブジェクトのすべての非インデクサー プロパティを再び読み取る必要があることを示します。 特定のインデクサーの場合は "Item\[*indexer*\]" (*indexer* はインデックス値) の引数、すべてのインデクサーの場合は "Item\[\]" の値を使って、オブジェクトのインデクサー プロパティが変更されたことを示すイベントを発生させることができます。

バインディング ソースは、プロパティにデータが含まれる単一のオブジェクト、またはオブジェクトのコレクションとして処理できます。 C# と Visual Basic コードでは、実行時に変更されないコレクションを表示する [**List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx) を実装するオブジェクトへの 1 回限りのバインディングを設定できます。 監視可能なコレクション (コレクションの項目の追加と削除を監視する) の場合、代わりに [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) への一方向バインディングを設定します。 C++ コードでは、監視可能なコレクションと監視可能ではないコレクションの両方について、[**Vector&lt;T&gt;**](https://msdn.microsoft.com/library/dn858385.aspx) にバインドできます。 独自のコレクション クラスにバインドするには、次の表をご覧ください。

| シナリオ                                                        | C# と VB (CLR)                                                                                                                                                                                                                                                                                                                                                                                                                   | C++/CX                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
|-----------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| オブジェクトにバインドする。                                              | どのオブジェクトでもかまいません。                                                                                                                                                                                                                                                                                                                                                                                                                 | オブジェクトで [**BindableAttribute**](https://msdn.microsoft.com/library/windows/apps/Hh701872) を指定するか、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装する必要があります。                                                                                                                                                                                                                                                                                                             |
| バインドされたオブジェクトからプロパティ変更の更新を取得する。                | オブジェクトで [**System.ComponentModel. INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) を実装する必要があります。                                                                                                                                                                                                                                                                                                         | オブジェクトで [**Windows.UI.Xaml.Data. INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/BR209899) を実装する必要があります。                                                                                                                                                                                                                                                                                                                                                           |
| コレクションにバインドする。                                           | [**List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx)                                                                                                                                                                                                                                                                                                                                                                            | [**Platform::Collections::Vector&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/hh441570.aspx)                                                                                                                                                                                                                                                                                                                                                                                         |
| バインドされたコレクションからコレクション変更の更新を取得する。          | [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx)                                                                                                                                                                                                                                                                                                                                        | [**Windows::Foundation::Collections::IObservableVector&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/br226052.aspx)                                                                                                                                                                                                                                                                                                                                                                                         |
| バインドをサポートするコレクションを実装する。                   | [**List(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/6sh2ey19.aspx) を拡張するか、[**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx)、[**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/5y536ey6.aspx)(Of [**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx))、[**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ienumerable.aspx)、または [**IEnumerable**](https://msdn.microsoft.com/library/windows/apps/xaml/9eekhta0.aspx)(Of **Object**) を実装します。 汎用の **IList(Of T)** と **IEnumerable(Of T)** へのバインドはサポートされていません。 | [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979)、[**IBindableIterable**](https://msdn.microsoft.com/library/windows/apps/Hh701957)、[**IVector**](https://msdn.microsoft.com/library/windows/apps/BR206631)&lt;[**Object**](https://msdn.microsoft.com/library/windows/apps/xaml/system.object.aspx)^&gt;、[**IIterable**](https://msdn.microsoft.com/library/windows/apps/BR226024)&lt;**Object**^&gt;、**IVector**&lt;[**IInspectable**](https://msdn.microsoft.com/library/BR205821)\*&gt;、または **IIterable**&lt;**IInspectable**\*&gt; を実装します。 汎用の **IVector&lt;T&gt;** と **IIterable&lt;T&gt;** へのバインドはサポートされていません。 |
| コレクション変更の更新をサポートするコレクションを実装する。 | [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) を拡張するか、(汎用ではない) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) と [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) を実装します。                                                                                                                                                               | [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979) と [**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974) を実装します。                                                                                                                                                                                                                                                                                                                       |
| 段階的読み込みをサポートするコレクションを実装する。       | [**ObservableCollection(Of T)**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) を拡張するか、(汎用ではない) [**IList**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.ilist.aspx) と [**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) を実装します。 さらに、[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) を実装します。                                                          | [**IBindableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701979)、[**IBindableObservableVector**](https://msdn.microsoft.com/library/windows/apps/Hh701974)、[**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) を実装します。                                                                                                                                                                                                                                         |

段階的読み込みを使うと、任意の大きさのデータ ソースにリスト コントロールをバインドすると同時に、高パフォーマンスを実現できます。 たとえば、一度にすべての結果を読む込むことなく、Bing の画像クエリ結果にリスト コントロールをバインドすることができます。 この場合、すぐに読み込むのは一部の結果だけで、他の結果は必要に応じて読み込みます。 段階的読み込みをサポートするには、コレクション変更通知をサポートするデータ ソースに [**ISupportIncrementalLoading**](https://msdn.microsoft.com/library/windows/apps/Hh701916) を実装する必要があります。 データ バインディング エンジンがより多くのデータを要求する場合は、UI を更新するためにデータ ソースで適切な要求を行い、結果を統合して、適切な通知を送信する必要があります。

### <a name="binding-target"></a>バインディング ターゲット

以下の 2 つの例で、**Button.Content** プロパティはバインディング ターゲットであり、その値はバインディング オブジェクトを宣言するマークアップ拡張に設定されます。 最初に [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) を示し、次に [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) を示します。 マークアップでバインディングを宣言する方法は一般的です (便利で、読みやすく、ツールで処理できます)。 ただし、必要な場合は、マークアップを使わずに、命令を使って (プログラムで) [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) クラスのインスタンスを作成できます。

```xaml
<Button Content="{x:Bind ...}" ... />
```

```xaml
<Button Content="{Binding ...}" ... />
```

### <a name="binding-object-declared-using-xbind"></a>{x:Bind} を使って宣言されたバインディング オブジェクト

[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) マークアップを作成する前に必要な手順が 1 つあります。 マークアップのページを表すクラスからバインディング ソース クラスを公開する必要があります。 そのためには、**HostView** ページ クラスに (ここでは **HostViewModel** 型の) プロパティを追加します。

```csharp
namespace QuizGame.View
{
    public sealed partial class HostView : Page
    {
        public HostView()
        {
            this.InitializeComponent();
            this.ViewModel = new HostViewModel();
        }
    
        public HostViewModel ViewModel { get; set; }
    }
}
```

これが完了したら、バインディング オブジェクトを宣言するマークアップを詳しく見ていくことができます。 次の例では、前の「バインディング ターゲット」セクションで使用したものと同じ **Button.Content** バインディング ターゲットを使って、**HostViewModel.NextButtonText** プロパティにバインドされたバインディング ターゲットを示します。

```xaml
<Page x:Class="QuizGame.View.HostView" ... >
    <Button Content="{x:Bind Path=ViewModel.NextButtonText, Mode=OneWay}" ... />
</Page>
```

**Path** として指定している値に注意してください。 この値はページ自体のコンテキストで解釈され、この場合、パスは、先ほど **HostView** ページに追加した **ViewModel** プロパティを参照することによって開始されます。 このプロパティは **HostViewModel** インスタンスを返すため、そのオブジェクトにドットを付けて **HostViewModel.NextButtonText** プロパティにアクセスできます。 さらに、**Mode** を指定して、[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) の既定値である 1 回限りのバインディングをオーバーライドします。

[**Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) プロパティは、入れ子になったプロパティ、添付プロパティ、整数と文字列のインデクサーにバインドするためのさまざまな構文オプションをサポートしています。 詳しくは、「[Property-path 構文](https://msdn.microsoft.com/library/windows/apps/Mt185586)」をご覧ください。 文字列のインデクサーにバインドすると、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装しなくても動的プロパティにバインドする効果を得られます。 その他の設定については、「[{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)」をご覧ください。

> [!Note]
> [**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text)への変更は、双方向のバインド ソース[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683)は、フォーカスを失ったときに、およびユーザーのキーストロークのたびに送信されます。

**DataTemplate と x:DataType**

[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) 内で (項目テンプレート、コンテンツ テンプレート、ヘッダー テンプレートのいずれとして使用される場合でも)、**Path** の値はページのコンテキストではなく、テンプレート化されたデータ オブジェクトのコンテキストで解釈されています。 {x:Bind} をデータ テンプレートで使用する場合、コンパイル時にバインディングを検証できるように (バインディング用に効率的なコードを生成できるように) するために、**DataTemplate** では、**x:DataType** を使って、データ オブジェクトの型を宣言する必要があります。 次に示す例は、**SampleDataGroup** オブジェクトのコレクションにバインドされている、項目コントロールの **ItemTemplate** として使うことができます。

```xaml
<DataTemplate x:Key="SimpleItemTemplate" x:DataType="data:SampleDataGroup">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{x:Bind Title}"/>
      <TextBlock Text="{x:Bind Description}"/>
    </StackPanel>
  </DataTemplate>
```

**Path 内の厳密に型指定されていないオブジェクト**

たとえば、SampleDataGroup という名前の型があり、Title という名前の文字列プロパティを実装しているとします。 また、MainPage.SampleDataGroupAsObject プロパティがあり、これは型オブジェクトのプロパティですが、実際には SampleDataGroup のインスタンスを返すとします。 バインディング `<TextBlock Text="{x:Bind SampleDataGroupAsObject.Title}"/>` は、型オブジェクトで Title プロパティが見つからないため、コンパイル エラーとなります。 これを解決するには、Path 構文に `<TextBlock Text="{x:Bind ((data:SampleDataGroup)SampleDataGroupAsObject).Title}"/>` などのキャストを追加します。 Element がオブジェクトとして宣言されているが、実際には TextBlock である、`<TextBlock Text="{x:Bind Element.Text}"/>` という例を考えてみます。 この場合も、`<TextBlock Text="{x:Bind ((TextBlock)Element).Text}"/>` のようにキャストによって問題が解決されます。

**データを非同期的に読み込む場合**

ページの部分クラスに、**{x:Bind}** をサポートするコードがコンパイル時に生成されます。 これらのファイルは `obj` フォルダー内にあり、`<view name>.g.cs` (C# の場合) などの名前が付けられています。 生成されたコードには、ページの [**Loading**](https://msdn.microsoft.com/library/windows/apps/BR208706) イベントのハンドラーが含まれており、このハンドラーが、ページのバインディングを表す生成されたクラスで **Initialize** メソッドを呼び出します。 次に、**Initialize** が **Update** を呼び出して、バインディング ソースとターゲットの間のデータの移動を開始します。 **Loading** は、ページまたはユーザー コントロールの最初の測定パスの直前に発生します。 したがって、データが非同期的に読み込まれる場合、**Initialize** が呼び出された時点で準備ができていない可能性があります。 そのため、データを読み込んだ後、`this.Bindings.Update();` を呼び出すことによって、1 回限りのバインディングを強制的に実行できます。 非同期的に読み込まれたデータについて 1 回限りのバインディングのみが必要な場合は、この方法でバインディングを初期化する方が、一方向のバインドを使って変更をリッスンするよりもずっと低コストです。 データがきめ細かく変更されない場合や、特定のアクションの一部として更新される可能性が高い場合は、バインディングを 1 回限りにし、いつでも **Update** を呼び出すことによって、強制的に手動更新を実行できます。

> [!Note]
> **{x:Bind}** は、JSON オブジェクトのディクショナリ構造内を移動する場合などの遅延バインディングのシナリオや、プロパティ名の語彙的な一致に基づく厳密ではない型指定であるダック タイピング ("アヒルのように歩き、泳ぎ、鳴くならば、それはアヒルである") には適していません。 ダック タイピングでは、Age プロパティへのバインディングは、Person オブジェクトでも Wine オブジェクトでも同様に満足されます。 このようなシナリオでは、**{Binding}** を使用します。

### <a name="binding-object-declared-using-binding"></a>{Binding} を使って宣言されたバインディング オブジェクト

[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) は、既定で、マークアップ ページの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) にバインドしていることを前提としています。 したがって、ページの **DataContext** を、バインディング ソース クラス (ここでは **HostViewModel** 型) のインスタンスに設定します。 次の例は、バインディング オブジェクトを宣言するマークアップを示しています。 前の「バインディング ターゲット」セクションで使用したものと同じ **Button.Content** バインディング ターゲットを使っており、**HostViewModel.NextButtonText** プロパティにバインドします。

```xaml
<Page xmlns:viewmodel="using:QuizGame.ViewModel" ... >
    <Page.DataContext>
        <viewmodel:HostViewModel/>
    </Page.DataContext>
    ...
    <Button Content="{Binding Path=NextButtonText}" ... />
</Page>
```

**Path** として指定している値に注意してください。 この値は、ページの [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) で解釈されます。この例では、**HostViewModel** のインスタンスに設定されます。 パスは **HostViewModel.NextButtonText** プロパティを参照します。 [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) の既定値である一方向のバインディングが適切であるため、**Mode** は省略できます。

UI 要素の [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) の既定値は、その親から継承された値です。 もちろん **DataContext** を明示的に設定することによってこの既定値 (さらに既定で子に継承される) をオーバーライドすることができます。 要素で明示的に **DataContext** を設定することは、同じソースを使う複数のバインディングが必要な場合に便利です。

バインディング オブジェクトには **Source** プロパティがあり、その既定値はバインディングが宣言されている UI 要素の [**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) です。 この既定値をオーバーライドするには、バインディングで **Source**、**RelativeSource**、または **ElementName** を明示的に設定します (詳しくは、「[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782)」をご覧ください)。

[**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) 内で、[**DataContext**](https://msdn.microsoft.com/library/windows/apps/BR208713) はテンプレート化されるデータ オブジェクトに設定されています。 次の例は、**Title** と **Description** という名前の文字列プロパティを持つ任意の型のコレクションにバインドされている、項目コントロールの **ItemTemplate** として使うことができます

```xaml
<DataTemplate x:Key="SimpleItemTemplate">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{Binding Title}"/>
      <TextBlock Text="{Binding Description"/>
    </StackPanel>
  </DataTemplate>
```

> [!Note]
> 既定では、 [**TextBox.Text**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.text)への変更は、 [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683)がフォーカスを失ったとき双方向のバインド ソースに送信されます。 変更をユーザーの各キーストロークの後に送信するには、マークアップのバインディングで **UpdateSourceTrigger** を **PropertyChanged** に設定します。 **UpdateSourceTrigger** を **Explicit** に設定することによって、変更が送信されるタイミングを完全に制御することもできます。 次に、テキスト ボックスでのイベント (通常 [**TextBox.TextChanged**](https://msdn.microsoft.com/library/windows/apps/BR209683)) を処理し、ターゲットで [**GetBindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.getbindingexpression) を呼び出して [**BindingExpression**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.aspx) オブジェクトを取得します。最後に、[**BindingExpression.UpdateSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.bindingexpression.updatesource.aspx) を呼び出して、データ ソースをプログラムで更新します。

[**Path**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.path) プロパティは、入れ子になったプロパティ、添付プロパティ、整数と文字列のインデクサーにバインドするためのさまざまな構文オプションをサポートしています。 詳しくは、「[Property-path 構文](https://msdn.microsoft.com/library/windows/apps/Mt185586)」をご覧ください。 文字列のインデクサーにバインドすると、[**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) を実装しなくても動的プロパティにバインドする効果を得られます。 [**ElementName**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.elementname) プロパティは要素間のバインディングに便利です。 [**RelativeSource**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.relativesource) プロパティにはいくつかの用途があり、そのうちの 1 つが、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/BR209391) 内でバインディングをテンプレート化するためのより強力な方法としての用途です。 その他の設定については、「[{Binding} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204782)」と [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) クラスの説明をご覧ください。

## <a name="what-if-the-source-and-the-target-are-not-the-same-type"></a>ソースとターゲットが同じ型ではない場合

ブール型プロパティの値に基づいて UI 要素の表示を制御する場合、数値の範囲や傾向に応じた色で UI 要素をレンダリングする場合、または文字列を想定している UI 要素のプロパティに日付や時刻の値を表示する場合は、値の型を別の型に変換する必要があります。 バインディング ソース クラスから適切な型の別のプロパティを公開し、変換ロジックをカプセル化し、その中でテストできるようにしておくことが、適切なソリューションである場合があります。 ただし、この方法はソースとターゲットのプロパティの数が多くなり、組み合わせが多くなると、柔軟性も拡張性もありません。 その場合は、いくつかのオプションがあります。

* {X:Bind} を使用している場合、関数に直接バインドして変換を行うことができます
* または、変換を実行するためのオブジェクトである、値コンバーターを指定することができます 

## <a name="value-converters"></a>値コンバーター

[**DateTime**](https://msdn.microsoft.com/library/windows/apps/xaml/system.datetime.aspx) 値を月を含む文字列値に変換する、1 回限りまたは一方向のバインディングに適した値コンバーターを以下に示します。 このクラスは、[**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903) を実装します。

```csharp
public class DateToStringConverter : IValueConverter
{
    // Define the Convert method to convert a DateTime value to 
    // a month string.
    public object Convert(object value, Type targetType, 
        object parameter, string language)
    {
        // value is the data from the source object.
        DateTime thisdate = (DateTime)value;
        int monthnum = thisdate.Month;
        string month;
        switch (monthnum)
        {
            case 1:
                month = "January";
                break;
            case 2:
                month = "February";
                break;
            default:
                month = "Month not found";
                break;
        }
        // Return the value to pass to the target.
        return month;
    }

    // ConvertBack is not implemented for a OneWay binding.
    public object ConvertBack(object value, Type targetType, 
        object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
```

```vbnet
Public Class DateToStringConverter
    Implements IValueConverter

    ' Define the Convert method to change a DateTime object to
    ' a month string.
    Public Function Convert(ByVal value As Object, -
        ByVal targetType As Type, ByVal parameter As Object, -
        ByVal language As String) As Object -
        Implements IValueConverter.Convert

        ' value is the data from the source object.
        Dim thisdate As DateTime = CType(value, DateTime)
        Dim monthnum As Integer = thisdate.Month
        Dim month As String
        Select Case (monthnum)
            Case 1
                month = "January"
            Case 2
                month = "February"
            Case Else
                month = "Month not found"
        End Select
        ' Return the value to pass to the target.
        Return month

    End Function

    ' ConvertBack is not implemented for a OneWay binding.
    Public Function ConvertBack(ByVal value As Object, -
        ByVal targetType As Type, ByVal parameter As Object, -
        ByVal language As String) As Object -
        Implements IValueConverter.ConvertBack

        Throw New NotImplementedException

    End Function
End Class
```

次に、バインディング オブジェクトのマークアップでその値コンバーターを利用する方法を示します。

```xaml
<UserControl.Resources>
  <local:DateToStringConverter x:Key="Converter1"/>
</UserControl.Resources>

...

<TextBlock Grid.Column="0" 
  Text="{x:Bind ViewModel.Month, Converter={StaticResource Converter1}}"/>

<TextBlock Grid.Column="0" 
  Text="{Binding Month, Converter={StaticResource Converter1}}"/>
```

バインドの [**Converter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converter) パラメーターを定義した場合、[**Convert**](https://msdn.microsoft.com/library/windows/apps/hh701934) メソッドと [**ConvertBack**](https://msdn.microsoft.com/library/windows/apps/hh701938) メソッドがバインド エンジンによって呼び出されます。 ソースからデータが渡されると、バインド エンジンは、**Convert** を呼び出し、返すデータをターゲットに渡します。 ターゲットからデータが渡されると (双方向バインディングの場合)、バインド エンジンは、**ConvertBack** を呼び出し、返すデータをソースに渡します。

コンバーターには省略可能なパラメーターもあります。変換で使う言語を指定できる [**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterlanguage)、および変換ロジックに渡すパラメーターを指定できる [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.binding.converterparameter) です。 コンバーター パラメーターの使用例については、「[**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/BR209903)」をご覧ください。

> [!Note]
> 変換でエラーがある場合は、例外をスローしません。 代わりに [**DependencyProperty.UnsetValue**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyproperty.unsetvalue) を返します。これにより、データ転送が中止されます。

バインディング ソースを解決できない場合に使用する既定値を表示するには、マークアップのバインディング オブジェクトで **FallbackValue** プロパティを設定します。 これは、変換エラーや書式エラーを処理する場合に便利です。 また、バインド時にソースのプロパティが、型が混在するバインド先のコレクションのどのオブジェクトにも見つからないときにも便利です。

テキスト コントロールを文字列でない値にバインドした場合、データ バインディング エンジンは値を文字列に変換します。 値が参照型である場合、データ バインディング エンジンは [**ICustomPropertyProvider.GetStringRepresentation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.icustompropertyprovider.getstringrepresentation) または [**IStringable.ToString**](https://msdn.microsoft.com/library/Dn302136) を呼び出すことで文字列の値を取得します。取得できない場合は、[**Object.ToString**](https://msdn.microsoft.com/library/windows/apps/system.object.tostring.aspx) を呼び出します。 ただし、データ バインディング エンジンは基底クラスの実装を隠ぺいする **ToString** の実装を無視することに注意してください。 代わりに、サブクラスの実装で基底クラスの **ToString** メソッドをオーバーライドする必要があります。 同様に、ネイティブ言語では、すべてのマネージ オブジェクトが [**ICustomPropertyProvider**](https://msdn.microsoft.com/library/windows/apps/BR209878) と [**IStringable**](https://msdn.microsoft.com/library/Dn302135) を実装しているように見えます。 ただし、**GetStringRepresentation** と **IStringable.ToString** のすべての呼び出しは、**Object.ToString** またはそのオーバーライドされたメソッドに割り振られます。基底クラスの実装を隠ぺいする新しい **ToString** メソッドの実装に割り振られることはありません。

> [!NOTE]
> Windows 10、バージョン1607 以降では、XAML フレームワークにブール値と Visibility 値のコンバーターが組み込まれています。 コンバーターは、**Visible** 列挙値に対して **true** を、**Collapsed** に対して **false** をマッピングします。これにより、コンバーターを作成せずに Visibility プロパティをブール値にバインドできます。 組み込みのコンバーターを使用するには、アプリの最小のターゲット SDK バージョンが 14393 以降である必要があります。 アプリがそれよりも前のバージョンの Windows 10 をターゲットとしている場合は使うことができません。 ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。

## <a name="function-binding-in-xbind"></a>{X:Bind} の関数バインド

{x:Bind} は関数となるバインディング パスの最終ステップを有効化します。 これを使って変換を実行できます。また 1 つ以上のプロパティに依存するバインディングを実行できます。 [ **X:bind で関数**を参照してください。](function-bindings.md)

<span id="resource-dictionaries-with-x-bind"/>

## <a name="resource-dictionaries-with-xbind"></a>リソース ディクショナリと {x:Bind}

[{x:Bind} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt204783)はコードの生成に依存するため、**InitializeComponent** (生成されたコードを初期化する) を呼び出すコンストラクターを含むコード ビハインド ファイルが必要です。 ファイル名を参照する代わりに、その型をインスタンス化する (**InitializeComponent** が呼び出される) ことによって、リソース ファイルを再利用します。 次の例では、既存のリソース ディクショナリがあり、その中で {x:Bind} を使う場合の対処方法を示します。

TemplatesResourceDictionary.xaml

```xaml
<ResourceDictionary
    x:Class="ExampleNamespace.TemplatesResourceDictionary"
    .....
    xmlns:examplenamespace="using:ExampleNamespace">
    
    <DataTemplate x:Key="EmployeeTemplate" x:DataType="examplenamespace:IEmployee">
        <Grid>
            <TextBlock Text="{x:Bind Name}"/>
        </Grid>
    </DataTemplate>
</ResourceDictionary>
```

TemplatesResourceDictionary.xaml.cs

```csharp
using Windows.UI.Xaml.Data;
 
namespace ExampleNamespace
{
    public partial class TemplatesResourceDictionary
    {
        public TemplatesResourceDictionary()
        {
            InitializeComponent();
        }
    }
}
```

MainPage.xaml

```xaml
<Page x:Class="ExampleNamespace.MainPage"
    ....
    xmlns:examplenamespace="using:ExampleNamespace">

    <Page.Resources>
        <ResourceDictionary>
            .... 
            <ResourceDictionary.MergedDictionaries>
                <examplenamespace:TemplatesResourceDictionary/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Page.Resources>
</Page>
```

## <a name="event-binding-and-icommand"></a>イベント バインディングと ICommand

[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) はイベント バインディングと呼ばれる機能をサポートしています。 この機能によって、バインディングを使用するイベントのハンドラーを指定できます。これは、コード ビハインド ファイルのメソッドによるイベント処理に対する追加のオプションです。 たとえば、**MainPage** クラスに **RootFrame** プロパティがあるとします。

```csharp
    public sealed partial class MainPage : Page
    {
        ....    
        public Frame RootFrame { get { return Window.Current.Content as Frame; } }
    }
```

次のように、**RootFrame** プロパティによって返される **Frame** オブジェクトのメソッドに、ボタンの **Click** イベントをバインドできます。 また、ボタンの **IsEnabled** プロパティを、同じ **Frame** の別のメンバーにもバインドします。

```xaml
    <AppBarButton Icon="Forward" IsCompact="True"
    IsEnabled="{x:Bind RootFrame.CanGoForward, Mode=OneWay}"
    Click="{x:Bind RootFrame.GoForward}"/>
```

この方法では、オーバーロードされたメソッドを使ってイベントを処理することはできません。 また、イベントを処理するメソッドにパラメーターがある場合、すべてのパラメーターがそれぞれ、イベントのすべての型から代入できる必要があります。 この場合、[**Frame.GoForward**](https://msdn.microsoft.com/library/windows/apps/BR242693) はオーバーロードされておらず、パラメーターはありません (ただし、2 つの **object** パラメーターを取る場合でも有効です)。 一方、[**Frame.GoBack**](https://msdn.microsoft.com/library/windows/apps/Dn996568) はオーバーロードされているため、この手法でそのメソッドを使うことはできません。

イベント バインディングの手法は、コマンドの実装と使用に似ています (コマンドは [**ICommand**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.icommand.aspx) インターフェイスを実装するオブジェクトを返すプロパティです)。 [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) と [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) はいずれもコマンドで動作します。 コマンド パターンを何度も実装する必要はありません。[QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame) サンプル (Common フォルダー) に含まれている **DelegateCommand** ヘルパー クラスを使うことができます。


## <a name="binding-to-a-collection-of-folders-or-files"></a>フォルダーやファイルのコレクションへのバインド

[**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/BR227346) 名前空間の API を使って、フォルダーとファイルのデータを取得できます。 ただし、**GetFilesAsync** メソッド、**GetFoldersAsync** メソッド、**GetItemsAsync** メソッドは、リスト コントロールへのバインドに適した値を返さないことがあります。 代わりに、[**FileInformationFactory**](https://msdn.microsoft.com/library/windows/apps/BR207501) クラスの [**GetVirtualizedFilesVector**](https://msdn.microsoft.com/library/windows/apps/Hh701422) メソッド、[**GetVirtualizedFoldersVector**](https://msdn.microsoft.com/library/windows/apps/Hh701428) メソッド、[**GetVirtualizedItemsVector**](https://msdn.microsoft.com/library/windows/apps/Hh701430) メソッドの戻り値にバインドする必要があります。 [StorageDataSource と GetVirtualizedFilesVector のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=228621)から抜粋した次のコード例は、一般的な使用パターンを示しています。 アプリ パッケージ マニフェストで **picturesLibrary** 機能を宣言し、ピクチャ ライブラリ フォルダーにピクチャがあることを確認します。

```csharp
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var library = Windows.Storage.KnownFolders.PicturesLibrary;
            var queryOptions = new Windows.Storage.Search.QueryOptions();
            queryOptions.FolderDepth = Windows.Storage.Search.FolderDepth.Deep;
            queryOptions.IndexerOption = Windows.Storage.Search.IndexerOption.UseIndexerWhenAvailable;

            var fileQuery = library.CreateFileQueryWithOptions(queryOptions);

            var fif = new Windows.Storage.BulkAccess.FileInformationFactory(
                fileQuery,
                Windows.Storage.FileProperties.ThumbnailMode.PicturesView,
                190,
                Windows.Storage.FileProperties.ThumbnailOptions.UseCurrentScale,
                false
                );

            var dataSource = fif.GetVirtualizedFilesVector();
            this.PicturesListView.ItemsSource = dataSource;
        }
```

通常はこの方法で、ファイルとフォルダーの情報の読み取り専用ビューを作成します。 たとえば、ユーザーが音楽ビューで曲を評価できるように、ファイルとフォルダーのプロパティへの双方向のバインドを作成できます。 ただし、適切な **SavePropertiesAsync** メソッド ([**MusicProperties.SavePropertiesAsync**](https://msdn.microsoft.com/library/windows/apps/BR207760) など) を呼び出すまで、変更は永続化されません。 項目からフォーカスが移動したときに選択のリセットがトリガーされるため、変更をコミットする必要があります。

この方法による双方向のバインドは、ミュージックなど、インデックス化された場所でのみ機能します。 ある場所がインデックス化されているかどうかを確認するには、[**FolderInformation.GetIndexedStateAsync**](https://msdn.microsoft.com/library/windows/apps/BR207627) メソッドを呼び出します。

仮想化されたベクターは、一部の項目に対して、値の設定の前に **null** を返す場合があることにも注意してください。 たとえば、仮想化されたベクターにバインドされたリスト コントロールの [**SelectedItem**](https://msdn.microsoft.com/library/windows/apps/BR209770) 値を使う前に、**null** をチェックする必要があります。または、代わりに [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/BR209768) を使います。

## <a name="binding-to-data-grouped-by-a-key"></a>キーでグループ化されたデータへのバインド

フラットな項目のコレクション (たとえば、**BookSku** クラスで表される書籍) があり、共通のプロパティ (たとえば、**BookSku.AuthorName**) をキーとして使って項目をグループ化する場合、結果はグループ化されたデータと呼ばれます。 データをグループ化すると、フラットなコレクションではなくなります。 グループ化されたデータはグループ オブジェクトのコレクションであり、各グループ オブジェクトには a) キーと b) プロパティがキーと一致する項目のコレクションがあります。 再び書籍の例で説明すると、書籍を著者名でグループ化した結果は、著者名グループのコレクションになります。各グループには、a) キーとしての著者名と、b) **AuthorName** プロパティがグループのキーに一致する **BookSku** のコレクションが含まれます。

一般的に、コレクションを表示するには、項目コントロール [**ItemsSource**](https://msdn.microsoft.com/library/windows/apps/BR242828) ([**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) や [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) など) を、コレクションを返すプロパティに直接バインドします。 項目のフラットなコレクションの場合は、何も特別なことをする必要はありません。 一方、グループ オブジェクトのコレクションの場合 (グループ化されたデータにバインドしている場合など) は、項目コントロールとバインディング ソースの間に存在する、[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) と呼ばれる中間オブジェクトのサービスが必要です。 グループ化されたデータを返すプロパティに **CollectionViewSource** をバインドし、項目コントロールを **CollectionViewSource** にバンドします。 **CollectionViewSource** の追加の付加価値として現在の項目を追跡できるため、複数の項目コントロールをすべて同じ **CollectionViewSource** にバインドすることによって同期させることができます。 [**CollectionViewSource.View**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.view) プロパティによって返されるオブジェクトの [**ICollectionView.CurrentItem**](https://msdn.microsoft.com/library/windows/apps/BR209857) プロパティによって、現在の項目にプログラムでアクセスすることもできます。

[**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) のグループ化機能をアクティブにするには、[**IsSourceGrouped**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.issourcegrouped) を **true** に設定します。 [**ItemsPath**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.data.collectionviewsource.itemspath) プロパティも設定する必要があるかどうかは、グループ オブジェクトを作成する方法に依存します。 グループ オブジェクトを作成するには、"グループである" パターンと "グループを保持する" パターンの 2 つの方法があります。 "グループである" パターンでは、グループ オブジェクトはコレクション型から派生 (たとえば、**List&lt;T&gt;**) から派生するため、グループ オブジェクトは実際にそれ自体が項目のグループです。 このパターンでは、**ItemsPath** を設定する必要はありません。 "グループを保持する" パターンでは、グループ オブジェクトはコレクション型 (**List&lt;T&gt;** など) の 1 つまたは複数のプロパティを持つため、グループは、プロパティの形式で項目のグループ (または複数のプロパティの形式で項目の複数のグループ) を "保持" します。 このパターンでは、**ItemsPath** を、項目のグループを含むプロパティの名前に設定する必要があります。

次の例は、"グループを保持する" パターンを示しています。 ページ クラスには [**ViewModel**](https://msdn.microsoft.com/library/windows/apps/BR208713) という名前のプロパティがあります。このプロパティはビュー モデルのインスタンスを返します。 [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) はビュー モデルの **Authors** プロパティにバインドされ (**Authors** はグループ オブジェクトのコレクション)、それがグループ化された項目を格納する **Author.BookSkus** プロパティであることも指定します。 最後に、[**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) は **CollectionViewSource** にバインドされ、グループ内の項目をレンダリングできるようにグループのスタイルが定義されています。

```csharp
    <Page.Resources>
        <CollectionViewSource
        x:Name="AuthorHasACollectionOfBookSku"
        Source="{x:Bind ViewModel.Authors}"
        IsSourceGrouped="true"
        ItemsPath="BookSkus"/>
    </Page.Resources>
    ...

    <GridView
    ItemsSource="{x:Bind AuthorHasACollectionOfBookSku}" ...>
        <GridView.GroupStyle>
            <GroupStyle
                HeaderTemplate="{StaticResource AuthorGroupHeaderTemplateWide}" ... />
        </GridView.GroupStyle>
    </GridView>
```

"グループである" パターンは、2 つの方法のいずれかで実装できます。 1 つは、独自のグループ クラスを作成する方法です。 **List&lt;T&gt;** からクラスを派生させます (ここで *T* は項目の型です)。 たとえば、`public class Author : List<BookSku>` と記述します。 もう 1 つは、**BookSku** 項目の同様のプロパティ値から、動的にグループ オブジェクト (とグループ クラス) を動的に作成する [LINQ](http://msdn.microsoft.com/library/bb397926.aspx) 式を使う方法です。 このアプローチ (項目のフラットな一覧のみを保持し、必要に応じてグループ化する) は、クラウド サービスのデータにアクセスするアプリで一般的です。 著者やジャンルなどに基づいて書籍を柔軟にグループ化することができます。**Author** や **Genre** などの特別なグループ クラスは必要ありません。

次の例は、[LINQ](http://msdn.microsoft.com/library/bb397926.aspx) を使用した "グループである" パターンを示しています。 今回は、書籍をジャンルでグループ化し、グループ ヘッダーにジャンル名と共に表示します。 これは、グループの [**Key**](https://msdn.microsoft.com/library/windows/apps/bb343251.aspx) の値に関連する "Key" プロパティ パスによって示されます。

```csharp
    using System.Linq;

    ...

    private IOrderedEnumerable<IGrouping<string, BookSku>> genres;

    public IOrderedEnumerable<IGrouping<string, BookSku>> Genres
    {
        get
        {
            if (this.genres == null)
            {
                this.genres = from book in this.bookSkus
                group book by book.genre into grp
                orderby grp.Key select grp;
            }
            return this.genres;
        }
    }
```

[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) をデータ テンプレートと共に使う場合、**x:DataType** 値を設定することによって、バインド先の型を指定する必要があることに注意してください。 型がジェネリックである場合、マークアップでは表現できないため、グループ スタイル ヘッダー テンプレート内で代わりに [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) を使う必要があります。

```xaml
    <Grid.Resources>
        <CollectionViewSource x:Name="GenreIsACollectionOfBookSku"
        Source="{x:Bind Genres}"
        IsSourceGrouped="true"/>
    </Grid.Resources>
    <GridView ItemsSource="{x:Bind GenreIsACollectionOfBookSku}">
        <GridView.ItemTemplate x:DataType="local:BookTemplate">
            <DataTemplate>
                <TextBlock Text="{x:Bind Title}"/>
            </DataTemplate>
        </GridView.ItemTemplate>
        <GridView.GroupStyle>
            <GroupStyle>
                <GroupStyle.HeaderTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Key}"/>
                    </DataTemplate>
                </GroupStyle.HeaderTemplate>
            </GroupStyle>
        </GridView.GroupStyle>
    </GridView>
```

[**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/Hh702601) コントロールは、ユーザーがグループ化されたデータを表示したり、データ間を移動したりするための優れた方法です。 [Bookstore2](http://go.microsoft.com/fwlink/?linkid=532952) サンプル アプリは、**SemanticZoom** の使い方を示しています。 このアプリでは、著者別にグループ化された書籍の一覧を表示する (拡大表示ビュー) ことも、縮小して著者のジャンプ リストを表示する (縮小表示ビュー) こともできます。 ジャンプ リストを使うと、書籍の一覧をスクロールするよりもすばやく移動することができます。 拡大表示ビューと縮小表示ビューは、実際には、同じ **CollectionViewSource** にバインドされた **ListView** または **GridView** コントロールです。

![SemanticZoom の図](images/sezo.png)

階層データ (カテゴリ内のサブカテゴリなど) にバインドする場合、一連の項目コントロールを使って、UI に階層レベルを表示できます。 1 つの項目コントロールで項目を選ぶと、後続する項目コントロールの内容に反映されます。 各リストをそれぞれの [**CollectionViewSource**](https://msdn.microsoft.com/library/windows/apps/BR209833) インスタンスにバインドし、**CollectionViewSource** インスタンスをチェーン形式でバインドすることで、これらのリストの同期を保つことができます。 これは、マスター/詳細 (またはリスト/詳細) ビューと呼ばれます。 詳しくは、「[階層データにバインドし、マスター/詳細ビューを作る方法](how-to-bind-to-hierarchical-data-and-create-a-master-details-view.md)」をご覧ください。

<span id="debugging"/>

## <a name="diagnosing-and-debugging-data-binding-problems"></a>データ バインディングに関する問題の診断とデバッグ

バインド マークアップには、プロパティ (と、C# では場合によってフィールドとメソッド) の名前が含まれています。 したがって、プロパティの名前を変更するときに、それを参照するすべてのバインディングを変更する必要があります。 この処理を忘れることは、データ バインディングのバグの一般的な例であり、アプリは正しくコンパイルまたは実行されません。

[{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) と [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) によって作成されたバインディング オブジェクトは、ほとんど機能的に同等です。 ただし、{x:Bind} にはバインディング ソースの型情報が含まれ、コンパイル時にソース コードが生成されます。 {x:Bind} を使うと、コードの残りの部分で取得できるものと同じ種類の問題の検出を行うことができます。 これには、コンパイル時のバインド式の検証や、ページの部分クラスとして生成されたソース コード内でのブレークポイント設定によるデバッグが含まれます。 これらのクラスは `obj` フォルダー内のファイルにあり、`<view name>.g.cs` (C# の場合) などの名前が付けられています。 バインディングに問題がある場合は、Microsoft Visual Studio デバッガーで、**[処理されない例外で中断]** をオンにします。 デバッガーはその時点での実行を中断し、問題のある点をデバッグすることができます。 {x:Bind} によって生成されたコードは、バインディング ソース ノードのグラフの各部分で同じパターンに従うため、この情報を **[コール スタック]** ウィンドウで使って、問題の原因となった呼び出しのシーケンスを特定できます。

[{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) には、バインディング ソースの型情報はありません。 ただし、デバッガーがアタッチされたアプリを実行すると、バインド エラーがある場合は Visual Studio の **[出力]** ウィンドウにそのエラーが表示されます。

## <a name="creating-bindings-in-code"></a>コードでのバインドの作成

**注**  このセクションは [{Binding}](https://msdn.microsoft.com/library/windows/apps/Mt204782) にのみ適用されます。コードで [{x:Bind}](https://msdn.microsoft.com/library/windows/apps/Mt204783) バインディングを作成することはできないためです。 ただし、{x:Bind} と同じメリットを、[**DependencyObject.RegisterPropertyChangedCallback**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobject.registerpropertychangedcallback.aspx) によって実現できます。これにより、すべての依存関係プロパティについての変更通知を登録できます。

XAML の代わりに手続き型コードを使っても UI 要素をデータに接続できます。 そのためには、新しい [**Binding**](https://msdn.microsoft.com/library/windows/apps/BR209820) オブジェクトを作成し、適切なプロパティを設定してから、[**FrameworkElement.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257.aspx) または [**BindingOperations.SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244376.aspx) を呼び出します。 バインドをプログラムで作成すると、Binding プロパティの値を実行時に選択する場合や、複数のコントロール間で 1 つのバインドを共有する場合に便利です。 ただし、**SetBinding** の呼び出し後は Binding プロパティの値を変更できないことに注意してください。

次の例では、バインドをコードで実装する方法を示しています。

```xaml
<TextBox x:Name="MyTextBox" Text="Text"/>
```

```csharp
// Create an instance of the MyColors class 
// that implements INotifyPropertyChanged.
MyColors textcolor = new MyColors();

// Brush1 is set to be a SolidColorBrush with the value Red.
textcolor.Brush1 = new SolidColorBrush(Colors.Red);

// Set the DataContext of the TextBox MyTextBox.
MyTextBox.DataContext = textcolor;

// Create the binding and associate it with the text box.
Binding binding = new Binding() { Path = new PropertyPath("Brush1") };
MyTextBox.SetBinding(TextBox.ForegroundProperty, binding);
```

```vbnet
' Create an instance of the MyColors class 
' that implements INotifyPropertyChanged. 
Dim textcolor As New MyColors()

' Brush1 is set to be a SolidColorBrush with the value Red. 
textcolor.Brush1 = New SolidColorBrush(Colors.Red)

' Set the DataContext of the TextBox MyTextBox. 
MyTextBox.DataContext = textcolor

' Create the binding and associate it with the text box.
Dim binding As New Binding() With {.Path = New PropertyPath("Brush1")}
MyTextBox.SetBinding(TextBox.ForegroundProperty, binding)
```

## <a name="xbind-and-binding-feature-comparison"></a>{x:Bind} と {Binding} の機能の比較

| 機能 | {x:Bind} | {Binding} | コメント |
|---------|----------|-----------|-------|
| Path が既定のプロパティである | `{x:Bind a.b.c}` | `{Binding a.b.c}` | | 
| Path プロパティ | `{x:Bind Path=a.b.c}` | `{Binding Path=a.b.c}` | x:Bind では、Path は既定で DataContext ではなく、Page をルートにします。 | 
| インデクサー | `{x:Bind Groups[2].Title}` | `{Binding Groups[2].Title}` | コレクション内で指定した項目にバインドします。 整数ベースのインデックスのみがサポートされます。 | 
| 添付プロパティ | `{x:Bind Button22.(Grid.Row)}` | `{Binding Button22.(Grid.Row)}` | 添付プロパティは、かっこを使って指定します。 プロパティが XAML 名前空間で宣言されていない場合は、そのプロパティの前に xml 名前空間を付けます。これはドキュメントの先頭でコード名前空間にマップする必要があります。 | 
| キャスト | `{x:Bind groups[0].(data:SampleDataGroup.Title)}` | 必要ありません。 | キャストはかっこを使って指定します。 プロパティが XAML 名前空間で宣言されていない場合は、そのプロパティの前に xml 名前空間を付けます。これはドキュメントの先頭でコード名前空間にマップする必要があります。 | 
| Converter | `{x:Bind IsShown, Converter={StaticResource BoolToVisibility}}` | `{Binding IsShown, Converter={StaticResource BoolToVisibility}}` | コンバーターは、Page/ResourceDictionary のルートまたは App.xaml で宣言する必要があります。 | 
| ConverterParameter、ConverterLanguage | `{x:Bind IsShown, Converter={StaticResource BoolToVisibility}, ConverterParameter=One, ConverterLanguage=fr-fr}` | `{Binding IsShown, Converter={StaticResource BoolToVisibility}, ConverterParameter=One, ConverterLanguage=fr-fr}` | コンバーターは、Page/ResourceDictionary のルートまたは App.xaml で宣言する必要があります。 | 
| TargetNullValue | `{x:Bind Name, TargetNullValue=0}` | `{Binding Name, TargetNullValue=0}` | バインド式のリーフが null の場合に使用されます。 文字列値の場合は単一引用符を使用します。 | 
| FallbackValue | `{x:Bind Name, FallbackValue='empty'}` | `{Binding Name, FallbackValue='empty'}` | バインディングのパスの一部 (リーフを除く) が null の場合に使用されます。 | 
| ElementName | `{x:Bind slider1.Value}` | `{Binding Value, ElementName=slider1}` | {x:Bind} によって、フィールドにバインドしています。Path は既定で Page をルートとするため、名前付きの要素はそのフィールドを使ってアクセスできます。 | 
| RelativeSource: Self | `<Rectangle x:Name="rect1" Width="200" Height="{x:Bind rect1.Width}" ... />` | `<Rectangle Width="200" Height="{Binding Width, RelativeSource={RelativeSource Self}}" ... />` | {x:Bind} では、要素に名前を付けて、Path でその名前を使います。 | 
| RelativeSource: TemplatedParent | 不要 | `{Binding <path>, RelativeSource={RelativeSource TemplatedParent}}` | {X:bind} TargetType ControlTemplate では、テンプレートの親へのバインドを示します。 {Binding} 標準のテンプレート バインディングほとんどのユーザー コントロール テンプレートで使用することができます。 ただし、コンバーターまたは双方向バインディングを使用する必要がある場合は TemplatedParent を使います。< | 
| Source | 不要 | `<ListView ItemsSource="{Binding Orders, Source={StaticResource MyData}}"/>` | {X:bind} の名前付きの要素を直接に使用できるプロパティまたは静的パスを使います。 | 
| Mode | `{x:Bind Name, Mode=OneWay}` | `{Binding Name, Mode=TwoWay}` | Mode には、OneTime、OneWay、TwoWay を指定できます。 {x:Bind} の既定値は OneTime で、{Binding} の既定値は OneWay です。 | 
| UpdateSourceTrigger | `{x:Bind Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}` | `{Binding UpdateSourceTrigger=PropertyChanged}` | UpdateSourceTrigger には、Default、LostFocus、PropertyChanged を指定できます。 {x:Bind} では、UpdateSourceTrigger=Explicit はサポートされません。 {x:Bind} では、TextBox.Text を除くすべての場合に PropertyChanged 動作を使います。TextBox.Text の場合は LostFocus 動作を使います。 | 


