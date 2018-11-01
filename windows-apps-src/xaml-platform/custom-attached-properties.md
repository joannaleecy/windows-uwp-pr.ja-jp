---
author: jwmsft
description: XAML 添付プロパティを依存関係プロパティとして実装する方法と、添付プロパティを XAML で使うために必要なアクセサー変換を定義する方法を説明します。
title: カスタム添付プロパティ
ms.assetid: E9C0C57E-6098-4875-AA3E-9D7B36E160E0
ms.author: jimwalk
ms.date: 07/18/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cppwinrt
- cpp
ms.openlocfilehash: de2d319f536b2c9d25d53e0b1ec2886831c66e12
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5878398"
---
# <a name="custom-attached-properties"></a>カスタム添付プロパティ

*添付プロパティ*は、XAML の概念です。 添付プロパティは、通常は依存関係プロパティの特殊な形式として定義されます。 このトピックでは、添付プロパティを依存関係プロパティとして実装する方法と、添付プロパティを XAML で使うために必要なアクセサー変換を定義する方法を説明します。

## <a name="prerequisites"></a>必要条件

依存関係プロパティを既にある依存関係プロパティのユーザーの観点から理解し、「[依存関係プロパティの概要](dependency-properties-overview.md)」を読んでいることを前提としています。 「[添付プロパティの概要](attached-properties-overview.md)」も読んでいる必要があります。 このトピックの例を参考にするには、XAML について理解し、C++、C#、または Visual Basic を使った基本的な Windows ランタイム アプリを作る方法を理解している必要もあります。

## <a name="scenarios-for-attached-properties"></a>添付プロパティのシナリオ

定義クラス以外のクラスで利用できるプロパティ設定メカニズムが必要な場合は、添付プロパティを作成できます。 その最も一般的なシナリオは、レイアウトとサービス サポートです。 既にあるレイアウト プロパティの例として、[**Canvas.ZIndex**](https://msdn.microsoft.com/library/windows/apps/hh759773) と [**Canvas.Top**](https://msdn.microsoft.com/library/windows/apps/hh759772) があります。 レイアウトのシナリオでは、レイアウト制御要素の子要素として存在する要素は親要素に対するレイアウト要件を個別に表現でき、それぞれ、親が添付プロパティとして定義するプロパティ値を設定します。 Windows ランタイム API のサービス サポートのシナリオの例は、[**ScrollViewer.IsZoomChainingEnabled**](https://msdn.microsoft.com/library/windows/apps/br209561) など、[**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/br209527) の添付プロパティのセットです。

> [!WARNING]
> Windows ランタイム XAML 実装の既存の制限は、カスタム添付プロパティをアニメーション化することはできません。

## <a name="registering-a-custom-attached-property"></a>カスタム添付プロパティの登録

他の種類で使う添付プロパティを厳密に定義する場合、プロパティが登録されているクラスが [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生する必要はありません。 ただし、添付プロパティが依存関係プロパティでもある標準モデルに従う場合は、バッキング プロパティ ストアを使うことができるように、アクセサーのターゲット パラメーターで **DependencyObject** を使う必要があります。

[**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/br242362) 型の **public** **static** **readonly** プロパティを宣言することで、添付プロパティを依存関係プロパティとして定義します。 このプロパティは、[**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) メソッドの戻り値を使って定義します。 プロパティ名は、**RegisterAttached** *name* パラメーターとして指定した添付プロパティ名の終わりに "Property" という文字列を追加した名前と一致する必要があります。 これは、依存関係プロパティが表すプロパティとの関連で依存関係プロパティの識別子に名前を付ける場合の確立された規則です。

カスタム添付プロパティを定義する主要領域は、アクセサーまたはラッパーを定義する方法の点でカスタム依存関係プロパティとは異なります。 使用して[カスタム依存関係プロパティ](custom-dependency-properties.md)で説明されているラッパー手法ではなく、静的なを提供する必要がありますも **を取得する。 PropertyName*と **設定。 PropertyName*メソッドを添付プロパティのアクセサーとしてします。 アクセサーは主に XAML パーサーで使われますが、XAML 以外のシナリオでは他の任意の呼び出し元もこれらを使って値を設定できます。

> [!IMPORTANT]
> アクセサーを正しくを定義しない場合は、XAML プロセッサは、添付プロパティにアクセスできませんし、それを使用しようとするすべてのユーザーはおそらく、XAML 解析エラーを取得します。 また、デザイン ツールとコーディング ツールは、参照されるアセンブリでカスタム依存関係プロパティを検出した場合に、"\*Property" という識別子の命名規則に依存することがよくあります。

## <a name="accessors"></a>アクセサー

**Get**_PropertyName_ アクセサーのシグネチャは次のようにする必要があります。

`public static` _valueType_ **Get**_PropertyName_ `(DependencyObject target)`

Microsoft Visual Basic の場合は、次のようになります。

`Public Shared Function Get`_PropertyName_`(ByVal target As DependencyObject) As `_valueType_`)`

*target* オブジェクトは実装でより具体的な型にすることができますが、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生する必要があります。 *valueType* 戻り値も、実装でより具体的な型にすることができます。 基本的な **Object** 型が受け入れられますが、多くの場合、添付プロパティにタイプ セーフを適用します。 タイプ セーフ手法として、getter シグネチャと setter シグネチャで型指定を使うことをお勧めします。

シグネチャは、**設定。 PropertyName*アクセサーはこれである必要があります。

`public static void Set`_PropertyName_` (DependencyObject target , `_valueType_` value)`

Visual Basic の場合は、次のようになります。

`Public Shared Sub Set`_PropertyName_` (ByVal target As DependencyObject, ByVal value As `_valueType_`)`

*target* オブジェクトは実装でより具体的な型にすることができますが、[**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生する必要があります。 *value* オブジェクトとその *valueType* は、実装でより具体的な型にすることができます。 添付プロパティがマークアップに検出された場合、このメソッドの値は XAML プロセッサからの入力であることに注意してください。 属性値 (最終的には単なる文字列) から適切な型を作成できるように、使う型の型変換または既存のマークアップ拡張サポートが必要です。 基本的な **Object** 型が受け入れられますが、多くの場合、さらにタイプ セーフにします。 これを実現するには、アクセサーに型を適用します。

> [!NOTE]
> プロパティ要素構文で使うことを意図が添付プロパティを定義することもできます。 その場合、値の型変換は必要ではありませんが、意図した値を XAML で確実に作成できるようにする必要があります。 [**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) は、プロパティ要素の使用だけをサポートする既存の添付プロパティの例です。

## <a name="code-example"></a>コードの例

この例は、([**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) メソッドを使った) 依存関係プロパティの登録と、カスタム添付プロパティの **Get** アクセサーと **Set** アクセサーを示しています。 この例では、添付プロパティ名は `IsMovable` です。 したがって、アクセサーの名前は `GetIsMovable` と `SetIsMovable` にする必要があります。 添付プロパティの所有者は `GameService` という名前の独自の UI を持たないサービス クラスです。その目的は **GameService.IsMovable** 添付プロパティを使うときに、添付プロパティ サービスを提供することだけです。

添付プロパティを定義する c++ +/CX は、少し複雑です。 ヘッダーとコード ファイル間の関連性を決定する必要があります。 また、「[カスタム依存関係プロパティ](custom-dependency-properties.md)」で説明している理由から、識別子を **get** アクセサーのみ持つプロパティとして公開する必要があります。 C++/cli CX このプロパティとフィールドの関係を定義する必要があります単純なプロパティのバッキング .NET **readonly**キーワードと暗黙的な証明書利用者のではなく明示的にします。 また、アプリが最初に開始されたとき、添付プロパティを必要とする XAML ページが読み込まれる前に、1 回だけ実行されるヘルパー関数内で、添付プロパティの登録を実行する必要があります。 依存関係プロパティまたは添付プロパティのプロパティ登録ヘルパー関数を呼び出す一般的な場所は、app.xaml ファイルのコードの **App** / [**Application**](https://msdn.microsoft.com/library/windows/apps/br242325) コンストラクターの内部からです。

```csharp
public class GameService : DependencyObject
{
    public static readonly DependencyProperty IsMovableProperty = 
    DependencyProperty.RegisterAttached(
      "IsMovable",
      typeof(Boolean),
      typeof(GameService),
      new PropertyMetadata(false)
    );
    public static void SetIsMovable(UIElement element, Boolean value)
    {
        element.SetValue(IsMovableProperty, value);
    }
    public static Boolean GetIsMovable(UIElement element)
    {
        return (Boolean)element.GetValue(IsMovableProperty);
    }
}
```

```vb
Public Class GameService
    Inherits DependencyObject

    Public Shared ReadOnly IsMovableProperty As DependencyProperty = 
        DependencyProperty.RegisterAttached("IsMovable",  
        GetType(Boolean), 
        GetType(GameService), 
        New PropertyMetadata(False))

    Public Shared Sub SetIsMovable(ByRef element As UIElement, value As Boolean)
        element.SetValue(IsMovableProperty, value)
    End Sub

    Public Shared Function GetIsMovable(ByRef element As UIElement) As Boolean
        GetIsMovable = CBool(element.GetValue(IsMovableProperty))
    End Function
End Class
```

```cppwinrt
// GameService.idl
namespace UserAndCustomControls
{
    runtimeclass GameService : Windows.UI.Xaml.DependencyObject
    {
        GameService();
        static Windows.UI.Xaml.DependencyProperty IsMovableProperty{ get; };
        Boolean IsMovable;
    }
}

// GameService.h
...
    bool IsMovable(){ return winrt::unbox_value<bool>(GetValue(m_IsMovableProperty)); }
    void IsMovable(bool value){ SetValue(m_IsMovableProperty, winrt::box_value(value)); }
    Windows::UI::Xaml::DependencyProperty IsMovableProperty(){ return m_IsMovableProperty; }

private:
    static Windows::UI::Xaml::DependencyProperty m_IsMovableProperty;
...

// GameService.cpp
...
Windows::UI::Xaml::DependencyProperty GameService::m_IsMovableProperty =
    Windows::UI::Xaml::DependencyProperty::RegisterAttached(
        L"IsMovable",
        winrt::xaml_typename<bool>(),
        winrt::xaml_typename<UserAndCustomControls::GameService>(),
        Windows::UI::Xaml::PropertyMetadata{ winrt::box_value(false) }
);
...
```

```cpp
// GameService.h
#pragma once

#include "pch.h"
//namespace WUX = Windows::UI::Xaml;

namespace UserAndCustomControls {
    public ref class GameService sealed : public WUX::DependencyObject {
    private:
        static WUX::DependencyProperty^ _IsMovableProperty;
    public:
        GameService::GameService();
        void GameService::RegisterDependencyProperties();
        static property WUX::DependencyProperty^ IsMovableProperty
        {
            WUX::DependencyProperty^ get() {
                return _IsMovableProperty;
            }
        };
        static bool GameService::GetIsMovable(WUX::UIElement^ element) {
            return (bool)element->GetValue(_IsMovableProperty);
        };
        static void GameService::SetIsMovable(WUX::UIElement^ element, bool value) {
            element->SetValue(_IsMovableProperty,value);
        }
    };
}

// GameService.cpp
#include "pch.h"
#include "GameService.h"

using namespace UserAndCustomControls;

using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Documents;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Interop;
using namespace Windows::UI::Xaml::Media;

GameService::GameService() {};

GameService::RegisterDependencyProperties() {
    DependencyProperty^ GameService::_IsMovableProperty = DependencyProperty::RegisterAttached(
         "IsMovable", Platform::Boolean::typeid, GameService::typeid, ref new PropertyMetadata(false));
}
```

## <a name="using-your-custom-attached-property-in-xaml"></a>XAML でのカスタム添付プロパティの使用

添付プロパティを定義し、そのサポート メンバーをカスタム型の一部として含めたら、定義を XAML で利用できるようにする必要があります。 そのためには、関連クラスを含むコード名前空間を参照する XAML 名前空間をマップする必要があります。 添付プロパティをライブラリの一部として定義した場合は、そのライブラリをアプリのアプリ パッケージの一部として含める必要があります。

XAML の XML 名前空間マッピングは、通常は XAML ページのルート要素に配置されます。 たとえば、前のスニペットで示した添付プロパティ定義を含む名前空間 `UserAndCustomControls` に `GameService` という名前のクラスがある場合、マッピングは次のようになります。

```xaml
<UserControl
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:uc="using:UserAndCustomControls"
  ... >
```

マッピングを使うと、Windows ランタイムで定義された既にある型も含め、ターゲット定義に一致する任意の要素に `GameService.IsMovable` 添付プロパティを設定できます。

```xaml
<Image uc:GameService.IsMovable="True" .../>
```

同じマップされた XML 名前空間内にもある要素にプロパティを設定する場合でも、添付プロパティ名にプレフィックスを含める必要があります。 これは、プレフィックスによって所有者型が修飾されるためです。 標準 XML 規則により属性が要素から名前空間を継承できる場合でも、添付プロパティの属性がその属性を含む要素と同じ XML 名前空間にあることは想定できません。 たとえば、`GameService.IsMovable` を `ImageWithLabelControl` のカスタム型 (定義は示しません) に設定する場合、その両方が同じプレフィックスにマップされる同じコード名前空間に定義されていても、XAML は依然として次のようになります。

```xaml
<uc:ImageWithLabelControl uc:GameService.IsMovable="True" .../>
```

> [!NOTE]
> C++ での XAML UI を作成する場合、XAML ページが、その型を使用して、いつでも、添付プロパティを定義するカスタム型のヘッダーを含める必要があります。 各 XAML ページには、.xaml.h コード ビハインド ヘッダーが関連付けられています。 ここに、添付プロパティの所有者型の定義のヘッダーを (**\#include** を使って) 含める必要があります。

## <a name="value-type-of-a-custom-attached-property"></a>カスタム添付プロパティの値型

カスタム添付プロパティの値型として使われる型は、使用方法、定義、または使用方法と定義の両方に影響します。 添付プロパティの値型は、複数の場所で (**Get** アクセサー メソッドと **Set** アクセサー メソッド両方のシグネチャで、また [**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833) 呼び出しの *propertyType* パラメーターとして) 宣言されます。

添付プロパティ (カスタムまたはそれ以外) で最も一般的な値型は、単純な文字列です。 これは、添付プロパティは一般に XAML 属性で使われることが意図されており、文字列を値型として使うとプロパティが軽量になるためです。 整数、倍精度浮動小数点、列挙値など、文字列メソッドへのネイティブ変換を持つその他のプリミティブも、添付プロパティの値型として一般的です。 ネイティブ文字列変換をサポートしない他の値型を添付プロパティ値として使うこともできます。 ただし、その場合は、使用方法または実装について選択が必要です。

- 添付プロパティはそのままにすることができますが、添付プロパティでは、添付プロパティがプロパティ要素であり、値がオブジェクト要素として宣言される使用方法のみサポートできます。 この場合、プロパティ型はオブジェクト要素としての XAML の使用をサポートする必要があります。 既にある Windows ランタイム参照クラスの場合は、XAML 構文を調べて、型が XAML オブジェクト要素の使用をサポートすることを確認します。
- 添付プロパティはそのままにすることができますが、文字列として表現できる **Binding** や **StaticResource** などの XAML 参照手法で属性を使う場合にのみ使います。

## <a name="more-about-the-canvasleft-example"></a>**Canvas.Left** の例に関する詳細

添付プロパティの使用法として前に挙げた例では、[**Canvas.Left**](https://msdn.microsoft.com/library/windows/apps/hh759771) 添付プロパティを設定するさまざまな方法を説明しました。 しかし、それによって [**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) がオブジェクトとやり取りする方法やタイミングがどのように変わるのでしょうか。 ここでは、この例をさらに詳しく検討します。添付プロパティを実装しており、他のオブジェクトで添付プロパティの値が検出された場合に、典型的な添付プロパティの所有者クラスが添付プロパティの値に対して実行する処理を理解するのは意味のあることだからです。

[**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) の主な機能は、UI で絶対位置の決まったレイアウト コンテナーとなることです。 **Canvas** の子は、基底クラスの定義済みプロパティ [**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) に格納されます。 パネルのうち、**Canvas** だけが絶対配置を使います。 **Canvas** や特定の **UIElement** が **UIElement** の子要素になっている場合にのみ関係するプロパティを追加した場合には、共通の [**UIElement**](https://msdn.microsoft.com/library/windows/apps/br208911) 型のオブジェクト モデルが大きくなっていたおそれがあります。 **Canvas** のレイアウト コントロールのプロパティを、どの **UIElement** でも使用できる添付プロパティに定義すると、オブジェクト モデルをすっきりした状態に保つことができます。

[**Canvas**](https://msdn.microsoft.com/library/windows/apps/br209267) にはパネルを実用的にするため、フレームワーク レベルの [**Measure**](https://msdn.microsoft.com/library/windows/apps/br208952) と [**Arrange**](https://msdn.microsoft.com/library/windows/apps/br208914) メソッドを上書きするという動作があります。 **Canvas** が子について実際に添付プロパティを確認するのはここです。 **Measure** と **Arrange** の両パターンの一部は、コンテンツを反復処理するループです。また、パネルには、パネルの子とされるものを明確にする [**Children**](https://msdn.microsoft.com/library/windows/apps/br227514) プロパティがあります。 このため、**Canvas** レイアウトの動作は、子を反復処理したうえで、子のそれぞれについて [**Canvas.GetLeft**](https://msdn.microsoft.com/library/windows/apps/br209269) と [**Canvas.GetTop**](https://msdn.microsoft.com/library/windows/apps/br209270) の静的呼び出しを実行し、その添付プロパティに既定以外の値 (既定値は 0) が含まれているかどうかを確認するというものになります。 確認された値はその後、**Canvas** の利用可能なレイアウト スペースで子のそれぞれが提供する値に応じて、子の絶対位置を設定するのに使われた後、**Arrange** を使ってコミットされます。

コードは、次の擬似コードのようになります。

```syntax
protected override Size ArrangeOverride(Size finalSize)
{
    foreach (UIElement child in Children)
    {
        double x = (double) Canvas.GetLeft(child);
        double y = (double) Canvas.GetTop(child);
        child.Arrange(new Rect(new Point(x, y), child.DesiredSize));
    }
    return base.ArrangeOverride(finalSize); 
    // real Canvas has more sophisticated sizing
}
```

> [!NOTE]
> パネルの動作について詳しくは、 [XAML カスタム パネルの概要](https://msdn.microsoft.com/library/windows/apps/mt228351)をご覧ください。

## <a name="related-topics"></a>関連トピック

* [**RegisterAttached**](https://msdn.microsoft.com/library/windows/apps/hh701833)
* [添付プロパティの概要](attached-properties-overview.md)
* [カスタム依存関係プロパティ](custom-dependency-properties.md)
* [XAML の概要](xaml-overview.md)
