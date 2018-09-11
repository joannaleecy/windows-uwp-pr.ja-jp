---
author: stevewhims
description: このトピックでは、C++ での値のさまざまなカテゴリを説明します。 左辺値と rvalue の音が間違いがも他の種類があります。
title: 値のカテゴリとへの参照
ms.author: stwhi
ms.date: 08/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、移動、転送、値のカテゴリ、移動セマンティクス、完全転送、左辺、右辺値、glvalue、prvalue、xvalue フラグ
ms.localizationpriority: medium
ms.openlocfilehash: cbccaf78b45d85d93619977d149431c4eec9e10a
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3846206"
---
# <a name="value-categories-and-references-to-them"></a>値のカテゴリとへの参照
このトピックでは、C++ で存在する値 (と値への参照) のさまざまなカテゴリを説明します。 *左辺値*と*rvalue*の音が間違いがいない、このトピックでは条件でそれらの考える可能性があります。 他の種類の値があります。

C++ ですべての式では、このトピックで説明されているカテゴリのいずれかに属している値が存在します。 C++ 言語、その facilies、およびこれらの値のカテゴリとへの参照の適切な理解が要求されるルールの側面があります。 たとえば、値、値をコピー、値を移動し、もう 1 つの関数への値を転送のアドレスを実行します。 このトピックでは、すべての詳細、それらの側面に送られませんが、それらの単色の理解の基本情報を提供します。

このトピックでは、id と movability [Stroustrup 2013] の 2 つの独立したプロパティで値のカテゴリの Stroustrup の分析の観点から囲まれています。

## <a name="an-lvalue-has-identity"></a>左辺が識別情報
*Id*の値に何を意味しますか。 値のメモリ アドレスがある (または実行できる) 場合、値がある識別し、安全に使用します。 これによりを行う比較を超える値の内容: id で区別またはと比較することができます。

*左辺*では、ユーザーがあります。 これは、「左辺値」で"l"が「左」(と同様に、left-hand 側の割り当て) の省略形である履歴のみ関心のある問題ではできるようになりました。 C++ では、左辺値は、左*または*割り当ての右側に表示できます。 「左辺値」、"l"次に、しない実際に確認に役立つ理解し、は何かを定義します。 Id を持つ値は、操作が起きると呼ばれることを理解する場合にのみ必要があります。

左辺値の式の例: 名前付き変数または定数です。または、関数の参照を返します。 左辺値では*ありません*が、数式の例: 一時的なです。または、値を返す関数。

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

次に、true を指定するステートメントですが、その左辺値は取得を行うため、id を持ちます。 どのような*xvalue フラグ*は、このトピックで後にしましょう。 ここでは、だけにする、glvalue「左辺して汎用化」と呼ばれる値カテゴリであることに注意してください。 Glvalues のスーパー セットには、左辺値 (*古代左辺値*とも呼ばれます) と取得の両方が含まれています。 そのため、中「の id を持って左辺」true の場合、次の図に示すように、次の id の完全なセットが glvalues のセットを示します。

![左辺が識別情報](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a>右辺値が移動します。左辺でないです。
ただし glvalues ではない値もあります。 したがって、これには値がのメモリ アドレスを取得する*ことはできません*(またはを有効にすることに依存することはできません) があります。 上記のコード例ではこのようないくつかの値を確認します。 欠点が聞こえます。 しますが実際の値の利点は、つまり (これはコストが安く一般) ことからの*移動*ではなく (これは一般に負荷の高い) からコピーできます。 値から移動すると、それが以前は存在しなくなったことを意味します。 そのため、しようとするために使用する場所にアクセスする必要ことを回避します。 タイミングと*方法*値は、このトピックの範囲外に移動するの説明。 このトピックでは、だけを移動する値が*右辺値*(または*従来の右辺値*) と呼ばれることを知る必要があります。

「右辺値」の"r"では、「直接」(と同様に、右-hand 側の割り当て) の省略形です。 ただし、rvalue と割り当ての外部の rvalue への参照を使用することができます。 "Rvalue"の"r"に集中することを次はありません。 右辺値と呼ばれるが移動する値であることを理解する場合にのみ必要があります。

次の図に示すように、左辺は逆に、移動はありません。 移動操作が起きる場合の*左辺*定義の対立するものし、非常に合理的左辺へのアクセスを続けることが想定されているコードの予期しない問題になります。

![右辺値が移動します。左辺でないです。](images/is-movable.png)

左辺を移動することはできません。 あります*が*種類の移動することができます (の id を使って点のセット) glvalue&mdash;を行っていることがわかっている場合 (などへの移動後アクセスしないように注意してください)&mdash;、xvalue フラグです。 この概念は、もう一度以下、値のカテゴリの全体像を見てときからしますされます。

## <a name="rvalue-references-and-reference-binding-rules"></a>右辺値への参照と参照バインディング規則
このセクションでは、右辺値への参照の構文について説明します。 別のトピックに移動し、転送の大幅な処理を待機する必要がありますが、これらは右辺値への参照によって解決は問題。 右辺値への参照を見ると、前に、まず必要がありますが明確になる`T&`&mdash;ことしますした旧されたを呼び出すだけ「参照」。 実際には「左辺値 (非 const) の参照をする」は、値が参照のユーザーを書き込むことができます。

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

左辺 const の参照は、左辺や右辺値にバインドできます。

型の右辺値への参照の構文`T`として書き込まれる`T&&`します。 移動の値を右辺値の参照が参照&mdash;、値の内容をしないこと (たとえば、一時的な) を使ってきました後を維持する必要があります。 ポイント全体以降はから移動する (変更できるため)、値にバインドされている右辺値参照では、`const`と`volatile`右辺値への参照に修飾子 (cv 修飾子のとも呼ばれます) は適用されません。

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

右辺値の参照は、右辺値にバインドします。 オーバー ロードの解像度、右辺値*方法によって*右辺値への参照よりも、左辺 const 参照にバインドされているという点で実際には。 右辺値の参照が左辺ように説明したように、右辺値の参照値を参照します (たとえば、移動コンス トラクターのパラメーター) を維持する必要はありませんを想定していますの内容があるためにバインドできません。

渡すことも右辺値引数の値では、予期されているところコピー コンス トラクターを介して (または、右辺値が、xvalue フラグである場合は、ムーブ構築)。

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a>Glvalue がの id。prvalue は発生しません。
この段階では、ユーザーが何がわかっています。 移動とそうでないことが確認されます。 まだおまだ id を持つ*しない*という名前の値のセット。 そのセットは、 *prvalue*、または*純粋な右辺値*と呼ばれます。

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is a prvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is a prvalue.
}
```

![左辺がの id。prvalue は発生しません。](images/has-identity2.png)

## <a name="the-complete-picture-of-value-categories"></a>値のカテゴリの完全な画像
情報と上の図に、1 つの大きな画像を組み合わせるのみは変わりません。

![値のカテゴリの完全な画像](images/value-categories.png)

### <a name="glvalue-i"></a>glvalue (i)
Glvalue (汎用左辺) では、ユーザーがあります。

### <a name="lvalue-im"></a>左辺値 (i\ & \!m)
左辺 (glvalue の種類) では、id しますが、移動はありません。 これらは、通常の読み取り/書き込み値を渡して周囲参照または const 参照、または値のコピーが低い場合です。 右辺値参照に左辺をバインドすることはできません。

### <a name="xvalue-im"></a>xvalue フラグ (i\ & m)
(Glvalue の一種でも、種類の右辺値)、xvalue フラグ id がありも移動します。 これにコピーは、コストがかかるために、移動させるをされる操作が起きる可能性があり、後でアクセスすることをしないように注意することができます。 以下に、xvalue フラグに左辺を有効にする方法を示します。

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

上記のコード例で移動していない何もまだします。 Xvalue フラグだけをキャスト左辺、名前のない右辺値の参照を作成しました。 まだその左辺値の名前で識別できます。として、xvalue フラグ、することが*できる*移動しています。 これを行うためには、上の理由から、別のトピックを待機するが、実際にはどのような移動します。 ただし、"x"「xvalue フラグ」意味「エキスパートのみ」するのに役立つ場合として考えることができます。 左辺をキャスト、xvalue フラグ (右辺値の種類) に、値になります右辺値参照にバインドされていること。

ここでは、取得の他の 2 つの例&mdash;、名前のない右辺値参照を返す関数を呼び出すと、xvalue フラグのメンバーにアクセスします。

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a>prvalue (\!i\ & m)
(純粋な右辺値、右辺値の種類) の prvalue id ではありませんが、移動します。 これらは、一時領域では通常、関数の呼び出しの結果を返します。 値、または、glvalue でないその他の式を評価した結果によって

### <a name="rvalue-m"></a>右辺値 (分)
右辺値が移動します。 右辺値*の参照*は、常に右辺値 (値を想定しています内容を維持する必要はありません) を参照します。

ただし、右辺値は、参照です自体右辺値かどうか。 (上記 xvalue フラグのコード例に示すもの) のような*名前のない*の右辺値の参照が、xvalue フラグはいは、その右辺値。 移動コンス トラクターのなど、右辺値の参照関数パラメーターにバインドされていることを優先します。 逆に、おそらく counter-intuitively) かどうか、右辺値の参照が、名前は、その名前で構成される式左辺します。 したがって、右辺値の参照パラメーターにバインドする*ことはできません*。 簡単に操作を行うことが&mdash;だけもう一度キャスト右辺値の名前のない参照 (xvalue フラグ)。

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
Id がないし、移動がない値の種類は、まだ説明していない 1 つの組み合わせです。 ただし、そのカテゴリは、C++ 言語で便利なアイデアはないため、無視します。

## <a name="reference-collapsing-rules"></a>規則の参照を折りたたんだり
式 (、左辺値への参照の左辺参照するか、右辺値への参照を右辺値の参照) で複数の like 参照では、別の出力を 1 つキャンセルします。

- `A& &` 折りたたまれます`A&`します。
- `A&& &&` 折りたたまれます`A&&`します。

数式で参照とは異なり、複数の左辺参照に折りたたまれます。

- `A& &&` 折りたたまれます`A&`します。
- `A&& &` 折りたたまれます`A&`します。

## <a name="forwarding-references"></a>転送への参照
この最後のセクションでは、右辺値の参照は、既に述べた、*参照を転送*のさまざまな概念と対照的です。

```cppwinrt
void foo(A&& a) { ... }
```

- `A&&` 説明した、右辺値参照です。 Const と揮発性は、右辺値への参照には適用されません。
- `foo` **A**の種類の rvalue のみを受け取ります。
- 理由右辺値の参照 (よう`A&&`) が存在はオーバー ロードが渡される一時的な (またはその他の右辺値) の大文字と小文字が最適化を作成するためです。

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- `_Ty&&` *転送リファレンス*です。 渡すことによって`bar`、種類 **_Ty**が const/非 const 揮発性/非揮発性とは別にすることができます。
- `bar` 任意の左辺値または型 **_Ty**の右辺の値を受け入れます。
- 転送の参照になる左辺に渡すと、 `_Ty& &&`、左辺値のリファレンスを縮小する`_Ty&`します。
- 転送の参照になる右辺値に渡すと、 `_Ty&& &&`、右辺値のリファレンスを縮小する`_Ty&&`します。
- 参照を転送する理由 (よう`_Ty&&`) が存在が*ない*の最適化が何を渡すには、それらを実行して効率的かつ透過的に転送します。 転送の参照を書き込み、または調査と見つかる) ライブラリのコードである場合にのみ発生する可能性が高い&mdash;など、コンス トラクターの引数を転送するファクトリ関数。

## <a name="sources"></a>Sources
* \[Stroustrup, 2013\] ある Stroustrup: C++ プログラミング言語、4 番目のエディション。 ◆ センター。 2013 します。
