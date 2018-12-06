---
description: このトピックでは、C++、C#、または Visual Basic と UI の XAML 定義を使って Windows ランタイム アプリを作成するときに使うことができる依存関係プロパティ システムについて説明します。
title: 依存関係プロパティの概要
ms.assetid: AD649E66-F71C-4DAA-9994-617C886FDA7E
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 92e8b0b0d68b1dc4110818977024d3040194a376
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8750733"
---
# <a name="dependency-properties-overview"></a>依存関係プロパティの概要

このトピックでは、C++、C#、または Visual Basic と UI の XAML 定義を使って Windows ランタイム アプリを作成するときに使うことができる依存関係プロパティ システムについて説明します。

## <a name="what-is-a-dependency-property"></a>依存関係プロパティとは

依存関係プロパティとは、特殊な種類のプロパティです。 具体的には、Windows ランタイムの一部である専用のプロパティ システムによってプロパティの値が追跡され影響を受けるプロパティです。

依存関係プロパティをサポートするには、そのプロパティを定義するオブジェクトが [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) (継承関係のどこかに **DependencyObject** 基底クラスを持つクラス) である必要があります。 多くの種類の XAML を使った UWP アプリの UI 定義を使用する**DependencyObject**サブクラスで、依存関係プロパティがサポートされます。 ただし、名前に "XAML" がない Windows ランタイム名前空間に由来する型は、依存関係プロパティをサポートしていません。このような型のプロパティは、プロパティ システムによる依存関係の動作をしない通常のプロパティです。

依存関係プロパティの目的は、他の入力 (その他のプロパティや、アプリの実行時にアプリ内で発生するイベントと状態) に基づいてプロパティの値を計算する方法を提供することです。 たとえば、他の入力には次のようなものがあります。

- ユーザー設定などの外部入力
- データ バインディング、アニメーション、ストーリーボードなどのジャスト イン タイム プロパティ判定機構
- リソースやスタイルなどの多目的テンプレート パターン
- オブジェクト ツリー内の他の要素との親子のリレーションシップから判断される値

または XAML を使った Windows ランタイム アプリの UI とは、c#、Microsoft Visual Basic または VisualC ではコンポーネント拡張機能を定義するため、プログラミング モデルの特定の機能をサポートしている依存関係プロパティを表します (、C++/cli CX) コード。 次のような機能があります。

- データ バインディング
- スタイル
- ストーリーボードに設定されたアニメーション
- "PropertyChanged" の動作 (依存関係プロパティを実装して、他の依存関係プロパティに対する変更を反映できるコールバックを提供する)
- プロパティ メタデータに由来する既定値の使用
- 一般的なプロパティ システム ユーティリティ ([**ClearValue**](https://msdn.microsoft.com/library/windows/apps/br242357)、メタデータ参照など)

## <a name="dependency-properties-and-windows-runtime-properties"></a>依存関係プロパティと Windows ランタイム プロパティ

依存関係プロパティは、実行時にアプリのすべての依存関係プロパティをサポートするグローバルな内部プロパティ ストアを提供することによって、Windows ランタイム プロパティの基本機能を拡張します。 これは、プロパティ定義クラスでプライベート フィールドのあるプロパティをサポートする標準的なパターンの代わりとなるものです。 この内部プロパティ ストアは、特定のオブジェクトのために存在する一連のプロパティ識別子とプロパティ値であると考えてかまいません (それが [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) である限り)。 ストア内の各プロパティは、名前ではなく、[**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) インスタンスで識別されます。 ただし、プロパティ システムによってこの実装の詳細はほとんどが隠されます。通常は、依存関係プロパティに単純な名前 (使っているコード言語のプログラム可能なプロパティ名、または、XAML を作成しているときは属性名) を使ってアクセスできます。

依存関係プロパティ システムの土台となる基本型は [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) です。 **DependencyObject** では、依存関係プロパティにアクセスできるメソッドを定義します。先に述べたプロパティ ストアという概念を内部的にサポートするのは **DependencyObject** 派生クラスのインスタンスです。

依存関係プロパティについて説明するときにこのドキュメントで使用する用語の概要を次に示します。

| 用語 | 説明 |
|------|-------------|
| 依存関係プロパティ | [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) 識別子上に存在するプロパティ (下記参照)。 この識別子は通常、定義する **DependencyObject** 派生クラスの静的メンバーとして使用できます。 |
| 依存関係プロパティ識別子 | プロパティを識別する定数値です。通常はパブリックで、読み取り専用です。 |
| プロパティ ラッパー | Windows ランタイム プロパティの呼び出し可能な **get** 実装と **set** 実装。 または、元の定義の言語固有のプロジェクション。  **get** プロパティ ラッパーの実装は [**GetValue**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobject.getvalue.aspx) を呼び出して、該当する依存関係プロパティの識別子を渡します。 |

プロパティ ラッパーは呼び出し元に対して便利なだけではありません。プロパティの Windows ランタイム定義を使用するプロセス、ツール、プロジェクションに対する依存関係プロパティの公開も行います。

次の例では、C# のカスタム "IsSpinning" 依存関係プロパティを定義し、依存関係プロパティの識別子とプロパティ ラッパーの関係を示します。

```csharp
// IsSpinningProperty is the dependency property identifier
// no need for info in the last PropertyMetadata parameter, so we pass null
public static readonly DependencyProperty IsSpinningProperty =
    DependencyProperty.Register(
        "IsSpinning", typeof(Boolean),
        typeof(ExampleClass), null
    );
// The property wrapper, so that callers can use this property through a simple ExampleClassInstance.IsSpinning usage rather than requiring property system APIs
public bool IsSpinning
{
    get { return (bool)GetValue(IsSpinningProperty); }
    set { SetValue(IsSpinningProperty, value); }
}
```

> [!NOTE]
> 上記の例は、カスタム依存関係プロパティを作成する方法の完全な例としてはありません。 コードを使って概念を学習する方法によって、依存関係プロパティの概念を示すことです。 もっと完全な例については、「[カスタム依存関係プロパティ](custom-dependency-properties.md)」をご覧ください。

## <a name="dependency-property-value-precedence"></a>依存関係プロパティ値の優先順位

依存関係プロパティの値を取得する場合、Windows ランタイムのプロパティ システムに関係する入力のいずれかを介して、そのプロパティで決定された値を取得することになります。 依存関係プロパティの値には優先順位が存在するため、Windows ランタイムのプロパティ システムは予測可能な方法で値を計算できます。基本的な優先順位の順序に関する知識は、ユーザーにとっても重要です。 知識がない場合、あるレベルの優先順位でプロパティを設定しようとしたのに、何か別のもの (システム、サードパーティの呼び出し元、自分のコード) がそれを別のレベルで設定したために、どのプロパティ値が使われ、その値がどこからきているかがわからなくていらいらするという状況になることもありえます。

たとえば、スタイルとテンプレートは、プロパティ値 (コントロールの外観) を設定するための共有の開始点として設計されています。 ただし、特定のコントロール インスタンスでは、そのコントロールの背景色を変えたり、コンテンツとして異なるテキスト文字列を使用したりするなど、その値を共通のテンプレート値から変更する場合があります。 Windows ランタイムのプロパティ システムでは、スタイルおよびテンプレートで指定される値より高い優先順位をローカル値で使います。 こうすることで、アプリ固有の値でテンプレートを上書きして、アプリの UI でコントロールを独自の使い方で便利に利用することができます。

### <a name="dependency-property-precedence-list"></a>依存関係プロパティの優先順位リスト

依存関係プロパティのランタイム値を割り当てる際に、最終的にプロパティ システムで使用される順序を次に示します。 優先順位の高いものから順に示します。 このリストの直後に、詳しい説明があります。

1. **アニメーション化された値:** アクティブなアニメーション、表示状態のアニメーション、または [**HoldEnd**](https://msdn.microsoft.com/library/windows/apps/br210306) 動作を使ったアニメーションです。 実際的な効果を持たせるためには、プロパティに適用されるアニメーションは、値がローカルに設定されている場合でも、その基本値 (アニメーション化されていない値) よりも優先される必要があります。
1. **ローカル値:** ローカル値の場合は、プロパティ ラッパーを利用した簡便な設定方法が利用できます (XAML で属性またはプロパティ要素として設定することに相当)。また、特定のインスタンスのプロパティを使用して [**SetValue**](https://msdn.microsoft.com/library/windows/apps/br242361) メソッドを呼び出すことによって設定することもできます。 バインドまたは静的リソースを使用してローカル値を設定すると、優先順位に関してはローカル値を設定した場合と同じように扱われます。新しいローカル値が設定されると、バインドやリソース参照は削除されます。
1. **テンプレートが適用されたプロパティ:** [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) または [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/br242348) からテンプレートの一部として作成された要素は、このプロパティを持ちます。
1. **スタイル setter:** ページ リソースまたはアプリケーション リソースから得たスタイル内にある [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) から得た値。
1. **既定値:** 依存関係プロパティには、プロパティ メタデータの一部として既定値を定義できます。

### <a name="templated-properties"></a>テンプレートが適用されたプロパティ

優先順位項目としてのテンプレートが適用されたプロパティは、XAML ページ マークアップで直接宣言した要素のプロパティには適用されません。 テンプレートが適用されたプロパティという概念は、Windows ランタイムが UI 要素に XAML テンプレートを適用して視覚効果を定義するときに作成されるオブジェクトのためだけに存在します。

コントロール テンプレートから設定されているすべてのプロパティになんらかの値があります。 これらの値は、ほぼコントロールの既定値を拡張したものであり、多くの場合、プロパティ値を直接設定することで、後でリセットできる値に関連付けられています。 そのため、テンプレートで設定された値は、新しいローカル値で上書きできるように、本当のローカル値とは区別できる必要があります。

> [!NOTE]
> 場合によっては、テンプレートがローカル値より優先されることもあります。それは、インスタンスに対して設定可能なプロパティの [{TemplateBinding} マークアップ拡張](templatebinding-markup-extension.md) 参照をテンプレートが公開しなかった場合です。 これは、通常、プロパティが実際にインスタンスで設定されないことを意図している場合にのみ行われます。たとえば、プロパティが視覚効果とテンプレートの動作だけに関係し、テンプレートを使うコントロールの目的の機能または実行時ロジックとは関係していない場合などです。

### <a name="bindings-and-precedence"></a>バインドと優先順位

バインド操作には、目的のスコープが何であれ、適切な優先順位があります。 たとえば、ローカル値に適用される [{Binding}](binding-markup-extension.md) はローカル値として機能し、プロパティ setter の [{TemplateBinding} マークアップ拡張](templatebinding-markup-extension.md)はスタイル setter の場合と同じように適用されます。 バインドは、データ ソースから値を取得するのを実行時まで待つ必要があります。このため、任意のプロパティに対してプロパティ値の優先順位を決定するプロセスも、実行時まで拡張されます。

バインドはローカル値と同じ優先順位で動作するだけでなく、実際はローカル値です。この場合、バインドは、遅延された値のプレースホルダーです。 プロパティ値にバインドを指定し、実行時にプロパティにローカル値を設定した場合、このローカル値でバインド全体が置き換えられます。 同様に、[**SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257) を呼び出して、実行時にのみ存在するバインドを定義すると、XAML で、または以前に実行したコードで適用したローカル値が置き換えられます。

### <a name="storyboarded-animations-and-base-value"></a>ストーリーボードに設定されたアニメーションと基本値

ストーリボードに設定されたアニメーションは、*基本値*という概念に基づいて動作します。 基本値とは、優先順位を使ってプロパティ システムによって決定される値ですが、アニメーションを探すという最後の手順が省略されています。 たとえば、基本値は、コントロールのテンプレートに由来する場合も、コントロールのインスタンスに設定したローカル値に由来する場合もあります。 どちらの場合も、アニメーションを適用すると、この基本値が上書きされ、アニメーションが動作し続ける限り、アニメーション化された値が適用されます。

アニメーション化されたプロパティでは、そのアニメーションが **From** と **To** の両方を明示的に指定していない場合、またはアニメーションが完了するとプロパティが基本値に戻る場合に、基本値は依然としてアニメーションの動作に影響を与えます。 このような場合、アニメーションが実行されなくなると、優先順位の残りの部分が再び使用されます。

ただし、[**HoldEnd**](https://msdn.microsoft.com/library/windows/apps/br210306) 動作と共に **To** を指定したアニメーションは、停止しているように見えていても、アニメーションが削除されるまでローカル値をオーバーライドできます。 これは概念的には、UI に視覚的なアニメーションが存在しない場合でも、永遠に実行されるアニメーションのようなものです。

1 つのプロパティに複数のアニメーションを適用できます。 このアニメーションそれぞれが、値の優先順位の異なる場所に由来する基本値を置き換えるように定義されている場合が考えられます。 ただし、これらのアニメーションは、実行時にすべて同時に実行され、多くの場合、これは各アニメーションが値に対して与える影響が等しいため、値を結合する必要があることを意味します。 これは、アニメーションが実際にどのように定義されているか、およびアニメーション化される値の型によって異なります。

詳しくは、「[ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/mt187354)」をご覧ください。

### <a name="default-values"></a>既定値

[**PropertyMetadata**](https://msdn.microsoft.com/library/windows/apps/br208771) 値を持つ依存関係プロパティの既定値の設定については、「[カスタム依存関係プロパティ](custom-dependency-properties.md)」で詳しく説明しています。

依存関係プロパティは、その既定値がプロパティのメタデータで明示的に定義されていない場合でも、既定値を持ちます。 メタデータによって変更されていない限り、Windows ランタイムの依存関係プロパティの既定値は、通常、次のいずれかです。

- 実行時オブジェクトまたは基本的な **Object** 型 (*参照型*) を使うプロパティには、**null** という既定値があります。 たとえば、[**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) は、意図的に設定されるか継承されるまで、**null** です。
- 数値やブール値 (*値型*) のような基本的な値を使うプロパティでは、その値に期待される既定値が使われます。 たとえば、整数と浮動小数点数の場合は 0、ブール値の場合は **false** です。
- Windows ランタイムの構造体を使うプロパティには、その構造体の暗黙の既定のコンストラクターを呼び出して取得される既定値があります。 このコンストラクターは、構造体の基本的な値フィールドごとの既定値を使います。 たとえば、[**Point**](https://msdn.microsoft.com/library/windows/apps/br225870) の既定値は、**X** と **Y** の値が 0 として初期化されます。
- 列挙型を使うプロパティには、その列挙型で定義されている最初のメンバーの既定値があります。 既定値を確認するには、特定の列挙型のリファレンスをご覧ください。
- 文字列 (.NET では [**System.String**](https://msdn.microsoft.com/library/windows/apps/xaml/system.string.aspx)、C++/CX では [**Platform::String**](https://msdn.microsoft.com/library/windows/apps/xaml/hh755812.aspx)) を使うプロパティには、空の文字列 (**""**) という既定値があります。
- コレクション プロパティは、このトピックで詳しく説明する理由から、一般に依存関係プロパティとして実装されます。 ただし、カスタム コレクション プロパティを実装して、それを依存関係プロパティにする場合は、「[カスタム依存関係プロパティ](custom-dependency-properties.md)」の最後のあたりで説明されているように、*意図しないシングルトン*にならないよう注意します。

## <a name="property-functionality-provided-by-a-dependency-property"></a>依存関係プロパティによって提供されるプロパティ機能

### <a name="data-binding"></a>データ バインディング

依存関係プロパティには、データ バインディングを適用して値を設定することができます。 データ バインディングは、XAML では [{Binding} マークアップ拡張](binding-markup-extension.md) 構文、コードでは [{x:Bind} マークアップ拡張](x-bind-markup-extension.md)または [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) クラスを使います。 データ バインディング プロパティの場合、最終的なプロパティ値の決定は実行時まで遅延されます。 その時点で、データ ソースから値が取得されます。 依存関係プロパティ システムがここで果たす役割は、値がまだ未知のときに XAML を読み込むような操作のプレースホルダー動作を可能にし、次に、Windows ランタイム データ バインディング エンジンとやり取りして実行時に値を供給することです。

XAML でバインドを使用して、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) 要素の [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) 値を設定する例を次に示します。 バインドでは、継承されたデータ コンテキストおよびオブジェクト データ ソースが使用されます (この短い例ではどちらも示されていません。コンテキストとソースを含むより完全なサンプルについては、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください)。

```xaml
<Canvas>
  <TextBlock Text="{Binding Team.TeamName}"/>
</Canvas>
```

XAML ではなく、コードを使ってバインドを確立することもできます。 「[**SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257)」をご覧ください。

> [!NOTE]
> このようなバインドは、依存関係プロパティ値の優先順位の目的上のローカル値として扱われます。 もともと [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) 値を保持していたプロパティに別のローカル値を設定すると、バインドの実行時の値だけでなく、バインド全体が上書きされます。 {x:Bind} バインドは生成されたコードを使用して実装され、プロパティにローカル値を設定します。 {x:Bind} を使用しているプロパティにローカル値が設定されると、次にバインディングが評価されるときに、その値は置き換えられます。たとえば、ソース オブジェクトのプロパティが変更されるときなどです。

### <a name="binding-sources-binding-targets-the-role-of-frameworkelement"></a>バインディング ソース、バインディング ターゲット、FrameworkElement の役割

プロパティをバインディング ソースとして使う場合は、依存関係プロパティでなくてもかまいません。通常は、バインディング ソースとして任意のプロパティを使うことができます。もっとも、これはプログラミング言語に左右され、それぞれ特殊なケースが存在します。 ただし、プロパティを [{Binding} マークアップ拡張](binding-markup-extension.md)または [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) のターゲットとして使用する場合は、依存関係プロパティである必要があります。 {x:Bind} では、生成されたコードを使用してバインディング値を適用するため、この要件はありません。

コードでバインドを作成する場合、[**SetBinding**](https://msdn.microsoft.com/library/windows/apps/br244257) API は [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) に対してのみ定義されている点に注意してください。 ただし、バインド定義は [**BindingOperations**](https://msdn.microsoft.com/library/windows/apps/br209823) を使用して作成できるため、どのような [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) プロパティでも参照することができます。

コードであれ XAML であれ、[**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713) は [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) プロパティです。 親子プロパティの継承という形を使って (通常は XAML マークアップで確立)、バインディング システムは親要素に存在する **DataContext** を解決することができます。 この継承は、子オブジェクト (ターゲット プロパティを持つ) が **FrameworkElement** でなく、そのために独自の **DataContext** 値を保持していない場合でも、評価できます。 ただし、**DataContext** を設定し保持するためには、継承する親要素が **FrameworkElement** であることが必要です。 その一方で、**DataContext** が **null** 値であっても機能できるようにバインドを定義する必要があります。

ほとんどのデータ バインディング シナリオに必要なのは、バインドを作成することだけではありません。 一方向または双方向のバインドを有効にするためには、バインディング システム (とターゲット) への伝播をつかさどる変更通知が、ソース プロパティによってサポートされている必要があります。 カスタム バインディング ソースの場合には、プロパティは依存関係プロパティである必要があるか、またはオブジェクトが [ **INotifyPropertyChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.componentmodel.inotifypropertychanged.aspx) をサポートする必要があります。 コレクションの場合は、[**INotifyCollectionChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/system.collections.specialized.inotifycollectionchanged.aspx) をサポートしている必要があります。 一部のクラスは、データ バインディングのシナリオで基底クラスとして使用できるように、実装でこれらのインターフェイスをサポートしています。たとえば、[**ObservableCollection&lt;T&gt;**](https://msdn.microsoft.com/library/windows/apps/xaml/ms668604.aspx) はそうしたクラスの 1 つです。 データ バインディングについての詳しい情報と、データ バインディングをプロパティ システムに関連付ける方法については、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください。

> [!NOTE]
> 型は、ここではサポートを一覧表示されている Microsoft .NET データ ソース。 C++/CX データ ソースは、変更通知または監視可能な動作のために異なるインターフェイスを使います。「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください。

### <a name="styles-and-templates"></a>スタイルとテンプレート

スタイルとテンプレートは、依存関係プロパティとして定義されるプロパティに関する 2 つのシナリオです。 スタイルは、アプリの UI を定義するプロパティを設定する際に役立ちます。 スタイルは XAML のリソースとして定義されます。その方法は、[**Resources**](https://msdn.microsoft.com/library/windows/apps/br208740) コレクションのエントリとするか、テーマ リソース ディクショナリなど、別の XAML ファイル内で定義するかのいずれかです。 スタイルにはプロパティの setter が含まれるため、スタイルはプロパティ システムと対話します。 ここで最も重要なプロパティは、[**Control**](https://msdn.microsoft.com/library/windows/apps/br209390) の [**Control.Template**](https://msdn.microsoft.com/library/windows/apps/br209465) プロパティです。このプロパティは、**Control** のほとんどの表示形式と表示状態を定義します。 スタイルについての詳しい情報と、[**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) を定義し、setter を使う XAML の例については、「[クイック スタート: コントロールのスタイル](https://msdn.microsoft.com/library/windows/apps/mt210950)」をご覧ください。

スタイルやテンプレートの値は、バインドと同様に、遅延された値です。 これは、コントロールのユーザーがコントロールにテンプレートを適用し直したりスタイルを定義し直したりできるようにするためです。 そのため、スタイルのプロパティ setter は、通常のプロパティではなく、依存関係プロパティしか操作できません。

### <a name="storyboarded-animations"></a>ストーリーボードに設定されたアニメーション

ストーリーボードに設定されたアニメーションを使うと、依存関係プロパティの値をアニメーション化できます。 Windows ランタイムのストーリーボードに設定されたアニメーションは、単なる視覚的装飾ではありません。 アニメーションは、個々のプロパティの値またはコントロールのすべてのプロパティと視覚効果の値を設定でき、時間の経過と共にこれらの値を変えることができるステート マシンと考えると便利です。

アニメーション化するためには、アニメーションのターゲット プロパティは依存関係プロパティである必要があります。 また、そのターゲット プロパティの値の型は、既存の [**Timeline**](https://msdn.microsoft.com/library/windows/apps/br210517) から派生したアニメーション型のいずれかでサポートされている必要があります。 [**Color**](https://msdn.microsoft.com/library/windows/apps/hh673723)、[**Double**](https://msdn.microsoft.com/library/windows/apps/system.double.aspx)、および [**Point**](https://msdn.microsoft.com/library/windows/apps/br225870) は、補間またはキーフレームの技法を使ってアニメーション化できます。 その他の値の大半は、個別の **Object** キー フレームを使ってアニメーション化できます。

アニメーションが適用されて実行されると、アニメーション化された値は、それ以外の場合のプロパティの値 (ローカル値など) よりも高い優先順位で動作します。 アニメーションにはオプションの [**HoldEnd**](https://msdn.microsoft.com/library/windows/apps/br210306) 動作もあり、アニメーションが停止しているように見えていても、アニメーションをプロパティ値に適用できます。

このステート マシン原則は、コントロールの [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/br209021) 状態モデルの一部としてストーリーボードに設定されたアニメーションを使って実現されます。 ストーリーボードに設定されたアニメーションについて詳しくは、「[ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/mt187354)」をご覧ください。 **VisualStateManager** とコントロールの視覚的状態の定義について詳しくは、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/jj819808)」または「[コントロール テンプレート](../design/controls-and-patterns/control-templates.md)」をご覧ください。

### <a name="property-changed-behavior"></a>プロパティ変更動作

プロパティ変更動作は、依存関係プロパティという用語で "依存関係" という言葉の起源です。 他のプロパティの値によって影響を受ける可能性のあるプロパティで有効な値を維持することは、多くのフレームワークにおいて、開発上の難しい問題です。 Windows ランタイムのプロパティ システムでは、各依存関係プロパティでプロパティ値が変更されるたびに呼び出されるコールバックを指定できます。 このコールバックを使用して、一般的な同期方法で、関連プロパティ値を通知または変更できます。 多くの既存の依存関係プロパティに、プロパティ変更動作があります。 また、同様のコールバック動作をカスタム依存関係プロパティに追加し、独自のプロパティ変更コールバックを実装することもできます。 例については、「[カスタム依存関係プロパティ](custom-dependency-properties.md)」をご覧ください。

Windows 10 では、[ **RegisterPropertyChangedCallback** ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobject.registerpropertychangedcallback.aspx) メソッドが導入されています。 これによりアプリケーション コードは、[ **DependencyObject**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.dependencyobject.aspx) のインスタンスで依存関係プロパティが変更された場合の変更通知を登録できます。

### <a name="default-value-and-clearvalue"></a>既定値と **ClearValue**

依存関係プロパティには、プロパティ メタデータの一部として既定値を定義できます。 依存関係プロパティの場合、その既定値は、プロパティが最初に設定された後も無効にはなりません。 既定値は、値の優先順位で他の決定要因がなくなるたびに、実行時に再び適用されることがあります  (依存関係プロパティ値の優先順位については、次のセクションで説明します)。たとえば、ユーザーが意図的にプロパティに適用されるスタイル値またはアニメーションを削除しても、削除後に適切な既定値がこれらのプロパティ値に適用されるようにしたい場合があります。 依存関係プロパティの既定値を使うと、各プロパティの値を余分な手間をかけて特に設定することなく、適切な値を適用することができます。

既にローカル値を設定した後でも、意図的にプロパティを既定値に設定することができます。 値を既定値にリセットし、優先順位が既定値よりも高く、ローカル値よりも低い値を有効にするには、プロパティの [**ClearValue**](https://msdn.microsoft.com/library/windows/apps/br242357) メソッドを呼び出します (メソッド パラメーターとしてクリアするプロパティを参照)。 プロパティで常に既定値がそのまま使われるようにしたくない場合、ローカル値をクリアして既定値に戻しても、コントロール テンプレートのスタイル setter に由来する値など、優先順位内の別の項目が有効になることがあります。

## <a name="dependencyobject-and-threading"></a>**DependencyObject** とスレッド

すべての [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) インスタンスは、Windows ランタイム アプリによって表示される現在の [**Window**](https://msdn.microsoft.com/library/windows/apps/br209041) と関連付けられている UI スレッド上で作成する必要があります。 それぞれの **DependencyObject** はメイン UI スレッド上で作成する必要がありますが、オブジェクトは、[**Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br230616) プロパティにアクセスすることにより、他のスレッドからディスパッチャー参照を使ってアクセスできます。 続いて、[**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) オブジェクトの [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) のようなメソッドを呼び出して、UI スレッドのスレッド制限の規則内でコードを実行します。

[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) のスレッドの側面も問題となります。それは、通常、UI スレッド上で実行されるコードのみが依存関係プロパティの値を変更または読み取ることができることを意味するためです。 通常、**非同期**パターンとバックグラウンド ワーカー スレッドを適切に使う一般的な UI コードでは、スレッドの問題を回避できます。 独自に **DependencyObject** 型を定義し、それをデータ ソースや **DependencyObject** が必ずしも適切でないその他のシナリオで使おうとすると、通常は **DependencyObject** に関連するスレッドの問題が発生します。

## <a name="related-topics"></a>関連トピック

### <a name="conceptual-material"></a>概念に関する資料

- [カスタム依存関係プロパティ](custom-dependency-properties.md)
- [添付プロパティの概要](attached-properties-overview.md)
- [データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)
- [ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/mt187354)
- [Windows ランタイム コンポーネントの作成](https://msdn.microsoft.com/library/windows/apps/xaml/hh441572.aspx)
- [XAML ユーザーとカスタム コントロールのサンプル](http://go.microsoft.com/fwlink/p/?linkid=238581)

## <a name="apis-related-to-dependency-properties"></a>依存関係プロパティに関連する Api

- [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356)
- [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362)

