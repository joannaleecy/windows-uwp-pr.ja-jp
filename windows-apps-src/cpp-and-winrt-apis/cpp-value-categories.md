---
author: stevewhims
description: このトピックでは、C++ で存在する値のさまざまなカテゴリについて説明します。 左辺値と rvalue の音がわかりが、その他の種類すぎます。
title: 値のカテゴリとへの参照
ms.author: stwhi
ms.date: 08/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、移動、転送、値のカテゴリ、移動の形式、完全転送、左辺、右辺値、glvalue、prvalue、xvalue フラグ
ms.localizationpriority: medium
ms.openlocfilehash: cbccaf78b45d85d93619977d149431c4eec9e10a
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5165231"
---
# <a name="value-categories-and-references-to-them"></a>値のカテゴリとへの参照
このトピックでは、C++ で存在するさまざまなカテゴリの値 (および値への参照) について説明します。 *左辺値*と*rvalue*の音がわかりが、このトピックでは条件でそれらのない考えです。 すぎるは、値の他の種類があります。

C++ ですべての式では、このトピックで説明されているカテゴリのいずれかに属している値が存在します。 C++ 言語、facilies、およびこれらの値のカテゴリとへの参照の適切な理解を要求するルールの側面があります。 たとえば、値、値をコピーし、値を移動および、別の関数に値を転送のアドレスを取得します。 このトピックでは、すべての詳細、それらの側面に送られませんが、それらの単色についての基本的な情報を提供します。

このトピックの情報は、id と movability [Stroustrup、2013] の 2 つの独立したプロパティで値のカテゴリの Stroustrup の分析の観点から囲まれています。

## <a name="an-lvalue-has-identity"></a>左辺が識別情報
*Id*の値に何を意味しますか。 値のメモリ アドレスがある (または実行できる) 場合、値がある識別し、安全に使用します。 これによりを行う比較を超える値の内容: id で区別またはと比較することができます。

*左辺値*は、id を持っています。 これは、「左辺値」の"l"が「左」(と同様、left-hand 側の割り当て) の省略形履歴のみ関心のある問題ではできるようになりました。 C++ では、左辺左上*または*割り当ての右側に表示されます。 「左辺値」、"l"し、実際にうまくいかない理解し、は何かを定義します。 操作が起きると呼ばれるものが id を持つ値であることを理解する場合にのみ必要があります。

左辺値の式の例: 名前付き変数または定数です。または、参照を返す関数。 左辺値では*ありません*が、式の例: 一時的なです。または、値を返す関数。

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

次に、true を指定するステートメントですが、その左辺値には、取得を行うための id が存在します。 どのような*xvalue フラグ*は、このトピックで後にしましょう。 ここでは、だけにする glvalue、「左辺して汎用化」と呼ばれる値のカテゴリがあることに注意してください。 Glvalues のスーパー セットには、左辺値 (*古代左辺値*とも呼ばれます) と取得の両方が含まれています。 そのため、中「左辺値は、id を持って」は、次の図に示すように、id を持つことの完全なセットが glvalues のセット。

![左辺が識別情報](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a>右辺値が移動します。左辺でないです。
Glvalues 以外の値があります。 したがって、これには値がのメモリ アドレスを取得する*ことはできません*が、(またはを有効にすることに依存することはできません) があります。 上記のコード例ではこのようないくつかの値を確認します。 欠点が聞こえます。 実際には、値を活用できます (これは一般に安価) ことから*移動*をはなどのではなく (これは一般に負荷の高い) からコピーします。 値からの移行は、それがするために使用する場所にしなくなったことを意味します。 そのためにするために使用する場所にアクセスしようとする必要が回避します。 タイミングと*方法*値は、このトピックのスコープ外に移動するのについて説明します。 このトピックのだけを移動する値が*右辺値*(または*従来の右辺値*) と呼ばれることを知る必要があります。

「右辺値」の"r"では、「権利」(と同様、右-hand 側の割り当て) の省略形です。 ただし、rvalue と割り当ての外部の rvalue への参照を使用することができます。 "Rvalue"の"r"に集中することを次はありません。 右辺値と呼ばれるものが移動する値であることを理解する場合にのみ必要があります。

次の図に示すように、左辺は逆に、移動はありません。 移動操作が起きると*左辺値*の定義の対立するものし、非常に合理的左辺へのアクセスを続けることが想定されているコードの予期しない問題になります。

![右辺値が移動します。左辺でないです。](images/is-movable.png)

左辺を移動することはできません。 あります*が*種類移動できる glvalue (の id を使って点のセット) の&mdash;何をしていることがわかっている場合 (など、移動後アクセスにしないように注意してください)&mdash;、xvalue フラグがあるとします。 この概念をもう一度、下の値のカテゴリの全体像を見てときします再度使用します。

## <a name="rvalue-references-and-reference-binding-rules"></a>右辺値への参照と参照バインド規則
このセクションでは、右辺値への参照の構文について説明します。 移動し、転送の大幅な処理を別のトピックを待機する必要がありますが、これらは右辺値への参照によって解決の問題。 右辺値への参照を見ると、前に、最初にする必要が明確になる`T&`&mdash;ことおした旧されてを呼び出すだけ「参照」。 実際には「左辺値 (非 const) 参照」を指定する参照のユーザーに書き込むことができます () の値を参照します。

```cppwinrt
template<typename T> T& get_by_lvalue_ref() { ... } // Get by lvalue (non-const) reference.
template<typename T> void set_by_lvalue_ref(T&) { ... } // Set by lvalue (non-const) reference.
```

左辺参照は、右辺値ではなく、左辺値にバインドできます。

左辺 const 参照し、(`T const&`)、(たとえば、定数)*ことはできません*リファレンスのユーザーを記述するオブジェクトを参照します。

```cppwinrt
template<typename T> T const& get_by_lvalue_cref() { ... } // Get by lvalue const reference.
template<typename T> void set_by_lvalue_cref(T const&) { ... } // Set by lvalue const reference.
```

左辺 const 参照は、左辺または右辺値にバインドします。

型の右辺値への参照の構文`T`として記述`T&&`します。 右辺値参照が移動可能な値を参照&mdash;、値の内容が、(たとえば、一時的な) を使用して後を維持する必要はありません。 ポイント全体からから移動する (変更できるため)、値にバインドされて右辺値参照を指定する`const`と`volatile`右辺値への参照に修飾子 (cv 修飾子のとも呼ばれます) は適用されません。

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

右辺値参照は、右辺値にバインドします。 オーバー ロードの解像度、右辺値*を希望*右辺値への参照よりも左辺 const 参照にバインドされているという点で実際には。 前述した右辺値参照値を参照します (たとえば、移動コンス トラクターのパラメーター) を保持する必要はありませんと見なされますの内容があるために、右辺値参照が左辺にバインドできません。

渡すこともできます右辺値引数の値では、必要な場所コピー コンス トラクターを介して (または、右辺値が、xvalue フラグの場合、移動構築経由で)。

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a>Glvalue がの id。prvalue しません。
この段階では、id を持って何がわかっています。 移動とそうでないことが確認します。 していないまだ名前付きの値のセットで id を持つ*しないでください*。 そのセットは、 *prvalue*、または*純粋な右辺値*と呼ばれます。

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
情報と、1 つの大きな画像上の図を組み合わせることのみが残っています。

![値のカテゴリの完全な画像](images/value-categories.png)

### <a name="glvalue-i"></a>glvalue (i)
Glvalue (汎用左辺値) は、id を持っています。

### <a name="lvalue-im"></a>左辺値 (i\ & \!m)
左辺 (glvalue の種類) では、id しますが、移動はありません。 これらは、通常の読み取り/書き込み値を渡しての周囲の参照または const 参照、または値のコピーが低い場合です。 左辺値にバインド右辺値参照することはできません。

### <a name="xvalue-im"></a>xvalue フラグ (i\ & m)
(Glvalue の種類も右辺値の種類)、xvalue フラグ id がありも移動します。 コピーは、コストがかかるために、移動しようとしたされる操作が起きる場合もあり、後にアクセスしないように注意することができます。 次に、xvalue フラグに左辺を有効にする方法を示します。

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

上記のコード例では移動していない何もまだします。 Xvalue フラグだけをキャスト左辺右辺値の名前のない参照を作成しました。 まだ左辺名によって識別できます。xvalue フラグ、としてことが*できる*移動しています。 これを行うためには、上の理由から、次のように、実際にどのような移動別のトピックを待機する必要があります。 ただし、意味"エキスパート専用として"できる場合は、「xvalue フラグ」の"x"を考えることができます。 左辺をキャスト、xvalue フラグ (右辺値の種類) に、値は、右辺値参照にバインドされていることになります。

ここでは、取得およびその他の 2 つの例&mdash;参照を指定する名前のない右辺値を返す関数を呼び出すと、xvalue フラグのメンバーにアクセスします。

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a>prvalue (\!i\ & m)
(純粋な右辺値、右辺値の種類) の prvalue では、id ではありませんが、移動します。 これらは、一時領域では通常、関数の呼び出しの結果を返します。 値、または、glvalue でないその他の式を評価した結果によって

### <a name="rvalue-m"></a>右辺値 (分)
右辺値が移動します。 右辺値*の参照*は、常に右辺値 (値と見なされます内容を維持する必要はありません) を参照します。

ただし、右辺値を右辺値参照自体にはかどうか。 (上記 xvalue フラグのコード例に示されている) のような*名前のない*の右辺値の参照が、xvalue フラグはいは、その右辺値。 移動コンス トラクターのなど、右辺値の参照関数パラメーターにバインドされていることを優先します。 逆に、おそらく counter-intuitively) 右辺値参照が、名前を持つ場合は、その名前で構成される式左辺します。 したがって、右辺値の参照パラメーターにバインドする*ことはできません*。 これを行うようにする簡単なが&mdash;だけにキャスト右辺値の名前のないリファレンス (xvalue フラグ) もう一度します。

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
識別していないし、移動がない値の種類は、まだ説明していない 1 つの組み合わせです。 ただし、そのカテゴリの C++ 言語で便利なアイデアがないため、無視します。

## <a name="reference-collapsing-rules"></a>[規則の参照を折りたたんだり
(参照を指定する左辺値への参照を左辺値または右辺値リファレンスへの参照を右辺値) の式に複数の like 参照は 1 つ別アウトをキャンセルします。

- `A& &` 折りたたまれます`A&`します。
- `A&& &&` 折りたたまれます`A&&`します。

数式で参照とは異なり複数左辺参照に折りたたまれます。

- `A& &&` 折りたたまれます`A&`します。
- `A&& &` 折りたたまれます`A&`します。

## <a name="forwarding-references"></a>転送への参照
この最後のセクションでは、右辺値の参照は、既に述べた、*参照を転送*のさまざまな概念と対照的です。

```cppwinrt
void foo(A&& a) { ... }
```

- `A&&` 参照を指定する右辺値は、説明したようにはします。 Const と揮発性は、右辺値への参照には適用されません。
- `foo` **入力**の rvalue のみを受け取ります。
- 理由右辺値の参照 (次のように`A&&`) が存在渡される、一時的な (またはその他の右辺値) の場合に最適なオーバー ロードを作成するためです。

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- `_Ty&&` *参照を転送*です。 渡すことによって`bar`、種類 **_Ty**は const/非 const 揮発性/非揮発性とは別である可能性があります。
- `bar` 任意の左辺値または型 **_Ty**の右辺値を受け入れます。
- なるへの参照を転送左辺値を渡すと、 `_Ty& &&`、左辺値の参照を解除する`_Ty&`します。
- なるへの参照を転送右辺値を渡すと、 `_Ty&& &&`、右辺値の参照を解除する`_Ty&&`します。
- 参照を転送する理由 (次のように`_Ty&&`) が存在は*いない*最適化の内容を渡すには、それらがし効率的かつ透過的に転送します。 書き込み、または調査と見つかる) ライブラリのコードの場合にのみ転送の参照が発生する可能性が高い&mdash;たとえば、コンス トラクターの引数を転送ファクトリ関数です。

## <a name="sources"></a>Sources
* \[Stroustrup、2013\] ある Stroustrup: C++ プログラミング言語、4 番目のエディション。 ◆ センター。 2013 します。
