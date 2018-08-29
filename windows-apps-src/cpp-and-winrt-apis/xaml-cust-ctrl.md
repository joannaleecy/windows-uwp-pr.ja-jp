---
author: stevewhims
description: このトピックによって C + を使用して簡単なカスタム コントロールを作成する手順を追って説明/WinRT。 独自の豊富な機能とカスタマイズ可能な UI コントロールを作成するのには、ここの情報を構築できます。
title: C++/WinRT による XAML カスタム (テンプレート化) コントロール
ms.author: stwhi
ms.date: 08/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: ウィンドウ 10、uwp、標準、c では、cpp、winrt、投影、XAML では、カスタムのテンプレート、コントロール
ms.localizationpriority: medium
ms.openlocfilehash: c108175c66d27b2cdbd910a0f7653ca1befb68e9
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2917311"
---
# <a name="xaml-custom-templated-controls-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>カスタム (テンプレート) コントロールの XAML [C + + WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)

ユニバーサル Windows プラットフォーム (UWP) の最も強力な機能の 1 つは、XAML[コントロール](/uwp/api/windows.ui.xaml.controls.control)の種類に基づいて、カスタム コントロールを作成するユーザー インターフェイス (UI) のスタックを提供する柔軟性です。 XAML UI フレームワークは、[カスタム依存関係プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)と添付プロパティ、および[コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)では、豊富な機能とカスタマイズ可能なコントロールを作成しやすくなるなどの機能を提供します。 このトピックによって C + を使用して (テンプレート) のカスタム コントロールを作成する手順を追って説明/WinRT。

## <a name="create-a-blank-app-bglabelcontrolapp"></a>空白のアプリケーション (BgLabelControlApp) を作成します。
まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。 作成、 **Visual C++ の空白のアプリケーション (C + + WinRT)** プロジェクト、および*BgLabelControlApp*という名前を付けます。

カスタム (テンプレート) を表すための新しいクラスを作成するつもりです。 同じコンパイル ユニット内のクラスを作成および使用しています。 ですが、このクラス、XAML マークアップからとのランタイム クラスになることを理由にインスタンスを作成したいです。 また、この作成と使用のどちらにも C++/WinRT を使用します。

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

上の一覧は、依存関係プロパティ (DP) を宣言するときにフォローしているパターンを示します。 各 DP を 2 つの部分があります。 最初に、[報告](/uwp/api/windows.ui.xaml.dependencyproperty)の種類の読み取り専用の静的プロパティを宣言します。 DP と*プロパティ*の名前があります。 実装では、この静的プロパティを使用します。 第 2 に、読み取り/書き込みインスタンス プロパティを宣言するには、DP の名前と型を持つ。

> [!NOTE]
> 浮動小数点型で、DP をする場合、 `double` (`Double` [MIDL 3.0](/uwp/midl-3/)で)。 宣言して、DP の型を実装する`float`(`Single` MIDL で)、エラーの結果、XAML マークアップでその DP の値を設定し、 *、テキストからの 'Windows.Foundation.Single' の作成に失敗しました '<NUMBER>'*。

ファイルを保存し、プロジェクトをビルドします。 ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\BgLabelControlApp\Debug\BgLabelControlApp\Unmerged\BgLabelControl.winmd`) が作成されます。 次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。 これらのファイルには、IDL 内で宣言した**BgLabelControl**のランタイム クラスの実装を開始するためのスタブが含まれます。 これらのスタブは `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\BgLabelControl.h` と `BgLabelControl.cpp` です。

スタブ ファイル `BgLabelControl.h` と `BgLabelControl.cpp` を `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\` からプロジェクト フォルダー `\BgLabelControlApp\BgLabelControlApp\` にコピーします。 **ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。 コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。

## <a name="implement-the-bglabelcontrol-custom-control-class"></a>**BgLabelControl**のカスタム コントロール クラスを実装します。
ここで、`\BgLabelControlApp\BgLabelControlApp\BgLabelControl.h` と `BgLabelControl.cpp` を開いてランタイム クラスを実装してみましょう。 `BgLabelControl.h`、既定のスタイル キーを設定し、**ラベル**と**LabelProperty**を実装するコンス トラクターを変更、依存関係プロパティの値に変更を処理する**OnLabelChanged**という名前の静的なイベント ハンドラーを追加、プライベート メンバーの追加**LabelProperty**のバッキング フィールドを格納します。

このチュートリアルでは、私たちも使用している**OnLabelChanged**を。 ある依存関係プロパティをプロパティ変更コールバックを登録する方法を確認できるようにします。

、それらを追加した後、`BgLabelControl.h`次のように見えます。

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

    static void OnLabelChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& e);

private:
    static Windows::UI::Xaml::DependencyProperty m_labelProperty;
};
...
```

`BgLabelControl.cpp`、次のような静的メンバーを定義します。

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

void BgLabelControl::OnLabelChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& e) {}
...
```

## <a name="design-the-default-style-for-bglabelcontrol"></a>**BgLabelControl**の既定のスタイルをデザインします。

コンス トラクターでは、 **BgLabelControl**は、自身の既定のスタイル キーを設定します。 どのようなの*です*が、既定のスタイルですか。 カスタム (テンプレート) コントロールを既定のスタイルがある必要があります&mdash;既定のコントロール テンプレートを含む&mdash;コントロールのコンシューマーは、スタイルまたはテンプレートを設定しない場合に、レンダリングに使用できることです。 このセクションで、既定のスタイルを含むプロジェクトをマークアップ ファイルを追加します。

[プロジェクト] ノードの下は、新しいフォルダーを作成し、「テーマ」という名前を付けます。 `Themes`、 **Visual C++** の型の新しい項目を追加 > **XAML** > **XAML ビュー**では、し、「Generic.xaml」という名前を付けます。 フォルダーとファイル名にする必要が次のようなカスタム コントロールの既定のスタイルを検索するため、XAML フレームワークのために。 デフォルトの内容を削除する`Generic.xaml`、次のマークアップに貼り付けます。

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

この例では、既定のスタイルを設定する唯一のプロパティは、コントロール テンプレートです。 テンプレートは、正方形 (背景は XAML の[コントロール](/uwp/api/windows.ui.xaml.controls.control)の種類のすべてのインスタンスが**バック グラウンド**プロパティにバインドされている)、およびテキストの要素 (テキストが、 **BgLabelControl::Label**の依存関係プロパティにバインドされている) で構成されます。

## <a name="add-an-instance-of-bglabelcontrol-to-the-main-ui-page"></a>UI のメイン ページに**BgLabelControl**のインスタンスを追加します。

メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。 ( **StackPanel**) 内の**Button**要素の直後後には、次のマークアップを追加します。

```xaml
<local:BgLabelControl Background="Red" Label="Hello, World!"/>
```

ディレクティブを組み込むと、次の追加も、 `MainPage.h` 、 **MainPage**の型 (XAML のマークアップと命令型コードをコンパイルするの組み合わせ) が**BgLabelControl**のカスタム コントロールの種類を認識できるようにします。

```cppwinrt
// MainPage.h
...
#include "BgLabelControl.h"
...
```

ここでプロジェクトをビルドして実行します。 既定のコントロール テンプレートは、バインドしている背景ブラシ、およびマークアップの**BgLabelControl**インスタンスのラベルに表示されます。

このチュートリアルでは、(テンプレート) のカスタム コントロールの簡単な例を示しました C + で + WinRT。 任意に豊富な機能を備えた独自のカスタム コントロールを行うことができます。 たとえば、カスタム コントロールは、何か複雑な作業は編集可能なデータ グリッド、ビデオ プレーヤー、または 3D ジオメトリのビジュアライザーのフォームを実行できます。

## <a name="important-apis"></a>重要な API
* [コントロール](/uwp/api/windows.ui.xaml.controls.control)
* [DependencyProperty](/uwp/api/windows.ui.xaml.dependencyproperty)

## <a name="related-topics"></a>関連トピック
* [コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)
* [カスタム依存関係プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)
