---
description: このトピックでは、C++ に存在する値のさまざまなカテゴリについて説明します。 lvalues と rvalues については聞いたことがあると思いますが、それ以外の種類もあります。
title: 値のカテゴリ、およびそれらへの参照
ms.date: 08/11/2018
ms.topic: article
keywords: windows 10、uwp、standard、c++、cpp、winrt、プロジェクション、移動、転送、値のカテゴリ、移動セマンティクス、完全転送、左辺値、右辺値、glvalue、prvalue、xvalue
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 1860f562233ceefa6d9ebb3741378b3265b4c3a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593017"
---
# <a name="value-categories-and-references-to-them"></a>値のカテゴリ、およびそれらへの参照
このトピックでは、C++ に存在する値 (および値への参照) のさまざまなカテゴリについて説明します。 音が悪くなります*左辺値*と*rvalue*、このトピックで条件のうちいない考えが。 すぎるは、値の他の種類があります。

C++ では、すべての式では、このトピックで説明したカテゴリのいずれかに属している値を生成します。 C++ 言語、その facilies、およびこれらの値のカテゴリ、およびそれらへの参照の適切な理解を必要とするルールの側面があります。 たとえば、値、値をコピーする、値の移動、および別の関数に値を転送のアドレスを取得します。 このトピックでは、すべての防御、これらの側面に移動しないが、それらの理解の基本的な情報を提供します。

このトピックの情報は、id と movability [Stroustrup 2013] の 2 つの独立したプロパティで値のカテゴリの Stroustrup の分析の観点から囲まれています。

## <a name="an-lvalue-has-identity"></a>左辺値は id を持っています
これはどういうの値に*identity*でしょうか。 値のメモリ アドレスがある (またはを実行できます) し、値がある識別し、安全に使用します。 これにより、行うことができます比較より値の内容: 比較または id によって区別できます。

*左辺値*id を持ちます。 今すぐ「左辺値」の"l"は、(ように、左側の hand 側を代入式の)、"left"の省略形を履歴にのみ関心のある問題です。 C++ では、左辺値が左側に表示できる*または*を代入式の右側にします。 「左辺値」の"l"し、実際に問題が解決しない理解もは何かを定義します。 Id を持つ値が左辺値と呼ばれるものであるかを理解するだけを指定する必要があります。

左辺値である式の例に示します: 名前付きの変数または定数。または、参照を返す関数。 式の例*いない*左辺値が含まれます: 一時的な; または値を返す関数。

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

ここで、左辺値が id を持っている場合は true。 ステートメントは、xvalues はそのためです。 他にどのようなことにしましょう、 *xvalue*はこのトピックで後述します。 ここでは、単に「左辺値を汎用化」の glvalue と呼ばれる値のカテゴリがあることに注意してください。 Glvalues のスーパー セットには、両方とも左辺値が含まれています (とも呼ばれます*古典左辺値*) と xvalues します。 そのため、while true「を左辺値は、id を持って」は、この図のように、id を持つことの完全なセットが、glvalues のセット。

![左辺値は id を持っています](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a>右辺値は移動可能です。左辺値はありません。
Glvalues ではない値があります。 したがって、ある値を*できません*のメモリ アドレスを取得する (またはそれを有効にするのに依存することはできません)。 上記のコード例ではこのようないくつかの値を見ました。 欠点が聞こえます。 実際値の利点などができますが、*移動*から (これは一般的に安価な) ことではなく (これは通常高価な) からコピーします。 値からの移行は場所に配置するために使用されなくを意味します。 そのため、使用場所にアクセスしようとしています。 は回避されます。 タイミングの詳細については、*方法*値は、このトピックではスコープ外に移動します。 このトピックでは、だけが移動可能な値と呼ばれることを知って、*右辺値*(または*古典 rvalue*)。

「右辺値」で"r"は、(ように、右、hand 側を代入式の)、"right"の省略形です。 ただし、右辺値、および割り当ての外部で、右辺値への参照を使用することができます。 「右辺値」で"r"に注目することはありません。 右辺値と呼ばれるものが移動可能である値であることを理解するだけを指定する必要があります。

この図のように、左辺値には逆に、移動可能なはありません。 移動を左辺値の定義を無視は*左辺値*、引き続き、左辺値にアクセスすることができる非常に期待されるコードの予期しない問題があります。

![右辺値は移動可能です。左辺値はありません。](images/is-movable.png)

左辺の値を移動することはできません。 あります*は*移動できる glvalue (一連の id を持つもの) の一種&mdash;何をしていることがわかっている場合 (移動後にアクセスしないように注意するを含む)&mdash;xvalue です。 このアイデアをもう 1 回、下の値のカテゴリの全体像に注目すると再度使用します。

## <a name="rvalue-references-and-reference-binding-rules"></a>右辺値参照、および参照バインディング規則
このセクションでは、rvalue への参照の構文について説明します。 私たちは別のトピックに移動し、転送の大幅な処理を待機する必要がありますは右辺値参照を解決できる問題。 右辺値参照を見ると、前に、まず必要があります明確になる`T&`&mdash;ことした以前されて呼び出しだけ「参照」。 本当に"を (非定数) を左辺値参照されて"、これは、値を参照のユーザーが書き込むことができます。

```cppwinrt
template<typename T> T& get_by_lvalue_ref() { ... } // Get by lvalue (non-const) reference.
template<typename T> void set_by_lvalue_ref(T&) { ... } // Set by lvalue (non-const) reference.
```

左辺値参照は、右辺値ではなくに左辺値にバインドできます。

左辺値の const 参照が存在し、(`T const&`)、参照先オブジェクトに参照のユーザー*ことはできません*書き込み (たとえば、定数)。

```cppwinrt
template<typename T> T const& get_by_lvalue_cref() { ... } // Get by lvalue const reference.
template<typename T> void set_by_lvalue_cref(T const&) { ... } // Set by lvalue const reference.
```

Const の左辺値参照には、左辺値または右辺値をバインドできます。

型の rvalue への参照の構文は、`T`として書き込まれる`T&&`します。 移動可能な値を右辺値参照が参照&mdash;値を内容を後に使用した (たとえば、一時的な) を保持する必要はありません。 全体のポイント以降から移動する (これにより変更)、値にバインドされて、右辺値参照`const`と`volatile`修飾子 (cv 修飾子のとも呼ばれます) は、右辺値参照に適用されません。

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

右辺値参照は、右辺値にバインドします。 オーバー ロードの解決、右辺値の観点から実際には、*希望*より const の左辺値参照への右辺値参照にバインドします。 参照しているため、ように、右辺値参照の値には (たとえば、移動コンス トラクターのパラメーター) を保持するために不要と見なされますの内容が、右辺値参照が左辺値にバインドできません。

渡すこともできます右辺値渡しで引数が必要な場合、コピー コンス トラクターを使用して (または移動の構築、右辺値が、xvalue 場合)。

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a>Glvalue が identity です。prvalue はありません。
この段階では、id を持って何がわかっています。 移動可能な新機能とサポートされない内容がわかります。 いないまだという名前の値のセットですが、*しない*id が存在します。 セットと呼ばれること、 *prvalue*、または*純粋な右辺値*します。

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is a prvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is a prvalue.
}
```

![左辺が identity です。prvalue はありません。](images/has-identity2.png)

## <a name="the-complete-picture-of-value-categories"></a>値のカテゴリの全体像
情報と、1 つの大きな画像に上記の図を結合するだけのままです。

![値のカテゴリの全体像](images/value-categories.png)

### <a name="glvalue-i"></a>glvalue (i)
Glvalue (一般的な左辺値) は、id を持ちます。

### <a name="lvalue-im"></a>左辺値 (は\&\!m)
左辺値 (glvalue の種類) は id を持つが、移動することはありません。 これらは、通常の読み取り/書き込み値を渡して周囲参照または定数の参照または値のコピーは安価な場合です。 左辺値は、右辺値参照にバインドできません。

### <a name="xvalue-im"></a>xvalue (は\&m)
(ある種の glvalue、ただしも、ある種の右辺値)、xvalue は id を持つ、移動することもできます。 転がって左辺値をコピーすることは高価であるために移動することが考えられますされ、その後アクセスしないように注意ができます。 次に、xvalue に左辺を有効にする方法を示します。

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

上記のコード例で移動していない何もまだします。 名前のない右辺値参照に左辺をキャストすることによって、xvalue 先ほど作成しました。 左辺値名によってまだ識別できます。の xvalue に今すぐ*対応*移動されるのです。 そのため、上の理由から、次のように、実際にどのような移動の別のトピックを待機する必要があります。 "X"で"xvalue"意味「エキスパート専用」に役立つ場合として考えることができます。 (右辺値の種類)、xvalue に左辺をキャストすることによって、値は、右辺値参照にバインドされていることになります。

Xvalues の他の 2 つの例をここでは&mdash;名前のない右辺値参照を返す関数を呼び出すと、xvalue のメンバーにアクセスします。

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a>prvalue (\!は\&m)
(純粋な右辺値はある種の右辺値) の prvalue では、id はありませんが、移動します。 これらの一時要素は通常、値、または、glvalue ではないその他の式の評価の結果によって関数の呼び出しの結果が返されます

### <a name="rvalue-m"></a>右辺値 (m)
右辺値は、移動可能です。 右辺*参照*常に右辺値 (値を保持する必要がありますしない内容と見なされます) を参照します。

右辺値参照自体を右辺値では。 *名前のない*(上記の xvalue コード例に示すもの) のような右辺値参照は、xvalue、はい、これは、右辺値です。 移動コンス トラクターなど、右辺値参照を関数パラメーターにバインドするが優先されます。 逆に、おそらく counter-intuitively)、右辺値参照は、名前を持つかどうかは、その名前で構成される式は左辺値です。 したがって、*ことはできません*右辺値参照パラメーターにバインドします。 それは簡単に行うことが&mdash;だけ再キャスト (xvalue、) の名前のない右辺値参照にします。

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

### <a name="im"></a>\!\&\!m
Id がないし、サポートされない移動可能な値の種類は、まだ説明していない 1 つの組み合わせです。 そのカテゴリには、C++ 言語で便利な考え方がないため、無視しました。

## <a name="reference-collapsing-rules"></a>参照縮小規則
(左辺値参照は左辺値参照または右辺値参照を右辺値参照) の式に複数の like 参照は 1 つ別の出力をキャンセルします。

- `A& &` 折りたたまれます`A&`します。
- `A&& &&` 折りたたまれます`A&&`します。

左辺値参照を式内の参照とは異なり、複数を折りたたみます。

- `A& &&` 折りたたまれます`A&`します。
- `A&& &` 折りたたまれます`A&`します。

## <a name="forwarding-references"></a>転送の参照
この最後のセクションでは、右辺値参照は、既に説明したようにのさまざまな概念と対照的です。 を*転送参照*します。

```cppwinrt
void foo(A&& a) { ... }
```

- `A&&` 前述したように、右辺値参照は、します。 Const と揮発性は、右辺値参照に適用されません。
- `foo` 型の右辺値のみを受け入れる**A**します。
- 理由の右辺値参照 (など`A&&`) 存在が渡される、一時的な (またはその他の右辺値) のケース用に最適化されたオーバー ロードを作成するようにします。

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- `_Ty&&` *転送参照*します。 渡すに応じて`bar`、型 **_Ty** const/非 const volatile/非 volatile とは無関係に可能性があります。
- `bar` 任意の左辺値または右辺値の型を受け入れる **_Ty**します。
- なる転送先の参照を左辺値を渡すと`_Ty& &&`、左辺値参照を解除する`_Ty&`します。
- なる転送先の参照を右辺値を渡すと`_Ty&& &&`、右辺値参照を解除する`_Ty&&`します。
- 参照を転送する理由 (など`_Ty&&`) 存在が*いない*最適化が何を渡すを実行して透過的かつ効率的に転送するようにします。 書き込み、または密接に調査) ライブラリのコードの場合にのみ転送の参照が発生する可能性が高いしたら&mdash;コンス トラクター引数では転送、factory 関数などです。

## <a name="sources"></a>Sources
* \[Stroustrup、2013\] B. Stroustrup:C++ プログラミング言語で、Fourth Edition。 Addison-Wesley. 2013。
