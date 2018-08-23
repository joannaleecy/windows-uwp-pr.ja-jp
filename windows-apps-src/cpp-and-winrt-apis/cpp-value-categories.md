---
author: stevewhims
description: このトピックでは、C で存在しない値のさまざまなカテゴリについて説明します。 Lvalue と rvalue 音がわかりは、他の種類をすぎる場合もあります。
title: 値のカテゴリ、およびへの参照
ms.author: stwhi
ms.date: 08/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、+ + c、cpp、winrt、投影、移動、転送、値のカテゴリ、移動の形式、最適な転送、操作が起きる、右辺値、glvalue、prvalue、xvalue フラグ
ms.localizationpriority: medium
ms.openlocfilehash: cbccaf78b45d85d93619977d149431c4eec9e10a
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2814674"
---
# <a name="value-categories-and-references-to-them"></a>値のカテゴリ、およびへの参照
このトピックでは、C で存在しているさまざまなカテゴリの値 (値への参照) について説明します。 *Lvalue*と*rvalue*音がわかりが、このトピックで説明する条件のうちいない考えです。 値の他の種類があります。

C ですべての式では、このトピックで説明するカテゴリのいずれかに属している値が生成します。 C 言語、facilies、およびこれらの値のカテゴリとへの参照の適切なの理解度を必要とすると、ルールの要素があります。 たとえば、値、値をコピー、値を移動および転送に別の関数の値のアドレスを取得します。 このトピックはすべての機能についての詳細] に移動しないが、それらの基本を理解情報を提供します。

このトピックの情報は、id および movability [Stroustrup 2013] の 2 つの独立したプロパティを Stroustrup の値のカテゴリの詳細な分析で囲まれています。

## <a name="an-lvalue-has-identity"></a>操作が起きるの id を持ってください。
どういう*id*の値の意味ですか。 値のメモリ アドレスがある (または実行可能な) し、[値の id を持って安全に使用します。 これにより、できる比較よりも多い値の内容: 比較したり、id で区別できるようにします。

*操作が起きる*id を持っています。 「操作が起きる」の「さ」が「左」(ように、left-hand-の面に、割り当て) の省略形のみ履歴興味のある問題です。 C では、操作が起きるは、左 *、または*割り当ての右側に表示されます。 "Lvalue"、"l"し、実際にうまくいかない理解し、は何かを定義します。 操作が起きると呼ばれるものは、id を持つ値であるかを理解するには、のみを指定する必要があります。

Lvalue は、式の例: 名前付き変数または定数といいます。または、参照を返す関数を選択します。 Lvalue では*ありません*が、式の例: 一時的なです。または、値を返す関数を選択します。

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

これで、条件を満たすステートメント lvalue が id を持っているは取得します。 どのような*xvalue フラグ*は、このトピックの後半にしましょう。 ここでは、だけで、glvalue「一般的な操作が起きる」と呼ばれる値のカテゴリがあることに注意してください。 Glvalues のスーパー セットには、lvalue (*クラシック lvalue*とも呼ばれます) と取得の両方が含まれています。 したがって、中に「操作が起きるの id を持って」条件が満たされた、一連の id を持っていることは、一連の glvalues、次の図に示すようにします。

![操作が起きるの id を持ってください。](images/has-identity1.png)

## <a name="an-rvalue-is-movable-an-lvalue-is-not"></a>右辺値が移動します。操作が起きるがないです。
ただし、glvalues 以外の値があります。 したがって、値のメモリ アドレスを取得する*ことはできません*(または与えてを有効にすることはできません) があります。 上記の例でこのようないくつかの値をしました。 欠点が聞こえます。 実際の値を利用できるは通常安価) は、*移動する*にはなどのではなく (これは、一般に価) からコピーします。 値から移動すると、内にある不要になったするために使用する場所を意味します。 したがって、するために使用する場所にアクセスしようとしています。 を回避します。 場合と*どのように*値がこのトピックの範囲外に移動するについて説明します。 このトピックでは、すぐに移動する値が*右辺値*(または*クラシック右辺値*) と呼ばれることを知っておく必要があります。

「右辺値」の"r"は、「右」(ように、右-hand-の面に、割り当て) の省略形です。 Rvalue および割り当ての外部で rvalue への参照を使用することができます。 "Rvalue"、"r"のオブジェクトに焦点を次はできません。 移動する値が右辺値と呼ばれるものであるかを理解のみにする必要があります。

逆に、次の図に示すように、操作が起きるは、移動です。 移動操作が起きるは*操作が起きる*の定義を入れては非常に適度に動作すると、引き続き値にアクセスすることができるコードの予期しないエラーになります。

![右辺値が移動します。操作が起きるがないです。](images/is-movable.png)

操作が起きるを移動することはできません。 しかし*が*移動できる glvalue (ユーザー機能のセット) の一種&mdash;何をしていることがわかっている場合 (など、移動後にアクセスしないように注意してください)&mdash;、xvalue フラグがします。 このアイデアをもう一度、次の値の項目の全体像を見るとお見直しされます。

## <a name="rvalue-references-and-reference-binding-rules"></a>右辺値の参照、およびリファレンス バインド規則
ここでは、右辺値への参照の構文を紹介します。 も大幅に移動し、[転送] の処理に移行する別のトピックを待つ必要はありますが、右辺値の参照が解決した問題です。 右辺値の参照を見ると、前に、最初が必要はわかりやすくなること`T&`&mdash;こと聞か以前れたり、通話だけ「参照」します。 「、操作が起きる (定数ではない) 参照」参照のユーザーを作成できます () の値を参照するは実際にできます。

```cppwinrt
template<typename T> T& get_by_lvalue_ref() { ... } // Get by lvalue (non-const) reference.
template<typename T> void set_by_lvalue_ref(T&) { ... } // Set by lvalue (non-const) reference.
```

右辺値ではなく、操作が起きる] に、操作が起きる参照にバインドできます。

操作が起きる定数参照し、(`T const&`)、するには、オブジェクトを*できない*参照のユーザーの作成 (たとえば、"定数") を参照してください。

```cppwinrt
template<typename T> T const& get_by_lvalue_cref() { ... } // Get by lvalue const reference.
template<typename T> void set_by_lvalue_cref(T const&) { ... } // Set by lvalue const reference.
```

操作が起きる定数の参照は、操作が起きるまたは右辺値にバインドします。

型の右辺値への参照の構文`T`として書き込まれます`T&&`します。 移動の値を右辺値の参照が参照&mdash;の値の内容は (たとえば、一時的な) を使用して後に維持する必要はありません。 全体のポイントからから移動する (変更されないように) の値にバインド右辺値参照では、`const`と`volatile`右辺値の参照を区切り記号 (とも呼ばれる cv の区切り記号) を適用しません。

```cppwinrt
template<typename T> T&& get_by_rvalue_ref() { ... } // Get by rvalue reference.
struct A { A(A&& other) { ... } }; // A move constructor takes an rvalue reference.
```

右辺値にバインド右辺値を参照します。 オーバー ロードの解像度を右辺値が*希望*よりも操作が起きる定数参照への右辺値参照にバインドするは実際には。 前述したを右辺値を参照する値 (たとえば、移動コンスのパラメーター) を保存する必要はありませんしたと見なされますの内容があるため、右辺値の参照に操作が起きるバインドことはできません。

渡すことも右辺値引数の値では、必要な場所でコピーの作成 (または右辺値が、xvalue フラグの場合は、移動構築機能を使って)。

## <a name="a-glvalue-has-identity-a-prvalue-does-not"></a>Glvalue が識別します。prvalue していません。
この時点での id を持ってとわかっています。 移動できる機能し、そうでないことがわかります。 まだおまだ id を持って*いない*名前付きの値のセットです。 そのセットは*prvalue*、または*単純右辺値*と呼ばれます。

```cppwinrt
int& get_by_ref() { ... }
int get_by_val() { ... }

int main()
{
    int* addr3{ &(get_by_ref() + 1) }; // Error: get_by_ref() + 1 is a prvalue.
    int* addr4{ &get_by_val() }; // Error: get_by_val() is a prvalue.
}
```

![操作が起きるが識別します。prvalue していません。](images/has-identity2.png)

## <a name="the-complete-picture-of-value-categories"></a>値のカテゴリの完全な画像
情報と、1 つの大きな画像の上にある図を結合するだけのままです。

![値のカテゴリの完全な画像](images/value-categories.png)

### <a name="glvalue-i"></a>glvalue (i)
Id を持って、glvalue (一般的な操作が起きる)。

### <a name="lvalue-im"></a>操作が起きる (i\ & \!m)
操作が起きる (glvalue の種類) の id が、移動されていません。 通過するを参照または定数の参照、または値をコピーすることが低い場合は、通常の読み取り/書き込み値です。 操作が起きる右辺値参照にバインドできません。

### <a name="xvalue-im"></a>xvalue フラグ (i\ & m)
(Glvalue、の種類もの右辺値の種類)、xvalue フラグ id がありも移動します。 される操作が起きるされるため、コストがコピー、移動する可能性があり、後で、アクセスしないように注意ができます。 Xvalue フラグに操作が起きるを有効にする方法をご紹介します。

```cppwinrt
struct A { ... };
A a; // a is an lvalue...
static_cast<A&&>(a); // ...but this expression is an xvalue.
```

上記のコードの例では移動していない何もまだします。 操作が起きる右辺値の名前のない参照にキャストを xvalue フラグ作成しました。 操作が起きる名で識別されることもできます。しますが、として、xvalue フラグ、今すぐ*利用できる*を移動します。 理由と、別のトピックを待つ必要はどのような移動など、実際が表示されます。 意味"エキスパート取り専用で"できる場合は、「xvalue フラグ」の"x"の考えることができます。 操作が起きるをキャストを xvalue フラグ (右辺値の種類) に、値になります右辺値参照にバインドされていること。

取得およびその他の 2 つの例を紹介&mdash;、名称未設定の右辺値の参照を返す関数を呼び出すと、xvalue フラグのメンバーにアクセスします。

```cppwinrt
struct A { int m; };
A&& f();
f(); // This expression is an xvalue...
f().m; // ...and so is this.
```

### <a name="prvalue-im"></a>prvalue (\!i\ & m)
(単純右辺値。 右辺値の一種) の prvalue id がありません。 しかし移動します。 関数を呼び出すの結果は一時これらは通常、値、または、glvalue] ではないその他の式を評価した結果を返します。

### <a name="rvalue-m"></a>右辺値 (m)
右辺値が移動します。 右辺値の*参照*は、常に右辺値 (値と見なされます内容を保存する必要はありません) を参照します。

右辺値参照自体を右辺値ですか。 (上記の xvalue フラグ コード例に示すもの) のような*名前*の右辺値の参照が、xvalue フラグはいは、その右辺値。 優先的に移動コンスのなど、右辺値の参照関数パラメーターにバインドします。 逆に、counter-intuitively など)、右辺値の参照が名前を持つかどうかは、その名前で構成されている式は、操作が起きるします。 したがって、右辺値参照パラメーターにバインドする*ことはできません*。 簡単に実行することができますが、&mdash;だけもう一度キャスト右辺値の名前の参照 (xvalue フラグ) にします。

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

### <a name="im"></a>\!i\ と \!m
ユーザーがない理由と移動されていない値の種類は、まだ説明していない 1 つの組み合わせです。 そのカテゴリが C 言語で便利なを理解するため、無視することができます。

## <a name="reference-collapsing-rules"></a>[ルールのリファレンス折りたたみ
(操作が起きる参照では、操作が起きるを参照または右辺値参照への右辺値参照) の式に複数の like 参照はいずれかの別のものをキャンセルします。

- `A& &` `A&`します。
- `A&& &&` `A&&`します。

式内の参照とは異なり、複数非表示、操作が起きる参照にします。

- `A& &&` `A&`します。
- `A&& &` `A&`します。

## <a name="forwarding-references"></a>参照の転送
最後のセクションでは、右辺値の参照は、既にで説明した、*参照の転送*のさまざまな概念とを比較します。

```cppwinrt
void foo(A&& a) { ... }
```

- `A&&` 右辺値、参照はきたようです。 定数と揮発性はしない右辺値の参照を適用します。
- `foo` **入力**の rvalue のみを受け入れます。
- 理由右辺値を参照 (次のような`A&&`) が存在する渡される一時的な (またはその他の右辺値) の場合に最適なオーバー ロードを作成するようにします。

```cppwinrt
template <typename _Ty> void bar(_Ty&& ty) { ... }
```

- `_Ty&&` *参照を転送*します。 内容を通過する`bar`、種類 **_Ty**は定数/非定数揮発性/非揮発性とは独立させてである可能性があります。
- `bar` 任意の操作が起きるまたは型 **_Ty**の右辺値を受け入れます。
- 転送参照操作が起きるを渡すと`_Ty& &&`、操作が起きるの参照を解除する`_Ty&`します。
- 転送の参照が右辺値を渡すと`_Ty&& &&`、右辺値の参照を解除する`_Ty&&`します。
- 参照を転送する理由 (次のような`_Ty&&`) が存在が*ない*の最適化] を何を通過するにはし透過的かつ効率的には、転送します。 書き込み、または密接に研究) ライブラリ コード場合にのみ転送の参照が発生する可能性がある&mdash;コンス引数に転送するファクトリ関数などです。

## <a name="sources"></a>Sources
* \[Stroustrup 2013\] B. Stroustrup: C プログラミング言語、4 番目の Edition します。 ◆ センターします。 2013 します。
