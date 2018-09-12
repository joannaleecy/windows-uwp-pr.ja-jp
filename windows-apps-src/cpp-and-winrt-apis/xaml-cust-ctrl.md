---
author: stevewhims
description: このトピックでは、C++ を使用して、単純なカスタム コントロールを作成する手順について/WinRT します。 ここでは、独自の機能が豊富でカスタマイズ可能な UI コントロールを作成する情報に基づいてビルドすることができます。
title: C++/WinRT による XAML カスタム (テンプレート化) コントロール
ms.author: stwhi
ms.date: 08/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、XAML で、テンプレート化された、カスタム コントロール
ms.localizationpriority: medium
ms.openlocfilehash: fd1843afc58bc758db1c6e575f3733bdc4f47b4e
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3929498"
---
# <a name="xaml-custom-templated-controls-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>されたカスタム (テンプレート化された) コントロールを XAML [、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)

> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

最も強力な機能をユニバーサル Windows プラットフォーム (UWP) の 1 つは、柔軟性、XAML[**コントロール**](/uwp/api/windows.ui.xaml.controls.control)の種類に基づいてカスタム コントロールを作成するユーザー インターフェイス (UI) スタックを提供します。 XAML UI フレームワークでは、[カスタム依存関係プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)と添付プロパティは、および[コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)では、機能が豊富でカスタマイズ可能なコントロールを作成しやすくなどの機能を提供します。 このトピックでは、C++ (テンプレート) カスタム コントロールを作成する手順について/WinRT します。

## <a name="create-a-blank-app-bglabelcontrolapp"></a>空のアプリ (BgLabelControlApp) の作成します。
まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。 **Visual C**を作成 > **Windows ユニバーサル** > **空白のアプリ (、C++/WinRT)** プロジェクト、および*BgLabelControlApp*という名前を付けます。

カスタム (テンプレート化された) コントロールを表すための新しいクラスを作成する行いましょう。 同じコンパイル ユニット内のクラスを作成および使用しています。 ただし、このクラス、XAML マークアップからしたいため、ランタイム クラスをインスタンス化できるします。 また、この作成と使用のどちらにも C++/WinRT を使用します。

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

上記の登録情報は、依存関係プロパティ (DP) を宣言するときとパターンを示しています。 各 DP に 2 つがあります。 まず、 [**DependencyProperty**](/uwp/api/windows.ui.xaml.dependencyproperty)型の読み取り専用の静的プロパティを宣言します。 名前、DP と*プロパティ*があります。 実装では、この静的プロパティを使用します。 次に、入力、DP の名前とインスタンスの読み取り/書き込みプロパティを宣言します。

> [!NOTE]
> する場合は、DP 浮動小数点型と、しやすく`double`(`Double` [MIDL](/uwp/midl-3/)3.0)。 宣言と実装の種類の DP `float` (`Single` MIDL で)、エラーが発生し、値を設定するには、XAML マークアップで、その DP と*テキストから 'Windows.Foundation.Single' を作成できませんでした"<NUMBER>'*。

ファイルを保存し、プロジェクトをビルドします。 ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\BgLabelControlApp\Debug\BgLabelControlApp\Unmerged\BgLabelControl.winmd`) が作成されます。 次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。 これらのファイルには、IDL で宣言した**BgLabelControl**ランタイム クラスの実装を開始するためのスタブが含まれます。 これらのスタブは `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\BgLabelControl.h` と `BgLabelControl.cpp` です。

スタブ ファイル `BgLabelControl.h` と `BgLabelControl.cpp` を `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\` からプロジェクト フォルダー `\BgLabelControlApp\BgLabelControlApp\` にコピーします。 **ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。 コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。

## <a name="implement-the-bglabelcontrol-custom-control-class"></a>**BgLabelControl**カスタム コントロール クラスを実装します。
ここで、`\BgLabelControlApp\BgLabelControlApp\BgLabelControl.h` と `BgLabelControl.cpp` を開いてランタイム クラスを実装してみましょう。 `BgLabelControl.h`、既定のスタイル キーを設定し、**ラベル**と**LabelProperty**実装コンス トラクターの変更、 **OnLabelChanged**依存関係プロパティの値に変更を処理するという名前の静的イベント ハンドラーを追加およびプライベート メンバーを追加します。**LabelProperty**のバッキング フィールドを保存します。

これらを追加した後、`BgLabelControl.h`次のように見えます。

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

`BgLabelControl.cpp`、次のように静的メンバーを定義します。

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

        BgLabelControlApp::implementation::BgLabelControl* ptr{ winrt::from_abi<BgLabelControlApp::implementation::BgLabelControl>(theControl) };
        // Call members of the implementation type via ptr.
    }
}
...
```

このチュートリアルで使用しない**OnLabelChanged**をします。 ありますが、プロパティ変更コールバックに依存関係プロパティを登録する方法を確認できるようにできます。 **OnLabelChanged**の実装には、(基本の投影された型は、 **DependencyObject**をここでは) 基本投影された型から派生投影された型を取得する方法も示しています。 投影された型を実装する型へのポインターを取得する方法を示しています。 その 2 つ目の操作は自然のみ可能で投影された型 (ランタイム クラスを実装するプロジェクト) を実装するプロジェクトです。

> [!NOTE]
> [Windows 10 SDK プレビュー ビルド 17661](https://www.microsoft.com/software-download/windowsinsiderpreviewSDK)をインストールした後で、し、呼び出すことができます[**winrt::get_self**](/uwp/cpp-ref-for-winrt/get-self) [**winrt::from_abi**](/uwp/cpp-ref-for-winrt/from-abi)ではなく、上記の依存関係プロパティ変更されたイベント ハンドラーで場合。

## <a name="design-the-default-style-for-bglabelcontrol"></a>既定のスタイルを**BgLabelControl**を設計します。

そのコンス トラクターでは、 **BgLabelControl**は、自身の既定のスタイル キーを設定します。 どのような*は*既定のスタイルかどうか。 カスタム (テンプレート) コントロールは、既定のスタイルが必要です&mdash;既定のコントロール テンプレートを含む&mdash;自体で、コントロールのコンシューマーは、スタイルやテンプレートを設定しない場合のレンダリングに使用できること。 このセクションで、既定のスタイルを含むプロジェクトに、マークアップ ファイルを追加しますがあります。

プロジェクト ノードを新しいフォルダーを作成し、"Themes"という名前を付けます。 `Themes`、 **Visual C**の種類の新しい項目の追加 > **XAML** > **XAML ビュー**、し、"Generic.xaml"という名前を付けます。 カスタム コントロールの既定のスタイルを検索する、XAML フレームワークの順序で次のようにする必要は、フォルダーとファイル名。 既定のコンテンツを削除`Generic.xaml`、次のマークアップに貼り付けます。

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

この例では、既定のスタイルを設定する唯一のプロパティは、コントロール テンプレートです。 テンプレートは、(そのバック グラウンドは、XAML[**コントロール**](/uwp/api/windows.ui.xaml.controls.control)の種類のすべてのインスタンスが**バック グラウンド**プロパティにバインドされている)、正方形とテキスト要素 (テキストは**BgLabelControl::Label**の依存関係プロパティにバインドされている) で構成されます。

## <a name="add-an-instance-of-bglabelcontrol-to-the-main-ui-page"></a>UI のメイン ページに**BgLabelControl**のインスタンスを追加します。

メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。 ( **StackPanel**) 内の**ボタン**要素の後すぐには、次のマークアップを追加します。

```xaml
<local:BgLabelControl Background="Red" Label="Hello, World!"/>
```

また、追加、次のディレクティブを含める`MainPage.h` **MainPage**型 (XAML マークアップと命令型コードのコンパイルの組み合わせ) が、 **BgLabelControl**カスタム コントロールの種類を認識できるようにします。

```cppwinrt
// MainPage.h
...
#include "BgLabelControl.h"
...
```

ここでプロジェクトをビルドして実行します。 既定のコントロール テンプレートのバインドは、背景ブラシをし、ラベルの場合、マークアップで**BgLabelControl**インスタンスのことが表示されます。

このチュートリアルでは、カスタム (テンプレート) コントロールの単純な例を示した c++/WinRT します。 任意機能豊富でフル機能を備えた、独自のカスタム コントロールを行うことができます。 たとえば、カスタム コントロールを編集可能なデータ グリッドやビデオ プレーヤーでは、3 D ジオメトリのビジュアライザーとしてと複雑なものの形式になります。 ことができます。

## <a name="implementing-overridable-functions-such-as-measureoverride-and-onapplytemplate"></a>実装する*オーバーライド* **MeasureOverride** **OnApplyTemplate**などの機能

カスタム コントロールを派生する基本のランタイム クラスから派生自体もさらに、[**コントロール**](/uwp/api/windows.ui.xaml.controls.control)のランタイム クラスからです。 **コントロール**、 [**FrameworkElement**](/uwp/api/windows.ui.xaml.frameworkelement)、派生クラスで上書きできる[**UIElement**](/uwp/api/windows.ui.xaml.uielement)のオーバーライドの方法があります。 その方法を示すコード例を以下に示します。

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

*オーバーライド可能*関数で表示、自体を別の言語プロジェクションで異なります。 C# では、たとえば、オーバーライド関数通常として表示されます保護されている仮想関数。 C++/WinRT では、これら仮想も、保護されたが引き続きそれらを上書きし、上記のように、独自の実装を提供できます。

## <a name="important-apis"></a>重要な API
* [コントロール クラス](/uwp/api/windows.ui.xaml.controls.control)
* [DependencyProperty クラス](/uwp/api/windows.ui.xaml.dependencyproperty)
* [FrameworkElement クラス](/uwp/api/windows.ui.xaml.frameworkelement)
* [UIElement クラス](/uwp/api/windows.ui.xaml.uielement)

## <a name="related-topics"></a>関連トピック
* [コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)
* [カスタム依存関係プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)
