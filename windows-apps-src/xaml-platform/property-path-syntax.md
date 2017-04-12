---
author: jwmsft
description: "PropertyPath クラスと文字列構文を使うと、PropertyPath 値を XAML またはコードでインスタンス化できます。"
title: "プロパティ パス構文"
ms.assetid: FF3ECF47-D81F-46E3-BE01-C839E0398025
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 3209028f151608c83e69d6750e978132a6c8b83c
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="property-path-syntax"></a>プロパティ パス構文

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

[**PropertyPath**](https://msdn.microsoft.com/library/windows/apps/br244259) クラスと文字列構文を使うと、**PropertyPath** 値を XAML またはコードでインスタンス化できます。 **PropertyPath** 値は、データ バインディングで使われます。 ストーリーボードに設定されたアニメーションのターゲットを設定する場合も、同様の構文が使われます。 どちらのシナリオにおいても、プロパティ パスは、最終的に 1 つのプロパティに解決される 1 つまたは複数のオブジェクトとプロパティの関係のトラバーサルを記述します。

プロパティ パス文字列は、XAML の属性に直接設定できます。 同じ文字列構文を使って、[**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) をコードで設定する [**PropertyPath**](https://msdn.microsoft.com/library/windows/apps/br244259) を作成することも、[**SetTargetProperty**](https://msdn.microsoft.com/library/windows/apps/br210503) を使ってコードでアニメーション ターゲットを設定することもできます。 Windows ランタイムには、プロパティ パスを使う機能領域として、データ バインディングとアニメーション ターゲット設定の 2 つがあります。 Windows ランタイムの実装時には、アニメーション ターゲット設定で基になる PropertyPath 値が作成されず、情報が文字列として保持されます。しかし、オブジェクトとプロパティのトラバーサルの概念はよく似ています。 データ バインディングとアニメーション ターゲット設定ではプロパティ パスの評価方法が多少異なるため、それぞれについてプロパティ パス構文を説明していきます。

## <a name="property-path-for-objects-in-data-binding"></a>データ バインディングでのオブジェクトのプロパティ パス

Windows ランタイムでは、任意の依存関係プロパティのターゲット値にバインドできます。 データ バインディングのソース プロパティ値は、依存関係プロパティである必要はなく、ビジネス オブジェクト (たとえば、Microsoft .NET 言語または C++ で書かれたクラス) のプロパティを使うことができます。 また、バインド値のソース オブジェクトには、アプリによって定義され、既に存在している依存関係オブジェクトを使うことができます。 ソースは、単純なプロパティ名を使うか、またはビジネス オブジェクトのオブジェクト グラフのオブジェクトとプロパティの関係のトラバーサルによって参照できます。

バインド先として、個々のプロパティか、またはリストまたはコレクションを保持するターゲット プロパティを設定できます。 ソースがコレクションの場合、またはパスにコレクション プロパティが指定されている場合、データ バインディング エンジンにより、ソースのコレクション項目がバインディング ターゲットと照合されます。その結果、コレクション内の特定の項目を予測する必要なく、[**ListBox**](https://msdn.microsoft.com/library/windows/apps/br242868) にデータ ソース コレクションの項目のリストを設定する動作が実行されます。

### <a name="traversing-an-object-graph"></a>オブジェクト グラフのトラバーサル

オブジェクト グラフ内のオブジェクトとプロパティの関係のトラバーサルを示す構文要素は、ドット (**.**) 文字です。 プロパティ パス文字列の各ドットは、オブジェクト (ドットの左側) とそのオブジェクトのプロパティ (ドットの右側) の間の区切りを表します。 文字列は左から右へ評価され、これにより複数のオブジェクトとプロパティの関係をステップごとに表すことができます。 次に例を示します。

``` syntax
"{Binding Path=Customer.Address.StreetAddress1}"
```

このパスは、次のように評価されます。

1.  データ コンテキスト オブジェクト (または同じ [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) によって指定された [**Source**](https://msdn.microsoft.com/library/windows/apps/br209832)) で、"Customer" という名前のプロパティが検索されます。
2.  "Customer" プロパティの値であるオブジェクトで、"Address" という名前のプロパティが検索されます。
3.  "Address" プロパティの値であるオブジェクトで、"StreetAddress1" という名前のプロパティが検索されます。

これらのそれぞれの手順で、値はオブジェクトとして扱われます。 結果の型は、バインドが特定のプロパティに割り当てられたときにのみ確認されます。 "Address" が単なる文字列値で、文字列のどの部分が番地を表しているかが示されない場合、この例は失敗します。 通常、バインドは、既知の意図的な情報構造を持つビジネス オブジェクトの特定の入れ子にされたプロパティ値を指し示します。

### <a name="rules-for-the-properties-in-a-data-binding-property-path"></a>データ バインディング プロパティ パスのプロパティの規則

-   プロパティ パスで参照されるすべてのプロパティは、ソース ビジネス オブジェクト内でパブリックであることが必要です。
-   終了プロパティ (パスに指定された最後のプロパティ) は、パブリックであり変更可能である必要があります。静的値にバインドすることはできません。
-   このパスが双方向バインドの [**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) 情報として使われる場合、終了プロパティは読み取り/書き込み可能である必要があります。

### <a name="indexers"></a>インデクサー

データ バインディングのプロパティ パスには、インデックス付きプロパティへの参照を含めることができます。 これにより、順序指定された一覧/ベクターまたは辞書/地図へのバインドが可能になります。 インデックス付きプロパティを示すには、角かっこ "\[\]" を使います。 角かっこ内には、整数 (順序指定された一覧用) または引用符で囲まれていない文字列 (辞書用) を含めることができます。 また、キーが整数である辞書にバインドすることもできます。 オブジェクトとプロパティを区切るドットを使って、同じパス内で異なるインデックス付きプロパティを使うことができます。

たとえば、"Teams" (順序指定された一覧) の一覧を含むビジネス オブジェクトがあるとします。それぞれには、各プレイヤーの姓がキーとして使われている、"Players" という辞書があるとします。 たとえば、2 番目のチームの特定のプレイヤーのプロパティ パスは、"Teams\[1\].Players\[Smith\]" となります  (一覧はインデックス 0 で始まるため、"Teams" の 2 番目の項目を示すには 1 を使います)。

**注:** C++ データ ソースに対してインデックスを付けられる局面は限られています。詳しくは、「[データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)」をご覧ください。

### <a name="attached-properties"></a>添付プロパティ

プロパティ パスには、添付プロパティへの参照を含めることができます。 添付プロパティの識別名には既にドットが含まれているため、ドットがオブジェクトとプロパティのステップとして処理されないように、すべての添付プロパティ名をかっこで囲む必要があります。 たとえば、[**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/hh759773) をバインド パスとして使うことを指定する文字列は "(Canvas.ZIndex)" となります。 添付プロパティについて詳しくは、「[添付プロパティの概要](attached-properties-overview.md)」をご覧ください。

### <a name="combining-property-path-syntax"></a>プロパティ パス構文の組み合わせ

プロパティ パス構文のさまざまな要素を 1 つの文字列で組み合わせることができます。 たとえば、インデックス付き添付プロパティを参照するプロパティ パスを定義できます (データ ソースにインデックス付き添付プロパティがある場合)。

### <a name="debugging-a-binding-property-path"></a>バインド プロパティ パスのデバッグ

プロパティ パスはバインド エンジンによって解釈され、実行時にのみ存在する可能性がある情報に依存するため、開発ツールの従来の設計時またはコンパイル時サポートに頼らずに、バインドのためのプロパティ パスをデバッグすることが必要になります。 多くの場合、実行時にプロパティ パスの解決に失敗すると、エラーなしで空白値が生成されます。これは、バインド解決の意図的なフォールバック動作です。 Microsoft Visual Studio には、バインド ソースを指定するプロパティ パスのどの部分で解決が失敗したかを特定できるデバッグ出力モードが用意されています。 この開発ツールの機能の使い方について詳しくは、[「データ バインディングの詳細」の「デバッグ」セクション](../data-binding/data-binding-in-depth.md#debugging)をご覧ください。

## <a name="property-path-for-animation-targeting"></a>アニメーション ターゲット設定のためのプロパティ パス

アニメーションは、アニメーションの実行時にストーリーボードに設定された値が適用される依存関係プロパティのターゲット設定に依存します。 アニメーション化されるプロパティが存在するオブジェクトを識別するために、アニメーションは、要素を名前 ([x:Name 属性](x-name-attribute.md)) でターゲット設定します。 通常、[**Storyboard.TargetName**](https://msdn.microsoft.com/library/windows/apps/hh759823) として識別されたオブジェクトで始まり、アニメーションが適用される特定の依存関係プロパティ値で終わるプロパティ パスを定義する必要があります。 このプロパティ パスは、[**Storyboard.TargetProperty**](https://msdn.microsoft.com/library/windows/apps/hh759824) の値として使われます。

XAML でアニメーションを定義する方法について詳しくは、「[ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/mt187354)」をご覧ください。

## <a name="simple-targeting"></a>単純なターゲット設定

ターゲット設定されたオブジェクト自体に存在するプロパティをアニメーション化するときに、(プロパティ値のサブプロパティではなく) このプロパティの型にアニメーションを直接適用できる場合は、修飾を追加することなく、アニメーション化の対象のプロパティを指定するだけでかまいません。 たとえば、[**Shape**](https://msdn.microsoft.com/library/windows/apps/br243377) サブクラス ([**Rectangle**](https://msdn.microsoft.com/library/windows/apps/br243371) など) をターゲット設定し、アニメーション化された [**Color**](https://msdn.microsoft.com/library/windows/apps/hh673723) を [**Fill**](https://msdn.microsoft.com/library/windows/apps/br243378) プロパティに割り当てる場合、プロパティ パスとして "Fill" を指定できます。

## <a name="indirect-property-targeting"></a>間接的なプロパティのターゲット設定

ターゲット オブジェクトのサブプロパティであるプロパティをアニメーション化できます。 言い換えると、ターゲット オブジェクトにプロパティがあり (つまり、オブジェクト自体)、このオブジェクトにプロパティがある場合は、オブジェクトとプロパティの関係をステップごとに表す方法を説明するプロパティ パスを定義する必要があります。 サブプロパティをアニメーション化するオブジェクトを指定するときは、必ずプロパティ名をかっこで囲み、プロパティを *typename*.*propertyname* 形式で指定します。 たとえば、ターゲット オブジェクトの [**RenderTransform**](https://msdn.microsoft.com/library/windows/apps/br208980) プロパティのオブジェクト値を指定するには、"(UIElement.RenderTransform)" をプロパティ パスの最初のステップとして指定します。 [**Transform**](https://msdn.microsoft.com/library/windows/apps/br243006) 値に直接適用できるアニメーションはないため、これはまだ完全なパスではありません。 そこで、この例では、**Double** 値によってアニメーション化できる **Transform** サブクラスのプロパティを終了プロパティに指定して、"(UIElement.RenderTransform).(CompositeTransform.TranslateX)" というプロパティ パスを完成させます。

## <a name="specifying-a-particular-child-in-a-collection"></a>コレクション内の特定の子の指定

コレクション プロパティ内の子項目を指定する場合、数値インデクサーを使うことができます。 整数インデックス値を角かっこ "\[\]" で囲みます。 参照できるのは順序指定された一覧のみで、辞書は参照できません。 コレクションはアニメーション化できる値ではないため、インデクサーの使用はプロパティ パスの終了プロパティとなりません。

たとえば、コントロールの [**Background**](https://msdn.microsoft.com/library/windows/apps/br209395) プロパティに適用される [**LinearGradientBrush**](https://msdn.microsoft.com/library/windows/apps/br210108) の最初のカラー ストップ カラーをアニメーション化する場合のプロパティ パスは、"(Control.Background).(GradientBrush.GradientStops)\[0\].(GradientStop.Color)" となります。 インデクサーがパスの最終ステップにならないことに注目してください。さらに、アニメーション化された値 [**Color**](https://msdn.microsoft.com/library/windows/apps/hh673723) を適用するために特に最終ステップでコレクション内の項目 0 の [**GradientStop.Color**](https://msdn.microsoft.com/library/windows/apps/br210094) プロパティを参照する必要があることに注目してください。

## <a name="animating-an-attached-property"></a>添付プロパティのアニメーション化

これは一般的なシナリオではありませんが、添付プロパティがアニメーションの種類と一致するプロパティ値を持つ限り、添付プロパティをアニメーション化することもあります。 添付プロパティの識別名には既にドットが含まれているため、ドットがオブジェクトとプロパティのステップとして処理されないように、すべての添付プロパティ名をかっこで囲む必要があります。 たとえば、オブジェクトの [**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/hh759795) 添付プロパティをアニメーション化することを指定する文字列として、プロパティ パス "(Grid.Row)" を使います。

**注:** この例では、[**Grid.Row**](https://msdn.microsoft.com/library/windows/apps/hh759795) の値は **Int32** プロパティ型です。 したがって、**Double** アニメーションを使ってこれをアニメーション化することはできません。 その代わり、[**DiscreteObjectKeyFrame**](https://msdn.microsoft.com/library/windows/apps/br243132) コンポーネントを持つ [**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/br210320) を定義します。ここで、[**ObjectKeyFrame.Value**](https://msdn.microsoft.com/library/windows/apps/br210344) は、"0"、"1" などの整数に設定します。

## <a name="rules-for-the-properties-in-an-animation-targeting-property-path"></a>アニメーション ターゲット設定プロパティ パスのプロパティの規則

-   プロパティ パスの想定される開始点は、[**Storyboard.TargetName**](https://msdn.microsoft.com/library/windows/apps/hh759823) によって識別されるオブジェクトです。
-   プロパティ パスで参照されるすべてのオブジェクトおよびプロパティは、パブリックであることが必要です。
-   終了プロパティ (パスに指定された最後のプロパティ) は、パブリックで読み取り/書き込み可能な依存関係プロパティである必要があります。
-   終了プロパティは、さまざまなアニメーションの種類 ([**Color**](https://msdn.microsoft.com/library/windows/apps/hh673723) アニメーション、**Double** アニメーション、[**Point**](https://msdn.microsoft.com/library/windows/apps/br225870) アニメーション、[**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/br210320)) のいずれかでアニメーション化できるプロパティ型を持つ必要があります。

## <a name="the-propertypath-class"></a>PropertyPath クラス

[**PropertyPath**](https://msdn.microsoft.com/library/windows/apps/br244259) クラスは、バインド シナリオのための [**Binding.Path**](https://msdn.microsoft.com/library/windows/apps/br209830) の基になるプロパティ型です。

ほとんどの場合、コードをまったく使わずに [**PropertyPath**](https://msdn.microsoft.com/library/windows/apps/br244259) を XAML で適用できます。 しかし、場合によっては、コードを使って **PropertyPath** オブジェクトを定義し、実行時にプロパティに割り当てることができます。

[**PropertyPath**](https://msdn.microsoft.com/library/windows/apps/br244259) は [**PropertyPath(String)**](https://msdn.microsoft.com/library/windows/apps/br244261) コンストラクターを持ちますが、既定のコンストラクターはありません。 このコンストラクターには、前に説明したプロパティ パス構文を使って定義した文字列を渡します。 これは、パスを [**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) 属性として割り当てるために使うのと同じ文字列でもあります。 **PropertyPath** クラスの唯一の他の API は [**Path**](https://msdn.microsoft.com/library/windows/apps/br244260) プロパティで、これは読み取り専用です。 このプロパティは、他の **PropertyPath** インスタンスの構成文字列として使うことができます。

## <a name="related-topics"></a>関連トピック

* [データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [ストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/mt187354)
* [{Binding} マークアップ拡張](binding-markup-extension.md)
* [**PropertyPath**](https://msdn.microsoft.com/library/windows/apps/br244259)
* [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820)
* [**Binding コンストラクター**](https://msdn.microsoft.com/library/windows/apps/br209825)
* [**DataContext**](https://msdn.microsoft.com/library/windows/apps/br208713)

