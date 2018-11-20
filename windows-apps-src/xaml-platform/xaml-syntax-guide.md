---
author: jwmsft
description: ここでは、XAML 構文の規則と、XAML 構文に存在する制限や選択肢を説明する用語について説明します。
title: XAML 構文のガイド
ms.assetid: A57FE7B4-9947-4AA0-BC99-5FE4686B611D
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 1fe2460dfc5ab11a9168f1d1d87207d2b9490026
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7305432"
---
# <a name="xaml-syntax-guide"></a>XAML 構文のガイド


ここでは、XAML 構文の規則と、XAML 構文に存在する制限や選択肢を説明する用語について説明します。 このトピックは、XAML 言語の初心者を対象に作成されています。XAML の用語や構文の復習にも使用できます。また、XAML 言語のしくみや背景知識を知ることもできます。

## <a name="xaml-is-xml"></a>XAML は XML

Extensible Application Markup Language (XAML) の基本的な構文は XML に基づいています。したがって、有効な XAML は有効な XML である必要があります。 ただし、XAML には XML を拡張した独自の構文概念もあります。 ある XML エンティティの構文がプレーン XML で有効であったとしても、XAML では別のより完全な意味を持つことがあります。 ここでは、次の XAML 構文の概念について説明します。

## <a name="xaml-vocabularies"></a>XAML ボキャブラリ

XAML がほとんどの XML 応用言語と異なる点としては、XAML には通常、XSD ファイルのようなスキーマが必須でないという点があります。 これは、XAML が拡張可能であることを目的としているためです。XAML という略語の "X" はそういう意味 (Extensible) です。 XAML を解析すると、XAML で参照される要素と属性は、Windows ランタイムで定義された中核となる型、または、Windows ランタイムを拡張または基にした型として、なんらかのバッキング コード表現に存在することが期待されます。 SDK ドキュメントでは、Windows ランタイムで既に定義されていて XAML で使うことのできる型を Windows ランタイムの *XAML ボキャブラリ*と呼ぶことがあります。 Microsoft Visual Studio では、この XAML ボキャブラリ内で有効なマークアップを作成できます。 Visual Studio では、カスタム型のソースがプロジェクトで正しく参照されている限り、XAML で使うカスタム型を含めることもできます。 XAML とカスタム型について詳しくは、「[XAML 名前空間と名前空間マッピング](xaml-namespaces-and-namespace-mapping.md)」をご覧ください。

##  <a name="declaring-objects"></a>オブジェクトの宣言

プログラミングの際にはオブジェクトとメンバーの観点から考えるのが一般的ですが、マークアップ言語は要素と属性で概念化されています。 最も基本的な意味においては、XAML マークアップで宣言する要素はバッキング ランタイム オブジェクト表現のオブジェクトになります。 アプリのランタイム オブジェクトを作成するには、XAML マークアップで XAML 要素を宣言します。 オブジェクトは、Windows ランタイムによって XAML が読み込まれたときに作成されます。

XAML ファイルには、ルートとして機能する要素が常に 1 つあります。ルートは、ページなどのいくつかのプログラミング構造の概念上のルートとなるオブジェクトまたはアプリケーションのランタイム定義全体のオブジェクト グラフを宣言します。

XAML 構文では、次の 3 つの方法を使って XAML でオブジェクトを宣言できます。

-   **オブジェクト要素構文を直接使用:** 開始タグと終了タグを使って、オブジェクトを XML 形式の要素としてインスタンス化します。 この構文を使うと、ルート オブジェクトを宣言することも、プロパティ値を設定する入れ子になったオブジェクトを作成することもできます。
-   **属性構文を間接的に使用:** オブジェクトの作成方法に関する命令が含まれるインライン文字列値を使います。 XAML パーサーは、この文字列を使って、新しく作成した参照値にプロパティ値を設定します。 この方法に対するサポートは、共通のオブジェクトとプロパティの一部に限定されます。
-   マークアップ拡張を使用。

これは、XAML ボキャブラリでオブジェクトの作成用にどの構文を使うかをいつも選択できるというわけではありません。 一部のオブジェクトは、作成時にオブジェクト要素構文しか使用できません。 また、オブジェクトのなかには、最初から属性に設定する方法でしか作成できないものもあります。 実際、オブジェクト要素構文または属性構文のどちらを使っても作成できるというオブジェクトは、XAML ボキャブラリでは比較的まれです。 構文形式が両方とも使用できたとしても、スタイルとしてはどちらか一方が使われることが多くなります。
また、XAML で新しい値を作成するのではなく、今あるオブジェクトを参照するために使用できる手法もあります。 今あるオブジェクトは、XAML の他の領域で定義されていることもあれば、プラットフォームとそのアプリケーションまたはプログラミング モデルの特定の動作を介して暗黙的に存在することもあります。

### <a name="declaring-an-object-by-using-object-element-syntax"></a>オブジェクト要素構文を使用したオブジェクトの宣言

オブジェクト要素構文を使ってオブジェクトを宣言するには、`<objectName>  </objectName>` のようにタグを記述します。ここで、*objectName* は、インスタンス化するオブジェクトの型名を表します。 [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) オブジェクトを宣言するためのオブジェクト要素の使用方法は次のとおりです。

```xml
<Canvas>
</Canvas>
```

オブジェクトに他のオブジェクトを含めない場合は、開始タグと終了タグのペアを使う代わりに、1 つの自己終了タグ () を使ってオブジェクト要素を宣言できます。 `<Canvas />`

### <a name="containers"></a>コンテナー

UI 要素として使われるオブジェクト ([**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) など) の多くは、他のオブジェクトを格納することができます。 そのようなオブジェクトは、コンテナーとも呼ばれます。 次の例は、要素 [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) を 1 つ格納している **Canvas** コンテナーを示しています。

```xml
<Canvas>
  <Rectangle />
</Canvas>
```

### <a name="declaring-an-object-by-using-attribute-syntax"></a>属性構文を使用したオブジェクトの宣言

この動作はプロパティの設定に関連付けられているため、次のセクションでさらに詳しく説明します。

### <a name="initialization-text"></a>初期化テキスト

一部のオブジェクトでは、構造の初期値として使われる内部テキストを使って新しい値を宣言できます。 XAML では、この手法と構文を*初期化テキスト*と呼びます。 初期化テキストは概念的に、パラメーターを持つコンストラクターの呼び出しに似ています。 初期化テキストは、一部の構造体の初期値を設定するのに便利です。

構造体の値に **x:Key** を持たせ、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内に存在できるようにする必要がある場合にはよく、オブジェクト要素構文を初期化テキストと共に使います。 この手法は、その構造体の値を複数のターゲット プロパティで共有する場合に使用できます。 一部の構造体では、属性構文を使って構造体の値を設定することができません。このため、初期化テキストが、便利で共有可能な [**CornerRadius**](https://msdn.microsoft.com/library/windows/apps/br242343)、[**Thickness**](https://msdn.microsoft.com/library/windows/apps/br208864)、[**GridLength**](https://msdn.microsoft.com/library/windows/apps/br208754)、[**Color**](https://msdn.microsoft.com/library/windows/apps/hh673723) リソースを生成するための唯一の方法になります。

この省略された例では、初期化テキストを使って [**Thickness**](https://msdn.microsoft.com/library/windows/apps/br208864) の値 (**Left** と **Right** を 20 に、**Top** と **Bottom** を 10 に設定する値) を指定しています。 この例は、キーを持つリソースとして作成された **Thickness** と、そのリソースへの参照を示しています。 [**Thickness**](https://msdn.microsoft.com/library/windows/apps/br208864) の初期化テキストについて詳しくは、「[**Thickness**](https://msdn.microsoft.com/library/windows/apps/br208864)」をご覧ください。

```xml
<UserControl ...>
  <UserControl.Resources>
    <Thickness x:Key="TwentyTenThickness">20,10</Thickness>
    ....
  </UserControl.Resources>
  ...
  <Grid Margin="{StaticResource TwentyTenThickness}">
  ...
  </Grid>
</UserControl ...>
```

**注:** 一部の構造体は、オブジェクト要素として宣言することはできません。 初期化テキストがサポートされておらず、リソースとして使うことができません。 XAML でそれらの値にプロパティを設定するには、属性構文を使う必要があります。 そのような型には、[**Duration**](https://msdn.microsoft.com/library/windows/apps/br242377)、[**RepeatBehavior**](https://msdn.microsoft.com/library/windows/apps/br210411)、[**Point**](https://msdn.microsoft.com/library/windows/apps/br225870)、[**Rect**](https://msdn.microsoft.com/library/windows/apps/br225994)、[**Size**](https://msdn.microsoft.com/library/windows/apps/br225995) などがあります。

## <a name="setting-properties"></a>プロパティの設定

オブジェクト要素構文を使用して宣言したオブジェクトのプロパティを設定できます。 XAML では、複数の方法でプロパティを設定できます。

-   属性構文を使用する。
-   プロパティ要素構文を使用する。
-   コンテンツ (内部テキストまたは子要素) によってオブジェクトの XAML コンテンツ プロパティが設定される要素構文を使用する。
-   コレクション構文を使用する (通常は暗黙的なコレクション構文)。

オブジェクトの宣言の場合と同様に、プロパティを設定する際にどの方法でも使用できるというわけではありません。 一部のプロパティでは、1 種類の方法しかサポートされません。
プロパティのなかには、複数の形式をサポートしているものもあります。たとえば、プロパティ要素構文と属性構文のどちらも使用できるプロパティもあります。 どれを使用できるかは、プロパティと、そのプロパティが使うオブジェクト型の両方に応じて決まります。 Windows ランタイム API リファレンスでは、「**構文**」セクションに、使うことができる XAML の使用方法が表示されます。 ときには、使うことができても冗長な別の方法が存在することがあります。 そのような冗長な方法は、表示されないこともあります。それは、リファレンスでは XAML でそのプロパティを使うためのベスト プラクティスや実世界のシナリオを示すようにしているためです。 XAML で設定できるプロパティのリファレンス ページにある **XAML の使用方法**に関するセクションに、XAML 構文に関するガイダンスが記載されています。

オブジェクトのプロパティには、XAML では設定できず、コードを使った場合にのみ設定できるプロパティもあります。 このようなプロパティは通常、XAML よりコード ビハインドで使う方が適しています。

読み取り専用プロパティは、XAML で設定することはできません。 コードでも、所有する型はコンストラクター オーバーロード、ヘルパー メソッド、集計プロパティのサポートなど、他の設定方法をサポートしている必要があります。 集計プロパティは、設定可能な他のプロパティの値のほか、組み込み処理のあるイベントに依存することもあります。これらの機能は、依存関係プロパティ システムで使用できます。 集計プロパティをサポートするうえで依存関係プロパティがいかに便利であるかについて詳しくは、「[依存関係プロパティの概要](dependency-properties-overview.md)」をご覧ください。

XAML のコレクション構文の場合、一見、読み取り専用のプロパティを設定しているかのように見えますが、実際は違います。 このトピックの「コレクション構文によるプロパティの設定」をご覧ください。

### <a name="setting-a-property-by-using-attribute-syntax"></a>属性構文によるプロパティの設定

XML や HTML などのマークアップ言語でプロパティ値を設定するには、属性値を設定するのが一般的です。 XAML 属性は、XML で属性値を設定する場合と同じように設定できます。 タグで囲まれ、要素名に続く任意の場所で属性名を指定します。要素名との間は少なくとも 1 つの空白で区切ります。 属性名の後に、等号を挟んで、 引用符で囲んだ属性値を指定します。 引用符は、値の前後で対応していれば二重引用符と単一引用符のどちらでもかまいません。 属性値は、文字列として表現できる値である必要があります。 文字列には数字が含まれることが多いものの、XAML では、XAML パーサーが関与して基本的な値の変換を実行するまで、属性値がすべて文字列値となります。

この例では、4 つの属性の属性構文を使用して、[**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) オブジェクトの [**Name**](https://msdn.microsoft.com/library/windows/apps/br208735)、[**Width**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Width)、[**Height**](/uwp/api/Windows.UI.Xaml.FrameworkElement.Height)、[**Fill**](/uwp/api/Windows.UI.Xaml.Shapes.Shape.Fill) の各プロパティを設定しています。

```xml
<Rectangle Name="rectangle1" Width="100" Height="100" Fill="Blue" />
```

### <a name="setting-a-property-by-using-property-element-syntax"></a>プロパティ要素構文によるプロパティの設定

オブジェクトの多くのプロパティは、プロパティ要素構文を使って設定できます。 プロパティ要素は次のようになります。`<`*object*`.`*property*`>`

プロパティ要素構文を使うには、設定するプロパティに対応する XAML プロパティ要素を作成します。 標準 XML の場合、この要素は、その名前にドットが含まれている要素と見なされます。 しかし、XAML では、要素名に含まれるドットによって、その要素がプロパティ要素であること、つまり、バッキング オブジェクト モデルの実装で *property* が *object* のメンバーになると想定されていることがわかります。 プロパティ要素構文を使うには、プロパティ要素タグに "設定する" ためにオブジェクト要素を指定できる必要があります。 プロパティ要素にはコンテンツ (単一の要素、複数の要素、または内部テキスト) が常に存在します。自己終了プロパティ要素を使う意味はありません。

次の文法では、*property* は設定するプロパティの名前、*propertyValueAsObjectElement* はプロパティの値の型の要件を満たす単一のオブジェクト要素をそれぞれ表します。

`<`*object*`>`

`<`*object*`.`*property*`>`

*propertyValueAsObjectElement*

`</`*object*`.`*property*`>`

`</`*object*`>`

次の例では、プロパティ要素構文を使用して、[**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/br242962) オブジェクト要素で [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) の [**Fill**](/uwp/api/Windows.UI.Xaml.Shapes.Shape.Fill) を設定しています  (**SolidColorBrush** 内では [**Color**](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush.Color) が属性として設定されています)。この XAML を解析すると、属性構文を使用して **Fill** を設定した上記の XAML の例とまったく同じ結果になります。

```xml
<Rectangle
  Name="rectangle1"
  Width="100" 
  Height="100"
> 
  <Rectangle.Fill> 
    <SolidColorBrush Color="Blue"/> 
  </Rectangle.Fill>
</Rectangle>
```

### <a name="xaml-vocabularies-and-object-oriented-programming"></a>XAML ボキャブラリとオブジェクト指向のプログラミング

Windows ランタイムの XAML 型の XAML メンバーとして表示されるプロパティとイベントは、ほとんどの場合基本型から継承されます。 `<Button Background="Blue" .../>` を例にして考えてみましょう。 [**Background**](https://msdn.microsoft.com/library/windows/apps/br209395) プロパティは、[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) クラスで即座に宣言されるプロパティではありません。 代わりに、[**Control**](https://msdn.microsoft.com/library/windows/apps/br209390) 基底クラスから **Background** が継承されます。 実際、**Button** に関するリファレンスのトピックを見ると、メンバーのリストには連続した基底クラス ([**ButtonBase**](https://msdn.microsoft.com/library/windows/apps/br227736)、[**Control**](https://msdn.microsoft.com/library/windows/apps/br209390)、[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706)、[**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911)、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356)) の各チェーンから継承されたメンバーが少なくとも 1 つ含まれることがわかります。 **[プロパティ]** の一覧では、読み取り/書き込みプロパティとコレクション プロパティがすべて、XAML ボキャブラリという意味で継承されます。 ほかには、イベント (さまざまな [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) イベントなど) が継承されます。

XAML のガイダンスに Windows ランタイム リファレンスを使う場合には、構文やコード例に示されている要素名が、プロパティを定義する型の名前のこともあります。これは、リファレンスのそのトピックが基底クラスからプロパティを継承する型になる可能性のあるものすべてに共通するものであるためです。 Visual Studio の XML エディターで IntelliSense for XAML を使うと、IntelliSense とそのドロップダウン リストによって継承が結合されるほか、クラス インスタンスのオブジェクト要素を開始した時点で設定に利用できる属性の正確な一覧が提供されます。

### <a name="xaml-content-properties"></a>XAML コンテンツ プロパティ

一部の型には、XAML コンテンツ構文を有効にするように定義されたプロパティが 1 つ含まれています。 型に XAML コンテンツ プロパティが含まれている場合には、XAML でプロパティ要素を指定するときにそのプロパティのプロパティ要素を省略できます。 つまり、所有する型のオブジェクト要素タグ内で直接内部テキストを指定することによって、プロパティをその内部テキストの値に設定できます。 XAML コンテンツ プロパティでは、そのプロパティのマークアップ構文を単純化できるため、入れ子の数を少なくすることによって XAML をわかりやすくすることができます。

XAML コンテンツ構文が利用できる場合、Windows ランタイム リファレンス ドキュメントでは、該当するプロパティの「**構文**」の XAML に関するセクションにその構文が示されています。 たとえば、[**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) の [**Child**](https://msdn.microsoft.com/library/windows/apps/br209258) プロパティのページには、プロパティ要素構文の代わりに、**Border** の単一オブジェクト **Border.Child** 値を設定する XAML コンテンツ構文が示されています。

```xml
<Border>
  <Button .../>
</Border>
```

XAML コンテンツ プロパティとして宣言されているプロパティで、プロパティの型が **Object** と **String** のいずれかの場合には、基本的に XML ドキュメント モデルの内部テキストになるもの (開始オブジェクト タグと終了オブジェクト タグの間の文字列) が XAML コンテンツ構文でサポートされます。 たとえば、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) の [**Text**](https://msdn.microsoft.com/library/windows/apps/br209676) プロパティのページには、**Text** を設定する内部テキスト値のある XAML 構文が示されていますが、文字列 "Text" が表示されることはありません。 次に使用方法の例を示します。

```xml
<TextBlock>Hello!</TextBlock>
```

あるクラスに XAML コンテンツ プロパティが存在する場合には、そのクラスに関するリファレンス トピックの「属性」のセクションに記載されています。 [**ContentPropertyAttribute**](https://msdn.microsoft.com/library/windows/apps/br228011) の値を検索します。 この属性は名前の付いたフィールド、"Name" を使います。 "Name" の値は、XAML コンテンツ プロパティとなるクラスのプロパティの名前です。 たとえば、[**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) リファレンス ページでは、ContentProperty("Name=Child") と表示されています。

ここで重要になる XAML 構文の規則の 1 つは、XAML コンテンツ プロパティ要素と、その要素で設定する他のプロパティ要素は混在できないというものです。 XAML コンテンツ プロパティは、プロパティ要素の前か、後に設定する必要があります。 たとえば、このような XAML は無効です。

``` syntax
<StackPanel>
  <Button>This example</Button>
  <StackPanel.Resources>
    <SolidColorBrush x:Key="BlueBrush" Color="Blue"/>
  </StackPanel.Resources>
  <Button>... is illegal XAML</Button>
</StackPanel>
```

## <a name="collection-syntax"></a>コレクション構文

これまでに見てきた構文はすべて、プロパティを 1 つのオブジェクトに設定しています。 しかし、複数の子要素を持つ親要素が必要な UI シナリオも数多くあります。 たとえば、入力フォームの UI では、複数のテキスト ボックス要素、いくつかのラベル、そしておそらくは 1 つの "Submit" ボタンが必要になります。 それでも、プログラミング オブジェクト モデルを使用してそれらの要素にアクセスする場合は、別々のプロパティの値としてアクセスするのではなく、1 つのコレクション プロパティの項目としてアクセスするのが一般的です。 XAML では、複数の子要素や、一般的なバッキング コレクション モデルがサポートされています。これは、暗黙的にコレクション型を使うプロパティを扱い、コレクション型の子要素を特別な方法で処理することによって実現されます。

このほか、多くのコレクション プロパティが、クラスの XAML コンテンツ プロパティとして識別されます。 暗黙的なコレクション処理と XAML コンテンツ構文を組み合わせた記述は、パネル、ビュー、項目コントロールなどのコントロールを合成するために広く使われる型によく見られます。 次の例は、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/br209635) 内で 2 つのピア UI 要素を合成させる XAML を可能な限り単純化したものです。

```xml
<StackPanel>
  <TextBlock>Hello</TextBlock>
  <TextBlock>World</TextBlock>
</StackPanel>
```

### <a name="the-mechanism-of-xaml-collection-syntax"></a>XAML コレクション構文のメカニズム

最初は、XAML で読み取り専用のコレクションのプロパティを "設定" しているかのように思えます。 しかし、実際には、XAML によって実現されているのは、既にあるコレクションに項目を追加することです。 XAML のサポートを実装する XAML 言語および XAML プロセッサは、この構文を有効にするためにバッキング コレクション型の規則に依存します。 通常は、コレクションの特定の項目を参照するインデクサーや **Items** プロパティなどのバッキング プロパティが存在しますが、 XAML 構文では、一般にそのようなプロパティは明示されません。 コレクションの場合、XAML の解析の基になるメカニズムは、プロパティではなくメソッド (ほとんどの場合 **Add** メソッド) です。 XAML プロセッサが XAML コレクション構文内に 1 つまたは複数のオブジェクト要素を見つけると、各オブジェクトが要素から作成され、次に、コレクションの **Add** メソッドの呼び出しによって、新しく作成された各オブジェクトが格納先のコレクションに順番に追加されます。

XAML パーサーによってコレクションに項目が追加されるときに、特定の XAML 要素がコレクション オブジェクトの子項目として許容されるかどうかは、**Add** メソッドのロジックによって決まります。 多くのコレクション型はバッキング実装によって厳密に型指定されているため、**Add** の入力パラメーターに渡される値の型が **Add** のパラメーター型と一致する必要があります。

コレクション プロパティでは、オブジェクト要素としてコレクションを明示的に指定するときには注意が必要です。 XAML パーサーは、オブジェクト要素を検出するたびに新しいオブジェクトを作成します。 使おうとしているコレクション プロパティが読み取り専用の場合には、XAML 解析で例外が発生する可能性があります。 暗黙的なコレクション構文だけを使えば、その例外が表示されることはありません。

## <a name="when-to-use-attribute-or-property-element-syntax"></a>属性構文を使用する状況とプロパティ要素構文を使用する状況

XAML で設定可能なプロパティはいずれも、直接値を設定するための属性構文またはプロパティ要素構文をサポートしますが、両方の構文をサポートしない可能性もあります。 いずれかの構文をサポートするプロパティもあれば、XAML コンテンツ プロパティなど、他の構文オプションをサポートしているプロパティもあります。 プロパティでサポートされる XAML 構文の種類は、そのプロパティでプロパティの型として使われるオブジェクトの型によって決まります。 プロパティ型が double (float または decimal)、integer、Boolean、string など、プリミティブ型の場合には、そのプロパティは常に属性構文をサポートします。

プロパティを設定する際、その設定に使うオブジェクト型を文字列の処理によって作成できる場合も、属性構文を使用できます。 プリミティブではこれが常に当てはまり、パーサーには型変換が組み込まれています。 ただし、その他のオブジェクト型のなかにも、プロパティ要素内のオブジェクト要素ではなく、属性値として指定された文字列を使って作成できるものがあります。 これを正しく機能させるには、基になる型変換が必要です。この型変換は、特定のプロパティでサポートされるか、該当するプロパティ型を使う値すべてでサポートされます。 属性の文字列値を使って、新しいオブジェクト値の初期化にとって重要なプロパティが設定されます。 型コンバーターによっては、文字列の情報を処理する方法に応じて、一般的なプロパティ型のさまざまなサブクラスが作成される可能性もあります。 この動作をサポートするオブジェクト型は、リファレンス ドキュメントの構文のセクションに特別な文法が記載されます。 たとえば、[**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) の XAML 構文では、属性構文を使って **Brush** 型のプロパティの新しい [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/br242962) 値を作成する方法を示しています (Windows ランタイム XAML には多数の **Brush** プロパティがあります)。

## <a name="xaml-parsing-logic-and-rules"></a>XAML 解析のロジックと規則

XAML パーサーが XAML を読み取るのと似た (文字列トークンのセットを順番に読み取っていく) 方法で XAML を読んでみると、有益な情報が得られることがあります。 XAML パーサーは、XAML の動作に関する定義に含まれる規則に基づいて、トークンを解釈する必要があります。

XML や HTML などのマークアップ言語でプロパティ値を設定するには、属性値を設定するのが一般的です。 次の構文では、*objectName* はインスタンス化するオブジェクト、*propertyName* はそのオブジェクトに設定するプロパティの名前、*propertyValue* は設定する値をそれぞれ表します。

```xml
<objectName propertyName="propertyValue" .../>

-or-

<objectName propertyName="propertyValue">

...<!--element children -->

</objectName>
```

このどちらの構文でも、オブジェクトを宣言し、そのオブジェクトのプロパティを設定できます。 最初のサンプルは、1 つのマークアップ要素ですが、このマークアップの解析は、実際には XAML プロセッサで別々の手順で行われます。

まず、オブジェクト要素があるので、新しい *objectName* オブジェクトをインスタンス化する必要があることがわかります。 そのようなインスタンスが作成された後にのみ、そのインスタンスにインスタンス プロパティ *propertyName* を設定できます。

XAML のもう 1 つの規則は、要素の属性がどのような順序でも設定できる必要があるというものです。 たとえば、`<Rectangle Height="50" Width="100" />` と `<Rectangle Width="100"  Height="50" />` の間には違いがありません。 順序をどちらにするかは、スタイルの問題です。

**注:** XAML デザイナー多くの場合の宣伝順序指定の規則、XML エディター以外のデザイン サーフェイスを使用するが、属性を並べ替えたり、新たに導入を後で、その XAML を自由に編集することができます。

## <a name="attached-properties"></a>添付プロパティ

XAML は、*添付プロパティ*と呼ばれる構文要素を追加することによって XML を拡張したものです。 プロパティ要素構文と同様に、添付プロパティ構文にはドットが含まれます。このドットは XAML 解析にとって特別な意味があります。 具体的には、添付プロパティの所有者プロバイダーとプロパティ名がドットで区切られます。

XAML では、*AttachedPropertyProvider*.*PropertyName* 構文を使って添付プロパティを設定します。XAML で添付プロパティ [**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) を設定する例を次に示します。

```xml
<Canvas>
  <Button Canvas.Left="50">Hello</Button>
</Canvas>
```

添付プロパティは、バッキング型に同じ名前のプロパティがない要素に設定できます。そのため、添付プロパティの機能は、グローバル プロパティ、または異なる XML 名前空間によって定義される属性 (**xml:space** 属性など) に似ています。

Windows ランタイム XAML には、次のシナリオをサポートする添付プロパティがあります。

-   子要素が親コンテナーのパネルにレイアウト内での動作を通知する: [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267)、[**Grid**](https://msdn.microsoft.com/library/windows/apps/br242704)、[**VariableSizedWrapGrid**](https://msdn.microsoft.com/library/windows/apps/br227651)。
-   コントロールの使用が、コントロール テンプレートから取得するコントロールの重要性の高い部分の動作に影響を及ぼす: [**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/br209527)、[**VirtualizingStackPanel**](https://msdn.microsoft.com/library/windows/apps/br227689)。
-   サービスと、そのサービスを使うクラスが継承を共有しない場合に、関連クラスで利用できるサービスを利用する: [**Typography**](https://msdn.microsoft.com/library/windows/apps/hh702143)、[**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/br209021)、[**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/br209081)、[**ToolTipService**](https://msdn.microsoft.com/library/windows/apps/br227609)。
-   アニメーションのターゲット設定: [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490)。

詳しくは、「[添付プロパティの概要](attached-properties-overview.md)」をご覧ください。

## <a name="literal--values"></a>リテラルの "{" 値

左中かっこ記号 (\{) はマークアップ拡張シーケンスの開始を表すため、この記号で始まるリテラル文字列値を指定するには、エスケープ シーケンスを使う必要があります。 エスケープ シーケンスは "\{\}" です。 たとえば、単一の左中かっこを表す文字列値を指定するには、属性値を "\{\}\{" として指定します。 このほか、"\{" 値を文字列として指定するために、代替引用符 (**""** で区切られた属性値内の **'** など) を使うこともできます。

**注:**「\\}」は、引用符で囲まれた属性内である場合にも機能します。
 
## <a name="enumeration-values"></a>列挙値

Windows ランタイム API の多くのプロパティでは、値として列挙型が使われます。 メンバーが読み取り/書き込みプロパティの場合には、属性値を指定することによって設定できます。 プロパティの値に使う列挙値を指定するには、定数名の非修飾名を使います。 たとえば、XAML で [**UIElement.Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) を設定するには、`<Button Visibility="Visible"/>` のように記述します。 次に、文字列として "Visible" が [**Visibility**](https://msdn.microsoft.com/library/windows/apps/br209006) 列挙値、**Visible** の名前付きの定数に直接マップされます。

-   修飾された形式は機能しないので、使わないでください。 たとえば、`<Button Visibility="Visibility.Visible"/>` のような XAML は無効です。
-   定数の値を使わないでください。 要するに、列挙体の整数値に依存しないようにしてください。この整数値は、明示的または暗黙的な列挙体の定義方法に応じて変わります。 一見、機能しているように見えても、永続的でない実装の詳細となるものに依存しているため、XAML でもコードでも好ましくない方法です。 たとえば、`<Button Visibility="1"/>` のように記述しないでください。

**注:** で XAML を使用して、列挙型を使用する Api のリファレンス トピック、**構文**の**プロパティの値**のセクションで列挙型へのリンクをクリックします。 列挙体のページに移動するので、その列挙体の名前付き定数を確認できます。

列挙体は、フラグのように機能します。つまり、**FlagsAttribute** で属性が設定されます。 フラグのように機能する列挙体の値の組み合わせを XAML 属性値として指定する必要がある場合は、各列挙体定数の名前を使います。各名前はコンマ (,) で区切り、空白文字は含めません。 フラグのような属性は、Windows ランタイム XAML ボキャブラリでは一般的ではありませんが、それが利用できる例の 1 つが [**ManipulationModes**](https://msdn.microsoft.com/library/windows/apps/br227934) で、XAML でフラグのように機能する列挙値の設定がサポートされています。

## <a name="interfaces-in-xaml"></a>XAML でのインターフェイス

まれに、プロパティの型がインターフェイスである XAML 構文があります。 XAML の型システムでは、インターフェイスを実装する型は解析時に値として許容されます。 値として使えるように、このような型の作成済みのインスタンスが必要になります。 型として使われるインターフェイスは、[**ButtonBase**](https://msdn.microsoft.com/library/windows/apps/br227736) の [**Command**](https://msdn.microsoft.com/library/windows/apps/br227740) と [**CommandParameter**](https://msdn.microsoft.com/library/windows/apps/br227741) プロパティの XAML 構文で見ることができます。 これらのプロパティは、Model-View-ViewModel (MVVM) 設計パターンをサポートしています。この設計パターンでは、**ICommand** インターフェイスはビューとモデルがどのように相互作用するかのコントラクトです。

## <a name="xaml-placeholder-conventions-in-windows-runtime-reference"></a>Windows ランタイム リファレンスでの XAML プレースホルダーの規則

XAML を使用できる Windows ランタイム API のリファレンス トピックでいずれかの「**構文**」セクションを調べたことがあれば、構文にかなりの数のプレースホルダーが含まれていることに気付いたことでしょう。 XAML 構文は、c#、Microsoft Visual Basic、または VisualC ではコンポーネント拡張機能とは異なる (、C++/cli CX) 構文 XAML 構文は使用法構文であるためです。 独自の XAML ファイルでの具体的な使い方を示しますが、使用できる値について説明し過ぎないようにしています。 そのため、通常は使用法としてリテラルとプレースホルダーを混ぜて文法を説明し、プレースホルダーの一部は「**XAML 値**」のセクションで定義します。

プロパティの XAML 構文で型名または要素名が表示されている場合、それらの名前は、元はプロパティを定義する型のための名前です。 しかし、Windows ランタイム XAML は、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) ベースのクラスのクラス継承モデルをサポートしています。 そのため、多くの場合、実際の定義クラスではなく、プロパティまたは属性を最初に定義したクラスから派生したクラスの属性を使います。 たとえば、深い継承を使って、任意の [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) 派生クラスの属性として [**Visibility**](https://msdn.microsoft.com/library/windows/apps/br208992) を設定できます  (例: `<Button Visibility="Visible" />`)。 そのため、XAML 使用方法の構文で示されている要素名が厳密に文字どおりであるとは考えないでください。そのクラスを表す要素と、派生クラスを表す要素でも、その構文が使用できることがあります。 定義要素として示されている型が、現実に使うことはまれであるか不可能である場合、その型の名前は構文内で意図的に小文字にしてあります。 たとえば、**UIElement.Visibility** の構文は、次のようになっています。

``` syntax
<uiElement Visibility="Visible"/>
-or-
<uiElement Visibility="Collapsed"/>
```

多くの XAML 構文のセクションでは、「使用方法」にプレースホルダーが含まれており、それらは「**構文**」セクションのすぐ下の「**XAML 値**」セクションで定義されています。

XAML の使用方法のセクションでも、さまざまな一般化されたプレースホルダーが使われています。 これらのプレースホルダーは、「**XAML 値**」で毎回再定義されるわけではありません。何を表しているかを推測したり、しだいに覚えることができるためです。 ほとんどの読者は、「**XAML 値**」で定義を繰り返し見ることに飽きてしまうと思われるので、定義しないままにしています。 参考までに、これらのプレースホルダーの一部と、それらの一般的な意味を、次の一覧に示しておきます。

-   *object*: 理論上は任意のオブジェクト値ですが、多くの場合、実際には特定の型のオブジェクトに限定されます (文字列かオブジェクトかの選択など)。詳しくは、リファレンス ページの「解説」をご覧ください。
-   *object* *property*: *object* *property* の組み合わせは、示されている構文が多くのプロパティの属性値として使用できる型のための構文である場合に使われます。 たとえば、[**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) の「**XAML 属性の使用方法**」には、<*object* *property*="*predefinedColorName*"/> が含まれています。
-   *eventhandler*: これは、イベント属性のために示される各 XAML 構文の属性値を表します。 これに対して指定するのは、イベント ハンドラー関数の関数名です。 この関数は、XAML ページのコード ビハインドで定義されている必要があります。 プログラミングのレベルでは、その関数は処理するイベントのデリゲート シグネチャと一致する必要があり、一致しない場合はアプリのコードがコンパイルされません。 ただし、それは実際にはプログラミングでの考慮事項であり、XAML での考慮事項ではないため、XAML 構文ではデリゲート型について何も言及しようとはしていません。 イベントのためにどのデリゲートを実装する必要があるかを知りたい場合は、イベントのリファレンス トピックにある「**イベント情報**」セクションの表で、" **デリゲート**" というラベルの行をご覧ください。
-   *enumMemberName*: すべての列挙体の属性構文に示されます。 列挙値を使うプロパティのための同じようなプレースホルダーがありますが、通常は、列挙体の名前を示すプレフィックスがプレースホルダーに付けられます。 たとえば、[**FrameworkElement.FlowDirection**](https://msdn.microsoft.com/library/windows/apps/br208716) で示される構文は、<*frameworkElement***FlowDirection**="* flowDirectionMemberName*"/> です。 これらのプロパティのリファレンス ページで、「**プロパティ値**」のセクションの "**型:**" というテキストの横に表示される、列挙型へのリンクをクリックしてください。 その列挙体を使うプロパティの属性値には、「**メンバー**」の表の「**メンバー名**」列に表示される任意の文字列を使用できます。
-   *double*、*int*、*string*、*bool*: これらは、XAML 言語既知のプリミティブ型です。 C# または Visual Basic を使ってプログラミングを行う場合は、これらの型が Microsoft .NET での対応する型 ([**Double**](https://msdn.microsoft.com/library/windows/apps/xaml/system.double.aspx)、[**Int32**](https://msdn.microsoft.com/library/windows/apps/xaml/system.int32.aspx)、[**String**](https://msdn.microsoft.com/library/windows/apps/xaml/system.string.aspx)、[**Boolean**](https://msdn.microsoft.com/library/windows/apps/xaml/system.boolean.aspx) など) に対応付けられ、XAML で定義された値を .NET コード ビハインドで扱うときには、それらの .NET 型の任意のメンバーを使うことができます。 C++/CX を使ってプログラミングを行う場合は、C++ のプリミティブ型を使いますが、[**Platform**](https://msdn.microsoft.com/library/windows/apps/xaml/hh710417.aspx) 名前空間で定義されている、それらと同等の型 (たとえば [**Platform::String**](https://msdn.microsoft.com/library/windows/apps/xaml/hh755812.aspx)) を使うこともできます。 場合によっては、特定のプロパティに対して、追加の値の制限があります。 しかし、そのような制限はコードの使用方法と XAML の使用方法の両方に適用されるので、それらの注は通常は「XAML」セクションではなく「**プロパティ値**」または「解説」セクションに記載されます。

## <a name="tips-and-tricks-notes-on-style"></a>スタイルに関するヒントと注意事項

-   マークアップ拡張の全般的な説明は、メインの「[XAML の概要](xaml-overview.md)」に記載されています。 ただし、このトピックで示されているガイダンスに最も大きな影響を及ぼすマークアップ拡張は、[StaticResource](staticresource-markup-extension.md) マークアップ拡張 (および関連する [ThemeResource](themeresource-markup-extension.md)) です。 StaticResource マークアップ拡張の機能は、XAML を XAML の [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の再利用可能なリソースにファクタリングできるようにすることです。 ほとんどの場合、**ResourceDictionary** でコントロール テンプレートと関連スタイルを定義します。 コントロール テンプレートの定義またはアプリ固有のスタイルの小さな部分についても、**ResourceDictionary** で定義します。たとえば、[**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/br242962) ではアプリが UI の各部分で何度も使う色を定義します。 StaticResource を使うと、設定にプロパティ要素を使う必要のあるプロパティが、属性構文で設定できるようになります。 XAML をファクタリングして再利用するメリットは、ページ レベルの構文を簡略化するだけにとどまりません。 詳しくは、「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。
-   XAML の例では、空白や改行がどのように適用されるかに関するさまざまな規則が確認できます。 特に、多くの異なる属性が設定されたオブジェクト要素の分割方法に関してはさまざまな規則があります。 これは、単にスタイルの問題です。 Visual Studio の XML エディターでは、XAML を編集するときに既定のスタイル規則が適用されますが、設定で変更することもできます。 まれではあるものの、XAML ファイル内の空白が意味を持つこともあります。このような場合について詳しくは、「[XAML と空白](xaml-and-whitespace.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [XAML の概要](xaml-overview.md)
* [XAML 名前空間と名前空間マッピング](xaml-namespaces-and-namespace-mapping.md)
* [ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)
 

