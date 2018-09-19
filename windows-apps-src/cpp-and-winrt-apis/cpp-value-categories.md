---
author: stevewhims
description: このトピックでは、C++ での値のさまざまなカテゴリについて説明します。 左辺値と rvalue の音が間違いされますが、すぎる他の種類。
title: 値のカテゴリとへの参照
ms.author: stwhi
ms.date: 08/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、移動、転送、値のカテゴリ、移動セマンティクス、完全転送、左辺、右辺値、glvalue、prvalue、xvalue フラグ
ms.localizationpriority: medium
ms.openlocfilehash: cbccaf78b45d85d93619977d149431c4eec9e10a
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4058044"
---
# <a name="value-categories-and-references-to-them"></a>値のカテゴリとへの参照
このトピックでは、C++ で存在するさまざまなカテゴリの値 (および値への参照) について説明します。 *左辺値*と*rvalue*の音が間違いされますが、このトピックでは条件でそれらのない考え。 すぎるは、値の他の種類があります。

C++ ですべての式では、このトピックで説明されているカテゴリのいずれかに属している値が存在します。 C++ 言語、facilies、およびこれらの値のカテゴリとへの参照の適切な理解を要求する規則の側面があります。 たとえば、値、値をコピー、移動、値および別の関数に値を転送のアドレスを考慮できます。 このトピックでは、すべての詳細、それらの側面に送られませんが、それらの単色についての基本的な情報を提供します。

このトピックの情報は、id と movability [Stroustrup 2013] の 2 つの独立したプロパティで値のカテゴリの Stroustrup の分析の観点から囲まれています。

## <a name="an-lvalue-has-identity"></a>左辺が識別情報
*Id*の値に何を意味しますか。 (または場合かかることができます) の値のメモリ アドレスし、値がある識別し、安全に使用します。 これによりを行う比較を超える値の内容: 比較または id で区別することができます。

*左辺値*では、ユーザーがあります。 「左辺値」の"l"が「左」(と同様、left-hand 側の割り当て) の省略形である履歴のみ関心のある問題です。 C++ では、左辺左上 *、または*割り当ての右側に表示されます。 「左辺値」の"l"し、しない実際にするために役立ちます理解もは何かを定義します。 操作が起きると呼ばれるが id を持つ値であることを理解する場合にのみ必要があります。

左辺値の式の例: 名前付き変数または定数です。または、参照を返す関数。 *いない*左辺値の式の例: 一時的なです。または、値を返す関数。

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    std::vector<byte> vec{ 99, 98, 97 };
    std::vector<byte>* addr1{ &vec }; // ok: vec is an lvalue.
    int* addr2{ &get_by_ref() }; // ok: get_by_ref() is an lvalue.

    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is not an lvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is not an lvalue.
}
```

これで、true を指定するステートメントですが、その左辺値には、取得を行うための id が存在します。 さらに詳しくどのような*xvalue フラグ*は、このトピックで後ほど説明します。 ここでは、単に注意してください glvalue、「左辺して汎用化」と呼ばれる値のカテゴリがあることです。 Glvalues のスーパー セットには、左辺値 (*古代左辺値*とも呼ばれます) と取得の両方が含まれています。 中にそのため、「左辺値は、id を持って」true の場合、次の図に示すように id を持つ作業の完全なセットは、glvalues のセットです。

![左辺が識別情報](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a>右辺値が移動します。左辺でないです。
Glvalues ではない値があります。 したがって、これには (またはを有効にすることに依存することはできません) のメモリ アドレスを取得する*ことはできません*が、値があります。 上記のコード例ではこのようないくつかの値をしました。 欠点が聞こえます。 実際には値の利点は、つまり (これは一般に安価) そこからの*移動*ではなく (これは一般に負荷の高い) からコピーできます。 値からの移行は、それが、場所にするために使用しなくなったことを意味します。 そのためにするために使用する場所にアクセスしようとする必要が回避されます。 タイミングと*方法*値は、このトピックの範囲外に移動するのについて説明します。 このトピックのだけを移動する値が*右辺値*(または*古代右辺値*) と呼ばれることを知る必要があります。

「右辺値」の"r"では、「権利」(と同様、右-hand 側の割り当て) の省略形です。 ただし、rvalue と割り当ての外部の rvalue への参照を使用することができます。 "Rvalue"の"r"に集中することを次はありません。 右辺値と呼ばれるが移動する値であることを理解する場合にのみ必要があります。

次の図に示すように、左辺は逆に、移動はありません。 移動操作が起きると*左辺*での定義の対立するものし、予期しない左辺へのアクセスを続けることが合理的に非常に想定されているコードについては問題になります。

![右辺値が移動します。左辺でないです。](images/is-movable.png)

左辺を移動することはできません。 あります*が*移動できる glvalue (id を使ったモ ノのセット) の種類&mdash;何をしていることがわかっている場合 (など、移動後アクセスにしないように注意してください)&mdash;、xvalue フラグです。 この概念をもう一度、下の値のカテゴリの全体像を見てときします再度使用します。

## <a name="rvalue-references-and-reference-binding-rules"></a>右辺値への参照と参照バインド規則
このセクションでは、右辺値への参照の構文について説明します。 別のトピックに移動し、転送の大幅な処理を待機する必要がありますが、これらは右辺値への参照によって解決の問題。 右辺値への参照を見ると、前に、最初にする必要が明確になる`T&`&mdash;ことおした旧されてを呼び出すだけ「参照」です。 実際には「左辺値 (非 const) 参照」を指定する参照のユーザーを書き込むことができます () の値を参照します。

```cppwinrt
template<typename T> T& get_by_lvalue_ref() { ... } // Get by lvalue (non-const) reference.
template<typename T> void set_by_lvalue_ref(T&) { ... } // Set by lvalue (non-const) reference.
```

左辺参照は、右辺値ではなく、左辺値にバインドできます。

左辺 const 参照し、(`T const&`)、*できない*リファレンスのユーザーが (たとえば、定数) 書き込むオブジェクトを参照します。

```cppwinrt
template<typename T> T const& get_by_lvalue_cref() { ... } // Get by lvalue const reference.
template<typename T> void set_by_lvalue_cref(T const&) { ... } // Set by lvalue const reference.
```

左辺 const 参照は、左辺または右辺値にバインドします。

型の右辺値への参照の構文`T`として記述`T&&`します。 右辺値参照が移動可能な値を参照&mdash;、値の内容が (たとえば、一時) が使用した後に保持する必要はありません。 ポイント全体以降から移動する (変更できるため) 値にバインドされて、右辺値参照`const`と`volatile`右辺値への参照に修飾子 (cv 修飾子のとも呼ばれます) は適用されません。

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

右辺値参照は、右辺値にバインドします。 オーバー ロード解決、右辺値*を希望*右辺値への参照よりも左辺 const 参照にバインドされているという点で実際には、 ただし、前述した右辺値参照値を参照します (たとえば、移動コンス トラクターのパラメーター) を維持する必要はありませんと見なされますの内容があるために、右辺値参照が左辺値にバインドできません。

渡すこともできます右辺値引数の値では、予期されているところコピー コンス トラクターを介して (または、右辺値が、xvalue フラグである場合は、ムーブ構築経由で)。

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a>Glvalue がの id。prvalue しません。
この段階では、ユーザーがどのようながわかっています。 移動とそうでないことが確認します。 まだおまだ名前付きの値のセットで id を持つ*しないでください*。 そのセットは、 *prvalue*、または*純粋な右辺値*と呼ばれます。

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is a prvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is a prvalue.
}
```

![左辺がの id。prvalue しません。](images/has-identity2.png)

## <a name="the-complete-picture-of-value-categories"></a>値のカテゴリの完全な画像
情報と上の図に、1 つの大きな画像を組み合わせるのみは変わりません。

![値のカテゴリの完全な画像](images/value-categories.png)

### <a name="glvalue-i"></a>glvalue (i)
Glvalue (汎用左辺値) は、id を持っています。

### <a name="lvalue-im"></a>左辺値 (i\ & \!m)
左辺 (glvalue の種類) では、id しますが、移動はありません。 これらは、通常の読み取り/書き込み値を渡して周囲参照または const 参照、または値のコピーが低い場合です。 左辺値にバインド右辺値参照することはできません。

### <a name="xvalue-im"></a>xvalue フラグ (i\ & m)
(Glvalue の種類も右辺値の種類)、xvalue フラグ id がありも移動します。 これのコピーは、コストがかかるために、移動しようとしたされる操作が起きる可能性があり、後にアクセスしないように注意することができます。 以下に、xvalue フラグに左辺を有効にする方法を示します。

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

上記のコード例では移動していない何もまだします。 Xvalue フラグだけをキャスト左辺右辺値の名前のない参照を作成しました。 左辺名によっても識別できます。として、xvalue フラグ、ことが*できる*移動中のします。 これを行うためには、上の理由から、次のように、実際にどのような移動別のトピックを待機する必要があります。 ただし、意味"エキスパート専用として"するのに役立つ場合は、「xvalue フラグ」の"x"を考えることができます。 左辺をキャスト、xvalue フラグ (右辺値の種類) に、値は、右辺値参照にバインドされていることになります。

ここでは、取得およびその他の 2 つの例&mdash;参照を指定する名前のない右辺値を返す関数を呼び出すと、xvalue フラグのメンバーにアクセスします。

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a>prvalue (\!i\ & m)
(純粋な右辺値、右辺値の種類) の prvalue id ではありませんが、移動します。 これらは、一時領域では通常、関数の呼び出しの結果を返します。 値、または、glvalue でないその他の式を評価した結果によって

### <a name="rvalue-m"></a>右辺値 (分)
右辺値が移動します。 右辺値*の参照*は、常に右辺値 (値と見なされます内容を維持する必要はありません) を参照します。

ただし、右辺値を右辺値参照自体にはかどうか。 (上記 xvalue フラグのコード例に示されている) のような*名前のない*の右辺値の参照が、xvalue フラグはいは、その右辺値。 移動コンス トラクターのなど、右辺値の参照を関数パラメーターにバインドされていることを優先します。 逆に、おそらく counter-intuitively) 右辺値参照が、名前を持つ場合は、その名前で構成される式左辺します。 したがって、右辺値参照パラメーターにバインド*できません*。 簡単に行うことが&mdash;だけにキャスト右辺値の名前のないリファレンス (xvalue フラグ) もう一度します。

```cppwinrt
void foo(A&) { ... }
void foo(A&&) { ... }
void bar(A&& a) // a is a named rvalue reference; it's an lvalue.
{
    foo(a); // Calls foo(A&).
    foo(static_cast<A&&>(a)); // Calls foo(A&&).
}
A&& get_by_rvalue_ref() { ... } // This unnamed rvalue reference is an xvalue.
```

### <a name="im"></a>\!i\ & \!m
識別していないし、移動がない値の種類には、まだ説明していない 1 つの組み合わせです。 ただし、そのカテゴリの C++ 言語で便利なアイデアがないため、無視します。

## <a name="reference-collapsing-rules"></a>規則の参照を折りたたんだり
式 (参照を指定する左辺値への参照を左辺または右辺値リファレンスへの参照を右辺値) に複数の like 参照は 1 つ別アウトをキャンセルします。

- `A& &` 折りたたまれます`A&`します。
- `A&& &&` 折りたたまれます`A&&`します。

数式で参照とは異なり、複数左辺参照に折りたたまれます。

- `A& &&` 折りたたまれます`A&`します。
- `A&& &` 折りたたまれます`A&`します。

## <a name="forwarding-references"></a>転送への参照
この最後のセクションでは、右辺値の参照は、既に述べた、*転送リファレンス*のさまざまな概念と対照的です。

```cppwinrt
void foo(A&& a) { ... }
```

- `A&&` 説明したように、参照を指定する右辺値です。 Const と揮発性は、右辺値への参照には適用されません。
- `foo` type **A**の rvalue のみを受け取ります。
- 理由右辺値の参照 (次のように`A&&`) が存在渡される一時的な (またはその他の右辺値) の場合に最適なオーバー ロードを作成するためです。

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- `_Ty&&` *参照を転送*です。 渡すことによって`bar`、種類 **_Ty**は const/非 const 揮発性/非揮発性とは別である可能性があります。
- `bar` 任意の左辺値または型 **_Ty**の右辺値を受け入れます。
- 転送参照になる左辺値を渡すと、 `_Ty& &&`、左辺値の参照を解除する`_Ty&`します。
- 転送参照になる右辺値を渡すと、 `_Ty&& &&`、右辺値の参照を解除する`_Ty&&`します。
- 参照を転送する理由 (次のように`_Ty&&`) が存在が*ない*の最適化が何を渡すには、それらと効率的かつ透過的に転送します。 転送の参照に書き込み、または調査と見つかる) ライブラリのコードである場合にのみ発生する可能性が高い&mdash;たとえば、コンス トラクターの引数を転送ファクトリ関数です。

## <a name="sources"></a>Sources
* \[Stroustrup, 2013\] ある Stroustrup: C++ プログラミング言語、4 番目のエディション。 ◆ センター。 2013 します。
