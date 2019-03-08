---
description: このトピックでは C + を使用して単純なカスタム コントロールを作成する次の手順を示します/cli WinRT します。 独自の機能が豊富でカスタマイズ可能な UI コントロールを作成する、情報はこちらでビルドすることができます。
title: C++/WinRT による XAML カスタム (テンプレート化) コントロール
ms.date: 10/03/2018
ms.topic: article
keywords: windows 10、uwp、standard、c++、cpp、winrt、プロジェクション、XAML をテンプレート、カスタム コントロール
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: ce4f7eea074233c625a2cc92ef773f0b06c2be9f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635147"
---
# <a name="xaml-custom-templated-controls-with-cwinrt"></a>C++/WinRT による XAML カスタム (テンプレート化) コントロール

> [!IMPORTANT]
> 基本的な概念と用語の使用およびを持つランタイム クラスを作成する方法についての理解をサポートする[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)を参照してください[C + を使用して Api を使用/cli WinRT](consume-apis.md)と[作成者 Api c++/cliWinRT](author-apis.md)します。

ユニバーサル Windows プラットフォーム (UWP) の最も強力な機能の 1 つは、柔軟性、XAML に基づくカスタム コントロールを作成するユーザー インターフェイス (UI) スタックを提供する[**コントロール**](/uwp/api/windows.ui.xaml.controls.control)型。 XAML UI フレームワークがなどの機能を提供します[カスタム依存関係プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)と[添付プロパティ](/windows/uwp/xaml-platform/custom-attached-properties)、および[コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)、簡単に作成すること機能豊富でカスタマイズ可能なコントロール。 このトピックで説明した C + を使用してカスタム (テンプレート) コントロールを作成する手順/cli WinRT します。

## <a name="create-a-blank-app-bglabelcontrolapp"></a>空のアプリ (BgLabelControlApp) の作成します。
まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。 作成、 **Visual C** > **Windows ユニバーサル** > **空のアプリ (C +/cli WinRT)** プロジェクト、および名前を付けます*BgLabelControlApp*. このトピックの後のセクションに表示するプロジェクトをビルドする (それまでの間でビルドはありません)。

カスタム (テンプレート) コントロールを表す新しいクラスを作成しようとしています。 同じコンパイル ユニット内のクラスを作成および使用しています。 クラスのインスタンスをこの XAML のマークアップから、これはランタイム クラスである理由を可能にします。 また、この作成と使用のどちらにも C++/WinRT を使用します。

新しいランタイム クラスの作成の最初の手順では、新しい **Midl ファイル (.idl)** 項目をプロジェクトに追加します。 これに `BgLabelControl.idl` という名前をつけます。 `BgLabelControl.idl` の既定のコンテンツを削除し、このランタイム クラスの宣言に貼り付けます。

```idl
// BgLabelControl.idl
namespace BgLabelControlApp
{
    runtimeclass BgLabelControl : Windows.UI.Xaml.Controls.Control
    {
        BgLabelControl();
        static Windows.UI.Xaml.DependencyProperty LabelProperty{ get; };
        String Label;
    }
}
```

上記の一覧は、依存関係プロパティ (DP) を宣言するときに従うパターンを示しています。 各配布ポイントを 2 つの部分があります。 最初に、型の読み取り専用の静的プロパティを宣言[ **DependencyProperty**](/uwp/api/windows.ui.xaml.dependencyproperty)します。 プラス、配布ポイントの名前を持つ*プロパティ*します。 実装では、この静的プロパティを使用します。 次に、読み取り/書き込みインスタンス プロパティを宣言する型と、配布ポイントの名前を使用します。 作成する場合、*添付プロパティ*(DP) ではなく、コード例を参照して、[カスタム添付プロパティ](/windows/uwp/xaml-platform/custom-attached-properties)します。

> [!NOTE]
> 浮動小数点型で、配布ポイントをする場合、ように`double`(`Double`で[MIDL 3.0](/uwp/midl-3/))。 宣言と型の配布ポイントを実装する`float`(`Single` MIDL で)、XAML マークアップでは、その配布ポイントの値を設定し、エラーが発生し、*テキストから 'Windows.Foundation.Single' を作成できませんでした '<NUMBER>'*.

ファイルを保存し、プロジェクトをビルドします。 ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\BgLabelControlApp\Debug\BgLabelControlApp\Unmerged\BgLabelControl.winmd`) が作成されます。 次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。 これらのファイルは、スタブ実装を開始するため、 **BgLabelControl** IDL 内で宣言されているランタイム クラスです。 これらのスタブは `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\BgLabelControl.h` と `BgLabelControl.cpp` です。

スタブ ファイル `BgLabelControl.h` と `BgLabelControl.cpp` を `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\` からプロジェクト フォルダー `\BgLabelControlApp\BgLabelControlApp\` にコピーします。 **ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。 コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。

## <a name="implement-the-bglabelcontrol-custom-control-class"></a>実装、 **BgLabelControl**カスタム コントロール クラス
ここで、`\BgLabelControlApp\BgLabelControlApp\BgLabelControl.h` と `BgLabelControl.cpp` を開いてランタイム クラスを実装してみましょう。 `BgLabelControl.h`、既定のスタイル キー、実装を設定するコンス トラクターを変更する**ラベル**と**LabelProperty**、という名前の静的イベント ハンドラーを追加**OnLabelChanged**に依存関係プロパティの値の変更を処理し、バッキング フィールドを格納するプライベート メンバーを追加**LabelProperty**します。

それらを追加した後、`BgLabelControl.h`ようになります。

```cppwinrt
// BgLabelControl.h
...
struct BgLabelControl : BgLabelControlT<BgLabelControl>
{
    BgLabelControl() { DefaultStyleKey(winrt::box_value(L"BgLabelControlApp.BgLabelControl")); }

    winrt::hstring Label()
    {
        return winrt::unbox_value<winrt::hstring>(GetValue(m_labelProperty));
    }

    void Label(winrt::hstring const& value)
    {
        SetValue(m_labelProperty, winrt::box_value(value));
    }

    static Windows::UI::Xaml::DependencyProperty LabelProperty() { return m_labelProperty; }

    static void OnLabelChanged(Windows::UI::Xaml::DependencyObject const&, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const&);

private:
    static Windows::UI::Xaml::DependencyProperty m_labelProperty;
};
...
```

`BgLabelControl.cpp`、このような静的メンバーを定義します。

```cppwinrt
// BgLabelControl.cpp
...
Windows::UI::Xaml::DependencyProperty BgLabelControl::m_labelProperty =
    Windows::UI::Xaml::DependencyProperty::Register(
        L"Label",
        winrt::xaml_typename<winrt::hstring>(),
        winrt::xaml_typename<BgLabelControlApp::BgLabelControl>(),
        Windows::UI::Xaml::PropertyMetadata{ winrt::box_value(L"default label"), Windows::UI::Xaml::PropertyChangedCallback{ &BgLabelControl::OnLabelChanged } }
);

void BgLabelControl::OnLabelChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& /* e */)
{
    if (BgLabelControlApp::BgLabelControl theControl{ d.try_as<BgLabelControlApp::BgLabelControl>() })
    {
        // Call members of the projected type via theControl.

        BgLabelControlApp::implementation::BgLabelControl* ptr{ winrt::get_self<BgLabelControlApp::implementation::BgLabelControl>(theControl) };
        // Call members of the implementation type via ptr.
    }
}
...
```

このチュートリアルでは、では使用しません**OnLabelChanged**します。 依存関係プロパティをプロパティ変更コールバックを登録する方法を表示することではあります。 実装**OnLabelChanged**投影の基本型から派生の射影された型を取得する方法も示しています (基本の射影された型が**DependencyObject**、この場合)。 射影された型を実装する型へのポインターを取得する方法を示します。 2 番目の操作は自然のみ可能になることで予測される型 (ランタイム クラスを実装するプロジェクト) を実装するプロジェクト。

> [!NOTE]
> Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョンは 1809) をインストールしていないかを呼び出す必要がありますし、後で、 [ **winrt::from_abi** ](/uwp/cpp-ref-for-winrt/from-abi) 、上記の依存関係プロパティの変更イベント ハンドラーで代わりに[ **winrt::get_self**](/uwp/cpp-ref-for-winrt/get-self)します。

## <a name="design-the-default-style-for-bglabelcontrol"></a>既定のスタイルを設計**BgLabelControl**

コンス トラクターに**BgLabelControl**自体の既定のスタイル キーを設定します。 では、*は*既定のスタイルですか? カスタム (テンプレート) コントロールを既定のスタイルを持つ必要があります&mdash;既定のコントロール テンプレートを格納している&mdash;がスタイルやテンプレート コントロールのコンシューマーが設定されていない場合にそれ自体を表示するために使用できます。 このセクションでは、既定のスタイルを含むプロジェクトにマークアップ ファイルを追加します。

プロジェクト ノード、新しいフォルダーを作成し、「テーマ」という名前を付けます。 `Themes`、型の新しい項目の追加**Visual C** > **XAML** > **XAML ビュー**、し、"Generic.xaml"という名前を付けます。 フォルダーとファイル名は、XAML フレームワークがカスタム コントロールの既定のスタイルを検索するための順序で次のように指定する必要があります。 既定の内容を削除`Generic.xaml`、次のマークアップに貼り付けます。

```xaml
<!-- \Themes\Generic.xaml -->
<ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:BgLabelControlApp">

    <Style TargetType="local:BgLabelControl" >
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="local:BgLabelControl">
                    <Grid Width="100" Height="100" Background="{TemplateBinding Background}">
                        <TextBlock HorizontalAlignment="Center" VerticalAlignment="Center" Text="{TemplateBinding Label}"/>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
</ResourceDictionary>
```

この場合、既定のスタイルを設定する唯一のプロパティは、コントロール テンプレートです。 正方形のテンプレートで構成されます (背景にバインドされて、**バック グラウンド**プロパティを XAML のすべてのインスタンス[**コントロール**](/uwp/api/windows.ui.xaml.controls.control)型が) と (そのテキスト要素テキストがバインドされた、 **BgLabelControl::Label**依存関係プロパティ)。

## <a name="add-an-instance-of-bglabelcontrol-to-the-main-ui-page"></a>インスタンスを追加**BgLabelControl** UI のメイン ページに

メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。 直後に、**ボタン**要素 (内部、 **StackPanel**)、次のマークアップを追加します。

```xaml
<local:BgLabelControl Background="Red" Label="Hello, World!"/>
```

次の include ディレクティブを追加しますも、`MainPage.h`ように、 **MainPage**型 (XAML マークアップと命令型コードのコンパイルの組み合わせ) は、認識、 **BgLabelControl**カスタム コントロールの種類。 使用する場合**BgLabelControl**別の XAML ページから追加これも、そのページのヘッダー ファイルにディレクティブを含める同じです。 または、ディレクティブは、プリコンパイル済みヘッダー ファイルの代わりで含める、1 つだけ配置します。

```cppwinrt
// MainPage.h
...
#include "BgLabelControl.h"
...
```

ここでプロジェクトをビルドして実行します。 既定のコントロール テンプレートがバインドしているの背景のブラシをラベルの表示、 **BgLabelControl**マークアップ内のインスタンス。

このチュートリアルでは、カスタム (テンプレート) コントロールの簡単な例を示した c++/cli WinRT します。 任意に豊富で完全な機能を備えた独自のカスタム コントロールを行うことができます。 たとえば、カスタム コントロールは、編集可能データ グリッド、ビデオ プレーヤー、または 3 D ジオメトリのビジュアライザーとして何か複雑な形式を実行できます。

## <a name="implementing-overridable-functions-such-as-measureoverride-and-onapplytemplate"></a>実装する*オーバーライド可能な*などの関数**MeasureOverride**と**OnApplyTemplate**

カスタム コントロールを派生する、 [**コントロール**](/uwp/api/windows.ui.xaml.controls.control)自体さらに、ランタイム クラスはランタイムの基本クラスから派生します。 オーバーライド可能なメソッドがあると**コントロール**、 [ **FrameworkElement**](/uwp/api/windows.ui.xaml.frameworkelement)、および[ **UIElement** ](/uwp/api/windows.ui.xaml.uielement)派生クラスでオーバーライドできます。 その方法を示すコード例を次に示します。

```cppwinrt
struct BgLabelControl : BgLabelControlT<BgLabelControl>
{
...
    // Control overrides.
    void OnPointerPressed(Windows::UI::Xaml::Input::PointerRoutedEventArgs const& /* e */) const { ... };

    // FrameworkElement overrides.
    Windows::Foundation::Size MeasureOverride(Windows::Foundation::Size const& /* availableSize */) const { ... };
    void OnApplyTemplate() const { ... };

    // UIElement overrides.
    Windows::UI::Xaml::Automation::Peers::AutomationPeer OnCreateAutomationPeer() const { ... };
...
};
```

*オーバーライド可能な*関数はさまざまな言語プロジェクションで通常と異なる表示自体。 C#、たとえば、オーバーライド可能な関数が通常プロテクト仮想関数として表示します。 C++/cli、WinRT 仮想も、保護ですがそれらをオーバーライドし、上記のように、独自の実装を提供できます。

## <a name="important-apis"></a>重要な API
* [コントロール クラス](/uwp/api/windows.ui.xaml.controls.control)
* [DependencyProperty クラス](/uwp/api/windows.ui.xaml.dependencyproperty)
* [FrameworkElement クラス](/uwp/api/windows.ui.xaml.frameworkelement)
* [UIElement クラス](/uwp/api/windows.ui.xaml.uielement)

## <a name="related-topics"></a>関連トピック
* [コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)
* [カスタム依存関係プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)
