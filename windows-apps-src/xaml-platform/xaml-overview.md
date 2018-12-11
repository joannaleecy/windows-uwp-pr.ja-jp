---
description: ここでは、Windows ランタイム アプリの開発者を対象に、XAML 言語と XAML の概念を紹介し、Windows ランタイム アプリを作成する際に XAML でオブジェクトを宣言したり属性を設定したりするためのさまざまな方法について説明します。
title: XAML の概要
ms.assetid: 48041B37-F1A8-44A4-BB8E-1D4DE30E7823
ms.date: 07/18/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cppwinrt
- cpp
ms.openlocfilehash: 639f552a240cf8d28d1a2a0ce530315671128746
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8874632"
---
# <a name="xaml-overview"></a>XAML の概要

ここでは、Windows ランタイム アプリの開発者を対象に、XAML 言語と XAML の概念を紹介し、Windows ランタイム アプリを作成する際に XAML でオブジェクトを宣言したり属性を設定したりするためのさまざまな方法について説明します。

## <a name="what-is-xaml"></a>XAML とは

XAML (Extensible Application Markup Language) は宣言型言語の一種です。 具体的には、XAML では、複数のオブジェクトの間の階層的な関係を示す言語構造と、型の拡張をサポートするバッキング型変換を使って、オブジェクトの初期化とオブジェクトのプロパティの設定を行うことができます。 表示される UI 要素を宣言型 XAML マークアップで作成できます。 さらに、各 XAML ファイルに別のコード ビハインド ファイルを関連付けて、イベントに応答することも、XAML で宣言したオブジェクトを操作することもできます。

XAML 言語では、開発プロセスにおけるさまざまなツールや役割の間でソースを交換できます。たとえば、デザイン ツールと IDE の間や、メインの開発者とローカライズを担当する開発者の間で XAML ソースを交換できます。 交換形式として XAML を使うことで、デザイナーと開発者の役割を分離または結合して、それぞれがアプリの制作中に反復的な作業を行うことができます。

Windows ランタイム アプリ プロジェクトの一部としてみた場合、XAML ファイルは .xaml というファイル名拡張子を持つ XML ファイルです。

## <a name="basic-xaml-syntax"></a>基本的な XAML 構文

XAML には、XML に基づく基本的な構文があります。 定義上、有効な XAML は、有効な XML でもある必要があります。 しかし、XAML には、XML 1.0 仕様に基づいて有効な XML でありつつも、別のより完全な意味が割り当てられた構文概念もあります。 たとえば、属性の文字列値またはコンテンツとしてではなく要素内でプロパティ値を設定できる*プロパティ要素構文*がサポートされています。 標準 XML と比較すると、XAML プロパティ要素は、名前にドットを含む要素であるため、プレーン XML でも有効ではありますが、同じ意味にはなりません。

## <a name="xaml-and-microsoft-visual-studio"></a>XAML と Microsoft Visual Studio

Microsoft Visual Studio では、XAML テキスト エディターでも、もっとグラフィカル指向の XAML デザイン サーフェイスでも、有効な XAML 構文の生成を支援する機能を使うことができます。 そのため、Visual Studio を使ってアプリの XAML を作成するときは、キー入力のたびに構文を気にかける必要はありません。 IDE は有効な XAML 構文を記述できるように支援してくれます。たとえば、オート コンプリートによるヒント、Microsoft IntelliSense でのドロップダウン リストによる候補の表示、ツールボックスでの UI 要素ライブラリの表示などの機能があります。 それでも、XAML を初めて使う場合は、XAML 構文の規則と、リファレンスなどのトピックでの XAML 構文の解説で制限や選択肢の説明に使われることがある用語を確認しておくと役に立ちます。 XAML 構文の細かな点について詳しくは、「[XAML 構文のガイド](xaml-syntax-guide.md)」をご覧ください。

## <a name="xaml-namespaces"></a>XAML 名前空間

一般的なプログラミングでは、名前空間とは、プログラミング エンティティの識別子がどのように解釈されるかを決定する、整理のための概念です。 名前空間を使うことで、プログラミング フレームワークは、ユーザーが宣言した識別子とフレームワークで宣言された識別子を区別し、名前空間の修飾により識別子を明確化し、名前スコープの規則を強制的に適用したりすることができます。 XAML には、XAML 言語でこの目的を果たすための独自の XAML 名前空間の概念があります。 XAML では、XML 言語の名前空間の概念が次のように応用および拡張されています。

-   XAML は、名前空間の宣言のために予約された XML 属性 **xmlns** を使います。 この属性の値は、通常は、Uniform Resource Identifier (URI) です。これは XML から継承した慣例です。
-   XAML では、宣言でプレフィックスを使って既定以外の名前空間を宣言し、要素や属性内でプレフィックスを使うことでその名前空間を参照します。
-   XAML には、使用時または宣言時にプレフィックスが付いていないときに使う名前空間である既定の名前空間という概念があります。 既定の名前空間は、XAML プログラミング フレームワークそれぞれに異なる名前空間を定義することができます。
-   名前空間の定義は、XAML ファイルまたはコンストラクト内で親要素から子要素に継承されます。 たとえば XAML ファイルのルート要素の名前空間を定義する場合、そのファイル内のすべての要素はその名前空間の定義を継承します。 ページへの要素がさらに名前空間を定義し直した場合、その要素の子孫は新しい定義を継承します。
-   要素の属性は、要素の名前空間を継承します。 XAML 属性でプレフィックスが使用されることはかなりまれです。

ほとんどの場合、XAML ファイルでは、既定の XAML 名前空間をルート要素で宣言します。 既定の XAML 名前空間は、プレフィックスで修飾することなく宣言できる要素を定義します。 一般的な Windows ランタイム アプリ プロジェクトの場合、この既定の名前空間には、UI 定義で使われる Windows ランタイムの組み込み XAML ボキャブラリがすべて含まれます。これは既定のコントロール、テキスト要素、XAML グラフィックス、アニメーション、データバインド、スタイル サポートの種類などを含みます。 こうして、Windows ランタイム アプリ用に作成する XAML の大半は、一般的な UI 要素を参照するときに XAML の名前空間とプレフィックスを使うことを避けられます。

次のスニペットは、テンプレートを使って作成された、アプリの開始ページの [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) ルートです (開始タグのみを表し、以降は省略しています)。 これは既定の名前空間を宣言し、**x** 名前空間 (次に説明) も宣言しています。

```xml
<Page
    x:Class="Application1.BlankPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
>
```

## <a name="the-xaml-language-xaml-namespace"></a>XAML 言語の XAML 名前空間

ほぼすべての Windows ランタイム XAML ファイルで宣言される特定の XAML 名前空間が、XAML 言語の名前空間です。 この名前空間は、言語仕様に従って XAML 言語で定義される要素と概念を含みます。 慣例として、XAML 言語の XAML 名前空間はプレフィックス "x" にマップされます。 Windows ランタイム アプリ プロジェクトの既定のプロジェクト テンプレートとファイル テンプレートでは、既定の XAML 名前空間 (プレフィックスなし、`xmlns=` のみ) と XAML 言語の XAML 名前空間 (プレフィックス "x") の両方がルート要素の一部として必ず定義されます。

"x" プレフィックス/XAML 言語の XAML 名前空間には、XAML でよく使われるプログラミング構成要素がいくつか存在します。 代表的なコントロールをいくつか次に示します。

| 用語 | 説明 |
|------|-------------|
| [x:Key](x-key-attribute.md) | XAML [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内の各リソースにユーザー定義の一意のキーを設定します。 このキー トークンの文字列は、**StaticResource** マークアップ拡張の引数であり、後でこのキーを使って、アプリの XAML のどこかで使われた別の XAML の XAML リソースを取得することができます。 |
| [x:Class](x-class-attribute.md) | XAML ページのコード ビハインドを提供するクラスのコード名前空間とコード クラス名を指定します。 これによって、アプリのビルド時にビルド アクションによって作成または結合されたクラスの名前が付けられます。 これらのビルド アクションは、XAML マークアップ コンパイラをサポートし、アプリがコンパイルされるときにマークアップとコード ビハインドを組み合わせます。 XAML ページのコード ビハインドをサポートするには、このようなクラスが必要です。 既定の Windows ランタイムのライセンス認証モデルの [**Window.Content**](https://msdn.microsoft.com/library/windows/apps/br209051)。 |
| [x:Name](x-name-attribute.md) | XAML で定義されたオブジェクト要素が処理された後のランタイム コードに存在するインスタンスのランタイム オブジェクト名を指定します。 XAML で **x:Name** を設定することは、コードで名前付き変数を宣言するようなものと考えることができます。 後でわかるように、これは、まさに Windows ランタイム アプリのコンポーネントとして XAML を読み込むときに起こることです。 <br/><div class="alert">**注:**[**FrameworkElement.Name**](https://msdn.microsoft.com/library/windows/apps/br208735)は、フレームワークで同様のプロパティがすべての要素でサポートします。 そのため、その要素型で **FrameworkElement.Name** がサポートされていない場合はいつでも、要素 ID に **x:Name** を使用できます。 |
| [x:Uid](x-uid-directive.md) | 一部のプロパティ値にローカライズされたリソースを使う必要がある要素を識別します。 **x:Uid** の使い方について詳しくは、「[クイック スタート: UI リソースの翻訳](https://msdn.microsoft.com/library/windows/apps/xaml/hh965329)」をご覧ください。 |
| [XAML 固有のデータ型](xaml-intrinsic-data-types.md) | これらの型は、属性やリソースで必要なときに、単純な値型の値を指定できます。 この本質的な型は、各プログラミング言語に固有の定義の一部として一般的に定義される単純な値型に対応しています。 たとえば、[**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/br210320) のストーリーボードに設定された表示状態で使うブール値に対応する **true** を表すオブジェクトが必要になることがあります。 XAML でのその値の場合、**x:Boolean** 固有の型を次のようにオブジェクト要素として使います。  <code>&lt;x:Boolean&gt;True&lt;/x:Boolean&gt;</code> | 

XAML 言語の XAML 名前空間には、その他のプログラミング構成要素もありますが、あまり一般的ではありません。

## <a name="mapping-custom-types-to-xaml-namespaces"></a>XAML 名前空間へのカスタム型のマッピング

XAML の言語として最も強力な機能の 1 つが、Windows ランタイム アプリの XAML ボキャブラリを簡単に拡張できることです。 アプリのプログラミング言語で独自のカスタム型を定義でき、XAML マークアップでそのカスタム型を参照できます。 カスタム型による機能拡張のサポートは、基本的に XAML 言語のしくみに組み込まれています。 フレームワークやアプリの開発者は、XAML が参照するバッキング オブジェクトを作成する責任を負います。 フレームワークもアプリ開発者も、ボキャブラリ内のオブジェクトが何を表現し、基本的な XAML 構文規則を超えて何を行うかについて仕様にバインドされることはありません (XAML 言語の XAML 名前空間の型がなすべきことについて期待されることはありますが、Windows ランタイムはすべての必要なサポートを提供しています)。

Windows ランタイム コア ライブラリ以外のライブラリとメタデータに含まれる型のために XAML を使う場合は、プレフィックスを使って XAML 名前空間を宣言およびマップする必要があります。 ライブラリで定義された型を参照するには、要素を使うときにそのプレフィックスを使います。 プレフィックス マッピングは、通常はルート要素で、その他の XAML 名前空間定義と一緒に、**xmlns** 属性として宣言します。

カスタム型を参照する独自の名前空間定義を行うには、キーワード **xmlns:** に続けて目的のプレフィックスを指定します。 この属性の値には、先頭部分にキーワード **using:** を含める必要があります。 値の残り部分は、カスタム型を含む特定のコード バッキング名前空間を名前で参照する文字列トークンです。

プレフィックスは、その XAML ファイル内の残りのマークアップでその XAML 名前空間を参照するために使われるマークアップ トークンを定義します。 プレフィックスと、XAML 名前空間内で参照されるエンティティの間は、コロン (:) で区切ります。

たとえば、プレフィックス `myTypes` を名前空間 `myCompany.myTypes` にマップする属性構文は `    xmlns:myTypes="using:myCompany.myTypes"` で、代表的な要素の使用方法は次のようになります。 `<myTypes:CustomButton/>`

カスタム型の XAML 名前空間のマッピングの詳細については、コンポーネント拡張機能では VisualC 特別な注意事項を含む (、C++/cli CX)、 [XAML 名前空間と名前空間マッピング](xaml-namespaces-and-namespace-mapping.md)を参照してください。

## <a name="other-xaml-namespaces"></a>その他の XAML 名前空間

プレフィックス "d" (デザイナー名前空間を示す) や、プレフィックス "mc" (マークアップ互換性を示す) を定義している XAML ファイルもよく使われます。 一般に、これらはインフラストラクチャ サポートのために使うか、設計時のツールでシナリオを実現するために使います。 詳しくは、[「XAML 名前空間」トピックの「その他の XAML 名前空間」セクション](xaml-namespaces-and-namespace-mapping.md#other-XAML-namespaces)をご覧ください。

## <a name="markup-extensions"></a>マークアップ拡張

マークアップ拡張は、XAML 言語の概念であり、Windows ランタイム XAML 実装でよく使われています。 マークアップ拡張は、しばしば、単純にバッキング型に基づいて要素を宣言するのとは違って、値または挙動に XAML ファイルでアクセスできる、ある種の "ショートカット" を表します。 マークアップ拡張によっては、構文の合理化、または、異なる XAML ファイル間での整理を目標として、プレーン文字列や入れ子になった追加要素を使ってプロパティを設定できます。

XAML 属性構文では、中かっこ ("{" と "}") によって XAML マークアップ拡張を使っていることを示します。 これにより、XAML プロセッサの通常の処理 (リテラル文字列か、直接文字列に変換できる値のいずれかとして属性値を扱う処理) がエスケープされます。 代わりに、XAML パーサーが特定のマークアップ拡張の動作を実現するコードを呼び出し、そのコードが XAML パーサーの必要とする代替オブジェクトまたは動作結果を用意します。 マークアップ拡張は引数を取ることができ、引数はマークアップ拡張名に従い、中かっこ内に含めることもできます。 通常、評価されたマークアップ拡張には、オブジェクトの戻り値が用意されています。 解析時に、ソース XAML でマークアップ拡張が使われていたオブジェクト ツリーの位置にその戻り値が挿入されます。

Windows ランタイム XAML は、既定の XAML 名前空間で定義され、Windows ランタイム XAML パーサーが認識できる次のマークアップ拡張をサポートしています。

-   [{{xBind}}](x-bind-markup-extension.md): コンパイル時に生成される特定用途のコードを実行することで、プロパティの評価が実行時まで遅延されるデータ バインディングをサポートします。 このマークアップ拡張は、さまざまな引数をサポートしています。
-   [{{Binding}}](binding-markup-extension.md): 汎用的なランタイム オブジェクト検査を実行することで、プロパティの評価が実行時まで遅延されるデータ バインディングをサポートします。 このマークアップ拡張は、さまざまな引数をサポートしています。
-   [{{StaticResource}}](staticresource-markup-extension.md): [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) で定義されているリソース値の参照をサポートします。 これらのリソースは、異なる XAML ファイルに存在していてもかまいませんが、最終的には読み込み時に XAML パーサーによって検出できる必要があります。 `{StaticResource}` の使用時の引数は、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) 内のキーを持つリソースのキー (名前) を識別します。
-   [{{ThemeResource}}](themeresource-markup-extension.md): [{{StaticResource}}](staticresource-markup-extension.md) と似ていますが、実行時のテーマ変更に応答できます。 {ThemeResource} は、Windows ランタイムの既定の XAML テンプレートによく出現します。これらのテンプレートのほとんどは、アプリの実行中にユーザーがテーマを切り替えた場合に対応できるように設計されているためです。
-   [{{TemplateBinding}}](templatebinding-markup-extension.md): [{{Binding}}](binding-markup-extension.md) の特殊なケースであり、XAML のコントロール テンプレートとその実行時の最終的な使用をサポートします。
-   [{RelativeSource}](relativesource-markup-extension.md): テンプレート化された親に値が由来する特定の形式のテンプレート バインディングを有効にします。
-   [{CustomResource}](customresource-markup-extension.md): 高度なリソース検索のシナリオで使います。

Windows ランタイムは、[{x:Null} マークアップ拡張](x-null-markup-extension.md)もサポートしています。 これは、XAML で [**Nullable**](https://msdn.microsoft.com/library/windows/apps/xaml/b3h38hb0.aspx) 値を **null** に設定するために使われます。 たとえば、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) のコントロール テンプレートでこれを使うと、**null** は不確定なチェック状態として解釈されます ("Indeterminate" 表示状態がトリガーされます)。

一般に、マークアップ拡張では、アプリのオブジェクト グラフの他の部分から既存のインスタンスが返されるか、値が実行時まで保留されます。 マークアップ拡張は属性値として使うことができ、それが一般的な使用方法であるため、マークアップ拡張は多くの場合、マークアップ拡張を使用しなければプロパティ要素構文が必要である参照型のプロパティの値を設定するために使用されます。

たとえば、再利用可能な [**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) を [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) から参照するための構文は、`<Button Style="{StaticResource SearchButtonStyle}"/>` です。 [**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) は参照型であり、単純値ではないため、`{StaticResource}` を使わない場合は、[**FrameworkElement.Style**](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティを設定するために、`<Button.Style>` プロパティ要素と、その中の `<Style>` 定義が必要になります。

マークアップ拡張を使うと、XAML で設定可能なすべてのプロパティを属性構文で設定できるようになる可能性があります。 属性構文でオブジェクトを直接インスタンス化できないプロパティでも、属性構文を使って、プロパティの参照値を指定できます。 つまり、XAML のプロパティに値型または新しく作成した参照型を設定するという通常の要件を延期する特殊な動作を有効にすることができます。

次の XAML の例では、属性構文を使って、[**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) の [**Style**](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティの値を設定します。 [**Style**](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティは、[**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) クラスのインスタンスを受け取ります。このインスタンスは、参照型であるため、既定では属性構文の文字列を使って作成することはできません。 しかし、この例では、属性が [StaticResource](staticresource-markup-extension.md) のマークアップ拡張機能を参照しています。 このマークアップ拡張が処理されると、リソース ディクショナリ内のキーを持つリソースとして既に定義されている **Style** 要素への参照が返されます。

```xml
<Canvas.Resources>
  <Style TargetType="Border" x:Key="PageBackground">
    <Setter Property="BorderBrush" Value="Blue"/>
    <Setter Property="BorderThickness" Value="5"/>
  </Style>
</Canvas.Resources>
...
<Border Style="{StaticResource PageBackground}">
  ...
</Border>
```

マークアップ拡張は、入れ子にすることもできます。 一番内側のマークアップ拡張が最初に評価されます。

マークアップ拡張のため、属性内のリテラル "{" 値には特別な構文が必要です。 詳しくは、「[XAML 構文のガイド](xaml-syntax-guide.md)」をご覧ください。

## <a name="events"></a>イベント

XAML は、オブジェクトとそのプロパティを記述するための宣言型言語ですが、マークアップ内のオブジェクトにイベント ハンドラーをアタッチするための構文も備えています。 XAML イベント構文では、Windows ランタイム プログラミング モデルを利用して、XAML で宣言されたイベントを統合できます。 イベントの名前は、そのイベントが処理されるオブジェクトの属性名として指定します。 属性値には、コードで定義するイベント ハンドラー関数の名前を指定します。 XAML プロセッサはこの名前を使って、読み込まれたオブジェクト ツリーにデリゲート表現を作成し、指定されたハンドラーを内部ハンドラー リストに追加します。 Windows ランタイム アプリの大半は、マークアップ ソースとコード ビハインド ソースの両方によって定義されます。

次に単純な例を示します。 [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) クラスは [**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) という名前のイベントをサポートします。 ユーザーが **Button** をクリックすると呼び出されるコードを実行する **Click** のハンドラーを作成できます。 XAML では、**Click** を **Button** の属性として指定します。 属性値には、ハンドラーのメソッド名である文字列を指定します。

```xml
<Button Click="showUpdatesButton-Click">Show updates</Button>
```

コンパイルの際に、`showUpdatesButton-Click` という名前のメソッドが、コード ビハインド ファイルと、XAML ページの [x:Class](x-class-attribute.md) 値に宣言された名前空間に定義されていることが前提となります。 また、このメソッドは、[**Click**](https://msdn.microsoft.com/library/windows/apps/br227737) イベントのデリゲート コントラクトを満たす必要があります。 例:

```csharp
namespace App1
{
    public sealed partial class MainPage: Page {
        ...
        private void showUpdatesButton_Click (object sender, RoutedEventArgs e) {
            //your code
        }
    }
}
```

```vb
' Namespace included at project level
Public NotInheritable Class MainPage
    Inherits Page
        ...
        Private Sub showUpdatesButton_Click (sender As Object, e As RoutedEventArgs e)
            ' your code
        End Sub
    ...
End Class
```

```cppwinrt
namespace winrt::App1::implementation
{
    struct MainPage : MainPageT<MainPage>
    {
        ...
        void showUpdatesButton_Click(Windows::Foundation::IInspectable const&, Windows::UI::Xaml::RoutedEventArgs const&);
    };
}
```

```cpp
// .h
namespace App1
{
    public ref class MainPage sealed {
        ...
    private:
        void showUpdatesButton_Click(Object^ sender, RoutedEventArgs^ e);
    };
}
```

1 つのプロジェクトの中で、XAML を使って .xaml ファイルが作成され、任意の言語 (C#、Visual Basic、C++/CX) を使って分離コード ファイルが作成されます。 名前空間とクラスを XAML ページのルート要素の [x:Class](x-class-attribute.md) 属性として指定すると、プロジェクトのビルド アクションの一環として XAML ファイルがマークアップ コンパイルされるときに、各 XAML ページの XAML コード ビハインド ファイルの場所が特定されます。 これらの機構がどのように XAML で動作し、プログラミングとアプリケーション モデルにどのように関連するかについての詳しい情報は、「[イベントとルーティング イベントの概要](events-and-routed-events-overview.md)」をご覧ください。

**注**の内容 +/CX がある 2 つのコード ビハインド ファイルは 1 つは、ヘッダー (. xaml.h)、もう一方の実装 (. xaml.cpp)。 実装は、ヘッダーを参照し、コード ビハインド接続用のエントリ ポイントを表す技術的なヘッダーです。

## <a name="resource-dictionaries"></a>リソース ディクショナリ

[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の作成は、通常はリソース ディクショナリを XAML ページの領域または別の XAML ファイルとして記述すれば完了する、一般的なタスクです。 リソース ディクショナリとその使用方法は、概念的に広い範囲にわたるので、このトピックでは扱いません。 詳しくは、「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。

## <a name="xaml-and-xml"></a>XAML と XML

XAML 言語は、基本的に XML 言語に基づいています。 ただし、XAML は XML と比較して大幅に拡張されています。 特にバッキング型の概念に対する関係からスキーマの概念が大きく異なるほか、アタッチされたメンバーやマークアップ拡張などの言語要素が追加されています。 **xml:lang** は XAML で有効ですが、解析動作の際ではなく実行時に作用し、一般的にフレームワーク レベルのプロパティに対するエイリアスが設定されます。 詳しくは、「[**FrameworkElement.Language**](https://msdn.microsoft.com/library/windows/apps/hh702066)」をご覧ください。 **xml:base** はマークアップで有効ですが、パーサーでは無視されます。 **xml:space** は有効ですが、「[XAML と空白](xaml-and-whitespace.md)」で説明されているシナリオ以外では使われません。 **encoding** 属性は XAML で有効です。 サポートされているのは UTF-8 エンコードと UTF-16 エンコードだけです。 UTF-32 エンコードはサポートされていません。

###  <a name="case-sensitivity-in-xaml"></a>XAML での大文字と小文字の区別

XAML は、大文字と小文字を区別します。 XAML は XML を基にしているため、XML と同じく大文字と小文字が区別されます。 XAML 要素と属性の名前では、大文字と小文字が区別されます。 属性の値は、場合によって大文字と小文字が区別されます。これは、特定のプロパティに対して属性値がどのように処理されるかによって決まります。 たとえば、属性値で列挙型のメンバー名が宣言されている場合、その列挙型メンバーの値を返すためにメンバー名文字列を型変換する組み込みの動作では、大文字と小文字は区別されません。 一方、**Name** プロパティの値と、**Name** プロパティで宣言した名前に基づきオブジェクトを操作するユーティリティ メソッドでは、名前の文字列の大文字と小文字が区別されます。

## <a name="xaml-namescopes"></a>XAML 名前スコープ

XAML 言語では、XAML 名前スコープという概念が定義されています。 XAML 名前スコープの概念は、XAML 要素に適用された **x:Name** や **Name** の値が XAML プロセッサによってどのように扱われるか (特に名前を一意の識別子として使うスコープ) に影響します。 XAML 名前スコープについては、別のトピックで詳しく説明します。「[XAML 名前スコープ](xaml-namescopes.md)」をご覧ください。

## <a name="the-role-of-xaml-in-the-development-process"></a>開発プロセスでの XAML の役割

XAML は、アプリ開発プロセスにおいて重要な役割を果たします。

-   XAML は、C#、Visual Basic、または C++/CX を使ったプログラミングでアプリの UI と UI 内の要素を宣言するための基本形式です。 一般的には、プロジェクトの 1 つ以上の XAML ファイルが、アプリの初期表示される UI のページ メタファを表します。 また、別の XAML ファイルで、ナビゲーション用 UI のための追加のページを宣言できます。 それ以外の XAML ファイルでは、リソース (テンプレート、スタイルなど) を宣言できます。
-   XAML 形式は、アプリのコントロールや UI に適用されるスタイルとテンプレートを宣言するために使われます。
-   既存のコントロールをテンプレート化する場合や、コントロール パッケージの一部として既定のテンプレートを提供するコントロールを定義する場合などに、スタイルとテンプレートを使います。 スタイルやテンプレートを定義する際には、通常、関連する XAML を、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) をルートとする独立した XAML ファイルとして宣言します。
-   XAML は、アプリの UI を作成し異なるデザイナー アプリ間で UI 設計を交換することを可能にするデザイナー サポートの共通形式です。 たとえば、アプリの XAML を異なる XAML デザイン ツール (またはツール内のデザイン ウィンドウ) の間で交換することができます。
-   XAML で基本的な UI を定義するテクノロジは他にもあります。 Windows ランタイムの XAML は、Windows Presentation Foundation (WPF) XAML や Microsoft Silverlight XAML と関連があり、共有される既定の XAML 名前空間用に同じ URI を使っています。 また、Windows ランタイムの XAML ボキャブラリの多くは、Silverlight や (Silverlight ほどではありませんが) WPF でも使われている XAML-for-UI ボキャブラリと共通しています。 そのため、XAML を使う先行技術のために定義された UI を効率的に移行することができます。
-   XAML で UI の外観を定義し、関連付けられたコード ビハインド ファイルでロジックを定義します。 UI 設計は、コード ビハインドのロジックに変更を加えることなく調整できます。 XAML は、デザイナーと開発者との間のワークフローを単純化します。
-   ビジュアル デザイナーとビジュアル デザイン サーフェイスの高度な機能による XAML 言語のサポートがあるため、XAML では、開発の初期段階での迅速な UI のプロトタイピングが可能になります。

開発プロセスにおける役割によっては、XAML を使う機会がそれほどない場合もあります。 XAML ファイルと対話する度合いは、使っている開発環境、ツールボックスやプロパティ エディターなどの対話型のデザイン環境機能を使っているかどうか、Windows ランタイム アプリの範囲と目的によっても異なります。 それでも、アプリの開発時には、テキスト エディターや XML エディターを使って要素レベルで XAML ファイルの編集を行うこともありえます。 ここに示された情報を理解することで、XAML のテキスト表現や XML 表現を正確に編集できるようになります。さらに、XAML ファイルがツール、マークアップのコンパイル処理、Windows ランタイム アプリのランタイム フェーズによって使われる際に、XAML ファイルの宣言と目的の妥当性を保持することができます。

## <a name="optimize-your-xaml-for-load-performance"></a>読み込みパフォーマンスを向上させるための XAML の最適化

パフォーマンスを向上させるためのベスト プラクティスを使って XAML で UI 要素を定義するためのヒントを次に示します。 これらのヒントの多くは XAML リソースの使用に関するものですが、便宜上、一般的な XAML の概要を示すこのトピックにおいても紹介します。 XAML リソースについて詳しくは、「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。 パフォーマンス向上のヒントについて詳しくは、パフォーマンスに悪影響を及ぼすため避ける必要のある XAML の実例も含めて、「[XAML マークアップの最適化](https://msdn.microsoft.com/library/windows/apps/mt204779)」をご覧ください。

-   XAML で同じ色のブラシをよく使う場合は、その都度名前付きの色を属性値として使う代わりに、[**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/br242962) をリソースとして定義します。
-   複数の UI ページに同じリソースを使う場合は、各ページではなく [**Application.Resources**](https://msdn.microsoft.com/library/windows/apps/br242338) にそのリソースを定義することをお勧めします。 逆に、1 つのページのみでリソースを使う場合は、リソースを **Application.Resources** に定義する代わりに、必要なページだけに定義します。 これは、アプリ設計時の XAML ファクタリングと、XAML 構文解析時のパフォーマンスの両方に有効です。
-   アプリでパッケージ化するリソースについては、使われていないリソース (キーを持つ一方でそれを使うアプリ内に [StaticResource](staticresource-markup-extension.md) 参照がないリソース) がないかどうかを調べます。 これらは、アプリをリリースする前に、XAML から削除します。
-   デザイン リソース ([**MergedDictionaries**](https://msdn.microsoft.com/library/windows/apps/br208801)) を提供する別個の XAML ファイルを使う場合は、その XAML ファイルから使われていないリソースをコメント アウトするか削除することをお勧めします。 複数のアプリで使っている共有 XAML や、すべてのアプリに共通するリソースを提供する共有 XAML がある場合でも、毎回 XAML リソースをパッケージ化するのはアプリであり、そのたびに XAML リソースを読み込む可能性があります。
-   構成に必要ない UI 要素は定義しないでください。可能な限り、既定のコントロール テンプレートを使ってください (既定のテンプレートは読み込み時のパフォーマンスが既にテストされ確認されています)。
-   UI 要素の範囲を超えた描画を避け、[**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) などのコンテナーを使うようにします。 基本的に、同じピクセルを複数回描画しないでください。 過剰な描画とそのテスト方法について詳しくは、[**DebugSettings.IsOverdrawHeatMapEnabled**](https://msdn.microsoft.com/library/windows/apps/hh701823) をご覧ください。
-   [**ListView**](https://msdn.microsoft.com/library/windows/apps/br242878) や [**GridView**](https://msdn.microsoft.com/library/windows/apps/br242705) には既定の項目テンプレートを使います。これらには、リスト項目が多数あるビジュアル ツリーを作成する際に発生するパフォーマンスの問題を解決する特殊な **Presenter** ロジックが用意されています。

## <a name="debugging-xaml"></a>XAML のデバッグ

XAML はマークアップ言語であるため、Microsoft Visual Studio が備えている一般的なデバッグ方法のいくつかは使うことができません。 たとえば、XAML ファイル内にブレークポイントを設定する方法がありません。 ただし、アプリの開発中に、UI 定義や他の XAML マークアップを使って問題のデバッグをサポートできる方法があります。

XAML ファイルに問題がある場合、一般的な結果として、一部のシステムやアプリによって XAML 解析例外がスローされます。 XAML 解析例外が発生した場合は必ず、XAML パーサーによって読み込まれる XAML では、有効なオブジェクト ツリーの作成に失敗します。 たとえば、XAML によってアプリケーションの最初の "ページ" (ルート ビジュアルとして読み込まれます) が表される場合、XAML 解析例外は回復可能ではありません。

XAML は、Visual Studio などの IDE や XAML デザイン サーフェイスのいずれかで編集されることがあります。 Visual Studio では、編集しているときに XAML ソースに対する設計時検証やエラー チェックを行うことができます。 たとえば、誤った属性値を入力したときに、XAML テキスト エディターで "波線" が表示される場合があります。UI 定義の問題を確認するために、XAML コンパイル パスを待機する必要はありません。

アプリを実際に実行したとき、XAML 解析エラーが設計時に検出されていないと、共通言語ランタイム (CLR) によって、[**XamlParseException**](https://msdn.microsoft.com/library/windows/apps/hh673774) として報告されます。 実行時の **XamlParseException** に関する操作について詳しくは、「[C# または Visual Basic での Windows ランタイム アプリの例外処理](https://msdn.microsoft.com/library/windows/apps/dn532194)」をご覧ください。

**注:**、C++ を使用するアプリ +/CX コードは特定[**XamlParseException**](https://msdn.microsoft.com/library/windows/apps/hh673774)を取得しないでください。 ただし、例外のメッセージによって、エラーの原因が XAML 関連であることが明らかになります。このメッセージには、**XamlParseException** と同様に、XAML ファイル内の行番号などのコンテキスト情報も含まれています。

Windows ランタイム アプリのデバッグについて詳しくは、「[デバッグ セッションの開始](https://msdn.microsoft.com/library/windows/apps/xaml/hh781607.aspx)」をご覧ください。